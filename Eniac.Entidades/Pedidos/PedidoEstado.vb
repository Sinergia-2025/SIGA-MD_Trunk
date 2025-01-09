Public Class PedidoEstado
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      NumeroPedido
      IdProducto
      FechaEstado
      IdEstado
      TipoEstadoPedido
      IdUsuario
      CantEstado
      Observacion
      IdSucursalFact
      IdTipoComprobanteFact
      LetraFact
      CentroEmisorFact
      NumeroComprobanteFact
      Orden
      IdCriticidad
      FechaEntrega
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroReparto

      'Para FK a PedidosEstados que se generó
      IdSucursalGenerado
      IdTipoComprobanteGenerado
      LetraGenerado
      CentroEmisorGenerado
      NumeroPedidoGenerado

      'Para FK a Ventas Remitos que se generó
      IdSucursalRemito
      IdTipoComprobanteRemito
      LetraRemito
      CentroEmisorRemito
      NumeroComprobanteRemito

      'Para FK a OrdenesProduccion que se generó
      IdSucursalProduccion
      IdTipoComprobanteProduccion
      LetraProduccion
      CentroEmisorProduccion
      NumeroOrdenProduccion

      'Para FK a PedidosEstadosProveedores que se vinculó
      IdSucursalVinculado
      IdTipoComprobanteVinculado
      LetraVinculado
      CentroEmisorVinculado
      NumeroPedidoVinculado
      IdProductoVinculado
      OrdenVinculado
      FechaEstadoVinculado

      AnulacionPorModificacion

      '-- MultiDeposito.- --
      IdSucursalAnterior
      IdDepositoAnterior
      IdUbicacionAnterior

   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property FechaEstado As Date


   Public Property IdEstado As String
   Public Property TipoEstadoPedido As String
   Public Property IdUsuario As String
   Public Property CantEstado As Decimal
   Public Property Observacion As String
   Public Property IdCriticidad As String
   Public Property FechaEntrega As Date
   Public Property NumeroReparto As Integer


   Public Property IdSucursalFact As Integer
   Public Property IdTipoComprobanteFact As String
   Public Property LetraFact As String
   Public Property CentroEmisorFact As Integer
   Public Property NumeroComprobanteFact As Long


   'Para FK a PedidosEstados que se generó
   Public Property IdSucursalGenerado As Integer
   Public Property IdTipoComprobanteGenerado As String
   Public Property LetraGenerado As String
   Public Property CentroEmisorGenerado As Integer
   Public Property NumeroPedidoGenerado As Long


   'Para FK a Ventas Remitos que se generó
   Public Property IdSucursalRemito As Integer
   Public Property IdTipoComprobanteRemito As String
   Public Property LetraRemito As String
   Public Property CentroEmisorRemito As Integer
   Public Property NumeroComprobanteRemito As Long


   'Para FK a OrdenesProduccion que se generó
   Public Property IdSucursalProduccion As Integer
   Public Property IdTipoComprobanteProduccion As String
   Public Property LetraProduccion As String
   Public Property CentroEmisorProduccion As Integer
   Public Property NumeroOrdenProduccion As Long


   'Para FK a PedidosEstadosProveedores que se vinculó
   Public Property IdSucursalVinculado As Integer
   Public Property IdTipoComprobanteVinculado As String
   Public Property LetraVinculado As String
   Public Property CentroEmisorVinculado As Short
   Public Property NumeroPedidoVinculado As Long
   Public Property IdProductoVinculado As String
   Public Property OrdenVinculado As Integer
   Public Property FechaEstadoVinculado As Date?

   Public Property AnulacionPorModificacion As Boolean = False


   Public Property IdSucursalAnterior As Integer
   Public Property IdDepositoAnterior As Integer
   Public Property IdUbicacionAnterior As Integer

End Class