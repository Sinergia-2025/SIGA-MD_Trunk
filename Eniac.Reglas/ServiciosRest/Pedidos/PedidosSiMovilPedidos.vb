#Region "Options/Imports"
Imports Eniac.Entidades
Imports System.Net
Imports System.IO
Imports Eniac.Entidades.JSonEntidades.SiMovilPedidos
#End Region
Namespace ServiciosRest.Pedidos
   Public Class PedidosSiMovilPedidos
      Inherits BasePedidosWeb
      Private Property IdEmpresa As Integer
      Public Sub New()
         Dim codigoClienteSinergia As String = Publicos.CodigoClienteSinergia
         If Not IsNumeric(codigoClienteSinergia) Then
            Throw New Exception("No está configurado el Codigo de Empresa.")
         End If
         IdEmpresa = Integer.Parse(codigoClienteSinergia)
      End Sub

      Public Overrides Function PermiteSeleccionarRutasPedidosPendientes() As Boolean
         Return True
      End Function

#Region "GET"
      Public Overrides Function AgregarPedidoWeb(ds As Entidades.DsPreventa, da As Datos.DataAccess, rutasSeleccionadas As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)) As Entidades.DsPreventa
         Dim precioConIVA As Boolean = Publicos.PreciosConIVA

         Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open

         Try
            If blnAbreConexion Then da.OpenConection()

            'Dim rVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)
            'Dim rPedidosWeb As PedidosWeb = New PedidosWeb()
            Dim pedidos As List(Of PedidoSiMovilJSon)

            Dim url As StringBuilder = New StringBuilder(Reglas.Publicos.PedidosURLWebGET)
            If rutasSeleccionadas.Count > 0 Then
               url.AppendFormat("?idRuta={0}", String.Join(",", rutasSeleccionadas.ConvertAll(Function(x) x.IdRuta.ToString())))
            End If

            pedidos = GetPedidos(New Uri(url.ToString()))
            '  "http://www.siweb.com.ar/sistema/rest/index.php/api/pedido/cuitempresa/30713688300"))
            '  "http://sinergia-pc-04/WebMovil/api/Pedidos"

            Dim vendedor As Eniac.Entidades.Empleado
            Dim cliente As Entidades.Cliente
            'Dim estadoVisita As Eniac.Entidades.EstadoVisita
            'Try
            '   estadoVisita = New Reglas.EstadosVisitas(da).GetUno(1)
            'Catch ex As Exception
            '   estadoVisita = Nothing
            'End Try

            Dim rVentas As Ventas = New Ventas(da)
            Dim rRutas As MovilRutas = New MovilRutas(da)
            Dim rTransp As Transportistas = New Transportistas(da)

            Dim cache As BusquedasCacheadas = New BusquedasCacheadas()

            Dim numeroPedido As Long = 0

            For Each dr As DsPreventa.ArchivoRow In ds.Archivo
               For Each drP As DsPreventa.PedidoRow In dr.GetPedidoRows
                  For Each drPP As DsPreventa.PedidoProductoRow In drP.GetPedidoProductoRows
                     drPP.Delete()
                  Next
                  drP.Delete()
               Next
               dr.Delete()
            Next
            ds.AcceptChanges()

            If pedidos.Count = 0 Then
               Throw New Exception("No se encontraron pedidos para importar.")
            End If

            Dim calcDescRec = New CalculosDescuentosRecargos()

            Dim ruta As Entidades.MovilRuta = Nothing
            Dim transportistaRuta As Entidades.Transportista = Nothing

            Dim tipoComprobantePedido = cache.BuscaTipoComprobante("PEDIDO")

            For Each pedido As PedidoSiMovilJSon In pedidos

               If ruta Is Nothing OrElse ruta.IdRuta <> pedido.IdRuta Then
                  ruta = rRutas.GetUno(pedido.IdRuta, Base.AccionesSiNoExisteRegistro.Excepcion)
                  transportistaRuta = rTransp.GetUno(ruta.IdTransportista.IfNull)
               End If

               Try
                  vendedor = New Eniac.Reglas.Empleados(da).GetUno(ruta.IdVendedor)
               Catch ex As Exception
                  vendedor = Nothing
               End Try

               Try
                  cliente = New Reglas.Clientes(da).GetUnoPorCodigo(pedido.CodigoCliente, False, False)
               Catch ex As Exception
                  cliente = Nothing
               End Try

               If vendedor Is Nothing And cliente IsNot Nothing Then
                  vendedor = cliente.Vendedor
               End If

               Dim drArchivo As Entidades.DsPreventa.ArchivoRow = Nothing
               For Each dr As Entidades.DsPreventa.ArchivoRow In ds.Archivo
                  If dr.FormatoArchivo.Equals(Entidades.PreVenta.PreventaFormatoArchivo.Web) Then
                     If vendedor Is Nothing And dr.IsIdVendedorNull Then
                        drArchivo = dr
                        Exit For
                     End If
                     If vendedor IsNot Nothing AndAlso dr.IdVendedor = vendedor.IdEmpleado Then
                        drArchivo = dr
                        Exit For
                     End If
                  End If
               Next

               If drArchivo Is Nothing Then
                  drArchivo = ds.Archivo.NewArchivoRow()

                  drArchivo.NombreArchivo = "Pedidos Web de " + If(vendedor IsNot Nothing, vendedor.NombreEmpleado, "Vendedor inexistente")
                  drArchivo.PathCompletoArchivo = String.Empty
                  drArchivo.FormatoArchivo = Entidades.PreVenta.PreventaFormatoArchivo.Web

                  If vendedor IsNot Nothing Then
                     drArchivo.IdVendedor = vendedor.IdEmpleado
                     drArchivo.NombreVendedor = vendedor.NombreEmpleado
                  Else
                     drArchivo.SetIdVendedorNull()
                     drArchivo.SetNombreVendedorNull()
                  End If
               End If

               drArchivo.IdRuta = ruta.IdRuta
               drArchivo.NombreRuta = ruta.NombreRuta

               Dim drPedido As DsPreventa.PedidoRow = ds.Pedido.NewPedidoRow()

               drPedido.PedidoWeb = pedido

               drPedido.NroVersionRemoto = pedido.NroVersionRemoto

               drPedido.Pasa = True
               drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal

               drPedido.IdRuta = drArchivo.IdRuta
               drPedido.NombreRuta = ruta.NombreRuta

               If cliente Is Nothing Then
                  drPedido.Pasa = False
                  drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                  drPedido.MensajeError = "CLIENTE INEXISTENTE - "
                  drPedido.IdCliente = pedido.CodigoCliente
                  drPedido.CodigoCliente = pedido.CodigoCliente
               ElseIf Not cliente.Activo Then
                  drPedido.Pasa = False
                  drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                  drPedido.MensajeError = "CLIENTE INACTIVO - "
                  drPedido.IdCliente = pedido.CodigoCliente
                  drPedido.CodigoCliente = pedido.CodigoCliente
               Else
                  drPedido.FechaPedido = pedido.FechaPedido
                  drPedido.FechaPedido_Fecha = pedido.FechaPedido.Date
                  drPedido.FechaPedido_Hora = pedido.FechaPedido.TimeOfDay.ToString()
                  drPedido.FechaRecepcionWeb = pedido.FechaRecepcionWeb
                  drPedido.CodigoCliente = cliente.CodigoCliente
                  drPedido.IdCliente = cliente.IdCliente
                  drPedido.TipoDocCliente = cliente.TipoDocCliente
                  drPedido.NroDocCliente = cliente.NroDocCliente
                  drPedido.NombreCliente = cliente.NombreCliente
                  drPedido.Direccion = cliente.Direccion
                  drPedido.NombreCategoriaFiscalAbrev = cliente.CategoriaFiscal.NombreCategoriaFiscalAbrev
                  drPedido.CUIT = cliente.Cuit


                  If Reglas.Publicos.ParametrosSiMovil.SolicitaTipoComprobante Then
                     drPedido.IdTipoComprobanteFact = pedido.IdTipoComprobante
                  End If

                  drPedido.PorcDesc = calcDescRec.DescuentoRecargo(cliente, tipoComprobantePedido.GrabaLibro, tipoComprobantePedido.EsPreElectronico,
                                                                   cache.BuscaFormasPago(cliente.IdFormasPago),
                                                                   pedido.PedidosProductos.Count)


                  If String.IsNullOrWhiteSpace(cliente.NombreTransportista) Or
                     cliente.NombreTransportista = ".SIN FLETE" Then
                     drPedido.IdTransportista = ruta.IdTransportista.IfNull
                     drPedido.NombreTransportista = transportistaRuta.NombreTransportista
                  Else
                     drPedido.IdTransportista = cliente.IdTransportista
                     drPedido.NombreTransportista = cliente.NombreTransportista
                  End If

                  If cliente.IdFormasPago = 0 Then
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     drPedido.MensajeError = "CLIENTE SIN FORMA DE PAGO - "
                  End If

                  If ExistePedidoCliente(actual.Sucursal.Id, drPedido.IdCliente, drPedido.FechaPedido, da) Then
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     drPedido.MensajeError = "PEDIDO YA INGRESADO - "
                  End If

               End If            ' ELSE - If cliente Is Nothing Then

               Dim estadoVisita As Eniac.Entidades.EstadoVisita
               Try
                  estadoVisita = New Eniac.Reglas.EstadosVisitas(da).GetUno(pedido.IdEstadoVisita)
               Catch ex As Exception
                  estadoVisita = Nothing
               End Try
               If estadoVisita Is Nothing Then
                  drPedido.Pasa = False
                  drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                  drPedido.MensajeError = "ESTADO DE VISITA INEXISTENTE - "
               Else
                  drPedido.IdEstadoVenta = estadoVisita.IdEstadoVisita
                  drPedido.NombreEstadoVenta = estadoVisita.NombreEstadoVisita
               End If

               drPedido.Observaciones = pedido.Observacion.Truncar(100)

               drPedido.ArchivoRow = drArchivo

               If Not ds.Archivo.Contains(drArchivo) Then
                  ds.Archivo.AddArchivoRow(drArchivo)
               End If

               drPedido.IdSucursal = actual.Sucursal.Id
               drPedido.IdTipoComprobante = tipoComprobantePedido.IdTipoComprobante
               drPedido.Letra = "X"

               'drPedido.CentroEmisor = 1
               Dim impresora As Entidades.Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, drPedido.IdTipoComprobante)
               drPedido.CentroEmisor = impresora.CentroEmisor

               drPedido.NumeroPedido = numeroPedido
               numeroPedido += 1
               Dim cargaDetalle As Boolean = False

               '-- REQ-38418.- ---------------------------------------------------------------------------------------
               If Reglas.Publicos.ParametrosSiMovil.SolicitaTipoComprobante Then
                  If ds.TipoComprobantes IsNot Nothing AndAlso ds.TipoComprobantes.Where(Function(p) p.IdTipoComprobante = pedido.IdTipoComprobante).Count > 0 Then
                     ds.Pedido.AddPedidoRow(drPedido)
                     cargaDetalle = True
                  End If
               Else
                  ds.Pedido.AddPedidoRow(drPedido)
                  cargaDetalle = True
               End If

               If cargaDetalle Then
                  For Each pedidoDetalle As PedidoProductoSiMovilJSon In pedido.PedidosProductos
                     'For Each pedidoDetalle As PedidoProductoJSon In pedido.detalle

                     Dim idListaPrecios As Integer
                     If cliente IsNot Nothing Then
                        Try
                           idListaPrecios = cliente.IdListaPrecios
                        Catch
                           Throw
                        End Try
                     Else
                        idListaPrecios = Publicos.ListaPreciosPredeterminada
                     End If
                     Dim respetaListaPreciosCliente As Boolean = False
                     If Not respetaListaPreciosCliente Then
                        idListaPrecios = pedidoDetalle.IdListaPrecios
                     End If

                     Dim drPedidoProducto As Entidades.DsPreventa.PedidoProductoRow = ds.PedidoProducto.NewPedidoProductoRow()
                     drPedidoProducto.IdProducto = pedidoDetalle.IdProducto
                     drPedidoProducto.Cantidad = pedidoDetalle.Cantidad

                     drPedidoProducto.CantidadCambio = pedidoDetalle.CantidadCambio
                     drPedidoProducto.CantidadBonif = pedidoDetalle.CantidadBonif
                     drPedidoProducto.NotaCambio = pedidoDetalle.NotaCambio
                     drPedidoProducto.NotaBonif = pedidoDetalle.NotaBonif

                     drPedidoProducto.CantidadDevolucion = pedidoDetalle.CantidadDevolucion
                     drPedidoProducto.NotaDevolucion = pedidoDetalle.NotaDevolucion

                     drPedidoProducto.PedidoRowParent = drPedido
                     drPedidoProducto.Orden = ds.PedidoProducto.Count + 1

                     '>>>> Resolución para lista de precios -1
                     Dim param As Entidades.PreVenta.AccionSinListaPrecios = Publicos.PreVentaAccionSinListaPrecios
                     If idListaPrecios < 0 Then
                        Select Case param
                           Case Entidades.PreVenta.AccionSinListaPrecios.Ruta
                              Dim listaDefault As MovilRutaListaDePrecios = ruta.ListasDePrecio.FirstOrDefault(Function(x) x.PorDefecto)
                              If listaDefault IsNot Nothing Then
                                 idListaPrecios = listaDefault.IdListaPrecios
                              End If
                           Case Entidades.PreVenta.AccionSinListaPrecios.Cliente
                              idListaPrecios = If(cliente IsNot Nothing, cliente.IdListaPrecios, Publicos.ListaPreciosPredeterminada)
                           Case Entidades.PreVenta.AccionSinListaPrecios.Predeterminada
                              idListaPrecios = Publicos.ListaPreciosPredeterminada
                        End Select
                     End If
                     '<<<< Resolución para lista de precios -1
                     drPedidoProducto.IdListaPrecios = idListaPrecios

                     If idListaPrecios < 0 Then
                        drPedido.Pasa = False
                        drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                        drPedido.MensajeError += "ARTICULO SIN LISTA DE PRECIOS - "
                        drPedidoProducto.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                        drPedidoProducto.MensajeError += "ARTICULO SIN LISTA DE PRECIOS - "
                        drPedidoProducto.ConError_ProductoInexistente = True
                     Else

                        Dim productoSucursal As Eniac.Entidades.ProductoSucursal
                        productoSucursal = cache.GetProductosSucursales(actual.Sucursal.IdSucursal, pedidoDetalle.IdProducto, idListaPrecios)

                        'Si el producto no existe
                        If productoSucursal Is Nothing OrElse String.IsNullOrWhiteSpace(productoSucursal.Producto.IdProducto) OrElse Not productoSucursal.Producto.Activo Then
                           drPedidoProducto.Precio = 0
                           drPedido.Pasa = False
                           drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                           drPedido.MensajeError += "ARTICULO INACTIVO o INEXISTENTE - "
                           drPedidoProducto.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                           drPedidoProducto.MensajeError += "ARTICULO INACTIVO o INEXISTENTE - "
                           drPedidoProducto.ConError_ProductoInexistente = True
                        Else
                           Dim producto As Entidades.Producto = productoSucursal.Producto

                           drPedidoProducto.NombreProducto = productoSucursal.Producto.NombreProducto
                           If Publicos.PreVentaAgrupaOrdenProductoEnCadaPedido Then
                              drPedidoProducto.OrdenProducto = productoSucursal.Producto.Orden
                           End If

                           If ruta.PrecioConImpuestos Then
                              drPedidoProducto.PrecioMovil = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(pedidoDetalle.Precio, producto), Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                              drPedidoProducto.PrecioMovilConIVA = pedidoDetalle.Precio
                           Else
                              drPedidoProducto.PrecioMovil = pedidoDetalle.Precio
                              drPedidoProducto.PrecioMovilConIVA = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pedidoDetalle.Precio, producto), Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                           End If

                           If Reglas.Publicos.PreciosConIVA Then
                              drPedidoProducto.PrecioLista = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(productoSucursal.PrecioVentaLista, producto), Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                              drPedidoProducto.PrecioListaConIVA = productoSucursal.PrecioVentaLista
                           Else
                              drPedidoProducto.PrecioLista = productoSucursal.PrecioVentaLista
                              drPedidoProducto.PrecioListaConIVA = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(productoSucursal.PrecioVentaLista, producto), Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                           End If

                           drPedidoProducto.Stock = productoSucursal.Stock
                           drPedidoProducto.IVA = productoSucursal.Producto.Alicuota

                           Dim listaPrecios As Eniac.Entidades.ListaDePrecios = cache.BuscaListaDePrecios(idListaPrecios)
                           If listaPrecios IsNot Nothing Then
                              drPedidoProducto.NombreListaPrecios = listaPrecios.NombreListaPrecios
                           Else
                              drPedido.Pasa = False
                              drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                              drPedido.MensajeError += "LISTA DE PRECIOS INEXISTENTE - "
                           End If

                           If Publicos.PreventaV2ImportaDescuentosSimovilWeb Then
                              drPedidoProducto.PorcDesc1 = pedidoDetalle.Descuento

                           ElseIf Not Publicos.PreventaV2ImportaDescuentosSimovilWeb Then

                              Dim descRec As Eniac.Reglas.DescuentoRecargoProducto = If(cliente Is Nothing, New DescuentoRecargoProducto(), rVentas.DescuentoRecargo(cliente, productoSucursal.Producto, drPedidoProducto.Cantidad))
                              drPedidoProducto.PorcDesc1 = descRec.DescuentoRecargo1
                              drPedidoProducto.PorcDesc2 = descRec.DescuentoRecargo2

                              If drPedidoProducto.CantidadCambio <> 0 Then
                                 drPedido.Pasa = True
                                 drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                                 drPedido.MensajeError += "ARTICULO CON CAMBIO - "
                              End If

                              If drPedidoProducto.CantidadBonif <> 0 Then
                                 drPedido.Pasa = True
                                 drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                                 drPedido.MensajeError += "ARTICULO CON BONIFICACIONES - "
                              End If
                           End If

                           '-.PE-32604.-
                           If cliente IsNot Nothing AndAlso String.IsNullOrWhiteSpace(cliente.IdTipoComprobante) Then
                              Throw New Exception(String.Format("El cliente ({0}) {1} no tiene configurado tipo de comprobante. Por favor verifique el cliente.",
                                                cliente.CodigoCliente, cliente.NombreCliente))
                           End If

                           'RUTA: PuedeModificarPrecio y Reglas.Publicos.PreventaRespetaPrecioDelMovil
                           If ruta.PuedeModificarPrecio Or Reglas.Publicos.PreventaRespetaPrecioDelMovil Then
                              'Se toman los precios del Movil
                              drPedidoProducto.Precio = drPedidoProducto.PrecioMovil
                              drPedidoProducto.PrecioConIVA = drPedidoProducto.PrecioMovilConIVA


                              'WORKAROUND: Los precios del movil viene Neto (con impuestos y recargos aplicados)
                              '            por lo que tengo que calcular el precio sin D/R
                              If drPedidoProducto.Precio = 0 Or drPedidoProducto.PrecioConIVA = 0 Then
                                 drPedido.Pasa = False
                                 drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                                 drPedido.MensajeError += "EL PRODUCTO " & drPedidoProducto.NombreProducto & " TIENE PRECIO 0 "
                              End If

                              If drPedidoProducto.Precio > 0 Then
                                 drPedidoProducto.Precio = Math.Round((drPedidoProducto.Precio / (1 + (drPedidoProducto.PorcDesc1 / 100))) / (1 + (drPedidoProducto.PorcDesc2 / 100)), Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                              Else
                                 drPedidoProducto.PrecioConIVA = 0
                              End If

                              If drPedidoProducto.PrecioConIVA > 0 Then
                                 drPedidoProducto.PrecioConIVA = Math.Round((drPedidoProducto.PrecioConIVA / (1 + (drPedidoProducto.PorcDesc1 / 100))) / (1 + (drPedidoProducto.PorcDesc2 / 100)), Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                              Else
                                 drPedidoProducto.PrecioConIVA = 0
                              End If

                              drPedidoProducto.PrecioNeto = drPedidoProducto.PrecioMovil
                              drPedidoProducto.PrecioNetoConIVA = drPedidoProducto.PrecioMovilConIVA




                              'Dim precioMovil As Decimal = drPedidoProducto.PrecioMovil
                              'If (precioConIVA And ruta.PrecioConImpuestos) Or (Not precioConIVA And Not ruta.PrecioConImpuestos) Then
                              '   drPedidoProducto.Precio = precioMovil
                              'Else
                              '   If precioConIVA And Not ruta.PrecioConImpuestos Then
                              '      drPedidoProducto.Precio = (precioMovil * (1 + (drPedidoProducto.IVA / 100))) + productoSucursal.Producto.ImporteImpuestoInterno
                              '   ElseIf Not precioConIVA And ruta.PrecioConImpuestos Then
                              '      drPedidoProducto.Precio = (precioMovil - productoSucursal.Producto.ImporteImpuestoInterno) / (1 + (drPedidoProducto.IVA / 100))
                              '   End If
                              'End If
                           Else
                              'Se toman los precios de Lista
                              drPedidoProducto.Precio = drPedidoProducto.PrecioLista
                              drPedidoProducto.PrecioConIVA = drPedidoProducto.PrecioListaConIVA

                              drPedidoProducto.PrecioNeto = Math.Round((drPedidoProducto.Precio / (1 + (drPedidoProducto.PorcDesc1 / 100))) / (1 + (drPedidoProducto.PorcDesc2 / 100)), Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                              drPedidoProducto.PrecioNetoConIVA = Math.Round((drPedidoProducto.PrecioConIVA / (1 + (drPedidoProducto.PorcDesc1 / 100))) / (1 + (drPedidoProducto.PorcDesc2 / 100)), Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)

                           End If



                        End If         'ELSE - If producto Is Nothing OrElse String.IsNullOrWhiteSpace(producto.Producto.IdProducto) Then
                     End If            'ELSE - If idListaPrecios < 0 Then

                     'drPedidoProducto.Precio = drPedidoProducto.Precio + (drPedidoProducto.Precio * drPedidoProducto.PorcDesc1 / 100)
                     'drPedidoProducto.Precio = drPedidoProducto.Precio + (drPedidoProducto.Precio * drPedidoProducto.PorcDesc2 / 100)
                     'Dim importe As Decimal = Math.Round(drPedidoProducto.Precio, 2) * drPedidoProducto.Cantidad

                     'Dim precioNeto As Decimal = drPedidoProducto.Precio
                     'precioNeto = precioNeto + (precioNeto * drPedidoProducto.PorcDesc1 / 100)
                     'precioNeto = precioNeto + (precioNeto * drPedidoProducto.PorcDesc2 / 100)
                     Dim importe As Decimal = Math.Round(drPedidoProducto.PrecioNetoConIVA, Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio) * drPedidoProducto.Cantidad

                     drPedidoProducto.ImporteTotal = importe

                     importe = importe + (importe * drPedido.PorcDesc / 100)

                     drPedido.ImporteTotal += importe

                     If drPedidoProducto.Cantidad <> 0 Or drPedidoProducto.CantidadCambio <> 0 Or drPedidoProducto.CantidadBonif <> 0 Or drPedidoProducto.CantidadDevolucion <> 0 Then
                        ds.PedidoProducto.AddPedidoProductoRow(drPedidoProducto)
                     End If

                  Next
               End If
               '------------------------------------------------------------------------------------------------------


               If estadoVisita IsNot Nothing Then
                  Dim mensaje As String = New PreVenta().ValidaEstadoVisita(estadoVisita, drPedido)
                  If Not String.IsNullOrWhiteSpace(mensaje) Then
                     drPedido.Pasa = False
                     If drPedido.Estado Is Nothing OrElse DirectCast(drPedido.Estado, Entidades.PreVenta.PreventaEstadoPedido) = Entidades.PreVenta.PreventaEstadoPedido.Normal Then
                        drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Corregible
                        drPedido.MensajeError = String.Empty
                     End If
                     drPedido.MensajeError += mensaje
                  End If
               End If

            Next     ' For Each pedido As PedidoJSon In pedidos

            ds.AcceptChanges()
         Catch
            ds.RejectChanges()
            Throw
         Finally
            If blnAbreConexion Then da.CloseConection()
            ds.AcceptChanges()
         End Try
         Return ds

      End Function

      Public Function GetRutasPedidosPendientes() As List(Of JSonEntidades.CobranzasMovil.Rutas)

         Dim simovilCobranzaURLBase As String = Publicos.SimovilCobranzaURLBase
         If String.IsNullOrWhiteSpace(simovilCobranzaURLBase) Then
            Throw New Exception("No está configurado la URL Base para Simovil Cobranza.")
         End If
         Dim Uri As Uri = New Uri(New Uri(simovilCobranzaURLBase), "RutasPedidosPendientes")

         Dim wc As New WebClient()
         Try
            wc.Headers.Add(HeadersDictionary.Headers.IdEmpresa.ToString(), IdEmpresa.ToString())
            Using orResult As System.IO.Stream = wc.OpenRead(Uri)

               Dim reader As StreamReader = New StreamReader(orResult)
               Dim jsonString As String = reader.ReadToEnd()

               Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
               Dim rutas As List(Of JSonEntidades.CobranzasMovil.Rutas) = serializer.Deserialize(Of List(Of JSonEntidades.CobranzasMovil.Rutas))(jsonString)

               Return rutas
            End Using
         Catch ex As WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            'Para evitar el warning, pero ya la NetExceptionHandler lanza una excepción por todos sus caminos
            Return New List(Of JSonEntidades.CobranzasMovil.Rutas)()
         End Try
      End Function

      Public Function GetPedidos(fechaPedidosDesde As Date?, fechaPedidosHasta As Date?,
                                 fechaProcesoDesde As Date?, fechaProcesoHasta As Date?,
                                 idRuta As Integer,
                                 codigoCliente As Long,
                                 procesado As Entidades.Publicos.SiNoTodos) As List(Of PedidoSiMovilJSon)
         Dim stb = New StringBuilder()
         stb.Append(Publicos.PedidosURLWebGET)
         stb.AppendFormat("?actualizaFechaDescarga=False")
         If fechaPedidosDesde.HasValue Then
            stb.AppendFormat("&fechaPedidosDesde={0:yyyy-MM-dd_HH:mm:ss}", fechaPedidosDesde.Value)
         End If
         If fechaPedidosHasta.HasValue Then
            stb.AppendFormat("&fechaPedidosHasta={0:yyyy-MM-dd_HH:mm:ss}", fechaPedidosHasta.Value)
         End If
         If fechaProcesoDesde.HasValue Then
            stb.AppendFormat("&fechaProcesoDesde={0:yyyy-MM-dd_HH:mm:ss}", fechaProcesoDesde.Value)
         End If
         If fechaProcesoHasta.HasValue Then
            stb.AppendFormat("&fechaProcesoHasta={0:yyyy-MM-dd_HH:mm:ss}", fechaProcesoHasta.Value)
         End If
         If idRuta > 0 Then
            stb.AppendFormat("&idRuta={0}", idRuta)
         End If
         If codigoCliente > 0 Then
            stb.AppendFormat("&codigoCliente={0}", codigoCliente)
         End If
         'If procesado <> Entidades.Publicos.SiNoTodos.TODOS Then
         stb.AppendFormat("&procesado={0}", procesado.ToString())
         'End If

         Dim uri As Uri = New Uri(stb.ToString())
         Return GetPedidos(uri)
      End Function

      Public Function GetPedidosConFK(fechaPedidosDesde As Date?, fechaPedidosHasta As Date?,
                                      fechaProcesoDesde As Date?, fechaProcesoHasta As Date?,
                                      idRuta As Integer,
                                      codigoCliente As Long,
                                      procesado As Entidades.Publicos.SiNoTodos) As List(Of PedidoSiMovilJSon)
         Dim pedidos = GetPedidos(fechaPedidosDesde, fechaPedidosHasta,
                                  fechaProcesoDesde, fechaProcesoHasta,
                                  idRuta,
                                  codigoCliente,
                                  procesado)
         Using dtClientes As DataTable = New Reglas.Clientes().GetAll()
            Using dtRutas As DataTable = New Reglas.MovilRutas().GetAll()
               Using dtListas As DataTable = New Reglas.ListasDePrecios().GetAll()
                  Using dtProductos As DataTable = New Reglas.Productos().GetAll()
                     Dim dr As DataRow()
                     For Each ped As PedidoSiMovilJSon In pedidos
                        dr = dtClientes.Select(String.Format("{0} = {1}", Entidades.Cliente.Columnas.CodigoCliente.ToString(), ped.CodigoCliente))
                        If dr.Length > 0 Then
                           ped.NombreCliente = dr(0)(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()
                        End If

                        dr = dtRutas.Select(String.Format("{0} = {1}", Entidades.MovilRuta.Columnas.IdRuta.ToString(), ped.IdRuta))
                        If dr.Length > 0 Then
                           ped.NombreRuta = dr(0)(Entidades.MovilRuta.Columnas.NombreRuta.ToString()).ToString()
                        End If

                        For Each pp As PedidoProductoSiMovilJSon In ped.PedidosProductos
                           dr = dtListas.Select(String.Format("{0} = {1}", Entidades.ListaDePrecios.Columnas.IdListaPrecios.ToString(), pp.IdListaPrecios))
                           If dr.Length > 0 Then
                              pp.NombreListaPrecios = dr(0)(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()).ToString()
                           End If

                           dr = dtProductos.Select(String.Format("TRIM({0}) = '{1}'", Entidades.Producto.Columnas.IdProducto.ToString(), pp.IdProducto))
                           If dr.Length > 0 Then
                              pp.NombreProducto = dr(0)(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
                           End If

                        Next
                     Next
                  End Using
               End Using
            End Using
         End Using
         Return pedidos
      End Function


      Private Function GetPedidos(uri As Uri) As List(Of PedidoSiMovilJSon)
         Dim wc As New WebClient()
         Try
            wc.Headers.Add(HeadersDictionary.Headers.IdEmpresa.ToString(), IdEmpresa.ToString())
            Using orResult As System.IO.Stream = wc.OpenRead(uri)

               Dim reader As StreamReader = New StreamReader(orResult)
               Dim jsonString As String = reader.ReadToEnd()

               Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
               serializer.MaxJsonLength = serializer.MaxJsonLength * 10
               Dim pedidos As List(Of PedidoSiMovilJSon) = serializer.Deserialize(Of List(Of PedidoSiMovilJSon))(jsonString)

               '' ''Dim ser As New DataContractJsonSerializer(GetType(List(Of PedidoSiMovilJSon)))

               '' ''Dim encode As Text.Encoding = System.Text.Encoding.GetEncoding("utf-8")
               ' '' '' Pipes the response stream to a higher level stream reader with the required encoding format. 
               ' '' ''Dim readStream As New StreamReader(orResult, encode)
               ' '' ''Dim str As String = readStream.ReadToEnd()

               '' ''Dim pedidos As List(Of PedidoSiMovilJSon) = TryCast(ser.ReadObject(orResult), List(Of PedidoSiMovilJSon))
               Return pedidos
            End Using
         Catch ex As WebException
            If ex.Response IsNot Nothing AndAlso TypeOf (ex.Response) Is HttpWebResponse Then
               Dim response As HttpWebResponse = DirectCast(ex.Response, HttpWebResponse)
               If response.StatusCode = HttpStatusCode.NotFound Then
                  Throw New Exception("No se han encontrado pedidos en la Web.", ex)
               ElseIf response.StatusCode = HttpStatusCode.BadRequest Then
                  ThrowStatusCode400Exception(ex, response)
               End If
            End If
            Throw ex
         End Try

      End Function

      Private Function ExistePedidoWeb(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As Boolean
         Return New Reglas.Pedidos().ExistePedido(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      End Function
#End Region

#Region "PUT"
      Public Overrides Sub SetEstadoPedidoProcesado(idPedidoWeb As Entidades.DsPreventa.PedidoRow, estado As EstadoSiWeb)
         SetEstadoPedidoProcesado(DirectCast(idPedidoWeb.PedidoWeb, PedidoSiMovilJSon), estado)
      End Sub

      Public Overloads Sub SetEstadoPedidoProcesado(pedido As PedidoSiMovilJSon, estado As EstadoSiWeb)
         'Dim pedido As PedidoSiMovilJSon = DirectCast(idPedidoWeb.PedidoWeb, PedidoSiMovilJSon)
         If estado = EstadoSiWeb.Procesado Then
            pedido.Procesado = True
         Else
            pedido.Procesado = False
         End If
         Dim ser As New System.Web.Script.Serialization.JavaScriptSerializer()
         Dim datos As String = ser.Serialize(pedido)

         Dim url As String = Publicos.PedidosURLWebPUT
         If Not String.IsNullOrWhiteSpace(url) Then
            Dim hdrDic As HeadersDictionary
            hdrDic = New HeadersDictionary().AgregarEmpresa(IdEmpresa).Agregar(HeadersDictionary.Headers.VersionAPI, "2")
            GetPUTResponse(New Uri(url), datos, hdrDic, Nothing)
         End If
      End Sub

#End Region

#Region "POST"
      Private respuestaServicioRest As String
      Public Function PostPedidos(pedidosJ As List(Of JSonEntidades.Pedidos.PedidoJSon)) As PedidosSiGA.WebSigaServiceResponse
         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         Dim pedidosAsRest As String = serializer.Serialize(pedidosJ)

         Dim url As String = Publicos.PedidosURLWebPOST
         ' "http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigapedido"


         GetPOSTResponse(New Uri(url), pedidosAsRest,
                         Sub(x)
                            respuestaServicioRest = x
                         End Sub)

         Dim webSigaServiceResponse As PedidosSiGA.WebSigaServiceResponse
         webSigaServiceResponse = TryCast(serializer.Deserialize(respuestaServicioRest, GetType(PedidosSiGA.WebSigaServiceResponse)), PedidosSiGA.WebSigaServiceResponse)

         Return webSigaServiceResponse
      End Function

      Private Sub GetPOSTResponse(uri As Uri, data As String, callback As Action(Of String))
         Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)

         request.Method = "POST"
         request.ContentType = "application/json; charset=utf-8"

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
                         Dim reader As StreamReader = New StreamReader(stream, encoding.UTF8)
                         Dim responseString As String = reader.ReadToEnd()
                         callback(responseString)
                      End Using

                      'Dim ser As New DataContractJsonSerializer(GetType(PedidoWebEstadoResponse))
                      'callback(TryCast(ser.ReadObject(response.GetResponseStream()), PedidoWebEstadoResponse))
                   End If
                End Using
                Return 0
             End Function, Nothing)
      End Sub
#End Region
      Private Function ExistePedidoCliente(idSucursal As Integer, IdCliente As Long, fechaPedido As DateTime, da As Datos.DataAccess) As Boolean
         Return New Reglas.Pedidos(da).ExistePedido(idSucursal, IdCliente, fechaPedido)
      End Function

      Protected Overrides Sub ThrowStatusCode400Exception(ex As WebException, response As HttpWebResponse)
         Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
         ' Pipes the response stream to a higher level stream reader with the required encoding format. 
         Dim readStream As New StreamReader(response.GetResponseStream(), encode)

         Dim str As String = readStream.ReadToEnd()
         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

         Dim errorResponse As SiMovilPedidosErrorResponse
         errorResponse = serializer.Deserialize(Of SiMovilPedidosErrorResponse)(str)

         Throw New Exception(String.Format("{0} - {1}", errorResponse.CodigoError, errorResponse.MensajeError), ex)

         'MyBase.ThrowStatusCode400Exception(ex, response)
      End Sub

      Public Class SiMovilPedidosErrorResponse
         Public Property CodigoError() As Integer
         Public Property MensajeError() As String
      End Class

   End Class
End Namespace