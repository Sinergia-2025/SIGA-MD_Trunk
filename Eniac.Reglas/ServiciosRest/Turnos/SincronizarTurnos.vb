Namespace ServiciosRest.Turnos
   Public Class SincronizarTurnos
      Inherits SincronizacionBase

      Public Sub New()
         MyBase.New(Publicos.SimovilTurnosURLBase)
         'MyBase.New("http://tifon.sinergiamovil.com.ar/api/Turnos")
         'MyBase.New("http://sinergia-pc-04/Soporte/api/")
      End Sub

      Public Sub ImportarAutomaticamente()
         DescargarTurnosNuevos(New Entidades.Filtros.GetPorRangoFechasFiltros(Today.AddDays(-5), Today.UltimoSegundoDelDia()))

      End Sub


      Private Sub DescargarTurnosNuevos(filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
         'OnAvance("Obteniendo Solicitudes de Tickets")
         Dim turnosWeb = ObtenerSolicitudesTicket(filtros)
         'Dim calendarios = New Reglas.Calendarios().GetTodos()

         Using cacheTurnos = Cache.TurnosCacheHandler.Instancia
            Using cacheArchivo = Ayudante.Cache.Archivos.CacheEmbarcacionSiga.Instancia
               Dim cacheGral = New BusquedasCacheadas()

               For Each turnoWeb In turnosWeb
                  OnAvance(String.Format("Cargando {0} {1:G} {2:G} / {3}", turnoWeb.TurnoId, turnoWeb.FechaHoraDesde, turnoWeb.FechaHoraHasta, turnoWeb.IdCliente))

                  Dim turno = turnoWeb.Convert(cacheGral)

                  Dim da As Datos.DataAccess = New Datos.DataAccess()
                  da.OpenConection()
                  Try
                     da.BeginTransaction()

                     Dim sqlTurno = New SqlServer.TurnosCalendarios(da, Publicos.IDAplicacionSinergia)

                     OnAvance(String.Format("Grabando {0} {1:G} {2:G} / {3}", turnoWeb.TurnoId, turnoWeb.FechaHoraDesde, turnoWeb.FechaHoraHasta, turnoWeb.IdCliente))

                     If turno.IdEstadoTurno = "R" AndAlso turnoWeb.FechaHoraExpiracion.HasValue AndAlso turnoWeb.FechaHoraExpiracion.Value < Now Then
                        sqlTurno.TurnosCalendarios_D(turno.IdTurnoUnico)
                     Else
                        sqlTurno.TurnosCalendarios_M_Guid(turno.IdTurno, turno.IdTurnoUnico, turno.IdCalendario, turno.FechaDesde, turno.FechaHasta, turno.IdCliente, turno.Observaciones,
                                                          turno.IdTipoTurno, turno.IdProducto, turno.PrecioLista, turno.Precio,
                                                          turno.DescuentoRecargoPorcGral, turno.DescuentoRecargoPorc1, turno.DescuentoRecargoPorc2, turno.PrecioNeto,
                                                          turno.NumeroSesion, turno.IdEstadoTurno,
                                                          turno.IdEmbarcacion, turno.IdDestino, turno.DestinoLibre, turno.CantidadPasajeros, turno.FechaHoraLlegada)
                     End If

                     'OnAvance(String.Format("Marcando {0} {1:G} {2:G} / {3}", solicitud.TurnoId, solicitud.FechaHoraDesde, solicitud.FechaHoraHasta, solicitud.IdCliente))
                     'MarcarSolicitud(solicitud)
                     da.CommitTransaction()
                  Catch
                     da.RollbakTransaction()
                     Throw
                  Finally
                     da.CloseConection()
                  End Try

               Next
            End Using
         End Using
      End Sub

      Public Function ObtenerSolicitudesTicket(filtros As Entidades.Filtros.GetPorRangoFechasFiltros) As List(Of Entidades.JSonEntidades.Turnos.TurnoSinergiaDTO)
         Try

            Dim archWeb As New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Turnos.TurnoSinergiaDTO)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim stb = New StringBuilder(BaseUri.ToString())
            stb.Append("/ObtenerTurnos/")
            Dim separador = "?"
            AddParameter(stb, separador, "desde", filtros.FechaDesde.ToString("O"))
            AddParameter(stb, separador, "hasta", filtros.FechaHasta.ToString("O"))

            'Dim uri As Uri = New Uri(BaseUri, "ObtenerTurnos")
            'Dim uri = New Uri(stb.ToString())

            OnAvance(String.Format("Descargando información de {0}.", "Turnos"))

            Dim result = archWeb.Get(stb.ToString(), 0, Integer.MaxValue, Today, headers)

            Return result
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            Return Nothing
         End Try
      End Function

      Private Sub AddParameter(stb As StringBuilder, ByRef separador As String, key As String, value As String)
         stb.AppendFormat("{0}{1}={2}", separador, key, value)
         separador = "&"
      End Sub

   End Class
End Namespace