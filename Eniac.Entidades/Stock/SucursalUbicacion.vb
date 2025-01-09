Public Class SucursalUbicacion
   Inherits Entidad

   Public Const NombreTabla As String = "SucursalesUbicaciones"
   Public Enum Columnas
      CodigoDeposito
      IdDeposito
      NombreDeposito
      IdSucursal
      NombreSucursal
      IdUbicacion
      NombreUbicacion
      CodigoUbicacion
      EstadoUbicacion
      NombreEstado
      SucursalAsociada
      DepositoAsociado
      UbicacionAsociada
      Activo
   End Enum

   Public Property IdDeposito As Integer
   Public Property CodigoDeposito As String
   Public Property NombreDeposito As String
   Public Property IdSucursal As Integer
   Public Property NombreSucursal As String
   Public Property IdUbicacion As Integer
   Public Property NombreUbicacion As String
   Public Property CodigoUbicacion As String
   Public Property EstadoUbicacion As Integer
   Public Property NombreEstado As String
   Public Property SucursalAsociada As Integer
   Public Property DepositoAsociado As Integer
   Public Property UbicacionAsociada As Integer
   Public Property Activo As Boolean

End Class
