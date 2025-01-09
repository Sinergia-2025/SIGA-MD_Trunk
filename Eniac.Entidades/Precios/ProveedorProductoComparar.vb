Public Class ProveedorProductoComparar
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "ProveedoresProductosComparar"

   Public Enum Columnas
      IdProducto
      Linea
      IdProveedor
      CodigoProductoProveedor
      PrecioCompraAnterior
      PorcVarCompra
      PrecioCompra
      DescRec1
      DescRec2
      DescRec3
      DescRec4
      PrecioCostoAnterior
      PorcVarCosto
      PrecioCosto
   End Enum

#Region "Propiedades"

   Public Property IdProducto As String
   Public Property Linea As Integer
   Public Property IdProveedor As Long
   Public Property CodigoProductoProveedor As String
   Public Property PrecioCompraAnterior As Decimal?
   Public Property PorcVarCompra As Decimal?
   Public Property PrecioCompra As Decimal?
   Public Property DescRec1 As Decimal?
   Public Property DescRec2 As Decimal?
   Public Property DescRec3 As Decimal?
   Public Property DescRec4 As Decimal?
   Public Property PrecioCostoAnterior As Decimal?
   Public Property PorcVarCosto As Decimal?
   Public Property PrecioCosto As Decimal?

#End Region

End Class
