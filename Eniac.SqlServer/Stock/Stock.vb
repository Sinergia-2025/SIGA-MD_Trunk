Public Class Stock
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetProductosMasMovimientos(sucursal As Integer,
                                              desde As Date, hasta As Date,
                                              tipoMovimiento As String,
                                              cantidad As Integer,
                                              orden As String,
                                              idMarca As Integer,
                                              idRubro As Integer,
                                              idSubRubro As Integer,
                                              idCliente As Long,
                                              idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         'Obtengo los Movimiento del tipo "Compras"
         .AppendLine("SELECT TOP " & cantidad.ToString())
         .AppendLine("  M.NombreMarca, R.NombreRubro, A.IdProducto, A.NombreProducto, SUM(A.Cantidad) as Cantidad ")
         '--
         .AppendLine("  , A.IdaAtributoProducto01, A.DescripcionAtributo01 ")
         .AppendLine("  , A.IdaAtributoProducto02, A.DescripcionAtributo02 ")
         .AppendLine("  , A.IdaAtributoProducto03, A.DescripcionAtributo03 ")
         .AppendLine("  , A.IdaAtributoProducto04, A.DescripcionAtributo04 ")
         '--
         .AppendLine("  FROM ")
         .AppendLine("  ( ")
         .AppendLine("  SELECT Prod.IdMarca, Prod.IdRubro, RIGHT(REPLICATE(' ',15) + MCP.IdProducto,15) as IdProducto, Prod.NombreProducto, MCP.Precio, MCP.Cantidad ")
         '--<
         .AppendLine("	, (CASE WHEN MCP.IdaAtributoProducto01 IS NULL THEN 0  ELSE AP01.IdaAtributoProducto END) AS IdaAtributoProducto01")
         .AppendLine("  , (CASE WHEN MCP.IdaAtributoProducto01 IS NULL THEN '' ELSE AP01.Descripcion END) AS DescripcionAtributo01")
         .AppendLine("  , (CASE WHEN MCP.IdaAtributoProducto02 IS NULL THEN 0  ELSE AP02.IdaAtributoProducto END) AS IdaAtributoProducto02")
         .AppendLine("  , (CASE WHEN MCP.IdaAtributoProducto02 IS NULL THEN '' ELSE AP02.Descripcion END) AS DescripcionAtributo02")
         .AppendLine("  , (CASE WHEN MCP.IdaAtributoProducto03 IS NULL THEN 0  ELSE AP03.IdaAtributoProducto END) AS IdaAtributoProducto03")
         .AppendLine("  , (CASE WHEN MCP.IdaAtributoProducto03 IS NULL THEN '' ELSE AP03.Descripcion END) AS DescripcionAtributo03")
         .AppendLine("  , (CASE WHEN MCP.IdaAtributoProducto04 IS NULL THEN 0  ELSE AP04.IdaAtributoProducto END) AS IdaAtributoProducto04")
         .AppendLine("  , (CASE WHEN MCP.IdaAtributoProducto04 IS NULL THEN '' ELSE AP04.Descripcion END) AS DescripcionAtributo04")
         '--
         .AppendLine("    FROM TiposMovimientos TM, Productos Prod, MovimientosStock MC  ")
         .AppendLine("    INNER JOIN Proveedores P ON P.IdProveedor = MC.IdProveedor ")
         '--
         .AppendLine(" 	  INNER JOIN MovimientosStockProductos MCP ON MC.IdSucursal = MCP.IdSucursal")
         .AppendLine("		  AND  MC.IdTipoMovimiento = MCP.IdTipoMovimiento")
         .AppendLine("	     AND MC.NumeroMovimiento = MCP.NumeroMovimiento  ")
         '--
         .AppendLine("    LEFT OUTER JOIN TiposComprobantes TC ON MC.IdTipoComprobante = TC.IdTipoComprobante  ")
         .AppendLine("    LEFT OUTER JOIN Sucursales S ON MC.IdSucursal2 = S.IdSucursal  ")
         '--
         .AppendLine("    LEFT OUTER JOIN AtributosProductos AP01 ON AP01.IdaAtributoProducto = MCP.IdaAtributoProducto01")
         .AppendLine("    LEFT OUTER JOIN AtributosProductos AP02 ON AP02.IdaAtributoProducto = MCP.IdaAtributoProducto02")
         .AppendLine("    LEFT OUTER JOIN AtributosProductos AP03 ON AP03.IdaAtributoProducto = MCP.IdaAtributoProducto03")
         .AppendLine("    LEFT OUTER JOIN AtributosProductos AP04 ON AP04.IdaAtributoProducto = MCP.IdaAtributoProducto04")
         '--
         .AppendLine("  WHERE MC.IdTipoMovimiento = TM.IdTipoMovimiento ")
         .AppendLine("    AND MC.IdSucursal = MCP.IdSucursal  ")
         .AppendLine("    AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento  ")
         .AppendLine("    AND MC.NumeroMovimiento = MCP.NumeroMovimiento  ")
         .AppendLine("    AND MCP.IdProducto = Prod.IdProducto  ")
         .AppendLine("	  AND MC.IdSucursal = " & sucursal.ToString())
         .AppendFormatLine("	  AND MC.FechaMovimiento >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("	  AND MC.FechaMovimiento <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))


         If Not String.IsNullOrEmpty(tipoMovimiento) Then
            .AppendLine("  AND TM.IdTipoMovimiento = '" & tipoMovimiento & "'")
         End If

         If idMarca > 0 Then
            .AppendLine("  AND Prod.IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("  AND Prod.IdRubro = " & idRubro.ToString())
         End If

         If idSubRubro > 0 Then
            .AppendLine("  AND Prod.IdSubRubro = " & idSubRubro.ToString())
         End If

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If idCliente > 0 Then
            .AppendLine("	AND 1 = 2") 'Fuerzo que no devuelva nada en Compras
         End If

         .AppendLine("UNION ALL")

         'Obtengo los Movimiento del tipo "Ventas"

         .AppendLine("  SELECT Prod.IdMarca, Prod.IdRubro, RIGHT(REPLICATE(' ',15) + MVP.IdProducto,15) as IdProducto, Prod.NombreProducto, MVP.Precio,MVP.Cantidad ")
         '--
         .AppendLine("  , (CASE WHEN MVP.IdaAtributoProducto01 IS NULL THEN 0  ELSE AP01.IdaAtributoProducto END) AS IdaAtributoProducto01")
         .AppendLine("  , (CASE WHEN MVP.IdaAtributoProducto01 IS NULL THEN '' ELSE AP01.Descripcion END) AS DescripcionAtributo01")
         .AppendLine("  , (CASE WHEN MVP.IdaAtributoProducto02 IS NULL THEN 0  ELSE AP02.IdaAtributoProducto END) AS IdaAtributoProducto02")
         .AppendLine("  , (CASE WHEN MVP.IdaAtributoProducto02 IS NULL THEN '' ELSE AP02.Descripcion END) AS DescripcionAtributo02")
         .AppendLine("  , (CASE WHEN MVP.IdaAtributoProducto03 IS NULL THEN 0  ELSE AP03.IdaAtributoProducto END) AS IdaAtributoProducto03")
         .AppendLine("  , (CASE WHEN MVP.IdaAtributoProducto03 IS NULL THEN '' ELSE AP03.Descripcion END) AS DescripcionAtributo03")
         .AppendLine("  , (CASE WHEN MVP.IdaAtributoProducto04 IS NULL THEN 0  ELSE AP04.IdaAtributoProducto END) AS IdaAtributoProducto04")
         .AppendLine("  , (CASE WHEN MVP.IdaAtributoProducto04 IS NULL THEN '' ELSE AP04.Descripcion END) AS DescripcionAtributo04")
         '--
         .AppendLine("   FROM TiposMovimientos TM, Productos Prod, Clientes C, MovimientosStock MV ")
         '--
         .AppendLine("     INNER JOIN MovimientosStockProductos MVP ")
         .AppendLine("    		ON	MV.IdSucursal = MVP.IdSucursal  ")
         .AppendLine("    		AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento ")
         .AppendLine("    	   AND MV.NumeroMovimiento = MVP.NumeroMovimiento ")

         '--
         .AppendLine("    LEFT OUTER JOIN TiposComprobantes TC ON MV.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("    LEFT OUTER JOIN Sucursales S ON MV.IdSucursal = S.IdSucursal ")
         '--
         .AppendLine("    LEFT OUTER JOIN AtributosProductos AP01 ON AP01.IdaAtributoProducto = MVP.IdaAtributoProducto01")
         .AppendLine("    LEFT OUTER JOIN AtributosProductos AP02 ON AP02.IdaAtributoProducto = MVP.IdaAtributoProducto02")
         .AppendLine("    LEFT OUTER JOIN AtributosProductos AP03 ON AP03.IdaAtributoProducto = MVP.IdaAtributoProducto03")
         .AppendLine("    LEFT OUTER JOIN AtributosProductos AP04 ON AP04.IdaAtributoProducto = MVP.IdaAtributoProducto04")

         '--
         .AppendLine("   WHERE MV.IdTipoMovimiento = TM.IdTipoMovimiento ")
         .AppendLine("     AND MV.IdSucursal = MVP.IdSucursal ")
         .AppendLine("     AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento ")
         .AppendLine("     AND MV.NumeroMovimiento = MVP.NumeroMovimiento ")
         .AppendLine("     AND MV.IdCliente = C.IdCliente")
         .AppendLine("     AND MVP.IdProducto = Prod.IdProducto ")
         .AppendLine("	   AND MV.IdSucursal = " & sucursal.ToString())

         .AppendFormatLine("	  AND MV.FechaMovimiento >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("	  AND MV.FechaMovimiento <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))


         If Not String.IsNullOrEmpty(tipoMovimiento) Then
            .AppendLine("  AND TM.IdTipoMovimiento = '" & tipoMovimiento & "'")
         End If

         If idMarca > 0 Then
            .AppendLine("  AND Prod.IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("  AND Prod.IdRubro = " & idRubro.ToString())
         End If

         If idSubRubro > 0 Then
            .AppendLine("  AND Prod.IdSubRubro = " & idSubRubro.ToString())
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If

         If idProveedor <> 0 Then
            .AppendLine("	AND 1 = 2") 'Fuerzo que no devuelva nada en Ventas
         End If

         .AppendLine("	) A, Marcas M, Rubros R")
         .AppendLine("  WHERE A.IdMarca = M.IdMarca ")
         .AppendLine("	  AND A.IdRubro = R.IdRubro")
         .AppendLine("	 GROUP BY A.idProducto ,a.NombreProducto , m.NombreMarca , R.NombreRubro ")
         '--
         .AppendLine("	 , A.IdaAtributoProducto01, A.DescripcionAtributo01")
         .AppendLine("	 , A.IdaAtributoProducto02, A.DescripcionAtributo02")
         .AppendLine("	 , A.IdaAtributoProducto03, A.DescripcionAtributo03")
         .AppendLine("	 , A.IdaAtributoProducto04, A.DescripcionAtributo04")
         '--
         .AppendLine("	 ORDER BY Cantidad " & orden & " , A.NombreProducto, M.NombreMarca, R.NombreRubro ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetProductosLotes(sucursales() As Integer,
                                     desde As Date, hasta As Date,
                                     soloVencidos As Boolean,
                                     idProducto As String,
                                     idMarca As Integer,
                                     idRubro As Integer,
                                     idSubRubro As Integer,
                                     conStock As Boolean,
                                     depositos As Entidades.SucursalDeposito(),
                                     stockUnificado As Boolean,
                                     tipoDeposito As Entidades.SucursalDeposito.TiposDepositos?) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT S.Nombre AS NombreSucursal, PL.IdLote, PL.IdProducto, P.NombreProducto, PL.FechaIngreso, PL.FechaVencimiento, PL.CantidadInicial, PL.CantidadActual , SD.IdDeposito, PL.IdUbicacion")
         .AppendLine(" FROM ProductosLotes PL ")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = PL.IdProducto")
         .AppendLine(" LEFT JOIN Sucursales S ON PL.IdSucursal = S.IdSucursal")

         .AppendLine("  INNER JOIN SucursalesDepositos SD ON PL.idSucursal = SD.idSucursal AND PL.IdDeposito = SD.IdDeposito
                        LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PL.IdSucursal AND SU.IdDeposito = PL.IdDeposito AND SU.IdUbicacion = PL.IdUbicacion")

         .AppendLine(" WHERE 1=1")
         .AppendFormat(" AND PL.IdSucursal IN (0")
         For Each suc As Object In sucursales
            If Integer.Parse(suc.ToString()) <> 0 Then
               .AppendLine("," & suc.ToString())
            End If
         Next
         .AppendLine(") ")
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND PL.IdProducto = '" & idProducto & "'")
         End If

         If desde.Year > 1 Then
            .AppendLine("    AND CONVERT(varchar(11), PL.FechaVencimiento, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("    AND CONVERT(varchar(11), PL.FechaVencimiento, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
            'Else
            '   .AppendLine("    AND CONVERT(varchar(11), PL.FechaVencimiento, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         End If

         If soloVencidos Then
            'El dia de HOY no lo considero vencido.
            .AppendLine("   AND Convert(varchar(11), PL.FechaVencimiento, 120) < Convert(varchar(11), getdate(), 120) ")
         End If

         If idMarca > 0 Then
            .AppendLine("  AND P.IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("  AND P.IdRubro = " & idRubro.ToString())
         End If

         If idSubRubro > 0 Then
            .AppendLine("  AND P.IdSubRubro = " & idSubRubro.ToString())
         End If

         If conStock Then
            .AppendLine("  AND PL.CantidadActual > 0")
         End If

         GetListaDepositosMultiples(stb, depositos, "PL")
         If tipoDeposito.HasValue Then
            .AppendFormatLine("   AND SD.TipoDeposito = '{0}'", tipoDeposito.Value.ToString())
         End If


         .AppendLine("  ORDER BY P.NombreProducto, PL.IdProducto, PL.FechaVencimiento, PL.IdLote")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetResumenPorProducto(sucursal As Integer,
                                         desde As Date, hasta As Date,
                                         tipoMovimiento As String,
                                         idProducto As String,
                                         idMarca As Integer,
                                         idRubro As Integer,
                                         idSubRubro As Integer,
                                         idCliente As Long,
                                         idProveedor As Long,
                                         mostrarProdSinMov As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         'Obtengo los Movimiento del tipo "Compras"
         .AppendFormatLine("SELECT M.NombreMarca, R.NombreRubro, A.IdProducto, A.NombreProducto, ")
         '     .AppendFormatLine("       SUM(A.Precio*A.Cantidad) AS ImporteNeto, SUM(A.Cantidad) as Cantidad, SUM(A.Stock) as Stock ")
         .AppendFormatLine("       SUM(A.Precio*A.Cantidad) AS ImporteNeto, SUM(A.Cantidad) as Cantidad, A.Stock")

         .AppendFormatLine("  FROM ")
         .AppendFormatLine("  ( ")

         '-.PE-31484.-

         .AppendFormatLine("  SELECT Prod.IdMarca, Prod.IdRubro, RIGHT(REPLICATE(' ',15) + Prod.IdProducto,15) as IdProducto, Prod.NombreProducto, MCP.Precio, MCP.Cantidad, PS.Stock ")

         .AppendFormatLine("     FROM Productos Prod")
         .AppendFormatLine("     INNER JOIN ProductosSucursales PS ON PS.IdProducto = Prod.IdProducto")
         .AppendFormatLine("     LEFT JOIN MovimientosStockProductos MCP ON MCP.IdProducto = Prod.IdProducto")
         .AppendFormatLine("     LEFT JOIN MovimientosStock MC ON MC.IdSucursal = MCP.IdSucursal  ")
         .AppendFormatLine("        AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento")
         .AppendFormatLine("        AND MC.NumeroMovimiento = MCP.NumeroMovimiento ")
         .AppendFormatLine("     LEFT JOIN TiposMovimientos TM ON MC.IdTipoMovimiento = TM.IdTipoMovimiento ")
         .AppendFormatLine("     LEFT OUTER JOIN TiposComprobantes TC ON MC.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendFormatLine("     LEFT OUTER JOIN Sucursales S ON MC.IdSucursal2 = S.IdSucursal")
         .AppendFormatLine("     LEFT OUTER JOIN Proveedores P ON MC.IdProveedor = P.IdProveedor")
         .AppendFormatLine("     WHERE PS.IdSucursal = {0}", sucursal)
         .AppendFormatLine("        AND ((MC.IdSucursal = {0}", sucursal)
         .AppendFormatLine("	  AND MC.FechaMovimiento >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("	  AND MC.FechaMovimiento <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia, True))

         ' .AppendFormatLine("  AND MC.FechaMovimiento >= '{0}'", ObtenerFecha(desde, False))
         If mostrarProdSinMov Then
            .AppendFormatLine("     OR MCP.IdProducto Is NULL")
         End If

         .AppendFormatLine(" ))")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("	AND Prod.IdProducto = '{0}'", idProducto)
         End If

         If Not String.IsNullOrEmpty(tipoMovimiento) Then
            .AppendFormatLine("  AND TM.IdTipoMovimiento = '{0}'", tipoMovimiento)
         End If

         If idMarca > 0 Then
            .AppendFormatLine("  AND Prod.IdMarca = {0}", idMarca)
         End If

         If idRubro > 0 Then
            .AppendFormatLine("  AND Prod.IdRubro = {0}", idRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormatLine("  AND Prod.IdSubRubro = {0}", idSubRubro)
         End If

         If idProveedor > 0 Then
            .AppendFormatLine("	AND P.IdProveedor = {0}", idProveedor)
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("	AND 1 = 2") 'Fuerzo que no devuelva nada en Compras
         End If


         '.AppendFormatLine("UNION ALL")

         ''Obtengo los Movimiento del tipo "Ventas"

         ''-.PE-31484.-
         '.AppendFormatLine("  SELECT Prod.IdMarca, Prod.IdRubro, RIGHT(REPLICATE(' ',15) + Prod.IdProducto,15) as IdProducto, Prod.NombreProducto, MVP.Precio,MVP.Cantidad, PS.Stock ")

         '.AppendFormatLine("     FROM Productos Prod")
         '.AppendFormatLine("     INNER JOIN ProductosSucursales PS ON PS.IdProducto = Prod.IdProducto")
         '.AppendFormatLine("     LEFT JOIN MovimientosStockProductos MVP ON MVP.IdProducto = Prod.IdProducto")
         '.AppendFormatLine("     LEFT JOIN MovimientosStock MV ON MV.IdSucursal = MVP.IdSucursal")
         '.AppendFormatLine("     AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento")
         '.AppendFormatLine("     AND MV.NumeroMovimiento = MVP.NumeroMovimiento")
         '.AppendFormatLine("     LEFT JOIN TiposMovimientos TM ON MV.IdTipoMovimiento = TM.IdTipoMovimiento")
         '.AppendFormatLine("     LEFT OUTER JOIN TiposComprobantes TC ON MV.IdTipoComprobante = TC.IdTipoComprobante")
         '.AppendFormatLine("     LEFT OUTER JOIN Sucursales S ON MV.IdSucursal = S.IdSucursal")
         '.AppendFormatLine("     WHERE PS.IdSucursal = " & sucursal.ToString())
         '.AppendFormatLine("          AND ((MV.IdSucursal = " & sucursal.ToString())
         '.AppendFormatLine("	  AND MV.FechaMovimiento >= '{0}'", ObtenerFecha(desde, False))
         '.AppendFormatLine("	  AND MV.FechaMovimiento <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia, True))
         'If mostrarProdSinMov Then
         '   .AppendFormatLine("       OR MVP.IdProducto Is NULL")
         'End If
         '.AppendFormatLine(" )) ")


         'If Not String.IsNullOrEmpty(idProducto) Then
         '   .AppendFormatLine("	AND Prod.IdProducto = '{0}'", idProducto)
         'End If

         If Not String.IsNullOrEmpty(tipoMovimiento) Then
            .AppendFormatLine("  AND TM.IdTipoMovimiento = '{0}'", tipoMovimiento)
         End If

         If idMarca > 0 Then
            .AppendFormatLine("  AND Prod.IdMarca = {0}", idMarca)
         End If

         If idRubro > 0 Then
            .AppendFormatLine("  AND Prod.IdRubro = {0}", idRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormatLine("  AND Prod.IdSubRubro = {0}", idSubRubro)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("	AND MC.IdCliente = {0}", idCliente)
         End If

         If idProveedor > 0 Then
            .AppendFormatLine("	AND 1 = 2") 'Fuerzo que no devuelva nada en Ventas
         End If

         .AppendFormatLine("	) A, Marcas M, Rubros R")
         .AppendFormatLine("  WHERE A.IdMarca = M.IdMarca ")
         .AppendFormatLine("	  AND A.IdRubro = R.IdRubro")
         .AppendFormatLine("	 GROUP BY M.NombreMarca, R.NombreRubro, A.IdProducto, A.NombreProducto, A.Stock")
         .AppendFormatLine("	 ORDER BY M.NombreMarca, R.NombreRubro, A.NombreProducto")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetProductosNumeroDeSerie(sucursales As Entidades.Sucursal(),
                                             idMarca As Integer,
                                             idRubro As Integer,
                                             idSubRubro As Integer,
                                             idProducto As String,
                                             idProveedor As Long,
                                             disponible As Entidades.Publicos.SiNoTodos,
                                             nroSerie As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT PN.*,C.CodigoCliente, V.NombreCliente, V.Direccion,P.NombreProducto,CO.Fecha,CO.NombreProveedor")
         .AppendLine(" FROM ProductosNrosSerie PN ")
         .AppendLine(" LEFT JOIN Productos P ON PN.IdProducto = P.IdProducto")
         '   .AppendLine(" LEFT JOIN ProductosSucursales PS ON PN.IdProducto = PS.IdProducto")
         .AppendFormatLine(" LEFT JOIN Ventas V ON ")
         .AppendFormatLine("					PN.IdSucursalVenta = V.IdSucursal")
         .AppendFormatLine("					AND PN.IdTipoCompVenta = V.IdTipoComprobante")
         .AppendFormatLine("					AND PN.LetraVenta = V.Letra")
         .AppendFormatLine("					AND PN.CentroEmisorVenta = V.CentroEmisor")
         .AppendFormatLine("					AND PN.NumeroComprobanteVenta = V.NumeroComprobante")
         .AppendFormatLine("LEFT JOIN Compras CO ON")
         .AppendFormatLine("					PN.IdSucursal = CO.IdSucursal")
         .AppendFormatLine("					AND PN.IdTipoCompCompra = CO.IdTipoComprobante")
         .AppendFormatLine("					AND PN.LetraCompra = CO.Letra")
         .AppendFormatLine("					AND PN.CentroEmisorCompra = CO.CentroEmisor")
         .AppendFormatLine("					AND PN.NumeroComprobanteCompra = CO.NumeroComprobante")
         .AppendFormatLine("					AND PN.IdProveedor = CO.IdProveedor")
         .AppendFormatLine(" LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente")
         '.AppendLine(" LEFT JOIN Sucursales S ON PL.IdSucursal = S.IdSucursal")
         .AppendLine(" WHERE 1=1 ")
         '.AppendFormat(" AND PL.IdSucursal IN (0")
         'For Each suc As Object In Sucursales
         '   If Integer.Parse(suc.ToString()) <> 0 Then
         '      .AppendLine("," & suc.ToString())
         '   End If
         'Next
         '.AppendLine(") ")
         GetListaSucursalesMultiples(stb, sucursales, "PN")

         ' .AppendLine("  AND PS.IdSucursal = " & actual.Sucursal.Id.ToString())

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND PN.IdProducto = '" & idProducto & "'")
         End If

         If idMarca > 0 Then
            .AppendLine("  AND P.IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("  AND P.IdRubro = " & idRubro.ToString())
         End If
         If idSubRubro > 0 Then
            .AppendLine("  AND P.IdSubRubro = " & idSubRubro.ToString())
         End If

         If idProveedor > 0 Then
            .AppendLine("  AND PR.IdProveedor = " & idProveedor.ToString())
         End If

         If disponible <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("    AND PN.Vendido = {0}", IIf(disponible = Entidades.Publicos.SiNoTodos.SI, "0", "1"))
         End If

         If Not String.IsNullOrWhiteSpace(nroSerie) Then
            .AppendLine("  AND PN.NroSerie = '" & nroSerie & "'")
         End If

         .AppendLine("  ORDER BY P.NombreProducto, PN.IdProducto")

      End With
      Return GetDataTable(stb)
   End Function


   Public Function GetProductoLivianoParaControlStock(idSucursal As Integer, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P.IdProducto, P.NombreProducto, P.EsCompuesto, P.DescontarStockComponentes, P.AfectaStock, P.IdFormula, PS.Stock") ', PS.StockReservado")
         .AppendFormatLine("  FROM Productos P")
         .AppendFormatLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         .AppendFormatLine(" WHERE P.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND PS.IdSucursal = {0}", idSucursal)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetInformeDetallePorProductoNrosSerie(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito(),
                                                         idTipoMovimiento As String, idTipoComprobante As String,
                                                         desde As Date, hasta As Date,
                                                         idEmpleado As Integer,
                                                         idProducto As String, nroSerie As String, idLote As String,
                                                         idCliente As Long, idProveedor As Long,
                                                         marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                                         rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataTable
      Dim query = New StringBuilder()
      With query
         'Obtengo los Movimiento del tipo "Compras"
         .AppendFormatLine("SELECT MC.FechaMovimiento")
         .AppendFormatLine("     , MC.IdSucursal")
         .AppendFormatLine("     , MCP.IdDeposito")
         .AppendFormatLine("     , SD.NombreDeposito")
         .AppendFormatLine("     , MC.IdTipoMovimiento")
         .AppendFormatLine("     , TM.Descripcion as TipoMovimiento")
         .AppendFormatLine("     , MC.NumeroMovimiento")
         .AppendFormatLine("     , TC.Descripcion as TipoComprobante")
         .AppendFormatLine("     , MC.Letra")
         .AppendFormatLine("     , MC.CentroEmisor")
         .AppendFormatLine("     , MC.NumeroComprobante")
         .AppendFormatLine("     , P.IdProveedor AS IdClienteProveedor")
         .AppendFormatLine("     , P.CodigoProveedor AS CodigoClienteProveedor")
         .AppendFormatLine("     , P.NombreProveedor AS NombreClienteProveedor")
         .AppendFormatLine("     , RIGHT(REPLICATE(' ',15) + MCP.IdProducto,15) as IdProducto")
         .AppendFormatLine("     , MCP.Precio")
         .AppendFormatLine("     , (CASE WHEN MCPNS.Cantidad > 0 THEN MCPNS.Cantidad ELSE 0 END) AS INGRESO ")
         .AppendFormatLine("     , (CASE WHEN MCPNS.Cantidad < 0 THEN MCPNS.Cantidad ELSE 0 END) AS EGRESO")

         .AppendFormatLine("     , S.Nombre as NombreSucursalDeA")

         'No mostraba los movimientos desde Stock, ejemplo: AJUSTE.
         .AppendFormatLine("     , (CASE WHEN CP.NombreProducto IS NULL THEN Pr.NombreProducto ELSE CP.NombreProducto END) AS NombreProducto")
         .AppendFormatLine("     , M.NombreMarca")
         .AppendFormatLine("     , Mo.NombreModelo")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , SR.NombreSubRubro")
         .AppendFormatLine("     , SSR.NombreSubSubRubro")
         .AppendFormatLine("     , MCPNS.NroSerie")
         .AppendFormatLine("     , MC.Usuario")

         .AppendFormatLine("     , MC.Observacion")
         .AppendFormatLine("     , MC.IdEmpleado")
         .AppendFormatLine("     , E.NombreEmpleado")
         .AppendFormatLine("     , TM.MuestraCombo")
         .AppendFormatLine("     , MC.IdProduccion")
         .AppendFormatLine("  FROM MovimientosStock MC")
         .AppendFormatLine(" INNER JOIN TiposMovimientos TM ON TM.IdTipoMovimiento = MC.IdTipoMovimiento")
         .AppendFormatLine(" INNER JOIN MovimientosStockProductos MCP")
         .AppendFormatLine("         ON MCP.IdSucursal         = MC.IdSucursal")
         .AppendFormatLine("        AND MCP.IdTipoMovimiento   = MC.IdTipoMovimiento")
         .AppendFormatLine("        AND MCP.NumeroMovimiento   = MC.NumeroMovimiento")
         .AppendFormatLine(" INNER JOIN MovimientosStockProductosNrosSerie MCPNS")
         .AppendFormatLine("         ON MCPNS.IdSucursal       = MCP.IdSucursal")
         .AppendFormatLine("        AND MCPNS.IdTipoMovimiento = MCP.IdTipoMovimiento")
         .AppendFormatLine("        AND MCPNS.NumeroMovimiento = MCP.NumeroMovimiento")
         .AppendFormatLine("        AND MCPNS.Orden            = MCP.Orden")
         .AppendFormatLine("        AND MCPNS.IdProducto       = MCP.IdProducto")
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = MCP.IdSucursal AND SD.IdDeposito = MCP.IdDeposito")
         .AppendFormatLine(" INNER JOIN Productos Pr ON Pr.IdProducto = MCP.IdProducto")
         .AppendFormatLine("  LEFT JOIN Sucursales S ON S.IdSucursal = MC.IdSucursal2")
         .AppendFormatLine("  LEFT JOIN Proveedores P ON P.IdProveedor = MC.IdProveedor")
         .AppendFormatLine("  LEFT JOIN Clientes C ON C.IdCliente = MC.IdCliente")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON TC.IdTipoComprobante = MC.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN Marcas M ON M.IdMarca = Pr.IdMarca")
         .AppendFormatLine("  LEFT JOIN Modelos Mo ON Mo.IdModelo = Pr.IdModelo")
         .AppendFormatLine("  LEFT JOIN Rubros R ON R.IdRubro = Pr.IdRubro ")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubrubro = Pr.IdSubrubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubrubro = Pr.IdSubSubrubro")
         .AppendFormatLine("  LEFT JOIN Empleados E ON MC.IdEmpleado = E.IdEmpleado")
         .AppendFormatLine("  LEFT JOIN ComprasProductos CP")
         .AppendFormatLine("         ON CP.IdSucursal          = MC.IdSucursal ")
         .AppendFormatLine("        AND CP.IdTipoComprobante   = MC.IdTipoComprobante")
         .AppendFormatLine("        AND CP.Letra               = MC.Letra")
         .AppendFormatLine("        AND CP.CentroEmisor        = MC.CentroEmisor")
         .AppendFormatLine("        AND CP.NumeroComprobante   = MC.NumeroComprobante")
         .AppendFormatLine("        AND CP.IdProveedor         = MC.IdProveedor")
         .AppendFormatLine("        AND CP.IdProducto          = MCP.IdProducto")
         .AppendFormatLine("        AND CP.Orden               = MCP.Orden")

         .AppendFormatLine(" WHERE MC.FechaMovimiento BETWEEN '{0}' AND '{1}'", ObtenerFecha(desde, True), ObtenerFecha(hasta, True))

         GetListaSucursalesMultiples(query, sucursales, "MC")
         GetListaDepositosMultiples(query, depositos, "MCP")

         If Not String.IsNullOrEmpty(idTipoMovimiento) Then
            .AppendFormatLine("   AND TM.IdTipoMovimiento = '{0}'", idTipoMovimiento)
         End If
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND MC.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If idEmpleado > 0 Then
            .AppendFormatLine("   AND MC.IdEmpleado = {0}", idEmpleado)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("	AND MCP.IdProducto = '{0}'", idProducto)
         End If
         If Not String.IsNullOrEmpty(nroSerie) Then
            .AppendFormatLine("   AND MCPNS.{0} LIKE '%{1}%' ", Entidades.CompraProductoNroSerie.Columnas.NroSerie.ToString(), nroSerie)
         End If
         If Not String.IsNullOrEmpty(idLote) Then
            .AppendFormatLine("   AND MCP.IdLote = '{0}'", idLote)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("   AND MC.Idcliente = {0}", idCliente)
         End If
         If idProveedor > 0 Then
            .AppendFormatLine("   AND MC.IdProveedor = {0}", idProveedor)
         End If

         GetListaMarcasMultiples(query, marcas, "Pr")
         GetListaModelosMultiples(query, modelos, "Pr")
         GetListaRubrosMultiples(query, rubros, "Pr")
         GetListaSubRubrosMultiples(query, subRubros, "Pr")
         GetListaSubSubRubrosMultiples(query, subSubRubros, "Pr")

         .AppendFormatLine(" ORDER BY FechaMovimiento DESC")

      End With
      Return GetDataTable(query)
   End Function

   Public Function GetInformeDetallePorProducto(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                                                idTipoMovimiento As String, idTipoComprobante As String,
                                                idProducto As String, idLote As String,
                                                marcas As Entidades.Marca(), modelos As Entidades.Modelo(), rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(),
                                                subsubrubros As Entidades.SubSubRubro(),
                                                idCliente As Long, idProveedor As Long, idEmpleado As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         'Obtengo los Movimiento del tipo "Compras"
         .AppendLine("SELECT MC.FechaMovimiento")
         .AppendLine("     , MC.IdSucursal")
         .AppendLine("     , MC.IdTipoMovimiento")
         .AppendLine("     , TM.Descripcion as TipoMovimiento")
         .AppendLine("     , MC.NumeroMovimiento")
         .AppendLine("     , TC.Descripcion as TipoComprobante")
         .AppendLine("     , MC.Letra")
         .AppendLine("     , MC.CentroEmisor")
         .AppendLine("     , MC.NumeroComprobante")

         .AppendLine("     , ISNULL(C.IdCliente, P.IdProveedor) AS IdClienteProveedor")
         .AppendLine("     , ISNULL(C.CodigoCliente, P.CodigoProveedor) AS CodigoClienteProveedor")
         .AppendLine("     , ISNULL(NULLIF(V.NombreCliente, ''), P.NombreProveedor) AS NombreClienteProveedor")

         .AppendLine("     , RIGHT(REPLICATE(' ',15) + MCP.IdProducto,15) as IdProducto")
         .AppendLine("     , MCP.Precio")
         .AppendLine("     ,  (CASE WHEN ISNULL(MSPL.Cantidad, MCP.Cantidad) > 0 THEN ISNULL(MSPL.Cantidad, MCP.Cantidad) ELSE 0 END) AS INGRESO")
         .AppendLine("     ,  (CASE WHEN ISNULL(MSPL.Cantidad, MCP.Cantidad) < 0 THEN ISNULL(MSPL.Cantidad, MCP.Cantidad) ELSE 0 END) AS EGRESO")

         ' .AppendLine("     , MCP.Cantidad")
         .AppendLine("     , S.Nombre as NombreSucursalDeA")

         'No mostraba los movimientos desde Stock, ejemplo: AJUSTE.
         .AppendLine("     , (CASE WHEN CP.NombreProducto IS NULL THEN Prod.NombreProducto ELSE CP.NombreProducto END) AS NombreProducto")
         .AppendLine("     , M.NombreMarca")
         .AppendLine("     , R.NombreRubro")
         .AppendLine("     , SR.NombreSubRubro")
         .AppendLine("     , MC.Usuario")
         '.AppendLine("     , MCP.IdLote")
         .AppendLine("     , ISNULL(MSPL.IdLote, MCP.IdLote) IdLote")
         .AppendLine("     , MC.Observacion")
         .AppendLine("     , MC.IdEmpleado")
         .AppendLine("     , E.NombreEmpleado")
         .AppendLine("     , TM.MuestraCombo")
         .AppendLine("     , MC.IdProduccion")

         '-- REQ-35223.- ----------------------------------------------------------
         .AppendFormatLine(" , (CASE WHEN MCP.IdaAtributoProducto01 IS NULL THEN 0  ELSE AP01.IdaAtributoProducto END) AS IdaAtributoProducto01")
         .AppendFormatLine(" , (CASE WHEN MCP.IdaAtributoProducto01 IS NULL THEN '' ELSE AP01.Descripcion END) AS DescripcionAtributo01")
         '--
         .AppendFormatLine(" , (CASE WHEN MCP.IdaAtributoProducto02 IS NULL THEN 0  ELSE AP02.IdaAtributoProducto END) AS IdaAtributoProducto02")
         .AppendFormatLine(" , (CASE WHEN MCP.IdaAtributoProducto02 IS NULL THEN '' ELSE AP02.Descripcion END) AS DescripcionAtributo02")
         '--
         .AppendFormatLine(" , (CASE WHEN MCP.IdaAtributoProducto03 IS NULL THEN 0  ELSE AP03.IdaAtributoProducto END) AS IdaAtributoProducto03")
         .AppendFormatLine(" , (CASE WHEN MCP.IdaAtributoProducto03 IS NULL THEN '' ELSE AP03.Descripcion END) AS DescripcionAtributo03")
         '---
         .AppendFormatLine(" , (CASE WHEN MCP.IdaAtributoProducto04 IS NULL THEN 0  ELSE AP04.IdaAtributoProducto END) AS IdaAtributoProducto04")
         .AppendFormatLine(" , (CASE WHEN MCP.IdaAtributoProducto04 IS NULL THEN '' ELSE AP04.Descripcion END) AS DescripcionAtributo04")
         '-------------------------------------------------------------------------
         .AppendFormatLine("     , MCP.IdDeposito")
         .AppendFormatLine("     , MCP.IdUbicacion")
         .AppendLine("     , SD.NombreDeposito")
         .AppendLine("     , SU.NombreUbicacion")

         .AppendLine("  FROM MovimientosStock MC")
         .AppendLine(" LEFT JOIN TiposMovimientos TM ON  MC.IdTipoMovimiento = TM.IdTipoMovimiento")
         .AppendLine(" INNER JOIN MovimientosStockProductos MCP")
         .AppendLine("         ON MC.IdSucursal = MCP.IdSucursal")
         .AppendLine("        AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento")
         .AppendLine("        AND MC.NumeroMovimiento = MCP.NumeroMovimiento")

         .AppendLine("  LEFT JOIN MovimientosStockProductosLotes MSPL")
         .AppendLine("    ON MSPL.IdSucursal = MCP.IdSucursal")
         .AppendLine("   AND MSPL.IdTipoMovimiento = MCP.IdTipoMovimiento")
         .AppendLine("   AND MSPL.NumeroMovimiento = MCP.NumeroMovimiento")
         .AppendLine("   AND MSPL.IdProducto = MCP.IdProducto")
         .AppendLine("   AND MSPL.Orden = MCP.Orden")

         .AppendLine(" INNER JOIN Productos Prod ON MCP.IdProducto = Prod.IdProducto ")
         .AppendLine(" INNER JOIN SucursalesDepositos SD ON MCP.IdSucursal = SD.IdSucursal AND MCP.IdDeposito = SD.IdDeposito")
         .AppendLine(" INNER JOIN SucursalesUbicaciones SU ON MCP.IdSucursal = SU.IdSucursal AND MCP.IdDeposito = SU.IdDeposito AND MCP.IdUbicacion = SU.IDUbicacion")

         .AppendLine(" LEFT OUTER JOIN Sucursales S ON MC.IdSucursal2 = S.IdSucursal ")
         .AppendLine(" LEFT OUTER JOIN Proveedores P ON MC.IdProveedor = P.IdProveedor ")
         .AppendLine(" LEFT OUTER JOIN TiposComprobantes TC ON MC.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" LEFT OUTER JOIN SubRubros SR ON Prod.IdSubrubro = SR.IdSubrubro ")
         '-- REQ-35221.- ----------------------------------------------------------
         .AppendLine("  LEFT JOIN AtributosProductos AP01 ON AP01.IdaAtributoProducto = MCP.IdaAtributoProducto01")
         .AppendLine("  LEFT JOIN AtributosProductos AP02 ON AP02.IdaAtributoProducto = MCP.IdaAtributoProducto02")
         .AppendLine("  LEFT JOIN AtributosProductos AP03 ON AP03.IdaAtributoProducto = MCP.IdaAtributoProducto03")
         .AppendLine("  LEFT JOIN AtributosProductos AP04 ON AP04.IdaAtributoProducto = MCP.IdaAtributoProducto04")
         '-------------------------------------------------------------------------
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = Prod.IdMarca ")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = Prod.IdRubro ")
         .AppendLine(" LEFT JOIN Empleados E ON E.IdEmpleado = MC.IdEmpleado ")
         .AppendLine(" LEFT JOIN ComprasProductos CP ")
         .AppendLine(" ON CP.IdSucursal = MC.IdSucursal ")
         .AppendLine(" AND CP.IdTipoComprobante = MC.IdTipoComprobante")
         .AppendLine(" AND CP.Letra = MC.Letra")
         .AppendLine(" AND CP.CentroEmisor = MC.CentroEmisor")
         .AppendLine(" AND CP.NumeroComprobante = MC.NumeroComprobante")
         .AppendLine(" AND CP.IdProveedor = MC.IdProveedor")
         .AppendLine(" AND CP.IdProducto = MCP.IdProducto")
         .AppendLine(" AND CP.Orden = MCP.Orden")

         .AppendLine("  LEFT JOIN Clientes C ON MC.IdCliente = C.IdCliente ")
         .AppendLine("  LEFT JOIN Ventas V ON V.IdSucursal = MC.IdSucursal")
         .AppendLine(" 	                  AND V.IdTipoComprobante = MC.IdTipoComprobante")
         .AppendLine(" 	                  AND V.Letra = MC.Letra")
         .AppendLine(" 	                  AND V.CentroEmisor = MC.CentroEmisor")
         .AppendLine(" 	                  AND V.NumeroComprobante = MC.NumeroComprobante")

         .AppendLine("  WHERE 1 = 1")

         ''If IdSucAsociada > 0 Then
         ''   .AppendLine("	  (MC.IdSucursal = " & IdSucursal.ToString())
         ''   .AppendLine("	   OR MC.IdSucursal = " & IdSucAsociada.ToString() & ")")
         ''Else
         ''   .AppendLine("	  MC.IdSucursal = " & IdSucursal.ToString())
         ''End If

         .AppendFormatLine("   AND MC.FechaMovimiento >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("   AND MC.FechaMovimiento <= '{0}'", ObtenerFecha(hasta, True))

         GetListaSucursalesMultiples(stb, sucursales, "MC")

         If Not String.IsNullOrEmpty(idLote) Then
            .AppendFormatLine("   AND MCP.IdLote = '{0}'", idLote)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND MCP.IdProducto = '{0}'", idProducto)
         End If

         If Not String.IsNullOrEmpty(idTipoMovimiento) Then
            .AppendFormatLine("   AND TM.IdTipoMovimiento = '{0}'", idTipoMovimiento)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND MC.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         GetListaMarcasMultiples(stb, marcas, "Prod")
         GetListaModelosMultiples(stb, modelos, "Prod")
         GetListaRubrosMultiples(stb, rubros, "Prod")
         GetListaSubRubrosMultiples(stb, subrubros, "Prod")
         GetListaSubSubRubrosMultiples(stb, subsubrubros, "Prod")

         If idProveedor > 0 Then
            .AppendFormatLine("   AND P.IdProveedor = {0}", idProveedor)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         'SI FILTRA POR CLIENTE
         If idEmpleado > 0 Then
            .AppendFormatLine("   AND MC.IdEmpleado = {0}", idEmpleado)
         End If
         .AppendLine(" ORDER BY FechaMovimiento")
      End With
      Return GetDataTable(stb)
   End Function

End Class