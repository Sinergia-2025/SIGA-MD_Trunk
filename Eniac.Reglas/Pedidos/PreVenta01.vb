Imports System.IO
Imports Eniac.Entidades
Imports actual = Eniac.Entidades.Usuario.Actual

Partial Class PreVenta

   Public Function AgregarArchivo(fiArchivo As FileInfo, ds As Entidades.DsPreventa) As Entidades.DsPreventa

      Try
         da.OpenConection()

         If ds.Archivo.Select(String.Format("{0} = '{1}'", ds.Archivo.NombreArchivoColumn.ColumnName, fiArchivo.Name)).Length > 0 Then
            Throw New Exception(String.Format("El archivo '{0}' ya fue agregado. No es posible agregar más de una vez el mismo archivo.", fiArchivo.Name))
         End If

         Try
            GetArchivo(fiArchivo.Name)
         Catch ex As Exception
            Throw New Exception(String.Format("El archivo '{0}' no puede ser leido: {1}.", fiArchivo.Name, ex.Message), ex)
         End Try

         Dim dr As Entidades.DsPreventa.ArchivoRow = ds.Archivo.NewArchivoRow()
         Dim formato As Entidades.PreVenta.PreventaFormatoArchivo = GetFormatoArchivo(fiArchivo)

         dr.NombreArchivo = fiArchivo.Name
         dr.PathCompletoArchivo = fiArchivo.FullName
         dr.FormatoArchivo = formato

         Select Case formato
            Case Entidades.PreVenta.PreventaFormatoArchivo.Estandar
               AgregarArchivoEstandar(fiArchivo, dr, ds)
            Case Entidades.PreVenta.PreventaFormatoArchivo.PDA_CocaCola
               AgregarArchivoPDA_CocaCola(fiArchivo, dr, ds)
            Case Else
               Throw New Exception(String.Format("Formato del archivo {0} incorrecto: {1}. Por favor verifique.", fiArchivo.Name, formato))
         End Select

         'ds.Archivo.AddArchivoRow(dr)

         ds.AcceptChanges()
      Catch
         ds.RejectChanges()
         Throw
      Finally
         da.CloseConection()
      End Try
      Return ds
   End Function

   Private Sub AgregarArchivoEstandar(fiArchivo As FileInfo, drArchivo As Entidades.DsPreventa.ArchivoRow, ds As Entidades.DsPreventa)

      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()

      Dim precioConIVA As Boolean = Publicos.PreciosConIVA
      Dim respetaListaPreciosCliente As Boolean = Publicos.PreventaV2RespetaListaPreciosCliente
      Using stmArchivo As New StreamReader(fiArchivo.FullName)
         Dim primerLinea As String = stmArchivo.ReadLine()
         Dim ruta As Entidades.MovilRuta
         Try
            ruta = New Reglas.MovilRutas(da).GetUno(Integer.Parse(primerLinea))
         Catch ex As Exception
            Throw New Exception(String.Format("Error buscando la ruta '{0}': {1}", primerLinea, ex.Message), ex)
         End Try

         Dim rVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)

         drArchivo.IdRuta = ruta.IdRuta
         drArchivo.NombreRuta = ruta.NombreRuta
         drArchivo.IdVendedor = ruta.IdVendedor
         drArchivo.NombreVendedor = New Empleados(da).GetUno(ruta.IdVendedor).NombreEmpleado

         Dim intLineas As Integer = 1

         Dim busquedasCacheadas As BusquedasCacheadas = New BusquedasCacheadas()

         Do While stmArchivo.Peek() >= 0
            Dim lineaPedido As String = stmArchivo.ReadLine()
            If Not String.IsNullOrWhiteSpace(lineaPedido) Then

               intLineas += 1

               Dim drPedido As Entidades.DsPreventa.PedidoRow = ds.Pedido.NewPedidoRow()
               drPedido.ArchivoRow = drArchivo

               drPedido.IdSucursal = actual.Sucursal.Id
               drPedido.IdTipoComprobante = "PEDIDO"
               drPedido.Letra = "X"
               drPedido.CentroEmisor = 0
               drPedido.NumeroPedido = ds.Pedido.Count + 1
               drPedido.IdRuta = drArchivo.IdRuta
               drPedido.NombreRuta = ruta.NombreRuta

               Dim primerNivel As String() = lineaPedido.Split(";"c)

               Try
                  drPedido.FechaPedido = DateTime.ParseExact(primerNivel(0), "dd/MM/yyyy HH:mm", Globalization.CultureInfo.InvariantCulture)
               Catch ex As Exception
                  Throw New Exception("ATENCION: Problema con el Pedido de la Linea: " & intLineas.ToString() & " Fecha: " & primerNivel(0))

                  'GAR: 02/02/2017 - Hacerlo Mejor porque igual da error mas abajo.
                  'drPedido.Pasa = False
                  'drPedido.Estado = Entidades.PreventaEstadoPedido.ConError
                  'drPedido.MensajeError = "Fecha Invalida. Valor: " & primerNivel(0) & ". Linea del Archivo: " & intLineas.ToString()
                  '---------------------
               End Try

               drPedido.Pasa = True
               drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal
               Dim cliente As Entidades.Cliente
               Try
                  cliente = New Reglas.Clientes(da).GetUnoPorCodigo(Long.Parse(primerNivel(1)))
               Catch ex As Exception
                  cliente = Nothing
               End Try

               If cliente Is Nothing Then
                  drPedido.Pasa = False
                  drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                  drPedido.MensajeError = "CLIENTE INACTIVO o INEXISTENTE - "
                  drPedido.IdCliente = Long.Parse(primerNivel(1))
                  drPedido.CodigoCliente = Long.Parse(primerNivel(1))
               Else
                  drPedido.IdCliente = cliente.IdCliente
                  drPedido.CodigoCliente = cliente.CodigoCliente
                  drPedido.TipoDocCliente = cliente.TipoDocCliente
                  drPedido.NroDocCliente = cliente.NroDocCliente
                  drPedido.NombreCliente = cliente.NombreCliente
                  drPedido.Direccion = cliente.Direccion
                  drPedido.NombreCategoriaFiscalAbrev = cliente.CategoriaFiscal.NombreCategoriaFiscalAbrev
                  drPedido.CUIT = cliente.Cuit

                  drPedido.PorcDesc = rVentas.DescuentoRecargo(cliente, cache.BuscaTipoComprobante("PEDIDO"), cache.BuscaFormasPago(cliente.IdFormasPago),
                                                               cantidadLineasVenta:=0)    'TODO: Se pasa 0 porque el cambio es grande y se carga el PE-27095

                  Dim transportista As Eniac.Entidades.Transportista = cache.BuscaTransportista(cliente.IdTransportista)

                  If (transportista) Is Nothing Then
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     drPedido.MensajeError = "EL CLIENTE NO TIENE ASIGNADO TRANSPORTISTA - "
                  ElseIf transportista.NombreTransportista = ".SIN FLETE" Then
                     drPedido.IdTransportista = ruta.IdTransportista.IfNull
                     drPedido.NombreTransportista = cache.BuscaTransportista(ruta.IdTransportista.IfNull).NombreTransportista
                  Else
                     drPedido.IdTransportista = transportista.idTransportista
                     drPedido.NombreTransportista = transportista.NombreTransportista
                  End If

                  If ExistePedidoCliente(actual.Sucursal.Id, drPedido.IdCliente, drPedido.FechaPedido) Then
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     drPedido.MensajeError = "PEDIDO YA INGRESADO - "
                  End If

               End If

               Dim estadoVisita As Eniac.Entidades.EstadoVisita
               Try
                  estadoVisita = GetEstadoVisita(Integer.Parse(primerNivel(2)))
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

               ''drPedido.Observaciones = primerNivel(primerNivel.Length - 1)

               If Not ds.Archivo.Contains(drArchivo) Then
                  ds.Archivo.AddArchivoRow(drArchivo)
               End If
               ds.Pedido.AddPedidoRow(drPedido)

               Dim posicionObservaciones As Integer
               posicionObservaciones = 3

               For index As Integer = 3 To primerNivel.Length - 1
                  posicionObservaciones = index
                  Dim lineaPedidoArticulo As String = primerNivel(index)
                  Dim lineaArticulo As String() = lineaPedidoArticulo.Split("#"c)
                  If lineaArticulo.Length < 3 Then Exit For

                  Dim idListaPrecios As Integer
                  Try
                     idListaPrecios = cliente.IdListaPrecios
                  Catch
                     Throw
                  End Try
                  If Not respetaListaPreciosCliente Then
                     Dim idListaPreciosArchivo As Integer = -1
                     If lineaArticulo.Length > 3 Then
                        idListaPreciosArchivo = Integer.Parse(lineaArticulo(4))
                        If idListaPreciosArchivo > -1 Then
                           idListaPrecios = idListaPreciosArchivo
                        End If
                     End If
                  End If

                  Dim producto As Eniac.Entidades.ProductoSucursal

                  producto = busquedasCacheadas.GetProductosSucursales(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
                                                                       lineaArticulo(0),
                                                                       idListaPrecios)

                  'Try
                  '   producto = New Eniac.Reglas.ProductosSucursales(da).GetUno(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
                  '                                                              lineaArticulo(0),
                  '                                                              cliente.ListaDePrecios.IdListaPrecios)
                  'Catch ex As Exception
                  '   producto = Nothing
                  'End Try
                  Dim drPedidoProducto As Entidades.DsPreventa.PedidoProductoRow = ds.PedidoProducto.NewPedidoProductoRow()
                  drPedidoProducto.IdProducto = lineaArticulo(0)
                  drPedidoProducto.Cantidad = Decimal.Parse(lineaArticulo(1))
                  drPedidoProducto.PrecioMovil = Decimal.Parse(lineaArticulo(2))


                  If lineaArticulo.Length > 5 Then drPedidoProducto.CantidadCambio = Decimal.Parse(lineaArticulo(5))
                  If lineaArticulo.Length > 6 Then drPedidoProducto.CantidadBonif = Decimal.Parse(lineaArticulo(6))
                  If lineaArticulo.Length > 7 Then drPedidoProducto.NotaCambio = lineaArticulo(7)
                  If lineaArticulo.Length > 8 Then drPedidoProducto.NotaBonif = lineaArticulo(8)


                  drPedidoProducto.IdListaPrecios = idListaPrecios
                  drPedidoProducto.PedidoRowParent = drPedido
                  drPedidoProducto.Orden = ds.PedidoProducto.Count + 1

                  If producto Is Nothing OrElse String.IsNullOrWhiteSpace(producto.Producto.IdProducto) Then
                     drPedidoProducto.Precio = 0
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     drPedido.MensajeError += "ARTICULO INACTIVO o INEXISTENTE - "
                  Else
                     drPedidoProducto.NombreProducto = producto.Producto.NombreProducto
                     drPedidoProducto.PrecioLista = producto.PrecioVentaLista
                     drPedidoProducto.Stock = producto.Stock
                     drPedidoProducto.IVA = producto.Producto.Alicuota
                     If Publicos.PreVentaAgrupaOrdenProductoEnCadaPedido Then
                        drPedidoProducto.OrdenProducto = producto.Producto.Orden
                     End If

                     Dim listaPrecios As Eniac.Entidades.ListaDePrecios = busquedasCacheadas.BuscaListaDePrecios(idListaPrecios)
                     If listaPrecios IsNot Nothing Then
                        drPedidoProducto.NombreListaPrecios = listaPrecios.NombreListaPrecios
                     Else
                        drPedido.Pasa = False
                        drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                        drPedido.MensajeError += "LISTA DE PRECIOS INEXISTENTE - "
                     End If

                     If ruta.PuedeModificarPrecio Then
                        Dim precioMovil As Decimal = drPedidoProducto.PrecioMovil
                        If (precioConIVA And ruta.PrecioConImpuestos) Or
                           (Not precioConIVA And Not ruta.PrecioConImpuestos) Then
                           drPedidoProducto.Precio = precioMovil
                        Else
                           If precioConIVA And Not ruta.PrecioConImpuestos Then
                              drPedidoProducto.Precio = (precioMovil * (1 + (drPedidoProducto.IVA / 100))) + producto.Producto.ImporteImpuestoInterno
                           ElseIf Not precioConIVA And ruta.PrecioConImpuestos Then
                              drPedidoProducto.Precio = (precioMovil - producto.Producto.ImporteImpuestoInterno) / (1 + (drPedidoProducto.IVA / 100))
                           End If
                        End If
                     Else
                        drPedidoProducto.Precio = producto.PrecioVentaLista
                     End If

                     Dim descRec As Eniac.Reglas.DescuentoRecargoProducto = rVentas.DescuentoRecargo(cliente, producto.Producto, drPedidoProducto.Cantidad)
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



                  'drPedidoProducto.Precio = drPedidoProducto.Precio + (drPedidoProducto.Precio * drPedidoProducto.PorcDesc1 / 100)
                  'drPedidoProducto.Precio = drPedidoProducto.Precio + (drPedidoProducto.Precio * drPedidoProducto.PorcDesc2 / 100)


                  Dim importe As Decimal = Math.Round(drPedidoProducto.Precio, 2) * drPedidoProducto.Cantidad
                  'If Not precioConIVA Then
                  '   importe = Math.Round(drPedidoProducto.Precio +
                  '                        (drPedidoProducto.Precio * drPedidoProducto.IVA / 100), 2) * drPedidoProducto.Cantidad
                  'End If

                  'importe = importe + (importe * drPedidoProducto.PorcDesc1 / 100)
                  'importe = importe + (importe * drPedidoProducto.PorcDesc2 / 100)

                  drPedidoProducto.ImporteTotal = importe

                  importe = importe + (importe * drPedido.PorcDesc / 100)

                  drPedido.ImporteTotal += importe

                  If drPedidoProducto.Cantidad <> 0 Or drPedidoProducto.CantidadCambio <> 0 Or drPedidoProducto.CantidadBonif <> 0 Then
                     ds.PedidoProducto.AddPedidoProductoRow(drPedidoProducto)
                  End If
               Next

               'posicionObservaciones += 1

               drPedido.Observaciones = primerNivel(posicionObservaciones) ''primerNivel.Length - 1)

               If estadoVisita IsNot Nothing Then
                  Dim mensaje As String = ValidaEstadoVisita(estadoVisita, drPedido)
                  If Not String.IsNullOrWhiteSpace(mensaje) Then
                     drPedido.Pasa = False
                     If drPedido.Estado Is Nothing OrElse DirectCast(drPedido.Estado, Entidades.PreVenta.PreventaEstadoPedido) = Entidades.PreVenta.PreventaEstadoPedido.Normal Then
                        drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Corregible
                        drPedido.MensajeError = String.Empty
                     End If
                     drPedido.MensajeError += mensaje
                  End If
               End If

            End If
         Loop
      End Using
   End Sub

   Private Sub AgregarArchivoPDA_CocaCola(fiArchivo As FileInfo, drArchivo As Entidades.DsPreventa.ArchivoRow, ds As Entidades.DsPreventa)

      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()

      Dim arPDA As Entidades.ArchivoPDA = New Entidades.ArchivoPDA()

      Dim estadoVisita As List(Of Eniac.Entidades.EstadoVisita) = New Eniac.Reglas.EstadosVisitas().GetTodos(False, True)
      Dim preventaV2ImportaDescuentos As Boolean = Publicos.PreventaV2ImportaDescuentosPedidosPDA


      Using stmArchivo As New StreamReader(fiArchivo.FullName)
         arPDA = arPDA.GetInfo(stmArchivo)

         If arPDA.Datos.Count > 0 Then
            Dim ruta As Entidades.MovilRuta
            Try
               ruta = New Reglas.MovilRutas(da).GetUno(arPDA.Datos(0).CodigoRuta)
            Catch ex As Exception
               Throw New Exception(String.Format("Error buscando la ruta '{0}': {1}", arPDA.Datos(0).CodigoRuta, ex.Message), ex)
            End Try

            drArchivo.IdRuta = ruta.IdRuta
            drArchivo.NombreRuta = ruta.NombreRuta
            drArchivo.IdVendedor = ruta.IdVendedor

            drArchivo.NombreVendedor = New Empleados(da).GetUno(ruta.IdVendedor).NombreEmpleado

            Dim stbMensajeError As StringBuilder

            For Each lineaPedido As Entidades.ArchivoPDADatos In arPDA.Datos
               Dim cliente As Entidades.Cliente = Nothing

               Dim centroEmisor As Short = Short.Parse(lineaPedido.NroPedido.Split("-"c)(0))
               Dim numeroPedido As Long = Long.Parse(lineaPedido.NroPedido.Split("-"c)(1))
               Dim drPedido As Entidades.DsPreventa.PedidoRow
               Dim drCol() As DataRow
               drCol = ds.Pedido.Select(String.Format("NombreArchivo = '{0}' And CentroEmisor = {1} And NumeroPedido = {2}",
                                                      drArchivo.NombreArchivo, centroEmisor, numeroPedido))
               Try
                  cliente = New Reglas.Clientes(da).GetUnoPorCodigo(Long.Parse(lineaPedido.CodigoCliente), True)
               Catch ex As Exception
                  cliente = Nothing
               End Try

               stbMensajeError = New StringBuilder()

               If drCol.Length = 0 Then
                  drPedido = ds.Pedido.NewPedidoRow()
                  drPedido.ArchivoRow = drArchivo
                  drPedido.IdSucursal = actual.Sucursal.Id
                  drPedido.IdTipoComprobante = "PEDIDOPDA"
                  drPedido.Letra = "X"
                  drPedido.CentroEmisor = centroEmisor
                  drPedido.NumeroPedido = numeroPedido
                  drPedido.IdRuta = drArchivo.IdRuta
                  drPedido.NombreRuta = ruta.NombreRuta

                  drPedido.IdEstadoVenta = estadoVisita(0).IdEstadoVisita
                  drPedido.NombreEstadoVenta = estadoVisita(0).NombreEstadoVisita

                  drPedido.FechaPedido = lineaPedido.Fecha

                  drPedido.Pasa = True
                  drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal
                  drPedido.MensajeError = String.Empty
                  drPedido.CodigoCliente = Long.Parse(lineaPedido.CodigoCliente)

                  If cliente Is Nothing Then
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     stbMensajeError.AppendFormat("CLIENTE INACTIVO o INEXISTENTE - ")
                     drPedido.IdCliente = drPedido.CodigoCliente
                  Else
                     drPedido.IdCliente = cliente.IdCliente
                     drPedido.CodigoCliente = cliente.CodigoCliente
                     drPedido.TipoDocCliente = cliente.TipoDocCliente
                     drPedido.NroDocCliente = cliente.NroDocCliente
                     drPedido.NombreCliente = cliente.NombreCliente
                     drPedido.Direccion = cliente.Direccion
                     drPedido.NombreCategoriaFiscalAbrev = cliente.CategoriaFiscal.NombreCategoriaFiscalAbrev
                     drPedido.CUIT = cliente.Cuit

                     Dim tpCompPedido = cache.BuscaTipoComprobante("PEDIDO")
                     drPedido.PorcDesc = New CalculosDescuentosRecargos().DescuentoRecargo(cliente, tpCompPedido.GrabaLibro, tpCompPedido.EsPreElectronico, cache.BuscaFormasPago(cliente.IdFormasPago),
                                                                                           cantidadLineasVenta:=0)   'TODO: Se pasa 0 porque el cambio es grande y se carga el PE-27094

                     If cache.BuscaTransportista(cliente.IdTransportista).NombreTransportista = ".SIN FLETE" Then
                        drPedido.IdTransportista = ruta.IdTransportista.IfNull
                        drPedido.NombreTransportista = cache.BuscaTransportista(ruta.IdTransportista.IfNull).NombreTransportista
                     Else
                        drPedido.IdTransportista = cache.BuscaTransportista(cliente.IdTransportista).idTransportista
                        drPedido.NombreTransportista = cache.BuscaTransportista(cliente.IdTransportista).NombreTransportista
                     End If

                     'If ExistePedidoPDA(actual.Sucursal.Id, Long.Parse(lineaPedido.NroPedido.Split("-"c)(1))) Then
                     If ExistePedidoPDA(actual.Sucursal.Id, PDACocaCola_CombinarEmisorNumero(Short.Parse(lineaPedido.NroPedido.Split("-"c)(0)),
                                                                                             Long.Parse(lineaPedido.NroPedido.Split("-"c)(1)))) Then
                        drPedido.Pasa = False
                        drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                        stbMensajeError.AppendFormat("PEDIDO YA INGRESADO")
                     End If

                  End If

                  If Not ds.Archivo.Contains(drArchivo) Then
                     ds.Archivo.AddArchivoRow(drArchivo)
                  End If
                  ds.Pedido.AddPedidoRow(drPedido)
               Else
                  drPedido = DirectCast(drCol(0), Entidades.DsPreventa.PedidoRow)
               End If

               Dim drPedidoProducto As Entidades.DsPreventa.PedidoProductoRow = ds.PedidoProducto.NewPedidoProductoRow()
               drPedidoProducto.PedidoRowParent = drPedido
               drPedidoProducto.IdProducto = lineaPedido.CodigoProducto.Trim()

               Dim producto As Eniac.Entidades.ProductoSucursal
               Try
                  If cliente IsNot Nothing Then
                     producto = New Eniac.Reglas.ProductosSucursales(da).GetUno(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
                                                                                drPedidoProducto.IdProducto,
                                                                                cliente.IdListaPrecios)
                  Else
                     producto = New Eniac.Reglas.ProductosSucursales(da).GetUno(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
                                                                                drPedidoProducto.IdProducto,
                                                                                Publicos.ListaPreciosPredeterminada)
                  End If
               Catch ex As Exception
                  producto = Nothing
               End Try

               drPedidoProducto.Cantidad = lineaPedido.Cantidad
               'drPedidoProducto.Precio = lineaPedido.Precio
               drPedidoProducto.PrecioMovil = lineaPedido.Precio
               drPedidoProducto.Precio = producto.PrecioVentaLista
               drPedidoProducto.Orden = ds.PedidoProducto.Count + 1

               ds.PedidoProducto.AddPedidoProductoRow(drPedidoProducto)

               If producto Is Nothing OrElse String.IsNullOrWhiteSpace(producto.Producto.IdProducto) Then
                  drPedido.Pasa = False
                  drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                  stbMensajeError.AppendFormat("ARTICULO INACTIVO o INEXISTENTE")
               Else
                  drPedidoProducto.NombreProducto = producto.Producto.NombreProducto
                  drPedidoProducto.Stock = producto.Stock
                  If Publicos.PreciosConIVA Then
                     drPedidoProducto.PrecioListaConIVA = producto.PrecioVentaLista
                     drPedidoProducto.PrecioLista = CalculosImpositivos.ObtenerPrecioSinImpuestos(producto.PrecioVentaLista, producto.Producto)

                     drPedidoProducto.PrecioConIVA = drPedidoProducto.Precio
                     drPedidoProducto.Precio = CalculosImpositivos.ObtenerPrecioSinImpuestos(drPedidoProducto.Precio, producto.Producto)

                     drPedidoProducto.PrecioMovilConIVA = drPedidoProducto.PrecioMovil
                     drPedidoProducto.PrecioMovil = CalculosImpositivos.ObtenerPrecioSinImpuestos(drPedidoProducto.PrecioMovil, producto.Producto)
                  Else
                     drPedidoProducto.PrecioLista = producto.PrecioVentaLista
                     drPedidoProducto.PrecioListaConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(producto.PrecioVentaLista, producto.Producto)

                     drPedidoProducto.Precio = drPedidoProducto.Precio
                     drPedidoProducto.PrecioConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(drPedidoProducto.Precio, producto.Producto)

                     drPedidoProducto.PrecioMovil = drPedidoProducto.PrecioMovil
                     drPedidoProducto.PrecioMovilConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(drPedidoProducto.PrecioMovil, producto.Producto)
                  End If

                  If cliente IsNot Nothing Then
                     Dim descRec = New CalculosDescuentosRecargos().DescuentoRecargo(cliente, producto.Producto.IdProducto, drPedidoProducto.Cantidad, decimalesRedondeoEnPrecio:=2)
                     drPedidoProducto.PorcDesc1 = descRec.DescuentoRecargo1
                     drPedidoProducto.PorcDesc2 = descRec.DescuentoRecargo2
                  End If


                  'If lineaPedido.Porcentaje <> 0 Then
                  '   If drPedidoProducto.PorcDesc1 = 0 Then
                  '      drPedidoProducto.PorcDesc1 = lineaPedido.Porcentaje * -1
                  '   ElseIf drPedidoProducto.PorcDesc2 = 0 Then
                  '      drPedidoProducto.PorcDesc2 = lineaPedido.Porcentaje * -1
                  '   Else
                  '      Dim desc1 As Decimal = (100 + drPedidoProducto.PorcDesc1) / 100
                  '      Dim desc2 As Decimal = (100 + lineaPedido.Porcentaje * -1) / 100

                  '      drPedidoProducto.PorcDesc1 = Decimal.Round(((desc1 * desc2) - 1) * 100, 2)
                  '   End If
                  'End If
               End If

               Dim importe As Decimal = Math.Round(drPedidoProducto.PrecioLista, 2) * drPedidoProducto.Cantidad
               If Not Publicos.PreciosConIVA Then
                  importe = Math.Round(drPedidoProducto.PrecioLista +
                                       (drPedidoProducto.PrecioLista * drPedidoProducto.IVA / 100), 2) * drPedidoProducto.Cantidad
               End If

               Dim desc1 As Decimal = 0
               If lineaPedido.PorcentajeRetornable <> 0 Then
                  If preventaV2ImportaDescuentos And drPedido.Pasa Then
                     desc1 = lineaPedido.PorcentajeRetornable * -1
                     drPedido.Pasa = True
                  Else
                     drPedido.Pasa = False
                  End If
                  If drPedido.Estado.ToString() <> "ConError" Then
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                     stbMensajeError.Clear()
                     stbMensajeError.AppendFormat("PEDIDO CON ARTICULOS CON DESCUENTO")
                  End If
               End If

               '-- REQ-31246.- --
               Dim desc2 As Decimal = 0
               Dim tempDesc2 As Decimal = CalculosDescuentosRecargos.CombinaDosDescuentos(lineaPedido.Porcentaje * -1, lineaPedido.PorcentajeDescuento2 * -1, 2) * -1
               If tempDesc2 <> 0 Then
                  If preventaV2ImportaDescuentos And drPedido.Pasa Then
                     desc2 = tempDesc2 * -1
                     drPedido.Pasa = True
                  Else
                     drPedido.Pasa = False
                  End If
                  If drPedido.Estado.ToString() <> "ConError" Then
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                     stbMensajeError.Clear()
                     stbMensajeError.AppendFormat("PEDIDO CON ARTICULOS CON DESCUENTO")
                  End If
               End If
               If drPedido.Pasa And (desc1 <> 0 Or desc2 <> 0) Then
                  drPedidoProducto.PorcDesc1 = desc1
                  drPedidoProducto.PorcDesc2 = desc2
               End If

               importe = importe + (importe * drPedidoProducto.PorcDesc1 / 100)
               importe = importe + (importe * drPedidoProducto.PorcDesc2 / 100)

               drPedidoProducto.ImporteTotal = importe

               importe = importe + (importe * drPedido.PorcDesc / 100)

               drPedido.ImporteTotal += importe

               drPedidoProducto.CantidadSinCargo = lineaPedido.CantidadSinCargo
               drPedidoProducto.CantidadFaltante = lineaPedido.CantidadFaltante
               drPedidoProducto.CantidadDevolucion = lineaPedido.CantidadDevolucion

               '------------------
               If drPedidoProducto.CantidadSinCargo <> 0 Or
                  drPedidoProducto.CantidadFaltante <> 0 Or
                  drPedidoProducto.CantidadDevolucion <> 0 Then
                  drPedido.Pasa = False
                  If drPedido.Estado.ToString() <> "ConError" Then
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                     stbMensajeError.Clear()
                     stbMensajeError.AppendFormat("PEDIDO CON ARTICULOS CON NOVEDADES")
                  End If
               End If
               drPedido.MensajeError = stbMensajeError.ToString()
            Next
         End If
      End Using
   End Sub

   Private Function PDACocaCola_CombinarEmisorNumero(centroEmisor As Short, numeroPedido As Long) As Long
      Return centroEmisor * 1000000 + numeroPedido
   End Function

   Private Function GetFormatoArchivo(fiArchivo As FileInfo) As Entidades.PreVenta.PreventaFormatoArchivo
      Using stmArchivo As New StreamReader(fiArchivo.FullName)
         Dim primerLinea As String = stmArchivo.ReadLine()
         Dim idRuta As Integer
         If Integer.TryParse(primerLinea, idRuta) Then
            Return Entidades.PreVenta.PreventaFormatoArchivo.Estandar
         Else
            Return Entidades.PreVenta.PreventaFormatoArchivo.PDA_CocaCola
         End If
      End Using
   End Function

   Public Function GetEstadoVisita(ByVal idestado As Integer) As Eniac.Entidades.EstadoVisita
      Return New Eniac.Reglas.EstadosVisitas(da).GetUno(idestado)
   End Function

   Private Function ExistePedidoCliente(idSucursal As Integer, IdCliente As Long, fechaPedido As DateTime) As Boolean
      Return New Reglas.Pedidos(da).ExistePedido(idSucursal, IdCliente, fechaPedido)
   End Function

   Private Function ExistePedidoPDA(idSucursal As Integer, NumeroPedido As Long) As Boolean
      Return New Reglas.Pedidos(da).ExistePedido(idSucursal, NumeroPedido)
   End Function

End Class