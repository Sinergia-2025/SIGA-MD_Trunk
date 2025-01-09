Public Class MovimientoStockProductoLotes
   Inherits Entidad

   Public Const NombreTabla As String = "MovimientosStockProductosLotes"

   Public Enum Columnas
      IdSucursal
      IdDeposito
      IdUbicacion
      IdTipoMovimiento
      NumeroMovimiento
      Orden
      IdProducto
      IdLote
      Cantidad
      Cantidad2
      FechaVencimiento
      PrecioCosto
   End Enum

   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer
   Public Property IdTipoMovimiento As String
   Public Property NumeroMovimiento As Long
   Public Property FechaVencimiento As Date
   Public Property PrecioCosto As Decimal
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property IdLote As String
   Public Property Cantidad As Decimal
   Public Property Cantidad2 As Decimal

End Class
