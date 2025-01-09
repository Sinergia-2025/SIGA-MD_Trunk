Imports LibreriaFiscalV2
Imports LibreriaFiscalV2.ControladorFiscal.EstadosFiscales

Public Class ImpresionFiscalV2
   Implements IDisposable, Reglas.FiscalV2.IObtenerAuditoriaPorFecha, Reglas.FiscalV2.IObtenerAuditoriaPorZeta, Reglas.FiscalV2.IInformeAFIP

#Region "Campos"

   'Private Estado As EstadoImpresion = New EstadoImpresion()

   Private _controladorFiscal As LibreriaFiscalV2.ControladorFiscal
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _comprobante As Entidades.Venta
   Private _maximoCaracteresItem As Integer = 20
   Private _modeloFiscal As ControladorFiscal.ModelosFiscales

   Private _quitar_IVA_FacturaB As Boolean = False
   Private disposedValue As Boolean
#End Region

   Public Property ControladorFiscal() As LibreriaFiscalV2.ControladorFiscal
      Get
         Return _controladorFiscal
      End Get
      Set(value As LibreriaFiscalV2.ControladorFiscal)
         _controladorFiscal = value
      End Set
   End Property


   ''' <summary>
   ''' asignar entidad comprobante para tener los datos a mano al imprimir
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Comprobante() As Entidades.Venta
      Get
         Return _comprobante
      End Get
      Set(value As Entidades.Venta)
         _comprobante = value
      End Set
   End Property


   ''' <summary>
   ''' Crea una instancia de la impresora para imprimir.
   ''' </summary>
   ''' <param name="impresora">Es la impresora del sistema.</param>
   ''' <remarks></remarks>
   Public Sub New(impresora As Entidades.Impresora)
      Me.New(ConvertirStringAModeloFiscal(impresora.Modelo), ConvertirPuertoStringAInteger(impresora.Puerto), impresora.Velocidad, impresora.MaximoCaracteresItem)
   End Sub

   ''' <summary>
   ''' Crea una instancia de la impresora para imprimir.
   ''' </summary>
   ''' <param name="modelo">Es el modelo de la impresora Fiscal, por ejemp. HASAR, EPSON, etc.</param>
   ''' <param name="puerto">El puerto de conexión. Por ejem. COM1, COM2, LPT1, etc.</param>
   ''' <param name="velocidad">Velocidad de conexión</param>
   ''' <param name="maximoCaracteresItem">Cantidad máxima de caracteres para truncar en la descripción del producto</param>
   ''' <remarks></remarks>
   Private Sub New(modelo As String, puerto As String, velocidad As Integer, maximoCaracteresItem As Integer)
      Me.New(ConvertirStringAModeloFiscal(modelo), ConvertirPuertoStringAInteger(puerto), velocidad, maximoCaracteresItem)
   End Sub

   ''' <summary>
   ''' Crea una instancia de la impresora para imprimir.
   ''' </summary>
   ''' <param name="modeloFiscal">Es el modelo de la impresora Fiscal, por ejemp. HASAR, EPSON, etc.</param>
   ''' <param name="puerto">El puerto de conexión. Por ejem. 1, 2, 3, etc.</param>
   ''' <param name="velocidad">Velocidad de conexión</param>
   ''' <param name="maximoCaracteresItem">Cantidad máxima de caracteres para truncar en la descripción del producto</param>
   ''' <remarks></remarks>
   Private Sub New(modeloFiscal As LibreriaFiscalV2.ControladorFiscal.ModelosFiscales, puerto As Integer, velocidad As Integer, maximoCaracteresItem As Integer)
      Me._maximoCaracteresItem = maximoCaracteresItem
      Me._modeloFiscal = modeloFiscal

      Me._controladorFiscal = LibreriaFiscalV2.ControladorFiscal.CrearInstancia(modeloFiscal)
      Me._controladorFiscal.Timeout = 2000

      'SPC - 22/10/2020 - Pareciera ser que ya no es necesario.
      '                   Si fuese a ser necesario según versión de Firmware habrá que parametrizar en cada impresora
      If modeloFiscal = LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.EPSON_TM900AF Then
         _quitar_IVA_FacturaB = True
      End If
      Me._controladorFiscal.Comenzar(puerto, velocidad)

      'If modeloFiscal = LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.EPSON_TM900AF Then
      '   _quitar_IVA_FacturaB = True
      '   Me._controladorFiscal.Comenzar(puerto)
      'ElseIf modeloFiscal = LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.HASAR_250_2G Then
      '   Me._controladorFiscal.Comenzar(puerto)
      'Else
      '   Me._controladorFiscal.Comenzar(puerto, LibreriaFiscalV2.ControladorFiscal.ModosTrabajoLibreria.SINCRONO)
      'End If

      Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

   End Sub

   Public Sub ImprimirFiscal(comprobante As Entidades.Venta)

      Try

         Dim ArchivoLOG As String = Entidades.Publicos.CarpetaLOGs & Reglas.Publicos.CuitEmpresa & "_" &
                                        comprobante.TipoComprobante.DescripcionAbrev & "_" &
                                        comprobante.LetraComprobante & "_" &
                                        comprobante.CentroEmisor.ToString("0000") & "_" &
                                        Date.Now.ToString("HHmmss") + ".log"

         Dim ValorImpuestoInterno As Decimal = 0

         With Me._controladorFiscal

            If comprobante.Impresora.GrabarLOGs Then
               .LoggerEnabled(ArchivoLOG) = True
            End If

            If comprobante.Cliente.Cuit <> "" Then

               .DatosCliente(Publicos.NormalizarDescripcion(comprobante.Cliente.NombreCliente),
                             comprobante.Cliente.Cuit,
                             Me.GetTipoDocumento("CUIT"),
                             Me.GetTipoDeResponsabilidad(comprobante.Cliente.CategoriaFiscal.IdCategoriaFiscal),
                             Publicos.NormalizarDescripcion(comprobante.Cliente.Direccion))

               'El Comprobante Asociado se requiere cuando es una NC/ND. Debe ser el comprobante que se invoca
               For Each invocado In comprobante.Invocados
                  Try
                     .CargarComprobanteAsociado(GetTipoDocumentoFiscal(invocado.Invocado.IdTipoComprobante, invocado.Invocado.Letra),
                                                invocado.Invocado.CentroEmisor, Convert.ToInt32(invocado.Invocado.NumeroComprobante))
                  Catch ex As TipoDocumentoFiscalNotImplementedException
                     'Esta excepción se da cuando no encuentra un tipo de documento fiscal para el invocado.
                     'En caso de que esto suceda, directamente no agrego el comprobante asociado y continuo con el siguiente.
                  End Try
               Next
            Else

               .DatosCliente(Publicos.NormalizarDescripcion(comprobante.Cliente.NombreCliente),
                             comprobante.Cliente.NroDocCliente.ToString(),
                             Me.GetTipoDocumento(comprobante.Cliente.TipoDocCliente),
                             Me.GetTipoDeResponsabilidad(comprobante.Cliente.CategoriaFiscal.IdCategoriaFiscal),
                             Publicos.NormalizarDescripcion(comprobante.Cliente.Direccion))

            End If

            Dim tipoComp As LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales

            tipoComp = Me.GetTipoDocumentoFiscal(comprobante.TipoComprobante.IdTipoComprobante, comprobante.LetraComprobante)

            Dim pf As PaqueteFiscal
            pf = .AbrirComprobanteFiscal(tipoComp)

            If Not String.IsNullOrWhiteSpace(comprobante.CategoriaFiscal.LeyendaCategoriaFiscal) Then
               '.ImprimirTextoFiscal(comprobante.CategoriaFiscal.LeyendaCategoriaFiscal)
               Dim descr = Publicos.NormalizarDescripcion(comprobante.CategoriaFiscal.LeyendaCategoriaFiscal).DivideEnPartes(50)
               For i = 0 To descr.Length - 1
                  .ImprimirTextoFiscal(descr(i))
               Next
               .ImprimirTextoFiscal(".")
            End If

            Dim precio As Decimal = 0
            Dim importeBruto As Decimal = 0
            Dim importeBrutoParaDescuento = 0D
            For Each item As Entidades.VentaProducto In comprobante.VentasProductos

               'Hay que enviarlo con valor Unitario.
               ValorImpuestoInterno = item.ImporteImpuestoInterno / item.Cantidad
               precio = item.PrecioNeto

               If Not Reglas.Publicos.Facturacion.FacturacionTicketIncluyeRecargoGeneral Then
                  precio = item.Precio + (item.DescuentoRecargo / item.Cantidad)
               End If
               importeBrutoParaDescuento += (item.Precio * item.Cantidad) + item.DescuentoRecargo

               'Según Pedro Porcel debemos mandar el precio con/sin impuestos dependiendo de si el comprobante discrimina o no
               'item.PrecioNeto tiene el precio con IVA si es MO, CF, etc. y sin IVA si es RI
               '        "en el caso de comprobantes que NO discriminan: precio final, % iva e impuestos internos"
               '        "en el caso de comprobantes que SI discriminan: precio neto, % iva e impuestos internos"
               '' ''If tipoComp = LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.TICKET_C Then
               '' ''   precio = item.PrecioNeto
               '' ''Else
               '' ''   precio = (item.PrecioNeto - ValorImpuestoInterno) / (1 + (item.AlicuotaImpuesto / 100))
               '' ''End If

               'El comportamiento de EPSON 2G es diferente al de HASAR 2G.
               'EPSON 2G espera que se le envie el precio del producto sin impuestos en FACTURA_B igual que una FACTURA_A
               If _quitar_IVA_FacturaB Then
                  If tipoComp = LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.FACTURA_B Or
                     tipoComp = LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.NOTA_CREDITO_BC Or
                     tipoComp = LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.NOTA_DEBITO_B Then
                     precio = (precio - ValorImpuestoInterno) / (1 + (item.AlicuotaImpuesto / 100))
                  End If
               End If

               Dim descr = Publicos.NormalizarDescripcion(item.Producto.NombreProducto).DivideEnPartes(20)
               For i = 0 To descr.Length - 2
                  .ImprimirTextoFiscal(descr(i))
               Next

               '.ImprimirItem(Publicos.NormalizarDescripcion(item.Producto.NombreProducto),
               .ImprimirItem(descr(descr.Length - 1),
                             item.Cantidad,
                             precio,
                             item.AlicuotaImpuesto,
                             ValorImpuestoInterno)
               importeBruto += precio * item.Cantidad
            Next

            If Not Reglas.Publicos.Facturacion.FacturacionTicketIncluyeRecargoGeneral AndAlso comprobante.DescuentoRecargoPorc <> 0 Then
               'Dim valorDescuentoRecargo As Decimal = importeBruto * comprobante.DescuentoRecargoPorc / 100
               Dim valorDescuentoRecargo As Decimal = importeBrutoParaDescuento * comprobante.DescuentoRecargoPorc / 100
               If valorDescuentoRecargo <> 0 Then
                  Dim mensajeDescuentoRecargo As String = If(valorDescuentoRecargo < 0, "D E S C U E N T O", "R E C A R G O")

                  .DescuentoGeneral(mensajeDescuentoRecargo, valorDescuentoRecargo)
               End If
            End If

            .ImprimirPago(comprobante.FormaPago.DescripcionFormasPago, comprobante.ImporteTotal)

            If Not comprobante.Impresora.CierreFiscalEstandar Or (comprobante.Impresora.Modelo = "LX-300F+" And comprobante.TipoComprobante.CoeficienteValores < 0) Then
               pf = .CerrarComprobanteNoFiscalHomologado()
            Else
               pf = .CerrarComprobanteFiscal()
            End If

            comprobante.NumeroComprobante = Int64.Parse(pf.ParseInteger(3).ToString())

            If comprobante.Impresora.AbrirCajonDinero And comprobante.TipoComprobante.AfectaCaja Then
               .AbrirGaveta()
            End If

            Try
               .Finalizar()
            Catch ex As Exception
               'no hago nada porque ya tomo el nro.
            End Try


            'Estado.OK = True
            'Estado.MensajeError = ""
            'Estado.NumeroComprobante = Long.Parse(.Respuesta.ParseInteger(3).ToString())

            If IO.File.Exists(ArchivoLOG) Then

               'Le cambio el nombre porque ya esta la numeracion del comprobante.
               Dim ArchivoLOGfinal As String = Entidades.Publicos.CarpetaLOGs & Reglas.Publicos.CuitEmpresa & "_" &
                                comprobante.TipoComprobante.DescripcionAbrev & "_" &
                                comprobante.LetraComprobante & "_" &
                                comprobante.CentroEmisor.ToString("0000") & "_" &
                                comprobante.NumeroComprobante.ToString("00000000") + ".log"

               System.IO.File.Move(ArchivoLOG, ArchivoLOGfinal)

            End If


         End With

      Catch ex As Exception

         Throw

         '   Estado.OK = False
         '   Estado.MensajeError = ex.Message
         '   Estado.NumeroComprobante = 0

      Finally

         Me._controladorFiscal = Nothing

         '   'Return Estado

      End Try

   End Sub

   Public Sub ImprimirNoFiscal(comprobante As Entidades.Venta)

      Try

         Dim ArchivoLOG As String = Entidades.Publicos.CarpetaLOGs & Reglas.Publicos.CuitEmpresa & "_" &
                                        comprobante.TipoComprobante.DescripcionAbrev & "_" &
                                        comprobante.LetraComprobante & "_" &
                                        comprobante.CentroEmisor.ToString("0000") & "_" &
                                        Date.Now.ToString("HHmmss") + ".log"


         Dim Cliente As String

         With Me._controladorFiscal

            If comprobante.Impresora.GrabarLOGs Then
               .LoggerEnabled(ArchivoLOG) = True
            End If

            Cliente = comprobante.Cliente.NombreCliente

            'Vale la pena ?
            If comprobante.Cliente.Cuit <> "" Then
               Cliente = Cliente & ", CUIT: " & comprobante.Cliente.Cuit
            End If

            .AbrirComprobanteNoFiscal()

            .ImprimirTextoNoFiscal(Reglas.Publicos.NombreFantasia)
            .ImprimirTextoNoFiscal(Reglas.Publicos.DireccionEmpresa)
            .ImprimirTextoNoFiscal(comprobante.TipoComprobante.Descripcion.Trim() & " '" & comprobante.LetraComprobante & "'")
            .ImprimirTextoNoFiscal("Nº " & comprobante.CentroEmisor.ToString("0000") & " - " & comprobante.NumeroComprobante.ToString("00000000") & " Fecha: " & comprobante.Fecha.ToString("dd/MM/yyyy"))

            .ImprimirTextoNoFiscal("Producto / Cantidad / Precio / Importe")

            For Each item As Entidades.VentaProducto In comprobante.VentasProductos

               .ImprimirTextoNoFiscal(Publicos.NormalizarDescripcion(item.Producto.NombreProducto))
               .ImprimirTextoNoFiscal(item.Cantidad.ToString("##,##0.00") & " x $ " & item.PrecioNeto.ToString("##,##0.00") & " = $ " & item.ImporteTotal.ToString("##,##0.00"))

            Next

            If comprobante.DescuentoRecargo <> 0 Then
               .ImprimirTextoNoFiscal("Desc/Rec: " & comprobante.ImporteTotal.ToString("##,##0.00"))

            End If

            .ImprimirTextoNoFiscal("TOTAL: " & comprobante.ImporteTotal.ToString("##,##0.00"))

            .ImprimirTextoNoFiscal("Pago: " & comprobante.FormaPago.DescripcionFormasPago)

            .CerrarComprobanteNoFiscal()

            comprobante.NumeroComprobante = Long.Parse(.Respuesta.ParseInteger(3).ToString())

            If comprobante.Impresora.AbrirCajonDinero And comprobante.TipoComprobante.AfectaCaja Then
               .AbrirGaveta()
            End If

            .Finalizar()

            'Estado.OK = True
            'Estado.MensajeError = ""
            'Estado.NumeroComprobante = Long.Parse(.Respuesta.ParseInteger(3).ToString())

            If System.IO.File.Exists(ArchivoLOG) Then

               'Le cambio el nombre porque ya esta la numeracion del comprobante.
               Dim ArchivoLOGfinal As String = Entidades.Publicos.CarpetaLOGs & Reglas.Publicos.CuitEmpresa & "_" &
                                comprobante.TipoComprobante.DescripcionAbrev & "_" &
                                comprobante.LetraComprobante & "_" &
                                comprobante.CentroEmisor.ToString("0000") & "_" &
                                comprobante.NumeroComprobante.ToString("00000000") + ".log"

               System.IO.File.Move(ArchivoLOG, ArchivoLOGfinal)

            End If


         End With

      Catch ex As Exception

         Throw ex

         '   Estado.OK = False
         '   Estado.MensajeError = ex.Message
         '   Estado.NumeroComprobante = 0

      Finally

         Me._controladorFiscal = Nothing

         '   'Return Estado

      End Try

   End Sub

   Private Function GetTipoDeResponsabilidad(idCategoriaFiscal As Short) As LibreriaFiscalV2.ControladorFiscal.TiposDeResponsabilidades
      Select Case idCategoriaFiscal
         Case 1
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeResponsabilidades.CONSUMIDOR_FINAL
         Case 2
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeResponsabilidades.RESPONSABLE_INSCRIPTO
         Case 4
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeResponsabilidades.RESPONSABLE_EXENTO
         Case 5
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeResponsabilidades.RESPONSABLE_EXENTO
         Case 6
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeResponsabilidades.MONOTRIBUTO
         Case Else
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeResponsabilidades.CONSUMIDOR_FINAL
      End Select
   End Function

   Private Function GetTipoDocumento(tipoDoc As String) As LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento
      Select Case tipoDoc
         Case "DNI"
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_DNI
         Case "CUIT"
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_CUIT
         Case "CUIL"
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_CUIL
         Case "PASAPORTE"
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_PASAPORTE
         Case "LC"
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_LC
         Case "CI"
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_CI
         Case "LE"
            Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_LE
         Case Else
            If Me._controladorFiscal.Modelo.ToString.Contains("EPSON") Then
               Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_DNI
            Else
               Return LibreriaFiscalV2.ControladorFiscal.TiposDeDocumento.TIPO_NINGUNO
            End If
      End Select
   End Function

   Private Function GetTipoDocumentoFiscal(documento As String, letra As String) As LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales
      Select Case documento
         Case "FACT-F" 'Factura Fiscal
            Select Case letra
               Case "A"
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.FACTURA_A
               Case "B"
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.FACTURA_B
            End Select
         Case "NCRED-F" 'N. de Credito Fiscal
            Select Case letra
               Case "A"
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.NOTA_CREDITO_A
               Case "B"
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.NOTA_CREDITO_BC
               Case Else
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.NOTA_CREDITO_BC
            End Select
         Case "NDEB-F" 'N. de Debito Fiscal
            Select Case letra
               Case "A"
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.NOTA_DEBITO_A
               Case "B"
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.NOTA_DEBITO_B
            End Select
         Case "TCK-FACT-F" 'Ticket-Factura Fiscal
            Select Case letra
               Case "A"
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.TICKET_FACTURA_A
               Case "B"
                  Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.TICKET_FACTURA_B
            End Select
         Case "TICKET-F" 'Ticket Fiscal
            Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.TICKET_C
         Case "TICKET" 'Ticket Fiscal
            Return LibreriaFiscalV2.ControladorFiscal.DocumentosFiscales.TICKET_C
      End Select
      Throw New TipoDocumentoFiscalNotImplementedException(String.Format("No existe Tipo Documento Fiscal para {0} {1}", documento, letra))
   End Function

   Private Class TipoDocumentoFiscalNotImplementedException
      Inherits NotImplementedException
      Public Sub New(mensaje As String)
         MyBase.New(mensaje)
      End Sub
   End Class

   Public Function CierreX() As String

      Try

         Me._controladorFiscal.ReporteX()

         If Me._controladorFiscal.HuboErrorFiscal Then
            Throw New Exception(Me.GetDetalleErrorFiscal())
         End If

         If Me._controladorFiscal.HuboErrorImpresor Then
            Throw New Exception(Me.GetDetalleErrorImpresor())
         End If

         'devuelve el nro. del Cierre Z
         Dim nro As Integer = Me._controladorFiscal.Respuesta.ParseInteger(3)

         Return "Cierre X Nro. " + nro.ToString() + " realizado EXITOSAMENTE !!!"

      Catch ex As Exception
         Throw ex

      Finally
         Try
            Me._controladorFiscal.Finalizar()   'Libera el Puerto
         Catch ex As Exception
         End Try
         Me._controladorFiscal = Nothing

      End Try

   End Function

   Public Function CierreZ() As String

      Try

         Dim pf = Me._controladorFiscal.ReporteZ()

         If Me._controladorFiscal.HuboErrorFiscal Then
            Throw New Exception(Me.GetDetalleErrorFiscal())
         End If

         If Me._controladorFiscal.HuboErrorImpresor Then
            Throw New Exception(Me.GetDetalleErrorImpresor())
         End If


         'devuelve el nro. del Cierre Z
         Dim nro As Integer = 0

         Try
            nro = Me._controladorFiscal.Respuesta.ParseInteger(3)
         Catch ex As Exception
            'no hace nada para que no le falle al usuario
         End Try

         If nro <> 0 Then
            Return "Cierre Z Nro. " + nro.ToString() + " realizado EXITOSAMENTE !!!"
         Else
            Return "Cierre Z realizado EXITOSAMENTE !!!"

         End If

      Catch ex As Exception
         Throw ex

      Finally
         Try
            Me._controladorFiscal.Finalizar()   'Libera el Puerto
         Catch ex As Exception
         End Try

         Me._controladorFiscal = Nothing

      End Try

   End Function

   Public Function CierreZReimprimir(NroZetaDesde As Long, NroZetaHasta As Long, DatosGlobales As Boolean) As String

      Try

         Me._controladorFiscal.ReporteZPorNumeros(NroZetaDesde, NroZetaHasta, DatosGlobales)

         If Me._controladorFiscal.HuboErrorFiscal Then
            Throw New Exception(Me.GetDetalleErrorFiscal())
         End If

         If Me._controladorFiscal.HuboErrorImpresor Then
            Throw New Exception(Me.GetDetalleErrorImpresor())
         End If

         Return "Informe de Cierre Z realizado EXITOSAMENTE !!!"

      Catch ex As Exception
         Throw ex

      Finally
         Try
            Me._controladorFiscal.Finalizar()   'Libera el Puerto
         Catch ex As Exception
         End Try
         Me._controladorFiscal = Nothing

      End Try

   End Function

   Public ReadOnly Property HayComprobanteFiscalAbierto() As Boolean
      Get
         ControladorFiscal.SolicitarEstado()
         Return ControladorFiscal.Respuesta.EstadoFiscal(DOCUMENTO_ABIERTO) And ControladorFiscal.Respuesta.EstadoFiscal(DOCUMENTO_FISCAL_ABIERTO)
      End Get
   End Property

   Public Sub ImprimirFiscalPie(comprobante As Entidades.Venta)

      Try

         Dim ArchivoLOG As String = Entidades.Publicos.CarpetaLOGs & Reglas.Publicos.CuitEmpresa & "_" &
                                        comprobante.TipoComprobante.DescripcionAbrev & "_" &
                                        comprobante.LetraComprobante & "_" &
                                        comprobante.CentroEmisor.ToString("0000") & "_" &
                                        Date.Now.ToString("HHmmss") + ".log"


         With Me._controladorFiscal

            'If Comprobante.Impresora.GrabarLOGs Then
            '   .LoggerEnabled(ArchivoLOG) = True
            'End If

            .ImprimirPago(comprobante.FormaPago.DescripcionFormasPago, comprobante.ImporteTotal)

            If comprobante.Impresora.CierreFiscalEstandar Then
               .CerrarComprobanteFiscal()
            Else
               .CerrarComprobanteNoFiscalHomologado()
            End If

            comprobante.NumeroComprobante = Long.Parse(.Respuesta.ParseInteger(3).ToString())

            If comprobante.Impresora.AbrirCajonDinero And comprobante.TipoComprobante.AfectaCaja Then
               .AbrirGaveta()
            End If

            .Finalizar()

            'Estado.OK = True
            'Estado.MensajeError = ""
            'Estado.NumeroComprobante = Long.Parse(.Respuesta.ParseInteger(3).ToString())

            If System.IO.File.Exists(ArchivoLOG) Then

               'Le cambio el nombre porque ya esta la numeracion del comprobante.
               Dim ArchivoLOGfinal As String = Entidades.Publicos.CarpetaLOGs & Reglas.Publicos.CuitEmpresa & "_" &
                                comprobante.TipoComprobante.DescripcionAbrev & "_" &
                                comprobante.LetraComprobante & "_" &
                                comprobante.CentroEmisor.ToString("0000") & "_" &
                                comprobante.NumeroComprobante.ToString("00000000") + ".log"

               System.IO.File.Move(ArchivoLOG, ArchivoLOGfinal)

            End If


         End With

      Catch ex As Exception

         Throw ex

         '   Estado.OK = False
         '   Estado.MensajeError = ex.Message
         '   Estado.NumeroComprobante = 0

         'Finally

         '   'Return Estado

      End Try

   End Sub

   Public Function AbrirComprobanteFiscal() As Boolean

      Try

         With ControladorFiscal

            If Comprobante.Cliente.Cuit <> "" Then

               .DatosCliente(Comprobante.Cliente.NombreCliente,
                             Comprobante.Cliente.Cuit,
                             Me.GetTipoDocumento("CUIT"),
                             Me.GetTipoDeResponsabilidad(Comprobante.Cliente.CategoriaFiscal.IdCategoriaFiscal),
                             Comprobante.Cliente.Direccion)

            Else

               .DatosCliente(Comprobante.Cliente.NombreCliente,
                             Comprobante.Cliente.NroDocCliente.ToString(),
                             Me.GetTipoDocumento(Comprobante.Cliente.TipoDocCliente),
                             Me.GetTipoDeResponsabilidad(Comprobante.Cliente.CategoriaFiscal.IdCategoriaFiscal),
                             Comprobante.Cliente.Direccion)

            End If

            .AbrirComprobanteFiscal(Me.GetTipoDocumentoFiscal(Comprobante.TipoComprobante.IdTipoComprobante, Comprobante.LetraComprobante))

         End With
      Catch ex As Exception
         Throw ex 'ver lo que te dije acerca de la InnerException!!!!!
      End Try
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function ImprimirTextoFiscal() As Boolean

      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function ImprimirItemFiscal(item As Entidades.VentaProducto) As Boolean
      Try
         With ControladorFiscal
            .ImprimirItem(Publicos.NormalizarDescripcion(item.Producto.NombreProducto),
                            item.Cantidad,
                            item.PrecioNeto,
                            item.AlicuotaImpuesto,
                             0)
         End With
      Catch ex As Exception
         Throw ex
      End Try
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function ImprimirSubtotal() As Boolean
      'todo
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function ImprimirPago() As Boolean
      Try
         With ControladorFiscal
            .ImprimirPago(Comprobante.FormaPago.DescripcionFormasPago, Comprobante.ImporteTotal)
         End With
      Catch ex As Exception
         Throw ex
      End Try
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function CerrarComprobanteFiscal() As Boolean
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function AbrirGaveta() As Boolean
      ControladorFiscal.AbrirGaveta()
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function CancelarComprobanteFiscal() As Boolean
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function AbrirComprobanteNoFiscal() As Boolean
      ControladorFiscal.AbrirComprobanteNoFiscal()
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function ImprimirTextoNoFiscal(texto As String) As Boolean
      ControladorFiscal.ImprimirTextoNoFiscal(texto)
      Return False         'Para eliminar el warning BC42353
   End Function

   Public Function CerrarComprobanteNoFiscal() As Boolean
      ControladorFiscal.CerrarComprobanteNoFiscal()
      Return False         'Para eliminar el warning BC42353
   End Function

   ''' <summary>
   ''' 
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ValidarImpresor() As Boolean

      Try
         ControladorFiscal.SolicitarEstado()

         If Not ControladorFiscal.HuboErrorFiscal And Not ControladorFiscal.HuboErrorImpresor Then
            Return True

         Else
            Select Case True
               Case ControladorFiscal.Respuesta.EstadoFiscal(FECHA_INVALIDA) 'se debe realizar cierre Z
                  'solicitar cierre z o realizarlo
               Case ControladorFiscal.Respuesta.EstadoFiscal(CAMPO_INVALIDO), ControladorFiscal.Respuesta.EstadoFiscal(COMANDO_DESCONOCIDO)
                  'avisar
                  Return False

               Case ControladorFiscal.Respuesta.EstadoImpresor(ControladorFiscal.EstadosImpresor.SIN_PAPEL_TICKET)
                  'avisar sin papel
                  Return False
            End Select
         End If

      Catch ex As Exception
         Throw New ExcepcionFiscal(ex.Message, ex)
      End Try

      Return True
   End Function

   Public Function GetDetalleErrorFiscal() As String
      Dim respuesta As String = String.Empty

      respuesta = "Error Fiscal -- Detalle técnico " & vbCrLf & vbCrLf

      If Not Me._controladorFiscal.Respuesta Is Nothing Then
         For index As LibreriaFiscalV2.ControladorFiscal.EstadosFiscales = 0 To ControladorFiscal.EstadosFiscales.CERTIFICADOS_INVALIDOS ' 15
            respuesta &= index.ToString & " = " & Me._controladorFiscal.Respuesta.EstadoFiscal(index).ToString & vbCrLf
         Next
      End If

      Return respuesta

   End Function

   Public Function GetDetalleErrorImpresor() As String
      Dim respuesta As String = String.Empty

      respuesta = "Error Impresor -- Detalle técnico " & vbCrLf & vbCrLf

      If Not Me._controladorFiscal.Respuesta Is Nothing Then
         For index As LibreriaFiscalV2.ControladorFiscal.EstadosImpresor = 0 To ControladorFiscal.EstadosImpresor.CAJON_DINERO_CERRADO  ' 15
            respuesta &= index.ToString & " = " & Me._controladorFiscal.Respuesta.EstadoImpresor(index).ToString & vbCrLf
         Next
      End If

      Return respuesta

   End Function


   Private Shared Function ConvertirPuertoStringAInteger(puerto As String) As Integer
      puerto = puerto.Replace("COM", "")
      Dim result As Integer
      If Integer.TryParse(puerto, result) Then
         Return result
      Else
         Return 0
      End If
   End Function

   Private Shared Function ConvertirStringAModeloFiscal(modelo As String) As LibreriaFiscalV2.ControladorFiscal.ModelosFiscales
      'HASAR: SMH/P-330F, SMH/P-441F, SMH/P-715F 
      'EPSON: TM-U950F, TM-U220AF, TM-U2000AF, TM-U2002AF+, LX-300F+.
      Select Case modelo
         Case "SMH/P-330F"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.HASAR_330

         Case "SMH/P-441F"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.HASAR_441

         Case "SMH/P-715F"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.HASAR_715

         Case "SMH/P-715Fv1"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.HASAR_715_VER1

         Case "SMH/P-250F2g"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.HASAR_250_2G

         Case "TM-U220AF", "TM-U220AFII"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.EPSON_220

         Case "TM-U2000AF", "TM-U2000AF+", "TM-U2002AF+"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.EPSON_2002

         Case "TM-U950F"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.EPSON_950

         Case "LX-300F+"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.EPSON_LX300

         Case "TM-900AF"
            Return LibreriaFiscalV2.ControladorFiscal.ModelosFiscales.EPSON_TM900AF

         Case Else
            Throw New Exception(String.Format("ATENCION: El modelo {1} NO se encuentra Habilitado,{0}{0}NO podrá Continuar, por favor comuniquese con SISTEMAS.",
                                              Environment.NewLine, modelo))
      End Select
   End Function


#Region "Implement IObtenerAuditoriaPorFecha, IObtenerAuditoriaPorZeta, IInformeAFIP"
   Public ReadOnly Property PuedeExportarPorNroZeta As Boolean Implements Reglas.FiscalV2.IObtenerAuditoriaPorZeta.PuedeExportarPorNroZeta
      Get
         Return Reglas.FiscalV2.ImpresionFiscalV2Factory.ObtenerAuditoriaPorZeta(_controladorFiscal).PuedeExportarPorNroZeta
      End Get
   End Property

   Public ReadOnly Property MetodoExportacion As Reglas.FiscalV2.MetodoExportacionInformeAFIP Implements Reglas.FiscalV2.IInformeAFIP.MetodoExportacion
      Get
         Return Reglas.FiscalV2.ImpresionFiscalV2Factory.InformeAFIP(_controladorFiscal).MetodoExportacion
      End Get
   End Property


   Public Sub ObtenerAuditoria(fechaDesde As Date, fechaHasta As Date, archivoSalida As String) Implements Reglas.FiscalV2.IObtenerAuditoriaPorFecha.ObtenerAuditoria
      If disposedValue Then Throw New ObjectDisposedException(GetType(ImpresionFiscalV2).Name)

      Reglas.FiscalV2.ImpresionFiscalV2Factory.ObtenerAuditoriaPorFecha(_controladorFiscal).ObtenerAuditoria(fechaDesde, fechaHasta, archivoSalida)

   End Sub
   Public Sub ObtenerAuditoria(zetaDesde As Integer, zetaHasta As Integer, archivoSalida As String) Implements Reglas.FiscalV2.IObtenerAuditoriaPorZeta.ObtenerAuditoria
      If disposedValue Then Throw New ObjectDisposedException(GetType(ImpresionFiscalV2).Name)

      Reglas.FiscalV2.ImpresionFiscalV2Factory.ObtenerAuditoriaPorZeta(_controladorFiscal).ObtenerAuditoria(zetaDesde, zetaHasta, archivoSalida)

   End Sub
   Public Sub InformeAFIP(impresora As Entidades.Impresora, fechaDesde As Date, fechaHasta As Date, archivoSalida As String) Implements Reglas.FiscalV2.IInformeAFIP.InformeAFIP
      If disposedValue Then Throw New ObjectDisposedException(GetType(ImpresionFiscalV2).Name)

      Reglas.FiscalV2.ImpresionFiscalV2Factory.InformeAFIP(_controladorFiscal).InformeAFIP(impresora, fechaDesde, fechaHasta, archivoSalida)

   End Sub

   Public Function FechaPrimerZeta() As Date? Implements Reglas.FiscalV2.IInformeAFIP.FechaPrimerZeta
      If disposedValue Then Throw New ObjectDisposedException(GetType(ImpresionFiscalV2).Name)

      Return Reglas.FiscalV2.ImpresionFiscalV2Factory.InformeAFIP(_controladorFiscal).FechaPrimerZeta()
   End Function


   Public Function PrimerDiaSemanaFiscal(fecha As Date) As Date
      Return Reglas.FiscalV2.ImpresionFiscalV2Comunes.PrimerDiaSemanaFiscal(fecha)
   End Function
   Public Function UltimoDiaSemanaFiscal(fecha As Date) As Date
      Return Reglas.FiscalV2.ImpresionFiscalV2Comunes.UltimoDiaSemanaFiscal(fecha)
   End Function

   Public Function SemanaFiscal(fecha As Date) As Tuple(Of Date, Date)
      Return Reglas.FiscalV2.ImpresionFiscalV2Comunes.SemanaFiscal(fecha)
   End Function


#End Region

#Region "IDisposable"
   Protected Overridable Sub Dispose(disposing As Boolean)
      If Not disposedValue Then
         If disposing Then
            Try
               Me._controladorFiscal.Finalizar()   'Libera el Puerto
            Catch ex As Exception
            End Try
            Try
               Me._controladorFiscal.Dispose()
            Catch ex As Exception
            End Try
            Me._controladorFiscal = Nothing
            ' TODO: dispose managed state (managed objects)
         End If

         ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
         ' TODO: set large fields to null
         disposedValue = True
      End If
   End Sub

   ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
   ' Protected Overrides Sub Finalize()
   '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
   '     Dispose(disposing:=False)
   '     MyBase.Finalize()
   ' End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
      Dispose(disposing:=True)
      GC.SuppressFinalize(Me)
   End Sub

#End Region
End Class