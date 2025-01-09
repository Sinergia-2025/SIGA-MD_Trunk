Imports System.Runtime.CompilerServices
Namespace Extensions
   Public Module TurnoSinergiaDTOExtensions
      <Extension>
      Public Function Convert(turnoWeb As Entidades.JSonEntidades.Turnos.TurnoSinergiaDTO,
                              cacheGral As BusquedasCacheadas) As Entidades.TurnoCalendario
         If cacheGral Is Nothing Then cacheGral = New BusquedasCacheadas()
         Return ServiciosRest.Turnos.TurnoConverter.FromWeb(turnoWeb, cacheGral)
      End Function
      <Extension>
      Public Function Convert(turno As Entidades.TurnoCalendario) As Reglas.Turnos.Handlers.TurnosCalendariosHandlerRemoto.CrearTurnoSinReservaSinergiaDTO
         Return ServiciosRest.Turnos.TurnoConverter.ToWeb(turno)
      End Function
   End Module
End Namespace