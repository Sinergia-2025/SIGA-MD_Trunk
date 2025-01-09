#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Partial Class SubSubRubros
#Region "RestService & Json"
   Public Event AvanceValidarDatosSubSubRubros(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosSubSubRubros(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosSubSubRubros(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosSubSubRubros(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)(dato.DatosSubSubRubro))
   End Function

   Public Function GetSubSubSubRubrosJson(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon) = New List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)()

      Dim dt As DataTable = New SqlServer.SubSubRubros(da).SubSubRubros_GA(fechaActualizacionDesde)
      Dim o As Entidades.JSonEntidades.Archivos.SubSubRubroJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.SubSubRubroJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.SubSubRubroJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdSubSubRubro = Integer.Parse(dr(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString()).ToString())
         .NombreSubSubRubro = dr(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()).ToString()
         .IdSubRubro = Integer.Parse(dr(Entidades.SubSubRubro.Columnas.IdSubRubro.ToString()).ToString())

         .FechaActualizacionWeb = dr.Field(Of DateTime?)(Entidades.SubSubRubro.Columnas.FechaActualizacionWeb.ToString()).IfNull().ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)

         .IdSubSubRubroTiendaNube = dr.Field(Of String)(Entidades.SubSubRubro.Columnas.IdSubSubRubroTiendaNube.ToString())
         .IdSubSubRubroMercadoLibre = dr.Field(Of String)(Entidades.SubSubRubro.Columnas.IdSubSubRubroMercadoLibre.ToString())
      End With
   End Sub

   Public Sub CargarJSonEnDataTable(jEntidades As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte), dt As DataTable)
      Dim dr As DataRow
      For Each transporte As Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte In jEntidades
         Dim jEntidad As Entidades.JSonEntidades.Archivos.SubSubRubroJSon
         jEntidad = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)(transporte.DatosSubSubRubro)

         dr = dt.NewRow()
         Clientes.SeteaValor(dr, "CuitEmpresa", jEntidad.CuitEmpresa, GetType(String))
         Clientes.SeteaValor(dr, Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString(), jEntidad.IdSubSubRubro, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString(), jEntidad.NombreSubSubRubro, GetType(String))
         Clientes.SeteaValor(dr, Entidades.SubSubRubro.Columnas.IdSubRubro.ToString(), jEntidad.IdSubRubro, GetType(Integer))

         Clientes.SeteaValor(dr, Entidades.SubSubRubro.Columnas.FechaActualizacionWeb.ToString(), jEntidad.FechaActualizacionWeb, GetType(String))
         Clientes.SeteaValor(dr, Entidades.SubSubRubro.Columnas.IdSubSubRubroTiendaNube.ToString(), jEntidad.IdSubSubRubroTiendaNube, GetType(String))
         Clientes.SeteaValor(dr, Entidades.SubSubRubro.Columnas.IdSubSubRubroMercadoLibre.ToString(), jEntidad.IdSubSubRubroMercadoLibre, GetType(String))

         Clientes.SeteaValor(dr, "DatosSyncronizados", jEntidad, GetType(Object))
         jEntidad.drOrigen = dr

         dt.Rows.Add(dr)
      Next
   End Sub

   Public Overloads Sub ValidarDatos(dt As DataTable, dtSubRubro As DataTable)
      ValidarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)("DatosSyncronizados")),
                   New ServiciosRest.Sincronizacion.SyncBaseCollection().
                        AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.SubRubroJSon),
                                                    dtSubRubro.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)("DatosSyncronizados"))))
   End Sub

   Public Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon), syncs As ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("SubSubRubros")

      eventArgs.TotalRegistros = col.Count
      For Each en As Entidades.JSonEntidades.Archivos.SubSubRubroJSon In col
         Dim stbMensajeError As StringBuilder = New StringBuilder()

         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatos(eventArgs)
         If True Then
            If Not cache.ExisteSubRubro(en.IdSubRubro) Then
               'SubRubro en ALTA
               If GetCollection(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)(syncs).Any(Function(x) x.IdSubRubro = en.IdSubRubro) Then
                  en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la SubRubro con IdSubRubro = {0}.", en.IdSubRubro), "IdSubRubro")
               End If
            End If
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteSubRubro(en.IdSubRubro))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)

   End Function

   'transporte
   Public Overrides Function ImportarDatos(dt As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.SubSubRubros = New SqlServer.SubSubRubros(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("SubSubRubros")
         eventArgs.TotalRegistros = dt.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr As Entidades.JSonEntidades.Archivos.SubSubRubroJSon In dt
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatos(eventArgs)
            If dr.___Estado = "A" Then
               sql.SubSubRubros_I(dr.IdSubRubro,
                                  dr.IdSubSubRubro,
                                  dr.NombreSubSubRubro,
                                  dr.IdSubSubRubroTiendaNube,
                                  dr.IdSubSubRubroMercadoLibre, dr.IdSubSubRubroArborea)
            ElseIf dr.___Estado = "M" Then
               sql.SubSubRubros_U(dr.IdSubRubro,
                                  dr.IdSubSubRubro,
                                  dr.NombreSubSubRubro,
                                  dr.IdSubSubRubroTiendaNube,
                                  dr.IdSubSubRubroMercadoLibre, dr.IdSubSubRubroArborea)
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
            Publicos.WebArchivos.SubSubRubros.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      ImportarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)("DatosSyncronizados")))
   End Sub

   Public Function GetSubSubSubRubrosJsonTransporte(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon) = GetSubSubSubRubrosJson(fechaActualizacionDesde)
      Dim result As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.SubSubRubroJSon In datos
         Dim tEntidad As Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte
         tEntidad = New Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdSubRubro, jEntidad.FechaActualizacionWeb) 'Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas))
         tEntidad.DatosSubSubRubro = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

#End Region

End Class