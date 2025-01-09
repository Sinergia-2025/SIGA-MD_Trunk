Public Class CierreX

#Region "Campos"

   Private _ArchivoEntrada As String
   Private _ArchivoSalida As String

   Dim Estado As EstadoImpresion = New EstadoImpresion()
   Dim oImpresora As Entidades.Impresora

#End Region

#Region "Metodos"
   Private Sub HacerCierreX()

      Try

         Me.Cursor = Cursors.WaitCursor

         'Me._ArchivoEntrada = My.Application.Info.DirectoryPath & "\Envio.txt"
         'Me._ArchivoSalida = My.Application.Info.DirectoryPath & "\Respuesta.txt"
         Me._ArchivoEntrada = Entidades.Publicos.DriverBase + "Eniac\CierreX.IN"
         Me._ArchivoSalida = Entidades.Publicos.DriverBase + "Eniac\CierreX.OUT"

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


         Linea = ""
         'Select Case True

         '   Case optCierreX.Checked
         Linea = "@CIERREX" & Chr(10)

         '   Case optAuditoriaPorFecha.Checked
         '      Linea = "@AUDITORIAF" & Chr(10)

         '   Case optAuditoriaPorNroCierre.Checked
         '      Linea = "@AUDITORIAZ" & Chr(10)

         'End Select

         Dim ioArchivoGraba As System.IO.StreamWriter

         ioArchivoGraba = My.Computer.FileSystem.OpenTextFileWriter(Me._ArchivoEntrada, False, System.Text.Encoding.ASCII)
         ioArchivoGraba.WriteLine(Linea)
         ioArchivoGraba.Close()

         strEjecuta = Entidades.Publicos.DriverBase + "Eniac\PFBATCH.EXE /NOECHO /" & Entidades.Publicos.DriverBase.Replace("\", "") & oImpresora.Puerto & " /I:" & Me._ArchivoEntrada & " /O:" & Me._ArchivoSalida

         '32 Segundos de espera. Si ponemos -1 no devuelve el control hasta que finaliza. Es conveniente como tambien un riesgo
         ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, 32000)

         If System.IO.File.Exists(Me._ArchivoSalida) Then

            ioArchivoLee = My.Computer.FileSystem.OpenTextFileReader(Me._ArchivoSalida, System.Text.Encoding.ASCII)

            If ioArchivoLee.EndOfStream = True Then
               ioArchivoLee.Close()

               MessageBox.Show("ERROR!!: problema en la COMUNICACION con la IMPRESORA FISCAL, sin Respuesta luego de indicar el INFORME.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)

               Exit Sub
            Else
               Linea = ioArchivoLee.ReadLine
            End If

            ioArchivoLee.Close()

            '@CIERREX|ERROR|ATENCION NO HAY COMPROBANTES PROCESADOS DESDE EL ULTIMO CIERRE
            'If Linea.Substring(9, 5) = "ERROR" Then
            If Linea.Contains("ERROR") Then

               MessageBox.Show(Linea, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)

            Else

               MessageBox.Show("Informe realizado EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.Close()

            End If
         Else

            MessageBox.Show("ATENCION!!! No hubo respuesta de la Impresora Fiscal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Me.Close()

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


         strEjecuta = Entidades.Publicos.DriverBase + "Eniac\PFBATCH.EXE /NOECHO /" & Entidades.Publicos.DriverBase.Replace("\", "") & Me.oImpresora.Puerto & " /I:" & Me._ArchivoEntrada & " /O:" & Me._ArchivoSalida


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

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnProceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceder.Click

      Try

         If MessageBox.Show("Confirma realizar el Cierra X ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


            oImpresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, True)


            'If Strings.InStr(Publicos.ModelosImpresoraFiscalBatch, oImpresora.Modelo, CompareMethod.Text) > 0 Then
            If oImpresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.BATCH Then

               Me.HacerCierreX()

            Else

               Me.HacerCierreXDLLs()

            End If

         Else
            MessageBox.Show("Usted ha cancelado el Cierre 'X' !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If


      Catch ex As Exception

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally

         Me.Cursor = Cursors.Default

      End Try

   End Sub

   Private Sub HacerCierreXDLLs()

      Me.Cursor = Cursors.WaitCursor
      Dim mensaje As String

      If oImpresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2 Then
         'Metodo nuevo de impresion
         Dim impf As ImpresionFiscalV2 = New ImpresionFiscalV2(oImpresora)
         mensaje = impf.CierreX()
      Else
         'Metodo nuevo de impresion
         Dim impf As ImpresionFiscal = New ImpresionFiscal(oImpresora.Modelo, oImpresora.Puerto)
         mensaje = impf.CierreX()
      End If

      MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Me.Close()

   End Sub

#End Region

End Class