Public Class SeleccionMultipleBase
   <ScriptIgnore()>
   Public Property UbicacionAdmin As SeleccionMultipleUbicaciones

   Public Property Cantidad As Decimal

   Public Sub New()
   End Sub
   Public Sub New(ubicacionAdmin As SeleccionMultipleUbicaciones)
      Me.New()
      Me.UbicacionAdmin = ubicacionAdmin
   End Sub

#Region "ReadOnly Properties"
   Public ReadOnly Property Producto As ProductoLivianoParaImportarProducto
      Get
         Return UbicacionAdmin.Producto
      End Get
   End Property
   Public ReadOnly Property Ubicacion As SucursalUbicacion
      Get
         Return UbicacionAdmin.Ubicacion
      End Get
   End Property
   Public ReadOnly Property IdProducto As String
      Get
         Return If(Producto Is Nothing, String.Empty, Producto.IdProducto)
      End Get
   End Property
   Public ReadOnly Property NombreProducto As String
      Get
         Return If(Producto Is Nothing, String.Empty, Producto.NombreProducto)
      End Get
   End Property

   Public ReadOnly Property IdSucursal As Integer
      Get
         Return If(Ubicacion Is Nothing, 0, Ubicacion.IdSucursal)
      End Get
   End Property
   Public ReadOnly Property NombreSucursal As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.NombreSucursal)
      End Get
   End Property

   Public ReadOnly Property IdDeposito As Integer
      Get
         Return If(Ubicacion Is Nothing, 0, Ubicacion.IdDeposito)
      End Get
   End Property
   Public ReadOnly Property CodigoDeposito As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.CodigoDeposito)
      End Get
   End Property
   Public ReadOnly Property NombreDeposito As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.NombreDeposito)
      End Get
   End Property

   Public ReadOnly Property IdUbicacion As Integer
      Get
         Return If(Ubicacion Is Nothing, 0, Ubicacion.IdUbicacion)
      End Get
   End Property
   Public ReadOnly Property CodigoUbicacion As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.CodigoUbicacion)
      End Get
   End Property
   Public ReadOnly Property NombreUbicacion As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.NombreUbicacion)
      End Get
   End Property

#End Region

End Class