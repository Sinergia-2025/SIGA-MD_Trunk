Namespace Extensiones
   Public Module StringExtensions
      ''' <summary>
      ''' Trunca la longitud de una cadena de caracteres a un máximo suminstrado.
      ''' </summary>
      ''' <param name="value">String a truncar</param>
      ''' <param name="maxLength">Máximo de caracteres</param>
      ''' <returns>Cadena de caracteres truncada al ancho suministrado.</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function Truncar(value As String, maxLength As Integer) As String
         If String.IsNullOrWhiteSpace(value) Then Return String.Empty
         Return value.Substring(0, Math.Min(value.Length, maxLength)).Trim()
      End Function

      <Extension()>
      Public Function IfNull(value As String) As String
         Return value.IfNull(String.Empty)
      End Function
      <Extension()>
      Public Function IfNull(value As String, valorParaNull As String) As String
         If value Is Nothing Then Return valorParaNull
         Return value
      End Function


      <Extension()>
      Public Function DivideEnPartes(s As String, partLength As Integer) As String()
         If String.IsNullOrEmpty(s) Then
            Throw New ArgumentNullException("String cannot be null or empty.")
         End If
         If partLength <= 0 Then
            Throw New ArgumentException("Split length has to be positive.")
         End If
         Return Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(s.Length / partLength))).Select(Function(i) s.Substring(i * partLength, If(s.Length - (i * partLength) >= partLength, partLength, Math.Abs(s.Length - (i * partLength))))).ToArray()
      End Function

      <Extension()>
      Public Function PrimerLetraMayuscula(texto As String) As String
         ' Test for nothing or empty.
         If String.IsNullOrEmpty(texto) Then
            Return texto
         End If
         ' Convert to character array.
         Dim array() As Char = texto.ToCharArray
         ' Uppercase first character.
         array(0) = Char.ToUpper(array(0))
         ' Return new string.
         Return New String(array)
      End Function

      <Extension()>
      Public Function DejarSoloNumeros(texto As String) As String
         Return texto.DejarSoloNumeros({"-"c, "."c})
      End Function

      <Extension()>
      Public Function DejarSoloNumeros(texto As String, otrosCaracteresValidos As Char()) As String
         Return texto.DejarSoloNumeros({"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c}, otrosCaracteresValidos)
      End Function
      <Extension()>
      Public Function DejarSoloNumeros(texto As String, caracteresValidos As Char(), otrosCaracteresValidos As Char()) As String
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
         For Each car As Char In texto
            If caracteresValidos.Contains(car) Or otrosCaracteresValidos.Contains(car) Then
               stb.Append(car)
            End If
         Next
         Return stb.ToString()
      End Function

      <Extension()>
      Public Function ValorNumericoPorDefecto(Of T)(valor As String, porDefecto As T) As T
         Return ObjectExtensions.ValorNumericoPorDefecto(valor, porDefecto)
      End Function

      <Extension>
      Public Function StringToEnum(Of T)(valor As String, valorPorDefecto As T) As T
         Try
            Dim obj As Object = [Enum].Parse(GetType(T), valor)
            Return DirectCast(obj, T)
         Catch ex As Exception
            Return valorPorDefecto
         End Try
      End Function

      <Extension>
      Public Function ToDecimal(valor As String) As Decimal?
         If IsNumeric(valor) Then
            Return Decimal.Parse(valor)
         End If
         Return Nothing
      End Function
      <Extension>
      Public Function ToInt32(valor As String) As Integer?
         If IsNumeric(valor) Then
            Return Integer.Parse(valor)
         End If
         Return Nothing
      End Function
      <Extension>
      Public Function ToInt64(valor As String) As Long?
         If IsNumeric(valor) Then
            Return Long.Parse(valor)
         End If
         Return Nothing
      End Function

      <Extension()>
      Public Function ConvertToBase64String(toConvert As String) As String
         Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(toConvert)
         Return System.Convert.ToBase64String(plainTextBytes)
      End Function

      <Extension()> Public Function RodearConComillasParaSql(texto As String) As String
         Return texto.RodearCon("'")
      End Function
      <Extension()> Public Function RodearConComillas(texto As String) As String
         Return texto.RodearCon("""")
      End Function
      <Extension()> Public Function RodearCon(texto As String, extremos As String) As String
         Return texto.RodearCon(extremos, extremos)
      End Function
      <Extension()> Public Function RodearCon(texto As String, prefijo As String, posfijo As String) As String
         Return String.Format("{0}{1}{2}", prefijo, texto, posfijo)
      End Function

      <Extension()> Public Function Replace2(texto As String, reemplazos As IEnumerable(Of ReplaceTuple)) As String
         For Each kv In reemplazos
            If texto.Contains(kv.Item1) Then
               texto = texto.Replace(kv.Item1, kv.Item2.Invoke())
            End If
         Next
         Return texto
      End Function
      Public Class ReplaceTuple
         Inherits Tuple(Of String, Func(Of String))
         Public Sub New(item1 As String, item2 As Func(Of String))
            MyBase.New(item1, item2)
         End Sub
      End Class

   End Module
End Namespace