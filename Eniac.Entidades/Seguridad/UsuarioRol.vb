<Serializable()>
Public Class UsuarioRol
   Inherits Entidad
   Public Const NombreTabla As String = "UsuariosRoles"
   Public Enum Columnas
      IdUsuario
      IdRol
      IdSucursal
   End Enum

   Public Sub New()
      Me.New(idSucursal:=0, idRol:=String.Empty)
   End Sub

   Public Sub New(idSucursal As Integer, idRol As String)
      Me.New(idSucursal, idRol, idUsuario:=String.Empty)
   End Sub

   Public Sub New(idSucursal As Integer, idRol As String, idUsuario As String)
      Me.IdSucursal = idSucursal
      Me.IdUsuario = idUsuario
      Me.IdRol = idRol
      NombreUsuario = String.Empty
   End Sub

   Public Property IdUsuario As String
   Public Property NombreUsuario As String
   Public Property IdRol As String

End Class

