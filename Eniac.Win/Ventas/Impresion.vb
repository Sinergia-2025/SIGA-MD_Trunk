Imports System.IO
Public Class Impresion

#Region "Campos"

   Private _ArchivoEntrada As String
   Private _ArchivoSalida As String
   Private _oVenta As Entidades.Venta
   Private _eSucursal As Entidades.Sucursal
   'Private _EpsonFiscal As AxEpsonFPHostControlX.AxEpsonFPHostControl
   Private Estado As EstadoImpresion = New EstadoImpresion()

   Private ResulShell As Integer
   Private strEjecuta As String
   Private _Logo As String
   Private _LogoMime As String
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal

   'Dim Comprobante As Integer

#End Region

#Region "Constructores"

   Public Sub New(Venta As Entidades.Venta)

      _oVenta = Venta
      _eSucursal = New Reglas.Sucursales().GetUna(_oVenta.IdSucursal, incluirLogo:=False)
      _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa(_eSucursal))

   End Sub

   'ES CORRECTO EL PASAJE VIA REFERENCIA DEL OCX FISCAL ???
   'Public Sub New(Ventas As Entidades.Venta, ByRef EpsonFiscal As AxEpsonFPHostControlX.AxEpsonFPHostControl)

   '   Me._oVentas = Ventas
   '   Me._EpsonFiscal = EpsonFiscal

   'End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub

#End Region

#Region "Metodos FISCALES BATCH"

   Public Function Imprimir_EPSON() As EstadoImpresion

      Try

         Me._ArchivoEntrada = Entidades.Publicos.CarpetaEniac + "Envio.txt"
         Me._ArchivoSalida = Entidades.Publicos.CarpetaEniac + "Salida.txt"

         Dim objEpson As New FiscalEPSON(Me._ArchivoEntrada, Me._ArchivoSalida, Me._oVenta)

         'Me._ArchivoEntrada = My.Application.Info.DirectoryPath & "\Envio.txt"
         'Me._ArchivoSalida = My.Application.Info.DirectoryPath & "\Respuesta.txt"

         Dim strRespuesta As String

         strRespuesta = objEpson.Abrir()

         If strRespuesta <> "OK" Then
            Estado.OK = False
            Estado.MensajeError = strRespuesta
            Estado.NumeroComprobante = 0
            Entidades.EniacMail.EnviarMail(strRespuesta)
            Return Estado
         End If

         If Me._oVenta.TipoComprobante.IdTipoComprobante = Publicos.IdTicketFiscal Then
            strRespuesta = objEpson.Encabezado()

            If strRespuesta <> "OK" Then
               Estado.OK = False
               Estado.MensajeError = strRespuesta
               Estado.NumeroComprobante = 0
               Entidades.EniacMail.EnviarMail(strRespuesta)
               Return Estado
            End If
         Else

            If File.Exists(Me._ArchivoSalida) Then
               File.Delete(Me._ArchivoSalida)
            End If

            If File.Exists(Me._ArchivoEntrada) Then
               File.Delete(Me._ArchivoEntrada)
            End If

         End If

         strRespuesta = objEpson.Cuerpo()

         If strRespuesta <> "OK" Then
            Estado.OK = False
            Estado.MensajeError = strRespuesta
            Estado.NumeroComprobante = 0
            Entidades.EniacMail.EnviarMail(strRespuesta)
            Return Estado
         End If

         strRespuesta = objEpson.Detalle()

         If strRespuesta <> "OK" Then
            Estado.OK = False
            Estado.MensajeError = strRespuesta
            Estado.NumeroComprobante = 0
            Entidades.EniacMail.EnviarMail(strRespuesta)
            Return Estado
         End If

         strRespuesta = objEpson.Cierre()

         If strRespuesta <> "OK" Then
            Estado.OK = False
            Estado.MensajeError = strRespuesta
            Estado.NumeroComprobante = 0
            Entidades.EniacMail.EnviarMail(strRespuesta)
            Return Estado
         End If

         '--------- INICIO IMPRIMIR -----------

         'Dim ResulShell As Integer, Linea As String, I As Integer, strEjecuta As String
         Dim Linea As String, I As Integer

         Dim ioArchivoLee As System.IO.StreamReader
         Dim blnOK As Boolean

         I = 0

         Do While I < 3


            'strEjecuta = "pfbatch /NOECHO /C:1 /I:Envio.txt /O:Respuesta.txt "

            strEjecuta = Entidades.Publicos.CarpetaEniac + "PFBATCH.EXE /NOECHO /" + Entidades.Publicos.DriverBase.Replace("\", "") & Me._oVenta.Impresora.Puerto & " /I:" & Me._ArchivoEntrada & " /O:" & Me._ArchivoSalida

            '32 Segundos de espera. Si ponemos -1 no devuelve el control hasta que finaliza. Es conveniente como tambien un riesgo

            'Cuando imprime muchas lineas de detalle no alcanzan los 32 segundos, seguia y luego daba error que el archivo estaba abierto.

            'Metodo arcaico!
            '---------------
            'ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, 32000)
            ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, -1)

            'Metodo Moderno!
            '---------------

            'Creo un nuevo Hijo de Ejecucion
            'Dim tr As System.Threading.Thread = New System.Threading.Thread(AddressOf EjecucionDOS)

            'While tr.IsAlive
            '   ' Que Cartelito pongo!!!??? una relojito ??
            'End While


            '         |@ESTADO            |OK   |0080|0200|N|
            '         |@PONEENCABEZADO    |OK   |0080|0200|
            '         |@PONEENCABEZADO    |OK   |0080|0200|
            '         |@PONEENCABEZADO    |OK   |0080|0200|
            '         |@PONEENCABEZADO    |OK   |0080|0200|
            '         |@PONEENCABEZADO    |OK   |0080|0200|
            '00043    |@TIQUEABRE         |OK   |0080|3200|
            '00043    |@TIQUEITEM         |OK   |0080|3200|
            '00043    |@TIQUEITEM         |OK   |0080|3200|
            '00043    |@TIQUEITEM         |OK   |0080|3200|
            '00043    |@TIQUEPAGO         |OK   |0080|3200|000000013490|
            '00043    |@TIQUECIERRA       |OK   |0080|0200|00000017|

            If My.Computer.FileSystem.FileExists(Me._ArchivoSalida) Then

               ioArchivoLee = My.Computer.FileSystem.OpenTextFileReader(Me._ArchivoSalida, System.Text.Encoding.ASCII)

               If ioArchivoLee.EndOfStream = True Then
                  ioArchivoLee.Close()

                  Estado.OK = False
                  Estado.MensajeError = "ARCHIVO EN BLANCO PROBLEMA EN COMUNICACION"
                  Estado.NumeroComprobante = 0
                  Entidades.EniacMail.EnviarMail(Estado.MensajeError)
                  Return Estado
               Else
                  Linea = ioArchivoLee.ReadLine
               End If

               ioArchivoLee.Close()

               '         |@ESTADO            |ERROR DE COMUNICACION
               '         |@ESTADO            |OK   |0080|0200|N|
               If Mid(Linea, 31, 5) = "ERROR" Then

                  Dim CodErr As String

                  CodErr = Trim(Mid(Linea, 37, 4))

                  Estado.OK = False
                  Estado.MensajeError = objEpson.TablaErrores(CodErr)
                  Estado.NumeroComprobante = 0
                  Return Estado

               Else

                  strRespuesta = ""

                  blnOK = True

                  Using sr As StreamReader = New StreamReader(Me._ArchivoSalida)

                     Linea = sr.ReadLine

                     While Not Linea Is Nothing

                        strRespuesta = strRespuesta & Linea & Chr(13)

                        If Strings.Mid(Linea, 11, 12) = "@TIQUECIERRA" Or Strings.Mid(Linea, 11, 11) = "@FACTCIERRA" Then

                           If Strings.Mid(Linea, 31, 5).Trim() = "OK" Then
                              '00043    |@TIQUECIERRA       |OK   |0080|0200|00000017|

                              Estado.NumeroComprobante = Integer.Parse(Linea.Substring(46, 8))

                           End If

                        End If

                        'Si alguna linea no esta OK lo aviso. O SOLO IMPORTA EL OK EN EL NUMERO DE COMPROBANTE ???
                        If Strings.Mid(Linea, 31, 5).Trim() <> "OK" Then
                           blnOK = False
                        End If

                        Linea = sr.ReadLine
                     End While


                     sr.Close()

                  End Using

                  Estado.OK = blnOK

                  If blnOK Then
                     Estado.MensajeError = ""
                     Return Estado
                  Else
                     Estado.MensajeError = "ERROR en la impresion/registracion, reintente la operacion" & Chr(13) & Chr(13) & strRespuesta
                     Estado.NumeroComprobante = 0
                     Entidades.EniacMail.EnviarMail(Estado.MensajeError)
                     Return Estado

                  End If

               End If
            Else
               MessageBox.Show("Archivo de salida no encontrado", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            I = I + 1
         Loop

         Estado.OK = False
         Estado.MensajeError = "IMPRESOR FISCAL APAGADO O DESCONECTADO"
         Estado.NumeroComprobante = 0
         Entidades.EniacMail.EnviarMail(Estado.MensajeError)

         Return Estado

      Catch ex As Exception

         Estado.OK = False

         Entidades.EniacMail.EnviarMail(ex.Message)

         Dim mensa As String = ex.Message

         If ex.InnerException IsNot Nothing Then
            mensa += " - " + ex.InnerException.Message
         End If

         Estado.MensajeError = mensa
         Estado.NumeroComprobante = 0

         Return Estado

      End Try

   End Function

   Public Function Imprimir_HASAR() As EstadoImpresion

      Try

         Dim objHasar As New FiscalHASAR(Me._oVenta.Impresora.Puerto, Me._oVenta.Impresora.Velocidad, Entidades.Publicos.CarpetaEniac)

         Dim strRespuesta As String

         If _oVenta.TipoComprobante.IdTipoComprobante = Publicos.IdTicketFiscal Then

            'strRespuesta = objHasar.Cuerpo_Ticket(Comprobante)
            strRespuesta = objHasar.Cuerpo_Ticket(Me._oVenta.TipoComprobante.IdTipoComprobante)

         Else

            objHasar.Orden_SetCustomerData(Me._oVenta.Cliente.NombreCliente, Me._oVenta.Cliente.Cuit,
                                          Me._oVenta.Cliente.CategoriaFiscal.CondicionIvaImpresoraFiscalHasar, Me._oVenta.Cliente.TipoDocCliente,
                                          Me._oVenta.Cliente.Direccion)

            objHasar.Cuerpo_TicketFactura(Me._oVenta.TipoComprobante.IdTipoComprobante, Me._oVenta.LetraComprobante)

         End If


         Dim Descripcion As String = String.Empty
         Dim Cantidad As Decimal = 0
         Dim Precio As Decimal = 0
         Dim Alicuota As Decimal = 0

         For intCont As Integer = 0 To Me._oVenta.VentasProductos.Count - 1


            '*                 MAXIMO 20 LETRAS
            Descripcion = Strings.Left(Publicos.NormalizarDescripcion(Me._oVenta.VentasProductos.Item(intCont).Producto.NombreProducto) & Space(20), 20)

            Cantidad = Me._oVenta.VentasProductos.Item(intCont).Cantidad

            'Coloco el Precio con Descuento directamente 

            Precio = Me._oVenta.VentasProductos.Item(intCont).Precio
            Alicuota = Me._oVenta.VentasProductos.Item(intCont).AlicuotaImpuesto

            If (Me._oVenta.Cliente.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
            Not Me._oVenta.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then

               Precio = Decimal.Round(Precio * (1 + (Alicuota / 100)), 2)

            End If

            Precio = Precio + (Me._oVenta.VentasProductos.Item(intCont).DescuentoRecargo / Me._oVenta.VentasProductos.Item(intCont).Cantidad)

            If Reglas.Publicos.Facturacion.FacturacionTicketIncluyeRecargoGeneral And Me._oVenta.DescuentoRecargoPorc > 0 Then
               Precio = Precio + (Precio * Me._oVenta.DescuentoRecargoPorc / 100)
            End If

            Dim Codigo As String
            Codigo = Me._oVenta.VentasProductos.Item(intCont).IdProducto

            objHasar.Detalle(Codigo, Descripcion, "", Cantidad, Precio, Alicuota)

         Next

         'Falta manejo en el cierre, de informar el descuento/Recargo total.
         strRespuesta = objHasar.Cierre(Me._oVenta.ImporteTotal, Me._oVenta.FormaPago.Dias)

         strRespuesta = objHasar.FiscalImprimir()
         If strRespuesta IsNot Nothing And strRespuesta <> "OK" Then
            Estado.OK = False
            Estado.MensajeError = strRespuesta
            Estado.NumeroComprobante = 0
            Return Estado
         End If

         Estado.OK = True
         Estado.NumeroComprobante = objHasar.GetNumeroComprobante(Me._oVenta.TipoComprobante.IdTipoComprobante)
         Estado.MensajeError = ""

         Return Estado

      Catch ex As Exception

         Estado.OK = False
         Estado.MensajeError = ex.Message
         Estado.NumeroComprobante = 0

         Return Estado

      End Try

   End Function

   Private Sub EjecucionDOS()

      '32 Segundos de espera. Si ponemos -1 no devuelve el control hasta que finaliza. Es conveniente como tambien un riesgo

      'ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, 32000)

      ResulShell = Shell(strEjecuta, AppWinStyle.Hide, True, -1)

   End Sub

#End Region

#Region "Metodos NO FISCALES"

   Public Function Imprimir() As EstadoImpresion

      Estado.OK = True
      Estado.MensajeError = ""

      Return Estado

   End Function

   Public Function ImprimirComprobanteNoFiscal(Visualizar As Boolean, Optional UtilizarComprobanteEstandar As Boolean = False, Optional VisualizaPercepcion As Boolean = True) As Boolean

      Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(Me._oVenta.TipoComprobante.IdTipoComprobante, Me._oVenta.LetraComprobante)

      'Utiliza una Rutina Especifica
      If tipoLetra.ArchivoAImprimir.Contains(";") And Not Visualizar And Not UtilizarComprobanteEstandar Then

         Dim FuncionEspecif = tipoLetra.ArchivoAImprimir.Split(";"c)

         Select Case FuncionEspecif(0).ToString()

            Case "FACTURA_CENTRALAUTOP"
               Me.Factura_CentralAutopartes(FuncionEspecif(1))

            Case "REMITO_CENTRALAUTOP"
               Dim Cont As Integer
               For Cont = 1 To Me._oVenta.TipoComprobante.CantidadCopias
                  Me.RemitoTransportista_CentralAutopartes(FuncionEspecif(1), Cont)
                  Me.Espera(400) 'Hago una espera para dar tiempo a construir el nuevo TXT
               Next

            Case "FACTURA_VINNOVA"
               Me.Factura_Distribuidora_Vinnova(FuncionEspecif(1), tipoLetra.NombreImpresora)

            Case Else
               Throw New Exception("ATENCION: NO fue posible imprimir porque NO Existe la Rutina: " & FuncionEspecif(0).ToString() & ", Contáctese con Sistemas.")

         End Select

         Return True

      End If

      Dim rep = New Reporte()
      rep.ArmarReporteDeVenta(_oVenta, _categoriaFiscalEmpresa, UtilizarComprobanteEstandar, False)

      Dim Copias As Integer
      If tipoLetra.ArchivoAImprimir <> String.Empty Then
         Copias = tipoLetra.CantidadCopias
      Else
         Copias = Me._oVenta.TipoComprobante.CantidadCopias
      End If

      If Visualizar Then
         Dim frmImprime As VisorReportes
         frmImprime = New VisorReportes(rep.ReporteNombre,
                                        rep.ReporteDataSource,
                                        rep.VentasProductosDT,
                                        rep.ReporteDataSource2,
                                        rep.VentasObservacionesDT,
                                        rep.ReporteDataSource3,
                                        rep.VentasImpuestosDT,
                                        rep.ReporteDataSource4,
                                        rep.CuotasDT,
                                        rep.Parametros,
                                        rep.ReporteEmbebido,
                                        _oVenta.TipoComprobante.EsElectronico,
                                        Copias)
         frmImprime.Text = rep.Titulo
         frmImprime.StartPosition = FormStartPosition.CenterScreen
         frmImprime.Destinatarios = Me._oVenta.Cliente.CorreoElectronico
         'If Me._oVentas.TipoComprobante.EsElectronico Then
         '   frmImprime.ImprimeDirecto = True
         'End If
         frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
         frmImprime.ShowDialog()

         If Not String.IsNullOrWhiteSpace(rep.ReporteNombreComplementario) Then
            Dim frmImprime2 As VisorReportes
            frmImprime2 = New VisorReportes(rep.ReporteNombreComplementario,
                                           rep.ReporteDataSource,
                                           rep.VentasProductosDT,
                                           rep.ReporteDataSource2,
                                           rep.VentasObservacionesDT,
                                           rep.ReporteDataSource3,
                                           rep.VentasImpuestosDT,
                                           rep.ReporteDataSource4,
                                           rep.CuotasDT,
                                           rep.Parametros,
                                           rep.ReporteEmbebidoComplementario,
                                           Me._oVenta.TipoComprobante.EsElectronico,
                                           Copias)
            frmImprime2.Text = rep.Titulo
            frmImprime2.StartPosition = FormStartPosition.CenterScreen
            frmImprime.Destinatarios = Me._oVenta.Cliente.CorreoElectronico
            'If Me._oVentas.TipoComprobante.EsElectronico Then
            '   frmImprime.ImprimeDirecto = True
            'End If
            frmImprime2.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
            frmImprime2.ShowDialog()
         End If

      Else
         Dim imp As Imprimir = New Imprimir(rep.ConfigImprimir)
         imp.Run(rep.ReporteNombre,
                 rep.ReporteDataSource,
                 rep.VentasProductosDT,
                 rep.ReporteDataSource2,
                 rep.VentasObservacionesDT,
                 rep.ReporteDataSource3,
                 rep.VentasImpuestosDT,
                 rep.ReporteDataSource4,
                 rep.CuotasDT,
                 rep.Parametros,
                 rep.ReporteEmbebido,
                 tipoLetra.NombreImpresora,
                 Copias,
                 Me._oVenta.TipoComprobante.EsElectronico)

         If Not String.IsNullOrWhiteSpace(rep.ReporteNombreComplementario) Then
            Dim imp2 As Imprimir = New Imprimir(rep.ConfigImprimirComplementario)
            imp2.Run(rep.ReporteNombreComplementario,
                    rep.ReporteDataSource,
                    rep.VentasProductosDT,
                    rep.ReporteDataSource2,
                    rep.VentasObservacionesDT,
                    rep.ReporteDataSource3,
                    rep.VentasImpuestosDT,
                    rep.ReporteDataSource4,
                    rep.CuotasDT,
                    rep.Parametros,
                    rep.ReporteEmbebidoComplementario,
                    tipoLetra.NombreImpresora,
                    Copias,
                    Me._oVenta.TipoComprobante.EsElectronico)
         End If

      End If

      If _oVenta.Percepciones IsNot Nothing Then
         For Each perc As Entidades.PercepcionVenta In _oVenta.Percepciones
            If perc.ImporteTotal <> 0 Then
               Dim ret As PercepcionImprimir = New PercepcionImprimir()
               ret.ImprimirPercepcion(_oVenta, perc, VisualizaPercepcion, Imprime:=Not Visualizar)
            End If
         Next
      End If


      If Not Visualizar Or (Visualizar And Publicos.VisualizarComprobanteVentaAsumeImpresion) Then
         Me.ActualizaFechaImpresion()
      End If

      Return True
   End Function

   Private Sub ActualizaFechaImpresion()
      Dim ven As Reglas.Ventas = New Reglas.Ventas()
      ven.ActualizaFechaImpresion(Me._oVenta.IdSucursal, Me._oVenta.TipoComprobante.IdTipoComprobante,
                                    Me._oVenta.LetraComprobante, Me._oVenta.CentroEmisor,
                                    Me._oVenta.NumeroComprobante)
   End Sub

   Public Function ReImprimirComprobanteFiscal() As Boolean

      Dim DecimalesAMostrarEnPrecio As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio(_eSucursal)
      Dim DecimalesAMostrarEnTotalXProducto As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto(_eSucursal)

      'cambio los valores porque se graban segun corresponde, ej: Mota de credito u otro tipo que necesite grabarlo en forma negativa
      Dim coe As Integer = Me._oVenta.TipoComprobante.CoeficienteValores

      Dim dtVP As SistemaDataSet.VentasProductosDataTable = New SistemaDataSet.VentasProductosDataTable()
      Dim drVP As SistemaDataSet.VentasProductosRow

      Dim ImporteBruto As Decimal = 0
      Dim descRec1 As Decimal = 0
      Dim descRec2 As Decimal = 0

      For Each vp As Entidades.VentaProducto In Me._oVenta.VentasProductos

         drVP = dtVP.NewVentasProductosRow()

         drVP.IdTipoComprobante = Me._oVenta.TipoComprobante.IdTipoComprobante
         drVP.NumeroComprobante = Me._oVenta.NumeroComprobante
         'drF.Letra = Me._oVentas.Cliente.CategoriaFiscal.LetraFiscal
         drVP.Letra = Me._oVenta.LetraComprobante
         drVP.IdSucursal = vp.IdSucursal
         drVP.IdProducto = vp.Producto.IdProducto
         drVP.EsObservacion = vp.Producto.EsObservacion
         drVP.CentroEmisor = vp.CentroEmisor
         drVP.NombreProducto = vp.Producto.NombreProducto
         drVP.Cantidad = vp.Cantidad * coe
         'If Not Me._oVentas.Cliente.CategoriaFiscal.IvaDiscriminado Then
         If Not Me._oVenta.CategoriaFiscal.IvaDiscriminado Then
            drVP.Precio = Decimal.Round(vp.Precio * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
            drVP.PrecioNeto = Decimal.Round(vp.PrecioNeto * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
            drVP.ImporteTotal = Decimal.Round(vp.ImporteTotal * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnTotalXProducto)
            drVP.Descuento = Decimal.Round(vp.DescuentoRecargo * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
            drVP.DescuentoProducto = Decimal.Round(vp.DescuentoRecargoProducto * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
         Else
            drVP.Precio = vp.Precio
            drVP.PrecioNeto = vp.PrecioNeto
            drVP.ImporteTotal = vp.ImporteTotal
            drVP.Descuento = vp.DescuentoRecargo
            drVP.DescuentoProducto = vp.DescuentoRecargoProducto
         End If

         drVP.AlicuotaImpuesto = vp.AlicuotaImpuesto
         drVP.ImporteImpuestoInterno = vp.ImporteImpuestoInterno

         With drVP
            '.Precio = .Precio * coe
            '.PrecioNeto = .PrecioNeto * coe
            .ImporteTotal = .ImporteTotal * coe
            .Descuento = .Descuento * coe
            .DescuentoProducto = .DescuentoProducto * coe
         End With

         drVP.DescuentoProductoPorc1 = vp.DescuentoRecargoPorc1
         drVP.DescuentoProductoPorc2 = vp.DescuentoRecargoPorc2
         drVP.DescuentoProductoPorcCompuesto = Reglas.CalculosDescuentosRecargos.CombinaDosDescuentos(vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, DecimalesAMostrarEnPrecio)

         Dim precioParaDescuento As Decimal
         If Not Me._oVenta.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            precioParaDescuento = drVP.Precio - (drVP.ImporteImpuestoInterno / drVP.Cantidad)
         Else
            precioParaDescuento = drVP.Precio
         End If

         descRec1 = Decimal.Round(precioParaDescuento * vp.DescuentoRecargoPorc1 / 100, DecimalesAMostrarEnPrecio)
         descRec2 = Decimal.Round((precioParaDescuento + descRec1) * vp.DescuentoRecargoPorc2 / 100, DecimalesAMostrarEnPrecio)

         ImporteBruto += Decimal.Round((drVP.Precio + descRec1 + descRec2) * vp.Cantidad, 2)

         dtVP.AddVentasProductosRow(drVP)
      Next

      Dim dtVO As SistemaDataSet.VentasObservacionesDataTable = New SistemaDataSet.VentasObservacionesDataTable()
      Dim drVO As SistemaDataSet.VentasObservacionesRow

      For Each vo As Entidades.VentaObservacion In Me._oVenta.VentasObservaciones

         drVO = dtVO.NewVentasObservacionesRow()

         drVO.IdSucursal = Me._oVenta.IdSucursal
         drVO.IdTipoComprobante = Me._oVenta.TipoComprobante.IdTipoComprobante
         drVO.Letra = Me._oVenta.LetraComprobante
         drVO.CentroEmisor = Me._oVenta.CentroEmisor
         drVO.NumeroComprobante = Me._oVenta.NumeroComprobante
         drVO.Linea = vo.Linea
         drVO.Observacion = vo.Observacion

         dtVO.AddVentasObservacionesRow(drVO)
      Next

      'Total de Perceciones e Impuestos NO IVA
      Dim TotalImpuestosVarios As Decimal = 0
      For Each vi As Entidades.VentaImpuesto In Me._oVenta.ImpuestosVarios
         TotalImpuestosVarios += vi.Importe
      Next

      Dim TotalImpuestos As Decimal = Me._oVenta.TotalImpuestos - TotalImpuestosVarios

      If Not Me._oVenta.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         With Me._oVenta
            .ImporteBruto = ImporteBruto
            .DescuentoRecargo = ImporteBruto * (.DescuentoRecargoPorc / 100)
            .Subtotal = .Subtotal + .TotalImpuestos - TotalImpuestosVarios
            .TotalImpuestos = 0
         End With
         TotalImpuestos = 0
      End If

      With Me._oVenta
         .ImporteBruto = .ImporteBruto * coe
         .DescuentoRecargo = .DescuentoRecargo * coe
         .Subtotal = .Subtotal * coe
         .ImporteTotal = .ImporteTotal * coe
      End With
      TotalImpuestos = TotalImpuestos * coe
      TotalImpuestosVarios = TotalImpuestosVarios * coe

      Dim pagare As String = String.Empty

      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
      Dim frmImprime As VisorReportes

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaOficial(_eSucursal)))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.Direccion & " - " & actual.Sucursal.Localidad.NombreLocalidad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoComprobante", Me._oVenta.TipoComprobante.Descripcion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Letra", Me._oVenta.LetraComprobante))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CentroEmisor", Me._oVenta.Impresora.CentroEmisor.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", Me._oVenta.NumeroComprobante.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me._oVenta.Fecha.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", Me._oVenta.Fecha.AddDays(Reglas.Publicos.DiasValidezPresupuesto(_eSucursal)).ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", Me._oVenta.Cliente.NombreCliente))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", Me._oVenta.Cliente.CodigoCliente.ToString()))
      '-- REQ-44139.- --------------------------------------------------------------------------------------------------------------------------------------------------------
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CodigoClienteLetras", Me._oVenta.Cliente.CodigoClienteLetras.ToString()))
      '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CategoriaIVA", Me._oVenta.CategoriaFiscal.NombreCategoriaFiscal))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdCategoriaFiscal", Me._oVenta.CategoriaFiscal.IdCategoriaFiscal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", Me._oVenta.Cliente.Direccion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", Me._oVenta.Cliente.Telefono & " " & Me._oVenta.Cliente.Celular))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", Me._oVenta.Cliente.NombreLocalidad & " - " & Me._oVenta.Cliente.Localidad.NombreProvincia))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cuit", "0" & Me._oVenta.Cliente.Cuit.Replace("-", "")))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPago", Me._oVenta.FormaPago.DescripcionFormasPago))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPagoDias", Me._oVenta.FormaPago.Dias.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", Me._oVenta.Observacion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Vendedor", Me._oVenta.Vendedor.NombreEmpleado))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Bruto", Me._oVenta.ImporteBruto.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescuentoRecargo", Me._oVenta.DescuentoRecargo.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescuentoRecargoPorc", Me._oVenta.DescuentoRecargoPorc.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Subtotal", Me._oVenta.Subtotal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalIVA", TotalImpuestos.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalImpuestosVarios", TotalImpuestosVarios.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Total", Me._oVenta.ImporteTotal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Kilos", Me._oVenta.Kilos.ToString()))


      'Calculo el saldo para imprimirlo
      Dim SaldoActual As Decimal = 0
      Dim blnContemplaHora As Boolean = True
      'SaldoActual = New Reglas.CuentasCorrientes().GetSaldoCliente(Me._oVenta.IdSucursal, Me._oVenta.Cliente.IdCliente, Me._oVenta.Fecha, blnContemplaHora)
      SaldoActual = New Reglas.CuentasCorrientes().GetSaldoCliente({New Entidades.Sucursal() With {.Id = Me._oVenta.IdSucursal}},
                                                                   Me._oVenta.Cliente.IdCliente, Me._oVenta.Fecha, blnContemplaHora, comprobantesAsociados:="TODOS",
                                                                   grabaLibro:=Nothing, comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:="",
                                                                   excluirPreComprobantes:=False, IdCama:=0, IdEmbarcacion:=0)
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoActual", SaldoActual.ToString()))
      '--------------------------------

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CotizacionDolar", Me._oVenta.CotizacionDolar.ToString()))

      'frmImprime = New VisorReportes("Eniac.Win.Fiscal.rdlc", "SistemaDataSet_VentasProductos", dtVP, parm, True)
      frmImprime = New VisorReportes("Eniac.Win.Fiscal.rdlc", "SistemaDataSet_VentasProductos", dtVP, "SistemaDataSet_VentasObservaciones", dtVO, parm, True, 1) '# 1 = Cantidad Copias
      frmImprime.Text = Me._oVenta.TipoComprobante.Descripcion
      frmImprime.StartPosition = FormStartPosition.CenterScreen
      frmImprime.Destinatarios = Me._oVenta.Cliente.CorreoElectronico
      frmImprime.Show()

      Me.ActualizaFechaImpresion()

      Return True
   End Function

#End Region

#Region "Metodos CLIENTE - Central Autopartes"

   Private Sub Factura_CentralAutopartes(Puerto As String)

      Dim mFile As String = Entidades.Publicos.DriverBase + "Factura.txt"
      'abre el archivo de texto
      Dim Archi As System.IO.StreamWriter
      Archi = My.Computer.FileSystem.OpenTextFileWriter(mFile, False, System.Text.Encoding.ASCII)

      Dim CuentaLineas As Integer, Cadena As String, Valor As String, DescProd As String

      Try

         'agrega lineas
         With Archi
            .WriteLine(Chr(27) & Chr(64) & Chr(27) & Chr(67) & Chr(72))

            .WriteLine("")
            .WriteLine("")
            .WriteLine(Space(53) & Me._oVenta.TipoComprobanteDescripcion.ToUpper())  '3
            .WriteLine("")
            .WriteLine(Space(60) & Me._oVenta.Fecha.ToString("dd/MM/yyyy")) '5
            .WriteLine("")


            .WriteLine("")
            .WriteLine("")
            .WriteLine("")
            .WriteLine("")

            Valor = Space(10) & Me._oVenta.Cliente.NombreCliente & " (" & Me._oVenta.Cliente.CodigoCliente.ToString() & ")"

            .WriteLine(Valor)

            .WriteLine(Space(10) & Me._oVenta.Cliente.Direccion)
            .WriteLine(Space(10) & Me._oVenta.Cliente.NombreLocalidad)
            .WriteLine("")
            .WriteLine(Space(10) & Me._oVenta.Cliente.CategoriaFiscal.NombreCategoriaFiscal & Space(15) & Me._oVenta.Cliente.Cuit)
            .WriteLine("")

            '.WriteLine(Space(15) & Me._oVentas.FormaPago.DescripcionFormasPago & Space(10) & Me.txtRemito.Text)
            .WriteLine(Space(15) & Me._oVenta.FormaPago.DescripcionFormasPago)

            '.WriteLine(Space(63) & Me.txtPedido.Text)  
            .WriteLine("")

            .WriteLine("")

            '01/10 - para ver como sale sin alterar letra
            '.WriteLine(Chr(27) & Chr(77))

            '-------------------------
            'CuentaLineas = 21

            'Le agrego una linea en blanco y le quito detalle para que no entre "justo" con los titulos.
            'Varia segun la impresora.
            .WriteLine("")
            CuentaLineas = 21
            '-------------------------

            For Each Linea As Entidades.VentaProducto In Me._oVenta.VentasProductos

               Cadena = Me.Completa(Linea.Producto.IdProducto, 13, False)

               If Len(Publicos.NormalizarDescripcion(Linea.Producto.NombreProducto.Trim)) > 30 Then

                  DescProd = Mid(Publicos.NormalizarDescripcion(Linea.Producto.NombreProducto.Trim), 1, 30)
                  Cadena &= " " & Me.Completa(DescProd, 30, False)
                  .WriteLine(Cadena)
                  CuentaLineas += 1

                  Cadena = Space(13)
                  DescProd = Mid(Publicos.NormalizarDescripcion(Linea.Producto.NombreProducto.Trim), 31, 30)
               Else
                  DescProd = Publicos.NormalizarDescripcion(Linea.Producto.NombreProducto.Trim)
               End If

               Cadena &= " " & Me.Completa(DescProd, 30, False)
               Valor = Me.Completa(Format(Linea.Cantidad, "#,###.#"), 7, True)

               Cadena &= " " & Valor

               Valor = Me.Completa(Format(Linea.Precio, "##,###.00"), 9, True)
               Cadena &= " " & Valor

               Valor = Me.Completa(Format(Linea.DescuentoRecargoPorc2, "##0"), 3, True)
               Cadena &= " " & Valor

               Valor = Me.Completa(Format(Linea.DescuentoRecargoPorc1, "##0"), 3, True)
               Cadena &= " " & Valor

               Valor = Me.Completa(Format(Linea.ImporteTotal, "##,###.00"), 9, True)
               Cadena &= " " & Valor

               .WriteLine(Cadena)

               CuentaLineas += 1

            Next
            For I As Integer = CuentaLineas To 59
               .WriteLine(" ")
            Next

            'El formulario esta mal diseñado.. como van a poner el descuento despues del subtotal!!??
            .WriteLine(Space(67) & Me.Completa(Format(Me._oVenta.Subtotal, "###,###.00"), 13, True))
            .WriteLine(Space(67) & Me.Completa(Format(Me._oVenta.DescuentoRecargo, "###,###.00"), 13, True))
            .WriteLine(Space(67) & Me.Completa(Format(Me._oVenta.TotalImpuestos, "###,###.00"), 13, True))
            'TODO: En el futuro Poner las Percepciones.
            .WriteLine(Space(67) & Me.Completa(Format("0.00"), 13, True))
            .WriteLine(" ")
            .WriteLine(Space(67) & Me.Completa(Format(Me._oVenta.ImporteTotal, "###,###.00"), 13, True))

            'Calculo el saldo para imprimirlo
            Dim SaldoActual As Decimal = 0
            SaldoActual = New Reglas.CuentasCorrientes().GetSaldoCliente({New Entidades.Sucursal() With {.Id = Me._oVenta.IdSucursal}},
                                                                         Me._oVenta.Cliente.IdCliente, fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:="TODOS",
                                                                         grabaLibro:=Nothing, comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:="",
                                                                         excluirPreComprobantes:=False, IdCama:=0, IdEmbarcacion:=0)
            '--------------------------------

            '.WriteLine(Me._oVentas.TipoComprobante.DescripcionAbrev & " " & Me._oVentas.LetraComprobante & " " & Me._oVentas.CentroEmisor.ToString() & "-" & Me._oVentas.NumeroComprobante.ToString() & Space(20) & "Saldo Actual en CtaCte: " & SaldoActual.ToString("##,##0.00"))
            .WriteLine(Me._oVenta.TipoComprobante.DescripcionAbrev & " " & Me._oVenta.LetraComprobante & " " & Me._oVenta.CentroEmisor.ToString() & "-" & Me._oVenta.NumeroComprobante.ToString())

            .WriteLine("")

            'EJECT
            '.WriteLine(Chr(12))
            .Write(Chr(12))

         End With

      Catch ex As Exception

         Throw New Exception("Error en impresion de Factura: " & ex.Message)

      End Try

      'cierra
      Archi.Flush()
      Archi.Close()
      Archi.Dispose()

      Dim Cont As Integer
      For Cont = 1 To Me._oVenta.TipoComprobante.CantidadCopias
         MandaImprimirCOPY(mFile, Puerto)
      Next

   End Sub

   Private Sub Factura_Distribuidora_Vinnova(Puerto As String, NombreImpresora As String)

      Dim mFile As String = Entidades.Publicos.DriverBase + "Factura.txt"
      'abre el archivo de texto
      Dim Archi As System.IO.StreamWriter
      Archi = My.Computer.FileSystem.OpenTextFileWriter(mFile, False, System.Text.Encoding.ASCII)

      Dim CuentaLineas As Integer, Cadena As String, Precio As Decimal, DescRec1 As Decimal, DescRec2 As Decimal, TotalLinea As Decimal

      Try

         'Version a Pagina Completa 72 Lineas
         If Me._oVenta.VentasProductos.Count > 17 Then

            'Armar el archivo de texto
            With Archi

               '1
               .WriteLine(Chr(27) & Chr(64) & Chr(27) & Chr(67) & Chr(72))

               '1 ---- Deja la impresora en estado normal, por las dudas ---- 
               '.Write(Chr(27) & Chr(64))              'Inicializa impresora, default
               '.Write(Chr(27) & Chr(50))              'Espacio entre lineas normal
               '.Write(Chr(27) & Chr(80))              'Ancho normal, 10 cpi
               '.Write(Chr(27) & Chr(67) & Chr(36))    'Lineas por hoja 36
               '.WriteLine(" ") 'Hara Falta ?


               '2
               .WriteLine(Me.Completa(Me._oVenta.TipoComprobante.Descripcion.Trim() & Space(30) & Me._oVenta.LetraComprobante, 62, False) & " Fecha: " & Me._oVenta.Fecha.ToString("dd/MM/yyyy"))

               '3
               .WriteLine("")

               '4
               .WriteLine(Me.Completa("Documento NO Valido como Factura", 59, False) & "Numero: " & Me._oVenta.CentroEmisor.ToString("0000") & "-" & Me._oVenta.NumeroComprobante.ToString("00000000"))

               .WriteLine("")

               '5
               .WriteLine(Me.Repetir("-", 80))

               '6
               .WriteLine(Me.Completa("Cliente: " & Me._oVenta.Cliente.NombreCliente, 50, False) & Strings.Left("Telefono: " & Me._oVenta.Cliente.Telefono.Trim() & " " & Me._oVenta.Cliente.Celular.Trim(), 30))

               '7
               .WriteLine(Me.Completa("Direccion: " & Me._oVenta.Cliente.Direccion, 50, False) & Strings.Left("Localidad: " & Me._oVenta.Cliente.NombreLocalidad, 30))

               .WriteLine("")

               '8
               .WriteLine(Me.Repetir("-", 80))

               '9
               .WriteLine("Detalle                                          Cant.   Precio   D/R      Total")

               '10
               .WriteLine(Me.Repetir("-", 80))
               '           DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDsCCCCCCCCsPPPPPPPPsDDDDDDsTTTTTTTT
               '           1234567890123456789012345678901234567890123456 12345678 12345678 123456 12345678
               '           12345678901234567890123456789012345678901234567890123456789012345678901234567890

               CuentaLineas = 12

               For Each Linea As Entidades.VentaProducto In Me._oVenta.VentasProductos

                  Cadena = Me.Completa(Strings.Left(Publicos.NormalizarDescripcion(Linea.Producto.NombreProducto), 45), 45, False)

                  Cadena &= " " & Me.Completa(Linea.Cantidad.ToString("#,##0.00"), 8, True)

                  If Not Me._oVenta.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                     Precio = Decimal.Round(Linea.Precio * (1 + (Linea.AlicuotaImpuesto / 100)), 2)
                  Else
                     Precio = Linea.Precio
                  End If

                  Cadena &= " " & Me.Completa(Precio.ToString("#,##0.00"), 8, True)

                  Cadena &= " " & Me.Completa(Linea.DescuentoRecargoPorc1.ToString("##0.00"), 6, True)

                  DescRec1 = Decimal.Round(Precio * Linea.DescuentoRecargoPorc1 / 100, 2)
                  DescRec2 = Decimal.Round((Precio + DescRec1) * Linea.DescuentoRecargoPorc2 / 100, 2)

                  TotalLinea = Decimal.Round((Precio + DescRec1 + DescRec2) * Linea.Cantidad, 2)

                  Cadena &= " " & Me.Completa(TotalLinea.ToString("##,###.00"), 9, True)

                  .WriteLine(Cadena)

                  CuentaLineas += 1

               Next

               For I As Integer = CuentaLineas To 61
                  .WriteLine(" ")
               Next

               '63
               .WriteLine(Me.Completa(Me.Repetir("=", 10), 80, True))

               '64
               .WriteLine(Me.Completa("Total " & Me.Completa(Me._oVenta.ImporteTotal.ToString("##,##0.00"), 9, True), 80, True))

               '65
               .WriteLine("")

               '66
               .WriteLine(Strings.Left("Observacion: " & Me._oVenta.Observacion, 80))

               '67
               .WriteLine("")

               '68
               .WriteLine("     *** ATENCION: REVISE SU PEDIDO. NO SE ACEPTAN RECLAMOS POSTERIORES ***")

               'EJECT
               '.WriteLine(Chr(12))
               .Write(Chr(12))

               'Utilizo un Total de 69 Lineas, por el margen que deja.

            End With


            'Version a Pagina Completa 36 Lineas
         Else


            'agrega lineas
            With Archi

               '1
               .WriteLine(Chr(27) & Chr(64) & Chr(27) & Chr(67) & Chr(36))

               '1 ---- Deja la impresora en estado normal, por las dudas ---- 
               '.Write(Chr(27) & Chr(64))              'Inicializa impresora, default
               '.Write(Chr(27) & Chr(50))              'Espacio entre lineas normal
               '.Write(Chr(27) & Chr(80))              'Ancho normal, 10 cpi
               '.Write(Chr(27) & Chr(67) & Chr(36))    'Lineas por hoja 36
               '.WriteLine(" ") 'Hara Falta ?


               '2
               .WriteLine(Me.Completa(Me._oVenta.TipoComprobante.Descripcion.Trim() & Space(30) & Me._oVenta.LetraComprobante, 62, False) & " Fecha: " & Me._oVenta.Fecha.ToString("dd/MM/yyyy"))

               '3

               '4
               .WriteLine(Me.Completa("Documento NO Valido como Factura", 59, False) & "Numero: " & Me._oVenta.CentroEmisor.ToString("0000") & "-" & Me._oVenta.NumeroComprobante.ToString("00000000"))


               '5
               .WriteLine(Me.Repetir("-", 80))

               '6
               .WriteLine(Me.Completa("Cliente: " & Me._oVenta.Cliente.NombreCliente, 50, False) & Strings.Left("Telefono: " & Me._oVenta.Cliente.Telefono.Trim() & " " & Me._oVenta.Cliente.Celular.Trim(), 30))

               '7
               .WriteLine(Me.Completa("Direccion: " & Me._oVenta.Cliente.Direccion, 50, False) & Strings.Left("Localidad: " & Me._oVenta.Cliente.NombreLocalidad, 30))

               '8
               .WriteLine(Me.Repetir("-", 80))

               '9
               .WriteLine("Detalle                                          Cant.   Precio   D/R      Total")

               '10
               .WriteLine(Me.Repetir("-", 80))
               '           DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDsCCCCCCCCsPPPPPPPPsDDDDDDsTTTTTTTT
               '           1234567890123456789012345678901234567890123456 12345678 12345678 123456 12345678
               '           12345678901234567890123456789012345678901234567890123456789012345678901234567890

               CuentaLineas = 9

               For Each Linea As Entidades.VentaProducto In Me._oVenta.VentasProductos

                  Cadena = Me.Completa(Strings.Left(Publicos.NormalizarDescripcion(Linea.Producto.NombreProducto), 45), 45, False)

                  Cadena &= " " & Me.Completa(Linea.Cantidad.ToString("#,##0.00"), 8, True)

                  If Not Me._oVenta.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                     Precio = Decimal.Round(Linea.Precio * (1 + (Linea.AlicuotaImpuesto / 100)), 2)
                  Else
                     Precio = Linea.Precio
                  End If

                  Cadena &= " " & Me.Completa(Precio.ToString("#,##0.00"), 8, True)

                  Cadena &= " " & Me.Completa(Linea.DescuentoRecargoPorc1.ToString("##0.00"), 6, True)

                  DescRec1 = Decimal.Round(Precio * Linea.DescuentoRecargoPorc1 / 100, 2)
                  DescRec2 = Decimal.Round((Precio + DescRec1) * Linea.DescuentoRecargoPorc2 / 100, 2)

                  TotalLinea = Decimal.Round((Precio + DescRec1 + DescRec2) * Linea.Cantidad, 2)

                  Cadena &= " " & Me.Completa(TotalLinea.ToString("##,###.00"), 9, True)

                  .WriteLine(Cadena)

                  CuentaLineas += 1

               Next

               For I As Integer = CuentaLineas To 25
                  .WriteLine(" ")
               Next

               '26
               .WriteLine(Me.Completa(Me.Repetir("=", 10), 80, True))

               '27
               .WriteLine(Me.Completa("Total " & Me.Completa(Me._oVenta.ImporteTotal.ToString("##,##0.00"), 9, True), 80, True))

               '28
               .WriteLine("")

               '29
               .WriteLine(Strings.Left("Observacion: " & Me._oVenta.Observacion, 80))

               '30
               .WriteLine("")

               '31
               .WriteLine("     *** ATENCION: REVISE SU PEDIDO. NO SE ACEPTAN RECLAMOS POSTERIORES ***")

               'EJECT
               '.WriteLine(Chr(12))
               .Write(Chr(12))

               'Utilizo un Total de 69 Lineas, por el margen que deja.

            End With

         End If


      Catch ex As Exception

         Throw New Exception("Error en impresion de Factura: " & ex.Message)

      End Try

      'cierra
      Archi.Flush()
      Archi.Close()
      Archi.Dispose()

      Dim Cont As Integer

      For Cont = 1 To Me._oVenta.TipoComprobante.CantidadCopias
         If Puerto.Contains("LPT") Or Puerto.Contains("COM") Then
            Me.MandaImprimirCOPY(mFile, Puerto)
         Else
            Me.MandaImprimirPRINT(NombreImpresora, mFile)
         End If
      Next

   End Sub

   Private Sub RemitoTransportista_CentralAutopartes(Puerto As String, Copia As Integer)

      'abre el archivo de texto
      Dim Archi As System.IO.StreamWriter
      Archi = My.Computer.FileSystem.OpenTextFileWriter(Entidades.Publicos.DriverBase + "Remito.txt", False, System.Text.Encoding.ASCII)

      Try

         'agrega lineas
         With Archi
            .WriteLine(Chr(27) & Chr(64) & Chr(27) & Chr(67) & Chr(72))
            .WriteLine(Me.Repetir("=", 80))
            .WriteLine(Space(31) & Reglas.Publicos.NombreEmpresaImpresion)
            .WriteLine("R E M I T O                           [X]         NUMERO: " & Me._oVenta.CentroEmisor.ToString("0000") & "-" & Me._oVenta.NumeroComprobante.ToString("00000000"))
            '           12345678901234567890123456789012345678901234567890
            .WriteLine("")
            .WriteLine(Completa(actual.Sucursal.Direccion, 49, False) & " FECHA : " & Me._oVenta.Fecha.ToString("dd/MM/yyyy"))
            .WriteLine(Completa(actual.Sucursal.Localidad.IdLocalidad.ToString() & " - " & actual.Sucursal.Localidad.NombreLocalidad, 49, False) & " C.U.I.T         23-12720031-9")
            .WriteLine(Completa("TEL/FAX: " & actual.Sucursal.Telefono, 49, False) & " INGR. BRUTOS     021-720193-6")
            .WriteLine("I.V.A. RESPONSABLE INSCRIPTO                      INICIO ACTIVIDADES " & actual.Sucursal.FechaInicioActiv.ToString("dd/MM/yyyy"))
            .WriteLine("")
            .WriteLine("                     --DOCUMENTO NO VALIDO COMO FACTURA--")

            .WriteLine(Me.Repetir("=", 80))

            .WriteLine("CLIENTE    : " & Me._oVenta.Cliente.NombreCliente & " (" & Me._oVenta.Cliente.CodigoCliente & ")")
            .WriteLine("DOMICILIO  : " & Me._oVenta.Cliente.Direccion & " - " & Me._oVenta.Cliente.NombreLocalidad)
            .WriteLine("INSCRIPCION: " & Completa(Me._oVenta.Cliente.CategoriaFiscal.NombreCategoriaFiscal, 40, False) & "CUIT: " & Me._oVenta.Cliente.Cuit)
            .WriteLine(Me.Repetir("=", 80))
            .WriteLine("TRANSPORTE : " & Completa(Me._oVenta.Transportista.NombreTransportista, 67, False))
            .WriteLine("DOMICILIO  : " & Me._oVenta.Transportista.DireccionTransportista & " - " & Me._oVenta.Transportista.NombreLocalidad)
            .WriteLine("INSCRIPCION: " & Completa(Me._oVenta.Transportista.CategoriaFiscal.NombreCategoriaFiscal, 40, False) & "CUIT: " & Me._oVenta.Transportista.CuitTransportista)

            Dim Cadena As String
            'Cadena = "PEDIDO     : " & Me._oVenta.NumeroLote.ToString()

            'If Me._oVenta.Facturables.Count > 0 Then
            '   Cadena &= ", FACTURA/S:"
            '   For Each Linea As Entidades.Venta In Me._oVenta.Facturables
            '      'NO pongo el Emisor porque es el mismo
            '      Cadena &= " '" & Linea.LetraComprobante & "' " & Linea.NumeroComprobante
            '   Next
            'End If

            Dim stb = New StringBuilder()
            stb.AppendFormat("PEDIDO     : {0}", Me._oVenta.NumeroLote)
            If Me._oVenta.Invocados.Count > 0 Then
               stb.AppendFormat(", FACTURA/S:{0}", String.Join(" ", Me._oVenta.Invocados.ToList().ConvertAll(Function(v) String.Format("'{0}' {1}", v.LetraInvocado, v.NumeroComprobanteInvocado))))
            End If

            Cadena = stb.ToString()
            .WriteLine(Completa(Cadena, 80, False))


            .WriteLine(Me.Repetir("-", 80))
            .WriteLine("CODIGO        A R T I C U L O S                                         CANTIDAD")
            '           1234567890123 123456789012345678901234567890123456789012345678901234567890 12345
            '           12345678901234567890123456789012345678901234567890123456789012345678901234567890
            .WriteLine(Me.Repetir("-", 80))


            '.WriteLine(Chr(27) & Chr(77))

            Dim CuentaLineas As Integer, Valor As String

            CuentaLineas = 23
            For Each Linea As Entidades.VentaProducto In Me._oVenta.VentasProductos

               Cadena = Me.Completa(Linea.Producto.IdProducto, 13, False)

               Cadena &= " " & Me.Completa(Publicos.NormalizarDescripcion(Linea.Producto.NombreProducto.Trim), 60, False)

               Valor = Me.Completa(Format(Linea.Cantidad, "#,###"), 5, True)

               Cadena &= " " & Valor

               .WriteLine(Cadena)

               CuentaLineas += 1

            Next

            If Me._oVenta.VentasObservaciones.Count > 0 Then

               .WriteLine(Me.Repetir("-", 80))
               .WriteLine("OBSERVACIONES / DETALLE DE BULTOS")
               .WriteLine(Me.Repetir("-", 80))
               CuentaLineas += 3

               For Each Linea As Entidades.VentaObservacion In Me._oVenta.VentasObservaciones
                  Cadena = Me.Completa(Linea.Observacion, 80, False)
                  .WriteLine(Cadena)
                  CuentaLineas += 1
               Next

            End If

            For I As Integer = CuentaLineas To 64
               .WriteLine(" ")
            Next

            '.WriteLine(Chr(27) & Chr(80))
            .WriteLine(Me.Repetir("-", 80))
            .WriteLine("TOTAL DE BULTOS : " & Me._oVenta.Bultos.ToString("#,###")) '12
            .WriteLine("VALOR DECLARADO : " & Me._oVenta.ValorDeclarado.ToString("#,##0.00")) '12

            Select Case Copia
               Case 1
                  .WriteLine("ORIGINAL")
               Case 2
                  .WriteLine("DUPLICADO")
               Case 3
                  .WriteLine("TRIPLICADO")
               Case 4
                  .WriteLine("CUADRUPLICADO")
               Case Else
                  .WriteLine("QUINTUPLICADO/OTROS")
            End Select

            .WriteLine(Me.Repetir("=", 80))
            'EJECT
            .Write(Chr(12))

         End With

      Catch ex As Exception

         Throw New Exception("Error en la impresion del Remito Transportista: " & ex.Message)

      End Try

      'cierra
      Archi.Flush()
      Archi.Close()
      Archi.Dispose()

      MandaImprimirCOPY(Entidades.Publicos.DriverBase + "Remito.txt", Puerto)

   End Sub

   Private Function Completa(Cadena As String, LongCampo As Integer, A_La_Derecha As Boolean) As String

      If A_La_Derecha Then

         If Len(Cadena) < LongCampo Then
            LongCampo = LongCampo - Len(Cadena)
            Cadena = Space(LongCampo) & Cadena
         End If

         Return Cadena
      Else
         Cadena = Cadena & Space(LongCampo)
         'Dim Dife As Integer
         'Dife = LongCampo - Len(Cadena)
         Return Strings.Left(Cadena, LongCampo)
      End If

   End Function

   Private Function Repetir(Caracter As String, repeticion As Integer) As String

      Dim Cadena As String = ""

      For i As Integer = 1 To repeticion
         Cadena &= Caracter
      Next

      Return Cadena

   End Function

   Private Sub MandaImprimirCOPY(Archivo As String, Puerto As String)

      Dim Orden As String = String.Empty

      Try

         'Ejemplo: COPY c:\factura.txt LPT1
         Orden = "COPY " & Archivo & " " & Puerto

         Dim Archi As System.IO.StreamWriter
         Archi = My.Computer.FileSystem.OpenTextFileWriter(Entidades.Publicos.DriverBase + "PRNSIGA.BAT", False, System.Text.Encoding.ASCII)
         Archi.AutoFlush = True
         Archi.WriteLine(Orden)
         Archi.Close()
         Archi.Dispose()


         Dim Accion As String = Entidades.Publicos.DriverBase + "PRNSIGA.BAT"

         '    Accion = Orden

         Shell(Accion, AppWinStyle.NormalFocus)

      Catch ex As Exception

         Throw New Exception("Error en MandaImprimirCOPY." & ex.Message & " Orden: " & Orden)

      End Try

   End Sub

   Private Sub MandaImprimirPRINT(NombreImpresora As String, Archivo As String)

      Dim Orden As String = String.Empty

      Try

         'Ejemplo: print /d:\\TERRA-PC\FX890 c:\Factura.txt
         Orden = "PRINT /d:" & NombreImpresora & " " & Archivo

         Dim Archi As System.IO.StreamWriter
         Archi = My.Computer.FileSystem.OpenTextFileWriter(Entidades.Publicos.DriverBase + "PRNSIGA.BAT", False, System.Text.Encoding.ASCII)
         Archi.AutoFlush = True
         Archi.WriteLine(Orden)
         Archi.Close()
         Archi.Dispose()


         Dim Accion As String = Entidades.Publicos.DriverBase + "PRNSIGA.BAT"

         '    Accion = Orden

         Shell(Accion, AppWinStyle.NormalFocus)

      Catch ex As Exception

         Throw New Exception("Error en MandaImprimirPRINT." & ex.Message & " Orden: " & Orden)

      End Try

   End Sub

   Private Sub Espera(MiliSegundos As Integer)

      Dim d1 As DateTime = DateTime.Now
      Dim d2 As DateTime = DateTime.Now
      Dim ts As TimeSpan = Nothing

      Do While True
         System.Windows.Forms.Application.DoEvents()
         d2 = DateTime.Now
         ts = d2.Subtract(d1)
         If ts.Milliseconds > MiliSegundos Then
            Exit Do
         End If
      Loop

   End Sub

#End Region

End Class

Public Class EstadoImpresion

   Public OK As Boolean 'true or false
   Public NumeroComprobante As Long   'Obtenido de la Impresora fiscal o de una tabla (segun corresponda)
   Public MensajeError As String 'error

End Class
