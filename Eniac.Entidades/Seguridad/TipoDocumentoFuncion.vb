Public Class TipoDocumentoFuncion
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "TiposDocumentosFunciones"

   Public Enum Columnas
      IdTipoLink
      Descripcion
      DescripcionAbreviada
      Orden

   End Enum
   Public Property IdTipoLink As String
   Public Property Descripcion As String
   Public Property DescripcionAbreviada As String
   Public Property Orden As Integer

End Class