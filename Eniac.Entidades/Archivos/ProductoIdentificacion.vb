Public Class ProductoIdentificacion
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "ProductosIdentificaciones"
   Public Enum Columnas
      IdProducto
      Identificacion
   End Enum

   Public Sub New()
   End Sub
   Public Sub New(idProducto As String, identificacion As String)
      Me.New()
      Me.IdProducto = idProducto
      Me.Identificacion = identificacion
   End Sub

   Public Property IdProducto As String
   Public Property Identificacion As String

End Class