Public Class EstadoListaControl
   Inherits CRMEntidad

   Public Enum Columnas
      IdEstadoCalidad
      NombreEstadoCalidad
      Posicion
      Finalizado
      PorDefecto
      Color
   End Enum

   Public Property IdEstadoCalidad As Integer
   Public Property NombreEstadoCalidad As String
   Public Property Posicion As Integer
   Public Property Finalizado As Boolean
   Public Property PorDefecto As Boolean
   Public Property Color As Integer?

End Class