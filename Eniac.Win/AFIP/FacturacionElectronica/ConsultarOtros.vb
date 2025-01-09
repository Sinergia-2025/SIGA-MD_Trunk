Public Class ConsultarOtros

   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultarCantMaxRegDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarCantMaxRegDet.Click
      Try
         If Not Publicos.HayInternet() Then
            MessageBox.Show("No tiene internet para realizar esta acción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor
         Dim reg As Reglas.AFIPFE = New Reglas.AFIPFE()
         Me.txtCantidadMaxRegistrosDetalle.Text = reg.GetCantMaxRegistroDetalleV1().ToString()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

End Class