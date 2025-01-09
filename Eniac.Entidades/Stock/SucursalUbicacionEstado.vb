Public Class SucursalUbicacionEstado
   Inherits Entidad

   Public Const NombreTabla As String = "EstadosUbicaciones"

   Public Enum Columnas
      IdEstado
      NombreEstado
      OrdenEstado
      Activo
   End Enum

   Public Property IdEstado As Integer
   Public Property NombreEstado As String
   Public Property OrdenEstado As Integer
   Public Property Activo As Boolean

End Class
