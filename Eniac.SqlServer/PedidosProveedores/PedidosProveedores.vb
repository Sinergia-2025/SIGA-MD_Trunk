Public Class PedidosProveedores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function PedidosProveedores_GetIdMaximo(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Integer
      Dim stb = New StringBuilder()
      With stb
         .AppendFormat("SELECT ISNULL(MAX({0}),0) AS {0}", Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).AppendLine()
         .AppendFormat("  FROM PedidosProveedores").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letraFiscal).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", emisor).AppendLine()
      End With
      Return CInt(GetDataTable(stb).Rows(0)(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()))
   End Function

   Public Sub PedidosProveedores_D(idSucursal As Integer, idTipoComprobante As String, Letra As String, centroEmisor As Integer, NumeroPedido As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormat("DELETE FROM PedidosProveedores").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", Letra)
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND NumeroPedido = {0}", NumeroPedido)
      End With
      Execute(stb)
   End Sub

   Public Sub PedidosProveedores_I(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Integer,
                                   numeroPedido As Long,
                                   fechaPedido As Date,
                                   observacion As String,
                                   idUsuario As String,
                                   descuentoRecargo As Double,
                                   descuentoRecargoPorc As Double,
                                   idProveedor As Long,
                                   idComprador As Integer,
                                   idFormaPago As Integer?,
                                   idTransportista As Integer?,
                                   cotizacionDolar As Decimal?,
                                   idTipoComprobanteFact As String,
                                   importeBruto As Decimal,
                                   subTotal As Decimal,
                                   totalImpuestos As Decimal,
                                   totalImpuestoInterno As Decimal,
                                   importeTotal As Decimal,
                                   idEstadoVisita As Integer,
                                   numeroOrdenCompra As Long,
                                   fechaAutorizacion As Date?,
                                   fechaReprogramacion As Date?,
                                   idMoneda As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO PedidosProveedores").AppendLine()
         .AppendFormat("           ({0}", Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.Letra.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.FechaPedido.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.Observacion.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.IdUsuario.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.DescuentoRecargo.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.DescuentoRecargoPorc.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.IdProveedor.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.IdComprador.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.IdFormasPago.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.IdTransportista.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.CotizacionDolar.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.IdTipoComprobanteFact.ToString()).AppendLine()

         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.ImporteBruto.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.SubTotal.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.TotalImpuestos.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.TotalImpuestoInterno.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.ImporteTotal.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.IdEstadoVisita.ToString()).AppendLine()

         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.NumeroOrdenCompra.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.FechaAutorizacion.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.FechaReprogramacion.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.PedidoProveedor.Columnas.Idmoneda.ToString()).AppendLine()

         .AppendFormat(" ) VALUES (").AppendLine()
         .AppendFormat("            {0} ", idSucursal).AppendLine()
         .AppendFormat("          ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("          ,'{0}'", letra).AppendLine()
         .AppendFormat("          , {0} ", centroEmisor).AppendLine()
         .AppendFormat("          , {0} ", numeroPedido).AppendLine()
         .AppendFormat("          ,'{0}'", Me.ObtenerFecha(fechaPedido, True)).AppendLine()
         .AppendFormat("          ,'{0}'", observacion).AppendLine()
         .AppendFormat("          ,'{0}'", idUsuario).AppendLine()
         .AppendFormat("          , {0} ", descuentoRecargo).AppendLine()
         .AppendFormat("          , {0} ", descuentoRecargoPorc).AppendLine()
         .AppendFormat("          , {0} ", idProveedor).AppendLine()

         If String.IsNullOrWhiteSpace(idComprador.ToString()) Then
            .AppendFormat("          , NULL ").AppendLine()
         Else
            .AppendFormat("          ,{0}", idComprador).AppendLine()
         End If

         If idFormaPago.HasValue Then
            .AppendFormat("          , {0} ", idFormaPago.Value).AppendLine()
         Else
            .AppendFormat("          , NULL ").AppendLine()
         End If
         If idTransportista > 0 Then
            .AppendFormat("          , {0} ", idTransportista.Value).AppendLine()
         Else
            .AppendFormat("          , NULL ").AppendLine()
         End If
         If cotizacionDolar.HasValue Then
            .AppendFormat("          , {0} ", cotizacionDolar.Value).AppendLine()
         Else
            .AppendFormat("          , NULL ").AppendLine()
         End If
         If String.IsNullOrWhiteSpace(idTipoComprobanteFact) Then
            .AppendFormat("          , NULL ").AppendLine()
         Else
            .AppendFormat("          ,'{0}'", idTipoComprobanteFact).AppendLine()
         End If

         .AppendFormat("          ,{0}", importeBruto).AppendLine()
         .AppendFormat("          ,{0}", subTotal).AppendLine()
         .AppendFormat("          ,{0}", totalImpuestos).AppendLine()
         .AppendFormat("          ,{0}", totalImpuestoInterno).AppendLine()
         .AppendFormat("          ,{0}", importeTotal).AppendLine()
         .AppendFormat("          ,{0} ", idEstadoVisita).AppendLine()

         If numeroOrdenCompra > 0 Then
            .AppendFormat("          ,{0}", numeroOrdenCompra).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If

         If fechaAutorizacion > Date.Parse("1/1/0001") Then
            .AppendFormat("          ,{0}", Me.ObtenerFecha(fechaAutorizacion, True)).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If

         If fechaReprogramacion > Date.Parse("1/1/0001") Then
            .AppendFormat("          ,{0}", Me.ObtenerFecha(fechaReprogramacion, True)).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         If idMoneda.HasValue Then
            .AppendFormat("          , {0} ", idMoneda.Value).AppendLine()
         Else
            .AppendFormat("          , NULL ").AppendLine()
         End If
         .AppendFormat(")")
      End With
      Execute(myQuery)
   End Sub

   Public Function GetPedidos(sucursales As Entidades.Sucursal(), idEstado As String,
                              fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                              idProducto As String, IdProveedor As Long,
                              marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                              rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                              ordenCompra As Long, tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(), letra As String, centroEmisor As Short,
                              orden As Integer, fechaEstado As Date?, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT '' AS Color")
         .AppendFormatLine("     , 'False' AS masivo")
         .AppendFormatLine("     , PE.IdSucursal")
         .AppendFormatLine("     , P.IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion AS DescripcionTipoComprobante")
         .AppendFormatLine("     , P.Letra")
         .AppendFormatLine("     , P.CentroEmisor")
         .AppendFormatLine("     , P.NumeroPedido")
         .AppendFormatLine("     , P.FechaPedido")
         .AppendFormatLine("     , P.IdProveedor, PV.NombreProveedor")
         .AppendFormatLine("     , PP.IdProducto, PRP.CodigoProductoProveedor, PP.NombreProducto, PP.Orden")
         .AppendFormatLine("     , PR.Tamano")
         .AppendFormatLine("     , PR.IdUnidadDeMedida")

         .AppendFormatLine("     , PS.IdDepositoDefecto, SD.CodigoDeposito CodigoDepositoDefecto, SD.NombreDeposito NombreDepositoDefecto, PS.IdUbicacionDefecto, SU.CodigoUbicacion CodigoUbicacionDefecto, SU.NombreUbicacion NombreUbicacionDefecto")

         .AppendFormatLine("     , PP.Cantidad")
         .AppendFormatLine("     , PP.CantidadUMCompra")
         .AppendFormatLine("     , PP.IdUnidadDeMedida IdUnidadDeMedidaStock")
         .AppendFormatLine("     , PP.IdUnidadDeMedidaCompra")
         .AppendFormatLine("     , UMS.NombreUnidadDeMedida NombreUnidadDeMedidaStock")
         .AppendFormatLine("     , UMC.NombreUnidadDeMedida NombreUnidadDeMedidaCompra")

         .AppendFormatLine("     , PP.ImporteTotalConImpuestos")
         .AppendFormatLine("     , PP.Costo")
         .AppendFormatLine("     , PE.FechaEstado, PE.IdEstado, EP.IdTipoEstado, EP.Color AS ColorEstado, PE.TipoEstadoPedido")
         .AppendFormatLine("     , PE.CantEstado AS CantEntregada")
         .AppendFormatLine("     , PE.IdEstadoProducto ")
         .AppendFormatLine("     , PE.IdEstadoCantidad ")
         .AppendFormatLine("     , PE.IdEstadoPrecio")
         .AppendFormatLine("     , PE.IdEstadoFechaEntrega")
         .AppendFormatLine("     , PE.FechaEstadoProducto")
         .AppendFormatLine("     , PE.FechaEstadoCantidad")
         .AppendFormatLine("     , PE.FechaEstadoPrecio")
         .AppendFormatLine("     , PE.FechaEstadoFechaEntrega")
         .AppendFormatLine("     , (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         .AppendFormatLine("     , PP.CantidadUMCompra / PP.Cantidad * (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantidadUMCompraPendiente")
         .AppendFormatLine("     , P.NumeroOrdenCompra")
         .AppendFormatLine("     , PE.IdTipoComprobanteFact, PE.LetraFact, PE.CentroEmisorFact, PE.NumeroComprobanteFact")
         .AppendFormatLine("     , PE.IdSucursalRemito,PE.IdTipoComprobanteRemito, PE.LetraRemito, PE.CentroEmisorRemito, PE.NumeroComprobanteRemito")
         .AppendFormatLine("     , PE.IdSucursalGenerado,PE.IdTipoComprobanteGenerado, PE.LetraGenerado, PE.CentroEmisorGenerado, PE.NumeroPedidoGenerado")
         .AppendFormatLine("     , PE.IdUsuario")
         .AppendFormatLine("     , PE.Observacion")
         .AppendFormatLine("     , M.NombreMarca")
         .AppendFormatLine("     , Mo.NombreModelo")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , SR.NombreSubRubro")
         .AppendFormatLine("     , SSR.NombreSubSubRubro")
         .AppendFormatLine("     , PE.IdCriticidad")
         .AppendFormatLine("     , PE.FechaEntrega")
         .AppendFormatLine("     , P.DescuentoRecargoPorc")
         .AppendFormatLine("     , CONVERT(DECIMAL(14,2), 0) AS CantidadNuevoEstado")
         .AppendFormatLine("     , CONVERT(DECIMAL(14,2), 0) AS CantidadUMCompraNuevoEstado")

         .AppendFormatLine("  FROM PedidosProveedores P")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendFormatLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("                               AND PP.Letra = P.Letra")
         .AppendFormatLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendFormatLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendFormatLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("                             AND PE.Letra = P.Letra")
         .AppendFormatLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendFormatLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendFormatLine("                             AND PE.Orden = PP.Orden")
         If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.TODOS Then
            .AppendFormatLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         Else
            .AppendFormatLine(" INNER JOIN (")
            .AppendFormatLine("             SELECT *")
            .AppendFormatLine("               FROM EstadosPedidosProveedores E")
            .AppendFormatLine("              WHERE EXISTS(")
            .AppendFormatLine("                           SELECT *")
            .AppendFormatLine("                             FROM EstadosPedidosProveedoresRoles EPR")
            .AppendFormatLine("                            INNER JOIN UsuariosRoles UR ON UR.IdRol = EPR.IdRol")
            .AppendFormatLine("                            WHERE UR.IdSucursal = {0}", actual.Sucursal.Id)
            .AppendFormatLine("                              AND UR.IdUsuario = '{0}'", actual.Nombre)
            .AppendFormatLine("                              AND EPR.TipoEstadoPedido = E.TipoEstadoPedido AND EPR.IdEstado = E.IdEstado)")
            .AppendFormatLine("            ) EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         End If
         .AppendFormatLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendFormatLine(" INNER JOIN Productos PR ON PR.IdProducto = PE.IdProducto")
         .AppendFormatLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PE.IdProducto AND PS.IdSucursal = PP.IdSucursal")
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = PS.IdSucursal AND SD.IdDeposito = PS.IdDepositoDefecto")
         .AppendFormatLine(" INNER JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PS.IdSucursal AND SU.IdDeposito = PS.IdDepositoDefecto AND SU.IdUbicacion = PS.IdUbicacionDefecto")

         .AppendFormatLine("  LEFT JOIN UnidadesDeMedidas UMS ON UMS.IdUnidadDeMedida = PP.IdUnidadDeMedida")
         .AppendFormatLine("  LEFT JOIN UnidadesDeMedidas UMC ON UMC.IdUnidadDeMedida = PP.IdUnidadDeMedidaCompra")

         .AppendFormatLine("  LEFT JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendFormatLine("  LEFT JOIN Modelos Mo ON Mo.IdModelo = PR.IdModelo")
         .AppendFormatLine("  LEFT JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = PR.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = PR.IdSubSubRubro")
         .AppendFormatLine("  LEFT JOIN ProductosProveedores PRP ON PRP.IdProducto = PE.IdProducto AND PRP.IdProveedor =PR.IdProveedor")
         .AppendFormatLine(" WHERE TC.Tipo = '{0}'", tipoTipoComprobante)

         GetListaSucursalesMultiples(stbQuery, sucursales, "P")
         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If idEstado = "SOLO PENDIENTES" Then
            .AppendFormatLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf idEstado = "SOLO EN PROCESO" Then
            .AppendFormatLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf idEstado <> "TODOS" Then
            .AppendFormatLine("   AND PE.IdEstado = '{0}'", idEstado)
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendFormatLine("   AND P.FechaPedido >= '{0}'", ObtenerFecha(fechaDesde, True))
            .AppendFormatLine("   AND P.FechaPedido <= '{0}'", ObtenerFecha(fechaHasta, True))
         End If

         If numeroPedido > 0 Then
            .AppendFormatLine("   AND p.NumeroPedido = {0}", numeroPedido)
         End If

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND p.Letra = '{0}'", letra)
         End If

         If centroEmisor > 0 Then
            .AppendFormatLine("   AND p.CentroEmisor = {0}", centroEmisor)
         End If

         If orden > 0 Then
            .AppendFormatLine("   AND PE.Orden = {0}", orden)
         End If

         If fechaEstado.HasValue Then
            .AppendFormatLine("   AND PE.FechaEstado = '{0}'", ObtenerFecha(fechaEstado.Value, True))
         End If

         If IdProveedor > 0 Then
            .AppendFormatLine("   AND P.IdProveedor = {0}", IdProveedor)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND pp.IdProducto = '{0}'", idProducto)
         End If

         GetListaMarcasMultiples(stbQuery, marcas, "Pr")
         GetListaModelosMultiples(stbQuery, modelos, "Pr")
         GetListaRubrosMultiples(stbQuery, rubros, "Pr")
         GetListaSubRubrosMultiples(stbQuery, subRubros, "Pr")
         GetListaSubSubRubrosMultiples(stbQuery, subSubRubros, "Pr")

         If ordenCompra > 0 Then
            .AppendFormatLine("   AND P.NumeroOrdenCompra = {0}", ordenCompra)
         End If

         .AppendFormatLine(" ORDER BY p.FechaPedido")

      End With

      Return GetDataTable(stbQuery)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT P.* ")
         .AppendLine("      ,PV.CodigoProveedor")
         .AppendLine("  FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
      End With
   End Sub

   Public Function PedidosProveedores_GA(IdSucursal As Integer, drPedidosCol As DataRow()) As DataTable
      Return PedidosProveedores_GA(IdSucursal, 0, drPedidosCol)
   End Function
   Public Function PedidosProveedores_GA(IdSucursal As Integer, numeroOrdenCompra As Long, drPedidosCol As DataRow()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE P.IdSucursal = {0}", IdSucursal).AppendLine()
         If numeroOrdenCompra > 0 Then
            .AppendFormat("   AND P.NumeroOrdenCompra = {0}", numeroOrdenCompra)
         End If
         If drPedidosCol IsNot Nothing AndAlso drPedidosCol.Length > 0 Then
            .Append("AND (")
            Dim primero As Boolean = True
            For Each drPedido As DataRow In drPedidosCol
               If primero Then
                  primero = False
               Else
                  .AppendFormat(" OR ").AppendLine()
               End If
               .AppendFormat("(P.IdSucursal = {0} AND P.IdTipoComprobante = '{1}' AND P.Letra = '{2}' AND P.CentroEmisor = {3} AND P.NumeroPedido = {4})",
                             drPedido("IdSucursal"), drPedido("IdTipoComprobante"), drPedido("Letra"), drPedido("CentroEmisor"), drPedido("NumeroPedido"))
            Next
            .AppendLine(")")
         End If

         .AppendLine("  ORDER BY P.IdSucursal, P.IdTipoComprobante, P.Letra, P.CentroEmisor, P.NumeroPedido")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function PedidosProveedores_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE P.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND P.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND P.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND P.NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendLine("  ORDER BY P.IdSucursal, P.IdTipoComprobante, P.Letra, P.CentroEmisor, P.NumeroPedido")
      End With
      Return GetDataTable(stb)
   End Function

#Region "reporte"

   Public Function GetPedidosDetalleComprobante(idSucursal As Integer, idEstado As String,
                                                fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                                                idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                                idProveedor As Long, idUsuario As String, tamanio As Decimal, idVendedor As Integer, ordenCompra As Long,
                                                tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdSucursal ")
         .AppendLine(" ,P.IdTipoComprobante AS IdTipoComprobanteP")
         .AppendLine(" ,P.Letra AS LetraP")
         .AppendLine(" ,P.CentroEmisor AS CentroEmisorP")
         .AppendLine(" ,P.NumeroPedido")
         .AppendLine(" ,PE.IdProducto")
         .AppendLine(" ,PE.FechaEstado")
         .AppendLine(" ,PE.Orden")

         .AppendLine("	,V.IdTipoComprobante,")
         .AppendLine("	V.Letra,")
         .AppendLine("	V.CentroEmisor,")
         .AppendLine("	V.NumeroComprobante,")
         .AppendLine("	V.Fecha,")
         .AppendLine("	V.IdProveedor,")
         .AppendLine("	V.IdComprador,")
         .AppendLine("	V.IdCategoriaFiscal,")
         .AppendLine("	V.IdFormasPago,")
         .AppendLine("	V.Observacion,")
         .AppendLine("	I.IdImpresora,")
         .AppendLine("	I.TipoImpresora,")
         .AppendLine("	V.TotalBruto AS ImporteBruto,")
         .AppendLine("	V.DescuentoRecargo,")
         .AppendLine("	V.DescuentoRecargoPorc,")
         .AppendLine("	V.TotalNeto AS SubTotal,")
         .AppendLine("	V.TotalIVA AS TotalImpuestos,")
         .AppendLine("	V.ImporteTotal,")
         .AppendLine("	V.IdEstadoComprobante,")
         .AppendLine("	V.IdTipoComprobanteFact,")
         .AppendLine("	V.LetraFact,")
         .AppendLine("	V.CentroEmisorFact,")
         .AppendLine("	V.NumeroComprobanteFact,")
         '.AppendLine("	V.IdCaja,")
         '.AppendLine("	V.NumeroPlanilla,")
         '.AppendLine("	V.NumeroMovimiento,")
         .AppendLine("	V.ImportePesos,")
         '.AppendLine("	V.ImporteTickets,")
         .AppendLine("	V.ImporteTarjetas,")
         .AppendLine("	V.ImporteCheques,")
         .AppendLine("	V.Bultos,")
         .AppendLine("	V.ValorDeclarado,")
         .AppendLine("	V.IdTransportista,")
         .AppendLine("	V.NumeroLote,")
         '.AppendLine("	V.CAE,")
         '.AppendLine("	V.CAEVencimiento,")
         '.AppendLine("	V.Utilidad,")
         '.AppendLine("	V.FechaTransmisionAFIP,")
         .AppendLine("	V.CotizacionDolar")
         '.AppendLine("  V.IdPeriodo")

         .AppendLine(" FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine("  LEFT JOIN Compras V ON (V.IdSucursal = PE.IdSucursal")
         .AppendLine("                      AND V.IdProveedor = PE.IdProveedor")
         .AppendLine("                      AND V.IdTipoComprobante = PE.IdTipoComprobanteFact")
         .AppendLine("                      AND V.Letra = PE.LetraFact")
         .AppendLine("                      AND V.CentroEmisor = PE.CentroEmisorFact")
         .AppendLine("                      AND V.NumeroComprobante = PE.NumeroComprobanteFact) OR")
         .AppendLine("                         (V.IdSucursal = PE.IdSucursalRemito")
         .AppendLine("                      AND V.IdProveedor = PE.IdProveedor")
         .AppendLine("                      AND V.IdTipoComprobante = PE.IdTipoComprobanteRemito")
         .AppendLine("                      AND V.Letra = PE.LetraRemito")
         .AppendLine("                      AND V.CentroEmisor = PE.CentroEmisorRemito")
         .AppendLine("                      AND V.NumeroComprobante = PE.NumeroComprobanteRemito)")
         .AppendLine("  LEFT JOIN Impresoras I ON I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")

         .AppendLine(" WHERE p.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()
         GetListaTiposComprobantesMultiples(stb, tiposComprobante, "P")

         .AppendLine("   AND (V.NumeroComprobante IS NOT NULL)")

         If idEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf idEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf idEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & idEstado.ToString() & "'")
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaPedido >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaPedido <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroPedido > 0 Then
            .AppendLine("   AND p.NumeroPedido = " & numeroPedido.ToString())
         End If

         If idProveedor > 0 Then
            .AppendLine("   and PV.IdProveedor = " & idProveedor.ToString())
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & idUsuario & "'")
         End If

         If idVendedor > 0 Then
            .AppendLine("   and P.IdComprador = " & idVendedor.ToString()) ''COD'
         End If

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPedidosDetalleComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long, idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdSucursal, ")
         .AppendLine("	V.IdTipoComprobante,")
         .AppendLine("	V.Letra,")
         .AppendLine("	V.CentroEmisor,")
         .AppendLine("	V.NumeroComprobante,")
         .AppendLine("	V.Fecha,")
         .AppendLine("	V.IdProveedor,")
         .AppendLine("	V.IdVendedor,")
         .AppendLine("	V.IdCategoriaFiscal,")
         .AppendLine("	V.IdFormasPago,")
         .AppendLine("	V.Observacion,")
         .AppendLine("	I.IdImpresora,")
         .AppendLine("	I.TipoImpresora,")
         .AppendLine("	V.ImporteBruto,")
         .AppendLine("	V.DescuentoRecargo,")
         .AppendLine("	V.DescuentoRecargoPorc,")
         .AppendLine("	V.SubTotal,")
         .AppendLine("	V.TotalImpuestos,")
         .AppendLine("	V.ImporteTotal,")
         .AppendLine("	V.IdEstadoComprobante,")
         .AppendLine("	V.IdTipoComprobanteFact,")
         .AppendLine("	V.LetraFact,")
         .AppendLine("	V.CentroEmisorFact,")
         .AppendLine("	V.NumeroComprobanteFact,")
         .AppendLine("	V.IdCaja,")
         .AppendLine("	V.NumeroPlanilla,")
         .AppendLine("	V.NumeroMovimiento,")
         .AppendLine("	V.ImportePesos,")
         .AppendLine("	V.ImporteTickets,")
         .AppendLine("	V.ImporteTarjetas,")
         .AppendLine("	V.ImporteCheques,")
         .AppendLine("	V.Bultos,")
         .AppendLine("	V.ValorDeclarado,")
         .AppendLine("	V.IdTransportista,")
         .AppendLine("	V.NumeroLote,")
         .AppendLine("	V.CAE,")
         .AppendLine("	V.CAEVencimiento,")
         .AppendLine("	V.Utilidad,")
         .AppendLine("	V.FechaTransmisionAFIP,")
         .AppendLine("	V.CotizacionDolar")
         '.AppendLine("  V.IdPeriodo")

         .AppendLine(" FROM Compras V, Impresoras I")

         .AppendLine(" WHERE I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")

         .AppendLine("   AND V.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND V.IdProveedor = '" & idProveedor & "'")
         .AppendLine("   AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND V.Letra = '" & letra & "'")
         .AppendLine("   AND V.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND V.NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetPedidosxComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long, idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido ")
         .AppendLine(" FROM PedidosEstadosProveedores ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND V.IdProveedor = '" & idProveedor & "'")
         .AppendLine("   AND IdTipoComprobanteFact = '" & idTipoComprobante & "'")
         .AppendLine("   AND LetraFact = '" & letra & "'")
         .AppendLine("   AND CentroEmisorFact = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobanteFact = " & numeroComprobante.ToString())
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPedidosDetalladoXEstadosTodos(idSucursal As Integer, idEstado As String,
                                                    fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                                                    idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                                    idProveedor As Long, idUsuario As String, tamanio As Decimal, idVendedor As Integer, ordenCompra As Long,
                                                    tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante()) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT P.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroPedido")
         .AppendLine("     , P.FechaPedido")
         .AppendLine("     , P.IdProveedor")
         .AppendLine("     , PV.NombreProveedor")
         .AppendLine("     , PP.idProducto")
         .AppendLine("     , PP.NombreProducto")
         .AppendLine("     , PR.Tamano")
         .AppendLine("     , PP.IdUnidadDeMedida")
         .AppendLine("     , PP.IdUnidadDeMedidaCompra
	                        , PP.CantidadUMCompra")
         .AppendLine("     , PP.Orden")
         .AppendLine("     , PP.Cantidad")

         .AppendLine("     , PP.Costo")
         .AppendLine("     , PP.CostoLista")
         .AppendLine("     , PP.CostoNeto")
         .AppendLine("     , PP.DescuentoRecargoPorc")
         .AppendLine("     , PP.DescuentoRecargoPorc2")
         .AppendLine("     , PP.DescuentoRecargoProducto")
         .AppendLine("     , PP.DescRecGeneral")
         .AppendLine("     , PP.DescRecGeneralProducto")
         .AppendLine("     , PP.AlicuotaImpuesto")
         .AppendLine("     , PP.ImporteImpuesto")
         .AppendLine("     , PP.ImpuestoInterno")
         .AppendLine("     , PP.ImporteImpuestoInterno")
         .AppendLine("     , PP.PorcImpuestoInterno")

         .AppendLine("     , PE.fechaEstado")
         .AppendLine("     , PE.IdEstado")
         .AppendLine("     , PE.TipoEstadoPedido")
         .AppendLine("     , EP.IdTipoEstado")
         .AppendLine("     , EP.Color")
         .AppendLine("     , (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         '.AppendLine("     , PE.CantEstado AS CantEntregada")
         .AppendLine("     , PE.CantEstado")
         .AppendLine("     , PE.IdTipoComprobanteFact")
         .AppendLine("     , PE.LetraFact")
         .AppendLine("     , PE.CentroEmisorFact")
         .AppendLine("     , PE.NumeroComprobanteFact")
         .AppendLine("     , PE.IdUsuario")
         .AppendLine("     , PE.observacion")
         .AppendLine("     , PE.IdCriticidad")
         .AppendLine("     , PE.FechaEntrega")

         .AppendLine("     , PE.IdSucursalRemito")
         .AppendLine("     , PE.IdTipoComprobanteRemito")
         .AppendLine("     , PE.LetraRemito")
         .AppendLine("     , PE.CentroEmisorRemito")
         .AppendLine("     , PE.NumeroComprobanteRemito")

         .AppendLine("     , PE.IdEstadoProducto")
         .AppendLine("     , PE.IdEstadoCantidad")
         .AppendLine("     , PE.IdEstadoPrecio")
         .AppendLine("     , PE.IdEstadoFechaEntrega")
         .AppendLine("     , PE.FechaEstadoProducto")
         .AppendLine("     , PE.FechaEstadoCantidad")
         .AppendLine("     , PE.FechaEstadoPrecio")
         .AppendLine("     , PE.FechaEstadoFechaEntrega")

         .AppendLine(" FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine("   LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If idEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf idEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf idEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & idEstado.ToString() & "'")
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaPedido >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaPedido <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroPedido > 0 Then
            .AppendLine("   AND p.NumeroPedido = " & numeroPedido.ToString())
         End If

         If idProveedor > 0 Then
            .AppendLine("   and PV.IdProveedor = " & idProveedor.ToString())
         End If


         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & idUsuario & "'")
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idVendedor > 0 Then
            .AppendLine("   and P.IdComprador = " & idVendedor.ToString())
         End If


         .AppendLine(" ORDER BY p.fechaPedido")

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetOCDetalladoXEstadosTodos(idSucursal As Integer, idEstado As String,
                                               fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                                               idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                               idProveedor As Long, idUsuario As String, tamanio As Decimal, idVendedor As Integer, ordenCompra As Long,
                                               tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(),
                                               fechaDesdeEntrega As Date, fechaHastaEntrega As Date,
                                               importeMinimo As Decimal, importeMaximo As Decimal,
                                               fechaDesdeAutorizacion As Date, fechaHastaAutorizacion As Date) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT case when EXISTS(SELECT * FROM CalidadOCActivaciones COC
                        WHERE COC.IdSucursal = PP.IdSucursal
                        AND COC.IdTipoComprobante = PP.IdTipoComprobante
                        AND COC.Letra = PP.Letra
                        AND COC.CentroEmisor = PP.CentroEmisor
                        AND COC.NumeroPedido = PP.NumeroPedido
						AND COC.Orden = PP.Orden
						) then 'True' else 'False'  END as acti 
                  ,P.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroPedido")
         .AppendLine("     , P.FechaPedido")
         .AppendLine("     , P.IdProveedor")
         .AppendLine("     , PV.NombreProveedor")
         .AppendLine("     , PP.idProducto")
         .AppendLine("     , PP.NombreProducto")
         .AppendLine("     , PR.Tamano")
         .AppendLine("     , PP.IdUnidadDeMedida")
         .AppendLine("     , PP.Orden")
         .AppendLine("     , PP.Cantidad")
         .AppendLine("     , PP.Costo")
         .AppendLine("     , PP.CostoConImpuestos")
         .AppendLine("     , PE.fechaEstado")
         .AppendLine("     , PE.IdEstado")
         .AppendLine("     , PE.TipoEstadoPedido")
         .AppendLine("     , EP.IdTipoEstado")
         .AppendLine("     , EP.Color")
         .AppendLine("     , (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         '.AppendLine("     , PE.CantEstado AS CantEntregada")
         .AppendLine("     , PE.CantEstado")
         .AppendLine("     , PE.IdTipoComprobanteFact")
         .AppendLine("     , PE.LetraFact")
         .AppendLine("     , PE.CentroEmisorFact")
         .AppendLine("     , PE.NumeroComprobanteFact")
         .AppendLine("     , PE.IdUsuario")
         .AppendLine("     , PE.observacion")
         .AppendLine("     , PE.IdCriticidad")
         .AppendLine("     , PE.FechaEntrega")

         .AppendLine("     , PE.IdSucursalRemito")
         .AppendLine("     , PE.IdTipoComprobanteRemito")
         .AppendLine("     , PE.LetraRemito")
         .AppendLine("     , PE.CentroEmisorRemito")
         .AppendLine("     , PE.NumeroComprobanteRemito")

         .AppendLine("     , PE.IdEstadoProducto")
         .AppendLine("     , PE.IdEstadoCantidad")
         .AppendLine("     , PE.IdEstadoPrecio")
         .AppendLine("     , PE.IdEstadoFechaEntrega")
         .AppendLine("     , PE.FechaEstadoProducto")
         .AppendLine("     , PE.FechaEstadoCantidad")
         .AppendLine("     , PE.FechaEstadoPrecio")
         .AppendLine("     , PE.FechaEstadoFechaEntrega")

         .AppendLine(" FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine("   LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If idEstado = "PENDIENTE/EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf idEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf idEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & idEstado.ToString() & "'")
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaPedido >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaPedido <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         End If

         If fechaDesdeEntrega > Date.Parse("01/01/1990") Then
            .AppendLine("   AND PE.FechaEntrega >= '" & fechaDesdeEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND PE.FechaEntrega <= '" & fechaHastaEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If fechaDesdeAutorizacion > Date.Parse("01/01/1990") Then
            .AppendLine("   AND P.FechaAutorizacion >= '" & fechaDesdeAutorizacion.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND P.FechaAutorizacion <= '" & fechaHastaAutorizacion.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroPedido > 0 Then
            .AppendLine("   AND p.NumeroPedido = " & numeroPedido.ToString())
         End If

         If idProveedor > 0 Then
            .AppendLine("   and PV.IdProveedor = " & idProveedor.ToString())
         End If


         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & idUsuario & "'")
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("    and PP.IdProducto = '" & idProducto & "'")
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idVendedor > 0 Then
            .AppendLine("   and P.IdComprador = " & idVendedor.ToString())
         End If

         If importeMinimo > 0 Then
            .AppendLine("   AND P.ImporteTotal >= " & importeMinimo)
         End If

         If importeMaximo > 0 Then
            .AppendLine("   AND P.ImporteTotal <= " & importeMaximo)
         End If

         .AppendLine(" ORDER BY PP.Orden")

      End With
      Return GetDataTable(stbQuery)
   End Function


   Public Function GetPedidosDetalladoXEstados(idSucursal As Integer, idEstado As String,
                                               fechaDesde As Date?, fechaHasta As Date?, fechaDesdeEntrega As Date?, fechaHastaEntrega As Date?, numeroPedido As Long,
                                               idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                               idProveedor As Long, idIdUsuario As String, idVendedor As Integer, ordenCompra As Long,
                                               tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante()) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine("      ,TC.DescripcionAbrev IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.NumeroOrdenCompra")
         .AppendLine("      ,P.IdProveedor, PV.CodigoProveedor, PV.NombreProveedor")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano AS TamanoProducto, PP.IdUnidadDeMedida , pp.Orden, PS.Ubicacion,")
         .AppendLine("       PP.FactorConversionCompra,
                             UNS.NombreUnidadDeMedida NombreUnidadDeMedida,
                             PP.IdUnidadDeMedidaCompra,
                             UNC.NombreUnidadDeMedida NombreUnidadDeMedidaCompra,
                             PP.CantidadUMCompra")
         .AppendLine("      ,pp.Cantidad AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      ,PE.CantEstado AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdSucursalGenerado, pe.IdTipoComprobanteGenerado, pe.LetraGenerado, pe.CentroEmisorGenerado, pe.NumeroPedidoGenerado")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")

         '.AppendLine("      ,PP.PrecioVentaPorTamano")
         '.AppendLine("      ,PP.Tamano")
         '.AppendLine("      ,CONVERT(DECIMAL(9,2), PP.Tamano * PP.Cantidad) TamanoTotal")
         '.AppendLine("      ,PP.IdUnidadDeMedida")
         '.AppendLine("      ,PP.IdMoneda")
         '.AppendLine("      ,MO.NombreMoneda")
         '.AppendLine("      ,MO.Simbolo")
         '.AppendLine("      ,PP.IdProduccionProceso")
         '.AppendLine("      ,PRP.NombreProduccionProceso")
         '.AppendLine("      ,PP.IdProduccionForma")
         '.AppendLine("      ,PRF.NombreProduccionForma")
         '.AppendLine("      ,PP.Espmm")
         '.AppendLine("      ,PP.EspPulgadas")
         '.AppendLine("      ,PP.CodigoSAE")
         '.AppendLine("      ,PP.LargoExtAlto")
         '.AppendLine("      ,PP.AnchoIntBase")
         '.AppendLine("      ,PP.UrlPlano")

         .AppendLine(" FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")

         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = TC.Tipo")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         '.AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = PP.IdProduccionForma")
         '.AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = PP.IdProduccionProceso")
         '.AppendLine(" LEFT JOIN Monedas MO ON MO.IdMoneda = PP.IdMoneda")
         .AppendLine(" LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         .AppendLine("  LEFT JOIN UnidadesDeMedidas UNS ON UNS.IdUnidadDeMedida = PP.IdUnidadDeMedida
                        LEFT JOIN UnidadesDeMedidas UNC ON UNC.IdUnidadDeMedida = PP.IdUnidadDeMedidaCompra")

         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If idEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf idEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf idEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & idEstado.ToString() & "'")
         End If

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND p.FechaPedido >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
            .AppendFormatLine("   AND p.FechaPedido <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         If fechaDesdeEntrega.HasValue Then
            .AppendFormatLine("   AND p.FechaPedido >= '{0}'", ObtenerFecha(fechaDesdeEntrega.Value, True))
            .AppendFormatLine("   AND p.FechaPedido <= '{0}'", ObtenerFecha(fechaHastaEntrega.Value, True))
         End If


         If numeroPedido > 0 Then
            .AppendLine("   AND P.NumeroPedido = " & numeroPedido.ToString())
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & idProducto & "'")
         End If

         If idMarca > 0 Then
            .AppendLine("    and pr.IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("    and pr.IdRubro = " & idRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(lote) Then
            .AppendLine("    and pr.Lote = " & lote.ToString())
         End If

         If idProveedor > 0 Then
            .AppendLine("   and P.IdProveedor = " & idProveedor) ''1'
         End If

         If Not String.IsNullOrEmpty(idIdUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & idIdUsuario & "'")
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idVendedor > 0 Then
            .AppendLine("   and P.IdComprador = " & idVendedor.ToString())
         End If

         .AppendLine(" ORDER BY p.fechaPedido")

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidosEstadosProductos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long, idProducto As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine(" ,P.IdTipoComprobante")
         .AppendLine(" ,P.Letra")
         .AppendLine(" ,P.CentroEmisor")
         .AppendLine(" ,P.NumeroPedido")
         .AppendLine(" ,P.FechaPedido")
         .AppendLine("      ,P.IdProveedor, PV.CodigoProveedor, PV.NombreProveedor")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano, Pr.IdUnidadDeMedida, pp.Orden")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE ")
         .AppendLine(" (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE PE.CantEntregada END) END) AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")
         .AppendLine(" FROM PedidosProveedores P")

         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND P.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND P.Letra = '" & letra & "'")
         .AppendLine("   AND P.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND P.NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND PE.IdProducto = '" & idProducto & "'")
         .AppendLine(" ORDER BY p.fechaPedido")

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function pedidosCabecera(idSucursal As Integer, idEstado As String,
                                   fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                                   idProveedor As Long, idIdUsuario As String, idVendedor As Integer, ordenCompra As Long,
                                   tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(), letra As String, emisor As Short) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT 'FALSE' as anula")
         .AppendLine("     , p.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , TC.DescripcionAbrev")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroPedido")
         .AppendLine("     , P.IdProveedor")
         .AppendLine("     , PV.CodigoProveedor")
         .AppendLine("     , PV.NombreProveedor")
         .AppendLine("     , p.FechaPedido")
         .AppendLine("     , p.IdUsuario")
         .AppendLine("     , p.Observacion")
         .AppendLine("     , p.NumeroOrdenCompra")
         .AppendLine("     , p.ImporteTotal")

         .AppendLine("     , p.ImporteBruto")
         .AppendLine("     , p.SubTotal")
         .AppendLine("     , p.TotalImpuestos")
         .AppendLine("     , p.TotalImpuestoInterno")

         .AppendLine("     , CONVERT(decimal(9,2), ")
         .AppendLine("               (SELECT CASE WHEN SUM(PP.Cantidad) = 0 THEN 0 ELSE SUM(PP.CantPendiente + PP.CantEnProceso) / SUM(PP.Cantidad) END")
         .AppendLine("          FROM PedidosProductosProveedores PP")
         .AppendLine("         WHERE PP.IdSucursal = P.IdSucursal")
         .AppendLine("           AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("           AND PP.Letra = P.Letra")
         .AppendLine("           AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("           AND PP.NumeroPedido = P.NumeroPedido) * 100) AS PorcPendiente")

         .AppendLine("       , CONVERT(decimal(9,2), 
               (SELECT CASE WHEN SUM(PP.Cantidad) = 0 THEN 0 ELSE CASE WHEN P.ImporteTotal = 0 THEN 0 ELSE 1 - (SUM(PP.Costo * PP.CantEnProceso) / P.ImporteTotal) END END
		     FROM PedidosProductosProveedores PP
           WHERE PP.IdSucursal = P.IdSucursal
           AND PP.IdTipoComprobante = P.IdTipoComprobante
           AND PP.Letra = P.Letra
           AND PP.CentroEmisor = P.CentroEmisor
           AND PP.NumeroPedido = P.NumeroPedido) * 100) AS PorcPendienteImporte")
         ''.AppendLine("     , (CantEntregada + CantAnulada) / Cantidad")
         '' ''.AppendLine(" ,(SELECT COUNT(PCC.IdSucursal) FROM PedidosClientesContactos PCC WHERE P.IdSucursal = PCC.IdSucursal AND P.NumeroPedido = PCC.NumeroPedido")
         '' ''.AppendLine(" AND P.IdTipoComprobante = PCC.IdTipoComprobante AND P.Letra = PCC.Letra")
         '' ''.AppendLine(" 	AND P.CentroEmisor = PCC.CentroEmisor) AS CantidadContactos")
         .AppendLine(" FROM PedidosProveedores P")

         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")

         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()
         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If idEstado <> "TODOS" Then
            .AppendLine("   AND EXISTS(SELECT * FROM PedidosEstadosProveedores PE")
            .AppendLine("                      INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado")
            .AppendLine("                      WHERE PE.IdSucursal = P.IdSucursal")
            .AppendLine("                        AND PE.IdTipoComprobante = P.IdTipoComprobante")
            .AppendLine("                        AND PE.Letra = P.Letra")
            .AppendLine("                        AND PE.CentroEmisor = P.CentroEmisor")
            .AppendLine("                        AND PE.NumeroPedido = P.NumeroPedido")

            If idEstado = "SOLO PENDIENTES" Then
               .AppendLine("                        AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO'))")
            ElseIf idEstado = "SOLO EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado = 'EN PROCESO')")
            Else
               .AppendFormat("                        AND EP.IdEstado = '{0}')", idEstado).AppendLine()
            End If
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND P.FechaPedido >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND P.FechaPedido <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroPedido > 0 Then
            .AppendLine("   AND P.NumeroPedido = " & numeroPedido.ToString())
         End If

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND P.Letra = '{0}'", letra)
         End If

         If emisor > 0 Then
            .AppendFormat("   AND P.CentroEmisor = {0}", emisor)
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idProveedor <> 0 Then
            .AppendLine("   and P.IdProveedor = " & idProveedor.ToString())
         End If

         If Not String.IsNullOrEmpty(idIdUsuario) Then
            .AppendLine("    and P.IdUsuario = '" & idIdUsuario & "'")
         End If

         If idVendedor > 0 Then
            .AppendLine("   and P.IdComprador = " & idVendedor.ToString())
         End If

         .AppendLine(" ORDER BY P.fechaPedido")

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function OCCabecera(idSucursal As Integer, idEstado As String,
                              fechaDesde As Date, fechaHasta As Date, numeroPedido As Long, nroHasta As Long,
                              idProveedor As Long, idIdUsuario As String, idVendedor As Integer, ordenCompra As Long,
                              tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(), letra As String, emisor As Short,
                              fechaDesdeEntrega As Date, fechaHastaEntrega As Date,
                              importeMinimo As Decimal, importeMaximo As Decimal,
                              fechaDesdeAutorizacion As Date, fechaHastaAutorizacion As Date,
                              correoEnviado As String,
                              fechaDesdeEnvio As Date, fechaHastaEnvio As Date,
                              verReprogramadas As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT case when EXISTS(SELECT * FROM CalidadOCActivaciones COC
                        WHERE COC.IdSucursal = P.IdSucursal
                        AND COC.IdTipoComprobante = P.IdTipoComprobante
                        AND COC.Letra = P.Letra
                        AND COC.CentroEmisor = P.CentroEmisor
                        AND COC.NumeroPedido = P.NumeroPedido ) then 1 else 0  END as acti")
         .AppendLine("     , 'False' as Envio")
         .AppendLine("     , p.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , TC.DescripcionAbrev")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroPedido")
         .AppendLine("     , P.IdProveedor")
         .AppendLine("     , PV.CodigoProveedorLetras AS CodigoProveedor")
         .AppendLine("     , PV.NombreProveedor")
         .AppendLine("     , PV.TelefonoProveedor")
         ' .AppendLine("     , PV.CorreoElectronico + ' ; ' + PV.CorreoAdministrativo AS CorreoElectronico ")
         .AppendLine("     ,PV.CorreoElectronico")
         .AppendLine("     , p.FechaPedido")
         .AppendLine("     , p.IdUsuario")
         .AppendLine("     , p.Observacion")
         .AppendLine("     , p.NumeroOrdenCompra")
         .AppendLine("     , P.TotalImpuestos")
         .AppendLine("     , P.ImporteBruto")
         .AppendLine("     , p.ImporteTotal")
         .AppendLine("     , P.FechaAutorizacion")
         .AppendLine("     , P.FechaReprogramacion")

         .AppendLine("     , (SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido
           ORDER BY CE.FechaEnvio DESC) as FechaEnvio")
         .AppendLine(" , (SELECT TOP 1 CE.MetodoGrabacion	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido
           ORDER BY CE.FechaEnvio DESC) as Metodo")
         .AppendLine("  , (SELECT TOP 1 CE.FechaReprogramacion	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido
           ORDER BY CE.FechaEnvio DESC) as FechaReprogEnvio")
         .AppendLine("     , ( SELECT TOP 1 PP.FechaEntrega	FROM PedidosEstadosProveedores PP
           WHERE PP.IdSucursal = P.IdSucursal
           AND PP.IdTipoComprobante = P.IdTipoComprobante
           AND PP.Letra = P.Letra
           AND PP.CentroEmisor = P.CentroEmisor
           AND PP.NumeroPedido = P.NumeroPedido
            ORDER BY PP.Orden ) as FechaEntrega")
         .AppendLine("     , ( SELECT TOP 1 CA.FechaReprogEntrega	FROM CalidadOCActivaciones CA
           WHERE CA.IdSucursal = P.IdSucursal
           AND CA.IdTipoComprobante = P.IdTipoComprobante
           AND CA.Letra = P.Letra
           AND CA.CentroEmisor = P.CentroEmisor
           AND CA.NumeroPedido = P.NumeroPedido
		     AND CA.Orden = 0 ORDER BY CA.FechaActivacion DESC) as FechaReprogEntrega")
         .AppendLine("     , CONVERT(decimal(9,2), ")
         .AppendLine("               (SELECT CASE WHEN SUM(PP.Cantidad) = 0 THEN 0 ELSE SUM(PP.CantPendiente + PP.CantEnProceso) / SUM(PP.Cantidad) END")
         .AppendLine("          FROM PedidosProductosProveedores PP")
         .AppendLine("         WHERE PP.IdSucursal = P.IdSucursal")
         .AppendLine("           AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("           AND PP.Letra = P.Letra")
         .AppendLine("           AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("           AND PP.NumeroPedido = P.NumeroPedido) * 100) AS PorcPendiente")

         '  .AppendLine("       , CONVERT(decimal(9,2), 
         '        (SELECT CASE WHEN SUM(PP.CantEnProceso) = 0 THEN 0 ELSE CASE WHEN P.ImporteTotal = 0 THEN 0 ELSE (SUM(PP.Costo * PP.CantEnProceso) / P.ImporteTotal) END END
         'FROM PedidosProductosProveedores PP
         '    WHERE PP.IdSucursal = P.IdSucursal
         '    AND PP.IdTipoComprobante = P.IdTipoComprobante
         '    AND PP.Letra = P.Letra
         '    AND PP.CentroEmisor = P.CentroEmisor
         '    AND PP.NumeroPedido = P.NumeroPedido) * 100) AS PorcPendienteImporte")

         .AppendFormatLine("   , case when EXISTS(SELECT * FROM PedidosEstadosProveedores PE
                      INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado
                      WHERE PE.IdSucursal = P.IdSucursal
                        AND PE.IdTipoComprobante = P.IdTipoComprobante
                        AND PE.Letra = P.Letra
                        AND PE.CentroEmisor = P.CentroEmisor
                        AND PE.NumeroPedido = P.NumeroPedido
                        AND (EP.IdEstado = 'CANCELADO' OR EP.IdEstado = 'ANULADO' )) then 0 else CONVERT(decimal(9,2), 
               ( SELECT CASE WHEN SUM(PP.CantEnProceso) = 0 THEN 0 ELSE CASE WHEN P.ImporteTotal = 0 THEN 0 ELSE (SUM(PP.CostoConImpuestos * PP.CantEnProceso) / P.ImporteTotal) END END
		     FROM PedidosProductosProveedores PP
           WHERE PP.IdSucursal = P.IdSucursal
           AND PP.IdTipoComprobante = P.IdTipoComprobante
           AND PP.Letra = P.Letra
           AND PP.CentroEmisor = P.CentroEmisor
           AND PP.NumeroPedido = P.NumeroPedido) * 100) END AS PorcPendienteImporte ")

         .AppendLine(" FROM PedidosProveedores P")

         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")

         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()
         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If idEstado <> "TODOS" Then
            .AppendLine("   AND EXISTS(SELECT * FROM PedidosEstadosProveedores PE")
            .AppendLine("                      INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado")
            .AppendLine("                      WHERE PE.IdSucursal = P.IdSucursal")
            .AppendLine("                        AND PE.IdTipoComprobante = P.IdTipoComprobante")
            .AppendLine("                        AND PE.Letra = P.Letra")
            .AppendLine("                        AND PE.CentroEmisor = P.CentroEmisor")
            .AppendLine("                        AND PE.NumeroPedido = P.NumeroPedido")

            If idEstado = "PENDIENTE/EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO'))")
            ElseIf idEstado = "SOLO EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado = 'EN PROCESO')")
            Else
               .AppendFormat("                        AND EP.IdEstado = '{0}')", idEstado).AppendLine()
            End If
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND P.FechaPedido >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND P.FechaPedido <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If fechaDesdeEntrega > Date.Parse("01/01/1990") Then
            .AppendLine("   AND EXISTS(SELECT * FROM PedidosEstadosProveedores PE")
            .AppendLine("                      INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado")
            .AppendLine("                      WHERE PE.IdSucursal = P.IdSucursal")
            .AppendLine("                        AND PE.IdTipoComprobante = P.IdTipoComprobante")
            .AppendLine("                        AND PE.Letra = P.Letra")
            .AppendLine("                        AND PE.CentroEmisor = P.CentroEmisor")
            .AppendLine("                        AND PE.NumeroPedido = P.NumeroPedido")
            .AppendLine("   AND PE.FechaEntrega >= '" & fechaDesdeEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND PE.FechaEntrega <= '" & fechaHastaEntrega.ToString("yyyyMMdd HH:mm:ss") & "')")
         End If

         'If fechaDesdeEntrega > Date.Parse("01/01/1990") Then
         '   .AppendLine("   AND  ( SELECT TOP 1 PP.FechaEntrega	FROM PedidosProductosProveedores PP
         '  WHERE PP.IdSucursal = P.IdSucursal
         '  AND PP.IdTipoComprobante = P.IdTipoComprobante
         '  AND PP.Letra = P.Letra
         '  AND PP.CentroEmisor = P.CentroEmisor
         '  AND PP.NumeroPedido = P.NumeroPedido) >= '" & fechaDesdeEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
         '   .AppendLine("   AND ( SELECT TOP 1 PP.FechaEntrega	FROM PedidosProductosProveedores PP
         '  WHERE PP.IdSucursal = P.IdSucursal
         '  AND PP.IdTipoComprobante = P.IdTipoComprobante
         '  AND PP.Letra = P.Letra
         '  AND PP.CentroEmisor = P.CentroEmisor
         '  AND PP.NumeroPedido = P.NumeroPedido) <= '" & fechaHastaEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
         'End If

         If fechaDesdeAutorizacion > Date.Parse("01/01/1990") Then
            .AppendLine("   AND P.FechaAutorizacion >= '" & fechaDesdeAutorizacion.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND P.FechaAutorizacion <= '" & fechaHastaAutorizacion.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If fechaDesdeEnvio > Date.Parse("01/01/1990") Then
            .AppendLine("   AND (SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido
           ORDER BY CE.FechaEnvio DESC) >= '" & fechaDesdeEnvio.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND (SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido
           ORDER BY CE.FechaEnvio DESC) <= '" & fechaHastaEnvio.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroPedido > 0 Then
            .AppendLine("   AND P.NumeroPedido >= " & numeroPedido.ToString())
         End If

         If nroHasta > 0 Then
            .AppendLine("   AND P.NumeroPedido <= " & nroHasta.ToString())
         End If

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND P.Letra = '{0}'", letra)
         End If

         If emisor > 0 Then
            .AppendFormat("   AND P.CentroEmisor = {0}", emisor)
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idProveedor <> 0 Then
            .AppendLine("   and P.IdProveedor = " & idProveedor.ToString())
         End If

         If Not String.IsNullOrEmpty(idIdUsuario) Then
            .AppendLine("    and P.IdUsuario = '" & idIdUsuario & "'")
         End If

         If idVendedor > 0 Then
            .AppendLine("   and P.IdComprador = " & idVendedor.ToString())
         End If

         If importeMinimo > 0 Then
            .AppendLine("   AND P.ImporteTotal >= " & importeMinimo)
         End If

         If importeMaximo > 0 Then
            .AppendLine("   AND P.ImporteTotal <= " & importeMaximo)
         End If

         'If correoEnviado <> "TODOS" Then
         '   .AppendFormatLine("	AND (SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
         '  WHERE CE.IdSucursal = P.IdSucursal
         '  AND CE.IdTipoComprobante = P.IdTipoComprobante
         '  AND CE.Letra = P.Letra
         '  AND CE.CentroEmisor = P.CentroEmisor
         '  AND CE.NumeroPedido = P.NumeroPedido) IS {0} ", If(correoEnviado = "SI", "NOT NULL AND (SELECT TOP 1 CE.MetodoGrabacion	FROM CalidadEnviosOC CE
         '  WHERE CE.IdSucursal = P.IdSucursal
         '  AND CE.IdTipoComprobante = P.IdTipoComprobante
         '  AND CE.Letra = P.Letra
         '  AND CE.CentroEmisor = P.CentroEmisor
         '  AND CE.NumeroPedido = P.NumeroPedido
         '  ORDER BY CE.FechaEnvio DESC) <> 'N'  ", If(correoEnviado = "NO_ENVIAR", "NOT NULL AND (SELECT TOP 1 CE.MetodoGrabacion	FROM CalidadEnviosOC CE
         '  WHERE CE.IdSucursal = P.IdSucursal
         '  AND CE.IdTipoComprobante = P.IdTipoComprobante
         '  AND CE.Letra = P.Letra
         '  AND CE.CentroEmisor = P.CentroEmisor
         '  AND CE.NumeroPedido = P.NumeroPedido
         '  ORDER BY CE.FechaEnvio DESC) = 'N'  ", "NULL")))
         'End If

         If correoEnviado <> "TODOS" Then
            Select Case correoEnviado

               Case "NO"
                  .AppendFormatLine("	AND ((SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido) IS NULL")

                  If verReprogramadas Then
                     .AppendLine(" 
                       Or (SELECT TOP 1 CE.FechaReprogramacion	FROM CalidadEnviosOC CE
                           WHERE CE.IdSucursal = P.IdSucursal
                           And CE.IdTipoComprobante = P.IdTipoComprobante
                           And CE.Letra = P.Letra
                           And CE.CentroEmisor = P.CentroEmisor
                           And CE.NumeroPedido = P.NumeroPedido 
                       And CE.FechaReprogramacion Is Not NULL
                         And CE.FechaReprogramacion <> P.FechaReprogramacion
                       ORDER BY CE.FechaReprogramacion DESC) Is Not NULL  

                       Or ((SELECT TOP 1 CE.FechaReprogramacion	FROM CalidadEnviosOC CE
                           WHERE CE.IdSucursal = P.IdSucursal
                           And CE.IdTipoComprobante = P.IdTipoComprobante
                           And CE.Letra = P.Letra
                           And CE.CentroEmisor = P.CentroEmisor
                           And CE.NumeroPedido = P.NumeroPedido
                     ORDER BY CE.FechaReprogramacion DESC) IS NULL AND P.FechaReprogramacion IS NOT NULL)")
                  End If

                  .AppendLine(" )")
               Case "SI"
                  .AppendFormatLine("	AND ((SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido) IS NOT NULL AND (SELECT TOP 1 CE.MetodoGrabacion	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido
           ORDER BY CE.FechaEnvio DESC) <> 'N' ) ")

               Case "NO_ENVIAR"
                  .AppendFormatLine("	AND ((SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido) IS NOT NULL AND (SELECT TOP 1 CE.MetodoGrabacion	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido
           ORDER BY CE.FechaEnvio DESC) = 'N' ) ")

            End Select
            ' , If(correoEnviado = "SI", ", If(correoEnviado = "NO_ENVIAR", ", "NULL ")))
         End If

         .AppendLine(" ORDER BY (SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
           WHERE CE.IdSucursal = P.IdSucursal
           AND CE.IdTipoComprobante = P.IdTipoComprobante
           AND CE.Letra = P.Letra
           AND CE.CentroEmisor = P.CentroEmisor
           AND CE.NumeroPedido = P.NumeroPedido) DESC")

      End With
      Return GetDataTable(stbQuery)
   End Function

#End Region

#Region "PROCESO FACTURA"

   Public Function GetPedidosXProveedorProducto(IdSucursal As Integer,
                                                IdEstado As String,
                                                IdProducto As String,
                                                IdProveedor As Long,
                                                facturables As Entidades.Venta(),
                                                tipoTipoComprobante As String,
                                                buscoConFactNulo As Boolean,
                                                buscoConRemitoNulo As Boolean) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.IdProveedor ")
         .AppendLine("      ,pp.idProducto, pp.orden")
         .AppendLine("      ,pp.Cantidad")
         .AppendLine("      , pe.idEstado ")
         .AppendLine("      ,pe.CantEstado AS CantEntregada ")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN pe.CantEstado ELSE 0 END) AS CantPendiente ")
         .AppendLine("      ,pe.IdTipoComprobanteFact ")
         .AppendLine("      ,pe.LetraFact ")
         .AppendLine("      ,pe.CentroEmisorFact ")
         .AppendLine("      ,pe.NumeroComprobanteFact ")
         .AppendLine("      ,pe.FechaEstado ")
         .AppendLine("      ,pe.IdCriticidad")
         .AppendLine("      ,pe.FechaEntrega")
         .AppendLine(" FROM PedidosProveedores P ")

         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto ")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante ")

         .AppendLine(" WHERE p.IdSucursal = " & IdSucursal.ToString())

         .AppendFormat("   AND TC.Tipo='{0}'", tipoTipoComprobante)

         .AppendLine("   AND p.IdProveedor=" & IdProveedor)
         .AppendLine("   AND pp.IdProducto = '" & IdProducto & "'")

         If Not String.IsNullOrWhiteSpace(IdEstado) Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstado & "' ")
         End If

         .AppendFormat("   AND PE.IdEstado <> '{0}'", Entidades.EstadoPedido.ESTADO_ANULADO).AppendLine()

         If buscoConFactNulo Then
            .AppendLine("   AND PE.NumeroComprobanteFact IS NULL")
         End If

         If buscoConRemitoNulo Then
            .AppendLine("   AND PE.NumeroComprobanteRemito IS NULL")
         End If

         If facturables IsNot Nothing AndAlso facturables.Length > 0 Then
            .Append("   AND (1 = 2 ")
            For Each pedido As Entidades.Venta In facturables
               .AppendFormat("OR (PE.IdTipoComprobante = '{0}' AND PE.Letra = '{1}' AND PE.CentroEmisor = {2} AND PE.NumeroPedido = {3})",
                              pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroComprobante)
            Next
            .AppendLine(")")
         End If

         .AppendLine(" ORDER BY p.fechaPedido ")

      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Function GetPedidosSumaPorProductos(IdSucursal As Integer,
                                              IdEstado As String,
                                              FechaDesde As Date,
                                              FechaHasta As Date,
                                              IdProveedor As Long,
                                              IdVendedor As Integer,
                                              IdMarca As Integer,
                                              IdRubro As Integer,
                                              IdSubRubro As Integer,
                                              IdProducto As String,
                                              Tamanio As Decimal,
                                              OrdenCompra As Decimal,
                                              tipoTipoComprobante As String) As DataTable
      ''IdProveedor As Long) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.Tamano, Pr.IdUnidadDeMedida")
         .AppendLine("       ,PP.IdUnidadDeMedida
	                          ,PP.IdUnidadDeMedidaCompra
	                          ,PP.FactorConversionCompra
	                          ,UNS.NombreUnidadDeMedida
	                          ,UNC.NombreUnidadDeMedida NombreUnidadDeMedidaCompra")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,SUM(PP.ImporteTotal / PP.Cantidad * PE.CantEstado) AS ImporteTotal")
         .AppendLine("      ,SUM(PE.CantEstado) AS Cantidad")
         .AppendLine("      ,SUM(PE.CantEstado * PP.FactorConversionCompra) AS CantidadUMC")
         .AppendLine(" FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")

         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido ")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PR.IdProducto AND PS.IdSucursal = P.IdSucursal")
         .AppendLine(" LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         .AppendLine(" LEFT JOIN UnidadesDeMedidas UNS ON UNS.IdUnidadDeMedida = PP.IdUnidadDeMedida
                       LEFT JOIN UnidadesDeMedidas UNC ON UNC.IdUnidadDeMedida = PP.IdUnidadDeMedidaCompra")

         .AppendLine(" WHERE PE.IdSucursal = " & IdSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

         If IdEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf IdEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf IdEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstado.ToString() & "'")
         End If

         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaPedido >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaPedido <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If IdProveedor > 0 Then
            .AppendLine("   and P.IdProveedor = " & IdProveedor.ToString())
         End If

         If IdVendedor > 0 Then
            .AppendLine("   and P.IdComprador = " & IdVendedor.ToString())
         End If

         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & IdProducto & "'")
         End If

         If IdMarca <> 0 Then
            .AppendLine("    and pr.IdMarca = " & IdMarca.ToString())
         End If

         If IdRubro <> 0 Then
            .AppendLine("    and pr.IdRubro = " & IdRubro.ToString())
         End If

         If Tamanio > 0 Then
            .AppendLine("    and pr.Tamano = " & Tamanio.ToString())
         End If

         If OrdenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & OrdenCompra.ToString())
         End If

         .AppendLine(" GROUP BY M.NombreMarca, R.NombreRubro, pp.idProducto, pp.NombreProducto, pr.Tamano, Pr.IdUnidadDeMedida,
                       PS.Stock, PP.IdUnidadDeMedida ,PP.IdUnidadDeMedidaCompra ,PP.FactorConversionCompra ,UNS.NombreUnidadDeMedida
	                   ,UNC.NombreUnidadDeMedida")
         .AppendLine(" ORDER BY pp.NombreProducto, pp.idProducto")
      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Function GetPedidosParaGenerarPedidoProv(IdSucursal As Integer,
                                             IdProveedor As Long,
                                             IdMarca As Integer,
                                             IdRubro As Integer,
                                             IdSubRubro As Integer,
                                             IdProducto As String,
                                             OrdenCompra As Decimal) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,pp.IdProducto, pp.NombreProducto")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,0.00 Estimativo")
         .AppendLine("      ,P.NumeroOrdenCompra")
         .AppendLine("       ,OC.IdProveedor ")
         .AppendLine("      ,PRO.CodigoProveedor")
         .AppendLine("      ,PRO.NombreProveedor")
         .AppendLine("      ,SUM(PE.CantEstado) AS Cantidad")
         ' .AppendLine("      ,SUM(PE.CantEstado * Pr.Kilos) AS Kilos")
         .AppendLine(" FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")

         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido ")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PR.IdProducto AND PS.IdSucursal = P.IdSucursal")
         .AppendLine(" INNER JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         '.AppendLine(" INNER JOIN Proveedores PRO ON PRO.IdProveedor = OC.IdProveedor ")
         .AppendLine(" WHERE PE.IdSucursal = " & IdSucursal.ToString())
         '.AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

         .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")

         'If IdCliente > 0 Then
         '   .AppendLine("   and C.IdCliente = " & IdCliente.ToString())
         'End If

         If IdProveedor <> 0 Then
            .AppendLine("   AND OC.IdProveedor = " & IdProveedor)
         End If

         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & IdProducto & "'")
         End If

         If IdMarca <> 0 Then
            .AppendLine("    and pr.IdMarca = " & IdMarca.ToString())
         End If

         If IdRubro <> 0 Then
            .AppendLine("    and pr.IdRubro = " & IdRubro.ToString())
         End If

         If OrdenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & OrdenCompra.ToString())
         End If

         .AppendLine(" GROUP BY M.NombreMarca, R.NombreRubro, pp.idProducto, pp.NombreProducto, pr.Tamano, ")
         .AppendLine("  Pr.IdUnidadDeMedida, PS.Stock, PS.PrecioCosto  ,P.NumeroOrdenCompra,   p.IdProveedor, PV.CodigoProveedor ,PV.NombreProveedor ")
         .AppendLine(" ORDER BY pp.NombreProducto, pp.idProducto")
      End With

      Return GetDataTable(stbQuery)

   End Function

#End Region

   Public Function VerificaPedidoModificable(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, idEstadoPedidoNuevo As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT (SELECT COUNT(1) FROM PedidosProductosProveedores AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroPedido = P.NumeroPedido) AS PedidosProductos")
         .AppendFormatLine("      ,(SELECT COUNT(1) FROM PedidosEstadosProveedores   AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroPedido = P.NumeroPedido) AS PedidosEstados")
         .AppendFormatLine("      ,(SELECT COUNT(1) FROM PedidosEstadosProveedores   AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine("                                                                 AND PP.IdEstado <> EP.idEstado) AS PedidosEstadosNoPendientes")
         .AppendFormatLine("  FROM PedidosProveedores AS P")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine(" CROSS JOIN EstadosPedidosProveedores AS EP")
         .AppendFormatLine(" WHERE P.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND P.Letra = '{0}'", letra)
         .AppendFormatLine("   AND P.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND P.NumeroPedido = {0}", numeroPedido)
         '.AppendFormatLine("   AND EP.IdTipoEstado = 'PENDIENTE'")
         .AppendFormatLine("   AND EP.IdEstado = '{0}'", idEstadoPedidoNuevo)
         .AppendFormatLine("   AND EP.TipoEstadoPedido = TP.Tipo")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPedido(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short?, numeroPedido As Long?,
                              idProveedor As Long?, fechaPed As Date?,
                              ordenCompra As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT * FROM PedidosProveedores AS P")
         .AppendFormat(" WHERE 1 = 1", idProveedor).AppendLine()
         If idSucursal > 0 Then
            .AppendFormat("   AND P.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND P.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor.HasValue AndAlso centroEmisor.Value <> 0 Then
            .AppendFormat("   AND P.CentroEmisor = {0}", centroEmisor.Value).AppendLine()
         End If
         If numeroPedido.HasValue AndAlso numeroPedido.Value <> 0 Then
            .AppendFormat("   AND P.NumeroPedido = {0}", numeroPedido.Value).AppendLine()
         End If

         If idProveedor.HasValue AndAlso idProveedor.Value <> 0 Then
            .AppendFormat("   AND P.IdProveedor = {0}", idProveedor.Value).AppendLine()
         End If

         If ordenCompra.HasValue AndAlso ordenCompra.Value <> 0 Then
            .AppendFormat("   AND P.NumeroOrdenCompra = {0}", ordenCompra.Value).AppendLine()
         End If

         If fechaPed.HasValue Then
            .AppendFormat("   AND P.FechaPedido = '{0}'", ObtenerFecha(fechaPed.Value, True)).AppendLine()
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function ExistePedido(idSucursal As Integer, idProveedor As Long, fechaPed As DateTime) As Boolean
      Return GetPedido(idSucursal, String.Empty, String.Empty, Nothing, Nothing, idProveedor, fechaPed, Nothing).Rows.Count > 0
   End Function

   Public Function ExistePedido(idSucursal As Integer, numeroPedido As Long) As Boolean
      Return ExistePedido(idSucursal, "PEDIDOPDA", numeroPedido)
   End Function

   Public Function ExistePedido(idSucursal As Integer, idTipoComprobante As String, numeroPedido As Long) As Boolean
      Return GetPedido(idSucursal, idTipoComprobante, String.Empty, Nothing, numeroPedido, Nothing, Nothing, Nothing).Rows.Count > 0
   End Function

   Public Function ExistePedido(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As Boolean
      Return GetPedido(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, Nothing, Nothing, Nothing).Rows.Count > 0
   End Function

   Public Function ExistePedido(idSucursal As Integer, idTipoComprobante As String, idProveedor As Long, ordenCompra As Long) As Boolean
      Return GetPedido(idSucursal, idTipoComprobante, String.Empty, Nothing, Nothing, idProveedor, Nothing, ordenCompra).Rows.Count > 0
   End Function

   Public Sub ActualizarComprobantePorComprobante(idSucursal As Integer,
                                                   idTipoComprobanteActual As String,
                                                   letraActual As String,
                                                   centroEmisorActual As Integer,
                                                   numeroComprobanteActual As Long,
                                                   idTipoComprobanteNuevo As String,
                                                   letraNuevo As String,
                                                   centroEmisorNuevo As Integer,
                                                   numeroComprobanteNuevo As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Length = 0
         .AppendFormat("UPDATE PedidosEstadosProveedores")
         .AppendFormat("   SET IdTipoComprobanteFact = '{0}'", idTipoComprobanteNuevo)
         .AppendFormat("      ,LetraFact = '{0}'", letraNuevo)
         .AppendFormat("      ,CentroEmisorFact = {0}", centroEmisorNuevo)
         .AppendFormat("      ,NumeroComprobanteFact = {0}", numeroComprobanteNuevo)
         .AppendFormat("   WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("     AND IdTipoComprobanteFact = '{0}'", idTipoComprobanteActual)
         .AppendFormat("     AND LetraFact = '{0}'", letraActual)
         .AppendFormat("     AND CentroEmisorFact = {0}", centroEmisorActual)
         .AppendFormat("     AND NumeroComprobanteFact = {0}", numeroComprobanteActual)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ActualizarFechaAutorizacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numero As Long,
                                          fechaAutorizacion As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE PedidosProveedores")
         .AppendFormat("   SET FechaAutorizacion = '{0}'", fechaAutorizacion)
         .AppendFormat("   WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("     AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("     AND Letra = '{0}'", letra)
         .AppendFormat("     AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("     AND NumeroPedido = {0}", numero)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ActualizarFechaReprogramacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numero As Long,
                                            fechaReprogramacion As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE PedidosProveedores")
         .AppendFormat("   SET FechaReprogramacion = '{0}'", fechaReprogramacion)
         .AppendFormat("   WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("     AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("     AND Letra = '{0}'", letra)
         .AppendFormat("     AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("     AND NumeroPedido = {0}", numero)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ActualizarImportesCalidad(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numero As Long,
                                        importeTotal As Decimal, importeTotalConImpuestos As Decimal, totalImpuestos As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE PedidosProveedores")
         .AppendFormat("   SET ImporteTotal = '{0}'", importeTotalConImpuestos)
         .AppendFormat("       ,ImporteBruto = '{0}'", importeTotal)
         .AppendFormat("       ,Subtotal = '{0}'", importeTotal)
         .AppendFormat("       ,TotalImpuestos = '{0}'", totalImpuestos)

         .AppendFormat("   WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("     AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("     AND Letra = '{0}'", letra)
         .AppendFormat("     AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("     AND NumeroPedido = {0}", numero)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CopiarPedido(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                           idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Integer, numeroPedidoNuevo As Long,
                           fechaPedidoNuevo As Date, observacionNuevo As String, usuarioNuevo As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO PedidosProveedores")
         .AppendFormatLine("      (IdSucursal")
         .AppendFormatLine("      ,IdTipoComprobante")
         .AppendFormatLine("      ,Letra")
         .AppendFormatLine("      ,CentroEmisor")
         .AppendFormatLine("      ,NumeroPedido")
         .AppendFormatLine("      ,FechaPedido")
         .AppendFormatLine("      ,Observacion")
         .AppendFormatLine("      ,IdUsuario")
         .AppendFormatLine("      ,DescuentoRecargo,DescuentoRecargoPorc,IdProveedor") '',IdVendedor")
         .AppendFormatLine("      ,IdFormasPago,IdTransportista,CotizacionDolar,IdTipoComprobanteFact,ImporteBruto")
         .AppendFormatLine("      ,SubTotal,TotalImpuestos,TotalImpuestoInterno,ImporteTotal,IdEstadoVisita")
         .AppendFormatLine("      ,NumeroOrdenCompra)")
         .AppendFormatLine("SELECT {0} AS IdSucursal", idSucursalNuevo)
         .AppendFormatLine("      ,'{0}' AS IdTipoComprobante", idTipoComprobanteNuevo)
         .AppendFormatLine("      ,'{0}' AS Letra", letraNuevo)
         .AppendFormatLine("      ,{0} AS CentroEmisor", centroEmisorNuevo)
         .AppendFormatLine("      ,{0} AS NumeroPedido", numeroPedidoNuevo)
         .AppendFormatLine("      ,'{0}' FechaPedido", ObtenerFecha(fechaPedidoNuevo, True))
         .AppendFormatLine("      ,'{0}' Observacion", observacionNuevo)
         .AppendFormatLine("      ,'{0}' IdUsuario", usuarioNuevo)
         .AppendFormatLine("      ,DescuentoRecargo,DescuentoRecargoPorc,IdProveedor") '',IdVendedor")
         .AppendFormatLine("      ,IdFormasPago,IdTransportista,CotizacionDolar,IdTipoComprobanteFact,ImporteBruto")
         .AppendFormatLine("      ,SubTotal,TotalImpuestos,TotalImpuestoInterno,ImporteTotal,IdEstadoVisita")
         .AppendFormatLine("      ,NumeroOrdenCompra")
         .AppendFormatLine("  FROM PedidosProveedores")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   And IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroPedido = {0}", numeroPedido)
      End With
      Execute(myQuery)
   End Sub


#Region "Metodos de la versión vieja a REVISAR"
   Public Function GetPedidosXProveedorProducto(IdSucursal As Integer,
                                              IdEstado As String,
                                              IdProducto As String,
                                              IdProveedor As Long,
                                              facturables As Entidades.Compra(),
                                              tipoTipoComprobante As String,
                                              buscoConFactNulo As Boolean,
                                              buscoConRemitoNulo As Boolean,
                                              estadoAnulado As String) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT p.IdSucursal, P.IdTipoComprobante, P.Letra, P.CentroEmisor, p.NumeroPedido, p.FechaPedido ")
         .AppendLine("      ,P.IdProveedor ")
         .AppendLine("      ,pp.idProducto, pp.orden")
         .AppendLine("      , pp.orden")
         .AppendLine("      ,pp.Cantidad")
         .AppendLine("      , pe.idEstado ")
         .AppendLine("      ,pe.CantEstado AS CantEntregada ")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN pe.CantEstado ELSE 0 END) AS CantPendiente ")
         .AppendLine("      ,pe.IdTipoComprobanteFact")
         .AppendLine("      ,pe.LetraFact")
         .AppendLine("      ,pe.CentroEmisorFact")
         .AppendLine("      ,pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdSucursalRemito")
         .AppendLine("      ,pe.IdTipoComprobanteRemito")
         .AppendLine("      ,pe.LetraRemito")
         .AppendLine("      ,pe.CentroEmisorRemito")
         .AppendLine("      ,pe.NumeroComprobanteRemito")
         .AppendLine("      ,pe.FechaEstado ")
         .AppendLine("      ,pe.IdCriticidad")
         .AppendLine("      ,pe.FechaEntrega")
         .AppendLine("  FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN PedidosProductosProveedores PP")
         .AppendLine("         ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("        AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("        AND PP.Letra = P.Letra")
         .AppendLine("        AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("        AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE")
         .AppendLine("         ON PE.IdSucursal = PP.IdSucursal")
         .AppendLine("        AND PE.IdTipoComprobante = PP.IdTipoComprobante")
         .AppendLine("        AND PE.Letra = PP.Letra")
         .AppendLine("        AND PE.CentroEmisor = PP.CentroEmisor")
         .AppendLine("        AND PE.NumeroPedido = PP.NumeroPedido")
         .AppendLine("        AND PE.IdProducto = PP.IdProducto")
         .AppendLine("        AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP")
         .AppendLine("         ON EP.IdEstado = PE.IdEstado")
         .AppendLine("        AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Proveedores PR ON PR.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante ")
         .AppendLine(" WHERE p.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND p.IdProveedor = " & IdProveedor.ToString())
         .AppendLine("   AND pp.IdProducto = '" & IdProducto & "'")
         '.AppendLine("   AND pe.IdEstado = '" & IdEstado.ToString() & "'")

         .AppendFormat("   AND TC.Tipo='{0}'", tipoTipoComprobante)

         If Not String.IsNullOrWhiteSpace(IdEstado) Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstado & "' ")
         End If

         .AppendFormat("   AND PE.IdEstado <> '{0}'", estadoAnulado).AppendLine()

         If buscoConFactNulo Then
            .AppendLine("   AND PE.NumeroComprobanteFact IS NULL")
         End If

         If buscoConRemitoNulo Then
            .AppendLine("   AND PE.NumeroComprobanteRemito IS NULL")
         End If

         If facturables IsNot Nothing AndAlso facturables.Length > 0 Then
            .Append("   AND (1 = 2 ")
            For Each pedido As Entidades.Compra In facturables
               .AppendFormat("OR (P.IdTipoComprobante = '{0}' AND P.Letra = '{1}' AND P.CentroEmisor = {2} AND P.NumeroPedido = {3})",
                              pedido.TipoComprobante.IdTipoComprobante, pedido.Letra, pedido.CentroEmisor, pedido.NumeroComprobante)
            Next
            .AppendLine(")")
         End If

         .AppendLine(" ORDER BY p.fechaPedido ")

      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Sub UpdateEstadoPedido(idSucursal As Integer,
                                 idpedido As Integer,
                                 idproducto As String,
                                 fechaEstado As Date,
                                 idEstado As String,
                                 cantEntregada As Decimal,
                                 fechaNuevoEstado As Date,
                                 observacion As String,
                                 orden As Integer)

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET CantEntregada = " & cantEntregada.ToString)
         .AppendLine("      ,IdEstado = '" & idEstado & "'")
         .AppendLine("      ,FechaEstado = '" & ObtenerFecha(fechaNuevoEstado, True) & "'")
         .AppendLine("      ,Observacion = '" & observacion & "'")
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdPedido = " & idpedido.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With

      Me.Execute(stbQuery.ToString())

   End Sub

   Public Sub ActualizarCantidadEntregada(idSucursal As Integer,
                                          idPedido As Integer,
                                          idProducto As String,
                                          Cantidad As Decimal,
                                          orden As Integer)

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("UPDATE PedidosProductosProveedores")
         .AppendLine("   SET CantEntregada = CantEntregada + " & Cantidad.ToString)
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdPedido = " & idPedido.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With

      Me.Execute(stbQuery.ToString())

   End Sub

   Public Sub ActualizarComprobantePedido(idSucursal As Integer,
                                              idPedido As Integer,
                                              idProducto As String,
                                              fechaEstado As Date,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroComprobante As Long,
                                              Orden As Integer)

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("      ,Letra = '" & letra & "'")
         .AppendLine("      ,CentroEmisor =" & centroEmisor.ToString)
         .AppendLine("      ,NumeroComprobante = " & numeroComprobante.ToString)
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdPedido = " & idPedido.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
         .AppendLine("   AND Orden = " & Orden.ToString)
      End With

      Me.Execute(stbQuery.ToString())

   End Sub


   Public Sub InsertaEstadoPedido(idSucursal As Integer,
                                   idpedido As Integer,
                                   idproducto As String,
                                   fechaEstado As Date,
                                   idEstado As String,
                                   IdUsuario As String,
                                   observacion As String,
                                   cantEntregada As Decimal,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Integer,
                                   numeroComprobante As Long,
                                    Orden As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO PedidosEstadosProveedores")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdPedido")
         .AppendLine("           ,idProducto")
         .AppendLine("           ,fechaEstado")
         .AppendLine("           ,idEstado")
         .AppendLine("           ,IdUsuario")
         .AppendLine("           ,observacion")
         .AppendLine("           ,cantEntregada")
         .AppendLine("           ,IdTipoComprobante")
         .AppendLine("           ,Letra")
         .AppendLine("           ,CentroEmisor")
         .AppendLine("           ,NumeroComprobante")
         .AppendLine("           ,Orden")
         .AppendLine("           )")

         .AppendLine("     VALUES (")

         .AppendFormat("    {0}", idSucursal)
         .AppendFormat("   ,{0}", idpedido)
         .AppendFormat("   ,'{0}'", idproducto)
         .AppendFormat("  ,'{0}'", Me.ObtenerFecha(fechaEstado, True))
         .AppendFormat("   ,'{0}'", idEstado)
         .AppendFormat("   ,'{0}'", IdUsuario)
         .AppendFormat("  , '{0}'", observacion)
         .AppendFormat("  ,{0}", cantEntregada)
         If idTipoComprobante = "" Then
            .AppendFormat("  ,{0}", "NULL")
         Else
            .AppendFormat("  ,'{0}'", idTipoComprobante)
         End If
         If letra = "" Then
            .AppendFormat("  ,{0}", "NULL")
         Else
            .AppendFormat("  ,'{0}'", letra)
         End If
         If centroEmisor = 0 Then
            .AppendFormat("   ,{0}", "NULL")
         Else
            .AppendFormat("  ,{0}", centroEmisor)
         End If
         If numeroComprobante = 0 Then
            .AppendFormat("   ,{0}", "NULL")
         Else
            .AppendFormat("  ,{0}", numeroComprobante)
         End If
         .AppendFormat("  ,{0}", Orden)

         .Append(")")

      End With

      Execute(myQuery)

   End Sub


#End Region

End Class