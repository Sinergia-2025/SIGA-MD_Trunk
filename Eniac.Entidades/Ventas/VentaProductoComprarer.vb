Public Class VentaProductoComprarer
   Implements IEqualityComparer(Of Entidades.IVentaProducto)

   Public Overloads Function Equals(x As Entidades.IVentaProducto, y As Entidades.IVentaProducto) As Boolean Implements IEqualityComparer(Of Entidades.IVentaProducto).Equals
      Return If(String.IsNullOrWhiteSpace(x.IdTipoComprobante), String.Empty, x.IdTipoComprobante) = If(String.IsNullOrWhiteSpace(y.IdTipoComprobante), String.Empty, y.IdTipoComprobante) And
             If(String.IsNullOrWhiteSpace(x.Letra), String.Empty, x.Letra) = If(String.IsNullOrWhiteSpace(y.Letra), String.Empty, y.Letra) And
             x.CentroEmisor = y.CentroEmisor And x.NumeroComprobante = y.NumeroComprobante And x.Producto.IdProducto = y.Producto.IdProducto And x.Orden = y.Orden
   End Function

   Public Overloads Function GetHashCode(obj As Entidades.IVentaProducto) As Integer Implements IEqualityComparer(Of Entidades.IVentaProducto).GetHashCode
      Return If(String.IsNullOrWhiteSpace(obj.IdTipoComprobante), String.Empty, obj.IdTipoComprobante).GetHashCode() Xor
             If(String.IsNullOrWhiteSpace(obj.Letra), String.Empty, obj.Letra).GetHashCode() Xor
             obj.CentroEmisor.GetHashCode() Xor obj.NumeroComprobante.GetHashCode Xor obj.Producto.IdProducto.GetHashCode() Xor obj.Orden
   End Function
End Class