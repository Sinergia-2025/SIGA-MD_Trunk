Public Class CmdSubidaArborea
   Implements Eniac.Win.IComandoMenu

   Private Const Tag As String = "CmdSubidaArborea.Ejecutar"

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Aplicando Configuración Regional.", Tag), TraceEventType.Information)
      Reglas.Publicos.VerificaConfiguracionRegional()

      '# Comenzando la Subida de Información
      My.Application.Log.WriteEntry(String.Format("{0} - Comenzando Subida de Información desde Tarea Programada.", Tag), TraceEventType.Information)
      Dim Arborea = New Reglas.ServiciosRest.TiendasWeb.SincronizacionArborea()
      Try
         Dim PublicarPrecioPorEmbalaje As Boolean = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPrecioPorEmbalaje

         '-- Proceso de Subida de Datos.
         Arborea.SincronizacionSubida(reenviarTodo:=False,
                                      sincronizaClientes:=True,
                                      sincronizaCategorias:=True,
                                      sincronizaProductos:=True,
                                      sincronizaPrecios:=True,
                                      PublicarPrecioPorEmbalaje)

         '# Reporte de Errores en caso que existan (actuales o previos)
         My.Application.Log.WriteEntry(String.Format("{0} - Consultando Reporte de Errores.", Tag), TraceEventType.Information)
         Me.ReporteDeErrores(Arborea.ReporteDeErrores())
      Catch ex As Exception
         Dim err As StringBuilder = New StringBuilder
         With err
            .AppendFormatLine("*** Se encontraron los siguientes ERRORES en el Proceso de Subida de Arborea ***")
            .AppendFormatLine("<br>")
            .AppendFormatLine("{0}", ex.Message)
         End With
         ReporteDeErrores(err.ToString())
      End Try
      My.Application.Log.WriteEntry(String.Format("{0} - Fin", Tag), TraceEventType.Information)
   End Sub

   Private Sub ReporteDeErrores(cuerpo As String)
      Dim ms = New MailSSS
      If Not String.IsNullOrEmpty(cuerpo) AndAlso String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.Arborea.ArboreaCorreoNotificaciones) Then
         My.Application.Log.WriteEntry(String.Format("{0} - Se encontraron errores pero no existe un Correo de Notificación configurado."), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0} - ERROR/ES: {0}.", cuerpo), TraceEventType.Information)
         Exit Sub
      End If

      Dim destinatarios As String() = {Reglas.Publicos.TiendasWeb.Arborea.ArboreaCorreoNotificaciones}
      Dim asunto As String = String.Format("Reporte de Errores Encontrados - Sincronización Arborea {0}", Now)

      ms.CrearMail(destinatarios, asunto, cuerpo, Nothing, {Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta})
      ms.EnviarMail()
   End Sub

End Class
