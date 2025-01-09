Public Class CmdSubidaMercadoLibre
   Implements Eniac.Win.IComandoMenu

   Private Const Tag As String = "CmdSubidaMercadoLibre.Ejecutar"

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Aplicando Configuración Regional.", Tag), TraceEventType.Information)
      Reglas.Publicos.VerificaConfiguracionRegional()

      '# Comenzando la Subida de Información
      My.Application.Log.WriteEntry(String.Format("{0} - Comenzando Subida de Información desde Tarea Programada.", Tag), TraceEventType.Information)
      Dim mercadolibre = New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()
      Try
         '-- Recupero Fecha de Token.- --
         If CDate(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreFechaRefreshTokenML) < DateTime.Now() Then
            '-- Asigna Fecha del Dia.- --
            Dim FechaToken = DateTime.Now()
            '-- Sincronizacion .- 
            Dim sincML As New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()
            '-- Ejecuto autorizacion sobre Mercado Libre - Obtengo Valor Token.- --
            Dim token = sincML.GetRefreshToken(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoAppIdML,
                                                  Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoSecretML,
                                                  Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoRefreshTokenML)
            '-- Actualiza Fecha de Expiracion.- --
            FechaToken = FechaToken.AddSeconds(token.expires_in)
            '-- Proceso de Gabado de Datos al sistema.- --
            sincML.GuardarToken(token.access_token, FechaToken.ToString(), token.refresh_token, token.user_id)
         End If
         Dim PublicarPrecioPorEmbalaje As Boolean = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePrecioPorEmbalaje

         '-- Proceso de Subida de Datos.
         mercadolibre.SubirInformacion(reenviarTodo:=False, True, PublicarPrecioPorEmbalaje)

         '# Reporte de Errores en caso que existan (actuales o previos)
         My.Application.Log.WriteEntry(String.Format("{0} - Consultando Reporte de Errores.", Tag), TraceEventType.Information)
         Me.ReporteDeErrores(mercadolibre.ReporteDeErrores())
      Catch ex As Exception
         Dim err As StringBuilder = New StringBuilder
         With err
            .AppendFormatLine("*** Se encontraron los siguientes ERRORES en el Proceso de Subida de Tienda Nube ***")
            .AppendFormatLine("<br>")
            .AppendFormatLine("{0}", ex.Message)
         End With
         ReporteDeErrores(err.ToString())
      End Try

      My.Application.Log.WriteEntry(String.Format("{0} - Fin", Tag), TraceEventType.Information)

   End Sub

   Private Sub ReporteDeErrores(cuerpo As String)
      Dim ms = New MailSSS
      If Not String.IsNullOrEmpty(cuerpo) AndAlso String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCorreoNotificaciones) Then
         My.Application.Log.WriteEntry(String.Format("{0} - Se encontraron errores pero no existe un Correo de Notificación configurado."), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0} - ERROR/ES: {0}.", cuerpo), TraceEventType.Information)

         Exit Sub
      End If

      Dim destinatarios As String() = {Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCorreoNotificaciones}
      Dim asunto As String = String.Format("Reporte de Errores Encontrados - Sincronización Tienda Nube {0}", Now)

      ms.CrearMail(destinatarios, asunto, cuerpo, Nothing, {Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta})
      ms.EnviarMail()
   End Sub
End Class
