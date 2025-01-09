Public Class CRMEstadoCicloPlanificacion
   Inherits Entidad
   Public Const NombreTabla As String = "CRMEstadosCiclosPlanificacion"

   Public Enum Columnas
      IdEstadoCicloPlanificacion
      TipoEstadoCicloPlanificacion
      Orden
      PorDefecto
      BackColor
      ForeColor
   End Enum

   Public Property IdEstadoCicloPlanificacion As String
   Public Property TipoEstadoCicloPlanificacion As TiposEstadosCicloPlanificacion
   Public Property Orden As Integer
   Public Property PorDefecto As Boolean
   Public Property BackColor As Integer?
   Public Property ForeColor As Integer?

   Public Enum TiposEstadosCicloPlanificacion
      PENDIENTE
      ENPROCESO
      FINALIZADO
   End Enum

End Class