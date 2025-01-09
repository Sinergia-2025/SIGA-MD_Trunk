Public Class VisorTexto

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         tsbSalir.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      DialogResult = DialogResult.Cancel
      Close()
   End Sub

   Public Overloads Function ShowDialog(owner As Form, titulo As String, texto As String) As DialogResult
      Text = String.Format(Text, titulo)
      txtTexto.Text = texto
      Return ShowDialog(owner)
   End Function

End Class