Option Explicit On
Option Strict On
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Public Class RegistracionPagos

#Region "Campos"


   Private _publicos As Publicos

   Private _tipoImpuestoIVA As Eniac.Entidades.TipoImpuesto.Tipos = Eniac.Entidades.TipoImpuesto.Tipos.IVA
   Private _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal
   Private NumeroReparto As Integer


   Private Const Efectivo As String = "Efectivo"
   Private Const NC As String = "N. Crédito"
   Private Const CC As String = "Cta. Cte."
   ''Private Const Cheque As String = "Cheque"
   Private Const Varias As String = "Varias->Ver Detalle"
   Private Const ReEnvio As String = "Re-Envío"
   Private Const Rendida As String = "RENDIDA"
   Private Const noRendida As String = "NO RENDIDA"

   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True
   Private _dsProductosSinDescargo As DataSet
   Private _dtProductosSinDescargo As DataTable
   Private _dtProductosSinDescargoComprobante As DataTable
   Private _titArticulosSinDescargo0 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titArticulosSinDescargo1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
#End Region

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbModoConsultarComprobantes, GetType(Entidades.RegistracionPagos.ModoConsultarComprobantes))
         cmbModoConsultarComprobantes.SelectedValue = Reglas.Publicos.RegistracionPagosModoConsultarComprobantes

         Me._publicos.CargaComboLocalidades(Me.cmbLocalidad)
         Me.cmbLocalidad.SelectedIndex = -1

         Me._publicos.CargaComboTransportistas(Me.cmbRespDistribucion)
         Me.cmbRespDistribucion.SelectedIndex = -1


         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         Me._categoriaFiscalEmpresa = New Eniac.Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)

         Me._publicos.CargaComboRutas(cmbRuta, activa:=True, seleccionMultiple:=False, seleccionTodos:=False, cargarListaPrecios:=False)

         Me._publicos.CargaComboDesdeEnum(cmbDias, GetType(Entidades.Publicos.Dias))
         Me.cmbDias.SelectedIndex = -1

         CrearDtProductosSinDescargo()

         _titArticulosSinDescargo0 = GetColumnasVisiblesGrilla(ugvProductosSinDescargar.DisplayLayout.Bands(0))
         _titArticulosSinDescargo1 = GetColumnasVisiblesGrilla(ugvProductosSinDescargar.DisplayLayout.Bands(1))

         Me.txtNumeroReparto.Text = "0"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ProximoReparto()
      Dim ofactura As Reglas.Ventas = New Reglas.Ventas()

      NumeroReparto = ofactura.GetProximoNumeroReparto
      lblNumeroReparto.Text = "Nro. Reparto: " & NumeroReparto.ToString
   End Sub


   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      If MessageBox.Show("Perderá los cambios al salir. Desea Continuar?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = vbOK Then
         Me.Close()
      End If
      Me.tsbGrabar.Enabled = True
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click

      Try
         If MessageBox.Show(String.Format("Los pagos se imputarán a la caja: {0} - {1}. ¿Desea continuar?",
                                          Me.cmbCajas.SelectedValue.ToString, Me.cmbCajas.Text), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            Me.GrabarComprobante()
            Me.tsbRefrescar.PerformClick()
         End If
      Catch ex As Exception
         ShowError(ex, recursivo:=True)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function GrabarRecibo(TpoComp As Eniac.Entidades.TipoComprobante, _
                                 FormaPago As Eniac.Entidades.VentaFormaPago, _
                                 NumeroReparto As Integer?,
                                 ClienteActual As Eniac.Entidades.Cliente, _
                                 vendedor As Eniac.Entidades.Empleado, _
                                 obs As String, _
                                 ImporteTotal As Decimal, _
                                 ImporteEfectivo As Decimal, _
                                 ImporteCheque As Decimal, _
                                 ImporteTransferencia As Decimal, _
                                 CtaBancaria As Eniac.Entidades.CuentaBancaria, _
                                 ComprobantesAfectados As System.Collections.Generic.List(Of Eniac.Entidades.CuentaCorrientePago),
                                 cheques As dtsRegistracionPagos.ChequesRow()) As Eniac.Entidades.CuentaCorriente

      Dim oReglasCuentaCorriente As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
      Dim oCtaCte As Eniac.Entidades.CuentaCorriente = New Eniac.Entidades.CuentaCorriente()

      With oCtaCte
         .TipoComprobante = TpoComp
         .Letra = "X"

         If TpoComp.LetrasHabilitadas = "X" Or TpoComp.LetrasHabilitadas = "R" Then
            .Letra = TpoComp.LetrasHabilitadas
         Else
            If ClienteActual IsNot Nothing Then
               .Letra = ClienteActual.CategoriaFiscal.LetraFiscal
            End If
         End If


         .CentroEmisor = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante).CentroEmisor
         .NumeroComprobante = 0

         'Actualiza la fecha de hoy, si se dejo la pantalla abierta mucho tiempo
         .Fecha = Date.Now
         .FechaVencimiento = .Fecha

         .FormaPago = FormaPago
         .NumeroReparto = If(NumeroReparto.HasValue, NumeroReparto.Value, Nothing)

         'cargo el cliente ----------
         .Cliente = DirectCast(ClienteActual, Eniac.Entidades.Cliente)
         .IdCategoria = .Cliente.IdCategoria
         .Vendedor = vendedor

         .Observacion = obs

         'cargo valores del comprobante
         .ImporteTotal = ImporteTotal

         'cargo los comprobantes
         .Pagos = ComprobantesAfectados

         'cargo el efectivo para tenerlo discriminado
         .ImportePesos = ImporteEfectivo
         .ImporteDolares = 0
         .ImporteTickets = 0
         .ImporteTarjetas = 0 'Decimal.Parse(Me.txtTarjetas.Text)

         'cargo los cheques
         If cheques IsNot Nothing Then
            .Cheques = New List(Of Eniac.Entidades.Cheque)() '' Me._cheques
            For Each drCheque As dtsRegistracionPagos.ChequesRow In cheques
               Dim cheque As Eniac.Entidades.Cheque = New Eniac.Entidades.Cheque()

               With cheque
                  .NumeroCheque = drCheque.NumeroCheque
                  .Banco = New Eniac.Reglas.Bancos().GetUno(drCheque.IdBanco)
                  .IdBancoSucursal = drCheque.IdBancoSucursal
                  .Localidad.IdLocalidad = drCheque.IdLocalidad
                  .Cuit = drCheque.Cuit
                  .FechaEmision = drCheque.FechaEmision
                  .FechaCobro = drCheque.FechaCobro
                  .Titular = drCheque.Titular
                  .Importe = drCheque.Importe
                  .Cliente.CodigoCliente = drCheque.CodigoCliente
                  .Usuario = drCheque.Usuario
                  .IdEstadoCheque = Eniac.Entidades.Cheque.Estados.ENCARTERA
                  .IdTipoCheque = drCheque.IdTipoCheque
                  .NroOperacion = drCheque.NroOperacion
               End With

               .Cheques.Add(cheque)
            Next
         End If
         .ImporteCheques = ImporteCheque

         .Tarjetas = Nothing 'Me._tarjetas

         'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 And Me.bscCuentaBancariaTransfBanc.Selecciono Then
         .ImporteTransfBancaria = ImporteTransferencia
         .CuentaBancariaTransfBanc = CtaBancaria

         'cargo las Retenciones
         'TODO: Ver de agregar las retenciones aquí.
         '.Retenciones = Me._retenciones
         '.ImporteRetenciones = Decimal.Parse(Me.txtRetenciones.Text)

         'cargo la caja
         .CajaDetalle.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

         'cargo datos generales del comprobante
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .IdEstado = "NORMAL"
      End With

      My.Application.Log.WriteEntry("Recibos-Inserta registro.", TraceEventType.Verbose)
      oReglasCuentaCorriente.Insertar(oCtaCte, Eniac.Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)
      My.Application.Log.WriteEntry("Recibos-Termino de Insertar registro.", TraceEventType.Verbose)

      Return oCtaCte

   End Function

   Private Function GrabarComprobanteNuevo(tipoComprobante As Eniac.Entidades.TipoComprobante,
                                           idCliente As Long,
                                           fechaComprobante As Date,
                                           vendedor As Eniac.Entidades.Empleado,
                                           idFormaDePago As Integer,
                                           obs As String,
                                           transportista As Eniac.Entidades.Transportista,
                                           fechaEnvio As Date,
                                           nroReparto As Integer,
                                           mercDespachada As Boolean,
                                           productos As List(Of Eniac.Entidades.VentaProducto),
                                           comprobanteAsociado As Entidades.Venta) As Eniac.Entidades.Venta

      Dim Comprobante As Eniac.Entidades.Venta
      Dim reglaVentas As Reglas.Ventas = New Reglas.Ventas()
      Dim reglaSiGAVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()

      Dim cliente As Eniac.Entidades.Cliente = New Eniac.Reglas.Clientes().GetUno(idCliente)

      If Not tipoComprobante.GrabaLibro AndAlso Not tipoComprobante.EsPreElectronico AndAlso Eniac.Reglas.Publicos.Facturacion.FacturacionGrabaLibroNoFuerzaConsFinal Then
         cliente.CategoriaFiscal = New Eniac.Reglas.CategoriasFiscales()._GetUno(1S)      'No deberia ser Fijo 1.
      End If

      Comprobante = reglaVentas.GrabarComprobanteAutomaticoConCAE(Eniac.Entidades.Usuario.Actual.Sucursal.Id,
                                                            tipoComprobante.IdTipoComprobante,
                                                            cliente,
                                                            fechaComprobante,
                                                            vendedor.IdEmpleado,
                                                            idFormaDePago,
                                                            obs,
                                                            productos,
                                                            transportista,
                                                            fechaEnvio,
                                                            Integer.Parse(Me.cmbCajas.SelectedValue.ToString()),
                                                            nroReparto,
                                                            mercDespachada,
                                                            {comprobanteAsociado},
                                                            Eniac.Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

      Comprobante = reglaSiGAVentas.GetUna(Comprobante.IdSucursal, Comprobante.IdTipoComprobante, Comprobante.LetraComprobante, Comprobante.CentroEmisor, Comprobante.NumeroComprobante)
      Return Comprobante
   End Function

   Private Function InsertarComprobanteAutomatico(ByVal Comprobante As Eniac.Entidades.Venta, _ComprobantesGrilla As List(Of Eniac.Entidades.CuentaCorrientePago), Optional paga As Decimal? = Nothing) As List(Of Eniac.Entidades.CuentaCorrientePago)

      Dim oLineaDetalle As Eniac.Entidades.CuentaCorrientePago = New Eniac.Entidades.CuentaCorrientePago()

      With oLineaDetalle
         .TipoComprobante = Comprobante.TipoComprobante
         .Letra = Comprobante.LetraComprobante
         .CentroEmisor = Comprobante.CentroEmisor
         .NumeroComprobante = Comprobante.NumeroComprobante
         .Cuota = 1
         .FechaEmision = Comprobante.Fecha
         .FechaVencimiento = Comprobante.Fecha.AddDays(New Eniac.Reglas.VentasFormasPago().GetUna(Comprobante.FormaPago.IdFormasPago).Dias)
         .ImporteCuota = Comprobante.ImporteTotal
         .SaldoCuota = Comprobante.ImporteTotal
         If paga.HasValue Then
            .Paga = paga.Value
         Else
            .Paga = Comprobante.ImporteTotal
         End If
         .DescuentoRecargoPorc = 0
         .DescuentoRecargo = 0
         .IdSucursal = actual.Sucursal.IdSucursal
         .Usuario = actual.Nombre
      End With

      _ComprobantesGrilla.Add(oLineaDetalle)

      Return _ComprobantesGrilla
   End Function

   Private Sub GrabarComprobante()
      If Me.ValidarComprobante() Then

         Dim oCliente As Eniac.Entidades.Cliente
         Dim Vend As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados()
         Dim Transp As Eniac.Reglas.Transportistas = New Eniac.Reglas.Transportistas()
         Dim catFiscal As Eniac.Reglas.CategoriasFiscales = New Eniac.Reglas.CategoriasFiscales
         Dim tipoComp As Eniac.Reglas.TiposComprobantes = New Eniac.Reglas.TiposComprobantes
         Dim tipoCompNC As Eniac.Reglas.TiposComprobantes = New Eniac.Reglas.TiposComprobantes
         Dim repartoProdSinDescargar As Eniac.Reglas.RepartosProductosSinDescargar = New Eniac.Reglas.RepartosProductosSinDescargar
         Dim fPago As Eniac.Reglas.VentasFormasPago = New Eniac.Reglas.VentasFormasPago
         Dim CajaDetalle As Eniac.Reglas.CajaDetalles = New Eniac.Reglas.CajaDetalles
         Dim rRepartoComprobantes As Reglas.RepartosComprobantes = New Reglas.RepartosComprobantes()
         Dim eRecibo As Entidades.CuentaCorriente
         Dim ultimoNroOrden As Integer
         Dim dsRecibos As dtsRegistracionPagos.RecibosDataTable = New dtsRegistracionPagos.RecibosDataTable

         tspBarra.Minimum = 0
         tspBarra.Value = 0
         tspBarra.Maximum = DtsRegistracionPagos.Pedidos.Count
         tspBarra.Visible = True

         '# Número de Reparto
         ' Verificar que no se haya borrado el Número de Reparto de la pantalla después de haber rendido.
         Dim _numReparto As Integer? = Integer.Parse(Me.txtNumeroReparto.Text)
         If _numReparto = 0 Then
            Me.txtNumeroReparto.Focus()
            Throw New Exception("El número de reparto no puede ser 0.")
         End If
         ultimoNroOrden = rRepartoComprobantes.GetCodigoMaximo(actual.Sucursal.IdSucursal, _numReparto.Value)

         ' para cada pedido de la grilla principal
         For Each drPedido As dtsRegistracionPagos.PedidosRow In DtsRegistracionPagos.Pedidos
            ' # Reseteo la instancia de recibo por cada vuelta
            eRecibo = Nothing

            Try
               tspBarra.Increment(1)
               Application.DoEvents()
               Dim _ComprobantesGrilla As New List(Of Eniac.Entidades.CuentaCorrientePago)()

               If Not drPedido.IsFormaPagoNull() AndAlso Not String.IsNullOrEmpty(drPedido.FormaPago) Then

                  oCliente = New Eniac.Reglas.Clientes().GetUno(drPedido.IdCliente)

                  Dim vendedor As Eniac.Entidades.Empleado = Vend.GetUno(Integer.Parse(drPedido.IdVendedor.ToString()))

                  Dim _transportista As Eniac.Entidades.Transportista

                  If Not drPedido.IsIdTransportistaNull() Then
                     _transportista = Transp.GetUno(drPedido.IdTransportista)
                  Else
                     _transportista = Transp.GetUno(oCliente.IdTransportista)
                  End If



                  Dim _categoriaFiscalCliente As Eniac.Entidades.CategoriaFiscal = catFiscal.GetUno(drPedido.IdCategoriaFiscal)

                  Dim Comprobante As Eniac.Entidades.Venta

                  Dim _tipoCompNC As Eniac.Entidades.TipoComprobante
                  If drPedido.GrabaLibro Then
                     _tipoCompNC = New Eniac.Reglas.TiposComprobantes().GetUno(Publicos.IdNotaCreditoGrabaLibro)
                  Else
                     _tipoCompNC = New Eniac.Reglas.TiposComprobantes().GetUno(Publicos.IdNotaCreditoNoGrabaLibro)
                  End If

                  ' articulos de la fila activa

                  Dim _formaPago As Eniac.Entidades.VentaFormaPago = fPago.GetUna(drPedido.IdFormasPago)

                  Select Case drPedido.FormaPago

                     Case Efectivo
                        'genero recibo x pago efectivo solamente
                        'esto es un recibo
                        Dim _tipoComp As Eniac.Entidades.TipoComprobante = New Eniac.Reglas.TiposComprobantes().GetTipoComprobanteRecibo(drPedido.IdTipoComprobante, drPedido.Efectivo)
                        Dim compro As Eniac.Entidades.Venta = New Eniac.Reglas.Ventas().GetUna(drPedido.IdSucursal,
                                                                                               drPedido.IdTipoComprobante,
                                                                                               drPedido.Letra,
                                                                                               CShort(drPedido.CentroEmisor),
                                                                                               drPedido.NumeroComprobante)
                        '# Guardo el recibo generado para luego insertarlo en RepartoComprobantes
                        eRecibo = GrabarRecibo(_tipoComp, _
                                          _formaPago, _
                                          _numReparto,
                                          oCliente, _
                                          vendedor, _
                                          "Recibo por pago Efectivo", _
                                          drPedido.Efectivo, _
                                          drPedido.Efectivo, _
                                          0, 0, Nothing, InsertarComprobanteAutomatico(compro, _ComprobantesGrilla), drPedido.GetChequesRows)

                        RegistrarCambios(compro, Nothing)

                        ActualizarFechaRendicion(drPedido)

                     Case CC
                        ' GrabarCC(pedido, True)
                        ActualizarCC(drPedido)
                        Dim compro As Eniac.Entidades.Venta = New Eniac.Reglas.Ventas().GetUna(drPedido.IdSucursal,
                                                                                               drPedido.IdTipoComprobante,
                                                                                               drPedido.Letra,
                                                                                               CShort(drPedido.CentroEmisor),
                                                                                               drPedido.NumeroComprobante)
                        RegistrarCambios(compro, Nothing)

                     Case NC
                        'TODO: Ver de pasar esta lógica a un método de la Regla manejando correctamente la transacción.
                        '      Actualemente, graba la NC en una transacción, actualiza las observaciones de la FC 
                        '      en otra y en una última graba la Minuta.

                        Dim compro As Eniac.Entidades.Venta = New Eniac.Reglas.Ventas().GetUna(drPedido.IdSucursal,
                                                                                               drPedido.IdTipoComprobante,
                                                                                               drPedido.Letra,
                                                                                               CShort(drPedido.CentroEmisor),
                                                                                               drPedido.NumeroComprobante)
                        Try

                           If Not String.IsNullOrWhiteSpace(compro.TipoComprobante.IdTipoComprobanteNCred) Then
                              _tipoCompNC = New Eniac.Reglas.TiposComprobantes().GetUno(compro.TipoComprobante.IdTipoComprobanteNCred)
                           End If

                           Try
                              If drPedido.GetProductosRows().Count > 0 Then
                                 For Each vp As Entidades.VentaProducto In compro.VentasProductos
                                    vp.IdEstadoVenta = drPedido.GetProductosRows()(0).IdMotivo
                                 Next
                              End If
                              'Grabo las notas de credito
                              Comprobante = GrabarComprobanteNuevo(_tipoCompNC,
                                                                   drPedido.IdCliente,
                                                                   Date.Now,
                                                                   vendedor,
                                                                   drPedido.IdFormasPago,
                                                                   "Nota Credito Total",
                                                                   _transportista,
                                                                   If(drPedido.IsFechaEnvioNull, Today, drPedido.FechaEnvio),
                                                                   compro.NumeroReparto,
                                                                   compro.MercDespachada,
                                                                   compro.VentasProductos,
                                                                   compro)
                           Catch ex As Exception
                              Throw New Exception(String.Format("No se pudo registrar la NC. Si la NC es electrónica la misma estará para solicitar CAE y deberá aplicarla manualmente. Motivo: {0}.", ex.Message), ex)
                           End Try
                           Dim reglaVentas As Reglas.Ventas = New Reglas.Ventas()
                           compro.Observacion = String.Format("{0} - {1}", drPedido.GetProductosRows(0).IdMotivo, drPedido.GetProductosRows(0).Motivo)
                           reglaVentas.ModificarObs(compro)

                           Dim paga As Decimal = Math.Min(compro.ImporteTotal, Comprobante.ImporteTotal * -1)

                           InsertarComprobanteAutomatico(compro, _ComprobantesGrilla, paga)
                           'esto es un recibo
                           Dim _tipoComp As Eniac.Entidades.TipoComprobante = New Eniac.Reglas.TiposComprobantes().GetTipoComprobanteRecibo(drPedido.IdTipoComprobante, 0)

                           Try
                              '# Guardo el recibo generado para luego insertarlo en RepartoComprobantes
                              eRecibo = GrabarRecibo(_tipoComp, _
                                                _formaPago,
                                                _numReparto, _
                                                oCliente, _
                                                vendedor, _
                                                "Aplicación de NC", _
                                                0, _
                                                0, _
                                                0, 0, Nothing, _
                                                InsertarComprobanteAutomatico(Comprobante, _ComprobantesGrilla, paga * -1), drPedido.GetChequesRows)
                           Catch ex As Exception
                              Throw New Exception(String.Format("No se pudo registrar la minuta para aplicar la NC con la FC. La NC fue creada en CtaCte realice la aplicación de manera manual. Motivo del error: {0}", ex.Message), ex)
                           End Try
                           RegistrarCambios(compro, Nothing)
                           ActualizarFechaRendicion(drPedido)
                        Catch ex As Eniac.Reglas.Ventas.ActualizaCAEException
                           Dim reglaVentas As Reglas.Ventas = New Reglas.Ventas()
                           compro.Observacion = String.Format("{0} - {1}", drPedido.GetProductosRows(0).IdMotivo, drPedido.GetProductosRows(0).Motivo)
                           reglaVentas.ModificarObs(compro)
                           ActualizarCC(drPedido)
                           MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch
                           Throw
                        End Try

                        ''Case Cheque
                        ''   'GrabarCheque(pedido, True)

                        ''   GrabarRecibo(_tipoComp, _
                        ''                  New Eniac.Reglas.VentasFormasPago().GetUna(3), _
                        ''               oCliente, _
                        ''               vendedor, _
                        ''               "Recibo por pago con cheque", _
                        ''                  Decimal.Parse(pedido.Cells("ImporteTotal").Value.ToString), _
                        ''                  0, _
                        ''                  Decimal.Parse(pedido.Cells("ImporteTotal").Value.ToString), 0, Nothing, Nothing)


                     Case ReEnvio
                        GrabarReenvio(drPedido, True)

                     Case Varias

                        Dim importeParcialEfectivo As Decimal = drPedido.Efectivo
                        Dim ImporteParcialCC As Decimal = drPedido.CuentaCorriente
                        Dim importeParcialCheque As Decimal = drPedido.TotalCheques
                        Dim importeParcialNC As Decimal = drPedido.TotalNC

                        Dim compro As Eniac.Entidades.Venta = New Eniac.Reglas.Ventas().GetUna(drPedido.IdSucursal,
                                                                          drPedido.IdTipoComprobante,
                                                                          drPedido.Letra,
                                                                          CShort(drPedido.CentroEmisor),
                                                                          drPedido.NumeroComprobante)

                        If drPedido.TotalNC <> 0 Then
                           Try
                              If Not String.IsNullOrWhiteSpace(compro.TipoComprobante.IdTipoComprobanteNCred) Then
                                 _tipoCompNC = New Eniac.Reglas.TiposComprobantes().GetUno(compro.TipoComprobante.IdTipoComprobanteNCred)
                              End If

                              Comprobante = GrabarComprobanteNuevo(_tipoCompNC,
                                                                   drPedido.IdCliente,
                                                                   Date.Now,
                                                                   vendedor,
                                                                   drPedido.IdFormasPago,
                                                                   "Nota Credito Parcial",
                                                                   _transportista,
                                                                   If(drPedido.IsFechaEnvioNull, Today, drPedido.FechaEnvio),
                                                                   compro.NumeroReparto,
                                                                   compro.MercDespachada,
                                                                   InsertarProductos(drPedido, compro),
                                                                   compro)

                              drPedido.TotalNC = Comprobante.ImporteTotal * -1
                              Me.InsertarComprobanteAutomatico(Comprobante, _ComprobantesGrilla)
                           Catch ex As Eniac.Reglas.Ventas.ActualizaCAEException
                              Dim reglaVentas As Reglas.Ventas = New Reglas.Ventas()
                              compro.Observacion = String.Format("{0} - {1}", drPedido.GetProductosRows(0).IdMotivo, drPedido.GetProductosRows(0).Motivo)
                              reglaVentas.ModificarObs(compro)
                              ActualizarCC(drPedido)
                              MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                           Catch
                              Throw
                           End Try
                        End If

                        InsertarComprobanteAutomatico(compro, _ComprobantesGrilla, drPedido.Efectivo + drPedido.TotalCheques + drPedido.TotalNC)

                        Dim _tipoComp As Eniac.Entidades.TipoComprobante = New Eniac.Reglas.TiposComprobantes().GetTipoComprobanteRecibo(drPedido.IdTipoComprobante, drPedido.Efectivo + drPedido.TotalCheques)
                        'esto es un recibo
                        '# Guardo el recibo generado para luego insertarlo en RepartoComprobantes
                        eRecibo = GrabarRecibo(_tipoComp, _
                                          _formaPago,
                                          _numReparto, _
                                          oCliente, _
                                          vendedor, _
                                          "Recibo por pago con Varios medios", _
                                          drPedido.Efectivo + drPedido.TotalCheques, _
                                          drPedido.Efectivo, _
                                          drPedido.TotalCheques, 0, Nothing, _
                                          _ComprobantesGrilla, drPedido.GetChequesRows)
                        RegistrarCambios(compro, InsertarProductos(drPedido, compro))
                        If drPedido.CuentaCorriente > 0 Then
                           ActualizarCC(drPedido)
                        Else
                           ActualizarFechaRendicion(drPedido)
                        End If

                     Case String.Empty
                        drPedido.FormaPago = noRendida
                  End Select


                  If drPedido.FormaPago <> noRendida Then

                     If drPedido.FormaPago <> ReEnvio Then

                        drPedido.FormaPago = Rendida

                     End If
                     ' busco las formas de pago de los pedidos.
                  End If

               End If
            Catch ex As Exception
               Throw New Exception(String.Format("Error procesando el comprobante {0}-{1}-{2}-{3}: {4}",
                                                 drPedido.IdTipoComprobante, drPedido.Letra,
                                                 drPedido.CentroEmisor, drPedido.NumeroComprobante,
                                                 ex.Message), ex)
               tspBarra.Value = 0
               tspBarra.Visible = False
            End Try


            ' # Busco el reparto al cuál pertenece el recibo.
            ' # En caso de no encontrarlo, inserto un nuevo registro y dejo los campos correspondientes a la factura NULL.
            Dim eRepartoComprobante As Entidades.RepartoComprobante = New Entidades.RepartoComprobante()
            rRepartoComprobantes = New Reglas.RepartosComprobantes()

            If Not String.IsNullOrEmpty(drPedido.FormaPago) AndAlso eRecibo IsNot Nothing Then
               eRepartoComprobante = rRepartoComprobantes.ExisteFactura(eRecibo.IdSucursal,
                                                                        eRecibo.NumeroReparto.Value,
                                                                        drPedido.IdTipoComprobante,
                                                                        drPedido.Letra,
                                                                        drPedido.CentroEmisor,
                                                                        drPedido.NumeroComprobante)

               ' # Si se encontró el registro, actualizo los campos vinculados al recibo. 
               If eRepartoComprobante IsNot Nothing Then
                  ' # Recibo
                  eRepartoComprobante.Recibo = eRecibo

                  ' # Update
                  rRepartoComprobantes.Actualizar(eRepartoComprobante)
               Else
                  eRepartoComprobante = New Entidades.RepartoComprobante
                  eRepartoComprobante.IdSucursal = eRecibo.IdSucursal
                  eRepartoComprobante.IdReparto = eRecibo.NumeroReparto.Value

                  ' # Establezco el Nro de Orden para la operación
                  If ultimoNroOrden = 0 Then ' # Significa que no se encontraron registros para ese ID Reparto
                     ultimoNroOrden = eRepartoComprobante.IdReparto
                  End If
                  eRepartoComprobante.Orden = ultimoNroOrden + 1
                  ultimoNroOrden = eRepartoComprobante.Orden

                  ' # Recibo
                  eRepartoComprobante.Recibo = eRecibo

                  ' # Create
                  rRepartoComprobantes.Insertar(eRepartoComprobante)
               End If

               '# Cargo el dataset con los reicbos para luego imprimirlo como resumen detallado
               Dim dr As dtsRegistracionPagos.RecibosRow = dsRecibos.NewRecibosRow()

               dr.IdSucursal = eRecibo.IdSucursal
               dr.IdReparto = eRecibo.NumeroReparto.Value
               dr.Orden = ultimoNroOrden
               dr.IdTipoComprobanteRec = eRecibo.TipoComprobante.IdTipoComprobante
               dr.CentroEmisorRec = eRecibo.CentroEmisor
               dr.LetraRec = eRecibo.Letra
               dr.NumeroComprobanteRec = eRecibo.NumeroComprobante
               dr.ImporteTotalRec = eRecibo.ImporteTotal
               dr.IdSucursalRec = eRecibo.IdSucursal
               dr.CodigoCliente = drPedido.CodigoCliente
               dr.NombreCliente = drPedido.NombreCliente
               dr.FormaPago = drPedido.FormaDePago
               dr.Observacion = eRecibo.Observacion

               dsRecibos.AddRecibosRow(dr)
            End If

         Next

         Try
            If String.IsNullOrWhiteSpace(txtNumeroReparto.Text) OrElse Long.Parse(Me.txtNumeroReparto.Text) = 0 Then
               For Each drProdComp As DataRow In Me._dtProductosSinDescargoComprobante.Rows
                  Dim oProductoSinDescargar As Eniac.Entidades.RepartoProductoSinDescargar = New Eniac.Entidades.RepartoProductoSinDescargar
                  oProductoSinDescargar.IdSucursal = actual.Sucursal.Id
                  oProductoSinDescargar.IdReparto = Integer.Parse(drProdComp("IdReparto").ToString())
                  oProductoSinDescargar.IdProducto = drProdComp("IdProducto").ToString()
                  oProductoSinDescargar.Cantidad = Decimal.Parse(drProdComp("Cantidad").ToString())
                  oProductoSinDescargar.Precio = Decimal.Parse(drProdComp("Precio").ToString())
                  repartoProdSinDescargar.Merge(oProductoSinDescargar)
               Next
            Else
               For Each drProducto As DataRow In Me._dtProductosSinDescargo.Rows
                  Dim oProductoSinDescargar As Eniac.Entidades.RepartoProductoSinDescargar = New Eniac.Entidades.RepartoProductoSinDescargar
                  oProductoSinDescargar.IdSucursal = actual.Sucursal.Id
                  oProductoSinDescargar.IdReparto = Integer.Parse(txtNumeroReparto.Text)
                  oProductoSinDescargar.IdProducto = drProducto("IdProducto").ToString()
                  oProductoSinDescargar.Cantidad += Decimal.Parse(drProducto("Cantidad").ToString())
                  oProductoSinDescargar.Precio = Decimal.Parse(drProducto("Precio").ToString())
                  repartoProdSinDescargar.Merge(oProductoSinDescargar)
               Next
            End If

            Dim rReparto As Eniac.Reglas.Repartos = New Eniac.Reglas.Repartos()
            Dim reparto As Entidades.Reparto = New Entidades.Reparto() With {.IdSucursal = actual.Sucursal.Id, .IdReparto = Integer.Parse(txtNumeroReparto.Text)}
            'No tiene sentido recuperar todo el reparto cuando la actualización toma solo la clave primaria y actualiza solo los totales
            'Dim reparto As Entidades.Reparto = ReglaReparto.GetUno(actual.Sucursal.Id, Integer.Parse(txtNumeroReparto.Text), Eniac.Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
            With reparto
               .TotalResumenComprobante = Decimal.Parse(txtTotalComprobantes.Text)
               .TotalResumenEfectivo = Decimal.Parse(txtTotalEfectivo.Text)
               .TotalResumenCtaCte = Decimal.Parse(txttotalCC.Text)
               .TotalResumenCheques = Decimal.Parse(txttotalCheque.Text)
               .TotalResumenNCred = Decimal.Parse(txtTotalNC.Text)
               .TotalResumenReenvio = Decimal.Parse(txtTotalReenvios.Text)
               .TotalResumenSaldoGeneral = Decimal.Parse(txtTotalSubtotales.Text)
            End With
            rReparto.Actualizar(reparto)
         Catch ex As Exception
            Throw New Exception("Error procesando el Reparto", ex)
            tspBarra.Value = 0
            tspBarra.Visible = False
         End Try


         tspBarra.Value = 0
         tspBarra.Visible = False

         ShowMessage("¡Comprobantes Rendidos correctamente!")

         Using frmConfirmacion As RegistracionPagosConfirmacion = New RegistracionPagosConfirmacion()
            If frmConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

               '# Resumen
               If frmConfirmacion.ImprimeResumen Then
                  ImprimirResumen(tentativo:=False)
               End If

               '# Resumen Detallado
               If frmConfirmacion.ImprimeResumenDetallado Then
                  ImprimirResumenDetallado(dsRecibos)
               End If

            End If
         End Using
         cargarGrillas()

      End If

   End Sub

   Private Sub RegistrarCambios(venta As Eniac.Entidades.Venta, ventasProductosNC As List(Of Eniac.Entidades.VentaProducto))
      If ventasProductosNC Is Nothing Then ventasProductosNC = New List(Of Eniac.Entidades.VentaProducto)()

      Dim mps = New List(Of Eniac.Entidades.MovimientoStockProducto)()
      Dim mp As Eniac.Entidades.MovimientoStockProducto

      Dim orden As Integer = 0
      Dim vpNC As Eniac.Entidades.VentaProducto
      For Each vp As Eniac.Entidades.VentaProducto In venta.VentasProductos
         vpNC = Nothing
         For Each q As Eniac.Entidades.VentaProducto In (From vpNCq As Eniac.Entidades.VentaProducto In ventasProductosNC
                                                         Where vpNCq.IdProducto = vp.IdProducto And vpNCq.Orden = vp.Orden
                                                         Select vpNCq)
            vpNC = q
         Next

         If vp.TipoOperacion = Eniac.Entidades.Producto.TiposOperaciones.CAMBIO Then
            mp = New Eniac.Entidades.MovimientoStockProducto()
            mp.IdSucursal = actual.Sucursal.Id
            mp.IdProducto = vp.IdProducto
            'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
            'mp.CantidadDefectuoso = vp.Cantidad
            orden += 1
            mp.Orden = orden
            mps.Add(mp)
            If vpNC IsNot Nothing Then
               'mp.CantidadDefectuoso = mp.CantidadDefectuoso - vpNC.Cantidad
               mp = New Eniac.Entidades.MovimientoStockProducto()
               mp.IdSucursal = actual.Sucursal.Id
               mp.IdProducto = vp.IdProducto
               'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
               mp.Cantidad = vpNC.Cantidad
               orden += 1
               mp.Orden = orden
               mps.Add(mp)
            End If
         ElseIf vp.TipoOperacion = Eniac.Entidades.Producto.TiposOperaciones.BONIFICACION Or
               (vp.TipoOperacion = Eniac.Entidades.Producto.TiposOperaciones.NORMAL And vp.Precio = 0) Then
            If vpNC IsNot Nothing Then
               mp = New Eniac.Entidades.MovimientoStockProducto()
               mp.IdSucursal = actual.Sucursal.Id
               mp.IdProducto = vp.IdProducto
               'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
               mp.Cantidad = vp.Cantidad
               orden += 1
               mp.Orden = orden
               mps.Add(mp)
            End If
         End If
      Next

      If mps.Count > 0 Then
         Dim idTipoMovimiento As String = Publicos.RegistracionPagosTipoMovimiento
         If String.IsNullOrWhiteSpace(idTipoMovimiento) Then
            Throw New Exception("No está definido Tipo de movimiento para Cambio.")
         End If
         Dim movi = New Eniac.Entidades.MovimientoStock()
         movi.IdSucursal = actual.Sucursal.Id
         movi.Sucursal = actual.Sucursal
         movi.TipoMovimiento = New Eniac.Reglas.TiposMovimientos().GetUno(idTipoMovimiento)
         movi.FechaMovimiento = Now
         movi.Usuario = actual.Nombre
         movi.Observacion = String.Format("Registración de pagos de: {0} {1} {2:0000}-{3:00000000}",
                                          venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)
         movi.Productos = mps

         Dim rMovCom = New Reglas.MovimientosStock()
         rMovCom.Insertar(movi, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)
      End If

   End Sub

   Private Sub GrabarReenvio(ByVal pedido As dtsRegistracionPagos.PedidosRow, ByVal EsPagoTotal As Boolean)
      'busco el pedido, luego actualizo con el nuevo nro de reparto.
      Dim oPedido As Reglas.Ventas = New Reglas.Ventas()

      Dim strFiltro As String
      strFiltro =
         String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                       pedido.IdSucursal, pedido.IdTipoComprobante, pedido.Letra, pedido.CentroEmisor, pedido.NumeroComprobante)

      'oPedido.ActualizarPedidoPorReenvio(strFiltro, NumeroReparto, pedido.IdTransportistaNuevo, pedido.FechaEnvioNueva)
      oPedido.ActualizarPedidoPorReenvio(strFiltro, Nothing, Nothing, Nothing)

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      rCtaCte.ActualizarNumeroReparto(pedido.IdSucursal, pedido.IdTipoComprobante, pedido.Letra, pedido.CentroEmisor, pedido.NumeroComprobante, numeroReparto:=Nothing)

   End Sub

   Private Sub ActualizarCC(ByVal pedido As dtsRegistracionPagos.PedidosRow)
      Dim opedido As Reglas.Ventas = New Reglas.Ventas()
      opedido.ModificarFormaPago(actual.Sucursal.Id, _
                                 pedido.IdTipoComprobante, _
                                 pedido.Letra, _
                                 pedido.CentroEmisor, _
                                 pedido.NumeroComprobante)
   End Sub

   Private Sub ActualizarFechaRendicion(ByVal pedido As dtsRegistracionPagos.PedidosRow)
      Dim opedido As Reglas.Ventas = New Reglas.Ventas()
      opedido.ModificarFechaRendicion(actual.Sucursal.Id, _
                                      pedido.IdTipoComprobante, _
                                      pedido.Letra, _
                                      pedido.CentroEmisor, _
                                      pedido.NumeroComprobante)
   End Sub

   Private Function ValidarComprobante() As Boolean
      Return True
   End Function

   Private Function InsertarProductos(ByVal drPedido As dtsRegistracionPagos.PedidosRow, compro As Eniac.Entidades.Venta) As List(Of Eniac.Entidades.VentaProducto)
      Dim oLineaDetalle As Eniac.Entidades.VentaProducto
      Dim ventasProductos As List(Of Eniac.Entidades.VentaProducto) = New List(Of Eniac.Entidades.VentaProducto)()

      For Each drProducto As dtsRegistracionPagos.ProductosRow In drPedido.GetProductosRows
         If drProducto.Devuelve > 0 Then

            Dim vp As Eniac.Entidades.VentaProducto = compro.VentasProductos.Find(Function(x) x.Orden = drProducto.Orden And x.IdProducto = drProducto.IdProducto)

            Dim precio As Decimal
            Dim importeDevuelve As Decimal

            If (compro.Cliente.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or _
               Not compro.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Then
               precio = vp.Precio
               importeDevuelve = drProducto.ImporteDevuelve
            Else
               'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
               precio = vp.Precio ''Math.Round(vp.PrecioNeto * (1 + (vp.AlicuotaImpuesto / 100)), 2) '' Math.Round(vp.Precio / (1 + (vp.AlicuotaImpuesto / 100)), 4)
               importeDevuelve = drProducto.ImporteDevuelve ''Math.Round(drProducto.ImporteDevuelve * (1 + (vp.AlicuotaImpuesto / 100)), 2)
            End If



            oLineaDetalle = New Eniac.Entidades.VentaProducto()
            Me.CargarUnArticulo(oLineaDetalle,
                                vp.IdProducto,
                                vp.NombreProducto,
                                vp.DescuentoRecargoPorc1,
                                vp.DescuentoRecargoPorc2,
                                0,
                                precio,
                                drProducto.Devuelve,
                                importeDevuelve,
                                0,
                                vp.Costo,
                                precio,
                                0,
                                Eniac.Entidades.TipoImpuesto.Tipos.IVA,
                                vp.AlicuotaImpuesto,
                                precio * vp.AlicuotaImpuesto / 100,
                                precio,
                                drProducto.IdListaPrecios,
                                drProducto.PorcImpuestoInterno,
                                DirectCast([Enum].Parse(GetType(Eniac.Entidades.OrigenesPorcImpInt), drProducto.OrigenPorcImpInt), Eniac.Entidades.OrigenesPorcImpInt),
                                drProducto.IdMotivo)

            oLineaDetalle.Orden = ventasProductos.Count + 1
            ventasProductos.Add(oLineaDetalle)
         End If
      Next

      Return ventasProductos
   End Function

   Private Sub CargarUnArticulo(linea As Eniac.Entidades.VentaProducto,
                                idProducto As String,
                                productoDescripcion As String,
                                descuentoRecargoPorc1 As Decimal,
                                descuentoRecargoPorc2 As Decimal,
                                descuentoRecargo As Decimal,
                                precio As Decimal,
                                cantidad As Decimal,
                                importeTotal As Decimal,
                                stock As Decimal,
                                costo As Decimal,
                                precioLista As Decimal,
                                kilos As Decimal,
                                idTipoImpuesto As Eniac.Entidades.TipoImpuesto.Tipos,
                                porcentajeIva As Decimal,
                                importeIva As Decimal,
                                precioNeto As Decimal,
                                idListaPrecios As Integer,
                                porcImpuestoInterno As Decimal,
                                origenPorcImpInt As Eniac.Entidades.OrigenesPorcImpInt,
                                idEstadoVenta As Integer)

      With linea
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         '.Producto.IdProducto = idProducto
         .Producto = New Eniac.Reglas.Productos().GetUno(idProducto)  'Luego uso ciertas caracteristicas (ej: LOTE).
         .Producto.NombreProducto = productoDescripcion   'Piso la descripcion por si tiene habilitado la posibilidad de cambiarlas.
         .DescuentoRecargoPorc1 = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         .DescuentoRecargo = descuentoRecargo
         .Precio = precio
         .Cantidad = cantidad
         .ImporteTotal = importeTotal
         .Stock = stock
         .Costo = costo
         .PrecioLista = precioLista
         .Kilos = kilos
         .PrecioNeto = precioNeto
         .AlicuotaImpuesto = porcentajeIva
         .ImporteImpuesto = importeIva
         .TipoImpuesto = New Eniac.Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .IdListaPrecios = idListaPrecios
         .PorcImpuestoInterno = porcImpuestoInterno
         .OrigenPorcImpInt = origenPorcImpInt
         .IdEstadoVenta = idEstadoVenta
      End With
   End Sub

   Private Sub tsbPagarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPagarTodo.Click

      If MessageBox.Show("¿Desea marcar todos los comprobantes como rendidos en EFECTIVO?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
         Exit Sub
      End If

      For Each drPedido As dtsRegistracionPagos.PedidosRow In DtsRegistracionPagos.Pedidos
         If Not drPedido.IsFormaPagoNull AndAlso Not String.IsNullOrWhiteSpace(drPedido.FormaPago) Then
            If MessageBox.Show("Este pedido tiene asiganada una forma de pago, desea cambiarla?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
               Me.ugvDetallePedidos.Focus()
               Continue For
            Else ' cambia forma de pago, elimino de todas las grillas las formas de pago
               QuitarFormaPago(drPedido)
            End If
         End If

         drPedido.FormaPago = Efectivo
         drPedido.Efectivo = drPedido.ImporteTotal

      Next

      DtsRegistracionPagos.AcceptChanges()

      If ugvDetallePedidos.ActiveCell IsNot Nothing Then
         ugvDetallePedidos.ActiveCell.CancelUpdate()
      End If

      CalcularTotales()

   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click

      utcPreventa.SelectedTab = utcPreventa.Tabs("tbcDetallePago")
      Me.txtNumeroReparto.Text = "0"
      cmbModoConsultarComprobantes.SelectedValue = Reglas.Publicos.RegistracionPagosModoConsultarComprobantes
      chbLocalidad.Checked = False
      Me.cmbLocalidad.SelectedValue = 0
      Me.chbRespDistribucion.Checked = False
      Me.cmbRespDistribucion.SelectedValue = 0
      Me.dtpFechaHasta.Value = Date.Today
      Me.dtpFechaRend.Value = Date.Today
      Me.btnBuscar.Enabled = True

      DtsRegistracionPagos.Clear()

      Me.txttotalCC.Text = "0"
      Me.txttotalCheque.Text = "0"
      Me.txtTotalComprobantes.Text = "0"
      Me.txtTotalEfectivo.Text = "0"
      Me.txtTotalNC.Text = "0"
      Me.txtTotalReenvios.Text = "0"
      Me.txtTotalSubtotales.Text = "0"

      Me.tsbGrabar.Enabled = True
      tsbPagarTodo.Enabled = True
      If _dsProductosSinDescargo IsNot Nothing Then
         _dsProductosSinDescargo.Clear()
      End If
      If _dtProductosSinDescargo IsNot Nothing Then _dtProductosSinDescargo.Clear()
      If _dtProductosSinDescargoComprobante IsNot Nothing Then _dtProductosSinDescargo.Clear()
      Me.chbRuta.Checked = False
      Me.chbVendedor.Checked = False
   End Sub

   Private Sub chbLocalidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLocalidad.CheckedChanged
      Try
         Me.cmbLocalidad.Enabled = Me.chbLocalidad.Checked
         If Not Me.chbLocalidad.Checked Then

            Me.cmbLocalidad.SelectedIndex = -1
         Else
            If Me.cmbLocalidad.Items.Count > 0 Then
               Me.cmbLocalidad.SelectedIndex = 0
            End If

            Me.cmbLocalidad.Focus()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbRespDistribucion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRespDistribucion.CheckedChanged
      Try
         Me.cmbRespDistribucion.Enabled = Me.chbRespDistribucion.Checked
         If Not Me.chbRespDistribucion.Checked Then

            Me.cmbRespDistribucion.SelectedIndex = -1
         Else
            If Me.cmbRespDistribucion.Items.Count > 0 Then
               Me.cmbRespDistribucion.SelectedIndex = 0
            End If

            Me.cmbRespDistribucion.Focus()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
      Try

         If String.IsNullOrWhiteSpace(txtNumeroReparto.Text) OrElse Long.Parse(Me.txtNumeroReparto.Text) = 0 Then
            ShowMessage("El número de Reparto es requerido.")
            'If MessageBox.Show("Esta seguro de filtrar sin número de reparto", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Me.txtNumeroReparto.Focus()
            Exit Sub
            'End If
         End If

         If New Reglas.Repartos().Get1(actual.Sucursal.Id, Integer.Parse(Me.txtNumeroReparto.Text)).Rows.Count = 0 Then
            ShowMessage("El número de Reparto ingresado no fue registrado con Organizar Entrega.")
            Me.txtNumeroReparto.Focus()
            Exit Sub
         End If
         If Me.chbRuta.Checked And Me.cmbRuta.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Ruta aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbRuta.Focus()
            Exit Sub
         End If
         If Me.chbDias.Checked And Me.cmbDias.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Dia aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbDias.Focus()
            Exit Sub
         End If

         Me.cargarGrillas()

         utcPreventa.SelectedTab = utcPreventa.Tabs("tbcDetallePago")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cargarGrillas()

      Dim cl As Reglas.RegistracionPagos = New Reglas.RegistracionPagos()

      Dim fechaHasta As DateTime
      Dim distribucion As Integer = 0
      Dim localidad As Integer = 0
      Dim numeroReparto As Integer = 0

      Dim IdVendedor As Integer = 0

      fechaHasta = Me.dtpFechaHasta.Value


      If Me.cmbRespDistribucion.Enabled Then
         distribucion = Integer.Parse(Me.cmbRespDistribucion.SelectedValue.ToString())
      End If

      If Me.cmbLocalidad.Enabled Then
         localidad = Integer.Parse(Me.cmbLocalidad.SelectedValue.ToString())
      End If

      numeroReparto = If(IsNumeric(txtNumeroReparto.Text), Integer.Parse(Me.txtNumeroReparto.Text), 0)


      If Me.cmbVendedor.Enabled Then
         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
      End If


      DtsRegistracionPagos.Clear()

      _dsProductosSinDescargo.Clear()
      _dtProductosSinDescargoComprobante.Clear()

      Dim modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes = Entidades.RegistracionPagos.ModoConsultarComprobantes.SoloRepartoSeleccionado
      If cmbModoConsultarComprobantes.SelectedIndex > -1 Then
         modoConsultarComprobantes = DirectCast(cmbModoConsultarComprobantes.SelectedValue, Entidades.RegistracionPagos.ModoConsultarComprobantes)
      End If

      Dim diaSeleccionado As Entidades.Publicos.Dias? = Nothing
      If chbDias.Checked Then diaSeleccionado = Me.cmbDias.ValorSeleccionado(Of Entidades.Publicos.Dias)()

      DtsRegistracionPagos.Pedidos.Merge(cl.GetPedidos(actual.Sucursal.IdSucursal, distribucion, localidad, numeroReparto, fechaHasta, True, modoConsultarComprobantes, IdVendedor,
                                                       If(chbRuta.Checked, Integer.Parse(cmbRuta.SelectedValue.ToString()), 0), diaSeleccionado), False, MissingSchemaAction.Ignore)

      DtsRegistracionPagos.Productos.Merge(cl.GetPedidosProductos(actual.Sucursal.IdSucursal, distribucion, localidad, numeroReparto, fechaHasta, True, modoConsultarComprobantes, IdVendedor,
                                                                  If(chbRuta.Checked, Integer.Parse(cmbRuta.SelectedValue.ToString()), 0), diaSeleccionado), False, MissingSchemaAction.Ignore)

      If Me.ugvDetallePedidos.Rows.Count = 1 Then
         Me.tssRegistros.Text = Me.ugvDetallePedidos.Rows.Count.ToString() & " Registro"
      Else
         Me.tssRegistros.Text = Me.ugvDetallePedidos.Rows.Count.ToString() & " Registros"
      End If

      CalcularTotales()
   End Sub

   Private Sub tsbVarias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbVarias.Click
      Try
         SeteaOtrasFormas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbEfectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEfectivo.Click
      Try
         SeteaFormaPago(Efectivo)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub SeteaFormaPago(ByVal formaPago As String)
      Dim drPedido As dtsRegistracionPagos.PedidosRow = GetCurrentPedidoRow()
      If drPedido Is Nothing Then
         MessageBox.Show("Debe seleccionar una Factura!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.ugvDetallePedidos.Focus()
         Exit Sub
      End If

      If Not drPedido.IsFormaPagoNull AndAlso Not String.IsNullOrWhiteSpace(drPedido.FormaPago) AndAlso drPedido.FormaPago <> formaPago Then
         If MessageBox.Show("Este pedido tiene asiganada una forma de pago, desea cambiarla?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Me.ugvDetallePedidos.Focus()
            Exit Sub
         Else ' cambia forma de pago, elimino de todas las grillas las formas de pago
            QuitarFormaPago(drPedido)
         End If
      End If

      Select Case formaPago
         Case Efectivo
            drPedido.Efectivo = drPedido.ImporteTotal
         Case CC
            drPedido.CuentaCorriente = drPedido.ImporteTotal
         Case NC
            Using frm As frmMotivoNC = New frmMotivoNC(drPedido)
               If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  drPedido.TotalNC = drPedido.ImporteTotal

                  For Each drProducto As dtsRegistracionPagos.ProductosRow In drPedido.GetProductosRows
                     drProducto.IdMotivo = frm.IdMotivo
                     drProducto.Motivo = frm.Motivo
                     drProducto.Devuelve = drProducto.Cantidad
                     drProducto.ImporteDevuelve = drProducto.ImporteTotal

                  Next
                  AgregarProductoSinDescargo(drPedido)
               Else
                  Exit Sub
               End If

            End Using

         Case ReEnvio
            '' ''Using frm As CambiarFechaEnvioyRespDist = New CambiarFechaEnvioyRespDist(drPedido)
            '' ''   If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '' ''      drPedido.TotalReenvio = drPedido.ImporteTotal
            '' ''      drPedido.FechaEnvioNueva = frm.NuevaFecha
            '' ''      drPedido.IdTransportistaNuevo = frm.NuevoTransportista.idTransportista
            '' ''      drPedido.NombreTransportistaNuevo = frm.NuevoTransportista.NombreTransportista

            '' ''      ProximoReparto()
            '' ''   Else
            '' ''      Exit Sub
            '' ''   End If
            '' ''End Using
            drPedido.TotalReenvio = drPedido.ImporteTotal
            AgregarProductoSinDescargo(drPedido)
      End Select
      drPedido.FormaPago = formaPago

      DtsRegistracionPagos.AcceptChanges()

      CalcularTotales()

      If ugvDetallePedidos.ActiveCell IsNot Nothing Then
         ugvDetallePedidos.ActiveCell.CancelUpdate()
      End If

      ugvDetallePedidos.PerformAction(UltraGridAction.NextRow)

      EstadoToolbar()
   End Sub

   Private Sub QuitarFormaPago(ByVal FilaPago As dtsRegistracionPagos.PedidosRow)
      If FilaPago IsNot Nothing Then
         FilaPago.Efectivo = 0
         FilaPago.CuentaCorriente = 0
         FilaPago.TotalNC = 0
         FilaPago.TotalCheques = 0
         FilaPago.TotalReenvio = 0
         FilaPago.SetFechaEnvioNuevaNull()
         FilaPago.SetIdTransportistaNuevoNull()
         FilaPago.SetNombreTransportistaNuevoNull()

         FilaPago.FormaPago = String.Empty

         For Each drProducto As dtsRegistracionPagos.ProductosRow In FilaPago.GetProductosRows
            drProducto.Motivo = String.Empty
            drProducto.Devuelve = 0
            drProducto.ImporteDevuelve = 0

            For Each drComp As DataRow In _dtProductosSinDescargoComprobante.Rows
               If Integer.Parse(drComp("IdSucursal").ToString()) = drProducto.IdSucursal And
                  drComp("IdTipoComprobante").ToString() = drProducto.IdTipoComprobante And
                  drComp("Letra").ToString() = drProducto.Letra And
                  Integer.Parse(drComp("CentroEmisor").ToString()) = drProducto.CentroEmisor And
                  Long.Parse(drComp("NumeroPedido").ToString()) = drProducto.NumeroComprobante And
                   drComp("IdProducto").ToString() = drProducto.IdProducto Then
                  _dtProductosSinDescargoComprobante.Rows.Remove(drComp)
                  Exit For
               End If
            Next
            For Each drProd As DataRow In _dtProductosSinDescargo.Rows
               If drProd("IdProducto").ToString() = drProducto.IdProducto Then
                  drProd("Cantidad") = Decimal.Parse(drProd("Cantidad").ToString()) - drProducto.Cantidad
               End If
               If Decimal.Parse(drProd("Cantidad").ToString()) = 0 Then
                  _dtProductosSinDescargo.Rows.Remove(drProd)
                  Exit For
               End If
            Next
         Next
         For Each drCheques As dtsRegistracionPagos.ChequesRow In FilaPago.GetChequesRows
            DtsRegistracionPagos.Cheques.Rows.Remove(drCheques)
         Next
      End If
   End Sub

   Private Function GetCurrentPedidoRow() As dtsRegistracionPagos.PedidosRow
      Dim drPedido As dtsRegistracionPagos.PedidosRow = Nothing

      If ugvDetallePedidos.ActiveRow IsNot Nothing AndAlso
         ugvDetallePedidos.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugvDetallePedidos.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugvDetallePedidos.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then
         If TypeOf (DirectCast(ugvDetallePedidos.ActiveRow.ListObject, DataRowView).Row) Is dtsRegistracionPagos.ProductosRow AndAlso
            ugvDetallePedidos.ActiveRow.ParentRow IsNot Nothing Then
            ugvDetallePedidos.ActiveRow = ugvDetallePedidos.ActiveRow.ParentRow
         End If
         If TypeOf (DirectCast(ugvDetallePedidos.ActiveRow.ListObject, DataRowView).Row) Is dtsRegistracionPagos.PedidosRow Then
            drPedido = DirectCast(DirectCast(ugvDetallePedidos.ActiveRow.ListObject, DataRowView).Row, dtsRegistracionPagos.PedidosRow)
         End If
      End If

      Return drPedido
   End Function

   Private Sub tsbCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCC.Click
      Try
         SeteaFormaPago(CC)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNC.Click
      Try
         SeteaFormaPago(NC)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbReenvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReenvio.Click
      Try
         SeteaFormaPago(ReEnvio)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbNoRendir_Click(sender As Object, e As EventArgs) Handles tsbNoRendir.Click
      Try
         SeteaFormaPago(String.Empty)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CalcularTotales()

      Dim TComprobantes As Decimal = 0
      Dim TEfectivo As Decimal = 0
      Dim TNC As Decimal = 0
      Dim Tcheque As Decimal = 0
      Dim Tcc As Decimal = 0
      Dim TReenvios As Decimal = 0


      For Each drPedido As dtsRegistracionPagos.PedidosRow In DtsRegistracionPagos.Pedidos
         TComprobantes += drPedido.ImporteTotal
         TEfectivo += drPedido.Efectivo
         Tcc += drPedido.CuentaCorriente
         TNC += drPedido.TotalNC
         Tcheque += drPedido.TotalCheques
         TReenvios += drPedido.TotalReenvio
      Next

      Me.txtTotalComprobantes.Text = TComprobantes.ToString("N2")

      Me.txtTotalEfectivo.Text = TEfectivo.ToString("N2")
      Me.txtTotalNC.Text = TNC.ToString("N2")
      Me.txttotalCheque.Text = Tcheque.ToString("N2")
      Me.txttotalCC.Text = Tcc.ToString("N2")
      Me.txtTotalReenvios.Text = TReenvios.ToString("N2")

      Dim subTotales As Decimal
      subTotales = TEfectivo + TNC + Tcheque + Tcc + TReenvios


      Me.txtTotalSubtotales.Text = (TComprobantes - subTotales).ToString("N2")

      If (TComprobantes - subTotales) = 0 Then
         Me.txtTotalSubtotales.ForeColor = Color.Green
      Else
         Me.txtTotalSubtotales.ForeColor = Color.Red
      End If

      ugNc.DisplayLayout.Bands(1).ColumnFilters.ClearAllFilters()
      ugNc.DisplayLayout.Bands(1).ColumnFilters("Devuelve").FilterConditions.Add(FilterComparisionOperator.NotEquals, 0D)


   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraGridPrintDocument1.Header.TextCenter = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + "Listado de Clientes"
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 5
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 5
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 14
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 8
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmdImprimirResumen_Click(sender As Object, e As EventArgs) Handles cmdImprimirResumen.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         ImprimirResumen(tentativo:=True)

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ImprimirResumenDetallado(ds As dtsRegistracionPagos.RecibosDataTable)
      Try

         ' # Parámetros del RDLC
         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))

         '# Resolver Informe Personalizado
         Dim reporte As Entidades.InformePersonalizadoResuelto
         Dim strReporte As String = String.Empty
         Dim frmImprime As VisorReportes

         ' Resolver si el cliente tiene informe personalizado
         reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.RegistracionPagosResumenDetallado, "Eniac.Win.ResumenDetallado.rdlc")

         frmImprime = New VisorReportes(reporte.NombreArchivo, "dtsRecibos", ds, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default
      Catch ex As Exception

         ShowError(ex)

      End Try
      


   End Sub

   Private Sub ImprimirResumen(tentativo As Boolean)
      Dim filtro As StringBuilder = New StringBuilder()
      Dim idTransportista As Integer = 0
      If Me.cmbRespDistribucion.Enabled Then
         Dim transportista As Entidades.Transportista = cmbRespDistribucion.ItemSeleccionado(Of Entidades.Transportista)()
         idTransportista = transportista.idTransportista
         filtro.AppendFormat(" Resp. de Distribución: {0} - ", transportista.NombreTransportista)
      End If

      If Me.cmbLocalidad.Enabled Then
         Dim localidad As String = String.Empty
         localidad = DirectCast(Me.cmbLocalidad.SelectedItem, Eniac.Entidades.Localidad).NombreLocalidad
         filtro.AppendFormat("Localidad: {0} - ", cmbLocalidad.ItemSeleccionado(Of Entidades.Localidad)().NombreLocalidad)
      End If

      Dim nroReparto As Integer = Integer.Parse(txtNumeroReparto.Text)
      filtro.AppendFormat("Nro. Reparto: {0} - ", nroReparto)

      filtro.AppendFormat("Fecha Hasta: {0} - ", Me.dtpFechaHasta.Text)

      If tentativo Then
         filtro.Insert(0, "*** TENTATIVO ***  ")
         filtro.Append("  *** TENTATIVO ***")
      End If


      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtro.ToString()))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EFECTIVO", txtTotalEfectivo.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CTACTE", txttotalCC.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CHEQUES", txttotalCheque.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NC", txtTotalNC.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("REENVIOS", txtTotalReenvios.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TOTAL", (CDec(txtTotalEfectivo.Text) +
                                                                          CDec(txttotalCC.Text) +
                                                                          CDec(txttotalCheque.Text) +
                                                                          CDec(txtTotalNC.Text) +
                                                                          CDec(txtTotalReenvios.Text)).ToString("N2")))


      'Dim reglas As Reglas.OrganizarEntregas = New Reglas.OrganizarEntregas()
      Dim dt As New DataTable
      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Resumen.rdlc", "", dt, parm, True, 1) '# 1 = Cantidad Copias

      frmImprime.Text = Me.Text
      frmImprime.WindowState = FormWindowState.Maximized
      frmImprime.ShowDialog()
   End Sub

   Private Sub txtNumeroReparto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroReparto.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnBuscar.Focus()
      End If
   End Sub

   Private Sub cmbLocalidad_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLocalidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnBuscar.Focus()
      End If
   End Sub

   Private Sub cmbRespDistribucion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbRespDistribucion.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnBuscar.Focus()
      End If
   End Sub

   Private Sub dtpFechaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaHasta.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnBuscar.Focus()
      End If
   End Sub

   Private Sub btnBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnBuscar.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnBuscar_Click(sender, Nothing)
      End If
   End Sub

   Private Sub ugvDetallePedidos_AfterRowActivate(sender As Object, e As EventArgs) Handles ugvDetallePedidos.AfterRowActivate
      Try
         EstadoToolbar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub EstadoToolbar()
      Dim drPedido As dtsRegistracionPagos.PedidosRow = GetCurrentPedidoRow()
      If drPedido IsNot Nothing Then
         tsbEfectivo.Enabled = drPedido.FormaPago <> Varias
         tsbVarias.Enabled = True
         tsbCC.Enabled = drPedido.FormaPago <> Varias
         tsbNC.Enabled = drPedido.FormaPago <> Varias
         tsbReenvio.Enabled = drPedido.FormaPago <> Varias
         tsbNoRendir.Enabled = drPedido.FormaPago <> String.Empty
      End If
   End Sub

   Private Sub ugvDetallePedidos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugvDetallePedidos.DoubleClickRow
      Try
         SeteaOtrasFormas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub SeteaOtrasFormas()
      Dim drPedido As dtsRegistracionPagos.PedidosRow = GetCurrentPedidoRow()
      If drPedido Is Nothing Then
         MessageBox.Show("Debe seleccionar una Factura!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.ugvDetallePedidos.Focus()
         Exit Sub
      End If

      If Not drPedido.IsFormaPagoNull AndAlso Not String.IsNullOrWhiteSpace(drPedido.FormaPago) AndAlso drPedido.FormaPago <> Varias Then
         If MessageBox.Show("Este pedido tiene asiganada una forma de pago, desea cambiarla?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Me.ugvDetallePedidos.Focus()
            Exit Sub
         Else ' cambia forma de pago, elimino de todas las grillas las formas de pago
            QuitarFormaPago(drPedido)
         End If
      End If

      DtsRegistracionPagos.AcceptChanges()

      Using frmOtraForma As OtrasFormasPago = New OtrasFormasPago(drPedido)
         If frmOtraForma.ShowDialog() = Windows.Forms.DialogResult.OK Then
            drPedido.FormaPago = Varias
            If ugvDetallePedidos.ActiveCell IsNot Nothing Then
               ugvDetallePedidos.ActiveCell.CancelUpdate()
            End If
            AgregarProductoSinDescargo(drPedido)
            ugvDetallePedidos.PerformAction(UltraGridAction.NextRow)
         End If
      End Using

      CalcularTotales()
   End Sub

   Private Sub AgregarProductoSinDescargo(drPedido As dtsRegistracionPagos.PedidosRow)

      For Each drProducto As dtsRegistracionPagos.ProductosRow In drPedido.GetProductosRows
         Dim existe As Boolean = False
         For Each dr As DataRow In _dtProductosSinDescargo.Rows
            If dr("IdProducto").ToString() = drProducto.IdProducto Then
               existe = True
            End If
         Next
         If existe = False Then
            If drProducto.Devuelve > 0 Then
               Dim drSinDescargo As DataRow = _dtProductosSinDescargo.NewRow()
               drSinDescargo("IdProducto") = drProducto.IdProducto
               drSinDescargo("NombreProducto") = drProducto.NombreProducto
               drSinDescargo("Cantidad") = drProducto.Devuelve
               drSinDescargo("Precio") = drProducto.Precio
               Me._dtProductosSinDescargo.Rows.Add(drSinDescargo)
               Dim drComprobante As DataRow = _dtProductosSinDescargoComprobante.NewRow()
               drComprobante("IdProducto") = drProducto.IdProducto
               drComprobante("IdSucursal") = drPedido.IdSucursal
               drComprobante("IdTipoComprobante") = drPedido.IdTipoComprobante
               drComprobante("Letra") = drPedido.Letra
               drComprobante("CentroEmisor") = drPedido.CentroEmisor
               drComprobante("NumeroPedido") = drPedido.NumeroComprobante
               If Not drPedido.IsNumeroRepartoNull Then
                  drComprobante("IdReparto") = drPedido.NumeroReparto
               End If
               drComprobante("NombreProducto") = drProducto.NombreProducto
               drComprobante("Cantidad") = drProducto.Devuelve
               drComprobante("Precio") = drProducto.Precio
               drComprobante("TipoOperacion") = drProducto.TipoOperacion
               drComprobante("CodigoCliente") = drPedido.CodigoCliente
               drComprobante("NombreCliente") = drPedido.NombreCliente
               Me._dtProductosSinDescargoComprobante.Rows.Add(drComprobante)
            End If
         Else
            For Each drProd As DataRow In _dtProductosSinDescargo.Rows
               If drProd("IdProducto").ToString() = drProducto.IdProducto Then
                  drProd("Cantidad") = Decimal.Parse(drProd("Cantidad").ToString()) + drProducto.Devuelve
                  Me._dtProductosSinDescargo.AcceptChanges()
                  For Each drComp As DataRow In _dtProductosSinDescargoComprobante.Rows
                     If drProducto.Devuelve > 0 Then
                        Dim drComprobante As DataRow = _dtProductosSinDescargoComprobante.NewRow()
                        If Not (Integer.Parse(drComp("IdSucursal").ToString()) = drProducto.IdSucursal And
                           drComp("IdTipoComprobante").ToString() = drProducto.IdTipoComprobante And
                           drComp("Letra").ToString() = drProducto.Letra And
                           Integer.Parse(drComp("CentroEmisor").ToString()) = drProducto.CentroEmisor And
                           Long.Parse(drComp("NumeroPedido").ToString()) = drProducto.NumeroComprobante) And
                           drComp("IdProducto").ToString() = drProducto.IdProducto Then
                           drComprobante("IdProducto") = drProducto.IdProducto
                           drComprobante("IdSucursal") = drPedido.IdSucursal
                           drComprobante("IdTipoComprobante") = drPedido.IdTipoComprobante
                           drComprobante("Letra") = drPedido.Letra
                           drComprobante("CentroEmisor") = drPedido.CentroEmisor
                           drComprobante("NumeroPedido") = drPedido.NumeroComprobante
                           drComprobante("IdReparto") = drPedido.NumeroReparto
                           drComprobante("NombreProducto") = drProducto.NombreProducto
                           drComprobante("Cantidad") = drProducto.Devuelve
                           drComprobante("Precio") = drProducto.Precio
                           drComprobante("TipoOperacion") = drProducto.TipoOperacion
                           drComprobante("CodigoCliente") = drPedido.CodigoCliente
                           drComprobante("NombreCliente") = drPedido.NombreCliente
                           Me._dtProductosSinDescargoComprobante.Rows.Add(drComprobante)
                           Me._dtProductosSinDescargoComprobante.AcceptChanges()
                           Exit For
                        End If
                     End If
                  Next
               End If
            Next
         End If
      Next
      Me.ugvProductosSinDescargar.DataSource = _dsProductosSinDescargo.Tables("ProductosSinDescargo")
      AjustarColumnasGrillaProductosSinDescargo()
   End Sub

   Private Sub CrearDtProductosSinDescargo()

      _dtProductosSinDescargo = New DataTable()
      _dtProductosSinDescargo.Columns.Add("IdProducto", GetType(String))
      _dtProductosSinDescargo.Columns.Add("NombreProducto", GetType(String))
      _dtProductosSinDescargo.Columns.Add("Cantidad", GetType(Decimal))
      _dtProductosSinDescargo.Columns.Add("Precio", GetType(Decimal))
      _dtProductosSinDescargoComprobante = New DataTable()
      _dtProductosSinDescargoComprobante.Columns.Add("IdProducto", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("IdSucursal", GetType(Integer))
      _dtProductosSinDescargoComprobante.Columns.Add("IdTipoComprobante", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("Letra", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("CentroEmisor", GetType(Short))
      _dtProductosSinDescargoComprobante.Columns.Add("NumeroPedido", GetType(Integer))
      _dtProductosSinDescargoComprobante.Columns.Add("IdReparto", GetType(Integer))
      _dtProductosSinDescargoComprobante.Columns.Add("NombreProducto", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("Cantidad", GetType(Decimal))
      _dtProductosSinDescargoComprobante.Columns.Add("Precio", GetType(Decimal))
      _dtProductosSinDescargoComprobante.Columns.Add("CodigoCliente", GetType(Long))
      _dtProductosSinDescargoComprobante.Columns.Add("NombreCliente", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("TipoOperacion", GetType(String))
      _dsProductosSinDescargo = New DataSet()

      Dim Relacion As DataRelation
      _dsProductosSinDescargo.Tables.Add("ProductosSinDescargo", _dtProductosSinDescargo)
      _dsProductosSinDescargo.Tables.Add("ProductosSinDescargoComprobante", _dtProductosSinDescargoComprobante)
      Relacion = New DataRelation("ProductosSinDescargo",
                                  {_dtProductosSinDescargo.Columns("IdProducto")},
                                  {_dtProductosSinDescargoComprobante.Columns("IdProducto")})
      _dsProductosSinDescargo.Relations.Add(Relacion)
   End Sub

   Private Sub tsbImprimirGrilla_Click(sender As Object, e As EventArgs) Handles tsbImprimirGrilla.Click
      Try

         If DtsRegistracionPagos.Tables(0).Rows.Count = 0 Then Exit Sub
         If utcPreventa.Tabs("tbcDetallePago").Selected Then
            UltraGridPrintDocument1.Grid = ugvDetallePedidos
         ElseIf utcPreventa.Tabs("tbcSaldoCliente").Selected Then
            UltraGridPrintDocument1.Grid = ugEfectivo
         ElseIf utcPreventa.Tabs("tbcCuentaCorriente").Selected Then
            UltraGridPrintDocument1.Grid = ugCtaCte
         ElseIf utcPreventa.Tabs("tbcCheque").Selected Then
            UltraGridPrintDocument1.Grid = ugCheque
         ElseIf utcPreventa.Tabs("tbcArticulosNC").Selected Then
            UltraGridPrintDocument1.Grid = ugNc
         ElseIf utcPreventa.Tabs("tbcReenvios").Selected Then
            UltraGridPrintDocument1.Grid = ugReenvios
         ElseIf utcPreventa.Tabs("tbcProductosSinDescargar").Selected Then
            UltraGridPrintDocument1.Grid = ugvProductosSinDescargar
         End If


         Dim Titulo As String
         Titulo = String.Format("{1}{0}{0}{2} - {3}{0}{0}{0}{4}", Environment.NewLine(), Publicos.NombreEmpresaImpresion, Text, utcPreventa.SelectedTab.Text, CargarFiltrosImpresion)
         'Titulo = Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro
         .AppendFormat("Número de Reparto: {0} - ", Me.txtNumeroReparto.Text)
         .AppendFormat("Fecha Hasta: {0} - ", dtpFechaHasta.Text)
         If Me.cmbRespDistribucion.Enabled Then
            .AppendFormat(" Resp. Distribución: {0} - ", Me.cmbRespDistribucion.Text)
         End If
         If Me.cmbLocalidad.Enabled Then
            .AppendFormat(" Localidad: {0} - ", Me.cmbLocalidad.Text)
         End If
      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try

         If DtsRegistracionPagos.Tables.Count = 0 OrElse DtsRegistracionPagos.Tables(0).Rows.Count = 0 Then Exit Sub

         Dim ugdetalle As UltraGrid = Nothing
         Dim nameTab As String = String.Empty
         If utcPreventa.Tabs("tbcDetallePago").Selected Then
            nameTab = utcPreventa.Tabs("tbcDetallePago").Text
            ugdetalle = ugvDetallePedidos
         ElseIf utcPreventa.Tabs("tbcSaldoCliente").Selected Then
            nameTab = utcPreventa.Tabs("tbcSaldoCliente").Text
            ugdetalle = ugEfectivo
         ElseIf utcPreventa.Tabs("tbcCuentaCorriente").Selected Then
            nameTab = utcPreventa.Tabs("tbcCuentaCorriente").Text
            ugdetalle = ugCtaCte
         ElseIf utcPreventa.Tabs("tbcCheque").Selected Then
            nameTab = utcPreventa.Tabs("tbcCheque").Text
            ugdetalle = ugCheque
         ElseIf utcPreventa.Tabs("tbcArticulosNC").Selected Then
            nameTab = utcPreventa.Tabs("tbcArticulosNC").Text
            ugdetalle = ugNc
         ElseIf utcPreventa.Tabs("tbcReenvios").Selected Then
            nameTab = utcPreventa.Tabs("tbcReenvios").Text
            ugdetalle = ugReenvios
         ElseIf utcPreventa.Tabs("tbcProductosSinDescargar").Selected Then
            nameTab = utcPreventa.Tabs("tbcProductosSinDescargar").Text
            ugdetalle = ugvProductosSinDescargar
         End If

         Dim myWorkbook As New Workbook()
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = String.Format("{0} - {1}", Me.Text, nameTab)
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = String.Format("{0}_{1}.xls", Me.Name, Name)
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(ugdetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try

         If DtsRegistracionPagos.Tables.Count = 0 OrElse DtsRegistracionPagos.Tables(0).Rows.Count = 0 Then Exit Sub

         Dim ugdetalle As UltraGrid = Nothing
         Dim nameTab As String = String.Empty
         If utcPreventa.Tabs("tbcDetallePago").Selected Then
            nameTab = utcPreventa.Tabs("tbcDetallePago").Text
            ugdetalle = ugvDetallePedidos
         ElseIf utcPreventa.Tabs("tbcSaldoCliente").Selected Then
            nameTab = utcPreventa.Tabs("tbcSaldoCliente").Text
            ugdetalle = ugEfectivo
         ElseIf utcPreventa.Tabs("tbcCuentaCorriente").Selected Then
            nameTab = utcPreventa.Tabs("tbcCuentaCorriente").Text
            ugdetalle = ugCtaCte
         ElseIf utcPreventa.Tabs("tbcCheque").Selected Then
            nameTab = utcPreventa.Tabs("tbcCheque").Text
            ugdetalle = ugCheque
         ElseIf utcPreventa.Tabs("tbcArticulosNC").Selected Then
            nameTab = utcPreventa.Tabs("tbcArticulosNC").Text
            ugdetalle = ugNc
         ElseIf utcPreventa.Tabs("tbcReenvios").Selected Then
            nameTab = utcPreventa.Tabs("tbcReenvios").Text
            ugdetalle = ugReenvios
         ElseIf utcPreventa.Tabs("tbcProductosSinDescargar").Selected Then
            nameTab = utcPreventa.Tabs("tbcProductosSinDescargar").Text
            ugdetalle = ugvProductosSinDescargar
         End If

         Me.sfdExportar.FileName = String.Format("{0}_{1}.pdf", Me.Name, nameTab)
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(String.Format("{0} - {1}", Me.Text, nameTab) + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(ugdetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub AjustarColumnasGrillaProductosSinDescargo()

      AjustarColumnasGrilla(ugvProductosSinDescargar.DisplayLayout.Bands(0), _titArticulosSinDescargo0)
      AjustarColumnasGrilla(ugvProductosSinDescargar.DisplayLayout.Bands(1), _titArticulosSinDescargo1)

      With ugvProductosSinDescargar.DisplayLayout.Bands(1)
         Dim col As Integer = 0
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdTipoComprobante"), "Tipo", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Letra"), "L.", col, 30)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("CentroEmisor"), "Emisor", col, 50)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NumeroPedido"), "Pedido", col, 70, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdReparto"), "Reparto", col, 70, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreProducto"), "Número", col, 150, HAlign.Left)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Cantidad"), "Cantidad", col, 70, HAlign.Right, False, "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Precio"), "Precio", col, 70, HAlign.Right, False, "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("CodigoCliente"), "Código", col, 80, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreCliente"), "Cliente", col, 250)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("TipoOperacion"), "Tipo de Operación", col, 120)

      End With

   End Sub

   Private Sub chkVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
      If Not Me.chbVendedor.Checked Then

         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If
   End Sub

   Private Sub chbRuta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbRuta.CheckedChanged
      Try
         chbRuta.FiltroCheckedChanged(cmbRuta)
         If Not chbRuta.Checked Then
            chbDias.Checked = False
         End If
         chbDias.Enabled = chbRuta.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbDias_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbDias.CheckedChanged
      Try
         Me.chbDias.FiltroCheckedChanged(Me.cmbDias, -1)
         cmbDias.Enabled = chbDias.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class
