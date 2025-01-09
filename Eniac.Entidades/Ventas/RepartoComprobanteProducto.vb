Public Class RepartoComprobanteProducto
   Inherits Entidad
   Public Const NombreTabla As String = "RepartosComprobantesProductos"
   Public Enum Columnas
      IdSucursal
      IdReparto
      Orden
      IdProducto
      OrdenProducto
      NombreProducto
      Cantidad
      CantidadCambio
      Precio
      PrecioConImp

   End Enum

   Public Property IdReparto As Integer
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property OrdenProducto As Integer
   Public Property NombreProducto As String
   Public Property Cantidad As Decimal
   Public Property CantidadCambio As Decimal
   Public Property Precio As Decimal
   Public Property PrecioConImp As Decimal

End Class