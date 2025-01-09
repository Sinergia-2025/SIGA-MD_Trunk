Public Class MovimientoStockProductoNrosSerie
   Inherits Entidad

   Public Const NombreTabla As String = "MovimientosStockProductosNrosSerie"

   Public Enum Columnas
      IdSucursal
      IdDeposito
      IdUbicacion
      IdTipoMovimiento
      NumeroMovimiento
      Orden
      IdProducto
      NroSerie
      Cantidad
      Cantidad2
   End Enum

   Public Property IdTipoMovimiento As String
   Public Property NumeroMovimiento As Long
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property NroSerie As String
   Public Property Cantidad As Decimal
   Public Property Cantidad2 As Decimal
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer

End Class
