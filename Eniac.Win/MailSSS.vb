Imports System.Net.Mail
Public Class MailSSS

   Private _mailConfig As Entidades.MailConfig
   Private _mailPriority As MailPriority
   Private _mensaje As MailMessage

   Public Sub New()
      If actual.MailConfig.UtilizaComoPredeterminado Then
         'aca utilizo el mail del usuario logueado si tiene el seteo
         Me._mailConfig = actual.MailConfig
      Else
         'en este caso utilizo el mail generico que tiene cargada la empresa
         Me._mailConfig = New Reglas.Parametros().GetMailGenerico()
      End If

      Me._mailPriority = MailPriority.Normal
      Me._mensaje = New MailMessage()
   End Sub

   Public Sub CrearMail(destinatarios() As String, asunto As String, cuerpo As String,
                        destinatariosCC() As String, destinatariosBCC() As String)
      CrearMail("TO", destinatarios, asunto, cuerpo, destinatariosCC, destinatariosBCC)
   End Sub

   Public Sub CrearMail(TipoEnvio As String,
                        destinatarios() As String,
                        asunto As String,
                        cuerpo As String,
                        destinatariosCC() As String,
                        destinatariosBCC() As String)
      With Me._mensaje
         .From = New MailAddress(Me._mailConfig.Direccion)
         For Each destinatario As String In destinatarios
            If Not destinatario = "" Then
               Select Case TipoEnvio.ToUpper
                  Case "TO"
                     .To.Add(destinatario)
                  Case "CC"
                     .CC.Add(destinatario)
                  Case "BCC"
                     .Bcc.Add(destinatario)
               End Select
            End If
         Next

         If destinatariosCC IsNot Nothing Then
            For Each cc As String In destinatariosCC
               If Not cc = "" Then
                  .CC.Add(cc)
               End If
            Next
         End If
         If destinatariosBCC IsNot Nothing Then
            For Each bcc As String In destinatariosBCC
               If Not bcc = "" Then
                  .Bcc.Add(bcc)
               End If
            Next
         End If


         .Subject = asunto

         '.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(cuerpo, New System.Net.Mime.ContentType("text/html")))

         'agregado Vanina
         'obtengo del html la url de la imagen
         Dim cadenaTexto As String = cuerpo
         Dim urlImg As String = ""

         If cadenaTexto.IndexOf(" src=""") > -1 Then

            urlImg = cadenaTexto.Substring(cadenaTexto.IndexOf(" src=""") + 6, cadenaTexto.Length - cadenaTexto.IndexOf(" src=""") - 6)
            Dim idxImagenHasta = urlImg.IndexOf(""">")

            If idxImagenHasta < 0 Then idxImagenHasta = urlImg.IndexOf("""/>")

            'idxImagenHasta = Math.Min(idxImagenHasta, urlImg.IndexOf("""/>"))

            If idxImagenHasta > 0 Then
               urlImg = Left(urlImg, idxImagenHasta)
               cuerpo = cuerpo.Replace(urlImg, "cid:imagenid")
            End If
         End If

         ' Creamos la vista para clientes que
         ' sólo pueden acceder a texto plano...
         Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString("", Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Plain)

         ' Ahora creamos la vista para clientes que
         ' pueden mostrar contenido HTML...
         Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(cuerpo, New System.Net.Mime.ContentType("text/html"))

         If Not String.IsNullOrWhiteSpace(urlImg) Then
            ' Creamos el recurso a incrustar. Observad
            ' que el ID que le asignamos (arbitrario) está
            ' referenciado desde el código HTML como origen
            ' de la imagen 
            Dim imagenid As LinkedResource = New LinkedResource(urlImg, System.Net.Mime.MediaTypeNames.Image.Jpeg)
            imagenid.ContentId = "imagenid"
            ' Lo incrustamos en la vista HTML...

            htmlView.LinkedResources.Add(imagenid)
         End If

         ' Por último, vinculamos ambas vistas al mensaje...
         .AlternateViews.Add(plainView)
         .AlternateViews.Add(htmlView)

         .IsBodyHtml = True
         .BodyEncoding = Encoding.UTF8
         .Body = cuerpo
         .Priority = Me._mailPriority
      End With
   End Sub

   Public Overloads Sub AgregarAdjunto(adjunto As Attachment)
      Me._mensaje.Attachments.Add(adjunto)
   End Sub

   Public Overloads Sub AgregarAdjunto(archivo As String)
      Dim adj = New Attachment(archivo)
      Me._mensaje.Attachments.Add(adj)
   End Sub

   Public Sub EnviarMail()

      Dim smt = New SmtpClient()

      smt.Port = Me._mailConfig.PuertoSalida
      smt.Host = Me._mailConfig.ServidorSMTP
      smt.EnableSsl = Me._mailConfig.RequiereSSL
      smt.UseDefaultCredentials = Not Me._mailConfig.RequiereAutenticacion
      smt.Credentials = New System.Net.NetworkCredential(Me._mailConfig.UsuarioMail, Me._mailConfig.Clave)

      Try
         smt.Send(Me._mensaje)
      Catch ex As Exception
         Throw
      Finally
         Me._mensaje.Dispose()
      End Try

   End Sub

End Class