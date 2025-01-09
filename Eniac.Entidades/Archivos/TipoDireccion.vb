<Serializable()>
Public Class TipoDireccion
   Inherits Entidad
   Public Const NombreTabla As String = "TiposDirecciones"
   Public Enum Columnas
      IdTipoDireccion
      NombreTipoDireccion
      NombreAbrevTipoDireccion
   End Enum

   Public Property IdTipoDireccion As Integer
   Public Property NombreTipoDireccion As String
   Public Property NombreAbrevTipoDireccion As String

End Class