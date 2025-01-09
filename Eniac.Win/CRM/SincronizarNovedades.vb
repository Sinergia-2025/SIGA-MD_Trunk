#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class SincronizarNovedades

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         txtURLServicio.Text = Reglas.Publicos.SimovilSoporteURLBase
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
      Try
         InicializaBackgroundWorker({btnSincronizar})
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub HabilitarControlers(habilitar As Boolean)
      For Each ctrl As Object In _controlesDesactivar
         If TypeOf (ctrl) Is Control Then
            DirectCast(ctrl, Control).Enabled = habilitar
         ElseIf TypeOf (ctrl) Is ToolStripItem Then
            DirectCast(ctrl, ToolStripItem).Enabled = habilitar
         End If
      Next
   End Sub

#Region "BackgroudWorker"
   Private _controlesDesactivar As Object()
   Public Sub InicializaBackgroundWorker(controlesDesactivar As Object())
      _controlesDesactivar = controlesDesactivar
      HabilitarControlers(False)
      If bkgSincronizar IsNot Nothing Then
         bkgSincronizar.RunWorkerAsync()
      Else
         bkgSincronizar_RunWorkerCompleted(Nothing, Nothing)
      End If
   End Sub

   Private Sub bkgSincronizar_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bkgSincronizar.DoWork
      Try
         Dim rSincronizarTickets As New Reglas.ServiciosRest.Soporte.SincronizarTickets()
         AddHandler rSincronizarTickets.Avance, Sub(sender1 As Object, e1 As Reglas.ServiciosRest.SincronizacionEventArgs)
                                                   bkgSincronizar.ReportProgress(0, e1.Mensaje)
                                                End Sub
         rSincronizarTickets.ImportarAutomaticamente()

      Catch ex As Exception
         bkgSincronizar.ReportProgress(0, ex)
         bkgSincronizar.CancelAsync()
      End Try
   End Sub

   Private Sub bkgSincronizar_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bkgSincronizar.ProgressChanged
      If TypeOf (e.UserState) Is Exception Then
         Me.ShowError(DirectCast(e.UserState, Exception))
      ElseIf TypeOf (e.UserState) Is String Then
         tssInfo.Text = e.UserState.ToString()
      End If

   End Sub

   Private Sub bkgSincronizar_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bkgSincronizar.RunWorkerCompleted
      tssInfo.Text = "Actualizando grillas"
      'CargarGrillaDetalle()

      HabilitarControlers(True)
      tssInfo.Text = String.Empty

   End Sub
#End Region

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         bkgSincronizar.CancelAsync()
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class