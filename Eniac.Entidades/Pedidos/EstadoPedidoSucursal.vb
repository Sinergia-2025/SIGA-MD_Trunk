Public Class EstadoPedidoSucursal
   Inherits Entidad

   Public Const NombreTabla As String = "EstadosPedidosSucursales"
   Public Enum Columnas
      IdEstado
      TipoEstadoPedido
      IdSucursal
      IdDeposito
      IdUbicacion
   End Enum

   Public Property IdEstado As String
   Public Property TipoEstadoPedido As String
   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer

End Class
