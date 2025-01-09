Public Class CalendarioUsuario
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdCalendario
      IdUsuario

   End Enum

   Public Property IdCalendario As Integer
   Public Property IdUsuario As String
   Public Property PermitirEscritura As Boolean

End Class