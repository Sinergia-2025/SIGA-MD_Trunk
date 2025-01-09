
'Namespace JSonEntidades.Pedidos
Public Class PedidosJSonTALKIU
      Public Enum Resultados
         results
      End Enum

   '# Solo las propiedades que voy a enviar
   Public Property results As List(Of OrdenesTalkiu)

End Class

   Public Class OrdenesTalkiu
   Public Enum Ordenes
      proposal_id
      red
      title
      supplier
      start_date
      end_date
      status
      goal_group_info
      payment_methods
      orders
      total_products_quantity
      subtotal
      discount
      total
   End Enum
   Public Property proposal_id As String
      Public Property red As Red
      Public Property title As String
      Public Property supplier As String
      Public Property start_date As String
      Public Property end_date As String
      Public Property status As String
      Public Property goal_group_info As List(Of String)
      Public Property payment_methods As List(Of String)
      Public Property orders As List(Of Orders)
   Public Property total_products_quantity As Integer?
   Public Property subtotal As Double?
   Public Property discount As Double?
   Public Property total As Double?

End Class

   Public Class Red
      Public Enum Red
         name
         id
      End Enum
      Public Property name As String
      Public Property id As String
   End Class

   Public Class Orders
      Public Enum Orden
         order_id
         proposal_id
         red
         retailer
         supplier
         status
         order_lines
         quantity
         payment_method
         subtotal
         discount
         total
         observations
         confirmed_at
      End Enum

      Public Property order_id As String
      Public Property proposal_id As String
      Public Property red As Red
      Public Property retailer As retailer
      Public Property supplier As supplier
      Public Property status As String
   Public Property order_lines As List(Of OrdersLines)

   Public Property quantity As Integer?
   Public Property payment_method As String
   Public Property subtotal As Double?
   Public Property discount As Double?
   Public Property total As Double?
   Public Property observations As String
   Public Property confirmed_at As Date?

End Class

   Public Class retailer
      Public Enum Red
         name
         cuit
         state
         location
         postal_code
         transport
      End Enum
      Public Property name As String
      Public Property cuit As String
      Public Property state As String
      Public Property location As String
      Public Property postal_code As String
      Public Property transport As String

   End Class
   Public Class supplier
      Public Enum Red
         name
         cuit
      End Enum
      Public Property name As String
      Public Property cuit As String

   End Class

   Public Class OrdersLines
      Public Enum Lines
         sku_code
         gtin
         description
         price_without_discount
         price
         discount
         price_from_field
         quantity
         total
      End Enum

      Public Property sku_code As String
      Public Property gtin As String
      Public Property description As String
      Public Property price_without_discount As String
   Public Property price As Double?
   Public Property discount As Double?
   Public Property price_from_field As String
   Public Property quantity As Integer?
   Public Property total As Double?

End Class

'End Namespace

