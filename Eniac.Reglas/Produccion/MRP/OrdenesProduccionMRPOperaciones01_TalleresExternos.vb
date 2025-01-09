Imports System.Drawing
Imports Eniac.Entidades

Partial Class OrdenesProduccionMRPOperaciones

#Region "Envio Talleres Externos"
   Public Function CalculaProductosEnvioTalleresExternos(dtSeleccion As DataTable, idProveedor As Long) As DataSet
      Dim pkOPMRP = New List(Of Entidades.OrdenProduccionMRPPK)()
      For Each drSelec In dtSeleccion.AsEnumerable()
         Dim pkNueva = New Entidades.OrdenProduccionMRPPK() With {
                           .IdSucursal = drSelec.Field(Of Integer)("IdSucursal"),
                           .IdTipoComprobante = drSelec.Field(Of String)("IdTipoComprobante"),
                           .LetraComprobante = drSelec.Field(Of String)("LetraComprobante"),
                           .CentroEmisor = drSelec.Field(Of Integer)("CentroEmisor"),
                           .NumeroOrdenProduccion = drSelec.Field(Of Integer)("NumeroOrdenProduccion"),
                           .Orden = drSelec.Field(Of Integer)("Orden"),
                           .IdProducto = drSelec.Field(Of String)("IdProducto"),
                           .IdProcesoProductivo = drSelec.Field(Of Long)("IdProcesoProductivo")
            }
         If Not pkOPMRP.Exists(Function(pk) pk.IdSucursal = pkNueva.IdSucursal And
                                            pk.IdTipoComprobante = pkNueva.IdTipoComprobante And
                                            pk.LetraComprobante = pkNueva.LetraComprobante And
                                            pk.CentroEmisor = pkNueva.CentroEmisor And
                                            pk.NumeroOrdenProduccion = pkNueva.NumeroOrdenProduccion And
                                            pk.Orden = pkNueva.Orden And
                                            pk.IdProducto = pkNueva.IdProducto And
                                            pk.IdProcesoProductivo = pkNueva.IdProcesoProductivo) Then
            pkOPMRP.Add(pkNueva)
         End If
      Next

      Dim dtNecesarios = GetSql().OrdenesProduccionMRPOperaciones_GA_TalleresExternos(idProveedor:=idProveedor, fechaDesde:=Nothing, fechaHasta:=Nothing, idCentroProductor:=0, idTipoComprobanteOP:=String.Empty, numeroOrdenProduccion:=0, idTipoComprobantePedido:=String.Empty, numeroPedido:=0, ordenPedido:=0,
                                                                                      esProductoNecesario:=Entidades.Publicos.SiNoTodos.SI, pkOPMRP)

      For Each drSelec In dtSeleccion.AsEnumerable()
         For Each drNecesario In dtNecesarios.Where(Function(drNec) drNec.Field(Of Integer)("IdSucursal") = drSelec.Field(Of Integer)("IdSucursal") And
                                                                    drNec.Field(Of String)("IdTipoComprobante") = drSelec.Field(Of String)("IdTipoComprobante") And
                                                                    drNec.Field(Of String)("LetraComprobante") = drSelec.Field(Of String)("LetraComprobante") And
                                                                    drNec.Field(Of Integer)("CentroEmisor") = drSelec.Field(Of Integer)("CentroEmisor") And
                                                                    drNec.Field(Of Integer)("NumeroOrdenProduccion") = drSelec.Field(Of Integer)("NumeroOrdenProduccion") And
                                                                    drNec.Field(Of Integer)("Orden") = drSelec.Field(Of Integer)("Orden") And
                                                                    drNec.Field(Of String)("IdProducto") = drSelec.Field(Of String)("IdProducto") And
                                                                    drNec.Field(Of Long)("IdProcesoProductivo") = drSelec.Field(Of Long)("IdProcesoProductivo"))
            drNecesario("CantidadSeleccionada") = drNecesario.Field(Of Decimal)("CantidadPendiente") * drSelec.Field(Of Decimal)("CantidadSeleccionada") / drSelec.Field(Of Decimal)("CantidadPendiente")

            drNecesario("CantidadSeleccionadaCompra") = IIf(drNecesario.Field(Of Decimal)("FactorConversionCompra") = 0, 0D,
                                                            (drSelec.Field(Of Decimal)("CantidadSeleccionada") * drNecesario.Field(Of Decimal)("FactorConversionCompra")))


         Next
      Next

      dtSeleccion.Columns.Add("Vincular", GetType(Object))
      dtNecesarios.Columns.Add("LoteSeleccionado", GetType(String))
      dtNecesarios.Columns.Add("NroSerieSeleccionado", GetType(String))
      dtNecesarios.Columns.Add("NombreDepositoUbicacion", GetType(String))
      dtNecesarios.Columns.Add("SeleccionMultiple", GetType(Object))

      Dim cache = New BusquedasCacheadas()
      Dim rProd = New Productos(da)
      Dim rProdSuc = New SucursalesUbicaciones(da)

      For Each dr In dtNecesarios.AsEnumerable()
         Dim prod = rProd._GetUnoParaM(dr.Field(Of String)("IdProductoProceso"))
         Dim prodSuc = rProdSuc.GetUno(prod.IdDepositoDefecto, prod.IdSucursal, prod.IdUbicacionDefecto)
         dr("SeleccionMultiple") = New List(Of Entidades.SeleccionMultipleUbicaciones)({New Entidades.SeleccionMultipleUbicaciones() With {
                                                                                          .Producto = prod,
                                                                                          .Ubicacion = prodSuc,
                                                                                          .Cantidad = dr.Field(Of Decimal)("CantidadSeleccionada")
                                                                                       }})
      Next

      Return New DataSet().Add("ProductosResultantes", dtSeleccion).Add("ProductosNecesarios", dtNecesarios)
   End Function
   Public Function GetOperacionesEnvioTalleresExternos(idProveedor As Long, fechaDesde As Date?, fechaHasta As Date?,
                                                       idCentroProductor As Integer,
                                                       idTipoComprobanteOP As String, numeroOrdenProduccion As Long,
                                                       idTipoComprobantePedido As String, numeroPedido As Integer, ordenPedido As Integer) As DataTable
      Return GetSql().OrdenesProduccionMRPOperaciones_GA_TalleresExternos(idProveedor, fechaDesde, fechaHasta,
                                                                          idCentroProductor,
                                                                          idTipoComprobanteOP, numeroOrdenProduccion,
                                                                          idTipoComprobantePedido, numeroPedido, ordenPedido,
                                                                          esProductoNecesario:=Entidades.Publicos.SiNoTodos.NO, pkOPMRP:=Nothing)
   End Function

   Public Sub GrabarProductosEnvioTalleresExternos(dtProductosResultantes As DataTable, dtProductosNecesarios As DataTable,
                                                   tipoComprobante As Entidades.TipoComprobante, proveedor As Entidades.Proveedor,
                                                   transportista As Entidades.Transportista, totalBultos As Integer, valorDeclarado As Decimal, lote As Integer,
                                                   idFuncion As String)
      EjecutaConTransaccion(Sub() _GrabarProductosEnvioTalleresExternos(dtProductosResultantes, dtProductosNecesarios,
                                                                        tipoComprobante, proveedor,
                                                                        transportista, totalBultos, valorDeclarado, lote,
                                                                        New BusquedasCacheadas(), idFuncion))
   End Sub
   Public Sub _GrabarProductosEnvioTalleresExternos(dtProductosResultantes As DataTable, dtProductosNecesarios As DataTable,
                                                    tipoComprobante As Entidades.TipoComprobante, proveedor As Entidades.Proveedor,
                                                    transportista As Entidades.Transportista, totalBultos As Integer, valorDeclarado As Decimal, lote As Integer,
                                                    cache As BusquedasCacheadas, idFuncion As String)

      Dim rCompras = New Compras(da)
      Dim rPE = New PedidosEstadosProveedores(da)

      Dim compra = _CrearRemitoEnvioTalleresExternos(dtProductosNecesarios, tipoComprobante, proveedor, transportista, totalBultos, valorDeclarado, lote, cache, rCompras)
      Dim cambio = _CambioEstadoOrdenCompra(dtProductosResultantes, cache, rPE)

      Dim CompraObs = compra.ComprasObservaciones.ClonarColeccion

      Dim rMovimientos = New MovimientosStock(da)

      Dim oMov = rCompras.PreparaCompraParaGrabar(compra, cache)

      '----PE:43349-Generar Obs.detalladas en el Remito Compra Transporte que contenga las OC vinculadas a enviar
      For Each filaGrabar In cambio.Pedidos.OfType(Of Entidades.PedidosProveedoresAdminPedidos)
         oMov.Compra.ComprasObservaciones.Add(New Entidades.CompraObservacion With {.Observacion = String.Format("Vinculo:{0}-{1}-{2}-{3} Fecha: {4}",
                                                                                                                 filaGrabar.IdTipoComprobante,
                                                                                                                 filaGrabar.Letra,
                                                                                                                 filaGrabar.CentroEmisor,
                                                                                                                 filaGrabar.NumeroPedido,
                                                                                                                 filaGrabar.FechaPedido)})
      Next

      rMovimientos._Insertar(oMov, dtExpensas:=New DataTable(), Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
      rPE._ActualizarEstadoPedidoProveedorMasivo(cambio, idFuncion, CompraObs)

      'Throw New Exception("Corte para pruebas")

   End Sub

   Public Function _CrearRemitoEnvioTalleresExternos(dtProductosNecesarios As DataTable,
                                                     tipoComprobante As Entidades.TipoComprobante, proveedor As Entidades.Proveedor,
                                                     transportista As Entidades.Transportista, totalBultos As Integer, valorDeclarado As Decimal, lote As Integer,
                                                     cache As BusquedasCacheadas, rCompras As Compras) As Entidades.Compra
      Dim rFormaPago = New VentasFormasPago(da)
      Dim fpContado = rFormaPago.GetUna("Compras", esContado:=True)
      Dim decimalesRedondeoEnPrecio = Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnPrecio

      Dim c = rCompras.CreaCompra(actual.Sucursal.Id, tipoComprobante, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=Nothing,
                                  fecha:=Date.Now, proveedor, comprador:=cache.GetPrimerComprador(), descuentoRecargoPorc:=0, cotizacionDolar:=Nothing,
                                  fpContado, idCaja:=0, observacion:=String.Empty,
                                  cache)

      Dim orden = 0I
      For Each drPN In dtProductosNecesarios.AsEnumerable()
         Dim producto = cache.BuscaProductoEntidadPorId(drPN.Field(Of String)("IdProductoProceso"), da)
         Dim prodLiv = New Productos(da)._GetUnoParaM(drPN.Field(Of String)("IdProductoProceso"))
         Dim nombreProducto = drPN.Field(Of String)("NombreProductoResultante")

         '-- REQ-42982.- ----------------------------------------------------------------------------------
         c.ComprasObservaciones.Add(New Entidades.CompraObservacion With {.Observacion = String.Format("{0} {1}", producto.IdProducto, drPN.Field(Of String)("NombreProductoResultante"))})
         c.ComprasObservaciones.Add(New Entidades.CompraObservacion With {.Observacion = String.Format("Método:{0}", drPN.Field(Of String)("NormasMetodos"))})
         '--------------------------------------------------------------------------------------------------

         Dim ubics = drPN.Field(Of List(Of Entidades.SeleccionMultipleUbicaciones))("SeleccionMultiple")
         If ubics Is Nothing Then
            Dim prodUbic = New SucursalesUbicaciones(da).GetUno(prodLiv.IdDepositoDefecto, prodLiv.IdSucursal, prodLiv.IdUbicacionDefecto)
            ubics = New List(Of Entidades.SeleccionMultipleUbicaciones)({New Entidades.SeleccionMultipleUbicaciones() With {
                                                                              .Producto = prodLiv,
                                                                              .Ubicacion = prodUbic,
                                                                              .Cantidad = drPN.Field(Of Decimal)("CantidadSeleccionada")
                                                                        }})
         Else
            If ubics.Count = 1 Then
               ubics(0).Cantidad = drPN.Field(Of Decimal)("CantidadSeleccionada")
            End If
         End If

         For Each u In ubics
            If Not u.Lotes.AnySecure() Then
               u.Lotes.Add(New Entidades.SeleccionMultipleLotes() With {
                                 .IdLote = String.Empty,
                                 .Cantidad = u.Cantidad,
                                 .UbicacionAdmin = u
                              })
            End If

            For Each l In u.Lotes
               Dim cantidad = l.Cantidad
               Dim FactorConversionCompra = producto.FactorConversionCompra
               '  Dim kilosProducto = If(producto.KilosEsUMCompras, producto.Kilos, 0D)
               Dim idDeposito = l.IdDeposito
               Dim idUbicacion = l.IdUbicacion

               Dim idLote = l.IdLote
               Dim vtoLote = l.FechaVencimiento
               Dim informeNumero = l.InformeCalidadNumero
               Dim informeLink = l.InformeCalidadLink
               Dim nrosSerie As List(Of String) = Nothing      'Ignoramos Nro de Serie hasta que esté la necesidad para no complicar el desarrollo ahora y llegar con fechas.

               orden += 1

               Dim cp = rCompras.CreaCompraProducto(c, producto:=producto, nombreProducto,
                                                    descuentoRecargoPorc:=0, cantidad, FactorConversionCompra, precioPorKilo:=0I,
                                                    idDeposito, idUbicacion, precio:=Nothing, alicuotaIVA:=Nothing,
                                                    orden, idLote, vtoLote,
                                                    informeNumero, informeLink, nrosSerie,
                                                    decimalesRedondeoEnPrecio,
                                                    cache)

               rCompras.AgregaCompraProducto(c, cp, decimalesRedondeoEnPrecio)
            Next
         Next
      Next

      rCompras.PreparaRemitoTransporte(c, transportista, totalBultos, valorDeclarado, lote)

      Return c
   End Function
   Public Function _CambioEstadoOrdenCompra(dtProductosResultantes As DataTable, cache As BusquedasCacheadas, rPE As PedidosEstadosProveedores) As Entidades.PedidosProveedoresAdminCambioEstado
      Dim cambio = New Entidades.PedidosProveedoresAdminCambioEstado(cache.BuscaEstadosPedidoProveedores(Reglas.Publicos.EstadoOrdenCompraVinculada, Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString()))

      For Each drProd In dtProductosResultantes.AsEnumerable()
         Dim drColOC = drProd.Field(Of DataRow())("Vincular")
         If drColOC.AnySecure() Then
            For Each drOC In drColOC.Where(Function(dr) dr.Field(Of String)("masivo") = Boolean.TrueString)
               Dim pedidos = rPE._GetParaAdminPedidos(drOC.Field(Of Integer)(Entidades.PedidoEstadoProveedor.Columnas.IdSucursal.ToString()),
                                                      drOC.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobante.ToString()),
                                                      drOC.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.Letra.ToString()),
                                                      drOC.Field(Of Integer)(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisor.ToString()),
                                                      drOC.Field(Of Long)(Entidades.PedidoEstadoProveedor.Columnas.NumeroPedido.ToString()),
                                                      drOC.Field(Of Integer)(Entidades.PedidoEstadoProveedor.Columnas.Orden.ToString()),
                                                      drOC.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdProducto.ToString()),
                                                      drOC.Field(Of Date)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstado.ToString()))
               Dim cantidadVinculada = 0D
               If Not pedidos.Any() Then
                  Throw New Exception(String.Format("No se encontró Estado de Pedido para {0}/{1} {2} {3:0000}-{4:00000000} Ln: {5} / Prod: {6} / Fecha Estado: {7:dd/MM/yyyy}",
                                                    drOC.Field(Of Integer)(Entidades.PedidoEstadoProveedor.Columnas.IdSucursal.ToString()),
                                                    drOC.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobante.ToString()),
                                                    drOC.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.Letra.ToString()),
                                                    drOC.Field(Of Integer)(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisor.ToString()),
                                                    drOC.Field(Of Long)(Entidades.PedidoEstadoProveedor.Columnas.NumeroPedido.ToString()),
                                                    drOC.Field(Of Integer)(Entidades.PedidoEstadoProveedor.Columnas.Orden.ToString()),
                                                    drOC.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdProducto.ToString()),
                                                    drOC.Field(Of Date)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstado.ToString())))
               Else
                  ' Dim pedido = pedidos.First()
                  pedidos.First().Cantidad = drOC.Field(Of Decimal)("CantidadNuevoEstado")

                  pedidos.First().OPOperacionTalleresExternos = New Entidades.OrdenProduccionMRPOperacion_PK() With {
                           .IdSucursal = drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString()),
                           .IdTipoComprobante = drProd.Field(Of String)(Entidades.OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString()),
                           .LetraComprobante = drProd.Field(Of String)(Entidades.OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString()),
                           .CentroEmisor = drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString()),
                           .NumeroOrdenProduccion = drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString()),
                           .Orden = drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.Orden.ToString()),
                           .IdProducto = drProd.Field(Of String)(Entidades.OrdenProduccionMRPProducto.Columnas.IdProducto.ToString()),
                           .IdProcesoProductivo = drProd.Field(Of Long)(Entidades.OrdenProduccionMRPProducto.Columnas.IdProcesoProductivo.ToString()),
                           .IdOperacion = drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.IdOperacion.ToString())
                        }
                  If Not String.IsNullOrEmpty(drProd("IdTipoComprobantePedido").ToString()) Then
                     pedidos.First().IdTipoComprobantePedido = drProd("IdTipoComprobantePedido").ToString()
                     pedidos.First().CentroEmisorPedido = Integer.Parse(drProd("CentroEmisorPedido").ToString())
                     pedidos.First().LetraPedido = drProd("LetraPedido").ToString()
                     pedidos.First().NumeroPedidoPedido = Long.Parse(drProd("NumeroPedido").ToString())
                     pedidos.First().DescripcionTipoComprobantePedido = drProd("DescripcionTipoComprobantePedido").ToString()
                     pedidos.First().OrdenPedido = Integer.Parse(drProd("OrdenPedido").ToString())
                     pedidos.First().IdProductoPedido = drProd("IdProductoPedido").ToString()
                  End If
               End If
               cambio.Pedidos.AddRange(pedidos)
            Next
         Else
            Throw New Exception(String.Format("No seleccionó OC para vincular a {0} - {1} / {3} {4} {5:0000}-{6:00000000} Ln: {7}",
                                              drProd.Field(Of String)(Entidades.OrdenProduccionMRPProducto.Columnas.IdProducto.ToString()),
                                              drProd.Field(Of String)(Entidades.Producto.Columnas.NombreProducto.ToString()),
                                              drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString()),
                                              drProd.Field(Of String)(Entidades.OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString()),
                                              drProd.Field(Of String)(Entidades.OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString()),
                                              drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString()),
                                              drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString()),
                                              drProd.Field(Of Integer)(Entidades.OrdenProduccionMRPProducto.Columnas.Orden.ToString())))
         End If
      Next

      Return cambio
   End Function


#End Region



#Region "Eliminables"
   Public Function GetOperacionesTalleresExternos(proveedor As Long, fechaDesde As Date, fechaHasta As Date,
                                                  idCenroProductor As Integer,
                                                  idTipoComprobanteOP As String, ordenProduccion As Long,
                                                  idTipoComprobantePedido As String, idPedido As Integer, linea As Integer) As List(Of Entidades.OrdenProduccionMRPOperacion)
      Using dt = GetSql().OrdenesProduccionMRPOperaciones_GA_TalleresExternos_old(proveedor, fechaDesde, fechaHasta,
                                                                              idCenroProductor,
                                                                              idTipoComprobanteOP, ordenProduccion,
                                                                              idTipoComprobantePedido, idPedido, linea)
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr, incluirHijos:=True), Function() New Entidades.OrdenProduccionMRPOperacion())
      End Using
   End Function
#End Region

End Class