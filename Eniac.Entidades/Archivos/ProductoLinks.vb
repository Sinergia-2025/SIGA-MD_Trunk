Public Class ProductoLinks
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProducto
      ItemLink
      Descripcion
      Link
      IdTipoAdjunto
      NombreTipoAdjunto
   End Enum

   Public Property IdProducto As String
   Public Property ItemLink As Integer
   Public Property Descripcion As String
   Public Property Link As String
   Public Property IdTipoAdjunto As Integer
   Public Property NombreTipoAdjunto As String


End Class
