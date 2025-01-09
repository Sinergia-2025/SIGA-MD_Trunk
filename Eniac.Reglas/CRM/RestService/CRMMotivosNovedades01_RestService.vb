Imports Eniac.Entidades
Imports Eniac.Entidades.JSonEntidades.Archivos.CRM
Imports Eniac.Reglas.ServiciosRest.Sincronizacion

Partial Class CRMMotivosNovedades
   Private Const ModuloEvento As String = "CRMMotivoNovedad"
   Public Overrides Function Convertir(transporte As List(Of CRMMotivoNovedadJSonTransporte)) As List(Of CRMMotivoNovedadJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of CRMMotivoNovedadJSon)(dato.Datos))
   End Function

   Public Overrides Function ValidarDatos(col As List(Of CRMMotivoNovedadJSon), syncs As SyncBaseCollection) As Boolean
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

         SetEstadoRow(en, stbMensajeError, Function(x) Cache.CRMCacheHandler.Instancia.Estados.Existe(x.IdMotivoNovedad))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)
   End Function

   Public Overrides Function ImportarDatos(col As List(Of CRMMotivoNovedadJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql = New SqlServer.CRMMotivosNovedades(da)
         Dim eventArgs = New Clientes.AvanceProcesarDatosEventArgs(ModuloEvento)

         eventArgs.TotalRegistros = col.Count
         Dim maximoFechaActualizacion As Date? = Nothing
         For Each en In col
            eventArgs.RegistroActual += 1
            eventArgs.Datos = en
            OnAvanceImportarDatos(eventArgs)
            If en.___Estado = "A" Then
               sql.CRMMotivosNovedades_I(en.IdMotivoNovedad, en.NombreMotivoNovedad, en.Posicion, en.IdTipoNovedad)
            ElseIf en.___Estado = "M" Then
               sql.CRMMotivosNovedades_U(en.IdMotivoNovedad, en.NombreMotivoNovedad, en.Posicion, en.IdTipoNovedad)
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

End Class
