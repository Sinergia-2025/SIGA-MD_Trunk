Public Class EstadoOrdenProduccionSucursal
   Inherits Entidad

   Public Const NombreTabla As String = "EstadosOrdenesProduccionSucursales"
   Public Enum Columnas
      IdEstado
      IdSucursal
      IdDeposito
      IdUbicacion
   End Enum

   Public Property IdEstado As String
   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer
End Class
