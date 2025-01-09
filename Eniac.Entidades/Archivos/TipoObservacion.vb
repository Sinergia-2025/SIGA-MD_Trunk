Public Class TipoObservacion
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "TiposObservaciones"

#Region "Columnas"
   Public Enum Columnas
      IdObservaciones
      Descripcion
      Activa
      PorDefecto
   End Enum
#End Region

#Region "Campos"
   Public Property IdObservaciones As Short
   Public Property Descripcion As String
   Public Property Activa As Boolean
   Public Property PorDefecto As Boolean

#End Region
End Class
