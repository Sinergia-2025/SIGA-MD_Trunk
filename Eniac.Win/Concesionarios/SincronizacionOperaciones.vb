
Public Class SincronizacionOperaciones

#Region "Properties"
   Private _resumenDataSource As List(Of Resumen)
   Private _detallesErrorDataSource As List(Of DetalleErrores)
   Private _controles As Object()
#End Region

#Region "Overrides"
   Public Sub New()
      InitializeComponent()

      _resumenDataSource = New List(Of Resumen)()
      ugResumen.DataSource = _resumenDataSource
      _detallesErrorDataSource = New List(Of DetalleErrores)()
      ugDetallesError.DataSource = _detallesErrorDataSource

      _controles = {btnSincronizar, tsbRefrescar}
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() RefrescarDatos())
   End Sub
#End Region

#Region "Eventos"
   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
      TryCatched(Sub() InicializaBackgroundWorker())
   End Sub
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
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

      Try
         '-- Define la URL de Conexion Web.- --
         bwSincronizacion.ReportProgress(0, Reglas.Publicos.Concesionarios.SincronizacionMovil.URLConcesionarios)

         Dim movilConcesion = New Reglas.ServiciosRest.Concesionarios.SincronizacionMovil()
         '# Estos handlers son los encargados de escuchar los eventos de la regla.
         '# Cuando se disparen dichos eventos en la regla, estos van a disparar el evento ProgressChanged del BW.
         AddHandler movilConcesion.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
         AddHandler movilConcesion.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
         AddHandler movilConcesion.ProcesoFinalizado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
         AddHandler movilConcesion.InformarError, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)

         movilConcesion.SubirInformacion(False, False, False)

      Catch ex As Exception
         bwSincronizacion.ReportProgress(0, ex)
         bwSincronizacion.CancelAsync()
      End Try
   End Sub

   Private Sub bwSincronizacion_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSincronizacion.RunWorkerCompleted
      HabilitarControlers(True)
   End Sub

   Private Sub bwSincronizacion_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwSincronizacion.ProgressChanged
      If TypeOf (e.UserState) Is Reglas.ServiciosRest.Concesionarios.SincronizacionMovilEventArgs Then
         MostrarAvance(DirectCast(e.UserState, Reglas.ServiciosRest.Concesionarios.SincronizacionMovilEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.Concesionarios.SincronizacionMovilEstadoEventArgs Then
         MostrarEstado(DirectCast(e.UserState, Reglas.ServiciosRest.Concesionarios.SincronizacionMovilEstadoEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.Concesionarios.SincronizacionMovilProcesoFinalizadoEventArgs Then
         ProcesoFinalizado(DirectCast(e.UserState, Reglas.ServiciosRest.Concesionarios.SincronizacionMovilProcesoFinalizadoEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.Concesionarios.SincronizacionMovilErrorEventArgs Then
         MostrarError(DirectCast(e.UserState, Reglas.ServiciosRest.Concesionarios.SincronizacionMovilErrorEventArgs))

      ElseIf TypeOf (e.UserState) Is Exception Then
         tssInfo.Text = String.Empty
         ShowError(DirectCast(e.UserState, Exception))
      End If
   End Sub
#End Region



#Region "Métodos"
   Private Sub RefrescarDatos()
      tssInfo.Text = String.Empty
      _resumenDataSource.Clear()
      _detallesErrorDataSource.Clear()
      ugResumen.Rows.Refresh(RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(RefreshRow.RefreshDisplay)
      ugResumen.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub

   Private Sub HabilitarControlers(habilitar As Boolean)
      For Each ctrl As Object In _controles
         If TypeOf (ctrl) Is Control Then
            DirectCast(ctrl, Control).Enabled = habilitar
         ElseIf TypeOf (ctrl) Is ToolStripItem Then
            DirectCast(ctrl, ToolStripItem).Enabled = habilitar
         End If
      Next
   End Sub

   Public Sub InicializaBackgroundWorker()
      HabilitarControlers(False)
      _resumenDataSource.Clear()
      ugResumen.Rows.Refresh(RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(RefreshRow.RefreshDisplay)
      ugResumen.Rows.Refresh(RefreshRow.FireInitializeRow)
      If bwSincronizacion IsNot Nothing Then
         bwSincronizacion.RunWorkerAsync()
      Else
         bwSincronizacion_RunWorkerCompleted(Nothing, Nothing)
      End If
   End Sub

   Private Sub ProcesoFinalizado(avance As Reglas.ServiciosRest.Concesionarios.SincronizacionMovilProcesoFinalizadoEventArgs)
      Dim msg = New StringBuilder()
      With msg
         .AppendFormatLine("{0}", avance.Mensaje)
         .AppendFormatLine("End Point Actualizados: {0}", avance.Nuevos)
         .AppendFormatLine("End Point con Errores: {0}", avance.Actualizados)
      End With

      ShowMessage(msg.ToString())
   End Sub
   Private Sub MostrarError(estado As Reglas.ServiciosRest.Concesionarios.SincronizacionMovilErrorEventArgs)
      Dim Resumen = New DetalleErrores() With
                     {
                        .Mensaje = estado.Mensaje,
                        .ElementoTransmitido = estado.ElementoTransmitido
                     }
      _detallesErrorDataSource.Add(Resumen)

      ugDetallesError.Rows.Refresh(RefreshRow.ReloadData)
      ugDetallesError.Rows.Refresh(RefreshRow.RefreshDisplay)
      ugDetallesError.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub
   Private Sub MostrarEstado(estado As Reglas.ServiciosRest.Concesionarios.SincronizacionMovilEstadoEventArgs)
      Dim resumen = _resumenDataSource.FirstOrDefault(Function(x) x.Nombre = estado.Nombre And x.Concesionario = estado.Concesionario)
      If resumen Is Nothing Then
         resumen = New Resumen() With
                     {
                        .Nombre = estado.Nombre,
                        .Estado = estado.Estado.ToString(),
                        .NroRegistro = estado.TotalRegistrosSubidos,
                        .TotalRegistros = estado.TotalRegistros,
                        .TotalRegistrosExitosos = estado.TotalRegistrosExitosos,
                        .TotalRegistrosError = estado.TotalRegistrosError,
                        .Metodo = estado.Metodo.ToString()
                     }
         _resumenDataSource.Add(resumen)
      Else
         resumen.Nombre = estado.Nombre
         resumen.Estado = estado.Estado.ToString()
         resumen.NroRegistro = estado.TotalRegistrosSubidos
         resumen.TotalRegistros = estado.TotalRegistros
         resumen.TotalRegistrosExitosos = estado.TotalRegistrosExitosos
         resumen.TotalRegistrosError = estado.TotalRegistrosError
         resumen.Metodo = estado.Metodo.ToString()
      End If
      ugResumen.Rows.Refresh(RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(RefreshRow.RefreshDisplay)
      ugResumen.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub
   Private Sub MostrarAvance(avance As Reglas.ServiciosRest.Concesionarios.SincronizacionMovilEventArgs)
      tssInfo.Text = avance.Mensaje
   End Sub

#End Region

#Region "Clases"
   Public Class Resumen
      Public Property Concesionario As Entidades.ConcesionarioMovil
      Public Property Estado As String
      Public Property Metodo As String
      Public Property Nombre As String
      Public Property NroRegistro As Long
      Public Property TotalRegistros As Long

      Public Property TotalRegistrosExitosos As Long
      Public Property TotalRegistrosError As Long
   End Class
   Public Class DetalleErrores
      Public Property ElementoTransmitido As String
      Public Property Mensaje As String
   End Class
#End Region
End Class