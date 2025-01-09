Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Namespace ServiciosRest.TiendasWeb
   Public Class SincronizacionTiendaNube
      Inherits Base

#Region "Propiedades"
      Private Property TiendaNubeURLBase As Uri
      Private Property TiendaNubeListaDePrecios As Integer
      Private Property TiendaNubeCategoriaCliente As Integer
      Private Property TiendaNubeCategoriaFiscalCliente As Integer
      Private Property RestResponse As String
      Private Property _reenviarTodo As Boolean
      Private Property _rebajarTodo As Boolean

      Private Property _nuevosProductos As Integer
      Private Property _productosActualizados As Integer

      Public Event Avance(sender As Object, e As SincronizacionTiendaWebEventArgs)
      Public Event Estado(sender As Object, e As SincronizacionTiendaWebEstadoEventArgs)
      Public Event ProcesoFinalizado(sender As Object, e As SincronizacionTiendaWebProcesoFinalizadoEventArgs)
      Public Event InformarError(sender As Object, e As SincronizacionTiendaWebErrorEventArgs)

#End Region

#Region "Constructors"
      Private Sub New(accesoDatos As Datos.DataAccess)
         da = accesoDatos
      End Sub
      Public Sub New()
         Me.New(New Datos.DataAccess())
         If Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeURLBase) Then
            Me.TiendaNubeURLBase = New Uri(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeURLBase)
         Else
            Throw New Exception("ATENCIÓN: La URL Base para Tienda Nube no se encuentra configurada.")
         End If

         If String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeToken) Then
            Throw New Exception("ATENCIÓN: No hay un Token configurado.")
         End If
      End Sub
#End Region

#Region "Methods"
      Private Sub TriggerEvent(sincroEstado As SincroTiendaWebEstados, verb As SincroTiendaWebMetodos, totalRegistros As Integer, nroRegistroSubiendo As Integer, queEstoySubiendo As String, countExitosos As Integer, countError As Integer)
         RaiseEvent Estado(Me, New SincronizacionTiendaWebEstadoEventArgs(Entidades.TiendasWeb.TIENDANUBE, sincroEstado, verb, totalRegistros, nroRegistroSubiendo, queEstoySubiendo, countExitosos, countError))
      End Sub

      Protected Sub OnInformarError(elementoTransmitido As String, mensaje As String)
         RaiseEvent InformarError(Me, New SincronizacionTiendaWebErrorEventArgs(Entidades.TiendasWeb.TIENDANUBE, elementoTransmitido, mensaje))
      End Sub

      Public Function ReporteDeErrores() As String
         Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb
         Dim reporteError As StringBuilder = New StringBuilder

         Dim dt = rPTW.GetPedidosAImportar("TIENDANUBE", {"ERROR"}, Nothing, desde:=Nothing, hasta:=Nothing, tipoFechaFiltro:=Nothing) '# Obtengo todos los pedidos que tienen algun tipo de error y no pudieron procesarse 

         If dt.Rows.Count = 0 Then Return Nothing '# Si no hay errores, no envio ningun reporte.

         With reporteError
            .AppendFormatLine("*** Se encontraron los siguientes ERRORES en el Proceso de Bajada de Pedidos de Tienda Nube ***")
            .AppendFormatLine("<br>")
            For Each dr As DataRow In dt.Rows
               .AppendFormatLine("<br>  >> Id Pedido (Tienda Nube): {0}", dr.Field(Of String)("Id"))
               .AppendFormatLine("<br>  >> Número Pedido: {0}", dr.Field(Of Long)("Numero"))
               .AppendFormatLine("<br>  >> Cliente: {0}", dr.Field(Of String)("NombreClienteTiendaWeb"))
               .AppendFormatLine("<br>  >> Fecha Pedido: {0}", dr.Field(Of DateTime)("FechaPedido"))
               .AppendFormatLine("<br>  >> Fecha Descarga: {0}", dr.Field(Of DateTime)("FechaDescarga"))
               .AppendFormatLine("<br>  >> Usuario de Descarga: {0}", dr.Field(Of String)("IdUsuarioDescarga"))
               .AppendFormatLine("<br>  >> ERROR: {0}", dr.Field(Of String)("MensajeError"))
               .AppendFormatLine("<br>")
               .AppendFormatLine("<br>")
            Next
         End With
         Return reporteError.ToString()
      End Function

      Public Sub SubirInformacion(reenviarTodo As Boolean, sincronizaCategorias As Boolean, sincronizaProductos As Boolean, publicarPrecioPorEmbalaje As Boolean)
         _reenviarTodo = reenviarTodo

         '# Validación de Token
         '--------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Validando Token..."))
         My.Application.Log.WriteEntry("Validando Token..", TraceEventType.Verbose)
         '--------------------------
         If String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeToken) Then
            My.Application.Log.WriteEntry("Token vacio.", TraceEventType.Verbose)
         Else
            '# Obtengo los Rubros a enviar
            If sincronizaCategorias Then SubirCategorias()
            '# Obtengo los Productos a enviar
            If sincronizaProductos Then SubirProductos(publicarPrecioPorEmbalaje)
         End If

      End Sub

      Public Sub BajarInformacion(bajarTodo As Boolean)
         _rebajarTodo = bajarTodo

         '# Bajo los pedidos de tienda nube
         BajarPedidos()
         '--------------------------

      End Sub
      Private Sub BajarPedidos()
         EjecutaConConexion(Sub() _BajarPedidos())
      End Sub
      Private Sub SubirCategorias()
         EjecutaConConexion(Sub() _SubirCategorias())
      End Sub
      Private Sub SubirProductos(PublicarPrecioPorEmbalaje As Boolean)
         EjecutaConConexion(Sub() _SubirProductos(PublicarPrecioPorEmbalaje))
      End Sub

      Private Function GetEndpoint(control As String, id As String) As String
         Dim stb = New StringBuilder(control)
         If id IsNot Nothing Then stb.AppendFormat("/{0}", id)

         Return stb.ToString()
      End Function

      Private Function GetIdCategoriaPadre(dr As DataRow) As Integer
         '# IdSubSubRubroTiendaNube >> IdSubRubroTiendaNube >> IdRubroTiendaNube 
         If Not String.IsNullOrEmpty(dr((Entidades.SubSubRubro.Columnas.IdSubSubRubroTiendaNube.ToString())).ToString()) Then
            Return CInt(dr.Field(Of String)(Entidades.SubSubRubro.Columnas.IdSubSubRubroTiendaNube.ToString()))
         ElseIf Not String.IsNullOrEmpty(dr((Entidades.SubRubro.Columnas.IdSubRubroTiendaNube.ToString())).ToString()) Then
            Return CInt(dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroTiendaNube.ToString()))
         Else
            Return CInt(dr.Field(Of String)(Entidades.Rubro.Columnas.IdRubroTiendaNube.ToString()))
         End If
      End Function

      Private Sub _BajarPedidos()
         '--------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Obteniendo información de los Pedidos..."))
         '--------------------------
         Dim serializer = New JavaScriptSerializer()

         '# since_id >> Obtengo los Pedidos posteriores al último registrado en el sistema. En caso de reBajar todos, traigo todos
         Dim rPedidosTiendasWeb As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb(da)
         Dim since_id As Long = 0
         Dim sistemaDestino As String = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString()
         If Not _rebajarTodo Then since_id = rPedidosTiendasWeb.GetMaxId(sistemaDestino)

         '# Creo los parámetros asociados al GET
         My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - Parámetros de la Request: fields=id&since_id={0}&status=open.", since_id.ToString()), TraceEventType.Verbose)
         Dim params As Dictionary(Of String, String) = New Dictionary(Of String, String)
         params.Add("fields", "id") '# Este parámetro es para obtener SOLO los IDs de los nuevos pedidos
         params.Add("since_id", since_id.ToString()) '# Este parámetro es para obtener todos los pedidos a partir de este (incluyendolo)
         params.Add("status", "open") '# Traigo solo los pedidos con estado "OPEN"

         '# Primero obtengo todos los IDs de los nuevos pedidos
         My.Application.Log.WriteEntry("SubidaTiendaNube.Ejecutar - Obteniendo IDs de Nuevos Pedidos.", TraceEventType.Verbose)
         Dim response = GETResponse(Of List(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.PedidosTN))(Me.GetHeaders(), Me.SetURLParameters(GetEndpoint(Controls.orders.ToString(), String.Empty), params))

         '--------------------------
         If response.Count > 0 Then RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Bajando pedidos..."))
         '--------------------------

         My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - {0} Pedidos (posibles) por bajar.", response.Where(Function(x) x.id <> since_id).Count), TraceEventType.Verbose)

         '# Luego por cada uno de los pedidos obtenidos realizo un GET por separado para obtenerlos individualmente y poder guardar su JSON como auditoría.
         Dim ePTW As Entidades.PedidoTiendaWeb
         Dim count As Integer = 0
         For Each pedido As Entidades.JSonEntidades.TiendasWeb.TiendaNube.PedidosTN In response.Where(Function(x) x.id <> since_id)

            '# Si el pedido ya esta grabado, no lo voy a buscar.
            If rPedidosTiendasWeb.ExistePedido(pedido.id.ToString(), sistemaDestino) Then Continue For

            count += 1
            ePTW = New Entidades.PedidoTiendaWeb

            My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - Obteniendo Pedido {0}.", pedido.id), TraceEventType.Verbose)
            Dim p = GETResponse(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.PedidosTN)(Me.GetHeaders(), GetEndpoint(Controls.orders.ToString(), pedido.id.ToString()))
            TriggerEvent(SincroTiendaWebEstados.Bajando, SincroTiendaWebMetodos.GET, response.Count, count, "PEDIDOS", 0, 0)

            '# Vuelvo a serializar el JSON y me lo guardo como auditoría
            Dim jsonString As String = serializer.Serialize(p)

            With ePTW
               .Id = p.id.ToString()
               .SistemaDestino = sistemaDestino
               .Numero = p.number
               .IdClienteTiendaWeb = p.customer.id
               .NombreClienteTiendaWeb = p.customer.name.Truncar(100)
               .ObservacionesTiendaWeb = p.note.Truncar(200)
               .IdMoneda = p.currency
               .TipoEnvio = p.shipping_pickup_type
               If .TipoEnvio = "ship" AndAlso p.shipping_address IsNot Nothing Then
                  .DireccionEnvio = String.Concat(p.shipping_address.address, " ", p.shipping_address.number, " ", p.shipping_address.city, " ", p.shipping_address.province)
                  .CostoEnvio = p.shipping_cost_customer
               End If
               .FechaPedido = p.created_at
               .ImporteTotal = p.total
               .SubTotal = p.subtotal
               .IdUsuarioEstado = actual.Nombre
               .FechaEstado = Now
               .IdUsuarioDescarga = actual.Nombre
               .FechaDescarga = Now
               .IdEstadoPedidoTiendaWeb = "PENDIENTE" '# Los pedidos quedan inicialmente con estado "PENDIENTE"
               .JSON = jsonString
               .NroDocCliente = If(Not String.IsNullOrEmpty(p.customer.identification), Convert.ToInt64(p.customer.identification), 0L)
               .Email = p.customer.email
               .Telefono = p.customer.phone
               .CodigoPostal = If(p.billing_zipcode.HasValue, p.billing_zipcode, 0)
               .DireccionCalle = p.billing_address
               .DireccionNumero = p.billing_number
               .Adicional = p.billing_floor
               .Localidad = p.billing_city
               .Provincia = p.billing_province
            End With

            '# Productos
            Dim ePPTW As Entidades.PedidoProductoTiendaWeb
            For Each pr As Entidades.JSonEntidades.TiendasWeb.TiendaNube.PedidoProductoTN In p.products
               ePPTW = New Entidades.PedidoProductoTiendaWeb
               With ePPTW
                  .Id = p.id.ToString()
                  .SistemaDestino = sistemaDestino
                  .Numero = p.number
                  .IdProductoTiendaWeb = pr.product_id
                  .NombreProductoTiendaWeb = pr.name
                  .Precio = pr.price
                  .Cantidad = pr.quantity

                  ePTW.Productos.Add(ePPTW)
               End With
            Next

            '# Guardo el pedido en mi tabla de PedidosTiendasWeb (Tabla de Pedidos intermedia entre el SIGA y la Web)
            My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - Grabando Pedido {0}.", pedido.id), TraceEventType.Verbose)

            rPedidosTiendasWeb._Inserta(ePTW, soloTransaccion:=True)

            My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - Pedido {0} grabado correctamente.", pedido.id), TraceEventType.Verbose)
         Next

         '# Si no se descargo un nuevo pedido, muestro en pantalla el mensaje
         '--------------------------
         If count = 0 Then
            RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "No hay pedidos para bajar."))
            My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - No hay pedidos para bajar."), TraceEventType.Information)
         End If
         '--------------------------

      End Sub

      Private Sub _SubirProductos(PublicarPrecioPorEmbalaje As Boolean)
         '--------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Obteniendo información de los Productos..."))
         My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Comenzando la Subida de Productos."), TraceEventType.Information)
         '--------------------------

         _nuevosProductos = 0
         _productosActualizados = 0

         Dim serializer = New JavaScriptSerializer()

         Dim rProductos = New Productos(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)

         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString())

         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                       .Tabla = Entidades.Producto.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })


         Using dt = rProductos.GetProductosTiendaWeb(_reenviarTodo, Entidades.TiendasWeb.TIENDANUBE, PublicarPrecioPorEmbalaje)
            Try
               Dim count As Integer = 0
               Dim countExitoso As Integer = 0
               Dim countError As Integer = 0

               My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - {0} Productos por subir desde la Última Sincronización.", dt.Rows.Count), TraceEventType.Verbose)

               Dim cotizacion = New Reglas.Monedas().GetUna(2).FactorConversion
               Dim tipo = Reglas.Publicos.PrecioProductoTN

               '# Productos
               For Each dr As DataRow In dt.Rows
                  Try
                     Dim id_producto_tiendanube As String = dr.Field(Of String)(Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN.Campos.id.ToString())
                     If String.IsNullOrWhiteSpace(id_producto_tiendanube) Then
                        id_producto_tiendanube = Nothing
                     End If


                     '# Me aseguro de no enviar stock < 0

                     '-- REQ-33467.- Parte Entera.- ------------------------------------------------------------
                     Dim stock As Integer? = Nothing
                     Dim variant_stock = dr.Field(Of Decimal?)("variant_stock")
                     If variant_stock.HasValue Then
                        stock = Convert.ToInt32(variant_stock.Value)
                     End If
                     'Dim stock As Integer? = Convert.ToInt32(dr.Field(Of Decimal?)("variant_stock"))
                     '------------------------------------------------------------------------------------------
                     If stock.HasValue AndAlso stock.Value < 0 Then stock = Math.Max(0, stock.Value)


                     '# Si no tiene precio promocional, se envía un 0.
                     Dim precioPromocional As Decimal = dr.Field(Of Decimal?)("variant_promotional_price").IfNull(0)
                     Dim precioVenta As Decimal = dr.Field(Of Decimal?)("variant_price").IfNull(0)

                     If tipo = Reglas.Publicos.MonedaProductoTiendasWeb.PESOS.ToString() And
                        dr.Field(Of Integer)("IdMoneda") = Reglas.Publicos.MonedaProductoTiendasWeb.DOLARES Then
                        precioVenta *= cotizacion
                        precioPromocional *= cotizacion
                     ElseIf tipo = Reglas.Publicos.MonedaProductoTiendasWeb.DOLARES.ToString() And
                        dr.Field(Of Integer)("IdMoneda") = Reglas.Publicos.MonedaProductoTiendasWeb.PESOS Then
                        precioVenta /= cotizacion
                        precioPromocional /= cotizacion
                     End If

                     count += 1
                     Dim variants = New With {.id = dr.Field(Of String)("variant_id"),
                                           .price = precioVenta,
                                           .promotional_price = precioPromocional,
                                           .stock = stock,
                                           .width = dr.Field(Of Decimal?)("variant_width"),
                                           .height = dr.Field(Of Decimal?)("variant_height"),
                                           .depth = dr.Field(Of Decimal?)("variant_depth"),
                                           .sku = dr.Field(Of String)("variant_sku"),
                                           .barcode = dr.Field(Of String)("variant_barcode"),
                                           .weight = dr.Field(Of Decimal?)("variant_weight")}

                     Dim categories = New With {.id = GetIdCategoriaPadre(dr)}

                     '# Para los productos, en caso de ser una moficación (PACTH), se debe enviar las Variantes del producto por separado. 
                     '# requires_shipping => Campo EsServicio => Si es True, el producto es digital. Caso contrario, es Físico.

                     '# Valido la publicación del producto. 
                     Dim published As Boolean? = Nothing
                     Dim activo As Boolean = dr.Field(Of Boolean)("Activo")
                     Dim publicarEnWeb As Boolean = dr.Field(Of Boolean)("PublicarEnWeb")


                     '-- Si no posee Codigo TN y esta activo y publicarTN = true tomo valor de parametro.- --------------------
                     If (String.IsNullOrEmpty(id_producto_tiendanube) AndAlso activo = True AndAlso publicarEnWeb = True) Then
                        published = Publicos.ProductoActivoenTienda
                     Else
                        If Publicos.ProductoActivoenTienda Then
                           If (Not String.IsNullOrEmpty(id_producto_tiendanube) AndAlso (activo = False OrElse publicarEnWeb = False)) Then '# Nueva Publicación también por defecto en FALSE
                              My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - El producto {0} fue procesado anteriormente pero ahora se encuentra Inactivo o PublicarEnWeb = False.", dr.Field(Of String)("name")), TraceEventType.Verbose)
                              published = False
                           Else
                              My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - El producto {0} fue procesado anteriormente pero ahora se encuentra Activo o PublicarEnWeb = True.", dr.Field(Of String)("name")), TraceEventType.Verbose)
                              published = True
                           End If
                        End If
                     End If

                     My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Producto: {0} (activo:{1}/published:{2}/publicarEnWeb:{3})",
                                                              dr.Field(Of String)("name"),
                                                              activo,
                                                              If(published.HasValue, published.Value.ToString(), "null"), publicarEnWeb), TraceEventType.Verbose)

                     Dim producto = New With {.id = id_producto_tiendanube,
                                              .name = dr.Field(Of String)(Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN.Campos.name.ToString()),
                                              .description = CargaDescripcionProducto(id_producto_tiendanube, dr.Field(Of String)(Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN.Campos.description.ToString())),
                                              .brand = dr.Field(Of String)(Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN.Campos.brand.ToString()),
                                              .free_shipping = dr.Field(Of Boolean)(Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN.Campos.free_shipping.ToString()),
                                              .published = published,
                                              .requires_shipping = Not dr.Field(Of Boolean)(Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN.Campos.requires_shipping.ToString()),
                                              .variants = If(String.IsNullOrEmpty(id_producto_tiendanube), {variants}.ToList(), Nothing),
                                              .categories = {GetIdCategoriaPadre(dr)}}


                     '--------------------------
                     TriggerEvent(SincroTiendaWebEstados.Subiendo, If(producto.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), dt.Rows.Count, count, "PRODUCTOS", countExitoso, countError)
                     '--------------------------
                     Dim data = serializer.Serialize(producto)

                     My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - JSON: {0}", data), TraceEventType.Verbose)

#If SYNCTIENDAWEB <> "FALSE" Then
                     Dim response As Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN = Nothing
                     Dim notFound As Boolean = False
                     Dim verb As SincroTiendaWebMetodos
                     Try
                        '# Valido que el producto siga existiendo en la tienda. 
                        If producto.id IsNot Nothing Then GETResponse(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN)(GetHeaders(), GetEndpoint(Controls.products.ToString(), producto.id))
                     Catch ex As Exception
                        My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Hubo un error al tratar de obtener el Producto {0}. El producto no se encontró en la tienda Web. - Método GET - URI: {1}.", dr.Field(Of String)("name"), ex.Message), TraceEventType.Error)
                        notFound = True
                     End Try

                     '# Si el producto ese eliminó de la tienda pero NO del SIGA, se vuelve a subir.
                     If notFound Then
                        verb = SincroTiendaWebMetodos.POST
                     Else
                        verb = If(producto.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT)
                     End If

                     response = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN)(data, verb, Me.GetHeaders(), GetEndpoint(Controls.products.ToString(), If(Not notFound, producto.id, "")))

                     If (producto.id Is Nothing) OrElse notFound Then '#(POST)
                        _nuevosProductos += 1
                        My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Enviando Nuevo Producto {0} - Método POST.", dr.Field(Of String)("name")), TraceEventType.Verbose)

                        My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Guardando Cód. Producto Tienda Nube ({0}) del Producto: {1}", response.Id, dr.Field(Of String)("name")), TraceEventType.Verbose)
                        rProductos.GuardarIdProductoTiendaNube(dr.Field(Of String)(Entidades.Producto.Columnas.IdProducto.ToString()), response.Id)

                        Dim id = String.Empty
                        If response.Variants.FirstOrDefault() IsNot Nothing Then
                           id = response.Variants.FirstOrDefault().Id
                        End If
                        My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Guardando Cód. Variante del Producto Tienda Nube ({0}) del Producto: {1}", id, dr.Field(Of String)("name")), TraceEventType.Verbose)
                        rProductos.GuardarIdVarianteProducto(dr.Field(Of String)(Entidades.Producto.Columnas.IdProducto.ToString()), id)
                     End If

                     '# Si el producto se encuentra disponible en la tienda y tiene variants en Nothing, quiere decir que es una modificación del producto, por lo que debemos enviarlas por separado
                     If Not notFound AndAlso producto.variants Is Nothing Then '#(PUT de variantes) 
                        _productosActualizados += 1
                        My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Actualizando Variantes del Producto {0} - Método PUT.", dr.Field(Of String)("name")), TraceEventType.Verbose)

                        Dim var = serializer.Serialize(variants)
                        Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.VarianteTN)(var, SincroTiendaWebMetodos.PUT, Me.GetHeaders(), GetEndpoint(Controls.products.ToString(), String.Format("{0}/variants/{1}", producto.id, response.Variants.FirstOrDefault().Id)))
                     End If
                     '--------------------------'--------------------------'--------------------------'--------------------------
                     RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Subiendo Productos..."))
                     '--------------------------'--------------------------'--------------------------'--------------------------
#Else
                  Threading.Thread.Sleep(500)
                  If count Mod 3 = 0 Then
                     Throw New Exception("Excepción de prueba")
                  End If
#End If
                     countExitoso += 1
                  Catch ex As Exception
                     countError += 1
                     OnInformarError(String.Format("Producto='{0}'", dr.Field(Of String)(Entidades.Producto.Columnas.IdProducto.ToString())), ex.Message)
                  End Try
                  TriggerEvent(SincroTiendaWebEstados.Subiendo, If(dr.Field(Of String)(Entidades.JSonEntidades.TiendasWeb.TiendaNube.ProductoTN.Campos.id.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), dt.Rows.Count, count, "PRODUCTOS", countExitoso, countError)

                  '41074 - Parametrizar cuanto tiempo demorar el proceso de sincronización
                  Threading.Thread.Sleep(Publicos.TiendasWeb.TiendaNube.TiendaNubeSleepEntreSolicitudes)
               Next

               '--------------------------
               '# Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.Producto.NombreTabla), TraceEventType.Information)
            Finally
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                                      Entidades.Producto.NombreTabla, Date.Now)
               '#If SYNCTIENDAWEB <> "FALSE" Then
               '         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
               '                                                                            .Tabla = Entidades.Producto.NombreTabla,
               '                                                                            .FechaActualizacion = Now,
               '                                                                            .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
               '                                                                            .IdUsuario = actual.Nombre,
               '                                                                            .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
               '#End If
            End Try

            '--------------------------
            '# Guardo la fecha de sincronización 
            My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.Producto.NombreTabla), TraceEventType.Information)

            rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                                   Entidades.Producto.NombreTabla, Date.Now)
            '#If SYNCTIENDAWEB <> "FALSE" Then
            '         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
            '                                                                            .Tabla = Entidades.Producto.NombreTabla,
            '                                                                            .FechaActualizacion = Now,
            '                                                                            .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
            '                                                                            .IdUsuario = actual.Nombre,
            '                                                                            .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
            '#End If
         End Using
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Productos subidos correctamente."))
         RaiseEvent ProcesoFinalizado(Me, New SincronizacionTiendaWebProcesoFinalizadoEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Proceso de Subida finalizado correctamente !!!", _nuevosProductos, _productosActualizados))
         '--------------------------
      End Sub

      Private Function CargaDescripcionProducto(idProductoTN As String, descripProductoTN As String) As String
         Dim actProductoDescrip = Publicos.ActualizacionProductoDescripcion
         Dim vDescrip As String

         If String.IsNullOrEmpty(idProductoTN) Then
            If actProductoDescrip = Publicos.ActualizarTiendasWeb.NUNCA.ToString() Or actProductoDescrip = Publicos.ActualizarTiendasWeb.MODIFICA.ToString() Then
               vDescrip = Nothing
            Else
               vDescrip = descripProductoTN
            End If
         Else
            If actProductoDescrip = Publicos.ActualizarTiendasWeb.NUNCA.ToString() Or actProductoDescrip = Publicos.ActualizarTiendasWeb.ALTA.ToString() Then
               vDescrip = Nothing
            Else
               vDescrip = descripProductoTN
            End If
         End If
         Return vDescrip
      End Function

      Private Sub _SubirCategorias()
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Obteniendo información de las Categorías..."))
         '--------------------------
         Dim serializer = New JavaScriptSerializer()

         Dim rRubros = New Rubros(da)
         Dim rSRubros = New SubRubros(da)
         Dim rSSRubros = New SubSubRubros(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         Dim rProductos = New Productos(da)

         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString())
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                       .Tabla = Entidades.Rubro.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })

         Dim count As Integer = 0
         Dim countExitoso As Integer = 0
         Dim countError As Integer = 0
         Using dt = rRubros.GetRubrosTiendasWeb(Entidades.TiendasWeb.TIENDANUBE)
            Try
               '# Rubros
               '--------------------------'--------------------------'--------------------------'--------------------------
               If dt.Rows.Count > 0 Then RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.TIENDANUBE, "Subiendo Categorías..."))
               '--------------------------'--------------------------'--------------------------'--------------------------

               My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - {0} Rubros por subir.", dt.Rows.Count), TraceEventType.Information)

               For Each dr As DataRow In dt.Rows
                  count += 1
                  Dim x = New With {.id = dr.Field(Of String)(Entidades.Rubro.Columnas.IdRubroTiendaNube.ToString()),
                                    .name = dr.Field(Of String)(Entidades.Rubro.Columnas.NombreRubro.ToString()),
                                    .parent = Nothing}

                  Dim data = serializer.Serialize(x) '# Armo el JSON y Lo convierto a String
                  '--------------------------
                  TriggerEvent(SincroTiendaWebEstados.Subiendo, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), dt.Rows.Count, count, "RUBROS", countExitoso, countError)
                  '--------------------------
                  Try
#If SYNCTIENDAWEB <> "FALSE" Then
                     Dim response = Enviar(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.CategoriaTN)(data, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), Me.GetHeaders(), GetEndpoint(Controls.categories.ToString(), x.id))

                     My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Guardando IDRubroTiendaNube {0} del Rubro {1}.", response.Id, dr.Field(Of Integer)(Entidades.Rubro.Columnas.IdRubro.ToString())), TraceEventType.Information)
                     rRubros.GuardarIdRubroTiendaNube(dr.Field(Of Integer)(Entidades.Rubro.Columnas.IdRubro.ToString()), response.Id)
#Else
                  Threading.Thread.Sleep(500)
                  If count Mod 3 = 0 Then
                     Throw New Exception("Excepción de prueba")
                  End If
#End If
                     countExitoso += 1
                  Catch ex As Exception
                     countError += 1
                     OnInformarError(String.Format("Rubro={0}", dr.Field(Of Integer)(Entidades.Rubro.Columnas.IdRubro.ToString())), ex.Message)
                     ''Throw New Exception(String.Format("Error enviando Rubro {0} - {1}: {2}{2}{3}",
                     ''                                  dr.Field(Of Integer)(Entidades.Rubro.Columnas.IdRubro.ToString()),
                     ''                                  dr.Field(Of String)(Entidades.Rubro.Columnas.NombreRubro.ToString()),
                     ''                                  Environment.NewLine, ex.Message), ex)
                  End Try
                  TriggerEvent(SincroTiendaWebEstados.Subiendo, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), dt.Rows.Count, count, "RUBROS", countExitoso, countError)
                  '41074 - Parametrizar cuanto tiempo demorar el proceso de sincronización
                  Threading.Thread.Sleep(Publicos.TiendasWeb.TiendaNube.TiendaNubeSleepEntreSolicitudes)
               Next

               '# Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Guardando Fecha de Última Sincronización - Tabla {0}", Entidades.Rubro.NombreTabla), TraceEventType.Information)
            Finally
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                                   Entidades.Rubro.NombreTabla, Date.Now)
               '#If SYNCTIENDAWEB <> "FALSE" Then
               '            rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
               '                                                                               .Tabla = Entidades.Rubro.NombreTabla,
               '                                                                               .FechaActualizacion = Now,
               '                                                                               .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
               '                                                                               .IdUsuario = actual.Nombre,
               '                                                                               .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
               '#End If
            End Try
         End Using


         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString())
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                       .Tabla = Entidades.SubRubro.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })

         count = 0
         countExitoso = 0
         countError = 0
         '# SubRubros
         Using dt = rSRubros.GetSubRubrosTiendaWeb(Entidades.TiendasWeb.TIENDANUBE)
            Try
               My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - {0} SubRubros por subir.", dt.Rows.Count), TraceEventType.Information)

               For Each dr As DataRow In dt.Rows
                  count += 1
                  Dim x = New With {.id = dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroTiendaNube.ToString()),
                                    .name = dr.Field(Of String)(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()),
                                    .parent = dr.Field(Of String)(Entidades.Rubro.Columnas.IdRubroTiendaNube.ToString())} '# Envio como 'parent' el id del rubro

                  Dim data = serializer.Serialize(x) '# Armo el JSON y Lo convierto a String
                  '--------------------------
                  Me.TriggerEvent(SincroTiendaWebEstados.Subiendo, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), dt.Rows.Count, count, "SUBRUBROS", countExitoso, countError)
                  '--------------------------
                  Try
#If SYNCTIENDAWEB <> "FALSE" Then
                     Dim response = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.CategoriaTN)(data, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), Me.GetHeaders(), GetEndpoint(Controls.categories.ToString(), x.id))
                     My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Guardando IDSubRubroTiendaNube {0} del SubRubro {1}.", response.Id, dr.Field(Of Integer)(Entidades.SubRubro.Columnas.IdSubRubro.ToString())), TraceEventType.Information)
                     rSRubros.GuardarIdSubRubroTiendaNube(dr.Field(Of Integer)(Entidades.SubRubro.Columnas.IdSubRubro.ToString()), response.Id)
#Else
                  Threading.Thread.Sleep(500)
                  If count Mod 3 = 0 Then
                     Throw New Exception("Excepción de prueba")
                  End If
#End If
                     countExitoso += 1
                  Catch ex As Exception
                     countError += 1
                     OnInformarError(String.Format("SubRubro={0}", dr.Field(Of Integer)(Entidades.SubRubro.Columnas.IdSubRubro.ToString())), ex.Message)
                     'Throw New Exception(String.Format("Error enviando SubRubros {0} - {1}: {2}{2}{3}",
                     '                                  dr.Field(Of Integer)(Entidades.SubRubro.Columnas.IdSubRubro.ToString()),
                     '                                  dr.Field(Of String)(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()),
                     '                                  Environment.NewLine, ex.Message), ex)
                  End Try
                  TriggerEvent(SincroTiendaWebEstados.Subiendo, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), dt.Rows.Count, count, "SUBRUBROS", countExitoso, countError)

                  '41074 - Parametrizar cuanto tiempo demorar el proceso de sincronización
                  Threading.Thread.Sleep(Publicos.TiendasWeb.TiendaNube.TiendaNubeSleepEntreSolicitudes)
               Next

               '# Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Guardando Fecha de Última Sincronización - Tabla {0}", Entidades.SubRubro.NombreTabla), TraceEventType.Information)

            Finally
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                                   Entidades.SubRubro.NombreTabla, Date.Now)
               '#If SYNCTIENDAWEB <> "FALSE" Then
               '            rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
               '                                                                               .Tabla = Entidades.SubRubro.NombreTabla,
               '                                                                               .FechaActualizacion = Now,
               '                                                                               .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
               '                                                                               .IdUsuario = actual.Nombre,
               '                                                                               .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
               '#End If
            End Try
         End Using

         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString())
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                       .Tabla = Entidades.SubSubRubro.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })

         count = 0
         countExitoso = 0
         countError = 0
         '# SubSubRubros
         Using dt = rSSRubros.GetSubSubRubrosTiendaWeb(Entidades.TiendasWeb.TIENDANUBE)
            Try
               My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - {0} SubSubRubros por subir.", dt.Rows.Count), TraceEventType.Information)

               For Each dr As DataRow In dt.Rows
                  count += 1
                  Dim x = New With {.id = dr.Field(Of String)(Entidades.SubSubRubro.Columnas.IdSubSubRubroTiendaNube.ToString()),
                                    .name = dr.Field(Of String)(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()),
                                    .parent = dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroTiendaNube.ToString())} '# Envio como 'parent' el id del subrubro

                  Dim data = serializer.Serialize(x) '# Armo el JSON y Lo convierto a String
                  '--------------------------
                  Me.TriggerEvent(SincroTiendaWebEstados.Subiendo, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), dt.Rows.Count, count, "SUBSUBRUBROS", countExitoso, countError)
                  '--------------------------
                  Try
#If SYNCTIENDAWEB <> "FALSE" Then
                     Dim response = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.CategoriaTN)(data, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), Me.GetHeaders(), GetEndpoint(Controls.categories.ToString(), x.id))
                     My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Guardando IDSubSubRubroTiendaNube {0} del SubSubRubro {1}.", response.Id, dr.Field(Of Integer)(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString())), TraceEventType.Information)
                     rSSRubros.GuardarIdSubSubRubroTiendaNube(dr.Field(Of Integer)(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString()), response.Id)
#Else
                  Threading.Thread.Sleep(500)
                  If count Mod 3 = 0 Then
                     Throw New Exception("Excepción de prueba")
                  End If
#End If
                     countExitoso += 1
                  Catch ex As Exception
                     countError += 1
                     OnInformarError(String.Format("SubSubRubro={0}", dr.Field(Of Integer)(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString())), ex.Message)
                     'Throw New Exception(String.Format("Error enviando SubSubRubros {0} - {1}: {2}{2}{3}",
                     '                                       dr.Field(Of Integer)(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString()),
                     '                                       dr.Field(Of String)(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()),
                     '                                       Environment.NewLine, ex.Message), ex)
                  End Try
                  TriggerEvent(SincroTiendaWebEstados.Subiendo, If(x.id Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT), dt.Rows.Count, count, "SUBSUBRUBROS", countExitoso, countError)

                  '41074 - Parametrizar cuanto tiempo demorar el proceso de sincronización
                  Threading.Thread.Sleep(Publicos.TiendasWeb.TiendaNube.TiendaNubeSleepEntreSolicitudes)
               Next

               '# Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube - Guardando Fecha de Última Sincronización - Tabla {0}", Entidades.SubSubRubro.NombreTabla), TraceEventType.Information)
            Finally
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                                   Entidades.SubSubRubro.NombreTabla, Date.Now)
               '#If SYNCTIENDAWEB <> "FALSE" Then
               '         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
               '                                                                            .Tabla = Entidades.SubSubRubro.NombreTabla,
               '                                                                            .FechaActualizacion = Now,
               '                                                                            .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
               '                                                                            .IdUsuario = actual.Nombre,
               '                                                                            .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
               '#End If
            End Try
         End Using

      End Sub

      Private Function Enviar(Of T)(data As String, method As SincroTiendaWebMetodos, headers As Dictionary(Of String, String), relativeUri As String) As T 'POSTResponseTiendaNube
         Dim uri As Uri = New Uri(Me.TiendaNubeURLBase, relativeUri)
         '--------------------------------------------------------------------------------------
         GetPOSTResponse(uri, method.ToString(), data, headers, Sub(x)
                                                                   RestResponse = x
                                                                End Sub)
         '# Get the POST response
         Return DirectCast(New JavaScriptSerializer().Deserialize(RestResponse, GetType(T)), T)
         '--------------------------------------------------------------------------------------
      End Function

#Region "Web Methods"
      Public Function GETResponse(Of T)(headers As Dictionary(Of String, String), relativeUri As String) As T
         Dim uri As Uri = New Uri(Me.TiendaNubeURLBase, relativeUri)
         Dim wc As New WebClient()

         '# Estos dos parámetros deben enviarse acá porque el wc no los contiene (no como así los tiene el HttpWebRequest)
         wc.Headers.Add("ContentType", "application/json; charset=utf-8")
         wc.Headers.Add("User-Agent", "SIGA(info@sinergiasoftware.com.ar)")

         Try
            If headers IsNot Nothing Then
               For Each header As KeyValuePair(Of String, String) In headers
                  If Not String.IsNullOrWhiteSpace(header.Key) Then
                     wc.Headers.Add(header.Key, header.Value)
                  End If
               Next
            End If

            Using orResult As System.IO.Stream = wc.OpenRead(uri)
               Using reader As StreamReader = New StreamReader(orResult, New System.Text.UTF8Encoding())
                  Dim responseString As String = reader.ReadToEnd()
                  Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
                  Dim datos As T = DirectCast(serializer.Deserialize(responseString, GetType(T)), T)
                  Return datos
               End Using
            End Using
         Catch ex As WebException
            TiendaNubeExceptionHelper.TiendaNubeExceptionHandler(ex)
         End Try
      End Function

      Private Sub GetPOSTResponse(uri As Uri, metodo As String, data As String, headers As Dictionary(Of String, String), callback As Action(Of String))
         Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)
         request.Method = metodo
         request.ContentType = "application/json; charset=utf-8"
         request.UserAgent = "SIGA(info@sinergiasoftware.com.ar)"

         '# Add headers
         If headers IsNot Nothing Then
            For Each header As KeyValuePair(Of String, String) In headers
               If Not String.IsNullOrWhiteSpace(header.Key) Then
                  request.Headers.Add(header.Key, header.Value)
               End If
            Next
         End If

         Try
            Dim encoding As New System.Text.UTF8Encoding()
            Dim bytes As Byte() = encoding.GetBytes(data)
            request.ContentLength = bytes.Length
            Using requestStream As Stream = request.GetRequestStream()
               ' Send the data.
               requestStream.Write(bytes, 0, bytes.Length)
            End Using

            request.BeginGetResponse(
             Function(x)
                Using response As HttpWebResponse = DirectCast(request.EndGetResponse(x), HttpWebResponse)
                   If callback IsNot Nothing Then
                      Using stream As Stream = response.GetResponseStream()
                         Dim reader As StreamReader = New StreamReader(stream, encoding)
                         Dim responseString As String = reader.ReadToEnd()
                         callback(responseString)
                      End Using
                   End If
                End Using
                Return 0
             End Function, Nothing)
         Catch ex As WebException
            TiendaNubeExceptionHelper.TiendaNubeExceptionHandler(ex)
         End Try
      End Sub

      Private Function GetHeaders() As Dictionary(Of String, String)
         Return GetHeaders(since_id:=0, onlyIds:=False)
      End Function

      Private Function GetHeaders(since_id As Long, onlyIds As Boolean) As Dictionary(Of String, String)
         Dim headers As Dictionary(Of String, String) = New Dictionary(Of String, String)
         headers.Add("Authentication", String.Format("bearer {0}", Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeToken))

         Return headers
      End Function

      Private Function SetURLParameters(url As String, param As Dictionary(Of String, String)) As String
         For Each kv As KeyValuePair(Of String, String) In param
            If Not url.Contains("?") Then
               url += String.Format("?{0}={1}", kv.Key, kv.Value)
            Else
               url += String.Format("&{0}={1}", kv.Key, kv.Value)
            End If
         Next
         Return url
      End Function

#End Region

#End Region

#Region "Enum"
      Public Enum Controls
         categories
         products
         orders
      End Enum
#End Region

#Region "Responses"
      Public Class POSTResponseTiendaNube
         Public Property id As String
         Public Property parent As String

      End Class
#End Region

   End Class
End Namespace