Namespace Extensiones
   Public Module StringBuilderExtensions
      <Extension()>
      Public Function AppendFormatLine(stb As StringBuilder, format As String, ParamArray args() As Object) As StringBuilder
         stb.AppendFormat(format, args).AppendLine()
         Return stb
      End Function

   End Module
End Namespace