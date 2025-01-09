Public Class ucNDConfActualizador

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      txtPathDescargaMSIActualizador.Text = Reglas.Publicos.URLPathDescargaMSI
      txtURLActualizador.Text = Reglas.Publicos.URLActualizacion

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      VerificaPathMSI()
      ActualizarParametro(Entidades.Parametro.Parametros.UBICACIONMSI, txtPathDescargaMSIActualizador, Nothing, lblPathDescargaMSIActualizador.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.URLACTUALIZADOR, txtURLActualizador, Nothing, lblURLActualizador.Text)

   End Sub

   '-- REQ-33689.- -----------------------------------------------------------------
   Private Sub cmdDestinoArchivosMSI_Click(sender As Object, e As EventArgs) Handles cmdDestinoArchivosMSI.Click
      Using dialogo = New FolderBrowserDialog()
         dialogo.SelectedPath = txtPathDescargaMSIActualizador.Text
         If dialogo.ShowDialog() = DialogResult.OK Then
            txtPathDescargaMSIActualizador.Text = dialogo.SelectedPath & "\"
         End If
      End Using
   End Sub

   Private Sub txtPathDescargaMSIActualizador_Leave(sender As Object, e As EventArgs) Handles txtPathDescargaMSIActualizador.Leave
      VerificaPathMSI()
   End Sub
   '--------------------------------------------------------------------------------
   Private Function VerificaPathMSI() As String
      Dim sTxtPath As String
      If Not String.IsNullOrEmpty(txtPathDescargaMSIActualizador.Text) Then
         sTxtPath = Mid(txtPathDescargaMSIActualizador.Text, Len(txtPathDescargaMSIActualizador.Text))
         If sTxtPath <> "\" Then
            txtPathDescargaMSIActualizador.Text = txtPathDescargaMSIActualizador.Text & "\"
         End If
      End If

   End Function
End Class