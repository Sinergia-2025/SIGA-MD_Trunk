Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Public Class CRMNovedadesSeguimiento
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon)

   Private _base As String

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CRMNovedadSeguimiento.NombreTabla
      da = accesoDatos
      Me._base = Publicos.NombreBaseAdjuntosCRM
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMNovedadSeguimiento)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMNovedadSeguimiento)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMNovedadSeguimiento)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CRMNovedadesSeguimiento = New SqlServer.CRMNovedadesSeguimiento(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMNovedadesSeguimiento(da).CRMNovedadesSeguimiento_GA()
   End Function

   Public Overloads Function GetAll(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As System.Data.DataTable
      Return New SqlServer.CRMNovedadesSeguimiento(da).CRMNovedadesSeguimiento_GA(idTipoNovedad, letra, centroEmisor, idNovedad, fechaActualizacionWebDesde:=Nothing,
                                                                                     visibleParaCliente:=Entidades.Publicos.SiNoTodos.TODOS, visibleParaRepresentante:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMNovedadSeguimiento, tipo As TipoSP)

      Dim fechaActualizacionWeb As Date? = Nothing   'Desde la aplicación de gestión pasamos siempre NOTHING para que lo grabe SQL

      Dim sqlC As SqlServer.CRMNovedadesSeguimiento = New SqlServer.CRMNovedadesSeguimiento(da)

      Dim idEstadoNovedad As Integer? = If(en.EstadoNovedad IsNot Nothing, en.EstadoNovedad.IdEstadoNovedad, Nothing)
      Select Case tipo
         Case TipoSP._I
            If en.IdSeguimiento = 0 Then
               en.IdSeguimiento = GetCodigoMaximo(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad) + 1
            End If
            'en.FechaSeguimiento = Now
            en.UsuarioSeguimiento.Usuario = actual.Nombre
            Dim idUnicoSinc As String = Nothing
            sqlC.CRMNovedadesSeguimiento_I(fechaActualizacionWeb,
                                           en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico, en.FechaSeguimiento,
                                           en.Comentario, en.Interlocutor, en.EsComentario, en.IdUsuarioSeguimiento,
                                           en.IdTipoComentarioNovedad, en.ComentarioPrincipal, en.Activo, idEstadoNovedad, en.IdUsuarioAsignado)

            If en.ArchivoAdjunto IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(en.ArchivoAdjunto.NombreAdjunto) Then
               Dim rAdjunto As CRMNovedadesSeguimientoAdjuntos = New CRMNovedadesSeguimientoAdjuntos(da, Me._base)
               en.ArchivoAdjunto.TipoNovedad = en.TipoNovedad
               en.ArchivoAdjunto.Letra = en.Letra
               en.ArchivoAdjunto.CentroEmisor = en.CentroEmisor
               en.ArchivoAdjunto.IdNovedad = en.IdNovedad
               en.ArchivoAdjunto.IdSeguimiento = en.IdSeguimiento
               en.ArchivoAdjunto.IdUnico = en.IdUnico
               rAdjunto._Insertar(en.ArchivoAdjunto)
            End If

         Case TipoSP._U
            sqlC.CRMNovedadesSeguimiento_U(fechaActualizacionWeb,
                                           en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico, en.FechaSeguimiento,
                                           en.Comentario, en.Interlocutor, en.EsComentario, en.IdUsuarioSeguimiento,
                                           en.IdTipoComentarioNovedad, en.ComentarioPrincipal, en.Activo, idEstadoNovedad, en.IdUsuarioAsignado)
         Case TipoSP._D
            Dim rAdjunto As CRMNovedadesSeguimientoAdjuntos = New CRMNovedadesSeguimientoAdjuntos(da, Me._base)
            rAdjunto.Borrar(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico)
            sqlC.CRMNovedadesSeguimiento_D(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.CRMNovedadSeguimiento, dr As DataRow)
      'Const tag As String = "CRMNovedadesSeguimiento.CargarUno"
      'My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Iniciando"))

      With o
         '.TipoNovedad = New Reglas.CRMTiposNovedades().GetUno(dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()))
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()))
         'My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "CRMTiposNovedades.Luego GetUno"))

         .Letra = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString())
         .IdNovedad = dr.Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString())
         .IdSeguimiento = dr.Field(Of Integer)(Entidades.CRMNovedadSeguimiento.Columnas.IdSeguimiento.ToString())
         .IdUnico = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.IdUnico.ToString())

         .FechaSeguimiento = dr.Field(Of Date)(Entidades.CRMNovedadSeguimiento.Columnas.FechaSeguimiento.ToString())
         .Comentario = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString())
         If Not String.IsNullOrWhiteSpace(dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.Interlocutor.ToString())) Then
            .Interlocutor = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.Interlocutor.ToString())
         Else
            .Interlocutor = String.Empty
         End If
         .EsComentario = dr.Field(Of Boolean)(Entidades.CRMNovedadSeguimiento.Columnas.EsComentario.ToString())
         '.UsuarioSeguimiento = New Reglas.Usuarios(da).GetUno(dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.UsuarioSeguimiento.ToString()))
         '.UsuarioAsignado = New Reglas.Usuarios(da).GetUno(dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.UsuarioAsignado.ToString()))

         .UsuarioSeguimiento = Cache.SeguridadCacheHandler.Instancia.Usuarios.Buscar(dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.UsuarioSeguimiento.ToString()))
         .UsuarioAsignado = Cache.SeguridadCacheHandler.Instancia.Usuarios.Buscar(dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.UsuarioAsignado.ToString()))

         .IdTipoComentarioNovedad = dr.Field(Of Integer?)(Entidades.CRMNovedadSeguimiento.Columnas.IdTipoComentarioNovedad.ToString())
         .ComentarioPrincipal = dr.Field(Of Boolean)(Entidades.CRMNovedadSeguimiento.Columnas.ComentarioPrincipal.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.CRMNovedadSeguimiento.Columnas.Activo.ToString())

         '.EstadoNovedad = New Reglas.CRMEstadosNovedades(da).GetUno(dr.Field(Of Integer)(Entidades.CRMNovedadSeguimiento.Columnas.IdEstadoNovedad.ToString()))
         .EstadoNovedad = Cache.CRMCacheHandler.Instancia.Estados.Buscar(dr.Field(Of Integer?)(Entidades.CRMNovedadSeguimiento.Columnas.IdEstadoNovedad.ToString()).IfNull())

         'My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Antes de Adjuntos"))

         .ArchivoAdjunto = New CRMNovedadesSeguimientoAdjuntos(da, Me._base).GetUno(.IdTipoNovedad, .Letra, .CentroEmisor, .IdNovedad, .IdSeguimiento, .IdUnico, False)

         .FechaActualizacionWeb = dr.Field(Of Date)(Entidades.CRMNovedadSeguimiento.Columnas.FechaActualizacionWeb.ToString())

         'My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Luego de Adjuntos"))

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Entidades.CRMNovedadSeguimiento)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Insertar(entidades As List(Of Entidades.CRMNovedadSeguimiento))
      For Each en As Entidades.CRMNovedadSeguimiento In entidades
         _Insertar(en)
      Next
   End Sub

   Public Sub _Actualizar(entidad As Entidades.CRMNovedadSeguimiento)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Actualizar(entidades As List(Of Entidades.CRMNovedadSeguimiento))
      For Each en As Entidades.CRMNovedadSeguimiento In entidades
         _Actualizar(en)
      Next
   End Sub

   Public Sub _Borrar(entidad As Entidades.CRMNovedadSeguimiento)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub BorrarTodosDeUnaNovedad(entidades As List(Of Entidades.CRMNovedadSeguimiento))
      For Each en As Entidades.CRMNovedadSeguimiento In entidades
         _Borrar(en)
      Next
   End Sub
   Public Sub _Borrar(en As Entidades.CRMNovedad)
      _Borrar(New Entidades.CRMNovedadSeguimiento() _
                  With {.TipoNovedad = en.TipoNovedad,
                        .Letra = en.Letra,
                        .CentroEmisor = en.CentroEmisor,
                        .IdNovedad = en.IdNovedad,
                        .IdSeguimiento = 0,
                        .IdUnico = String.Empty})
   End Sub

   Public Function GetUno(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String) As Entidades.CRMNovedadSeguimiento
      Return GetUno(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.CRMNovedadSeguimiento
      Return CargaEntidad(New SqlServer.CRMNovedadesSeguimiento(da).CRMNovedadesSeguimiento_G1(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.CRMNovedadSeguimiento(),
                          accion, String.Format("No existe seguimiento con: {0} {1} {2:0000}-{3:00000000} seg: {4} GUID: {5}",
                                                idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico))
   End Function

   Public Function GetTodos(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As List(Of Entidades.CRMNovedadSeguimiento)
      'Const tag As String = "CRMNovedadesSeguimiento.GetTodos"
      'My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Antes de GetAll"))
      Dim dt As DataTable = Me.GetAll(idTipoNovedad, letra, centroEmisor, idNovedad)
      'My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Después de GetAll"))

      Return CargaLista(dt, Sub(o, dr) CargarUno(DirectCast(o, Entidades.CRMNovedadSeguimiento), dr), Function() New Entidades.CRMNovedadSeguimiento())
   End Function

   Public Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Integer
      Return New SqlServer.CRMNovedadesSeguimiento(da).GetCodigoMaximo(idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function

   Public Function GetNovedadesSeguimientos(desde As Date, hasta As Date, idTipoNovedad As String,
                                            idCategoriaNovedad As Integer, idEstadoNovedad As Integer,
                                            idUsuario As String, tipoUsuario As Entidades.CRMNovedad.TipoUsuarioFiltro, idMedioComunicacionNovedad As Integer,
                                            idNovedad As Long, idNovedadPadre As Long, idCliente As Long, idProspecto As Long, idProveedor As Long,
                                            idPrioridadNovedad As Integer, esComentario As String,
                                            tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                            finalizado As String,
                                            idFuncion As String,
                                            idMetodoResolucionNovedad As Integer,
                                            revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                                            priorizado As Entidades.Publicos.SiNoTodos,
                                            idAplicacion As String,
                                            nroVersion As String,
                                            idProyecto As Integer,
                                            prioridadDelProyectoDesde As Decimal,
                                            prioridadDelProyectoHasta As Decimal,
                                            estadoDelProyecto As Integer,
                                            clasificacionDelProyecto As Integer,
                                            enGarantia As Entidades.Publicos.SiNoTodos,
                                            enPrestamo As Entidades.Publicos.SiNoTodos,
                                            estadoPrestamo As Entidades.CRMNovedad.EstadosProductosPrestados,
                                            activo As Entidades.Publicos.SiNoTodos,
                                            idTipoComentario As Integer) As DataTable

      Return New SqlServer.CRMNovedadesSeguimiento(da).
                     CRMNovedades_GetNovedadesSeguimientos(desde, hasta, idTipoNovedad, idCategoriaNovedad, idEstadoNovedad,
                                                           idUsuario, tipoUsuario, idMedioComunicacionNovedad,
                                                           idNovedad, idNovedadPadre, idCliente, idProspecto, idProveedor,
                                                           idPrioridadNovedad, esComentario,
                                                           tipoFechaFiltro, finalizado, idFuncion, idMetodoResolucionNovedad,
                                                           revisionAdministrativa, priorizado, idAplicacion, nroVersion, idProyecto,
                                                           prioridadDelProyectoDesde, prioridadDelProyectoHasta, estadoDelProyecto,
                                                           clasificacionDelProyecto, enGarantia, enPrestamo, estadoPrestamo, activo,
                                                           idTipoComentario)
   End Function

#End Region

   Public Function GetNovedadesParaWeb() As DataTable
      Return New SqlServer.CRMNovedadesSeguimiento(da).GetNovedadesParaWeb(Today.AddYears(-1), Today.AddMonths(-6), Publicos.NombreBaseAdjuntosCRM)
   End Function

End Class