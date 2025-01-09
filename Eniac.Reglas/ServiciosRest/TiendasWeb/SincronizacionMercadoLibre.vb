Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports Eniac.Entidades

Namespace ServiciosRest.TiendasWeb
   Public Class SincronizacionMercadoLibre
      Inherits Base

      Public serializer As New JavaScriptSerializer()

#Region "Propiedades"
      Private Property MercadoLibreURLBase As Uri
      Private Property UriCategorias As String = "sites/MLA/categories"

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
         If Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreURLBase) Then
            Me.MercadoLibreURLBase = New Uri(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreURLBase)
         Else
            Throw New Exception("ATENCIÓN: La URL Base para Mercado Libre no se encuentra configurada.")
         End If

         If String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoAppIdML) Then
            Throw New Exception("ATENCIÓN: No existe aplicacion Mercado Libre configurada.")
         End If
      End Sub
#End Region

#Region "Methods"
      Private Sub TriggerEvent(estado As SincroTiendaWebEstados, verb As SincroTiendaWebMetodos, totalRegistros As Integer, nroRegistroSubiendo As Integer, queEstoySubiendo As String, countExitosos As Integer, countError As Integer)
         RaiseEvent estado(Me, New SincronizacionTiendaWebEstadoEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, estado, verb, totalRegistros, nroRegistroSubiendo, queEstoySubiendo, countExitosos, countError))
      End Sub
      Protected Sub OnInformarError(elementoTransmitido As String, mensaje As String)
         RaiseEvent InformarError(Me, New SincronizacionTiendaWebErrorEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, elementoTransmitido, mensaje))
      End Sub

      Public Function ReporteDeErrores() As String
         Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb
         Dim reporteError As StringBuilder = New StringBuilder

         Dim dt As DataTable = rPTW.GetPedidosAImportar("MERCADOLIBRE", {"ERROR"}, Nothing, desde:=Nothing, hasta:=Nothing, tipoFechaFiltro:=Nothing) '# Obtengo todos los pedidos que tienen algun tipo de error y no pudieron procesarse 

         If dt.Rows.Count = 0 Then Return Nothing '# Si no hay errores, no envio ningun reporte.

         With reporteError
            .AppendFormatLine("*** Se encontraron los siguientes ERRORES en el Proceso de Bajada de Pedidos de Mercado Libre ***")
            .AppendFormatLine("<br>")
            For Each dr As DataRow In dt.Rows
               .AppendFormatLine("<br>  >> Id Pedido (Mercado Libre): {0}", dr.Field(Of String)("Id"))
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

      Public Sub ActualizaCategorias()
         '-- Actualiza el estado de las Categorias ML.- --
         Me._ActualizaCategorias()
         '--------------------------
      End Sub
      Private Sub _ActualizaCategorias()
         '--------------------------
         Dim serializer = New JavaScriptSerializer()
         Dim rCategoriasML = New Reglas.CategoriasMercadoLibre(da)

         '-- Marca Todas las Categorias Existentes en False (Desactiva).- --
         Dim ActivoSiNo As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.NO
         rCategoriasML.EstadoCategoria(ActivoSiNo)
         '-- Recupera el listado de Categorias de Mercado Libre.- --
         Dim response = GETResponse(Of List(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.CategoriaML))(Me.GetHeaders(), UriCategorias)
         '--------------------------
         If response.Count > 0 Then
            For Each categoML As Entidades.JSonEntidades.TiendasWeb.Mercadolibre.CategoriaML In response
               '-- Si la Categoria esta en la base la Activa.- --
               If rCategoriasML.ExisteCategoria(categoML.id.ToString()) Then
                  '-- Activa Categoria.- --
                  ActivoSiNo = Entidades.Publicos.SiNoTodos.SI
                  rCategoriasML.EstadoCategoria(ActivoSiNo)
               Else
                  '-- Carga Nueva Categoria.- --
                  Dim SQLCateML = New Entidades.CategoriasMercadoLibre
                  '-- Carga los Datos de las Categorias.- --
                  SQLCateML.IdCategoria = categoML.id
                  SQLCateML.NombreCategoria = categoML.name
                  SQLCateML.ActivoCategoria = Entidades.Publicos.SiNoTodos.SI
                  '-- Inserta Categoria.- --
                  rCategoriasML.Insertar(SQLCateML)
               End If
            Next
         End If
         '--------------------------
      End Sub

      Public Sub BajarInformacion(bajarTodo As Boolean)
         _rebajarTodo = bajarTodo
         '-- Bajo los pedidos de Mercado Libre.- --
         Me.BajarPedidos()
         '--------------------------
      End Sub
      Private Sub BajarPedidos()
         EjecutaConConexion(Sub() _BajarPedidos())
      End Sub
      Private Sub _BajarPedidos()
         '--------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, "Obteniendo información de los Pedidos..."))
         '--------------------------
         Dim serializer = New JavaScriptSerializer()
         Dim sistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.MERCADOLIBRE.ToString()
         Dim rPedidosTiendasWeb = New Reglas.PedidosTiendasWeb(da)
         Dim rURIRelativa = "search"
         Dim params = New Dictionary(Of String, String)

         '-- Obtener la fecha de ultima Bajada.- --
         '********************************************************************************************************************
         Dim fechaUltimaSincronizacion = New Reglas.FechasSincronizaciones().GetFechaUltimaSincronizacion(
                                             Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.MERCADOLIBRE.ToString(),
                                             Entidades.Pedido.NombreTabla)
         '********************************************************************************************************************
         '-- Se Crean los parámetros asociados al GET.- --
         params.Add("seller", Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoResellerML) '-- Este parámetro es para obtener el codigo de Reseller.- --
         params.Add("order.status", "paid") '-- Este parámetro es para Definir el Estado de la Ordenes.- --

         '-- Evalua la Fecha de Actualizacion.- --
         If fechaUltimaSincronizacion IsNot Nothing Then
            My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre.Ejecutar - Parámetros de la Request: Ultima Fecha de Bajada.", fechaUltimaSincronizacion.ToString()), TraceEventType.Verbose)
            '-- Adiciona las Fecha de busqueda.- --
            params.Add("order.date_created.from", fechaUltimaSincronizacion.Value.ToString("yyyy-MM-ddTHH:mm:ss-04:00")) '-- Fecha Desde Ultima Bajada - Ver futuro Zulu -04:00.- --
         End If

         '-- Primero obtengo todos los IDs de los nuevos pedidos.- --
         My.Application.Log.WriteEntry("SubidaMercadoLibre.Ejecutar - Obteniendo IDs de Nuevos Pedidos.", TraceEventType.Verbose)
         Dim response = GETResponse(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.OrdenesML)(Me.GetHeaders(), Me.SetURLParameters(GetEndpoint(Controls.orders.ToString(), rURIRelativa), params))

         '--------------------------
         If response.results.Count > 0 Then RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, "Bajando pedidos Mercado Libre..."))
         '--------------------------
         My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre.Ejecutar - {0} Pedidos (posibles) por bajar.", response.results.Count), TraceEventType.Verbose)

         '-- Luego por cada uno de los pedidos obtenidos realizo un GET por separado para obtenerlos individualmente y poder guardar su JSON como auditoría.- --
         Dim ePTW As Entidades.PedidoTiendaWeb
         Dim count As Integer = 0
         Dim countExitoso As Integer = 0
         Dim countError As Integer = 0

         For Each pedido As Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Resultado In response.results
            '-- Si el pedido ya esta grabado, no lo voy a buscar.- --
            If rPedidosTiendasWeb.ExistePedido(pedido.id.ToString(), sistemaDestino) Then Continue For

            count += 1
            ePTW = New Entidades.PedidoTiendaWeb

            My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre.Ejecutar - Obteniendo Pedido {0}.", pedido.id), TraceEventType.Verbose)
            Dim p = GETResponse(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.PedidosML)(Me.GetHeaders(), GetEndpoint(Controls.orders.ToString(), pedido.id.ToString()))

            TriggerEvent(SincroTiendaWebEstados.Bajando, SincroTiendaWebMetodos.GET, response.results.Count, count, "pedidos", countExitoso, countError)

            '# vuelvo a serializar el json y me lo guardo como auditoría
            Dim jsonstring As String = serializer.Serialize(p)

            With ePTW
               .Id = p.id.ToString()
               .SistemaDestino = sistemaDestino
               .Numero = CLng(p.id.ToString())

               .IdClienteTiendaWeb = CStr(p.buyer.id)
               '-- REQ-34152.- -------------------------------------------------------------------------------------------------------------
               .NombreClienteTiendaWeb = String.Format("{0} {1}", p.buyer.last_name.ToString(), p.buyer.first_name.ToString()).Truncar(100)
               '----------------------------------------------------------------------------------------------------------------------------
               .IdMoneda = p.currency_id

               .FechaPedido = CDate(p.date_created)
               .ImporteTotal = CDec(p.paid_amount)
               .SubTotal = CDec(p.total_amount)
               .IdUsuarioEstado = actual.Nombre
               .FechaEstado = Now
               .IdUsuarioDescarga = actual.Nombre
               .FechaDescarga = Now
               .IdEstadoPedidoTiendaWeb = "PENDIENTE" '# Los pedidos quedan inicialmente con estado "PENDIENTE"
               .JSON = jsonstring
               '-- REQ-34577.- -------------------------------------------------------------------------------
               Dim rBilling = GETResponse(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Billing_Info)(Me.GetHeaders(), "orders/" + p.id.ToString() + "/billing_info")
               If rBilling IsNot Nothing Then
                  .NroDocCliente = Long.Parse(rBilling.billing_info.doc_number)
               Else
                  .NroDocCliente = p.buyer.id
               End If
               '----------------------------------------------------------------------------------------------
               .Email = p.buyer.email
               '--REG-32517.- -- Se corrige Dado que con Shiping puede tener Telefono Nulo.- -----------------
               .Telefono = If(p.buyer.phone Is Nothing, ".", p.buyer.phone.area_code + p.buyer.phone.number)
               '----------------------------------------------------------------------------------------------
               .PacksIdTiendaWeb = If(p.pack_id = Nothing, p.id.ToString(), p.pack_id)

               If p.shipping.id <> Nothing Then
                  .TipoEnvio = "shipping"

                  My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre.Ejecutar - Obteniendo Pedido {0}.", pedido.id), TraceEventType.Verbose)
                  '-- Recupera los datos del Shipping del Pedido de Mercado Libre.- --
                  Dim rShipp = GETResponse(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Shippings)(Me.GetHeaders(), "shipments/" + p.shipping.id.ToString())


                  .CostoEnvio = CDec(rShipp.shipping_option.cost)
                  .CodigoPostal = CInt(rShipp.receiver_address.zip_code)
                  .DireccionNumero = rShipp.receiver_address.street_number
                  '--REG-32517.- -- Se corrige Largo del Campo a Varchar(100).- --
                  .DireccionEnvio = String.Concat(rShipp.receiver_address.street_name, " ", rShipp.receiver_address.street_number, " ", rShipp.receiver_address.city.name, " ", rShipp.receiver_address.state.name).Truncar(100)
                  .DireccionCalle = rShipp.receiver_address.street_name.Truncar(100)
                  '--REG-32517.- -- Se corrige Largo del Campo de Varchar(100) as Varchar(200).- --
                  .Adicional = rShipp.receiver_address.comment.Truncar(200)
                  '--------------------------------------------------------------------------------
                  .Localidad = rShipp.receiver_address.city.name
                  .Provincia = rShipp.receiver_address.state.name

                  .ObservacionesTiendaWeb = "Shipping ID " + p.shipping.id.ToString()
               Else
                  .DireccionEnvio = "."
                  .CostoEnvio = 0
                  .CodigoPostal = actual.Sucursal.Localidad.IdLocalidad

                  .DireccionCalle = "."
                  .DireccionNumero = "."
                  .Adicional = "."
                  .Localidad = "."
                  .Provincia = "."

                  .ObservacionesTiendaWeb = p.comment.Truncar(200)
               End If

            End With

            '# Productos
            Dim ePPTW As Entidades.PedidoProductoTiendaWeb
            For Each pr As Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Order_Items In p.order_items
               ePPTW = New Entidades.PedidoProductoTiendaWeb
               With ePPTW
                  .Id = p.id.ToString()
                  .SistemaDestino = sistemaDestino
                  .Numero = CLng(p.id.ToString())
                  .IdProductoTiendaWeb = pr.item.id
                  .NombreProductoTiendaWeb = pr.item.title
                  .Precio = CDec(pr.unit_price)
                  .Cantidad = CDec(pr.quantity)
                  ePTW.Productos.Add(ePPTW)
               End With
            Next

            '# Guardo el pedido en mi tabla de PedidosTiendasWeb (Tabla de Pedidos intermedia entre el SIGA y la Web)
            My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre.Ejecutar - Grabando Pedido {0}.", pedido.id), TraceEventType.Verbose)

            rPedidosTiendasWeb._Inserta(ePTW, soloTransaccion:=True)

            My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre.Ejecutar - Pedido {0} grabado correctamente.", pedido.id), TraceEventType.Verbose)

            countExitoso += 1
         Next
         TriggerEvent(SincroTiendaWebEstados.Bajando, SincroTiendaWebMetodos.GET, response.results.Count, count, "pedidos", countExitoso, countError)

         '-- Si no se descargo un nuevo pedido, muestro en pantalla el mensaje.- --
         If count = 0 Then
            RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, "No hay pedidos para bajar."))
            My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre.Ejecutar - No hay pedidos para bajar."), TraceEventType.Information)
         End If
         '-------------------------------------------------------------------------
      End Sub

      Public Sub SubirProductos(publicarPrecioPorEmbalaje As Boolean)
         '-- Publica Productos en Mercado Libre.- --
         EjecutaConConexion(Sub() _SubirProductos(publicarPrecioPorEmbalaje))
         '--------------------------
      End Sub
      Public Sub _SubirProductos(publicarPrecioPorEmbalaje As Boolean)
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, "Obteniendo información de los Productos..."))
         My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre - Comenzando la Subida de Productos."), TraceEventType.Information)
         '--------------------------
         Dim sCondicion As String
         Dim rRubros = New Reglas.Rubros(da)
         Dim rProductos = New Reglas.Productos(da)
         '-- Contiene los estados de Inactividad de ML.- --
         Dim lEstadoML = New List(Of String) From {"closed", "inactive"}
         _nuevosProductos = 0
         _productosActualizados = 0

         Dim rSincronizaciones As Reglas.FechasSincronizaciones = New Reglas.FechasSincronizaciones(da)

         '-- Obtener Todos los Productos a Subir para Mercado Libre.- --
         Dim dt As DataTable = rProductos.GetProductosTiendaWeb(_reenviarTodo, Entidades.TiendasWeb.MERCADOLIBRE, publicarPrecioPorEmbalaje)
         Dim count = 0I
         Dim countExitoso = 0I
         Dim countError = 0I
         '-- Productos - Publicaciones.- 
         '--------------------------'--------------------------'--------------------------'--------------------------
         My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre - {0} Productos por subir desde la Última Sincronización.", dt.Rows.Count), TraceEventType.Verbose)
         '--------------------------'--------------------------'--------------------------'--------------------------
         '-- REQ-31683.- -- 
         Dim DicCategorias As New Dictionary(Of String, Decimal)
         Dim PrecioCategoML As New Decimal

         For Each dr As DataRow In dt.Rows
            If DicCategorias.ContainsKey(dr.Field(Of String)("Categoria")) Then
               '-- Recupera Valor de Clave.- --
               PrecioCategoML = DicCategorias.Item(dr.Field(Of String)("Categoria"))
            Else
#If SYNCTIENDAWEB <> "FALSE" Then
               '-- Obtiene Precio minimo de la Categoria de Mercado Libre de Existir.- --
               PrecioCategoML = ConsultaCategoriaMLibre(dr.Field(Of String)("Categoria"))
#End If
               '-- Guarda Valor Categoria.- --
               DicCategorias.Add(dr.Field(Of String)("Categoria"), PrecioCategoML)
            End If
         Next

         For Each dr As DataRow In dt.Rows
            count += 1
            '-- Recupera Precio Categoria.- --
            If DicCategorias.ContainsKey(dr.Field(Of String)("Categoria")) Then
               '-- Recupera Valor de Clave.- --
               PrecioCategoML = DicCategorias.Item(dr.Field(Of String)("Categoria"))
            End If
            '-- Verifica Precio.- --                                
            If dr.Field(Of Decimal)("variant_price") >= PrecioCategoML Then
               '-- Descarga Condiciones.- --
               sCondicion = dr.Field(Of String)("Condicion")
               '-- Descarga Codigo de Mercado Libre de Existir.- --
               Dim CodigoML = dr.Field(Of String)("CodigoMercadoLibre")
               '-- Descarga Estado de Mercado Libre de Existir.- --
#If SYNCTIENDAWEB <> "FALSE" Then
               Dim EstadoML = If(CodigoML = Nothing, Nothing, ConsultaProdMercadoLibre(CodigoML))
#Else
               Dim EstadoML = "new"
#End If
               If lEstadoML.Contains(EstadoML) And sCondicion = "update" Then
                  sCondicion = "new"
               End If

               Dim data As String = String.Empty
               '--------------------------
               TriggerEvent(SincroTiendaWebEstados.Subiendo, SincroTiendaWebMetodos.POST, dt.Rows.Count, count, "PUBLICACIONES", countExitoso, countError)
               '--------------------------
               Try
                  Select Case sCondicion
                     '-- Si es nuevo Cargo todos sus datos a ML-
                     Case "new"
                        '-- Carga la imagen Default.- --
                        Dim Imagenes = New With {.id = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreImagenDefaultML}
                        '-- Carga la Garantia Default.- --
                        Dim Garantias = New With {.id = "WARRANTY_TYPE", .value_name = "Garantía del vendedor"}

                        ''-- Carga Atributos de Marca y Modelo N/A.- --
                        Dim Atributos = {New With {.id = "BRAND", .value_id = "-1", .value_name = Nothing},
                                         New With {.id = "MODEL", .value_id = "-1", .value_name = Nothing}}

                        '-- Mercado Libre no permite stock negativos.- --
                        Dim vStock As Decimal
                        If dr.Field(Of Decimal)("variant_stock") < 0 Then
                           vStock = 0
                        Else
                           vStock = dr.Field(Of Decimal)("variant_stock")
                        End If
                        '-- Carga Producto Final.- --
                        Dim Producto = New With
                        {
                           .site_id = "MLA",                                              '-- Id de Sitio
                           .title = Replace(dr.Field(Of String)("name"), "'", ""),        '-- Descripcion.-
                           .category_id = dr.Field(Of String)("Categoria"),               '-- Categoria ML
                           .price = dr.Field(Of Decimal)("variant_price"),                '-- Precio de Producto
                           .currency_id = "ARS",                                          '-- Moneda
                           .available_quantity = vStock,                                  '-- Stock
                           .listing_type_id = "gold_special",                             '-- Tipo de Publicacion
                           .condition = "new",                                            '-- Condicion.-
                           .pictures = {Imagenes}.ToList(),                               '-- Imagen
                           .sale_terms = {Garantias}.ToList(),                            '-- Garantia
                           .attributes = Atributos,
                           .accepts_mercadopago = "true",                                 '-- Acepta Mercado Pago
                           .status = "active"                                             '-- Estado de la Campaña
                        }
                        '-- Armo el JSON y Lo convierto a String
                        data = serializer.Serialize(Producto)
                        '-- Si es nuevo Cargo todos sus datos a ML-
#If SYNCTIENDAWEB <> "FALSE" Then
                        CargaNuevoProducto(data, dr, dt.Rows.Count)
#End If
                        '-- Actualiza Contador.- --
                        _nuevosProductos += 1

                    '-- Si ya Existe Modifico sus datos Principales.
                     Case "update"
                        Dim Producto = New With
                        {
                           .title = dr.Field(Of String)("name"),
                           .price = dr.Field(Of Decimal)("variant_price"),
                           .available_quantity = dr.Field(Of Decimal)("variant_stock")
                        }
                        '-- Armo el JSON y Lo convierto a String
                        data = serializer.Serialize(Producto)
                        '-- Si ya Existe Modifico sus datos Principales.
#If SYNCTIENDAWEB <> "FALSE" Then
                        UpdateProdMercadoLibre(data, CodigoML, EstadoML)
#End If
                        '-- Actualiza Contador.- --
                        _productosActualizados += 1

                        '-- Cambio el estado de la Publicacion.- 
                     Case Else
                        Dim Status = New With
                           {
                              .status = dr.Field(Of String)("Condicion")
                           }
                        '-- Armo el JSON y Lo convierto a String
                        data = serializer.Serialize(Status)
                        '-- Si ya Existe pero esta inactivo desactivo campaña-.
#If SYNCTIENDAWEB <> "FALSE" Then
                        StatusProdMercadoLibre(data, CodigoML)
#End If
                        '-- Actualiza Contador.- --
                        _productosActualizados += 1

                  End Select
                  My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre - JSON: {0}", data), TraceEventType.Verbose)

#If SYNCTIENDAWEB <> "FALSE" Then
#Else
                  If count Mod 3 = 0 Then
                     Throw New Exception("Prueba de error")
                  End If
#End If

                  countExitoso += 1

               Catch ex As Exception
                  countError += 1
                  Dim idProducto = dr.Field(Of String)("IdProducto")
                  OnInformarError(String.Format("IdProducto='{0}'", idProducto), ex.Message)
                  'Throw New Exception(String.Format("Error enviando Publicacion {0} - {1}: {2}{2}{3}",
                  '                               CodigoML,
                  '                               dr.Field(Of String)("IdProducto"),
                  '                               Environment.NewLine, ex.Message), ex)
               End Try
               TriggerEvent(SincroTiendaWebEstados.Subiendo, SincroTiendaWebMetodos.POST, dt.Rows.Count, count, "PUBLICACIONES", countExitoso, countError)
               '--------------------------'--------------------------'--------------------------'--------------------------
               RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, "Subiendo Productos..."))
               '--------------------------'--------------------------'--------------------------'--------------------------
            Else
               Throw New Exception(String.Format("SubidaMercadoLibre - Publicacion {0}, su precio esta por debajo del minimo de Mercado Libre {1}.", dr.Field(Of String)("name"), PrecioCategoML))
            End If
         Next
         '--------------------------
         '# Guardo la fecha de sincronización 
         My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.Producto.NombreTabla), TraceEventType.Information)
#If SYNCTIENDAWEB <> "FALSE" Then
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.MERCADOLIBRE.ToString(),
                                                                            .Tabla = Entidades.Producto.NombreTabla,
                                                                            .FechaActualizacion = Now,
                                                                            .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
                                                                            .IdUsuario = actual.Nombre,
                                                                            .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
#End If
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, "Productos subidos correctamente."))
         RaiseEvent ProcesoFinalizado(Me, New SincronizacionTiendaWebProcesoFinalizadoEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, "Proceso de Subida finalizado correctamente !!!", _nuevosProductos, _productosActualizados))
         '--------------------------
      End Sub

      '-- Incorpora Nueva Publicacion.- --
      Public Sub CargaNuevoProducto(data As String, dr As DataRow, CantidadReg As Integer)
         Dim rProductos = New Reglas.Productos(da)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Publicaciones)(data, SincroTiendaWebMetodos.POST, Me.GetHeaders(), "items")
         '-- Guardo Valor de ID Mercado libre'
         rProductos.GuardarIdProductoTiendaWeb("MercadoLibre", dr.Field(Of String)("IdProducto"), response.id)
         '-- Desactiva Producto.- --
         Dim Status = New With
               {
                  .status = "paused"
               }
         '-- Armo el JSON y Lo convierto a String
         data = serializer.Serialize(Status)
         '-- Cambia el Estado a Pausado. --
         StatusProdMercadoLibre(data, response.id)
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre - Cargando Publicacion {0} de {1}.", response.id, CantidadReg), TraceEventType.Verbose)

      End Sub
      '-- Actualiza Valores de Publicacion.- --
      Public Sub UpdateProdMercadoLibre(data As String, idPublicacion As String, statusML As String)
         '-- Si ya Existe Modifico sus datos Principales.
         Dim response = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Actualizaciones)(data, SincroTiendaWebMetodos.PUT, Me.GetHeaders(), "items/" + idPublicacion)
         '-- Actualiza Status Producto.- --
         If statusML <> "active" Then
            Dim Status = New With
               {
                  .status = statusML
               }
            '-- Armo el JSON y Lo convierto a String
            data = serializer.Serialize(Status)
            '-- Cambia el Estado a Pausado. --
            StatusProdMercadoLibre(data, response.id)
         End If
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre - Actualizando Variantes del Producto {0} - Método PUT.", idPublicacion), TraceEventType.Verbose)
      End Sub
      '-- Cambia Status de Publicacion.- --
      Public Sub StatusProdMercadoLibre(data As String, idPublicacion As String)
         '-- Si ya Existe pero esta inactivo desactivo campaña-.
         Dim response = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Status)(data, SincroTiendaWebMetodos.PUT, Me.GetHeaders(), "items/" + idPublicacion)
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaMercadoLibre - Actualizando Variantes del Producto {0} - Método PUT.", idPublicacion), TraceEventType.Verbose)
      End Sub

      Public Function ConsultaProdMercadoLibre(idPublicacion As String) As String
         '-- Recupera el listado de Categorias de Mercado Libre.- --
         Dim response = GETResponse(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Status)(Me.GetHeaders(), "items/" + idPublicacion)
         '-- Informo el Estado.- --
         Return response.status
      End Function

      Public Function ConsultaCategoriaMLibre(idPublicacion As String) As Decimal
         '-- Recupera el listado de Categorias de Mercado Libre.- --
         Dim response = GETResponse(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Categories)(Me.GetHeaders(), "categories/" + idPublicacion)
         '-- Informo el Estado.- --
         Return response.settings.minimum_price
      End Function

      Public Sub SubirInformacion(reenviarTodo As Boolean, sincronizaProductos As Boolean, publicarPrecioPorEmbalaje As Boolean)
         _reenviarTodo = reenviarTodo

         '# Validación de Token
         '--------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.MERCADOLIBRE, "Validando Token..."))
         My.Application.Log.WriteEntry("Validando Token..", TraceEventType.Verbose)
         '--------------------------
         If String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreToken) Then
            My.Application.Log.WriteEntry("Token vacio.", TraceEventType.Verbose)
         Else
            '-- Publicacion de Productos.- --
            If sincronizaProductos Then SubirProductos(publicarPrecioPorEmbalaje)
            '--------------------------
         End If

      End Sub

      Private Function Enviar(Of T)(data As String, method As SincroTiendaWebMetodos, headers As Dictionary(Of String, String), relativeUri As String) As T
         Dim uri = New Uri(Me.MercadoLibreURLBase, relativeUri)
         '--------------------------------------------------------------------------------------
         GetPOSTResponse(uri, method.ToString(), data, headers, Sub(x)
                                                                   RestResponse = x
                                                                End Sub)
         '# Get the POST response
         Return DirectCast(New JavaScriptSerializer().Deserialize(RestResponse, GetType(T)), T)
         '--------------------------------------------------------------------------------------
      End Function

#End Region

#Region "Web Methods"
      Public Function GETResponse(Of T)(headers As Dictionary(Of String, String), relativeUri As String) As T
         Dim uri As Uri = New Uri(Me.MercadoLibreURLBase, relativeUri)
         Dim wc As New WebClient()

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
            MercadoLibreExceptionHelper.MercadoLibreExceptionHandler(ex)
         End Try
      End Function

      Private Sub GetPOSTResponse(uri As Uri, metodo As String, data As String, headers As Dictionary(Of String, String), callback As Action(Of String))

         Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)
         request.Method = metodo
         request.ContentType = "application/json"
         request.UserAgent = "SIGA(info@sinergiasoftware.com.ar)"
         request.Host = uri.Host

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
            MercadoLibreExceptionHelper.MercadoLibreExceptionHandler(ex)
         End Try
      End Sub

      '-- Obtiene el Token.- --
      Private Function GetHeaders() As Dictionary(Of String, String)
         Return GetHeaders(since_id:=0, onlyIds:=False)
      End Function
      Private Function GetHeaders(since_id As Long, onlyIds As Boolean) As Dictionary(Of String, String)
         Dim headers As Dictionary(Of String, String) = New Dictionary(Of String, String)
         headers.Add("Authorization", String.Format("Bearer {0}", Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreToken))
         Return headers
      End Function

      Private Function GetEndpoint(control As String, id As String) As String
         Dim stb = New StringBuilder(control)
         If id IsNot Nothing Then stb.AppendFormat("/{0}", id)

         Return stb.ToString()
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

#Region "Enum"
      Public Enum Controls
         categories
         products
         orders
      End Enum
#End Region

#Region "Responses"
      Public Class POSTResponseMercadoLibre
         Public Property id As String
         Public Property parent As String

      End Class
#End Region

   End Class

End Namespace
