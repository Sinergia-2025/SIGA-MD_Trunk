Public Class ClienteActualizacionSuceso
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ClientesActualizacionesSucesos"
   Public Enum Columnas
      IdCliente
      NombreServidor
      BaseDatos
      FechaEjecucion
      TipoSuceso
      Orden
      TipoSucesoValue
      Datos
      Estado
      Mensaje
      NombreScript
      Script

   End Enum

   Public Property IdCliente As Long
   Public Property NombreServidor As String
   Public Property BaseDatos As String
   Public Property FechaEjecucion As DateTime
   Public Property TipoSuceso As Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso
   Public Property Orden As Integer
   Public Property TipoSucesoValue As String
   Public Property Datos As String
   Public Property Mensaje As String
   Public Property NombreScript As String
   Public Property Script As String

   Public ReadOnly Property Estado As Entidades.ClienteActualizacion.EstadoActualizacion
      Get
         If TipoSuceso = JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_InicioBusqueda_Error Or
            TipoSuceso = JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Scripts_ErrorBajando Or
            TipoSuceso = JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_MSI_Error_BajandoInstaladores Or
            TipoSuceso = JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Backup_Error Or
            TipoSuceso = JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_EjecScripts_Error Or
            TipoSuceso = JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_InstalandoMSI_Error Or
            TipoSuceso = JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Finalizado_ConErrores Then
            Return ClienteActualizacion.EstadoActualizacion.ConError
         Else
            Return ClienteActualizacion.EstadoActualizacion.Finalizado
         End If
      End Get
   End Property


End Class