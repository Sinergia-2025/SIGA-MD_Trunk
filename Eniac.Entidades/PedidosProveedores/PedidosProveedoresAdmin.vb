Public Class AdminCambioEstado(Of TEstado)

   Public Property EstadoDestino As TEstado ''EstadoPedidoProveedor
   Public Property FechaNuevoEstado As Date?
   Public Property Observaciones As String

   Public Property IdUsuario As String
   Public Property GeneraUnPedidoPorProveedor As Boolean

   Public Property Pedidos As List(Of AdminCambioEstadoDetalle(Of TEstado))

   Private Sub New()
      GeneraUnPedidoPorProveedor = False
      Pedidos = New List(Of AdminCambioEstadoDetalle(Of TEstado))()
      IdUsuario = actual.Nombre
   End Sub

   Public Sub New(estadoDestino As TEstado) ''EstadoPedidoProveedor)
      Me.New()
      Me.EstadoDestino = estadoDestino
   End Sub

   Public Sub New(estadoDestino As TEstado, observaciones As String)
      Me.New(estadoDestino)
      Me.Observaciones = observaciones
   End Sub
End Class
Public Class AdminCambioEstadoDetalle(Of TEstado)

   Public Property IdSucursal As Integer
   Public Property IdTipoComprobante As String
   Public Property DescripcionTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property Orden As Integer
   Public Property FechaEstado As Date
   Public Property Producto As ProductoLivianoParaImportarProducto

   Public Property FechaPedido As Date


   Public Property IdClienteProveedor As Long

   Public Property FechaEntrega As Date
   Public Property EstadoActual As TEstado ''EstadoPedidoProveedor
   ''' <summary>
   ''' Es la fecha que se le puso al estado de pedido cuando se realiza efectivamente el cambio de estado
   ''' </summary>
   ''' <remarks>
   ''' Cada registro que se cambia la fecha de estado tiene un segundo de diferencia con el anterior. Esto en un momento se hizo para evitar problemas de clave duplicada.
   ''' </remarks>
   ''' <returns></returns>
   Public Property FechaEstadoDestino As Date
   Public Property Cantidad As Decimal
   Public Property Precio As Decimal
   Public Property DescRecPorcGral As Decimal
   Public Property IdCriticidad As String
   Public Property IdResponsable As Integer

   Public Property NumeroReparto As Integer

   Public Property PlanMaestroNumero As Integer?
   Public Property PlanMaestroFecha As Date?

   Public Property Ubicaciones As List(Of SeleccionMultipleUbicaciones)

   Public Property Componentes As List(Of AdminCambioEstadoComponentes)

   Public Property OPOperacionTalleresExternos As OrdenProduccionMRPOperacion_PK

   Public Property IdTipoComprobantePedido As String
   Public Property DescripcionTipoComprobantePedido As String
   Public Property LetraPedido As String
   Public Property CentroEmisorPedido As Integer
   Public Property NumeroPedidoPedido As Long
   Public Property OrdenPedido As Integer
   Public Property IdProductoPedido As String

   Public Function SetPlanMaestro(planMaestroNumero As Integer?, planMaestroFecha As Date?) As AdminCambioEstadoDetalle(Of TEstado)
      Me.PlanMaestroNumero = planMaestroNumero
      Me.PlanMaestroFecha = planMaestroFecha
      Return Me
   End Function

   Public ReadOnly Property IdProducto As String
      Get
         Return If(Producto Is Nothing, String.Empty, Producto.IdProducto)
      End Get
   End Property

   Public Sub New()
      Ubicaciones = New List(Of SeleccionMultipleUbicaciones)()
      Componentes = New List(Of AdminCambioEstadoComponentes)()
   End Sub

   Public Sub New(idSucursal As Integer, idTipoComprobante As String, descripcionTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                  orden As Integer, fechaEstado As Date, producto As ProductoLivianoParaImportarProducto)
      Me.New()
      Me.IdSucursal = idSucursal
      Me.IdTipoComprobante = idTipoComprobante
      Me.DescripcionTipoComprobante = descripcionTipoComprobante
      Me.Letra = letra
      Me.CentroEmisor = centroEmisor
      Me.NumeroPedido = numeroPedido
      Me.Orden = orden
      Me.FechaEstado = fechaEstado
      Me.Producto = producto
   End Sub

   Public Function PkToString() As String
      Return String.Format("{1} {2} {3:0000}-{4:00000000} - Ln: {5} - Prod: {6} {7}",
                           IdSucursal, DescripcionTipoComprobante, Letra, CentroEmisor, NumeroPedido,
                           Orden, Producto.IdProducto, Producto.NombreProducto)
   End Function
End Class
Public Class AdminCambioEstadoComponentes
   Public Property Producto As ProductoLivianoParaImportarProducto
   Public Property Cantidad As Decimal
   Public Property Ubicaciones As List(Of SeleccionMultipleUbicaciones)
   Public Property UbicacionDestino As SucursalUbicacion

   Public Property ProductoComponente As ProduccionProductoComp ' OrdenProduccionProductoFormula

End Class

Public Structure PedProvAdminClaveGenerar
   Public Property IdSucursal As Integer
   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long

   Public Property IdSucursalDestino As Integer
   Public Property IdTipoComprobanteDestino As String
   Public Property IdProveedor As Long
   Public Property DescRecPorcGral As Decimal

   Public Sub New(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                  idSucursalDestino As Integer, idTipoComprobanteDestino As String, idProveedor As Long, descRecPorcGral As Decimal)
      Me.IdSucursal = idSucursal
      Me.IdTipoComprobante = idTipoComprobante
      Me.Letra = letra
      Me.CentroEmisor = centroEmisor
      Me.NumeroPedido = numeroPedido
      Me.IdSucursalDestino = idSucursalDestino
      Me.IdTipoComprobanteDestino = idTipoComprobanteDestino
      Me.IdProveedor = idProveedor
      Me.DescRecPorcGral = descRecPorcGral
   End Sub

   'Public Sub New(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, idProveedor As Long)
   '   Me.New(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idSucursalDestino:=0, idTipoComprobanteDestino:=String.Empty, idProveedor)
   'End Sub

   Public Sub New(idTipoComprobanteDestino As String, idProveedor As Long)
      Me.New(idSucursal:=0, idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroPedido:=0, idSucursalDestino:=0, idTipoComprobanteDestino, idProveedor, descRecPorcGral:=0)
   End Sub
End Structure

Public Class PedidosProveedoresAdminCambioEstado
   Inherits AdminCambioEstado(Of EstadoPedidoProveedor)
   Public Sub New(estadoDestino As EstadoPedidoProveedor)
      MyBase.New(estadoDestino)
   End Sub
   Public Sub New(estadoDestino As EstadoPedidoProveedor, observaciones As String)
      MyBase.New(estadoDestino, observaciones)
   End Sub
End Class
Public Class PedidosProveedoresAdminPedidos
   Inherits AdminCambioEstadoDetalle(Of EstadoPedidoProveedor)
   Public Sub New()
   End Sub
   Public Sub New(idSucursal As Integer, idTipoComprobante As String, descripcionTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, orden As Integer, fechaEstado As Date, producto As ProductoLivianoParaImportarProducto)
      MyBase.New(idSucursal, idTipoComprobante, descripcionTipoComprobante, letra, centroEmisor, numeroPedido, orden, fechaEstado, producto)
   End Sub
End Class

Public Class OrdenesProduccionAdminCambioEstado
   Inherits AdminCambioEstado(Of EstadoOrdenProduccion)
   Public Sub New(estadoDestino As EstadoOrdenProduccion)
      MyBase.New(estadoDestino)
   End Sub
   Public Sub New(estadoDestino As EstadoOrdenProduccion, observaciones As String)
      MyBase.New(estadoDestino, observaciones)
   End Sub
End Class

Public Class OrdenesProduccionAdminPedidos
   Inherits AdminCambioEstadoDetalle(Of EstadoOrdenProduccion)
   Public Sub New()
   End Sub
   Public Sub New(idSucursal As Integer, idTipoComprobante As String, descripcionTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, orden As Integer, fechaEstado As Date, producto As ProductoLivianoParaImportarProducto)
      MyBase.New(idSucursal, idTipoComprobante, descripcionTipoComprobante, letra, centroEmisor, numeroPedido, orden, fechaEstado, producto)
   End Sub
End Class