<Serializable()>
Public Class ProductoSucursalAtributo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProducto
      IdSucursal
      IdProdSucAtributo
      IdaAtributo01
      IdaAtributo02
      IdaAtributo03
      IdaAtributo04
      Stock
      Stock2
   End Enum

#Region "Propiedades"
   Public Property IdProducto As String
   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer
   Public Property IdProdSucAtributo As Integer
   Public Property IdaAtributo01 As Integer
   Public Property IdaAtributo02 As Integer
   Public Property IdaAtributo03 As Integer
   Public Property IdaAtributo04 As Integer
   Public Property Stock As Decimal
   Public Property Stock2 As Decimal

#End Region

End Class