#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class TiposListasMetas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposListasMetas"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposListasMetas"
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
   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sExcepciones As SqlServer.TiposListasMetas = New SqlServer.TiposListasMetas(da)
      Return sExcepciones.TiposListasMetas_GA()
   End Function



#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.TipoListaMeta = DirectCast(entidad, Entidades.TipoListaMeta)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.TiposListasMetas = New SqlServer.TiposListasMetas(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.TiposListasMetas_I(en.IdListaControlTipo, en.Dia, en.MetaCoches, en.IdUsuario, en.FechaModificacion)
            Case TipoSP._U
               sqlC.TiposListasMetas_U(en.IdListaControlTipo, en.Dia, en.MetaCoches, en.IdUsuario, en.FechaModificacion)
            Case TipoSP._D
               sqlC.TiposListasMetas_D(en.IdListaControlTipo, en.Dia)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoListaMeta, ByVal dr As DataRow)
      With o
         .IdListaControlTipo = Integer.Parse(dr(Entidades.TipoListaMeta.Columnas.IdListaControlTipo.ToString()).ToString())
         .Dia = Date.Parse(dr(Entidades.TipoListaMeta.Columnas.Dia.ToString()).ToString())
         .MetaCoches = Integer.Parse(dr(Entidades.TipoListaMeta.Columnas.MetaCoches.ToString()).ToString())
         .IdUsuario = dr(Entidades.TipoListaMeta.Columnas.IdUsuario.ToString()).ToString()
         .FechaModificacion = DateTime.Parse(dr(Entidades.TipoListaMeta.Columnas.FechaModificacion.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Function GetUno(IdListaControlTipo As Integer, Dia As Date) As Entidades.TipoListaMeta
      Dim sMetas As SqlServer.TiposListasMetas = New SqlServer.TiposListasMetas(da)
      Return CargaEntidad(sMetas.TiposListasMetas_G1(IdListaControlTipo, Dia),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoListaMeta(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe la Meta {0}", Dia))
   End Function

   Public Function GetTodas() As List(Of Entidades.TipoListaMeta)
      Dim dt As DataTable = New SqlServer.TiposListasMetas(da).TiposListasMetas_GA()
      Dim o As Entidades.TipoListaMeta
      Dim oLis As List(Of Entidades.TipoListaMeta) = New List(Of Entidades.TipoListaMeta)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoListaMeta()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetMetas(fechaDesde As Date, fechaHasta As Date) As System.Data.DataTable
      Dim sExcepciones As SqlServer.TiposListasMetas = New SqlServer.TiposListasMetas(da)
      Return sExcepciones.TiposListasMetas_GMetas(fechaDesde, fechaHasta)
   End Function

   Public Function GetTotalMetasPorMes(IdListaControlTipo As Integer, fechaDesde As Date, fechaHasta As Date) As Integer
      Dim sExcepciones As SqlServer.TiposListasMetas = New SqlServer.TiposListasMetas(da)
      Return sExcepciones.TiposListasMetas_GMetasTotalPorMes(IdListaControlTipo, fechaDesde, fechaHasta)
   End Function

#End Region

End Class