Public Class CategoriasMercadoLibre
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "CategoriasMercadoLibre"

   Public Enum Columnas
      IdCategoria
      NombreCategoria
      ActivoCategoria
   End Enum

#Region "Propiedades"

   Private _idCategoria As String
   Public Property IdCategoria() As String
      Get
         Return Me._idCategoria
      End Get
      Set(ByVal value As String)
         Me._idCategoria = value
      End Set
   End Property

   Private _nombreCategoria As String
   Public Property NombreCategoria() As String
      Get
         Return Me._nombreCategoria
      End Get
      Set(ByVal value As String)
         Me._nombreCategoria = value
      End Set
   End Property

   Private _activoCategoria As Integer
   Public Property ActivoCategoria() As Integer
      Get
         Return _activoCategoria
      End Get
      Set(ByVal value As Integer)
         _activoCategoria = value
      End Set
   End Property

#End Region

End Class
