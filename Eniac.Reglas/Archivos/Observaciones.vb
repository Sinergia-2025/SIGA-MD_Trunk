Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class Observaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Observaciones"
      da = New Datos.DataAccess()
   End Sub
   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Observaciones = New SqlServer.Observaciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Observaciones(Me.da).Observaciones_GA(String.Empty)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.Observacion = DirectCast(entidad, Entidades.Observacion)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.Observaciones = New SqlServer.Observaciones(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.Observaciones_I(en.IdObservacion, en.DetalleObservacion, en.Tipo)

            Case TipoSP._U
               sqlC.Observaciones_U(en.IdObservacion, en.DetalleObservacion, en.Tipo)

            Case TipoSP._D
               sqlC.Observaciones_D(en.IdObservacion)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Observacion, ByVal dr As DataRow)

      With o
         .IdObservacion = Integer.Parse(dr(Entidades.Observacion.Columnas.IdObservacion).ToString())
         .DetalleObservacion = dr(Entidades.Observacion.Columnas.DetalleObservacion).ToString()
         .Tipo = dr(Entidades.Observacion.Columnas.Tipo).ToString()
      End With

   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetTodos(tipo As String) As List(Of Entidades.Observacion)
      'Dim dt As DataTable = Me.GetAll2(True)
      Dim dt As DataTable = New SqlServer.Observaciones(Me.da).Observaciones_GA(tipo)
      Dim o As Entidades.Observacion
      Dim oLis As List(Of Entidades.Observacion) = New List(Of Entidades.Observacion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Observacion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal IdObservacion As Integer) As Entidades.Observacion
      Dim sql As SqlServer.Observaciones = New SqlServer.Observaciones(Me.da)
      Dim dt As DataTable = sql.Observaciones_G1(IdObservacion)
      Dim o As Entidades.Observacion = New Entidades.Observacion()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Observacion.")
      End If
      Return o
   End Function

   Public Function Get1(ByVal IdObservacion As Integer) As DataTable
      Dim sql As SqlServer.Observaciones = New SqlServer.Observaciones(Me.da)
      Return sql.Observaciones_G1(IdObservacion)
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim sql As SqlServer.Observaciones = New SqlServer.Observaciones(Me.da)
      Dim dt As DataTable = sql.Observaciones_GetCodigoMaximo()
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function GetPorNombre(ByVal detalleObservacion As String, ByVal Tipo As String) As DataTable

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.Observaciones = New SqlServer.Observaciones(Me.da)

         Return sql.Observaciones_GPorNombre(detalleObservacion, Tipo)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

#End Region

End Class

