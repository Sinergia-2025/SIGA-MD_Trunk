Namespace ServiciosRest.TiendasWeb
   Public Class SincronizacionTiendaWebProcesoFinalizadoEventArgs
      Inherits EventArgs
      Public Sub New(tienda As Entidades.TiendasWeb, mensaje As String, nuevos As Integer, actualizados As Integer)
         Me.Tienda = tienda
         Me.Mensaje = mensaje
         Me.Nuevos = nuevos
         Me.Actualizados = actualizados
      End Sub

      Public Property Tienda As Entidades.TiendasWeb
      Public Property Mensaje As String
      Public Property Nuevos As Integer
      Public Property Actualizados As Integer
   End Class
End Namespace