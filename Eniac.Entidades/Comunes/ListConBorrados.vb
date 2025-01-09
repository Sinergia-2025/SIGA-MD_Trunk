Public Class ListConBorrados(Of T)
   Inherits List(Of T)

   Public Sub New()
      Borrados = New List(Of T)()
   End Sub

   Public Sub New(lista As IEnumerable(Of T))
      Me.New()
      AddRange(lista)
   End Sub

   Public Property Borrados As List(Of T)

   Public Shadows Function Remove(item As T) As Boolean
      Borrados.Add(item)
      Return MyBase.Remove(item)
   End Function
   Public Shadows Sub Clear()
      While Any()
         Remove(Me(0))
      End While
   End Sub

   Public Shadows Function Add(item As T) As Boolean
      MyBase.Add(item)
      Return Borrados.Remove(item)
   End Function

End Class
Public Class ListConBorrados
   Public Shared Function From(Of T)(lista As IEnumerable(Of T)) As ListConBorrados(Of T)
      Return New ListConBorrados(Of T)(lista)
   End Function

End Class