Imports System.Net.Mail
Imports System.Drawing

Public Class EniacException
   Inherits System.Exception

   Public Sub New()
      MyBase.New()
      Me.EnviarMail()
   End Sub

   Public Sub New(message As String)
      MyBase.New(message)
      Me.EnviarMail()
   End Sub

   Public Sub New(message As String, innerException As System.Exception)
      MyBase.New(message, innerException)
      Me.EnviarMail()
   End Sub

   Private Sub EnviarMail()
      Dim mensaje As String = Me.Message

      If Me.InnerException IsNot Nothing Then
         mensaje += "<br>"
         mensaje += "Sub-Error:"
         mensaje += Me.InnerException.Message
      End If

      EniacMail.EnviarMail(mensaje)

   End Sub


   Public Overrides ReadOnly Property Message As String
      Get
         Return MyBase.Message
      End Get
   End Property

End Class
