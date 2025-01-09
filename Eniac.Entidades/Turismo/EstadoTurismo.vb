Public Class EstadoTurismo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdEstadoTurismo
      NombreEstadoTurismo
      Posicion
      Finalizado
      PorDefecto
      SolicitaPasajeros
      Color
   End Enum

   Public Property IdEstadoTurismo As Integer
   Public Property NombreEstadoTurismo As String
   Public Property Posicion As Integer
   Public Property Finalizado As Boolean
   Public Property PorDefecto As Boolean
   Public Property SolicitaPasajeros As Boolean
   Public Property Color As Integer?

End Class