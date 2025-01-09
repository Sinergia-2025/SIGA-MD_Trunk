Public Class CRMMedioComunicacionNovedad
   Inherits CRMEntidad

   Public Enum Columnas
      IdMedioComunicacionNovedad
      NombreMedioComunicacionNovedad
      Posicion
      IdTipoNovedad
      PorDefecto
      Color
   End Enum

   Public Property IdMedioComunicacionNovedad() As Integer
   Public Property NombreMedioComunicacionNovedad() As String
   Public Property Posicion() As Integer
   Public Property PorDefecto As Boolean
   Public Property Color As Integer?

End Class