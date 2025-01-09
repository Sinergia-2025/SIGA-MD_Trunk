Public Class CRMTiposNovedadesObjetivos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CRMTipoNovedadObjetivo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivo)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivo)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivo)))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.CRMTiposNovedadesObjetivos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMTiposNovedadesObjetivos(da).CRMTiposNovedadesObjetivos_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Sub _Insertar(entidad As Entidades.CRMTipoNovedadObjetivo)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivo), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CRMTipoNovedadObjetivo)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivo), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CRMTipoNovedadObjetivo)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoNovedadObjetivo), TipoSP._D)
   End Sub

   Public Function GetUno(idTipoNovedad As String, periodoObjetivo As DateTime) As Entidades.CRMTipoNovedadObjetivo
      Return GetUno(idTipoNovedad, periodoObjetivo, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoNovedad As String, periodoObjetivo As DateTime, accion As AccionesSiNoExisteRegistro) As Entidades.CRMTipoNovedadObjetivo
      Dim sql As SqlServer.CRMTiposNovedadesObjetivos = New SqlServer.CRMTiposNovedadesObjetivos(da)
      Return CargaEntidad(sql.CRMTiposNovedadesObjetivos_G1(idTipoNovedad, periodoObjetivo),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoNovedadObjetivo(),
                          accion, Function() String.Format("No existen Objetivos definidos para {0} en el periodo {1}", idTipoNovedad, periodoObjetivo.ToPeriodo()))
   End Function

   Public Function GetTodos() As List(Of Entidades.CRMTipoNovedadObjetivo)
      Return GetTodos(periodo:=Nothing)
   End Function
   Public Function GetTodos(periodo As DateTime?) As List(Of Entidades.CRMTipoNovedadObjetivo)
      Return CargaLista(New SqlServer.CRMTiposNovedadesObjetivos(da).CRMTiposNovedadesObjetivos_GA(periodo),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoNovedadObjetivo())
   End Function

   Public Sub CopiarObjetivosParaPeriodo()
      EjecutaConConexion(Sub() _CopiarObjetivosParaPeriodo())
   End Sub
   Friend Sub _CopiarObjetivosParaPeriodo()
      Dim sql = New SqlServer.CRMTiposNovedadesObjetivos(da)
      Dim periodoActual = DateTime.Today.PrimerDiaMes()
      Dim dt = sql.CRMTiposNovedadesObjetivos_GA(periodoActual)
      If dt.Rows.Count = 0 Then
         Dim periodoAnterior = GetTodos(periodoActual.AddMonths(-1))
         periodoAnterior.All(Function(o)
                                o.PeriodoObjetivo = periodoActual
                                _Insertar(o)
                                Return True
                             End Function)
      End If
   End Sub

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMTipoNovedadObjetivo, tipo As TipoSP)
      Dim sql = New SqlServer.CRMTiposNovedadesObjetivos(da)
      Dim rUsr = New CRMTiposNovedadesObjetivosUsuarios(da)

      en.IdUsuarioActualizacion = actual.Nombre
      en.FechaActualizacion = DateTime.Now

      Select Case tipo
         Case TipoSP._I
            sql.CRMTiposNovedadesObjetivos_I(en.IdTipoNovedad, en.PeriodoObjetivo, en.IdUsuarioActualizacion, en.FechaActualizacion)
            rUsr._Insertar(en)
         Case TipoSP._U
            sql.CRMTiposNovedadesObjetivos_U(en.IdTipoNovedad, en.PeriodoObjetivo, en.IdUsuarioActualizacion, en.FechaActualizacion)
            rUsr._Actualizar(en)
         Case TipoSP._D
            rUsr._Borrar(en)
            sql.CRMTiposNovedadesObjetivos_D(en.IdTipoNovedad, en.PeriodoObjetivo)
      End Select
   End Sub

   Private Sub CargarUno(eCRMTipoNovedadObjetivo As Entidades.CRMTipoNovedadObjetivo, dr As DataRow)
      With eCRMTipoNovedadObjetivo
         .IdTipoNovedad = dr.Field(Of String)(Entidades.CRMTipoNovedadObjetivo.Columnas.IdTipoNovedad.ToString())
         .PeriodoObjetivo = dr.Field(Of Integer)(Entidades.CRMTipoNovedadObjetivo.Columnas.PeriodoObjetivo.ToString()).FromPeriodo()
         .IdUsuarioActualizacion = dr.Field(Of String)(Entidades.CRMTipoNovedadObjetivo.Columnas.IdUsuarioActualizacion.ToString())
         .FechaActualizacion = dr.Field(Of DateTime)(Entidades.CRMTipoNovedadObjetivo.Columnas.FechaActualizacion.ToString())

         .Usuarios = New CRMTiposNovedadesObjetivosUsuarios(da).GetTodos(.IdTipoNovedad, .PeriodoObjetivo)

      End With
   End Sub

#End Region

End Class