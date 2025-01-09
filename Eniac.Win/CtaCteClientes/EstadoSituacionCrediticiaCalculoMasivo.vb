Public Class EstadoSituacionCrediticiaCalculoMasivo
#Region "Properties"
   Private _resumenDataSource As List(Of Resumen)
   Private _detallesErrorDataSource As List(Of DetalleErrores)
   Private _controles As Object()
#End Region
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _resumenDataSource = New List(Of Resumen)()
      _detallesErrorDataSource = New List(Of DetalleErrores)()

      '# Controles en pantalla
      _controles = {pnlAcciones, tsbRefrescar}
   End Sub


#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(
      Sub()
         Dim titResumen = GetColumnasVisiblesGrilla(ugResumen)
         ugResumen.DataSource = _resumenDataSource
         AjustarColumnasGrilla(ugResumen, titResumen)

         tbcLog.SelectedTab = tbpErrores
         Dim titErrores = GetColumnasVisiblesGrilla(ugDetallesError)
         ugDetallesError.DataSource = _detallesErrorDataSource
         AjustarColumnasGrilla(ugDetallesError, titErrores)

         tbcLog.SelectedTab = tbpResumen
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnCalcular.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
      TryCatched(Sub() InicializaBackgroundWorker())
   End Sub
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub ugResumen_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugResumen.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Resumen)()
         If dr IsNot Nothing Then
            If dr.Etapa = Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PreCalculo Then
               e.Row.Cells("EtapaResult").Color(Color.Black, Color.LightYellow)
            ElseIf dr.Etapa = Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PostCalculo Then
               e.Row.Cells("EtapaResult").Color(Color.Black, Color.Yellow)
            ElseIf dr.Etapa = Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PreActualizacion Then
               e.Row.Cells("EtapaResult").Color(Color.Black, Color.YellowGreen)
            ElseIf dr.Etapa = Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PostActualizacion Then
               e.Row.Cells("EtapaResult").Color(Color.Black, Color.Green)
            End If
         End If
      End Sub)
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
         '-- Define Tipo de Proceso.- --
         Dim rCtaCte = New Reglas.CuentasCorrientes()
         Dim r = rCtaCte.CalculoSituacionCrediticiaMasivo(avance:=Function(e1)
                                                                     bwSincronizacion.ReportProgress(0, e1)
                                                                     Return e1
                                                                  End Function,
                                                          [error]:=Function(e1)
                                                                      bwSincronizacion.ReportProgress(0, e1)
                                                                      Return e1
                                                                   End Function,
                                                          continuarConError:=True)

         e.Result = r

      Catch ex As Exception
         bwSincronizacion.ReportProgress(0, ex)
         bwSincronizacion.CancelAsync()
      End Try
   End Sub

   Private Sub bwSincronizacion_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSincronizacion.RunWorkerCompleted
      If e IsNot Nothing AndAlso e.Result IsNot Nothing AndAlso TypeOf e.Result Is Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoResult Then
         Dim r = DirectCast(e.Result, Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoResult)
         Dim stb = New StringBuilder()
         stb.AppendFormatLine("{0} Finalizado", Text).AppendLine()
         If _detallesErrorDataSource.AnySecure() Then
            stb.AppendFormatLine("Se reportaron {0} ERRORES", _detallesErrorDataSource.CountSecure()).AppendLine()
         Else
            stb.AppendFormatLine("Se actualizaron {0} clientes exitosamente.", r.Avances.CountSecure()).AppendLine()
         End If
         stb.AppendFormatLine("Tiempo: {0}", r.TiempoTotal.ToString())
         ShowMessage(stb.ToString())
      Else
         ShowMessage("Proceso finalizado!")
      End If
      HabilitarControlers(True)
   End Sub

   Private Sub bwSincronizacion_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwSincronizacion.ProgressChanged
      '# Recibiendo la información disparada por el primer evento dentro de la regla en "e", puedo realizar actualizaciones en la pantalla
      If TypeOf (e.UserState) Is Exception Then
         tssInfo.Text = String.Empty
         ShowError(DirectCast(e.UserState, Exception))

      ElseIf TypeOf (e.UserState) Is Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs Then
         MostrarAvance(DirectCast(e.UserState, Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoErrorEventArgs Then
         MostrarError(DirectCast(e.UserState, Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoErrorEventArgs))

      Else

      End If
   End Sub
#End Region
#Region "Métodos"
   Private Sub RefrescarDatos()
      tssInfo.Text = String.Empty

      chbSaldoLimiteCreditoContemplaPedidos.Checked = Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoContemplaPedidos
      chbSaldoLimiteCreditoContemplaAnticipos.Checked = Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoContemplaAnticipos

      ugResumen.ClearFilas()
      ugDetallesError.ClearFilas()
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
      ugResumen.ClearFilas()
      ugDetallesError.ClearFilas()

      bwSincronizacion.RunWorkerAsync(Nothing)

   End Sub

   Private Sub MostrarError(estado As Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoErrorEventArgs)
      Dim detError = New DetalleErrores(estado)
      _detallesErrorDataSource.Add(detError)
      ugDetallesError.Rows.Refresh(RefreshRow.ReloadData)
   End Sub

   Private Sub MostrarAvance(avance As Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs)
      Dim resumen = _resumenDataSource.FirstOrDefault(Function(r) r.CodigoCliente = avance.Cliente.CodigoCliente)
      If resumen Is Nothing Then
         resumen = New Resumen(avance)
         _resumenDataSource.Add(resumen)
         ugResumen.Rows.Refresh(RefreshRow.ReloadData)
      Else
         resumen.Actualiza(avance)
         ugResumen.Rows.Refresh(RefreshRow.FireInitializeRow)
      End If
      tssInfo.Text = String.Format("{0} - {1} / {2}", resumen.CodigoCliente, resumen.NombreCliente, resumen.EtapaResult)
   End Sub

#End Region



   Public Class Resumen
      Public ReadOnly Property Etapa As Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs.Etapas
      Private Property Cliente As Entidades.ClienteLiviano
      Private Property Tiempo As TimeSpan
      Public ReadOnly Property CodigoCliente As Long
         Get
            Return Cliente.CodigoCliente
         End Get
      End Property
      Public ReadOnly Property NombreCliente As String
         Get
            Return Cliente.NombreCliente
         End Get
      End Property
      Public ReadOnly Property EtapaResult As String
         Get
            Return Etapa.GetDescription()
         End Get
      End Property
      Public ReadOnly Property TiempoResult As String
         Get
            Return Tiempo.TotalSeconds.ToString("N4")
         End Get
      End Property
      Public ReadOnly Property SaldoLimiteCredigoNuevo As Decimal

      Public Sub New(e As Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs)
         Me.New(e.Etapa, e.Cliente, e.SaldoNuevo, e.Tiempo)
      End Sub
      Private Sub New(etapa As Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs.Etapas, cliente As Entidades.ClienteLiviano, saldoLimiteCredigoNuevo As Decimal, tiempo As TimeSpan)
         Me.Etapa = etapa
         Me.Cliente = cliente
         Me.SaldoLimiteCredigoNuevo = saldoLimiteCredigoNuevo
         Me.Tiempo = tiempo
      End Sub

      Public Sub Actualiza(nuevo As Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoEventArgs)
         _Etapa = nuevo.Etapa
         _Tiempo = nuevo.Tiempo
         _SaldoLimiteCredigoNuevo = nuevo.SaldoNuevo
      End Sub

   End Class
   Public Class DetalleErrores
      Inherits Resumen

      Public Sub New(e As Reglas.CuentasCorrientes.CalculoSituacionCrediticiaMasivoErrorEventArgs)
         MyBase.New(e)
         Ex = e.Ex
      End Sub

      Private Property Ex As Exception
      Public ReadOnly Property Mensaje As String
         Get
            Return Ex.Message
         End Get
      End Property

   End Class

End Class