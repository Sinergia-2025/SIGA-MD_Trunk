Public Class VinculacionToken
   Public Sub New()
      InitializeComponent()

      '# Cargo el token actual
      Me.txtToken.Text = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeToken
   End Sub

   Private Sub btnToken_Click(sender As Object, e As EventArgs) Handles btnToken.Click
      Try
         Me.ObtenerToken()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   '-------------------------------------------------------
   Private Sub ObtenerToken()
      Dim cliente = New NemiroCustoms.TiendaNubeClient("2505", "WdjslUpzINsqXgY9iwn3OtJdPuJ1skJJMtU5g6Lebm5Xlqjg") '# ClientID y Secret de SIGA

      Using login = New Nemiro.OAuth.LoginForms.Login(cliente)
         Dim result = login.ShowDialog()
         If result = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(login.AccessTokenValue) Then
               Me.txtToken.Text = login.AccessTokenValue
               ShowMessage("Se generó Token para Tienda Nube correctamente !!!")

               '# Guardo el token
               Me.GuardarToken()
            End If
         End If
      End Using
   End Sub
   '-------------------------------------------------------
   Private Sub GuardarToken()
      Dim rParametros As Reglas.Parametros = New Reglas.Parametros
      rParametros.SetValor(CInt(actual.Sucursal.IdEmpresa), Entidades.Parametro.Parametros.TIENDANUBETOKEN.ToString(), Me.txtToken.Text.Trim())
   End Sub
   '-------------------------------------------------------
End Class