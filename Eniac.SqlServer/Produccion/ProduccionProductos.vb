Public Class ProduccionProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionProductos_I(idSucursal As Integer,
                                    idProduccion As Integer,
                                    orden As Integer,
                                    idProducto As String,
                                    cantidad As Decimal,
                                    idLote As String,
                                    fechaVencimiento As Date,
                                    idFormula As Integer,
                                    idProduccionProceso As Integer,
                                    idProduccionForma As Integer,
                                    espmm As Decimal,
                                    espPies As String,
                                    codigoSAE As Integer,
                                    largoExtAlto As Decimal,
                                    anchoIntBase As Decimal,
                                    urlPlano As String,
                                    idDeposito As Integer,
                                    idUbicacion As Integer)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("INSERT INTO ProduccionProductos (")
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdProduccion")
         .AppendFormatLine("   , Orden")
         .AppendFormatLine("   , IdProducto")
         .AppendFormatLine("   , CantidadProducida")
         .AppendFormatLine("   , IdLote")
         .AppendFormatLine("   , FechaVencimiento")
         .AppendFormatLine("   , IdFormula")

         .AppendFormatLine("   , IdProduccionProceso")
         .AppendFormatLine("   , IdProduccionForma")
         .AppendFormatLine("   , Espmm")
         .AppendFormatLine("   , EspPies")
         .AppendFormatLine("   , CodigoSAE")
         .AppendFormatLine("   , LargoExtAlto")
         .AppendFormatLine("   , AnchoIntBase")
         .AppendFormatLine("   , UrlPlano")
         .AppendFormatLine("   , IdDeposito")
         .AppendFormatLine("   , IdUbicacion")

         .AppendFormatLine("   )  VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   ,  {0} ", idProduccion)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   , '{0}'", idProducto)
         .AppendFormatLine("   ,  {0} ", cantidad)
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idLote))

         If fechaVencimiento = Nothing Then
            .AppendFormatLine("   , NULL")
         Else
            .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaVencimiento, True))
         End If
         .AppendFormatLine("   ,  {0}", idFormula)

         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idProduccionProceso))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idProduccionForma))
         .AppendFormatLine("   ,  {0} ", GetStringFromDecimal(espmm))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(espPies))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(codigoSAE))
         .AppendFormatLine("   ,  {0} ", GetStringFromDecimal(largoExtAlto))
         .AppendFormatLine("   ,  {0} ", GetStringFromDecimal(anchoIntBase))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(urlPlano))

         .AppendFormatLine("   ,  {0}", idDeposito)
         .AppendFormatLine("   ,  {0}", idUbicacion)

         .AppendFormatLine(")")
      End With

      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProduccionProductos")

   End Sub

   Public Function ProduccionProductos_GA(idSucursal As Integer, idproduccion As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT PP.*")
         .AppendFormatLine("  FROM ProduccionProductos PP")
         .AppendFormatLine(" WHERE PP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PP.IdProduccion = {0}", idproduccion)
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPorRangoFechas(idSucursal As Integer, desde As Date, hasta As Date,
                                     idProducto As String, idEstado As Entidades.OrdenProduccionEstado.FiltroEstadosInforme,
                                     marcas As Entidades.Marca(), rubros As Entidades.Rubro()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT Pr.Fecha")
         .AppendFormatLine("      ,CONVERT(DATE, Pr.Fecha) Fecha_FECHA")
         .AppendFormatLine("      ,CONVERT(TIME, Pr.Fecha) Fecha_HORA")
         .AppendFormatLine("      ,DATEDIFF(DAY, CONVERT(DATE, Pr.Fecha), CONVERT(DATE, GETDATE())) DP")
         .AppendFormatLine("      ,PP.IdProduccion")
         .AppendFormatLine("      ,PP.IdProducto")
         .AppendFormatLine("      ,P.NombreProducto")
         .AppendFormatLine("      ,PP.IdFormula")
         .AppendFormatLine("      ,PF.NombreFormula")
         .AppendFormatLine("      ,M.NombreMarca")
         .AppendFormatLine("      ,R.NombreRubro")
         .AppendFormatLine("      ,PP.CantidadProducida AS Cantidad ")
         .AppendFormatLine("      ,E.NombreEmpleado ")
         .AppendFormatLine("      ,Pr.Usuario ")
         .AppendFormatLine("      ,Pr.IdEstado")
         .AppendFormatLine("  FROM ProduccionProductos PP ")
         .AppendFormatLine("  LEFT JOIN Produccion Pr ON Pr.IdProduccion = PP.IdProduccion ")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = PP.IdProducto ")
         .AppendFormatLine("  LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
         .AppendFormatLine("  LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN Empleados E ON E.IdEmpleado = Pr.IdResponsable ")
         .AppendFormatLine(" WHERE Pr.IdSucursal= {0}", idSucursal)
         .AppendFormatLine("   AND Pr.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("   AND Pr.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND PP.IdProducto = '{0}'", idProducto)
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")

         If idEstado <> Entidades.OrdenProduccionEstado.FiltroEstadosInforme.TODOS Then
            .AppendFormatLine("	 AND Pr.IdEstado = '{0}'", idEstado.ToString())
         End If
         .AppendLine(" ORDER BY Pr.Fecha, P.NombreProducto")
      End With

      Return GetDataTable(stb)
   End Function
   Public Function GetPorRangoFechasProd(idSucursal As Integer, producciones As String) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT PP.IdSucursal")
         .AppendLine("      ,PP.IdProduccion")
         .AppendLine("      ,Pr.Fecha")
         .AppendLine("      ,PP.IdProducto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,PP.IdFormula")
         .AppendLine("      ,PF.NombreFormula")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,PP.CantidadProducida")
         .AppendLine("      ,PP.IdLote")
         .AppendLine("      ,PP.FechaVencimiento")
         .AppendLine(" FROM ProduccionProductos PP ")
         .AppendLine(" LEFT JOIN Produccion Pr ON Pr.IdProduccion = PP.IdProduccion ")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = PP.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine("  LEFT JOIN Empleados E ON E.IdEmpleado = Pr.IdResponsable")
         .AppendLine("  WHERE Pr.IdSucursal= " & idSucursal.ToString())

         .AppendLine("   AND Pr.IdProduccion in (" & producciones & ")")
         .AppendLine(" ORDER BY Pr.Fecha, P.NombreProducto")
      End With

      Return GetDataTable(stb)

   End Function
   Public Function GetTotalPorProducto(idSucursal As Integer, desde As Date, hasta As Date,
                                       idProducto As String, marcas As Entidades.Marca(), rubros As Entidades.Rubro()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PP.IdProducto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,PP.IdFormula")
         .AppendLine("      ,PF.NombreFormula")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,CONVERT(DATE, Pr.Fecha) AS Fecha")
         .AppendLine("      ,SUM(PP.CantidadProducida) AS Cantidad")
         .AppendLine(" FROM ProduccionProductos PP ")
         .AppendLine(" LEFT JOIN Produccion Pr ON Pr.IdProduccion = PP.IdProduccion ")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = PP.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  WHERE Pr.IdSucursal= {0}", idSucursal)
         .AppendFormatLine("	  AND Pr.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("	  AND Pr.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("	 AND PP.IdProducto = '{0}'", idProducto)
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")

         .AppendLine("  AND Pr.IdEstado <> 'ANULADA' ")
         .AppendLine(" GROUP BY PP.IdProducto, P.NombreProducto, PP.IdFormula ,PF.NombreFormula, M.NombreMarca, R.NombreRubro, Pr.Fecha ")
         .AppendLine(" ORDER BY Pr.Fecha, P.NombreProducto")
      End With

      Return GetDataTable(stb)
   End Function

   'Private Sub SelectTexto(stb As StringBuilder)
   '   With stb
   '      .AppendLine("SELECT M.*")
   '      .AppendLine("  FROM MovimientosDetalle M")
   '   End With
   'End Sub

   'Public Overloads Function Buscar(columna As String, valor As String) As DataTable
   '   Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "M.")
   'End Function

End Class