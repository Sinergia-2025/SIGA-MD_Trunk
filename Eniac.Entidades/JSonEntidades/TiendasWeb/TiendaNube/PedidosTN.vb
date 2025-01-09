Namespace JSonEntidades.TiendasWeb.TiendaNube
   Public Class PedidosTN
      Inherits Entidad
      Public Enum Campos
         id
         token
         number
         customer
         products
         note
         subtotal
         total
         billing_address
         billing_number
         billing_floor
         billing_locality
         billing_zipcode
         shipping_pickup_type
         shipping_address
         currency
         shipping_option
         shipping_cost_customer
         completed_at
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property id As Long
      Public Property token As String
      Public Property number As Long
      Public Property customer As ClienteTN
      Public Property products As List(Of PedidoProductoTN)
      Public Property note As String
      Public Property subtotal As Decimal
      Public Property total As Decimal
      Public Property billing_address As String
      Public Property billing_number As String
      Public Property billing_floor As String
      Public Property billing_locality As String
      Public Property billing_province As String
      Public Property billing_city As String
      Public Property billing_zipcode As Integer?
      Public Property shipping_pickup_type As String
      Public Property shipping_address As Addresses
      Public Property shipping_cost_customer As Decimal?
      Public Property currency As String
      Public Property shipping_option As String
      Public Property created_at As DateTime
      Public Property email As String
      Public Property phone As String
   End Class

End Namespace
