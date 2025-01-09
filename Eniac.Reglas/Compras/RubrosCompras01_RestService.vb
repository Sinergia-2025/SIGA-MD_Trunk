#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On
Imports Eniac.Entidades.JSonEntidades
Imports Eniac.Entidades.JSonEntidades.Extensions
#End Region
Partial Class RubrosCompras

#Region "RestService & Json"
   Public Event AvanceValidarDatosRubrosCompras(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosRubrosCompras(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Public Function GetRubroCompraJSon() As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJson)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJson) = New List(Of Entidades.JSonEntidades.Archivos.RubroCompraJson)()

      Dim dt As DataTable = New SqlServer.RubrosCompras(da).RubrosCompras_GA()
      Dim o As Entidades.JSonEntidades.Archivos.RubroCompraJson
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.RubroCompraJson()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.RubroCompraJson, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdRubro = Integer.Parse(dr("IdRubro").ToString())
         .NombreRubro = dr("NombreRubro").ToString()
      End With
   End Sub

   Public Sub CargarJSonEnLista(entidadesTransporte As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte),
                                entidadesJson As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJson))

      Dim ser As System.Web.Script.Serialization.JavaScriptSerializer
      Dim entidadJSon As Entidades.JSonEntidades.Archivos.RubroCompraJson

      ser = New System.Web.Script.Serialization.JavaScriptSerializer()
      For Each transporte As Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte In entidadesTransporte
         entidadJSon = ser.Deserialize(Of Entidades.JSonEntidades.Archivos.RubroCompraJson)(transporte.DatosRubro)
         entidadesJson.Add(entidadJSon)
      Next
   End Sub

   Protected Sub OnAvanceValidarDatosRubrosCompras(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosRubrosCompras(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Protected Sub OnAvanceImportarDatosRubrosCompras(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosRubrosCompras(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJson)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.RubroCompraJson)(dato.DatosRubro))
   End Function

   Public Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJson), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("RubrosCompras")

      Dim stbMensajeError As StringBuilder = New StringBuilder()

      eventArgs.TotalRegistros = col.Count
      For Each en As Entidades.JSonEntidades.Archivos.RubroCompraJson In col
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatosRubrosCompras(eventArgs)
         If True Then
            'Dim IdProvincia As String = drMarca(Entidades.Rubro.Columnas.IdProvincia.ToString()).ToString()
            'If Not String.IsNullOrEmpty(IdProvincia) AndAlso Not cache.ExisteProvincia(IdProvincia) Then
            '   drRubro.SetColumnError("IdProvincia", String.Format("No existe la Provincia con IdProvincia = {0}.", IdProvincia))
            'End If
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteRubroCompra(x.IdRubro))

         OnAvanceValidarDatosRubrosCompras(eventArgs)
      Next

      Return CheckAlgunError(col)

   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

   Public Overrides Function ImportarDatos(transporte As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJson)) As Boolean
      ImportarDesdeWebSiga(transporte)
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dt As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sClientes As SqlServer.RubrosCompras = New SqlServer.RubrosCompras(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("RubrosCompras")

         eventArgs.TotalRegistros = dt.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr1 As T In dt
            Dim dr As Entidades.JSonEntidades.Archivos.RubroCompraJson = CType(Convert.ChangeType(dr1, GetType(Entidades.JSonEntidades.Archivos.RubroCompraJson)), Entidades.JSonEntidades.Archivos.RubroCompraJson)
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatosRubrosCompras(eventArgs)
            If dr.___Estado = "A" Then
               sClientes.RubrosCompras_I(dr.IdRubro, dr.NombreRubro)
            ElseIf dr.___Estado = "M" Then
               sClientes.RubrosCompras_U(dr.IdRubro, dr.NombreRubro)
            End If

            dr.___Estado = "I"

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
            OnAvanceImportarDatosRubrosCompras(eventArgs)

         Next
         'If maximoFechaActualizacion.HasValue Then
         '   Publicos.WebArchivos.Rubros.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         'End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Function GetRubrosComprasJSonTransporte() As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJson) = GetRubroCompraJSon()
      Dim result As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.RubroCompraJson In datos
         Dim tEntidad As Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte
         tEntidad = New Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdRubro, Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)) ' jEntidad.FechaActualizacionWeb)
         tEntidad.DatosRubro = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

#End Region

End Class