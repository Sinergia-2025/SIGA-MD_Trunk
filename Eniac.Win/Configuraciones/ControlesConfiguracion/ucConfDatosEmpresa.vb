Public Class ucConfDatosEmpresa

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbOrigenCotizacionMoneda, GetType(Reglas.ServiciosRest.CotizacionMonedas.CotizacionMonedasOrigen))
      e.Publicos.CargaComboDesdeEnum(cmbOperacionCotizacionMoneda, GetType(Reglas.ServiciosRest.CotizacionMonedas.CotizacionMonedasOperacion))

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)


      txtSueldosDomicilioEmpresa.Text = Reglas.Publicos.DireccionEmpresa
      txtDireccionWebEmpresa.Text = Reglas.Publicos.DireccionWebEmpresa
      txtDescripcionAdicional.Text = Reglas.Publicos.DescripcionAdicionalEmpresa
      dtpFechaInicioActividades.Value = Reglas.Publicos.FechaInicioActividades
      txtIngresosBrutos.Text = Reglas.Publicos.IngresosBrutos
      chbVisualizarComprobanteVentaAsumeImpresion.Checked = Reglas.Publicos.Facturacion.VisualizarComprobanteVentaAsumeImpresion
      chbMostrarNombreFantasiaComprobantes.Checked = Reglas.Publicos.MostrarNombreFantasiaenComprobantes
      chbConsultarMultipleSucursal.Checked = Reglas.Publicos.ConsultarMultipleSucursal
      chbConsultarMultipleSucursal.Enabled = Reglas.Publicos.PermiteConsultarMultipleSucursal



      chbRetieneGanancias.Checked = Reglas.Publicos.RetieneGanancias
      chbRetieneIIBB.Checked = Reglas.Publicos.RetieneIIBB
      txtCantidadDePadronesARBA.Text = Reglas.Publicos.CantidadPadronesARBAaGuardar.ToString()

      txtTipoDocCliente.Text = Reglas.Publicos.TipoDocumentoCliente
      txtTipoDocProveedor.Text = Reglas.Publicos.TipoDocumentoProveedor


      'Correo Electronico
      txtMailServidor.Text = Reglas.Publicos.MailServidor ' par.GetValorPD(txtMailServidor.Tag.ToString(), "")
      txtMailPuertoSalida.Text = Reglas.Publicos.MailPuertoSalida.ToString() ' par.GetValorPD(txtMailPuertoSalida.Tag.ToString(), "25")
      txtMailDireccion.Text = Reglas.Publicos.MailDireccion ' par.GetValorPD(txtMailDireccion.Tag.ToString(), "")
      txtMailUsuario.Text = Reglas.Publicos.MailUsuario ' par.GetValorPD(txtMailUsuario.Tag.ToString(), "")
      txtMailPassword.Text = Reglas.Publicos.MailPassword ' par.GetValorPD(txtMailPassword.Tag.ToString(), "")
      chbMailRequiereSSL.Checked = Reglas.Publicos.MailRequiereSSL ' par.GetValorPD(chbMailRequiereSSL.Tag.ToString(), "False")
      chbMailRequiereAutenticacion.Checked = Reglas.Publicos.MailRequiereAutenticacion ' par.GetValorPD(chbMailRequiereAutenticacion.Tag.ToString(), "False")
      chbCopiaASiMismo.Checked = Reglas.Publicos.MailCopiaASiMismo
      txtCantidadMailsPorMinuto.Text = Reglas.Publicos.MailCantidadMailsPorMinuto.ToString() ' par.GetValorPD(txtCantidadMailsPorMinuto.Tag.ToString(), CStr(12))
      txtCantidadMailsPorHora.Text = Reglas.Publicos.MailCantidadMailsPorHora.ToString() ' par.GetValorPD(txtCantidadMailsPorHora.Tag.ToString(), CStr(120))

      cmbOrigenCotizacionMoneda.SelectedValue = Reglas.Publicos.OrigenCotizacionMoneda
      cmbOperacionCotizacionMoneda.SelectedValue = Reglas.Publicos.OperacionCotizacionMonedas



      'LOGO EMPRESA
      Dim parimg As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
      Dim parimagen As Entidades.ParametroImagen = New Entidades.ParametroImagen()
      pcbFoto.Image = Publicos.Logo(sucursal:=Nothing) ' parimg.GetValor("LOGOEMPRESA")
      If pcbFoto.Image IsNot Nothing Then
         Using ms = New IO.MemoryStream()
            pcbFoto.Image.Save(ms, Imaging.ImageFormat.Jpeg)
            MostrarTamano(ms.Length)
         End Using
      Else
         MostrarTamano(0)
      End If
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Datos Generales de la empresa

      ActualizarParametro(Entidades.Parametro.Parametros.SUELDOS_DOMICILIO_EMPRESA, txtSueldosDomicilioEmpresa, "SUELDOS", lblSueldosDomicilioEmpresa.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.DIRECCIONWEBEMPRESA, txtDireccionWebEmpresa, Nothing, lblSueldosDomicilioEmpresa.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.DESCRIPCIONADICIONALEMPRESA, txtDescripcionAdicional, Nothing, lblDescripcionAdicional.Text)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.FECHAINICIOACTIVIDADES, dtpFechaInicioActividades.Value.ToString("dd/MM/yyyy"), Nothing, lblFechaInicioActividades.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.INGRESOSBRUTOS, txtIngresosBrutos, Nothing, lblIngresosBrutos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASVISUALIZARCOMPROBANTEASUMEIMPRESION, chbVisualizarComprobanteVentaAsumeImpresion, Nothing, chbVisualizarComprobanteVentaAsumeImpresion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MOSTRARNOMBREFANTASIAENCOMPROBANTES, chbMostrarNombreFantasiaComprobantes, Nothing, chbMostrarNombreFantasiaComprobantes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CONSULTARMULTIPLESUCURSAL, chbConsultarMultipleSucursal, Nothing, chbConsultarMultipleSucursal.Text)



      ActualizarParametro(Entidades.Parametro.Parametros.RETIENEGANANCIAS, chbRetieneGanancias, Nothing, chbRetieneGanancias.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RETIENEIIBB, chbRetieneIIBB, Nothing, chbRetieneIIBB.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CANTIDADPADRONESARBA, txtCantidadDePadronesARBA, Nothing, lblCantidadDePadronesARBA.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.TIPODOCUMENTOCLIENTE, txtTipoDocCliente, Nothing, lblTipoDocumentoCliente.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TIPODOCUMENTOPROVEEDOR, txtTipoDocProveedor, Nothing, lblTipoDocumentoProveedor.Text)

      'Correo Electronico
      ActualizarParametro(Entidades.Parametro.Parametros.MAILSERVIDOR, txtMailServidor, Nothing, lblMailServidor.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILPUERTOSALIDA, txtMailPuertoSalida, Nothing, "Puerto de Salida")
      ActualizarParametro(Entidades.Parametro.Parametros.MAILDIRECCION, txtMailDireccion, Nothing, lblMailDireccion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILUSUARIO, txtMailUsuario, Nothing, lblMailUsuario.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILPASSWORD, txtMailPassword, Nothing, lblMailPassword.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILREQUIERESSL, chbMailRequiereSSL, Nothing, chbMailRequiereSSL.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILREQUIEREAUTENTICACION, chbMailRequiereAutenticacion, Nothing, chbMailRequiereAutenticacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILCOPIAASIMISMO, chbCopiaASiMismo, Nothing, chbCopiaASiMismo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CANTEMAILSPORMINUTO, txtCantidadMailsPorMinuto, Nothing, "Cantidad de correos máxima a enviar por minuto.")
      ActualizarParametro(Entidades.Parametro.Parametros.CANTEMAILSPORHORA, txtCantidadMailsPorHora, Nothing, "Cantidad de correos máxima a enviar por hora.")
      '-----------------------


      Dim logo = New Reglas.ParametrosImagenes()
      Dim logoemp = New Entidades.ParametroImagen()
      logoemp.IdParametroImagenes = "LOGOEMPRESA" 'pcbFoto.Image.Tag.ToString()
      logoemp.IdEmpresa = actual.Sucursal.IdEmpresa
      logoemp.ValorParametroImagenes = pcbFoto.Image
      logo.Insertar(logoemp)

      ActualizarParametro(Of Reglas.ServiciosRest.CotizacionMonedas.CotizacionMonedasOrigen)(Entidades.Parametro.Parametros.ORIGENCOTIZACIONMONEDA, cmbOrigenCotizacionMoneda, Nothing, lblOrigenCotizacionMoneda.Text)
      ActualizarParametro(Of Reglas.ServiciosRest.CotizacionMonedas.CotizacionMonedasOperacion)(Entidades.Parametro.Parametros.OPERACIONCOTIZACIONMONEDAS, cmbOperacionCotizacionMoneda, Nothing, lblOrigenCotizacionMoneda.Text + " - Operación")


   End Sub


   Private Sub MostrarTamano(tamano As Decimal)
      lblTamano.Text = String.Format("{0} {1}", "Tamaño Bytes Image : ", Publicos.GetTamanioArchivoFormateado(tamano))
   End Sub




   Private Sub btnLimpiarImagen_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen.Click
      FindForm().TryCatched(Sub() pcbFoto.Image = Nothing)
   End Sub

   Private Sub btnBuscarImagen_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen.Click
      FindForm().TryCatched(
         Sub()
            If ofdArchivos.ShowDialog() = DialogResult.OK Then
               Dim nombrearchivo As String = ofdArchivos.FileName
               If Not String.IsNullOrEmpty(nombrearchivo) Then
                  Dim fileInfo = New IO.FileInfo(nombrearchivo)
                  If fileInfo.Length > Reglas.Publicos.TamañoMaximoImagenes Then
                     FindForm().ShowMessage(String.Format("El archivo seleccionado tiene un tamaño ({0}) que excede el tamaño máximo permitido ({1}).",
                                                          Publicos.GetTamanioArchivoFormateado(fileInfo.Length),
                                                          Publicos.GetTamanioArchivoFormateado(Reglas.Publicos.TamañoMaximoImagenes)))
                  Else
                     pcbFoto.Image = New Bitmap(nombrearchivo)
                     MostrarTamano(fileInfo.Length)
                  End If
               End If
            End If
         End Sub)
   End Sub

   Private Sub btnProbanrEnvioMail_Click(sender As Object, e As EventArgs) Handles btnProbanrEnvioMail.Click
      FindForm().TryCatched(
         Sub()
            GrabarCorreo()

            If actual.MailConfig.UtilizaComoPredeterminado Then
               MessageBox.Show("No puede probar la configuración ya que tiene seteado como predeterminado un mail en su perfil.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            If ValidarCorreo() Then
               Dim ms = New MailSSS()
               ms.CrearMail("TO", {txtMailDireccion.Text}, "Prueba de envio de mail", "Prueba de envio de mail", Nothing, Nothing)
               ms.EnviarMail()
               MessageBox.Show("Prueba enviada exitosamente.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               MessageBox.Show("Los datos del correo electrónico estan incompletos", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
         End Sub)
   End Sub


   Private Sub GrabarCorreo()
      ActualizarParametro(Entidades.Parametro.Parametros.MAILSERVIDOR, txtMailServidor, Nothing, lblMailServidor.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILPUERTOSALIDA, txtMailPuertoSalida, Nothing, "Puerto de Salida")
      ActualizarParametro(Entidades.Parametro.Parametros.MAILDIRECCION, txtMailDireccion, Nothing, lblMailDireccion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILUSUARIO, txtMailUsuario, Nothing, lblMailUsuario.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILPASSWORD, txtMailPassword, Nothing, lblMailPassword.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILREQUIERESSL, chbMailRequiereSSL, Nothing, chbMailRequiereSSL.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MAILREQUIEREAUTENTICACION, chbMailRequiereAutenticacion, Nothing, chbMailRequiereAutenticacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CANTEMAILSPORMINUTO, txtCantidadMailsPorMinuto, Nothing, "Cantidad de correos máxima a enviar por minuto.")
      ActualizarParametro(Entidades.Parametro.Parametros.CANTEMAILSPORHORA, txtCantidadMailsPorHora, Nothing, "Cantidad de correos máxima a enviar por hora.")

      Reglas.ParametrosCache.Editor.Instancia().Commit()

   End Sub

   Private Function ValidarCorreo() As Boolean
      Dim validaDatos As Boolean = True

      If (Reglas.Publicos.MailServidor = "" Or Reglas.Publicos.MailDireccion = "" Or Reglas.Publicos.MailUsuario = "" Or Reglas.Publicos.MailPassword = "" Or Reglas.Publicos.MailPuertoSalida = 0) Then
         validaDatos = False
      End If

      Return validaDatos
   End Function

End Class