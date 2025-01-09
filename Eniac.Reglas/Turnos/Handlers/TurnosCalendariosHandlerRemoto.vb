Namespace Turnos.Handlers
   Public Class TurnosCalendariosHandlerRemoto
      Implements ITurnosCalendariosHandler

      Public ReadOnly Property PuedeEditar As Boolean Implements ITurnosCalendariosHandler.PuedeEditar
         Get
            Return False
         End Get
      End Property

      Public Sub New(da As Datos.DataAccess)
         _baseURL = Publicos.SimovilTurnosURLBase
      End Sub

      Public Class CrearTurnoSinReservaSinergiaDTO
         Public Property idCliente As Long
         Public Property idEmbarcacion As Long
         Public Property idDestino As Integer
         Public Property idTipoCalendario As Integer
         Public Property fechaHoraDesde As String
         Public Property fechaHoraHasta As String
         Public Property destinoDetalle As String
         Public Property numeroPasajeros As Integer
         Public Property timonel As String
         Public Property confirmado As Boolean
         Public Property idTipoServicio As String


      End Class
      Public Sub Inserta(entidad As Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.Inserta

         Dim web = New ServiciosRest.Archivos.BaseArchivosWeb(Of CrearTurnoSinReservaSinergiaDTO)()
         Dim headers = New ServiciosRest.HeadersDictionary()
         headers.AgregarEmpresa(Convert.ToInt32(Publicos.CodigoClienteSinergia)).AgregarVersion()

         Dim en As CrearTurnoSinReservaSinergiaDTO = entidad.Convert()

         Dim url = String.Format("{0}/Turnos/CrearTurnoSinReserva", _baseURL.TrimEnd("/"c))
         web.Post(en, url, headers, binario:=False)
         'web.Post(en, "http://tifon.sinergiamovil.com.ar/api/Turnos/Turnos/CrearTurnoSinReserva", headers, binario:=False)

      End Sub

      Public Sub Actualiza(entidad As Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.Actualiza

      End Sub

      Public Sub ActualizaEstadoPorIdUnico(idTurnoUnico As String, estado As Entidades.EstadoTurno) Implements ITurnosCalendariosHandler.ActualizaEstadoPorIdUnico
         If estado.Finalizado Then
            Dim web = New ServiciosRest.Archivos.BaseArchivosWeb(Of String)()
            Dim headers = New ServiciosRest.HeadersDictionary()
            headers.AgregarEmpresa(Convert.ToInt32(Publicos.CodigoClienteSinergia)).AgregarVersion()

            Dim url = String.Format("{0}/Turnos/{1}/ConfirmarTurno", _baseURL.TrimEnd("/"c), idTurnoUnico)
            web.Put(String.Empty, url, headers)

         End If
      End Sub

      Public Sub Borra(entidad As Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.Borra
         Dim web = New ServiciosRest.Archivos.BaseArchivosWeb(Of String)()
         Dim headers = New ServiciosRest.HeadersDictionary()
         headers.AgregarEmpresa(Convert.ToInt32(Publicos.CodigoClienteSinergia)).AgregarVersion()

         Dim url = String.Format("{0}/Turnos/{1}", _baseURL.TrimEnd("/"c), entidad.IdTurnoUnico)
         web.Delete(url, headers)

      End Sub

      Public Function GetInvocados(venta As Entidades.Venta) As List(Of Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.GetInvocados

      End Function

      Public Function GetTodos() As List(Of Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.GetTodos

      End Function

      Private _baseURL As String = "http://tifon.sinergiamovil.com.ar/api/Turnos"

      Public Function GetTodos(idCalendario As Integer, fechaDesdeDesde As Date?, fechaDesdeHasta As Date?) As List(Of Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.GetTodos
         Return ProcesaReservas(GetTodosInterno(idCalendario, fechaDesdeDesde, fechaDesdeHasta))
      End Function

      Private Function ProcesaReservas(lista As List(Of Entidades.TurnoCalendario)) As List(Of Entidades.TurnoCalendario)

         Dim rReserva = New Reservas()
         rReserva.ActualizaDesdeTurno(lista.Where(Function(t) t.Calendario.SolicitaBotado AndAlso t.IdEstadoTurno <> "R" And t.Activo).ToArray())
         rReserva.CancelaDesdeTurno(lista.Where(Function(t) t.Calendario.SolicitaBotado AndAlso Not t.Activo).ToArray())

         lista.RemoveAll(Function(t) t.Activo = False)

         Return lista
      End Function

      Private Function GetTodosInterno(idCalendario As Integer, fechaDesdeDesde As Date?, fechaDesdeHasta As Date?) As List(Of Entidades.TurnoCalendario)
         Dim stbUrl = New StringBuilder()
         stbUrl.AppendFormat("{0}/ObtenerTurnos", _baseURL.TrimEnd("/"c))
         stbUrl.AppendFormat("?{0}={1}", "ExcluirReservasExpiradas", Boolean.FalseString)
         stbUrl.AppendFormat("&{0}={1}", "ExcluirEliminados", Boolean.FalseString)

         If fechaDesdeDesde.HasValue Then
            stbUrl.AppendFormat("&{0}={1}", "FechaDesde", fechaDesdeDesde.Value.ToString("O"))
         End If
         If fechaDesdeHasta.HasValue Then
            stbUrl.AppendFormat("&{0}={1}", "FechaHasta", fechaDesdeHasta.Value.ToString("O"))
         End If
         If idCalendario > 0 Then
            stbUrl.AppendFormat("&{0}={1}", "IdCalendario", idCalendario)
         End If

         Dim wc = New Net.WebClient()
         Try
            wc.Headers.Add("IdEmpresa", Publicos.CodigoClienteSinergia)
            Using cacheTurnos = Cache.TurnosCacheHandler.Instancia
               Using cacheArchivo = Ayudante.Cache.Archivos.CacheEmbarcacionSiga.Instancia
                  Dim cacheGral = New BusquedasCacheadas()
                  Using orResult As System.IO.Stream = wc.OpenRead(stbUrl.ToString())
                     Using reader = New IO.StreamReader(orResult, New System.Text.UTF8Encoding())
                        Dim responseString = reader.ReadToEnd()
                        Dim serializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                        Dim datos = serializer.Deserialize(Of List(Of Entidades.JSonEntidades.Turnos.TurnoSinergiaDTO))(responseString)

                        Return datos.ConvertAll(Function(x) x.Convert(cacheGral))
                     End Using
                  End Using
               End Using
            End Using
         Catch ex As Net.WebException
            ServiciosRest.NetExceptionHelper.NetExceptionHandler(ex)
            Return Nothing
         End Try

      End Function

      Public Function GetUno(idTurno As String) As Entidades.TurnoCalendario Implements ITurnosCalendariosHandler.GetUno
         Return GetUno(idTurno, Base.AccionesSiNoExisteRegistro.Vacio)
      End Function

      Public Function GetUno(idTurno As String, accion As Base.AccionesSiNoExisteRegistro) As Entidades.TurnoCalendario Implements ITurnosCalendariosHandler.GetUno

         Dim stbUrl = New StringBuilder()
         stbUrl.AppendFormat("{0}/Turnos/{1}", _baseURL, idTurno)

         Dim wc = New Net.WebClient()
         Try
            wc.Headers.Add("IdEmpresa", Publicos.CodigoClienteSinergia)
            Using cacheTurnos = Cache.TurnosCacheHandler.Instancia
               Using cacheArchivo = Ayudante.Cache.Archivos.CacheEmbarcacionSiga.Instancia
                  Dim cacheGral = New BusquedasCacheadas()
                  Using orResult As System.IO.Stream = wc.OpenRead(stbUrl.ToString())
                     Using reader = New IO.StreamReader(orResult, New System.Text.UTF8Encoding())
                        Dim responseString = reader.ReadToEnd()
                        Dim serializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                        Dim datos = serializer.Deserialize(Of Entidades.JSonEntidades.Turnos.TurnoSinergiaDTO)(responseString)

                        Return datos.Convert(cacheGral)
                     End Using
                  End Using
               End Using
            End Using
         Catch ex As Net.WebException
            If accion = Base.AccionesSiNoExisteRegistro.Vacio Then
               Return New Entidades.TurnoCalendario()
            End If
            If accion = Base.AccionesSiNoExisteRegistro.Excepcion Then
               ServiciosRest.NetExceptionHelper.NetExceptionHandler(ex)
            End If
            Return Nothing
         End Try
      End Function

      Public Function ControlaCupoDisponible(turnos As List(Of Entidades.TurnoCalendario),
                                             turnoActual As Entidades.TurnoCalendario,
                                             fechaHoraDesde As DateTime,
                                             fechaHoraHasta As DateTime,
                                             cupo As Integer) As Boolean Implements ITurnosCalendariosHandler.ControlaCupoDisponible

         'Dim contCupos As Integer = 0
         'For Each turExistente As Entidades.TurnoCalendario In turnos
         '   If turExistente.IdTurno <> turnoActual.IdTurno Then
         '      If turExistente.FechaDesde < fechaHoraHasta And turExistente.FechaHasta > fechaHoraDesde Then
         '         contCupos += 1
         '      End If
         '   End If
         'Next
         'Return contCupos < cupo


         Dim col = GetTodosInterno(turnoActual.IdCalendario, fechaHoraDesde, fechaDesdeHasta:=Nothing)

         Dim contCupos As Integer = 0
         For Each turExistente In col
            If turExistente.IdTurno <> turnoActual.IdTurno Then
               If turExistente.FechaDesde < fechaHoraHasta And turExistente.FechaHasta > fechaHoraDesde Then
                  contCupos += 1
               End If
            End If
         Next
         Return contCupos < cupo
      End Function

   End Class
End Namespace