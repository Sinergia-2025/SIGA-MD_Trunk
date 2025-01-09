Public Class ProyectosEstados
   Inherits Reglas.Base


#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.ProyectoEstado.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProyectoEstado.NombreTabla
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
      Catch
         da.RollbakTransaction()
         Throw
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
      Catch
         da.RollbakTransaction()
         Throw
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
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ProyectosEstados = New SqlServer.ProyectosEstados(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ProyectosEstados(Me.da).ProyectosEstados_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.ProyectoEstado = DirectCast(entidad, Entidades.ProyectoEstado)

      Dim sqlC As SqlServer.ProyectosEstados = New SqlServer.ProyectosEstados(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ProyectosEstados_I(en.IdEstado, en.NombreEstado, en.Finalizado, en.Color, en.Posicion)
         Case TipoSP._U
            sqlC.ProyectosEstados_U(en.IdEstado, en.NombreEstado, en.Finalizado, en.Color, en.Posicion)
         Case TipoSP._D
            sqlC.ProyectosEstados_D(en.IdEstado)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ProyectoEstado, ByVal dr As DataRow)

      With o
         .IdEstado = dr.Field(Of Integer)(Entidades.ProyectoEstado.Columnas.IdEstado.ToString())
         .NombreEstado = dr.Field(Of String)(Entidades.ProyectoEstado.Columnas.NombreEstado.ToString())
         .Finalizado = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString())
         .Color = dr.Field(Of Integer?)(Entidades.CRMEstadoNovedad.Columnas.Color.ToString())
         .Posicion = dr.Field(Of Integer?)(Entidades.ProyectoEstado.Columnas.Posicion.ToString())
      End With

   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(idProyectoEstado As Integer) As Entidades.ProyectoEstado
      Dim dt As DataTable = New SqlServer.ProyectosEstados(Me.da).ProyectosEstados_G1(idProyectoEstado)
      Dim o As Entidades.ProyectoEstado = New Entidades.ProyectoEstado()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.ProyectoEstado)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ProyectoEstado
      Dim oLis As List(Of Entidades.ProyectoEstado) = New List(Of Entidades.ProyectoEstado)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ProyectoEstado()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ProyectosEstados(Me.da).GetCodigoMaximo()
   End Function

#End Region


End Class
