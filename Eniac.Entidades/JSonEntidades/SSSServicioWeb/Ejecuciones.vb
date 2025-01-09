Namespace JSonEntidades.SSSServicioWeb
   Public Class Ejecuciones
      Public Property CodigoCliente As Long
      Public Property NombreServidor As String
      Public Property BaseDatos As String
      Public Property FechaEjecucion As Date
      Public Property FechaInicio As Nullable(Of Date)
      Public Property FechaFinalizacion As Nullable(Of Date)
      Public Property FechaDescarga As Nullable(Of Date)
      Public Property FechaProceso As Nullable(Of Date)
      Public Property Procesado As Boolean
      Public Property IdUnico As System.Guid
      Public Property TipoEjecucion As String
   End Class
End Namespace