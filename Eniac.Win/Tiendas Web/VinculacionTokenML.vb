
Public Class VinculacionTokenML
   Public FechaToken As DateTime
   Public TokenRefresh As String = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoRefreshTokenML
   Public CodigoResell As String = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoResellerML
   Public codeTG As String = String.Empty

   Public Sub New()
      InitializeComponent()

      '# Cargo el token actual
      Me.txtToken.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreToken

   End Sub

   Private Sub btnInicializar_Click(sender As Object, e As EventArgs) Handles btnInicializar.Click
      Try
         '-- Ejecuta Proceso de Inicio de Mercado Libre.- --
         ProcesoInicio()
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

   '----------------------------------------------
   '-- Procedimiento inicial de Mercado Libre.- --
   Private Sub ProcesoInicio()
      Dim sincML As New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()

      Try
         '-- Obtengo los Valores del TG (Codigo de Token).- --
         sincML.ObtenerCodigoToken(codeTG)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   '-------------------------------------------------------
   '-- Procedimiento de Carga de Categorias.- --
   Private Sub ProcesoCategorias()
      Dim CategoriasML = New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()
      Try
         '-- Verifica la Configuracion.- --
         Reglas.Publicos.VerificaConfiguracionRegional()
         '-- Proceso de Categorias.- --
         CategoriasML.ActualizaCategorias()
         ShowMessage("Proceso de Categorizacion Finalizado.- !!!")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
      Dim sincML As New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()

      Try
         '-- Asigno Fecha del Sistema.- --
         FechaToken = DateTime.Now()
         '-- Obtengo los Valores del TG (Codigo de Token).- --
         If Not String.IsNullOrEmpty(txtCodigoAutorizacion.Text) Then
            '-- Ejecuto autorizacion sobre Mercado Libre - Obtengo Valor Token.- --
            Dim token = sincML.GetToken(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoAppIdML,
                                  Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoSecretML,
                                  txtCodigoAutorizacion.Text)
            '-- Actualiza Fecha de Expiracion.- --
            FechaToken = FechaToken.AddSeconds(token.expires_in)
            '-- Proceso de Gabado de Datos al sistema.- --
            sincML.GuardarToken(token.access_token, FechaToken.ToString(), token.refresh_token, token.user_id)
            '-- Inicia Proceso de Solicitud de Token.- --
            Me.txtToken.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreToken
            '-- Informo Exito del Proceso.- --
            ShowMessage("Se generó Token para Mercado Libre correctamente !!!")
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   '-------------------------------------------------------

End Class