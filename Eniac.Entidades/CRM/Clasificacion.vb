Public Class Clasificacion
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "Clasificaciones"

   Public Enum Columnas
      IdClasificacion
      NombreClasificacion
   End Enum

   Public Property IdClasificacion As Integer
   Public Property NombreClasificacion As String

End Class