Imports System.Text

Namespace My

   ' The following events are availble for MyApplication:
   ' 
   ' Startup: Raised when the application starts, before the startup form is created.
   ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
   ' UnhandledException: Raised if the application encounters an unhandled exception.
   ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
   ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
   Partial Friend Class MyApplication

      Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
         Dim stb As StringBuilder = New StringBuilder()
         stb.Append("Se ha producido un error que no se pudo controlar, por favor comuniquese con Sistemas.")

         If e.Exception IsNot Nothing Then
            stb.AppendLine().AppendLine()
            stb.AppendLine(New String("-"c, 30)).AppendLine(New String(" "c, 7) + "DETALLE TECNICO").AppendLine(New String("-"c, 30))
            stb.Append(e.Exception.Message)
            If e.Exception.InnerException IsNot Nothing Then
               stb.AppendLine().AppendLine()
               stb.Append(e.Exception.InnerException.Message)
            End If
         End If

         My.Application.Log.WriteEntry(e.Exception.ToString(), TraceEventType.Critical)

         MessageBox.Show(stb.ToString(), "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Sub



   End Class

End Namespace

