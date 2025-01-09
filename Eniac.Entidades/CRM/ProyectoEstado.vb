Public Class ProyectoEstado
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "ProyectosEstados"

    Public Enum Columnas
      IdEstado
      NombreEstado
      Finalizado
      Color
      Posicion
   End Enum

   Public Property IdEstado As Integer
   Public Property NombreEstado As String
   Public Property Finalizado As Boolean
   Public Property Color As Integer?
   Public Property Posicion As Integer?

End Class
