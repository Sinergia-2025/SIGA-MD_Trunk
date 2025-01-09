Public Class SucursalesDepositosUsuarios
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "SucursalDepositoUsuario"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.SucursalDepositoUsuario)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.SucursalDepositoUsuario)))
   End Sub
   Public Sub Merge(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.SucursalDepositoUsuario)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.SucursalDepositoUsuario)))
   End Sub
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.SucursalDepositoUsuario, tipo As TipoSP)
      Dim sqlC = New SqlServer.SucursalesDepositosUsuarios(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.SucursalesDepositosUsuarios_I(en.IdDeposito, en.IdSucursal, en.IdUsuario, en.Responsable, en.UsuarioDefault, en.PermitirEscritura)
         Case TipoSP._D
            sqlC.SucursalesDepositosUsuarios_D(en.IdDeposito, en.IdSucursal)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.SucursalDepositoUsuario, dr As DataRow)
      With o
         .IdDeposito = dr.Field(Of Integer)(Entidades.SucursalDepositoUsuario.Columnas.IdDeposito.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.SucursalDepositoUsuario.Columnas.IdSucursal.ToString())
         .IdUsuario = dr.Field(Of String)(Entidades.SucursalDepositoUsuario.Columnas.IdUsuario.ToString())
         .NombreUsuario = dr.Field(Of String)("Nombre")
         .Responsable = dr.Field(Of Boolean)(Entidades.SucursalDepositoUsuario.Columnas.Responsable.ToString())
         .UsuarioDefault = dr.Field(Of Boolean)(Entidades.SucursalDepositoUsuario.Columnas.UsuarioDefault.ToString())
         .PermitirEscritura = dr.Field(Of Boolean)(Entidades.SucursalDepositoUsuario.Columnas.PermitirEscritura.ToString())
      End With
   End Sub

#End Region
#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.SucursalDepositoUsuario)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.SucursalDepositoUsuario)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Merge(entidad As Entidades.SucursalDepositoUsuario)
      EjecutaSP(entidad, TipoSP._M)
   End Sub
   Public Sub _Borrar(entidad As Entidades.SucursalDepositoUsuario)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.SucursalDeposito)
      entidad.Usuarios.ForEach(
         Sub(u)
            u.IdDeposito = entidad.IdDeposito
            u.IdSucursal = entidad.IdSucursal
            _Insertar(u)
         End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.SucursalDeposito)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.SucursalDeposito)
      _Borrar(New Entidades.SucursalDepositoUsuario() With
                {
                  .IdDeposito = entidad.IdDeposito,
                  .IdSucursal = entidad.IdSucursal
                })
   End Sub

   Public Function GetUsuariosPorDepositos(idDeposito As Integer, idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() _GetUsuariosPorDepositos(idDeposito, idSucursal))
   End Function

   Private Function _GetUsuariosPorDepositos(idDeposito As Integer, idSucursal As Integer) As DataTable
      Return New SqlServer.SucursalesDepositosUsuarios(da).GetUsuariosPorDepositos(idDeposito, idSucursal)
   End Function

   Public Function GetSeguridadUsuariosDepositos(IdDeposito As Integer, PermiteEscritura As Boolean) As DataTable
      Return EjecutaConConexion(Function() _GetSeguridadUsuariosDepositos(IdDeposito, PermiteEscritura))
   End Function

   Private Function _GetSeguridadUsuariosDepositos(IdDeposito As Integer, PermiteEscritura As Boolean) As DataTable
      Return New SqlServer.SucursalesDepositosUsuarios(da).GetSeguridadUsuariosPorDepositos(IdDeposito, actual.Nombre, actual.Sucursal.IdSucursal, PermiteEscritura)
   End Function

   Public Sub InsertaSucursalesDepositos(usuarios As DataTable, idDeposito As Integer, idsucursal As Integer)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Dim sSDU = New SqlServer.SucursalesDepositosUsuarios(da)
         '-- Borra los usuarios Actuales.-
         sSDU.SucursalesDepositosUsuarios_D(idDeposito, idsucursal)
         '-- Incorpora usuarios nuevos.-
         If usuarios IsNot Nothing Then
            For Each dr As DataRow In usuarios.Rows
               sSDU.SucursalesDepositosUsuarios_I(idDeposito, idsucursal,
                                               dr("IdUsuario").ToString(),
                                               Boolean.Parse(dr("Responsable").ToString()),
                                               Boolean.Parse(dr("UsuarioDefault").ToString()),
                                               Boolean.Parse(dr("PermitirEscritura").ToString()))
            Next
         End If
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Function GetTodos(idDeposito As Integer, idSucursal As Integer) As List(Of Entidades.SucursalDepositoUsuario)
      Return CargaLista(_GetUsuariosPorDepositos(idDeposito, idSucursal),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.SucursalDepositoUsuario)
   End Function

#End Region
End Class
