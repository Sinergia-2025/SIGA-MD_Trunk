<Serializable()>
Public Class ProductoProveedor
   Inherits Entidad

   Public Const NombreTabla As String = "ProductosProveedores"

   Public Enum Columnas
      IdProveedor
      IdProducto
      CodigoProductoProveedor
      UltimoPrecioCompra
      UltimaFechaCompra
      UltimoPrecioFabrica
      DescuentoRecargoPorc1
      DescuentoRecargoPorc2
      DescuentoRecargoPorc3
      DescuentoRecargoPorc4
      DescuentoRecargoPorc5
      DescuentoRecargoPorc6
   End Enum

   Public Sub New()
      UltimaFechaCompra = Date.Now
      IdProducto = String.Empty
      CodigoProductoProveedor = String.Empty
   End Sub

   Public Sub New(idProveedor As Long, idProducto As String, ultimaFechaCompra As Date)
      Me.New()
      Me.IdProveedor = idProveedor
      Me.IdProducto = idProducto
      Me.UltimaFechaCompra = ultimaFechaCompra
   End Sub


#Region "Propiedades"

   Public Property IdProveedor As Long
   Public Property IdProducto As String
   Public Property CodigoProductoProveedor As String
   Public Property UltimoPrecioCompra As Decimal
   Public Property UltimaFechaCompra As Date

   Public Property UltimoPrecioFabrica As Decimal
   Public Property DescuentoRecargoPorc1 As Decimal
   Public Property DescuentoRecargoPorc2 As Decimal
   Public Property DescuentoRecargoPorc3 As Decimal
   Public Property DescuentoRecargoPorc4 As Decimal
   Public Property DescuentoRecargoPorc5 As Decimal
   Public Property DescuentoRecargoPorc6 As Decimal

#End Region

End Class