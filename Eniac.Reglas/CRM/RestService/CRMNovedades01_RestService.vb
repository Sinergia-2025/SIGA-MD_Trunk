Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Partial Class CRMNovedades
   Private Const ModuloEvento As String = "CRMNovedad"

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon)(dato.Datos))
   End Function

   Public Overloads Overrides Function ImportarDatos(col As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql = New SqlServer.CRMNovedades(da)
         Dim eventArgs = New Clientes.AvanceProcesarDatosEventArgs(ModuloEvento)

         eventArgs.TotalRegistros = col.Count
         Dim maximoFechaActualizacion As Date? = Nothing
         For Each en In col
            eventArgs.RegistroActual += 1
            eventArgs.Datos = en
            OnAvanceImportarDatos(eventArgs)
            If en.___Estado = "A" Then
               sql.CRMNovedades_I(en.FechaActualizacionWeb.ToDateTime(),
                                  en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad,
                                  en.FechaNovedad.ToDateTime().IfNull(),
                                  en.Descripcion,
                                  en.IdPrioridadNovedad,
                                  en.IdCategoriaNovedad,
                                  en.IdEstadoNovedad,
                                  en.FechaEstadoNovedad.ToDateTime().IfNull(Today),
                                  en.IdUsuarioEstadoNovedad,
                                  en.FechaAlta.ToDateTime().IfNull(Today),
                                  en.IdUsuarioAlta,
                                  en.IdUsuarioAsignado,
                                  en.Avance,
                                  en.IdMedioComunicacionNovedad.IfNull(),
                                  en.IdCliente,
                                  en.IdProspecto,
                                  en.IdFuncion,
                                  en.IdSistema,
                                  en.FechaProximoContacto.ToDateTime(),
                                  If(en.BanderaColor.HasValue, Drawing.Color.FromArgb(en.BanderaColor.Value), DirectCast(Nothing, Drawing.Color?)),
                                  en.Interlocutor,
                                  en.IdMetodoResolucionNovedad.IfNull(),
                                  en.IdProveedor,
                                  en.IdProyecto,
                                  en.RevisionAdministrativa,
                                  en.Priorizado,
                                  en.IdTipoNovedadPadre,
                                  en.LetraPadre,
                                  en.CentroEmisorPadre,
                                  en.IdNovedadPadre,
                                  en.Version,
                                  en.VersionFecha.ToDateTime(),
                                  en.FechaInicioPlan.ToDateTime(),
                                  en.FechaFinPlan.ToDateTime(),
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
                                  en.FechaEntregado.ToDateTime(),
                                  en.FechaFinalizado.ToDateTime(),
                                  en.IdEstadoNovedadEntregado,
                                  en.IdEstadoNovedadFinalizado,
                                  en.IdUsuarioEntregado,
                                  en.IdUsuarioFinalizado,
                                  en.IdEstadoNovedadAnterior,
                                  en.AvanceAnterior,
                                  en.Observacion,
                                  en.ClienteValorizacionEstrellas,
                                  en.AnticipoNovedad,
                                  en.FechaHoraRetiro.ToDateTime(),
                                  en.IdDomicilioRetiro,
                                  en.FechaHoraEntrega.ToDateTime(),
                                  en.IdDomicilioEntrega,
                                  en.IdProveedorGarantia,
                                  en.FechaHoraEnvioGarantia.ToDateTime(),
                                  en.FechaHoraRetiroGarantia.ToDateTime(),
                                  en.idMarcaProducto,
                                  en.NombreMarcaProducto,
                                  en.idModeloProducto,
                                  en.NombreModeloProducto,
                                  en.IdSucursalNovedad,
                                  en.ServiceLugarCompra, en.ServiceLugarCompraFecha.ToDateTime(), en.ServiceLugarCompraTipoComprobante, en.ServiceLugarCompraNumeroComprobante,
                                  en.IdAplicacionTerceros, en.IdMotivoNovedad.IfNull(), en.ComentarioPrincipal, en.PatenteVehiculo)
            ElseIf en.___Estado = "M" Then
               sql.CRMNovedades_U(en.FechaActualizacionWeb.ToDateTime(),
                                  en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad,
                                  en.FechaNovedad.ToDateTime().IfNull(Today),
                                  en.Descripcion,
                                  en.IdPrioridadNovedad,
                                  en.IdCategoriaNovedad,
                                  en.IdEstadoNovedad,
                                  en.FechaEstadoNovedad.ToDateTime().IfNull(Today),
                                  en.IdUsuarioEstadoNovedad,
                                  en.FechaAlta.ToDateTime().IfNull(Today),
                                  en.IdUsuarioAlta,
                                  en.IdUsuarioAsignado,
                                  en.Avance,
                                  en.IdMedioComunicacionNovedad.IfNull(),
                                  en.IdCliente,
                                  en.IdProspecto,
                                  en.IdFuncion,
                                  en.IdSistema,
                                  en.FechaProximoContacto.ToDateTime(),
                                  If(en.BanderaColor.HasValue, Drawing.Color.FromArgb(en.BanderaColor.Value), DirectCast(Nothing, Drawing.Color?)),
                                  en.Interlocutor,
                                  en.IdMetodoResolucionNovedad.IfNull(),
                                  en.IdProveedor,
                                  en.IdProyecto,
                                  en.RevisionAdministrativa,
                                  en.Priorizado,
                                  en.IdTipoNovedadPadre,
                                  en.LetraPadre,
                                  en.CentroEmisorPadre,
                                  en.IdNovedadPadre,
                                  en.Version,
                                  en.VersionFecha.ToDateTime(),
                                  en.FechaInicioPlan.ToDateTime(),
                                  en.FechaFinPlan.ToDateTime(),
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
                                  en.FechaEntregado.ToDateTime(),
                                  en.FechaFinalizado.ToDateTime(),
                                  en.IdEstadoNovedadEntregado,
                                  en.IdEstadoNovedadFinalizado,
                                  en.IdUsuarioEntregado,
                                  en.IdUsuarioFinalizado,
                                  en.IdEstadoNovedadAnterior,
                                  en.AvanceAnterior,
                                  en.Observacion,
                                  en.ClienteValorizacionEstrellas,
                                  en.AnticipoNovedad,
                                  en.FechaHoraRetiro.ToDateTime(),
                                  en.IdDomicilioRetiro,
                                  en.FechaHoraEntrega.ToDateTime(),
                                  en.IdDomicilioEntrega,
                                  en.IdProveedorGarantia,
                                  en.FechaHoraEnvioGarantia.ToDateTime(),
                                  en.FechaHoraRetiroGarantia.ToDateTime(),
                                  en.idMarcaProducto,
                                  en.NombreMarcaProducto,
                                  en.idModeloProducto,
                                  en.NombreModeloProducto,
                                  en.IdSucursalNovedad,
                                  en.ServiceLugarCompra, en.ServiceLugarCompraFecha.ToDateTime(), en.ServiceLugarCompraTipoComprobante, en.ServiceLugarCompraNumeroComprobante,
                                  en.IdAplicacionTerceros, en.IdMotivoNovedad.IfNull(), en.ComentarioPrincipal, en.PatenteVehiculo)
            End If

            en.___Estado = "I"

            If IsDate(en.FechaActualizacionWeb) Then
               Dim fecha As Date = DateTime.Parse(en.FechaActualizacionWeb)
               If Not maximoFechaActualizacion.HasValue Then
                  maximoFechaActualizacion = fecha
               End If

               If fecha > maximoFechaActualizacion Then
                  maximoFechaActualizacion = fecha
               End If
            End If
            OnAvanceImportarDatos(eventArgs)

         Next
         If maximoFechaActualizacion.HasValue Then
            Publicos.WebArchivos.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, Entidades.Parametro.Parametros.WEBARCHIVOSCRMNOVEDADESULTIMADESCARGA, da)
         End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Overloads Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon), syncs As SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs(ModuloEvento)

      Dim stbMensajeError = New StringBuilder()

      Dim regla = New CRMNovedades()

      Dim proyectosCache = New Proyectos().GetTodos()
      Dim funcionesCache = New Funciones().GetAll()

      eventArgs.TotalRegistros = col.Count
      For Each en In col
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatos(eventArgs)

         If Not Reglas.Cache.CRMCacheHandler.Instancia.Tipos.Existe(en.IdTipoNovedad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Tipo de Novedad con IdTipoNovedad = {0}.", en.IdTipoNovedad))
         End If
         If Not Reglas.Cache.CRMCacheHandler.Instancia.Prioridades.Existe(en.IdPrioridadNovedad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Prioridad de Novedad con IdPrioridadNovedad = {0}.", en.IdPrioridadNovedad))
         End If
         If Not Reglas.Cache.CRMCacheHandler.Instancia.Categorias.Existe(en.IdCategoriaNovedad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Categoria de Novedad con IdCategoriaNovedad = {0}.", en.IdCategoriaNovedad))
         End If
         If en.IdMedioComunicacionNovedad.IfNull() <> 0 AndAlso Not Reglas.Cache.CRMCacheHandler.Instancia.Medios.Existe(en.IdMedioComunicacionNovedad.Value) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Medio de Novedad con IdMedioComunicacionNovedad = {0}.", en.IdMedioComunicacionNovedad))
         End If
         If en.IdMetodoResolucionNovedad.IfNull() <> 0 AndAlso Not Reglas.Cache.CRMCacheHandler.Instancia.Metodos.Existe(en.IdMetodoResolucionNovedad.Value) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Metodo de Novedad con IdMetodoResolucionNovedad = {0}.", en.IdMetodoResolucionNovedad))
         End If
         If Not Reglas.Cache.CRMCacheHandler.Instancia.Estados.Existe(en.IdEstadoNovedad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Estado de Novedad con IdEstadoNovedad = {0}.", en.IdEstadoNovedad))
         End If

         If Not String.IsNullOrWhiteSpace(en.IdUsuarioEstadoNovedad) AndAlso Not Reglas.Cache.SeguridadCacheHandler.Instancia.Usuarios.Existe(en.IdUsuarioEstadoNovedad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Usuario de Estado con IdUsuarioEstadoNovedad = {0}.", en.IdUsuarioEstadoNovedad))
         End If
         If Not Reglas.Cache.SeguridadCacheHandler.Instancia.Usuarios.Existe(en.IdUsuarioAlta) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Usuario de Alta con IdUsuarioAlta = {0}.", en.IdUsuarioAlta))
         End If
         If Not Reglas.Cache.SeguridadCacheHandler.Instancia.Usuarios.Existe(en.IdUsuarioAsignado) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Usuario de Asignado con IdUsuarioAsignado = {0}.", en.IdUsuarioAsignado))
         End If
         If Not String.IsNullOrWhiteSpace(en.IdUsuarioAsignado) AndAlso Not Reglas.Cache.SeguridadCacheHandler.Instancia.Usuarios.Existe(en.IdUsuarioAsignado) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Usuario de Asignado con IdUsuarioAsignado = {0}.", en.IdUsuarioAsignado))
         End If
         If Not String.IsNullOrWhiteSpace(en.IdUsuarioResponsable) AndAlso Not Reglas.Cache.SeguridadCacheHandler.Instancia.Usuarios.Existe(en.IdUsuarioResponsable) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Usuario de Responsable con IdUsuarioResponsable = {0}.", en.IdUsuarioResponsable))
         End If

         If en.IdProyecto > 0 AndAlso Not proyectosCache.Any(Function(x) x.IdProyecto = en.IdProyecto) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Proyecto con IdProyecto = {0}.", en.IdProyecto))
         End If

         If en.IdCliente > 0 AndAlso Not cache.ExisteClientePorIdRapido(en.IdCliente) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Cliente con IdCliente = {0}.", en.IdCliente))
         End If
         If en.IdProspecto > 0 AndAlso Not cache.ExisteProspectoPorIdRapido(en.IdProspecto) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Prospecto con IdProspecto = {0}.", en.IdProspecto))
         End If
         If en.IdProveedor > 0 AndAlso Not cache.ExisteProveedorPorIdRapido(en.IdProveedor) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Proveedor con IdProveedor = {0}.", en.IdProveedor))
         End If

         If Not String.IsNullOrWhiteSpace(en.IdFuncion) AndAlso funcionesCache.Select(String.Format("Id = '{0}'", en.IdFuncion)).Count = 0 Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Función con IdFuncion = {0}.", en.IdFuncion))
         End If


         SetEstadoRow(en, stbMensajeError, Function(x) regla.Existe(x.IdTipoNovedad, x.Letra, x.CentroEmisor, x.IdNovedad)) ' Reglas.Cache.CRMCacheHandler.Instancia.Estados.Existe(x.IdEstadoNovedad))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)
   End Function

   Private Function GetJSon(fechaActualizacionDesde As Date?) As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon)
      Dim lst = New List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon)()

      Dim dt As DataTable = GetSqlServer().CRMNovedades_Sync(fechaActualizacionDesde)
      Dim o As Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon()
         CargarUno(o, dr)
         lst.Add(o)
      Next

      Return lst
   End Function

   Public Function GetTransporte(fechaActualizacionDesde As Date?) As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSonTransporte)
      Dim datos = GetJSon(fechaActualizacionDesde)
      Dim result = New List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad In datos
         Dim tEntidad = New Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSonTransporte(Publicos.CuitEmpresa,
                                                                                          jEntidad.IdTipoNovedad, jEntidad.Letra, jEntidad.CentroEmisor, jEntidad.IdNovedad,
                                                                                          jEntidad.FechaActualizacionWeb) ' Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas))
         tEntidad.Datos = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

   Protected Overridable Sub CargarUno(o As Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon, dr As DataRow)
      With o
         Const tag As String = "CRMNovedades.CargarUno"
         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Inicia"))

         .IdTipoNovedad = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString())
         .Letra = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString())
         .IdNovedad = dr.Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString())

         .FechaNovedad = dr.Field(Of Date)(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).ToStringFormatoPropio()
         .Descripcion = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.Descripcion.ToString())
         .IdPrioridadNovedad = dr.Field(Of Integer)(Entidades.CRMNovedad.Columnas.IdPrioridadNovedad.ToString())
         .IdCategoriaNovedad = dr.Field(Of Integer)(Entidades.CRMNovedad.Columnas.IdCategoriaNovedad.ToString())
         .IdEstadoNovedad = dr.Field(Of Integer)(Entidades.CRMNovedad.Columnas.IdEstadoNovedad.ToString())
         .FechaEstadoNovedad = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).ToStringFormatoPropio()
         .IdUsuarioEstadoNovedad = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString())
         .FechaAlta = dr.Field(Of Date)(Entidades.CRMNovedad.Columnas.FechaAlta.ToString()).ToStringFormatoPropio()
         .IdUsuarioAlta = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString())
         .IdUsuarioAsignado = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString())
         .IdUsuarioResponsable = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdUsuarioResponsable.ToString())

         .Avance = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.Avance.ToString()).IfNull()

         .IdMedioComunicacionNovedad = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdMedioComunicacionNovedad.ToString())
         .IdMetodoResolucionNovedad = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdMetodoResolucionNovedad.ToString())

         .IdAplicacionTerceros = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdAplicacionTerceros.ToString()).IfNull()
         .IdMotivoNovedad = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdMotivoNovedad.ToString())
         .ComentarioPrincipal = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.ComentarioPrincipal.ToString()).StringToEnum(Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ninguno)

         .PatenteVehiculo = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.PatenteVehiculo.ToString()).IfNull()

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Luego de controles estáticos"))

         .IdCliente = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.IdCliente.ToString()).IfNull()
         .IdProspecto = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.IdProspecto.ToString()).IfNull()
         .IdProveedor = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.IdProveedor.ToString()).IfNull()

         .IdProyecto = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdProyecto.ToString()).IfNull()
         .IdFuncion = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdFuncion.ToString())
         .IdSistema = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdSistema.ToString())

         .FechaProximoContacto = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()).ToStringFormatoPropio()
         .BanderaColor = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.BanderaColor.ToString())
         .Interlocutor = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.Interlocutor.ToString())

         .RevisionAdministrativa = dr.Field(Of Boolean)(Entidades.CRMNovedad.Columnas.RevisionAdministrativa.ToString())
         .Priorizado = dr.Field(Of Boolean)(Entidades.CRMNovedad.Columnas.Priorizado.ToString())

         .IdTipoNovedadPadre = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString())
         .LetraPadre = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.LetraPadre.ToString())
         .CentroEmisorPadre = dr.Field(Of Short?)(Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString()).IfNull()
         .IdNovedadPadre = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString()).IfNull()

         .Version = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.Version.ToString())

         .FechaInicioPlan = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString()).ToStringFormatoPropio()
         .FechaFinPlan = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString()).ToStringFormatoPropio()
         .VersionFecha = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.VersionFecha.ToString()).ToStringFormatoPropio()
         .TiempoEstimado = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString()).IfNull()

         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Finalizando"))

         .Cantidad = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.Cantidad.ToString()).IfNull()

         .IdSucursalService = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdSucursalService.ToString()).IfNull()
         .IdTipoComprobanteService = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoComprobanteService.ToString())
         .LetraService = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.LetraService.ToString())
         .CentroEmisorService = Convert.ToInt16(dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.CentroEmisorService.ToString()).IfNull())
         .NumeroComprobanteService = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.NumeroComprobanteService.ToString()).IfNull()

         .IdProducto = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdProducto.ToString())
         .NombreProducto = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.NombreProducto.ToString())
         .CantidadProducto = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.CantidadProducto.ToString()).IfNull()
         .CostoReparacion = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.CostoReparacion.ToString()).IfNull()

         .IdProductoPrestado = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdProductoPrestado.ToString())
         .CantidadProductoPrestado = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.CantidadProductoPrestado.ToString()).IfNull()
         .NroSerieProductoPrestado = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.NroSerieProductoPrestado.ToString())
         .ProductoPrestadoDevuelto = dr.Field(Of Boolean)(Entidades.CRMNovedad.Columnas.ProductoPrestadoDevuelto.ToString())
         .IdProveedorService = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.IdProveedorService.ToString()).IfNull()

         .Contador1 = dr.Field(Of Integer)(Entidades.CRMNovedad.Columnas.Contador1.ToString())
         .Contador2 = dr.Field(Of Integer)(Entidades.CRMNovedad.Columnas.Contador2.ToString())

         .FechaActualizacionWeb = dr.Field(Of Date)(Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString()).ToStringFormatoPropio(conMilisegundos:=True)
         .EtiquetaNovedad = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.EtiquetaNovedad.ToString())

         .IdProductoNovedad = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdProductoNovedad.ToString())

         .NroDeSerie = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.NroDeSerie.ToString())
         .TieneGarantiaService = dr.Field(Of Boolean?)(Entidades.CRMNovedad.Columnas.TieneGarantiaService.ToString())
         .UbicacionService = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.UbicacionService.ToString())

         '# Campos correspondientes a la facturación de la novedad
         .IdSucursalFact = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdSucursalFact.ToString())
         .IdTipoComprobanteFact = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoComprobanteFact.ToString())
         .LetraFact = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.LetraFact.ToString())
         .CentroEmisorFact = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.CentroEmisorFact.ToString())
         .NumeroComprobanteFact = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.NumeroComprobanteFact.ToString())
         .RequiereTesteo = dr.Field(Of Boolean)(Entidades.CRMNovedad.Columnas.RequiereTesteo.ToString())

         .FechaEntregado = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaEntregado.ToString()).ToStringFormatoPropio()
         .FechaFinalizado = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaFinalizado.ToString()).ToStringFormatoPropio()
         .IdEstadoNovedadEntregado = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdEstadoNovedadEntregado.ToString())
         .IdEstadoNovedadFinalizado = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdEstadoNovedadFinalizado.ToString())

         .IdUsuarioEntregado = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdUsuarioEntregado.ToString())
         .IdUsuarioFinalizado = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdUsuarioFinalizado.ToString())
         .IdEstadoNovedadAnterior = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdEstadoNovedadAnterior.ToString())
         .AvanceAnterior = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.AvanceAnterior.ToString())



         .Observacion = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.Observacion.ToString())
         .ClienteValorizacionEstrellas = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.ClienteValorizacionEstrellas.ToString())
         .AnticipoNovedad = dr.Field(Of Decimal?)(Entidades.CRMNovedad.Columnas.AnticipoNovedad.ToString()).IfNull()
         .FechaHoraRetiro = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaHoraRetiro.ToString()).ToStringFormatoPropio()
         .IdDomicilioRetiro = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdDomicilioRetiro.ToString())
         .FechaHoraEntrega = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaHoraEntrega.ToString()).ToStringFormatoPropio()
         .IdDomicilioEntrega = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdDomicilioEntrega.ToString())
         .IdProveedorGarantia = dr.Field(Of Long?)(Entidades.CRMNovedad.Columnas.IdProveedorGarantia.ToString())
         .FechaHoraEnvioGarantia = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaHoraEnvioGarantia.ToString()).ToStringFormatoPropio()
         .FechaHoraRetiroGarantia = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.FechaHoraRetiroGarantia.ToString()).ToStringFormatoPropio()
         .idMarcaProducto = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.idMarcaProducto.ToString())
         .idModeloProducto = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.idModeloProducto.ToString())
         .IdSucursalNovedad = dr.Field(Of Integer?)(Entidades.CRMNovedad.Columnas.IdSucursalNovedad.ToString())
         .ServiceLugarCompra = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.ServiceLugarCompra.ToString())
         .ServiceLugarCompraFecha = dr.Field(Of Date?)(Entidades.CRMNovedad.Columnas.ServiceLugarCompraFecha.ToString()).ToStringFormatoPropio()
         .ServiceLugarCompraTipoComprobante = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.ServiceLugarCompraTipoComprobante.ToString())
         .ServiceLugarCompraNumeroComprobante = dr.Field(Of String)(Entidades.CRMNovedad.Columnas.ServiceLugarCompraNumeroComprobante.ToString())


         My.Application.Log.WriteEntry(String.Format("{0} - {1:yyyy-MM-dd HH:mm:ss.fff} - {2}", tag, Now, "Fin"))

      End With
   End Sub

End Class