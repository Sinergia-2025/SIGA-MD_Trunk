Public Class ProductoModeloSubTipo
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadProductosModelosSubTipos"

   Public Enum Columnas
      IdProductoModeloSubTipo
      NombreProductoModeloSubTipo
      IdProductoModeloTipo
   End Enum

   Public Property IdProductoModeloSubTipo As Integer
   Public Property NombreProductoModeloSubTipo As String
   Public Property IdProductoModeloTipo As Integer

End Class
