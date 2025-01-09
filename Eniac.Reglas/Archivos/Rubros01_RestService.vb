#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports Eniac.Reglas.ServiciosRest.Sincronizacion
#End Region
Partial Class Rubros

#Region "RestService & Json"
   Public Event AvanceValidarDatosRubros(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosRubros(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Public Function GetRubrosJSon(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.RubroJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.RubroJSon) = New List(Of Entidades.JSonEntidades.Archivos.RubroJSon)()

      Dim dt As DataTable = New SqlServer.Rubros(da).Rubros_GA(fechaActualizacionDesde)
      Dim o As Entidades.JSonEntidades.Archivos.RubroJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.RubroJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.RubroJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdRubro = Integer.Parse(dr(Entidades.Rubro.Columnas.IdRubro.ToString()).ToString())
         .NombreRubro = dr(Entidades.Rubro.Columnas.NombreRubro.ToString()).ToString()

         .IdProvincia = dr(Entidades.Rubro.Columnas.IdProvincia.ToString()).ToString()
         If IsNumeric(dr(Entidades.Rubro.Columnas.IdActividad.ToString())) Then
            .IdActividad = Integer.Parse(dr(Entidades.Rubro.Columnas.IdActividad.ToString()).ToString())
         End If
         .ComisionPorVenta = Decimal.Parse(dr(Entidades.Rubro.Columnas.ComisionPorVenta.ToString()).ToString())
         .UnidHasta1 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta1.ToString()).ToString())
         .UnidHasta2 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta2.ToString()).ToString())
         .UnidHasta3 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta3.ToString()).ToString())
         .UnidHasta4 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta4.ToString()).ToString())
         .UnidHasta5 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta5.ToString()).ToString())
         If IsNumeric(dr(Entidades.Rubro.Columnas.UHPorc1.ToString())) Then
            .UHPorc1 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc1.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Rubro.Columnas.UHPorc2.ToString())) Then
            .UHPorc2 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc2.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Rubro.Columnas.UHPorc3.ToString())) Then
            .UHPorc3 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc3.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Rubro.Columnas.UHPorc4.ToString())) Then
            .UHPorc4 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc4.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Rubro.Columnas.UHPorc5.ToString())) Then
            .UHPorc5 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc5.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Rubro.Columnas.Orden.ToString())) Then
            .Orden = Integer.Parse(dr(Entidades.Rubro.Columnas.Orden.ToString()).ToString())
         End If

         .FechaActualizacionWeb = dr.Field(Of DateTime?)(Entidades.Rubro.Columnas.FechaActualizacionWeb.ToString()).IfNull().ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)

         If IsNumeric(dr(Entidades.Rubro.Columnas.DescuentoRecargoPorc1.ToString())) Then
            .DescuentoRecargoPorc1 = Decimal.Parse(dr(Entidades.Rubro.Columnas.DescuentoRecargoPorc1.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Rubro.Columnas.DescuentoRecargoPorc2.ToString())) Then
            .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.Rubro.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
         End If

         .IdRubroTiendaNube = dr.Field(Of String)(Entidades.Rubro.Columnas.IdRubroTiendaNube.ToString())
         .IdRubroMercadoLibre = dr.Field(Of String)(Entidades.Rubro.Columnas.IdRubroMercadoLibre.ToString())

         .CodigoExportacion = dr.Field(Of String)(Entidades.Rubro.Columnas.CodigoExportacion.ToString())
      End With
   End Sub

   Public Sub CargarJSonEnDataTable(entidadesJSon As List(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte), dt As DataTable)
      Dim dr As DataRow
      For Each transporte As Entidades.JSonEntidades.Archivos.RubroJSonTransporte In entidadesJSon
         Dim entidadJSon As Entidades.JSonEntidades.Archivos.RubroJSon
         entidadJSon = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.RubroJSon)(transporte.DatosRubro)

         dr = dt.NewRow()
         Clientes.SeteaValor(dr, "CuitEmpresa", entidadJSon.CuitEmpresa, GetType(String))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.IdRubro.ToString(), entidadJSon.IdRubro, GetType(Integer))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.NombreRubro.ToString(), entidadJSon.NombreRubro, GetType(String))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.IdProvincia.ToString(), entidadJSon.IdProvincia, GetType(String))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.IdActividad.ToString(), entidadJSon.IdActividad, GetType(Integer))

         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.ComisionPorVenta.ToString(), entidadJSon.ComisionPorVenta, GetType(Decimal))

         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UnidHasta1.ToString(), entidadJSon.UnidHasta1, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UnidHasta2.ToString(), entidadJSon.UnidHasta2, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UnidHasta3.ToString(), entidadJSon.UnidHasta3, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UnidHasta4.ToString(), entidadJSon.UnidHasta4, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UnidHasta5.ToString(), entidadJSon.UnidHasta5, GetType(Decimal))

         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UHPorc1.ToString(), entidadJSon.UHPorc1, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UHPorc2.ToString(), entidadJSon.UHPorc2, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UHPorc3.ToString(), entidadJSon.UHPorc3, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UHPorc4.ToString(), entidadJSon.UHPorc4, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.UHPorc5.ToString(), entidadJSon.UHPorc5, GetType(Decimal))

         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.Orden.ToString(), entidadJSon.Orden, GetType(Integer))

         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.FechaActualizacionWeb.ToString(), entidadJSon.FechaActualizacionWeb, GetType(String))

         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.DescuentoRecargoPorc1.ToString(), entidadJSon.DescuentoRecargoPorc1, GetType(Decimal))
         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.DescuentoRecargoPorc2.ToString(), entidadJSon.DescuentoRecargoPorc2, GetType(Decimal))

         Clientes.SeteaValor(dr, Entidades.Rubro.Columnas.CodigoExportacion.ToString(), entidadJSon.CodigoExportacion, GetType(String))

         Clientes.SeteaValor(dr, "DatosSyncronizados", entidadJSon, GetType(Object))

         entidadJSon.drOrigen = dr

         dt.Rows.Add(dr)
      Next
   End Sub

   Public Overloads Sub ValidarDatos(dt As DataTable)
      ValidarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.RubroJSon)("DatosSyncronizados")), Nothing)
   End Sub

   Private Overloads Function ValidarDatos(en As Entidades.JSonEntidades.Archivos.RubroJSon, cache As BusquedasCacheadas) As Boolean
      Dim stbMensajeError As StringBuilder = New StringBuilder()

      If True Then
         If Not String.IsNullOrEmpty(en.IdProvincia) AndAlso Not cache.ExisteProvincia(en.IdProvincia) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Provincia con IdProvincia = {0}.", en.IdProvincia), "IdProvincia")
         End If
      End If

      SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteRubro(x.IdRubro))

      'If en.ConErrores Then
      '   en.___Estado = "E"
      '   en.___MensajeError = stbMensajeError.ToString()
      '   If en.drOrigen IsNot Nothing Then
      '      en.drOrigen("___estado") = "E"
      '      en.drOrigen("___mensajeError") = en.___MensajeError
      '   End If
      'Else
      '   If cache.ExisteRubro(en.IdRubro) Then
      '      en.___Estado = "M"
      '      If en.drOrigen IsNot Nothing Then en.drOrigen("___estado") = "M"
      '   Else
      '      en.___Estado = "A"
      '      If en.drOrigen IsNot Nothing Then en.drOrigen("___estado") = "A"
      '   End If
      'End If

   End Function

   Public Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.RubroJSon), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Rubros")

      eventArgs.TotalRegistros = col.Count
      For Each en As Entidades.JSonEntidades.Archivos.RubroJSon In col
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceImportarDatos(eventArgs)
         ValidarDatos(en, cache)
         OnAvanceImportarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)

   End Function
   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.RubroJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.RubroJSon)(dato.DatosRubro))
   End Function

   Public Overrides Function ImportarDatos(dt As List(Of Entidades.JSonEntidades.Archivos.RubroJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sClientes As SqlServer.Rubros = New SqlServer.Rubros(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Rubros")
         eventArgs.TotalRegistros = dt.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr As Entidades.JSonEntidades.Archivos.RubroJSon In dt
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatos(eventArgs)
            If dr.___Estado = "A" Then
               sClientes.Rubros_I(dr.IdRubro,
                                  dr.NombreRubro,
                                  dr.IdProvincia,
                                  dr.IdActividad.IfNull(),
                                  dr.ComisionPorVenta,
                                  dr.UnidHasta1, dr.UnidHasta2, dr.UnidHasta3, dr.UnidHasta4, dr.UnidHasta5,
                                  dr.UHPorc1.IfNull(), dr.UHPorc2.IfNull(), dr.UHPorc3.IfNull(), dr.UHPorc4.IfNull(), dr.UHPorc5.IfNull(),
                                  Convert.ToInt32(dr.Orden),
                                  dr.DescuentoRecargoPorc1, dr.DescuentoRecargoPorc2, dr.CodigoExportacion, dr.IdRubroTiendaNube, dr.IdRubroMercadoLibre, dr.IdRubroArborea)
            ElseIf dr.___Estado = "M" Then
               sClientes.Rubros_U(dr.IdRubro,
                                  dr.NombreRubro,
                                  dr.IdProvincia,
                                  dr.IdActividad.IfNull(),
                                  dr.ComisionPorVenta,
                                  dr.UnidHasta1, dr.UnidHasta2, dr.UnidHasta3, dr.UnidHasta4, dr.UnidHasta5,
                                  dr.UHPorc1.IfNull(), dr.UHPorc2.IfNull(), dr.UHPorc3.IfNull(), dr.UHPorc4.IfNull(), dr.UHPorc5.IfNull(),
                                  Convert.ToInt32(dr.Orden),
                                  dr.DescuentoRecargoPorc1, dr.DescuentoRecargoPorc2, dr.CodigoExportacion, dr.IdRubroTiendaNube, dr.IdRubroMercadoLibre, dr.IdRubroArborea)
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
            Publicos.WebArchivos.Rubros.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      ImportarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.RubroJSon)("DatosSyncronizados")))
   End Sub

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosRubros(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosRubros(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Public Function GetRubrosJSonTransporte(fechaActualizacionDesde As DateTime?) As List(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.RubroJSon) = GetRubrosJSon(fechaActualizacionDesde)
      Dim result As List(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.RubroJSon In datos
         Dim tEntidad As Entidades.JSonEntidades.Archivos.RubroJSonTransporte
         tEntidad = New Entidades.JSonEntidades.Archivos.RubroJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdRubro, jEntidad.FechaActualizacionWeb) 'Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas))
         tEntidad.DatosRubro = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

#End Region

End Class