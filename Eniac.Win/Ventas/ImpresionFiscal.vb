Option Strict Off

Imports LibreriaFiscal
Imports LibreriaFiscal.ControladorFiscal.EstadosFiscales

Public Class ImpresionFiscal

#Region "Campos"

   'Private Estado As EstadoImpresion = New EstadoImpresion()

   Private _controladorFiscal As LibreriaFiscal.ControladorFiscal
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _comprobante As Entidades.Venta

#End Region

   Public Property ControladorFiscal() As LibreriaFiscal.ControladorFiscal
      Get
         Return _controladorFiscal
      End Get
      Set(ByVal value As LibreriaFiscal.ControladorFiscal)
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
      Set(ByVal value As Entidades.Venta)
         _comprobante = value
      End Set
   End Property


   ''' <summary>
   ''' Crea una instancia de la impresora para imprimir.
   ''' </summary>
   ''' <param name="modelo">Es el modelo de la impresora Fiscal, por ejemp. HASAR, EPSON, etc.</param>
   ''' <param name="puerto">El puerto de conexión. Por ejem. COM1, COM2, LPT1, etc.</param>
   ''' <remarks></remarks>


   Public Sub New(ByVal modelo As String, _
                  ByVal puerto As String)

      Dim ModeloFiscal As LibreriaFiscal.ControladorFiscal.ModelosFiscales

      'HASAR: SMH/P-330F, SMH/P-441F, SMH/P-715F 
      'EPSON: TM-U950F, TM-U220AF, TM-U2000AF, TM-U2002AF+, LX-300F+.

      Select Case True
         Case modelo = "SMH/P-330F"
            ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_330

         Case modelo = "SMH/P-441F"
            ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_441

         Case modelo = "SMH/P-715F"
            ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_715

         Case modelo = "SMH/P-715Fv1"
            ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_715_VER1

         Case modelo = "SMH/P-250F2g"
            'ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_250_2G

         Case (modelo = "TM-U220AF" Or modelo = "TM-U220AFII")
            ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_220

         Case (modelo = "TM-U2000AF" Or modelo = "TM-U2000AF+" Or modelo = "TM-U2002AF+")
            ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_2002

         Case modelo = "TM-U950F"
            ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_950

         Case modelo = "LX-300F+"
            ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_LX300

         Case modelo = "TM-900AF"
            'ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_TM900AF

         Case Else

            Throw New Exception("ATENCION: El modelo " & modelo & " NO se encuentra Habilitado , " & Chr(13) & Chr(13) & "NO podrá Continuar, por favor comuniquese con SISTEMAS.")
            Exit Sub

      End Select

      Me._controladorFiscal = LibreriaFiscal.ControladorFiscal.CrearInstancia(ModeloFiscal)
      Me._controladorFiscal.Timeout = 2000
      If modelo = "TM-900AF" Or modelo = "SMH/P-250F2g" Then
         Dim int As Integer = 0
         Select Case puerto
            Case "COM1"
               int = 1
            Case "COM2"
               int = 2
            Case "COM3"
               int = 3
            Case "COM4"
               int = 4
            Case "COM5"
               int = 5
            Case "COM6"
               int = 6
            Case Else
               int = 0
         End Select
         Me._controladorFiscal.Comenzar(int)
      Else
         Me._controladorFiscal.Comenzar(puerto, LibreriaFiscal.ControladorFiscal.ModosTrabajoLibreria.SINCRONO)
      End If

      Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)

   End Sub

   Public Sub ImprimirFiscal(ByVal comprobante As Entidades.Venta)

      Try

         Dim ArchivoLOG As String = Entidades.Publicos.CarpetaLOGs & Publicos.CuitEmpresa & "_" & _
                                        comprobante.TipoComprobante.DescripcionAbrev & "_" & _
                                        comprobante.LetraComprobante & "_" & _
                                        comprobante.CentroEmisor.ToString("0000") & "_" & _
                                        Date.Now.ToString("HHmmss") + ".log"

         Dim ValorImpuestoInterno As Double = 0

         With Me._controladorFiscal

            If comprobante.Impresora.GrabarLOGs Then
               .LoggerEnabled(ArchivoLOG) = True
            End If

            If comprobante.Cliente.Cuit <> "" Then

               .DatosCliente(comprobante.Cliente.NombreCliente, _
                             comprobante.Cliente.Cuit, _
                             Me.GetTipoDocumento("CUIT"), _
                             Me.GetTipoDeResponsabilidad(comprobante.Cliente.CategoriaFiscal.IdCategoriaFiscal), _
                             comprobante.Cliente.Direccion)

            Else

                    .DatosCliente(comprobante.Cliente.NombreCliente, _
                                  comprobante.Cliente.NroDocCliente.ToString(), _
                                  Me.GetTipoDocumento(comprobante.Cliente.TipoDocCliente), _
                                  Me.GetTipoDeResponsabilidad(comprobante.Cliente.CategoriaFiscal.IdCategoriaFiscal), _
                                  comprobante.Cliente.Direccion)

            End If

            .AbrirComprobanteFiscal(Me.GetTipoDocumentoFiscal(comprobante.TipoComprobante.IdTipoComprobante, comprobante.LetraComprobante))

            For Each item As Entidades.VentaProducto In comprobante.VentasProductos

               'Hay que enviarlo con valor Unitario.
               ValorImpuestoInterno = item.ImporteImpuestoInterno / item.Cantidad

               .ImprimirItem(Publicos.NormalizarDescripcion(item.Producto.NombreProducto), _
                             item.Cantidad, _
                             item.PrecioNeto, _
                             item.AlicuotaImpuesto, _
                              ValorImpuestoInterno)
            Next

            .ImprimirPago(comprobante.FormaPago.DescripcionFormasPago, comprobante.ImporteTotal)

            If Not comprobante.Impresora.CierreFiscalEstandar Or (comprobante.Impresora.Modelo = "LX-300F+" And comprobante.TipoComprobante.CoeficienteValores < 0) Then
               .CerrarComprobanteNoFiscalHomologado()
            Else
               .CerrarComprobanteFiscal()
            End If

            'Anulado para analizar el comportamiento del sistema en caso de errores.
            'If .HuboErrorImpresor Then
            '   .Finalizar()
            '   Throw New ExcepcionFiscal("Hubo error en la impresora fiscal:" + .Respuesta.ToString())
            'End If

            'If .HuboErrorFiscal Then
            '   Dim mensaje As String = "Hubo un error fiscal:" + .Respuesta.ToString()
            '   .CerrarComprobanteFiscal()
            '   .Finalizar()
            '   Throw New ExcepcionFiscal(mensaje)
            'End If

            'debido a la libreria fiscal se pone este if hasta que Pedro Porcel solucione la misma
            comprobante.NumeroComprobante = Long.Parse(.Respuesta.ParseInteger(3).ToString())

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

            If System.IO.File.Exists(ArchivoLOG) Then

               'Le cambio el nombre porque ya esta la numeracion del comprobante.
               Dim ArchivoLOGfinal As String = Entidades.Publicos.CarpetaLOGs & Publicos.CuitEmpresa & "_" & _
                                comprobante.TipoComprobante.DescripcionAbrev & "_" & _
                                comprobante.LetraComprobante & "_" & _
                                comprobante.CentroEmisor.ToString("0000") & "_" & _
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

   Public Sub ImprimirNoFiscal(ByVal comprobante As Entidades.Venta)

      Try

         Dim ArchivoLOG As String = Entidades.Publicos.CarpetaLOGs & Publicos.CuitEmpresa & "_" & _
                                        comprobante.TipoComprobante.DescripcionAbrev & "_" & _
                                        comprobante.LetraComprobante & "_" & _
                                        comprobante.CentroEmisor.ToString("0000") & "_" & _
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
               Dim ArchivoLOGfinal As String = Entidades.Publicos.CarpetaLOGs & Publicos.CuitEmpresa & "_" & _
                                comprobante.TipoComprobante.DescripcionAbrev & "_" & _
                                comprobante.LetraComprobante & "_" & _
                                comprobante.CentroEmisor.ToString("0000") & "_" & _
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

   Private Function GetTipoDeResponsabilidad(ByVal idCategoriaFiscal As Short) As LibreriaFiscal.ControladorFiscal.TiposDeResponsabilidades
      Select Case idCategoriaFiscal
         Case 1
            Return LibreriaFiscal.ControladorFiscal.TiposDeResponsabilidades.CONSUMIDOR_FINAL
         Case 2
            Return LibreriaFiscal.ControladorFiscal.TiposDeResponsabilidades.RESPONSABLE_INSCRIPTO
         Case 4
            Return LibreriaFiscal.ControladorFiscal.TiposDeResponsabilidades.RESPONSABLE_EXENTO
         Case 5
            Return LibreriaFiscal.ControladorFiscal.TiposDeResponsabilidades.RESPONSABLE_EXENTO
         Case 6
            Return LibreriaFiscal.ControladorFiscal.TiposDeResponsabilidades.MONOTRIBUTO
         Case Else
            Return LibreriaFiscal.ControladorFiscal.TiposDeResponsabilidades.CONSUMIDOR_FINAL
      End Select
   End Function

   Private Function GetTipoDocumento(ByVal tipoDoc As String) As LibreriaFiscal.ControladorFiscal.TiposDeDocumento
      Select Case tipoDoc
         Case "DNI"
            Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_DNI
         Case "CUIT"
            Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_CUIT
         Case "CUIL"
            Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_CUIL
         Case "PASAPORTE"
            Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_PASAPORTE
         Case "LC"
            Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_LC
         Case "CI"
            Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_CI
         Case "LE"
            Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_LE
         Case Else
            If Me._controladorFiscal.Modelo.ToString.Contains("EPSON") Then
               Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_DNI
            Else
               Return LibreriaFiscal.ControladorFiscal.TiposDeDocumento.TIPO_NINGUNO
            End If
      End Select
   End Function

   Private Function GetTipoDocumentoFiscal(ByVal documento As String, ByVal letra As String) As LibreriaFiscal.ControladorFiscal.DocumentosFiscales
      Select Case documento
         Case "FACT-F" 'Factura Fiscal
            Select Case letra
               Case "A"
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.FACTURA_A
               Case "B"
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.FACTURA_B
            End Select
         Case "NCRED-F" 'N. de Credito Fiscal
            Select Case letra
               Case "A"
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.NOTA_CREDITO_A
               Case "B"
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.NOTA_CREDITO_BC
               Case Else
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.NOTA_CREDITO_BC
            End Select
         Case "NDEB-F" 'N. de Debito Fiscal
            Select Case letra
               Case "A"
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.NOTA_DEBITO_A
               Case "B"
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.NOTA_DEBITO_B
            End Select
         Case "TCK-FACT-F" 'Ticket-Factura Fiscal
            Select Case letra
               Case "A"
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.TICKET_FACTURA_A
               Case "B"
                  Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.TICKET_FACTURA_B
            End Select
         Case "TICKET-F" 'Ticket Fiscal
            Return LibreriaFiscal.ControladorFiscal.DocumentosFiscales.TICKET_C
      End Select
   End Function

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
         Me._controladorFiscal.Finalizar()   'Libera el Puerto
         Me._controladorFiscal = Nothing

      End Try

   End Function

   Public Function CierreZ() As String

      Try

         Me._controladorFiscal.ReporteZ()

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
         Me._controladorFiscal.Finalizar()   'Libera el Puerto

         Me._controladorFiscal = Nothing

      End Try

   End Function

   Public Function CierreZReimprimir(ByVal NroZetaDesde As Long, ByVal NroZetaHasta As Long, ByVal DatosGlobales As Boolean) As String

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
         Me._controladorFiscal.Finalizar()   'Libera el Puerto
         Me._controladorFiscal = Nothing

      End Try

   End Function

   Public ReadOnly Property HayComprobanteFiscalAbierto() As Boolean
      Get
         ControladorFiscal.SolicitarEstado()
         Return ControladorFiscal.Respuesta.EstadoFiscal(DOCUMENTO_ABIERTO) And ControladorFiscal.Respuesta.EstadoFiscal(DOCUMENTO_FISCAL_ABIERTO)
      End Get
   End Property

   Public Sub ImprimirFiscalPie(ByVal comprobante As Entidades.Venta)

      Try

         Dim ArchivoLOG As String = Entidades.Publicos.CarpetaLOGs & Publicos.CuitEmpresa & "_" & _
                                        Comprobante.TipoComprobante.DescripcionAbrev & "_" & _
                                        Comprobante.LetraComprobante & "_" & _
                                        Comprobante.CentroEmisor.ToString("0000") & "_" & _
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

            Comprobante.NumeroComprobante = Long.Parse(.Respuesta.ParseInteger(3).ToString())

            If Comprobante.Impresora.AbrirCajonDinero And Comprobante.TipoComprobante.AfectaCaja Then
               .AbrirGaveta()
            End If

            .Finalizar()

            'Estado.OK = True
            'Estado.MensajeError = ""
            'Estado.NumeroComprobante = Long.Parse(.Respuesta.ParseInteger(3).ToString())

            If System.IO.File.Exists(ArchivoLOG) Then

               'Le cambio el nombre porque ya esta la numeracion del comprobante.
               Dim ArchivoLOGfinal As String = Entidades.Publicos.CarpetaLOGs & Publicos.CuitEmpresa & "_" & _
                                Comprobante.TipoComprobante.DescripcionAbrev & "_" & _
                                Comprobante.LetraComprobante & "_" & _
                                Comprobante.CentroEmisor.ToString("0000") & "_" & _
                                Comprobante.NumeroComprobante.ToString("00000000") + ".log"

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

   Public Sub AbrirComprobanteFiscal()

      Try

         With ControladorFiscal

            If Comprobante.Cliente.Cuit <> "" Then

               .DatosCliente(Comprobante.Cliente.NombreCliente, _
                             Comprobante.Cliente.Cuit, _
                             Me.GetTipoDocumento("CUIT"), _
                             Me.GetTipoDeResponsabilidad(Comprobante.Cliente.CategoriaFiscal.IdCategoriaFiscal), _
                             Comprobante.Cliente.Direccion)

            Else

               .DatosCliente(Comprobante.Cliente.NombreCliente, _
                             Comprobante.Cliente.NroDocCliente.ToString(), _
                             Me.GetTipoDocumento(Comprobante.Cliente.TipoDocCliente), _
                             Me.GetTipoDeResponsabilidad(Comprobante.Cliente.CategoriaFiscal.IdCategoriaFiscal), _
                             Comprobante.Cliente.Direccion)

            End If

            .AbrirComprobanteFiscal(Me.GetTipoDocumentoFiscal(Comprobante.TipoComprobante.IdTipoComprobante, Comprobante.LetraComprobante))

         End With
      Catch ex As Exception
         Throw ex 'ver lo que te dije acerca de la InnerException!!!!!
      End Try

   End Sub

   Public Function ImprimirTextoFiscal() As Boolean


   End Function

   Public Function ImprimirItemFiscal(ByVal item As Entidades.VentaProducto) As Boolean
      Try
         With ControladorFiscal
            .ImprimirItem(Publicos.NormalizarDescripcion(item.Producto.NombreProducto), _
                            item.Cantidad, _
                            item.PrecioNeto, _
                            item.AlicuotaImpuesto, _
                             0)
         End With
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ImprimirSubtotal() As Boolean
      'todo
   End Function

   Public Function ImprimirPago() As Boolean
      Try
         With ControladorFiscal
            .ImprimirPago(Comprobante.FormaPago.DescripcionFormasPago, Comprobante.ImporteTotal)
         End With
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CerrarComprobanteFiscal() As Boolean
   End Function

   Public Function AbrirGaveta() As Boolean
      ControladorFiscal.AbrirGaveta()
   End Function

   Public Function CancelarComprobanteFiscal() As Boolean
   End Function

   Public Function AbrirComprobanteNoFiscal() As Boolean
      ControladorFiscal.AbrirComprobanteNoFiscal()
   End Function

   Public Function ImprimirTextoNoFiscal(ByVal texto As String) As Boolean
      ControladorFiscal.ImprimirTextoNoFiscal(texto)
   End Function

   Public Function CerrarComprobanteNoFiscal() As Boolean
      ControladorFiscal.CerrarComprobanteNoFiscal()
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

               Case ControladorFiscal.Respuesta.EstadoImpresor(LibreriaFiscal.ControladorFiscal.EstadosImpresor.SIN_PAPEL_TICKET)
                  'avisar sin papel
                  Return False
            End Select
         End If

      Catch ex As Exception
         Throw New LibreriaFiscal.ExcepcionFiscal(ex.Message, ex)
      End Try

      Return True
   End Function

   Public Function GetDetalleErrorFiscal() As String
      Dim respuesta As String = String.Empty

      respuesta = "Error Fiscal -- Detalle técnico " & vbCrLf & vbCrLf

      If Not Me._controladorFiscal.Respuesta Is Nothing Then
         For index As LibreriaFiscal.ControladorFiscal.EstadosFiscales = 0 To 15
            respuesta &= index.ToString & " = " & Me._controladorFiscal.Respuesta.EstadoFiscal(index).ToString & vbCrLf
         Next

      End If

      Return respuesta

   End Function

   Public Function GetDetalleErrorImpresor() As String
      Dim respuesta As String = String.Empty

      respuesta = "Error Impresor -- Detalle técnico " & vbCrLf & vbCrLf

      If Not Me._controladorFiscal.Respuesta Is Nothing Then
         For index As LibreriaFiscal.ControladorFiscal.EstadosImpresor = 0 To 15
            respuesta &= index.ToString & " = " & Me._controladorFiscal.Respuesta.EstadoImpresor(index).ToString & vbCrLf
         Next
      End If

      Return respuesta

   End Function


End Class
