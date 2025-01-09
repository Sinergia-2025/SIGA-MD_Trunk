Option Explicit On
Option Strict On

Imports System.Text

Public Class VentasPeriodos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "VentasPeriodos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "VentasPeriodos"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim period As Entidades.VentaPeriodo = DirectCast(entidad, Entidades.VentaPeriodo)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.VentasPeriodos = New SqlServer.VentasPeriodos(Me.da)
         Select Case tipo
            Case TipoSP._I
               sql.VentasPeriodos_I(period.IdPeriodo, period.DescripcionPeriodo, period.Dias)
            Case TipoSP._U
               sql.VentasPeriodos_U(period.IdPeriodo, period.DescripcionPeriodo, period.Dias)
            Case TipoSP._D
               sql.VentasPeriodos_D(period.IdPeriodo)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.VentaPeriodo)
      With o
         .IdPeriodo = Int32.Parse(dr("IdPeriodo").ToString())
         If Not String.IsNullOrEmpty(dr("DescripcionPeriodo").ToString()) Then
            .DescripcionPeriodo = dr("DescripcionPeriodo").ToString()
         End If
         If Not String.IsNullOrEmpty(dr("Dias").ToString()) Then
            .Dias = Int32.Parse(dr("Dias").ToString())
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.VentaPeriodo)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.VentaPeriodo
      Dim oLis As List(Of Entidades.VentaPeriodo) = New List(Of Entidades.VentaPeriodo)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.VentaPeriodo()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal idPeriodo As Int32) As Entidades.VentaPeriodo
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT IdPeriodo")
         .Append("      ,DescripcionPeriodo")
         .Append("      ,Dias")
         .Append("  FROM VentasPeriodos")
         .Append("  WHERE IdPeriodo = ")
         .Append(idPeriodo.ToString())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim o As Entidades.VentaPeriodo = New Entidades.VentaPeriodo()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(dr, o)
      Else
         Throw New Exception("No existe el Período")
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdPeriodo) AS maximo ")
         .Append(" FROM VentasPeriodo")
      End With

      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

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
      Dim stbQuery As StringBuilder = New StringBuilder("")
      entidad.Columna = "F." + entidad.Columna
      With stbQuery
         .Append("SELECT")
         .Append(" F.IdPeriodo")
         .Append(", F.DescripcionPeriodo ")
         .Append(", F.Dias ")
         .Append(" FROM  ")
         .Append(Me.NombreEntidad & " F ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.VentasPeriodos(Me.da).VentasPeriodos_GA()
   End Function

#End Region

End Class
