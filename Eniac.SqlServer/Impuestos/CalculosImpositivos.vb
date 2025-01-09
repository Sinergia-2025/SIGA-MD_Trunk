Option Strict On
Option Explicit On
''' <summary>
''' Agrupa funciones que devuelven el cálculo que se utilizan cuando se manipulan valores con o sin impuestos en Queries
''' </summary>
''' <remarks></remarks>
Public Class CalculosImpositivos
   Public Shared Function ObtenerPrecioSinImpuestos(tablaCampoPrecioCI As String, aliasTablaProductos As String) As String
      Return ObtenerPrecioSinImpuestos(tablaCampoPrecioCI,
                                       String.Concat(aliasTablaProductos, ".Alicuota"),
                                       String.Concat(aliasTablaProductos, ".PorcImpuestoInterno"),
                                       String.Concat(aliasTablaProductos, ".ImporteImpuestoInterno"),
                                       String.Concat(aliasTablaProductos, ".OrigenPorcImpInt"))

   End Function
   ''' <summary>
   ''' Permite obtener la instrucción SQL que calcula el precio Sin Impuestos desde un precio Con Impuestos.
   ''' </summary>
   ''' <param name="tablaCampoPrecioCI">Nombre de tabla (o su alias) y campo de donde obtener el precio Con Impuestos</param>
   ''' <param name="tablaCampoPorcIVA">Nombre de tabla (o su alias) y campo de donde obtener el porcentaje de IVA (ej: 21%)</param>
   ''' <param name="tablaCampoPorcImpInt">Nombre de tabla (o su alias) y campo de donde obtener el porcentaje de Impuestos Internos (ej: 8%)</param>
   ''' <param name="tablaCampoImpImpInt">Nombre de tabla (o su alias) y campo de donde obtener el importe de Impuestos Internos (cuando tiene valor fijo de ImpInt)</param>
   ''' <returns>String con la instrucción SQL para calcular el precio Sin Impuestos</returns>
   ''' <remarks></remarks>
   Public Shared Function ObtenerPrecioSinImpuestos(tablaCampoPrecioCI As String, tablaCampoPorcIVA As String,
                                                    tablaCampoPorcImpInt As String, tablaCampoImpImpInt As String,
                                                    tablaCampoOrigenPorcImpInt As String) As String
      'tablaCampoPrecioCI = "PSP.PrecioVenta"
      'tablaCampoPorcIVA = "P.Alicuota"
      'tablaCampoPorcImpInt = "P.PorcImpuestoInterno"
      'tablaCampoImpImpInt = "P.ImporteImpuestoInterno"
      tablaCampoPorcIVA = String.Format("({0} / 100)", tablaCampoPorcIVA)
      tablaCampoPorcImpInt = String.Format("({0} / 100)", tablaCampoPorcImpInt)
      Return String.Format("   CASE WHEN {4} = 'BRUTO' THEN ({0} - {3}) * (1 - {2}) / (1 + {1}) ELSE ({0} - {3}) / (1 + {1} + {2}) END",
                           tablaCampoPrecioCI,
                           tablaCampoPorcIVA,
                           tablaCampoPorcImpInt,
                           tablaCampoImpImpInt,
                           tablaCampoOrigenPorcImpInt)
   End Function

   Public Shared Function ObtenerPrecioConImpuestos(tablaCampoPrecioSI As String, aliasTablaProductos As String) As String
      Return ObtenerPrecioConImpuestos(tablaCampoPrecioSI,
                                       String.Concat(aliasTablaProductos, ".Alicuota"),
                                       String.Concat(aliasTablaProductos, ".PorcImpuestoInterno"),
                                       String.Concat(aliasTablaProductos, ".ImporteImpuestoInterno"),
                                       String.Concat(aliasTablaProductos, ".OrigenPorcImpInt"))
   End Function

   Public Shared Function ObtenerPrecioConImpuestos(tablaCampoPrecioSI As String, tablaCampoPorcIVA As String,
                                                    tablaCampoPorcImpInt As String, tablaCampoImpImpInt As String,
                                                    tablaCampoOrigenPorcImpInt As String) As String
      'tablaCampoPrecioCI = "PSP.PrecioVenta"
      'tablaCampoPorcIVA = "P.Alicuota"
      'tablaCampoPorcImpInt = "P.PorcImpuestoInterno"
      'tablaCampoImpImpInt = "P.ImporteImpuestoInterno"
      tablaCampoPorcIVA = String.Format("({0} / 100)", tablaCampoPorcIVA)
      tablaCampoPorcImpInt = String.Format("({0} / 100)", tablaCampoPorcImpInt)
      Return String.Format("   CASE WHEN {4} = 'BRUTO' THEN ({0} * (1 + {1})) * (1 + ({2} / (1 - {2}))) + {3} ELSE ({0} * (1 + {1} + {2})) + {3} END",
                           tablaCampoPrecioSI,
                           tablaCampoPorcIVA,
                           tablaCampoPorcImpInt,
                           tablaCampoImpImpInt,
                           tablaCampoOrigenPorcImpInt)
   End Function

End Class