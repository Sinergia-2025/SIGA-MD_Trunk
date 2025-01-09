Option Strict On
Option Explicit On
Namespace ServiciosRest.CotizacionMonedas
   Public Class CotizacionMonedas
      Public Function ObtenerCotizacion() As Cotizacion
         Return CotizacionMonedasFactory.Crear().Obtener()
      End Function
      Public Function ObtenerCotizacionValor() As Decimal
         Dim cotiz As Cotizacion = ObtenerCotizacion()

         Dim origen As CotizacionMonedasOperacion = Publicos.OperacionCotizacionMonedas
         Select Case origen
            Case CotizacionMonedasOperacion.Promedio
               Return cotiz.Promedio
            Case CotizacionMonedasOperacion.Comprador
               Return cotiz.Comprador
            Case CotizacionMonedasOperacion.Vendedor
               Return cotiz.Vendedor
            Case Else
               Throw New NotImplementedException(String.Format("La Cotización de Moneda '{0}' no fue implementada.", origen))
         End Select

      End Function
   End Class
   Public Class Cotizacion
      Public Property Comprador As Decimal
      Public Property Vendedor As Decimal
      Public Property Promedio As Decimal
   End Class
End Namespace