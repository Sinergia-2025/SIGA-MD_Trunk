Namespace ServiciosRest.Concesionarios
   Public Class SincronizacionMovilProcesoFinalizadoEventArgs
      Inherits EventArgs
      Public Sub New(concesionario As Entidades.ConcesionarioMovil, mensaje As String, nuevos As Integer, actualizados As Integer)
         Me.Concesionario = concesionario
         Me.Mensaje = mensaje
         Me.Nuevos = nuevos
         Me.Actualizados = actualizados
      End Sub

      Public Property Concesionario As Entidades.ConcesionarioMovil
      Public Property Mensaje As String
      Public Property Nuevos As Integer
      Public Property Actualizados As Integer
   End Class
End Namespace