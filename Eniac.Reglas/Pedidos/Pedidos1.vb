Partial Class Pedidos

   Public Sub GrabarPedidosAImportar(dt As DataTable,
                                     formatoArchivo As Entidades.Pedido.FormatoImportarPedidos,
                                     ordenCompra As Long,
                                     idFormaPago As Integer,
                                     idProveedor As Long,
                                     ByRef BarraProg As Windows.Forms.ProgressBar,
                                     tiempo As Windows.Forms.ToolStripLabel,
                                     registroactual As Windows.Forms.ToolStripLabel,
                                     respetaPreciosOrdenCompra As Boolean,
                                     fechaEntrega As Date?,
                                     altaProductos As Boolean,
                                     AplicaDescuentoRecargo As Boolean,
                                     Anticipado As Boolean,
                                     idFuncion As String)
      Dim cache = New BusquedasCacheadas()
      Try
         da.OpenConection()

         Dim rPedidos = New Reglas.Pedidos(da)
         Dim categoriaFiscalEmpresa = New Reglas.CategoriasFiscales(da).GetUno(Publicos.CategoriaFiscalEmpresa)

         Dim tipoImpuestoIVA = New Eniac.Reglas.TiposImpuestos().GetUno(Eniac.Entidades.TipoImpuesto.Tipos.IVA)
         Dim rCriticidad = New Eniac.Reglas.PedidosCriticidades(da)
         Dim drCriticidad = rCriticidad.GetTodosPorOrden()
         Dim criticidad = rCriticidad.GetUno(drCriticidad.Rows(0)(Eniac.Entidades.CriticidadPedido.Columnas.IdCriticidad.ToString()).ToString())

         Dim idTipoComprobanteDefault As String = Reglas.Publicos.ImportarPedidosTipoComprobante
         Dim tpCompDefault = New Reglas.TiposComprobantes().GetUno(idTipoComprobanteDefault)
         Dim tpComp As Entidades.TipoComprobante

         Dim pedido = New Entidades.Pedido()
         'Dim ClientePedido As Long = 0
         Dim estaCargando As Boolean = True

         'Grabo la cabecera de la Orden de Compra

         If formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB Then
            Dim OC As DataTable = New Reglas.OrdenesCompra().Get1(actual.Sucursal.IdSucursal, ordenCompra)
            If OC.Rows.Count = 0 Then
               Dim OrdenCompras As Entidades.OrdenCompra = New Entidades.OrdenCompra
               OrdenCompras.NumeroOrdenCompra = ordenCompra
               OrdenCompras.IdProveedor = idProveedor
               OrdenCompras.IdFormasPago = idFormaPago
               OrdenCompras.FechaPedidos = Date.Now
               OrdenCompras.Usuario = actual.Nombre
               OrdenCompras.IdSucursal = actual.Sucursal.IdSucursal
               OrdenCompras.RespetaPreciosOrdenCompra = respetaPreciosOrdenCompra
               OrdenCompras.AplicaDescuentoRecargo = AplicaDescuentoRecargo
               OrdenCompras.Anticipado = Anticipado

               Dim rOrdenesCompra As OrdenesCompra = New Reglas.OrdenesCompra(da)
               rOrdenesCompra.Inserta(OrdenCompras)
            End If
         End If

         Dim i As Integer = 0

         BarraProg.Minimum = 0
         BarraProg.Value = 0
         Dim HoraInicio As DateTime = Now

         Dim dtARecorrer As DataTable = dt.Clone()
         Dim drARecorrer As DataRow

         For Each dr As DataRow In dt.Rows
            If Boolean.Parse(dr("Importa").ToString()) Then
               drARecorrer = dtARecorrer.NewRow()
               drARecorrer.ItemArray = dr.ItemArray
               dtARecorrer.Rows.Add(drARecorrer)
            End If
         Next

         BarraProg.Maximum = dtARecorrer.Rows.Count

         If dtARecorrer.Rows.Count = 0 Then
            Throw New Exception("No hay pedidos a importar.")
         End If

         Dim tpFact As Eniac.Entidades.TipoComprobante '= New Eniac.Reglas.TiposComprobantes(da).GetUno("COTIZACION")
         Dim estadoVisita As Eniac.Entidades.EstadoVisita = New Eniac.Reglas.EstadosVisitas(da).GetUno(1)
         Dim listaDePreciosDefault As Eniac.Entidades.ListaDePrecios = New Eniac.Reglas.ListasDePrecios(da).GetUno(Publicos.ListaPreciosPredeterminada)

         Dim formasPago As Entidades.VentaFormaPago
         Dim nroPedido As Long? = Nothing
         Dim producto As Eniac.Entidades.Producto
         Dim listaDePrecios As Eniac.Entidades.ListaDePrecios
         Dim vendedor As Entidades.Empleado
         Dim fechaPedido As DateTime
         Dim fechaEntregaParaGrabar As DateTime
         Dim cliente As Entidades.Cliente
         Dim observacion As String
         Dim idProducto As String
         Dim precio As Decimal
         Dim PrecioCosto As Decimal
         Dim DescuentoRecargoPorc1 As Decimal
         Dim DescuentoRecargoPorc2 As Decimal
         Dim idClienteActual As Long = 0
         ''''Dim Marca As String
         ''''Dim Rubro As String
         ''''Dim IVA As Decimal
         ''''Dim Moneda As String

         Dim dicProductos As Dictionary(Of String, Entidades.Producto) = New Dictionary(Of String, Entidades.Producto)()
         Dim dicClientes As Dictionary(Of Long, Entidades.Cliente) = New Dictionary(Of Long, Entidades.Cliente)()

         Dim dicPedidos As Dictionary(Of String, List(Of DataRow)) = New Dictionary(Of String, List(Of DataRow))()
         Dim clavePedido As String
         Dim nroPedidoTemp As Long
         Dim idClienteTemp As Long

         Dim numeroOrdenCompra As Long

         For Each drPedido As DataRow In dtARecorrer.Rows
            i += 1
            BarraProg.Value = i
            tiempo.Text = Now.Subtract(HoraInicio).ToString()
            registroactual.Text = i.ToString() + "/"

            System.Windows.Forms.Application.DoEvents()

            nroPedidoTemp = 0
            If IsNumeric(drPedido("NumeroPedido")) Then
               nroPedidoTemp = Long.Parse(drPedido("NumeroPedido").ToString())
            End If

            idClienteTemp = Long.Parse(drPedido("IdCliente").ToString())
            clavePedido = String.Format("{0}||{1}", nroPedidoTemp, idClienteTemp)

            If Not dicPedidos.ContainsKey(clavePedido) Then
               dicPedidos.Add(clavePedido, New List(Of DataRow))
            End If
            dicPedidos(clavePedido).Add(drPedido)
         Next

         i = 0
         For Each drPedido As KeyValuePair(Of String, List(Of DataRow)) In dicPedidos ' dtARecorrer.Rows
            If IsNumeric(drPedido.Value(0)("NumeroPedido")) AndAlso Long.Parse(drPedido.Value(0)("NumeroPedido").ToString()) > 0 Then
               nroPedido = Long.Parse(drPedido.Value(0)("NumeroPedido").ToString())
            Else
               nroPedido = Nothing
            End If

            If Not IsDBNull(drPedido.Value(0)("Entidades_TipoComprobante")) Then
               tpComp = DirectCast(drPedido.Value(0)("Entidades_TipoComprobante"), Entidades.TipoComprobante)
            Else
               tpComp = tpCompDefault
            End If

            idClienteActual = Long.Parse(drPedido.Value(0)("IdCliente").ToString())

            If Not dicClientes.ContainsKey(idClienteActual) Then
               dicClientes.Add(idClienteActual, New Reglas.Clientes(da)._GetUno(idClienteActual, False))
            End If
            cliente = dicClientes(idClienteActual)
            tpFact = cache.BuscaTipoComprobante(cliente.IdTipoComprobante)

            Dim clienteVinculado As Entidades.Cliente = Nothing
            If cliente.IdClienteCtaCte > 0 Then
               If Not dicClientes.ContainsKey(cliente.IdClienteCtaCte) Then
                  dicClientes.Add(cliente.IdClienteCtaCte, New Reglas.Clientes(da)._GetUno(cliente.IdClienteCtaCte, False))
               End If
               clienteVinculado = dicClientes(cliente.IdClienteCtaCte)
            End If

            If IsDBNull(drPedido.Value(0)("Entidades_FormasPago")) Then
               formasPago = New Reglas.VentasFormasPago().GetUna(idFormaPago)
            Else
               formasPago = DirectCast(drPedido.Value(0)("Entidades_FormasPago"), Entidades.VentaFormaPago)
            End If

            If IsDBNull(drPedido.Value(0)("Entidades_Vendedor")) Then
               vendedor = cliente.Vendedor
            Else
               vendedor = DirectCast(drPedido.Value(0)("Entidades_Vendedor"), Entidades.Empleado)
            End If

            If IsDBNull(drPedido.Value(0)("FechaPedido")) Then
               fechaPedido = Date.Today
            Else
               fechaPedido = DirectCast(drPedido.Value(0)("FechaPedido"), DateTime)
            End If

            If formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Then
               fechaEntregaParaGrabar = Today
            Else
               If fechaEntrega.HasValue Then
                  fechaEntregaParaGrabar = fechaEntrega.Value
               Else
                  fechaEntregaParaGrabar = fechaPedido.AddDays(Reglas.Publicos.CantidadDiasEntregaImportacion)
               End If
            End If

            numeroOrdenCompra = ordenCompra
            If IsNumeric(drPedido.Value(0)("NumeroOrdenCompra")) AndAlso Long.Parse(drPedido.Value(0)("NumeroOrdenCompra").ToString()) > 0 Then
               numeroOrdenCompra = Long.Parse(drPedido.Value(0)("NumeroOrdenCompra").ToString())
            End If

            observacion = drPedido.Value(0)("Observaciones").ToString()


            'Arma cabecera Pedido
            pedido = rPedidos.CrearPedido(tpComp,
                                          cliente,
                                          String.Empty,
                                          Nothing,
                                          nroPedido,
                                          fechaPedido,
                                          vendedor,
                                          Nothing,
                                          Nothing,
                                          formasPago,
                                          tpFact,
                                          observacion,
                                          estadoVisita,
                                          numeroOrdenCompra,
                                          descuentoRecargoPorc:=Nothing,
                                          clienteVinculado:=clienteVinculado,
                                          idMoneda:=Entidades.Moneda.Peso, cotizacionDolar:=Nothing, 0, 0)



            For Each drPedidoProducto As DataRow In drPedido.Value
               i += 1
               BarraProg.Value = i
               tiempo.Text = Now.Subtract(HoraInicio).ToString()
               registroactual.Text = i.ToString() + "/"

               System.Windows.Forms.Application.DoEvents()


               If IsDBNull(drPedidoProducto("Entidades_ListaDePrecios")) Then
                  listaDePrecios = listaDePreciosDefault
               Else
                  listaDePrecios = DirectCast(drPedidoProducto("Entidades_ListaDePrecios"), Entidades.ListaDePrecios)
               End If

               If altaProductos Then
                  Dim oProd As Reglas.Productos = New Reglas.Productos(da)
                  If Not oProd.Existe(drPedidoProducto("IdProducto").ToString()) Then
                     oProd.InsertarProducto(actual.Sucursal.Id, drPedidoProducto("IdProducto").ToString(),
                                            drPedidoProducto("NombreProducto").ToString(), drPedido.Value(0)("NombreMarca").ToString(),
                                            drPedido.Value(0)("NombreRubro").ToString(), drPedido.Value(0)("Moneda").ToString(),
                                            Decimal.Parse(drPedido.Value(0)("IVA").ToString()), actual.Nombre, idFuncion)
                  End If

               End If

               idProducto = drPedidoProducto("IdProducto").ToString().Trim()

               If Not dicProductos.ContainsKey(idProducto) Then
                  dicProductos.Add(idProducto, New Eniac.Reglas.Productos(da).GetUno(idProducto))
               End If
               producto = dicProductos(idProducto)

               precio = Decimal.Parse(drPedidoProducto("PrecioVenta").ToString())
               If Publicos.PreciosConIVA Then
                  If tpComp.UtilizaImpuestos Then
                     If Not cliente.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
                        precio = precio
                     Else
                        precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precio, producto.Alicuota, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
                        '        Math.Round(((precio - producto.ImporteImpuestoInterno) / (1 + (producto.Alicuota / 100) + (producto.PorcImpuestoInterno / 100))), 2)
                     End If
                  Else
                     precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precio, producto.Alicuota, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
                     producto.Alicuota = 0
                  End If

               Else
                  If tpComp.UtilizaImpuestos Then
                     If Not cliente.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
                        precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precio, producto.Alicuota, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
                        '        Math.Round((precio * (1 + (producto.Alicuota / 100) + (producto.PorcImpuestoInterno / 100))) + producto.ImporteImpuestoInterno, 2)
                     Else
                        precio = precio
                     End If
                  Else
                     precio = precio
                     producto.Alicuota = 0
                  End If

               End If

               ' Verifico los siguientes campos. Si el valor es Nothing, les asigno 0 para que luego tome el valor por defecto del ProductosSucursal
               Dim temp As Decimal? = Nothing

               ' Precio Costo
               temp = drPedidoProducto.Field(Of Decimal?)("PrecioCosto")
               PrecioCosto = If(temp.HasValue, temp.Value, 0)

               ' DescRecProducto1
               temp = drPedidoProducto.Field(Of Decimal?)("DescuentoRecargoPorc")
               DescuentoRecargoPorc1 = If(temp.HasValue, temp.Value, 0)

               ' DescRecProducto2
               temp = drPedidoProducto.Field(Of Decimal?)("DescuentoRecargoPorc2")
               DescuentoRecargoPorc2 = If(temp.HasValue, temp.Value, 0)

               'If ClientePedido <> idClienteActual Then
               '   If Not estaCargando Then
               '      Try
               '         da.BeginTransaction()
               '         'Grabo el Pedido
               '         rPedidos.Inserta(pedido)
               '      Catch ex As Exception
               '         da.RollbakTransaction()
               '         Throw
               '      End Try
               '      da.CommitTransaction()
               '   Else
               '      estaCargando = False
               '   End If
               'End If



               'Carga Producto al Pedido
               rPedidos.AgregarLinea(pedido, rPedidos.CrearPedidoProducto(producto,
                                                                          producto.NombreProducto,
                                                                          DescuentoRecargoPorc1,
                                                                          DescuentoRecargoPorc2,
                                                                          precio,
                                                                          Decimal.Parse(drPedidoProducto("Cantidad").ToString()),
                                                                          tipoImpuestoIVA,
                                                                          Nothing,
                                                                          listaDePrecios,
                                                                          criticidad,
                                                                          fechaEntregaParaGrabar,
                                                                          pedido,
                                                                          2,
                                                                          Nothing,
                                                                          precioVentaPorTamano:=0,
                                                                          tamano:=0,
                                                                          idUnidadDeMedida:=String.Empty,
                                                                          moneda:=Nothing,
                                                                          espmm:=0,
                                                                          espPulgadas:=String.Empty,
                                                                          codigoSAE:=String.Empty,
                                                                          produccionProceso:=Nothing,
                                                                          produccionForma:=Nothing,
                                                                          largoExtAlto:=0,
                                                                          anchoIntBase:=0,
                                                                          architrave:=0,
                                                                          modelo:=Nothing,
                                                                          urlPlano:=String.Empty,
                                                                          idFormula:=0,
                                                                          tipoOperacion:=Entidades.Producto.TiposOperaciones.NORMAL,
                                                                          nota:="",
                                                                          costo:=PrecioCosto))

               'ClientePedido = idClienteActual
            Next           'For Each drPedidoProducto As DataRow In drPedido.Value


            EjecutaSoloConTransaccion(
               Function()
                  'Grabo el Pedido
                  If pedido.NumeroPedido > 0 Then
                     If rPedidos.ExistePedido(pedido.IdSucursal, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido) Then
                        Throw New Exception(String.Format("El {0} {1} {2:0000}-{4:00000000} ya existe. Por favor verifique.",
                                                          pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido))
                     End If
                  End If
                  rPedidos.Inserta(pedido)
                  Return True
               End Function)
         Next              'For Each drPedido As KeyValuePair(Of String, List(Of DataRow)) In dicPedidos ' dtARecorrer.Rows

         'If pedido IsNot Nothing Then
         '   Try
         '      'Grabo el ultimo Pedido
         '      da.BeginTransaction()
         '      rPedidos.Inserta(pedido)

         '   Catch ex As Exception
         '      BarraProg.Value = 0
         '      da.RollbakTransaction()
         '      Throw
         '   End Try
         '   da.CommitTransaction()
         'End If

      Catch
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Function CalculaTotalKilosItems(_ventasProductos As List(Of Entidades.PedidoProducto)) As Ventas.TotalKilosItems
      Dim result As Ventas.TotalKilosItems = New Ventas.TotalKilosItems()

      For Each vp As Entidades.PedidoProducto In _ventasProductos
         result.TotalKilos += vp.Kilos

         'Asumimos que:
         '     SI tiene decimales es un item que se vende por peso.
         '     NO tiene decimales es un item que se vende por unidad.
         'Posible problema:
         '     Un producto que se vende por peso pero el peso es redondo (sin decimales).
         '     Ejemplo: Una horma de 4kg de queso será contado como 4 productos, si fuera 4.01 será contado como 1 producto.
         If Decimal.ToInt32(vp.Cantidad) = vp.Cantidad Then
            result.TotalProductos += Decimal.ToInt32(vp.Cantidad)
         Else
            result.TotalProductos += 1
         End If

         result.TotalItems += 1
      Next

      Return result
   End Function

   Public Function GetInfPedidosFacturados(fechaDesde As Date?, fechaHasta As Date?,
                                           idCliente As Long?, codigoCliente As Long?,
                                           tolerancia As Decimal) As Entidades.DsInfPedidosFacturados
      Dim sql As SqlServer.Pedidos = New SqlServer.Pedidos(da)
      Dim dtCabeceraLocal = sql.GetInfPedidosFacturadosCabecera(fechaDesde, fechaHasta, idCliente, tolerancia)
      Dim dtDetalleLocal = sql.GetInfPedidosFacturadosDetalle(fechaDesde, fechaHasta, idCliente, tolerancia)

      Dim ds = New Entidades.DsInfPedidosFacturados()

      ds.Cabecera.Merge(dtCabeceraLocal, False, MissingSchemaAction.Ignore)
      ds.Detalle.Merge(dtDetalleLocal, False, MissingSchemaAction.Ignore)

      ds.AcceptChanges()

      Dim rPedidosWeb = New Reglas.ServiciosRest.Pedidos.PedidosSiMovilPedidos()
      Dim pedidos = rPedidosWeb.GetPedidosConFK(fechaDesde, fechaHasta,
                                                Nothing, Nothing,
                                                idRuta:=0,
                                                codigoCliente:=If(codigoCliente.HasValue, codigoCliente.Value, 0),
                                                procesado:=Entidades.Publicos.SiNoTodos.TODOS)

      Dim cacheRutas = New Reglas.MovilRutas(da).GetTodos()
      Dim cache = New BusquedasCacheadas()

      For Each pedidoWeb As Entidades.JSonEntidades.SiMovilPedidos.PedidoSiMovilJSon In pedidos
         Dim ruta As Entidades.MovilRuta = cacheRutas.FirstOrDefault(Function(x) x.IdRuta = pedidoWeb.IdRuta)
         Dim existeCabecera As Boolean = False
         For Each drCabecera As Entidades.DsInfPedidosFacturados.CabeceraRow In ds.Cabecera.Where(Function(x) x.CodigoCliente = pedidoWeb.CodigoCliente And x.FechaPedido.Date = pedidoWeb.FechaPedido.Date)
            drCabecera.IdPedidoWeb = pedidoWeb.IdPedido
            drCabecera.IdUnicoPedidoWeb = pedidoWeb.IdUnicoPedidos.ToString()
            drCabecera.NroVersionRemoto = pedidoWeb.NroVersionRemoto

            existeCabecera = True

            For Each pedidoProductoWeb As Entidades.JSonEntidades.SiMovilPedidos.PedidoProductoSiMovilJSon In pedidoWeb.PedidosProductos
               Dim existeDetalle As Boolean = False

               For Each drDetalle As Entidades.DsInfPedidosFacturados.DetalleRow In drCabecera.GetDetalleRows.Where(Function(x) x.IdProducto = pedidoProductoWeb.IdProducto)
                  drDetalle.Cantidad_PedidoWeb = pedidoProductoWeb.Cantidad
                  If ruta.PrecioConImpuestos Then
                     Dim prod As Entidades.Producto = cache.BuscaProductoEntidadPorId(pedidoProductoWeb.IdProducto)
                     drDetalle.Precio_PedidoWeb = Math.Round(CalculosImpositivos.ObtenerPrecioSinImpuestos(pedidoProductoWeb.Precio, prod), 2)
                  Else
                     drDetalle.Precio_PedidoWeb = pedidoProductoWeb.Precio
                  End If
                  drDetalle.DescuentoRecargoPorc_PedidoWeb = pedidoProductoWeb.Descuento

                  drDetalle.Diferencia_PedidoWebPedido = If(drDetalle.IsPrecio_PedidoNull, 0, drDetalle.Precio_Pedido - drDetalle.Precio_PedidoWeb)
                  drDetalle.Diferencia_PedidoWebPedido_tolerancia = If(Math.Abs(drDetalle.Diferencia_PedidoWebPedido) < tolerancia, 0, drDetalle.Diferencia_PedidoWebPedido)

                  existeDetalle = False

               Next
            Next
         Next
      Next

      Return ds
   End Function

   Public Function ReleerPedido(pedido As Entidades.Pedido) As Entidades.Pedido
      Return GetUno(pedido.IdSucursal, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido, estadoPedido:=Nothing)
   End Function

   Public Function DividirPedido(detalles As List(Of DetallesDividir), idTipoComprobante As String, pedido As Entidades.Pedido) As List(Of Entidades.Pedido)
      Return EjecutaConTransaccion(Function() _DividirPedido(detalles, idTipoComprobante, pedido))
   End Function

   Public Function _DividirPedido(detalles As List(Of DetallesDividir), idTipoComprobante As String, pedido As Entidades.Pedido) As List(Of Entidades.Pedido)
      Dim rPedido = New Pedidos(da)

      Dim tipoComprobanteNuevo = New Entidades.TipoComprobante With {
         .IdTipoComprobante = idTipoComprobante
      }

      Dim nuevo = rPedido.CrearPedido(pedido.TipoComprobante, pedido.Cliente, String.Empty, Nothing, Nothing, pedido.Fecha, pedido.Vendedor, caja:=Nothing, pedido.Transportista,
                                      pedido.FormaPago, tipoComprobanteNuevo, pedido.Observacion, pedido.EstadoVisita, Nothing,
                                      pedido.DescuentoRecargoPorc, pedido.ClienteVinculado, pedido.IdMoneda, cotizacionDolar:=Nothing, pedido.IdPlazoEntrega, pedido.ValidezPresupuesto)
      nuevo.PedidosObservaciones = pedido.PedidosObservaciones

      For Each detalle In detalles
         If detalle.CantidadDestino > 0 Then
            rPedido.AgregarLinea(nuevo, rPedido.CrearPedidoProducto(detalle.PedidoProducto.Producto, detalle.PedidoProducto.Producto.NombreProducto,
                                                                     detalle.PedidoProducto.DescuentoRecargoPorc, detalle.PedidoProducto.DescuentoRecargoPorc2,
                                                                     detalle.PedidoProducto.Precio, detalle.CantidadDestino, detalle.PedidoProducto.TipoImpuesto,
                                                                     detalle.PedidoProducto.AlicuotaImpuesto, detalle.PedidoProducto.IdListaPrecios,
                                                                     detalle.PedidoProducto.IdCriticidad, detalle.PedidoProducto.FechaEntrega,
                                                                     nuevo, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio, kilosModif:=Nothing, precioVentaPorTamano:=0,
                                                                     detalle.PedidoProducto.Tamano, detalle.PedidoProducto.IdUnidadDeMedida, detalle.PedidoProducto.Moneda,
                                                                     detalle.PedidoProducto.Espmm, detalle.PedidoProducto.EspPulgadas, detalle.PedidoProducto.CodigoSAE,
                                                                     detalle.PedidoProducto.ProduccionProceso, detalle.PedidoProducto.ProduccionForma,
                                                                     detalle.PedidoProducto.LargoExtAlto, detalle.PedidoProducto.AnchoIntBase, detalle.PedidoProducto.Architrave,
                                                                     detalle.PedidoProducto.ProduccionModeloForma, detalle.PedidoProducto.UrlPlano,
                                                                     detalle.PedidoProducto.IdFormula,
                                                                     detalle.PedidoProducto.TipoOperacion, detalle.PedidoProducto.Nota, costo:=0))
         End If
      Next

      If nuevo.PedidosProductos.Count = 0 Then
         Throw New Exception("El pedido destino no posee ninguna linea.")
      End If

      Dim original = rPedido.CrearPedido(pedido.TipoComprobante, pedido.Cliente, String.Empty, Nothing, Nothing, pedido.Fecha, pedido.Vendedor, caja:=Nothing, pedido.Transportista,
                                         pedido.FormaPago, pedido.TipoComprobanteFact, pedido.Observacion, pedido.EstadoVisita, Nothing,
                                         pedido.DescuentoRecargoPorc, pedido.ClienteVinculado, pedido.IdMoneda, cotizacionDolar:=Nothing, pedido.IdPlazoEntrega, pedido.ValidezPresupuesto)
      original.LetraComprobante = pedido.LetraComprobante
      original.CentroEmisor = pedido.CentroEmisor
      original.NumeroPedido = pedido.NumeroPedido
      original.PedidosObservaciones = pedido.PedidosObservaciones

      For Each detalle In detalles
         If detalle.CantidadOrigen > 0 Then
            rPedido.AgregarLinea(original, rPedido.CrearPedidoProducto(detalle.PedidoProducto.Producto, detalle.PedidoProducto.Producto.NombreProducto,
                                                                       detalle.PedidoProducto.DescuentoRecargoPorc, detalle.PedidoProducto.DescuentoRecargoPorc2,
                                                                       detalle.PedidoProducto.Precio, detalle.CantidadOrigen, detalle.PedidoProducto.TipoImpuesto,
                                                                       detalle.PedidoProducto.AlicuotaImpuesto, detalle.PedidoProducto.IdListaPrecios,
                                                                       detalle.PedidoProducto.IdCriticidad, detalle.PedidoProducto.FechaEntrega,
                                                                       original, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio, kilosModif:=Nothing, precioVentaPorTamano:=0,
                                                                       detalle.PedidoProducto.Tamano, detalle.PedidoProducto.IdUnidadDeMedida, detalle.PedidoProducto.Moneda,
                                                                       detalle.PedidoProducto.Espmm, detalle.PedidoProducto.EspPulgadas, detalle.PedidoProducto.CodigoSAE,
                                                                       detalle.PedidoProducto.ProduccionProceso, detalle.PedidoProducto.ProduccionForma,
                                                                       detalle.PedidoProducto.LargoExtAlto, detalle.PedidoProducto.AnchoIntBase, detalle.PedidoProducto.Architrave,
                                                                       detalle.PedidoProducto.ProduccionModeloForma, detalle.PedidoProducto.UrlPlano,
                                                                       detalle.PedidoProducto.IdFormula,
                                                                       detalle.PedidoProducto.TipoOperacion, detalle.PedidoProducto.Nota, costo:=0))
         End If
      Next

      If original.PedidosProductos.Count = 0 Then
         Throw New Exception(String.Format("El pedido origen ({1} {2} {3:0000}-{4:00000000}) se ha quedado sin lineas.", original.IdSucursal, original.IdTipoComprobante, original.LetraComprobante, original.CentroEmisor, original.NumeroPedido))
      End If

      Return rPedido.Dividir(pedido, New List(Of Entidades.Pedido)({original, nuevo}))
   End Function

   Public Function GetDetalleDividir(pedido As Entidades.Pedido) As List(Of DetallesDividir)
      Return GetDetalleDividir(pedido.PedidosProductos)
   End Function
   Public Function GetDetalleDividir(productos As List(Of Entidades.PedidoProducto)) As List(Of DetallesDividir)
      Dim result = New List(Of DetallesDividir)()
      For Each producto In productos
         result.Add(New DetallesDividir(producto))
      Next
      Return result
   End Function

   Public Function DividirFaltantePedidos(dtFaltante As DataTable) As List(Of Entidades.Pedido)
      Return EjecutaConTransaccion(Function() _DividirFaltantePedidos(dtFaltante))
   End Function
   Public Function _DividirFaltantePedidos(dtFaltante As DataTable) As List(Of Entidades.Pedido)
      Dim pedidosGenerados = New List(Of Entidades.Pedido)()

      'Armo un Dictionary para agrupar por comprobante
      'En la Key voy a tener un IPKComprobante (en nuestro caso un PKComprobante) y en el Value tendremos
      'una Tuple con el Pedido que representa dicha IPKComprobante (que voy a necesitar para el proceso de división)
      'en el Item1 de la Tuple y en el Item2 la List de DetallesDividir necesaria para el mismo proceso de división.
      Dim dicDivisiones = New Dictionary(Of Entidades.IPKComprobante, Tuple(Of Entidades.Pedido, List(Of DetallesDividir)))

      'El Dictionary lo cargo a partir del siguiente F/E
      For Each dr In dtFaltante.AsEnumerable()
         'Armo la Key del Dictionary con la PK del pedido aprobanchando PKComprobante
         Dim pkComprobante = New Entidades.PKComprobante(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                                         dr.Field(Of Short)("CentroEmisor"), dr.Field(Of Long)("NumeroPedido"))
         'Si no encuentro la PKComprobante la agrego para luego poder operar con ella
         If Not dicDivisiones.Keys.Contains(pkComprobante) Then
            'Busco el pedido, el cual voy a poner en el Item1 del Value del Dictionary. Este Pedido es necesario para el proceso de división.
            Dim pedido = GetUno(pkComprobante.IdSucursal, pkComprobante.IdTipoComprobante, pkComprobante.Letra, pkComprobante.CentroEmisor, pkComprobante.NumeroComprobante, estadoPedido:=Nothing)
            'Agrego la IPKComprobante (Key), el Pedido (Value.Item1) y la List de DetallesDividir (Value.Item2) en el Dictionary.
            dicDivisiones.Add(pkComprobante, New Tuple(Of Entidades.Pedido, List(Of DetallesDividir))(pedido, GetDetalleDividir(pedido.PedidosProductos)))
         End If

         'Busco el detalle asociado a la IPKComprobante que estan en el Dictionary
         Dim detalle = dicDivisiones(pkComprobante)
         'Obtengo la Cantidad a Dividir del DataRow que estoy procesando.
         Dim cantidadDividir = dr.Field(Of Decimal)("CantidadDividir")

         'Busco en la List de DetallesDividir que estoy evaluando por IdProducto
         For Each d In detalle.Item2.Where(Function(d1) d1.IdProducto = dr.Field(Of String)("IdProducto"))
            'Mientras me quede cantidad a dividir, voy acumulando dicha cantidad en la CantidadDestino.
            If cantidadDividir > 0 Then
               d.CantidadDestino = Math.Min(cantidadDividir, d.CantidadOriginal)
               cantidadDividir -= d.CantidadDestino
            End If
         Next
      Next
      For Each kv In dicDivisiones
         'Para cada IPKComprobante cargada en el Dictionary, ejecuto el proceso de división pasando la Lista de DetallesDividir (Value.Item2)
         'y la información del Pedido que se recupero (Value.Item1).
         pedidosGenerados.AddRange(_DividirPedido(kv.Value.Item2, kv.Value.Item1.IdTipoComprobanteFact, kv.Value.Item1))
      Next

      Return pedidosGenerados
   End Function

   Public Class DetallesDividir
      Public Enum Columnas
         IdProducto
         NombreProducto
         Cantidad
         PrecioNeto
         Precio
         ImporteTotal
         CantidadOriginal
         CantidadOrigen
         CantidadDestino
         ImporteTotalOriginal
         ImporteTotalOrigen
         ImporteTotalDestino
      End Enum

      Public Property PedidoProducto As Entidades.PedidoProducto

      Public Sub New(pedidoProducto As Entidades.PedidoProducto)
         _PedidoProducto = pedidoProducto
         _cantidadOrigen = _PedidoProducto.Cantidad
         _CantidadOriginal = _PedidoProducto.Cantidad
         _ImporteTotalOriginal = _PedidoProducto.ImporteTotal
      End Sub

#Region "Propiedades Readonly"
      Public ReadOnly Property IdProducto() As String
         Get
            If PedidoProducto Is Nothing Then
               Return String.Empty
            End If
            Return PedidoProducto.IdProducto
         End Get
      End Property

      Public ReadOnly Property NombreProducto() As String
         Get
            If PedidoProducto Is Nothing Then
               Return String.Empty
            End If
            Return PedidoProducto.NombreProducto
         End Get
      End Property

      Public ReadOnly Property Cantidad() As Decimal
         Get
            If PedidoProducto Is Nothing Then
               Return 0
            End If
            Return PedidoProducto.Cantidad
         End Get
      End Property

      Public ReadOnly Property PrecioNeto() As Decimal
         Get
            If PedidoProducto Is Nothing Then
               Return 0
            End If
            Return Math.Round(PedidoProducto.ImporteTotal / PedidoProducto.Cantidad, 2)
         End Get
      End Property

      Public ReadOnly Property ImporteTotal() As Decimal
         Get
            If PedidoProducto Is Nothing Then
               Return 0
            End If
            Return PedidoProducto.ImporteTotal * ((PedidoProducto.AlicuotaImpuesto / 100) + 1)
         End Get
      End Property

      Public ReadOnly Property ImporteTotalOrigen() As Decimal
         Get
            If PedidoProducto Is Nothing Then
               Return 0
            End If
            Return PrecioNeto * _cantidadOrigen ''* ((PedidoProducto.AlicuotaImpuesto / 100) + 1)
         End Get
      End Property

      Public ReadOnly Property ImporteTotalDestino() As Decimal
         Get
            If PedidoProducto Is Nothing Then
               Return 0
            End If
            Return PrecioNeto * _cantidadDestino ''* ((PedidoProducto.AlicuotaImpuesto / 100) + 1)
         End Get
      End Property
#End Region

      Public Property CantidadOriginal As Decimal

      Private _cantidadOrigen As Decimal
      Public Property CantidadOrigen() As Decimal
         Get
            Return _cantidadOrigen
         End Get
         Set(value As Decimal)
            If value > CantidadOriginal Then value = CantidadOriginal
            If value < 0 Then value = 0
            _cantidadOrigen = value
            _cantidadDestino = CantidadOriginal - value
         End Set
      End Property

      Private _cantidadDestino As Decimal
      Public Property CantidadDestino() As Decimal
         Get
            Return _cantidadDestino
         End Get
         Set(value As Decimal)
            If value > CantidadOriginal Then value = CantidadOriginal
            If value < 0 Then value = 0
            _cantidadDestino = value
            _cantidadOrigen = CantidadOriginal - value
         End Set
      End Property

      Public Property ImporteTotalOriginal As Decimal

   End Class
End Class