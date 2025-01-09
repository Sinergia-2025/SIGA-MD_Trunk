Namespace JSonEntidades.TiendasWeb.Arborea
   Public Class Categorias
      Public Enum Campos
         name
         parent
         images
      End Enum

      Public Property name As String                  '-- Nombre Categoria.-
      Public Property parent As String                '-- Id Codigo Padre.-
      Public Property images As List(Of Images)      '-- Lista de Imagenes.-
   End Class

   Public Class CategoriasResponse
      Public Enum Campos
         id
      End Enum
      Public Property id As String                     '-- id de Categroia.-
   End Class

End Namespace
