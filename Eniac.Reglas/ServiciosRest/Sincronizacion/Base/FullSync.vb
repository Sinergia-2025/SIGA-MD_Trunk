#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
Imports Eniac.Entidades.Filtros
Imports Sync = Eniac.Reglas.ServiciosRest.Sincronizacion
#End Region
Namespace ServiciosRest.Sincronizacion
   Public Class FullSync

      'Public Sub Sincronizar(esReenvio As Boolean, esRecibirTotdo As Boolean)

      '   Using syncs = New Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection()

      '      AddHandler syncs.NotificarEstadoInformation, Sub(sender1, e1) MostrarEstadoInformation(String.Format("{0} - {1}", e1.Tipo.Name, e1.Estado))
      '      AddHandler syncs.NotificarEstadoVerbose, Sub(sender1, e1) MostrarEstadoVerbose(String.Format("{0} - {1}", e1.Tipo.Name, e1.Estado))
      '      AddHandler syncs.LuegoObtenerCantidadRegistros, Sub(sender1, e1) AddResumen(e1.Tipo, Estado.Cantidad, e1.CantidadRegistros, Nothing, Nothing, Nothing)
      '      AddHandler syncs.RecibiendoDatos, Sub(sender1, e1) AddResumen(e1.Tipo, Estado.Recibiendo, Nothing, e1.RegistrosRecibidos, e1.PaginaActual, Nothing)
      '      AddHandler syncs.RecibiendoDatosFinalizado, Sub(sender1, e1) AddResumen(e1.Tipo, Estado.Recibido, Nothing, e1.RegistrosRecibidos, e1.PaginaActual, Nothing)
      '      AddHandler syncs.DespuesRecibiendoDatos, Sub(sender1, e1) AddResumen(e1.Tipo, Estado.Recibido, Nothing, Nothing, Nothing, e1.TotalPaginas)

      '      syncs.Add(New Sync.SyncLocalidades().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.SyncRubrosCompras().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.SyncMarcas().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.SyncRubros().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.SyncSubRubros().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.SyncSubSubRubros().InicializaDatos(esReenvio, esRecibirTotdo))

      '      syncs.Add(New Sync.SyncClientes().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.SyncProveedores().InicializaDatos(esReenvio, esRecibirTotdo))

      '      syncs.Add(New Sync.SyncProductos().InicializaDatos(esReenvio, esRecibirTotdo, New ProductosPublicarEnFiltros() With {.SincronizacionSucursal = Entidades.Publicos.SiNoTodos.SI}))
      '      syncs.Add(New Sync.SyncProductosSucursales().InicializaDatos(esReenvio, esRecibirTotdo, New ProductosPublicarEnFiltros() With {.SincronizacionSucursal = Entidades.Publicos.SiNoTodos.SI}))
      '      syncs.Add(New Sync.SyncProductosSucursalesPrecios().InicializaDatos(esReenvio, esRecibirTotdo, New ProductosPublicarEnFiltros() With {.SincronizacionSucursal = Entidades.Publicos.SiNoTodos.SI}))

      '      syncs.Add(New Sync.CRM.SyncCRMCategoriasNovedades().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.CRM.SyncCRMEstadosNovedades().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.CRM.SyncCRMMediosComunicacionesNovedades().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.CRM.SyncCRMMetodosResolucionesNovedades().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.CRM.SyncCRMPrioridadesNovedades().InicializaDatos(esReenvio, esRecibirTotdo))
      '      syncs.Add(New Sync.CRM.SyncCRMTiposComentariosNovedades().InicializaDatos(esReenvio, esRecibirTotdo))

      '      syncs.Add(New Sync.CRM.SyncCRMNovedades().InicializaDatos(esReenvio, esRecibirTotdo))

      '      syncs.ImportarAutomaticamente(syncs)
      '      syncs.EnviarAutomaticamente(grabaArchivoLocal:=True)


      '      'syncs.DescargarDatos()
      '      'syncs.ValidarDatos()
      '      'syncs.ImportarDatos()

      '      'syncs.CargarDatos()
      '      'syncs.EnviarDatos(grabaArchivoLocal:=True)
      '   End Using


      'End Sub

   End Class
End Namespace