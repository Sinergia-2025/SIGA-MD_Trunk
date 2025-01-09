Option Strict On
Option Explicit On
Namespace ServiciosRest.CotizacionMonedas
   Friend Class CotizacionMonedaDesactivado
      Implements ICotizacionMonedas
      Public Function Obtener() As Cotizacion Implements ICotizacionMonedas.Obtener
         Return New Cotizacion()
      End Function
   End Class
End Namespace