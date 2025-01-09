Public Class CRMNovedadesCambiosEstados
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.CRMNovedadCambioEstado.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMNovedadCambioEstado)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMNovedadCambioEstado)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMNovedadCambioEstado)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.CRMNovedadesCambiosEstados(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.CRMNovedadesCambiosEstados(da).CRMNovedadesCambiosEstados_GA()
   End Function

   Public Overloads Function GetAll(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Return New SqlServer.CRMNovedadesCambiosEstados(da).CRMNovedadesCambiosEstados_GA(idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMNovedadCambioEstado, tipo As TipoSP)
      Dim sqlC = New SqlServer.CRMNovedadesCambiosEstados(da)

      Select Case tipo
         Case TipoSP._I
            If en.IdCambioEstado = 0 Then
               en.IdCambioEstado = GetCodigoMaximo(en) + 1
            End If

            sqlC.CRMNovedadesCambiosEstados_I(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdCambioEstado, en.FechaCambioEstado,
                                              en.IdEstadoNovedad, en.IdUsuario, en.IdUsuarioAsignado, en.IdSucursalNovedad)
         Case TipoSP._U
            sqlC.CRMNovedadesCambiosEstados_U(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdCambioEstado, en.FechaCambioEstado,
                                              en.IdEstadoNovedad, en.IdUsuario, en.IdUsuarioAsignado, en.IdSucursalNovedad)
         Case TipoSP._D
            sqlC.CRMNovedadesCambiosEstados_D(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdCambioEstado)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.CRMNovedadCambioEstado, dr As DataRow)
      With o
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr.Field(Of String)(Entidades.CRMNovedadCambioEstado.Columnas.IdTipoNovedad.ToString()))

         .Letra = dr.Field(Of String)(Entidades.CRMNovedadCambioEstado.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString())
         .IdNovedad = dr.Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString())
         .IdCambioEstado = dr.Field(Of Integer)(Entidades.CRMNovedadCambioEstado.Columnas.IdCambioEstado.ToString())

         .FechaCambioEstado = dr.Field(Of Date)(Entidades.CRMNovedadCambioEstado.Columnas.FechaCambioEstado.ToString())
         .EstadoNovedad = Cache.CRMCacheHandler.Instancia.Estados.Buscar(dr.Field(Of Integer)(Entidades.CRMNovedadCambioEstado.Columnas.IdEstadoNovedad.ToString()))
         .IdUsuario = dr.Field(Of String)(Entidades.CRMNovedadCambioEstado.Columnas.IdUsuario.ToString())
         .IdUsuarioAsignado = dr.Field(Of String)(Entidades.CRMNovedadCambioEstado.Columnas.IdUsuarioAsignado.ToString())
         .IdSucursalNovedad = dr.Field(Of Integer?)(Entidades.CRMNovedadCambioEstado.Columnas.IdSucursalNovedad.ToString())
         .NombreSucursalNovedad = dr.Field(Of String)("NombreSucursalNovedad").IfNull()

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Entidades.CRMNovedadCambioEstado)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Insertar(entidades As List(Of Entidades.CRMNovedadCambioEstado))
      entidades.ForEach(Sub(en) _Insertar(en))
   End Sub

   Public Sub _Actualizar(entidad As Entidades.CRMNovedadCambioEstado)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Actualizar(entidades As List(Of Entidades.CRMNovedadCambioEstado))
      entidades.ForEach(Sub(en) _Actualizar(en))
   End Sub

   Public Sub _Borrar(entidad As Entidades.CRMNovedadCambioEstado)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub BorrarTodosDeUnaNovedad(entidades As List(Of Entidades.CRMNovedadCambioEstado))
      entidades.ForEach(Sub(en) _Borrar(en))
   End Sub
   Public Sub _Borrar(en As Entidades.CRMNovedad)
      _Borrar(New Entidades.CRMNovedadCambioEstado(en))
   End Sub

   Public Function GetUno(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idCambioEstado As Integer) As Entidades.CRMNovedadCambioEstado
      Return GetUno(idTipoNovedad, letra, centroEmisor, idNovedad, idCambioEstado, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idCambioEstado As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.CRMNovedadCambioEstado
      Return CargaEntidad(New SqlServer.CRMNovedadesCambiosEstados(da).CRMNovedadesCambiosEstados_G1(idTipoNovedad, letra, centroEmisor, idNovedad, idCambioEstado),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMNovedadCambioEstado(),
                          accion, String.Format("No existe seguimiento con: {0} {1} {2:0000}-{3:00000000} if: {4}",
                                                idTipoNovedad, letra, centroEmisor, idNovedad, idCambioEstado))
   End Function

   Public Function GetTodos(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As List(Of Entidades.CRMNovedadCambioEstado)
      Return CargaLista(New SqlServer.CRMNovedadesCambiosEstados(da).CRMNovedadesCambiosEstados_GA(idTipoNovedad, letra, centroEmisor, idNovedad),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMNovedadCambioEstado())
   End Function
   Public Function GetTodosAgrupados(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As List(Of Entidades.CRMNovedadCambioEstado)
      Return CargaLista(New SqlServer.CRMNovedadesCambiosEstados(da).CRMNovedadesCambiosEstados_GA_Agrupados(idTipoNovedad, letra, centroEmisor, idNovedad),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMNovedadCambioEstado())
   End Function

   Public Function GetCodigoMaximo(en As Entidades.CRMNovedadCambioEstado) As Integer
      Return GetCodigoMaximo(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)
   End Function
   Public Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Integer
      Return New SqlServer.CRMNovedadesCambiosEstados(da).GetCodigoMaximo(idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function
#End Region

End Class