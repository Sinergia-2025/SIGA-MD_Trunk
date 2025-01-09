Public Class CmdBajadaTiendaNube
   Implements Eniac.Win.IComandoMenu

   Private Const Tag As String = "CmdBajadaTiendaNube.Ejecutar"

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      Dim importacionPedidos = New Reglas.ServiciosRest.TiendasWeb.ImportacionPedidosTiendasWeb()

      If Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeToken) Then
         Dim tiendaNube = New Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaNube()
         '# Seteando configuración regional
         My.Application.Log.WriteEntry(String.Format("{0} - Aplicando Configuración Regional.", Tag), TraceEventType.Information)
         Reglas.Publicos.VerificaConfiguracionRegional()

         '# Bajada de Información
         My.Application.Log.WriteEntry(String.Format("{0} - Comenzando Bajada de Información desde Tarea Programada.", Tag), TraceEventType.Information)
         tiendaNube.BajarInformacion(bajarTodo:=False)

         '# Importación de los Pedidos
         My.Application.Log.WriteEntry(String.Format("{0} - Comenzando Importación de Pedidos desde Tarea Programada.", Tag), TraceEventType.Information)
         importacionPedidos.Importar(Entidades.TiendasWeb.TIENDANUBE)

         '# Reporte de Errores en caso que existan (actuales o previos)
         My.Application.Log.WriteEntry(String.Format("{0} - Consultando Reporte de Errores.", Tag), TraceEventType.Information)
         Me.ReporteDeErrores(tiendaNube.ReporteDeErrores())
      End If

      '-- Mercado Libre.- -REQ-30522.- --
      If Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreToken) Then
         Dim mercadolibre = New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()

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

         '# Seteando configuración regional
         My.Application.Log.WriteEntry(String.Format("{0} - Aplicando Configuración Regional.", Tag), TraceEventType.Information)
         Reglas.Publicos.VerificaConfiguracionRegional()

         '# Bajada de Información
         My.Application.Log.WriteEntry(String.Format("{0} - Comenzando Bajada de Información desde Tarea Programada.", Tag), TraceEventType.Information)
         mercadolibre.BajarInformacion(bajarTodo:=False)

         '# Importación de los Pedidos
         My.Application.Log.WriteEntry(String.Format("{0} - Comenzando Importación de Pedidos desde Tarea Programada.", Tag), TraceEventType.Information)
         importacionPedidos.Importar(Entidades.TiendasWeb.MERCADOLIBRE)

         '# Reporte de Errores en caso que existan (actuales o previos)
         My.Application.Log.WriteEntry(String.Format("{0} - Consultando Reporte de Errores.", Tag), TraceEventType.Information)
         Me.ReporteDeErrores(mercadolibre.ReporteDeErrores())
      End If

      My.Application.Log.WriteEntry(String.Format("{0} - Fin", Tag), TraceEventType.Information)
   End Sub


   Private Sub ReporteDeErrores(cuerpo As String)
      If String.IsNullOrEmpty(cuerpo) Then Exit Sub

      Dim ms As MailSSS = New MailSSS
      If Not String.IsNullOrEmpty(cuerpo) AndAlso String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCorreoNotificaciones) Then
         My.Application.Log.WriteEntry(String.Format("{0} - Se encontraron errores pero no existe un Correo de Notificación configurado."), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0} - ERROR/ES: {0}.", cuerpo), TraceEventType.Information)

         Exit Sub
      End If

      Dim destinatarios As String() = {Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCorreoNotificaciones}
      Dim asunto As String = String.Format("Reporte de Errores Encontrados - Sincronización Tienda Nube {0}", Now)

      ms.CrearMail(destinatarios, asunto, cuerpo, Nothing, {Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta})
      ms.EnviarMail()
   End Sub

End Class
