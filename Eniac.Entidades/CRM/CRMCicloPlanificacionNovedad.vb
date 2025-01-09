Public Class CRMCicloPlanificacionNovedad
   Inherits Entidad
   Public Const NombreTabla As String = "CRMCiclosPlanificacionNovedades"

   Public Enum Columnas
      IdCicloPlanificacion
      IdTipoNovedad
      Letra
      CentroEmisor
      IdNovedad
      Orden
      TipoPlanificacion
      Planificada
      IdEstadoNovedadInicio
      IdEstadoNovedadCierre
      IdEstadoNovedadFinal
      IdUsuarioAlta
      FechaAlta
      IdUsuarioActualizacion
      FechaActualizacion

   End Enum

   Public Property IdCicloPlanificacion As Integer
   Public Property IdTipoNovedad As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property IdNovedad As Long
   Public Property Orden As Integer
   Public Property TipoPlanificacion As TiposPlanificacion
   Public Property Planificada As Boolean
   Public Property IdEstadoNovedadInicio As Integer?
   Public Property IdEstadoNovedadCierre As Integer?
   Public Property IdEstadoNovedadFinal As Integer?
   Public Property IdUsuarioAlta As String
   Public Property FechaAlta As Date
   Public Property IdUsuarioActualizacion As String
   Public Property FechaActualizacion As Date

   Public Enum TiposPlanificacion
      ABIERTA
      CERRADA
   End Enum

End Class