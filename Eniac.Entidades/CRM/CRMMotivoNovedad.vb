Public Class CRMMotivoNovedad
   Inherits CRMEntidad
   Public Const NombreTabla As String = "CRMMotivosNovedades"
   Public Enum Columnas
      IdMotivoNovedad
      NombreMotivoNovedad
      Posicion
      IdTipoNovedad

   End Enum

   Public Property IdMotivoNovedad As Integer
   Public Property NombreMotivoNovedad As String
   Public Property Posicion As Integer
   Public Property NombreTipoEstadoNovedad As String '# NO se persiste en DB. Simplemente se agrega para visualizarlo
End Class