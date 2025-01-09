Namespace ServiciosRest.Concesionarios
   Public Class SincronizacionMovilErrorEventArgs
      Inherits EventArgs

      Public Sub New(concesionario As Entidades.ConcesionarioMovil, elementoTransmitido As String, mensaje As String)
         Me.Concesionario = concesionario
         Me.ElementoTransmitido = elementoTransmitido
         Me.Mensaje = mensaje
      End Sub

      Public Property Concesionario As Entidades.ConcesionarioMovil
      Public Property ElementoTransmitido As String
      Public Property Mensaje As String

   End Class
End Namespace