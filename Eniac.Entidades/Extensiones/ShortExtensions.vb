Namespace Extensiones
   Public Module ShortExtensions
      <Extension>
      Public Function IfNull(valor As Short?) As Short
         Return valor.IfNull(0)
      End Function
      <Extension>
      Public Function IfNull(valor As Short?, valueIfNull As Short) As Short
         If valor.HasValue Then
            Return valor.Value
         End If
         Return valueIfNull
      End Function

   End Module
End Namespace