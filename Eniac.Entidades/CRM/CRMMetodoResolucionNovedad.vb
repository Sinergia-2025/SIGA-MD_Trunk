Public Class CRMMetodoResolucionNovedad
   Inherits CRMEntidad

   Public Enum Columnas
      IdMetodoResolucionNovedad
      NombreMetodoResolucionNovedad
      Posicion
      IdTipoNovedad
      PorDefecto
   End Enum

   Public Property IdMetodoResolucionNovedad() As Integer
   Public Property NombreMetodoResolucionNovedad() As String
   Public Property Posicion() As Integer
   Public Property PorDefecto() As Boolean

End Class