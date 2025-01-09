Namespace ServiciosRest.Sincronizacion
   Public Class EnviarDatosException
      Inherits Exception

      Public Sub New(tipo As Type, innerEx As Exception)
         MyBase.New(String.Format("Error al Enviar Datos de {0}: {1}", tipo.Name, innerEx.Message), innerEx)
      End Sub

   End Class
End Namespace