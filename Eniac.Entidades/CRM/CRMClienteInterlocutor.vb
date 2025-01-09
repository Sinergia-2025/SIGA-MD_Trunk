Public Class CRMClienteInterlocutor
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCliente
      Interlocutor
   End Enum

   Public Sub New()
   End Sub

   Public Property IdCliente() As Long
   Public Property Interlocutor() As String

End Class