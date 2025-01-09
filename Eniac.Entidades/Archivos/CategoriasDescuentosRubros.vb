<Serializable()> _
Public Class CategoriasDescuentosRubros
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoria
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


End Class