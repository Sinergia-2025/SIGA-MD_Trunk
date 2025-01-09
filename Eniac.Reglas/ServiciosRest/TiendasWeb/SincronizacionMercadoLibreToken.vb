Namespace ServiciosRest.TiendasWeb
   Partial Class SincronizacionMercadoLibre

      Public Function GetToken(appId As String, appSecret As String, code As String) As Entidades.JSonEntidades.TiendasWeb.Mercadolibre.AccessTokenML

         Dim relativePath = New StringBuilder("oauth/token?grant_type=authorization_code")
         Dim rCabecera As New Dictionary(Of String, String)

         relativePath.AppendFormat("&client_id={0}", appId)             '8477661978426261
         relativePath.AppendFormat("&client_secret={0}", appSecret)     '1oOiZCj3hFeWkXciXzOrjNlXgRruGJNv
         relativePath.AppendFormat("&code={0}", code)                   'TG-60cbb828202f3c0008992e2a-776468130
         relativePath.AppendFormat("&redirect_uri=https://www.sinergiasoftware.com.ar/")

         Dim token = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.AccessTokenML)(String.Empty, SincroTiendaWebMetodos.POST, rCabecera, relativePath.ToString())

         Return token

      End Function

      Public Function GetRefreshToken(appId As String, appSecret As String, refreshToken As String) As Entidades.JSonEntidades.TiendasWeb.Mercadolibre.AccessTokenML

         Dim rCabecera As New Dictionary(Of String, String)

         Dim relativePath = New StringBuilder("oauth/token?grant_type=refresh_token")
         relativePath.AppendFormat("&client_id={0}", appId)             '8477661978426261
         relativePath.AppendFormat("&client_secret={0}", appSecret)     '1oOiZCj3hFeWkXciXzOrjNlXgRruGJNv
         relativePath.AppendFormat("&refresh_token={0}", refreshToken)  'TG-60cbb828202f3c0008992e2a-776468130

         Dim token = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.AccessTokenML)(String.Empty, SincroTiendaWebMetodos.POST, rCabecera, relativePath.ToString())

         Return token

      End Function

      '-------------------------------------------------------
      '-- Proceso de Guardado de Token.- --
      Public Sub GuardarToken(CodigoToken As String,
                               FechaRefres As String,
                               RefresToken As String,
                               CodigoResell As String
                               )
         '-- Carga los Parametros nuevos.- --
         Dim rParametros As New Reglas.Parametros
         With rParametros
            '-- Codigo Token Actualiza.- -- 
            .SetValor(CInt(actual.Sucursal.IdEmpresa), Entidades.Parametro.Parametros.MERCADOLIBRETOKEN.ToString(), CodigoToken.Trim())
            '-- Fecha Expiracion de Token.- --
            .SetValor(CInt(actual.Sucursal.IdEmpresa), Entidades.Parametro.Parametros.MERCADOLIBREFECHATOKEN.ToString(), FechaRefres.ToString())
            '-- Codigo de Refresh Token.- --
            .SetValor(CInt(actual.Sucursal.IdEmpresa), Entidades.Parametro.Parametros.MERCADOLIBREREFRESHTOKEN.ToString(), RefresToken.ToString())
            '-- Codigo de Reseller.- --
            .SetValor(CInt(actual.Sucursal.IdEmpresa), Entidades.Parametro.Parametros.MERCADOLIBRECODIGORESELLER.ToString(), CodigoResell.ToString())
         End With

         '-- Refresca los Parametros nuevos.- --
         With Reglas.ParametrosCache.Instancia
            '-- Codigo Token Refresh.- -- 
            .LimpiarCache(Entidades.Parametro.Parametros.MERCADOLIBRETOKEN.ToString())
            '-- Fecha Expiracion Refresh.- -- 
            .LimpiarCache(Entidades.Parametro.Parametros.MERCADOLIBREFECHATOKEN.ToString())
            '-- Codigo Token Refresh.- -- 
            .LimpiarCache(Entidades.Parametro.Parametros.MERCADOLIBREREFRESHTOKEN.ToString())
            '-- Codigo Reseller Refresh.- -- 
            .LimpiarCache(Entidades.Parametro.Parametros.MERCADOLIBRECODIGORESELLER.ToString())
         End With

      End Sub
      '-------------------------------------------------------

      Public Function ObtenerCodigoToken(ByRef code As String) As Boolean

         Using proceso = New Process()
            proceso.StartInfo.UseShellExecute = False
            proceso.StartInfo.RedirectStandardOutput = True
            proceso.StartInfo.CreateNoWindow = True
            '-- Inicia Proceso.- --
            proceso.Start(String.Format("http://auth.mercadolibre.com.ar/authorization?response_type=code&client_id={0}", Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoAppIdML))

         End Using
         '-- Retorna Valor de Obtencion.- --
         Return Not String.IsNullOrWhiteSpace(code)

      End Function

   End Class

End Namespace