#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Partial Class Localidades
#Region "RestService & Json"
   Public Event AvanceValidarDatosLocalidades(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosLocalidades(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosLocalidades(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosLocalidades(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)(dato.DatosLocalidad))
   End Function

   Public Function GetLocalidadesJSon(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSon) = New List(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)()

      Dim dt As DataTable = New SqlServer.Localidades(da).Localidades_GA(fechaActualizacionDesde)
      Dim o As Entidades.JSonEntidades.Archivos.LocalidadJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.LocalidadJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.LocalidadJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdLocalidad = Integer.Parse(dr(Entidades.Localidad.Columnas.IdLocalidad.ToString()).ToString())
         .NombreLocalidad = dr(Entidades.Localidad.Columnas.NombreLocalidad.ToString()).ToString()
         .IdProvincia = dr(Entidades.Localidad.Columnas.IdProvincia.ToString()).ToString()

         .FechaActualizacionWeb = dr.Field(Of DateTime?)(Entidades.Localidad.Columnas.FechaActualizacionWeb.ToString()).IfNull().ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)
      End With
   End Sub

   Public Sub CargarJSonEnDataTable(localidadesJson As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte), dt As DataTable)
      Dim dr As DataRow
      For Each transporte As Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte In localidadesJson
         Dim localidadeJson As Entidades.JSonEntidades.Archivos.LocalidadJSon
         localidadeJson = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)(transporte.DatosLocalidad)

         dr = dt.NewRow()
         Clientes.SeteaValor(dr, "CuitEmpresa", localidadeJson.CuitEmpresa, GetType(String))
         Clientes.SeteaValor(dr, Entidades.Localidad.Columnas.IdLocalidad.ToString(), localidadeJson.IdLocalidad, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.Localidad.Columnas.NombreLocalidad.ToString(), localidadeJson.NombreLocalidad, GetType(String))
         Clientes.SeteaValor(dr, Entidades.Localidad.Columnas.IdProvincia.ToString(), localidadeJson.IdProvincia, GetType(String))

         Clientes.SeteaValor(dr, Entidades.Localidad.Columnas.FechaActualizacionWeb.ToString(), localidadeJson.FechaActualizacionWeb, GetType(String))

         Clientes.SeteaValor(dr, "DatosSyncronizados", localidadeJson, GetType(Object))
         localidadeJson.drOrigen = dr

         dt.Rows.Add(dr)
      Next
   End Sub

   Public Overloads Sub ValidarDatos(dt As DataTable)
      ValidarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)("DatosSyncronizados")), Nothing)
   End Sub


   Public Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSon), syncs As ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Localidades")

      eventArgs.TotalRegistros = col.Count
      For Each en As Entidades.JSonEntidades.Archivos.LocalidadJSon In col
         Dim stbMensajeError As StringBuilder = New StringBuilder()
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatos(eventArgs)
         If True Then
            If Not cache.ExisteProvincia(en.IdProvincia) Then
               SetErrorMessage(stbMensajeError, en, String.Format("No existe la Provincia con IdProvincia = {0}.", en.IdProvincia), "IdProvincia")
            End If
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteLocalidad(x.IdLocalidad))

         OnAvanceValidarDatos(eventArgs)

         '' ''If drLocalidad.HasErrors Then
         '' ''   drLocalidad("___estado") = "E"
         '' ''   Dim stb As StringBuilder = New StringBuilder()
         '' ''   For Each dc As DataColumn In drLocalidad.GetColumnsInError
         '' ''      stb.AppendFormat("{0} - ", drLocalidad.GetColumnError(dc))
         '' ''   Next
         '' ''   drLocalidad("___mensajeError") = stb.ToString()
         '' ''Else
         '' ''   Dim idLocalidad As Integer = Integer.Parse(drLocalidad(Entidades.Localidad.Columnas.IdLocalidad.ToString()).ToString())
         '' ''   'If cache.BuscaClientePorId(idCliente) Is Nothing Then
         '' ''   If cache.ExisteLocalidad(idLocalidad) Then
         '' ''      drLocalidad("___estado") = "M"
         '' ''   Else
         '' ''      drLocalidad("___estado") = "A"
         '' ''   End If
         '' ''End If
      Next

      Return CheckAlgunError(col)

   End Function

   Public Overrides Function ImportarDatos(transporte As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.Localidades = New SqlServer.Localidades(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Localidades")
         eventArgs.TotalRegistros = transporte.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr As Entidades.JSonEntidades.Archivos.LocalidadJSon In transporte
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatos(eventArgs)
            If dr.___Estado = "A" Then
               sql.Localidades_I(dr.IdLocalidad,
                                 dr.IdProvincia,
                                 dr.NombreLocalidad)
            ElseIf dr.___Estado = "M" Then
               sql.Localidades_U(dr.IdLocalidad,
                                 dr.IdProvincia,
                                 dr.NombreLocalidad)
            End If

            dr.___Estado = "I"

            Dim fechaActualizacion As String = dr.FechaActualizacionWeb
            If IsDate(fechaActualizacion) Then
               Dim fecha As DateTime = DateTime.Parse(fechaActualizacion)
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
            Publicos.WebArchivos.Localidades.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         End If

      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      ImportarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)("DatosSyncronizados")))
   End Sub

   Public Function GetLocalidadesJSonTransporte(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSon) = GetLocalidadesJSon(fechaActualizacionDesde)
      Dim result As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.LocalidadJSon In datos
         Dim tEntidad As Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte
         tEntidad = New Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdLocalidad, jEntidad.FechaActualizacionWeb) 'Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas))
         tEntidad.DatosLocalidad = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub
#End Region

End Class