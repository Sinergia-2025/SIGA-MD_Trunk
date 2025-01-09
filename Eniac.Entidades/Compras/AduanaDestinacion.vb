Public Class AduanaDestinacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdDestinacion
      NombreDestinacion
      RegimenArancelario
   End Enum

   Public Sub New()
   End Sub

   Public Property IdDestinacion As String
   Public Property NombreDestinacion As String
   Public Property RegimenArancelario As String

End Class