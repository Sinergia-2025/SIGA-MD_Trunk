<Serializable()>
<Description("EstadoPedido")>
Public Class EstadoPedido
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdEstado
      idTipoComprobante
      IdTipoEstado
      Orden
      AfectaPendiente
      TipoEstadoPedido
      Color
      ReservaStock
      Divide
      IdEstadoDivideA
      IdEstadoDivideB
      PorcDivideA
      PorcDivideB
      SolicitaSucursalParaTipoComprobante
      IdSucursal
      IdDeposito
      IdUbicacion
   End Enum

   Public Class TipoEstado
      Public Const PENDIENTE As String = "PENDIENTE"
      Public Const ENPROCESO As String = "EN PROCESO"
      Public Const ENTREGADO As String = "ENTREGADO"
      Public Const ANULADO As String = "ANULADO"
      Public Const RECHAZADO As String = "RECHAZADO"
   End Class

   Public Const ESTADO_ANULADO As String = TipoEstado.ANULADO     'Se define hardcoded para no llenar la pantalla de configuración con parámetros, pero debería ponerse allí.
   Public Const ESTADO_ALTA As String = TipoEstado.PENDIENTE      'Se define hardcoded para no llenar la pantalla de configuración con parámetros, pero debería ponerse allí.

   Public Sub New()
      Roles = New List(Of EstadoPedidoRol)()
   End Sub
   Public Sub New(tipoEstadoPedido As String)
      Me.New()
      Me.TipoEstadoPedido = tipoEstadoPedido
   End Sub

   Public Property IdEstado() As String
   Public Property IdTipoComprobante() As String
   Public Property IdTipoEstado() As String
   Public Property Orden() As Integer
   Public Property AfectaPendiente() As Boolean
   Public Property TipoEstadoPedido() As String
   Public Property Color As Integer
   Public Property ReservaStock As Boolean

   Public Property Divide As Boolean
   Public Property IdEstadoDivideA As String
   Public Property IdEstadoDivideB As String
   Public Property PorcDivideA As Decimal
   Public Property PorcDivideB As Decimal
   Public Property SolicitaSucursalParaTipoComprobante As Boolean

   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer

   Public Property Roles As List(Of EstadoPedidoRol)

End Class