Public Class ProductoTipoServicio
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadProductosTiposServicios"

   Public Enum Columnas
      IdProductoTipoServicio
      NombreProductoTipoServicio
      Prefijo

   End Enum

   Public Property IdProductoTipoServicio As Integer
   Public Property NombreProductoTipoServicio As String
   Public Property Prefijo As String

End Class
