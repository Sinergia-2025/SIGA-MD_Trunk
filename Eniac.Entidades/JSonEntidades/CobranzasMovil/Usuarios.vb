Namespace JSonEntidades.CobranzasMovil
   Public Class Usuarios
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub

      Public Property IdEmpresa As Integer
      Public Property IdUsuario As String
      Public Property NombreUsuario As String
      Public Property Clave As String

      Public Property Roles As IEnumerable(Of UsuariosRoles)

   End Class
   Public Class UsuariosRoles
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub

      Public Property IdEmpresa As Integer
      Public Property IdUsuario As String
      Public Property IdRol As String
      Public Property Activo As Boolean

   End Class
End Namespace