<Serializable()>
<Description("EstadoPedido")>
Public Class EstadoOrdenProduccion
   Inherits Eniac.Entidades.Entidad
   Implements IReservaStock

   Public Enum Columnas
      IdEstado
      IdTipoComprobante
      IdTipoEstado
      Orden
      Color
      ReservaMateriaPrima
      GeneraProductoTerminado
      TipoEstadoPedido
      IdEstadoPedido
      IdSucursal
      IdDeposito
      NombreDeposito
      IdUbicacion
      NombreUbicacion
   End Enum

   Public Class TipoEstado
      Public Const PENDIENTE As String = "PENDIENTE"
      Public Const ENPROCESO As String = "EN PROCESO"
      Public Const FINALIZADO As String = "FINALIZADO"
      Public Const ANULADO As String = "ANULADO"
   End Class

   Public Const ESTADO_ANULADO As String = TipoEstado.ANULADO     'Se define hardcoded para no cargar la pantalla de configuración, pero debería ponerse allí.
   Public Const ESTADO_ALTA As String = TipoEstado.PENDIENTE

   Public Property IdEstado() As String
   Public Property IdTipoComprobante() As String
   Public Property IdTipoEstado() As String
   Public Property Orden() As Integer
   Public Property Color As Integer
   Public Property ReservaMateriaPrima As Boolean Implements IReservaStock.Reserva
   Public Property GeneraProductoTerminado As Boolean

   Public Property TipoEstadoPedido As String
   Public Property IdEstadoPedido As String

   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer

End Class