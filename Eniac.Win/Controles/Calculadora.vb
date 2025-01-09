Public Class Calculadora

#Region "Overrides"

   'Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

   '   MyBase.OnLoad(e)

   '   Me.ulcCalculadora.Focus()

   'End Sub

#End Region

#Region "Eventos"

   Private Sub Calculadora_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

      'Lo asigno al control porque queda en el ultimo lugar que se posiciono, y si esta en los botones OK/Cerrar no toca las teclas 123456789/*-+
      Me.ulcCalculadora.Focus()

   End Sub

   Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

#End Region

End Class