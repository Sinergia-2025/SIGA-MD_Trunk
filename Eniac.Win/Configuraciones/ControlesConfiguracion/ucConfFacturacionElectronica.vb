Public Class ucConfFacturacionElectronica
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboTiposImpresionesFiscales(cmbTipoImpresionFiscal)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Facturación Electrónica
      chbEnviaMailCompElectronico.Checked = Reglas.Publicos.EnviaMailComprobanteElectronico
      chbEnviaCOMailCompElectronico.Checked = Reglas.Publicos.EnviaMailCopiaOcultaComprobanteElectronico
      txtMailCOCompElectronico.Text = Reglas.Publicos.MailCopiaOcultaCompElectronico
      chbImprimirLuegoSolicitarCae.Checked = Reglas.Publicos.ImprimeLuegoDeSolictarCAE
      chbFacElecEsSincronico.Checked = Reglas.Publicos.FactElectEsSincronica
      chbSolicitarCAESeleccionarTodos.Checked = Reglas.Publicos.SolicitarCAESeleccionarTodos
      txtSolicitarCAECantidadDiasFiltroFecha.Text = Reglas.Publicos.SolicitarCAECantidadDiasFiltroFecha.ToString()

      txtUbicacionPDFsFE.Text = Reglas.Publicos.UbicacionPDFsFE
      cmbTipoImpresionFiscal.SelectedValue = Reglas.Publicos.TipoImpresionFiscal
      txtFechaVencimientoCertificadoP12.Text = Reglas.Publicos.VencimientoCertificadoFE.ToString("dd/MM/yyyy")


      txtFactElectSource.Text = Reglas.Publicos.FacturaElectronica.FactElectSource
      txtFactElectDestination.Text = Reglas.Publicos.FacturaElectronica.FactElectDestination
      cmbFactElectUniqueID.Text = Reglas.Publicos.FacturaElectronica.FactElecUniqueID.ToString()
      dtpFactElectGenerationTime.Value = Reglas.Publicos.FacturaElectronica.FactElectGenerationTime
      dtpFactElectExpirationTime.Value = Reglas.Publicos.FacturaElectronica.FactElectExpirationTime
      cmbFactElectService.Text = Reglas.Publicos.FacturaElectronica.FactElecService

      txtAFIPURLControlarComprobante.Text = Reglas.Publicos.AFIPURLControlarComprobante

      chbGuardarLog.Checked = Reglas.Publicos.FacturaElectronica.FactElecGuardarLog
      txtGuardarLog.Text = Reglas.Publicos.FacturaElectronica.FactElecGuardarLogPath

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Facturación Electrónica
      ActualizarParametro(Entidades.Parametro.Parametros.ENVIAMAILCLIENTECOMPELECTRONICO, chbEnviaMailCompElectronico, Nothing, chbEnviaMailCompElectronico.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ENVIACOMAILCOMPELECTRONICO, chbEnviaCOMailCompElectronico, Nothing, chbEnviaCOMailCompElectronico.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILCOPIAOCULTACOMPELECTRONICO, txtMailCOCompElectronico, Nothing, chbEnviaCOMailCompElectronico.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IMPRIMIRLUEGODESOLICITARCAE, chbImprimirLuegoSolicitarCae, Nothing, chbImprimirLuegoSolicitarCae.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTELECTSINCRONICA, chbFacElecEsSincronico, Nothing, chbFacElecEsSincronico.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SOLICITARCAESELECCIONARTODOS, chbSolicitarCAESeleccionarTodos, Nothing, chbSolicitarCAESeleccionarTodos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SOLICITARCAECANTIDADDIASFILTROFECHA, txtSolicitarCAECantidadDiasFiltroFecha, Nothing, lblSolicitarCAECantidadDiasFiltroFecha.Text)

      If Not IO.Directory.Exists(txtUbicacionPDFsFE.Text) Then IO.Directory.CreateDirectory(txtUbicacionPDFsFE.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.UBICACIONPDFSFE, txtUbicacionPDFsFE, Nothing, lblUbicacionPDFsFE.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TIPOIMPRESIONFISCAL, cmbTipoImpresionFiscal, Nothing, lblTipoImpresionFiscal.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.FACTELECTSOURCE, txtFactElectSource, Nothing, lblFactElectSource.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTELECTDESTINATION, txtFactElectDestination, Nothing, lblFactElectDestination.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.FACTELECUNIQUEID, cmbFactElectUniqueID.Text, Nothing, lblFactElectUniqueID.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTELECTGENERATIONTIME, dtpFactElectExpirationTime, Nothing, lblFactElectExpirationTime.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTELECTEXPIRATIONTIME, dtpFactElectGenerationTime, Nothing, lblFactElectGenerationTime.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.FACTELECSERVICE, cmbFactElectService.Text, Nothing, lblFactElectService.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.AFIPURLCONTROLARCOMPROBANTE, txtAFIPURLControlarComprobante, Nothing, lblAFIPURLControlarComprobante.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTELECGUARDARLOG, chbGuardarLog, Nothing, chbGuardarLog.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTELECGUARDARLOGPATH, txtGuardarLog, Nothing, String.Concat(chbGuardarLog.Text, " Path"))

   End Sub

   Private Sub btnCargarCertificado_Click(sender As Object, e As EventArgs) Handles btnCargarCertificado.Click
      Try
         Using frm As ParametrosDelUsuarioCargarNuevoCertificado = New ParametrosDelUsuarioCargarNuevoCertificado()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Reglas.ParametrosCache.Instancia().CargarTodos()
               Reglas.ParametrosCache.Editor.Instancia().Clear()

               Dim reg As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
               reg.GrabarParametroImagen(frm.Archivo.FullName, actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.CERTIFICADOFE.ToString())
               ActualizarParametroTexto(Entidades.Parametro.Parametros.VENCIMIENTOCERTIFICADOFE, frm.FechaVencimineto.ToString("dd/MM/yyyy"), "", "Fecha de vencimiento de certificado p12.")
               txtFechaVencimientoCertificadoP12.Text = frm.FechaVencimineto.ToString("dd/MM/yyyy")

               Reglas.ParametrosCache.Editor.Instancia().Commit()

               MessageBox.Show("Se cargo el certificado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End Using
      Catch ex As Exception
         FindForm().ShowError(ex)
      End Try
   End Sub

End Class