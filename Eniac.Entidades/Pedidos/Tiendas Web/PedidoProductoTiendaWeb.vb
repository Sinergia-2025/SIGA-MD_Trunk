Public Class PedidoProductoTiendaWeb
   Inherits Entidad

   Public Const NombreTabla As String = "PedidosProductosTiendasWeb"

   Public Property Id As String
   Public Property SistemaDestino As String
   Public Property Numero As Long
   Public Property IdProductoTiendaWeb As String
   Public Property NombreProductoTiendaWeb As String
   Public Property Precio As Decimal
   Public Property Cantidad As Decimal

   Public Enum Columnas
      Id
      SistemaDestino
      Numero
      IdProductoTiendaWeb
      NombreProductoTiendaWeb
      Precio
      Cantidad
   End Enum
End Class
