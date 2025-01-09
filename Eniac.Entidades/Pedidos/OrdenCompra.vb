<Serializable()>
<Description("OrdenCompra")>
Public Class OrdenCompra
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      NumeroOrdenCompra
      IdProveedor
      IdFormasPago
      FechaPedidos
      IdUsuario
      RespetaPreciosOrdenCompra
      AplicaDescuentoRecargo
      Anticipado
   End Enum

   Public Property NumeroOrdenCompra As Long
   Public Property IdProveedor As Long
   Public Property IdFormasPago As Integer
   Public Property FechaPedidos As DateTime
   Public Property RespetaPreciosOrdenCompra As Boolean
   Public Property IdUsuario As String
   Public Property AplicaDescuentoRecargo As Boolean
   Public Property Anticipado As Boolean

#Region "Propiedades para mostrar en pantalla, no se persisten"
   Public Property CodigoProveedor As String
   Public Property NombreProveedor As String
   Public Property DescripcionFormasPago As String
#End Region

End Class