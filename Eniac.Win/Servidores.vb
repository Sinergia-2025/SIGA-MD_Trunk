Public Class Servidores

   Private _servidorPorDefecto As String = "Servidor.txt"
   Private _directorioConfig As String = Entidades.Publicos.CarpetaEniac

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         System.IO.Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory)
         'System.IO.Directory.SetCurrentDirectory(Me._directorioConfig)

         If System.IO.File.Exists(Me._servidorPorDefecto) Then
            Dim fileContents As String = My.Computer.FileSystem.ReadAllText(Me._servidorPorDefecto)
            Ayudantes.Conexiones.Servidor = fileContents
            Ayudantes.Conexiones.ServidorWS = fileContents.Substring(0, fileContents.IndexOf("\"c))
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Exit Sub
         Else
            Dim ay As Ayudantes.Conexiones = New Ayudantes.Conexiones()
            Me.cmbServidores.DataSource = ay.GetTodosLosServidoresSQLServer()
            Me.cmbServidores.DisplayMember = "Name"
            Me.cmbServidores.ValueMember = "Server"
         End If
      Catch ex As Exception
         MessageBox.Show("Error obteniendo los servidores. - " + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      Select Case Me.cmbServidores.Items.Count
         Case 0
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
         Case 1
            Ayudantes.Conexiones.Servidor = Me.cmbServidores.Text
            Ayudantes.Conexiones.ServidorWS = Me.cmbServidores.SelectedValue.ToString()
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            My.Computer.FileSystem.WriteAllText(Me._servidorPorDefecto, Ayudantes.Conexiones.Servidor, False)
         Case Else
            If System.IO.File.Exists(Me._servidorPorDefecto) Then
               Try
                  Dim fileContents As String = My.Computer.FileSystem.ReadAllText(Me._servidorPorDefecto)
                  Me.cmbServidores.Text = fileContents
                  Ayudantes.Conexiones.Servidor = fileContents
                  Ayudantes.Conexiones.ServidorWS = Me.cmbServidores.SelectedValue.ToString()
                  Me.Close()
                  Me.DialogResult = Windows.Forms.DialogResult.OK
               Catch ex As Exception
                  'no hago nada de nada
               End Try
            End If
      End Select

   End Sub

   Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
      Try
         Ayudantes.Conexiones.Servidor = Me.cmbServidores.Text
         Ayudantes.Conexiones.ServidorWS = Me.cmbServidores.SelectedValue.ToString()
         Me.Close()
         Me.DialogResult = Windows.Forms.DialogResult.OK
         My.Computer.FileSystem.WriteAllText(Me._servidorPorDefecto, Ayudantes.Conexiones.Servidor, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class