Public Class CRMTipoEstadoNovedad
   Inherits CRMEntidad

   Public Const NombreTabla As String = "CRMTiposEstadosNovedades"

   Public Enum Columnas
      IdTipoEstadoNovedad
      NombreTipoEstadoNovedad
      Posicion
      IdTipoNovedad
   End Enum

   Public Property IdTipoEstadoNovedad As Integer
   Public Property NombreTipoEstadoNovedad As String
   Public Property Posicion As Integer


End Class
