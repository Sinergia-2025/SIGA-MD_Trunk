Namespace JSonEntidades.Exportaciones.Pirelli
   Public Class Response
      Public Enum Campos
         Ok
         errores
         mensaje
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property Ok As Boolean
      Public Property Errores As List(Of UploadError)
      Public Property mensaje As String

   End Class

   Public Class UploadError
      Public Enum Campos
         linea
         [error]
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property linea As Integer
      Public Property [error] As String
   End Class

End Namespace