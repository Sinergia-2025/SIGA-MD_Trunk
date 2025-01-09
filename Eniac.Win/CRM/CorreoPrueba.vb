Public Class CorreoPrueba

   Dim _CorreoPrueba As String = String.Empty
   Public Sub New()

      Me.InitializeComponent()

   End Sub


   Public Sub New(ByVal CorreoPrueba As String)

      Me.New()
      Me._CorreoPrueba = CorreoPrueba

   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.txtCorreoDePrueba.Text = _CorreoPrueba

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

End Class