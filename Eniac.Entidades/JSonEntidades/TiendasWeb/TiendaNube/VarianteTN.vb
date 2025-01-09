Namespace JSonEntidades.TiendasWeb.TiendaNube
   Public Class VarianteTN
      Public Enum Campos
         id
         image_id
         product_id
         price
         promotional_price
         stock_management
         stock
         weight
         width
         height
         depth
         sku
         values
         barcode
         created_at
         updated_at
      End Enum

      '# Solo las propiedades que se van a enviar
      Public Property Id As String
      Public Property Product_id As String
      Public Property Price As Decimal?
      Public Property Promotional_Price As Decimal?
      Public Property Stock As Integer?
      Public Property Weight As Decimal?
      Public Property Width As Decimal?
      Public Property Height As Decimal?
      Public Property Depth As Decimal?
      Public Property Sku As String
      Public Property Barcode As String

   End Class

End Namespace
