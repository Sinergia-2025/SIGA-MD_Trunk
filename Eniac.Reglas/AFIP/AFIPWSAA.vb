Imports System.Net
Imports System.Security
Imports System.Security.Cryptography.Pkcs
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml


Public Class AFIPWSAA
   Inherits Base

   Private _verboseMode As Boolean = True
   Private Shared _globalUniqueID As Long = 0               ' OJO! NO ES THREAD-SAFE
   Public XmlLoginTicketRequest As XmlDocument = Nothing
   Public XmlLoginTicketResponse As XmlDocument = Nothing
   Public Service As String                                 ' Identificacion del WSN para el cual se solicita el TA
   Public UniqueId As UInt32                                ' Entero de 32 bits sin signo que identifica el requerimiento
   Public GenerationTime As DateTime                        ' Momento en que fue generado el requerimiento
   Public ExpirationTime As DateTime                        ' Momento en el que exoira la solicitud
   Public Sign As String                                    ' Firma de seguridad recibida en la respuesta
   Public Token As String                                   ' Token de seguridad recibido en la respuesta
   Private _urlWSAA As String
   Private _claveTA As String

   Public Sub New(accesoDatos As Eniac.Datos.DataAccess)
      da = accesoDatos
      Dim par As Reglas.Parametros = New Reglas.Parametros(Me.da)
      _urlWSAA = par.GetValorPD(Entidades.Parametro.Parametros.URLWSAA.ToString(), String.Empty)
      _claveTA = par.GetValorPD(Entidades.Parametro.Parametros.CLAVETICKETACCESOFE.ToString(), String.Empty)
   End Sub

   ''' <summary>
   ''' Controla si existe el certificado y sino lo crea.
   ''' </summary>
   ''' <param name="servicioNegocio">Es el nombre del servicio, por ejemplo wsfe, wsbfe, etc.</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   ''' 
   Public Function CrearCertificado(servicioNegocio As String) As Boolean

      If ElTAestaOK(servicioNegocio) Then
         'el ticket actual esta correcto no hago nada
         Return False
      End If

      Dim strUrlWsaaWsdl As String = Me._urlWSAA
      Dim strPasswordSecureString As New SecureString
      Dim strProxy As String = Nothing
      Dim strProxyUser As String = Nothing
      Dim strProxyPassword As String = ""
      Dim blnVerboseMode As Boolean = True

      ' Argumentos OK, entonces procesar normalmente...

      Dim strTicketRespuesta As String

      'como no esta bien el ticket de acceso genero uno nuevo
      For Each character As Char In Me._claveTA.ToCharArray
         strPasswordSecureString.AppendChar(character)
      Next
      strPasswordSecureString.MakeReadOnly()

      Try
         strTicketRespuesta = ObtenerLoginTicketResponse(servicioNegocio,
                                                            strUrlWsaaWsdl,
                                                            strPasswordSecureString,
                                                            strProxy,
                                                            strProxyUser,
                                                            strProxyPassword,
                                                            blnVerboseMode)

      Catch excepcionAlObtenerTicket As Exception
         Throw
      End Try

      Return True
   End Function

   Private Function GetLTR(argServicio As String) As String
      Dim stb = New StringBuilder()
      Dim par = New Reglas.Parametros()
      With stb
         .Append("<?xml version=""1.0"" encoding=""UTF8""?><loginTicketRequest version=""1.0""><header>")
         .AppendFormat("<source>{0}</source>", par.GetValorPD(Entidades.Parametro.Parametros.FACTELECTSOURCE, String.Empty))
         .AppendFormat("<destination>{0}</destination>", par.GetValorPD(Entidades.Parametro.Parametros.FACTELECTDESTINATION, String.Empty))
         .AppendFormat("<uniqueId>{0}</uniqueId>", par.GetValorPD(Entidades.Parametro.Parametros.FACTELECUNIQUEID, String.Empty))
         .AppendFormat("<generationTime>{0}-03:00</generationTime>", DateTime.Parse(par.GetValorPD(Entidades.Parametro.Parametros.FACTELECTGENERATIONTIME, String.Empty), New Globalization.CultureInfo("es-AR")).ToString("s"))
         .AppendFormat("<expirationTime>{0}-03:00</expirationTime>", DateTime.Parse(par.GetValorPD(Entidades.Parametro.Parametros.FACTELECTEXPIRATIONTIME, String.Empty), New Globalization.CultureInfo("es-AR")).ToString("s"))
         .AppendFormat("</header><service>{0}</service></loginTicketRequest>", argServicio)
      End With
      Return stb.ToString()
   End Function

   Private Function ObtenerLoginTicketResponse(argServicio As String,
                                               argUrlWsaa As String,
                                               argPassword As SecureString,
                                               argProxy As String,
                                               argProxyUser As String,
                                               argProxyPassword As String,
                                               argVerbose As Boolean) As String

      _verboseMode = argVerbose
      CertificadosX509Lib.VerboseMode = argVerbose

      Dim cmsFirmadoBase64 As String
      Dim loginTicketResponse As String
      Dim xmlNodoUniqueId As XmlNode
      Dim xmlNodoGenerationTime As XmlNode
      Dim xmlNodoExpirationTime As XmlNode
      Dim xmlNodoService As XmlNode

      ' PASO 1: Genero el Login Ticket Request
      Try
         _globalUniqueID += 1

         XmlLoginTicketRequest = New XmlDocument()
         XmlLoginTicketRequest.LoadXml(GetLTR(argServicio))

         xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId")
         xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime")
         xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime")
         xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service")

         xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s")
         xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s")
         xmlNodoUniqueId.InnerText = _globalUniqueID.ToString()
         xmlNodoService.InnerText = argServicio
         Service = argServicio

         If _verboseMode Then
            Console.WriteLine(XmlLoginTicketRequest.OuterXml)
         End If

      Catch excepcionAlGenerarLoginTicketRequest As Exception
         Throw New Exception("***Error GENERANDO el LoginTicketRequest : " + excepcionAlGenerarLoginTicketRequest.Message + excepcionAlGenerarLoginTicketRequest.StackTrace)
      End Try

      ' PASO 2: Firmo el Login Ticket Request
      Try
         Dim certFirmante As X509Certificate2 = CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(argPassword)

         If Me._verboseMode Then
            Console.WriteLine("***Firmando: ")
            Console.WriteLine(XmlLoginTicketRequest.OuterXml)
         End If

         ' Convierto el login ticket request a bytes, para firmar
         Dim EncodedMsg As Encoding = Encoding.UTF8
         Dim msgBytes As Byte() = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml)

         ' Firmo el msg y paso a Base64
         Dim encodedSignedCms As Byte() = CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante)
         cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms)

      Catch excepcionAlFirmar As Exception
         Throw New Exception("***Error FIRMANDO el LoginTicketRequest : " + excepcionAlFirmar.Message)
      End Try

      ' PASO 3: Invoco al WSAA para obtener el Login Ticket Response
      Try
         If _verboseMode Then
            Console.WriteLine("***Llamando al WSAA en URL: {0}", argUrlWsaa)
            Console.WriteLine("***Argumento en el request:")
            Console.WriteLine(cmsFirmadoBase64)
         End If

         Dim servicioWsaa As New WSAA.LoginCMSService()
         servicioWsaa.Url = argUrlWsaa
         If argProxy IsNot Nothing Then
            servicioWsaa.Proxy = New WebProxy(argProxy, True)
            If argProxyUser IsNot Nothing Then
               Dim Credentials As New NetworkCredential(argProxyUser, argProxyPassword)
               servicioWsaa.Proxy.Credentials = Credentials
            End If
         End If
         loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64)

         If _verboseMode Then
            Console.WriteLine("***LoguinTicketResponse: ")
            Console.WriteLine(loginTicketResponse)
         End If

      Catch excepcionAlInvocarWsaa As Exception
         Throw New Exception("***Error INVOCANDO al servicio WSAA : " + excepcionAlInvocarWsaa.Message)
      End Try


      ' PASO 4: Analizo el Login Ticket Response recibido del WSAA
      Try
         XmlLoginTicketResponse = New XmlDocument()
         XmlLoginTicketResponse.LoadXml(loginTicketResponse)
         Dim sql As SqlServer.ParametrosArchivos = New SqlServer.ParametrosArchivos(Me.da)

         Select Case argServicio
            Case "wsfex"
               sql.ActualizaTA(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOFEX.ToString(), XmlLoginTicketResponse.InnerXml)
            Case "wsfe"
               sql.ActualizaTA(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOFE.ToString(), XmlLoginTicketResponse.InnerXml)
            Case "wsbfe"
               sql.ActualizaTA(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOBFE.ToString(), XmlLoginTicketResponse.InnerXml)
            Case "ws_sr_constancia_inscripcion"
               sql.ActualizaTA(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOPN4.ToString(), XmlLoginTicketResponse.InnerXml)
         End Select

         UniqueId = UInt32.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText)
         GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText)
         ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText)
         Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText
         Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText
      Catch excepcionAlAnalizarLoginTicketResponse As Exception
         Throw New Exception("***Error ANALIZANDO el LoginTicketResponse : " + excepcionAlAnalizarLoginTicketResponse.Message)
      End Try

      Return loginTicketResponse

   End Function

   Private Function ElTAestaOK(argServicio As String) As Boolean
      XmlLoginTicketResponse = New XmlDocument()

      'controlo que el parametro del ticket de acceso este cargado sino lo cargo la primera vez, si se puede.
      Try
         Dim sql As SqlServer.ParametrosArchivos = New SqlServer.ParametrosArchivos(Me.da)
         Select Case argServicio
            Case "wsfex"
               XmlLoginTicketResponse.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOFEX.ToString()))
            Case "wsfe"
               XmlLoginTicketResponse.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOFE.ToString()))
            Case "wsbfe"
               XmlLoginTicketResponse.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOBFE.ToString()))
            Case "ws_sr_constancia_inscripcion"
               XmlLoginTicketResponse.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOPN4.ToString()))
         End Select

      Catch ex As Exception
         'retorno false porque si es la primera vez y da error lo hago cargar por la fuerza
         Return False
      End Try
      Me.ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText)

      If Me.ExpirationTime < DateTime.Now Then
         Return False
      End If

      Return True
   End Function

End Class



''' <summary>
''' Libreria de utilidades para manejo de certificados
''' </summary>
''' <remarks></remarks>
Public Class CertificadosX509Lib

   Public Shared VerboseMode As Boolean = False

   ''' <summary>
   ''' Firma mensaje
   ''' </summary>
   ''' <param name="argBytesMsg">Bytes del mensaje</param>
   ''' <param name="argCertFirmante">Certificado usado para firmar</param>
   ''' <returns>Bytes del mensaje firmado</returns>
   ''' <remarks></remarks>
   Public Shared Function FirmaBytesMensaje(argBytesMsg As Byte(),
                              argCertFirmante As X509Certificate2) As Byte()
      Try
         ' Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms)
         Dim infoContenido As New ContentInfo(argBytesMsg)
         Dim cmsFirmado As New SignedCms(infoContenido)

         ' Creo objeto CmsSigner que tiene las caracteristicas del firmante
         Dim cmsFirmante As New CmsSigner(argCertFirmante)
         cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly

         If VerboseMode Then
            Console.WriteLine("***Firmando bytes del mensaje...")
         End If
         ' Firmo el mensaje PKCS #7
         cmsFirmado.ComputeSignature(cmsFirmante)

         If VerboseMode Then
            Console.WriteLine("***OK mensaje firmado")
         End If

         ' Encodeo el mensaje PKCS #7.
         Return cmsFirmado.Encode()
      Catch excepcionAlFirmar As Exception
         Throw New Exception("***Error al firmar: " & excepcionAlFirmar.Message)
         Return Nothing
      End Try
   End Function

   ''' <summary>
   ''' Lee certificado 
   ''' </summary>
   ''' <returns>Un objeto certificado X509</returns>
   ''' <remarks></remarks>
   Public Shared Function ObtieneCertificadoDesdeArchivo(argPassword As SecureString) As X509Certificate2
      Dim objCert As New X509Certificate2
      Try
         Dim argArchivo As Byte()
         Dim par As ParametrosImagenes = New ParametrosImagenes()
         argArchivo = par.GetValor2(Entidades.ParametroArchivo.Parametros.CERTIFICADOFE.ToString())
         If argPassword.IsReadOnly Then
            objCert.Import(argArchivo, argPassword, X509KeyStorageFlags.PersistKeySet)
         Else
            objCert.Import(argArchivo)
         End If
         Return objCert
      Catch excepcionAlImportarCertificado As Exception
         Throw New Exception(excepcionAlImportarCertificado.Message & " " & excepcionAlImportarCertificado.StackTrace)
         Return Nothing
      End Try
   End Function

End Class