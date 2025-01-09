Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class Publicaciones
      Public Enum Campos
         id
         site_id
         title
         category_id
         price
         currency_id
         available_quantity
         listing_type_id
         condition
         pictures
         sale_terms
         attributes
         accepts_mercadopago
         status
      End Enum

      '-- Solo las propiedades que voy a enviar.-
      Public Property id As String                       '-- ID de Producto.-
      Public Property site_Id As String                  '-- ID de Site Pais.-
      Public Property title As String                    '-- Titulo de Publicacion
      Public Property category_id As String              '-- Categoria de Publicacion
      Public Property price As String                    '-- Precio de Publicacion
      Public Property currency_id As String              '-- Moneda de Publicacion
      Public Property available_quantity As String       '-- Cantidad Disponible de Publicacion
      Public Property listing_type_id As String          '-- ID del tipo de publicación.
      Public Property condition As String                '-- Condicion del Producto.
      Public Property pictures As List(Of Picture)       '-- Imagen Inicial de Publicacion
      Public Property sale_terms As List(Of SaleTerms)   '-- Terminos de Garantia
      Public Property attributes As List(Of Atributos)   '-- Atributos Marca Modelo.-
      Public Property accepts_mercadopago As String      '-- Acepta Mercado Pago
      Public Property status As String                   '-- Estado de Publicacion
   End Class

End Namespace