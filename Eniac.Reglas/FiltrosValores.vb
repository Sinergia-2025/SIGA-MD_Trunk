Public Class FiltrosValores
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "FiltrosValores"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "FiltrosValores"
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
      Dim sql As SqlServer.FiltrosValores = New SqlServer.FiltrosValores(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.FiltrosValores(Me.da).FiltrosValores_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.FiltroValor = DirectCast(entidad, Entidades.FiltroValor)

      Dim sql As SqlServer.FiltrosValores = New SqlServer.FiltrosValores(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.FiltrosValores_I(en.IdTipoFiltro, en.IdNombreFiltro, en.IdColumna, en.IdRegistro, en.Valor)
         Case TipoSP._U
            sql.FiltrosValores_U(en.IdTipoFiltro, en.IdNombreFiltro, en.IdColumna, en.IdRegistro, en.Valor)
         Case TipoSP._D
            sql.FiltrosValores_D(en.IdTipoFiltro, en.IdNombreFiltro, en.IdColumna, en.IdRegistro)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.FiltroValor, ByVal dr As DataRow)
      With o
         .IdTipoFiltro = dr(Entidades.FiltroValor.Columnas.IdTipoFiltro.ToString()).ToString()
         .IdNombreFiltro = dr(Entidades.FiltroValor.Columnas.IdNombreFiltro.ToString()).ToString()
         .IdColumna = dr(Entidades.FiltroValor.Columnas.IdColumna.ToString()).ToString()
         .IdRegistro = Int32.Parse(dr(Entidades.FiltroValor.Columnas.IdRegistro.ToString()).ToString())
         .Valor = dr(Entidades.FiltroValor.Columnas.Valor.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarFiltros(ByVal idTipoFiltro As String, ByVal idNombreFiltro As String, ByVal filtros As List(Of Entidades.FiltroValor))
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.FiltrosValores = New SqlServer.FiltrosValores(Me.da)
         'elimino todo los filtros anteriores
         sql.BorrarFiltros(idTipoFiltro, idNombreFiltro)

         'recorro y agrego todos los filtros
         For Each vl As Entidades.FiltroValor In filtros
            sql.FiltrosValores_I(vl.IdTipoFiltro, vl.IdNombreFiltro, vl.IdColumna, vl.IdRegistro, vl.Valor)
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub BorraFiltros(ByVal idTipoFiltro As String, ByVal idNombreFiltro As String)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()
         Dim sql As SqlServer.FiltrosValores = New SqlServer.FiltrosValores(Me.da)
         sql.BorrarFiltros(idTipoFiltro, idNombreFiltro)
         Me.da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Function GetTodos() As List(Of Entidades.FiltroValor)
      Try
         Me.da.OpenConection()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.FiltroValor
         Dim oLis As List(Of Entidades.FiltroValor) = New List(Of Entidades.FiltroValor)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.FiltroValor()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Return oLis

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetTodosPorTipoNombre(ByVal idTipoFiltro As String, _
                                         ByVal idNombreFiltro As String) As List(Of Entidades.FiltroValor)
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.FiltrosValores = New SqlServer.FiltrosValores(Me.da)

         Dim dt As DataTable = sql.GetPorTipoNombre(idTipoFiltro, idNombreFiltro)
         Dim o As Entidades.FiltroValor
         Dim oLis As List(Of Entidades.FiltroValor) = New List(Of Entidades.FiltroValor)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.FiltroValor()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Return oLis

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetNombreFiltros(ByVal idTipoFiltro As String) As String()
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.FiltrosValores = New SqlServer.FiltrosValores(Me.da)

         Dim dt As DataTable = sql.GetNombresFiltros(idTipoFiltro)
         Dim oLis As List(Of String) = New List(Of String)()
         For Each dr As DataRow In dt.Rows
            oLis.Add(dr("IdNombreFiltro").ToString())
         Next

         Return oLis.ToArray()

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(ByVal idTipoFiltro As String, _
                               ByVal idNombreFiltro As String, _
                               ByVal idColumna As String, _
                               ByVal idRegistro As Integer) As Entidades.FiltroValor
      Try
         Me.da.OpenConection()

         Return Me._GetUno(idTipoFiltro, idNombreFiltro, idColumna, idRegistro)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(ByVal idTipoFiltro As String, _
                               ByVal idNombreFiltro As String, _
                               ByVal idColumna As String, _
                               ByVal idRegistro As Integer) As Entidades.FiltroValor

      Dim sql As SqlServer.FiltrosValores = New SqlServer.FiltrosValores(Me.da)

      Dim dt As DataTable = sql.FiltrosValores_G1(idTipoFiltro, idNombreFiltro, idColumna, idRegistro)

      Dim o As Entidades.FiltroValor = New Entidades.FiltroValor()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la FiltroValor.")
      End If

      Return o

   End Function

#End Region



End Class
