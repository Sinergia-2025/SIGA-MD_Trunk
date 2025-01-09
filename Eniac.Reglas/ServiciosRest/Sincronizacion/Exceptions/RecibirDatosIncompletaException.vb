Namespace ServiciosRest.Sincronizacion
   Public Class RecibirDatosIncompletaException
      Inherits Exception

      Public Sub New(tipo As Type, ultimaPaginaSincronizada As Integer)
         MyBase.New(String.Format("No se finalizó la descarga de {0} - Última página sincronizada: {1}", tipo.Name, ultimaPaginaSincronizada))
      End Sub


   End Class
End Namespace