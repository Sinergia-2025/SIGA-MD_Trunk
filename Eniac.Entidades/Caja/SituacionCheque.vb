Public Class SituacionCheque
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "SituacionCheques"

   Public Enum Columnas
      IdSituacionCheque
      NombreSituacionCheque
      PorDefecto

   End Enum

   Public Property IdSituacionCheque As Integer
   Public Property NombreSituacionCheque As String
   Public Property PorDefecto As Boolean

End Class
