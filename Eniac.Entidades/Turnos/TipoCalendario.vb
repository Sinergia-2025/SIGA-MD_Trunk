Public Class TipoCalendario
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "TiposCalendarios"
   Public Enum Columnas
      IdTipoCalendario
      NombreTipoCalendario
   End Enum

   Public Property IdTipoCalendario As Short
   Public Property NombreTipoCalendario As String
End Class