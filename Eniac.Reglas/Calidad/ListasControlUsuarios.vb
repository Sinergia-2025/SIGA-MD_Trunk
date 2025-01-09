#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ListasControlUsuarios
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ListasControlUsuarios"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ListasControlUsuarios"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub


#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.ListaControlUsuario = DirectCast(entidad, Entidades.ListaControlUsuario)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlUsuarios = New SqlServer.ListasControlUsuarios(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ListasControlUsuarios_I(en.IdListaControl, en.IdUsuario)
            Case TipoSP._U
               sqlC.ListasControlUsuarios_U(en.IdListaControl, en.IdUsuario)
            Case TipoSP._D
               sqlC.ListasControlUsuarios_D(en.IdListaControl)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ListaControlUsuario, ByVal dr As DataRow)
      With o
         .IdListaControl = Integer.Parse(dr(Entidades.ListaControlUsuario.Columnas.IdListaControl.ToString()).ToString())
         .IdUsuario = dr(Entidades.ListaControlUsuario.Columnas.IdUsuario.ToString()).ToString()
         .NombreListaControl = dr(Entidades.ListaControl.Columnas.NombreListaControl.ToString()).ToString()
         .Nombre = dr(Entidades.Usuario.Columnas.Nombre.ToString()).ToString()

      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Overloads Sub Borrar(IdListaControl As Integer)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlUsuarios = New SqlServer.ListasControlUsuarios(da)
         sqlC.ListasControlUsuarios_D(IdListaControl)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(listasControlUsuarios As List(Of Entidades.ListaControlUsuario))
      For Each Item As Entidades.ListaControlUsuario In ListasControlUsuarios
         Me.EjecutaSP(Item, TipoSP._I)
      Next
   End Sub


   Public Function GetTodas(IdListaControl As Integer) As List(Of Entidades.ListaControlUsuario)
      Dim dt As DataTable = New SqlServer.ListasControlUsuarios(da).ListasControlUsuarios_GA(IdListaControl)
      Dim o As Entidades.ListaControlUsuario
      Dim oLis As List(Of Entidades.ListaControlUsuario) = New List(Of Entidades.ListaControlUsuario)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ListaControlUsuario()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUsuariosxListaControl(IdListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlUsuarios(da).ListasControlUsuarios_GA(IdListaControl)
      Return dt
   End Function

   Public Sub Guardar(ListaControl As Entidades.ListaControl, dtListasControlUsuarios As DataTable)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.ListasControlUsuarios = New SqlServer.ListasControlUsuarios(da)
         sql.ListasControlUsuarios_D(ListaControl.IdListaControl)

         For Each drListaControlUsuario As DataRow In dtListasControlUsuarios.Rows
            sql.ListasControlUsuarios_I(Integer.Parse(drListaControlUsuario(Entidades.ListaControlUsuario.Columnas.IdListaControl.ToString()).ToString()),
                                     drListaControlUsuario(Entidades.ListaControlUsuario.Columnas.IdUsuario.ToString()).ToString())
         Next

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub
#End Region

End Class