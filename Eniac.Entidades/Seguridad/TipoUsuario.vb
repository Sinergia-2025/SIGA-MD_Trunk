Public Class TipoUsuario
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "TiposUsuarios"

   Public Enum Columnas
      IdTipoUsuario
      NombreTipoUsuario
      EsDeProceso
   End Enum

   Public Property IdTipoUsuario As Integer
   Public Property NombreTipoUsuario As String
   Public Property EsDeProceso As Boolean

End Class