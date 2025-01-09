Public Class EstadoVehiculo
   Inherits Entidad
   Public Const NombreTabla As String = "EstadosVehiculos"
   Public Enum Columnas
      IdEstadoVehiculo
      NombreEstadoVehiculo
      EnStock
      SolicitaFecha
      IdEstadoVehiculoLuegoVencer
      Predeterminado

   End Enum

   Public Sub New()
   End Sub

   Public Property IdEstadoVehiculo As Integer
   Public Property NombreEstadoVehiculo As String
   Public Property EnStock As Boolean
   Public Property SolicitaFecha As Boolean
   Public Property IdEstadoVehiculoLuegoVencer As Integer?
   Public Property Predeterminado As Boolean

End Class