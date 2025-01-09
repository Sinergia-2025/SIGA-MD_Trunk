Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class Actualizaciones
      Public Enum Campos
         id
         title
         price
         available_quantity
         status
      End Enum

      '-- Solo las propiedades que voy a enviar.-
      Public Property id As String                       '-- ID de Producto.-
      Public Property title As String                    '-- Titulo de Publicacion
      Public Property price As String                    '-- Precio de Publicacion
      Public Property available_quantity As String       '-- Cantidad Disponible de Publicacion
      Public Property status As String                   '-- Estado de Publicacion
   End Class

End Namespace
