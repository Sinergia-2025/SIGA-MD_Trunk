Namespace Banco.DebitosDirectos
   Public Class SIRPLUS

#Region "Públicos"
      Public Shared Function ArmarCodigoBarras(
                                 identificacionDeUsuario As Long,
                                 identificadorDeConcepto As Integer,
                                 fechaVenc1 As Date?,
                                 importeVenc1 As Decimal?,
                                 fechaVenc2 As Date?,
                                 importeVenc2 As Decimal?,
                                 fechaVenc3 As Date?,
                                 importeVenc3 As Decimal?,
                                 identificadorCuenta As Long) As String
         If fechaVenc1.HasValue AndAlso fechaVenc2.HasValue AndAlso fechaVenc2.Value <= fechaVenc1.Value Then
            Throw New ArgumentException("La segunda fecha de vencimiento debe ser posterior a la primera")
         End If
         If fechaVenc2.HasValue AndAlso fechaVenc3.HasValue AndAlso fechaVenc3.Value <= fechaVenc2.Value Then
            Throw New ArgumentException("La tercer fecha de vencimiento debe ser posterior a la segunda")
         End If
         Return ArmarCodigoBarras(identificacionDeUsuario,
                                  identificadorDeConcepto,
                                  fechaVenc1,
                                  importeVenc1,
                                  If(fechaVenc1.HasValue AndAlso fechaVenc2.HasValue, Convert.ToInt32(fechaVenc2.Value.Subtract(fechaVenc1.Value).TotalDays), 0),
                                  importeVenc2,
                                  If(fechaVenc2.HasValue AndAlso fechaVenc3.HasValue, Convert.ToInt32(fechaVenc3.Value.Subtract(fechaVenc1.Value).TotalDays), 0),
                                  importeVenc3,
                                  identificadorCuenta)
      End Function


      Public Shared Function ArmarCodigoBarras(
                                 identificacionDeUsuario As Long,
                                 identificadorDeConcepto As Integer,
                                 fechaVenc1 As Date?,
                                 importeVenc1 As Decimal?,
                                 diasHastaVenc2 As Integer?,
                                 importeVenc2 As Decimal?,
                                 diasHastaVenc3 As Integer?,
                                 importeVenc3 As Decimal?,
                                 identificadorCuenta As Long) As String

         ' Verificar las longitudes de los parámetros
         If identificacionDeUsuario.ToString().Length > 12 Then
            'Throw New ArgumentException("La Identificación de Usuario debe tener como máximo 8 dígitos.")
            Throw New ArgumentException("El código del cliente debería tener como máximo 8 dígitos.")
         End If

         If Not identificacionDeUsuario > 0 Then
            Throw New ArgumentException("La Identificación de Usuario no es válida.")
         End If

         If identificadorDeConcepto.ToString().Length > 1 Then
            Throw New ArgumentException("La Identificación de Concepto debe tener como máximo 1 dígito.")
         End If

         If identificadorDeConcepto < 1 OrElse identificadorDeConcepto > 4 Then
            Throw New ArgumentException("La Identificación de Concepto debe estar comprendido entre 1 y 4.")
         End If


         'Const empresaDeServicio As String = "0447" ' Otorgado por SIRO. Longitud 4. NO VARIA.

         ' # Armado del string para obtener los dígitos verificadores
         Dim identificadorDeUsuario As String = identificacionDeUsuario.ToString("000000000000")

         ' #############################################################################################################################
         ' # Si no se utiliza algunos de los vencimientos (ni sus importes), se debe completar el total de la longitud del campo con 0 #
         ' #############################################################################################################################

         Dim fechaVencimiento1 As String = If(fechaVenc1.HasValue, fechaVenc1.Value.ToString("yyMMdd"), "000000")
         Dim importeVencimiento1 As String = If(importeVenc1.HasValue, importeVenc1.Value, 0).ToString("00000000.00").Replace(".", "").Replace(",", "")
         Dim diasHastaVencimiento2 As String = diasHastaVenc2.Value.ToString("00")
         Dim importeVencimiento2 As String = If(importeVenc2.HasValue, importeVenc2.Value - importeVenc1.Value, 0).ToString("000000.00").Replace(".", "").Replace(",", "")
         Dim diasHastaVencimiento3 As String = diasHastaVenc3.Value.ToString("00")
         Dim importeVencimiento3 As String = If(importeVenc3.HasValue, importeVenc3.Value - importeVenc1.Value, 0).ToString("000000.00").Replace(".", "").Replace(",", "")


         Dim _identificadorDeCuenta As String = identificadorCuenta.ToString("0000") ' Otorgado por ROELA. Longitud 10. NO VARIA.
         Dim tipoDeRecaudacion As String = "004"
         Dim CodigoServicioSCR As String = "0500"
         ' # Concantenación de Todos los Valores
         Dim temp As String = String.Concat(tipoDeRecaudacion,
                                            CodigoServicioSCR,
                                            _identificadorDeCuenta,
                                            identificadorDeUsuario,
                                            fechaVencimiento1,
                                            importeVencimiento1,
                                            diasHastaVencimiento2,
                                            importeVencimiento2,
                                            diasHastaVencimiento3,
                                            importeVencimiento3)

         Dim rDigitoVerificador As Ayudante.DigitosVerificadores.DVSIRPLUS = New Ayudante.DigitosVerificadores.DVSIRPLUS()
         Return rDigitoVerificador.Calcular(temp)

      End Function

#End Region

#Region "Privados"

#End Region

   End Class
End Namespace