<Obsolete("Se reemplaza por MovimientosStockProductosNrosSerie", True)>
Public Class MovimientoVentaProductoNroSerie
   Inherits Entidad

   Public Const NombreTabla As String = "MovimientosVentasProductosNrosSerie"

   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      Orden
      IdProducto
      NroSerie
      Cantidad
   End Enum

   Public Property IdTipoMovimiento As String
   Public Property NumeroMovimiento As Long
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property NroSerie As String
   Public Property Cantidad As Integer

End Class
