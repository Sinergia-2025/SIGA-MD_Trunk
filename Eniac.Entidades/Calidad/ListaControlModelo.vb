Public Class ListaControlModelo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProductoModelo
      IdListaControl
      fecha
      Idusuario
   End Enum

   Public Property IdProductoModelo As Integer
   Public Property IdListaControl As Integer
   Public Property fecha As DateTime
   Public Property IdUsuario As String
   Public Property NombreListaControl As String
   Public Property Orden As Integer

End Class