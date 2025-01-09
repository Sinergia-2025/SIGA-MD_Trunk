
Option Explicit On
Option Strict On

Public Class ContabilidadCentrosCostos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContabilidadCentrosCostos"
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
      Dim sql As SqlServer.ContabilidadCentrosCostos = New SqlServer.ContabilidadCentrosCostos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ContabilidadCentrosCostos(Me.da).CentrosCostos_GA()
   End Function

#End Region

#Region "Metodos Privados"



   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.ContabilidadCentroCosto = DirectCast(entidad, Entidades.ContabilidadCentroCosto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadCentrosCostos = New SqlServer.ContabilidadCentrosCostos(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.CentrosCostos_I(en.IdCentroCosto, en.NombreCentroCosto)

            Case TipoSP._U
               sql.CentrosCostos_U(en.IdCentroCosto, en.NombreCentroCosto)

            Case TipoSP._D
               sql.CentrosCostos_D(en.IdCentroCosto)

         End Select

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUna(ByVal o As Entidades.ContabilidadCentroCosto, ByVal dr As DataRow)
      With o
         .IdCentroCosto = Integer.Parse(dr(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).ToString())
         .NombreCentroCosto = dr(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ContabilidadCentroCosto)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ContabilidadCentroCosto
      Dim oLis As List(Of Entidades.ContabilidadCentroCosto) = New List(Of Entidades.ContabilidadCentroCosto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ContabilidadCentroCosto()
         Me.CargarUna(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal codCentroCosto As Integer) As Entidades.ContabilidadCentroCosto
      Try
         Me.da.OpenConection()
         Return Me._GetUna(codCentroCosto)
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Friend Function _GetUna(ByVal idCentroCosto As Integer) As Entidades.ContabilidadCentroCosto
      Dim sql As SqlServer.ContabilidadCentrosCostos = New SqlServer.ContabilidadCentrosCostos(Me.da)
      Dim dt As DataTable = sql.CentrosCostos_G1(idCentroCosto)
      Dim o As Entidades.ContabilidadCentroCosto = New Entidades.ContabilidadCentroCosto()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0))
      Else
         Throw New Exception(String.Format("No existe el Centro de Costo {0}.", idCentroCosto))
      End If
      Return o
   End Function

   Public Function Get1(ByVal codCentroCosto As Integer) As DataTable
      Dim sql As SqlServer.ContabilidadCentrosCostos = New SqlServer.ContabilidadCentrosCostos(Me.da)
      Return sql.CentrosCostos_G1(codCentroCosto)
   End Function

   Public Function GetPorCodigo(ByVal idCentroCosto As Integer) As DataTable
      Return New SqlServer.ContabilidadCentrosCostos(Me.da).GetPorCodigoNombre(idCentroCosto, String.Empty)
   End Function
   Public Function GetPorNombre(ByVal nombreCentroCosto As String) As DataTable
      Return New SqlServer.ContabilidadCentrosCostos(Me.da).GetPorCodigoNombre(Nothing, nombreCentroCosto)
   End Function

   Public Function GetIdMaximo() As Integer

      Dim sql As SqlServer.ContabilidadCentrosCostos = New SqlServer.ContabilidadCentrosCostos(Me.da)
      Dim dt As DataTable = sql.CentrosCosto_GetIdMaximo()
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region
End Class
