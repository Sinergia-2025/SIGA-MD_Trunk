Public Class Legajo
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadLegajos"

   Public Enum Columnas
      IdLegajo
      Legajo
      Nombre
      Activo
      IdSector
      IdCategoria
   End Enum

   Public Property IdLegajo As Integer
   Public Property Legajo As String
   Public Property Nombre As String
   Public Property Activo As Boolean
   Public Property IdSector As Integer
   Public Property IdCategoria As Integer

End Class
