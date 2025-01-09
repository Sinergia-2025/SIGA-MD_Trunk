Namespace Extensiones
   Public Module LongExtensions
      <Extension>
      Public Function IfNull(valor As Long?) As Long
         Return valor.IfNull(0)
      End Function
      <Extension>
      Public Function IfNull(valor As Long?, valueIfNull As Long) As Long
         If valor.HasValue Then
            Return valor.Value
         End If
         Return valueIfNull
      End Function

      <Extension>
      Public Function ToShort(valor As Long) As Short
         Return Convert.ToInt16(valor)
      End Function
      <Extension>
      Public Function ToInteger(valor As Long) As Integer
         Return Convert.ToInt32(valor)
      End Function

   End Module
End Namespace