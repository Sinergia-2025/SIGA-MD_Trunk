Namespace ServiciosRest
   Public Class ErrorResponse
      Public Property CodigoError As Integer
      Public Property MensajeError As String
      Public Property MensajeTecnico As IEnumerable(Of String)
      Public Property Excepcion As Exception
   End Class

   Public Class TurnoErrorResponse
      Public Property Status As Integer
      Public Property Title As String
      Public Property ErrorTecnico As String

      Public Overrides Function ToString() As String
         Dim stb = New StringBuilder()
         stb.AppendFormatLine(Title)
         If Not String.IsNullOrWhiteSpace(ErrorTecnico) Then
            stb.AppendLine().AppendLine().AppendLine("MENSAJE TECNICO").AppendLine().Append(ErrorTecnico)
         End If
         Return stb.ToString()
      End Function

   End Class

   Public Class TiendasWebErrorResponse
      Inherits ErrorResponse
      Public Property code As Integer
      Public Property message As String
      Public Property description As String
      Public Property Excepcion As Exception
   End Class
End Namespace