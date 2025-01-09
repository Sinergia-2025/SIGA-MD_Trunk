Namespace Extensiones
   Public Module NumericExtensions
      <Extension()>
      Public Function MismoSigno(base As Decimal, valor As Decimal) As Boolean
         Return base / Math.Abs(base) = valor / Math.Abs(valor)
      End Function
      <Extension()>
      Public Function MismoSigno(base As Long, valor As Long) As Boolean
         Return MismoSigno(Convert.ToDecimal(base), Convert.ToDecimal(valor))
      End Function
      <Extension()>
      Public Function MismoSigno(base As Integer, valor As Integer) As Boolean
         Return MismoSigno(Convert.ToDecimal(base), Convert.ToDecimal(valor))
      End Function
      <Extension()>
      Public Function MismoSigno(base As Short, valor As Short) As Boolean
         Return MismoSigno(Convert.ToDecimal(base), Convert.ToDecimal(valor))
      End Function

      <Extension()>
      Public Function TupleRangeToList(rango As Tuple(Of Long, Long)) As List(Of Long)
         Dim result = New List(Of Long)()
         For i = rango.Item1 To rango.Item2
            result.Add(i)
         Next
         Return result
      End Function
   End Module
End Namespace