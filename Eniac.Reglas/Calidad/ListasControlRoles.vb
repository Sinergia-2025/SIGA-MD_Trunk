#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ListasControlRoles
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ListasControlRoles"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ListasControlRoles"
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
         Dim en As Entidades.ListaControlRol = DirectCast(entidad, Entidades.ListaControlRol)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlRoles = New SqlServer.ListasControlRoles(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ListasControlRoles_I(en.IdListaControl, en.IdRol)
            Case TipoSP._U
               sqlC.ListasControlRoles_U(en.IdListaControl, en.IdRol)
            Case TipoSP._D
               sqlC.ListasControlRoles_D(en.IdListaControl)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ListaControlRol, ByVal dr As DataRow)
      With o
         .IdListaControl = Integer.Parse(dr(Entidades.ListaControlRol.Columnas.IdListaControl.ToString()).ToString())
         .IdRol = dr(Entidades.ListaControlRol.Columnas.IdRol.ToString()).ToString()
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

         Dim sqlC As SqlServer.ListasControlRoles = New SqlServer.ListasControlRoles(da)
         sqlC.ListasControlRoles_D(IdListaControl)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(ListasControlRoles As List(Of Entidades.ListaControlRol))
      For Each Item As Entidades.ListaControlRol In ListasControlRoles
         Me.EjecutaSP(Item, TipoSP._I)
      Next
   End Sub


   Public Function GetTodas(IdListaControl As Integer) As List(Of Entidades.ListaControlRol)
      Dim dt As DataTable = New SqlServer.ListasControlRoles(da).ListasControlRoles_GA(IdListaControl)
      Dim o As Entidades.ListaControlRol
      Dim oLis As List(Of Entidades.ListaControlRol) = New List(Of Entidades.ListaControlRol)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ListaControlRol()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetRolesxListaControl(IdListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlRoles(da).ListasControlRoles_GA(IdListaControl)
      Return dt
   End Function

   Public Sub Guardar(ListaControl As Entidades.ListaControl, dtListasControlRoles As DataTable)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.ListasControlRoles = New SqlServer.ListasControlRoles(da)
         sql.ListasControlRoles_D(ListaControl.IdListaControl)

         For Each drListaControlRol As DataRow In dtListasControlRoles.Rows
            sql.ListasControlRoles_I(Integer.Parse(drListaControlRol(Entidades.ListaControlRol.Columnas.IdListaControl.ToString()).ToString()),
                                     drListaControlRol(Entidades.ListaControlRol.Columnas.IdRol.ToString()).ToString())
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