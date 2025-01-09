Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class PedidosML
      Public Enum Campos
         id
         date_created
         comment
         pack_id
         pickup_id
         total_amount
         paid_amount
         order_items
         currency_id
         shipping
         status
         buyer
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property id As String
      Public Property date_created As String
      Public Property comment As String
      Public Property pack_id As String
      Public Property pickup_id As String
      Public Property total_amount As String
      Public Property paid_amount As String
      Public Property order_items As List(Of Order_Items)
      Public Property currency_id As String
      Public Property shipping As Shippings
      Public Property status As String
      Public Property buyer As Buyers
   End Class

End Namespace
