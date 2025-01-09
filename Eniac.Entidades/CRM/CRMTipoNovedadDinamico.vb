Public Class CRMTipoNovedadDinamico
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoNovedad
      IdNombreDinamico
      EsRequerido
      Orden
   End Enum

   Public Property IdTipoNovedad As String
   Public Property IdNombreDinamico As String
   Public Property EsRequerido As Boolean
   Public Property Orden As Integer
End Class