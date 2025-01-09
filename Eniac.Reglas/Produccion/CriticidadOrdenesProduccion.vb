Option Explicit On
Option Strict On

Imports System.Text

Public Class CriticidadesOrdenesProduccion
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CriticidadOrdenesProduccion"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.CriticidadOrdenesProduccion = New SqlServer.CriticidadOrdenesProduccion(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CriticidadOrdenesProduccion(Me.da).CriticidadOrdenesProduccion_GA(False)
   End Function

   Public Overloads Function GetAll(ByVal todos As Boolean) As System.Data.DataTable
      Return New SqlServer.CriticidadOrdenesProduccion(Me.da).CriticidadOrdenesProduccion_GA(todos)
   End Function



#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.CriticidadOrdenProduccion = DirectCast(entidad, Entidades.CriticidadOrdenProduccion)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.CriticidadOrdenesProduccion = New SqlServer.CriticidadOrdenesProduccion(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.CriticidadOrdenesProduccion_I(en.IdCriticidad, en.Orden)

            Case TipoSP._U
               sql.CriticidadOrdenesProduccion_U(en.IdCriticidad, en.Orden)

            Case TipoSP._D
               sql.CriticidadOrdenesProduccion_D(en.IdCriticidad)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUna(ByVal o As Entidades.CriticidadOrdenProduccion, ByVal dr As DataRow)
      With o
         .IdCriticidad = dr(Entidades.CriticidadOrdenProduccion.Columnas.IdCriticidad.ToString()).ToString()
         .Orden = Integer.Parse(dr(Entidades.CriticidadOrdenProduccion.Columnas.Orden.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodosPorOrden() As DataTable
      Dim sql As SqlServer.CriticidadOrdenesProduccion = New SqlServer.CriticidadOrdenesProduccion(Me.da)
      Return sql.GetTodosPorOrden()
   End Function

   Public Function GetTodos() As List(Of Entidades.CriticidadOrdenProduccion)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.CriticidadOrdenProduccion
      Dim oLis As List(Of Entidades.CriticidadOrdenProduccion) = New List(Of Entidades.CriticidadOrdenProduccion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CriticidadOrdenProduccion()
         Me.CargarUna(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal IdCriticidad As String) As Entidades.CriticidadOrdenProduccion
      Dim sql As SqlServer.CriticidadOrdenesProduccion = New SqlServer.CriticidadOrdenesProduccion(Me.da)
      Dim dt As DataTable = sql.CriticidadOrdenesProduccion_G1(IdCriticidad)
      Dim o As Entidades.CriticidadOrdenProduccion = New Entidades.CriticidadOrdenProduccion()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0))
      Else
         Throw New Exception("No existe El Estado.")
      End If
      Return o
   End Function

   Public Function Get1(ByVal IdCriticidad As String) As DataTable
      Dim sql As SqlServer.CriticidadOrdenesProduccion = New SqlServer.CriticidadOrdenesProduccion(Me.da)
      Return sql.CriticidadOrdenesProduccion_G1(IdCriticidad)
   End Function

   Public Function GetTodosPorOrden(ByVal IdCriticidad As String) As DataTable
      Dim sql As SqlServer.CriticidadOrdenesProduccion = New SqlServer.CriticidadOrdenesProduccion(Me.da)
      Return sql.GetTodosPorOrden()
   End Function

#End Region

End Class

