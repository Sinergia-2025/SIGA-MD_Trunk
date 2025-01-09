Public Class CRMTipoCategoriaNovedad
   Inherits Entidad

   Public Const NombreTabla As String = "CRMTiposCategoriasNovedades"

   Public Enum Columnas
      IdTipoCategoriaNovedad
      NombreTipoCategoriaNovedad
      Posicion
      IdTipoNovedad
   End Enum

   Public Property IdTipoCategoriaNovedad As Integer
   Public Property NombreTipoCategoriaNovedad As String
   Public Property Posicion As Integer
   Public Property IdTipoNovedad As String

End Class
