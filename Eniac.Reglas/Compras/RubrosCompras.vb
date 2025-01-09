Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports Eniac.Reglas.ServiciosRest.Sincronizacion

#End Region

Public Class RubrosCompras
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte, Entidades.JSonEntidades.Archivos.RubroCompraJson)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte, Entidades.JSonEntidades.Archivos.RubroCompraJson)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "RubrosCompras"
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      entidad.Columna = "R." + entidad.Columna

      'If entidad.Columna = "R.NombreCuentaCaja" Then entidad.Columna = "C." + entidad.Columna.Replace("R.", "")

      Me.SelectFiltrado(stbQuery)

      With stbQuery
         .Append("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RubrosCompras(Me.da).RubrosCompras_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Try
         Dim ent As Entidades.RubroCompra = DirectCast(entidad, Entidades.RubroCompra)

         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.RubrosCompras = New SqlServer.RubrosCompras(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.RubrosCompras_I(ent.IdRubro, ent.NombreRubro)

            Case TipoSP._U
               sql.RubrosCompras_U(ent.IdRubro, ent.NombreRubro)

            Case TipoSP._D
               sql.RubrosCompras_D(ent.IdRubro)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.RubroCompra, ByVal dr As DataRow)

      With o
         .IdRubro = Integer.Parse(dr("IdRubro").ToString())
         .NombreRubro = dr("NombreRubro").ToString()
      End With

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetPorCodigo(ByVal IdRubro As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Me.SelectFiltrado(stb)

      With stb
         If IdRubro > 0 Then
            .AppendLine("	WHERE R.IdRubro = " & IdRubro.ToString())
         End If
         .AppendLine("	ORDER BY R.NombreRubro")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Me.SelectFiltrado(stb)

      With stb
         .AppendLine("	WHERE R.NombreRubro LIKE '%" & nombre & "%' ")
         .AppendLine("	ORDER BY R.NombreRubro")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetUno(ByVal idRubro As Int32) As Entidades.RubroCompra
      Dim stb As StringBuilder = New StringBuilder("")
      Me.SelectFiltrado(stb)
      With stb
         .AppendLine(" WHERE R.IdRubro = " & idRubro.ToString())
      End With
      Dim dt As DataTable = Me.DataServer.GetDataTable(stb.ToString())
      Dim en As Entidades.RubroCompra = New Entidades.RubroCompra()
      If dt.Rows.Count > 0 Then
         en.IdRubro = Integer.Parse(dt.Rows(0)("IdRubro").ToString())
         en.NombreRubro = dt.Rows(0)("NombreRubro").ToString()
      End If
      Return en
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdRubro) AS maximo FROM RubrosCompras")
      End With

      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())

      Return Integer.Parse(dt.Rows(0)("maximo").ToString())

   End Function

   Private Sub SelectFiltrado(ByRef stb As StringBuilder)

      With stb
         .Length = 0
         .AppendLine("SELECT R.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("  FROM RubrosCompras R")
      End With

   End Sub
   Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT R.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("  FROM RubrosCompras R")
         .AppendLine(" WHERE R.NombreRubro = '" & nombre & "' ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetTodos() As List(Of Entidades.RubroCompra)
      Try
         Me.da.OpenConection()
         Return _GetTodos()
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function _GetTodos() As List(Of Entidades.RubroCompra)
      Try
         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.RubroCompra
         Dim oLis As List(Of Entidades.RubroCompra) = New List(Of Entidades.RubroCompra)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.RubroCompra()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      Catch
         Throw
      End Try
   End Function

#End Region

End Class