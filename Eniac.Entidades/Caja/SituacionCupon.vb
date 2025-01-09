Public Class SituacionCupon
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "SituacionCupones"

   Public Enum Columnas
      IdSituacionCupon
      NombreSituacionCupon
      PorDefecto
   End Enum

   Public Property IdSituacionCupon As Integer
   Public Property NombreSituacionCupon As String
   Public Property PorDefecto As Boolean
End Class
