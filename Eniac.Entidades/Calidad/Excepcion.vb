Public Class Excepcion
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadExcepciones"

   Public Enum Columnas
      IdExcepcion
      IdListaControlTipo
      IdExcepcionTipo
      Motivo
      FechaExcepcion
      IdUsuario
      AccionesCorrectivas
      Item
      IdUsuario1
      IdUsuario2
      IdUsuario3
      FechaUsuario1
      FechaUsuario2
      FechaUsuario3
      Dpto

   End Enum
   Public Property IdExcepcion As Integer
   Public Property IdListaControlTipo As Integer
   Public Property IdExcepcionTipo As Integer
   Public Property Motivo As String
   Public Property FechaExcepcion As DateTime
   Public Property IdUsuario As String
   Public Property AccionesCorrectivas As String
   Public Property Item As String
   Public Property IdUsuario1 As String
   Public Property IdUsuario2 As String
   Public Property IdUsuario3 As String
   Public Property FechaUsuario1 As DateTime
   Public Property FechaUsuario2 As DateTime
   Public Property FechaUsuario3 As DateTime
   Public Property Dpto As String

End Class
