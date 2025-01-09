Public Class UsuariosRoles
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.UsuarioRol.NombreTabla, accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.UsuarioRol)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.UsuarioRol), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.UsuarioRol)))
   End Sub

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.UsuariosRoles(da).UsuariosRoles_GA()
   End Function

   'Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
   '   Dim sql As SqlServer.UsuariosRoles = New SqlServer.UsuariosRoles(da)
   '   Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   'End Function

#End Region

#Region "Metodos privados"

   Private Sub EjecutaSP(en As Entidades.UsuarioRol, tipo As TipoSP)
      Dim sql = New SqlServer.UsuariosRoles(da)
      Select Case tipo
         Case TipoSP._I
            sql.UsuariosRoles_I(en.IdUsuario, en.IdRol, en.IdSucursal)

         Case TipoSP._D
            sql.UsuariosRoles_D(en.IdSucursal, en.IdRol, en.IdUsuario)

      End Select

   End Sub
   Private Sub CargarUno(o As Entidades.UsuarioRol, dr As DataRow)
      With o
         .IdUsuario = dr.Field(Of String)(Entidades.UsuarioRol.Columnas.IdUsuario.ToString())
         .NombreUsuario = dr.Field(Of String)("NombreUsuario")
         .IdRol = dr.Field(Of String)(Entidades.UsuarioRol.Columnas.IdRol.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.UsuarioRol.Columnas.IdSucursal.ToString())
      End With
   End Sub

   Private Sub EliminarUsuariosInactivos()
      Dim sql = New SqlServer.UsuariosRoles(da)
      sql.EliminarUsuariosInactivos()
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.UsuarioRol)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Borrar(entidad As Entidades.UsuarioRol)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Sub Actualizar(idSucursal As Integer, idRol As String, usuariosRoles As List(Of Entidades.UsuarioRol))
      EjecutaConTransaccion(
      Sub()
         _Borrar(New Entidades.UsuarioRol(idSucursal, idRol))
         For Each ur In usuariosRoles
            _Insertar(New Entidades.UsuarioRol(idSucursal, idRol, ur.IdUsuario))
         Next
         EliminarUsuariosInactivos()
      End Sub)
   End Sub

   Public Function GetTodos() As List(Of Entidades.UsuarioRol)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.UsuarioRol())
   End Function
   Public Function GetTodosPorRol(rol As String, sucursal As Integer) As List(Of Entidades.UsuarioRol)
      Return CargaLista(GetUsuariosPorRol(rol, sucursal), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.UsuarioRol())
   End Function
   Public Function GetUsuariosPorRol(rol As String, sucursal As Integer) As DataTable
      Return New SqlServer.UsuariosRoles(da).GetUsuariosPorRol(rol, sucursal)
   End Function

   Public Function GetRolesdeUsuarios(usuario As String, Optional idRol As String = "") As DataTable
      Return New SqlServer.UsuariosRoles(da).GetRolesdeUsuarios(usuario, idRol)
   End Function

   Public Function GetTodosParaMovil() As DataTable
      Return New SqlServer.UsuariosRoles(da).GetTodosParaMoviles()
   End Function

#End Region

End Class