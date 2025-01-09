Public Class RepartoComprobante
   Inherits Entidad
   Public Const NombreTabla As String = "RepartosComprobantes"
   Public Enum Columnas
      IdSucursal
      IdReparto
      Orden
      IdTipoComprobantePedido
      LetraPedido
      CentroEmisorPedido
      NumeroPedido
      IdTipoComprobanteFact
      LetraFact
      CentroEmisorFact
      NumeroComprobante
      IdSucursalRecibo
      IdTipoComprobanteRecibo
      LetraRecibo
      CentroEmisorRecibo
      NumeroComprobanteRecibo
      ImporteTotalFact
      ImporteTotalRecibo
   End Enum

   Public Sub New()
      Productos = New List(Of RepartoComprobanteProducto)()
   End Sub

   Public Property IdReparto As Integer
   Public Property Orden As Integer

   Public Property Pedido As Pedido
   Public Property Venta As Venta
   Public Property ImporteTotalFact As Decimal?
   Public Property Recibo As CuentaCorriente
   Public Property ImporteTotalRecibo As Decimal?

   Public Property Productos As List(Of RepartoComprobanteProducto)

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdTipoComprobantePedido As String
      Get
         If Pedido Is Nothing Then Return String.Empty
         Return Pedido.IdTipoComprobante
      End Get
   End Property
   Public ReadOnly Property LetraPedido As String
      Get
         If Pedido Is Nothing Then Return String.Empty
         Return Pedido.LetraComprobante
      End Get
   End Property
   Public ReadOnly Property CentroEmisorPedido As Short?
      Get
         If Pedido Is Nothing Then Return Nothing
         Return Pedido.CentroEmisor
      End Get
   End Property
   Public ReadOnly Property NumeroPedido As Long?
      Get
         If Pedido Is Nothing Then Return Nothing
         Return Pedido.NumeroPedido
      End Get
   End Property

   Public ReadOnly Property IdTipoComprobanteFact As String
      Get
         If Venta Is Nothing Then Return String.Empty
         Return Venta.IdTipoComprobante
      End Get
   End Property
   Public ReadOnly Property LetraFact As String
      Get
         If Venta Is Nothing Then Return String.Empty
         Return Venta.LetraComprobante
      End Get
   End Property
   Public ReadOnly Property CentroEmisorFact As Short?
      Get
         If Venta Is Nothing Then Return Nothing
         Return Venta.CentroEmisor
      End Get
   End Property
   Public ReadOnly Property NumeroComprobante As Long?
      Get
         If Venta Is Nothing Then Return Nothing
         Return Venta.NumeroComprobante
      End Get
   End Property

   Public ReadOnly Property IdSucursalRecibo As Integer?
      Get
         If Recibo Is Nothing Then Return Nothing
         Return Recibo.IdSucursal
      End Get
   End Property
   Public ReadOnly Property IdTipoComprobanteRecibo As String
      Get
         If Recibo Is Nothing Then Return String.Empty
         Return Recibo.TipoComprobante.IdTipoComprobante
      End Get
   End Property
   Public ReadOnly Property LetraRecibo As String
      Get
         If Recibo Is Nothing Then Return String.Empty
         Return Recibo.Letra
      End Get
   End Property
   Public ReadOnly Property CentroEmisorRecibo As Short?
      Get
         If Recibo Is Nothing Then Return Nothing
         Return Recibo.CentroEmisor
      End Get
   End Property
   Public ReadOnly Property NumeroComprobanteRecibo As Long?
      Get
         If Recibo Is Nothing Then Return Nothing
         Return Recibo.NumeroComprobante
      End Get
   End Property
#End Region

End Class