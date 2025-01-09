Namespace ServiciosRest.CobranzasMovil
   Public Class Usuarios
      Public Function GetUsuarios(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.Usuarios)
         Dim result As List(Of Entidades.JSonEntidades.CobranzasMovil.Usuarios) = New List(Of Entidades.JSonEntidades.CobranzasMovil.Usuarios)()

         Dim dtClientes = New Reglas.Usuarios().GetAll(activo:=True)
         Dim dtPermisos = New Reglas.UsuariosRoles().GetTodosParaMovil()

         For Each dr As DataRow In dtClientes.Rows
            Dim o = New Entidades.JSonEntidades.CobranzasMovil.Usuarios(idEmpresa)
            o.IdUsuario = dr.Field(Of String)(Entidades.Usuario.Columnas.Id.ToString())
            o.NombreUsuario = dr.Field(Of String)(Entidades.Usuario.Columnas.Nombre.ToString())
            o.Clave = dr.Field(Of String)(Entidades.Usuario.Columnas.Clave.ToString())

            o.Roles = dtPermisos.Select(String.Format("IdUsuario = '{0}'", o.IdUsuario)).
                                 ToList().ConvertAll(Function(drP)
                                                        Return New Entidades.JSonEntidades.CobranzasMovil.UsuariosRoles(idEmpresa) _
                                                                 With {.IdUsuario = o.IdUsuario,
                                                                       .IdRol = drP.Field(Of String)("IdFuncion"),
                                                                       .Activo = drP.Field(Of Boolean)("Enabled")}
                                                     End Function).ToArray()

            result.Add(o)
         Next

         Return result
      End Function

   End Class
End Namespace