#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Public Class MonitorParametros

#Region "Overrides"
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() tstCantidad.Text = Reglas.ParametrosCache.Instancia.CantidadMaximaParametrosMonitoreados.ToString())
      TryCatched(Sub() ugParametros.DataSource = Reglas.ParametrosCache.Instancia.UltimosParametrosAccedidos)
      TryCatched(Sub() tssRegistros.MostrarRegistros(Reglas.ParametrosCache.Instancia.UltimosParametrosAccedidos))

      AddHandler Reglas.ParametrosCache.Instancia.UltimosParametrosAccedidos.ListChanged, Sub(sender, e1)
                                                                                             TryCatched(Sub()
                                                                                                           If InvokeRequired Then
                                                                                                              Invoke(Sub() timerListChanged.ReStart())
                                                                                                           Else
                                                                                                              timerListChanged.ReStart()
                                                                                                           End If
                                                                                                        End Sub)
                                                                                          End Sub

      TryCatched(Sub() ugParametros.AgregarFiltroEnLinea({"Item2", "Item3"}))
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         tsbSalir.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() Reglas.ParametrosCache.Instancia.UltimosParametrosAccedidos.Clear())
   End Sub
   Private Sub tstCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles tstCantidad.KeyDown
      TryCatched(Sub()
                    If e.KeyCode = Keys.Enter Then
                       Reglas.ParametrosCache.Instancia.CantidadMaximaParametrosMonitoreados = Integer.Parse(tstCantidad.Text)
                    End If
                 End Sub)
   End Sub
   Private Sub tsbCantidad_Click(sender As Object, e As EventArgs) Handles tsbCantidad.Click
      TryCatched(Sub() Reglas.ParametrosCache.Instancia.CantidadMaximaParametrosMonitoreados = Integer.Parse(tstCantidad.Text))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub timerListChanged_Tick(sender As Object, e As EventArgs) Handles timerListChanged.Tick
      TryCatched(Sub()
                    ugParametros.ActivateFirstVisibleRow()
                    tssRegistros.MostrarRegistros(Reglas.ParametrosCache.Instancia.UltimosParametrosAccedidos)
                    timerListChanged.Stop()
                 End Sub)
   End Sub

   Private Sub MonitorParametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

   End Sub
#End Region

End Class