#Region "Options/Imports"
Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports System.Net
Imports System.Runtime.Serialization.Json
#End Region
Namespace ServiciosRest.Pedidos
   Public Class PedidosSiWeb
      Inherits BasePedidosWeb

#Region "GET"
      Public Overrides Function AgregarPedidoWeb(ds As Entidades.DsPreventa, da As Datos.DataAccess, rutasSeleccionadas As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)) As Entidades.DsPreventa
         Try
            Dim cache As Reglas.BusquedasCacheadas = New BusquedasCacheadas()
            da.OpenConection()

            Dim rVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)
            Dim pedidos As List(Of PedidoWeb)
            pedidos = GetPedidos(New Uri(Reglas.Publicos.PedidosURLWebGET))
            '  "http://www.siweb.com.ar/sistema/rest/index.php/api/pedido/cuitempresa/30713688300"))


            For Each pedido As PedidoWeb In pedidos
               Dim vendedor As Eniac.Entidades.Empleado
               Try
                  vendedor = New Eniac.Reglas.Empleados(da).GetUno(Integer.Parse(pedido.CodigoVendedor))
               Catch ex As Exception
                  vendedor = Nothing
               End Try

               Dim cliente As Entidades.Cliente = Nothing
               Try
                  cliente = New Reglas.Clientes(da).GetUnoPorCodigo(Long.Parse(pedido.CodigoCliente))
               Catch ex As Exception
                  cliente = Nothing
               End Try

               If vendedor Is Nothing Then
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

                  drArchivo.NombreArchivo = "Pedidos Web de " + pedido.VendedorName
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

               '' ''drArchivo.IdRuta = Ruta.IdRuta
               '' ''drArchivo.NombreRuta = Ruta.NombreRuta

               Dim drPedido As DsPreventa.PedidoRow = ds.Pedido.NewPedidoRow()
               drPedido.ArchivoRow = drArchivo
               drPedido.CentroEmisor = 0
               drPedido.NumeroPedido = Convert.ToInt64(pedido.IdPedido)

               drPedido.FechaPedido = DateTime.ParseExact(pedido.FechaFormato, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)

               drPedido.Pasa = True
               drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal

               Dim estadoVisita As Eniac.Entidades.EstadoVisita
               Try
                  estadoVisita = New Reglas.EstadosVisitas(da).GetUno(1)
               Catch ex As Exception
                  estadoVisita = Nothing
               End Try
               If estadoVisita Is Nothing Then
                  drPedido.Pasa = False
                  drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                  drPedido.MensajeError = "ESTADO DE VISITA INEXISTENTE"
               Else
                  drPedido.IdEstadoVenta = estadoVisita.IdEstadoVisita
                  drPedido.NombreEstadoVenta = estadoVisita.NombreEstadoVisita
               End If

               If cliente Is Nothing Then
                  drPedido.MensajeError = "CLIENTE INACTIVO o INEXISTENTE"
                  drPedido.Pasa = False
                  drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
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

                  drPedido.PorcDesc = rVentas.DescuentoRecargo(cliente, cache.BuscaTipoComprobante("PEDIDO"), cache.BuscaFormasPago(cliente.IdFormasPago),
                                                               pedido.Detalle.Count)

                  ''If cliente.Transportista.NombreTransportista = ".SIN FLETE" Then

                  ''   Dim ruta As Entidades.Ruta
                  ''   Try
                  ''      ruta = New SiLIVE.Reglas.Rutas(da)._GetUno(vendedor.TipoDocEmpleado, vendedor.NroDocEmpleado, cliente.IdCliente, drPedido.FechaPedido)
                  ''   Catch ex As Exception
                  ''      ruta = Nothing
                  ''   End Try
                  ''   If ruta IsNot Nothing Then
                  ''      drPedido.IdTransportista = ruta.IdTransportista
                  ''      drPedido.NombreTransportista = ruta.Transportista.NombreTransportista
                  ''   End If
                  ''Else
                  ''   drPedido.IdTransportista = cliente.Transportista.idTransportista
                  ''   drPedido.NombreTransportista = cliente.Transportista.NombreTransportista
                  ''End If

                  If ds.Pedido.Select(String.Format("{0} = {1} AND {2} = {3}",
                                                    ds.Pedido.CentroEmisorColumn.ColumnName, 0,
                                                    ds.Pedido.NumeroPedidoColumn.ColumnName, pedido.IdPedido)).Length > 0 Then
                     Exit For
                  End If

                  If ExistePedidoWeb(drPedido.IdSucursal, drPedido.NumeroPedido) Then
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     drPedido.MensajeError = "PEDIDO YA INGRESADO"
                  End If
               End If

               If Not ds.Archivo.Contains(drArchivo) Then
                  ds.Archivo.AddArchivoRow(drArchivo)
               End If
               ds.Pedido.AddPedidoRow(drPedido)

               For Each pedidoDetalle As PedidoWebDetalle In pedido.Detalle


                  Dim drPedidoProducto As Entidades.DsPreventa.PedidoProductoRow = ds.PedidoProducto.NewPedidoProductoRow()
                  drPedidoProducto.PedidoRowParent = drPedido
                  drPedidoProducto.IdProducto = pedidoDetalle.CodigoProducto
                  drPedidoProducto.Orden = 0
                  ds.PedidoProducto.AddPedidoProductoRow(drPedidoProducto)

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

                  drPedidoProducto.Cantidad = Decimal.Parse(pedidoDetalle.Cantidad)
                  drPedidoProducto.Precio = Decimal.Parse(pedidoDetalle.PrecioUnitario)
                  drPedidoProducto.Orden = ds.PedidoProducto.Count

                  If producto Is Nothing OrElse String.IsNullOrWhiteSpace(producto.Producto.IdProducto) Then
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     drPedido.MensajeError = "ARTICULO INACTIVO o INEXISTENTE"
                  Else
                     drPedidoProducto.NombreProducto = producto.Producto.NombreProducto
                     drPedidoProducto.PrecioLista = producto.PrecioVentaLista
                     drPedidoProducto.Stock = producto.Stock

                     Dim descRec As Eniac.Reglas.DescuentoRecargoProducto = rVentas.DescuentoRecargo(cliente, producto.Producto, drPedidoProducto.Cantidad)
                     drPedidoProducto.PorcDesc1 = descRec.DescuentoRecargo1
                     drPedidoProducto.PorcDesc2 = descRec.DescuentoRecargo2

                     If Decimal.Parse(pedidoDetalle.DescuentoPorcentaje) <> 0 Then
                        If drPedidoProducto.PorcDesc1 = 0 Then
                           drPedidoProducto.PorcDesc1 = Decimal.Parse(pedidoDetalle.DescuentoPorcentaje) * -1
                        ElseIf drPedidoProducto.PorcDesc2 = 0 Then
                           drPedidoProducto.PorcDesc2 = Decimal.Parse(pedidoDetalle.DescuentoPorcentaje) * -1
                        Else
                           Dim desc1 As Decimal = (100 + drPedidoProducto.PorcDesc1) / 100
                           Dim desc2 As Decimal = (100 + Decimal.Parse(pedidoDetalle.DescuentoPorcentaje) * -1) / 100

                           drPedidoProducto.PorcDesc1 = Decimal.Round(((desc1 * desc2) - 1) * 100, 2)
                        End If
                     End If
                  End If

                  Dim importe As Decimal = Math.Round(drPedidoProducto.PrecioLista, 2) * drPedidoProducto.Cantidad
                  If Not Publicos.PreciosConIVA Then
                     importe = Math.Round(drPedidoProducto.PrecioLista +
                                          (drPedidoProducto.PrecioLista * drPedidoProducto.IVA / 100), 2) * drPedidoProducto.Cantidad
                  End If

                  importe = importe + (importe * drPedidoProducto.PorcDesc1 / 100)
                  importe = importe + (importe * drPedidoProducto.PorcDesc2 / 100)

                  drPedidoProducto.ImporteTotal = importe

                  importe = importe + (importe * drPedido.PorcDesc / 100)

                  drPedido.ImporteTotal += importe

                  If drPedidoProducto.PorcDesc1 <> 0 Or
                     drPedidoProducto.PorcDesc2 <> 0 Or
                     drPedidoProducto.CantidadSinCargo <> 0 Or
                     drPedidoProducto.CantidadFaltante <> 0 Or
                     drPedidoProducto.CantidadDevolucion <> 0 Then
                     drPedido.Pasa = False
                     drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                     drPedido.MensajeError = "PEDIDO CON ARTICULOS CON NOVEDADES"
                  End If
               Next
            Next

            ds.AcceptChanges()
         Catch
            ds.RejectChanges()
            Throw
         Finally
            da.CloseConection()
         End Try
         Return ds
      End Function

      Public Function GetPedidos(uri As Uri) As List(Of PedidoWeb)
         Dim wc As New WebClient()
         Dim orResult As System.IO.Stream = wc.OpenRead(uri)

         Dim ser As New DataContractJsonSerializer(GetType(List(Of PedidoWeb)))
         Dim pedidos As List(Of PedidoWeb) = TryCast(ser.ReadObject(orResult), List(Of PedidoWeb))

         Return pedidos
      End Function

      Private Function ExistePedidoWeb(idSucursal As Integer, NumeroPedido As Long) As Boolean
         Return New Reglas.Pedidos().ExistePedido(idSucursal, "PEDIDOWEB", NumeroPedido)
      End Function
#End Region

#Region "PUT"
      Public Overrides Sub SetEstadoPedidoProcesado(idPedidoWeb As Entidades.DsPreventa.PedidoRow, estado As BasePedidosWeb.EstadoSiWeb)
         GetPUTResponse(New Uri(String.Format("http://www.siweb.com.ar/sistema/rest/index.php/api/pedido/id/{0}/estado/{1}",
                                              idPedidoWeb.IdWeb, Convert.ToInt32(estado))), "", New HeadersDictionary(), Nothing)
      End Sub
#End Region

   End Class
End Namespace