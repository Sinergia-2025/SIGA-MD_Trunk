Namespace JSonEntidades.TiendasWeb.Arborea
   Public Class Clientes
      Public Enum Campos
         email
         first_name
         last_name
         username
         billing
         shipping
      End Enum

      Public Property email As String                     '-- Email de Cliente.-
      Public Property first_name As String                '-- Primer Nombre.-
      Public Property last_name As String                 '-- Apellido.-
      Public Property username As String                  '-- User Name.-
      Public Property billing As List(Of Billing)         '-- Billing.-
      Public Property shipping As List(Of Shipping)       '-- Shipping.-
   End Class

   Public Class ClientesResponse
      Public Enum Campos
         id
      End Enum
      Public Property id As String                     '-- Email de Cliente.-
   End Class

   Public Class ClientesUpdate
      Public Enum Campos
         email
         first_name
         last_name
         username
      End Enum

      Public Property email As String                     '-- Email de Cliente.-
      Public Property first_name As String                '-- Primer Nombre.-
      Public Property last_name As String                 '-- Apellido.-
      Public Property username As String                  '-- User Name.-
   End Class


End Namespace
