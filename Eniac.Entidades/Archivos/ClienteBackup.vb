Public Class ClienteBackup
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ClientesBackups"
   Public Enum Columnas
      IdCliente
      NombreServidor
      BaseDatos
      FechaEjecucion
      FechaInicioBackup
      FechaFinBackup
      Activo
   End Enum

   Public Property IdCliente As Long
   Public Property NombreServidor As String
   Public Property BaseDatos As String
   Public Property FechaEjecucion As DateTime
   Public Property FechaInicioBackup As DateTime?
   Public Property FechaFinBackup As DateTime?
   Public Property Activo As Boolean
End Class