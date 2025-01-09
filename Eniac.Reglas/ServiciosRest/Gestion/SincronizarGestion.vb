Namespace ServiciosRest.Gestion
   Public Class SincronizarGestion
      Inherits SincronizacionBase

      Public Sub New()
         MyBase.New(Publicos.SimovilGestionURLBase)
         'MyBase.New("http://sinergiamovil.com.ar/simovilgestion_test/api/")
         'MyBase.New("http://sinergia-pc-04/Soporte/api/")
      End Sub


      Public Function LoginGestion() As LoginToken
         Dim serializer = New Web.Script.Serialization.JavaScriptSerializer()
         Dim login = New With {
                  .CodigoEmpresa = "204",
                  .Username = Publicos.CuitEmpresa,
                  .Password = Publicos.ClaveClienteSinergia
            }
         Dim headers = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarCuitEmpresa().AgregarVersion()
         Dim archWeb = New Archivos.BaseArchivosWeb(Of String)()

         Dim uri = New Uri(BaseUri, "login/authenticate")

         Dim token = archWeb.Post(Of LoginToken)(serializer.Serialize(login), uri.ToString(), headers, binario:=False)

         Return token
      End Function
      Public Class LoginToken
         Public Property Token As String
      End Class

      Public Function GetCategorias() As List(Of Entidades.CRMCategoriaNovedad)
         Dim token = LoginGestion()
         Dim headers = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarCuitEmpresa().AgregarVersion().Agregar("Token", token.Token)

         Dim archWeb = New Archivos.BaseArchivosWeb(Of Entidades.CRMCategoriaNovedad)()

         Dim uri = New Uri(BaseUri, "CategoriasNovedades")

         Dim result = archWeb.Get(uri.ToString(), 0, Integer.MaxValue, Today, headers)

         Return result
      End Function

      Public Function EnviarNuevoTicket(Interlocutor As String, Descripcion As String, IdCategoriaNovedad As Integer, Comentario As String) As SolicitudTicket
         Dim token = LoginGestion()

         Dim serializer = New Web.Script.Serialization.JavaScriptSerializer()
         Dim ticket = New SolicitudTicket With {
                  .Letra = "S",
                  .Interlocutor = Interlocutor,
                  .Descripcion = Descripcion,
                  .IdCategoriaNovedad = IdCategoriaNovedad,
                  .Comentario = Comentario
               }

         Dim headers = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarCuitEmpresa().AgregarVersion().Agregar("Token", token.Token)

         Dim archWeb = New Archivos.BaseArchivosWeb(Of String)()

         Dim uri = New Uri(BaseUri, "Ticket")

         Dim result = archWeb.Post(Of SolicitudTicket)(serializer.Serialize(ticket), uri.ToString(), headers, binario:=False)

         Return result
      End Function

      Private Sub EnviarArchivosAdjuntos(ticket As SolicitudTicket)

         'Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(Uri), HttpWebRequest)



         'Dim httpClient = New HttpClient()
         '{
         '    BaseAddress = New Uri("https://localhost:7075")
         '};
      End Sub

      Public Function GetNovedads(idTipoNovedad As String) As List(Of Entidades.JSonEntidades.Gestion.Soporte.Ticket)
         Dim token = LoginGestion()
         Dim headers = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarCuitEmpresa().AgregarVersion().Agregar("Token", token.Token)
         Dim archWeb = New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Gestion.Soporte.Ticket)()

         Dim uri = New Uri(BaseUri, "Novedades")
         Dim params = New Dictionary(Of String, String)()
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            params.Add("idTipoNovedad", idTipoNovedad)
         End If

         Dim result = archWeb.Get(uri.ToString(params), 0, Integer.MaxValue, Today, headers)

         Return result
      End Function

      Public Class SolicitudTicket
         Public Property Letra As String
         Public Property IdNovedad As Long
         Public Property Descripcion As String
         Public Property IdCategoriaNovedad As Integer
         Public Property Comentario As String
         Public Property IdCliente As Long
         Public Property Interlocutor As String

      End Class

   End Class
End Namespace