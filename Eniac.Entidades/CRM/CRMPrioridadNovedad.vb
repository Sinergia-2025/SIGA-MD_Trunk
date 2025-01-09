Public Class CRMPrioridadNovedad
   Inherits CRMEntidad

   Public Enum Columnas
      IdPrioridadNovedad
      NombrePrioridadNovedad
      Posicion
      IdTipoNovedad
      PorDefecto
   End Enum

   Public Property IdPrioridadNovedad() As Integer
   Public Property NombrePrioridadNovedad() As String
   Public Property Posicion() As Integer
   Public Property PorDefecto As Boolean

End Class