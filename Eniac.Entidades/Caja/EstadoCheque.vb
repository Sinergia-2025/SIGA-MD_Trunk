Public Class EstadoCheque
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "EstadosCheques"
   Public Enum Columnas
      IdEstadoCheque
      NombreEstadoCheque
   End Enum

   Public Property IdEstadoCheque As String
   Public Property NombreEstadoCheque As String

End Class