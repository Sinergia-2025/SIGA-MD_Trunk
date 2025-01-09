Imports System.IO
Imports System.Net.Http
Namespace ServiciosRest.Gestion
   Partial Class SincronizarGestion

      Public Function SubirAdjuntoTicket(ticket As SolicitudTicket, files As IEnumerable(Of String)) As List(Of FileResponseMessage)
         Dim token = LoginGestion()
         Dim headers = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarCuitEmpresa().AgregarVersion().Agregar("Token", token.Token)

         Dim uri = New Uri(BaseUri, String.Format("filestreaming/upload?overWrite=true&letra={0}&idNovedad={1}", ticket.Letra, ticket.IdNovedad))

         Return UploadAsync(uri.ToString(), files, headers)
         'Dim result = UploadAsync(uri.ToString(), files, headers).Result

      End Function

      Public Function UploadAsync(url As String, files As IEnumerable(Of String), headers As HeadersDictionary) As List(Of FileResponseMessage)
         Return UploadAsync(url, files.ToList().ConvertAll(Function(f) New FileInfo(f)), headers)
      End Function
      'Public Shared Async Function UploadAsync(url As String, files As IEnumerable(Of String), headers As HeadersDictionary) As Task(Of String)
      '   Return Await UploadAsync(url, files.ToList().ConvertAll(Function(f) New FileInfo(f)), headers)
      'End Function
      'Public Shared Async Function UploadAsync(url As String, files As IEnumerable(Of FileInfo), headers As HeadersDictionary) As Task(Of String)
      Public Shared Function UploadAsync(url As String, files As IEnumerable(Of FileInfo), headers As HeadersDictionary) As List(Of FileResponseMessage)
         Using formData = New MultipartFormDataContent()
            For Each fi In files
               '' Submit the form using HttpClient And 
               '' create form data as Multipart (enctype="multipart/form-data")
               Dim fileStreamContent = New StreamContent(fi.OpenRead())
               ''Add the HttpContent objects to the form data
               ''<input type="file" name="file1" />
               Dim name = fi.Name
               Dim fileName = fi.Name
               formData.Add(fileStreamContent, name, name)
            Next

            Using client = New HttpClient()

               For Each h In headers
                  client.DefaultRequestHeaders.Add(h.Key, h.Value)
               Next

               '' equivalent to pressing the submit button on a form with attributes (action="{url}" method="post")
               Dim response = client.PostAsync(url, formData).Result

               Dim serializer = New Web.Script.Serialization.JavaScriptSerializer()
               '' ensure the request was a success
               If Not response.IsSuccessStatusCode Then
                  Dim mensaje = response.Content.ReadAsStringAsync().Result
                  Dim msg = serializer.Deserialize(Of List(Of FileResponseMessage))(mensaje)
                  If msg.AnySecure() Then
                     Throw New Exception(msg(0).Content)
                  Else
                     Throw New Exception(mensaje)
                  End If
               End If
               Dim mensajeRespuesta = response.Content.ReadAsStringAsync().Result
               Return serializer.Deserialize(Of List(Of FileResponseMessage))(mensajeRespuesta)
            End Using
         End Using
      End Function
      Public Class FileResponseMessage
         Public Property IsExists As Boolean
         Public Property Content As String

      End Class
   End Class
End Namespace