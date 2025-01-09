Public Class CRMCiclosPlanificacionNovedades
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CRMCicloPlanificacionNovedad.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMCicloPlanificacionNovedad)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMCicloPlanificacionNovedad)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMCicloPlanificacionNovedad)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().CRMCiclosPlanificacionNovedades_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CRMCiclosPlanificacionNovedades
      Return New SqlServer.CRMCiclosPlanificacionNovedades(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CRMCicloPlanificacionNovedad, tipo As TipoSP)
      Dim sql = GetSql()
      en.IdUsuarioActualizacion = actual.Nombre
      en.FechaActualizacion = Date.Now
      Select Case tipo
         Case TipoSP._I
            en.IdUsuarioAlta = actual.Nombre
            en.FechaAlta = Date.Now
            sql.CRMCiclosPlanificacionNovedades_I(en.IdCicloPlanificacion, en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad,
                                                  en.Orden, en.TipoPlanificacion, en.Planificada,
                                                  en.IdEstadoNovedadInicio, en.IdEstadoNovedadCierre, en.IdEstadoNovedadFinal,
                                                  en.IdUsuarioAlta, en.FechaAlta, en.IdUsuarioActualizacion, en.FechaActualizacion)

         Case TipoSP._U
            sql.CRMCiclosPlanificacionNovedades_U(en.IdCicloPlanificacion, en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad,
                                                  en.Orden, en.TipoPlanificacion, en.Planificada,
                                                  en.IdEstadoNovedadInicio, en.IdEstadoNovedadCierre, en.IdEstadoNovedadFinal,
                                                  en.IdUsuarioAlta, en.FechaAlta, en.IdUsuarioActualizacion, en.FechaActualizacion)

         Case TipoSP._D
            sql.CRMCiclosPlanificacionNovedades_D(en.IdCicloPlanificacion, en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CRMCicloPlanificacionNovedad, dr As DataRow)
      With o
         .IdCicloPlanificacion = dr.Field(Of Integer)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdCicloPlanificacion.ToString())

         .IdTipoNovedad = dr.Field(Of String)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdTipoNovedad.ToString())
         .Letra = dr.Field(Of String)(Entidades.CRMCicloPlanificacionNovedad.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.CRMCicloPlanificacionNovedad.Columnas.CentroEmisor.ToString())
         .IdNovedad = dr.Field(Of Long)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdNovedad.ToString())

         .Orden = dr.Field(Of Integer)(Entidades.CRMCicloPlanificacionNovedad.Columnas.Orden.ToString())
         .TipoPlanificacion = dr.Field(Of String)(Entidades.CRMCicloPlanificacionNovedad.Columnas.TipoPlanificacion.ToString()).StringToEnum(Entidades.CRMCicloPlanificacionNovedad.TiposPlanificacion.ABIERTA)
         .Planificada = dr.Field(Of Boolean)(Entidades.CRMCicloPlanificacionNovedad.Columnas.Planificada.ToString())

         .IdEstadoNovedadInicio = dr.Field(Of Integer?)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadInicio.ToString())
         .IdEstadoNovedadCierre = dr.Field(Of Integer?)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadCierre.ToString())
         .IdEstadoNovedadFinal = dr.Field(Of Integer?)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadFinal.ToString())

         .IdUsuarioAlta = dr.Field(Of String)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdUsuarioAlta.ToString())
         .FechaAlta = dr.Field(Of Date)(Entidades.CRMCicloPlanificacionNovedad.Columnas.FechaAlta.ToString())
         .IdUsuarioActualizacion = dr.Field(Of String)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdUsuarioActualizacion.ToString())
         .FechaActualizacion = dr.Field(Of Date)(Entidades.CRMCicloPlanificacionNovedad.Columnas.FechaActualizacion.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CRMCicloPlanificacionNovedad)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CRMCicloPlanificacionNovedad)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CRMCicloPlanificacionNovedad)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Function GetAll(idCicloPlanificacion As Integer) As DataTable
      Return GetSql().CRMCiclosPlanificacionNovedades_GA(idCicloPlanificacion)
   End Function
   Public Overloads Function GetAll(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Return GetSql().CRMCiclosPlanificacionNovedades_GA(idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function
   Public Function Get1(idCicloPlanificacion As Integer, idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Return GetSql().CRMCiclosPlanificacionNovedades_G1(idCicloPlanificacion, idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function

   Public Function GetUno(idCicloPlanificacion As Integer, idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Entidades.CRMCicloPlanificacionNovedad
      Return GetUno(idCicloPlanificacion, idTipoNovedad, letra, centroEmisor, idNovedad, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idCicloPlanificacion As Integer, idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, accion As AccionesSiNoExisteRegistro) As Entidades.CRMCicloPlanificacionNovedad
      Return CargaEntidad(Get1(idCicloPlanificacion, idTipoNovedad, letra, centroEmisor, idNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMCicloPlanificacionNovedad(),
                          accion, Function() String.Format("No existe Ciclo de Planificación {0}", idCicloPlanificacion))
   End Function
   Public Function GetTodos() As List(Of Entidades.CRMCicloPlanificacionNovedad)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMCicloPlanificacionNovedad())
   End Function
   Public Function GetTodos(idCicloPlanificacion As Integer) As List(Of Entidades.CRMCicloPlanificacionNovedad)
      Return CargaLista(GetAll(idCicloPlanificacion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMCicloPlanificacionNovedad())
   End Function

   Public Function GetOrdenMaximo(idCicloPlanificacion As Integer) As Integer
      Return GetSql().GetOrdenMaximo(idCicloPlanificacion)
   End Function
   Public Function GetProximoOrden(idCicloPlanificacion As Integer) As Integer
      Return GetOrdenMaximo(idCicloPlanificacion) + 10
   End Function

#End Region
End Class