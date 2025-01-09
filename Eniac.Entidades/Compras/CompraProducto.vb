<Serializable()>
Public Class CompraProducto
   Inherits Entidad
   Implements IMovimientoConAtributos

   Public Const NombreTabla As String = "ComprasProductos"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProveedor
      IdProducto
      Cantidad
      Precio
      DescRecGeneral
      DescuentoRecargo
      ImporteTotal
      DescuentoRecargoProducto
      DescuentoRecargoPorc
      DescRecGeneralProducto
      PrecioNeto
      ImporteTotalNeto
      PorcentajeIVA
      IVA
      Orden
      NombreProducto
      IdConcepto
      PasajeMovimiento
      MontoAplicado
      MontoSaldo
      ProporcionalImp
      IdCentroCosto
      IdaAtributoProducto01
      IdaAtributoProducto02
      IdaAtributoProducto03
      IdaAtributoProducto04
      IdDeposito
      IdUbicacion
      InformeCalidadNumero
      InformeCalidadLink
      IdLote
      FechaVencimientoLote
      CantidadUMCompra
      FactorConversionCompra
      PrecioPorUMCompra
      IdUnidadDeMedida
      IdUnidadDeMedidaCompra
   End Enum

#Region "Campos"

   Private _centroEmisor As Short
   Private _tipoComprobante As Entidades.TipoComprobante
   Private _letra As String
   Private _numeroComprobante As Long
   Private _orden As Integer
   Private _productoSucursal As Entidades.ProductoSucursal
   Private _cantidad As Decimal
   Private _precio As Decimal
   Private _descRecGeneral As Decimal
   Private _descRecGeneralProducto As Decimal
   Private _descuentoRecargo As Decimal
   Private _descuentoRecargoProducto As Decimal
   Private _descuentoRecargoPorc As Decimal
   Private _iva As Decimal
   Private _importeTotal As Decimal
   Private _stock As Decimal
   Private _compra As Entidades.Compra
   Private _precioNeto As Decimal
   Private _importeTotalNeto As Decimal
   Private _producto As Entidades.Producto
   Private _pasajeMovimiento As Boolean
   Private _montoAplicado As Decimal
   Private _montoSaldo As Decimal
   Private _proporcionalImp As Decimal

#End Region

#Region "Propiedades"
   Public Property InformeCalidadNumero As String
   Public Property InformeCalidadLink As String


   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer
   '-- REQ-34986.- -----------------------------------
   Public Property IdaAtributoProducto01 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto01
   Public Property DescripcionAtributo01 As String
   Public Property IdaAtributoProducto02 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto02
   Public Property DescripcionAtributo02 As String
   Public Property IdaAtributoProducto03 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto03
   Public Property DescripcionAtributo03 As String
   Public Property IdaAtributoProducto04 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto04
   Public Property DescripcionAtributo04 As String
   '--------------------------------------------------
   Public Property IdLote As String
   Public Property FechaVencimientoLote As Date?
   '--------------------------------------------------

   Public Property CantidadUMCompra As Decimal
   Public Property FactorConversionCompra As Decimal
   Public Property PrecioPorUMCompra As Decimal
   Public Property IdUnidadDeMedida As String
   Public Property IdUnidadDeMedidaCompra As String

   '# Esta propiedad no se persiste. Es solo para visualización en grillas
   Public Property CodigoProductoProveedor() As String

   Public Property Compra() As Entidades.Compra
      Get
         If Me._compra Is Nothing Then
            Me._compra = New Entidades.Compra()
         End If
         Return Me._compra
      End Get
      Set(ByVal value As Entidades.Compra)
         Me._compra = value
      End Set
   End Property
   Public Property Stock() As Decimal
      Get
         Return _stock
      End Get
      Set(ByVal value As Decimal)
         _stock = value
      End Set
   End Property
   Public Property CentroEmisor() As Short
      Get
         Return _centroEmisor

      End Get
      Set(ByVal value As Short)
         _centroEmisor = value
      End Set
   End Property
   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         If Me._tipoComprobante Is Nothing Then
            Me._tipoComprobante = New Entidades.TipoComprobante()
         End If
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property
   Public Property Letra() As String
      Get
         Return _letra

      End Get
      Set(ByVal value As String)
         Me._letra = value
      End Set
   End Property
   Public Property NumeroComprobante() As Long
      Get
         Return Me._numeroComprobante
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobante = value
      End Set
   End Property
   Public Property Orden() As Integer
      Get
         Return Me._orden
      End Get
      Set(ByVal value As Integer)
         Me._orden = value
      End Set
   End Property
   Public Property ProductoSucursal() As Entidades.ProductoSucursal
      Get
         Return Me._productoSucursal
      End Get
      Set(ByVal value As Entidades.ProductoSucursal)
         Me._productoSucursal = value
      End Set
   End Property
   Public Property Cantidad() As Decimal
      Get
         Return _cantidad

      End Get
      Set(ByVal value As Decimal)
         _cantidad = value
      End Set
   End Property
   Public Property Precio() As Decimal
      Get
         Return _precio
      End Get
      Set(ByVal value As Decimal)
         _precio = value
      End Set
   End Property
   Public Property DescRecGeneral() As Decimal
      Get
         Return Me._descRecGeneral
      End Get
      Set(ByVal value As Decimal)
         Me._descRecGeneral = value
      End Set
   End Property
   Public Property DescRecGeneralProducto() As Decimal
      Get
         Return Me._descRecGeneralProducto
      End Get
      Set(ByVal value As Decimal)
         Me._descRecGeneralProducto = value
      End Set
   End Property
   Public Property DescuentoRecargo() As Decimal
      Get
         Return _descuentoRecargo
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargo = value
      End Set
   End Property
   Public Property DescuentoRecargoProducto() As Decimal
      Get
         Return _descuentoRecargoProducto
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoProducto = value
      End Set
   End Property
   Public Property DescuentoRecargoPorc() As Decimal
      Get
         Return _descuentoRecargoPorc
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc = value
      End Set
   End Property
   Public Property Iva() As Decimal
      Get
         Return _iva
      End Get
      Set(ByVal value As Decimal)
         _iva = value
      End Set
   End Property
   Public Property ImporteTotal() As Decimal
      Get
         Return _importeTotal
      End Get
      Set(ByVal value As Decimal)
         _importeTotal = value
      End Set
   End Property
   Public Property PrecioNeto() As Decimal
      Get
         Return _precioNeto
      End Get
      Set(ByVal value As Decimal)
         _precioNeto = value
      End Set
   End Property
   Public Property ImporteTotalNeto() As Decimal
      Get
         Return _importeTotalNeto
      End Get
      Set(ByVal value As Decimal)
         _importeTotalNeto = value
      End Set
   End Property
   Public Property Producto() As Entidades.Producto
      Get
         If Me._producto Is Nothing Then
            Me._producto = New Entidades.Producto()
         End If
         Return Me._producto
      End Get
      Set(ByVal value As Entidades.Producto)
         Me._producto = value
      End Set
   End Property
   Public ReadOnly Property NombreProducto() As String
      Get
         Return Me.Producto.NombreProducto
      End Get
   End Property

   Private _porcentajeIVA As Decimal
   Public Property PorcentajeIVA() As Decimal
      Get
         Return _porcentajeIVA
      End Get
      Set(ByVal value As Decimal)
         _porcentajeIVA = value
      End Set
   End Property

   Private _idConcepto As Integer = 0
   Public Property IdConcepto() As Integer
      Get
         Return Me._idConcepto
      End Get
      Set(ByVal value As Integer)
         Me._idConcepto = value
      End Set
   End Property

   Public Property PasajeMovimientos() As Boolean
      Get
         Return _pasajeMovimiento
      End Get
      Set(ByVal value As Boolean)
         _pasajeMovimiento = value
      End Set
   End Property

   Public Property MontoAplicado() As Decimal
      Get
         Return _montoAplicado
      End Get
      Set(ByVal value As Decimal)
         _montoAplicado = value
      End Set
   End Property

   Public Property MontoSaldo() As Decimal
      Get
         Return _montoSaldo
      End Get
      Set(ByVal value As Decimal)
         _montoSaldo = value
      End Set
   End Property

   Public Property ProporcionalImp() As Decimal
      Get
         Return _proporcionalImp
      End Get
      Set(ByVal value As Decimal)
         _proporcionalImp = value
      End Set
   End Property

   Public Property CentroCosto As ContabilidadCentroCosto
   Public ReadOnly Property IdCentroCosto As Integer?
      Get
         If CentroCosto Is Nothing Then Return Nothing
         Return CentroCosto.IdCentroCosto
      End Get
   End Property
   Public ReadOnly Property NombreCentroCosto As String
      Get
         If CentroCosto Is Nothing Then Return String.Empty
         Return CentroCosto.NombreCentroCosto
      End Get
   End Property

#End Region

#Region "Propiedades para pasar a MovimientosStockProductos desde generación automática"
   Public Property NrosSeries As List(Of SeleccionMultipleNrosSerie)
#End Region

End Class