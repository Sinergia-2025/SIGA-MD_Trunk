Namespace NemiroCustoms
   Public Class TiendaNubeClient
      Inherits Nemiro.OAuth.OAuth2Client

      'Uso
      'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      '   Try
      '      Dim cliente = New TiendaNubeClient("2505", "WdjslUpzINsqXgY9iwn3OtJdPuJ1skJJMtU5g6Lebm5Xlqjg")
      '      Using login = New Nemiro.OAuth.LoginForms.Login(cliente)
      '         Dim result = login.ShowDialog()
      '         If result = Windows.Forms.DialogResult.OK Then
      '            TextBox1.Text = login.AccessTokenValue
      '         End If
      '      End Using
      '   Catch ex As Exception
      '      MessageBox.Show(ex.Message)
      '   End Try
      'End Sub


      Public Sub New(clientId As String, clientSecret As String)
         MyBase.New(String.Format("https://www.tiendanube.com/apps/{0}/authorize", clientId), "https://www.tiendanube.com/apps/authorize/token", clientId, clientSecret)
         GrantType = Nemiro.OAuth.GrantType.AuthorizationCode
      End Sub

      Public Overrides ReadOnly Property ProviderName As String
         Get
            Return "Tienda Nube"
         End Get
      End Property

      Protected Overrides Sub GetAccessToken()
         'MyBase.GetAccessToken()

         Dim client = New Net.WebClient()

         Dim formData = New Specialized.NameValueCollection()
         formData.Add("grant_type", "authorization_code")
         formData.Add("client_id", ApplicationId)
         formData.Add("client_secret", ApplicationSecret)
         formData.Add("code", AuthorizationCode)

         Dim response = client.UploadValues(AccessTokenUrl, "POST", formData)
         Dim srtResponse = System.Text.Encoding.UTF8.GetString(response)
         Dim result = New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of TiendaNubeAccessTokenResponse)(srtResponse)

         AccessToken = New TiendaNubeAccessToken(result.access_token)

      End Sub

      Private Class TiendaNubeAccessToken
         Inherits Nemiro.OAuth.OAuth2AccessToken
         Public Sub New(accessToken As String)
            MyBase.New(accessToken, String.Empty)
            StatusCode = 200
         End Sub
      End Class


      Private Class TiendaNubeAccessTokenResponse
         Public Property access_token As String
         Public Property token_type As String
         Public Property scope As String
         Public Property user_id As Integer

      End Class
   End Class
End Namespace