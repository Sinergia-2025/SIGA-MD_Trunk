Public Class FechaSincronizacion
   Inherits Entidad

   Public Const NombreTabla As String = "FechasTransferencias"
   Public Enum Columnas
      FechaInicioSubida
      FechaInicioBajada
      FechaSubida
      FechaBajada
      SistemaDestino
      Tabla
      IdUsuario
      FechaActualizacion
      NroVersionAplicacion
      MetodoGrabacion
      IdFuncion
   End Enum

   Public Property FechaInicioSubida As Date?
   Public Property FechaInicioBajada As Date?
   Public Property FechaSubida As Date?
   Public Property FechaBajada As Date?
   Public Property SistemaDestino As String
   Public Property Tabla As String
   Public Property IdUsuario As String
   Public Property FechaActualizacion As Date?
   Public Property NroVersionAplicacion As String
   Public Property MetodoGrabacionActual As MetodoGrabacion
   Public Property IdFuncion As String
End Class