<Serializable()>
Public Class SueldosCategoria
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idCategoria
      NombreCategoria
   End Enum

   Private _idCategoria As Integer
   Public Property idCategoria() As Integer
      Get
         Return Me._idCategoria
      End Get
      Set(ByVal value As Integer)
         Me._idCategoria = value
      End Set
   End Property

   Private _NombreCategoria As String
   Public Property NombreCategoria() As String
      Get
         Return Me._NombreCategoria
      End Get
      Set(ByVal value As String)
         Me._NombreCategoria = value
      End Set
   End Property

End Class