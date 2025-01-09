<Obsolete("Se reemplaza por MovimientosStockProductosLote", True)>
<Serializable()>
Public Class MovimientoVentaProductoLote
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      Orden
      IdProducto
      IdLote
      Cantidad
   End Enum

#Region "Propiedades"

   Public Property IdTipoMovimiento As String
   Public Property NumeroMovimiento As Long
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property IdLote As String
   Public Property Cantidad As Decimal

#End Region

End Class
