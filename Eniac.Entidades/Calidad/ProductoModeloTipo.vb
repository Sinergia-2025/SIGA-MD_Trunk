Public Class ProductoModeloTipo
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadProductosModelosTipos"

   Public Enum ValoresFijosIdProductoModeloTipo As Integer
      <Description("(Selección Multiple)")> SeleccionMultiple = -1
      <Description("(Todos)")> Todos = -2
   End Enum

   Public Enum Columnas
      IdProductoModeloTipo
      NombreProductoModeloTipo
   End Enum

   Public Property IdProductoModeloTipo As Integer
   Public Property NombreProductoModeloTipo As String

End Class
