#Region "Imports"
Imports System.Net
Imports System.IO
Imports System.Runtime.Serialization.Json
#End Region
Namespace ServiciosRest.Archivos
   Public Class BaseArchivosWeb(Of T)

#Region "GET COUNT"
      'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductoregistros/CuitEmpresa/23238857449/

      Public Function GetCount(url As String, fechaActualizacion As Date) As List(Of WebSigaCountServiceResponse)
         Dim uri As Uri = New Uri(String.Format(url, fechaActualizacion.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)))
         Dim wc As New WebClient()
         Try
            Using orResult As System.IO.Stream = wc.OpenRead(uri)
               Dim ser As New DataContractJsonSerializer(GetType(List(Of WebSigaCountServiceResponse)))
               Dim pedidos As List(Of WebSigaCountServiceResponse) = TryCast(ser.ReadObject(orResult), List(Of WebSigaCountServiceResponse))
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
#End Region

#Region "GET MAX FECHA"
      'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigaproductojsonmax/CuitEmpresa/33711345499/

      Public Function GetMaxFecha(url As String, headers As Dictionary(Of String, String)) As DateTime?
         Dim uri As Uri = New Uri(url)
         Dim wc As New WebClient()
         Try
            If headers IsNot Nothing Then
               For Each header As KeyValuePair(Of String, String) In headers
                  If Not String.IsNullOrWhiteSpace(header.Key) Then
                     wc.Headers.Add(header.Key, header.Value)
                  End If
               Next
            End If
            Using orResult As System.IO.Stream = wc.OpenRead(uri)
               Dim ser As New DataContractJsonSerializer(GetType(List(Of WebSigaMaxFechaServiceResponse)))
               Dim pedidos As List(Of WebSigaMaxFechaServiceResponse) = TryCast(ser.ReadObject(orResult), List(Of WebSigaMaxFechaServiceResponse))
               If pedidos.Count > 0 Then
                  Return pedidos(0).ultimaFechaActualizacionAsDate
               Else
                  Return Nothing
               End If
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
#End Region

#Region "GET"
      Public Function [Get](url As String, offset As Long, registrosPorPagina As Integer, fechaActualizacion As Date) As List(Of T)
         Return [Get](url, offset, registrosPorPagina, fechaActualizacion, Nothing)
      End Function
      Public Function [Get](url As String, offset As Long, registrosPorPagina As Integer, fechaActualizacion As Date, headers As Dictionary(Of String, String)) As List(Of T)
         Using wc = New WebClient()
            Try
               Dim uri = New Uri(String.Format(url, offset, registrosPorPagina, fechaActualizacion.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)))

               If headers IsNot Nothing Then
                  For Each header In headers
                     If Not String.IsNullOrWhiteSpace(header.Key) Then
                        wc.Headers.Add(header.Key, header.Value)
                     End If
                  Next
               End If

               Using orResult = wc.OpenRead(uri)
                  Using reader = New StreamReader(orResult, New UTF8Encoding())
                     Dim responseString = reader.ReadToEnd()
                     Dim serializer = New Web.Script.Serialization.JavaScriptSerializer()
                     serializer.MaxJsonLength = serializer.MaxJsonLength * 10
                     Dim datos = DirectCast(serializer.Deserialize(responseString, GetType(List(Of T))), List(Of T))
                     Return datos
                  End Using
               End Using
            Catch ex As WebException
               If ex.Response IsNot Nothing AndAlso TypeOf (ex.Response) Is HttpWebResponse Then
                  Dim response = DirectCast(ex.Response, HttpWebResponse)
                  If response.StatusCode = HttpStatusCode.NotFound Then
                     Throw New Exception("No se han encontrado pedidos en la Web.", ex)
                  End If
               End If
               Throw ex
            End Try
         End Using
      End Function
#End Region

      Private Function Comprimir(valores As String) As String ' Byte()
         Dim result As Byte()
         Using outStream As MemoryStream = New IO.MemoryStream()
            Using gzipStream As Stream = New IO.Compression.GZipStream(outStream, IO.Compression.CompressionMode.Compress)
               Using inStream As Stream = New IO.MemoryStream(Text.Encoding.Unicode.GetBytes(valores))
                  inStream.CopyTo(gzipStream)
               End Using
            End Using
            result = outStream.ToArray()
         End Using
         Return Convert.ToBase64String(result)
      End Function


#Region "POST"
      Private respuestaServicioRest As String
      Public Function Post(paginaJSon As T(), url As String) As WebSigaServiceResponse
         Return Post(Of WebSigaServiceResponse)(paginaJSon, url)
      End Function
      Public Function Post(Of TResult)(paginaJSon As T(), url As String) As TResult
         Return Post(Of TResult)(paginaJSon, url, headers:=Nothing, binario:=False)
      End Function
      Public Function Post(paginaJSon As T, url As String, headers As Dictionary(Of String, String), binario As Boolean) As WebSigaServiceResponse
         Return Post(Of WebSigaServiceResponse)(paginaJSon, url, headers, binario)
      End Function
      Public Function Post(Of TResult)(paginaJSon As T, url As String, headers As Dictionary(Of String, String), binario As Boolean) As TResult
         Dim clientesAsJson = serializer.Serialize(paginaJSon)
         Return Post(Of TResult)(clientesAsJson, url, headers, binario)
      End Function
      Public Function Post(paginaJSon As T(), url As String, headers As Dictionary(Of String, String), binario As Boolean) As WebSigaServiceResponse
         Return Post(Of WebSigaServiceResponse)(paginaJSon, url, headers, binario)
      End Function
      Public Function Post(Of TResult)(paginaJSon As T(), url As String, headers As Dictionary(Of String, String), binario As Boolean) As TResult
         Dim clientesAsJson = serializer.Serialize(paginaJSon)
         Return Post(Of TResult)(clientesAsJson, url, headers, binario)
      End Function

      Private serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
      Public Function Post(clientesAsJson As String, url As String, headers As Dictionary(Of String, String), binario As Boolean) As WebSigaServiceResponse
         Return Post(Of WebSigaServiceResponse)(clientesAsJson, url, headers, binario)
      End Function
      Public Function Post(Of TResult)(clientesAsJson As String, url As String, headers As Dictionary(Of String, String), binario As Boolean) As TResult
         'Dim clientesAsJson As String = serializer.Serialize(paginaJSon)
         If binario Then
            clientesAsJson = """" + Comprimir(clientesAsJson) + """"
         End If

         GetPOSTResponse(New Uri(url), "POST", clientesAsJson, headers,
                         Sub(x)
                            respuestaServicioRest = x
                         End Sub)

         Dim webSigaServiceResponse = DirectCast(serializer.Deserialize(respuestaServicioRest, GetType(TResult)), TResult)

         Return webSigaServiceResponse
      End Function

      Public Function Put(paginaJSon As T, url As String, headers As Dictionary(Of String, String)) As WebSigaServiceResponse
         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         Dim clientesAsJson As String = serializer.Serialize(paginaJSon)

         GetPOSTResponse(New Uri(url), "PUT", clientesAsJson, headers,
                         Sub(x)
                            respuestaServicioRest = x
                         End Sub)

         Dim webSigaServiceResponse As WebSigaServiceResponse
         webSigaServiceResponse = TryCast(serializer.Deserialize(respuestaServicioRest, GetType(WebSigaServiceResponse)), WebSigaServiceResponse)

         Return webSigaServiceResponse
      End Function

      Private Sub GetPOSTResponse(uri As Uri, metodo As String, data As String, headers As Dictionary(Of String, String), callback As Action(Of String))

         Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)

         request.Method = metodo
         request.ContentType = "application/json; charset=utf-8"

         Dim encoding As New System.Text.UTF8Encoding()
         Dim bytes As Byte() = encoding.GetBytes(data)

         request.ContentLength = bytes.Length
         If headers IsNot Nothing Then
            For Each header As KeyValuePair(Of String, String) In headers
               If Not String.IsNullOrWhiteSpace(header.Key) Then
                  request.Headers.Add(header.Key, header.Value)
               End If
            Next
         End If

         Try
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

                         'Dim ser As New DataContractJsonSerializer(GetType(PedidoWebEstadoResponse))
                         'callback(TryCast(ser.ReadObject(response.GetResponseStream()), PedidoWebEstadoResponse))
                      End If
                   End Using
                   Return 0
                End Function, Nothing)
         Catch ex As WebException
            NetExceptionHelper.NetExceptionHandler(ex)
         End Try
      End Sub
#End Region

#Region "DELETE"
      Public Function Delete(url As String) As WebSigaServiceResponse
         Return Delete(url, data:=String.Empty, headers:=Nothing)
      End Function
      Public Function Delete(url As String, headers As Dictionary(Of String, String)) As WebSigaServiceResponse
         Return Delete(url, data:=String.Empty, headers:=headers)
      End Function
      Public Function Delete(url As String, data As String, headers As Dictionary(Of String, String)) As WebSigaServiceResponse
         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

         GetPOSTResponse(New Uri(url), "DELETE", "", headers,
                         Sub(x)
                            respuestaServicioRest = x
                         End Sub)

         Dim webSigaServiceResponse As WebSigaServiceResponse
         webSigaServiceResponse = TryCast(serializer.Deserialize(respuestaServicioRest, GetType(WebSigaServiceResponse)), WebSigaServiceResponse)

         'If Not webSigaServiceResponse.status Then    'HUBO UN ERROR
         '   Throw New Exception(String.Format("Error borrando los registros de la URL={0} ERROR: {1}", url, webSigaServiceResponse.message))
         'Else                                         'SE ENVIARON EXITOSAMENTE

         'End If

         Return webSigaServiceResponse
      End Function

#End Region

      Public Class WebSigaServiceResponse
         Public Property status As Boolean
         Public Property message As String
      End Class

      Public Class WebSigaCountServiceResponse
         Public Property cantidadRegistros As Long
      End Class

      Public Class WebSigaMaxFechaServiceResponse
         Public Property ultimaFechaActualizacion As String
         Public ReadOnly Property ultimaFechaActualizacionAsDate As DateTime?
            Get
               If String.IsNullOrWhiteSpace(ultimaFechaActualizacion) Then Return Nothing
               Try
                  Return DateTime.ParseExact(ultimaFechaActualizacion, Entidades.JSonEntidades.AyudanteJson.FormatoFechas, Globalization.CultureInfo.InvariantCulture)
               Catch ex As Exception
                  Return Nothing
               End Try
            End Get
         End Property
      End Class

   End Class
End Namespace