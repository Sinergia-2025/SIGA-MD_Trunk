Public Enum TipoReservaStock
   DesReserva = -1
   NoMueveReserva = 0
   Reserva = 1
End Enum
Public Interface IReservaStock
   Property Reserva As Boolean
End Interface