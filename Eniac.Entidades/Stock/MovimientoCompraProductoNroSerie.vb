<Obsolete("Se reemplaza por MovimientosStockProductosNrosSerie", True)>
Public Class MovimientoCompraProductoNroSerie
   Inherits Entidad

   Public Const NombreTabla As String = "MovimientosComprasProductosNrosSerie"

   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      Orden
      Cantidad
      IdProducto
      NroSerie
   End Enum

   Public Property IdTipoMovimiento As String
   Public Property NumeroMovimiento As Long
   Public Property Orden As Integer
   Public Property Cantidad As Integer
   Public Property IdProducto As String
   Public Property NroSerie As String

End Class
