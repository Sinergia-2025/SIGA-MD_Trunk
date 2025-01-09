Public Class ProductoExcepcion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProducto
      IdExcepcion
      fecha
      IdUsuario

   End Enum

   Public Property IdProducto As String
   Public Property IdExcepcion As Integer
   Public Property fecha As DateTime
   Public Property IdUsuario As String
   Public Property NombreProducto As String


End Class