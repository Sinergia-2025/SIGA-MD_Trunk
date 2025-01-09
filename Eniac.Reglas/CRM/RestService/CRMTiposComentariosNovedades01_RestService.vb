#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion
#End Region
Partial Class CRMTiposComentariosNovedades
   Private Const ModuloEvento As String = "CRMTipoComentarioNovedad"

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSon)(dato.Datos))
   End Function

   Public Overloads Overrides Function ImportarDatos(col As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql = New SqlServer.CRMTiposComentariosNovedades(da)
         Dim eventArgs = New Clientes.AvanceProcesarDatosEventArgs(ModuloEvento)

         eventArgs.TotalRegistros = col.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each en In col
            eventArgs.RegistroActual += 1
            eventArgs.Datos = en
            OnAvanceImportarDatos(eventArgs)
            If en.___Estado = "A" Then
               sql.CRMTiposComentariosNovedades_I(en.IdTipoComentarioNovedad, en.NombreTipoComentarioNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto, en.Color, en.VisibleParaCliente, en.VisibleParaRepresentante)
            ElseIf en.___Estado = "M" Then
               sql.CRMTiposComentariosNovedades_U(en.IdTipoComentarioNovedad, en.NombreTipoComentarioNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto, en.Color, en.VisibleParaCliente, en.VisibleParaRepresentante)
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

   Public Overloads Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSon), syncs As SyncBaseCollection) As Boolean
      'Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs(ModuloEvento)

      Dim stbMensajeError = New StringBuilder()

      eventArgs.TotalRegistros = col.Count
      For Each en In col
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatos(eventArgs)

         If Not Reglas.Cache.CRMCacheHandler.Instancia.Tipos.Existe(en.IdTipoNovedad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Tipo de Novedad con IdTipoNovedad = {0}.", en.IdTipoNovedad))
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) Reglas.Cache.CRMCacheHandler.Instancia.TiposComentarios.Existe(x.IdTipoComentarioNovedad))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)
   End Function

   Public Function GetTransporte() As List(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSonTransporte)
      Dim datos = GetTodos(idTipoNovedad:=String.Empty)
      Dim result = New List(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad In datos
         Dim tEntidad = New Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSonTransporte(Publicos.CuitEmpresa, jEntidad.IdTipoComentarioNovedad, Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas))
         tEntidad.Datos = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function


End Class