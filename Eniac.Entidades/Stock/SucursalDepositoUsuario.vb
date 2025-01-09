Public Class SucursalDepositoUsuario
   Inherits Entidad

   Public Const NombreTabla As String = "SucursalesDepositosUsuarios"

   Public Enum Columnas
      IdDeposito
      IdSucursal
      IdUsuario
      Responsable
      UsuarioDefault
      PermitirEscritura
   End Enum

   Public Property IdDeposito As Integer
   Public Property IdSucursal As Integer
   Public Property IdUsuario As String
   Public Property NombreUsuario As String         'No se persiste solo para mostrar en pantalla
   Public Property Responsable As Boolean
   Public Property UsuarioDefault As Boolean
   Public Property PermitirEscritura As Boolean

End Class
