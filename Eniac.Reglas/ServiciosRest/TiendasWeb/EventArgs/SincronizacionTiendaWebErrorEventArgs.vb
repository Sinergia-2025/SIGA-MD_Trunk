Namespace ServiciosRest.TiendasWeb
   Public Class SincronizacionTiendaWebErrorEventArgs
      Inherits EventArgs

      Public Sub New(tienda As Entidades.TiendasWeb, elementoTransmitido As String, mensaje As String)
         Me.Tienda = tienda
         Me.ElementoTransmitido = elementoTransmitido
         Me.Mensaje = mensaje
      End Sub

      Public Property Tienda As Entidades.TiendasWeb
      Public Property ElementoTransmitido As String
      Public Property Mensaje As String

   End Class
End Namespace