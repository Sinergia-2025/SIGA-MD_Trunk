Option Strict On
Option Explicit On
Namespace Validaciones.Impositivo
   Public Class ValidarIdFiscalEsPY
      Implements IValidarIdFiscal
      Public Function Validar(datos As DatosValidacionFiscal) As ValidacionResult Implements IValidacion(Of DatosValidacionFiscal).Validar

         If datos.SolicitaCUIT Then
            If datos.IdFiscal.Trim().Length = 0 Then
               Return New Validaciones.ValidacionResult() With {.Error = True, .MensajeError = "Debe ingresar un RUC para este tipo de Categoria Fiscal."}
            End If
         End If

         If Not String.IsNullOrWhiteSpace(datos.IdFiscal) Then
            '   If datos.IdFiscal.Length <> 11 Then
            '      Return New Validaciones.ValidacionResult() With {.Error = True,
            '                                                       .MensajeError = String.Format("El número de CUIT ingresado es inválido, deben ser 11 caracteres y posee {0}.",
            '                                                                                     datos.IdFiscal.Length.ToString())}
            '   End If
            If Validaciones.Impositivo.ValidarDigitoVerificador.Instancia.Validar(datos.IdFiscal).Error Then
               Return New Validaciones.ValidacionResult() With {.Error = True, .MensajeError = "El número de RUC ingresado es inválido."}
            End If
         End If

         Return New ValidacionResult()
      End Function
   End Class
End Namespace