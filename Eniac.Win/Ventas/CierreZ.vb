Option Explicit On
Option Strict On

Public Class CierreZ

#Region "Campos"

   Private _ArchivoEntrada As String
   Private _ArchivoSalida As String

   Dim Estado As EstadoImpresion = New EstadoImpresion()

   Dim oImpresora As Entidades.Impresora

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         oImpresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, True)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnProceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceder.Click

      Try

         If MessageBox.Show("Confirma realizar el Cierra Z?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If oImpresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.BATCH Then 'BATCH
               Me.HacerCierreZ()
            Else
               Me.HacerCierreZDLLs()
            End If

         Else
            MessageBox.Show("Usted ha cancelado el Cierre 'Z' !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If


      Catch ex As Exception

         ShowError(ex, True)

      Finally

         Me.Cursor = Cursors.Default

      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub HacerCierreZ()

      Try

         If oImpresora.Marca = "HASAR" Then

            If Not My.Computer.FileSystem.FileExists(Entidades.Publicos.CarpetaEniac + "SPOOLER.EXE") Then
               MsgBox("ATENCION: NO se encuentra el archivo " + Entidades.Publicos.CarpetaEniac + "SPOOLER.EXE" & Chr(13) & Chr(13) & "NO podrá imprimir con la FISCAL, por favor comuniquese con SISTEMAS.", MsgBoxStyle.Exclamation)
               Exit Sub
            End If

            Dim objHasar As New FiscalHASAR(oImpresora.Puerto, oImpresora.Velocidad, Entidades.Publicos.CarpetaEniac)

            objHasar.Orden_Cierre_Diario_Z()

            MessageBox.Show("Cierre Z realizado EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Me.Close()

         Else

            If Not My.Computer.FileSystem.FileExists(Entidades.Publicos.CarpetaEniac + "CIERREZ.EXE") Then
               MsgBox("ATENCION: NO se encuentra el archivo " + Entidades.Publicos.CarpetaEniac + "CIERREZ.EXE" & Chr(13) & Chr(13) & "NO podrá realizar el Cierre Z, por favor contáctese con SISTEMAS.", MsgBoxStyle.Exclamation)
               Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            'Me._ArchivoEntrada = My.Application.Info.DirectoryPath & "\Envio.txt"
            'Me._ArchivoSalida = My.Application.Info.DirectoryPath & "\Respuesta.txt"
            Me._ArchivoEntrada = Entidades.Publicos.CarpetaEniac + "CierreZ.IN"
            Me._ArchivoSalida = Entidades.Publicos.CarpetaEniac + "CierreZ.OUT"

            Dim strRespuesta As String

            strRespuesta = Abrir()

            If strRespuesta <> "OK" Then
               MessageBox.Show(strRespuesta, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
               Exit Sub
            End If


            Dim strEjecuta As String, ResulShell As Integer, ioArchivoLee As System.IO.StreamReader, Linea As String

            If System.IO.File.Exists(Me._ArchivoSalida) Then
               System.IO.File.Delete(Me._ArchivoSalida)
            End If

            If System.IO.File.Exists(Me._ArchivoEntrada) Then
               System.IO.File.Delete(Me._ArchivoEntrada)
            End If

            'Linea = "@CIERREZ" & Chr(10)

            'Dim ioArchivoGraba As System.IO.StreamWriter

            'ioArchivoGraba = My.Computer.FileSystem.OpenTextFileWriter(Me._ArchivoEntrada, False, System.Text.Encoding.ASCII)
            'ioArchivoGraba.WriteLine(Linea)
            'ioArchivoGraba.Close()

            strEjecuta = Entidades.Publicos.CarpetaEniac + "CIERREZ.EXE /" + Entidades.Publicos.DriverBase.Replace("\", "") & oImpresora.Puerto & " /O:" & Me._ArchivoSalida

            '32 Segundos de espera. Si ponemos -1 no devuelve el control hasta que finaliza. Es conveniente como tambien un riesgo
            ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, 32000)

            If System.IO.File.Exists(Me._ArchivoSalida) Then

               ioArchivoLee = My.Computer.FileSystem.OpenTextFileReader(Me._ArchivoSalida, System.Text.Encoding.ASCII)

               If ioArchivoLee.EndOfStream = True Then
                  ioArchivoLee.Close()

                  MessageBox.Show("ERROR!!: problema en la COMUNICACION con la IMPRESORA FISCAL, sin Respuesta luego de indicar el CIERRE.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)

                  Exit Sub
               Else
                  Linea = ioArchivoLee.ReadLine
               End If

               ioArchivoLee.Close()

               '@CIERREZ|ERROR|ATENCION NO HAY COMPROBANTES PROCESADOS DESDE EL ULTIMO CIERRE
               '@CIERREZ|ERROR||

               'Al usar el CIERREZ.EXE devuelve @CIERREZ|ERROR|| pero hace el cierre

               If Linea.Substring(9, 5) = "ERROR" And Linea.Substring(14, 2) <> "||" And Linea <> "@CIERREZ|ERROR|ATENCION NO HAY COMPROBANTES PROCESADOS DESDE EL ULTIMO CIERRE" Then
                  MessageBox.Show(Linea.Substring(15), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
               Else
                  MessageBox.Show("Cierre Z realizado EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Me.Close()
               End If
            Else

               MessageBox.Show("ATENCION!!! No hubo respuesta de la Impresora Fiscal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

               Me.Close()

            End If


         End If



      Catch ex As Exception
         Throw

      Finally
         Me.Cursor = Cursors.Default

      End Try

   End Sub

   Private Function Abrir() As String

      Dim ResulShell As Integer, Linea As String, I As Integer, strEjecuta As String

      Dim ioArchivoLee As System.IO.StreamReader

      Do While I < 3

         If System.IO.File.Exists(Me._ArchivoSalida) Then
            System.IO.File.Delete(Me._ArchivoSalida)
         End If

         If System.IO.File.Exists(Me._ArchivoEntrada) Then
            System.IO.File.Delete(Me._ArchivoEntrada)
         End If


         Linea = "@estado" & Chr(10)

         Dim ioArchivoGraba As System.IO.StreamWriter

         ioArchivoGraba = My.Computer.FileSystem.OpenTextFileWriter(Me._ArchivoEntrada, False, System.Text.Encoding.ASCII)
         ioArchivoGraba.WriteLine(Linea)
         ioArchivoGraba.Close()


         strEjecuta = Entidades.Publicos.CarpetaEniac + "PFBATCH.EXE /NOECHO /" + Entidades.Publicos.DriverBase.Replace("\", "") & Me.oImpresora.Puerto & " /I:" & Me._ArchivoEntrada & " /O:" & Me._ArchivoSalida


         '32 Segundos de espera. Si ponemos -1 no devuelve el control hasta que finaliza. Es conveniente como tambien un riesgo
         ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, 32000)
         'ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, 10000)


         If System.IO.File.Exists(Me._ArchivoSalida) Then

            ioArchivoLee = My.Computer.FileSystem.OpenTextFileReader(Me._ArchivoSalida, System.Text.Encoding.ASCII)

            If ioArchivoLee.EndOfStream = True Then
               ioArchivoLee.Close()
               Return "Problema en Comunicacion con Impresor Fiscal, NO existio respuesta al consultar el ESTADO."
            Else
               Linea = ioArchivoLee.ReadLine
            End If

            ioArchivoLee.Close()

            '         |@ESTADO            |ERROR DE COMUNICACION
            If Mid(Linea, 31, 5) = "ERROR" Then

               Dim CodErr As String

               CodErr = Trim(Mid(Linea, 37, 4))

               Return TablaErrores(CodErr)

            Else

               Return "OK"

            End If
         Else
            MessageBox.Show("El archivo " & Me._ArchivoSalida & " no fue encontrado.", "Abrir", MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

         I = I + 1
      Loop

      Return "No pudo abrir el controlador fiscal"

   End Function

   Private Function TablaErrores(ByVal pCodigo As String) As String

      Select Case pCodigo
         Case "1"
            Return "IMPRESORA OCUPADA"
         Case "2"
            Return "IMPRESORA SELECCIONADA"
         Case "4"
            Return "ERROR/FALLA"
         Case "8"
            Return "FUERA DE LINEA"
         Case "10"
            Return "FALTA PAPEL DE AUTIDORIA"
         Case "20"
            Return "FALTA PAPEL DE TICKET"
         Case "40"
            Return "BUFFER LLENO"
         Case "80"
            Return "BUFFER VACIO"
         Case "400"
            Return "IMPRESORA SIN PAPEL"
         Case "8000"
            Return "ERROR EN IMPRESORA"
         Case "8008"
            Return "ERROR / FUERA DE LINEA"
         Case "8080"
            Return "ERROR / BUFFER VACIO"
         Case "8010"
            Return "ERROR / SIN PAPEL"
         Case "0080"
            Return "ERRON EN EL CONTROLADOR"
         Case "C0B0"
            Return "IMPRESORA SIN PAPEL"
         Case Else
            Return "ERROR CODIGO: " & pCodigo
      End Select

   End Function

   Private Sub HacerCierreZOCX()

      Me.Cursor = Cursors.WaitCursor

      Dim bAnswer As Boolean
      Dim AnswerFields As String

      Dim arrRespuesta(19) As String

      arrRespuesta(1) = "Estado de la Impresora: "                                     ' (datos hex. ASCII)
      arrRespuesta(2) = "Estado Fiscal: "                                              ' <HHHH> (datos hex. ASCII)
      arrRespuesta(3) = "Número de cierre Z: "                                         ' <nnnnn>
      arrRespuesta(4) = "Cant. de Documentos Fiscales Cancelados: "                   ' <nnnnn>
      arrRespuesta(5) = "Cant. de documentos No Fiscales Homologados (D.N.F.H): "     ' <nnnnn>
      arrRespuesta(6) = "Cant. de Documentos No Fiscales no homologados (D.N.F.): "   ' <nnnnn>
      arrRespuesta(7) = "Cant. de Comprobantes Fiscales Tique/Factura/Tique-Factura B,C emitidos: "    ' <nnnnn>
      arrRespuesta(8) = "Cant. de Comprobantes de Tique-Factura ‘A’ y Facturas ‘A’ emitidos: "                ' <nnnnn>
      arrRespuesta(9) = "Número de último comprobante de Tiques/Tique-Factura/Facturas 'B’ o ‘C’ emitidos: "  ' <nnnnnnnn>
      arrRespuesta(10) = "Monto total Facturado: "       ' <nnnnnnnnnnnn.nn>
      arrRespuesta(11) = "Monto total de IVA Cobrado: "  ' <nnnnnnnnnnnn.nn>
      arrRespuesta(12) = "Importe Total de las percepciones en Facturas o Tique-Facturas: "  ' <nnnnnnnnnnnn.nn>
      arrRespuesta(13) = "Número de último comprobante Tique-Factura/Factura ‘A’ emitido: "  '<nnnnnnnn>
      arrRespuesta(14) = "Número de último comprobante Tique-N.Créd./N.Créd. 'A’ emitido :" ' <nnnnnnnn>
      arrRespuesta(15) = "Número de último comprobante Tique-N.Créd./N.Créd. 'B’ o ‘C’ emitido: "  ' <nnnnnnnn>
      arrRespuesta(16) = "Número del último Remito emitido: "     ' <nnnnnnnn>
      arrRespuesta(17) = "Importe Total de Notas de Crédito emitidas: "       ' <nnnnnnnnnnnn.nn>
      arrRespuesta(18) = "Importe Total de IVA de Notas de Crédito: "         ' <nnnnnnnnnnnn.nn>
      arrRespuesta(19) = "Importe Total de las Percepciones en Notas de Crédito o Tiques-N.Créd.: " ' <nnnnnnnnnnnn.nn>

      bAnswer = True

      If oImpresora.EsProtocoloExtendido Then

         Dim sCmd As String
         Dim sCmdExt As String

         sCmd = Chr(&H8S) & Chr(&H1S)
         'If bAnswer Then bAnswer = Me.EpsonFP.AddDataField(sCmd)

         sCmdExt = Chr(&HCS) & Chr(&H0S)
         'If bAnswer Then bAnswer = Me.EpsonFP.AddDataField(sCmdExt)

         'If bAnswer Then bAnswer = Me.EpsonFP.SendCommand

         Call FPDelay()

      Else

         AnswerFields = ""

         'bAnswer = Me.EpsonFP.AddDataField(Chr(&H39S)) 'Comando Cierre de Jornada
         'bAnswer = Me.EpsonFP.AddDataField(Chr(&H5AS)) 'Cierre diario (Z)
         'bAnswer = Me.EpsonFP.AddDataField(Chr(&H50S)) 'Impreso (P)

         'bAnswer = Me.EpsonFP.SendCommand()

         Call FPDelay()

      End If

      'AnswerFields = arrRespuesta(1) & String.Format(Hex(Me.EpsonFP.PrinterStatus), "0000") & vbCrLf

      'AnswerFields = AnswerFields & arrRespuesta(2) & String.Format(Hex(Me.EpsonFP.FiscalStatus), "0000") & vbCrLf

      'If (Strings.Format(Hex(Me.EpsonFP.FiscalStatus), "0000") = "0600") Then
      '    For i = 3 To 19
      '        AnswerFields = AnswerFields & vbCrLf & arrRespuesta(i) & Me.EpsonFP.GetExtraField(i)
      '        Call FPDelay()
      '    Next
      'End If

      'Me.EpsonFP.ClosePort()


      Me.Cursor = Cursors.Arrow

      ' MessageBox.Show(AnswerFields, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.Close()

   End Sub

   Private Sub FPDelay()

      If oImpresora.EsProtocoloExtendido Then
         Dim d1 As DateTime = DateTime.Now
         Dim d2 As DateTime = DateTime.Now
         Dim ts As TimeSpan = Nothing

         'Do While Me.EpsonFP.CtlState = EpsonFPHostControlX.TxFiscalState.EFP_S_Busy
         '    d2 = DateTime.Now
         '    ts = d2.Subtract(d1)
         '    If ts.Milliseconds > 400 Then
         '        Exit Do
         '    End If
         'Loop
      Else
         'While (Me.EpsonFP.CtlState = EpsonFPHostControlX.TxFiscalState.EFP_S_Busy)
         '    System.Windows.Forms.Application.DoEvents()
         'End While
      End If

   End Sub

   Private Sub HacerCierreZDLLs()

      Me.Cursor = Cursors.WaitCursor
      Dim mensaje As String

      'Metodo nuevo de impresion
      If oImpresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2 Then
         Dim impf As ImpresionFiscalV2 = New ImpresionFiscalV2(oImpresora)
         mensaje = impf.CierreZ()
      Else
         Dim impf As ImpresionFiscal = New ImpresionFiscal(oImpresora.Modelo, oImpresora.Puerto)
         mensaje = impf.CierreZ()
      End If

      MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Me.Close()

   End Sub

#End Region

End Class
