Public Class ArchivoDestinoExportacion

   Private Sub btnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click
      Dim DialogoGuardarArchivo As SaveFileDialog = New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Archivos Valores Separados por Comas (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then

               Me.txtArchivoDestino.Text = DialogoGuardarArchivo.FileName
            End If
         Catch Ex As Exception
            MessageBox.Show(Ex.Message)
         End Try

      End If
     
   End Sub

   Private Sub tsbConfirmar_Click(sender As Object, e As EventArgs) Handles tsbConfirmar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Yes
      Me.Close()
   End Sub
End Class