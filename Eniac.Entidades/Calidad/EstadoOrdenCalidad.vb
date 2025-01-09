Public Class EstadoOrdenCalidad
   Inherits Entidad
   Public Const NombreTabla As String = "EstadosOrdenesCalidad"

   Public Enum Columnas
      IdEstadoCalidad
      TipoEstadoCalidad
      Orden
      BackColor
      ForeColor

   End Enum

   Public Property IdEstadoCalidad As String
   Public Property TipoEstadoCalidad As TiposEstadosCalidad
   Public Property Orden As Integer
   Public Property BackColor As Integer?
   Public Property ForeColor As Integer?

   Public Enum TiposEstadosCalidad
      PENDIENTE
      ENPROCESO
      ANULADO
      ACEPTADO
      RECHAZADO
   End Enum

   Public Enum ValoresFijosEstadosOrdenesCalidad As Integer
      <Description("(Selección Multiple)")> SeleccionMultiple = -1
      <Description("(Todos)")> Todos = -2
   End Enum
End Class