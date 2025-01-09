Public Class ListaControlUsuario
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdListaControl
      IdUsuario
      NombreListaControl
      Nombre
   End Enum

   Public Property IdListaControl As Integer
   Public Property IdUsuario As String
   Public Property NombreListaControl As String
   Public Property Nombre As String

End Class