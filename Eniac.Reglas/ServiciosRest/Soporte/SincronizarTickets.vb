#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Namespace ServiciosRest.Soporte
   Public Class SincronizarTickets
      Inherits SincronizacionBase

      Public Sub New()
         MyBase.New(Publicos.SimovilSoporteURLBase)
         'MyBase.New("http://w1021701.ferozo.com/SSSServicioWeb/api/")
         'MyBase.New("http://sinergia-pc-04/Soporte/api/")
      End Sub

      Public Sub ImportarAutomaticamente()
         DescargarTicketsNuevos()
         SubirNovedades()
         SubirEstadosNovedades()
         SubirCategoriasNovedades()
         SubirTiposComentariosNovedades()
         SubirEmpresas()
      End Sub

#Region "Descargar Tickets Nuevos"
      Private Sub DescargarTicketsNuevos()
         Dim solicitudesTicket As List(Of SSSSoporte.Entidades.Movil.Ticket)
         OnAvance("Obteniendo Solicitudes de Tickets")
         solicitudesTicket = ObtenerSolicitudesTicket()

         Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
         Dim usuarioMovil As Entidades.Usuario = New Entidades.Usuario() With {.Usuario = Reglas.Publicos.SimovilSoporteUsuarioDefault}

         Dim tiposComentarios As IEnumerable(Of Entidades.CRMTipoComentarioNovedad)
         tiposComentarios = New Reglas.CRMTiposComentariosNovedades().GetTodos(idTipoNovedad:=String.Empty)
         Dim tipoComentarioPorTipoNovedad As Dictionary(Of String, Entidades.CRMTipoComentarioNovedad) = New Dictionary(Of String, Entidades.CRMTipoComentarioNovedad)()

         For Each solicitud As SSSSoporte.Entidades.Movil.Ticket In solicitudesTicket
            OnAvance(String.Format("Cargando {0} {1} {2:0000}-{3:00000000}", solicitud.IdTipoNovedad, solicitud.Letra, solicitud.CentroEmisor, solicitud.IdNovedad))


            Dim novedad As Entidades.CRMNovedad = New Entidades.CRMNovedad()
            novedad.TipoNovedad = cache.CRMTipoNovedad.Buscar(solicitud.IdTipoNovedad)
            novedad.Letra = solicitud.Letra
            novedad.CentroEmisor = solicitud.CentroEmisor
            novedad.IdNovedad = solicitud.IdNovedad

            novedad.FechaNovedad = solicitud.FechaNovedad
            novedad.Descripcion = solicitud.Descripcion
            novedad.CategoriaNovedad = cache.CRMCategoriaNovedad.Buscar(solicitud.IdCategoriaNovedad)
            novedad.FechaEstadoNovedad = Nothing

            Dim cliente As Entidades.Cliente = cache.BuscaClienteEntidadPorCodigo(solicitud.CodigoEmpresa)
            novedad.IdCliente = cliente.IdCliente
            novedad.IdSistema = cliente.ZonaGeografica.IdZonaGeografica
            novedad.RevisionAdministrativa = cache.BuscaCategoria(cliente.IdCategoria).RequiereRevisionAdministrativa
            novedad.Interlocutor = solicitud.Interlocutor

            novedad.ComentarioPrincipal = Entidades.CRMNovedad.ComentarioPrincipalOptiones.Primero

            novedad.NuevoComentario = solicitud.Comentarios

            Dim nuevoTipoComentario As Entidades.CRMTipoComentarioNovedad
            If Not tipoComentarioPorTipoNovedad.ContainsKey(solicitud.IdTipoNovedad) Then
               nuevoTipoComentario = tiposComentarios.FirstOrDefault(Function(x) x.IdTipoNovedad = solicitud.IdTipoNovedad And x.VisibleParaCliente And x.VisibleParaRepresentante)
               If nuevoTipoComentario Is Nothing Then
                  nuevoTipoComentario = tiposComentarios.FirstOrDefault(Function(x) x.IdTipoNovedad = solicitud.IdTipoNovedad And x.VisibleParaCliente)
               End If
               If nuevoTipoComentario Is Nothing Then
                  nuevoTipoComentario = New Entidades.CRMTipoComentarioNovedad()
               End If
               tipoComentarioPorTipoNovedad.Add(solicitud.IdTipoNovedad, nuevoTipoComentario)
            End If

            novedad.NuevoIdTipoComentarioNovedad = tipoComentarioPorTipoNovedad(solicitud.IdTipoNovedad).IdTipoComentarioNovedad

            novedad.Avance = 0
            novedad.FechaAlta = Now
            novedad.UsuarioAsignado = usuarioMovil
            'novedad.UsuarioEstadoNovedad = usuarioMovil
            'novedad.UsuarioAlta = usuarioMovil
            novedad.FechaProximoContacto = Nothing
            novedad.BanderaColor = Nothing
            novedad.IdProyecto = 0
            novedad.Priorizado = False
            novedad.IdTipoNovedadPadre = String.Empty
            novedad.LetraPadre = String.Empty
            novedad.CentroEmisorPadre = 0
            novedad.IdNovedadPadre = 0
            novedad.Version = String.Empty
            novedad.VersionFecha = Nothing
            novedad.FechaInicioPlan = Nothing
            novedad.FechaFinPlan = Nothing
            novedad.TiempoEstimado = 0
            novedad.UsuarioResponsable = Nothing
            novedad.Cantidad = 0

            novedad.IdFuncion = "SIGA"                                  'TODO: parametrizar

            'Valores por defecto
            novedad.EstadoNovedad = cache.CRMEstadoNovedad.BuscarDefault(novedad.IdTipoNovedad)
            novedad.PrioridadNovedad = cache.CRMPrioridadNovedad.BuscarDefault(novedad.IdTipoNovedad)
            novedad.MetodoResolucionNovedad = cache.CRMMetodoResolucionNovedad.BuscarDefault(novedad.IdTipoNovedad)

            Dim idMedioComunicacion As Integer = If(novedad.Letra = "M", 140, If(novedad.Letra = "W", 145, If(novedad.Letra = "T", 149, 0)))
            If idMedioComunicacion > 0 Then
               novedad.MedioComunicacionNovedad = cache.CRMMedioComunicacionNovedad.Buscar(idMedioComunicacion)
            Else
               novedad.MedioComunicacionNovedad = cache.CRMMedioComunicacionNovedad.BuscarDefault(novedad.IdTipoNovedad)
            End If

            If novedad.MedioComunicacionNovedad Is Nothing Then
               novedad.MedioComunicacionNovedad = cache.CRMMedioComunicacionNovedad.BuscarDefault(novedad.IdTipoNovedad)
            End If

            Dim adjuntos As List(Of SSSSoporte.Entidades.FileMetaData)
            adjuntos = ObtenerListaAdjuntosDeSolicitudesTicket(novedad.IdTipoNovedad, novedad.Letra, novedad.CentroEmisor, novedad.IdNovedad)

            Dim cont As Integer = 0
            Dim total As Integer = adjuntos.Count
            For Each adjunto As SSSSoporte.Entidades.FileMetaData In adjuntos
               Dim datos As Byte()
               cont += 1
               OnAvance(String.Format("Obteniendo adjunto {4}/{5} del {0} {1} {2:0000}-{3:00000000}.",
                                      novedad.IdTipoNovedad, novedad.Letra, novedad.CentroEmisor, novedad.IdNovedad,
                                      cont, total))

               datos = ObtenerAdjuntosDeSolicitudesTicket(novedad.IdTipoNovedad, novedad.Letra, novedad.CentroEmisor, novedad.IdNovedad, adjunto.FileName)
               novedad.Seguimientos.Add(New Entidades.CRMNovedadSeguimiento() _
                                          With {.TipoNovedad = Nothing,
                                                .Comentario = adjunto.FileName,
                                                .IdTipoComentarioNovedad = tipoComentarioPorTipoNovedad(solicitud.IdTipoNovedad).IdTipoComentarioNovedad,
                                                .FechaSeguimiento = novedad.FechaNovedad,
                                                .EsComentario = True,
                                                .ArchivoAdjunto = New Entidades.CRMNovedadSeguimientoAdjunto() _
                                                                     With {.TipoNovedad = Nothing,
                                                                           .Adjunto = datos,
                                                                           .NombreAdjunto = adjunto.FileName}})
            Next

            Dim da As Datos.DataAccess = New Datos.DataAccess()
            da.OpenConection()
            Try
               da.BeginTransaction()

               Dim rNovedad As Reglas.CRMNovedades = New CRMNovedades(da)

               OnAvance(String.Format("Grabando {0} {1} {2:0000}-{3:00000000}", solicitud.IdTipoNovedad, solicitud.Letra, solicitud.CentroEmisor, solicitud.IdNovedad))
               rNovedad.Inserta(novedad)

               OnAvance(String.Format("Marcando {0} {1} {2:0000}-{3:00000000} como procesada", solicitud.IdTipoNovedad, solicitud.Letra, solicitud.CentroEmisor, solicitud.IdNovedad))
               MarcarSolicitud(solicitud)
               da.CommitTransaction()
            Catch
               da.RollbakTransaction()
               Throw
            Finally
               da.CloseConection()
            End Try

         Next
      End Sub

      Public Sub MarcarSolicitud(solicitud As SSSSoporte.Entidades.Movil.Ticket)

         Try
            Dim archWeb As New Archivos.BaseArchivosWeb(Of SSSSoporte.Entidades.Movil.Ticket)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim urlDelete As String = String.Format("{0}/{1}/{2}/{3}/{4}/{5}", BaseUri.AbsoluteUri, "Solicitudes",
                                                    solicitud.IdTipoNovedad, solicitud.Letra, solicitud.CentroEmisor, solicitud.IdNovedad)

            Dim uri As Uri = New Uri(BaseUri, "Solicitudes")
            uri = New Uri(urlDelete)

            archWeb.Delete(uri.ToString(), headers)
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
         End Try
      End Sub
      Public Function ObtenerSolicitudesTicket() As List(Of SSSSoporte.Entidades.Movil.Ticket)
         Try

            Dim archWeb As New Archivos.BaseArchivosWeb(Of SSSSoporte.Entidades.Movil.Ticket)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri As Uri = New Uri(BaseUri, "Solicitudes")

            OnAvance(String.Format("Descargando información de {0}.", "Solicitudes"))

            Dim result As List(Of SSSSoporte.Entidades.Movil.Ticket)
            result = archWeb.Get(uri.ToString(), 0, Integer.MaxValue, Today, headers)

            Return result
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            Return Nothing
         End Try
      End Function

      Public Function ObtenerListaAdjuntosDeSolicitudesTicket(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As List(Of SSSSoporte.Entidades.FileMetaData)
         Try

            Dim archWeb As New Archivos.BaseArchivosWeb(Of SSSSoporte.Entidades.FileMetaData)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim url As String = String.Format("{0}/filestreaming/searchfileindownloaddirectory?letra={2}&idNovedad={4}",
                                              BaseUri, idTipoNovedad, letra, centroEmisor, idNovedad)

            Dim uri As Uri = New Uri(url)

            OnAvance(String.Format("Obteniendo cantidad de adjuntos del {0} {1} {2:0000}-{3:00000000}.", idTipoNovedad, letra, centroEmisor, idNovedad))

            Dim result As List(Of SSSSoporte.Entidades.FileMetaData)
            result = archWeb.Get(uri.ToString(), 0, Integer.MaxValue, Today, headers)

            Return result
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            Return Nothing
         Catch ex As Exception
            'NetExceptionHelper.NetExceptionHandler(ex)
            If TypeOf (ex.InnerException) Is System.Net.WebException Then
               Dim ex1 As System.Net.WebException = DirectCast(ex.InnerException, System.Net.WebException)
               If ex1.Response IsNot Nothing AndAlso TypeOf (ex1.Response) Is System.Net.HttpWebResponse Then
                  Dim response As System.Net.HttpWebResponse = DirectCast(ex1.Response, System.Net.HttpWebResponse)
                  If response.StatusCode = System.Net.HttpStatusCode.NotFound Then
                     Return New List(Of SSSSoporte.Entidades.FileMetaData)()
                  End If
               End If
            End If
            Throw
         End Try
      End Function
      Public Function ObtenerAdjuntosDeSolicitudesTicket(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long,
                                                         nombreArchivo As String) As Byte()
         Try

            Dim archWeb As New Archivos.BaseArchivosWeb(Of Byte())()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            'Dim baseStreamingURL As String = String.Format("{0}/filestreaming/download?letra={2}&idNovedad={4}&fileName{5}",
            '                                               BaseUri, idTipoNovedad, letra, centroEmisor, idNovedad, nombreArchivo)
            'Dim baseStreamingURL As String = String.Format("{0}/filestreaming/",
            '                                               BaseUri, idTipoNovedad, letra, centroEmisor, idNovedad)
            Dim url As String = String.Format("{0}filestreaming/download?letra={2}&idNovedad={4}&fileName={5}",
                                              BaseUri, idTipoNovedad, letra, centroEmisor, idNovedad, nombreArchivo)

            Dim uri As Uri = New Uri(url)

            'OnAvanceImportarAutomaticamente(String.Format("Descargando información de {0}.", Metodo.Solicitudes.ToString()))

            Dim result As Byte() = Nothing
            Using httpClient As System.Net.WebClient = New System.Net.WebClient()

               'httpClient.BaseAddress = baseStreamingURL

               Using inputStream As System.IO.Stream = httpClient.OpenRead(uri)
                  Using outPutStream As IO.MemoryStream = New IO.MemoryStream()

                     Dim buffer(1048575) As Byte   '' 1MB buffer
                     While True
                        Dim read As Integer = inputStream.Read(buffer, 0, buffer.Length)
                        If read > 0 Then
                           outPutStream.Write(buffer, 0, read)
                        Else
                           result = outPutStream.ToArray()
                           Exit While
                        End If
                     End While
                  End Using
               End Using
            End Using

            Return result
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            Return Nothing
         End Try
      End Function

#End Region

      Private Sub SubirNovedades()
         Dim novedades As List(Of Entidades.JSonEntidades.Soporte.CRMNovedad) = New List(Of Entidades.JSonEntidades.Soporte.CRMNovedad)()

         Using dtNovedades As DataTable = New Reglas.CRMNovedades().GetNovedadesParaWeb()
            Using dtSeguimientos As DataTable = New Reglas.CRMNovedadesSeguimiento().GetNovedadesParaWeb()
               For Each drNovedad As DataRow In dtNovedades.Rows
                  Dim novedad As Entidades.JSonEntidades.Soporte.CRMNovedad
                  novedad = Entidades.JSonEntidades.Soporte.CRMNovedad.Parse(IdEmpresa, drNovedad)
                  novedades.Add(novedad)
                  For Each drSeguimiento As DataRow In dtSeguimientos.Select(String.Format("IdTipoNovedad = '{0}' AND Letra = '{1}' AND CentroEmisor = {2} AND IdNovedad = {3}",
                                                                                           novedad.IdTipoNovedad, novedad.Letra, novedad.CentroEmisor, novedad.IdNovedad))
                     novedad.Seguimientos.Add(Entidades.JSonEntidades.Soporte.NovedadesSeguimiento.Parse(IdEmpresa, drSeguimiento))
                  Next
               Next
            End Using
         End Using

         SubirIndividual("Novedades", novedades, tamanoPagina:=Reglas.Publicos.Simovil.Subida.PaginaTickets, binario:=True)
      End Sub

      Private Sub SubirEstadosNovedades()
         Dim estados As List(Of Entidades.CRMEstadoNovedad) = New Reglas.CRMEstadosNovedades().GetTodos(idTipoNovedad:="")
         SubirIndividual("EstadosNovedades", estados.ConvertAll(Function(x) New Entidades.JSonEntidades.Soporte.EstadosNovedades(IdEmpresa, x)))
      End Sub

      Public Sub SubirCategoriasNovedades()
         Dim categorias As List(Of Entidades.CRMCategoriaNovedad) = New Reglas.CRMCategoriasNovedades().GetTodos(idTipoNovedad:="")
         SubirIndividual("CategoriasNovedades", categorias.ConvertAll(Function(x) New Entidades.JSonEntidades.Soporte.CategoriasNovedades(IdEmpresa, x)))
      End Sub

      Public Sub SubirTiposComentariosNovedades()
         Dim categorias As List(Of Entidades.CRMTipoComentarioNovedad) = New Reglas.CRMTiposComentariosNovedades().GetTodos(idTipoNovedad:="")
         SubirIndividual("TiposComentariosNovedades", categorias.ConvertAll(Function(x) New Entidades.JSonEntidades.Soporte.TiposComentariosNovedades(IdEmpresa, x)))
      End Sub

      Public Sub SubirEmpresas()
         Dim dtClientes As DataTable = New Reglas.Clientes().GetAll()
         SubirIndividual("Empresa", dtClientes.Select().ToList().ConvertAll(Function(x) New Entidades.JSonEntidades.Soporte.Empresas(IdEmpresa, x)))
      End Sub

      '      Private Sub SubirIndividual(Of T)(metodo As Metodo, lista As List(Of T), Optional binario As Boolean = False)
      '         OnAvanceImportarAutomaticamente(String.Format("Subiendo información de {0}.", metodo.ToString()))

      '         Try
      '            Dim archWeb As New Archivos.BaseArchivosWeb(Of T)()

      '            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

      '            Dim metodoUrl As String = metodo.ToString()
      '            If binario Then
      '               metodoUrl = String.Concat(metodoUrl, "/", "binary")
      '            End If

      '            Dim uri As Uri = New Uri(BaseUri, metodoUrl)

      '            OnAvanceImportarAutomaticamente(String.Format("Borrando información de {0}.", metodo.ToString()))
      '            archWeb.Delete(uri.ToString(), headers)

      '            Dim paginas As List(Of T()) = PaginarDatos(lista, 1000)

      '            Dim paginasCount As Integer = paginas.Count
      '            For i As Integer = 0 To paginasCount - 1
      '               Dim pagina As T() = paginas(i)
      '               OnAvanceImportarAutomaticamente(String.Format("Subiendo información de {0} - Página {1} de {2}.", metodo.ToString(), i + 1, paginasCount))
      '               archWeb.Post(pagina, uri.ToString(), headers, binario)
      '            Next
      '         Catch ex As System.Net.WebException
      '            NetExceptionHelper.NetExceptionHandler(ex)
      '         End Try
      '      End Sub

      '      Private Function PaginarDatos(Of T)(datos As List(Of T), registrosPorPagina As Integer) As List(Of T())
      '         Dim result As List(Of T()) = New List(Of T())
      '         Dim posicion As Integer = 0
      '         While posicion < datos.Count
      '            Dim pagina(Math.Min(datos.Count - posicion, registrosPorPagina) - 1) As T
      '            datos.CopyTo(posicion, pagina, 0, Math.Min(datos.Count - posicion, registrosPorPagina))
      '            result.Add(pagina)
      '            posicion += registrosPorPagina
      '         End While
      '         Return result
      '      End Function


      '#Region "Evento Control de Avance"
      '      Public Event AvanceImportarAutomaticamente(sender As Object, e As AvanceImportarAutomaticamenteEventArgs)
      '      Protected Overridable Sub OnAvanceImportarAutomaticamente(etapa As String)
      '         RaiseEvent AvanceImportarAutomaticamente(Me, New AvanceImportarAutomaticamenteEventArgs(etapa))
      '      End Sub
      '      Public Class AvanceImportarAutomaticamenteEventArgs
      '         Inherits EventArgs
      '         Public Property Etapa As String
      '         Public Sub New(etapa As String)
      '            Me.Etapa = etapa
      '         End Sub
      '      End Class

      '#End Region

      'Private Function GetResponseMessage(response As WebResponse) As String
      '   Dim strErrorResponse As String
      '   Using stm As Stream = response.GetResponseStream()
      '      Using sr As New StreamReader(stm)
      '         strErrorResponse = sr.ReadToEnd()
      '      End Using
      '   End Using
      '   Return strErrorResponse
      'End Function

      'Private Enum Metodo
      '   Solicitudes
      '   Novedades
      '   EstadosNovedades
      '   CategoriasNovedades
      '   Empresa
      'End Enum

   End Class
End Namespace