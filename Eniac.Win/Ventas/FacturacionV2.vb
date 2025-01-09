Imports Eniac.Entidades.Entidad

Public Class FacturacionV2
   Implements IFacturacion

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub


   Public Sub New(idcliente As Long, idTipoComprobante As String, idProducto As String)
      Me.New()

      Dim ocli = New Reglas.Clientes()
      Dim cli = ocli.GetUno(idcliente)
      _CodigoClienteService = cli.CodigoCliente
      _IdTipoComprobanteService = idTipoComprobante
      _IdProductoService = idProducto
   End Sub

#End Region

#Region "Constantes"

   Private Const funcionActual As String = "FacturacionV2"
   Private Const funcionSupervisor As String = "Ventas"

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

   Private _titCheques As Dictionary(Of String, String)
   Private _titPercepcionesIVA As Dictionary(Of String, String)
   Private _tituloOriginal As String
   Private _modalidad As Entidades.Producto.Modalidades

   Private _cargaComboDestino As Boolean = False

   Dim oLineaVP As Eniac.Entidades.VentaProducto

   Private _codigoBarrasCompleto As String

   '-- REQ-41996.- -------------------------------------------------------
   Private _cambioListaPrecio As Integer? = Nothing
   '----------------------------------------------------------------------

   Private _SoloCopia As Boolean
   Private _SeleccionoInvocados As Entidades.Publicos.SiNoTodos
   Private _mantenerVendedor As Boolean = False
   Private _mantenerCaja As Boolean = False
   Private _CajaAlAbrir As Integer = 0
   Private _ventasContactos As List(Of Entidades.ClienteContacto)
   Private _ventasDespachos As List(Of Entidades.VentaDespacho)

   Private _titContactos As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titObservaciones As Dictionary(Of String, String)

   Private _facturacionMantieneElClienteDefault As Long

   Private _utilizaCentroCostos As Boolean = False
   Private _permiteCambiarCentroCostosVentas As Boolean = False
   Private _puedeEditarDolar As Boolean

   Private _clienteTieneDescRec As Boolean = False

   Private _FormaPagoCoeficiente As Integer = 0

   Private _cantLineas As Integer
   Private _descRec1 As Decimal
   Private _descRec2 As Decimal
   Private _descRecPorc1 As Decimal
   Private _descRecPorc2 As Decimal
   Private _modificoDescuentos As Boolean
   Private _txtCantidad_prev As Decimal?
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private ventaProducto As Entidades.VentaProducto

   Private _ventasProductos As System.Collections.Generic.List(Of Entidades.VentaProducto)
   Private _ventasProductosFormulasActual As DataTable
   Private _ventasProductosFormulas As Dictionary(Of Entidades.VentaProducto, DataTable) = New Dictionary(Of Entidades.VentaProducto, DataTable)()
   Private _turnosInvocados As List(Of Entidades.TurnoCalendario)
   Private _crmInvocados As List(Of Entidades.CRMNovedad)

   Private _subTotales As System.Collections.Generic.List(Of Entidades.VentaImpuesto)
   Private _estado As Estados
   Private _publicos As Publicos
   Private _numeroComprobante As Integer
   Private _clienteE As Entidades.Cliente
   Private _comprobantesSeleccionados As List(Of Entidades.Venta)
   Private _ModificaDetalle As String
   Private _ModificaDetalleRT As String
   Private _editarProductoDesdeGrilla As Boolean
   Private _cheques As List(Of Entidades.Cheque)
   Private _tarjetas As List(Of Entidades.VentaTarjeta)
   Private _transferencias As List(Of Entidades.VentaTransferencia)
   Private _ventasObservaciones As List(Of Entidades.VentaObservacion)
   Private _ventasObservacionesCHTarjeta As List(Of Entidades.VentaObservacion)
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
   Private _fc As FacturacionComunes
   Private _baseImponibleIIBB As Decimal = 0
   Private DescRecPorc1RT As Decimal = 0
   Private DescRecPorc2RT As Decimal = 0
   Private DescRecRT As Decimal = 0
   Private TotalProductoRT As Decimal = 0
   Private _DescRecGralPorc As Decimal = 0
   Private _blnCajasModificables As Boolean = True
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja
   Private _ConfiguracionImpresoras As Boolean
   Private _decimalesEnDescRec As Integer
   Private _decimalesAMostrarEnTotalXProducto As Integer
   Private _decimalesAMostrarEnPrecio As Integer
   Private _decimalesRedondeoEnPrecio As Integer   '4
   Private _decimalesEnCantidad As Integer = 2
   Private _decimalesMostrarEnCantidad As Integer = 2
   Private _decimalesEnTamanio As Integer = 2      'En el ABM tiene 3, habria que hacerlo seteable.
   Private _decimalesEnKilos As Integer = 3
   Private _decimalesEnTotales As Integer = 2

   Private _formatoEnKilos As String
   Private _formatoEnTotales As String
   Private _formatoAMostrarEnPrecio As String

   Private _ceroEnPrecio As String

   Private _InvocaPedido As Boolean = False
   Private _IdCategoriaFiscalOriginal As Short = 0
   Private _DescuentosRecargosProd As Reglas.DescuentoRecargoProducto

   Private _solicitaPrecioVentaPorTamano As Boolean = False

   Private _dtActividades As DataTable

   Private _ventasConProductosEnCero As Boolean

   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""
   Private _CodigoClienteService As Long = 0
   Private _IdTipoComprobanteService As String = String.Empty
   Private _IdProductoService As String
   Public ConsultarAutomaticamente As Boolean = False

   Private _facturacionCoeficienteNegativoRecuperaPrecioUltimaVenta As Boolean
   Private _cargandoComboFormula As Boolean = False
   Private _cargandoProductoDesdeCompleto As Boolean = False
   Private _solicitaModificarFormulaLuegoDelProducto As Boolean = True
   Private _calculaPreciosSegunFormula As Boolean

   Private _vendedorPorClave As Entidades.Empleado
   Private _nroOferta As Integer

   Private _recalcularEfectivoAlCargarTarjeta As Boolean
   Private _continuarConFaltaDeCredito As Boolean = True
   Private _precioOriginal As Decimal = 0

   '# Comprobantes con fecha de devolución
   Private _modificoFechaDevolucion As Boolean
   Private _titRemitoTransporte As Dictionary(Of String, String)

   Private _VisualizaPC As String

   '# Lotes Seleccionados
   Private _lotesSeleccionados As DataTable
   Private _nrosSerieSeleccionados As List(Of Entidades.ProductoNroSerie)

   Private _idTipoObservacion As Short
   '-.PE-32995.-
   Private _idUsuario As String = actual.Nombre
   '-- 33202.- --
   Private _idListaAux As Integer = -1
   Private ActualizaPrecios As Boolean = Reglas.Publicos.ActualizaPreciosDeVenta()

   Private _idEmbarcacion As Long = 0
   Private _codigoEmbarcacion As Long = 0
   Private _nombreEmbarcacion As String
   Private _idCategoriaEmbarcacion As Integer
   Private _nombreCategoriaEmbarcacion As String

   Private _idCama As Long = 0
   Private _codigoCama As String
   Private _idNave As Short = 0
   Private _nombreNave As String
   Private _idCategoriaCama As Integer
   Private _nombreCategoriaCama As String

   '-- REQ-35220.- --------------------------------------------------------------------
   Public Property MovAtributo01 As Entidades.AtributoProducto
   Public Property MovAtributo02 As Entidades.AtributoProducto
   Public Property MovAtributo03 As Entidades.AtributoProducto
   Public Property MovAtributo04 As Entidades.AtributoProducto

   '-- REQ-35488.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
   Public Property sucOrigen As Integer = actual.Sucursal.Id
   Public Property depOrigen As Integer
   Public Property depOrigenRT As Integer
   Public Property ubiOrigen As Integer
   Public Property ubiOrigenRT As Integer


   Private flackCargaProductos As Boolean = True
   '-----------------------------------------------------------------------------------
#End Region

#Region "Campos Busqueda"
   Private Const BusquedaClienteSecundaria_DOMICILIO As String = "DOMICILIO"
   Private Const BusquedaClienteSecundaria_CUIT As String = "CUIT"
   Private Const BusquedaClienteSecundaria_EMBARCACION As String = "EMBARCACION"
   Private Const BusquedaClienteSecundaria_CAMA As String = "CAMA"
#End Region

   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

#End Region

#Region "Propiedades"

   Private _cierraAutomaticamente As Boolean = False
   Public Property CierraAutomaticamente() As Boolean
      Get
         Return Me._cierraAutomaticamente
      End Get
      Set(value As Boolean)
         Me._cierraAutomaticamente = value
      End Set
   End Property

   Private _soloComprobantesElectronicos As Boolean = False
   Public Property SoloComprobantesElectronicos() As Boolean
      Get
         Return Me._soloComprobantesElectronicos
      End Get
      Set(value As Boolean)
         Me._soloComprobantesElectronicos = value
      End Set
   End Property

   Private _soloComprobantesPedidos As Boolean = False
   Public Property SoloComprobantesPedidos() As Boolean
      Get
         Return Me._soloComprobantesPedidos
      End Get
      Set(value As Boolean)
         Me._soloComprobantesPedidos = value
      End Set
   End Property


   'vml 22/09/12 - contabilidad
   Private _tablaAsientos As DataTable
   Public Property tablaAsientos() As DataTable
      Get
         Return _tablaAsientos
      End Get
      Set(value As DataTable)
         _tablaAsientos = value
      End Set
   End Property

   'vml de donde viene?
   Private _vieneDeOrganizarEntregas As Boolean = False
   Public Property vieneDeOrganizarEntregas() As Boolean
      Get
         Return _vieneDeOrganizarEntregas
      End Get
      Set(value As Boolean)
         _vieneDeOrganizarEntregas = value
      End Set
   End Property

   'vml objeto pedido a editar
   Private _PedidoAEditar As Entidades.Venta
   Public Property PedidoAEditar() As Entidades.Venta
      Get
         Return Me._PedidoAEditar
      End Get
      Set(value As Entidades.Venta)
         Me._PedidoAEditar = value
      End Set
   End Property


#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try
         bscObservacion.MaxLengh = Reglas.Publicos.Facturacion.FacturacionCantidadCaracteresObservaciones.ToString()


         Me._publicos = New Publicos()
         Me._fc = New FacturacionComunes()

         _titCheques = GetColumnasVisiblesGrilla(dgvCheques)
         _titPercepcionesIVA = GetColumnasVisiblesGrilla(ugPercepcionIVA)
         _solicitaModificarFormulaLuegoDelProducto = Reglas.Publicos.SolicitaModificarFormulaLuegoDelProducto

         _recalcularEfectivoAlCargarTarjeta = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaRecalcularEfectivoAlCargarTarjeta

         Me._cargoBienLaPantalla = True

         tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpContactos")
         _titContactos = GetColumnasVisiblesGrilla(ugContactos)
         tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpObservaciones")
         _titObservaciones = GetColumnasVisiblesGrilla(ugObservaciones)
         tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")

         'Cargo los decimales y seteo tambien los objetos en pantallas.
         _decimalesRedondeoEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         _decimalesAMostrarEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
         _decimalesAMostrarEnTotalXProducto = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto
         _decimalesEnDescRec = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec

         _formatoAMostrarEnPrecio = String.Format("N{0}", _decimalesAMostrarEnPrecio)
         _formatoEnTotales = String.Format("N{0}", _decimalesEnTotales)
         _formatoEnKilos = String.Format("N{0}", _decimalesEnKilos)

         _ceroEnPrecio = 0D.ToString(_formatoAMostrarEnPrecio)

         Me._ventasConProductosEnCero = Reglas.Publicos.VentasConProductosEnCero

         txtPrecio.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         txtDescRec.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         txtTotalProducto.Formato = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()
         dgvProductos.Columns("Precio").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         dgvProductos.Columns("DescuentoRecargo").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString() 'Oculto por el momento
         dgvProductos.Columns("PrecioNeto").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         dgvProductos.Columns("Importe").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            Me._decimalesEnCantidad = 0
            Me.txtCantidad.Formato = "N0"
            Me.txtCantidadRT.Formato = "N0"
            Me.txtCantidadManual.Formato = "N0"
            Me.txtCantidadManualRT.Formato = "N0"
         Else
            _decimalesEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad
            _decimalesMostrarEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad
            Me.txtCantidad.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
            Me.txtCantidadRT.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
            Me.txtCantidadManual.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
            Me.txtCantidadManualRT.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
         End If
         'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         Me.dgvProductos.Columns("Cantidad").DefaultCellStyle.Format = "N" + Me._decimalesMostrarEnCantidad.ToString()
         Me.dgvRemitoTransp.Columns("grtCantidad").DefaultCellStyle.Format = "N" + Me._decimalesMostrarEnCantidad.ToString()

         Me.dgvProductos.Columns("CantidadManual").DefaultCellStyle.Format = "N" + Me._decimalesMostrarEnCantidad.ToString()
         Me.dgvRemitoTransp.Columns("CantidadManualRT").DefaultCellStyle.Format = "N" + Me._decimalesMostrarEnCantidad.ToString()


         Me.txtKilos.Formato = "N" + Me._decimalesEnKilos.ToString()
         Me.txtKilosModDesc.Formato = "N" + Me._decimalesEnKilos.ToString()
         Me.dgvProductos.Columns("Kilos").DefaultCellStyle.Format = "N" + Me._decimalesEnKilos.ToString()
         Me.dgvRemitoTransp.Columns("grtKilos").DefaultCellStyle.Format = "N" + Me._decimalesEnKilos.ToString()
         '-------------------------------------------------------------------------------------------------------------------------
         _cargaComboDestino = True
         _publicos.CargaComboDepositos(cmbDepositoOrigen, sucOrigen, miraUsuario:=True, permiteEscritura:=True, disponibleventa:=True)
         _publicos.CargaComboDepositos(cmbDepositoRT, sucOrigen, miraUsuario:=True, permiteEscritura:=True, disponibleventa:=True)
         _cargaComboDestino = False

         If cmbDepositoOrigen.Items.Count > 0 Then
            cmbDepositoOrigen.SelectedIndex = 0
            _cargoBienLaPantalla = True
         Else
            _mensajeDeErrorEnCarga = String.Format("El usuario no posee depositos autorizados para la sucursal ({0})", actual.Sucursal.Nombre)
            _cargoBienLaPantalla = False
            Exit Sub
         End If

         _publicos.CargaComboTiposObservaciones(cmbTipoObservacion)

         _idTipoObservacion = New Reglas.TiposObservaciones().GetIdTipoObservacionDefecto()
         '-------------------------------------------------------------------------------------------------------------------------
         'Seguridad de la Lista de Precios
         Dim oUsuario = New Reglas.Usuarios()
         cmbListaDePrecios.Enabled = oUsuario.TienePermisos("Facturacion-ListaDePrecios")

         _puedeEditarDolar = oUsuario.TienePermisos("Facturacion-ModCotizacionDolar")
         txtCotizacionDolar.Enabled = _puedeEditarDolar

         'Seguridad del Descuento/Recargo General
         'Me.txtDescRecGralPorc.ReadOnly = Not oUsuario.TienePermisos( "Clientes-DescRecGeneralPorc")
         txtDescRecGralPorc.Formato = "N" + _decimalesEnDescRec.ToString()
         txtDescRecPorc1.Formato = "N" + _decimalesEnDescRec.ToString()
         txtDescRecPorc2.Formato = "N" + _decimalesEnDescRec.ToString()
         dgvProductos.Columns("DescuentoRecargoPorc1").DefaultCellStyle.Format = "N" + Me._decimalesEnDescRec.ToString()
         dgvProductos.Columns("DescuentoRecargoPorc2").DefaultCellStyle.Format = "N" + Me._decimalesEnDescRec.ToString()

         'Seguridad del Precio y Descuento/Recargo por Producto y Gral
         chbModificaPrecio.Visible = oUsuario.TienePermisos("Facturacion-ModifPrecioProd")
         chbModificaDescRecargo.Visible = oUsuario.TienePermisos("Facturacion-ModifDescRecProd")

         '# La unica forma de que el tilde para modificar el Desc/Rec esté inhabilitado es que no tenga permisos ni tenga el parámetro activado
         If Not oUsuario.TienePermisos("Facturacion-ModifDescRecGral") AndAlso
            Not Reglas.Publicos.Facturacion.FacturacionModificaDescRecGralPorc Then
            Me.chbModificaDescRecGralPorc.Enabled = False
         Else
            Me.chbModificaDescRecGralPorc.Enabled = True
         End If

         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         Me.llbCliente.Visible = oUsuario.TienePermisos("Clientes-PuedeUsarMasInfo")

         lnkProducto.Visible = oUsuario.TienePermisos("Productos")

         btnHistoricoVentas.Visible = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "InfVentasDetallePorProductos")

         '---------------------------------------
         If Me.SoloComprobantesElectronicos Then
            Me._publicos.CargaComboTiposComprobantesElectronicos(Me.cmbTiposComprobantes, "SI")
         ElseIf Me.SoloComprobantesPedidos Then
            Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "PEDIDOSCLIE", , , , True)
         Else
            Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "VENTAS", , , , True)
         End If

         If Me.cmbTiposComprobantes.Items.Count = 0 Then
            Me._ConfiguracionImpresoras = True
         End If


         _tituloOriginal = Text

         _publicos.CargaComboAFIPConceptoCM05(cmbAFIPConceptoCM05, Entidades.AFIPConceptoCM05.TiposConceptosCM05.INGRESOS)

         _publicos.CargaComboDesdeEnum(cmbAFIPWSCodigoAnulacion, GetType(Entidades.Publicos.SiNo))
         _publicos.CargaComboAFIPWSReferenciaTransferencia(cmbAFIPWSReferenciaTransferencia)
         _publicos.CargaComboTipoDocumento(cmbTipoDoc)
         _publicos.CargaComboCategoriasFiscales(cmbCategoriaFiscal)

         '-.PE-32995.-
         Dim rEmpleados = New Reglas.Empleados
         If rEmpleados.GetPorTipo(Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario, False).Count = 0 Then
            'El usuario no es vendedor
            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Else
            'El usuario es vendedor
            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
         End If
         '-----------

         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")

         '-- REQ-31198.- -----------------------------------------------
         '-Carga Clausulas de Venta - Incoterms.-
         _publicos.CargaComboClausulaVentas(cmbClausulaVentas)
         '-Carga Destinos del Comprobante.- 
         _publicos.CargaComboDestinosExportacion(cmbDestinoComprobante)
         '-Carga Destinos del Despacho.- 
         _publicos.CargaComboDestinosExportacion(cmbDestinoDespacho)
         '--------------------------------------------------------------

         _publicos.CargaComboListaDePrecios(cmbListaDePrecios, activa:=True, insertarEnPosicionCero:=Nothing)
         _publicos.CargaComboImpuestos(cmbPorcentajeIva)
         _publicos.CargaComboCentroCostos(cmbCentroCosto)

         _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.Id, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         _publicos.CargaComboTarjetas(cmbTarTarjeta, True)
         'Me._publicos.CargaComboTipoDocumento(Me.cmbTipoDocProveedor)

         '# Tipos de Cheque
         _publicos.CargaComboTiposCheques(cmbTipoCheque)

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
         cmbMonedaVenta.SelectedValue = Reglas.Publicos.Facturacion.FacturacionMonedaPorDefecto

         Me.lblSemaforoRentabilidad.Visible = Reglas.Publicos.Facturacion.FacturacionVisualizaSemaforoUtilidad
         Me.txtSemaforoRentabilidad.Visible = Me.lblSemaforoRentabilidad.Visible
         Me.lblSemaforoPorcentaje.Visible = Me.lblSemaforoRentabilidad.Visible
         If Reglas.Publicos.Facturacion.FacturacionSemaforoCalculoMuestra = Entidades.Publicos.SemaforoCalculoMuestra.ContribucionMarginal.ToString() Then
            lblSemaforoRentabilidad.Text = "CMG"
            lblSemaforoRentabilidadDetalle.Text = "CMG"
            dgvProductos.Columns("ContribucionMarginalPorc").HeaderText = "CMG %"
         End If

         _facturacionMantieneElClienteDefault = Publicos.FacturacionMantieneElClienteDefault

         Me.SeteaDetalles()

         Me._estaCargando = False

         Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         '-- REQ-30773 --
         'Me.chbMercDespachada.Checked = Publicos.MercaderiaDespachada

         Me.tsbInvocarPedidos.Visible = Reglas.Publicos.TieneModuloPedidos

         txtTamanio.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarTamano
         txtUM.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarUM
         pnlTamanio.Visible = txtTamanio.Visible Or txtUM.Visible

         '-- REQ-32381.- -------------------------------------------------------------------------------------------------------------------
         _VisualizaPC = Reglas.Publicos.Facturacion.FacturacionVisualizaPrecioCosto.ToString()
         If _VisualizaPC = Entidades.Publicos.VisualizaPrecioCosto.NOMOSTRAR.ToString() Then
            pnlCosto.Visible = False
         End If
         '----------------------------------------------------------------------------------------------------------------------------------

         pnlRecargoVenta.Visible = oUsuario.TienePermisos("FacturacionV2-VerRecargoVenta")

         pnlPrecioVentaPorTamano.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarPrecioVentaPorTamano
         lblPrecioVentaPorTamano2.Text = String.Empty
         pnlMoneda.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarMoneda
         pnlSemaforoRentabilidadDetalle.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarSemaforoRentabilidadDetalle

         cmbMonedaVenta.Enabled = Reglas.Publicos.Facturacion.FacturacionPermiteFacturarEnOtrasMonedas

         dgvProductos.Columns(Entidades.VentaProducto.Columnas.Tamano.ToString()).Visible = txtTamanio.Visible
         dgvProductos.Columns(Entidades.VentaProducto.Columnas.IdUnidadDeMedida.ToString()).Visible = txtUM.Visible
         dgvProductos.Columns(Entidades.VentaProducto.Columnas.Costo.ToString()).Visible = pnlCosto.Visible
         dgvProductos.Columns(Entidades.VentaProducto.Columnas.PrecioVentaPorTamano.ToString()).Visible = pnlPrecioVentaPorTamano.Visible
         dgvProductos.Columns(Entidades.Moneda.Columnas.NombreMoneda.ToString()).Visible = pnlMoneda.Visible
         dgvProductos.Columns("ContribucionMarginalPorc").Visible = pnlSemaforoRentabilidadDetalle.Visible

         pnlFormula.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarFormula
         dgvProductos.Columns("NombreFormula").Visible = pnlFormula.Visible

         pnlNota.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarNota
         dgvProductos.Columns("Nota").Visible = pnlNota.Visible

         dgvProductos.Columns("Orden").Visible = Reglas.Publicos.Facturacion.FacturacionVisualizaOrden


         _tit = GetColumnasVisiblesGrilla(dgvProductos)
         If Not Reglas.Publicos.FacturacionVisualizaDeposito Then
            _tit.Remove("NombreDeposito")
         End If
         If Not Reglas.Publicos.FacturacionVisualizaUbicacion Then
            _tit.Remove("NombreUbicacion")
         End If

         '-- REQ-34986.- --------------------------------------------------------------------------------------------------------------------------------
         With dgvProductos.Columns("DescripcionAtributo01")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion
            If TipoAtributo01 > 0 Then
               lblAtributo01.Text = .HeaderText
               pnlAtributosProductos01.Visible = True
            End If
         End With
         With dgvProductos.Columns("DescripcionAtributo02")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion
            If TipoAtributo02 > 0 Then
               lblAtributo02.Text = .HeaderText
               pnlAtributosProductos02.Visible = True
            End If
         End With
         With dgvProductos.Columns("DescripcionAtributo03")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03).Descripcion
         End With
         With dgvProductos.Columns("DescripcionAtributo04")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04).Descripcion
         End With
         '-----------------------------------------------------------------------------------------------------------------------------------------------
         _titRemitoTransporte = GetColumnasVisiblesGrilla(Me.dgvRemitoTransp)

         '-- REQ-33524.- -----------------------------------------------------------------------------------------------------
         CargaComboBusquedaDomicilio()
         '-- REQ-33678.- ----------------------
         cmbBusquedaDomicilio.Text = Reglas.Publicos.BusquedaClienteFacturacion
         cmbBusquedaDomicilio.Enabled = True

         '--------------------------------------------------------------------------------------------------------------------

         'VML camio para editar pedidos
         ' si vienen de organizar entregasEdita entonces no llamo el me.nuevo
         If Me._vieneDeOrganizarEntregas Then

            Me.tsbReemplazarComprobantes()

         Else
            'Que pueda ser opcional (por ahora).
            'Me.txtNumeroLote.Visible = Publicos.FacturacionRemitoTranspUtilizaLote
            'Me.lblLote.Visible = Publicos.FacturacionRemitoTranspUtilizaLote

            Me.Nuevo(Publicos.FacturacionMantieneElCliente AndAlso _facturacionMantieneElClienteDefault > 0, False)

         End If

         _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos
         _permiteCambiarCentroCostosVentas = _utilizaCentroCostos AndAlso Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosVentas
         _facturacionCoeficienteNegativoRecuperaPrecioUltimaVenta = Reglas.Publicos.Facturacion.FacturacionCoeficienteNegativoRecuperaPrecioUltimaVenta

         cmbCentroCosto.Visible = _utilizaCentroCostos
         cmbCentroCosto.LabelAsoc.Visible = _utilizaCentroCostos
         'NombreCentroCosto.Visible = _utilizaCentroCostos

         Me.dgvProductos.Columns("IdCentroCosto").Visible = Me._utilizaCentroCostos
         Me.dgvProductos.Columns("NombreCentroCosto").Visible = Me._utilizaCentroCostos

         '# Cantidad convertida e valor de conversión
         Me.dgvProductos.Columns("Cantidad").Visible = Reglas.Publicos.FacturacionVisualizaCantidadConvertida
         Me.pnlCantidadConvertida.Visible = Reglas.Publicos.FacturacionVisualizaCantidadConvertida
         Me.dgvProductos.Columns("Conversion").Visible = Reglas.Publicos.FacturacionVisualizaConversion
         Me.dgvRemitoTransp.Columns("grtCantidad").Visible = Reglas.Publicos.FacturacionVisualizaCantidadConvertida
         Me.dgvRemitoTransp.Columns("ConversionRT").Visible = Reglas.Publicos.FacturacionVisualizaConversion

         If Reglas.Publicos.VisualizaNrosSerie Then
            Me.dgvProductos.Columns("NrosSerie").Visible = True
            Me.dgvRemitoTransp.Columns("NrosSerieRT").Visible = True
            'GAR: 19/10/2017 . Lo agregue pero no lo tomo. revisar el objeto.
            'Me.dgvProductos.Columns("NrosSerie").DisplayIndex = 10
         End If

         If _invocadosCajero IsNot Nothing Then
            InvocarDesdeCajero()
         End If

         btnPlanesTarjetas.Visible = Reglas.Publicos.UtilizaInteresesTarjetas
         tsbCanje.Visible = Reglas.Publicos.Facturacion.FacturacionUtilizaCanje

         'Viene de Service Administracion de Productos en reparacion
         If ConsultarAutomaticamente Then
            bscCodigoCliente.Text = _CodigoClienteService.ToString()
            bscCodigoCliente.PresionarBoton()
         End If
         If Not String.IsNullOrWhiteSpace(_IdTipoComprobanteService) Then
            cmbTiposComprobantes.SelectedValue = _IdTipoComprobanteService
         End If
         If ConsultarAutomaticamente Then
            If Not String.IsNullOrWhiteSpace(_IdProductoService) Then
               bscCodigoProducto2.Text = _IdProductoService.ToString()
               bscCodigoProducto2.PresionarBoton()
            End If

         End If

         CargaTipoComprobanteProducto()

         '-- REQ-33326.- -----------------------------------------------------------------------------------------------------
         SeteaComprobanteSegunFormaDePago()

         '-- REQ-33202.- - Guarda Valor Actual.- -------------------------------
         cmbListaDePrecios.Tag = cmbListaDePrecios.SelectedValue
         '--------------------------------------------------------
         Me._cargoBienLaPantalla = True
      Catch ex As Exception
         _mensajeDeErrorEnCarga = ex.Message
         Me._cargoBienLaPantalla = False
      End Try
   End Sub

#End Region

#Region "Martin - editar pedido"

   Private Sub tsbReemplazarComprobantes()
      Try
         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         'If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         '    Exit Sub
         'End If


         ' Dim ComprobantesAEditar() As List(Of Entidades.Venta)

         Dim IdTipoComprobante As String = String.Empty

         ' Dim oFactAyuda As FacturablesPendientesAyuda

         If Me.dgvFacturables.RowCount > 0 Then
            If Me._comprobantesSeleccionados IsNot Nothing Then
               If Me._comprobantesSeleccionados.Count > 0 Then
                  IdTipoComprobante = Me._comprobantesSeleccionados(0).TipoComprobante.IdTipoComprobante
               End If
            End If
         Else
            IdTipoComprobante = ""
         End If

         'If Me.dgvFacturables.Rows.Count = 0 Then
         '    oFactAyuda = New FacturablesPendientesAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)
         'Else
         '    oFactAyuda = New FacturablesPendientesAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text, DirectCast(Me.dgvFacturables.DataSource, List(Of Entidades.Venta)))
         'End If

         'oFactAyuda.Owner = Me

         'oFactAyuda.ShowDialog()

         Me._comprobantesSeleccionados.Add(Me._PedidoAEditar)


         Me.CargarComprobantesFacturables(_comprobantesSeleccionados)
         Me.CargarProductosFacturables(_comprobantesSeleccionados)
         CargarContactosFacturables(_comprobantesSeleccionados)

         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
            Me.CargarObservacionesFacturables(_comprobantesSeleccionados)
         End If

         Me.LimpiarCamposProductos()
         Me.CalcularTotales()
         Me.CalcularDatosDetalle()
         'Me.CalcularTotales()

         Me._ModificaDetalle = "TODO"
         Me._ModificaDetalleRT = "TODO"

         'If Me._comprobantesSeleccionados.Count > 0 Then
         '    If Not Me.tbcDetalle.Contains(Me.tbpFacturables) Then
         '        Me.tbcDetalle.TabPages.Add(Me.tbpFacturables)
         '    End If
         '    If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
         '        Me.CambiarEstadoControlesDetalle(False)
         '        Me._ModificaDetalle = "SOLOPRECIOS"
         '    End If
         'Else
         '    If Me.tbcDetalle.Contains(Me.tbpFacturables) Then
         '        Me.tbcDetalle.TabPages.Remove(Me.tbpFacturables)
         '    End If
         'End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigoPaciente_BuscadorClick() Handles bscCodigoPaciente.BuscadorClick

      Dim codigoPaciente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoPaciente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoPaciente.Text.Trim.Length > 0 Then
            codigoPaciente = Long.Parse(Me.bscCodigoPaciente.Text.Trim())
         End If

         '# Valido que esté configurado la categoria para los Pacientes
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaPaciente) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Pacientes. Debe configurarla para poder continuar.")
            Exit Sub
         End If

         Me.bscCodigoPaciente.Datos = oClientes.GetFiltradoPorCodigo(codigoPaciente, True, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCodigoPaciente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoPaciente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPaciente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            ShowError(ex)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscPaciente_BuscadorClick() Handles bscPaciente.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscPaciente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes

         '# Valido que esté configurado la categoria para los Pacientes
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaPaciente) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Pacientes. Debe configurarla para poder continuar.")
            Exit Sub
         End If

         Me.bscPaciente.Datos = oClientes.GetFiltradoPorNombre(Me.bscPaciente.Text.Trim(), True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscPaciente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscPaciente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPaciente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            ShowError(ex1)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoDoctor_BuscadorClick() Handles bscCodigoDoctor.BuscadorClick

      Dim codigoDoctor As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoDoctor)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoDoctor.Text.Trim.Length > 0 Then
            codigoDoctor = Long.Parse(Me.bscCodigoDoctor.Text.Trim())
         End If

         '# Valido que esté configurado la categoria para los Doctores
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaDoctor) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Doctores. Debe configurarla para poder continuar.")
            Exit Sub
         End If

         Me.bscCodigoDoctor.Datos = oClientes.GetFiltradoPorCodigo(codigoDoctor, True, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaDoctor))
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCodigoDoctor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoDoctor.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosDoctor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            ShowError(ex1)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscDoctor_BuscadorClick() Handles bscDoctor.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscDoctor)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes

         '# Valido que esté configurado la categoria para los Doctores
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaDoctor) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Doctores. Debe configurarla para poder continuar.")
            Exit Sub
         End If

         Me.bscDoctor.Datos = oClientes.GetFiltradoPorNombre(Me.bscDoctor.Text.Trim(), True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaDoctor))
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscDoctor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDoctor.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosDoctor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            ShowError(ex1)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dtpFechaDevolucion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDevolucion.ValueChanged
      Try
         Me._modificoFechaDevolucion = True
         Me.CalcularFechaDiasDevolucion()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub rbCantDiasFechaDevolucion_CheckedChanged(sender As Object, e As EventArgs) Handles rbCantDiasFechaDevolucion.CheckedChanged
      Try
         Me.txtCantDiasFechaDevolucion.Enabled = Me.rbCantDiasFechaDevolucion.Checked
         Me.dtpFechaDevolucion.Enabled = Not Me.rbCantDiasFechaDevolucion.Checked
         If Me.rbCantDiasFechaDevolucion.Checked Then
            Me.CalcularFechaDiasDevolucion()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub rbFechaDevolucion_CheckedChanged(sender As Object, e As EventArgs) Handles rbFechaDevolucion.CheckedChanged
      Try
         Me.dtpFechaDevolucion.Enabled = Me.rbFechaDevolucion.Checked
         Me.txtCantDiasFechaDevolucion.Enabled = Not Me.rbFechaDevolucion.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantDiasFechaDevolucion_Leave(sender As Object, e As EventArgs) Handles txtCantDiasFechaDevolucion.Leave
      Try
         Me.CalcularFechaDiasDevolucion()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dtpFechaDevolucion_Leave(sender As Object, e As EventArgs) Handles dtpFechaDevolucion.Leave
      Try
         Me.CalcularFechaDiasDevolucion()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub Grabar(tecla As Keys)
      If cmbCajas.SelectedIndex < 0 Then
         Exit Sub
      End If
      Dim caja As Entidades.CajaNombre = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, Integer.Parse(cmbCajas.SelectedValue.ToString()))
      Dim idTipoComprobanteNuevo As String = String.Empty

      If tecla.Equals(Keys.F3) Then
         If String.IsNullOrWhiteSpace(caja.IdTipoComprobanteF3) Then
            If Reglas.Publicos.Facturacion.FacturacionPermiteCobroTarjetaAutomatico Then
               If Not InsertarTarjetaTeclaRapidaF3() Then
                  Exit Sub
               End If
            Else
               Exit Sub
            End If
         Else
            idTipoComprobanteNuevo = caja.IdTipoComprobanteF3
         End If

      ElseIf tecla.Equals(Keys.F4) Then
         If Not String.IsNullOrWhiteSpace(caja.IdTipoComprobanteF4) Then
            idTipoComprobanteNuevo = caja.IdTipoComprobanteF4
         End If
      End If

      If Not String.IsNullOrWhiteSpace(idTipoComprobanteNuevo) Then
         Dim existe As Boolean = False
         For Each tpCom As Entidades.TipoComprobante In DirectCast(cmbTiposComprobantes.DataSource, List(Of Entidades.TipoComprobante))
            If tpCom.IdTipoComprobante = idTipoComprobanteNuevo Then
               cmbTiposComprobantes.SelectedValue = idTipoComprobanteNuevo
               existe = True
            End If
         Next
         If Not existe Then
            ShowMessage(String.Format("El tipo de comprobante {0} configurado en la Caja {1} como Comprobante de {2} no está habilitado. Por favor verifique y reintente.",
                                      idTipoComprobanteNuevo, cmbCajas.Text, tecla.ToString()))
            Exit Sub
         End If
      End If

      Me.tsbGrabar.PerformClick()
   End Sub

   Public Sub SetCacheCalculosDescuentosRecargos(cache As Reglas.BusquedasCacheadas)
      CalculosDescuentosRecargos1.Inicializar(cache)
   End Sub
   Private Sub FacturacionV2_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
      If Visible Then
         If Publicos.FacturacionMantieneElCliente AndAlso _facturacionMantieneElClienteDefault > 0 Then
            NavegacionDesdeClienteSegunParametros()
         End If
      End If
   End Sub

   Private Sub FacturacionV2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         If _ConfiguracionImpresoras Then
            ShowMessage("No Existe la PC en Configuraciones/Impresoras")
            FormEnabled(False, {grbCliente, tbcDetalle}, tspFacturacion, {tsbSalir})
            'Me.Close()
         End If

         If Not CalculosDescuentosRecargos1.Inicializado Then
            Try
               Me.Enabled = False
               CalculosDescuentosRecargos1.Inicializar()
            Finally
               lblEstado.Text = String.Empty
               Me.Enabled = True
            End Try
         End If

         If _cargoBienLaPantalla Then
            If _invocadosCajero Is Nothing Then
               Dim facturacionSolicitaVendedorAlAbrir As Boolean = Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorAlAbrir
               Dim facturacionSolicitaCajaAlAbrir As Boolean = Reglas.Publicos.Facturacion.FacturacionSolicitaCajaAlAbrir
               If facturacionSolicitaVendedorAlAbrir Or facturacionSolicitaCajaAlAbrir Then
                  Using frm As SeleccionVendedorDefecto = New SeleccionVendedorDefecto()
                     If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                        If facturacionSolicitaVendedorAlAbrir Then
                           cmbVendedor.SelectedItem = GetVendedorCombo(frm.Vendedor.IdEmpleado)
                           cmbVendedor.Enabled = False
                           _mantenerVendedor = True
                        End If

                        If facturacionSolicitaCajaAlAbrir Then
                           cmbCajas.SelectedValue = frm.IdCaja
                           _CajaAlAbrir = Integer.Parse(frm.IdCaja.ToString())
                           SeteaColorGroupboxCliente()
                           cmbCajas.Enabled = False
                           _mantenerCaja = True
                        End If
                     End If
                  End Using
               End If
            Else
               cmbVendedor.Enabled = False
               If Not String.IsNullOrWhiteSpace(_IdTipoComprobanteService) Then
                  If cmbTiposComprobantes.SelectedIndex = -1 Then
                     ShowMessage("Comprobante no se encuentra habilitado en esta PC o Usuario no tiene Permisos necesarios , verifique configuraciones")
                     _ventasProductos.Clear()
                     dgvProductos.DataSource = _ventasProductos.ToArray()
                     dgvRemitoTransp.DataSource = _ventasProductos.ToArray()
                     Close(DialogResult.Cancel)
                  Else
                     cmbTiposComprobantes.Enabled = False
                  End If
               End If
            End If
         End If
         bscCodigoCliente.Focus()
         If Not Me._cargoBienLaPantalla Then
            MessageBox.Show(_mensajeDeErrorEnCarga, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private _presionoElShift As Boolean = False

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Or keyData = Keys.F3 Or keyData = (Keys.F4 Or Keys.Shift) Or keyData = (Keys.F3 Or Keys.Shift) Then
         _presionoElShift = keyData = (Keys.F4 Or Keys.Shift) Or keyData = (Keys.F3 Or Keys.Shift)
         If tsbGrabar.Visible And tsbGrabar.Enabled Then
            Grabar(keyData)
         End If
      ElseIf keyData = Keys.F5 Then
         tsbNuevo.PerformClick()
      ElseIf keyData = Keys.F6 Then
         btnHistoricoVentas.PerformClick()
      ElseIf keyData = Keys.F7 Then
         btnBuscarProducto.PerformClick()
      ElseIf keyData = Keys.F8 Then
         Try
            tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
            txtCantidadManual.Focus()
         Catch ex As Exception
            ShowError(ex)
         End Try
      ElseIf keyData = Keys.F9 Then
         If Not tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
            tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
            If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
               bscProducto2.Focus()
            Else
               bscCodigoProducto2.Focus()
            End If
         Else
            tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpRemitoTransp")
            bscCodigoProducto2RT.Focus()
         End If
      ElseIf keyData = Keys.F11 Then
         If Not tbcDetalle.SelectedTab.Key = "tbpPagos" Then
            tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
         Else
            If btnPlanesTarjetas.Visible Then
               btnPlanesTarjetas.PerformClick()
            End If
         End If
      ElseIf keyData = Keys.F12 Then
         tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpTotales")
         txtDescRecGralPorc.Focus()
      ElseIf keyData = Keys.Escape Then
         If Not tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
            btnLimpiarProducto.PerformClick()
         Else
            btnLimpiarProductoRT.PerformClick()
         End If
      ElseIf keyData = (Keys.Add Or Keys.Control) Then
         If Not tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
            btnInsertar.PerformClick()
         Else
            btnInsertarRT.PerformClick()
         End If
      ElseIf keyData = (Keys.G Or Keys.Control) Then
         If Not tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
            If dgvProductos.RowCount > 0 Then
               dgvProductos.FirstDisplayedScrollingRowIndex = dgvProductos.Rows.Count - 1
               dgvProductos.Rows(dgvProductos.Rows.Count - 1).Selected = True
               dgvProductos.SelectedRows(0).Cells("IdProducto").Selected = True
            End If
            dgvProductos.Focus()
         Else
            If dgvRemitoTransp.RowCount > 0 Then
               dgvRemitoTransp.FirstDisplayedScrollingRowIndex = dgvRemitoTransp.Rows.Count - 1
               dgvRemitoTransp.Rows(dgvRemitoTransp.Rows.Count - 1).Selected = True
               dgvRemitoTransp.SelectedRows(0).Cells("grtIdProducto").Selected = True
            End If
            dgvRemitoTransp.Focus()
         End If
      ElseIf keyData = (Keys.Subtract Or Keys.Control) Or keyData = (Keys.OemMinus Or Keys.Control) Then
         If Not tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
            If dgvProductos.SelectedRows.Count > 0 Then
               btnEliminar.PerformClick()
               If dgvProductos.Rows.Count > 0 Then
                  dgvProductos.Focus()
               Else
                  If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
                     bscProducto2.Focus()
                  Else
                     bscCodigoProducto2.Focus()
                  End If
               End If
            End If
         Else
            If dgvRemitoTransp.SelectedRows.Count > 0 Then
               btnEliminarRT.PerformClick()
               If dgvRemitoTransp.Rows.Count > 0 Then
                  dgvRemitoTransp.Focus()
               Else
                  bscCodigoProducto2RT.Focus()
               End If
            End If
         End If
      ElseIf keyData = (Keys.T Or Keys.Control) Then
         tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
         tbcPagosTarChe.SelectedTab = tbpPagosTarjetas
      ElseIf keyData = (Keys.H Or Keys.Control) Then
         tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
         tbcPagosTarChe.SelectedTab = tbpPagosCheques
      ElseIf keyData = (Keys.F Or Keys.Control) Then
         tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
         tbcPagosTarChe.SelectedTab = tbpTransferencias
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   ''''Private Sub Facturacion_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
   ''''   Select Case e.KeyCode
   ''''      Case Keys.F5
   ''''         'tsbNuevo.PerformClick()
   ''''         'Case Keys.F4
   ''''         '   If e.Shift Then
   ''''         '      Me._presionoElShift = True
   ''''         '   End If
   ''''         '   If Me.tsbGrabar.Enabled Then
   ''''         '      Me.tsbGrabar.PerformClick()
   ''''         '   End If
   ''''         '#####################################################
   ''''         '# Se iguala al comportamiento de Facturación Rápida #
   ''''         '#####################################################
   ''''      ''''''''Case Keys.F4, Keys.F3
   ''''      ''''''''   If e.Shift Then
   ''''      ''''''''      Me._presionoElShift = True
   ''''      ''''''''   End If
   ''''      ''''''''   If Me.tsbGrabar.Visible And Me.tsbGrabar.Enabled Then
   ''''      ''''''''      Grabar(e.KeyCode)
   ''''      ''''''''   End If
   ''''      'Case Keys.F6
   ''''      '   Try
   ''''      '      Me.AbrirHistoricoVentas()
   ''''      '   Catch ex As Exception
   ''''      '      ShowError(ex)
   ''''      '   End Try
   ''''      'Case Keys.F7
   ''''      '   Try
   ''''      '      Me.BuscarProductoConConsultaPrecios()
   ''''      '   Catch ex As Exception
   ''''      '      ShowError(ex)
   ''''      '   End Try
   ''''      'Case Keys.F8
   ''''      '   Try
   ''''      '      tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
   ''''      '      Me.txtCantidadManual.Focus()
   ''''      '   Catch ex As Exception
   ''''      '      ShowError(ex)
   ''''      '   End Try
   ''''      'Case Keys.F9
   ''''      '   If Not Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
   ''''      '      Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
   ''''      '      If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
   ''''      '         Me.bscProducto2.Focus()
   ''''      '      Else
   ''''      '         Me.bscCodigoProducto2.Focus()
   ''''      '      End If
   ''''      '   Else
   ''''      '      Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpRemitoTransp")
   ''''      '      Me.bscCodigoProducto2RT.Focus()
   ''''      '   End If
   ''''      'Case Keys.F11
   ''''      '   If Not tbcDetalle.SelectedTab.Key = "tbpPagos" Then
   ''''      '      Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
   ''''      '   Else
   ''''      '      If btnPlanesTarjetas.Visible Then
   ''''      '         btnPlanesTarjetas.PerformClick()
   ''''      '      End If
   ''''      '   End If
   ''''      'Case Keys.F12
   ''''      '   Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpTotales")
   ''''      '   Me.txtDescRecGralPorc.Focus()
   ''''      'Case Keys.Add
   ''''      '   If e.Control Then
   ''''      '      If Not Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
   ''''      '         Me.btnInsertar.PerformClick()
   ''''      '      Else
   ''''      '         Me.btnInsertarRT.PerformClick()
   ''''      '      End If
   ''''      '   End If
   ''''      Case Keys.Subtract, Keys.OemMinus
   ''''         If e.Control Then
   ''''            If Not Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
   ''''               If Me.dgvProductos.SelectedRows.Count > 0 Then
   ''''                  Me.btnEliminar.PerformClick()
   ''''                  If Me.dgvProductos.Rows.Count > 0 Then
   ''''                     Me.dgvProductos.Focus()
   ''''                  Else
   ''''                     If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
   ''''                        Me.bscProducto2.Focus()
   ''''                     Else
   ''''                        Me.bscCodigoProducto2.Focus()
   ''''                     End If
   ''''                  End If
   ''''               End If
   ''''            Else
   ''''               If Me.dgvRemitoTransp.SelectedRows.Count > 0 Then
   ''''                  Me.btnEliminarRT.PerformClick()
   ''''                  If Me.dgvRemitoTransp.Rows.Count > 0 Then
   ''''                     Me.dgvRemitoTransp.Focus()
   ''''                  Else
   ''''                     Me.bscCodigoProducto2RT.Focus()
   ''''                  End If
   ''''               End If
   ''''            End If

   ''''         End If
   ''''         'Case Keys.Escape
   ''''         '   If Not Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
   ''''         '      Me.btnLimpiarProducto.PerformClick()
   ''''         '   Else
   ''''         '      Me.btnLimpiarProductoRT.PerformClick()
   ''''         '   End If
   ''''         '   'Case Keys.D
   ''''         '   '   If e.Control Then
   ''''         '   '      Me.cmbVendedor.Focus()
   ''''         '   '   End If
   ''''         '   'Case Keys.F
   ''''         '   '   If e.Control Then
   ''''         '   '      Me.dtpFecha.Focus()
   ''''         '   '   End If
   ''''         'Case Keys.G
   ''''         '   If e.Control Then
   ''''         '      If Not Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
   ''''         '         If Me.dgvProductos.RowCount > 0 Then
   ''''         '            Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
   ''''         '            Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
   ''''         '            Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Selected = True
   ''''         '         End If
   ''''         '         Me.dgvProductos.Focus()
   ''''         '      Else
   ''''         '         If Me.dgvRemitoTransp.RowCount > 0 Then
   ''''         '            Me.dgvRemitoTransp.FirstDisplayedScrollingRowIndex = Me.dgvRemitoTransp.Rows.Count - 1
   ''''         '            Me.dgvRemitoTransp.Rows(Me.dgvRemitoTransp.Rows.Count - 1).Selected = True
   ''''         '            Me.dgvRemitoTransp.SelectedRows(0).Cells("grtIdProducto").Selected = True
   ''''         '         End If
   ''''         '         Me.dgvRemitoTransp.Focus()
   ''''         '      End If

   ''''         '   End If
   ''''         '   'Case Keys.I
   ''''         '   '   If e.Control Then
   ''''         '   '      Me.tsbInvocarComprobantes.PerformClick()
   ''''         '   '   End If
   ''''         '   'Case Keys.J
   ''''         '   '   If e.Control Then
   ''''         '   '      Me.cmbCajas.Focus()
   ''''         '   '   End If
   ''''         '   'Case Keys.L
   ''''         '   '   If e.Control Then
   ''''         '   '      Me.cmbListaDePrecios.Focus()
   ''''         '   '   End If
   ''''         '   'Case Keys.N
   ''''         '   '   If e.Control Then
   ''''         '   '      Me.bscCliente.Focus()
   ''''         '   '   End If
   ''''         '   'Case Keys.P
   ''''         '   '   If e.Control Then
   ''''         '   '      Me.cmbFormaPago.Focus()
   ''''         '   '   End If
   ''''         '   'Case Keys.T
   ''''         '   '   If e.Control Then
   ''''         '   '      Me.cmbTiposComprobantes.Focus()
   ''''         '   '   End If
   ''''      Case Else
   ''''   End Select
   ''''End Sub

   Private Sub txtImporteCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteCheque.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtTitularCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTitularCheque.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub dtpFechaCobro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaCobro.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub dtpFechaEmision_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaEmision.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtCodPostalCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodPostalCheque.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtSucursalBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSucursalBanco.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtNroCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroCheque.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub cmbTipoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoCheque.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtNroOperacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroOperacion.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub bscCodBancos_BuscadorClick() Handles bscCodBancos.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscCodBancos)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscCodBancos.Datos = oBanco.GetFiltradoPorCodigo(Me.bscCodBancos.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodBancos_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCodBancos.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
            Me.txtNroCheque.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscBancos_BuscadorClick() Handles bscBancos.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscBancos)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscBancos.Datos = oBanco.GetFiltradoPorNombre(Me.bscBancos.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscBancos_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscBancos.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
            Me.txtNroCheque.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtTarjetas_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTarjetas.KeyUp
      PresionarTab(e)
   End Sub

   Private Sub txtCheques_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCheques.KeyUp
      PresionarTab(e)
   End Sub

   Private Sub txtTickes_Leave(sender As Object, e As EventArgs)
      TryCatched(Sub() CalcularPagos(False))
   End Sub

   Private Sub txtTickets_KeyUp(sender As Object, e As KeyEventArgs)
      PresionarTab(e)
   End Sub

   Private Sub txtEfectivo_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave
      TryCatched(Sub() CalcularPagos(False))
   End Sub
   Private Sub txtImporteDolares_Leave(sender As Object, e As EventArgs) Handles txtImporteDolares.Leave
      TryCatched(Sub() CalcularPagos(False))
   End Sub

   Private Sub txtEfectivo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtImporteDolares.KeyUp, txtEfectivo.KeyUp
      PresionarTab(e)
   End Sub

   Private Sub txtTransferenciaBancaria_Leave(sender As Object, e As EventArgs) Handles txtTransferenciaBancaria.Leave
      TryCatched(Sub() CalcularPagos(False))
   End Sub

   Private Sub txtTransferenciaBancaria_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTransferenciaBancaria.KeyUp
      'PresionarTab(e)
      If e.KeyCode = Keys.Enter Then
         If Not String.IsNullOrEmpty(Me.txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 Then
            PresionarTab(e)
         Else
            Me.cmbTarTarjeta.Focus()
         End If
      End If
   End Sub

   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click

      Try
         If _ventasProductos.Count = 0 OrElse ShowPregunta("ATENCION: ¿Desea Realizar un Comprobante Nuevo?", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            'If MessageBox.Show("ATENCION: ¿Desea Realizar un Comprobante Nuevo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            Me.Nuevo(False, False)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      '   If dgvProductos.RowCount <> 0 Then
      '      If MessageBox.Show("Quedan productos pendientes de grabar, desea salir de todas formas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.No Then
      '         Me.Close()
      '      End If
      '   Else
      '      Me.Close()
      '   End If

      Me.Close()

   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         ''Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")
         Dim codProd As String = String.Empty
         Me._codigoBarrasCompleto = Me.bscCodigoProducto2.Text.Trim()

         codProd = Me.bscCodigoProducto2.Text.Trim()

         Dim idCliente As Long = 0
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         If Me.cmbListaDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar la lista de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbListaDePrecios.Focus()
            Exit Sub
         End If

         Dim dt As DataTable
         dt = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , , , GetTipoOperacionSeleccionada(), , , , , idCliente, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)

         If dt.Rows.Count > 0 Then
            Me._modalidad = Entidades.Producto.Modalidades.NORMAL
         Else
            codProd = Me.GetCodigoModalidadPeso()
            dt = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , Entidades.Producto.Modalidades.PESO.ToString(), , , , , , , idCliente, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
            If dt.Rows.Count > 0 Then
               Me._modalidad = DirectCast([Enum].Parse(GetType(Entidades.Producto.Modalidades), dt.Rows(0)(Entidades.Producto.Columnas.ModalidadCodigoDeBarras.ToString()).ToString()), Entidades.Producto.Modalidades)  ''   Entidades.Producto.Modalidades.PESO
            Else
               'aca va la pantalla
               '' ''Dim frm As New AvisoProductoInexistente()
               '' ''frm.ShowDialog()
            End If
         End If
         Me.bscCodigoProducto2.Datos = dt
      Catch ex As Exception
         ShowError(ex)
      Finally
         '# Vuelvo a poner la propiedad en False luego de que se haya ejecutado la búsqueda
         _editarProductoDesdeGrilla = False
      End Try
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)

         Dim idCliente As Long = 0
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         If Me.cmbListaDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar la lista de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbListaDePrecios.Focus()
            Exit Sub
         End If

         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , , GetTipoOperacionSeleccionada(), , , , , idCliente)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion, bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         Me._estoyCargandoElProducto = False
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescuento_LostFocus(sender As Object, e As EventArgs) Handles txtDescRec.LostFocus
      Try
         Me.CalcularTotalProducto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecPorc1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecPorc1.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '    Me.txtDescRecPorc2.Focus()
      'End If
      PresionarTab(e)
   End Sub

   Private Sub txtDescRecPorc2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecPorc2.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.bscProducto2.Enabled And Reglas.Publicos.Facturacion.FacturacionModificaDescriProdCantidad Then
            Me.txtKilosModDesc.Focus()
         Else
            If _utilizaCentroCostos And cmbCentroCosto.Enabled Then
               cmbCentroCosto.Focus()
            Else
               If cmbNota.Enabled And cmbNota.Visible Then
                  cmbNota.Focus()
               Else
                  If txtDescRec.ReadOnly Then
                     '-- REQ-32381.- -------------------------------------------------------------------------------------------------------------------
                     If _VisualizaPC = Entidades.Publicos.VisualizaPrecioCosto.MODIFICABLE.ToString() And Not txtCosto.ReadOnly Then
                        txtCosto.Focus()
                     Else
                        Me.btnInsertar.Focus()
                     End If
                     '----------------------------------------------------------------------------------------------------------------------------------
                  Else
                     txtDescRec.Focus()
                  End If
               End If
            End If
         End If
      End If
   End Sub
   Private Sub txtDescRec_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRec.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnInsertar.Focus()
      End If
   End Sub
   Private Sub cmbNota_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbNota.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnInsertar.Focus()
      End If
   End Sub

   Private Sub txtKilosModDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKilosModDesc.KeyDown
      If e.KeyCode = Keys.Enter Then
         If _utilizaCentroCostos Then
            cmbCentroCosto.Focus()
         Else
            If cmbNota.Enabled And cmbNota.Visible Then
               cmbNota.Focus()
            Else
               Me.btnInsertar.Focus()
            End If
         End If
      End If
   End Sub

   Private Sub txtDescRecGralPorc_GotFocus(sender As Object, e As EventArgs) Handles txtDescRecGralPorc.GotFocus
      Me.txtDescRecGralPorc.SelectAll()
   End Sub

   Private Sub txtDescRecGralPorc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecGralPorc.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtTotalGeneral.Focus()
      End If
   End Sub

   Private Sub txtDescRecGralPorc_Leave(sender As Object, e As EventArgs) Handles txtDescRecGralPorc.Leave
      Try
         Me.CalcularDatosDetalle()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtTotalDescRec_LostFocus(sender As Object, e As EventArgs) Handles txtDescRecGral.LostFocus
      Me.CalcularTotales()
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      '-- Procedimiento de Validacion de Campos.- --
      If Not ValidacionGrabaComprobante() Then
         Exit Sub
      End If
      Try
         Cursor = Cursors.WaitCursor
         GrabarComprobante()
         btnInsertarTarjeta.Enabled = True
      Catch ex As Exception
         Dim ex1 = New Entidades.EniacException(ex.Message)
         ShowError(ex, True)
      Finally
         _presionoElShift = False
         Cursor = Cursors.Default
         tsbGrabar.Enabled = True
      End Try
   End Sub
   Private Sub tsbCanje_Click(sender As Object, e As EventArgs) Handles tsbCanje.Click

   End Sub

   Private Sub ProcedimientoDeCanje()
      Using frm As New FacturacionUtilizaCanje()
         '-- Pasa Parametros.- ----------------------------------------
         frm.idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         frm.idListaPrecios = DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios
         frm._clienteE = _clienteE
         frm.fechaCompro = dtpFecha.Value
         frm._categoriaFiscalEmpresa = _categoriaFiscalEmpresa
         frm._cotizacionDolar = txtCotizacionDolar.ValorNumericoPorDefecto(0D)
         frm._valorRedondeo = _decimalesRedondeoEnPrecio
         '-------------------------------------------------------------
         frm.ShowInTaskbar = False
         frm.StartPosition = FormStartPosition.CenterScreen


         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '-- REQ-34986.- ----------------------------------------
            _ventasProductos.Clear()
            SetProductosDataSource()
            CalcularDatosDetalle()
            '-- Setea Tipo de Comprobante.- ------------------------
            cmbTiposComprobantes.SelectedValue = frm.cmbTipoComprobante.SelectedValue

            For Each dr As DataGridViewRow In frm.dgvDetalle.Rows
               '-- Carga Producto.- ----------------
               bscCodigoProducto2.Text = dr.Cells(0).Value.ToString()
               flackCargaProductos = False
               bscCodigoProducto2.PresionarBoton()
               '-- Aloja los datos recuperados.- --
               With MovAtributo01
                  .IdaAtributoProducto = Integer.Parse(dr.Cells("IdaAtributoProducto01").Value.ToString())
                  .Descripcion = dr.Cells("DescripcionAtributo01").Value.ToString()
               End With
               With MovAtributo02
                  .IdaAtributoProducto = Integer.Parse(dr.Cells("IdaAtributoProducto02").Value.ToString())
                  .Descripcion = dr.Cells("DescripcionAtributo02").Value.ToString()
               End With
               With MovAtributo03
                  .IdaAtributoProducto = Integer.Parse(dr.Cells("IdaAtributoProducto03").Value.ToString())
                  .Descripcion = dr.Cells("DescripcionAtributo03").Value.ToString()
               End With
               With MovAtributo04
                  .IdaAtributoProducto = Integer.Parse(dr.Cells("IdaAtributoProducto04").Value.ToString())
                  .Descripcion = dr.Cells("DescripcionAtributo04").Value.ToString()
               End With
               '-- Carga la Cantidad.- -------------
               txtCantidadManual.Text = (Decimal.Parse(dr.Cells(10).Value.ToString()) * DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores).ToString()
               txtCantidadManual.Focus()
               '-------------------------------------------------------
               flackCargaProductos = True
               txtPrecio.Focus()
               btnInsertar.Focus()
               btnInsertar.PerformClick()
            Next
         End If
      End Using
   End Sub
   Private Function ValidacionGrabaComprobante() As Boolean

      '-- REQ-33532.- --
      If Not String.IsNullOrEmpty(bscCodigoChofer.Text) AndAlso String.IsNullOrEmpty(bscCodigoVehiculo.Text) Then
         ShowMessage("Debe asignarse una patente de Vehiculo!")
         tbcDetalle.Tabs("tbpAdicionales").Selected = True
         bscCodigoVehiculo.Focus()
         Return False
      End If
      '-- REQ-31232.- --
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 AndAlso
         DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).Dias > 0 AndAlso
         txtTotalPago.ValorNumericoPorDefecto(0D) <> 0 Then
         ShowMessage("No estan permitidas Notas de Credito a Cuenta Corriente que Posean Pagos!")
         Return False
      End If
      '-- REQ-31198.- -Factura electronica de Exportacion.-
      If tbcDetalle.Tabs("tbpExportacion").Visible Then
         If cmbClausulaVentas.SelectedIndex = -1 Then
            ShowMessage("Debe Seleccionar una Clausula de Venta!")
            tbcDetalle.Tabs("tbpExportacion").Selected = True
            cmbClausulaVentas.Focus()
            Return False

         End If
         If cmbDestinoComprobante.SelectedIndex = -1 Then
            ShowMessage("Debe Seleccionar un Destino de Comprobante!")
            tbcDetalle.Tabs("tbpExportacion").Selected = True
            cmbDestinoComprobante.Focus()
            Return False
         End If
         If dtpFechaPagoExportacion.Enabled AndAlso Not dtpFechaPagoExportacion.Checked Then
            ShowMessage("Debe Cargar la Fecha de Pago del comporbante!")
            tbcDetalle.Tabs("tbpExportacion").Selected = True
            dtpFechaPagoExportacion.Focus()
            Return False
         End If
      End If
      Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)
      If tipoComp.CoeficienteValores = -1 AndAlso tipoComp.Tipo = "VENTAS" AndAlso _tarjetas.Count > 0 Then
         Dim resultado As Windows.Forms.DialogResult
         resultado = MessageBox.Show("Se van a anular los cupones de pagos con Tarjeta, ¿desea continuar?", "Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If resultado = Windows.Forms.DialogResult.No Then
            Return False
         End If
      End If
      '---------------------------------------------------
      Return True

   End Function

   Private _oFactAyuda As FacturablesPendientesAyuda
   Private Sub tsbInvocarComprobantes_Click(sender As Object, e As EventArgs) Handles tsbInvocarComprobantes.Click
      Try
         _SeleccionoInvocados = Entidades.Publicos.SiNoTodos.NO

         _cargaProductoDesdeInvocacion = True

         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            Exit Sub
         End If

         Dim IdTipoComprobante As String = String.Empty

         If Me.dgvFacturables.RowCount > 0 Then
            If Me._comprobantesSeleccionados IsNot Nothing Then
               If Me._comprobantesSeleccionados.Count > 0 Then
                  IdTipoComprobante = Me._comprobantesSeleccionados(0).TipoComprobante.IdTipoComprobante
               End If
            End If
         Else
            IdTipoComprobante = ""
         End If

         If Me.cmbListaDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar la lista de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbListaDePrecios.Focus()
            Exit Sub
         End If

         If _mantenerVendedor AndAlso Reglas.Publicos.Facturacion.MantieneVendedorInvocados <> Entidades.Publicos.VendedorComprobanteInvocado.NO.ToString() Then
            Throw New Exception(String.Format("El sistema está configurado como 'Facturación: Solicita Vendedor al Abrir'=SI y 'Mantiene el vendedor del comprobante Invocado' = {0}. Estos dos parámetros no son compatibles. Por favor verifique la configuración.", Reglas.Publicos.Facturacion.MantieneVendedorInvocados))
         End If

         If Me.dgvFacturables.Rows.Count = 0 Then
            Me._oFactAyuda = New FacturablesPendientesAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), comprobantesSeleccionados:=Nothing)
         Else
            Me._oFactAyuda = New FacturablesPendientesAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), DirectCast(Me.dgvFacturables.DataSource, List(Of Entidades.Venta)))
         End If

         _oFactAyuda.Owner = Me

         _oFactAyuda.ShowDialog()


         '### >>> PR-34956 Señalar y PE-34958 Vialparking
         '        Al invocar comprobantes en dolares que pregunte si desea o no actualizar los precios con  cotizacion actual del dolar
         Dim selec = _oFactAyuda.ComprobantesSeleccionados

         '### >>> PE-37357 
         If selec IsNot Nothing AndAlso selec.Count > 0 Then

            Dim cotizacionDolarDesde = EvaluarCotizacionDolarComprobanteInvocado(selec)
            '### <<< PR-34956 Señalar y PE-34958 Vialparking


            If Not _oFactAyuda.chbSoloCopiar.Checked Then
               CargarComprobantesFacturables(_oFactAyuda.ComprobantesSeleccionados)
            End If

            If Not _oFactAyuda.chbSoloCabecera.Checked Then
               CargarProductosFacturables(_oFactAyuda.ComprobantesSeleccionados)
            End If


            '### >>> PR-34956 Señalar y PE-34958 Vialparking
            If selec.Count > 0 Then
               cmbMonedaVenta.SelectedValue = selec.First().IdMoneda
               If cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.INVOCADO Then
                  txtCotizacionDolar.SetValor(selec.First().CotizacionDolar)
                  _cotizacionDolar_Prev = selec.First().CotizacionDolar
               Else
                  Dim cotizacionDolar_anterior = txtCotizacionDolar.ValorNumericoPorDefecto(0D)
                  RecalcularCotizacionDolar(selec.First().CotizacionDolar, cotizacionDolar_anterior)
               End If
            End If
            '### <<< PR-34956 Señalar y PE-34958 Vialparking


            '-- REQ-33733.- ---------------
            CargaTipoComprobanteProducto()
            '------------------------------

            Me.CargarContactosFacturables(Me._oFactAyuda.ComprobantesSeleccionados)

            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImportaObservDeInvocados Then
               '# Cargo las observaciones generales y detalladas
               Me.CargarObservacionesFacturables(Me._oFactAyuda.ComprobantesSeleccionados)
            End If

            Me.bscCliente.Permitido = False
            Me.bscCodigoCliente.Permitido = False

            Me.LimpiarCamposProductos()
            Me.CalcularTotales()
            Me.CalcularDatosDetalle()
            'Me.CalcularTotales()

            If Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
               Me.CalcularTotalRemitoTransporte()
            End If

            If Not Me._oFactAyuda.chbSoloCopiar.Checked Then
               If Me._comprobantesSeleccionados.Count > 0 Then
                  If Not Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
                     Me.tbcDetalle.Tabs("tbpFacturables").Visible = True
                  End If
                  If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
                     Me.CambiarEstadoControlesDetalle(False)
                     Me.CambiarEstadoControlesDetalleRT(False)
                     Me._ModificaDetalle = "SOLOPRECIOS"
                     Me._ModificaDetalleRT = "NO"
                  ElseIf Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "NO" AndAlso
                         Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
                     Me.CambiarEstadoControlesDetalleRT(False)
                     Me._ModificaDetalle = "NO"
                     Me._ModificaDetalleRT = "NO"
                     txtCotizacionDolar.Enabled = False
                  End If
               Else
                  If Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
                     Me.tbcDetalle.Tabs("tbpFacturables").Visible = False
                  End If
               End If
            End If

            If cmbTiposComprobantes.SelectedIndex > 0 AndAlso cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).InformaLibroIVA AndAlso
               _comprobantesSeleccionados.Any(Function(v) v.ImpuestosVarios.Any(Function(vi) vi.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA)) Then
               _ModificaDetalle = "NO"
               _ModificaDetalleRT = "NO"
            End If

            Me._SoloCopia = Me._oFactAyuda.chbSoloCopiar.Checked
            _SeleccionoInvocados = _oFactAyuda.cmbInvocados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)

         End If

      Catch ex As Exception
         ShowError(ex)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            ShowError(ex)
         End Try
      Finally
         _cargaProductoDesdeInvocacion = False
      End Try
   End Sub

   '### >>> PR-34956 Señalar y PE-34958 Vialparking
   Private Function EvaluarCotizacionDolarComprobanteInvocado(selec As List(Of Entidades.Venta)) As Entidades.Publicos.CotizacionDolarComprobanteInvocado
      Dim cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO

      If selec IsNot Nothing AndAlso selec.Count > 0 AndAlso
         txtCotizacionDolar.ValorNumericoPorDefecto(0D) <> selec.First().CotizacionDolar Then
         Dim primerInvocado = selec.First()

         If selec.First().IdMoneda = Entidades.Moneda.Dolar Then
            If selec.Any(Function(v) v.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString()) Then
               cotizacionDolarDesde = Reglas.Publicos.Facturacion.CotizacionDolarPedidoInvocado
            Else
               cotizacionDolarDesde = Reglas.Publicos.Facturacion.CotizacionDolarComprobanteInvocado
            End If
         ElseIf selec.First().IdMoneda = Entidades.Moneda.Peso Then
            If selec.Any(Function(v) v.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString()) Then
               cotizacionDolarDesde = Reglas.Publicos.Facturacion.CotizacionDolarPedidoPesosInvocado
            Else
               cotizacionDolarDesde = Reglas.Publicos.Facturacion.CotizacionDolarComprobantePesosInvocado
            End If
         End If


         If cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.PREGUNTAR Then
            Dim stbPregunta = New StringBuilder()
            stbPregunta.AppendFormatLine("La valoración del dolar del comprobante invocado ({0}) difiere de la del comprobante invocador ({1})",
                                      primerInvocado.TipoComprobante.Descripcion, cmbTiposComprobantes.Text).AppendLine()
            stbPregunta.AppendFormatLine("   {0}: {1:N2}", primerInvocado.TipoComprobante.Descripcion, primerInvocado.CotizacionDolar)
            stbPregunta.AppendFormatLine("   {0}: {1:N2}", cmbTiposComprobantes.Text, txtCotizacionDolar.ValorNumericoPorDefecto(0D)).AppendLine()

            stbPregunta.AppendFormatLine("¿Desea tomar la valoración del dolar del {0}?", primerInvocado.TipoComprobante.Descripcion)
            If ShowPregunta(stbPregunta.ToString()) = DialogResult.Yes Then
               cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.INVOCADO
            Else
               cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO
            End If
         End If
         'txtCotizacionDolar.SetValor(selec.First().CotizacionDolar)
      End If

      Return cotizacionDolarDesde
   End Function
   '### <<< PR-34956 Señalar y PE-34958 Vialparking

   Private Sub tsbInvocarPedidos_Click(sender As Object, e As EventArgs) Handles tsbInvocarPedidos.Click
      Try
         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            Exit Sub
         End If

         _cargaProductoDesdeInvocacion = True

         Dim IdTipoComprobante As String = "PEDIDO"

         Me._InvocaPedido = True

         If Me.cmbTiposComprobantes.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un Tipo de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         If Me.cmbListaDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar la lista de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbListaDePrecios.Focus()
            Exit Sub
         End If

         Dim oPedidosAyuda As PedidosPendientesAyuda

         If Me.dgvFacturables.Rows.Count = 0 Then
            oPedidosAyuda = New PedidosPendientesAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
         Else
            oPedidosAyuda = New PedidosPendientesAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), DirectCast(Me.dgvFacturables.DataSource, List(Of Entidades.Venta)))
         End If

         oPedidosAyuda.ShowDialog()


         '### >>> PR-34956 Señalar y PE-34958 Vialparking
         '        Al invocar comprobantes en dolares que pregunte si desea o no actualizar los precios con  cotizacion actual del dolar
         Dim selec = oPedidosAyuda.ComprobantesSeleccionados
         Dim cotizacionDolarDesde = EvaluarCotizacionDolarComprobanteInvocado(selec)
         '### <<< PR-34956 Señalar y PE-34958 Vialparking

         '### <<< P-37522 
         If selec IsNot Nothing AndAlso selec.Count > 0 Then


            CargarComprobantesFacturables(oPedidosAyuda.ComprobantesSeleccionados)
            CargarProductosFacturables(oPedidosAyuda.ComprobantesSeleccionados)
            CargarContactosFacturables(oPedidosAyuda.ComprobantesSeleccionados)

            If cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).ImportaObservDeInvocados Then
               CargarObservacionesFacturables(oPedidosAyuda.ComprobantesSeleccionados)
            End If


            '### >>> PR-34956 Señalar y PE-34958 Vialparking
            If selec.Count > 0 Then
               cmbMonedaVenta.SelectedValue = selec.First().IdMoneda
               If cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.INVOCADO Then
                  txtCotizacionDolar.SetValor(selec.First().CotizacionDolar)
                  _cotizacionDolar_Prev = selec.First().CotizacionDolar
               Else
                  Dim cotizacionDolar_anterior = txtCotizacionDolar.ValorNumericoPorDefecto(0D)
                  RecalcularCotizacionDolar(selec.First().CotizacionDolar, cotizacionDolar_anterior)
               End If
            End If
            '### <<< PR-34956 Señalar y PE-34958 Vialparking


            bscCliente.Permitido = False
            bscCodigoCliente.Permitido = False

            LimpiarCamposProductos()
            CalcularTotales()
            CalcularDatosDetalle()
            'Me.CalcularTotales()

            If tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
               CalcularTotalRemitoTransporte()
            End If

            If Me._comprobantesSeleccionados.Count > 0 Then
               If Not Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
                  Me.tbcDetalle.Tabs("tbpFacturables").Visible = True
               End If
               If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
                  Me.CambiarEstadoControlesDetalle(False)
                  Me.CambiarEstadoControlesDetalleRT(False)
                  Me._ModificaDetalle = "SOLOPRECIOS"
                  Me._ModificaDetalleRT = "NO"
               ElseIf Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "NO" Then 'AndAlso
                  'Me.tbcDetalle.Tabs(Me.tbpRemitoTransp) Then
                  Me.CambiarEstadoControlesDetalle(False)
                  Me.CambiarEstadoControlesDetalleRT(False)
                  Me._ModificaDetalle = "NO"
                  Me._ModificaDetalleRT = "NO"
                  txtCotizacionDolar.Enabled = False
               End If
            Else
               If Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
                  Me.tbcDetalle.Tabs("tbpFacturables").Visible = False
               End If
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         _cargaProductoDesdeInvocacion = False
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            Dim val As Integer
            If Not Integer.TryParse(bscCodigoCliente.Text, val) Then
               If Reglas.Publicos.ClienteMuestraCodigoClienteLetras Then
                  Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigoClienteLetras(Me.bscCodigoCliente.Text.Trim())
               Else
                  MessageBox.Show("El Código de Cliente debe ser numérico.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            Else
               Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(Long.Parse(Me.bscCodigoCliente.Text.Trim()), True, True)
            End If
         Else
            Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Finally
         Me.Cursor = Cursors.Default
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

   Private Sub llbCliente_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked

      Try
         MostrarMasInfo()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Function MostrarMasInfo() As DialogResult

      Dim clie As Entidades.Cliente = Nothing
      If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), incluirFoto:=True)
      End If
      Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         '-- REQ-43932.- ------------------------------------------
         Me.bscCodigoCliente.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido As Boolean = bscCodigoCliente.Permitido
         Me.bscCodigoCliente.Enabled = True
         bscCodigoCliente.Permitido = True
         bscCodigoCliente.Selecciono = False
         Me.bscCodigoCliente.PresionarBoton()
         bscCodigoCliente.Permitido = prevPermitido
         If clie.NroDocCliente = 0 Then
            result = DialogResult.Cancel
         End If
      End If
      Return result

   End Function

   Private Function MostrarMasInfoPaciente() As DialogResult

      Dim clie As Entidades.Cliente = Nothing
      If Me.bscCodigoPaciente.Selecciono Or Me.bscPaciente.Selecciono Then
         clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoPaciente.Tag.ToString()), incluirFoto:=True)
      End If
      Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         Me.bscCodigoPaciente.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido As Boolean = bscCodigoPaciente.Permitido
         Me.bscCodigoPaciente.PresionarBoton()
         bscCodigoPaciente.Permitido = prevPermitido
      End If
      Return result

   End Function

   Private Function MostrarMasInfoDoctor() As DialogResult

      Dim clie As Entidades.Cliente = Nothing
      If Me.bscCodigoDoctor.Selecciono Or Me.bscDoctor.Selecciono Then
         clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoDoctor.Tag.ToString()), incluirFoto:=True)
      End If
      Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         Me.bscCodigoDoctor.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido As Boolean = bscCodigoDoctor.Permitido
         Me.bscCodigoDoctor.PresionarBoton()
         bscCodigoDoctor.Permitido = prevPermitido
      End If
      Return result

   End Function

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If (Not Me.bscProducto2.FilaDevuelta Is Nothing Or Not Me.bscCodigoProducto2.FilaDevuelta Is Nothing) And Me.txtCantidad.Text <> "" Then
            If Me.ValidarInsertaProducto() Then
               Me.InsertarProducto()
               If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
                  Me.bscProducto2.Focus()
               Else
                  Me.bscCodigoProducto2.Focus()
               End If
               If Me._ModificaDetalle <> "TODO" Then
                  Me.CambiarEstadoControlesDetalle(False)
               End If
               If Me._ModificaDetalleRT <> "TODO" Then
                  Me.CambiarEstadoControlesDetalleRT(False)
               End If
               '-- REQ-41996.- ------------------------------------------------------------------
               If _cambioListaPrecio.HasValue Then
                  cmbListaDePrecios.SelectedValue = _cambioListaPrecio
                  _cambioListaPrecio = Nothing
               End If
               '---------------------------------------------------------------------------------
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvProductos.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaProducto()
               If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
                  Me.bscProducto2.Focus()
               Else
                  Me.bscCodigoProducto2.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbModificaPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chbModificaPrecio.CheckedChanged

      SoloLecturaPrecios(Not Me.chbModificaPrecio.Checked)

      If Me.chbModificaPrecio.Checked Then
         FocusPrecio()
         Me.txtPrecio.SelectAll()
      Else
         Me.txtCantidadManual.Focus()
         Me.txtCantidadManual.SelectAll()
      End If

   End Sub
   Private Sub chbModificaDescRecGralPorc_CheckedChanged(sender As Object, e As EventArgs) Handles chbModificaDescRecGralPorc.CheckedChanged

      '# Disparo el cálculo del D/R
      Dim nuevoDescRecGralPorc As Decimal = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                                         cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                                         cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                                         _cantLineas)
      Me._DescRecGralPorc = nuevoDescRecGralPorc
      Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnTotales.ToString())

      If Me.chbModificaDescRecGralPorc.Checked Then
         Me.txtDescRecGralPorc.ReadOnly = False
         Me.txtDescRecGralPorc.Focus()
         Me.txtDescRecGralPorc.SelectAll()
      Else
         Me.txtDescRecGralPorc.ReadOnly = True
      End If

      Me.CalcularDatosDetalle()
   End Sub
   Private Sub chbModificaDescRecargo_CheckedChanged(sender As Object, e As EventArgs) Handles chbModificaDescRecargo.CheckedChanged
      Dim puede As Boolean = True

      If Not _estaCargando Then
         If Me.chbModificaDescRecargo.Checked Then
            puede = BaseSeguridad.ControloPermisos(Eniac.Entidades.Usuario.Actual.Sucursal.Id, Eniac.Ayudantes.Common.usuario, "Facturacion-ClaveDescRecProd", "FacturacionV2")
         End If
      End If

      If puede Then
         Me.txtDescRecPorc1.ReadOnly = Not Me.chbModificaDescRecargo.Checked
         Me.txtDescRecPorc2.ReadOnly = Not Me.chbModificaDescRecargo.Checked
         Me.txtDescRec.ReadOnly = Not Me.chbModificaDescRecargo.Checked Or Not Reglas.Publicos.Facturacion.FacturacionModificaDescRecProductoPorMonto

         If Me.chbModificaDescRecargo.Checked Then
            Me.txtDescRecPorc1.Focus()
            Me.txtDescRecPorc1.SelectAll()
         ElseIf Me.chbModificaPrecio.Checked Then
            FocusPrecio()
            Me.txtPrecio.SelectAll()
         Else
            Me.txtCantidadManual.Focus()
            Me.txtCantidadManual.SelectAll()
         End If
      Else
         Me.chbModificaDescRecargo.Checked = False
      End If
   End Sub
   Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaDescRecargo.Checked Then
            Me.txtDescRecPorc1.Focus()
            Me.txtDescRecPorc1.SelectAll()
         Else
            If cmbNota.Enabled And cmbNota.Visible Then
               cmbNota.Focus()
            Else
               Me.btnInsertar.Focus()
            End If
         End If
      End If
   End Sub

   Private Sub txtCantidad_GotFocus(sender As Object, e As EventArgs) Handles txtCantidadManual.GotFocus, txtCantidad.GotFocus
      Try
         Me.txtCantidadManual.SelectAll()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantidad_LostFocus(sender As Object, e As EventArgs) Handles txtCantidadManual.LostFocus, txtCantidad.LostFocus
      Try

         ''# En caso de que la unidad de medida seleccionada NO sea la unidad de medida principal del producto, realizo la conversión
         'If sender.Equals(txtCantidadManual) Then
         '   Dim f = If(Me.bscCodigoProducto2.FilaDevuelta IsNot Nothing, Me.bscCodigoProducto2.FilaDevuelta, Me.bscProducto2.FilaDevuelta)
         '   If f IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.txtCantidadManual.Text) Then
         '      Me.txtCantidad.Text = Me.RealizarConversionUnidadesMedida(CDec(Me.txtCantidadManual.Text), CDec(f.Cells("Conversion").Value), Me.cmbUM2).ToString()
         '   End If
         'End If

         Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
         If Me.txtCantidad.Text.Trim().Length = 0 Then
            Me.txtCantidad.Text = "1." + New String("0"c, Me._decimalesEnCantidad)
            Me.txtCantidadManual.Text = "1." + New String("0"c, Me._decimalesEnCantidad)
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

               For Each vp As Entidades.VentaProducto In Me._ventasProductos
                  If vp.Producto.IdRubro = Producto.IdRubro Then
                     cantidad += vp.Cantidad
                  End If
               Next

               Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, Producto, cantidad, Me._decimalesEnTotales)

               For Each vp As Entidades.VentaProducto In Me._ventasProductos
                  If vp.Producto.IdRubro = Producto.IdRubro Then
                     vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
                     If calculaDescuentoRecargo2 Then
                        vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
                     End If
                  End If
                  vp.DescuentoRecargo = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                                   vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, vp.Cantidad)
               Next

               'RecalcularTodo()

            Else
               Me._DescuentosRecargosProd = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), Me._decimalesEnTotales)
            End If

            Dim cambia As Boolean = False
            If CalculosDescuentosRecargos1.HabilitaDescuentoRecargoProducto AndAlso (Not _txtCantidad_prev.HasValue OrElse _txtCantidad_prev.Value <> Decimal.Parse(Me.txtCantidad.Text.ToString())) Then

               cambia = True
               'SI SE MODIFICARON MANUALMENTE LOS DESCUENTOS EN LA LINEA A MODIFICAR Y CAMBIO LA CANTIDAD
               If _modificoDescuentos Then
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
                                                            Decimal.Parse(Me.txtDescRecPorc2.Text)), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes
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
            '-- REQ-33202.- -------------------------------------------------------------------------------------------------------------
            '# Si el producto tiene una bonificación x Lista de Precios x cantidad, se cambia la lista de precios y se modifica el precio
            If Producto.TipoBonificacion = Entidades.Producto.TiposBonificacionesProductos.LISTAPRECIO AndAlso
               Not Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
               BonificacionListaDePrecioXCantidad(Producto, txtCantidad.ValorNumericoPorDefecto(0D))
            End If
            '-----------------------------------------------------------------------------------------------------------------------------
         End If

         Me.CalcularTotalProducto()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadManual.KeyDown, txtCantidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            FocusPrecio()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            If cmbNota.Enabled And cmbNota.Visible Then
               cmbNota.Focus()
            Else
               Me.btnInsertar.Focus()
            End If
         End If
      End If
   End Sub

   Private Sub cmbPorcentajeIva_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPorcentajeIva.KeyDown
      'Para ir a chbModificaPrecio debe usar el TAB.
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            FocusPrecio()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            If cmbNota.Enabled And cmbNota.Visible Then
               cmbNota.Focus()
            Else
               Me.btnInsertar.Focus()
            End If
         End If
      End If
   End Sub

   Private Sub cmbPorcentajeIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPorcentajeIva.SelectedIndexChanged
      Try
         If Me._estoyCargandoElProducto Then Exit Sub
         If _cargandoProductoDesdeCompleto Then Exit Sub

         If Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing And Me.cmbPorcentajeIva.Tag IsNot Nothing Then
            If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
               Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Dim actualPrecio As Decimal = Decimal.Parse(Me.txtPrecio.Tag.ToString())
               'Dim impuestoInterno As Decimal = Decimal.Parse(Me.txtImpuestoInterno.Text)

               Dim iidb As ImpIntDesdeBusquedas = GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)

               actualPrecio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(actualPrecio, Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()),
                                                                                   iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
               actualPrecio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(actualPrecio, Decimal.Parse(Me.cmbPorcentajeIva.Text.ToString()),
                                                                                   iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)

               Me.txtPrecio.Text = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
               Me.txtPrecio.Tag = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))

               'Luego de recalcular PrecioVenta RECALCULO PrecioCosto

               actualPrecio = Decimal.Parse(Me.txtCosto.Text.ToString())
               'Dim impuestoInterno As Decimal = Decimal.Parse(Me.txtImpuestoInterno.Text)

               actualPrecio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(actualPrecio, Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()),
                                                                                   iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
               actualPrecio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(actualPrecio, Decimal.Parse(Me.cmbPorcentajeIva.Text.ToString()),
                                                                                   iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)

               Me.txtCosto.Text = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))

               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbTiposComprobantes_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTiposComprobantes.KeyDown
      If e.KeyCode = Keys.Enter And Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante Then
         If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
            Me.bscProducto2.Focus()
         Else
            Me.bscCodigoProducto2.Focus()
         End If
      Else
         PresionarTab(e)
      End If
   End Sub

   Private _tipoComprobanteActual As Entidades.TipoComprobante

   Private _ultimo_cmbTiposComprobantes_SelectedValue As Object
   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged

      If _estaCargando Then Exit Sub

      If Object.Equals(_ultimo_cmbTiposComprobantes_SelectedValue, cmbTiposComprobantes.SelectedValue) Then
         Exit Sub
      End If

      Try
         'limpio los valores si aún no le dio al +
         Me.btnLimpiarProducto.PerformClick()

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

         tsbInvocarCompras.Visible = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).InvocaCompras

         'solo habilito el boton de Facturables segun corresponde (si Eligio Factura en blanco o negro, tickets, etc)
         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            '# Valido si el cliente no posee comprobantes vencidos por la cantidad de días permitidos 
            'Me.ValidarDiasDeVencimiento()

            '# En caso que el comprobante solicite fecha de devolución, muestro los controles para ingresar la misma.
            Me.pnlConDevolucion.Visible = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).SolicitaFechaDevolucion
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).SolicitaFechaDevolucion Then
               Me.dgvRemitoTransp.Columns(Entidades.VentaProducto.Columnas.FechaDevolucion.ToString()).Visible = True
               Me.dtpFechaDevolucion.MinDate = Me.dtpFecha.Value
               Me.dtpFechaDevolucion.Value = Date.Now
               Me.rbCantDiasFechaDevolucion.Checked = True
               _modificoFechaDevolucion = False
            Else
               Me.dgvRemitoTransp.Columns(Entidades.VentaProducto.Columnas.FechaDevolucion.ToString()).Visible = False
               Me.dgvRemitoTransp.DataSource = Me._ventasProductos.ToArray()
            End If

            'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
            Me.cmbCategoriaFiscal.Enabled = True
            If Me._clienteE IsNot Nothing Then
               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then

                  'Vuelvo a asignarlo para saber si lo cambio.
                  Me._clienteE = New Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

                  If Not Me._clienteE.EsClienteGenerico Then
                     Me.cmbCategoriaFiscal.Enabled = False


                     'Si cambio la categoria... le vuelvo la original
                     If DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal <> Me._IdCategoriaFiscalOriginal Then
                        Me.cmbCategoriaFiscal.SelectedValue = Me._IdCategoriaFiscalOriginal
                        'Exit Sub
                     End If

                  End If
               Else

                  'Solo para los comprobantes en negro (los Pre-Eelctronicos son en blanco)
                  If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
                     Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
                  Else
                     If Not Me._clienteE.EsClienteGenerico Then
                        'Pudo cambiarla.
                        Me.cmbCategoriaFiscal.SelectedValue = Me._IdCategoriaFiscalOriginal
                     End If
                  End If
               End If
            End If

            Dim tpComp As Entidades.TipoComprobante = DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)
            If _tipoComprobanteActual IsNot Nothing AndAlso
               ((_tipoComprobanteActual.GrabaLibro Or _tipoComprobanteActual.EsPreElectronico) <> (tpComp.GrabaLibro Or tpComp.EsPreElectronico) Or
                _tipoComprobanteActual.UtilizaImpuestos <> tpComp.UtilizaImpuestos) Then
               For Each vp As Entidades.VentaProducto In _ventasProductos
                  Me.SeteaIVASegunComprobante(vp, tpComp, setearPrecio:=False) '# setearPrecio solo 'True'desde la invocación
               Next
               Me.RecalcularTodo(MetodoLlamador.CambioTipoDeComprobante, True)
            End If
            _tipoComprobanteActual = tpComp

            '-----------------------------------------------------------

            ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
            ''Habria que hacerlo mas general!
            'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal AndAlso Me._clienteE IsNot Nothing AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit) Then
            '   MessageBox.Show("El Comprobante requiere obligatorio el CUIT pero el Cliente NO lo tiene.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '   'Me.Nuevo()
            '   'Exit Sub
            'End If

            FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
            ''Si es X es remito, siempre debe tener esa letra, sino dejo la que esta.
            'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Length = 1 Then
            '   Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            'Else
            '   If Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
            '      Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
            '   Else
            '      Me.txtLetra.Text = ""
            '   End If
            'End If

            'Los comprobantes que facturan a otros son las FACTURAS y TICKET. Aunque depende del seteo que se haga en las tablas.
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFacturador Then
               Me.tsbInvocarComprobantes.Enabled = True
               If Not Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
                  Me.tbcDetalle.Tabs("tbpFacturables").Visible = True
               End If
            Else
               Me.tsbInvocarComprobantes.Enabled = False
               If Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
                  Me.tbcDetalle.Tabs("tbpFacturables").Visible = False
               End If
            End If

            If Me.cmbFormaPago.SelectedIndex >= 0 Then
               'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja And DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
               '   If Not Me.tbcDetalle.Tabs(Me.tbpPagos) Then
               '      Me.tbcDetalle.TabPages.Add(Me.tbpPagos)
               '   End If
               'Else
               '   If Me.tbcDetalle.Tabs(Me.tbpPagos) Then
               '      Me._cheques.Clear()
               '      Me.dgvCheques.DataSource = Me._cheques
               '      Me.tbcDetalle.TabPages.Remove(Me.tbpPagos)
               '   End If
               'End If
            End If

            Me.chbNumeroAutomatico.Checked = True
            Me.chbNumeroAutomatico.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
            txtNumeroPosible.MaxLength = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LargoMaximoNumero

            txtReferenciaComercial.Enabled = GetTipoComprobanteSeleccionado().AFIPWSRequiereReferenciaComercial
            cmbAFIPWSCodigoAnulacion.Enabled = GetTipoComprobanteSeleccionado().AFIPWSCodigoAnulacion
            cmbAFIPWSCodigoAnulacion.SelectedIndex = -1

            cmbAFIPWSReferenciaTransferencia.Enabled = GetTipoComprobanteSeleccionado().AFIPWSRequiereReferenciaTransferencia
            cmbAFIPWSReferenciaTransferencia.SelectedIndex = -1

            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
               If Not Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
                  Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible = True
               End If
               If Me.tbcDetalle.Tabs("tbpProductos").Visible Then
                  Me.tbcDetalle.Tabs("tbpProductos").Visible = False
               End If
               If Me.tbcDetalle.Tabs("tbpTotales").Visible Then
                  Me.tbcDetalle.Tabs("tbpTotales").Visible = False
               End If
            Else
               If Not Me.tbcDetalle.Tabs("tbpProductos").Visible Then
                  Me.tbcDetalle.Tabs("tbpProductos").Visible = True
               End If
               If Not Me.tbcDetalle.Tabs("tbpTotales").Visible Then
                  Me.tbcDetalle.Tabs("tbpTotales").Visible = True
               End If
               If Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
                  Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible = False
               End If
            End If

            If Publicos.IdNotaDebitoChequeRechazado(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante) Then
               If Not Me.tbcDetalle.Tabs("tbpCheques").Visible Then
                  Me._chequesRechazados = Nothing
                  Me._chequesRechazados = New List(Of Entidades.Cheque)
                  Me.dgvChequesRechazados.DataSource = Me._chequesRechazados
                  Me.tbcDetalle.Tabs("tbpCheques").Visible = True

                  If Not Me.chbModificaDescRecGralPorc.Checked Then
                     Me.chbModificaDescRecGralPorc.Checked = False
                     Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
                  End If

                  _clienteTieneDescRec = False
               End If
            Else
               If Me.tbcDetalle.Tabs("tbpCheques").Visible Then
                  Me.tbcDetalle.Tabs("tbpCheques").Visible = False
               End If

               '# Solo si no se aplicaron descuentos manuales
               If Not Me.chbModificaDescRecGralPorc.Checked Then
                  Me.txtDescRecGralPorc.Text = Me._DescRecGralPorc.ToString()
                  _clienteTieneDescRec = _DescRecGralPorc <> 0
               End If
            End If

            ''NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
            'Me.cmbCategoriaFiscal.Enabled = True
            'If Me._clienteE IsNot Nothing Then
            '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then

            '      'Vuelvo a asignarlo para saber si lo cambio.
            '      Me._clienteE = New Reglas.Clientes().GetUno(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)

            '      Me.cmbCategoriaFiscal.Enabled = False
            '      'Si cambio la categoria... le vuelvo la original
            '      If DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal <> Me._clienteE.CategoriaFiscal.IdCategoriaFiscal Then
            '         Me.cmbCategoriaFiscal.SelectedValue = Me._clienteE.CategoriaFiscal.IdCategoriaFiscal
            '         Exit Sub
            '      End If

            '   Else

            '      If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal Then
            '         Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
            '      End If

            '   End If
            'End If
            ''-----------------------------------------------------------

         Else
            If Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
               Me.tbcDetalle.Tabs("tbpFacturables").Visible = False
            End If
            Me.tsbInvocarComprobantes.Enabled = False
            If Me.tbcDetalle.Tabs("tbpCheques").Visible Then
               Me.tbcDetalle.Tabs("tbpCheques").Visible = False
            End If
         End If

         ' '' ''Limpio Grilla productos y de Facturables, siempre y cuando haya registros cargados por facturables.
         ' '' ''SI antes eligio un Facturador y ahora no ó viceversa
         ' '' ''En cambio si coincide en Facturador/NO Facturador dejo todo como esta. (ej: Presupuesto/Remito o Factura/Ticket)
         '' ''If Me.dgvFacturables.RowCount > 0 Then

         '' ''   Me.LimpiarDetalle()

         '' ''End If

         If Me.tbcDetalle.Tabs("tbpProductos").Visible Then
            'NO logro que quede primero.
            'Me.tbcDetalle.TabPages.Item(0).Name = Me.tbpProductos.Name
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")

            SetProductosDataSource()

            If Me.dgvProductos.Rows.Count > 0 Then
               Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            End If
            Me.dgvProductos.Refresh()

         Else
            'NO logro que quede primero.
            'Me.tbcDetalle.TabPages.Item(0).Name = Me.tbpRemitoTransp.Name
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpRemitoTransp")

            Me.dgvRemitoTransp.DataSource = Me._ventasProductos.ToArray()
            If Me.dgvRemitoTransp.Rows.Count > 0 Then
               Me.dgvRemitoTransp.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            End If
            Me.dgvRemitoTransp.Refresh()

            If Me._clienteE IsNot Nothing Then
               If Me._clienteE.IdTransportista > 0 Then
                  Dim Transp As Reglas.Transportistas = New Reglas.Transportistas()
                  Me._transportistaA = Transp.GetUno(Me._clienteE.IdTransportista)
                  Me.bscTransportista.Text = Me._transportistaA.NombreTransportista
                  Me.bscTransportista.Selecciono = True
               End If
            End If

         End If

         If Reglas.Publicos.FactElectEsSincronica Then
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsElectronico Then
               If Me.tbcPagosTarChe.TabPages.Contains(Me.tbpPagosCheques) Then
                  tbcPagosTarChe.Controls.Remove(tbcPagosTarChe.TabPages("tbpPagosCheques"))
               End If
            Else
               If Not Me.tbcPagosTarChe.TabPages.Contains(Me.tbpPagosCheques) Then
                  Me.tbcPagosTarChe.TabPages.Add(Me.tbpPagosCheques)
               End If
            End If
         End If

         CambiarEstadoControlesDetalle(_clienteE IsNot Nothing And _ModificaDetalle <> "NO")
         CambiarEstadoControlesDetalleRT(_clienteE IsNot Nothing)

         'Al cambiar de tipo de comprobante quito los productos que utilizan LOTE o NRO de SERIE
         'porque pudo cambiar de Factura a NCRED o viseversa, y lleva controles o que afecta stock si a no.
         LimpiaProductoPorCambioTipoComprobante()

         '''''Si algun producto es con Lote tengo que limpiar el detalle, porque pudo cambiar de Factura a NCRED o viseversa, y lleva controles
         ''''' o que afecta stock si a no.
         ''''If Me.ProductosConLote() > 0 Then
         ''''   Me.LimpiarDetalle()
         ''''End If

         cmbEmisor.SelectedIndex = -1
         If cmbTiposComprobantes.SelectedValue IsNot Nothing Then
            _publicos.CargaComboEmisor(cmbEmisor, actual.Sucursal.Id, Me.cmbTiposComprobantes.SelectedValue.ToString(), miraPC:=True)
            'Me.CargarProximoNumero()
         End If

         ' # Esto está repetido más arriba y este no hace nada
         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            '-- REQ-30773 --
            Dim TipComp = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantes.SelectedValue.ToString())
            Me.chbMercDespachada.Checked = CBool(TipComp.ActivaTildeMercDespacha)

            'Se ejecuta al cambiar en pantalla, mas alla que lo hayan elegido
            ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
            ''Habria que hacerlo mas general!
            'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal AndAlso Me._clienteE IsNot Nothing AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit) Then
            '   MessageBox.Show("El Comprobante requiere obligatorio el CUIT pero el Cliente NO lo tiene.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '   'Me.Nuevo()
            '   'Exit Sub
            'End If

         End If

         ' Se aplica la lógica del Recargo/Descuento por Cantidad de Lineas.
         '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
            If Not Me.chbModificaDescRecGralPorc.Checked AndAlso
               Not Publicos.IdNotaDebitoChequeRechazado(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante) Then

               _cantLineas = _ventasProductos.Count
               Me._DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                          cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                          cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                          _cantLineas)
               Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
               Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
            End If
         End If

         Me.ChequeaCajas()

         CargaTipoComprobanteProducto()

         Me.CalcularDatosDetalle()

         '# Si es remito transportista, luego de calcular todos los importes, actualizo el precio que se visualiza en pantalla
         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
            Me.CalcularTotalRemitoTransporte()
         End If

         _ultimo_cmbTiposComprobantes_SelectedValue = cmbTiposComprobantes.SelectedValue

      Catch ex As Exception
         ShowError(ex)
         Try
            Nuevo(False, False)
         Catch ex1 As Exception
            ShowError(ex1)
         End Try
      End Try

   End Sub

   Private _cargandoProductosAutomaticamente As Boolean = False

   Private Sub CargaTipoComprobanteProducto()
      If validaCliente() Then
         For Each rwVentaProduct As Entidades.VentaProducto In _ventasProductos.Where(Function(x) x.Automatico).ToArray()
            EliminarLineaProducto(rwVentaProduct)
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
         End If
         _cargandoProductosAutomaticamente = False

      End If
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
   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      Me.LimpiarCamposProductos()
      If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
         Me.bscProducto2.Focus()
      Else
         Me.bscCodigoProducto2.Focus()
      End If
   End Sub

   Private Sub dgvProductos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
      Try
         If e.RowIndex < 0 Then Exit Sub

         If Me._ModificaDetalle <> "NO" Then
            'limpia los textbox, y demas controles
            Me.LimpiarCamposProductos()
            'carga el producto seleccionado de la grilla en los textbox 

            '#Seteo el valor de la propiedad
            _editarProductoDesdeGrilla = True

            flackCargaProductos = False
            Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex), editarProductoDesdeGrilla:=_editarProductoDesdeGrilla)
            flackCargaProductos = True

            Me.EliminarLineaProducto()

            If Reglas.Publicos.Facturacion.FacturacionConservaOrdenProductos Then
               If Me.dgvProductos.Rows.Count <> 0 Then
                  Dim FilaPosicion As Integer = e.RowIndex
                  If e.RowIndex = Me.dgvProductos.Rows.Count Then
                     FilaPosicion -= 1
                  End If
                  Me.dgvProductos.FirstDisplayedScrollingRowIndex = FilaPosicion
                  Me.dgvProductos.Rows(FilaPosicion).Selected = True
               End If
            End If

            If Me._ModificaDetalle = "SOLOPRECIOS" Then
               HabilidaPrecios(True)
               Me.txtDescRecPorc1.Enabled = True
               Me.txtDescRecPorc2.Enabled = True
               Me.txtDescRec.Enabled = True

               Dim tipoComp As Entidades.TipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)()
               'Si Cliente utiliza impuestos, y Empresa utiliza impuestos, y es un comprobante en negro
               If (Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                  Not tipoComp.GrabaLibro And Not tipoComp.EsPreElectronico) Or
                  tipoComp.PermiteSeleccionarAlicuotaIVA Then
                  Me.cmbPorcentajeIva.Enabled = True
               Else
                  Me.cmbPorcentajeIva.Enabled = False
               End If

               Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
               Me.btnInsertar.Enabled = True
               FocusPrecio()
            Else
               Me.txtCantidadManual.Focus()
               Me.txtCantidadManual.SelectAll()
            End If

            Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
            Me.btnInsertar.Enabled = True
            FocusPrecio()
         Else
            Me.txtCantidadManual.Focus()
            Me.txtCantidadManual.SelectAll()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnLimpiarProductoRT_Click(sender As Object, e As EventArgs) Handles btnLimpiarProductoRT.Click
      Me.LimpiarCamposProductosRT()
      Me.bscCodigoProducto2RT.Focus()
   End Sub

   Private Sub dgvRemitoTransp_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRemitoTransp.CellDoubleClick
      Try
         If Me._ModificaDetalleRT <> "NO" Then
            'limpia los textbox, y demas controles
            Me.LimpiarCamposProductosRT()
            'carga el producto seleccionado de la grilla en los textbox 

            '#Seteo el valor de la propiedad
            _editarProductoDesdeGrilla = True
            Me.CargarProductoCompletoRT(Me.dgvRemitoTransp.Rows(e.RowIndex), editarProductoDesdeGrilla:=_editarProductoDesdeGrilla)
            'elimina el producto de la grilla
            Me.EliminarLineaProductoRT()

            If Me._ModificaDetalle = "SOLOPRECIOS" Then
               Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
               Me.btnInsertar.Enabled = True
               Me.txtCantidadManual.Focus()
               Me.txtCantidadManual.SelectAll()
            Else
               Me.txtCantidadManual.Focus()
               Me.txtCantidadManual.SelectAll()
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugObservaciones_DoubleClickRow(sender As Object, e As UltraWinGrid.DoubleClickRowEventArgs) Handles ugObservaciones.DoubleClickRow
      Try
         If e.Row.Index <> -1 Then
            'limpia los textbox, y demas controles
            Me.LimpiarCamposObservDetalles()

            'carga la observacion seleccionada de la grilla en los textbox 
            Me.CargarObservDetalleCompleto()

            'elimina el producto de la grilla
            Me.EliminarLineaObservacion()

            'Tengo que renumerar por la forma que asigno el numero de linea.
            Me.RenumerarObservacionesDetalle()

            cmbTipoObservacion.Focus()
            'Me.bscObservacionDetalle.SelectAll()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnInsertarCheque_Click(sender As Object, e As EventArgs) Handles btnInsertarCheque.Click
      Try
         If Me.ValidarInsertarCheques() Then
            Me.InsertarChequesGrilla()
            Me.bscCodBancos.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminarCheque_Click(sender As Object, e As EventArgs) Handles btnEliminarCheque.Click
      Try
         If Me.dgvCheques.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaCheques()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbFormaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbFormaPago.KeyDown
      PresionarTab(e)
   End Sub

   Private _formaPagoAnterio As Entidades.VentaFormaPago
   Private Sub cmbFormaPago_Enter(sender As Object, e As EventArgs) Handles cmbFormaPago.Enter
      '-- REQ-31080.- --
      TryCatched(Sub()
                    _formaPagoAnterio = cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)
                    Dim fp = DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago)
                    Me._FormaPagoCoeficiente = If(fp IsNot Nothing, fp.Dias, 999)
                 End Sub)
   End Sub

   Private Sub SeteaComprobanteSegunFormaDePago()
      '-- REQ-33326.- -----------------------------------------------------------------------------------------------------
      If DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdTipoComprobantes IsNot Nothing Then
         '-- REQ-33409 - Busca el Tipo de Comprobante dentro del Combo.- --
         For Each cTipoCompr In DirectCast(cmbTiposComprobantes.DataSource, List(Of Entidades.TipoComprobante))
            If cTipoCompr.IdTipoComprobante = DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdTipoComprobantes Then
               cmbTiposComprobantes.SelectedValue = DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdTipoComprobantes
            End If
         Next
      End If
      '--------------------------------------------------------------------------------------------------------------------
   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         If Me.cmbTiposComprobantes.SelectedItem Is Nothing Then
            MessageBox.Show("Falta asignar el tipo de comprobante para una PC en impresoras.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If


         If Me.cmbFormaPago.SelectedIndex <> -1 Then
            '-- REQ-33326.- -----------------------------------------------------------------------------------------------------
            SeteaComprobanteSegunFormaDePago()
            '--------------------------------------------------------------------------------------------------------------------
            txtReferenciaCtaCte.Enabled = DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).Dias <> 0

            If DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).Dias = 0 And DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja Then
               If Not Me.tbcDetalle.Tabs("tbpPagos").Visible Then
                  Me.tbcDetalle.Tabs("tbpPagos").Visible = True
               End If
            Else
               'If Me.tbcDetalle.Tabs(Me.tbpPagos) Then
               '   Me._cheques.Clear()
               '   Me.dgvCheques.DataSource = Me._cheques
               '   Me.tbcDetalle.TabPages.Remove(Me.tbpPagos)
               'End If
            End If

            Me.ChequeaCajas()

            If _invocadosCajero IsNot Nothing Then
               If _invocadosCajero.Count > 0 Then
                  If DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).Dias > 0 Then
                     txtEfectivo.Text = 0D.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
                     txtImporteDolares.SetValor(0D)
                     txtTransferenciaBancaria.Text = 0D.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
                     txtTickets.Text = 0D.ToString("N" + _decimalesAMostrarEnPrecio.ToString())

                     _cheques.Clear()
                     dgvCheques.DataSource = Me._cheques
                     LimpiarCamposCheques()

                     _tarjetas.Clear()
                     dgvTarjetas.DataSource = Me._tarjetas
                     LimpiarCamposTarjetas()

                     CalcularPagos(False)
                  End If
               End If
            End If

            '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
            If Not Me.chbModificaDescRecGralPorc.Checked Then
               _cantLineas = _ventasProductos.Count
               _DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                               cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                               cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                               _cantLineas)
               txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnTotales.ToString())
               _clienteTieneDescRec = _DescRecGralPorc <> 0
            End If
            Me.CalcularDatosDetalle()

            '-- REQ-31080 --
            If _FormaPagoCoeficiente = 0 And DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).Dias <> 0 And DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 AndAlso
               txtTotalPago.ValorNumericoPorDefecto(0D) <> 0 Then
               MessageBox.Show("Cambio a una forma de pago Cuenta Corriente y Posee Pagos!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
            End If

            '-- REQ-33202.- ---------------------------------------------------------------------------------------
            If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios IsNot Nothing Then
               '-- Guarda Lista de Precios Anterior.- --
               cmbListaDePrecios.Tag = cmbListaDePrecios.SelectedValue
               'If cmbListaDePrecios.ValorSeleccionado(Of Integer) <> cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).IdListaPrecios Then
               If _formaPagoAnterio IsNot Nothing AndAlso _formaPagoAnterio.IdListaPrecios.IfNull(-1) <> cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).IdListaPrecios.IfNull(-1) Then
                  '-- Carga Nueva Lista de Precios.- ------
                  cmbListaDePrecios.SelectedValue = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios
                  '-- Desactiva Combo de lista de Precios.- 
                  cmbListaDePrecios.Enabled = False
                  '-- Recalcula valores anterirores.- --
                  RecalcularTodo(FacturacionV2.MetodoLlamador.CambioListaDePrecibos, False)
               End If
            Else
               'If cmbListaDePrecios.ValorSeleccionado(Of Integer) <> ObjectExtensions.ValorNumericoPorDefecto(cmbListaDePrecios.Tag, 0I) Then
               If _formaPagoAnterio IsNot Nothing AndAlso _formaPagoAnterio.IdListaPrecios.IfNull(-1) <> cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).IdListaPrecios.IfNull(-1) Then
                  '-- Guarda Lista de Precios Anterior.- --
                  cmbListaDePrecios.SelectedValue = CInt(cmbListaDePrecios.Tag)
                  '-- Desactiva Combo de lista de Precios.- 
                  cmbListaDePrecios.Enabled = True
                  '-- Recalcula valores anterirores.- --
                  RecalcularTodo(FacturacionV2.MetodoLlamador.CambioListaDePrecibos, True)
               End If
            End If
            '------------------------------------------------------------------------------------------------------
            RecalcularTodo(FacturacionV2.MetodoLlamador.CambioFormaDePago, True)

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tbcDetalle_SelectedTabChanged(sender As Object, e As UltraWinTabControl.SelectedTabChangedEventArgs) Handles tbcDetalle.SelectedTabChanged
      Try
         If Me.tbcDetalle.Tabs("tbpProductos").Visible Then
            If Me.tbcDetalle.SelectedTab Is tbcDetalle.Tabs("tbpProductos") Then
               If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
                  Me.bscProducto2.Focus()
               Else
                  Me.bscCodigoProducto2.Focus()
               End If
            End If
         End If

         If Me.tbcDetalle.Tabs("tbpPagos").Visible Then
            If Me.tbcDetalle.SelectedTab Is tbcDetalle.Tabs("tbpPagos") Then
               Me.txtEfectivo.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbListaDePrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbListaDePrecios.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub cmbListaDePrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaDePrecios.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         '-- REQ-33202.- Verifico si cambio Variable.- --
         ActualizaPrecios = If(cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).IdListaPrecios.HasValue, True, Reglas.Publicos.ActualizaPreciosDeVenta())
         '------------------------------------
         If ActualizaPrecios Then
            RecalcularTodo(FacturacionV2.MetodoLlamador.CambioListaDePrecibos, False)
         Else
            SetearPrecio()
         End If
         '-- REQ-33202.- Restablezco cambio Variable.- --
         ActualizaPrecios = Reglas.Publicos.ActualizaPreciosDeVenta()
         ''------------------------------------
         'If Reglas.Publicos.ActualizaPreciosDeVenta Then
         '   Me.RecalcularTodo(MetodoLlamador.CambioListaDePrecibos, False)
         'End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub SetearPrecio()
      If _clienteE Is Nothing Then Return
      If cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios) Is Nothing Then Return
      'Dim dr = bscCodigoProducto2.FilaDevuelta
      Dim idProducto = bscCodigoProducto2.Text.Trim()
      Dim oProductos = New Reglas.Productos()
      Dim dt = oProductos.GetPorCodigo(idProducto, actual.Sucursal.Id,
                                       cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios).IdListaPrecios,
                                       "VENTAS", , , , , , , , , _clienteE.IdCliente, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
      If dt.Count > 0 Then
         Dim dr = dt(0)

         Dim producto = New Reglas.Productos().GetUno(idProducto, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
         If producto IsNot Nothing Then
            Dim p = FacturacionAyudantes.GetPrecio(dr.Field(Of Decimal)("PrecioVentaSinIVA"), dr.Field(Of Decimal)("PrecioVentaConIVA"),
                                                   producto, _clienteE, dtpFecha.Value, _nroOferta, _categoriaFiscalEmpresa, _codigoBarrasCompleto,
                                                   txtCotizacionDolar.ValorNumericoPorDefecto(0D), _modalidad, _decimalesRedondeoEnPrecio,
                                                   FormaDePago:=DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago))

            txtPrecio.Text = p.ToString(_formatoAMostrarEnPrecio)
            txtPrecio.Tag = txtPrecio.Text
         End If
      End If

   End Sub
   'Se lo reemplazo por una buscador de observaciones
   'Private Sub txtObservacion_KeyDown( sender As Object,  e As KeyEventArgs) handles txtObservacion.KeyDown
   '   PresionarTab(e)
   'End Sub

   Private Sub txtCotizacionDolar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCotizacionDolar.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub cmbCategoriaFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCategoriaFiscal.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
         ''Si es X es remito y siempre debe tener esa letra
         'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "B" Or Me.txtLetra.Text = "C" Or Me.txtLetra.Text = "E") And Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
         '   Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
         'End If

         'If Me.cmbCategoriaFiscal.SelectedIndex >= 0 And Me._clienteE IsNot Nothing Then

         '   'Limpio Si cambio de categoria fiscal y tenia Facturables. Sino cambiar toda toda la logica del calculo del iva del producto, pero no es razonable.
         '   If Short.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString()) <> Me._clienteE.CategoriaFiscal.IdCategoriaFiscal And Me.dgvFacturables.RowCount > 0 Then

         '      Me._ventasProductos = Nothing
         '      Me._ventasProductos = New List(Of Entidades.VentaProducto)
         '      Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()

         '      Me._comprobantesSeleccionados = Nothing
         '      Me._comprobantesSeleccionados = New List(Of Entidades.Venta)

         '      Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados

         '   End If

         'End If

         If Me._clienteE IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then

            Me._clienteE.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString()))

            'Exento sin IVA (Cliente o Empresa). 
            If Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Me.cmbPorcentajeIva.Text = "0." + New String("0"c, Me._decimalesEnTotales)
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
               Me.cmbPorcentajeIva.Enabled = False
            Else
               Me.cmbPorcentajeIva.Enabled = True
            End If

            'Si es un comprobante en blanco no deberia cambiar el IVA del producto
            If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
               Dim tipoComp As Entidades.TipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)()
               If (Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                   Not tipoComp.GrabaLibro And Not tipoComp.EsPreElectronico) Or
                  tipoComp.PermiteSeleccionarAlicuotaIVA Then
                  Me.cmbPorcentajeIva.Enabled = True
               Else
                  Me.cmbPorcentajeIva.Enabled = False
               End If
            End If

            Me.RecalcularTodo(MetodoLlamador.CambioCategoriaFiscal, False)

            Me.LimpiarCamposProductos()

            If _clienteE.EsClienteGenerico Then
               If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
                  '  Me.txtCUIT.Text = ""
                  Me.lblCUIT.Text = My.Resources.RTextos.Cuit
                  Me.cmbTipoDoc.Visible = False
                  Me.txtNroDocCliente.Visible = False
                  Me.lblTipoDocumento.Visible = False
                  Me.txtCUIT.Visible = True
                  Me.txtCUIT.ReadOnly = False
               Else
                  Me.cmbTipoDoc.Visible = True
                  Me.txtNroDocCliente.Visible = True
                  Me.cmbTipoDoc.Enabled = True
                  Me.txtNroDocCliente.ReadOnly = False
                  Me.lblTipoDocumento.Visible = True
                  Me.txtCUIT.Visible = False
                  'Me.txtCUIT.Text = dr.Cells("NroDocCliente").Value.ToString()
                  Me.lblCUIT.Text = "Nro Documento"
               End If

            Else
               If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
                  '  Me.txtCUIT.Text = ""
                  Me.lblCUIT.Text = My.Resources.RTextos.Cuit
                  Me.cmbTipoDoc.Visible = False
                  Me.txtNroDocCliente.Visible = False
                  Me.lblTipoDocumento.Visible = False
                  Me.txtCUIT.Visible = True
                  Me.txtCUIT.ReadOnly = True
               Else
                  Me.cmbTipoDoc.Visible = True
                  Me.txtNroDocCliente.Visible = True
                  Me.cmbTipoDoc.Enabled = False
                  Me.txtNroDocCliente.ReadOnly = True
                  Me.lblTipoDocumento.Visible = True
                  Me.txtCUIT.Visible = False
                  'Me.txtCUIT.Text = dr.Cells("NroDocCliente").Value.ToString()
                  Me.lblCUIT.Text = "Nro Documento"
               End If
            End If
            _ultimaCategoriaFiscalSeleccionada = _clienteE.CategoriaFiscal
         Else
            _ultimaCategoriaFiscalSeleccionada = Nothing
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private _ultimaCategoriaFiscalSeleccionada As Entidades.CategoriaFiscal

   Private Sub cmbVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVendedor.KeyDown

      If e.KeyCode = Keys.Enter And Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
         If Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante Then
            Me.cmbTiposComprobantes.Focus()
         Else
            If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
               Me.bscProducto2.Focus()
            Else
               Me.bscCodigoProducto2.Focus()
            End If
         End If
      Else
         PresionarTab(e)
      End If

   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      Me.txtNumeroPosible.ReadOnly = chbNumeroAutomatico.Checked
   End Sub

   Private Sub bscObservacion_BuscadorClick() Handles bscObservacion.BuscadorClick
      Try
         Dim oProductos As Reglas.Observaciones = New Reglas.Observaciones
         Me._publicos.PreparaGrillaObservaciones(Me.bscObservacion)
         Me.bscObservacion.Datos = oProductos.GetPorNombre(Me.bscObservacion.Text.Trim(), "VENTA")

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscObservacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscObservacion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarObservacion(e.FilaDevuelta)
            'Me.txtCantidadManual.Focus()
            'Me.txtCantidadManual.SelectAll()
            Me.txtCotizacionDolar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtBultos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBultos.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtValorDeclarado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValorDeclarado.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtValorDeclarado_Leave(sender As Object, e As EventArgs) Handles txtValorDeclarado.Leave
      Me.txtValorDeclarado.Text = Decimal.Parse(Me.txtValorDeclarado.Text).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      'Me.txtBruto.Text = txtValorDeclarado.Text
      'Me.txtSubTotal.Text = txtValorDeclarado.Text
      Me.txtTotalGeneral.Text = txtValorDeclarado.Text
      'Se quiere que afecte el valor declarado en el calculo.
      'Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)
   End Sub

   Private Sub bscTransportista_BuscadorClick() Handles bscTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscTransportista)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         Me.bscTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscTransportista.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)
            Me.txtNumeroLote.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
         '  Me.Nuevo()
      End Try

   End Sub

   '-- REQ-33791.- -----------------------------------------------------------------------------------------------------------------------------------------
   Private Sub bscNombreTransportista_BuscadorClick() Handles bscNombreTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscNombreTransportista)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         Me.bscNombreTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscNombreTransportista.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscNombreTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista2(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
         '  Me.Nuevo()
      End Try

   End Sub

   '--------------------------------------------------------------------------------------------------------------------------------------------------------
   Private Sub txtNumeroLote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroLote.KeyDown
      'PresionarTab(e)
      If e.KeyCode = Keys.Enter Then
         Me.bscCodigoProducto2RT.Focus()
      End If
   End Sub

   Private Sub bscCodigoProducto2RT_BuscadorClick() Handles bscCodigoProducto2RT.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2RT)

         If Me.cmbListaDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar la lista de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbListaDePrecios.Focus()
            Exit Sub
         End If

         Me.bscCodigoProducto2RT.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2RT.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2RT_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2RT.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProductoRT(e.FilaDevuelta)
            Me.txtCantidadManualRT.Focus()
            Me.txtCantidadManualRT.SelectAll()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2RT_BuscadorClick() Handles bscProducto2RT.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2RT)

         If Me.cmbListaDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar la lista de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbListaDePrecios.Focus()
            Exit Sub
         End If

         Me.bscProducto2RT.Datos = oProductos.GetPorNombre(Me.bscProducto2RT.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2RT_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2RT.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProductoRT(e.FilaDevuelta)
            Me.txtCantidadManualRT.Focus()
            Me.txtCantidadRT.SelectAll()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantidadRT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadRT.KeyDown, txtCantidadManualRT.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtCantDiasFechaDevolucion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantDiasFechaDevolucion.KeyDown
      If e.KeyCode = Keys.Enter Then
         'PresionarTab(e)
         btnInsertarRT.Focus()
      End If
   End Sub

   Private Sub dtpFechaDevolucion_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaDevolucion.KeyDown
      If e.KeyCode = Keys.Enter Then
         'PresionarTab(e)
         btnInsertarRT.Focus()
      End If
   End Sub

   Private Sub btnInsertarRT_Click(sender As Object, e As EventArgs) Handles btnInsertarRT.Click
      Try
         If (Not Me.bscProducto2RT.FilaDevuelta Is Nothing Or Not Me.bscCodigoProducto2RT.FilaDevuelta Is Nothing) And Me.txtCantidadRT.Text <> "" Then
            If Me.ValidarInsertaProductoRT() Then
               Me.InsertarProductoRT()
               Me.bscCodigoProducto2RT.Focus()
               If Me._ModificaDetalle <> "TODO" Then
                  Me.CambiarEstadoControlesDetalle(False)
               End If
               If Me._ModificaDetalleRT <> "TODO" Then
                  Me.CambiarEstadoControlesDetalleRT(False)
               End If
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminarRT_Click(sender As Object, e As EventArgs) Handles btnEliminarRT.Click
      Try
         If Me.dgvRemitoTransp.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaProductoRT()
               Me.bscCodigoProducto2RT.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

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
            'Me.txtCantidadManual.Focus()
            'Me.txtCantidadManual.SelectAll()
            Me.btnInsertarObservacion.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarObservacion_Click(sender As Object, e As EventArgs) Handles btnInsertarObservacion.Click
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

   Private Sub btnEliminarObservacion_Click(sender As Object, e As EventArgs) Handles btnEliminarObservacion.Click
      Try
         If Me.ugObservaciones.ActiveRow IsNot Nothing Then
            If MessageBox.Show("Esta seguro de eliminar la Observación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaObservacion()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarChequeTercero_Click(sender As Object, e As EventArgs) Handles btnInsertarChequeTercero.Click

      If Me._clienteE Is Nothing Then
         MessageBox.Show("ATENCION: Debe elegir el Cliente antes de cargar el Cheque Rechazado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Me.bscCodigoCliente.Focus()
         Exit Sub
      End If

      Try

         Dim oChequesDetalleAyuda As Eniac.Win.ChequesDetalleAyuda
         oChequesDetalleAyuda = New Eniac.Win.ChequesDetalleAyuda(Int32.Parse(Me.cmbCajas.SelectedValue.ToString()), Long.Parse(Me.bscCodigoCliente.Text.ToString()))

         oChequesDetalleAyuda.TipoDeMovimiento = "G"  'Los cheques entregados sin los Rechazados
         oChequesDetalleAyuda.ShowDialog()

         If oChequesDetalleAyuda.blSeleccionados Then
            Me.ActualizaGrillaChequesTerceros(oChequesDetalleAyuda.dtSelectedCheques)
         End If

         'Me.CalcularPagos()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnEliminarChequeTercero_Click(sender As Object, e As EventArgs) Handles btnEliminarChequeTercero.Click
      Try
         If Me.dgvChequesRechazados.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaChequeTercero()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ActualizaGrillaChequesTerceros(dtCheques As DataTable)

      Dim blnInsertar As Boolean

      Dim oLineaDetalle As Entidades.Cheque = New Entidades.Cheque()

      Dim oLineaDetalleObs As Entidades.VentaObservacion = New Entidades.VentaObservacion()

      'Siempre viene 1 registro, manejar directamente el datatable

      For Each cRow As DataRow In dtCheques.Rows

         With oLineaDetalle
            .IdCheque = cRow.Field(Of Long)("IdCheque")
            .IdTipoCheque = cRow.Field(Of String)("IdTipoCheque")
            .NombreTipoCheque = cRow.Field(Of String)("NombreTipoCheque")

            .NumeroCheque = Integer.Parse(cRow("NumeroCheque").ToString())
            .Banco = New Reglas.Bancos().GetUno(Integer.Parse(cRow("IdBanco").ToString()))
            .IdBancoSucursal = Integer.Parse(cRow("IdBancoSucursal").ToString())
            .Localidad.IdLocalidad = Integer.Parse(cRow("IdLocalidad").ToString())
            .FechaEmision = Date.Parse(cRow("FechaEmision").ToString())
            .FechaCobro = Date.Parse(cRow("FechaCobro").ToString())
            .Titular = cRow("Titular").ToString()
            .Importe = Decimal.Parse(cRow("Importe").ToString())

            'Lo actualizo por si vino como ALTA.
            .Cliente.IdCliente = _clienteE.IdCliente
            .Cliente.CodigoCliente = _clienteE.CodigoCliente

            .Usuario = actual.Nombre
         End With

         cmbTipoObservacion.SelectedValue = _idTipoObservacion

         With oLineaDetalleObs
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .Linea = ugObservaciones.Rows.Count + 1
            .IdTipoObservacion = _idTipoObservacion
            .DescripcionTipoObservacion = cmbTipoObservacion.Text
            .Observacion = String.Format("{0} - Suc: {1} - CP: {2} - Numero: {3} - Cobro: {4:dd/MM/yyyy} - $ {5:N2} - Titular: {6}",
                                         oLineaDetalle.Banco.NombreBanco, oLineaDetalle.IdBancoSucursal, oLineaDetalle.Localidad.IdLocalidad, oLineaDetalle.NumeroCheque,
                                         oLineaDetalle.FechaCobro, oLineaDetalle.Importe, oLineaDetalle.Titular).Truncar(100)
         End With

         blnInsertar = True

         For i As Integer = 0 To Me._chequesRechazados.Count - 1
            If Me._chequesRechazados(i).NumeroCheque = Integer.Parse(cRow("NumeroCheque").ToString()) And
               Me._chequesRechazados(i).Banco.IdBanco = Integer.Parse(cRow("IdBanco").ToString()) And
               Me._chequesRechazados(i).IdBancoSucursal = Integer.Parse(cRow("IdBancoSucursal").ToString()) And
               Me._chequesRechazados(i).Localidad.IdLocalidad = Integer.Parse(cRow("IdLocalidad").ToString()) Then
               blnInsertar = False
               Exit For
            End If
         Next

         If blnInsertar Then
            Me._chequesRechazados.Add(oLineaDetalle)
            Me._ventasObservaciones.Add(oLineaDetalleObs)
         End If

      Next

      Me.dgvChequesRechazados.DataSource = Me._chequesRechazados.ToArray()
      Me.dgvChequesRechazados.FirstDisplayedScrollingRowIndex = Me.dgvChequesRechazados.Rows.Count - 1

      Me.dgvChequesRechazados.Refresh()

      SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())

      Me.CalcularPagos(False)

   End Sub

   Private Sub SetDataSourceObservaciones(datos As Object)
      Me.ugObservaciones.DataSource = datos
      AjustarColumnasGrilla(ugObservaciones, _titObservaciones)
      If ugObservaciones.Rows.Count > 0 Then
         ugObservaciones.DisplayLayout.RowScrollRegions(0).FirstRow = ugObservaciones.Rows(ugObservaciones.Rows.Count - 1)
      End If
      'Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      'Me.dgvObservaciones.Refresh()
   End Sub


   Private Sub EliminarLineaChequeTercero()
      Me._chequesRechazados.RemoveAt(Me.dgvChequesRechazados.SelectedRows(0).Index)
      Me.dgvChequesRechazados.DataSource = Me._chequesRechazados.ToArray()
      'Me.CalcularPagos()
   End Sub

   Private Sub txtPercepcionIVA_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIVA.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         ShowError(ex)
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

   Private Sub txtPercepcionIIBB_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIIBB.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionGanancias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionGanancias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionVarias.Focus()
      End If
   End Sub

   Private Sub txtPercepcionVarias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionVarias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPercepcionVarias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionVarias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtTotalRetenciones.Focus()
      End If
   End Sub

   Private Sub dgvProductos_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick

      Try
         If Me.dgvProductos.Rows.Count = 0 Then Exit Sub

         If Me.dgvProductos.SelectedRows.Count = 0 Then Exit Sub

         '# Visualizar Nros. Serie
         Me.MostrarNumerosSerieDesdeGrilla(Me.dgvProductos, e)

         '# Visualizar Lotes
         Me.MostrarNumerosLotesDesdeGrilla(Me.dgvProductos, e)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub dgvRemitoTransp_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRemitoTransp.CellClick

      Try
         If Me.dgvRemitoTransp.Rows.Count = 0 Then Exit Sub

         If Me.dgvRemitoTransp.SelectedRows.Count = 0 Then Exit Sub

         '# Visualizar Nros. Serie
         Me.MostrarNumerosSerieDesdeGrilla(Me.dgvRemitoTransp, e)

         '# Visualizar Lotes
         Me.MostrarNumerosLotesDesdeGrilla(Me.dgvRemitoTransp, e)


      Catch ex As Exception
         ShowError(ex)
      End Try

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

   Private Sub cmbTarTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTarTarjeta.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub bscTarBanco_BuscadorClick() Handles bscTarBanco.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscTarBanco)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscTarBanco.Datos = oBanco.GetFiltradoPorNombre(Me.bscTarBanco.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscTarBanco_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscTarBanco.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTarjetasBancos(e.FilaDevuelta)
            Me.txtTarMonto.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtTarMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarMonto.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtTarCuotas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarCuotas.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtTarNumeroLote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarNumeroLote.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtTarNumeroCupon_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarNumeroCupon.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub btnInsertarTarjeta_Click(sender As Object, e As EventArgs) Handles btnInsertarTarjeta.Click
      Try
         If Me.ValidarInsertarTarjeta() Then
            Me.InsertarTarjetaGrilla()
            Me.cmbTarTarjeta.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminarTarjeta_Click(sender As Object, e As EventArgs) Handles btnEliminarTarjeta.Click
      Try
         If Me.dgvTarjetas.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la tarjeta seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaTarjetas()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBanc)
            bscCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim(), Entidades.Moneda.Peso)
         End Sub)
   End Sub
   Private Sub bscCodigoCuentaBancariaTransfBanc_BuscadorClick() Handles bscCodigoCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCodigoCuentaBancariaTransfBanc)
            bscCodigoCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion, bscCodigoCuentaBancariaTransfBanc.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscCodigoCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCuentaBancariaTransfBanc.Tag = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               bscCodigoCuentaBancariaTransfBanc.Selecciono = True
               bscCuentaBancariaTransfBanc.Selecciono = True
               dtpFechaTransferencia.Select()
            End If
         End Sub)
   End Sub

   'Segun como juega con las solapdas presenta otro error lo captura otra evento.
   'Private Sub txtBultos_Validated( sender As Object,  e As EventArgs) Handles txtBultos.Validated
   '   Try
   '      If Me.txtBultos.Text = "?????" Then
   '         Me.ErrorProvider1.SetError(Me.txtBultos, "Revisar cantidad de Bultos")
   '         MessageBox.Show("Revisar cantidad de Bultos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Else
   '         ErrorProvider1.SetError(Me.txtBultos, "")
   '      End If
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub cmbActividades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbActividades.SelectedIndexChanged
      Try
         If cmbActividades.SelectedItem IsNot Nothing AndAlso
            TypeOf (cmbActividades.SelectedItem) Is DataRowView AndAlso
            DirectCast(cmbActividades.SelectedItem, DataRowView).Row IsNot Nothing Then
            Dim drCmb As DataRow = DirectCast(cmbActividades.SelectedItem, DataRowView).Row
            Dim drCol As DataRow() = _dtActividades.Select(String.Format("IdProvincia = '{0}'",
                                                                         drCmb("IdProvincia")))
            If drCol.Length > 0 Then
               drCol(0)("IdActividad") = drCmb("IdActividad")
               drCol(0)("NombreActividad") = drCmb("NombreActividad")
               drCol(0)("Porcentaje") = drCmb("Porcentaje")
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Me.CalcularTotales()
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick

      Dim codigoProveedor As Long = -1

      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedor As Reglas.Proveedores = New Reglas.Proveedores
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedor.GetFiltradoPorCtaOrden()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub FacturacionV2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

      Dim intRegistros As Integer

      If Not Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
         intRegistros = Me.dgvProductos.RowCount
      Else
         intRegistros = Me.dgvRemitoTransp.RowCount
      End If

      If intRegistros <> 0 Then
         If MessageBox.Show("Quedan Productos pendientes de Grabar, desea salir de todas formas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
            e.Cancel = True
            Return
         End If
      End If
      'If e.CloseReason = CloseReason.UserClosing Then
      '   e.Cancel = True
      '   Me.Hide()
      'End If
   End Sub

   Private Sub bscDireccion_BuscadorClick() Handles bscDireccion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Select Case cmbBusquedaDomicilio.SelectedItem.ToString()
            Case BusquedaClienteSecundaria_DOMICILIO
               _publicos.PreparaGrillaClientes2(bscDireccion)
               Dim oClientes As Reglas.Clientes = New Reglas.Clientes
               bscDireccion.Datos = oClientes.GetFiltradoPorDireccion(bscDireccion.Text.Trim())
            Case BusquedaClienteSecundaria_CUIT
               _publicos.PreparaGrillaClientes2(bscDireccion)
               Dim oClientes As Reglas.Clientes = New Reglas.Clientes
               bscDireccion.Datos = oClientes.GetFiltradoPorCUIT(bscDireccion.Text.Trim())
            Case BusquedaClienteSecundaria_EMBARCACION
               _publicos.PreparaGrillaEmbarcaciones(bscDireccion)
               Dim oEmbarcaciones As Reglas.Embarcaciones = New Reglas.Embarcaciones()
               bscDireccion.Datos = oEmbarcaciones.GetFiltradoPorNombre(bscDireccion.Text.Trim())
            Case BusquedaClienteSecundaria_CAMA
               _publicos.PreparaGrillaCamas(bscDireccion)
               Dim oCamas As Reglas.Camas = New Reglas.Camas
               bscDireccion.Datos = oCamas.GetCamaPorCodigo(bscDireccion.Text.Trim())
         End Select
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscDireccion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDireccion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Select Case cmbBusquedaDomicilio.SelectedItem.ToString()
               Case BusquedaClienteSecundaria_DOMICILIO
                  CargarDatosCliente(e.FilaDevuelta)
               Case BusquedaClienteSecundaria_CUIT
                  CargarDatosCliente(e.FilaDevuelta)
               Case BusquedaClienteSecundaria_EMBARCACION
                  CargarDatosEmbarcacion(e.FilaDevuelta)
               Case BusquedaClienteSecundaria_CAMA
                  CargarDatosCama(e.FilaDevuelta)
            End Select
         End If
      Catch ex As Exception
         ShowError(ex)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub txtProductoObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoObservacion.KeyDown
      If e.KeyCode = Keys.Enter Then
         Dim oProd As Reglas.Productos = New Reglas.Productos()
         Dim prod As Entidades.Producto = New Entidades.Producto()
         prod = oProd.GetUno(Me.bscCodigoProducto2.Text)

         If txtCantidadManual.Enabled And Not prod.EsObservacion Then
            Me.txtCantidadManual.Focus()
         Else
            If cmbNota.Enabled And cmbNota.Visible Then
               cmbNota.Focus()
            Else
               Me.btnInsertar.Focus()
            End If
         End If
      End If
   End Sub

   Private Sub dgvProductos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProductos.CellFormatting
      If e.ColumnIndex = PrecioIVA.Index Then
         e.FormattingApplied = True
         Dim row As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
         If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
            Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            e.Value = String.Format("{0:N2}", CDec(row.Cells(Precio.Name).Value))
         Else
            e.Value = String.Format("{0:N2}", (CDec(row.Cells(Precio.Name).Value) * (CDec(row.Cells(AlicuotaImpuesto.Name).Value) + 100) / 100) +
                                              CDec(row.Cells(ImporteImpuestoInterno.Name).Value))
         End If
      End If
   End Sub

   Private _PlanesTarjetas As Boolean

   Private Sub btnPlanesTarjetas_Click(sender As Object, e As EventArgs) Handles btnPlanesTarjetas.Click
      Try
         _PlanesTarjetas = True

         If Me._tarjetas.Count > 0 Then
            If ShowPregunta("Al cambiar los planes de las tarjetas se perderán los registros de tarjeta ya ingresado. ¿Desea continuar?") = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         End If

         Dim prevDescRecGralPorc As Decimal = Decimal.Parse(txtDescRecGralPorc.Text)

         Me.txtDescRecGralPorc.Text = (0).ToString("N" + _decimalesEnDescRec.ToString())
         _clienteTieneDescRec = False

         Try
            Me.CalcularDatosDetalle()
         Catch ex As Exception
            ShowError(ex)
         End Try

         Dim totalGeneral As Decimal = Decimal.Parse(txtTotalGeneral.Text)

         Using frm = New SeleccionPlanesTarjetas(totalGeneral,
                                                 txtEfectivo.ValorNumericoPorDefecto(0D),
                                                 txtTransferenciaBancaria.ValorNumericoPorDefecto(0D),
                                                 txtTickets.ValorNumericoPorDefecto(0D),
                                                 txtCheques.ValorNumericoPorDefecto(0D),
                                                 txtImporteDolares.ValorNumericoPorDefecto(0D),
                                                 _tarjetas, False,
                                                 0)
            '-- REQ-34675.- -----------------------
            frm._fechaComprobante = dtpFecha.Value
            '--------------------------------------
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

               '# En caso de que la modificación del D/R Gral esté activado
               '# Se debe avisar al usuario que se va a sobreescribir dicho d/r con los d/r asociados a las tarjetas.
               If Me.chbModificaDescRecGralPorc.Checked Then
                  ShowMessage(String.Format("ATENCIÓN: Se va a sobreescribir el D/R Gral ingresado manualmente ({0}%) por el D/R asociado a los Planes de Tarjetas.", prevDescRecGralPorc.ToString()))
                  Me.chbModificaDescRecGralPorc.Checked = False
               End If

               dgvTarjetas.DataSource = Me._tarjetas.ToArray()

               txtEfectivo.Text = frm.Efectivo.ToString(txtEfectivo.Formato)
               txtImporteDolares.SetValor(frm.Dolares)

               '-- REQ- 34513.- -----------------------------------------------------------------------------
               txtTransferenciaBancaria.Text = frm.Transferencia.ToString(txtTransferenciaBancaria.Formato)
               txtTickets.Text = frm.Tickets.ToString(txtTickets.Formato)
               txtCheques.Text = frm.Cheques.ToString(txtCheques.Formato)
               '---------------------------------------------------------------------------------------------
               If totalGeneral <> frm.ImporteTotalConInterses Then
                  'Si eligio mas de una, tengo que redondear el coeficiente por mas que luego tenga que ajustar algo.
                  '-- REQ- 34513.- -----------------------------------------------------------------------------
                  If Me.dgvTarjetas.RowCount > 1 Or frm.Efectivo <> 0 Or frm.Transferencia <> 0 Or frm.Tickets <> 0 Or frm.Cheques <> 0 Then
                     txtDescRecGralPorc.Text = Decimal.Round((frm.ImporteTotalConInterses / totalGeneral * 100) - 100, _decimalesEnDescRec).ToString("N" + _decimalesEnDescRec.ToString())
                  Else
                     'Si eligio sola una, tomo ese % porque un 12% puede mostrar 11.99.

                     Me.txtDescRecGralPorc.Text = Me._tarjetas(0).Tarjeta.PorcIntereses.ToString("N" + _decimalesEnDescRec.ToString())

                  End If
               Else
                  Me.txtDescRecGralPorc.Text = (0).ToString("N" + _decimalesEnDescRec.ToString())
               End If
               _DescRecGralPorc = Decimal.Parse(txtDescRecGralPorc.Text)
            Else
               Me.txtDescRecGralPorc.Text = prevDescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
            End If

            Try
               Me.CalcularDatosDetalle()
               If Math.Abs(Decimal.Parse(txtDiferencia.Text)) < 1 AndAlso _tarjetas.Count > 0 Then
                  _tarjetas(_tarjetas.Count - 1).Monto = _tarjetas(_tarjetas.Count - 1).Monto + Decimal.Parse(txtDiferencia.Text)
                  Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()
               End If
               Me.CalcularPagos(_recalcularEfectivoAlCargarTarjeta)
            Catch ex As Exception
               ShowError(ex)
            End Try

         End Using

      Catch ex As Exception
         ShowError(ex)
      Finally
         _PlanesTarjetas = False
      End Try
   End Sub

   Private Sub dgvTarjetas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTarjetas.CellDoubleClick
      Try
         If btnInsertarTarjeta.Enabled Then
            Me.LimpiarCamposTarjetas()
            'carga el producto seleccionado de la grilla en los textbox 
            Me.CargarTarjetaCompleto(Me.dgvTarjetas.Rows(e.RowIndex))
            'elimina el producto de la grilla
            Me.EliminarLineaTarjetas()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
      Try
         Me.ChequeaCajas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAFIPConceptoCM05_CheckedChanged(sender As Object, e As EventArgs) Handles chbAFIPConceptoCM05.CheckedChanged

      If Not chbAFIPConceptoCM05.Checked Then
         cmbAFIPConceptoCM05.SelectedIndex = -1
      End If

      cmbAFIPConceptoCM05.Enabled = chbAFIPConceptoCM05.Checked

      If chbAFIPConceptoCM05.Checked Then
         cmbAFIPConceptoCM05.Select()
      End If
   End Sub


#End Region

#Region "Metodos"
   ''' <summary>
   ''' Guardo la lista de Precios anterior para el caso de cmabio por bonificacion.
   ''' y solo la primera vez.
   ''' </summary>
   Private Sub GuardoListaPreciosPrevia()
      '-- REQ-41748.- -------------------------------------------------------
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

   Private Sub SeteaIVASegunComprobante(vp As Entidades.VentaProducto, tpComp As Entidades.TipoComprobante, setearPrecio As Boolean)

      If tpComp.GrabaLibro Or tpComp.EsPreElectronico Or tpComp.UtilizaImpuestos Then
         '-- REQ-32869.- -------------------------------------
         If _clienteE.CategoriaFiscal.UtilizaImpuestos Then

            '# Si la alicuota del VP es 0%, quiere decir que el IVA NO fue modificado manualmente ya que vengo de un comprobante que NO UTILIZA imp.
            '# En ese caso, se debe colocar el IVA del ABM Producto. Si es <> 0%, NO lo modifico ya que fué modificado anteriormente.
            If vp.AlicuotaImpuesto = 0 Then
               vp.AlicuotaImpuesto = vp.Producto.Alicuota
            End If

            '# Si el comprobante además de utilizar impuestos, GRABA LIBRO, SI O SI debe ir el IVA del Prodducto ABM.
            If tpComp.GrabaLibro Or tpComp.EsPreElectronico Then
               vp.AlicuotaImpuesto = vp.Producto.Alicuota
            End If

            '# Alicuota 2
            If Reglas.Publicos.ProductoUtilizaAlicuota2 AndAlso cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal)().ResuelveUtilizaAlicuota2Producto(_clienteE) AndAlso vp.Producto.Alicuota2.HasValue Then
               vp.AlicuotaImpuesto = vp.Producto.Alicuota2.Value
            End If

            If setearPrecio Then
               If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                  vp.Precio = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), _decimalesRedondeoEnPrecio)
               End If
            End If
         End If
         '--------------------------------------------------------
      Else

         '# Si la alicuota del VP <> alicuota ProductoABM, quiere decir que se fue modificado manualmente ya que vengo de un comprobante que UTILIZA IMP. En ese caso, NO lo modifico.
         '# Caso contrario, llevo la alicuota VP a 0%.
         If vp.AlicuotaImpuesto = vp.Producto.Alicuota Then
            vp.AlicuotaImpuesto = 0
         End If
         If setearPrecio Then
            vp.Precio = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), _decimalesRedondeoEnPrecio)
         End If

      End If

   End Sub

   Private Sub SeteaConversionUnidadesMedida()
      SeteaConversionUnidadesMedida(Me.bscCodigoProducto2, Me.bscProducto2, Me.cmbUM2, Me.txtCantidad, Me.txtCantidadManual)
   End Sub
   Private Sub SeteaConversionUnidadesMedidaRT()
      SeteaConversionUnidadesMedida(Me.bscCodigoProducto2RT, Me.bscProducto2RT, Me.cmbUM2RT, Me.txtCantidadRT, Me.txtCantidadManualRT)
   End Sub

   Friend Shared Sub SeteaConversionUnidadesMedida(bscCodigo As Eniac.Controles.Buscador2, bscNombre As Eniac.Controles.Buscador2, cmbUM As Eniac.Controles.ComboBox, txtCantidad As TextBox, txtCantidadManual As TextBox)
      '# En caso de que la unidad de medida seleccionada NO sea la unidad de medida principal del producto, realizo la conversión
      Dim fila = If(bscCodigo.FilaDevuelta IsNot Nothing, bscCodigo.FilaDevuelta, bscNombre.FilaDevuelta)
      If fila IsNot Nothing Then
         txtCantidad.Text = RealizarConversionUnidadesMedida(txtCantidadManual.ValorNumericoPorDefecto(0D),
                                                             Decimal.Parse(fila.Cells("Conversion").Value.ToString()),
                                                             cmbUM).ToString()
      Else
         txtCantidad.Text = txtCantidadManual.Text
      End If
   End Sub

   Private Shared Function RealizarConversionUnidadesMedida(cantidadAConvertir As Decimal, valorConversion As Decimal, combo As Eniac.Controles.ComboBox) As Decimal

      '# Si la UM seleccionada es la 2da, se realiza la conversión. En caso de que la UM seleccionada sea la principal, no se realiza ninguna conversión.
      Dim result As Decimal = cantidadAConvertir
      If combo.Items.Count > 1 AndAlso combo.SelectedIndex > 0 Then
         result = (cantidadAConvertir / valorConversion)
      End If
      Return result

   End Function

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

   Private Sub CargarLotesPreviamenteSeleccionados(vp As Entidades.VentaProducto)

      If _lotesSeleccionados Is Nothing Then
         _lotesSeleccionados = New DataTable
         _lotesSeleccionados.Columns.Add("IdSucursal", GetType(Integer))
         _lotesSeleccionados.Columns.Add("IdProducto", GetType(String))
         _lotesSeleccionados.Columns.Add("IdLote", GetType(String))
         _lotesSeleccionados.Columns.Add("FechaVencimiento", GetType(Date))
         _lotesSeleccionados.Columns.Add("CantidadSeleccionada", GetType(Decimal))
      End If

      For Each vpl As Entidades.VentaProductoLote In vp.VentasProductosLotes
         Dim row As DataRow = _lotesSeleccionados.NewRow
         row("IdSucursal") = vpl.IdSucursal
         row("IdProducto") = vpl.IdProducto
         row("IdLote") = vpl.IdLote
         If vpl.FechaVencimiento IsNot Nothing Then
            row("FechaVencimiento") = vpl.FechaVencimiento
         End If
         row("CantidadSeleccionada") = vpl.Cantidad
         _lotesSeleccionados.Rows.Add(row)
      Next

   End Sub

   Private Sub CargarLotesSeleccionados(lotesSeleccionados As DataTable,
                                        lineaDetalle As Entidades.VentaProducto,
                                        _productoTemporal As Entidades.Producto)
      Me.CargarLotesSeleccionados(lotesSeleccionados,
                                  lineaDetalle,
                                  _productoTemporal,
                                  precioCosto:=0,
                                  idMoneda:=0)
   End Sub

   Private Sub CargarLotesSeleccionados(lotesSeleccionados As DataTable,
                                        lineaDetalle As Entidades.VentaProducto,
                                        _productoTemporal As Entidades.Producto,
                                        precioCosto As Decimal,
                                        idMoneda As Integer)

      For Each row As DataRow In lotesSeleccionados.Rows

         '# Validar que no se haya sobrepasado el stock del lote con los productos ya agregados anteriormente
         Dim cantidadTotal As Decimal = 0
         For Each vp As Entidades.VentaProducto In _ventasProductos
            cantidadTotal = vp.VentasProductosLotes.Where(Function(vpl) vpl.IdLote = row("IdLote").ToString() And vpl.IdProducto.Equals(row("IdProducto").ToString())).Sum(Function(x) x.Cantidad)
            cantidadTotal += CDec(row("CantidadSeleccionada"))
            If cantidadTotal > CDec(row("CantidadActual")) Then
               Throw New Exception(String.Format("ATENCIÓN: La cantidad ingresada del lote {0} del producto {1} superaría la cantidad en stock.", row("IdLote"), row("NombreProducto")))
            End If
         Next

         _productoLoteTemporal = New Entidades.VentaProductoLote

         '# Validar Fecha de Vencimiento
         If Reglas.Publicos.LoteSolicitaFechaVencimiento Then
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock > 0 Then
               If row.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString()) = Me.dtpFecha.Value.Date Then
                  If ShowPregunta("La fecha del lote es igual a la fecha del comprobante. Desea continuar?") <> Windows.Forms.DialogResult.Yes Then
                     Exit Sub
                  End If
               ElseIf row.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString()) < Me.dtpFecha.Value.Date Then
                  If ShowPregunta("La fecha del lote es menor que la fecha del comprobante. Desea continuar?") <> Windows.Forms.DialogResult.Yes Then
                     Exit Sub
                  End If
               End If
               _productoLoteTemporal.FechaVencimiento = row.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString())
            Else
               _productoLoteTemporal.FechaVencimiento = row.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString())
            End If
         Else
            _productoLoteTemporal.FechaVencimiento = Nothing
         End If

         _productoLoteTemporal.IdSucursal = row.Field(Of Integer)(Entidades.ProductoLote.Columnas.IdSucursal.ToString())
         _productoLoteTemporal.Producto = _productoTemporal
         _productoLoteTemporal.IdLote = row.Field(Of String)(Entidades.ProductoLote.Columnas.IdLote.ToString())
         _productoLoteTemporal.Cantidad = row.Field(Of Decimal)("CantidadSeleccionada")
         _productoLoteTemporal.Orden = _numeroOrden

         lineaDetalle.VentasProductosLotes.Add(_productoLoteTemporal)

         '# Si se manejan Precio Costo
         If precioCosto <> 0 Then
            If Reglas.Publicos.UtilizaPrecioCostoPorLote Then
               precioCosto = _productoLoteTemporal.Producto.PrecioCosto
               If Reglas.Publicos.PreciosConIVA Then
                  precioCosto = Decimal.Round(precioCosto / (1 + lineaDetalle.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
               End If
               If idMoneda = 2 Then
                  precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
               End If
            End If
         End If
      Next

      '# Luego de cargar los lotes que se seleccionaron en la entidad, mantengo la estructura pero limpio el datatable
      If _lotesSeleccionados IsNot Nothing Then
         _lotesSeleccionados.Clear()
      End If

   End Sub

   Private Sub LimpiarPaciente()
      Me.bscPaciente.Text = ""
      Me.bscCodigoPaciente.Text = ""

      Me.bscPaciente.Permitido = True
      Me.bscCodigoPaciente.Permitido = True
   End Sub

   Private Sub LimpiarDoctor()
      Me.bscDoctor.Text = ""
      Me.bscCodigoDoctor.Text = ""

      Me.bscDoctor.Permitido = True
      Me.bscCodigoDoctor.Permitido = True
   End Sub

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

   Private Sub CalcularFechaDiasDevolucion()

      '# Según la cantidad de días ingresado por el usuario, calculo la fecha de devolución. 
      If Me.rbCantDiasFechaDevolucion.Checked Then
         Me.dtpFechaDevolucion.Value = Date.Now.AddDays(CInt(Me.txtCantDiasFechaDevolucion.Text))
      Else '# Según la fecha ingresada por el usuario, calculo la cantidad de días.
         Me.txtCantDiasFechaDevolucion.Text = Me.dtpFechaDevolucion.Value.Subtract(Date.Today).Days.ToString()
      End If

   End Sub

   Private Sub MostrarNumerosLotesDesdeGrilla(grilla As DataGridView, e As DataGridViewCellEventArgs)
      If grilla.Columns(e.ColumnIndex).Name = "NrosLotes" Or grilla.Columns(e.ColumnIndex).Name = "NrosLotesRT" Then
         Dim eVentaProducto As Entidades.VentaProducto = DirectCast(grilla.SelectedRows(0).DataBoundItem, Eniac.Entidades.VentaProducto)

         If Not eVentaProducto.Producto.Lote Then
            ShowMessage("Este producto no utiliza Lote.")
            Exit Sub
         End If

         '# Reconstruyo los lotes seleccionados - solo si hay seleccionados - 
         If eVentaProducto.VentasProductosLotes.Count <> 0 Then
            Me.CargarLotesPreviamenteSeleccionados(eVentaProducto)
         End If

         Dim coeficienteStock As Integer = DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock
         If coeficienteStock = 0 And
            Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario) Then
            Dim tipoSecundario As Entidades.TipoComprobante
            tipoSecundario = New Reglas.TiposComprobantes().GetUno(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario)
            coeficienteStock = tipoSecundario.CoeficienteStock
         End If

         '--Si viene de invocacion no muestra Lotes
         If _comprobantesSeleccionados.Count > 0 AndAlso _comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock Then
            Exit Sub
         End If

         If (eVentaProducto.Producto.IdSucursal = 0) Then eVentaProducto.Producto.IdSucursal = actual.Sucursal.Id
            Using frm As SeleccionNrosLotes = New SeleccionNrosLotes(eVentaProducto.Producto, eVentaProducto.IdDeposito, eVentaProducto.IdUbicacion, eVentaProducto.Cantidad, coeficienteStock, _lotesSeleccionados)
               If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  '# Me guardo los lotes seleccionados
                  _lotesSeleccionados = frm._lotesSeleccionados
                  Me.CargarLotesSeleccionados(_lotesSeleccionados, eVentaProducto, eVentaProducto.Producto)
               End If
            End Using
         End If
   End Sub

   Private Sub MostrarNumerosSerieDesdeGrilla(grilla As DataGridView, e As System.Windows.Forms.DataGridViewCellEventArgs)

      If grilla.Columns(e.ColumnIndex).Name = "NrosSerie" Or grilla.Columns(e.ColumnIndex).Name = "NrosSerieRT" Then
         If e.RowIndex <> -1 Then

            Dim nrosSerie As DataTable
            Dim rNrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()
            Dim cantidadDeProductos As Integer = 0
            Dim invocado As Boolean = False

            Dim drVP = DirectCast(DirectCast(grilla.SelectedRows(0), DataGridViewRow).DataBoundItem, Eniac.Entidades.VentaProducto)
            If drVP.Producto.NrosSeries.Count > 0 Then

               cantidadDeProductos = drVP.Producto.NrosSeries.Count

               If _comprobantesSeleccionados.Count > 0 AndAlso _comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock Then
                  nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, drVP.IdDeposito, drVP.IdUbicacion, drVP.Producto.IdProducto, drVP.Producto.NrosSeries.ConvertAll(Function(ns) ns.NroSerie))
                  invocado = True
               Else
                  If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 Then
                     nrosSerie = rNrosSerie.GetNrosSerieProductoClienteVendido(actual.Sucursal.Id, drVP.Producto.IdProducto, _clienteE.IdCliente)
                  Else
                     '-- REQ-32489.- -----------------------------------------------------------------------------------------------------------
                     nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, drVP.IdDeposito, drVP.IdUbicacion, drVP.Producto.IdProducto)
                  End If
               End If
               If Not invocado Then
                  Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, drVP.Producto, nrosSerie)
                  If sel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     drVP.Producto.NrosSeries.Clear()
                     drVP.Producto.NrosSeries = sel.ProductosNrosSerie
                  End If
               End If

            Else
               If drVP.Producto.NroSerie Then

                  cantidadDeProductos = Integer.Parse(Math.Round(drVP.Cantidad, 0).ToString())

                  '-- REQ-32489.- -----------------------------------------------------------------------------------------------------------
                  nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, drVP.IdDeposito, drVP.IdUbicacion, drVP.Producto.IdProducto)

                  Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, drVP.Producto, nrosSerie)
                  If sel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     drVP.Producto.NrosSeries.Clear()
                     drVP.Producto.NrosSeries = sel.ProductosNrosSerie
                  End If

               Else
                  ShowMessage("El producto no tiene definido numero de serie")
               End If

            End If
         End If
      End If
   End Sub

   Private Function ValidarLimiteCredito(arrojarException As Boolean) As Boolean?
      If Decimal.Parse(Me.txtSaldoCtaCte.Text) + Decimal.Parse(Me.txtTotalGeneral.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
         Select Case Publicos.ControlaEventosdeLimiteDeCreditoDeClientes
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
      Me.txtLimiteDiasVto.Text = (0).ToString()

      '# Controlo Limite Dias Vto Factura 
      If Me._clienteE Is Nothing OrElse
         Me.cmbTiposComprobantes.SelectedIndex = -1 Then Exit Sub

      If Me._clienteE.LimiteDiasVtoFactura > 0 AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = 1 Then
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
               Me.txtLimiteDiasVto.Text = Dias.ToString()

               Select Case Publicos.ControlaDiasVtoDeCreditoDeClientes
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

   Private Function InsertarTarjetaTeclaRapidaF3() As Boolean
      Me._tarjetas.Clear()
      Dim tarjeta As Entidades.Tarjeta
      Dim banco As Entidades.Banco
      Dim cuotas As Integer
      Try
         tarjeta = New Reglas.Tarjetas().GetUno(Reglas.Publicos.Facturacion.FacturacionTarjetaAutomatico)
         banco = New Reglas.Bancos().GetUno(Reglas.Publicos.Facturacion.FacturacionBancoTarjetaAutomatico)

         cuotas = Math.Max(cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).CantidadCuotas, 1)
      Catch ex As Exception
         Throw New Exception(String.Format("Error guardando automáticamente con TARJETA (F3):", ex.Message), ex)
      End Try

      If ShowPregunta(String.Format("El pago se realizara totalmente en con TARJETA{0}{0}Tarjeta: {2}{0}Banco: {1}{0}Cuotas:{3}{0}{0}¿Desea continuar?",
                                    Environment.NewLine, banco.NombreBanco, tarjeta.NombreTarjeta, cuotas)) = Windows.Forms.DialogResult.Yes Then
         InsertarTarjetaGrilla(tarjeta, banco, Decimal.Parse(txtTotalGeneral.Text), cuotas, 0, 0)
         Return True
      Else
         Return False
      End If

   End Function

   'Por ahora no se usa.
   Private Function PuedoCancelarVenta() As Boolean
      Return BaseSeguridad.ControloPermisos(Eniac.Entidades.Usuario.Actual.Sucursal.Id, Eniac.Ayudantes.Common.usuario, funcionActual, funcionSupervisor)
   End Function

   Private Sub CargarDatosBancos(dr As DataGridViewRow)
      Me.bscBancos.Text = dr.Cells("NombreBanco").Value.ToString()
      bscBancos.Tag = dr.Cells("IdBanco").Value.ToString()
      Me.bscCodBancos.Text = dr.Cells("IdBanco").Value.ToString()
   End Sub

   Private Sub CargarDatosTarjetasBancos(dr As DataGridViewRow)
      Me.bscTarBanco.Text = dr.Cells("NombreBanco").Value.ToString()
      bscTarBanco.Tag = dr.Cells("IdBanco").Value.ToString()
   End Sub

   Private Sub EliminarLineaCheques()
      Me._cheques.RemoveAt(Me.dgvCheques.SelectedRows(0).Index)

      Me.dgvCheques.DataSource = Me._cheques.ToArray()

      Me.CalcularPagos(False)
   End Sub

   Private Sub EliminarLineaTarjetas()
      Me._tarjetas.RemoveAt(Me.dgvTarjetas.SelectedRows(0).Index)

      Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()

      Me.CalcularPagos(_recalcularEfectivoAlCargarTarjeta)
   End Sub

   Private Sub CargarObservacionesChequesTarjetas()

      Dim oLineaDetalleObs As Entidades.VentaObservacion

      Me._ventasObservacionesCHTarjeta.Clear()

      Dim linea As Integer = 1

      For Each dr2 As Entidades.VentaObservacion In Me._ventasObservaciones
         oLineaDetalleObs = New Entidades.VentaObservacion()
         With oLineaDetalleObs
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .Linea = linea
            .Observacion = dr2.Observacion
         End With
         Me._ventasObservacionesCHTarjeta.Add(oLineaDetalleObs)
         linea += 1
      Next

      For Each dr As Entidades.Cheque In Me._cheques
         oLineaDetalleObs = New Entidades.VentaObservacion()
         With oLineaDetalleObs
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .Linea = linea
            .Observacion = String.Format("{0} - Suc: {1} - CP: {2} - Numero: {3} - Cobro: {4:dd/MM/yyyy} - $ {5} - Titular:{6}",
                                         dr.Banco.NombreBanco, dr.IdBancoSucursal, dr.Localidad.IdLocalidad, dr.NumeroCheque, dr.FechaCobro, dr.Importe, dr.Titular)
         End With

         Me._ventasObservacionesCHTarjeta.Add(oLineaDetalleObs)
         linea += 1
      Next

      For Each dr1 As Entidades.VentaTarjeta In Me._tarjetas
         oLineaDetalleObs = New Entidades.VentaObservacion()
         With oLineaDetalleObs
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .Linea = linea
            .Observacion = String.Format("{0} - Banco: {1} - Nro.Cupón: {2} - Cuotas: {3} - Monto: {4}",
                                         dr1.Tarjeta.NombreTarjeta, dr1.Banco.NombreBanco, dr1.NumeroCupon, dr1.Cuotas, dr1.Monto)
         End With

         Me._ventasObservacionesCHTarjeta.Add(oLineaDetalleObs)
         linea += 1
      Next

   End Sub

   Private Sub CalcularPagos(recalcularEfectivoSegunDiferencia As Boolean)

      Dim tarMon As Decimal = 0
      Dim pago As Decimal = 0
      Dim fPago As Entidades.VentaFormaPago = cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)()

      For i As Integer = 0 To Me._cheques.Count - 1
         pago += Me._cheques(i).Importe
      Next

      Me.txtCheques.Text = pago.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      For Each tar As Entidades.VentaTarjeta In Me._tarjetas
         tarMon += tar.Monto
      Next

      Me.txtTarjetas.Text = tarMon.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      If Me.txtTarjetas.Text.Length = 0 Then
         Me.txtTarjetas.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      End If
      If Me.txtTickets.Text.Length = 0 Then
         Me.txtTickets.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      End If
      If Me.txtEfectivo.Text.Length = 0 Then
         Me.txtEfectivo.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      End If
      If txtImporteDolares.Text.Length = 0 Then
         txtImporteDolares.SetValor(0D)
      End If
      If Me.txtTransferenciaBancaria.Text.Length = 0 Then
         Me.txtTransferenciaBancaria.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      End If

      pago = Math.Round(pago, _decimalesEnTotales) + txtEfectivo.ValorNumericoPorDefecto(0D) + txtTickets.ValorNumericoPorDefecto(0D) + txtTarjetas.ValorNumericoPorDefecto(0D) + txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) +
             (txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D))

      Me.txtTotalPago.Text = pago.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      If fPago IsNot Nothing AndAlso fPago.Dias = 0 AndAlso recalcularEfectivoSegunDiferencia AndAlso Decimal.Parse(txtDiferencia.Text) <> 0 Then
         txtEfectivo.Text = Math.Max(0, (Decimal.Parse(txtEfectivo.Text) + Decimal.Parse(txtDiferencia.Text))).ToString("N" + _decimalesEnTotales.ToString())

         CalcularPagos(False)
         'pago = Math.Round(pago, Me._valorRedondeo) + Decimal.Parse(Me.txtEfectivo.Text) + _
         '                        Decimal.Parse(Me.txtTickets.Text) + Decimal.Parse(Me.txtTarjetas.Text)

         'Me.txtTotalPago.Text = pago.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
         'Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      End If

   End Sub

   Private Sub LimpiarCamposCheques()
      Me.bscCodBancos.Text = ""
      Me.bscCodBancos.FilaDevuelta = Nothing
      Me.bscBancos.Text = ""
      Me.bscBancos.FilaDevuelta = Nothing
      Me.dtpFechaCobro.Value = Date.Now
      Me.dtpFechaEmision.Value = Date.Now
      Me.txtImporteCheque.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtNroCheque.Text = "0"
      Me.txtCodPostalCheque.Text = "0"
      Me.txtSucursalBanco.Text = "0"
      Me.txtTitularCheque.Text = ""
      Me.txtNroOperacion.Clear()
      Me.txtCuitChequeTercero.Clear()
      Me.cmbTipoCheque.SelectedValue = "F" '# Fisico
   End Sub

   Private Sub LimpiarCamposTarjetas()
      Me.cmbTarTarjeta.SelectedIndex = -1
      Me.bscTarBanco.Text = ""
      Me.bscTarBanco.FilaDevuelta = Nothing
      Me.txtTarCuotas.Text = "1"
      Me.txtTarMonto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTarNumeroCupon.Text = "0"
      Me.txtTarNumeroLote.Text = "0"
   End Sub

   Private Sub CalcularDescuentosProductos()
      If _clienteE Is Nothing Then Exit Sub
      If cmbTiposComprobantes.SelectedItem Is Nothing Then
         ShowMessage("Debe seleccionar un tipo de comprobante.")
         Exit Sub
      End If


      Me.txtDescRec.Text = CalculaDescuentosProductos(Decimal.Parse(Me.txtPrecio.Text),
                                                      Decimal.Parse(txtImpuestoInterno.Text),
                                                      Decimal.Parse(Me.txtDescRecPorc1.Text),
                                                      Decimal.Parse(Me.txtDescRecPorc2.Text),
                                                      Decimal.Parse(Me.txtCantidad.Text)).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      'Me.txtDescRec.Text = DescRecT.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))

   End Sub

   Private Function CalculaDescuentosProductos(precioProducto As Decimal, impInt As Decimal, descRecPorc1 As Decimal, descRecPorc2 As Decimal, cantidad As Decimal) As Decimal

      Dim DescRec1 As Decimal
      Dim DescRec2 As Decimal
      Dim DescRecT As Decimal

      'Dim precio As Decimal = Decimal.Parse(Me.txtPrecio.Text) - Decimal.Parse(txtImpuestoInterno.Text)

      Dim precioParaDescuento As Decimal = precioProducto
      'Se anula esta lógica porque no se permite más facturación con ImpInt fijos.
      'If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
      '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
      '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
      '      Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
      '      precioParaDescuento = precioProducto - impInt
      '   Else
      '      precioParaDescuento = precioProducto
      '   End If
      'Else
      '   precioParaDescuento = precioProducto
      'End If


      DescRec1 = precioParaDescuento * descRecPorc1 / 100

      DescRec2 = (precioParaDescuento + DescRec1) * descRecPorc2 / 100

      DescRecT = Decimal.Round((DescRec1 + DescRec2) * cantidad, Me._decimalesRedondeoEnPrecio)

      Return DescRecT
   End Function

   Private Sub CalcularDescuentosProductosRT(PrecioLista As Decimal)
      Dim DescRec1 As Decimal
      Dim DescRec2 As Decimal
      Dim DescRecT As Decimal

      DescRec1 = PrecioLista * DescRecPorc1RT / 100

      DescRec2 = (PrecioLista + DescRec1) * DescRecPorc2RT / 100

      DescRecT = Decimal.Round((DescRec1 + DescRec2) * Decimal.Parse(Me.txtCantidadRT.Text), Me._decimalesRedondeoEnPrecio)

      DescRecRT = DescRecT

   End Sub

   Private Function ValidarComprobante() As Boolean

      Publicos.GetSistema().ControlaValidezDeFecha(dtpFecha.Value)

      If Not Reglas.Publicos.Facturacion.PermitirComprobFechaFutura And Me.dtpFecha.Value > Date.Now Then
         MessageBox.Show("No puede Grabar el Comprobante con una Fecha mayor a " & Date.Now.ToString("dd/MM/yyyy"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False
      End If

      Dim tpCompo = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
         DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
         Dim dt As DataTable = oPF.Get1(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
         If dt.Rows.Count = 0 Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not Boolean.Parse(dt.Rows(0)("VentasHabilitadas").ToString()) Then
            ShowMessage(String.Format("El Período Fiscal '{0}' no está habilitado para emitir Comprobantes de Venta.", dtpFecha.Value.ToString("yyyy/MM")))
            Me.dtpFecha.Focus()
            Return False
         End If
      End If


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
      If cmbEmisor.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar un Centro Emisor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbEmisor.Focus()
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

      If Me._ventasProductos.Count = 0 Then
         MessageBox.Show("No se cargó ningún producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
         If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
            Me.bscProducto2.Focus()
         Else
            Me.bscCodigoProducto2.Focus()
         End If
         Return False
      End If

      If Me._clienteE Is Nothing Then
         MessageBox.Show("Falta cargar el Código del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCodigoCliente.Focus()
         Return False
      Else
         If String.IsNullOrWhiteSpace(Me._clienteE.Direccion) Then
            MessageBox.Show("El cliente no tiene cargada dirección. Por favor modifique el cliente y vuelva a intentar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            llbCliente_LinkClicked(llbCliente, Nothing)
            Me.bscCodigoCliente.Focus()
            Return False
         End If
         If Me._clienteE.IdLocalidad <= 0 Then
            MessageBox.Show("El cliente no tiene cargada localidad. Por favor modifique el cliente y vuelva a intentar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoCliente.Focus()
            Return False
         End If
      End If

      If Not Me._ventasConProductosEnCero And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
         'verifico que ningun producto tenga precio cero
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            If Not pro.Producto.EsObservacion And pro.ImporteTotal = 0 Then
               MessageBox.Show("No puede haber productos con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
               If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
                  Me.bscProducto2.Focus()
               Else
                  Me.bscCodigoProducto2.Focus()
               End If
               Return False
            End If
         Next
      End If

      If _clienteE.IdSucursalAsociada <> 0 AndAlso Not cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).EsRemitoTransportista Then
         'Se agrega esta validación porque consideramos que para operaciones entre empresas diferentes, donde hay que hacer facturas, el circuito debería ser otro.
         'Si se levanta la restricción evaluar que pasa con la compra que se debe registrar en la otra empresa.
         ShowMessage("Solo se pueden usar clientes/sucursales con Remitos de Transporte")
         Return False
      End If

      If _clienteE.IdSucursalAsociada <> 0 And
         cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).EsRemitoTransportista And
         cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).CoeficienteValores = -1 And
         _ventasProductos.Any(Function(vp) vp.Producto.NrosSeries.Any()) Then
         'Se agrega esta validación porque cuando se desea registrar una NC de un producto con Nro de Serie de un cliente/sucursal (mueve entre sucursales)
         'el Nro de Serie que se desea mover está en la otra sucursal. No está disponible en esta, por lo que decidimos bloquearlo.
         ShowMessage(String.Format("No se pueden registrar {0} (CoeficienteValores = -1) con productos con Nro de Serie.", cmbTiposComprobantes.Text))
         Return False
      End If

      If Not _transferencias.Any() AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
         MessageBox.Show("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If Decimal.Parse(Me.txtTransferenciaBancaria.Text) < 0 Then
         MessageBox.Show("El importe de Transferencia Bancaria no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      '*** Controlo la Facturacion Sin Stock ***
      Dim rStock As Reglas.Stock = New Reglas.Stock()
      Dim prodSinStock As Entidades.ProductosSinStock()
      prodSinStock = rStock.ControlarStockVenta(actual.Sucursal.Id, cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante), _ventasProductos, _comprobantesSeleccionados)

      If prodSinStock.Count > 0 Then
         Dim stbMensaje As StringBuilder = New StringBuilder()
         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            stbMensaje.AppendLine("No es posible facturar los siguientes productos porque no hay stock suficiente.")
         ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
            stbMensaje.AppendLine("Va a facturar los siguientes productos aunque no tenga stock suficiente.")
         End If
         stbMensaje.AppendLine()
         For Each prodSS As Entidades.ProductosSinStock In prodSinStock
            stbMensaje.AppendFormatLine("    - {0} {1} - Cantidad: {2} - Stock: {3}", prodSS.Producto.IdProducto, prodSS.Producto.NombreProducto, prodSS.Cantidad, prodSS.Stock)
         Next
         ShowMessage(stbMensaje.ToString())
         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            Return False
         End If
      End If

#Region "Marcado"
      ' '' ''PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), ó invoco (no corresponde)
      ' '' ''los valores posibles para el coeficientestock son 0, 1 y -1

      '' ''Dim blnControlarStock As Boolean = False

      '' ''If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0 Or
      '' ''   (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 AndAlso Reglas.Publicos.Facturacion.FacturarSinStockControlaNoAfectaStock) Then

      '' ''   'Si NO facturo otros (ej: Factura sin Facturables).

      '' ''   If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 OrElse Me._comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = 0 Then
      '' ''      'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).

      '' ''      blnControlarStock = True

      '' ''   End If

      '' ''End If

      '' ''If _comprobantesSeleccionados IsNot Nothing AndAlso _comprobantesSeleccionados.Count > 0 Then
      '' ''   If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFacturador And
      '' ''      _comprobantesSeleccionados.Where(Function(x) x.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString()).Count > 0 Then
      '' ''      ShowMessage(String.Format("El tipo de comprobante {0} no permite invocar comprobantes de Venta.", cmbTiposComprobantes.Text))
      '' ''      Return False
      '' ''   End If
      '' ''   If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).InvocaCompras And
      '' ''      _comprobantesSeleccionados.Where(Function(x) x.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString()).Count > 0 Then
      '' ''      ShowMessage(String.Format("El tipo de comprobante {0} no permite invocar comprobantes de Compras.", cmbTiposComprobantes.Text))
      '' ''      Return False
      '' ''   End If
      '' ''End If

      '' ''If blnControlarStock AndAlso Reglas.Publicos.Facturacion.FacturarSinStock <> "PERMITIR" Then
      '' ''   'Validacion de Stock segun Parametro
      '' ''   Dim cantidadTotal As Decimal = 0
      '' ''   Dim ProductosCadena As String = ""
      '' ''   Dim producto As String
      '' ''   Dim ProdRepetido As DataTable = New DataTable()
      '' ''   ProdRepetido.Columns.Add("ProdRepetido", System.Type.GetType("System.String"))
      '' ''   ProdRepetido.Columns.Add("NombreProducto", System.Type.GetType("System.String"))
      '' ''   Dim dr2 As DataRow
      '' ''   Dim entro As Boolean = False
      '' ''   Dim ocomponentes1 As Reglas.ProductosComponentes
      '' ''   Dim ocomponentes2 As Reglas.ProductosComponentes
      '' ''   Dim _componentes As DataTable
      '' ''   Dim oProductos1 As Reglas.Productos
      '' ''   Dim Producto1 As Entidades.Producto
      '' ''   Dim entro2 As Boolean = False

      '' ''   For Each pro As Entidades.VentaProducto In Me._ventasProductos

      '' ''      If entro2 Then
      '' ''         Exit For
      '' ''      End If

      '' ''      producto = pro.IdProducto

      '' ''      oProductos1 = New Reglas.Productos()
      '' ''      Producto1 = New Entidades.Producto()

      '' ''      'Busco el producto Nuevamente aunque este en la Coleccion porque pudo ajustar alguna caracterisca luego de algun hipotetico mensaje anterior.
      '' ''      Producto1 = oProductos1.GetUno(pro.IdProducto, False)

      '' ''      If Producto1.AfectaStock Then

      '' ''         If Producto1.EsCompuesto Then

      '' ''            If Producto1.DescontarStockComponentes Then
      '' ''               ocomponentes2 = New Reglas.ProductosComponentes()
      '' ''               _componentes = ocomponentes2.GetComponentes(actual.Sucursal.IdSucursal, Producto1.IdProducto, Producto1.IdFormula, 0)

      '' ''               For Each dr1 As DataRow In _componentes.Rows

      '' ''                  If entro2 Then
      '' ''                     Exit For
      '' ''                  End If

      '' ''                  cantidadTotal = Decimal.Parse(dr1("Cantidad").ToString()) * pro.Cantidad

      '' ''                  Dim prodSuc As Entidades.ProductoSucursal = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.IdSucursal, dr1("IdProductoComponente").ToString())

      '' ''                  'Sumo cantidades en productos repetidos para controlar stock
      '' ''                  For Each pro1 As Entidades.VentaProducto In Me._ventasProductos

      '' ''                     'If pro1.IdProducto = producto Then
      '' ''                     '   cantidadTotal = cantidadTotal + pro1.Cantidad
      '' ''                     'End If
      '' ''                     Dim produ3 As Entidades.Producto = New Reglas.Productos().GetUno(pro1.IdProducto, False)

      '' ''                     If produ3.EsCompuesto Then
      '' ''                        If produ3.DescontarStockComponentes Then
      '' ''                           ocomponentes1 = New Reglas.ProductosComponentes()
      '' ''                           Dim _componentes2 As DataTable
      '' ''                           _componentes2 = ocomponentes1.GetComponentes(actual.Sucursal.IdSucursal, produ3.IdProducto, produ3.IdFormula, 0)
      '' ''                           For Each dr4 As DataRow In _componentes2.Rows
      '' ''                              If producto = dr4("IdProductoComponente").ToString() Then
      '' ''                                 cantidadTotal = cantidadTotal + Decimal.Parse(dr4("Cantidad").ToString()) * pro1.Cantidad
      '' ''                              End If
      '' ''                           Next
      '' ''                        End If

      '' ''                     Else
      '' ''                        producto = pro1.IdProducto
      '' ''                        'Sumo cantidades en productos repetidos para controlar stock
      '' ''                        For Each pro2 As Entidades.VentaProducto In Me._ventasProductos
      '' ''                           If pro2.IdProducto = producto Then
      '' ''                              cantidadTotal = cantidadTotal + pro2.Cantidad
      '' ''                           End If
      '' ''                        Next
      '' ''                     End If
      '' ''                  Next

      '' ''                  'Controlo la cantidad total con el stock del producto
      '' ''                  If cantidadTotal > prodSuc.Stock And blnControlarStock Then
      '' ''                     'chequeo que ya no se haya controlado
      '' ''                     For Each rep As DataRow In ProdRepetido.Rows
      '' ''                        If pro.IdProducto = rep("ProdRepetido").ToString() Then
      '' ''                           entro = True
      '' ''                        End If
      '' ''                     Next
      '' ''                     If entro = True Then
      '' ''                     Else
      '' ''                        dr2 = ProdRepetido.NewRow()
      '' ''                        dr2("ProdRepetido") = prodSuc.Producto.IdProducto
      '' ''                        dr2("NombreProducto") = prodSuc.Producto.NombreProducto
      '' ''                        ProdRepetido.Rows.Add(dr2)
      '' ''                     End If

      '' ''                  End If
      '' ''                  entro = False
      '' ''                  cantidadTotal = 0

      '' ''                  For Each dr As DataRow In ProdRepetido.Rows
      '' ''                     ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      '' ''                     entro2 = True
      '' ''                  Next

      '' ''               Next
      '' ''            End If
      '' ''         Else
      '' ''            'Sumo cantidades en productos repetidos para controlar stock
      '' ''            For Each pro1 As Entidades.VentaProducto In Me._ventasProductos

      '' ''               'If pro1.IdProducto = producto Then
      '' ''               '   cantidadTotal = cantidadTotal + pro1.Cantidad
      '' ''               'End If
      '' ''               Dim produ3 As Entidades.Producto = New Reglas.Productos().GetUno(pro1.IdProducto, False)

      '' ''               If produ3.EsCompuesto Then
      '' ''                  If produ3.DescontarStockComponentes Then
      '' ''                     ocomponentes1 = New Reglas.ProductosComponentes()
      '' ''                     Dim _componentes2 As DataTable
      '' ''                     _componentes2 = ocomponentes1.GetComponentes(actual.Sucursal.IdSucursal, produ3.IdProducto, produ3.IdFormula, 0)
      '' ''                     For Each dr4 As DataRow In _componentes2.Rows
      '' ''                        If producto = dr4("IdProductoComponente").ToString() Then
      '' ''                           cantidadTotal = cantidadTotal + Decimal.Parse(dr4("Cantidad").ToString()) * pro1.Cantidad
      '' ''                        End If
      '' ''                     Next
      '' ''                  End If
      '' ''               Else
      '' ''                  producto = pro1.IdProducto
      '' ''                  'Sumo cantidades en productos repetidos para controlar stock
      '' ''                  'For Each pro2 As Entidades.VentaProducto In Me._ventasProductos
      '' ''                  If pro.IdProducto = producto Then
      '' ''                     cantidadTotal = cantidadTotal + pro1.Cantidad
      '' ''                  End If
      '' ''                  'Next
      '' ''               End If
      '' ''            Next

      '' ''            'Controlo la cantidad total con el stock del producto
      '' ''            If cantidadTotal > pro.Stock And blnControlarStock Then
      '' ''               'chequeo que ya no se haya controlado
      '' ''               For Each rep As DataRow In ProdRepetido.Rows
      '' ''                  If pro.IdProducto = rep("ProdRepetido").ToString() Then
      '' ''                     entro = True
      '' ''                  End If
      '' ''               Next
      '' ''               If entro = True Then
      '' ''               Else
      '' ''                  dr2 = ProdRepetido.NewRow()
      '' ''                  dr2("ProdRepetido") = pro.IdProducto
      '' ''                  dr2("NombreProducto") = pro.NombreProducto
      '' ''                  ProdRepetido.Rows.Add(dr2)
      '' ''               End If

      '' ''            End If
      '' ''            entro = False
      '' ''            cantidadTotal = 0

      '' ''            For Each dr As DataRow In ProdRepetido.Rows
      '' ''               ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      '' ''               entro2 = True
      '' ''            Next

      '' ''         End If
      '' ''      End If
      '' ''   Next


      '' ''   If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" And ProductosCadena <> "" Then
      '' ''      MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock. " + ProductosCadena, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''      Return False

      '' ''   ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" And ProductosCadena <> "" Then

      '' ''      MessageBox.Show("Va a Facturar el Producto " + ProductosCadena + " aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

      '' ''   End If
      '' ''End If
#End Region

      '--------------------------------------------------------------------------------------------------------------
      'PE-35846 >>>
      'If Decimal.Parse(Me.txtTotalGeneral.Text) = 0 Then
      '   MessageBox.Show("El comprobante no puede tener importe cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
      '      tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
      '      If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
      '         Me.bscProducto2.Focus()
      '      Else
      '         Me.bscCodigoProducto2.Focus()
      '      End If
      '   Else
      '      tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpRemitoTransp")
      '      Me.txtValorDeclarado.Focus()
      '   End If
      '   Return False
      'End If
      'PE-35846 <<<

      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      '-- Valida Vendedor.- --   
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
      '-- Valida Caja.- --
      If Me.cmbCajas.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar la caja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbCajas.Focus()
         Return False
      End If


      If Me.chbEsCtaOrden.Checked AndAlso
         Not Me.bscProveedor.Selecciono Then
         MessageBox.Show("Es Por Cta. Orden seleccionado pero no se cargó el proveedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscProveedor.Focus()
         Return False
      End If

      If Me.cmbFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar la forma de pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbFormaPago.Focus()
         Return False
      End If

      If Me.cmbListaDePrecios.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar la lista de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbListaDePrecios.Focus()
         Return False
      End If

      If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 And
         DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).RequiereReferenciaCtaCte And
         String.IsNullOrWhiteSpace(txtReferenciaCtaCte.Text) Then
         ShowMessage(String.Format("El comprobante {0} requiere que se ingrese una Referencia cuando es a Cta Cte.", DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Descripcion))
         Me.txtReferenciaCtaCte.Focus()
         Return False
      End If

      Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
      rVentas.ValidaMediosPagoSegunFormaPago(cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                             cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                             txtEfectivo.Text.ValorNumericoPorDefecto(0D),
                                             txtImporteDolares.ValorNumericoPorDefecto(0D),
                                             txtTickets.Text.ValorNumericoPorDefecto(0D),
                                             txtTransferenciaBancaria.Text.ValorNumericoPorDefecto(0D),
                                             _cheques,
                                             _tarjetas)

      'Si es Nota Credito o Dev. Proforma no puede aceptar cheques. Que lo arregle desde caja.
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores <= 0 And Me.dgvCheques.RowCount > 0 Then
         MessageBox.Show("Este comprobante no esta habilitado para ingresar cheque(s).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Length > 1 Then
         'Valida si el comprobante esta permitido para la letra fiscal
         Dim tip As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         If Not tip.LetraHabilitada(Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text) Then
            MessageBox.Show("Este comprobante no esta habilitado para esta Letra Fiscal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbTiposComprobantes.Focus()
            Return False
         End If
      End If

      If Not Me.chbNumeroAutomatico.Checked And Long.Parse(Me.txtNumeroPosible.Text) <= 0 Then
         MessageBox.Show("El número de comprobante digitado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtNumeroPosible.Focus()
         Return False
      End If

      'Validaciones especiales si es Remito Transportista
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then

         If txtBultos.ValorNumericoPorDefecto(0D) <= 0 Then
            MessageBox.Show("ATENCION: Debe ingresar el Total de Bultos del Remito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpRemitoTransp")
            Me.txtBultos.Focus()
            Return False
         End If

         If Not Me.bscTransportista.Selecciono Then
            MessageBox.Show("Debe ingresar el Transportista del Remito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpRemitoTransp")
            Me.bscTransportista.Focus()
            Return False
         End If

         If Long.Parse("0" & Me.txtNumeroLote.Text) <= 0 And Reglas.Publicos.Facturacion.FacturacionRemitoTranspUtilizaLote Then
            MessageBox.Show("Debe ingresar el Lote del Remito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpRemitoTransp")
            Me.txtNumeroLote.Focus()
            Return False
         End If

         'Dejan de ser obligatorias.
         'If Me._cantMaxItemsObserv > 0 And Me._ventasObservaciones.Count = 0 Then
         '   MessageBox.Show("ATENCION: debe ingresar al menos una Observacion de Detalle.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '   Me.tbcDetalle.SelectedTab = Me.tbpObservaciones
         '   Me.bscObservacionDetalle.Focus()
         '   Return False
         'End If

      End If

      '# Valido que de los productos ingresados, en caso de utilizar Lote, se hayan seleccionado.
      If Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then

         '# Si el comprobante principal es una NC e invocó una venta, no realizo la validación ya que los lotes deberían tomarse del comprobante facturable.
         If Not (_comprobantesSeleccionados.Count > 0 AndAlso _comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock < 0 AndAlso
            DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock > 0) Then
            If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 Then
               If Not _comprobantesSeleccionados.Count > 0 Then
                  For Each vp As Entidades.VentaProducto In _ventasProductos
                     If vp.Producto.Lote Then
                        If vp.VentasProductosLotes.Count = 0 Then
                           ShowMessage(String.Format("ATENCIÓN: No se ha seleccionado un Lote para el producto {0} de la linea {1}.", vp.Producto.NombreProducto, vp.Orden))
                           Return False
                        End If
                     End If
                  Next
               End If

            End If
         End If

      End If

      'Validaciones especiales si es Nota de Debito de Cheque Rechazado
      If Publicos.IdNotaDebitoChequeRechazado(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante) Then

         If Me._chequesRechazados.Count = 0 Then
            MessageBox.Show("ATENCION: debe ingresar al menos un Cheque Rechazado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpCheques")
            Me.btnInsertarChequeTercero.Focus()
            Return False
         End If

         Dim CheqRech As Decimal = 0
         For i As Integer = 0 To Me._chequesRechazados.Count - 1
            CheqRech += Me._chequesRechazados(i).Importe
         Next

         If CheqRech > Decimal.Parse(Me.txtTotalGeneral.Text) Then
            MessageBox.Show("ATENCION: El total de Cheque/s Rechazado/s supera al total del comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
            If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
               Me.bscProducto2.Focus()
            Else
               Me.bscCodigoProducto2.Focus()
            End If
            Return False
         End If

         If CheqRech = Decimal.Parse(Me.txtTotalGeneral.Text) Then
            If MessageBox.Show("ATENCION: El total de Cheque/s Rechazado/s es igual al total del comprobante, Continua? .", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.No Then
               Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
               If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
                  Me.bscProducto2.Focus()
               Else
                  Me.bscCodigoProducto2.Focus()
               End If
               Return False
            End If
         End If

      End If

      'Validacion por si invoco comprobantes -------------------------------

      If Me.ugObservaciones.Rows.Count > Me._cantMaxItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = Integer.Parse(IIf(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista, Me.dgvRemitoTransp.RowCount, Me.dgvProductos.RowCount).ToString())

      If LineasDetalle + Me.ugObservaciones.Rows.Count > Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & (LineasDetalle + Me.ugObservaciones.Rows.Count).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
            Me.btnEliminarRT.Focus()
         Else
            Me.btnEliminar.Focus()
         End If
         Return False
      End If

      '-------------------------------------------------------------------
      'If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
      '   If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 Then
      '      If Decimal.Parse(Me.txtSaldoCtaCte.Text) + Decimal.Parse(Me.txtTotalGeneral.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
      '         If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
      '            Return False
      '         End If
      '      End If
      '   End If
      'End If

      If Decimal.Parse(txtLimiteDeCredito.Text) > 0 AndAlso cmbFormaPago.SelectedIndex > -1 AndAlso
         DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 AndAlso cmbTiposComprobantes.SelectedIndex > -1 AndAlso
         DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ActualizaCtaCte AndAlso
         DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores > 0 Then

         Dim valido As Boolean? = ValidarLimiteCredito(arrojarException:=False)

         If valido.HasValue Then Return valido.Value

      End If

      Dim ImporteTope = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).ImporteTope
      ''PE-35846 - If ImporteTope > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) > ImporteTope Then
      If txtTotalGeneral.ValorNumericoPorDefecto(0D) > ImporteTope Then
         ShowMessage(String.Format("El Comprobante Superó el Límite Permitido de $ {0}", ImporteTope.ToString(_formatoEnTotales)))
         txtTotalGeneral.Focus()
         Return False
      End If

      Dim ImporteMinimo = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).ImporteMinimo
      ''PE-35846 - If ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) < ImporteMinimo Then
      If txtTotalGeneral.ValorNumericoPorDefecto(0D) < ImporteMinimo Then
         ShowMessage(String.Format("El Comprobante No Alcanzó el Mínimo Requerido de $ {0}", ImporteMinimo.ToString(_formatoEnTotales)))
         txtTotalGeneral.Focus()
         Return False
      End If

      'A Raymundo cada tanto le pasa que no genera el descuento, no dan enter!
      If (Decimal.Parse(Me.txtDescRecGralPorc.Text) <> 0 And Decimal.Parse(Me.txtDescRecGral.Text) = 0) AndAlso Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
         MessageBox.Show("No se calculó el Descuento/Recargo General, por favor de enter para confirmarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtDescRecGralPorc.Focus()
         Return False
      End If

      ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
      ''Habria que hacerlo mas general!
      'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal And String.IsNullOrEmpty(Me._clienteE.Cuit) Then
      '   MessageBox.Show("El Cliente NO tiene CUIT y es obligatorio para este comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   Me.cmbTiposComprobantes.Focus()
      '   Return False
      'End If



      Dim CategoriaFiscalCliente As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      Dim CUIT As String = String.Empty

      If Me._clienteE.EsClienteGenerico Then
         CategoriaFiscalCliente = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
         If CategoriaFiscalCliente.SolicitaCUIT Then
            Dim result As Reglas.Validaciones.ValidacionResult
            result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() With
                                                                                             {.IdFiscal = txtCUIT.Text,
                                                                                              .SolicitaCUIT = CategoriaFiscalCliente.SolicitaCUIT And
                                                                                                              Me.ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente})
            If result.Error Then
               txtCUIT.Focus()
               MessageBox.Show(result.MensajeError.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return False
            Else
               CUIT = txtCUIT.Text.ToString()
            End If
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
                  '-- REQ-38089.- --------------------------------------------
                  ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
                  If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
                     Return False
                  End If
                  '-----------------------------------------------------------
               Else
                  If txtNroDocCliente.ValorNumericoPorDefecto(0L) = 0 Then
                     ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
                     Me.txtNroDocCliente.Focus()
                     Return False
                  End If
               End If
            End If
         End If
      End If

      If cmbEmisor.SelectedItem Is Nothing Then
         ShowMessage("Debe seleccionar un emisor.")
         cmbEmisor.Focus()
         Return False
      End If

      '------- Permitir comprobante con fecha y numeración anterior ---------
      Dim oVN As Reglas.VentasNumeros = New Reglas.VentasNumeros()
      Dim oImpresora As Entidades.Impresora
      Dim shtCentroEmisor As Short

      'oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())
      oImpresora = DirectCast(cmbEmisor.SelectedItem, Entidades.Impresora)

      shtCentroEmisor = oImpresora.CentroEmisor

      Dim FechaComp As Date
      'Dim fechaAnt As Date
      'Dim fechaPos As Date

      'Dim ComprobanteAnterior As DataTable
      'Dim ComprobantePosterior As DataTable


      Dim fechaMinima As New Date(1900, 1, 1)


      If Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante Then

#Region "Notas-Marcas"
         'ComprobanteAnterior = oVN.GetCompAnterior(actual.Sucursal.IdSucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text, CentroEmisor, Long.Parse(Me.txtNumeroPosible.Text))
         'ComprobantePosterior = oVN.GetCompPosterior(actual.Sucursal.IdSucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text, CentroEmisor, Long.Parse(Me.txtNumeroPosible.Text))

         'If ComprobanteAnterior.Rows.Count = 0 Then

         '   If ComprobantePosterior.Rows.Count = 0 Then
         '      'no hay comprobante anterior y posterior QUE HACER???

         '   Else
         '      'no hay comprobante anterior y hay posterior

         '      For Each dr As DataRow In ComprobantePosterior.Rows

         '         If Me.dtpFecha.Value > Date.Parse(dr("Fecha").ToString()) Then
         '            fechaAnt = Date.Parse(dr("Fecha").ToString())
         '            MessageBox.Show("No puede Grabar el Comprobante con una Fecha mayor a: " & fechaAnt.ToString("dd/MM/yyyy") & " Comprobante Nro: " & dr("NumeroComprobante").ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '            Return False
         '         End If

         '      Next

         '   End If

         'Else

         '   If ComprobantePosterior.Rows.Count = 0 Then
         '      'hay comprobante anterior y no hay posterior QUE HACER???

         '   Else
         '      'hay comprobante anterior y posterior

         '      For Each dr As DataRow In ComprobanteAnterior.Rows

         '         For Each dr1 As DataRow In ComprobantePosterior.Rows

         '            fechaAnt = Date.Parse(dr("Fecha").ToString())
         '            fechaPos = Date.Parse(dr1("Fecha").ToString())

         '            If Me.dtpFecha.Value > fechaAnt And Me.dtpFecha.Value > fechaPos Then
         '               MessageBox.Show("No puede Grabar el Comprobante con una Fecha menor a: " & fechaAnt.ToString("dd/MM/yyyy") & " y mayor a: " & fechaPos.ToString("dd/MM/yyyy") & " Comprobante Nro: " & dr("NumeroComprobante").ToString() & "-" & dr1("NumeroComprobante").ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '               Return False
         '            End If

         '         Next

         '      Next

         '   End If

         'End If
#End Region

      Else
         'Numeracion Automatica
         FechaComp = oVN.GetUltimaFecha(actual.Sucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text, shtCentroEmisor)

         If Not Reglas.Publicos.Facturacion.PermitirComprobFechaNumAnterior And Me.dtpFecha.Value.Date < FechaComp Then
            MessageBox.Show("No puede Grabar el Comprobante con una Fecha menor a " & FechaComp.ToString("dd/MM/yyyyy"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If

      End If

      If Not Me.chbNumeroAutomatico.Checked And Long.Parse(Me.txtNumeroPosible.Text) > 0 And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal Then

         If New Reglas.Ventas().Existe(actual.Sucursal.IdSucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(),
                                       Me.txtLetra.Text, shtCentroEmisor, Long.Parse(Me.txtNumeroPosible.Text)) Then
            MessageBox.Show("El Numero de Comprobante " & Me.txtNumeroPosible.Text & " Ya Existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
         End If

         If New Reglas.Ventas().ExisteCtaCte(actual.Sucursal.IdSucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(),
                              Me.txtLetra.Text, shtCentroEmisor, Long.Parse(Me.txtNumeroPosible.Text)) Then
            MessageBox.Show("El Numero de Comprobante " & Me.txtNumeroPosible.Text & " Ya Existe en Cuenta Corriente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
         End If

      End If


      If Decimal.Parse(Me.txtDiferencia.Text) < 0 Then
         MessageBox.Show("No puede asignar mas Pagos que el Total del Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
         Me.txtEfectivo.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal Then
         'Verifico que ningun producto tenga Cantidad Negativa (Hay que hacer un control segun la Fiscal !!).
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            If pro.Cantidad < 0 Then
               MessageBox.Show("Un Comprobante FISCAL No puede tener Productos con Cantidad en Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
               If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
                  Me.bscProducto2.Focus()
               Else
                  Me.bscCodigoProducto2.Focus()
               End If
               Return False
            End If
         Next
      End If

      'Verifico Descuento Máximo solo de los productos que NO permiten modificar descripcion
      Dim PorcDescTotal As Decimal = 0
      Dim PrecioLista As Decimal = 0

      For Each pro As Entidades.VentaProducto In Me._ventasProductos

         'Los Cambios y las Bonificaciones no tienen importe, por lo que no se debe controlar que el Imp.Int.
         If pro.TipoOperacion = Entidades.Producto.TiposOperaciones.NORMAL Then
            'GAR: 27/02/2018. Agrego este control porque hubo casos en cero (hasta encontrar el origen).
            'Si es remito de transportista no graba nada de impuestos internos.
            If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
               If (pro.Producto.ImporteImpuestoInterno > 0 Or pro.Producto.PorcImpuestoInterno > 0) And pro.ImporteImpuestoInterno = 0 Then
                  MessageBox.Show("El Producto " & pro.NombreProducto & " se cargo con Impuesto Interno en cero pero NO es correcto. Por favor quitelo y vuelva a cargarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Return False
               End If
            End If            'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
         End If               'If GetTipoOperacionSeleccionada() = Entidades.Producto.TiposOperaciones.NORMAL Then

         '----------------------------

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

         ' Si el comprobante seleccionado no mueve stock Y NO ES PreElectrónico, evito la verificacion del Nro De Serie.
         Dim coeStock = tpCompo.CoeficienteStock
         If coeStock = 0 AndAlso tpCompo.EsElectronico AndAlso Not String.IsNullOrWhiteSpace(tpCompo.IdTipoComprobanteSecundario) Then
            'Dim tipoSecundario As Entidades.TipoComprobante
            Dim tipoSecundario = New Reglas.TiposComprobantes().GetUno(tpCompo.IdTipoComprobanteSecundario)
            coeStock = tipoSecundario.CoeficienteStock
         End If

         If coeStock <> 0 Then ' OrElse esPre Then
            If pro.Producto.NroSerie Then
               If pro.Producto.NrosSeries.Count < pro.Cantidad Then
                  ShowMessage(String.Format("ATENCION: Producto {0} - {1} falta seleccionar numeros de serie", pro.Producto.IdProducto, pro.Producto.NombreProducto))
                  Return False
               End If
            End If
         End If

      Next
      '-----------------------------------------------------------------------------------------------


      'Validación IVA de Productos
      Dim prod As Entidades.Producto
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            'prod = New Entidades.Producto()
            prod = New Reglas.Productos().GetUno(pro.IdProducto)
            If pro.AlicuotaImpuesto <> prod.Alicuota AndAlso prod.Alicuota2.HasValue AndAlso pro.AlicuotaImpuesto <> prod.Alicuota2.Value Then
               If prod.Alicuota2.HasValue AndAlso prod.Alicuota2.Value <> 0 Then
                  MessageBox.Show("ATENCION: El IVA del Producto '" & pro.Producto.IdProducto & " - " & pro.Producto.NombreProducto & "', NO Corresponde: Debe Ser " & prod.Alicuota.ToString() + " % ó " + prod.Alicuota2.Value.ToString() + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Else
                  MessageBox.Show("ATENCION: El IVA del Producto '" & pro.Producto.IdProducto & " - " & pro.Producto.NombreProducto & "', NO Corresponde: Debe Ser " & prod.Alicuota.ToString() + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               End If
               Return False
            End If
         Next
      End If
      '-------------------------------
#Region "Notas-Marcas"
      ' '' ''Controlo los componentes de aquellos productos que descuentan stock al facturar.
      '' ''If blnControlarStock Then
      '' ''   Dim oComponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
      '' ''   Dim oProductos As Reglas.Productos
      '' ''   Dim oProducto As Entidades.Producto
      '' ''   Dim idListaDePrecios As Integer = 0
      '' ''   Dim dtComponentes As DataTable

      '' ''   For Each pro As Entidades.VentaProducto In Me._ventasProductos
      '' ''      oProductos = New Reglas.Productos()
      '' ''      oProducto = New Entidades.Producto()

      '' ''      'Busco el producto Nuevamente aunque este en la Coleccion porque pudo ajustar alguna caracterisca luego de algun hipotetico mensaje anterior.
      '' ''      oProducto = oProductos.GetUno(pro.IdProducto)

      '' ''      If oProducto.EsCompuesto And oProducto.DescontarStockComponentes Then
      '' ''         dtComponentes = oComponentes.GetComponentes(actual.Sucursal.IdSucursal, oProducto.IdProducto, oProducto.IdFormula, idListaDePrecios)
      '' ''         If dtComponentes.Rows.Count = 0 Then
      '' ''            MessageBox.Show("ATENCION: El Producto '" & pro.IdProducto & " - " & pro.NombreProducto & "', tiene Predeterminada una Fórmula sin Componentes. NO puede Grabar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '' ''            Return False
      '' ''         End If
      '' ''      End If
      '' ''   Next
      '' ''End If

      'por las dudas, cuando revisemos la funcionalidad levantamos el control.
      'If Publicos.RetieneIIBB Then
      '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsElectronico Then
      '      MessageBox.Show("ATENCION: No puede generar un comprobante Electronico si es Agente de Retencion de IIBB!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '      Return False
      '   End If
      '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal Then
      '      MessageBox.Show("ATENCION: No puede generar un comprobante Fiscal si es Agente de Retencion de IIBB!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '      Return False
      '   End If
      'End If
#End Region

      If New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "Facturacion-OBLIGA-Invocar") AndAlso (_comprobantesSeleccionados Is Nothing OrElse _comprobantesSeleccionados.Count = 0) Then
         ShowMessage("Debe invocar un comprobante. Por favor reintente.")
         Return False
      End If

      If GetTipoComprobanteSeleccionado().AFIPWSRequiereComprobanteAsociado And
         (_comprobantesSeleccionados Is Nothing OrElse _comprobantesSeleccionados.Where(Function(x) x.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString()).Count = 0) Then
         ShowMessage(String.Format("Para el comprobante {1} es obligatorio informar Comprobante Asociado{0}{0}Debe invocar un comprobante de venta",
                                   Environment.NewLine, GetTipoComprobanteSeleccionado().Descripcion))
         Return False
      End If

      If GetTipoComprobanteSeleccionado().AFIPWSCodigoAnulacion And cmbAFIPWSCodigoAnulacion.SelectedIndex < 0 Then
         ShowMessage(String.Format("Para el comprobante {1} debe indicar si el comprobante anula un comprobante ya rechazado",
                                   Environment.NewLine, GetTipoComprobanteSeleccionado().Descripcion))
         Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpAdicionales")
         cmbAFIPWSCodigoAnulacion.Focus()
         Return False
      End If

      If GetTipoComprobanteSeleccionado().AFIPWSRequiereReferenciaTransferencia And cmbAFIPWSReferenciaTransferencia.SelectedIndex < 0 Then
         ShowMessage(String.Format("Para el comprobante {1} debe indicar la Referencia de Transferencia",
                                   Environment.NewLine, GetTipoComprobanteSeleccionado().Descripcion))
         Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpAdicionales")
         cmbAFIPWSReferenciaTransferencia.Focus()
         Return False
      End If

      If Reglas.Publicos.FactElectEsSincronica And DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsElectronico And Decimal.Parse(txtCheques.Text) > 0 Then
         MessageBox.Show("ATENCION: Para un Comprobante Electronico (En Linea) NO puede cargar Cheques, debe enviar a CtaCte y hacer un Recibo. NO puede Grabar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return False
      End If

      If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro AndAlso _tarjetas.Count > 0 Then
         If MessageBox.Show("ATENCION: Esta seguro de asignar Tarjetas como forma de pago a: " & Me.cmbTiposComprobantes.Text.ToString(), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then
            Return False
         End If
      End If

      '# Si el comprobante solicita Fecha de Devolución me aseguro que todos los productos tengan seteada la misma
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).SolicitaFechaDevolucion Then
         Dim msg As StringBuilder = New StringBuilder
         Dim count As Integer = 0
         For Each vp As Entidades.VentaProducto In _ventasProductos
            If Not vp.FechaDevolucion.HasValue Then
               With msg
                  count += 1
                  .AppendFormatLine("El producto {0} requiere Fecha de Devolución. Por favor edite el producto y seleccione una.", vp.NombreProducto)
                  If count <> _ventasProductos.Count Then
                     .AppendLine()
                  End If
               End With
            End If
         Next

         If Not String.IsNullOrEmpty(msg.ToString()) Then
            ShowMessage(msg.ToString())
            Return False
         End If
      End If

      If _comprobantesSeleccionados IsNot Nothing AndAlso
         _comprobantesSeleccionados.Count > 0 AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 AndAlso
         (txtEfectivo.ValorNumericoPorDefecto(0D) <> _comprobantesSeleccionados(0).ImportePesos Or
          txtImporteDolares.ValorNumericoPorDefecto(0D) <> _comprobantesSeleccionados(0).ImporteDolares Or
          txtTarjetas.ValorNumericoPorDefecto(0D) <> _comprobantesSeleccionados(0).ImporteTarjetas Or
          txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) <> _comprobantesSeleccionados(0).ImporteTransfBancaria Or
          txtTickets.ValorNumericoPorDefecto(0D) <> _comprobantesSeleccionados(0).ImporteTickets) Then
         If ShowPregunta("ATENCION: La forma de pago no coincide con la del comprobante invocado. Desea continuar?") = Windows.Forms.DialogResult.Cancel Then
            Return False
         End If
      End If

      If chbAFIPConceptoCM05.Checked And cmbAFIPConceptoCM05.SelectedIndex = -1 Then
         tbcDetalle.Tabs("tbpAdicionales").Selected = True
         cmbAFIPConceptoCM05.Select()
         ShowMessage("ATENCION: Activo el Concepto de CM05 pero no seleccionó uno. Debe elegir una.")
         Return False
      End If

      Return True

   End Function

   Private Function EsComprobanteFiscal() As Boolean
      Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
   End Function

   Private Sub LogV(mensaje As String)
      My.Application.Log.WriteEntry(String.Concat(mensaje, String.Format(" {0:dd/MM/yyyy HH:mm:ss.fff}", Now)), TraceEventType.Verbose)
   End Sub

   Private Sub GrabarComprobante()
      LogV("********** FacturacionV2.GrabarComprobante ********** ")
      LogV(" 0.- Inicia GrabarComprobante ")

      'Le quito el Foco al campo que lo tenga, porque podria ser uno de valor (pesos, transferencia) y que no haya dado enter.
      If Not Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
         If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
            Me.bscProducto2.Focus()
         Else
            Me.bscCodigoProducto2.Focus()
         End If
      Else
         Me.bscCodigoProducto2RT.Focus()
      End If

      ValidarInsertarTarjetasConIntereses()

      If Reglas.Publicos.Facturacion.Impresion.FacturacionDetallaChequesyTarjetas Then
         Me.CargarObservacionesChequesTarjetas()
      End If

      Me.CalcularPagos(False)

      LogV(" 1.- ValidarComprobantes ")

      If Me.ValidarComprobante() Then

         LogV(" 1.1.- ValidarComprobantes FINALIZADO ")

         Me.tsbGrabar.Enabled = False

         If Me.tbcDetalle.Tabs("tbpPagos").Visible Then
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
         End If

         Dim oFacturacion = New Reglas.Ventas()
         Dim oVentas = New Entidades.Venta()

         LogV(" 2.- Prepara Venta para grabar ")

         With oVentas
            '-- REQ-33532.- -- Carga Datos de Transportista-Empleado-Vehiculo.- ---
            With oVentas
               .IdTransportistaTransporte = Nothing
               .IdChoferTransporte = Nothing
               .VehiculoTransporte.PatenteVehiculo = String.Empty
            End With
            If chbTransportista.Checked Then
               oVentas.IdTransportistaTransporte = Integer.Parse(bscCodigoTransportista.Text)
               If Not String.IsNullOrEmpty(bscCodigoChofer.Text) Then
                  With oVentas
                     .IdChoferTransporte = Integer.Parse(bscCodigoChofer.Text)
                     .VehiculoTransporte.PatenteVehiculo = bscCodigoVehiculo.Text
                  End With
               End If
            End If
            '----------------------------------------------------------------------
            'cargo el comprobante
            .TipoComprobante = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)

            'cargo el cliente ----------
            .Cliente = Me._clienteE

            If Not Me._clienteE.EsClienteGenerico Then
               .NombreCliente = Me.bscCliente.Text
            Else
               .NombreCliente = Me.txtNombreClienteGenerico.Text
            End If

            '-- REQ-31198.- ------------------
            .EsFacturaExportacion = tbcDetalle.Tabs("tbpExportacion").Visible

            If cmbClausulaVentas.SelectedIndex <> -1 Then
               .IdIcotermExportacion = cmbClausulaVentas.SelectedValue.ToString()
            Else
               .IdIcotermExportacion = Nothing
            End If
            If cmbDestinoComprobante.SelectedIndex <> -1 Then
               .IdDestinoExportacion = cmbDestinoComprobante.SelectedValue.ToString()
            Else
               .IdDestinoExportacion = Nothing
            End If
            '---------------------------------
            .FechaPagoExportacion = dtpFechaPagoExportacion.Valor(dtpFechaPagoExportacion.Enabled)


            If (bscCodigoClienteVinculado.Selecciono Or bscClienteVinculado.Selecciono) AndAlso IsNumeric(bscCodigoClienteVinculado.Tag) Then
               .ClienteVinculado = New Reglas.Clientes().GetUno(Long.Parse(bscCodigoClienteVinculado.Tag.ToString()))
            End If

            Dim idDireccionSeleccionada = cmbDirecciones.ValorSeleccionado(Of Integer)
            Using dtDirecciones = New Reglas.ClientesDirecciones().GetDirecciones(.Cliente.IdCliente)
               Dim drDireccion = dtDirecciones.AsEnumerable().FirstOrDefault(Function(dr) dr.Field(Of Integer)("IdDireccion") = idDireccionSeleccionada)
               If drDireccion Is Nothing Then
                  Throw New Exception("La direccion seleccionada ya no pertenece al cliente")
               End If
               .IdDomicilio = idDireccionSeleccionada.NullIf(0)
               .Direccion = drDireccion.Field(Of String)("Direccion")
               .IdLocalidad = drDireccion.Field(Of Integer?)("IdLocalidad").IfNull()
            End Using
            ''cargo la direccion elegida
            'If idDireccionSeleccionada = 0 Then
            '   .Direccion = .Cliente.Direccion
            '   .IdLocalidad = .Cliente.IdLocalidad
            'ElseIf idDireccionSeleccionada = -1 Then
            '   .Direccion = .Cliente.Direccion2.IfNull()
            '   .IdLocalidad = .Cliente.IdLocalidad2
            'Else
            '   Using dtDirecciones = New Reglas.ClientesDirecciones().GetDireccionCliente(.Cliente.IdCliente, idDireccionSeleccionada)
            '      Dim drDireccion = dtDirecciones.AsEnumerable().FirstOrDefault()
            '      If drDireccion Is Nothing Then
            '         Throw New Exception("La direccion seleccionada ya no pertenece al cliente")
            '      End If
            '      .Direccion = drDireccion.Field(Of String)("Direccion")
            '      .IdLocalidad = drDireccion.Field(Of Integer?)("IdLocalidad").IfNull()
            '   End Using
            'End If

            If _clienteE.EsClienteGenerico Then
               .Direccion = Me.txtDireccionClienteGenerico.Text
               .IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text.ToString())
            End If

            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)

            .LetraComprobante = Me.txtLetra.Text

            If Not Me.chbNumeroAutomatico.Checked Or (.TipoComprobante.EsFiscal And Not .TipoComprobante.GrabaLibro) Then
               .NumeroComprobante = Long.Parse(Me.txtNumeroPosible.Text)
            End If

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
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

            If Me.cmbFormaPago.SelectedIndex <> -1 Then
               .FormaPago = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago)
            End If

            .Observacion = Me.bscObservacion.Text
            If .TipoComprobante.AFIPWSRequiereReferenciaComercial Then
               .ReferenciaComercial = txtReferenciaComercial.Text
            End If

            If .TipoComprobante.AFIPWSCodigoAnulacion Then
               .AnulacionFCE = DirectCast(cmbAFIPWSCodigoAnulacion.SelectedValue, Entidades.Publicos.SiNo) = Entidades.Publicos.SiNo.SI
            End If

            If .TipoComprobante.AFIPWSRequiereReferenciaTransferencia Then
               .IdAFIPReferenciaTransferencia = cmbAFIPWSReferenciaTransferencia.ValorSeleccionado(Of String)
            End If

            '-- REQ-33524.- -----------------------------------------
            .IdEmbarcacion = _idEmbarcacion
            .CodigoEmbarcacion = _codigoEmbarcacion
            .NombreEmbarcacion = _nombreEmbarcacion
            .IdCategoriaEmbarcacion = _idCategoriaEmbarcacion
            .NombreCategoriaEmbarcacion = _nombreCategoriaEmbarcacion
            .AgregarObservacionEmbarcacion = True
            '-- REQ-36331.- -----------------------------------------
            .IdCama = _idCama
            .CodigoCama = _codigoCama
            .IdNave = _idNave
            .NombreNave = _nombreNave
            .IdCategoriaCama = _idCategoriaCama
            .NombreCategoriaCama = _nombreCategoriaCama
            '--------------------------------------------------------

            .VentasImpuestos = _subTotales
            .ImpuestosVarios = _fc.ImpuestosVarios
            '.Percepciones.BaseImponible = Me._baseImponibleIIBB

            'cargo valores del comprobante
            .ImporteBruto = Decimal.Parse(Me.txtTotalBruto.Text)
            .DescuentoRecargo = Decimal.Parse(Me.txtDescRecGral.Text)
            .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescRecGralPorc.Text)
            .DescuentoRecargoPorcManual = Me.chbModificaDescRecGralPorc.Checked '# Registro si el descuento fué aplicado de forma automática o no.
            .Subtotal = Decimal.Parse(Me.txtTotalNeto.Text)
            .TotalImpuestos = Decimal.Parse(Me.txtTotalImpuestos.Text) + Decimal.Parse(Me.txtTotalRetenciones.Text)
            .ImporteTotal = Decimal.Parse(Me.txtTotalGeneral.Text)

            .Kilos = Decimal.Parse(Me.txtKilos.Text)

            .ConceptoCM05 = If(chbAFIPConceptoCM05.Checked, cmbAFIPConceptoCM05.ItemSeleccionado(Of Entidades.AFIPConceptoCM05)(), Nothing)

            'cargo la impresora
            '.Impresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal())
            '.Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)
            .Impresora = DirectCast(cmbEmisor.SelectedItem, Entidades.Impresora)

            'cargo los productos
            .VentasProductos = _ventasProductos

            '-- REQ-33373.- --------------------------------------------------------------
            'If Reglas.Publicos.CtaCteEmbarcacion And New Reglas.Generales().ExisteTabla("Embarcaciones") Then
            '   If .VentasProductos.Where(Function(c) c.NombreProducto = .NombreEmbarcacion).Count = 0 Then
            '      Dim colProd As List(Of Eniac.Entidades.Producto) = New Eniac.Reglas.Productos().GetTodosObservacion()
            '      Dim productoObservacion As Eniac.Entidades.Producto = Nothing
            '      If colProd.Count > 0 Then
            '         productoObservacion = colProd(0)
            '      End If

            '      oLineaVP = New Eniac.Entidades.VentaProducto()

            '      oLineaVP.Orden = .VentasProductos.Count + 1
            '      oLineaVP.Producto = productoObservacion.GetCopia()

            '      oLineaVP.Producto.NombreProducto = .NombreEmbarcacion
            '      oLineaVP.NombreListaPrecios = Me.cmbListaDePrecios.Text
            '      oLineaVP.TipoImpuesto.IdTipoImpuesto = _tipoImpuestoIVA

            '      oLineaVP.Cantidad = 1
            '      oLineaVP.PrecioLista = 0
            '      .VentasProductos.Add(oLineaVP)

            '      oLineaVP = New Eniac.Entidades.VentaProducto()
            '      oLineaVP.Orden = .VentasProductos.Count + 1
            '      oLineaVP.Producto = productoObservacion.GetCopia()

            '      oLineaVP.Producto.NombreProducto = String.Format("Categoria {0}", .NombreCategoriaEmbarcacion)
            '      oLineaVP.NombreListaPrecios = Me.cmbListaDePrecios.Text
            '      oLineaVP.TipoImpuesto.IdTipoImpuesto = _tipoImpuestoIVA

            '      oLineaVP.Cantidad = 1
            '      oLineaVP.PrecioLista = 0
            '      '-- Carga Categoria.-
            '      .VentasProductos.Add(oLineaVP)
            '   End If
            'End If
            '-----------------------------------------------------------------------------


            Dim rPPF As Reglas.VentasProductosFormulas = New Reglas.VentasProductosFormulas()
            For Each pp As Entidades.VentaProducto In _ventasProductos
               If _ventasProductosFormulas.ContainsKey(pp) AndAlso _ventasProductosFormulas(pp) IsNot Nothing Then
                  pp.VentasProductosFormulas = rPPF.CargaLista(_ventasProductosFormulas(pp))
               End If
            Next

            'Cargo los Comprobantes Facturados (tal vez ninguno)
            '.Facturables = Me._comprobantesSeleccionados
            .Invocados.Add(Me._comprobantesSeleccionados)

            .SeleccionoInvocados = _SeleccionoInvocados

            'Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !

            If Me._comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 AndAlso (.TipoComprobante.CoeficienteStock <> 0 Or .TipoComprobante.EsPreElectronico) AndAlso Not Me._InvocaPedido AndAlso Not Me._SoloCopia Then
               .IdEstadoComprobante = "INVOCO"
               '.CantidadInvocados = Me._comprobantesSeleccionados.Count
            Else
               '.CantidadInvocados = 0
            End If

            'cargo el Remito Transportista
            .Bultos = Convert.ToInt32(txtBultos.ValorNumericoPorDefecto(0D))
            .ValorDeclarado = Me.txtValorDeclarado.ValorNumericoPorDefecto(0D)
            .Transportista = Me._transportistaA
            .NumeroLote = Me.txtNumeroLote.ValorNumericoPorDefecto(0L)

            'cargo las Observaciones
            If Reglas.Publicos.Facturacion.Impresion.FacturacionDetallaChequesyTarjetas Then
               .VentasObservaciones = Me._ventasObservacionesCHTarjeta
            Else
               .VentasObservaciones = Me._ventasObservaciones
            End If


            If oVentas.TipoComprobante.AfectaCaja Then
               'controlo el pago que se realiza si no va a la cuenta corriente
               If oVentas.FormaPago.Dias = 0 Then
                  If Decimal.Parse(txtTotalPago.Text) = 0 Then
                     If Decimal.Parse(txtDiferencia.Text) <> 0 Then
                        If Reglas.Publicos.Facturacion.FacturacionContadoEsEnPesos Then
                           Dim fPago = cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)
                           Dim medio = "pesos"
                           Dim ctaBancaria = New Reglas.CuentasBancarias().GetUna(fPago.IdCuentaBancariaEfectivo.IfNull(-1), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
                           If fPago.IdCuentaBancariaEfectivo.HasValue Then
                              medio = String.Format("transferencia a la cuenta {0}", ctaBancaria.NombreCuenta)
                           End If
                           If ShowPregunta(String.Format("¿El pago se realizara totalmente como {0}?", medio)) = Windows.Forms.DialogResult.No Then
                              tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
                              txtEfectivo.Select()
                              Exit Sub
                           Else
                              If fPago.IdCuentaBancariaEfectivo.HasValue Then
                                 txtTransferenciaBancaria.Text = txtTotalGeneral.Text
                                 bscCodigoCuentaBancariaTransfBanc.Text = fPago.IdCuentaBancariaEfectivo.Value.ToString()
                                 bscCodigoCuentaBancariaTransfBanc.Visible = True
                                 bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
                                 bscCodigoCuentaBancariaTransfBanc.Visible = False
                              Else
                                 txtEfectivo.Text = txtTotalGeneral.Text
                              End If
                           End If
                        Else
                           tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
                           txtEfectivo.Select()
                           Exit Sub
                        End If
                     End If
                  Else
                     'si puso algo en pagos, se debe controlar que la diferencia este en cero
                     If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                        tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
                        Me.txtEfectivo.Focus()
                        Throw New Exception("El pago debe ser igual al total del comprobante.")
                     End If
                  End If
               End If
            Else

               If oVentas.FormaPago.Dias = 0 Then
                  'Asigno la diferencia porque puedo poner cheques o tarjetas.
                  'las PRE-Facturas NO afectan Caja pero cargar los pagos cuando es Contado.
                  'si puso algo en pagos, se debe controlar que la diferencia este en cero
                  If Decimal.Parse(Me.txtDiferencia.Text) <> Decimal.Parse(Me.txtTotalGeneral.Text) And Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                     tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
                     Me.txtEfectivo.Focus()
                     Throw New Exception("El pago debe ser igual al total del comprobante.")
                  End If

                  If Decimal.Parse(Me.txtEfectivo.Text) = 0 And Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                     '   Me.txtEfectivo.Text = Me.txtEfectivo.Text
                     'Else
                     Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
                  End If
               End If

            End If

            .AplicarSaldoCtaCte = .FormaPago.Dias > 0 AndAlso chbAplicarSaldoCtaCte.Checked

            'carga los importes de pagos y cheques
            .Cheques = _cheques
            .Tarjetas = _tarjetas
            .ImportePesos = Decimal.Parse(txtEfectivo.Text)
            .ImporteDolares = txtImporteDolares.ValorNumericoPorDefecto(0D)

            '.ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text)
            .ImporteTickets = Decimal.Parse(Me.txtTickets.Text)

            If txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) > 0 And bscCuentaBancariaTransfBanc.Selecciono Then
               .ImporteTransfBancaria = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)
               .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(bscCuentaBancariaTransfBanc.Tag.ToString())) ''._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
               .FechaTransferencia = Me.dtpFechaTransferencia.Value
            End If
            If _transferencias.AnySecure() Then
               .FechaTransferencia = dtpFechaTransferencia.Value
            End If

            .Transferencias = _transferencias

            'carga los cheques rechazados
            .ChequesRechazados = Me._chequesRechazados

            'Informe los Productos que tuvieron Lotes.
            .CantidadLotes = 0   'Me.ProductosConLote()    ---- Luego le cargo el correcto segun la seleccion de lotes.

            '# Se quita esto porque se cambió la lógica. Los lotes no dependen directamente de la venta sino de los Productos de la venta que utilicen Lote (Venta > Producto > Lote)
            '.VentasProductosLotes = Me._productosLotes

            'Cargo la utilidad
            .Utilidad = Decimal.Parse(txtSemaforoRentabilidad.Key)

            .CotizacionDolar = txtCotizacionDolar.ValorNumericoPorDefecto(0D)
            .IdMoneda = Integer.Parse(cmbMonedaVenta.SelectedValue.ToString())

            .ComisionVendedor = 0  'Se calcula despues

            .MercDespachada = Me.chbMercDespachada.Checked

            'grabo la caja
            .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

            .TurnosInvocados = _turnosInvocados

            .CrmInvocados = _crmInvocados

            '# Se realiza esta lógica en caso que .CrmInvocados sea Nothing, para no pisar lógica de otra funcionalidad
            '# Si estoy invocando un comprobante para hacer una NC y ese comprobante tiene Services facturados, los agrego para luego liberarlos
            If _crmInvocados Is Nothing AndAlso
                    .TipoComprobante.CoeficienteValores < 0 AndAlso
                    _comprobantesSeleccionados IsNot Nothing AndAlso
                    _comprobantesSeleccionados.Count > 0 Then

               '# En caso que haya más de un comprobante invocado, se va a tomar el primer invocado solamente.
               .CrmInvocados = _comprobantesSeleccionados(0).CrmInvocados

            End If

            'si invoco pedidos me traigo la Orden de compra, solo si invoco un pedido
            If Me._InvocaPedido Then
               If Me._comprobantesSeleccionados.Count = 1 Then
                  .NumeroOrdenCompra = Me._comprobantesSeleccionados(0).NumeroOrdenCompra
               End If
            End If

            If Me.cmbActividades.SelectedIndex <> -1 Then
               .IdActividad = Integer.Parse(Me.cmbActividades.SelectedValue.ToString())
               .IdProvincia = DirectCast(Me.cmbActividades.SelectedItem, DataRowView)("IdProvincia").ToString()
            End If

            If Me.bscCodigoProveedor.Selecciono() Or Me.bscProveedor.Selecciono() Then
               .Proveedor = New Reglas.Proveedores()._GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))
            End If

            .EsCtaOrden = Me.chbEsCtaOrden.Checked

            .IdCategoria = .Cliente.IdCategoria

            If .TipoComprobante.AfectaCaja And .FormaPago.Dias = 0 Then
               Dim oCaja As Reglas.CajasNombres = New Reglas.CajasNombres()
               Dim caja As Entidades.CajaNombre = New Entidades.CajaNombre()
               Dim oCajas As Reglas.Cajas = New Reglas.Cajas()
               Dim saldoCaja As Decimal

               Dim oPlanilla As Entidades.Caja = oCajas.GetPlanillaActual(.IdSucursal, .IdCaja)
               saldoCaja = oCajas.GetSaldoPesosFinal(.IdSucursal, .IdCaja, oPlanilla.NumeroPlanilla) + oCajas.GetSaldoChequesFinal(.IdSucursal, .IdCaja, oPlanilla.NumeroPlanilla)
               Dim totalCaja = saldoCaja + txtEfectivo.ValorNumericoPorDefecto(0D) + txtCheques.ValorNumericoPorDefecto(0D) +
                               (txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D))
               caja = oCaja.GetUna(.IdSucursal, .IdCaja)

               If caja.TopeAviso > 0 And totalCaja >= caja.TopeAviso And totalCaja < caja.TopeBloqueo Then
                  MessageBox.Show("Superó el Limite Recomendado de " & caja.TopeAviso.ToString("N2") & ", y está por llegar al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               ElseIf caja.TopeBloqueo > 0 And totalCaja >= caja.TopeBloqueo Then
                  ShowMessage("Llegó al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2") & ". No podrá registrar el próximo comprobante.")
               End If
            End If

            .VentasContactos.Clear()
            For Each contacto As Entidades.ClienteContacto In _ventasContactos
               .VentasContactos.Add(New Entidades.VentaClienteContacto(contacto))
            Next

            .ExportacionEmbarques.Clear()
            For Each despacho As Entidades.VentaDespacho In _ventasDespachos
               Dim eEmbarques = New Entidades.VentaExportacionEmbarques
               eEmbarques.IdPermisoEmbarque = despacho.IdPermisoEmbarque.ToUpper()
               eEmbarques.IdDestinoDespacho = despacho.IdDestinoDespacho
               .ExportacionEmbarques.Add(eEmbarques)
            Next

            '-- REQ-31371.- ------------------------------------------------------
            .Cuit = txtCUIT.Text
            .TipoDocCliente = cmbTipoDoc.Text
            If String.IsNullOrEmpty(txtNroDocCliente.Text.ToString()) Then
               .NroDocCliente = 0
            Else
               .NroDocCliente = Long.Parse(txtNroDocCliente.Text.ToString())
            End If
            '---------------------------------------------------------------------
            '# Historia Clínica
            If Me.bscCodigoPaciente.Selecciono AndAlso Me.bscPaciente.Selecciono Then .IdPaciente = Long.Parse(Me.bscCodigoPaciente.Tag.ToString())
            If Me.bscCodigoDoctor.Selecciono AndAlso Me.bscDoctor.Selecciono Then .IdDoctor = Long.Parse(Me.bscCodigoDoctor.Tag.ToString())
            If Me.chbFechaCirugia.Checked Then .FechaCirugia = Me.dtpFechaCirugia.Value
         End With

         oVentas.ReemplazaComprobante = False

         LogV(" 2.1.- Prepara Venta para grabar FINALIZADO ")

         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If oVentas.TipoComprobante.ActualizaCtaCte Then
            If oVentas.FormaPago.Dias > 0 Then
               'si el cliente compro el modulo de cuenta corriente
               If Reglas.Publicos.TieneModuloCuentaCorrienteClientes Then
                  oVentas.CuentaCorriente.Referencia = txtReferenciaCtaCte.Text
                  If Not Reglas.Publicos.CtaCte.UtilizaCuotasVencimientoCtaCteClientes Then

                     If MessageBox.Show("Confirma enviar el Comprobante a Cuenta Corriente?", Me.Text, MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then
                        'Me.tsbGrabar.Enabled = True
                        Exit Sub
                     End If

                     Dim oCCP As Entidades.CuentaCorrientePago
                     oCCP = New Entidades.CuentaCorrientePago()
                     oCCP.ImporteCuota = oVentas.ImporteTotal
                     oCCP.SaldoCuota = oCCP.ImporteCuota
                     oCCP.FechaVencimiento = Me.dtpFecha.Value.AddDays(oVentas.FormaPago.Dias)
                     oVentas.CuentaCorriente.Pagos.Add(oCCP)

                  Else

                     Dim cc As CuentaCorriente = New CuentaCorriente(Me.dtpFecha.Value, oVentas.ImporteTotal, oVentas.FormaPago.IdFormasPago)

                     If cc.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        'recuperar los datos para armar la cuenta corriente
                        Dim oCCP As Entidades.CuentaCorrientePago
                        For Each dr As DataRow In cc.Pagos.Rows
                           oCCP = New Entidades.CuentaCorrientePago()
                           oCCP.ImporteCuota = Decimal.Parse(dr("MontoAPagar").ToString())
                           oCCP.SaldoCuota = oCCP.ImporteCuota
                           oCCP.FechaVencimiento = Date.Parse(dr("FechaAPagar").ToString())
                           oVentas.CuentaCorriente.Pagos.Add(oCCP)
                        Next

                        oVentas.FormaPago = New Reglas.VentasFormasPago().GetUna(cc.IdFormaDePago)

                     Else
                        'Me.tsbGrabar.Enabled = True
                        Throw New Exception("Debe ingresar la forma de pago para poder grabar e imprimir.")
                     End If

                  End If

               End If
            End If
         End If

         'si voy a imprimir en una impresora fiscal, primero imprimo y despues obtengo el nro. de comprobante
         'en otro caso, grabo y despues imprimo

         LogV(" 3.- Condiciones antes de Imprimir ")
         LogV(String.Format(" 3.1.- Me.EsComprobanteFiscal() = {0}", Me.EsComprobanteFiscal()))
         LogV(String.Format(" 3.2.- oVentas.TipoComprobante.GrabaLibro = {0}", oVentas.TipoComprobante.GrabaLibro))

         LogV(" 4.- Antes de Imprimir ")
         'Solo Fiscales LEGALES envio antes de grabar, los demas grabo primero.
         If Me.EsComprobanteFiscal() And oVentas.TipoComprobante.GrabaLibro Then
            LogV(" 4.1.- Imprimir Fiscal ")
            LogV(" 4.1.1.- Antes de Imprimir Fiscal ")
            If Me._fc.ImprimirComprobante(oVentas, Me.EsComprobanteFiscal()) Then
               LogV(" 4.1.2.- Luego de Imprimir Fiscal ")
               Try
                  LogV(" 4.1.3.- Antes de Insertar Venta ")

                  oFacturacion.Insertar(oVentas, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

               Catch ex As Reglas.Ventas.ActualizaCAEException
                  MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               Catch
                  Throw
               End Try

               If Me._cierraAutomaticamente Then
                  Me.Close()
                  Exit Sub
               End If

               MessageBox.Show(oVentas.TipoComprobante.Descripcion & " Nro. " & oVentas.NumeroComprobante.ToString() & Convert.ToChar(Keys.Enter) & " de " & Me.bscCliente.Text & Convert.ToChar(Keys.Enter) & " fue impreso y grabado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               If Not String.IsNullOrEmpty(oVentas.TipoComprobante.IdTipoComprobanteSecundario) Then
                  If MessageBox.Show("¿Desea Cargar Automaticamente el Comprobante Secundario '" & oVentas.TipoComprobante.IdTipoComprobanteSecundario & "'?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                     'Me.tsbGrabar.Enabled = True
                     Me.NuevoSecundario(oVentas)
                     Exit Sub
                  End If
               End If

               Me.Nuevo(Publicos.FacturacionMantieneElCliente, Publicos.FacturacionMantieneElComprobante)

            Else
               Throw New Exception("Error en la impresión Fiscal")
            End If
         Else
            LogV(" 4.2.- Imprimir No Fiscal ")
            Try
               LogV(" 4.2.1.- Antes de Guardar Comprobante ")

               oFacturacion.Insertar(oVentas, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

            Catch ex As Reglas.Ventas.ActualizaCAEException
               Dim stbMensaje = New StringBuilder(ex.Message)
               stbMensaje.AppendLine().AppendLine().AppendFormat("¿Desea reintentar el envio del comprobante {0}?", oVentas.PkToString())
               If ShowPregunta(stbMensaje.ToString(), MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                  Try
                     Dim rVentas = New Reglas.Ventas()
                     rVentas.ActualizarCAE(oVentas, Entidades.AFIPCAE.Secuencia.SegundaVez, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
                  Catch ex1 As Exception
                     Dim stbMensaje2 = New StringBuilder(ex1.Message).AppendLine().AppendLine()
                     stbMensaje2.AppendFormat("No se pudo obtener el CAE del comprobante {0}", oVentas.PkToString()).AppendLine().AppendLine()
                     stbMensaje2.AppendFormat("Solicite CAE del mismo utilizando la pantalla de Solicitar CAE")
                     ShowMessage(stbMensaje2.ToString())
                  End Try
               Else
                  ShowMessage("No se realizó el reenvio del comprobante. Verifique en Solicitar CAE.")
               End If
            Catch
               Throw
            End Try
            'Solo Fiscales LEGALES envio antes de grabar, los demas grabo primero.
            If Me.EsComprobanteFiscal() And oVentas.TipoComprobante.EsPreElectronico Then
               If Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionFiscalSincronica Then
                  LogV(" 4.3.- Imprimir Pre-Fiscal ")

                  My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Convierto Pre-Ticket en Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                  '''''Armo la entidad TICKET FISCAL
                  LogV(" 4.3.1.- Antes de Armar Comprobante Fiscal ")
                  Dim ComprobanteFiscal As Entidades.Venta = oFacturacion.ArmarComprobanteFiscal(oVentas)
                  LogV(" 4.3.2.- Luego de Armar Comprobante Fiscal ")
                  '''''Conservo pre TICKET

                  Try
                     My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Comienzo Imprimir Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                     LogV(" 4.3.3.- Antes de Impresión Fiscal ")
                     If Me._fc.ImprimirComprobante(ComprobanteFiscal, Me.EsComprobanteFiscal()) Then
                        LogV(" 4.3.4.- Luego de Impresión Fiscal ")
                        Try
                           'Guardo numero de comprobante por si falla la grabacion del TICKET
                           oFacturacion.ActualizaNumeroComprobanteFiscal(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                                                               oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor,
                                                               oVentas.NumeroComprobante, ComprobanteFiscal.NumeroComprobante)

                           My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Grabo Nuevo Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                           '''''Si la impresion fue ok grabo el TICKET FISCAL
                           LogV(" 4.3.5.- Antes de Guardar Comprobante ")
                           oFacturacion.GrabarComprobanteFiscal(oVentas, ComprobanteFiscal, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)
                           LogV(" 4.3.6.- Luego de Guardar Comprobante ")

                        Catch ex As Reglas.Ventas.ActualizaCAEException
                           MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Catch
                           MessageBox.Show("Error en la grabación del comprobante, por favor ir a pantalla Impresion Tickets Fiscales.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                     End If
                     My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Finalizo Imprimir Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                  Catch ex As Exception
                     Dim stb As StringBuilder = New StringBuilder()
                     stb.AppendLine("Error en la impresión Fiscal.")
                     ArmaErrorRecursivo(ex, stb)

                     ShowMessage(stb.ToString())
#Region "Notas-Marcas"
                     'stb.AppendLine().Append("¿Desea reintentar?")
                     'If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then

                     '   Using IFR As ImpresionFiscalReintentar = New ImpresionFiscalReintentar(oVentas, ComprobanteFiscal, Me.EsComprobanteFiscal())
                     '      IFR.IdFuncion = IdFuncion
                     '      IFR.ShowDialog()
                     '   End Using

                     'Else
                     '   MessageBox.Show("Error en la impresión Fiscal, imprimir comprobante desde la Pantalla Impresión Ticket Fiscal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                     'End If
#End Region
                  End Try
               Else
                  ' MessageBox.Show("Imprimir comprobante de la Pantalla Impresion Tickets Fiscales.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               End If
            Else
               Dim msg As System.Text.StringBuilder = New System.Text.StringBuilder()
               msg.AppendFormat("{0} Nro. {1}", oVentas.TipoComprobante.Descripcion, oVentas.NumeroComprobante.ToString()).AppendLine()
               msg.AppendFormat("de {0}", Me.bscCliente.Text).AppendLine()

               If oVentas.TipoComprobante.EsElectronico Then
                  If Not String.IsNullOrEmpty(oVentas.AFIPCAE.CAE) Then
                     msg.AppendFormat("CAE {0} con vencimiento {1} ", oVentas.AFIPCAE.CAE, oVentas.AFIPCAE.CAEVencimiento.ToString("dd/MM/yyyy")).AppendLine()
                     ExportarPDF.ArmarDocumento(oVentas, "", "")
                  End If
               End If

               'verifica si el tipo de comprobante se puede imprimir, sino no hace nada
               Try
                  LogV(" 5.- Antes de Impresión de comprobantes no fiscales ")
                  If Me.ImprimeComprobante() Then
                     If Me._fc.ImprimirComprobante(oVentas, Me.EsComprobanteFiscal()) Then
                        msg.AppendFormat(" fue impreso y grabado.")
                     Else
                        msg.AppendFormat(" fue grabado.")
                     End If
                  Else
                     msg.AppendFormat(" fue grabado.")
                  End If
                  LogV(" 5.1.- Luego de Impresión de comprobantes no fiscales ")
               Catch ex As Exception
                  'si da error en la impresión solo muestra el mensaje y sigue para borrar la pantalla.
                  'sino no borraba la pantalla y era como que no se grababa la factura, mientras que si se graba
                  ShowError(ex)
               End Try

               Try
                  LogV(" 6.- Antes de Impresión el recibo del comprobante ")
                  Dim facturacionimprimeReciboVentasCtaCte = Reglas.Publicos.Facturacion.Impresion.FacturacionimprimeReciboVentasCtaCte
                  If facturacionimprimeReciboVentasCtaCte Then
                     Dim recibo = New Reglas.CuentasCorrientes().GetRecibosDelComprobante(oVentas).FirstOrDefault()
                     If recibo IsNot Nothing AndAlso recibo.TipoComprobante.Imprime Then
                        If New RecibosImprimir().ImprimirRecibo(recibo, Reglas.Publicos.CtaCte.VisualizaReciboDeCliente) Then
                           msg.AppendFormat(" fue impreso y grabado.")
                        End If
                     End If
                  Else
                     msg.AppendFormat(" fue grabado.")
                  End If
                  LogV(" 6.1.- Luego de Impresión de comprobantes no fiscales ")
               Catch ex As Exception
                  'si da error en la impresión solo muestra el mensaje y sigue para borrar la pantalla.
                  'sino no borraba la pantalla y era como que no se grababa la factura, mientras que si se graba
                  ShowError(ex)
               End Try


               'Si es NC abre la pantalla de Recibos para poder asociarla al comprobante y cancelarlo
               If Publicos.FacturacionCargarReciboLuegoNC And oVentas.TipoComprobante.CoeficienteValores = -1 And Not oVentas.TipoComprobante.EsPreElectronico And
                  oVentas.TipoComprobante.ActualizaCtaCte And oVentas.FormaPago.Dias > 0 Then
                  Dim ctacte = New Reglas.CuentasCorrientes().GetUna(oVentas.IdSucursal, oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)
                  'Si la NC está saldada no tengo que abrir el Recibo para aplicar la Minuta
                  If ctacte.Saldo <> 0 Then
                     Try
                        Me.Cursor = Cursors.WaitCursor
                        Dim Recibos As Recibos = New Recibos(oVentas)
                        Recibos.ConsultarAutomaticamente = True
                        Recibos.MdiParent = Me.MdiParent
                        Recibos.IdFuncion = IdFuncion
                        Recibos.Show()
                     Catch ex As Exception
                        ShowError(ex)
                     Finally
                        Me.Cursor = Cursors.Default
                     End Try
                  End If
               End If

               If Me._cierraAutomaticamente Then
                  Me.Close()
                  Exit Sub
               End If

               If oVentas.TipoComprobante.AfectaCaja And oVentas.FormaPago.Dias = 0 Then

                  Dim OfreceCalcularVuelto As String = Reglas.Publicos.Facturacion.FacturacionOfreceCalcularVuelto

                  If OfreceCalcularVuelto <> "NOOFRECER" Then

                     If OfreceCalcularVuelto = "OFRECER" Then

                        If MessageBox.Show(msg.ToString() & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter) & "¿ Desea Calcular el Vuelto ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                           Dim oFactCalcularVuelto As FacturacionCalcularVuelto
                           oFactCalcularVuelto = New FacturacionCalcularVuelto(oVentas.ImportePesos)
                           oFactCalcularVuelto.ShowDialog()
                        End If

                     Else

                        Dim oFactCalcularVuelto As FacturacionCalcularVuelto
                        oFactCalcularVuelto = New FacturacionCalcularVuelto(oVentas.ImportePesos)
                        oFactCalcularVuelto.ShowDialog()

                     End If

                  Else

                     MessageBox.Show(msg.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                  End If

               End If

               '' ''******************************
               '' ''vml 10/9/12
               ' ''Dim tieneContabilidad As Boolean = True ' reemplazar por variable de la base.
               ' ''Publicos.TieneModuloContabilidad
               ' ''If tieneContabilidad Then
               ' ''    CargarContabilidad(oVentas)
               ' ''End If
               '' ''****************************************************************

               Try
                  If Not String.IsNullOrEmpty(oVentas.TipoComprobante.IdTipoComprobanteSecundario) And Not oVentas.TipoComprobante.EsPreElectronico And Not oVentas.TipoComprobante.EsPreFiscal Then
                     If MessageBox.Show("¿Desea Cargar Automaticamente el Comprobante Secundario '" & oVentas.TipoComprobante.IdTipoComprobanteSecundario & "'?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.NuevoSecundario(oVentas)
                        Exit Sub
                     End If
                  End If
               Catch ex As Exception
                  'si da error en el segundo comprobante muestra el error y muestra el error, pero limpia la pantalla
                  ShowError(ex)
               End Try

               Me.Nuevo(Publicos.FacturacionMantieneElCliente, Publicos.FacturacionMantieneElComprobante)
            End If
         End If

         If _invocadosCajero IsNot Nothing AndAlso _invocadosCajero.Count > 0 Then
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
         End If


      End If

      LogV(" 0.1.- Finaliza GrabarComprobante ")
      LogV("********** FacturacionV2.GrabarComprobante ********** ")

   End Sub

   Private Function ArmarTablaMultiplesRubros(ventas As Entidades.Venta _
                                                , rubrosVta As DataTable _
                                                , grillaPantalla As DataGridView) As DataTable

      For Each filarubro As DataRow In rubrosVta.Rows
         For Each prod As Entidades.VentaProducto In ventas.VentasProductos

            If filarubro("idProducto").ToString = prod.IdProducto.ToString Then

               Select Case filarubro("campo").ToString
                  Case ContabilidadPublicos.ConstantesVenta.ImporteTotal '"Imp. Total"
                     If CBool(filarubro("debe")) Then 'debe
                        filarubro("debeValor") = prod.ImporteTotal
                     Else 'haber
                        filarubro("haberValor") = prod.ImporteTotal
                     End If
                  Case ContabilidadPublicos.ConstantesVenta.IvaTotal '"IVA Total"
                     If CBool(filarubro("debe")) Then 'debe
                        filarubro("debeValor") = prod.ImporteImpuesto
                     Else 'haber
                        filarubro("haberValor") = prod.ImporteImpuesto
                     End If
                  Case ContabilidadPublicos.ConstantesVenta.ImporteBruto '"Imp. Bruto"
                     If CBool(filarubro("debe")) Then 'debe
                        filarubro("debeValor") = prod.PrecioNeto - prod.ImporteImpuesto
                     Else 'haber
                        filarubro("haberValor") = prod.PrecioNeto - prod.ImporteImpuesto
                     End If

                  Case ContabilidadPublicos.ConstantesVenta.Iva10 '"IVA 10%" ' esta combinacion solo para compras
                     If CBool(filarubro("debe")) Then 'debe
                        filarubro("debeValor") = prod.ImporteImpuesto
                     Else 'haber
                        filarubro("haberValor") = prod.ImporteImpuesto
                     End If
                  Case ContabilidadPublicos.ConstantesVenta.Iva21 '"IVA 21%"  ' esta combinacion solo para compras
                     If CBool(filarubro("debe")) Then 'debe
                        filarubro("debeValor") = prod.ImporteImpuesto
                     Else 'haber
                        filarubro("haberValor") = prod.ImporteImpuesto
                     End If


               End Select
            End If
         Next
      Next

      Return rubrosVta

   End Function

   Private Function GetDscAsiento(oventas As Entidades.Venta) As String
      Return oventas.IdSucursal.ToString & "-" & oventas.IdTipoComprobante.ToString & "-" & oventas.LetraComprobante.ToString & "-" & oventas.CentroEmisor.ToString & "-" & oventas.NumeroComprobante.ToString & "-" & oventas.Fecha.ToString
   End Function

   Private Function ObtenerCantidadGrupos(ventas As Entidades.Venta) As Integer
      Dim oProcesoContable As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos()

      Return oProcesoContable.GetCantRubrosVenta(ventas)

   End Function

   Private Function ImprimeComprobante() As Boolean
      'Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime
      'si presiono Shift+F4 no le va a imprimir el comprobante (solo es valido para los comprobantes que no son Fiscales
      If Me._presionoElShift Then
         Return False
      End If
      Return Me._imprime
   End Function

   Private Sub SeteaDetalles()
      _ventasProductos = New System.Collections.Generic.List(Of Entidades.VentaProducto)
      _ventasContactos = New List(Of Entidades.ClienteContacto)()
      _subTotales = New System.Collections.Generic.List(Of Entidades.VentaImpuesto)()
      _ventasObservaciones = New List(Of Entidades.VentaObservacion)()
      _ventasObservacionesCHTarjeta = New List(Of Entidades.VentaObservacion)()
      _cheques = New List(Of Entidades.Cheque)()
      _tarjetas = New List(Of Entidades.VentaTarjeta)()
      _chequesRechazados = New List(Of Entidades.Cheque)()
      _productosLotes = New List(Of Entidades.VentaProductoLote)()
      _ventasDespachos = New List(Of Entidades.VentaDespacho)()
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

   Private Sub CalcularTotalProductoRT(PrecioLista As Decimal)
      TotalProductoRT = (PrecioLista * Decimal.Parse(Me.txtCantidadRT.Text)) + DescRecRT
   End Sub

   Private Sub LimpiarCamposProductos()

      _ordenProducto = 0

      Me.bscCodigoProducto2.Enabled = True
      Me.bscCodigoProducto2.Text = ""
      Me._nroOferta = Nothing
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.Enabled = True
      Me.bscProducto2.Text = ""
      Me.bscProducto2.FilaDevuelta = Nothing
      cmbTipoOperacion.Enabled = True
      Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)

      txtCosto.Text = 0D.ToString(_formatoAMostrarEnPrecio)
      txtCosto.Tag = Nothing

      txtRecargoVenta.Text = txtPrecio.Text
      Me.txtStock.Text = "0"
      Me.txtStock.Tag = False
      Me.txtCantidad.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      Me.txtDescRec.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto)
      Me.txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTamanio.Text = "0." + New String("0"c, Me._decimalesEnTamanio)
      Me.txtUM.Text = ""
      Me.lblKilosModDesc.Visible = False
      Me.txtKilosModDesc.Text = "0." + New String("0"c, Me._decimalesEnKilos)
      Me.txtKilosModDesc.Visible = False
      txtProductoObservacion.Text = String.Empty
      txtProductoObservacion.Visible = False
      Me.dtpFechaActPrecios.Value = Date.Today()
      Me.txtCantidadManual.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      If Me.cmbUM2.Items.Count > 0 Then
         Me.cmbUM2.DataSource = Nothing
         Me.cmbUM2.Items.Clear()
      End If
      '--------------------------------------------------------------------------
      cmbDepositoOrigen.Enabled = True
      cmbUbicacionOrigen.Enabled = True
      '--------------------------------------------------------------------------
      cmbCentroCosto.SelectedIndex = -1
      cmbFormula.SelectedIndex = -1
      cmbTipoOperacion.SelectedItem = Entidades.Producto.TiposOperaciones.NORMAL
      cmbNota.Text = String.Empty

      MuestraImpuestosInternos(0, 0)

      _modificoDescuentos = False
      _txtCantidad_prev = Nothing

      '--REQ-35488.- -------------------------
      txtAtributo01.Text = String.Empty
      txtAtributo02.Text = String.Empty
      '---------------------------------------
      'controlo que cuando viene de un presupuesto revise si carga los descuentos/recargos del tipo de comprobante
      Dim carDesRecAct As Boolean = True
      If Me._comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 Then
         carDesRecAct = Me._comprobantesSeleccionados(0).TipoComprobante.CargaDescRecActual
      End If

      If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro And carDesRecAct Then
         Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
         For Each vpo As Entidades.VentaProducto In _ventasProductos
            _txtCantidad_prev = Nothing
            Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

            For Each vp As Entidades.VentaProducto In _ventasProductos
               If vp.Producto.IdRubro = vpo.Producto.IdRubro Then
                  cantidad += vp.Cantidad
               End If
            Next

            Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, vpo.Producto, cantidad, Me._decimalesEnTotales)

            For Each vp As Entidades.VentaProducto In _ventasProductos
               If vp.Producto.IdRubro = vpo.Producto.IdRubro Then
                  vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
                  If calculaDescuentoRecargo2 Then
                     vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
                  End If
               End If
               vp.DescuentoRecargo = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                                vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, vp.Cantidad)
            Next
         Next
         'RecalcularTodo()
      End If

      _ventasProductosFormulasActual = Nothing
      _nrosSerieSeleccionados = Nothing

      pnlEsOferta.Visible = False

      SetearDescuentosPorCantidad(Nothing)
   End Sub

   Private Function MuestraImpuestosInternos(importe As Decimal, porcentaje As Decimal) As Decimal
      txtImpuestoInterno.Text = importe.ToString("N2")
      txtImpuestoInterno.Visible = importe <> 0
      txtImpuestoInterno.LabelAsoc.Visible = txtImpuestoInterno.Visible

      '-- REQ-31083 -- Se amplia a cuatro la cantidad de Decimales.- --
      '-- Se corrige tambien Campo del formulario en formato N4.- --
      txtPorcImpuestoInterno.Text = porcentaje.ToString("N4")
      txtPorcImpuestoInterno.Visible = porcentaje <> 0
      txtPorcImpuestoInterno.LabelAsoc.Visible = txtPorcImpuestoInterno.Visible

      Return importe
   End Function

   Private Sub LimpiarCamposProductosRT()
      Me.bscCodigoProducto2RT.Enabled = True
      Me.bscCodigoProducto2RT.Text = ""
      Me.bscCodigoProducto2RT.FilaDevuelta = Nothing
      Me.bscProducto2RT.Enabled = True
      Me.bscProducto2RT.Text = ""
      Me.bscProducto2RT.FilaDevuelta = Nothing
      Me.txtStockRT.Text = "0"
      Me.txtStockRT.Tag = False
      Me.txtCantidadRT.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      Me.txtCantidadManualRT.Text = Me.txtCantidadRT.Text
      If Me.cmbUM2RT.Items.Count > 0 Then
         Me.cmbUM2RT.DataSource = Nothing
         Me.cmbUM2RT.Items.Clear()
      End If

      cmbDepositoRT.Enabled = False
      cmbUbicacionRT.Enabled = False

      Me.txtCantDiasFechaDevolucion.Text = "0"
      Me.CalcularFechaDiasDevolucion()
   End Sub

   Private Sub LimpiarCamposObservDetalles()
      Me.bscObservacionDetalle.Text = String.Empty
      cmbTipoObservacion.SelectedValue = _idTipoObservacion
   End Sub

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
      Dim bultos As Decimal = 0
      Dim blnEmbalajeNormal As Boolean = Not Publicos.ProductoEmbalajeHaciaArriba

      'If Me.dgvProductos.Rows.Count > 0 Then

      Dim totalKilosItems As Reglas.Ventas.TotalKilosItems = New Reglas.Ventas().CalculaTotalKilosItems(_ventasProductos)
      Kilos = totalKilosItems.TotalKilos
      CantProductos = totalKilosItems.TotalProductos

      'For Each vp As Entidades.VentaProducto In Me._ventasProductos
      '   Kilos += vp.Kilos
      'Next

      If Reglas.Publicos.Facturacion.FacturacionRemitoTranspCalculaBultos Then
         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.AfectaStock Then
               If vp.Producto.Embalaje > 0 Then
                  If blnEmbalajeNormal Then
                     bultos = bultos + vp.Cantidad
                  Else
                     bultos = bultos + Decimal.Round((vp.Cantidad / Decimal.Parse(vp.Producto.Embalaje.ToString())), 0)
                  End If
               Else
                  bultos = 0
                  Exit For
               End If
            End If
         Next
      End If

      For Each vi As Entidades.VentaImpuesto In Me._subTotales
         bruto += vi.Bruto
         subTotal += vi.Neto

         'Si es remito de transporte le borro el IVA, el valor declarado es SIN IVA.
         If Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
            vi.Importe = 0
         End If

         If vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
            impInt += vi.Importe
         Else
            iva += vi.Importe
         End If
         total += vi.Total
      Next

      Dim entPercIVA = New List(Of Entidades.PercepcionVentaCalculo)()
      Dim entPercIIBB = New List(Of Entidades.PercepcionVentaCalculo)()
      'IIBB - Calcula la percepción de ingresos brutos del cliente
      'solo se calcula si el cliente tiene una actividad
      'EsComercial=True deja afuera las NDEBCHEQRECH

      Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)
      If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
         If Reglas.Publicos.RetieneIIBB And ((tipoComp.GrabaLibro And tipoComp.EsComercial) Or tipoComp.EsPreElectronico) Then
            'Si es una nota de crédito que invocó una factura, calculo las percepciones como regla de 3 de entre el total de la factura y el total de la nota de crédito
            If tipoComp.CoeficienteValores < 0 AndAlso _comprobantesSeleccionados IsNot Nothing AndAlso _comprobantesSeleccionados.Count > 0 Then
               'bruto: es el total la NC
               'subTotal: es el neto imponible de la NC
               'subtotalInvocados: es el neto imponible de la FC
               'importePerVen: importe de cada percepcion aplicando regla de 3 para el calculo proporcional
               Dim subtotalInvocados As Decimal = 0
               For Each dr As DataRow In _dtActividades.Select()
                  dr("Monto") = 0
               Next
               For Each fact As Entidades.Venta In _comprobantesSeleccionados
                  subtotalInvocados += fact.Subtotal
                  For Each perVen As Entidades.PercepcionVenta In fact.Percepciones
                     Dim importePerVen As Decimal = perVen.ImporteTotal
                     importePerVen = If(subtotalInvocados <> 0, importePerVen * subTotal / subtotalInvocados, 0)
                     Select Case perVen.TipoImpuesto.IdTipoImpuesto
                        Case Entidades.TipoImpuesto.Tipos.PIIBB
                           percepcionIB += importePerVen

                           Dim PercepcionCalc = New Entidades.PercepcionVentaCalculo()
                           Dim coe As Integer = tipoComp.CoeficienteValores

                           For Each dr As DataRow In _dtActividades.Select(String.Format("IdProvincia = '{0}'", perVen.IdProvincia))
                              Dim monto As Decimal = If(IsNumeric(dr("Monto")), Decimal.Parse(dr("Monto").ToString()), 0)
                              dr("Monto") = monto + importePerVen
                           Next

                           PercepcionCalc.Alicuota = perVen.Alicuota
                           PercepcionCalc.BaseImponible = subTotal
                           PercepcionCalc.IdActividad = perVen.IdActividad
                           PercepcionCalc.Monto = importePerVen
                           PercepcionCalc.IdProvincia = perVen.IdProvincia
                           entPercIIBB.Add(PercepcionCalc)

                        Case Entidades.TipoImpuesto.Tipos.PGANA
                           percepcionGanancias += importePerVen
                        Case Entidades.TipoImpuesto.Tipos.PIVA
                           percepcionIVA += importePerVen
                        Case Entidades.TipoImpuesto.Tipos.PVAR
                           percepcionVarias += importePerVen
                        Case Else

                     End Select

                  Next
               Next

               txtPercepcionIVA.Text = percepcionIVA.ToString("N" + _decimalesEnTotales.ToString())
               txtPercepcionIIBB.Text = percepcionIB.ToString("N" + _decimalesEnTotales.ToString())
               txtPercepcionGanancias.Text = percepcionGanancias.ToString("N" + _decimalesEnTotales.ToString())
               txtPercepcionVarias.Text = percepcionVarias.ToString("N" + _decimalesEnTotales.ToString())

            Else
               'If Me.cmbActividades.SelectedIndex <> -1 And Me._clienteE IsNot Nothing Then
               If _dtActividades IsNot Nothing And Me._clienteE IsNot Nothing Then
                  For Each drActividad As DataRow In _dtActividades.Rows
                     drActividad("Monto") = 0
                  Next

                  Dim coe As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores

                  entPercIIBB = New Reglas.Ventas().GetMontoPercepcionIIBB(Me._clienteE,
                                                                           _dtActividades,
                                                                           subTotal * coe,
                                                                           total * coe,
                                                                           Me.dtpFecha.Value)
                  If entPercIIBB IsNot Nothing Then
                     Dim totalPercepIIBB As Decimal = 0
                     For Each ent As Entidades.PercepcionVentaCalculo In entPercIIBB
                        ent.Monto = ent.Monto * coe
                        totalPercepIIBB += ent.Monto
                        ent.BaseImponible = ent.BaseImponible * coe
                        Me._baseImponibleIIBB = ent.BaseImponible
                        For Each dr As DataRow In _dtActividades.Select(String.Format("IdProvincia = '{0}'", ent.IdProvincia))
                           dr("Monto") = ent.Monto
                        Next
                     Next
                     Me.txtPercepcionIIBB.Text = totalPercepIIBB.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
                  End If
               End If
            End If
         Else
            Me.txtPercepcionIIBB.Text = "0." + New String("0"c, Me._decimalesEnTotales)
            Me._baseImponibleIIBB = 0
         End If

         entPercIVA = _fc.CalculaPercepcionesIVA(_clienteE, tipoComp, _categoriaFiscalEmpresa, _ventasProductos, _comprobantesSeleccionados)

         txtPercepcionIVA.SetValor(entPercIVA.Sum(Function(x) x.Monto))
         ugPercepcionIVA.DataSource = entPercIVA
         AjustarColumnasGrilla(ugPercepcionIVA, _titPercepcionesIVA)

      End If

      dgvActividades.Columns("IdProvincia").Visible = False

      percepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
      percepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
      percepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
      percepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)

      percepcionTotal = percepcionIVA + percepcionIB + percepcionGanancias + percepcionVarias

      totalGeneral = total + percepcionTotal

      'End If

      txtTotalRetenciones.Text = percepcionTotal.ToString(_formatoEnTotales)
      txtTotalBruto.Text = bruto.ToString(_formatoEnTotales)
      txtDescRecGral.Text = (subTotal - bruto).ToString(_formatoEnTotales)
      txtTotalNeto.Text = subTotal.ToString(_formatoEnTotales)
      txtTotalSubtotales.Text = totalGeneral.ToString(_formatoEnTotales)
      txtTotalImpuestos.Text = iva.ToString(_formatoEnTotales)
      txtTotalImpuestosInternos.Text = impInt.ToString(_formatoEnTotales)
      txtTotalGeneral.Text = totalGeneral.ToString(_formatoEnTotales)

      '---REQ-44517.- ----------------------------------------------------------------------------------------------------------------
      Dim cotizaDolar As Decimal
      If Decimal.Parse(txtCotizacionDolar.Text) = 0 Then
         cotizaDolar = New Reglas.Monedas().GetUna(2).FactorConversion
      Else
         cotizaDolar = Decimal.Parse(txtCotizacionDolar.Text)
      End If
      '--------------------------------------------------------------------------------------------------------------------------------
      txtTotalRetencionesDolar.Text = (percepcionTotal / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      txtTotalBrutoDolar.Text = (bruto / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      txtDescRecGralDolar.Text = ((subTotal - bruto) / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      txtTotalNetoDolar.Text = (subTotal / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      txtTotalSubtotalesDolar.Text = (totalGeneral / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      txtTotalImpuestosDolar.Text = (iva / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      txtTotalImpuestosInternosDolar.Text = (impInt / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      txtTotalGeneralDolar.Text = (totalGeneral / cotizaDolar).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))

      CalcularDiferenciaDePago()

      txtKilos.Text = Kilos.ToString(_formatoEnKilos)
      txtCantidadProductos.Text = CantProductos.ToString("N0")
      txtBultos.Text = bultos.ToString("N0")

      'TODO: 5329/2023
      _fc.CargarRetenciones(entPercIVA, entPercIIBB,
                            txtPercepcionGanancias.ValorNumericoPorDefecto(0D), txtPercepcionVarias.ValorNumericoPorDefecto(0D))

      If dgvProductos.Rows.Count > 0 Then
         cmbCategoriaFiscal.Enabled = False
      ElseIf cmbTiposComprobantes.SelectedItem IsNot Nothing And cmbCategoriaFiscal.SelectedItem IsNot Nothing Then
         'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
         If Not _clienteE Is Nothing AndAlso _clienteE.EsClienteGenerico Then
            cmbCategoriaFiscal.Enabled = Not tipoComp.GrabaLibro
         End If
      End If

      lblItems.Text = String.Format("{0} Items", _ventasProductos.Count)

      If Not _enNuevo And Not _PlanesTarjetas Then
         If _invocadosCajero IsNot Nothing AndAlso _invocadosCajero.Count > 0 Then
            If txtCheques.ValorNumericoPorDefecto(0D) = 0 And
               txtTickets.ValorNumericoPorDefecto(0D) = 0 And
               txtTarjetas.ValorNumericoPorDefecto(0D) = 0 And
               txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) = 0 And cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).Dias = 0 Then
               If Reglas.Publicos.Facturacion.FacturacionContadoEsEnPesos Then
                  txtEfectivo.Text = txtTotalGeneral.Text
               End If
               CalcularPagos(False)
            End If
         End If
      End If

   End Sub

   Private Sub CargarDatosPaciente(dr As DataGridViewRow)
      Me.bscCodigoPaciente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoPaciente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscPaciente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoPaciente.Selecciono = True
      Me.bscPaciente.Selecciono = True

      Me.bscCodigoPaciente.Permitido = False
      Me.bscPaciente.Permitido = False

      Me.bscCodigoDoctor.Focus()
   End Sub

   Private Sub CargarDatosDoctor(dr As DataGridViewRow)
      Me.bscCodigoDoctor.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoDoctor.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscDoctor.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoDoctor.Selecciono = True
      Me.bscDoctor.Selecciono = True

      Me.bscCodigoDoctor.Permitido = False
      Me.bscDoctor.Permitido = False

      Me.dtpFechaCirugia.Focus()
   End Sub

   Private Sub CargarDatosEmbarcacion(dr As DataGridViewRow)

      _idEmbarcacion = Long.Parse(dr.Cells("idEmbarcacion").Value.ToString())
      _codigoEmbarcacion = Long.Parse(dr.Cells("CodigoEmbarcacion").Value.ToString())
      _nombreEmbarcacion = dr.Cells("NombreEmbarcacion").Value.ToString()
      _idCategoriaEmbarcacion = Integer.Parse(dr.Cells("idCategoriaEmbarcacion").Value.ToString())
      _nombreCategoriaEmbarcacion = dr.Cells("nombreCategoriaEmbarcacion").Value.ToString()

      bscDireccion.Text = dr.Cells("NombreEmbarcacion").Value.ToString()
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      If Not String.IsNullOrEmpty(bscCodigoCliente.Text) Then
         bscCliente.PresionarBoton()
         Me.bscDireccion.Permitido = False
      Else
         MessageBox.Show("La EMBARCACION no posee Cliente Responsable de Cargo Asignado!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscDireccion.Permitido = True
      End If

   End Sub

   Private Sub CargarDatosCama(dr As DataGridViewRow)


      _idCama = Long.Parse(dr.Cells("idCama").Value.ToString())
      _codigoCama = dr.Cells("CodigoCama").Value.ToString()
      _idNave = Short.Parse(dr.Cells("idNave").Value.ToString())
      _nombreNave = dr.Cells("NombreNave").Value.ToString()
      _idCategoriaCama = Integer.Parse(dr.Cells("idCategoriaCama").Value.ToString())
      _nombreCategoriaCama = dr.Cells("nombreCategoriaCama").Value.ToString()

      bscDireccion.Text = dr.Cells("CodigoCama").Value.ToString()

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      If Not String.IsNullOrEmpty(bscCodigoCliente.Text) Then
         bscCliente.PresionarBoton()
         Me.bscDireccion.Permitido = False
      Else
         MessageBox.Show("La CAMA no posee Cliente Responsable de Cargo Asignado!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscDireccion.Permitido = True
      End If

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      txtCategoria.Text = dr.Cells("NombreCategoria").Value.ToString()

      txtObservacion.Text = dr.Cells("Observacion").Value.ToString()

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

      With cmbDirecciones
         .DisplayMember = "DireccionAMostrar"
         .ValueMember = "IdDireccion"
         .DataSource = New Reglas.ClientesDirecciones().GetDirecciones(Long.Parse(dr.Cells("IdCliente").Value.ToString()))
         .SelectedIndex = 0
      End With

      cmbDirecciones.Enabled = True
      '      Me.txtDireccionYLocalidad.Text = dr.Cells("Direccion").Value.ToString() & " - " & dr.Cells("NombreLocalidad").Value.ToString()

      txtTelefonos.Text = dr.Cells("Telefono").Value.ToString() & " " & dr.Cells("Celular").Value.ToString()
      txtLimiteDeCredito.Text = dr.Cells("LimiteDeCredito").Value.ToString()
      txtCorreoElectronico.Text = dr.Cells("CorreoElectronico").Value.ToString()

      _IdCategoriaFiscalOriginal = Short.Parse(dr.Cells("IdCategoriaFiscal").Value.ToString())

      cmbCategoriaFiscal.SelectedValue = dr.Cells("IdCategoriaFiscal").Value

      Dim idProvinciaCliente As String = String.Empty
      If cmbDirecciones.SelectedItem IsNot Nothing Then
         idProvinciaCliente = DirectCast(cmbDirecciones.SelectedItem, DataRowView).Row("IdProvincia").ToString()
      End If
      _dtActividades = New Reglas.ClientesActividades().GetClientesActividades(Long.Parse(dr.Cells("IdCliente").Value.ToString()),
                                                                              idProvinciaCliente,
                                                                              DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal)

      _dtActividades.Columns.Add("Monto", GetType(Decimal)).DefaultValue = 0

      dgvActividades.DataSource = _dtActividades
      dgvActividades.Columns("IdProvincia").Visible = False

      Dim act As DataTable = _dtActividades.Copy()

      Dim unaProvincia As Boolean = _dtActividades.Rows.Count > 0

      Dim ultimaProvincia As String = String.Empty
      For Each drActividades As DataRow In _dtActividades.Rows
         If String.IsNullOrWhiteSpace(ultimaProvincia) Then
            ultimaProvincia = drActividades("IdProvincia").ToString()
         Else
            If ultimaProvincia <> drActividades("IdProvincia").ToString() Then
               unaProvincia = False
               ultimaProvincia = drActividades("IdProvincia").ToString()
            Else
               drActividades.Delete()
            End If
         End If
      Next

      _dtActividades.AcceptChanges()

      If unaProvincia Then
         'Cargo las actividades en el combo si tiene mas de una
         'If Boolean.Parse(dr.Cells("InscriptoIBStaFe").Value.ToString()) Then
         '' ''Dim act As DataTable = New Reglas.ClientesActividades().GetClientesActividades(Long.Parse(dr.Cells("IdCliente").Value.ToString()))
         'Dim act As DataTable = New Reglas.EmpresaActividades().GetEmpresaActividades(_dtActividades.Rows(0)("IdProvincia").ToString())
         If act.Rows.Count >= 1 Then
            Me.cmbActividades.Visible = True
            Me.lblActividades.Visible = True
            Me.cmbActividades.DisplayMember = "NombreActividad"
            Me.cmbActividades.ValueMember = "IdActividad"
            Me.cmbActividades.DataSource = act
         End If
         'End If
      End If

      FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
      ''Si es X es remito y siempre debe tener esa letra
      'If Me.txtLetra.Text = "" Or Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "B" Or Me.txtLetra.Text = "C" Or Me.txtLetra.Text = "E" Then
      '   Me.txtLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
      'End If


      'Me.txtCUIT.Text = dr.Cells("CUIT").Value.ToString()

      Me.tbcDetalle.Enabled = True

      If Reglas.Publicos.Facturacion.PermiteModificarClienteFacturacion Then
         Me.bscCliente.Permitido = True
         Me.bscCodigoCliente.Permitido = True
      Else
         Me.bscCliente.Permitido = False
         Me.bscCodigoCliente.Permitido = False
      End If

      Me.bscDireccion.Permitido = False
      Me.txtNumeroLote.Text = dr.Cells("NumeroLote").Value.ToString()

      'Dim Vend As Reglas.Empleados = New Reglas.Empleados()
      If Not _mantenerVendedor Then
         Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(Integer.Parse(dr.Cells("IdVendedor").Value.ToString()))
      End If
      If cmbVendedor.Items.Count = 1 Then
         cmbVendedor.SelectedIndex = 0
      End If

      'Asigno al SelectedValue porque la numeracion de las listas, no necesamiente es correlativa y da error.
      Me.cmbListaDePrecios.SelectedValue = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())

      Dim oCliente As Reglas.Clientes = New Reglas.Clientes()
      Me._clienteE = oCliente.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))


      If Reglas.Publicos.AFIPUtilizaCM05 Then
         chbAFIPConceptoCM05.Enabled = True
         If _clienteE.IdConceptoCM05.HasValue Then
            chbAFIPConceptoCM05.Checked = True
            cmbAFIPConceptoCM05.SelectedValue = _clienteE.IdConceptoCM05.Value
         Else
            chbAFIPConceptoCM05.Checked = False
         End If
      End If


      'If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
      '   Me.txtCUIT.Text = dr.Cells("CUIT").Value.ToString()
      '   Me.lblCUIT.Text = My.Resources.RTextos.Cuit
      'Else
      '   Me.cmbTipoDoc.Text = dr.Cells("TipoDocCliente").Value.ToString()
      '   Me.txtCUIT.Text = dr.Cells("NroDocCliente").Value.ToString()
      '   Me.lblCUIT.Text = "Nro Documento"
      'End If
      If _clienteE.CategoriaFiscal.SolicitaCUIT Then
         lblCUIT.Text = My.Resources.RTextos.Cuit
         cmbTipoDoc.Visible = False
         txtNroDocCliente.Visible = False
         lblTipoDocumento.Visible = False
         txtCUIT.Visible = True
         txtCUIT.ReadOnly = True
         lblCUIT.Text = My.Resources.RTextos.Cuit
         txtNroDocCliente.Text = String.Empty
      Else
         cmbTipoDoc.Visible = True
         cmbTipoDoc.Enabled = False
         txtNroDocCliente.Visible = True
         txtNroDocCliente.ReadOnly = True
         lblTipoDocumento.Visible = True
         txtCUIT.Text = String.Empty
         txtCUIT.Visible = False
         lblCUIT.Text = "Nro Documento"
      End If
      '-- REQ-31371.- ------------------------------------------------------
      txtCUIT.Text = dr.Cells("CUIT").Value.ToString()
      If String.IsNullOrEmpty(dr.Cells("NroDocCliente").Value.ToString()) Then
         cmbTipoDoc.Text = Reglas.Publicos.TipoDocumentoCliente()
         txtNroDocCliente.Text = "0"
      Else
         cmbTipoDoc.Text = dr.Cells("TipoDocCliente").Value.ToString()
         txtNroDocCliente.Text = dr.Cells("NroDocCliente").Value.ToString()
      End If
      '---------------------------------------------------------------------


      If Me._clienteE.IdTipoComprobante <> "" Then
         Me.cmbTiposComprobantes.SelectedIndex = -1 '# Fuerzo la entrada al evento
         If _invocadosCajero IsNot Nothing AndAlso Reglas.Publicos.CajeroIgnorarTipoComprobanteCliente Then
            Me.cmbTiposComprobantes.SelectedValue = Reglas.Publicos.TipoComprobanteGeneradoCajero
         Else
            Me.cmbTiposComprobantes.SelectedValue = Me._clienteE.IdTipoComprobante
            If Me.cmbTiposComprobantes.SelectedIndex = -1 And Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If
      End If

      '# Vuelvo a validar la entidad del cliente por si no se permitió seguir por Falta de Crédito(evento de cambio de comprobante)
      If _clienteE Is Nothing Then Exit Sub

      If _invocadosCajero Is Nothing OrElse _invocadosCajero.Count = 0 Then

         If Reglas.Publicos.Facturacion.FacturacionSolicitaFormaDePago Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me._clienteE.IdFormasPago > 0 Then
               Me.cmbFormaPago.SelectedValue = Me._clienteE.IdFormasPago
               If Me.cmbFormaPago.SelectedIndex = -1 And Me.cmbFormaPago.Items.Count > 0 Then
                  Me.cmbFormaPago.SelectedIndex = 0
               End If
            End If
         End If

         If Reglas.Publicos.Facturacion.FacturacionSolicitaListaDePrecios Then
            Me.cmbListaDePrecios.SelectedIndex = -1
         Else
            If Me._clienteE.IdListaPrecios > 0 Then
               Me.cmbListaDePrecios.SelectedValue = Me._clienteE.IdListaPrecios
               If Me.cmbListaDePrecios.SelectedIndex = -1 And Me.cmbListaDePrecios.Items.Count > 0 Then
                  Me.cmbListaDePrecios.SelectedIndex = 0
               End If
            End If
         End If

      End If


      If Me._clienteE.IdTransportista > 0 And Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
         Dim Transp As Reglas.Transportistas = New Reglas.Transportistas()
         Me._transportistaA = Transp.GetUno(Me._clienteE.IdTransportista)
         Me.bscTransportista.Text = Me._transportistaA.NombreTransportista
         Me.bscTransportista.Selecciono = True
      End If

      If Me.cmbTiposComprobantes.Items.Count > 0 AndAlso Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
            Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
         End If
      End If

      If Not _mantenerCaja Then
         If Me._clienteE.IdCaja > 0 Then
            Me.cmbCajas.SelectedValue = Me._clienteE.IdCaja
            If Me.cmbCajas.SelectedIndex = -1 And Me.cmbCajas.Items.Count > 0 Then
               Me.cmbCajas.SelectedIndex = 0
            End If
         End If
      End If

      Me.CambiarEstadoControlesDetalle(True)
      Me.CambiarEstadoControlesDetalleRT(True)

      'Se calcula el descuento/recargo gral del Cliente
      '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
      If Not Me.chbModificaDescRecGralPorc.Checked Then
         _cantLineas = _ventasProductos.Count
         Dim nuevoDescRecGralPorc As Decimal = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                                            cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                                            cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                                            _cantLineas)
         Dim actualizar As Boolean = False
         If IsNumeric(txtTarjetas.Text) AndAlso Convert.ToDecimal(txtTarjetas.Text) <> 0 Then
            If nuevoDescRecGralPorc <> _DescRecGralPorc Then
               actualizar = ShowPregunta(String.Format("¿Desea actualizar el D/R actual {0:N2}% por el nuevo D/R {1:N2}%?", _DescRecGralPorc, nuevoDescRecGralPorc)) = Windows.Forms.DialogResult.Yes
            Else
               actualizar = False
            End If
         Else
            actualizar = True
         End If
         If actualizar Then
            Me._DescRecGralPorc = nuevoDescRecGralPorc
            Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnTotales.ToString())
            _clienteTieneDescRec = _DescRecGralPorc <> 0
         End If
      End If

      'Me.cmbCategoriaFiscal.Enabled = False
      Me.CargarProximoNumero()

      Me.CargarSaldosCtaCte()
      Me.ValidarDiasDeVencimiento()

      'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
      Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)
      cmbCategoriaFiscal.Enabled = If(tipoComp IsNot Nothing, Not tipoComp.GrabaLibro, True)


      'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
      NavegacionDesdeClienteSegunParametros()


      'Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
      'Habria que hacerlo mas general!
      'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal And String.IsNullOrEmpty(Me._clienteE.Cuit) Then
      '   MessageBox.Show("El Cliente NO tiene CUIT y es obligatorio para este comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   'Me.cmbTiposComprobantes.SelectedIndex = -1
      '   'Me.cmbTiposComprobantes.Focus()
      '   Me.Nuevo()
      '   Exit Sub
      'End If

      'controlo CUIT segun categoria fiscal (Factura Electronica y Fiscales rebota seguro).
      If tipoComp IsNot Nothing AndAlso Me._clienteE.CategoriaFiscal.SolicitaCUIT AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit.ToString()) AndAlso
         (tipoComp.GrabaLibro Or tipoComp.EsPreElectronico) Then

         MessageBox.Show("ATENCION: El Cliente NO tiene CUIT y es obligatorio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

         If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
            Me.Nuevo(False, False)
         End If
      End If

      If _clienteE.IdClienteCtaCte > 0 And Not bscCodigoClienteVinculado.Selecciono And Not bscClienteVinculado.Selecciono Then
         bscCodigoClienteVinculado.Permitido = True
         bscCodigoClienteVinculado.Text = New Reglas.Clientes().GetUno(_clienteE.IdClienteCtaCte).CodigoCliente.ToString()
         bscCodigoClienteVinculado.PresionarBoton()
         bscCodigoClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado
      End If

      _publicos.CargaComboClientesContactos(cmbContacto, Long.Parse(dr.Cells("IdCliente").Value.ToString()), True)

      ' Aplico la lógica del Desc/Rec por Cantidad de Lineas
      _cantLineas = _ventasProductos.Count
      _DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                            cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                            cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                            _cantLineas)

      CargaTipoComprobanteProducto()

      If _clienteE.EsClienteGenerico Then
         bscCliente.Visible = False
         txtNombreClienteGenerico.Visible = True
         If _clienteE.CategoriaFiscal.SolicitaCUIT Then
            txtCUIT.ReadOnly = False
         Else
            txtCUIT.Visible = False
            txtNroDocCliente.Visible = True
            cmbTipoDoc.Enabled = True
            txtNroDocCliente.ReadOnly = False
            cmbTipoDoc.Visible = True
            cmbTipoDoc.Text = Reglas.Publicos.TipoDocumentoCliente
            lblTipoDocumento.Visible = True
         End If
         txtCUIT.ReadOnly = False
         cmbDirecciones.Visible = False
         cmbDirecciones.Text = Me.cmbDirecciones.Text
         txtDireccionClienteGenerico.Visible = True
         txtDireccionClienteGenerico.Text = dr.Cells("Direccion").Value.ToString()
         bscCodigoLocalidad.Visible = True
         bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
         txtNombreClienteGenerico.Text = dr.Cells("NombreCliente").Value.ToString()
         txtNombreClienteGenerico.Focus()
         '  cmbCategoriaFiscal.Visible = True
         '  cmbCategoriaFiscal.SelectedValue = Me._Proveedor.CategoriaFiscal.IdCategoriaFiscal
         '  txtCategoriaFiscal.Visible = False
      Else
         txtNombreClienteGenerico.Visible = False
         bscCliente.Visible = True
         txtCUIT.ReadOnly = True
         txtNroDocCliente.ReadOnly = True
         cmbTipoDoc.Enabled = False
         cmbDirecciones.Visible = True
         txtDireccionClienteGenerico.Visible = False
         bscCodigoLocalidad.Visible = False
      End If

      _ultimaCategoriaFiscalSeleccionada = _clienteE.CategoriaFiscal

      Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

      If _clienteE IsNot Nothing AndAlso _clienteE.VarPesosCotizDolar <> 0 Then
         Me.txtCotizacionDolar.Text = (Decimal.Parse(Me.txtCotizacionDolar.Text()) + Decimal.Parse(_clienteE.VarPesosCotizDolar.ToString())).ToString("N2")
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
         If Reglas.Publicos.Facturacion.FacturacionSaldoCtaCteIncluyeCh3ros Then
            Me.txtSaldoCtaCte.Text = (Decimal.Parse(dt.Rows(0)("Saldo").ToString()) + Decimal.Parse("0" & dt.Rows(0)("IMPORTE2").ToString())).ToString("N2")
         Else
            Me.txtSaldoCtaCte.Text = Decimal.Parse(dt.Rows(0)("Saldo").ToString()).ToString("N2")
         End If
         If Not String.IsNullOrEmpty(dt.Rows(0)("SaldoVencido").ToString()) Then
            Me.txtSaldoCtaCteVencido.Text = (Decimal.Parse(dt.Rows(0)("SaldoVencido").ToString())).ToString("N2")
         End If
      End If

      'If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
      '   If Decimal.Parse(Me.txtSaldoCtaCte.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
      '      If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
      '         Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
      '      End If
      '   End If
      'End If
      If Decimal.Parse(txtLimiteDeCredito.Text) > 0 AndAlso cmbFormaPago.SelectedIndex > -1 AndAlso
         DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 AndAlso cmbTiposComprobantes.SelectedIndex > -1 AndAlso
         DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ActualizaCtaCte AndAlso
         DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores > 0 Then

         ValidarLimiteCredito(arrojarException:=True)

      End If

      '# Color de semáforo SALDOS
      Me.SetearColorSemaforos(Me.txtSaldoCtaCte, Entidades.SemaforoVentaUtilidad.TiposSemaforos.SALDOS)

   End Sub

   Private Sub CargarDatosTransportista(dr As DataGridViewRow)
      Me.bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
      'Me.txtDireccionTransportista.Text = dr.Cells("DireccionTransportista").Value.ToString()

      'Me.txtLocalidadTransportista.Text = dr.Cells("NombreLocalidad").Value.ToString()
      'Me.txtTelefoTransportista.Text = dr.Cells("TelefonoTransportista").Value.ToString()

      Dim Transp As Reglas.Transportistas = New Reglas.Transportistas()
      Me._transportistaA = Transp.GetUno(Long.Parse(dr.Cells("IdTransportista").Value.ToString()))
   End Sub

   Private _enNuevo As Boolean
   Private Sub Nuevo(MantieneElCliente As Boolean, MantieneElComprobante As Boolean)

      _enNuevo = True

      Try
         Me.tsbGrabar.Enabled = False
         Me._estado = Estados.Insercion
         'Me.Text = "Facturación"
         Me.cmbTiposComprobantes.Enabled = True
         Me.cmbVendedor.Enabled = Not _mantenerVendedor
         cmbCajas.Enabled = Not _mantenerCaja

         Me.cmbFormaPago.Enabled = True
         Me.txtTotalGeneral.Enabled = True
         Me.txtDescRecGral.Enabled = True

         If Me.cmbTiposComprobantes.SelectedIndex > -1 AndAlso
            DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpRemitoTransp") '# Tab Remito Transp
         Else
            Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
         End If

         Me.tbcDetalle.Enabled = True

         If Not MantieneElCliente Then
            Me.bscCodigoCliente.Text = String.Empty
            Me.bscCodigoCliente.Selecciono = False

            bscCliente.ReseteaPermitidoNoBackColor()
            bscCodigoCliente.ReseteaPermitidoNoBackColor()
            bscCliente.ReseteaPermitidoSiBackColor()
            bscCodigoCliente.ReseteaPermitidoSiBackColor()

            Me.bscCliente.Text = String.Empty
            Me.bscCliente.Selecciono = False
            Me.bscDireccion.Text = String.Empty
            Me.bscDireccion.Selecciono = False
            Me.bscDireccion.Permitido = True
            Me.bscCliente.Permitido = True
            Me.bscCodigoCliente.Permitido = True
            Me._clienteE = Nothing

            Me.bscClienteVinculado.Text = String.Empty
            Me.bscClienteVinculado.Selecciono = False
            Me.bscClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado
            Me.bscCodigoClienteVinculado.Text = String.Empty
            Me.bscCodigoClienteVinculado.Selecciono = False
            Me.bscCodigoClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado

         ElseIf _facturacionMantieneElClienteDefault > 0 Then
            bscCodigoCliente.Text = _facturacionMantieneElClienteDefault.ToString()
         End If



         Me.txtCategoria.Text = String.Empty
         Me.txtCorreoElectronico.Text = String.Empty
         Me.txtCUIT.Text = String.Empty
         Me.txtCUIT.Visible = True
         Me.lblCUIT.Text = My.Resources.RTextos.Cuit

         txtReferenciaComercial.Text = String.Empty
         cmbAFIPWSCodigoAnulacion.SelectedIndex = -1

         'Me.dtpFecha.Enabled = True
         Me.bscObservacion.Text = String.Empty
         Me._ventasProductos.Clear()

         '-- REQ-35220.- ----------------------------------------
         _tit.Remove("DescripcionAtributo01")
         _tit.Remove("DescripcionAtributo02")
         _tit.Remove("DescripcionAtributo03")
         _tit.Remove("DescripcionAtributo04")
         '-------------------------------------------------------

         SetProductosDataSource()

         _transferencias = New List(Of Entidades.VentaTransferencia)()
         ugTransferenciasMultiples.DataSource = _transferencias

         _ventasContactos.Clear()
         ugContactos.DataSource = _ventasContactos
         AjustarColumnasGrilla(ugContactos, _titContactos)

         _productosLotes.Clear()
         _subTotales.Clear()
         dgvIvas.DataSource = Me._subTotales.ToArray()

         dgvRemitoTransp.DataSource = Me._ventasProductos.ToArray()
         AjustarColumnasGrilla(dgvRemitoTransp, _titRemitoTransporte)

         _ventasDespachos.Clear()
         dgvEmbarqueDespacho.DataSource = Me._ventasDespachos.ToArray()

         cmbClausulaVentas.SelectedIndex = -1
         cmbDestinoDespacho.SelectedIndex = -1
         cmbDestinoComprobante.SelectedIndex = -1
         dtpFechaPagoExportacion.Value = Today
         dtpFechaPagoExportacion.Checked = False

         txtTelefonos.Text = String.Empty
         txtLimiteDeCredito.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtLimiteDiasVto.Text = (0).ToString()

         txtSaldoCtaCteVencido.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         'Me.txtBruto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
         txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         _clienteTieneDescRec = False
         txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         'Me.txtDireccionYLocalidad.Text = String.Empty
         dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
         dtpFechaTransferencia.Value = Me.dtpFecha.Value.Date
         txtTotalGeneral.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtKilos.Text = "0." + New String("0"c, Me._decimalesEnKilos)
         txtCantidadProductos.Text = "0"
         '----
         bscCodigoProducto2.Text = String.Empty
         bscProducto2.Text = String.Empty
         txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
         txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
         txtStock.Text = String.Empty
         txtStock.Tag = False
         txtCantidad.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
         txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto)
         txtTamanio.Text = "0." + New String("0"c, Me._decimalesEnTamanio)
         txtUM.Text = ""
         btnInsertar.Enabled = True
         btnEliminar.Enabled = True
         txtCantidadManual.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
         If Me.cmbUM2.Items.Count > 0 Then
            Me.cmbUM2.DataSource = Nothing
            Me.cmbUM2.Items.Clear()
         End If
         '----
         bscCodigoProducto2RT.Text = String.Empty
         bscProducto2RT.Text = String.Empty
         txtStockRT.Text = String.Empty
         txtStockRT.Tag = False
         txtCantidadRT.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
         txtCantidadManualRT.Text = Me.txtCantidadRT.Text
         txtTamanioRT.Text = "0." + New String("0"c, Me._decimalesEnTamanio)
         txtUMRT.Text = ""
         btnInsertarRT.Enabled = True
         btnEliminarRT.Enabled = True
         '----

         txtTickets.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtEfectivo.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtImporteDolares.SetValor(0D)
         txtTarjetas.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtCheques.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtTransferenciaBancaria.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtTotalBruto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtTotalNeto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtTotalSubtotales.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtTotalImpuestos.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtPercepcionIVA.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtPercepcionIIBB.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtPercepcionGanancias.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtPercepcionVarias.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtTotalRetenciones.Text = "0." + New String("0"c, Me._decimalesEnTotales)

         txtCosto.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
         txtCosto.Tag = Nothing

         FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
         'If cmbTiposComprobantes.SelectedItem IsNot Nothing AndAlso DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Then
         '   'si la letra es X se la seteo directamente
         '   txtLetra.Text = "X"
         'Else
         '   txtLetra.Text = String.Empty
         'End If

         bscCuentaBancariaTransfBanc.Text = String.Empty

         If Not MantieneElComprobante Then
            If cmbTiposComprobantes.Items.Count > 0 Then
               cmbTiposComprobantes.SelectedIndex = -1   'Fuerzo el evento de Changed
               cmbTiposComprobantes.SelectedIndex = 0
            Else
               cmbTiposComprobantes.SelectedIndex = -1
            End If
         End If

         If _invocadosCajero IsNot Nothing Then
            Dim tpIdx As Integer = cmbTiposComprobantes.SelectedIndex
            cmbTiposComprobantes.SelectedValue = Reglas.Publicos.TipoComprobanteGeneradoCajero
            If cmbTiposComprobantes.SelectedValue Is Nothing Then
               cmbTiposComprobantes.SelectedIndex = tpIdx
            End If
         End If

         If Not _mantenerVendedor Then
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
         End If
         If cmbVendedor.Items.Count = 1 Then
            cmbVendedor.SelectedIndex = 0
         End If
         If Me.cmbFormaPago.Items.Count > 0 Then
            Me.cmbFormaPago.SelectedIndex = 0
         Else
            Me.cmbFormaPago.SelectedIndex = -1
         End If

         chbAplicarSaldoCtaCte.Checked = Reglas.Publicos.Facturacion.FacturacionPermiteAplicarSaldoCtaCte

         Me.cmbListaDePrecios.SelectedIndex = 0
         '-- Guarda Valor en el Tag.---
         cmbListaDePrecios.Tag = 0

         Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
         _clienteTieneDescRec = False
         Me.txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesEnTotales)

         cmbCategoriaFiscal.Enabled = True
         cmbCategoriaFiscal.SelectedIndex = -1

         chbNumeroAutomatico.Checked = True
         chbNumeroAutomatico.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante

         CambiarEstadoControlesDetalle(False)
         CambiarEstadoControlesDetalleRT(False)

         _ModificaDetalle = "TODO"
         _ModificaDetalleRT = "TODO"

         txtCotizacionDolar.Enabled = _puedeEditarDolar

         If tbcDetalle.Tabs("tbpFacturables").Visible Then
            tbcDetalle.Tabs("tbpFacturables").Visible = False
         End If

         If tbcDetalle.Tabs("tbpExportacion").Visible Then
            tbcDetalle.Tabs("tbpExportacion").Visible = False
         End If

         FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
         'txtLetra.Text = ""

         'If Me._comprobantesSeleccionados IsNot Nothing Then
         '   Me._comprobantesSeleccionados.Clear()
         'End If
         _comprobantesSeleccionados = Nothing
         _comprobantesSeleccionados = New List(Of Entidades.Venta)

         dgvFacturables.DataSource = Me._comprobantesSeleccionados

         txtTotalPago.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtDiferencia.Text = "0." + New String("0"c, Me._decimalesEnTotales)

         _cheques.Clear()
         dgvCheques.DataSource = Me._cheques
         AjustarColumnasGrilla(dgvCheques, _titCheques)
         LimpiarCamposCheques()

         btnInsertarTarjeta.Enabled = True
         _tarjetas.Clear()
         dgvTarjetas.DataSource = Me._tarjetas.ToArray()

         LimpiarCamposTarjetas()
         txtBultos.Text = String.Empty
         txtValorDeclarado.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         _transportistaA = Nothing
         bscTransportista.Text = String.Empty
         txtNumeroLote.Text = String.Empty

         _ventasObservaciones.Clear()
         _ventasObservacionesCHTarjeta.Clear()

         SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())

         _numeroOrden = 0
         _DescRecGralPorc = 0

         CargarProximoNumero()

         txtSemaforoRentabilidad.BackColor = Me.txtLetra.BackColor
         txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
         txtSemaforoRentabilidad.Text = ""
         txtSemaforoRentabilidad.Key = "0"

         txtSemaforoRentabilidadDetalle.Text = ""

         txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         txtSaldoCtaCte.BackColor = Me.txtLetra.BackColor
         txtSaldoCtaCte.ForeColor = Me.txtLetra.ForeColor
         txtSaldoCtaCte.Font = New Font(Me.txtSaldoCtaCte.Font, FontStyle.Regular)

         cmbMonedaVenta.SelectedValue = Reglas.Publicos.Facturacion.FacturacionMonedaPorDefecto

         ' # Cotización Dolar - Cantidad de decimales y lenght máximo del campo
         Dim dolarFormato As String = String.Format("N{0}", Reglas.Publicos.Facturacion.FacturacionCantidadDecimalesEnCotizacionDolar.ToString())

         Dim cantEnteros As Integer = Integer.Parse(Reglas.Publicos.Facturacion.FacturacionCantidadEnterosEnCotizacionDolar.ToString())
         Dim cantDecimales As Integer = Integer.Parse(Reglas.Publicos.Facturacion.FacturacionCantidadDecimalesEnCotizacionDolar.ToString())

         txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString(dolarFormato)
         txtCotizacionDolar.Formato = dolarFormato
         txtCotizacionDolar.MaxLength = cantEnteros + cantDecimales + 1 'Cantidad de Enteros + Cantidad de Decimales + 1 (El lugar que ocupa el .)
         '------------------------------------------------------------------------

         chbModificaPrecio.Checked = Reglas.Publicos.Facturacion.FacturacionModificaPrecioProducto
         chbModificaDescRecargo.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescRecProducto

         '# El Desc/Rec siempre va a venir en FALSE ya que cuando esté tildado quiere decir que el usuario aplicó un Desc/Rec Manualmente
         chbModificaDescRecGralPorc.Checked = False

         _publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         cmbCajas.SelectedIndex = 0

         If Reglas.Publicos.Facturacion.FacturacionSolicitaCajaAlAbrir And _CajaAlAbrir <> 0 Then
            cmbCajas.SelectedValue = _CajaAlAbrir
         End If

         cmbActividades.Visible = False
         lblActividades.Visible = False
         cmbActividades.DataSource = Nothing

         'Me.lblNombreProveedorPorCtaOrden.Visible = bscProveedor.Visible
         chbEsCtaOrden.Enabled = Reglas.Publicos.Facturacion.FactPorCtaOrden

         txtReferenciaCtaCte.Visible = Not bscProveedor.Visible And Entidades.Usuario.Actual.Sistema = "SiCAP"
         lblReferenciaCtaCte.Visible = txtReferenciaCtaCte.Visible

         bscCodigoProveedor.Text = ""
         bscCodigoProveedor.Tag = Nothing
         bscProveedor.Text = ""
         cmbDirecciones.Enabled = False
         cmbDirecciones.SelectedIndex = -1

         lblKilosModDesc.Visible = False
         txtKilosModDesc.Text = "0." + New String("0"c, Me._decimalesEnKilos)
         txtKilosModDesc.Visible = False
         _InvocaPedido = False

         If Not MantieneElCliente Then
            bscCodigoCliente.Focus()
            bscCliente.Visible = True
            txtNombreClienteGenerico.Visible = False
            txtNombreClienteGenerico.Text = ""
            txtNroDocCliente.Text = ""
            txtCUIT.ReadOnly = True
            cmbTipoDoc.Visible = False
            txtNroDocCliente.Visible = False
            lblTipoDocumento.Visible = False
            cmbDirecciones.Visible = True
            txtDireccionClienteGenerico.Visible = False
            bscCodigoLocalidad.Visible = False
            txtDireccionClienteGenerico.Text = ""
            bscCodigoLocalidad.Text = ""
         Else
            'Para que se ejecuto el evento
            bscCodigoCliente.Permitido = True
            bscCodigoCliente.PresionarBoton()

            'Me.bscCodigoCliente.Permitido = False
         End If

         '# Historia Clínica Star Medical
         If Reglas.Publicos.FacturacionMuestraHistoriaClinica Then
            Me.chbFechaCirugia.Checked = False
            Me.dtpFechaCirugia.Value = UltimoSegundoDelDia(Date.Today.AddDays(-1)).AddSeconds(1)
            Me.LimpiarPaciente()
            Me.LimpiarDoctor()
         Else
            Me.gbHistoriaClinica.Visible = False
         End If
         '------------------------------

         LimpiarCamposObservDetalles()

         tsbInvocarCompras.Visible = False
         If cmbTiposComprobantes.SelectedIndex > -1 Then
            tsbInvocarCompras.Visible = DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).InvocaCompras
         End If

         If Reglas.Publicos.VisualizaNrosSerie Then
            Me.dgvProductos.Columns("NrosSerie").Visible = True
            Me.dgvRemitoTransp.Columns("NrosSerieRT").Visible = True
         End If

         '-- REQ-44219.- -----------------------------------------------------------
         Me.dgvProductos.Columns("NombreDeposito").Visible = Reglas.Publicos.FacturacionVisualizaDeposito
         Me.dgvProductos.Columns("NombreUbicacion").Visible = Reglas.Publicos.FacturacionVisualizaUbicacion

         '-- REQ-33524.- -----------------------------------------------------------
         cmbBusquedaDomicilio.Text = Reglas.Publicos.BusquedaClienteFacturacion
         cmbBusquedaDomicilio.Enabled = True
         bscDireccion.Text = ""
         '--------------------------------------------------------------------------
         '-- REQ-33532.- -----------------------------------------------------------
         chbTransportista.Checked = False
         bscCodigoTransportista.Text = String.Empty
         bscCodigoTransportista.Enabled = chbTransportista.Checked
         bscNombreTransportista.Text = String.Empty
         bscNombreTransportista.Enabled = chbTransportista.Checked
         pnlChoferesVehiculo.Visible = chbTransportista.Checked
         bscCodigoChofer.Text = String.Empty
         bscNombreChofer.Text = String.Empty
         bscCodigoVehiculo.Text = String.Empty
         txtMarcaVehiculo.Text = String.Empty
         txtModeloVehiculo.Text = String.Empty
         '--------------------------------------------------------------------------
         cmbDepositoOrigen.Enabled = True
         cmbUbicacionOrigen.Enabled = True
         '--------------------------------------------------------------------------
         chbAFIPConceptoCM05.Checked = False
         If Not Reglas.Publicos.AFIPUtilizaCM05 Then
            chbAFIPConceptoCM05.Enabled = False
         End If

         CalculosDescuentosRecargos1.HabilitaDescuentoRecargoProducto = True
         _idCama = 0
         _idEmbarcacion = 0

         _transferencias.Clear()
         ugTransferenciasMultiples.Rows.Refresh(RefreshRow.ReloadData)
         txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
         bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()

      Finally
         _enNuevo = False

      End Try

   End Sub

   Private Sub NuevoSecundario(ComprobantePrimario As Entidades.Venta)

      Me._estado = Estados.Insercion
      'Me.Text = "Facturación"

      Me.tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpProductos")
      Me.tbcDetalle.Enabled = True

      Me.txtEfectivo.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtImporteDolares.SetValor(0D)
      Me.txtTickets.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTarjetas.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtCheques.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me._cheques.Clear()
      Me.dgvCheques.DataSource = Me._cheques
      Me.LimpiarCamposCheques()

      'Me.txtLetra.Text = String.Empty

      Dim importaObservDeInvocados As Boolean = ComprobantePrimario.TipoComprobante.ImportaObservDeInvocados

      Me.cmbTiposComprobantes.SelectedValue = ComprobantePrimario.TipoComprobante.IdTipoComprobanteSecundario

      If Me.cmbFormaPago.Items.Count > 0 Then
         Me.cmbFormaPago.SelectedIndex = 0
      Else
         Me.cmbFormaPago.SelectedIndex = -1
      End If

      Me._ModificaDetalle = "TODO"
      Me._ModificaDetalleRT = "TODO"

      txtCotizacionDolar.Enabled = _puedeEditarDolar

      Me._ventasObservacionesCHTarjeta.Clear()

      If Not importaObservDeInvocados Then
         Me._ventasObservaciones.Clear()
      End If

      SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())

      Me._comprobantesSeleccionados = Nothing
      Me._comprobantesSeleccionados = New List(Of Entidades.Venta)
      Me._comprobantesSeleccionados.Add(ComprobantePrimario)
      'Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados

      Me.CargarComprobantesFacturables(Me._comprobantesSeleccionados)
      Me.CargarProductosFacturables(Me._comprobantesSeleccionados)
      CargarContactosFacturables(_comprobantesSeleccionados)

      'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
      '   Me.CargarObservacionesFacturables(Me._comprobantesSeleccionados)
      'End If

      Me.LimpiarCamposProductos()
      Me.CalcularTotales()
      Me.CalcularDatosDetalle()
      'Me.CalcularTotales()

      If Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
         Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         _clienteTieneDescRec = False
         Me.CalcularTotalRemitoTransporte()

         If Me._clienteE.IdTransportista > 0 Then
            Dim Transp As Reglas.Transportistas = New Reglas.Transportistas()
            Me._transportistaA = Transp.GetUno(Me._clienteE.IdTransportista)
            Me.bscTransportista.Text = Me._transportistaA.NombreTransportista
            Me.bscTransportista.Selecciono = True
         End If
      Else
         Me.txtBultos.Text = String.Empty
         Me.txtValorDeclarado.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         Me._transportistaA = Nothing
         Me.bscTransportista.Text = String.Empty
      End If

      If Not Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
         Me.tbcDetalle.Tabs("tbpFacturables").Visible = True
      End If

      If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
         Me.CambiarEstadoControlesDetalle(False)
         Me.CambiarEstadoControlesDetalleRT(False)
         Me._ModificaDetalle = "SOLOPRECIOS"
         Me._ModificaDetalleRT = "NO"
      ElseIf Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "NO" Then ' AndAlso
         'Me.tbcDetalle.Tabs(Me.tbpRemitoTransp) Then
         Me.CambiarEstadoControlesDetalle(False)
         Me.CambiarEstadoControlesDetalleRT(False)
         Me._ModificaDetalle = "NO"
         Me._ModificaDetalleRT = "NO"
         txtCotizacionDolar.Enabled = False
      End If

      Me.txtTotalPago.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      'Me.txtDiferencia.Text = "0." + New String("0"c, Me._decimalesAMostrar)

      'Me.txtBultos.Text = String.Empty
      'Me.txtValorDeclarado.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      'Me._transportistaA = Nothing
      'Me.bscTransportista.Text = String.Empty
      Me.txtNumeroLote.Text = String.Empty

      LimpiarCamposObservDetalles()

      Me.CargarProximoNumero()

      Me.CargarSaldosCtaCte()
      Me.ValidarDiasDeVencimiento()

      Me.tsbGrabar.Enabled = True

      Me.bscCodigoCliente.Focus()

      _SeleccionoInvocados = Entidades.Publicos.SiNoTodos.NO

      'TODO: analizar si es convieniente o no.
      'Me._productosLotes.Clear()

      '---------------------------------------

   End Sub

   Private Function ValidarInsertaProducto() As Boolean

      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar un tipo de comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If txtCosto.ReadOnly = False And Decimal.Parse(txtCosto.Text) = 0 Then
         MessageBox.Show("El Valor del Costo debe ser mayor a Cero", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         txtCosto.Focus()
         Return False
      End If

      If Me.cmbFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar una Forma de Pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbFormaPago.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
         DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
         Dim dt As DataTable = oPF.Get1(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
         If dt.Rows.Count = 0 Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not Boolean.Parse(dt.Rows(0)("VentasHabilitadas").ToString()) Then
            ShowMessage(String.Format("El Período Fiscal '{0}' no está habilitado para emitir Comprobantes de Venta.", dtpFecha.Value.ToString("yyyy/MM")))
            Me.dtpFecha.Focus()
            Return False
         End If
      End If

      Dim CategoriaFiscalCliente As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      Dim CUIT As String = String.Empty

      If Me._clienteE.EsClienteGenerico Then
         CategoriaFiscalCliente = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
         CUIT = txtCUIT.Text.ToString()
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


      If _ventasProductos.Count = 0 Then
         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante) IsNot Nothing Then
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja And DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
               Dim oCaja As Reglas.CajasNombres = New Reglas.CajasNombres()
               Dim caja As Entidades.CajaNombre = New Entidades.CajaNombre()
               Dim oCajas As Reglas.Cajas = New Reglas.Cajas()
               Dim saldoCaja As Decimal

               Dim oPlanilla As Entidades.Caja = oCajas.GetPlanillaActual(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()))
               saldoCaja = oCajas.GetSaldoPesosFinal(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), oPlanilla.NumeroPlanilla) + oCajas.GetSaldoChequesFinal(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), oPlanilla.NumeroPlanilla)
               Dim totalCaja = saldoCaja + txtEfectivo.ValorNumericoPorDefecto(0D) + txtCheques.ValorNumericoPorDefecto(0D) +
                               (txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D))
               caja = oCaja.GetUna(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()))

               If caja.TopeAviso > 0 And totalCaja >= caja.TopeAviso And totalCaja < caja.TopeBloqueo Then
                  MessageBox.Show("Superó el Limite Recomendado de " & caja.TopeAviso.ToString("N2") & ", y está por llegar al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               ElseIf caja.TopeBloqueo > 0 And totalCaja >= caja.TopeBloqueo Then
                  MessageBox.Show("Llegó al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.txtKilosModDesc.Focus()
                  Return False
               End If
            End If
         End If
      End If


      'Esta Habilitado si permite Modificar la Descripcion.
      If Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible Then

         If Reglas.Publicos.Facturacion.FacturacionModificaDescripSolicitaKilos Then
            If Decimal.Parse("0" & Me.txtKilosModDesc.Text) = 0 Then
               MessageBox.Show("Debe Ingresar Kilos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Me.txtKilosModDesc.Focus()
               Return False
            End If
         End If

         If Me.bscCodigoProducto2.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Codigo de Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
               Me.bscProducto2.Focus()
            Else
               Me.bscCodigoProducto2.Focus()
            End If
            Return False
         End If
         If Me.bscProducto2.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscProducto2.Focus()
            Return False
         End If

         If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono And (Me.bscCodigoProducto2.Text.Trim.Length = 0 Or Me.bscProducto2.Text.Trim.Length = 0) Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscProducto2.Focus()
            Return False
         End If

         'Significa que escribo en ambos casos y no dio enter, tiene que al menos buscar.
         If bscCodigoProducto2.FilaDevuelta Is Nothing And bscProducto2.FilaDevuelta Is Nothing Then
            MessageBox.Show("No eligió un Producto, solo los digito, falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscProducto2.Focus()
            Return False
         End If

      Else
         If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscProducto2.Focus()
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

      If _clienteE.IdSucursalAsociada <> 0 AndAlso Not cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).EsRemitoTransportista Then
         'Se agrega esta validación porque consideramos que para operaciones entre empresas diferentes, donde hay que hacer facturas, el circuito debería ser otro.
         'Si se levanta la restricción evaluar que pasa con la compra que se debe registrar en la otra empresa.
         ShowMessage("Solo se pueden usar clientes/sucursales con Remitos de Transporte")
         Return False
      End If

      If _clienteE.IdSucursalAsociada <> 0 And
         cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).EsRemitoTransportista And
         cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).CoeficienteValores = -1 And
         prod.NroSerie Then
         'Se agrega esta validación porque cuando se desea registrar una NC de un producto con Nro de Serie de un cliente/sucursal (mueve entre sucursales)
         'el Nro de Serie que se desea mover está en la otra sucursal. No está disponible en esta, por lo que decidimos bloquearlo.
         ShowMessage(String.Format("No se pueden registrar {0} (CoeficienteValores = -1) con productos con Nro de Serie.", cmbTiposComprobantes.Text))
         Return False
      End If

      If Not prod.EsObservacion Then
         If Decimal.Parse(Me.txtPrecio.Text) <= 0 And Not Me._ventasConProductosEnCero Then
            MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            FocusPrecio()
            Return False
         End If

         If Me.txtCantidad.Text = "" Then
            MessageBox.Show("No puede ingresar sin cantidad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCantidadManual.Focus()
            Return False
         End If

         If Decimal.Parse(Me.txtCantidad.Text) = 0 Then
            MessageBox.Show("La cantidad debe ser distinta de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCantidadManual.Focus()
            Return False
         End If

         'En txtStock.Tag guardo propiedad "AfectaStock"
         If Decimal.Parse(Me.txtCantidad.Text) = 0 And Boolean.Parse(Me.txtStock.Tag.ToString()) Then
            MessageBox.Show("La cantidad debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCantidadManual.Focus()
            Return False
         End If

         If Decimal.Parse(Me.txtCantidad.Text) < 0 And Boolean.Parse(Me.txtStock.Tag.ToString()) And Not Reglas.Publicos.Facturacion.FacturacionPermiteCantidadNegativa Then
            MessageBox.Show("La cantidad debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCantidadManual.Focus()
            Return False
         End If

         If Me.dgvProductos.RowCount >= Me._cantMaxItems Then
            MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas de Productos para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & dgvProductos.RowCount.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnInsertar.Focus()
            Return False
         End If

         'Sumo Lineas del Comprobante + Lineas de Observaciones.
         If Me.dgvProductos.RowCount + Me.ugObservaciones.Rows.Count >= Me._cantMaxItems Then
            MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & (dgvProductos.RowCount + ugObservaciones.Rows.Count).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnInsertar.Focus()
            Return False
         End If
      Else
         If Decimal.Parse(Me.txtPrecio.Text) > 0 Then
            MessageBox.Show("El precio debe ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            FocusPrecio()
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
      End If         'If GetTipoOperacionSeleccionada() <> Entidades.Producto.TiposOperaciones.NORMAL Then

      'Los Cambios y las Bonificaciones no tienen importe, por lo que no se debe controlar que el Imp.Int.
      If GetTipoOperacionSeleccionada() = Entidades.Producto.TiposOperaciones.NORMAL Then
         'GAR: 27/02/2018. Agrego este control porque hubo casos en cero (hasta encontrar el origen).
         'Si es remito de transportista no graba nada de impuestos internos.
         If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
            If (prod.ImporteImpuestoInterno > 0 Or prod.PorcImpuestoInterno > 0) And Decimal.Parse(Me.txtImpuestoInterno.Text) = 0 Then
               MessageBox.Show("El Producto se cargo con Impuesto Interno en cero pero NO es correcto. Por favor vuelva a seleccionarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Me.txtImpuestoInterno.Focus()
               Return False
            End If
         End If            'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
      End If

      '----------------------------

      '*** Controlo la Facturacion Sin Stock ***

      Dim rStock As Reglas.Stock = New Reglas.Stock()
      Dim prodSinStock As Entidades.ProductosSinStock()
      prodSinStock = rStock.ControlarStockVenta(actual.Sucursal.Id, cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante), _ventasProductos, _comprobantesSeleccionados,
                                                idProductoInsertar:=bscCodigoProducto2.Text, cantidadInsertar:=If(IsNumeric(txtCantidad.Text), Decimal.Parse(txtCantidad.Text), 0))

      If prodSinStock.Count > 0 Then
         Dim stbMensaje As StringBuilder = New StringBuilder()
         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            stbMensaje.AppendLine("No es posible facturar el producto porque no hay stock suficiente.")
         ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
            stbMensaje.AppendLine("Va a facturar el producto aunque no tenga stock suficiente.")
         End If
         stbMensaje.AppendLine()

         For Each prodSS As Entidades.ProductosSinStock In prodSinStock
            stbMensaje.AppendFormatLine("    - {0} {1} - Cantidad: {2} - Stock: {3}", prodSS.Producto.IdProducto, prodSS.Producto.NombreProducto, prodSS.Cantidad, prodSS.Stock)
         Next

         ShowMessage(stbMensaje.ToString())

         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            Return False
         End If

      End If

      If _precioOriginal <> Decimal.Parse(Me.txtPrecio.Text) Then

         Dim stbMensaje As StringBuilder = New StringBuilder()
         Dim PorcentajePorDebajoPL As Decimal = 0
         Dim PrecioPermitidoPorDebajoPL As Decimal = 0
         Dim PorcentajePorArribaPL As Decimal = 0
         Dim PrecioPermitidoPorArribaPL As Decimal = 0
         Dim NoPermitir As Boolean = False

         'Precio menor al original
         If Decimal.Parse(Me.txtPrecio.Text) < _precioOriginal Then
            PorcentajePorDebajoPL = Reglas.Publicos.Facturacion.PorcentajePermitidoPorDebajoPrecioLista
            PrecioPermitidoPorDebajoPL = _precioOriginal - ((_precioOriginal * PorcentajePorDebajoPL) / 100)

            If Reglas.Publicos.Facturacion.ModificarPrecioPorDebajoPrecioLista = "NOPERMITIR" Then

               If PorcentajePorDebajoPL > 100 Then
                  stbMensaje.AppendLine("No es posible modificar el precio del Producto.")
                  NoPermitir = True
               ElseIf Decimal.Parse(Me.txtPrecio.Text) < PrecioPermitidoPorDebajoPL Then
                  stbMensaje.AppendLine("No es posible modificar el precio del Producto, esta por debajo del Precio Permitido.")
                  NoPermitir = True
               End If

            ElseIf Reglas.Publicos.Facturacion.ModificarPrecioPorDebajoPrecioLista = "AVISARYPERMITIR" Then

               If Decimal.Parse(Me.txtPrecio.Text) < PrecioPermitidoPorDebajoPL Then
                  stbMensaje.AppendLine("Va modificar el precio del Producto, esta por debajo del Precio Permitido.")
               End If

            End If

            stbMensaje.AppendLine()

            If Reglas.Publicos.Facturacion.ModificarPrecioPorDebajoPrecioLista <> "PERMITIR" AndAlso stbMensaje.Length > 2 Then

               stbMensaje.AppendFormatLine("    - {0} {1} - Precio Original: {2} - Precio modificado: {3} - Porcentaje Permitido: {4} %", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text,
                                           _precioOriginal, Me.txtPrecio.Text, PorcentajePorDebajoPL)

               ShowMessage(stbMensaje.ToString())
            End If


         Else
            'Precio mayor al original

            PorcentajePorArribaPL = Reglas.Publicos.Facturacion.PorcentajePermitidoPorArribaPrecioLista
            PrecioPermitidoPorArribaPL = _precioOriginal + ((_precioOriginal * PorcentajePorArribaPL) / 100)

            If Reglas.Publicos.Facturacion.ModificarPrecioPorArribaPrecioLista = "NOPERMITIR" Then

               If Decimal.Parse(Me.txtPrecio.Text) > PrecioPermitidoPorArribaPL Then
                  stbMensaje.AppendLine("No es posible modificar el precio del Producto, esta por arriba del Precio Permitido.")
                  NoPermitir = True
               End If

            ElseIf Reglas.Publicos.Facturacion.ModificarPrecioPorArribaPrecioLista = "AVISARYPERMITIR" Then

               If Decimal.Parse(Me.txtPrecio.Text) > PrecioPermitidoPorArribaPL Then
                  stbMensaje.AppendLine("Va modificar el precio del Producto, esta por arriba del Precio Permitido.")
               End If

            End If

            stbMensaje.AppendLine()

            If Reglas.Publicos.Facturacion.ModificarPrecioPorArribaPrecioLista <> "PERMITIR" AndAlso stbMensaje.Length > 2 Then

               stbMensaje.AppendFormatLine("    - {0} {1} - Precio Original: {2} - Precio modificado: {3} - Porcentaje Permitido: {4} %", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text,
                                           _precioOriginal, Me.txtPrecio.Text, PorcentajePorArribaPL)

               ShowMessage(stbMensaje.ToString())
            End If

         End If

         If NoPermitir Then
            Return False
         End If

      End If



      ' '' ''PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), ó invoco (no corresponde)
      ' '' ''los valores posibles para el coeficientestock son 0, 1 y -1

      '' ''Dim blnControlarStock As Boolean = False

      '' ''If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0 Or
      '' ''   (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 AndAlso Reglas.Publicos.Facturacion.FacturarSinStockControlaNoAfectaStock) Then

      '' ''   'Si NO facturo otros (ej: Factura sin Facturables).

      '' ''   If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 OrElse Me._comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = 0 Then
      '' ''      'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).

      '' ''      blnControlarStock = True

      '' ''   End If

      '' ''End If



      '' ''If blnControlarStock Then

      '' ''   'Validacion de Stock segun Parametro
      '' ''   Dim cantidadTotal As Decimal = 0
      '' ''   Dim ProductosCadena As String = ""
      '' ''   Dim producto As String
      '' ''   Dim ProdRepetido As DataTable = New DataTable()
      '' ''   ProdRepetido.Columns.Add("ProdRepetido", System.Type.GetType("System.String"))
      '' ''   ProdRepetido.Columns.Add("NombreProducto", System.Type.GetType("System.String"))
      '' ''   Dim dr2 As DataRow
      '' ''   Dim entro As Boolean = False
      '' ''   Dim entro2 As Boolean = False

      '' ''   'busco el compuesto y comparo todo los componentes con los que estan en VentasProductos
      '' ''   Dim _Componentes As DataTable
      '' ''   Dim oProductos As Reglas.Productos
      '' ''   Dim oProducto As Entidades.Producto
      '' ''   Dim ocomponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
      '' ''   Dim prodprodcomp As Entidades.ProduccionProductoComp

      '' ''   If Not prod.EsCompuesto Then


      '' ''      '1 Parte. Del Producto ingresado
      '' ''      If Decimal.Parse(Me.txtCantidad.Text) > Decimal.Parse(Me.txtStock.Text) And Boolean.Parse(Me.txtStock.Tag.ToString()) Then

      '' ''         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
      '' ''            MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''            Me.txtCantidadManual.Focus()
      '' ''            Return False

      '' ''         ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
      '' ''            MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''         End If

      '' ''      End If

      '' ''      '2 Parte. Del Producto ingreso mas lo que esta en la grilla.

      '' ''      If Boolean.Parse(Me.txtStock.Tag.ToString()) And Me.dgvProductos.RowCount <> 0 Then

      '' ''         Dim cantidadTotal1 As Decimal = Decimal.Parse(Me.txtCantidad.Text)
      '' ''         producto = prod.IdProducto

      '' ''         For Each pro1 As Entidades.VentaProducto In Me._ventasProductos

      '' ''            If entro2 Then
      '' ''               Exit For
      '' ''            End If

      '' ''            Dim produ3 As Entidades.Producto = New Reglas.Productos().GetUno(pro1.IdProducto, False)

      '' ''            If produ3.EsCompuesto Then
      '' ''               If produ3.DescontarStockComponentes Then
      '' ''                  Dim _componentes2 As DataTable
      '' ''                  _componentes2 = ocomponentes.GetComponentes(actual.Sucursal.IdSucursal, produ3.IdProducto, produ3.IdFormula, 0)
      '' ''                  For Each dr4 As DataRow In _componentes2.Rows
      '' ''                     If prod.IdProducto = dr4("IdProductoComponente").ToString() Then
      '' ''                        cantidadTotal1 = cantidadTotal1 + Decimal.Parse(dr4("Cantidad").ToString()) * pro1.Cantidad
      '' ''                     End If
      '' ''                  Next

      '' ''               End If

      '' ''            Else

      '' ''               'Sumo cantidades en productos repetidos para controlar stock
      '' ''               'For Each pro2 As Entidades.VentaProducto In Me._ventasProductos
      '' ''               If pro1.IdProducto = producto Then
      '' ''                  cantidadTotal1 = cantidadTotal1 + pro1.Cantidad
      '' ''               End If
      '' ''               'Next

      '' ''            End If

      '' ''         Next

      '' ''         'Controlo la cantidad total con el stock del producto
      '' ''         If cantidadTotal1 > Decimal.Parse(Me.txtStock.Text) And blnControlarStock Then
      '' ''            'chequeo que ya no se haya controlado
      '' ''            For Each rep As DataRow In ProdRepetido.Rows
      '' ''               If prod.IdProducto = rep("ProdRepetido").ToString() Then
      '' ''                  entro = True
      '' ''               End If
      '' ''            Next
      '' ''            If entro = True Then
      '' ''            Else
      '' ''               dr2 = ProdRepetido.NewRow()
      '' ''               dr2("ProdRepetido") = prod.IdProducto
      '' ''               dr2("NombreProducto") = prod.NombreProducto
      '' ''               ProdRepetido.Rows.Add(dr2)
      '' ''            End If

      '' ''         End If
      '' ''         entro = False
      '' ''         cantidadTotal = 0

      '' ''         For Each dr As DataRow In ProdRepetido.Rows
      '' ''            ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      '' ''            entro2 = True
      '' ''         Next

      '' ''      End If

      '' ''   Else

      '' ''      oProductos = New Reglas.Productos()
      '' ''      oProducto = New Entidades.Producto()


      '' ''      'Busco el producto Nuevamente aunque este en la Coleccion porque pudo ajustar alguna caracterisca luego de algun hipotetico mensaje anterior.
      '' ''      oProducto = oProductos.GetUno(prod.IdProducto)

      '' ''      prodprodcomp = New Entidades.ProduccionProductoComp()

      '' ''      If prod.DescontarStockComponentes Then

      '' ''         _Componentes = ocomponentes.GetComponentes(actual.Sucursal.IdSucursal, oProducto.IdProducto, oProducto.IdFormula, 0)


      '' ''         For Each dr1 As DataRow In _Componentes.Rows

      '' ''            If entro2 Then
      '' ''               Exit For
      '' ''            End If

      '' ''            cantidadTotal = Decimal.Parse(dr1("Cantidad").ToString()) * Decimal.Parse(Me.txtCantidad.Text.ToString())

      '' ''            Dim prodSuc As Entidades.ProductoSucursal = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.IdSucursal, dr1("IdProductoComponente").ToString())

      '' ''            'If Me._ventasProductos.Count = 0 Then
      '' ''            '   If cantidadTotal > prodSuc.Stock Then
      '' ''            '      ProductosCadena = ProductosCadena + " - " + dr1("NombreProducto").ToString()
      '' ''            '   End If
      '' ''            'End If

      '' ''            For Each pro As Entidades.VentaProducto In Me._ventasProductos


      '' ''               Dim produ3 As Entidades.Producto = New Reglas.Productos().GetUno(pro.IdProducto, False)

      '' ''               If produ3.EsCompuesto Then
      '' ''                  If produ3.DescontarStockComponentes Then
      '' ''                     Dim _componentes2 As DataTable
      '' ''                     _componentes2 = ocomponentes.GetComponentes(actual.Sucursal.IdSucursal, produ3.IdProducto, produ3.IdFormula, 0)
      '' ''                     For Each dr4 As DataRow In _componentes2.Rows
      '' ''                        If dr1("IdProducto").ToString() = dr4("IdProducto").ToString() Then
      '' ''                           cantidadTotal = cantidadTotal + Decimal.Parse(dr4("Cantidad").ToString()) * pro.Cantidad
      '' ''                        End If
      '' ''                     Next
      '' ''                  End If


      '' ''               Else
      '' ''                  producto = pro.IdProducto
      '' ''                  'Sumo cantidades en productos repetidos para controlar stock
      '' ''                  For Each pro1 As Entidades.VentaProducto In Me._ventasProductos
      '' ''                     If pro1.IdProducto = producto Then
      '' ''                        cantidadTotal = cantidadTotal + pro1.Cantidad
      '' ''                     End If
      '' ''                  Next

      '' ''               End If
      '' ''            Next


      '' ''            'Controlo la cantidad total con el stock del producto
      '' ''            If cantidadTotal > prodSuc.Stock And blnControlarStock Then
      '' ''               'chequeo que ya no se haya controlado
      '' ''               For Each rep As DataRow In ProdRepetido.Rows
      '' ''                  If dr1("IdProductoComponente").ToString() = rep("ProdRepetido").ToString() Then
      '' ''                     entro = True
      '' ''                  End If
      '' ''               Next
      '' ''               If entro = True Then
      '' ''               Else
      '' ''                  dr2 = ProdRepetido.NewRow()
      '' ''                  dr2("ProdRepetido") = dr1("IdProductoComponente").ToString()
      '' ''                  dr2("NombreProducto") = dr1("NombreProducto").ToString()
      '' ''                  ProdRepetido.Rows.Add(dr2)
      '' ''               End If

      '' ''            End If
      '' ''            entro = False
      '' ''            cantidadTotal = 0

      '' ''            For Each dr As DataRow In ProdRepetido.Rows
      '' ''               ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      '' ''               entro2 = True
      '' ''            Next

      '' ''            'If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" And ProductosCadena <> "" Then
      '' ''            '   MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock. " + ProductosCadena, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''            '   Return False

      '' ''            'ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" And ProductosCadena <> "" Then

      '' ''            '   MessageBox.Show("Va a Facturar el Producto " + ProductosCadena + " aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

      '' ''            'End If

      '' ''         Next



      '' ''      End If



      '' ''   End If

      '' ''   If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" And ProductosCadena <> "" Then
      '' ''      MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock. " + ProductosCadena, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''      Return False

      '' ''   ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" And ProductosCadena <> "" Then

      '' ''      MessageBox.Show("Va a Facturar el Producto " + ProductosCadena + " aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''   End If

      '' ''End If

      '-----------------------------------------

      ''controlo que no se repita el producto ingresado
      'Dim ent As Entidades.VentaProducto
      'For i As Integer = 0 To Me._ventasProductos.Count - 1
      '   ent = Me._ventasProductos(i)
      '   If ent.Producto = Me.bscCodigoProducto2.Text Then
      '      If MessageBox.Show("El producto ya esta ingresado en este comprobante. ¿Desea agregar la cantidad al mismo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
      '         Me.txtCantidad.Text = (Decimal.Parse(Me.txtCantidad.Text) + ent.Cantidad).ToString("N2")
      '         Me.CalcularTotalProducto()
      '         Me._ventasProductos.RemoveAt(i)
      '         Return True
      '      Else
      '         Return False
      '      End If
      '   End If
      'Next

      'Si esta habilitado aunque grabe Libro de Iva significa que tiene Multiples IVAs, chequeo que sea uno de los dos.
      If Me.cmbPorcentajeIva.Enabled And (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                                          DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico) Then
         Dim oProducto As Entidades.Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text.Trim())
         Dim alicuotaSeleccionada As Decimal = Decimal.Parse(Me.cmbPorcentajeIva.Text)
         If alicuotaSeleccionada <> oProducto.Alicuota AndAlso oProducto.Alicuota2.HasValue AndAlso alicuotaSeleccionada <> oProducto.Alicuota2.Value Then
            Dim stbMensaje As StringBuilder = New StringBuilder()
            stbMensaje.AppendFormat("Alicuota NO habilitada para este Producto, solo puede ingresar: {0}", oProducto.Alicuota)
            If oProducto.Alicuota2.HasValue Then
               stbMensaje.AppendFormat(" o {0}", oProducto.Alicuota2.Value)
            End If
            stbMensaje.Append(".")
            ShowMessage(stbMensaje.ToString())
            Me.cmbPorcentajeIva.Focus()
            Return False
         End If
      End If

      If _utilizaCentroCostos Then
         If cmbCentroCosto.SelectedIndex = -1 Then
            ShowMessage("Debe seleccionar un centro de costos.")
            Me.cmbCentroCosto.Focus()
            Return False
         End If
      End If


      Dim NroDocCliente As Long = 0

      If Me._clienteE.EsClienteGenerico Then
         CategoriaFiscalCliente = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
         CUIT = txtCUIT.Text.ToString()
         NroDocCliente = If(IsNumeric(txtNroDocCliente.Text), Long.Parse(Me.txtNroDocCliente.Text), 0)
      Else
         CategoriaFiscalCliente = Me._clienteE.CategoriaFiscal
         CUIT = Me._clienteE.Cuit
         NroDocCliente = Me._clienteE.NroDocCliente
      End If

      If Not CategoriaFiscalCliente.IvaDiscriminado And Not CategoriaFiscalCliente.SolicitaCUIT And CategoriaFiscalCliente.LetraFiscal <> "E" _
             And (Decimal.Parse(Me.txtTotalGeneral.Text.ToString()) + (Decimal.Parse(Me.txtCantidad.Text.ToString()) * Decimal.Parse(Me.txtPrecio.Text.ToString()))) >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF And NroDocCliente = 0 AndAlso
             DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ControlaTopeConsumidorFinal Then

         If Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal Or (Not Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal And (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
            DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico)) Then

            ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
         End If

      End If


      Return True

   End Function

   Private Function ValidarInsertaProductoRT() As Boolean

      'Esta Habilitado si permite Modificar la Descripcion.
      If Me.bscProducto2RT.Enabled Then

         If Me.bscCodigoProducto2RT.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Codigo de Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2RT.Focus()
            Return False
         End If
         If Me.bscProducto2RT.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscProducto2RT.Focus()
            Return False
         End If

         If Not Me.bscCodigoProducto2RT.Selecciono And Not Me.bscProducto2RT.Selecciono And (Me.bscCodigoProducto2RT.Text.Trim.Length = 0 Or Me.bscProducto2RT.Text.Trim.Length = 0) Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2RT.Focus()
            Return False
         End If

         'Significa que escribo en ambos casos y no dio enter, tiene que al menos buscar.
         If bscCodigoProducto2RT.FilaDevuelta Is Nothing And bscProducto2RT.FilaDevuelta Is Nothing Then
            MessageBox.Show("No eligió un Producto, solo los digito, falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2RT.Focus()
            Return False
         End If

      Else
         If Not Me.bscCodigoProducto2RT.Selecciono And Not Me.bscProducto2RT.Selecciono Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2RT.Focus()
            Return False
         End If
      End If

      If Me.txtCantidadRT.Text = "" Then
         MessageBox.Show("No puede ingresar sin cantidad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidadManualRT.Focus()
         Return False
      End If

      If Double.Parse(Me.txtCantidadRT.Text) < 0 And Boolean.Parse(Me.txtStockRT.Tag.ToString()) And Not Reglas.Publicos.Facturacion.FacturacionPermiteCantidadNegativa Then
         MessageBox.Show("No puede ingresar una cantidad negativa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidadManualRT.Focus()
         Return False
      End If

      If Double.Parse(Me.txtCantidadRT.Text) = 0 Then
         MessageBox.Show("La cantidad debe ser distinta de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidadManualRT.Focus()
         Return False
      End If

      If Me.dgvRemitoTransp.RowCount >= Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas de Productos para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & dgvRemitoTransp.RowCount.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarRT.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.
      If Me.dgvRemitoTransp.RowCount + Me.ugObservaciones.Rows.Count >= Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & (dgvRemitoTransp.RowCount + ugObservaciones.Rows.Count).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarRT.Focus()
         Return False
      End If

      '# En caso de que el comprobante solicite Fecha de Devolución
      Dim solicitaFechaDevolucion As Boolean = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).SolicitaFechaDevolucion
      If solicitaFechaDevolucion Then

         If Me.rbCantDiasFechaDevolucion.Checked AndAlso Not CInt(Me.txtCantDiasFechaDevolucion.Text) > 0 Then
            ShowMessage("ATENCIÓN: La Cant. de Días de la Fecha de Devolución debe ser mayor a 0.")
            Me.txtCantDiasFechaDevolucion.Focus()
            Return False
         End If

         If Me.rbFechaDevolucion.Checked AndAlso Not _modificoFechaDevolucion Then
            ShowMessage("ATENCIÓN: Debe seleccionar la Fecha de Devolución del producto.")
            Me.dtpFechaDevolucion.Focus()
            Return False
         End If

         If Me.rbFechaDevolucion.Checked AndAlso Me.dtpFechaDevolucion.Value <= Date.Now Then
            ShowMessage("ATENCIÓN: La Fecha de Devolución no puede ser menor o igual a HOY.")
            Me.dtpFechaDevolucion.Focus()
            Return False
         End If

      End If
      '*** Controlo la Facturacion Sin Stock ***

      'PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), ó invoco (no corresponde)
      'los valores posibles para el coeficientestock son 0, 1 y -1

      Dim blnControlarStock As Boolean = False

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0 Then

         'Si NO facturo otros (ej: Factura sin Facturables).

         If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 OrElse Me._comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = 0 Then
            'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).

            blnControlarStock = True

         End If

      End If

      '1 Parte. Del Producto ingresado
      If Decimal.Parse(Me.txtCantidadRT.Text) > Decimal.Parse(Me.txtStockRT.Text) And Boolean.Parse(Me.txtStockRT.Tag.ToString()) And blnControlarStock Then

         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCantidadManualRT.Focus()
            Return False

         ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
            MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      End If

      '2 Parte. Del Producto ingreso mas lo que esta en la grilla.

      If Boolean.Parse(Me.txtStockRT.Tag.ToString()) And blnControlarStock Then

         Dim cantidadTotal As Decimal = Decimal.Parse(Me.txtCantidadRT.Text)

         For Each pro1 As Entidades.VentaProducto In Me._ventasProductos
            If pro1.IdProducto = Me.bscCodigoProducto2RT.Text.Trim() Then
               cantidadTotal = cantidadTotal + pro1.Cantidad
            End If
         Next

         If cantidadTotal > Decimal.Parse(Me.txtStockRT.Text) Then

            If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
               MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return False

            ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
               MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

         End If

      End If

      '-----------------------------------------

      Return True

   End Function

   Private Function ValidarInsertaObservacion() As Boolean

      If Me.ugObservaciones.Rows.Count = Me._cantMaxItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = Integer.Parse(IIf(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista, Me.dgvRemitoTransp.RowCount, Me.dgvProductos.RowCount).ToString())

      If LineasDetalle + Me.ugObservaciones.Rows.Count >= Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & (LineasDetalle + Me.ugObservaciones.Rows.Count).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      Return True

   End Function

   Private _estoyCargandoElProducto As Boolean

   Private Sub CargarProducto(dr As DataGridViewRow)

      My.Application.Log.WriteEntry("Inicia CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Me._estoyCargandoElProducto = True

      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscCodigoProducto2.Enabled = False

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscProducto2.Enabled = False

      cmbTipoOperacion.Enabled = True
      '--------------------------------
      cmbDepositoOrigen.Enabled = True
      cmbDepositoOrigen.SelectedValue = Integer.Parse(dr.Cells("IdDepositoDefecto").Value.ToString.Trim())
      If cmbDepositoOrigen.SelectedIndex <> -1 Then
         cmbUbicacionOrigen.Enabled = True
         cmbUbicacionOrigen.SelectedValue = Integer.Parse(dr.Cells("IdUbicacionDefecto").Value.ToString.Trim())
      Else
         cmbDepositoOrigen.SelectedIndex = 0
      End If
      '--------------------------------
      'Me.bscProducto2.Enabled = Publicos.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
      txtProductoObservacion.Text = Me.bscProducto2.Text
      chbModificaPrecio.Checked = Reglas.Publicos.Facturacion.FacturacionModificaPrecioProducto
      If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()) Then
         txtProductoObservacion.Visible = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

         If Boolean.Parse(dr.Cells("EsObservacion").Value.ToString()) Then
            Me.txtProductoObservacion.MaxLength = Reglas.Publicos.CantidadCaracteresProductoObservacion
         Else
            Me.txtProductoObservacion.MaxLength = Integer.Parse(Me.bscProducto2.MaxLengh)
         End If

         If Not chbModificaPrecio.Checked AndAlso Reglas.Publicos.Facturacion.FacturacionModificaDescripSolicitaPrecio Then
            chbModificaPrecio.Checked = True
         End If
      End If

      txtRecargoVenta.Text = dr.ValorNumericoPorDefecto("RecargoVenta", 0D).ToString("N" + _decimalesAMostrarEnPrecio.ToString())

      Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      If Producto.ImporteImpuestoInterno <> 0 Then
         ShowMessage(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se podrá agregar el producto al Comprobante.", Producto.IdProducto, Producto.NombreProducto))
      End If

      _calculaPreciosSegunFormula = Producto.CalculaPreciosSegunFormula

      My.Application.Log.WriteEntry("1- CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      If _utilizaCentroCostos Then
         If Producto.CentroCosto Is Nothing Then
            If Not _cargarProductoCompleto And Not _cargaProductoDesdeInvocacion Then
               ShowMessage(String.Format("El producto '{0} - {1}' no tiene asignado Centro de Costos. Por favor verifique y vuelva a intentar.",
                                         Producto.IdProducto, Producto.NombreProducto))
            End If
         Else
            cmbCentroCosto.SelectedValue = Producto.IdCentroCosto.Value
         End If
         cmbCentroCosto.Enabled = _permiteCambiarCentroCostosVentas
      End If

      If GetTipoOperacionSeleccionada() <> Entidades.Producto.TiposOperaciones.NORMAL Then
         dr.Cells("PrecioVentaSinIVA").Value = 0
         dr.Cells("PrecioVentaConIVA").Value = 0
      End If

      Dim ultimaVentaDelProducto As DataTable = Nothing
      If _facturacionCoeficienteNegativoRecuperaPrecioUltimaVenta AndAlso GetTipoComprobanteSeleccionado().CoeficienteValores < 0 Then
         ultimaVentaDelProducto = New Reglas.VentasProductos().UltimaVentaDelProducto(_clienteE.IdCliente, Producto.IdProducto)
         If ultimaVentaDelProducto.Rows.Count > 0 Then
            dr.Cells("PrecioVentaSinIVA").Value = ultimaVentaDelProducto.Rows(0)("PrecioVentaSinIVA")
            dr.Cells("PrecioVentaConIVA").Value = ultimaVentaDelProducto.Rows(0)("PrecioVentaConIVA")
            txtDescRecPorc1.Text = ultimaVentaDelProducto.Rows(0)("DescuentoRecargoPorc").ToString()
            txtDescRecPorc2.Text = ultimaVentaDelProducto.Rows(0)("DescuentoRecargoPorc2").ToString()
            If Producto.Moneda.IdMoneda = 2 Then
               dr.Cells("PrecioVentaSinIVA").Value = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()) / Decimal.Parse(txtCotizacionDolar.Text)
               dr.Cells("PrecioVentaConIVA").Value = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()) / Decimal.Parse(txtCotizacionDolar.Text)
            End If
            _txtCantidad_prev = 1
            _modificoDescuentos = True
         End If
      End If

      Me.cmbPorcentajeIva.Text = dr.Cells("Alicuota").Value.ToString()
      Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
      '--------------------------------------------------------------------------------------------------------------------------------
      Dim PrecioPorEmbalaje As Boolean = Boolean.Parse(dr.Cells("PrecioPorEmbalaje").Value.ToString())

      Dim PrecioVentaSinIVA As Decimal = 0
      Dim PrecioVentaConIVA As Decimal = 0

      ''''Dim PrecioCostoSinIVA As Decimal
      ''''Dim PrecioCostoConIVA As Decimal
      ''''Dim PrecioCosto As Decimal

      My.Application.Log.WriteEntry("2- CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      ''''If Publicos.PreciosConIVA Then
      ''''   PrecioCostoConIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
      ''''   PrecioCostoSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioCostoConIVA, Producto.Alicuota,
      ''''                                                                            Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
      ''''Else
      ''''   PrecioCostoSinIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
      ''''   PrecioCostoConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioCostoSinIVA, Producto.Alicuota,
      ''''                                                                Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
      ''''End If

      PrecioVentaSinIVA = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString())
      PrecioVentaConIVA = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString())

      '----------------------------------------------------------------------------------------------------------------------------------

      If cmbFormaPago.SelectedIndex > -1 AndAlso DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).AplicanOfertas Then

         Dim oferta As Entidades.ProductoOferta = New Reglas.ProductosOfertas().GetOfertaVigente(dtpFecha.Value.Date, dr.Cells("IdProducto").Value.ToString.Trim(),
                                                                                       Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
         If oferta IsNot Nothing Then
            _nroOferta = oferta.IdOferta
            If Reglas.Publicos.PreciosConIVA Then
               PrecioVentaConIVA = oferta.PrecioOferta
               PrecioVentaSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(oferta.PrecioOferta, Producto.Alicuota,
                                                                                        Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
            Else
               PrecioVentaSinIVA = oferta.PrecioOferta
               PrecioVentaConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(oferta.PrecioOferta, Producto.Alicuota,
                                                                            Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
            End If
         End If
      End If
      '----------------------------------------------------------------------------------------------------------------------------------


      If PrecioPorEmbalaje Then
         PrecioVentaSinIVA = PrecioVentaSinIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
         PrecioVentaConIVA = PrecioVentaConIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
         ''''PrecioCostoSinIVA = PrecioCostoSinIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
         ''''PrecioCostoConIVA = PrecioCostoConIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
      End If

      'Si el producto pertenece a una Marca que tiene lista de Precios especifica.. vuelvo a tomar los precios.

      Dim dt As DataTable
      dt = New Reglas.ClientesMarcasListasDePrecios().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdMarca").Value.ToString()))

      My.Application.Log.WriteEntry("3- CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      If dt.Rows.Count = 1 Then

         Dim IdListaDePrecio As Integer
         IdListaDePrecio = Integer.Parse(dt.Rows(0)("IdListaPrecios").ToString())

         dt = Nothing
         dt = New Reglas.Productos().GetPorCodigo(Me.bscCodigoProducto2.Text, actual.Sucursal.Id, IdListaDePrecio, "VENTAS")

         PrecioVentaSinIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaSinIVA").ToString())
         PrecioVentaConIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaConIVA").ToString())

         ''''If Publicos.PreciosConIVA Then
         ''''   PrecioCostoConIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
         ''''   PrecioCostoSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioCostoConIVA, Producto.Alicuota,
         ''''                                                                            Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
         ''''Else
         ''''   PrecioCostoSinIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
         ''''   PrecioCostoConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioCostoSinIVA, Producto.Alicuota,
         ''''                                                                            Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
         ''''End If
      End If
      '----------------------------------------------------------------------------------------------------------------------------------

      'Precio de Venta, Opciones: ACTUAL o ULTIMO
      If Publicos.VentasPrecioVenta <> "ACTUAL" Then

         Dim CalculoVenta() As String = Publicos.VentasPrecioVenta.Split(";"c)

         Dim OtroPrecioVenta As Decimal = 0

         Select Case CalculoVenta(0).ToString()

            Case "ULTIMO"

               Dim oVP As Reglas.VentasProductos = New Reglas.VentasProductos()

               OtroPrecioVenta = oVP.GetUltimoDeProducto(actual.Sucursal.Id,
                                                         Me.cmbTiposComprobantes.SelectedValue.ToString(),
                                                         Me.bscCodigoProducto2.Text,
                                                         Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

            Case Else
               Throw New Exception("ATENCION: el sistema tiene configurado el Tipo de VENTA '" & CalculoVenta(0).ToString() & "' (incorrecto), verifíquelo en Parametros")

         End Select

         If OtroPrecioVenta <> 0 Then
            PrecioVentaSinIVA = OtroPrecioVenta
            PrecioVentaConIVA = Decimal.Round(PrecioVentaSinIVA * (1 + (Decimal.Parse(dr.Cells("Alicuota").Value.ToString()) / 100)), Me._decimalesRedondeoEnPrecio)
         End If

      End If
      '------------------------------------------

      ''''If Publicos.VentasPrecioCosto <> "ACTUAL" Then
      ''''   Dim splVentasCalculoCosto = Publicos.VentasPrecioCosto.Split(";"c)
      ''''   Dim otroPrecioCosto = 0D

      ''''   Select Case splVentasCalculoCosto(0).ToString()
      ''''      Case "PROMPOND"
      ''''         Dim oCP = New Reglas.ComprasProductos()
      ''''         otroPrecioCosto = oCP.GetCostoPromedioPonderado(actual.Sucursal.Id, bscCodigoProducto2.Text,
      ''''                                                         Date.Today.AddMonths(splVentasCalculoCosto(1).ValorNumericoPorDefecto(0I) * (-1)),
      ''''                                                         Date.Today.UltimoSegundoDelDia(),
      ''''                                                         _decimalesRedondeoEnPrecio)

      ''''      Case Else
      ''''         Throw New Exception(String.Format("ATENCION: el sistema tiene configurado el Tipo de COSTO '{0}' (incorrecto), verifíquelo en Parametros.",
      ''''                                           splVentasCalculoCosto(0).ToString()))
      ''''   End Select

      ''''   If otroPrecioCosto <> 0 Then
      ''''      PrecioCostoSinIVA = otroPrecioCosto
      ''''      PrecioCostoConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(otroPrecioCosto, Producto)
      ''''   End If
      ''''End If


      If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
         PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         ''''PrecioCostoSinIVA = Decimal.Round(PrecioCostoSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         '''''-- REQ-31541.- --
         ''''PrecioCostoConIVA = Decimal.Round(PrecioCostoConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      End If

      'Si leyo el Precio de la Etiqueta lo asigno.
      If Me._modalidad = Entidades.Producto.Modalidades.PRECIO And (PrecioVentaConIVA = 0 Or Publicos.ProductoCodigoBarraPrecioRespetaEtiqueta) Then
         PrecioVentaConIVA = Me.GetPrecioModalidadPrecio()
         PrecioVentaSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioVentaConIVA, Decimal.Parse(Me.cmbPorcentajeIva.Text),
                                                                                  Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
      End If
      If (Me._clienteE.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
         Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
         Not DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
         Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         Me.txtPrecio.Tag = Me.txtPrecio.Text
         ''''PrecioCosto = PrecioCostoSinIVA
      Else
         'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
         Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         Me.txtPrecio.Tag = Me.txtPrecio.Text
         '-- REQ-31736.- --
         'If Me._clienteE.CategoriaFiscal.IvaDiscriminado Then
         ''''PrecioCosto = PrecioCostoConIVA
         'Else
         '   PrecioCosto = PrecioCostoSinIVA
         'End If
      End If

      _modificoPrecioManualmente = False
      _precioOriginal = Decimal.Parse(Me.txtPrecio.Text)

      My.Application.Log.WriteEntry("4- CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      CalcularImpuestoInterno()

      '-- REQ-35220.- -------------------------------------------------------------------------------
      MovAtributo01 = New Entidades.AtributoProducto
      MovAtributo02 = New Entidades.AtributoProducto
      MovAtributo03 = New Entidades.AtributoProducto
      MovAtributo04 = New Entidades.AtributoProducto
      If Integer.Parse(dr.Cells("Atributos").Value.ToString()) > 0 Then
         If flackCargaProductos Then
            '-- Carga los Valores de Atributo.- --
            With MovAtributo01
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo01").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo01").Value.ToString())
            End With
            With MovAtributo02
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo02").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo02").Value.ToString())
            End With
            With MovAtributo03
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo03").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo03").Value.ToString())
            End With
            With MovAtributo04
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo04").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo04").Value.ToString())
            End With

            '-- Convoca Formulario de Carga de Atributos.-
            Using sap = SeleccionaAtributosProductosFactory.Create(DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante))
               With sap
                  .Atributo01 = MovAtributo01
                  .Atributo02 = MovAtributo02
                  .Atributo03 = MovAtributo03
                  .Atributo04 = MovAtributo04
                  '-- Adiciona Producto y Sucursal.- ---------------
                  .idSucursal = actual.Sucursal.IdSucursal
                  .idProducto = dr.Cells("IdProducto").Value.ToString.Trim()
               End With
               '-- Invoca Formulario.- -----------------------------
               If sap.ShowDialog(Me) = DialogResult.Cancel Then
                  btnLimpiarProducto.PerformClick()
                  bscCodigoProducto2.Focus()
                  Exit Sub
               End If
               '-- Aloja los datos recuperados.- --
               With sap
                  MovAtributo01 = .Atributo01
                  MovAtributo02 = .Atributo02
                  MovAtributo03 = .Atributo03
                  MovAtributo04 = .Atributo04
               End With
            End Using
         End If
         '----------------------------------------------
         txtAtributo01.Text = MovAtributo01.Descripcion
         txtAtributo02.Text = MovAtributo02.Descripcion
         '----------------------------------------------
         Me.txtStock.Text = New Reglas.ProductosSucursalesAtributos().GetStockProductoAtributo(dr.Cells("IdProducto").Value.ToString.Trim(),
                                                                                               actual.Sucursal.IdSucursal,
                                                                                               MovAtributo01.IdaAtributoProducto,
                                                                                               MovAtributo02.IdaAtributoProducto,
                                                                                               MovAtributo03.IdaAtributoProducto,
                                                                                               MovAtributo04.IdaAtributoProducto).ToString()
      Else
         Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      End If
      '----------------------------------------------------------------------------------------------
      Me.txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

      Me.txtTamanio.Text = dr.Cells("Tamano").Value.ToString()
      Me.txtUM.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
      Me.txtCantidadManual.Text = "1." + New String("0"c, Me._decimalesEnCantidad)

      '-- REQ-38566.- ----------------------------------------------------------------
      If Not Reglas.Publicos.Facturacion.FacturacionCantidadPorDefecto Then
         Me.txtCantidadManual.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      End If
      Me.txtCantidad.Text = Me.txtCantidadManual.Text
      '-------------------------------------------------------------------------------

      '# Agrego las unidades de medida al combo
      Me.CargaComboUnidadesMedida(Producto.UnidadDeMedida, Producto.UnidadDeMedida2, Me.cmbUM2)

      Me.txtKilosModDesc.Text = dr.Cells("Kilos").Value.ToString()

      Me.dtpFechaActPrecios.Value = Date.Parse(dr.Cells("FechaActualizacion").Value.ToString())

      'Se calculan los descuentos correspondientes al Cliente/Producto/Cantidad
      '-------------------------------------------------------------------------
      'Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())
      My.Application.Log.WriteEntry("4.5- CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
      Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
      If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
         Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.IdRubro = Producto.IdRubro Then
               cantidad = vp.Cantidad
            End If
         Next

         Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, Producto, cantidad, Me._decimalesEnTotales)

         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.IdRubro = Producto.IdRubro Then
               vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
               If calculaDescuentoRecargo2 Then
                  vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
               End If
            End If
            vp.DescuentoRecargo = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                             vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, vp.Cantidad)
         Next

         'RecalcularTodo()

      Else
         Me._DescuentosRecargosProd = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), Me._decimalesEnTotales)
      End If

      My.Application.Log.WriteEntry("5- CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Dim precioCosto = New Reglas.Ventas().CalculoPrecioCosto(Producto, _clienteE, GetTipoComprobanteSeleccionado(),
                                                               Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString()),
                                                               txtCotizacionDolar.ValorNumericoPorDefecto(0D),
                                                               _decimalesRedondeoEnPrecio)

      txtCosto.Text = precioCosto.PrecioCosto.ToString(_formatoAMostrarEnPrecio)
      txtCosto.Tag = precioCosto.PrecioCostoSinIVA.ToString(_formatoAMostrarEnPrecio)
      txtCosto.ReadOnly = True

      '-- REQ-32381.- -------------------------------------------------------------------------------------------------------------------
      If _VisualizaPC = Entidades.Publicos.VisualizaPrecioCosto.MODIFICABLE.ToString() And Producto.PermiteModificarDescripcion Then
         txtCosto.Enabled = True
         txtCosto.ReadOnly = False
         txtCosto.Tag = Nothing
      End If
      '----------------------------------------------------------------------------------------------------------------------------------

      lblPrecioVentaPorTamano2.Text = String.Format("x {0}", Producto.UnidadDeMedida.NombreUnidadDeMedida)
      cmbMoneda.SelectedValue = Producto.Moneda.IdMoneda
      _solicitaPrecioVentaPorTamano = Producto.SolicitaPrecioVentaPorTamano
      txtPrecioVentaPorTamano.Enabled = _solicitaPrecioVentaPorTamano

      If ultimaVentaDelProducto Is Nothing OrElse ultimaVentaDelProducto.Rows.Count = 0 Then
         Me.txtDescRecPorc1.Text = Me._DescuentosRecargosProd.DescuentoRecargo1.ToString("N" + _decimalesEnTotales.ToString())
         If calculaDescuentoRecargo2 Then
            Me.txtDescRecPorc2.Text = Me._DescuentosRecargosProd.DescuentoRecargo2.ToString("N" + _decimalesEnTotales.ToString())
         End If
      End If

      If Me._DescuentosRecargosProd.Mensaje <> "" Then
         MessageBox.Show(Me._DescuentosRecargosProd.Mensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
      '--------------------------------------------------------------------------

      _cargandoComboFormula = True
      _publicos.CargaComboFormulasDeProductos(cmbFormula, Producto.IdProducto)
      _cargandoComboFormula = False
      If cmbFormula.Items.Count = 0 Then
         cmbFormula.SelectedIndex = -1
         cmbFormula.Enabled = False
      Else
         cmbFormula.SelectedValue = Producto.IdFormula
         cmbFormula.Enabled = True
      End If

      'Exento sin IVA. 
      If Me.cmbTiposComprobantes.SelectedIndex <> -1 Then
         If Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or
               Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
               Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
            Me.cmbPorcentajeIva.Text = "0." + New String("0"c, Me._decimalesEnTotales)
            Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
         End If
      End If

      Me._productoLoteTemporal = New Entidades.VentaProductoLote()
      Me._productoLoteTemporal.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

      If Boolean.Parse(dr.Cells("FacturacionCantidadNegativa").Value.ToString()) Then
         Me.txtCantidad.Text = "-1." + New String("0"c, Me._decimalesEnCantidad)
         Me.txtStock.Tag = False
      End If

      'Si esta habitada, seguramente la cambiaria
      If Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible Then
         If Reglas.Publicos.Facturacion.FacturacionModificaDescriProdCantidad Then
            Me.txtCantidadManual.Focus()
            Me.txtCantidadManual.SelectAll()
         Else
            txtProductoObservacion.Focus()
            'Me.bscProducto2.Focus()
            'Me.bscProducto2.SelectAll()
         End If
         If Reglas.Publicos.Facturacion.FacturacionModificaDescripSolicitaKilos Then
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
            Me.txtCantidadManual.Focus()
            Me.txtCantidadManual.SelectAll()
         End If
      End If

      My.Application.Log.WriteEntry("6- CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      If Me._modalidad = Entidades.Producto.Modalidades.PESO Then
         Me.txtCantidadManual.Text = Decimal.Round(Me.GetPrecioModalidadPeso(), Me._decimalesEnCantidad).ToString("N" + _decimalesMostrarEnCantidad.ToString())
      End If

      Me._modalidad = Entidades.Producto.Modalidades.NORMAL

      SetearDescuentosPorCantidad(Producto)

      Me._estoyCargandoElProducto = False

      pnlEsOferta.Visible = Reglas.Publicos.FacturacionResaltaProductosEnOferta And Producto.EsOferta = "SI"

      'Controla multiples Ivas en producto
      If Reglas.Publicos.ProductoUtilizaAlicuota2 AndAlso cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal)().ResuelveUtilizaAlicuota2Producto(_clienteE) AndAlso dr.Cells("Alicuota2").Value.ToString() <> Nothing Then
         Me.cmbPorcentajeIva.Enabled = True
         'Me.cmbPorcentajeIva.Tag = dr.Cells("Alicuota2").Value.ToString()
         cmbPorcentajeIva.SelectedValue = dr.Cells("Alicuota2").Value

         Dim tipoComp As Entidades.TipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)()
         If (Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
             Not tipoComp.GrabaLibro And Not tipoComp.EsPreElectronico) Or
            tipoComp.PermiteSeleccionarAlicuotaIVA Then
            Me.cmbPorcentajeIva.Enabled = True
         Else
            Me.cmbPorcentajeIva.Enabled = False
         End If
      End If
      My.Application.Log.WriteEntry("Finaliza CargarProducto " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

   End Sub

   Private Sub CalcularImpuestoInterno()

      Dim iidb As FacturacionV2.ImpIntDesdeBusquedas = FacturacionV2.GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)

      If iidb.PorcImpuestoInterno = 0 Then
         MuestraImpuestosInternos(iidb.ImporteImpuestoInterno, iidb.PorcImpuestoInterno)
      Else
         If Not IsNumeric(txtPrecio.Text) Then txtPrecio.Text = (0).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         Dim precioNeto As Decimal
         Dim descRecPorc1 As Decimal = Decimal.Parse(txtDescRecPorc1.Text)
         Dim descRecPorc2 As Decimal = Decimal.Parse(txtDescRecPorc2.Text)
         Dim descRecGralPorc As Decimal = Decimal.Parse(txtDescRecGralPorc.Text)

         Dim alicuotaIVA As Decimal = Decimal.Parse(cmbPorcentajeIva.Text)

         If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
            Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
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
         If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
             Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            'El precio en pantalla está sin IVA
            impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA, iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
            'impuestoInterno = importeImpuestoInternoProducto + (precioNeto * porcImpuestoInterno / 100)
         Else
            'El precio en pantalla está con IVA
            impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA, iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
            'impuestoInterno = importeImpuestoInternoProducto + (precioNeto * porcImpuestoInterno / 100)
         End If

         MuestraImpuestosInternos(impuestoInterno, iidb.PorcImpuestoInterno)
      End If

   End Sub

   Private Sub CargarProductoRT(dr As DataGridViewRow)

      Me.bscCodigoProducto2RT.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscCodigoProducto2RT.Enabled = False


      Me.bscCodigoProducto2RT.Tag = dr.Cells("IdFormula").Value.ToString()

      cmbDepositoRT.Enabled = True
      cmbUbicacionRT.Enabled = True

      Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      Me.bscProducto2RT.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscProducto2RT.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

      Me.txtStockRT.Text = dr.Cells("Stock").Value.ToString()
      Me.txtStockRT.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

      Me.txtTamanioRT.Text = dr.Cells("Tamano").Value.ToString()
      Me.txtUMRT.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
      Me.txtCantidadRT.Text = "1." + New String("0"c, Me._decimalesEnCantidad)
      Me.txtCantidadManualRT.Text = Me.txtCantidadRT.Text

      '# Agrego las unidades de medida al combo
      Me.CargaComboUnidadesMedida(Producto.UnidadDeMedida, Producto.UnidadDeMedida2, Me.cmbUM2RT)

      If Not String.IsNullOrEmpty(dr.Cells("IdSubRubro").Value.ToString()) Then

         'Cargo el Descuento/Recargo cargado en el subrubro
         Dim oSR As Reglas.SubRubros = New Reglas.SubRubros()
         Dim SubR As Entidades.SubRubro

         SubR = oSR.GetUno(Integer.Parse(dr.Cells("IdSubRubro").Value.ToString()))
         DescRecPorc1RT = SubR.DescuentoRecargoPorc1

         'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
         Dim oCSR As Reglas.ClientesDescuentosSubRubros = New Reglas.ClientesDescuentosSubRubros()
         Dim SubR2 As Entidades.SubRubro

         SubR2 = oCSR.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdSubRubro").Value.ToString()))
         DescRecPorc2RT = SubR2.DescuentoRecargoPorc1

      End If
      '---------------------------------------------------------------------------

      Me.txtStockRT.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())
      If Boolean.Parse(dr.Cells("FacturacionCantidadNegativa").Value.ToString()) Then
         Me.txtCantidadRT.Text = "-1." + New String("0"c, Me._decimalesEnCantidad)
         Me.txtStockRT.Tag = False
      End If

      'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
      Dim oCDM As Reglas.ClientesDescuentosMarcas = New Reglas.ClientesDescuentosMarcas()
      Dim Marc As Entidades.Marca

      Marc = oCDM.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdMarca").Value.ToString()))
      If Marc.DescuentoRecargoPorc1 <> 0 Then
         If Decimal.Parse(Me.txtDescRecPorc1.Text) = 0 Then
            DescRecPorc1RT = Marc.DescuentoRecargoPorc1
         ElseIf DescRecPorc2RT = 0 Then
            DescRecPorc2RT = Marc.DescuentoRecargoPorc1
         End If
      End If
      If Marc.DescuentoRecargoPorc2 <> 0 Then
         If DescRecPorc1RT = 0 Then
            DescRecPorc1RT = Marc.DescuentoRecargoPorc2
         ElseIf DescRecPorc2RT = 0 Then
            DescRecPorc2RT = Marc.DescuentoRecargoPorc2
         End If
      End If

      Dim PrecioPorEmbalaje As Boolean = Boolean.Parse(dr.Cells("PrecioPorEmbalaje").Value.ToString())

      Dim PrecioVentaSinIVA As Decimal = 0
      Dim PrecioVentaConIVA As Decimal = 0

      If PrecioPorEmbalaje Then
         PrecioVentaSinIVA = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()) / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
         PrecioVentaConIVA = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()) / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
      Else
         PrecioVentaSinIVA = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString())
         PrecioVentaConIVA = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString())
      End If

      If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
         PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      End If

      If (Me._clienteE.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
      Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
         Me.txtPrecioRT.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         Me.txtPrecioRT.Tag = Me.txtPrecioRT.Text
      Else
         'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
         Me.txtPrecioRT.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         Me.txtPrecioRT.Tag = Me.txtPrecioRT.Text
      End If

   End Sub

   Private _cargarProductoCompleto As Boolean = False
   Private _cargaProductoDesdeInvocacion As Boolean = False
   Private _ordenProducto As Integer
   Private Sub CargarProductoCompleto(dr As DataGridViewRow,
                                      editarProductoDesdeGrilla As Boolean)
      Try
         _cargarProductoCompleto = True
         _cargandoProductoDesdeCompleto = True
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Dim Prod As Entidades.Producto
         Dim oRub As Reglas.Rubros = New Reglas.Rubros()
         Dim Rub As Entidades.Rubro = New Entidades.Rubro()

         Prod = oProductos.GetUno(dr.Cells("IdProducto").Value.ToString.Trim())
         Rub = oRub.GetUno(Prod.IdRubro)

         ventaProducto = DirectCast(dr.DataBoundItem, Entidades.VentaProducto)

         If _ventasProductosFormulas.ContainsKey(ventaProducto) Then
            _ventasProductosFormulasActual = _ventasProductosFormulas(ventaProducto)
         End If

         _cargandoProductosAutomaticamente = ventaProducto.Automatico

         Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

         cmbTipoOperacion.SelectedItem = ventaProducto.TipoOperacion
         cmbNota.Text = ventaProducto.Nota

         'Llamo al evento para cargar el objeto "FilaDevuelta" validado luego al insertar el producto.

         '# Se agrega parámetro al final para indicar que se está editando desde la grilla
         '# Para que NO busqué por otros códigos que no sea el EXACTO.
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", soloBuscaPorIdProducto:=editarProductoDesdeGrilla)
         Me.bscCodigoProducto2.PresionarBoton()

         If Reglas.Publicos.Facturacion.FacturacionConservaOrdenProductos Then
            _ordenProducto = ventaProducto.Orden   ' Integer.Parse(dr.Cells("Orden").Value.ToString())
         End If


         ' Verificar si la fila devuelta está vacia.
         ' # Se adopta por ahora una solución parcial que es no permitirle al usuario editar el producto que está en la grilla si no lo selecciono.
         If Me.bscCodigoProducto2.FilaDevuelta Is Nothing Then
            Throw New Exception("No se seleccionó un producto para editar.")
         End If

         If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
            'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
            Me.bscProducto2.Text = dr.Cells("ProductoDesc").Value.ToString()
            Me.txtProductoObservacion.Text = dr.Cells("ProductoDesc").Value.ToString()

            If Prod.EsObservacion Then
               Me.txtProductoObservacion.MaxLength = Reglas.Publicos.CantidadCaracteresProductoObservacion
            Else
               Me.txtProductoObservacion.MaxLength = Integer.Parse(Me.bscProducto2.MaxLengh)
            End If

         End If

         'NO hace falta, el "PresionarBoton" llama a "CargarProducto" y lo asigna.
         ''Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
         'Me.txtStock.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("Stock").Value.ToString()
         'Me.txtStock.Tag = Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("AfectaStock").Value.ToString())

         Me._nroOferta = Integer.Parse(dr.Cells("IdOferta").Value.ToString())

         cmbFormula.SelectedIndex = -1


         cmbFormula.SelectedValue = ventaProducto.IdFormula

         If Not _calculaPreciosSegunFormula OrElse _ventasProductosFormulasActual Is Nothing Then
            Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), Me._decimalesRedondeoEnPrecio).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            Me.txtPrecio.Tag = Me.txtPrecio.Text
         End If

         txtCosto.Text = ventaProducto.Costo.ToString(_formatoAMostrarEnPrecio)
         txtCosto.Tag = ventaProducto.CostoParaGrabar.IfNull().ToString(_formatoAMostrarEnPrecio)

         Me.txtCantidad.Text = dr.Cells("Cantidad").Value.ToString()
         Me.txtCantidadManual.Text = dr.Cells("CantidadManual").Value.ToString()
         Me.cmbPorcentajeIva.Text = dr.Cells("AlicuotaImpuesto").Value.ToString()
         Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text

         If Decimal.Parse(dr.Cells("Precio").Value.ToString()) <> 0 Then
            If Prod.UnidHasta1 = 0 Or Rub.UnidHasta1 = 0 Then
               Me.txtDescRecPorc1.Text = Decimal.Parse(dr.Cells("DescuentoRecargoPorc1").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesEnDescRec))
               Me.txtDescRecPorc2.Text = Decimal.Parse(dr.Cells("DescuentoRecargoPorc2").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesEnDescRec))
            End If
         End If

         _modificoPrecioManualmente = ventaProducto.ModificoPrecioManualmente

         CalcularImpuestoInterno()
         '----------------------------------------------------------
         cmbDepositoOrigen.SelectedValue = Integer.Parse(dr.Cells("IdDeposito").Value.ToString())
         cmbUbicacionOrigen.SelectedValue = Integer.Parse(dr.Cells("IdUbicacion").Value.ToString())
         '----------------------------------------------------------
         _cargandoProductoDesdeCompleto = False

         Me.txtDescRec.Text = Decimal.Parse(dr.Cells("DescuentoRecargo").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         Me.txtTotalProducto.Text = Decimal.Parse(dr.Cells("Importe").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto))

         Me.txtTamanio.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("Tamano").Value.ToString()
         Me.txtUM.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
         Me.cmbUM2.SelectedValue = Me.txtUM.Text

         txtPrecioVentaPorTamano.Text = Decimal.Parse(dr.Cells(Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString()).Value.ToString()).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         cmbMoneda.SelectedValue = Integer.Parse(dr.Cells(Entidades.PedidoProducto.Columnas.IdMoneda.ToString()).Value.ToString())

         '-- REQ-35220.- -- Aloja los datos recuperados.- --
         With MovAtributo01
            .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto01").Value.ToString())
            If dr.Cells("DescripcionAtributo01").Value IsNot Nothing Then
               .Descripcion = dr.Cells("DescripcionAtributo01").Value.ToString()
            End If
         End With
         With MovAtributo02
            .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto02").Value.ToString())
            If dr.Cells("DescripcionAtributo02").Value IsNot Nothing Then
               .Descripcion = dr.Cells("DescripcionAtributo02").Value.ToString()
            End If
         End With
         With MovAtributo03
            .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto03").Value.ToString())
            If dr.Cells("DescripcionAtributo03").Value IsNot Nothing Then
               .Descripcion = dr.Cells("DescripcionAtributo03").Value.ToString()
            End If
         End With
         With MovAtributo04
            .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto04").Value.ToString())
            If dr.Cells("DescripcionAtributo04").Value IsNot Nothing Then
               .Descripcion = dr.Cells("DescripcionAtributo04").Value.ToString()
            End If
         End With
         '-- REQ-35488.- -------------------------------
         txtAtributo01.Text = MovAtributo01.Descripcion
         txtAtributo02.Text = MovAtributo02.Descripcion
         '----------------------------------------------

         'Divido por la cantidad porque en la linea ya esta el total por linea.
         If Decimal.Parse(dr.Cells("Cantidad").Value.ToString()) <> 0 Then
            Me.txtKilosModDesc.Text = (Decimal.Parse(dr.Cells("Kilos").Value.ToString()) / Decimal.Parse(dr.Cells("Cantidad").Value.ToString())).ToString("##,##0.000")
         End If

         _modificoDescuentos = CBool(dr.Cells("ModificoDescuentos").Value)
         _txtCantidad_prev = Decimal.Parse(dr.Cells("Cantidad").Value.ToString())

         If _utilizaCentroCostos Then
            If dr.Cells("IdCentroCosto").Value Is Nothing Then
               cmbCentroCosto.SelectedIndex = -1
            Else
               cmbCentroCosto.SelectedValue = Integer.Parse(dr.Cells("IdCentroCosto").Value.ToString())
            End If
         End If

         SetearDescuentosPorCantidad(Prod)

         _nrosSerieSeleccionados = ventaProducto.Producto.NrosSeries
         '# Reconstruyo los lotes seleccionados dentro del producto que se está editando
         Me.CargarLotesPreviamenteSeleccionados(ventaProducto)
      Finally
         _cargarProductoCompleto = False
      End Try
   End Sub

   Private Sub CargarProductoCompletoRT(dr As DataGridViewRow,
                                        editarProductoDesdeGrilla As Boolean)

      Dim oProductos As Reglas.Productos = New Reglas.Productos

      Me.bscCodigoProducto2RT.Text = dr.Cells("grtIdProducto").Value.ToString.Trim()

      'Llamo al evento para cargar el objeto "FilaDevuelta" validado luego al insertar el producto.
      Me.bscCodigoProducto2RT.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2RT.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", soloBuscaPorIdProducto:=editarProductoDesdeGrilla)
      Me.bscCodigoProducto2RT.PresionarBoton()

      If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(Me.bscCodigoProducto2RT.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
         'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
         Me.bscProducto2RT.Text = dr.Cells("grtProductoDesc").Value.ToString()
      End If

      'Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
      Me.txtStockRT.Text = Me.bscCodigoProducto2RT.FilaDevuelta.Cells("Stock").Value.ToString()
      Me.txtTamanioRT.Text = Me.bscCodigoProducto2RT.FilaDevuelta.Cells("Tamano").Value.ToString()
      Me.txtUMRT.Text = dr.Cells("IdUnidadDeMedidaRT").Value.ToString()
      Me.cmbUM2RT.SelectedValue = Me.txtUMRT.Text

      Me.txtCantidadRT.Text = dr.Cells("grtCantidad").Value.ToString()
      Me.txtCantidadManualRT.Text = dr.Cells("CantidadManualRT").Value.ToString()

      Me.txtPrecioRT.Text = dr.Cells("grtPrecio").Value.ToString() '# Este campo es invisible, pero se agrega para que se mantengan los precios en caso de que los productos fueran invocados desde otro comprobante (por ej: un pedido)

      '# SOLO si el tipo de comprobante requiere fecha de devolucion
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).SolicitaFechaDevolucion Then
         Me.rbFechaDevolucion.Checked = True

         '# En caso de que los productos vengan de la grilla estándar, no van a tener fecha de devolución, por lo tanto no hago el cálculo
         If IsDate(dr.Cells(Entidades.VentaProducto.Columnas.FechaDevolucion.ToString()).Value) Then
            Me.dtpFechaDevolucion.Value = Date.Parse(dr.Cells(Entidades.VentaProducto.Columnas.FechaDevolucion.ToString()).Value.ToString())
            Me.CalcularFechaDiasDevolucion()
         End If
      End If
   End Sub

   Private Sub CargarObservacion(dr As DataGridViewRow)
      Me.bscObservacion.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub CargarObservDetalle(dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub CargarObservDetalleCompleto()
      If ugObservaciones.ActiveRow IsNot Nothing Then
         Me.bscObservacionDetalle.Text = ugObservaciones.ActiveRow.Cells("Observacion").Value.ToString()
         cmbTipoObservacion.SelectedValue = Short.Parse(ugObservaciones.ActiveRow.Cells("idTipoObservacion").Value.ToString())
      End If
   End Sub

   Private Sub CalcularDatosDetalle()

      If Me.cmbCategoriaFiscal.SelectedItem Is Nothing Then Exit Sub

      If Not IsNumeric(txtDescRecGralPorc.Text) Then
         txtDescRecGralPorc.Text = "0"
         _clienteTieneDescRec = False
      End If

      'If Publicos.DescuentoMaximo > 0 And Decimal.Parse(Me.txtDescRecGralPorc.Text.ToString()) < 0 And Math.Abs(Decimal.Parse(Me.txtDescRecGralPorc.Text.ToString())) > Publicos.DescuentoMaximo Then
      '   MessageBox.Show("ATENCION: no puede asignar un Descuento mayor al: " & Publicos.DescuentoMaximo.ToString("N2") + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '   Me.txtDescRecGralPorc.Focus()
      '   Exit Sub
      'End If

      For Each vPro As Entidades.VentaProducto In Me._ventasProductos


         Dim importeTotalParaDescuento As Decimal = vPro.ImporteTotal
         'Se anula esta lógica porque no se permite más facturación con ImpInt fijos.
         'If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
         '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
         '      importeTotalParaDescuento = vPro.ImporteTotal - vPro.ImporteImpuestoInterno
         '   Else
         '      importeTotalParaDescuento = vPro.ImporteTotal
         '   End If
         '   ''precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
         'Else
         '   importeTotalParaDescuento = vPro.ImporteTotal
         'End If


         vPro.DescRecGeneral = Decimal.Round((importeTotalParaDescuento * Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100), Me._decimalesRedondeoEnPrecio)

         Me.CalculaValores(vPro.Cantidad, vPro.AlicuotaImpuesto, vPro.ImporteImpuestoInterno, vPro.Precio,
               vPro.DescuentoRecargoPorc1, vPro.DescuentoRecargoPorc2, Decimal.Parse(Me.txtDescRecGralPorc.Text),
               vPro.PrecioNeto, 0, vPro.ImporteImpuesto, vPro.ImporteTotal, vPro.Producto)

         'vPro.DescuentoRecargo = (vPro.PrecioNeto - vPro.Precio) * vPro.Cantidad

      Next

      Me.dgvProductos.Refresh()
      Me.dgvRemitoTransp.Refresh()

      Me.RecalcularSubtotales()
      Me.CalcularTotales()

   End Sub

   Private Sub RenumerarObservacionesDetalle()

      Dim Linea As Integer = 0

      For Each vObs As Entidades.VentaObservacion In Me._ventasObservaciones
         Linea += 1
         vObs.Linea = Linea
      Next

      SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())

   End Sub

   Private Sub CargarUnArticulo(linea As Entidades.VentaProducto,
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
                                costoParaGrabar As Decimal,
                                precioLista As Decimal,
                                kilos As Decimal,
                                idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                porcentajeIva As Decimal,
                                importeIva As Decimal,
                                precioNeto As Decimal,
                                FechaActualizacion As Date,
                                ImpuestoInterno As Decimal,
                                porcImpuestoInterno As Decimal,
                                origenPorcImpInt As Entidades.OrigenesPorcImpInt,
                                centroCosto As Entidades.ContabilidadCentroCosto,
                                PrecioVentaPorTamano As Decimal,
                                Tamano As Decimal,
                                IdUnidadDeMedida As String,
                                moneda As Entidades.Moneda,
                                idFormula As Integer,
                                nombreFormula As String,
                                idOferta As Integer,
                                ubicacion As String)
      Dim cotizacion As Decimal = 1
      Decimal.TryParse(txtCotizacionDolar.Text, cotizacion)

      With linea
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         '--
         If ventaProducto IsNot Nothing Then
            .TipoComprobante = ventaProducto.TipoComprobante
            .Letra = ventaProducto.Letra
            .CentroEmisor = ventaProducto.CentroEmisor
            .NumeroComprobante = ventaProducto.NumeroComprobante
            .Orden = ventaProducto.Orden
            ventaProducto = Nothing
         End If
         '--
         '.Producto.IdProducto = idProducto
         .Producto = producto 'New Reglas.Productos().GetUno(idProducto)  'Luego uso ciertas caracteristicas (ej: LOTE).
         .CodigoProductoProveedor = If(producto.ProductoProveedorHabitual IsNot Nothing, producto.ProductoProveedorHabitual.CodigoProductoProveedor, Nothing)
         .Producto.NombreProducto = productoDescripcion   'Piso la descripcion por si tiene habilitado la posibilidad de cambiarlas.
         .DescuentoRecargoPorc1 = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         .DescuentoRecargo = descuentoRecargo

         .Precio = precio
         .PrecioDolar = precio / cotizacion

         .Cantidad = cantidad
         .CantidadManual = cantidadManual
         .Conversion = producto.Conversion

         .ImporteTotal = importeTotal
         .ImporteTotalDolar = importeTotal / cotizacion

         .Stock = stock

         .Costo = costo
         .CostoDolar = costo / cotizacion

         .CostoParaGrabar = costoParaGrabar
         .PrecioLista = precioLista
         .Kilos = kilos

         .PrecioNeto = precioNeto
         .PrecioNetoDolar = precioNeto / cotizacion

         .AlicuotaImpuesto = porcentajeIva
         .ImporteImpuesto = importeIva
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .ComisionVendedorPorc = 0
         .ComisionVendedor = 0
         .IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         .NombreListaPrecios = Me.cmbListaDePrecios.Text
         .FechaActualizacion = FechaActualizacion

         .ModificoDescuentos = If(_DescuentosRecargosProd Is Nothing, False, _DescuentosRecargosProd.DescuentoRecargo1 <> descuentoRecargoPorc1 Or _DescuentosRecargosProd.DescuentoRecargo2 <> descuentoRecargoPorc2)
         .ImporteImpuestoInterno = ImpuestoInterno
         .PorcImpuestoInterno = porcImpuestoInterno
         .OrigenPorcImpInt = origenPorcImpInt

         .PrecioVentaPorTamano = PrecioVentaPorTamano
         .Tamano = Tamano
         .IdUnidadDeMedida = IdUnidadDeMedida
         .Moneda = moneda

         .IdFormula = idFormula
         .NombreFormula = nombreFormula

         .TipoOperacion = GetTipoOperacionSeleccionada()
         .Nota = cmbNota.Text

         .CentroCosto = centroCosto
         .Automatico = _cargandoProductosAutomaticamente

         .IdOferta = idOferta
         .Ubicacion = ubicacion

         '-- REQ-33202.- ------------------------------------------------------------------
         .PrecioAux = precio
         .IdListaPreciosAux = _idListaAux
         '---------------------------------------------------------------------------------

         .ModificoPrecioManualmente = _modificoPrecioManualmente

         If _ordenProducto > 0 Then
            .Orden = _ordenProducto
         ElseIf _ordenProducto = 0 Then
            .Orden = _ventasProductos.MaxSecure(Function(x) x.Orden).IfNull() + 1
         End If

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

   Private Function GetCostoParaGrabar(txtCosto As TextBox, producto As Entidades.Producto) As Decimal
      Dim costoParaGrabar As Decimal = 0
      If IsNumeric(txtCosto.Tag) Then
         costoParaGrabar = ObjectExtensions.ValorNumericoPorDefecto(txtCosto.Tag(), 0D)
      Else
         If Not ((_clienteE.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                  Not _clienteE.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Or
                  Not DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos) Then
            costoParaGrabar = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(txtCosto.ValorNumericoPorDefecto(0D), producto)
         End If
      End If
      Return costoParaGrabar
   End Function

   Private Sub InsertarProducto()

      Dim producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text)
      If producto.ImporteImpuestoInterno <> 0 Then
         Throw New Exception(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se puede agregar el producto al Comprobane.", producto.IdProducto, producto.NombreProducto))
      End If

      '      txtCosto.Enabled = producto.PermiteModificarDescripcion

      'Asigno la actividad del Rubro del primer producto que se elige.
      If Me.cmbActividades.Items.Count > 0 And Me._ventasProductos.Count = 0 Then
         Me.cmbActividades.SelectedValue = New Reglas.Rubros().GetUno(producto.IdRubro).Actividad.IdActividad
         'Estaba en cero o bien no lo encontro en el combo, queda en vacio
         If Me.cmbActividades.SelectedIndex = -1 Then
            Me.cmbActividades.SelectedIndex = 0
         End If
      End If

      '-- REQ-33202.- ----------------------------------------------------------------------------------------------------------
      If Reglas.Publicos.Facturacion.FacturacionAgrupaCantidadesProductos Then
         Dim drExistente = _ventasProductos.FirstOrDefault(Function(vp) vp.IdProducto.Trim() = bscCodigoProducto2.Text.Trim())
         If drExistente IsNot Nothing Then
            Dim cantidadActual = txtCantidad.ValorNumericoPorDefecto(0D)
            txtCantidad.Text = (cantidadActual + drExistente.Cantidad).ToString("N2")
            txtCantidadManual.Text = (cantidadActual + drExistente.Cantidad).ToString("N2")
            _ordenProducto = drExistente.Orden
            txtCantidadManual.Focus()
            btnInsertar.Focus()
            _ventasProductos.Remove(drExistente)
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
      Dim oLineaDetalle As Entidades.VentaProducto = New Entidades.VentaProducto()
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
      Dim Ubicacion As String

      Dim filaDevuelta As DataGridViewRow
      If bscCodigoProducto2.FilaDevuelta Is Nothing Then
         filaDevuelta = bscProducto2.FilaDevuelta
      Else
         filaDevuelta = bscCodigoProducto2.FilaDevuelta
      End If

      IdMoneda = Integer.Parse(filaDevuelta.Cells("IdMoneda").Value.ToString())
      alicuotaIVA = Decimal.Parse(filaDevuelta.Cells("Alicuota").Value.ToString())
      Ubicacion = filaDevuelta.Cells("Ubicacion").Value.ToString()

      '-- REQ-31736 (Modificacion Agrupa).- --
      precioCosto = Decimal.Parse(Me.txtCosto.Text)

      precioLista = Decimal.Parse(filaDevuelta.Cells("PrecioVenta").Value.ToString())
      If Reglas.Publicos.PreciosConIVA Then
         '-- Le quito el IVA que el producto tiene en forma predeterminada.- --
         precioLista = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precioLista, producto)
      End If

      'Precio de Costo, Opciones: ACTUAL o PROMPOND;<meses>
      ''''If Publicos.VentasPrecioCosto <> "ACTUAL" Then

      ''''   Dim CalculoCosto() As String = Publicos.VentasPrecioCosto.Split(";"c)

      ''''   Dim OtroPrecioCosto As Decimal = 0

      ''''   Select Case CalculoCosto(0).ToString()

      ''''      Case "PROMPOND"

      ''''         Dim oCP As Reglas.ComprasProductos = New Reglas.ComprasProductos()

      ''''         OtroPrecioCosto = oCP.GetCostoPromedioPonderado(actual.Sucursal.Id,
      ''''                                                         Me.bscCodigoProducto2.Text,
      ''''                                                         Date.Today.AddMonths(Integer.Parse(CalculoCosto(1).ToString()) * (-1)),
      ''''                                                         Date.Today)

      ''''      Case Else
      ''''         Throw New Exception("ATENCION: el sistema tiene configurado el Tipo de COSTO '" & CalculoCosto(0).ToString() & "' (incorrecto), verifíquelo en Parametros.")

      ''''   End Select

      ''''   If OtroPrecioCosto <> 0 Then
      ''''      precioCosto = OtroPrecioCosto
      ''''   End If

      ''''End If
      '----------------------------------------------------

      If IdMoneda = 2 Then
         '-- REQ-31290.- --
         'precioCosto = Decimal.Round(precioCosto / Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      End If

      If Boolean.Parse(filaDevuelta.Cells("PrecioPorEmbalaje").Value.ToString()) Then
         '-- REQ-31290.- --
         'precioCosto = precioCosto / Integer.Parse(filaDevuelta.Cells("Embalaje").Value.ToString())
         precioLista = precioLista / Integer.Parse(filaDevuelta.Cells("Embalaje").Value.ToString())
      End If


      'Asigno el nuevo iva (puedo cambiar o no)
      alicuotaIVA = Decimal.Parse(Me.cmbPorcentajeIva.Text)

      'If Me.txtUM.Text <> "" Then
      '   Dim Conversion As Decimal
      Dim kilosProducto As Decimal = 0
      '   Dim oUM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
      '   Conversion = oUM.GetUno(Me.txtUM.Text).ConversionAKilos
      If (Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible) And Reglas.Publicos.Facturacion.FacturacionModificaDescripSolicitaKilos Then
         kilosProducto = Decimal.Parse(Me.txtKilosModDesc.Text.ToString())
      Else
         kilosProducto = Decimal.Parse(filaDevuelta.Cells("Kilos").Value.ToString())
      End If


      'Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * kilosProducto * Conversion, 3)
      Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * kilosProducto, 3)
      'End If

      Dim precioProducto As Decimal = Decimal.Parse(Me.txtPrecio.Text.Trim())

      Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text)
      Dim cantidadManual As Decimal = CDec(Me.txtCantidadManual.Text)
      Dim descRecPorGeneral As Decimal = Decimal.Parse(Me.txtDescRecGralPorc.Text)

      Dim precioNeto As Decimal = 0

      Me._numeroOrden += 1

      '--------------------------------------------------------------------------------
      '###############################
      '#          Lotes              #
      '###############################
      Dim coeficienteStockParaLote As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock
      If coeficienteStockParaLote = 0 And
         Not String.IsNullOrWhiteSpace(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario) Then
         Dim tipoSecundario As Entidades.TipoComprobante
         tipoSecundario = New Reglas.TiposComprobantes().GetUno(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario)
         coeficienteStockParaLote = tipoSecundario.CoeficienteStock
      End If

      'Dim _productoTemporal As Entidades.Producto = producto
      If producto.Lote And coeficienteStockParaLote <> 0 Then

         'Si es NCRE , valido fechas.. sino.. que exista
         If coeficienteStockParaLote > 0 Then
            '_productoLoteTemporal.Producto.IdSucursal = actual.Sucursal.Id
            producto.IdSucursal = actual.Sucursal.Id
            Using frm As New SeleccionNrosLotes(producto, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer), CDec(Me.txtCantidad.Text), coeficienteStockParaLote, _numeroOrden)
               If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                  Throw New Exception("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Venta.")
               Else
                  '# Me guardo los lotes seleccionados
                  _lotesSeleccionados = frm._lotesSeleccionados
                  Me.CargarLotesSeleccionados(_lotesSeleccionados, oLineaDetalle, producto)
               End If
            End Using
         Else
            Dim invocado As Boolean = False
            If _comprobantesSeleccionados.Count > 0 AndAlso _comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock Then
               invocado = True
            End If

            If Not invocado Then
               '# Si el comprobante facturable no afecta stock, los nros de lotes no fueron solicitados, por lo que se le solicitan al usuario.
               '# Selección Automática
               Dim DispProdLotes As Decimal = New Reglas.ProductosLotes().GetDisponiblePorProducto(actual.Sucursal.Id, Me.bscCodigoProducto2.Text)
               If DispProdLotes = 0 Then
                  Throw New Exception("No existen Lotes para el Producto seleccionado.")
               End If
               If DispProdLotes < CDec(Me.txtCantidad.Text) Then
                  Throw New Exception("El Producto tiene en Stock " & DispProdLotes.ToString() & " quedaría en Cantidad Negativa, No es posible con Lotes.")
               End If

               '# Selección Manual
               If Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
                  producto.IdSucursal = actual.Sucursal.Id
                  Using frm As New SeleccionNrosLotes(producto, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer), CDec(Me.txtCantidad.Text), coeficienteStockParaLote, _lotesSeleccionados)
                     If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        Throw New Exception("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Venta.")
                     Else
                        _lotesSeleccionados = frm._lotesSeleccionados
                        Me.CargarLotesSeleccionados(_lotesSeleccionados, oLineaDetalle, producto, precioCosto, IdMoneda)
                     End If
                  End Using
               End If
            End If
         End If

      Else
         If producto.Lote AndAlso
            coeficienteStockParaLote = 0 AndAlso
            DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico AndAlso
            Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
            MessageBox.Show("El comprobante " & DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).DescripcionAbrev.ToString() & " No permite productos con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If
      End If

      Dim centroCosto As Entidades.ContabilidadCentroCosto = Nothing
      If _utilizaCentroCostos Then
         centroCosto = DirectCast(cmbCentroCosto.SelectedItem, Entidades.ContabilidadCentroCosto)
      End If

      If Reglas.Publicos.Facturacion.FacturacionVisualizaPrecioCosto <> Entidades.Publicos.VisualizaPrecioCosto.MODIFICABLE.ToString() Then
         Dim vpLote = oLineaDetalle.VentasProductosLotes.FirstOrDefault()
         Dim precioCostoNuevo = New Reglas.Ventas().CalculoPrecioCosto(
                                             actual.Sucursal.Id,
                                             producto, If(vpLote IsNot Nothing, vpLote.IdLote, String.Empty),
                                             cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer),
                                             _clienteE, GetTipoComprobanteSeleccionado(),
                                             txtCotizacionDolar.ValorNumericoPorDefecto(0D),
                                             _decimalesRedondeoEnPrecio)
         If precioCostoNuevo IsNot Nothing Then
            txtCosto.Text = precioCostoNuevo.PrecioCosto.ToString(_formatoAMostrarEnPrecio)
            txtCosto.Tag = precioCostoNuevo.PrecioCostoSinIVA.ToString(_formatoAMostrarEnPrecio)

            precioCosto = txtCosto.ValorNumericoPorDefecto(0D)
         End If
      End If

      '--------------------------------------------------------------------------------
      Dim impuestoInterno As Decimal = Decimal.Round(Decimal.Parse(Me.txtImpuestoInterno.Text) * cantidad, _decimalesRedondeoEnPrecio)
      Me.CalculaValores(cantidad, alicuotaIVA, impuestoInterno, precioProducto, descRecPorc1, descRecPorc2, descRecPorGeneral,
                        precioNeto, importeBruto, importeIva, importeTotal, producto)

      Dim precioVentaPorTamano As Decimal = 0
      If txtPrecioVentaPorTamano.Visible And Not txtPrecioVentaPorTamano.ReadOnly And txtPrecioVentaPorTamano.Enabled And IsNumeric(txtPrecioVentaPorTamano.Text) Then
         precioVentaPorTamano = Decimal.Parse(txtPrecioVentaPorTamano.Text)
      End If
      Dim tamano As Decimal = 0
      If IsNumeric(txtTamanio.Text) Then
         tamano = Decimal.Parse(txtTamanio.Text)
      End If

      '# Valido que se haya seleccionado una Unidad de Medida
      If Me.cmbUM2.SelectedIndex = -1 Then
         Me.cmbUM2.Focus()
         Throw New Exception("ATENCIÓN: Debe seleccionar una UM para el producto.")
      End If
      Dim idUnidadMedida As String = Me.cmbUM2.SelectedValue.ToString()
      Dim moneda As Entidades.Moneda = DirectCast(cmbMoneda.SelectedItem, Entidades.Moneda)

      Dim iidb As FacturacionV2.ImpIntDesdeBusquedas = FacturacionV2.GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)

      Dim idFormula As Integer = 0
      Dim nombreFormula As String = ""
      If cmbFormula.SelectedIndex > -1 AndAlso IsNumeric(cmbFormula.SelectedValue) Then
         idFormula = Integer.Parse(cmbFormula.SelectedValue.ToString())
         nombreFormula = cmbFormula.Text
      End If

      '-- REQ-32381.- -------------------------------------------------------------------------------------------------------------------
      If _VisualizaPC = Entidades.Publicos.VisualizaPrecioCosto.MODIFICABLE.ToString() And producto.PermiteModificarDescripcion Then
         txtCosto.Tag = precioCosto
         txtCosto.ReadOnly = True
      End If
      '----------------------------------------------------------------------------------------------------------------------------------

      If producto.DescontarStockComponentes Then
         If Not _ventasProductosFormulasActual.Any() Then ' Is Nothing Then
            _ventasProductosFormulasActual = New Reglas.ProductosComponentes().GetComponentes(actual.Sucursal.Id, producto.IdProducto, producto.IdFormula, cmbListaDePrecios.ValorSeleccionado(Publicos.ListaPreciosPredeterminada))
            _ventasProductosFormulasActual.Columns.Add("SeleccionMultiple", GetType(Object))
         End If


         Using frm = New SeleccionMultipleUbicacionListaProductos()
            Dim rSelecc = New Reglas.SeleccionMultipleUbicaciones()
            Dim lst = _ventasProductosFormulasActual.AsEnumerable().ToList().ConvertAll(
                           Function(dr)
                              Dim prod = dr.Field(Of Entidades.SeleccionMultipleProducto)("SeleccionMultiple")
                              If prod Is Nothing Then
                                 prod = rSelecc.CreaSeleccionMultipleProducto(dr.Field(Of String)("IdProductoComponente"),
                                                                                  actual.Sucursal.Id, cmbDepositoOrigen.ValorSeleccionado(0I), cmbUbicacionOrigen.ValorSeleccionado(0I),
                                                                                  dr.Field(Of Decimal)("Cantidad") * cantidad, dr)
                                 dr("SeleccionMultiple") = prod
                              End If
                              Return prod
                           End Function)


            Dim tpComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)
            If frm.ShowDialog(Me, lst, tpComp.CoeficienteStock, tpComp.SolicitaInformeCalidad) <> DialogResult.OK Then
               Exit Sub
            End If
         End Using
      End If


      Dim costoParaGrabar As Decimal = GetCostoParaGrabar(txtCosto, producto)

      Me.CargarUnArticulo(oLineaDetalle,
                          producto,
                          txtProductoObservacion.Text,
                          descRecPorc1,
                          descRecPorc2,
                          descRecargo,
                          precioProducto,
                          cantidad,
                          cantidadManual,
                          importeTotal,
                          stock,
                          precioCosto,
                          costoParaGrabar,
                          precioLista,
                          Kilos,
                          Me._tipoImpuestoIVA,
                          alicuotaIVA,
                          importeIva,
                          precioNeto,
                          Me.dtpFechaActPrecios.Value,
                          impuestoInterno,
                          Decimal.Parse(txtPorcImpuestoInterno.Text),
                          iidb.OrigenPorcImpInt,
                          centroCosto,
                          precioVentaPorTamano,
                          tamano,
                          idUnidadMedida,
                          moneda,
                          idFormula,
                          nombreFormula,
                          _nroOferta,
                          Ubicacion)

      'Selecciono los nros. de serie SOLO si el producto permite
      If coeficienteStockParaLote <> 0 Then
         If oLineaDetalle.Producto.NroSerie Then
            Dim nrosSerie As DataTable
            Dim rNrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()
            Dim Invocado As Boolean = False

            If _nrosSerieSeleccionados IsNot Nothing AndAlso _comprobantesSeleccionados.Count > 0 AndAlso _comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock Then
               nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer),
                                                           bscCodigoProducto2.Text, _nrosSerieSeleccionados.ConvertAll(Function(ns) ns.NroSerie))
               oLineaDetalle.Producto.NrosSeries = _nrosSerieSeleccionados
               Invocado = True
            Else
               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 Then
                  nrosSerie = rNrosSerie.GetNrosSerieProductoClienteVendido(actual.Sucursal.Id, Me.bscCodigoProducto2.Text, _clienteE.IdCliente)

               Else
                  '-- REQ-32489.- -------------------------------------------------------------------------
                  nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer), bscCodigoProducto2.Text)
               End If
            End If

            Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidad.Text), 0).ToString())
            If Not Invocado Then
               Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, oLineaDetalle.Producto, nrosSerie)
               If sel.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                  MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie debe seleccionar los numeros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Me.btnInsertar.Focus()
                  Exit Sub
               Else
                  For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
                     Dim noFueAgregado As Boolean
                     noFueAgregado = _ventasProductos.All(Function(vp)
                                                             If vp.Producto.IdProducto = ns.Producto.IdProducto Then
                                                                Return Not vp.Producto.NrosSeries.Any(Function(x) x.NroSerie = ns.NroSerie)
                                                             End If
                                                             Return True
                                                          End Function)

                     '# Si el producto ya fue agregado a la grilla, no dejo agregarlo nuevamente
                     If Not noFueAgregado Then
                        ShowMessage(String.Format("ATENCIÓN: El Producto: {0} Nro. Serie: {1} ya fue agregado.", ns.Producto.IdProducto, ns.NroSerie))
                        Exit Sub
                     End If
                  Next
                  oLineaDetalle.Producto.NrosSeries.Clear()
                  For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
                     oLineaDetalle.Producto.NrosSeries.Add(ns)
                  Next
               End If
            End If
         End If
         End If

      '# Si el producto Es Compuesto y NO tiene Fórmula predeterminada, el sistema no debe permitir ingresarlo.
      If oLineaDetalle.Producto.EsCompuesto AndAlso
         Not oLineaDetalle.Producto.IdFormula > 0 AndAlso Not oLineaDetalle.Producto.IdProcesoProductivoDefecto > 0 Then
         ShowMessage(String.Format("ATENCIÓN: El Producto: {0} {1} es Compuesto y no tiene Fórmula o Proceso Productivo predeterminado. Debe configurarla primero para poder ingresarlo.",
                                   oLineaDetalle.Producto.IdProducto,
                                   oLineaDetalle.Producto.NombreProducto))
         Exit Sub
      End If
      With oLineaDetalle
         '--REQ-35220.- ---------------------------------------------
         .IdaAtributoProducto01 = MovAtributo01.IdaAtributoProducto
         .DescripcionAtributo01 = MovAtributo01.Descripcion
         .IdaAtributoProducto02 = MovAtributo02.IdaAtributoProducto
         .DescripcionAtributo02 = MovAtributo02.Descripcion
         .IdaAtributoProducto03 = MovAtributo03.IdaAtributoProducto
         .DescripcionAtributo03 = MovAtributo03.Descripcion
         .IdaAtributoProducto04 = MovAtributo04.IdaAtributoProducto
         .DescripcionAtributo04 = MovAtributo04.Descripcion
         '---------------------------------------------------------
         .IdDeposito = depOrigen
         .NombreDeposito = cmbDepositoOrigen.Text
         .IdUbicacion = ubiOrigen
         .NombreUbicacion = cmbUbicacionOrigen.Text
      End With

      If oLineaDetalle.Orden = 0 Then
         oLineaDetalle.Orden = Me._numeroOrden
      End If

      Me._ventasProductos.Add(oLineaDetalle)


      If _ventasProductosFormulas.ContainsKey(oLineaDetalle) Then
         _ventasProductosFormulas.Add(oLineaDetalle, _ventasProductosFormulasActual)
      Else
         _ventasProductosFormulas(oLineaDetalle) = _ventasProductosFormulasActual
      End If
      _ventasProductosFormulasActual = Nothing

      '-- REQ-35220.- ------------------------------------------------------------------------------
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo01") Then _tit.Add("DescripcionAtributo01", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo02") Then _tit.Add("DescripcionAtributo02", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo03") Then _tit.Add("DescripcionAtributo03", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo04") Then _tit.Add("DescripcionAtributo04", "")
      End If
      '-- REQ-44219.- -------------------------------------------------------------------------------
      If Reglas.Publicos.FacturacionVisualizaDeposito Then
         If Not _tit.ContainsKey("NombreDeposito") Then _tit.Add("NombreDeposito", "")
      End If
      If Reglas.Publicos.FacturacionVisualizaUbicacion Then
         If Not _tit.ContainsKey("NombreUbicacion") Then _tit.Add("NombreUbicacion", "")
      End If
      '----------------------------------------------------------------------------------------------
      SetProductosDataSource()
      '----------------------------------------------------------------------------------------------

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

      If _ordenProducto <> 0 AndAlso Reglas.Publicos.Facturacion.FacturacionConservaOrdenProductos Then
         Dim filaseleccionada As Integer = _ordenProducto - 1
         Try
            Me.dgvProductos.FirstDisplayedScrollingRowIndex = 1
            Me.dgvProductos.Rows(filaseleccionada).Selected = True
         Catch ex As Exception
         End Try
      End If

      'importeBruto = precioProducto * cantidad
      importeNeto = precioNeto * cantidad

      'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
      If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) Then
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

      ' Aplico la lógica de Descuentos
      '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
      If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         If Not Me.chbModificaDescRecGralPorc.Checked Then
            _cantLineas = _ventasProductos.Count
            Dim descRec As Decimal = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                                  cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                                  cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                                  _cantLineas)
            If descRec <> 0 Then
               Me._DescRecGralPorc = descRec
               Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
            End If
         End If
      End If

      'Me.CalcularTotalProducto()
      Me.LimpiarCamposProductos()
      Me.CalcularTotales()
      Me.CalcularDatosDetalle()
      'Me.CalcularTotales()
      Me.OrdenarGrillaProductos()

      Me.tsbGrabar.Enabled = True
      If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
         Me.bscProducto2.Focus()
      Else
         Me.bscCodigoProducto2.Focus()
      End If

      Me.CambiarEstadoControlesDetalle(Me._clienteE IsNot Nothing)
      Me.CambiarEstadoControlesDetalleRT(Me._clienteE IsNot Nothing)

      HabilitaCotizacionDolar()

      _cargandoProductosAutomaticamente = False

   End Sub

   Private Sub SetProductosDataSource()
      dgvProductos.DataSource = _ventasProductos.ToArray().OrderBy(Function(x) x.Orden).ToArray()

      AjustarColumnasGrillaProductos()
      OrdenarGrillaProductos()
      ColorearCeldasGrillaProductos()

      If txtLetra.Text = "E" Then
         dtpFechaPagoExportacion.Enabled = _ventasProductos.Any(Function(vp) vp.Producto.EsServicio)
      End If
   End Sub
   Private Overloads Sub AjustarColumnasGrillaProductos()
      AjustarColumnasGrilla(dgvProductos, _tit)
      '      DisplayIndexProducto()
   End Sub
   Private Sub ColorearCeldasGrillaProductos()
      'Cuando eventualmente se migre DataGridView a Infragistics reemplazar este método por el evento de InitializeRow de IG.

      'Por el momento solo recorro las filas si está habilitado este parametro, ya que solo coloreo cuando es Oferta y así evito ingresar innecesariamente.
      If Reglas.Publicos.FacturacionResaltaProductosEnOferta Then
         For Each dgr In dgvProductos.Rows.OfType(Of DataGridViewRow)
            Dim dr = dgvProductos.FilaSeleccionada(Of Entidades.VentaProducto)(dgr)
            If dr.Producto.EsOferta = "SI" Then
               dgr.Cells(IdProducto.Name).Style.BackColor = Color.Yellow
               dgr.Cells(IdProducto.Name).Style.SelectionBackColor = Color.YellowGreen
               dgr.Cells(IdProducto.Name).Style.SelectionForeColor = Color.Black
               dgr.Cells(ProductoDesc.Name).Style.BackColor = Color.Yellow
               dgr.Cells(ProductoDesc.Name).Style.SelectionBackColor = Color.YellowGreen
               dgr.Cells(ProductoDesc.Name).Style.SelectionForeColor = Color.Black
            End If
         Next
      End If
   End Sub

   '-- REQ-35220.- -------------------------------------------------------------------------------------------------------
   Private Sub DisplayIndexProducto()
      DisplayIndex({IdProducto, ProductoDesc, DescripcionAtributo01, DescripcionAtributo02,
                    DescripcionAtributo03, DescripcionAtributo04, CantidadManual, Cantidad, NombreDeposito, NombreUbicacion, Conversion, Stock, Precio,
                   PrecioIVA, DescuentoRecargoPorc1, DescuentoRecargoPorc2, PrecioNeto, AlicuotaImpuesto, Importe,
                   ContribucionMarginalPorc, Kilos, Ubicacion, NombreListaPrecios, FechaActualizacion, IdCentroCosto,
                   NombreCentroCosto, Tamano, IdUnidadDeMedida, PrecioVentaPorTamano, NombreMoneda, Nota, IdOFerta})
   End Sub
   Private Sub DisplayIndex(columnas As IEnumerable(Of DataGridViewColumn))
      Dim pos = 0
      columnas.ToList().ForEach(Sub(c)
                                   DisplayIndex(c, pos)
                                End Sub)
   End Sub
   Private Sub DisplayIndex(column As DataGridViewColumn, ByRef pos As Integer)
      dgvProductos.Columns(column.Name).DisplayIndex = pos
      pos += 1
      Console.WriteLine(String.Format("{1} : {0}", column.Name, pos))
   End Sub
   '------------------------------------------------------------------------------------------------------------------------
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
      'If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
      '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
      '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
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

      If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoConIVA(precioNeto, alicuotaIVA, prod.PorcImpuestoInterno, prod.ImporteImpuestoInterno, prod.OrigenPorcImpInt) * cantidad
         Dim tmpImpInt = impuestoInterno  '((impuestoInterno - (prod.ImporteImpuestoInterno * cantidad)) * (1 + (descRecPorGeneral / 100))) + prod.ImporteImpuestoInterno * cantidad
         importeIVA = Decimal.Round(((precioNeto * cantidad) - tmpImpInt) - ((precioNeto * cantidad) - tmpImpInt) / (1 + alicuotaIVASobre100), Me._decimalesRedondeoEnPrecio)
      Else
         impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA, prod.PorcImpuestoInterno, prod.ImporteImpuestoInterno, prod.OrigenPorcImpInt) * cantidad
         importeIVA = Decimal.Round((precioNeto * cantidad) * alicuotaIVASobre100, Me._decimalesRedondeoEnPrecio)
      End If

   End Sub

   Private Sub CalculaValoresRT(cantidad As Decimal,
                                 alicuotaIVA As Decimal,
                                ByRef precioProducto As Decimal,
                                 descRecPorc1 As Decimal,
                                 descRecPorc2 As Decimal,
                                 descRecPorGeneral As Decimal,
                                ByRef precioNeto As Decimal,
                                ByRef importeBruto As Decimal,
                                ByRef importeIVA As Decimal,
                                ByRef importeTotalProducto As Decimal)

      Dim alicuotaIVASobre100 As Decimal = (alicuotaIVA / 100)

      Dim descRec1 As Decimal = Decimal.Round(precioProducto * descRecPorc1 / 100, Me._decimalesRedondeoEnPrecio)
      Dim descRec2 As Decimal = Decimal.Round((precioProducto + descRec1) * descRecPorc2 / 100, Me._decimalesRedondeoEnPrecio)
      Dim descRec As Decimal = Decimal.Round((precioProducto + descRec1 + descRec2) * descRecPorGeneral / 100, Me._decimalesRedondeoEnPrecio)

      precioNeto = precioProducto + descRec1 + descRec2 + descRec

      importeBruto = (precioProducto + descRec1 + descRec2) * cantidad

      'Lo calcula despues
      'importeTotalProducto = precioNeto * cantidad
      '------------------------------------
      'En Pantalla debe mostrar el total bruto (sin aplicar el descuento General)
      importeTotalProducto = importeBruto

      If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         importeIVA = Decimal.Round((precioNeto * cantidad) - (precioNeto * cantidad) / (1 + alicuotaIVASobre100), Me._decimalesRedondeoEnPrecio)
      Else
         importeIVA = Decimal.Round((precioNeto * cantidad) * alicuotaIVASobre100, Me._decimalesRedondeoEnPrecio)
      End If

   End Sub

   Private Sub InsertarProductoRT()

      Dim producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2RT.Text)
      If producto.ImporteImpuestoInterno <> 0 Then
         Throw New Exception(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se puede agregar el producto al Comprobane.", producto.IdProducto, producto.NombreProducto))
      End If

      Dim oLineaDetalle As Entidades.VentaProducto = New Entidades.VentaProducto()

      Dim precioCosto As Decimal = 0
      Dim precioLista As Decimal = 0
      Dim stock As Decimal = 0
      Dim Kilos As Decimal = 0
      Dim porcentajeIva As Decimal = 0
      Dim importeIva As Decimal = 0
      Dim importeBruto As Decimal = 0
      Dim precioNeto As Decimal = 0

      Dim alicuotaIVA As Decimal
      Dim IdMoneda As Integer

      If bscCodigoProducto2RT.FilaDevuelta Is Nothing Then
         precioCosto = Decimal.Parse(bscProducto2RT.FilaDevuelta.Cells("PrecioCosto").Value.ToString())
         precioLista = Decimal.Parse(bscProducto2RT.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscProducto2RT.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscProducto2RT.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      Else
         precioCosto = Decimal.Parse(bscCodigoProducto2RT.FilaDevuelta.Cells("PrecioCosto").Value.ToString())
         precioLista = Decimal.Parse(bscCodigoProducto2RT.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscCodigoProducto2RT.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscCodigoProducto2RT.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      End If

      'Precio de Costo, Opciones: ACTUAL o PROMPOND;<meses>
      If Publicos.VentasPrecioCosto <> "ACTUAL" Then
         Dim splVentasCalculoCosto() As String = Publicos.VentasPrecioCosto.Split(";"c)
         Dim otroPrecioCosto = 0D

         'Dejo preparado para distintas formas.
         If splVentasCalculoCosto(0) = "PROMPOND" Then
            Dim oCP = New Reglas.ComprasProductos()
            otroPrecioCosto = oCP.GetCostoPromedioPonderado(actual.Sucursal.Id, bscCodigoProducto2RT.Text,
                                                            Date.Today.AddMonths(Integer.Parse(splVentasCalculoCosto(1).ToString()) * (-1)),
                                                            Date.Today.UltimoSegundoDelDia(),
                                                            _decimalesRedondeoEnPrecio)
            If otroPrecioCosto <> 0 Then
               precioCosto = otroPrecioCosto
            End If
         Else
            Throw New Exception(String.Format("ATENCION: el sistema tiene configurado el Tipo de COSTO '{0}' (incorrecto), verifíquelo en Parametros.",
                                              splVentasCalculoCosto(0).ToString()))
         End If
      End If

      'Le quito el IVA que el producto tiene en forma predeterminada.
      If Reglas.Publicos.PreciosConIVA Then
         precioCosto = Decimal.Round(precioCosto / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
         precioLista = Decimal.Round(precioLista / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
      End If

      If IdMoneda = 2 Then
         precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      End If

      'If Me.txtUMRT.Text <> "" Then
      '   Dim Conversion As Decimal
      '   Dim oUM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
      '   Conversion = oUM.GetUno(Me.txtUMRT.Text).ConversionAKilos
      '   Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidadRT.Text) * Decimal.Parse(Me.txtTamanioRT.Text) * Conversion, 3)
      'End If

      Dim kilosProducto As Decimal = 0
      If bscCodigoProducto2RT.FilaDevuelta Is Nothing Then
         kilosProducto = Decimal.Parse(bscProducto2RT.FilaDevuelta.Cells("Kilos").Value.ToString())
      Else
         kilosProducto = Decimal.Parse(bscCodigoProducto2RT.FilaDevuelta.Cells("Kilos").Value.ToString())
      End If

      Dim cantidad As Decimal = CDec(Me.txtCantidadRT.Text)

      Kilos = Decimal.Round(cantidad * kilosProducto, 3)

      Dim cantidadManual As Decimal = CDec(Me.txtCantidadManualRT.Text)

      Dim idUnidadDeMedida As String = Me.cmbUM2RT.SelectedValue.ToString()
      Dim precioProducto As Decimal = Decimal.Parse(Me.txtPrecioRT.Text.Trim())

      'calculo el descuento total
      Dim descRecPorc1 As Decimal = DescRecPorc1RT
      Dim descRecPorc2 As Decimal = DescRecPorc2RT
      Dim descRecPorGeneral As Decimal = Decimal.Parse(Me.txtDescRecGralPorc.Text)

      'Fuerzo los calculos porque pudo no pasar Insertar sin los tab en los campos de descuento.
      Me.CalcularDescuentosProductosRT(precioLista)
      Me.CalcularTotalProductoRT(precioLista)

      Dim descRecargo As Decimal = DescRecRT
      Dim importeTotal As Decimal = TotalProductoRT

      Dim centroCosto As Entidades.ContabilidadCentroCosto = Nothing

      Me.CalculaValoresRT(Decimal.Parse(Me.txtCantidadManualRT.Text), alicuotaIVA, precioProducto, descRecPorc1, descRecPorc2, descRecPorGeneral,
                        precioNeto, importeBruto, importeIva, importeTotal)

      If Me.txtStockRT.Text.Length <> 0 Then
         stock = Decimal.Parse(Me.txtStockRT.Text)
      End If

      Dim moneda As Entidades.Moneda = New Reglas.Monedas().GetUna(IdMoneda)

      '--------------------------------------------------------------------------------
      '###############################
      '#          Lotes              #
      '###############################
      Dim coeficienteStockParaLote As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock
      If coeficienteStockParaLote = 0 And
         Not String.IsNullOrWhiteSpace(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario) Then
         Dim tipoSecundario As Entidades.TipoComprobante
         tipoSecundario = New Reglas.TiposComprobantes().GetUno(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario)
         coeficienteStockParaLote = tipoSecundario.CoeficienteStock
      End If

      'Dim _productoTemporal As Entidades.Producto = producto
      If producto.Lote And coeficienteStockParaLote <> 0 Then

         'Si es NCRE , valido fechas.. sino.. que exista
         If coeficienteStockParaLote > 0 Then
            '_productoLoteTemporal.Producto.IdSucursal = actual.Sucursal.Id
            producto.IdSucursal = actual.Sucursal.Id
            Using frm As New SeleccionNrosLotes(producto, cmbDepositoRT.ValorSeleccionado(Of Integer), cmbUbicacionRT.ValorSeleccionado(Of Integer), CDec(Me.txtCantidadRT.Text), coeficienteStockParaLote, _numeroOrden)
               If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                  Throw New Exception("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Venta.")
               Else
                  '# Me guardo los lotes seleccionados
                  _lotesSeleccionados = frm._lotesSeleccionados
                  Me.CargarLotesSeleccionados(_lotesSeleccionados, oLineaDetalle, producto)
               End If
            End Using
         Else

            '# Si el comprobante facturable no afecta stock, los nros de lotes no fueron solicitados, por lo que se le solicitan al usuario.
            '# Selección Automática
            Dim DispProdLotes As Decimal = New Reglas.ProductosLotes().GetDisponiblePorProducto(actual.Sucursal.Id, Me.bscCodigoProducto2RT.Text)
            If DispProdLotes = 0 Then
               Throw New Exception("No existen Lotes para el Producto seleccionado.")
            End If
            If DispProdLotes < CDec(Me.txtCantidad.Text) Then
               Throw New Exception("El Producto tiene en Stock " & DispProdLotes.ToString() & " quedaría en Cantidad Negativa, No es posible con Lotes.")
            End If

            '# Selección Manual
            If Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
               producto.IdSucursal = actual.Sucursal.Id
               Using frm As New SeleccionNrosLotes(producto, cmbDepositoRT.ValorSeleccionado(Of Integer), cmbUbicacionRT.ValorSeleccionado(Of Integer), CDec(Me.txtCantidadRT.Text), coeficienteStockParaLote, _lotesSeleccionados)
                  If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                     Throw New Exception("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Venta.")
                  Else
                     _lotesSeleccionados = frm._lotesSeleccionados
                     Me.CargarLotesSeleccionados(_lotesSeleccionados, oLineaDetalle, producto, precioCosto, IdMoneda)
                  End If
               End Using
            End If
         End If

      Else
         If producto.Lote AndAlso
            coeficienteStockParaLote = 0 AndAlso
            DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico AndAlso
            Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
            MessageBox.Show("El comprobante " & DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).DescripcionAbrev.ToString() & " No permite productos con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If
      End If

      '-- REQ-32676.- --------------------------------------
      Dim costoParaGrabar As Decimal
      If producto.PrecioPorEmbalaje Then
         costoParaGrabar = precioCosto / producto.Embalaje
         precioLista = precioLista / producto.Embalaje
      Else
         costoParaGrabar = precioCosto
      End If
      '-----------------------------------------------------

      Dim idFormula As Integer = 0
      Dim nombreFormula = String.Empty

      If Not String.IsNullOrEmpty(bscCodigoProducto2RT.Tag.ToString()) Then
         idFormula = Integer.Parse(bscCodigoProducto2RT.Tag.ToString())
      End If

      Me.CargarUnArticulo(oLineaDetalle,
                          producto,
                          Me.bscProducto2RT.Text,
                          descRecPorc1,
                          descRecPorc2,
                          descRecargo,
                          precioProducto,
                          cantidad,
                          cantidadManual,
                          importeTotal * Decimal.Parse(Me.txtCantidadRT.Text),
                          stock,
                          precioCosto,
                          costoParaGrabar,
                          precioLista,
                          Kilos,
                          Me._tipoImpuestoIVA,
                          alicuotaIVA,
                          importeIva,
                          0,
                          Me.dtpFechaActPrecios.Value,
                          0,
                          0,
                          Entidades.OrigenesPorcImpInt.BRUTO,
                          centroCosto,
                          0,
                          0,
                          idUnidadDeMedida,
                          moneda,
                          idFormula,
                          nombreFormula,
                          0,
                          Nothing)

      '# Incremento el orden
      Me._numeroOrden += 1

      'Selecciono los nros. de serie SOLO si el producto permite
      If coeficienteStockParaLote <> 0 Then
         If oLineaDetalle.Producto.NroSerie Then
            Dim nrosSerie As DataTable
            Dim onrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()

            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 Then
               nrosSerie = New Reglas.ProductosNrosSerie().GetNrosSerieProductoClienteVendido(actual.Sucursal.Id, Me.bscCodigoProducto2RT.Text, _clienteE.IdCliente)

            Else
               '-- REQ-32489.- -------------------------------------------------------------------------
               nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, cmbDepositoRT.ValorSeleccionado(Of Integer), cmbUbicacionRT.ValorSeleccionado(Of Integer), bscCodigoProducto2RT.Text)
            End If

            Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidadRT.Text), 0).ToString())
            Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, oLineaDetalle.Producto, nrosSerie)
            If sel.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
               ShowMessage("Si el producto esta marcado que utiliza Nro. de Serie debe seleccionar los numeros")
               Me.btnInsertar.Focus()
               Exit Sub
            Else
               For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie

                  Dim noFueAgregado As Boolean
                  noFueAgregado = _ventasProductos.All(Function(vp)
                                                          If vp.Producto.IdProducto = ns.Producto.IdProducto Then
                                                             Return Not vp.Producto.NrosSeries.Any(Function(x) x.NroSerie = ns.NroSerie)
                                                          End If
                                                          Return True
                                                       End Function)

                  '# Si el producto ya fue agregado a la grilla, no dejo agregarlo nuevamente
                  If Not noFueAgregado Then
                     ShowMessage(String.Format("ATENCIÓN: El Producto: {0} Nro. Serie: {1} ya fue agregado.", ns.Producto.IdProducto, ns.NroSerie))
                     Exit Sub
                  End If
                  ns.OrdenVenta = _numeroOrden
                  oLineaDetalle.Producto.NrosSeries.Add(ns)
               Next
            End If
         End If
      End If

      '# Guardo la Fecha de Devolución SOLO si el tipo de comprobante lo requiere
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).SolicitaFechaDevolucion Then
         '# Vuelvo a calcular la fecha
         Me.CalcularFechaDiasDevolucion()
         oLineaDetalle.FechaDevolucion = Me.dtpFechaDevolucion.Value
      End If

      '# Si el producto Es Compuesto y NO tiene Fórmula predeterminada, el sistema no debe permitir ingresarlo.
      If oLineaDetalle.Producto.EsCompuesto AndAlso
         Not oLineaDetalle.Producto.IdFormula > 0 Then
         ShowMessage(String.Format("ATENCIÓN: El Producto: {0} {1} es Compuesto y no tiene fórmula predeterminada. Debe configurarla primero para poder ingresarlo.",
                                   oLineaDetalle.Producto.IdProducto,
                                   oLineaDetalle.Producto.NombreProducto))
         Exit Sub
      End If
      With oLineaDetalle
         .IdDeposito = depOrigenRT
         .NombreDeposito = cmbDepositoRT.Text
         .IdUbicacion = ubiOrigenRT
         .NombreUbicacion = cmbUbicacionRT.Text
      End With

      oLineaDetalle.Orden = Me._numeroOrden
      Me._ventasProductos.Add(oLineaDetalle)

      Me.dgvRemitoTransp.DataSource = Me._ventasProductos.ToArray()
      Me.dgvRemitoTransp.Refresh()

      'Sin Facturables se para en la ultima fila, sino, primero.
      If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 Then
         Me.dgvRemitoTransp.FirstDisplayedScrollingRowIndex = Me.dgvRemitoTransp.Rows.Count - 1
         Me.dgvRemitoTransp.Rows(Me.dgvRemitoTransp.Rows.Count - 1).Selected = True
      Else
         Me.dgvRemitoTransp.FirstDisplayedScrollingRowIndex = 0
         Me.dgvRemitoTransp.Rows(0).Selected = True
      End If

      Me.LimpiarCamposProductosRT()

      Me.CalcularTotales()
      Me.CalcularDatosDetalle()

      Me.CalcularTotalRemitoTransporte()

      Me.tsbGrabar.Enabled = True
      Me.bscCodigoProducto2RT.Focus()

   End Sub

   Private Sub InsertarObservacion()

      Dim oLineaDetalle As Entidades.VentaObservacion = New Entidades.VentaObservacion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Linea = Me.ugObservaciones.Rows.Count + 1
         .Observacion = Me.bscObservacionDetalle.Text
         .IdTipoObservacion = Short.Parse(cmbTipoObservacion.SelectedValue.ToString())
         .DescripcionTipoObservacion = cmbTipoObservacion.Text
      End With

      Me._ventasObservaciones.Add(oLineaDetalle)

      SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())

      Me.LimpiarCamposObservDetalles()

      'Me.bscObservacionDetalle.Focus()

   End Sub

   Private Sub EliminarLineaProducto()
      EliminarLineaProducto(dgvProductos.FilaSeleccionada(Of Entidades.VentaProducto)())
   End Sub

   Private Sub EliminarLineaProducto(vpro As Entidades.VentaProducto)

      Dim producto As Entidades.Producto = vpro.Producto

      If _ventasProductosFormulas.ContainsKey(vpro) Then
         _ventasProductosFormulas.Remove(vpro)
      End If

      For Each vpl As Entidades.VentaProductoLote In _productosLotes.ToArray()
         If vpl.IdProducto = vpro.IdProducto AndAlso vpl.Orden = vpro.Orden Then
            _productosLotes.Remove(vpl)
         End If
      Next

      Me._ventasProductos.Remove(vpro)

      '-- REQ-35220.- -------------------------------------------------------------------------------
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() = 0 Then
         If _tit.ContainsKey("DescripcionAtributo01") Then _tit.Remove("DescripcionAtributo01")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() = 0 Then
         If _tit.ContainsKey("DescripcionAtributo02") Then _tit.Remove("DescripcionAtributo02")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() = 0 Then
         If _tit.ContainsKey("DescripcionAtributo03") Then _tit.Remove("DescripcionAtributo03")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() = 0 Then
         If _tit.ContainsKey("DescripcionAtributo04") Then _tit.Remove("DescripcionAtributo04")
      End If
      '----------------------------------------------------------------------------------------------
      If _tit.ContainsKey("NombreDeposito") Then _tit.Remove("NombreDeposito")
      If _tit.ContainsKey("NombreUbicacion") Then _tit.Remove("NombreUbicacion")
      '----------------------------------------------------------------------------------------------
      SetProductosDataSource()

      'Me.OrdenarGrillaProductos()

      Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
      If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
         Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.IdRubro = producto.IdRubro Then
               cantidad = vp.Cantidad
            End If
         Next
         Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, producto, cantidad, Me._decimalesEnTotales)
         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.IdRubro = producto.IdRubro Then
               vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
               If calculaDescuentoRecargo2 Then
                  vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
               End If
            End If
            vp.DescuentoRecargo = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                             vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, vp.Cantidad)
         Next
      End If

      ' Aplico la lógica del Desc/Rec por Cantidad de Lineas
      '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
      If Not Me.chbModificaDescRecGralPorc.Checked Then
         _cantLineas = _ventasProductos.Count
         Me._DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                          cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                          cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                          _cantLineas)
         If Me._DescRecGralPorc <> 0 Then
            txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
         End If
      End If

      If Me.dgvProductos.Rows.Count > 0 Then

         'sin facturables se para en la ultima fila, sino, primero.
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

      HabilitaCotizacionDolar()

      _ordenProducto -= 1

   End Sub

   Private Sub EliminarLineaProductoRT()

      Me._ventasProductos.RemoveAt(Me.dgvRemitoTransp.SelectedRows(0).Index)
      Me.dgvRemitoTransp.DataSource = Me._ventasProductos.ToArray()

      If Me.dgvRemitoTransp.Rows.Count > 0 Then
         'Sin Facturables se para en la ultima fila, sino, primero.
         If Me._comprobantesSeleccionados Is Nothing OrElse Me._comprobantesSeleccionados.Count = 0 Then
            Me.dgvRemitoTransp.FirstDisplayedScrollingRowIndex = Me.dgvRemitoTransp.Rows.Count - 1
            Me.dgvRemitoTransp.Rows(Me.dgvRemitoTransp.Rows.Count - 1).Selected = True
         Else
            Me.dgvRemitoTransp.FirstDisplayedScrollingRowIndex = 0
            Me.dgvRemitoTransp.Rows(0).Selected = True
         End If

      End If

      Me.CalcularTotales()
      Me.CalcularDatosDetalle()

      Me.CalcularTotalRemitoTransporte()

   End Sub

   Private Sub EliminarLineaObservacion()
      If ugObservaciones.ActiveRow IsNot Nothing AndAlso
         ugObservaciones.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugObservaciones.ActiveRow.ListObject) Is Entidades.VentaObservacion Then
         Me._ventasObservaciones.Remove(DirectCast(ugObservaciones.ActiveRow.ListObject, Entidades.VentaObservacion))
         SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())
      End If

   End Sub

   Private Function ConvertirComprobantesFacturables(selec As List(Of Entidades.Venta)) As List(Of Entidades.Compra)
      Return selec.ConvertAll(Function(c) New Entidades.Compra() _
                                         With {.IdSucursal = c.IdSucursal,
                                               .TipoComprobante = c.TipoComprobante,
                                               .Letra = c.LetraComprobante,
                                               .CentroEmisor = c.CentroEmisor,
                                               .NumeroComprobante = c.NumeroComprobante,
                                               .Proveedor = c.Proveedor,
                                               .Fecha = c.Fecha,
                                               .Comprador = c.Vendedor,
                                               .FormaPago = c.FormaPago})
   End Function

   Private Sub CargarComprobantesFacturables(selec As List(Of Entidades.Compra))
      CargarComprobantesFacturables(selec.ConvertAll(Function(c) New Entidades.Venta() _
                                                                With {.IdSucursal = c.IdSucursal,
                                                                      .TipoComprobante = c.TipoComprobante,
                                                                      .LetraComprobante = c.Letra,
                                                                      .CentroEmisor = c.CentroEmisor,
                                                                      .NumeroComprobante = c.NumeroComprobante,
                                                                      .Proveedor = c.Proveedor,
                                                                      .Fecha = c.Fecha,
                                                                      .Vendedor = c.Comprador,
                                                                      .FormaPago = c.FormaPago}))
   End Sub
   Private Sub CargarComprobantesFacturables(selec As List(Of Entidades.Venta))

      _comprobantesSeleccionados = New List(Of Entidades.Venta)

      Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)
      If tipoComp IsNot Nothing AndAlso tipoComp.GeneraObservConInvocados Then
         _ventasObservaciones.Clear()
      End If

      Dim listaDeIdVendedores = selec.Where(Function(v) v.Vendedor IsNot Nothing).Select(Function(v) v.Vendedor.IdEmpleado).Distinct()
      Dim listaDeIdCajasPedid = selec.Where(Function(v) v.Caja IsNot Nothing).Select(Function(v) v.Caja.IdCaja).Distinct()

      '' '### >>> PR-34956 Señalar y PE-34958 Vialparking
      '' '        Al invocar comprobantes en dolares que pregunte si desea o no actualizar los precios con  cotizacion actual del dolar
      ''Dim cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO

      ''If selec.Count > 0 AndAlso selec.First().IdMoneda = Entidades.Moneda.Dolar AndAlso
      ''   txtCotizacionDolar.ValorNumericoPorDefecto(0D) <> selec.First().CotizacionDolar Then
      ''   Dim primerInvocado = selec.First()

      ''   If selec.Any(Function(v) v.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString()) Then
      ''      cotizacionDolarDesde = Reglas.Publicos.Facturacion.CotizacionDolarPedidoInvocado
      ''   Else
      ''      cotizacionDolarDesde = Reglas.Publicos.Facturacion.CotizacionDolarComprobanteInvocado
      ''   End If

      ''   If cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.PREGUNTAR Then
      ''      Dim stbPregunta = New StringBuilder()
      ''      stbPregunta.AppendFormatLine("La valoración del dolar del comprobante invocado ({0}) difiere de la del comprobante invocador ({1})",
      ''                                   primerInvocado.TipoComprobante.Descripcion, cmbTiposComprobantes.Text).AppendLine()
      ''      stbPregunta.AppendFormatLine("   {0}: {1:N2}", primerInvocado.TipoComprobante.Descripcion, primerInvocado.CotizacionDolar)
      ''      stbPregunta.AppendFormatLine("   {0}: {1:N2}", cmbTiposComprobantes.Text, txtCotizacionDolar.ValorNumericoPorDefecto(0D)).AppendLine()

      ''      stbPregunta.AppendFormatLine("¿Desea tomar la valoración del dolar del {0}?", primerInvocado.TipoComprobante.Descripcion)
      ''      If ShowPregunta(stbPregunta.ToString()) = DialogResult.Yes Then
      ''         cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.INVOCADO
      ''      Else
      ''         cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO
      ''      End If
      ''   End If
      ''End If
      ''If cotizacionDolarDesde = Entidades.Publicos.CotizacionDolarComprobanteInvocado.INVOCADO Then
      ''   txtCotizacionDolar.SetValor(selec.First().CotizacionDolar)
      ''End If
      '' '### <<< PR-34956 Señalar y PE-34958 Vialparking
      cmbDirecciones.SelectedValue = selec.First().IdDomicilio.IfNull()

      For Each v As Entidades.Venta In selec
         Me._comprobantesSeleccionados.Add(v)

         If Me._cantMaxItemsObserv > 0 AndAlso tipoComp IsNot Nothing AndAlso tipoComp.GeneraObservConInvocados Then
            'Me.bscObservacionDetalle.Text = "Invoco: " & v.TipoComprobante.Descripcion & " ´" & v.LetraComprobante & "´ " & v.CentroEmisor.ToString("0000") & "-" & v.NumeroComprobante.ToString("00000000") & ". Emision: " & v.Fecha.ToString("dd/MM/yyyy")
            'v.NumeroOrdenCompra
            Dim formato As String = "Invoco: {0} ´{1}´ {2:0000}-{3:00000000}. Emision: {4:dd/MM/yyyy}"
            If v.NumeroOrdenCompra <> 0 Then
               formato = String.Concat(formato, " - O. de Compra: {5}")
            End If
            Me.bscObservacionDetalle.Text = String.Format(formato,
                                                          v.TipoComprobante.Descripcion,
                                                          v.LetraComprobante,
                                                          v.CentroEmisor,
                                                          v.NumeroComprobante,
                                                          v.Fecha,
                                                          v.NumeroOrdenCompra).Truncar(100)

            cmbTipoObservacion.SelectedValue = _idTipoObservacion
            Me.InsertarObservacion()

            '-.PE-32868.-
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImportaObservGrales Then

               If Not v.Observacion = Nothing Then
                  '-- REQ-34233 (roll-back 33806).- ---------
                  Me.bscObservacion.Text = v.Observacion
                  '------------------------------------------
                  Dim ObsGral = New Entidades.VentaObservacion
                  '-- REQ-34233 (roll-back 33806).- ---------
                  With ObsGral
                     .IdTipoObservacion = _idTipoObservacion
                     .DescripcionTipoObservacion = cmbTipoObservacion.Text
                     .Observacion = v.Observacion
                  End With

                  '------------------------------------------
                  ObsGral.Linea = Me.ugObservaciones.Rows.Count + 1

                  Me._ventasObservaciones.Add(ObsGral)
               End If
            End If
         End If

         '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
         If Not Me.chbModificaDescRecGralPorc.Checked Then
            If tipoComp IsNot Nothing AndAlso tipoComp.CargaDescRecGralActual Then
               txtDescRecGralPorc.Text = v.DescuentoRecargoPorc.ToString(txtDescRecGralPorc.Formato)
               _clienteTieneDescRec = v.DescuentoRecargoPorc <> 0
            End If
         End If

      Next

      If Me._comprobantesSeleccionados.Count <> 0 Then
         '-- Vendedores.- ---------------------------------------------------------------------------------
         If Not _mantenerVendedor Then
            Select Case Reglas.Publicos.Facturacion.MantieneVendedorInvocados
               Case Entidades.Publicos.VendedorComprobanteInvocado.NO.ToString()
                  cmbVendedor.SelectedIndex = -1
               Case Entidades.Publicos.VendedorComprobanteInvocado.CLIENTE.ToString()
                  Dim oCliente = New Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
                  cmbVendedor.SelectedValue = oCliente.Vendedor.IdEmpleado
               Case Entidades.Publicos.VendedorComprobanteInvocado.INVOCADO.ToString()
                  If _comprobantesSeleccionados(0).Vendedor IsNot Nothing Then
                     cmbVendedor.SelectedValue = Me._comprobantesSeleccionados(0).Vendedor.IdEmpleado
                  End If
            End Select
         End If

         '-- Cajas.- --------------------------------------------------------------------------------------
         If listaDeIdCajasPedid.Count = 1 Then
            cmbCajas.SelectedValue = _comprobantesSeleccionados(0).Caja.IdCaja
         ElseIf listaDeIdCajasPedid.Count > 1 Then
            cmbCajas.SelectedIndex = -1
         End If
         '-------------------------------------------------------------------------------------------------
         '-- Incoterm.- --
         If _comprobantesSeleccionados(0).IdIcotermExportacion IsNot Nothing Then
            cmbClausulaVentas.SelectedValue = _comprobantesSeleccionados(0).IdIcotermExportacion
         Else
            cmbClausulaVentas.SelectedIndex = -1
         End If
         '-- Destino.- --
         If _comprobantesSeleccionados(0).IdDestinoExportacion IsNot Nothing Then
            cmbDestinoComprobante.SelectedValue = _comprobantesSeleccionados(0).IdDestinoExportacion
         Else
            cmbDestinoComprobante.SelectedIndex = -1
         End If
         '-------------------------------------------------------------------------------------------------

         If Me._InvocaPedido Then
            If Reglas.Publicos.MantieneFormaPagoPedidosInvocados Then
               Me.cmbFormaPago.SelectedValue = Me._comprobantesSeleccionados(0).FormaPago.IdFormasPago
            End If
            If Me._comprobantesSeleccionados(0).Proveedor IsNot Nothing AndAlso Me._comprobantesSeleccionados(0).Proveedor.IdProveedor <> 0 Then
               Me.bscCodigoProveedor.Text = Me._comprobantesSeleccionados(0).Proveedor.CodigoProveedor.ToString()
               Me.bscCodigoProveedor.PresionarBoton()
               'Me.bscProveedor.Text = Me._comprobantesSeleccionados(0).Proveedor.NombreProveedor.ToString()
            End If
         Else
            If Reglas.Publicos.MantieneFormaPagoInvocados Then
               Me.cmbFormaPago.SelectedValue = Me._comprobantesSeleccionados(0).FormaPago.IdFormasPago
            End If
         End If

         If _comprobantesSeleccionados(0).ClienteVinculado IsNot Nothing Then
            bscCodigoClienteVinculado.Text = _comprobantesSeleccionados(0).CodigoClienteVinculado.ToString()
            bscCodigoClienteVinculado.PresionarBoton()
         Else
            bscCodigoClienteVinculado.Text = String.Empty
            bscCodigoClienteVinculado.Selecciono = False
            bscCodigoClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado

            bscClienteVinculado.Text = String.Empty
            bscClienteVinculado.Selecciono = False
            bscClienteVinculado.Permitido = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado
         End If

         If tipoComp IsNot Nothing AndAlso tipoComp.CoeficienteValores = -1 Then
            Me.txtEfectivo.Text = Me._comprobantesSeleccionados(0).ImportePesos.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
            txtImporteDolares.SetValor(_comprobantesSeleccionados(0).ImporteDolares)
            Me.txtTickets.Text = Me._comprobantesSeleccionados(0).ImporteTickets.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
            If Me._comprobantesSeleccionados(0).CuentaBancariaTransfBanc.IdCuentaBancaria > 0 Then
               Me.txtTransferenciaBancaria.Text = Me._comprobantesSeleccionados(0).ImporteTransfBancaria.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
               Me.bscCuentaBancariaTransfBanc.Text = Me._comprobantesSeleccionados(0).CuentaBancariaTransfBanc.NombreCuenta.ToString()
               Me.bscCuentaBancariaTransfBanc.PresionarBoton()
            End If
            If Me._comprobantesSeleccionados(0).Tarjetas.Count > 0 Then
               Me.txtTarjetas.Text = Me._comprobantesSeleccionados(0).ImporteTarjetas.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
               _tarjetas = Me._comprobantesSeleccionados(0).Tarjetas
               Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()
               If tipoComp.CoeficienteValores = -1 AndAlso tipoComp.Tipo = "VENTAS" AndAlso _tarjetas.Count > 0 Then
                  btnInsertarTarjeta.Enabled = False
               End If
               Me.CalcularPagos(_recalcularEfectivoAlCargarTarjeta)
            End If
            Me.CalcularPagos(False)
         End If

         '# Cliente Genérico del primer pedido invocado
         With _comprobantesSeleccionados(0)
            If _clienteE.EsClienteGenerico Then
               'If .Cliente.EsClienteGenerico Then
               Me.txtNombreClienteGenerico.Text = .NombreCliente
               Me.txtDireccionClienteGenerico.Text = .Direccion
               Me.txtNroDocCliente.Text = .NroDocCliente.ToString()
               Me.txtCUIT.Text = .Cuit
               Me.bscCodigoLocalidad.Text = .IdLocalidad.ToString()
               If .TipoDocCliente IsNot Nothing Then
                  Me.cmbTipoDoc.SelectedValue = .TipoDocCliente
               Else
                  Me.cmbTipoDoc.SelectedValue = Reglas.Publicos.TipoDocumentoCliente
               End If
            End If
         End With

         '# Se selecciona la lista de precios del primer producto, del primer pedido invocado
         If _comprobantesSeleccionados.Any() AndAlso _comprobantesSeleccionados.First().VentasProductos.Any() Then
            Me.cmbListaDePrecios.SelectedValue = _comprobantesSeleccionados(0).VentasProductos(0).IdListaPrecios
         End If
      End If

      tbcDetalle.Tabs("tbpAdicionales").Selected = True
      Dim rClientes As Reglas.Clientes = New Reglas.Clientes

      If Me._comprobantesSeleccionados(0).IdPaciente.HasValue Then
         bscCodigoPaciente.Text = rClientes.GetUno(_comprobantesSeleccionados(0).IdPaciente.Value).CodigoCliente.ToString()
         bscCodigoPaciente.PresionarBoton()
      End If
      If Me._comprobantesSeleccionados(0).IdDoctor.HasValue Then
         bscCodigoDoctor.Text = rClientes.GetUno(_comprobantesSeleccionados(0).IdDoctor.Value).CodigoCliente.ToString()
         bscCodigoDoctor.PresionarBoton()
      End If
      If Me._comprobantesSeleccionados(0).FechaCirugia.HasValue Then
         chbFechaCirugia.Checked = True
         dtpFechaCirugia.Value = Date.Parse(_comprobantesSeleccionados(0).FechaCirugia.ToString())
      End If

      If tbcDetalle.Tabs("tbpProductos").Visible Then
         tbcDetalle.Tabs("tbpProductos").Selected = True
      Else
         tbcDetalle.Tabs("tbpRemitoTransp").Selected = True
      End If

      Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados

      Me.OrdenarGrillaFacturables()

      CalculosDescuentosRecargos1.HabilitaDescuentoRecargoProducto = Not selec.Any(Function(v) Not v.TipoComprobante.CargaDescRecActual)

   End Sub

   Private Sub CargarContactosFacturables(selec As List(Of Entidades.Venta))
      _ventasContactos.Clear()
      For Each venta As Entidades.Venta In selec
         For Each contacto As Entidades.VentaClienteContacto In venta.VentasContactos
            Dim existe As Boolean = False
            For Each contactoCargado As Entidades.ClienteContacto In _ventasContactos
               If contactoCargado.IdCliente = contacto.IdCliente AndAlso contactoCargado.IdContacto = contacto.IdContacto Then
                  existe = True
               End If
            Next
            If Not existe Then
               _ventasContactos.Add(contacto.Contacto)
            End If
         Next
      Next
      ugContactos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
   End Sub

   Private Sub CargarProductosFacturables(selec As List(Of Entidades.Venta))

      Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)

      'limpio todos los productos de la grilla
      Me._ventasProductos = Nothing
      Me._ventasProductos = New List(Of Entidades.VentaProducto)

      Dim DescRec1 As Decimal, DescRec2 As Decimal
      Dim PrecioNeto As Decimal

      'creo una coleccion para probar si existe codigos repetidos
      Dim codigos As List(Of String) = New List(Of String)

      Dim Producto As Entidades.Producto

      Dim oSR As Reglas.SubRubros = New Reglas.SubRubros()

      Dim oCSR As Reglas.ClientesDescuentosSubRubros = New Reglas.ClientesDescuentosSubRubros()

      Dim blnEntrar As Boolean

      Dim CoefVal As Integer = If(tipoComp IsNot Nothing, tipoComp.CoeficienteValores, 1)

      'Verifico la cantidad de Coeficientes de Valor seleccionados.
      'Si hay solo uno son todos positivos o negativos, evaluo con la lógica pre-existentes.
      'Si hay más de un coeficiente de valor seleccionado signitica que hay positivos y negativos seleccionados por lo que
      'no debería cambiar el coeficiente de valor del comprobante seleccionado en el combo ya que se trataría por ejemplo:
      'de una Cotización que seleccionó un Remito y una Devolución de Remito, entonces tendremos una línea positiva y una negativa
      If selec.Select(Function(v) v.TipoComprobante.CoeficienteValores).Distinct().Count < 2 Then
         'Si el invocador es un comprobante con Coef de valores 1 e invoca un comprobante con Coef -1 (Ej: ND invoca NC)
         If CoefVal = 1 And selec.Count > 0 Then
            If selec(0).TipoComprobante.CoeficienteValores = -1 Then
               CoefVal = -1
            End If
         End If

         'Si el invocador es una NCRED y A su vez Invoca Un comprobante Positivo debe multiplicar por 1 en lugar de -1.
         'Si es Factura es 1 asi que queda como invoca.
         If CoefVal = -1 And selec.Count > 0 Then
            If selec(0).TipoComprobante.CoeficienteValores = 1 Then
               CoefVal = 1
            End If
         End If
      End If

      Dim productosInactivos As StringBuilder = New StringBuilder()
      Dim algunInactivo As Boolean = False
      For Each v As Entidades.Venta In selec
         For Each vp As Entidades.VentaProducto In v.VentasProductos
            If Not vp.Producto.Activo Then
               productosInactivos.AppendFormatLine("     {0} - {1}", vp.Producto.IdProducto, vp.Producto.NombreProducto)
               algunInactivo = True
            End If
         Next
      Next

      If algunInactivo Then
         Throw New Exception(String.Format("No se puede invocar porque los siguientes productos están inactivos:{0}{0}{1}", Environment.NewLine, productosInactivos.ToString()))
      End If

      Dim facturacionInvocarPedidosDeOtrasSucursales As Boolean = Reglas.Publicos.Facturacion.FacturacionInvocarPedidosDeOtrasSucursales

      For Each v As Entidades.Venta In selec

         'En REMITO no tendria sentido que haya carga el descuento.
         'Poner el recargo general solo si cargo uno, si pone mas, se pierde.
         '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
         If Not Me.chbModificaDescRecGralPorc.Checked Then
            If selec.Count = 1 And Not v.TipoComprobante.CargaDescRecActual Then
               Me.txtDescRecGralPorc.Text = v.DescuentoRecargoPorc.ToString()
               _clienteTieneDescRec = v.DescuentoRecargoPorc <> 0
               _DescRecGralPorc = Decimal.Parse(txtDescRecGralPorc.Text)
            End If
         End If

         For Each vp As Entidades.VentaProducto In v.VentasProductos

            vp.Automatico = False

            '--REQ-32986.- ---------------------------------
            vp.InvocaDesdePedido = _InvocaPedido
            '-----------------------------------------------


            blnEntrar = True

            Producto = New Reglas.Productos().GetUno(vp.Producto.IdProducto)

            vp.Cantidad = vp.Cantidad * CoefVal

            'Busco los Nros de Serie
            Dim NumerosSerie As String = String.Empty
            Dim PNS As List(Of Eniac.Entidades.ProductoNroSerie) = New List(Of Eniac.Entidades.ProductoNroSerie)

            ''PE-36645 >>> Si el producto tiene NS al invocar y solo copiar me descuenta el stock de los prod pero egresa 2 veces el mismo NS
            ''Continuar análisis del problema desde acá. r12848 -> 25021/26051
            ''Luego de agregar este código se agregó reemplazó el GetFacturable por GetUno. No sería necesario buscar nuevamente
            ''los numeros de serie. Hay que probar casos de prueba de los pendientes antes mensionados aparte de los de ahora.
            ''Advertencia de retura galáctiva. Borrar este comentario al resolver.
            'If Reglas.Publicos.Facturacion.Impresion.VentasImpresionVisualizaNrosSerie Then
            '   PNS = New Reglas.ProductosNrosSerie().GetNrosSerieProducto_ComprobanteVenta(v.IdSucursal,
            '                                                                               v.TipoComprobante.IdTipoComprobante,
            '                                                                               v.LetraComprobante,
            '                                                                               v.CentroEmisor,
            '                                                                               v.NumeroComprobante,
            '                                                                               vp.IdProducto)
            '   vp.Producto.NrosSeries = PNS
            'End If
            ''PE-36645 <<<

            Dim NroSerie As Entidades.ProductoNroSerie
            If Reglas.Publicos.Facturacion.Impresion.VentasImpresionVisualizaNrosSerie Then
               If vp.VentasProductosNrosSerie.Count > 0 Then
                  For Each ns As Entidades.VentaProductoNroSerie In vp.VentasProductosNrosSerie
                     NroSerie = New Entidades.ProductoNroSerie()
                     NroSerie.TipoComprobante.IdTipoComprobante = ns.IdTipoComprobante
                     NroSerie.Letra = ns.Letra
                     NroSerie.CentroEmisor = Short.Parse(ns.CentroEmisor.ToString())
                     NroSerie.NumeroComprobante = ns.NumeroComprobante
                     NroSerie.Producto = New Reglas.Productos().GetUno(ns.IdProducto)
                     NroSerie.NroSerie = ns.NroSerie
                     vp.Producto.NrosSeries.Add(NroSerie)
                  Next
               End If
            End If

            'tengo que recalcular el impuesto interno del producto por si cambio
            If Producto.PorcImpuestoInterno <> vp.PorcImpuestoInterno Then
               Dim precio As Decimal
               If Me._clienteE.CategoriaFiscal.IvaDiscriminado Then
                  precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto,
                                                                                vp.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt)
                  precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(vp.Precio, vp.AlicuotaImpuesto,
                                                                                Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
               Else
                  precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto,
                                                                                Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
               End If
               If precio <> 0 Then
                  vp.Precio = precio
               End If
               vp.PorcImpuestoInterno = Producto.PorcImpuestoInterno
               vp.ImporteImpuestoInterno = Me.GetNuevoImporteImpuestoInterno(vp, Producto)
            End If

            Dim utilizarAlicuota2 As Boolean = Reglas.Publicos.ProductoUtilizaAlicuota2 AndAlso cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal)().ResuelveUtilizaAlicuota2Producto(_clienteE) AndAlso vp.Producto.Alicuota2.HasValue
            If utilizarAlicuota2 Then
               'Dim precio As Decimal = vp.Precio

               'If Not _categoriaFiscalEmpresa.IvaDiscriminado Or Not _clienteE.CategoriaFiscal.IvaDiscriminado Then
               '   precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precio, vp.AlicuotaImpuesto,
               '                                                                 vp.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt)
               '   'precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precio, vp.Producto.Alicuota2.Value,
               '   '                                                              Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
               'End If

               ''vp.Precio =
               vp.AlicuotaImpuesto = vp.Producto.Alicuota2.Value
            End If


            'Los precios en la BASE siempre se guardan SIN IVA

            'Le agrego el IVA porque al momento de la grabacion se lo saca si cumple con esto. Se devuelve SIN IVA
            '1.
            'If Publicos.PreciosConIVA Then
            '   vp.PrecioLista = Decimal.Round((vp.PrecioLista * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
            '   vp.Costo = Decimal.Round((vp.Costo * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
            'End If
            Dim oc As Entidades.OrdenCompra
            If v.NumeroOrdenCompra <> 0 Then
               Dim rg As Reglas.OrdenesCompra = New Reglas.OrdenesCompra()
               oc = rg.GetUno(actual.Sucursal.Id, v.NumeroOrdenCompra, False)
            Else
               oc = New Entidades.OrdenCompra()
            End If

            'Indica si el comprobante elegido mantene el precio (PRESUPUESTO) o hay que cargar el actual (REMITO).
            'reviso si la Orden de Compra respeta precios, no tomo en cuenta los otros seteos

            'si tiene una Orden de Compra y la misma respeta precios, NO ME IMPORTAN LOS OTROS SETEOS
            If oc IsNot Nothing AndAlso oc.RespetaPreciosOrdenCompra Then
               If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                  If vp.PrecioConImpuestos = 0 Then
                     'vp.Precio = Decimal.Round((vp.Precio * (1 + vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), Me._decimalesRedondeoEnPrecio)
                     vp.Precio = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), _decimalesRedondeoEnPrecio)

                  Else
                     vp.Precio = vp.PrecioConImpuestos
                  End If
               End If

               If String.IsNullOrEmpty(vp.NombreListaPrecios) Then
                  vp.IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
                  vp.NombreListaPrecios = Me.cmbListaDePrecios.Text
               End If
            Else
               If v.TipoComprobante.CargaPrecioActual And Not vp.Producto.PermiteModificarDescripcion And vp.TipoOperacion = Entidades.Producto.TiposOperaciones.NORMAL Then
                  vp.IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
                  vp.NombreListaPrecios = Me.cmbListaDePrecios.Text

                  'Si carga el precio actual y el mismo tiene valor. En los productos varios se deja en 0 (cero) para vender aquellos que no se detallan.
                  If vp.PrecioLista <> 0 Then

                     Dim dt As DataTable = New Reglas.Productos().GetPorCodigo(vp.IdProducto, actual.Sucursal.Id, vp.IdListaPrecios, "VENTAS", soloBuscaPorIdProducto:=True)
                     Dim precioVentaSinIVA As Decimal = Decimal.Parse(dt.Rows(0)("PrecioVentaSinIVA").ToString())
                     Dim precioVentaConIVA As Decimal = Decimal.Parse(dt.Rows(0)("PrecioVentaConIVA").ToString())
                     'AHORA CAMBIA LA FORMA porque comente "1."
                     If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                        GetTipoComprobanteSeleccionado().UtilizaImpuestos Then
                        'vp.Precio = Decimal.Round((vp.PrecioLista * (1 + vp.AlicuotaImpuesto / 100)), Me._decimalesRedondeoEnPrecio)
                        vp.Precio = precioVentaConIVA ' Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.PrecioLista, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), _decimalesRedondeoEnPrecio)

                     Else
                        vp.Precio = precioVentaSinIVA ' vp.PrecioLista
                     End If

                     If vp.Producto.Moneda.IdMoneda = Entidades.Moneda.Dolar Then
                        '  If v.IdMoneda = Entidades.Moneda.Dolar Then
                        vp.Precio = Decimal.Round(vp.Precio * v.CotizacionDolar, Me._decimalesRedondeoEnPrecio)
                        '   Else

                        '  vp.Precio = Decimal.Round(vp.Precio * txtCotizacionDolar.ValorNumericoPorDefecto(0D), Me._decimalesRedondeoEnPrecio)

                        '   End If
                     End If

                     Dim PrecioPorEmbalaje As Boolean = vp.Producto.PrecioPorEmbalaje

                     If PrecioPorEmbalaje Then
                        vp.Precio = vp.Precio / vp.Producto.Embalaje
                     End If


                  Else
                     blnEntrar = False
                     If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                        If vp.PrecioConImpuestos = 0 Then
                           'vp.Precio = Decimal.Round((vp.Precio * (1 + vp.AlicuotaImpuesto / 100)), Me._decimalesRedondeoEnPrecio)
                           vp.Precio = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), _decimalesRedondeoEnPrecio)

                        Else
                           vp.Precio = vp.PrecioConImpuestos
                        End If
                     End If
                  End If

                  'En REMITO no tendria sentido que haya carga el descuento.
                  'vp.DescuentoRecargo = Decimal.Round((vp.Precio * vp.Cantidad * vp.DescuentoRecargoPorc / 100), Me._valorRedondeo)


                  Producto = vp.Producto

                  'Cargo el Descuento/Recargo cargado en el subrubro

                  'If Producto.IdSubRubro > 0 Then
                  '   SubR = oSR.GetUno(Producto.IdSubRubro)
                  '   vp.DescuentoRecargoPorc1 = SubR.DescuentoRecargoPorc1

                  '   'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
                  '   SubR2 = oCSR.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Producto.IdSubRubro)
                  '   vp.DescuentoRecargoPorc2 = SubR2.DescuentoRecargoPorc1
                  'End If
                  '---------------------------------------------------------------------------

               Else

                  If vp.Producto.PermiteModificarDescripcion And Reglas.Publicos.Facturacion.FacturacionProductoModificaDescripcionCargaPrecioActual Then
                     vp.IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
                     vp.NombreListaPrecios = Me.cmbListaDePrecios.Text

                     'Si carga el precio actual y el mismo tiene valor. En los productos varios se deja en 0 (cero) para vender aquellos que no se detallan.
                     If vp.PrecioLista <> 0 Then
                        'AHORA CAMBIA LA FORMA porque comente "1."
                        If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                           vp.Precio = Decimal.Round((vp.PrecioLista * (1 + vp.AlicuotaImpuesto / 100)), Me._decimalesRedondeoEnPrecio)
                        Else
                           vp.Precio = vp.PrecioLista
                        End If

                        Dim PrecioPorEmbalaje As Boolean = vp.Producto.PrecioPorEmbalaje

                        If PrecioPorEmbalaje Then
                           vp.Precio = vp.Precio / vp.Producto.Embalaje
                        End If

                     Else
                        blnEntrar = False
                        If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                           vp.Precio = Decimal.Round((vp.Precio * (1 + vp.AlicuotaImpuesto / 100)), Me._decimalesRedondeoEnPrecio)
                        End If
                     End If

                     'En REMITO no tendria sentido que haya carga el descuento.
                     'vp.DescuentoRecargo = Decimal.Round((vp.Precio * vp.Cantidad * vp.DescuentoRecargoPorc / 100), Me._valorRedondeo)

                     Producto = vp.Producto

                     'Cargo el Descuento/Recargo cargado en el subrubro

                     'If Producto.IdSubRubro > 0 Then
                     '   SubR = oSR.GetUno(Producto.IdSubRubro)
                     '   vp.DescuentoRecargoPorc1 = SubR.DescuentoRecargoPorc1

                     '   'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
                     '   SubR2 = oCSR.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Producto.IdSubRubro)
                     '   vp.DescuentoRecargoPorc2 = SubR2.DescuentoRecargoPorc1
                     'End If
                     '---------------------------------------------------------------------------

                  Else

                     ' Mismo codigo que esta en cambio de comprobante
                     _tipoComprobanteActual = v.TipoComprobante

                     'Dim tpComp As Entidades.TipoComprobante = DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)

                     If _tipoComprobanteActual IsNot Nothing AndAlso tipoComp IsNot Nothing AndAlso
                        ((_tipoComprobanteActual.GrabaLibro Or _tipoComprobanteActual.EsPreElectronico) <> (tipoComp.GrabaLibro Or tipoComp.EsPreElectronico) Or
                         _tipoComprobanteActual.UtilizaImpuestos <> tipoComp.UtilizaImpuestos) Then

                        Me.SeteaIVASegunComprobante(vp, tipoComp, setearPrecio:=True)

                     Else
                        If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                           vp.Precio = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), _decimalesRedondeoEnPrecio)
                        End If
                     End If
                     _tipoComprobanteActual = tipoComp

                     If String.IsNullOrEmpty(vp.NombreListaPrecios) Then
                        vp.IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
                        vp.NombreListaPrecios = Me.cmbListaDePrecios.Text
                     End If
                  End If

               End If

            End If

            If _utilizaCentroCostos AndAlso Not vp.IdCentroCosto.HasValue Then
               vp.CentroCosto = Producto.CentroCosto
            End If

            'Calculo el descuento Recargo CON/SIN IVA.

            If v.TipoComprobante.CargaDescRecActual Then
               '# Carga Desc Rec Actual
               '# Piso el valor de la propiedad para no afectar al resto de los métodos que realizan cálculos a partir de éste.
               Me._DescuentosRecargosProd = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE, vp.Producto, vp.Cantidad, Me._decimalesEnTotales)

               vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
               vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
            End If

            DescRec1 = Decimal.Round((vp.Precio * vp.DescuentoRecargoPorc1 / 100), Me._decimalesRedondeoEnPrecio)
            DescRec2 = Decimal.Round(((vp.Precio + DescRec1) * vp.DescuentoRecargoPorc2 / 100), Me._decimalesRedondeoEnPrecio)

            vp.DescuentoRecargo = (DescRec1 + DescRec2) * vp.Cantidad

            'Calculo el Precio Neto CON/SIN IVA.
            PrecioNeto = vp.Precio + DescRec1 + DescRec2
            PrecioNeto = Decimal.Round(PrecioNeto * (1 + (v.DescuentoRecargoPorc / 100)), Me._decimalesRedondeoEnPrecio)
            PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), Me._decimalesRedondeoEnPrecio)

            vp.PrecioNeto = PrecioNeto

            vp.ImporteTotal = (vp.Precio * vp.Cantidad) + vp.DescuentoRecargo

            '-- REQ-35220.- -------------------------------------------------------------------------------------------
            vp.DescripcionAtributo01 = New Reglas.AtributosProductos().GetUnoIDA(vp.IdaAtributoProducto01).Descripcion
            vp.DescripcionAtributo02 = New Reglas.AtributosProductos().GetUnoIDA(vp.IdaAtributoProducto02).Descripcion
            vp.DescripcionAtributo03 = New Reglas.AtributosProductos().GetUnoIDA(vp.IdaAtributoProducto03).Descripcion
            vp.DescripcionAtributo04 = New Reglas.AtributosProductos().GetUnoIDA(vp.IdaAtributoProducto04).Descripcion
            '----------------------------------------------------------------------------------------------------------

            'Solo se unifica en caso de facturar REMITOS, para presupuesto lo dejo separado porque ahora se puede digita separado.
            'Y en caso de NO poder modificar la descripcion del producto

            'If codigos.Contains(vp.Producto.IdProducto) And v.TipoComprobante.CargaPrecioActual And Not Publicos.FacturacionModificaDescripcionProducto And blnEntrar Then

            Dim codigoParaLinea As String = vp.Producto.IdProducto + "___" + vp.TipoOperacion.ToString()
            Dim indexOfCodigo As Integer = 0

            If facturacionInvocarPedidosDeOtrasSucursales Then
               vp.IdSucursal = actual.Sucursal.Id
            End If

            If Reglas.Publicos.Facturacion.FacturacionModificaDescriAcumulaProducto Then
               If codigos.Contains(codigoParaLinea) And v.TipoComprobante.CargaPrecioActual And blnEntrar Then
                  indexOfCodigo = codigos.IndexOf(codigoParaLinea)

                  Me._ventasProductos(indexOfCodigo).Cantidad += vp.Cantidad
                  Me._ventasProductos(indexOfCodigo).CantidadManual += vp.CantidadManual
                  Me._ventasProductos(indexOfCodigo).ImporteTotal = Me._ventasProductos(indexOfCodigo).Cantidad * Me._ventasProductos(indexOfCodigo).Precio
               Else

                  Me._numeroOrden += 1
                  vp.Orden = Me._numeroOrden
                  codigos.Add(codigoParaLinea)
                  Me._ventasProductos.Add(vp)

                  If vp.VentasProductosFormulas.Count > 0 Then
                     _ventasProductosFormulas.Add(vp, ConvertFormulaADataTable(vp))
                  End If

               End If

            Else
               If codigos.Contains(codigoParaLinea) And v.TipoComprobante.CargaPrecioActual And Not vp.Producto.PermiteModificarDescripcion Then
                  indexOfCodigo = codigos.IndexOf(codigoParaLinea)

                  _ventasProductos(indexOfCodigo).Cantidad += vp.Cantidad
                  _ventasProductos(indexOfCodigo).CantidadManual += vp.CantidadManual
                  _ventasProductos(indexOfCodigo).ImporteTotal = Me._ventasProductos(indexOfCodigo).Cantidad * Me._ventasProductos(indexOfCodigo).Precio
                  _ventasProductos(indexOfCodigo).Producto.NrosSeries.AddRange(vp.Producto.NrosSeries)
               Else

                  Me._numeroOrden += 1
                  vp.Orden = Me._numeroOrden
                  codigos.Add(codigoParaLinea)

                  Me._ventasProductos.Add(vp)

                  If vp.VentasProductosFormulas.Count > 0 Then
                     _ventasProductosFormulas.Add(vp, ConvertFormulaADataTable(vp))
                  End If

               End If

               '-.PE-32964.-
               _ventasProductos(indexOfCodigo).FechaActualizacion = vp.FechaActualizacion

            End If

            vp.PrecioAux = vp.Precio
            vp.IdListaPreciosAux = vp.IdListaPrecios

            If vp.CostoParaGrabar Is Nothing Or vp.CostoParaGrabar = 0 Then
               vp.CostoParaGrabar = vp.Costo
            End If

         Next

      Next

      'Elimino los de Cantidades en Cero (Puede suceder por una devolucion).
      Dim blnLlegoAlFin As Boolean = False
      Dim Cont As Integer
      Do While Not blnLlegoAlFin And Me._ventasProductos.Count > 0
         Cont = 0
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            If pro.Cantidad = 0 Then
               'Cada Vez que borro debo volver a Empezar porque se renumeran los indices y si continuo da error
               Me._ventasProductos.RemoveAt(Cont)
               Exit For
            End If
            Cont += 1
         Next
         If Cont = Me._ventasProductos.Count Then
            blnLlegoAlFin = True
         End If
      Loop

      '-- REQ-34669.- ------------------------------------------------------------------------------
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo01") Then _tit.Add("DescripcionAtributo01", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo02") Then _tit.Add("DescripcionAtributo02", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo03") Then _tit.Add("DescripcionAtributo03", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo04") Then _tit.Add("DescripcionAtributo04", "")
      End If
      '----------------------------------------------------------------------------------------------
      If Not _tit.ContainsKey("NombreDeposito") Then _tit.Add("NombreDeposito", "")
      If Not _tit.ContainsKey("NombreUbicacion") Then _tit.Add("NombreUbicacion", "")
      '----------------------------------------------------------------------------------------------

      SetProductosDataSource()

      'GAR: 03/05/2018 - Vuelven a aparecer por mas que los oculte arriba, asi que vuelvo a hacerlo!
      dgvProductos.Columns("IdCentroCosto").Visible = _utilizaCentroCostos
      dgvProductos.Columns("NombreCentroCosto").Visible = _utilizaCentroCostos

      'Me.OrdenarGrillaProductos()
      dgvRemitoTransp.DataSource = _ventasProductos

      tsbGrabar.Enabled = True

      HabilitaCotizacionDolar()

   End Sub

   Private Function ConvertFormulaADataTable(vp As Entidades.VentaProducto) As DataTable
      If vp.VentasProductosFormulas.Count > 0 Then
         Dim oComponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
         Dim dtComponentes As DataTable

         If vp.Producto.CalculaPreciosSegunFormula Then
            'Busco con idFormula = -1 para que no me traiga nada, pero que me defina la estructura del DataTable
            dtComponentes = oComponentes.GetComponentes(actual.Sucursal.IdSucursal, vp.IdProducto, IdFormula:=-1, idListaDePrecios:=vp.IdListaPrecios) ' pp.IdFormula, pp.IdListaPrecios)
            For Each vpf As Entidades.VentaProductoFormula In vp.VentasProductosFormulas
               Dim drCol As DataRow() = dtComponentes.Select(String.Format("IdProductoComponente = '{0}'", vpf.IdProductoComponente))
               If drCol.Length > 0 Then
                  For Each drComponente As DataRow In drCol
                     drComponente("PrecioVenta") = vpf.PrecioVenta
                     drComponente("PrecioCosto") = vpf.PrecioCosto
                     drComponente("Cantidad") = vpf.Cantidad
                     drComponente("SegunCalculoForma") = vpf.SegunCalculoForma
                  Next
               Else
                  Dim rProd As Reglas.Productos = New Reglas.Productos()
                  Dim dtFueraFormula As DataTable = rProd.GetProductosGrillaFiltroMarcaRubroSubrubro(actual.Sucursal.Id, "", 0, 0, 0, vpf.IdProductoComponente)
                  If dtFueraFormula.Rows.Count > 0 Then
                     Dim drComponente As DataRow = dtComponentes.NewRow()
                     Dim drFueraFormula As DataRow = dtFueraFormula.Rows(0)
                     drComponente("IdProductoComponente") = drFueraFormula("IdProducto")
                     drComponente("NombreProducto") = drFueraFormula("NombreProducto")
                     drComponente("IdUnidadDeMedida") = drFueraFormula("IdUnidadDeMedida")
                     drComponente("PrecioCosto") = drFueraFormula("PrecioCosto")
                     drComponente("PrecioCostoSinIVA") = drFueraFormula("PrecioCostoSinIVA")
                     drComponente("PrecioCostoConIVA") = drFueraFormula("PrecioCostoConIVA")
                     drComponente("NombreMoneda") = drFueraFormula("NombreMoneda")
                     drComponente("FactorConversion") = drFueraFormula("FactorConversion")
                     drComponente("Simbolo") = drFueraFormula("Simbolo")
                     drComponente("Tamano") = drFueraFormula("Tamano")
                     drComponente("SegunCalculoForma") = False

                     drComponente("PrecioVenta") = drFueraFormula("PrecioVenta")
                     drComponente("PrecioVentaSinIVA") = drFueraFormula("PrecioVentaSinIVA")
                     drComponente("PrecioVentaConIVA") = drFueraFormula("PrecioVentaConIVA")
                     drComponente("ComponenteAgregado") = True

                     drComponente("PrecioVenta") = vpf.PrecioVenta
                     drComponente("PrecioCosto") = vpf.PrecioCosto
                     drComponente("Cantidad") = vpf.Cantidad
                     drComponente("SegunCalculoForma") = vpf.SegunCalculoForma

                     dtComponentes.Rows.Add(drComponente)
                  End If

               End If
            Next
            Return dtComponentes
         End If
      End If
      Return Nothing
   End Function

   Private Sub CargarObservacionesFacturables(selec As List(Of Entidades.Venta))

      'No Limpio las Observaciones para que quede el INVOCO.
      'Me._ventasObservaciones = Nothing
      'Me._ventasObservaciones = New List(Of Entidades.VentaObservacion)

      '# Observaciones Detalladas
      For Each v As Entidades.Venta In selec

         For Each vp As Entidades.VentaObservacion In v.VentasObservaciones
            vp.Linea = Me._ventasObservaciones.Count + 1
            Me._ventasObservaciones.Add(vp)
         Next

      Next

      '# Observaciones generales
      '# Si los Comp. invocados = 1 y tiene OBS General, pisa la OBS General del comprobante origen.
      'Dim obsGral As String() = selec.Where(Function(x) Not String.IsNullOrWhiteSpace(x.Observacion)).ToList().ConvertAll(Function(x) x.Observacion).ToArray()

      'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImportaObservGrales Then
      '   If obsGral.Count = 1 Then
      '      Me.bscObservacion.Text = obsGral(0)
      '   Else
      '      For Each obs As String In obsGral
      '         Dim ventaObs As Entidades.VentaObservacion = New Entidades.VentaObservacion
      '         ventaObs.Observacion = obs
      '         ventaObs.Linea = Me._ventasObservaciones.Count + 1

      '         Me._ventasObservaciones.Add(ventaObs)
      '      Next
      '   End If
      'End If

      SetDataSourceObservaciones(Me._ventasObservaciones)

   End Sub

   Private Sub SetOrdenGrilla(column As DataGridViewColumn, ByRef orden As Integer)
      column.DisplayIndex = orden
      orden += 1
   End Sub

   Private Sub OrdenarGrillaProductos()

      Dim MuestraPesos = (Reglas.Publicos.VentasVisualizaPrecioEnDolares = Reglas.Publicos.FormatoVisualizaPrecioDolares.PESOS.ToString() Or Reglas.Publicos.VentasVisualizaPrecioEnDolares = Reglas.Publicos.FormatoVisualizaPrecioDolares.AMBOS.ToString())
      Dim MuestraDolar = (Reglas.Publicos.VentasVisualizaPrecioEnDolares = Reglas.Publicos.FormatoVisualizaPrecioDolares.DOLARES.ToString() Or Reglas.Publicos.VentasVisualizaPrecioEnDolares = Reglas.Publicos.FormatoVisualizaPrecioDolares.AMBOS.ToString())

      Dim canti As Integer = 0
      With Me.dgvProductos

         Me.SetOrdenGrilla(.Columns("IdProducto"), canti)
         Me.SetOrdenGrilla(.Columns("ProductoDesc"), canti)

         Me.SetOrdenGrilla(.Columns("DescripcionAtributo01"), canti)
         Me.SetOrdenGrilla(.Columns("DescripcionAtributo02"), canti)
         Me.SetOrdenGrilla(.Columns("DescripcionAtributo03"), canti)
         Me.SetOrdenGrilla(.Columns("DescripcionAtributo04"), canti)

         Me.SetOrdenGrilla(.Columns("NombreDeposito"), canti)
         Me.SetOrdenGrilla(.Columns("NombreUbicacion"), canti)

         If Reglas.Publicos.Facturacion.FacturacionMuestraProvHabitual Then
            .Columns("CodigoProductoProveedor").Visible = True
            Me.SetOrdenGrilla(.Columns("CodigoProductoProveedor"), canti)
         End If

         Me.SetOrdenGrilla(.Columns("CantidadManual"), canti)
         Me.SetOrdenGrilla(.Columns("Cantidad"), canti)

         Me.SetOrdenGrilla(.Columns("Stock"), canti)

         Me.SetOrdenGrilla(.Columns("Precio"), canti)
         Me.SetOrdenGrilla(.Columns("PrecioDolar"), canti)

         Me.SetOrdenGrilla(.Columns("PrecioIVA"), canti)
         Me.SetOrdenGrilla(.Columns("Conversion"), canti)
         Me.SetOrdenGrilla(.Columns("DescuentoRecargoPorc1"), canti)
         Me.SetOrdenGrilla(.Columns("DescuentoRecargoPorc2"), canti)
         Me.SetOrdenGrilla(.Columns("PrecioNeto"), canti)
         Me.SetOrdenGrilla(.Columns("PrecioNetoDolar"), canti)
         Me.SetOrdenGrilla(.Columns("AlicuotaImpuesto"), canti)
         Me.SetOrdenGrilla(.Columns("ImporteImpuesto"), canti)
         Me.SetOrdenGrilla(.Columns("Importe"), canti)
         Me.SetOrdenGrilla(.Columns("ImporteDolar"), canti)
         Me.SetOrdenGrilla(.Columns("NrosSerie"), canti)
         Me.SetOrdenGrilla(.Columns("NrosLotes"), canti)
         Me.SetOrdenGrilla(.Columns("Kilos"), canti)
         Me.SetOrdenGrilla(.Columns("Ubicacion"), canti)
         Me.SetOrdenGrilla(.Columns("FechaActualizacion"), canti)
         Me.SetOrdenGrilla(.Columns("IdCentroCosto"), canti)
         Me.SetOrdenGrilla(.Columns("NombreCentroCosto"), canti)
         Me.SetOrdenGrilla(.Columns("Costo"), canti)
         Me.SetOrdenGrilla(.Columns("CostoDolar"), canti)

         If Me._clienteE IsNot Nothing AndAlso
            ((Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
             Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos) Then
            .Columns("PrecioIVA").Visible = False
         Else
            .Columns("PrecioIVA").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarPrecioConIVA
         End If

         .Columns("DescuentoRecargoPorc1").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarDesc1
         .Columns("DescuentoRecargoPorc2").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarDesc2
         .Columns("Kilos").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarKilos
         .Columns("Stock").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarStock

         .Columns("Cantidad").Visible = Reglas.Publicos.FacturacionVisualizaCantidadConvertida
         .Columns("Conversion").Visible = Reglas.Publicos.FacturacionVisualizaConversion
         'Me.dgvRemitoTransp.Columns("grtCantidad").Visible = Reglas.Publicos.FacturacionVisualizaCantidadConvertida
         'Me.dgvRemitoTransp.Columns("ConversionRT").Visible = Reglas.Publicos.FacturacionVisualizaConversion

         If Reglas.Publicos.VisualizaNrosSerie Then
            .Columns("NrosSerie").Visible = True
            Me.dgvRemitoTransp.Columns("NrosSerieRT").Visible = True
         End If
         If Reglas.Publicos.VisualizaLote Then
            .Columns("NrosLotes").Visible = True
            Me.dgvRemitoTransp.Columns("NrosLotesRT").Visible = True
         End If

         .Columns("Precio").Visible = MuestraPesos
         .Columns("PrecioDolar").Visible = MuestraDolar
         .Columns("PrecioNeto").Visible = MuestraPesos
         .Columns("PrecioNetoDolar").Visible = MuestraDolar
         .Columns("Importe").Visible = MuestraPesos
         .Columns("ImporteDolar").Visible = MuestraDolar
         .Columns("Costo").Visible = MuestraPesos
         .Columns("CostoDolar").Visible = MuestraDolar

         .Columns("PrecioNeto").Visible = (Reglas.Publicos.Facturacion.FacturacionMostrarPrecioUnitario AndAlso MuestraPesos)
         .Columns("PrecioNetoDolar").Visible = (Reglas.Publicos.Facturacion.FacturacionMostrarPrecioUnitario AndAlso MuestraDolar)


      End With
   End Sub

   Private Sub OrdenarGrillaFacturables()
      With Me.dgvFacturables
         .Columns("gfacFecha").DisplayIndex = 0
         .Columns("gfacTipoComprobanteDescripcion").DisplayIndex = 1
         .Columns("gfacLetraComprobante").DisplayIndex = 2
         .Columns("gfacCentroEmisor").DisplayIndex = 3
         .Columns("gfacNumeroComprobante").DisplayIndex = 4
         .Columns("gfacSubtotal").DisplayIndex = 5
         .Columns("gfacTotalImpuestos").DisplayIndex = 6
         .Columns("gfacImporteTotal").DisplayIndex = 7
         .Columns("gfacKilos").DisplayIndex = 8
         .Columns("gfacObservacion").DisplayIndex = 9
      End With
   End Sub

   'Private Sub OrdenarSolapas()

   '   'TODO: NINGUNO FUNCIONO !!

   '   Dim Posicion As Integer = -1

   '   If Me.tbcDetalle.Tabs(Me.tbpProductos) Then
   '      Posicion += 1
   '      Me.tbcDetalle.TabPages("tbpProductos").TabIndex = Posicion
   '      'Me.tbcDetalle.TabPages(Posicion) = me.tbpProductos
   '      'Me.tbcDetalle.TabPages.Item(Posicion) = Me.tbpProductos
   '   End If

   '   If Me.tbcDetalle.Tabs(Me.tbpRemitoTransp) Then
   '      Posicion += 1
   '      Me.tbcDetalle.TabPages("tbpRemitoTransp").TabIndex = Posicion
   '   End If

   '   If Me.tbcDetalle.Tabs(Me.tbpFacturables) Then
   '      Posicion += 1
   '      Me.tbcDetalle.TabPages("tbpFacturables").TabIndex = Posicion
   '   End If

   '   If Me.tbcDetalle.Tabs(Me.tbpCheques) Then
   '      Posicion += 1
   '      Me.tbcDetalle.TabPages("tbpCheques").TabIndex = Posicion
   '   End If

   '   If Me.tbcDetalle.Tabs(Me.tbpObservaciones) Then
   '      Posicion += 1
   '      Me.tbcDetalle.TabPages("tbpObservaciones").TabIndex = Posicion
   '   End If

   '   If Me.tbcDetalle.Tabs(Me.tbpPagos) Then
   '      Posicion += 1
   '      Me.tbcDetalle.TabPages("tbpPagos").TabIndex = Posicion
   '   End If

   '   If Me.tbcDetalle.Tabs(Me.tbpTotales) Then
   '      Posicion += 1
   '      Me.tbcDetalle.TabPages("tbpTotales").TabIndex = Posicion
   '   End If

   'End Sub

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
         txtPrecioVentaPorTamano.Focus()
         txtPrecioVentaPorTamano.SelectAll()
      Else
         Me.txtPrecio.Focus()
         Me.txtPrecio.SelectAll()
      End If
   End Sub

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)

      Me.btnLimpiarProducto.Enabled = Habilitado
      Me.bscCodigoProducto2.Enabled = Habilitado
      Me.bscProducto2.Enabled = Habilitado
      cmbTipoOperacion.Enabled = Habilitado
      Me.txtCantidadManual.Enabled = Habilitado
      HabilidaPrecios(Habilitado Or chbModificaPrecio.Checked)
      Me.txtDescRecPorc1.Enabled = Habilitado
      Me.txtDescRecPorc2.Enabled = Habilitado
      Me.txtDescRec.Enabled = Habilitado
      Me.cmbPorcentajeIva.Enabled = Habilitado

      '-------------------------------------------------------
      cmbDepositoOrigen.Enabled = Habilitado
      cmbUbicacionOrigen.Enabled = Habilitado
      '-------------------------------------------------------
      cmbFormula.Enabled = Habilitado

      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado

      cmbFormula.Enabled = Habilitado

      'Por las que le toque habilitar, es factible que no corresponda
      If Habilitado Then
         Me.cmbPorcentajeIva.Enabled = Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos
      End If

      'If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
      '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
      '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
      '      Me.cmbPorcentajeIva.Enabled = False
      '   End If
      'End If

      If Habilitado Then
         Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)()
         If tipoComp IsNot Nothing AndAlso ((Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                                             Not tipoComp.GrabaLibro And Not tipoComp.EsPreElectronico) Or
                                            tipoComp.PermiteSeleccionarAlicuotaIVA) Then
            Me.cmbPorcentajeIva.Enabled = True
         Else
            Me.cmbPorcentajeIva.Enabled = False
         End If
      End If


   End Sub
   Private Sub CambiarEstadoControlesDetalleRT(Habilitado As Boolean)

      Me.btnLimpiarProductoRT.Enabled = Habilitado
      Me.bscCodigoProducto2RT.Enabled = Habilitado
      Me.bscProducto2RT.Enabled = Habilitado
      Me.txtCantidadManualRT.Enabled = Habilitado
      Me.btnInsertarRT.Enabled = Habilitado
      Me.btnEliminarRT.Enabled = Habilitado

   End Sub

   Private Sub InsertarChequesGrilla()

      Dim oLineaDetalle As Entidades.Cheque = New Entidades.Cheque()
      Dim oLineaDetalleObs As Entidades.VentaObservacion = New Entidades.VentaObservacion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .NumeroCheque = Integer.Parse(Me.txtNroCheque.Text)
         .Banco = New Reglas.Bancos().GetUno(Integer.Parse(Me.bscBancos.Tag.ToString())) ''._filaDevuelta.Cells("idBanco").Value.ToString()))
         .IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text)
         .Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalCheque.Text)
         .FechaEmision = Me.dtpFechaEmision.Value
         .FechaCobro = Me.dtpFechaCobro.Value
         .Titular = Me.txtTitularCheque.Text
         .Importe = Decimal.Parse(Me.txtImporteCheque.Text)
         .Cliente.IdCliente = _clienteE.IdCliente
         .Cliente.CodigoCliente = _clienteE.CodigoCliente
         .Cuit = Me.txtCuitChequeTercero.Text

         .Usuario = actual.Nombre
         .IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA

         .IdTipoCheque = Me.cmbTipoCheque.SelectedValue.ToString()
         .NombreTipoCheque = Me.cmbTipoCheque.Text
         .NroOperacion = Me.txtNroOperacion.Text
      End With

      Me._cheques.Add(oLineaDetalle)



      Me.dgvCheques.DataSource = Me._cheques.ToArray()
      Me.dgvCheques.FirstDisplayedScrollingRowIndex = Me.dgvCheques.Rows.Count - 1

      Me.dgvCheques.Refresh()
      Me.LimpiarCamposCheques()
      Me.CalcularPagos(False)

   End Sub

   Private Sub InsertarTarjetaGrilla() ' Overload
      InsertarTarjetaGrilla(New Reglas.Tarjetas().GetUno(Integer.Parse(Me.cmbTarTarjeta.SelectedValue.ToString())),
                            New Reglas.Bancos().GetUno(Integer.Parse(bscTarBanco.Tag.ToString())),
                            Decimal.Parse(Me.txtTarMonto.Text),
                            Integer.Parse(Me.txtTarCuotas.Text),
                            Integer.Parse(Me.txtTarNumeroLote.Text),
                            Integer.Parse(Me.txtTarNumeroCupon.Text))
   End Sub

   Private Sub InsertarTarjetaGrilla(tarjeta As Entidades.Tarjeta, banco As Entidades.Banco, monto As Decimal, cuotas As Integer, lote As Integer, numeroCupon As Integer)

      Dim oLineaDetalle As Entidades.VentaTarjeta = New Entidades.VentaTarjeta()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .IdTarjetaCupon = If(cmbTarTarjeta.Tag IsNot Nothing, Integer.Parse(cmbTarTarjeta.Tag.ToString()), 0)
         .Tarjeta = tarjeta 'New Reglas.Tarjetas().GetUno(Int32.Parse(Me.cmbTarTarjeta.SelectedValue.ToString()))
         .Banco = banco 'New Reglas.Bancos().GetUno(Integer.Parse(bscTarBanco.Tag.ToString())) ''  Me.bscTarBanco._filaDevuelta.Cells("IdBanco").Value.ToString()))
         .Monto = monto 'Decimal.Parse(Me.txtTarMonto.Text)
         .Cuotas = cuotas 'Int32.Parse(Me.txtTarCuotas.Text)
         .NumeroLote = lote 'Int32.Parse(Me.txtTarNumeroLote.Text)
         .NumeroCupon = numeroCupon 'Int32.Parse(Me.txtTarNumeroCupon.Text)
         .Usuario = actual.Nombre
      End With

      Me._tarjetas.Add(oLineaDetalle)


      Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()
      Me.dgvTarjetas.FirstDisplayedScrollingRowIndex = Me.dgvTarjetas.Rows.Count - 1

      Me.dgvTarjetas.Refresh()
      Me.LimpiarCamposTarjetas()
      Me.CalcularPagos(_recalcularEfectivoAlCargarTarjeta)

   End Sub

   Private Sub CalcularDiferenciaDePago()
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
   End Sub

   Private Function ValidarInsertarCheques() As Boolean

      If Decimal.Parse(Me.txtImporteCheque.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un cheque con importe cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtImporteCheque.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtNroCheque.Text) = 0 Then
         MessageBox.Show("El número de cheque no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtNroCheque.Focus()
         Return False
      End If

      If Not Me.bscBancos.Selecciono And Not Me.bscCodBancos.Selecciono Then
         MessageBox.Show("Debe seleccionar un Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCodBancos.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtSucursalBanco.Text) < 0 Then
         MessageBox.Show("La Sucursal del Banco es inválida.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtSucursalBanco.Focus()
         Return False
      End If

      If Integer.Parse(Me.txtCodPostalCheque.Text) = 0 Then
         MessageBox.Show("Debe ingresar un C.P. para el cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCodPostalCheque.Focus()
         Return False
      Else
         If Not New Reglas.Localidades().Existe(Integer.Parse(Me.txtCodPostalCheque.Text)) Then
            MessageBox.Show("No existe la localidad del Cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCodPostalCheque.Focus()
            Return False
         End If
      End If

      '# Valido que se haya seleccionado un cliente
      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         MessageBox.Show("Debe seleccionar un Cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      '# Validación del CUIT
      If String.IsNullOrEmpty(Me.txtCuitChequeTercero.Text) Then
         ShowMessage("Debe ingresar un Nro. CUIT para el Cheque.")
         Return False
      Else

         Dim result As Reglas.Validaciones.ValidacionResult
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                     With {.IdFiscal = txtCuitChequeTercero.Text,
                                                                                           .SolicitaCUIT = True}) '# Siempre solicitamos el CUIT al insertar el cheque por la nueva Alternative Key en BD
         If result.Error Then
            txtCuitChequeTercero.Focus()
            ShowMessage(result.MensajeError)
            Return False
         End If

      End If

      'controlo que no se repita el cheque ingresado
      Dim ent As Entidades.Cheque
      For i As Integer = 0 To Me._cheques.Count - 1
         ent = Me._cheques(i)
         If ent.NumeroCheque = Integer.Parse(Me.txtNroCheque.Text) And
                  ent.Banco.IdBanco = Integer.Parse(Me.bscCodBancos.Text) And
                  ent.IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text) And
                  ent.Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalCheque.Text) And
                  ent.Cuit = Me.txtCuitChequeTercero.Text Then
            MessageBox.Show("El cheque ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If
      Next

      If New Reglas.Cheques().Existe(actual.Sucursal.IdSucursal,
                                       Integer.Parse(Me.txtNroCheque.Text),
                                       Integer.Parse(Me.bscCodBancos.Text),
                                       Integer.Parse(Me.txtSucursalBanco.Text),
                                       Integer.Parse(Me.txtCodPostalCheque.Text),
                                       Me.txtCuitChequeTercero.Text) Then
         MessageBox.Show("El Cheque fué Ingresado con Anterioridad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroCheque.Focus()
         Return False
      End If

      If Reglas.Publicos.Facturacion.Impresion.FacturacionDetallaChequesyTarjetas Then
         Dim LineasDetalle As Integer = Integer.Parse(IIf(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista, Me.dgvRemitoTransp.RowCount, Me.dgvProductos.RowCount).ToString())

         If LineasDetalle + Me.dgvTarjetas.RowCount + dgvCheques.RowCount + Me.ugObservaciones.Rows.Count >= _cantMaxItems + Reglas.Publicos.Facturacion.CantMaxItemsDetallaChequesyTarjetas Then
            MessageBox.Show("No puede ingresar mas de " & (_cantMaxItems + Reglas.Publicos.Facturacion.CantMaxItemsDetallaChequesyTarjetas) & " líneas (Productos, Observaciones, Cheques y/o Tarjetas) para este tipo de comprobante." + Environment.NewLine +
                            "Cantidad de líneas del comprobante " & (LineasDetalle + Me.dgvTarjetas.RowCount + dgvCheques.RowCount + Me.ugObservaciones.Rows.Count).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnInsertarTarjeta.Focus()
            Return False
         End If
      End If

      '# Tipo de Cheque
      If Me.cmbTipoCheque.SelectedIndex = -1 Then
         Me.cmbTipoCheque.Focus()
         ShowMessage("ATENCIÓN: No seleccionó un Tipo de Cheque")
         Return False
      End If

      If DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion AndAlso
        String.IsNullOrEmpty(Me.txtNroOperacion.Text) Then
         Me.txtNroOperacion.Focus()
         ShowMessage("ATENCIÓN: Debe ingresar un Número de Operación para el Tipo de Cheque seleccionado.")
         Return False
      End If

      'Valida fecha cobro sea mayor a fecha emision
      If Me.dtpFechaCobro.Value.Date < Me.dtpFechaEmision.Value.Date Then
         Me.dtpFechaCobro.Focus()
         ShowMessage("La Fecha de Cobro NO puede ser menor a la Fecha de Emisión")
         Return False
      End If

      Return True

   End Function

   Private Sub ValidarInsertarTarjetasConIntereses()
      If Reglas.Publicos.UtilizaInteresesTarjetas Then
         For Each vt As Entidades.VentaTarjeta In _tarjetas
            If vt.Tarjeta Is Nothing OrElse vt.Tarjeta.IdTarjeta = 0 Then
               tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
               tbcPagosTarChe.SelectedTab = tbpPagosTarjetas
               Throw New Exception("Debe seleccionar una Tarjeta.")
            End If

            If vt.Banco Is Nothing OrElse vt.Banco.IdBanco = 0 Then
               tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
               tbcPagosTarChe.SelectedTab = tbpPagosTarjetas
               Throw New Exception(String.Format("La tarjeta {0} no tiene seleccionado un Banco.", vt.Tarjeta.NombreTarjeta))
            End If

            If vt.Monto <= 0 Then
               tbcDetalle.SelectedTab = tbcDetalle.Tabs("tbpPagos")
               tbcPagosTarChe.SelectedTab = tbpPagosTarjetas
               Throw New Exception("No puede ingresar el importe menor a cero.")
               Return
            End If
         Next
      End If

      If Reglas.Publicos.Facturacion.FacturacionTarjetasValidaCuponLote Then
         Dim oTarCup As Reglas.TarjetasCupones = New Reglas.TarjetasCupones()
         Dim TarCup As DataTable = New DataTable
         For Each vt As Entidades.VentaTarjeta In _tarjetas
            TarCup = oTarCup.GetCupon(actual.Sucursal.Id, vt.NumeroCupon, vt.NumeroLote)
            If TarCup.Rows.Count > 0 Then
               Throw New Exception("Ya existe el número de cupón " & vt.NumeroCupon.ToString() & " en el lote " & vt.NumeroLote.ToString() & ".")
            End If
         Next
      End If

   End Sub

   Private Function ValidarInsertarTarjeta() As Boolean

      If Me.cmbTarTarjeta.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar una Tarjeta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTarTarjeta.Focus()
         Return False
      End If

      If Not Me.bscTarBanco.Selecciono Then
         MessageBox.Show("Debe seleccionar un Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscTarBanco.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtTarMonto.Text) <= 0 Then
         MessageBox.Show("No puede ingresar el importe menor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTarMonto.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtTarNumeroLote.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un Nro de lote menor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTarNumeroLote.Focus()
         Return False
      End If
      If Decimal.Parse(Me.txtTarNumeroCupon.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un Nro de cupon menor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTarNumeroCupon.Focus()
         Return False
      End If


      ''controlo que no se repita la tarjeta ingresada
      'For Each ent As Entidades.VentaTarjeta In Me._tarjetas
      '   If ent.Tarjeta.IdTarjeta = Integer.Parse(Me.cmbTarTarjeta.SelectedValue.ToString()) And _
      '            ent.Banco.IdBanco = Integer.Parse(Me.bscTarBanco._filaDevuelta.Cells("IdBanco").Value.ToString()) Then
      '      MessageBox.Show("La tarjeta ya fue ingresada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      Return False
      '   End If
      'Next

      If Reglas.Publicos.Facturacion.Impresion.FacturacionDetallaChequesyTarjetas Then
         Dim LineasDetalle As Integer = Integer.Parse(IIf(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista, Me.dgvRemitoTransp.RowCount, Me.dgvProductos.RowCount).ToString())

         If LineasDetalle + Me.dgvTarjetas.RowCount + dgvCheques.RowCount + Me.ugObservaciones.Rows.Count >= _cantMaxItems + Reglas.Publicos.Facturacion.CantMaxItemsDetallaChequesyTarjetas Then
            MessageBox.Show("No puede ingresar mas de " & (_cantMaxItems + Reglas.Publicos.Facturacion.CantMaxItemsDetallaChequesyTarjetas) & " líneas (Productos, Observaciones, Cheques y/o Tarjetas) para este tipo de comprobante." + Environment.NewLine +
                            "Cantidad de líneas del comprobante " & (LineasDetalle + Me.dgvTarjetas.RowCount + dgvCheques.RowCount + Me.ugObservaciones.Rows.Count).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnInsertarTarjeta.Focus()
            Return False
         End If
      End If

      If Reglas.Publicos.Facturacion.FacturacionTarjetasValidaCuponLote Then

         Dim oTarCup As Reglas.TarjetasCupones = New Reglas.TarjetasCupones()
         Dim TarCup As DataTable = New DataTable
         TarCup = oTarCup.GetCupon(actual.Sucursal.Id, Integer.Parse(Me.txtTarNumeroCupon.Text.ToString()), Integer.Parse(Me.txtTarNumeroLote.Text.ToString()))

         If TarCup.Rows.Count > 0 Then
            MessageBox.Show("Ya existe el número de cupón " & Me.txtTarNumeroCupon.Text.ToString() & " en el lote " & Me.txtTarNumeroLote.Text.ToString() & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtTarNumeroCupon.Focus()
            Return False
         End If

      End If

      Return True
   End Function

   Private Function GetVendedorCombo(Id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If Id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Public Enum MetodoLlamador
      CambioTipoDeComprobante
      CambioListaDePrecibos
      CambioCategoriaFiscal
      CambioFormaDePago
   End Enum

   Private Sub RecalcularTodo(metodoLlamador As MetodoLlamador, oLista As Boolean)

      Try

         If Me._ventasProductos IsNot Nothing Then

            'Dim oProductos As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            'Dim pro1 As Entidades.ProductoSucursal

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Dim ProdDT As DataTable


            Dim DescRec1 As Decimal
            Dim DescRec2 As Decimal
            Dim PrecioNeto As Decimal
            Dim PrecioPorEmbalaje As Boolean
            Dim precioParaDescuento As Decimal
            Dim precioAnterior As Decimal
            Dim cargoPrecioDesdeLaBase As Boolean
            Dim precioMonedaLocalConIVA As Decimal
            Dim precioMonedaLocalConSinIVA As Decimal

            For Each pro As Entidades.VentaProducto In Me._ventasProductos

               'voy a controlar si se modifico el precio del producto manualmente
               Dim seModificoElPrecioManualmente = pro.ModificoPrecioManualmente
               'redondeo el valor a 2 para despues compararlo ya que pueden haber diferencia de centavos luego.
               precioAnterior = Decimal.Round(pro.Precio, 2)

               cargoPrecioDesdeLaBase = False

               '-- REQ-33202.- ---------------------------------------------------------------------------------------
               Dim cListaPrecio As New Integer
               If oLista AndAlso pro.IdListaPreciosAux > -1 Then
                  '-- 
                  pro.IdListaPrecios = pro.IdListaPreciosAux
                  pro.Precio = pro.PrecioAux
                  cListaPrecio = pro.IdListaPreciosAux
               Else

                  cListaPrecio = DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios
               End If
               'obtengo el producto de la base de datos, incluyendo el precio de la lista que se selecciono
               '-- PE-41304.------------------------------------------------------------------------------------------
               ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, cListaPrecio, "VENTAS",,,,,,,,,,, True)
               '------------------------------------------------------------------------------------------------------

               If pro.TipoOperacion <> Entidades.Producto.TiposOperaciones.NORMAL Then
                  ProdDT.Rows(0)("PrecioVentaConIVA") = 0
                  ProdDT.Rows(0)("PrecioVentaSinIVA") = 0
               End If

               If Integer.Parse(ProdDT.Rows(0)("IdMoneda").ToString()) = 2 Then
                  precioMonedaLocalConIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()) * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
                  precioMonedaLocalConSinIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()) * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
               Else
                  precioMonedaLocalConIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()), 2)
                  precioMonedaLocalConSinIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()), 2)
               End If

               PrecioPorEmbalaje = Boolean.Parse(ProdDT.Rows(0)("PrecioPorEmbalaje").ToString())

               If PrecioPorEmbalaje Then
                  precioMonedaLocalConIVA = Decimal.Round(precioMonedaLocalConIVA / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString()), 2)
                  precioMonedaLocalConSinIVA = Decimal.Round(precioMonedaLocalConSinIVA / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString()), 2)
               End If

               'PE-38540 - El control se hace a la hora de cargar la línea. Allí detectaremos si el importe cambio o no.
               '''''controlo si el precio anterior es igual a alguno de los precios con o sin IVA, el redondeo es a 2 por una cuestion de comparacion
               '''''If metodoLlamador <> FacturacionV2.MetodoLlamador.CambioListaDePrecibos Then
               ''''If Not (precioAnterior = precioMonedaLocalConIVA Or precioAnterior = precioMonedaLocalConSinIVA) Then
               ''''   seModificoElPrecioManualmente = True
               ''''End If
               '''''End If

               If _invocadosCajero.CountSecure() > 0 AndAlso
                   (pro.PrecioServicioTecnicoConIVA.HasValue Or pro.PrecioServicioTecnicoSinIVA.HasValue) Then
                  seModificoElPrecioManualmente = False
                  If pro.PrecioServicioTecnicoConIVA.HasValue Then
                     ProdDT.Rows(0)("PrecioVentaConIVA") = pro.PrecioServicioTecnicoConIVA.Value
                  End If
                  If pro.PrecioServicioTecnicoSinIVA.HasValue Then
                     ProdDT.Rows(0)("PrecioVentaSinIVA") = pro.PrecioServicioTecnicoSinIVA.Value
                  End If
               End If

               'si no se modifico el precio manualmente lo cambio
               If Not _cargaProductoDesdeInvocacion Then
                  If Not seModificoElPrecioManualmente Then

                     If (metodoLlamador = FacturacionV2.MetodoLlamador.CambioListaDePrecibos Or metodoLlamador = FacturacionV2.MetodoLlamador.CambioCategoriaFiscal Or
                         metodoLlamador = FacturacionV2.MetodoLlamador.CambioTipoDeComprobante Or metodoLlamador = FacturacionV2.MetodoLlamador.CambioFormaDePago) Then

                        If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                           Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                           DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then

                           pro.Precio = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()), _decimalesRedondeoEnPrecio) ' Me._decimalesAMostrarEnPrecio)
                           cargoPrecioDesdeLaBase = True
                        Else

                           pro.Precio = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()), _decimalesRedondeoEnPrecio) 'Me._decimalesAMostrarEnPrecio)
                           cargoPrecioDesdeLaBase = True
                        End If


                        If DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).AplicanOfertas Then


                           Dim oferta As Entidades.ProductoOferta = New Reglas.ProductosOfertas().GetOfertaVigente(dtpFecha.Value.Date, pro.Producto.IdProducto,
                                                                                             Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

                           If oferta IsNot Nothing Then
                              _nroOferta = oferta.IdOferta

                              If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                           Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                           DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
                                 pro.Precio = oferta.PrecioOferta
                              Else
                                 pro.Precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(oferta.PrecioOferta, pro.Producto.Alicuota,
                                                                               pro.PorcImpuestoInterno, pro.ImporteImpuestoInterno, pro.OrigenPorcImpInt)
                              End If
                           End If
                        End If

                     End If

                  Else
                     If metodoLlamador = FacturacionV2.MetodoLlamador.CambioCategoriaFiscal Then
                        If _ultimaCategoriaFiscalSeleccionada.IvaDiscriminado <> _clienteE.CategoriaFiscal.IvaDiscriminado Then
                           If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                              Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                              DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then

                              'pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString())
                              pro.Precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.Precio, pro.Producto)
                              'cargoPrecioDesdeLaBase = True
                           Else

                              'pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())
                              pro.Precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(pro.Precio, pro.Producto)
                              'cargoPrecioDesdeLaBase = True
                           End If
                        End If
                     End If
                  End If




                  If Integer.Parse(ProdDT.Rows(0)("IdMoneda").ToString()) = 2 And cargoPrecioDesdeLaBase Then
                     pro.Precio = Decimal.Round(pro.Precio * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
                  End If

                  If PrecioPorEmbalaje And cargoPrecioDesdeLaBase Then
                     pro.Precio = pro.Precio / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString())
                  End If
               End If

               If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                  If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                     DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
                     Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
                     precioParaDescuento = pro.Precio - (pro.ImporteImpuestoInterno / pro.Cantidad)
                  Else
                     precioParaDescuento = pro.Precio
                  End If
                  ''precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
               Else
                  precioParaDescuento = pro.Precio
               End If

               'Calculo el Nuevo Descuento/Recargo
               DescRec1 = Decimal.Round((precioParaDescuento * pro.DescuentoRecargoPorc1 / 100), Me._decimalesRedondeoEnPrecio)
               DescRec2 = Decimal.Round(((precioParaDescuento + DescRec1) * pro.DescuentoRecargoPorc2 / 100), Me._decimalesRedondeoEnPrecio)

               pro.DescuentoRecargo = (DescRec1 + DescRec2) * pro.Cantidad

               'Calculo el Nuevo Precio Neto
               PrecioNeto = pro.Precio + DescRec1 + DescRec2
               PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), Me._decimalesRedondeoEnPrecio)

               pro.PrecioNeto = PrecioNeto

               pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargo

               If metodoLlamador = FacturacionV2.MetodoLlamador.CambioListaDePrecibos Then
                  Dim lp = cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios)()
                  pro.IdListaPrecios = lp.IdListaPrecios
                  pro.NombreListaPrecios = lp.NombreListaPrecios
               End If

            Next

            SetProductosDataSource()

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
            If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
               Me.bscProducto2.Focus()
            Else
               Me.bscCodigoProducto2.Focus()
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub CargarProximoNumero()

      If Me.txtLetra.Text <> "" And cmbEmisor.SelectedIndex > -1 Then

         Dim oImpresora As Entidades.Impresora = DirectCast(cmbEmisor.SelectedItem, Entidades.Impresora)
         Dim oVentasNumeros As New Reglas.VentasNumeros
         Dim CentroEmisor As Short

         'CentroEmisor = oImpresoras.GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal()).CentroEmisor

         'oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

         CentroEmisor = oImpresora.CentroEmisor

         If Reglas.Publicos.Facturacion.FacturacionSolicitaNumeroDeComprobante And Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante Then
            Me.txtNumeroPosible.Text = "0"
            Me.chbNumeroAutomatico.Checked = False

         Else

            Me.txtNumeroPosible.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal,
                                                                       DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                                       Me.txtLetra.Text,
                                                                       CentroEmisor).ToString()
         End If

         Me.txtNumeroPosible.Tag = oImpresora.Marca

      Else

         Me.txtNumeroPosible.Text = ""
         Me.txtNumeroPosible.Tag = ""

      End If

      Me.CargarLineasPermitidas()

      Me.OrdenarGrillaProductos()

      'Me.OrdenarSolapas()

   End Sub

   Private Sub CargarLineasPermitidas()

      If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

         Dim oComprobanteLetra As Entidades.TipoComprobanteLetra
         oComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text)

         'Toma las Lineas del reporte especifico.
         If oComprobanteLetra.TipoComprobante.IdTipoComprobante <> "" Then

            If Reglas.Publicos.Facturacion.Impresion.FacturacionDetallaChequesyTarjetas Then
               Me._cantMaxItems = oComprobanteLetra.CantidadItemsProductos - Reglas.Publicos.Facturacion.CantMaxItemsDetallaChequesyTarjetas
            Else
               Me._cantMaxItems = oComprobanteLetra.CantidadItemsProductos
            End If

            Me._cantMaxItemsObserv = oComprobanteLetra.CantidadItemsObservaciones
            Me._imprime = oComprobanteLetra.Imprime

            'Toma las Lineas del Comprobante.
         Else
            If Reglas.Publicos.Facturacion.Impresion.FacturacionDetallaChequesyTarjetas Then
               Me._cantMaxItems = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItems - Reglas.Publicos.Facturacion.CantMaxItemsDetallaChequesyTarjetas
            Else
               Me._cantMaxItems = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItems
            End If

            Me._cantMaxItemsObserv = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItemsObserv
            Me._imprime = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime

         End If

      Else

         Me._cantMaxItems = 0
         Me._cantMaxItemsObserv = 0
         Me._imprime = False

      End If

      If Me._cantMaxItemsObserv > 0 Then
         If Not Me.tbcDetalle.Tabs("tbpObservaciones").Visible Then
            Me.tbcDetalle.Tabs("tbpObservaciones").Visible = True
         End If
      Else
         If Me.tbcDetalle.Tabs("tbpObservaciones").Visible Then
            Me._ventasObservaciones.Clear()
            SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())
            Me.tbcDetalle.Tabs("tbpObservaciones").Visible = False
         End If
      End If

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

      For Each dr As Entidades.VentaProducto In Me._ventasProductos

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

         descRec1 = Decimal.Round(precioParaDescuento * dr.DescuentoRecargoPorc1 / 100, Me._decimalesRedondeoEnPrecio)
         descRec2 = Decimal.Round((precioParaDescuento + descRec1) * dr.DescuentoRecargoPorc2 / 100, Me._decimalesRedondeoEnPrecio)
         Dim costo As Decimal = 0

         'SPC - El costo no debería ir a buscarse nuevamente. Ya está en un control de pantalla o en el datarow de la grilla
         'If dr.Producto.Lote And Reglas.Publicos.UtilizaPrecioCostoPorLote Then
         '   costo = dr.Costo
         'Else
         '   costo = New Reglas.ProductosSucursales().GetUno(dr.IdSucursal, dr.IdProducto).PrecioCosto
         'End If
         costo = dr.Costo

         If Not Me._InvocaPedido Then
            'SPC - El costo no debería calcularse nuevamente. Ya está en un control de pantalla o en el datarow de la grilla
            'If Publicos.PreciosConIVA Then
            '   'Le quito el IVA que el producto tiene en forma predeterminada.
            '   'costo = Decimal.Round((costo - (dr.ImporteImpuestoInterno / dr.Cantidad)) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
            '   costo = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(costo, dr.AlicuotaImpuesto,
            '                                                                dr.PorcImpuestoInterno, dr.Producto.ImporteImpuestoInterno,
            '                                                                dr.OrigenPorcImpInt)
            'End If

            'If dr.Producto.Moneda.IdMoneda = 2 Then
            '   costo = costo * Decimal.Parse(Me.txtCotizacionDolar.Text.ToString())

            'End If

            'If dr.Producto.PrecioPorEmbalaje Then
            '   dr.Costo = costo / dr.Producto.Embalaje
            'Else
            '   dr.Costo = costo
            'End If
         Else
            'If Not _categoriaFiscalEmpresa.IvaDiscriminado Or Not _clienteE.CategoriaFiscal.IvaDiscriminado Then
            '   costo = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(costo, dr.AlicuotaImpuesto,
            '                                                                dr.PorcImpuestoInterno, dr.Producto.ImporteImpuestoInterno,
            '                                                                dr.OrigenPorcImpInt)
            'End If
            'If dr.Producto.PrecioPorEmbalaje Then
            '   dr.Costo = costo / dr.Producto.Embalaje
            'Else
            '   dr.Costo = costo
            'End If
         End If

         importeCosto = dr.Costo * dr.Cantidad
         importeBruto = (dr.Precio + descRec1 + descRec2) * dr.Cantidad
         importeNeto = dr.PrecioNeto * dr.Cantidad
         'impuestoInterno = Decimal.Round(dr.Producto.ImporteImpuestoInterno + ((impuestoInterno - dr.Producto.ImporteImpuestoInterno) * (1 + (txtDescRecGralPorc.Text.ValorNumericoPorDefecto(0D) / 100))), Me._decimalesRedondeoEnPrecio)

         If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            'importeBruto = Decimal.Round((importeBruto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
            importeBruto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(importeBruto, dr.AlicuotaImpuesto, dr.PorcImpuestoInterno, dr.Producto.ImporteImpuestoInterno, dr.OrigenPorcImpInt),
                                         Me._decimalesRedondeoEnPrecio)
            importeNeto = Decimal.Round((importeNeto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
            'importeCosto = Decimal.Round((importeCosto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)

            importeCosto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(importeCosto, dr.AlicuotaImpuesto, dr.PorcImpuestoInterno, dr.Producto.ImporteImpuestoInterno, dr.OrigenPorcImpInt),
                                      Me._decimalesRedondeoEnPrecio)

         End If

         dr.Utilidad = importeNeto - importeCosto
         If importeCosto <> 0 Then
            dr.ContribucionMarginalPorc = Decimal.Round(dr.Utilidad / importeCosto * 100, _decimalesRedondeoEnPrecio)
         End If

         Utilidad += (importeNeto - importeCosto)
         importeNetoTotal += importeNeto
         importeCostoTotal += importeCosto

         entro = False

         For Each vi As Entidades.VentaImpuesto In Me._subTotales
            If vi.Alicuota = dr.AlicuotaImpuesto And vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA Then
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

      '# Semáforo para RENTABILIDAD
      If PorcentajeUtilidad <> 0 Then
         txtSemaforoRentabilidad.Text = PorcentajeUtilidad.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
         Me.SetearColorSemaforos(txtSemaforoRentabilidad, Entidades.SemaforoVentaUtilidad.TiposSemaforos.RENTABILIDAD)
         Me.txtSemaforoRentabilidad.Key = Utilidad.ToString()
         Me.txtSemaforoRentabilidad.Refresh()
      Else

         Me.txtSemaforoRentabilidad.Text = ""
         Me.txtSemaforoRentabilidad.BackColor = Me.txtLetra.BackColor
         Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
         Me.txtSemaforoRentabilidad.Key = "0"

      End If

   End Sub

   ''''Private Function ProductosConLote() As Integer
   ''''   Dim Cantidad As Integer = 0
   ''''   For Each vp As Entidades.VentaProducto In Me._ventasProductos
   ''''      If vp.Producto.Lote Then
   ''''         Cantidad += 1
   ''''      End If
   ''''   Next
   ''''   Return Cantidad
   ''''End Function

   Private Sub LimpiaProductoPorCambioTipoComprobante()
      _productosLotes.Clear()

      Dim vpEliminar = _ventasProductos.Where(Function(vp) vp.Producto.Lote Or vp.Producto.NroSerie)
      If vpEliminar.Count > 0 Then
         '_ventasProductos.RemoveAll(vpEliminar)

         Dim stb = New StringBuilder("Los siguientes productos utilizan Lote o Nro Serie y fueron eliminados:").AppendLine().AppendLine()
         vpEliminar.ToList().
            ForEach(
            Sub(vp)
               stb.AppendFormatLine("* {0} - {1} - {2:N2} {3}",
                                    vp.IdProducto.Trim(), vp.NombreProducto, vp.CantidadManual, vp.IdUnidadDeMedida)
               _ventasProductos.Remove(vp)
            End Sub)

         ShowMessage(stb.ToString())
      End If

      SetProductosDataSource()
   End Sub

   Private Sub LimpiarDetalle()

      _ventasDespachos = Nothing
      _ventasDespachos = New List(Of Entidades.VentaDespacho)

      _ventasProductos = Nothing
      _ventasProductos = New List(Of Entidades.VentaProducto)
      SetProductosDataSource()

      _productosLotes = New List(Of Entidades.VentaProductoLote)

      dgvRemitoTransp.DataSource = Me._ventasProductos.ToArray()

      _ventasContactos = New List(Of Entidades.ClienteContacto)()
      ugContactos.DataSource = _ventasContactos
      AjustarColumnasGrilla(ugContactos, _titContactos)

      'Me.OrdenarGrillaProductos()

      Me._subTotales = Nothing
      Me._subTotales = New List(Of Entidades.VentaImpuesto)
      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      Me._comprobantesSeleccionados = Nothing
      Me._comprobantesSeleccionados = New List(Of Entidades.Venta)

      Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados

      'Pone todo en cero.
      Me.CalcularTotales()

   End Sub

   Private Sub CalcularTotalRemitoTransporte()

      'SE tomo tal Total Neto que se calcula en CalcularTotales

      'Dim Total As Decimal = 0

      'If Me.dgvFacturables.RowCount = 0 Then
      '   'Cuando es cargado manaualmente el ImporteTotal esta neto y el ImporteImpuesto en cero.
      '   For Each vp As Entidades.VentaProducto In Me._ventasProductos
      '      Total += vp.ImporteTotal
      '   Next
      'Else
      '   For Each vi As Entidades.VentaImpuesto In Me._subTotales
      '      Total += vi.Neto
      '   Next
      'End If

      'Me.txtValorDeclarado.Text = Total.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
      '-------------------------------------------------------

      Me.txtValorDeclarado.Text = Me.txtTotalNeto.Text

      Me.txtTotalGeneral.Text = txtValorDeclarado.Text
      'Se quiere que afecte el valor declarado en el calculo.
      'Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)

   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString

   End Sub

   Private Function GetCodigoModalidadPeso() As String
      If _codigoBarrasCompleto.Length = 13 Then
         Dim num As Integer = 0
         Integer.TryParse(_codigoBarrasCompleto.Substring(0, Reglas.Publicos.CaracteresProductoCBPesoCantidad), num)
         Return num.ToString()
      Else
         Return Me._codigoBarrasCompleto
      End If
   End Function

   Private Function GetPrecioModalidadPrecio() As Decimal
      If Me._codigoBarrasCompleto.Length = 13 Then
         Return Decimal.Parse(Me._codigoBarrasCompleto.Substring(7, 5).Insert(3, "."))
      Else
         Return 0
      End If
   End Function

   Private Function GetPrecioModalidadPeso() As Decimal
      If Me._codigoBarrasCompleto.Length = 13 Then
         Return Decimal.Parse(Me._codigoBarrasCompleto.Substring(7, 5).Insert(2, "."))
      Else
         Return 0
      End If
   End Function

   Private _invocadosCajero As List(Of Entidades.Venta)

   Public Sub InvocarDesdeCajero(invocado As Entidades.Venta, idTipoComprobanteGenerar As String)
      InvocarDesdeCajero(invocado, idTipoComprobanteGenerar, soloCopia:=False)
   End Sub
   Public Sub InvocarDesdeCajero(invocado As Entidades.Venta, idTipoComprobanteGenerar As String, soloCopia As Boolean)
      _invocadosCajero = New List(Of Entidades.Venta)({invocado})
      _IdTipoComprobanteService = idTipoComprobanteGenerar
      _soloCopiaCajero = soloCopia
   End Sub

   Private _soloCopiaCajero As Boolean

   Private Sub InvocarDesdeCajero()

      Dim comprobante As Entidades.Venta = _invocadosCajero(0)

      bscCodigoCliente.Text = comprobante.Cliente.CodigoCliente.ToString()
      bscCodigoCliente.PresionarBoton()

      txtNombreClienteGenerico.Text = comprobante.NombreCliente
      txtDireccionClienteGenerico.Text = comprobante.Direccion
      bscCodigoLocalidad.Text = comprobante.Cliente.Localidad.IdLocalidad.ToString()

      If comprobante.IdCaja <> 0 Then
         cmbCajas.SelectedValue = comprobante.IdCaja
      End If

      cmbFormaPago.SelectedValue = comprobante.FormaPago.IdFormasPago

      If Not _soloCopiaCajero Then
         Me.CargarComprobantesFacturables(_invocadosCajero)
      End If
      Me.CargarProductosFacturables(_invocadosCajero)
      CargarContactosFacturables(_invocadosCajero)

      'VER, PORQUE NO SE EL TIPO DE COMPROBANTE HASTA EL FINAL
      'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
      '   Me.CargarObservacionesFacturables(invocados)
      'End If
      If Reglas.Publicos.Facturacion.FacturacionContadoEsEnPesos Then
         txtEfectivo.Text = comprobante.ImportePesos.ToString()
      End If
      txtTickets.Text = comprobante.ImporteTickets.ToString()
      txtTransferenciaBancaria.Text = comprobante.ImporteTransfBancaria.ToString()
      bscCuentaBancariaTransfBanc.Text = comprobante.CuentaBancariaTransfBanc.NombreCuenta
      bscCuentaBancariaTransfBanc.Tag = comprobante.CuentaBancariaTransfBanc.IdCuentaBancaria
      bscCuentaBancariaTransfBanc.Selecciono = True

      For Each tarjeta As Entidades.VentaTarjeta In comprobante.Tarjetas
         With tarjeta
            cmbTarTarjeta.SelectedValue = .Tarjeta.IdTarjeta
            cmbTarTarjeta.Tag = .IdTarjetaCupon.ToString
            bscTarBanco.Tag = .Banco.IdBanco
            txtTarMonto.Text = .Monto.ToString()
            txtTarCuotas.Text = .Cuotas.ToString()
            txtTarNumeroLote.Text = .NumeroLote.ToString()
            txtTarNumeroCupon.Text = .NumeroCupon.ToString()
         End With
         InsertarTarjetaGrilla()
      Next

      For Each cheque As Entidades.Cheque In comprobante.Cheques
         With cheque
            txtNroCheque.Text = .NumeroCheque.ToString()
            bscBancos.Tag = .Banco.IdBanco.ToString()
            '.Banco = New Reglas.Bancos().GetUno(Integer.Parse(Me.bscBancos._filaDevuelta.Cells("idBanco").Value.ToString()))
            txtSucursalBanco.Text = .IdBancoSucursal.ToString()
            txtCodPostalCheque.Text = .Localidad.IdLocalidad.ToString()
            dtpFechaEmision.Value = .FechaEmision
            dtpFechaCobro.Value = .FechaCobro
            txtTitularCheque.Text = .Titular
            txtImporteCheque.Text = .Importe.ToString()
         End With
         InsertarChequesGrilla()
      Next

      If Not Reglas.Publicos.Facturacion.FacturacionInvocarDeOtroCliente Then
         Me.bscCliente.Permitido = False
         Me.bscCodigoCliente.Permitido = False
      End If

      Me.LimpiarCamposProductos()
      Me.CalcularTotales()
      Me.CalcularDatosDetalle()

      If _comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 Then
         If Not Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
            Me.tbcDetalle.Tabs("tbpFacturables").Visible = True
         End If
         If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
            Me.CambiarEstadoControlesDetalle(False)
            Me.CambiarEstadoControlesDetalleRT(False)
            Me._ModificaDetalle = "SOLOPRECIOS"
            Me._ModificaDetalleRT = "NO"
         ElseIf Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "NO" AndAlso
                Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
            Me.CambiarEstadoControlesDetalle(False)
            Me.CambiarEstadoControlesDetalleRT(False)
            Me._ModificaDetalle = "NO"
            Me._ModificaDetalleRT = "NO"
            txtCotizacionDolar.Enabled = False
         End If
      Else
         If Me.tbcDetalle.Tabs("tbpFacturables").Visible Then
            Me.tbcDetalle.Tabs("tbpFacturables").Visible = False
         End If
      End If

      _turnosInvocados = _invocadosCajero(0).TurnosInvocados

      '# CRM Invocados
      _crmInvocados = _invocadosCajero(0).CrmInvocados
      chbAplicarSaldoCtaCte.Checked = Reglas.Publicos.Facturacion.FacturacionPermiteAplicarSaldoCtaCte Or _invocadosCajero(0).CrmInvocados.Count > 0

      _ventasContactos.Clear()
      If _comprobantesSeleccionados IsNot Nothing AndAlso _comprobantesSeleccionados.Count > 0 Then
         For Each contacto As Entidades.VentaClienteContacto In _comprobantesSeleccionados(0).VentasContactos
            _ventasContactos.Add(contacto.Contacto)
         Next
      End If
      ugContactos.DataSource = _ventasContactos

      '# Observaciones
      Me.bscObservacion.Text = comprobante.Observacion
      Me._ventasObservaciones = comprobante.VentasObservaciones
      ugObservaciones.DataSource = _ventasObservaciones

      tsbInvocarComprobantes.Visible = False
      tsbInvocarPedidos.Visible = False
      tsbNuevo.Visible = False

   End Sub

   Private Sub CargarTarjetaCompleto(dr As DataGridViewRow)

      If dr IsNot Nothing AndAlso
         dr.DataBoundItem IsNot Nothing AndAlso
         TypeOf (dr.DataBoundItem) Is Entidades.VentaTarjeta Then
         Dim vt As Entidades.VentaTarjeta = DirectCast(dr.DataBoundItem, Eniac.Entidades.VentaTarjeta)
         cmbTarTarjeta.SelectedValue = vt.Tarjeta.IdTarjeta
         If vt.Banco IsNot Nothing AndAlso vt.Banco.IdBanco > 0 Then
            bscTarBanco.Text = vt.Banco.NombreBanco
            bscTarBanco.PresionarBoton()
         End If

         txtTarMonto.Text = vt.Monto.ToString("N2")
         txtTarCuotas.Text = vt.Cuotas.ToString()
         txtTarNumeroCupon.Text = vt.NumeroCupon.ToString()
         Me.txtTarNumeroLote.Text = vt.NumeroLote.ToString()

      End If

   End Sub

   Private Sub ChequeaCajas()
      If _enNuevo Then Return
      SeteaColorGroupboxCliente()
      SeteaTituloVentana()

      If cmbFormaPago.SelectedIndex < 0 Then Exit Sub
      If cmbCajas.SelectedIndex < 0 Then Exit Sub

      If DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante) IsNot Nothing Then
         If DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja And DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then

            Dim rCajas = New Reglas.Cajas()
            Dim oPlanilla = rCajas.GetPlanillaActual(actual.Sucursal.IdSucursal, cmbCajas.ValorSeleccionado(Of Integer))

            '# Se agrega validación por si la sucursal no posee una Planilla creada
            If oPlanilla Is Nothing Then Throw New Exception("Esta sucursal no tiene planilla de caja creada para la forma de pago seleccionada.")

            Dim saldoCaja = rCajas.GetSaldoPesosFinal(actual.Sucursal.IdSucursal, cmbCajas.ValorSeleccionado(Of Integer), oPlanilla.NumeroPlanilla) +
                            rCajas.GetSaldoChequesFinal(actual.Sucursal.IdSucursal, cmbCajas.ValorSeleccionado(Of Integer), oPlanilla.NumeroPlanilla)
            Dim totalCaja = saldoCaja + txtEfectivo.ValorNumericoPorDefecto(0D) + txtCheques.ValorNumericoPorDefecto(0D) +
                            (txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D))

            Dim rCajasNombre = New Reglas.CajasNombres()
            Dim caja = rCajasNombre.GetUna(actual.Sucursal.IdSucursal, cmbCajas.ValorSeleccionado(Of Integer))
            If caja.TopeAviso > 0 And totalCaja >= caja.TopeAviso And totalCaja < caja.TopeBloqueo Then
               ShowMessage(String.Format("Superó el Limite Recomendado de {0:N2}, y está por llegar al Límite Permitido en Caja de {0:N2}",
                                         caja.TopeAviso, caja.TopeBloqueo))
            ElseIf caja.TopeBloqueo > 0 And totalCaja >= caja.TopeBloqueo Then
               ShowMessage(String.Format("Llegó al Límite Permitido en Caja de {0:N2}", caja.TopeBloqueo))
            End If

         End If
      End If
   End Sub

   Private Sub SeteaTituloVentana()
      Dim prefijo As String = ""
      Dim orden As String = Reglas.Publicos.Facturacion.FacturacionOrdenDeTitulo
      Dim formato As String = ""
      Dim facturacionCajaEnTitulo As Boolean = Reglas.Publicos.Facturacion.FacturacionCajaEnTitulo
      Dim facturacionVendedorEnTitulo As Boolean = Reglas.Publicos.Facturacion.FacturacionVendedorEnTitulo

      If facturacionVendedorEnTitulo And facturacionCajaEnTitulo Then
         If orden = Entidades.Publicos.FacturacionOrdenesDeTitulo.VENDEDORCAJA.ToString() Then
            formato = "{0} - {1} - "
         Else
            formato = "{1} - {0} - "
         End If
      ElseIf facturacionVendedorEnTitulo Then
         formato = "{0} - "
      ElseIf facturacionCajaEnTitulo Then
         formato = "{1} - "
      End If

      prefijo = String.Format(formato, cmbVendedor.Text, cmbCajas.Text)

      Me.Text = prefijo + _tituloOriginal
   End Sub

   Private Sub SeteaColorGroupboxCliente()
      SeteaColorGroupboxCliente(cmbCajas, cmbVendedor, cmbTiposComprobantes, grbCliente)
   End Sub

   Private Sub SolicitarFormula()
      If _solicitaModificarFormulaLuegoDelProducto And cmbFormula.SelectedIndex > -1 Then
         Using frm As New FormulasABM()
            If frm.ShowDialog(bscCodigoProducto2.Text, Integer.Parse(cmbFormula.SelectedValue.ToString()), _ventasProductosFormulasActual) = Windows.Forms.DialogResult.OK Then
               _ventasProductosFormulasActual = frm.Componentes.Copy()
            End If
         End Using
      End If
   End Sub

   Private Sub CalculaPreciosSegunFormula()
      If _calculaPreciosSegunFormula Then
         If cmbFormula.SelectedIndex = -1 Then
            Exit Sub
            'cmbFormula.Focus()
            'Throw New Exception("El producto seleccionado calcula sus precios según su FORMULA. No ha seleccionado una Formula. Por favor reintente.")
         End If
         Dim idFormula As Integer = Integer.Parse(cmbFormula.SelectedValue.ToString())

         SolicitarFormula()

         Dim idListaDePrecios As Integer = Publicos.ListaPreciosPredeterminada
         If cmbListaDePrecios.SelectedIndex > -1 Then idListaDePrecios = Integer.Parse(cmbListaDePrecios.SelectedValue.ToString())


         Dim rProductoComponente As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
         Dim preciosProducto As Entidades.PreciosProducto
         preciosProducto = rProductoComponente.CalculaPreciosSegunFormula(actual.Sucursal.Id, bscCodigoProducto2.Text, idFormula, idListaDePrecios,
                                                                          0, 0, 0, 0, modeloForma:=Nothing,
                                                                          _ventasProductosFormulasActual, txtCotizacionDolar.ValorNumericoPorDefecto(0D))

         If (Me._clienteE.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
         Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            If Me.txtPrecioVentaPorTamano.Enabled Then
               Me.txtPrecioVentaPorTamano.Text = preciosProducto.PrecioVentaSinIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            Else
               txtPrecio.Text = preciosProducto.PrecioVentaSinIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            End If
            txtCosto.Text = preciosProducto.PrecioCostoSinIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            If bscCodigoProducto2.FilaDevuelta IsNot Nothing Then bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value = preciosProducto.PrecioVentaSinIVA
         Else
            If Me.txtPrecioVentaPorTamano.Enabled Then
               txtPrecioVentaPorTamano.Text = preciosProducto.PrecioVentaConIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            Else
               txtPrecio.Text = preciosProducto.PrecioVentaConIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            End If
            txtCosto.Text = preciosProducto.PrecioCostoConIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            If bscCodigoProducto2.FilaDevuelta IsNot Nothing Then bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value = preciosProducto.PrecioVentaConIVA
         End If

         txtCosto.Tag = preciosProducto.PrecioCostoSinIVA.ToString("N" + _decimalesAMostrarEnPrecio.ToString())

      End If
   End Sub

#End Region

   '-- REQ-33524.- -----------------------------------------------------------
   Private Sub CargaComboBusquedaDomicilio()
      cmbBusquedaDomicilio.Items.Add(BusquedaClienteSecundaria_CUIT)
      cmbBusquedaDomicilio.Items.Add(BusquedaClienteSecundaria_DOMICILIO)
      If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
         cmbBusquedaDomicilio.Items.Add(BusquedaClienteSecundaria_EMBARCACION)
      End If
      If New Reglas.Generales().ExisteTabla("Camas") Then
         cmbBusquedaDomicilio.Items.Add(BusquedaClienteSecundaria_CAMA)
      End If
   End Sub
   '--------------------------------------------------------------------------

   Private Sub cmbFormula_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFormula.SelectedValueChanged
      Try
         If Not _cargandoComboFormula And Not _cargandoProductoDesdeCompleto Then
            CalculaPreciosSegunFormula()
         End If
      Catch ex As Exception
         ShowError(ex)
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

   Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidadManual.Enter, txtCantidad.Enter
      Try
         If txtCantidadManual.Tag IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtCantidadManual.Tag.ToString()) Then
            ToolTip1.Show(txtCantidadManual.Tag.ToString(), txtCantidadManual, New Point(0, 17))
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidadManual.Leave, txtCantidad.Leave
      Try
         ToolTip1.Hide(txtCantidadManual)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVendedor.SelectedIndexChanged
      Try
         If Reglas.Publicos.Facturacion.FacturacionVendedorEnTitulo Then
            SeteaTituloVentana()
         End If
         SeteaColorGroupboxCliente()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbCentroCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCentroCosto.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            btnInsertar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbEmisor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmisor.SelectedIndexChanged
      Try
         CargarProximoNumero()
      Catch ex As Exception
         ShowError(ex)
      End Try
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
         For Each contacto As Entidades.ClienteContacto In _ventasContactos
            If contacto.IdContacto = contactoCombo.IdContacto Then
               existe = True
            End If
         Next
         If Not existe Then
            _ventasContactos.Add(DirectCast(cmbContacto.SelectedItem, Entidades.ClienteContacto))
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
            _ventasContactos.Remove(DirectCast(ugContactos.ActiveRow.ListObject, Entidades.ClienteContacto))
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

   Private Sub txtPrecioVentaPorTamano_Leave(sender As Object, e As EventArgs) Handles txtPrecioVentaPorTamano.Leave
      Try
         If txtPrecioVentaPorTamano.Enabled Then
            If IsNumeric(txtPrecioVentaPorTamano.Text) Then
               Dim precioVentaPorTamano As Decimal = Decimal.Parse(txtPrecioVentaPorTamano.Text)
               Dim tamano As Decimal = Decimal.Parse(txtTamanio.Text)
               Dim cotizacionDolar As Decimal = Decimal.Parse(txtCotizacionDolar.Text)
               If cmbMoneda.SelectedIndex = -1 Then
                  cotizacionDolar = 0
               ElseIf cmbMoneda.SelectedValue.Equals(1) Then
                  cotizacionDolar = 1
               End If
               txtPrecio.Text = Decimal.Round((precioVentaPorTamano * tamano * cotizacionDolar), _decimalesRedondeoEnPrecio).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPrecioVentaPorTamano_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioVentaPorTamano.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaDescRecargo.Checked Then
            Me.txtDescRecPorc1.Focus()
            Me.txtDescRecPorc1.SelectAll()
         Else
            Me.btnInsertar.Focus()
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

         If PorcentajeUtilidad <> 0 Then
            txtSemaforoRentabilidadDetalle.Text = PorcentajeUtilidad.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
            Me.SetearColorSemaforos(txtSemaforoRentabilidadDetalle, Entidades.SemaforoVentaUtilidad.TiposSemaforos.RENTABILIDAD)
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

   Private _modificoPrecioManualmente As Boolean = False
   Private _txtPrecioEnter As Decimal
   Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
      TryCatched(Sub() _txtPrecioEnter = txtPrecio.ValorNumericoPorDefecto(0D))
   End Sub

   Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
      TryCatched(
      Sub()
         If txtPrecio.Text.Trim().Length = 0 Then
            txtPrecio.Text = _ceroEnPrecio
         End If
         'dp - Lo comento para hasta que Bazar Celta defina como lo quiere.
         'If Decimal.Parse(Me.txtPrecio.Text) <= 0 And Not Me._ventasConProductosEnCero Then
         '   Dim oProd As Reglas.Productos = New Reglas.Productos()
         '   Dim prod As Entidades.Producto = New Entidades.Producto()
         '   prod = oProd.GetUno(Me.bscCodigoProducto2.Text)
         '   If Not prod.EsObservacion Then
         '      MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '      FocusPrecio()
         '      Exit Sub
         '   End If
         'End If

         '-- PE-41304.- --------------------------------------------------------------------------
         If Not _modificoPrecioManualmente Then
            _modificoPrecioManualmente = _txtPrecioEnter <> txtPrecio.ValorNumericoPorDefecto(0D)
         End If
         '----------------------------------------------------------------------------------------

         CalcularDescuentosProductos()
         CalcularTotalProducto()
         CalcularImpuestoInterno()
      End Sub)
   End Sub

   Private Sub txtDescRecPorc1_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc1.Leave
      Try
         If Me.txtDescRecPorc1.Text = "" Or Me.txtDescRecPorc1.Text = "-" Then
            Me.txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
         Me.CalcularImpuestoInterno()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecPorc2_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc2.Leave
      Try
         If Me.txtDescRecPorc2.Text = "" Or Me.txtDescRecPorc2.Text = "-" Then
            Me.txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
         Me.CalcularImpuestoInterno()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtDescRec_Leave(sender As Object, e As EventArgs) Handles txtDescRec.Leave
      Try
         If Not IsNumeric(Me.txtDescRec.Text) Then
            Me.txtDescRec.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.CalcularDescRecargoProductosXMonto()
         Me.CalcularTotalProducto()
         Me.CalcularImpuestoInterno()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CalcularDescRecargoProductosXMonto()
      Dim nuevoDescuento As Decimal = Decimal.Parse(Me.txtDescRec.Text)
      If nuevoDescuento <> 0 Then
         Dim precioBase As Decimal = Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(txtCantidad.Text)
         Dim porcCalculado As Decimal = 0

         Dim calculaDesc2 As Boolean = Decimal.Parse(txtDescRecPorc2.Text) <> 0
         If calculaDesc2 Then
            Dim descuento As Decimal = precioBase * (Decimal.Parse(txtDescRecPorc1.Text) / 100)
            nuevoDescuento = nuevoDescuento - descuento
            precioBase = precioBase + descuento

         End If
         porcCalculado = nuevoDescuento / precioBase * 100

         If Not calculaDesc2 Then
            txtDescRecPorc1.Text = porcCalculado.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         Else
            txtDescRecPorc2.Text = porcCalculado.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         End If
      Else
         Me.txtDescRec.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         Me.txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         Me.txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      End If
   End Sub
   Private Function GetNuevoImporteImpuestoInterno(vp As Entidades.VentaProducto, producto As Entidades.Producto) As Decimal
      Dim precioNeto As Decimal = vp.Precio


      'If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or _
      '   Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
      '   precioNeto = Decimal.Parse(txtPrecio.Text)
      'Else
      '   precioNeto = (Decimal.Parse(txtPrecio.Text) - importeImpuestoInternoProducto) / (1 + (alicuotaIVA / 100) + (PorcImpuestoInterno / 100))
      'End If

      precioNeto = precioNeto * (1 + (vp.DescuentoRecargoPorc1 / 100))
      precioNeto = precioNeto * (1 + (vp.DescuentoRecargoPorc2 / 100))
      precioNeto = precioNeto * (1 + (vp.DescRecGeneralProducto / 100))

      Dim impuestoInterno As Decimal

      'If DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado Then
      If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
          Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
         'El precio en pantalla está sin IVA
         impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, vp.AlicuotaImpuesto,
                                                                                             producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
      Else
         'El precio en pantalla está con IVA
         impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, vp.AlicuotaImpuesto,
                                                                                             producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
      End If

      impuestoInterno = impuestoInterno * vp.Cantidad

      Return impuestoInterno

   End Function

   Private Function GetTipoOperacionSeleccionada() As Entidades.Producto.TiposOperaciones
      If cmbTipoOperacion.SelectedIndex = -1 Then Return Entidades.Producto.TiposOperaciones.NORMAL
      Return DirectCast(cmbTipoOperacion.SelectedItem, Entidades.Producto.TiposOperaciones)
   End Function

   Private Sub cmbTipoOperacion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoOperacion.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtCuitChequeTercero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuitChequeTercero.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
      Try
         _publicos.CargaComboObservaciones(cmbNota, DirectCast(cmbTipoOperacion.SelectedItem, Entidades.Producto.TiposOperaciones))
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Shared Function GetImpIntDesdeBusquedas(bscCodigoProducto2 As Eniac.Controles.Buscador2, bscNombreProducto2 As Eniac.Controles.Buscador2) As ImpIntDesdeBusquedas
      Dim result As ImpIntDesdeBusquedas = New ImpIntDesdeBusquedas()
      Dim dgvr As DataGridViewRow = Nothing
      If bscCodigoProducto2.Selecciono Then
         dgvr = bscCodigoProducto2.FilaDevuelta
      ElseIf bscNombreProducto2.Selecciono Then
         dgvr = bscNombreProducto2.FilaDevuelta
      End If

      If dgvr IsNot Nothing Then
         With dgvr
            If .Cells("ImporteImpuestoInterno").Value IsNot Nothing Then
               result.ImporteImpuestoInterno = Decimal.Parse(.Cells("ImporteImpuestoInterno").Value.ToString())
            End If
            If .Cells("PorcImpuestoInterno").Value IsNot Nothing Then
               result.PorcImpuestoInterno = Decimal.Parse(.Cells("PorcImpuestoInterno").Value.ToString())
            End If
            If .Cells("OrigenPorcImpInt").Value IsNot Nothing Then
               result.OrigenPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), .Cells("OrigenPorcImpInt").Value.ToString()), Entidades.OrigenesPorcImpInt)
            End If
         End With
      End If
      Return result
   End Function

   Public Class ImpIntDesdeBusquedas
      Public Property ImporteImpuestoInterno As Decimal
      Public Property PorcImpuestoInterno As Decimal
      Public Property OrigenPorcImpInt As Entidades.OrigenesPorcImpInt
      Public Sub New()
         ImporteImpuestoInterno = 0
         PorcImpuestoInterno = 0
         OrigenPorcImpInt = Entidades.OrigenesPorcImpInt.BRUTO
      End Sub
   End Class

   Private Sub tsbInvocarCompras_Click(sender As Object, e As EventArgs) Handles tsbInvocarCompras.Click
      Try
         _cargaProductoDesdeInvocacion = True

         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            Exit Sub
         End If




         'Me._InvocaPedido = True

         If Me.cmbTiposComprobantes.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un Tipo de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If


         Dim IdTipoComprobante As String = ""
         If Me.dgvFacturables.RowCount > 0 Then
            If Me._comprobantesSeleccionados IsNot Nothing Then
               If Me._comprobantesSeleccionados.Count > 0 Then
                  IdTipoComprobante = Me._comprobantesSeleccionados(0).TipoComprobante.IdTipoComprobante
               End If
            End If
         End If


         Dim comprobantesSeleccionados As List(Of Entidades.Compra)
         If Me.dgvFacturables.Rows.Count = 0 Then
            comprobantesSeleccionados = New List(Of Entidades.Compra)()
         Else
            comprobantesSeleccionados = ConvertirComprobantesFacturables(DirectCast(Me.dgvFacturables.DataSource, List(Of Entidades.Venta)))
         End If
         Using oFactAyuda As FacturablesPendientesComAyuda = New FacturablesPendientesComAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(),
                                                                                               IdTipoComprobante,
                                                                                               IdProveedor:=0,
                                                                                               comprobantesSeleccionados:=comprobantesSeleccionados,
                                                                                               invocandoDesde:=FacturablesPendientesComAyuda.OrigenInvocacion.Ventas)
            If oFactAyuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Dim cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()
               _ventasProductos.Clear()
               Dim productos As List(Of Entidades.CompraProducto) = New List(Of Entidades.CompraProducto)()
               For Each compra As Entidades.Compra In oFactAyuda.ComprobantesSeleccionados

                  'Agrupo los productos que tienen concepto y el mismo un producto en una misma linea
                  For Each cp As Entidades.CompraProducto In compra.ComprasProductos.Where(Function(x) x.IdConcepto > 0)
                     Dim concepto As Entidades.Concepto = cache.BuscaConcepto(cp.IdConcepto)
                     If Not String.IsNullOrWhiteSpace(concepto.IdProducto) Then
                        Dim colCP As List(Of Entidades.CompraProducto) = productos.Where(Function(x) x.Producto.IdProducto = concepto.IdProducto).ToList()
                        If colCP.Count = 0 Then
                           Dim producto As Entidades.Producto = cache.BuscaProductoEntidadPorId(concepto.IdProducto)
                           cp.Producto = producto
                           cp.Cantidad = 1
                           productos.Add(cp)
                        Else
                           colCP(0).Precio += cp.Precio
                        End If
                     Else
                        productos.Add(cp)
                     End If
                  Next
                  For Each cp As Entidades.CompraProducto In compra.ComprasProductos.Where(Function(x) x.IdConcepto = 0)
                     productos.Add(cp)
                  Next
               Next

               For Each compraProducto As Entidades.CompraProducto In productos ' compra.ComprasProductos
                  bscCodigoProducto2.Text = compraProducto.Producto.IdProducto
                  bscCodigoProducto2.PresionarBoton()
                  txtProductoObservacion.Text = compraProducto.NombreProducto '# Mantengo el nombre con el que se guardó la compra

                  txtCantidadManual.Focus()
                  txtCantidad.Text = compraProducto.Cantidad.ToString("N" + _decimalesMostrarEnCantidad.ToString())
                  txtCantidadManual.Text = txtCantidad.Text
                  txtPrecio.Focus()
                  txtPrecio.Text = compraProducto.Precio.ToString("N" + _decimalesRedondeoEnPrecio.ToString())
                  If _utilizaCentroCostos Then
                     cmbCentroCosto.SelectedValue = compraProducto.CentroCosto.IdCentroCosto
                  End If
                  If _clienteE IsNot Nothing Then
                     If Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
                        txtPrecio.Text = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(compraProducto.Precio,
                                                                                              compraProducto.PorcentajeIVA,
                                                                                              compraProducto.Producto.PorcImpuestoInterno,
                                                                                              compraProducto.Producto.ImporteImpuestoInterno,
                                                                                              compraProducto.Producto.OrigenPorcImpInt).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
                     End If
                  End If
                  cmbPorcentajeIva.SelectedValue = compraProducto.PorcentajeIVA
                  btnInsertar.Focus()
                  btnInsertar.PerformClick()
               Next
               CargarComprobantesFacturables(oFactAyuda.ComprobantesSeleccionados)
            End If


            'Dim oPedidosAyuda As PedidosPendientesAyuda

            'If Me.dgvFacturables.Rows.Count = 0 Then
            '   oPedidosAyuda = New PedidosPendientesAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
            'Else
            '   oPedidosAyuda = New PedidosPendientesAyuda(Me.cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), DirectCast(Me.dgvFacturables.DataSource, List(Of Entidades.Venta)))
            'End If

            'oPedidosAyuda.ShowDialog()

            'Me.CargarComprobantesFacturables(oPedidosAyuda.ComprobantesSeleccionados)
            'Me.CargarProductosFacturables(oPedidosAyuda.ComprobantesSeleccionados)
            'CargarContactosFacturables(oPedidosAyuda.ComprobantesSeleccionados)

            'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
            '   Me.CargarObservacionesFacturables(oPedidosAyuda.ComprobantesSeleccionados)
            'End If

            'Me.bscCliente.Permitido = False
            'Me.bscCodigoCliente.Permitido = False

            'Me.LimpiarCamposProductos()
            'Me.CalcularTotales()
            'Me.CalcularDatosDetalle()
            ''Me.CalcularTotales()

            'If Me.tbcDetalle.Contains(Me.tbpRemitoTransp) Then
            '   Me.CalcularTotalRemitoTransporte()
            'End If


            'If Me._comprobantesSeleccionados.Count > 0 Then
            '   If Not Me.tbcDetalle.Contains(Me.tbpFacturables) Then
            '      Me.tbcDetalle.TabPages.Add(Me.tbpFacturables)
            '   End If
            '   If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
            '      Me.CambiarEstadoControlesDetalle(False)
            '      Me.CambiarEstadoControlesDetalleRT(False)
            '      Me._ModificaDetalle = "SOLOPRECIOS"
            '      Me._ModificaDetalleRT = "NO"
            '   ElseIf Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "NO" Then 'AndAlso
            '      'Me.tbcDetalle.Tabs(Me.tbpRemitoTransp) Then
            '      Me.CambiarEstadoControlesDetalle(False)
            '      Me.CambiarEstadoControlesDetalleRT(False)
            '      Me._ModificaDetalle = "NO"
            '      Me._ModificaDetalleRT = "NO"
            '      txtCotizacionDolar.Enabled = False
            '   End If
            'Else
            '   If Me.tbcDetalle.Contains(Me.tbpFacturables) Then
            '      Me.tbcDetalle.TabPages.Remove(Me.tbpFacturables)
            '   End If
            'End If

         End Using

      Catch ex As Exception
         ShowError(ex)
      Finally
         _cargaProductoDesdeInvocacion = False
      End Try
   End Sub


   Private Sub HabilitaCotizacionDolar()
      'txtCotizacionDolar.Enabled = _puedeEditarDolar AndAlso _ModificaDetalle <> "NO" AndAlso _ventasProductos.LongCount(Function(x) x.IdMoneda > 1) = 0
   End Sub

   Private Function GetTipoComprobanteSeleccionado() As Entidades.TipoComprobante
      Return cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)() ' DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)
   End Function

   Private Sub lllSaldoCtaCte_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lllSaldoCtaCte.LinkClicked
      Try
         Me.Cursor = Cursors.WaitCursor
         If New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "RecibosNuevos") Then
            If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
               Using Recibos As Recibos = New Recibos(Long.Parse(bscCodigoCliente.Text), 0, cerraLuegoDeGrabar:=False)
                  Recibos.IdFuncion = "RecibosNuevos"
                  Recibos.ShowDialog(Me)
               End Using
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnObservacionCliente_Click(sender As Object, e As EventArgs) Handles btnObservacionCliente.Click
      Try
         If MessageBox.Show("¿Desea ingresar nuevas observaciones ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            Dim ocli As Reglas.Clientes = New Reglas.Clientes()
            _clienteE.Observacion = Me.txtObservacion.Text
            _clienteE.Usuario = actual.Nombre

            ocli.Actualizar(_clienteE)

            MessageBox.Show("La observación fue registrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkProducto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkProducto.LinkClicked
      Try
         Dim pr As ProductosDetalle = New ProductosDetalle(New Entidades.Producto())
         pr.StateForm = StateForm.Insertar
         pr.CierraAutomaticamente = True
         If pr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoProducto2.Text = pr.IdProducto
            Me.bscCodigoProducto2.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpFechaTransferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaTransferencia.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.cmbTarTarjeta.Focus()
      End If
   End Sub

   Private Sub dgvCheques_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCheques.CellDoubleClick
      Try
         Me.LimpiarCamposCheques()
         'carga el producto seleccionado de la grilla en los textbox 
         Me.CargarChequeCompleto(Me.dgvCheques.Rows(e.RowIndex))
         'elimina el producto de la grilla
         Me.EliminarLineaCheques()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarChequeCompleto(dr As DataGridViewRow)

      If dr IsNot Nothing AndAlso
         dr.DataBoundItem IsNot Nothing AndAlso
         TypeOf (dr.DataBoundItem) Is Entidades.Cheque Then

         Dim oCheque As Entidades.Cheque = DirectCast(dr.DataBoundItem, Entidades.Cheque)

         With oCheque
            If .Banco IsNot Nothing AndAlso .Banco.IdBanco > 0 Then
               bscBancos.Text = .Banco.NombreBanco
               bscBancos.PresionarBoton()
            End If
            Me.txtSucursalBanco.Text = .IdBancoSucursal.ToString()
            Me.txtCodPostalCheque.Text = .Localidad.IdLocalidad.ToString()
            Me.dtpFechaEmision.Value = .FechaEmision
            Me.dtpFechaCobro.Value = .FechaCobro
            Me.txtTitularCheque.Text = .Titular
            Me.txtNroCheque.Text = .NumeroCheque.ToString()
            Me.txtImporteCheque.Text = .Importe.ToString("N2")
            Me.txtCuitChequeTercero.Text = .Cuit

            Me.cmbTipoCheque.SelectedValue = .IdTipoCheque.ToString()
            Me.txtNroOperacion.Text = .NroOperacion.ToString()
         End With

      End If

   End Sub

   Private Sub CalculosDescuentosRecargos1_ReporteEstado(sender As Object, e As CalculosDescuentosRecargosReporteEstadoEventArgs) Handles CalculosDescuentosRecargos1.ReporteEstado
      Try
         lblEstado.Text = e.Estado
         Application.DoEvents()
      Catch ex As Exception
      End Try
   End Sub

   Private Sub NavegacionDesdeClienteSegunParametros()
      'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
      If Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante And Me._clienteE.IdTipoComprobante = "" Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me.cmbTiposComprobantes.Focus()
      End If

      If Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorPorClave And Not _mantenerVendedor Then
         Me.cmbVendedor.SelectedIndex = -1
         Me.cmbVendedor.Enabled = False
      Else
         If Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor And Not _mantenerVendedor Then
            Me.cmbVendedor.SelectedIndex = -1
            Me.cmbVendedor.Focus()
         End If
      End If

      If Me.tbcDetalle.Tabs("tbpRemitoTransp").Visible Then
         If Not Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante And Not Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
            Me.bscCodigoProducto2RT.Focus()
         End If
      Else
         If Not Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante And Not Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
            If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
               Me.bscProducto2.Focus()
            Else
               Me.bscCodigoProducto2.Focus()
            End If
         End If
      End If
   End Sub

   Private Sub txtNombreClienteGenerico_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreClienteGenerico.KeyDown
      If e.KeyCode = Keys.Enter Then
         'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
         NavegacionDesdeClienteSegunParametros()
      End If
   End Sub

   Private Sub chbEsCtaOrden_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsCtaOrden.CheckedChanged
      If chbEsCtaOrden.Checked Then
         Me.bscProveedor.Enabled = True
      Else
         Me.bscProveedor.Text = ""
         Me.bscProveedor.Enabled = False
      End If
   End Sub

   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      If Me.cmbTipoCheque.SelectedIndex <> -1 Then
         If Not DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion Then
            Me.txtNroOperacion.Clear()
            Me.txtNroOperacion.Enabled = False
         Else
            Me.txtNroOperacion.Enabled = True
         End If
      End If
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
         End If
         Me.txtNroCheque.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
   End Sub

   Private Sub txtDireccionClienteGenerico_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccionClienteGenerico.KeyDown
      If e.KeyCode = Keys.Enter Then
         'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
         NavegacionDesdeClienteSegunParametros()
      End If
   End Sub

   Private Sub bscCodigoLocalidad_KeyDown(sender As Object, e As KeyEventArgs) Handles bscCodigoLocalidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
         NavegacionDesdeClienteSegunParametros()
      End If
   End Sub

   Private Sub btnRefrescarPaciente_Click(sender As Object, e As EventArgs) Handles btnRefrescarPaciente.Click
      Try
         Me.LimpiarPaciente()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnRefrescarDoctor_Click(sender As Object, e As EventArgs) Handles btnRefrescarDoctor.Click
      Try
         Me.LimpiarDoctor()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFechaCirugia_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaCirugia.CheckedChanged
      Try
         Me.dtpFechaCirugia.Enabled = Me.chbFechaCirugia.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub llbPaciente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbPaciente.LinkClicked
      Try
         MostrarMasInfoPaciente()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub llbDoctor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDoctor.LinkClicked
      Try
         MostrarMasInfoDoctor()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantidadManual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadManual.KeyPress
      Try
         If e.KeyChar = "*" Then
            Me.cmbUM2.Focus()
            Me.cmbUM2.DroppedDown = True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbUM2_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUM2.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            Me.txtCantidadManual.Focus()
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

   Private Sub txtCantidadManualRT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadManualRT.KeyPress
      Try
         If e.KeyChar = "*" Then
            Me.cmbUM2RT.Focus()
            Me.cmbUM2RT.DroppedDown = True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantidadManualRT_Leave(sender As Object, e As EventArgs) Handles txtCantidadManualRT.Leave
      Try
         SeteaConversionUnidadesMedidaRT()
         ''# En caso de que la unidad de medida seleccionada NO sea la unidad de medida principal del producto, realizo la conversión
         'Dim f = If(Me.bscCodigoProducto2RT.FilaDevuelta IsNot Nothing, Me.bscCodigoProducto2RT.FilaDevuelta, Nothing)
         'If f IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.txtCantidadManualRT.Text) Then
         '   Me.txtCantidadRT.Text = Me.RealizarConversionUnidadesMedida(CDec(Me.txtCantidadManualRT.Text), CDec(f.Cells("Conversion").Value), Me.cmbUM2RT).ToString()
         'End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbUM2RT_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUM2RT.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            Me.txtCantidadManualRT.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbUM2RT_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUM2RT.SelectedValueChanged
      Try
         SeteaConversionUnidadesMedidaRT()
         ''# En caso de que la unidad de medida seleccionada NO sea la unidad de medida principal del producto, realizo la conversión
         'Dim f = If(Me.bscCodigoProducto2RT.FilaDevuelta IsNot Nothing, Me.bscCodigoProducto2RT.FilaDevuelta, Nothing)
         'If f IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.txtCantidadManualRT.Text) Then
         '   Me.txtCantidadRT.Text = Me.RealizarConversionUnidadesMedida(CDec(Me.txtCantidadManualRT.Text), CDec(f.Cells("Conversion").Value), Me.cmbUM2RT).ToString()
         'End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCantidadManual_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadManual.TextChanged
      TryCatched(Sub() SeteaConversionUnidadesMedida())
   End Sub

#Region "Factura de Exportacion.- "
   '-- REQ-31198.- -Factura de Exportacion.- --
   Private Sub txtLetra_TextChanged(sender As Object, e As EventArgs) Handles txtLetra.TextChanged
      If UCase(txtLetra.Text) = "E" Then
         Me.tbcDetalle.Tabs("tbpExportacion").Visible = True

         dtpFechaPagoExportacion.Enabled = _ventasProductos.Any(Function(vp) vp.Producto.EsServicio)
      Else
         Me.tbcDetalle.Tabs("tbpExportacion").Visible = False

         dtpFechaPagoExportacion.Enabled = False
      End If
   End Sub

   Private Sub btnLimpiarEmbarques_Click(sender As Object, e As EventArgs) Handles btnLimpiarEmbarques.Click
      '-- Limpia Campos de Carga.- --
      LimpiarCamposExportacion()
      txtCodigoDespacho.Focus()
   End Sub

   Private Sub LimpiarCamposExportacion()
      cmbDestinoDespacho.SelectedIndex = -1
      txtCodigoDespacho.Text = ""
   End Sub

   '-- Insercion de Despachos.- ----------------------------
   Private Sub btnInsertarDespacho_Click(sender As Object, e As EventArgs) Handles btnInsertarDespacho.Click
      Try
         If txtCodigoDespacho.Text <> "" Then
            If ValidarInsertaDespacho() Then
               InsertarDespacho()
               txtCodigoDespacho.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function ValidarInsertaDespacho() As Boolean

      If txtCodigoDespacho.Text = "" Or Len(txtCodigoDespacho.Text) <> 16 Then
         ShowMessage("Se debe ingresar un Codigo de Despacho Igual a 16 digitos.")
         txtCodigoDespacho.Focus()
         Return False
      End If

      If cmbDestinoDespacho.SelectedIndex = -1 Then
         ShowMessage("Se debe seleccionar un destino de Despacho.")
         cmbDestinoDespacho.Focus()
         Return False
      End If
      Return True

   End Function

   Private Sub InsertarDespacho()

      Dim oDespacho = New Entidades.VentaDespacho()

      With oDespacho
         .IdPermisoEmbarque = txtCodigoDespacho.Text.ToUpper()
         .IdDestinoDespacho = cmbDestinoDespacho.SelectedValue.ToString()
         .DescripcionDespacho = cmbDestinoDespacho.Text
      End With
      _ventasDespachos.Add(oDespacho)

      dgvEmbarqueDespacho.DataSource = _ventasDespachos.ToArray()

      LimpiarCamposExportacion()

   End Sub

   Private Sub btnEliminarDespacho_Click(sender As Object, e As EventArgs) Handles btnEliminarDespacho.Click
      Try
         If dgvEmbarqueDespacho.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

               EliminarDespacho()

               txtCodigoDespacho.Focus()
            End If
         End If
         LimpiarCamposExportacion()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub EliminarDespacho()

      _ventasDespachos.RemoveAt(dgvEmbarqueDespacho.SelectedRows(0).Index)
      dgvEmbarqueDespacho.DataSource = _ventasDespachos.ToArray()

      If dgvEmbarqueDespacho.Rows.Count > 0 Then
         If _comprobantesSeleccionados Is Nothing OrElse _comprobantesSeleccionados.Count = 0 Then
            dgvEmbarqueDespacho.FirstDisplayedScrollingRowIndex = dgvEmbarqueDespacho.Rows.Count - 1
            dgvEmbarqueDespacho.Rows(dgvEmbarqueDespacho.Rows.Count - 1).Selected = True
         Else
            dgvEmbarqueDespacho.FirstDisplayedScrollingRowIndex = 0
            dgvEmbarqueDespacho.Rows(0).Selected = True
         End If

      End If

   End Sub

   Private Sub txtCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCosto.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnInsertar.Focus()
      End If
   End Sub

   '--------------------------------------------------------
#End Region

#Region "REQ-33532"
   Private Sub bscCodigoTransportista_BuscadorClick() Handles bscCodigoTransportista.BuscadorClick
      Try
         Dim vIdTrans As Long = 0
         Dim oTransportistas = New Reglas.Transportistas
         Me._publicos.PreparaGrillaTransportistas(bscCodigoTransportista)
         If Not String.IsNullOrEmpty(bscCodigoTransportista.Text) Then
            vIdTrans = Long.Parse(bscCodigoTransportista.Text)
         End If
         Me.bscCodigoTransportista.Datos = oTransportistas.GetFiltradoPorCodigo(vIdTrans, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub bscCodigoTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista2(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoChofer_BuscadorClick() Handles bscCodigoChofer.BuscadorClick
      Try
         Dim rEmpleado = New Reglas.Empleados
         Me._publicos.PreparaGrillaChoferes(bscCodigoChofer)
         Me.bscCodigoChofer.Datos = rEmpleado.GetChoferTransportista(Integer.Parse(bscCodigoTransportista.Text))
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoEmpleado_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoChofer.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosChofer(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoVehiculo_BuscadorClick() Handles bscCodigoVehiculo.BuscadorClick
      Dim codigoVehiculo As String = ""
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaVehiculos2(Me.bscCodigoVehiculo)
         codigoVehiculo = Me.bscCodigoVehiculo.Text.Trim()
         bscCodigoVehiculo.Datos = New Reglas.Vehiculos().GetFiltradoPorPatente(codigoVehiculo, False)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscCodigoVehiculo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoVehiculo.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosVehiculos(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarDatosChofer(dr As DataGridViewRow)
      bscCodigoChofer.Text = dr.Cells("IdEmpleado").Value.ToString()
      bscNombreChofer.Text = dr.Cells("NombreEmpleado").Value.ToString()
   End Sub
   Private Sub CargarDatosTransportista2(dr As DataGridViewRow)
      bscCodigoTransportista.Text = dr.Cells("IdTransportista").Value.ToString()
      bscNombreTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()

      Dim rEmpleado = New Reglas.Empleados().GetChoferTransportista(Integer.Parse(dr.Cells("IdTransportista").Value.ToString()))
      pnlChoferesVehiculo.Visible = rEmpleado.Rows.Count > 0
   End Sub

   Private Sub CargarDatosVehiculos(dr As DataGridViewRow)
      bscCodigoVehiculo.Text = dr.Cells(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString()).Value.ToString().Trim()
      txtMarcaVehiculo.Text = dr.Cells("NombreMarcaVehiculo").Value.ToString().Trim()
      txtModeloVehiculo.Text = dr.Cells("NombreModeloVehiculo").Value.ToString().Trim()
      'bscCodigoCliente.Text = dr.Cells(Entidades.Vehiculo.Columnas.IdCliente.ToString()).Value.ToString().Trim()
      'bscCodigoCliente.PresionarBoton()
   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      bscCodigoTransportista.Enabled = chbTransportista.Checked
      bscNombreTransportista.Enabled = chbTransportista.Checked
      If Not chbTransportista.Checked Then
         bscCodigoTransportista.Text = ""
         bscNombreTransportista.Text = ""
         pnlChoferesVehiculo.Visible = chbTransportista.Checked
         bscCodigoChofer.Text = String.Empty
         bscNombreChofer.Text = String.Empty
         bscCodigoVehiculo.Text = String.Empty
         txtMarcaVehiculo.Text = String.Empty
         txtModeloVehiculo.Text = String.Empty
      End If
      bscCodigoTransportista.Focus()
   End Sub

   '### >>> PR-34956 Señalar y PE-34958 Vialparking
   Private _cotizacionDolar_Prev As Decimal
   Private Sub txtCotizacionDolar_Enter(sender As Object, e As EventArgs) Handles txtCotizacionDolar.Enter
      TryCatched(Sub() _cotizacionDolar_Prev = txtCotizacionDolar.ValorNumericoPorDefecto(0D))
   End Sub
   Private Sub txtCotizacionDolar_Leave(sender As Object, e As EventArgs) Handles txtCotizacionDolar.Leave
      TryCatched(
         Sub()
            If txtCotizacionDolar.ValorNumericoPorDefecto(0D) < 1 Then
               MessageBox.Show("La cotización dólar no puede ser inferior a uno (1)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               txtCotizacionDolar.Focus()
               Exit Sub
            End If
            Dim cotizacionDolar = txtCotizacionDolar.ValorNumericoPorDefecto(0D)
            'SOLO REPROCESO SI CAMBIA EL TIPO DE CAMBIO. SI NO CAMBIÓ NO HAGO NADA
            If cotizacionDolar <> _cotizacionDolar_Prev And cmbMonedaVenta.ValorSeleccionado(Of Integer) = Entidades.Moneda.Dolar Then
               RecalcularCotizacionDolar(_cotizacionDolar_Prev, cotizacionDolar)
            End If
         End Sub)
   End Sub
   Private Sub RecalcularCotizacionDolar(ByRef cotizacionDolar_anterior As Decimal, cotizacionDolar_nueva As Decimal)
      Dim coeficienteCambio = cotizacionDolar_nueva / cotizacionDolar_anterior

      _ventasProductos.ForEach(
         Sub(vp)
            If vp.IdMoneda = Entidades.Moneda.Dolar Then
               vp.PrecioLista *= coeficienteCambio
               vp.Precio *= coeficienteCambio
               vp.PrecioNeto *= coeficienteCambio
               vp.Costo *= coeficienteCambio
               vp.ImporteTotal *= coeficienteCambio
               vp.ImporteImpuesto *= coeficienteCambio
               vp.ImporteImpuestoInterno *= coeficienteCambio
               vp.ImporteTotalNeto *= coeficienteCambio

               vp.CostoParaGrabar *= coeficienteCambio
               vp.PrecioAux *= coeficienteCambio
               vp.PrecioVentaPorTamano *= coeficienteCambio
            End If
         End Sub)


      cotizacionDolar_anterior = cotizacionDolar_nueva
      RecalcularTodo(metodoLlamador:=MetodoLlamador.CambioTipoDeComprobante, oLista:=False)
      _cotizacionDolar_Prev = cotizacionDolar_nueva
   End Sub

   'Private Sub txtCotizacionDolar_TextChanged(sender As Object, e As EventArgs) Handles txtCotizacionDolar.TextChanged
   '   If Me._estaCargando Then Exit Sub

   '   Try

   '      ActualizaPrecios = If(cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).IdListaPrecios.HasValue, True, Reglas.Publicos.ActualizaPreciosDeVenta())

   '      If ActualizaPrecios Then
   '         RecalcularTodo(FacturacionV2.MetodoLlamador.CambioListaDePrecibos, False)
   '      Else
   '         SetearPrecio()
   '      End If

   '      ActualizaPrecios = Reglas.Publicos.ActualizaPreciosDeVenta()
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   Private Sub cmbUbicacionOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionOrigen.SelectedIndexChanged
      If Not _cargaComboDestino Then
         If cmbUbicacionOrigen.SelectedValue IsNot Nothing Then
            ubiOrigen = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
         End If
         Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(sucOrigen, depOrigen, ubiOrigen, bscCodigoProducto2.Text())
         If dt.Count <> 0 Then
            txtStock.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
         End If
      End If
   End Sub

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim dr = cmbDepositoOrigen.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               depOrigen = dr.Field(Of Integer)("IdDeposito")
               _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, depOrigen, sucOrigen)
               cmbUbicacionOrigen.SelectedIndex = 0
               ubiOrigen = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
            End If
         End Sub)
   End Sub

   Private Sub cmbDepositoRT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoRT.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim dr = cmbDepositoRT.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               depOrigenRT = dr.Field(Of Integer)("IdDeposito")
               _publicos.CargaComboUbicaciones(cmbUbicacionRT, depOrigenRT, sucOrigen)
               cmbUbicacionRT.SelectedIndex = 0
               ubiOrigenRT = Integer.Parse(cmbUbicacionRT.SelectedValue.ToString())
            End If
         End Sub)
   End Sub

   Private Sub cmbUbicacionRT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionRT.SelectedIndexChanged
      If Not _cargaComboDestino Then
         ubiOrigenRT = Integer.Parse(cmbUbicacionRT.SelectedValue.ToString())
         Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(sucOrigen, depOrigenRT, ubiOrigenRT, bscCodigoProducto2RT.Text())
         If dt.Count <> 0 Then
            txtStockRT.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
         End If
      End If
   End Sub

   Private Sub txtDireccionClienteGenerico_TextChanged(sender As Object, e As EventArgs) Handles txtDireccionClienteGenerico.TextChanged

   End Sub

   Private Sub bscCodigoLocalidad_Load(sender As Object, e As EventArgs) Handles bscCodigoLocalidad.Load

   End Sub
   '### <<< PR-34956 Señalar y PE-34958 Vialparking

#End Region


#Region "Transferencias Multiples"
   Private Sub bscCuentaBancariaTransfBancMultiple_BuscadorClick() Handles bscCuentaBancariaTransfBancMultiple.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBancMultiple)
         bscCuentaBancariaTransfBancMultiple.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBancMultiple.Text.Trim(), Entidades.Moneda.Peso)
      End Sub)
   End Sub
   Private Sub bscCodigoCuentaBancariaTransfBancMultiples_BuscadorClick() Handles bscCodigoCuentaBancariaTransfBancMultiples.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCuentasBancarias2(bscCodigoCuentaBancariaTransfBancMultiples)
         bscCodigoCuentaBancariaTransfBancMultiples.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(bscCodigoCuentaBancariaTransfBancMultiples.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscCuentaBancariaTransfBancMultiple_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBancMultiple.BuscadorSeleccion, bscCodigoCuentaBancariaTransfBancMultiples.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            bscCodigoCuentaBancariaTransfBancMultiples.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
            bscCuentaBancariaTransfBancMultiple.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            bscCodigoCuentaBancariaTransfBancMultiples.Selecciono = True
            bscCuentaBancariaTransfBancMultiple.Selecciono = True
            txtImporteTransferenciaMultiple.Focus()
         End If
      End Sub)
   End Sub
   Private Sub txtImporteTransferenciaMultiple_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteTransferenciaMultiple.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnAgregarImporteTransfMultiple_Click(sender As Object, e As EventArgs) Handles btnAgregarImporteTransfMultiple.Click
      TryCatched(
      Sub()
         If ValidarInsertarTransfMultiple() Then
            InsertarTransferenciaMultiple()
            CalcularPagos(False)
         End If
      End Sub)
   End Sub
   Private Sub btnQuitarImporteTransfMultiple_Click(sender As Object, e As EventArgs) Handles btnQuitarImporteTransfMultiple.Click
      TryCatched(
      Sub()
         If ugTransferenciasMultiples.ActiveRow IsNot Nothing Then
            QuitarTransferenciaMultiple()
            CalcularPagos(False)
         End If
      End Sub)
   End Sub

   Private Sub InsertarTransferenciaMultiple()
      If _transferencias Is Nothing Then _transferencias = New List(Of Entidades.VentaTransferencia)
      _transferencias.Add(New Entidades.VentaTransferencia With
                          {
                              .IdCuentaBancaria = bscCodigoCuentaBancariaTransfBancMultiples.Text.ValorNumericoPorDefecto(0I),
                              .Orden = _transferencias.Count + 1,
                              .Importe = txtImporteTransferenciaMultiple.ValorNumericoPorDefecto(0D),
                              .NombreCuenta = bscCuentaBancariaTransfBancMultiple.Text
                          })

      If ugTransferenciasMultiples.DataSource Is Nothing Then ugTransferenciasMultiples.DataSource = _transferencias
      txtImporteTransferenciaMultiple.SetValor(0D)
      bscCuentaBancariaTransfBancMultiple.Text = String.Empty
      bscCodigoCuentaBancariaTransfBancMultiples.Text = String.Empty
      ugTransferenciasMultiples.Rows.Refresh(RefreshRow.ReloadData)

      txtImporteTransferenciaMultiple.SelectAll()

      '# Si se cargan multiples transferencias, se debe bloquear el campo individual de importe de transferencia
      txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
      bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()

      '# El importe visualizado en el Textbox de transferencias va a ser el total de las multiples realizadas
      txtTransferenciaBancaria.SetValor(_transferencias.Sum(Function(x) x.Importe))

      bscCuentaBancariaTransfBancMultiple.Focus()
   End Sub
   Private Sub QuitarTransferenciaMultiple()
      Dim dr = ugTransferenciasMultiples.FilaSeleccionada(Of Entidades.VentaTransferencia)
      If dr IsNot Nothing Then
         _transferencias.Remove(dr)
         ugTransferenciasMultiples.Rows.Refresh(RefreshRow.ReloadData)
      End If

      '# Si se cargan multiples transferencias, se debe bloquear el campo individual de importe de transferencia
      txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
      bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()

      '# El importe visualizado en el Textbox de transferencias va a ser el total de las multiples realizadas
      txtTransferenciaBancaria.SetValor(_transferencias.Sum(Function(x) x.Importe))
   End Sub
   Private Function ValidarInsertarTransfMultiple() As Boolean
      If Not bscCodigoCuentaBancariaTransfBancMultiples.Selecciono Then
         ShowMessage("ATENCIÓN: Debe seleccionar una cuenta bancaria.")
         bscCodigoCuentaBancariaTransfBancMultiples.Focus()
         Return False
      End If
      If txtImporteTransferenciaMultiple.ValorNumericoPorDefecto(0D) = 0 Then
         ShowMessage("ATENCIÓN: El importe de la transferencia no puede ser 0.")
         txtImporteTransferenciaMultiple.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub bscCodigoCliente_Load(sender As Object, e As EventArgs) Handles bscCodigoCliente.Load

   End Sub

   Private Sub lblCotizacionDolar_Click(sender As Object, e As EventArgs) Handles lblCotizacionDolar.Click

   End Sub

   Private Sub txtCotizacionDolar_TextChanged(sender As Object, e As EventArgs) Handles txtCotizacionDolar.TextChanged

   End Sub
#End Region

End Class