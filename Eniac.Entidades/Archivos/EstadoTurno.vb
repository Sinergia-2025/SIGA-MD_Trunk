Public Class EstadoTurno
   Inherits Entidades.Entidad

   Public Enum Columnas
      IdEstadoTurno
      NombreEstadoTurno
      Color
      Finalizado
   End Enum

   Public Property IdEstadoTurno As String
   Public Property NombreEstadoTurno As String
   Public Property Color As Integer?
   Public Property Finalizado As Boolean

End Class
