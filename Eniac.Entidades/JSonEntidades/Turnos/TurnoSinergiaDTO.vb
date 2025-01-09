Namespace JSonEntidades.Turnos
   Public Class TurnoSinergiaDTO
      Public Property TurnoId As String
      Public Property IdCalendario As Integer
      Public Property FechaHoraDesde As DateTime
      Public Property FechaHoraHasta As DateTime?
      Public Property IdCliente As Long
      Public Property IdEmbarcacion As Long
      Public Property IdDestino As Short?
      Public Property DestinoDetalle As String
      Public Property NumeroPasajeros As Integer?
      Public Property Timonel As String
      Public Property Confirmado As Boolean
      Public Property IdTipoTurno As String
      Public Property IdTipoServicio As String
      Public Property Eliminado As Boolean

      Public Property FechaHoraInicioReserva As DateTime?
      Public Property FechaHoraExpiracion As DateTime?

   End Class
End Namespace