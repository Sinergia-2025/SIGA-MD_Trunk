Namespace Extensiones
   Partial Module DecimalExtensions
      ''' <summary>
      ''' Extensión para calculo de redondeos parciales tomando 5 como base por defecto.
      ''' </summary>
      ''' <param name="valor">Valor a redondear</param>
      ''' <param name="enteros">Cantidad de enteros sobre las que redondear</param>
      ''' <param name="decimales">Cantidad de decimales sobre los que redondear</param>
      ''' <returns>Permite el calculo de redondeo en diferentes bases.</returns>
      ''' <example>
      '''   Si la base es 5 con 1 entero redondeará:
      '''      5, 10, 15, 20, 25, etc.
      '''   Si la base es 5 con 2 enteros redondeará:
      '''      50, 100, 150, 200, 250, etc.
      ''' </example>
      <Extension()>
      Public Function MidRound(valor As Decimal, enteros As UInteger, decimales As UInteger) As Decimal
         Return Convert.ToDecimal(Convert.ToDouble(valor).MidRound(enteros, decimales))
      End Function

      ''' <summary>
      ''' Extensión para calculo de redondeos parciales.
      ''' </summary>
      ''' <param name="valor">Valor a redondear</param>
      ''' <param name="enteros">Cantidad de enteros sobre las que redondear</param>
      ''' <param name="decimales">Cantidad de decimales sobre los que redondear</param>
      ''' <param name="base">Base de calculo de reondeo.</param>
      ''' <returns>Permite el calculo de redondeo en diferentes bases.</returns>
      ''' <example>
      '''   Si la base es 10 con 2 enteros redondeará:
      '''      10, 20, 30, 40, 50, etc.
      '''   Si la base es 5 con 1 entero redondeará:
      '''      5, 10, 15, 20, 25, etc.
      '''   Si la base es 3 con 3 enteros redondeará:
      '''      300, 600, 900, 1200, etc.
      ''' </example>
      <Extension()>
      Public Function MidRound(valor As Decimal, enteros As UInteger, decimales As UInteger, base As UShort) As Decimal
         Return Convert.ToDecimal(Convert.ToDouble(valor).MidRound(enteros, decimales, base))
      End Function
      <Extension()>
      Public Function MidRound(valor As Decimal, enteros As UInteger, decimales As UInteger, base As UShort, behaviour As MidRoundBehaviour) As Decimal
         Return Convert.ToDecimal(Convert.ToDouble(valor).MidRound(enteros, decimales, base, behaviour))
      End Function

   End Module
End Namespace