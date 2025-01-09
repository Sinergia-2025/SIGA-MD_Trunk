Option Strict Off
Public Class FiscalEPSON

   Private _ArchivoEntrada As String
   Private _ArchivoSalida As String
   Private _oVenta As Entidades.Venta

   Private ResulShell As Integer
   Private strEjecuta As String

   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal

#Region "Constructores"

   'Public Sub New(ByVal ArchivoEntrada As String, ByVal ArchivoSalida As String, ByVal Puerto As String, ByVal Velocidad As String, ByVal RutaArchivo As String)
   Public Sub New(ByVal ArchivoEntrada As String, ByVal ArchivoSalida As String, ByVal Venta As Entidades.Venta)

      Me._ArchivoEntrada = ArchivoEntrada
      Me._ArchivoSalida = ArchivoSalida

      Me._oVenta = Venta

      Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function Abrir() As String

      'Dim ResulShell As Integer, Linea As String, I As Integer, strEjecuta As String
      Dim Linea As String, I As Integer

      Dim ioArchivoLee As System.IO.StreamReader

      I = 0

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


         strEjecuta = Entidades.Publicos.CarpetaEniac + "PFBATCH.EXE /NOECHO /" + Entidades.Publicos.DriverBase.Replace("\", "") & Me._oVenta.Impresora.Puerto & " /I:" & Me._ArchivoEntrada & " /O:" & Me._ArchivoSalida


         '32 Segundos de espera. Si ponemos -1 no devuelve el control hasta que finaliza. Es conveniente como tambien un riesgo
         ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, 32000)

         If System.IO.File.Exists(Me._ArchivoSalida) Then

            ioArchivoLee = My.Computer.FileSystem.OpenTextFileReader(Me._ArchivoSalida, System.Text.Encoding.ASCII)

            If ioArchivoLee.EndOfStream = True Then
               ioArchivoLee.Close()
               Return "Archivo de SALIDA en Blanco, Problema en Comunicacion con Impresor Fiscal"
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

   Public Function Encabezado() As String

      If System.IO.File.Exists(Me._ArchivoSalida) Then
         System.IO.File.Delete(Me._ArchivoSalida)
      End If

      If System.IO.File.Exists(Me._ArchivoEntrada) Then
         System.IO.File.Delete(Me._ArchivoEntrada)
      End If

      Dim Linea As String

      Dim ioArchivoGraba As System.IO.StreamWriter

      Try

         ioArchivoGraba = My.Computer.FileSystem.OpenTextFileWriter(Me._ArchivoEntrada, False, System.Text.Encoding.ASCII)

         '//// EN CUANTO SE FISCALIZE LA IMPREOSA ESTOS DATOS NO SE IMPRIMEN MAS ////

         '//// Datos del encabezado desde 1 al 10. ////

         'Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "1" & Chr(124) & Chr(242) & "**Nombre de la Empresa**"
         Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "1" & Chr(124) & "****************************"
         'ioArchivoGraba.WriteLine(Linea)

         'Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "2" & Chr(124) & "**Fec.Inic.Act.**"
         Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "2" & Chr(124) & "****************************"
         'ioArchivoGraba.WriteLine(Linea)

         'Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "3" & Chr(124) & "**Nro.Ingr.Brutos**"
         Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "3" & Chr(124) & "MUCHAS GRACIAS POR SU COMPRA"
         'ioArchivoGraba.WriteLine(Linea)

         'Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "4" & Chr(124) & "**Domicilio**"
         Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "4" & Chr(124) & "****************************"
         'ioArchivoGraba.WriteLine(Linea)

         'Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "5" & Chr(124) & "**Telefono**"
         Linea = "@PONEENCABEZADO" & Chr(124) & Chr(124) & "5" & Chr(124) & "****************************"
         'ioArchivoGraba.WriteLine(Linea)

         'LINEA = "@PONEENCABEZADO" + CHR(124) + CHR(124) + "6" + CHR(124) & "2000 - Rosario - Santa Fe'

         '///////////////////////////////////////////////////////////////////////////////

         ioArchivoGraba.Close()

         Return "OK"

      Catch ex As Exception

         Return "Error: " & ex.Message

      End Try

   End Function

   Public Function Cuerpo() As String

      Dim Linea As String

      Dim ioArchivoGraba As System.IO.StreamWriter

      Try

         ioArchivoGraba = My.Computer.FileSystem.OpenTextFileWriter(Me._ArchivoEntrada, True, System.Text.Encoding.ASCII)

         If Me._oVenta.TipoComprobante.IdTipoComprobante = Publicos.IdTicketFiscal Then

            Linea = "@TIQUEABRE" & Chr(124) & "00043"

            ioArchivoGraba.WriteLine(Linea)

            Linea = "@TIQUETEXTO|00001" & Chr(124) & Strings.Left("Vend.: " & Me._oVenta.Vendedor.NombreEmpleado & Space(40), 40)

            ioArchivoGraba.WriteLine(Linea)

         Else        'TICKET FACTURA / FACTURA

            'Campo 1 y 2

            Linea = "@FACTABRE" & Chr(124) & "00043" & Chr(124)

            'Tipo de Documento Fiscal que se va a realizar: <a> (Según modelo)
            'F= 0x46 Factura Fiscal
            'T= 0x54 Tique-Factura Fiscal
            'N= 0x4E Nota de Crédito Fiscal
            'M= 0x4D Tique-Nota de Crédito Fiscal
            'R= Recibo Fiscal !!!???

            'Campo 3
            'Linea = Linea & "T" & Chr(124) & strPapel & Chr(124)  '*** PERMITIR VARIOS COMPROBANTES!!! ****
            Linea = Linea & Me._oVenta.TipoComprobante.IdTipoComprobanteEpson & Chr(124)

            'Campo 4
            '"F": Hoja suelta / "C": Continuo / Comentario de Hernan Cimarelli: "S" de Suelta???
            Linea = Linea & Me._oVenta.Impresora.OrigenPapel & Chr(124)  '*** PERMITIR VARIOS COMPROBANTES!!! ****

            'Campo 5

            '*             LETRA A-B                      P/DIBUJAR FACT    
            'Linea = Linea & Me._oVentas.Cliente.CategoriaFiscal.LetraFiscal & Chr(124) & intCantidadCopias.ToString & Chr(124) & strFormulario & Chr(124) & "10" & Chr(124)
            Linea = Linea & Me._oVenta.CategoriaFiscal.LetraFiscal & Chr(124)

            'Campo 6
            'Cantidad de Copias (1 es porque tiene Carbonico)
            Linea = Linea & Me._oVenta.Impresora.CantidadCopias.ToString() & Chr(124)

            'Campo 7
            '"F": prerimpreso / "P": Dibuja impre / "A": Autoimpreso
            Linea = Linea & Me._oVenta.Impresora.TipoFormulario & Chr(124)

            'Campo 8
            'Tamaño de Letra (CPI = 10)
            Linea = Linea & Me._oVenta.Impresora.TamanioLetra.ToString() & Chr(124)

            'Campo 9: Condicion IVA Vendedor
            '  "I" 

            Dim CondicionIVAVendedor As String = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa).CondicionIvaImpresoraFiscalEpson

            Linea = Linea & CondicionIVAVendedor & Chr(124)

            'Campo 10: Condicion IVA Comprador   '**** 
            'Me._oVentas.Cliente.CategoriaFiscal.CondicionIvaImpresoraFiscal
            Linea = Linea & Me._oVenta.CategoriaFiscal.CondicionIvaImpresoraFiscalEpson & Chr(124)


            '*********************************

            'Campo 11: Nombre Comercial Comprador Primer Línea. Aprovecho y pongo el Vendedor.

            Linea = Linea & Strings.Left("Vend.: " & Me._oVenta.Vendedor.NombreEmpleado & Space(40), 40) & Chr(124)

            'Campo 12: Nombre Comercial Comprador Segunda Línea. 

            Linea = Linea & Strings.Left(Me._oVenta.Cliente.NombreCliente & Space(40), 40) & Chr(124)

            Dim TipoDoc As String

            TipoDoc = Me._oVenta.Cliente.TipoDocCliente

            'Campo 13/14: Tipo y Nro Documento

            'Si tiene el CUIT cargado lo tomo de ahi, para evitar codificarlo con el CUIT.
            If Not String.IsNullOrEmpty(Me._oVenta.Cliente.Cuit) Then
               If TipoDoc <> "CUIL" And TipoDoc <> "CUIT" Then
                  TipoDoc = "CUIT"
               End If
               Linea = Linea & TipoDoc & Chr(124) & Me._oVenta.Cliente.Cuit & Chr(124)
            Else
               Linea = Linea & Me._oVenta.Cliente.TipoDocCliente & Chr(124) & Strings.Left(Me._oVenta.Cliente.NroDocCliente & Space(11), 11) & Chr(124)
            End If

            'Campo 15/16: Bienes de Uso / Direccion

            'Bien de USO (B = Muestra Leyenda / N = No Muestra Leyenda).
            If Me._oVenta.Cliente.Direccion.Trim() <> "" Then
               Linea = Linea & "N" & Chr(124) & Strings.Left(Me._oVenta.Cliente.Direccion, 40) & Chr(124) & Chr(127) & Chr(124)
            Else
               'Fuerzo un Domicilio. Da error si no lo tiene.
               Linea = Linea & "N" & Chr(124) & "Sin Domicilio" & Chr(124) & Chr(127) & Chr(124)
            End If

            'Campo 17: Telefono
            If Me._oVenta.Cliente.Telefono.Trim() <> "" Then
               Linea = Linea & Chr(127) & Chr(124) & Me._oVenta.Cliente.Telefono & Chr(124) & Chr(127) '& Chr(13)
            Else
               'Fuerzo un telefono. Da error si no lo tiene.
               Linea = Linea & Chr(127) & Chr(124) & "0" & Chr(124) & Chr(127) '& Chr(13)
            End If

            ioArchivoGraba.WriteLine(Linea)

         End If

         ioArchivoGraba.Close()

         Return "OK"

      Catch ex As Exception

         Return "Error: " & ex.Message

      End Try

   End Function

   Public Function Detalle() As String

      Dim Linea As String = ""
      Dim intCont As Integer
      Dim decPrecio As Decimal
      Dim intIVA As Integer

      Dim ioArchivoGraba As System.IO.StreamWriter

      Try

         ioArchivoGraba = My.Computer.FileSystem.OpenTextFileWriter(Me._ArchivoEntrada, True, System.Text.Encoding.ASCII)

         If Me._oVenta.TipoComprobante.IdTipoComprobante = Publicos.IdTicketFiscal Then

            For intCont = 0 To Me._oVenta.VentasProductos.Count - 1

               Linea = "@TIQUEITEM" & Chr(124) & "00043" & Chr(124)

               '*                 MAXIMO 20 LETRAS
               Linea = Linea & Strings.Left(Publicos.NormalizarDescripcion(Me._oVenta.VentasProductos.Item(intCont).Producto.NombreProducto) & Space(20), 20)

               Linea = Linea & Chr(124) & (Me._oVenta.VentasProductos.Item(intCont).Cantidad * 1000).ToString("00000000")

               'Coloco el Precio con Descuento directamente 
               decPrecio = Me._oVenta.VentasProductos.Item(intCont).Precio + Decimal.Round(Me._oVenta.VentasProductos.Item(intCont).DescuentoRecargo / Me._oVenta.VentasProductos.Item(intCont).Cantidad, 2)

               If Reglas.Publicos.Facturacion.FacturacionTicketIncluyeRecargoGeneral And Me._oVenta.DescuentoRecargoPorc > 0 Then
                  decPrecio = decPrecio + Decimal.Round(decPrecio * Me._oVenta.DescuentoRecargoPorc / 100, 2)
               End If

               Linea = Linea & Chr(124) & Strings.Right("000000000" & CStr(Int(decPrecio * 100)), 9)
               Linea = Linea & Chr(124)

               '*              IVA * 100
               'Linea = Linea & "2100" & Chr(124)
               intIVA = Me._oVenta.VentasProductos.Item(intCont).AlicuotaImpuesto * 100
               Linea = Linea & intIVA.ToString("0000") & Chr(124)

               '*              ?            BULTOS          IMP.INTERNOS
               Linea = Linea & "M" & Chr(124) & "00001" & Chr(124) & "00000000"

               ioArchivoGraba.WriteLine(Linea)

            Next

         Else

            For intCont = 0 To Me._oVenta.VentasProductos.Count - 1

               Linea = "@FACTITEM" & Chr(124) & "00043" & Chr(124)

               '*                 MAXIMO 20 LETRAS
               Linea = Linea & Strings.Left(Publicos.NormalizarDescripcion(Me._oVenta.VentasProductos.Item(intCont).Producto.NombreProducto) & Space(20), 20)

               Linea = Linea & Chr(124) & (Me._oVenta.VentasProductos.Item(intCont).Cantidad * 1000).ToString("00000000")

               'Coloco el Precio con Descuento directamente 
               decPrecio = Me._oVenta.VentasProductos.Item(intCont).Precio + Decimal.Round(Me._oVenta.VentasProductos.Item(intCont).DescuentoRecargo / Me._oVenta.VentasProductos.Item(intCont).Cantidad, 2)

               If Reglas.Publicos.Facturacion.FacturacionTicketIncluyeRecargoGeneral And Me._oVenta.DescuentoRecargoPorc > 0 Then
                  decPrecio = decPrecio + Decimal.Round(decPrecio * Me._oVenta.DescuentoRecargoPorc / 100, 2)
               End If

               Linea = Linea & Chr(124) & Strings.Right("000000000" & CStr(Int(decPrecio * 100)), 9)
               Linea = Linea & Chr(124)

               '*              IVA INSC. * 100
               'Linea = Linea & "2100" & Chr(124)
               intIVA = Me._oVenta.VentasProductos.Item(intCont).AlicuotaImpuesto * 100
               Linea = Linea & intIVA.ToString("0000") & Chr(124)

               '*              ?            BULTOS          IMP.INTERNOS
               Linea = Linea & "M" & Chr(124) & "00001" & Chr(124) & "00000000" & Chr(124) & Chr(127)

               'If Me._oVentas.Cliente.CategoriaFiscal.IdCategoriaFiscal <> 3 Then
               If Me._oVenta.CategoriaFiscal.IdCategoriaFiscal <> 3 Then
                  '*                                                    IVA NO INSC. * 100  (+0.00%)
                  Linea = Linea & Chr(124) & Chr(127) & Chr(124) & Chr(127) & Chr(124) & "0000"
                  'Linea = Linea & Chr(13)
               Else
                  '*                                                    IVA NO INSC. * 100 (+10.50%)
                  Linea = Linea & Chr(124) & Chr(127) & Chr(124) & Chr(127) & Chr(124) & "1050"
                  'Linea = Linea & Chr(13)
               End If

               ioArchivoGraba.WriteLine(Linea)

            Next

         End If

         ioArchivoGraba.Close()

         Return "OK"

      Catch ex As Exception

         Return "Error: " & ex.Message

      End Try

   End Function

   Public Function Cierre() As String

      Dim Linea As String, decDescRecargo As Decimal

      Dim ioArchivoGraba As System.IO.StreamWriter

      Try

         ioArchivoGraba = My.Computer.FileSystem.OpenTextFileWriter(Me._ArchivoEntrada, True, System.Text.Encoding.ASCII)

         'Calculo el Descuento, tiene que tener IVA si es CF o MO. En forma predeterminada NO tiene IVA

         If Reglas.Publicos.Facturacion.FacturacionTicketIncluyeRecargoGeneral And Me._oVenta.DescuentoRecargoPorc > 0 Then
            Me._oVenta.DescuentoRecargo = 0
         End If

         If Not Me._oVenta.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            decDescRecargo = Decimal.Round(Me._oVenta.ImporteTotal - (Me._oVenta.ImporteTotal / (1 + Me._oVenta.DescuentoRecargoPorc / 100)), 2)
         Else
            decDescRecargo = Me._oVenta.DescuentoRecargo
         End If

         decDescRecargo = Math.Abs(decDescRecargo)

         If Me._oVenta.TipoComprobante.IdTipoComprobante = Publicos.IdTicketFiscal Then

            If Me._oVenta.DescuentoRecargo <> 0 Then
               If Me._oVenta.DescuentoRecargo < 0 Then
                  'decDescRecargo = Me._oVentas.DescuentoRecargo * -1
                  Linea = "@TIQUEPAGO" & Chr(124) & "00043" & Chr(124) & "BONIFICACION        "
                  Linea = Linea & Chr(124) & Strings.Right("000000000" & CStr(Int(decDescRecargo * 100)), 9)
                  Linea = Linea & Chr(124) & "D"
               Else
                  Linea = "@TIQUEPAGO" & Chr(124) & "00043" & Chr(124) & "RECARGO             "
                  'Linea = Linea & Chr(124) & Strings.Right("000000000" & CStr(Int(Me._oVentas.DescuentoRecargo * 100)), 9)
                  Linea = Linea & Chr(124) & Strings.Right("000000000" & CStr(Int(decDescRecargo * 100)), 9)
                  Linea = Linea & Chr(124) & "R"
               End If
               ioArchivoGraba.WriteLine(Linea)
            End If

            Linea = "@TIQUECIERRA" & Chr(124) & "00043" & Chr(124) & "T"

            ioArchivoGraba.WriteLine(Linea)

         Else

            If Me._oVenta.DescuentoRecargo <> 0 Then
               If Me._oVenta.DescuentoRecargo < 0 Then
                  'decDescRecargo = Me._oVentas.DescuentoRecargo * -1
                  Linea = "@FACTPAGO" & Chr(124) & "00043" & Chr(124) & "BONIFICACION        "
                  Linea = Linea & Chr(124) & Strings.Right("000000000" & CStr(Int(decDescRecargo * 100)), 9)
                  Linea = Linea & Chr(124) & "D"
               Else
                  Linea = "@FACTPAGO" & Chr(124) & "00043" & Chr(124) & "RECARGO             "
                  'Linea = Linea & Chr(124) & Strings.Right("000000000" & CStr(Int(Me._oVentas.DescuentoRecargo * 100)), 9)
                  Linea = Linea & Chr(124) & Strings.Right("000000000" & CStr(Int(decDescRecargo * 100)), 9)
                  Linea = Linea & Chr(124) & "R"
               End If
               ioArchivoGraba.WriteLine(Linea)
            End If


            'Linea = "@FACTCIERRA" & Chr(124) & "00043" & Chr(124) & "T" & Chr(124) & Me._oVentas.Cliente.CategoriaFiscal.LetraFiscal & Chr(124) & "FINAL"
            Linea = "@FACTCIERRA" & Chr(124) & "00043" & Chr(124) & Me._oVenta.TipoComprobante.IdTipoComprobanteEpson & Chr(124)
            Linea = Linea & Me._oVenta.CategoriaFiscal.LetraFiscal & Chr(124) & "FINAL"

            ioArchivoGraba.WriteLine(Linea)

         End If

         ioArchivoGraba.Close()

         Return "OK"

      Catch ex As Exception

         Return "Error: " & ex.Message

      End Try

   End Function

   Public Function TablaErrores(ByVal pCodigo As String) As String

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

   Public Function AbrirCajon(Puerto As String) As String
      If System.IO.File.Exists(Me._ArchivoSalida) Then
         System.IO.File.Delete(Me._ArchivoSalida)
      End If

      If System.IO.File.Exists(Me._ArchivoEntrada) Then
         System.IO.File.Delete(Me._ArchivoEntrada)
      End If

      Dim Linea As String
      Linea = "@ABRECAJON1" + Environment.NewLine

      'Dim ioArchivoGraba As System.IO.StreamWriter

      IO.File.WriteAllText(Me._ArchivoEntrada, Linea, System.Text.Encoding.ASCII)

      strEjecuta = Entidades.Publicos.CarpetaEniac + "PFBATCH.EXE /NOECHO /" + Entidades.Publicos.DriverBase.Replace("\", "") & Puerto.ToString().Replace("COM", "") & " /I:" & Me._ArchivoEntrada & " /O:" & Me._ArchivoSalida

      '32 Segundos de espera. Si ponemos -1 no devuelve el control hasta que finaliza. Es conveniente como tambien un riesgo
      ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, 32000)

      Return "OK"
   End Function

#End Region

End Class
