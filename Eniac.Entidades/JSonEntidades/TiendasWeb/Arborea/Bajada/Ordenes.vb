Namespace JSonEntidades.TiendasWeb.Arborea
   Public Class PedidosArborea
      Public Enum Campos
         results
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property results As List(Of Ordenes)
   End Class

   Public Class Ordenes
      Public Enum Campos
         id
         status
         currency
         date_created
         total
         total_tax
         customer_id
         billing
         shipping
         transaction_id
         line_items
      End Enum
      Public Property id As String
      Public Property status As String
      Public Property currency As String
      Public Property date_created As String
      Public Property total As String
      Public Property total_tax As String
      Public Property customer_id As Integer
      Public Property billing As Billing
      Public Property shipping As Shipping
      Public Property transaction_id As String
      Public Property line_items As List(Of Line_Items)
      Public Property shipping_line As List(Of Shipping_Line)
   End Class

   Public Class Shipping_Line
      Public Enum Campos
         id
         total
         total_tax
      End Enum
      Public Property id As String
      Public Property total As String
      Public Property total_tax As String
   End Class

   Public Class Line_Items
      Public Enum Campos
         id
         name
         product_id
         quantity
         price
         total_tax
      End Enum
      Public Property id As String
      Public Property name As String
      Public Property product_id As String
      Public Property quantity As String
      Public Property price As String
      Public Property total_tax As String
   End Class

End Namespace

