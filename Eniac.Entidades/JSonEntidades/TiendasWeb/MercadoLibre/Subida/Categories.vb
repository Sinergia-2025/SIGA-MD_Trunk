Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class Categories
      Public Enum Campos
         id
         settings
      End Enum

      '-- Solo las propiedades que voy a enviar.-
      Public Property id As String                       '-- ID de Producto.-
      Public Property settings As Seteos                  '-- Estado de Publicacion
   End Class

   Public Class Seteos
      Inherits Entidad

      Public Enum Campos
         max_description_length
         max_title_length
         minimum_price
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property max_description_length As Long
      Public Property max_title_length As Long
      Public Property minimum_price As Decimal
   End Class


End Namespace
