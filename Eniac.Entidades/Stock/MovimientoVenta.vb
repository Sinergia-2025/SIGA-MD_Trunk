<Obsolete("Se reemplaza por MovimientosStock", True)>
<Serializable()>
Public Class MovimientoVenta
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "MovimientosVentas"

   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      FechaMovimiento
      Neto
      Total
      IdCategoriaFiscal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Usuario
      Observacion
      TotalImpuestos
   End Enum

#Region "Campos"

   Private _sucursal As Entidades.Sucursal
   Private _tipoMovimiento As Entidades.TipoMovimiento
   Private _numeroMovimiento As Long
   Private _fechaMovimiento As DateTime
   Private _neto As Decimal
   Private _totalImpuestos As Decimal
   Private _total As Decimal
   Private _cliente As Entidades.Cliente
   Private _idCategoriaFiscal As Short
   Private _tipoComprobante As Entidades.TipoComprobante
   Private _letra As String
   Private _centroEmisor As Integer
   Private _numeroComprobante As Long
   Private _observacion As String
   'Private _comentarios As String
   Private _productos As List(Of MovimientoVentaProducto)
   Private _venta As Entidades.Venta

#End Region

#Region "Propiedades"

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
   Public Property FechaMovimiento() As DateTime
      Get
         Return Me._fechaMovimiento
      End Get
      Set(ByVal value As DateTime)
         Me._fechaMovimiento = value
      End Set
   End Property
   Public Property Neto() As Decimal
      Get
         Return Me._neto
      End Get
      Set(ByVal value As Decimal)
         Me._neto = value
      End Set
   End Property
   Public Property TotalImpuestos() As Decimal
      Get
         Return Me._totalImpuestos
      End Get
      Set(ByVal value As Decimal)
         Me._totalImpuestos = value
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
   Public Property IdCategoriaFiscal() As Short
      Get
         Return _idCategoriaFiscal
      End Get
      Set(ByVal value As Short)
         _idCategoriaFiscal = value
      End Set
   End Property
   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property
   Public Property Letra() As String
      Get
         Return Me._letra
      End Get
      Set(ByVal value As String)
         Me._letra = value
      End Set
   End Property

   Public Property CentroEmisor() As Integer
      Get
         Return Me._centroEmisor
      End Get
      Set(ByVal value As Integer)
         Me._centroEmisor = value
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
   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value
      End Set
   End Property

   Public Property Productos() As List(Of MovimientoVentaProducto)
      Get
         If Me._productos Is Nothing Then
            Me._productos = New List(Of MovimientoVentaProducto)
         End If
         Return Me._productos
      End Get
      Set(ByVal value As List(Of MovimientoVentaProducto))
         Me._productos = value
      End Set
   End Property

   Public Property Venta() As Entidades.Venta
      Get
         If Me._venta Is Nothing Then
            Me._venta = New Entidades.Venta()
         End If
         Return Me._venta
      End Get
      Set(ByVal value As Entidades.Venta)
         Me._venta = value
      End Set
   End Property

#End Region

End Class