Namespace Extensiones
   Public Module ICollectionExtensions
      <Extension>
      Public Function AddRange(Of T)(datos As ICollection(Of T), range As IEnumerable(Of T)) As ICollection(Of T)
         range.ForEachSecure(Sub(d) datos.Add(d))
         Return datos
      End Function
   End Module
End Namespace