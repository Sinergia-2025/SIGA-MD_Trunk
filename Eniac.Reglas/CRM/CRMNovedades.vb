Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Public Class CRMNovedades
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon)

#Region "Constructores"

   Private _base As String = String.Empty

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CRMNovedades"
      da = accesoDatos
      _base = Publicos.NombreBaseAdjuntosCRM
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.CRMNovedad)))
   End Sub

   Public Sub Inserta(entidad As Entidades.CRMNovedad)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.CRMNovedad)))
   End Sub

   Public Sub Actualiza(entidad As Entidades.CRMNovedad)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.CRMNovedad)))
   End Sub

   Public Sub Borra(entidad As Entidades.CRMNovedad)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Protected Overridable Function GetSqlServer() As Eniac.SqlServer.CRMNovedades
      Return New SqlServer.CRMNovedades(da)
   End Function


   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return GetSqlServer().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overloads Function Buscar(entidad As Eniac.Entidades.Buscar, TipoNovedad As Entidades.CRMTipoNovedad,
                                    finalizado As Boolean?, usuarioAsignado As String) As DataTable
      Dim tipo As String = String.Empty

      If TipoNovedad IsNot Nothing Then
         tipo = TipoNovedad.IdTipoNovedad
      End If

      Return Buscar(entidad, tipo, finalizado, usuarioAsignado)
   End Function

   Public Overloads Function Buscar(entidad As Entidades.Buscar, idTipoNovedad As String,
                                    finalizado As Boolean?, usuarioAsignado As String) As DataTable
      Return GetSqlServer().Buscar(entidad.Columna, entidad.Valor.ToString(), idTipoNovedad, finalizado, usuarioAsignado)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetNovedades(desde:=Nothing, hasta:=Nothing, tipoFechaFiltro:=Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad, idTipoNovedad:=String.Empty, buscarABM:=Nothing,
                          CategoriasNovedades:=Nothing, EstadoNovedades:=Nothing, MedioNovedades:=Nothing, MetodoNovedades:=Nothing, idUsuarioAsignado:=String.Empty,
                          idNovedad:=0, idNovedadPadre:=0, idCliente:=0, idProspecto:=0, idProveedor:=0, idPrioridadNovedad:=0,
                          idUsuarioAlta:=String.Empty, finalizado:="TODOS", idProyecto:=0,
                          revisionAdministrativa:=Entidades.Publicos.SiNoTodos.TODOS, idAplicacion:=String.Empty, nroVersion:=String.Empty, descripcion:=String.Empty,
                          priorizado:=Entidades.Publicos.SiNoTodos.TODOS, usaOrdenamientoDelTablero:=True, idFuncion:=String.Empty, prioridadDelProyectoDesde:=0, prioridadDelProyectoHasta:=0,
                          estadoDelProyecto:=0, clasificacionDelProyecto:=0,
                          enGarantia:=Entidades.Publicos.SiNoTodos.TODOS, enPrestamo:=Entidades.Publicos.SiNoTodos.TODOS, estadoPrestamo:=Entidades.CRMNovedad.EstadosProductosPrestados.TODOS,
                          tipoUsuario:=0, visualizaSucursal:=Nothing, sucursales:=Nothing, categoriaReporta:="TODOS", patenteVehiculo:=String.Empty)
   End Function
   Public Function GetEmpty() As DataTable
      Return GetNovedades(desde:=Nothing, hasta:=Nothing, tipoFechaFiltro:=Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad, idTipoNovedad:=String.Empty, buscarABM:=Nothing,
                           CategoriasNovedades:=Nothing, EstadoNovedades:=Nothing, MedioNovedades:=Nothing, MetodoNovedades:=Nothing, idUsuarioAsignado:=String.Empty,
                          idNovedad:=-1, idNovedadPadre:=0, idCliente:=0, idProspecto:=0, idProveedor:=0, idPrioridadNovedad:=0,
                          idUsuarioAlta:=String.Empty, finalizado:="TODOS", idProyecto:=0,
                          revisionAdministrativa:=Entidades.Publicos.SiNoTodos.TODOS, idAplicacion:=String.Empty, nroVersion:=String.Empty, descripcion:=String.Empty,
                          priorizado:=Entidades.Publicos.SiNoTodos.TODOS, usaOrdenamientoDelTablero:=True, idFuncion:=String.Empty, prioridadDelProyectoDesde:=0, prioridadDelProyectoHasta:=0,
                          estadoDelProyecto:=0, clasificacionDelProyecto:=0,
                          enGarantia:=Entidades.Publicos.SiNoTodos.TODOS, enPrestamo:=Entidades.Publicos.SiNoTodos.TODOS, estadoPrestamo:=Entidades.CRMNovedad.EstadosProductosPrestados.TODOS,
                          tipoUsuario:=0, visualizaSucursal:=Nothing, sucursales:=Nothing, categoriaReporta:="TODOS", patenteVehiculo:=String.Empty)
   End Function

#End Region

#Region "Metodos Privados"

   Protected Overridable Sub EjecutaSP(en As Entidades.CRMNovedad, tipo As TipoSP)
      'Dim en As Entidades.CRMNovedad = DirectCast(entidad, Entidades.CRMNovedad)

      Dim _cache = New BusquedasCacheadas()

      If en.IdNovedad = 0 Then
         en.IdNovedad = GetCodigoMaximo(en.IdTipoNovedad, en.Letra, en.CentroEmisor) + 1L
         en.TipoNovedad = New Reglas.CRMTiposNovedades(da).GetUno(en.IdTipoNovedad)
      ElseIf tipo = TipoSP._I Then
         If Existe(en.TipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad) Then
            Throw New Exception(String.Format("Ya existe un {0} con número {1}. Por favor verifique.", en.TipoNovedad.NombreTipoNovedad, en.IdNovedad))
         End If
      End If

      If tipo <> TipoSP._D Then
         ValidarNovedad(en)
      End If

      'en.FechaEstadoNovedad = Now
      'en.UsuarioEstadoNovedad.Usuario = Entidades.Usuario.Actual.Nombre

      Dim rSequimiento = New CRMNovedadesSeguimiento(da)
      Dim rProductos = New CRMNovedadesProductos(da)

      Dim rSeguimientoAdjunto = New CRMNovedadesSeguimientoAdjuntos(da, Me._base)
      Dim rCambioEstado = New CRMNovedadesCambiosEstados(da)
      Dim sqlClteInter = New SqlServer.CRMClientesInterlocutores(da)
      Dim sqlProvInter = New SqlServer.CRMProveedoresInterlocutores(da)
      Dim sqlProsInter = New SqlServer.CRMProspectosInterlocutores(da)

      '# Auditorias
      Dim rAuditoria As Reglas.Auditorias = New Reglas.Auditorias(da)
      Dim op As Entidades.OperacionesAuditorias = New Entidades.OperacionesAuditorias
      '-----------------------

      Dim lstNuevosSeguimientos = New List(Of Entidades.CRMNovedadSeguimiento)()
      Dim lstSeguimientosExistentes = New List(Of Entidades.CRMNovedadSeguimiento)()

      If Not en.FechaEstadoNovedad.HasValue Then
         en.FechaEstadoNovedad = Now
      End If

      For Each seg As Entidades.CRMNovedadSeguimiento In en.Seguimientos
         If seg.TipoNovedad Is Nothing AndAlso seg.IdNovedad = 0 Then
            seg.TipoNovedad = en.TipoNovedad
            seg.Letra = en.Letra
            seg.CentroEmisor = en.CentroEmisor
            seg.IdNovedad = en.IdNovedad
            seg.EstadoNovedad = en.EstadoNovedad
            seg.UsuarioAsignado = en.UsuarioAsignado
            lstNuevosSeguimientos.Add(seg)
         Else
            If seg.EsComentario Then
               lstSeguimientosExistentes.Add(seg)
            End If
         End If
      Next

      If Not String.IsNullOrWhiteSpace(en.NuevoComentario) Then
         Dim adjunto As Entidades.CRMNovedadSeguimientoAdjunto = Nothing
         If Not String.IsNullOrWhiteSpace(en.NuevoAdjunto) AndAlso IO.File.Exists(en.NuevoAdjunto) Then
            adjunto = New Entidades.CRMNovedadSeguimientoAdjunto()
            adjunto.NombreAdjunto = en.NuevoAdjunto
         End If
         lstNuevosSeguimientos.Add(New Entidades.CRMNovedadSeguimiento(en, en.FechaEstadoNovedad, en.NuevoComentario, en.Interlocutor, True, en.NuevoIdTipoComentarioNovedad, en.EstadoNovedad, adjunto))
      End If

      If tipo = TipoSP._I AndAlso lstNuevosSeguimientos.Count = 0 Then
         lstNuevosSeguimientos.Add(New Entidades.CRMNovedadSeguimiento(en, en.FechaEstadoNovedad, "Alta de la novedad", String.Empty, True, en.NuevoIdTipoComentarioNovedad, en.EstadoNovedad, adjunto:=Nothing))
      End If

      If en.EstadoNovedad.ActualizaUsuarioResponsable Then
         If en.UsuarioResponsable Is Nothing Then en.UsuarioResponsable = New Entidades.Usuario()
         en.UsuarioResponsable.Usuario = en.UsuarioAsignado.Usuario ' Entidades.Usuario.Actual.Nombre
      End If

      Dim fechaActualizacionWeb As Date? = Nothing   'Desde la aplicación de gestión pasamos siempre NOTHING para que lo grabe SQL

      Dim sqlC As SqlServer.CRMNovedades = GetSqlServer()
      Select Case tipo
         Case TipoSP._I
            If en.EstadoNovedad.Finalizado Then
               en.FechaFinalizado = Now
               en.IdEstadoNovedadFinalizado = en.IdEstadoNovedad
               en.IdUsuarioFinalizado = en.IdUsuarioAsignado
            End If
            If en.EstadoNovedad.Entregado = Entidades.CRMEstadoNovedad.EntregadoValores.Graba Then
               en.FechaEntregado = Now
               en.IdEstadoNovedadEntregado = en.IdEstadoNovedad

               Dim rUsuario = New Reglas.Usuarios(da)
               If rUsuario.UsuarioEsDeProceso(en.IdUsuarioAsignado) Then
                  en.IdUsuarioEntregado = actual.Nombre
               Else
                  en.IdUsuarioEntregado = en.IdUsuarioAsignado
               End If

            ElseIf en.EstadoNovedad.Entregado = Entidades.CRMEstadoNovedad.EntregadoValores.Limpia Then
               en.FechaEntregado = Nothing
               en.IdEstadoNovedadEntregado = Nothing
               en.IdUsuarioEntregado = String.Empty
            End If

            en.Contador1 = If(en.EstadoNovedad.AcumulaContador1, 1, 0)
            en.Contador2 = If(en.EstadoNovedad.AcumulaContador2, 1, 0)

            en.FechaAlta = Now
            en.UsuarioAlta.Usuario = actual.Nombre
            en.UsuarioEstadoNovedad.Usuario = actual.Nombre
            sqlC.CRMNovedades_I(fechaActualizacionWeb,
                                en.IdTipoNovedad,
                                en.Letra,
                                en.CentroEmisor,
                                en.IdNovedad,
                                en.FechaNovedad,
                                en.Descripcion,
                                en.IdPrioridadNovedad,
                                en.IdCategoriaNovedad,
                                en.IdEstadoNovedad,
                                en.FechaEstadoNovedad.Value,
                                en.IdUsuarioEstadoNovedad,
                                en.FechaAlta,
                                en.IdUsuarioAlta,
                                en.IdUsuarioAsignado,
                                en.Avance,
                                en.IdMedioComunicacionNovedad,
                                en.IdCliente,
                                en.IdProspecto,
                                en.IdFuncion,
                                en.IdSistema,
                                en.FechaProximoContacto,
                                en.BanderaColor,
                                en.Interlocutor,
                                en.IdMetodoResolucionNovedad,
                                en.IdProveedor,
                                en.IdProyecto,
                                en.RevisionAdministrativa,
                                en.Priorizado,
                                en.IdTipoNovedadPadre,
                                en.LetraPadre,
                                en.CentroEmisorPadre,
                                en.IdNovedadPadre,
                                en.Version,
                                en.VersionFecha,
                                en.FechaInicioPlan,
                                en.FechaFinPlan,
                                en.TiempoEstimado,
                                en.IdUsuarioResponsable,
                                en.Cantidad,
                                en.IdSucursalService,
                                en.IdTipoComprobanteService,
                                en.LetraService,
                                en.CentroEmisorService,
                                en.NumeroComprobanteService,
                                en.IdProducto,
                                en.NombreProducto,
                                en.CantidadProducto,
                                en.CostoReparacion,
                                en.IdProductoPrestado,
                                en.CantidadProductoPrestado,
                                en.NroSerieProductoPrestado,
                                en.ProductoPrestadoDevuelto,
                                en.IdProveedorService,
                                en.Contador1,
                                en.Contador2,
                                en.IdProductoNovedad,
                                en.EtiquetaNovedad,
                                en.NroDeSerie,
                                en.TieneGarantiaService,
                                en.UbicacionService,
                                en.IdSucursalFact,
                                en.IdTipoComprobanteFact,
                                en.LetraFact,
                                en.CentroEmisorFact,
                                en.NumeroComprobanteFact,
                                en.RequiereTesteo,
                                en.FechaEntregado,
                                en.FechaFinalizado,
                                en.IdEstadoNovedadEntregado,
                                en.IdEstadoNovedadFinalizado,
                                en.IdUsuarioEntregado,
                                en.IdUsuarioFinalizado,
                                en.IdEstadoNovedadAnterior,
                                en.AvanceAnterior,
                                en.Observacion,
                                en.ClienteValorizacionEstrellas,
                                en.AnticipoNovedad,
                                en.FechaHoraRetiro,
                                en.IdDomicilioRetiro,
                                en.FechaHoraEntrega,
                                en.IdDomicilioEntrega,
                                en.IdProveedorGarantia,
                                en.FechaHoraEnvioGarantia,
                                en.FechaHoraRetiroGarantia,
                                en.IdMarcaProducto,
                                en.NombreMarcaProducto,
                                en.IdModeloProducto,
                                en.NombreModeloProducto,
                                en.IdSucursalNovedad,
                                en.ServiceLugarCompra, en.ServiceLugarCompraFecha, en.ServiceLugarCompraTipoComprobante, en.ServiceLugarCompraNumeroComprobante,
                                en.IdAplicacionTerceros, en.IdMotivoNovedad, en.ComentarioPrincipal, en.PatenteVehiculo)

            rCambioEstado._Insertar(New Entidades.CRMNovedadCambioEstado(en) With
                                       {
                                          .EstadoNovedad = en.EstadoNovedad,
                                          .FechaCambioEstado = en.FechaEstadoNovedad.IfNull(Date.Today),
                                          .IdUsuario = en.IdUsuarioEstadoNovedad,
                                          .IdUsuarioAsignado = en.IdUsuarioAsignado,
                                          .IdSucursalNovedad = en.IdSucursalNovedad
                                       })

            Select Case en.ComentarioPrincipal
               Case Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ninguno
                  'Limpio cualquier tilde que hubiera
                  'Como en pantalla se seleccionó NINGUNO no debería haber uno seleccionado, pero lo hago por las dudas
                  lstNuevosSeguimientos.ForEach(Sub(s) s.ComentarioPrincipal = False)
               Case Entidades.CRMNovedad.ComentarioPrincipalOptiones.Primero
                  If lstNuevosSeguimientos.Any() Then
                     'Limpio cualquier tilde que hubiera para pasarlo al primero
                     'Como en pantalla se seleccionó PRIMERO y estoy dando de alta no debería haber uno seleccionado,
                     'pero limpio primero por las dudas y luego busco el primero y lo marco como true
                     lstNuevosSeguimientos.ForEach(Sub(s) s.ComentarioPrincipal = False)
                     lstNuevosSeguimientos.Where(Function(s) s.EsComentario).FirstOrDefault().ComentarioPrincipal = True
                  End If
               Case Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ultimo
                  If lstNuevosSeguimientos.Any() Then
                     'Limpio cualquier tilde que hubiera para pasarlo al último
                     'Como en pantalla se seleccionó ULTIMO y estoy dando de alta no debería haber uno seleccionado,
                     'pero limpio primero por las dudas y luego busco el último y lo marco como true
                     lstNuevosSeguimientos.ForEach(Sub(s) s.ComentarioPrincipal = False)
                     lstNuevosSeguimientos.Where(Function(s) s.EsComentario).LastOrDefault().ComentarioPrincipal = True
                  End If
               Case Entidades.CRMNovedad.ComentarioPrincipalOptiones.Manual
                  'No hay que hacer nada. Debería venir solo uno de pantalla.
                  'Por las dudas verifico si hay solo uno marcado y disparo una excepción si no es así.
                  If lstNuevosSeguimientos.Where(Function(s) s.ComentarioPrincipal).Count <> 1 Then
                     Throw New Exception(String.Format("Debe seleccionar un Comentario como Principal si ha seleccionado Comentario Principal: {0}", en.ComentarioPrincipal.ToString()))
                  End If
            End Select

            rSequimiento._Insertar(lstNuevosSeguimientos)

            '-- Requerimiento 31709.- ----------------------------------------
            If en.ProductosNovedad IsNot Nothing Then
               '-- Informa Novedades Productos Para el Caso de Informarse.- --
               rProductos._Inserta(en)
            End If
            '-----------------------------------------------------------------

            en.Seguimientos = rSequimiento.GetTodos(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)
            en.CambiosEstados = rCambioEstado.GetTodos(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)
            en.CambiosEstadosAgrupado = rCambioEstado.GetTodosAgrupados(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)

            If en.IdCliente > 0 And Not String.IsNullOrWhiteSpace(en.Interlocutor) Then
               sqlClteInter.CRMClientesInterlocutores_I(en.IdCliente, en.Interlocutor)
            End If
            If en.IdProspecto > 0 And Not String.IsNullOrWhiteSpace(en.Interlocutor) Then
               sqlProsInter.CRMProspectosInterlocutores_I(en.IdProspecto, en.Interlocutor)
            End If
            If en.IdProveedor > 0 And Not String.IsNullOrWhiteSpace(en.Interlocutor) Then
               sqlProvInter.CRMProveedoresInterlocutores_I(en.IdProveedor, en.Interlocutor)
            End If

            '# Auditoría de CRMNovedades
            rAuditoria.Insertar("CRMNovedades", Entidades.OperacionesAuditorias.Alta, actual.Nombre, String.Format("IdTipoNovedad = '{0}' AND Letra = '{1}' AND CentroEmisor = {2} AND IdNovedad = {3}",
                                                                                                                   en.IdTipoNovedad,
                                                                                                                   en.Letra,
                                                                                                                   en.CentroEmisor,
                                                                                                                   en.IdNovedad), False)

         Case TipoSP._U
            Dim enActual As Entidades.CRMNovedad = GetUno(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)

            If enActual.IdEstadoNovedad <> en.IdEstadoNovedad Then
               'If lstNuevosSeguimientos.LongCount(Function(x) x.EsComentario = True) = 0 Then
               '   lstNuevosSeguimientos.Add(New Entidades.CRMNovedadSeguimiento(en, DateTime.Now, "Cambio de estado", en.EstadoNovedad) _
               '                                    With {.EsComentario = True,
               '                                          .UsuarioAsignado = en.UsuarioAsignado})
               'End If
               If en.EstadoNovedad.Finalizado AndAlso Not en.FechaFinalizado.HasValue Then
                  en.FechaFinalizado = Now
                  en.IdEstadoNovedadFinalizado = en.IdEstadoNovedad
                  en.IdUsuarioFinalizado = enActual.IdUsuarioAsignado
               End If
               If en.EstadoNovedad.Entregado = Entidades.CRMEstadoNovedad.EntregadoValores.Graba And Not en.FechaEntregado.HasValue Then
                  en.FechaEntregado = Now
                  en.IdEstadoNovedadEntregado = en.IdEstadoNovedad

                  Dim rUsuario = New Reglas.Usuarios(da)
                  If rUsuario.UsuarioEsDeProceso(enActual.IdUsuarioAsignado) Then
                     If rUsuario.UsuarioEsDeProceso(en.IdUsuarioAsignado) Then
                        en.IdUsuarioEntregado = actual.Nombre
                     Else
                        en.IdUsuarioEntregado = en.IdUsuarioAsignado
                     End If
                  Else
                     en.IdUsuarioEntregado = enActual.IdUsuarioAsignado
                  End If

               ElseIf en.EstadoNovedad.Entregado = Entidades.CRMEstadoNovedad.EntregadoValores.Limpia Then
                  en.FechaEntregado = Nothing
                  en.IdEstadoNovedadEntregado = Nothing
                  en.IdUsuarioEntregado = String.Empty
               End If
            End If

            If en.TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SERVICE) Then
               Dim oCtaCte As DataTable = New Reglas.CuentasCorrientes(da)._GetComprobantesDeNovedadTodos(en)
               For Each dr As DataRow In oCtaCte.Rows
                  Dim Empresa As Integer = New Reglas.Sucursales().GetUna(Integer.Parse(dr("IdSucursal").ToString()), False).IdEmpresa
                  If Empresa = actual.Sucursal.IdEmpresa Then
                     en.AnticipoNovedad = New CuentasCorrientes(da).GetRecibosDeNovedad(en).SumSecure(Function(rc) rc.ImporteTotal).IfNull()
                  Else
                     Exit For
                  End If
               Next
            End If

            ChequeaCambioNovedad(en, enActual, _cache, lstNuevosSeguimientos)
            If enActual.IdEstadoNovedad <> en.IdEstadoNovedad Then
               If Not en.MarcaCRMFecha Then
                  en.FechaEstadoNovedad = Now
               End If
               en.UsuarioEstadoNovedad.Usuario = actual.Nombre

               en.Contador1 = enActual.Contador1 + If(en.EstadoNovedad.AcumulaContador1, 1, 0)
               en.Contador2 = enActual.Contador2 + If(en.EstadoNovedad.AcumulaContador2, 1, 0)

               'TODO: DESHARDCODEAR
               'SPC: DESHARDCODEAR
               'URGENTE: DESHARDCODEAR
               'ESPERANDO TEST
               If en.IdEstadoNovedad = 478 AndAlso en.RequiereTesteo Then
                  Dim usuario = New Entidades.Usuario() With {.Usuario = actual.Nombre}
                  Dim usuarioAsignado = New Entidades.Usuario() With {.Usuario = "tester"}
                  Dim peTest = New Entidades.CRMNovedad()
                  peTest.TipoNovedad = en.TipoNovedad
                  peTest.Letra = en.Letra
                  peTest.CentroEmisor = en.CentroEmisor
                  peTest.IdNovedad = 0

                  peTest.IdCliente = en.IdCliente

                  peTest.FechaNovedad = Now
                  peTest.Descripcion = en.Descripcion
                  peTest.PrioridadNovedad = en.PrioridadNovedad
                  peTest.CategoriaNovedad = en.CategoriaNovedad
                  peTest.MedioComunicacionNovedad = en.MedioComunicacionNovedad
                  peTest.MetodoResolucionNovedad = Cache.CRMCacheHandler.Instancia.Metodos.Buscar(252)
                  peTest.EstadoNovedad = Cache.CRMCacheHandler.Instancia.Estados.Buscar(479) 'en.EstadoNovedad
                  peTest.FechaAlta = Now
                  peTest.UsuarioAlta = usuario
                  peTest.UsuarioAsignado = usuarioAsignado
                  peTest.IdProyecto = en.IdProyecto
                  peTest.IdFuncion = en.IdFuncion
                  peTest.IdSistema = en.IdSistema
                  peTest.IdTipoNovedadPadre = en.IdTipoNovedadPadre
                  peTest.LetraPadre = en.LetraPadre
                  peTest.CentroEmisorPadre = en.CentroEmisorPadre
                  peTest.IdNovedadPadre = en.IdNovedadPadre

                  peTest.EtiquetaNovedad = en.EtiquetaNovedad

                  peTest.Seguimientos.Add(New Entidades.CRMNovedadSeguimiento(novedad:=Nothing,
                                                                            fechaSeguimiento:=Nothing,
                                                                            comentario:=String.Format("Pendiente de DESARROLLO: {0}{1}-{3}",
                                                                                                      en.IdTipoNovedad.Substring(0, 2),
                                                                                                      en.Letra,
                                                                                                      en.CentroEmisor,
                                                                                                      en.IdNovedad).Truncar(2000),
                                                                            interlocutor:=String.Empty,
                                                                            esComentario:=True,
                                                                            idTipoComentarioNovedad:=1,
                                                                            estadoNovedad:=peTest.EstadoNovedad,
                                                                            adjunto:=Nothing))

                  peTest.Seguimientos.AddRange(en.Seguimientos.Where(Function(x) x.IdTipoComentarioNovedad.IfNull() = 7 And x.Activo).
                                                               OrderBy(Function(x) x.IdSeguimiento).
                                                               ToList().
                                                               ConvertAll(Function(x)
                                                                             Dim r = x.Clonar(x)
                                                                             r.IdNovedad = 0
                                                                             r.IdSeguimiento = 0
                                                                             r.TipoNovedad = Nothing
                                                                             Return r
                                                                          End Function))

                  Inserta(peTest)

               End If

               rCambioEstado._Insertar(New Entidades.CRMNovedadCambioEstado(en) With
                                       {
                                          .EstadoNovedad = en.EstadoNovedad,
                                          .FechaCambioEstado = en.FechaEstadoNovedad.IfNull(Date.Today),
                                          .IdUsuario = en.IdUsuarioEstadoNovedad,
                                          .IdUsuarioAsignado = en.IdUsuarioAsignado,
                                          .IdSucursalNovedad = en.IdSucursalNovedad
                                       })

            ElseIf Not enActual.IdSucursalNovedad.Equals(en.IdSucursalNovedad) Then
               rCambioEstado._Insertar(New Entidades.CRMNovedadCambioEstado(en) With
                                       {
                                          .EstadoNovedad = en.EstadoNovedad,
                                          .FechaCambioEstado = en.FechaEstadoNovedad.IfNull(Date.Today),
                                          .IdUsuario = en.IdUsuarioEstadoNovedad,
                                          .IdUsuarioAsignado = en.IdUsuarioAsignado,
                                          .IdSucursalNovedad = en.IdSucursalNovedad
                                       })

            End If

            If en.EstadoNovedad.Finalizado AndAlso Not en.ClienteValorizacionEstrellas.HasValue Then
               en.ClienteValorizacionEstrellas = _cache.BuscaClienteEntidadPorId(en.IdCliente).ValorizacionEstrellas
            End If

            sqlC.CRMNovedades_U(fechaActualizacionWeb,
                                en.IdTipoNovedad,
                                en.Letra,
                                en.CentroEmisor,
                                en.IdNovedad,
                                en.FechaNovedad,
                                en.Descripcion,
                                en.IdPrioridadNovedad,
                                en.IdCategoriaNovedad,
                                en.IdEstadoNovedad,
                                en.FechaEstadoNovedad.Value,
                                en.IdUsuarioEstadoNovedad,
                                en.FechaAlta,
                                en.IdUsuarioAlta,
                                en.IdUsuarioAsignado,
                                en.Avance,
                                en.IdMedioComunicacionNovedad,
                                en.IdCliente,
                                en.IdProspecto,
                                en.IdFuncion,
                                en.IdSistema,
                                en.FechaProximoContacto,
                                en.BanderaColor,
                                en.Interlocutor,
                                en.IdMetodoResolucionNovedad,
                                en.IdProveedor,
                                en.IdProyecto,
                                en.RevisionAdministrativa,
                                en.Priorizado,
                                en.IdTipoNovedadPadre,
                                en.LetraPadre,
                                en.CentroEmisorPadre,
                                en.IdNovedadPadre,
                                en.Version,
                                en.VersionFecha,
                                en.FechaInicioPlan,
                                en.FechaFinPlan,
                                en.TiempoEstimado,
                                en.IdUsuarioResponsable,
                                en.Cantidad,
                                en.IdSucursalService,
                                en.IdTipoComprobanteService,
                                en.LetraService,
                                en.CentroEmisorService,
                                en.NumeroComprobanteService,
                                en.IdProducto,
                                en.NombreProducto,
                                en.CantidadProducto,
                                en.CostoReparacion,
                                en.IdProductoPrestado,
                                en.CantidadProductoPrestado,
                                en.NroSerieProductoPrestado,
                                en.ProductoPrestadoDevuelto,
                                en.IdProveedorService,
                                en.Contador1,
                                en.Contador2,
                                en.IdProductoNovedad,
                                en.EtiquetaNovedad,
                                en.NroDeSerie,
                                en.TieneGarantiaService,
                                en.UbicacionService,
                                en.IdSucursalFact,
                                en.IdTipoComprobanteFact,
                                en.LetraFact,
                                en.CentroEmisorFact,
                                en.NumeroComprobanteFact,
                                en.RequiereTesteo,
                                en.FechaEntregado,
                                en.FechaFinalizado,
                                en.IdEstadoNovedadEntregado,
                                en.IdEstadoNovedadFinalizado,
                                en.IdUsuarioEntregado,
                                en.IdUsuarioFinalizado,
                                en.IdEstadoNovedadAnterior,
                                en.AvanceAnterior,
                                en.Observacion,
                                en.ClienteValorizacionEstrellas,
                                en.AnticipoNovedad,
                                en.FechaHoraRetiro,
                                en.IdDomicilioRetiro,
                                en.FechaHoraEntrega,
                                en.IdDomicilioEntrega,
                                en.IdProveedorGarantia,
                                en.FechaHoraEnvioGarantia,
                                en.FechaHoraRetiroGarantia,
                                en.IdMarcaProducto,
                                en.NombreMarcaProducto,
                                en.IdModeloProducto,
                                en.NombreModeloProducto,
                                en.IdSucursalNovedad,
                                en.ServiceLugarCompra, en.ServiceLugarCompraFecha, en.ServiceLugarCompraTipoComprobante, en.ServiceLugarCompraNumeroComprobante,
                                en.IdAplicacionTerceros, en.IdMotivoNovedad, en.ComentarioPrincipal, en.PatenteVehiculo)

            Select Case en.ComentarioPrincipal
               Case Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ninguno
                  'Limpio cualquier tilde que hubiera
                  'Como en pantalla se seleccionó NINGUNO no debería haber uno seleccionado, pero lo hago por las dudas
                  lstNuevosSeguimientos.ForEach(Sub(s) s.ComentarioPrincipal = False)
                  lstSeguimientosExistentes.ForEach(Sub(s) s.ComentarioPrincipal = False)

               Case Entidades.CRMNovedad.ComentarioPrincipalOptiones.Primero
                  If lstNuevosSeguimientos.Any() Then
                     'Limpio cualquier tilde que hubiera para pasarlo al primero
                     'Como en pantalla se seleccionó PRIMERO se puede dar vaciar situaciones ya que el primero podría estar entre los nuevo o los ya existentes.
                     'Incluso se podría haber cambiado la condición de Ninguno/Manual/Último a Primero en la Novedad, por lo que habría que cambiar igualmente.
                     'Entonces limpio primero ambas colecciones por las dudas y luego busco el primero entre los existentes. Si hay algún EsComentario entre
                     'los existentes le pongo al primero de ellos como Principal. Si no hay ninguno entre los existente, busco el primer comentario nuevo
                     'y le pongo Principal.
                     lstNuevosSeguimientos.ForEach(Sub(s) s.ComentarioPrincipal = False)
                     lstSeguimientosExistentes.ForEach(Sub(s) s.ComentarioPrincipal = False)

                     Dim primerComentarioExistente = lstSeguimientosExistentes.Where(Function(s) s.EsComentario).LastOrDefault()
                     If primerComentarioExistente IsNot Nothing Then
                        primerComentarioExistente.ComentarioPrincipal = True
                     Else
                        lstNuevosSeguimientos.Where(Function(s) s.EsComentario).LastOrDefault().ComentarioPrincipal = True
                     End If
                  End If

               Case Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ultimo
                  'Limpio cualquier tilde que hubiera para pasarlo al último
                  'Como en pantalla se seleccionó ULTIMO se puede dar vaciar situaciones ya que el último podría estar entre los nuevo o los ya existentes.
                  'Incluso se podría haber cambiado la condición de Ninguno/Manual a Último en la Novedad, por lo que habría que cambiar igualmente.
                  'Entonces limpio primero ambas colecciones por las dudas y luego busco el último entre los nuevos. Si hay algún EsComentario entre
                  'los nuevos a ese le pongo al último de ellos como Principal. Si no hay ninguno entre los nuevos, busco el último comentario existente
                  'y le pongo al último de los existentes como Principal.
                  lstNuevosSeguimientos.ForEach(Sub(s) s.ComentarioPrincipal = False)
                  lstSeguimientosExistentes.ForEach(Sub(s) s.ComentarioPrincipal = False)

                  Dim ultimoComentarioNuevo = lstNuevosSeguimientos.Where(Function(s) s.EsComentario).LastOrDefault()
                  If ultimoComentarioNuevo IsNot Nothing Then
                     ultimoComentarioNuevo.ComentarioPrincipal = True
                  Else
                     lstSeguimientosExistentes.Where(Function(s) s.EsComentario).FirstOrDefault().ComentarioPrincipal = True
                  End If

               Case Entidades.CRMNovedad.ComentarioPrincipalOptiones.Manual
                  'No hay que hacer nada. Debería venir solo uno de pantalla.
                  'Por las dudas verifico si hay solo uno marcado y disparo una excepción si no es así.
                  If lstNuevosSeguimientos.Where(Function(s) s.ComentarioPrincipal).Count() + lstSeguimientosExistentes.Where(Function(s) s.ComentarioPrincipal).Count() <> 1 Then
                     Throw New Exception(String.Format("Debe seleccionar solo un Comentario como Principal si ha seleccionado Comentario Principal: {0}", en.ComentarioPrincipal.ToString()))
                  End If

            End Select

            rSequimiento._Insertar(lstNuevosSeguimientos)

            rSequimiento._Actualizar(lstSeguimientosExistentes)

            For Each seg In en.SeguimientosBorrados
               rSequimiento._Borrar(seg)
               rSeguimientoAdjunto.Borrar(seg.IdTipoNovedad, seg.Letra, seg.CentroEmisor, seg.IdNovedad, seg.IdSeguimiento, seg.IdUnico)
            Next

            '-- Informa Novedades Productos Para el Caso de Informarse.- -----
            '-- REQ 31709.- ----------------------------------------
            rProductos._Actualiza(en, enActual)
            '-----------------------------------------------------------------

            en.Seguimientos = rSequimiento.GetTodos(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)
            en.CambiosEstados = rCambioEstado.GetTodos(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)
            en.CambiosEstadosAgrupado = rCambioEstado.GetTodosAgrupados(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)
            en.ProductosNovedad = rProductos.GetTodos(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)
            en.AjustarStock = Entidades.Publicos.AjustaStock.NOAJUSTA

            ''como estoy actualizando, previo a Insertar los nuevos seguimientos tengo que eliminarlos todos para que 
            ''se actualicen y agreguen los correctos.
            'rSequimiento.BorrarTodosDeUnaNovedad(enActual.Seguimientos)
            'rSequimiento.Insertar(en.Seguimientos)
            If en.IdCliente > 0 And Not String.IsNullOrWhiteSpace(en.Interlocutor) Then
               sqlClteInter.CRMClientesInterlocutores_I(en.IdCliente, en.Interlocutor)
            End If
            If en.IdProspecto > 0 And Not String.IsNullOrWhiteSpace(en.Interlocutor) Then
               sqlProsInter.CRMProspectosInterlocutores_I(en.IdProspecto, en.Interlocutor)
            End If
            If en.IdProveedor > 0 And Not String.IsNullOrWhiteSpace(en.Interlocutor) Then
               sqlProvInter.CRMProveedoresInterlocutores_I(en.IdProveedor, en.Interlocutor)
            End If

            '# Auditoría CRMNovedades

            '# Si al consultar la tabla de auditoria no encuentro registros, quiere decir que todavía no se guardó ninguna auditoria. Por lo tanto en el UPDATE, hago una operación de ALTA
            '# Caso contrario, MODIFICO.
            If rAuditoria.GetUno("CRMNovedades", String.Format("IdTipoNovedad = '{0}' AND Letra = '{1}' AND CentroEmisor = {2} AND IdNovedad = {3}",
                                 en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)).Rows.Count > 0 Then
               op = Entidades.OperacionesAuditorias.Modificacion
            Else
               op = Entidades.OperacionesAuditorias.Alta
            End If

            rAuditoria.Insertar("CRMNovedades", op, actual.Nombre, String.Format("IdTipoNovedad = '{0}' AND Letra = '{1}' AND CentroEmisor = {2} AND IdNovedad = {3}",
                                                                                 en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad), False)
         Case TipoSP._D
            en.AjustarStock = Entidades.Publicos.AjustaStock.REVERTIR

            rAuditoria.Insertar("CRMNovedades", Entidades.OperacionesAuditorias.Baja, actual.Nombre, String.Format("IdTipoNovedad = '{0}' AND Letra = '{1}' AND CentroEmisor = {2} AND IdNovedad = {3}",
                                                                                 en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad), False)
            '-- REQ-31802.- -Al momento de Eliminar una activad se genera un error en el CRM.-
            rCambioEstado._Borrar(en)
            rSequimiento._Borrar(en)
            '-- REQ-31709.- ------
            rProductos._Borra(en)
            '---------------------
            sqlC.CRMNovedades_D(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad)
      End Select

      en.NuevoComentario = String.Empty
      en.NuevoAdjunto = String.Empty

   End Sub

   Public Overridable Sub ValidarNovedad(en As Entidades.CRMNovedad)
      For Each dinamico As Entidades.CRMTipoNovedadDinamico In en.TipoNovedad.Dinamicos
         If dinamico.EsRequerido Then
            ValidarNovedad(en, dinamico.IdNombreDinamico)
         End If
      Next
   End Sub
   Public Overridable Sub ValidarNovedad(en As Entidades.CRMNovedad, dinamico As String)
      Select Case dinamico
         Case "CLIENTES"
            If en.IdCliente <= 0 Then
               Throw New Exception("El Cliente es requerido.")
            End If
         Case "PROSPECTOS"
            If en.IdProspecto <= 0 Then
               Throw New Exception("El Prospecto es requerido.")
            End If
         Case "PROVEEDORES"
            If en.IdProveedor <= 0 Then
               Throw New Exception("El Prospecto es requerido.")
            End If
         Case "FUNCIONES"
            If String.IsNullOrWhiteSpace(en.IdFuncion) Then
               Throw New Exception("La Función es requerida.")
            End If
         Case "SISTEMAS"
            If String.IsNullOrWhiteSpace(en.IdSistema) Then
               Throw New Exception("El Sistema es requerida.")
            End If
         Case "METODORESOLUCION"
            If en.IdMetodoResolucionNovedad <= 0 Then
               Throw New Exception("El Método de resolución es requerido.")
            End If
         Case "PRODUCTOS"
            If String.IsNullOrWhiteSpace(en.IdProductoNovedad) Then
               Throw New Exception("La producto es requerido.")
            End If
         Case Entidades.CRMTipoNovedad.TipoDinamico.APLICACIONTERCERO.ToString()
            If String.IsNullOrWhiteSpace(en.IdAplicacionTerceros) Then
               Throw New Exception("La aplicación de terceros es requerido.")
            End If
         Case Entidades.CRMTipoNovedad.TipoDinamico.MOTIVOS.ToString()
            If en.IdMotivoNovedad = 0 Then
               Throw New Exception("El motivo es requerido.")
            End If
         Case Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString()
            If String.IsNullOrWhiteSpace(en.PatenteVehiculo) Then
               Throw New Exception("La Patente del Vehículo es requerida.")
            End If
         Case Else

      End Select
   End Sub


   Protected Overridable Sub ChequeaCambioNovedad(enNueva As Entidades.CRMNovedad, enActual As Entidades.CRMNovedad, _cache As BusquedasCacheadas, lstSeguimiento As List(Of Entidades.CRMNovedadSeguimiento))
      If enActual.FechaNovedad <> enNueva.FechaNovedad Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Fecha de {0:dd/MM/yyyy HH:mm:ss} a {1:dd/MM/yyyy HH:mm:ss}.",
                                                                              enActual.FechaNovedad,
                                                                              enNueva.FechaNovedad),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.Descripcion <> enNueva.Descripcion Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Descripcion de ´{0}´ a ´{1}´.",
                                                                              enActual.Descripcion,
                                                                              enNueva.Descripcion),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdPrioridadNovedad <> enNueva.IdPrioridadNovedad Then
         enNueva.PrioridadNovedad = New Reglas.CRMPrioridadesNovedades(da).GetUno(enNueva.IdPrioridadNovedad)
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Prioridad de {0} a {1}.",
                                                                              enActual.PrioridadNovedad.NombrePrioridadNovedad,
                                                                              enNueva.PrioridadNovedad.NombrePrioridadNovedad),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdMedioComunicacionNovedad <> enNueva.IdMedioComunicacionNovedad Then
         enNueva.MedioComunicacionNovedad = New Reglas.CRMMediosComunicacionesNovedades(da).GetUno(enNueva.IdMedioComunicacionNovedad)
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Medio de {0} a {1}.",
                                                                              enActual.MedioComunicacionNovedad.NombreMedioComunicacionNovedad,
                                                                              enNueva.MedioComunicacionNovedad.NombreMedioComunicacionNovedad),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdMetodoResolucionNovedad <> enNueva.IdMetodoResolucionNovedad Then
         enNueva.MetodoResolucionNovedad = New Reglas.CRMMetodosResolucionesNovedades(da).GetUno(enNueva.IdMetodoResolucionNovedad)
         Dim nombreActual As String = "´´"
         Dim nombreNueva As String = "´´"
         If enActual.MetodoResolucionNovedad IsNot Nothing Then nombreActual = enActual.MetodoResolucionNovedad.NombreMetodoResolucionNovedad
         If enNueva.MetodoResolucionNovedad IsNot Nothing Then nombreNueva = enNueva.MetodoResolucionNovedad.NombreMetodoResolucionNovedad
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Medio de {0} a {1}.",
                                                                              nombreActual,
                                                                              nombreNueva),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdCategoriaNovedad <> enNueva.IdCategoriaNovedad Then
         enNueva.CategoriaNovedad = New Reglas.CRMCategoriasNovedades(da).GetUno(enNueva.IdCategoriaNovedad)
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Categoría de {0} a {1}.",
                                                                              enActual.CategoriaNovedad.NombreCategoriaNovedad,
                                                                              enNueva.CategoriaNovedad.NombreCategoriaNovedad),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdEstadoNovedad <> enNueva.IdEstadoNovedad Then
         enNueva.EstadoNovedad = New Reglas.CRMEstadosNovedades(da).GetUno(enNueva.IdEstadoNovedad)
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Estado de {0} a {1}.",
                                                                              enActual.EstadoNovedad.NombreEstadoNovedad,
                                                                              enNueva.EstadoNovedad.NombreEstadoNovedad),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.Avance <> enNueva.Avance Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Avance de {0:N0}% a {1:N0}%.",
                                                                              enActual.Avance,
                                                                              enNueva.Avance),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdUsuarioAsignado <> enNueva.IdUsuarioAsignado Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Usuario Asignado de {0} a {1}.",
                                                                              enActual.IdUsuarioAsignado,
                                                                              enNueva.IdUsuarioAsignado),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdUsuarioResponsable <> enNueva.IdUsuarioResponsable Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Usuario Responsable de {0} a {1}.",
                                                                              enActual.IdUsuarioResponsable,
                                                                              enNueva.IdUsuarioResponsable),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdCliente <> enNueva.IdCliente Then
         'Dim clienteActual As Entidades.Cliente = New Reglas.Clientes(da)._GetUno(enActual.IdCliente)
         'Dim clienteNuevo As Entidades.Cliente = New Reglas.Clientes(da)._GetUno(enNueva.IdCliente)
         Dim clienteActual As Entidades.Cliente = _cache.BuscaClienteEntidadPorId(enActual.IdCliente)
         Dim clienteNuevo As Entidades.Cliente = _cache.BuscaClienteEntidadPorId(enNueva.IdCliente)
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Cliente de {1} ({0}) a {3} ({2}).",
                                                                              clienteActual.CodigoCliente, clienteActual.NombreCliente,
                                                                              clienteNuevo.CodigoCliente, clienteNuevo.NombreCliente),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdProspecto <> enNueva.IdProspecto Then
         Dim clienteActual As Entidades.Cliente = New Reglas.Clientes(da, Entidades.Cliente.ModoClienteProspecto.Prospecto)._GetUno(enActual.IdCliente)
         Dim clienteNuevo As Entidades.Cliente = New Reglas.Clientes(da, Entidades.Cliente.ModoClienteProspecto.Prospecto)._GetUno(enNueva.IdCliente)
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Prospecto de {1} ({0}) a {3} ({2}).",
                                                                              clienteActual.CodigoCliente, clienteActual.NombreCliente,
                                                                              clienteNuevo.CodigoCliente, clienteNuevo.NombreCliente),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdProveedor <> enNueva.IdProveedor Then
         Dim proveedorActual As Entidades.Proveedor = New Reglas.Proveedores(da)._GetUno(enActual.IdProveedor)
         Dim proveedorNuevo As Entidades.Proveedor = New Reglas.Proveedores(da)._GetUno(enNueva.IdProveedor)
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Proveedor de {1} ({0}) a {3} ({2}).",
                                                                              proveedorActual.CodigoProveedor, proveedorActual.NombreProveedor,
                                                                              proveedorNuevo.CodigoProveedor, proveedorNuevo.NombreProveedor),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdFuncion <> enNueva.IdFuncion Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Función de {0} a {1}.",
                                                                              enActual.IdFuncion, enNueva.IdFuncion),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdSistema <> enNueva.IdSistema Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Sistema de {0} a {1}.",
                                                                              enActual.IdSistema, enNueva.IdSistema),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      Dim nombreBanderaColorActual As String = Entidades.CRMNovedad.NombreBanderaColor(enActual.BanderaColor)
      Dim nombreBanderaColorNuevo As String = Entidades.CRMNovedad.NombreBanderaColor(enNueva.BanderaColor)
      If nombreBanderaColorActual <> nombreBanderaColorNuevo Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Color de ´{0}´ a ´{1}´.",
                                                                              nombreBanderaColorActual, nombreBanderaColorNuevo),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If (enActual.FechaProximoContacto.HasValue And Not enNueva.FechaProximoContacto.HasValue) OrElse
         (Not enActual.FechaProximoContacto.HasValue And enNueva.FechaProximoContacto.HasValue) OrElse
         (enActual.FechaProximoContacto.HasValue AndAlso enNueva.FechaProximoContacto.HasValue AndAlso
          enActual.FechaProximoContacto.Value <> enNueva.FechaProximoContacto.Value) Then
         Dim fechaActual As String = String.Empty
         Dim fechaNueva As String = String.Empty
         If enActual.FechaProximoContacto.HasValue Then fechaActual = enActual.FechaProximoContacto.Value.ToString("dd/MM/yyyy HH:mm")
         If enNueva.FechaProximoContacto.HasValue Then fechaNueva = enNueva.FechaProximoContacto.Value.ToString("dd/MM/yyyy HH:mm")
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Fecha de Proximo Contacto de ´{0}´ a ´{1}´.",
                                                                              fechaActual, fechaNueva),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.Interlocutor <> enNueva.Interlocutor Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Interlocutor de ´{0}´ a ´{1}´.",
                                                                              enActual.Interlocutor, enNueva.Interlocutor),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If (enActual.FechaInicioPlan.HasValue And Not enNueva.FechaInicioPlan.HasValue) OrElse
       (Not enActual.FechaInicioPlan.HasValue And enNueva.FechaInicioPlan.HasValue) OrElse
       (enActual.FechaInicioPlan.HasValue AndAlso enNueva.FechaInicioPlan.HasValue AndAlso
        enActual.FechaInicioPlan.Value <> enNueva.FechaInicioPlan.Value) Then
         Dim fechaActual As String = String.Empty
         Dim fechaNueva As String = String.Empty
         If enActual.FechaInicioPlan.HasValue Then fechaActual = enActual.FechaInicioPlan.Value.ToString("dd/MM/yyyy HH:mm")
         If enNueva.FechaInicioPlan.HasValue Then fechaNueva = enNueva.FechaInicioPlan.Value.ToString("dd/MM/yyyy HH:mm")
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Fecha de Inicio Plan de ´{0}´ a ´{1}´.",
                                                                              fechaActual, fechaNueva),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If (enActual.FechaFinPlan.HasValue And Not enNueva.FechaFinPlan.HasValue) OrElse
      (Not enActual.FechaFinPlan.HasValue And enNueva.FechaFinPlan.HasValue) OrElse
      (enActual.FechaFinPlan.HasValue AndAlso enNueva.FechaFinPlan.HasValue AndAlso
       enActual.FechaFinPlan.Value <> enNueva.FechaFinPlan.Value) Then
         Dim fechaActual As String = String.Empty
         Dim fechaNueva As String = String.Empty
         If enActual.FechaFinPlan.HasValue Then fechaActual = enActual.FechaFinPlan.Value.ToString("dd/MM/yyyy HH:mm")
         If enNueva.FechaFinPlan.HasValue Then fechaNueva = enNueva.FechaFinPlan.Value.ToString("dd/MM/yyyy HH:mm")
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Fecha de Fin Plan de ´{0}´ a ´{1}´.",
                                                                              fechaActual, fechaNueva),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If (enActual.VersionFecha.HasValue And Not enNueva.VersionFecha.HasValue) OrElse
            (Not enActual.VersionFecha.HasValue And enNueva.VersionFecha.HasValue) OrElse
            (enActual.VersionFecha.HasValue AndAlso enNueva.VersionFecha.HasValue AndAlso
             enActual.VersionFecha.Value <> enNueva.VersionFecha.Value) Then
         Dim fechaActual As String = String.Empty
         Dim fechaNueva As String = String.Empty
         If enActual.VersionFecha.HasValue Then fechaActual = enActual.VersionFecha.Value.ToString("dd/MM/yyyy HH:mm")
         If enNueva.VersionFecha.HasValue Then fechaNueva = enNueva.VersionFecha.Value.ToString("dd/MM/yyyy HH:mm")
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Fecha de Version de ´{0}´ a ´{1}´.",
                                                                              fechaActual, fechaNueva),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.Version <> enNueva.Version Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Version de ´{0}´ a ´{1}´.",
                                                                              enActual.Version, enNueva.Version),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdTipoNovedadPadre <> enNueva.IdTipoNovedadPadre Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Tipo de Novedad Padre de {0} a {1}.",
                                                                              enActual.IdTipoNovedadPadre, enNueva.IdTipoNovedadPadre),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.IdNovedadPadre <> enNueva.IdNovedadPadre Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió el Nro. de Novedad Padre de {0} a {1}.",
                                                                              enActual.IdNovedadPadre, enNueva.IdNovedadPadre),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If

      If enActual.Priorizado <> enNueva.Priorizado Then
         lstSeguimiento.Add(New Entidades.CRMNovedadSeguimiento(enNueva, enNueva.FechaEstadoNovedad.Value,
                                                                String.Format("Cambió la Priorizacion de {0} a {1}.",
                                                                              enActual.Priorizado, enNueva.Priorizado),
                                                                estadoNovedad:=enNueva.EstadoNovedad))
      End If


   End Sub

   Protected Overridable Sub CargarUno(o As Entidades.CRMNovedad, dr As DataRow)
      With o
         Const tag As String = "CRMNovedades.CargarUno"
         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Inicia"))
         '.TipoNovedad = New Reglas.CRMTiposNovedades().GetUno(dr(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
         .Letra = dr(Entidades.CRMNovedad.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).ToString())
         .IdNovedad = Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).ToString())

         .FechaNovedad = DateTime.Parse(dr(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).ToString())
         .Descripcion = dr(Entidades.CRMNovedad.Columnas.Descripcion.ToString()).ToString()
         .PrioridadNovedad = New Reglas.CRMPrioridadesNovedades(da).GetUno(Integer.Parse(dr(Entidades.CRMNovedad.Columnas.IdPrioridadNovedad.ToString()).ToString()))
         .CategoriaNovedad = New Reglas.CRMCategoriasNovedades(da).GetUno(Integer.Parse(dr(Entidades.CRMNovedad.Columnas.IdCategoriaNovedad.ToString()).ToString()))
         .EstadoNovedad = New Reglas.CRMEstadosNovedades(da).GetUno(Integer.Parse(dr(Entidades.CRMNovedad.Columnas.IdEstadoNovedad.ToString()).ToString()))
         .FechaEstadoNovedad = DateTime.Parse(dr(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).ToString())
         .UsuarioEstadoNovedad = New Reglas.Usuarios(da).GetUno(dr(Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString()).ToString())
         .FechaAlta = DateTime.Parse(dr(Entidades.CRMNovedad.Columnas.FechaAlta.ToString()).ToString())
         .UsuarioAlta = New Reglas.Usuarios(da).GetUno(dr(Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString()).ToString())
         .UsuarioAsignado = New Reglas.Usuarios(da).GetUno(dr(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString()).ToString())
         If .UsuarioAsignado Is Nothing Then .UsuarioAsignado = New Entidades.Usuario()
         .UsuarioResponsable = New Reglas.Usuarios(da).GetUno(dr(Entidades.CRMNovedad.Columnas.IdUsuarioResponsable.ToString()).ToString())
         If .UsuarioResponsable Is Nothing Then .UsuarioResponsable = New Entidades.Usuario()

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.Avance.ToString()).ToString()) Then
            .Avance = Decimal.Parse(dr(Entidades.CRMNovedad.Columnas.Avance.ToString()).ToString())
         End If
         .MedioComunicacionNovedad = New Reglas.CRMMediosComunicacionesNovedades(da).GetUno(Integer.Parse(dr(Entidades.CRMNovedad.Columnas.IdMedioComunicacionNovedad.ToString()).ToString()))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdMetodoResolucionNovedad.ToString()).ToString()) Then
            .MetodoResolucionNovedad = New Reglas.CRMMetodosResolucionesNovedades(da).GetUno(Integer.Parse(dr(Entidades.CRMNovedad.Columnas.IdMetodoResolucionNovedad.ToString()).ToString()))
         End If

         .IdAplicacionTerceros = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdAplicacionTerceros.ToString()).IfNull()
         .MotivoNovedad = New CRMMotivosNovedades(da).GetUno(dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdMotivoNovedad.ToString()).IfNull, AccionesSiNoExisteRegistro.Vacio)
         .ComentarioPrincipal = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.ComentarioPrincipal.ToString()).StringToEnum(Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ultimo)

         .PatenteVehiculo = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.PatenteVehiculo.ToString()).IfNull()

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Luego de controles estáticos"))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdCliente.ToString()).ToString()) Then
            .IdCliente = Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdCliente.ToString()).ToString())
         End If

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Luego de cliente"))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdProspecto.ToString()).ToString()) Then
            .IdProspecto = Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdProspecto.ToString()).ToString())
         End If

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Luego de prospecto"))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdProveedor.ToString()).ToString()) Then
            .IdProveedor = Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdProveedor.ToString()).ToString())
         End If

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Luego de proyecto"))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdProyecto.ToString()).ToString()) Then
            .IdProyecto = Int32.Parse(dr(Entidades.CRMNovedad.Columnas.IdProyecto.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()).ToString()) Then
            .IdFuncion = dr(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()).ToString()
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdSistema.ToString()).ToString()) Then
            .IdSistema = dr(Entidades.CRMNovedad.Columnas.IdSistema.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()).ToString()) Then
            .FechaProximoContacto = DateTime.Parse(dr(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).ToString()) Then
            .BanderaColor = Drawing.Color.FromArgb(Integer.Parse(dr(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).ToString()))
         Else
            .BanderaColor = Nothing
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.Interlocutor.ToString()).ToString()) Then
            .Interlocutor = dr(Entidades.CRMNovedad.Columnas.Interlocutor.ToString()).ToString()
         End If

         .RevisionAdministrativa = Boolean.Parse(dr(Entidades.CRMNovedad.Columnas.RevisionAdministrativa.ToString()).ToString())

         .Priorizado = Boolean.Parse(dr(Entidades.CRMNovedad.Columnas.Priorizado.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString()).ToString()) Then
            .IdTipoNovedadPadre = dr(Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString()).ToString()
         End If

         .LetraPadre = dr(Entidades.CRMNovedad.Columnas.LetraPadre.ToString()).ToString()
         If IsNumeric(dr(Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString()).ToString()) Then
            .CentroEmisorPadre = Short.Parse(dr(Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString()).ToString()) Then
            .IdNovedadPadre = Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr.Field(Of String)("DescripcionPadre")) Then
            .DescripcionPadre = dr.Field(Of String)("DescripcionPadre")
         End If

         .Version = dr(Entidades.CRMNovedad.Columnas.Version.ToString()).ToString()

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString()).ToString()) Then
            .FechaInicioPlan = DateTime.Parse(dr(Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString()).ToString()) Then
            .FechaFinPlan = DateTime.Parse(dr(Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.VersionFecha.ToString()).ToString()) Then
            .VersionFecha = DateTime.Parse(dr(Entidades.CRMNovedad.Columnas.VersionFecha.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString()).ToString()) Then
            .TiempoEstimado = Decimal.Parse(dr(Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString()).ToString())
         End If

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Antes de Seguimiento"))

         If .IdNovedad <> 0 Then
            .Seguimientos = New CRMNovedadesSeguimiento(da).GetTodos(.IdTipoNovedad, .Letra, .CentroEmisor, .IdNovedad)
            '-- REQ-31709.- -----------------------------------------------------------------------------------------------
            .ProductosNovedad = New CRMNovedadesProductos(da).GetTodos(.IdTipoNovedad, .Letra, .CentroEmisor, .IdNovedad)
            '--------------------------------------------------------------------------------------------------------------
            .CambiosEstados = New CRMNovedadesCambiosEstados(da).GetTodos(.IdTipoNovedad, .Letra, .CentroEmisor, .IdNovedad)
            .CambiosEstadosAgrupado = New CRMNovedadesCambiosEstados(da).GetTodosAgrupados(.IdTipoNovedad, .Letra, .CentroEmisor, .IdNovedad)
         End If

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Finalizando"))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.Cantidad.ToString()).ToString()) Then
            .Cantidad = Decimal.Parse(dr(Entidades.CRMNovedad.Columnas.Cantidad.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdSucursalService.ToString()).ToString()) Then
            .IdSucursalService = Integer.Parse(dr(Entidades.CRMNovedad.Columnas.IdSucursalService.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdTipoComprobanteService.ToString()).ToString()) Then
            .IdTipoComprobanteService = dr(Entidades.CRMNovedad.Columnas.IdTipoComprobanteService.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.LetraService.ToString()).ToString()) Then
            .LetraService = dr(Entidades.CRMNovedad.Columnas.LetraService.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.CentroEmisorService.ToString()).ToString()) Then
            .CentroEmisorService = Short.Parse(dr(Entidades.CRMNovedad.Columnas.CentroEmisorService.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.NumeroComprobanteService.ToString()).ToString()) Then
            .NumeroComprobanteService = Long.Parse(dr(Entidades.CRMNovedad.Columnas.NumeroComprobanteService.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdProducto.ToString()).ToString()) Then
            .IdProducto = dr(Entidades.CRMNovedad.Columnas.IdProducto.ToString()).ToString()
         End If

         .NombreProducto = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.NombreProducto.ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.CantidadProducto.ToString()).ToString()) Then
            .CantidadProducto = Decimal.Parse(dr(Entidades.CRMNovedad.Columnas.CantidadProducto.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.CostoReparacion.ToString()).ToString()) Then
            .CostoReparacion = Decimal.Parse(dr(Entidades.CRMNovedad.Columnas.CostoReparacion.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdProductoPrestado.ToString()).ToString()) Then
            .IdProductoPrestado = dr(Entidades.CRMNovedad.Columnas.IdProductoPrestado.ToString()).ToString()
            .NombreProductoPrestado = dr.Field(Of String)("NombreProductoPrestado")
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.CantidadProductoPrestado.ToString()).ToString()) Then
            .CantidadProductoPrestado = Decimal.Parse(dr(Entidades.CRMNovedad.Columnas.CantidadProductoPrestado.ToString()).ToString())
         End If

         .NroSerieProductoPrestado = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.NroSerieProductoPrestado.ToString())
         .ProductoPrestadoDevuelto = Boolean.Parse(dr(Entidades.CRMNovedad.Columnas.ProductoPrestadoDevuelto.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdProveedorService.ToString()).ToString()) Then
            .IdProveedorService = Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdProveedorService.ToString()).ToString())
         End If

         .Contador1 = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.Contador1.ToString()).IfNull()
         .Contador2 = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.Contador2.ToString()).IfNull()

         If Not IsDBNull(dr(Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString())) Then
            .FechaActualizacionWeb = dr.Field(Of DateTime)(Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString())
         End If

         If Not IsDBNull(dr(Entidades.CRMNovedad.Columnas.IdProductoNovedad.ToString())) AndAlso Not String.IsNullOrWhiteSpace(dr(Entidades.CRMNovedad.Columnas.IdProductoNovedad.ToString()).ToString()) Then
            .IdProductoNovedad = dr(Entidades.CRMNovedad.Columnas.IdProductoNovedad.ToString()).ToString()
         End If

         .EtiquetaNovedad = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.EtiquetaNovedad.ToString())
         .NroDeSerie = dr.Field(Of String)("NroDeSerie")
         .TieneGarantiaService = dr.Field(Of Boolean?)(Entidades.CRMNovedad.Columnas.TieneGarantiaService.ToString())
         .UbicacionService = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.UbicacionService.ToString())

         '# Campos correspondientes a la facturación de la novedad
         .IdSucursalFact = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdSucursalFact.ToString())
         .IdTipoComprobanteFact = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoComprobanteFact.ToString())
         .LetraFact = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.LetraFact.ToString())
         .CentroEmisorFact = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.CentroEmisorFact.ToString())
         .NumeroComprobanteFact = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.NumeroComprobanteFact.ToString())

         If Not IsDBNull(dr(Entidades.CRMNovedad.Columnas.RequiereTesteo.ToString())) Then
            .RequiereTesteo = dr.Field(Of Boolean)(Entidades.CRMNovedad.Columnas.RequiereTesteo.ToString())
         End If

         .FechaEntregado = dr.Field(Of DateTime?)(Entidades.CRMNovedad.Columnas.FechaEntregado.ToString())
         .FechaFinalizado = dr.Field(Of DateTime?)(Entidades.CRMNovedad.Columnas.FechaFinalizado.ToString())
         .IdEstadoNovedadEntregado = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdEstadoNovedadEntregado.ToString())
         .IdEstadoNovedadFinalizado = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdEstadoNovedadFinalizado.ToString())

         .IdUsuarioEntregado = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdUsuarioEntregado.ToString())
         .IdUsuarioFinalizado = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdUsuarioFinalizado.ToString())
         .IdEstadoNovedadAnterior = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdEstadoNovedadAnterior.ToString())
         .AvanceAnterior = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.AvanceAnterior.ToString())
         .Observacion = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.Observacion.ToString())
         .ClienteValorizacionEstrellas = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.ClienteValorizacionEstrellas.ToString())

         '-- REQ-31756/31871/31988 - Carga Domicilios de Entrega-Retiro - Proveedor Garantia.- --------------------------------------
         '-- Datos de Anticipos y Saldos.- ------------------------------------------------------------------------------------------
         .AnticipoNovedad = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.AnticipoNovedad.ToString()).IfNull()
         '-- Datos de Retiro.- ------------------------------------------------------------------------------------------------------
         .FechaHoraRetiro = dr.Field(Of DateTime?)(Entidades.CRMNovedad.Columnas.FechaHoraRetiro.ToString())
         .IdDomicilioRetiro = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdDomicilioRetiro.ToString())
         '-- Datos de Entrega.- -----------------------------------------------------------------------------------------------------
         .FechaHoraEntrega = dr.Field(Of DateTime?)(Entidades.CRMNovedad.Columnas.FechaHoraEntrega.ToString())
         .IdDomicilioEntrega = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdDomicilioEntrega.ToString())
         '-- Datos de Garantia.- ----------------------------------------------------------------------------------------------------
         .IdProveedorGarantia = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.IdProveedorGarantia.ToString())
         .FechaHoraEnvioGarantia = dr.Field(Of DateTime?)(Entidades.CRMNovedad.Columnas.FechaHoraEnvioGarantia.ToString())
         .FechaHoraRetiroGarantia = dr.Field(Of DateTime?)(Entidades.CRMNovedad.Columnas.FechaHoraRetiroGarantia.ToString())
         '-- REQ-31710.- ------------------------------------------------------------------------------------------------------------  
         .IdMarcaProducto = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.idMarcaProducto.ToString())
         .NombreMarcaProducto = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.NombreMarcaProducto.ToString())
         .IdModeloProducto = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.idModeloProducto.ToString())
         .NombreModeloProducto = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.NombreModeloProducto.ToString())
         '-- REQ-31656.- ------------------------------------------------------------------------------------------------------------  
         .IdSucursalNovedad = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdSucursalNovedad.ToString())
         '---------------------------------------------------------------------------------------------------------------------------

         .ServiceLugarCompra = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.ServiceLugarCompra.ToString())
         .ServiceLugarCompraFecha = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.ServiceLugarCompraFecha.ToString())
         .ServiceLugarCompraTipoComprobante = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.ServiceLugarCompraTipoComprobante.ToString())
         .ServiceLugarCompraNumeroComprobante = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.ServiceLugarCompraNumeroComprobante.ToString())

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Fin"))

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Protected Overridable Function GetNewEntity() As Entidades.CRMNovedad
      Return New Entidades.CRMNovedad()
   End Function

   Public Function GetNewEntityWithDefaults(tipoNovedad As Entidades.CRMTipoNovedad, idUsuario As String) As Entidades.CRMNovedad
      Dim crm = GetNewEntity()

      crm.TipoNovedad = tipoNovedad
      crm.Letra = tipoNovedad.LetrasHabilitadas
      crm.CentroEmisor = 1
      crm.IdNovedad = 0
      crm.FechaNovedad = Date.Now
      crm.FechaAlta = Date.Now

      Dim usuario = New Entidades.Usuario() With {.Usuario = idUsuario}
      crm.UsuarioAlta = usuario
      crm.UsuarioAsignado = usuario

      crm.PrioridadNovedad = Cache.CRMCacheHandler.Instancia.Prioridades.BuscarDefaultOrFirst(tipoNovedad.IdTipoNovedad)
      crm.CategoriaNovedad = Cache.CRMCacheHandler.Instancia.Categorias.BuscarDefaultOrFirst(tipoNovedad.IdTipoNovedad)
      crm.EstadoNovedad = Cache.CRMCacheHandler.Instancia.Estados.BuscarDefaultOrFirst(tipoNovedad.IdTipoNovedad)
      crm.MedioComunicacionNovedad = Cache.CRMCacheHandler.Instancia.Medios.BuscarDefaultOrFirst(tipoNovedad.IdTipoNovedad)

      If tipoNovedad.DinamicoRequerido(Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION) Then
         crm.MetodoResolucionNovedad = Cache.CRMCacheHandler.Instancia.Metodos.BuscarDefaultOrFirst(tipoNovedad.IdTipoNovedad)
      End If

      Return crm
   End Function

   Public Function Get1(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Return GetSqlServer().CRMNovedades_G1(idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function

   Public Function GetUno(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Entidades.CRMNovedad
      Return GetUno(idTipoNovedad, letra, centroEmisor, idNovedad, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, accion As AccionesSiNoExisteRegistro) As Entidades.CRMNovedad
      Return CargaEntidad(Get1(idTipoNovedad, letra, centroEmisor, idNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() GetNewEntity(),
                          accion, Function() String.Format("No existe una novedad con {0} {1} {2:0000}-{3:00000000}", idTipoNovedad, letra, centroEmisor, idNovedad))
   End Function

   Public Function GetNovedades(desde As Date?, hasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                idTipoNovedad As String,
                                buscarABM As Eniac.Entidades.Buscar,
                                CategoriasNovedades As Entidades.CRMCategoriaNovedad(),
                                EstadoNovedades As Entidades.CRMEstadoNovedad(),
                                MedioNovedades As Entidades.CRMMedioComunicacionNovedad(),
                                MetodoNovedades As Entidades.CRMMetodoResolucionNovedad(),
                                idUsuarioAsignado As String,
                                idNovedad As Long,
                                idNovedadPadre As Long,
                                idCliente As Long,
                                idProspecto As Long,
                                idProveedor As Long,
                                idPrioridadNovedad As Integer,
                                idUsuarioAlta As String,
                                finalizado As String,
                                idProyecto As Integer,
                                revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                                idAplicacion As String,
                                nroVersion As String,
                                descripcion As String,
                                priorizado As Entidades.Publicos.SiNoTodos,
                                usaOrdenamientoDelTablero As Boolean,
                                idFuncion As String,
                                prioridadDelProyectoDesde As Decimal,
                                prioridadDelProyectoHasta As Decimal,
                                estadoDelProyecto As Integer,
                                clasificacionDelProyecto As Integer,
                                enGarantia As Entidades.Publicos.SiNoTodos,
                                enPrestamo As Entidades.Publicos.SiNoTodos,
                                estadoPrestamo As Entidades.CRMNovedad.EstadosProductosPrestados,
                                tipoUsuario As Integer,
                                visualizaSucursal As String,
                                sucursales As Entidades.Sucursal(),
                                categoriaReporta As String,
                                patenteVehiculo As String) As DataTable

      'medioDeComunicacion As Integer, -- Se quita porque el parámetro está duplicado
      Dim ordenamiento As StringBuilder = New StringBuilder()
      If usaOrdenamientoDelTablero Then
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            Dim tipoNovedad As Entidades.CRMTipoNovedad = New Reglas.CRMTiposNovedades(da).GetUno(idTipoNovedad)
            If tipoNovedad IsNot Nothing Then
               ordenamiento.AppendFormat("{0} {1}", tipoNovedad.PrimerOrdenGrilla.Replace("__", "."), If(tipoNovedad.PrimerOrdenDesc, " DESC", " "))
               If Not String.IsNullOrEmpty(tipoNovedad.SegundoOrdenGrilla) Then
                  ordenamiento.AppendFormat(", {0} {1}", tipoNovedad.SegundoOrdenGrilla.Replace("__", "."), If(tipoNovedad.SegundoOrdenDesc, " DESC", " "))
               End If
            Else
               ordenamiento.AppendFormat(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString())
            End If
         End If
      End If

      Dim fechaActualizacionDesde As DateTime? = Nothing
      Return GetSqlServer().CRMNovedades_GetNovedades(desde, hasta, tipoFechaFiltro, idTipoNovedad, buscarABM, CategoriasNovedades, EstadoNovedades,
                                                      MedioNovedades, MetodoNovedades,
                                                      idUsuarioAsignado,
                                                      idNovedad, idNovedadPadre, idCliente, idProspecto, idProveedor,
                                                      idPrioridadNovedad, idUsuarioAlta,
                                                      finalizado, idProyecto, revisionAdministrativa,
                                                      idAplicacion, nroVersion, descripcion,
                                                      priorizado, ordenamiento.ToString(), idFuncion,
                                                      fechaActualizacionDesde, prioridadDelProyectoDesde, prioridadDelProyectoHasta,
                                                      estadoDelProyecto, clasificacionDelProyecto, enGarantia, enPrestamo, estadoPrestamo, tipoUsuario,
                                                      visualizaSucursal, sucursales, categoriaReporta, patenteVehiculo)
   End Function


   Public Function GetNovedadesCambioEstado(desde As Date?, hasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                               idTipoNovedad As String,
                               buscarABM As Eniac.Entidades.Buscar,
                               idCategoriaNovedad As Integer,
                               idEstadoNovedad As Integer,
                               idUsuarioAsignado As String,
                               idMedioComunicacionNovedad As Integer,
                               idMetodoResolucionNovedad As Integer,
                               idNovedad As Long,
                               idNovedadPadre As Long,
                               idCliente As Long,
                               idProspecto As Long,
                               idProveedor As Long,
                               idPrioridadNovedad As Integer,
                               idUsuarioAlta As String,
                               finalizado As String,
                               idProyecto As Integer,
                               revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                               idAplicacion As String,
                               nroVersion As String,
                               descripcion As String,
                               priorizado As Entidades.Publicos.SiNoTodos,
                               usaOrdenamientoDelTablero As Boolean,
                               idFuncion As String,
                               prioridadDelProyectoDesde As Decimal,
                               prioridadDelProyectoHasta As Decimal,
                               estadoDelProyecto As Integer,
                               clasificacionDelProyecto As Integer,
                               enGarantia As Entidades.Publicos.SiNoTodos,
                               enPrestamo As Entidades.Publicos.SiNoTodos,
                               estadoPrestamo As Entidades.CRMNovedad.EstadosProductosPrestados,
                               tipoUsuario As Integer,
                               visualizaSucursal As String,
                               patenteVehiculo As String) As DataTable

      'medioDeComunicacion As Integer, -- Se quita porque el parámetro está duplicado
      Dim ordenamiento As StringBuilder = New StringBuilder()
      If usaOrdenamientoDelTablero Then
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            Dim tipoNovedad As Entidades.CRMTipoNovedad = New Reglas.CRMTiposNovedades(da).GetUno(idTipoNovedad)
            If tipoNovedad IsNot Nothing Then
               ordenamiento.AppendFormat("{0} {1}", tipoNovedad.PrimerOrdenGrilla.Replace("__", "."), If(tipoNovedad.PrimerOrdenDesc, " DESC", " "))
               If Not String.IsNullOrEmpty(tipoNovedad.SegundoOrdenGrilla) Then
                  ordenamiento.AppendFormat(", {0} {1}", tipoNovedad.SegundoOrdenGrilla.Replace("__", "."), If(tipoNovedad.SegundoOrdenDesc, " DESC", " "))
               End If
            Else
               ordenamiento.AppendFormat(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString())
            End If
         End If
      End If

      Dim fechaActualizacionDesde As DateTime? = Nothing
      Return GetSqlServer().CRMNovedades_GetNovedadesCambioEstado(desde, hasta, tipoFechaFiltro, idTipoNovedad, buscarABM, idCategoriaNovedad, idEstadoNovedad,
                                                    idUsuarioAsignado, idMedioComunicacionNovedad, idMetodoResolucionNovedad,
                                                    idNovedad, idNovedadPadre, idCliente, idProspecto, idProveedor,
                                                    idPrioridadNovedad, idUsuarioAlta,
                                                    finalizado, idProyecto, revisionAdministrativa,
                                                    idAplicacion, nroVersion, descripcion,
                                                    priorizado, ordenamiento.ToString(), idFuncion,
                                                    fechaActualizacionDesde, prioridadDelProyectoDesde, prioridadDelProyectoHasta,
                                                    estadoDelProyecto, clasificacionDelProyecto, enGarantia, enPrestamo, estadoPrestamo, tipoUsuario,
                                                    visualizaSucursal, New Generales().ExisteTabla("Embarcaciones"), patenteVehiculo)
   End Function



   Public Function GetAlertasInforme(desde As Date, hasta As Date, idTipoNovedad As String, fecNovedad As Boolean,
                                            idCategoriaNovedad As Integer, Priorizado As Boolean?) As DataTable

      Return GetSqlServer().CRMNovedades_GetAlertasInforme(desde, hasta, idTipoNovedad, fecNovedad, idCategoriaNovedad, Priorizado)
   End Function

   Public Function GetGestionesInforme(desde As Date, hasta As Date, idTipoNovedad As String, Usuario As String,
                                           idCategoriaNovedad As Integer, IdCategoria As Integer) As DataTable

      Return GetSqlServer().CRMNovedades_GetGestionesInforme(desde, hasta, idTipoNovedad, Usuario, idCategoriaNovedad, IdCategoria)
   End Function

   Public Function GetNovedadXTipo(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Try
         Me.da.OpenConection()

         Return GetSqlServer().GetNovedadXTipo(idTipoNovedad, letra, centroEmisor, idNovedad)

      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetTodos(idTipoNovedad As String) As List(Of Entidades.CRMNovedad)
      Dim dt As DataTable = Me.GetAll(idTipoNovedad)
      Dim o As Entidades.CRMNovedad
      Dim oLis As List(Of Entidades.CRMNovedad) = New List(Of Entidades.CRMNovedad)
      For Each dr As DataRow In dt.Rows
         o = GetNewEntity()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetNovedadesPorVersion(idAplicacion As String, idZonaGeografica As String, nroVersionDesde As String, nroVersionHasta As String) As DataTable
      Return GetSqlServer().GetNovedadesPorVersion(idAplicacion, idZonaGeografica, nroVersionDesde, nroVersionHasta)
   End Function

   Public Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short) As Long
      Return GetSqlServer().GetCodigoMaximo(idTipoNovedad, letra, centroEmisor)
   End Function

   Public Function Existe(tipoNovedad As Entidades.CRMTipoNovedad, letra As String, centroEmisor As Short, idNovedad As Long) As Boolean
      Return Existe(tipoNovedad.IdTipoNovedad, letra, centroEmisor, idNovedad)
   End Function

   Public Function Existe(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Boolean
      Return GetSqlServer().Existe(idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function

   Public Sub Importar(dt As DataTable, tspImportando As System.Windows.Forms.ToolStripProgressBar)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim drCol As DataRow() = dt.Select(String.Format("{0} = True", Entidades.Importadores.Columnas.Importa.ToString()))
         tspImportando.Maximum = drCol.Length
         For Each dr As DataRow In drCol
            Try
               If blnAbreConexion Then da.BeginTransaction()
               Dim o As Entidades.CRMNovedad = New Entidades.CRMNovedad()
               CargarUno(o, dr)

               o.NuevoComentario = dr(Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString()).ToString()

               If dr(Entidades.Importadores.Columnas.Accion.ToString()).Equals("A") Then
                  Inserta(o)
               ElseIf dr(Entidades.Importadores.Columnas.Accion.ToString()).Equals("M") Then
                  Actualiza(o)
               End If

               If blnAbreConexion Then da.CommitTransaction()
               dr(Entidades.Importadores.Columnas.EstadoImporta.ToString()) = "OK"
               tspImportando.PerformStep()
            Catch ex As Exception
               If blnAbreConexion Then da.RollbakTransaction()
               dr(Entidades.Importadores.Columnas.EstadoImporta.ToString()) = "ERROR"
               dr(Entidades.Importadores.Columnas.Mensaje.ToString()) = ex.Message
            End Try
            System.Windows.Forms.Application.DoEvents()
         Next
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Function GetNovedadesRelacionadas(n As Entidades.CRMNovedad) As DataTable
      Return GetSqlServer().CRMNovedades_GetNovedadesRelacionadas(n.IdTipoNovedad, n.Letra, n.CentroEmisor, n.IdNovedad,
                                                                                  n.IdTipoNovedadPadre, n.LetraPadre, n.CentroEmisorPadre, n.IdNovedadPadre)
   End Function

   Public Class GetClientesGestionResult
      Public Property Periodos As List(Of String)
      Public Property PeriodosCantidad As List(Of String)
      Public Property PeriodosHoras As List(Of String)
      Public Property Datos As DataTable
   End Class
   Public Function GetClientesGestion(idCliente As Long, fechaDesde As Date, fechaHasta As Date) As GetClientesGestionResult
      Dim periodos = New Tuple(Of Date, Date)(fechaDesde, fechaHasta).ToPeriodList(descending:=True)
      Dim periodosCantidad = periodos.ConvertAll(Function(s) String.Format("Cantidad_Mes_{0}", s))
      Dim periodosHoras = periodos.ConvertAll(Function(s) String.Format("Horas_Mes_{0}", s))
      Return EjecutaConConexion(
         Function()
            Dim dt = GetSqlServer().GetClientesGestion(idCliente, fechaDesde, fechaHasta, periodosCantidad, periodosHoras)
            Return New GetClientesGestionResult() With {.Periodos = periodos, .PeriodosCantidad = periodosCantidad, .PeriodosHoras = periodosHoras, .Datos = dt}
         End Function)
   End Function

   Public Function GetNovedadesXCliente(idTipoNovedad As String, idCliente As Long, fechaDesde As Date?, fechaHasta As Date?, topRegistros As Integer) As DataTable
      Return EjecutaConConexion(Function() GetSqlServer().GetNovedadesXCliente(idTipoNovedad, idCliente, fechaDesde, fechaHasta, topRegistros))
   End Function

   Public Function GetGestionesAlertasXCliente(idTipoNovedad As String,
                             IdCliente As Long) As DataTable
      Try
         Me.da.OpenConection()

         Return GetSqlServer().GetGestionesAlertasXCliente(idTipoNovedad, IdCliente)

      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetHojaNovedades(idUsuario As String, verDetalleActividades As Boolean, revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                                    fechaDesde As Date, fechaHasta As Date, idCliente As Long?, idProyecto As Integer?,
                                    idTipoCategoriaNovedad As Integer?, idCategoriaNovedad As Integer?,
                                    agrupadoPorCategoria As Boolean,
                                    idNovedad As Long, idAplicacion As String, nroVersion As String, idFuncion As String,
                                    totalizadoPor As Entidades.Publicos.PeriodosCalendarios) As DataTable
      Return EjecutaConConexion(Function() _GetHojaNovedades(idUsuario, verDetalleActividades, revisionAdministrativa,
                                                             fechaDesde, fechaHasta, idCliente, idProyecto,
                                                             idTipoCategoriaNovedad, idCategoriaNovedad,
                                                             agrupadoPorCategoria,
                                                             idNovedad, idAplicacion, nroVersion, idFuncion,
                                                             totalizadoPor))
   End Function

   Public Function _GetHojaNovedades(idUsuario As String, verDetalleActividades As Boolean, revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                                     fechaDesde As Date, fechaHasta As Date, idCliente As Long?, idProyecto As Integer?,
                                     idTipoCategoriaNovedad As Integer?, idCategoriaNovedad As Integer?,
                                     agrupadoPorCategoria As Boolean,
                                     idNovedad As Long, idAplicacion As String, nroVersion As String, idFuncion As String,
                                     totalizadoPor As Entidades.Publicos.PeriodosCalendarios) As DataTable
      Dim sql = GetSqlServer()

      Dim dias = New List(Of String)()
      Dim expDt = New StringBuilder()
      'cuando encuentro el lunes voy sumando de a un día hasta llegar al domingo
      For i = 0 To Convert.ToInt32(fechaHasta.Subtract(fechaDesde).TotalDays)
         If totalizadoPor = Entidades.Publicos.PeriodosCalendarios.Dia Then
            Dim columnaFecha = String.Format("Fecha_{0:yyyyMMdd}", fechaDesde.AddDays(i))
            dias.Add(columnaFecha)
            expDt.AppendFormat("ISNULL({0}, 0) + ", columnaFecha)
         ElseIf totalizadoPor = Entidades.Publicos.PeriodosCalendarios.Mes Then
            Dim columnaFecha = String.Format("Mes_{0:yyyyMM}", fechaDesde.AddDays(i))
            If Not dias.Contains(columnaFecha) Then
               dias.Add(columnaFecha)
               expDt.AppendFormat("ISNULL({0}, 0) + ", columnaFecha)
            End If
         ElseIf totalizadoPor = Entidades.Publicos.PeriodosCalendarios.Anio Then
            Dim columnaFecha = String.Format("Anio_{0:yyyy}", fechaDesde.AddDays(i))
            If Not dias.Contains(columnaFecha) Then
               dias.Add(columnaFecha)
               expDt.AppendFormat("ISNULL({0}, 0) + ", columnaFecha)
            End If
         End If
      Next
      expDt.Append("0") 'se cierra la expresión con un más por lo que le agrego un 0 para que no acumule y no de error la expresion

      Dim dt = sql.GetHojaNovedades(idUsuario, verDetalleActividades, revisionAdministrativa,
                                    fechaDesde, fechaHasta, dias, idCliente, idProyecto,
                                    idTipoCategoriaNovedad, idCategoriaNovedad, agrupadoPorCategoria,
                                    idNovedad, idAplicacion, nroVersion, idFuncion,
                                    totalizadoPor, expDt.ToString())
      Return dt
   End Function

   Public Sub ActualizacionGenerarVersion(dt As DataTable, valores As Entidades.CRMNovedad.CambioMasivo, idAplicacion As String, listScript As List(Of Entidades.VersionScript))
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim dicClientesParaActualizar = ActualizacionMasiva(dt, valores)

         Dim usuario = New Entidades.Usuario() With {.Usuario = actual.Nombre}
         Dim usuarioAsignado = New Entidades.Usuario() With {.Usuario = Reglas.Publicos.SimovilSoporteUsuarioDefault}
         For Each clienteParaActualizar In dicClientesParaActualizar
            Dim tkPA = New Entidades.CRMNovedad()
            tkPA.TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar("TICKETS")
            tkPA.Letra = "X"
            tkPA.CentroEmisor = 1
            tkPA.IdNovedad = 0

            tkPA.IdCliente = clienteParaActualizar.Key.Item1

            tkPA.FechaNovedad = valores.VersionFecha.Value
            tkPA.Descripcion = String.Format("Nueva versión {0}", valores.Version.Valor)
            tkPA.PrioridadNovedad = Cache.CRMCacheHandler.Instancia.Prioridades.BuscarDefault(tkPA.IdTipoNovedad)
            tkPA.CategoriaNovedad = Cache.CRMCacheHandler.Instancia.Categorias.Buscar(431)
            tkPA.MedioComunicacionNovedad = Cache.CRMCacheHandler.Instancia.Medios.BuscarDefault(tkPA.IdTipoNovedad)
            tkPA.MetodoResolucionNovedad = Cache.CRMCacheHandler.Instancia.Metodos.BuscarDefault(tkPA.IdTipoNovedad)
            tkPA.EstadoNovedad = Cache.CRMCacheHandler.Instancia.Estados.Buscar(437)
            tkPA.FechaAlta = Now
            tkPA.UsuarioAlta = usuario
            tkPA.UsuarioAsignado = usuarioAsignado
            tkPA.IdProyecto = clienteParaActualizar.Key.Item2
            tkPA.IdFuncion = "AAS.Actualizacion"
            tkPA.IdSistema = valores.Aplicacion.IdZonaGeografica

            tkPA.Version = valores.Version.Valor
            tkPA.VersionFecha = valores.VersionFecha.Value

            For Each pe In clienteParaActualizar.Value
               tkPA.Seguimientos.Add(New Entidades.CRMNovedadSeguimiento(novedad:=Nothing,
                                                                         fechaSeguimiento:=Nothing,
                                                                         comentario:=String.Format("{0}{1}-{3}: {4}",
                                                                                                   pe.IdTipoNovedad.Substring(0, 2),
                                                                                                   pe.Letra,
                                                                                                   pe.CentroEmisor,
                                                                                                   pe.IdNovedad,
                                                                                                   pe.Descripcion).Truncar(2000),
                                                                         interlocutor:=String.Empty,
                                                                         esComentario:=True,
                                                                         idTipoComentarioNovedad:=101,
                                                                         estadoNovedad:=pe.EstadoNovedad,
                                                                         adjunto:=Nothing))
            Next
            Inserta(tkPA)
            '   Public Property Seguimientos As List(Of CRMNovedadSeguimiento)
         Next

         dicClientesParaActualizar.Clear()

         'Insertar el registro en Version
         If Not valores.Version.EsNull Then
            Dim rVersion As Reglas.Versiones = New Versiones(da)
            If Not rVersion.ExisteVersion(idAplicacion, valores.Version.Valor) Then
               Using dtUltima As DataTable = rVersion.GetUltimaPorAplicacion(idAplicacion)
                  Dim vFwk As String = String.Empty
                  Dim vRP As String = String.Empty
                  Dim vLng As String = String.Empty
                  If dtUltima.Rows.Count > 0 Then
                     vFwk = dtUltima.Rows(0)("VersionFramework").ToString()
                     vRP = dtUltima.Rows(0)("VersionReportViewer").ToString()
                     vLng = dtUltima.Rows(0)("VersionLenguaje").ToString()
                  End If
                  rVersion._Insertar(New Entidades.Version() _
                                       With {.IdAplicacion = idAplicacion,
                                             .NroVersion = valores.Version.Valor,
                                             .VersionFecha = valores.VersionFecha.Value,
                                             .IdAplicacionBase = Nothing,
                                             .NroVersionAplicacionBase = Nothing,
                                             .VersionFramework = vFwk,
                                             .VersionReportViewer = vRP,
                                             .VersionLenguaje = vLng})
               End Using

               If Not listScript Is Nothing Then
                  Dim oReg As Reglas.VersionesScripts = New Reglas.VersionesScripts(da)
                  For Each ent As Entidades.VersionScript In listScript
                     oReg.Inserta(ent)
                  Next
               End If
            End If
         End If

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function ActualizacionMasiva(dt As DataTable, valores As Entidades.CRMNovedad.CambioMasivo) As Dictionary(Of Tuple(Of Long, Integer), List(Of Entidades.CRMNovedad))
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Dim dicClientesParaActualizar = New Dictionary(Of Tuple(Of Long, Integer), List(Of Entidades.CRMNovedad))()
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()


         Dim novedad As Entidades.CRMNovedad
         For Each dr As DataRow In dt.Select("selec")
            novedad = GetUno(dr(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()).ToString(),
                             dr(Entidades.CRMNovedad.Columnas.Letra.ToString()).ToString(),
                             Short.Parse(dr(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).ToString()),
                             Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).ToString()))
            If valores.Prioridad IsNot Nothing Then
               novedad.PrioridadNovedad = valores.Prioridad
            End If

            If valores.PrioridadDelta <> 0 Then
               Dim nuevaPosicion As Integer = novedad.PrioridadNovedad.Posicion
               nuevaPosicion += valores.PrioridadDelta
               Dim nuevaPrioridad As Entidades.CRMPrioridadNovedad
               If valores.PrioridadDelta < 0 Then
                  nuevaPrioridad = Cache.CRMCacheHandler.Instancia.Prioridades.GetTodos(novedad.IdTipoNovedad).FirstOrDefault(Function(x) x.Posicion >= nuevaPosicion)
               Else
                  nuevaPrioridad = Cache.CRMCacheHandler.Instancia.Prioridades.GetTodos(novedad.IdTipoNovedad).LastOrDefault(Function(x) x.Posicion <= nuevaPosicion)
               End If
               If nuevaPrioridad IsNot Nothing Then
                  novedad.PrioridadNovedad = nuevaPrioridad
               End If
            End If

            If valores.Priorizado.HasValue Then
               novedad.Priorizado = valores.Priorizado.Value
            End If
            If valores.RequiereTesteo.HasValue Then
               novedad.RequiereTesteo = valores.RequiereTesteo.Value
            End If
            If valores.UsuarioAsignado IsNot Nothing Then
               novedad.UsuarioAsignado = valores.UsuarioAsignado
            End If
            If valores.GrabaResponsableEnAsignado Then
               If novedad.UsuarioResponsable IsNot Nothing Then
                  novedad.UsuarioAsignado = novedad.UsuarioResponsable
               End If
            End If
            If valores.EstadoNovedad IsNot Nothing Then
               novedad.EstadoNovedad = valores.EstadoNovedad
            End If
            If valores.Avance.HasValue Then
               novedad.Avance = valores.Avance.Value
            End If
            If valores.VersionFecha.HasValue Then
               novedad.VersionFecha = valores.VersionFecha.Value
            End If
            If Not valores.Version.EsNull Then
               novedad.Version = valores.Version.Valor
            End If
            If valores.FechaProximoContacto.HasValue Then
               If valores.FechaProximoContacto.Value.Equals(Date.MinValue) Then
                  novedad.FechaProximoContacto = Nothing
               Else
                  novedad.FechaProximoContacto = valores.FechaProximoContacto.Value
               End If
            End If
            If valores.MedioNovedad IsNot Nothing Then
               novedad.MedioComunicacionNovedad = valores.MedioNovedad
            End If
            If valores.MetodoNovedad IsNot Nothing Then
               novedad.MetodoResolucionNovedad = valores.MetodoNovedad
            End If
            If valores.BanderaColor.HasValue Then
               If valores.BanderaColor.Equals(Drawing.SystemColors.Control) Then
                  novedad.BanderaColor = Nothing
               Else
                  novedad.BanderaColor = valores.BanderaColor.Value
               End If
            End If
            If valores.Categoria IsNot Nothing Then
               novedad.CategoriaNovedad = valores.Categoria
            End If
            If valores.Aplicacion IsNot Nothing Then
               novedad.IdSistema = valores.Aplicacion().IdZonaGeografica
            End If
            If Not String.IsNullOrWhiteSpace(valores.IdFuncion) Then
               novedad.IdFuncion = valores.IdFuncion
            End If
            If valores.IdCliente > 0 Then
               novedad.IdCliente = valores.IdCliente
            End If
            If valores.IdProyecto > 0 Then
               novedad.IdProyecto = valores.IdProyecto
            End If

            If Not String.IsNullOrWhiteSpace(valores.EtiquetaNovedad) Then
               If valores.AccionEtiquetaNovedad = Entidades.CRMNovedad.AccionEtiquetaNovedad.AGREGAR Then
                  novedad.EtiquetaNovedad = String.Format("{0} {1}", novedad.EtiquetaNovedad, valores.EtiquetaNovedad).Trim()
               ElseIf valores.AccionEtiquetaNovedad = Entidades.CRMNovedad.AccionEtiquetaNovedad.QUITAR Then
                  novedad.EtiquetaNovedad = novedad.EtiquetaNovedad.Replace(valores.EtiquetaNovedad, String.Empty).Trim()
               ElseIf valores.AccionEtiquetaNovedad = Entidades.CRMNovedad.AccionEtiquetaNovedad.CAMBIAR Then
                  novedad.EtiquetaNovedad = valores.EtiquetaNovedad.Trim()
               End If
            End If

            If Not String.IsNullOrWhiteSpace(valores.NuevoComentario) Then
               novedad.NuevoComentario = valores.NuevoComentario
               novedad.NuevoAdjunto = valores.NuevoAdjunto
               novedad.NuevoIdTipoComentarioNovedad = valores.NuevoIdTipoComentarioNovedad
               novedad.ComentarioPrincipal = valores.ComentarioPrincipal
            End If

            novedad.FechaEstadoNovedad = Nothing

            Actualiza(novedad)

            If Not String.IsNullOrWhiteSpace(novedad.IdTipoNovedadPadre) AndAlso valores.EstadosPadres.ContainsKey(novedad.IdTipoNovedadPadre) Then
               Dim estadoPadre = Cache.CRMCacheHandler.Instancia.Estados.Buscar(valores.EstadosPadres(novedad.IdTipoNovedadPadre))
               If estadoPadre IsNot Nothing Then
                  Dim padre = GetUno(novedad.IdTipoNovedadPadre, novedad.LetraPadre, novedad.CentroEmisorPadre, novedad.IdNovedadPadre)
                  Dim dtRelacionadas = GetNovedadesRelacionadas(padre)
                  If dtRelacionadas.Select(String.Format("{0} = '{1}' AND {2} = {3} AND {4} <> {5}",
                                                         "Parentesco", "Hijo",
                                                         "Finalizado", "False",
                                                         "IdMetodoResolucionNovedad", "252")).Length = 0 Then
                     padre.EstadoNovedad = estadoPadre
                     padre.Avance = 100
                     padre.Version = novedad.Version
                     padre.VersionFecha = novedad.VersionFecha
                     Actualiza(padre)
                  End If
               End If
            End If

            Dim key = New Tuple(Of Long, Integer)(novedad.IdCliente, novedad.IdProyecto)
            If Not dicClientesParaActualizar.ContainsKey(key) Then
               dicClientesParaActualizar.Add(key, New List(Of Entidades.CRMNovedad)())
            End If
            dicClientesParaActualizar(key).Add(novedad)

         Next

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return dicClientesParaActualizar
   End Function

   Public Function GetNovedadesParaWeb() As DataTable
      Return GetSqlServer().GetNovedadesParaWeb(Today.AddYears(-1), Today.AddMonths(-6))
   End Function

   Public Function GetCantidadNovedadesPorProyecto(idProyecto As Integer, finalizado As Boolean) As DataTable
      Return New SqlServer.CRMNovedades(da).GetCantidadNovedadesPorProyecto(idProyecto, finalizado)
   End Function

   Public Function ConvertirNovedadEnVenta(nov As Entidades.CRMNovedad, _cache As BusquedasCacheadas) As Entidades.Venta

      With nov
         Dim categoriaFiscalEmpresa = _cache.BuscaCategoriaFiscal(Publicos.CategoriaFiscalEmpresa)

         '# Valido que el servicio no haya sido facturado previamente
         If .IdSucursalFact.HasValue AndAlso .IdSucursalFact.Value > 0 Then '# Asumo que si tiene la sucursal, está facturado
            Throw New Exception(String.Format("ATENCIÓN: Este servicio ya fué facturado con el comprobante {0} {1} {2:0000}-{3:00000000}",
                                           .IdTipoComprobanteFact,
                                           .LetraFact,
                                           .CentroEmisorFact,
                                           .NumeroComprobanteFact))
         End If

         '# Valido que estén correctamente configuradas las impresoras
         Dim tiposComprobante = New Reglas.TiposComprobantes(da).GetHabilitados(actual.Sucursal.Id,
                                                              My.Computer.Name,
                                                              "VENTAS",
                                                              Tipo2:="",
                                                              AfectaCaja:="",
                                                              UsaFacturacionRapida:="",
                                                              UsaFacturacion:=True,
                                                              IgnoraSucursal:=False,
                                                              esRecibo:=Nothing,
                                                              coeficionesStock:=Nothing,
                                                              grabaLibro:=Nothing,
                                                              esReciboClienteVinculado:=Nothing, coeficienteValor:=Nothing, importeComprobante:=Nothing,
                                                              esElectronico:=Nothing, clase:=String.Empty)
         If tiposComprobante.Count = 0 Then
            Throw New Exception("No Existe la PC en Configuraciones/Impresoras")
         End If

         '# Creo la venta con la que voy a facturar el servicio
         Dim rVentas = New Reglas.Ventas()
         Dim rClientes = New Reglas.Clientes()

         '# Valido que esté configurado un producto por defecto en los parámetros
         If String.IsNullOrEmpty(Reglas.Publicos.CRMNovedadesProductoFacturable) Then
            Throw New Exception("ATENCIÓN: Debe configurar un producto facturable en Parámetros > Service para poder continuar.")
         End If

         Dim eCliente = rClientes.GetUno(.IdCliente)
         Dim descRecPorcGeneral As Decimal = 0
         Dim observacion As String = Reglas.Publicos.CRMNovedadesObservacionFacturable '# Observación GENERAL (al pie de página)
         Dim idCaja As Integer = 0
         Dim listaPrecios = _cache.BuscaListaDePrecios(eCliente.IdListaPrecios)
         Dim fPago = _cache.BuscaFormasPago(Publicos.CRMNovedadesFormaDePago)
         Dim eVenta = rVentas.CreaVenta(actual.Sucursal.Id,
                                        tiposComprobante(0), letra:=String.Empty, centroEmisor:=0, numeroComprobante:=Nothing,
                                        cliente:=eCliente,
                                        categoriaFiscal:=Nothing,
                                        fecha:=Now,
                                        vendedor:=Nothing,
                                        transportista:=Nothing,
                                        formaPago:=fPago,
                                        descuentoRecargoPorc:=descRecPorcGeneral,
                                        idCaja:=idCaja,
                                        cotizacionDolar:=Nothing,
                                        mercDespachada:=Nothing,
                                        numeroReparto:=Nothing,
                                        fechaEnvio:=Nothing,
                                        proveedor:=Nothing,
                                        observaciones:=observacion,
                                        cobrador:=Nothing,
                                        clienteVinculado:=Nothing,
                                        nroOrdenCompra:=0)

         If nov.ProductosNovedad.Count = 0 Or Eniac.Reglas.Publicos.RMAProductosConsumidosNoFactura Then
            Dim eProductoPorDefecto = _cache.BuscaProductoEntidadPorId(Reglas.Publicos.CRMNovedadesProductoFacturable)
            '# Valido que el producto exista
            If eProductoPorDefecto Is Nothing Then
               Throw New Exception("ATENCIÓN: El producto facturable configurado en Parámetros no existe.")
            End If
            Dim tipoImpuesto = _cache.BuscaTiposImpuestos(eProductoPorDefecto.IdTipoImpuesto)


            Dim precio = .CostoReparacion

            If Eniac.Reglas.Publicos.CRMImporteConIVA Then
               ' precio = Decimal.Round((.CostoReparacion) / (1 + eProductoPorDefecto.Alicuota / 100), 2)
               precio = (.CostoReparacion) / (1 + eProductoPorDefecto.Alicuota / 100)

            End If

            'If (Not eCliente.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado) Then
            '   precio = Decimal.Round((precio) / (1 + eProductoPorDefecto.Alicuota / 100), 2)
            'End If


            '# Agrego el producto por defecto para la facturación del servicio
            Dim vp = rVentas.AgregarVentaProducto(eVenta,
                                                     rVentas.CreaVentaProducto(eProductoPorDefecto,
                                                                               eProductoPorDefecto.NombreProducto,
                                                                               descRecPorcGeneral,
                                                                               descRecPorcGeneral,
                                                                               precio,
                                                                               1,
                                                                               tipoImpuesto,
                                                                               eProductoPorDefecto.Alicuota,
                                                                               listaPrecios,
                                                                               Nothing,
                                                                               Entidades.Producto.TiposOperaciones.NORMAL,
                                                                               String.Empty,
                                                                               Nothing,
                                                                               eVenta, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio), Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
            vp.PrecioServicioTecnicoSinIVA = vp.Precio
            vp.PrecioServicioTecnicoConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.Producto)

         Else
            For Each prod In nov.ProductosNovedad
               Dim eProductoPorDefecto = _cache.BuscaProductoEntidadPorId(prod.IdProducto)
               Dim tipoImpuesto = _cache.BuscaTiposImpuestos(eProductoPorDefecto.IdTipoImpuesto)
               Dim precio As Decimal = prod.PrecioProducto

               If (categoriaFiscalEmpresa.IvaDiscriminado AndAlso eVenta.CategoriaFiscal.IvaDiscriminado) Or Publicos.PreciosConIVA Then
                  precio = CalculosImpositivos.ObtenerPrecioSinImpuestos(prod.PrecioProducto, eProductoPorDefecto)
               End If

               If Eniac.Reglas.Publicos.CRMImporteConIVA Then
                  precio = (prod.PrecioProducto) / (1 + eProductoPorDefecto.Alicuota / 100)
               End If

               '# Agrego el producto por defecto para la facturación del servicio
               Dim vp = rVentas.AgregarVentaProducto(eVenta,
                                                     rVentas.CreaVentaProducto(eProductoPorDefecto,
                                                                               eProductoPorDefecto.NombreProducto,
                                                                               descRecPorcGeneral,
                                                                               descRecPorcGeneral,
                                                                               precio,
                                                                               prod.CantidadProducto,
                                                                               tipoImpuesto,
                                                                               eProductoPorDefecto.Alicuota,
                                                                               listaPrecios,
                                                                               Nothing,
                                                                               Entidades.Producto.TiposOperaciones.NORMAL,
                                                                               String.Empty,
                                                                               Nothing,
                                                                               eVenta, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio), Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)

               vp.PrecioServicioTecnicoSinIVA = vp.Precio
               vp.PrecioServicioTecnicoConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.Producto)



               Dim lote As Entidades.VentaProductoLote
               Dim NroSerie As Entidades.VentaProductoNroSerie
               If Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraLoteObservacion(actual.Sucursal) Then
                  For Each lt As Entidades.CRMNovedadProductoLote In prod.ProductosNovedadLote

                     lote = New Entidades.VentaProductoLote()
                     lote.TipoComprobante = eVenta.TipoComprobante.ToString()
                     lote.Letra = eVenta.LetraComprobante
                     lote.CentroEmisor = eVenta.CentroEmisor
                     lote.NumeroComprobante = eVenta.NumeroComprobante
                     lote.Orden = lt.OrdenProducto
                     lote.Producto = New Reglas.Productos().GetUno(lt.IdProducto)
                     lote.Cantidad = lt.CantidadActual
                     lote.IdLote = lt.IdLote
                     lote.FechaVencimiento = lt.FechaVencimiento
                     lote.IdDeposito = lt.IdDeposito
                     lote.IdUbicacion = lt.IdUbicacion
                     vp.VentasProductosLotes.Add(lote)
                  Next
               End If


               For Each ns As Entidades.CRMNovedadProductoNrosSerie In prod.ProductosNovedadNrosSerie
                  NroSerie = New Entidades.VentaProductoNroSerie()
                  NroSerie.IdTipoComprobante = eVenta.TipoComprobante.IdTipoComprobante
                  NroSerie.Letra = eVenta.LetraComprobante
                  NroSerie.CentroEmisor = eVenta.CentroEmisor
                  NroSerie.NumeroComprobante = eVenta.NumeroComprobante
                  NroSerie.Orden = ns.OrdenProducto
                  NroSerie.IdProducto = New Reglas.Productos().GetUno(ns.IdProducto).IdProducto
                  NroSerie.NroSerie = ns.NroSerie
                  vp.VentasProductosNrosSerie.Add(NroSerie)
               Next

            Next
         End If

         '# Observaciones detalladas especiales
         Dim obsEspeciales = New List(Of String)()
         '----------------------------------------
         obsEspeciales.Add(String.Format("Número de Servicio Técnico: {0}", nov.IdNovedad))
         obsEspeciales.Add(String.Format("Producto Reparado: {0} {1}", nov.NombreProducto, If(Not String.IsNullOrEmpty(nov.NroDeSerie), String.Format("- Nro. Serie: {0}", nov.NroDeSerie), Nothing)))
         '----------------------------------------
         For Each especial In obsEspeciales
            rVentas.AgregarVentaObservacion(eVenta, especial)
         Next

         '# Por cada comentario de tipo "Visible para el cliente", lo agrego como observación detallada
         For Each s In nov.Seguimientos
            If s.IdTipoComentarioNovedad.HasValue AndAlso Cache.CRMCacheHandler.Instancia.TiposComentarios.Buscar(s.IdTipoComentarioNovedad.Value).VisibleParaCliente Then
               rVentas.AgregarVentaObservacion(eVenta, String.Format("{0}", s.Comentario))
            End If
         Next

         '# Agrego la novedad a CrmInvocados 
         eVenta.CrmInvocados.Add(nov)

         'Lo convierto con número 0 porque no necesito que tenga numero
         eVenta.NumeroComprobante = 0

         Return eVenta
      End With

   End Function

   '-- REG-31710 ---------------------------------------------------------------
   Public Sub ActualizaAnticipos(IdTipoNovedad As String,
                                 LetraNovedad As String,
                                 CentroEmisorNovedad As Short,
                                 NumeroNovedad As Long,
                                 ImporteRecibo As Double)
      '# Actualizo el registro con el comprobante de venta facturado
      Dim sCRMNovedad As SqlServer.CRMNovedades = New SqlServer.CRMNovedades(da)
      sCRMNovedad.ActualizarAnticipos(IdTipoNovedad,
                                         LetraNovedad,
                                         CentroEmisorNovedad,
                                         NumeroNovedad,
                                         ImporteRecibo)
   End Sub

   Public Sub ActualizarDatosVentaCRM(eVenta As Entidades.Venta, esAnulacion As Boolean)

      '# Actualizo el registro con el comprobante de venta facturado
      Dim sCRMNovedad = New SqlServer.CRMNovedades(da)
      Dim rAuditoria = New Auditorias(da)

      For Each n In eVenta.CrmInvocados
         Dim novedad = GetUno(n.IdTipoNovedad, n.Letra, n.CentroEmisor, n.IdNovedad)

         If esAnulacion Then
            If novedad.IdEstadoNovedadAnterior.HasValue Then
               Dim nuevoEstadoCRM = Cache.CRMCacheHandler.Instancia.Estados.Buscar(novedad.IdEstadoNovedadAnterior.Value)
               novedad.EstadoNovedad = nuevoEstadoCRM
               novedad.Avance = novedad.AvanceAnterior.IfNull()
            End If
            novedad.IdEstadoNovedadAnterior = Nothing
            novedad.AvanceAnterior = Nothing

         Else
            If n.EstadoNovedad.IdEstadoFacturado.HasValue Then
               Dim nuevoEstadoCRM = Cache.CRMCacheHandler.Instancia.Estados.Buscar(n.EstadoNovedad.IdEstadoFacturado.Value)
               novedad.IdEstadoNovedadAnterior = novedad.IdEstadoNovedad
               novedad.AvanceAnterior = novedad.Avance
               novedad.EstadoNovedad = nuevoEstadoCRM
               If nuevoEstadoCRM.AvanceEstadoFacturado.HasValue Then
                  novedad.Avance = nuevoEstadoCRM.AvanceEstadoFacturado.Value
               End If
            End If

         End If

         Actualiza(novedad)

         '-- PE-31136 -------------------------------------------------------------------------------
         sCRMNovedad.ActualizarDatosVentaCRM(n.IdTipoNovedad, n.Letra, n.CentroEmisor, n.IdNovedad,
                                             If(Not esAnulacion, eVenta.IdSucursal, Nothing),
                                             If(Not esAnulacion, eVenta.IdTipoComprobante, Nothing),
                                             If(Not esAnulacion, eVenta.LetraComprobante, Nothing),
                                             If(Not esAnulacion, eVenta.CentroEmisor, Nothing),
                                             If(Not esAnulacion, eVenta.NumeroComprobante, Nothing))

         '# Auditoria
         rAuditoria.Insertar("CRMNovedades", Entidades.OperacionesAuditorias.Modificacion, actual.Nombre,
                             String.Format("IdTipoNovedad = '{0}' AND Letra = '{1}' AND CentroEmisor = {2} AND IdNovedad = {3}",
                                           n.IdTipoNovedad,
                                           n.Letra,
                                           n.CentroEmisor,
                                           n.IdNovedad), True)
      Next

   End Sub

   Public Function ObtenerServiciosFacturados(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Short,
                                              numeroComprobante As Long) As List(Of Entidades.CRMNovedad)

      Return Me.CargaLista(New SqlServer.CRMNovedades(da).ObtenerServiciosFacturados(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMNovedad)
   End Function

   Public Function GetAuditoriaCRMNovedades(fechaDesde As Date?,
                                            fechaHasta As Date?,
                                            idTipoNovedad As String,
                                            idNovedad As Long,
                                            tipoOperacion As String) As DataTable
      Return New SqlServer.CRMNovedades(da).GetAuditoriaCRMNovedades(fechaDesde, fechaHasta, idTipoNovedad, idNovedad, tipoOperacion)
   End Function

   Public Function GetInfOrdenesReparacion(idSucursal As Integer,
                                           desdeFechaNovedad As Date?, hastaFechaNovedad As Date?, nullFechaNovedad As Boolean,
                                           desdeFechaHoraEnvioGarantia As Date?, hastaFechaHoraEnvioGarantia As Date?, nullFechaHoraEnvioGarantia As Boolean,
                                           desdeFechaHoraRetiroGarantia As Date?, hastaFechaHoraRetiroGarantia As Date?, nullFechaHoraRetiroGarantia As Boolean,
                                           desdeFechaHoraRetiro As Date?, hastaFechaHoraRetiro As Date?, nullFechaHoraRetiro As Boolean,
                                           desdeFechaHoraEntrega As Date?, hastaFechaHoraEntrega As Date?, nullFechaHoraEntrega As Boolean, 'fechaDesde As Date?, fechaHasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                           idProducto As String, idEstadoNovedad As Integer, idProveedorService As Integer,
                                           idTipoComentario As Integer, visibleClientes As Entidades.Publicos.SiNoTodos, visibleRepresentantes As Entidades.Publicos.SiNoTodos,
                                           cantidadLineasVacias As Integer) As DataSet
      Dim sql = New SqlServer.CRMNovedades(da)
      Dim dtCabecera = sql.GetInfCRMServiceCabecera(idSucursal,
                                                    desdeFechaNovedad, hastaFechaNovedad, nullFechaNovedad,
                                                    desdeFechaHoraEnvioGarantia, hastaFechaHoraEnvioGarantia, nullFechaHoraEnvioGarantia,
                                                    desdeFechaHoraRetiroGarantia, hastaFechaHoraRetiroGarantia, nullFechaHoraRetiroGarantia,
                                                    desdeFechaHoraRetiro, hastaFechaHoraRetiro, nullFechaHoraRetiro,
                                                    desdeFechaHoraEntrega, hastaFechaHoraEntrega, nullFechaHoraEntrega, 'fechaDesde As Date?, fechaHasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                                    idProducto, idEstadoNovedad, idProveedorService, idCliente:=0)
      Dim dtDetalle = sql.GetInfCRMServiceDetalle(idSucursal, desdeFechaNovedad, hastaFechaNovedad, nullFechaNovedad,
                                                  desdeFechaHoraEnvioGarantia, hastaFechaHoraEnvioGarantia, nullFechaHoraEnvioGarantia,
                                                  desdeFechaHoraRetiroGarantia, hastaFechaHoraRetiroGarantia, nullFechaHoraRetiroGarantia,
                                                  desdeFechaHoraRetiro, hastaFechaHoraRetiro, nullFechaHoraRetiro,
                                                  desdeFechaHoraEntrega, hastaFechaHoraEntrega, nullFechaHoraEntrega, 'fechaDesde As Date?, fechaHasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                                  idProducto, idEstadoNovedad,
                                                  idTipoComentario, visibleClientes, visibleRepresentantes)

      Dim ds = New DataSet()
      ds.Tables.Add("Cabecera", dtCabecera)
      ds.Tables.Add("Detalle", dtDetalle)

      dtCabecera.AsEnumerable().ToList().ForEach(
         Sub(drC)
            For i = 1 To cantidadLineasVacias
               Dim drD = dtDetalle.NewRow()
               drD("IdTipoNovedad") = drC("IdTipoNovedad")
               drD("Letra") = drC("Letra")
               drD("CentroEmisor") = drC("CentroEmisor")
               drD("IdNovedad") = drC("IdNovedad")
               drD("Comentario") = String.Empty
               dtDetalle.Rows.Add(drD)
            Next
         End Sub)

      'Agregar Relación entre tablas en el DataSet, ejemplo en consulta pedidos
      Dim columnasPadre = {ds.Tables("Cabecera").Columns("IdTipoNovedad"),
                           ds.Tables("Cabecera").Columns("Letra"),
                           ds.Tables("Cabecera").Columns("CentroEmisor"),
                           ds.Tables("Cabecera").Columns("IdNovedad")}
      Dim columnasHijo = {ds.Tables("Detalle").Columns("IdTipoNovedad"),
                          ds.Tables("Detalle").Columns("Letra"),
                          ds.Tables("Detalle").Columns("CentroEmisor"),
                          ds.Tables("Detalle").Columns("IdNovedad")}

      Dim relation = New DataRelation("Detalle", columnasPadre, columnasHijo, True)
      ds.Relations.Add(relation)

      Return ds
   End Function

   '-.PE-31872 .-
   Public Function GetInfCRMService(idSucursal As Integer,
                                    desdeFechaNovedad As Date?, hastaFechaNovedad As Date?, nullFechaNovedad As Boolean,
                                    desdeFechaHoraEnvioGarantia As Date?, hastaFechaHoraEnvioGarantia As Date?, nullFechaHoraEnvioGarantia As Boolean,
                                    desdeFechaHoraRetiroGarantia As Date?, hastaFechaHoraRetiroGarantia As Date?, nullFechaHoraRetiroGarantia As Boolean,
                                    desdeFechaHoraRetiro As Date?, hastaFechaHoraRetiro As Date?, nullFechaHoraRetiro As Boolean,
                                    desdeFechaHoraEntrega As Date?, hastaFechaHoraEntrega As Date?, nullFechaHoraEntrega As Boolean, 'fechaDesde As Date?, fechaHasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                    idProducto As String,
                                    idEstadoNovedad As Integer,
                                    idProveedorService As Long,
                                    idCliente As Long) As DataTable

      Dim sql = New SqlServer.CRMNovedades(da)

      Return sql.GetInfCRMServiceCabecera(idSucursal,
                                          desdeFechaNovedad, hastaFechaNovedad, nullFechaNovedad,
                                          desdeFechaHoraEnvioGarantia, hastaFechaHoraEnvioGarantia, nullFechaHoraEnvioGarantia,
                                          desdeFechaHoraRetiroGarantia, hastaFechaHoraRetiroGarantia, nullFechaHoraRetiroGarantia,
                                          desdeFechaHoraRetiro, hastaFechaHoraRetiro, nullFechaHoraRetiro,
                                          desdeFechaHoraEntrega, hastaFechaHoraEntrega, nullFechaHoraEntrega,
                                          idProducto, idEstadoNovedad, idProveedorService, idCliente)

   End Function

#End Region

End Class