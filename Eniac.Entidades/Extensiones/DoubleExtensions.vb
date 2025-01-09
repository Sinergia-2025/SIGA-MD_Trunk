Imports System.Runtime.CompilerServices
Namespace Extensiones
   Public Module DoubleExtensions
      <Extension()>
      Public Function ToInteger(valor As Double) As Integer
         Return Convert.ToInt32(valor.Truncar())
      End Function
      <Extension()>
      Public Function ToDecimal(valor As Double) As Decimal
         Return Convert.ToDecimal(valor)
      End Function
      <Extension()>
      Public Function Truncar(valor As Double) As Double
         Return Math.Truncate(valor)
      End Function
      <Extension>
      Public Function IfNull(valor As Double?) As Double
         Return valor.IfNull(0)
      End Function
      <Extension>
      Public Function IfNull(valor As Double?, valueIfNull As Double) As Double
         If valor.HasValue Then
            Return valor.Value
         End If
         Return valueIfNull
      End Function
   End Module
End Namespace