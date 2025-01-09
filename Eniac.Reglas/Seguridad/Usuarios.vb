#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class Usuarios
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess(CadenaSegura))
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Usuarios"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Public Function EsValido(usuario As String, password As String) As Boolean
      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Append("SELECT")
         .Append(" U.Id")
         .Append(", U.Nombre ")
         .Append(", U.Clave ")
         .Append(" FROM  ")
         .Append("Usuarios U ")
         .Append("  WHERE ")
         .Append(" U.Id = '" & usuario & "'")
         .Append(" AND U.Clave ='" & password & "'")
      End With
      'controla el Case Sensitive si tiene el parametro de Politicas de Clave
      Dim dt As DataTable
      dt = Me.da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         If Not Publicos.PoliticasSeguridadClaves Then
            Return True
         Else
            'comparo con Case Sensitive, si es igual a 0 significa que son iguales sino da error
            If String.Compare(password, dt.Rows(0)("Clave").ToString(), False) = 0 Then
               Return True
            End If
         End If
      End If
      Return False
   End Function

   Public Overloads Function ObtenerFunciones(usuario As String, sucursal As Integer, padre As String) As DataTable
      Return New SqlServer.Usuarios(da).ObtenerFunciones(usuario, sucursal, padre)
   End Function

   Public Overloads Function ObtenerFuncionesParaMenu(usuario As String, sucursal As Integer) As DataTable
      Return New SqlServer.Usuarios(da).ObtenerFuncionesParaMenu(usuario, sucursal)
   End Function

   'Public Overloads Function ObtenerFunciones(usuario As String, sucursal As Integer) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   With stbQuery
   '      .Append("SELECT     F.Id, F.Nombre, F.Descripcion, F.EsMenu, F.EsBoton, F.Enabled, F.Visible, F.IdPadre, F.Posicion, F.Archivo, F.Pantalla, F.Icono, F.Parametros")
   '      .Append(" FROM         UsuariosRoles AS UR INNER JOIN")
   '      .Append("                      RolesFunciones AS RF ON UR.IdRol = RF.IdRol INNER JOIN")
   '      .Append("                      Funciones AS F ON RF.IdFuncion = F.Id ")
   '      .AppendFormat(" WHERE     (UR.IdUsuario = '{0}') AND (UR.IdSucursal = {1}) AND (F.Pantalla <> '')", usuario, sucursal)
   '      .Append(" ORDER BY F.IdPadre, F.Posicion")
   '   End With
   '   Return Me.DataServer("CadenaSegura").GetDataTable(stbQuery.ToString())
   'End Function

   '<Obsolete("Usar TienePermisos(String, Integer, String) ya que el padre no tiene sentido.", True)>
   'Public Function TienePermisos(usuario As String,
   '                              sucursal As Integer,
   '                              padre As String,
   '                              funcion As String) As Boolean
   '   'No puede haber dos IdFuncion con diferente IdPadre por lo que no tiene sentido enviar el IdPadre
   '   'Si se lo seguimos pasando, cuando cambiemos una función a otro padre (sub-menu) dejarán de andar los permisos asignados
   '   Return TienePermisos(usuario, sucursal, funcion)
   'End Function

   Public Function TienePermisos(funcion As String) As Boolean
      Return TienePermisos(actual.Nombre, actual.Sucursal.Id, funcion)
   End Function

   Public Function TienePermisos(usuario As String,
                                 sucursal As Integer,
                                 funcion As String) As Boolean
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .Append(" SELECT F.* ")
         .AppendFormatLine(" FROM Funciones F, RolesFunciones RF, UsuariosRoles UR  ")
         .AppendFormatLine(" WHERE UR.IdRol = RF.IdRol ")
         .AppendFormatLine(" AND RF.IdFuncion = F.Id ")
         .AppendFormatLine(" AND UR.IdUsuario = '" & usuario & "'")
         .AppendFormatLine(" AND UR.IdSucursal = " & sucursal.ToString() & "")
         'If String.IsNullOrEmpty(padre) Then
         '   .Append(" AND F.IdPadre is null ")
         'Else
         '   .Append(" AND F.IdPadre = '" & padre & "'")
         'End If
         .AppendFormatLine(" AND F.Id = '" & funcion & "'")
         .AppendFormatLine(" AND F.Enabled = 'True'")
         .AppendFormatLine(" ORDER BY Posicion Asc")
      End With
      If Me.DataServer("CadenaSegura").GetDataTable(stbQuery.ToString()).Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   'Private Sub EjecutaSP(entidad As Entidades.Entidad, tipo As TipoSP)
   '   Dim usuario As Entidades.Usuario = DirectCast(entidad, Entidades.Usuario)
   '   Try
   '      da.OpenConection()
   '      da.BeginTransaction()

   '      da.Command.Connection = da.Connection
   '      da.Command.Transaction = da.Transaction
   '      da.Command.CommandText = Me.NombreEntidad & tipo.ToString()
   '      da.Command.CommandType = CommandType.StoredProcedure

   '      da.LoadParameter("@id", ParameterDirection.Input, DbType.String, usuario.Id)
   '      If tipo <> TipoSP._D Then
   '         da.LoadParameter("@Nombre", ParameterDirection.Input, DbType.String, usuario.Nombre)
   '         da.LoadParameter("@Clave", ParameterDirection.Input, DbType.String, usuario.Clave)
   '      End If
   '      da.Command.ExecuteNonQuery()

   '      da.CommitTransaction()

   '   Catch ex As Exception
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Sub

   Public Sub ActualizaPassword(id As String, claveNueva As String)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim oUsuarios As SqlServer.Usuarios = New SqlServer.Usuarios(da)
         Dim oUsuariosClaves As SqlServer.UsuariosClaves = New SqlServer.UsuariosClaves(da)
         oUsuarios.ActualizaPassword(id, claveNueva)
         oUsuariosClaves.UsuariosClaves_I(id, DateTime.Now(), claveNueva)

         da.CommitTransaction()

      Catch ex As Exception
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Overrides"

   Protected Overridable Function GetSqlServer() As Eniac.SqlServer.Usuarios
      Return New SqlServer.Usuarios(da)
   End Function

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Usuario)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Usuario)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Usuario)))
   End Sub

   Public Sub ActualizarMail(usuario As Entidades.Usuario)
      EjecutaConTransaccion(Sub()
                               Dim sql As SqlServer.Usuarios
                               sql = New SqlServer.Usuarios(da)

                               sql.ActualizarMail(usuario.Id, usuario.MailConfig.ServidorSMTP, usuario.MailConfig.PuertoSalida,
                                                  usuario.MailConfig.Direccion, usuario.MailConfig.UsuarioMail, usuario.MailConfig.Clave,
                                                  usuario.MailConfig.RequiereSSL, usuario.MailConfig.RequiereAutenticacion,
                                                  usuario.MailConfig.CantidadXHora, usuario.MailConfig.CantidadXMinuto,
                                                  usuario.MailConfig.UtilizaComoPredeterminado)
                            End Sub)
   End Sub

   Public Overrides Function GetAll() As DataTable
      Return GetAll(activo:=Nothing)
   End Function

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Usuarios = GetSqlServer()
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

#End Region

#Region "Metodos Privados"


   Private Sub EjecutaSP(usuario As Entidades.Usuario, tipo As TipoSP)
      Dim sql As SqlServer.Usuarios = New SqlServer.Usuarios(da)
      Select Case tipo
         Case TipoSP._I
            usuario.FechaUltimaModContraseña = Now

            sql.Usuarios_I(usuario.Id, usuario.Nombre, usuario.Clave, usuario.CorreoElectronico, usuario.FechaUltimaModContraseña, usuario.Activo, usuario.NivelAutorizacion,
                           usuario.MailConfig.ServidorSMTP, usuario.MailConfig.PuertoSalida, usuario.MailConfig.Direccion, usuario.MailConfig.Usuario, usuario.MailConfig.Password,
                           usuario.MailConfig.RequiereSSL, usuario.MailConfig.RequiereAutenticacion, usuario.MailConfig.CantidadXHora, usuario.MailConfig.CantidadXMinuto,
                           usuario.MailConfig.UtilizaComoPredeterminado, usuario.TipoUsuario)

         Case TipoSP._U
            sql.Usuarios_U(usuario.Id, usuario.Nombre, usuario.Clave, usuario.CorreoElectronico, usuario.FechaUltimaModContraseña, usuario.Activo, usuario.NivelAutorizacion,
                           usuario.MailConfig.ServidorSMTP, usuario.MailConfig.PuertoSalida, usuario.MailConfig.Direccion, usuario.MailConfig.Usuario, usuario.MailConfig.Password,
                           usuario.MailConfig.RequiereSSL, usuario.MailConfig.RequiereAutenticacion, usuario.MailConfig.CantidadXHora, usuario.MailConfig.CantidadXMinuto,
                           usuario.MailConfig.UtilizaComoPredeterminado, usuario.TipoUsuario)


         Case TipoSP._D
            sql.Usuarios_D(usuario.Id)

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Usuario, dr As DataRow, toLowerId As Boolean)
      With o
         .Id = dr(Eniac.Entidades.Usuario.Columnas.Id.ToString()).ToString()
         If toLowerId Then
            .Id = .Id.ToLower()
         End If
         .Usuario = .Id
         .Nombre = dr(Eniac.Entidades.Usuario.Columnas.Nombre.ToString()).ToString()
         .Clave = dr(Eniac.Entidades.Usuario.Columnas.Clave.ToString()).ToString()
         .CorreoElectronico = dr(Eniac.Entidades.Usuario.Columnas.CorreoElectronico.ToString()).ToString()
         .FechaUltimaModContraseña = DateTime.Parse(dr(Eniac.Entidades.Usuario.Columnas.FechaUltimaModContraseña.ToString()).ToString())
         .Activo = Boolean.Parse(dr(Eniac.Entidades.Usuario.Columnas.Activo.ToString()).ToString())
         .TipoUsuario = Short.Parse(dr(Eniac.Entidades.Usuario.Columnas.TipoUsuario.ToString()).ToString())
         .NivelAutorizacion = Short.Parse(dr(Eniac.Entidades.Usuario.Columnas.NivelAutorizacion.ToString()).ToString())
      End With
   End Sub

   Private Sub CargarUnoConMail(o As Entidades.Usuario, dr As DataRow)
      With o
         CargarUno(o, dr, toLowerId:=False)

         .MailConfig = New Entidades.MailConfig()
         .MailConfig.ServidorSMTP = dr(Eniac.Entidades.Usuario.Columnas.MailServidorSMTP.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Eniac.Entidades.Usuario.Columnas.MailPuertoSalida.ToString()).ToString()) Then
            .MailConfig.PuertoSalida = Int32.Parse(dr(Eniac.Entidades.Usuario.Columnas.MailPuertoSalida.ToString()).ToString())
         End If
         .MailConfig.Direccion = dr(Eniac.Entidades.Usuario.Columnas.MailDireccion.ToString()).ToString()
         .MailConfig.UsuarioMail = dr(Eniac.Entidades.Usuario.Columnas.MailUsuario.ToString()).ToString()
         .MailConfig.Clave = dr(Eniac.Entidades.Usuario.Columnas.MailPassword.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Eniac.Entidades.Usuario.Columnas.MailRequiereSSL.ToString()).ToString()) Then
            .MailConfig.RequiereSSL = Boolean.Parse(dr(Eniac.Entidades.Usuario.Columnas.MailRequiereSSL.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Eniac.Entidades.Usuario.Columnas.MailRequiereAutenticacion.ToString()).ToString()) Then
            .MailConfig.RequiereAutenticacion = Boolean.Parse(dr(Eniac.Entidades.Usuario.Columnas.MailRequiereAutenticacion.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Eniac.Entidades.Usuario.Columnas.MailCantxHora.ToString()).ToString()) Then
            .MailConfig.CantidadXHora = Int32.Parse(dr(Eniac.Entidades.Usuario.Columnas.MailCantxHora.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Eniac.Entidades.Usuario.Columnas.MailCantxMinuto.ToString()).ToString()) Then
            .MailConfig.CantidadXMinuto = Int32.Parse(dr(Eniac.Entidades.Usuario.Columnas.MailCantxMinuto.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Eniac.Entidades.Usuario.Columnas.UtilizaComoPredeterminado.ToString()).ToString()) Then
            .MailConfig.UtilizaComoPredeterminado = Boolean.Parse(dr(Eniac.Entidades.Usuario.Columnas.UtilizaComoPredeterminado.ToString()).ToString())
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Overloads Function GetAll(activo As Boolean?) As DataTable
      Return New SqlServer.Usuarios(da).Usuarios_GA(activo, usuarioActual:=String.Empty)
   End Function

   Public Sub _Insertar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.Usuario), TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.Usuario), TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.Usuario), TipoSP._D)
   End Sub

   Public Function GetTodos(toLowerId As Boolean) As List(Of Entidades.Usuario)
      Return GetTodos(toLowerId, activo:=Nothing)
   End Function

   Public Function GetTodos(toLowerId As Boolean, activo As Boolean?) As List(Of Entidades.Usuario)
      Return CargaLista(GetAll(activo), Sub(o, dr) CargarUno(o, dr, toLowerId), Function() New Entidades.Usuario())
   End Function

   Public Function GetActivos(toLowerId As Boolean, usuarioActual As String) As List(Of Entidades.Usuario)
      Return CargaLista(GetSqlServer().Usuarios_GA(activo:=True, usuarioActual), Sub(o, dr) CargarUno(o, dr, toLowerId), Function() New Entidades.Usuario())
   End Function


   Public Function GetUno(id As String) As Entidades.Usuario
      Return CargaEntidad(GetSqlServer().Usuarios_G1(id), Sub(o, dr) CargarUno(o, dr, toLowerId:=False), Function() New Entidades.Usuario(),
                          AccionesSiNoExisteRegistro.Nulo, String.Format("No existe usuario con Id: ´{0}´", id))

   End Function

   Public Function GetUnoConMail(idUsuario As String) As Entidades.Usuario
      Return CargaEntidad(GetSqlServer().GetUnoConMail(idUsuario), Sub(o, dr) CargarUnoConMail(o, dr), Function() New Entidades.Usuario(),
                          AccionesSiNoExisteRegistro.Nulo, String.Format("No existe usuario con Id: ´{0}´", Id))
   End Function

   Public Function _GetTodos(toLowerId As Boolean) As DataTable
      Return GetAll()
   End Function

   Public Function EsUsuarioActivo(usuario As String) As Boolean
      Try
         Me.da.OpenConection()
         Return New SqlServer.Usuarios(da).EsUsuarioActivo(usuario)
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function EsValido(usuario As String, password As String, PoliticasSeguridad As Boolean) As Boolean
      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Append("SELECT")
         .Append(" U.Id")
         .Append(", U.Nombre ")
         .Append(", U.Clave ")
         .Append(", U.FechaUltimaModContraseña")
         .Append(",U.Activo")
         .Append(" FROM  ")
         .Append("Usuarios U ")
         .Append("  WHERE ")
         .Append(" U.Id = '" & usuario & "'")
         .Append(" AND U.Clave ='" & password & "'")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())
      Dim cantidad As Integer = 0
      Dim i As Integer = 0


      If dt.Rows.Count > 0 Then
         If PoliticasSeguridad Then
            For Each ch As Char In dt.Rows(0)("Clave").ToString()
               If ch = password.Chars(i) Then
                  cantidad += 1
               End If
               i += 1
            Next
            If cantidad = dt.Rows(0)("Clave").ToString().Length Then
               Return True
            Else
               Return False
            End If
         Else
            Return True
         End If
      End If

      Return False
   End Function

   Public Function UsuarioEsDeProceso(idUsuario As String) As Boolean
      Return New SqlServer.Usuarios(da).UsuarioEsDeProceso(idUsuario)
   End Function

#End Region

End Class