Public Class PreciosCalculos

   Public Function GetPrecioCosto(ByRef componentes As DataTable, dividetamano As Boolean, factorConversionProducto As Decimal) As Decimal
      Dim costo As Decimal = 0
      Dim costoLinea As Decimal = 0
      Dim costoLineaDolar As Decimal = 0
      Dim valorConversion As Decimal = 0
      Dim tamano As Decimal = 0

      'el costo a calcular va a variar dependiendo del factor de conversión de la moneda seleccionada.
      'el tamaño es calculado si esta seteado en los parametros del usuario que lo haga

      For Each dr As DataRow In componentes.Rows
         If Not String.IsNullOrEmpty(dr("Cantidad").ToString()) Then
            'multiplico el precio de costo por el factor de conversión de la moneda
            valorConversion = Decimal.Parse(dr("PrecioCosto").ToString()) * Decimal.Parse(dr("FactorConversion").ToString())
            If dividetamano Then
               'esto lo hago si esta el parametro general seteado
               Decimal.TryParse(dr("Tamano").ToString(), tamano)
               If tamano <> 0 Then
                  costoLinea = valorConversion * Decimal.Parse(dr("Cantidad").ToString()) / tamano
                  If Decimal.Parse(dr("FactorConversion").ToString()) = 1 Then
                     costoLineaDolar = (Decimal.Parse(dr("PrecioCosto").ToString()) / factorConversionProducto) * Decimal.Parse(dr("Cantidad").ToString()) / tamano
                  Else
                     costoLineaDolar = Decimal.Parse(dr("PrecioCosto").ToString()) * Decimal.Parse(dr("Cantidad").ToString()) / tamano
                  End If
               Else
                  'si el tamaño esta en 0 no lo divido para que no reviente
                  costoLinea = valorConversion * Decimal.Parse(dr("Cantidad").ToString())
                  If Decimal.Parse(dr("FactorConversion").ToString()) = 1 Then
                     costoLineaDolar = (Decimal.Parse(dr("PrecioCosto").ToString()) / factorConversionProducto) * Decimal.Parse(dr("Cantidad").ToString())
                  Else
                     costoLineaDolar = Decimal.Parse(dr("PrecioCosto").ToString()) * Decimal.Parse(dr("Cantidad").ToString())
                  End If
               End If
            Else
               'no tengo en cuenta el tamaño para calcular la formula (teniamos clientes que no podiamos afectar)
               costoLinea = valorConversion * Decimal.Parse(dr("Cantidad").ToString())
               ' costoLineaDolar = Decimal.Parse(dr("PrecioCosto").ToString()) * Decimal.Parse(dr("Cantidad").ToString())
               If Decimal.Parse(dr("FactorConversion").ToString()) = 1 Then
                  costoLineaDolar = (Decimal.Parse(dr("PrecioCosto").ToString()) / factorConversionProducto) * Decimal.Parse(dr("Cantidad").ToString())
               Else
                  costoLineaDolar = Decimal.Parse(dr("PrecioCosto").ToString()) * Decimal.Parse(dr("Cantidad").ToString())
               End If
            End If
         End If
         dr("CostoLinea") = costoLinea.ToString("#,###,##0.0000")
         dr("CostoLineaDolar") = costoLineaDolar.ToString("#,###,##0.0000")
         costo += costoLinea
         costoLinea = 0
         tamano = 0
      Next

      Return (costo / factorConversionProducto)
   End Function




End Class
