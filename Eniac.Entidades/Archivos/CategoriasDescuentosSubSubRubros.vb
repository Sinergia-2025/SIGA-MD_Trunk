<Serializable()> _
Public Class CategoriasDescuentosSubSubRubros
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoria
      IdSubSubRubro
      IdSubRubro
      IdRubro
      DescuentoRecargoPorc1
   End Enum

#Region "Propiedades"

   Private _idCategoria As Integer
   Public Property IdCategoria() As Integer
      Get
         Return _idCategoria
      End Get
      Set(ByVal value As Integer)
         _idCategoria = value
      End Set
   End Property
   Private _idSubSubRubro As Integer
   Public Property IdSubSubRubro() As Integer
      Get
         Return _idSubSubRubro
      End Get
      Set(ByVal value As Integer)
         _idSubSubRubro = value
      End Set
   End Property
   Private _idSubRubro As Integer
   Public Property IdSubRubro() As Integer
      Get
         Return _idSubRubro
      End Get
      Set(ByVal value As Integer)
         _idSubRubro = value
      End Set
   End Property

   Private _idRubro As Integer
   Public Property IdRubro() As Integer
      Get
         Return _idRubro
      End Get
      Set(ByVal value As Integer)
         _idRubro = value
      End Set
   End Property

   Private _descuentoRecargoPorc1 As Decimal
   Public Property DescuentoRecargoPorc1() As Decimal
      Get
         Return _descuentoRecargoPorc1
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc1 = value
      End Set
   End Property
#End Region

   Property Descuento As Decimal

End Class