Public Class TipoComprobanteProducto
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "TiposComprobantesProductos"
   Public Enum Columnas
      IdTipoComprobante
      IdProducto
      Cantidad
   End Enum

   Public Property IdTipoComprobante As String
   Public Property IdProducto As String
   Public Property NombreProducto As String   '' No se persiste, es solo para grillas
   Public Property Cantidad As Decimal

End Class
