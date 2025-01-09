Partial Class Ventas

#Region "Get Suma Por"
   Public Function GetSumaPorProductos(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito(), ubicacion As Entidades.SucursalUbicacion,
                                       desde As Date, hasta As Date,
                                       idVendedor As Integer, idCliente As Long,
                                       idMarca As Integer, idRubro As Integer, idSubRubro As Integer,
                                       idProducto As String, idProveedor As Long,
                                       alertaDeCaja As Boolean,
                                       idCategoria As Integer,
                                       unificarSumaProductos As Boolean,
                                       idListaPrecios As Integer,
                                       idCaja As Integer, idSucursalCaja As Integer,
                                       idTransportista As Integer,
                                       mostrarProductodeVenta As Boolean, mostrarProveedorHabitual As Boolean,
                                       esComercial As Entidades.Publicos.SiNoTodos,
                                       cantidadDias As Integer,
                                       nivelAgrupamiento As Entidades.Publicos.Reportes.NivelAgrupamientoStock) As DataTable
      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetSumaPorProductos(sucursales, depositos, ubicacion,
                                     New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa),
                                     desde, hasta,
                                     idVendedor, idCliente,
                                     idMarca, idRubro, idSubRubro,
                                     idProducto, idProveedor,
                                     alertaDeCaja,
                                     idCategoria,
                                     unificarSumaProductos,
                                     idListaPrecios,
                                     idCaja, idSucursalCaja,
                                     idTransportista,
                                     mostrarProductodeVenta, mostrarProveedorHabitual,
                                     esComercial, cantidadDias, nivelAgrupamiento)
   End Function

   Public Function GetSumaPorMarcas(Sucursales As Entidades.Sucursal(),
                                       Desde As Date,
                                       Hasta As Date,
                                       IdVendedor As Integer,
                                       IdCliente As Long,
                                       IdMarca As Integer,
                                       IdRubro As Integer,
                                       IdSubRubro As Integer,
                                       IdProveedor As Long,
                                       AlertaDeCaja As Boolean,
                                       IdCategoria As Integer,
                                       UnificarSumaProductos As Boolean,
                                       idListaPrecios As Integer,
                                       idCaja As Integer,
                                       idSucursalCaja As Integer) As DataTable

      Dim sql As SqlServer.Ventas
      Dim dt As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim IvaDiscriminado As Boolean

      IvaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Ventas(da)

         dt = sql.GetSumaPorMarcas(Sucursales,
                                   Desde, Hasta,
                                   IdVendedor,
                                   IdCliente,
                                   IdMarca,
                                   IdRubro,
                                   IdSubRubro,
                                   IdProveedor,
                                   AlertaDeCaja,
                                   IdCategoria,
                                   UnificarSumaProductos,
                                   idListaPrecios,
                                   idCaja,
                                   idSucursalCaja,
                                   IvaDiscriminado)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function
   Public Function GetSumaPorRubros(xAgrupamiento As Entidades.Venta.SumaXAgrupamiento, Sucursales As Entidades.Sucursal(),
                                       Desde As Date,
                                       Hasta As Date,
                                       IdVendedor As Integer,
                                       IdCliente As Long,
                                       IdMarca As Integer,
                                       IdRubro As Integer,
                                       IdSubRubro As Integer,
                                       IdProveedor As Long,
                                       AlertaDeCaja As Boolean,
                                       IdCategoria As Integer,
                                       UnificarSumaProductos As Boolean,
                                       idListaPrecios As Integer,
                                       idCaja As Integer,
                                       idSucursalCaja As Integer) As DataTable

      Dim sql As SqlServer.Ventas
      Dim dt As DataTable

      Try
         Me.da.OpenConection()

         Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
         Dim IvaDiscriminado As Boolean

         IvaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado

         sql = New SqlServer.Ventas(da)

         dt = sql.GetSumaPorRubros(xAgrupamiento, Sucursales,
                                   Desde, Hasta,
                                   IdVendedor,
                                   IdCliente,
                                   IdMarca,
                                   IdRubro,
                                   IdSubRubro,
                                   IdProveedor,
                                   AlertaDeCaja,
                                   IdCategoria,
                                   UnificarSumaProductos,
                                   idListaPrecios,
                                   idCaja,
                                   idSucursalCaja,
                                   IvaDiscriminado)

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function
#End Region

#Region "Get Total Por"
   Public Function GetTotalPorComprobante(periodoFiscal As Integer,
                                       grabaLibro As String) As DataTable
      Return New SqlServer.Ventas(da).GetTotalPorComprobante(actual.Sucursal.IdEmpresa, periodoFiscal, grabaLibro)
   End Function

   Public Function GetTotalPorCategoriaFiscal(ByVal IdSucursal As Integer,
                                                ByVal Desde As Date, ByVal Hasta As Date,
                                                Optional ByVal GrabaLibro As String = "TODOS") As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CF.NombreCategoriaFiscal")
         .AppendLine("	,SUM(V.TotalImpuestos) as TotalImpuestos ")
         .AppendLine("  ,SUM(V.TotalImpuestoInterno) AS TotalImpuestoInterno")
         .AppendLine("	,SUM(V.ImporteTotal) as Total ")
         .AppendLine("	FROM Ventas V, CategoriasFiscales CF, TiposComprobantes TC ")
         .AppendLine(" WHERE V.IdCategoriaFiscal=CF.IdCategoriaFiscal ")
         .AppendLine("   AND V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("   AND TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero

         'El IVA es por Empresa, no por Sucursal. 
         '.AppendLine("	 AND V.IdSucursal = " & IdSucursal.ToString())

         .AppendLine("	 AND CONVERT(varchar(11), V.fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("    AND CONVERT(varchar(11), V.fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")

         If GrabaLibro = "SI" Then
            .AppendLine("	AND TC.GrabaLibro ='True'")
         ElseIf GrabaLibro = "NO" Then
            .AppendLine("	AND TC.GrabaLibro ='False'")
         End If

         .AppendLine("	GROUP BY CF.NombreCategoriaFiscal")
         .AppendLine("	HAVING SUM(V.TotalImpuestos)<>0 OR SUM(V.ImporteTotal)<>0 OR SUM(V.TotalImpuestoInterno) <> 0")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetTotalPorDia(ByVal IdSucursal As Integer,
                                    ByVal Desde As Date, ByVal Hasta As Date,
                                    Optional ByVal GrabaLibro As String = "TODOS") As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CONVERT(varchar(11), V.fecha, 120) as Fecha ")

         'RI
         If oCategoriaFiscalEmpresa.IvaDiscriminado Then
            .AppendLine("	,SUM(V.SubTotal) as SubTotal ")
            .AppendLine("	,SUM(V.TotalImpuestos) as TotalImpuestos ")
            .AppendLine("  ,SUM(V.TotalImpuestoInterno) AS TotalImpuestoInterno")
         Else
            'Monotributo

            .AppendLine("	,SUM(V.ImporteTotal) as SubTotal ")
            .AppendLine("	,0 as TotalImpuestos ")
            .AppendLine("  ,0 AS TotalImpuestoInterno")
         End If

         .AppendLine("	,SUM(V.ImporteTotal) as ImporteTotal ")
         '.AppendLine("  ,SUM(SUM(V.ImporteTotal)) OVER (ORDER BY CONVERT(varchar(11), V.fecha, 120) ASC) AS Acumulado") funciona con sql 2014
         .AppendLine("  ,0 AS Acumulado")
         .AppendLine("	FROM Ventas V, TiposComprobantes TC ")
         .AppendLine(" WHERE V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("	AND V.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("	AND CONVERT(varchar(11), V.fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	AND CONVERT(varchar(11), V.fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")

         If GrabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         End If

         .AppendLine("   AND TC.AfectaCaja = 'True' ")
         .AppendLine("   AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)

         .AppendLine("	GROUP BY CONVERT(varchar(11), V.fecha, 120)")
         .AppendLine("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function InfTotalesDeVentasPorClientes(sucursales As Entidades.Sucursal(),
                                                 desde As Date, hasta As Date,
                                                 conIVA As Boolean,
                                                 idCliente As Long,
                                                 idTipoComprobante As String,
                                                 idZonaGeografica As String,
                                                 idMarca As Integer,
                                                 idRubro As Integer,
                                                 IdVendedor As Integer,
                                                 tipoVendedor As String,
                                                 idProducto As String,
                                                 grupos As Entidades.Grupo(),
                                                 GrabaLibro As String,
                                                 agruparXRubro As Boolean,
                                                 agruparXMarca As Boolean,
                                                 agruparXVendedor As String,
                                                 IdProveedor As Long,
                                                 incluirPreComprobantes As Boolean,
                                              Habitual As Boolean) As DataTable

      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         Dim dt As DataTable
         dt = sql.InfTotalesDeVentasPorClientes(sucursales,
                                                desde, hasta, conIVA,
                                                idCliente, idTipoComprobante,
                                                idZonaGeografica, idMarca, idRubro,
                                                IdVendedor, tipoVendedor, idProducto, actual.NivelAutorizacion, grupos, GrabaLibro,
                                                agruparXRubro,
                                                agruparXMarca,
                                                agruparXVendedor,
                                                IdProveedor,
                                                incluirPreComprobantes,
                                                Habitual)
         Return dt
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetTotalVentasSucursales(ByVal suc As List(Of Integer),
                                             ByVal Desde As Date,
                                             ByVal Hasta As Date) As DataTable

      Dim sql As SqlServer.Ventas

      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Ventas(da)
         dt = sql.VentasTotalSucursal(suc, Desde, Hasta)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function
#End Region

End Class