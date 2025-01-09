Public Class CRMCategoriaNovedad
   Inherits CRMEntidad

   Public Enum Columnas
      IdCategoriaNovedad
      NombreCategoriaNovedad
      Posicion
      IdTipoNovedad
      PorDefecto
      Reporta
      Color
      PublicarEnWeb
      IdTipoCategoriaNovedad
   End Enum

   Public Enum ComboReporta
      SI
      NO
      CLIENTE
   End Enum

   Public Property IdCategoriaNovedad As Integer
   Public Property NombreCategoriaNovedad As String
   Public Property Posicion As Integer
   Public Property PorDefecto As Boolean
   Public Property Reporta As String
   Public Property Color As Integer?
   Public Property PublicarEnWeb As Boolean
   Public Property IdTipoCategoriaNovedad As Integer

End Class