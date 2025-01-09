Public Class GenerarCuentaCorrienteConfirmar

   Private _dt As DataTable
   Private _formatear As IGenerarCuentaCorrienteConfirmar

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(dt As DataTable, formatear As IGenerarCuentaCorrienteConfirmar)
      Me.New()

      _dt = dt
      _formatear = formatear
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            ugPasajeros.DataSource = _dt.Select("Selec").CopyToDataTable(Function() _dt.Clone())
            _formatear.FormatearGrillaPasajeros(ugPasajeros)
         End Sub)

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

End Class
Public Interface IGenerarCuentaCorrienteConfirmar
   Sub FormatearGrillaPasajeros(ugPasajeros As UltraGrid)
End Interface