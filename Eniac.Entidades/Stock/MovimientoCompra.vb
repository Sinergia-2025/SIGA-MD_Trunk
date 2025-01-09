<Obsolete("Se reemplaza por MovimientosStock", True)>
<Serializable()>
Public Class MovimientoCompra
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "MovimientosCompras"

   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      FechaMovimiento
      Total
      PorcentajeIVA
      IdCategoriaFiscal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdSucursal2
      Usuario
      Observacion
      PercepcionIVA
      PercepcionIB
      PercepcionGanancias
      PercepcionVarias
      IdProduccion
      IdProveedor
      IdEmpleado
      ImpuestosInternos
      MercEnviada
   End Enum

#Region "Campos"

   Private _sucursal As Entidades.Sucursal
   Private _sucursal2 As Entidades.Sucursal
   Private _tipoMovimiento As Entidades.TipoMovimiento
   Private _numeroMovimiento As Long
   Private _fechaMovimiento As DateTime
   Private _total As Decimal
   Private _porcentajeIVA As Decimal
   Private _proveedor As Entidades.Proveedor
   Private _letraComprobanteProveedor As String
   Private _nroEmisorProveedor As Integer
   Private _productos As List(Of MovimientoCompraProducto)
   Private _comentarios As String
   Private _compra As Entidades.Compra
   Private _observacion As String

   'Cambios para MovimientosStock
   Private _descuentoRecargo As Decimal
   'Private _numeroComprobanteProveedor As Long
   'vml 29/09/12
   Private _grabaAutomatico As Boolean
   Private _esMultipleRubro As Boolean
   Private _tablaContabilidad As DataTable
   Private _origenMovimiento As String
   Private _idProduccion As Integer

#End Region

#Region "Propiedades"

   Public Property DescuentoRecargo() As Decimal
      Get
         Return Me._descuentoRecargo
      End Get
      Set(ByVal value As Decimal)
         Me._descuentoRecargo = value
      End Set
   End Property
   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value
      End Set
   End Property
   Public Property Sucursal2() As Entidades.Sucursal
      Get
         If Me._sucursal2 Is Nothing Then
            Me._sucursal2 = New Entidades.Sucursal()
         End If
         Return Me._sucursal2
      End Get
      Set(ByVal value As Entidades.Sucursal)
         Me._sucursal2 = value
      End Set
   End Property
   Public Property Sucursal() As Entidades.Sucursal
      Get
         If Me._sucursal Is Nothing Then
            Me._sucursal = New Entidades.Sucursal()
         End If
         Return Me._sucursal
      End Get
      Set(ByVal value As Entidades.Sucursal)
         Me._sucursal = value
      End Set
   End Property
   Public Property TipoMovimiento() As Entidades.TipoMovimiento
      Get
         If Me._tipoMovimiento Is Nothing Then
            Me._tipoMovimiento = New Entidades.TipoMovimiento()
         End If
         Return Me._tipoMovimiento
      End Get
      Set(ByVal value As Entidades.TipoMovimiento)
         Me._tipoMovimiento = value
      End Set
   End Property
   Public Property NumeroMovimiento() As Long
      Get
         Return Me._numeroMovimiento
      End Get
      Set(ByVal value As Long)
         Me._numeroMovimiento = value
      End Set
   End Property
   Public Property FechaMovimiento() As Date
      Get
         Return Me._fechaMovimiento
      End Get
      Set(ByVal value As Date)
         Me._fechaMovimiento = value
      End Set
   End Property
   Public Property Total() As Decimal
      Get
         Return Me._total
      End Get
      Set(ByVal value As Decimal)
         Me._total = value
      End Set
   End Property
   Public Property PorcentajeIVA() As Decimal
      Get
         Return Me._porcentajeIVA
      End Get
      Set(ByVal value As Decimal)
         Me._porcentajeIVA = value
      End Set
   End Property
   Public Property Proveedor() As Entidades.Proveedor
      Get
         If Me._proveedor Is Nothing Then
            Me._proveedor = New Entidades.Proveedor()
         End If
         Return Me._proveedor
      End Get
      Set(ByVal value As Entidades.Proveedor)
         Me._proveedor = value
      End Set
   End Property
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
   Public Property Productos() As List(Of MovimientoCompraProducto)
      Get
         If Me._productos Is Nothing Then
            Me._productos = New List(Of MovimientoCompraProducto)()
         End If
         Return Me._productos
      End Get
      Set(ByVal value As List(Of MovimientoCompraProducto))
         Me._productos = value
      End Set
   End Property
   Public Property Comentarios() As String
      Get
         Return Me._comentarios
      End Get
      Set(ByVal value As String)
         Me._comentarios = value
      End Set
   End Property

   Private _percepcionIVA As Decimal
   Public Property PercepcionIVA() As Decimal
      Get
         Return _percepcionIVA
      End Get
      Set(ByVal value As Decimal)
         _percepcionIVA = value
      End Set
   End Property

   Private _percepcionIB As Decimal
   Public Property PercepcionIB() As Decimal
      Get
         Return _percepcionIB
      End Get
      Set(ByVal value As Decimal)
         _percepcionIB = value
      End Set
   End Property

   Private _percepcionGanancias As Decimal
   Public Property PercepcionGanancias() As Decimal
      Get
         Return _percepcionGanancias
      End Get
      Set(ByVal value As Decimal)
         _percepcionGanancias = value
      End Set
   End Property

   Private _percepcionVarias As Decimal
   Public Property PercepcionVarias() As Decimal
      Get
         Return _percepcionVarias
      End Get
      Set(ByVal value As Decimal)
         _percepcionVarias = value
      End Set
   End Property

   'Private _periodoFiscal As Integer
   'Public Property PeriodoFiscal() As Integer
   '   Get
   '      Return Me._periodoFiscal
   '   End Get
   '   Set(ByVal value As Integer)
   '      Me._periodoFiscal = value
   '   End Set
   'End Property

   Private _productosLotes As List(Of Entidades.ProductoLote)
   Public Property ProductosLotes() As List(Of Entidades.ProductoLote)
      Get
         If Me._productosLotes Is Nothing Then
            Me._productosLotes = New List(Of Entidades.ProductoLote)()
         End If
         Return _productosLotes
      End Get
      Set(ByVal value As List(Of Entidades.ProductoLote))
         _productosLotes = value
      End Set
   End Property

   Private _productosNrosSerie As List(Of Entidades.ProductoNroSerie)
   Public Property ProductosNrosSerie() As List(Of Entidades.ProductoNroSerie)
      Get
         If Me._productosNrosSerie Is Nothing Then
            Me._productosNrosSerie = New List(Of Entidades.ProductoNroSerie)()
         End If
         Return _productosNrosSerie
      End Get
      Set(ByVal value As List(Of Entidades.ProductoNroSerie))
         _productosNrosSerie = value
      End Set
   End Property

   Private _idCaja As Integer
   Public Property IdCaja() As Integer
      Get
         Return _idCaja
      End Get
      Set(ByVal value As Integer)
         _idCaja = value
      End Set
   End Property

   Public Property tablaContabilidad() As DataTable
      Get
         Return _tablaContabilidad
      End Get
      Set(ByVal value As DataTable)
         _tablaContabilidad = value
      End Set
   End Property
   'vml 03/12/12
   Public Property origenMovimiento() As String
      Get
         Return _origenMovimiento
      End Get
      Set(ByVal value As String)
         _origenMovimiento = value
      End Set
   End Property

   Public Property IdProduccion() As Integer
      Get
         Return Me._idProduccion
      End Get
      Set(ByVal value As Integer)
         Me._idProduccion = value
      End Set
   End Property

   '-.PE-31849.-
   Private _mercEnviada As Boolean
   Public Property MercEnviada() As Boolean
      Get
         Return Me._mercEnviada
      End Get
      Set(ByVal value As Boolean)
         Me._mercEnviada = value
      End Set
   End Property

   Public Property Empleado As Empleado

   Public Property ImpuestosInternos() As Decimal

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdEmpleado As Integer
      Get
         If Empleado Is Nothing Then Return 0
         Return Empleado.IdEmpleado
      End Get
   End Property
   Public ReadOnly Property NombreEmpleado As String
      Get
         If Empleado Is Nothing Then Return String.Empty
         Return Empleado.NombreEmpleado
      End Get
   End Property

#End Region

#End Region

End Class