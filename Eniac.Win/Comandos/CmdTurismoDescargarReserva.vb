Option Strict On
Option Explicit On
Public Class CmdTurismoDescargarReserva
   Implements Eniac.Win.IComandoMenu

   Private Const Tag As String = "CmdTurismoDescargarReserva.Ejecutar"

   Private WithEvents sincronizacion As Reglas.ServiciosRest.Turismo.SolicitudesReserva

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      Dim simovilURLBase As String = Reglas.Publicos.SimovilTurismoURLBase
      If String.IsNullOrWhiteSpace(simovilURLBase) Then
         My.Application.Log.WriteEntry(String.Format("{0} - No está configurado la URL Base para Simovil Turismo.", Tag), TraceEventType.Error)
         Exit Sub
      End If
      Dim BaseUri As Uri = New Uri(simovilURLBase)

      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Instancia regla de SincronizacionSubidaMovil", Tag), TraceEventType.Verbose)
      sincronizacion = New Reglas.ServiciosRest.Turismo.SolicitudesReserva(BaseUri)

      sincronizacion.ImportarAutomaticamente()

      My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)

   End Sub

   Public Sub sincronizacion_Avance(sender As Object, e As Reglas.ServiciosRest.Turismo.SolicitudesReserva.AvanceImportarAutomaticamenteEventArgs) Handles sincronizacion.AvanceImportarAutomaticamente
      MuestraAvance(e)
   End Sub


   Private Sub MuestraAvance(avance As Reglas.ServiciosRest.Turismo.SolicitudesReserva.AvanceImportarAutomaticamenteEventArgs)
      If avance IsNot Nothing Then
         My.Application.Log.WriteEntry(String.Format("{0} - {1}", Tag, avance.Etapa), TraceEventType.Verbose)
      End If
   End Sub

End Class