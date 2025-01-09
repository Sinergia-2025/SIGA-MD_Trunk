<Serializable()> _
Public Class ProductoSucursal
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProducto
      IdSucursal
      PrecioFabrica
      PrecioCosto
      Usuario
      FechaActualizacion
      Stock
      StockInicial
      PuntoDePedido
      StockMinimo
      StockMaximo
      Ubicacion
      'StockReservado
      FechaActualizacionWeb
      'StockDefectuoso
      'StockFuturo
      'StockFuturoReservado
      IdDepositoDefecto
      IdUbicacionDefecto
   End Enum

#Region "Campos"

   Private _precios As List(Of Entidades.ProductoSucursalPrecio)
   Private _producto As Producto = Nothing
   Private _sucursal As Sucursal = Nothing
   Private _precioFabrica As Decimal = 0
   Private _precioCosto As Decimal = 0
   'Private _precioVenta As Decimal = 0
   Private _stock As Decimal = 0
   Private _stockInicial As Decimal = 0

   Private _fechaActualizacion As Date

   Private _puntoDePedido As Decimal = 0
   Private _stockMinimo As Decimal = 0
   Private _stockMaximo As Decimal = 0
   Private _ubicacion As String = String.Empty

   Public Enum SituacionDeStock
      Todos
      StockMinimo
      PuntoDePedido
   End Enum

#End Region

#Region "Propiedades"

   Public Property IdDepositoDefecto As Integer
   Public Property IdUbicacionDefecto As Integer

   Public Property StockMinimo() As Decimal
      Get
         Return Me._stockMinimo
      End Get
      Set(ByVal value As Decimal)
         Me._stockMinimo = value
      End Set
   End Property

   Public Property StockMaximo() As Decimal
      Get
         Return Me._stockMaximo
      End Get
      Set(ByVal value As Decimal)
         Me._stockMaximo = value
      End Set
   End Property

   Public Property PuntoDePedido() As Decimal
      Get
         Return Me._puntoDePedido
      End Get
      Set(ByVal value As Decimal)
         Me._puntoDePedido = value
      End Set
   End Property

   Public Property FechaActualizacion() As Date
      Get
         Return Me._fechaActualizacion
      End Get
      Set(ByVal value As Date)
         Me._fechaActualizacion = value
      End Set
   End Property

   Public Property StockInicial() As Decimal
      Get
         Return Me._stockInicial
      End Get
      Set(ByVal value As Decimal)
         Me._stockInicial = value
      End Set
   End Property

   Public Property Stock() As Decimal
      Get
         Return Me._stock
      End Get
      Set(ByVal value As Decimal)
         Me._stock = value
      End Set
   End Property

   Public Property Stock2() As Decimal

   'Public Property StockReservado() As Decimal
   'Public Property StockDefectuoso() As Decimal
   'Public Property StockFuturo() As Decimal
   'Public Property StockFuturoReservado() As Decimal

   Public Property Sucursal() As Sucursal
      Get
         If Me._sucursal Is Nothing Then
            Me._sucursal = New Sucursal()
         End If
         Return Me._sucursal
      End Get
      Set(ByVal value As Sucursal)
         Me._sucursal = value
      End Set
   End Property

   Public Property Producto() As Producto
      Get
         If Me._producto Is Nothing Then
            Me._producto = New Producto()
         End If
         Return Me._producto
      End Get
      Set(ByVal value As Producto)
         Me._producto = value
      End Set
   End Property

   Public Property PrecioVentaLista As Decimal

   Public Property PrecioCosto() As Decimal
      Get
         Return Me._precioCosto
      End Get
      Set(ByVal value As Decimal)
         Me._precioCosto = value
      End Set
   End Property

   Public Property PrecioFabrica() As Decimal
      Get
         Return Me._precioFabrica
      End Get
      Set(ByVal value As Decimal)
         Me._precioFabrica = value
      End Set
   End Property

   Public Property Precios() As List(Of Entidades.ProductoSucursalPrecio)
      Get
         If Me._precios Is Nothing Then
            Me._precios = New List(Of Entidades.ProductoSucursalPrecio)
         End If
         Return _precios
      End Get
      Set(ByVal value As List(Of Entidades.ProductoSucursalPrecio))
         _precios = value
      End Set
   End Property

   Public Property Ubicacion() As String
      Get
         Return Me._ubicacion
      End Get
      Set(ByVal value As String)
         Me._ubicacion = value
      End Set
   End Property
   Public Property FuerzaActualizacionPrecio As Boolean '# Esta propiedad no se graba en base de datos, solo se está utilizando para forzar la actualización de la fecha en la importación por Plantilla Excel

#End Region

   Public Function GetPrecioVentaDeLista(idListaPrecios As Integer) As Decimal
      For Each pre As ProductoSucursalPrecio In Me.Precios
         If pre.ListaDePrecios.IdListaPrecios = idListaPrecios Then
            Return pre.PrecioVenta
         End If
      Next
      Return 0
   End Function

   Public Function GetCopia() As Entidades.ProductoSucursal
      Dim copia As Entidades.ProductoSucursal = New Entidades.ProductoSucursal()
      Dim pr1 As Entidades.ProductoSucursalPrecio
      With copia
         .FechaActualizacion = Me.FechaActualizacion
         .IdSucursal = Me.IdSucursal
         .Password = Me.Password
         .PrecioCosto = Me._precioCosto
         .PrecioFabrica = Me._precioFabrica
         For Each pr As Entidades.ProductoSucursalPrecio In Me.Precios
            pr.IdSucursal = Me.IdSucursal
            pr1 = pr.GetCopiaSinProductoSucursal()
            .Precios.Add(pr1)
         Next
         '.PrecioVenta = Me._precioVenta
         .Producto = Me._producto.GetCopia()
         .PuntoDePedido = Me._puntoDePedido
         .Stock = Me._stock
         .StockInicial = Me._stockInicial
         .StockMinimo = Me._stockMinimo
         .Sucursal = Me.Sucursal.GetCopia()
         .Usuario = Me.Usuario
         .Ubicacion = Me.Ubicacion
         .FuerzaActualizacionPrecio = Me.FuerzaActualizacionPrecio
      End With

      Return copia
   End Function

End Class