Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports Eniac.Datos

#End Region

Public Class RecepcionEstados
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "RecepcionEstadosV"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

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

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT ")
         .Append(" IdSector ")
         .Append(", NombreSector ")
         .Append(", LetraSector ")
         .Append("FROM  ")
         .Append("Sectores ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RecepcionEstados(Me.da).RecepcionEstados_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim sec As Entidades.RecepcionEstado = DirectCast(entidad, Entidades.RecepcionEstado)

      Dim sql As SqlServer.RecepcionEstados = New SqlServer.RecepcionEstados(Me.da)
      Select Case tipo
         Case TipoSP._I
            '
         Case TipoSP._U
            '
         Case TipoSP._D
            '
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.RecepcionEstado, ByVal dr As DataRow)
      With o
         .IdEstado = Integer.Parse(dr("IdEstado").ToString())
         .NombreEstado = dr("NombreEstado").ToString()
         If Not String.IsNullOrEmpty(dr("Reporte").ToString()) Then
            .Reporte = dr("Reporte").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.RecepcionEstado)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.RecepcionEstado
      Dim oLis As List(Of Entidades.RecepcionEstado) = New List(Of Entidades.RecepcionEstado)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.RecepcionEstado()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal idEstado As Integer) As Entidades.RecepcionEstado
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT IdEstado")
         .AppendLine("      ,NombreEstado")
         .AppendLine("      ,Reporte")
         .Append("  FROM RecepcionEstados")
         .AppendFormat("  WHERE IdEstado = '{0}'", idEstado)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim o As Entidades.RecepcionEstado = New Entidades.RecepcionEstado()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el estado.")
      End If
      Return o
   End Function

#End Region

End Class
