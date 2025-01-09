Option Explicit On
Option Strict On

#Region "Imports"

Imports Eniac.Entidades
Imports System.Text

#End Region
Public Class EstadosVisitas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "EstadosVisitas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "EstadosVisitas"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Inserta(entidad)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Actualiza(entidad)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.EstadosVisitas(da).Buscar(entidad)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(Nothing, Nothing)
   End Function

   Public Overloads Function GetAll(admitePedidoSinLineas As Boolean?, admintePedidoConLineas As Boolean?) As System.Data.DataTable
      Return New SqlServer.EstadosVisitas(Me.da).EstadosVisitas_GA(admitePedidoSinLineas, admintePedidoConLineas)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim EstadoVisita As Entidades.EstadoVisita = DirectCast(entidad, Entidades.EstadoVisita)
      Dim sql As SqlServer.EstadosVisitas = New SqlServer.EstadosVisitas(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.EstadosVisitas_I(EstadoVisita.IdEstadoVisita, EstadoVisita.NombreEstadoVisita, EstadoVisita.AdmitePedidoSinLineas, EstadoVisita.AdmintePedidoConLineas)
         Case TipoSP._U
            sql.EstadosVisitas_U(EstadoVisita.IdEstadoVisita, EstadoVisita.NombreEstadoVisita, EstadoVisita.AdmitePedidoSinLineas, EstadoVisita.AdmintePedidoConLineas)
         Case TipoSP._D
            sql.EstadosVisitas_D(EstadoVisita.IdEstadoVisita)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EstadoVisita, ByVal dr As DataRow)
      With o
         .IdEstadoVisita = Integer.Parse(dr(Entidades.EstadoVisita.Columnas.IdEstadoVisita.ToString()).ToString())
         .NombreEstadoVisita = dr(Entidades.EstadoVisita.Columnas.NombreEstadoVisita.ToString()).ToString()
         .AdmitePedidoSinLineas = Boolean.Parse(dr(Entidades.EstadoVisita.Columnas.AdmitePedidoSinLineas.ToString()).ToString())
         .AdmintePedidoConLineas = Boolean.Parse(dr(Entidades.EstadoVisita.Columnas.AdmintePedidoConLineas.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Function GetTodos() As List(Of Entidades.EstadoVisita)
      Try
         Me.da.OpenConection()
         Return _GetTodos(Nothing, Nothing)
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetTodos(admitePedidoSinLineas As Boolean?, admintePedidoConLineas As Boolean?) As List(Of Entidades.EstadoVisita)
      Try
         Me.da.OpenConection()
         Return _GetTodos(admitePedidoSinLineas, admintePedidoConLineas)
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function _GetTodos(admitePedidoSinLineas As Boolean?, admintePedidoConLineas As Boolean?) As List(Of Entidades.EstadoVisita)
      Try
         Dim dt As DataTable = Me.GetAll(admitePedidoSinLineas, admintePedidoConLineas)
         Dim o As Entidades.EstadoVisita
         Dim oLis As List(Of Entidades.EstadoVisita) = New List(Of Entidades.EstadoVisita)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.EstadoVisita()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      Catch
         Throw
      End Try
   End Function

   Public Function GetUno(ByVal idEstadoVisita As Integer) As Entidades.EstadoVisita
      Dim sql As SqlServer.EstadosVisitas = New SqlServer.EstadosVisitas(Me.da)
      Dim dt As DataTable = sql.EstadosVisitas_G1(idEstadoVisita)
      Dim o As Entidades.EstadoVisita = New Entidades.EstadoVisita()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Estado de Visita.")
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.EstadosVisitas(da).GetCodigoMaximo()
   End Function

#End Region

End Class
