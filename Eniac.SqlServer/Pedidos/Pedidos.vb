Public Class Pedidos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function Pedido_GetIdMaximo(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Long
      Return GetCodigoMaximo(Entidades.Pedido.Columnas.NumeroPedido.ToString(), Entidades.Pedido.NombreTabla,
                             String.Format("{0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7}",
                                           Entidades.Pedido.Columnas.IdSucursal.ToString(), idSucursal,
                                           Entidades.Pedido.Columnas.IdTipoComprobante.ToString(), idTipoComprobante,
                                           Entidades.Pedido.Columnas.Letra.ToString(), letraFiscal,
                                           Entidades.Pedido.Columnas.CentroEmisor.ToString(), emisor))
   End Function

   Public Sub Pedidos_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM Pedidos")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroPedido = {0}", numeroPedido)
      End With

      Execute(stb)
   End Sub

   Public Sub Pedidos_I(idSucursal As Integer,
                        idTipoComprobante As String,
                        letra As String,
                        centroEmisor As Integer,
                        numeroPedido As Long,
                        fechaPedido As Date,
                        observacion As String,
                        idUsuario As String,
                        descuentoRecargo As Double,
                        descuentoRecargoPorc As Double,
                        idCliente As Long,
                        IdVendedor As Integer,
                        IdCaja As Integer?,
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
                        kilos As Decimal,
                        observacionInterna As String,
                        idMoneda As Integer,
                        idClienteVinculado As Long,
                        palets As Integer,
                        nroVersionAplicacion As String,
                        nroVersionRemoto As String,
                        idPedidoTiendaNube As String,
                        idPedidoMercadoLibre As String,
                        idLocalidad As Integer?,
                        direccion As String,
                        cuit As String,
                        tipoDocCliente As String,
                        nroDocCliente As Long?,
                        nombreCliente As String,
                        SaldoActualCtaCte As Decimal?,
                        idPlazoEntrega As Integer,
                        validezPresupuesto As Integer, idDomicilio As Integer?,
                        fechaActualizacion As Date, idUsuarioActualizacion As String)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Pedidos")
         .AppendFormatLine("           ({0}", Entidades.Pedido.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.Letra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.NumeroPedido.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.FechaPedido.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.Observacion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdUsuario.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.DescuentoRecargo.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.DescuentoRecargoPorc.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdCliente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdVendedor.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdCaja.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdFormasPago.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdTransportista.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.CotizacionDolar.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdTipoComprobanteFact.ToString())

         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.ImporteBruto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.SubTotal.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.TotalImpuestos.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.TotalImpuestoInterno.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.ImporteTotal.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdEstadoVisita.ToString())

         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.NumeroOrdenCompra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.Kilos.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.ObservacionInterna.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdMoneda.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdClienteVinculado.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.Palets.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.NroVersionAplicacion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.NroVersionRemoto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdPedidoTiendaNube.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdPedidoMercadoLibre.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdLocalidad.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.Direccion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.Cuit.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.TipoDocCliente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.NroDocCliente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.NombreCliente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.SaldoActualCtaCte.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdPlazoEntrega.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.ValidezPresupuesto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdDomicilio.ToString())

         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.FechaActualizacion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Pedido.Columnas.IdUsuarioActualizacion.ToString())

         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          ,'{0}'", idTipoComprobante)
         .AppendFormatLine("          ,'{0}'", letra)
         .AppendFormatLine("          , {0} ", centroEmisor)
         .AppendFormatLine("          , {0} ", numeroPedido)
         .AppendFormatLine("          ,'{0}'", Me.ObtenerFecha(fechaPedido, True))
         .AppendFormatLine("          ,'{0}'", observacion)
         .AppendFormatLine("          ,'{0}'", idUsuario)
         .AppendFormatLine("          , {0} ", descuentoRecargo)
         .AppendFormatLine("          , {0} ", descuentoRecargoPorc)
         .AppendFormatLine("          , {0} ", idCliente)

         If IdVendedor > 0 Then
            .AppendFormatLine("          ,{0}", IdVendedor)
         Else
            .AppendFormatLine("          , NULL ")
         End If

         If IdCaja.HasValue Then
            .AppendFormatLine("          , {0} ", IdCaja.Value)
         Else
            .AppendFormatLine("          , NULL ")
         End If

         If idFormaPago.HasValue Then
            .AppendFormatLine("          , {0} ", idFormaPago.Value)
         Else
            .AppendFormatLine("          , NULL ")
         End If
         If idTransportista > 0 Then
            .AppendFormatLine("          , {0} ", idTransportista.Value)
         Else
            .AppendFormatLine("          , NULL ")
         End If
         If cotizacionDolar.HasValue Then
            .AppendFormatLine("          , {0} ", cotizacionDolar.Value)
         Else
            .AppendFormatLine("          , NULL ")
         End If
         If String.IsNullOrWhiteSpace(idTipoComprobanteFact) Then
            .AppendFormatLine("          , NULL ")
         Else
            .AppendFormatLine("          ,'{0}'", idTipoComprobanteFact)
         End If

         .AppendFormatLine("          ,{0}", importeBruto)
         .AppendFormatLine("          ,{0}", subTotal)
         .AppendFormatLine("          ,{0}", totalImpuestos)
         .AppendFormatLine("          ,{0}", totalImpuestoInterno)
         .AppendFormatLine("          ,{0}", importeTotal)
         .AppendFormatLine("          ,{0}", idEstadoVisita)

         If numeroOrdenCompra > 0 Then
            .AppendFormatLine("          ,{0}", numeroOrdenCompra)
         Else
            .AppendFormatLine("          ,NULL")
         End If

         .AppendFormatLine("          ,{0}", kilos)

         .AppendFormatLine("          ,'{0}'", observacionInterna)

         .AppendFormatLine("          ,{0}", idMoneda)
         .AppendFormatLine("          ,{0}", If(idClienteVinculado > 0, idClienteVinculado.ToString(), "NULL"))
         .AppendFormatLine("          ,{0}", palets)
         .AppendFormatLine("          ,'{0}'", nroVersionAplicacion)
         .AppendFormatLine("          ,'{0}'", nroVersionRemoto)
         .AppendFormatLine("          ,'{0}'", idPedidoTiendaNube)
         .AppendFormatLine("          ,'{0}'", idPedidoMercadoLibre)

         If idLocalidad.HasValue Then
            .AppendFormatLine("          ,{0}", idLocalidad.Value)
         Else
            .AppendFormatLine("          ,NULL")
         End If
         .AppendFormatLine("          ,'{0}'", direccion)
         .AppendFormatLine("          ,'{0}'", cuit)

         '-- REQ-37899.- ----------------------------------------------
         If nroDocCliente > 0 Then
            .AppendFormatLine("          ,'{0}'", tipoDocCliente)
            .AppendFormatLine("      , {0} ", nroDocCliente.Value)
         Else
            .AppendFormatLine("          ,NULL")
            .AppendFormatLine("      ,NULL")
         End If
         '--------------------------------------------------------------
         .AppendFormatLine("          ,'{0}'", nombreCliente)

         If saldoActualCtaCte.HasValue Then
            .AppendFormatLine("          ,{0}", saldoActualCtaCte.Value)
         Else
            .AppendFormatLine("          ,NULL")
         End If

         .AppendFormatLine("          , {0} ", idPlazoEntrega)
         .AppendFormatLine("          , {0} ", validezPresupuesto)
         If idDomicilio.HasValue AndAlso idDomicilio > 0 Then
            .AppendFormatLine("          ,{0}", idDomicilio.Value)
         Else
            .AppendFormatLine("          ,NULL")
         End If

         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaActualizacion, True, True))
         .AppendFormatLine("          ,'{0}'", idUsuarioActualizacion)


         .AppendFormat(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Pedidos_U(idSucursal As Integer,
                        idTipoComprobante As String,
                        letra As String,
                        centroEmisor As Integer,
                        numeroPedido As Long,
                        fechaPedido As Date,
                        observacion As String,
                        idUsuario As String,
                        descuentoRecargo As Double,
                        descuentoRecargoPorc As Double,
                        idCliente As Long,
                        idVendedor As Long,
                        idCaja As Integer?,
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
                        kilos As Decimal,
                        observacionInterna As String,
                        idMoneda As Integer,
                        idClienteVinculado As Long,
                        palets As Integer,
                        nroVersionAplicacion As String,
                        nroVersionRemoto As String,
                        idPedidoTiendaNube As String,
                        idPedidoMercadoLibre As String,
                        idLocalidad As Integer?,
                        direccion As String,
                        cuit As String,
                        tipoDocCliente As String,
                        nroDocCliente As Long?,
                        nombreCliente As String,
                        SaldoActualCtaCte As Decimal?,
                        IdPlazoEntrega As Integer,
                        validezPresupuesto As Integer,
                        fechaActualizacion As Date, idUsuarioActualizacion As String)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Pedidos SET")

         .AppendFormatLine("       {0} = '{1}'", Entidades.Pedido.Columnas.FechaPedido.ToString(), ObtenerFecha(fechaPedido, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.Observacion.ToString(), observacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.IdUsuario.ToString(), idUsuario)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.DescuentoRecargo.ToString(), descuentoRecargo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.DescuentoRecargoPorc.ToString(), descuentoRecargoPorc)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdVendedor.ToString(), GetStringFromNumber(idVendedor))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdCaja.ToString(), GetStringFromNumber(idCaja))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdFormasPago.ToString(), GetStringFromNumber(idFormaPago))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdTransportista.ToString(), GetStringFromNumber(idTransportista.IfNull()))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.CotizacionDolar.ToString(), GetStringFromDecimal(cotizacionDolar))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdTipoComprobanteFact.ToString(), GetStringParaQueryConComillas(idTipoComprobanteFact))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.ImporteBruto.ToString(), importeBruto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.SubTotal.ToString(), subTotal)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.TotalImpuestos.ToString(), totalImpuestos)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.TotalImpuestoInterno.ToString(), totalImpuestoInterno)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.ImporteTotal.ToString(), importeTotal)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdEstadoVisita.ToString(), idEstadoVisita)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.NumeroOrdenCompra.ToString(), GetStringFromNumber(numeroOrdenCompra))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.Kilos.ToString(), kilos)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.ObservacionInterna.ToString(), observacionInterna)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdMoneda.ToString(), idMoneda)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdClienteVinculado.ToString(), GetStringFromNumber(idClienteVinculado))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.Palets.ToString(), palets)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.NroVersionAplicacion.ToString(), nroVersionAplicacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.NroVersionRemoto.ToString(), nroVersionRemoto)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.IdPedidoTiendaNube.ToString(), idPedidoTiendaNube)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.IdPedidoMercadoLibre.ToString(), idPedidoMercadoLibre)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.IdLocalidad.ToString(), GetStringFromNumber(idLocalidad))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.Direccion.ToString(), direccion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.Cuit.ToString(), cuit)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.TipoDocCliente.ToString(), tipoDocCliente)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.NroDocCliente.ToString(), GetStringFromNumber(nroDocCliente))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.NombreCliente.ToString(), nombreCliente)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.SaldoActualCtaCte.ToString(), saldoActualCtaCte)

         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.IdPlazoEntrega.ToString(), IdPlazoEntrega)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.FechaActualizacion.ToString(), ObtenerFecha(fechaActualizacion, True, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Pedido.Columnas.IdUsuarioActualizacion.ToString(), idUsuarioActualizacion)

         .AppendFormatLine("     , {0} = NULL", Entidades.Pedido.Columnas.FechaImpresion.ToString())

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Pedido.Columnas.ValidezPresupuesto.ToString(), validezPresupuesto)


         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Pedido.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.Pedido.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.Pedido.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.Pedido.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.Pedido.Columnas.NumeroPedido.ToString(), numeroPedido)

      End With
      Execute(myQuery)
   End Sub

   Public Function GetPedidos(sucursales As Entidades.Sucursal(),
                              idEstado As String,
                              fechaDesde As Date,
                              fechaHasta As Date,
                              numeroPedido As Long,
                              idProducto As String,
                              idCliente As Long,
                              tamanio As Decimal,
                              idMarca As Integer,
                              idRubro As Integer,
                              idSubRubro As Integer,
                              idVendedor As Integer,
                              tipoVendedor As Entidades.OrigenFK,
                              ordenCompra As Long,
                              tipoTipoComprobante As String,
                              tiposComprobante As Entidades.TipoComprobante(),
                              letra As String,
                              centroEmisor As Short,
                              orden As Integer,
                              fechaEstado As Date?,
                              idZonaGeografica As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT '' as Color")
         .AppendLine("      ,'False' as masivo")
         .AppendLine("      ,pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.IdCliente, C.NombreCliente")
         .AppendLine("     , L.IdLocalidad")
         .AppendLine("     , L.NombreLocalidad")
         .AppendLine("     , Pv.IdProvincia")
         .AppendLine("     , Pv.NombreProvincia")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pp.Tamano, pr.IdUnidadDeMedida, pp.Orden")
         .AppendLine("      ,pp.Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado, PE.TipoEstadoPedido")
         .AppendLine("      ,'' AS IdEstadoNuevo")
         .AppendLine("      ,PE.CantEstado AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         .AppendLine("      ,(CASE WHEN PU.Stock IS NULL THEN 0 ELSE PU.Stock END) AS Stock ")
         .AppendLine("      ,P.NumeroOrdenCompra")
         .AppendLine("      ,P.Kilos")
         .AppendLine("      ,pe.IdSucursal AS IdSucursalFact, pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdSucursalRemito,pe.IdTipoComprobanteRemito, pe.LetraRemito, pe.CentroEmisorRemito, pe.NumeroComprobanteRemito")
         .AppendLine("      ,pe.IdSucursalGenerado,pe.IdTipoComprobanteGenerado, pe.LetraGenerado, pe.CentroEmisorGenerado, pe.NumeroPedidoGenerado")
         .AppendLine("      ,pe.IdSucursalProduccion,pe.IdTipoComprobanteProduccion, pe.LetraProduccion, pe.CentroEmisorProduccion, pe.NumeroOrdenProduccion")
         .AppendLine("      ,pe.IdSucursalVinculado, pe.IdTipoComprobanteVinculado, pe.LetraVinculado, pe.CentroEmisorVinculado, pe.NumeroPedidoVinculado, pe.IdProductoVinculado, pe.OrdenVinculado, pe.FechaEstadoVinculado")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.Observacion") ' Observación de PedidosEstados
         .AppendLine("      ,p.Observacion as PedidoObs") ' Observación de Pedidos
         .AppendLine("      ,m.NombreMarca")
         .AppendLine("      ,r.NombreRubro")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")
         .AppendLine("      ,PP.UrlPlano")
         .AppendLine("      ,PP.IdFormula")
         .AppendLine("      ,PP.TipoOperacion")
         .AppendLine("      ,PP.Nota")
         .AppendLine("      ,CONVERT(int, NULL) AS IdSucursalTipoComprobanteDestino")
         .AppendLine("      ,PP.CodigoSAE")
         .AppendLine("      ,PP.LargoExtAlto")
         .AppendLine("      ,PP.AnchoIntBase")
         .AppendLine("      ,(pp.Tamano*pp.Cantidad) as KgTotal")
         .AppendLine("      ,C.Telefono")
         .AppendLine("      ,C.Direccion")
         .AppendLine("      ,P.Palets")
         .AppendLine("      ,P.NroVersionAplicacion")
         .AppendLine("      ,P.NroVersionRemoto")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,P.FechaImpresion")
         .AppendLine("      ,P.IdPedidoTiendaNube")
         .AppendLine("      ,P.IdPedidoMercadoLibre")
         .AppendLine("      ,P.IdLocalidad")
         .AppendLine("      ,P.Direccion as DireccionPedido")
         .AppendLine("      ,P.Cuit")
         .AppendLine("      ,P.TipoDocCliente")
         .AppendLine("      ,P.NroDocCliente")
         .AppendLine("      ,P.NombreCliente NombreClienteGenerico")

         .AppendLine("      ,VFP.DescripcionFormasPago FormaDePagos")
         .AppendLine("      ,LPC.NombreListaPrecios ListaDePrecios")
         .AppendLine("      ,PP.IdListaPrecios")
         .AppendLine("      ,P.SaldoActualCtaCte")

         .AppendLine("      ,P.IdPlazoEntrega")
         .AppendLine("      ,PT.DescripcionPlazoEntrega")

         .AppendLine("      ,P.ValidezPresupuesto")
         .AppendLine("      ,EP.ReservaStock")

         .AppendLine("      ,PS.IdDepositoDefecto")
         .AppendLine("      ,SD.NombreDeposito AS NombreDepositoDefecto")
         .AppendLine("      ,PS.IdUbicacionDefecto")
         .AppendLine("      ,SU.NombreUbicacion AS NombreUbicacionDefecto")
         .AppendLine("      ,PP.IdProcesoProductivo")


         .AppendLine(" FROM Pedidos P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.TODOS Then
            .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         Else
            .AppendLine(" INNER JOIN (")
            .AppendLine("             SELECT *")
            .AppendLine("               FROM EstadosPedidos E")
            .AppendLine("              WHERE EXISTS(")
            .AppendLine("                           SELECT *")
            .AppendLine("                             FROM EstadosPedidosRoles EPR")
            .AppendLine("                            INNER JOIN UsuariosRoles UR ON UR.IdRol = EPR.IdRol")
            .AppendFormatLine("                            WHERE UR.IdSucursal = {0}", actual.Sucursal.Id)
            .AppendFormatLine("                              AND UR.IdUsuario = '{0}'", actual.Nombre)
            .AppendLine("                              AND EPR.TipoEstadoPedido = E.TipoEstadoPedido AND EPR.IdEstado = E.IdEstado)")
            .AppendLine("            ) EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         End If
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente")
         .AppendLine("  LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  LEFT JOIN Provincias Pv ON Pv.IdProvincia = L.IdProvincia")
         .AppendLine(" INNER JOIN Productos PR ON PR.IdProducto = PE.IdProducto")

         .AppendLine(" INNER JOIN PLazosEntregas PT ON PT.IdPlazoEntrega = P.IdPlazoEntrega")

         '-- REQ-31816.- --
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON VFP.IdFormasPago = P.IdFormasPago")
         .AppendLine("  LEFT JOIN ListasDePrecios LPC ON LPC.IdListaPrecios = PP.IdListaPrecios")

         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = PR.IdProducto AND PS.IdSucursal = P.IdSucursal")
         .AppendLine(" LEFT JOIN ProductosUbicaciones PU ON PU.IdProducto = PP.IdProducto AND PU.IdSucursal = P.IdSucursal AND PU.IdDeposito = PS.IdDepositoDefecto AND PU.IdUbicacion = PS.IdUbicacionDefecto")

         .AppendLine(" INNER JOIN SucursalesDepositos SD ON  SD.IdSucursal = P.IdSucursal AND SD.IdDeposito = PS.IdDepositoDefecto")
         .AppendLine(" INNER JOIN SucursalesUbicaciones SU ON  SU.IdSucursal = P.IdSucursal AND SU.IdDeposito = PS.IdDepositoDefecto AND SU.IdUbicacion = PS.IdUbicacionDefecto ")

         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         ' Según el tipo de vendedor
         If tipoVendedor <> Entidades.OrigenFK.Movimiento Then
            .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor ")
         Else
            .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = P.IdVendedor ")
         End If

         .AppendLine("  WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "P")

         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante)
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

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND p.Letra = '{0}'", letra).AppendLine()
         End If

         If centroEmisor > 0 Then
            .AppendFormat("   AND p.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If

         If orden > 0 Then
            .AppendFormat("   AND PE.Orden = {0}", orden).AppendLine()
         End If

         If fechaEstado.HasValue Then
            .AppendFormat("   AND PE.FechaEstado = '{0}'", ObtenerFecha(fechaEstado.Value, True)).AppendLine()
         End If

         If idCliente > 0 Then
            .AppendLine("   AND C.IdCliente = " & idCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & idProducto & "'")
         End If

         If idMarca <> 0 Then
            .AppendFormat("	AND Pr.IdMarca = '{0}'", idMarca)
         End If

         If idRubro <> 0 Then
            .AppendFormat("	AND Pr.IdRubro = '{0}'", idRubro)
         End If

         If idSubRubro <> 0 Then
            .AppendFormat("	AND Pr.IdSubRubro = '{0}'", idSubRubro)
         End If

         If tamanio > 0 Then
            .AppendLine("    and pr.Tamano = " & tamanio.ToString())
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idVendedor > 0 Then
            If tipoVendedor <> Entidades.OrigenFK.Movimiento Then
               .AppendLine("   AND C.IdVendedor = " & idVendedor.ToString())
            Else
               .AppendLine("   AND P.IdVendedor = " & idVendedor.ToString())
            End If
         End If


         .AppendLine(" ORDER BY p.FechaPedido, p.IdSucursal, p.IdTipoComprobante, p.letra, p.centroemisor, p.numeropedido, pp.orden, pp.IdProducto")

      End With

      Return GetDataTable(stbQuery)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT P.* ")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,CV.CodigoCliente CodigoClienteVinculado")
         .AppendLine("      ,CV.NombreCliente NombreClienteVinculado")
         .AppendLine("      ,E.TipoDocEmpleado TipoDocVendedor")
         .AppendLine("      ,E.NroDocEmpleado  NroDocVendedor")
         .AppendLine("      ,P.NombreCliente NombreClienteGenerico")
         .AppendLine("  FROM Pedidos P")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = P.IdCliente")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = P.IdVendedor")
         .AppendLine("  LEFT JOIN Clientes CV ON CV.IdCliente = P.IdClienteVinculado")
      End With
   End Sub

   Public Function Pedidos_GA(idSucursal As Integer, drPedidosCol As DataRow()) As DataTable
      Return Pedidos_GA(idSucursal, 0, drPedidosCol)
   End Function
   Public Function Pedidos_GA(idSucursal As Integer, numeroOrdenCompra As Long, drPedidosCol As DataRow()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE P.IdSucursal = {0}", idSucursal).AppendLine()
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

   Public Function Pedidos_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE P.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND P.Letra = '{0}'", letra)
         .AppendFormatLine("   AND P.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND P.NumeroPedido = {0}", numeroPedido)
         .AppendFormatLine("  ORDER BY P.IdSucursal, P.IdTipoComprobante, P.Letra, P.CentroEmisor, P.NumeroPedido")
      End With
      Return GetDataTable(stb)
   End Function

#Region "reporte"

   Public Function GetPedidosDetalleComprobante(idSucursal As Integer,
                                                idEstado As String,
                                                fechaDesde As Date,
                                                fechaHasta As Date,
                                                numeroPedido As Long,
                                                idProducto As String,
                                                idMarca As Integer,
                                                idRubro As Integer,
                                                lote As String,
                                                idCliente As Long,
                                                idUsuario As String,
                                                tamanio As Decimal,
                                                idVendedor As Integer,
                                                tipoVendedor As Entidades.OrigenFK,
                                                ordenCompra As Long,
                                                tipoTipoComprobante As String,
                                                tiposComprobante As Entidades.TipoComprobante(),
                                                 idListaPrecios As Integer,
                                                mostrarAnulacionesPorModificacion As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT P.IdSucursal ")
         .AppendLine(" ,P.IdTipoComprobante AS IdTipoComprobanteP")
         .AppendLine(" ,P.Letra AS LetraP")
         .AppendLine(" ,P.CentroEmisor AS CentroEmisorP")
         .AppendLine(" ,P.NumeroPedido")
         .AppendLine(" ,PE.IdProducto")
         .AppendLine(" ,PE.FechaEstado")
         .AppendLine(" ,PE.Orden")

         .AppendLine("  ,V.IdSucursal IdSucursalFact")
         .AppendLine("	,V.IdTipoComprobante,")
         .AppendLine("	V.Letra,")
         .AppendLine("	V.CentroEmisor,")
         .AppendLine("	V.NumeroComprobante,")
         .AppendLine("	V.Fecha,")
         .AppendLine("	V.IdCliente,")
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
         '.AppendLine("	V.IdTipoComprobanteFact,")
         '.AppendLine("	V.LetraFact,")
         '.AppendLine("	V.CentroEmisorFact,")
         '.AppendLine("	V.NumeroComprobanteFact,")
         .AppendLine("	V.IdCaja,")
         .AppendLine("	V.NumeroPlanilla,")
         .AppendLine("	V.NumeroMovimiento,")
         .AppendLine("	V.ImportePesos,")
         .AppendLine("	V.ImporteTickets,")
         .AppendLine("	V.ImporteTarjetas,")
         .AppendLine("	V.ImporteCheques,")
         .AppendLine("	V.Kilos,")
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

         .AppendLine(" FROM Pedidos P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine("  LEFT JOIN Ventas V ON (V.IdSucursal = PE.IdSucursal")
         .AppendLine("                     AND V.IdTipoComprobante = PE.IdTipoComprobanteFact")
         .AppendLine("                     AND V.Letra = PE.LetraFact")
         .AppendLine("                     AND V.CentroEmisor = PE.CentroEmisorFact")
         .AppendLine("                     AND V.NumeroComprobante = PE.NumeroComprobanteFact) OR")
         .AppendLine("                        (V.IdSucursal = PE.IdSucursalRemito")
         .AppendLine("                     AND V.IdTipoComprobante = PE.IdTipoComprobanteRemito")
         .AppendLine("                     AND V.Letra = PE.LetraRemito")
         .AppendLine("                     AND V.CentroEmisor = PE.CentroEmisorRemito")
         .AppendLine("                     AND V.NumeroComprobante = PE.NumeroComprobanteRemito)")
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

         If idCliente > 0 Then
            .AppendLine("   and C.IdCliente = " & idCliente.ToString())
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & idUsuario & "'")
         End If

         If idListaPrecios > -1 Then
            .AppendFormatLine("   AND PP.IdListaPrecios = '{0}'", idListaPrecios)
         End If
         'If IdVendedor > 0 Then
         '   .AppendLine("   and C.IdVendedor = " & IdVendedor)
         'End If
         If idVendedor > 0 Then
            If tipoVendedor <> Entidades.OrigenFK.Movimiento Then
               .AppendLine("   and C.IdVendedor = " & idVendedor.ToString())
            Else
               .AppendLine("   and P.IdVendedor = " & idVendedor.ToString())
            End If
         End If

         If Not mostrarAnulacionesPorModificacion Then
            .AppendFormatLine("	 AND PE.AnulacionPorModificacion = 'False'")
         End If

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPedidosDetalleComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdSucursal, ")
         .AppendLine("	V.IdTipoComprobante,")
         .AppendLine("	V.Letra,")
         .AppendLine("	V.CentroEmisor,")
         .AppendLine("	V.NumeroComprobante,")
         .AppendLine("	V.Fecha,")
         .AppendLine("	V.IdCliente,")
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
         .AppendLine("	V.Kilos,")
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

         .AppendLine(" FROM Ventas V, Impresoras I")

         .AppendLine(" WHERE I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")

         .AppendLine("   AND V.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND V.Letra = '" & letra & "'")
         .AppendLine("   AND V.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND V.NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPedidosxComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido ")
         .AppendLine(" FROM PedidosEstados  ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobanteFact = '" & idTipoComprobante & "'")
         .AppendLine("   AND LetraFact = '" & letra & "'")
         .AppendLine("   AND CentroEmisorFact = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobanteFact = " & numeroComprobante.ToString())
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPedidosDetalladoXEstadosTodos(idSucursal As Integer,
                                                    idEstado As String,
                                                    fechaDesde As Date,
                                                    fechaHasta As Date,
                                                    tiposComprobante As Entidades.TipoComprobante(),
                                                    letra As String,
                                                    centroEmisor As Short,
                                                    numeroPedidoDesde As Long,
                                                    numeroPedidoHasta As Long,
                                                    idProducto As String,
                                                    idMarca As Integer,
                                                    idRubro As Integer,
                                                    lote As String,
                                                    idCliente As Long,
                                                    idUsuario As String,
                                                    tamanio As Decimal,
                                                    idVendedor As Integer,
                                                    tipoVendedor As Entidades.OrigenFK,
                                                    ordenCompra As Long,
                                                    tipoTipoComprobante As String,
                                                    idProveedor As Long,
                                                    categorias As Entidades.Categoria(),
                                                    origenCategorias As Entidades.OrigenFK,
                                                    numeroReparto As Integer,
                                                    numeroRepartoHasta As Integer,
                                                    idFormasPago As Integer,
                                                    idListaPrecios As Integer,
                                                    mostrarAnulacionesPorModificacion As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT P.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroPedido")
         .AppendLine("     , P.FechaPedido")
         .AppendLine("     , P.IdCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , PP.idProducto")
         .AppendLine("     , PP.NombreProducto")
         .AppendLine("     , PP.Tamano")
         .AppendLine("     , PR.IdUnidadDeMedida")
         .AppendLine("     , PP.Orden")
         .AppendLine("     , PP.Cantidad")
         .AppendLine("     , PE.fechaEstado")
         .AppendLine("     , PE.IdEstado")
         .AppendLine("     , PE.TipoEstadoPedido")
         .AppendLine("     , EP.IdTipoEstado")
         .AppendLine("     , EP.Color")
         .AppendLine("     , (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         '.AppendLine("     , PE.CantEstado AS CantEntregada")
         .AppendLine("     , PE.CantEstado")
         .AppendLine("     , PE.IdSucursalFact")
         .AppendLine("     , PE.IdTipoComprobanteFact")
         .AppendLine("     , PE.LetraFact")
         .AppendLine("     , PE.CentroEmisorFact")
         .AppendLine("     , PE.NumeroComprobanteFact")
         .AppendLine("     , PE.IdUsuario")
         .AppendLine("     , PE.observacion")
         .AppendLine("     , PE.IdCriticidad")
         .AppendLine("     , PE.FechaEntrega")

         .AppendLine("     , PP.IdListaPrecios")
         .AppendLine("     , PP.NombreListaPrecios")
         .AppendLine("      ,PP.UrlPlano")

         .AppendLine("     , PE.IdSucursalRemito")
         .AppendLine("     , PE.IdTipoComprobanteRemito")
         .AppendLine("     , PE.LetraRemito")
         .AppendLine("     , PE.CentroEmisorRemito")
         .AppendLine("     , PE.NumeroComprobanteRemito")

         .AppendLine("     ,PE.IdSucursalGenerado")
         .AppendLine("     ,PE.IdTipoComprobanteGenerado")
         .AppendLine("     ,PE.LetraGenerado")
         .AppendLine("     ,PE.CentroEmisorGenerado")
         .AppendLine("     ,PE.NumeroPedidoGenerado")
         .AppendLine("     ,PE.IdSucursalProduccion")
         .AppendLine("     ,PE.IdTipoComprobanteProduccion")
         .AppendLine("     ,PE.LetraProduccion")
         .AppendLine("     ,PE.CentroEmisorProduccion")
         .AppendLine("     ,PE.NumeroOrdenProduccion")
         .AppendLine("     ,PE.IdProductoProduccion")
         .AppendLine("     ,PE.OrdenProduccion")
         .AppendLine("     ,PE.IdSucursalVinculado")
         .AppendLine("     ,PE.IdTipoComprobanteVinculado")
         .AppendLine("     ,PE.LetraVinculado")
         .AppendLine("     ,PE.CentroEmisorVinculado")
         .AppendLine("     ,PE.NumeroPedidoVinculado")
         .AppendLine("     ,PE.IdProductoProduccion")
         .AppendLine("     ,PE.OrdenProduccion")
         .AppendLine("     ,PE.FechaEstadoVinculado")
         .AppendLine("     ,PE.NumeroReparto")

         .AppendLine("      ,PP.TipoOperacion")
         .AppendLine("      ,PP.Nota")

         .AppendLine("      ,PP.IdFormula")
         .AppendLine("      ,PF.NombreFormula")

         .AppendLine("      ,pp.Costo")
         .AppendLine("      ,PP.PrecioLista")
         .AppendLine("      ,pp.Precio")
         .AppendLine("      ,PP.DescuentoRecargoPorc")
         .AppendLine("      ,PP.DescuentoRecargoPorc2")
         .AppendLine("      ,PP.PrecioNeto")
         .AppendLine("        ,MRPPP.DescripcionProceso
	                           ,MRPPP.CodigoProcesoProductivo")
         .AppendLine("      ,(SELECT COUNT(1) FROM PedidosProductosFormulas PPF")
         .AppendLine("         WHERE PPF.IdSucursal = PP.IdSucursal")
         .AppendLine("           AND PPF.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("           AND PPF.Letra = P.Letra")
         .AppendLine("           AND PPF.CentroEmisor = P.CentroEmisor")
         .AppendLine("           AND PPF.NumeroPedido = P.NumeroPedido")
         .AppendLine("           AND PPF.IdProducto = PP.IdProducto")
         .AppendLine("           AND PPF.Orden = PP.Orden")
         .AppendLine("           AND PPF.Cantidad <> 0) CantComponentes")

         .AppendLine(" FROM Pedidos P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine("   LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         '--------------------
         .AppendFormatLine(" LEFT JOIN Categorias CAT ON CAT.IdCategoria = {0}.IdCategoria", If(origenCategorias = Entidades.OrigenFK.Actual, "C", "P"))
         '--------------------
         .AppendLine(" LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
         .AppendLine("  LEFT JOIN MRPProcesosProductivos MRPPP ON MRPPP.IdProcesoProductivo = PP.IdProcesoProductivo ")
         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND P.Letra = '{0}'", letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND P.CentroEmisor = {0}", centroEmisor)
         End If

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

         If numeroPedidoDesde > 0 Then
            .AppendFormatLine("   AND P.NumeroPedido >= {0} AND P.NumeroPedido <= {1}", numeroPedidoDesde, numeroPedidoHasta)
         End If

         If idCliente > 0 Then
            .AppendLine("   and C.IdCliente = " & idCliente.ToString())
         End If

         If idProveedor <> 0 Then
            .AppendLine("   and OC.IdProveedor = " & idProveedor.ToString())
         End If


         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & idUsuario & "'")
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idVendedor > 0 Then
            If tipoVendedor <> Entidades.OrigenFK.Movimiento Then
               .AppendLine("   and C.IdVendedor = " & idVendedor.ToString())
            Else
               .AppendLine("   and P.IdVendedor = " & idVendedor.ToString())
            End If
         End If

         GetListaCategoriasMultiples(stbQuery, categorias, "CAT")

         If numeroReparto > 0 Then
            .AppendFormatLine("   AND P.NumeroReparto >= {0}", numeroReparto)
         End If

         If numeroRepartoHasta > 0 Then
            .AppendFormatLine("	 AND P.NumeroReparto <= {0}", numeroRepartoHasta)
         End If

         If idFormasPago > 0 Then
            .AppendFormatLine("	 AND P.IdFormasPago = {0}", idFormasPago)
         End If

         If idListaPrecios > -1 Then
            .AppendFormatLine("	 AND PP.IdListaPrecios = {0}", idListaPrecios)
         End If

         If Not mostrarAnulacionesPorModificacion Then
            .AppendFormatLine("	 AND PE.AnulacionPorModificacion = 'False'")
         End If

         '-- REQ-32831.- --
         .AppendLine(" ORDER BY PP.ORDEN")

      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidosDetalladoXEstados(idSucursal As Integer,
                                               idEstado As String,
                                               fechaDesde As Date,
                                               fechaHasta As Date,
                                               fechaDesdeEntrega As Date?,
                                               fechaHastaEntrega As Date?,
                                               numeroPedido As Long,
                                               idProducto As String,
                                               idMarca As Integer,
                                               idRubro As Integer,
                                               lote As String,
                                               idCliente As Long,
                                               idIdUsuario As String,
                                               tamanio As Decimal,
                                               idVendedor As Integer,
                                               ordenCompra As Long,
                                               tipoTipoComprobante As String,
                                               tiposComprobante As Entidades.TipoComprobante(),
                                               espPulgadas As String,
                                               espmm As Decimal?,
                                               sae As Integer?,
                                               idProceso As Integer,
                                               idProveedor As Long,
                                               idZonaGeografica As String,
                                               listaPrecios As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.Observacion as ObservacionGeneral")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.NumeroOrdenCompra")
         .AppendLine("      ,P.IdCliente, C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia")

         .AppendLine("     , L.IdLocalidad")
         .AppendLine("     , L.NombreLocalidad")
         .AppendLine("     , Pv.IdProvincia")
         .AppendLine("     , Pv.NombreProvincia")

         .AppendLine("    	 ,P.CotizacionDolar")
         .AppendLine("      ,(PP.ImporteTotalNeto / PP.Cantidad * PE.CantEstado) AS SubTotal")
         .AppendLine("      ,(PP.ImporteImpuestoInterno / PP.Cantidad * PE.CantEstado) AS TotalImpuestoInterno")
         .AppendLine("      ,(PP.ImporteImpuesto / PP.Cantidad * PE.CantEstado) AS TotalImpuestos")
         .AppendLine("      ,(PP.ImporteTotalNeto + PP.ImporteImpuestoInterno + PP.ImporteImpuesto / PP.Cantidad * PE.CantEstado) AS ImporteTotal")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano AS TamanoProducto, Pr.IdUnidadDeMedida AS IdUnidadDeMedidaProducto, pp.Orden, PS.Ubicacion")
         .AppendLine("       ,(pp.Costo * PE.CantEstado) AS Costo")
         .AppendLine("      ,pp.Cantidad AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      ,PE.CantEstado AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.Observacion")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")

         .AppendLine("      ,PP.PrecioVentaPorTamano")
         .AppendLine("      ,PP.Tamano")
         .AppendLine("      ,CONVERT(DECIMAL(9,2), PP.Tamano * PP.Cantidad) TamanoTotal")
         .AppendLine("      ,PP.IdUnidadDeMedida")
         .AppendLine("      ,PP.IdMoneda")
         .AppendLine("      ,MO.NombreMoneda")
         .AppendLine("      ,MO.Simbolo")
         .AppendLine("      ,PP.IdProduccionProceso")
         .AppendLine("      ,PRP.NombreProduccionProceso")
         .AppendLine("      ,PP.IdProduccionForma")
         .AppendLine("      ,PRF.NombreProduccionForma")
         .AppendLine("      ,PP.Espmm")
         .AppendLine("      ,PP.EspPulgadas")
         .AppendLine("      ,PP.CodigoSAE")
         .AppendLine("      ,PP.LargoExtAlto")
         .AppendLine("      ,PP.AnchoIntBase")
         .AppendLine("      ,PP.UrlPlano")
         .AppendLine("      ,PP.TipoOperacion")
         .AppendLine("      ,PP.Nota")
         .AppendLine("      ,EP.Color")

         .AppendLine("      ,PP.IdFormula")
         .AppendLine("      ,PF.NombreFormula")

         .AppendLine("      ,pp.Costo As CostoActual")
         .AppendLine("      ,PP.PrecioLista")
         .AppendLine("      ,pp.Precio")
         .AppendLine("      ,PP.DescuentoRecargoPorc")
         .AppendLine("      ,PP.DescuentoRecargoPorc2")
         .AppendLine("      ,PP.PrecioNeto")
         .AppendLine("      ,EE.NombreEmpleado as Vendedor")

         .AppendLine("      ,(SELECT COUNT(1) FROM PedidosProductosFormulas PPF")
         .AppendLine("         WHERE PPF.IdSucursal = PP.IdSucursal")
         .AppendLine("           AND PPF.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("           AND PPF.Letra = P.Letra")
         .AppendLine("           AND PPF.CentroEmisor = P.CentroEmisor")
         .AppendLine("           AND PPF.NumeroPedido = P.NumeroPedido")
         .AppendLine("           AND PPF.IdProducto = PP.IdProducto")
         .AppendLine("           AND PPF.Orden = PP.Orden) CantComponentes")
         .AppendLine("           ,LP.NombreListaPrecios")


         .AppendLine(" FROM Pedidos P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")

         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = TC.Tipo")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine("  LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  LEFT JOIN Provincias Pv ON Pv.IdProvincia = L.IdProvincia")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = PP.IdProduccionForma")
         .AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = PP.IdProduccionProceso")
         .AppendLine(" LEFT JOIN Monedas MO ON MO.IdMoneda = PP.IdMoneda")
         .AppendLine(" LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         .AppendLine(" LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
         .AppendLine(" LEFT JOIN Empleados EE ON EE.IdEmpleado = P.IdVendedor")
         .AppendLine("INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = PP.IdListaPrecios")
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

         If fechaDesdeEntrega.HasValue Then
            .AppendFormat("   AND p.FechaPedido >= '{0}'", ObtenerFecha(fechaDesdeEntrega.Value, True))
            .AppendFormat("   AND p.FechaPedido <= '{0}'", ObtenerFecha(fechaHastaEntrega.Value, True))
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

         If idCliente > 0 Then
            .AppendLine("   and C.IdCliente = " & idCliente) ''1'
         End If

         If idProveedor <> 0 Then
            .AppendLine("   and OC.IdProveedor = " & idProveedor.ToString())
         End If

         If Not String.IsNullOrEmpty(idIdUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & idIdUsuario & "'")
         End If

         If tamanio > 0 Then
            .AppendLine("    and pr.tamano = " & tamanio.ToString())
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idVendedor > 0 Then
            .AppendLine("   and C.IdVendedor = " & idVendedor)
         End If

         If Not String.IsNullOrWhiteSpace(espPulgadas) Then
            .AppendFormat("   AND PP.EspPulgadas = '{0}'", espPulgadas)
         End If

         If espmm.HasValue Then
            .AppendFormat("   AND PP.Espmm = {0}", espmm.Value)
         End If

         If sae.HasValue Then
            .AppendFormat("   AND PP.CodigoSAE = {0}", sae.Value)
         End If

         If idProceso > 0 Then
            .AppendFormat("   AND PP.IdProduccionProceso = {0}", idProceso)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendLine("	 AND C.IdZonaGeografica = '" & idZonaGeografica & "'")
         End If

         If Not String.IsNullOrEmpty(listaPrecios) Then
            .AppendFormatLine("	AND PP.NombreListaPrecios = '{0}'", listaPrecios)
         End If

         .AppendLine(" ORDER BY p.fechaPedido")

      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidosEstadosProductos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long,
                                              idProducto As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine(" ,P.IdTipoComprobante")
         .AppendLine(" ,P.Letra")
         .AppendLine(" ,P.CentroEmisor")
         .AppendLine(" ,P.NumeroPedido")
         .AppendLine(" ,P.FechaPedido")
         .AppendLine("      ,P.IdCliente, C.CodigoCliente, C.NombreCliente")
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
         .AppendLine(" FROM Pedidos P")

         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
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

   Public Function pedidosCabecera(sucursales As Entidades.Sucursal(),
                                   idEstado As String, alMenosUno_TodosSean As Boolean,
                                   fechaDesde As Date,
                                   fechaHasta As Date,
                                   tiposComprobante As Entidades.TipoComprobante(),
                                   letra As String,
                                   centroEmisor As Short,
                                   numeroPedidoDesde As Long,
                                   numeroPedidoHasta As Long,
                                   idCliente As Long,
                                   idIdUsuario As String,
                                   IdVendedor As Integer,
                                   TipoVendedor As Entidades.OrigenFK,
                                   ordenCompra As Long,
                                   tipoTipoComprobante As String,
                                   idProveedor As Long,
                                   categorias As Entidades.Categoria(),
                                   origenCategorias As Entidades.OrigenFK,
                                   numeroReparto As Integer,
                                   numeroRepartoHasta As Integer,
                                   idFormasPago As Integer,
                                   idListaPrecios As Integer,
                                   impreso As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT 'FALSE' as anula")
         .AppendLine("     , p.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroPedido")
         .AppendLine("     , c.IdCliente")
         .AppendLine("     , c.CodigoCliente")
         .AppendLine("     , c.NombreCliente")

         .AppendLine("     , L.IdLocalidad")
         .AppendLine("     , L.NombreLocalidad")
         .AppendLine("     , Pv.IdProvincia")
         .AppendLine("     , Pv.NombreProvincia")

         .AppendLine("     , P.IdClienteVinculado")
         .AppendLine("     , CV.CodigoCliente CodigoClienteVinculado")
         .AppendLine("     , CV.NombreCliente NombreClienteVinculado")

         .AppendLine("     , p.FechaPedido")
         .AppendLine("     , p.IdUsuario")
         .AppendLine("     , p.Observacion")
         .AppendLine("     , ISNULL(P.ObservacionInterna, '') AS ObservacionInterna")
         .AppendLine("     , ISNULL(P.ObservacionInterna, '') AS ObservacionInterna_Original")
         .AppendLine("     , p.NumeroOrdenCompra")
         .AppendLine("     , p.ImporteTotal")
         .AppendLine("     ,E.NombreEmpleado As NombreVendedor")
         .AppendLine("     , CONVERT(decimal(9,2), ")
         .AppendLine("               (SELECT CASE WHEN SUM(PP.Cantidad) = 0 THEN 0 ELSE SUM(PP.CantPendiente + PP.CantEnProceso) / SUM(PP.Cantidad) END")
         .AppendLine("          FROM PedidosProductos PP")
         .AppendLine("         WHERE PP.IdSucursal = P.IdSucursal")
         .AppendLine("           AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("           AND PP.Letra = P.Letra")
         .AppendLine("           AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("           AND PP.NumeroPedido = P.NumeroPedido) * 100) AS PorcPendiente")

         ''.AppendLine("     , (CantEntregada + CantAnulada) / Cantidad")
         .AppendLine("     ,(SELECT COUNT(PCC.IdSucursal)")
         .AppendLine("  FROM PedidosClientesContactos PCC WHERE P.IdSucursal = PCC.IdSucursal AND P.NumeroPedido = PCC.NumeroPedido")
         .AppendLine(" AND P.IdTipoComprobante = PCC.IdTipoComprobante AND P.Letra = PCC.Letra")
         .AppendLine(" 	AND P.CentroEmisor = PCC.CentroEmisor) AS CantidadContactos")

         .AppendLine("     , P.Palets")
         .AppendLine("     , P.NroVersionAplicacion")
         .AppendLine("     , P.NroVersionRemoto")

         .AppendLine(" FROM Pedidos P")

         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine("  LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  LEFT JOIN Provincias Pv ON Pv.IdProvincia = L.IdProvincia")
         .AppendLine("  LEFT JOIN Clientes CV ON CV.IdCliente = P.IdClienteVinculado ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("  LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")

         '--------------------
         .AppendFormatLine(" LEFT JOIN Categorias CAT ON CAT.IdCategoria = {0}.IdCategoria", If(origenCategorias = Entidades.OrigenFK.Actual, "C", "CV"))

         '--------------------

         If TipoVendedor <> Entidades.OrigenFK.Movimiento Then
            .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor ")
         Else
            .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = P.IdVendedor ")
         End If
         .AppendLine(" WHERE 1 = 1")

         '.AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())

         GetListaSucursalesMultiples(stbQuery, sucursales, "P")

         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()
         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND P.Letra = '{0}'", letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND P.CentroEmisor = {0}", centroEmisor)
         End If

         If idListaPrecios > -1 Then
            .AppendFormatLine("   AND EXISTS(SELECT * FROM PedidosProductos PP")
            .AppendFormatLine("               WHERE PP.IdSucursal = P.IdSucursal")
            .AppendFormatLine("                 AND PP.IdTipoComprobante = P.IdTipoComprobante")
            .AppendFormatLine("                 AND PP.Letra = P.Letra")
            .AppendFormatLine("                 AND PP.CentroEmisor = P.CentroEmisor")
            .AppendFormatLine("                 AND PP.NumeroPedido = P.NumeroPedido")

            .AppendFormatLine("                 AND PP.IdListaPrecios = {0}", idListaPrecios)
            .AppendFormatLine("              )")
         End If


         If idEstado <> "TODOS" Then
            .AppendFormatLine("   AND {0} EXISTS(SELECT * FROM PedidosEstados PE", If(alMenosUno_TodosSean, "", "NOT"))
            .AppendLine("                      INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado")
            .AppendLine("                      WHERE PE.IdSucursal = P.IdSucursal")
            .AppendLine("                        AND PE.IdTipoComprobante = P.IdTipoComprobante")
            .AppendLine("                        AND PE.Letra = P.Letra")
            .AppendLine("                        AND PE.CentroEmisor = P.CentroEmisor")
            .AppendLine("                        AND PE.NumeroPedido = P.NumeroPedido")

            If idEstado = "SOLO PENDIENTES" Then
               .AppendFormatLine("                        AND {0} EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO'))", If(alMenosUno_TodosSean, "", "NOT"))
            ElseIf idEstado = "SOLO EN PROCESO" Then
               .AppendFormatLine("                        AND EP.IdTipoEstado {0} 'EN PROCESO')", If(alMenosUno_TodosSean, "=", "<>"))
            Else
               .AppendFormatLine("                        AND EP.IdEstado {1} '{0}')", idEstado, If(alMenosUno_TodosSean, "=", "<>"))
            End If
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND P.FechaPedido >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND P.FechaPedido <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroPedidoDesde > 0 Then
            .AppendFormatLine("   AND P.NumeroPedido >= {0} AND P.NumeroPedido <= {1}", numeroPedidoDesde, numeroPedidoHasta)
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idCliente <> 0 Then
            .AppendLine("   and C.IdCliente = " & idCliente.ToString())
         End If

         If idProveedor <> 0 Then
            .AppendLine("   and OC.IdProveedor = " & idProveedor.ToString())
         End If

         If Not String.IsNullOrEmpty(idIdUsuario) Then
            .AppendLine("    and P.IdUsuario = '" & idIdUsuario & "'")
         End If

         If IdVendedor > 0 Then
            If TipoVendedor <> Entidades.OrigenFK.Movimiento Then
               .AppendLine("   and C.IdVendedor = " & IdVendedor.ToString())
            Else
               .AppendLine("   and P.IdVendedor = " & IdVendedor.ToString())
            End If
         End If

         'Else
         '.AppendLine("   and C.IdVendedor = P." & IdVendedor.ToString())
         'End If

         GetListaCategoriasMultiples(stbQuery, categorias, "CAT")

         If numeroReparto > 0 Then
            .AppendFormatLine("   AND P.NumeroReparto >= {0}", numeroReparto)
         End If

         If numeroRepartoHasta > 0 Then
            .AppendFormatLine("	 AND P.NumeroReparto <= {0}", numeroRepartoHasta)
         End If

         If idFormasPago > 0 Then
            .AppendFormatLine("	 AND P.IdFormasPago = {0}", idFormasPago)
         End If

         Select Case impreso
            Case Entidades.Publicos.SiNoTodos.SI : .Append(" AND P.FechaImpresion < GETDATE()")
            Case Entidades.Publicos.SiNoTodos.NO : .Append(" AND P.FechaImpresion IS NULL")
            Case Else : .Append("")
         End Select

         .AppendLine(" ORDER BY P.fechaPedido")

      End With

      Return GetDataTable(stbQuery)
   End Function

#End Region
#Region "PROCESO FACTURA"

   Public Function GetPedidosXClienteProducto(idSucursal As Integer,
                                              idEstado As String,
                                              idProducto As String,
                                              idCliente As Long,
                                              facturables As IEnumerable(Of Entidades.IPKComprobante),
                                              tipoTipoComprobante As String,
                                              buscoConFactNulo As Boolean,
                                              buscoConRemitoNulo As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.IdCliente ")
         .AppendLine("      ,pp.idProducto, pp.orden")
         .AppendLine("      ,pp.Cantidad")
         .AppendLine("      , pe.idEstado ")
         .AppendLine("      ,pe.CantEstado AS CantEntregada ")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN pe.CantEstado ELSE 0 END) AS CantPendiente ")
         .AppendLine("      ,pe.IdSucursal AS IdSucursalFact ")
         .AppendLine("      ,pe.IdTipoComprobanteFact ")
         .AppendLine("      ,pe.LetraFact ")
         .AppendLine("      ,pe.CentroEmisorFact ")
         .AppendLine("      ,pe.NumeroComprobanteFact ")
         .AppendLine("      ,pe.FechaEstado ")
         .AppendLine("      ,pe.IdCriticidad")
         .AppendLine("      ,pe.FechaEntrega")
         .AppendLine("      ,pe.IdSucursalRemito")
         .AppendLine("      ,pe.IdTipoComprobanteRemito")
         .AppendLine("      ,pe.LetraRemito")
         .AppendLine("      ,pe.CentroEmisorRemito")
         .AppendLine("      ,pe.NumeroComprobanteRemito")

         .AppendLine("      ,pe.IdSucursalGenerado")
         .AppendLine("      ,pe.IdTipoComprobanteGenerado")
         .AppendLine("      ,pe.LetraGenerado")
         .AppendLine("      ,pe.CentroEmisorGenerado")
         .AppendLine("      ,pe.NumeroPedidoGenerado")

         .AppendLine("      ,pe.IdSucursalProduccion")
         .AppendLine("      ,pe.IdTipoComprobanteProduccion")
         .AppendLine("      ,pe.LetraProduccion")
         .AppendLine("      ,pe.CentroEmisorProduccion")
         .AppendLine("      ,pe.NumeroOrdenProduccion")

         .AppendLine("      ,pe.IdSucursalVinculado, pe.IdTipoComprobanteVinculado, pe.LetraVinculado, pe.CentroEmisorVinculado, pe.NumeroPedidoVinculado, pe.IdProductoVinculado, pe.OrdenVinculado, pe.FechaEstadoVinculado")

         .AppendLine("      ,PS.IdDepositoDefecto")
         .AppendLine("      ,SD.NombreDeposito ")
         .AppendLine("      ,PS.IdUbicacionDefecto")
         .AppendLine("      ,SU.NombreUbicacion ")

         .AppendLine(" FROM Pedidos P ")

         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto ")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante ")

         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PP.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" INNER JOIN SucursalesDepositos SD ON  SD.IdSucursal = P.IdSucursal AND SD.IdDeposito = PS.IdDepositoDefecto")
         .AppendLine(" INNER JOIN SucursalesUbicaciones SU ON  SU.IdSucursal = P.IdSucursal AND SU.IdDeposito = PS.IdDepositoDefecto AND SU.IdUbicacion = PS.IdUbicacionDefecto ")

         .AppendFormat(" WHERE TC.Tipo='{0}'", tipoTipoComprobante).AppendLine()

         If idSucursal > 0 Then
            .AppendLine("   AND p.IdSucursal = " & idSucursal.ToString())
         End If
         .AppendLine("   AND p.IdCliente=" & idCliente)
         .AppendLine("   AND pp.IdProducto = '" & idProducto & "'")
         If Not String.IsNullOrWhiteSpace(idEstado) Then
            .AppendLine("   AND PE.IdEstado = '" & idEstado & "' ")
         End If
         .AppendFormat("   AND PE.IdEstado <> '{0}'", Entidades.EstadoPedido.ESTADO_ANULADO).AppendLine()
         If buscoConFactNulo Then
            .AppendLine("   AND PE.NumeroComprobanteFact IS NULL")
         End If
         If buscoConRemitoNulo Then
            .AppendLine("   AND PE.NumeroComprobanteRemito IS NULL")
         End If
         If facturables IsNot Nothing AndAlso facturables.Count > 0 Then
            .Append("   AND (1 = 2 ")
            For Each pedido In facturables
               Dim andOrden = String.Empty
               If TypeOf (pedido) Is Entidades.PedidoProducto Then
                  andOrden = String.Format(" AND PE.Orden = {0}", DirectCast(pedido, Entidades.PedidoProducto).Orden)
               End If

               .AppendFormat("OR (PE.IdSucursal = {4} AND PE.IdTipoComprobante = '{0}' AND PE.Letra = '{1}' AND PE.CentroEmisor = {2} AND PE.NumeroPedido = {3}{5})",
                              pedido.IdTipoComprobante, pedido.Letra, pedido.CentroEmisor, pedido.NumeroComprobante, pedido.IdSucursal, andOrden)
            Next
            .AppendLine(")")
         End If
         .AppendLine(" ORDER BY p.fechaPedido ")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidosSumaPorProductos(idSucursal As Integer,
                                              idEstado As String,
                                              fechaDesde As Date,
                                              fechaHasta As Date,
                                              idCliente As Long,
                                              idVendedor As Integer,
                                              idMarca As Integer,
                                              idRubro As Integer,
                                              idSubRubro As Integer,
                                              idProducto As String,
                                              tamanio As Decimal,
                                              ordenCompra As Decimal,
                                              tipoTipoComprobante As String,
                                              idProveedor As Long) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.Tamano, Pr.IdUnidadDeMedida")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,SUM(PP.ImporteTotal / PP.Cantidad * PE.CantEstado) AS ImporteTotal")
         .AppendLine("      ,SUM(PE.CantEstado) AS Cantidad")
         .AppendLine("      ,SUM(PE.CantEstado * Pr.Kilos) AS Kilos")
         .AppendLine(" FROM Pedidos P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")

         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido ")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PR.IdProducto AND PS.IdSucursal = P.IdSucursal")
         .AppendLine(" LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")

         .AppendLine(" WHERE PE.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

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

         If idCliente > 0 Then
            .AppendLine("   and C.IdCliente = " & idCliente.ToString())
         End If

         If idProveedor <> 0 Then
            .AppendLine("   and OC.IdProveedor = " & idProveedor.ToString())
         End If

         If idVendedor > 0 Then
            .AppendLine("   and C.IdVendedor = " & idVendedor)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & idProducto & "'")
         End If

         If idMarca <> 0 Then
            .AppendLine("    and pr.IdMarca = " & idMarca.ToString())
         End If

         If idRubro <> 0 Then
            .AppendLine("    and pr.IdRubro = " & idRubro.ToString())
         End If

         If tamanio > 0 Then
            .AppendLine("    and pr.Tamano = " & tamanio.ToString())
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         .AppendLine(" GROUP BY M.NombreMarca, R.NombreRubro, pp.idProducto, pp.NombreProducto, pr.Tamano, Pr.IdUnidadDeMedida, PS.Stock")
         .AppendLine(" ORDER BY pp.NombreProducto, pp.idProducto")
      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidosParaGenerarPedidoProv(idSucursal As Integer, idProveedor As Long,
                                                   idMarca As Integer, idRubro As Integer, idSubRubro As Integer,
                                                   idProducto As String, ordenCompra As Decimal,
                                                   oCObligatoria As Boolean,
                                                   fechaDesde As Date?, fechaHasta As Date?,
                                                   idEstado As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,pp.IdProducto, pp.NombreProducto")
         .AppendLine("      ,PS.Stock")
         If oCObligatoria Then
            .AppendLine("      ,CASE WHEN OC.RespetaPreciosOrdenCompra = 0 THEN PS.PrecioCosto ELSE PP.Precio END AS PrecioCosto")
         Else
            .AppendLine(", PS.PrecioCosto AS PrecioCosto ")
         End If

         .AppendLine("      ,0.00 Estimativo")
         .AppendLine("      ,P.NumeroOrdenCompra")
         If ordenCompra <> 0 Then
            .AppendLine("      ,OC.IdProveedor ")
            .AppendLine("      ,OC.RespetaPreciosOrdenCompra")
            .AppendLine("      ,PRO.CodigoProveedor")
            .AppendLine("      ,PRO.NombreProveedor")
         End If

         .AppendLine("      ,SUM(PE.CantEstado) AS Cantidad")
         ' .AppendLine("      ,SUM(PE.CantEstado * Pr.Kilos) AS Kilos")
         .AppendLine(" FROM Pedidos P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")

         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido ")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PR.IdProducto AND PS.IdSucursal = P.IdSucursal")

         If oCObligatoria Then
            .AppendLine(" INNER JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
            .AppendLine(" INNER JOIN Proveedores PRO ON PRO.IdProveedor = OC.IdProveedor ")
         End If
         .AppendLine(" WHERE PE.IdSucursal = " & idSucursal.ToString())
         '.AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND P.FechaPedido >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND P.FechaPedido <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         If idEstado <> "TODOS" Then
            .AppendLine("   AND EXISTS(SELECT * FROM PedidosEstados PE")
            .AppendLine("                      INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado")
            .AppendLine("                      WHERE PE.IdSucursal = P.IdSucursal")
            .AppendLine("                        AND PE.IdTipoComprobante = P.IdTipoComprobante")
            .AppendLine("                        AND PE.Letra = P.Letra")
            .AppendLine("                        AND PE.CentroEmisor = P.CentroEmisor")
            .AppendLine("                        AND PE.NumeroPedido = P.NumeroPedido")

            If idEstado = "SOLO PENDIENTES" Then
               .AppendLine("                        AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO'))")
               .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
            ElseIf idEstado = "SOLO EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado = 'EN PROCESO')")
               .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
            Else
               .AppendFormatLine("                        AND EP.IdEstado = '{0}')", idEstado)
               .AppendFormatLine("   AND EP.IdEstado = '{0}'", idEstado)
            End If

         End If

         '   .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO', 'ENTREGADO')")

         'If IdCliente > 0 Then
         '   .AppendLine("   and C.IdCliente = " & IdCliente.ToString())
         'End If

         If idProveedor <> 0 And oCObligatoria Then
            .AppendLine("   AND OC.IdProveedor = " & idProveedor)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & idProducto & "'")
         End If

         If idMarca <> 0 Then
            .AppendLine("    and pr.IdMarca = " & idMarca.ToString())
         End If

         If idRubro <> 0 Then
            .AppendLine("    and pr.IdRubro = " & idRubro.ToString())
         End If

         If ordenCompra > 0 And oCObligatoria Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         .AppendLine(" GROUP BY M.NombreMarca, R.NombreRubro, pp.idProducto, pp.NombreProducto, pr.Tamano, ")
         '.AppendLine("  Pr.IdUnidadDeMedida, PS.Stock, PS.PrecioCosto  ,P.NumeroOrdenCompra")
         .AppendLine("  Pr.IdUnidadDeMedida, PS.Stock,P.NumeroOrdenCompra")
         If oCObligatoria Then
            .AppendLine(" , OC.IdProveedor, PRO.CodigoProveedor ,PRO.NombreProveedor , OC.RespetaPreciosOrdenCompra")
            .AppendLine(" , CASE WHEN OC.RespetaPreciosOrdenCompra = 0 THEN PS.PrecioCosto ELSE PP.Precio END")
         Else
            .AppendLine(" , PS.PrecioCosto")
         End If
         '-- REQ-35213.- ------------
         '.AppendLine(" , PP.Precio")
         '---------------------------
         .AppendLine(" ORDER BY pp.NombreProducto, pp.idProducto")
      End With

      Return GetDataTable(stbQuery)
   End Function

#End Region

   Public Function VerificaPedidoModificable(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT (SELECT COUNT(1) FROM PedidosProductos AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroPedido = P.NumeroPedido) AS PedidosProductos")
         .AppendLine("      ,(SELECT COUNT(1) FROM PedidosEstados   AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroPedido = P.NumeroPedido) AS PedidosEstados")
         .AppendLine("      ,(SELECT COUNT(1) FROM PedidosEstados   AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine("                                                      AND PP.IdEstado <> EP.idEstado) AS PedidosEstadosNoPendientes")
         .AppendLine("  FROM Pedidos AS P")
         .AppendLine(" CROSS JOIN EstadosPedidos AS EP")
         .AppendFormatLine(" WHERE P.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND P.Letra = '{0}'", letra)
         .AppendFormatLine("   AND P.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND P.NumeroPedido = {0}", numeroPedido)
         .AppendFormatLine("   AND EP.IdTipoEstado = '{0}'", Entidades.EstadoPedido.ESTADO_ALTA)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPedido(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short?, numeroPedido As Long?,
                             idCliente As Long?, fechaPed As Date?,
                             ordenCompra As Long?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT * FROM Pedidos AS P")
         .AppendFormat(" WHERE 1 = 1", idCliente).AppendLine()
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

         If idCliente.HasValue AndAlso idCliente.Value <> 0 Then
            .AppendFormat("   AND P.IdCliente = {0}", idCliente.Value).AppendLine()
         End If

         If ordenCompra.HasValue AndAlso ordenCompra.Value <> 0 Then
            .AppendFormat("   AND P.NumeroOrdenCompra = {0}", ordenCompra.Value).AppendLine()
         End If

         If fechaPed.HasValue Then
            .AppendFormat("   AND P.FechaPedido = '{0}'", ObtenerFecha(fechaPed.Value, True)).AppendLine()
         End If

         .AppendFormatLine("   AND EXISTS (SELECT * FROM PedidosEstados PE")
         .AppendFormatLine("         WHERE PE.IdSucursal = P.IdSucursal")
         .AppendFormatLine("                      AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("                      AND PE.Letra = P.Letra")
         .AppendFormatLine("                      AND PE.CentroEmisor = P.CentroEmisor")
         .AppendFormatLine("                      AND PE.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine("                      AND PE.IdEstado <> 'ANULADO')")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function ExistePedido(idSucursal As Integer, idCliente As Long, fechaPed As Date) As Boolean
      Return GetPedido(idSucursal, String.Empty, String.Empty, Nothing, Nothing, idCliente, fechaPed, Nothing).Rows.Count > 0
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

   Public Function ExistePedido(idSucursal As Integer, idTipoComprobante As String, idCliente As Long, ordenCompra As Long) As Boolean
      Return GetPedido(idSucursal, idTipoComprobante, String.Empty, Nothing, Nothing, idCliente, Nothing, ordenCompra).Rows.Count > 0
   End Function

   Public Sub Actualizar_Palets_Pedidos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                        cantidadPalets As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE Pedidos ").AppendLine()
         .AppendFormat("   SET Palets = {0}", cantidadPalets).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
      End With
      Execute(myQuery)
   End Sub
   Public Sub ActualizarComprobantePorComprobante(idSucursal As Integer,
                                                  idTipoComprobanteActual As String,
                                                  letraActual As String,
                                                  centroEmisorActual As Integer,
                                                  numeroComprobanteActual As Long,
                                                  idTipoComprobanteNuevo As String,
                                                  letraNuevo As String,
                                                  centroEmisorNuevo As Integer,
                                                  numeroComprobanteNuevo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE PedidosEstados")
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

   Public Sub ActualizarComprobantePorComprobanteRemito(idSucursal As Integer,
                                                        idTipoComprobanteActual As String,
                                                        letraActual As String,
                                                        centroEmisorActual As Integer,
                                                        numeroComprobanteActual As Long,
                                                        idTipoComprobanteNuevo As String,
                                                        letraNuevo As String,
                                                        centroEmisorNuevo As Integer,
                                                        numeroComprobanteNuevo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE PedidosEstados")
         .AppendFormat("   SET IdTipoComprobanteRemito = '{0}'", idTipoComprobanteNuevo)
         .AppendFormat("      ,LetraRemito = '{0}'", letraNuevo)
         .AppendFormat("      ,CentroEmisorRemito = {0}", centroEmisorNuevo)
         .AppendFormat("      ,NumeroComprobanteRemito = {0}", numeroComprobanteNuevo)
         .AppendFormat("   WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("     AND IdTipoComprobanteRemito = '{0}'", idTipoComprobanteActual)
         .AppendFormat("     AND LetraRemito = '{0}'", letraActual)
         .AppendFormat("     AND CentroEmisorRemito = {0}", centroEmisorActual)
         .AppendFormat("     AND NumeroComprobanteRemito = {0}", numeroComprobanteActual)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ActualizarObservacionInterna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long, observacionInternaNueva As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Pedidos")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.Pedido.Columnas.ObservacionInterna.ToString(), observacionInternaNueva)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Pedido.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.Pedido.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.Pedido.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.Pedido.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.Pedido.Columnas.NumeroPedido.ToString(), numeroPedido)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ActualizaFechaImpresion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long)
      Dim myQuery = New StringBuilder()
      Dim gen As Generales = New Generales(_da)
      With myQuery
         .Append("UPDATE Pedidos SET ")
         .AppendFormat("  FechaImpresion = '{0}'", gen.GetServerDBFechaHora().ToString("yyyyMMdd HH:mm:ss"))

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND letra = '{0}'", letra)
         .AppendFormat("   AND centroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND numeroPedido = {0}", numeroPedido)

      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Pedidos")
   End Sub

   Public Sub PedidosProductos_U_FechaEnvio(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long,
                                            fecEnvio As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PP")
         .AppendFormatLine("   SET FechaEntrega = '{0}'", ObtenerFecha(fecEnvio, True))
         .AppendFormatLine("  FROM PedidosProductos AS PP")
         .AppendFormatLine(" WHERE PP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND PP.Letra = '{0}'", letra)
         .AppendFormatLine("   AND PP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND PP.NumeroPedido = {0}", numeroPedido)
      End With
      Execute(myQuery)
   End Sub

   Public Sub PedidosEstados_U_FechaEnvio(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long,
                                          fecEnvio As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PedidosEstados ")
         .AppendFormatLine("   SET FechaEntrega = '{0}'", ObtenerFecha(fecEnvio, True))
         .AppendFormatLine("  FROM PedidosEstados AS PE")
         .AppendFormatLine(" INNER JOIN EstadosPedidos AS EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = 'PEDIDOSCLIE'")
         .AppendFormatLine(" WHERE EP.IdTipoEstado = '{0}'", Eniac.Entidades.EstadoPedido.TipoEstado.PENDIENTE)
         .AppendFormatLine("   AND PE.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PE.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND PE.Letra = '{0}'", letra)
         .AppendFormatLine("   AND PE.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND PE.NumeroPedido = {0}", numeroPedido)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Pedidos_RespDist(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                               idTransportista As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE Pedidos ").AppendLine()
         .AppendFormat("   SET IdTransportista = {0}", idTransportista).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
      End With
      Execute(myQuery)
   End Sub

   Public Sub Pedidos_FormaPago(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                idFormaPago As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE Pedidos ").AppendLine()
         .AppendFormat("   SET IdFormasPago = {0}", idFormaPago).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
      End With
      Execute(myQuery)
   End Sub

   Public Sub Pedidos_TipoCompFact(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                   idTipoComprobanteFact As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE Pedidos ").AppendLine()
         .AppendFormat("   SET IdTipoComprobanteFact = '{0}'", idTipoComprobanteFact).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
      End With
      Execute(myQuery)
   End Sub

   Private Sub GetInfPedidosFacturadosQuery(stb As StringBuilder,
                                            fechaDesde As Date?, fechaHasta As Date?,
                                            idCliente As Long?,
                                            tolerancia As Decimal)
      With stb
         .AppendFormatLine("SELECT P.IdSucursal IdSucursal_Pedido, P.IdTipoComprobante IdTipoComprobante_Pedido, P.Letra Letra_Pedido, P.CentroEmisor CentroEmisor_Pedido, P.NumeroPedido")
         .AppendFormatLine("     , PE.IdEstado")
         .AppendFormatLine("     , P.FechaPedido")
         .AppendFormatLine("     , V.IdSucursal IdSucursal_Venta, V.IdTipoComprobante IdTipoComprobante_Venta, V.Letra Letra_Venta, V.CentroEmisor CentroEmisor_Venta, V.NumeroComprobante")
         .AppendFormatLine("     , V.Fecha FechaVenta")
         .AppendFormatLine("     , P.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendFormatLine("     , PP.IdProducto")
         .AppendFormatLine("     , PR.NombreProducto")
         .AppendFormatLine("     , PE.CantEstado Cantidad_Pedido")
         .AppendFormatLine("     , VP.Cantidad   Cantidad_Venta")
         .AppendFormatLine("     , ROUND(PP.Precio, 2) Precio_Pedido")
         .AppendFormatLine("     , PP.DescuentoRecargoPorc DescuentoRecargoPorc_Pedido")
         .AppendFormatLine("     , PP.DescuentoRecargoPorc2 DescuentoRecargoPorc2_Pedido")
         .AppendFormatLine("     , ROUND(PP.PrecioNeto, 2) PrecioNeto_Pedido")
         .AppendFormatLine("     , ROUND(VP.Precio, 2) Precio_Venta")
         .AppendFormatLine("     , VP.DescuentoRecargoPorc DescuentoRecargoPorc_Venta")
         .AppendFormatLine("     , VP.DescuentoRecargoPorc2 DescuentoRecargoPorc2_Venta")
         .AppendFormatLine("     , ROUND(VP.PrecioNeto, 2) PrecioNeto_Venta")
         .AppendFormatLine("     , ISNULL(ROUND(VP.PrecioNeto, 2)-ROUND(PP.PrecioNeto, 2), 0) AS Diferencia_PedidoVenta")
         .AppendFormatLine("     , CASE WHEN ABS(ISNULL(ROUND(VP.PrecioNeto, 2)-ROUND(PP.PrecioNeto, 2), 0)) < {0} THEN 0 ELSE ISNULL(ROUND(VP.PrecioNeto, 2)-ROUND(PP.PrecioNeto, 2), 0) END Diferencia_PedidoVenta_tolerancia", tolerancia)
         .AppendFormatLine("  FROM Pedidos P")
         .AppendFormatLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal        = P.IdSucursal")
         .AppendFormatLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("                               AND PP.Letra             = P.Letra")
         .AppendFormatLine("                               AND PP.CentroEmisor      = P.CentroEmisor")
         .AppendFormatLine("                               AND PP.NumeroPedido      = P.NumeroPedido")
         .AppendFormatLine(" INNER JOIN PedidosEstados   PE ON PE.IdSucursal        = PP.IdSucursal")
         .AppendFormatLine("                               AND PE.IdTipoComprobante = PP.IdTipoComprobante")
         .AppendFormatLine("                               AND PE.Letra             = PP.Letra")
         .AppendFormatLine("                               AND PE.CentroEmisor      = PP.CentroEmisor")
         .AppendFormatLine("                               AND PE.NumeroPedido      = PP.NumeroPedido")
         .AppendFormatLine("                               AND PE.IdProducto        = PP.IdProducto")
         .AppendFormatLine("                               AND PE.Orden             = PP.Orden")
         .AppendFormatLine(" INNER JOIN Clientes         C  ON C.IdCliente          = P.IdCliente")
         .AppendFormatLine("  LEFT JOIN Ventas           V  ON V.IdSucursal         = PE.IdSucursalFact")
         .AppendFormatLine("                               AND V.IdTipoComprobante  = PE.IdTipoComprobanteFact")
         .AppendFormatLine("                               AND V.Letra              = PE.LetraFact")
         .AppendFormatLine("                               AND V.CentroEmisor       = PE.CentroEmisorFact")
         .AppendFormatLine("                               AND V.NumeroComprobante  = PE.NumeroComprobanteFact")
         .AppendFormatLine("  LEFT JOIN VentasProductos  VP ON VP.IdSucursal        = V.IdSucursal")
         .AppendFormatLine("                               AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("                               AND VP.Letra             = V.Letra")
         .AppendFormatLine("                               AND VP.CentroEmisor      = V.CentroEmisor")
         .AppendFormatLine("                               AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendFormatLine("                               AND VP.IdProducto        = PP.IdProducto")
         .AppendFormatLine("  LEFT JOIN Productos        PR ON PR.IdProducto        = PP.IdProducto")
         .AppendFormatLine(" WHERE PE.IdEstado <> 'ANULADO'")
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND P.FechaPedido >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND P.FechaPedido <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If
         If idCliente.HasValue AndAlso idCliente.Value > 0 Then
            .AppendFormatLine("   AND P.IdCliente = {0}", idCliente)
         End If
         '.AppendFormatLine("   AND ROUND(PP.PrecioNeto, 2) <> ROUND(VP.PrecioNeto, 2)")
      End With
   End Sub

   Public Function GetPedidosSinFacturar(sucursales As List(Of Entidades.Sucursal)) As DataTable

      Dim query = New StringBuilder()

      With query
         .Length = 0
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	P.IdSucursal S, ")
         .AppendFormatLine("	C.CodigoCliente Código, ")
         .AppendFormatLine("	C.NombreCliente Cliente, ")
         .AppendFormatLine("	P.FechaPedido Fecha, ")
         .AppendFormatLine("	P.IdTipoComprobante Comprobante, ")
         .AppendFormatLine("	P.Letra, ")
         .AppendFormatLine("	P.CentroEmisor Emisor,")
         .AppendFormatLine("	P.NumeroPedido Pedido, ")
         .AppendFormatLine("	P.ImporteTotal Total ")
         .AppendFormatLine("FROM PedidosEstados PE")
         .AppendFormatLine("INNER JOIN Pedidos P ON PE.IdSucursal = P.IdSucursal AND PE.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine("INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante AND TC.Tipo = 'PEDIDOSCLIE'")
         .AppendFormatLine("INNER JOIN Clientes C ON P.IdCliente = C.IdCliente")
         .AppendFormatLine("WHERE 1=1 ")
         .AppendFormatLine("  AND PE.IdTipoComprobanteFact = ''")
         .AppendFormatLine("  AND PE.IdEstado <> 'ANULADO'")
         If sucursales IsNot Nothing AndAlso sucursales.Any() Then
            query.AppendFormatLine("   AND {0}.idSucursal IN ({1})", "P", String.Join(",", sucursales.ToList().ConvertAll(Function(m) m.IdSucursal)))
         End If
         .AppendFormatLine("GROUP BY P.FechaPedido,P.IdSucursal,P.IdTipoComprobante, P.Letra, P.CentroEmisor, P.NumeroPedido, C.CodigoCliente, C.NombreCliente, P.ImporteTotal")
      End With

      Return GetDataTable(query)

   End Function


   Public Function GetInfPedidosFacturadosCabecera(fechaDesde As Date?, fechaHasta As Date?,
                                                   idCliente As Long?,
                                                   tolerancia As Decimal) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT IdSucursal_Pedido, IdTipoComprobante_Pedido, Letra_Pedido, CentroEmisor_Pedido, NumeroPedido")
         .AppendFormatLine("              , IdEstado, FechaPedido")
         .AppendFormatLine("              , IdSucursal_Venta, IdTipoComprobante_Venta, Letra_Venta, CentroEmisor_Venta, NumeroComprobante")
         .AppendFormatLine("              , FechaVenta")
         .AppendFormatLine("              , IdCliente, CodigoCliente, NombreCliente")
         .AppendFormatLine("FROM (")

         GetInfPedidosFacturadosQuery(stb, fechaDesde, fechaHasta, idCliente, tolerancia)

         .AppendFormatLine("     ) Detalle")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetInfPedidosFacturadosDetalle(fechaDesde As Date?, fechaHasta As Date?,
                                                  idCliente As Long?,
                                                  tolerancia As Decimal) As DataTable
      Dim stb = New StringBuilder()
      GetInfPedidosFacturadosQuery(stb, fechaDesde, fechaHasta, idCliente, tolerancia)
      Return GetDataTable(stb)
   End Function

   Public Function GetPedidosPendientesCantItemsFacturados(estado As String, tieneCantidadFact As Boolean, sucursales As List(Of Entidades.Sucursal)) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendFormatLine("SELECT * FROM (")
         .AppendFormatLine("  SELECT ")
         '.AppendFormatLine("    PE.IdSucursal")
         '.AppendFormatLine("    ,C.IdCliente")
         .AppendFormatLine("    C.CodigoCliente AS Codigo")
         .AppendFormatLine("    ,C.NombreCliente AS Cliente")
         .AppendFormatLine("    ,P.IdSucursal as Sucursal")
         .AppendFormatLine("    ,P.IdTipoComprobante AS Tipo")
         .AppendFormatLine("    ,P.Letra")
         .AppendFormatLine("    ,P.CentroEmisor AS Emisor")
         .AppendFormatLine("    ,P.NumeroPedido AS Numero")
         .AppendFormatLine("    ,P.FechaPedido AS Fecha")
         .AppendFormatLine("    ,P.NumeroOrdenCompra AS NumeroOC")
         .AppendFormatLine("    ,PP.IdProducto AS CodProducto")
         .AppendFormatLine("    ,PP.NombreProducto AS NombreProducto")
         .AppendFormatLine("    ,PP.Cantidad")
         .AppendFormatLine("    ,PE.IdEstado")
         .AppendFormatLine("    ,PP.CantEntregada")

         .AppendFormatLine("    ,(SELECT CASE WHEN SUM(PP.Cantidad) = 0 Then 0 Else SUM(PP.CantPendiente + PP.CantEnProceso) / SUM(PP.Cantidad) End")
         .AppendFormatLine("    FROM PedidosProductos PP")
         .AppendFormatLine("    WHERE PP.IdSucursal = P.IdSucursal")
         .AppendFormatLine("    And PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("    And PP.Letra = P.Letra")
         .AppendFormatLine("    And PP.CentroEmisor = P.CentroEmisor")
         .AppendFormatLine("    And PP.NumeroPedido = P.NumeroPedido) * 100 As PorcPend")

         .AppendFormatLine("   FROM Pedidos P")
         .AppendFormatLine("   INNER JOIN TiposComprobantes TC On TC.IdTipoComprobante = P.IdTipoComprobante And TC.Tipo = 'PEDIDOSCLIE'")
         .AppendFormatLine("   INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendFormatLine("   INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendFormatLine("    AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("    AND PP.Letra = P.Letra")
         .AppendFormatLine("    AND PP.CentroEmisor = P.CentroEmisor")
         .AppendFormatLine("    AND PP.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine("   INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendFormatLine("    AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("    AND PE.Letra = P.Letra")
         .AppendFormatLine("    AND PE.CentroEmisor = P.CentroEmisor")
         .AppendFormatLine("    AND PE.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine("    AND PE.IdProducto = PP.IdProducto")
         .AppendFormatLine("    AND PE.Orden = PP.Orden")
         .AppendFormatLine("   WHERE PE.IdEstado = '{0}'", estado)
         .AppendFormatLine("  ) AS P")
         .AppendFormatLine(" WHERE 1=1 ")
         If tieneCantidadFact Then
            .AppendFormatLine("AND P.PorcPend < 100")
         Else
            .AppendFormatLine("AND P.PorcPend = 100")
         End If
         If sucursales IsNot Nothing AndAlso sucursales.Any() Then
            stb.AppendFormatLine("   AND {0}.Sucursal IN ({1})", "P", String.Join(",", sucursales.ToList().ConvertAll(Function(m) m.IdSucursal)))
         End If
      End With

      Return GetDataTable(stb)

   End Function
End Class