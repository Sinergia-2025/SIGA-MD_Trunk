Namespace ServiciosRest.CotizacionMonedas
   Public Class CotizacionMonedasAFIPExportacion
      Implements ICotizacionMonedas

      Public Function Obtener() As Cotizacion Implements ICotizacionMonedas.Obtener
         Try
            Dim afip = New AFIPFEX()
            Dim cotizacion = afip.GetCotizacionDolar()
            Return New Cotizacion() With {.Comprador = cotizacion, .Vendedor = cotizacion, .Promedio = cotizacion}
         Catch ex As Exception
            Return New Cotizacion()
         End Try
      End Function
   End Class
End Namespace