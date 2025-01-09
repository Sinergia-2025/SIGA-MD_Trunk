Option Strict Off
Public Class FiscalHASAR

   Private yFisPort As String
   Private yFisVel As String
   Private yFiscalRespuesta As String
   Private yFiscalError As String
   Private yFisRuta As String
   Private ArchivoSpoolerLog As String
   Private Archivoresultado As String
   Public RutaArchivo As String
   Private pathLogFiscales As String = Entidades.Publicos.CarpetaEniac + "LogsFiscales"

   Public Function Cuerpo_Ticket(ByVal IdTipoComprobante As String) As String

      Dim Resultado As String

      Resultado = Orden_OpenFiscalReceipt(IdTipoComprobante, "")

      Return Resultado

   End Function

   Public Function Cuerpo_TicketFactura(ByVal IdTipoComprobante As String, ByVal Letra As String) As String

      Dim Resultado As String

      Resultado = Orden_OpenFiscalReceipt(IdTipoComprobante, Letra)

      Return Resultado

   End Function

   Public Function Comentarios(ByVal Texto As String) As String

      Dim Resultado As String

      Resultado = Orden_PrintFiscalText(Texto)

      Return Resultado

   End Function

   Public Function Detalle(ByVal Codigo As String, ByVal Descripcion As String, ByVal Tamano As String, ByVal Cantidad As Decimal, ByVal Precio As Decimal, ByVal Alicuota As Decimal) As String

      Dim Resultado As String

      Resultado = Me.Orden_ImprimeDetalle(Codigo, Descripcion, Tamano, Cantidad, Precio, Alicuota)

      Return Resultado

   End Function

   Public Function Cierre(ByVal Total As Decimal, ByVal DiasPago As Integer) As String

      Dim Resul As String

      Resul = Me.Orden_Cierre_de_comprobante(Total, DiasPago)

      Return Resul

   End Function

   Public Function Orden_GetDateTime() As String

      Dim wOrden As String, Resultado As Integer
      Dim wFe As String, Who As String

      wOrden = ""
      Resultado = Fiscal("Y")

      wFe = Mid(yFiscalRespuesta, 35, 6)
      wFe = Right(wFe, 2) & "/" & Mid(wFe, 3, 2) & "/20" & Left(wFe, 2)
      Who = Mid(yFiscalRespuesta, 42, 6)
      Who = Left(Who, 2) & ":" + Mid(Who, 3, 2) + ":" + Right(Who, 2)

      Return wFe & " " & Who

   End Function

   Function Orden_SetCustomerData(ByVal wNombre As String, ByVal wCuit As String, ByVal wIdTipoInscipcion As String, ByVal wTipoDocumento As String, ByVal wDomici As String) As Boolean

      Dim mCuit As String, wOrden As String
      mCuit = wCuit

      If Len(wNombre) > 40 Then
         wNombre = Mid(wNombre, 1, 40)
      End If


      'Tipo de documento
      '-----------------
      'C: CUIT
      'L: CUIL (sólo disponible en los modelos SMH/P-715F, SMH/P-PR5F, y SMH/P-441F)
      '0: Libreta de enrolamiento
      '1: Libreta cívica
      '2: Documento Nacional de Identidad
      '3: Pasaporte
      '4: Cédula de identidad
      ' (espacio en blanco): Sin calificador

      wTipoDocumento = "C"

      'Select Case TipoDocumento
      '   Case "COD", "DNI"
      '      TipoDocumento = "L"  'cuil
      '   Case "DNI"
      '      TipoDocumento = "2"

      'End Select

      wOrden = "b" + Chr(28)
      wOrden = wOrden + wNombre + Chr(28) + mCuit + Chr(28)
      wOrden = wOrden + wIdTipoInscipcion + Chr(28) + wTipoDocumento + Chr(28)

      '* DOMICILIO
      If Len(Trim(wDomici)) > 0 Then
         wOrden = wOrden + wDomici
      End If

      Fiscal(wOrden)

   End Function

   Function Orden_OpenFiscalReceipt(ByVal wTipoComprobante As String, ByVal wLetra As String) As String

      'Tipo de Documento
      '-----------------
      'T: Tique
      'A: Tique Factura 'A’
      'B: Tique Factura 'B/C’
      'D: Tique nota de débito ‘A’            Sólo modelos SMH/P-715F, SMH/P-PR5F, y SMH/P-441F
      'E: Tique nota de débito ‘B/C’          Sólo modelos SMH/P-715F, SMH/P-PR5F, y SMH/P-441F

      Dim wOrden As String
      Dim wFisOrd As String

      If wTipoComprobante = Publicos.IdTicketFiscal Then
         wFisOrd = "T"
      Else
         wFisOrd = IIf(wLetra = "A", "A", "B")
      End If

      'POR AHORA SOLO SE HACEN TICKET-FACTURA
      'If wMov_tip = "D" Then
      '  wFisOrd = "E"
      'End If

      wOrden = "@" + Chr(28) + wFisOrd + Chr(28) + "T"
      Fiscal(wOrden)

      Return "OK"

   End Function

   Function Orden_OpenFiscalReceipt_Tipo_A(ByVal wMov_tip As String, ByRef wNumero_comprobante As String) As Boolean

      Dim wOrden As String

      wOrden = ""
      Dim wFisOrd As String

      wFisOrd = "A"
      If wMov_tip = "D" Then
         wFisOrd = "D"
      End If

      wOrden = "@" + Chr(28) + wFisOrd + Chr(28) + "T"
      Fiscal(wOrden)


   End Function

   Function Orden_ImprimeDetalle(ByVal wCod As String, ByVal wDes As String, ByVal wTam As String, ByVal wCant As Decimal, ByVal wPre As Decimal, ByVal wAlicuota As Decimal) As String

      Dim wOrden As String

      wOrden = ""

      wOrden = "B" + Chr(28)

      'DESCRIPCION 
      Dim wDescfiscal As String
      wDescfiscal = Trim(wCod + " " + wDes + " " + wTam)
      If Len(wDescfiscal) > 20 Then
         wDescfiscal = Left(wDescfiscal, 20)
      End If

      wOrden = wOrden + wDescfiscal

      If wCant < 0 Then
         wOrden = wOrden + "d"
      End If
      wOrden = wOrden + Chr(28)

      'CANTIDAD	
      wDescfiscal = wCant.ToString
      'wDescfiscal = Replace(wDescfiscal, ".00", ".0")

      wOrden = wOrden + wDescfiscal + Chr(28)

      'PRECIO

      'wDescfiscal = Trim(wPre.ToString("0.0"))
      'wDescfiscal = Replace(wDescfiscal, ".00", ".0")
      wDescfiscal = Trim(wPre.ToString("0.00"))

      wOrden = wOrden + wDescfiscal + Chr(28)

      'ALICUOTA IVA
      wDescfiscal = wAlicuota.ToString("00.0")
      wOrden = wOrden + wDescfiscal + Chr(28)

      'SUMA AL MONTO
      wOrden = wOrden + "M" + Chr(28)

      'IMPUESTOS INTERNOS
      wOrden = wOrden + "0.0" + Chr(28)

      'PARAMETRO DISPLAY (NO TIENE EFECTO PARA EL MODELO )
      wOrden = wOrden + "0" + Chr(28)

      'T: MUESTRA EL IMPORTE CON IVA INCLUIDO EN EL PRECIO 
      wOrden = wOrden + "T" '+ Chr(28)

      'PrintLineItem
      Fiscal(wOrden)

      Dim wSublin As String
      Dim wBonif As String = String.Empty
      Dim wDesw As String

      wSublin = System.Math.Round(wCant * wPre, 2).ToString

      If Not String.IsNullOrEmpty(wBonif) Then
         wOrden = "U" + Chr(28)
         wOrden = wOrden + "Bonif " + Trim(wBonif) + "%" + Chr(28)
         wDesw = System.Math.Round(wBonif / 100 * wSublin, 2)
         wOrden = wOrden + Trim(wDesw) + Chr(28)
         wOrden = wOrden + "m" + Chr(28)
         wOrden = wOrden + "0" + Chr(28)
         wOrden = wOrden + "T"

         'LastItemDiscount
         If Fiscal(wOrden) <> 0 Then
            Return "Error Fiscal LastItemDiscount: " & Me.yFiscalError
         End If

      End If

      Return "OK"

   End Function

   Function Orden_Cierre_de_comprobante(ByVal wTotal As Decimal, ByVal wDiasPago As Integer) As String

      Dim wOrden As String ', hLinea As String

      'Subtotal      QUE SON ESTOS COMANDOS !!??
      wOrden = "C" + Chr(28) + "P" + Chr(28) + "N" + Chr(28) + "0"

      Fiscal(wOrden)

      'hLinea = yFiscalRespuesta


      'Contado (si no lo pongo la fiscal asume Cuenta Corriente).
      If wDiasPago = 0 Then
         'TotalRender
         'wOrden = "D" + Chr(28) + "pesos " + Chr(28) + Trim(Format(wTotal, ".00")) + Chr(28) + "T" + Chr(28) + "0"
         'If Fiscal(wOrden) <> 0 Then
         '   Return ("Error Fiscal TotalRender: " & Me.yFiscalError)
         'End If

         'TotalTender
         wOrden = "D" + Chr(28) + "pesos " + Chr(28) + wTotal.ToString("#0.00") + Chr(28) + "T" + Chr(28) + "0"
         Fiscal(wOrden)

      End If

      'If Fiscal(wOrden) <> 0 Then
      '   Return ("Error Fiscal TotalRender: " & Me.yFiscalError)
      'End If

      'CloseFiscalReceipt
      wOrden = "E"
      Fiscal(wOrden)

      Return "OK"

   End Function

   Function Orden_PrintFiscalText(ByVal Texto As String) As String

      Dim wOrden As String

      wOrden = "A" + Chr(28) + Texto + Chr(28) + "0"
      Fiscal(wOrden)

      Return "OK"

   End Function

   Function Fiscal(ByVal wCadena As String) As Integer

      Dim Orden As String
      'orden Impresion con archivo

      'escribe el comando
      Orden = yFisRuta & "\accion.tmp"
      My.Computer.FileSystem.WriteAllText(Orden, wCadena & vbNewLine, True, System.Text.Encoding.Default)

      Return 0

   End Function

   Function GetNumeroComprobante(ByVal wTipoComprobante As String) As Integer

      Dim Lista() As String
      Dim NumeroComprobante As Integer

      Lista = Split(yFiscalRespuesta, vbNewLine)

      If wTipoComprobante = Publicos.IdTicketFiscal Then
         NumeroComprobante = Integer.Parse(Right(Lista(0), 8))
      Else
         NumeroComprobante = Integer.Parse(Right(Lista(1), 8))
      End If

      Return NumeroComprobante

   End Function

   Function FiscalImprimir() As String

      'LECTURA DE LA IMPRE FISCAL
      Dim WFRES As String
      Dim WEJECUTA As String
      Dim ObjFile As System.IO.FileInfo
      Dim Bat As String
      Dim Orden As String


      'orden Impresion con archivo

      'escribe el comando
      Orden = yFisRuta & "\accion.tmp"

      WEJECUTA = yFisRuta & "\spooler -p " & Trim(yFisPort) & "  -v " & Trim(yFisVel) & " -a " & yFisRuta & " -f " & Orden

      'escribe la orden completa
      Bat = yFisRuta & "\orden.bat"
      My.Computer.FileSystem.WriteAllText(Bat, WEJECUTA, False, System.Text.Encoding.ASCII)

      'escribe el bat que ejecuta la orden/comando y lo ejecuta
      WEJECUTA = yFisRuta & "\orden.bat"

      'copia el archivo y lo deja en el log
      System.IO.File.Copy(yFisRuta & "\accion.tmp", Me.pathLogFiscales + "\hasar" + DateTime.Now.ToString("yyyMMddHHmmss") + ".tmp")

      Shell(WEJECUTA, AppWinStyle.Hide, True, 10000)

      'LEE EL ARCHIVO DE LOG PARA VER SI HAY UN ERROR
      WFRES = VerError(ArchivoSpoolerLog)
      If WFRES <> "OK" Then
         Return WFRES
      End If

      'LEE EL ARCHIVO DE RESPUESTA
      ObjFile = New System.IO.FileInfo(Archivoresultado)
      If ObjFile.Exists() = False Then
         Return "No encuentra el archivo " & Archivoresultado
      Else
         yFiscalRespuesta = My.Computer.FileSystem.ReadAllText(Archivoresultado)
      End If

      Return "OK"

   End Function

   Public Function Orden_Cierre_Diario_Z() As String

      '*DailyClose
      Dim wOrden As String

      wOrden = "9" & Chr(28) & "Z"
      Fiscal(wOrden)

      Me.FiscalImprimir()

      Return "OK"

   End Function

   Public Function Orden_Leer_Fecha_y_Hora() As String

      'GetDateTime

      yFiscalRespuesta = Fiscal("Y")

      Return yFiscalRespuesta

   End Function

   Public Function Orden_Cancelar_Comprobante() As String

      yFiscalRespuesta = Fiscal(Chr(152))

      Return yFiscalRespuesta

   End Function

   Function VerError(ByVal ArcLog As String) As String

      Dim WCAD As String


      WCAD = My.Computer.FileSystem.ReadAllText(ArcLog)
      Me.yFiscalError = ""

      If InStr(WCAD, "Impresor Ocupado", CompareMethod.Text) > 0 Then
         Return "REPETIR"
      End If

      If InStr(WCAD, "Error", CompareMethod.Text) > 0 Then
         Me.yFiscalError = WCAD
         Return "MAL"
      End If

      Return "OK"

   End Function

   Public Sub New(ByVal Puerto As String, ByVal Velocidad As Integer, ByVal RutaArchivo As String)

      yFisPort = Puerto
      yFisVel = Velocidad.ToString()  '9600
      yFisRuta = RutaArchivo

      Dim ObjFile As System.IO.FileInfo

      ArchivoSpoolerLog = My.Application.Info.DirectoryPath & "\SPOOLER.LOG"
      'ArchivoSpoolerLog = yFisRuta & "\spooler.log"

      If Not System.IO.Directory.Exists(Me.pathLogFiscales) Then
         System.IO.Directory.CreateDirectory(Me.pathLogFiscales)
      End If

      ObjFile = New System.IO.FileInfo(ArchivoSpoolerLog)
      If ObjFile.Exists() Then
         ObjFile.Delete()
      End If

      Archivoresultado = yFisRuta & "\accion.tmp"
      ObjFile = New System.IO.FileInfo(Archivoresultado)
      If ObjFile.Exists() Then
         ObjFile.Delete()
      End If


      Archivoresultado = yFisRuta & "\accion.ans"
      ObjFile = New System.IO.FileInfo(Archivoresultado)
      If ObjFile.Exists() Then
         ObjFile.Delete()
      End If

   End Sub

   Public Function AbrirCajon() As String
      Dim wOrden As String

      wOrden = "{"

      Fiscal(wOrden)
      Me.FiscalImprimir()

      Return "OK"
   End Function

End Class
