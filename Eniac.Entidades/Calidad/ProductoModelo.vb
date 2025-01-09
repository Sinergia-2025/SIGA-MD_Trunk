Public Class ProductoModelo
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadProductosModelos"

   Public Enum Columnas
      IdProductoModelo
      NombreProductoModelo
      CodigoProductoModelo
      IdProductoModeloTipo
      IdProductoModeloSubTipo
   End Enum

   Public Property IdProductoModelo As Integer
   Public Property NombreProductoModelo As String
   Public Property CodigoProductoModelo As String
   Public Property IdProductoModeloTipo As Integer
   Public Property IdProductoModeloSubTipo As Integer

End Class
