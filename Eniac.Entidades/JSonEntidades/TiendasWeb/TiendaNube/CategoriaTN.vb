Namespace JSonEntidades.TiendasWeb.TiendaNube
   Public Class CategoriaTN
      Public Enum Campos
         id
         name
         descripton
         handle
         parent
         subcategories
         created_at
         updated_at
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property Id As String
      Public Property Name As StringMultilenguaje
      Public Property Parent As String

   End Class

End Namespace
