Imports Eniac.Entidades

Partial Class PedidosEstadosProveedores

   Public Shared Function GetCoeficienteStock(idEstadoActual As String, idEstadoDestino As String, idTipoEstadoPedido As String, _cache As BusquedasCacheadas) As Integer
      Return GetCoeficienteStock(_cache.BuscaEstadosPedidoProveedores(idEstadoActual, idTipoEstadoPedido), _cache.BuscaEstadosPedidoProveedores(idEstadoDestino, idTipoEstadoPedido), _cache)
   End Function
   Public Shared Function GetCoeficienteStock(estadoActual As Entidades.EstadoPedidoProveedor, estadoDestino As Entidades.EstadoPedidoProveedor, _cache As BusquedasCacheadas) As Integer
      Dim tipoComp = _cache.BuscaTipoComprobante(estadoDestino.IdTipoComprobante)
      Return If(tipoComp Is Nothing, 0, tipoComp.CoeficienteStock)
   End Function

   Public Sub ActualizarEstadoPedidoProveedorMasivo(cambioEstado As Entidades.PedidosProveedoresAdminCambioEstado, idFuncion As String)
      EjecutaConTransaccion(Sub() _ActualizarEstadoPedidoProveedorMasivo(cambioEstado, idFuncion, New List(Of CompraObservacion)))
   End Sub

   Public Sub _ActualizarEstadoPedidoProveedorMasivo(cambioEstado As Entidades.PedidosProveedoresAdminCambioEstado, idFuncion As String, Observaciones As List(Of CompraObservacion))
      'Viene el Estado pero tambien utilizo el Tipo de Estado

      Dim fechaNuevoEstado = cambioEstado.FechaNuevoEstado.IfNull(Date.Now)

      Dim fechaNuevoEstadoInicial As Date = fechaNuevoEstado

      Dim dicCompraAGenerar = New Dictionary(Of Entidades.PedProvAdminClaveGenerar, List(Of Entidades.PedidosProveedoresAdminPedidos))()
      Dim dicPedidosAGenerar = New Dictionary(Of Entidades.PedProvAdminClaveGenerar, List(Of Entidades.PedidosProveedoresAdminPedidos))()

      Dim idTipoComprobanteFact = cambioEstado.EstadoDestino.IdTipoComprobante
      Dim tipoComprobanteFact = If(Not String.IsNullOrWhiteSpace(idTipoComprobanteFact), New TiposComprobantes(da).GetUno(idTipoComprobanteFact), Nothing)

      Dim nroPedido As Long = 0

      Dim sqlPE = New SqlServer.PedidosEstadosProveedores(da)
      For Each filaGrabar In cambioEstado.Pedidos.OfType(Of Entidades.PedidosProveedoresAdminPedidos)

         Dim rPP = New PedidosProductosProveedores(da)
         Dim sqlEP = New SqlServer.EstadosPedidosProveedores(da)
         Dim sqlPP = New SqlServer.PedidosProductosProveedores(da)

         Dim peOriginal = GetUno(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                 filaGrabar.Orden, filaGrabar.Producto.IdProducto, filaGrabar.FechaEstado, accion:=AccionesSiNoExisteRegistro.Excepcion)

         filaGrabar.FechaEstadoDestino = fechaNuevoEstado
         If peOriginal.CantEstado = filaGrabar.Cantidad Then
            CambiarEstado(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                          filaGrabar.Producto.IdProducto, filaGrabar.FechaEstado,
                          cambioEstado.EstadoDestino.IdEstado, cambioEstado.EstadoDestino.TipoEstadoPedido,
                          filaGrabar.Cantidad,
                          fechaNuevoEstado,
                          cambioEstado.Observaciones,
                          filaGrabar.Orden,
                          filaGrabar.IdCriticidad,
                          filaGrabar.FechaEntrega,
                          filaGrabar.NumeroReparto, sqlPE)
            If filaGrabar.OPOperacionTalleresExternos IsNot Nothing Then
               sqlPE.PedidosEstadosProveedores_U_OpOperacionTallerExt(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                                      filaGrabar.Producto.IdProducto, fechaNuevoEstado, filaGrabar.Orden,
                        filaGrabar.OPOperacionTalleresExternos.IdSucursal, filaGrabar.OPOperacionTalleresExternos.IdTipoComprobante, filaGrabar.OPOperacionTalleresExternos.LetraComprobante,
                        filaGrabar.OPOperacionTalleresExternos.CentroEmisor, filaGrabar.OPOperacionTalleresExternos.NumeroOrdenProduccion.ToInteger(), filaGrabar.OPOperacionTalleresExternos.Orden,
                        filaGrabar.OPOperacionTalleresExternos.IdProducto, filaGrabar.OPOperacionTalleresExternos.IdProcesoProductivo, filaGrabar.OPOperacionTalleresExternos.IdOperacion)

               sqlPE.PedidosEstadosProveedores_U_OP(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor,
                                          filaGrabar.NumeroPedido, filaGrabar.Producto.IdProducto, fechaNuevoEstado, Nothing, filaGrabar.Orden,
                                            filaGrabar.OPOperacionTalleresExternos.IdSucursal, filaGrabar.OPOperacionTalleresExternos.IdTipoComprobante, filaGrabar.OPOperacionTalleresExternos.LetraComprobante,
                                          filaGrabar.OPOperacionTalleresExternos.CentroEmisor, filaGrabar.OPOperacionTalleresExternos.NumeroOrdenProduccion.ToInteger(),
                                              filaGrabar.OPOperacionTalleresExternos.IdProducto, filaGrabar.OPOperacionTalleresExternos.Orden)


            End If


         Else
            sqlPE.PedidosEstadosProveedores_I(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                              filaGrabar.Producto.IdProducto, fechaNuevoEstado,
                                              filaGrabar.IdClienteProveedor,
                                              cambioEstado.EstadoDestino.IdEstado,
                                              cambioEstado.IdUsuario,
                                              cambioEstado.Observaciones,
                                              filaGrabar.Cantidad,
                                              peOriginal.IdTipoComprobanteFact, peOriginal.LetraFact, peOriginal.CentroEmisorFact, peOriginal.NumeroComprobanteFact,
                                              filaGrabar.Orden,
                                              filaGrabar.IdCriticidad,
                                              filaGrabar.FechaEntrega,
                                              cambioEstado.EstadoDestino.TipoEstadoPedido,
                                              filaGrabar.NumeroReparto,
                                              peOriginal.IdSucursalGenerado, peOriginal.IdTipoComprobanteGenerado, peOriginal.LetraGenerado, peOriginal.CentroEmisorGenerado, peOriginal.NumeroPedidoGenerado,
                                              peOriginal.IdSucursalRemito, peOriginal.IdTipoComprobanteRemito, peOriginal.LetraRemito, peOriginal.CentroEmisorRemito, peOriginal.NumeroComprobanteRemito,
                                              peOriginal.IdEstadoProducto, peOriginal.IdEstadoCantidad, peOriginal.IdEstadoPrecio, peOriginal.IdEstadoFechaEntrega,
                                              peOriginal.FechaEstadoProducto, peOriginal.FechaEstadoCantidad, peOriginal.FechaEstadoPrecio, peOriginal.FechaEstadoFechaEntrega)

            If filaGrabar.OPOperacionTalleresExternos IsNot Nothing Then
               sqlPE.PedidosEstadosProveedores_U_OpOperacionTallerExt(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                                      filaGrabar.Producto.IdProducto, fechaNuevoEstado, filaGrabar.Orden,
                        filaGrabar.OPOperacionTalleresExternos.IdSucursal, filaGrabar.OPOperacionTalleresExternos.IdTipoComprobante, filaGrabar.OPOperacionTalleresExternos.LetraComprobante,
                        filaGrabar.OPOperacionTalleresExternos.CentroEmisor, filaGrabar.OPOperacionTalleresExternos.NumeroOrdenProduccion.ToInteger(), filaGrabar.OPOperacionTalleresExternos.Orden,
                        filaGrabar.OPOperacionTalleresExternos.IdProducto, filaGrabar.OPOperacionTalleresExternos.IdProcesoProductivo, filaGrabar.OPOperacionTalleresExternos.IdOperacion)


               sqlPE.PedidosEstadosProveedores_U_OP(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor,
                                               filaGrabar.NumeroPedido, filaGrabar.Producto.IdProducto, fechaNuevoEstado, Nothing, filaGrabar.Orden,
                                                 filaGrabar.OPOperacionTalleresExternos.IdSucursal, filaGrabar.OPOperacionTalleresExternos.IdTipoComprobante, filaGrabar.OPOperacionTalleresExternos.LetraComprobante,
                                               filaGrabar.OPOperacionTalleresExternos.CentroEmisor, filaGrabar.OPOperacionTalleresExternos.NumeroOrdenProduccion.ToInteger(),
                                                   filaGrabar.OPOperacionTalleresExternos.IdProducto, filaGrabar.OPOperacionTalleresExternos.Orden)

            End If


            sqlPE.PedidosEstadosProveedores_U_Cantidad(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                       filaGrabar.Producto.IdProducto, filaGrabar.Orden, fechaNuevoEstado,
                                                       filaGrabar.Cantidad * -1)

         End If

         'Agrego Obs. Detalladas con Orden de producción vinculada 
         If nroPedido <> filaGrabar.NumeroPedido Or nroPedido = 0 Then
            Dim pedido As Entidades.PedidoProveedor = New Entidades.PedidoProveedor
            With pedido
               .IdSucursal = filaGrabar.IdSucursal
               .TipoComprobante = New Reglas.TiposComprobantes().GetUno(filaGrabar.IdTipoComprobante)
               .LetraComprobante = filaGrabar.Letra
               .CentroEmisor = Short.Parse(filaGrabar.CentroEmisor.ToString())
               .NumeroPedido = filaGrabar.NumeroPedido
            End With

            'falta buscar las lineas de los pedidos.-

            If filaGrabar.OPOperacionTalleresExternos IsNot Nothing Then
               pedido.PedidosObservaciones.Add(New Entidades.PedidoObservacionProveedor With {.Observacion =
                                             String.Format("Vinculo: {0}-{1}-{2}-{3} Linea: {4} {5}-{6}-{7}-{8} ",
                                                           filaGrabar.OPOperacionTalleresExternos.IdTipoComprobante, filaGrabar.OPOperacionTalleresExternos.LetraComprobante,
                                                           filaGrabar.OPOperacionTalleresExternos.CentroEmisor, filaGrabar.OPOperacionTalleresExternos.NumeroOrdenProduccion,
                                                           filaGrabar.OrdenPedido, filaGrabar.DescripcionTipoComprobantePedido,
                                                           filaGrabar.LetraPedido, filaGrabar.CentroEmisorPedido, filaGrabar.NumeroPedidoPedido)})
            End If
            For Each obs In Observaciones
               pedido.PedidosObservaciones.Add(New Entidades.PedidoObservacionProveedor With {.Observacion = obs.Observacion})
            Next

            Observaciones.Clear()

            Dim rPedObs As PedidosObservacionesProveedores = New PedidosObservacionesProveedores(da)
            rPedObs.InsertaObservacionesDesdePedido(pedido)
         End If


         rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                         filaGrabar.Producto.IdProducto, filaGrabar.Orden,
                                                         filaGrabar.EstadoActual.TipoEstadoPedido, cambioEstado.EstadoDestino.IdTipoEstado, filaGrabar.Cantidad)

         RegistraMovimientoStock(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                 filaGrabar.Producto, filaGrabar.Orden,
                                 filaGrabar.EstadoActual.IdEstado, cambioEstado.EstadoDestino.IdEstado, filaGrabar.EstadoActual.TipoEstadoPedido,
                                 filaGrabar.Cantidad, filaGrabar.Ubicaciones,
                                 Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

         ActualizaPedidoOrigen(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                               filaGrabar.Producto.IdProducto, filaGrabar.Orden, filaGrabar.FechaEstado,
                               filaGrabar.EstadoActual.IdEstado, cambioEstado.EstadoDestino.IdEstado, filaGrabar.EstadoActual.TipoEstadoPedido,
                               filaGrabar.Cantidad, filaGrabar.IdResponsable, idFuncion)


         If Not String.IsNullOrEmpty(idTipoComprobanteFact) Then
            If tipoComprobanteFact.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString() Then
               Dim clavePedido = New Entidades.PedProvAdminClaveGenerar(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                                        filaGrabar.IdSucursal, idTipoComprobanteFact, filaGrabar.IdClienteProveedor, filaGrabar.DescRecPorcGral)

               If Not dicCompraAGenerar.ContainsKey(clavePedido) Then
                  dicCompraAGenerar.Add(clavePedido, New List(Of Entidades.PedidosProveedoresAdminPedidos)())
               End If
               dicCompraAGenerar(clavePedido).Add(filaGrabar)
            ElseIf tipoComprobanteFact.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSPROV.ToString() OrElse
                   tipoComprobanteFact.Tipo = Entidades.TipoComprobante.Tipos.PRESUPPROV.ToString() OrElse
                   tipoComprobanteFact.Tipo = Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString() Then

               Dim clavePedido = If(cambioEstado.GeneraUnPedidoPorProveedor,
                                    New Entidades.PedProvAdminClaveGenerar(idTipoComprobanteFact, filaGrabar.IdClienteProveedor),
                                    New Entidades.PedProvAdminClaveGenerar(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                                           filaGrabar.IdSucursal, idTipoComprobanteFact, filaGrabar.IdClienteProveedor, filaGrabar.DescRecPorcGral))
               If Not dicPedidosAGenerar.ContainsKey(clavePedido) Then
                  dicPedidosAGenerar.Add(clavePedido, New List(Of Entidades.PedidosProveedoresAdminPedidos)())
               End If
               dicPedidosAGenerar(clavePedido).Add(filaGrabar)

            End If      'If tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString() Then
            'Y DE        ElseIf tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSPROV.ToString() OrElse PRESUPPROV.ToString() OrElse ORDENCOMPRAPROV.ToString() Then
         End If

         fechaNuevoEstado = fechaNuevoEstado.AddSeconds(1)
         nroPedido = filaGrabar.NumeroPedido
      Next           'For Each filaGrabar As DataRow In tablagrabar.Rows

      If tipoComprobanteFact IsNot Nothing Then
         CreaCompraDesdePedido(dicCompraAGenerar, fechaNuevoEstadoInicial, fechaNuevoEstado, idFuncion, sqlPE)

         CrearPedidoDesdePedido(dicPedidosAGenerar, fechaNuevoEstadoInicial, fechaNuevoEstado, idFuncion, sqlPE)
      End If
   End Sub

   Private Sub CrearPedidoDesdePedido(dicPedidosAGenerar As Dictionary(Of Entidades.PedProvAdminClaveGenerar, List(Of Entidades.PedidosProveedoresAdminPedidos)),
                                      fechaNuevoEstadoInicial As Date, fechaNuevoEstado As Date,
                                      idFuncion As String, sqlPE As SqlServer.PedidosEstadosProveedores)
      For Each valores In dicPedidosAGenerar
         Dim primerPedido = valores.Value.First()

         Dim idSucursalPresup = primerPedido.IdSucursal
         Dim idTipoComprobantePresup = primerPedido.IdTipoComprobante
         Dim letraPresup = primerPedido.Letra
         Dim centroEmisorPresup = primerPedido.CentroEmisor
         Dim numeroPedidoPresup = primerPedido.NumeroPedido

         Dim presup = New PedidosProveedores(da).GetUno(idSucursalPresup, idTipoComprobantePresup, letraPresup, centroEmisorPresup, numeroPedidoPresup)

         Dim prov = New Reglas.Proveedores(da)._GetUno(valores.Key.IdProveedor, False)
         Dim tipoComprobante = _cache.BuscaTipoComprobante(valores.Key.IdTipoComprobanteDestino)

         Dim rPedidos = New PedidosProveedores(da)
         Dim pedido = rPedidos._CrearPedido(prov, tipoComprobante, letra:=String.Empty, centroEmisor:=Nothing, numeroComprobante:=Nothing,
                                            fecha:=Today,
                                            presup.Comprador, presup.Transportista, presup.FormaPago,
                                            presup.TipoComprobanteFact,
                                            observaciones:=String.Empty,
                                            presup.EstadoVisita,
                                            ordenCompra:=0)

         For Each drFilaGrabar In valores.Value
            idSucursalPresup = drFilaGrabar.IdSucursal
            idTipoComprobantePresup = drFilaGrabar.IdTipoComprobante
            letraPresup = drFilaGrabar.Letra
            centroEmisorPresup = drFilaGrabar.CentroEmisor
            numeroPedidoPresup = drFilaGrabar.NumeroPedido

            Dim oProducto = New Reglas.Productos(da).GetUno(drFilaGrabar.Producto.IdProducto, False, False, AccionesSiNoExisteRegistro.Excepcion)
            Dim ordenPresup = drFilaGrabar.Orden
            Dim cantEstadoPresup = drFilaGrabar.Cantidad

            Dim presupProd = New PedidosProductosProveedores(da).GetUno(idSucursalPresup, idTipoComprobantePresup, letraPresup, centroEmisorPresup, numeroPedidoPresup,
                                                                        ordenPresup, oProducto.IdProducto)

            Dim costo = presupProd.Costo
            Dim precioPorUMCompra = presupProd.PrecioPorUMCompra
            Dim usaPrecioSinIVA = (pedido.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                                  Not pedido.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos
            Dim alicuota = presupProd.AlicuotaImpuesto
            If Not usaPrecioSinIVA Then
               costo = presupProd.CostoConImpuestos
               precioPorUMCompra = precioPorUMCompra * (1 + (presupProd.AlicuotaImpuesto / 100))
            End If

            rPedidos.AgregarLinea(pedido,
                                  rPedidos.CrearPedidoProducto(
                                          producto:=oProducto,
                                          productoDescripcion:=presupProd.NombreProducto,
                                          descuentoRecargoPorc1:=presupProd.DescuentoRecargoPorc,
                                          descuentoRecargoPorc2:=presupProd.DescuentoRecargoPorc2,
                                          costo:=costo,
                                          cantidad:=cantEstadoPresup,
                                          tipoImpuesto:=presupProd.TipoImpuesto,
                                          porcentajeIva:=alicuota,
                                          criticidad:=New PedidosCriticidades(da).GetUno(presupProd.IdCriticidad),
                                          fechaEntrega:=Today,
                                          cantidadUMCompra:=presupProd.FactorConversionCompra * cantEstadoPresup,
                                          factorConversionCompra:=presupProd.FactorConversionCompra,
                                          precioPorUMCompra:=precioPorUMCompra,
                                          pedido:=pedido,
                                          redondeoEnCalculo:=2))

         Next        'For Each drFilaGrabar As DataRow In valores.Value

         For Each pedObs In presup.PedidosObservaciones
            rPedidos.AgregarObservacion(pedido, pedObs)
         Next

         Dim pedidoGenerado = rPedidos.Inserta(pedido)

         For Each drFilaGrabar In valores.Value
            sqlPE.PedidosEstadosProveedores_U_Ped(
                        presup.IdSucursal, presup.IdTipoComprobante, presup.LetraComprobante, presup.CentroEmisor,
                        presup.NumeroPedido, drFilaGrabar.Producto.IdProducto, drFilaGrabar.FechaEstadoDestino, fechaEstadoHasta:=Nothing, drFilaGrabar.Orden, '' fechaNuevoEstadoInicial, fechaNuevoEstado, drFilaGrabar.Orden,
                        pedidoGenerado.IdSucursal, pedidoGenerado.IdTipoComprobante, pedidoGenerado.LetraComprobante,
                        pedidoGenerado.CentroEmisor, pedidoGenerado.NumeroPedido)
         Next
      Next           'For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicPedidosAGenerar
   End Sub
   Private Sub CreaCompraDesdePedido(dicCompraAGenerar As Dictionary(Of Entidades.PedProvAdminClaveGenerar, List(Of Entidades.PedidosProveedoresAdminPedidos)),
                                     fechaNuevoEstadoInicial As Date, fechaNuevoEstado As Date,
                                     idFuncion As String, sqlPE As SqlServer.PedidosEstadosProveedores)
      Dim decimalesRedondeoEnPrecio = Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnPrecio ' 2I
      Dim formaDePagoCtaCte = New VentasFormasPago().GetUna("COMPRAS", False)

      Dim dtCajas = New CajasUsuarios(da).GetCajasTodas({actual.Sucursal}, actual.Nombre, nombrePC:=String.Empty, cajasModificables:=True)
      Dim caja = dtCajas.FirstOrDefault()
      If caja Is Nothing Then Throw New Exception("No tiene ninguna caja con permiso de escritura. No podrá continuar.")

      Dim rCompras = New Compras(da)

      For Each valores In dicCompraAGenerar
         Dim pedido = valores.Key
         Dim compra = rCompras.CreaCompra(pedido.IdSucursal, _cache.BuscaTipoComprobante(pedido.IdTipoComprobanteDestino), String.Empty, centroEmisor:=0, numeroComprobante:=Nothing,
                                          fecha:=Date.Now, _cache.BuscaProveedor(pedido.IdProveedor), _cache.GetPrimerComprador(), pedido.DescRecPorcGral, cotizacionDolar:=Nothing,
                                          formaDePagoCtaCte, caja.IdCaja, observacion:="Generado por Cambio de Estado", _cache)
         Dim orden = 0I
         For Each filaGrabar In valores.Value
            Dim presupProd = New PedidosProductosProveedores(da).GetUno(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                                        filaGrabar.Orden, filaGrabar.Producto.IdProducto)

            Dim usaPrecioConIVA = (Not compra.Proveedor.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado) And
                                   compra.Proveedor.CategoriaFiscal.UtilizaImpuestos And _categoriaFiscalEmpresa.UtilizaImpuestos And
                                   compra.TipoComprobante.UtilizaImpuestos

            For Each ubic In filaGrabar.Ubicaciones
               Dim lotes = ubic.Lotes.ToList()
               If Not lotes.AnySecure() Then
                  lotes.Add(New Entidades.SeleccionMultipleLotes() With {
                                 .IdLote = String.Empty,
                                 .Cantidad = ubic.Cantidad,
                                 .UbicacionAdmin = ubic
                              })
               End If
               For Each l In lotes
                  orden += 1
                  Dim precio As PrecioEnmascarado? = Nothing
                  If Not presupProd.TipoComprobante.CargaPrecioActual Then
                     precio = New PrecioEnmascarado(presupProd.Costo, conIva:=usaPrecioConIVA)
                  End If
                  Dim cp = rCompras.CreaCompraProducto(compra, _cache.BuscaProductoEntidadPorId(ubic.IdProducto, da), presupProd.NombreProducto,
                                                       presupProd.DescuentoRecargoPorc, l.Cantidad, presupProd.FactorConversionCompra, presupProd.PrecioPorUMCompra, ubic.IdDeposito, ubic.IdUbicacion,
                                                       precio, presupProd.AlicuotaImpuesto, orden,
                                                       l.IdLote, l.FechaVencimiento, l.InformeCalidadNumero, l.InformeCalidadLink,
                                                       ubic.NrosSerie.ConvertAll(Function(ns) ns.NroSerie),
                                                       decimalesRedondeoEnPrecio, _cache)
                  rCompras.AgregaCompraProducto(compra, cp, decimalesRedondeoEnPrecio)
               Next
            Next

            rCompras.AgregarInvocado(compra, pedido, _cache)
         Next

         Dim rMovimientos = New MovimientosStock(da)
         Dim oMov = rCompras.PreparaCompraParaGrabar(compra, _cache)
         rMovimientos._Insertar(oMov, dtExpensas:=New DataTable(), Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

         '''''Lo asigno completo para que tenga valor en el procedimiento que lo llamo.
         ''''cb = GetUna(oMov.Compra.IdSucursal,
         ''''      oMov.Compra.TipoComprobante.IdTipoComprobante,
         ''''      oMov.Compra.Letra,
         ''''      oMov.Compra.CentroEmisor,
         ''''      oMov.Compra.NumeroComprobante,
         ''''      oMov.Compra.Proveedor.IdProveedor)

         For Each drFilaGrabar In valores.Value
            sqlPE.PedidosEstadosProveedores_U_Fact(
                        drFilaGrabar.IdSucursal, drFilaGrabar.IdTipoComprobante, drFilaGrabar.Letra, drFilaGrabar.CentroEmisor, drFilaGrabar.NumeroPedido,
                        drFilaGrabar.Producto.IdProducto, drFilaGrabar.FechaEstadoDestino, '' drFilaGrabar.FechaEstado, fechaNuevoEstadoInicial, fechaNuevoEstado, drFilaGrabar.Orden,
                        compra.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante, drFilaGrabar.Orden)
         Next

      Next

   End Sub

   Private Sub CreaCompraDesdePedido1(dicCompraAGenerar As Dictionary(Of Entidades.PedProvAdminClaveGenerar, List(Of Entidades.PedidosProveedoresAdminPedidos)),
                                     fechaNuevoEstadoInicial As Date, fechaNuevoEstado As Date,
                                     idFuncion As String, sqlPE As SqlServer.PedidosEstadosProveedores)

      Dim formaDePagoCtaCte = New VentasFormasPago().GetUna("COMPRAS", False)
      Dim dtCajas = New CajasUsuarios(da).GetCajasTodas({actual.Sucursal}, actual.Nombre, nombrePC:=String.Empty, cajasModificables:=True)
      Dim caja = dtCajas.FirstOrDefault()
      If caja Is Nothing Then Throw New Exception("No tiene ninguna caja con permiso de escritura. No podrá continuar.")

      Dim rUbic = New SucursalesUbicaciones(da)

      Dim rCompras = New Compras(da)

      For Each valores In dicCompraAGenerar
         Dim productos = New List(Of Entidades.CompraProducto)
         Dim importeTotal = 0D

         Dim tipoComprobanteFact = _cache.BuscaTipoComprobante(valores.Key.IdTipoComprobanteDestino)

         Dim invocados = New List(Of Entidades.Compra)()

         For Each filaGrabar In valores.Value
            Dim prov = _cache.BuscaProveedor(filaGrabar.IdClienteProveedor)

            Dim presupProd = New PedidosProductosProveedores(da).GetUno(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                                        filaGrabar.Orden, filaGrabar.Producto.IdProducto)

            invocados.Add(New Entidades.Compra() With {
                              .IdSucursal = presupProd.IdSucursal,
                              .TipoComprobante = presupProd.TipoComprobante,
                              .Letra = presupProd.Letra,
                              .CentroEmisor = presupProd.CentroEmisor.ToShort(),
                              .NumeroComprobante = presupProd.NumeroPedido,
                              .Proveedor = presupProd.Proveedor
                          })

            Dim costo = presupProd.Costo
            Dim usaPrecioSinIVA = (prov.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                                   Not prov.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos
            Dim alicuota = presupProd.AlicuotaImpuesto
            'If Not usaPrecioSinIVA Then
            '   costo = presupProd.CostoConImpuestos
            'End If
            costo = presupProd.CostoConImpuestos

            Dim agregarProducto =
               Function(productos1 As List(Of Entidades.CompraProducto), ubic As Entidades.SeleccionMultipleUbicaciones, lote As Entidades.SeleccionMultipleLotes)
                  Dim producto = New Entidades.CompraProducto()
                  With producto
                     .Producto = _cache.BuscaProductoEntidadPorId(filaGrabar.Producto.IdProducto)
                     .Precio = costo
                     .Cantidad = If(lote IsNot Nothing, lote.Cantidad, ubic.Cantidad)
                     .IdDeposito = ubic.IdDeposito
                     .IdUbicacion = ubic.IdUbicacion
                     If lote IsNot Nothing Then
                        .IdLote = lote.IdLote
                        .FechaVencimientoLote = lote.FechaVencimiento
                     End If
                     If .Producto.InformeControlCalidad AndAlso tipoComprobanteFact.SolicitaInformeCalidad Then
                        .InformeCalidadNumero = lote.InformeCalidadNumero
                        .InformeCalidadLink = lote.InformeCalidadLink
                     End If
                     .NrosSeries = ubic.NrosSerie
                  End With
                  productos1.Add(producto)
                  Return producto
               End Function

            For Each ubic In filaGrabar.Ubicaciones
               If ubic.Lotes.AnySecure() Then
                  For Each lote In ubic.Lotes
                     Dim producto = agregarProducto(productos, ubic, lote)
                     importeTotal += producto.Precio * producto.Cantidad
                  Next
               Else
                  Dim producto = agregarProducto(productos, ubic, lote:=Nothing)
                  importeTotal += producto.Precio * producto.Cantidad
               End If
            Next
         Next

         Dim proveedor = _cache.BuscaProveedor(valores.Key.IdProveedor)

         Dim pkPedidos = From pe In valores.Value
                         Select pe.IdSucursal, pe.IdTipoComprobante, pe.DescripcionTipoComprobante, pe.Letra, pe.CentroEmisor, pe.NumeroPedido, pe.FechaPedido
                         Distinct
         Dim obs = pkPedidos.ToList().ConvertAll(
                        Function(pk)
                           Return New Entidades.CompraObservacion() With
                              {
                                 .Observacion = String.Format("Invoco: {1} ´{2}´ {3:0000}-{4:00000000}. Emision: {5:dd/MM/yyyy}",
                                                              pk.IdTipoComprobante, pk.DescripcionTipoComprobante, pk.Letra, pk.CentroEmisor, pk.NumeroPedido, pk.FechaPedido)
                              }
                        End Function)

         Dim compra = rCompras._GrabarComprobante(actual.Sucursal.Id,
                                                  tipoComprobanteFact.IdTipoComprobante,
                                                  valores.Key.IdProveedor,
                                                  caja.IdCaja,
                                                  fechaNuevoEstado,
                                                  _cache.GetPrimerComprador(),
                                                  formaDePagoCtaCte.IdFormasPago,
                                                  observacion:="Generado por Cambio de Estado",
                                                  importeTotal,
                                                  productos,
                                                  observacionDetalladas:=obs,
                                                  contactos:=Nothing, nombreProducto:=String.Empty, cobrador:=Nothing, comprobantesAsociados:=invocados,
                                                  proveedor.RubroCompra.IdRubro,
                                                  metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion:=idFuncion)
         For Each drFilaGrabar In valores.Value
            sqlPE.PedidosEstadosProveedores_U_Fact(
                        drFilaGrabar.IdSucursal, drFilaGrabar.IdTipoComprobante, drFilaGrabar.Letra, drFilaGrabar.CentroEmisor, drFilaGrabar.NumeroPedido,
                        drFilaGrabar.Producto.IdProducto, drFilaGrabar.FechaEstadoDestino, '' drFilaGrabar.FechaEstado, fechaNuevoEstadoInicial, fechaNuevoEstado, drFilaGrabar.Orden,
                        compra.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante, drFilaGrabar.Orden)
         Next
      Next
   End Sub


   Public Function ConvertirACambioEstado(dt As DataTable, _ubicaciones As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                          _tipoTipoComprobante As String, idEstado As String,
                                          observaciones As String, generaUnPedidoPorProveedor As Boolean) As Entidades.PedidosProveedoresAdminCambioEstado
      Return EjecutaConConexion(Function() _ConvertirACambioEstado(dt, _ubicaciones, _tipoTipoComprobante, idEstado, observaciones, generaUnPedidoPorProveedor))
   End Function

   Private Function _ConvertirACambioEstado(dt As DataTable, _ubicaciones As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                            _tipoTipoComprobante As String, idEstado As String,
                                            observaciones As String, generaUnPedidoPorProveedor As Boolean) As Entidades.PedidosProveedoresAdminCambioEstado
      Dim rUbic = New SucursalesUbicaciones(da)
      Dim cambioEstado = New Entidades.PedidosProveedoresAdminCambioEstado(_cache.BuscaEstadosPedidoProveedores(idEstado, _tipoTipoComprobante)) With
               {
                  .Observaciones = observaciones,
                  .GeneraUnPedidoPorProveedor = generaUnPedidoPorProveedor
               }

      Dim rProductos = New Productos(da)

      For Each dr In dt.AsEnumerable()
         Dim pedido = New Entidades.PedidosProveedoresAdminPedidos(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("DescripcionTipoComprobante"),
                                                                   dr.Field(Of String)("Letra"), dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Long)("NumeroPedido"),
                                                                   dr.Field(Of Integer)("Orden"), dr.Field(Of Date)("FechaEstado"),
                                                                   rProductos._GetUnoParaM(dr.Field(Of String)("IdProducto"))) With
                      {
                         .FechaPedido = dr.Field(Of Date)("FechaPedido"),
                         .IdClienteProveedor = dr.Field(Of Long)("IdProveedor"),
                         .FechaEntrega = dr.Field(Of Date)("FechaEntrega"),
                         .EstadoActual = _cache.BuscaEstadosPedidoProveedores(dr.Field(Of String)("IdEstado"), _tipoTipoComprobante),
                         .Cantidad = dr.Field(Of Decimal)("CantidadNuevoEstado"),
                         .Precio = dr.Field(Of Decimal)("Costo"),
                         .DescRecPorcGral = dr.Field(Of Decimal)("DescuentoRecargoPorc"),
                         .IdCriticidad = dr.Field(Of String)("IdCriticidad"),
                         .IdResponsable = 0,
                         .NumeroReparto = 0,
                         .Ubicaciones = _ubicaciones(dr)
                      }
         If Not pedido.Ubicaciones.AnySecure() Then
            pedido.Ubicaciones.Add(New Entidades.SeleccionMultipleUbicaciones() With {
                                       .Producto = pedido.Producto,
                                       .Cantidad = pedido.Cantidad,
                                       .Ubicacion = rUbic.GetUno(dr.Field(Of Integer)("IdDepositoDefecto"), dr.Field(Of Integer)("IdSucursal"), dr.Field(Of Integer)("IdUbicacionDefecto"),
                                                                 AccionesSiNoExisteRegistro.Excepcion)
                                   })
         End If
         cambioEstado.Pedidos.Add(pedido)
      Next

      Return cambioEstado
   End Function

   Public Function GetParaAdminPedidos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                       orden As Integer, idProducto As String, fechaEstado As Date?) As List(Of Entidades.PedidosProveedoresAdminPedidos)
      Return EjecutaConConexion(Function() _GetParaAdminPedidos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                                orden, idProducto, fechaEstado))
   End Function
   Public Function _GetParaAdminPedidos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                        orden As Integer, idProducto As String, fechaEstado As Date?) As List(Of Entidades.PedidosProveedoresAdminPedidos)
      Dim dtPE = Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, fechaEstado)
      Dim result = New List(Of Entidades.PedidosProveedoresAdminPedidos)()
      For Each drPE In dtPE.AsEnumerable()
         Dim producto = New Productos(da)._GetUnoParaM(drPE.Field(Of String)("IdProducto"), AccionesSiNoExisteRegistro.Excepcion)
         result.Add(New Entidades.PedidosProveedoresAdminPedidos(drPE.Field(Of Integer)("IdSucursal"),
                                                                 drPE.Field(Of String)("IdTipoComprobante"), drPE.Field(Of String)("DescripcionTipoComprobante"),
                                                                 drPE.Field(Of String)("Letra"), drPE.Field(Of Integer)("CentroEmisor"),
                                                                 drPE.Field(Of Long)("NumeroPedido"), drPE.Field(Of Integer)("Orden"),
                                                                 drPE.Field(Of Date)("FechaEstado"), producto) With {
            .FechaPedido = drPE.Field(Of Date)("FechaPedido"),
            .IdClienteProveedor = drPE.Field(Of Long?)("IdProveedor").IfNull(),
            .FechaEntrega = drPE.Field(Of Date)("FechaEntrega"),
            .EstadoActual = _cache.BuscaEstadosPedidoProveedores(drPE.Field(Of String)("IdEstado"), drPE.Field(Of String)("TipoEstadoPedido")),
            .Cantidad = drPE.Field(Of Decimal)("CantEstado"),
            .Precio = drPE.Field(Of Decimal)("Costo"),
            .DescRecPorcGral = drPE.Field(Of Decimal)("DescuentoRecargoPorc"),
            .IdCriticidad = drPE.Field(Of String)("IdCriticidad"),
            .NumeroReparto = drPE.Field(Of Integer?)("NumeroReparto").IfNull(),
            .IdResponsable = 0})
      Next
      Return result
   End Function

   Public Sub RegistraMovimientoStock(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                      producto As Entidades.ProductoLivianoParaImportarProducto, orden As Integer,
                                      idEstadoAnterior As String, idEstadoNuevo As String, tipoEstadoPedido As String,
                                      cantidad As Decimal, ubicaciones As List(Of Entidades.SeleccionMultipleUbicaciones),
                                      metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      Dim estadoAnterior = If(Not String.IsNullOrWhiteSpace(idEstadoAnterior), _cache.BuscaEstadosPedidoProveedores(idEstadoAnterior, tipoEstadoPedido), Nothing)
      Dim estadoNuevo = _cache.BuscaEstadosPedidoProveedores(idEstadoNuevo, tipoEstadoPedido)

      Dim idTipoMovimientoAnterior = String.Empty
      Dim stockAfectadoAnterior = String.Empty

      Dim idTipoMovimientoNuevo = estadoNuevo.IdTipoMovimiento
      Dim stockAfectadoNuevo = estadoNuevo.StockAfectado.ToString()
      If estadoAnterior IsNot Nothing Then
         idTipoMovimientoAnterior = estadoAnterior.IdTipoMovimiento
         stockAfectadoAnterior = estadoAnterior.StockAfectado.ToString()
      Else
         'Si no tengo definido EstadoAnterior (estadoAnterior IS NOTHING), viene desde la pantalla de carga de Pedido
         'Entonces dejo en blanco el Tipo de Movimiento y Stock Afectado anterior para que:
         '     - Si el nuevo tiene definido Tipo de Movimiento y Stock Afectado, al ser diferente registre el movimiento
         '     - Si el nuevo NO tiene definido Tipo de Movimiento y Stock Afectado, al ser iguales NO registre el movimiento
      End If

      'Solo debo realizar movimientos de Stock si difieren en la propiedad de IdTipoMovimiento y StockAfectado.
      'Si son iguales significa que no cambian las cantidades.
      If idTipoMovimientoAnterior <> idTipoMovimientoNuevo Or stockAfectadoAnterior <> stockAfectadoNuevo Then
         Dim movimientosAGenerar = New Dictionary(Of String, Entidades.MovimientoStock)()
         If Not String.IsNullOrWhiteSpace(idTipoMovimientoAnterior) Then
            AgregaMovimientoStockPorCambioEstado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, producto, orden, ubicaciones, idTipoMovimientoAnterior, coe:=-1, movimientosAGenerar)
         End If

         If Not String.IsNullOrWhiteSpace(idTipoMovimientoNuevo) Then
            AgregaMovimientoStockPorCambioEstado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, producto, orden, ubicaciones, idTipoMovimientoNuevo, coe:=+1, movimientosAGenerar)
         End If

         Dim rMovimientoCompra = New MovimientosStock(da)
         For Each m In movimientosAGenerar.Values
            'Grabo los movimiento de stock
            rMovimientoCompra.CargarMovimientoStock(m, metodoGrabacion, idFuncion)
         Next
      End If         'If idTipoMovimientoAnterior <> idTipoMovimientoNuevo And stockAfectadoAnterior <> stockAfectadoNuevo Then
   End Sub

   Private Sub AgregaMovimientoStockPorCambioEstado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                    producto As Entidades.ProductoLivianoParaImportarProducto, orden As Integer, ubicaciones As List(Of Entidades.SeleccionMultipleUbicaciones),
                                                    idTipoMovimientoAnterior As String, coe As Integer, movimientosAGenerar As Dictionary(Of String, Entidades.MovimientoStock))
      'Instancio el Movimiento de Compra poniendo en la Observacion el motivo.
      Dim movi = New Entidades.MovimientoStock With {
         .IdSucursal = idSucursal,
         .Sucursal = _cache.BuscaSucursal(idSucursal),
         .TipoMovimiento = _cache.BuscaTipoMovimiento(idTipoMovimientoAnterior),
         .FechaMovimiento = Date.Now,
         .Usuario = actual.Nombre,
         .Observacion = String.Format("Cambio de estado de: {0} {1} {2:0000}-{3:00000000} Ln: {4}", idTipoComprobante, letra, centroEmisor, numeroPedido, orden)
      }

      movimientosAGenerar.Add(idTipoMovimientoAnterior, movi)

      For Each u In ubicaciones
         'Instancio un Movimiento de Compra Producto poniendo el producto y la cantidad.
         'Multiplico por -1 la cantidad porque este es el movimiento de salida del estado anterior. (asumo que el tipo está definido positivo)
         Dim moviProd = New Entidades.MovimientoStockProducto With {
                  .IdSucursal = idSucursal,
                  .IdDeposito = u.IdDeposito,
                  .IdUbicacion = u.IdUbicacion,
                  .IdProducto = producto.IdProducto,
                  .Orden = movi.Productos.Count + 1,
                  .Cantidad = u.Cantidad * coe
               }
         movi.Productos.Add(moviProd)

         If producto.Lote AndAlso movi.TipoMovimiento.CoeficienteStock <> 0 Then
            For Each l In u.Lotes
               Dim lote = New Entidades.ProductoLote() With {
                     .IdSucursal = l.IdSucursal,
                     .IdDeposito = l.IdDeposito,
                     .IdUbicacion = l.IdUbicacion,
                     .IdLote = l.IdLote.ToUpper(),
                     .FechaIngreso = movi.FechaMovimiento,
                     .FechaVencimiento = l.FechaVencimiento,
                     .CantidadInicial = l.Cantidad * coe,
                     .CantidadActual = l.Cantidad * coe,
                     .Habilitado = True
                  }
               lote.ProductoSucursal.IdSucursal = idSucursal
               lote.ProductoSucursal.Producto.IdProducto = producto.IdProducto

               movi.ProductosLotes.Add(lote)
            Next
         End If
         If producto.NroSerie AndAlso movi.TipoMovimiento.CoeficienteStock <> 0 Then
            moviProd.ProductosNrosSerie = u.NrosSerie.ConvertAll(
                                                Function(ns) New Entidades.MovimientoStockProductoNrosSerie() With {
                                                   .IdSucursal = ns.IdSucursal,
                                                   .IdDeposito = ns.IdDeposito,
                                                   .IdUbicacion = ns.IdUbicacion,
                                                   .IdTipoMovimiento = movi.TipoMovimiento.IdTipoMovimiento,
                                                   .NumeroMovimiento = movi.NumeroMovimiento,
                                                   .Orden = moviProd.Orden,
                                                   .IdProducto = ns.IdProducto,
                                                   .NroSerie = ns.NroSerie
                                                })
         End If
      Next
   End Sub
End Class