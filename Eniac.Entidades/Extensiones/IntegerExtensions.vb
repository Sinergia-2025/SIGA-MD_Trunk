Namespace Extensiones
   Public Module IntegerExtensions
      <Extension>
      Public Function IfNull(valor As Decimal?) As Decimal
         Return valor.IfNull(0)
      End Function
      <Extension>
      Public Function IfNull(valor As Decimal?, valueIfNull As Decimal) As Decimal
         Return valor.IfNull(Function() valueIfNull)
      End Function
      <Extension>
      Public Function IfNull(valor As Decimal?, valueIfNull As Func(Of Decimal)) As Decimal
         If valor.HasValue Then
            Return valor.Value
         End If
         Return valueIfNull()
      End Function

      <Extension>
      Public Function ToShort(valor As Integer) As Short
         Return Convert.ToInt16(valor)
      End Function

      <Extension>
      Public Function ToArgbColor(valor As Integer?) As Drawing.Color
         If valor.HasValue Then
            Return Drawing.Color.FromArgb(valor.Value)
         Else
            Return Nothing
         End If
      End Function

      Public Function CompraraRangosEnteros(valorDesdeNuevo As Integer, valorHastaNuevo As Integer, valorDesdeExistente As Integer, valorHastaExistente As Integer) As Boolean
         Return (valorDesdeNuevo >= valorDesdeExistente And valorHastaNuevo <= valorHastaExistente) Or
                (valorDesdeNuevo <= valorDesdeExistente And valorHastaNuevo >= valorDesdeExistente) Or
                (valorDesdeNuevo <= valorHastaExistente And valorHastaNuevo >= valorHastaExistente)
      End Function

   End Module
End Namespace