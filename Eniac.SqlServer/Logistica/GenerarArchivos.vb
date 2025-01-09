Public Class GenerarArchivos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetRutasArchivo(IdVendedor As Integer, ByVal ruta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT RC.Orden")
         .AppendFormatLine("      ,RC.Dia")
         .AppendFormatLine("      ,C.CodigoCliente")
         .AppendFormatLine("      ,R.IdVendedor")
         .AppendFormatLine("      ,E.NombreEmpleado")
         .AppendFormatLine("      ,RC.IdRuta")
         .AppendFormatLine("  FROM MovilRutasClientes RC")
         .AppendFormatLine(" INNER JOIN MovilRutas R ON R.IdRuta = RC.IdRuta")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = rc.IdCliente")
         .AppendFormatLine(" INNER JOIN Empleados E ON E.IdEmpleado = R.IdVendedor ")
         .AppendFormatLine(" WHERE 1 = 1")
         If IdVendedor > 0 Then
            .AppendFormatLine("   AND R.IdVendedor = {0}", IdVendedor)
         End If
         If ruta <> 0 Then
            .AppendFormatLine("   AND R.idRuta = {0}", ruta)
         End If
         .AppendFormatLine(" ORDER BY R.NroDocVendedor,RC.Dia,RC.Orden")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function getRutasSeleccionadas(IdVendedor As Integer, ByVal ruta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT X.idruta")
         .AppendFormatLine("  FROM (SELECT RC.Orden")
         .AppendFormatLine("              ,RC.Dia")
         .AppendFormatLine("              ,C.CodigoCliente")
         .AppendFormatLine("              ,R.IdVendedor")
         .AppendFormatLine("              ,RC.IdRuta")
         .AppendFormatLine("          FROM MovilRutasClientes RC")
         .AppendFormatLine("         INNER JOIN MovilRutas R ON R.IdRuta = RC.IdRuta")
         .AppendFormatLine("         INNER JOIN Clientes C ON C.IdCliente = RC.IdCliente")
         .AppendFormatLine("         WHERE 1 = 1")
         If IdVendedor > 0 Then
            .AppendFormatLine("           AND R.IdVendedor = {0}", IdVendedor)
         End If
         If ruta <> 0 Then
            .AppendFormatLine("           AND R.idRuta = {0}", ruta)
         End If
         .AppendFormatLine(" ) x")

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetRubrosArchivo(sucursal As Integer,
                                    IdVendedor As Integer,
                                    preciosConIVA As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("SELECT R.IdRubro").AppendLine()
         .AppendFormat("      ,R.NombreRubro").AppendLine()
         .AppendFormat(" FROM Productos P").AppendLine()
         .AppendFormat(" INNER JOIN ProductosSucursalesPrecios PSP on PSP.IdProducto = P.IdProducto").AppendLine()
         .AppendFormat(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro").AppendLine()
         .AppendFormat(" WHERE PSP.precioVenta <> 0").AppendLine()
         .AppendFormat("   AND P.Activo = 1").AppendLine()
         .AppendFormat("   AND PSP.idSucursal = {0}", sucursal).AppendLine()
         .AppendFormat("   AND P.PublicarEnWeb = 1").AppendLine()
         .AppendFormat(" GROUP BY R.IdRubro,R.NombreRubro").AppendLine()
         .AppendFormat(" ORDER BY R.IdRubro").AppendLine()
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetArticulosArchivo(sucursal As Integer,
                                       IdVendedor As Integer,
                                       preciosConIVA As Boolean,
                                       exportaConIVA As Boolean,
                                       idListaPrecios As Integer,
                                       IncluirEsCambiableEsBonificable As Boolean) As DataTable


      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT ROW_NUMBER() OVER(order by p.idProducto ) as autonum")
         .AppendLine("      ,p.IdProducto")
         .AppendLine("      ,p.idrubro AS IdFamilia")
         .AppendLine("      ,REPLACE(p.NombreProducto, ';', '_') AS NombreProducto")
         .AppendLine("      ,REPLACE(p.nombrecorto, ';', '_') AS corto")
         .AppendLine("      ,p.IdProducto")

         If idListaPrecios = -1 Then
            .AppendLine("      ,CAST(0 AS numeric(14,2)) AS precio1")
            .AppendLine("      ,CAST(0 AS numeric(14,2)) AS precio2")
            .AppendLine("      ,CAST(0 AS numeric(14,2)) AS c9")
            .AppendLine("      ,CAST(0 AS numeric(14,2)) AS c10")
         Else
            If exportaConIVA Then
               If preciosConIVA Then
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS precio1")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS precio2")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS c9")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS c10")
               Else
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta*(1+ p.Alicuota/100),2)+P.ImporteImpuestoInterno AS numeric(14,2)) AS precio1")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta*(1+ p.Alicuota/100),2)+P.ImporteImpuestoInterno AS numeric(14,2)) AS precio2")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta*(1+ p.Alicuota/100),2)+P.ImporteImpuestoInterno AS numeric(14,2)) AS c9")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta*(1+ p.Alicuota/100),2)+P.ImporteImpuestoInterno AS numeric(14,2)) AS c10")
               End If
            Else
               If preciosConIVA Then
                  .AppendLine("      ,CAST(ROUND((psp.PrecioVenta-P.ImporteImpuestoInterno)/(1+ p.Alicuota/100),2) AS numeric(14,2)) AS precio1")
                  .AppendLine("      ,CAST(ROUND((psp.PrecioVenta-P.ImporteImpuestoInterno)/(1+ p.Alicuota/100),2) AS numeric(14,2)) AS precio2")
                  .AppendLine("      ,CAST(ROUND((psp.PrecioVenta-P.ImporteImpuestoInterno)/(1+ p.Alicuota/100),2) AS numeric(14,2)) AS c9")
                  .AppendLine("      ,CAST(ROUND((psp.PrecioVenta-P.ImporteImpuestoInterno)/(1+ p.Alicuota/100),2) AS numeric(14,2)) AS c10")
               Else
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS precio1")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS precio2")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS c9")
                  .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS c10")
               End If
            End If
         End If

         .AppendLine("      ,p.embalaje AS Presentacion")
         .AppendLine("      ,'0' AS cambio")
         If IncluirEsCambiableEsBonificable Then
            .AppendFormat("      ,CASE WHEN P.{0} = 0 THEN '{1}' ELSE '{2}' END AS {0}", "EsCambiable", Boolean.FalseString.ToLower(), Boolean.TrueString.ToLower()).AppendLine()
            .AppendFormat("      ,CASE WHEN P.{0} = 0 THEN '{1}' ELSE '{2}' END AS {0}", "EsBonificable", Boolean.FalseString.ToLower(), Boolean.TrueString.ToLower()).AppendLine()
         End If            'If IncluirEsCambiableEsBonificable Then

         .AppendLine("  FROM Productos P")
         .AppendLine(" INNER JOIN ProductosSucursalesPrecios PSP ON psp.IdProducto = p.IdProducto")

         .AppendLine(" WHERE P.Activo = 'True'")
         .AppendLine("   AND P.PublicarEnWeb = 1")
         .AppendLine("   AND PSP.precioVenta <> 0")
         .AppendLine("   AND PSP.idSucursal=" & sucursal)
         If idListaPrecios > -1 Then
            .AppendLine("   AND PSP.IdListaPrecios = " & idListaPrecios.ToString)
         Else
            .AppendLine("   AND PSP.IdListaPrecios = 0")
         End If

         .AppendLine(" ORDER BY autonum")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesArchivos(IdVendedor As Integer, idRuta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.CodigoCliente")
         .AppendFormatLine("      ,Ca.NombreCalle")
         .AppendFormatLine("      ,C.Altura")
         .AppendFormatLine("      ,C.ObservacionWeb AS Observacion")
         .AppendFormatLine("      ,C.NombreCliente")
         .AppendFormatLine("      ,CF.NombreCategoriaFiscal")
         .AppendFormatLine("      ,C.CUIT")
         .AppendFormatLine("      ,C.IdCategoriaFiscal")
         .AppendFormatLine("  FROM Clientes c")
         .AppendFormatLine(" INNER JOIN Calles CA ON CA.IdCalle = C.IdCalle")
         .AppendFormatLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
         .AppendFormatLine(" INNER JOIN MovilRutasClientes RC ON RC.IdCliente = C.IdCliente")
         .AppendFormatLine(" INNER JOIN MovilRutas r ON R.IdRuta = RC.IdRuta")
         .AppendFormatLine(" WHERE 1 = 1")
         .AppendFormatLine("   AND RC.idRuta = {0}", idRuta)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetHistoricosArchivos(IdVendedor As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT C.CodigoCliente, ")
         .Append(" vp.IdProducto, ")
         .Append(" 0 as cant1, ")
         .Append(" 0 as cant2, ")
         .Append(" 0 as cant3, ")
         .Append(" 0 as cant4 ")
         .Append(" from Ventas v, VentasProductos vp, Clientes C")
         .Append(" where v.IdSucursal = vp.IdSucursal ")
         .Append(" and v.IdTipoComprobante=vp.IdTipoComprobante ")
         .Append(" and v.Letra=vp.Letra ")
         .Append(" and v.CentroEmisor=vp.CentroEmisor ")
         .Append(" and v.NumeroComprobante=vp.NumeroComprobante ")

         .Append(" and v.[IdCliente]=c.idcliente")
         '.Append(" and v.TipoDocCliente = c.TipoDocCliente")
         '.Append(" and v.NroDoccliente = c.NroDocCliente")

         If IdVendedor > 0 Then
            .AppendFormat(" and v.IdVendedor = {0}", IdVendedor) ' 4
         End If

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetListasDePreciosArchivo(idListaPreciosCol As Integer(), idSucursal As Integer, exportaConIVA As Boolean, preciosConIVA As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("SELECT PSP.IdProducto")
         .AppendFormat("      ,PSP.IdListaPrecios")
         .AppendFormat("      ,LP.NombreListaPrecios")

         If exportaConIVA Then
            If preciosConIVA Then
               .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS PrecioVenta")
            Else
               .AppendLine("      ,CAST(ROUND(psp.PrecioVenta*(1+ p.Alicuota/100),2)+P.ImporteImpuestoInterno AS numeric(14,2)) AS PrecioVenta")
            End If
         Else
            If preciosConIVA Then
               .AppendLine("      ,CAST(ROUND((psp.PrecioVenta-P.ImporteImpuestoInterno)/(1+ p.Alicuota/100),2) AS numeric(14,2)) AS PrecioVenta")
            Else
               .AppendLine("      ,CAST(ROUND(psp.PrecioVenta,2) AS numeric(14,2)) AS PrecioVenta")
            End If
         End If

         '.AppendFormat("      ,PSP.PrecioVenta")
         .AppendFormat("      ,CONVERT(NVARCHAR(20), PSP.FechaActualizacion, 120) FechaActualizacion")
         .AppendFormat("  FROM ProductosSucursalesPrecios PSP")
         .AppendFormat(" INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = PSP.IdListaPrecios")
         .AppendFormat(" INNER JOIN Productos P ON P.IdProducto = PSP.IdProducto")
         .AppendFormat(" WHERE PSP.IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND PSP.PrecioVenta <> 0")
         .AppendFormat("   AND P.Activo = 1")
         .AppendFormat("   AND P.PublicarEnWeb = 1")
         If idListaPreciosCol.Length > 0 Then
            .AppendFormat("   AND PSP.IdListaPrecios IN (")
            For Each id As Integer In idListaPreciosCol
               .AppendFormat("{0},", id)
            Next
            .AppendFormat("{0})", idListaPreciosCol(0))
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function getAuxHistoricos(IdVendedor As Integer, ByVal filaPrincipal As DataRow) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT top 4 ")
         .Append(" C.CodigoCliente, ")
         .Append(" vp.IdProducto, ")
         .Append(" vp.Cantidad ")
         .Append(" from Ventas v, VentasProductos vp, Clientes C ")

         .Append(" where v.IdSucursal = vp.IdSucursal ")
         .Append(" and v.IdTipoComprobante=vp.IdTipoComprobante ")
         .Append(" and v.Letra=vp.Letra ")
         .Append(" and v.CentroEmisor=vp.CentroEmisor ")
         .AppendFormat(" and vp.idproducto=  '{0}'", filaPrincipal("idproducto"))

         .Append(" and v.[IdCliente]=c.idcliente")

         '.Append(" and v.TipoDocCliente = c.TipoDocCliente")
         '.Append(" and v.NroDoccliente = c.NroDocCliente")

         If IdVendedor > 0 Then
            .AppendFormat(" and v.IdVendedor = {0}", IdVendedor) ' 4
         End If

         .Append(" order by v.fecha desc")
      End With

      Return Me.GetDataTable(stb.ToString())


   End Function

   Public Function GetRutasPreventista(ByVal preventista As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb

         .Append(" Select r.[idruta]")
         .Append(" FROM ")
         .Append(" [Rutas] R")

         If preventista <> 0 Then
            .Append(" where ")
            .AppendFormat(" R.nrodocVendedor = {0}", preventista) ' 3
         End If

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
