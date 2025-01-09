Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports System.Text
Public Class PlanesTarjetas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "PlanesTarjetas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "PlanesTarjetas"
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.PlanesTarjetas(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.PlanesTarjetas(Me.da).PlanesTarjetas_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.PlanesTarjetas(Me.da).GetCodigoMaximo()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.PlanTarjeta = DirectCast(entidad, Entidades.PlanTarjeta)
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.PlanesTarjetas = New SqlServer.PlanesTarjetas(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.PlanesTarjetas_I(en.IdPlanTarjeta, en.NombrePlanTarjeta, en.CuotasDesde, en.CuotasHasta,
                                     en.PorcDescRec, en.IdTarjeta, en.IdBanco, en.Activo, en.PorcDescRecDom,
                                     en.PorcDescRecLun, en.PorcDescRecMar, en.PorcDescRecMie, en.PorcDescRecJue,
                                     en.PorcDescRecVie, en.PorcDescRecSab)
            Case TipoSP._U
               sqlC.PlanesTarjetas_U(en.IdPlanTarjeta, en.NombrePlanTarjeta, en.CuotasDesde, en.CuotasHasta,
                                     en.PorcDescRec, en.IdTarjeta, en.IdBanco, en.Activo, en.PorcDescRecDom,
                                     en.PorcDescRecLun, en.PorcDescRecMar, en.PorcDescRecMie, en.PorcDescRecJue,
                                     en.PorcDescRecVie, en.PorcDescRecSab)
            Case TipoSP._D
               sqlC.PlanesTarjetas_D(en.IdPlanTarjeta)
         End Select

         If blnAbreConexion Then da.CommitTransaction()
      Catch ex As Exception
         If blnAbreConexion Then da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.PlanTarjeta, ByVal dr As DataRow)
      With o
         .IdPlanTarjeta = Integer.Parse(dr(PlanTarjeta.Columnas.IdPlanTarjeta.ToString()).ToString())
         .NombrePlanTarjeta = dr(PlanTarjeta.Columnas.NombrePlanTarjeta.ToString()).ToString()

         .CuotasDesde = Integer.Parse(dr(PlanTarjeta.Columnas.CuotasDesde.ToString()).ToString())
         .CuotasHasta = Integer.Parse(dr(PlanTarjeta.Columnas.CuotasHasta.ToString()).ToString())
         .PorcDescRec = Decimal.Parse(dr(PlanTarjeta.Columnas.PorcDescRec.ToString()).ToString())
         '-- REQ-34584.- -----------------------------------------------------------------------------------
         .PorcDescRecDom = CBool(dr(PlanTarjeta.Columnas.PorcDescRecDom.ToString()).ToString())
         .PorcDescRecLun = CBool(dr(PlanTarjeta.Columnas.PorcDescRecLun.ToString()).ToString())
         .PorcDescRecMar = CBool(dr(PlanTarjeta.Columnas.PorcDescRecMar.ToString()).ToString())
         .PorcDescRecMie = CBool(dr(PlanTarjeta.Columnas.PorcDescRecMie.ToString()).ToString())
         .PorcDescRecJue = CBool(dr(PlanTarjeta.Columnas.PorcDescRecJue.ToString()).ToString())
         .PorcDescRecVie = CBool(dr(PlanTarjeta.Columnas.PorcDescRecVie.ToString()).ToString())
         .PorcDescRecSab = CBool(dr(PlanTarjeta.Columnas.PorcDescRecSab.ToString()).ToString())
         '--------------------------------------------------------------------------------------------------
         If Not String.IsNullOrWhiteSpace(dr(PlanTarjeta.Columnas.IdTarjeta.ToString()).ToString()) Then
            .Tarjeta = New Tarjetas(da)._GetUno(Integer.Parse(dr(PlanTarjeta.Columnas.IdTarjeta.ToString()).ToString()))
         End If
         If Not String.IsNullOrWhiteSpace(dr(PlanTarjeta.Columnas.IdBanco.ToString()).ToString()) Then
            .Banco = New Bancos().GetUno(Integer.Parse(dr(PlanTarjeta.Columnas.IdBanco.ToString()).ToString()))
         End If
         .Activo = CBool(dr(PlanTarjeta.Columnas.Activo.ToString()))
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idPlanTarjeta As Integer) As Entidades.PlanTarjeta
      Dim dt As DataTable = New SqlServer.PlanesTarjetas(Me.da).PlanesTarjetas_G1(idPlanTarjeta)
      Dim o As Entidades.PlanTarjeta = New Entidades.PlanTarjeta()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.PlanTarjeta)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.PlanTarjeta
      Dim oLis As List(Of Entidades.PlanTarjeta) = New List(Of Entidades.PlanTarjeta)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.PlanTarjeta()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Function GetPlanesActivos() As List(Of Entidades.PlanTarjeta)
      Dim dt As DataTable = New SqlServer.PlanesTarjetas(Me.da).PlanesTarjetas_GActivos()
      Dim o As Entidades.PlanTarjeta
      Dim oLis As List(Of Entidades.PlanTarjeta) = New List(Of Entidades.PlanTarjeta)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.PlanTarjeta()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class
