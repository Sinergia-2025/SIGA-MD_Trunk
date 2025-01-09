<Serializable(), DebuggerDisplay("{DebuggerDisplayForClass,nq}")>
Public Class CuentaCorrientePago
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      CuotaNumero
      Fecha
      FechaVencimiento
      ImporteCuota
      SaldoCuota
      IdFormasPago
      Observacion
      IdTipoComprobante2
      NumeroComprobante2
      CentroEmisor2
      CuotaNumero2
      Letra2
      DescuentoRecargo
      DescuentoRecargoPorc
      ImporteCapital
      ImporteInteres
      FechaVencimiento2
      ImporteCuota2
      FechaVencimiento3
      ImporteCuota3
      '-- REQ-34469.- --------------
      FechaVencimiento4
      ImporteCuota4
      FechaVencimiento5
      ImporteCuota5
      '-----------------------------
      CodigoDeBarra
      ReferenciaCuota
      IdEmbarcacion
      IdCama
      '-- REQ-42455.- ---
      FechaPromedioCobro
      PromedioDiasCobro
      CantidadDiasCobro
      '------------------
   End Enum

   Public Sub New()
      ImporteCuota = 0
      SaldoCuota = 0
      DescuentoRecargoPorc = 0
      DescuentoRecargo = 0
   End Sub


#Region "Propiedades"

   Private _tipoComprobante As TipoComprobante
   Public Property TipoComprobante() As TipoComprobante
      Get
         If _tipoComprobante Is Nothing Then _tipoComprobante = New TipoComprobante()
         Return _tipoComprobante
      End Get
      Set(value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property

   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property Cuota As Integer
   Public Property FechaEmision As Date
   Public Property FechaVencimiento As Date
   Public Property ImporteCuota As Decimal
   Public Property SaldoCuota As Decimal
   Public Property Paga As Decimal
   Public Property DescuentoRecargoPorc As Decimal
   Public Property DescuentoRecargo As Decimal
   Public Property MontoAplicadoIncluyeIntereses As Boolean

   Private _cuentaCorriente As Entidades.CuentaCorriente
   Public Property CuentaCorriente() As CuentaCorriente
      Get
         If _cuentaCorriente Is Nothing Then _cuentaCorriente = New CuentaCorriente()
         Return _cuentaCorriente
      End Get
      Set(value As CuentaCorriente)
         _cuentaCorriente = value
      End Set
   End Property

   Private _formaPago As VentaFormaPago
   Public Property FormaPago() As VentaFormaPago
      Get
         If _formaPago Is Nothing Then _formaPago = New VentaFormaPago()
         Return Me._formaPago
      End Get
      Set(value As VentaFormaPago)
         Me._formaPago = value
      End Set
   End Property

   Public Property ImporteCapital As Decimal
   Public Property ImporteInteres As Decimal

   Public Property NombreProductos As String       'No se persiste. Concatenación de NombreProducto de los VentasProductos del Comprobante2
   Public Property Direccion As String             'No se persiste. Dirección persistida en cuenta corriente
   Public Property NombreMoneda As String          'No se persiste. Moneda de la Factura
   Public Property NumeroOrdenCompra As Long?      'No se persiste. Nro de Orden de compra. Solo para mostrar en grillas

   Public Property FechaVencimiento2 As Date?
   Public Property ImporteCuota2 As Decimal?
   Public Property FechaVencimiento3 As Date?
   Public Property ImporteCuota3 As Decimal?

   '-- REQ-34469.- -----------------------------------------------
   Public Property FechaVencimiento4 As Date?
   Public Property ImporteCuota4 As Decimal?
   Public Property FechaVencimiento5 As Date?
   Public Property ImporteCuota5 As Decimal?
   '--------------------------------------------------------------
   Public Property CodigoDeBarra As String
   Public Property CodigoDeBarraSirplus As String

   Public Property ReferenciaCuota As Long
   Public Property IdEmbarcacion As Long
   Public Property IdCama As Long
   Public Property CodigoEmbarcacion As Long
   Public Property NombreEmbarcacion As String
   Public Property CodigoCama As Long
   Public Property IdEmbarcacionCama As Long
   Public Property CodigoEmbarcacionCama As Long
   Public Property NombreEmbarcacionCama As String

   Public Property Observacion As String

   '-- REQ-42455.- ------------------------------
   Public Property FechaPromedioCobro As Date?
   Public Property PromedioDiasCobro As Decimal?
   Public Property CantidadDiasCobro As Decimal?
   '---------------------------------------------
#End Region

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return TipoComprobante.IdTipoComprobante
      End Get
   End Property

   Public ReadOnly Property FormasPagoDescripcion() As String
      Get
         Return Me.FormaPago.DescripcionFormasPago
      End Get
   End Property

   Public ReadOnly Property IdCliente As Long
      Get
         If CuentaCorriente Is Nothing OrElse CuentaCorriente.Cliente Is Nothing Then Return 0
         Return CuentaCorriente.Cliente.IdCliente
      End Get
   End Property

   Public ReadOnly Property CodigoCliente As Long
      Get
         If CuentaCorriente Is Nothing OrElse CuentaCorriente.Cliente Is Nothing Then Return 0
         Return CuentaCorriente.Cliente.CodigoCliente
      End Get
   End Property

   Public ReadOnly Property NombreCliente As String
      Get
         If CuentaCorriente Is Nothing OrElse CuentaCorriente.Cliente Is Nothing Then Return String.Empty
         Return CuentaCorriente.Cliente.NombreCliente
      End Get
   End Property
#End Region

   <DebuggerBrowsable(DebuggerBrowsableState.Never)>
   Private ReadOnly Property DebuggerDisplayForClass() As String
      Get
         Return String.Format("{0} / {1}-{2} {3:0000}-{4:00000000} Cta: {5} / {6:dd/MM/yyyy HH:mm:ss}",
                              IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Cuota, FechaEmision)
      End Get
   End Property
End Class