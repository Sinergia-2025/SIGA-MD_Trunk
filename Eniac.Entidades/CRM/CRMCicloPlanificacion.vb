Public Class CRMCicloPlanificacion
   Inherits Entidad
   Public Const NombreTabla As String = "CRMCiclosPlanificacion"

   Public Enum Columnas
      IdCicloPlanificacion
      NombreCicloPlanificacion
      IdEstadoCicloPlanificacion
      FechaInicio
      FechaCierre
      FechaFinalizacion
      IdUsuarioAlta
      FechaAlta
      IdUsuarioActualizacion
      FechaActualizacion

   End Enum

   Public Sub New()
      Novedades = New List(Of CRMCicloPlanificacionNovedad)()
   End Sub

   Public Property IdCicloPlanificacion As Integer
   Public Property NombreCicloPlanificacion As String
   Public Property EstadoCicloPlanificacion As CRMEstadoCicloPlanificacion
   Public Property FechaInicio As Date
   Public Property FechaCierre As Date
   Public Property FechaFinalizacion As Date
   Public Property IdUsuarioAlta As String
   Public Property FechaAlta As Date
   Public Property IdUsuarioActualizacion As String
   Public Property FechaActualizacion As Date

   Public Property Novedades As List(Of CRMCicloPlanificacionNovedad)

End Class