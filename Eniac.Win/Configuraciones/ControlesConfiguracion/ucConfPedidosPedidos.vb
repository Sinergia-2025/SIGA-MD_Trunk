Public Class ucConfPedidosPedidos

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      e.Publicos.CargaComboEstadosPedidos(cmbEstadosPedidos, False, False, False, False, False, "PEDIDOSCLIE")
      e.Publicos.CargaComboEstadosPedidos(cmbEstadosPedidosFacturado, False, False, False, False, False, "PEDIDOSCLIE")
      e.Publicos.CargaComboEstadosPedidos(cmbEstadoPresupuestoAlAnularPedido, False, False, False, False, False, "PRESUPCLIE")
      e.Publicos.CargaComboTiposComprobantes(cmbImportarPedidosTipoComprobante, False, "PEDIDOSCLIE")
      e.Publicos.CargaComboDesdeEnum(cmbImportarPedidosFormatoArchivo, GetType(Entidades.Pedido.FormatoImportarPedidos), , True)
      e.Publicos.CargaComboDesdeEnum(cmbCopiaPresupuestoActualizaPrecio, GetType(Reglas.Publicos.SiempreNuncaPreguntar), , True)
      e.Publicos.CargaComboMonedas1(cmbMonedaPorDefecto)
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Pedidos Clientes
      chbPedidosPendientesFacturarAutomatico.Checked = Reglas.Publicos.PedidosFacturarAutomatico
      chbPedidosVisualizaAntesImprimir.Checked = Reglas.Publicos.PedidosVisualiza

      If cmbEstadosPedidos.Items.Count > 0 Then cmbEstadosPedidos.SelectedValue = Reglas.Publicos.EstadoPedidoPendiente
      If cmbEstadosPedidosFacturado.Items.Count > 0 Then cmbEstadosPedidosFacturado.SelectedValue = Reglas.Publicos.EstadoPedidoFacturado
      If cmbEstadoPresupuestoAlAnularPedido.Items.Count > 0 Then cmbEstadoPresupuestoAlAnularPedido.SelectedValue = Reglas.Publicos.EstadoPresupuestoAlAnularPedido

      chbPedidosSolicitaTransportista.Checked = Reglas.Publicos.PedidosSolicitaTransportista
      chbPedidosSolicitaComprobanteGenerar.Checked = Reglas.Publicos.PedidosSolicitaComprobanteGenerar
      chbPermiteModificarClientePedido.Checked = Reglas.Publicos.PermiteModificarClientePedido
      chbFacturarPedidoSeleccionado.Checked = Reglas.Publicos.Facturacion.FacturarPedidoSeleccionado
      chbPrefacturaConsumePedido.Checked = Reglas.Publicos.PreFacturaConsumePedidos
      chbPedidosPermiteFechaEntregaDistintas.Checked = Reglas.Publicos.PedidosPermiteFechaEntregaDistintas
      chbUtilizaOrdenCompraPedidos.Checked = Reglas.Publicos.UtilizaOrdenCompraPedidos
      chbConvertirPedidoEnFacturaConservaPreciosPedido.Checked = Reglas.Publicos.ConvertirPedidoEnFacturaConservaPreciosPedido

      chbPedidosGeneraOrdenProduccionPorProducto.Checked = Reglas.Publicos.PedidoGeneraOrdenProduccionPorProducto


      cmbImportarPedidosFormatoArchivo.SelectedValue = Reglas.Publicos.ImportarPedidosFormatoArchivo.ToString()
      cmbImportarPedidosTipoComprobante.SelectedValue = Reglas.Publicos.ImportarPedidosTipoComprobante
      txtDiasEntregaImportacion.Text = Reglas.Publicos.CantidadDiasEntregaImportacion.ToString()


      chbPedidosModificaDescripSolicitaKilos.Checked = Reglas.Publicos.PedidosModificaDescripSolicitaKilos
      chbPedidosModificaPrecioProducto.Checked = Reglas.Publicos.PedidosModificaPrecioProducto
      chbPermiteModificarDescRecPedidos.Checked = Reglas.Publicos.PedidosPermiteModificarDescRecPedidos()
      chbPedidosOcultarRentabilidad.Checked = Reglas.Publicos.PedidosOcultarRentabilidad
      chbPedidosPermiteModificarCambio.Checked = Reglas.Publicos.PedidosPermiteModificarCambio

      chbPedidoGenPedProvOCObligatoria.Checked = Reglas.Publicos.PedidosGenPedProvOCObligatoria
      chbImportarPedidosAltaProd.Checked = Reglas.Publicos.ImportarPedidosAltaProductos
      chbPedidosConservaOrdenProductos.Checked = Reglas.Publicos.PedidosConservaOrdenProductos
      '-- REQ-34676.- -------------------------------------------------------------------------
      chbPedidosValidaFacturaRemitoProveedor.Checked = Reglas.Publicos.PedidosValidaFacturaRemitoProveedor
      '----------------------------------------------------------------------------------------
      chbPedidosPresupuestosAgrupaProductos.Checked = Reglas.Publicos.PedidosPresupuestosAgrupaProductos

      cmbCopiaPresupuestoActualizaPrecio.SelectedValue = Reglas.Publicos.CopiaPresupuestoActualizaPrecios

      Select Case Publicos.PedidosControlaEventosdeLimiteDeCreditoDeClientes
         Case "Permitir"
            rbtPermitirFacturarCreditoLimite.Checked = True
         Case "No Permitir"
            rbtNoPermitirFacturarCreditoLimite.Checked = True
         Case Else
            rbtAvisarPermitirFacturarCreditoLimite.Checked = True
      End Select

      Select Case Publicos.PedidosControlaDiasVtoDeCreditoDeClientes
         Case "Permitir"
            rbtPermitirFacturarLimiteDiasVto.Checked = True
         Case "No Permitir"
            rbtNoPermitirFacturarLimiteDiasVto.Checked = True
         Case Else
            rbtAvisarPermitirFacturarLimiteDiasVto.Checked = True
      End Select
      cmbMonedaPorDefecto.SelectedValue = Reglas.Publicos.PedidosMonedaPorDefecto

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Pedidos Clientes
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSFACTURARAUTOMATICO, chbPedidosPendientesFacturarAutomatico, Nothing, chbPedidosPendientesFacturarAutomatico.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSVISUALIZA, chbPedidosVisualizaAntesImprimir, Nothing, chbPedidosVisualizaAntesImprimir.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.PEDIDOSESTADOAREMITIR, cmbEstadosPedidos, Nothing, cmbEstadosPedidos.LabelAsoc.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOPRESUPUESTOALANULARPEDIDO, cmbEstadoPresupuestoAlAnularPedido, Nothing, cmbEstadoPresupuestoAlAnularPedido.LabelAsoc.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.PEDIDOSESTADOFACTURADO, cmbEstadosPedidosFacturado, Nothing, cmbEstadosPedidosFacturado.LabelAsoc.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSSOLICITATRANSPORTISTA, chbPedidosSolicitaTransportista, Nothing, chbPedidosSolicitaTransportista.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSSOLICITACOMPROBANTEGENERAR, chbPedidosSolicitaComprobanteGenerar, Nothing, chbPedidosSolicitaComprobanteGenerar.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPERMITEMODIFICARCLIENTE, chbPermiteModificarClientePedido, Nothing, chbPermiteModificarClientePedido.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURARPEDIDOSELECCIONADO, chbFacturarPedidoSeleccionado, Nothing, chbFacturarPedidoSeleccionado.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PREFACTURACONSUMEPEDIDOS, chbPrefacturaConsumePedido, Nothing, chbPrefacturaConsumePedido.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPERMITEFECHAENTREGADISTINTAS, chbPedidosPermiteFechaEntregaDistintas, Nothing, chbPedidosPermiteFechaEntregaDistintas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSUTILIZAORDENCOMPRA, chbUtilizaOrdenCompraPedidos, Nothing, chbUtilizaOrdenCompraPedidos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CONVERTIRPEDIDOENFACTURACONSERVAPRECIOSPEDIDO, chbConvertirPedidoEnFacturaConservaPreciosPedido, Nothing, chbConvertirPedidoEnFacturaConservaPreciosPedido.Text)

      If cmbImportarPedidosFormatoArchivo.SelectedIndex > -1 Then
         ActualizarParametroTexto(Entidades.Parametro.Parametros.IMPORTARPEDIDOSFORMATOARCHIVO, cmbImportarPedidosFormatoArchivo.SelectedValue.ToString(), Nothing, lblImportarPedidosFormatoArchivo.Text)
      End If
      If cmbImportarPedidosTipoComprobante.SelectedIndex > -1 Then
         ActualizarParametroTexto(Entidades.Parametro.Parametros.IMPORTARPEDIDOSTIPOCOMPROBANTE, cmbImportarPedidosTipoComprobante.SelectedValue.ToString(), Nothing, lblImportarPedidosTipoComprobante.Text)
      End If
      ActualizarParametro(Entidades.Parametro.Parametros.DIASENTREGAIMPORTACION, txtDiasEntregaImportacion, Nothing, lblDiasEntregaImportacion.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMODIFICADESCRIPSOLICITAKILOS, chbPedidosModificaDescripSolicitaKilos, Nothing, chbPedidosModificaDescripSolicitaKilos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSMODIFICAPRECIOPRODUCTO, chbPedidosModificaPrecioProducto, Nothing, chbPedidosModificaPrecioProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPERMITEMODIFICARDESCREC, chbPermiteModificarDescRecPedidos, Nothing, chbPermiteModificarDescRecPedidos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOCULTARENTABILIDAD, chbPedidosOcultarRentabilidad, Nothing, chbPedidosOcultarRentabilidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPERMITEMODIFICARCAMBIO, chbPedidosPermiteModificarCambio, Nothing, chbPedidosPermiteModificarCambio.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOGENERAORDENPRODUCCIONPORPRODUCTO, chbPedidosGeneraOrdenProduccionPorProducto, Nothing, chbPedidosGeneraOrdenProduccionPorProducto.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSGENPEDPROVOCOBLIGATORIA, chbPedidoGenPedProvOCObligatoria, Nothing, chbPedidoGenPedProvOCObligatoria.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IMPORTARPEDIDOSALTAPRODUCTOS, chbImportarPedidosAltaProd, Nothing, chbImportarPedidosAltaProd.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSCLIENTESCONSERVAORDENPRODUCTOS, chbPedidosConservaOrdenProductos, Nothing, chbPedidosConservaOrdenProductos.Text)

      '-- REQ-34676.- -------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSCLIENTESVALIDAREMITOFACTURAPROVEEDOR, chbPedidosValidaFacturaRemitoProveedor, Nothing, chbPedidosValidaFacturaRemitoProveedor.Text)
      '----------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPRESUPUESTOSAGRUPAPRODUCTOS, chbPedidosPresupuestosAgrupaProductos, Nothing, chbPedidosPresupuestosAgrupaProductos.Text)

      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.COPIAPRESUPUESTOACTUALIZAPRECIO, cmbCopiaPresupuestoActualizaPrecio, Nothing, lblActualizaPrecioCopia.Text)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.PEDIDOSCONTROLAEVENTOSDELIMITEDECREDITODECLIENTES,
                           If(rbtPermitirFacturarCreditoLimite.Checked, rbtPermitirFacturarCreditoLimite.Text,
                              If(rbtNoPermitirFacturarCreditoLimite.Checked, rbtNoPermitirFacturarCreditoLimite.Text,
                                 rbtAvisarPermitirFacturarCreditoLimite.Text)),
                           Nothing, String.Concat(grbPermitirControlarLimiteCredito.Text, " - ", lblCreditoLimite.Text))

      ActualizarParametroTexto(Entidades.Parametro.Parametros.PEDIDOSCONTROLADIASVTODECREDITODECLIENTES,
                           If(rbtPermitirFacturarLimiteDiasVto.Checked, rbtPermitirFacturarLimiteDiasVto.Text,
                              If(rbtNoPermitirFacturarLimiteDiasVto.Checked, rbtNoPermitirFacturarLimiteDiasVto.Text,
                                 rbtAvisarPermitirFacturarLimiteDiasVto.Text)),
                           Nothing, String.Concat(grbPermitirControlarLimiteCredito.Text, " - ", lblLimiteDiasVto.Text))

      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.PEDIDOSMONEDAPORDEFECTO, cmbMonedaPorDefecto, Nothing, lblMonedaPorDefecto.Text)

   End Sub

End Class