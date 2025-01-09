Public Class ucConfVentasCajero

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbCajeroGenera, GetType(Entidades.VentaCajero.CajeroGenera), , True)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbCajerosAbrirVariasVentanasFacturacion.Checked = Reglas.Publicos.CajeroAbrirVariasVentanasDeFactuacion
      chbCajerosActualizacionAutomatica.Checked = Reglas.Publicos.CajeroPermiteActualizacionAutomatica
      txtTiempoDeActAutomatica.Text = Reglas.Publicos.CajeroTiempoDeActualizacionAutomatica.ToString()

      cmbCajeroGenera.SelectedValue = Reglas.Publicos.CajeroGenera
      chbCajeroSeleccionMultiple.Checked = Reglas.Publicos.CajeroSeleccionMultiple

      txtIdentifNDEBCheqRech.Text = Reglas.Publicos.IdNotaDebitoChequeRechazado
      txtTipoComprobanteEnviadoCajero.Text = Reglas.Publicos.TipoComprobanteEnviadoCajero
      txtTipoComprobanteGeneradoCajero.Text = Reglas.Publicos.TipoComprobanteGeneradoCajero

      chbCajeroIgnorarTipoComprobanteCliente.Checked = Reglas.Publicos.CajeroIgnorarTipoComprobanteCliente


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.CAJEROABRIRVARIASVENTANASDEFACTURACION, chbCajerosAbrirVariasVentanasFacturacion, Nothing, chbCajerosAbrirVariasVentanasFacturacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJEROPERMITEACTUALIZACIONAUTOMATICA, chbCajerosActualizacionAutomatica, Nothing, chbCajerosActualizacionAutomatica.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJEROTIEMPODEACTUALIZACIONAUTOMATICA, txtTiempoDeActAutomatica, Nothing, txtTiempoDeActAutomatica.Text)

      If cmbCajeroGenera.SelectedIndex < 0 Then cmbCajeroGenera.SelectedIndex = 0
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.FACTURACIONCAJEROGENERA, cmbCajeroGenera, Nothing, lblCajeroGenera.Text)
      If cmbCajeroGenera.SelectedItem.Equals(Entidades.VentaCajero.CajeroGenera.Recibos.ToString()) Then
         ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCAJEROSELECCIONMULTIPLE, chbCajeroSeleccionMultiple, Nothing, chbCajeroSeleccionMultiple.Text)
      Else
         ActualizarParametroTexto(Entidades.Parametro.Parametros.FACTURACIONCAJEROSELECCIONMULTIPLE, Boolean.FalseString, Nothing, chbCajeroSeleccionMultiple.Text)
      End If


      ActualizarParametro(Entidades.Parametro.Parametros.NDEBCHEQRECH, txtIdentifNDEBCheqRech, Nothing, lblIdentifNDebCheqCheq.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONTIPOCOMPROBANTEGENERADOCAJERO, txtTipoComprobanteGeneradoCajero, Nothing, lblTipoComprobanteGeneradoCajero.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONTIPOCOMPROBANTEENVIADOCAJERO, txtTipoComprobanteEnviadoCajero, Nothing, lblTipoComprobanteEnviadoCajero.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CAJEROIGNORARTIPOCOMPROBANTECLIENTE, chbCajeroIgnorarTipoComprobanteCliente, Nothing, chbCajeroIgnorarTipoComprobanteCliente.Text)

   End Sub

   Private Sub cmbCajeroGenera_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCajeroGenera.SelectedValueChanged
      FindForm().TryCatched(Sub() chbCajeroSeleccionMultiple.Enabled = cmbCajeroGenera.SelectedValue.Equals(Entidades.VentaCajero.CajeroGenera.Recibos.ToString()))
   End Sub

End Class