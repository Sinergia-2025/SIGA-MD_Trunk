Imports System.ComponentModel
Namespace ServiciosRest.CotizacionMonedas
   Friend Class CotizacionMonedasFactory
      Public Shared Function Crear() As ICotizacionMonedas
         Dim origen As CotizacionMonedasOrigen = Publicos.OrigenCotizacionMoneda
         Select Case origen
            Case CotizacionMonedasOrigen.GeekLab
               Return New CotizacionMonedasGeekLab()
            Case CotizacionMonedasOrigen.BancoNacion
               Return New CotizacionMonedasBancoNacion()
            Case CotizacionMonedasOrigen.AFIPExportacion
               Return New CotizacionMonedasAFIPExportacion()
            Case CotizacionMonedasOrigen.Desactivado
               Return New CotizacionMonedaDesactivado()
            Case Else
               Throw New NotImplementedException(String.Format("El Origen de Cotización de Moneda '{0}' no fue implementado.", origen))
         End Select
      End Function
   End Class
   Public Enum CotizacionMonedasOrigen
      <Description("Promedio Mercado")> GeekLab
      <Description("Banco Nacion Argentina")> BancoNacion
      <Description("AFIP Ws Exportación")> AFIPExportacion
      <Description("Desactivado")> Desactivado
   End Enum
   Public Enum CotizacionMonedasOperacion
      Promedio
      Comprador
      Vendedor
   End Enum
End Namespace