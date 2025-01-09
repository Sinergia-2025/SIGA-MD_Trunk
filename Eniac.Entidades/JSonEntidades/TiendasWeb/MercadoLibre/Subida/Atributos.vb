Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class Atributos
      Public Enum Campos
         id
         value_id
         value_name
      End Enum

      '-- Solo las propiedades que voy a enviar.-
      Public Property id As String                       '-- ID de Producto.-
      Public Property value_id As String                    '-- Titulo de Publicacion
      Public Property value_name As String                    '-- Precio de Publicacion
   End Class

End Namespace
