Option Strict On
Option Explicit On

Public Class SincronizarPanelDeControl
   Private _controles As Control()
   Private _toolstrip As ToolStripItem()

   Public Sub New()
      InitializeComponent()
      _controles = {btnSincronizar}
      _toolstrip = {tsbSalir}
   End Sub


#Region "Eventos"
   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
      TryCatched(_controles, _toolstrip, Sub() Sincronizar())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region

   Private Sub regla_Avance(sender As Object, e As Reglas.AvanceSincronizarPanelDeControlEventArgs)
      tssInfo.Text = e.ToString()
      Application.DoEvents()
   End Sub

   Private Sub Sincronizar()
      Dim regla = New Reglas.SincronizarPanelDeControl(IdFuncion)
      AddHandler regla.Avance, AddressOf regla_Avance
      Try
         regla.Sincronizar(chbReenviar.Checked, chbEnviarWebPanelDeControl.Checked, chbExportarPanelDeControl.Checked,
                           chbEnviarWebPanelDeFechasSalida.Checked, chbExportarPanelDeFechasSalida.Checked)
      Finally
         RemoveHandler regla.Avance, AddressOf regla_Avance
      End Try
   End Sub


End Class