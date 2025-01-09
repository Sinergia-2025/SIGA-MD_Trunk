Namespace JSonEntidades.CobranzasMovil
   Public Class Temp_Ejecuciones
      Public Property IdEmpresa As Integer
      Public Property IdEjecucion_Temp As Guid
      Public Property FechaEjecucion_Temp As String

      Public Property Sucursales As ICollection(Of Temp_EjecucionesSucursales) = New HashSet(Of Temp_EjecucionesSucursales)

   End Class
   Public Class Temp_EjecucionesSucursales
      Public Property IdEmpresa As Integer
      Public Property IdEjecucion_Temp As Guid
      Public Property IdSucursal As Integer

   End Class

End Namespace