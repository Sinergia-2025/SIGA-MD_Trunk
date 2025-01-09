Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class PedidoProductoML
      Public Enum Campos
         product_id
         variant_id
         depth
         height
         name
         price
         quantity
         free_shipping
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property product_id As String
      Public Property variant_id As String
      Public Property depth As Decimal?
      Public Property height As Decimal?
      Public Property name As String
      Public Property price As Decimal
      Public Property quantity As Decimal
      Public Property free_shipping As Boolean
   End Class
End Namespace
