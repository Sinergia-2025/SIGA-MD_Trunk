Public Class TipoTurno
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdTipoTurno
      NombreTipoTurno
      IdTipoCalendario
   End Enum

   Public Property IdTipoTurno As String
   Public Property NombreTipoTurno As String
   Public Property IdTipoCalendario As Short
End Class