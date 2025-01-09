<Serializable()> _
Public Class ProductoSucursalPrecio
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProducto
      IdSucursal
      IdListaPrecios
      PrecioVenta
      FechaActualizacion
      Usuario
      FechaActualizacionWeb

   End Enum

   Private _productoSucursal As Entidades.ProductoSucursal
   Public Property ProductoSucursal() As Entidades.ProductoSucursal
      Get
         Return _productoSucursal
      End Get
      Set(ByVal value As Entidades.ProductoSucursal)
         _productoSucursal = value
      End Set
   End Property

   Private _listaDePrecios As Entidades.ListaDePrecios
   Public Property ListaDePrecios() As Entidades.ListaDePrecios
      Get
         Return _listaDePrecios
      End Get
      Set(ByVal value As Entidades.ListaDePrecios)
         _listaDePrecios = value
      End Set
   End Property

   Private _precioVenta As Decimal
   Public Property PrecioVenta() As Decimal
      Get
         Return _precioVenta
      End Get
      Set(ByVal value As Decimal)
         _precioVenta = value
      End Set
   End Property

   Private _fechaActualizacion As DateTime
   Public Property FechaActualizacion() As DateTime
      Get
         Return _fechaActualizacion
      End Get
      Set(ByVal value As DateTime)
         _fechaActualizacion = value
      End Set
   End Property

   Public Function GetCopia() As Entidades.ProductoSucursalPrecio
      Dim copia As Entidades.ProductoSucursalPrecio = New Entidades.ProductoSucursalPrecio()
      With copia
         .FechaActualizacion = Me._fechaActualizacion
         .IdSucursal = Me.IdSucursal
         .ListaDePrecios = Me._listaDePrecios.GetCopia()
         .Password = Me.Password
         .PrecioVenta = Me._precioVenta
         .ProductoSucursal = Me._productoSucursal.GetCopia()
         .Usuario = Me.Usuario
      End With

      Return copia
   End Function

   Public Function GetCopiaSinProductoSucursal() As Entidades.ProductoSucursalPrecio
      Dim copia As Entidades.ProductoSucursalPrecio = New Entidades.ProductoSucursalPrecio()
      With copia
         .FechaActualizacion = Me._fechaActualizacion
         .IdSucursal = Me.IdSucursal
         .ListaDePrecios = Me._listaDePrecios.GetCopia()
         .Password = Me.Password
         .PrecioVenta = Me._precioVenta
         .ProductoSucursal = Me._productoSucursal
         .Usuario = Me.Usuario
      End With
      Return copia
   End Function


End Class
