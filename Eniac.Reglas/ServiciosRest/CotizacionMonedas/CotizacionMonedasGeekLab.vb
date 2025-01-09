Option Strict On
Option Explicit On
Namespace ServiciosRest.CotizacionMonedas
   Public Class CotizacionMonedasGeekLab
      Implements ICotizacionMonedas
      Friend Function Obtener() As Cotizacion Implements ICotizacionMonedas.Obtener
         Try
            If Publicos.EstaActivaLaURL("http://ws.geeklab.com.ar/dolar/get-dolar-json.php") Then
               Dim moneda As Entidades.MonedaDolar = New Reglas.ServiciosRest.ConsultaDolar(New Uri("http://ws.geeklab.com.ar/dolar/get-dolar-json.php")).GetValor()
               If moneda IsNot Nothing AndAlso moneda.libre.HasValue Then
                  Return New Cotizacion() With {.Promedio = moneda.libre.Value}
               End If
            End If
         Catch ex As Exception
            'si da error que no haga nada
         End Try
         Return New Cotizacion()
      End Function
   End Class
End Namespace