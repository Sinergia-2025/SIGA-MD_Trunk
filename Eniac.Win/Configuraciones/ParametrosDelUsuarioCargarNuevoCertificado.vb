Public Class ParametrosDelUsuarioCargarNuevoCertificado

   Public Property Archivo As IO.FileInfo
   Public Property FechaVencimineto As DateTime
   Private _fechaVencimientoReferencia As DateTime

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      _fechaVencimientoReferencia = Today.AddYears(2).AddDays(-1)
      dtpVencimientoCertificado.Value = _fechaVencimientoReferencia
   End Sub

   Private Sub btnBuscarArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscarArchivo.Click
      Try
         Me.ofdCertificado.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
         If Me.ofdCertificado.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdCertificado.FileName) Then
               txtArchivoCertificado.Text = ofdCertificado.FileName
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         If String.IsNullOrWhiteSpace(txtArchivoCertificado.Text) Then
            ShowMessage("Debe seleccionar un archivo")
            Exit Sub
         End If
         Dim fi As IO.FileInfo = New IO.FileInfo(txtArchivoCertificado.Text)
         If Not fi.Exists Then
            ShowMessage(String.Format("No se puede encontrar el archivo {0}", txtArchivoCertificado.Text))
            Exit Sub
         End If

         If dtpVencimientoCertificado.Value < _fechaVencimientoReferencia Then
            If ShowPregunta(String.Format("La fecha de vencimiento es menor a 1 año {0:dd/MM/yyyy}. ¿Esta correctamente cargada la fecha de vencimiento?", dtpVencimientoCertificado.Value)) = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         End If

         Archivo = fi
         FechaVencimineto = dtpVencimientoCertificado.Value

         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
   End Sub
End Class