Option Strict On
Option Explicit On
''' <summary>
''' Agrupa funciones de cálculo que se utilizan cuando se manipulan valores con o sin impuestos
''' </summary>
''' <remarks></remarks>
Public Class CalculosImpositivos

   ''' <summary>
   ''' Permite obtener el Precio Sin Impuestos desde el Precio Con Impuestos de un producto.
   ''' </summary>
   ''' <param name="precioCI">Precio Con Impuestos</param>
   ''' <param name="producto">Producto al que se desea calcular el precio Sin Impuestos</param>
   ''' <returns>El Precio Sin Impuestos del producto.</returns>
   ''' <remarks>Tener en cuenta que como impImpInt se debe pasar el importe unitario del importe de impuesto interno.</remarks>
   Public Shared Function ObtenerPrecioSinImpuestos(precioCI As Decimal, producto As Entidades.Producto) As Decimal
      Return ObtenerPrecioSinImpuestos(precioCI, producto, producto.Alicuota)
   End Function

   ''' <summary>
   ''' Permite obtener el Precio Sin Impuestos desde el Precio Con Impuestos de un producto.
   ''' </summary>
   ''' <param name="precioCI">Precio Con Impuestos</param>
   ''' <param name="porcIVA">Porcentaje de IVA del producto (ej: 21%)</param>
   ''' <param name="producto">Producto al que se desea calcular el precio Sin Impuestos</param>
   ''' <returns>El Precio Sin Impuestos del producto.</returns>
   ''' <remarks>Tener en cuenta que como impImpInt se debe pasar el importe unitario del importe de impuesto interno.</remarks>
   Public Shared Function ObtenerPrecioSinImpuestos(precioCI As Decimal, producto As Entidades.Producto, porcIVA As Decimal) As Decimal
      Return ObtenerPrecioSinImpuestos(precioCI, porcIVA, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
   End Function

   ''' <summary>
   ''' Permite obtener el Precio Sin Impuestos desde el Precio Con Impuestos de un producto.
   ''' </summary>
   ''' <param name="precioCI">Precio Con Impuestos</param>
   ''' <param name="porcIVA">Porcentaje de IVA del producto (ej: 21%)</param>
   ''' <param name="porcImpInt">Porcentaje de Impuesto Interno (ej: 8%)</param>
   ''' <param name="impImpInt">Importe Impuesto Interno (cuando tiene valor fijo de ImpInt)</param>
   ''' <returns>El Precio Sin Impuestos del producto.</returns>
   ''' <remarks>Tener en cuenta que como impImpInt se debe pasar el importe unitario del importe de impuesto interno.</remarks>
   Public Shared Function ObtenerPrecioSinImpuestos(precioCI As Decimal, porcIVA As Decimal, porcImpInt As Decimal, impImpInt As Decimal, origenPorcImpInt As Entidades.OrigenesPorcImpInt) As Decimal
      Dim factorImpInt As Decimal = porcImpInt / 100
      Dim factorIVA As Decimal = porcIVA / 100
      If origenPorcImpInt = Entidades.OrigenesPorcImpInt.BRUTO Then
         Return (precioCI - (Math.Min(Math.Abs(impImpInt), Math.Abs(precioCI)) * If(precioCI = 0, 1, (precioCI / Math.Abs(precioCI))))) * (1 - factorImpInt) / (1 + factorIVA)
      ElseIf origenPorcImpInt = Entidades.OrigenesPorcImpInt.NETO Then
         Return (precioCI - (Math.Min(Math.Abs(impImpInt), Math.Abs(precioCI)) * If(precioCI = 0, 1, (precioCI / Math.Abs(precioCI))))) / (1 + factorIVA + factorImpInt)
      Else
         ThrowOrigenNoImplementado(origenPorcImpInt)
      End If
   End Function

   ''' <summary>
   ''' Permite obtener el Precio Con Impuestos desde el Precio Sin Impuestos de un producto.
   ''' </summary>
   ''' <param name="precioSI">Precio Sin Impuestos</param>
   ''' <param name="producto">Producto al que se desea calcular el precio Con Impuestos</param>
   ''' <returns>El Precio Con Impuestos del producto.</returns>
   ''' <remarks>Tener en cuenta que como impImpInt se debe pasar el importe unitario del importe de impuesto interno.</remarks>
   Public Shared Function ObtenerPrecioConImpuestos(precioSI As Decimal, producto As Entidades.Producto) As Decimal
      Return ObtenerPrecioConImpuestos(precioSI, producto, producto.Alicuota)
   End Function

   ''' <summary>
   ''' Permite obtener el Precio Con Impuestos desde el Precio Sin Impuestos de un producto.
   ''' </summary>
   ''' <param name="precioSI">Precio Sin Impuestos</param>
   ''' <param name="producto">Producto al que se desea calcular el precio Con Impuestos</param>
   ''' <param name="porcIVA">Porcentaje de IVA del producto (ej: 21%)</param>
   ''' <returns>El Precio Con Impuestos del producto.</returns>
   ''' <remarks>Tener en cuenta que como impImpInt se debe pasar el importe unitario del importe de impuesto interno.</remarks>
   Public Shared Function ObtenerPrecioConImpuestos(precioSI As Decimal, producto As Entidades.Producto, porcIVA As Decimal) As Decimal
      Return ObtenerPrecioConImpuestos(precioSI, porcIVA, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
   End Function

   ''' <summary>
   ''' Permite obtener el Precio Con Impuestos desde el Precio Sin Impuestos de un producto.
   ''' </summary>
   ''' <param name="precioSI">Precio Sin Impuestos</param>
   ''' <param name="porcIVA">Porcentaje de IVA del producto (ej: 21%)</param>
   ''' <param name="porcImpInt">Porcentaje de Impuesto Interno (ej: 8%)</param>
   ''' <param name="impImpInt">Importe Impuesto Interno (cuando tiene valor fijo de ImpInt)</param>
   ''' <returns>El Precio Con Impuestos del producto.</returns>
   ''' <remarks>Tener en cuenta que como impImpInt se debe pasar el importe unitario del importe de impuesto interno.</remarks>
   Public Shared Function ObtenerPrecioConImpuestos(precioSI As Decimal, porcIVA As Decimal, porcImpInt As Decimal, impImpInt As Decimal, origenPorcImpInt As Entidades.OrigenesPorcImpInt) As Decimal
      Dim factorImpInt As Decimal = porcImpInt / 100
      Dim factorIVA As Decimal = porcIVA / 100
      If origenPorcImpInt = Entidades.OrigenesPorcImpInt.BRUTO Then
         Return (precioSI * (1 + factorIVA)) * (1 + (factorImpInt / (1 - factorImpInt))) + impImpInt
      ElseIf origenPorcImpInt = Entidades.OrigenesPorcImpInt.NETO Then
         Return (precioSI * (1 + factorIVA + factorImpInt)) + impImpInt
      Else
         ThrowOrigenNoImplementado(origenPorcImpInt)
      End If
   End Function

   ''' <summary>
   ''' Calcula el Impuesto Interno Unitario para un precio SIN Impuestos
   ''' </summary>
   ''' <param name="precioSI">Precio Sin Impuestos</param>
   ''' <param name="porcIVA">Porcentaje de IVA del producto (ej: 21%)</param>
   ''' <param name="porcImpInt">Porcentaje de Impuesto Interno (ej: 8%)</param>
   ''' <param name="impImpInt">Importe Impuesto Interno (cuando tiene valor fijo de ImpInt)</param>
   ''' <returns>Impuesto Interno Unitario</returns>
   ''' <remarks></remarks>
   Public Shared Function CalcularImpuestoInternoDesdeNetoSinIVA(precioSI As Decimal, porcIVA As Decimal, porcImpInt As Decimal, impImpInt As Decimal, origenPorcImpInt As Entidades.OrigenesPorcImpInt) As Decimal
      Dim factorImpInt As Decimal = porcImpInt / 100
      Dim factorIVA As Decimal = porcIVA / 100
      If origenPorcImpInt = Entidades.OrigenesPorcImpInt.BRUTO Then
         Return impImpInt + ((precioSI * (1 + factorIVA)) * (factorImpInt / (1 - factorImpInt)))
      ElseIf origenPorcImpInt = Entidades.OrigenesPorcImpInt.NETO Then
         Return impImpInt + (precioSI * factorImpInt)
      Else
         ThrowOrigenNoImplementado(origenPorcImpInt)
      End If
   End Function

   ''' <summary>
   ''' Calcula el Impuesto Interno Unitario para un precio Con Impuestos
   ''' </summary>
   ''' <param name="precioCI">Precio Con Impuestos</param>
   ''' <param name="porcIVA">Porcentaje de IVA del producto (ej: 21%)</param>
   ''' <param name="porcImpInt">Porcentaje de Impuesto Interno (ej: 8%)</param>
   ''' <param name="impImpInt">Importe Impuesto Interno (cuando tiene valor fijo de ImpInt)</param>
   ''' <returns>Impuesto Interno Unitario</returns>
   ''' <remarks></remarks>
   Public Shared Function CalcularImpuestoInternoDesdeNetoConIVA(precioCI As Decimal, porcIVA As Decimal, porcImpInt As Decimal, impImpInt As Decimal, origenPorcImpInt As Entidades.OrigenesPorcImpInt) As Decimal
      Dim factorImpInt As Decimal = porcImpInt / 100
      Dim factorIVA As Decimal = porcIVA / 100
      If origenPorcImpInt = Entidades.OrigenesPorcImpInt.BRUTO Then
         Return impImpInt + (precioCI * factorImpInt)
      ElseIf origenPorcImpInt = Entidades.OrigenesPorcImpInt.NETO Then
         Return CalcularImpuestoInternoDesdeNetoSinIVA(ObtenerPrecioSinImpuestos(precioCI, porcIVA, porcImpInt, impImpInt, origenPorcImpInt), porcIVA, porcImpInt, impImpInt, origenPorcImpInt)
      Else
         ThrowOrigenNoImplementado(origenPorcImpInt)
      End If
   End Function

   ''' <summary>
   ''' Dispara una excepción indicando que el métido de calculo para el origen indicado no fue implementado.
   ''' </summary>
   ''' <param name="origenPorcImpInt">Origen para el calculo de impuestos internos desde porcentaje.</param>
   ''' <remarks>Throws Exception</remarks>
   Private Shared Sub ThrowOrigenNoImplementado(origenPorcImpInt As Entidades.OrigenesPorcImpInt)
      Throw New Exception(String.Format("Origen de calculo para impuestos internos desde porcentaje con código '{0}' no implementado.", origenPorcImpInt.ToString()))
   End Sub

End Class