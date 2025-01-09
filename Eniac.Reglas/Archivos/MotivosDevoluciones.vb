Option Explicit On
Option Strict On

#Region "Imports"

Imports Eniac.Entidades
Imports System.Text

#End Region
Public Class MotivosDevoluciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "MotivosDevoluciones"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "MotivosDevoluciones"
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
      Return New SqlServer.MotivosDevoluciones(da).Buscar(entidad)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MotivosDevoluciones(Me.da).MotivosDevoluciones_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim MotivoDevolucion As Entidades.MotivoDevolucion = DirectCast(entidad, Entidades.MotivoDevolucion)
      Dim sql As SqlServer.MotivosDevoluciones = New SqlServer.MotivosDevoluciones(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.MotivosDevoluciones_I(MotivoDevolucion.IdMotivoDevolucion, MotivoDevolucion.NombreMotivoDevolucion)
         Case TipoSP._U
            sql.MotivosDevoluciones_U(MotivoDevolucion.IdMotivoDevolucion, MotivoDevolucion.NombreMotivoDevolucion)
         Case TipoSP._D
            sql.MotivosDevoluciones_D(MotivoDevolucion.IdMotivoDevolucion)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.MotivoDevolucion, ByVal dr As DataRow)
      With o
         .IdMotivoDevolucion = Integer.Parse(dr(Entidades.MotivoDevolucion.Columnas.IdMotivoDevolucion.ToString()).ToString())
         .NombreMotivoDevolucion = dr(Entidades.MotivoDevolucion.Columnas.NombreMotivoDevolucion.ToString()).ToString()
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

   Public Function GetTodos() As List(Of Entidades.MotivoDevolucion)
      Try
         Me.da.OpenConection()
         Return _GetTodos()
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function _GetTodos() As List(Of Entidades.MotivoDevolucion)
      Try
         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.MotivoDevolucion
         Dim oLis As List(Of Entidades.MotivoDevolucion) = New List(Of Entidades.MotivoDevolucion)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.MotivoDevolucion()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      Catch
         Throw
      End Try
   End Function

   Public Function GetUna(ByVal idMotivoDevolucion As Integer) As Entidades.MotivoDevolucion
      Dim sql As SqlServer.MotivosDevoluciones = New SqlServer.MotivosDevoluciones(Me.da)
      Dim dt As DataTable = sql.MotivosDevoluciones_G1(idMotivoDevolucion)
      Dim o As Entidades.MotivoDevolucion = New Entidades.MotivoDevolucion()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Motivo de Devolucion.")
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MotivosDevoluciones(da).GetCodigoMaximo()
   End Function

#End Region

End Class
