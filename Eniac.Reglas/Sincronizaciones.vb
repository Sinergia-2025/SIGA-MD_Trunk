#Region "Imports"

Imports System.Text

#End Region

Public Class Sincronizaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SincronizaRegistros"
      da = New Datos.DataAccess()
   End Sub
   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub BorraRegistro(ByVal id As Integer)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Comunes = New SqlServer.Comunes(Me.da)
         sql.SincronizaRegistro_D(id)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub BorrarRegistros(ByVal idSucursalDestino As Integer)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Comunes = New SqlServer.Comunes(Me.da)
         sql.SincronizaRegistros_D(idSucursalDestino)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub CambiarEstadoRegistros(ByVal idSucursalDestino As Integer)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Comunes = New SqlServer.Comunes(Me.da)
         sql.SincronizaRegistros_UEstado(idSucursalDestino)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub InsertarRegistros(ByVal registros As List(Of Entidades.SincronizaRegistro))
      Try
         da.OpenConection()
         da.BeginTransaction()

         For Each reg As Entidades.SincronizaRegistro In registros
            Me.EjecutaSP(reg, TipoSP._I)
         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub InsertaRegistro(ByVal reg As Entidades.SincronizaRegistro)
      Try
         da.OpenConection()
         da.BeginTransaction()

         reg.Estado = "E" 'esperando ser recuperado
         Me.EjecutaSP(reg, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub EjecutaSPyEliminaRegistros(ByVal reg As Entidades.SincronizaRegistro)
      Try
         da.OpenConection()
         da.BeginTransaction()

         reg.Estado = "T" 'esperando ser recuperado
         Me.EjecutaQuerySP(reg.Query.Replace("´", "'"))
         Me.EjecutaSP_D(reg.Id)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal sincro As Entidades.SincronizaRegistro, ByVal tipo As TipoSP)
      Dim sql As SqlServer.Comunes = New SqlServer.Comunes(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.SincronizaRegistros_I(sincro.FechaHora.Value, sincro.SucursalOrigen, sincro.SucursalDestino, sincro.Query, sincro.Tabla, sincro.FechaHoraProceso.Value, sincro.Estado)
         Case TipoSP._U
         Case TipoSP._D
            sql.SincronizaRegistros_D(sincro.SucursalDestino)
      End Select

   End Sub
   Private Sub EjecutaSP_D(ByVal id As Long)
      Dim sql As SqlServer.Comunes = New SqlServer.Comunes(Me.da)
      sql.SincronizaRegistro_D(id)
   End Sub
   Private Sub EjecutaQuerySP(ByVal query As String)
      Dim sql As SqlServer.Comunes = New SqlServer.Comunes(Me.da)
      sql.SincronizaQuery_I(query)

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.SincronizaRegistro)
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT [Id]")
         .Append("      ,[FechaHora]")
         .Append("      ,[SucursalOrigen]")
         .Append("      ,[SucursalDestino]")
         .Append("      ,[Query]")
         .Append("      ,[Tabla]")
         .Append("      ,[FechaHoraProceso]")
         .Append("      ,[Estado]")
         .Append("  FROM [SincronizaRegistros]")
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())
      Dim o As Entidades.SincronizaRegistro
      Dim oLis As List(Of Entidades.SincronizaRegistro) = New List(Of Entidades.SincronizaRegistro)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SincronizaRegistro()
         With o
            .Id = Int32.Parse(dr("Id").ToString())
            .FechaHora = DateTime.Parse(dr("FechaHora").ToString())
            .SucursalOrigen = Int32.Parse(dr("SucursalOrigen").ToString())
            .SucursalDestino = Int32.Parse(dr("SucursalDestino").ToString())
            .Query = dr("Query").ToString()
            .Tabla = dr("Tabla").ToString()
            If Not String.IsNullOrEmpty(dr("FechaHoraProceso").ToString()) Then
               .FechaHoraProceso = DateTime.Parse(dr("FechaHoraProceso").ToString())
            End If
            .Estado = dr("Estado").ToString()
         End With
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Function GetPorSucursal(ByVal idSucursalDestino As Integer) As List(Of Entidades.SincronizaRegistro)
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT [Id]")
         .Append("      ,[FechaHora]")
         .Append("      ,[SucursalOrigen]")
         .Append("      ,[SucursalDestino]")
         .Append("      ,[Query]")
         .Append("      ,[Tabla]")
         .Append("      ,[FechaHoraProceso]")
         .Append("      ,[Estado]")
         .Append("  FROM [SincronizaRegistros]")
         .Append("  WHERE ")
         .Append("  SucursalDestino =")
         .Append(idSucursalDestino)
         .Append(" ORDER BY Id")
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())
      Dim o As Entidades.SincronizaRegistro
      Dim oLis As List(Of Entidades.SincronizaRegistro) = New List(Of Entidades.SincronizaRegistro)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SincronizaRegistro()
         With o
            .Id = Int32.Parse(dr("Id").ToString())
            .FechaHora = DateTime.Parse(dr("FechaHora").ToString())
            .SucursalOrigen = Int32.Parse(dr("SucursalOrigen").ToString())
            .SucursalDestino = Int32.Parse(dr("SucursalDestino").ToString())
            .Query = dr("Query").ToString()
            .Tabla = dr("Tabla").ToString()
            If Not String.IsNullOrEmpty(dr("FechaHoraProceso").ToString()) Then
               .FechaHoraProceso = DateTime.Parse(dr("FechaHoraProceso").ToString())
            End If
            .Estado = dr("Estado").ToString()
         End With
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Function GetDistintoALaSucursal(ByVal idSucursalDestino As Integer) As List(Of Entidades.SincronizaRegistro)
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT [Id]")
         .Append("      ,[FechaHora]")
         .Append("      ,[SucursalOrigen]")
         .Append("      ,[SucursalDestino]")
         .Append("      ,[Query]")
         .Append("      ,[Tabla]")
         .Append("      ,[FechaHoraProceso]")
         .Append("      ,[Estado]")
         .Append("  FROM [SincronizaRegistros]")
         .Append("  WHERE ")
         .Append("  SucursalDestino <>")
         .Append(idSucursalDestino.ToString())
         .Append(" ORDER BY Id")
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())
      Dim o As Entidades.SincronizaRegistro
      Dim oLis As List(Of Entidades.SincronizaRegistro) = New List(Of Entidades.SincronizaRegistro)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SincronizaRegistro()
         With o
            .Id = Int32.Parse(dr("Id").ToString())
            .FechaHora = DateTime.Parse(dr("FechaHora").ToString())
            .SucursalOrigen = Int32.Parse(dr("SucursalOrigen").ToString())
            .SucursalDestino = Int32.Parse(dr("SucursalDestino").ToString())
            .Query = dr("Query").ToString()
            .Tabla = dr("Tabla").ToString()
            .FechaHoraProceso = Nothing
            If Not String.IsNullOrEmpty(dr("FechaHoraProceso").ToString()) Then
               .FechaHoraProceso = DateTime.Parse(dr("FechaHoraProceso").ToString())
            End If
            .Estado = dr("Estado").ToString()
         End With
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Sub SincronizarRegistros(ByVal registros As List(Of Entidades.SincronizaRegistro))
      Try
         da.OpenConection()
         da.BeginTransaction()

         For Each reg As Entidades.SincronizaRegistro In registros
            Me.EjecutaSP(reg, TipoSP._I)
         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

End Class
