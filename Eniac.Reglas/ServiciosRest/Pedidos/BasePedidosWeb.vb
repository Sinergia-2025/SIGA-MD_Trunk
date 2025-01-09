Imports System.IO
Imports Eniac.Entidades
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text

Namespace ServiciosRest.Pedidos
   Public MustInherit Class BasePedidosWeb
      Public Enum EstadoSiWeb As Integer
         Borrador = 0
         Enviado = 1
         Procesado = 2
      End Enum

      Public Overridable Function PermiteSeleccionarRutasPedidosPendientes() As Boolean
         Return False
      End Function

#Region "GET"
      Public MustOverride Function AgregarPedidoWeb(ds As Entidades.DsPreventa, da As Datos.DataAccess, rutasSeleccionadas As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)) As Entidades.DsPreventa
#End Region

#Region "PUT"
      Public MustOverride Sub SetEstadoPedidoProcesado(idPedidoWeb As Entidades.DsPreventa.PedidoRow, estado As EstadoSiWeb)
#End Region

      Protected Sub GetPUTResponse(uri As Uri, data As String, headersDictionary As HeadersDictionary, callback As Action(Of PedidoWebEstadoResponse))
         Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)

         request.Method = "PUT"
         request.ContentType = "application/json; charset=utf-8"

         Dim encoding As New System.Text.UTF8Encoding()
         Dim bytes As Byte() = encoding.GetBytes(data)

         request.ContentLength = bytes.Length

         For Each hdr As KeyValuePair(Of String, String) In headersDictionary
            request.Headers.Add(hdr.Key, hdr.Value)
         Next

         Using requestStream As Stream = request.GetRequestStream()
            ' Send the data.
            requestStream.Write(bytes, 0, bytes.Length)
         End Using

         request.BeginGetResponse(
             Function(x)
                Try
                   Using response As HttpWebResponse = DirectCast(request.EndGetResponse(x), HttpWebResponse)
                      If callback IsNot Nothing Then
                         Dim ser As New DataContractJsonSerializer(GetType(PedidoWebEstadoResponse))
                         callback(TryCast(ser.ReadObject(response.GetResponseStream()), PedidoWebEstadoResponse))
                      End If
                   End Using
                   Return 0
                Catch ex As WebException
                   If ex.Response IsNot Nothing AndAlso TypeOf (ex.Response) Is HttpWebResponse Then
                      Dim response As HttpWebResponse = DirectCast(ex.Response, HttpWebResponse)
                      If response.StatusCode = HttpStatusCode.NotFound Then
                         Throw New Exception("No se han encontrado pedidos en la Web.", ex)
                      ElseIf response.StatusCode = HttpStatusCode.BadRequest Then
                         ThrowStatusCode400Exception(ex, response)
                      End If
                   End If

                   Throw
                End Try
             End Function, Nothing)
      End Sub

      Protected Overridable Sub ThrowStatusCode400Exception(ex As WebException, response As HttpWebResponse)
         Throw New WebException(String.Format("{0}. Verifique la InnerException para mayor detalle.", ex.Message), ex)
      End Sub

      Public Overridable Sub AgregarMensajeErrorSegunBanderas(ds As Entidades.DsPreventa)
         For Each drPedido As DsPreventa.PedidoRow In ds.Pedido
            drPedido.MensajeError = String.Empty
            drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal
            drPedido.Pasa = True

            Dim stbMensajeError As StringBuilder = New StringBuilder()
            drPedido.MensajeError = String.Empty
            If drPedido.ConError_FaltaTransportista Then
               stbMensajeError.AppendFormat("PEDIDO SIN TRANSPORTISTA - ")
            End If
            If drPedido.ConError_EstadoVisitaInexistente Then
               stbMensajeError.AppendFormat("ESTADO DE VISITA INEXISTENTE - ")
            End If
            If drPedido.ConError_ClienteInexistente Then
               stbMensajeError.AppendFormat("CLIENTE INACTIVO o INEXISTENTE - ")
            End If
            If drPedido.ConError_PedidoYaExiste Then
               stbMensajeError.AppendFormat("PEDIDO YA INGRESADO - ")
            End If

            Dim countErrorProductoInexistente As Integer = 0
            Dim countAdverProductoNovedades As Integer = 0

            For Each drPedidoProducto As DsPreventa.PedidoProductoRow In drPedido.GetPedidoProductoRows()
               drPedidoProducto.MensajeError = String.Empty
               drPedidoProducto.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal

               Dim stbMensajeErrorProducto As StringBuilder = New StringBuilder()
               If drPedidoProducto.ConError_ProductoInexistente Then
                  countErrorProductoInexistente += 1
                  stbMensajeErrorProducto.AppendFormat("ARTICULO INACTIVO o INEXISTENTE - ")
               End If

               If drPedidoProducto.Advertencia_ProductoConNovedades Then
                  countAdverProductoNovedades += 1
                  stbMensajeErrorProducto.AppendFormat("ARTICULOS CON NOVEDADES - ")
               End If

               If drPedidoProducto.ConError_ProductoInexistente Then
                  drPedidoProducto.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
                  drPedidoProducto.MensajeError = stbMensajeErrorProducto.ToString()
               ElseIf drPedidoProducto.Advertencia_ProductoConNovedades Then
                  drPedidoProducto.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
                  drPedidoProducto.MensajeError = stbMensajeErrorProducto.ToString()
               End If
            Next

            If countErrorProductoInexistente > 0 Then
               stbMensajeError.AppendFormat("{0} ARTICULO INACTIVO o INEXISTENTE - ", countErrorProductoInexistente)
            End If

            If countAdverProductoNovedades > 0 Then
               stbMensajeError.AppendFormat("{0} ARTICULO CON NOVEDADES - ", countAdverProductoNovedades)
            End If

            If drPedido.ConError_FaltaTransportista Or
               drPedido.ConError_EstadoVisitaInexistente Or
               drPedido.ConError_ClienteInexistente Or
               drPedido.ConError_PedidoYaExiste Or
               countErrorProductoInexistente > 0 Then
               drPedido.Pasa = False
               drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.ConError
               drPedido.MensajeError = stbMensajeError.ToString()
            ElseIf countAdverProductoNovedades > 0 Then
               drPedido.Pasa = False
               drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Advertencia
               drPedido.MensajeError = stbMensajeError.ToString()
            Else
               drPedido.Pasa = True
               drPedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal
            End If

         Next
      End Sub

   End Class

End Namespace