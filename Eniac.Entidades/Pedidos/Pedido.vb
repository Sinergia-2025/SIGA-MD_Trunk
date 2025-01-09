Imports System.ComponentModel
<Serializable()>
Public Class Pedido
   Inherits Entidad
   Implements IPKComprobante

   Public Const NombreTabla As String = "Pedidos"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      FechaPedido
      IdCliente
      Observacion
      IdUsuario
      DescuentoRecargo
      DescuentoRecargoPorc
      IdVendedor
      IdFormasPago
      IdTransportista
      CotizacionDolar
      IdTipoComprobanteFact
      ImporteBruto
      SubTotal
      TotalImpuestos
      TotalImpuestoInterno
      ImporteTotal
      IdEstadoVisita
      NumeroOrdenCompra
      Kilos
      ObservacionInterna
      IdMoneda
      IdClienteVinculado
      Palets
      NroVersionAplicacion
      NroVersionRemoto
      FechaImpresion
      IdPedidoTiendaNube
      IdPedidoMercadoLibre
      IdLocalidad
      Direccion
      Cuit
      TipoDocCliente
      NroDocCliente
      NombreCliente
      IdCaja
      SaldoActualCtaCte
      IdPlazoEntrega
      ValidezPresupuesto
      IdDomicilio
      FechaActualizacion
      IdUsuarioActualizacion
   End Enum

   Public Enum FormatoImportarPedidos As Integer
      <Description("Estándar")> ESTANDAR = 0
      <Description("Talkiu")> TALKIU = 1
      <Description("Talkiu Web")> TALKIUWEB = 2

   End Enum

#Region "Campos"

   'Private _importeBruto As Decimal
   'Private _subtotal As Decimal
   'Private _importeTotal As Decimal
   'Private _periodo As Entidades.VentaPeriodo
   'Private _facturables As System.Collections.Generic.List(Of Entidades.Venta)
   'Private _idEstadoComprobante As String = String.Empty
   'Private _tipoComprobanteFact As Entidades.TipoComprobante
   'Private _letraFact As String = String.Empty
   'Private _centroEmisorFact As Integer
   'Private _numeroComprobanteFact As Long
   'Private _NumeroPlanilla As Integer
   'Private _NumeroMovimiento As Integer
   'Private _kilos As Decimal
   'Private _comisionVendedor As Decimal
   'Private _bultos As Integer
   'Private _valorDeclarado As Decimal
   'Private _numeroLote As Long
   'Private _ventasObservaciones As System.Collections.Generic.List(Of Entidades.VentaObservacion)
   'Private _chequesRechazados As List(Of Entidades.Cheque)
   'Private _totalImpuestos As Decimal
   'Private _cantidadInvocados As Integer
   'Private _cantidadLotes As Integer
   'Private _ventasProductosLotes As System.Collections.Generic.List(Of Entidades.VentaProductoLote)


#End Region

#Region "Propiedades"


   Public Property TipoComprobante() As Entidades.TipoComprobante

   Private _letraComprobante As String = String.Empty
   Public Property LetraComprobante() As String
      Get
         'Si no fue seteado de la venta, tomo el del Cliente
         If String.IsNullOrEmpty(Me._letraComprobante) AndAlso Cliente IsNot Nothing AndAlso Cliente.CategoriaFiscal IsNot Nothing Then
            Me._letraComprobante = Me.Cliente.CategoriaFiscal.LetraFiscal
         End If
         Return Me._letraComprobante
      End Get
      Set(ByVal value As String)
         Me._letraComprobante = value
      End Set
   End Property

   Public Property CentroEmisor() As Short
   Public Property NumeroPedido() As Long

   Public Property Fecha() As Date

   Public Property Observacion() As String
   Public Property IdUsuario() As String

   Public Property DescuentoRecargo() As Decimal
   Public Property DescuentoRecargoPorc() As Decimal

   Private _cliente As Entidades.Cliente
   Public Property Cliente() As Entidades.Cliente
      Get
         If Me._cliente Is Nothing Then
            Me._cliente = New Entidades.Cliente()
         End If
         Return Me._cliente
      End Get
      Set(ByVal value As Entidades.Cliente)
         Me._cliente = value
      End Set
   End Property

   Public Property Vendedor() As Empleado
   Public Property Caja() As CajaNombre

   Public Property FormaPago() As Entidades.VentaFormaPago

   Private _transportista As Entidades.Transportista
   Public Property Transportista() As Entidades.Transportista
      Get
         If Me._transportista Is Nothing Then
            Me._transportista = New Entidades.Transportista()
         End If
         Return Me._transportista
      End Get
      Set(ByVal value As Entidades.Transportista)
         Me._transportista = value
      End Set
   End Property

   Public Property TipoComprobanteFact() As Entidades.TipoComprobante

   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         If Me._categoriaFiscal Is Nothing AndAlso Cliente IsNot Nothing Then
            Me._categoriaFiscal = Me.Cliente.CategoriaFiscal
         End If
         Return Me._categoriaFiscal
      End Get
      Set(ByVal value As Entidades.CategoriaFiscal)
         Me._categoriaFiscal = value
      End Set
   End Property

   Private _impresora As Entidades.Impresora
   Public Property Impresora() As Entidades.Impresora
      Get
         If Me._impresora Is Nothing Then
            Me._impresora = New Entidades.Impresora()
         End If
         Return _impresora
      End Get
      Set(ByVal value As Entidades.Impresora)
         _impresora = value
      End Set
   End Property

   Public Property CotizacionDolar() As Decimal
   Public Property ImporteBruto() As Decimal
   Public Property SubTotal() As Decimal
   Public Property TotalImpuestos() As Decimal
   Public Property TotalImpuestoInterno() As Decimal
   Public Property ImporteTotal() As Decimal
   Public Property EstadoVisita() As EstadoVisita
   Public Property NumeroOrdenCompra As Long
   Public Property Utilidad As Decimal

   Public Property Kilos As Decimal

   Public Property ObservacionInterna As String

   Public Property IdMoneda As Integer = 1

   Public Property ClienteVinculado As Entidades.Cliente

   Public Property Palets As Integer = 1

   Public Property NroVersionAplicacion As String
   Public Property NroVersionRemoto As String
   Public Property IdPedidoTiendaNube As String
   Public Property IdPedidoMercadoLibre As String

   Private _pedidosProductos As System.Collections.Generic.List(Of Entidades.PedidoProducto)
   Public Property PedidosProductos() As Generic.List(Of Entidades.PedidoProducto)
      Get
         If Me._pedidosProductos Is Nothing Then
            Me._pedidosProductos = New Generic.List(Of Entidades.PedidoProducto)()
         End If
         Return Me._pedidosProductos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.PedidoProducto))
         Me._pedidosProductos = value
      End Set
   End Property

   Private _contactos As List(Of PedidoClienteContacto)
   Public Property Contactos() As List(Of PedidoClienteContacto)
      Get
         Return _contactos
      End Get
      Set(ByVal value As List(Of PedidoClienteContacto))
         _contactos = value
      End Set
   End Property

   Private _pedidosContactos As List(Of Entidades.PedidoClienteContacto)
   Public Property PedidosContactos() As List(Of Entidades.PedidoClienteContacto)
      Get
         If Me._pedidosContactos Is Nothing Then
            Me._pedidosContactos = New List(Of Entidades.PedidoClienteContacto)()
         End If
         Return Me._pedidosContactos
      End Get
      Set(ByVal value As List(Of Entidades.PedidoClienteContacto))
         Me._pedidosContactos = value
      End Set
   End Property

   Private _pedidosObservaciones As List(Of Entidades.PedidoObservacion)
   Public Property PedidosObservaciones() As List(Of Entidades.PedidoObservacion)
      Get
         If Me._pedidosObservaciones Is Nothing Then
            Me._pedidosObservaciones = New List(Of Entidades.PedidoObservacion)()
         End If
         Return Me._pedidosObservaciones
      End Get
      Set(ByVal value As List(Of Entidades.PedidoObservacion))
         Me._pedidosObservaciones = value
      End Set
   End Property

   Public Property SaldoActualCtaCte As Decimal

   Public Property FechaActualizacion As Date
   Public Property IdUsuarioActualizacion As String

#End Region

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return Me.TipoComprobante.IdTipoComprobante
      End Get
   End Property

   Public ReadOnly Property TipoComprobanteDescripcion() As String
      Get
         Return Me.TipoComprobante.Descripcion
      End Get
   End Property

   Public ReadOnly Property IdEmpleado() As Integer
      Get
         If Vendedor Is Nothing Then Return Nothing
         Return Vendedor.IdEmpleado
      End Get
   End Property

   Public Property IdPlazoEntrega As Integer

   Public Property ValidezPresupuesto As Integer

   Public ReadOnly Property IdCaja() As Integer?
      Get
         If Caja Is Nothing Then Return Nothing
         Return Caja.IdCaja
      End Get
   End Property

   Public ReadOnly Property IdFormaPago() As Integer?
      Get
         If Vendedor Is Nothing Then Return Nothing
         Return FormaPago.IdFormasPago
      End Get
   End Property

   Public ReadOnly Property IdTransportista() As Integer?
      Get
         If Transportista Is Nothing Then Return Nothing
         Return Transportista.idTransportista
      End Get
   End Property

   Public ReadOnly Property IdTipoComprobanteFact() As String
      Get
         If TipoComprobanteFact Is Nothing Then Return String.Empty
         Return Me.TipoComprobanteFact.IdTipoComprobante
      End Get
   End Property

   Public ReadOnly Property IdEstadoVisita() As Integer
      Get
         If EstadoVisita Is Nothing Then EstadoVisita = New EstadoVisita()
         Return Me.EstadoVisita.IdEstadoVisita
      End Get
   End Property

   Public ReadOnly Property NombreEstadoVisita() As String
      Get
         If EstadoVisita Is Nothing Then EstadoVisita = New EstadoVisita()
         Return Me.EstadoVisita.NombreEstadoVisita
      End Get
   End Property

   Public ReadOnly Property IdCliente As Long
      Get
         If _cliente Is Nothing Then Return 0
         Return _cliente.IdCliente
      End Get
   End Property
   Public ReadOnly Property CodigoCliente As Long
      Get
         If _cliente Is Nothing Then Return 0
         Return _cliente.CodigoCliente
      End Get
   End Property
   Public ReadOnly Property NombreCliente As String
      Get
         If _cliente Is Nothing Then Return String.Empty
         Return _cliente.NombreCliente
      End Get
   End Property

   Public ReadOnly Property IdClienteVinculado As Long
      Get
         If _ClienteVinculado Is Nothing Then Return 0
         Return _ClienteVinculado.IdCliente
      End Get
   End Property
   Public ReadOnly Property CodigoClienteVinculado As Long
      Get
         If _ClienteVinculado Is Nothing Then Return 0
         Return _ClienteVinculado.CodigoCliente
      End Get
   End Property
   Public ReadOnly Property NombreClienteVinculado As String
      Get
         If _ClienteVinculado Is Nothing Then Return String.Empty
         Return _ClienteVinculado.NombreCliente
      End Get
   End Property

   Public Property IdLocalidad As Integer?
   Public Property Direccion As String
   Public Property Cuit As String
   Public Property TipoDocCliente As String
   Public Property NroDocCliente As Long?
   Public Property NombreClienteGenerico As String

   Public Property IdDomicilio As Integer?

#End Region

   'Este valor es calculado en el GetUna. No se guarda en BD.
   Public Property CantidadProductos As Decimal

#Region "IPKComprobante"
   Private ReadOnly Property IPKComprobante_IdSucursal As Integer Implements IPKComprobante.IdSucursal
      Get
         Return IdSucursal
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_IdTipoComprobante As String Implements IPKComprobante.IdTipoComprobante
      Get
         Return IdTipoComprobante
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_Letra As String Implements IPKComprobante.Letra
      Get
         Return LetraComprobante
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_CentroEmisor As Integer Implements IPKComprobante.CentroEmisor
      Get
         Return CentroEmisor
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_NumeroComprobante As Long Implements IPKComprobante.NumeroComprobante
      Get
         Return NumeroPedido
      End Get
   End Property
#End Region

End Class