Public Class EstadoCliente
   Inherits Entidades.Entidad

   Public Enum Columnas
      IdEstadoCliente
      NombreEstadoCliente
      Color
   End Enum

   Public Property IdEstadoCliente As Integer
   Public Property NombreEstadoCliente As String
   Public Property Color As Integer?
End Class
