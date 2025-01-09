Public Class RegistracionPagosConfirmacion

   Private _Cae As Boolean = False

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(SolicitarCae As Boolean)
      Me.New()

      _Cae = SolicitarCae
   End Sub

#Region "Propiedades"
   Public Property ImprimeResumen As Boolean
   Public Property ImprimeResumenDetallado As Boolean
   Public Property SolicitarCae As Boolean
#End Region


#Region "Eventos"
   Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
      Try
         DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub

   Private Sub chbResumen_CheckedChanged(sender As Object, e As EventArgs) Handles chbResumen.CheckedChanged
      ImprimeResumen = Me.chbResumen.Checked
   End Sub

   Private Sub chbResumenDetallado_CheckedChanged(sender As Object, e As EventArgs) Handles chbResumenDetallado.CheckedChanged
      ImprimeResumenDetallado = Me.chbResumenDetallado.Checked
   End Sub

   Private Sub chbSolicitarCae_CheckedChanged(sender As Object, e As EventArgs) Handles chbSolicitarCae.CheckedChanged
      SolicitarCae = Me.chbSolicitarCae.Checked
   End Sub

   Private Sub RegistracionPagosConfirmacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      chbSolicitarCae.Enabled = SolicitarCae
   End Sub


#End Region

End Class