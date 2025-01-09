Imports System.ComponentModel

<Obsolete("Se reemplaza por MovimientosStockProductos", True)>
<Serializable()>
Public Class MovimientoCompraProducto
   Inherits Entidad
   Implements IMovimientoConAtributos

   Public Const NombreTabla As String = "MovimientosComprasProductos"

   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      IdProducto
      Cantidad
      Precio
      IdLote
      Orden
      CantidadReservado
      CantidadDefectuoso
      CantidadFuturo
      CantidadFuturoReservado
      IdaAtributoProducto01
      IdaAtributoProducto02
      IdaAtributoProducto03
      IdaAtributoProducto04
   End Enum

   Public Enum Afecta
      DISPONIBLE
      RESERVADO
      DEFECTUOSO
      FUTURO
      <Description("FUTURO RESERVADO")> FUTURORESERVADO
   End Enum

#Region "Propiedades"
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
   Public Property Orden() As Integer
   Public Property IdProducto() As String
   Public Property NombreProducto() As String
   Public Property Cantidad() As Decimal
   Public Property PrecioCostoO() As Decimal
   Public Property PrecioCostoNuevo() As Decimal
   Public Property Precio() As Decimal
   Public Property PrecioVentaActual() As Decimal
   Public Property PrecioVentaNuevo() As Decimal
   Public Property DescuentoRecargoPorc() As Decimal
   Public Property DescuentoRecargo() As Decimal
   Public Property DescRecGeneral() As Decimal
   Public Property Stock() As Decimal
   Public Property ImporteTotal() As Decimal
   Public Property PorcentajeIVA() As Decimal
   Public Property IVA() As Decimal
   Public Property TotalProducto() As Decimal
   Public Property PorcVar() As Decimal
   Private _movimientoCompra As Entidades.MovimientoCompra
   Public Property MovimientoCompra() As Entidades.MovimientoCompra
      Get
         If Me._movimientoCompra Is Nothing Then
            Me._movimientoCompra = New MovimientoCompra()
         End If
         Return Me._movimientoCompra
      End Get
      Set(ByVal value As Entidades.MovimientoCompra)
         Me._movimientoCompra = value
      End Set
   End Property
   Private _productoSucursal As Entidades.ProductoSucursal = Nothing
   Public Property ProductoSucursal() As Entidades.ProductoSucursal
      Get
         If Me._productoSucursal Is Nothing Then
            Me._productoSucursal = New Entidades.ProductoSucursal()
         End If
         Return Me._productoSucursal
      End Get
      Set(ByVal value As Entidades.ProductoSucursal)
         Me._productoSucursal = value
      End Set
   End Property
   Public Property IdLote() As String
   Public Property VtoLote As Date?
   Public Property PorcentRecargo() As Decimal
   Public Property IdConcepto() As Integer
   Public Property NombreConcepto() As String
   Public Property FechaActualizacion() As Date
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

   Public Property CodigoProductoProveedor() As String
   Public Property CantidadReservado() As Decimal
   Public Property CantidadDefectuoso() As Decimal
   Public Property CantidadFuturo() As Decimal
   Public Property CantidadFuturoReservado() As Decimal

   '# Productos con Nro. Serie
   Private _productosNrosSerie As List(Of MovimientoCompraProductoNroSerie)
   Public Property ProductosNrosSerie() As List(Of MovimientoCompraProductoNroSerie)
      Get
         If Me._productosNrosSerie Is Nothing Then
            Me._productosNrosSerie = New List(Of MovimientoCompraProductoNroSerie)
         End If
         Return Me._productosNrosSerie
      End Get
      Set(ByVal value As List(Of MovimientoCompraProductoNroSerie))
         Me._productosNrosSerie = value
      End Set
   End Property

#Region "Propiedades para ser mostradas en grillas. No se persisten en BD"
   Public Property CantidadAfectada As Afecta
   Public ReadOnly Property CantidadParaGrillas As Decimal
      Get
         Return Cantidad + CantidadReservado + CantidadDefectuoso + CantidadFuturo + CantidadFuturoReservado
      End Get
   End Property
#End Region

#End Region

   Public Sub SetCantidadSegunAfecta(cantidad As Decimal, afecta As String)
      SetCantidadSegunAfecta(cantidad, DirectCast([Enum].Parse(GetType(Afecta), afecta), Afecta))
   End Sub
   Public Sub SetCantidadSegunAfecta(cantidad As Decimal, afecta As Afecta)
      Select Case afecta
         Case MovimientoCompraProducto.Afecta.DISPONIBLE
            Me.Cantidad = cantidad
         Case MovimientoCompraProducto.Afecta.RESERVADO
            CantidadReservado = cantidad
         Case MovimientoCompraProducto.Afecta.DEFECTUOSO
            CantidadDefectuoso = cantidad
         Case MovimientoCompraProducto.Afecta.FUTURO
            CantidadFuturo = cantidad
         Case MovimientoCompraProducto.Afecta.FUTURORESERVADO
            CantidadFuturoReservado = cantidad
         Case Else
      End Select
   End Sub

End Class