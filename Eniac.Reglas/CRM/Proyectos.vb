Option Strict On
Option Explicit On

Public Class Proyectos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Proyectos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Proyectos"
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
      Dim sql As SqlServer.Proyectos = New SqlServer.Proyectos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Proyectos(Me.da).Proyectos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.Proyecto = DirectCast(entidad, Entidades.Proyecto)

      Dim sqlC As SqlServer.Proyectos = New SqlServer.Proyectos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Proyectos_I(en.IdProyecto, en.NombreProyecto, en.Cliente.IdCliente, en.FechaInicio, en.FechaFin, en.Estimado, en.Presupuestado,
                             en.IdPrioridadImporte, en.IdPrioridadEstrategico, en.IdPrioridadComplejidad, en.IdPrioridadReplicabilidad, en.IdPrioridadProyecto, en.Clasificacion.IdClasificacion, en.IdEstado, en.FechaFinReal, en.HsRealEstimadas, en.HsInformadas)
         Case TipoSP._U
            sqlC.Proyectos_U(en.IdProyecto, en.NombreProyecto, en.Cliente.IdCliente, en.FechaInicio, en.FechaFin, en.Estimado, en.Presupuestado,
                             en.IdPrioridadImporte, en.IdPrioridadEstrategico, en.IdPrioridadComplejidad, en.IdPrioridadReplicabilidad, en.IdPrioridadProyecto, en.Clasificacion.IdClasificacion, en.IdEstado, en.FechaFinReal, en.HsRealEstimadas, en.HsInformadas)
         Case TipoSP._D
            sqlC.Proyectos_D(en.IdProyecto)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Proyecto, ByVal dr As DataRow)
      With o
         .IdProyecto = Int32.Parse(dr(Entidades.Proyecto.Columnas.IdProyecto.ToString()).ToString())
         .NombreProyecto = dr(Entidades.Proyecto.Columnas.NombreProyecto.ToString()).ToString()
         .Cliente = New Reglas.Clientes(Me.da).GetUno(Long.Parse(dr(Entidades.Proyecto.Columnas.IdCliente.ToString()).ToString()))
         .FechaInicio = DateTime.Parse(dr(Entidades.Proyecto.Columnas.FechaInicio.ToString()).ToString())
         .FechaFin = DateTime.Parse(dr(Entidades.Proyecto.Columnas.FechaFin.ToString()).ToString())
         .Estimado = Decimal.Parse(dr(Entidades.Proyecto.Columnas.Estimado.ToString()).ToString())
         .Presupuestado = Decimal.Parse(dr(Entidades.Proyecto.Columnas.Presupuestado.ToString()).ToString())
         .IdPrioridadImporte = dr.Field(Of Integer)(Entidades.Proyecto.Columnas.IdPrioridadImporte.ToString())
         .IdPrioridadEstrategico = dr.Field(Of Integer)(Entidades.Proyecto.Columnas.IdPrioridadEstrategico.ToString())
         .IdPrioridadComplejidad = dr.Field(Of Integer)(Entidades.Proyecto.Columnas.IdPrioridadComplejidad.ToString())
         .IdPrioridadReplicabilidad = dr.Field(Of Integer)(Entidades.Proyecto.Columnas.IdPrioridadReplicabilidad.ToString())
         .IdPrioridadProyecto = dr.Field(Of Decimal)(Entidades.Proyecto.Columnas.IdPrioridadProyecto.ToString())
         .IdEstado = dr.Field(Of Integer)(Entidades.Proyecto.Columnas.IdEstado.ToString())
         .Finalizado = dr.Field(Of Boolean)(Entidades.Proyecto.Columnas.Finalizado.ToString())

         '# Clasificacion del Proyecto 
         Dim rClasificaciones As Reglas.Clasificaciones = New Reglas.Clasificaciones
         .Clasificacion = rClasificaciones.GetUno(dr.Field(Of Integer)(Entidades.Clasificacion.Columnas.IdClasificacion.ToString()))

         .FechaFinReal = dr.Field(Of Date?)(Entidades.Proyecto.Columnas.FechaFinReal.ToString())
         .HsRealEstimadas = dr.Field(Of Decimal)(Entidades.Proyecto.Columnas.HsRealEstimadas.ToString())
         .HsInformadas = dr.Field(Of Decimal)(Entidades.Proyecto.Columnas.HsInformadas.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idProyecto As Integer) As Entidades.Proyecto
      Return GetUno(idProyecto, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idProyecto As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Proyecto
      Return CargaEntidad(New SqlServer.Proyectos(Me.da).Proyectos_G1(idProyecto),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.Proyecto(),
                          accion, Function() String.Format("No se encontró un proyecto con código {0}", idProyecto))
   End Function

   Public Function GetTodos() As List(Of Entidades.Proyecto)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.Proyecto())
   End Function

   Public Function GetFiltradoPorCodigo(idProyecto As Integer?) As DataTable
      Return New SqlServer.Proyectos(da).GetFiltradoPorCodigoNombre(idProyecto, String.Empty, Nothing)
   End Function

   Public Function GetFiltradoPorNombre(ByVal nombre As String) As DataTable
      Return New SqlServer.Proyectos(da).GetFiltradoPorCodigoNombre(Nothing, nombre, Nothing)
   End Function

   Public Function GetFiltradoPorCodigo(idProyecto As Integer?, idCliente As Long?) As DataTable
      Return New SqlServer.Proyectos(da).GetFiltradoPorCodigoNombre(idProyecto, String.Empty, idCliente)
   End Function

   Public Function GetFiltradoPorNombre(ByVal nombre As String, idCliente As Long?) As DataTable
      Return New SqlServer.Proyectos(da).GetFiltradoPorCodigoNombre(Nothing, nombre, idCliente)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Proyectos(Me.da).GetCodigoMaximo()
   End Function

   Public Function Existe(idProyecto As Integer) As Boolean
      Return New SqlServer.Proyectos(da).Existe(idProyecto)
   End Function

#End Region

End Class
