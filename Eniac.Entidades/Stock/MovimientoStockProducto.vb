Public Class MovimientoStockProducto
   Inherits Entidad
   Implements IMovimientoConAtributos

   Public Const NombreTabla As String = "MovimientosStockProductos"

   Public Sub New()
      MovimientoStock = New MovimientoStock()
      ProductoSucursal = New ProductoSucursal()
      ProductosNrosSerie = New List(Of MovimientoStockProductoNrosSerie)
      ProductosNrosLotes = New List(Of MovimientoStockProductoLotes)
      Sucursal = New Sucursal()
      Deposito = New SucursalDeposito()
      Ubicacion = New SucursalUbicacion()
      TipoMovimiento = New TipoMovimiento()

   End Sub
   Public Enum Afecta
      DISPONIBLE
      RESERVADO
      DEFECTUOSO
      FUTURO
      <Description("FUTURO RESERVADO")> FUTURORESERVADO
   End Enum

#Region "Columnas"
   Public Enum Columnas
      IdSucursal
      IdDeposito
      IdUbicacion
      IdTipoMovimiento
      NumeroMovimiento
      IdProducto
      Cantidad
      Cantidad2
      Precio
      Orden
      IdDeposito2
      IdUbicacion2
      IdaAtributoProducto01
      IdaAtributoProducto02
      IdaAtributoProducto03
      IdaAtributoProducto04
      IdLote
      FechaLote
      VtoLote
      NrosSerie
      InformeCalidadNumero
      InformeCalidadLink
   End Enum
#End Region

#Region "Propiedades para ser mostradas en grillas. No se persisten en BD"
   Public Property CantidadAfectada As Afecta
#End Region

#Region "Propiedades"
   Public Property Sucursal As Sucursal
   Public Property Deposito As SucursalDeposito
   Public Property Ubicacion As SucursalUbicacion
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer
   Public Property NombreUbicacion As String
   Public Property TipoMovimiento As TipoMovimiento
   Public Property NumeroMovimiento As Long
   Public Property IdProducto As String
   Public Property Cantidad As Decimal
   Public Property Cantidad2 As Decimal
   Public Property CantidadParaGrillas As Decimal
   Public Property Precio() As Decimal
   Public Property Orden() As Integer
   Public Property IdaAtributoProducto01 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto01
   Public Property DescripcionAtributo01 As String
   Public Property IdaAtributoProducto02 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto02
   Public Property DescripcionAtributo02 As String
   Public Property IdaAtributoProducto03 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto03
   Public Property DescripcionAtributo03 As String
   Public Property IdaAtributoProducto04 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto04
   Public Property DescripcionAtributo04 As String

   Public Property NombreDeposito As String

   Public Property IdSucursal2 As Integer
   Public Property NombreSucursal2 As String
   Public Property IdDeposito2 As Integer
   Public Property NombreDeposito2 As String
   Public Property IdUbicacion2 As Integer
   Public Property NombreUbicacion2 As String



   Public Property IdLote As String
   Public Property VtoLote As Date?
   Public Property NrosSerie As String

   Public Property PorcentRecargo As Decimal
   Public Property IdConcepto() As Integer
   Public Property NombreConcepto() As String
   Public Property FechaActualizacion() As Date
   Public Property NombreProducto() As String
   Public Property PrecioCostoO() As Decimal
   Public Property PrecioCostoNuevo() As Decimal
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
   Public Property CodigoProductoProveedor() As String
   Public Property InformeCalidadNumero As String
   Public Property InformeCalidadLink As String
#End Region

#Region "Propiedades no persistidas"

   Public Property CantidadUMCompra As Decimal        ' Utilizadas solo para transferir información de pantalla a ComprasProductos.
   Public Property FactorConversionCompra As Decimal  ' Utilizadas solo para transferir información de pantalla a ComprasProductos.
   Public Property PrecioPorUMCompra As Decimal       ' Utilizadas solo para transferir información de pantalla a ComprasProductos.
   Public Property IdUnidadDeMedida As String         ' Utilizadas solo para transferir información de pantalla a ComprasProductos.
   Public Property IdUnidadDeMedidaCompra As String   ' Utilizadas solo para transferir información de pantalla a ComprasProductos.

#End Region


#Region "Otras Tablas"

   Public Property CentroCosto As ContabilidadCentroCosto
   Public Property ProductoSucursal As ProductoSucursal
   <ScriptIgnore()>
   Public Property MovimientoStock As MovimientoStock
   Public Property ProductosNrosSerie As List(Of MovimientoStockProductoNrosSerie)
   Public Property ProductosNrosLotes As List(Of MovimientoStockProductoLotes)
#End Region

#Region "Propiedades ReadOnly"
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

End Class
