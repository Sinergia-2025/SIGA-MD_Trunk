Option Strict On
Option Explicit On
Namespace Ayudante.DigitosVerificadores
   Public Class DVSIRPLUS
      Implements ICalculoDigitosVerificadores

      Dim digitoVerificador As Integer = 0

      Public Function Calcular(valorACalcular As String) As String Implements ICalculoDigitosVerificadores.Calcular
         Dim acumulador As Integer = 0
         Dim cadena As String = "1,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5,7,9,3,5"
         Dim Secuencia As String() = cadena.Split(","c)
         Dim i As Integer = 0

         For Each caracter As String In valorACalcular
            acumulador += Integer.Parse(Secuencia(i).ToString()) * Integer.Parse(caracter.ToString())
            i += 1
         Next

         '# Obtengo el Dígito Verificador
         digitoVerificador = CalcularDigito(acumulador)

         ' # ACTUALIZO LA CADENA
         Return String.Concat(valorACalcular, digitoVerificador.ToString())
      End Function

      Private Function CalcularDigito(ByRef producto As Integer) As Integer
         Return Convert.ToInt32(Math.Truncate(producto / 2) Mod 10)
      End Function

   End Class
End Namespace