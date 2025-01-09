Public Class TurnosCalendariosProductos
   Inherits Entidad
   Public Const NombreTabla As String = "TurnosCalendariosProductos"
   Public Enum Columnas
      IdTurno
      IdProducto
      Orden
      NumeroSesion
      ValorFluencia
   End Enum

   Public Property IdTurno As Integer
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property NumeroSesion As Integer
   Public Property ValorFluencia As Integer

   Public Property NombreProducto As String     'Solo para grillas

End Class