Namespace Extensiones
   Public Module BooleanExtensions
      <Extension>
      Public Function IfNull(valor As Boolean?) As Boolean
         Return valor.IfNull(False)
      End Function
      <Extension>
      Public Function IfNull(valor As Boolean?, valueIfNull As Boolean) As Boolean
         If valor.HasValue Then
            Return valor.Value
         End If
         Return valueIfNull
      End Function

      <Extension>
      Public Function ToStringEspañol(valor As Boolean) As String
         Return ToString(valor, "SI", "NO", String.Empty)
      End Function
      <Extension>
      Public Function ToString(valor As Boolean, trueString As String, falseString As String) As String
         Return ToString(valor, trueString, falseString, String.Empty)
      End Function
      <Extension>
      Public Function ToString(valor As Boolean?, trueString As String, falseString As String, nullString As String) As String
         Return If(valor.HasValue, If(valor.Value, trueString, falseString), nullString)
      End Function

   End Module
End Namespace