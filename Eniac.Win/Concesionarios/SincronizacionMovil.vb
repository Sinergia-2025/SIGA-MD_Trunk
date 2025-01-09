Imports Eniac.Win.SincronizacionSubidaTiendaWeb

Public Class SincronizacionMovil

#Region "Properties"
   Private _resumenDataSource As List(Of Resumen)
   Private _detallesErrorDataSource As List(Of DetalleErrores)
#End Region

   Public Sub New()

      InitializeComponent()

      _resumenDataSource = New List(Of Resumen)()
      ugResumen.DataSource = _resumenDataSource
      _detallesErrorDataSource = New List(Of DetalleErrores)()
      ugDetallesError.DataSource = _detallesErrorDataSource

   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() RefrescarDatos())
   End Sub
#End Region

#Region "Eventos"
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
      TryCatched(Sub() InicializaBackgroundWorker())
   End Sub
#End Region

#Region "Eventos Background Worker"
   Private Sub bwSincronizacion_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwSincronizacion.DoWork
      Try
         Reglas.Publicos.VerificaConfiguracionRegional()
      Catch ex As Exception
         bwSincronizacion.ReportProgress(0, ex)
         bwSincronizacion.CancelAsync()
      End Try

      bwSincronizacion.ReportProgress(0, Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeURLBase)

   End Sub
   Private Sub bwSincronizacion_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSincronizacion.RunWorkerCompleted
      HabilitarControlers(True)
   End Sub

   Private Sub bwSincronizacion_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwSincronizacion.ProgressChanged
      '# Recibiendo la información disparada por el primer evento dentro de la regla en "e", puedo realizar actualizaciones en la pantalla
      If TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEventArgs Then
         'MostrarAvance(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEstadoEventArgs Then
         'MostrarEstado(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEstadoEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebProcesoFinalizadoEventArgs Then
         'ProcesoFinalizado(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebProcesoFinalizadoEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebErrorEventArgs Then
         'MostrarError(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebErrorEventArgs))

      ElseIf TypeOf (e.UserState) Is Exception Then
         tssInfo.Text = String.Empty
         ShowError(DirectCast(e.UserState, Exception))
      End If
   End Sub
#End Region

#Region "Métodos"
   Private Sub RefrescarDatos()

   End Sub
   Private Sub HabilitarControlers(habilitar As Boolean)

   End Sub
   Public Sub InicializaBackgroundWorker()

   End Sub
#End Region
End Class