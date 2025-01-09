#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On
Imports Eniac.Entidades.JSonEntidades
Imports Eniac.Entidades.JSonEntidades.Extensions
#End Region
Partial Class ProductosSucursalesPrecios

#Region "RestService & Json"
   Public Event AvanceValidarDatosProductosSucursalesPrecios(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosProductosSucursalesPrecios(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosProductosSucursalesPrecios(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosProductosSucursalesPrecios(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Public Overrides Function Convertir(transporte As List(Of Archivos.ProductoSucursalPrecioJSonTransporte)) As List(Of Archivos.ProductoSucursalPrecioJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)(dato.DatosProductoSucursalPrecio))
   End Function

   Public Function GetProductosSucursalesPreciosJSon(fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros, listaPrecioPublicarenWeb As Entidades.Publicos.SiNoTodos) As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon) = New List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)()

      Dim dt As DataTable = New SqlServer.ProductosSucursalesPrecios(da).ProductosSucursalesPrecios_GA(fechaActualizacionDesde, publicarEn,
                                                                                                       blnPreciosConIVA:=Publicos.PreciosConIVA, listaPrecioPublicarenWeb:=listaPrecioPublicarenWeb,
                                                                                                       soloTraeEstoyAca:=False, publicarEnWebSucursal:=Entidades.Publicos.SiNoTodos.SI,
                                                                                                       aplicarPreciosOferta:=False,
                                                                                                       soloProductosConStock:=False,
                                                                                                       productoActivo:=Nothing,
                                                                                                       productoModulo:=String.Empty)
      Dim o As Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdProducto = dr("IdProducto").ToString().Trim()
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         .IdListaPrecios = Integer.Parse(dr("IdListaPrecios").ToString())
         .PrecioVenta = Decimal.Parse(dr("PrecioVenta").ToString())
         .FechaActualizacion = DateTime.Parse(dr("FechaActualizacion").ToString()).ToString(AyudanteJson.FormatoFechas)
         .Usuario = dr("Usuario").ToString()

         .FechaActualizacionWeb = dr.Field(Of DateTime?)(Entidades.ProductoSucursalPrecio.Columnas.FechaActualizacionWeb.ToString()).IfNull().ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)
      End With
   End Sub

   Public Sub CargarJSonEnDataTable(productosSucursalesPreciosJson As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte), dt As DataTable)
      Dim dr As DataRow
      For Each transporte As Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte In productosSucursalesPreciosJson
         Dim productoSucursalPrecioJson As Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon
         productoSucursalPrecioJson = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)(transporte.DatosProductoSucursalPrecio)

         dr = dt.NewRow()
         Clientes.SeteaValor(dr, "CuitEmpresa", productoSucursalPrecioJson.CuitEmpresa, GetType(String))
         Clientes.SeteaValor(dr, "IdProducto", productoSucursalPrecioJson.IdProducto, GetType(String))
         Clientes.SeteaValor(dr, "IdSucursal", productoSucursalPrecioJson.IdSucursal, GetType(Integer))
         Clientes.SeteaValor(dr, "IdListaPrecios", productoSucursalPrecioJson.IdListaPrecios, GetType(Integer))

         Clientes.SeteaValor(dr, "PrecioVenta", productoSucursalPrecioJson.PrecioVenta, GetType(Decimal))
         Clientes.SeteaValor(dr, "FechaActualizacion", productoSucursalPrecioJson.FechaActualizacion, GetType(String))
         Clientes.SeteaValor(dr, "Usuario", productoSucursalPrecioJson.Usuario, GetType(String))

         Clientes.SeteaValor(dr, Entidades.ProductoSucursal.Columnas.FechaActualizacionWeb.ToString(), productoSucursalPrecioJson.FechaActualizacionWeb, GetType(String))

         Clientes.SeteaValor(dr, "DatosSyncronizados", productoSucursalPrecioJson, GetType(Object))

         productoSucursalPrecioJson.drOrigen = dr

         dt.Rows.Add(dr)
      Next
   End Sub

   Public Overrides Function ValidarDatos(col As List(Of Archivos.ProductoSucursalPrecioJSon), syncs As ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Precios")
      Dim cache = New BusquedasCacheadas()

      eventArgs.TotalRegistros = col.Count
      For Each en As Archivos.ProductoSucursalPrecioJSon In col
         Dim stbMensajeError = New StringBuilder()

         en.IdProducto = en.IdProducto.Trim()
         Dim productoEnAlta As Boolean = False
         productoEnAlta = GetCollection(Of Entidades.JSonEntidades.Archivos.ProductoJSon)(syncs).Any(Function(x) x.IdProducto = en.IdProducto And x.___Estado = "A")

         eventArgs.RegistroActual += 1
         OnAvanceValidarDatos(eventArgs)

         If Not productoEnAlta AndAlso Not cache.ExisteProductoPorIdRapido(en.IdProducto) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Producto con IdProducto = {0}.", en.IdProducto), "IdProducto")
         End If

         If Not cache.ExisteListaDePrecios(en.IdListaPrecios) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Lista de Precios con IdListaPrecios = {0}.", en.IdListaPrecios), "IdListaPrecios")
         End If

         If Not cache.ExisteSucursal(en.IdSucursal) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Sucursal con IdSucursal = {0}.", en.IdSucursal), "IdSucursal")
         End If

         If Not cache.ExisteUsuario(en.Usuario) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Usuario con Id = {0}.", en.Usuario), "Usuario")
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) productoEnAlta)
         If en.___Estado = "M" Then en.___Estado = "M/A"

         OnAvanceValidarDatos(eventArgs)

      Next

      Return CheckAlgunError(col)

   End Function

   Public Sub ValidarDatosPrecios(dt As DataTable, cache As BusquedasCacheadas, dtProductos As DataTable)

      ValidarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)("DatosSyncronizados")),
       New ServiciosRest.Sincronizacion.SyncBaseCollection().
            AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.ProductoJSon),
                                        dtProductos.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ProductoJSon)("DatosSyncronizados"))))
   End Sub

   Public Overrides Function ImportarDatos(transporte As List(Of Archivos.ProductoSucursalPrecioJSon)) As Boolean

      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sProductos As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Precios")
         eventArgs.TotalRegistros = transporte.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr As Archivos.ProductoSucursalPrecioJSon In transporte
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatos(eventArgs)
            If dr.___Estado = "A" Or dr.___Estado = "M" Or dr.___Estado = "M/A" Then
               Try
                  sProductos.ProductosSucursalesPrecios_M(dr.IdProducto,
                                                          dr.IdSucursal,
                                                          dr.IdListaPrecios,
                                                          dr.PrecioVenta,
                                                          dr.FechaActualizacion.ToDateTime().IfNull(Today),
                                                          dr.Usuario)

               Catch ex As Exception
                  If ex.Message.Contains("MERGE") AndAlso ex.Message.Contains("FOREIGN KEY 'FK_ProductosSucursalesPrecios_ProductosSucursales'") Then
                     Throw New Exception(String.Format("No se encuentra registro de Stock para el producto {0} en la sucursal {1}. Por favor marque DESCARGAR TODO en Stock para resolver esto.", dr.IdProducto, dr.IdSucursal), ex)
                  Else
                     Throw
                  End If
               End Try
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

         'Por las dudas lanzo la actualizacion de los precios de listas. Esto esta por si reactive un producto inactivo.
         Dim sqlPSP = New SqlServer.ProductosSucursalesPrecios(Me.da)
         sqlPSP.ProductosSucursalesPrecios_IFaltante(idProducto:=String.Empty, usuario:=actual.Nombre)


         If maximoFechaActualizacion.HasValue Then
            Publicos.WebArchivos.ProductosSucursalesPrecios.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Sub ImportarDesdeWebSigaPrecios(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      ImportarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)("DatosSyncronizados")))
   End Sub

   Public Function GetProductosSucursalesPreciosJSonTransporte(fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros, listaPrecioPublicarenWeb As Entidades.Publicos.SiNoTodos) As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon) = GetProductosSucursalesPreciosJSon(fechaActualizacionDesde, publicarEn, listaPrecioPublicarenWeb)
      Dim result As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon In datos
         Dim tProducto As Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte
         tProducto = New Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdProducto, jEntidad.IdSucursal, jEntidad.IdListaPrecios, jEntidad.FechaActualizacionWeb) 'Now.ToString(AyudanteJson.FormatoFechas))
         tProducto.DatosProductoSucursalPrecio = serializer.Serialize(jEntidad)
         result.Add(tProducto)
      Next

      Return result
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub
#End Region

End Class