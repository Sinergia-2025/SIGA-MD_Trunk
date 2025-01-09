#Region "Options/Imports"
Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports Eniac.Entidades.JSonEntidades.Pedidos
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports System.Runtime.Serialization
#End Region
Namespace ServiciosRest.Pedidos
   Public Class PedidosSiGA
      Inherits BasePedidosWeb
#Region "GET"
      Public Overrides Function AgregarPedidoWeb(ds As Entidades.DsPreventa, da As Datos.DataAccess, rutasSeleccionadas As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)) As Entidades.DsPreventa
         Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
         Try
            If blnAbreConexion Then da.OpenConection()

            'Dim rVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)
            'Dim rPedidosWeb As PedidosWeb = New PedidosWeb()
            Dim pedidos As List(Of PedidoJSon)
            pedidos = GetPedidos(New Uri(Reglas.Publicos.PedidosURLWebGET))
            '  "http://www.siweb.com.ar/sistema/rest/index.php/api/pedido/cuitempresa/30713688300"))

            Dim vendedor As Eniac.Entidades.Empleado
            Dim cliente As Entidades.Cliente
            Dim estadoVisita As Eniac.Entidades.EstadoVisita
            Try
               estadoVisita = New Reglas.EstadosVisitas(da).GetUno(1)
            Catch ex As Exception
               estadoVisita = Nothing
            End Try

            For Each pedido As PedidoJSon In pedidos
               vendedor = Nothing
               If pedido.IdVendedor > 0 Then
                  vendedor = New Eniac.Reglas.Empleados(da).GetUno(pedido.IdVendedor, Base.AccionesSiNoExisteRegistro.Nulo)
               End If

               If vendedor Is Nothing Then
                  vendedor = New Eniac.Reglas.Empleados(da).GetPorTipoNro(pedido.TipoDocVendedor, pedido.NroDocVendedor).FirstOrDefault()
               End If

               Try
                  cliente = New Reglas.Clientes(da).GetUnoPorCodigo(pedido.IdCliente)
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

                  drArchivo.NombreArchivo = "Pedidos Web de " + vendedor.NombreEmpleado
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
               drPedido.IdSucursal = pedido.IdSucursal
               drPedido.IdTipoComprobante = pedido.IdTipoComprobante
               drPedido.Letra = pedido.Letra
               drPedido.CentroEmisor = Convert.ToInt16(pedido.CentroEmisor)
               drPedido.NumeroPedido = pedido.NumeroPedido
               drPedido.IdWeb = pedido.id

               drPedido.NroVersionRemoto = pedido.NroVersionRemoto

               drPedido.IdTipoComprobanteFact = pedido.IdTipoComprobanteFact
               If pedido.IdTransportista.HasValue Then
                  drPedido.IdTransportista = pedido.IdTransportista.Value
               Else
                  drPedido.ConError_FaltaTransportista = True
               End If

               If pedido.IdFormasPago.HasValue Then
                  drPedido.IdFormasPago = pedido.IdFormasPago.Value
               End If

               drPedido.FechaPedido = DateTime.Parse(pedido.FechaPedido)

               drPedido.Pasa = True
               drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal

               If estadoVisita Is Nothing Then
                  drPedido.ConError_EstadoVisitaInexistente = True
               Else
                  drPedido.IdEstadoVenta = estadoVisita.IdEstadoVisita
                  drPedido.NombreEstadoVenta = estadoVisita.NombreEstadoVisita
               End If

               If cliente Is Nothing Then
                  drPedido.ConError_ClienteInexistente = True
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

                  drPedido.PorcDesc = pedido.DescuentoRecargoPorc

                  If ds.Pedido.Select(String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}",
                                                    ds.Pedido.IdTipoComprobanteColumn.ColumnName, pedido.IdTipoComprobante,
                                                    ds.Pedido.LetraColumn.ColumnName, pedido.Letra,
                                                    ds.Pedido.CentroEmisorColumn.ColumnName, pedido.CentroEmisor,
                                                    ds.Pedido.NumeroPedidoColumn.ColumnName, pedido.NumeroPedido)).Length > 0 Then
                     Exit For
                  End If

                  If ExistePedidoWeb(drPedido.IdSucursal, drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroPedido) Then
                     drPedido.ConError_PedidoYaExiste = True
                  End If
               End If

               If Not ds.Archivo.Contains(drArchivo) Then
                  ds.Archivo.AddArchivoRow(drArchivo)
               End If
               ds.Pedido.AddPedidoRow(drPedido)

               For Each pedidoDetalle As PedidoProductoJSon In pedido.PedidosProductos
                  'For Each pedidoDetalle As PedidoProductoJSon In pedido.detalle


                  Dim drPedidoProducto As Entidades.DsPreventa.PedidoProductoRow = ds.PedidoProducto.NewPedidoProductoRow()
                  drPedidoProducto.PedidoRowParent = drPedido
                  drPedidoProducto.IdProducto = pedidoDetalle.IdProducto
                  drPedidoProducto.Orden = 0
                  ds.PedidoProducto.AddPedidoProductoRow(drPedidoProducto)

                  drPedidoProducto.IdListaPrecios = pedidoDetalle.IdListaPrecios
                  drPedidoProducto.NombreListaPrecios = pedidoDetalle.NombreListaPrecios

                  Dim producto As Eniac.Entidades.ProductoSucursal

                  Try
                     producto = New Eniac.Reglas.ProductosSucursales(da).GetUno(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
                                                                                   drPedidoProducto.IdProducto,
                                                                                   drPedidoProducto.IdListaPrecios)
                  Catch ex As Exception
                     producto = Nothing
                  End Try

                  Dim fechaEntrega As DateTime
                  If DateTime.TryParse(pedidoDetalle.FechaEntrega, fechaEntrega) Then
                     drPedidoProducto.FechaEntrega = fechaEntrega
                  End If
                  drPedidoProducto.Cantidad = pedidoDetalle.Cantidad
                  drPedidoProducto.Precio = pedidoDetalle.Precio
                  drPedidoProducto.Orden = ds.PedidoProducto.Count

                  If producto Is Nothing OrElse String.IsNullOrWhiteSpace(producto.Producto.IdProducto) Then
                     '' ''drPedido.Pasa = False
                     '' ''drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     '' ''drPedido.MensajeError = "ARTICULO INACTIVO o INEXISTENTE"

                     '' ''drPedidoProducto.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                     drPedidoProducto.ConError_ProductoInexistente = True
                  Else
                     drPedidoProducto.NombreProducto = producto.Producto.NombreProducto
                     drPedidoProducto.PrecioLista = producto.PrecioVentaLista
                     drPedidoProducto.Stock = producto.Stock
                     If pedidoDetalle.DescuentoRecargoPorc.HasValue Then
                        drPedidoProducto.PorcDesc1 = pedidoDetalle.DescuentoRecargoPorc.Value
                     End If
                     If pedidoDetalle.DescuentoRecargoPorc2.HasValue Then
                        drPedidoProducto.PorcDesc2 = pedidoDetalle.DescuentoRecargoPorc2.Value
                     End If
                  End If

                  drPedidoProducto.IVA = pedidoDetalle.AlicuotaImpuesto
                  drPedidoProducto.PrecioMovil = pedidoDetalle.Precio

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

                  'If drPedidoProducto.PorcDesc1 <> 0 Or
                  '   drPedidoProducto.PorcDesc2 <> 0 Or
                  If drPedidoProducto.CantidadSinCargo <> 0 Or
                     drPedidoProducto.CantidadFaltante <> 0 Or
                     drPedidoProducto.CantidadDevolucion <> 0 Then
                     '' ''drPedido.Pasa = False
                     '' ''drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                     '' ''drPedido.MensajeError = "PEDIDO CON ARTICULOS CON NOVEDADES"
                     drPedidoProducto.Advertencia_ProductoConNovedades = True
                  End If
               Next
            Next     ' For Each pedido As PedidoJSon In pedidos

            AgregarMensajeErrorSegunBanderas(ds)

            ds.AcceptChanges()
         Catch
            ds.RejectChanges()
            Throw
         Finally
            If blnAbreConexion Then da.CloseConection()
         End Try
         Return ds

      End Function

      Private Function GetPedidos(uri As Uri) As List(Of PedidoJSon)
         Dim wc As New WebClient()
         Try
            Using orResult As System.IO.Stream = wc.OpenRead(uri)
               Dim ser As New DataContractJsonSerializer(GetType(List(Of PedidoJSon)))
               Dim pedidos As List(Of PedidoJSon) = TryCast(ser.ReadObject(orResult), List(Of PedidoJSon))
               Return pedidos
            End Using
         Catch ex As WebException
            If ex.Response IsNot Nothing AndAlso TypeOf (ex.Response) Is HttpWebResponse Then
               Dim response As HttpWebResponse = DirectCast(ex.Response, HttpWebResponse)
               If response.StatusCode = HttpStatusCode.NotFound Then
                  Throw New Exception("No se han encontrado pedidos en la Web.", ex)
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
         Dim url As String = Publicos.PedidosURLWebPUT
         If Not String.IsNullOrWhiteSpace(url) Then
            GetPUTResponse(New Uri(String.Format(url,
                                                 idPedidoWeb.IdWeb,
                                                 Convert.ToInt32(estado))), "", New HeadersDictionary(), Nothing)
         End If
      End Sub

#End Region

#Region "POST"
      Private respuestaServicioRest As String
      Public Function PostPedidos(pedidosJ As List(Of JSonEntidades.Pedidos.PedidoJSon)) As WebSigaServiceResponse
         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         Dim pedidosAsRest As String = serializer.Serialize(pedidosJ)

         Dim url As String = Publicos.PedidosURLWebPOST
         ' "http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigapedido"


         GetPOSTResponse(New Uri(url), pedidosAsRest,
                         Sub(x)
                            respuestaServicioRest = x
                         End Sub)

         Dim webSigaServiceResponse As WebSigaServiceResponse
         webSigaServiceResponse = TryCast(serializer.Deserialize(respuestaServicioRest, GetType(WebSigaServiceResponse)), WebSigaServiceResponse)

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

      Public Class WebSigaServiceResponse
         Public Property status As Boolean
         Public Property message As String
      End Class

   End Class
End Namespace