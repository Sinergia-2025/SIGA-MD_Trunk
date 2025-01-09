Public Class Embarcacion
   Inherits Entidades.Entidad

   Public Enum Estados
      ALTA
      ENGUARDERIA
      RESERVADO
      BOTADO
      SALIDA
      INACTIVO
   End Enum

   Public Enum Situaciones
      ALTA
      ENGUARDERIA
      SALIDA
   End Enum

End Class

Public Class EmbarcacionLiviano
   Inherits Entidades.Entidad

   Public Enum Columnas
      IdEmbarcacion
      CodigoEmbarcacion
      NombreEmbarcacion
   End Enum

   Public Property IdEmbarcacion As Long
   Public Property CodigoEmbarcacion As Long
   Public Property NombreEmbarcacion As String

End Class