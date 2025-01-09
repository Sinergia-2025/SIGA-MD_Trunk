Public Class ucConfVentas1

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      e.Publicos.CargaComboDesdeEnum(cmbFacturacionSemaforoCalculoMuestra, GetType(Entidades.Publicos.SemaforoCalculoMuestra), , True)
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      txtDiasPresupuesto.Text = Reglas.Publicos.DiasValidezPresupuesto.ToString()
      txtUltimaHojaVentas.Text = Reglas.Publicos.NroHojaLibroIvaVentas.ToString()
      chbFacturacionModificaNumeroComprobante.Checked = Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante
      chbFacturacionModificaDescripcionProducto.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto
      chbFacturacionModificaPrecioProducto.Checked = Reglas.Publicos.Facturacion.FacturacionModificaPrecioProducto
      chbFacturacionModificaDescRecGralPorc.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescRecGralPorc
      chbFacturacionModificaDescRecargoProducto.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescRecProducto
      chbFacturacionModificaDescRecProductoPorMonto.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescRecProductoPorMonto

      txtIdentifNDEBGL.Text = Reglas.Publicos.IdNotaDebitoGrabaLibro
      txtIdentifNCREDGL.Text = Reglas.Publicos.IdNotaCreditoGrabaLibro
      txtIdentifNDEBNoGL.Text = Reglas.Publicos.IdNotaDebitoNoGrabaLibro
      txtIdentifNCREDNoGL.Text = Reglas.Publicos.IdNotaCreditoNoGrabaLibro

      chbFacturacionContadoEsEnPesos.Checked = Reglas.Publicos.Facturacion.FacturacionContadoEsEnPesos
      chbFacturacionTicketIncluyeRecargoGeneral.Checked = Reglas.Publicos.Facturacion.FacturacionTicketIncluyeRecargoGeneral
      chbFacturacionPresupuestoIncluyeRecargoGeneral.Checked = Reglas.Publicos.Facturacion.FacturacionPresupuestoIncluyeRecargoGeneral
      chbGrabaLibroNoIncluyeRecargoGeneral.Checked = Reglas.Publicos.Facturacion.GrabaLibroNoIncluyeRecargoGeneral


      'Columna 2
      chbFacturacionPermitirFechaNumAnterior.Checked = Reglas.Publicos.Facturacion.PermitirComprobFechaNumAnterior
      chbFacturacionPermitirFechaFutura.Checked = Reglas.Publicos.Facturacion.PermitirComprobFechaFutura
      chbFacturacionRapidaMantieneElCliente.Checked = Reglas.Publicos.Facturacion.FacturacionMantieneElCliente
      txtFacturacionMantieneElClienteDefault.Text = Reglas.Publicos.Facturacion.FacturacionMantieneElClienteDefault.ToString()
      chbFacturacionRapidaMantieneElComprobante.Checked = Reglas.Publicos.Facturacion.FacturacionMantieneElComprobante
      chbFacturacionPermiteFacturarEnOtrasMonedas.Checked = Reglas.Publicos.Facturacion.FacturacionPermiteFacturarEnOtrasMonedas
      chbVisualizaVentasAntesImprimir.Checked = Reglas.Publicos.VisualizaComprobantesDeVenta
      chbVisualizaSemaforoUtilidad.Checked = Reglas.Publicos.Facturacion.FacturacionVisualizaSemaforoUtilidad
      cmbFacturacionSemaforoCalculoMuestra.SelectedValue = Reglas.Publicos.Facturacion.FacturacionSemaforoCalculoMuestra
      chbActualizaPreciosDeVenta.Checked = Reglas.Publicos.ActualizaPreciosDeVenta
      chbVentasConProductosEnCero.Checked = Reglas.Publicos.VentasConProductosEnCero

      Dim splVentasPrecioCosto = Reglas.Publicos.Facturacion.VentasPrecioCosto.Split(";"c)
      cmbVentaPrecioCosto.Text = splVentasPrecioCosto(0)
      txtVentaPrecioCostoMeses.Text = If(splVentasPrecioCosto.Length > 1, splVentasPrecioCosto(1).ValorNumericoPorDefecto(0I).ToString(), "0")
      cmbVentaPrecioVenta.Text = Reglas.Publicos.Facturacion.VentasPrecioVenta

      chbFacturacionInvocarInvocador.Checked = Reglas.Publicos.Facturacion.FacturacionInvocarInvocador
      chbFacturacionInvocarDeOtroCliente.Checked = Reglas.Publicos.Facturacion.FacturacionInvocarDeOtroCliente
      chbFacturacionSolicitaVendedor.Checked = Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor
      chbFacturacionSolicitaComprobante.Checked = Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      txtFacturacionMantieneElClienteDefault.SetValor(txtFacturacionMantieneElClienteDefault.ValorNumericoPorDefecto(0I))

      ActualizarParametro(Entidades.Parametro.Parametros.DIASVALIDEZPRESUPUESTO, txtDiasPresupuesto, Nothing, lblDiasPresupuesto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.NROHOJALIBROIVAVENTAS, txtUltimaHojaVentas, Nothing, lblUltimaHojaVentas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICANUMEROCOMPROBANTE, chbFacturacionModificaNumeroComprobante, Nothing, chbFacturacionModificaNumeroComprobante.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRIPCIONPRODUCTO, chbFacturacionModificaDescripcionProducto, Nothing, chbFacturacionModificaDescripcionProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICAPRECIOPRODUCTO, chbFacturacionModificaPrecioProducto, Nothing, chbFacturacionModificaPrecioProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRECPRODUCTO, chbFacturacionModificaDescRecargoProducto, Nothing, chbFacturacionModificaDescRecargoProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRECGRALPORC, chbFacturacionModificaDescRecGralPorc, Nothing, chbFacturacionModificaDescRecGralPorc.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRECPRODUCTOPORMONTO, chbFacturacionModificaDescRecProductoPorMonto, Nothing, chbFacturacionModificaDescRecProductoPorMonto.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.IDNDEBGL, txtIdentifNDEBGL, Nothing, lblIdentifNDEBGL.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IDNCREDGL, txtIdentifNCREDGL, Nothing, lblIdentifNCREDGL.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IDNDEBNOGL, txtIdentifNDEBNoGL, Nothing, lblIdentifNDEBNoGL.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IDNCREDNOGL, txtIdentifNCREDNoGL, Nothing, lblIdentifNCREDNoGL.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCONTADOESENPESOS, chbFacturacionContadoEsEnPesos, Nothing, chbFacturacionContadoEsEnPesos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONTICKETINCLUYERECARGOGENERAL, chbFacturacionTicketIncluyeRecargoGeneral, Nothing, chbFacturacionTicketIncluyeRecargoGeneral.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPRESUPUESTOINCLUYERECARGOGENERAL, chbFacturacionPresupuestoIncluyeRecargoGeneral, Nothing, chbFacturacionPresupuestoIncluyeRecargoGeneral.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.GRABALIBRONOINCLUYERECARGOGENERAL, chbGrabaLibroNoIncluyeRecargoGeneral, Nothing, chbGrabaLibroNoIncluyeRecargoGeneral.Text)


      'Columna 2
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCOMPROBFECHNUMANTERIOR, chbFacturacionPermitirFechaNumAnterior, Nothing, chbFacturacionPermitirFechaNumAnterior.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCOMPROBFECHAFUTURA, chbFacturacionPermitirFechaFutura, Nothing, chbFacturacionPermitirFechaFutura.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMANTIENECLIENTE, chbFacturacionRapidaMantieneElCliente, Nothing, chbFacturacionRapidaMantieneElCliente.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMANTIENEELCLIENTEDEFAULT, txtFacturacionMantieneElClienteDefault, Nothing, lblFacturacionMantieneElClienteDefault.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMANTIENECOMPROBANTE, chbFacturacionRapidaMantieneElComprobante, Nothing, chbFacturacionRapidaMantieneElComprobante.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPERMITEFACTURARENOTRASMONEDAS, chbFacturacionPermiteFacturarEnOtrasMonedas, Nothing, chbFacturacionPermiteFacturarEnOtrasMonedas.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.VISUALIZACOMPROBANTESDEVENTA, If(chbVisualizaVentasAntesImprimir.Checked, "SI", "NO"), Nothing, chbVisualizaVentasAntesImprimir.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONVISUALIZASEMAFOROUTILIDAD, chbVisualizaSemaforoUtilidad, Nothing, chbVisualizaSemaforoUtilidad.Text)
      If cmbFacturacionSemaforoCalculoMuestra.SelectedIndex < 0 Then cmbFacturacionSemaforoCalculoMuestra.SelectedIndex = 0
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.FACTURACIONSEMAFOROCALCULOMUESTRA, cmbFacturacionSemaforoCalculoMuestra, Nothing, lblFacturacionSemaforoCalculoMuestra.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ACTUALIZAPRECIOSDEVENTA, chbActualizaPreciosDeVenta, Nothing, chbActualizaPreciosDeVenta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASCONPRODUCTOSENCERO, chbVentasConProductosEnCero, Nothing, chbVentasConProductosEnCero.Text)

      Dim ventaPrecioCosto = cmbVentaPrecioCosto.Text
      If (cmbVentaPrecioCosto.Text = "PROMPOND") Then
         ventaPrecioCosto = String.Concat(ventaPrecioCosto, ";", txtVentaPrecioCostoMeses.ValorNumericoPorDefecto(0I).ToString())
      End If
      ActualizarParametroTexto(Entidades.Parametro.Parametros.VENTASPRECIOCOSTO, ventaPrecioCosto, Nothing, lblVentaPrecioCosto.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.VENTASPRECIOVENTA, cmbVentaPrecioVenta.Text, Nothing, lblVentaPrecioVenta.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONINVOCARINVOCADOR, chbFacturacionInvocarInvocador, Nothing, chbFacturacionInvocarInvocador.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONINVOCARDEOTROCLIENTE, chbFacturacionInvocarDeOtroCliente, Nothing, chbFacturacionInvocarDeOtroCliente.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSOLICITAVENDEDOR, chbFacturacionSolicitaVendedor, Nothing, chbFacturacionSolicitaVendedor.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSOLICITACOMPROBANTE, chbFacturacionSolicitaComprobante, Nothing, chbFacturacionSolicitaComprobante.Text)

   End Sub

   Private Sub cmbVentaPrecioCosto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVentaPrecioCosto.SelectedValueChanged
      FindForm().TryCatched(Sub() txtVentaPrecioCostoMeses.Enabled = cmbVentaPrecioCosto.Text = "PROMPOND")
   End Sub

End Class