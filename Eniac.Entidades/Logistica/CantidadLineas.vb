Public Class CantidadLineas
   Private _cantMaxItems As Integer
   Public Property CantMaxItems() As Integer
      Get
         Return _cantMaxItems
      End Get
      Set(ByVal value As Integer)
         _cantMaxItems = value
      End Set
   End Property
   Private _cantMaxItemsObserv As Integer
   Public Property CantMaxItemsObserv() As Integer
      Get
         Return _cantMaxItemsObserv
      End Get
      Set(ByVal value As Integer)
         _cantMaxItemsObserv = value
      End Set
   End Property
   Private _imprime As Boolean
   Public Property Imprime() As Boolean
      Get
         Return _imprime
      End Get
      Set(ByVal value As Boolean)
         _imprime = value
      End Set
   End Property

   Public Sub New()
      CantMaxItems = 0
      CantMaxItemsObserv = 0
      Imprime = False
   End Sub
End Class
