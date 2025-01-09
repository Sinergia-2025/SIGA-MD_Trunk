Public Class PedidoEstadoProveedor
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      IdProducto
      Orden
      FechaEstado

      IdProveedor
      IdEstado
      TipoEstadoPedido
      IdUsuario
      CantEstado
      Observacion
      IdCriticidad
      FechaEntrega
      NumeroReparto

      'Para FK a Compra que se generó + IdProveedor
      IdTipoComprobanteFact
      LetraFact
      CentroEmisorFact
      NumeroComprobanteFact

      'Para FK a PedidosProveedor que se generó + IdProveedor
      IdSucursalGenerado
      IdTipoComprobanteGenerado
      LetraGenerado
      CentroEmisorGenerado
      NumeroPedidoGenerado

      'Para FK a Compras Remitos que se generó + IdProveedor
      IdSucursalRemito
      IdTipoComprobanteRemito
      LetraRemito
      CentroEmisorRemito
      NumeroComprobanteRemito

      IdEstadoProducto
      IdEstadoCantidad
      IdEstadoPrecio
      IdEstadoFechaEntrega
      FechaEstadoProducto
      FechaEstadoCantidad
      FechaEstadoPrecio
      FechaEstadoFechaEntrega

      'Vinculación entre OrdenesProduccionMRPOperaciones y PedidosEstadosProveedores
      IdSucursalOpOperacionTallerExt
      IdTipoComprobanteOpOperacionTallerExt
      LetraOpOperacionTallerExt
      CentroEmisorOpOperacionTallerExt
      NumeroOrdenProduccionOpOperacionTallerExt
      OrdenOpOperacionTallerExt
      IdProductoOpOperacionTallerExt
      IdProcesoProductivoOpOperacionTallerExt
      IdOperacionOpOperacionTallerExt

   End Enum

   Public Sub New()
      Proveedor = New Proveedor()
   End Sub

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property FechaEstado As Date

   Public Property Proveedor As Proveedor

   Public Property IdEstado As String
   Public Property TipoEstadoPedido As String
   Public Property IdUsuario As String
   Public Property CantEstado As Decimal
   Public Property Observacion As String
   Public Property IdCriticidad As String
   Public Property FechaEntrega As Date
   Public Property NumeroReparto As Integer


   'Para FK a Compra que se generó + IdProveedor
   Public Property IdTipoComprobanteFact As String
   Public Property LetraFact As String
   Public Property CentroEmisorFact As Integer
   Public Property NumeroComprobanteFact As Long


   'Para FK a PedidosProveedores que se generó + IdProveedor
   Public Property IdSucursalGenerado As Integer
   Public Property IdTipoComprobanteGenerado As String
   Public Property LetraGenerado As String
   Public Property CentroEmisorGenerado As Integer
   Public Property NumeroPedidoGenerado As Long


   'Para FK a Compra Remitos que se generó + IdProveedor
   Public Property IdSucursalRemito As Integer
   Public Property IdTipoComprobanteRemito As String
   Public Property LetraRemito As String
   Public Property CentroEmisorRemito As Integer
   Public Property NumeroComprobanteRemito As Long


   'Para Web OC de Metalsur
   Public Property IdEstadoProducto As String
   Public Property IdEstadoCantidad As String
   Public Property IdEstadoPrecio As String
   Public Property IdEstadoFechaEntrega As String
   Public Property FechaEstadoProducto As Date?
   Public Property FechaEstadoCantidad As Date?
   Public Property FechaEstadoPrecio As Date?
   Public Property FechaEstadoFechaEntrega As Date?


   'Vinculación entre OrdenesProduccionMRPOperaciones y PedidosEstadosProveedores
   Public Property IdSucursalOpOperacionTallerExt As Integer?
   Public Property IdTipoComprobanteOpOperacionTallerExt As String
   Public Property LetraOpOperacionTallerExt As String
   Public Property CentroEmisorOpOperacionTallerExt As Integer?
   Public Property NumeroOrdenProduccionOpOperacionTallerExt As Integer?
   Public Property OrdenOpOperacionTallerExt As Integer?
   Public Property IdProductoOpOperacionTallerExt As String
   Public Property IdProcesoProductivoOpOperacionTallerExt As Long?
   Public Property IdOperacionOpOperacionTallerExt As Integer?

End Class