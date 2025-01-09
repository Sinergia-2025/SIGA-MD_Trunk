Public Class CRMCiclosPlanificacion
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CRMCicloPlanificacion.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMCicloPlanificacion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMCicloPlanificacion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMCicloPlanificacion)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().CRMCiclosPlanificacion_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CRMCiclosPlanificacion
      Return New SqlServer.CRMCiclosPlanificacion(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CRMCicloPlanificacion, tipo As TipoSP)

      en.IdUsuarioActualizacion = actual.Nombre
      en.FechaActualizacion = Date.Now

      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            en.IdUsuarioAlta = actual.Nombre
            en.FechaAlta = Date.Now
            sql.CRMCiclosPlanificacion_I(en.IdCicloPlanificacion, en.NombreCicloPlanificacion, en.EstadoCicloPlanificacion.IdEstadoCicloPlanificacion,
                                         en.FechaInicio, en.FechaCierre, en.FechaFinalizacion,
                                         en.IdUsuarioAlta, en.FechaAlta, en.IdUsuarioActualizacion, en.FechaActualizacion)

         Case TipoSP._U
            sql.CRMCiclosPlanificacion_U(en.IdCicloPlanificacion, en.NombreCicloPlanificacion, en.EstadoCicloPlanificacion.IdEstadoCicloPlanificacion,
                                         en.FechaInicio, en.FechaCierre, en.FechaFinalizacion,
                                         en.IdUsuarioAlta, en.FechaAlta, en.IdUsuarioActualizacion, en.FechaActualizacion)

         Case TipoSP._D
            sql.CRMCiclosPlanificacion_D(en.IdCicloPlanificacion)

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CRMCicloPlanificacion, dr As DataRow, cargaNovedades As Boolean)
      With o
         .IdCicloPlanificacion = dr.Field(Of Integer)(Entidades.CRMCicloPlanificacion.Columnas.IdCicloPlanificacion.ToString())
         .NombreCicloPlanificacion = dr.Field(Of String)(Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString())
         .EstadoCicloPlanificacion = New CRMEstadosCiclosPlanificacion(da).GetUno(dr.Field(Of String)(Entidades.CRMCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()))
         .FechaInicio = dr.Field(Of Date)(Entidades.CRMCicloPlanificacion.Columnas.FechaInicio.ToString())
         .FechaCierre = dr.Field(Of Date)(Entidades.CRMCicloPlanificacion.Columnas.FechaCierre.ToString())
         .FechaFinalizacion = dr.Field(Of Date)(Entidades.CRMCicloPlanificacion.Columnas.FechaFinalizacion.ToString())
         .IdUsuarioAlta = dr.Field(Of String)(Entidades.CRMCicloPlanificacion.Columnas.IdUsuarioAlta.ToString())
         .FechaAlta = dr.Field(Of Date)(Entidades.CRMCicloPlanificacion.Columnas.FechaAlta.ToString())
         .IdUsuarioActualizacion = dr.Field(Of String)(Entidades.CRMCicloPlanificacion.Columnas.IdUsuarioActualizacion.ToString())
         .FechaActualizacion = dr.Field(Of Date)(Entidades.CRMCicloPlanificacion.Columnas.FechaActualizacion.ToString())

         If cargaNovedades Then
            .Novedades = New CRMCiclosPlanificacionNovedades(da).GetTodos(.IdCicloPlanificacion)
         End If

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CRMCicloPlanificacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CRMCicloPlanificacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CRMCicloPlanificacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idCicloPlanificacion As Integer) As DataTable
      Return GetSql().CRMCiclosPlanificacion_G1(idCicloPlanificacion)
   End Function

   Public Function GetUno(idCicloPlanificacion As Integer) As Entidades.CRMCicloPlanificacion
      Return GetUno(idCicloPlanificacion, cargaNovedades:=False, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idCicloPlanificacion As Integer, cargaNovedades As Boolean) As Entidades.CRMCicloPlanificacion
      Return GetUno(idCicloPlanificacion, cargaNovedades, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idCicloPlanificacion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CRMCicloPlanificacion
      Return GetUno(idCicloPlanificacion, cargaNovedades:=False, accion)
   End Function
   Public Function GetUno(idCicloPlanificacion As Integer, cargaNovedades As Boolean, accion As AccionesSiNoExisteRegistro) As Entidades.CRMCicloPlanificacion
      Return CargaEntidad(Get1(idCicloPlanificacion), Sub(o, dr) CargarUno(o, dr, cargaNovedades), Function() New Entidades.CRMCicloPlanificacion(),
                          accion, Function() String.Format("No existe Ciclo de Planificación {0}", idCicloPlanificacion))
   End Function
   Public Function GetTodos() As List(Of Entidades.CRMCicloPlanificacion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr, cargaNovedades:=False), Function() New Entidades.CRMCicloPlanificacion())
   End Function

   Public Function GetPorCodigo(idCicloPlanificacion As Integer) As DataTable
      Return GetSql().CRMCiclosPlanificacion_G1(idCicloPlanificacion)
   End Function
   Public Function GetPorNombre(nombreCicloPlanificacion As String) As DataTable
      Return GetSql().CRMCiclosPlanificacion_GA_PorNombre(nombreCicloPlanificacion)
   End Function

   Public Function NewEntidad() As Entidades.CRMCicloPlanificacion
      Dim result = New Entidades.CRMCicloPlanificacion With {
         .EstadoCicloPlanificacion = New CRMEstadosCiclosPlanificacion(da).GetUnoPorDefecto(),
         .FechaInicio = Date.Today,
         .FechaCierre = Date.Today,
         .FechaFinalizacion = Date.Today
      }
      Return result
   End Function
   Public Function GetEntidad(dr As DataRow) As Entidades.CRMCicloPlanificacion
      Return GetUno(dr.Field(Of Integer)(Entidades.CRMCicloPlanificacion.Columnas.IdCicloPlanificacion.ToString()))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return GetSql().GetCodigoMaximo()
   End Function
   Public Function GetProximoCodigo() As Integer
      Return GetCodigoMaximo() + 1
   End Function

#End Region
End Class