Imports Eniac.Entidades

Public Class PedidosClientesV2
   Implements IConParametros

   '' ''Private _IdCategoriaFiscalOriginal As Short = 0
   Private _ConfiguracionImpresoras As Boolean
   Private _titContactos As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tipoTipoComprobante As String
   Private _solicitaPrecioVentaPorTamano As Boolean = False
   Private _cotizacionDolar_Prev As Decimal
   Private _calculaPreciosSegunFormula As Boolean
   Private _esCopia As Boolean
   Private _frmInvocador As String = ""
   Private _cargandoComboFormula As Boolean = False
   Private _cargandoProductoDesdeCompleto As Boolean = False
   Private _solicitaModificarFormulaLuegoDelProducto As Boolean = True
   Private _dtPedidoSinStock As DataTable = Nothing
   Private _decimalesAnchoLargo As Integer = 0
   Private _formatoAnchoLargo As String = "N0"
   Private _cantidadOriginal As Decimal = 0
   Private _cantidadNoPendienteOriginal As Decimal = 0

   Private _idTipoObservacionDefecto As Short

   Private _fechaActualizacionBD As Date?
   Private _idUsuarioActualizacionBD As String
   Private _idListaAux As Integer = -1

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _esCopia = False
   End Sub

   'Public Sub New(pedido As Entidades.Pedido)
   '   Me.New()
   '   PedidoAEditar = pedido
   'End Sub


#Region "Constantes"

   Private Const funcionActual As String = "Ventas"
   Private Const funcionSupervisor As String = "FacturacionRapidaSuper"
   Private Const funcionActualLimiteCredito As String = "FactV2LimiteCreditoPermitido"
   Private Const funcionActualLimiteDiasVto As String = "FactV2LimiteDiasVtoPermitido"
#End Region
   Private Function LimiteCreditoPermitido() As Boolean
      Return BaseSeguridad.ControloPermisos(funcionActualLimiteCredito)
   End Function
   Private Function LimiteDiasVtoPermitido() As Boolean
      Return BaseSeguridad.ControloPermisos(funcionActualLimiteDiasVto)
   End Function

#Region "Campos"


   Private _pedidosProductos As List(Of Entidades.PedidoProducto)
   Private _pedidosContactos As List(Of Entidades.ClienteContacto)
   Private _pedidosProductosFormulasActual As Entidades.ProductoArbol
   Private _pedidosProductosFormulas As New Dictionary(Of Entidades.PedidoProducto, Entidades.ProductoArbol)()

   Private _editarProductosDesdeGrilla As Boolean

   '-- REQ-41752.- -------------------------------------------------------
   Private _cambioListaPrecio As Integer? = Nothing
   '----------------------------------------------------------------------

   Private _subTotales As List(Of Entidades.VentaImpuesto)
   Private _estado As Estados
   Private _publicos As Publicos
   Private _numeroComprobante As Integer
   Private _clienteE As Entidades.Cliente
   Private _comprobantesSeleccionados As List(Of Entidades.Venta)
   Private _ModificaDetalle As String
   Private _cheques As List(Of Entidades.Cheque)
   Private _tarjetas As List(Of Entidades.VentaTarjeta)
   Private _pedidosObservaciones As List(Of Entidades.PedidoObservacion)
   Private _transportistaA As Entidades.Transportista
   Private _chequesRechazados As List(Of Entidades.Cheque)
   Private _estaCargando As Boolean = True
   Private _cantMaxItems As Integer
   Private _cantMaxItemsObserv As Integer
   Private _imprime As Boolean
   Private _tipoImpuestoIVA As Entidades.TipoImpuesto.Tipos = Entidades.TipoImpuesto.Tipos.IVA
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _productoLoteTemporal As Entidades.VentaProductoLote
   Private _productosLotes As List(Of Entidades.VentaProductoLote)
   Private _numeroOrden As Integer

   Private _descRec1 As Decimal
   Private _descRec2 As Decimal
   Private _descRecPorc1 As Decimal
   Private _descRecPorc2 As Decimal

   Private _decimalesEnDescRec As Integer
   Private _decimalesAMostrarEnTotalXProducto As Integer
   Private _decimalesAMostrarEnPrecio As Integer
   Private _formatoPrecios As String = "N2"
   Private _decimalesRedondeoEnPrecio As Integer   '4
   Private _decimalesEnCantidad As Integer = 2
   Private _decimalesMostrarEnCantidad As Integer = 2
   Private _formatoCantidades As String = "N2"

   Private _decimalesRedondeoEnTamanio As Integer = 2
   Private _decimalesMostrarEnTamanio As Integer = 2      'En el ABM tiene 3, habria que hacerlo seteable.
   Private _formatoTamanio As String = "N2"
   Private _decimalesEnKilos As Integer = 3
   Private _decimalesEnTotales As Integer = 2

   'Private _decimalesEnTotales As Integer = 2
   'Private _valorRedondeo As Integer = 2     '4 Se ajusto hasta que grabemos directamente los campos con IVA
   'Private _decimalesAMostrar As Integer = 2
   'Private _decimalesEnKilos As Integer = 3
   Private _fc As FacturacionComunes
   Private _DescuentosRecargosProd As Eniac.Reglas.DescuentoRecargoProducto
   Private _DescRecGralPorc As Decimal = 0
   Private _txtCantidad_prev As Decimal?
   Private _modificoDescuentosProducto As Boolean
   Private _titProductos As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private _blnCajasModificables As Boolean = True
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja

   Private _vendedorPorClave As Entidades.Empleado

#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

#End Region

#Region "Propiedades"

   Private _soloComprobantesElectronicos As Boolean = False
   Public Property SoloComprobantesElectronicos() As Boolean
      Get
         Return _soloComprobantesElectronicos
      End Get
      Set(value As Boolean)
         _soloComprobantesElectronicos = value
      End Set
   End Property

   Private _pedidoAEditar As Eniac.Entidades.Pedido
   Private Property PedidoAEditar() As Eniac.Entidades.Pedido
      Get
         Return Me._pedidoAEditar
      End Get
      Set(value As Eniac.Entidades.Pedido)
         Me._pedidoAEditar = value
      End Set
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         If Reglas.Publicos.PedidosOcultarRentabilidad = True Then
            lblRentabilidad.Visible = False
            txtRentabilidad.Visible = False
         End If
         ' verifico el parámetro de criticidad para saber si ocultarlo o no
         If Not Reglas.Publicos.PedidosMostrarCriticidad() Then
            Me.lblCriticidad.Visible = False
            Me.cmbCriticidad.Visible = False
         End If

         tbcDetalle.SelectedTab = tbpContactos
         _titContactos = GetColumnasVisiblesGrilla(ugContactos)
         tbcDetalle.SelectedTab = tbpProductos

         _solicitaModificarFormulaLuegoDelProducto = Reglas.Publicos.SolicitaModificarFormulaLuegoDelProducto

         _decimalesRedondeoEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         _decimalesAMostrarEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
         _formatoPrecios = "N" + _decimalesAMostrarEnPrecio.ToString()
         _decimalesAMostrarEnTotalXProducto = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto
         _decimalesEnDescRec = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec

         _decimalesRedondeoEnTamanio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnTamano
         _decimalesMostrarEnTamanio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnTamano
         _formatoTamanio = "N" + _decimalesMostrarEnTamanio.ToString()

         _decimalesAnchoLargo = Reglas.Publicos.PedidosDecimalesMostrarLargoAncho
         _formatoAnchoLargo = "N" + _decimalesAnchoLargo.ToString()

         Me.txtPrecio.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Me.txtDescRec.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Me.txtTotalProducto.Formato = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()
         Me.dgvProductos.Columns("Precio").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Me.dgvProductos.Columns("DescuentoRecargo").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString() 'Oculto por el momento
         Me.dgvProductos.Columns("PrecioNeto").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Me.dgvProductos.Columns("Importe").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            Me._decimalesEnCantidad = 0
            Me.txtCantidad.Formato = "N0"
            Me.txtCantidadManual.Formato = "N0"
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         Else
            _decimalesEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad
            _decimalesMostrarEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad
            _formatoCantidades = "N" + _decimalesMostrarEnCantidad.ToString()
            Me.txtCantidad.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
            Me.txtCantidadManual.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
         End If
         Me.dgvProductos.Columns("Cantidad").DefaultCellStyle.Format = "N" + _decimalesMostrarEnCantidad.ToString()
         Me.dgvProductos.Columns("CantidadManual").DefaultCellStyle.Format = "N" + Me._decimalesMostrarEnCantidad.ToString()

         Me.txtKilos.Formato = "N" + Me._decimalesEnKilos.ToString()
         Me.txtKilosModDesc.Formato = "N" + Me._decimalesEnKilos.ToString()
         Me.dgvProductos.Columns("Kilos").DefaultCellStyle.Format = "N" + Me._decimalesEnKilos.ToString()

         'Seguridad de la Lista de Precios
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         Me.cmbListaDePrecios.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Facturacion-ListaDePrecios")

         'Seguridad del Descuento/Recargo General
         Me.txtDescRecGralPorc.ReadOnly = Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes-DescRecGeneralPorc")
         txtDescRecGralPorc.Formato = "N" + _decimalesEnDescRec.ToString()
         txtDescRecPorc1.Formato = "N" + _decimalesEnDescRec.ToString()
         txtDescRecPorc2.Formato = "N" + _decimalesEnDescRec.ToString()
         Me.dgvProductos.Columns("DescuentoRecargoPorc").DefaultCellStyle.Format = "N" + Me._decimalesEnDescRec.ToString()
         Me.dgvProductos.Columns("DescuentoRecargoPorc2").DefaultCellStyle.Format = "N" + Me._decimalesEnDescRec.ToString()

         Me.dgvProductos.Columns("Utilidad").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()

         '# Seguridad en Cantidad convertida e valor de conversión
         Me.dgvProductos.Columns("Cantidad").Visible = Reglas.Publicos.FacturacionVisualizaCantidadConvertida
         Me.pnlCantidadConvertida.Visible = Reglas.Publicos.FacturacionVisualizaCantidadConvertida
         Me.dgvProductos.Columns("Conversion").Visible = Reglas.Publicos.FacturacionVisualizaConversion

         'Seguridad del Precio y Descuento/Recargo por Producto
         Me.chbModificaPrecio.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Facturacion-ModifPrecioProd")
         Me.chbModificaDescRecargo.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Pedidos-ModifDescRecProd")

         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         Me.llbCliente.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes-PuedeUsarMasInfo")
         '---------------------------------------

         Me._publicos = New Publicos()
         Me._fc = New FacturacionComunes()

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

         If PedidoAEditar IsNot Nothing Then
            Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, _tipoTipoComprobante, , , , )
         Else
            Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, _tipoTipoComprobante, , , , True)
         End If
         If Me.cmbTiposComprobantes.Items.Count = 0 Then
            Me._ConfiguracionImpresoras = True
         End If

         Me._publicos.CargaComboPlazosEntrega(Me.cmbPlazosEntrega)


         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantesFact, False, "VENTAS", , , , True)

         Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)

         '-- REG-30529.- --
         _publicos.CargaComboCajas(cmbCajaPedido, actual.Sucursal.Id, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         cmbCajaPedido.SelectedIndex = -1


         cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.NORMAL)
         If Reglas.Publicos.ProductoPermiteEsCambiable Then
            cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.CAMBIO)
         End If
         If Reglas.Publicos.ProductoPermiteEsBonificable Then
            cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.BONIFICACION)
         End If

         cmbTipoOperacion.SelectedItem = Entidades.Producto.TiposOperaciones.NORMAL
         cmbTipoOperacion.Visible = cmbTipoOperacion.Items.Count > 1
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()).Visible = cmbTipoOperacion.Visible

         _publicos.CargaComboMonedas1(cmbMoneda)
         _publicos.CargaComboMonedas1(cmbMonedaVenta)
         cmbMonedaVenta.SelectedValue = Reglas.Publicos.PedidosMonedaPorDefecto


         If PedidoAEditar IsNot Nothing Then
            If PedidoAEditar.PedidosProductos.Count = 0 Then
               Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisita, True, Nothing)
            Else
               Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisita, Nothing, True)
            End If
         Else
            Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisita, Nothing, True)
         End If

         _idTipoObservacionDefecto = New Reglas.TiposObservaciones().GetIdTipoObservacionDefecto()
         _publicos.CargaComboTiposObservaciones(cmbTipoObservacion)

         'GAR: 13/01/2017
         'Si tiene varios estados pongo predeterminado el Normal.
         'Luego parametrizar
         If Me.cmbEstadoVisita.Items.Count > 0 And Me.cmbEstadoVisita.SelectedIndex = -1 Then
            Me.cmbEstadoVisita.Text = "Normal"
         End If
         '-- Ajuste a Revisar
         Dim blnPermiteFechaEntregaDistintas As Boolean

         blnPermiteFechaEntregaDistintas = Reglas.Publicos.PedidosPermiteFechaEntregaDistintas

         Me.lblFechaEntrega.Visible = Not blnPermiteFechaEntregaDistintas
         Me.dtpFechaEntrega.Visible = Not blnPermiteFechaEntregaDistintas

         Me.lblFechaEntregaProd.Visible = blnPermiteFechaEntregaDistintas
         Me.dtpFechaEntregaProd.Visible = blnPermiteFechaEntregaDistintas

         '-----------------


         Me._publicos.CargaComboCriticidades(Me.cmbCriticidad)
         Me.cmbCriticidad.SelectedIndex = 0
         Me._publicos.CargaComboTipoDocumento(Me.cmbTipoDoc)
         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios, activa:=True, insertarEnPosicionCero:=Nothing)
         Me._publicos.CargaComboImpuestos(Me.cmbPorcentajeIva)

         Me._publicos.CargaComboTransportistas(Me.cmbRespDistribucion)

         _publicos.CargaComboProduccionModeloForma(cmbProductoProduccionModeloForma)

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True
         '  Me._publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, blnMiraUsuario, blnMiraPC)

         Me.lblSemaforoRentabilidad.Visible = Reglas.Publicos.Facturacion.FacturacionVisualizaSemaforoUtilidad
         Me.txtSemaforoRentabilidad.Visible = Me.lblSemaforoRentabilidad.Visible
         'Me.lblSemaforoPorcentaje.Visible = Me.lblSemaforoRentabilidad.Visible
         If Reglas.Publicos.Facturacion.FacturacionSemaforoCalculoMuestra = Entidades.Publicos.SemaforoCalculoMuestra.ContribucionMarginal.ToString() Then
            lblSemaforoRentabilidad.Text = "CMG %"
            lblSemaforoRentabilidadDetalle.Text = "CMG:"
            lblRentabilidadDetalle.Text = "CMG:"
            dgvProductos.Columns("ContribucionMarginalPorc").HeaderText = "CMG %"
            dgvProductos.Columns("Utilidad").HeaderText = "CMG $"
         End If

         Me.SeteaDetalles()

         Me._estaCargando = False

         _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            Me.txtCantidad.Formato = "##,##0"
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         End If

         'If Publicos.VisualizaNrosSerie Then
         '   dgvProductos.Columns("NrosSerie").Visible = True
         'End If

         txtTotalMetrosCuadrados.Text = "0." + New String("0"c, Me._decimalesMostrarEnTamanio)

         Me.dgvProductos.Columns("FechaEntrega").DefaultCellStyle.Format() = "dd/MM/yyyy"

         txtTamanio.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarTamano
         txtUM.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarUM
         pnlTamanio.Visible = txtTamanio.Visible Or txtUM.Visible
         pnlCosto.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarCosto
         pnlPrecioVentaPorTamano.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarPrecioVentaPorTamano
         lblPrecioVentaPorTamano2.Text = String.Empty
         pnlMoneda.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarMoneda
         pnlSemaforoRentabilidadDetalle.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarSemaforoRentabilidadDetalle
         pnlRentabilidadDetalle.Visible = pnlSemaforoRentabilidadDetalle.Visible

         cmbMonedaVenta.Enabled = Reglas.Publicos.Facturacion.FacturacionPermiteFacturarEnOtrasMonedas

         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.Tamano.ToString()).Visible = txtTamanio.Visible
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).Visible = txtUM.Visible
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.Costo.ToString()).Visible = pnlCosto.Visible
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString()).Visible = pnlPrecioVentaPorTamano.Visible
         dgvProductos.Columns(Entidades.Moneda.Columnas.NombreMoneda.ToString()).Visible = pnlMoneda.Visible
         dgvProductos.Columns("ContribucionMarginalPorc").Visible = pnlSemaforoRentabilidadDetalle.Visible
         dgvProductos.Columns("Utilidad").Visible = pnlRentabilidadDetalle.Visible

         pnlProductoEspmm.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoEspmm
         pnlProductoEspPulgadas.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoEspPulgadas
         pnlProductoSAE.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoSAE
         pnlProductoProduccionProceso.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoProduccionProceso
         pnlProductoProduccionForma.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoProduccionForma
         pnlProductoLargoExtAlto.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoLargoExtAlto
         pnlProductoAnchoIntBase.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoAnchoIntBase
         pnlProductoArchitrave.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoArchitrave
         pnlProductoProduccionModeloForma.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarProductoModeloForma
         pnlProductoUrlPlano.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarUrlPlanoDetalle

         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.Espmm.ToString()).Visible = pnlProductoEspmm.Visible
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.EspPulgadas.ToString()).Visible = pnlProductoEspPulgadas.Visible
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.CodigoSAE.ToString()).Visible = pnlProductoSAE.Visible
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.AnchoIntBase.ToString()).Visible = pnlProductoAnchoIntBase.Visible
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.LargoExtAlto.ToString()).Visible = pnlProductoLargoExtAlto.Visible
         dgvProductos.Columns(Entidades.PedidoProducto.Columnas.Architrave.ToString()).Visible = pnlProductoArchitrave.Visible
         dgvProductos.Columns(Entidades.ProduccionModeloForma.Columnas.NombreProduccionModeloForma.ToString()).Visible = pnlProductoProduccionModeloForma.Visible
         dgvProductos.Columns(Entidades.ProduccionProceso.Columnas.NombreProduccionProceso.ToString()).Visible = pnlProductoProduccionProceso.Visible
         dgvProductos.Columns(Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString()).Visible = pnlProductoProduccionForma.Visible
         dgvProductos.Columns("UrlPlanoCount").Visible = pnlProductoUrlPlano.Visible

         pnlFormula.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarFormula
         dgvProductos.Columns("NombreFormula").Visible = pnlFormula.Visible

         pnlProcesoProductivo.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarFormula
         dgvProductos.Columns("NombreProcesoProductivo").Visible = pnlProcesoProductivo.Visible

         pnlNota.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarNota
         dgvProductos.Columns("Nota").Visible = pnlNota.Visible

         If pnlProductoProduccionProceso.Visible Then
            _publicos.CargaComboProduccionProcesos(cmbProductoProduccionProceso)
         End If
         If pnlProductoProduccionForma.Visible Then
            _publicos.CargaComboProduccionFormas(cmbProductoProduccionForma)
         End If

         txtProductoAnchoIntBase.Formato = _formatoAnchoLargo
         txtProductoLargoExtAlto.Formato = _formatoAnchoLargo
         txtProductoArchitrave.Formato = _formatoAnchoLargo
         dgvProductos.Columns(LargoExtAlto.Name).DefaultCellStyle.Format = _formatoAnchoLargo
         dgvProductos.Columns(AnchoIntBase.Name).DefaultCellStyle.Format = _formatoAnchoLargo
         dgvProductos.Columns(Architrave.Name).DefaultCellStyle.Format = _formatoAnchoLargo

         LimpiarCamposProductos()

         OrdenarGrillaProductos()
         _titProductos = GetColumnasVisiblesGrilla(dgvProductos)

         If Not _ConfiguracionImpresoras Then
            Me.Nuevo()
         End If

         '-- REQ-32987.- -------------------------------------------------------------------
         If PedidoAEditar IsNot Nothing Then
            Me.cmbTiposComprobantes.SelectedValue = PedidoAEditar.IdTipoComprobante.ToString()
            '----------------------------------------------------------------------------------
            cmbPlazosEntrega.SelectedValue = PedidoAEditar.IdPlazoEntrega
         End If

         cmbRespDistribucion.Visible = Reglas.Publicos.PedidosSolicitaTransportista
         cmbRespDistribucion.LabelAsoc.Visible = cmbRespDistribucion.Visible
         '-- REQ-34970.- -----------------------------------------------------------
         txtTotalMetrosCuadrados.Visible = pnlPrecioVentaPorTamano.Visible
         txtTotalMetrosCuadrados.LabelAsoc.Visible = txtTotalMetrosCuadrados.Visible
         '--------------------------------------------------------------------------

         cmbTiposComprobantesFact.Visible = Reglas.Publicos.PedidosSolicitaComprobanteGenerar
         cmbTiposComprobantesFact.LabelAsoc.Visible = cmbTiposComprobantesFact.Visible

         CargaTipoComprobanteProducto()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub dtpFechaEntregaProd_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaEntregaProd.KeyDown
      If e.KeyCode = Keys.Enter Then
         If cmbNota.Enabled AndAlso cmbNota.Visible Then
            cmbNota.Focus()
         Else
            btnInsertar.Select()
         End If
      End If
   End Sub
   Private Sub cmbNota_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbNota.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnInsertar.Select()
      End If
   End Sub

   Private Sub cmbCriticidad_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCriticidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.dtpFechaEntregaProd.Visible Then
            Me.dtpFechaEntregaProd.Focus()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
      End If
   End Sub

   Private Sub Facturacion_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

      Select Case e.KeyCode
         Case Keys.F5
            tsbNuevo.PerformClick()
         Case Keys.F4
            tsbGrabar.PerformClick()
         Case Keys.F6
            btnHistoricoVentas.PerformClick()
         Case Keys.F7
            btnBuscarProducto.PerformClick()
         Case Keys.F9
            tbcDetalle.SelectedTab = tbpProductos
            bscCodigoProducto2.Focus()
         Case Keys.F12
            tbcDetalle.SelectedTab = tbpTotales
            txtDescRecGralPorc.Focus()
         Case Keys.Add
            If e.Control Then
               btnInsertar.PerformClick()
            End If
         Case Keys.Subtract, Keys.OemMinus
            If e.Control Then
               If dgvProductos.SelectedRows.Count > 0 Then
                  btnEliminar.PerformClick()
                  If dgvProductos.Rows.Count > 0 Then
                     dgvProductos.Focus()
                  Else
                     bscCodigoProducto2.Focus()
                  End If
               End If
            End If
         Case Keys.Escape
            btnLimpiarProducto.PerformClick()
         Case Keys.G
            If e.Control Then
               If dgvProductos.RowCount > 0 Then
                  dgvProductos.FirstDisplayedScrollingRowIndex = dgvProductos.Rows.Count - 1
                  dgvProductos.Rows(dgvProductos.Rows.Count - 1).Selected = True
                  dgvProductos.SelectedRows(0).Cells("IdProducto").Selected = True
               End If
               dgvProductos.Focus()
            End If
         Case Else
      End Select
   End Sub


   Private Sub tsbNuevo_Click(sender As Object, e As System.EventArgs) Handles tsbNuevo.Click
      Try
         If ShowPregunta(Traducciones.TraducirTexto("ATENCION: ¿Desea Realizar un Pedido Nuevo?", Me, "__ConfirmarNuevoComprobante")) = Windows.Forms.DialogResult.Yes Then
            Nuevo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As System.EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)

         Dim idCliente As Long = 0
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , , , GetTipoOperacionSeleccionada(), , , , , idCliente, soloBuscaPorIdProducto:=_editarProductosDesdeGrilla)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Dim idCliente As Long = 0
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , , GetTipoOperacionSeleccionada(), , , , , idCliente)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion, bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtDescuento_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescRec.LostFocus
      Try
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtDescRecPorc1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecPorc1.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtDescRecPorc2.Focus()
      End If
   End Sub

   Private Sub txtDescRecPorc1_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescRecPorc1.LostFocus
      Try
         If Me.txtDescRecPorc1.Text = "" Or Me.txtDescRecPorc1.Text = "-" Then
            Me.txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtDescRecPorc2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecPorc2.KeyDown
      If e.KeyCode = Keys.Enter Then
         If (Me.bscProducto2.Enabled Or txtProductoObservacion.Visible) And Reglas.Publicos.PedidosModificaDescripSolicitaKilos Then
            Me.txtKilosModDesc.Focus()
         Else
            Me.cmbCriticidad.Focus()
         End If
      End If
   End Sub

   Private Sub txtKilosModDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKilosModDesc.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.cmbCriticidad.Focus()
      End If
   End Sub


   Private Sub txtDescRecPorc2_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescRecPorc2.LostFocus
      Try
         If Me.txtDescRecPorc2.Text = "" Or Me.txtDescRecPorc2.Text = "-" Then
            Me.txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtDescRecGralPorc_GotFocus(sender As Object, e As System.EventArgs) Handles txtDescRecGralPorc.GotFocus
      Me.txtDescRecGralPorc.SelectAll()
   End Sub

   Private Sub txtDescRecGralPorc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecGralPorc.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtTotalGeneral.Focus()
      End If
   End Sub

   Private Sub txtDescRecGralPorc_Leave(sender As Object, e As System.EventArgs) Handles txtDescRecGralPorc.Leave
      Try
         Me.CalcularDatosDetalle()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtTotalDescRec_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescRecGral.LostFocus
      Me.CalcularTotales()
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.GrabarComprobante()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
         Me.tsbGrabar.Enabled = True
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            CargarDatosCliente(e.FilaDevuelta)
         End Sub,
         onErrorAction:=
         Sub(owner, ex)
            ShowError(ex)
            TryCatched(Sub() Nuevo())
         End Sub)
   End Sub

   Private Sub llbCliente_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked
      Try
         MostrarMasInfo()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoClienteVinculado_BuscadorClick() Handles bscCodigoClienteVinculado.BuscadorClick

      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoClienteVinculado)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If IsNumeric(Me.bscCodigoClienteVinculado.Text.Trim()) Then
            codigoCliente = Long.Parse(Me.bscCodigoClienteVinculado.Text.Trim())
         End If
         Me.bscCodigoClienteVinculado.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCodigoClienteVinculado_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoClienteVinculado.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteVinculado(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscClienteVinculado_BuscadorClick() Handles bscClienteVinculado.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscClienteVinculado)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscClienteVinculado.Datos = oClientes.GetFiltradoPorNombre(Me.bscClienteVinculado.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscClienteVinculado_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscClienteVinculado.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteVinculado(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub HabilitaComprobanteFactSegunLineas()
      cmbTiposComprobantesFact.Enabled = dgvProductos.RowCount = 0
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As System.EventArgs) Handles btnInsertar.Click
      Try
         If (Not Me.bscProducto2.FilaDevuelta Is Nothing Or Not Me.bscCodigoProducto2.FilaDevuelta Is Nothing) And Me.txtCantidad.Text <> "" Then
            If Me.ValidarInsertaProducto() Then
               Me.InsertarProducto()
               Me.bscCodigoProducto2.Focus()
               If Me._ModificaDetalle <> "TODO" Then
                  Me.CambiarEstadoControlesDetalle(False)
               End If
               '-- REQ-41752.- ------------------------------------------------------------------
               If _cambioListaPrecio.HasValue Then
                  cmbListaDePrecios.SelectedValue = _cambioListaPrecio
                  _cambioListaPrecio = Nothing
               End If
               '---------------------------------------------------------------------------------
            End If
            '-- REQ-41995.- ------------------------------------------------------------------
            If _cambioListaPrecio.HasValue Then
               cmbListaDePrecios.SelectedValue = _cambioListaPrecio
               _cambioListaPrecio = Nothing
            End If
            '---------------------------------------------------------------------------------
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvProductos.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               EliminarLineaProducto(soloBorrar:=True)
               bscCodigoProducto2.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub chbModificaPrecioyBonificaciones_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbModificaPrecio.CheckedChanged

      SoloLecturaPrecios(Not Me.chbModificaPrecio.Checked)

      If Me.chbModificaPrecio.Checked Then
         FocusPrecio()
      Else
         txtCantidadManual.Select()
         Me.txtCantidadManual.SelectAll()
      End If

   End Sub

   Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaDescRecargo.Checked Then
            Me.txtDescRecPorc1.Focus()
            Me.txtDescRecPorc1.SelectAll()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
         'Me.txtDescRecPorc1.Focus()
      End If
   End Sub

   Private Sub txtPrecio_LostFocus(sender As Object, e As System.EventArgs) Handles txtPrecio.LostFocus
      Try
         If Me.txtPrecio.Text.Trim().Length = 0 Then
            Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtCantidad_LostFocus(sender As Object, e As System.EventArgs) Handles txtCantidad.LostFocus, txtCantidadManual.LostFocus
      Try

         ''# En caso de que la unidad de medida seleccionada NO sea la unidad de medida principal del producto, realizo la conversión
         'Dim f = If(Me.bscCodigoProducto2.FilaDevuelta IsNot Nothing, Me.bscCodigoProducto2.FilaDevuelta, Me.bscProducto2.FilaDevuelta)
         'If f IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.txtCantidadManual.Text) Then
         '   Me.txtCantidad.Text = Me.RealizarConversionUnidadesMedida(CDec(Me.txtCantidadManual.Text), CDec(f.Cells("Conversion").Value), Me.cmbUM2).ToString()
         'End If

         Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual

         If Me.txtCantidad.Text.Trim().Length = 0 Then
            Me.txtCantidad.Text = "1." + New String("0"c, Me._decimalesEnCantidad)
         Else
            If Me.txtPrecio.Text = "-" Then
               Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
            End If
         End If

         'El Sub "Nuevo" ejecuta este evento y daba error porque 
         If Not String.IsNullOrEmpty(Me.bscCodigoProducto2.Text) Then

            'Se calculan los decuentos por Cantidad/Rubro
            Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text.ToString())

            If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
               _txtCantidad_prev = Nothing
               Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

               For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
                  If vp.Producto.IdRubro = Producto.IdRubro Then
                     cantidad += vp.Cantidad
                  End If
               Next

               Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, Producto, cantidad, Me._decimalesEnTotales)

               For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
                  If vp.Producto.IdRubro = Producto.IdRubro Then
                     vp.DescuentoRecargoPorc = _DescuentosRecargosProd.DescuentoRecargo1
                     If calculaDescuentoRecargo2 Then
                        vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
                     End If
                  End If
                  vp.DescuentoRecargoProducto = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                                           vp.DescuentoRecargoPorc, vp.DescuentoRecargoPorc2, vp.Cantidad)
               Next
               'RecalcularTodo()
            Else
               Me._DescuentosRecargosProd = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), Me._decimalesEnTotales)
            End If

            Dim cambia As Boolean = False
            If Not _txtCantidad_prev.HasValue OrElse _txtCantidad_prev.Value <> Decimal.Parse(Me.txtCantidad.Text.ToString()) Then

               cambia = True
               'SI SE MODIFICARON MANUALMENTE LOS DESCUENTOS EN LA LINEA A MODIFICAR Y CAMBIO LA CANTIDAD
               If _modificoDescuentosProducto Then
                  cambia = False
                  'ME FIJO SI LOS DESCUENTOS QUE EL SISTEMA CALCULA SON DISTINTO A CERO Y SI, TAMBIEN, SON DIFERENTES A LOS QUE ESTAN EN LA LINEA MODIFICADA
                  If (_DescuentosRecargosProd.DescuentoRecargo1 <> 0 Or _DescuentosRecargosProd.DescuentoRecargo2 <> 0) And
                      (Decimal.Parse(Me.txtDescRecPorc1.Text) <> Me._DescuentosRecargosProd.DescuentoRecargo1 Or
                       Decimal.Parse(Me.txtDescRecPorc2.Text) <> Me._DescuentosRecargosProd.DescuentoRecargo2) Then
                     'SI EL DESCUENTO FUE MODIFICADO MANUALMENTE Y EL CALCULADO POR EL SISTEMA DIFIERE DE ESTE Y DE CERO, PREGUNTO AL USUARIO QUE QUIERE HACER
                     'SI PRESIONA 'SI' EN LA PREGUNTA, CAMBIO EL DESCUENTO POR EL CALCULADO POR EL SISTEMA
                     cambia = MessageBox.Show(String.Format("Los descuentos calculados por el sistema difieren de los descuentos de la línea que se está modificando." + Environment.NewLine + Environment.NewLine +
                                                            "Según sistema: {0:N2} y {1:N2}" + Environment.NewLine +
                                                            "Descuento modificado: {2:N2} y {3:N2}" + Environment.NewLine + Environment.NewLine +
                                                            "¿Desea tomar el nuevo descuento calculado por el sistema o mantener el descuento modificado?" + Environment.NewLine + Environment.NewLine +
                                                            "SI: Toma el del sistema" + Environment.NewLine +
                                                            "NO: Mantiene el modificado",
                                                            Me._DescuentosRecargosProd.DescuentoRecargo1,
                                                            Me._DescuentosRecargosProd.DescuentoRecargo2,
                                                            Decimal.Parse(Me.txtDescRecPorc1.Text),
                                                            Decimal.Parse(Me.txtDescRecPorc2.Text)), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes
                  End If
               End If
            End If

            'SIGNIFICA QUE DEBE CAMBIAR LOS DESCUENTOS DE LA PANTALLA
            If cambia Then
               Me.txtDescRecPorc1.Text = Me._DescuentosRecargosProd.DescuentoRecargo1.ToString("N" + _decimalesEnDescRec.ToString())
               If calculaDescuentoRecargo2 Then
                  Me.txtDescRecPorc2.Text = Me._DescuentosRecargosProd.DescuentoRecargo2.ToString("N" + _decimalesEnDescRec.ToString())
               End If
            End If

            '# Si el producto tiene una bonificación x Lista de Precios x cantidad, se cambia la lista de precios y se modifica el precio
            If Producto.TipoBonificacion = Entidades.Producto.TiposBonificacionesProductos.LISTAPRECIO AndAlso
           Not Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
               BonificacionListaDePrecioXCantidad(Producto, txtCantidad.ValorNumericoPorDefecto(0D))
            End If

         End If

         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown, txtCantidadManual.KeyDown
      If e.KeyCode = Keys.Enter Then
         If txtProductoAnchoIntBase.Enabled AndAlso txtProductoAnchoIntBase.Visible Then
            txtProductoAnchoIntBase.Focus()
         ElseIf txtProductoLargoExtAlto.Enabled AndAlso txtProductoLargoExtAlto.Visible Then
            txtProductoLargoExtAlto.Focus()
         ElseIf txtProductoArchitrave.Enabled AndAlso txtProductoArchitrave.Visible Then
            txtProductoArchitrave.Focus()
         ElseIf cmbProductoProduccionForma.Enabled AndAlso cmbProductoProduccionForma.Visible Then
            cmbProductoProduccionForma.Focus()
         ElseIf Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            FocusPrecio()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
      End If
   End Sub

   Private Sub cmbPorcentajeIva_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPorcentajeIva.KeyDown
      'If e.KeyCode = Keys.Enter Then
      'Me.PresionarTab(e)
      'End If
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            FocusPrecio()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
      End If
   End Sub

   Private Sub cmbPorcentajeIva_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbPorcentajeIva.SelectedIndexChanged
      Try
         If Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing And Me.cmbPorcentajeIva.Tag IsNot Nothing Then
            If (Not cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
               Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Dim actualPrecio As Decimal = Decimal.Parse(Me.txtPrecio.Tag.ToString())
               'Dim impuestoInterno As Decimal = Decimal.Parse(Me.txtImpuestoInterno.Text)
               Dim iidb As FacturacionV2.ImpIntDesdeBusquedas = FacturacionV2.GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)

               actualPrecio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(actualPrecio, Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()),
                                                                                   iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
               actualPrecio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(actualPrecio, Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()),
                                                                                   iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)

               Me.txtPrecio.Text = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
               Me.txtPrecio.Tag = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As System.EventArgs) Handles btnLimpiarProducto.Click
      Me.LimpiarCamposProductos()
      Me.bscCodigoProducto2.Focus()
   End Sub

   Private Sub dgvProductos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
      Try
         If _ModificaDetalle <> "NO" Then
            'limpia los textbox, y demas controles
            Me.LimpiarCamposProductos()
            'carga el producto seleccionado de la grilla en los textbox

            '# Seteo la propiedad en True para indicar que voy a editar un producto que se encuentra en la grilla y debe buscar por Código Exacto.
            _editarProductosDesdeGrilla = True
            Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex), editarProductosDesdeGrilla:=_editarProductosDesdeGrilla)
            'elimina el producto de la grilla
            Me.EliminarLineaProducto(soloBorrar:=False)

            If Me._ModificaDetalle = "SOLOPRECIOS" Then
               Me.txtPrecio.Enabled = True
               Me.txtDescRecPorc1.Enabled = True
               Me.txtDescRecPorc2.Enabled = True

               'Si Cliente utiliza impuestos, y Empresa utiliza impuestos, y es un comprobante en negro
               'If Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
               '############## ver
               Me.cmbPorcentajeIva.Enabled = True
               'End If

               Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
               Me.btnInsertar.Enabled = True
               FocusPrecio()
            Else
               txtCantidadManual.Select()
               Me.txtCantidadManual.SelectAll()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Private Sub bscDireccion_BuscadorClick() Handles bscDireccion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscDireccion)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscDireccion.Datos = oClientes.GetFiltradoPorDireccion(Me.bscDireccion.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscDireccion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDireccion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Try
            Me.Nuevo()
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub


   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         If Me.tbcDetalle.Contains(Me.tbpProductos) Then
            If Me.tbcDetalle.SelectedTab Is Me.tbpProductos Then
               Me.bscCodigoProducto2.Focus()
            End If
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub cmbListaDePrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbListaDePrecios.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbListaDePrecios_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbListaDePrecios.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         If Reglas.Publicos.ActualizaPreciosDeVenta Then
            Me.RecalcularTodo(recuperaCosto:=False, desdeListaPrecios:=True)
         Else
            SetearPrecio()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtCotizacionDolar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCotizacionDolar.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbCategoriaFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCategoriaFiscal.KeyDown, cmbEstadoVisita.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         'Si es X es remito y siempre debe tener esa letra
         If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "B" Or Me.txtLetra.Text = "C" Or Me.txtLetra.Text = "E") And Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
            Me.txtLetra.Text = Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).LetraFiscal
         End If

         'If Me.cmbCategoriaFiscal.SelectedIndex >= 0 And Me._clienteE IsNot Nothing Then

         '   'Limpio Si cambio de categoria fiscal y tenia Facturables. Sino cambiar toda toda la logica del calculo del iva del producto, pero no es razonable.
         '   If Short.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString()) <> Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IdCategoriaFiscal And Me.dgvFacturables.RowCount > 0 Then

         '      Me._ventasProductos = Nothing
         '      Me._ventasProductos = New List(Of Entidades.VentaProducto)
         '      Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()

         '      Me._comprobantesSeleccionados = Nothing
         '      Me._comprobantesSeleccionados = New List(Of Entidades.Venta)

         '      Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados

         '   End If

         'End If

         If Me._clienteE IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then

            ''Me._clienteE.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString()))

            'Exento sin IVA (Cliente o Empresa). 
            If Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Me.cmbPorcentajeIva.Text = "0." + New String("0"c, Me._decimalesEnTotales)
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
               Me.cmbPorcentajeIva.Enabled = False
            Else
               Me.cmbPorcentajeIva.Enabled = True
            End If

            'Si es un comprobante en blanco no deberia cambiar el IVA del producto
            'SPC: Debería tomar el tipo de comprobante a generar
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
               Me.cmbPorcentajeIva.Enabled = False
            End If

            Me.RecalcularTodo(recuperaCosto:=True, desdeListaPrecios:=False)
            Me.LimpiarCamposProductos()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub cmbVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVendedor.KeyDown

      If e.KeyCode = Keys.Enter And Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
         If Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante Then

            Me.bscCodigoProducto2.Focus()
         End If
      Else
         Me.PresionarTab(e)
      End If

   End Sub

   Private Sub txtPercepcionIVA_Leave(sender As Object, e As System.EventArgs) Handles txtPercepcionIVA.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionIVA.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionIIBB.Focus()
      End If
   End Sub

   Private Sub txtPercepcionIIBB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionIIBB.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionGanancias.Focus()
      End If
   End Sub

   Private Sub txtPercepcionIIBB_Leave(sender As Object, e As System.EventArgs) Handles txtPercepcionIIBB.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_Leave(sender As Object, e As System.EventArgs) Handles txtPercepcionGanancias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionGanancias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionVarias.Focus()
      End If
   End Sub

   Private Sub txtPercepcionVarias_Leave(sender As Object, e As System.EventArgs) Handles txtPercepcionVarias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionVarias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionVarias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtTotalPercepcion.Focus()
      End If
   End Sub

   Private Sub txtProductoObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoObservacion.KeyDown
      If e.KeyCode = Keys.Enter Then
         Dim oProd As Reglas.Productos = New Reglas.Productos()
         Dim prod As Entidades.Producto = New Entidades.Producto()
         prod = oProd.GetUno(Me.bscCodigoProducto2.Text)

         If txtCantidadManual.Enabled And Not prod.EsObservacion Then
            txtCantidadManual.Select()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
      End If
   End Sub


   Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
      TryCatched(
      Sub()
         Dim pedidoProducto = dgvProductos.FilaSeleccionada(Of Entidades.PedidoProducto)
         'If Me.dgvProductos.Rows.Count = 0 Then Exit Sub
         'If Me.dgvProductos.SelectedRows.Count = 0 Then Exit Sub
         'If e.RowIndex <> -1 Then
         If pedidoProducto IsNot Nothing Then
            'Dim pedidoProducto = dr ' As Entidades.PedidoProducto = DirectCast(Me.dgvProductos.SelectedRows(0).DataBoundItem, Entidades.PedidoProducto)
            If dgvProductos.Columns(e.ColumnIndex).Name = "NrosSerie" Then
               If pedidoProducto.Producto.NrosSeries.Count > 0 Then
                  Dim onrosSerie = New Reglas.ProductosNrosSerie()
                  Dim cantidadDeProductos = pedidoProducto.Producto.NrosSeries.Count
                  '-- REQ-32489.- ---------------------------------------------------------
                  Using nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, pedidoProducto.Producto.IdDeposito, pedidoProducto.Producto.IdUbicacion, pedidoProducto.Producto.IdProducto)
                     Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, pedidoProducto.Producto, nrosSerie)
                     If sel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        pedidoProducto.Producto.NrosSeries.Clear()
                        pedidoProducto.Producto.NrosSeries = sel.ProductosNrosSerie
                     End If
                  End Using
               End If
            ElseIf dgvProductos.Columns(e.ColumnIndex).Name = "UrlPlanoCount" Then
               If Not String.IsNullOrWhiteSpace(pedidoProducto.UrlPlano) Then
                  Try
                     Process.Start(pedidoProducto.UrlPlano)
                  Catch ex As Exception
                     ShowError(ex)
                  End Try
               End If
            ElseIf dgvProductos.Columns(e.ColumnIndex).Name = dgvProductos_verFormula.Name Then
               Using frm = New EstructuraProductos()
                  Dim forma = cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma)
                  frm.ShowDialog(Me, _pedidosProductosFormulas(pedidoProducto), GetValoresForma(pedidoProducto, False), pedidoProducto.ProduccionModeloForma,
                                 txtCotizacionDolar.ValorNumericoPorDefecto(0D), StateForm.Consultar)
               End Using
            End If
         End If
      End Sub)

   End Sub

   Private Sub dgvProductos_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvProductos.KeyUp
      If Me.dgvProductos.SelectedRows.Count > 0 Then
         'Control y la tecla "-" de un teclado o nobebook.
         If e.Control And (e.KeyCode = Keys.Subtract Or e.KeyCode = Keys.OemMinus) Then
            Me.btnEliminar.PerformClick()
            Me.dgvProductos.Focus()
         End If
      End If
   End Sub

#End Region

#Region "Metodos"
   Private Sub SetearPrecio()
      If _clienteE Is Nothing Then Return
      If cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios) Is Nothing Then Return
      'Dim dr = bscCodigoProducto2.FilaDevuelta
      Dim idProducto = bscCodigoProducto2.Text.Trim()
      Dim oProductos = New Reglas.Productos()
      Dim dt = oProductos.GetPorCodigo(idProducto, actual.Sucursal.Id,
                                       cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios).IdListaPrecios,
                                       "VENTAS", , , , , , , , , _clienteE.IdCliente)
      If dt.Count > 0 Then
         Dim dr = dt(0)

         Dim producto = New Reglas.Productos().GetUno(idProducto, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
         If producto IsNot Nothing Then
            Dim p = FacturacionAyudantes.GetPrecio(dr.Field(Of Decimal)("PrecioVentaSinIVA"), dr.Field(Of Decimal)("PrecioVentaConIVA"),
                                                   producto, _clienteE, dtpFecha.Value, _nroOferta:=0, _categoriaFiscalEmpresa, codigoBarrasCompleto:=String.Empty,
                                                   txtCotizacionDolar.ValorNumericoPorDefecto(0D), modalidad:=Entidades.Producto.Modalidades.NORMAL, _decimalesRedondeoEnPrecio,
                                                   FormaDePago:=Nothing)

            txtPrecio.Text = p.ToString(_formatoPrecios)
            txtPrecio.Tag = txtPrecio.Text
         End If
      End If

   End Sub
   Private Sub SeteaConversionUnidadesMedida()
      FacturacionV2.SeteaConversionUnidadesMedida(Me.bscCodigoProducto2, Me.bscProducto2, Me.cmbUM2, Me.txtCantidad, Me.txtCantidadManual)
   End Sub

   'Private Function RealizarConversionUnidadesMedida(cantidadAConvertir As Decimal, valorConversion As Decimal, combo As Eniac.Controles.ComboBox) As Decimal

   '   '# Si la UM seleccionada es la 2da, se realiza la conversión. En caso de que la UM seleccionada sea la principal, no se realiza ninguna conversión.
   '   Dim result As Decimal = cantidadAConvertir
   '   If combo.Items.Count > 1 AndAlso combo.SelectedIndex > 0 Then
   '      result = (cantidadAConvertir / valorConversion)
   '   End If
   '   Return result

   'End Function

   Private Sub CargaComboUnidadesMedida(um1 As Entidades.UnidadDeMedida, um2 As Entidades.UnidadDeMedida, combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreUnidadDeMedida"
         .ValueMember = "IdUnidadDeMedida"

         Dim lista As List(Of Entidades.UnidadDeMedida) = New List(Of Entidades.UnidadDeMedida)
         lista.Add(um1) '# Siempre el primer item va a ser la UM Principal
         If um2 IsNot Nothing Then lista.Add(um2)
         .DataSource = lista
         .SelectedIndex = 0
      End With
   End Sub

   Private Function ObtenerPreciosConSinImpuestos(precio As Decimal, producto As Entidades.Producto, conImpuestos As Boolean) As Decimal
      If conImpuestos Then
         Return Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precio, producto)
      Else
         Return Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precio, producto)
      End If

   End Function

   Private Sub SetearColorSemaforos(textBox As Eniac.Controles.TextBox, IdTipoSemaforo As Entidades.SemaforoVentaUtilidad.TiposSemaforos)

      '# valor va a tomar el decimal que se encuentre en la caja de texto recibida por parámetro
      '# La misma que va a ser utilizada para pintar el color del semáforo
      '# RENTABILIDAD / SALDOS
      If Not String.IsNullOrEmpty(textBox.Text) Then
         Dim valor As Decimal = CDec(textBox.Text)
         Dim eSemaforoVentaUtilidad As Entidades.SemaforoVentaUtilidad

         eSemaforoVentaUtilidad = New Reglas.SemaforoVentasUtilidades().ColorSemaforo(valor, IdTipoSemaforo)
         If eSemaforoVentaUtilidad IsNot Nothing Then
            With eSemaforoVentaUtilidad
               textBox.BackColor = System.Drawing.Color.FromArgb(.ColorSemaforo)
               textBox.ForeColor = System.Drawing.Color.FromArgb(.ColorLetra)
               If .Negrita Then
                  textBox.Font = New Font(textBox.Font, FontStyle.Bold)
               Else
                  textBox.Font = New Font(textBox.Font, FontStyle.Regular)
               End If
            End With
         End If
      End If
   End Sub

   Public Sub ModificarPedido(pedido As Eniac.Entidades.Pedido, esCopia As Boolean, owner As System.Windows.Forms.IWin32Window, dt As DataTable)
      _esCopia = esCopia
      If pedido Is Nothing Then
         Throw New Exception(Traducciones.TraducirTexto("Debe pasar un pedido a modificar.", Me, "__PedidoNoSuministrado"))
      End If

      If Not _esCopia Then
         Dim regPedidos As Reglas.Pedidos = New Reglas.Pedidos()
         regPedidos.VerificaPedidoModificable(pedido)
      Else
         pedido.Fecha = Today
         For Each pp As Entidades.PedidoProducto In pedido.PedidosProductos
            pp.FechaEntrega = Today
            pp.CantNoPendienteOriginal = 0
            pp.CantPendiente = pp.Cantidad
            pp.PedidosEstados.Clear()
         Next
      End If            'If Not _esCopia Then

      PedidoAEditar = pedido
      _dtPedidoSinStock = dt
      ShowDialog(owner)
   End Sub

   Private Function MostrarMasInfo() As DialogResult

      Try
         Dim clie As Entidades.Cliente = Nothing
         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
            clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), incluirFoto:=True)
         End If
         Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
         If result = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoCliente.Text = clie.CodigoCliente.ToString()
            Me.bscCodigoCliente.PresionarBoton()
         End If
         Return result
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      Return Nothing
   End Function

   Private Sub CalcularDescuentosProductos()

      'Dim DescRec1 As Decimal
      'Dim DescRec2 As Decimal
      'Dim DescRecT As Decimal

      'Dim precio As Decimal = Decimal.Parse(Me.txtPrecio.Text) - Decimal.Parse(txtImpuestosInternos.Text)

      'DescRec1 = precio * Decimal.Parse(Me.txtDescRecPorc1.Text) / 100

      'DescRec2 = (precio + DescRec1) * Decimal.Parse(Me.txtDescRecPorc2.Text) / 100

      'DescRecT = Decimal.Round((DescRec1 + DescRec2) * Decimal.Parse(Me.txtCantidad.Text), Me._decimalesRedondeoEnPrecio)

      Me.txtDescRec.Text = CalculaDescuentosProductos(Decimal.Parse(Me.txtPrecio.Text),
                                                      Decimal.Parse(Me.txtImpuestoInterno.Text),
                                                      Decimal.Parse(Me.txtDescRecPorc1.Text),
                                                      Decimal.Parse(Me.txtDescRecPorc2.Text),
                                                      Decimal.Parse(Me.txtCantidad.Text)).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      'Me.txtDescRec.Text = DescRecT.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))

   End Sub

   Private Function CalculaDescuentosProductos(precioProducto As Decimal, impInt As Decimal, descRecPorc1 As Decimal, descRecPorc2 As Decimal, cantidad As Decimal) As Decimal

      Dim precioParaDescuento As Decimal = precioProducto
      'Se anula esta lógica porque no se permite más facturación con ImpInt fijos.
      'If Not cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
      '   If DirectCast(Me.cmbTiposComprobantesFact.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
      '      DirectCast(Me.cmbTiposComprobantesFact.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
      '      Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
      '      precioParaDescuento = precioProducto - impInt
      '   Else
      '      precioParaDescuento = precioProducto
      '   End If
      'Else
      '   precioParaDescuento = precioProducto
      'End If

      Dim descRec1 = precioParaDescuento * descRecPorc1 / 100

      Dim descRec2 = (precioParaDescuento + descRec1) * descRecPorc2 / 100

      Dim descRecT = Decimal.Round((descRec1 + descRec2) * cantidad, Me._decimalesRedondeoEnPrecio)

      Return descRecT
   End Function

   'Private Function ValidarLimiteCredito(arrojarException As Boolean) As Boolean?
   '   If Decimal.Parse(Me.txtSaldoCtaCte.Text) + Decimal.Parse(Me.txtTotalGeneral.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
   '      Select Case Publicos.ControlaEventosdeLimiteDeCreditoDeClientes
   '         Case "No Permitir"
   '            If Not arrojarException Then
   '               ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
   '               Return False
   '            Else
   '               Throw New Exception("ATENCION: El Cliente Superó la cantidad de dias de límite de Crédito. El Comprobante fué Cancelado por Falta de Crédito.")
   '            End If
   '         Case "Avisar y Permitir"
   '            If ShowPregunta("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?") <> Windows.Forms.DialogResult.Yes Then
   '               If Not arrojarException Then
   '                  ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
   '                  Return False
   '               Else
   '                  Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
   '               End If
   '            End If
   '      End Select
   '   End If
   'End Function

   Private Function ValidarComprobante() As Boolean

      Dim sistema As Entidades.Sistema = Publicos.GetSistema()

      If DateDiff(DateInterval.Day, Me.dtpFecha.Value, sistema.FechaVencimiento) < 0 Then
         MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.dtpFecha.Focus()
         Return False
      End If

      'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
      '    Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
      '    Dim dt As DataTable = oPF.Get1(Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
      '    If dt.Rows.Count = 0 Then
      '        MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '        Me.dtpFecha.Focus()
      '        Return False
      '    ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
      '        MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '        Me.dtpFecha.Focus()
      '        Return False
      '    End If
      'End If


      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Código del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If Me.bscCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCliente.Focus()
         Return False
      End If

      If Me._pedidosProductos.Count = 0 Then
         MessageBox.Show("No se cargó ningún producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.tbcDetalle.SelectedTab = Me.tbpProductos
         Me.bscCodigoProducto2.Focus()
         Return False
      End If

      If txtOrdenDeCompra.ValorNumericoPorDefecto(0L) <> 0 Then
         If Reglas.Publicos.UtilizaOrdenCompraPedidos Then
            Using dtOC = New Reglas.OrdenesCompra().Get1(actual.Sucursal.IdSucursal, txtOrdenDeCompra.ValorNumericoPorDefecto(0L))
               If dtOC.Any() Then
                  ShowMessage("No existe la Orden de Compra.")
                  txtOrdenDeCompra.Focus()
                  Return False
               End If
            End Using
         End If
      End If

      Dim estadoSeleccionado As Entidades.EstadoPedido
      Dim cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

      estadoSeleccionado = cache.BuscaEstadosPedido(Entidades.EstadoPedido.ESTADO_ALTA, "PEDIDOSCLIE")

      If estadoSeleccionado.ReservaStock And estadoSeleccionado.IdDeposito = 0 Then
         ShowMessage(String.Format("El estado {0}, reserva stock. Debe seleccionar Deposito y Ubicacion Por Defecto.", Entidades.EstadoPedido.ESTADO_ALTA))
         Return False
      End If

      If Me._clienteE.EsClienteGenerico Then
         If Me.txtNombreClienteGenerico.Text = "" Then
            MessageBox.Show("Debe cargar Nombre de Cliente Eventual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNombreClienteGenerico.Focus()
            Return False
         End If
         If Me.txtDireccionClienteGenerico.Text = "" Then
            MessageBox.Show("Debe cargar Direccion de Cliente Eventual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDireccionClienteGenerico.Focus()
            Return False
         End If
         If Me.bscCodigoLocalidad.Text.Trim().Length = 0 Then
            MessageBox.Show("Debe cargar la Localidad de Cliente Eventual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoLocalidad.Focus()
            Return False
         End If
      End If


      'If Not Publicos.VentasConProductosEnCero And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
      '    'verifico que ningun producto tenga precio cero
      '    For Each pro As Entidades.VentaProducto In Me._ventasProductos
      '        If pro.ImporteTotal = 0 Then
      '            MessageBox.Show("No puede haber productos con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '            Me.tbcDetalle.SelectedTab = Me.tbpProductos
      '            Me.bscCodigoProducto2.Focus()
      '            Return False
      '        End If
      '    Next
      'End If

      '*** Controlo la Facturacion Sin Stock ***

      'PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), ó invoco (no corresponde)
      'los valores posibles para el coeficientestock son 0, 1 y -1

      Dim blnControlarStock As Boolean = False

      'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0 Then

      '    'Si NO facturo otros (ej: Factura sin Facturables).

      '    If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 OrElse Me._comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = 0 Then
      '        'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).

      '        blnControlarStock = True

      '    End If

      'End If

      Dim cantidadTotal As Decimal = 0
      Dim ProductosCadena As String = ""
      Dim producto As String
      Dim ProdRepetido As DataTable = New DataTable()
      ProdRepetido.Columns.Add("ProdRepetido", System.Type.GetType("System.String"))
      ProdRepetido.Columns.Add("NombreProducto", System.Type.GetType("System.String"))
      Dim dr2 As DataRow
      Dim entro As Boolean = False

      Dim fechaEntrega As DateTime? = Nothing
      Dim PorcDescTotal As Decimal = 0
      Dim PrecioLista As Decimal = 0


      For Each pro As Entidades.PedidoProducto In Me._pedidosProductos

         If Not Reglas.Publicos.PedidosPermiteFechaEntregaDistintas Then
            'GAR: 13/01/2017
            'Todo la fecha de pedido Cabecera.

            'If Not fechaEntrega.HasValue Then fechaEntrega = pro.FechaEntrega
            'If Not fechaEntrega.Value.Date.Equals(pro.FechaEntrega.Date) Then
            '   'SPC: Ver como permitimos esto.
            '   'TODO: Ver como permitimos esto.
            '   MessageBox.Show("La Fecha de Entrega de los Diferentes Productos No Puede ser Distinta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '   Return False
            'End If

            If Not fechaEntrega.HasValue Then fechaEntrega = Me.dtpFechaEntrega.Value
            pro.FechaEntrega = Me.dtpFechaEntrega.Value
            '------------------------------
         End If


         If Not pro.Producto.PermiteModificarDescripcion Then

            'Si la Empresa o el Cliente es MO/CF el precio tiene IVA, pero el Precio de IVA esta sin IVA, se lo tengo que poner!
            If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
               PrecioLista = Decimal.Round((pro.PrecioLista * (1 + (pro.AlicuotaImpuesto / 100))) + pro.ImporteImpuestoInterno, Me._decimalesRedondeoEnPrecio)
            Else
               PrecioLista = pro.PrecioLista
            End If

            'Calculo el precio Neto contra el de Lista porque ademas pudo cambiar el precio (para arriba o abajo).
            If PrecioLista > 0 Then
               PorcDescTotal = Decimal.Round((pro.PrecioNeto / PrecioLista - 1) * 100, Me._decimalesRedondeoEnPrecio)
            Else
               PorcDescTotal = 0
            End If

            'Rechazo Si tiene configurado el precio neto, y realizo descuento (en el global) y el descuento es mayor al maximo...
            If Reglas.Publicos.Facturacion.DescuentoMaximo > 0 And PorcDescTotal < 0 And Math.Abs(PorcDescTotal) > Reglas.Publicos.Facturacion.DescuentoMaximo Then
               MessageBox.Show("ATENCION: Asignó un Descuento de " & Math.Abs(PorcDescTotal).ToString("N2") & "% y el Máximo es : " & Reglas.Publicos.Facturacion.DescuentoMaximo.ToString("N2") + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return False
            End If

         End If

         If DateDiff(DateInterval.Day, Me.dtpFecha.Value.Date, pro.FechaEntrega.Date) < 0 Then
            ShowMessage(String.Format(Traducciones.TraducirTexto("La Fecha de Entrega del producto (Código {0}) es menor a la Fecha del Pedido ({1:dd/MM/yyyy}).", Me, "__ErrorFechaEntregaInvalida"),
                                      pro.IdProducto, dtpFecha.Value))
            Me.dtpFecha.Focus()
            Return False
         End If

         producto = pro.IdProducto
         'Sumo cantidades en productos repetidos para controlar stock
         For Each pro1 As Entidades.PedidoProducto In Me._pedidosProductos

            If pro1.IdProducto = producto Then
               cantidadTotal = cantidadTotal + pro1.Cantidad
            End If
         Next
         'Controlo la cantidad total con el stock del producto
         If cantidadTotal > pro.Stock And blnControlarStock Then
            'chequeo que ya no se haya controlado
            For Each rep As DataRow In ProdRepetido.Rows
               If pro.IdProducto = rep("ProdRepetido").ToString() Then
                  entro = True
               End If
            Next
            If entro = True Then
            Else
               dr2 = ProdRepetido.NewRow()
               dr2("ProdRepetido") = pro.IdProducto
               dr2("NombreProducto") = pro.NombreProducto
               ProdRepetido.Rows.Add(dr2)
            End If

         End If
         entro = False
         cantidadTotal = 0
      Next

      For Each dr As DataRow In ProdRepetido.Rows
         ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      Next

      If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" And ProductosCadena <> "" Then
         MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock. " + ProductosCadena, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False

      ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" And ProductosCadena <> "" Then

         MessageBox.Show("Va a Facturar el Producto " + ProductosCadena + " aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

      End If


      'If Decimal.Parse(Me.txtTotalGeneral.Text) = 0 Then
      '    MessageBox.Show("No se calcularon los totales de la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '    If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
      '        Me.tbcDetalle.SelectedTab = Me.tbpProductos
      '        Me.bscCodigoProducto2.Focus()
      '    Else
      '        Me.tbcDetalle.SelectedTab = Me.tbpRemitoTransp
      '        Me.txtValorDeclarado.Focus()
      '    End If
      '    Return False
      'End If

      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If Not Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorPorClave Then

         If Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar el vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbVendedor.Focus()
            Return False
         End If
      Else
         Using frm As New FacturacionSolicitarVendedorPorClave()
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
               _vendedorPorClave = frm.Vendedor
            Else
               MessageBox.Show("Falta cargar el vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return False
            End If
         End Using
      End If

      If Me.cmbEstadoVisita.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el estado de visita.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbEstadoVisita.Focus()
         Return False
      End If

      'If Reglas.Publicos.TieneModuloLogistica Then
      If cmbFormaPago.SelectedIndex = -1 Then
         ShowMessage("Falta cargar la forma de pago.")
         cmbFormaPago.Focus()
         cmbFormaPago.DroppedDown = True
         Return False
      End If
      If Reglas.Publicos.PedidosSolicitaTransportista Then
         If cmbRespDistribucion.SelectedIndex = -1 Then
            ShowMessage("Falta cargar el responsable de distribución.")
            cmbRespDistribucion.Focus()
            cmbRespDistribucion.DroppedDown = True
            Return False
         End If
      End If
      If Reglas.Publicos.PedidosSolicitaComprobanteGenerar Then
         If cmbTiposComprobantesFact.SelectedIndex = -1 Then
            ShowMessage("Falta cargar el comprobante a generar.")
            cmbTiposComprobantesFact.Focus()
            cmbTiposComprobantesFact.DroppedDown = True
            Return False
         End If
      End If
      'End If

      If Not Me.chbNumeroAutomatico.Checked And Long.Parse(Me.txtNumeroPosible.Text) <= 0 Then
         MessageBox.Show("El número de comprobante digitado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtNumeroPosible.Focus()
         Return False
      End If


      If Decimal.Parse(txtLimiteDeCredito.Text) > 0 AndAlso cmbFormaPago.SelectedIndex > -1 AndAlso
         DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 AndAlso cmbTiposComprobantes.SelectedIndex > -1 AndAlso
         DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Tipo = "PEDIDOSCLIE" Then

         Dim valido As Boolean? = ValidarLimiteCredito(arrojarException:=False)

         If valido.HasValue Then Return valido.Value

      End If

      Dim ImporteTope As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteTope
      If ImporteTope > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) > ImporteTope Then
         MessageBox.Show("El Comprobante Superó el Límite Permitido de $ " & ImporteTope.ToString("N" + Me._decimalesEnTotales.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      Dim ImporteMinimo As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteMinimo
      If ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) < ImporteMinimo Then
         MessageBox.Show("El Comprobante No Alcanzó el Mínimo Requerido de $ " & ImporteMinimo.ToString("N." + Me._decimalesEnTotales.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      'A Raymundo cada tanto le pasa que no genera el descuento, no dan enter!
      If Decimal.Parse(Me.txtDescRecGralPorc.Text) <> 0 And Decimal.Parse(Me.txtDescRecGral.Text) = 0 Then
         MessageBox.Show("No se calculó el Descuento/Recargo General, por favor de enter para confirmarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtDescRecGralPorc.Focus()
         Return False
      End If

      Dim CategoriaFiscalCliente As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      Dim CUIT As String = String.Empty

      If Me._clienteE.EsClienteGenerico Then
         CategoriaFiscalCliente = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
         Dim result As Reglas.Validaciones.ValidacionResult
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                   With {.IdFiscal = txtCUIT.Text,
                                                                                         .SolicitaCUIT = CategoriaFiscalCliente.SolicitaCUIT})
         If result.Error Then
            txtCUIT.Focus()
            MessageBox.Show(result.MensajeError.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         Else
            CUIT = txtCUIT.Text.ToString()
         End If
      Else
         CategoriaFiscalCliente = Me._clienteE.CategoriaFiscal
         CUIT = Me._clienteE.Cuit
      End If

      If CategoriaFiscalCliente.SolicitaCUIT And String.IsNullOrEmpty(CUIT.ToString()) And
                          (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                           DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico) Then

         MessageBox.Show("ATENCION: El Cliente NO tiene CUIT y es obligatorio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         If Not Me._clienteE.EsClienteGenerico Then
            If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
               Return False
            End If
         Else
            Me.txtCUIT.Focus()
            Return False
         End If


      End If

      '#####################################
      '# COPIADO TAL CUAL DE FACTURACIONV2 #
      '#####################################

      'Si es Consumidor Final, vendio a partir de $1000 y no tiene DNI
      If Not CategoriaFiscalCliente.IvaDiscriminado And Not CategoriaFiscalCliente.SolicitaCUIT And CategoriaFiscalCliente.LetraFiscal <> "E" And
         Decimal.Parse(Me.txtTotalGeneral.Text.ToString()) >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF And Me._clienteE.NroDocCliente = 0 And
         DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ControlaTopeConsumidorFinal Then

         'Si tiene el parametro Activo de DNI controla a Todos (Blanco, Negro, Remito, Presupuestos, etc, sino, solo lo Blanco/Electronico.
         If Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal Or
            (Not Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal And
             (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
              DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico)) Then
            If CUIT <> "" Then
               'Tiene CUIT
               If ShowPregunta(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio, pero tiene CUIT desea utilizarlo?", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF)) = Windows.Forms.DialogResult.Yes Then
                  Me.txtCUIT.Text = CUIT
                  Me.lblCUIT.Text = My.Resources.RTextos.Cuit
               Else

                  If Not Me._clienteE.EsClienteGenerico Then
                     If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
                        Return False
                     End If
                     Me.lblCUIT.Text = "Nro.Documento"

                  Else
                     Return False
                     Me.txtNroDocCliente.Focus()
                  End If
               End If

            Else

               If Not Me._clienteE.EsClienteGenerico Then

                  ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))

                  If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
                     Return False
                  End If

               Else
                  If txtNroDocCliente.Text = "" Then
                     ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
                     Me.txtNroDocCliente.Focus()
                     Return False

                  End If
               End If

            End If


         End If
      End If

      Return True

   End Function

   'Private Function EsComprobanteFiscal() As Boolean
   '    Return DirectCast("PEDIDO", Entidades.TipoComprobante).EsFiscal
   'End Function

   Private Sub GrabarComprobante()

      If ValidarComprobante() Then

         tsbGrabar.Enabled = False


         Dim oPedido = New Reglas.Pedidos(IdFuncion)
         Dim oPedidos = New Entidades.Pedido()

         With oPedidos
            'cargo el comprobante
            .TipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)()

            'cargo el cliente ----------
            .Cliente = Me._clienteE
            .Cliente.NombreCliente = Me.bscCliente.Text


            Dim idDireccionSeleccionada = cmbDirecciones.ValorSeleccionado(Of Integer)
            Using dtDirecciones = New Reglas.ClientesDirecciones().GetDirecciones(.Cliente.IdCliente)
               Dim drDireccion = dtDirecciones.AsEnumerable().FirstOrDefault(Function(dr) dr.Field(Of Integer)("IdDireccion") = idDireccionSeleccionada)
               If drDireccion Is Nothing Then
                  Throw New Exception("La direccion seleccionada ya no pertenece al cliente")
               End If
               .IdDomicilio = idDireccionSeleccionada.NullIf(-1) Or idDireccionSeleccionada.NullIf(0)
               .Direccion = drDireccion.Field(Of String)("Direccion")
               .IdLocalidad = drDireccion.Field(Of Integer?)("IdLocalidad").IfNull()
            End Using

            If Me._clienteE.EsClienteGenerico Then
               .NombreClienteGenerico = Me.txtNombreClienteGenerico.Text
               .Direccion = Me.txtDireccionClienteGenerico.Text
               .IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text.ToString())
            End If

            If (bscCodigoClienteVinculado.Selecciono Or bscClienteVinculado.Selecciono) AndAlso IsNumeric(bscCodigoClienteVinculado.Tag) Then
               .ClienteVinculado = New Reglas.Clientes().GetUno(Long.Parse(bscCodigoClienteVinculado.Tag.ToString()))
            End If

            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal)()

            .LetraComprobante = Me.txtLetra.Text

            If Not Me.chbNumeroAutomatico.Checked Or (.TipoComprobante.EsFiscal And Not .TipoComprobante.GrabaLibro) Or PedidoAEditar IsNot Nothing Then
               .NumeroPedido = Long.Parse(Me.txtNumeroPosible.Text)
            End If

            'cargo datos generales del comprobante
            If PedidoAEditar IsNot Nothing Then
               .IdSucursal = PedidoAEditar.IdSucursal
            Else
               .IdSucursal = actual.Sucursal.Id
            End If

            If .CategoriaFiscal.SolicitaCUIT Then
               .Cuit = Me.txtCUIT.Text
            ElseIf Not String.IsNullOrEmpty(Me.txtNroDocCliente.Text.ToString) Then
               .TipoDocCliente = Me.cmbTipoDoc.Text
               .NroDocCliente = Long.Parse(Me.txtNroDocCliente.Text.ToString())
            End If

            .Usuario = actual.Nombre

            'Pudo levantar la pantalla y grabar despues. Vuelvo a asignarlo para que tome la hora.
            If Me.dtpFecha.Value.Date = New Reglas.Generales().GetServerDBFechaHora.Date Then
               Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora
            End If
            .Fecha = Me.dtpFecha.Value

            If Not Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorPorClave Then
               If Me.cmbVendedor.SelectedIndex <> -1 Then
                  .Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
               End If
            Else
               .Vendedor = _vendedorPorClave
            End If

            If Me.cmbCajaPedido.SelectedIndex <> -1 Then
               Dim rCaja As New Reglas.CajasNombres
               .Caja = rCaja.GetUna(actual.Sucursal.IdSucursal, CInt(cmbCajaPedido.SelectedValue.ToString()))
            End If

            .Observacion = Me.txtObservacion.Text

            .FechaActualizacion = _fechaActualizacionBD.IfNull()
            .IdUsuarioActualizacion = _idUsuarioActualizacionBD

            .EstadoVisita = DirectCast(Me.cmbEstadoVisita.SelectedItem, Entidades.EstadoVisita)

            '.VentasImpuestos = Me._subTotales
            '.ImpuestosVarios = Me._fc.ImpuestosVarios
            .IdPlazoEntrega = Integer.Parse(cmbPlazosEntrega.SelectedValue.ToString())

            ''cargo valores del comprobante
            .ImporteBruto = Decimal.Parse(Me.txtTotalBruto.Text)
            .DescuentoRecargo = Decimal.Parse(Me.txtDescRecGral.Text)
            .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescRecGralPorc.Text)
            .SubTotal = Decimal.Parse(Me.txtTotalNeto.Text)
            .TotalImpuestos = Decimal.Parse(Me.txtTotalImpuestos.Text) '+ Decimal.Parse(Me.txtTotalPercepcion.Text)
            .TotalImpuestoInterno = Decimal.Parse(Me.txtTotalImpuestosInternos.Text)
            .ImporteTotal = Decimal.Parse(Me.txtTotalGeneral.Text)

            .CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text)
            .IdMoneda = Integer.Parse(cmbMonedaVenta.SelectedValue.ToString())
            .Kilos = Decimal.Parse(Me.txtKilos.Text)

            'cargo la impresora
            '.Impresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal())
            .Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

            If Me.txtOrdenDeCompra.Text <> "" Then
               .NumeroOrdenCompra = Long.Parse(Me.txtOrdenDeCompra.Text.ToString())
            End If

            'cargo los productos
            .PedidosProductos = Me._pedidosProductos

            'MD-PROD: Verificar la carga de las formulas
            .PedidosProductos.ForEach(
               Sub(pp)
                  If _pedidosProductosFormulas.ContainsKey(pp) AndAlso _pedidosProductosFormulas(pp) IsNot Nothing Then
                     pp.PedidosProductosFormulas = _pedidosProductosFormulas(pp).ConvertToPedidosProductosFormula()
                  End If
               End Sub)

            ''Dim rPPF As Reglas.PedidosProductosFormulas = New Reglas.PedidosProductosFormulas()
            ''For Each pp As Entidades.PedidoProducto In _pedidosProductos
            ''   If _pedidosProductosFormulas.ContainsKey(pp) AndAlso _pedidosProductosFormulas(pp) IsNot Nothing Then
            ''      pp.PedidosProductosFormulas = rPPF.CargaLista(_pedidosProductosFormulas(pp))
            ''   End If
            ''Next


            ''Cargo los Comprobantes Facturados (tal vez ninguno)
            '.Facturables = Me._comprobantesSeleccionados

            'Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !
            'If Me._comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 AndAlso .TipoComprobante.CoeficienteStock <> 0 Then
            '   .IdEstadoComprobante = "INVOCO"
            '   .CantidadInvocados = Me._comprobantesSeleccionados.Count
            'Else
            '   .CantidadInvocados = 0
            'End If

            'cargo el Remito Transportista
            '.Bultos = Integer.Parse("0" & Me.txtBultos.Text)
            '.ValorDeclarado = Decimal.Parse("0" & Me.txtValorDeclarado.Text)
            .Transportista = Nothing
            .FormaPago = Nothing
            .TipoComprobanteFact = Nothing
            'If Reglas.Publicos.TieneModuloLogistica Then
            If Reglas.Publicos.PedidosSolicitaTransportista Then
               If cmbRespDistribucion.SelectedIndex >= 0 Then
                  .Transportista = DirectCast(cmbRespDistribucion.SelectedItem, Entidades.Transportista)
               End If
            End If
            If cmbFormaPago.SelectedIndex >= -1 Then
               .FormaPago = DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago)
            End If
            If Reglas.Publicos.PedidosSolicitaComprobanteGenerar Then
               If cmbTiposComprobantesFact.SelectedIndex >= -1 Then
                  .TipoComprobanteFact = DirectCast(cmbTiposComprobantesFact.SelectedItem, Entidades.TipoComprobante)
               End If
            End If
            'End If
            '.NumeroLote = Long.Parse("0" & Me.txtNumeroLote.Text)

            'cargo las Observaciones
            .PedidosObservaciones = Me._pedidosObservaciones

            'If oVentas.TipoComprobante.AfectaCaja Then
            '    'controlo el pago que se realiza si no va a la cuenta corriente
            '    If oVentas.FormaPago.Dias = 0 Then
            '        If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
            '            If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
            '                If Not Publicos.FacturacionContadoEsEnPesos AndAlso MessageBox.Show("El pago se realizara totalmente en pesos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            '                    Me.tbpPagos.Focus()
            '                    Me.txtEfectivo.Focus()
            '                    Exit Sub
            '                Else
            '                    Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
            '                End If
            '            End If
            '        Else
            '            'si puso algo en pagos, se debe controlar que la diferencia este en cero
            '            If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
            '                Me.tbpPagos.Focus()
            '                Me.txtEfectivo.Focus()
            '                Throw New Exception("El pago debe ser igual al total del comprobante.")
            '            End If
            '        End If
            '    End If
            'Else
            '    Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
            'End If

            'carga los importes de pagos y cheques
            '.Cheques = Me._cheques
            '.Tarjetas = Me._tarjetas
            ' .ImportePesos = Decimal.Parse(Me.txtEfectivo.Text)
            '.ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text)
            ' .ImporteTickets = Decimal.Parse(Me.txtTickets.Text)

            'carga los cheques rechazados
            '.ChequesRechazados = Me._chequesRechazados

            'Informe los Productos que tuvieron Lotes.
            '.CantidadLotes = 0   'Me.ProductosConLote()    ---- Luego le cargo el correcto segun la seleccion de lotes.

            'cargo los Lotes
            '.VentasProductosLotes = Me._productosLotes

            'Cargo la utilidad
            .Utilidad = Decimal.Parse(Me.txtSemaforoRentabilidad.Key)
            .SaldoActualCtaCte = Decimal.Parse(Me.txtSaldoCtaCte.Text.ToString())
            '.ComisionVendedor = 0  'Se calcula despues

            For Each pp As Entidades.PedidoProducto In .PedidosProductos
               If Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                  pp.Costo = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(pp.Costo, pp.AlicuotaImpuesto,
                                                                                                pp.PorcImpuestoInterno, pp.Producto.ImporteImpuestoInterno,
                                                                                                pp.OrigenPorcImpInt),
                                           Me._decimalesRedondeoEnPrecio)
                  ' (pp.ImporteImpuestoInterno / pp.Cantidad),
               End If
            Next

            'grabo la caja
            ' .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
            .PedidosContactos.Clear()
            For Each contacto As Entidades.ClienteContacto In _pedidosContactos
               .PedidosContactos.Add(New Entidades.PedidoClienteContacto(contacto))
            Next
         End With

         oPedidos.ValidezPresupuesto = Reglas.Publicos.DiasValidezPresupuesto

         If PedidoAEditar Is Nothing OrElse _esCopia Then
            '' ''Using stm = New IO.StreamWriter("d:\Temp\_\pedido.xml")
            '' ''   Dim a = New System.Xml.Serialization.XmlSerializer(oPedidos.GetType())
            '' ''   a.Serialize(stm, oPedidos)
            '' ''End Using
            ' '' ''IO.File.WriteAllText("d:\Temp\_\pedido.json", New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(oPedidos))

            oPedido.Insertar(oPedidos)
         Else
            oPedidos.CentroEmisor = PedidoAEditar.CentroEmisor
            oPedidos.Palets = PedidoAEditar.Palets
            oPedido.Actualizar(oPedidos)
         End If


         'verifica si el tipo de comprobante se puede imprimir, sino no hace nada
         Try
            'Luego cambiar al otro parametro.
            If Me.ImprimeComprobante() Then
               If Publicos.PedidosVisualiza Then
                  Me.ImprimirPedido(oPedidos, Publicos.PedidosVisualiza)
                  MessageBox.Show("Grabación e Impresión Exitosa!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Else
                  Me.ImprimirPedido(oPedidos, False)
                  MessageBox.Show("Grabación e Impresión Exitosa!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            Else
               MessageBox.Show("Grabación Exitosa!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         Catch ex As Exception
            'si da error en la impresión solo muestra el mensaje y sigue para borrar la pantalla.
            'sino no borraba la pantalla y era como que no se grababa la factura, mientras que si se graba
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try

         If PedidoAEditar Is Nothing Then
            Me.Nuevo()
         Else
            Close()
         End If

      End If

   End Sub

   Private Sub ImprimirPedido(oPedido As Entidades.Pedido, Visualizar As Boolean)
      Dim impresion As ImpresionPedidos = New ImpresionPedidos()
      impresion.ImprimirPedido(oPedido, Visualizar)
   End Sub


   Private Function ImprimeComprobante() As Boolean
      Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime
   End Function

   Private Sub SeteaDetalles()
      Me._pedidosProductos = New List(Of Entidades.PedidoProducto)
      _pedidosContactos = New List(Of Entidades.ClienteContacto)()
      Me._subTotales = New List(Of Entidades.VentaImpuesto)()
      Me._pedidosObservaciones = New List(Of Entidades.PedidoObservacion)()
      Me._cheques = New List(Of Entidades.Cheque)()
      Me._tarjetas = New List(Of Entidades.VentaTarjeta)()
      Me._chequesRechazados = New List(Of Entidades.Cheque)()
      Me._productosLotes = New List(Of Entidades.VentaProductoLote)()

   End Sub

   Private Sub CalcularTotalProducto()
      If Me.txtCantidad.Text = "-" Then
         Me.txtCantidad.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      End If
      If Me.txtDescRec.Text = "" Or Me.txtDescRec.Text = "-" Then
         Me.txtDescRec.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      End If
      Me.txtTotalProducto.Text = ((Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtCantidad.Text)) + Decimal.Parse(Me.txtDescRec.Text)).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto))
   End Sub

   Private _ordenProducto As Integer
   Private Sub LimpiarCamposProductos()
      Dim precioCero = (0).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
      Dim cantidadCero = (0).ToString("N" + _decimalesMostrarEnCantidad.ToString())
      Dim cantidadCeroAnchoLargo = (0).ToString(_formatoAnchoLargo)

      _ordenProducto = 0
      _cantidadOriginal = 0
      _cantidadNoPendienteOriginal = 0

      _editarProductosDesdeGrilla = False
      bscCodigoProducto2.Enabled = True
      bscCodigoProducto2.Text = ""
      bscCodigoProducto2.FilaDevuelta = Nothing
      bscProducto2.Enabled = True
      bscProducto2.Text = ""
      bscProducto2.FilaDevuelta = Nothing
      cmbTipoOperacion.Enabled = True
      txtPrecio.Text = precioCero
      txtStock.Text = "0"
      txtStock.Tag = False
      txtCantidad.Text = cantidadCero
      txtCantidadManual.Text = cantidadCero

      If cmbUM2.Items.Count > 0 Then
         cmbUM2.DataSource = Nothing
         cmbUM2.Items.Clear()
      End If

      txtDescRec.Text = precioCero
      txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto)
      txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtTamanio.Text = "0." + New String("0"c, Me._decimalesMostrarEnTamanio)

      txtUM.Text = ""
      lblKilosModDesc.Visible = False
      txtKilosModDesc.Text = "0." + New String("0"c, Me._decimalesEnKilos)
      txtKilosModDesc.Visible = False
      cmbCriticidad.SelectedIndex = 0
      dtpFechaEntregaProd.Value = Date.Today
      txtProductoObservacion.Text = String.Empty
      txtProductoObservacion.Visible = False
      dtpFechaActPrecios.Value = Date.Today

      txtCosto.Text = precioCero
      txtProductoEspPulgadas.Text = String.Empty
      txtProductoEspmm.Text = cantidadCero
      txtProductoSAE.Text = String.Empty
      cmbProductoProduccionForma.SelectedIndex = -1
      cmbProductoProduccionProceso.SelectedIndex = -1
      txtProductoLargoExtAlto.Text = cantidadCeroAnchoLargo
      txtProductoAnchoIntBase.Text = cantidadCeroAnchoLargo
      txtProductoArchitrave.Text = cantidadCeroAnchoLargo
      cmbProductoProduccionForma.SelectedIndex = -1

      'NO LO RESETEAMOS DE UNA LINEA A LA OTRA PARA AGILIZAR LA CARGA POR SOLICITUD DEL USUARIO
      'txtPrecioVentaPorTamano.Text = precioCero
      cmbMoneda.SelectedIndex = -1
      txtSemaforoRentabilidadDetalle.Text = precioCero
      txtProductoUrlPlano.Text = String.Empty
      cmbFormula.SelectedIndex = -1
      cmbProcesoProductivo.SelectedIndex = -1
      cmbTipoOperacion.SelectedItem = Entidades.Producto.TiposOperaciones.NORMAL
      cmbNota.Text = String.Empty

      MuestraImpuestosInternos(0, 0)

      _modificoDescuentosProducto = False
      _txtCantidad_prev = Nothing


      If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
         Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
         For Each vpo As Entidades.PedidoProducto In _pedidosProductos
            _txtCantidad_prev = Nothing
            Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

            For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
               If vp.Producto.IdRubro = vpo.Producto.IdRubro Then
                  cantidad += vp.Cantidad
               End If
            Next

            Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, vpo.Producto, cantidad, Me._decimalesEnTotales)

            For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
               If vp.Producto.IdRubro = vpo.Producto.IdRubro Then
                  vp.DescuentoRecargoPorc = _DescuentosRecargosProd.DescuentoRecargo1
                  If calculaDescuentoRecargo2 Then
                     vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
                  End If
               End If
               vp.DescuentoRecargoProducto = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                                        vp.DescuentoRecargoPorc, vp.DescuentoRecargoPorc2, vp.Cantidad)
            Next
         Next

         'RecalcularTodo()

      End If

      _pedidosProductosFormulasActual = Nothing

      SetearDescuentosPorCantidad(Nothing)
   End Sub

   Private Sub CalcularImpuestoInterno()
      Dim iidb As FacturacionV2.ImpIntDesdeBusquedas = FacturacionV2.GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)

      'Dim iidb.importeImpuestoInternoProducto As Decimal = 0
      'Dim iidb.porcImpuestoInterno As Decimal = 0
      'Dim iidb.OrigenPorcImpInt As Entidades.OrigenesPorcImpInt

      'With bscCodigoProducto2.FilaDevuelta
      '   iidb.importeImpuestoInternoProducto = Decimal.Parse(.Cells("ImporteImpuestoInterno").Value.ToString())
      '   iidb.porcImpuestoInterno = Decimal.Parse(.Cells("PorcImpuestoInterno").Value.ToString())
      'End With

      If iidb.PorcImpuestoInterno = 0 Then
         MuestraImpuestosInternos(iidb.ImporteImpuestoInterno, iidb.PorcImpuestoInterno)
      Else
         If Not IsNumeric(txtPrecio.Text) Then txtPrecio.Text = (0).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         Dim precioNeto As Decimal
         Dim descRecPorc1 As Decimal = Decimal.Parse(txtDescRecPorc1.Text)
         Dim descRecPorc2 As Decimal = Decimal.Parse(txtDescRecPorc2.Text)
         Dim descRecGralPorc As Decimal = Decimal.Parse(txtDescRecGralPorc.Text)

         Dim alicuotaIVA As Decimal = Decimal.Parse(cmbPorcentajeIva.Text)

         If (Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
            Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            precioNeto = Decimal.Parse(txtPrecio.Text)
         Else
            precioNeto = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(Decimal.Parse(txtPrecio.Text), alicuotaIVA,
                                                                              iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
         End If

         precioNeto = precioNeto * (1 + (descRecPorc1 / 100))
         precioNeto = precioNeto * (1 + (descRecPorc2 / 100))
         precioNeto = precioNeto * (1 + (descRecGralPorc / 100))

         Dim impuestoInterno As Decimal

         'If DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado Then
         If (Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
             Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            'El precio en pantalla está sin IVA
            impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA,
                                                                                                iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
         Else
            'El precio en pantalla está con IVA
            impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA,
                                                                                                iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
         End If

         MuestraImpuestosInternos(impuestoInterno, iidb.PorcImpuestoInterno)
      End If

   End Sub

   Private Function MuestraImpuestosInternos(importe As Decimal, porcentaje As Decimal) As Decimal
      txtImpuestoInterno.Text = importe.ToString("N4")
      txtImpuestoInterno.Visible = importe <> 0
      txtImpuestoInterno.LabelAsoc.Visible = txtImpuestoInterno.Visible

      txtPorcImpuestoInterno.Text = porcentaje.ToString("N4")
      txtPorcImpuestoInterno.Visible = porcentaje <> 0
      txtPorcImpuestoInterno.LabelAsoc.Visible = txtPorcImpuestoInterno.Visible

      Return importe
   End Function

   Private Sub CalcularTotales()

      Dim bruto As Decimal = 0
      Dim descuento As Decimal = 0
      Dim subTotal As Decimal = 0
      Dim iva As Decimal = 0
      Dim impInt As Decimal = 0
      Dim total As Decimal = 0
      Dim totalGeneral As Decimal = 0
      Dim Kilos As Decimal = 0
      Dim CantProductos As Integer
      Dim percepcionIVA As Decimal = 0
      Dim percepcionIB As Decimal = 0
      Dim percepcionGanancias As Decimal = 0
      Dim percepcionVarias As Decimal = 0
      Dim percepcionTotal As Decimal = 0

      'If Me.dgvProductos.Rows.Count > 0 Then

      Dim totalKilosItems As Reglas.Ventas.TotalKilosItems = New Reglas.Pedidos().CalculaTotalKilosItems(_pedidosProductos)
      Kilos = totalKilosItems.TotalKilos
      CantProductos = totalKilosItems.TotalProductos

      'For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
      '   Kilos += vp.Kilos
      'Next

      For Each vi As Entidades.VentaImpuesto In Me._subTotales
         bruto += vi.Bruto
         subTotal += vi.Neto
         If vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
            impInt += vi.Importe
         Else
            iva += vi.Importe
         End If
         total += vi.Total
      Next

      percepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
      percepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
      percepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
      percepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)

      percepcionTotal = percepcionIVA + percepcionIB + percepcionGanancias + percepcionVarias

      totalGeneral = total + percepcionTotal

      'End If

      Me.txtTotalPercepcion.Text = percepcionTotal.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalBruto.Text = bruto.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtDescRecGral.Text = (subTotal - bruto).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalNeto.Text = subTotal.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalSubtotales.Text = totalGeneral.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalImpuestos.Text = iva.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalImpuestosInternos.Text = impInt.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalGeneral.Text = totalGeneral.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))

      Dim cotizaDolar = Decimal.Parse(txtCotizacionDolar.Text)
      Me.txtTotalPercepcionDolar.Text = (percepcionTotal / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalBrutoDolar.Text = (bruto / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtDescRecGralDolar.Text = ((subTotal - bruto) / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalNetoDolar.Text = (subTotal / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalSubtotalesDolar.Text = (totalGeneral / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalImpuestosDolar.Text = (iva / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalImpuestosInternosDolar.Text = (impInt / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalGeneralDolar.Text = (totalGeneral / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))


      ' Me.CalcularDiferenciaDePago()

      Me.txtKilos.Text = Kilos.ToString("N" + _decimalesEnKilos.ToString())
      txtCantidadProductos.Text = CantProductos.ToString("N0")

      'TODO: 5329/2023
      Me._fc.CargarRetenciones(Nothing,
                     New Entidades.PercepcionVentaCalculo(),
                     Decimal.Parse(Me.txtPercepcionGanancias.Text),
                     Decimal.Parse(Me.txtPercepcionVarias.Text))

      If Me.dgvProductos.Rows.Count > 0 Then
         Me.cmbCategoriaFiscal.Enabled = False
         'ElseIf Me.cmbTiposComprobantes.SelectedItem IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then
         '    'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
         '    Me.cmbCategoriaFiscal.Enabled = Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro
      End If

      Me.lblItems.Text = Me.dgvProductos.Rows.Count.ToString() + " Items"

   End Sub

   Private Sub ComboCategoriaFiscalSelectedValue(idCategoriaFiscal As Short)

      Dim tipoComprobanteFact As Entidades.TipoComprobante = cmbTiposComprobantesFact.ItemSeleccionado(Of Entidades.TipoComprobante)()
      If tipoComprobanteFact Is Nothing Then
         tipoComprobanteFact = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)()
      End If

      If tipoComprobanteFact IsNot Nothing AndAlso
         Publicos.FacturacionGrabaLibroNoFuerzaConsFinal And
         Not tipoComprobanteFact.GrabaLibro And Not tipoComprobanteFact.EsPreElectronico Then
         idCategoriaFiscal = 1S
      End If
      cmbCategoriaFiscal.Enabled = True
      cmbCategoriaFiscal.SelectedValue = idCategoriaFiscal
      cmbCategoriaFiscal.Enabled = False
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         '# Agregue esta verificación del index ya que se estaba ingresando 3 veces método.
         '# Las dos primeras traía valores, pero la tercera vez no(index -1) y pinchaba.
         '# No llegué a entender por qué entra 3 veces.
         '# PE 26764.
         If dr.Index <> -1 Then

            Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
            Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
            Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
            txtObservacion2.Text = dr.Cells("Observacion").Value.ToString()

            With cmbDirecciones
               .DisplayMember = "DireccionAMostrar"
               .ValueMember = "IdDireccion"
               .DataSource = New Reglas.ClientesDirecciones().GetDirecciones(Long.Parse(dr.Cells("IdCliente").Value.ToString()))
               .SelectedIndex = 0
            End With

            cmbDirecciones.Enabled = True
            'Me.txtDireccionYLocalidad.Text = dr.Cells("Direccion").Value.ToString() & " - " & dr.Cells("NombreLocalidad").Value.ToString()

            '-- REQ-41759.- --------------------------------------------------------------------
            If PedidoAEditar IsNot Nothing Then
               Dim dtDom = DirectCast(cmbDirecciones.DataSource, DataTable)
               For Each drDom As DataRow In dtDom.Rows
                  If drDom("Direccion").ToString() = PedidoAEditar.Direccion.ToString() Then
                     cmbDirecciones.Text = drDom("DireccionAMostrar").ToString()
                  End If
               Next
            End If
            '-----------------------------------------------------------------------------------

            Me.txtTelefonos.Text = dr.Cells("Telefono").Value.ToString() & " " & dr.Cells("Celular").Value.ToString()
            Me.txtLimiteDeCredito.Text = dr.Cells("LimiteDeCredito").Value.ToString()


            If IsNumeric(dr.Cells("ColorEstadoCliente").Value) Then
               Dim colorEstado As Color = Color.FromArgb(Integer.Parse(dr.Cells("ColorEstadoCliente").Value.ToString()))
               bscCliente.PermitidoNoBackColor = colorEstado
               bscCodigoCliente.PermitidoNoBackColor = colorEstado

               bscCliente.PermitidoSiBackColor = colorEstado
               bscCodigoCliente.PermitidoSiBackColor = colorEstado
            Else
               bscCliente.ReseteaPermitidoNoBackColor()
               bscCodigoCliente.ReseteaPermitidoNoBackColor()
               bscCliente.ReseteaPermitidoSiBackColor()
               bscCodigoCliente.ReseteaPermitidoSiBackColor()
            End If

            'Me.cmbCategoriaFiscal.SelectedValue = dr.Cells("IdCategoriaFiscal").Value
            'Me._IdCategoriaFiscalOriginal = Short.Parse(dr.Cells("IdCategoriaFiscal").Value.ToString())

            ComboCategoriaFiscalSelectedValue(dr.ValorNumericoPorDefecto("IdCategoriaFiscal", 0S))

            'Si es X es remito y siempre debe tener esa letra
            'If Me.txtLetra.Text <> "X" And Me.txtLetra.Text <> "R" Then
            '    Me.txtLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
            'End If

            Me.txtCategoria.Text = dr.Cells("NombreCategoria").Value.ToString()
            Me.tbcDetalle.Enabled = True

            If Reglas.Publicos.PermiteModificarClientePedido Then
               Me.bscCliente.Permitido = True
               Me.bscCodigoCliente.Permitido = True
            Else
               Me.bscCliente.Permitido = False
               Me.bscCodigoCliente.Permitido = False
            End If

            Me.bscDireccion.Permitido = False

            Dim Vend As Reglas.Empleados = New Reglas.Empleados()
            Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(Integer.Parse(dr.Cells("IdVendedor").Value.ToString()))

            'Asigno al SelectedValue porque la numeracion de las listas, no necesamiente es correlativa y da error.
            Me.cmbListaDePrecios.SelectedValue = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())

            Dim oCliente As Reglas.Clientes = New Reglas.Clientes()
            Me._clienteE = oCliente.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

            If Me._clienteE.IdTipoComprobante <> "" Then
               Me.cmbTiposComprobantesFact.SelectedValue = Me._clienteE.IdTipoComprobante
            End If
            If Me.cmbTiposComprobantesFact.SelectedIndex = -1 And Me.cmbTiposComprobantesFact.Items.Count > 0 Then
               Me.cmbTiposComprobantesFact.SelectedIndex = 0
            End If

            If Me._clienteE.IdFormasPago <> 0 Then
               Me.cmbFormaPago.SelectedValue = Me._clienteE.IdFormasPago
               If Me.cmbFormaPago.SelectedIndex = -1 And Me.cmbFormaPago.Items.Count > 0 Then
                  Me.cmbFormaPago.SelectedIndex = 0
               End If
            End If

            If _clienteE.IdTransportista <> 0 Then
               cmbRespDistribucion.SelectedValue = _clienteE.IdTransportista
               If Me.cmbRespDistribucion.SelectedIndex = -1 And Me.cmbRespDistribucion.Items.Count > 0 Then
                  Me.cmbRespDistribucion.SelectedIndex = 0
               End If
            End If

            If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
               Me.lblCUIT.Text = My.Resources.RTextos.Cuit
               Me.cmbTipoDoc.Visible = False
               Me.txtNroDocCliente.Visible = False
               Me.lblTipoDocumento.Visible = False
               Me.txtCUIT.Visible = True
               Me.txtCUIT.ReadOnly = True
               Me.txtCUIT.Text = dr.Cells("CUIT").Value.ToString()
               Me.lblCUIT.Text = My.Resources.RTextos.Cuit
               Me.txtNroDocCliente.Text = String.Empty
            Else
               Me.cmbTipoDoc.Visible = True
               Me.cmbTipoDoc.Enabled = False
               Me.txtNroDocCliente.Visible = True
               Me.txtNroDocCliente.ReadOnly = True
               Me.lblTipoDocumento.Visible = True
               Me.txtCUIT.Text = String.Empty
               Me.txtCUIT.Visible = False
               Me.lblCUIT.Text = "Nro. Doc."
               Me.cmbTipoDoc.Text = dr.Cells("TipoDocCliente").Value.ToString()
               Me.txtNroDocCliente.Text = dr.Cells("NroDocCliente").Value.ToString()
            End If

            Me.CambiarEstadoControlesDetalle(True)

            'Se calcula el descuento/recargo gral del Cliente
            Dim nuevoDescRecGralPorc As Decimal = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                                    cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                                    cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                                    _pedidosProductos.Count)
            'SPC: Se determinó que no sería necesario realizar esta consulta.
            '     Si el pedido tiene un %, al editar debe respetar dicho porcentaje.
            '     En el alta debe cambiar el % según corresponda.
            '' '' ''Dim actualizar As Boolean = False

            '' '' ''If nuevoDescRecGralPorc <> _DescRecGralPorc Then
            '' '' ''   actualizar = MessageBox.Show(String.Format("¿Desea actualizar el D/R actual {0:N2}% por el nuevo D/R {1:N2}%?", _DescRecGralPorc, nuevoDescRecGralPorc),
            '' '' ''                                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes
            '' '' ''Else
            '' '' ''   actualizar = False
            '' '' ''End If
            Dim actualizar As Boolean = True

            If actualizar Then
               Me._DescRecGralPorc = nuevoDescRecGralPorc
               Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnTotales.ToString())
            End If

            'Me.cmbCategoriaFiscal.Enabled = False
            Me.CargarProximoNumero()

            Me.CargarSaldosCtaCte()

            Me.ValidarDiasDeVencimiento()

            'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@

            'Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
            'Habria que hacerlo mas general!
            'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal And String.IsNullOrEmpty(Me._clienteE.Cuit) Then
            '    MessageBox.Show("El Cliente NO tiene CUIT y es obligatorio para este comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    'Me.cmbTiposComprobantes.SelectedIndex = -1
            '    'Me.cmbTiposComprobantes.Focus()
            '    Me.Nuevo()
            '    Exit Sub
            'End If
            'txtDireccionYLocalidad
            ''controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
            'If Publicos.FacturacionSolicitaComprobante Then
            '    Me.cmbTiposComprobantes.SelectedIndex = -1
            '    Me.cmbTiposComprobantes.Focus()
            'End If

            If Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorPorClave Then
               Me.cmbVendedor.SelectedIndex = -1
               Me.cmbVendedor.Enabled = False
            Else
               If Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
                  Me.cmbVendedor.SelectedIndex = -1
                  Me.cmbVendedor.Focus()
               End If
            End If


            If Not Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante And Not Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
               Me.bscCodigoProducto2.Focus()
            End If

            If _clienteE.IdClienteCtaCte > 0 And Not bscCodigoClienteVinculado.Selecciono And Not bscClienteVinculado.Selecciono Then
               bscCodigoClienteVinculado.Permitido = True
               bscCodigoClienteVinculado.Text = New Reglas.Clientes().GetUno(_clienteE.IdClienteCtaCte).CodigoCliente.ToString()
               bscCodigoClienteVinculado.PresionarBoton()
               bscCodigoClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado
            End If

            _publicos.CargaComboClientesContactos(cmbContacto, Long.Parse(dr.Cells("IdCliente").Value.ToString()), True)

            If dr.Cells("Direccion").Value.ToString() = Nothing Then
               MessageBox.Show("Actualice la dirección del cliente para continuar..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               MostrarMasInfo()
            End If

            CargaTipoComprobanteProducto()

            Me.SetearCamposClienteGenerico(dr.Cells("Direccion").Value.ToString(), dr.Cells("IdLocalidad").Value.ToString(), dr.Cells("NombreCliente").Value.ToString())


            Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

            If _clienteE IsNot Nothing AndAlso _clienteE.VarPesosCotizDolar <> 0 Then
               Me.txtCotizacionDolar.Text = (Decimal.Parse(Me.txtCotizacionDolar.Text()) + Decimal.Parse(_clienteE.VarPesosCotizDolar.ToString())).ToString("N2")
         End If

      End If
      End If

   End Sub

   Private Sub SetearCamposClienteGenerico(direccion As String, localidad As String, nombreCliente As String)
      If Me._clienteE.EsClienteGenerico Then
         Me.bscCliente.Visible = False
         Me.txtNombreClienteGenerico.Visible = True
         If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
            Me.txtCUIT.ReadOnly = False
         Else
            Me.txtCUIT.Visible = False
            Me.txtNroDocCliente.Visible = True
            Me.cmbTipoDoc.Enabled = True
            Me.txtNroDocCliente.ReadOnly = False
            Me.cmbTipoDoc.Visible = True
            Me.cmbTipoDoc.Text = Reglas.Publicos.TipoDocumentoCliente
            Me.lblTipoDocumento.Visible = True
         End If
         Me.txtCUIT.ReadOnly = False
         Me.txtDireccionClienteGenerico.Visible = True
         Me.txtDireccionClienteGenerico.Text = direccion 'dr.Cells("Direccion").Value.ToString()
         Me.bscCodigoLocalidad.Visible = True
         Me.bscCodigoLocalidad.Text = localidad 'dr.Cells("IdLocalidad").Value.ToString()
         Me.txtNombreClienteGenerico.Text = nombreCliente 'dr.Cells("NombreCliente").Value.ToString()
         Me.txtNombreClienteGenerico.Focus()
         '  Me.cmbCategoriaFiscal.Visible = True
         '  Me.cmbCategoriaFiscal.SelectedValue = Me._Proveedor.CategoriaFiscal.IdCategoriaFiscal
         '  Me.txtCategoriaFiscal.Visible = False
      Else
         Me.txtNombreClienteGenerico.Visible = False
         Me.bscCliente.Visible = True
         Me.txtCUIT.ReadOnly = True
         Me.txtNroDocCliente.ReadOnly = True
         Me.cmbTipoDoc.Enabled = False
         Me.txtDireccionClienteGenerico.Visible = False
         Me.bscCodigoLocalidad.Visible = False
      End If
   End Sub

   Private Sub CargarDatosClienteVinculado(dr As DataGridViewRow)

      Me.bscClienteVinculado.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoClienteVinculado.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      Me.bscCodigoClienteVinculado.Tag = dr.Cells("IdCliente").Value.ToString()
   End Sub

   Private Sub CargarSaldosCtaCte()

      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos

      Dim dt As DataTable

      dt = oCtaCteDet.GetSaldosCtaCte(Nothing, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Nothing, 0)

      Me.txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtSaldoCtaCteVencido.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      If dt.Rows.Count = 1 Then
         Me.txtSaldoCtaCte.Text = Decimal.Parse(dt.Rows(0)("Saldo").ToString()).ToString("##,##0.00")
         If Not String.IsNullOrEmpty(dt.Rows(0)("SaldoVencido").ToString()) Then
            Me.txtSaldoCtaCteVencido.Text = Decimal.Parse(dt.Rows(0)("SaldoVencido").ToString()).ToString("##,##0.00")
         End If
      End If

      'If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
      '   If Decimal.Parse(Me.txtSaldoCtaCte.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
      '      If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
      '         Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
      '      End If
      '   End If
      'End If

      If Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 And
         DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 AndAlso
         DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Tipo = "PEDIDOSCLIE" Then

         Me.ValidarLimiteCredito(arrojarException:=True)

      End If

      '# Semaforo de SALDOS
      Me.SetearColorSemaforos(Me.txtSaldoCtaCte, IdTipoSemaforo:=Entidades.SemaforoVentaUtilidad.TiposSemaforos.SALDOS)

   End Sub



   Private Sub Nuevo()
      _fechaActualizacionBD = Nothing
      _idUsuarioActualizacionBD = String.Empty
      tsbGrabar.Enabled = False
      _estado = Estados.Insercion

      cmbVendedor.Enabled = True

      bscCliente.ReseteaPermitidoNoBackColor()
      bscCodigoCliente.ReseteaPermitidoNoBackColor()
      bscCliente.ReseteaPermitidoSiBackColor()
      bscCodigoCliente.ReseteaPermitidoSiBackColor()

      txtTotalGeneral.Enabled = True
      txtDescRecGral.Enabled = True
      tbcDetalle.SelectedTab = Me.tbpProductos
      tbcDetalle.Enabled = True
      bscCodigoCliente.Text = String.Empty
      bscCliente.Text = String.Empty
      bscDireccion.Text = String.Empty
      bscDireccion.Selecciono = False
      bscDireccion.Permitido = True
      bscCliente.Permitido = True
      bscCodigoCliente.Permitido = True


      _clienteE = Nothing

      bscClienteVinculado.Text = String.Empty
      bscClienteVinculado.Selecciono = False
      bscClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado
      bscCodigoClienteVinculado.Text = String.Empty
      bscCodigoClienteVinculado.Selecciono = False
      bscCodigoClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado

      'Me.dtpFecha.Enabled = True
      txtObservacion.Text = String.Empty
      _pedidosProductos.Clear()
      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      'HabilitaComprobanteFactSegunLineas()
      SetProductosDataSource()

      _pedidosContactos.Clear()
      ugContactos.DataSource = _pedidosContactos
      AjustarColumnasGrilla(ugContactos, _titContactos)

      _productosLotes.Clear()
      _subTotales.Clear()
      dgvIvas.DataSource = Me._subTotales.ToArray()

      txtTelefonos.Text = String.Empty
      txtLimiteDeCredito.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtSaldoCtaCteVencido.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      cmbDirecciones.Enabled = False
      cmbDirecciones.SelectedIndex = -1
      'txtDireccionYLocalidad.Text = String.Empty

      dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
      txtTotalGeneral.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtKilos.Text = "0." + New String("0"c, Me._decimalesEnKilos)
      txtCantidadProductos.Text = "0"
      '----
      bscCodigoProducto2.Text = String.Empty
      bscProducto2.Text = String.Empty
      txtProductoObservacion.Visible = False
      txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
      txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
      txtStock.Text = String.Empty
      txtStock.Tag = False
      txtCantidad.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto)
      txtTamanio.Text = "0." + New String("0"c, Me._decimalesMostrarEnTamanio)
      txtTotalMetrosCuadrados.Text = "0." + New String("0"c, Me._decimalesMostrarEnTamanio)
      txtUM.Text = ""
      btnInsertar.Enabled = True
      btnEliminar.Enabled = True
      '----

      txtTotalBruto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtTotalNeto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtTotalSubtotales.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtTotalImpuestos.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtPercepcionIVA.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtPercepcionIIBB.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtPercepcionGanancias.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtPercepcionVarias.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtTotalPercepcion.Text = "0." + New String("0"c, Me._decimalesEnTotales)


      If Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorPorClave Then
         cmbVendedor.SelectedIndex = -1
         cmbVendedor.Enabled = False
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         Else
            Me.cmbVendedor.SelectedIndex = -1
         End If
      End If

      cmbListaDePrecios.SelectedIndex = 0

      txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
      txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      'Me.txtCategoriaFiscal.Text = String.Empty
      'Me.txtCategoria.Text = String.Empty

      cmbCategoriaFiscal.Enabled = True
      cmbCategoriaFiscal.SelectedIndex = -1

      CambiarEstadoControlesDetalle(False)

      _ModificaDetalle = "TODO"

      txtCotizacionDolar.Enabled = Reglas.Publicos.PedidosPermiteModificarCambio

      If _comprobantesSeleccionados IsNot Nothing Then
         _comprobantesSeleccionados.Clear()
      End If

      _transportistaA = Nothing

      _pedidosObservaciones.Clear()

      dgvObservaciones.DataSource = Me._pedidosObservaciones.ToArray()

      _numeroOrden = 0
      _DescRecGralPorc = 0

      CargarProximoNumero()

      txtSemaforoRentabilidad.Text = ""
      txtSemaforoRentabilidad.Key = "0"
      txtSemaforoRentabilidadDetalle.Text = ""
      txtSemaforoRentabilidad.BackColor = Me.txtLetra.BackColor
      txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor

      txtSemaforoRentabilidadDetalle.Text = ""

      txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtSaldoCtaCte.BackColor = Me.txtLetra.BackColor
      txtSaldoCtaCte.ForeColor = Me.txtLetra.ForeColor
      txtSaldoCtaCte.Font = New Font(Me.txtSaldoCtaCte.Font, FontStyle.Regular)

      txtRentabilidadDetalle.Text = ""

      ' cmbMonedaVenta.SelectedValue = 1
      cmbMonedaVenta.SelectedValue = Reglas.Publicos.PedidosMonedaPorDefecto

      Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

      If _clienteE IsNot Nothing AndAlso _clienteE.VarPesosCotizDolar <> 0 Then
         Me.txtCotizacionDolar.Text = (Decimal.Parse(Me.txtCotizacionDolar.Text()) + Decimal.Parse(_clienteE.VarPesosCotizDolar.ToString())).ToString("N2")
      End If

      Me.chbModificaPrecio.Checked = Reglas.Publicos.PedidosModificaPrecioProducto
      Me.chbModificaDescRecargo.Checked = Reglas.Publicos.PedidosPermiteModificarDescRecPedidos

      lblKilosModDesc.Visible = False
      txtKilosModDesc.Text = "0." + New String("0"c, Me._decimalesEnKilos)
      txtKilosModDesc.Visible = False

      ' Me.cmbCajas.SelectedIndex = 0

      bscCodigoCliente.Text = String.Empty
      bscCodigoCliente.Focus()

      cmbTiposComprobantes.SelectedIndex = 0
      cmbTiposComprobantesFact.SelectedIndex = -1

      dtpFechaEntrega.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now

      txtOrdenDeCompra.Text = ""

      bscCliente.Visible = True
      bscCodigoLocalidad.Visible = False

      cmbDirecciones.Visible = True
      'txtDireccionYLocalidad.Visible = True
      txtNombreClienteGenerico.Visible = False
      txtNombreClienteGenerico.Text = ""
      txtDireccionClienteGenerico.Visible = False
      txtDireccionClienteGenerico.Text = ""
      '-- REG-30529.- --
      cmbCajaPedido.SelectedIndex = -1

      LimpiarCamposObservDetalles()
   End Sub

   Private Function ValidarInsertaProducto() As Boolean

      'Esta Habilitado si permite Modificar la Descripcion.
      If Me.bscProducto2.Enabled Then

         If Me.bscCodigoProducto2.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Codigo de Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2.Focus()
            Return False
         End If
         If Me.bscProducto2.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscProducto2.Focus()
            Return False
         End If

         If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono And (Me.bscCodigoProducto2.Text.Trim.Length = 0 Or Me.bscProducto2.Text.Trim.Length = 0) Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2.Focus()
            Return False
         End If

         'Significa que escribo en ambos casos y no dio enter, tiene que al menos buscar.
         If bscCodigoProducto2.FilaDevuelta Is Nothing And bscProducto2.FilaDevuelta Is Nothing Then
            MessageBox.Show("No eligió un Producto, solo los digito, falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2.Focus()
            Return False
         End If

      Else
         If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2.Focus()
            Return False
         End If

         Dim PrecioNeto As Decimal = 0
         Dim descRec1 As Decimal = Decimal.Round(Decimal.Parse(Me.txtPrecio.Text.ToString()) * Decimal.Parse(Me.txtDescRecPorc1.Text.ToString()) / 100, Me._decimalesRedondeoEnPrecio)
         Dim descRec2 As Decimal = Decimal.Round((Decimal.Parse(Me.txtPrecio.Text.ToString()) + descRec1) * Decimal.Parse(Me.txtDescRecPorc2.Text.ToString()) / 100, Me._decimalesRedondeoEnPrecio)
         Dim descRec As Decimal = Decimal.Round((Decimal.Parse(Me.txtPrecio.Text.ToString()) + descRec1 + descRec2) * Decimal.Parse(Me.txtDescRecGralPorc.Text.ToString()) / 100, Me._decimalesRedondeoEnPrecio)

         PrecioNeto = Decimal.Parse(Me.txtPrecio.Text.ToString()) + descRec1 + descRec2 + descRec

         Dim PorcDescTotal As Decimal = 0

         'Calculo el precio Neto contra el de Lista porque ademas pudo cambiar el precio (para arriba o abajo).
         If Decimal.Parse(Me.txtPrecio.Tag.ToString()) > 0 Then
            PorcDescTotal = Decimal.Round((PrecioNeto / Decimal.Parse(Me.txtPrecio.Tag.ToString()) - 1) * 100, Me._decimalesRedondeoEnPrecio)
         End If

         'Rechazo Si tiene configurado el precio neto, y realizo descuento (en el global) y el descuento es mayor al maximo...
         If Reglas.Publicos.Facturacion.DescuentoMaximo > 0 And PorcDescTotal < 0 And Math.Abs(PorcDescTotal) > Reglas.Publicos.Facturacion.DescuentoMaximo Then
            MessageBox.Show("ATENCION: Asignó un Descuento de " & Math.Abs(PorcDescTotal).ToString("N2") & "% y el Máximo es : " & Reglas.Publicos.Facturacion.DescuentoMaximo.ToString("N2") + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If Decimal.Parse(Me.txtDescRecPorc1.Text.ToString()) < 0 Or Me.txtPrecio.ReadOnly Then
               Me.txtDescRecPorc1.Focus()
            Else
               FocusPrecio()
            End If
            Return False
         End If

      End If

      Dim oProd As Reglas.Productos = New Reglas.Productos()
      Dim prod As Entidades.Producto = New Entidades.Producto()
      prod = oProd.GetUno(Me.bscCodigoProducto2.Text)

      If Not prod.EsObservacion Then
         If GetTipoOperacionSeleccionada() = Entidades.Producto.TiposOperaciones.NORMAL Then
            If Decimal.Parse(Me.txtPrecio.Text) <= 0 Then
               MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               FocusPrecio()
               Return False
            End If
         End If

         If Me.txtCantidad.Text = "" Then
            MessageBox.Show("No puede ingresar sin cantidad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCantidadManual.Select()
            Return False
         End If

         If Decimal.Parse(Me.txtCantidad.Text) = 0 Then
            MessageBox.Show("La cantidad debe ser distinta de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCantidadManual.Select()
            Return False
         End If

         'En txtStock.Tag guardo propiedad "AfectaStock"
         If Decimal.Parse(Me.txtCantidad.Text) <= 0 And Boolean.Parse(Me.txtStock.Tag.ToString()) Then
            MessageBox.Show("La cantidad debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCantidadManual.Select()
            Return False
         End If
      Else
         If Decimal.Parse(Me.txtPrecio.Text) > 0 Then
            MessageBox.Show("El precio debe ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            FocusPrecio()
            Return False
         End If
      End If

      If txtCantidad.ValorNumericoPorDefecto(0D) < _cantidadNoPendienteOriginal Then
         ShowMessage("Está modificando la línea del pedido por debajo de la cantidad Pendiente.")
         txtCantidadManual.Select()
         Return False
      End If

      If Reglas.Publicos.PedidosPermiteFechaEntregaDistintas Then
         If DateDiff(DateInterval.Day, Me.dtpFecha.Value, Me.dtpFechaEntregaProd.Value) < 0 Then
            ShowMessage(String.Format(Traducciones.TraducirTexto("La Fecha de Entrega es menor a la Fecha del Pedido ({0:dd/MM/yyyy}.", Me, "__ErrorFechaEntregaPedidoInvalida"),
                                      dtpFecha.Value))
            Me.dtpFechaEntregaProd.Focus()
            Return False
         End If
      End If

      If GetTipoOperacionSeleccionada() <> Entidades.Producto.TiposOperaciones.NORMAL Then
         If Decimal.Parse(txtPrecio.Text) <> 0 Then
            ShowMessage(String.Format("El precio debe ser cero (0) en operaciones del tipo {0}.", cmbTipoOperacion.Text))
            Me.txtPrecio.Focus()
            Return False
         End If
         If cmbNota.Visible AndAlso String.IsNullOrWhiteSpace(cmbNota.Text) Then
            ShowMessage(String.Format("El tipo de operación {0} requiere que se ingrese una Nota.", cmbTipoOperacion.Text))
            Me.cmbNota.Focus()
            Return False
         End If
      End If


      'If Me.dgvProductos.RowCount = Me._cantMaxItems Then
      '    MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas de Productos para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '    btnInsertar.Select()
      '    Return False
      'End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.


      '*** Controlo la Facturacion Sin Stock ***

      'PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), ó invoco (no corresponde)
      'los valores posibles para el coeficientestock son 0, 1 y -1

      Dim blnControlarStock As Boolean = False

      'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0 Then

      '    'Si NO facturo otros (ej: Factura sin Facturables).

      '    If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 OrElse Me._comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = 0 Then
      '        'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).

      '        blnControlarStock = True

      '    End If

      'End If

      'If Decimal.Parse(Me.txtCantidad.Text) > Decimal.Parse(Me.txtStock.Text) And Boolean.Parse(Me.txtStock.Tag.ToString()) And blnControlarStock Then

      '   If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
      '      MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      txtCantidadManual.Select()
      '      Return False

      '   ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
      '      MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   End If

      'End If

      '-----------------------------------------

      'Si esta habilitado aunque grabe Libro de Iva significa que tiene Multiples IVAs, chequeo que sea uno de los dos.
      'If Me.cmbPorcentajeIva.Enabled And DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
      '    Dim oProducto As Entidades.Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text.Trim())
      '    If Decimal.Parse(Me.cmbPorcentajeIva.Text) <> oProducto.Alicuota And Decimal.Parse(Me.cmbPorcentajeIva.Text) <> oProducto.Alicuota2 Then
      '        MessageBox.Show("Alicuota NO habilitada para este Producto, estas son: " & oProducto.Alicuota.ToString() & " y " & oProducto.Alicuota2.ToString() & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '        Me.cmbPorcentajeIva.Focus()
      '        Return False
      '    End If
      'End If


      'controlo que no se repita el producto ingresado
      'Dim ent As Entidades.VentaProducto
      'For i As Integer = 0 To Me._ventasProductos.Count - 1
      '   ent = Me._ventasProductos(i)
      '   If ent.Producto.IdProducto = Me.bscCodigoProducto2.Text Then
      '      If MessageBox.Show("El Producto ya está ingresado en este Comprobante. ¿Desea agregar la cantidad al mismo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
      '         Me.txtCantidad.Text = (Decimal.Parse(Me.txtCantidad.Text) + ent.Cantidad).ToString("##0.00")
      '         Me.CalcularTotalProducto()
      '         Me._ventasProductos.RemoveAt(i)
      '         Return True
      '      Else
      '         Return False
      '      End If
      '   End If
      'Next

      If Not prod.EsObservacion Then
         'Esta Habilitado si permite Modificar la Descripcion.
         If Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible Then
            If Reglas.Publicos.PedidosModificaDescripSolicitaKilos Then
               If Not IsNumeric(txtKilosModDesc.Text) Then txtKilosModDesc.Text = "0.00"
               If Decimal.Parse(Me.txtKilosModDesc.Text) = 0 Then
                  MessageBox.Show("Debe Ingresar Kilos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Me.txtKilosModDesc.Focus()
                  Return False
               End If
            End If
         End If
      End If

      If Reglas.Publicos.PreVentaAgrupaOrdenProductoEnCadaPedido Then
         If _pedidosProductos.Count > 0 Then
            If _pedidosProductos.LongCount(Function(x) x.Producto.Orden <> prod.Orden) > 0 Then
               Dim stb As StringBuilder = New StringBuilder()
               stb.AppendLine("No puede ingresar Productos con diferente Orden en un mismo pedido si tiene activado el parámetro 'Preventa Agrupa los productos por órden en diferentes Pedido'")
               ShowMessage(stb.ToString())
               bscCodigoProducto2.Focus()
               Return False
            End If
         End If
      End If

      Return True

   End Function

   Private Sub CargarProducto(dr As DataGridViewRow)

      If Integer.Parse(dr.Cells("Atributos").Value.ToString()) = 0 Then

         Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         Me.bscCodigoProducto2.Enabled = False

         Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         Me.bscProducto2.Enabled = False
         'Me.bscProducto2.Enabled = Publicos.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
         txtProductoObservacion.Text = Me.bscProducto2.Text
         If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()) Then
            txtProductoObservacion.Visible = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
         End If

         cmbTipoOperacion.Enabled = False

         Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         '####################################################################################
         '# Si el producto utiliza doble UM NO SE PUEDE UTILZIAR EN PEDIDOS (Por el momento) #
         '####################################################################################
         If Producto.UnidadDeMedida2 IsNot Nothing Then
            Me.bscCodigoProducto2.Focus()
            LimpiarCamposProductos()
            Throw New Exception("ATENCIÓN: No se puede cargar un producto con doble Unidad de Medida.")
         End If

         If Producto.ImporteImpuestoInterno <> 0 Then
            ShowMessage(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se podrá agregar el producto al Pedido.", Producto.IdProducto, Producto.NombreProducto))
         End If

         _calculaPreciosSegunFormula = Producto.CalculaPreciosSegunFormula

         'Dim impuestoInterno As Decimal = MuestraImpuestosInternos(Decimal.Parse(dr.Cells("ImporteImpuestoInterno").Value.ToString()))

         If GetTipoOperacionSeleccionada() <> Entidades.Producto.TiposOperaciones.NORMAL Then
            dr.Cells("PrecioVentaSinIVA").Value = 0
            dr.Cells("PrecioVentaConIVA").Value = 0
         End If

         Me.cmbPorcentajeIva.Text = dr.Cells("Alicuota").Value.ToString()
         Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
         '--------------------------------------------------------------------------------------------------------------------------------
         Dim PrecioPorEmbalaje As Boolean = Boolean.Parse(dr.Cells("PrecioPorEmbalaje").Value.ToString())

         Dim PrecioVentaSinIVA As Decimal = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString())
         Dim PrecioVentaConIVA As Decimal = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString())

         Dim PrecioCostoSinIVA As Decimal
         Dim PrecioCostoConIVA As Decimal
         Dim PrecioCosto As Decimal

         If Reglas.Publicos.PreciosConIVA Then
            PrecioCostoConIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
            PrecioCostoSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioCostoConIVA, Producto.Alicuota,
         Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
         Else
            PrecioCostoSinIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
            PrecioCostoConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioCostoSinIVA, Producto.Alicuota,
         Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
         End If


         If PrecioPorEmbalaje Then
            PrecioVentaSinIVA = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()) / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
            PrecioVentaConIVA = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()) / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
            PrecioCostoConIVA = PrecioCostoConIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
            PrecioCostoSinIVA = PrecioCostoSinIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
         End If

         'Si el producto pertenece a una Marca que tiene lista de Precios especifica.. vuelvo a tomar los precios.

         Dim dt As DataTable
         dt = New Reglas.ClientesMarcasListasDePrecios().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdMarca").Value.ToString()))

         If dt.Rows.Count = 1 Then

            Dim IdListaDePrecio As Integer
            IdListaDePrecio = Integer.Parse(dt.Rows(0)("IdListaPrecios").ToString())

            dt = Nothing
            dt = New Reglas.Productos().GetPorCodigo(Me.bscCodigoProducto2.Text, actual.Sucursal.Id, IdListaDePrecio, "VENTAS")

            PrecioVentaSinIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaSinIVA").ToString())
            PrecioVentaConIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaConIVA").ToString())

            If Reglas.Publicos.PreciosConIVA Then
               PrecioCostoConIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
               PrecioCostoSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioCostoConIVA, Producto.Alicuota,
            Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
            Else
               PrecioCostoSinIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
               PrecioCostoConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioCostoSinIVA, Producto.Alicuota,
            Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
            End If
         End If
         '----------------------------------------------------------------------------------------------------------------------------------

         'Precio de Venta, Opciones: ACTUAL o ULTIMO
         If Publicos.VentasPrecioVenta <> "ACTUAL" Then

            Dim CalculoVenta() As String = Publicos.VentasPrecioVenta.Split(";"c)

            Dim OtroPrecioVenta As Decimal = 0

            Select Case CalculoVenta(0).ToString()

               Case "ULTIMO"

                  Dim oVP As Reglas.VentasProductos = New Reglas.VentasProductos()

                  OtroPrecioVenta = 0
                  '################ ver
                  'OtroPrecioVenta = oVP.GetUltimoDeProducto(actual.Sucursal.Id, _
                  '                                          Me.cmbTiposComprobantes.SelectedValue.ToString(), _
                  '                                          Me.bscCodigoProducto2.Text, _
                  '                                          Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)

               Case Else
                  Throw New Exception("ATENCION: el sistema tiene configurado el Tipo de VENTA '" & CalculoVenta(0).ToString() & "' (incorrecto), verifíquelo en Parametros")

            End Select

            If OtroPrecioVenta <> 0 Then
               PrecioVentaSinIVA = OtroPrecioVenta
               PrecioVentaConIVA = Decimal.Round(PrecioVentaSinIVA * (1 + (Decimal.Parse(dr.Cells("Alicuota").Value.ToString()) / 100)), Me._decimalesRedondeoEnPrecio)
            End If

         End If
         '------------------------------------------

         If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
            PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
            PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
            PrecioCostoSinIVA = Decimal.Round(PrecioCostoSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
            PrecioCostoConIVA = Decimal.Round(PrecioCostoConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         End If

         If (Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
         Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
         Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then

            Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            Me.txtPrecio.Tag = Me.txtPrecio.Text
            PrecioCosto = PrecioCostoSinIVA
         Else
            'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
            Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            Me.txtPrecio.Tag = Me.txtPrecio.Text
            PrecioCosto = PrecioCostoConIVA
         End If

         CalcularImpuestoInterno()

         Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
         Me.txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

         Me.txtTamanio.Text = dr.Cells("Tamano").Value.ToString()
         Me.txtUM.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
         Me.txtCantidad.SetValor(1D)
         Me.txtCantidadManual.Text = Me.txtCantidad.Text

         '# Combo de UM.
         Me.CargaComboUnidadesMedida(Producto.UnidadDeMedida, Producto.UnidadDeMedida2, Me.cmbUM2)

         Me.txtKilosModDesc.Text = dr.Cells("Kilos").Value.ToString()

         Me.dtpFechaActPrecios.Value = Date.Parse(dr.Cells("FechaActualizacion").Value.ToString())

         'Se calculan los descuentos correspondientes al Cliente/Producto/Cantidad
         '-------------------------------------------------------------------------
         Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
         If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
            _txtCantidad_prev = Nothing
            Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

            For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
               If vp.Producto.IdRubro = Producto.IdRubro Then
                  cantidad += vp.Cantidad
               End If
            Next

            Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, Producto, cantidad, Me._decimalesEnTotales)

            For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
               If vp.Producto.IdRubro = Producto.IdRubro Then
                  vp.DescuentoRecargoPorc = _DescuentosRecargosProd.DescuentoRecargo1
                  If calculaDescuentoRecargo2 Then
                     vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
                  End If
               End If
               vp.DescuentoRecargoProducto = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
         vp.DescuentoRecargoPorc, vp.DescuentoRecargoPorc2, vp.Cantidad)
            Next

            'RecalcularTodo()

         Else
            Me._DescuentosRecargosProd = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), Me._decimalesEnTotales)
         End If

         _solicitaPrecioVentaPorTamano = Producto.SolicitaPrecioVentaPorTamano
         txtPrecioVentaPorTamano.Enabled = _solicitaPrecioVentaPorTamano

         txtCosto.Text = PrecioCosto.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         lblPrecioVentaPorTamano2.Text = String.Format("x {0}", Producto.UnidadDeMedida.NombreUnidadDeMedida)
         Dim idMoneda As Integer = Reglas.Publicos.DetallePedido.PedidosMonedaPrecioVentaPorTamano
         If idMoneda = 0 Then
            cmbMoneda.SelectedValue = Producto.Moneda.IdMoneda
         Else
            cmbMoneda.SelectedValue = idMoneda
         End If

         txtProductoEspPulgadas.Text = Producto.EspPulgadas
         txtProductoEspmm.Text = Producto.Espmm.ToString("N" + _decimalesEnCantidad.ToString())
         txtProductoSAE.Text = Producto.CodigoSAE
         cmbProductoProduccionProceso.SelectedValue = Producto.IdProduccionProceso
         cmbProductoProduccionForma.SelectedValue = Producto.IdProduccionForma


         Me.txtDescRecPorc1.Text = Me._DescuentosRecargosProd.DescuentoRecargo1.ToString("N" + _decimalesEnTotales.ToString())
         If calculaDescuentoRecargo2 Then
            Me.txtDescRecPorc2.Text = Me._DescuentosRecargosProd.DescuentoRecargo2.ToString("N" + _decimalesEnTotales.ToString())
         End If

         'If _calculaPreciosSegunFormula Then
         _cargandoComboFormula = True
         _publicos.CargaComboFormulasDeProductos(cmbFormula, Producto.IdProducto)
         _publicos.CargaComboProcesosProductivos(cmbProcesoProductivo, Producto.IdProducto, Entidades.Publicos.SiNoTodos.SI)
         _cargandoComboFormula = False
         If cmbFormula.Items.Count = 0 Then
            cmbFormula.SelectedIndex = -1
            cmbFormula.Enabled = False
            cmbFormula.Visible = False
         Else
            cmbFormula.SelectedValue = Producto.IdFormula
            cmbFormula.Enabled = True
            cmbFormula.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarFormula
         End If
         If cmbProcesoProductivo.Items.Count = 0 Then
            cmbProcesoProductivo.SelectedIndex = -1
            cmbProcesoProductivo.Enabled = False
            cmbProcesoProductivo.Visible = False
         Else
            cmbProcesoProductivo.SelectedValue = Producto.IdProcesoProductivoDefecto.IfNull()
            cmbProcesoProductivo.Enabled = True
            cmbProcesoProductivo.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarFormula
         End If
         btnEditarFormula.Enabled = cmbFormula.Enabled

         HabilidaPrecios(_clienteE IsNot Nothing)

         txtProductoAnchoIntBase.Enabled = Producto.CalculaPreciosSegunFormula
         txtProductoLargoExtAlto.Enabled = Producto.CalculaPreciosSegunFormula
         txtProductoArchitrave.Enabled = Producto.CalculaPreciosSegunFormula
         cmbProductoProduccionForma.Enabled = Producto.CalculaPreciosSegunFormula

         If _DescuentosRecargosProd.Mensaje <> "" Then
            ShowMessage(_DescuentosRecargosProd.Mensaje.ToString())
         End If
         '--------------------------------------------------------------------------


         '' ''If Not String.IsNullOrEmpty(dr.Cells("IdSubRubro").Value.ToString()) Then

         '' ''   'Cargo el Descuento/Recargo cargado en el subrubro
         '' ''   Dim oSR As Reglas.SubRubros = New Reglas.SubRubros()
         '' ''   Dim SubR As Entidades.SubRubro

         '' ''   SubR = oSR.GetUno(Integer.Parse(dr.Cells("IdSubRubro").Value.ToString()))
         '' ''   Me.txtDescRecPorc1.Text = SubR.DescuentoRecargo.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))

         '' ''   'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
         '' ''   Dim oCSR As Reglas.ClientesDescuentosSubRubros = New Reglas.ClientesDescuentosSubRubros()
         '' ''   Dim SubR2 As Entidades.SubRubro

         '' ''   SubR2 = oCSR.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdSubRubro").Value.ToString()))
         '' ''   Me.txtDescRecPorc2.Text = SubR2.DescuentoRecargo.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
         '' ''End If
         ' '' ''---------------------------------------------------------------------------

         ' '' ''Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
         '' ''Dim oCDM As Reglas.ClientesDescuentosMarcas = New Reglas.ClientesDescuentosMarcas()
         '' ''Dim Marc As Entidades.Marca

         '' ''Marc = oCDM.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdMarca").Value.ToString()))
         '' ''If Marc.DescuentoRecargoPorc1 <> 0 Then
         '' ''   If Decimal.Parse(Me.txtDescRecPorc1.Text) = 0 Then
         '' ''      Me.txtDescRecPorc1.Text = Marc.DescuentoRecargoPorc1.ToString("##0.00")
         '' ''   ElseIf Decimal.Parse(Me.txtDescRecPorc2.Text) = 0 Then
         '' ''      Me.txtDescRecPorc2.Text = Marc.DescuentoRecargoPorc1.ToString("##0.00")
         '' ''   Else
         '' ''      MessageBox.Show("ATENCION: no fue posible asignar el Descuento especial de " & Marc.DescuentoRecargoPorc1.ToString("##0.00"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         '' ''   End If
         '' ''End If
         '' ''If Marc.DescuentoRecargoPorc2 <> 0 Then
         '' ''   If Decimal.Parse(Me.txtDescRecPorc1.Text) = 0 Then
         '' ''      Me.txtDescRecPorc1.Text = Marc.DescuentoRecargoPorc2.ToString("##0.00")
         '' ''   ElseIf Decimal.Parse(Me.txtDescRecPorc2.Text) = 0 Then
         '' ''      Me.txtDescRecPorc2.Text = Marc.DescuentoRecargoPorc2.ToString("##0.00")
         '' ''   Else
         '' ''      MessageBox.Show("ATENCION: no fue posible asignar el Descuento especial de " & Marc.DescuentoRecargoPorc2.ToString("##0.00"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         '' ''   End If
         '' ''End If
         '---------------------------------------------------------------------------

         'Exento sin IVA. 
         If Me.cmbTiposComprobantes.SelectedIndex <> -1 Then
            If Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
               Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
               Me.cmbPorcentajeIva.Text = "0." + New String("0"c, Me._decimalesEnTotales)
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
            End If
         End If

         Me._productoLoteTemporal = New Entidades.VentaProductoLote()
         Me._productoLoteTemporal.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

         txtCantidadManual.Select()
         Me.txtCantidadManual.SelectAll()

         'Si esta habitada, seguramente la cambiaria
         If Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible Then
            If Reglas.Publicos.Facturacion.FacturacionModificaDescriProdCantidad Then
               txtCantidadManual.Select()
               Me.txtCantidadManual.SelectAll()
            Else
               txtProductoObservacion.Focus()
               'Me.bscProducto2.Focus()
               'Me.bscProducto2.SelectAll()
            End If
            If Reglas.Publicos.PedidosModificaDescripSolicitaKilos Then
               Me.lblKilosModDesc.Visible = True
               Me.txtKilosModDesc.Visible = True
            Else
               Me.lblKilosModDesc.Visible = False
               Me.txtKilosModDesc.Visible = False
            End If
         Else
            Me.lblKilosModDesc.Visible = False
            Me.txtKilosModDesc.Visible = False
            If Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()) Then
               txtProductoObservacion.Focus()
            Else
               txtCantidadManual.Select()
               Me.txtCantidadManual.SelectAll()
            End If
         End If

         'Controla multiples Ivas en producto
         'If dr.Cells("Alicuota2").Value.ToString() <> Nothing Then
         '    Me.cmbPorcentajeIva.Enabled = True
         '    'Me._publicos.CargaComboImpuestos(Me.cmbPorcentajeIva)
         'End If

         SetearDescuentosPorCantidad(Producto)
      Else
         MessageBox.Show(String.Format("No es posible cargar el producto ({0}), el mismo utiliza SubRubro con Atributo", dr.Cells("NombreProducto").Value.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         bscCodigoProducto2.Selecciono = False
         bscProducto2.Selecciono = False
         bscCodigoProducto2.Focus()
      End If

   End Sub

   Private Sub CargarProductoCompleto(dr As DataGridViewRow,
      editarProductosDesdeGrilla As Boolean)

      Try
         _cargandoProductoDesdeCompleto = True

         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Dim Prod As Entidades.Producto

         Prod = oProductos.GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         Dim pedidoProducto As Entidades.PedidoProducto = DirectCast(dr.DataBoundItem, Entidades.PedidoProducto)

         If _pedidosProductosFormulas.ContainsKey(pedidoProducto) Then
            _pedidosProductosFormulasActual = _pedidosProductosFormulas(pedidoProducto)
         End If

         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

         cmbTipoOperacion.SelectedItem = pedidoProducto.TipoOperacion
         cmbNota.Text = pedidoProducto.Nota

         _cargandoProductosAutomaticamente = pedidoProducto.Automatico

         'Llamo al evento para cargar el objeto "FilaDevuelta" validado luego al insertar el producto.
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", soloBuscaPorIdProducto:=editarProductosDesdeGrilla)
         Me.bscCodigoProducto2.PresionarBoton()

         If Reglas.Publicos.PedidosConservaOrdenProductos Then
            _ordenProducto = pedidoProducto.Orden  '  Integer.Parse(dr.Cells("Orden").Value.ToString())
         End If

         If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
            'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
            Me.bscProducto2.Text = dr.Cells("ProductoDesc").Value.ToString()
            Me.txtProductoObservacion.Text = dr.Cells("ProductoDesc").Value.ToString()
         End If

         'NO hace falta, el "PresionarBoton" llama a "CargarProducto" y lo asigna.
         ''Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
         'Me.txtStock.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("Stock").Value.ToString()
         'Me.txtStock.Tag = Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("AfectaStock").Value.ToString())

         cmbFormula.SelectedIndex = -1
         cmbProcesoProductivo.SelectedIndex = -1
         _cargandoProductoDesdeCompleto = False

         cmbFormula.SelectedValue = pedidoProducto.IdFormula
         cmbProcesoProductivo.SelectedValue = pedidoProducto.IdProcesoProductivo
         txtProductoLargoExtAlto.Text = pedidoProducto.LargoExtAlto.ToString(_formatoCantidades)
         txtProductoAnchoIntBase.Text = pedidoProducto.AnchoIntBase.ToString(_formatoCantidades)
         txtProductoArchitrave.Text = pedidoProducto.Architrave.ToString(_formatoCantidades)
         cmbProductoProduccionModeloForma.SelectedValue = pedidoProducto.IdProduccionModeloForma

         If Not _calculaPreciosSegunFormula OrElse _pedidosProductosFormulasActual Is Nothing Then
            txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), Me._decimalesRedondeoEnPrecio).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         End If
         txtCantidad.Text = dr.Cells("Cantidad").Value.ToString()
         txtCantidadManual.Text = dr.Cells("CantidadManual").Value.ToString()
         cmbPorcentajeIva.Text = dr.Cells("AlicuotaImpuesto").Value.ToString()
         cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
         If Decimal.Parse(dr.Cells("Precio").Value.ToString()) <> 0 Then
            txtDescRecPorc1.Text = Decimal.Parse(dr.Cells("DescuentoRecargoPorc").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesEnDescRec))
            txtDescRecPorc2.Text = Decimal.Parse(dr.Cells("DescuentoRecargoPorc2").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesEnDescRec))
         End If

         CalcularImpuestoInterno()

         txtDescRec.Text = Decimal.Parse(dr.Cells("DescuentoRecargoProducto").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         txtTotalProducto.Text = Decimal.Parse(dr.Cells("Importe").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto))

         txtTamanio.Text = dr.Cells(Entidades.PedidoProducto.Columnas.Tamano.ToString()).Value.ToString() ' Me.bscCodigoProducto2.FilaDevuelta.Cells("Tamano").Value.ToString()
         If dr.Cells(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).Value IsNot Nothing Then
            txtUM.Text = dr.Cells(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).Value.ToString() ' Me.bscCodigoProducto2.FilaDevuelta.Cells("IdUnidadDeMedida").Value.ToString()
            cmbUM2.SelectedValue = txtUM.Text
         Else
            txtUM.Text = String.Empty
         End If

         'txtPrecioVentaPorTamano.Text = Decimal.Parse(dr.Cells(Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString()).Value.ToString()).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         'cmbMoneda.SelectedValue = Integer.Parse(dr.Cells(Entidades.PedidoProducto.Columnas.IdMoneda.ToString()).Value.ToString())

         dtpFechaEntregaProd.Value = DateTime.Parse(dr.Cells("FechaEntrega").Value.ToString())

         'Divido por la cantidad porque en la linea ya esta el total por linea.
         If Decimal.Parse(dr.Cells("Cantidad").Value.ToString()) <> 0 Then
            txtKilosModDesc.Text = (Decimal.Parse(dr.Cells("Kilos").Value.ToString()) / Decimal.Parse(dr.Cells("Cantidad").Value.ToString())).ToString("##,##0.000")
         End If

         _modificoDescuentosProducto = CBool(dr.Cells("ModificoDescuentos").Value)
         _txtCantidad_prev = Decimal.Parse(dr.Cells("Cantidad").Value.ToString())

         txtCosto.Text = pedidoProducto.Costo.ToString(_formatoPrecios)
         txtProductoEspPulgadas.Text = pedidoProducto.EspPulgadas
         txtProductoEspmm.Text = pedidoProducto.Espmm.ToString(_formatoCantidades)
         txtProductoSAE.Text = pedidoProducto.CodigoSAE
         cmbProductoProduccionForma.SelectedValue = pedidoProducto.IdProduccionForma
         cmbProductoProduccionProceso.SelectedValue = pedidoProducto.IdProduccionProceso
         txtPrecioVentaPorTamano.Text = pedidoProducto.PrecioVentaPorTamano.ToString(_formatoPrecios)

         Dim idMoneda As Integer = Reglas.Publicos.DetallePedido.PedidosMonedaPrecioVentaPorTamano
         If idMoneda = 0 Then
            cmbMoneda.SelectedValue = pedidoProducto.IdMoneda
         Else
            cmbMoneda.SelectedValue = idMoneda
         End If
         'cmbMoneda.SelectedValue = pedidoProducto.IdMoneda

         txtProductoUrlPlano.Text = pedidoProducto.UrlPlano

         _cantidadOriginal = pedidoProducto.CantidadOriginal
         _cantidadNoPendienteOriginal = pedidoProducto.CantNoPendienteOriginal

         SetearDescuentosPorCantidad(Prod)
      Finally
         _cargandoProductoDesdeCompleto = False
      End Try
   End Sub

   Private Sub CalcularDatosDetalle()

      If Me.cmbCategoriaFiscal.SelectedItem Is Nothing Then Exit Sub

      For Each vPro As Entidades.PedidoProducto In Me._pedidosProductos

         vPro.DescRecGeneral = Decimal.Round((vPro.ImporteTotal * Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100), Me._decimalesRedondeoEnPrecio)

         Me.CalculaValores(vPro.Cantidad, vPro.AlicuotaImpuesto, vPro.ImporteImpuestoInterno, vPro.Precio,
               vPro.DescuentoRecargoPorc, vPro.DescuentoRecargoPorc2, Decimal.Parse(Me.txtDescRecGralPorc.Text),
               vPro.PrecioNeto, 0, vPro.ImporteImpuesto, vPro.ImporteTotal, vPro.Producto)

         'vPro.DescuentoRecargoProducto = (vPro.PrecioNeto - vPro.Precio) * vPro.Cantidad

      Next

      Me.dgvProductos.Refresh()
      '     Me.dgvRemitoTransp.Refresh()

      Me.RecalcularSubtotales()
      Me.CalcularTotales()

   End Sub


   Private Sub CargarUnArticulo(linea As Entidades.PedidoProducto,
                                producto As Entidades.Producto,
                                productoDescripcion As String,
                                descuentoRecargoPorc1 As Decimal,
                                descuentoRecargoPorc2 As Decimal,
                                descuentoRecargo As Decimal,
                                precio As Decimal,
                                cantidad As Decimal,
                                cantidadManual As Decimal,
                                importeTotal As Decimal,
                                stock As Decimal,
                                costo As Decimal,
                                precioLista As Decimal,
                                kilos As Decimal,
                                idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                porcentajeIva As Decimal,
                                importeIva As Decimal,
                                precioNeto As Decimal,
                                criticidad As String,
                                fechaEntrega As Date,
                                fechaActualizacion As Date,
                                ImpuestoInterno As Decimal,
                                porcImpuestoInterno As Decimal,
                                origenPorcImpInt As Entidades.OrigenesPorcImpInt,
                                PrecioVentaPorTamano As Decimal,
                                Tamano As Decimal,
                                IdUnidadDeMedida As String,
                                moneda As Entidades.Moneda,
                                espmm As Decimal,
                                espPulgadas As String,
                                codigoSAE As String,
                                produccionProceso As Entidades.ProduccionProceso,
                                produccionForma As Entidades.ProduccionForma,
                                largoExtAlto As Decimal,
                                anchoIntBase As Decimal,
                                architrave As Decimal,
                                modeloForma As Entidades.ProduccionModeloForma,
                                urlPlano As String,
                                idFormula As Integer,
                                nombreFormula As String,
                                idProcesoProductivo As Long, codigoProcesoProductivo As String, descripcionProcesoProductivo As String,
                                modificoPrecioManualmente As Boolean)

      Dim cotizacion As Decimal = 1
      Decimal.TryParse(txtCotizacionDolar.Text, cotizacion)

      With linea
         If PedidoAEditar IsNot Nothing Then
            .IdSucursal = PedidoAEditar.IdSucursal
         Else
            .IdSucursal = actual.Sucursal.Id
         End If
         .Usuario = actual.Nombre
         '.Producto.IdProducto = idProducto
         .Producto = producto ' New Reglas.Productos().GetUno(idProducto)  'Luego uso ciertas caracteristicas (ej: LOTE).
         .Producto.NombreProducto = productoDescripcion   'Piso la descripcion por si tiene habilitado la posibilidad de cambiarlas.
         .CodigoProductoProveedor = If(producto.ProductoProveedorHabitual IsNot Nothing, producto.ProductoProveedorHabitual.CodigoProductoProveedor, Nothing)
         .DescuentoRecargoPorc = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         .DescuentoRecargoProducto = descuentoRecargo

         .Precio = precio
         .PrecioDolar = precio / cotizacion

         .Cantidad = cantidad
         .CantidadManual = cantidadManual
         .CantidadOriginal = _cantidadOriginal
         .CantNoPendienteOriginal = _cantidadNoPendienteOriginal
         .Conversion = producto.Conversion

         .ImporteTotal = importeTotal
         .ImporteTotalDolar = importeTotal / cotizacion

         .Stock = stock

         .Costo = costo
         .CostoDolar = costo / cotizacion

         .PrecioLista = precioLista
         .Kilos = kilos

         .PrecioNeto = precioNeto
         .PrecioNetoDolar = precioNeto / cotizacion

         .AlicuotaImpuesto = porcentajeIva
         .ImporteImpuesto = importeIva
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .IdCriticidad = criticidad
         .FechaEntrega = fechaEntrega
         .IdListaPrecios = Integer.Parse(cmbListaDePrecios.SelectedValue.ToString())
         .NombreListaPrecios = Me.cmbListaDePrecios.Text
         .FechaActualizacion = fechaActualizacion
         .ImporteImpuestoInterno = ImpuestoInterno
         .PrecioVentaPorTamano = PrecioVentaPorTamano
         .Tamano = Tamano
         .IdUnidadDeMedida = IdUnidadDeMedida
         .Moneda = moneda
         .ModificoDescuentos = _DescuentosRecargosProd.DescuentoRecargo1 <> descuentoRecargoPorc1 OrElse _DescuentosRecargosProd.DescuentoRecargo2 <> descuentoRecargoPorc2

         .Espmm = espmm
         .EspPulgadas = espPulgadas
         .CodigoSAE = codigoSAE
         .ProduccionProceso = produccionProceso
         .ProduccionForma = produccionForma
         .LargoExtAlto = largoExtAlto
         .AnchoIntBase = anchoIntBase
         .Architrave = architrave
         .ProduccionModeloForma = modeloForma

         .PorcImpuestoInterno = porcImpuestoInterno
         .OrigenPorcImpInt = origenPorcImpInt

         .UrlPlano = urlPlano

         .IdFormula = idFormula
         .NombreFormula = nombreFormula

         .IdProcesoProductivo = idProcesoProductivo
         .CodigoProcesoProductivo = codigoProcesoProductivo
         .DescripcionProcesoProductivo = descripcionProcesoProductivo

         .TipoOperacion = GetTipoOperacionSeleccionada()
         .Nota = cmbNota.Text
         .Automatico = _cargandoProductosAutomaticamente

         If _ordenProducto > 0 Then
            .Orden = _ordenProducto
         ElseIf _ordenProducto = 0 Then
            .Orden = _pedidosProductos.MaxSecure(Function(x) x.Orden).IfNull() + 1
         End If

         .ModificoPrecioManualmente = modificoPrecioManualmente

      End With

   End Sub

   Private Sub CargarTotales(impuesto As Entidades.VentaImpuesto,
                           idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                           alicuota As Decimal,
                           bruto As Decimal,
                           neto As Decimal,
                           importeIva As Decimal,
                           total As Decimal)

      With impuesto
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .Alicuota = alicuota
         .Bruto = bruto
         .Neto = neto
         .Importe = importeIva
         .Total = total
      End With

   End Sub

   Private Sub InsertarProducto()

      Dim producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text)
      If producto.ImporteImpuestoInterno <> 0 Then
         Throw New Exception(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se puede agregar el producto al Pedido.", producto.IdProducto, producto.NombreProducto))
      End If

      '-- REQ-36879.- ----------------------------------------------------------------------------------------------------------
      '-- REQ-41959.- ----------------------------------------------------------------------------------------------------------
      If Reglas.Publicos.PedidosPresupuestosAgrupaProductos Then
         Dim drExistente = _pedidosProductos.FirstOrDefault(Function(vp) vp.IdProducto.Trim() = bscCodigoProducto2.Text.Trim())
         If drExistente IsNot Nothing Then
            Dim cantidadActual = txtCantidad.ValorNumericoPorDefecto(0D)
            txtCantidad.SetValor(cantidadActual + drExistente.Cantidad)
            txtCantidadManual.SetValor(cantidadActual + drExistente.Cantidad)
            _ordenProducto = drExistente.Orden
            _cantidadOriginal = drExistente.CantidadOriginal
            txtCantidadManual.Focus()
            btnInsertar.Focus()
            _pedidosProductos.Remove(drExistente)
            btnInsertar.PerformClick()
            Exit Sub
         End If
      End If
      '------------------------------------------------------------------------------------------------------------------------


      'Fuerzo los calculos porque pudo no pasar Insertar sin los tab en los campos de descuento.
      Me.CalcularDescuentosProductos()
      Me.CalcularTotalProducto()
      '------------------------------------------------------------------------------------------

      'cargo los valores de los controles a variables locales---------------------
      Dim oLineaDetalle As Entidades.PedidoProducto = New Entidades.PedidoProducto()
      Dim oLineaImpuestos As Entidades.VentaImpuesto = New Entidades.VentaImpuesto()

      Dim stock As Decimal = 0
      Dim precioCosto As Decimal = 0
      Dim precioLista As Decimal = 0
      Dim Kilos As Decimal = 0

      Dim importeBruto As Decimal = 0
      Dim importeNeto As Decimal = 0
      Dim importeIva As Decimal = 0
      Dim importeTotal As Decimal = 0

      Dim descRecPorc1 As Decimal = Decimal.Parse(Me.txtDescRecPorc1.Text)
      Dim descRecPorc2 As Decimal = Decimal.Parse(Me.txtDescRecPorc2.Text)
      Dim descRecargo As Decimal = Decimal.Parse(Me.txtDescRec.Text)

      If Me.txtStock.Text.Length <> 0 Then
         stock = Decimal.Parse(Me.txtStock.Text)
      End If

      Dim alicuotaIVA As Decimal
      Dim IdMoneda As Integer

      If bscCodigoProducto2.FilaDevuelta Is Nothing Then
         'If pnlCosto.Visible Then
         precioCosto = Decimal.Parse(txtCosto.Text)
         'Else
         '   precioCosto = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("PrecioCosto").Value.ToString())
         'End If
         'If _categoriaFiscalEmpresa.IvaDiscriminado And cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Then
         '   precioLista = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("PrecioVentaSinIVA").Value.ToString())
         'Else
         '   precioLista = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("PrecioVentaConIVA").Value.ToString())
         'End If
         'precioLista = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscProducto2.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      Else
         'If pnlCosto.Visible Then
         precioCosto = Decimal.Parse(txtCosto.Text)
         '   Else
         '   precioCosto = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("PrecioCosto").Value.ToString())
         'End If
         'If _categoriaFiscalEmpresa.IvaDiscriminado And cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Then
         '   precioLista = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("PrecioVentaSinIVA").Value.ToString())
         'Else
         '   precioLista = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("PrecioVentaConIVA").Value.ToString())
         'End If
         ''precioLista = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscCodigoProducto2.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      End If

      Dim filaDevuelta As DataGridViewRow
      If bscCodigoProducto2.FilaDevuelta Is Nothing Then
         filaDevuelta = bscProducto2.FilaDevuelta
      Else
         filaDevuelta = bscCodigoProducto2.FilaDevuelta
      End If

      precioLista = Decimal.Parse(filaDevuelta.Cells("PrecioVenta").Value.ToString())
      If Reglas.Publicos.PreciosConIVA Then
         '-- Le quito el IVA que el producto tiene en forma predeterminada.- --
         precioLista = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precioLista, producto)
      End If

      'Precio de Costo, Opciones: ACTUAL o PROMPOND;<meses>
      If Publicos.VentasPrecioCosto <> "ACTUAL" Then

         Dim CalculoCosto() As String = Publicos.VentasPrecioCosto.Split(";"c)

         Dim OtroPrecioCosto As Decimal = 0

         Select Case CalculoCosto(0).ToString()

            Case "PROMPOND"

               Dim oCP As Reglas.ComprasProductos = New Reglas.ComprasProductos()

               OtroPrecioCosto = oCP.GetCostoPromedioPonderado(actual.Sucursal.Id,
                                                               bscCodigoProducto2.Text,
                                                               Date.Today.AddMonths(Integer.Parse(CalculoCosto(1).ToString()) * (-1)),
                                                               Date.Today,
                                                               decimalesRedondeoEnPrecio:=2)

            Case Else
               Throw New Exception("ATENCION: el sistema tiene configurado el Tipo de COSTO '" & CalculoCosto(0).ToString() & "' (incorrecto), verifíquelo en Parametros.")

         End Select

         If OtroPrecioCosto <> 0 Then
            precioCosto = OtroPrecioCosto
         End If

      End If

      'If Publicos.PreciosConIVA Then
      '   'Le quito el IVA que el producto tiene en forma predeterminada.
      '   precioCosto = Decimal.Round(precioCosto / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
      '   precioLista = Decimal.Round(precioLista / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
      'End If

      '----------------------------------------------------

      If IdMoneda = 2 Then
         'precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      End If

      'Asigno el nuevo iva (puedo cambiar o no)
      alicuotaIVA = Decimal.Parse(Me.cmbPorcentajeIva.Text)

      'If Me.txtUM.Text <> "" Then
      '   Dim Conversion As Decimal
      '   Dim oUM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
      '   Conversion = oUM.GetUno(Me.txtUM.Text).ConversionAKilos
      '   Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * Decimal.Parse(Me.txtTamanio.Text) * Conversion, 3)
      'End If
      '--REQ-34970.- ---------------
      If txtUM.Text = "M2" Then
         Dim totalTamañoProducto = Decimal.Parse(txtTamanio.Text) * Decimal.Parse(txtCantidad.Text)
         txtTotalMetrosCuadrados.Text = (Decimal.Parse(txtTotalMetrosCuadrados.Text) + totalTamañoProducto).ToString()
      End If
      '-----------------------------
      Dim kilosProducto As Decimal = 0
      'If (Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible) And Reglas.Publicos.PedidosModificaDescripSolicitaKilos Then
      '   kilosProducto = Decimal.Parse(Me.txtKilosModDesc.Text.ToString())
      'Else
      '   If bscCodigoProducto2.FilaDevuelta Is Nothing Then
      '      kilosProducto = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("Kilos").Value.ToString())
      '   Else
      '      kilosProducto = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("Kilos").Value.ToString())
      '   End If
      'End If
      kilosProducto = Decimal.Parse(Me.txtKilosModDesc.Text.ToString())
      Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * kilosProducto, 3)


      Dim precioProductoSinIVA As Decimal = Decimal.Parse(Me.txtPrecio.Text.Trim())
      Dim precioProductoConIVA As Decimal = 0

      Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text)
      Dim cantidadManual As Decimal = CDec(Me.txtCantidadManual.Text)

      Dim descRecPorGeneral As Decimal = Decimal.Parse(Me.txtDescRecGralPorc.Text)

      Dim precioNeto As Decimal = 0

      Dim criticidad As String = Me.cmbCriticidad.SelectedValue().ToString()
      Dim fechaEntrega As Date = Me.dtpFechaEntregaProd.Value()

      Me._numeroOrden += 1

      Dim impuestoInterno As Decimal = Decimal.Round(Decimal.Parse(Me.txtImpuestoInterno.Text) * cantidad, _decimalesRedondeoEnPrecio)
      Me.CalculaValores(cantidad, alicuotaIVA, impuestoInterno, precioProductoSinIVA, descRecPorc1, descRecPorc2, descRecPorGeneral,
                        precioNeto, importeBruto, importeIva, importeTotal, producto)

      Dim precioVentaPorTamano As Decimal = 0
      If txtPrecioVentaPorTamano.Visible And Not txtPrecioVentaPorTamano.ReadOnly And txtPrecioVentaPorTamano.Enabled And IsNumeric(txtPrecioVentaPorTamano.Text) Then
         precioVentaPorTamano = Decimal.Parse(txtPrecioVentaPorTamano.Text)
      End If
      Dim tamano As Decimal = 0
      If IsNumeric(txtTamanio.Text) Then
         tamano = Decimal.Parse(txtTamanio.Text)
      End If
      Dim idUnidadMedida As String = Me.cmbUM2.SelectedValue.ToString()

      '# Moneda del producto
      'Dim moneda As Entidades.Moneda = DirectCast(cmbMoneda.SelectedItem, Entidades.Moneda)
      Dim moneda As Entidades.Moneda = New Reglas.Monedas().GetUna(IdMoneda)

      Dim espPulgadas As String = txtProductoEspPulgadas.Text
      Dim codigoSAE As String = txtProductoSAE.Text
      Dim produccionProceso As Entidades.ProduccionProceso = DirectCast(cmbProductoProduccionProceso.SelectedItem, Entidades.ProduccionProceso)
      Dim produccionForma As Entidades.ProduccionForma = DirectCast(cmbProductoProduccionForma.SelectedItem, Entidades.ProduccionForma)
      Dim idFormula As Integer = 0
      Dim nombreFormula As String = ""
      If cmbFormula.SelectedIndex > -1 AndAlso IsNumeric(cmbFormula.SelectedValue) Then
         idFormula = Integer.Parse(cmbFormula.SelectedValue.ToString())
         nombreFormula = cmbFormula.Text
      End If

      Dim idProcesoProductivo As Long = 0
      Dim codigoProcesoProductivo As String = String.Empty
      Dim descripcionProcesoProductivo As String = String.Empty
      If cmbProcesoProductivo.SelectedIndex > -1 Then
         Dim drPrPr = cmbProcesoProductivo.ItemSeleccionado(Of DataRow)
         idProcesoProductivo = drPrPr.Field(Of Long)("IdProcesoProductivo")
         codigoProcesoProductivo = drPrPr.Field(Of String)("CodigoProcesoProductivo")
         descripcionProcesoProductivo = drPrPr.Field(Of String)("DescripcionProceso")
      End If

      'Dim espmm As Decimal = 0
      'Dim largoExtAlto As Decimal = 0
      'Dim anchoIntBase As Decimal = 0

      'Decimal.TryParse(txtProductoEspmm.Text, espmm)
      'Decimal.TryParse(txtProductoLargoExtAlto.Text, largoExtAlto)
      'Decimal.TryParse(txtProductoAnchoIntBase.Text, anchoIntBase)

      Dim iidb As FacturacionV2.ImpIntDesdeBusquedas = FacturacionV2.GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)

      '# Verifico si el Precio del producto fue cambiado manualmente
      Dim precioListaModificoPrecios = precioLista
      If (Not cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado OrElse Not _categoriaFiscalEmpresa.IvaDiscriminado) And
          Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
           DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
         precioListaModificoPrecios = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precioListaModificoPrecios, producto)
      End If
      precioListaModificoPrecios = Math.Round(precioListaModificoPrecios, _decimalesAMostrarEnPrecio)
      Dim modificoPrecioManualmente As Boolean = False
      If Not precioListaModificoPrecios = precioProductoConIVA AndAlso Not precioListaModificoPrecios = precioProductoSinIVA Then
         modificoPrecioManualmente = True
      End If

      CargarUnArticulo(oLineaDetalle,
                       producto,
                       txtProductoObservacion.Text,
                       descRecPorc1,
                       descRecPorc2,
                       descRecargo,
                       precioProductoSinIVA,
                       cantidad,
                       cantidadManual,
                       importeTotal,
                       stock,
                       precioCosto,
                       precioLista,
                       Kilos,
                       _tipoImpuestoIVA,
                       alicuotaIVA,
                       importeIva,
                       precioNeto,
                       criticidad,
                       fechaEntrega,
                       dtpFechaActPrecios.Value,
                       impuestoInterno,
                       txtPorcImpuestoInterno.ValorNumericoPorDefecto(0D),
                       iidb.OrigenPorcImpInt,
                       precioVentaPorTamano,
                       tamano,
                       idUnidadMedida,
                       moneda,
                       txtProductoEspmm.ValorNumericoPorDefecto(0D), espPulgadas, codigoSAE, produccionProceso, produccionForma,
                       txtProductoLargoExtAlto.ValorNumericoPorDefecto(0D), txtProductoAnchoIntBase.ValorNumericoPorDefecto(0D),
                       txtProductoArchitrave.ValorNumericoPorDefecto(0D), cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma),
                       txtProductoUrlPlano.Text,
                       idFormula,
                       nombreFormula,
                       idProcesoProductivo, codigoProcesoProductivo, descripcionProcesoProductivo,
                       modificoPrecioManualmente)

      ''Selecciono los nros. de serie SOLO si el producto permite
      'If oLineaDetalle.Producto.NroSerie Then
      '   Dim nrosSerie As DataTable
      '   Dim onrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()

      '   nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal.Id, Me.bscCodigoProducto2.Text)
      '   Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidad.Text), 0).ToString())
      '   Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, oLineaDetalle.Producto, nrosSerie)
      '   If sel.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      '      MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie debe seleccionar los numeros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      btnInsertar.Select()
      '      Exit Sub
      '   Else
      '      For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
      '         oLineaDetalle.Producto.NrosSeries.Add(ns)
      '      Next
      '   End If
      'End If

      If oLineaDetalle.Orden = 0 Then
         oLineaDetalle.Orden = Me._numeroOrden
      End If

      Me._pedidosProductos.Add(oLineaDetalle)
      If _pedidosProductosFormulas.ContainsKey(oLineaDetalle) Then
         _pedidosProductosFormulas.Add(oLineaDetalle, _pedidosProductosFormulasActual)
      Else
         _pedidosProductosFormulas(oLineaDetalle) = _pedidosProductosFormulasActual
      End If
      _pedidosProductosFormulasActual = Nothing

      '-- REQ-
      If (Not cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado) Then
         oLineaDetalle.ImporteTotalConImpuestos = oLineaDetalle.ImporteTotal
      Else
         oLineaDetalle.ImporteTotalConImpuestos = (oLineaDetalle.ImporteTotal + (oLineaDetalle.ImporteTotal * (oLineaDetalle.AlicuotaImpuesto / 100)))
      End If


      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      'HabilitaComprobanteFactSegunLineas()
      SetProductosDataSource()

      'Me.OrdenarGrillaProductos()
      'Me.dgvProductos.Refresh()

      'Sin Facturables se para en la ultima fila, sino, primero.
      If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 Then
         Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
         Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
      Else
         Me.dgvProductos.FirstDisplayedScrollingRowIndex = 0
         Me.dgvProductos.Rows(0).Selected = True
      End If

      'importeBruto = precioProducto * cantidad
      importeNeto = precioNeto * cantidad

      'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
      If (Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) Then
         importeBruto = Decimal.Round((importeBruto - impuestoInterno) / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
         importeNeto = Decimal.Round((importeNeto - impuestoInterno) / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
      End If

      Me.CargarTotales(oLineaImpuestos,
                        Me._tipoImpuestoIVA,
                        alicuotaIVA,
                        importeBruto,
                        importeNeto,
                        importeIva,
                        importeNeto + importeIva)

      Dim entro As Boolean = False
      For Each vi As Entidades.VentaImpuesto In Me._subTotales
         If vi.Alicuota = alicuotaIVA And vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA Then
            vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA
            vi.Bruto += importeBruto      'precioProducto * cantidad
            vi.Neto += importeNeto   'importeTotal
            vi.Importe += importeIva
            vi.Total += (importeNeto + importeIva)
            entro = True
         End If
      Next

      If Not entro Then
         Me._subTotales.Add(oLineaImpuestos)
      End If

      If impuestoInterno <> 0 Then
         oLineaImpuestos = New Entidades.VentaImpuesto()
         Me.CargarTotales(oLineaImpuestos,
                          Entidades.TipoImpuesto.Tipos.IMINT,
                          0,
                          0,
                          0,
                          impuestoInterno,
                          impuestoInterno)

         entro = False
         For Each vi As Entidades.VentaImpuesto In Me._subTotales
            If vi.Alicuota = 0 And vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
               vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT
               vi.Bruto += 0
               vi.Neto += 0
               vi.Importe += impuestoInterno
               vi.Total += impuestoInterno
               entro = True
            End If
         Next

         If Not entro Then
            Me._subTotales.Add(oLineaImpuestos)
         End If
      End If

      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      'Me.CalcularTotalProducto()
      Me.LimpiarCamposProductos()

      _cargandoProductosAutomaticamente = False
      Me.CalcularTotales()
      Me.CalcularDatosDetalle()
      'Me.CalcularTotales()
      PintarProductosStockNegativo()
      Me.tsbGrabar.Enabled = True
      Me.bscCodigoProducto2.Focus()

   End Sub

   Private Sub CalculaValores(cantidad As Decimal,
                              alicuotaIVA As Decimal,
                              ByRef impuestoInterno As Decimal,
                              ByRef precioProducto As Decimal,
                              descRecPorc1 As Decimal,
                              descRecPorc2 As Decimal,
                              descRecPorGeneral As Decimal,
                              ByRef precioNeto As Decimal,
                              ByRef importeBruto As Decimal,
                              ByRef importeIVA As Decimal,
                              ByRef importeTotalProducto As Decimal,
                              prod As Entidades.Producto)

      Dim alicuotaIVASobre100 As Decimal = (alicuotaIVA / 100)

      Dim precioParaDescuento As Decimal = precioProducto
      'Se anula esta lógica porque no se permite más facturación con ImpInt fijos.
      'If Not cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
      '   If DirectCast(Me.cmbTiposComprobantesFact.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
      '      DirectCast(Me.cmbTiposComprobantesFact.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
      '      Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
      '      precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
      '   Else
      '      precioParaDescuento = precioProducto
      '   End If
      '   ''precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
      'Else
      '   precioParaDescuento = precioProducto
      'End If

      _descRecPorc1 = descRecPorc1
      _descRecPorc2 = descRecPorc2

      _descRec1 = Decimal.Round(precioParaDescuento * descRecPorc1 / 100, Me._decimalesRedondeoEnPrecio)
      _descRec2 = Decimal.Round((precioParaDescuento + _descRec1) * descRecPorc2 / 100, Me._decimalesRedondeoEnPrecio)
      Dim descRec As Decimal = Decimal.Round((precioParaDescuento + _descRec1 + _descRec2) * descRecPorGeneral / 100, Me._decimalesRedondeoEnPrecio)

      precioNeto = precioProducto + _descRec1 + _descRec2 + descRec

      importeBruto = (precioProducto + _descRec1 + _descRec2) * cantidad

      'Lo calcula despues
      'importeTotalProducto = precioNeto * cantidad
      '------------------------------------
      'En Pantalla debe mostrar el total bruto (sin aplicar el descuento General)
      importeTotalProducto = importeBruto

      If Not cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoConIVA(precioNeto, alicuotaIVA, prod.PorcImpuestoInterno, prod.ImporteImpuestoInterno, prod.OrigenPorcImpInt) * cantidad
         Dim tmpImpInt = impuestoInterno '((impuestoInterno - (prod.ImporteImpuestoInterno * cantidad)) * (1 + (descRecPorGeneral / 100))) + prod.ImporteImpuestoInterno * cantidad
         importeIVA = Decimal.Round(((precioNeto * cantidad) - tmpImpInt) - ((precioNeto * cantidad) - tmpImpInt) / (1 + alicuotaIVASobre100), Me._decimalesRedondeoEnPrecio)
      Else
         impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA, prod.PorcImpuestoInterno, prod.ImporteImpuestoInterno, prod.OrigenPorcImpInt) * cantidad
         importeIVA = Decimal.Round((precioNeto * cantidad) * alicuotaIVASobre100, Me._decimalesRedondeoEnPrecio)
      End If

   End Sub


   Private Sub EliminarLineaProducto(soloBorrar As Boolean)
      'dgvProductos.FilaSeleccionada(Of Entidades.PedidoProducto)()
      Dim dr = dgvProductos.FilaSeleccionada(Of Entidades.PedidoProducto)()
      If dr IsNot Nothing Then
         If soloBorrar And Not _esCopia Then
            Dim r = New Reglas.PedidosProductos()
            r.PuedeBorrarPedidoProducto(dr)
         End If
         EliminarLineaProducto(dr) '_pedidosProductos(dgvProductos.SelectedRows(0).Index))
         PintarProductosStockNegativo()
      End If
   End Sub


   Private Sub EliminarLineaProducto(vpro As Entidades.PedidoProducto)

      Dim producto As Entidades.Producto = vpro.Producto

      If _pedidosProductosFormulas.ContainsKey(vpro) Then
         _pedidosProductosFormulas.Remove(vpro)
      End If

      Me._pedidosProductos.Remove(vpro)
      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      'HabilitaComprobanteFactSegunLineas()
      SetProductosDataSource()
      'Me.OrdenarGrillaProductos()

      Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
      If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
         Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

         For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
            If vp.Producto.IdRubro = producto.IdRubro Then
               cantidad = vp.Cantidad
            End If
         Next
         Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, producto, cantidad, Me._decimalesEnTotales)
         For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
            If vp.Producto.IdRubro = producto.IdRubro Then
               vp.DescuentoRecargoPorc = _DescuentosRecargosProd.DescuentoRecargo1
               If calculaDescuentoRecargo2 Then
                  vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
               End If
            End If
            vp.DescuentoRecargoProducto = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                                     vp.DescuentoRecargoPorc, vp.DescuentoRecargoPorc2, vp.Cantidad)
         Next
      End If

      If Me.dgvProductos.Rows.Count > 0 Then

         'Sin Facturables se para en la ultima fila, sino, primero.
         If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 Then
            Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
         Else
            Me.dgvProductos.FirstDisplayedScrollingRowIndex = 0
            Me.dgvProductos.Rows(0).Selected = True
         End If

      End If

      Me.CalcularDatosDetalle()
      Me.RecalcularSubtotales()
      Me.CalcularTotales()
      '--REQ-34970.- ---------------
      If vpro.IdUnidadDeMedida = "M2" Then
         Dim totalTamañoProducto = vpro.Tamano * vpro.CantidadManual
         txtTotalMetrosCuadrados.Text = (Decimal.Parse(txtTotalMetrosCuadrados.Text) - totalTamañoProducto).ToString()
      End If
      '-----------------------------
   End Sub

   Private Sub SetOrdenGrilla(column As DataGridViewColumn, ByRef orden As Integer)
      column.DisplayIndex = orden
      orden += 1
   End Sub

   Private Sub OrdenarGrillaProductos()
      Dim MuestraPesos = (Reglas.Publicos.PedidosVisualizaPrecioEnDolares = Reglas.Publicos.FormatoVisualizaPrecioDolares.PESOS.ToString() Or Reglas.Publicos.PedidosVisualizaPrecioEnDolares = Reglas.Publicos.FormatoVisualizaPrecioDolares.AMBOS.ToString())
      Dim MuestraDolar = (Reglas.Publicos.PedidosVisualizaPrecioEnDolares = Reglas.Publicos.FormatoVisualizaPrecioDolares.DOLARES.ToString() Or Reglas.Publicos.PedidosVisualizaPrecioEnDolares = Reglas.Publicos.FormatoVisualizaPrecioDolares.AMBOS.ToString())


      Dim canti As Integer = 0
      With Me.dgvProductos
         Me.SetOrdenGrilla(.Columns("NrosSerie"), canti)
         Me.SetOrdenGrilla(.Columns("IdProducto"), canti)
         Me.SetOrdenGrilla(.Columns("ProductoDesc"), canti)

         If Reglas.Publicos.PedidosMuestraProvHabitual Then
            .Columns("CodigoProductoProveedor").Visible = True
            Me.SetOrdenGrilla(.Columns("CodigoProductoProveedor"), canti)
         End If

         Me.SetOrdenGrilla(.Columns("Precio"), canti)
         Me.SetOrdenGrilla(.Columns("PrecioDolar"), canti)

         Me.SetOrdenGrilla(.Columns("Cantidad"), canti)
         Me.SetOrdenGrilla(.Columns("CantidadManual"), canti)
         Me.SetOrdenGrilla(.Columns("Conversion"), canti)
         Me.SetOrdenGrilla(.Columns("Stock"), canti)
         Me.SetOrdenGrilla(.Columns("PrecioIVA"), canti)
         Me.SetOrdenGrilla(.Columns("DescuentoRecargoPorc"), canti)
         Me.SetOrdenGrilla(.Columns("DescuentoRecargoPorc2"), canti)

         Me.SetOrdenGrilla(.Columns("PrecioNeto"), 13)
         Me.SetOrdenGrilla(.Columns("PrecioNetoDolar"), 14)

         Me.SetOrdenGrilla(.Columns("IdTipoImpuesto"), canti)
         Me.SetOrdenGrilla(.Columns("AlicuotaImpuesto"), canti)
         Me.SetOrdenGrilla(.Columns("ImporteImpuesto"), canti)

         Me.SetOrdenGrilla(.Columns("Importe"), 18)
         Me.SetOrdenGrilla(.Columns("ImporteIVA"), 19)
         Me.SetOrdenGrilla(.Columns("ImporteDolar"), 20)
         Me.SetOrdenGrilla(.Columns("Costo"), 21)
         Me.SetOrdenGrilla(.Columns("CostoDolar"), 22)


         If Me._clienteE IsNot Nothing AndAlso
                                                ((Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
            Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos) Then
            .Columns("PrecioIVA").Visible = False
         Else
            .Columns("PrecioIVA").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarPrecioConIVA
         End If

         .Columns("DescuentoRecargoPorc").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarDesc1
         .Columns("DescuentoRecargoPorc2").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarDesc2
         .Columns("Kilos").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarKilos
         .Columns("Stock").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarStock

         .Columns("Precio").Visible = MuestraPesos
         .Columns("PrecioDolar").Visible = MuestraDolar
         .Columns("PrecioNeto").Visible = MuestraPesos
         .Columns("PrecioNetoDolar").Visible = MuestraDolar
         .Columns("Importe").Visible = MuestraPesos

         .Columns("ImporteIVA").Visible = Reglas.Publicos.DetallePedido.PedidosMostrarPrecioMasIva

         .Columns("ImporteDolar").Visible = MuestraDolar
         .Columns("Costo").Visible = MuestraPesos
         .Columns("CostoDolar").Visible = MuestraDolar

         .Columns("PrecioNeto").Visible = (Reglas.Publicos.Facturacion.FacturacionMostrarPrecioUnitario AndAlso MuestraPesos)
         .Columns("PrecioNetoDolar").Visible = (Reglas.Publicos.Facturacion.FacturacionMostrarPrecioUnitario AndAlso MuestraDolar)
      End With
   End Sub

   Private Sub OrdenarSolapas()

      'TODO: NINGUNO FUNCIONO !!

      Dim Posicion As Integer = -1

      If Me.tbcDetalle.TabPages.Contains(Me.tbpProductos) Then
         Posicion += 1
         Me.tbcDetalle.TabPages("tbpProductos").TabIndex = Posicion
         'Me.tbcDetalle.TabPages(Posicion) = me.tbpProductos
         'Me.tbcDetalle.TabPages.Item(Posicion) = Me.tbpProductos
      End If

      'If Me.tbcDetalle.TabPages.Contains(Me.tbpRemitoTransp) Then
      '    Posicion += 1
      '    Me.tbcDetalle.TabPages("tbpRemitoTransp").TabIndex = Posicion
      'End If

      'If Me.tbcDetalle.TabPages.Contains(Me.tbpFacturables) Then
      '    Posicion += 1
      '    Me.tbcDetalle.TabPages("tbpFacturables").TabIndex = Posicion
      'End If

      'If Me.tbcDetalle.TabPages.Contains(Me.tbpCheques) Then
      '    Posicion += 1
      '    Me.tbcDetalle.TabPages("tbpCheques").TabIndex = Posicion
      'End If

      'If Me.tbcDetalle.TabPages.Contains(Me.tbpObservaciones) Then
      '    Posicion += 1
      '    Me.tbcDetalle.TabPages("tbpObservaciones").TabIndex = Posicion
      'End If

      'If Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
      '    Posicion += 1
      '    Me.tbcDetalle.TabPages("tbpPagos").TabIndex = Posicion
      'End If

      If Me.tbcDetalle.TabPages.Contains(Me.tbpTotales) Then
         Posicion += 1
         Me.tbcDetalle.TabPages("tbpTotales").TabIndex = Posicion
      End If

   End Sub

   Private Sub SoloLecturaPrecios(soloLectura As Boolean)
      txtPrecio.ReadOnly = soloLectura
      txtPrecioVentaPorTamano.ReadOnly = soloLectura
   End Sub

   Private Sub HabilidaPrecios(Habilitado As Boolean)
      If _solicitaPrecioVentaPorTamano Then
         Me.txtPrecio.Enabled = False
         txtPrecioVentaPorTamano.Enabled = Habilitado
      Else
         Me.txtPrecio.Enabled = Habilitado
         txtPrecioVentaPorTamano.Enabled = False
      End If
   End Sub

   Private Sub FocusPrecio()
      If _solicitaPrecioVentaPorTamano Then
         If Me.txtPrecioVentaPorTamano.ReadOnly = True Then

            If Me.chbModificaDescRecargo.Checked Then
               Me.txtDescRecPorc1.Focus()
               Me.txtDescRecPorc1.SelectAll()
               RecalculaPrecioDesdePrecioPorTamano()
            Else
               If cmbNota.Enabled AndAlso cmbNota.Visible Then
                  cmbNota.Focus()
               Else
                  btnInsertar.Select()
               End If
            End If
         Else
            txtPrecioVentaPorTamano.Focus()
            txtPrecioVentaPorTamano.SelectAll()
         End If
      Else
         Me.txtPrecio.Focus()
         Me.txtPrecio.SelectAll()
      End If
   End Sub

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)

      btnLimpiarProducto.Enabled = Habilitado

      bscCodigoProducto2.Enabled = Habilitado
      bscProducto2.Enabled = Habilitado
      cmbTipoOperacion.Enabled = Habilitado
      txtCantidadManual.Enabled = Habilitado
      HabilidaPrecios(Habilitado)
      txtDescRecPorc1.Enabled = Habilitado
      txtDescRecPorc2.Enabled = Habilitado
      cmbPorcentajeIva.Enabled = Habilitado

      txtProductoUrlPlano.Enabled = Habilitado
      txtProductoAnchoIntBase.Enabled = Habilitado
      txtProductoLargoExtAlto.Enabled = Habilitado
      txtProductoArchitrave.Enabled = Habilitado
      cmbProductoProduccionModeloForma.Enabled = Habilitado

      cmbFormula.Enabled = Habilitado
      cmbProcesoProductivo.Enabled = Habilitado
      btnEditarFormula.Enabled = cmbFormula.Enabled

      btnInsertar.Enabled = Habilitado
      btnEliminar.Enabled = Habilitado
      cmbCriticidad.Enabled = Habilitado
      dtpFechaEntregaProd.Enabled = Habilitado

      'Por las que le toque habilitar, es factible que no corresponda
      If Habilitado Then
         cmbPorcentajeIva.Enabled = Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos
      End If

      'If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
      '    If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
      '        Me.cmbPorcentajeIva.Enabled = False
      '    End If
      'End If

   End Sub

   'Private Sub PresionarTab(e As KeyEventArgs)
   '   If e.KeyCode = Keys.Enter Then
   '      Me.ProcessTabKey(True)
   '   End If
   'End Sub

   Private Function GetVendedorCombo(Id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If Id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub RecalcularTodo(recuperaCosto As Boolean, desdeListaPrecios As Boolean)

      Try
         If Me._pedidosProductos IsNot Nothing Then

            'Dim oProductos As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            'Dim pro1 As Entidades.ProductoSucursal

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Dim ProdDT As DataTable

            Dim DescRec1 As Decimal, DescRec2 As Decimal
            Dim PrecioNeto As Decimal

            For Each pro As Entidades.PedidoProducto In Me._pedidosProductos

               ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")

               If ProdDT.Rows.Count = 0 Then
                  Throw New Exception(String.Format("El producto con código '{0}' no existe o está inactivo. Por favor verifique y vuelva a realizar la acción deseada.", pro.Producto.IdProducto))
               End If

               Dim embalaje As Integer = 1
               If Boolean.Parse(ProdDT.Rows(0)("PrecioPorEmbalaje").ToString()) Then
                  embalaje = Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString())
               End If

               'Reemplazada la condición por la que posee FacturacionV2
               'If Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
               If (Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                     Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                     DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
                  If Not pro.ModificoPrecioManualmente Then
                     pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()) / embalaje
                  End If
               Else
                  If Not pro.ModificoPrecioManualmente Then
                     pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()) / embalaje
                  End If
               End If

               If Not pro.ModificoPrecioManualmente AndAlso pro.Producto.Moneda.IdMoneda = 2 Then
                  Dim cotizacion As Decimal = 1
                  Decimal.TryParse(txtCotizacionDolar.Text, cotizacion)
                  pro.Precio = pro.Precio * cotizacion
               End If

               If recuperaCosto Then
                  Dim PrecioCostoSinIVA As Decimal
                  Dim PrecioCostoConIVA As Decimal
                  'Dim PrecioCosto As Decimal

                  If Reglas.Publicos.PreciosConIVA Then
                     'PrecioCostoConIVA = Decimal.Parse(ProdDT.Rows(0)("PrecioCosto").ToString())
                     PrecioCostoSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioCostoConIVA, pro.Producto.Alicuota, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.Producto.OrigenPorcImpInt)
                  Else
                     'PrecioCostoSinIVA = Decimal.Parse(ProdDT.Rows(0)("PrecioCosto").ToString())
                     PrecioCostoConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioCostoSinIVA, pro.Producto.Alicuota, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.Producto.OrigenPorcImpInt)
                  End If

                  PrecioCostoConIVA = PrecioCostoConIVA / embalaje
                  PrecioCostoSinIVA = PrecioCostoSinIVA / embalaje

                  If Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                     pro.Costo = PrecioCostoSinIVA
                  Else
                     pro.Costo = PrecioCostoConIVA
                  End If
               End If

               If pro.Producto.SolicitaPrecioVentaPorTamano Then
                  Dim idMoneda As Integer = Reglas.Publicos.DetallePedido.PedidosMonedaPrecioVentaPorTamano
                  If idMoneda = 0 Then
                     idMoneda = pro.IdMoneda
                  End If

                  Dim cotizacion As Decimal = 0
                  If idMoneda = 1 Then
                     cotizacion = 1
                  ElseIf idMoneda = 2 Then
                     Decimal.TryParse(txtCotizacionDolar.Text, cotizacion)
                  End If
                  pro.Precio = CalculaPrecioDesdePrecioPorTamano(pro.PrecioVentaPorTamano, pro.Tamano, cotizacion)
               End If

               'Calculo el Nuevo Descuento/Recargo
               DescRec1 = Decimal.Round((pro.Precio * pro.DescuentoRecargoPorc / 100), Me._decimalesRedondeoEnPrecio)
               DescRec2 = Decimal.Round(((pro.Precio + DescRec1) * pro.DescuentoRecargoPorc2 / 100), Me._decimalesRedondeoEnPrecio)

               pro.DescuentoRecargoProducto = (DescRec1 + DescRec2) * pro.Cantidad

               'Calculo el Nuevo Precio Neto
               PrecioNeto = pro.Precio + DescRec1 + DescRec2
               PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), Me._decimalesRedondeoEnPrecio)

               pro.PrecioNeto = PrecioNeto

               pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargoProducto

               If desdeListaPrecios Then
                  Dim lp = cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios)()
                  pro.IdListaPrecios = lp.IdListaPrecios
                  pro.NombreListaPrecios = lp.NombreListaPrecios
               End If

            Next

            SetProductosDataSource()
            'Me.dgvProductos.DataSource = _pedidosProductos.ToArray()
            'AjustarColumnasGrilla(dgvProductos, _titProductos)

            If Me.dgvProductos.Rows.Count > 0 Then
               Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            End If

            Me.dgvProductos.Refresh()
            Me.CalcularTotalProducto()

            Me.LimpiarCamposProductos()

            Me.CalcularTotales()
            Me.CalcularDatosDetalle()
            ' Me.CalcularTotales()

            Me.tsbGrabar.Enabled = True
            Me.bscCodigoProducto2.Focus()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub CargarProximoNumero()


      '############### ver cargar proximo ID

      If PedidoAEditar Is Nothing Or _esCopia Then
         If Me.txtLetra.Text <> "" Then

            Dim oImpresora As Entidades.Impresora
            Dim oVentasNumeros As New Reglas.VentasNumeros
            Dim CentroEmisor As Short

            'CentroEmisor = oImpresoras.GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal()).CentroEmisor

            oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

            CentroEmisor = oImpresora.CentroEmisor

            Me.txtNumeroPosible.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal,
                                                                 DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                                 Me.txtLetra.Text,
                                                                 CentroEmisor).ToString()
            Me.txtNumeroPosible.Tag = oImpresora.Marca

         Else

            Me.txtNumeroPosible.Text = ""
            Me.txtNumeroPosible.Tag = ""

         End If
      Else
         Me.txtNumeroPosible.Text = PedidoAEditar.NumeroPedido.ToString()
      End If

      Me.CargarLineasPermitidas()

      Me.OrdenarGrillaProductos()

      Me.OrdenarSolapas()

   End Sub

   Private Sub CargarLineasPermitidas()

      Dim oComprobanteLetra As Entidades.TipoComprobanteLetra
      oComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno("PEDIDO", "X")

      'Toma las Lineas del reporte especifico.
      If oComprobanteLetra.TipoComprobante.IdTipoComprobante <> "" Then

         Me._cantMaxItems = oComprobanteLetra.CantidadItemsProductos
         Me._cantMaxItemsObserv = oComprobanteLetra.CantidadItemsObservaciones
         Me._imprime = oComprobanteLetra.Imprime

         'Toma las Lineas del Comprobante.
      Else
         Me._cantMaxItems = 0
         Me._cantMaxItemsObserv = 0
         Me._imprime = False

         '    Me._cantMaxItems = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItems
         '    Me._cantMaxItemsObserv = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItemsObserv
         '   Me._imprime = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime

      End If

      'Else

      '    Me._cantMaxItems = 0
      '    Me._cantMaxItemsObserv = 0
      '    Me._imprime = False

      'End If


   End Sub

   Private Sub RecalcularSubtotales()

      Me._subTotales.Clear()
      Dim olineaTotales As Entidades.VentaImpuesto
      Dim entro As Boolean = False

      Dim descRec1 As Decimal = 0
      Dim descRec2 As Decimal = 0
      Dim importeCosto As Decimal = 0
      Dim importeBruto As Decimal = 0
      Dim importeNeto As Decimal = 0
      Dim importeNetoTotal As Decimal = 0
      Dim importeCostoTotal As Decimal = 0
      Dim Utilidad As Decimal = 0
      Dim impuestoInterno As Decimal = 0

      For Each dr As Entidades.PedidoProducto In Me._pedidosProductos

         impuestoInterno = dr.ImporteImpuestoInterno

         Dim precioParaDescuento As Decimal = dr.Precio
         'Se anula esta lógica porque no se permite más facturación con ImpInt fijos.
         'If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
         '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
         '      Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
         '      precioParaDescuento = dr.Precio - (impuestoInterno / dr.Cantidad)
         '   Else
         '      precioParaDescuento = dr.Precio
         '   End If
         'Else
         '   precioParaDescuento = dr.Precio
         'End If

         descRec1 = Decimal.Round(precioParaDescuento * dr.DescuentoRecargoPorc / 100, Me._decimalesRedondeoEnPrecio)
         descRec2 = Decimal.Round((precioParaDescuento + descRec1) * dr.DescuentoRecargoPorc2 / 100, Me._decimalesRedondeoEnPrecio)

         importeCosto = dr.Costo * dr.Cantidad
         importeBruto = (dr.Precio + descRec1 + descRec2) * dr.Cantidad
         importeNeto = dr.PrecioNeto * dr.Cantidad
         'impuestoInterno = Decimal.Round(dr.Producto.ImporteImpuestoInterno + ((impuestoInterno - dr.Producto.ImporteImpuestoInterno) * (1 + (txtDescRecGralPorc.Text.ValorNumericoPorDefecto(0D) / 100))), Me._decimalesRedondeoEnPrecio)

         If Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            'importeBruto = Decimal.Round((importeBruto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
            importeBruto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(importeBruto, dr.AlicuotaImpuesto, dr.PorcImpuestoInterno, dr.Producto.ImporteImpuestoInterno * dr.Cantidad, dr.OrigenPorcImpInt),
                                         Me._decimalesRedondeoEnPrecio)
            importeNeto = Decimal.Round((importeNeto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
            'importeCosto = Decimal.Round((importeCosto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
            importeCosto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(importeCosto, dr.AlicuotaImpuesto, dr.PorcImpuestoInterno, dr.Producto.ImporteImpuestoInterno * dr.Cantidad, dr.OrigenPorcImpInt),
                                         Me._decimalesRedondeoEnPrecio)
         End If

         dr.Utilidad = importeNeto - importeCosto
         If importeCosto <> 0 Then
            dr.ContribucionMarginalPorc = Decimal.Round(dr.Utilidad / importeCosto * 100, _decimalesRedondeoEnPrecio)
         End If

         Utilidad += dr.Utilidad
         importeNetoTotal += importeNeto
         importeCostoTotal += importeCosto

         entro = False

         For Each vi As Entidades.VentaImpuesto In Me._subTotales
            If vi.Alicuota = dr.AlicuotaImpuesto Then
               vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA

               vi.Bruto += importeBruto
               vi.Neto += importeNeto

               vi.Importe += dr.ImporteImpuesto
               vi.Total += (importeNeto + dr.ImporteImpuesto)
               entro = True
            End If
         Next
         If Not entro Then

            olineaTotales = New Entidades.VentaImpuesto()

            Me.CargarTotales(olineaTotales,
                  Me._tipoImpuestoIVA,
               dr.AlicuotaImpuesto,
               importeBruto,
               importeNeto,
               dr.ImporteImpuesto,
               importeNeto + dr.ImporteImpuesto)

            Me._subTotales.Add(olineaTotales)
         End If

         If impuestoInterno <> 0 Then
            entro = False
            For Each vi As Entidades.VentaImpuesto In Me._subTotales
               If vi.Alicuota = 0 And vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
                  vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT

                  vi.Bruto += 0
                  vi.Neto += 0

                  vi.Importe += impuestoInterno
                  vi.Total += impuestoInterno
                  entro = True
               End If
            Next
            If Not entro Then

               olineaTotales = New Entidades.VentaImpuesto()

               Me.CargarTotales(olineaTotales,
                     Entidades.TipoImpuesto.Tipos.IMINT,
                     0,
                     0,
                     0,
                     impuestoInterno,
                     impuestoInterno)

               Me._subTotales.Add(olineaTotales)
            End If
         End If

      Next

      Me.dgvIvas.DataSource = Me._subTotales.ToArray()


      txtRentabilidad.Text = Utilidad.ToString("N2")

      Dim PorcentajeUtilidad As Decimal
      If Reglas.Publicos.Facturacion.FacturacionSemaforoCalculoMuestra = Entidades.Publicos.SemaforoCalculoMuestra.Rentabilidad.ToString() Then
         If importeNetoTotal <> 0 Then
            PorcentajeUtilidad = Decimal.Round(Utilidad / importeNetoTotal * 100, Me._decimalesRedondeoEnPrecio)
         End If
      Else
         If importeCostoTotal <> 0 Then
            PorcentajeUtilidad = Decimal.Round(Utilidad / importeCostoTotal * 100, Me._decimalesRedondeoEnPrecio)
         End If
      End If
      If PorcentajeUtilidad <> 0 Then
         Me.txtSemaforoRentabilidad.Text = PorcentajeUtilidad.ToString("N" + _decimalesAMostrarEnTotalXProducto.ToString())
         'Dim colo As Color = System.Drawing.Color.FromArgb(New Reglas.SemaforoVentasUtilidades().ColorSemaforo(PorcentajeUtilidad, Entidades.SemaforoVentaUtilidad.TiposSemaforos.RENTABILIDAD))

         'Me.txtSemaforoRentabilidad.BackColor = colo

         'If colo.ToArgb() = Color.Black.ToArgb() Then
         '   Me.txtSemaforoRentabilidad.ForeColor = Color.White
         'Else
         '   Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
         'End If

         '# Semaforo de RENTABILIDAD
         Me.SetearColorSemaforos(txtSemaforoRentabilidad, IdTipoSemaforo:=Entidades.SemaforoVentaUtilidad.TiposSemaforos.RENTABILIDAD)

         Me.txtSemaforoRentabilidad.Key = Utilidad.ToString()

      Else

         Me.txtSemaforoRentabilidad.Text = ""
         Me.txtSemaforoRentabilidad.BackColor = Me.txtLetra.BackColor
         Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
         Me.txtSemaforoRentabilidad.Key = "0"

      End If

   End Sub


   Private Function ProductosConLote() As Integer
      Dim Cantidad As Integer = 0
      For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
         If vp.Producto.Lote Then
            Cantidad += 1
         End If
      Next
      Return Cantidad
   End Function

   Private Sub SetProductosDataSource()
      dgvProductos.DataSource = _pedidosProductos.ToArray().OrderBy(Function(x) x.Orden).ToArray()
      AjustarColumnasGrilla(dgvProductos, _titProductos)
      OrdenarGrillaProductos()
      HabilitaComprobanteFactSegunLineas()
   End Sub

   Private Sub LimpiarDetalle()

      Me._pedidosProductos = Nothing
      Me._pedidosProductos = New List(Of Entidades.PedidoProducto)
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      'HabilitaComprobanteFactSegunLineas()

      _pedidosContactos = New List(Of Entidades.ClienteContacto)()

      ugContactos.DataSource = _pedidosContactos
      AjustarColumnasGrilla(ugContactos, _titContactos)

      '  Me.dgvRemitoTransp.DataSource = Me._ventasProductos.ToArray()

      Me.OrdenarGrillaProductos()

      Me._subTotales = Nothing
      Me._subTotales = New List(Of Entidades.VentaImpuesto)
      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      Me._comprobantesSeleccionados = Nothing
      Me._comprobantesSeleccionados = New List(Of Entidades.Venta)

      ' Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados

      'Pone todo en cero.
      Me.CalcularTotales()

   End Sub

   'Private Sub CalcularTotalRemitoTransporte()

   '    Dim Total As Decimal = 0

   '    If Me.dgvFacturables.RowCount = 0 Then
   '        'Cuando es cargado manaualmente el ImporteTotal esta neto y el ImporteImpuesto en cero.
   '        For Each vp As Entidades.VentaProducto In Me._ventasProductos
   '            Total += vp.ImporteTotal
   '        Next
   '    Else
   '        For Each vi As Entidades.VentaImpuesto In Me._subTotales
   '            Total += vi.Neto
   '        Next
   '    End If

   '    Me.txtValorDeclarado.Text = Total.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
   '    'Me.txtBruto.Text = txtValorDeclarado.Text
   '    'Me.txtSubTotal.Text = txtValorDeclarado.Text
   '    Me.txtTotalGeneral.Text = txtValorDeclarado.Text
   '    Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)

   'End Sub

   Private Function GetValoresForma(dr As Entidades.PedidoProducto, incluyaForma As Boolean) As Entidades.ProduccionFormasVariablesList
      Return GetValoresForma(dr.Espmm,
                             dr.LargoExtAlto,
                             dr.AnchoIntBase,
                             dr.Architrave,
                             If(incluyaForma, dr.ProduccionModeloForma, Nothing))
   End Function

   Private Function GetValoresForma(forma As Entidades.ProduccionModeloForma) As Entidades.ProduccionFormasVariablesList
      Return GetValoresForma(txtProductoEspmm.ValorNumericoPorDefecto(0D),
                             txtProductoLargoExtAlto.ValorNumericoPorDefecto(0D),
                             txtProductoAnchoIntBase.ValorNumericoPorDefecto(0D),
                             txtProductoArchitrave.ValorNumericoPorDefecto(0D),
                             forma)
   End Function
   Private Function GetValoresForma(espmm As Decimal, largoExtAlto As Decimal, anchoIntBase As Decimal, architrave As Decimal,
                                    forma As Entidades.ProduccionModeloForma) As Entidades.ProduccionFormasVariablesList
      Return Reglas.ProduccionFormas.GetValoresForma(espmm, largoExtAlto, anchoIntBase, architrave, forma)
   End Function
   Private Sub SolicitarFormula(idFormula As Integer, idListaDePrecios As Integer)
      If cmbFormula.SelectedIndex > -1 Then
         If _solicitaModificarFormulaLuegoDelProducto Then
            'MD-PROD: Cambiar la apertura de la pantalla de edición de formula por la nueva que use la colección de ProductosArbol.
            '         También definir la conversión de ProductoArbol a PedidoProductoFormula.
            '   Using frm As New FormulasABM()
            '      If frm.ShowDialog(bscCodigoProducto2.Text, Integer.Parse(cmbFormula.SelectedValue.ToString()), _pedidosProductosFormulasActual) = Windows.Forms.DialogResult.OK Then
            '         _pedidosProductosFormulasActual = frm.Componentes.Copy()
            '      End If
            '   End Using
         Else
            Dim forma = cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma)
            Dim _valoresFormulas = GetValoresForma(forma)
            Dim rEstructuraProducto = New Reglas.EstructuraProductos()
            _pedidosProductosFormulasActual = rEstructuraProducto.CreaEstructura(bscCodigoProducto2.Text, idFormula, idListaDePrecios, txtCantidad.ValorNumericoPorDefecto(0D),
                                                                                 muestraPrecio:=True, _valoresFormulas, moneda:=Entidades.Moneda.Peso,
                                                                                 txtCotizacionDolar.ValorNumericoPorDefecto(0D)).FirstOrDefault()
         End If
      End If
   End Sub

#End Region

   Private Sub MostrarPedidoEditable()
      '-- REQ-31647.- --
      If (cmbTiposComprobantes.FindStringExact(PedidoAEditar.IdTipoComprobante) <> -1) Then
         cmbTiposComprobantes.SelectedValue = PedidoAEditar.IdTipoComprobante
      End If
      '-----------------
      cmbMonedaVenta.SelectedValue = PedidoAEditar.IdMoneda

      '-- REQ-30529.- -------------------------------------------
      If PedidoAEditar.IdCaja Is Nothing Then
         chbCajaPedido.Checked = True
         cmbCajaPedido.SelectedIndex = -1
      Else
         chbCajaPedido.Checked = True
         cmbCajaPedido.SelectedValue = PedidoAEditar.Caja.IdCaja
      End If
      cmbCajaPedido.Enabled = chbCajaPedido.Checked
      '----------------------------------------------------------

      txtLetra.Text = PedidoAEditar.LetraComprobante
      If Not _esCopia Then
         txtNumeroPosible.Text = PedidoAEditar.NumeroPedido.ToString()
      End If            'If Not _esCopia Then

      bscCodigoCliente.Text = PedidoAEditar.Cliente.CodigoCliente.ToString()
      bscCodigoCliente.PresionarBoton()

      If PedidoAEditar.ClienteVinculado IsNot Nothing Then
         bscCodigoClienteVinculado.Permitido = True
         bscCodigoClienteVinculado.Text = PedidoAEditar.ClienteVinculado.CodigoCliente.ToString()
         bscCodigoClienteVinculado.PresionarBoton()
      Else
         bscCodigoClienteVinculado.Text = String.Empty
         bscCodigoClienteVinculado.Selecciono = False

         bscClienteVinculado.Text = String.Empty
         bscClienteVinculado.Selecciono = False
      End If

      bscCodigoClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado
      bscClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado

      If Not String.IsNullOrWhiteSpace(PedidoAEditar.IdTipoComprobanteFact) Then
         Me.cmbTiposComprobantesFact.SelectedValue = PedidoAEditar.IdTipoComprobanteFact
      Else
         Me.cmbTiposComprobantesFact.SelectedIndex = -1
      End If

      cmbRespDistribucion.SelectedValue = PedidoAEditar.IdTransportista
      '' ''cmbCategoriaFiscal.SelectedValue = PedidoAEditar.CategoriaFiscal.IdCategoriaFiscal
      ComboCategoriaFiscalSelectedValue(PedidoAEditar.CategoriaFiscal.IdCategoriaFiscal)
      cmbVendedor.SelectedItem = GetVendedorCombo(PedidoAEditar.Vendedor.IdEmpleado)
      cmbEstadoVisita.SelectedValue = PedidoAEditar.IdEstadoVisita

      If PedidoAEditar.IdFormaPago.HasValue Then
         cmbFormaPago.SelectedValue = PedidoAEditar.IdFormaPago.Value
      Else
         cmbFormaPago.SelectedIndex = -1
      End If

      If PedidoAEditar.IdFormaPago.HasValue Then
         cmbFormaPago.SelectedValue = PedidoAEditar.IdFormaPago.Value
      Else
         cmbFormaPago.SelectedIndex = -1
      End If

      dtpFecha.Value = PedidoAEditar.Fecha

      txtDescRecGralPorc.Text = PedidoAEditar.DescuentoRecargoPorc.ToString()
      txtCotizacionDolar.Text = PedidoAEditar.CotizacionDolar.ToString()

      txtObservacion.Text = PedidoAEditar.Observacion

      If PedidoAEditar.PedidosProductos.Count > 0 Then
         cmbListaDePrecios.SelectedValue = PedidoAEditar.PedidosProductos(0).IdListaPrecios
      End If

      Me._pedidosProductos = PedidoAEditar.PedidosProductos

      'El presupuesto/pedido cuando se manda a grabar en DescuentoRecargoProducto tiene el descuento total aplicado
      'La regla lo divide por la cantidad y lo graba unitario
      'Al recuperar el presupuesto/pedido el GetUna lo recuperar unitario
      'Para que la pantalla lo mande a guardar como lo espera la regla, lo multiplico por la cantidad de modo que esté como cuando se creó
      For Each pp As Entidades.PedidoProducto In _pedidosProductos
         pp.DescuentoRecargoProducto *= pp.Cantidad
      Next

      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      'HabilitaComprobanteFactSegunLineas()

      _pedidosObservaciones = PedidoAEditar.PedidosObservaciones
      dgvObservaciones.DataSource = _pedidosObservaciones.ToArray()

      Me.CalcularTotales()
      Me.CalcularDatosDetalle()

      cmbTiposComprobantes.Enabled = False
      txtLetra.Enabled = False
      If Not _esCopia Then
         chbNumeroAutomatico.Enabled = False
         txtNumeroPosible.Enabled = False
         txtNumeroPosible.Text = PedidoAEditar.NumeroPedido.ToString()
      End If            'If Not _esCopia Then
      txtOrdenDeCompra.Text = PedidoAEditar.NumeroOrdenCompra.ToString()

      tsbNuevo.Visible = False
      tsbGrabar.Enabled = True

      If Not Reglas.Publicos.PedidosPermiteFechaEntregaDistintas AndAlso _pedidosProductos.Count > 0 Then
         dtpFechaEntrega.Value = _pedidosProductos(0).FechaEntrega
      End If

      _pedidosContactos.Clear()
      For Each contacto As Entidades.PedidoClienteContacto In _pedidoAEditar.PedidosContactos
         _pedidosContactos.Add(contacto.Contacto)
      Next
      ugContactos.DataSource = _pedidosContactos

      Dim pedidoOriginal As Entidades.Pedido = New Reglas.Pedidos().GetPedidoOrigen(_pedidoAEditar)
      If pedidoOriginal IsNot Nothing Then
         If pedidoOriginal.TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
            _ModificaDetalle = "SOLOPRECIOS"
            Me.CambiarEstadoControlesDetalle(False)
         ElseIf pedidoOriginal.TipoComprobante.ModificaAlFacturar = "NO" Then
            _ModificaDetalle = "NO"
            Me.CambiarEstadoControlesDetalle(False)
            txtCotizacionDolar.Enabled = False
         End If
      End If
      _fechaActualizacionBD = PedidoAEditar.FechaActualizacion
      _idUsuarioActualizacionBD = PedidoAEditar.IdUsuarioActualizacion
      If PedidoAEditar.Cliente.EsClienteGenerico Then
         bscCodigoLocalidad.Text = PedidoAEditar.IdLocalidad.Value.ToString()
         txtDireccionClienteGenerico.Text = PedidoAEditar.Direccion
         txtCUIT.Text = PedidoAEditar.Cuit
         Dim TipoDoc As String
         If PedidoAEditar.TipoDocCliente IsNot Nothing Then
            TipoDoc = PedidoAEditar.TipoDocCliente
         Else
            TipoDoc = String.Empty
         End If
         cmbTipoDoc.SelectedValue = TipoDoc
         txtNroDocCliente.Text = If(PedidoAEditar.NroDocCliente Is Nothing, "0", PedidoAEditar.NroDocCliente.Value.ToString())
         txtNombreClienteGenerico.Text = PedidoAEditar.NombreClienteGenerico

         SetearCamposClienteGenerico(PedidoAEditar.Direccion, PedidoAEditar.IdLocalidad.Value.ToString(), PedidoAEditar.NombreClienteGenerico)
      End If

      If True Then  ' _solicitaModificarFormulaLuegoDelProducto Then
         Dim oComponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
         'Dim dtComponentes As DataTable
         Dim converter = New Reglas.ProductoArbolConverter()
         For Each pp As Entidades.PedidoProducto In _pedidoAEditar.PedidosProductos
            If True Then ' pp.Producto.CalculaPreciosSegunFormula Then
               Dim formula = converter.ConvertFromPedidosProductosFormula(pp.PedidosProductosFormulas)

               Dim rEstr = New Reglas.EstructuraProductos()
               rEstr.RecalculaCantidades(formula, GetValoresForma(pp, True))


               _pedidosProductosFormulas.Add(pp, formula)
               ''''dtComponentes = oComponentes.GetComponentes(actual.Sucursal.IdSucursal, pp.IdProducto, pp.IdFormula, pp.IdListaPrecios)
               ''''For Each ppf As Entidades.PedidoProductoFormula In pp.PedidosProductosFormulas
               ''''   Dim drCol As DataRow() = dtComponentes.Select(String.Format("IdProductoComponente = '{0}'", ppf.IdProductoComponente))
               ''''   If drCol.Length > 0 Then
               ''''      For Each dr As DataRow In drCol
               ''''         dr("PrecioVenta") = ppf.PrecioVenta
               ''''         dr("PrecioCosto") = ppf.PrecioCosto
               ''''         dr("Cantidad") = ppf.Cantidad
               ''''         dr("SegunCalculoForma") = ppf.SegunCalculoForma
               ''''      Next
               ''''   Else
               ''''      Dim rProd As Reglas.Productos = New Reglas.Productos()
               ''''      Dim dtFueraFormula As DataTable = rProd.GetProductosGrillaFiltroMarcaRubroSubrubro(actual.Sucursal.Id, "", 0, 0, 0, ppf.IdProductoComponente)
               ''''      If dtFueraFormula.Rows.Count > 0 Then
               ''''         Dim drComponente As DataRow = dtComponentes.NewRow()
               ''''         Dim drFueraFormula As DataRow = dtFueraFormula.Rows(0)
               ''''         drComponente("IdProductoComponente") = drFueraFormula("IdProducto")
               ''''         drComponente("NombreProducto") = drFueraFormula("NombreProducto")
               ''''         drComponente("IdUnidadDeMedida") = drFueraFormula("IdUnidadDeMedida")
               ''''         drComponente("PrecioCosto") = drFueraFormula("PrecioCosto")
               ''''         drComponente("PrecioCostoSinIVA") = drFueraFormula("PrecioCostoSinIVA")
               ''''         drComponente("PrecioCostoConIVA") = drFueraFormula("PrecioCostoConIVA")
               ''''         drComponente("NombreMoneda") = drFueraFormula("NombreMoneda")
               ''''         drComponente("FactorConversion") = drFueraFormula("FactorConversion")
               ''''         drComponente("Simbolo") = drFueraFormula("Simbolo")
               ''''         drComponente("Tamano") = drFueraFormula("Tamano")
               ''''         drComponente("SegunCalculoForma") = False

               ''''         drComponente("PrecioVenta") = drFueraFormula("PrecioVenta")
               ''''         drComponente("PrecioVentaSinIVA") = drFueraFormula("PrecioVentaSinIVA")
               ''''         drComponente("PrecioVentaConIVA") = drFueraFormula("PrecioVentaConIVA")
               ''''         drComponente("ComponenteAgregado") = True

               ''''         drComponente("PrecioVenta") = ppf.PrecioVenta
               ''''         drComponente("PrecioCosto") = ppf.PrecioCosto
               ''''         drComponente("Cantidad") = ppf.Cantidad
               ''''         drComponente("SegunCalculoForma") = ppf.SegunCalculoForma

               ''''         dtComponentes.Rows.Add(drComponente)
               ''''      End If
               ''''   End If
               ''''Next
               ''''If dtComponentes.Rows.Count > 0 Then
               ''''   'MD-PROD: Al editar un pedido debe tomar los componentes de la formula y guardarlo en el diccionario
               ''''   _pedidosProductosFormulas.Add(pp, dtComponentes)
               ''''End If
            End If
         Next
      End If
      SetProductosDataSource()
      PintarProductosStockNegativo()
      HabilitaComprobanteFactSegunLineas()
   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged, cmbTiposComprobantesFact.SelectedIndexChanged
      If Me._estaCargando Then Exit Sub

      Try
         'cada vez que selecciono un comprobante, pongo la fecha de hoy en el comprobante y si es fiscal no lo permito modificar
         If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
            Exit Sub
         End If
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
               Me.dtpFecha.Enabled = Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
               If Not Me.dtpFecha.Enabled Then
                  Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
               End If
            End If
         End If

         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
            Me._DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                       cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                       cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                       _pedidosProductos.Count)
            Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
         End If


         'solo habilito el boton de Facturables segun corresponde (si Eligio Factura en blanco o negro, tickets, etc)
         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
            Me.cmbCategoriaFiscal.Enabled = True
            If Me._clienteE IsNot Nothing Then
               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then

                  'Vuelvo a asignarlo para saber si lo cambio.
                  Me._clienteE = New Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

                  Me.cmbCategoriaFiscal.Enabled = False
                  'Si cambio la categoria... le vuelvo la original
                  If Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IdCategoriaFiscal <> _clienteE.CategoriaFiscal.IdCategoriaFiscal Then
                     '' ''Me.cmbCategoriaFiscal.SelectedValue = _clienteE.CategoriaFiscal.IdCategoriaFiscal
                     ComboCategoriaFiscalSelectedValue(_clienteE.CategoriaFiscal.IdCategoriaFiscal)
                     'Exit Sub
                  End If

               Else

                  ComboCategoriaFiscalSelectedValue(_clienteE.CategoriaFiscal.IdCategoriaFiscal)
                  ' '' ''Solo para los comprobantes en negro (los Pre-Eelctronicos son en blanco)
                  '' ''If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
                  '' ''   Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
                  '' ''Else
                  '' ''   'Pudo cambiarla.
                  '' ''   Me.cmbCategoriaFiscal.SelectedValue = _clienteE.CategoriaFiscal.IdCategoriaFiscal
                  '' ''End If

               End If
            End If
            '-----------------------------------------------------------


            'Si es X es remito, siempre debe tener esa letra, sino dejo la que esta.
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Length = 1 Then
               Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
                  Me.txtLetra.Text = Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).LetraFiscal
               Else
                  Me.txtLetra.Text = ""
               End If
            End If

            Me.chbNumeroAutomatico.Checked = True
            Me.chbNumeroAutomatico.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal

         End If

         If Me.tbcDetalle.TabPages.Contains(Me.tbpProductos) Then
            'NO logro que quede primero.
            'Me.tbcDetalle.TabPages.Item(0).Name = Me.tbpProductos.Name
            Me.tbcDetalle.SelectedTab = Me.tbpProductos

            'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
            'AjustarColumnasGrilla(dgvProductos, _titProductos)
            SetProductosDataSource()
            If Me.dgvProductos.Rows.Count > 0 Then
               Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            End If
            Me.dgvProductos.Refresh()

         End If

         Me.CambiarEstadoControlesDetalle(Me._clienteE IsNot Nothing)

         'Si algun producto es con Lote tengo que limpiar el detalle, porque pudo cambiar de Factura a NCRED o viseversa, y lleva controles
         ' o que afecta stock si a no.
         If Me.ProductosConLote() > 0 Then
            Me.LimpiarDetalle()
         End If

         Me.CargarProximoNumero()

         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            'Se ejecuta al cambiar en pantalla, mas alla que lo hayan elegido
            ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
            ''Habria que hacerlo mas general!
            'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal AndAlso Me._clienteE IsNot Nothing AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit) Then
            '   MessageBox.Show("El Comprobante requiere obligatorio el CUIT pero el Cliente NO lo tiene.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '   'Me.Nuevo()
            '   'Exit Sub
            'End If

         End If
         CargaTipoComprobanteProducto()
         'Por ahora , pero hay que hacerlo mas profundo (poner o quitar el IVA, etc).
         Me.CalcularTotales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private _cargandoProductosAutomaticamente As Boolean = False
   Private Sub CargaTipoComprobanteProducto()
      If validaCliente() Then
         For Each rwPedidoProduct As Entidades.PedidoProducto In _pedidosProductos.Where(Function(x) x.Automatico).ToArray()
            EliminarLineaProducto(rwPedidoProduct)
         Next

         If cmbTiposComprobantes.SelectedIndex > -1 Then
            Dim _tiposComprobantes As List(Of Entidades.TipoComprobanteProducto)
            _tiposComprobantes = New Reglas.TiposComprobantesProductos().GetTodos(Me.cmbTiposComprobantes.SelectedValue.ToString())

            For Each Row As Entidades.TipoComprobanteProducto In _tiposComprobantes
               _cargandoProductosAutomaticamente = True
               bscCodigoProducto2.Text = Row.IdProducto
               bscCodigoProducto2.PresionarBoton()
               txtCantidad.Text = Row.Cantidad.ToString
               txtPrecio.Focus()
               btnInsertar.PerformClick()
            Next
            _cargandoProductosAutomaticamente = False
         End If

      End If
   End Sub

   Private Sub btnObservacionCliente_Click(sender As Object, e As EventArgs) Handles btnObservacionCliente.Click
      Try
         If MessageBox.Show("¿Desea ingresar nuevas observaciones ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            Dim ocli As Reglas.Clientes = New Reglas.Clientes()
            _clienteE.Observacion = Me.txtObservacion2.Text
            _clienteE.Usuario = actual.Nombre

            ocli.Actualizar(_clienteE)

            MessageBox.Show("La observación fue registrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function validaCliente() As Boolean

      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono And (Me.bscCodigoCliente.Text.Trim.Length = 0 Or Me.bscCliente.Text.Trim.Length = 0) Then
         Return False
      End If

      If bscCodigoCliente.FilaDevuelta Is Nothing And bscCliente.FilaDevuelta Is Nothing Then
         Return False
      End If
      Return True
   End Function
   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      Me.txtNumeroPosible.ReadOnly = chbNumeroAutomatico.Checked
   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged
      If Me._estaCargando Then Exit Sub

      Try
         If Me.cmbTiposComprobantes.SelectedItem Is Nothing Then
            MessageBox.Show("Falta asignar el tipo de comprobante para una PC en impresoras.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         If Me.cmbFormaPago.SelectedIndex <> -1 Then
            txtDescRecGralPorc.Text = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                           cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                           cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                           _pedidosProductos.Count).ToString("N" + _decimalesEnTotales.ToString())
            Me.CalcularDatosDetalle()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub dgvProductos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProductos.CellFormatting
      If e.ColumnIndex = PrecioIVA.Index Then
         e.FormattingApplied = True
         Dim row As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
         If (Not Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
            Me.cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            e.Value = String.Format("{0:N2}", CDec(row.Cells(Precio.Name).Value))
         Else
            e.Value = String.Format("{0:N2}", (CDec(row.Cells(Precio.Name).Value) * (CDec(row.Cells(AlicuotaImpuesto.Name).Value) + 100) / 100) +
                                              CDec(row.Cells(ImporteImpuestoInterno.Name).Value))
         End If
      End If
   End Sub

   Private Sub chbModificaDescRecargo_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbModificaDescRecargo.CheckedChanged

      Me.txtDescRecPorc1.ReadOnly = Not Me.chbModificaDescRecargo.Checked
      Me.txtDescRecPorc2.ReadOnly = Not Me.chbModificaDescRecargo.Checked

      If Me.chbModificaDescRecargo.Checked Then
         Me.txtDescRecPorc1.Focus()
         Me.txtDescRecPorc1.SelectAll()
      ElseIf Me.chbModificaPrecio.Checked Then
         FocusPrecio()
      Else
         txtCantidadManual.Select()
         Me.txtCantidadManual.SelectAll()
      End If

   End Sub

   Private Sub SetearDescuentosPorCantidad(producto As Entidades.Producto)
      txtCantidadManual.Tag = Nothing
      ToolTip1.SetToolTip(txtCantidadManual, String.Empty)
      If producto IsNot Nothing Then
         Dim descRecCantidad As Reglas.Ventas.DescuentoRecargoPorCantidad = New Reglas.Ventas().GetDescuentoCantidad(producto)
         If descRecCantidad IsNot Nothing Then
            Dim stb As StringBuilder = New StringBuilder()
            If descRecCantidad.UnidHasta1 <> 0 Then
               stb.AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta1, descRecCantidad.UHPorc1.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            If descRecCantidad.UnidHasta2 <> 0 Then
               stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta2, descRecCantidad.UHPorc2.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            If descRecCantidad.UnidHasta3 <> 0 Then
               stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta3, descRecCantidad.UHPorc3.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            If descRecCantidad.UnidHasta4 <> 0 Then
               stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta4, descRecCantidad.UHPorc4.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            If descRecCantidad.UnidHasta5 <> 0 Then
               stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta5, descRecCantidad.UHPorc5.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            ToolTip1.Show(stb.ToString(), txtCantidadManual, New Point(0, 17))
            txtCantidadManual.Tag = stb.ToString()
         End If
      End If
   End Sub

   Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidad.Enter, txtCantidadManual.Enter
      Try
         If txtCantidadManual.Tag IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtCantidadManual.Tag.ToString()) Then
            ToolTip1.Show(txtCantidadManual.Tag.ToString(), txtCantidadManual, New Point(0, 17))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave, txtCantidadManual.Leave
      Try
         ToolTip1.Hide(txtCantidadManual)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub PedidosClientesV2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         If _ConfiguracionImpresoras Then
            MessageBox.Show("No Existe la PC en Configuraciones/Impresoras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         End If
         bscCodigoCliente.Focus()

         Try
            Me.Enabled = False
            CalculosDescuentosRecargos1.Inicializar()
         Finally
            lblEstado.Text = String.Empty
            Me.Enabled = True
         End Try

         If PedidoAEditar IsNot Nothing Then
            MostrarPedidoEditable()

            Dim cotizacionActualDolar As Decimal = New Reglas.Monedas().GetUna(2).FactorConversion
            'Dim cambioDolar As Boolean
            If PedidoAEditar.CotizacionDolar <> cotizacionActualDolar Then
               If ShowPregunta(String.Format("La cotización del dolar del presente Presupuesto difiere de la cotización actual del sistema." + Environment.NewLine + Environment.NewLine +
                                             "Presupuesto: {0:N2}" + Environment.NewLine +
                                             "Sistema: {1:N2}" + Environment.NewLine + Environment.NewLine +
                                             "¿Desea actualizar la cotización del dolar del Presupuesto?",
                                       PedidoAEditar.CotizacionDolar, cotizacionActualDolar)) = Windows.Forms.DialogResult.Yes Then
                  txtCotizacionDolar.Text = cotizacionActualDolar.ToString("N2")
                  RecalcularTodo(recuperaCosto:=True, desdeListaPrecios:=False)
               End If
            End If
            If _esCopia Then

               Dim PresupuestoActualizaPreciosCopia As String = Reglas.Publicos.CopiaPresupuestoActualizaPrecios
               If PresupuestoActualizaPreciosCopia = Reglas.Publicos.SiempreNuncaPreguntar.PREGUNTAR.ToString() Then
                  If ShowPregunta("¿Desea actualizar los precios?") = Windows.Forms.DialogResult.Yes Then
                     RecalcularTodo(recuperaCosto:=True, desdeListaPrecios:=False)
                  End If
               ElseIf PresupuestoActualizaPreciosCopia = Reglas.Publicos.SiempreNuncaPreguntar.SIEMPRE.ToString() Then
                  RecalcularTodo(recuperaCosto:=True, desdeListaPrecios:=False)
               End If

            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
      TryCatched(Sub() BuscarProductoConConsultaPrecios())
   End Sub

   Private Sub BuscarProductoConConsultaPrecios()
      If bscProducto2.Enabled Then
         Using frm As New ConsultarPrecios("SI", "TODOS")
            frm.ConsultarAutomaticamente = True
            If frm.ShowDialogParaBusqueda(bscCodigoProducto2.Text, bscProducto2.Text, CInt(cmbListaDePrecios.SelectedValue)) = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrWhiteSpace(frm.IdProductoDevuelta) Then
                  bscCodigoProducto2.Text = frm.IdProductoDevuelta
                  bscCodigoProducto2.PresionarBoton()
               End If
            End If
         End Using
      End If
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Function ValidarLimiteCredito(arrojarException As Boolean) As Boolean?
      If Decimal.Parse(Me.txtSaldoCtaCte.Text) + Decimal.Parse(Me.txtTotalGeneral.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
         Select Case Publicos.PedidosControlaEventosdeLimiteDeCreditoDeClientes
            Case "No Permitir"
               If Not arrojarException Then
                  ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
                  Return False
               Else
                  Throw New Exception("ATENCION: El Cliente Superó la cantidad de dias de límite de Crédito. El Comprobante fué Cancelado por Falta de Crédito.")
               End If
            Case "Avisar y Permitir"
               If Not LimiteCreditoPermitido() Then
                  ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
                  Return False
               End If
               If ShowPregunta("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?") <> Windows.Forms.DialogResult.Yes Then
                  If Not arrojarException Then
                     ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
                     Return False
                  Else
                     Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                  End If
               End If
            Case Else
               If Not LimiteCreditoPermitido() Then
                  ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
                  Return False
               End If
         End Select
      End If
   End Function

   Private Sub ValidarDiasDeVencimiento()
      'Me.txtLimiteDiasVto.Text = (0).ToString()

      '# Controlo Limite Dias Vto Factura 
      If Me._clienteE Is Nothing OrElse
         Me.cmbTiposComprobantes.SelectedIndex = -1 Then Exit Sub

      If Me._clienteE.LimiteDiasVtoFactura > 0 AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = 1 AndAlso
              DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Tipo = "PEDIDOSCLIE" Then

         Dim oCtaCteDet As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes
         Dim FechaLimite As Date = Date.Today().AddDays(-Me._clienteE.LimiteDiasVtoFactura)
         Dim dt As DataTable


         dt = oCtaCteDet.GetCtaCte(actual.Sucursal.IdSucursal, Nothing, Nothing, 0, Me._clienteE.IdCliente, Nothing, "CON SALDO", "", 0, "TODOS", Nothing, "SI", "SI", "SI", "", "ACTUAL", "ACTUAL", "NO",
                                   New Reglas.Sucursales().GetTodas(False).ToArray(), agruparIdClienteCtaCte:=False, ruta:=0, dia:=Nothing, 0)

         If dt.Rows.Count <> 0 Then
            Dim fechaDeVencimiento As Date = dt.Rows(0).Field(Of Date)("FechaVencimiento")
            If fechaDeVencimiento <= FechaLimite Then
               Dim fechaFact As Date = fechaDeVencimiento
               Dim Dias As Long = DateDiff(DateInterval.Day, fechaFact, FechaLimite)
               'Me.txtLimiteDiasVto.Text = Dias.ToString()

               Select Case Publicos.PedidosControlaDiasVtoDeCreditoDeClientes
                  Case "No Permitir"
                     Throw New Exception("ATENCION: El Cliente Superó la cantidad de dias de límite de Crédito. El Comprobante fué Cancelado por Falta de Crédito.")
                  Case "Avisar y Permitir"
                     If Not LimiteDiasVtoPermitido() Then
                        Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                     End If
                     If ShowPregunta("ATENCION: El Cliente Superó la cantidad de dias de límite de Crédito, ¿ Continúa ?", MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                        Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                     End If
                  Case Else
                     If Not LimiteDiasVtoPermitido() Then
                        Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                     End If
               End Select
            End If
         End If
      End If

   End Sub

   ''' <summary>
   ''' Guardo la lista de Precios anterior para el caso de cmabio por bonificacion.
   ''' y solo la primera vez.
   ''' </summary>
   Private Sub GuardoListaPreciosPrevia()
      '-- REQ-41752.- -------------------------------------------------------
      If Not _cambioListaPrecio.HasValue Then
         _cambioListaPrecio = Integer.Parse(cmbListaDePrecios.SelectedValue.ToString())
         '----------------------------------------------------------------------
      End If
   End Sub

  Private Sub BonificacionListaDePrecioXCantidad(prod As Entidades.Producto, cantidad As Decimal)
      _idListaAux = -1
      '-- REQ-33202.- ---------------------------------------------------------------------------------------
      If cantidad >= prod.UnidHasta5 AndAlso prod.UHListaPrecios5 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios5
         End If
         _idListaAux = CInt(prod.UHListaPrecios5)
      ElseIf cantidad >= prod.UnidHasta4 AndAlso prod.UHListaPrecios4 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios4
         End If
         _idListaAux = CInt(prod.UHListaPrecios4)
      ElseIf cantidad >= prod.UnidHasta3 AndAlso prod.UHListaPrecios3 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios3
         End If
         _idListaAux = CInt(prod.UHListaPrecios3)
      ElseIf cantidad >= prod.UnidHasta2 AndAlso prod.UHListaPrecios2 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios2
         End If
         _idListaAux = CInt(prod.UHListaPrecios2)

      ElseIf cantidad >= prod.UnidHasta1 AndAlso prod.UHListaPrecios1 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios1
         End If
         _idListaAux = CInt(prod.UHListaPrecios1)
      Else
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = _clienteE.IdListaPrecios
         End If
         _idListaAux = _clienteE.IdListaPrecios
      End If
      '-------------------------------------------------------------------------------------------------------
   End Sub


#Region "Contactos"
   Private Sub btnLimpiarContacto_Click(sender As Object, e As EventArgs) Handles btnLimpiarContacto.Click
      RefrescarContactos()
   End Sub

   Private Sub RefrescarContactos()
      cmbContacto.SelectedIndex = -1
      cmbContacto.Focus()
   End Sub


   Private Sub btnInsertarContacto_Click(sender As Object, e As EventArgs) Handles btnInsertarContacto.Click
      Try
         InsertarContacto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub InsertarContacto()
      If cmbContacto.SelectedIndex >= 0 Then
         Dim existe As Boolean = False
         Dim contactoCombo As Entidades.ClienteContacto = DirectCast(cmbContacto.SelectedItem, Entidades.ClienteContacto)
         For Each contacto As Entidades.ClienteContacto In _pedidosContactos
            If contacto.IdContacto = contactoCombo.IdContacto Then
               existe = True
            End If
         Next
         If Not existe Then
            _pedidosContactos.Add(DirectCast(cmbContacto.SelectedItem, Entidades.ClienteContacto))
            ugContactos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
         RefrescarContactos()
      End If
   End Sub

   Private Sub btnEliminarContacto_Click(sender As Object, e As EventArgs) Handles btnEliminarContacto.Click
      Try
         If ugContactos.ActiveRow IsNot Nothing AndAlso
            ugContactos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugContactos.ActiveRow.ListObject) Is Entidades.ClienteContacto Then
            _pedidosContactos.Remove(DirectCast(ugContactos.ActiveRow.ListObject, Entidades.ClienteContacto))
            ugContactos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbContacto.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            InsertarContacto()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos para Observ. Detalladas"
   Private Sub bscObservacionDetalle_BuscadorClick() Handles bscObservacionDetalle.BuscadorClick
      Try
         Dim oObservaciones As Reglas.Observaciones = New Reglas.Observaciones
         Me._publicos.PreparaGrillaObservaciones(Me.bscObservacionDetalle)
         Me.bscObservacionDetalle.Datos = oObservaciones.GetPorNombre(Me.bscObservacionDetalle.Text.Trim(), "VENTA")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscObservacionDetalle_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscObservacionDetalle.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarObservDetalle(e.FilaDevuelta)
            Me.btnInsertarObservacion.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarObservacion_Click(sender As Object, e As System.EventArgs) Handles btnInsertarObservacion.Click
      Try
         If Me.bscObservacionDetalle.Text <> "" And cmbTipoObservacion.SelectedIndex > -1 Then
            If Me.ValidarInsertaObservacion() Then
               Me.InsertarObservacion()
               Me.bscObservacionDetalle.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnEliminarObservacion_Click(sender As Object, e As System.EventArgs) Handles btnEliminarObservacion.Click
      Try
         If Me.dgvObservaciones.SelectedRows.Count > 0 Then
            If ShowPregunta("¿Está seguro de eliminar la Observación seleccionada?") = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaObservacion()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dgvObservaciones_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvObservaciones.CellDoubleClick

      Try
         If e.RowIndex <> -1 Then
            'limpia los textbox, y demas controles
            Me.LimpiarCamposObservDetalles()

            'carga la observacion seleccionada de la grilla en los textbox 
            Me.CargarObservDetalleCompleto(Me.dgvObservaciones.Rows(e.RowIndex))

            'elimina el producto de la grilla
            Me.EliminarLineaObservacion()

            'Tengo que renumerar por la forma que asigno el numero de linea.
            Me.RenumerarObservacionesDetalle()

            cmbTipoObservacion.Focus()
            'Me.bscObservacionDetalle.SelectAll()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub


   Private Sub CargarObservDetalle(dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub CargarObservDetalleCompleto(dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("gobsObservacion").Value.ToString()
      cmbTipoObservacion.SelectedValue = Short.Parse(dr.Cells("idTipoObservacion").Value.ToString())
   End Sub

   Private Sub InsertarObservacion()
      Dim oLineaDetalle As Entidades.PedidoObservacion = New Entidades.PedidoObservacion()

      With oLineaDetalle
         If PedidoAEditar IsNot Nothing Then
            .IdSucursal = PedidoAEditar.IdSucursal
         Else
            .IdSucursal = actual.Sucursal.Id
         End If
         .Usuario = actual.Nombre
         .Linea = Me.dgvObservaciones.RowCount + 1
         .Observacion = Me.bscObservacionDetalle.Text
         .IdTipoObservacion = Short.Parse(cmbTipoObservacion.SelectedValue.ToString())
         .DescripcionTipoObservacion = cmbTipoObservacion.Text
      End With

      Me._pedidosObservaciones.Add(oLineaDetalle)

      Me.dgvObservaciones.DataSource = Me._pedidosObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

      Me.LimpiarCamposObservDetalles()

   End Sub

   Private Sub LimpiarCamposObservDetalles()
      Me.bscObservacionDetalle.Text = ""
      cmbTipoObservacion.SelectedValue = _idTipoObservacionDefecto
   End Sub

   Private Function ValidarInsertaObservacion() As Boolean

      'If Me.dgvObservaciones.RowCount = Me._cantMaxItemsObserv Then
      '   ShowMessage(String.Format("No puede ingresar mas de {0} lineas de Observaciones para este tipo de comprobante.", _cantMaxItemsObserv))
      '   Me.btnInsertarObservacion.Focus()
      '   Return False
      'End If

      ''Sumo Lineas del Comprobante + Lineas de Observaciones.

      'Dim LineasDetalle As Integer = Me.dgvProductos.RowCount

      'If LineasDetalle + Me.dgvObservaciones.RowCount = Me._cantMaxItems Then
      '   ShowMessage(String.Format("No puede ingresar mas de {0} lineas (Productos y Observaciones) para este tipo de comprobante.", _cantMaxItems))
      '   Me.btnInsertarObservacion.Focus()
      '   Return False
      'End If

      Return True
   End Function

   Private Sub EliminarLineaObservacion()
      Me._pedidosObservaciones.RemoveAt(Me.dgvObservaciones.SelectedRows(0).Index)
      Me.dgvObservaciones.DataSource = Me._pedidosObservaciones.ToArray()
   End Sub

   Private Sub RenumerarObservacionesDetalle()

      Dim Linea As Integer = 0

      For Each vObs As Entidades.PedidoObservacion In Me._pedidosObservaciones
         Linea += 1
         vObs.Linea = Linea
      Next

      Me.dgvObservaciones.DataSource = Me._pedidosObservaciones.ToArray()
      'Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

   End Sub
#End Region

   Private Sub txtPrecioVentaPorTamano_Leave(sender As Object, e As EventArgs) Handles txtPrecioVentaPorTamano.Leave
      Try
         RecalculaPrecioDesdePrecioPorTamano()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub RecalculaPrecioDesdePrecioPorTamano()
      If txtPrecioVentaPorTamano.Enabled Then
         If IsNumeric(txtPrecioVentaPorTamano.Text) Then
            Dim precioVentaPorTamano As Decimal = Decimal.Parse(txtPrecioVentaPorTamano.Text)
            Dim tamano As Decimal = 0
            Decimal.TryParse(txtTamanio.Text, tamano)
            Dim cotizacionDolar As Decimal = Decimal.Parse(txtCotizacionDolar.Text)
            If cmbMoneda.SelectedIndex = -1 Then
               cotizacionDolar = 0
            ElseIf cmbMoneda.SelectedValue.Equals(1) Then
               cotizacionDolar = 1
            End If
            txtPrecio.Text = CalculaPrecioDesdePrecioPorTamano(precioVentaPorTamano, tamano, cotizacionDolar).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            Me.CalcularTotalProducto()
         End If
      End If
   End Sub

   Private Function CalculaPrecioDesdePrecioPorTamano(precioVentaPorTamano As Decimal,
                                                      tamano As Decimal,
                                                      cotizacionDolar As Decimal) As Decimal
      Return Decimal.Round((precioVentaPorTamano * tamano * cotizacionDolar), _decimalesRedondeoEnPrecio)
   End Function

   Private Sub txtPrecioVentaPorTamano_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioVentaPorTamano.KeyDown
      If e.KeyCode = Keys.Enter Then

         If Me.chbModificaDescRecargo.Checked Then
            Me.txtDescRecPorc1.Focus()
            Me.txtDescRecPorc1.SelectAll()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
         'Me.txtDescRecPorc1.Focus()
      End If
   End Sub

   Private Sub txtTotalProducto_TextChanged(sender As Object, e As EventArgs) Handles txtTotalProducto.TextChanged
      Try
         Dim utilidad As Decimal = 0
         Dim cantidad As Decimal = 0
         Dim importeNeto As Decimal = 0
         Dim importeCosto As Decimal = 0
         Dim PorcentajeUtilidad As Decimal = 0

         Decimal.TryParse(txtCantidad.Text, cantidad)
         Decimal.TryParse(txtTotalProducto.Text, importeNeto)
         Decimal.TryParse(txtCosto.Text, importeCosto)

         importeCosto = importeCosto * cantidad
         utilidad = importeNeto - importeCosto

         If Reglas.Publicos.Facturacion.FacturacionSemaforoCalculoMuestra = Entidades.Publicos.SemaforoCalculoMuestra.Rentabilidad.ToString() Then
            If importeNeto > 0 Then
               PorcentajeUtilidad = Decimal.Round(utilidad / importeNeto * 100, Me._decimalesRedondeoEnPrecio)
            End If
         Else
            If importeCosto > 0 Then
               PorcentajeUtilidad = Decimal.Round(utilidad / importeCosto * 100, Me._decimalesRedondeoEnPrecio)
            End If
         End If
         txtRentabilidadDetalle.Text = utilidad.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         If PorcentajeUtilidad <> 0 Then
            txtSemaforoRentabilidadDetalle.Text = PorcentajeUtilidad.ToString("N" + _decimalesAMostrarEnTotalXProducto.ToString())
            'Dim colo As Color = System.Drawing.Color.FromArgb(New Reglas.SemaforoVentasUtilidades().ColorSemaforo(PorcentajeUtilidad, Entidades.SemaforoVentaUtilidad.TiposSemaforos.RENTABILIDAD))

            'Me.txtSemaforoRentabilidadDetalle.BackColor = colo
            'If colo.ToArgb() = Color.Black.ToArgb() Then
            '   Me.txtSemaforoRentabilidadDetalle.ForeColor = Color.White
            'Else
            '   Me.txtSemaforoRentabilidadDetalle.ForeColor = Me.txtLetra.ForeColor
            'End If

            '# Semaforo de RENTABILIDAD
            Me.SetearColorSemaforos(txtSemaforoRentabilidadDetalle, IdTipoSemaforo:=Entidades.SemaforoVentaUtilidad.TiposSemaforos.RENTABILIDAD)

         Else
            Me.txtSemaforoRentabilidadDetalle.Text = ""
            Me.txtSemaforoRentabilidadDetalle.BackColor = Me.txtLetra.BackColor
            Me.txtSemaforoRentabilidadDetalle.ForeColor = Me.txtLetra.ForeColor
            Me.txtSemaforoRentabilidadDetalle.Key = "0"
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtProductoAnchoIntBase_Leave(sender As Object, e As EventArgs) Handles txtProductoAnchoIntBase.Leave, txtProductoLargoExtAlto.Leave, txtProductoArchitrave.Leave, cmbProductoProduccionModeloForma.SelectedValueChanged
      Try
         txtTamanio.Text = CalculaFormula().ToString(_formatoTamanio)
         txtKilosModDesc.Text = txtTamanio.Text
         CalculaPreciosSegunFormula(False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   'Private Sub txtProductoLargoExtAlto_Leave(sender As Object, e As EventArgs) Handles txtProductoLargoExtAlto.Leave
   '   Try
   '      txtTamanio.Text = CalculaFormula().ToString(_formatoTamanio)
   '      txtKilosModDesc.Text = txtTamanio.Text
   '      CalculaPreciosSegunFormula()
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   Private Sub CalculaPreciosSegunFormula(solicitaFormula As Boolean)
      If cmbFormula.SelectedIndex = -1 Then
         Exit Sub
         'cmbFormula.Focus()
         'Throw New Exception("El producto seleccionado calcula sus precios según su FORMULA. No ha seleccionado una Formula. Por favor reintente.")
      End If
      Dim idFormula As Integer = Integer.Parse(cmbFormula.SelectedValue.ToString())
      Dim idListaDePrecios As Integer = Publicos.ListaPreciosPredeterminada
      If cmbListaDePrecios.SelectedIndex > -1 Then idListaDePrecios = Integer.Parse(cmbListaDePrecios.SelectedValue.ToString())

      If solicitaFormula Then
         SolicitarFormula(idFormula, idListaDePrecios)
      End If

      If _calculaPreciosSegunFormula Then


         Dim rEstructuraProducto = New Reglas.EstructuraProductos()
         Dim forma = cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma)
         rEstructuraProducto.RecalculaCantidades(_pedidosProductosFormulasActual, GetValoresForma(forma))

         Dim preciosProducto = {_pedidosProductosFormulasActual}.ToList().
                                 ConvertAll(Function(e) New Entidades.PreciosProducto(actual.Sucursal.Id, e.IdProducto, idListaDePrecios) With
                                             {
                                                .PrecioCostoSinIVA = e.CostoSinImpuestos,
                                                .PrecioCostoConIVA = e.CostoConImpuestos,
                                                .PrecioVentaSinIVA = e.PrecioSinImpuestos,
                                                .PrecioVentaConIVA = e.PrecioConImpuestos
                                             }).FirstOrDefault()

         If (cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
         Not cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal).UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Then
            If txtPrecioVentaPorTamano.Enabled Then
               txtPrecioVentaPorTamano.Text = preciosProducto.PrecioVentaSinIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
               txtPrecio.Text = (0).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            Else
               txtPrecio.Text = preciosProducto.PrecioVentaSinIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            End If
            txtCosto.Text = preciosProducto.PrecioCostoSinIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            If bscCodigoProducto2.FilaDevuelta IsNot Nothing Then bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value = preciosProducto.PrecioVentaSinIVA
         Else
            If txtPrecioVentaPorTamano.Enabled Then
               txtPrecioVentaPorTamano.Text = preciosProducto.PrecioVentaConIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            Else
               txtPrecio.Text = preciosProducto.PrecioVentaConIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            End If
            txtCosto.Text = preciosProducto.PrecioCostoConIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            If bscCodigoProducto2.FilaDevuelta IsNot Nothing Then bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value = preciosProducto.PrecioVentaConIVA
         End If

      End If
   End Sub

   Private Function CalculaFormula() As Decimal
      Dim resultado As Decimal = 0
      If cmbProductoProduccionForma.SelectedItem IsNot Nothing Then
         Dim forma = cmbProductoProduccionForma.ItemSeleccionado(Of Entidades.ProduccionForma)
         If Not String.IsNullOrWhiteSpace(forma.FormulaCalculoKilaje) Then
            Dim rForma As Reglas.ProduccionFormas = New Reglas.ProduccionFormas()
            'MD-PROD: Tomar valores nuevos de formulas
            Dim formulaPreparada As String = rForma.PreparaFormulaParaEvaluar(forma.FormulaCalculoKilaje,
                                                                              txtProductoEspmm.ValorNumericoPorDefecto(0D),
                                                                              txtProductoLargoExtAlto.ValorNumericoPorDefecto(0D),
                                                                              txtProductoAnchoIntBase.ValorNumericoPorDefecto(0D),
                                                                              txtProductoArchitrave.ValorNumericoPorDefecto(0D),
                                                                              cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma))
            Dim resultadoFormula As CalcEngine.UltraCalcValue = UltraCalcManager1.Calculate(formulaPreparada)
            Try
               resultado = resultadoFormula.ToDecimal()
            Catch
               'Si hay algún error devuelvo cero.
            End Try
         End If
      Else
         resultado = txtTamanio.ValorNumericoPorDefecto(0D)
      End If
      Return Decimal.Round(resultado, _decimalesRedondeoEnTamanio)
   End Function

   Private Sub cmbProductoProduccionModeloForma_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProductoProduccionModeloForma.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            FocusPrecio()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
      End If
   End Sub

   Private Sub txtProductoArchitrave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoArchitrave.KeyDown
      If e.KeyCode = Keys.Enter Then
         If cmbProductoProduccionModeloForma.Enabled AndAlso cmbProductoProduccionModeloForma.Visible Then
            cmbProductoProduccionModeloForma.Focus()

         ElseIf Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            FocusPrecio()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
      End If
   End Sub

   Private Sub txtProductoLargoExtAlto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoLargoExtAlto.KeyDown
      If e.KeyCode = Keys.Enter Then
         'If txtProductoAnchoIntBase.Enabled AndAlso txtProductoAnchoIntBase.Visible Then
         '   txtProductoAnchoIntBase.Focus()
         'Else
         If txtProductoArchitrave.Enabled AndAlso txtProductoArchitrave.Visible Then
            txtProductoArchitrave.Focus()
         ElseIf cmbProductoProduccionModeloForma.Enabled AndAlso cmbProductoProduccionModeloForma.Visible Then
            cmbProductoProduccionModeloForma.Focus()

         ElseIf Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            FocusPrecio()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
      End If
   End Sub

   Private Sub txtProductoAnchoIntBase_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoAnchoIntBase.KeyDown
      If e.KeyCode = Keys.Enter Then
         If txtProductoLargoExtAlto.Enabled AndAlso txtProductoLargoExtAlto.Visible Then
            txtProductoLargoExtAlto.Focus()

         ElseIf txtProductoArchitrave.Enabled AndAlso txtProductoArchitrave.Visible Then
            txtProductoArchitrave.Focus()
         ElseIf cmbProductoProduccionModeloForma.Enabled AndAlso cmbProductoProduccionModeloForma.Visible Then
            cmbProductoProduccionModeloForma.Focus()

         ElseIf Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            FocusPrecio()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            If cmbNota.Enabled AndAlso cmbNota.Visible Then
               cmbNota.Focus()
            Else
               btnInsertar.Select()
            End If
         End If
      End If
   End Sub

   Private Sub btnProductoUrlPlanoOpenFile_Click(sender As Object, e As EventArgs) Handles btnProductoUrlPlanoOpenFile.Click
      Try
         If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtProductoUrlPlano.Text = OpenFileDialog1.FileName
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
      Try
         RecalculaPrecioDesdePrecioPorTamano()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCotizacionDolar_Leave(sender As Object, e As EventArgs) Handles txtCotizacionDolar.Leave
      Try
         If txtCotizacionDolar.ValorNumericoPorDefecto(0D) < 1 Then
            MessageBox.Show("La cotización dólar no puede ser inferior a uno (1)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCotizacionDolar.Focus()
            Exit Sub
         End If
         Dim cotizacionDolar As Decimal
         If Not Decimal.TryParse(txtCotizacionDolar.Text, cotizacionDolar) Then
            cotizacionDolar = 0
         End If
         'SOLO REPROCESO SI CAMBIA EL TIPO DE CAMBIO. SI NO CAMBIÓ NO HAGO NADA
         If cotizacionDolar <> _cotizacionDolar_Prev Then
            RecalcularTodo(recuperaCosto:=False, desdeListaPrecios:=False)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCotizacionDolar_Enter(sender As Object, e As EventArgs) Handles txtCotizacionDolar.Enter
      If Not Decimal.TryParse(txtCotizacionDolar.Text, _cotizacionDolar_Prev) Then
         _cotizacionDolar_Prev = 0
      End If
   End Sub

   Private Sub cmbFormula_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFormula.SelectedValueChanged
      TryCatched(Sub() If Not _cargandoComboFormula And Not _cargandoProductoDesdeCompleto Then CalculaPreciosSegunFormula(True))
   End Sub

   Private Sub btnEditarFormula_Click(sender As Object, e As EventArgs) Handles btnEditarFormula.Click
      TryCatched(
      Sub()
         If _pedidosProductosFormulasActual IsNot Nothing Then
            Using frm = New EstructuraProductos()
               Dim forma = cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma)
               frm.ShowDialog(Me, _pedidosProductosFormulasActual,
                              GetValoresForma(forma:=Nothing),
                              cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma),
                              txtCotizacionDolar.ValorNumericoPorDefecto(0D),
                              StateForm.Actualizar)
            End Using
         End If
      End Sub)
   End Sub


   Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
      TryCatched(Sub() CalcularImpuestoInterno())
   End Sub

   Private Sub txtDescRecPorc1_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc1.Leave
      TryCatched(Sub() CalcularImpuestoInterno())
   End Sub

   Private Sub txtDescRecPorc2_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc2.Leave
      TryCatched(Sub() CalcularImpuestoInterno())
   End Sub

   Private Function GetTipoOperacionSeleccionada() As Entidades.Producto.TiposOperaciones
      If cmbTipoOperacion.SelectedIndex = -1 Then Return Entidades.Producto.TiposOperaciones.NORMAL
      Return DirectCast(cmbTipoOperacion.SelectedItem, Entidades.Producto.TiposOperaciones)
   End Function

   Private Sub cmbTipoOperacion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoOperacion.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
      TryCatched(Sub() _publicos.CargaComboObservaciones(cmbNota, DirectCast(cmbTipoOperacion.SelectedItem, Entidades.Producto.TiposOperaciones)))
   End Sub

   Private Sub btnHistoricoVentas_Click(sender As Object, e As EventArgs) Handles btnHistoricoVentas.Click
      TryCatched(Sub() AbrirHistoricoVentas())
   End Sub
   Private Sub AbrirHistoricoVentas()
      'If bscProducto2.Enabled Then
      Using frm As New InfVentasDetallePorProductos()
         Dim idCliente As Long? = Nothing
         Dim codigoCliente As Long? = Nothing
         Dim idProducto As String = String.Empty
         If bscCodigoCliente.Selecciono Or bscCliente.Selecciono Then
            If IsNumeric(bscCodigoCliente.Tag) Then
               idCliente = Long.Parse(bscCodigoCliente.Tag.ToString())
            End If
            If IsNumeric(bscCodigoCliente.Text) Then
               codigoCliente = Long.Parse(bscCodigoCliente.Text)
            End If
         End If
         If bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono Then
            idProducto = bscCodigoProducto2.Text
         End If

         If frm.ShowDialogParaBusqueda(idCliente, codigoCliente, idProducto) = Windows.Forms.DialogResult.OK Then
            'If Not String.IsNullOrWhiteSpace(frm.IdProductoDevuelta) Then
            '   bscCodigoProducto2.Text = frm.IdProductoDevuelta
            '   bscCodigoProducto2.PresionarBoton()
            'End If
         End If
      End Using
      'End If
   End Sub

   Private Sub PintarProductosStockNegativo()
      If Not _dtPedidoSinStock Is Nothing Then
         For Each drProducto As DataRow In _dtPedidoSinStock.Rows
            For Each dr As DataGridViewRow In Me.dgvProductos.Rows

               If dr.Cells("IdProducto").Value.ToString() = drProducto("IdProducto").ToString() Then
                  dr.DefaultCellStyle.BackColor = Color.Coral
               End If
            Next
         Next
      End If
   End Sub

   Private Function dr(p1 As String) As Object
      Throw New NotImplementedException
   End Function

   Private Sub CalculosDescuentosRecargos1_ReporteEstado(sender As Object, e As CalculosDescuentosRecargosReporteEstadoEventArgs) Handles CalculosDescuentosRecargos1.ReporteEstado
      Try
         lblEstado.Text = e.Estado
         Application.DoEvents()
      Catch ex As Exception
      End Try
   End Sub

   Private Sub txtCantidadManual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadManual.KeyPress
      Try
         If e.KeyChar = "*" Then
            cmbUM2.Focus()
            cmbUM2.DroppedDown = True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   'Private Sub txtCantidadManual_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadManual.KeyDown
   '   Try
   '      Me.PresionarTab(e)
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   Private Sub cmbUM2_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUM2.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            txtCantidadManual.Select()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbUM2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUM2.SelectedValueChanged
      Try
         SeteaConversionUnidadesMedida()
         ''# En caso de que la unidad de medida seleccionada NO sea la unidad de medida principal del producto, realizo la conversión
         'Dim f = If(Me.bscCodigoProducto2.FilaDevuelta IsNot Nothing, Me.bscCodigoProducto2.FilaDevuelta, Nothing)
         'If f IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.txtCantidadManual.Text) Then
         '   Me.txtCantidad.Text = Me.RealizarConversionUnidadesMedida(CDec(Me.txtCantidadManual.Text), CDec(f.Cells("Conversion").Value), Me.cmbUM2).ToString()
         'End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantidadManual_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadManual.TextChanged
      TryCatched(Sub() SeteaConversionUnidadesMedida())
   End Sub

   Private Sub chbCajaPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbCajaPedido.CheckedChanged
      '-- Habilita o Deshabilita.- --
      cmbCajaPedido.Enabled = chbCajaPedido.Checked

      If Not Me.chbCajaPedido.Checked Then
         Me.cmbCajaPedido.SelectedIndex = -1
      Else
         If Me.cmbCajaPedido.Items.Count > 0 Then
            Me.cmbCajaPedido.SelectedIndex = -1
         End If
      End If
   End Sub

   'Private Sub txtCotizacionDolar_TextChanged(sender As Object, e As EventArgs) Handles txtCotizacionDolar.TextChanged
   '   If Me._estaCargando Then Exit Sub

   '   Try
   '      If Reglas.Publicos.ActualizaPreciosDeVenta Then
   '         Me.RecalcularTodo(recuperaCosto:=False, desdeListaPrecios:=True)
   '      End If
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   '   End Try
   'End Sub
End Class