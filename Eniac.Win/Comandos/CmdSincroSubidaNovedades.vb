Option Strict On
Option Explicit On
Public Class CmdSincroSubidaNovedades
   Implements Eniac.Win.IComandoMenu

   '# Log Tag
   Private Const Tag As String = "CmdSincroSubidaNovedades.Ejecutar"

   Private WithEvents rSincronizarTickets As Reglas.ServiciosRest.Soporte.SincronizarTickets

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar

      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Instancia regla de SincronizarTickets", Tag), TraceEventType.Verbose)
      rSincronizarTickets = New Reglas.ServiciosRest.Soporte.SincronizarTickets

      '### Subida
      My.Application.Log.WriteEntry(String.Format("{0} - Antes de subir la infomación", Tag), TraceEventType.Verbose)
      rSincronizarTickets.ImportarAutomaticamente()

      My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)

   End Sub

   Public Sub rSincronizarTickets_Avance(sender As Object, e As Reglas.ServiciosRest.SincronizacionEventArgs) Handles rSincronizarTickets.Avance
      If e IsNot Nothing Then
         My.Application.Log.WriteEntry(String.Format("{0} - {1}", Tag, e.Mensaje), TraceEventType.Verbose)
      End If
   End Sub

End Class
