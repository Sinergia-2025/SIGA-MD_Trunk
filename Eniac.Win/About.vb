Public Class About


   Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Set the title of the form.
      Dim ApplicationTitle As String
      If My.Application.Info.Title <> "" Then
         ApplicationTitle = My.Application.Info.Title
      Else
         ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
      End If
      Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
      ' Initialize all of the text displayed on the About Box.
      '    properties dialog (under the "Project" menu).
      Me.LabelProductName.Text = My.Application.Info.ProductName
      Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString())
      Me.LabelCopyright.Text = My.Application.Info.Copyright
      Me.LabelCompanyName.Text = My.Application.Info.CompanyName
      'Me.TextBoxDescription.Text = My.Application.Info.Description

      For Each assembly As System.Reflection.Assembly In AppDomain.CurrentDomain.GetAssemblies()
         If assembly.GetName().Name.Equals("Eniac.Win") Then
            If Not assembly.GetName().Version.Equals(My.Application.Info.Version) Then
               LabelVersion.Text += String.Format(" ({0})", assembly.GetName().Version.ToString())
            End If
         End If
      Next

   End Sub

   Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
      Me.Close()
   End Sub

   Private Sub txtPaginaWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles txtPaginaWeb.LinkClicked
      Try
         Process.Start(txtPaginaWeb.Text)
      Catch ex As Exception

      End Try
   End Sub

   Private Sub txtCorreoElectronico_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles txtCorreoElectronico.LinkClicked
      Try
         Process.Start(String.Format("mailto:{0}&subject={1}", txtCorreoElectronico.Text, LabelProductName.Text))
      Catch ex As Exception

      End Try
   End Sub
End Class
