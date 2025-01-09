Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Windows.Forms
Imports Eniac.Entidades

Namespace ServiciosRest.TiendasWeb

   Public Class SincronizacionArboreaExporter
      Private _numerador As New Dictionary(Of String, Long)()

      Private Property ExecutionId As String
      Private Sub New()
         ExecutionId = Date.Now.ToString("yyyyMMdd_HHmmss")
      End Sub

      Public Shared Function Crear() As SincronizacionArboreaExporter
         If Publicos.TiendasWeb.Arborea.ArboreaExportarSolicitudesSubida AndAlso
            Not String.IsNullOrWhiteSpace(Publicos.TiendasWeb.Arborea.ArboreaExportarSolicitudesSubidaPath) Then
            Dim dir = New DirectoryInfo(Publicos.TiendasWeb.Arborea.ArboreaExportarSolicitudesSubidaPath)
            If Not dir.Exists Then
               Try
                  dir.Create()
               Catch ex As Exception
                  'Si da error el directorio parámetro tiene un valor no válido o sin permisos
               End Try
            End If
            If dir.Exists Then
               Return New SincronizacionArboreaExporter()
            End If
         End If
         Return Nothing
      End Function

      Public Sub Exportar(modulo As String, uri As Uri, method As SincroTiendaWebMetodos, headers As HeadersDictionary, data As String)

         Dim archivo = New IO.FileInfo(Path.Combine(Publicos.TiendasWeb.Arborea.ArboreaExportarSolicitudesSubidaPath,
                                                    ExecutionId, modulo, String.Format("{0}_{1:00000000}.request", modulo, NextFileNumber(modulo))))
         If Not archivo.Directory.Exists Then
            archivo.Directory.Create()
         End If

         Dim stb = New StringBuilder("curl --location")
         stb.AppendFormatLine(" --request {0} '{1}' \", method, uri)
         headers.ToCurl(stb)
         If Not String.IsNullOrWhiteSpace(data) Then
            HeadersDictionary.ToCurl(stb, "Content-Type", "application/json")
            stb.AppendFormatLine(" --data-raw '{0}'", data)
         End If
         IO.File.WriteAllText(archivo.FullName, stb.ToString())

      End Sub

      Private Function NextFileNumber(modulo As String) As Long
         If Not _numerador.ContainsKey(modulo) Then
            _numerador.Add(modulo, 0)
         End If
         _numerador(modulo) += 1
         Return _numerador(modulo)
      End Function

   End Class

   Public Class SincronizacionArborea
      Inherits Base

      Public serializer As New JavaScriptSerializer()
      Private _logger As SincronizacionArboreaExporter

#Region "Propiedades"
      Private Property ArboreaURLBase As Uri
      Private Property ArboreaURLLPrecio As Uri
      Private Property ArboreaURLLPrecioClientes As Uri

      Private Property IdClienteArborea As String
      Private Property _reenviarTodo As Boolean
      Private Property _nuevosClientes As Integer
      Private Property _clientesPublicados As Integer
      Private Property RestResponse As String
      Private Property _nuevosProductos As Integer
      Private Property _productosActualizados As Integer
      Private Property _rebajarTodo As Boolean

      Public Event Avance(sender As Object, e As SincronizacionTiendaWebEventArgs)
      Public Event Estado(sender As Object, e As SincronizacionTiendaWebEstadoEventArgs)
      Public Event ProcesoFinalizado(sender As Object, e As SincronizacionTiendaWebProcesoFinalizadoEventArgs)
      Public Event InformarError(sender As Object, e As SincronizacionTiendaWebErrorEventArgs)
#End Region

#Region "Constructors"
      Public Sub New()
         Me.New(SincronizacionArboreaExporter.Crear())
      End Sub

      Private Sub New(accesoDatos As Datos.DataAccess, logger As SincronizacionArboreaExporter)
         da = accesoDatos
         _logger = logger
      End Sub
      Public Sub New(logger As SincronizacionArboreaExporter)
         Me.New(New Datos.DataAccess(), logger)

         If Not String.IsNullOrEmpty(Publicos.TiendasWeb.Arborea.ArboreaURLListaPrecios) Then
            ArboreaURLLPrecio = New Uri(Publicos.TiendasWeb.Arborea.ArboreaURLListaPrecios)
         Else
            Throw New Exception("ATENCIÓN: La URL Base para Arborea Lista de Precios, no se encuentra configurada.")
         End If
         '-- REQ-33743.- --------------------------------------------------------------------------------------------
         If Not String.IsNullOrEmpty(Publicos.TiendasWeb.Arborea.ArboreaURLListaPreciosClientes) Then
            ArboreaURLLPrecioClientes = New Uri(Publicos.TiendasWeb.Arborea.ArboreaURLListaPreciosClientes)
         End If
         '-----------------------------------------------------------------------------------------------------------
         If Not String.IsNullOrEmpty(Publicos.TiendasWeb.Arborea.ArboreaURLBase) Then
            ArboreaURLBase = New Uri(Publicos.TiendasWeb.Arborea.ArboreaURLBase)
         Else
            Throw New Exception("ATENCIÓN: La URL Base para Arborea no se encuentra configurada.")
         End If
         If String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.Arborea.ArboreaUsuarioToken) Then
            Throw New Exception("ATENCIÓN: Los Datos de Conexion para Arborea no estan disponible.")
         End If
      End Sub
#End Region

#Region "Methods"
      Private Sub TriggerEvent(estado As SincroTiendaWebEstados, verb As SincroTiendaWebMetodos, totalRegistros As Integer, nroRegistroSubiendo As Integer, queEstoySubiendo As String, countExitosos As Integer, countError As Integer)
         RaiseEvent estado(Me, New SincronizacionTiendaWebEstadoEventArgs(Entidades.TiendasWeb.ARBOREA, estado, verb, totalRegistros, nroRegistroSubiendo, queEstoySubiendo, countExitosos, countError))
      End Sub
      Protected Sub OnInformarError(elementoTransmitido As String, mensaje As String)
         RaiseEvent InformarError(Me, New SincronizacionTiendaWebErrorEventArgs(Entidades.TiendasWeb.ARBOREA, elementoTransmitido, mensaje))
      End Sub
      Public Function ReporteDeErrores() As String
         Dim rPTW = New PedidosTiendasWeb
         Dim reporteError = New StringBuilder

         Dim dt As DataTable = rPTW.GetPedidosAImportar("ARBOREA", {"ERROR"}, Nothing, desde:=Nothing, hasta:=Nothing, tipoFechaFiltro:=Nothing)

         If dt.Rows.Count = 0 Then Return Nothing

         With reporteError
            .AppendFormatLine("*** Se encontraron los siguientes ERRORES en el Proceso de Bajada de Pedidos de Arborea ***")
            .AppendFormatLine("<br>")
            For Each dr As DataRow In dt.Rows
               .AppendFormatLine("<br>  >> Id Pedido (Arborea): {0}", dr.Field(Of String)("Id"))
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

      Public Sub SincronizacionSubida(reenviarTodo As Boolean,
                                      sincronizaClientes As Boolean,
                                      sincronizaCategorias As Boolean,
                                      sincronizaProductos As Boolean,
                                      sincronizaPrecios As Boolean,
                                      PublicarPrecioPorEmbalaje As Boolean)
         '-- Carga la marca de ReenviarTodos.- --
         _reenviarTodo = reenviarTodo

         '# Validación de Token
         '--------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Validando Token..."))
         My.Application.Log.WriteEntry("Validando Token..", TraceEventType.Verbose)
         '--------------------------
         If String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.Arborea.ArboreaUsuarioToken) Then
            My.Application.Log.WriteEntry("Usuario vacio.", TraceEventType.Verbose)
         Else
            '-- Publicacion de Clientes.- ---------------------
            If sincronizaClientes Then PublicarClientes()
            '-- Publicacion de Categorias.- --
            If sincronizaCategorias Then PublicarCategorias()
            '-- Publicacion de Productos.- --
            If sincronizaProductos Then PublicarProductos(PublicarPrecioPorEmbalaje)
            '-- Publicacion de Listas de Precios.- --
            If sincronizaPrecios Then PublicaListaPrecios()
            '-- REQ-34699.- ------------------------------------------------------------------------------------------------------------------
            RaiseEvent ProcesoFinalizado(Me, New SincronizacionTiendaWebProcesoFinalizadoEventArgs(Entidades.TiendasWeb.ARBOREA, "Proceso de Subida finalizado correctamente !!!", _nuevosProductos, _productosActualizados))
            '---------------------------------------------------------------------------------------------------------------------------------

         End If
      End Sub
      '-- Incorpora Productos.- --
      ''' <summary>
      ''' Publica en Arborea las Listas de Precios.- --
      ''' </summary>
      Public Sub PublicaListaPrecios()
         '-- Publicar la lista de Precios.- --
         EjecutaConConexion(Sub() _PublicarListaPrecios())
         '--------------------------
      End Sub
      ''' <summary>
      ''' Nuevas Listas de Precios Alborea.- --
      ''' </summary>
      Public Sub _PublicarListaPrecios()
         '--------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Obteniendo información de las Listas de Precios..."))
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Comenzando la Subida de Listas de Precios."), TraceEventType.Information)
         '--------------------------------------------------------------------------------------------------------
         Dim serializer = New JavaScriptSerializer()
         Dim rProductos = New Productos(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         Dim dt As DataTable = rProductos.GetListasPreciosArborea(_reenviarTodo, Entidades.TiendasWeb.ARBOREA)

         Dim cotizacion = New Reglas.Monedas().GetUna(2).FactorConversion
         Dim tipo = Reglas.Publicos.PrecioProductoARB

         Dim cContador As Integer = 0
         Dim countExitoso = 0I
         Dim countError = 0I
         Dim data As String = String.Empty
         '--------------------------------------------------------------------------------------------------------
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - {0} Productos por subir desde la Última Sincronización.", dt.Rows.Count), TraceEventType.Verbose)
         '--------------------------------------------------------------------------------------------------------
         '# Listas de Precios.- ---
         For Each dr As DataRow In dt.Rows
            Try
#If SYNCTIENDAWEB <> "FALSE" Then
               '--- Carga las listas de Precio.- --
               Dim PrecioVenta As Decimal = dr.Field(Of Decimal)("PrecioVenta")
               Dim PrecioMayorista1 As Decimal = dr.Field(Of Decimal)("PrecioMayorista1")
               Dim PrecioMayorista2 As Decimal = dr.Field(Of Decimal)("PrecioMayorista2")
               Dim PrecioMayorista3 As Decimal = dr.Field(Of Decimal)("PrecioMayorista3")


               If tipo = Reglas.Publicos.MonedaProductoTiendasWeb.PESOS.ToString() And
                     dr.Field(Of Integer)("IdMoneda") = Reglas.Publicos.MonedaProductoTiendasWeb.DOLARES Then
                  PrecioVenta *= cotizacion
                  PrecioMayorista1 *= cotizacion
                  PrecioMayorista2 *= cotizacion
                  PrecioMayorista3 *= cotizacion
               ElseIf tipo = Reglas.Publicos.MonedaProductoTiendasWeb.DOLARES.ToString() And
                     dr.Field(Of Integer)("IdMoneda") = Reglas.Publicos.MonedaProductoTiendasWeb.PESOS Then
                  PrecioVenta /= cotizacion
                  PrecioMayorista1 /= cotizacion
                  PrecioMayorista2 /= cotizacion
                  PrecioMayorista3 /= cotizacion
               End If

               '-- REQ-34145.- -- Adicionamos Campo de Stock para Actualizacion de Stock.- ---------------------------
               Dim ListasPrecios = New With
               {
                  .IdProducto = dr.Field(Of String)("IdProducto").ToString(),              '-- Id de Producto.-
                  .STOCK = dr.Field(Of Decimal)("StockProducto").ToString(),               '-- Stock del Producto.-
                  .SKU = dr.Field(Of String)("SkuProducto").ToString(),                    '-- Sku del Producto.-
                  .Estado = dr.Field(Of String)("Condicion").ToString(),                   '-- Estado del Producto.-
                  .PrecioVenta = PrecioVenta.ToString("N2"),                               '-- Precio de Venta.-
                  .PrecioMayorista1 = PrecioMayorista1.ToString("N2"),                     '-- Precio Mayorista 01.-
                  .PrecioMayorista2 = PrecioMayorista2.ToString("N2"),                     '-- Precio Mayorista 02.-
                  .PrecioMayorista3 = PrecioMayorista3.ToString("N2")                      '-- Precio Mayorista 03.-
               }


               '------------------------------------------------------------------------------------------------------
               '-- Armo el JSON y Lo convierto a String
               data = serializer.Serialize(ListasPrecios)
               '-- Carga las Listas de Precios Arborea.-
               CargaListasPrecios(data, dr, dt.Rows.Count)
#Else
               Threading.Thread.Sleep(500)
               If cContador Mod 3 = 0 Then
                  Throw New Exception("Excepción de prueba")
               End If
#End If
               countExitoso += 1
               '--------------------------'--------------------------'--------------------------'--------------------------
               RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, String.Format("Subiendo Lista de Precios {0} de {1}.", countExitoso, dt.Count)))
               '--------------------------'--------------------------'--------------------------'--------------------------
            Catch ex As Exception
               countError += 1
               OnInformarError(String.Format("LP IdProducto='{0}'", dr.Field(Of String)("SkuProducto")), ex.Message)
               'arbMensaje.AppendFormat("Error enviando Lista de Precios de Producto {0} : {1}{2}",
               '                     dr.Field(Of String)("IdProducto").ToString(),
               '                     Environment.NewLine, ex.Message)
            End Try
         Next
         '-----------------------------
         '# Informo estado dee Avance.- 
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Listas de Precios subidas correctamente."))

      End Sub

      Public Sub CargaListasPrecios(data As String, dr As DataRow, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Actualizar(Of Entidades.JSonEntidades.TiendasWeb.Arborea.CategoriasResponse)(data, SincroTiendaWebMetodos.POST, Me.GetHeaders(), "", "precios")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Cargando Publicacion {0} de {1}.", response.id, CantidadReg), TraceEventType.Verbose)
      End Sub

      Public Sub CargaListasPreciosClientes(data As String, dr As DataRow, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Me.ActualizarClientes(Of Entidades.JSonEntidades.TiendasWeb.Arborea.CategoriasResponse)(data, SincroTiendaWebMetodos.POST, Me.GetHeaders(), "", "clientes")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Cargando Publicacion {0} de {1}.", response.id, CantidadReg), TraceEventType.Verbose)
      End Sub

      '-- Incorpora Productos.- --
      ''' <summary>
      ''' Publica en Arborea los Productos.- --
      ''' </summary>
      Public Sub PublicarProductos(publicarPrecioPorEmbalaje As Boolean)
         '-- Publicar la lista de Categorias SIGA.- --
         EjecutaConConexion(Sub() _PublicarProductos(publicarPrecioPorEmbalaje))
         '--------------------------
      End Sub
      ''' <summary>
      ''' Nuevos Productos Alborea.- --
      ''' </summary>
      Public Sub _PublicarProductos(publicarPrecioPorEmbalaje As Boolean)
         '--------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Obteniendo información de los Productos..."))
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Comenzando la Subida de Productos."), TraceEventType.Information)
         '--------------------------------------------------------------------------------------------------------
         _nuevosProductos = 0
         _productosActualizados = 0
         Dim cContador As Integer = 0
         Dim countExitoso = 0I
         Dim countError = 0I
         '--------------------------------------------------------------------------------------------------------
         Dim serializer = New JavaScriptSerializer()
         Dim rProductos = New Productos(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         Dim dt As DataTable = rProductos.GetProductosTiendaWeb(_reenviarTodo, Entidades.TiendasWeb.ARBOREA, publicarPrecioPorEmbalaje)
         Dim sCondicion As String
         '--------------------------------------------------------------------------------------------------------
         Dim mensaje = String.Format("SubidaArborea - {0} Productos por subir desde la Última Sincronización.", dt.Rows.Count)
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, mensaje))
         My.Application.Log.WriteEntry(String.Format(mensaje, TraceEventType.Verbose))
         '--------------------------------------------------------------------------------------------------------
         '# Productos
         For Each dr As DataRow In dt.Rows

            cContador += 1
            '-- Obtiene Condicion del Producto.- ---------------------------------------------------------------------
            sCondicion = dr.Field(Of String)("Condicion")
            '---------------------------------------------------------------------------------------------------------
            Dim data As String = String.Empty
            '-- Descarga Codigo de Producto Arborea de Existir.- -----------------------------------------------------
            Dim CodigoArborea = dr.Field(Of String)("CodigoProductoArborea")
            '---------------------------------------------------------------------------------------------------------

            mensaje = String.Format("Subiendo producto {0} - {1} - {2} - {3}", sCondicion, CodigoArborea, dr.Field(Of String)("IdProducto"), dr.Field(Of String)("name"))
            RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, mensaje))
            My.Application.Log.WriteEntry(String.Format(mensaje, TraceEventType.Verbose))

            Try
#If SYNCTIENDAWEB <> "FALSE" Then
               '-- Categorias Arborea.- ------------------------------------------------------------------------
               Dim actCategoria = Publicos.ActualizacionCategoriasARB
               '-- Define Variable Parent.- --------------------------------------------------------------------
               Dim oParent As Integer
               Dim oCategorias = New Object
               Dim oAttributos = New Object
               '-- Attributos.- --------------------------------------------------------------------------------
               Dim oAttrib = {New With {.id = CInt(Reglas.Publicos.TiendasWeb.Arborea.ArboreaImportaMarcasID),
                                        .visible = True,
                                        .options = dr.Field(Of String)("brand").ToUpper()
                             }}
               oAttributos = oAttrib
               '-- Categorias.- --------------------------------------------------------------------------------
               If Not String.IsNullOrWhiteSpace(dr.Field(Of String)("IdSubSubRubroArborea")) Then
                  oParent = CInt(dr.Field(Of String)("IdSubSubRubroArborea"))
                  ''-- Carga Atributos de Marca y Modelo N/A.- --
                  Dim oCatego = {New With {.id = CInt(dr.Field(Of String)("IdSubSubRubroArborea"))},
                                 New With {.id = CInt(dr.Field(Of String)("IdSubRubroArborea"))},
                                 New With {.id = CInt(dr.Field(Of String)("IdRubroArborea"))}}
                  oCategorias = oCatego
               ElseIf Not String.IsNullOrWhiteSpace(dr.Field(Of String)("IdSubRubroArborea")) Then
                  oParent = CInt(dr.Field(Of String)("IdSubRubroArborea"))
                  ''-- Carga Atributos de Marca y Modelo N/A.- --
                  Dim oCatego = {New With {.id = CInt(dr.Field(Of String)("IdSubRubroArborea"))},
                                 New With {.id = CInt(dr.Field(Of String)("IdRubroArborea"))}}
                  oCategorias = oCatego
               Else
                  oParent = CInt(dr.Field(Of String)("IdRubroArborea"))
                  ''-- Carga Atributos de Marca y Modelo N/A.- --
                  Dim oCatego = {New With {.id = CInt(dr.Field(Of String)("IdRubroArborea"))}}
                  oCategorias = oCatego
               End If
               '------------------------------------------------------------------------------------------------
               Select Case sCondicion
                  Case "new"
                     '-- Carga Producto Final.- --
                     If actCategoria = Publicos.ActualizarTiendasWeb.NUNCA.ToString() Or actCategoria = Publicos.ActualizarTiendasWeb.MODIFICA.ToString() Then
                        If Publicos.TiendasWeb.Arborea.ArboreaImportaMarcas Then
                           Dim Producto = New With
                              {
                                 .name = Replace(dr.Field(Of String)("name"), "'", ""),                        '-- Nombre del Producto.-
                                 .type = "simple",                                                             '-- Tipo de Producto.-
                                 .description = Replace(dr.Field(Of String)("description"), "'", ""),          '-- Descripcion del Producto.-
                                 .short_description = Replace(dr.Field(Of String)("NombreCorto"), "'", ""),    '-- Descripcion corta del Producto.-
                                 .shipping_required = True,                                                    '-- Requierte Shiping.-
                                 .attributes = oAttributos
                              }
                           '-- Armo el JSON y Lo convierto a String
                           data = serializer.Serialize(Producto)
                        Else
                           Dim Producto = New With
                              {
                                 .name = Replace(dr.Field(Of String)("name"), "'", ""),                        '-- Nombre del Producto.-
                                 .type = "simple",                                                             '-- Tipo de Producto.-
                                 .description = Replace(dr.Field(Of String)("description"), "'", ""),          '-- Descripcion del Producto.-
                                 .short_description = Replace(dr.Field(Of String)("NombreCorto"), "'", ""),    '-- Descripcion corta del Producto.-
                                 .shipping_required = True                                                    '-- Requierte Shiping.-
                              }
                           '-- Armo el JSON y Lo convierto a String
                           data = serializer.Serialize(Producto)
                        End If
                     Else
                        If Publicos.TiendasWeb.Arborea.ArboreaImportaMarcas Then
                           Dim Producto = New With
                           {
                              .name = Replace(dr.Field(Of String)("name"), "'", ""),                        '-- Nombre del Producto.-
                              .type = "simple",                                                             '-- Tipo de Producto.-
                              .description = Replace(dr.Field(Of String)("description"), "'", ""),          '-- Descripcion del Producto.-
                              .short_description = Replace(dr.Field(Of String)("NombreCorto"), "'", ""),    '-- Descripcion corta del Producto.-
                              .shipping_required = True,                                                    '-- Requierte Shiping.-
                              .parent = oParent,                                                            '-- Paren de Enlace.-
                              .categories = oCategorias,                                                     '-- Categorias.-
                              .attributes = oAttributos
                           }
                           '-- Armo el JSON y Lo convierto a String
                           data = serializer.Serialize(Producto)
                        Else
                           Dim Producto = New With
                           {
                              .name = Replace(dr.Field(Of String)("name"), "'", ""),                        '-- Nombre del Producto.-
                              .type = "simple",                                                             '-- Tipo de Producto.-
                              .description = Replace(dr.Field(Of String)("description"), "'", ""),          '-- Descripcion del Producto.-
                              .short_description = Replace(dr.Field(Of String)("NombreCorto"), "'", ""),    '-- Descripcion corta del Producto.-
                              .shipping_required = True,                                                    '-- Requierte Shiping.-
                              .parent = oParent,                                                            '-- Paren de Enlace.-
                              .categories = oCategorias                                                     '-- Categorias.-
                           }
                           '-- Armo el JSON y Lo convierto a String
                           data = serializer.Serialize(Producto)
                        End If
                     End If
                     '-- Si es nuevo Cargo todos sus datos a Arborea.-
                     CargaNuevoProducto(data, dr, dt.Rows.Count)
                     '-- Actualiza Contador.- -----------------------------------------------------------------------
                     _nuevosProductos += 1
                     '-----------------------------------------------------------------------------------------------
                  Case "update"
                     '-- Carga Producto Final.- --
                     If actCategoria = Publicos.ActualizarTiendasWeb.NUNCA.ToString() Or actCategoria = Publicos.ActualizarTiendasWeb.ALTA.ToString() Then
                        If Publicos.TiendasWeb.Arborea.ArboreaImportaMarcas Then
                           Dim Producto = New With
                              {
                                 .name = Replace(dr.Field(Of String)("name"), "'", ""),                        '-- Nombre del Producto.-
                                 .short_description = Replace(dr.Field(Of String)("NombreCorto"), "'", ""),     '-- Descripcion corta del Producto.-
                                 .attributes = oAttributos
                              }
                           '-- Armo el JSON y Lo convierto a String
                           data = serializer.Serialize(Producto)
                        Else
                           Dim Producto = New With
                              {
                                 .name = Replace(dr.Field(Of String)("name"), "'", ""),                        '-- Nombre del Producto.-
                                 .short_description = Replace(dr.Field(Of String)("NombreCorto"), "'", "")     '-- Descripcion corta del Producto.-
                              }
                           '-- Armo el JSON y Lo convierto a String
                           data = serializer.Serialize(Producto)
                        End If
                     Else
                        If Publicos.TiendasWeb.Arborea.ArboreaImportaMarcas Then
                           Dim Producto = New With
                                 {
                                    .name = Replace(dr.Field(Of String)("name"), "'", ""),                        '-- Nombre del Producto.-
                                    .short_description = Replace(dr.Field(Of String)("NombreCorto"), "'", ""),    '-- Descripcion corta del Producto.-
                                    .parent = oParent,                                                            '-- Paren de Enlace.-
                                    .categories = oCategorias,
                                    .attributes = oAttributos
                                 }
                           '-- Armo el JSON y Lo convierto a String
                           data = serializer.Serialize(Producto)
                        Else
                           Dim Producto = New With
                                 {
                                    .name = Replace(dr.Field(Of String)("name"), "'", ""),                        '-- Nombre del Producto.-
                                    .short_description = Replace(dr.Field(Of String)("NombreCorto"), "'", ""),    '-- Descripcion corta del Producto.-
                                    .parent = oParent,                                                            '-- Paren de Enlace.-
                                    .categories = oCategorias
                                 }
                           '-- Armo el JSON y Lo convierto a String
                           data = serializer.Serialize(Producto)
                        End If
                     End If
                     '-- Si ya Existe Modifico sus datos Principales.
                     UpdateProductosArborea(data, CodigoArborea, dr.Field(Of String)("IdProducto"))
                     '-----------------------------------------------------------------------------------------------
                     _productosActualizados += 1
                     '-----------------------------------------------------------------------------------------------
               End Select
               My.Application.Log.WriteEntry(String.Format("SubidaArborea - JSON: {0}", data), TraceEventType.Verbose)
#Else
               Threading.Thread.Sleep(500)
               If cContador Mod 3 = 0 Then
                  Throw New Exception("Excepción de prueba")
               End If
#End If
               countExitoso += 1
            Catch ex As Exception
               countError += 1
               OnInformarError(String.Format("IdProducto='{0}'", dr.Field(Of String)("IdProducto")), ex.Message)

               'arbMensaje.AppendFormat("Error enviando Publicacion {0} - {1}: {2}{2}{3}",
               '                        CodigoArborea,
               '                        dr.Field(Of String)("IdProducto"),
               '                        Environment.NewLine, ex.Message)
            End Try
            TriggerEvent(SincroTiendaWebEstados.Subiendo,
                         If(sCondicion = "new", SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                         dt.Rows.Count, cContador, "PRODUCTOS", countExitoso, countError)
            '--------------------------'--------------------------'--------------------------'--------------------------
            RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, String.Format("Subiendo Productos {0} de {1}.", cContador, dt.Count)))
            '--------------------------'--------------------------'--------------------------'--------------------------
         Next
         '--------------------------
         '# Guardo la fecha de sincronización 
         My.Application.Log.WriteEntry(String.Format("SubidaArborea.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.Producto.NombreTabla), TraceEventType.Information)
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString(),
                                                                          .Tabla = Entidades.Producto.NombreTabla,
                                                                          .FechaActualizacion = Now,
                                                                          .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
                                                                          .IdUsuario = actual.Nombre,
                                                                          .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Productos subidos correctamente."))
         '--------------------------

      End Sub
      ''' <summary>
      ''' Carga un nuevo Producto Arborea.-
      ''' </summary>
      Public Sub CargaNuevoProducto(data As String, dr As DataRow, CantidadReg As Integer)
         Dim rProductos = New Productos(da)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Enviar(Of Entidades.JSonEntidades.TiendasWeb.Arborea.CategoriasResponse)(data, SincroTiendaWebMetodos.POST, Me.GetHeaders(), "products", "productos")
         '-- Guardo Valor de ID Mercado libre'
         rProductos.GuardarIdProductoTiendaWeb("Arborea", dr.Field(Of String)("IdProducto"), response.id)
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Cargando Publicacion {0} de {1}.", response.id, CantidadReg), TraceEventType.Verbose)
      End Sub
      Public Sub UpdateProductosArborea(data As String, idProductoArborea As String, idProductoSiga As String)
         Dim rProductos = New Productos(da)
         '-- Si ya Existe Modifico sus datos Principales.
         Dim response = Enviar(Of Entidades.JSonEntidades.TiendasWeb.Mercadolibre.Actualizaciones)(data, SincroTiendaWebMetodos.PUT, Me.GetHeaders(), "products/" + idProductoArborea, "productos")

         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Actualizando Variantes del Producto {0} - Método PUT.", idProductoArborea), TraceEventType.Verbose)
      End Sub


      '-- Incorpora Categorias (rubros-subrubros-subsubrubros).- --
      ''' <summary>
      ''' Publica en Arborea las Categorias.- --
      ''' </summary>
      Public Sub PublicarCategorias()
         '-- Publicar la lista de Categorias SIGA.- --
         EjecutaConConexion(Sub() _PublicarCategorias())
         '--------------------------
      End Sub
      ''' <summary>
      ''' Nueva Categorias Arborea.- --
      ''' </summary>
      Public Sub _PublicarCategorias()

         '--------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Obteniendo información de las Categorías..."))
         '--------------------------------------------------------------------------------------------------------
         Dim serializer = New JavaScriptSerializer()
         '--------------------------------------------------------------------------------------------------------
         Dim rRubros = New Rubros(da)
         Dim rSRubros = New SubRubros(da)
         Dim rSSRubros = New SubSubRubros(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         Dim rProductos = New Productos
         Dim dt = If(Reglas.Publicos.TiendasWeb.Arborea.ArboreasincronizaCategorias, rRubros.GetRubrosTiendasWeb(Entidades.TiendasWeb.ARBOREA), Nothing)
         '--------------------------------------------------------------------------------------------------------
         Dim cContador = 0I
         Dim countExitoso = 0I
         Dim countError = 0I
         '# Rubros
         '--------------------------------------------------------------------------------------------------------
         If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Subiendo Rubros SIGA..."))
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - {0} Rubros por subir.", dt.Rows.Count), TraceEventType.Information)
            '--------------------------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------------------------------------
            For Each dr As DataRow In dt.Rows
               '-- Actualiza Contador de Rubros.- --
               cContador += 1
               '--------------------------------------------------------------------------------------------------------
               '-- Carga la imagen Default.- --
               Dim Imagenes = New With {.src = ""}

               Dim x = New With
               {
                  .name = dr.Field(Of String)(Entidades.Rubro.Columnas.NombreRubro.ToString()),
                  .parent = Publicos.TiendasWeb.Arborea.ArboreaCategoriaPrincipal,
                  .images = {Imagenes}.ToList()
               }
               Dim data = serializer.Serialize(x)
               '--------------------------------------------------------------------------------------------------------
               TriggerEvent(SincroTiendaWebEstados.Subiendo,
                         If(dr.Field(Of String)(Entidades.Rubro.Columnas.idRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                         dt.Rows.Count, cContador, "RUBROS", countExitoso, countError)
               '--------------------------------------------------------------------------------------------------------
               Try
#If SYNCTIENDAWEB <> "FALSE" Then
                  Dim response = Enviar(Of Entidades.JSonEntidades.TiendasWeb.Arborea.CategoriasResponse)(
                                             data,
                                             If(dr.Field(Of String)(Entidades.Rubro.Columnas.idRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                                             GetHeaders(),
                                             If(dr.Field(Of String)(Entidades.Rubro.Columnas.idRubroArborea.ToString()) Is Nothing,
                                             "products/categories",
                                             "products/categories/" + dr.Field(Of String)(Entidades.Rubro.Columnas.idRubroArborea.ToString())),
                                             "categorias")
                  '--------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaArborea - Guardando IdRubroArborea {0} del Rubro {1}.", response.id, dr.Field(Of Integer)(Entidades.Rubro.Columnas.IdRubro.ToString())), TraceEventType.Information)
                  rRubros.GuardarIdRubroTiendaWeb("Arborea", dr.Field(Of Integer)(Entidades.Rubro.Columnas.IdRubro.ToString()), response.id)
                  '--------------------------'--------------------------'--------------------------'--------------------------
                  RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, String.Format("Subiendo Rubros {0} de {1}.", cContador, dt.Count)))
                  '--------------------------'--------------------------'--------------------------'--------------------------
#Else
               If cContador Mod 3 = 0 Then
                  Throw New Exception("Prueba de error")
               End If
#End If
                  countExitoso += 1
               Catch ex As Exception
                  countError += 1
                  OnInformarError(String.Format("Rubro='{0}'", dr.Field(Of Integer)(Entidades.Rubro.Columnas.IdRubro.ToString())), ex.Message)
                  'arbMensaje.AppendFormat("Error enviando Rubro {0} - {1}: {2}{2}{3}",
                  '                        dr.Field(Of Integer)(Entidades.Rubro.Columnas.IdRubro.ToString()),
                  '                        dr.Field(Of String)(Entidades.Rubro.Columnas.NombreRubro.ToString()),
                  '                        Environment.NewLine, ex.Message)
               End Try
               '--------------------------------------------------------------------------------------------------------
               TriggerEvent(SincroTiendaWebEstados.Subiendo,
                         If(dr.Field(Of String)(Entidades.Rubro.Columnas.idRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                         dt.Rows.Count, cContador, "RUBROS", countExitoso, countError)
            Next
            '# Guardo la fecha de sincronización 
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - Guardando Fecha de Última Sincronización - Tabla {0}", Entidades.Rubro.NombreTabla), TraceEventType.Information)

#If SYNCTIENDAWEB <> "FALSE" Then
            rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString(),
                                                                          .Tabla = Entidades.Rubro.NombreTabla,
                                                                          .FechaActualizacion = Now,
                                                                          .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
                                                                          .IdUsuario = actual.Nombre,
                                                                          .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
#End If
            '--------------------------------------------------------------------------------------------------------
            cContador = 0
            countExitoso = 0
            countError = 0

            '# SubRubros
            '--------------------------------------------------------------------------------------------------------
            dt = rSRubros.GetSubRubrosTiendaWeb(Entidades.TiendasWeb.ARBOREA)
            '--------------------------------------------------------------------------------------------------------
            If dt.Rows.Count > 0 Then RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Subiendo Sub Rubros SIGA..."))
            '--------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - {0} SubRubros por subir.", dt.Rows.Count), TraceEventType.Information)
            '--------------------------------------------------------------------------------------------------------
            For Each dr As DataRow In dt.Rows
               '-- Actualiza Contador de SubRubros.- --
               cContador += 1
               '--------------------------------------------------------------------------------------------------------
               '-- Carga la imagen Default.- --
               Dim Imagenes = New With {.src = ""}
               '--------------------------------------------------------------------------------------------------------
               Dim x = New With
               {
                  .name = dr.Field(Of String)(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()),
                  .parent = dr.Field(Of String)(Entidades.Rubro.Columnas.idRubroArborea.ToString()),
                  .images = {Imagenes}.ToList()
               }
               Dim data = serializer.Serialize(x)
               '--------------------------------------------------------------------------------------------------------
               TriggerEvent(SincroTiendaWebEstados.Subiendo,
                         If(dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                         dt.Rows.Count, cContador, "SUBRUBROS", countExitoso, countError)
               '--------------------------------------------------------------------------------------------------------
               Try
#If SYNCTIENDAWEB <> "FALSE" Then
                  Dim response = Enviar(Of Entidades.JSonEntidades.TiendasWeb.Arborea.CategoriasResponse)(
                                             data,
                                             If(dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                                             GetHeaders(),
                                             If(dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString()) Is Nothing,
                                             "products/categories",
                                             "products/categories/" + dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString())),
                                             "categorias")

                  My.Application.Log.WriteEntry(String.Format("SubidaArborea - Guardando IDSubRubroArborea {0} del SubRubro {1}.",
                                                           response.id,
                                                           dr.Field(Of Integer)(Entidades.SubRubro.Columnas.IdSubRubro.ToString())),
                                             TraceEventType.Information)
                  rSRubros.GuardarIdSubRubroTiendaWeb("Arborea",
                                                   dr.Field(Of Integer)(Entidades.SubRubro.Columnas.IdSubRubro.ToString()),
                                                   response.id)
                  '--------------------------'--------------------------'--------------------------'--------------------------
                  RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, String.Format("Subiendo SubRubros {0} de {1}.", cContador, dt.Count)))
                  '--------------------------'--------------------------'--------------------------'--------------------------
#Else
               If cContador Mod 3 = 0 Then
                  Throw New Exception("Prueba de error")
               End If
#End If
                  countExitoso += 1
               Catch ex As Exception
                  countError += 1
                  OnInformarError(String.Format("SubRubro='{0}'", dr.Field(Of Integer)(Entidades.SubRubro.Columnas.IdSubRubro.ToString())), ex.Message)
                  'arbMensaje.AppendFormat("Error enviando SubRubros {0} - {1}: {2}{2}{3}",
                  '                        dr.Field(Of Integer)(Entidades.SubRubro.Columnas.IdSubRubro.ToString()),
                  '                        dr.Field(Of String)(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()),
                  '                        Environment.NewLine, ex.Message)
               End Try
               TriggerEvent(SincroTiendaWebEstados.Subiendo,
                         If(dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                         dt.Rows.Count, cContador, "SUBRUBROS", countExitoso, countError)
            Next
            '# Guardo la fecha de sincronización 
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - Guardando Fecha de Última Sincronización - Tabla {0}", Entidades.SubRubro.NombreTabla), TraceEventType.Information)
            '--------------------------------------------------------------------------------------------------------
#If SYNCTIENDAWEB <> "FALSE" Then
            rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString(),
                                                                          .Tabla = Entidades.SubRubro.NombreTabla,
                                                                          .FechaActualizacion = Now,
                                                                          .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
                                                                          .IdUsuario = actual.Nombre,
                                                                          .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
#End If
            '--------------------------------------------------------------------------------------------------------
            cContador = 0
            countExitoso = 0
            countError = 0

            '# SubSubRubros
            '--------------------------------------------------------------------------------------------------------
            dt = rSSRubros.GetSubSubRubrosTiendaWeb(Entidades.TiendasWeb.ARBOREA)
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - {0} SubSubRubros por subir.", dt.Rows.Count), TraceEventType.Information)

            For Each dr As DataRow In dt.Rows
               cContador += 1
               '--------------------------------------------------------------------------------------------------------
               '-- Carga la imagen Default.- --
               Dim Imagenes = New With {.src = ""}
               '--------------------------------------------------------------------------------------------------------
               Dim x = New With
               {
                  .name = dr.Field(Of String)(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()),
                  .parent = dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString()),
                  .images = {Imagenes}.ToList()
               }
               Dim data = serializer.Serialize(x)
               '--------------------------------------------------------------------------------------------------------
               TriggerEvent(SincroTiendaWebEstados.Subiendo,
                         If(dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                         dt.Rows.Count, cContador, "SUBSUBRUBROS", countExitoso, countError)
               '--------------------------------------------------------------------------------------------------------
               Try
#If SYNCTIENDAWEB <> "FALSE" Then
                  Dim response = Enviar(Of Entidades.JSonEntidades.TiendasWeb.Arborea.CategoriasResponse)(
                                             data,
                                             If(dr.Field(Of String)(Entidades.SubSubRubro.Columnas.IdSubSubRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                                             GetHeaders(),
                                             If(dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString()) Is Nothing,
                                             "products/categories",
                                             "products/categories/" + dr.Field(Of String)(Entidades.SubSubRubro.Columnas.IdSubSubRubroArborea.ToString())),
                                             "categorias")
                  '--------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaArborea - Guardando IDSubSubRubroArborea {0} del SubSubRubro {1}.",
                                                           response.id,
                                                           dr.Field(Of Integer)(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString())),
                                             TraceEventType.Information)
                  '--------------------------------------------------------------------------------------------------------
                  rSSRubros.GuardarIdSubSubRubroTiendaweb("Arborea",
                                                       dr.Field(Of Integer)(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString()),
                                                       response.id)
                  '--------------------------------------------------------------------------------------------------------
                  RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, String.Format("Subiendo SubSubRubros {0} de {1}.", cContador, dt.Count)))
                  '--------------------------'--------------------------'--------------------------'--------------------------
#Else
               If cContador Mod 3 = 0 Then
                  Throw New Exception("Prueba de error")
               End If
#End If
                  countExitoso += 1
               Catch ex As Exception
                  countError += 1
                  OnInformarError(String.Format("SubSubRubro='{0}'", dr.Field(Of Integer)(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString())), ex.Message)
                  'arbMensaje.AppendFormat("Error enviando SubSubRubros {0} - {1}: {2}{2}{3}",
                  '                        dr.Field(Of Integer)(Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString()),
                  '                        dr.Field(Of String)(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()),
                  '                        Environment.NewLine, ex.Message)
               End Try
               TriggerEvent(SincroTiendaWebEstados.Subiendo,
                         If(dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString()) Is Nothing, SincroTiendaWebMetodos.POST, SincroTiendaWebMetodos.PUT),
                         dt.Rows.Count, cContador, "SUBSUBRUBROS", countExitoso, countError)
            Next

            '# Guardo la fecha de sincronización 
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - Guardando Fecha de Última Sincronización - Tabla {0}", Entidades.SubSubRubro.NombreTabla), TraceEventType.Information)
            '--------------------------------------------------------------------------------------------------------
            rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString(),
                                                                          .Tabla = Entidades.SubSubRubro.NombreTabla,
                                                                          .FechaActualizacion = Now,
                                                                          .FechaSubida = rProductos.GetMaxFechaActualizacionWeb(),
                                                                          .IdUsuario = actual.Nombre,
                                                                          .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
            '--------------------------------------------------------------------------------------------------------
         End If
      End Sub

      '-- Incorpora Nuevo Cliente.- --
      ''' <summary>
      ''' Publica en Arborea los Clientes SIGA.- --
      ''' </summary>
      Public Sub PublicarClientes()
         '-- Publicar la lista de Clientes SIGA.- --
         EjecutaConConexion(Sub() _PublicarClientes())
         '--------------------------
      End Sub
      Public Sub _PublicarClientes()
         '--------------------------
         Dim sCondicion As String
         Dim rSincronizaciones = New Reglas.FechasSincronizaciones(da)
         Dim rClientes = New Clientes(da)
         Dim count = 0I
         Dim countExitoso = 0I
         Dim countError = 0I
         '--------------------------

         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Obteniendo información de los Clientes..."))
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Comenzando la Subida de Clientes."), TraceEventType.Information)
         '--------------------------

         '-- Obtener Todos los Productos a Subir para Mercado Libre.- -----------------------------------------------
         Dim dt As DataTable = rClientes.GetClientesTiendaWeb(_reenviarTodo, Entidades.TiendasWeb.ARBOREA)
         '--------------------------'--------------------------'--------------------------'--------------------------
         My.Application.Log.WriteEntry(String.Format("SubidaClientesArborea - {0} Clientes por subir desde la Última Sincronización.", dt.Rows.Count), TraceEventType.Verbose)
         '--------------------------'--------------------------'--------------------------'--------------------------
         '-- Recupera Cantidad de Registros.- --
         _nuevosClientes = dt.Rows.Count()

         For Each dr As DataRow In dt.Rows
            count += 1

            '-- Descarga Codigo de Mercado Libre de Existir.- --
            Dim ClienteArborea = CInt(dr("idCliente"))

            Dim data As String = String.Empty
            '--------------------------
            TriggerEvent(SincroTiendaWebEstados.Subiendo, SincroTiendaWebMetodos.POST, dt.Rows.Count, count, "CLIENTES", countExitoso, countError)
            '--------------------------
            '-- Descarga Condiciones.- --
            sCondicion = dr.Field(Of String)("condition")
            '-- Verifica Correos.- --
            Dim oCorreos = dr.Field(Of String)("email").Split(New Char() {";"c})
            Try
#If SYNCTIENDAWEB <> "FALSE" Then
               '-- REQ-33613.- ----
               If Not Publicos.IsValidEmail(oCorreos(0)) Then
                  Throw New Exception("Dirección de Correo Inválida.-")
               End If
               '-------------------
               Select Case sCondicion
                  Case "update"
                     Dim Cliente = New With
                        {
                           .first_name = Replace(dr.Field(Of String)("first_name"), "'", ""),      '-- Primer Nombre.- --
                           .last_name = Replace(dr.Field(Of String)("last_name"), "'", "")         '-- Apellido.- --
                        }
                     '-- Armo el JSON y Lo convierto a String
                     data = serializer.Serialize(Cliente)
                     '-- Actualiza Los datos de Clientes.- --
                     UpdateProdCliente(data, dr("idClienteArborea").ToString())
                     '-- REG-33743.- ------------------------------------------
                     IdClienteArborea = dr("idClienteArborea").ToString()
                     '---------------------------------------------------------
                  Case "new"
                     '-- Carga la imagen Default.- --
                     Dim oBilling = New With
                        {
                           .first_name = Replace(dr.Field(Of String)("first_name"), "'", ""),
                           .last_name = Replace(dr.Field(Of String)("last_name"), "'", ""),
                           .company = dr.Field(Of String)("company"),
                           .address_1 = Replace(dr.Field(Of String)("address_1"), "'", ""),
                           .address_2 = Replace(dr.Field(Of String)("address_2"), "'", ""),
                           .city = Replace(dr.Field(Of String)("city"), "'", ""),
                           .state = dr.Field(Of String)("state"),
                           .postcode = dr.Field(Of Integer)("postcode"),
                           .country = dr.Field(Of String)("country"),
                           .email = Replace(oCorreos(0), "'", ""),
                           .phone = dr.Field(Of String)("phone")
                        }
                     '-- Carga la Garantia Default.- --
                     Dim oShipping = New With
                        {
                           .first_name = Replace(dr.Field(Of String)("first_name"), "'", ""),
                           .last_name = Replace(dr.Field(Of String)("last_name"), "'", ""),
                           .company = dr.Field(Of String)("company"),
                           .address_1 = Replace(dr.Field(Of String)("address_1"), "'", ""),
                           .address_2 = Replace(dr.Field(Of String)("address_2"), "'", ""),
                           .city = Replace(dr.Field(Of String)("city"), "'", ""),
                           .state = dr.Field(Of String)("state"),
                           .postcode = dr.Field(Of Integer)("postcode"),
                           .country = dr.Field(Of String)("country")
                        }
                     '-- Carga Producto Final.- --
                     Dim Cliente = New With
                        {
                           .email = Replace(oCorreos(0), "'", ""),                                 '-- Email Cliente.- --
                           .first_name = Replace(dr.Field(Of String)("first_name"), "'", ""),      '-- Primer Nombre.- --
                           .last_name = Replace(dr.Field(Of String)("last_name"), "'", ""),        '-- Apellido.- --
                           .username = Replace(oCorreos(0), "'", ""),                              '-- Usuario.- --
                           .billing = {oBilling}.ToList(),                                         '-- Billing.- --
                           .shipping = {oShipping}.ToList()                                        '-- Shipping.- --
                        }
                     '-- Armo el JSON y Lo convierto a String
                     data = serializer.Serialize(Cliente)
                     '-- Cargo un Nuevo Cliente 
                     CargaNuevoCliente(data, dr)
                     '-- Actualiza Contador.- --
                     _clientesPublicados += 1
               End Select
               '-- REQ-33743.- --------------------------------------------------------------------------------------------------
               If ArboreaURLLPrecioClientes IsNot Nothing Then
                  '--- Carga las listas de Precio.- --
                  Dim ListasPreciosClientes = New With
                     {
                        .IdCliente = IdClienteArborea,                                      '-- Id de Cliente Arborea.-
                        .IdListaPrecio = dr.Field(Of Integer)("OrdenPrecios").ToString()    '-- Precio de Venta.-
                     }
                  '-- Armo el JSON y Lo convierto a String
                  data = serializer.Serialize(ListasPreciosClientes)
                  '-- Carga las Listas de Precios Arborea.-
                  CargaListasPreciosClientes(data, dr, dt.Rows.Count)
               End If
               '-----------------------------------------------------------------------------------------------------------------
               '-- Si ya Existe Modifico sus datos Principales.
               My.Application.Log.WriteEntry(String.Format("SubidaClientesArborea - JSON: {0}", data), TraceEventType.Verbose)
#Else
               If count Mod 3 = 0 Then
                  Throw New Exception("Prueba de error")
               End If
#End If
               countExitoso += 1
            Catch ex As Exception
               countError += 1
               OnInformarError(String.Format("Cliente='{0}'", ClienteArborea), ex.Message)
               'arbMensaje.AppendFormat("Error enviando Cliente {0} - : {1}{2}",
               '                        ClienteArborea,
               '                        Environment.NewLine, ex.Message)
            End Try
            TriggerEvent(SincroTiendaWebEstados.Subiendo, SincroTiendaWebMetodos.POST, dt.Rows.Count, count, "CLIENTES", countExitoso, countError)
            '--------------------------'--------------------------'--------------------------'--------------------------
            RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, String.Format("Subiendo Clientes {0} de {1}.", count, dt.Count)))
            '--------------------------'--------------------------'--------------------------'--------------------------
         Next
         '--------------------------
         '# Guardo la fecha de sincronización 
         My.Application.Log.WriteEntry(String.Format("SubidaArborea.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.Cliente.NombreTabla), TraceEventType.Information)

#If SYNCTIENDAWEB <> "FALSE" Then
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString(),
                                                                          .Tabla = Entidades.Producto.NombreTabla,
                                                                          .FechaActualizacion = Now,
                                                                          .FechaSubida = rClientes.GetMaxFechaActualizacionWeb(),
                                                                          .IdUsuario = actual.Nombre,
                                                                          .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
#End If

         '--------------------------
      End Sub
      Public Sub CargaNuevoCliente(data As String, dr As DataRow)
         Try
            '-- Si es nuevo Cargo todos sus datos a Arborea-
            Dim response = Enviar(Of Entidades.JSonEntidades.TiendasWeb.Arborea.ClientesResponse)(data, SincroTiendaWebMetodos.POST, Me.GetHeaders(), "customers", "clientes")
            '-- Guardo Valor de ID cliente Arborea'
            Dim rClientes = New Clientes(da)
            rClientes.GuardarIdClienteTiendaWeb("Arborea", dr("IdCliente").ToString(), response.id.ToString())
            '-- REG-33743.- ------------------------------------------
            IdClienteArborea = response.id.ToString()
            '---------------------------------------------------------
            '-- Informo del avance.- --
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - Cargando Cliente {0}.", response.id), TraceEventType.Verbose)
         Catch ex As Exception
            '-- Informo del avance.- --
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - Cargando Cliente {0}.", ex.Message), TraceEventType.Verbose)
         End Try
      End Sub
      ''' <summary>
      ''' Actualiza Valores de Cliente.- --
      ''' </summary>
      ''' <param name="data"></param>
      ''' <param name="idClienteArborea"></param>
      Public Sub UpdateProdCliente(data As String, idClienteArborea As String)
         '-- Si ya Existe Modifico sus datos Principales.
         Dim response = Me.Enviar(Of Entidades.JSonEntidades.TiendasWeb.Arborea.ClientesUpdate)(data, SincroTiendaWebMetodos.PUT, Me.GetHeaders(), "customers/" + idClienteArborea, "clientes")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Actualizando Variantes del Cliente {0} - Método PUT.", idClienteArborea), TraceEventType.Verbose)
      End Sub


      Public Sub SincronizacionBajada(bajarTodo As Boolean)
         _rebajarTodo = bajarTodo
         '-- Bajo los pedidos de Mercado Libre.- --
         Me.BajarArboreaPedidos()
         '--------------------------
      End Sub
      Private Sub BajarArboreaPedidos()
         EjecutaConConexion(Sub() _BajarArboreaPedidos())
      End Sub
      Private Sub _BajarArboreaPedidos()
         '--------------------------
         RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Obteniendo información de los Pedidos..."))
         '--------------------------
         Dim since_id As Long = 0
         Dim serializer = New JavaScriptSerializer()
         Dim rPedidosTiendasWeb = New PedidosTiendasWeb(da)
         Dim sistemaDestino = Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString()

         Dim params = New Dictionary(Of String, String)

         '-- Obtener la fecha de ultima Bajada.- --
         '********************************************************************************************************************
         Dim fechaUltimaSincronizacion = New FechasSincronizaciones().GetFechaUltimaSincronizacion(
                                             sistemaDestino,
                                             Entidades.Pedido.NombreTabla)
         '********************************************************************************************************************

         '-- Primero obtengo todos los IDs de los nuevos pedidos.- --
         My.Application.Log.WriteEntry("SubidaArborea.Ejecutar - Obteniendo IDs de Nuevos Pedidos.", TraceEventType.Verbose)
         '--------------------------------------------------------------------------------------------------------------------
         Dim response = GETResponse(Of List(Of Entidades.JSonEntidades.TiendasWeb.Arborea.Ordenes))(Me.GetHeaders(), "orders")

         If response.Count > 0 Then RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "Bajando pedidos Arborea..."))
         '--------------------------------------------------------------------------------------------------------------------
         My.Application.Log.WriteEntry(String.Format("SubidaArborea.Ejecutar - {0} Pedidos (posibles) por bajar.", response.Count), TraceEventType.Verbose)
         '--------------------------------------------------------------------------------------------------------------------
         '# Luego por cada uno de los pedidos obtenidos realizo un GET por separado para obtenerlos individualmente y poder guardar su JSON como auditoría.
         Dim ePTW As Entidades.PedidoTiendaWeb
         Dim count As Integer = 0
         '--------------------------------------------------------------------------------------------------------------------
         For Each pedido As Entidades.JSonEntidades.TiendasWeb.Arborea.Ordenes In response
            '# Si el pedido ya esta grabado, no lo voy a buscar.
            If rPedidosTiendasWeb.ExistePedido(pedido.id.ToString(), sistemaDestino) Then Continue For
            '-----------------------------------------------------------------------------------------------------------------
            '# Si el pedido no esta en estado Procesando, no lo cargo.
            If pedido.status.ToString() <> "processing" Then Continue For
            '-----------------------------------------------------------------------------------------------------------------
            count += 1
            ePTW = New Entidades.PedidoTiendaWeb
            '-----------------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaArborea.Ejecutar - Obteniendo Pedido {0}.", pedido.id), TraceEventType.Verbose)
            Dim p = GETResponse(Of Entidades.JSonEntidades.TiendasWeb.Arborea.Ordenes)(Me.GetHeaders(), String.Format("orders/{0}", pedido.id.ToString()))
            TriggerEvent(SincroTiendaWebEstados.Bajando, SincroTiendaWebMetodos.GET, response.Count, count, "PEDIDOS", 0, 0)

            '# vuelvo a serializar el json y me lo guardo como auditoría
            Dim jsonstring As String = serializer.Serialize(p)
            '----------------------------------------------------------------------------------------------
            With ePTW
               .Id = p.id.ToString()
               .SistemaDestino = sistemaDestino
               .Numero = CLng(p.id.ToString())
               .IdClienteTiendaWeb = CStr(p.customer_id)
               .NombreClienteTiendaWeb = String.Format("{0} {1}", p.shipping.first_name, p.shipping.last_name)
               .IdMoneda = p.currency
               .FechaPedido = CDate(p.date_created)
               .ImporteTotal = CDec(p.total)
               .SubTotal = CDec(p.total)
               .IdUsuarioEstado = actual.Nombre
               .FechaEstado = Now
               .IdUsuarioDescarga = actual.Nombre
               .FechaDescarga = Now
               .IdEstadoPedidoTiendaWeb = "PENDIENTE"
               .JSON = jsonstring
               .NroDocCliente = p.customer_id
               .Email = p.billing.email
               .Telefono = If(p.billing.phone, ".")
               '----------------------------------------------------------------------------------------------
               .PacksIdTiendaWeb = If(p.transaction_id = Nothing, p.id.ToString(), p.transaction_id)
               '----------------------------------------------------------------------------------------------
               If p.shipping.first_name <> Nothing Then
                  .TipoEnvio = "shipping"
                  .CostoEnvio = 0
                  .CodigoPostal = CInt(p.shipping.postcode)
                  .DireccionNumero = ""
                  .DireccionEnvio = p.shipping.address_1.Truncar(100)
                  .DireccionCalle = p.billing.address_1.Truncar(100)
                  .Adicional = ""
                  '--------------------------------------------------------------------------------
                  .Localidad = p.billing.city
                  .Provincia = p.billing.state
                  .ObservacionesTiendaWeb = ""
                  '----------------------------------------------------------------------------------------------
               Else
                  .DireccionEnvio = "."
                  .CostoEnvio = 0
                  .CodigoPostal = actual.Sucursal.Localidad.IdLocalidad
                  .DireccionCalle = "."
                  .DireccionNumero = "."
                  .Adicional = "."
                  .Localidad = "."
                  .Provincia = "."
                  .ObservacionesTiendaWeb = ""
               End If
               '----------------------------------------------------------------------------------------------
            End With
            '# Productos
            Dim ePPTW As Entidades.PedidoProductoTiendaWeb
            For Each pr As Entidades.JSonEntidades.TiendasWeb.Arborea.Line_Items In p.line_items
               ePPTW = New Entidades.PedidoProductoTiendaWeb
               '---------------------------------------------------------------------------------------------
               If pr.product_id = "0" Then Continue For
               '---------------------------------------------------------------------------------------------
               With ePPTW
                  .Id = p.id.ToString()
                  .SistemaDestino = sistemaDestino
                  .Numero = CLng(p.id.ToString())
                  .IdProductoTiendaWeb = pr.product_id
                  .NombreProductoTiendaWeb = pr.name
                  '-- REQ-34159.- -------------------
                  .Precio = CDec(pr.price)
                  '----------------------------------
                  .Cantidad = CDec(pr.quantity)
                  ePTW.Productos.Add(ePPTW)
               End With
            Next
            '----------------------------------------------------------------------------------------------
            '# Guardo el pedido en mi tabla de PedidosTiendasWeb (Tabla de Pedidos intermedia entre el SIGA y la Web)
            My.Application.Log.WriteEntry(String.Format("SubidaArborea.Ejecutar - Grabando Pedido {0}.", pedido.id), TraceEventType.Verbose)
            '----------------------------------------------------------------------------------------------
            rPedidosTiendasWeb._Inserta(ePTW, soloTransaccion:=True)
            '----------------------------------------------------------------------------------------------
            Dim data As String = String.Empty
            '# Cambio Estado del Pedido.- ---
            Dim Status = New With
            {
               .status = "completed"
            }
            '-- Armo el JSON y Lo convierto a String
            data = serializer.Serialize(Status)
            '-- Cambia el Estado a Pausado. --
            StatusProdArborea(data, p.id.ToString())
            '-- Informo del avance.- --
            My.Application.Log.WriteEntry(String.Format("SubidaArborea - Actualizando Variantes del Producto {0} - Método PUT.", p.id.ToString()), TraceEventType.Verbose)
            '----------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaArborea.Ejecutar - Pedido {0} grabado correctamente.", pedido.id), TraceEventType.Verbose)
         Next
         '----------------------------------------------------------------------------------------------
         '# Si no se descargo un nuevo pedido, muestro en pantalla el mensaje.-
         '----------------------------------------------------------------------------------------------
         If count = 0 Then
            RaiseEvent Avance(Me, New SincronizacionTiendaWebEventArgs(Entidades.TiendasWeb.ARBOREA, "No hay pedidos para bajar."))
            My.Application.Log.WriteEntry(String.Format("SubidaArborea.Ejecutar - No hay pedidos para bajar."), TraceEventType.Information)
         End If
         '----------------------------------------------------------------------------------------------
      End Sub

      Private Sub Log(modulo As String, uri As Uri, method As SincroTiendaWebMetodos, headers As HeadersDictionary, data As String)
         If _logger IsNot Nothing Then
            _logger.Exportar(modulo, uri, method, headers, data)
         End If
      End Sub

      Private Function Enviar(Of T)(data As String, method As SincroTiendaWebMetodos, headers As HeadersDictionary, relativeUri As String, modulo As String) As T
         Dim uri = New Uri(ArboreaURLBase, relativeUri)
         Log(modulo, uri, method, headers, data)
         '--------------------------------------------------------------------------------------
         GetPOSTResponse(uri, method.ToString(), data, headers, Sub(x)
                                                                   RestResponse = x
                                                                End Sub)
         '# Get the POST response
         Return DirectCast(New JavaScriptSerializer().Deserialize(RestResponse, GetType(T)), T)
         '--------------------------------------------------------------------------------------
      End Function

      Private Function Actualizar(Of T)(data As String, method As SincroTiendaWebMetodos, headers As HeadersDictionary, relativeUri As String, modulo As String) As T
         Dim uri = New Uri(ArboreaURLLPrecio, relativeUri)
         Log(modulo, uri, method, headers, data)
         '--------------------------------------------------------------------------------------
         GetPOSTResponse(uri, method.ToString(), data, headers, Sub(x)
                                                                   RestResponse = x
                                                                End Sub)
         '# Get the POST response
         Return DirectCast(New JavaScriptSerializer().Deserialize(RestResponse, GetType(T)), T)
         '--------------------------------------------------------------------------------------
      End Function

      Private Function ActualizarClientes(Of T)(data As String, method As SincroTiendaWebMetodos, headers As HeadersDictionary, relativeUri As String, modulo As String) As T
         Dim uri = New Uri(ArboreaURLLPrecioClientes, relativeUri)
         Log(modulo, uri, method, headers, data)
         '--------------------------------------------------------------------------------------
         GetPOSTResponse(uri, method.ToString(), data, headers, Sub(x)
                                                                   RestResponse = x
                                                                End Sub)
         '# Get the POST response
         Return DirectCast(New JavaScriptSerializer().Deserialize(RestResponse, GetType(T)), T)
         '--------------------------------------------------------------------------------------
      End Function

      '-- Cambia Status de Publicacion.- --
      Public Sub StatusProdArborea(data As String, idPublicacion As String)
         '-- Si ya Existe pero esta inactivo desactivo campaña-.
         Dim response = Enviar(Of Entidades.JSonEntidades.TiendasWeb.Arborea.Status)(data, SincroTiendaWebMetodos.PUT, Me.GetHeaders(), String.Format("orders/{0}", idPublicacion), "pedidos")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaArborea - Actualizando Variantes del Producto {0} - Método PUT.", idPublicacion), TraceEventType.Verbose)
      End Sub

#End Region

#Region "Web Methods"
      Public Function GETResponse(Of T)(headers As HeadersDictionary, relativeUri As String) As T
         Dim uri = New Uri(ArboreaURLBase, relativeUri)
         Dim wc = New WebClient()

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
      Private Sub GetPOSTResponse(uri As Uri, metodo As String, data As String, headers As HeadersDictionary, callback As Action(Of String))

         Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)
         request.Method = metodo
         request.ContentType = "application/json"
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
            ArboreaExceptionHelper.ArboreaExceptionHandler(ex)
         End Try
      End Sub

      '-- Obtiene el Token.- --
      Private Function GetHeaders() As HeadersDictionary
         Dim headers = New HeadersDictionary()
         headers.AgregarAuthorization(String.Format("Basic {0}",
                                                    String.Format("{0}:{1}",
                                                                  Publicos.TiendasWeb.Arborea.ArboreaUsuarioToken,
                                                                  Publicos.TiendasWeb.Arborea.ArboreaClaveToken).ConvertToBase64String))
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
      Public Class POSTResponseArborea
         Public Property id As String
         Public Property parent As String
      End Class
#End Region

   End Class

End Namespace
