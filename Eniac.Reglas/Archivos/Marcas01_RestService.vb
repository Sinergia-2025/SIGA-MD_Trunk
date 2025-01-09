#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Partial Class Marcas
#Region "RestService & Json"
   Public Event AvanceValidarDatosMarcas(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosMarcas(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosMarcas(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosMarcas(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub
   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.MarcaJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.MarcaJSon)(dato.DatosMarca))
   End Function

   Public Function GetMarcaJSon() As List(Of Entidades.JSonEntidades.Archivos.MarcaJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.MarcaJSon) = New List(Of Entidades.JSonEntidades.Archivos.MarcaJSon)()

      Dim dt As DataTable = New SqlServer.Marcas(da).Marcas_GA() 'fechaActualizacionDesde)
      Dim o As Entidades.JSonEntidades.Archivos.MarcaJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.MarcaJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.MarcaJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdMarca = Integer.Parse(dr(Entidades.Marca.Columnas.IdMarca.ToString()).ToString())
         .NombreMarca = dr(Entidades.Marca.Columnas.NombreMarca.ToString()).ToString()
         .ComisionPorVenta = Decimal.Parse(dr(Entidades.Marca.Columnas.ComisionPorVenta.ToString()).ToString())
         .DescuentoRecargoPorc1 = Decimal.Parse(dr(Entidades.Marca.Columnas.DescuentoRecargoPorc1.ToString()).ToString())
         .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.Marca.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
         .FechaActualizacionWeb = Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)
      End With
   End Sub

   Public Sub CargarJSonEnLista(entidadesTransporte As List(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte),
                                entidadesJson As List(Of Entidades.JSonEntidades.Archivos.MarcaJSon))

      Dim ser As System.Web.Script.Serialization.JavaScriptSerializer
      Dim entidadJSon As Entidades.JSonEntidades.Archivos.MarcaJSon

      ser = New System.Web.Script.Serialization.JavaScriptSerializer()
      For Each transporte As Entidades.JSonEntidades.Archivos.MarcaJSonTransporte In entidadesTransporte
         entidadJSon = ser.Deserialize(Of Entidades.JSonEntidades.Archivos.MarcaJSon)(transporte.DatosMarca)
         entidadesJson.Add(entidadJSon)
      Next
   End Sub

   Public Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.MarcaJSon), syncs As ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Marcas")

      Dim stbMensajeError = New StringBuilder()

      eventArgs.TotalRegistros = col.Count
      For Each en As Entidades.JSonEntidades.Archivos.MarcaJSon In col
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatos(eventArgs)
         If True Then
            'Dim IdProvincia As String = drMarca(Entidades.Rubro.Columnas.IdProvincia.ToString()).ToString()
            'If Not String.IsNullOrEmpty(IdProvincia) AndAlso Not cache.ExisteProvincia(IdProvincia) Then
            '   drRubro.SetColumnError("IdProvincia", String.Format("No existe la Provincia con IdProvincia = {0}.", IdProvincia))
            'End If
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteMarca(x.IdMarca))

         '' ''If drMarca.ConErrores Then
         '' ''   drMarca.___Estado = "E"
         '' ''   drMarca.___MensajeError = stbMensajeError.ToString()
         '' ''Else
         '' ''   Dim idMarca As Integer = drMarca.IdMarca
         '' ''   'If cache.BuscaClientePorId(idCliente) Is Nothing Then
         '' ''   If cache.ExisteMarca(idMarca) Then
         '' ''      drMarca.___Estado = "M"
         '' ''   Else
         '' ''      drMarca.___Estado = "A"
         '' ''   End If
         '' ''End If

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)

   End Function

   Public Overloads Sub ValidarDatos(dt As List(Of Entidades.JSonEntidades.Archivos.MarcaJSon))
      ValidarDatos(dt, Nothing)
   End Sub

   Public Overrides Function ImportarDatos(transporte As List(Of Entidades.JSonEntidades.Archivos.MarcaJSon)) As Boolean
      ImportarDesdeWebSiga(transporte)
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

   Public Sub ImportarDesdeWebSiga(Of T)(dt As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sClientes As SqlServer.Marcas = New SqlServer.Marcas(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Marcas")

         eventArgs.TotalRegistros = dt.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr1 As T In dt
            Dim dr As Entidades.JSonEntidades.Archivos.MarcaJSon = DirectCast(Convert.ChangeType(dr1, GetType(Entidades.JSonEntidades.Archivos.MarcaJSon)), Entidades.JSonEntidades.Archivos.MarcaJSon)
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatos(eventArgs)
            If dr.___Estado = "A" Then
               sClientes.Marcas_I(dr.IdMarca, dr.NombreMarca, dr.ComisionPorVenta, dr.DescuentoRecargoPorc1, dr.DescuentoRecargoPorc2)
            ElseIf dr.___Estado = "M" Then
               sClientes.Marcas_U(dr.IdMarca, dr.NombreMarca, dr.ComisionPorVenta, dr.DescuentoRecargoPorc1, dr.DescuentoRecargoPorc2)
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
            OnAvanceImportarDatos(eventArgs)

         Next
         'If maximoFechaActualizacion.HasValue Then
         '   Publicos.WebArchivos.Rubros.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         'End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Function GetMarcasJSonTransporte() As List(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.MarcaJSon) = GetMarcaJSon()
      Dim result As List(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.MarcaJSon In datos
         Dim tEntidad As Entidades.JSonEntidades.Archivos.MarcaJSonTransporte
         tEntidad = New Entidades.JSonEntidades.Archivos.MarcaJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdMarca, jEntidad.FechaActualizacionWeb) 'Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas))
         tEntidad.DatosMarca = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

#End Region

End Class