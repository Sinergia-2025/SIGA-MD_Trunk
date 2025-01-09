Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class Shippings
      Inherits Entidad

      Public Enum Campos
         id
         mode
         site_id
         receiver_address
         shipping_option
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property id As String
      Public Property mode As String
      Public Property site_id As String
      Public Property receiver_address As Receiver_Address
      Public Property shipping_option As Shipp_Options

   End Class

   Public Class Receiver_Address
      Public Enum Campos
         id
         address_line
         street_name
         street_number
         comment
         zip_code
         city
         state
         country
         receiver_name
         receiver_phone
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property id As String
      Public Property address_line As String
      Public Property street_name As String
      Public Property street_number As String
      Public Property comment As String
      Public Property zip_code As String
      Public Property city As Ubicacion
      Public Property state As Ubicacion
      Public Property country As Ubicacion
      Public Property receiver_name As String
      Public Property receiver_phone As String

   End Class

   Public Class Ubicacion
      Public Enum Campos
         id
         name
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property id As String
      Public Property name As String
   End Class

   Public Class Shipp_Options
      Public Enum Campos
         id
         name
         currency_id
         list_cost
         cost
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property id As String
      Public Property name As String
      Public Property currency_id As String
      Public Property list_cost As String
      Public Property cost As String

   End Class

   Public Class Billing_Info
      Public Enum Campos
         billing_info
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property billing_info As Billing_Data
   End Class

   Public Class Billing_Data
      Public Enum Campos
         doc_type
         doc_number
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property doc_type As String
      Public Property doc_number As String
   End Class

End Namespace
