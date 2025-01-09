Public Class VisorFotos

   Public Property NombreArchivo As String
   Public Property Foto As System.Drawing.Image

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.pcbFoto.Image = Foto
   End Sub

   Private Sub tsbDescargar_Click(sender As Object, e As EventArgs) Handles tsbDescargar.Click
      Try
         Dim mime As String = Foto.MimeType()
         Dim extension As String
         Dim filtro As String
         Select Case mime
            Case "image/jpeg"
               extension = "jpg"
               filtro = "File Images (*.jpg;*.jpeg;) | *.jpg;*.jpeg;"
            Case "image/png"
               extension = "png"
               filtro = "PNG Images | *.png"
            Case Else
               extension = "jpg"
               filtro = "File Images (*.jpg;*.jpeg;) | *.jpg;*.jpeg;"
         End Select

         sfdArchivo.Filter = filtro
         sfdArchivo.FileName = String.Format("{0}.{1}", NombreArchivo, extension)

         If sfdArchivo.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Foto.Save(sfdArchivo.FileName)

            ShowMessage("Archivo descargado exitosamente!")
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

End Class