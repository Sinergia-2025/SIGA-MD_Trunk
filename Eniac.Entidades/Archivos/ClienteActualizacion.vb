Public Class ClienteActualizacion
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ClientesActualizaciones"
   Public Enum Columnas
      IdCliente
      NombreServidor
      BaseDatos
      FechaEjecucion
      FechaInicioActualizacion
      FechaFinActualizacion
      IdUnico
      Estado
      EstadoDescargaScripts
      EstadoDescargaInstalador
      EstadoBackup
      EstadoEjecucionScripts
      EstadoEjecucionInstalador
      Activo

   End Enum

   Public Sub New()
      Sucesos = New List(Of ClienteActualizacionSuceso)()
   End Sub

   Public Property IdCliente As Long
   Public Property NombreServidor As String
   Public Property BaseDatos As String
   Public Property FechaEjecucion As DateTime
   Public Property FechaInicioActualizacion As DateTime?
   Public Property FechaFinActualizacion As DateTime?
   Public Property IdUnico As String
   Public Property Estado As EstadoActualizacion
   Public Property EstadoDescargaScripts As EstadoActualizacion = EstadoActualizacion.Pendiente
   Public Property EstadoDescargaInstalador As EstadoActualizacion = EstadoActualizacion.Pendiente
   Public Property EstadoBackup As EstadoActualizacion = EstadoActualizacion.Pendiente
   Public Property EstadoEjecucionScripts As EstadoActualizacion = EstadoActualizacion.Pendiente
   Public Property EstadoEjecucionInstalador As EstadoActualizacion = EstadoActualizacion.Pendiente
   Public Property Activo As Boolean

   Public Property Sucesos As List(Of Entidades.ClienteActualizacionSuceso)


#Region "Propiedades FK"
   Public Property CodigoCliente As Long
   Public Property NombreCliente As String
#End Region


   Public Enum EstadoActualizacion
      Pendiente
      Inicio
      Finalizado
      ConError
   End Enum
End Class