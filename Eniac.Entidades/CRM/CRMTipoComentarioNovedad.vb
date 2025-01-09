Public Class CRMTipoComentarioNovedad
   Inherits CRMEntidad

   Public Const NombreTabla As String = "CRMTiposComentariosNovedades"

   Public Enum Columnas
      IdTipoComentarioNovedad
      NombreTipoComentarioNovedad
      Posicion
      PorDefecto
      Color
      IdTipoNovedad
      VisibleParaCliente
      VisibleParaRepresentante

   End Enum

   Public Property IdTipoComentarioNovedad As Integer
   Public Property NombreTipoComentarioNovedad As String
   Public Property Posicion As Integer
   Public Property PorDefecto As Boolean
   Public Property Color As Integer?
   Public Property VisibleParaCliente As Boolean
   Public Property VisibleParaRepresentante As Boolean

End Class