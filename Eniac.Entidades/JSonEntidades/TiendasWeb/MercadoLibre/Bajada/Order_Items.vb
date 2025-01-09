Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class Order_Items
      Inherits Entidad
      Public Enum Campos
         item
         quantity
         currency_id
         unit_price
         sale_fee
      End Enum

      Public Property item As Items
      Public Property quantity As String
      Public Property currency_id As String
      Public Property unit_price As String
      Public Property sale_fee As String

   End Class

   Public Class Items
      Public Enum Campos
         id
         title
         category_id
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property id As String
      Public Property title As String
      Public Property category_id As String

   End Class

End Namespace
