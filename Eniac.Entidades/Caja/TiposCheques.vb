Public Class TiposCheques
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "TiposCheques"

   Public Enum Columnas
      IdTipoCheque
      NombreTipoCheque
      SolicitaNroOperacion
   End Enum

   Public Property IdTipoCheque As String
   Public Property NombreTipoCheque As String
   Public Property SolicitaNroOperacion As Boolean

End Class
