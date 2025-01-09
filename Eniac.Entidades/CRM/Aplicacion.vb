Public Class Aplicacion
   Inherits Entidad

   Public Sub New()
      MyBase.New()
   End Sub
   Public Enum Columnas
      IdAplicacion
      NombreAplicacion
      IdAplicacionBase
      PropietarioAplicacion
   End Enum

   Public Property IdAplicacion As String
   Public Property NombreAplicacion As String
   Public Property IdAplicacionBase As String
   Public Property PropietarioAplicacion As AplicacionPropietario
End Class
Public Enum AplicacionPropietario
   PROPIO
   TERCERO
End Enum