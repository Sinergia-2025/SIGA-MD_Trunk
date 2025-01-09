Public Class Roles
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.Rol.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Protected Overridable Function GetSqlServer() As SqlServer.Roles
      Return New SqlServer.Roles(da)
   End Function

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Rol)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Rol)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Rol)))
   End Sub

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Roles(da).Roles_GA()
   End Function
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Roles(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.Rol, tipo As TipoSP)
      Dim sql = New SqlServer.Roles(da)
      Select Case tipo
         Case TipoSP._I
            sql.Roles_I(en.Id, en.Nombre, en.Descripcion)
         Case TipoSP._U
            sql.Roles_U(en.Id, en.Nombre, en.Descripcion)
         Case TipoSP._D
            sql.Roles_D(en.Id)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.Rol, dr As DataRow)
      With o
         .Id = dr.Field(Of String)(Entidades.Rol.Columnas.Id.ToString())
         .Nombre = dr.Field(Of String)(Entidades.Rol.Columnas.Nombre.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.Rol.Columnas.Descripcion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Públicos"
   Public Sub _Insertar(entidad As Entidades.Rol)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Rol)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Rol)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Function Get1(id As String) As DataTable
      Return New SqlServer.Roles(da).Roles_G1(id)
   End Function
   Public Function GetUno(id As String) As Entidades.Rol
      Return GetUno(id, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(id As String, accion As AccionesSiNoExisteRegistro) As Entidades.Rol
      Return CargaEntidad(Get1(id), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Rol(),
                          accion, Function() String.Format("No existe Rol con Id: {0}", id))
   End Function
   Public Function GetTodos() As List(Of Entidades.Rol)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Rol())
   End Function

#End Region

End Class
