Public Class OrganizarEntregas
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub GetQryPedidosV2(stb As StringBuilder,
                              fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                              IdEmpleado As Integer, producto As String,
                              sinStock As Boolean, NombreProducto As String, idSucursal As Integer,
                              usaFechaEnvio As Boolean, pedidos As Boolean, reenvios As Boolean,
                              ordenProducto As Integer?,
                              IdLocalidad As Integer?,
                              IdCliente As Long?)
      With stb
         If pedidos Then
            .AppendFormatLine("SELECT T.NombreTransportista")
            .AppendFormatLine("     , T.IdTransportista")
            .AppendFormatLine("     , T.KilosMaximo")
            .AppendFormatLine("     , T.PaletsMaximo")
            .AppendFormatLine("     , E.NombreEmpleado")
            .AppendFormatLine("     , V.IdSucursal")
            .AppendFormatLine("     , v.IdTipoComprobante")
            .AppendFormatLine("     , ISNULL(v.IdTipoComprobanteFact, c.IdTipoComprobante) tipoCompCliente")
            .AppendFormatLine("     , V.Letra")
            .AppendFormatLine("     , V.CentroEmisor")
            .AppendFormatLine("     , V.NumeroPedido")
            .AppendFormatLine("     , V.FechaPedido")
            .AppendFormatLine("     , PE.FechaEntrega")
            .AppendFormatLine("     , c.TipoDocCliente")
            .AppendFormatLine("     , c.NroDocCliente")
            .AppendFormatLine("     , C.CodigoCliente")
            .AppendFormatLine("     , C.NombreCliente")
            .AppendFormatLine("     , C.HorarioClienteCompleto")
            .AppendFormatLine("     , V.Direccion") 'REQ-
            .AppendFormatLine("     , L.NombreLocalidad")
            .AppendFormatLine("     , VP.IdProducto")

            .AppendFormatLine("     , P.CodigoDeBarras") 'PE-31588

            .AppendFormatLine("     , VP.NombreProducto")
            .AppendFormatLine("     , P.NombreProducto Producto_NombreProducto")
            .AppendFormatLine("     , P.Orden AS OrdenProducto")
            .AppendFormatLine("     , PS.Ubicacion")
            .AppendFormatLine("     , P.IdRubro")
            .AppendFormatLine("     , R.NombreRubro")

            .AppendFormatLine("     , VP.TipoOperacion")
            .AppendFormatLine("     , VP.Nota")

            .AppendFormatLine("     , V.ImporteTotal")
            .AppendFormatLine("     , (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN VP.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN PE.CantEstado ELSE 0 END) END) AS Cantidad")

            .AppendFormatLine("     , VP.Precio")
            .AppendFormatLine("     , VP.ImporteTotal AS ImporteTotalProducto")
            .AppendFormatLine("     , V.IdFormasPago")
            .AppendFormatLine("     , Vfp.DescripcionFormasPago")
            .AppendFormatLine("     , Vfp.Dias")
            .AppendFormatLine("     , 'True' AS pasa")
            .AppendFormatLine("     , C.Cuit")
            .AppendFormatLine("     , CF.NombreCategoriaFiscal")
            .AppendFormatLine("  	  ,CASE WHEN C.Alicuota2deProducto = 'SEGUNCATEGORIAFISCAL' then 'Según Categoría Fiscal' ELSE  C.Alicuota2deProducto END AS Alicuota2deProducto")
            .AppendFormatLine("     , V.Observacion")
            .AppendFormatLine("     , 0 AS Reenvio")

            .AppendFormatLine("     ,CF.SolicitaCuit")
            .AppendFormatLine("     ,V.Kilos")
            .AppendFormatLine("     ,V.Palets")
            .AppendFormatLine("  FROM Pedidos V")
            .AppendFormatLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
            .AppendFormatLine("  LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista")
            .AppendFormatLine("  LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor")
            .AppendFormatLine("  LEFT JOIN Clientes C ON C.idCliente = V.idCliente")
            .AppendFormatLine("  LEFT JOIN Calles Ca ON Ca.IdCalle = C.IdCalle")
            .AppendFormatLine("  LEFT JOIN VentasFormasPago vfp ON vfp.IdFormasPago = v.IdFormasPago")
            .AppendFormatLine("  LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
            .AppendFormatLine("  LEFT JOIN Localidades AS L ON L.IdLocalidad = C.IdLocalidad")
            .AppendFormatLine("  INNER JOIN PedidosProductos VP ON V.IdSucursal = VP.IdSucursal")
            .AppendFormatLine("                                   AND V.IdTipoComprobante = vp.IdTipoComprobante")
            .AppendFormatLine("                                   AND V.Letra = vp.Letra")
            .AppendFormatLine("                                   AND V.CentroEmisor = VP.CentroEmisor")
            .AppendFormatLine("                                   AND V.NumeroPedido = VP.NumeroPedido")
            .AppendFormatLine("  INNER JOIN PedidosEstados PE ON PE.IdSucursal = VP.IdSucursal")
            .AppendFormatLine("                              AND PE.IdTipoComprobante = vp.IdTipoComprobante")
            .AppendFormatLine("                              AND PE.Letra = vp.Letra")
            .AppendFormatLine("                              AND PE.CentroEmisor = VP.CentroEmisor")
            .AppendFormatLine("                              AND PE.NumeroPedido = VP.NumeroPedido")
            .AppendFormatLine("                              AND PE.Orden = VP.Orden")
            .AppendFormatLine("                              AND PE.IdProducto = VP.IdProducto")
            .AppendFormatLine("  INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
            .AppendFormatLine("  INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
            .AppendFormatLine("  INNER JOIN ProductosSucursales PS ON PS.IdProducto = VP.IdProducto AND PS.IdSucursal = {0}", idSucursal)
            .AppendFormatLine("  INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = 'PEDIDOSCLIE'")
            .AppendFormatLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'")
            .AppendFormatLine("       AND PE.IdEstado = 'PENDIENTE'")
            .AppendFormatLine("   AND V.IdSucursal = {0}", idSucursal)
            If usaFechaEnvio Then
               .AppendFormatLine("       AND (PE.FechaEntrega BETWEEN '{0:yyyyMMdd} 00:00:00' AND '{1:yyyyMMdd} 23:59:59' OR PE.FechaEntrega IS NULL)", fechaDesde, fechaHasta)
            Else
               .AppendFormatLine("       AND (V.FechaPedido BETWEEN '{0:yyyyMMdd} 00:00:00' AND '{1:yyyyMMdd} 23:59:59' OR V.FechaPedido IS NULL)", fechaDesde, fechaHasta)
            End If

            If IdCliente.HasValue Then
               .AppendFormatLine("   AND V.IdCliente= {0}", IdCliente)
            End If

            If IdLocalidad.HasValue Then
               .AppendFormatLine("   AND L.IdLocalidad= {0}", IdLocalidad)
            End If

            If IdEmpleado > 0 Then
               .AppendFormatLine("       AND V.IdVendedor = {0} ", IdEmpleado)
            End If
            If Not distribucion = 0 Then
               .AppendFormatLine("       AND V.IdTransportista = {0}", distribucion)
            End If

            If Not String.IsNullOrEmpty(NombreProducto) Then
               For Each Palabra As String In NombreProducto.Split(" "c)
                  .AppendFormatLine("       AND P.NombreProducto LIKE '%{0}%'", Palabra)
               Next
            End If

            If Not String.IsNullOrEmpty(producto) Then
               .AppendFormatLine("       AND VP.IdProducto = '{0}'", producto)
            End If
            If sinStock = True Then
               .AppendFormatLine("       AND PS.Stock < 0 ")
            End If

            If ordenProducto.HasValue Then
               .AppendFormatLine("       AND P.Orden = {0}", ordenProducto)
            End If

         End If            'If pedidos then

         If pedidos And reenvios Then
            .AppendFormatLine("         UNION ALL")
         End If            'If pedidos And reenvios Then

         If reenvios Then
            .AppendFormatLine("SELECT T.NombreTransportista")
            .AppendFormatLine("     , T.IdTransportista")
            .AppendFormatLine("     , T.KilosMaximo")
            .AppendFormatLine("     , T.PaletsMaximo")
            .AppendFormatLine("     , E.NombreEmpleado")
            .AppendFormatLine("     , V.IdSucursal")
            .AppendFormatLine("     , v.IdTipoComprobante")
            .AppendFormatLine("     , NULL tipoCompCliente")
            .AppendFormatLine("     , V.Letra")
            .AppendFormatLine("     , V.CentroEmisor")
            .AppendFormatLine("     , V.NumeroComprobante AS NumeroPedido")
            .AppendFormatLine("     , V.Fecha AS FechaPedido")
            .AppendFormatLine("     , V.FechaEnvio AS FechaEntrega")
            .AppendFormatLine("     , c.TipoDocCliente")
            .AppendFormatLine("     , c.NroDocCliente")
            .AppendFormatLine("     , C.CodigoCliente")
            .AppendFormatLine("     , C.NombreCliente")
            .AppendFormatLine("     , C.HorarioClienteCompleto")

            .AppendFormatLine("     , C.Direccion")
            .AppendFormatLine("     , L.NombreLocalidad")
            .AppendFormatLine("     , VP.IdProducto")

            .AppendFormatLine("     , P.CodigoDeBarras") 'PE-31588

            .AppendFormatLine("     , VP.NombreProducto")
            .AppendFormatLine("     , P.NombreProducto Producto_NombreProducto")
            .AppendFormatLine("     , P.Orden AS OrdenProducto")
            .AppendFormatLine("     , PS.Ubicacion")
            .AppendFormatLine("     , P.IdRubro")
            .AppendFormatLine("     , R.NombreRubro")

            .AppendFormatLine("     , VP.TipoOperacion")
            .AppendFormatLine("     , VP.Nota")

            .AppendFormatLine("     , V.ImporteTotal")
            .AppendFormatLine("     , VP.Cantidad")
            .AppendFormatLine("     , VP.Precio")
            .AppendFormatLine("     , VP.ImporteTotal AS ImporteTotalProducto")
            .AppendFormatLine("     , V.IdFormasPago")
            .AppendFormatLine("     , Vfp.DescripcionFormasPago")
            .AppendFormatLine("     , Vfp.Dias")
            .AppendFormatLine("     , 'True' AS pasa")
            .AppendFormatLine("     , C.Cuit")
            .AppendFormatLine("     , CF.NombreCategoriaFiscal")
            .AppendFormatLine("     ,CASE WHEN C.Alicuota2deProducto = 'SEGUNCATEGORIAFISCAL' then 'Según Categoría Fiscal' ELSE  C.Alicuota2deProducto END AS Alicuota2deProducto")
            .AppendFormatLine("     , V.Observacion")
            .AppendFormatLine("     , 1 AS Reenvio")

            .AppendFormatLine("     ,CF.SolicitaCuit")
            .AppendFormatLine("     ,V.Kilos")
            .AppendFormatLine("     ,V.Palets")
            .AppendFormatLine("  FROM Ventas V")
            .AppendFormatLine("  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal")
            .AppendFormatLine("                                     AND CC.IdTipoComprobante = V.IdTipoComprobante")
            .AppendFormatLine("                                     AND CC.Letra = V.Letra")
            .AppendFormatLine("                                     AND CC.CentroEmisor = V.CentroEmisor")
            .AppendFormatLine("                                     AND CC.NumeroComprobante = V.NumeroComprobante")
            .AppendFormatLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
            .AppendFormatLine("  LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista")
            .AppendFormatLine("  LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor")
            .AppendFormatLine("  LEFT JOIN Clientes C ON C.idCliente = V.idCliente")
            .AppendFormatLine("  LEFT JOIN Calles Ca ON Ca.IdCalle = C.IdCalle")
            .AppendFormatLine("  LEFT JOIN VentasFormasPago vfp ON vfp.IdFormasPago = v.IdFormasPago")
            .AppendFormatLine("  LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
            .AppendFormatLine("  LEFT JOIN Localidades AS L ON L.IdLocalidad = C.IdLocalidad")
            .AppendFormatLine("  INNER JOIN VentasProductos VP ON V.IdSucursal = VP.IdSucursal")
            .AppendFormatLine("                                   AND V.IdTipoComprobante = vp.IdTipoComprobante")
            .AppendFormatLine("                                   AND V.Letra = vp.Letra")
            .AppendFormatLine("                                   AND V.CentroEmisor = VP.CentroEmisor")
            .AppendFormatLine("                                   AND V.NumeroComprobante = VP.NumeroComprobante")
            .AppendFormatLine("  INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
            .AppendFormatLine("  INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
            .AppendFormatLine("  INNER JOIN ProductosSucursales PS ON PS.IdProducto = VP.IdProducto AND PS.IdSucursal = {0}", idSucursal)
            .AppendFormatLine(" WHERE V.NumeroReparto IS NULL")
            .AppendFormatLine("   AND V.IdSucursal = {0}", idSucursal)
            .AppendFormatLine("       AND V.MercDespachada = 0")
            .AppendFormatLine("       AND TC.CoeficienteValores = 1")
            .AppendFormatLine("       AND TC.AfectaCaja = 1")
            .AppendFormatLine("       AND TC.EsComercial = 1")
            .AppendFormatLine("       AND CC.Saldo <> 0")
            .AppendFormatLine("       AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')")
            .AppendFormatLine("       AND (V.FechaEnvio BETWEEN '{0:yyyyMMdd} 00:00:00' AND '{1:yyyyMMdd} 23:59:59' OR V.FechaEnvio IS NULL)", fechaDesde, fechaHasta)

            If IdLocalidad.HasValue Then
               .AppendFormatLine("   AND L.IdLocalidad= {0}", IdLocalidad)
            End If

            If IdCliente.HasValue Then
               .AppendFormatLine("   AND V.IdCliente= {0}", IdCliente)
            End If

            If IdEmpleado > 0 Then
               .AppendFormatLine("       AND V.IdVendedor = {0}", IdEmpleado)
            End If
            If Not distribucion = 0 Then
               .AppendFormatLine("       AND V.IdTransportista = {0}", distribucion)
            End If
            If Not String.IsNullOrEmpty(NombreProducto) Then
               For Each Palabra As String In NombreProducto.Split(" "c)
                  .AppendFormatLine("       AND P.NombreProducto LIKE '%{0}%'", Palabra)
               Next
            End If
            If Not String.IsNullOrEmpty(producto) Then
               .AppendFormatLine("       AND VP.IdProducto = '{0}'", producto)
            End If
            If sinStock = True Then
               .AppendFormatLine("       AND PS.Stock < 0 ")
            End If

            If ordenProducto.HasValue Then
               .AppendFormatLine("       AND P.Orden = {0}", ordenProducto)
            End If
         End If            'If reenvios Then

      End With
   End Sub

   Public Function GetPedidosV2(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                IdEmpleado As Integer, producto As String,
                                sinStock As Boolean, nombreProducto As String, idSucursal As Integer,
                                usaFechaEnvio As Boolean, pedidos As Boolean, reenvios As Boolean,
                                ordenProducto As Integer?,
                                IdLocalidad As Integer?,
                                IdCliente As Long?) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P.IdTipoComprobante")
         .AppendFormatLine("     , P.Letra")
         .AppendFormatLine("     , P.CentroEmisor")
         .AppendFormatLine("     , P.NumeroPedido")
         .AppendFormatLine("     , P.IdTransportista")
         .AppendFormatLine("     , P.NombreTransportista")
         .AppendFormatLine("     , P.KilosMaximo")
         .AppendFormatLine("     , P.PaletsMaximo")
         .AppendFormatLine("     , P.NombreEmpleado")
         .AppendFormatLine("     , P.IdSucursal")
         .AppendFormatLine("     , P.FechaPedido")
         .AppendFormatLine("     , P.FechaEntrega")
         .AppendFormatLine("     , P.TipoDocCliente")
         .AppendFormatLine("     , P.NroDocCliente")
         .AppendFormatLine("     , P.NombreCliente")
         .AppendFormatLine("     , P.HorarioClienteCompleto")
         .AppendFormatLine("     , P.Direccion")
         .AppendFormatLine("     , P.NombreLocalidad")
         .AppendFormatLine("     , P.Kilos")
         .AppendFormatLine("     , P.Palets")
         .AppendFormatLine("     , P.ImporteTotal")
         .AppendFormatLine("     , P.IdFormasPago")
         .AppendFormatLine("     , P.DescripcionFormasPago")
         .AppendFormatLine("     , P.tipoCompCliente")
         .AppendFormatLine("     , P.CodigoCliente")
         .AppendFormatLine("     , P.Cuit")
         .AppendFormatLine("     , P.Observacion")
         .AppendFormatLine("     , P.NombreCategoriaFiscal")
         .AppendFormatLine("      ,P.Alicuota2deProducto")
         .AppendFormatLine("     , P.PASA")
         .AppendFormatLine("     , P.Reenvio")
         .AppendFormatLine("     , P.SolicitaCUIT")
         .AppendFormatLine("     , P.Dias")
         .AppendFormatLine("  FROM (")
         GetQryPedidosV2(stb,
                         fechaDesde, fechaHasta, distribucion,
                         IdEmpleado, producto,
                         sinStock, nombreProducto, idSucursal,
                         usaFechaEnvio, pedidos, reenvios,
                         ordenProducto,
                         IdLocalidad,
                         IdCliente)
         .AppendFormatLine(") AS P")
         .AppendFormatLine(" GROUP BY P.IdTipoComprobante")
         .AppendFormatLine("        , P.Letra")
         .AppendFormatLine("        , P.CentroEmisor")
         .AppendFormatLine("        , P.NumeroPedido")
         .AppendFormatLine("        , P.IdTransportista")
         .AppendFormatLine("        , P.NombreTransportista")
         .AppendFormatLine("        , P.NombreEmpleado")
         .AppendFormatLine("        , P.IdSucursal")
         .AppendFormatLine("        , P.FechaPedido")
         .AppendFormatLine("        , P.FechaEntrega")
         .AppendFormatLine("        , P.TipoDocCliente")
         .AppendFormatLine("        , P.NroDocCliente")
         .AppendFormatLine("        , P.NombreCliente")
         .AppendFormatLine("        , P.HorarioClienteCompleto")
         .AppendFormatLine("        , P.Direccion")
         .AppendFormatLine("        , P.NombreLocalidad")
         .AppendFormatLine("        , P.ImporteTotal")
         .AppendFormatLine("        , P.IdFormasPago")
         .AppendFormatLine("        , P.DescripcionFormasPago")
         .AppendFormatLine("        , P.tipoCompCliente")
         .AppendFormatLine("        , P.CodigoCliente")
         .AppendFormatLine("        , P.Cuit")
         .AppendFormatLine("        , P.Observacion")
         .AppendFormatLine("        , P.NombreCategoriaFiscal")
         .AppendFormatLine("        ,P.Alicuota2deProducto")
         .AppendFormatLine("        , P.PASA")
         .AppendFormatLine("        , P.Reenvio")
         .AppendFormatLine("        , P.SolicitaCUIT")
         .AppendFormatLine("        , P.Dias")
         .AppendFormatLine("        , P.Kilos")
         .AppendFormatLine("        , P.KilosMaximo")
         .AppendFormatLine("        , P.PaletsMaximo")
         .AppendFormatLine("        , P.Palets")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPedidosProductosV2(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                         IdEmpleado As Integer, producto As String,
                                         sinStock As Boolean, nombreProducto As String, idSucursal As Integer,
                                         usaFechaEnvio As Boolean, pedidos As Boolean, reenvios As Boolean,
                                         ordenProducto As Integer?,
                                         IdLocalidad As Integer?,
                                         IdCliente As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT P.IdTipoComprobante")
         .AppendFormatLine("     , P.Letra")
         .AppendFormatLine("     , P.CentroEmisor")
         .AppendFormatLine("     , P.NumeroPedido")
         .AppendFormatLine("     , P.IdSucursal")
         .AppendFormatLine("     , P.IdProducto")
         .AppendFormatLine("     , P.CodigoDeBarras")
         .AppendFormatLine("     , P.Kilos")
         .AppendFormatLine("     , P.NombreProducto")
         .AppendFormatLine("     , P.OrdenProducto")
         .AppendFormatLine("     , P.Ubicacion")
         .AppendFormatLine("     , P.IdRubro")
         .AppendFormatLine("     , P.NombreRubro")

         .AppendFormatLine("     , P.Cantidad")
         .AppendFormatLine("     , P.Precio")
         .AppendFormatLine("     , P.TipoOperacion")
         .AppendFormatLine("     , P.Nota")
         .AppendFormatLine("     , P.ImporteTotalProducto AS ImporteTotalProducto")

         .AppendFormatLine("  FROM (")
         GetQryPedidosV2(stb,
                         fechaDesde, fechaHasta, distribucion,
                         IdEmpleado, producto,
                         sinStock, nombreProducto, idSucursal, usaFechaEnvio, pedidos, reenvios,
                         ordenProducto,
                         IdLocalidad,
                         IdCliente)
         .AppendFormatLine(") AS P")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetArticulosSinStockV2(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                          IdEmpleado As Integer, producto As String,
                                          sinStock As Boolean, NombreProducto As String, idSucursal As Integer,
                                          usaFechaEnvio As Boolean, pedidos As Boolean, reenvios As Boolean,
                                          ordenProducto As Integer?,
                                          IdLocalidad As Integer?,
                                          IdCliente As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT P.IdProducto, P.NombreProducto, PS.Stock, P.CantidadSolicitada, 0 AS CantidadFaltante")
         .AppendFormatLine("  FROM (SELECT P.IdProducto, P.Producto_NombreProducto NombreProducto, 0 AS CantidadSolicitada")
         .AppendFormatLine("          FROM (")

         GetQryPedidosV2(stb,
                         fechaDesde, fechaHasta, distribucion,
                         IdEmpleado, producto,
                         sinStock, NombreProducto, idSucursal, usaFechaEnvio, pedidos, reenvios,
                         ordenProducto,
                         IdLocalidad,
                         IdCliente)

         .AppendFormatLine(") AS P")
         .AppendFormatLine("         GROUP BY P.IdProducto, P.Producto_NombreProducto) AS P")
         .AppendFormatLine(" INNER JOIN ProductosSucursales AS PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = {0}", idSucursal)


      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPedidos(fechaDesde As DateTime, fechaHasta As DateTime) As DataTable
      Return GetPedidos(fechaDesde, fechaHasta, 0, 0, String.Empty, False, String.Empty)
   End Function
   Public Function GetPedidos(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                       IdEmpleado As Integer, producto As String,
                                       sinStock As Boolean, NombreProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT T.NombreTransportista, ")
         .AppendLine("     T.IdTransportista,")
         .AppendLine("		E.NombreEmpleado, ")
         .AppendLine("    V.IdSucursal,")
         .AppendLine("		v.IdTipoComprobante, ")
         .AppendLine("		ISNULL(v.IdTipoComprobanteFact, c.IdTipoComprobante) tipoCompCliente, ")
         .AppendLine("		V.Letra, ")
         .AppendLine("     V.CentroEmisor,")
         .AppendLine("		V.NumeroComprobante,")
         .AppendLine("      V.Fecha,")
         .AppendLine("     V.FechaEnvio,")
         .AppendLine("		c.TipoDocCliente,")
         .AppendLine("		c.NroDocCliente,")
         .AppendLine("		C.CodigoCliente,")
         .AppendLine("		C.NombreCliente,")
         '.AppendLine(" C.NombreCliente + '  (#' + ltrim(str(c.codigoCliente)) + ')' as NombreCliente,")
         .AppendLine(" Ca.NombreCalle + ' ' + ltrim(str(C.Altura)) AS Direccion, ")
         '.AppendLine("		Ca.NombreCalle + ' ' + char(C.Altura) AS Direccion, ")
         .AppendLine("		V.ImporteTotal,")
         .Append("		Vfp.DescripcionFormasPago")
         .Append(", 'True' as pasa")
         .Append("     , C.Cuit")
         .Append("     , CF." & Eniac.Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString())
         .Append("     ,V.Observacion")
         .Append(" , 0 AS Reenvio")
         .AppendLine(" FROM Ventas V")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista")
         .AppendLine(" LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .AppendLine(" LEFT JOIN Clientes C ON C.idCliente = V.idCliente ")
         .AppendLine(" LEFT JOIN Calles Ca ON Ca.IdCalle = C.IdCalle")
         .AppendLine(" LEFT JOIN VentasFormasPago vfp ON vfp.IdFormasPago = v.IdFormasPago")
         .AppendLine(" LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal ")

         .AppendLine(" inner Join VentasProductos VP on V.IdSucursal = VP.IdSucursal ")
         .AppendLine(" and V.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine(" and V.Letra = vp.Letra ")
         .AppendLine(" and V.CentroEmisor = VP.CentroEmisor ")
         .AppendLine(" and V.NumeroComprobante = VP.NumeroComprobante  ")
         .AppendLine(" inner join Productos P on P.IdProducto = VP.IdProducto ")
         .AppendLine(" inner join ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")


         .AppendLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'") ''V.IdTipoComprobante = 'PEDIDO'")
         .AppendLine(" AND V.IdEstadoComprobante is null ")
         .AppendFormat("	AND (V.FechaEnvio Between '{0} 00:00:00' AND '{1} 23:59:59' OR V.FechaEnvio is null) ", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))

         If IdEmpleado > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdEmpleado & "")
         End If
         If Not distribucion = 0 Then
            .AppendLine("	AND V.IdTransportista = " & distribucion & "")
         End If

         If Not String.IsNullOrEmpty(NombreProducto) Then
            'Si contiene espacio hago una busqueda por cada palabra
            If Not NombreProducto.Contains(" ") Then
               .AppendLine("   AND P.NombreProducto LIKE '%" & NombreProducto & "%'")
            Else
               Dim Palabras() As String = NombreProducto.Split(" "c)

               .Append("   AND ( 1=1 ")
               For Each Palabra As String In Palabras
                  .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
               Next

               .AppendLine("  )")
            End If


         End If



         If Not String.IsNullOrEmpty(producto) Then
            .AppendLine(" AND VP.IdProducto = '" & producto & "'")
         End If
         If sinStock = True Then
            .AppendLine(" and PS.Stock < 0 ")

         End If
         .AppendLine(" AND V.IdEstadoComprobante is null")
         .AppendLine(" group by V.IdTipoComprobante, V.Letra,  V.CentroEmisor, V.NumeroComprobante,")
         .AppendLine(" T.IdTransportista, T.NombreTransportista, E.NombreEmpleado,  V.IdSucursal, V.Fecha, V.FechaEnvio, c.TipoDocCliente, c.NroDocCliente, ")
         .AppendLine(" C.NombreCliente, Ca.NombreCalle + ' ' + ltrim(str(C.Altura)), V.ImporteTotal,vfp.DescripcionFormasPago,ISNULL(v.IdTipoComprobanteFact, c.IdTipoComprobante), ")
         '.AppendLine(" C.NombreCliente + '  (#' + ltrim(str(c.codigoCliente)) + ')',")
         .AppendLine(" C.NombreCliente, C.CodigoCliente,")
         .AppendLine(" C.Cuit, V.Observacion, CF." & Eniac.Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString())

         .AppendLine(" UNION ")
         .AppendLine("SELECT T.NombreTransportista ")
         .AppendLine("      ,T.IdTransportista")
         .AppendLine("      ,E.NombreEmpleado ")
         .AppendLine("      ,V.IdSucursal ")
         .AppendLine("      ,v.IdTipoComprobante ")
         .AppendLine("      ,NULL tipoCompCliente ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,V.Fecha ")
         .AppendLine("      ,V.FechaEnvio ")
         .AppendLine("      ,c.TipoDocCliente ")
         .AppendLine("      ,c.NroDocCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,C.NombreCliente ")
         .AppendLine("      ,Ca.NombreCalle + ' ' + ltrim(str(C.Altura)) AS Direccion ")
         .AppendLine("      ,V.ImporteTotal ")
         .AppendLine("      ,Vfp.DescripcionFormasPago, 'True' as pasa ")
         .AppendLine("      ,C.Cuit ")
         .AppendLine("      ,CF.NombreCategoriaFiscal ")
         .AppendLine("      ,V.Observacion ")
         .AppendLine("      ,1 AS Reenvio")
         .AppendLine("  FROM Ventas V ")
         .AppendLine(" INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal ")
         .AppendLine("                                AND CC.IdTipoComprobante = V.IdTipoComprobante ")
         .AppendLine("                                AND CC.Letra = V.Letra ")
         .AppendLine("                                AND CC.CentroEmisor = V.CentroEmisor ")
         .AppendLine("                                AND CC.NumeroComprobante = V.NumeroComprobante ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante ")
         .AppendLine("  LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista ")
         .AppendLine("  LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .AppendLine("  LEFT JOIN Clientes C ON C.idCliente = V.idCliente ")
         .AppendLine("  LEFT JOIN Calles Ca ON Ca.IdCalle = C.IdCalle ")
         .AppendLine("  LEFT JOIN VentasFormasPago vfp ON vfp.IdFormasPago = v.IdFormasPago ")
         .AppendLine("  LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal ")
         .AppendLine(" INNER JOIN VentasProductos VP on V.IdSucursal = VP.IdSucursal and V.IdTipoComprobante = vp.IdTipoComprobante and V.Letra = vp.Letra and V.CentroEmisor = VP.CentroEmisor and V.NumeroComprobante = VP.NumeroComprobante ")
         .AppendLine(" INNER JOIN Productos P on P.IdProducto = VP.IdProducto ")
         .AppendLine(" INNER JOIN ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")
         .AppendLine(" WHERE V.NumeroReparto IS NULL ")
         .AppendLine("   AND V.MercDespachada = 0")
         .AppendLine("   AND TC.CoeficienteValores = 1 ")
         .AppendLine("   AND TC.AfectaCaja = 1 ")
         .AppendLine("   AND TC.EsComercial = 1 ")
         .AppendLine("   AND CC.Saldo <> 0 ")
         .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO') ")
         .AppendFormat("	AND (V.FechaEnvio Between '{0} 00:00:00' AND '{1} 23:59:59' OR V.FechaEnvio is null) ", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))

         If IdEmpleado > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdEmpleado)
         End If
         If Not distribucion = 0 Then
            .AppendLine("	AND V.IdTransportista = " & distribucion & "")
         End If
         If Not String.IsNullOrEmpty(NombreProducto) Then
            'Si contiene espacio hago una busqueda por cada palabra
            'If Not NombreProducto.Contains(" ") Then
            '   .AppendLine("   AND P.NombreProducto LIKE '%" & NombreProducto & "%'")
            'Else
            .Append("   AND ( 1=1 ")
            For Each Palabra As String In NombreProducto.Split(" "c)
               .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
            Next
            .AppendLine("  )")
            'End If
         End If
         If Not String.IsNullOrEmpty(producto) Then
            .AppendLine(" AND VP.IdProducto = '" & producto & "'")
         End If
         If sinStock = True Then
            .AppendLine(" and PS.Stock < 0 ")
         End If

         .AppendLine(" GROUP BY V.IdTipoComprobante, V.Letra,  V.CentroEmisor, V.NumeroComprobante, ")
         .AppendLine(" T.IdTransportista, T.NombreTransportista, E.NombreEmpleado,  V.IdSucursal, V.Fecha, V.FechaEnvio, c.TipoDocCliente, c.NroDocCliente, ")
         .AppendLine(" C.NombreCliente, Ca.NombreCalle + ' ' + ltrim(str(C.Altura)), V.ImporteTotal,vfp.DescripcionFormasPago,ISNULL(v.IdTipoComprobanteFact, c.IdTipoComprobante), ")
         .AppendLine(" C.NombreCliente, C.CodigoCliente, ")
         .AppendLine(" C.Cuit, V.Observacion, CF.NombreCategoriaFiscal ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPedidosProductos(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                       IdEmpleado As Integer, producto As String,
                                       sinStock As Boolean, NombreProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT V.IdSucursal ")
         .AppendLine("      ,V.IdTipoComprobante ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,VP.IdProducto ")
         .AppendLine("      ,P.NombreProducto ")
         .AppendLine("      ,VP.Cantidad ")
         .AppendLine("      ,VP.ImporteTotal ")
         .AppendLine("      ,PS.Ubicacion ")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine(" FROM Ventas V")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         ' .AppendLine(" LEFT JOIN Clientes C ON C.idCliente = V.idCliente ")

         .AppendLine("  inner join VentasProductos VP on VP.IdSucursal = V.IdSucursal")

         .AppendLine(" and VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" and VP.CentroEmisor = V.CentroEmisor")
         .AppendLine(" and VP.Letra = V.Letra")
         .AppendLine(" and VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN Productos P on P.IdProducto = VP.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS on PS.IdProducto = VP.IdProducto AND PS.IdSucursal = " + Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString())
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")

         .AppendLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'") ''V.IdTipoComprobante = 'PEDIDO'")
         .AppendLine(" AND V.IdEstadoComprobante is null ")

         .AppendFormat("	AND (V.FechaEnvio Between '{0} 00:00:00' AND '{1} 23:59:59' OR V.FechaEnvio is null) ", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))

         If IdEmpleado > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdEmpleado)
         End If
         If Not distribucion = 0 Then
            .AppendLine("	AND V.IdTransportista = " & distribucion & "")
         End If
         If Not String.IsNullOrEmpty(NombreProducto) Then
            'Si contiene espacio hago una busqueda por cada palabra
            'If Not NombreProducto.Contains(" ") Then
            '   .AppendLine("   AND P.NombreProducto LIKE '%" & NombreProducto & "%'")
            'Else
            .Append("   AND ( 1=1 ")
            For Each Palabra As String In NombreProducto.Split(" "c)
               .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
            Next
            .AppendLine("  )")
            'End If
         End If
         If Not String.IsNullOrEmpty(producto) Then
            .AppendLine(" AND VP.IdProducto = '" & producto & "'")
         End If
         If sinStock = True Then
            .AppendLine(" and PS.Stock < 0 ")
         End If

         .AppendLine(" UNION ")

         .AppendLine("SELECT V.IdSucursal ")
         .AppendLine("      ,V.IdTipoComprobante ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,VP.IdProducto ")
         .AppendLine("      ,P.NombreProducto ")
         .AppendLine("      ,VP.Cantidad ")
         .AppendLine("      ,VP.ImporteTotal ")
         .AppendLine("      ,PS.Ubicacion ")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("  FROM Ventas V ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante ")
         .AppendLine(" INNER JOIN VentasProductos VP ON VP.IdSucursal = V.IdSucursal ")
         .AppendLine("                              AND VP.IdTipoComprobante = V.IdTipoComprobante ")
         .AppendLine("                              AND VP.CentroEmisor = V.CentroEmisor ")
         .AppendLine("                              AND VP.Letra = V.Letra ")
         .AppendLine("                              AND VP.NumeroComprobante = V.NumeroComprobante ")
         .AppendLine(" INNER JOIN Productos P on P.IdProducto = VP.IdProducto ")
         .AppendLine(" INNER JOIN ProductosSucursales PS on PS.IdProducto = VP.IdProducto AND PS.IdSucursal = " + Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString())
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal ")
         .AppendLine("                                AND CC.IdTipoComprobante = V.IdTipoComprobante ")
         .AppendLine("                                AND CC.Letra = V.Letra ")
         .AppendLine("                                AND CC.CentroEmisor = V.CentroEmisor ")
         .AppendLine("                                AND CC.NumeroComprobante = V.NumeroComprobante ")
         .AppendLine(" WHERE V.NumeroReparto IS NULL ")
         .AppendLine("   AND V.MercDespachada = 0")
         .AppendLine("   AND TC.CoeficienteValores = 1 ")
         .AppendLine("   AND TC.AfectaCaja = 1 ")
         .AppendLine("   AND TC.EsComercial = 1 ")
         .AppendLine("   AND CC.Saldo <> 0 ")
         .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO') ")
         .AppendFormat("	AND (V.FechaEnvio Between '{0} 00:00:00' AND '{1} 23:59:59' OR V.FechaEnvio is null) ", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))

         If IdEmpleado > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdEmpleado)
         End If
         If Not distribucion = 0 Then
            .AppendLine("	AND V.IdTransportista = " & distribucion & "")
         End If
         If Not String.IsNullOrEmpty(NombreProducto) Then
            'Si contiene espacio hago una busqueda por cada palabra
            'If Not NombreProducto.Contains(" ") Then
            '   .AppendLine("   AND P.NombreProducto LIKE '%" & NombreProducto & "%'")
            'Else
            .Append("   AND ( 1=1 ")
            For Each Palabra As String In NombreProducto.Split(" "c)
               .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
            Next
            .AppendLine("  )")
            'End If
         End If
         If Not String.IsNullOrEmpty(producto) Then
            .AppendLine(" AND VP.IdProducto = '" & producto & "'")
         End If
         If sinStock = True Then
            .AppendLine(" and PS.Stock < 0 ")
         End If


      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPedidosProductosFiltrados(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                       IdEmpleado As Integer, producto As String,
                                       sinStock As Boolean, NombreProducto As String) As DataTable

      Return GetPedidosProductos(fechaDesde, fechaHasta, distribucion, IdEmpleado, producto, sinStock, NombreProducto)

      'Dim pedidos As DataTable = Me.GetPedidosFiltrados(fechaDesde, fechaHasta, distribucion, TipoDocEmpleado, NroDocEmpleado, producto, sinStock, NombreProducto)
      'Dim stb As StringBuilder = New StringBuilder("")
      'Dim PedidosProductos As New DataTable

      'For Each FilaPedido As DataRow In pedidos.Rows



      '   With stb
      '      .Length = 0

      '      .AppendLine("SELECT V.IdSucursal, V.IdTipoComprobante, ")
      '      .AppendLine("		V.Letra, ")
      '      .AppendLine("     V.CentroEmisor,")
      '      .AppendLine("		V.NumeroComprobante,")
      '      .AppendLine("     VP.IdProducto, P.NombreProducto, VP.Cantidad,  VP.ImporteTotal")

      '      .AppendLine(" FROM Ventas V")
      '      .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
      '      .AppendLine("  inner join VentasProductos VP on VP.IdSucursal = V.IdSucursal")
      '      .AppendLine(" and VP.IdTipoComprobante = V.IdTipoComprobante")
      '      .AppendLine(" and VP.CentroEmisor = V.CentroEmisor")
      '      .AppendLine(" and VP.Letra = V.Letra")
      '      .AppendLine(" and VP.NumeroComprobante = V.NumeroComprobante")
      '      .AppendLine(" INNER JOIN Productos P on P.IdProducto = VP.IdProducto")
      '      .AppendLine(" inner join ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")
      '      .AppendLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'") ''V.IdTipoComprobante = 'PEDIDO'")
      '      .AppendLine("	AND V.IdSucursal = " & FilaPedido("idSucursal").ToString & "")
      '      .AppendLine("	AND V.Letra = '" & FilaPedido("Letra").ToString & "'")
      '      .AppendLine("	AND V.CentroEmisor = " & FilaPedido("CentroEmisor").ToString & "")
      '      .AppendLine("	AND V.NumeroComprobante = " & FilaPedido("NumeroComprobante").ToString & "")

      '      '.AppendFormat("	AND V.FechaEnvio Between '{0} 00:00:00' ", fechaDesde.ToString("yyyyMMdd"))
      '      '.AppendFormat("	AND '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))
      '      'If Not String.IsNullOrEmpty(TipoDocEmpleado) Then
      '      '    .AppendLine("	AND V.TipoDocVendedor = '" & TipoDocEmpleado & "'")
      '      '    .AppendLine("	AND V.NroDocVendedor = '" & NroDocEmpleado & "'")
      '      'End If
      '      'If Not distribucion = 0 Then
      '      '    .AppendLine("	AND V.IdTransportista = " & distribucion & "")
      '      'End If
      '      'If Not String.IsNullOrEmpty(producto) Then
      '      '    .AppendLine(" AND VP.IdProducto = '" & producto & "'")
      '      'End If
      '      'If sinStock = True Then
      '      '    .AppendLine(" and PS.Stock < 0 ")

      '      'End If
      '      '.AppendLine(" AND V.IdEstadoComprobante is null")
      '      '' .AppendLine(" group by V.IdSucursal, V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante,  VP.IdProducto, P.NombreProducto, VP.Cantidad,  VP.ImporteTotal")
      '   End With


      '   PedidosProductos.Merge(Me.GetDataTable(stb.ToString()))
      'Next


      'Return PedidosProductos

   End Function

   Public Function GetPedidosSinFacturar(fechaDesde As DateTime) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT T.NombreTransportista, ")
         .Append("		E.NombreEmpleado, ")
         .Append("		V.IdTipoComprobante, ")
         .Append("		V.Letra, ")
         .Append("		V.NumeroComprobante,")
         .Append("		c.TipoDocCliente,")
         .Append("		c.NroDocCliente,")
         .Append("		C.NombreCliente,")
         .Append("		Ca.NombreCalle + ' ' + char(C.Altura) AS Direccion, ")
         .Append("		V.ImporteTotal,")
         .Append("		Vfp.DescripcionFormasPago,")
         .Append("      C.Cuit,")
         .Append("      CF." & Eniac.Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString())
         .Append(" FROM Ventas V")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .Append(" LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista")
         .Append(" LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .Append(" LEFT JOIN Clientes C ON C.idCliente = V.idCliente ")
         .Append(" LEFT JOIN Calles Ca ON Ca.IdCalle = C.IdCalle")
         .Append(" LEFT JOIN VentasFormasPago vfp ON vfp.IdFormasPago = v.IdFormasPago")
         .Append(" LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal ")

         .AppendLine(" inner Join VentasProductos VP on V.IdSucursal = VP.IdSucursal ")
         .AppendLine(" and V.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine(" and V.Letra = vp.Letra ")
         .AppendLine(" and V.CentroEmisor = VP.CentroEmisor ")
         .AppendLine(" and V.NumeroComprobante = VP.NumeroComprobante  ")
         .AppendLine(" inner join Productos P on P.IdProducto = VP.IdProducto ")
         .AppendLine(" inner join ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")

         .AppendLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'") ''V.IdTipoComprobante = 'PEDIDO'")
         .AppendLine(" AND IdEstadoComprobante is null")
         .AppendFormat("	AND V.FechaEnvio <= '{0} 00:00:00' ", fechaDesde.ToString("yyyyMMdd"))
         .Append(" order by C.NombreCliente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPedidosSinFacturarV2(fechaDesde As DateTime) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT P.IdSucursal,P.IdTipoComprobante,P.Letra,P.CentroEmisor,P.NumeroPedido")
         .AppendLine("  FROM Pedidos P ")
         .AppendLine(" INNER JOIN PedidosProductos PP ON P.IdSucursal = PP.IdSucursal ")
         .AppendLine("                               AND P.IdTipoComprobante = PP.IdTipoComprobante ")
         .AppendLine("                               AND P.Letra = PP.Letra ")
         .AppendLine("                               AND P.CentroEmisor = PP.CentroEmisor ")
         .AppendLine("                               AND P.NumeroPedido = PP.NumeroPedido")
         .AppendLine("  INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendLine("                              AND PE.IdTipoComprobante = PP.IdTipoComprobante")
         .AppendLine("                              AND PE.Letra = PP.Letra")
         .AppendLine("                              AND PE.CentroEmisor = PP.CentroEmisor")
         .AppendLine("                              AND PE.NumeroPedido = PP.NumeroPedido")
         .AppendLine("                              AND PE.Orden = PP.Orden")
         .AppendLine("                              AND PE.IdProducto = PP.IdProducto")
         .AppendLine(" WHERE PE.IdEstado = 'PENDIENTE'")
         .AppendFormat("   AND PE.FechaEntrega <= '{0}'", ObtenerFecha(fechaDesde, False)).AppendLine()
         .AppendLine(" GROUP BY P.IdSucursal,P.IdTipoComprobante,P.Letra,P.CentroEmisor,P.NumeroPedido")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPedidosFiltrados(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                       IdEmpleado As Integer, producto As String,
                                       sinStock As Boolean, NombreProducto As String) As DataTable

      Return GetPedidos(fechaDesde, fechaHasta, distribucion, IdEmpleado, producto, sinStock, NombreProducto)

      '' ''Dim stb As StringBuilder = New StringBuilder("")

      '' ''With stb
      '' ''   '.Append("SELECT T.NombreTransportista, ")
      '' ''   '.AppendLine("		E.NombreEmpleado, ")
      '' ''   '.AppendLine("    V.IdSucursal,")
      '' ''   '.AppendLine("		V.IdTipoComprobante, ")
      '' ''   '.AppendLine("		V.Letra, ")
      '' ''   '.AppendLine("     V.CentroEmisor,")
      '' ''   '.AppendLine("		V.NumeroComprobante,")
      '' ''   '.AppendLine("      V.Fecha,")
      '' ''   '.AppendLine("     V.FechaEnvio,")
      '' ''   '.AppendLine("		c.TipoDocCliente,")
      '' ''   '.AppendLine("		c.NroDocCliente,")
      '' ''   '.AppendLine("		C.NombreCliente,")
      '' ''   '.AppendLine("		Ca.NombreCalle + ' ' + char(C.Altura) AS Direccion, ")
      '' ''   '.AppendLine("		V.ImporteTotal,")
      '' ''   '.AppendLine("      'True' as pasa")


      '' ''   .AppendLine("SELECT T.NombreTransportista, ")
      '' ''   .AppendLine("		E.NombreEmpleado, ")
      '' ''   .AppendLine("    V.IdSucursal,")
      '' ''   .AppendLine("		v.IdTipoComprobante, ")
      '' ''   .AppendLine("		c.IdTipoComprobante tipoCompCliente, ")
      '' ''   .AppendLine("		V.Letra, ")
      '' ''   .AppendLine("     V.CentroEmisor,")
      '' ''   .AppendLine("		V.NumeroComprobante,")
      '' ''   .AppendLine("      V.Fecha,")
      '' ''   .AppendLine("     V.FechaEnvio,")
      '' ''   .AppendLine("		c.TipoDocCliente,")
      '' ''   .AppendLine("		c.NroDocCliente,")
      '' ''   .AppendLine("		C.NombreCliente,")
      '' ''   .AppendLine("		Ca.NombreCalle + ' ' + char(C.Altura) AS Direccion, ")
      '' ''   .AppendLine("		V.ImporteTotal,")
      '' ''   .Append("		Vfp.DescripcionFormasPago")
      '' ''   .Append(", 'True' as pasa")

      '' ''   .Append("     , C.Cuit")
      '' ''   .Append("     , CF." & Eniac.Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString())

      '' ''   .AppendLine(" FROM Ventas V")
      '' ''   .AppendLine(" LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista")
      '' ''   .AppendLine(" LEFT JOIN Empleados E ON E.TipoDocEmpleado = V.TipoDocVendedor ")
      '' ''   .AppendLine("			AND E.NroDocEmpleado = V.NroDocVendedor")
      '' ''   .AppendLine(" LEFT JOIN Clientes C ON C.idCliente = V.idCliente ")
      '' ''   .AppendLine(" LEFT JOIN Calles Ca ON Ca.IdCalle = C.IdCalle")
      '' ''   .Append(" LEFT JOIN VentasFormasPago vfp ON vfp.IdFormasPago = v.IdFormasPago")
      '' ''   .Append(" LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal ")
      '' ''   .AppendLine(" inner Join VentasProductos VP on V.IdSucursal = VP.IdSucursal ")
      '' ''   .AppendLine(" and V.IdTipoComprobante = vp.IdTipoComprobante ")
      '' ''   .AppendLine(" and V.Letra = vp.Letra ")
      '' ''   .AppendLine(" and V.CentroEmisor = VP.CentroEmisor ")
      '' ''   .AppendLine(" and V.NumeroComprobante = VP.NumeroComprobante  ")
      '' ''   .AppendLine(" inner join Productos P on P.IdProducto = VP.IdProducto ")
      '' ''   .AppendLine(" inner join ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")



      '' ''   .AppendLine(" WHERE V.IdTipoComprobante = 'PEDIDO'")
      '' ''   .AppendFormat("	AND V.FechaEnvio Between '{0} 00:00:00' ", fechaDesde.ToString("yyyyMMdd"))
      '' ''   .AppendFormat("	AND '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))
      '' ''   If Not String.IsNullOrEmpty(TipoDocEmpleado) Then
      '' ''      .AppendLine("	AND V.TipoDocVendedor = '" & TipoDocEmpleado & "'")
      '' ''      .AppendLine("	AND V.NroDocVendedor = '" & NroDocEmpleado & "'")
      '' ''   End If
      '' ''   If Not distribucion = 0 Then
      '' ''      .AppendLine("	AND V.IdTransportista = " & distribucion & "")
      '' ''   End If

      '' ''   If Not String.IsNullOrEmpty(NombreProducto) Then
      '' ''      'Si contiene espacio hago una busqueda por cada palabra
      '' ''      If Not NombreProducto.Contains(" ") Then
      '' ''         .AppendLine("   AND P.NombreProducto LIKE '%" & NombreProducto & "%'")
      '' ''      Else
      '' ''         Dim Palabras() As String = NombreProducto.Split(" "c)

      '' ''         .Append("   AND ( 1=1 ")
      '' ''         For Each Palabra As String In Palabras
      '' ''            .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
      '' ''         Next

      '' ''         .AppendLine("  )")
      '' ''      End If


      '' ''   End If



      '' ''   If Not String.IsNullOrEmpty(producto) Then
      '' ''      .AppendLine(" AND VP.IdProducto = '" & producto & "'")
      '' ''   End If
      '' ''   If sinStock = True Then
      '' ''      .AppendLine(" and PS.Stock < 0 ")

      '' ''   End If
      '' ''   .AppendLine(" AND V.IdEstadoComprobante is null")
      '' ''   .AppendLine(" group by T.NombreTransportista, E.NombreEmpleado,  V.IdSucursal, V.IdTipoComprobante,")
      '' ''   .AppendLine(" V.Letra,  V.CentroEmisor, V.NumeroComprobante, V.Fecha, V.FechaEnvio, c.TipoDocCliente, c.NroDocCliente, ")
      '' ''   .AppendLine(" C.NombreCliente, Ca.NombreCalle + ' ' + char(C.Altura), V.ImporteTotal,vfp.DescripcionFormasPago,c.IdTipoComprobante ")
      '' ''   .Append("     , C.Cuit, CF." & Eniac.Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString())
      '' ''End With

      '' ''Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetArticulosSinStock(fechaDesde As DateTime, fechaHasta As DateTime) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine(" SELECT VP.IdProducto, P.NombreProducto, PS.Stock, SUM(VP.Cantidad) as Cantidad ")
         .AppendLine(" FROM Ventas V ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" inner Join VentasProductos VP on V.IdSucursal = VP.IdSucursal ")
         .AppendLine(" and V.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine(" and V.Letra = vp.Letra ")
         .AppendLine(" and V.CentroEmisor = VP.CentroEmisor ")
         .AppendLine(" and V.NumeroComprobante = VP.NumeroComprobante ")
         .AppendLine(" inner join Productos P on P.IdProducto = VP.IdProducto ")
         .AppendLine(" inner join ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")
         .AppendLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'") ''V.IdTipoComprobante = 'PEDIDO'")
         .AppendLine(" AND V.IdEstadoComprobante is null ")
         .AppendFormat("	AND V.FechaEnvio Between '{0} 00:00:00' ", fechaDesde.ToString("yyyyMMdd"))
         .AppendFormat("	AND '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))
         .AppendLine(" and PS.Stock <= 0 ")
         .AppendLine("  GROUP BY VP.IdProducto , P.NombreProducto, PS.Stock ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetArticulosSinStockPedidos(fechaDesde As DateTime, fechaHasta As DateTime) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine(" SELECT VP.IdProducto, P.NombreProducto,  V.IdTipoComprobante, V.Letra,v.idSucursal  ,V.CentroEmisor, V.NumeroComprobante, VP.Cantidad")
         .AppendLine(" FROM Ventas V ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" inner Join VentasProductos VP on V.IdSucursal = VP.IdSucursal ")
         .AppendLine(" and V.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine(" and V.Letra = vp.Letra ")
         .AppendLine(" and V.CentroEmisor = VP.CentroEmisor ")
         .AppendLine(" and V.NumeroComprobante = VP.NumeroComprobante ")
         .AppendLine(" inner join Productos P on P.IdProducto = VP.IdProducto ")
         .AppendLine(" inner join ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")
         .AppendLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'") ''V.IdTipoComprobante = 'PEDIDO'")
         .AppendLine(" AND V.IdEstadoComprobante is null ")
         .AppendFormat("	AND V.FechaEnvio Between '{0} 00:00:00' ", fechaDesde.ToString("yyyyMMdd"))
         .AppendFormat("	AND '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))
         .AppendLine(" and PS.Stock <= 0 ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ArticulosSinStockFiltrados(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                       IdEmpleado As Integer, producto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")


      'Dim pedidos As DataTable = Me.ArticulosSinStockPedidosFiltrados(fechaDesde, fechaHasta, distribucion, TipoDocEmpleado, NroDocEmpleado, producto)

      'Dim PedidosProductos As New DataTable

      'For Each FilaPedido As DataRow In pedidos.Rows


      With stb

         .Length = 0
         .AppendLine(" SELECT VP.IdProducto, P.NombreProducto, PS.Stock, SUM(VP.Cantidad) as Cantidad ")
         '.AppendLine(" SELECT VP.IdProducto, P.NombreProducto, PS.Stock, SUM(VP.Cantidad) as Cantidad  ")
         '.AppendLine("  , V.IdTipoComprobante, V.Letra, V.NumeroComprobante,v.idSucursal  ,V.CentroEmisor ")
         .AppendLine(" FROM Ventas V ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" inner Join VentasProductos VP on V.IdSucursal = VP.IdSucursal ")
         .AppendLine(" and V.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine(" and V.Letra = vp.Letra ")
         .AppendLine(" and V.CentroEmisor = VP.CentroEmisor ")
         .AppendLine(" and V.NumeroComprobante = VP.NumeroComprobante ")
         .AppendLine(" inner join Productos P on P.IdProducto = VP.IdProducto ")
         .AppendLine(" inner join ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")
         .AppendLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'") ''V.IdTipoComprobante = 'PEDIDO'")
         .AppendLine(" AND V.IdEstadoComprobante is null ")
         .AppendLine(" and PS.Stock <= 0 ")

         '.AppendLine("	AND V.IdSucursal = " & FilaPedido("idSucursal").ToString & "")
         '.AppendLine("	AND V.Letra = '" & FilaPedido("Letra").ToString & "'")
         '.AppendLine("	AND V.CentroEmisor = " & FilaPedido("CentroEmisor").ToString & "")
         '.AppendLine("	AND V.NumeroComprobante = " & FilaPedido("NumeroComprobante").ToString & "")


         .AppendFormat("	AND V.FechaEnvio Between '{0} 00:00:00' ", fechaDesde.ToString("yyyyMMdd"))
         .AppendFormat("	AND '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))
         If IdEmpleado > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdEmpleado)
         End If
         If Not distribucion = 0 Then
            .AppendLine("	AND V.IdTransportista = " & distribucion & "")
         End If
         If Not String.IsNullOrEmpty(producto) Then
            .AppendLine(" AND VP.IdProducto = '" & producto & "'")
         End If

         '.AppendFormat("	AND V.FechaEnvio Between '{0} 00:00:00' ", fechaDesde.ToString("yyyyMMdd"))
         '.AppendFormat("	AND '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))

         'If Not String.IsNullOrEmpty(TipoDocEmpleado) Then
         '    .AppendLine("	AND V.TipoDocVendedor = '" & TipoDocEmpleado & "'")
         '    .AppendLine("	AND V.NroDocVendedor = '" & NroDocEmpleado & "'")
         'End If
         'If Not distribucion = 0 Then
         '    .AppendLine("	AND V.IdTransportista = " & distribucion & "")
         'End If
         'If Not String.IsNullOrEmpty(producto) Then
         '    .AppendLine(" AND VP.IdProducto = '" & producto & "'")
         'End If
         '.AppendLine("  GROUP BY VP.IdProducto , P.NombreProducto, PS.Stock ")
         '.AppendLine("  , V.IdTipoComprobante, V.Letra, V.NumeroComprobante,v.idSucursal  ,V.CentroEmisor ")
         .AppendLine("  GROUP BY VP.IdProducto , P.NombreProducto, PS.Stock ")
      End With


      'PedidosProductos.Merge(Me.GetDataTable(stb.ToString()))
      '  Next


      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ArticulosSinStockPedidosFiltrados(fechaDesde As DateTime, fechaHasta As DateTime, distribucion As Integer,
                                       IdEmpleado As Integer, producto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine(" SELECT VP.IdProducto, P.NombreProducto, V.IdTipoComprobante, V.Letra, V.NumeroComprobante, VP.Cantidad,v.idSucursal ")
         .AppendLine(" ,V.CentroEmisor")
         .AppendLine(" FROM Ventas V ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" inner Join VentasProductos VP on V.IdSucursal = VP.IdSucursal ")
         .AppendLine(" and V.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine(" and V.Letra = vp.Letra ")
         .AppendLine(" and V.CentroEmisor = VP.CentroEmisor ")
         .AppendLine(" and V.NumeroComprobante = VP.NumeroComprobante ")
         .AppendLine(" inner join Productos P on P.IdProducto = VP.IdProducto ")
         .AppendLine(" inner join ProductosSucursales PS on PS.IdProducto = VP.IdProducto ")
         .AppendLine(" WHERE TC.Tipo = 'PEDIDOSCLIE'") ''V.IdTipoComprobante = 'PEDIDO'")
         .AppendLine(" AND V.IdEstadoComprobante is null ")
         .AppendFormat("	AND V.FechaEnvio Between '{0} 00:00:00' ", fechaDesde.ToString("yyyyMMdd"))
         .AppendFormat("	AND '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))
         .AppendLine(" and PS.Stock <= 0 ")
         If IdEmpleado > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdEmpleado)
         End If
         If Not distribucion = 0 Then
            .AppendLine("	AND V.IdTransportista = " & distribucion & "")
         End If
         If Not String.IsNullOrEmpty(producto) Then
            .AppendLine(" AND VP.IdProducto = '" & producto & "'")
         End If

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ConsolidadoCargaMercaderia(idSucursal As Integer,
                                              fechaDesde As DateTime?, fechaHasta As DateTime?,
                                              nroRep As Integer(),
                                              dist As Integer,
                                              Idvend As Integer,
                                              productoCodigoNumerico As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT V.IdTransportista , T.NombreTransportista")
         .AppendLine("     , V.IdVendedor, E.NombreEmpleado AS NombreVendedor")
         .AppendLine("     , P.IdRubro, R.NombreRubro")
         If productoCodigoNumerico Then
            .AppendLine("     , RIGHT(REPLICATE(' ',15) + VP.IdProducto,15) AS IdProducto")
         Else
            .AppendLine("     , VP.IdProducto")
         End If
         .AppendLine("     , VP.NombreProducto, VP.Cantidad")
         .AppendLine("     , P.Orden AS OrdenProducto")
         .AppendLine("     , PS.Ubicacion")

         .AppendLine("     , VP.TipoOperacion")
         .AppendLine("     , CASE WHEN VP.TipoOperacion = 'NORMAL' THEN VP.Cantidad ELSE 0 END AS CantidadNormal")
         .AppendLine("     , CASE WHEN VP.TipoOperacion = 'CAMBIO' THEN VP.Cantidad ELSE 0 END AS CantidadCambio")
         .AppendLine("     , CASE WHEN VP.TipoOperacion = 'BONIFICACION' THEN VP.Cantidad ELSE 0 END AS CantidadBonificacion")
         .AppendLine("     , VP.Kilos")
         .AppendLine("     , P.CodigoDeBarras")
         .AppendLine("  FROM Ventas V")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" INNER JOIN VentasProductos VP ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("                              AND VP.IdTipoComprobante = V.IdTipoComprobante AND VP.Letra = V.Letra")
         .AppendLine("                              AND VP.CentroEmisor = V.CentroEmisor AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN Clientes C ON C.idCliente = V.idCliente ")
         .AppendLine(" INNER JOIN Transportistas T ON T.IdTransportista = v.IdTransportista")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" INNER JOIN ProductosSucursales PS on PS.IdProducto = VP.IdProducto AND PS.IdSucursal = " + Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString())
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")

         .AppendFormatLine(" WHERE V.IdSucursal = {0}", idSucursal)
         If fechaDesde.HasValue And fechaHasta.HasValue Then
            .AppendFormatLine("   AND V.FechaEnvio Between '{0}' AND '{1}'", ObtenerFecha(fechaDesde.Value, False), ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         ElseIf fechaDesde.HasValue And Not fechaHasta.HasValue Then
            .AppendFormatLine("   AND V.FechaEnvio >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         ElseIf Not fechaDesde.HasValue And fechaHasta.HasValue Then
            .AppendFormatLine("   AND V.FechaEnvio <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If

         If nroRep.Length > 0 Then
            Dim strNroRep As StringBuilder = New StringBuilder()
            For Each i As Integer In nroRep
               strNroRep.AppendFormat("{0},", i)
            Next
            .AppendFormatLine("   AND V.NumeroReparto IN ({0})", strNroRep.ToString().Trim().Trim(","c))
         End If
         If Idvend > 0 Then
            .AppendFormatLine("   AND V.IdVendedor = {0}", Idvend)
         End If
         If Not dist = 0 Then
            .AppendFormatLine("	AND v.IdTransportista = {0}", dist)
         End If
         .AppendLine("  and TC.Tipo <> 'PEDIDOSCLIE'") ''v.IdTipoComprobante<>'PEDIDO' ")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ListadoDeClientes(idSucursal As Integer,
                                     fechaDesde As Date?, fechaHasta As Date?,
                                     nroRep As Integer, nroRepH As Integer,
                                     dist As Integer,
                                     Idvend As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT v.NumeroReparto, V.FechaEnvio, v.IdTransportista , T.NombreTransportista, V.IdVendedor, E.NombreEmpleado AS NombreVendedor")
         .AppendLine("     , V.Fecha, V.IdSucursal, V.IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante")
         .AppendLine("     , CALLES.NombreCalle, C.Altura, C.DireccionAdicional")
         .AppendLine("     , c.NroDocCliente, C.NombreCliente, CF.NombreCategoriaFiscalAbrev AS CF, Importetotal, V.SaldoActualCtaCte, V.Observacion as Observaciones,vFP.DescripcionFormasPago, C.CodigoCliente")
         .AppendLine("     , C.IdLocalidad, L.NombreLocalidad, V.Direccion")
         .AppendLine("     , C.Telefono + ' ' + C.Celular AS TELEFONO")
         .AppendLine("  , CASE WHEN C.HorarioCorrido = 1 THEN 'Lunes a Viernes: Horario Corrido ' + C.HoraInicio + ' a ' + C.HoraFin2 ELSE 'Lunes a Viernes: ' + C.HoraInicio + ' a ' + C.HoraFin  + ' y '  + C.HoraInicio2 + ' a ' + C.HoraFin2 END  + ")
         .AppendLine(" CASE WHEN C.HorarioCorridoSab = 1 THEN '  Sábados: Horario Corrido ' + C.HoraSabInicio + ' a ' + C.HoraSabFin2 ELSE '  Sábados: ' + C.HoraSabInicio + ' a ' + C.HoraSabFin  + ' y '  + C.HoraSabInicio2 + ' a ' + C.HoraSabFin2 END as HORARIO ")
         .AppendLine("  FROM Ventas V")
         .AppendLine(" INNER JOIN Clientes C ON C.idCliente = V.idCliente ")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .AppendLine(" INNER JOIN Transportistas T ON T.IdTransportista = v.IdTransportista")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON VFP.IdFormasPago=v.IdFormasPago")
         .AppendLine(" INNER JOIN Calles ON CALLES.IdCalle = C.IdCalle")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine(" INNER JOIN Tiposcomprobantes TC ON TC.IdTipoComprobante=v.IdTipoComprobante ")

         .AppendFormatLine(" WHERE V.IdSucursal = {0}", idSucursal)

         'and tc.AfectaCaja='True'")
         If fechaDesde.HasValue And fechaHasta.HasValue Then
            .AppendFormatLine("   AND V.Fecha Between '{0}' AND '{0}'", ObtenerFecha(fechaDesde.Value, False), ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If

         If nroRep <> 0 Then
            .AppendFormatLine("   AND V.NumeroReparto >= {0}", nroRep)
         End If
         If nroRepH <> 0 Then
            .AppendFormatLine("   AND V.NumeroReparto <= {0}", nroRepH)
         End If
         If Idvend > 0 Then
            .AppendFormatLine("   AND V.IdVendedor = {0}", Idvend)
         End If
         If dist <> 0 Then
            .AppendFormatLine("   AND V.IdTransportista = {0}", dist)
         End If
         .AppendFormatLine("   AND TC.Tipo <> 'PEDIDOSCLIE'")

         .AppendFormatLine(" ORDER BY T.NombreTransportista, E.NombreEmpleado, V.Fecha")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Sub ActualizoEstadoFactura(filtro As String, estado As String, IdTipoComprobante As String,
                                       LetraComprobante As String, CentroEmisor As Short,
                                       NumeroComprobante As Long)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE Ventas SET ")
         .AppendFormat("      idEstadoComprobante = '{0}'", estado)
         .AppendFormat("      , IdTipoComprobanteFact = '{0}'", IdTipoComprobante)
         .AppendFormat("      , LetraFact = '{0}'", LetraComprobante)
         .AppendFormat("      , CentroEmisorFact = {0}", CentroEmisor)
         .AppendFormat("      , NumeroComprobanteFact = {0}", NumeroComprobante)
         .Append(" WHERE ")
         .Append(filtro)



      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "Ventas")
   End Sub

End Class
