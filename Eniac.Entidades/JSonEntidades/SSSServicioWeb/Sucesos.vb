Namespace JSonEntidades.SSSServicioWeb
   Public Class Sucesos
      Public Property CodigoCliente As Long
      Public Property NombreServidor As String
      Public Property BaseDatos As String
      Public Property FechaEjecucion As Date
      Public Property TipoSuceso As TipoSuceso
      Public Property Orden As Integer
      Public Property Datos As String


   End Class
   Public Enum TipoSuceso
      ComienzoBackup = 3001
      FinalizacionBackup = 3002
      ErrorBackup = 3003
      AdvertenciaBackup = 3004
      ConfiguracionBackup = 3100
      Parametros = 3101
      Dispositivos = 3102
      VersionProcesoBackup = 3201
      VersionBaseDatos = 3202

      Actualizador_Generico = 5000                 'Para notificaciones Generales. No se utiliza actualmente.
      Actualizador_InicioBusqueda = 5001           'Cuando inicia el proceso
      Actualizador_InicioBusqueda_Error = 5003     'Cuando hay un error al buscar la versión
      Actualizador_SinVersion = 5009               'Cuando la versión actual no requiere actualización y ejecutó la búsqueda

      Actualizador_Scripts_Grabando = 5101         'Luego de descargar los scripts, antes de guardar los mismos en BD
      Actualizador_Scripts_Grabados = 5102         'Luego de guardar exitosamente todos los scripts
      Actualizador_Scripts_ErrorBajando = 5103     'Si hay un error en la bajada y/o grabación del script // También cuando da un error no contemplado el proceso completo de bajada

      Actualizador_MSI_IniciandoBajada = 5201      'Cunado inicial la bajada del instalador
      Actualizador_MSI_FinBajada = 5202            'Cunado finaliza la descarga del instalador
      Actualizador_MSI_Error_BajandoInstaladores = 5203  'Cuando hay un error al descargar el instalador (se utiliza en 3 lugares diferentes)

      Actualizador_Backup_Inicio = 5301            'Cuando comienza la ejecución del backup
      Actualizador_Backup_Fin = 5302               'Cuando finaliza la ejecución del backup
      Actualizador_Backup_Error = 5303             'Cuando da error la ejeción del backup

      Actualizador_EjecScripts_Inicio = 5401       'Cuando comienza la ejecución de los scripts
      Actualizador_EjecScripts_Fin = 5402          'Cuando finaliza la ejecución de los scripts
      Actualizador_EjecScripts_Error = 5403        'Por cada script que da error en su ejecución // También cuando da una excepción la ejecución de los scripts en su proceso completo
      Actualizador_EjecScripts_Exitoso = 5404      'Por cada script que la ejecución es exitosa

      Actualizador_InstalandoMSI_Inicio = 5501     'Cuando inicial la ejecución del instalador
      Actualizador_InstalandoMSI_Fin = 5502        'Cuando el proceso de instalación finaliza su ejecuón
      Actualizador_InstalandoMSI_Error = 5503      'Cuando da error la instalación del MSI

      Actualizador_Finalizado = 5901               'Al finalizar el proceso de actualización, luego de instalar el MSI
      Actualizador_Finalizado_ConErrores = 5903    'No se utiliza, analizar como implementarlo
   End Enum
End Namespace