Public Class ActivacionOC
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "CalidadOCActivaciones"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      IdProducto
      Orden
      OrdenActivacion
      Contacto
      IdUsuario
      FechaActivacion
      Observacion
      IdObservacion
      FechaReprogEntrega
      Criticidad
      TelefonoProveedor
      CorreoElectronico
      Items
      Cantidades
      Precio
      FechaE
   End Enum

   Public Property TipoComprobante As Entidades.TipoComprobante
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property Producto As Entidades.Producto
   Public Property Orden As Integer
   Public Property OrdenActivacion As Integer
   Public Property Contacto As String
   Public Property IdUsuario As String
   Public Property FechaActivacion As DateTime
   Public Property Observacion As String
   Public Property IdObservacion As Integer
   Public Property FechaReprogEntrega As DateTime
   Public Property Criticidad As String
   Public Property TelefonoProveedor As String
   Public Property CorreoElectronico As String
   Public Property Items As Boolean
   Public Property Cantidades As Boolean
   Public Property Precio As Boolean
   Public Property FechaE As Boolean

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdProducto As String
      Get
         If Producto Is Nothing Then Return String.Empty
         Return Producto.IdProducto
      End Get
   End Property

   Public Property NombreProducto() As String
      Get
         If Producto Is Nothing Then Return String.Empty
         Return Producto.NombreProducto
      End Get
      Set(value As String)
         Producto.NombreProducto = value
      End Set
   End Property

#End Region

End Class