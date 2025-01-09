Imports System.Net
Imports System.Web.Script.Serialization
Imports System.IO

Namespace ServiciosRest
   Public Class NetExceptionHelper
      Friend Shared Sub NetExceptionHandler(ex As System.Net.WebException)
         Dim errorResponse As ErrorResponse = Nothing
         Dim turnoErrorResponse As TurnoErrorResponse = Nothing

         If TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.BadRequest Then
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)
            Try
               errorResponse = TryCast(New JavaScriptSerializer().Deserialize(strErrorResponse, GetType(ErrorResponse)), ErrorResponse)
            Catch innerEx As Exception
               Throw New BadRequestMessageDeserializeException(innerEx, ex)
            End Try
            If errorResponse Is Nothing OrElse errorResponse.CodigoError = 0 Then
               Try
                  turnoErrorResponse = TryCast(New JavaScriptSerializer().Deserialize(strErrorResponse, GetType(TurnoErrorResponse)), TurnoErrorResponse)
                  turnoErrorResponse.ErrorTecnico = strErrorResponse
               Catch innerEx As Exception
                  Throw New BadRequestMessageDeserializeException(innerEx, ex)
               End Try
            End If
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.InternalServerError Then
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)

            Throw New InternalServerErrorException(mensaje, ex)
         End If         'If ex.Response.StatusCode = HttpStatusCode.BadRequest Then

         If errorResponse IsNot Nothing AndAlso errorResponse.CodigoError <> 0 Then
            Throw New ErrorResponseException(errorResponse, ex)
         ElseIf turnoErrorResponse IsNot Nothing AndAlso turnoErrorResponse.Status <> 0 Then
            Throw New TurnoErrorResponseException(turnoErrorResponse, ex)
         Else
            Throw ex
         End If
      End Sub

      Private Shared Function GetResponseMessage(response As WebResponse) As String
         Dim strErrorResponse As String
         Using stm As Stream = response.GetResponseStream()
            Using sr As New StreamReader(stm)
               strErrorResponse = sr.ReadToEnd()
            End Using
         End Using
         Return strErrorResponse
      End Function

   End Class

#Region "Excepciones"
   Public Class TiendaNubeExceptionHelper
      Friend Shared Sub TiendaNubeExceptionHandler(ex As System.Net.WebException)
         Dim errorResponse As TiendasWebErrorResponse = Nothing
         If TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.BadRequest Then
            Try
               errorResponse = TryCast(New JavaScriptSerializer().Deserialize(GetResponseMessage(ex.Response), GetType(TiendasWebErrorResponse)), TiendasWebErrorResponse)
            Catch innerEx As Exception
               Throw New BadRequestMessageDeserializeException(innerEx, ex)
            End Try
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.InternalServerError Then
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)

            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 422 Then '# Unprocessable entity (Alguno de los datos que se están enviando es incorrecto)
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 415 Then '# Unsupported Media Type (El formato que se está enviando no es el correcto)
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 402 Then '# Payment required
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 404 Then '# Not Found 
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         End If

         If errorResponse IsNot Nothing AndAlso errorResponse.code <> 0 Then
            Throw New ErrorResponseException(errorResponse, ex)
         Else
            Throw ex
         End If
      End Sub

      Private Shared Function GetResponseMessage(response As WebResponse) As String
         Dim strErrorResponse As String
         Using stm As Stream = response.GetResponseStream()
            Using sr As New StreamReader(stm)
               strErrorResponse = sr.ReadToEnd()
            End Using
         End Using
         Return strErrorResponse
      End Function
   End Class

   Public Class MercadoLibreExceptionHelper
      Friend Shared Sub MercadoLibreExceptionHandler(ex As System.Net.WebException)
         Dim errorResponse As TiendasWebErrorResponse = Nothing
         If TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.BadRequest Then
            Try
               errorResponse = TryCast(New JavaScriptSerializer().Deserialize(GetResponseMessage(ex.Response), GetType(TiendasWebErrorResponse)), TiendasWebErrorResponse)
            Catch innerEx As Exception
               Throw New BadRequestMessageDeserializeException(innerEx, ex)
            End Try
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.InternalServerError Then
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)

            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 422 Then '# Unprocessable entity (Alguno de los datos que se están enviando es incorrecto)
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 415 Then '# Unsupported Media Type (El formato que se está enviando no es el correcto)
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 402 Then '# Payment required
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         End If

         If errorResponse IsNot Nothing AndAlso errorResponse.code <> 0 Then
            Throw New ErrorResponseException(errorResponse, ex)
         Else
            Throw ex
         End If
      End Sub

      Private Shared Function GetResponseMessage(response As WebResponse) As String
         Dim strErrorResponse As String
         Using stm As Stream = response.GetResponseStream()
            Using sr As New StreamReader(stm)
               strErrorResponse = sr.ReadToEnd()
            End Using
         End Using
         Return strErrorResponse
      End Function
   End Class

   Public Class ArboreaExceptionHelper

      Friend Shared Sub ArboreaExceptionHandler(ex As System.Net.WebException)
         Dim errorResponse As TiendasWebErrorResponse = Nothing
         If TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.BadRequest Then
            Try
               errorResponse = TryCast(New JavaScriptSerializer().Deserialize(GetResponseMessage(ex.Response), GetType(TiendasWebErrorResponse)), TiendasWebErrorResponse)
            Catch innerEx As Exception
               Throw New BadRequestMessageDeserializeException(innerEx, ex)
            End Try
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.InternalServerError Then
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)

            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 422 Then '# Unprocessable entity (Alguno de los datos que se están enviando es incorrecto)
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 415 Then '# Unsupported Media Type (El formato que se está enviando no es el correcto)
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 402 Then '# Payment required
            Dim strErrorResponse As String = GetResponseMessage(ex.Response)

            Dim mensaje As String
            mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}{4}{0}{0}Excepcion WebService: {0}{4}",
                                       Environment.NewLine,
                                       DirectCast(ex.Response, HttpWebResponse).Method,
                                       DirectCast(ex.Response, HttpWebResponse).ResponseUri,
                                       ex.Message,
                                       strErrorResponse)
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
            Throw New InternalServerErrorException(mensaje, ex)
         End If

         If errorResponse IsNot Nothing AndAlso errorResponse.code <> 0 Then
            Throw New ErrorResponseException(errorResponse, ex)
         Else
            Throw ex
         End If
      End Sub

      Private Shared Function GetResponseMessage(response As WebResponse) As String
         Dim strErrorResponse As String
         Using stm As Stream = response.GetResponseStream()
            Using sr As New StreamReader(stm)
               strErrorResponse = sr.ReadToEnd()
            End Using
         End Using
         Return strErrorResponse
      End Function

   End Class
   Public Class NetExceptionHelperException
      Inherits Exception
      Public Sub New(message As String, innerException As System.Exception)
         MyBase.New(message, innerException)
      End Sub
   End Class

   Public Class ErrorResponseException
      Inherits NetExceptionHelperException
      Public Sub New(errorResponse As ErrorResponse, innerException As Exception)
         MyBase.New(String.Format("{0} - {1}", errorResponse.CodigoError, errorResponse.MensajeError), innerException)
         Me.ErrorResponse = errorResponse
      End Sub
      Public Property ErrorResponse As ErrorResponse
   End Class

   Public Class TurnoErrorResponseException
      Inherits NetExceptionHelperException
      Public Sub New(errorResponse As TurnoErrorResponse, innerException As Exception)
         MyBase.New(errorResponse.ToString(), innerException)
         Me.ErrorResponse = errorResponse
      End Sub
      Public Property ErrorResponse As TurnoErrorResponse
   End Class

   Public Class InternalServerErrorException
      Inherits NetExceptionHelperException
      Public Sub New(message As String, innerException As System.Exception)
         MyBase.New(message, innerException)
      End Sub
   End Class

   Public Class BadRequestMessageDeserializeException
      Inherits NetExceptionHelperException
      Public Sub New(ex As Exception, exWeb As WebException)
         MyBase.New(String.Format("Error obteniendo el mensaje de error del BadReques: {0}", ex.Message), ex)
         InnerExceptionWeb = exWeb
      End Sub

      Public Property InnerExceptionWeb As WebException

   End Class
#End Region
End Namespace