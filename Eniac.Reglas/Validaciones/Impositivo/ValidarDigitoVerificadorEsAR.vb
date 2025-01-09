Option Strict On
Option Explicit On
Namespace Validaciones.Impositivo
   Public Class ValidarDigitoVerificadorEsAR
      Implements IValidarDigitoVerificador
      Public Function Validar(datos As String) As ValidacionResult Implements IValidacion(Of String).Validar
         Dim decCoeficiente As Decimal = 0
         Dim arrCUIT(0 To 10) As Integer
         Dim cont As Integer
         If Len(datos) < 11 Then
            Return New ValidacionResult() With {.Error = True, .MensajeError = "El CUIT debe contener 11 números"}
         End If
         For cont = 0 To 10
            If Not IsNumeric(datos.Substring(cont, 1)) Then
               Return New ValidacionResult() With {.Error = True, .MensajeError = "El CUIT debe contener solo números"}
            End If
         Next
         arrCUIT(0) = Integer.Parse(datos.Substring(0, 1))
         arrCUIT(1) = Integer.Parse(datos.Substring(1, 1))
         arrCUIT(2) = Integer.Parse(datos.Substring(2, 1))
         arrCUIT(3) = Integer.Parse(datos.Substring(3, 1))
         arrCUIT(4) = Integer.Parse(datos.Substring(4, 1))
         arrCUIT(5) = Integer.Parse(datos.Substring(5, 1))
         arrCUIT(6) = Integer.Parse(datos.Substring(6, 1))
         arrCUIT(7) = Integer.Parse(datos.Substring(7, 1))
         arrCUIT(8) = Integer.Parse(datos.Substring(8, 1))
         arrCUIT(9) = Integer.Parse(datos.Substring(9, 1))
         arrCUIT(10) = Integer.Parse(datos.Substring(10, 1))

         'EL NUMERO QUE LO MULTIPLICA ES "54327654321"
         decCoeficiente = (arrCUIT(0) * 5) + (arrCUIT(1) * 4) + (arrCUIT(2) * 3) + (arrCUIT(3) * 2) + (arrCUIT(4) * 7) + (arrCUIT(5) * 6)
         decCoeficiente = decCoeficiente + (arrCUIT(6) * 5) + (arrCUIT(7) * 4) + (arrCUIT(8) * 3) + (arrCUIT(9) * 2) + (arrCUIT(10) * 1)

         decCoeficiente = decCoeficiente / 11

         If decCoeficiente = Int(decCoeficiente) Then
            Return New ValidacionResult() With {.Error = False}
         Else
            Return New ValidacionResult() With {.Error = True, .MensajeError = "El dígito verificador es inválido."}
         End If
      End Function
   End Class
End Namespace