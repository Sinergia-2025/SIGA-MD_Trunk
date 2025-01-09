Public Class TipoListaMeta
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdListaControlTipo
      Dia
      MetaCoches
      IdUsuario
      FechaModificacion
   End Enum

   Public Property IdListaControlTipo As Integer
   Public Property Dia As Date
   Public Property MetaCoches As Integer
   Public Property IdUsuario As String
   Public Property FechaModificacion As DateTime

End Class