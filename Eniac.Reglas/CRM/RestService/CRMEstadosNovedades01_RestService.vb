Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Partial Class CRMEstadosNovedades
   Private Const ModuloEvento As String = "CRMCategoriaNovedad"

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSon)(dato.Datos))
   End Function

   Public Overloads Overrides Function ImportarDatos(col As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql = New SqlServer.CRMEstadosNovedades(da)
         Dim eventArgs = New Clientes.AvanceProcesarDatosEventArgs(ModuloEvento)

         eventArgs.TotalRegistros = col.Count
         Dim maximoFechaActualizacion As Date? = Nothing
         For Each en In col
            eventArgs.RegistroActual += 1
            eventArgs.Datos = en
            OnAvanceImportarDatos(eventArgs)
            If en.___Estado = "A" Then
               sql.CRMEstadosNovedades_I(en.IdEstadoNovedad, en.NombreEstadoNovedad, en.Posicion, en.SolicitaUsuario, en.Finalizado, en.IdTipoNovedad, en.PorDefecto, en.DiasProximoContacto, en.DiasProximoContacto, en.ActualizaUsuarioResponsable, en.SolicitaProveedorService, en.Imprime, en.Reporte, en.Embebido, en.AcumulaContador1, en.AcumulaContador2, en.EsFacturable, en.CantidadCopias, en.IdTipoEstadoNovedad, en.Entregado, en.IdEstadoFacturado, en.AvanceEstadoFacturado, en.ControlaStockConsumido, en.RequiereComentarios)
            ElseIf en.___Estado = "M" Then
               sql.CRMEstadosNovedades_U(en.IdEstadoNovedad, en.NombreEstadoNovedad, en.Posicion, en.SolicitaUsuario, en.Finalizado, en.IdTipoNovedad, en.PorDefecto, en.DiasProximoContacto, en.DiasProximoContacto, en.ActualizaUsuarioResponsable, en.SolicitaProveedorService, en.Imprime, en.Reporte, en.Embebido, en.AcumulaContador1, en.AcumulaContador2, en.EsFacturable, en.CantidadCopias, en.IdTipoEstadoNovedad, en.Entregado, en.IdEstadoFacturado, en.AvanceEstadoFacturado, en.ControlaStockConsumido, en.RequiereComentarios)
            End If

            en.___Estado = "I"

            'Dim fechaActualizacion As String = Clientes.ObtieneValor(dr, Entidades.Rubro.Columnas.FechaActualizacionWeb.ToString(), String.Empty)
            'If IsDate(fechaActualizacion) Then
            '   Dim fecha As DateTime = DateTime.Parse(fechaActualizacion)
            '   If Not maximoFechaActualizacion.HasValue Then
            '      maximoFechaActualizacion = fecha
            '   End If

            '   If fecha > maximoFechaActualizacion Then
            '      maximoFechaActualizacion = fecha
            '   End If
            'End If
            OnAvanceImportarDatos(eventArgs)

         Next
         'If maximoFechaActualizacion.HasValue Then
         '   Publicos.WebArchivos.Rubros.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         'End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Overloads Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSon), syncs As SyncBaseCollection) As Boolean
      Dim eventArgs = New Clientes.AvanceProcesarDatosEventArgs(ModuloEvento)

      Dim stbMensajeError = New StringBuilder()

      eventArgs.TotalRegistros = col.Count
      For Each en In col
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatos(eventArgs)

         If Not Cache.CRMCacheHandler.Instancia.Tipos.Existe(en.IdTipoNovedad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Tipo de Novedad con IdTipoNovedad = {0}.", en.IdTipoNovedad))
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) Cache.CRMCacheHandler.Instancia.Estados.Existe(x.IdEstadoNovedad))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)
   End Function

   Public Function GetTransporte() As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSonTransporte)
      Dim datos = GetTodos(idTipoNovedad:=String.Empty)
      Dim result = New List(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSonTransporte)()
      Dim serializer = New Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad In datos
         Dim tEntidad = New Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSonTransporte(Publicos.CuitEmpresa, jEntidad.IdEstadoNovedad, Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas))
         tEntidad.Datos = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

End Class