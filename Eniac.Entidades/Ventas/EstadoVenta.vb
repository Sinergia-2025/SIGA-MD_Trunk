Public Class EstadoVenta
   Inherits Entidad
   Public Const NombreTabla As String = "EstadosVenta"
   Public Enum Columnas
      IdEstadoVenta
      NombreEstadoVenta
      IdTipoMovimiento
   End Enum

   Public Property IdEstadoVenta As Integer
   Public Property NombreEstadoVenta As String
   Public Property IdTipoMovimiento As String

End Class