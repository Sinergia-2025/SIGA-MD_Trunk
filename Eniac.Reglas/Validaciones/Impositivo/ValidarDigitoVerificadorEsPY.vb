Option Strict On
Option Explicit On
Namespace Validaciones.Impositivo
   Public Class ValidarDigitoVerificadorEsPY
      Implements IValidarDigitoVerificador
      Public Function Validar(datos As String) As ValidacionResult Implements IValidacion(Of String).Validar
         If Not IsNumeric(datos) Then
            Return New ValidacionResult() With {.Error = True, .MensajeError = "El RUC debe contener solo números"}
         End If
         If datos.Length < 2 Then
            Return New ValidacionResult() With {.Error = True, .MensajeError = "RUC inválido"}
         End If

         Dim acumulado As Integer = 0
         Dim multiplicador As Integer = 2
         For i As Integer = datos.Length - 2 To 0 Step -1
            Dim numero As Short = Short.Parse(datos(i))
            acumulado += numero * multiplicador
            multiplicador += 1
            'If multiplicador > 7 Then multiplicador = 2
         Next

         Dim digitoCalculado As Integer = 11 - (acumulado Mod 11)
         If digitoCalculado > 9 Then digitoCalculado = 0
         If Integer.Parse(datos(datos.Length - 1)) = digitoCalculado Then
            Return New ValidacionResult() With {.Error = False}
         Else
            Return New ValidacionResult() With {.Error = True, .MensajeError = "El dígito verificador es inválido."}
         End If
      End Function
   End Class
End Namespace