Public Class CategoriaLegajo
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadCategorias"

   Public Enum Columnas
      Idcategoria
      NombreCategoria
   End Enum

   Public Property Idcategoria As Integer
   Public Property NombreCategoria As String

End Class
