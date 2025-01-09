<Serializable()> _
Public Class ClienteHistoria
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCLiente
      FechaHoraItem
      Item
   End Enum

   Private _Cliente As Entidades.Cliente
   Public Property Cliente() As Entidades.Cliente
      Get
         If Me._Cliente Is Nothing Then
            Me._Cliente = New Entidades.Cliente()
         End If
         Return _Cliente
      End Get
      Set(ByVal value As Entidades.Cliente)
         _Cliente = value
      End Set
   End Property

   Private _fechaHoraItem As DateTime
   Public Property FechaHoraItem() As DateTime
      Get
         Return _fechaHoraItem
      End Get
      Set(ByVal value As DateTime)
         _fechaHoraItem = value
      End Set
   End Property

   Private _item As String
   Public Property Item() As String
      Get
         Return _item
      End Get
      Set(ByVal value As String)
         _item = value
      End Set
   End Property

End Class
