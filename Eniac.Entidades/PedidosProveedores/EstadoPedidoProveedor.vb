<Serializable()>
<Description("EstadoPedidoPorveedor")>
Public Class EstadoPedidoProveedor
   Inherits Entidad

   Public Enum Columnas
      IdEstado
      idTipoComprobante
      IdTipoEstado
      Orden
      TipoEstadoPedido
      Color
      'IncrementaStockFuturo
      TipoEstadoPedidoCliente
      IdEstadoPedidoCliente
      IdTipoMovimiento
      StockAfectado
      IdEstadoDestino
      IdEstadoFacturado
      GeneraDeclaracionProduccion
   End Enum

   Public Class TipoEstado
      Public Const PENDIENTE As String = "PENDIENTE"
      Public Const ENPROCESO As String = "EN PROCESO"
      Public Const ENTREGADO As String = "ENTREGADO"
      Public Const ANULADO As String = "ANULADO"
      Public Const RECHAZADO As String = "RECHAZADO"
      Public Const OBSERVACION As String = "OBSERVAC."

   End Class

   'Public Const ESTADO_ANULADO As String = TipoEstado.ANULADO     'Se define hardcoded para no llenar la pantalla de configuración con parámetros, pero debería ponerse allí.
   'Public Const ESTADO_ALTA As String = TipoEstado.PENDIENTE      'Se define hardcoded para no llenar la pantalla de configuración con parámetros, pero debería ponerse allí.

   Public Sub New()
      Roles = New List(Of EstadoPedidoProveedorRol)()
   End Sub
   Public Sub New(tipoEstadoPedido As String)
      Me.New()
      Me.TipoEstadoPedido = tipoEstadoPedido
   End Sub

   Public Property IdEstado() As String
   Public Property IdTipoComprobante() As String
   Public Property IdTipoEstado() As String
   Public Property Orden() As Integer
   Public Property TipoEstadoPedido() As String
   Public Property Color As Integer
   'Public Property IncrementaStockFuturo As Boolean

   Public Property TipoEstadoPedidoCliente As String
   Public Property IdEstadoPedidoCliente As String

   Public Property IdTipoMovimiento As String
   Public Property StockAfectado As MovimientoStockProducto.Afecta?
   Public Property IdEstadoDestino As String
   Public Property IdEstadoFacturado As String

   Public Property GeneraDeclaracionProduccion As Boolean
   Public Property Roles As List(Of EstadoPedidoProveedorRol)

End Class