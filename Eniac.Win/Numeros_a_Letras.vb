Option Strict Off
Public Class Numeros_A_Letras
#Region "Singleton"
   Private Shared _instancia As Numeros_A_Letras = New Numeros_A_Letras()
   ''' <summary>
   ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
   ''' </summary>
   ''' <returns>Instancia del Cache de Parámetros</returns>
   ''' <remarks></remarks>
   Public Shared ReadOnly Property Instancia As Numeros_A_Letras
      Get
         Return _instancia
      End Get
   End Property
   Private Sub New()
   End Sub
#End Region

   Public Enum MonedaEnum
      SinMoneda
      Pesos
      Dolares
   End Enum

   Public Function EnLetras(valor As String, moneda As MonedaEnum, monedaAlFinal As Boolean) As String
      Dim _enLetras As String
      If Not IsNumeric(valor) Then
         Return "¡ La referencia no es valor o... 'excede' la precision !!!"
      End If

      Dim VValor As Decimal
      VValor = Decimal.Parse(valor)
      Dim monedaEnLetras As String = ConvertirMonedaEnLetras(moneda, Math.Truncate(Math.Abs(VValor)))
      'If Int(Abs(VValor)) = 1 Then moneda = " peso" Else moneda = " pesos"
      'If Right(Letras(Abs(VValor)), 6) = "illón " Or Right(Letras(Abs(VValor)), 8) = "illones " Then Moneda = "de" & Moneda

      Dim Fracs As String
      Dim Cents As Integer = Math.Round(Math.Abs(VValor) - Int(Math.Abs(VValor)), 2) * 100
      If Cents = 1 Then Fracs = " centavo" Else Fracs = " centavos"
      If Cents = 0 Then Fracs = "" Else Fracs = " con " & Letras(Cents) & Fracs
      _enLetras = Letras(Int(Math.Abs(VValor))) & If(monedaAlFinal, monedaEnLetras, String.Empty) & Fracs
      If valor < 0 Then EnLetras = "menos " & _enLetras
      If Not monedaAlFinal Then _enLetras = String.Format("{0} {1}", monedaEnLetras.Trim(), _enLetras)
      Return _enLetras
   End Function

   Public Function ConvertirMonedaSiga(idMoneda As Integer) As MonedaEnum
      Select Case idMoneda
         Case 1
            Return MonedaEnum.Pesos
         Case 2
            Return MonedaEnum.Dolares
         Case Else
            Return MonedaEnum.SinMoneda
      End Select
   End Function

#Region "Metodos Privados"
   Private Function ConvertirMonedaEnLetras(moneda As MonedaEnum, valor As Decimal) As String
      If moneda = Numeros_A_Letras.MonedaEnum.Pesos Then
         If valor = 1 Then Return " peso"
         Return " pesos"
      End If
      If moneda = Numeros_A_Letras.MonedaEnum.Dolares Then
         If valor = 1 Then Return " dolar"
         Return " dolares"
      End If
      Return String.Empty
   End Function
   Private Function Letras(ByVal Valor As Object) As String ' Funcion Auxiliar [uso 'exclusivo' de la funcion 'principal'] '
      Select Case Int(Valor)
         Case 0 : Letras = "cero"
         Case 1 : Letras = "un"
         Case 2 : Letras = "dos"
         Case 3 : Letras = "tres"
         Case 4 : Letras = "cuatro"
         Case 5 : Letras = "cinco"
         Case 6 : Letras = "seis"
         Case 7 : Letras = "siete"
         Case 8 : Letras = "ocho"
         Case 9 : Letras = "nueve"
         Case 10 : Letras = "diez"
         Case 11 : Letras = "once"
         Case 12 : Letras = "doce"
         Case 13 : Letras = "trece"
         Case 14 : Letras = "catorce"
         Case 15 : Letras = "quince"
         Case Is < 20 : Letras = "dieci" & Letras(Valor - 10)
         Case 20 : Letras = "veinte"
         Case Is < 30 : Letras = "veinti" & Letras(Valor - 20)
         Case 30 : Letras = "treinta"
         Case 40 : Letras = "cuarenta"
         Case 50 : Letras = "cincuenta"
         Case 60 : Letras = "sesenta"
         Case 70 : Letras = "setenta"
         Case 80 : Letras = "ochenta"
         Case 90 : Letras = "noventa"
         Case Is < 100 : Letras = Letras(Int(Valor \ 10) * 10) & " y " & Letras(Valor Mod 10)
         Case 100 : Letras = "cien"
         Case Is < 200 : Letras = "ciento " & Letras(Valor - 100)
         Case 200, 300, 400, 600, 800 : Letras = Letras(Int(Valor \ 100)) & "cientos"
         Case 500 : Letras = "quinientos"
         Case 700 : Letras = "setecientos"
         Case 900 : Letras = "novecientos"
         Case Is < 1000 : Letras = Letras(Int(Valor \ 100) * 100) & " " & Letras(Valor Mod 100)
         Case 1000 : Letras = "mil"
         Case Is < 2000 : Letras = "mil " & Letras(Valor Mod 1000)
         Case Is < 1000000 : Letras = Letras(Int(Valor \ 1000)) & " mil"
            If Valor Mod 1000 Then Letras = Letras & " " & Letras(Valor Mod 1000)
         Case 1000000 : Letras = "un millón "
         Case Is < 2000000 : Letras = "un millón " & Letras(Valor Mod 1000000)
         Case Is < 1000000000000.0# : Letras = Letras(Int(Valor / 1000000)) & " millones "
            If (Valor - Int(Valor / 1000000) * 1000000) _
            Then Letras = Letras & Letras(Valor - Int(Valor / 1000000) * 1000000)
         Case 1000000000000.0# : Letras = "un billón "
         Case Is < 2000000000000.0#
            Letras = "un billón " & Letras(Valor - Int(Valor / 1000000000000.0#) * 1000000000000.0#)
         Case Else : Letras = Letras(Int(Valor / 1000000000000.0#)) & " billones"
            If (Valor - Int(Valor / 1000000000000.0#) * 1000000000000.0#) _
            Then Letras = Letras & " " & Letras(Valor - Int(Valor / 1000000000000.0#) * 1000000000000.0#)
      End Select
   End Function
#End Region

#Region "Metodos Shared"
   Public Shared Function EnLetras(valor As String) As String
      Return Instancia().EnLetras(valor, MonedaEnum.Pesos, monedaAlFinal:=True)
   End Function
   Public Shared Function EnLetrasSinMoneda(Valor As String) As String
      Return Instancia().EnLetras(Valor, MonedaEnum.SinMoneda, True)
   End Function
#End Region

End Class