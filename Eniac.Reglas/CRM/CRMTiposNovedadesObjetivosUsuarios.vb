Public Class CRMTiposNovedadesObjetivosUsuarios
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CRMTipoNovedadObjetivoUsuario.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivoUsuario)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivoUsuario)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivoUsuario)))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.CRMTiposNovedadesObjetivosUsuarios(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMTiposNovedadesObjetivosUsuarios(da).CRMTiposNovedadesObjetivosUsuarios_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Sub _Insertar(entidad As Entidades.CRMTipoNovedadObjetivoUsuario)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivoUsuario), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CRMTipoNovedadObjetivoUsuario)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivoUsuario), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CRMTipoNovedadObjetivoUsuario)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivoUsuario), TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.CRMTipoNovedadObjetivo)
      entidad.Usuarios.All(Function(en)
                              en.IdTipoNovedad = entidad.IdTipoNovedad
                              en.PeriodoObjetivo = entidad.PeriodoObjetivo
                              _Insertar(en)
                              Return True
                           End Function)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CRMTipoNovedadObjetivo)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CRMTipoNovedadObjetivo)
      _Borrar(New Entidades.CRMTipoNovedadObjetivoUsuario() With {.IdTipoNovedad = entidad.IdTipoNovedad, .PeriodoObjetivo = entidad.PeriodoObjetivo})
   End Sub

   Public Function GetUno(idTipoNovedad As String, periodoObjetivo As DateTime, idUsuario As String) As Entidades.CRMTipoNovedadObjetivoUsuario
      Return GetUno(idTipoNovedad, periodoObjetivo, idUsuario, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoNovedad As String, periodoObjetivo As DateTime, idUsuario As String, accion As AccionesSiNoExisteRegistro) As Entidades.CRMTipoNovedadObjetivoUsuario
      Dim sql = New SqlServer.CRMTiposNovedadesObjetivosUsuarios(da)
      Return CargaEntidad(sql.CRMTiposNovedadesObjetivosUsuarios_G1(idTipoNovedad, periodoObjetivo, idUsuario),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoNovedadObjetivoUsuario(),
                          accion, Function() String.Format("No existen Objetivos definidos para {0} en el periodo {1} para el usuario {2}", idTipoNovedad, periodoObjetivo.ToPeriodo(), idUsuario))
   End Function

   Public Function GetTodos() As List(Of Entidades.CRMTipoNovedadObjetivoUsuario)
      Return CargaLista(GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoNovedadObjetivoUsuario())
   End Function
   Public Function GetTodos(idTipoNovedad As String, periodoObjetivo As DateTime?) As List(Of Entidades.CRMTipoNovedadObjetivoUsuario)
      Dim sql = New SqlServer.CRMTiposNovedadesObjetivosUsuarios(da)
      Return CargaLista(sql.CRMTiposNovedadesObjetivosUsuarios_GA(idTipoNovedad, periodoObjetivo),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoNovedadObjetivoUsuario())
   End Function

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMTipoNovedadObjetivoUsuario, tipo As TipoSP)
      Dim sql As SqlServer.CRMTiposNovedadesObjetivosUsuarios = New SqlServer.CRMTiposNovedadesObjetivosUsuarios(da)
      Select Case tipo
         Case TipoSP._I
            sql.CRMTiposNovedadesObjetivosUsuarios_I(en.IdTipoNovedad, en.PeriodoObjetivo, en.IdUsuario, en.Objetivo, en.ObjetivoMinimo)
         Case TipoSP._U
            sql.CRMTiposNovedadesObjetivosUsuarios_U(en.IdTipoNovedad, en.PeriodoObjetivo, en.IdUsuario, en.Objetivo, en.ObjetivoMinimo)
         Case TipoSP._D
            sql.CRMTiposNovedadesObjetivosUsuarios_D(en.IdTipoNovedad, en.PeriodoObjetivo, en.IdUsuario)
      End Select
   End Sub

   Private Sub CargarUno(eCRMTipoNovedadObjetivoUsuario As Entidades.CRMTipoNovedadObjetivoUsuario, dr As DataRow)
      With eCRMTipoNovedadObjetivoUsuario
         .IdTipoNovedad = dr.Field(Of String)(Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdTipoNovedad.ToString())
         .PeriodoObjetivo = dr.Field(Of Integer)(Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.PeriodoObjetivo.ToString()).FromPeriodo()
         .IdUsuario = dr.Field(Of String)(Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdUsuario.ToString())
         .NombreUsuario = dr.Field(Of String)("NombreUsuario")
         .Objetivo = dr.Field(Of Decimal)(Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.Objetivo.ToString())
         .ObjetivoMinimo = dr.Field(Of Decimal)(Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.ObjetivoMinimo.ToString())

      End With
   End Sub

#End Region

End Class