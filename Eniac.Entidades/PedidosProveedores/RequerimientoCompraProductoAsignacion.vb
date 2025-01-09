Public Class RequerimientoCompraProductoAsignacion
   Inherits Entidad
   Public Const NombreTabla As String = "RequerimientosComprasProductosAsignaciones"
   Public Enum Columnas
      IdRequerimientoCompra
      IdProducto
      Orden
      IdSucursalPedido
      IdTipoComprobantePedido
      LetraPedido
      CentroEmisorPedido
      NumeroPedido
      Cantidad
      FechaAsignacion
      IdUsuarioAsignacion

   End Enum

   Public Property IdRequerimientoCompra As Long
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property IdSucursalPedido As Integer
   Public Property IdTipoComprobantePedido As String
   Public Property LetraPedido As String
   Public Property CentroEmisorPedido As Integer
   Public Property NumeroPedido As Long
   Public Property Cantidad As Decimal
   Public Property FechaAsignacion As Date
   Public Property IdUsuarioAsignacion As String


End Class