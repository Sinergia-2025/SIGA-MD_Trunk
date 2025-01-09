Public Class CRMProspectoInterlocutor
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProspecto
      Interlocutor
   End Enum

   Public Sub New()

   End Sub

   Public Property IdProspecto() As Long
   Public Property Interlocutor() As String

End Class