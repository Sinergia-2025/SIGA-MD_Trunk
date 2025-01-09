Public Class ContabilidadEstadoAsiento
   Inherits Entidad

   Public Const NombreTabla As String = "ContabilidadEstadosAsientos"

   Public Enum Columnas
      IdEstadoAsiento
      NombreEstadoAsiento
      PorDefectoManual
      PorDefectoAutomatico

   End Enum

#Region "Propiedades"
   Public Property IdEstadoAsiento As Integer
   Public Property NombreEstadoAsiento As String
   Public Property PorDefectoManual As Boolean
   Public Property PorDefectoAutomatico As Boolean
#End Region

End Class