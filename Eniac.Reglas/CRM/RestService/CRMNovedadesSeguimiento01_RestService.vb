#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion
#End Region
Partial Class CRMNovedadesSeguimiento
   Private Const ModuloEvento As String = "CRMNovedadSeguimiento"

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon)(dato.Datos))
   End Function

   Public Overloads Overrides Function ImportarDatos(col As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql = New SqlServer.CRMNovedadesSeguimiento(da)
         Dim eventArgs = New Clientes.AvanceProcesarDatosEventArgs(ModuloEvento)

         eventArgs.TotalRegistros = col.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each en In col
            eventArgs.RegistroActual += 1
            eventArgs.Datos = en
            OnAvanceImportarDatos(eventArgs)
            If en.___Estado = "A" Then
               sql.CRMNovedadesSeguimiento_I(en.FechaActualizacionWeb.ToDateTime(),
                                             en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico,
                                             en.FechaSeguimiento.ToDateTime().IfNull(),
                                             en.Comentario,
                                             en.Interlocutor,
                                             en.EsComentario,
                                             en.IdUsuarioSeguimiento,
                                             en.IdTipoComentarioNovedad,
                                             en.ComentarioPrincipal,
                                             en.Activo,
                                             en.IdEstadoNovedad,
                                             en.IdUsuarioAsignado)
            ElseIf en.___Estado = "M" Then
               sql.CRMNovedadesSeguimiento_U(en.FechaActualizacionWeb.ToDateTime(),
                                             en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico,
                                             en.FechaSeguimiento.ToDateTime().IfNull(Today),
                                             en.Comentario,
                                             en.Interlocutor,
                                             en.EsComentario,
                                             en.IdUsuarioSeguimiento,
                                             en.IdTipoComentarioNovedad,
                                             en.ComentarioPrincipal,
                                             en.Activo,
                                             en.IdEstadoNovedad,
                                             en.IdUsuarioAsignado)
            End If

            en.___Estado = "I"

            If IsDate(en.FechaActualizacionWeb) Then
               Dim fecha As DateTime = DateTime.Parse(en.FechaActualizacionWeb)
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

   Public Overloads Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon), syncs As SyncBaseCollection) As Boolean
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
         If Not Reglas.Cache.CRMCacheHandler.Instancia.Estados.Existe(en.IdEstadoNovedad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Estado de Novedad con IdEstadoNovedad = {0}.", en.IdEstadoNovedad))
         End If
         If en.IdTipoComentarioNovedad.IfNull() <> 0 AndAlso Not Reglas.Cache.CRMCacheHandler.Instancia.TiposComentarios.Existe(en.IdTipoComentarioNovedad.Value) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Tipo de Comentario con IdTipoComentarioNovedad = {0}.", en.IdTipoComentarioNovedad))
         End If

         If Not String.IsNullOrWhiteSpace(en.IdUsuarioSeguimiento) AndAlso Not Reglas.Cache.SeguridadCacheHandler.Instancia.Usuarios.Existe(en.IdUsuarioSeguimiento) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Usuario de Seguimiento con IdUsuarioSeguimiento = {0}.", en.IdUsuarioSeguimiento))
         End If
         If Not String.IsNullOrWhiteSpace(en.IdUsuarioAsignado) AndAlso Not Reglas.Cache.SeguridadCacheHandler.Instancia.Usuarios.Existe(en.IdUsuarioAsignado) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Usuario de Asignado con IdUsuarioAsignado = {0}.", en.IdUsuarioAsignado))
         End If


         SetEstadoRow(en, stbMensajeError, Function(x) regla.Existe(x.IdTipoNovedad, x.Letra, x.CentroEmisor, x.IdNovedad)) ' Reglas.Cache.CRMCacheHandler.Instancia.Estados.Existe(x.IdEstadoNovedad))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)
   End Function

   Private Function GetJSon(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon)
      Dim lst = New List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon)()

      Dim dt As DataTable = New SqlServer.CRMNovedadesSeguimiento(da).CRMNovedadesSeguimiento_GA(fechaActualizacionDesde,
                                                                                                 visibleParaCliente:=Entidades.Publicos.SiNoTodos.TODOS,
                                                                                                 visibleParaRepresentante:=Entidades.Publicos.SiNoTodos.SI)
      Dim o As Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon()
         CargarUno(o, dr)
         lst.Add(o)
      Next

      Return lst
   End Function

   Public Function GetTransporte(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSonTransporte)
      Dim datos = GetJSon(fechaActualizacionDesde)
      Dim result = New List(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad In datos
         Dim tEntidad = New Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSonTransporte(Publicos.CuitEmpresa, jEntidad.IdUnico, jEntidad.FechaActualizacionWeb)
         tEntidad.Datos = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

   Protected Overridable Sub CargarUno(o As Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon, dr As DataRow)
      With o

         .IdTipoNovedad = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.IdTipoNovedad.ToString())
         .Letra = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.CRMNovedadSeguimiento.Columnas.CentroEmisor.ToString())
         .IdNovedad = dr.Field(Of Long)(Entidades.CRMNovedadSeguimiento.Columnas.IdNovedad.ToString())
         .IdSeguimiento = dr.Field(Of Integer)(Entidades.CRMNovedadSeguimiento.Columnas.IdSeguimiento.ToString())
         .IdUnico = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.IdUnico.ToString())

         .FechaSeguimiento = dr.Field(Of DateTime)(Entidades.CRMNovedadSeguimiento.Columnas.FechaSeguimiento.ToString()).ToStringFormatoPropio()
         .Comentario = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString())
         .Interlocutor = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.Interlocutor.ToString())
         .EsComentario = dr.Field(Of Boolean)(Entidades.CRMNovedadSeguimiento.Columnas.EsComentario.ToString())
         .IdTipoComentarioNovedad = dr.Field(Of Integer?)(Entidades.CRMNovedadSeguimiento.Columnas.IdTipoComentarioNovedad.ToString())
         .ComentarioPrincipal = dr.Field(Of Boolean)(Entidades.CRMNovedadSeguimiento.Columnas.ComentarioPrincipal.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.CRMNovedadSeguimiento.Columnas.Activo.ToString())
         .IdUsuarioSeguimiento = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.UsuarioSeguimiento.ToString())
         .IdUsuarioAsignado = dr.Field(Of String)(Entidades.CRMNovedadSeguimiento.Columnas.UsuarioAsignado.ToString())
         .IdEstadoNovedad = dr.Field(Of Integer)(Entidades.CRMNovedadSeguimiento.Columnas.IdEstadoNovedad.ToString())

         .FechaActualizacionWeb = dr.Field(Of DateTime)(Entidades.CRMNovedadSeguimiento.Columnas.FechaActualizacionWeb.ToString()).ToStringFormatoPropio(conMilisegundos:=True)

      End With
   End Sub

End Class