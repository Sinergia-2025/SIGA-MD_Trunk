Public Class Pais
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "Paises"
   Public Enum Columnas
      IdPais
      NombrePais
      IdAfipPais
   End Enum

   Public Sub New()
   End Sub

   Public Property IdPais As String
   Public Property NombrePais As String
   Public Property IdAfipPais As Integer

End Class