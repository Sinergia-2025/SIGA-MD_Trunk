Public Class ExcepcionTipo
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadExcepcionesTipos"

   Public Enum Columnas
      IdExcepcionTipo
      NombreExcepcionTipo

   End Enum

   Public Property IdExcepcionTipo As Integer
   Public Property NombreExcepcionTipo As String

End Class
