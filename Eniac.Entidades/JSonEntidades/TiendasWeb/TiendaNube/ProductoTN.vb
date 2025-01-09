Namespace JSonEntidades.TiendasWeb.TiendaNube
   Public Class ProductoTN
      Public Enum Campos
         id
         name
         description
         handle
         variants
         images
         categories
         brand
         published
         free_shipping
         seo_title
         seo_description
         attributes
         tags
         created_at
         updated_at
         requires_shipping
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property Id As String
      Public Property Name As StringMultilenguaje
      Public Property Description As StringMultilenguaje
      Public Property Variants As List(Of VarianteTN)
      Public Property Categories As List(Of Categoria)
      Public Property Brand As String
      Public Property Published As Boolean
      Public Property Free_Shipping As Boolean
      Public Property Requires_Shipping As Boolean

   End Class

End Namespace
