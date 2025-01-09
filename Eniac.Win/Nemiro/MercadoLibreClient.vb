
Namespace NemiroCustoms

   Public Class MercadoLibreClient
      Inherits Nemiro.OAuth.OAuth2Client

      Public Sub New(clientId As String, clientSecret As String)

         '                         http://auth.mercadolibre.com.ar/authorization?response_type=code&client_id=1025020883342335
         '                         https://api.mercadolibre.com/oauth/token
         MyBase.New(String.Format("http://auth.mercadolibre.com.ar/authorization?response_type=code&client_id={0}", clientId), "https://api.mercadolibre.com/oauth/token", clientId, clientSecret)
         GrantType = Nemiro.OAuth.GrantType.AuthorizationCode

      End Sub

      Public Overrides ReadOnly Property ProviderName As String
         Get
            Return "Mercado Libre"
         End Get
      End Property



      Protected Overrides Sub GetAccessToken()

         Dim client = New Net.WebClient()

         Dim formData = New Specialized.NameValueCollection()
         formData.Add("grant_type", "authorization_code")
         formData.Add("client_id", ApplicationId)
         formData.Add("client_secret", ApplicationSecret)
         formData.Add("code", AuthorizationCode)

         Dim response = client.UploadValues(AccessTokenUrl, "POST", formData)
         Dim srtResponse = System.Text.Encoding.UTF8.GetString(response)
         Dim result = New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of MercadoLibreAccessTokenResponse)(srtResponse)

         AccessToken = New MercadoLibreAccessToken(result.access_token)

      End Sub

      Private Class MercadoLibreAccessToken
         Inherits Nemiro.OAuth.OAuth2AccessToken
         Public Sub New(accessToken As String)
            MyBase.New(accessToken, String.Empty)
            StatusCode = 200
         End Sub
      End Class
      Private Class MercadoLibreAccessTokenResponse
         Public Property access_token As String
         Public Property token_type As String
         Public Property scope As String
         Public Property user_id As Integer

      End Class

   End Class

End Namespace