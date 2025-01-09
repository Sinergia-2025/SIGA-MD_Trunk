Namespace JSonEntidades.TiendasWeb.Mercadolibre
   Public Class OrdenesML
      Public Enum Campos
         results
         display
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property results As List(Of Resultado)
      Public Property display As String
   End Class

   Public Class Resultado
      Public Enum Campos
         id
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property id As Long
   End Class

End Namespace
