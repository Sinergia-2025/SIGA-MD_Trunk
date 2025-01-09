Imports System.Net.Mail
Imports System.Drawing

Public Class EniacMail

   Public Shared Sub EnviarMail(mensaje As String)

#If Not Debug Then

      Dim pantalla As String = "C:\Eniac\Error.jpg"

      ' Capturar toda la pantalla

      Dim flag As New Bitmap(200, 200)
      Dim gr As Graphics = Graphics.FromImage(flag)
      ' Tamaño de lo que queremos copiar
      ' En este caso el tamaño de la ventana principal
      Dim fSize As Size = My.Computer.Screen.Bounds.Size
      ' Creamos el bitmap con el área que vamos a capturar
      Dim bm As New Bitmap(fSize.Width, fSize.Height, gr)
      ' Un objeto Graphics a partir del bitmap
      Dim gr2 As Graphics = Graphics.FromImage(bm)
      ' Copiar todo el área de la pantalla
      gr2.CopyFromScreen(0, 0, 0, 0, fSize)

      ' Asignamos la imagen al PictureBox
      bm.Save(pantalla, System.Drawing.Imaging.ImageFormat.Jpeg)


      Dim _mensaje As MailMessage

      _mensaje = New MailMessage()

      With _mensaje
         .Attachments.Add(New Attachment(pantalla))

         .From = New MailAddress("soporte@sinergiass.com.ar")

         .To.Add("soporte@sinergiass.com.ar")

         .Subject = "Error - " + Eniac.Entidades.Usuario.Actual.Empresa + " - " + Eniac.Entidades.Usuario.Actual.Nombre + " - " + My.Computer.Name
         .IsBodyHtml = True
         .BodyEncoding = System.Text.ASCIIEncoding.ASCII
         Dim cuerpo As String = ArmarMail(mensaje)
         .AlternateViews.Add(AlternateView.CreateAlternateViewFromString(cuerpo, New System.Net.Mime.ContentType("text/html")))
         .Body = cuerpo
         .Priority = MailPriority.Normal
      End With

      Dim smt As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
      smt.Port = 26
      smt.Host = "mail.sinergiass.com.ar"
      smt.Credentials = New System.Net.NetworkCredential("soporte@sinergiass.com.ar", "Bandera98")

      Try
         smt.Send(_mensaje)
      Catch ex As Exception
         Dim men As String = ex.Message
      Finally
         _mensaje.Dispose()
      End Try

#End If

   End Sub

   Private Shared Function ArmarMail(mensaje As String) As String
      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
      stb.Append("<!DOCTYPE HTML>")
      stb.Append("<html>")
      stb.Append("<head>")
      stb.Append("</head>")
      stb.Append("<body>")

      stb.Append("<br>")
      stb.Append("Error:")
      stb.Append(mensaje)

      stb.Append("<br>")
      stb.Append("SO:")
      stb.Append(My.Computer.Info.OSFullName)

      stb.Append("<br>")
      stb.Append("Version SO:")
      stb.Append(My.Computer.Info.OSVersion)

      stb.Append("<br>")
      stb.Append("Memoria: ")
      stb.Append(My.Computer.Info.TotalPhysicalMemory.ToString())

      stb.Append("<br>")
      stb.Append("Separador decimal: ")
      stb.Append(My.Application.Culture.NumberFormat.CurrencyDecimalSeparator.ToString())

      stb.Append("<br>")
      stb.Append("Formato de Fecha: ")
      stb.Append(My.Application.Culture.DateTimeFormat.ShortDatePattern.ToString())

      stb.Append("<br>")
      stb.Append("Directorio actual: ")
      stb.Append(My.Computer.FileSystem.CurrentDirectory)

      stb.Append("<br>")
      stb.Append("<br>")
      stb.Append("<br>")
      stb.Append("Pila: ")
      stb.Append(My.Application.Info.StackTrace)

      stb.Append("</body>")
      stb.Append("</html>")

      Return stb.ToString()
   End Function

End Class
