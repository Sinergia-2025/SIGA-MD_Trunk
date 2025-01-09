#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class CRMEnvioMasivoNovedadesMails

   Public Function GetEnvioMasivoNovedadesMail(idAplicacion As String,
                                               categorias As Entidades.Categoria(),
                                               idZonaGeografica As String,
                                               idCliente As Long,
                                               desdeNombreCliente As String,
                                               configMail As String,
                                               IdCobrador As Integer) As DataTable

      Return New Reglas.CRMEnvioMasivoNovedadesMails().GetEnvioMasivoNovedadesMail(idAplicacion, categorias, idZonaGeografica,
                                                                                   idCliente, desdeNombreCliente, configMail,
                                                                                   IdCobrador)
   End Function

   Public Sub EnviarMails(asuntoMail As String, cuerpoMail As String, bcc As String,
                          dtEnvioMail As DataTable, dtNovedades As DataTable, adjuntos As String(),
                          dicArchivosNovedades As Dictionary(Of Long, String),
                          tspBarra As ToolStripProgressBar, tslTexto As ToolStripStatusLabel,
                          envioCtaCteCliente As Boolean)

      If String.IsNullOrEmpty(asuntoMail) Then Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      If cuerpoMail Is Nothing OrElse cuerpoMail.Length = 0 Then Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")

      Dim intCantidad As Integer = 0
      Dim rEnvioMail As Reglas.CRMEnvioMasivoNovedadesMails = New Reglas.CRMEnvioMasivoNovedadesMails()

      Dim clientesEnvio As List(Of Eniac.Reglas.CRMEnvioMasivoNovedadesMails.ClienteEnvioMail) = rEnvioMail.ArmaClientesEnvio(dtEnvioMail, intCantidad, bcc)

      Dim destinaBCC As List(Of String) = New List(Of String)()
      If Not String.IsNullOrWhiteSpace(bcc) Then
         For Each correo As String In bcc.Split(";"c)
            If Not String.IsNullOrWhiteSpace(correo) Then
               destinaBCC.Add(correo)
            End If
         Next
      End If

      'Trabajo el cuerpo para que respete el formato
      Dim stbCuerpo As StringBuilder = New StringBuilder()
      FormatearCuerpoMensaje(stbCuerpo, cuerpoMail)
      '--------------------------------------------

      tspBarra.Maximum = clientesEnvio.Count * 2
      tspBarra.Value = 0

      'Al 12/02/2015 Son 2 reglas, 150 maximo por hora y 15 maximo por minuto.
      'Se baja a 120 por hora y 12 por minutos.

      '30 Segundos = 30 x 1000 = 120 Correos por Horas
      Dim intTiempoEntreCorreos As Integer = 30000
      If intCantidad <= 120 Then
         '5 Segundos 
         intTiempoEntreCorreos = 5000
      End If

      Dim intActual As Integer = 0
      Dim TiempoEstimado As Integer = intCantidad * 1000 + intCantidad * intTiempoEntreCorreos
      Dim HoraInicio As DateTime = DateTime.Now()
      Dim oVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
      Dim oCtaCtes As Eniac.Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
      Dim dtCtaCte As DataTable
      Dim comprobante As Eniac.Entidades.Venta
      Dim saldoTotal As Decimal
      Dim oCtaCte As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
      Dim saldocliente As Decimal

      'recorro todos los clientes seleccionados en la grilla
      For Each clienteEnvio As Eniac.Reglas.CRMEnvioMasivoNovedadesMails.ClienteEnvioMail In clientesEnvio
         'For Each dr As UltraGridRow In Me.ugDetalle.Rows

         intActual += 1
         'La barra queda un poco corta para tanto texto
         tslTexto.Text = String.Format("Actual: {0}/{1}. Cliente: ({2}){3}. Correos: {4}. Tiempo estimado: {5}. Fin: {6}.",
                                       intActual, clientesEnvio.Count, clienteEnvio.CodigoCliente, clienteEnvio.NombreCliente,
                                       intCantidad.ToString(), TimeSpan.FromMilliseconds(TiempoEstimado).ToString(),
                                       HoraInicio.Add(TimeSpan.FromMilliseconds(TiempoEstimado)).ToString("HH:mm:ss"))
         Application.DoEvents()

         'inicializo el saldo por cliente
         saldoTotal = 0

         tslTexto.Text = tslTexto.Text + String.Format(" Enviando Correo a: {0}", clienteEnvio.CorreElectronico)
         tspBarra.PerformStep()
         Application.DoEvents()

         Dim destina As List(Of String) = New List(Of String)()

         'cargo los destinatarios
         For Each correo As String In clienteEnvio.CorreElectronico.Split(";"c)
            If Not String.IsNullOrWhiteSpace(correo) Then
               destina.Add(correo)
            End If
         Next

         Try
            saldocliente = oCtaCte.GetSaldoCliente(actual.Sucursal.Id, clienteEnvio.IdCliente)
         Catch ex As Exception
            saldocliente = 0
         End Try

         Dim cuerpoMailTemp As String = stbCuerpo.ToString()
         If cuerpoMailTemp.Contains("@@saldocliente@@") Then
            cuerpoMailTemp = cuerpoMailTemp.Replace("@@saldocliente@@", saldocliente.ToString("N2"))
         End If

         If cuerpoMailTemp.Contains("{0}") Then
            cuerpoMailTemp = String.Format(cuerpoMailTemp, clienteEnvio.NombreCliente)
         End If

         'creo el mail y lo envio
         Dim ms As Eniac.Win.MailSSS = New Eniac.Win.MailSSS()
         ms.CrearMail("TO", destina.ToArray(), asuntoMail, cuerpoMailTemp, Nothing, destinaBCC.ToArray())
         For Each comprMail As Reglas.CRMEnvioMasivoNovedadesMails.ComprobanteEnvioMail In clienteEnvio.Comprobantes
            ms.AgregarAdjunto(comprMail.NombreArchivoDestino)
         Next

         For Each adjunto As String In adjuntos
            If Not String.IsNullOrWhiteSpace(adjunto) Then
               ms.AgregarAdjunto(adjunto)
            End If
         Next

         If dicArchivosNovedades.ContainsKey(clienteEnvio.IdCliente) AndAlso IO.File.Exists(dicArchivosNovedades(clienteEnvio.IdCliente)) Then
            ms.AgregarAdjunto(dicArchivosNovedades(clienteEnvio.IdCliente))
         End If

         ms.EnviarMail()

         tspBarra.PerformStep()
         tslTexto.Text = String.Format("({0}) ", Math.Round(intTiempoEntreCorreos / 1000, 0)) + tslTexto.Text
         Application.DoEvents()

         System.Threading.Thread.Sleep(intTiempoEntreCorreos)
      Next

   End Sub

   Private Sub FormatearCuerpoMensaje(stbCuerpo As StringBuilder, cuerpoMail As String)
      stbCuerpo.Append("<!DOCTYPE HTML>")
      stbCuerpo.Append("<html>")
      stbCuerpo.Append("<head>")
      stbCuerpo.Append("</head>")
      stbCuerpo.Append("<body>")
      stbCuerpo.Append(cuerpoMail)
      stbCuerpo.Append("</body>")
      stbCuerpo.Append("</html>")
   End Sub

End Class