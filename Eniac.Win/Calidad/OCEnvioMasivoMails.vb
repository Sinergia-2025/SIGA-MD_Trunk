Imports Eniac.Reglas.OCEnvioMasivoMails
Imports System.Text.RegularExpressions
Public Class OCEnvioMasivoMails
   Inherits Reglas.Base

   Public Function GetEnvioMasivoMail(sucursales As Entidades.Sucursal(),
                                      fechaDesde As Date?, fechaHasta As Date?, modoFechas As String,
                                      idCategoria As Integer?, idZonaGeografica As String,
                                      idCliente As Long?, desdeNombreCliente As String,
                                      configMail As String, idCobrador As Integer,
                                      correoEnviado As Entidades.Publicos.SiNoTodos,
                                      listaComprobantes As Entidades.TipoComprobante(),
                                      operador As Entidades.Publicos.OperadoresRelacionales?,
                                      saldo As Decimal?) As DataTable
      Return New Reglas.VentasEnvioMasivoMails().GetEnvioMasivoMail(sucursales,
                                                                    fechaDesde, fechaHasta, modoFechas,
                                                                    idCategoria, idZonaGeografica,
                                                                    idCliente, desdeNombreCliente,
                                                                    configMail, idCobrador,
                                                                    correoEnviado,
                                                                    listaComprobantes,
                                                                    operador,
                                                                    saldo)
   End Function

   Public Sub EnviarMails(asuntoMail As String, cuerpoMail As String, bcc As String,
                          dtEnvioMail As DataTable, adjuntos As String(),
                          tspBarra As ToolStripProgressBar, tslTexto As ToolStripStatusLabel, Idfuncion As String,
                          labErrores As Label)

      ' If String.IsNullOrEmpty(asuntoMail) Then Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      '  If cuerpoMail Is Nothing OrElse cuerpoMail.Length = 0 Then Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")

      Dim intCantidad As Integer = 0
      Dim IntCantidadErrores As Integer = 0

      Dim rEnvioMail As Reglas.OCEnvioMasivoMails = New Reglas.OCEnvioMasivoMails()
      Dim ProveedoresEnvio As List(Of OCEnvioMail) = rEnvioMail.ArmaProveedoresEnvio(dtEnvioMail, intCantidad, bcc)

      Dim ePDF = New ExportarPDF()

      Dim pdf As String = Entidades.Publicos.DriverBase

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

      tspBarra.Maximum = ProveedoresEnvio.Count * 2
      tspBarra.Value = 0

      Dim mailConfig As Entidades.MailConfig = New Reglas.Parametros().GetMailGenerico()
      Dim intTiempoEntreCorreos As Integer = mailConfig.CalcularTiempoEntreCorreos(intCantidad)


      Dim intActual As Integer = 0
      Dim TiempoEstimado As Integer = intCantidad * 1000 + intCantidad * intTiempoEntreCorreos
      Dim HoraInicio As DateTime = DateTime.Now()
      Dim oPedidosProveedores As Eniac.Reglas.PedidosProveedores = New Eniac.Reglas.PedidosProveedores()
      Dim oCtaCtes As Eniac.Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
      Dim dtCtaCte As DataTable
      Dim comprobante As Eniac.Entidades.PedidoProveedor
      Dim saldoTotal As Decimal
      Dim oCtaCte As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
      Dim saldocliente As Decimal

      'recorro todos los clientes seleccionados en la grilla
      For Each ProveedorEnvio As OCEnvioMail In ProveedoresEnvio
         'For Each dr As UltraGridRow In Me.ugDetalle.Rows

         intActual += 1
         'La barra queda un poco corta para tanto texto
         tslTexto.Text = String.Format("Actual: {0}/{1}. Cliente: ({2}){3}. Correos: {4}. Tiempo estimado: {5}. Fin: {6}.",
                                       intActual, ProveedoresEnvio.Count, ProveedorEnvio.CodigoProveedor, ProveedorEnvio.NombreProveedor,
                                       intCantidad.ToString(), TimeSpan.FromMilliseconds(TiempoEstimado).ToString(),
                                       HoraInicio.Add(TimeSpan.FromMilliseconds(TiempoEstimado)).ToString("HH:mm:ss"))
         Application.DoEvents()

         'inicializo el saldo por cliente
         saldoTotal = 0

         'por cada cliente se le envian todos los comprobantes
         For Each comproMail As ComprobanteEnvioMail In ProveedorEnvio.Comprobantes
            comprobante = oPedidosProveedores.GetUno(comproMail.IdSucursal,
                                         comproMail.IdTipoComprobante, comproMail.LetraComprobante,
                                         comproMail.CentroEmisor, comproMail.NumeroComprobante)

            comproMail.NombreArchivoDestino = String.Format("{0}Eniac\Correos\{1}_{2}_{3}_{4:0000}_{5:00000000}.pdf",
                                                            pdf,
                                                            Reglas.Publicos.CuitEmpresa,
                                                            comprobante.TipoComprobante.DescripcionAbrev, comprobante.LetraComprobante,
                                                            comprobante.CentroEmisor, comprobante.NumeroPedido)
            'sumo el total de deuda que tiene cada cliente para luego comparar con la cta. cte. y si envio o no el informe adjunto
            saldoTotal += comprobante.ImporteTotal
            ePDF.ExportarPedidosProveedores(comprobante, comproMail.NombreArchivoDestino)
            asuntoMail = String.Format("Orden de Compra: {0}-{1:00000000}", comprobante.TipoComprobante.DescripcionAbrev, comprobante.NumeroPedido)

         Next

         tslTexto.Text = tslTexto.Text + String.Format(" Enviando Correo a: {0}", ProveedorEnvio.CorreElectronico)
         tspBarra.PerformStep()
         Application.DoEvents()

         Dim destina As List(Of String) = New List(Of String)()

         'cargo los destinatarios
         For Each correo As String In ProveedorEnvio.CorreElectronico.Split(";"c)
            If Not String.IsNullOrWhiteSpace(correo) Then
               destina.Add(correo)
            End If
         Next

         Try
            saldocliente = oCtaCte.GetSaldoCliente({actual.Sucursal}, ProveedorEnvio.IdProveedor,
                                                   fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:="TODOS",
                                                   grabaLibro:=Nothing, comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty,
                                                   excluirPreComprobantes:=False, IdCama:=0, IdEmbarcacion:=0)
         Catch ex As Exception
            saldocliente = 0
         End Try

         Dim cuerpoMailTemp As String = stbCuerpo.ToString()

         If cuerpoMailTemp.Contains("@@saldocliente@@") Then
            cuerpoMailTemp = cuerpoMailTemp.Replace("@@saldocliente@@", saldocliente.ToString("N2"))
         End If

         If cuerpoMailTemp.Contains("@@NombreCliente@@") Then
            cuerpoMailTemp = cuerpoMailTemp.Replace("@@NombreCliente@@", ProveedorEnvio.NombreProveedor)
         End If
         If cuerpoMailTemp.Contains("@@NombreFantasia@@") Then
            cuerpoMailTemp = cuerpoMailTemp.Replace("@@NombreFantasia@@", ProveedorEnvio.NombreDeFantasia)
         End If
         If cuerpoMailTemp.Contains("@@SiMovilUsuario@@") Then
            cuerpoMailTemp = cuerpoMailTemp.Replace("@@SiMovilUsuario@@", ProveedorEnvio.SiMovilUsuario)
         End If
         If cuerpoMailTemp.Contains("@@SiMovilClave@@") Then
            cuerpoMailTemp = cuerpoMailTemp.Replace("@@SiMovilClave@@", ProveedorEnvio.SiMovilClave)
         End If

         If cuerpoMailTemp.Contains("{0}") Then
            cuerpoMailTemp = String.Format(cuerpoMailTemp, ProveedorEnvio.NombreProveedor)
         End If

         Try

            'creo el mail y lo envio
            Dim ms As Eniac.Win.MailSSS = New Eniac.Win.MailSSS()
            ms.CrearMail("TO", destina.ToArray(), asuntoMail, cuerpoMailTemp, Nothing, destinaBCC.ToArray())
            For Each comprMail As ComprobanteEnvioMail In ProveedorEnvio.Comprobantes
               ms.AgregarAdjunto(comprMail.NombreArchivoDestino)
            Next

            For Each adjunto As String In adjuntos
               If Not String.IsNullOrWhiteSpace(adjunto) Then
                  ms.AgregarAdjunto(adjunto)
               End If
            Next

            ''Si selecciono que se envie con Cta. Cte. se lo adjunto
            ''para el cliente actual tengo que ir a buscar la cuenta corriente
            'If envioCtaCteCliente AndAlso reporteCtaCte.HasValue AndAlso saldocliente <> saldoTotal Then

            '   Dim NombreReporte As String = String.Empty
            '   Dim com As CtasCtesClientesComunes = New CtasCtesClientesComunes()
            '   Dim dt As DataTable = Nothing
            '   Dim dispo As String = Entidades.Publicos.DriverBase
            '   Dim SaldoActual As Decimal = 0
            '   Dim SaldoInicial As Decimal = 0
            '   Dim SaldoFinal As Decimal = 0

            '   Select Case reporteCtaCte.Value
            '      Case Entidades.Publicos.InformesCtaCte.CTACTE
            '         'Informe Cta Cte. 
            '         'controlo el saldo del cliente
            '         dtCtaCte = oCtaCtes.GetCtaCte(clienteEnvio.IdSucursalDefecto,
            '                                       Nothing, Nothing, 0, clienteEnvio.IdCliente, Nothing, "SOLOSALDO",
            '                                       "", 0, "TODOS", Nothing, "NO", "NO", "SI", "", "ACTUAL", "ACTUAL", "NO",
            '                                       Nothing, agruparIdClienteCtaCte:=True, ruta:=0, dia:=Nothing, 0)

            '         NombreReporte = "Informe_CtaCte_"
            '         dt = com.GetDataTableParaClientes(dtCtaCte, "SOLOSALDO")
            '      Case Entidades.Publicos.InformesCtaCte.CTACTEDH
            '         'Informe Cta Cte Debe Haber.
            '         Dim Sucursal As Entidades.Sucursal = New Reglas.Sucursales().GetUna(clienteEnvio.IdSucursalDefecto, False)
            '         SaldoActual = oCtaCte.GetSaldoCliente({Sucursal},
            '                                   clienteEnvio.IdCliente,
            '                                   Nothing, False, "TODOS", Nothing, Nothing, "", False)
            '         dt = oCtaCte.GetPorCliente({Sucursal},
            '                                clienteEnvio.IdCliente,
            '                                Nothing, Nothing, Nothing,
            '                                "TODOS", "", "SI", 1, Entidades.Moneda_TipoConversion.Actual,
            '                                 0, False)

            '         dt.Columns.Add("Ver", GetType(String))
            '         dt.Columns.Add("Debe", GetType(Decimal))
            '         dt.Columns.Add("Haber", GetType(Decimal))

            '         For Each dr As DataRow In dt.Rows
            '            dr("Ver") = "..."
            '            Dim importeTotal As Decimal = If(IsNumeric(dr("ImporteTotal")), Decimal.Parse(dr("ImporteTotal").ToString()), 0)
            '            If importeTotal > 0 Then
            '               dr("Debe") = importeTotal
            '            Else
            '               dr("Haber") = importeTotal * -1
            '            End If
            '            SaldoFinal = SaldoFinal + importeTotal
            '            dr("Saldo") = SaldoFinal
            '         Next
            '         NombreReporte = "Informe_CtaCte_DH"
            '         '  dt = com.GetDataTableParaClientes(dtCtaCte, "SOLOSALDO")
            '      Case Entidades.Publicos.InformesCtaCte.CTACTEDET
            '         'Informe Cta Cte Detallado Cliente. 

            '      Case Entidades.Publicos.InformesCtaCte.CTACTEDETDH
            '         'Informe Cta Cte Detallado cliente Debe-Haber. 

            '   End Select

            '   Dim nombreArchivoDestino As String = String.Format("{0}Eniac\Correos\{1}_{2}_{3:00000000}.pdf",
            '                                                  dispo,
            '                                                  NombreReporte,
            '                                                  clienteEnvio.NombreCliente,
            '                                                  clienteEnvio.IdCliente)
            '   If reporteCtaCte = Entidades.Publicos.InformesCtaCte.CTACTE Then

            '      com.ImprimirInformeCtaCteClientes(dt, clienteEnvio.NombreCliente, False, True, nombreArchivoDestino, True, "", False, "")

            '   ElseIf reporteCtaCte = Entidades.Publicos.InformesCtaCte.CTACTEDH Then

            '      com.ImprimirInformeCtaCteClientesDH(dt, clienteEnvio.NombreCliente, False, True,
            '                                          nombreArchivoDestino, True, "", False, "",
            '                                          SaldoInicial, SaldoActual, SaldoFinal)
            '   End If

            '   ms.AgregarAdjunto(nombreArchivoDestino)

            'End If

            ms.EnviarMail()

            '# Marco el correo como enviado y lo destildo
            If ProveedorEnvio.RowOrigen.Table.Columns.Contains("Estado") Then
               '# A cada linea de comprobante del cliente, le cambio el estado a Enviando
               For Each row As DataRow In ProveedorEnvio.RowOrigen.Table.Select(String.Format("IdProveedor = {0} AND Envio = True", ProveedorEnvio.IdProveedor.ToString()))
                  row("Estado") = "Enviando"
               Next

            End If


            Dim EnvioOC As Entidades.EnvioOC
            Dim rEnvioOC As Reglas.EnviosOC = New Reglas.EnviosOC()
            For Each comproMail As ComprobanteEnvioMail In ProveedorEnvio.Comprobantes

               comprobante = oPedidosProveedores.GetUno(comproMail.IdSucursal,
                                         comproMail.IdTipoComprobante, comproMail.LetraComprobante,
                                         comproMail.CentroEmisor, comproMail.NumeroComprobante)

               EnvioOC = New Entidades.EnvioOC
               With EnvioOC
                  .IdSucursal = comproMail.IdSucursal
                  .TipoComprobante = New Reglas.TiposComprobantes().GetUno(comproMail.IdTipoComprobante)
                  .Letra = comproMail.LetraComprobante
                  .CentroEmisor = comproMail.CentroEmisor
                  .NumeroPedido = comproMail.NumeroComprobante
                  .FechaEnvio = Date.Now
                  .IdUsuario = actual.Nombre
                  .FechaReprogramacion = comprobante.FechaReprogramacion

               End With
               rEnvioOC.Insertar(EnvioOC, "M", Idfuncion)

            Next



            '# Marco el correo como enviado y lo destildo
            If ProveedorEnvio.RowOrigen.Table.Columns.Contains("Estado") Then
               '# A cada linea de comprobante del cliente, le cambio el estado a Enviando
               For Each row As DataRow In ProveedorEnvio.RowOrigen.Table.Select(String.Format("IdCliente = {0} AND Envio = True", ProveedorEnvio.IdProveedor.ToString()))
                  row("Estado") = "Enviado"
                  row("Envio") = False
               Next
            End If
         Catch ex As Exception
            ' grabo log de error

            IntCantidadErrores += 1

            Dim EnvioOCError As Entidades.EnvioOCError
            Dim rEnvioOCError As Reglas.EnviosOCErrores = New Reglas.EnviosOCErrores()
            For Each comproMail As ComprobanteEnvioMail In ProveedorEnvio.Comprobantes
               EnvioOCError = New Entidades.EnvioOCError
               With EnvioOCError
                  .IdSucursal = comproMail.IdSucursal
                  .TipoComprobante = New Reglas.TiposComprobantes().GetUno(comproMail.IdTipoComprobante)
                  .Letra = comproMail.LetraComprobante
                  .CentroEmisor = comproMail.CentroEmisor
                  .NumeroPedido = comproMail.NumeroComprobante
                  .FechaEnvioError = Date.Now
                  .DescripcionError = ex.Message.ToString().Replace("'", "")
                  .Usuario = actual.Nombre
               End With
               rEnvioOCError.Insertar(EnvioOCError)
            Next
         End Try

         tspBarra.PerformStep()
         tslTexto.Text = String.Format("({0}) ", Math.Round(intTiempoEntreCorreos / 1000, 0)) + tslTexto.Text
         Application.DoEvents()

         System.Threading.Thread.Sleep(intTiempoEntreCorreos)

      Next

      labErrores.Text = "Cantidad de Mails con error: " & IntCantidadErrores

   End Sub

   Public Sub EnviarMailPrueba(asuntoMail As String, cuerpoMail As String, bcc As String,
                         dtEnvioMail As DataTable, adjuntos As String(),
                         tspBarra As ToolStripProgressBar, tslTexto As ToolStripStatusLabel,
                         envioCtaCteCliente As Boolean, reporteCtaCte As Entidades.Publicos.InformesCtaCte?)

      If String.IsNullOrEmpty(asuntoMail) Then Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      If cuerpoMail Is Nothing OrElse cuerpoMail.Length = 0 Then Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")

      Dim intCantidad As Integer = 0
      Dim rEnvioMail As Reglas.OCEnvioMasivoMails = New Reglas.OCEnvioMasivoMails()
      Dim ProveedoresEnvio As List(Of OCEnvioMail) = rEnvioMail.ArmaProveedoresEnvio(dtEnvioMail, intCantidad, bcc)

      Dim ePDF As Eniac.Win.ExportarPDF = New Eniac.Win.ExportarPDF()

      Dim pdf As String = Entidades.Publicos.DriverBase

      Dim destinaBCC As List(Of String) = New List(Of String)()
      If Not String.IsNullOrWhiteSpace(bcc) Then
         For Each correo As String In bcc.Split(";"c)
            If Not String.IsNullOrWhiteSpace(correo) Then
               'destinaBCC.Add(correo)
            End If
         Next
      End If

      'Trabajo el cuerpo para que respete el formato
      Dim stbCuerpo As StringBuilder = New StringBuilder()
      FormatearCuerpoMensaje(stbCuerpo, cuerpoMail)
      '--------------------------------------------

      tspBarra.Maximum = ProveedoresEnvio.Count * 2
      tspBarra.Value = 0

      Dim mailConfig As Entidades.MailConfig = New Reglas.Parametros().GetMailGenerico()
      Dim intTiempoEntreCorreos As Integer = mailConfig.CalcularTiempoEntreCorreos(intCantidad)


      Dim intActual As Integer = 0
      Dim TiempoEstimado As Integer = intCantidad * 1000 + intCantidad * intTiempoEntreCorreos
      Dim HoraInicio As DateTime = DateTime.Now()
      Dim oVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
      Dim oCtaCtes As Eniac.Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
      Dim dtCtaCte As DataTable
      Dim comprobante As Eniac.Entidades.Venta
      Dim oCtaCte As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()

      Dim saldoTotal As Decimal

      Dim saldocliente As Decimal

      'recorro todos los clientes seleccionados en la grilla
      For Each ProveedorEnvio As OCEnvioMail In ProveedoresEnvio
         'For Each dr As UltraGridRow In Me.ugDetalle.Rows

         intActual += 1
         'La barra queda un poco corta para tanto texto
         tslTexto.Text = String.Format("Actual: {0}/{1}. Cliente: ({2}){3}. Correos: {4}. Tiempo estimado: {5}. Fin: {6}.",
                                       intActual, ProveedoresEnvio.Count, ProveedorEnvio.CodigoProveedor, ProveedorEnvio.NombreProveedor,
                                       intCantidad.ToString(), TimeSpan.FromMilliseconds(TiempoEstimado).ToString(),
                                       HoraInicio.Add(TimeSpan.FromMilliseconds(TiempoEstimado)).ToString("HH:mm:ss"))
         Application.DoEvents()

         'inicializo el saldo por cliente
         saldoTotal = 0

         Application.DoEvents()


         Dim CorreoPrueba As String = String.Empty

         If Not String.IsNullOrWhiteSpace(bcc) Then
            CorreoPrueba = bcc
         Else
            CorreoPrueba = "Ingrese un correo de prueba"
         End If

         Dim PantCorreo As CorreoPrueba = New CorreoPrueba(CorreoPrueba)
         PantCorreo.ShowDialog()

         If PantCorreo.DialogResult = Windows.Forms.DialogResult.OK Then
            If IsValidEmail(PantCorreo.txtCorreoDePrueba.Text) Then
               tslTexto.Text = tslTexto.Text + String.Format(" Enviando Correo a: {0}", PantCorreo.txtCorreoDePrueba.Text)
               tspBarra.PerformStep()
               Application.DoEvents()



               'por cada cliente se le envian todos los comprobantes
               For Each comproMail As ComprobanteEnvioMail In ProveedorEnvio.Comprobantes
                  comprobante = oVentas.GetUna(comproMail.IdSucursal,
                                               comproMail.IdTipoComprobante, comproMail.LetraComprobante,
                                               comproMail.CentroEmisor, comproMail.NumeroComprobante)

                  'comproMail.NombreArchivoDestino = String.Format("{0}Eniac\Correos\{1}_{2}_{3}_{4:0000}_{5:00000000}.pdf",
                  '                                                pdf,
                  '                                                Reglas.Publicos.CuitEmpresa,
                  '                                                comprobante.TipoComprobante.DescripcionAbrev, comprobante.LetraComprobante,
                  '                                                comprobante.CentroEmisor, comprobante.NumeroComprobante)
                  '-- REQ-34676.- ----------------------------------------------------------------------------------------------
                  Dim nombreArchivo = New Reglas.Ventas().FormatoNombreArchivoExportacion(comprobante)
                  comproMail.NombreArchivoDestino = String.Format("{0}Eniac\Correos\{1}",
                                                                  pdf,
                                                                  nombreArchivo)
                  '--------------------------------------------------------------------------------------------------------------

                  'sumo el total de deuda que tiene cada cliente para luego comparar con la cta. cte. y si envio o no el informe adjunto
                  saldoTotal += comprobante.ImporteTotal
                  ePDF.Exportar(comprobante, comproMail.NombreArchivoDestino)
               Next

               tslTexto.Text = tslTexto.Text + String.Format(" Enviando Correo a: {0}", ProveedorEnvio.CorreElectronico)
               tspBarra.PerformStep()
               Application.DoEvents()

               Dim destina As List(Of String) = New List(Of String)()

               'cargo los destinatarios
               For Each correo As String In PantCorreo.txtCorreoDePrueba.Text.Split(";"c)
                  If Not String.IsNullOrWhiteSpace(correo) Then
                     destina.Add(correo)
                  End If
               Next

               Try
                  saldocliente = oCtaCte.GetSaldoCliente({actual.Sucursal}, ProveedorEnvio.IdProveedor,
                                                         fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:="TODOS",
                                                         grabaLibro:=Nothing, comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty,
                                                         excluirPreComprobantes:=False, IdCama:=0, IdEmbarcacion:=0)
               Catch ex As Exception
                  saldocliente = 0
               End Try



               Dim cuerpoMailTemp As String = stbCuerpo.ToString()
               If cuerpoMailTemp.Contains("@@saldocliente@@") Then
                  cuerpoMailTemp = cuerpoMailTemp.Replace("@@saldocliente@@", saldocliente.ToString("N2"))
               End If

               If cuerpoMailTemp.Contains("@@NombreFantasia@@") Then
                  cuerpoMailTemp = cuerpoMailTemp.Replace("@@NombreFantasia@@", ProveedorEnvio.NombreDeFantasia)
               End If
               If cuerpoMailTemp.Contains("@@SiMovilUsuario@@") Then
                  cuerpoMailTemp = cuerpoMailTemp.Replace("@@SiMovilUsuario@@", ProveedorEnvio.SiMovilUsuario)
               End If
               If cuerpoMailTemp.Contains("@@SiMovilClave@@") Then
                  cuerpoMailTemp = cuerpoMailTemp.Replace("@@SiMovilClave@@", ProveedorEnvio.SiMovilClave)
               End If


               If cuerpoMailTemp.Contains("{0}") Then
                  cuerpoMailTemp = String.Format(cuerpoMailTemp, ProveedorEnvio.NombreProveedor)
               End If

               'creo el mail y lo envio
               Dim ms As Eniac.Win.MailSSS = New Eniac.Win.MailSSS()
               ms.CrearMail("TO", destina.ToArray(), asuntoMail, cuerpoMailTemp, Nothing, destinaBCC.ToArray())
               For Each comprMail As ComprobanteEnvioMail In ProveedorEnvio.Comprobantes
                  ms.AgregarAdjunto(comprMail.NombreArchivoDestino)
               Next

               For Each adjunto As String In adjuntos
                  If Not String.IsNullOrWhiteSpace(adjunto) Then
                     ms.AgregarAdjunto(adjunto)
                  End If
               Next

               'Si selecciono que se envie con Cta. Cte. se lo adjunto
               'para el cliente actual tengo que ir a buscar la cuenta corriente
               If envioCtaCteCliente AndAlso reporteCtaCte.HasValue AndAlso saldocliente <> saldoTotal Then

                  Dim NombreReporte As String = String.Empty
                  Dim com As CtasCtesClientesComunes = New CtasCtesClientesComunes()
                  Dim dt As DataTable = Nothing
                  Dim dispo As String = Entidades.Publicos.DriverBase
                  Dim SaldoActual As Decimal = 0
                  Dim SaldoInicial As Decimal = 0
                  Dim SaldoFinal As Decimal = 0

                  If reporteCtaCte.Value = Entidades.Publicos.InformesCtaCte.CTACTE Then
                     'Informe Cta Cte. 
                     'controlo el saldo del cliente
                     dtCtaCte = oCtaCtes.GetCtaCte(ProveedorEnvio.IdSucursalDefecto,
                                                   Nothing, Nothing, 0, ProveedorEnvio.IdProveedor, Nothing, "SOLOSALDO", "", 0, "TODOS", Nothing, "NO", "NO", "SI", "", "ACTUAL", "ACTUAL", "NO", Nothing, agruparIdClienteCtaCte:=True, ruta:=0, dia:=Nothing, 0)

                     NombreReporte = "Informe_CtaCte_"
                     dt = com.GetDataTableParaClientes(dtCtaCte, "SOLOSALDO")

                  ElseIf reporteCtaCte.Value = Entidades.Publicos.InformesCtaCte.CTACTEDH Then
                     'Informe Cta Cte Debe Haber.

                     Dim Sucursal As Entidades.Sucursal = New Reglas.Sucursales().GetUna(ProveedorEnvio.IdSucursalDefecto, False)

                     SaldoActual = oCtaCte.GetSaldoCliente({Sucursal},
                                                  ProveedorEnvio.IdProveedor,
                                                  Nothing, False, "TODOS", Nothing, Nothing, "", False, 0, 0)

                     'If Me.chbFechas.Checked Then
                     '   Desde = Me.dtpDesde.Value
                     '   Hasta = Me.dtpHasta.Value
                     'SaldoInicial = oCtaCte.GetSaldoCliente({Sucursal},
                     '                             clienteEnvio.IdCliente, Nothing, False, "TODOS", Nothing, Nothing, "")

                     dt = oCtaCte.GetPorCliente({Sucursal},
                                               ProveedorEnvio.IdProveedor,
                                               Nothing,
                                               Nothing, Nothing,
                                               "TODOS", "",
                                               "SI", 1, Entidades.Moneda_TipoConversion.Actual,
                                                0,
                                                False)

                     dt.Columns.Add("Ver", GetType(String))
                     dt.Columns.Add("Debe", GetType(Decimal))
                     dt.Columns.Add("Haber", GetType(Decimal))

                     For Each dr As DataRow In dt.Rows
                        dr("Ver") = "..."
                        Dim importeTotal As Decimal = If(IsNumeric(dr("ImporteTotal")), Decimal.Parse(dr("ImporteTotal").ToString()), 0)
                        If importeTotal > 0 Then
                           dr("Debe") = importeTotal
                        Else
                           dr("Haber") = importeTotal * -1
                        End If

                        SaldoFinal = SaldoFinal + importeTotal

                        dr("Saldo") = SaldoFinal
                     Next

                     NombreReporte = "Informe_CtaCte_DH"

                     '  dt = com.GetDataTableParaClientes(dtCtaCte, "SOLOSALDO")

                  End If

                  Dim nombreArchivoDestino As String = String.Format("{0}Eniac\Correos\{1}_{2}_{3:00000000}.pdf",
                                                                 dispo,
                                                                 NombreReporte,
                                                                 ProveedorEnvio.NombreProveedor,
                                                                 ProveedorEnvio.IdProveedor)
                  If reporteCtaCte = Entidades.Publicos.InformesCtaCte.CTACTE Then

                     com.ImprimirInformeCtaCteClientes(dt, ProveedorEnvio.NombreProveedor, False, True, nombreArchivoDestino, True, "", False, "")

                  ElseIf reporteCtaCte = Entidades.Publicos.InformesCtaCte.CTACTEDH Then

                     com.ImprimirInformeCtaCteClientesDH(dt, ProveedorEnvio.NombreProveedor, False, True,
                                                         nombreArchivoDestino, True, "", False, "",
                                                         SaldoInicial, SaldoActual, SaldoFinal)
                  End If

                  ms.AgregarAdjunto(nombreArchivoDestino)

               End If

               ms.EnviarMail()

               tspBarra.PerformStep()
               tslTexto.Text = String.Format("({0}) ", Math.Round(intTiempoEntreCorreos / 1000, 0)) + tslTexto.Text
               Application.DoEvents()

               System.Threading.Thread.Sleep(intTiempoEntreCorreos)
            Else
               Throw New Exception("ATENCION: Ingrese un correo valido")
            End If
         End If
      Next

   End Sub
   Private Function IsValidEmail(ByVal email As String) As Boolean
      If email = String.Empty Then Return False
      ' Compruebo si el formato de la dirección es correcto.
      Dim re As Regex = New Regex("^[\w._%-]+@[\w.-]+\.[a-zA-Z]{2,4}$")
      Dim m As Match = re.Match(email)
      Return (m.Captures.Count <> 0)
   End Function

   Private Sub FormatearCuerpoMensaje(stbCuerpo As StringBuilder, cuerpoMail As String)
      'stbCuerpo.Append("<!DOCTYPE HTML>")
      stbCuerpo.Append("<html>")
      stbCuerpo.Append("<head>")
      stbCuerpo.Append("</head>")
      stbCuerpo.Append("<body>")
      stbCuerpo.Append(cuerpoMail)
      stbCuerpo.Append("</body>")
      stbCuerpo.Append("</html>")
   End Sub

   ''' <summary>
   ''' Para celdas de grillas Infragistics solamente.
   ''' </summary>
   ''' <param name="c">Recibe la celda a pintar</param>
   ''' <remarks></remarks>
   Public Sub PintarCeldas(c As UltraGridCell)

      Dim estado As String = c.Value.ToString()
      If estado = "Enviado" Then
         c.Appearance.BackColor = Color.LightGreen
         c.ActiveAppearance.BackColor = Color.LightGreen
      End If
      If estado = "Pendiente" Then
         c.Appearance.BackColor = Color.Yellow
         c.ActiveAppearance.BackColor = Color.Yellow
      End If
      If estado = "Enviando" Then
         c.Appearance.BackColor = Color.Cyan
         c.ActiveAppearance.BackColor = Color.Cyan
      End If
      If estado = "No Enviado" Then
         c.Appearance.BackColor = Color.Red
         c.ActiveAppearance.BackColor = Color.Red
      End If

      c.Appearance.ForeColor = Drawing.Color.Black
      c.ActiveAppearance.ForeColor = Drawing.Color.Black
   End Sub

End Class