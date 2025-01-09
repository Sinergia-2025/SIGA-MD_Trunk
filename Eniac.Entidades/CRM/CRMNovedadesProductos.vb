Public Class CRMNovedadProducto
   Inherits CRMEntidad
   Public Const NombreTabla As String = "CRMNovedadesProductos"

   Public Enum Columnas
      idTipoNovedad
      IdNovedad
      LetraNovedad
      CentroEmisor
      IdProducto
      NombreProducto
      OrdenProducto
      CantidadProducto
      PrecioProducto
      IdListaPrecios
      StockConsumidoProducto
      nroSerie
      IdSucursalActual
      IdDepositoActual
      IdUbicacionActual
      IdsucursalAnterior
      IdDepositoAnterior
      IdUbicacionAnterior
      StockReservadoProducto
   End Enum

   Public Property IdNovedad As Long
   Public Property LetraNovedad As String
   Public Property CentroEmisor As Short
   Public Property IdSucursalNovedad As Integer?
   Public Property IdProducto As String
   Public Property NombreProducto As String
   Public Property OrdenProducto As Integer
   Public Property CantidadProducto As Decimal
   Public Property PrecioProducto As Decimal
   Public Property ImporteNovedad As Decimal
   Public Property IdListaPrecios As Integer
   Public Property StockConsumidoProducto As Boolean
   Public Property nroSerie As String
   Public Property IdSucursalActual As Integer
   Public Property IdDepositoActual As Integer
   Public Property IdUbicacionActual As Integer
   Public Property IdsucursalAnterior As Integer
   Public Property IdDepositoAnterior As Integer
   Public Property IdUbicacionAnterior As Integer
   Public Property StockReservadoProducto As Boolean

   Private _productosNovedadLote As List(Of CRMNovedadProductoLote)
   Public Property ProductosNovedadLote As List(Of CRMNovedadProductoLote)
      Get
         If _productosNovedadLote Is Nothing Then _productosNovedadLote = New List(Of CRMNovedadProductoLote)()
         Return _productosNovedadLote
      End Get
      Set(ByVal value As List(Of CRMNovedadProductoLote))
         _productosNovedadLote = value
      End Set
   End Property

   Private _productosNovedadNrosSerie As List(Of CRMNovedadProductoNrosSerie)
   Public Property ProductosNovedadNrosSerie As List(Of CRMNovedadProductoNrosSerie)
      Get
         If _productosNovedadNrosSerie Is Nothing Then _productosNovedadNrosSerie = New List(Of CRMNovedadProductoNrosSerie)()
         Return _productosNovedadNrosSerie
      End Get
      Set(ByVal value As List(Of CRMNovedadProductoNrosSerie))
         _productosNovedadNrosSerie = value
      End Set
   End Property

End Class
