Public Class TipoListaProductoProgramacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdListaControlTipo
      Dia
      IdProducto
      IdUsuario
      FechaModificacion
      NombreProducto
      NombreProductoModeloTipo
   End Enum

   Public Property IdListaControlTipo As Integer
   Public Property Dia As Date
   Public Property IdProducto As String
   Public Property NombreProducto As String
   Public Property IdUsuario As String
   Public Property FechaModificacion As DateTime
   Public Property NombreProductoModeloTipo As String

End Class