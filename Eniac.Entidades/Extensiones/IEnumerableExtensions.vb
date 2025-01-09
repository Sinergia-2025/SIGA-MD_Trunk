Namespace Extensiones
   Public Module IEnumerableExtensions
      <Extension>
      Public Function JoinParaIn(Of T)(datos As IEnumerable(Of T)) As String
         Return datos.JoinParaIn(Function(x) x.ToString())
      End Function
      <Extension>
      Public Function JoinParaIn(Of T)(datos As IEnumerable(Of T), stringConverter As Func(Of T, String)) As String
         Return String.Join(",", datos.ToList().ConvertAll(Function(x) String.Format("'{0}'", stringConverter(x))))
      End Function
      <Extension>
      Public Function CountSecure(Of T)(datos As IEnumerable(Of T)) As Integer
         If datos IsNot Nothing Then
            Return datos.Count()
         End If
         Return 0I
      End Function
      '<Extension>
      'Public Function AnySecure(Of T)(datos As IEnumerable(Of T)) As Boolean
      '   If datos IsNot Nothing Then
      '      Return datos.Any()
      '   End If
      '   Return False
      'End Function
      <Extension>
      Public Function FirstOrDefaultSecure(Of T)(datos As IEnumerable(Of T)) As T
         Return If(datos.AnySecure(), datos.FirstOrDefault(), Nothing)
      End Function
      <Extension>
      Public Function FirstOrDefaultSecure(Of T)(datos As IEnumerable(Of T), predicate As Func(Of T, Boolean)) As T
         Return If(datos.AnySecure(), datos.FirstOrDefault(predicate), Nothing)
      End Function
      <Extension>
      Public Sub RemoveRange(Of T)(datos As ICollection(Of T), range As IEnumerable(Of T))
         range.ForEachSecure(Sub(e) datos.Remove(e))
      End Sub

   End Module
End Namespace