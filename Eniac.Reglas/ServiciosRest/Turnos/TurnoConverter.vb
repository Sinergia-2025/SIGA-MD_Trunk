Imports Eniac.Reglas.Ayudante.Cache.Turnos
Imports Eniac.Reglas.Ayudante.Cache.Archivos

Namespace ServiciosRest.Turnos
   Friend Class TurnoConverter

      Friend Shared Function FromWeb(turnoWeb As Entidades.JSonEntidades.Turnos.TurnoSinergiaDTO, cacheGral As BusquedasCacheadas) As Entidades.TurnoCalendario
         Dim turno = New Entidades.TurnoCalendario()
         Dim cal = CacheCalendarios.Instancia.Buscar(turnoWeb.IdCalendario)

         turno.IdTurno = 1
         turno.IdTurnoUnico = turnoWeb.TurnoId
         'turno.IdCalendario = turnoWeb.IdCalendario
         turno.Calendario = cal
         turno.FechaDesde = turnoWeb.FechaHoraDesde
         turno.FechaHasta = turnoWeb.FechaHoraDesde.AddMinutes(cal.LapsoPorDefecto)

         Dim emb = CacheEmbarcacionSiga.Instancia.Buscar(turnoWeb.IdEmbarcacion)
         turno.IdEmbarcacion = emb.IdEmbarcacion
         turno.CodigoEmbarcacion = emb.CodigoEmbarcacion
         turno.NombreEmbarcacion = emb.NombreEmbarcacion

         turno.IdDestino = turnoWeb.IdDestino.IfNull()
         turno.DestinoLibre = turnoWeb.DestinoDetalle
         turno.CantidadPasajeros = turnoWeb.NumeroPasajeros.IfNull()
         turno.FechaHoraLlegada = turnoWeb.FechaHoraHasta

         Dim clte = cacheGral.BuscaClienteEntidadPorId(turnoWeb.IdCliente)
         turno.IdCliente = clte.IdCliente
         turno.CodigoCliente = clte.CodigoCliente
         turno.NombreCliente = clte.NombreCliente

         Dim tipoTurno = CacheTiposTurnos.Instancia.Buscar(turnoWeb.IdTipoServicio)
         If tipoTurno Is Nothing Then
            tipoTurno = CacheTiposTurnos.Instancia.BuscarPorTipoCalendario(cal.IdTipoCalendario).FirstOrDefault()
         End If
         turno.IdTipoTurno = tipoTurno.IdTipoTurno
         turno.NombreTipoTurno = tipoTurno.NombreTipoTurno


         Dim estado = CacheTurnosEstados.Instancia.Buscar(turnoWeb.IdTipoTurno)
         turno.IdEstadoTurno = estado.IdEstadoTurno
         turno.NombreEstadoTurno = estado.NombreEstadoTurno

         turno.Activo = Not turnoWeb.Eliminado

         Return turno

      End Function

      Friend Shared Function ToWeb(entidad As Entidades.TurnoCalendario) As Reglas.Turnos.Handlers.TurnosCalendariosHandlerRemoto.CrearTurnoSinReservaSinergiaDTO

         Dim turnoWeb = New Reglas.Turnos.Handlers.TurnosCalendariosHandlerRemoto.CrearTurnoSinReservaSinergiaDTO() _
             With {.idCliente = entidad.IdCliente,
                   .idEmbarcacion = entidad.IdEmbarcacion,
                   .idDestino = entidad.IdDestino,
                   .idTipoCalendario = entidad.Calendario.IdTipoCalendario,
                   .fechaHoraDesde = entidad.FechaDesdeString,
                   .fechaHoraHasta = entidad.FechaHastaString,
                   .destinoDetalle = entidad.DestinoLibre,
                   .numeroPasajeros = entidad.CantidadPasajeros,
                   .timonel = entidad.NombreCliente,
                   .confirmado = False,
                   .idTipoServicio = entidad.IdTipoTurno}

         Return turnoWeb
      End Function

   End Class
End Namespace