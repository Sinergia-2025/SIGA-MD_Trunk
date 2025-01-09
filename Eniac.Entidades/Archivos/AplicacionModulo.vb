Public Class AplicacionModulo
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "AplicacionesModulos"
   Public Enum Columnas
      IdModulo
      NombreModulo
   End Enum

   Public Property IdModulo As Integer
   Public Property NombreModulo As String

End Class