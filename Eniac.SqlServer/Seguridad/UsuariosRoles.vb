Public Class UsuariosRoles
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub UsuariosRoles_I(idUsuario As String, idRol As String, idSucursal As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.UsuarioRol.NombreTabla)
         .AppendFormatLine("    ({0}", Entidades.UsuarioRol.Columnas.IdUsuario.ToString())
         .AppendFormatLine("    ,{0}", Entidades.UsuarioRol.Columnas.IdRol.ToString())
         .AppendFormatLine("    ,{0}", Entidades.UsuarioRol.Columnas.IdSucursal.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("    '{0}'", idUsuario)
         .AppendFormatLine("   ,'{0}'", idRol)
         .AppendFormatLine("   , {0} ", idSucursal)
         .AppendFormatLine(" )")

      End With
      Execute(myQuery)
   End Sub
   Public Sub UsuariosRoles_D(idSucursal As Integer, idRol As String, idUsuario As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.UsuarioRol.NombreTabla)
         .AppendFormatLine(" WHERE idRol = '{0}'", idRol)
         .AppendFormatLine("   AND idSucursal = {0}", idSucursal)
         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("   AND IdUsuario = '{0}'", idUsuario)
         End If

      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT UR.*, U.Nombre AS NombreUsuario")
         .AppendFormatLine("  FROM UsuariosRoles UR")
         .AppendFormatLine(" INNER JOIN Usuarios U ON U.Id = UR.IdUsuario")
      End With
   End Sub

   Public Function UsuariosRoles_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" ORDER BY U.Nombre")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetUsuariosPorRol(rol As String, sucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         '.AppendFormatLine("SELECT *")
         '.AppendFormatLine("  FROM UsuariosRoles UR")
         .AppendFormatLine(" WHERE UR.IdRol = '{0}'", rol)
         .AppendFormatLine("   AND UR.IdSucursal = {0}", sucursal)
         .AppendFormatLine(" ORDER BY U.Nombre")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetRolesdeUsuarios(usuario As String, idRol As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT S.Nombre, UR.IdRol, R.Descripcion  ")
         .AppendFormatLine("  FROM Usuarios U ")
         .AppendFormatLine(" INNER JOIN UsuariosRoles UR ON U.Id = UR.IdUsuario ")
         .AppendFormatLine(" INNER JOIN Roles R ON R.Id = UR.IdRol ")
         .AppendFormatLine(" INNER JOIN Sucursales S ON S.Id = UR.IdSucursal ")
         .AppendFormatLine(" WHERE U.Id = '{0}'", usuario)
         If Not String.IsNullOrEmpty(idRol) Then
            .AppendFormatLine(" AND UR.IdRol = '{0}'", idRol)
         End If
         .AppendLine(" ORDER BY U.Nombre")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetTodosParaMoviles() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT UR.IdUsuario, RF.IdFuncion, F.Enabled")
         .AppendFormatLine("  FROM Funciones F")
         .AppendFormatLine(" INNER JOIN RolesFunciones RF ON RF.IdFuncion = f.Id")
         .AppendFormatLine(" INNER JOIN UsuariosRoles UR ON UR.IdRol = RF.IdRol")
         .AppendFormatLine(" WHERE F.IdPadre = 'app.empresarial'")
         .AppendFormatLine("   AND F.Visible = 'True'")
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub EliminarUsuariosInactivos()
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE UR")
         .AppendFormatLine("  FROM UsuariosRoles UR")
         .AppendFormatLine(" INNER JOIN Usuarios U ON U.Id=UR.IdUsuario")
         .AppendFormatLine(" WHERE Activo = 'False'")

      End With
      Execute(myQuery)

   End Sub

End Class