<Serializable()> _
Public Class PC
   Inherits Entidades.Entidad

   Private _nombrePC As String
   Public Property NombrePC() As String
      Get
         Return _nombrePC
      End Get
      Set(ByVal value As String)
         _nombrePC = value
      End Set
   End Property

   Private _mac As String
   Public Property Mac() As String
      Get
         Return _mac
      End Get
      Set(ByVal value As String)
         _mac = value
      End Set
   End Property

End Class
