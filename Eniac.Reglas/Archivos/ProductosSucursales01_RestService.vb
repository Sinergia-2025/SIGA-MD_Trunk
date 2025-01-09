#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On
Imports Eniac.Entidades.JSonEntidades
Imports Eniac.Entidades.JSonEntidades.Extensions
#End Region
Partial Class ProductosSucursales
#Region "RestService & Json"
   Public Event AvanceValidarDatosProductosSucursales(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosProductosSucursales(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosProductosSucursales(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosProductosSucursales(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Public Overrides Function Convertir(transporte As List(Of Archivos.ProductoSucursalJSonTransporte)) As List(Of Archivos.ProductoSucursalJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)(dato.DatosProductoSucursal))
   End Function

   Public Function GetProductosSucursalesJSon(fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon) = New List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)()

      Dim idListaPreciosPredeterminada As Integer = Publicos.ListaPreciosPredeterminada()

      Dim dt As DataTable = New SqlServer.ProductosSucursales(da).ProductosSucursales_GA(idListaPreciosPredeterminada, fechaActualizacionDesde, publicarEn, Entidades.Publicos.SiNoTodos.SI)
      Dim o As Entidades.JSonEntidades.Archivos.ProductoSucursalJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.ProductoSucursalJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.ProductoSucursalJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdProducto = dr("IdProducto").ToString().Trim()
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         .PrecioFabrica = Decimal.Parse(dr("PrecioFabrica").ToString())
         .PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())
         .Usuario = dr("Usuario").ToString()
         .FechaActualizacion = DateTime.Parse(dr("FechaActualizacion").ToString()).ToString(AyudanteJson.FormatoFechas)
         .Stock = Decimal.Parse(dr("Stock").ToString())
         .StockInicial = Decimal.Parse(dr("StockInicial").ToString())
         .PuntoDePedido = Decimal.Parse(dr("PuntoDePedido").ToString())
         .StockMinimo = Decimal.Parse(dr("StockMinimo").ToString())
         .StockMaximo = Decimal.Parse(dr("StockMaximo").ToString())
         .Ubicacion = dr("Ubicacion").ToString()

         .FechaActualizacionWeb = dr.Field(Of DateTime?)(Entidades.ProductoSucursal.Columnas.FechaActualizacionWeb.ToString()).IfNull().ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)

      End With
   End Sub

   Public Sub CargarJSonEnDataTable(productosSucursalesJson As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte), dt As DataTable)
      Dim dr As DataRow
      For Each transporte As Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte In productosSucursalesJson
         Dim productoSucursalJson As Entidades.JSonEntidades.Archivos.ProductoSucursalJSon
         productoSucursalJson = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)(transporte.DatosProductoSucursal)

         dr = dt.NewRow()
         Clientes.SeteaValor(dr, "CuitEmpresa", productoSucursalJson.CuitEmpresa, GetType(String))
         Clientes.SeteaValor(dr, "IdProducto", productoSucursalJson.IdProducto, GetType(String))
         Clientes.SeteaValor(dr, "IdSucursal", productoSucursalJson.IdSucursal, GetType(Integer))

         Clientes.SeteaValor(dr, "PrecioFabrica", productoSucursalJson.PrecioFabrica, GetType(Decimal))
         Clientes.SeteaValor(dr, "PrecioCosto", productoSucursalJson.PrecioCosto, GetType(Decimal))
         Clientes.SeteaValor(dr, "Usuario", productoSucursalJson.Usuario, GetType(String))
         Clientes.SeteaValor(dr, "FechaActualizacion", productoSucursalJson.FechaActualizacion, GetType(String))
         Clientes.SeteaValor(dr, "Stock", productoSucursalJson.Stock, GetType(Decimal))
         Clientes.SeteaValor(dr, "StockInicial", productoSucursalJson.StockInicial, GetType(Decimal))
         Clientes.SeteaValor(dr, "PuntoDePedido", productoSucursalJson.PuntoDePedido, GetType(Decimal))
         Clientes.SeteaValor(dr, "StockMinimo", productoSucursalJson.StockMinimo, GetType(Decimal))
         Clientes.SeteaValor(dr, "StockMaximo", productoSucursalJson.StockMaximo, GetType(Decimal))
         Clientes.SeteaValor(dr, "Ubicacion", productoSucursalJson.Ubicacion, GetType(String))

         Clientes.SeteaValor(dr, Entidades.ProductoSucursal.Columnas.FechaActualizacionWeb.ToString(), productoSucursalJson.FechaActualizacionWeb, GetType(String))

         Clientes.SeteaValor(dr, "DatosSyncronizados", productoSucursalJson, GetType(Object))

         productoSucursalJson.drOrigen = dr

         dt.Rows.Add(dr)
      Next
   End Sub

   Public Overrides Function ValidarDatos(col As List(Of Archivos.ProductoSucursalJSon), syncs As ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Stock")
      Dim cache = New BusquedasCacheadas()

      eventArgs.TotalRegistros = col.Count
      For Each en As Archivos.ProductoSucursalJSon In col
         Dim stbMensajeError = New StringBuilder()

         en.IdProducto = en.IdProducto.Trim()
         Dim productoEnAlta As Boolean = False
         productoEnAlta = GetCollection(Of Entidades.JSonEntidades.Archivos.ProductoJSon)(syncs).Any(Function(x) x.IdProducto = en.IdProducto And x.___Estado = "A")

         eventArgs.RegistroActual += 1
         OnAvanceValidarDatos(eventArgs)

         If Not productoEnAlta And Not cache.ExisteProductoPorIdRapido(en.IdProducto) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Producto con IdProducto = {0}.", en.IdProducto), "IdProducto")
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

   Public Overloads Sub ValidarDatos(dt As DataTable, cache As BusquedasCacheadas, dtProductos As DataTable)
      ValidarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)("DatosSyncronizados")),
             New ServiciosRest.Sincronizacion.SyncBaseCollection().
                  AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.ProductoJSon),
                                              dtProductos.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ProductoJSon)("DatosSyncronizados"))))
   End Sub

   Public Overrides Function ImportarDatos(transporte As List(Of Archivos.ProductoSucursalJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sProductos As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Stock")
         eventArgs.TotalRegistros = transporte.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
         For Each dr As Archivos.ProductoSucursalJSon In transporte
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatos(eventArgs)
            If dr.___Estado = "A" Or dr.___Estado = "M" Or dr.___Estado = "M/A" Then
               Dim idSucursal As Integer = dr.IdSucursal
               Dim actualizaStock As Boolean = Publicos.WebArchivos.ProductosSucursales.ActualizaStockEstoyAca OrElse Not cache.BuscaSucursal(idSucursal).EstoyAca
               sProductos.ProductosSucursales_M(dr.IdProducto,
                                                idSucursal,
                                                dr.PrecioFabrica,
                                                dr.PrecioCosto,
                                                dr.Stock,
                                                dr.PuntoDePedido,
                                                dr.StockInicial,
                                                dr.StockMinimo,
                                                dr.StockMaximo,
                                                dr.Usuario,
                                                dr.FechaActualizacion.ToDateTime().IfNull(Today),
                                                dr.Ubicacion,
                                                actualizaStock)
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
            Publicos.WebArchivos.ProductosSucursales.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      ImportarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)("DatosSyncronizados")))
   End Sub

   Public Function GetProductosSucursalesJSonTransporte(fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon) = GetProductosSucursalesJSon(fechaActualizacionDesde, publicarEn)
      Dim result As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.ProductoSucursalJSon In datos
         Dim tProducto As Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte
         tProducto = New Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdProducto, jEntidad.IdSucursal, jEntidad.FechaActualizacionWeb) 'Now.ToString(AyudanteJson.FormatoFechas))
         tProducto.DatosProductoSucursal = serializer.Serialize(jEntidad)
         result.Add(tProducto)
      Next

      Return result
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

#End Region

End Class