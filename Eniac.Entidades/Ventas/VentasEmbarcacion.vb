Public Class VentasEmbarcacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdEmbarcacion
      CodigoEmbarcacion
      NombreEmbarcacion
      IdCategoriaEmbarcacion
      NombreCategoriaEmbarcacion
   End Enum

   Public Property IdEmbarcacion As Long
   Public Property CodigoEmbarcacion As Long
   Public Property NombreEmbarcacion As String
   Public Property IdCategoriaEmbarcacion As Integer
   Public Property NombreCategoriaEmbarcacion As String

End Class
