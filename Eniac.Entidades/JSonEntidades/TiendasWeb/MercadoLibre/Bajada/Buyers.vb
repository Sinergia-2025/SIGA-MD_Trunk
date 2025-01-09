Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class Buyers
      Inherits Entidad

      Public Enum Campos
         id
         nickname
         email
         first_name
         last_name
         phone
         alternative_phone
      End Enum

      Public Property id As Long
      Public Property nickname As String
      Public Property email As String
      Public Property first_name As String
      Public Property last_name As String
      Public Property phone As Phones
      Public Property alternative_phone As Phones
   End Class

   Public Class Phones
      Inherits Entidad

      Public Enum Campos
         area_code
         number
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property area_code As String
      Public Property number As String
   End Class

End Namespace

