Imports Eniac.Entidades.Publicos.Reportes

Partial Class Ventas

#Region "Get Suma Por"
   Public Function GetSumaPorProductos(sucursales As Entidades.Sucursal(),
                                       depositos As Entidades.SucursalDeposito(),
                                       ubicacion As Entidades.SucursalUbicacion,
                                       oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal,
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
                                       nivelAgrupamiento As NivelAgrupamientoStock) As DataTable
      Dim ivaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado
      Dim stb = New StringBuilder()

      Dim campoNombreProducto = If(mostrarProductodeVenta, "VP.NombreProducto", "P.NombreProducto")

      With stb
         .AppendFormatLine("SELECT M.NombreMarca")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , VP.IdProducto")
         .AppendFormatLine("     , {0}", campoNombreProducto)     'If(mostrarProductodeVenta, "VP.NombreProducto", "P.NombreProducto")
         .AppendFormatLine("     , P.Tamano")
         .AppendFormatLine("     , P.IdUnidadDeMedida")

         If unificarSumaProductos Then
            .AppendFormatLine("     , MAX(PS.Stock) AS Stock")
            .AppendFormatLine("     , ISNULL(MAX(PS.Stock) / NULLIF({0}, 0), 0) AS DiasStock", cantidadDias)
            .AppendFormatLine("     , 0 AS IdSucursal") 'Se agrega el campo con valor cero para que lo pueda recuperar la grilla
            .AppendFormatLine("     , '' AS NombreDeposito ") 'Se agrega el campo con valor cero para que lo pueda recuperar la grilla
            .AppendFormatLine("     , '' AS NombreUbicacion") 'Se agrega el campo con valor cero para que lo pueda recuperar la grilla
         Else
            .AppendFormatLine("     , PS.Stock")
            .AppendFormatLine("     , ISNULL(PS.Stock / NULLIF({0}, 0), 0) AS DiasStock", cantidadDias)
            .AppendFormatLine("     , V.IdSucursal")
            If nivelAgrupamiento = NivelAgrupamientoStock.Deposito Or nivelAgrupamiento = NivelAgrupamientoStock.Ubicacion Then
               .AppendFormatLine("     , SD.NombreDeposito")
            Else
               .AppendFormatLine("     , '' NombreDeposito")
            End If
            If nivelAgrupamiento = NivelAgrupamientoStock.Ubicacion Then
               .AppendFormatLine("     , SU.NombreUbicacion")
            Else
               .AppendFormatLine("     , '' NombreUbicacion")
            End If
         End If

         If idProveedor > 0 Then
            .AppendFormatLine("     , PP.CodigoProductoProveedor")
            .AppendFormatLine("     , P.Embalaje")
         End If
         .AppendFormatLine("     , PRO.CodigoProveedor As CodigoProveedorHabitual")
         .AppendFormatLine("     , PRO.NombreProveedor As NombreProveedorHabitual")
         .AppendFormatLine("     , SUM(VP.Cantidad) AS Cantidad")
         .AppendFormatLine("     , SUM(VP.Cantidad) AS CantidadVendida")
         .AppendFormatLine("     , ISNULL(SUM(VP.Cantidad) / NULLIF({0}, 0), 0) AS CantidadPromedio", cantidadDias)
         .AppendFormatLine("     , SUM(VP.ImporteTotalNeto) AS ImporteTotalNeto")

         .AppendFormatLine("     , SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteTotal")
         .AppendFormatLine("     , SUM(VP.Kilos) AS Kilos")

         '-- REQ-35217.- ----------------------------------------------------------
         .AppendFormatLine("     , (CASE WHEN AP01.IdaAtributoProducto IS NULL THEN 0  ELSE AP01.IdaAtributoProducto END) AS IdaAtributoProducto01")
         .AppendFormatLine("     , (CASE WHEN AP01.IdaAtributoProducto IS NULL THEN '' ELSE AP01.Descripcion END) AS DescripcionAtributo01")
         '--
         .AppendFormatLine("     , (CASE WHEN AP02.IdaAtributoProducto IS NULL THEN 0  ELSE AP02.IdaAtributoProducto END) AS IdaAtributoProducto02")
         .AppendFormatLine("     , (CASE WHEN AP02.IdaAtributoProducto IS NULL THEN '' ELSE AP02.Descripcion END) AS DescripcionAtributo02")
         '--
         .AppendFormatLine("     , (CASE WHEN AP03.IdaAtributoProducto IS NULL THEN 0  ELSE AP03.IdaAtributoProducto END) AS IdaAtributoProducto03")
         .AppendFormatLine("     , (CASE WHEN AP03.IdaAtributoProducto IS NULL THEN '' ELSE AP03.Descripcion END) AS DescripcionAtributo03")
         '---
         .AppendFormatLine("     , (CASE WHEN AP04.IdaAtributoProducto IS NULL THEN 0  ELSE AP04.IdaAtributoProducto END) AS IdaAtributoProducto04")
         .AppendFormatLine("     , (CASE WHEN AP04.IdaAtributoProducto IS NULL THEN '' ELSE AP04.Descripcion END) AS DescripcionAtributo04")
         '---
         .AppendFormatLine("  FROM Ventas V ")
         .AppendFormatLine(" INNER JOIN VentasProductos VP ON V.idSucursal = VP.IdSucursal")
         .AppendFormatLine("    		                      AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendFormatLine("      	                      AND V.Letra=VP.Letra")
         .AppendFormatLine("    	                         AND V.CentroEmisor=VP.CentroEmisor")
         .AppendFormatLine("    	                         AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")
         .AppendFormatLine("  LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendFormatLine("  LEFT JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendFormatLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCLiente")

         If nivelAgrupamiento = NivelAgrupamientoStock.Ubicacion Then
            .AppendFormatLine(" INNER JOIN ProductosUbicaciones PS ON VP.IdSucursal = PS.IdSucursal AND VP.IdProducto = PS.IdProducto")
            .AppendFormatLine("                                   AND VP.IdDeposito = PS.IdDeposito AND VP.IdUbicacion = PS.IdUbicacion")
         ElseIf nivelAgrupamiento = NivelAgrupamientoStock.Deposito Then
            .AppendFormatLine(" INNER JOIN ProductosDepositos   PS ON VP.IdSucursal = PS.IdSucursal AND VP.IdProducto = PS.IdProducto")
            .AppendFormatLine("                                   AND VP.IdDeposito = PS.IdDeposito")
         ElseIf nivelAgrupamiento = NivelAgrupamientoStock.Sucursal Then
            .AppendFormatLine(" INNER JOIN ProductosSucursales  PS ON VP.IdSucursal = PS.IdSucursal AND VP.IdProducto = PS.IdProducto")
         End If

         .AppendFormatLine("  LEFT OUTER JOIN AtributosProductos AP01 ON AP01.IdaAtributoProducto = VP.IdaAtributoProducto01")
         .AppendFormatLine("  LEFT OUTER JOIN AtributosProductos AP02 ON AP02.IdaAtributoProducto = VP.IdaAtributoProducto02")
         .AppendFormatLine("  LEFT OUTER JOIN AtributosProductos AP03 ON AP03.IdaAtributoProducto = VP.IdaAtributoProducto03")
         .AppendFormatLine("  LEFT OUTER JOIN AtributosProductos AP04 ON AP04.IdaAtributoProducto = VP.IdaAtributoProducto04")
         '-------------------------------------------------------------------------
         .AppendFormatLine("  LEFT JOIN Proveedores PRO ON PRO.IdProveedor = P.IdProveedor")
         .AppendFormatLine("	LEFT JOIN ProductosProveedores PP ON PP.IdProducto = VP.IdProducto")
         ' If idProveedor > 0 Then
         '   If mostrarProveedorHabitual Then
         If idProveedor = 0 Or (idProveedor > 0 And mostrarProveedorHabitual) Then
            .AppendFormatLine("		                           AND PP.IdProveedor = P.IdProveedor")
         End If
         ' End If
         '  End If
         .AppendFormatLine("	LEFT JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor")

         .AppendFormatLine("  LEFT JOIN SucursalesDepositos   SD ON SD.IdSucursal = VP.IdSucursal AND SD.IdDeposito = VP.IdDeposito")
         .AppendFormatLine("  LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = VP.IdSucursal AND SU.IdDeposito = VP.IdDeposito AND SU.IdUbicacion = VP.IdUbicacion")

         .AppendFormatLine(" WHERE TC.AfectaCaja = 'True'")
         .AppendFormatLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         If alertaDeCaja Then
            .AppendFormatLine("   AND P.AlertaDeCaja = 'True'")
         End If

         GetListaSucursalesMultiples(stb, sucursales, "V")
         GetListaDepositosMultiples(stb, depositos, "VP")
         If ubicacion IsNot Nothing Then
            .AppendFormatLine("   AND VP.IdDeposito  = {0}", ubicacion.IdDeposito)
            .AppendFormatLine("   AND VP.IdUbicacion = {0}", ubicacion.IdUbicacion)
         End If

         .AppendFormatLine("   AND V.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(desde, True), ObtenerFecha(hasta, True))

         If idListaPrecios > -1 Then
            .AppendFormatLine("   AND VP.IdListaPrecios = {0}", idListaPrecios)
         End If
         If idCaja > 0 Then
            .AppendFormatLine("   AND (V.IdCaja = {0} AND V.IdSucursal = {1})", idCaja, idSucursalCaja)
         End If

         If idProveedor > 0 Then
            .AppendFormatLine("   AND PR.IdProveedor = {0}", idProveedor)
         End If
         'If idProveedor = 0 And mostrarProveedorHabitual Then
         '   .AppendLine("   AND PP.IdProveedor=PR.IdProveedor")
         'End If

         If idVendedor > 0 Then
            .AppendFormatLine("   AND V.IdVendedor = {0}", idVendedor)
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If idMarca > 0 Then
            .AppendFormatLine("   AND P.IdMarca = {0}", idMarca)
         End If

         If idRubro > 0 Then
            .AppendFormatLine("   AND P.IdRubro = {0}", idRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormatLine("   AND P.IdSubRubro = {0}", idSubRubro)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("	AND VP.IdProducto = '{0}'", idProducto)
         End If

         If idCategoria > 0 Then
            .AppendFormatLine("	 AND C.IdCategoria = {0}", idCategoria)
         End If

         If idTransportista > 0 Then
            .AppendFormatLine("	 AND V.IdTransportista = {0}", idTransportista)
         End If

         If esComercial <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND P.EsComercial = {0}", GetStringFromBoolean(esComercial = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendFormatLine(" GROUP BY M.NombreMarca, R.NombreRubro, VP.IdProducto, P.Tamano, P.IdUnidadDeMedida")

         If idProveedor > 0 Then
            .AppendFormatLine("        , PP.CodigoProductoProveedor, P.Embalaje")
            ' End If
            '    If mostrarProveedorHabitual Then
            ' If idProveedor = 0 Then
            ' .AppendLine(", PP.CodigoProductoProveedor")
            '    End If
         End If
         .AppendFormatLine("        , PP.CodigoProductoProveedor, PP.IdProveedor,PRO.CodigoProveedor,PRO.NombreProveedor")
         .AppendFormatLine("        , PP.CodigoProductoProveedor, PP.IdProveedor,PRO.CodigoProveedor,PRO.NombreProveedor")

         .AppendFormatLine("        , {0}", campoNombreProducto)


         If Not unificarSumaProductos Then
            .AppendFormatLine("        , PS.Stock, V.IdSucursal")
            If nivelAgrupamiento = NivelAgrupamientoStock.Deposito Or nivelAgrupamiento = NivelAgrupamientoStock.Ubicacion Then
               .AppendFormatLine("        , SD.NombreDeposito")
            End If
            If nivelAgrupamiento = NivelAgrupamientoStock.Ubicacion Then
               .AppendFormatLine("        , SU.NombreUbicacion")
            End If
         End If

         '-- REQ-35217.- ----------------------------------------------------------
         .AppendFormatLine(" 	      , AP01.IdaAtributoProducto, AP01.Descripcion")
         .AppendFormatLine("        , AP02.IdaAtributoProducto, AP02.Descripcion")
         .AppendFormatLine("        , AP03.IdaAtributoProducto, AP03.Descripcion")
         .AppendFormatLine("        , AP04.IdaAtributoProducto, AP04.Descripcion")
         '-------------------------------------------------------------------------

         .AppendFormatLine(" ORDER BY {0}", campoNombreProducto)

      End With
      Return GetDataTable(stb)
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
                                         idSucursalCaja As Integer,
                                         ivaDiscriminado As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT M.NombreMarca")


         .AppendLine("      ,VP.NombreListaPrecios")
         .AppendLine("      ,VFP.DescripcionFormasPago")




         If UnificarSumaProductos Then
            .AppendLine("      ,MAX(PS.Stock) AS Stock")
            .AppendLine("      ,0 AS IdSucursal") 'Se agrega el campo con valor cero para que lo pueda recuperar la grilla
         Else
            .AppendLine("      ,PS.Stock")
            .AppendLine("      ,V.IdSucursal")
         End If

         .AppendLine("      ,SUM(VP.Cantidad) AS Cantidad")

         'If ivaDiscriminado Then
         .AppendLine("      ,SUM(VP.ImporteTotalNeto) AS ImporteTotalNeto")
         'Else
         '.AppendLine("      ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto) AS ImporteTotalNeto")
         'End If

         .AppendLine("      ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteTotal")
         .AppendLine("      ,SUM(VP.Kilos) AS Kilos")

         .AppendLine("  FROM Ventas V, VentasProductos VP, TiposComprobantes TC,")
         .AppendLine("       Productos P, Marcas M, Clientes C, ProductosSucursales PS,")
         .AppendLine("       VentasFormasPago VFP")

         .AppendLine(" WHERE V.IdSucursal = VP.IdSucursal")
         .AppendLine("   AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine("   AND V.Letra = VP.Letra")
         .AppendLine("   AND V.CentroEmisor = VP.CentroEmisor")
         .AppendLine("   AND V.NumeroComprobante = VP.NumeroComprobante")
         .AppendLine("   AND V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("   AND VP.IdProducto = P.IdProducto")
         .AppendLine("   AND VP.IdProducto = PS.IdProducto")
         .AppendLine("   AND VP.IdSucursal = PS.IdSucursal")
         .AppendLine("   AND V.IdFormasPago = VFP.IdFormasPago")

         If idListaPrecios > -1 Then
            .AppendFormat("   AND VP.IdListaPrecios = {0}", idListaPrecios).AppendLine()
         End If

         If idCaja > 0 Then
            .AppendFormat("   AND (V.IdCaja = {0} AND V.IdSucursal = {1})", idCaja, idSucursalCaja).AppendLine()
         End If

         .AppendLine("   AND P.IdMarca = M.IdMarca")
         .AppendLine("   AND V.IdCliente = C.IdCLiente")

         If AlertaDeCaja Then
            .AppendLine("   AND P.AlertaDeCaja = 'True'")
         End If

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         SqlServer.Comunes.GetListaSucursalesMultiples(stb, Sucursales, "V")
         .AppendLine("	 AND V.Fecha >= '" & Desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("	 AND V.Fecha <= '" & Hasta.ToString("yyyyMMdd HH:mm:ss") & "'")


         'If TipoKilos = "CON KILOS" Then
         '   .AppendLine("   AND VP.Kilos <> 0")
         'ElseIf TipoKilos = "SIN KILOS" Then
         '   .AppendLine("   AND VP.Kilos = 0")
         'End If

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If IdCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If

         If IdMarca > 0 Then
            .AppendLine("   AND P.IdMarca = " & IdMarca.ToString())
         End If

         If IdRubro > 0 Then
            .AppendLine("   AND P.IdRubro = " & IdRubro.ToString())
         End If

         If IdSubRubro > 0 Then
            .AppendLine("   AND P.IdSubRubro = " & IdSubRubro.ToString())
         End If

         If IdCategoria > 0 Then
            .AppendLine("	 AND C.IdCategoria = " & IdCategoria.ToString())
         End If

         .AppendLine(" GROUP BY M.NombreMarca, VP.NombreListaPrecios, VFP.DescripcionFormasPago")

         If Not UnificarSumaProductos Then
            .AppendLine(", PS.Stock")
            .AppendLine(", V.IdSucursal ")
         End If

         .AppendLine(" ORDER BY 1, 2, 3")

      End With

      Return Me.GetDataTable(stb.ToString())

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
                                         idSucursalCaja As Integer,
                                         ivaDiscriminado As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT R.NombreRubro")

         If xAgrupamiento <> Entidades.Venta.SumaXAgrupamiento.RUBRO Then
            If xAgrupamiento = Entidades.Venta.SumaXAgrupamiento.LISTA Then
               .AppendLine("      ,VP.NombreListaPrecios")
               .AppendLine("      ,VFP.DescripcionFormasPago")
            Else
               .AppendLine("      ,(C.IdZonaGeografica + ' - ' + ZG.NombreZonaGeografica) AS IdZonaGeografica")
            End If
         End If

         If UnificarSumaProductos Then
            .AppendLine("      ,MAX(PS.Stock) AS Stock")
            .AppendLine("      ,0 AS IdSucursal") 'Se agrega el campo con valor cero para que lo pueda recuperar la grilla
         Else
            .AppendLine("      ,PS.Stock")
            .AppendLine("      ,V.IdSucursal")
         End If

         .AppendLine("      ,SUM(VP.Cantidad) AS Cantidad")

         'If ivaDiscriminado Then
         .AppendLine("      ,SUM(VP.ImporteTotalNeto) AS ImporteTotalNeto")
         'Else
         '.AppendLine("      ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto) AS ImporteTotalNeto")
         'End If

         .AppendLine("      ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteTotal")
         .AppendLine("      ,SUM(VP.Kilos) AS Kilos")

         .AppendLine("  FROM Ventas V, VentasProductos VP, TiposComprobantes TC,")
         .AppendLine("       Productos P, Rubros R, Clientes C, ProductosSucursales PS,")
         .AppendLine("       VentasFormasPago VFP, ZonasGeograficas ZG")

         .AppendLine(" WHERE V.IdSucursal = VP.IdSucursal")
         .AppendLine("   AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine("   AND V.Letra = VP.Letra")
         .AppendLine("   AND V.CentroEmisor = VP.CentroEmisor")
         .AppendLine("   AND V.NumeroComprobante = VP.NumeroComprobante")
         .AppendLine("   AND V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("   AND VP.IdProducto = P.IdProducto")
         .AppendLine("   AND VP.IdProducto = PS.IdProducto")
         .AppendLine("   AND VP.IdSucursal = PS.IdSucursal")
         .AppendLine("   AND V.IdFormasPago = VFP.IdFormasPago")
         .AppendLine("   AND C.IdZonaGeografica = ZG.IdZonaGeografica")

         If idListaPrecios > -1 Then
            .AppendFormat("   AND VP.IdListaPrecios = {0}", idListaPrecios).AppendLine()
         End If

         If idCaja > 0 Then
            .AppendFormat("   AND (V.IdCaja = {0} AND V.IdSucursal = {1})", idCaja, idSucursalCaja).AppendLine()
         End If

         .AppendLine("   AND P.IdRubro = R.IdRubro")
         .AppendLine("   AND V.IdCliente = C.IdCLiente")

         If AlertaDeCaja Then
            .AppendLine("   AND P.AlertaDeCaja = 'True'")
         End If

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         SqlServer.Comunes.GetListaSucursalesMultiples(stb, Sucursales, "V")
         .AppendLine("	 AND V.Fecha >= '" & Desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("	 AND V.Fecha <= '" & Hasta.ToString("yyyyMMdd HH:mm:ss") & "'")


         'If TipoKilos = "CON KILOS" Then
         '   .AppendLine("   AND VP.Kilos <> 0")
         'ElseIf TipoKilos = "SIN KILOS" Then
         '   .AppendLine("   AND VP.Kilos = 0")
         'End If

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If IdCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If

         If IdMarca > 0 Then
            .AppendLine("   AND P.IdMarca = " & IdMarca.ToString())
         End If

         If IdRubro > 0 Then
            .AppendLine("   AND P.IdRubro = " & IdRubro.ToString())
         End If

         If IdSubRubro > 0 Then
            .AppendLine("   AND P.IdSubRubro = " & IdSubRubro.ToString())
         End If

         If IdCategoria > 0 Then
            .AppendLine("	 AND C.IdCategoria = " & IdCategoria.ToString())
         End If

         If xAgrupamiento = Entidades.Venta.SumaXAgrupamiento.RUBRO Then
            .AppendLine(" GROUP BY R.NombreRubro")
         ElseIf xAgrupamiento = Entidades.Venta.SumaXAgrupamiento.LISTA Then
            .AppendLine(" GROUP BY R.NombreRubro, VP.NombreListaPrecios, VFP.DescripcionFormasPago")
         Else
            .AppendLine(" GROUP BY R.NombreRubro, C.IdZonaGeografica, ZG.NombreZonaGeografica")
         End If

         If Not UnificarSumaProductos Then
            .AppendLine(", PS.Stock")
            .AppendLine(", V.IdSucursal ")
         End If

         '# Ordenamiento
         If xAgrupamiento = Entidades.Venta.SumaXAgrupamiento.RUBRO Then
            .AppendLine(" ORDER BY R.NombreRubro")
         ElseIf xAgrupamiento = Entidades.Venta.SumaXAgrupamiento.LISTA Then
            .AppendLine(" ORDER BY R.NombreRubro, VP.NombreListaPrecios, VFP.DescripcionFormasPago")
         Else
            .AppendLine(" ORDER BY R.NombreRubro, ZG.NombreZonaGeografica")
         End If

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
#End Region

#Region "Get Total Por"
   Public Function GetTotalPorComprobante(idEmpresa As Integer,
                                       periodoFiscal As Integer,
                                       grabaLibro As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT S.Nombre AS NombreSucursal")
         .AppendLine("      ,TC.Descripcion")
         .AppendLine("      ,V.Letra")
         .AppendLine("      ,SUM(V.SubTotal) as Neto")
         .AppendLine("      ,SUM(V.TotalImpuestos) as TotalImpuestos")
         .AppendLine("      ,SUM(V.TotalImpuestoInterno) AS TotalImpuestoInterno")
         .AppendLine("      ,SUM(V.ImporteTotal) as Total")
         .AppendLine("  FROM Sucursales S")
         .AppendLine(" INNER JOIN Ventas V ON V.IdSucursal = S.IdSucursal")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")

         .AppendLine(" WHERE TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero

         'El IVA es por Empresa, no por Sucursal. Pregunto por la pantalla posicion de IVA. Hay que modificarla.
         .AppendFormatLine("	 AND S.IdEmpresa = {0}", idEmpresa)

         .AppendLine("   AND YEAR(V.Fecha)*100+MONTH(V.Fecha) = " & periodoFiscal.ToString())

         If grabaLibro = "SI" Then
            .AppendLine("	AND TC.GrabaLibro = 'True'")
         ElseIf grabaLibro = "NO" Then
            .AppendLine("	AND TC.GrabaLibro = 'False'")
         End If

         .AppendLine("	GROUP BY S.Nombre, TC.Descripcion, V.Letra")
         .AppendLine("	ORDER BY S.Nombre, TC.Descripcion, V.Letra")
      End With

      Return GetDataTable(stb.ToString())

   End Function

   Public Function InfTotalesDeVentasPorClientes(sucursales As Entidades.Sucursal(),
                                              desde As Date,
                                              hasta As Date,
                                              conIVA As Boolean,
                                              idCliente As Long,
                                              idTipoComprobante As String,
                                              idZonaGeografica As String,
                                              idMarca As Integer,
                                              idRubro As Integer,
                                              IdVendedor As Integer,
                                              tipoVendedor As String,
                                              idProducto As String,
                                              nivelAutorizacion As Short,
                                              grupos As Entidades.Grupo(),
                                              GrabaLibro As String,
                                              agruparXRubro As Boolean,
                                              agruparXMarca As Boolean,
                                              agruparXVendedor As String,
                                              IdProveedor As Long,
                                              incluirPreComprobantes As Boolean,
                                              Habitual As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      '# Seteo las fechas con el primer día del mes y el útlimo segundo del mes para abarcar correctamente los períodos.
      Dim x As Date
      Dim cantPeriodos As Integer = 1
      desde = PrimerDiaMes(desde)

      With stb

         .AppendFormatLine("SELECT CodigoCliente")
         .AppendFormatLine("   	   ,NombreCliente")
         .AppendFormatLine("   	   ,{0}", Entidades.Cliente.Columnas.Direccion.ToString())
         .AppendFormatLine("   	   ,{0}", Entidades.Cliente.Columnas.Telefono.ToString())
         .AppendFormatLine("   	   ,{0}", Entidades.Cliente.Columnas.Cuit.ToString())
         .AppendFormatLine("        ,{0}", Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString())

         '# Columnas Dinámicas
         If idMarca <> 0 Or agruparXMarca Then
            .AppendFormatLine("        ,{0}, {1}", Entidades.Marca.Columnas.IdMarca.ToString(), Entidades.Marca.Columnas.NombreMarca.ToString())
         End If
         If idRubro <> 0 Or agruparXRubro Then
            .AppendFormatLine("        ,{0}, {1}", Entidades.Rubro.Columnas.IdRubro.ToString(), Entidades.Rubro.Columnas.NombreRubro.ToString())
         End If
         If Not String.IsNullOrEmpty(agruparXVendedor) Then
            .AppendFormatLine("   	   ,{0}, {1}", Entidades.Venta.Columnas.IdVendedor.ToString(), Entidades.Empleado.Columnas.NombreEmpleado.ToString())
         End If
         If IdProveedor <> 0 Or Habitual Then
            .AppendFormatLine("        ,{0}, {1}", Entidades.Proveedor.Columnas.CodigoProveedor.ToString(), Entidades.Proveedor.Columnas.NombreProveedor.ToString())
         End If


         x = desde
         .Append("   	   ,0")
         While x <= hasta
            .AppendFormat("+ CASE WHEN PVT.[{0}] IS NULL THEN 0 ELSE PVT.[{0}] END ", x.ToString("yyyy/MM"))
            x = x.AddMonths(1)
         End While
         .AppendFormatLine(" Total")

         x = desde
         While x <= hasta
            .AppendFormatLine("   	   ,[{0}]", x.ToString("yyyy/MM"))
            x = x.AddMonths(1)
         End While

         .AppendFormatLine("FROM (SELECT C.CodigoCliente")
         .AppendFormatLine("   		,C.NombreCliente")
         .AppendFormatLine("   		,C.{0}", Entidades.Cliente.Columnas.Direccion.ToString())
         .AppendFormatLine("   		,C.{0}", Entidades.Cliente.Columnas.Telefono.ToString())
         .AppendFormatLine("   		,C.{0}", Entidades.Cliente.Columnas.Cuit.ToString())
         .AppendFormatLine("   		,TCL.{0}", Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString())

         '# Columnas Dinámicas
         If idMarca <> 0 Or agruparXMarca Then
            .AppendFormatLine("   		,P.{0}, M.{1}", Entidades.Marca.Columnas.IdMarca.ToString(), Entidades.Marca.Columnas.NombreMarca.ToString())
         End If
         If idRubro <> 0 Or agruparXRubro Then
            .AppendFormatLine("        ,P.{0}, R.{1}", Entidades.Rubro.Columnas.IdRubro.ToString(), Entidades.Rubro.Columnas.NombreRubro.ToString())
         End If
         If Not String.IsNullOrEmpty(agruparXVendedor) Then
            .AppendFormatLine("        ,{0}.{1}, E.{2}", If(agruparXVendedor = Entidades.OrigenFK.Actual.ToString(), "C", "V"), Entidades.Venta.Columnas.IdVendedor.ToString(), Entidades.Empleado.Columnas.NombreEmpleado.ToString())
         End If
         If IdProveedor <> 0 Or Habitual Then
            .AppendFormatLine("        ,PR.{0}, PR.{1}", Entidades.Proveedor.Columnas.CodigoProveedor.ToString(), Entidades.Proveedor.Columnas.NombreProveedor.ToString())
         End If

         .AppendFormatLine("   		,LEFT(CONVERT(VARCHAR(11),V.Fecha,111),7) Periodo")

         '# Detalle o Cabecera
         Dim total As String = String.Empty
         If idMarca <> 0 Or idRubro <> 0 Or Not String.IsNullOrEmpty(idProducto) Or
            agruparXMarca Or
            agruparXRubro Or
            Not String.IsNullOrEmpty(agruparXVendedor) Or IdProveedor <> 0 Or
            Habitual Then
            If conIVA Then
               total = "SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
               .AppendFormatLine("      ,{0} AS Total", total)
            Else
               total = "SUM(VP.ImporteTotalNeto)"
               .AppendFormatLine("      ,{0} AS Total", total)
            End If
         Else
            If conIVA Then
               total = "SUM(V.ImporteTotal)"
               .AppendFormatLine("      ,{0} AS Total", total)
            Else
               total = "SUM(V.SubTotal)"
               .AppendFormatLine("      ,{0} AS Total", total)
            End If
         End If

         .AppendFormatLine("   	 FROM Clientes C ")
         .AppendFormatLine("   	 	LEFT JOIN Ventas V ON C.IdCliente = V.IdCliente ")
         .AppendFormatLine("   	 	LEFT JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         .AppendFormatLine("   	 	LEFT JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")

         If Not String.IsNullOrEmpty(agruparXVendedor) Then
            .AppendFormatLine("   	 	LEFT JOIN Empleados E ON {0}.IdVendedor = E.IdEmpleado", If(agruparXVendedor = Entidades.OrigenFK.Actual.ToString(), "C", "V"))
         End If

         .AppendFormatLine("        INNER JOIN TiposClientes TCL ON C.{0} = TCL.{0}", Entidades.Cliente.Columnas.IdTipoCliente.ToString())

         If idMarca <> 0 Or idRubro <> 0 Or Not String.IsNullOrEmpty(idProducto) Or
            agruparXMarca Or
            agruparXRubro Or
            IdProveedor <> 0 Or
            Habitual Or
            Not String.IsNullOrEmpty(agruparXVendedor) Then
            .AppendLine("   	 	LEFT JOIN VentasProductos VP ON VP.IdSucursal = V.IdSucursal AND VP.IdTipoComprobante = V.IdTipoComprobante ")
            .AppendLine("   	 	   AND VP.Letra = V.Letra AND VP.CentroEmisor = V.CentroEmisor AND VP.NumeroComprobante = V.NumeroComprobante")
            .AppendLine("   	 	LEFT JOIN Productos P ON P.IdProducto = VP.IdProducto")

            If Habitual Then
               If IdProveedor = 0 Then
                  .AppendLine("	INNER JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto AND PP.IdProveedor=P.IdProveedor")
                  .AppendLine("	INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor")
               End If
            End If

            If IdProveedor > 0 Then
               .AppendLine("	INNER JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto AND PP.IdProveedor = " & IdProveedor.ToString())
               .AppendLine("	INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor")
            End If



            .AppendFormatLine("   	 	LEFT JOIN Marcas M ON P.{0} = M.{0}", Entidades.Marca.Columnas.IdMarca.ToString())
            .AppendFormatLine("   	 	LEFT JOIN Rubros R ON P.{0} = R.{0}", Entidades.Rubro.Columnas.IdRubro.ToString())

         End If
         .AppendFormatLine("      WHERE 1 = 1")
         .AppendFormatLine("                               ")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)
         GetListaSucursalesMultiples(stb, sucursales, "V")


         If incluirPreComprobantes = True Then  'REQ 33604 
            .AppendFormatLine("        AND ((TC.AfectaCaja = 'True'  AND TC.EsComercial = 'True') OR TC.EsPreElectronico = 'True') ")
         Else
            .AppendFormatLine("        AND TC.AfectaCaja = 'True'  AND TC.EsComercial = 'True'")
         End If

         .AppendFormatLine("   	 	AND V.Fecha >= '{0}'", ObtenerFecha(PrimerDiaMes(desde), True))
         .AppendFormatLine("   	 	AND V.Fecha <= '{0}'", ObtenerFecha(UltimoSegundoDelDia(UltimoDiaMes(hasta)), True))


         If idMarca > 0 Then
            .AppendLine("  AND P.IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("  AND P.IdRubro = " & idRubro.ToString())
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         If IdVendedor > 0 Then
            .AppendFormatLine("	AND {0}.IdVendedor = {1}", If(tipoVendedor = Entidades.OrigenFK.Actual.ToString(), "C", "V"), IdVendedor)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	 AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND VP.IdProducto = '{0}'", idProducto)
         End If
         GetListaMultiples(stb, grupos, "TC")

         If GrabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         End If

         .AppendFormat("   	 GROUP BY C.CodigoCliente, C.NombreCliente, C.Direccion, C.Cuit, C.Telefono, TCL.NombreTipoCliente")
         .AppendFormat(", V.Fecha")

         '# Columnas Dinámicas
         If idMarca <> 0 Or agruparXMarca Then
            .AppendFormat(",P.{0}, M.{1}", Entidades.Marca.Columnas.IdMarca.ToString(), Entidades.Marca.Columnas.NombreMarca.ToString())
         End If
         If idRubro <> 0 Or agruparXRubro Then
            .AppendFormat(",P.{0}, R.{1}", Entidades.Rubro.Columnas.IdRubro.ToString(), Entidades.Rubro.Columnas.NombreRubro.ToString())
         End If
         If Not String.IsNullOrEmpty(agruparXVendedor) Then
            .AppendFormatLine("        ,{0}.{1}, E.{2}", If(agruparXVendedor = Entidades.OrigenFK.Actual.ToString(), "C", "V"), Entidades.Venta.Columnas.IdVendedor.ToString(), Entidades.Empleado.Columnas.NombreEmpleado.ToString())
         End If

         If Habitual Or IdProveedor <> 0 Then
            .AppendLine(",PR.CodigoProveedor,Pr.NombreProveedor")
         End If


         .AppendFormatLine(") SRC")
         .AppendFormatLine("PIVOT")
         .AppendFormatLine("   (")
         .AppendFormatLine("     SUM(Total)")
         .AppendFormat("   	FOR Periodo IN ([0]")

         x = desde
         While x <= hasta
            .AppendFormatLine("   	   ,[{0}]", x.ToString("yyyy/MM"))
            x = x.AddMonths(1)
         End While

         .AppendFormatLine("   )) PVT")
         .AppendFormatLine("   ORDER BY NombreCliente,")
         .AppendFormatLine("            CodigoCliente")

      End With

      Return Me.GetDataTable(stb.ToString())


   End Function

   Public Function VentasTotalSucursal(ByVal suc As List(Of Integer),
                                    ByVal Desde As Date,
                                    ByVal Hasta As Date) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      With stb
         .Length = 0
         .AppendLine("SELECT S.Nombre, ")
         .AppendLine("       TC.DescripcionAbrev, ")
         .AppendLine("       SUM(V.ImporteTotal) Total ")
         .AppendLine(" FROM Ventas V ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante ")
         .AppendLine("     AND TC.AfectaCaja = 'True' ")
         .AppendLine("     AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         .AppendLine(" INNER JOIN Sucursales S ON V.IdSucursal = S.IdSucursal ")
         If Desde <> Nothing Then
            .AppendFormat("	 AND V.Fecha >= '{0} 00:00:00'", Desde.ToString("yyyyMMdd"))
            .AppendFormat("	 AND V.Fecha <= '{0} 23:59:59'", Hasta.ToString("yyyyMMdd"))
         End If
         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat(" AND V.IdSucursal = 0")
         Else
            .AppendFormat(" AND V.IdSucursal IN ({0})", sucur)
         End If
         .AppendLine("GROUP BY S.Nombre ")
         .AppendLine("        ,TC.DescripcionAbrev ")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

#End Region

End Class