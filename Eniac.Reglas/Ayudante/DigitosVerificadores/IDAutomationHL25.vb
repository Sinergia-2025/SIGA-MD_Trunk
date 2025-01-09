Option Strict On
Option Explicit On
Namespace Ayudante.DigitosVerificadores
   Public Class IDAutomationHL25
      Implements ICalculoDigitosVerificadores

      Dim digitoVerificador1 As Integer = 0
      Dim digitoVerificador2 As Integer = 0

      Public Function Calcular(valorACalcular As String) As String Implements ICalculoDigitosVerificadores.Calcular
         Dim acumulador As Integer = 0
         Dim primerDigito As Boolean = True
         Dim lenght As Integer = valorACalcular.Length
         Dim coeficiente As Integer = 3 '# 1 Es el primer valor que toma el coeficiente

         ' # PRIMERA PARTE # '
         ' 
         For Each caracter As String In valorACalcular

            If primerDigito Then
               acumulador = Integer.Parse(caracter)

               primerDigito = False

            Else

               '# Voy acumulando el resultado del producto entre el dígito sobre el que estoy parado y el coeficiente actual
               acumulador += Integer.Parse(caracter) * coeficiente

               '# Actualizo el valor del Coeficiente
               AcumulaCoeficiente(coeficiente)

            End If
         Next

         ' # SEGUNDA PARTE - CALCULO DE LOS DOS DÍGITOS VERIFICADORES# '

         '# Obtengo el Primer Dígito Verificador
         digitoVerificador1 = CalcularDigito(acumulador)
         '# Se lo sumo al acumulador
         acumulador += digitoVerificador1 * coeficiente
         '# Obtengo el Segundo Dígito Verificador
         digitoVerificador2 = CalcularDigito(acumulador)

         ' # ACTUALIZO LA CADENA
         Return String.Concat(valorACalcular, digitoVerificador1.ToString(), digitoVerificador2.ToString())
      End Function

      Private Sub AcumulaCoeficiente(ByRef coeficiente As Integer)
         coeficiente += 2

         '# Si el coeficiente es mayor a 9, se resetea a 3 para respetar la secuencia (...3,5,7,9,3,5,7,9...)
         If coeficiente > 9 Then
            coeficiente = 3
         End If
      End Sub

      Private Function CalcularDigito(ByRef producto As Integer) As Integer
         'Return Integer.Parse((Math.Truncate(producto / 2) Mod 10).ToString())
         Return Convert.ToInt32(Math.Truncate(producto / 2) Mod 10)
      End Function
   End Class
End Namespace