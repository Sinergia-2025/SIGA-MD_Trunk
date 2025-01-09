<Obsolete("Se reemplaza por MovimientosStockProductos", True)>
<Serializable()>
Public Class MovimientoVentaProducto
   Inherits Eniac.Entidades.Entidad
   Implements IMovimientoConAtributos

   Public Const NombreTabla As String = "MovimientosVentasProductos"

   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      Orden
      IdProducto
      Cantidad
      Precio
      '-- REQ-34986.- -----------------------------------
      IdaAtributoProducto01
      IdaAtributoProducto02
      IdaAtributoProducto03
      IdaAtributoProducto04
      '--------------------------------------------------
   End Enum

#Region "Campos"

   Private _movimientoVenta As Entidades.MovimientoVenta
   Private _productosNrosSerie As List(Of Entidades.MovimientoVentaProductoNroSerie)
   Private _productosNrosLotes As List(Of Entidades.MovimientoVentaProductoLote)
   Private _productoSucursal As Entidades.ProductoSucursal = Nothing
   Private _orden As Integer
   Private _cantidad As Decimal = 0
   Private _precio As Decimal = 0

#End Region

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

   Public Property MovimientoVenta() As Entidades.MovimientoVenta
      Get
         If Me._movimientoVenta Is Nothing Then
            Me._movimientoVenta = New MovimientoVenta()
         End If
         Return Me._movimientoVenta
      End Get
      Set(ByVal value As Entidades.MovimientoVenta)
         Me._movimientoVenta = value
      End Set
   End Property
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

   Public Property Orden() As Integer
      Get
         Return Me._orden
      End Get
      Set(ByVal value As Integer)
         Me._orden = value
      End Set
   End Property

   Public Property Cantidad() As Decimal
      Get
         Return Me._cantidad
      End Get
      Set(ByVal value As Decimal)
         Me._cantidad = value
      End Set
   End Property
   Public Property Precio() As Decimal
      Get
         Return Me._precio
      End Get
      Set(ByVal value As Decimal)
         Me._precio = value
      End Set
   End Property

   Public Property ProductosNrosSerie() As List(Of MovimientoVentaProductoNroSerie)
      Get
         If Me._productosNrosSerie Is Nothing Then
            Me._productosNrosSerie = New List(Of MovimientoVentaProductoNroSerie)
         End If
         Return Me._productosNrosSerie
      End Get
      Set(ByVal value As List(Of MovimientoVentaProductoNroSerie))
         Me._productosNrosSerie = value
      End Set
   End Property

   Public Property ProductosNrosLotes() As List(Of MovimientoVentaProductoLote)
      Get
         If Me._productosNrosLotes Is Nothing Then
            Me._productosNrosLotes = New List(Of MovimientoVentaProductoLote)
         End If
         Return Me._productosNrosLotes
      End Get
      Set(ByVal value As List(Of MovimientoVentaProductoLote))
         Me._productosNrosLotes = value
      End Set
   End Property

#End Region

End Class