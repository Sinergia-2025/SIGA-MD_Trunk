Namespace Extensiones
   Public Enum MidRoundBehaviour
      Round
      Ceiling
      Floor
   End Enum
   Partial Module DoubleExtensions
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
      Public Function MidRound(valor As Double, enteros As UInteger, decimales As UInteger) As Double
         Return valor.MidRound(enteros, decimales, base:=5)
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
      Public Function MidRound(valor As Double, enteros As UInteger, decimales As UInteger, base As UShort) As Double
         Return MidRound(valor, enteros, decimales, base, MidRoundBehaviour.Round)
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
      Public Function MidRound(valor As Double, enteros As UInteger, decimales As UInteger, base As UShort, behaviour As MidRoundBehaviour) As Double
         'Verifico que la base no sea menor a 1 ya que una base 0 no permite un correcto calculo.
         If base < 1 Then
            Throw New Exception(String.Format("La base no puede ser menor a 1 (base: {0}).", base))
         End If
         'Verifico que la base no sea mayor a 10. No se verificó su funcionamiento con bases superiores.
         If base > 10 Then
            Throw New Exception(String.Format("La base no puede ser mayor a 10 (base: {0}).", base))
         End If
         'No es posible aplicar redondeo por enteros y decimales al mismo tiempo. Se anularian entre ellos.
         If decimales > 0 AndAlso enteros > 0 Then
            Throw New Exception(String.Format("No es posible redondear por decimales y enteros al mismo tiempo. (enteros: {0}, decimales: {1})", enteros, decimales))
         End If

         'Si se aplica redondeo por decimales, debo correr el separador decimal hacia la derecha la cantidad de decimales indicada.
         'Para ello multipilico el valor por 10^decimales (10 a la cantidad de decimales).
         'Ejemplo A:                                     Ejemplo B:
         '     valor = 120.25378                            valor = 345678.123
         '     enteros = 0                                  enteros = 3
         '     decimales = 3                                decimales = 0
         '     base = 10                                    base = 10
         '     nuevo valor = 120.25378 * (10 ^ 3)           nuevo valor = 345678.123 * (10 ^ (0 - 1))
         '                 = 120253.78                                  = 345678.123
         valor = valor * (10 ^ decimales)

         'Si se aplica redondeo por entero, debo correr el separador decimal hacia la izquierda la cantidad de enteros indicada menos 1.
         'Para ello divido el valor por 10^decimales (10 a la cantidad de enteros). Le debo quitar 1 a la cantidad porque si quiero una parte entera, en realidad no hay que mover nada.
         'Ejemplo A:                                     Ejemplo B:
         '     nuevo valor = 120253.78 * (10 ^ (0 - 1))     nuevo valor = 345678.123 * (10 ^ (3 - 1))
         '                 = 1202537.8                                  = 3456.78123
         valor = valor / (10 ^ (enteros - 1))

         Dim m As Long  'Esta variable la uso solo para que DivRem devuelva la división entera ya que es requerido en el método.

         'divParaCalculo se usa para determinar luego cuales son los valores mínimos y máximos para redondear.
         'Se determina obteniendo la división entera del valor suministrado dividido la base de redondeo.
         'Ejemplo A:                                     Ejemplo B:
         '     divParaCalculo = 1202537 / 10                divParaCalculo = 3457 / 10
         '                    = 120253                                     = 345
         Dim divParaCalculo = Math.DivRem(Convert.ToInt64(valor), base, m)

         'Valor menor calculado para calculo tomando en cuenta la división entera y la base de calculo.
         'Ejemplo A:                                     Ejemplo B:
         '     menor = 120253 * 10                          menor = 345 * 10
         '           = 1202530                                    = 3450
         Dim menor = divParaCalculo * base

         'Valor mayor calculado para calculo sumandole 1 unidad a la división entera y la base de calculo.
         'Ejemplo A:                                     Ejemplo B:
         '     menor = (120253 + 1) * 10                    mayor = (345 + 1) * 10
         '           = 1202540                                    = 3460
         Dim mayor = (divParaCalculo + 1) * base

         'El valor medio es el valor con el cual determino si debo ir para arriba o para abajo en el calculo del nuevo valor.
         'Se calculo dividiendo por dos la diferencia entre el menor y mayor y sumando el resultado de la división al menor valor.
         'Ejemplo A:                                     Ejemplo B:
         '     menor = 1202530 + ((1202540 - 1202530) /2)   medio = 3450 ((3460 - 3450) /2)
         '           = 1202535                                    = 3455
         Dim medio = menor + ((mayor - menor) / 2)

         'Dependiendo del Behaviour seleccionado
         'Si Round:
         '     Si el valor es MAYOR al medio, debo redondear para arriba, si es MENOR debo redondear para abajo.
         '     Ejemplo A:                                     Ejemplo B:
         '          valor = If(valor > medio, mayor, menor)            valor = If(valor > medio, mayor, menor)
         '     		      = If(1202537.8 >= 1202535, 1202540, 1202530)      = If(3456.78123 >= 3455, 3460, 3450)
         '                = 1202540                                          = 3460
         'Si Ceiling:
         '     Si el valor es IGUAL al menor tomo el menor, pero si difiere debo redondear para arriba tomando el mayor.
         '     Ejemplo A:                                     Ejemplo B:
         '          valor = If(valor = menor, menor, mayor)            valor = If(valor = menor, menor, mayor)
         '                = If(1202537.8 = 1202530, 1202530, 1202540)        = If(3456.78123 = 3450, 3450, 3460)
         '                = 1202540                                          = 3460
         'Si Floor:
         '     Si el valor es IGUAL al mayor tomo el mayor, pero si difiere debo redondear para abajo tomando el menor.
         '     Ejemplo A:                                     Ejemplo B:
         '          valor = If(valor = mayor, mayor, menor)            valor = If(valor = mayor, mayor, menor)
         '                = If(1202537.8 = 1202540, 1202540, 1202530)        = If(3456.78123 = 3460, 3460, 3450)
         '                = 1202530                                          = 3450
         Select Case behaviour
            Case MidRoundBehaviour.Round
               valor = If(valor >= medio, mayor, menor)

            Case MidRoundBehaviour.Ceiling
               valor = If(valor = menor, menor, mayor)

            Case MidRoundBehaviour.Floor
               valor = If(valor = mayor, mayor, menor)

            Case Else
               Throw New Exception(String.Format("Invalid Behaviour {0}", behaviour))
         End Select

         'Vuelvo a mover el separador decimal a la izquierda si se aplica redondeo por decimales.
         'Para ello divido el valor por 10^decimales (10 a la cantidad de decimales).
         'Ejemplo A:                                     Ejemplo B:
         '     valor = 1202540 / (10 ^ 3)                   nuevo valor = 3460 / (10 ^ (0 - 1))
         '           = 1202.54                                          = 3460
         valor = valor / (10 ^ decimales)

         'Vuelvo a mover el separador decimal a la derecha si se aplica redondeo por enteros.
         'Para ello multiplico el valor por 10^decimales (10 a la cantidad de enteros). Le debo quitar 1 a la cantidad porque si quiero una parte entera, en realidad no hay que mover nada.
         'Ejemplo A:                                     Ejemplo B:
         '     valor = 1202.54 * (10 ^ (0 - 1))             nuevo valor = 3460 * (10 ^ (3 - 1))
         '           = 120.254                                          = 346000
         valor = valor * (10 ^ (enteros - 1))

         Return valor
      End Function
   End Module
End Namespace