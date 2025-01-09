#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Partial Class SubRubros
#Region "RestService & Json"
   Public Event AvanceValidarDatosSubRubros(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosSubRubros(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Public Function GetSubRubrosJSon(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSon) = New List(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)()

      Dim dt As DataTable = New SqlServer.SubRubros(da).SubRubros_GA(fechaActualizacionDesde, idRubro:=0, rubros:=Nothing)
      Dim o As Entidades.JSonEntidades.Archivos.SubRubroJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.SubRubroJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.SubRubroJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdSubRubro = Integer.Parse(dr(Entidades.SubRubro.Columnas.IdSubRubro.ToString()).ToString())
         .NombreSubRubro = dr(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()).ToString()
         .DescuentoRecargoPorc1 = Decimal.Parse(dr(Entidades.SubRubro.Columnas.DescuentoRecargoPorc1.ToString()).ToString())
         .IdRubro = Integer.Parse(dr(Entidades.SubRubro.Columnas.IdRubro.ToString()).ToString())

         .UnidHasta1 = Integer.Parse(dr(Entidades.SubRubro.Columnas.UnidHasta1.ToString()).ToString())
         .UnidHasta2 = Integer.Parse(dr(Entidades.SubRubro.Columnas.UnidHasta2.ToString()).ToString())
         .UnidHasta3 = Integer.Parse(dr(Entidades.SubRubro.Columnas.UnidHasta3.ToString()).ToString())
         .UnidHasta4 = Integer.Parse(dr(Entidades.SubRubro.Columnas.UnidHasta4.ToString()).ToString())
         .UnidHasta5 = Integer.Parse(dr(Entidades.SubRubro.Columnas.UnidHasta5.ToString()).ToString())
         .UHPorc1 = Decimal.Parse(dr(Entidades.SubRubro.Columnas.UHPorc1.ToString()).ToString())
         .UHPorc2 = Decimal.Parse(dr(Entidades.SubRubro.Columnas.UHPorc2.ToString()).ToString())
         .UHPorc3 = Decimal.Parse(dr(Entidades.SubRubro.Columnas.UHPorc3.ToString()).ToString())
         .UHPorc4 = Decimal.Parse(dr(Entidades.SubRubro.Columnas.UHPorc4.ToString()).ToString())
         .UHPorc5 = Decimal.Parse(dr(Entidades.SubRubro.Columnas.UHPorc5.ToString()).ToString())

         .FechaActualizacionWeb = dr.Field(Of DateTime?)(Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString()).IfNull().ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)

         .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.SubRubro.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
         .IdSubRubroTiendaNube = dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroTiendaNube.ToString())
         .IdSubRubroMercadoLibre = dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroMercadoLibre.ToString())

         .CodigoExportacion = dr.Field(Of String)(Entidades.SubRubro.Columnas.CodigoExportacion.ToString())
      End With
   End Sub

   Public Sub CargarJSonEnDataTable(jEntidades As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte), dt As DataTable)
      Dim dr As DataRow
      For Each transporte As Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte In jEntidades
         Dim jEntidad As Entidades.JSonEntidades.Archivos.SubRubroJSon
         jEntidad = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)(transporte.DatosSubRubro)

         dr = dt.NewRow()
         Clientes.SeteaValor(dr, "CuitEmpresa", jEntidad.CuitEmpresa, GetType(String))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.IdSubRubro.ToString(), jEntidad.IdSubRubro, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.NombreSubRubro.ToString(), jEntidad.NombreSubRubro, GetType(String))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.DescuentoRecargoPorc1.ToString(), jEntidad.DescuentoRecargoPorc1, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.IdRubro.ToString(), jEntidad.IdRubro, GetType(Integer))

         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UnidHasta1.ToString(), jEntidad.UnidHasta1, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UnidHasta2.ToString(), jEntidad.UnidHasta2, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UnidHasta3.ToString(), jEntidad.UnidHasta3, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UnidHasta4.ToString(), jEntidad.UnidHasta4, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UnidHasta5.ToString(), jEntidad.UnidHasta5, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UHPorc1.ToString(), jEntidad.UHPorc1, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UHPorc2.ToString(), jEntidad.UHPorc2, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UHPorc3.ToString(), jEntidad.UHPorc3, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UHPorc4.ToString(), jEntidad.UHPorc4, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.UHPorc5.ToString(), jEntidad.UHPorc5, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.IdSubRubroTiendaNube.ToString(), jEntidad.IdSubRubroTiendaNube, GetType(String))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.IdSubRubroMercadoLibre.ToString(), jEntidad.IdSubRubroMercadoLibre, GetType(String))

         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString(), jEntidad.FechaActualizacionWeb, GetType(String))
         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.DescuentoRecargoPorc2.ToString(), jEntidad.DescuentoRecargoPorc2, GetType(Decimal))

         Clientes.SeteaValor(dr, Entidades.SubRubro.Columnas.CodigoExportacion.ToString(), jEntidad.CodigoExportacion, GetType(String))

         Clientes.SeteaValor(dr, "DatosSyncronizados", jEntidad, GetType(Object))
         jEntidad.drOrigen = dr

         dt.Rows.Add(dr)
      Next
   End Sub

   Public Overloads Sub ValidarDatos(dtSubRubros As DataTable, dtRubro As DataTable)
      ValidarDatos(dtSubRubros.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)("DatosSyncronizados")),
                   New ServiciosRest.Sincronizacion.SyncBaseCollection().
                        AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.RubroJSon),
                                                    dtRubro.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.RubroJSon)("DatosSyncronizados"))))
   End Sub

   Private Overloads Function ValidarDatos(en As Entidades.JSonEntidades.Archivos.SubRubroJSon, cache As BusquedasCacheadas, syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim stbMensajeError As StringBuilder = New StringBuilder()

      If True Then
         If Not cache.ExisteRubro(en.IdRubro) Then
            'Rubro en ALTA
            If GetCollection(Of Entidades.JSonEntidades.Archivos.RubroJSon)(syncs).Any(Function(x) x.IdRubro = en.IdRubro) Then
               en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Rubro con IdRubro = {0}.", en.IdRubro), "IdRubro")
            End If
         End If
      End If

      SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteSubRubro(x.IdSubRubro))

      'If en.ConErrores Then
      '   en.___Estado = "E"
      '   en.___MensajeError = stbMensajeError.ToString()
      '   If en.drOrigen IsNot Nothing Then
      '      en.drOrigen("___estado") = "E"
      '      en.drOrigen("___mensajeError") = en.___MensajeError
      '   End If
      'Else
      '   If cache.ExisteSubRubro(en.IdSubRubro) Then
      '      en.___Estado = "M"
      '      If en.drOrigen IsNot Nothing Then en.drOrigen("___estado") = "M"
      '   Else
      '      en.___Estado = "A"
      '      If en.drOrigen IsNot Nothing Then en.drOrigen("___estado") = "A"
      '   End If
      'End If

      Return Not en.ConErrores

   End Function

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)(dato.DatosSubRubro))
   End Function
   Public Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSon), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("SubRubros")

      eventArgs.TotalRegistros = col.Count
      For Each en As Entidades.JSonEntidades.Archivos.SubRubroJSon In col
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceImportarDatos(eventArgs)
         ValidarDatos(en, cache, syncs)
         OnAvanceImportarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)

   End Function

   Public Overrides Function ImportarDatos(dt As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.SubRubros = New SqlServer.SubRubros(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("SubRubros")
         eventArgs.TotalRegistros = dt.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr As Entidades.JSonEntidades.Archivos.SubRubroJSon In dt
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            RaiseEvent AvanceImportarDatosSubRubros(Me, eventArgs)
            If dr.___Estado = "A" Then
               sql.SubRubros_I(dr.IdRubro,
                               dr.IdSubRubro,
                               dr.NombreSubRubro,
                               dr.DescuentoRecargoPorc1,
                               dr.UnidHasta1, dr.UnidHasta2, dr.UnidHasta3, dr.UnidHasta4, dr.UnidHasta5,
                               dr.UHPorc1, dr.UHPorc2, dr.UHPorc3, dr.UHPorc4, dr.UHPorc5,
                               dr.DescuentoRecargoPorc2, dr.CodigoExportacion,
                               dr.IdSubRubroTiendaNube, dr.IdSubRubroMercadoLibre, dr.IdSubRubroArborea, grupoAtributo01:=Nothing, tipoAtributo01:=Nothing,
                               grupoAtributo02:=Nothing, tipoAtributo02:=Nothing, grupoAtributo03:=Nothing, tipoAtributo03:=Nothing, grupoAtributo04:=Nothing, tipoAtributo04:=Nothing)
            ElseIf dr.___Estado = "M" Then
               sql.SubRubros_U(dr.IdRubro,
                               dr.IdSubRubro,
                               dr.NombreSubRubro,
                               dr.DescuentoRecargoPorc1,
                               dr.UnidHasta1, dr.UnidHasta2, dr.UnidHasta3, dr.UnidHasta4, dr.UnidHasta5,
                               dr.UHPorc1, dr.UHPorc2, dr.UHPorc3, dr.UHPorc4, dr.UHPorc5,
                               dr.DescuentoRecargoPorc2, dr.CodigoExportacion,
                               dr.IdSubRubroTiendaNube, dr.IdSubRubroMercadoLibre, dr.IdSubRubroArborea, grupoAtributo01:=Nothing, tipoAtributo01:=Nothing,
                               grupoAtributo02:=Nothing, tipoAtributo02:=Nothing, grupoAtributo03:=Nothing, tipoAtributo03:=Nothing, grupoAtributo04:=Nothing, tipoAtributo04:=Nothing)
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

         Next
         If maximoFechaActualizacion.HasValue Then
            Publicos.WebArchivos.SubRubros.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      ImportarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)("DatosSyncronizados")))
   End Sub

   Public Function GetSubRubrosJSonTransporte(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSon) = GetSubRubrosJSon(fechaActualizacionDesde)
      Dim result As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.SubRubroJSon In datos
         Dim tEntidad As Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte
         tEntidad = New Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdSubRubro, jEntidad.FechaActualizacionWeb) 'Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas))
         tEntidad.DatosSubRubro = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

#End Region

End Class