Namespace JSonEntidades.TiendasWeb.Arborea
   Public Class Shipping
      Public Enum Campos
         first_name
         last_name
         company
         address_1
         address_2
         city
         state
         postcode
         country
      End Enum

      Public Property first_name As String               '-- Primer Nombre.-
      Public Property last_name As String                '-- Apellido.-
      Public Property company As String                  '-- Email de Cliente.-
      Public Property address_1 As String                '-- Direccion 1.-
      Public Property address_2 As String                '-- Direccion 2.-
      Public Property city As String                     '-- Ciudad.-
      Public Property state As String                    '-- Estado - Provincia.-
      Public Property postcode As String                 '-- Codigo Postal.-
      Public Property country As String                  '-- Pais.-
   End Class

End Namespace
