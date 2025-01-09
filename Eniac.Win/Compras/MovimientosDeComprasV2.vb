Public Class MovimientosDeComprasV2
   Implements IConParametros, IFormConNavegacion

#Region "Campos"

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titProductos As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titRemitoTransporte As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private _utilizaCentroCostos As Boolean = False
   Private _permiteCambiarCentroCostosCompras As Boolean = False
   Private _ActualizaCostoYPrecioVenta As Boolean

   Private informeCalidad As Boolean = False
   Private _InformeNumero As String
   Private _InformeLink As String

   Private _editarProductoDesdeGrilla As Boolean

   Private _estado As Estados
   Private _publicos As Publicos
   Private idCategoriaFiscal As Short
   Private _productos As List(Of Entidades.MovimientoStockProducto)
   Private _productosRT As List(Of Entidades.MovimientoStockProducto)
   Private _proveedor As Entidades.Proveedor
   Private _cargaPrecio As String
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _estaCargando As Boolean = True
   Private _productoLoteTemporal As Entidades.ProductoLote
   Private _productosLotes As List(Of Entidades.ProductoLote)
   Private _productosNrosSeries As List(Of Entidades.ProductoNroSerie)
   Private _editarNrosSeries As List(Of Entidades.ProductoNroSerie)
   Private _vieneDelDobleClick As Boolean = False
   Private _numeroOrden As Integer
   Private _idCaja As Integer = 0
   Private _Sucursal As Integer = 0

   Private _dtProvincias As DataTable
   Private _dtProvinciasRetenciones As DataTable

   'vml 30/09/12 - contabilidad
   Public _tablaAsientos As DataTable

   Private _decimalesAMostrarEnTotalXProducto As Integer
   Private _decimalesAMostrarEnPrecio As Integer
   Private _decimalesRedondeoEnPrecio As Integer   '4
   Private _decimalesEnCantidad As Integer = 2
   Private _decimalesEnKilos As Integer = 3
   Private _decimalesMostrarEnCantidad As Integer = 2
   Private _decimalesEnTotales As Integer = 2
   Private _permiteModificarSubtotal As Boolean = False

   Private _chequesPropios As List(Of Entidades.Cheque)
   Private _chequesTerceros As List(Of Entidades.Cheque)
   Private _comprobantesSeleccionados As List(Of Entidades.Compra)
   Private _cantMaxItemsObserv As Integer
   'Private _comprasProductos As System.Collections.Generic.List(Of Entidades.CompraProducto)
   Private _PO As Decimal
   Private _IVAO As Decimal
   Private _precioVenta As Decimal
   Private _comprasObservaciones As List(Of Entidades.CompraObservacion)
   Private _cantMaxItems As Integer
   Private _imprime As Boolean
   Private _alicuota As Decimal
   Private _buscaproductoproveedor As Boolean = False
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Reglas.Publicos.ComprasIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True
   Private _ConfiguracionImpresoras As Boolean

   Private _comprasImpuestosDespachoImportacion As List(Of Entidades.CompraImpuesto)
   Private _comprasImpuestos As IList(Of Entidades.CompraImpuesto)

   Private _ModificaDetalle As String
   Private _ModificaDetalleRT As String
   Private DescRecPorc1RT As Decimal = 0
   Private DescRecPorc2RT As Decimal = 0

   Private TotalProductoRT As Decimal = 0
   Private DescRecRT As Decimal = 0

   Private _transportistaA As Entidades.Transportista
   Private _CodigoProductoProveedor As String
   Private _InvocaPedido As Boolean = False

   Private _listaPreciosPredeterminada As Integer

   Private _tipoImpuestoIVA As Entidades.TipoImpuesto.Tipos = Entidades.TipoImpuesto.Tipos.IVA
   Private _eTipoImpuestoIVA As Entidades.TipoImpuesto

   Private _titIVAs As Dictionary(Of String, String)

   Private _comprasPosicionarNombreProducto As Boolean
   Private _idCuentaBancariaSeleccionada As Integer = 0

   '-- REQ-34986.- --------------------------------------------------------------------
   Public Property MovAtributo01 As Entidades.AtributoProducto
   Public Property MovAtributo02 As Entidades.AtributoProducto
   Public Property MovAtributo03 As Entidades.AtributoProducto
   Public Property MovAtributo04 As Entidades.AtributoProducto

   '-- REQ-35487.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
   '-- REG-35666.- ------------------------
   Private _cargaComboDestino As Boolean = False
   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""
   Public Property _sucStock As Integer
   Public Property _depStock As Integer
   Public Property _ubiStock As Integer
   '---------------------------------------
   Private flackCargaProductos As Boolean = True
   '-----------------------------------------------------------------------------------
   Private _tipoComprobantes As String

   Private _transferencias As List(Of Entidades.CompraTransferencia)
#End Region

#Region "Propiedades"
   Public Property tablaAsientos() As DataTable
      Get
         Return _tablaAsientos
      End Get
      Set(value As DataTable)
         _tablaAsientos = value
      End Set
   End Property
#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

#End Region

#Region "Overrides"

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoComprobantes = parametros
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         _listaPreciosPredeterminada = Reglas.Publicos.ListaPreciosPredeterminada

         _eTipoImpuestoIVA = New Reglas.TiposImpuestos().GetUno(_tipoImpuestoIVA)

         _decimalesEnTotales = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral

         txtPercepcionTotal.Formato = String.Format("N{0}", _decimalesEnTotales)

         _decimalesRedondeoEnPrecio = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnPrecio
         _decimalesAMostrarEnPrecio = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnPrecio
         _decimalesAMostrarEnTotalXProducto = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalXProducto

         '-- REQ-34420.- -----------------------------------------------------------------------
         txtPrecioDolares.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         '-- REQ-44315.- -----------------------------------------------------------------------
         txtCantidadUMCompra.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
         txtPrecioPorUMCompra.Formato = "##,##0." + New String("0"c, Me._decimalesMostrarEnCantidad)
         '--------------------------------------------------------------------------------------


         _comprasPosicionarNombreProducto = Reglas.Publicos.Compras.ComprasPosicionarNombreProducto
         _ActualizaCostoYPrecioVenta = Reglas.Publicos.ActualizaCostoYPrecioVenta

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            Me._decimalesEnCantidad = 0
            _decimalesMostrarEnCantidad = 0
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         Else
            _decimalesEnCantidad = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad
            _decimalesMostrarEnCantidad = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad
         End If

         tbcDetalle.SelectedTab = tbpTotales
         _titIVAs = GetColumnasVisiblesGrilla(ugIVAs)
         ugIVAs.AgregarTotalesSuma({Entidades.CompraImpuesto.Columnas.BaseImponible.ToString(),
                                    Entidades.CompraImpuesto.Columnas.Importe.ToString(),
                                    "ImporteTotal"})

         Me._chequesPropios = New List(Of Entidades.Cheque)()
         Me._chequesTerceros = New List(Of Entidades.Cheque)()

         Me._productos = New System.Collections.Generic.List(Of Entidades.MovimientoStockProducto)
         _comprasImpuestos = New System.ComponentModel.BindingList(Of Entidades.CompraImpuesto)()
         ugIVAs.DataSource = _comprasImpuestos
         AjustarColumnasGrilla(ugIVAs, _titIVAs)

         Me._productosRT = New System.Collections.Generic.List(Of Entidades.MovimientoStockProducto)
         Me._productosLotes = New List(Of Entidades.ProductoLote)()
         Me._productosNrosSeries = New List(Of Entidades.ProductoNroSerie)()
         Me._comprasObservaciones = New List(Of Entidades.CompraObservacion)()

         Me._publicos = New Publicos()
         Me._publicos.CargaComboBancos(Me.cmbBancoPropio)
         Dim blnMiraPC As Boolean = True, blnUsaFacturacion As Boolean = True
         If String.IsNullOrEmpty(_tipoComprobantes) Then
            Me._publicos.CargaComboTiposComprobantes(Me.cboTipoComprobante, blnMiraPC, "COMPRAS", , , , blnUsaFacturacion)
         Else
            Me._publicos.CargaComboTiposComprobantes(Me.cboTipoComprobante, blnMiraPC, "COMPRAS", , , , blnUsaFacturacion,,,,,,,,,, _tipoComprobantes)
         End If

         If Me.cboTipoComprobante.Items.Count = 0 Then
            Me._ConfiguracionImpresoras = True
         End If

         Me._publicos.CargaComboPeriodosFiscales(Me.cboPeriodoFiscal, actual.Sucursal.IdEmpresa, "ABIERTO")

         _sucStock = actual.Sucursal.IdSucursal
         '_cargaComboDestino = True
         _publicos.CargaComboDepositos(cmbDepositoOrigen, _sucStock, miraUsuario:=True, permiteEscritura:=True, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDepositos(cmbDepositoOrigenRT, _sucStock, miraUsuario:=True, permiteEscritura:=True, Entidades.Publicos.SiNoTodos.TODOS)
         '_cargaComboDestino = False

         If cmbDepositoOrigen.Items.Count > 0 Then
            cmbDepositoOrigen.SelectedIndex = 0
            cmbDepositoOrigenRT.SelectedIndex = 0
            _cargoBienLaPantalla = True
         Else
            _mensajeDeErrorEnCarga = String.Format("El usuario no posee depositos autorizados para la sucursal ({0})", actual.Sucursal.Nombre)
            _cargoBienLaPantalla = False
            Exit Sub
         End If

         If Me.cboPeriodoFiscal.Items.Count = 0 Then
            MessageBox.Show("NO Existen Periodos Fiscales Habilitados, no podra grabar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.tsbNuevo.Visible = False
            Me.tsbGrabar.Visible = False
            Exit Sub 'No logro hacer que salga, pero tampoco podra grabar nada.
         End If

         Me._publicos.CargaComboFormasDePago(Me.cboFormaPago, "COMPRAS")
         Me._publicos.CargaComboRubrosCompras(Me.cboRubro)
         Me._publicos.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR)

         '# Tipos de Cheque
         Me._publicos.CargaComboTiposCheques(Me.cmbTipoCheque)

         ' Dejar el combo de comprador vacio para que sea obligatorio para el usuario seleccionarlo
         If Reglas.Publicos.ComprasSolicitaComprador Then
            Me.cmbComprador.SelectedIndex = -1
         End If

         _publicos.CargaComboCentroCostos(cmbCentroCosto)

         Me._Sucursal = actual.Sucursal.Id

         Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

         _publicos.CargaComboAFIPConceptoCM05(cmbAFIPConceptoCM05, Entidades.AFIPConceptoCM05.TiposConceptosCM05.GASTOS)

         'carga las cajas.

         Me._publicos.CargaComboCajas(Me.cmbCajas, Me._Sucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         _publicos.CargaComboLetraComprobanteCompra(cboLetra)

         Me._publicos.CargaComboImpuestos(Me.cmbPorcentajeIVA)

         Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)

         Dim oCategFiscal As New Reglas.CategoriasFiscales()

         Me._categoriaFiscalEmpresa = oCategFiscal.GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         Me.grpPrecioCompra.Visible = Reglas.Publicos.UtilizaPrecioDeCompra

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            Me.txtCantidad.Formato = "##,##0"
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         End If

         If Reglas.Publicos.VisualizaLote Then
            dgvProductos.Columns("ColIdLote").Visible = True
            dgvProductos.Columns("VtoLote").Visible = True

            'dgvRemitoTransp.Columns("ColIdLote").Visible = True
            'dgvRemitoTransp.Columns("VtoLote").Visible = True

            'dgvProductos.Columns("VtoLote").DefaultCellStyle.Format = "dd/MM/yyyy"
         End If

         If Reglas.Publicos.VisualizaNrosSerie Then
            dgvProductos.Columns("NrosSerie").Visible = True
            dgvRemitoTransp.Columns("NrosSerie2").Visible = True

         End If
         If Reglas.Publicos.VisualizaLote Then
            dgvProductos.Columns("NrosLotes").Visible = True
            dgvRemitoTransp.Columns("NrosLote2").Visible = True
         End If

         pnlConceptos.Visible = Reglas.Publicos.TieneModuloExpensas
         dgvProductos.Columns("NombreConcepto").Visible = pnlConceptos.Visible
         'If Publicos.TieneModuloExpensas Then
         '   Me.dgvProductos.Columns("Stock").Visible = False
         '   Me.dgvProductos.Columns("NombreConcepto").Visible = True
         '   Me.lblConcepto.Visible = True
         '   Me.cmbConceptos.Visible = True
         '   pnlConceptos.Visible = True
         'End If


         Me.dgvProductos.Columns("CodigoProductoProveedor1").Visible = Reglas.Publicos.Compras.ComprasVisualizaCodigoProveedor

         Me.dgvProductos.Columns("PorcVar").Visible = Reglas.Publicos.Compras.ComprasVisualizaPorcVarCosto

         'Me._comprasProductos = New List(Of Entidades.CompraProducto)

         Me._estaCargando = False

         Me.tsbInvocarPedidos.Visible = Reglas.Publicos.TieneModuloPedidosProv

         SeteaFormatosACampos()

         tbcDetalle.SelectedTab = tbpDespachoImportacion
         tbcDetalle.SelectedTab = tbpProductos

         _tit = GetColumnasVisiblesGrilla(ugImpuestosDespacho)
         _titRemitoTransporte = GetColumnasVisiblesGrilla(dgvRemitoTransp)

         ''tbcDetalle.TabPages.Remove(tbpDespachoImportacion)

         '-- REQ-34986.- ------------------------------------------------------
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
         '---------------------------------------------------------------------
         ' Columnas visible en la grilla de productos
         _titProductos = GetColumnasVisiblesGrilla(Me.dgvProductos)
         Me.Nuevo()

         _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos
         _permiteCambiarCentroCostosCompras = _utilizaCentroCostos AndAlso Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosCompras

         cmbCentroCosto.Visible = _utilizaCentroCostos
         cmbCentroCosto.LabelAsoc.Visible = _utilizaCentroCostos
         pnlCentroCosto.Visible = _utilizaCentroCostos
         NombreCentroCosto.Visible = _utilizaCentroCostos

         ''Hasta corregir el problema con los cheques!
         'Me.tbcCompPagos.Visible = False
         'Me.tbcDetalle.TabPages.Remove(Me.tbpPagosChTerceros) 
         'Me.tbpPagosEfectivo.Text = "Pagos Efectivo"
         '--------------------------------------------------------------

         'Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      bscCodigoProveedor2.Focus()
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         If Not (ugIVAs.Focused And chbAjusteManualIVA.Checked) Then
            tsbNuevo.PerformClick()
         End If

      ElseIf keyData = Keys.F4 Then
         tsbGrabar.PerformClick()

      ElseIf keyData = Keys.F9 Then
         If tbcDetalle.TabPages.Contains(tbpProductos) Then
            tbcDetalle.SelectedTab = tbpProductos
            ProductoFocus()
         ElseIf tbcDetalle.TabPages.Contains(tbpRemitoTransp) Then
            tbcDetalle.SelectedTab = tbpRemitoTransp
            Navegar(bscCodigoProducto2RT)
         End If

      ElseIf keyData = Keys.F11 Then
         tbcDetalle.SelectedTab = tbpPagosEfectivo
         txtEfectivo.Focus()

      ElseIf keyData = Keys.F12 Then
         tbcDetalle.SelectedTab = tbpPagosChTerceros
         btnInsertarChequeTercero.Focus()

      ElseIf keyData = Keys.Escape Then
         If Not tbcDetalle.TabPages.Contains(tbpRemitoTransp) Then
            btnLimpiarProducto.PerformClick()
         Else
            btnLimpiarProductoRT.PerformClick()
         End If
      Else

         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub MovimientosDeCompras_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      TryCatched(
      Sub()
         If Not _cargoBienLaPantalla Then
            ShowMessage(_mensajeDeErrorEnCarga)
            Close()
         End If
         If _ConfiguracionImpresoras Then
            ShowMessage("No Existe la PC en Configuraciones/Impresoras")
            FormEnabled(value:=False, {grbProveedor, grbCajas, tbcDetalle}, tspMenu, {tsbSalir})
            'Close()
         End If
      End Sub)
   End Sub

   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      TryCatched(
      Sub()
         If ShowPregunta("ATENCION: ¿Desea Realizar un Comprobante Nuevo?") = Windows.Forms.DialogResult.Yes Then
            Nuevo()
         End If
      End Sub)
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub() GrabarComprobante())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#Region "Eventos Buscador Proveedor"
   Private Sub bscCodigoProveedor2_BuscadorClick() Handles bscCodigoProveedor2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor2)
         Dim codigoProveedor = bscCodigoProveedor2.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor2.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedor2_BuscadorClick() Handles bscProveedor2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscProveedor2)
         bscProveedor2.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor2.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProveedor(e.FilaDevuelta)
            If txtNombreProveedorGenerico.Text <> "" Then
               txtEmisorFactura.Focus()
            Else
               txtNombreProveedorGenerico.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscProveedor2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProveedor(e.FilaDevuelta)
            If txtEmisorFactura.ValorNumericoPorDefecto(0S) > 0 Then
               If txtNombreProveedorGenerico.Text <> "" Then
                  ProductoFocus()
               Else
                  txtNombreProveedorGenerico.Focus()
               End If
            Else
               txtEmisorFactura.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub llbProveedor_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbProveedor.LinkClicked
      AbrirPantallaProveedor()
   End Sub
   Private Sub AbrirPantallaProveedor()
      Try
         Dim PantProveedor As ProveedoresDetalle

         If Me.bscCodigoProveedor2.Selecciono Or Me.bscProveedor2.Selecciono Then
            Dim Prov As Eniac.Entidades.Proveedor = New Eniac.Entidades.Proveedor
            Dim blnIncluirFoto As Boolean = True
            Prov = New Eniac.Reglas.Proveedores().GetUno(Long.Parse(Me.bscCodigoProveedor2.Tag.ToString()), blnIncluirFoto)
            Prov.Usuario = actual.Nombre
            PantProveedor = New ProveedoresDetalle(Prov)
            PantProveedor.CierraAutomaticamente = True
            PantProveedor.StateForm = Eniac.Win.StateForm.Actualizar
         Else
            PantProveedor = New ProveedoresDetalle(New Entidades.Proveedor())
            PantProveedor.CierraAutomaticamente = True
            PantProveedor.StateForm = Eniac.Win.StateForm.Insertar
         End If

         If PantProveedor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoProveedor2.Text = PantProveedor.txtCodigoProveedor.Text
            Dim tmp As Boolean = bscCodigoProveedor2.Permitido
            bscCodigoProveedor2.Permitido = True
            Me.bscCodigoProveedor2.PresionarBoton()
            bscCodigoProveedor2.Permitido = tmp
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
#End Region




   Private Sub cboTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoComprobante.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try

         If Me.cboTipoComprobante.SelectedValue IsNot Nothing Then

            chbNumeroAutomatico.Checked = False
            cboLetra.Enabled = True
            txtEmisorFactura.Enabled = True
            txtNumeroFactura.Enabled = True
            chbNumeroAutomatico.Visible = False
            lblNumeroAutomatico.Visible = False
            lblNumeroFactura.Text = "Número"

            'Si es X/R es remito, siempre debe tener esa letra, sino dejo la que esta.
            'If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Then
            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Trim().Length = 1 Then
               Me.cboLetra.Text = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me._proveedor IsNot Nothing Then
                  If Me._proveedor.EsProveedorGenerico Then
                     Me.cboLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscalCompra
                  Else
                     Me.cboLetra.Text = Me._proveedor.CategoriaFiscal.LetraFiscalCompra
                  End If

               Else
                  Me.cboLetra.SelectedIndex = -1
               End If
            End If


            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).NumeracionAutomatica Then
               Me.CargarProximoNumeroProveedor()
            ElseIf DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 And
               Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).AfectaCaja And
               Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).ActualizaCtaCte Then
               Me.CargarProximoNumero()
            Else
               Me.txtEmisorFactura.Text = ""
               Me.txtNumeroFactura.Text = ""
            End If

            Me.cboPeriodoFiscal.Enabled = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro

         Else

            Me.cboLetra.SelectedIndex = -1
            Me.txtEmisorFactura.Text = ""
            Me.txtNumeroFactura.Text = ""

         End If

         'Si algun producto es con Lote tengo que limpiar el detalle, porque pudo cambiar de Factura a NCRED o viseversa, y lleva controles
         ' o que afecta stock si a no.
         If Me._productosLotes.Count > 0 Then
            Me.LimpiarDetalle()
         End If

         If cboTipoComprobante.SelectedItem IsNot Nothing AndAlso DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsDespachoImportacion Then
            If Not tbcDetalle.TabPages.Contains(tbpDespachoImportacion) Then
               tbcDetalle.TabPages.Add(tbpDespachoImportacion)
            End If
         Else
            If tbcDetalle.TabPages.Contains(tbpDespachoImportacion) Then
               tbcDetalle.TabPages.Remove(tbpDespachoImportacion)
            End If
         End If
         'If tbcDetalle.TabPages.Contains(tbpDespachoImportacion) Then
         '   tbcDetalle.TabPages.Remove(tbpDespachoImportacion)
         'End If


         If cboTipoComprobante.SelectedItem IsNot Nothing AndAlso DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
            If Me.tbcDetalle.TabPages.Contains(Me.tbpProductos) Then
               Me.tbcDetalle.TabPages.Remove(Me.tbpProductos)
            End If
            If Not Me.tbcDetalle.TabPages.Contains(Me.tbpRemitoTransp) Then
               Me.tbcDetalle.TabPages.Insert(0, Me.tbpRemitoTransp)
            End If
            Me.tbcDetalle.SelectedTab = Me.tbpRemitoTransp
            AjustarColumnasGrilla(dgvRemitoTransp, _titRemitoTransporte)
            DisplayIndexProductoRT()
         Else
            If Not Me.tbcDetalle.TabPages.Contains(Me.tbpProductos) Then
               Me.tbcDetalle.TabPages.Insert(0, Me.tbpProductos)
            End If
            If Me.tbcDetalle.TabPages.Contains(Me.tbpRemitoTransp) Then
               Me.tbcDetalle.TabPages.Remove(Me.tbpRemitoTransp)
            End If
            Me.tbcDetalle.SelectedTab = Me.tbpProductos
         End If

         If cboTipoComprobante.SelectedItem IsNot Nothing AndAlso
            DirectCast(cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).ClaseComprobante = Entidades.TipoComprobante.ClasesComprobante.LIQUIDATARJETA Then
            If Not tbcDetalle.TabPages.Contains(tbpCuponesTarjetas) Then
               Dim idx = tbcDetalle.TabPages.IndexOf(tbpProductos)   'Ubico donde está la solapa Productos para agregarlo despues de ella
               tbcDetalle.TabPages.Insert(idx + 1, tbpCuponesTarjetas)
            End If
            grbRetenciones.Enabled = True
         Else
            If tbcDetalle.TabPages.Contains(tbpCuponesTarjetas) Then
               tbcDetalle.TabPages.Remove(tbpCuponesTarjetas)
            End If
            grbRetenciones.Enabled = False
         End If

         '-.PE-31849.-
         If Me.cboTipoComprobante.SelectedValue IsNot Nothing Then
            Dim TipComp = New Reglas.TiposComprobantes().GetUno(Me.cboTipoComprobante.SelectedValue.ToString())
            Me.chbMercaderiaEnviada.Checked = CBool(TipComp.ActivaTildeMercDespacha)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cmbLetra_LostFocus(sender As Object, e As EventArgs) Handles cboLetra.LostFocus

      If Me.cboLetra.SelectedIndex >= 0 And Not Me.cboTipoComprobante.SelectedValue Is Nothing Then

         'Valida si el comprobante esta permitido para la letra fiscal
         Dim tip As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         If Not tip.LetraHabilitada(Me.cboTipoComprobante.SelectedValue.ToString(), Me.cboLetra.Text) Then
            MessageBox.Show("La Letra '" & Me.cboLetra.Text & "' NO esta habilitada para este Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboLetra.SelectedIndex = -1
            Exit Sub
         End If

         'If Not Me._proveedor Is Nothing And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas <> "X" Then
         If Not Me._proveedor Is Nothing And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Trim.Length > 1 Then
            If Me._proveedor.CategoriaFiscal.LetraFiscalCompra <> Me.cboLetra.Text Then
               If Me._proveedor.CategoriaFiscal.LetraFiscalCompra = "A" And Me.cboLetra.Text = "B" Then
                  If MessageBox.Show("Esta seguro de utilizar la Letra '" & Me.cboLetra.Text & "' ? NO coincide con la del Proveedor '" & Me._proveedor.CategoriaFiscal.LetraFiscalCompra & "'", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel Then
                     Me.cboLetra.SelectedIndex = -1
                     Exit Sub
                  End If
               Else
                  MessageBox.Show("La Letra '" & Me.cboLetra.Text & "' NO coincide con la del Proveedor '" & Me._proveedor.CategoriaFiscal.LetraFiscalCompra & "'", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.cboLetra.SelectedIndex = -1
                  Exit Sub
               End If
            End If
         End If

         'Diego.. COMO CANCELO el LOSTFOCUS!!??
      End If

   End Sub

   'Private Sub txtNumeroFactura_LostFocus(sender As Object, e As EventArgs) Handles txtNumeroFactura.LostFocus

   '   Dim oCompras As New Reglas.Compras
   '   If oCompras.Existe(0, _
   '                      Me.cmbTipoDocProveedor.SelectedValue.ToString(), Long.Parse("0" & Me.bscCodigoProveedor.Text), _
   '                      Me.cboTipoComprobante.SelectedValue.ToString, _
   '                      Me.cboLetra.Text, _
   '                      Short.Parse("0" & Me.txtEmisorFactura.Text), _
   '                      Long.Parse("0" & Me.txtNumeroFactura.Text)) Then

   '      MessageBox.Show("Este comprobante ya fue INGRESADO con ANTERIORIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   '      Me.txtNumeroFactura.Focus()
   '      Exit Sub
   '   End If

   'End Sub

   Private Sub txtNumeroFactura_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumeroFactura.Validating
      Try
         If bscCodigoProveedor2.Tag Is Nothing Then
            ShowMessage("ATENCION: Debe cargar el Proveedor")
            bscCodigoProveedor2.Focus()
         Else
            If Existe() Then
               MessageBox.Show("Este comprobante ya fue INGRESADO con ANTERIORIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               'segun la situacion entra en un bucle de mensaje y error, no pudiendo cortarlo.
               'e.Cancel = True
               Exit Sub
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub dtpFecha_LostFocus(sender As Object, e As EventArgs) Handles dtpFecha.LostFocus

      If Me.cboPeriodoFiscal.Enabled Then
         'Si la fecha del comprobante coincide con un periodo abierto le pongo esa fecha, sino, pongo la ultima
         If Me.cboPeriodoFiscal.FindStringExact(Me.dtpFecha.Value.ToString("yyyy/MM")) >= 0 Then
            Me.cboPeriodoFiscal.SelectedIndex = Me.cboPeriodoFiscal.FindStringExact(Me.dtpFecha.Value.ToString("yyyy/MM"))
         Else
            Me.cboPeriodoFiscal.SelectedIndex = 0
         End If
      End If

   End Sub

   Private Sub chbSinProductos_CheckedChanged(sender As Object, e As EventArgs) Handles chbSinProductos.CheckedChanged
      'TODO:
      '' '' '' ''Me.tbcDetalle.Enabled = Not Me.chbSinProductos.Checked
      '' '' '' ''Me.dgvProductos.Enabled = Not Me.chbSinProductos.Checked
      '' '' '' ''tsbInvocarComprobantes.Enabled = Not Me.chbSinProductos.Checked
      '' '' '' ''tsbInvocarPedidos.Enabled = Not Me.chbSinProductos.Checked

      '' '' '' ''If Me.chbSinProductos.Checked Then
      '' '' '' ''   Me.LimpiarCamposProductos()

      '' '' '' ''   Me._productos.Clear()
      '' '' '' ''   Me.dgvProductos.DataSource = Me._productos.ToArray()
      '' '' '' ''   Me._productosLotes.Clear()
      '' '' '' ''   Me._productosNrosSeries.Clear()

      '' '' '' ''   Me.txtBrutoNoGravado.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      '' '' '' ''   Me.txtBruto105.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      '' '' '' ''   Me.txtBruto210.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      '' '' '' ''   Me.txtBruto270.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      '' '' '' ''End If

      '' '' '' ''Me.txtBrutoNoGravado.ReadOnly = Not Me.chbSinProductos.Checked
      '' '' '' ''Me.txtBruto105.ReadOnly = Not Me.chbSinProductos.Checked
      '' '' '' ''Me.txtBruto210.ReadOnly = Not Me.chbSinProductos.Checked
      '' '' '' ''Me.txtBruto270.ReadOnly = Not Me.chbSinProductos.Checked

      '' '' '' ''If Not Me.chbSinProductos.Checked Then
      '' '' '' ''   Me.bscCodigoProducto2.Focus()
      '' '' '' ''Else
      '' '' '' ''   Me.txtBrutoNoGravado.Focus()
      '' '' '' ''End If

   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      Me.LimpiarCamposProductos()
      ProductoFocus()
      Me._vieneDelDobleClick = False
   End Sub

   Private Sub lnkProducto_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkProducto.LinkClicked
      Try
         '-- REG-41768.- -------------------------------------------------------------------------------------------------------
         Dim prod = New Entidades.Producto()
         If Not String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then
            prod = New Reglas.Productos().GetUno(bscCodigoProducto2.Text, True, True, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
         End If
         Using pr = New ProductosDetalle(prod)
            pr.StateForm = If(String.IsNullOrWhiteSpace(prod.IdProducto), StateForm.Insertar, StateForm.Actualizar)
            pr.CierraAutomaticamente = True
            If pr.ShowDialog() = Windows.Forms.DialogResult.OK Then
               bscCodigoProducto2.Text = pr.IdProducto
               bscCodigoProducto2.PresionarBoton()
            End If
         End Using
         '----------------------------------------------------------------------------------------------------------------------
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick

      Try
         If Me.bscCodigoProveedor2.Enabled And Me._proveedor Is Nothing Then
            ShowMessage("ATENCION: Debe cargar el Proveedor antes de cargar el producto")
            Me.bscCodigoProducto2.Text = ""
            Me.bscCodigoProveedor2.Focus()
            bscCodigoProveedor2.Datos = Nothing
            Exit Sub
         End If
         If Existe() Then
            ShowMessage("Este comprobante ya fue INGRESADO con ANTERIORIDAD")
            Me.txtNumeroFactura.Focus()
            Exit Sub
         End If

         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Dim oProdProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores()

         If Me.chbProductosDelProveedor.Checked Then
            Me._publicos.PreparaGrillaProductosProveedor2(Me.bscCodigoProducto2)
            Me.bscCodigoProducto2.Datos = oProdProv.GetPorCodigoProdProv(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, _listaPreciosPredeterminada, "COMPRAS", _proveedor.IdProveedor, soloCompuestos:=False, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
         Else
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
            Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, _listaPreciosPredeterminada, "COMPRAS", soloBuscaPorIdProducto:=_editarProductoDesdeGrilla, idProveedor:=_proveedor.IdProveedor)
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         '# Vuelvo a poner la propiedad en False luego de que se haya ejecutado la búsqueda
         _editarProductoDesdeGrilla = False
      End Try
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick

      Try

         If Me.bscCodigoProveedor2.Enabled And Me._proveedor Is Nothing Then
            MessageBox.Show("ATENCION: Debe cargar el Proveedor antes de cargar el producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.bscProducto2.Text = ""
            Me.bscCodigoProveedor2.Focus()
            Exit Sub
         End If

         If Existe() Then
            MessageBox.Show("Este comprobante ya fue INGRESADO con ANTERIORIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroFactura.Focus()
            Exit Sub
         End If

         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, _listaPreciosPredeterminada, "COMPRAS", idProveedor:=_proveedor.IdProveedor)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPorcDescRecargo_LostFocus(sender As Object, e As EventArgs) Handles txtDescuentoRecargoPorc.LostFocus
      Try
         If Me.txtDescuentoRecargoPorc.Text = "" Or Me.txtDescuentoRecargoPorc.Text = "-" Then
            Me.txtDescuentoRecargoPorc.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.CalcularDescRecargoProductosXPorc()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecargo_LostFocus(sender As Object, e As EventArgs) Handles txtDescuentoRecargo.LostFocus
      Try
         If Me.txtDescuentoRecargo.Text = "" Or Me.txtDescuentoRecargo.Text = "-" Then
            Me.txtDescuentoRecargo.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.CalcularDescRecargoProductosXMonto()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPorcDescRecargoGral_GotFocus(sender As Object, e As EventArgs) Handles txtPorcDescRecargoGral.GotFocus
      Me.txtPorcDescRecargoGral.SelectAll()
   End Sub

   Private Sub txtPorcDescRecargoGral_LostFocus(sender As Object, e As EventArgs) Handles txtPorcDescRecargoGral.LostFocus
      Try
         Me.CalcularDescuentoRecargo()
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If (Not Me.bscProducto2.FilaDevuelta Is Nothing Or Not Me.bscCodigoProducto2.FilaDevuelta Is Nothing) And Me.txtCantidad.Text <> "" Then
            If Me.ValidarInsertaProducto() Then
               Me.InsertarProducto()
               ProductoFocus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvProductos.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaProducto()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCantidad_LostFocus(sender As Object, e As EventArgs) Handles txtCantidad.LostFocus
      Try
         If Me.txtCantidad.Text.Trim().Length = 0 Then

         Else
            If Me.txtPrecio.Text = "-" Then
               Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
            End If
         End If
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
      Try
         If Me.txtPrecio.Text.Trim().Length = 0 Then
            Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.CalcularTotalProducto()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBruto_LostFocus(sender As Object, e As EventArgs)
      If Me.txtTotalBruto.Text.Trim().Length = 0 Then
         Me.txtTotalBruto.Text = "0"
      End If
   End Sub

   Private Sub dgvProductos_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick
      Try
         If Me.dgvProductos.Rows.Count = 0 Then Exit Sub

         If Me.dgvProductos.SelectedRows.Count = 0 Then Exit Sub

         If Me.dgvProductos.Columns(e.ColumnIndex).Name = "NrosSerie" Then
            If e.RowIndex <> -1 Then
               If DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NroSerie Then

                  Dim cantidadDeProductos As Integer = DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NrosSeries.Count

                  Dim Ver As Boolean = True

                  If DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NrosSeries.Count <
                                                               DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto).Cantidad Then
                     cantidadDeProductos = CInt(DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto).Cantidad)



                     Me.CargarNumeroDeSerieProductosCompras(DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto), Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()),
                                                      Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString()))

                  Else
                     Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos,
                                                                                         DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                                                         Entidades.MovimientoStockProducto).ProductoSucursal.Producto,
                                                                                         _productosNrosSeries,
                                                                                         Ver,
                                                                                         Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()),
                                                                                         Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString()))
                     ins.ShowDialog()

                  End If


               Else
                  ShowMessage("Este producto no utiliza Nro. Serie.")
                  Exit Sub
               End If
            End If
         End If

         '# Ver Lotes
         If Me.dgvProductos.Columns(e.ColumnIndex).Name = "NrosLotes" Then
            If Not DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.Lote Then
               ShowMessage("Este producto no utiliza Lote.")
               Exit Sub
            Else
               Dim eMCP = DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto)
               Me.SeleccionDeLotes(eMCP, loteSeleccionado:=eMCP.IdLote)
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub dgvProductos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
      Try
         'limpia los textbox, y demas controles
         Me.LimpiarCamposProductos()
         'carga el producto seleccionado de la grilla en los textbox
         '# Seteo la propiedad en True para indicar que voy a editar un producto que se encuentra en la grilla y debe buscar por Código Exacto.
         _editarProductoDesdeGrilla = True
         flackCargaProductos = False
         Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex), editarProductoDesdeGrilla:=_editarProductoDesdeGrilla)
         flackCargaProductos = True
         'elimina el producto de la grilla
         Me.EliminarLineaProducto()
         'hace foco en la cantidad

         If pnlCantidadUMCompra.Enabled And pnlCantidadUMCompra.Visible Then
            Navegar(txtCantidadUMCompra)
         Else
            txtCantidad.Focus()
            txtCantidad.SelectAll()
         End If

         Me._vieneDelDobleClick = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBrutoNoGravado_Leave(sender As Object, e As EventArgs)
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBruto105_Leave(sender As Object, e As EventArgs)
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBruto210_Leave(sender As Object, e As EventArgs)
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBruto270_Leave(sender As Object, e As EventArgs)
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionIVA_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIVA.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub txtRetencionIVA_Leave(sender As Object, e As EventArgs) Handles txtRetencionIVA.Leave, txtRetencionGanancias.Leave
      TryCatched(Sub() CalcularTotales())
   End Sub

   Private Sub txtPercepcionIB_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIIBB.Leave
      Try
         Me.CalcularTotales()
         If Not txtPercepcionIIBB.ReadOnly Then ''''AndAlso IsNumeric(txtPercepcionIIBB.Text) AndAlso Decimal.Parse(txtPercepcionIIBB.Text) <> 0 Then
            Dim drCol As DataRow() = _dtProvincias.Select("Importe <> 0")
            Dim dr As DataRow = Nothing
            If drCol.Length = 1 Then
               dr = drCol(0)
            ElseIf drCol.Length = 0 Then
               Dim localidad As Entidades.Localidad = New Reglas.Localidades().GetUna(_proveedor.IdLocalidadProveedor)
               drCol = _dtProvincias.Select(String.Format("IdProvincia = '{0}'", localidad.IdProvincia))
               If drCol.Length = 1 Then
                  dr = drCol(0)
               End If
            End If
            If dr IsNot Nothing Then
               dr("Importe") = txtPercepcionIIBB.ValorNumericoPorDefecto(0D)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub txtRetencionIIBB_Leave(sender As Object, e As EventArgs) Handles txtRetencionIIBB.Leave
      TryCatched(
      Sub()
         CalcularTotales()
         If Not txtRetencionIIBB.ReadOnly Then
            Dim drCol = _dtProvinciasRetenciones.Where(Function(dr1) dr1.Field(Of Decimal)("Importe") <> 0).ToArray()
            Dim dr As DataRow = Nothing
            If drCol.Length = 1 Then
               dr = drCol(0)
            ElseIf drCol.Length = 0 Then
               Dim localidad = New Reglas.Localidades().GetUna(_proveedor.IdLocalidadProveedor)
               drCol = _dtProvinciasRetenciones.Select(String.Format("IdProvincia = '{0}'", localidad.IdProvincia))
               If drCol.Length = 1 Then
                  dr = drCol(0)
               End If
            End If
            If dr IsNot Nothing Then
               dr("Importe") = txtRetencionIIBB.ValorNumericoPorDefecto(0D)
            End If
         End If
      End Sub)
   End Sub

   Private Sub txtPercepcionGanancias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionGanancias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionVarias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionVarias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtEfectivo_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnChequePropioInsertar_Click(sender As Object, e As EventArgs) Handles btnChequePropioInsertar.Click
      Try
         If Me.ValidarInsertarChequePropio() Then
            Me.InsertarChequePropioGrilla()
            Me.bscCuentaBancariaPropio.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnChequePropioEliminar_Click(sender As Object, e As EventArgs) Handles btnChequePropioEliminar.Click
      Try
         If Me.dgvChequesPropios.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaChequePropio()
               Me.bscCuentaBancariaPropio.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvChequesPropios_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChequesPropios.CellDoubleClick

      Try
         'Limpia los textbox, y demas controles
         Me.LimpiarCamposChequePropio()

         'Carga el Comprobante seleccionado de la grilla en los textbox 
         Me.CargarChequeCompleto(Me.dgvChequesPropios.Rows(e.RowIndex))

         'Elimina el comprobantede la grilla
         Me.EliminarLineaChequePropio()

         Me.txtNroChequePropio.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnInsertarChequeTercero_Click(sender As Object, e As EventArgs) Handles btnInsertarChequeTercero.Click

      If Me._proveedor Is Nothing Then
         MessageBox.Show("ATENCION: Debe elegir el Proveedor antes de cargar el Cheque de Tercero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Me.bscCodigoProveedor2.Focus()
         Exit Sub
      End If

      'Try
      '   If (Not Me.bscBancoTercero.FilaDevuelta Is Nothing) And Me.txtImporte.Text <> "" Then
      '      If Me.ValidarInsertarChequeTercero() Then
      '         Me.InsertarChequeTerceroGrilla()
      '         Me.bscBancoTercero.Focus()
      '      End If
      '   End If
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try

      Try

         Dim oChequesDetalleAyuda As Eniac.Win.ChequesDetalleAyuda
         oChequesDetalleAyuda = New Eniac.Win.ChequesDetalleAyuda(Int32.Parse(Me.cmbCajas.SelectedValue.ToString()), 0)

         oChequesDetalleAyuda.TipoDeMovimiento = "E" 'Reglas.CajaDetalles.TipoMovimiento.Egreso
         oChequesDetalleAyuda.ShowDialog()

         If oChequesDetalleAyuda.blSeleccionados Then
            Me.ActualizaGrillaChequesTerceros(oChequesDetalleAyuda.dtSelectedCheques)
         End If

         Me.CalcularPagos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnEliminarChequeTercero_Click(sender As Object, e As EventArgs) Handles btnEliminarChequeTercero.Click
      Try
         If Me.dgvChequesTerceros.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaChequeTercero()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancariaPropio.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaPropio)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaPropio.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaPropio.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaPropio.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaBancaria(e.FilaDevuelta)
            Me.GetProximoChequeDeChequera()
            Me.txtNroChequePropio.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   'Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick

   '   Try
   '      Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaTransfBanc)
   '      Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
   '      Me.bscCuentaBancariaTransfBanc.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaTransfBanc.Text.Trim())
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   'Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs)

   '   Try
   '      If Not e.FilaDevuelta Is Nothing Then
   '         'Me.CargarDatosCuentasBancarias(e.FilaDevuelta)
   '         Me.bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
   '         Me.bscCuentaBancariaPropio.Focus()
   '      End If
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   Private Sub txtTarjetas_Leave(sender As Object, e As EventArgs) Handles txtTarjetas.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTarjetas_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTarjetas.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTransferenciaBancaria_Leave(sender As Object, e As EventArgs) Handles txtTransferenciaBancaria.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTransferenciaBancaria_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTransferenciaBancaria.KeyUp
      If e.KeyCode = Keys.Enter Then
         If Not String.IsNullOrEmpty(Me.txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 Then
            Me.PresionarTab(e)
            'Me.bscCuentaBancariaTransfBanc.Focus()
         Else
            Me.bscCuentaBancariaPropio.Focus()
         End If
      End If
   End Sub

   Private Sub tsbInvocarPedidos_Click(sender As Object, e As EventArgs) Handles tsbInvocarPedidos.Click
      Try
         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoProveedor2.Selecciono And Not Me.bscProveedor2.Selecciono Then
            Exit Sub
         End If

         Dim IdTipoComprobante As String = "PEDIDOPROVEEDOR"

         Me._InvocaPedido = True

         Dim oPedidosAyuda As PedidosProvPendientesAyuda

         If Me.dgvPedidos.Rows.Count = 0 Then
            oPedidosAyuda = New PedidosProvPendientesAyuda(Me.cboTipoComprobante.SelectedValue.ToString(), IdTipoComprobante, _proveedor.IdProveedor)
         Else
            oPedidosAyuda = New PedidosProvPendientesAyuda(Me.cboTipoComprobante.SelectedValue.ToString(), IdTipoComprobante, _proveedor.IdProveedor, DirectCast(Me.dgvPedidos.DataSource, List(Of Entidades.Compra)))
         End If

         oPedidosAyuda.ShowDialog()

         Me.CargarComprobantesFacturables(oPedidosAyuda.ComprobantesSeleccionados)
         Me.CargarProductosFacturables(oPedidosAyuda.ComprobantesSeleccionados)

         'If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
         '   Me.CargarObservacionesFacturables(oPedidosAyuda.ComprobantesSeleccionados)
         'End If

         Me.LimpiarCamposProductos()
         Me.CalcularDescuentoRecargo()
         Me.CalcularTotales()
         If Me.tbcDetalle.SelectedTab Is tbpRemitoTransp Then
            Me.CalcularTotalRemitoTransporte()
         End If
         'Me.CalcularDatosDetalle()
         'Me.CalcularTotales()

         'If Me.tbcDetalle.Contains(Me.tbpRemitoTransp) Then
         '   Me.CalcularTotalRemitoTransporte()
         'End If


         If Me._comprobantesSeleccionados.Count > 0 Then
            If Not Me.tbcDetalle.Contains(Me.tbpFacturables) Then
               Me.tbcDetalle.TabPages.Add(Me.tbpFacturables)
            End If
            'If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
            '   Me.CambiarEstadoControlesDetalle(False)
            '   Me._ModificaDetalle = "SOLOPRECIOS"
            'End If
         Else
            If Me.tbcDetalle.Contains(Me.tbpFacturables) Then
               Me.tbcDetalle.TabPages.Remove(Me.tbpFacturables)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbInvocarComprobantes_Click(sender As Object, e As EventArgs) Handles tsbInvocarComprobantes.Click
      Try
         'Valido que haya ingresado el Proveedor. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoProveedor2.Selecciono And Not Me.bscProveedor2.Selecciono Then
            Exit Sub
         End If

         Dim IdTipoComprobante As String = String.Empty

         Dim oFactAyuda As FacturablesPendientesComAyuda

         If Me.dgvfacturables.RowCount > 0 Then
            If Me._comprobantesSeleccionados IsNot Nothing Then
               If Me._comprobantesSeleccionados.Count > 0 Then
                  IdTipoComprobante = Me._comprobantesSeleccionados(0).TipoComprobante.IdTipoComprobante
               End If
            End If
         Else
            IdTipoComprobante = ""
         End If

         If Me.dgvfacturables.Rows.Count = 0 Then
            oFactAyuda = New FacturablesPendientesComAyuda(Me.cboTipoComprobante.SelectedValue.ToString(), IdTipoComprobante, _proveedor.IdProveedor, New List(Of Entidades.Compra)())
         Else
            oFactAyuda = New FacturablesPendientesComAyuda(Me.cboTipoComprobante.SelectedValue.ToString(), IdTipoComprobante, _proveedor.IdProveedor, DirectCast(Me.dgvfacturables.DataSource, Entidades.Compra()).ToList())
         End If

         oFactAyuda.ShowDialog()

         If oFactAyuda.DialogResult = DialogResult.OK Then
            If Not oFactAyuda.chbSoloCopiar.Checked Then
               Me.CargarComprobantesFacturables(oFactAyuda.ComprobantesSeleccionados)
            End If

            Me.CargarProductosFacturables(oFactAyuda.ComprobantesSeleccionados)

            Me.LimpiarCamposProductos()
            Me.CalcularDescuentoRecargo()
            Me.CalcularTotales()

            If Not oFactAyuda.chbSoloCopiar.Checked Then
               If Me._comprobantesSeleccionados.Count > 0 Then
                  If Not Me.tbcDetalle.Contains(Me.tbpFacturablesCom) Then
                     Me.tbcDetalle.TabPages.Add(Me.tbpFacturablesCom)
                  End If
                  'If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
                  '   Me.CambiarEstadoControlesDetalle(False)
                  '   Me._ModificaDetalle = "SOLOPRECIOS"
                  'End If
               Else
                  If Me.tbcDetalle.Contains(Me.tbpFacturablesCom) Then
                     Me.tbcDetalle.TabPages.Remove(Me.tbpFacturablesCom)
                  End If
               End If
            End If
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub dgvObservaciones_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvObservaciones.CellDoubleClick

      Try

         'limpia los textbox, y demas controles
         Me.LimpiarCamposObservDetalles()

         'carga la observacion seleccionada de la grilla en los textbox 
         Me.CargarObservDetalleCompleto(Me.dgvObservaciones.Rows(e.RowIndex))

         'elimina el producto de la grilla
         Me.EliminarLineaObservacion()

         'Tengo que renumerar por la forma que asigno el numero de linea.
         Me.RenumerarObservacionesDetalle()

         Me.bscObservacionDetalle.Focus()
         'Me.bscObservacionDetalle.SelectAll()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub bscObservacion_BuscadorClick() Handles bscObservacion.BuscadorClick
      Try
         Dim oProductos As Reglas.Observaciones = New Reglas.Observaciones
         Me._publicos.PreparaGrillaObservaciones(Me.bscObservacion)
         Me.bscObservacion.Datos = oProductos.GetPorNombre(Me.bscObservacion.Text.Trim(), "COMPRA")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscObservacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscObservacion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarObservacion(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscObservacionDetalle_BuscadorClick() Handles bscObservacionDetalle.BuscadorClick
      Try
         Dim oProductos As Reglas.Observaciones = New Reglas.Observaciones
         Me._publicos.PreparaGrillaObservaciones(Me.bscObservacionDetalle)
         Me.bscObservacionDetalle.Datos = oProductos.GetPorNombre(Me.bscObservacionDetalle.Text.Trim(), "COMPRA")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscObservacionDetalle_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscObservacionDetalle.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarObservDetalle(e.FilaDevuelta)
            'Me.txtCantidad.Focus()
            'Me.txtCantidad.SelectAll()
            Me.btnInsertarObservacion.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnInsertarObservacion_Click(sender As Object, e As EventArgs) Handles btnInsertarObservacion.Click
      Try
         If Me.bscObservacionDetalle.Text <> "" Then
            If Me.ValidarInsertaObservacion() Then
               Me.InsertarObservacion()
               Me.bscObservacionDetalle.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnEliminarObservacion_Click(sender As Object, e As EventArgs) Handles btnEliminarObservacion.Click
      Try
         If Me.dgvObservaciones.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la Observación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaObservacion()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbCambiaParametros_Click(sender As Object, e As EventArgs) Handles tsbCambiaParametros.Click
      Try
         Using frm As New MovimientosDeComprasParametros(_decimalesAMostrarEnTotalXProducto,
                                                         _decimalesAMostrarEnPrecio,
                                                         _decimalesRedondeoEnPrecio,
                                                         _decimalesEnCantidad,
                                                         _decimalesMostrarEnCantidad,
                                                         _decimalesEnTotales,
                                                         _permiteModificarSubtotal)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

               _decimalesAMostrarEnTotalXProducto = frm.DecimalesAMostrarEnTotalXProducto
               _decimalesAMostrarEnPrecio = frm.DecimalesAMostrarEnPrecio
               _decimalesRedondeoEnPrecio = frm.DecimalesRedondeoEnPrecio
               _decimalesEnCantidad = frm.DecimalesEnCantidad
               _decimalesMostrarEnCantidad = frm.DecimalesMostrarEnCantidad
               _decimalesEnTotales = frm.DecimalesEnTotales
               _permiteModificarSubtotal = frm.PermiteModificarSubtotal

               SeteaFormatosACampos()
            End If
         End Using

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtTotalProducto_Leave(sender As Object, e As EventArgs) Handles txtTotalProducto.Leave
      Try
         If String.IsNullOrWhiteSpace(Me.txtCantidad.Text.Replace("-", "")) Then
            Me.txtCantidad.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         If String.IsNullOrWhiteSpace(Me.txtDescuentoRecargo.Text.Replace("-", "")) Then
            Me.txtDescuentoRecargo.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.txtPrecio.Text = ((Decimal.Parse(Me.txtTotalProducto.Text) - Decimal.Parse(Me.txtDescuentoRecargo.Text)) / Decimal.Parse(Me.txtCantidad.Text)).ToString("N" + _decimalesAMostrarEnTotalXProducto.ToString())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnPercIIBB_Click(sender As Object, e As EventArgs) Handles btnPercIIBB.Click
      Try
         _dtProvincias.AcceptChanges()
         Using frm As New MovimientosDeComprasPercepciones(_dtProvincias)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Dim valor As Object = _dtProvincias.Compute("SUM(importe)", "")
               If IsNumeric(valor) Then
                  txtPercepcionIIBB.Text = Decimal.Parse(valor.ToString()).ToString("N" + _decimalesEnTotales.ToString())
               End If
               txtPercepcionIIBB.ReadOnly = _dtProvincias.Select("importe <> 0").Length > 1
               Me.CalcularTotales()
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnRetencionIIBB_Click(sender As Object, e As EventArgs) Handles btnRetencionIIBB.Click
      TryCatched(
      Sub()
         _dtProvinciasRetenciones.AcceptChanges()
         Using frm As New MovimientosDeComprasPercepciones(_dtProvinciasRetenciones)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Dim valor As Object = _dtProvinciasRetenciones.Compute("SUM(importe)", "")
               If IsNumeric(valor) Then
                  txtRetencionIIBB.Text = Decimal.Parse(valor.ToString()).ToString("N" + _decimalesEnTotales.ToString())
               End If
               txtRetencionIIBB.ReadOnly = _dtProvinciasRetenciones.Select("importe <> 0").Length > 1
               CalcularTotales()
            End If
         End Using
      End Sub)
   End Sub

   Private Sub bscCodigoAduana_BuscadorClick() Handles bscCodigoAduana.BuscadorClick
      Dim codigo As Integer = -1
      Try
         _publicos.PreparaGrillaAduana(bscCodigoAduana)
         If IsNumeric(bscCodigoAduana.Text.Trim()) Then
            codigo = Integer.Parse(bscCodigoAduana.Text.Trim())
         End If
         bscCodigoAduana.Datos = New Reglas.Aduanas().GetFiltradoPorCodigo(codigo)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoAduana_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoAduana.BuscadorSeleccion, bscAduana.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosAduana(e.FilaDevuelta)
            bscCodigoDestinacion.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscAduana_BuscadorClick() Handles bscAduana.BuscadorClick
      Try
         _publicos.PreparaGrillaAduana(bscAduana)
         bscAduana.Datos = New Reglas.Aduanas().GetFiltradoPorNombre(bscAduana.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoDestinacion_BuscadorClick() Handles bscCodigoDestinacion.BuscadorClick
      Try
         _publicos.PreparaGrillaDestinacion(bscCodigoDestinacion)
         bscCodigoDestinacion.Datos = New Reglas.AduanasDestinaciones().GetFiltradoPorCodigo(bscCodigoDestinacion.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoDestinacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoDestinacion.BuscadorSeleccion, bscDestinacion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosDestinacion(e.FilaDevuelta)
            txtNumeroDespacho.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscDestinacion_BuscadorClick() Handles bscDestinacion.BuscadorClick
      Try
         _publicos.PreparaGrillaDestinacion(bscDestinacion)
         bscDestinacion.Datos = New Reglas.AduanasDestinaciones().GetFiltradoPorNombre(bscDestinacion.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoDespachante_BuscadorClick() Handles bscCodigoDespachante.BuscadorClick
      Dim codigo As Integer = 0
      If IsNumeric(bscCodigoDespachante.Text.Trim()) Then
         codigo = Integer.Parse(bscCodigoDespachante.Text.Trim())
      End If

      Try
         _publicos.PreparaGrillaDespachante(bscCodigoDespachante)
         bscCodigoDespachante.Datos = New Reglas.AduanasDespachantes().GetFiltradoPorCodigo(codigo)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoDespachante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoDespachante.BuscadorSeleccion, bscDespachante.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosDespachante(e.FilaDevuelta)
            bscCodigoAgenteTransporte.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscDespachante_BuscadorClick() Handles bscDespachante.BuscadorClick
      Try
         _publicos.PreparaGrillaDespachante(bscDespachante)
         bscDespachante.Datos = New Reglas.AduanasDespachantes().GetFiltradoPorNombre(bscDespachante.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoAgenteTransporte_BuscadorClick() Handles bscCodigoAgenteTransporte.BuscadorClick
      Dim codigo As Integer = 0
      If IsNumeric(bscCodigoAgenteTransporte.Text.Trim()) Then
         codigo = Integer.Parse(bscCodigoAgenteTransporte.Text.Trim())
      End If

      Try
         _publicos.PreparaGrillaAgenteTransporte(bscCodigoAgenteTransporte)
         bscCodigoAgenteTransporte.Datos = New Reglas.AduanasAgentesTransporte().GetFiltradoPorCodigo(codigo)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoAgenteTransporte_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoAgenteTransporte.BuscadorSeleccion, bscAgenteTransporte.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosAgenteTransporte(e.FilaDevuelta)
            txtDerechoAduana.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscAgenteTransporte_BuscadorClick() Handles bscAgenteTransporte.BuscadorClick
      Try
         _publicos.PreparaGrillaAgenteTransporte(bscAgenteTransporte)
         bscAgenteTransporte.Datos = New Reglas.AduanasAgentesTransporte().GetFiltradoPorNombre(bscAgenteTransporte.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarDespacho_Click(sender As Object, e As EventArgs) Handles btnInsertarDespacho.Click

      Try
         Dim baseImponible As Decimal = 0
         Dim alicuota As Decimal = 0
         Dim importe As Decimal = 0
         If IsNumeric(txtBaseImponibleDespacho.Text.Trim()) Then
            baseImponible = Decimal.Parse(txtBaseImponibleDespacho.Text.Trim())
         End If
         If IsNumeric(txtAlilcuotaDespacho.Text.Trim()) Then
            alicuota = Decimal.Parse(txtAlilcuotaDespacho.Text.Trim())
         End If
         If IsNumeric(txtImporteDespacho.Text.Trim()) Then
            importe = Decimal.Parse(txtImporteDespacho.Text.Trim())
         End If

         If baseImponible + alicuota = 0 Then Exit Sub

         _comprasImpuestosDespachoImportacion.Add(New Entidades.CompraImpuesto(Entidades.TipoImpuesto.Tipos.IVA.ToString(),
                                                                              baseImponible,
                                                                              importe,
                                                                              alicuota))

         ugImpuestosDespacho.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

         txtDerechoAduana.Text = Decimal.Round(Decimal.Parse(ugImpuestosDespacho.Rows.SummaryValues(Entidades.CompraImpuesto.Columnas.Importe.ToString()).Value.ToString()), 2).ToString()

         CalcularTotales()

         LimpiarCamposDepachoImpuestos()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub btnRefrescarDespacho_Click(sender As Object, e As EventArgs) Handles btnRefrescarDespacho.Click
      LimpiarCamposDepachoImpuestos()
   End Sub

   Private Sub btnEliminarDespacho_Click(sender As Object, e As EventArgs) Handles btnEliminarDespacho.Click

      If Me.ugImpuestosDespacho.Rows.Count = 0 Then Exit Sub

      Try
         If ugImpuestosDespacho.ActiveRow IsNot Nothing AndAlso
            ugImpuestosDespacho.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugImpuestosDespacho.ActiveRow.ListObject) Is Entidades.CompraImpuesto Then
            _comprasImpuestosDespachoImportacion.Remove(DirectCast(ugImpuestosDespacho.ActiveRow.ListObject, Entidades.CompraImpuesto))

            ugImpuestosDespacho.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

            CalcularTotales()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtBaseImponibleDespacho_Leave(sender As Object, e As EventArgs) Handles txtBaseImponibleDespacho.Leave, txtAlilcuotaDespacho.Leave
      Try
         Dim baseImponible As Decimal = 0
         Dim alicuota As Decimal = 0
         Decimal.TryParse(txtBaseImponibleDespacho.Text, baseImponible)
         Decimal.TryParse(txtAlilcuotaDespacho.Text, alicuota)

         txtImporteDespacho.Text = (baseImponible * alicuota / 100).ToString("N2")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dtpFecha_Leave(sender As Object, e As EventArgs) Handles dtpFecha.Leave
      dtpFechaOficializacion.Value = dtpFecha.Value
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscTransportista_BuscadorClick() Handles bscTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscTransportista)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         Me.bscTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscTransportista.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)
            Me.txtNumeroLote.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '  Me.Nuevo()
      End Try
   End Sub

   Private Sub txtValorDeclarado_Leave(sender As Object, e As EventArgs) Handles txtValorDeclarado.Leave
      Me.txtValorDeclarado.Text = Decimal.Parse(Me.txtValorDeclarado.Text).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))


      Me.txtTotalBruto.Text = txtValorDeclarado.Text
      Me.txtTotalNeto.Text = txtValorDeclarado.Text
      Me.txtTotalGeneral.Text = txtValorDeclarado.Text
      txtTotalGeneralCabecera.Text = txtTotalGeneral.Text
      'Se quiere que afecte el valor declarado en el calculo.
      'Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)
   End Sub

   Private Sub btnLimpiarProductoRT_Click(sender As Object, e As EventArgs) Handles btnLimpiarProductoRT.Click
      Me.LimpiarCamposProductosRT()
      Me.bscCodigoProducto2RT.Focus()
   End Sub


   Private Sub bscCodigoProducto2RT_BuscadorClick() Handles bscCodigoProducto2RT.BuscadorClick
      Try
         If Me.bscCodigoProducto2RT.Enabled And Me._proveedor Is Nothing Then
            MessageBox.Show("ATENCION: Debe cargar el Proveedor antes de cargar el producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.bscCodigoProducto2RT.Text = ""
            Me.bscCodigoProducto2RT.Focus()
            Exit Sub
         End If

         If Existe() Then

            MessageBox.Show("Este comprobante ya fue INGRESADO con ANTERIORIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroFactura.Focus()
            Exit Sub
         End If

         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Dim oProdProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores()

         If Me.chbProductosDelProveedor.Checked Then

            Me._publicos.PreparaGrillaProductosProveedor2(Me.bscCodigoProducto2RT)
            Me.bscCodigoProducto2RT.Datos = oProdProv.GetPorCodigoProdProv(Me.bscCodigoProducto2RT.Text.Trim(), actual.Sucursal.Id, _listaPreciosPredeterminada, "COMPRAS", _proveedor.IdProveedor, soloCompuestos:=False, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
         Else
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2RT)
            Me.bscCodigoProducto2RT.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2RT.Text.Trim(), actual.Sucursal.Id, _listaPreciosPredeterminada, "COMPRAS", soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Sub bscProducto2RT_BuscadorClick() Handles bscProducto2RT.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2RT)
         Me.bscProducto2RT.Datos = oProductos.GetPorNombre(Me.bscProducto2RT.Text.Trim(), actual.Sucursal.Id, _listaPreciosPredeterminada, "COMPRAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCodigoProducto2RT_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2RT.BuscadorSeleccion, bscProducto2RT.BuscadorSeleccion
      TryCatched(Sub() CargarProductoRT(e.FilaDevuelta))
   End Sub


   Private Sub dgvRemitoTransp_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRemitoTransp.CellDoubleClick
      Try
         If Me._ModificaDetalleRT <> "NO" Then
            'limpia los textbox, y demas controles
            Me.LimpiarCamposProductosRT()
            'carga el producto seleccionado de la grilla en los textbox 
            '# Seteo el valor del parámetro
            _editarProductoDesdeGrilla = True
            Me.CargarProductoCompletoRT(Me.dgvRemitoTransp.Rows(e.RowIndex), editarProductoDesdeGrilla:=_editarProductoDesdeGrilla)
            'elimina el producto de la grilla
            Me.EliminarLineaProductoRT()

            If _ModificaDetalle = "SOLOPRECIOS" Then
               tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
               btnInsertar.Enabled = True
            End If
            If pnlCantidadUMCRT.Enabled And pnlCantidadUMCRT.Visible Then
               Navegar(txtCantidadUMCompraRT)
            Else
               txtCantidadRT.Focus()
               txtCantidadRT.SelectAll()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPrecioLista_Leave(sender As Object, e As EventArgs) Handles txtPrecioLista.Leave, txtDescuento1.Leave, txtDescuento2.Leave, txtDescuento3.Leave
      TryCatched(Sub() SetPrecioCostoDesdePrecioCompra())
   End Sub


   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      Me.txtNumeroFactura.Enabled = Not chbNumeroAutomatico.Checked
   End Sub

   Private Sub txtPrecioDolares_Leave(sender As Object, e As EventArgs) Handles txtPrecioDolares.Leave
      Try
         txtPrecio.Text = Math.Round(Decimal.Parse(txtPrecioDolares.Text) * Decimal.Parse(txtCotizacionDolar.Text), _decimalesRedondeoEnPrecio).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugIVAs_CellDataError(sender As Object, e As CellDataErrorEventArgs) Handles ugIVAs.CellDataError
      e.RaiseErrorEvent = False
   End Sub

   Private Sub ugIVAs_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugIVAs.AfterCellUpdate
      If e.Cell.Column.Key = "Importe" Then
         CalcularTotales()
      End If
   End Sub

   Private Sub chbConcepto_CheckedChanged(sender As Object, e As EventArgs) Handles chbConcepto.CheckedChanged
      Try
         Me.cmbConceptos.Enabled = Me.chbConcepto.Checked
         If Not Me.chbConcepto.Checked Then
            Me.cmbConceptos.SelectedIndex = -1
         Else
            Me.cmbConceptos.SelectedIndex = 0
            Me.cmbConceptos.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged
      If Me._estaCargando Then Exit Sub
      Try
         If Me.cboTipoComprobante.SelectedValue IsNot Nothing Then

            chbNumeroAutomatico.Checked = False
            cboLetra.Enabled = True
            txtEmisorFactura.Enabled = True
            txtNumeroFactura.Enabled = True
            chbNumeroAutomatico.Visible = False
            lblNumeroAutomatico.Visible = False
            lblNumeroFactura.Text = "Número"

            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Trim().Length = 1 Then
               Me.cboLetra.Text = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me._proveedor IsNot Nothing Then
                  If Me._proveedor.EsProveedorGenerico Then
                     Me.cboLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscalCompra
                  Else
                     Me.cboLetra.Text = Me._proveedor.CategoriaFiscal.LetraFiscalCompra
                  End If

               Else
                  Me.cboLetra.SelectedIndex = -1
               End If

            End If


            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).NumeracionAutomatica Then
               Me.CargarProximoNumeroProveedor()
            ElseIf DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 And
               Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).AfectaCaja And
               Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).ActualizaCtaCte Then
               Me.CargarProximoNumero()
            Else
               Me.txtEmisorFactura.Text = ""
               Me.txtNumeroFactura.Text = ""
            End If

            Me.cboPeriodoFiscal.Enabled = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro

            txtPercepcionIVA.ReadOnly = Not DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado
            txtPercepcionIIBB.ReadOnly = Not DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado
            btnPercIIBB.Enabled = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado
            txtPercepcionGanancias.ReadOnly = Not DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado
            txtPercepcionVarias.ReadOnly = Not DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado
            txtImpuestosInternos.ReadOnly = Not DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado

         Else

            Me.cboLetra.SelectedIndex = -1
            Me.txtEmisorFactura.Text = ""
            Me.txtNumeroFactura.Text = ""

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#Region "Propiedades por Edición Manual de IVA"
   Private Sub chbAjusteManualIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbAjusteManualIVA.CheckedChanged
      Try
         HabilitaIVA()
         If Not chbAjusteManualIVA.Checked Then
            For Each ci As Entidades.CompraImpuesto In _comprasImpuestos
               ci.Importe = ci.Importe_Calculado
            Next
            Me.CalcularTotales()
         Else

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtIVA105_Leave(sender As Object, e As EventArgs)
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub txtIVA210_Leave(sender As Object, e As EventArgs)
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub txtIVA270_Leave(sender As Object, e As EventArgs)
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

   Private Sub MovimientosDeComprasV2_FormClosed(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

      Dim valida As Boolean = False
      Dim stbMensaje As StringBuilder = New StringBuilder()

      stbMensaje.AppendFormatLine("¿ Desea Salir del Formulario ?").AppendLine()
      stbMensaje.AppendFormatLine("       Verifique:").AppendLine()

      If dgvProductos.RowCount > 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Tiene Productos Cargados.").AppendLine()
      End If
      If valida Then
         If MessageBox.Show(stbMensaje.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
         End If
      End If

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

   Private Sub txtCantidadUMCompra_Leave(sender As Object, e As EventArgs) Handles txtCantidadUMCompra.Leave
      TryCatched(Sub() txtUnidadesCompras.SetValor(RequerimientosComprasDetalle.CalculaCantidadDesdeCantidadUMC(txtCantidadUMCompra.ValorNumericoPorDefecto(0D), txtCantidadUMCompra.TagNumericoPorDefecto(0D))))
   End Sub
   Private Sub txtUnidadesCompras_Leave(sender As Object, e As EventArgs) Handles txtUnidadesCompras.Leave
      TryCatched(
      Sub()
         If txtCantidadUMCompra.ValorNumericoPorDefecto(0D) <> 0 AndAlso txtUnidadesCompras.ValorNumericoPorDefecto(0D) <> 0 Then
            If txtPrecioPorUMCompra.ValorNumericoPorDefecto(0D) <> 0 Then
               txtCantidad.SetValor(txtUnidadesCompras.ValorNumericoPorDefecto(0D))
               txtPrecio.SetValor(txtCantidadUMCompra.ValorNumericoPorDefecto(0D) * txtPrecioPorUMCompra.ValorNumericoPorDefecto(0D) / txtUnidadesCompras.ValorNumericoPorDefecto(0D))
            Else
               ShowMessage("No se puede ingresar Precio x UMC en Cero")
            End If
         Else
            ShowMessage("No se puede ingresar Cantidad UMC o Unidades en Cero")
         End If
      End Sub)
   End Sub

   Private Sub txtCantidadUMCompraRT_Leave(sender As Object, e As EventArgs) Handles txtCantidadUMCompraRT.Leave
      TryCatched(Sub() txtUnidadesComprasRT.SetValor(RequerimientosComprasDetalle.CalculaCantidadDesdeCantidadUMC(txtCantidadUMCompraRT.ValorNumericoPorDefecto(0D), txtCantidadUMCompraRT.TagNumericoPorDefecto(0D))))
   End Sub
   Private Sub txtUnidadesComprasRT_Leave(sender As Object, e As EventArgs) Handles txtUnidadesComprasRT.Leave
      TryCatched(
      Sub()
         txtCantidadRT.SetValor(txtUnidadesComprasRT.ValorNumericoPorDefecto(0D))
         'txtPrecio.SetValor(txtCantidadUMCompraRT.ValorNumericoPorDefecto(0D) * txtPrecioPorumc.ValorNumericoPorDefecto(0D) / txtUnidadesComprasRT.ValorNumericoPorDefecto(0D))
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub IIBBxProvincia(ciList As List(Of Entidades.CompraImpuesto))
      For Each ci As Entidades.CompraImpuesto In ciList
         If Not String.IsNullOrEmpty(ci.IdProvincia) Then
            Dim dr As DataRow() = _dtProvincias.Select(String.Format("IdProvincia = '{0}'", ci.IdProvincia))
            Dim imp As Decimal = CDec(dr(0)("Importe"))
            imp += ci.Importe
            dr(0)("Importe") = imp
         End If
      Next
   End Sub
   Private Sub IIBBxProvincia(ciList As List(Of Entidades.CompraRetencion))
      For Each cr In ciList
         Dim r = cr.Retencion
         If Not String.IsNullOrEmpty(r.IdProvincia) Then
            Dim dr As DataRow() = _dtProvinciasRetenciones.Select(String.Format("IdProvincia = '{0}'", r.IdProvincia))
            Dim imp As Decimal = CDec(dr(0)("Importe"))
            imp += r.ImporteTotal
            dr(0)("Importe") = imp
         End If
      Next
   End Sub

   Private Function SeleccionDeLotes(lineaDetalle As Entidades.MovimientoStockProducto, loteSeleccionado As String) As Boolean

      With lineaDetalle

         Dim pl As Entidades.ProductoLote = New Entidades.ProductoLote

         Dim idL = New SeleccionDeLote(.IdProducto, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer),
                                       .Cantidad, DirectCast(cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock, True,
                                       loteSeleccionado, informeCalidad, .InformeCalidadNumero, .InformeCalidadLink)
         If idL.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Me.btnInsertar.Focus()
            If String.IsNullOrEmpty(.IdLote) Then
               ShowMessage("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.")
               Return False
            End If
         Else
            If Not String.IsNullOrEmpty(loteSeleccionado) Then Me._productosLotes.Remove(_productosLotes.Where(Function(x) x.IdLote = loteSeleccionado And x.Orden.Value = .Orden).FirstOrDefault())

            .IdLote = idL.bscLote.Text.ToUpper()
            .VtoLote = idL.dtpFechaVencimiento.Value.Date

            .InformeCalidadNumero = idL.txtInformeCalidad.Text
            .InformeCalidadLink = idL.txtLinkdoc.Text
            If String.IsNullOrEmpty(.InformeCalidadNumero) AndAlso informeCalidad Then
               ShowMessage("Recuerde Ingresar Numero de Informe de calidad y un archivo de Calidad Digitalizado.")
               Return False
            End If
            'Si Agrega, valido fechas.. sino.. que exista
            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock > 0 Then

               If Reglas.Publicos.LoteSolicitaFechaVencimiento Then
                  'Controlar la fecha de la factura con la fecha de vencimiento del lote
                  If idL.dtpFechaVencimiento.Value.Date = Me.dtpFecha.Value.Date Then
                     If MessageBox.Show("La fecha del lote es igual a la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                        Return False
                     End If
                  ElseIf idL.dtpFechaVencimiento.Value.Date < Me.dtpFecha.Value.Date Then
                     If MessageBox.Show("La fecha del lote es menor que la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                        Return False
                     End If
                  End If

                  pl.FechaVencimiento = idL.dtpFechaVencimiento.Value
               Else
                  pl.FechaVencimiento = Nothing
               End If

               pl.PrecioCosto = .PrecioCostoNuevo
               'Valido que exista
            Else

               Dim oProductoLote As Entidades.ProductoLote

               oProductoLote = New Reglas.ProductosLotes().GetUno(.IdProducto, idL.bscLote.Text.ToUpper(), actual.Sucursal.Id, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer))

               If oProductoLote Is Nothing Then
                  Throw New Exception(String.Format("El Lote {0} del Producto {1} no existe.", idL.bscLote.Text.ToUpper(), .IdProducto))
                  'ShowMessage("No existe el Lote informado.")
                  'Return False
               End If

               If oProductoLote.CantidadActual < Math.Abs(Decimal.Parse(Me.txtCantidad.Text)) Then
                  Throw New Exception(String.Format("El Lote '{0}' tiene en Stock {1} quedaría en Cantidad Negativa en caso de Restarle {2}.",
                                                    idL.bscLote.Text, oProductoLote.CantidadActual, Math.Abs(txtCantidad.ValorNumericoPorDefecto(0D))))
                  'ShowMessage("El Lote '" & idL.bscLote.Text & "' tiene en Stock " & oProductoLote.CantidadActual.ToString() & " quedaría en Cantidad Negativa en caso de Restarle " & Math.Abs(Decimal.Parse(Me.txtCantidad.Text)).ToString() & ".")
                  'Return False
               End If

               'Le pongo la fecha del Lote original
               If oProductoLote.FechaVencimiento.HasValue Then
                  .VtoLote = oProductoLote.FechaVencimiento.Value.Date
               Else
                  .VtoLote = Nothing
               End If
               pl.FechaVencimiento = .VtoLote

            End If

            pl.ProductoSucursal.Sucursal.IdSucursal = .IdSucursal
            pl.ProductoSucursal.Producto.IdProducto = .IdProducto
            pl.IdLote = .IdLote.ToUpper()

            pl.IdDeposito = cmbDepositoOrigen.ValorSeleccionado(Of Integer)
            pl.IdUbicacion = cmbUbicacionOrigen.ValorSeleccionado(Of Integer)

            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
               pl.IdDeposito = cmbDepositoOrigenRT.ValorSeleccionado(Of Integer)
               pl.IdUbicacion = cmbUbicacionOrigenRT.ValorSeleccionado(Of Integer)
            End If

            pl.FechaIngreso = Me.dtpFecha.Value

            pl.CantidadInicial = .Cantidad
            pl.CantidadActual = .Cantidad
            pl.Habilitado = True
            pl.Orden = Me._numeroOrden

            Me._productosLotes.Add(pl)
         End If

      End With

      Return True
   End Function

   Private Sub CargarProductoNroSerieEnLista(lineaDetalle As Entidades.MovimientoStockProducto, productosNrosSerie As List(Of Entidades.ProductoNroSerie))

      Dim eMCPNS As Entidades.MovimientoStockProductoNrosSerie
      With lineaDetalle
         For Each ns As Entidades.ProductoNroSerie In productosNrosSerie
            ns.OrdenCompra = _numeroOrden
            'ns.IdDeposito = Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString())
            'ns.IdUbicacion = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())

            eMCPNS = New Entidades.MovimientoStockProductoNrosSerie
            eMCPNS.IdSucursal = ns.IdSucursal
            eMCPNS.IdDeposito = ns.IdDeposito
            eMCPNS.IdUbicacion = ns.IdUbicacion

            eMCPNS.IdTipoMovimiento = .MovimientoStock.TipoMovimiento.IdTipoMovimiento
            eMCPNS.NumeroMovimiento = .MovimientoStock.NumeroMovimiento
            eMCPNS.Orden = ns.OrdenCompra.Value
            eMCPNS.IdProducto = ns.Producto.IdProducto
            eMCPNS.NroSerie = ns.NroSerie

            .ProductosNrosSerie.Add(eMCPNS)

            Me._productosNrosSeries.Add(ns)
         Next
      End With

      lineaDetalle.ProductoSucursal.Producto.NrosSeries.Clear()
      For Each pns As Entidades.ProductoNroSerie In productosNrosSerie
         lineaDetalle.ProductoSucursal.Producto.NrosSeries.Add(pns)
      Next

   End Sub

   Private Sub CargarProductosNrosSerieADevolver(lineaDetalle As Entidades.MovimientoStockProducto, cantidadProducto As Integer)

      Dim rCPNS As Reglas.ComprasProductosNrosSerie = New Reglas.ComprasProductosNrosSerie
      Dim producto As Entidades.Producto = lineaDetalle.ProductoSucursal.Producto
      Dim dt As DataTable = rCPNS.GetProductosNrosSerieADevolver(producto.IdProducto, _proveedor.IdProveedor)
      Dim coeficienteStock As Integer = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock

      '# Si el producto no corresponde con el proveedor o el producto ya no se encuentra disponible para devolver (porque ya fue vendido), se lo hago saber al usuario
      If dt Is Nothing Then
         Throw New Exception(String.Format("ATENCIÓN: No se encontraron registros. Puede que el proveedor seleccionado no sea el correcto o que el producto ya no se encuentre en stock."))
      End If

      '# Valido que no se haya ingresado una cantidad mayor a la disponible para devolver
      If dt.Rows.Count < cantidadProducto Then
         Throw New Exception(String.Format("ATENCIÓN: La cantidad ingresada a devolver({0}) es mayor a la cantidad disponible en stock({1}).", cantidadProducto, dt.Rows.Count))
      End If

      Using frm As New SeleccionoNrosSerie(cantidadProducto, producto, dt)
         frm._IdDeposito = Integer.Parse(cmbDepositoOrigenRT.SelectedValue.ToString())
         frm._IdUbicacion = Integer.Parse(cmbUbicacionOrigenRT.SelectedValue.ToString())
         If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Me.btnInsertar.Focus()
            Throw New Exception("Debe seleccionar los Nro. Serie del producto a devolver.")
         Else
            Me.CargarProductoNroSerieEnLista(lineaDetalle, frm.ProductosNrosSerie)
         End If
      End Using

   End Sub

   Private Sub CargarProximoNumeroProveedor()
      Dim oVentasNumeros As New Reglas.VentasNumeros()

      Dim ventaNumero As Entidades.VentaNumero = oVentasNumeros.GetUnoPorRelacionado(DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante)
      If ventaNumero IsNot Nothing Then
         cboLetra.SelectedItem = ventaNumero.LetraFiscal
         txtEmisorFactura.Text = ventaNumero.CentroEmisor.ToString()
         txtNumeroFactura.Text = ventaNumero.Numero.ToString()
         txtNumeroFactura.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal,
                                                                 DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                                 ventaNumero.LetraFiscal,
                                                                 ventaNumero.CentroEmisor).ToString()

         cboLetra.Enabled = False
         txtEmisorFactura.Enabled = False
         txtNumeroFactura.Enabled = False
         chbNumeroAutomatico.Visible = True
         lblNumeroAutomatico.Visible = True
         chbNumeroAutomatico.Checked = True
         lblNumeroFactura.Text = "Número (Posible)"

      Else

         If Me.cboLetra.Text <> "" And Not Me._proveedor Is Nothing Then

            Dim oCompras As New Reglas.Compras

            Me.txtEmisorFactura.Text = "1"

            Me.txtNumeroFactura.Text = oCompras.GetProximoNumero(actual.Sucursal.Id,
                                                                  Long.Parse(Me.bscCodigoProveedor2.Tag.ToString),
                                                                  DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                                  Me.cboLetra.Text,
                                                                  Short.Parse("0" & Me.txtEmisorFactura.Text)).ToString()
         Else

            Me.txtEmisorFactura.Text = ""
            Me.txtNumeroFactura.Text = ""

         End If
      End If
   End Sub

   Private Sub CargarProximoNumero()

      If Me.cboLetra.Text <> "" Then

         Dim oImpresoras As New Reglas.Impresoras
         Dim oCN As New Reglas.ComprasNumeros
         Dim CentroEmisor As Short

         'CentroEmisor = oImpresoras.GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, False).CentroEmisor
         CentroEmisor = oImpresoras.GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cboTipoComprobante.SelectedValue.ToString()).CentroEmisor

         Me.txtEmisorFactura.Text = CentroEmisor.ToString()

         Me.txtNumeroFactura.Text = oCN.GetProximoNumero(actual.Sucursal.Id,
                                                         DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                         Me.cboLetra.Text,
                                                         CentroEmisor).ToString()
      Else

         Me.txtEmisorFactura.Text = ""
         Me.txtNumeroFactura.Text = ""

      End If


   End Sub

   Private Sub CalcularDescRecargoProductosXPorc()
      If Decimal.Parse(Me.txtDescuentoRecargoPorc.Text) <> 0 Then
         Me.txtDescuentoRecargo.Text = Decimal.Round((Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtCantidad.Text) * Decimal.Parse(Me.txtDescuentoRecargoPorc.Text) / 100), Me._decimalesRedondeoEnPrecio).ToString("#0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      Else
         Me.txtDescuentoRecargo.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      End If
   End Sub

   Private Sub CalcularDescRecargoProductosXMonto()
      If Decimal.Parse(Me.txtDescuentoRecargo.Text) <> 0 Then
         Me.txtDescuentoRecargoPorc.Text = Decimal.Round(Decimal.Parse(Me.txtDescuentoRecargo.Text) / (Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtCantidad.Text)) * 100, Me._decimalesRedondeoEnPrecio).ToString("#0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      Else
         Me.txtDescuentoRecargoPorc.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      End If
   End Sub

   Private Function Existe() As Boolean
      Dim rCompras = New Reglas.Compras()
      Return rCompras.Existe(idSucursal:=0,
                             ObjectExtensions.ValorNumericoPorDefecto(bscCodigoProveedor2.Tag, 0L),
                             cboTipoComprobante.SelectedValue.ToString(), cboLetra.Text,
                             txtEmisorFactura.ValorNumericoPorDefecto(0S), txtNumeroFactura.ValorNumericoPorDefecto(0L))

   End Function


   Protected Overridable Function ValidarComprobante() As Boolean
      '-- REQ-35209.- ---------------------------------------------
      If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 And (If(_productos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0, 1, 0) +
                      If(_productos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0, 1, 0) +
                      If(_productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0, 1, 0) +
                      If(_productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0, 1, 0)) > 0 Then
         MessageBox.Show("Producto con Atributos no es compatible con Comprobante que no Afecta Stock", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If
      '-----------------------------------------------------------

      Dim sistema As Entidades.Sistema = Publicos.GetSistema()

      '# Vuelvo a calcular los pagos del comprobante
      Me.CalcularPagos()

      If DateDiff(DateInterval.Day, Me.dtpFecha.Value, sistema.FechaVencimiento) < 0 Then
         MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpFecha.Focus()
         Return False
      End If

      If Not Me.bscCodigoProveedor2.Selecciono() And Not Me.bscProveedor2.Selecciono() Then
         MessageBox.Show("Debe cargar un Proveedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProveedor2.Focus()
         Return False
      End If

      If Me._proveedor.EsProveedorGenerico Then
         If Me.txtNombreProveedorGenerico.Text = "" Then
            MessageBox.Show("Debe cargar Nombre de Proveedor Eventual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNombreProveedorGenerico.Focus()
            Return False
         End If
      End If

      If Me.cboTipoComprobante.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cboTipoComprobante.Focus()
         Return False
      End If

      Dim tipoComprobante As Entidades.TipoComprobante = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante)

      If tipoComprobante.EsRemitoTransportista And chbSinProductos.Checked Then
         MessageBox.Show("El remito de transportista debe salir con líneas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.chbSinProductos.Focus()
         Return False
      End If
      If ValidaCuitProveedor() = False Then
         Return False
      End If
      'controlo que el tipo de Comprobante Genere Contabilidad sino no valido los Periodos fiscales
      If tipoComprobante.GeneraContabilidad Then
         If tipoComprobante.GrabaLibro Then

            Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
            'No valido la fecha sino el periodo fiscal. (tal vez alguien lo cerro luego de ingresar).
            Dim dr As DataRow
            If TypeOf (cboPeriodoFiscal.SelectedItem) Is DataRow Then
               dr = DirectCast(cboPeriodoFiscal.SelectedItem, DataRow)
            ElseIf TypeOf (cboPeriodoFiscal.SelectedItem) Is DataRowView Then
               dr = DirectCast(cboPeriodoFiscal.SelectedItem, DataRowView).Row
            Else
               dr = Nothing
            End If
            Dim dt As DataTable = oPF.Get1(Integer.Parse(dr("IdEmpresa").ToString()), Integer.Parse(dr("PeriodoFiscal").ToString()))
            'No deberia pasar.
            If dt.Rows.Count = 0 Then
               MessageBox.Show("El Período Fiscal del Comprobante NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.dtpFecha.Focus()
               Return False
            ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
               MessageBox.Show("El Período Fiscal del Comprobante se encuentra Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.dtpFecha.Focus()
               Return False
            End If
         Else
            'No es fiscal pero en la tabla graba igual el periodo.

            Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
            'No valido la fecha sino el periodo fiscal. (tal vez alguien lo cerro luego de ingresar).
            Dim dt As DataTable = oPF.Get1(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
            'No deberia pasar.
            If dt.Rows.Count = 0 Then
               MessageBox.Show("El Período Fiscal del Comprobante NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.dtpFecha.Focus()
               Return False
            End If
         End If
      End If

      Dim importeTotal As Decimal = If(IsNumeric(txtTotalGeneralCabecera.Text), Decimal.Parse(txtTotalGeneralCabecera.Text), 0)
      If importeTotal < tipoComprobante.ImporteMinimo Then
         If tbcDetalle.Contains(tbpProductos) Then
            tbcDetalle.SelectedTab = tbpProductos
            bscCodigoProducto2.Focus()
         ElseIf tbcDetalle.Contains(tbpRemitoTransp) Then
            tbcDetalle.SelectedTab = tbpRemitoTransp
            bscCodigoProducto2RT.Focus()
         End If
         ShowMessage(String.Format("El importe mínimo para el comprobante {0} es de {1:N2}.", tipoComprobante.Descripcion, tipoComprobante.ImporteMinimo))
         Me.dtpFecha.Focus()
         Return False
      End If

      If Not Publicos.ComprasPermiteFechaMayorHoy AndAlso dtpFecha.Value >= Today.AddDays(1) Then   'Si es mayor o igual a mañana a las 0 horas => es mayor a hoy
         If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 Then
            If MessageBox.Show("La fecha del comprobante es mayor a hoy." + Environment.NewLine + Environment.NewLine + "¿Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
               Me.dtpFecha.Focus()
               Return False
            End If
         Else
            MessageBox.Show("La fecha del comprobante no puede ser mayor a hoy. Por favor reintente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            Return False
         End If
      End If

      'If Me.cboTipoComprobante.Enabled Then
      'End If
      'Valida si el comprobante esta permitido para la letra fiscal
      Dim tip As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      If Not tip.LetraHabilitada(Me.cboTipoComprobante.SelectedValue.ToString(), Me.cboLetra.Text) Then
         MessageBox.Show("Este comprobante no esta habilitado para esta Letra Fiscal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      'Controlo Permitir asignar letra "B" emitido por un RI y productos con 0% IVA
      '-----------------------------------------------------------------
      If Not Me._proveedor Is Nothing And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Trim.Length > 1 Then
         If Not Me._proveedor.EsProveedorGenerico Then
            If Me._proveedor.CategoriaFiscal.LetraFiscalCompra <> Me.cboLetra.Text Then
               If Me._proveedor.CategoriaFiscal.LetraFiscalCompra = "A" And Me.cboLetra.Text = "B" Then
                  If MessageBox.Show("Esta seguro de utilizar la Letra '" & Me.cboLetra.Text & "' ? NO coincide con la del Proveedor '" & Me._proveedor.CategoriaFiscal.LetraFiscalCompra & "'", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel Then
                     Me.cboLetra.SelectedIndex = -1
                     Return False
                  Else
                     For Each cp As Entidades.MovimientoStockProducto In Me._productos
                        If cp.PorcentajeIVA <> 0 Then
                           MessageBox.Show("El porcentaje de IVA no puede ser distinto 0% ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                           Return False
                        End If
                     Next
                  End If
               Else
                  MessageBox.Show("La Letra '" & Me.cboLetra.Text & "' NO coincide con la del Proveedor '" & Me._proveedor.CategoriaFiscal.LetraFiscalCompra & "'", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.cboLetra.SelectedIndex = -1
                  Return False
               End If
            End If
         Else
            Dim CategoriaFiscalProveedor As Entidades.CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
            If CategoriaFiscalProveedor.LetraFiscalCompra <> Me.cboLetra.Text Then
               If CategoriaFiscalProveedor.LetraFiscalCompra = "A" And Me.cboLetra.Text = "B" Then
                  If MessageBox.Show("Esta seguro de utilizar la Letra '" & Me.cboLetra.Text & "' ? NO coincide con la del Proveedor '" & CategoriaFiscalProveedor.LetraFiscalCompra & "'", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel Then
                     Me.cboLetra.SelectedIndex = -1
                     Return False
                     'Else
                     '   For Each cp As Entidades.MovimientoCompraProducto In Me._productos
                     '      If cp.PorcentajeIVA <> 0 Then
                     '         MessageBox.Show("El porcentaje de IVA no puede ser distinto 0% ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     '         Return False
                     '      End If
                     '   Next
                  End If
               Else
                  MessageBox.Show("La Letra '" & Me.cboLetra.Text & "' NO coincide con la del Proveedor '" & Me._proveedor.CategoriaFiscal.LetraFiscalCompra & "'", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.cboLetra.SelectedIndex = -1
                  Return False
               End If
            End If
         End If


      End If
      '---------------------------------------------------------------------------------

      'If Me.cboLetra.Enabled Then
      'End If
      If Me.cboLetra.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de letra del comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cboLetra.Focus()
         Return False
      End If

      'If Me.txtEmisorFactura.Enabled Then
      'End If
      If Me.txtEmisorFactura.Text.Length = 0 Then
         MessageBox.Show("Debe cargar un el Número de Emisor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtEmisorFactura.Focus()
         Return False
      Else
         If Integer.Parse("0" & Me.txtEmisorFactura.Text) <= 0 Then
            MessageBox.Show("El Emisor no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtEmisorFactura.Focus()
            Return False
         End If
      End If

      'If Me.txtNumeroFactura.Enabled Then
      'End If
      If Me.txtNumeroFactura.Text.Length = 0 Then
         MessageBox.Show("Debe cargar un el número del comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroFactura.Focus()
         Return False
      Else
         If Long.Parse("0" & Me.txtNumeroFactura.Text) <= 0 Then
            MessageBox.Show("El Número no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroFactura.Focus()
            Return False
         End If
      End If


      'If Me.cboTipoComprobante.Enabled Then
      'End If
      If Existe() Then
         ShowMessage("Este comprobante ya fue INGRESADO con ANTERIORIDAD")
         txtNumeroFactura.Focus()
         Return False
      End If

      If New Reglas.CuentasCorrientesProv().
                       Existe(idSucursal:=0,
                              ObjectExtensions.ValorNumericoPorDefecto(bscCodigoProveedor2.Tag, 0L),
                              cboTipoComprobante.SelectedValue.ToString(), cboLetra.Text,
                              txtEmisorFactura.ValorNumericoPorDefecto(0S), txtNumeroFactura.ValorNumericoPorDefecto(0L)) Then
         ShowMessage("Este comprobante ya EXISTE en Cuentas Corrientes de Proveedores")
         txtNumeroFactura.Focus()
         Return False
      End If

      'If Me.cboFormaPago.Enabled Then
      'End If
      If Me.cboFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar la forma de pago del documento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cboFormaPago.Focus()
         Return False
      End If

      If Not tipoComprobante.ActualizaCtaCte AndAlso cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).Dias <> 0 AndAlso
         tipoComprobante.CoeficienteStock = 0 Then   'Este último para que no controle la forma de pago en los Remitos - NO aplica a Ventas
         ShowMessage(String.Format("No es posible registrar una {0} a cuenta corriente ya que la misma está configurada como que NO actualiza Cuenta Corriente.", tipoComprobante.Descripcion))
         cboFormaPago.Focus()
         Return False
      End If

      'If Me.cboRubro.Enabled Then
      'End If
      If Me.cboRubro.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cboRubro.Focus()
         Return False
      End If

      ' valido que el usuario haya seleccionado un comprador
      If Me.cmbComprador.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el Comprador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbComprador.Focus()
         Return False
      End If

      If Not tipoComprobante.EsRemitoTransportista Then
         If Me.dgvProductos.Rows.Count = 0 And Not Me.chbSinProductos.Checked Then
            MessageBox.Show("Debe cargar como minimo un producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProductoFocus()
            Return False
         End If
      Else
         If Me.dgvRemitoTransp.Rows.Count = 0 Then
            MessageBox.Show("Debe cargar como minimo un producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProductoFocus()
            Return False
         End If
      End If

      'Si el proveedor esta marcado como que Retiene Ganancias NO puede poner la forma de PAGO CONTADO
      If (Me._proveedor.EsPasibleRetencion Or _proveedor.EsPasibleRetencionIVA) And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         'si es contado
         If DirectCast(Me.cboFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
            MessageBox.Show("Si al proveedor se le Retiene Ganancias o IVA NO puede ser contado la factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboFormaPago.Focus()
            Return False
         ElseIf CDec(txtTotalPago.Text) <> 0 Then
            'SPC: Por el momento no se puede pagar un comprobante directamente si al proveedor se le retiene. Se debe registrar el pago aparte.
            MessageBox.Show("Si al proveedor se le Retiene Ganancias o IVA NO puede imputar pagos en la generación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtEfectivo.Focus()
            Return False
         End If
      End If

      If cboTipoComprobante.ItemSeleccionado(Of Entidades.TipoComprobante).CoeficienteValores < 0 And cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).Dias > 0 Then
         If txtTotalPago.ValorNumericoPorDefecto(0D) > 0 Then
            ShowMessage(String.Format("No es posible registrar una {0} a Cuenta Corriente con Pago Parcial/Total.", cboTipoComprobante.Text))
            txtEfectivo.Focus()
            Return False
         End If
      End If

      If Not _transferencias.Any() AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
         MessageBox.Show("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
      '   MessageBox.Show("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Return False
      'End If

      If Decimal.Parse(Me.txtTransferenciaBancaria.Text) < 0 Then
         MessageBox.Show("El importe de Transferencia Bancaria no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If Decimal.Parse(Me.txtDiferencia.Text) < 0 Then
         MessageBox.Show("No puede asignar mas Pagos que el Total del Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.tbcDetalle.SelectedTab = Me.tbpPagosEfectivo
         Me.txtEfectivo.Focus()
         Return False
      End If

      If Not IsNumeric(txtPercepcionIVA.Text) Then txtPercepcionIVA.Text = "0.00"
      If Not IsNumeric(txtPercepcionIIBB.Text) Then txtPercepcionIIBB.Text = "0.00"
      If Not IsNumeric(txtPercepcionGanancias.Text) Then txtPercepcionGanancias.Text = "0.00"
      If Not IsNumeric(txtPercepcionVarias.Text) Then txtPercepcionVarias.Text = "0.00"
      If Not IsNumeric(txtImpuestosInternos.Text) Then txtImpuestosInternos.Text = "0.00"

      'If Decimal.Parse(txtPercepcionIVA.Text) < 0 Then
      '   ShowMessage("Las Percepciones de IVA no pueden ser negativas.")
      '   Me.txtPercepcionIVA.Focus()
      '   Return False
      'End If

      If Decimal.Parse(txtPercepcionIIBB.Text) < 0 Then
         ShowMessage("Las Percepciones de IIBB no pueden ser negativas.")
         Me.txtPercepcionIIBB.Focus()
         Return False
      End If

      If Decimal.Parse(txtPercepcionGanancias.Text) < 0 Then
         ShowMessage("Las Percepciones de Ganancias no pueden ser negativas.")
         Me.txtPercepcionGanancias.Focus()
         Return False
      End If

      'If Decimal.Parse(txtPercepcionVarias.Text) < 0 Then
      '   ShowMessage("Las Percepciones Varias no pueden ser negativas.")
      '   Me.txtPercepcionVarias.Focus()
      '   Return False
      'End If

      If Decimal.Parse(txtImpuestosInternos.Text) < 0 Then
         ShowMessage("Los Impuestos Internos no pueden ser negativos.")
         Me.txtImpuestosInternos.Focus()
         Return False
      End If

      Dim result As ValidaProvinciasResult = ValidaProvincias(_dtProvincias)
      If Not result.Valida Then
         ShowMessage(result.Mensaje)
         btnPercIIBB.PerformClick()
         Return result.Valida
      End If
      Dim resultReten = ValidaProvincias(_dtProvinciasRetenciones)
      If Not result.Valida Then
         ShowMessage(result.Mensaje)
         btnRetencionIIBB.PerformClick()
         Return result.Valida
      End If

      'Validaciones especiales si es Remito Transportista
      If tipoComprobante.EsRemitoTransportista Then
         If Long.Parse("0" & Me.txtBultos.Text) <= 0 Then
            MessageBox.Show("ATENCION: Debe ingresar el Total de Bultos del Remito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = Me.tbpRemitoTransp
            Me.txtBultos.Focus()
            Return False
         End If

         If _transportistaA Is Nothing Then
            MessageBox.Show("Debe ingresar el Transportista del Remito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = Me.tbpRemitoTransp
            Me.bscTransportista.Focus()
            Return False
         End If

         If Not IsNumeric(txtNumeroLote.Text) Then
            ShowMessage("El Lote del Remito debe ser numérico.")
            tbcDetalle.SelectedTab = Me.tbpRemitoTransp
            txtNumeroLote.Focus()
            Return False
         End If

         If Long.Parse("0" & Me.txtNumeroLote.Text) <= 0 And Reglas.Publicos.Facturacion.FacturacionRemitoTranspUtilizaLote Then
            MessageBox.Show("Debe ingresar el Lote del Remito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = Me.tbpRemitoTransp
            Me.txtNumeroLote.Focus()
            Return False
         End If
      End If


      If chbAFIPConceptoCM05.Checked And cmbAFIPConceptoCM05.SelectedIndex = -1 Then
         tbcDetalle.SelectedTab = tbpTotales
         cmbAFIPConceptoCM05.Select()
         ShowMessage("ATENCION: Activo el Concepto de CM05 pero no seleccionó uno. Debe elegir una.")
         Return False
      End If

      If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsDespachoImportacion Then
         If dtpFechaOficializacion.Value > Now Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("La fecha de oficialización no puede ser posterior a hoy.")
            dtpFechaOficializacion.Focus()
            Return False
         End If

         If dtpFechaOficializacion.Value < Today.AddMonths(-3) Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            If ShowPregunta("Está ingresando una fecha de oficialización anterior a 3 meses. ¿Está seguro?") = Windows.Forms.DialogResult.No Then
               dtpFechaOficializacion.Focus()
               Return False
            End If
         End If

         If Not IsNumeric(bscCodigoAduana.Text) OrElse Integer.Parse(bscCodigoAduana.Text.ToString()) = 0 Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("Debe ingresar una Aduana.")
            bscCodigoAduana.Focus()
            Return False
         End If

         If bscCodigoDestinacion.Text Is Nothing OrElse String.IsNullOrWhiteSpace(bscCodigoDestinacion.Text.ToString()) Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("Debe ingresar una Destinación.")
            bscCodigoDestinacion.Focus()
            Return False
         End If

         If Not IsNumeric(txtNumeroDespacho.Text) OrElse Long.Parse(txtNumeroDespacho.Text) = 0 Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("Debe ingresar un Número de Despacho.")
            txtNumeroDespacho.Focus()
            Return False
         End If

         If String.IsNullOrWhiteSpace(txtDigitoVerificador.Text) Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("Debe ingresar un Dígito Verificador.")
            txtDigitoVerificador.Focus()
            Return False
         End If

         If String.IsNullOrWhiteSpace(txtNumeroManifiesto.Text) Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("Debe ingresar el Número de Manifiesto.")
            txtNumeroManifiesto.Focus()
            Return False
         End If

         If Not IsNumeric(bscCodigoDespachante.Text) OrElse Integer.Parse(bscCodigoDespachante.Text.ToString()) = 0 Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("Debe ingresar un Despachante.")
            bscCodigoDespachante.Focus()
            Return False
         End If

         If Not IsNumeric(bscCodigoAgenteTransporte.Text) OrElse Integer.Parse(bscCodigoAgenteTransporte.Text.ToString()) = 0 Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("Debe ingresar un Agente de Transporte.")
            bscCodigoAgenteTransporte.Focus()
            Return False
         End If

         If Not IsNumeric(txtDerechoAduana.Text) OrElse Decimal.Parse(txtDerechoAduana.Text) = 0 Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            ShowMessage("Debe ingresar Derecho Aduanero.")
            txtDerechoAduana.Focus()
            Return False
         End If

         If _comprasImpuestosDespachoImportacion.Count = 0 Then
            tbcDetalle.SelectTab(tbpDespachoImportacion)
            If ShowPregunta("No ingresó impuestos del despacho. ¿Desea continuar?") = Windows.Forms.DialogResult.No Then
               txtBaseImponibleDespacho.Focus()
               Return False
            End If
         End If
      End If

      'Dim ini As String = (0).ToString("N" + Me._decimalesEnTotales.ToString())

      Dim totalIva As Decimal = 0
      Dim totalIva_Calculado As Decimal = 0

      For Each ci As Entidades.CompraImpuesto In _comprasImpuestos
         totalIva += ci.Importe
         totalIva_Calculado += ci.Importe_Calculado
      Next

      Dim toleranciaIvaManual As Decimal = Reglas.Publicos.ComprasToleranciaIvaManual '  0.05D

      'Si la diferencia entre el total de IVA ingresado por pantalla y el total de IVA calculado es mayor a la tolerancia
      If Math.Abs(totalIva - totalIva_Calculado) > toleranciaIvaManual Then
         ShowMessage(String.Format("El total de IVA ingresado ({0:N2}) difiere del IVA calculado ({1:N2}) por más de {2:N2}. Por favor verifique los importes.",
                                   totalIva, totalIva_Calculado, toleranciaIvaManual))
         ugIVAs.Focus()
         ugIVAs.IrPrimerCeldaEditable()
         Return False
      End If

      If Me.chbNroOrdenDeCompra.Checked AndAlso String.IsNullOrEmpty(Me.bscNroOrdenDeCompra.Text.ToString()) Then
         ShowMessage("Activó O.C. pero no selecciono una orden de compra.")
         Return False
      End If

      For Each pro As Entidades.MovimientoStockProducto In Me._productos
         If pro.ProductoSucursal.Producto.NroSerie Then
            If pro.ProductoSucursal.Producto.NrosSeries.Count < pro.Cantidad Then
               ShowMessage(String.Format("ATENCION: Producto {0} - {1} falta seleccionar numeros de serie", pro.ProductoSucursal.Producto.IdProducto, pro.ProductoSucursal.Producto.NombreProducto))
               Return False
            End If
         End If

      Next

      For Each pro As Entidades.MovimientoStockProducto In Me._productosRT
         If pro.ProductoSucursal.Producto.NroSerie Then
            If pro.ProductoSucursal.Producto.NrosSeries.Count < pro.Cantidad Then
               ShowMessage(String.Format("ATENCION: Producto {0} - {1} falta seleccionar numeros de serie", pro.ProductoSucursal.Producto.IdProducto, pro.ProductoSucursal.Producto.NombreProducto))
               Return False
            End If
         End If

      Next

      Dim rCompras As Reglas.Compras = New Reglas.Compras()
      rCompras.ValidaMediosPagoSegunFormaPago(cboTipoComprobante.ItemSeleccionado(Of Entidades.TipoComprobante),
                                             cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                             txtEfectivo.Text.ValorNumericoPorDefecto(0D),
                                             txtTransferenciaBancaria.Text.ValorNumericoPorDefecto(0D),
                                             _chequesPropios)

      Return True

   End Function

   Public Class ValidaProvinciasResult
      Public Property Valida As Boolean
      Public Property Mensaje As String
      Public Sub New(valida As Boolean, mensaje As String)
         Me.Valida = valida
         Me.Mensaje = mensaje
      End Sub
   End Class
   Public Shared Function ValidaProvincias(dtProvincias As DataTable) As ValidaProvinciasResult
      Dim stbErrorPercepciones As StringBuilder = New StringBuilder()
      Dim algunErrorPercepciones As Boolean = False

      For Each drProvincias As DataRow In dtProvincias.Rows
         drProvincias.ClearErrors()
         If IsNumeric(drProvincias(Entidades.CompraImpuesto.Columnas.Importe.ToString())) AndAlso
            Decimal.Parse(drProvincias(Entidades.CompraImpuesto.Columnas.Importe.ToString()).ToString()) <> 0 Then
            Dim stbErrorActual As StringBuilder = New StringBuilder()
            Dim errorActual As Boolean = False

            'If Not IsNumeric(drProvincias(Entidades.CompraImpuesto.Columnas.Numero.ToString())) OrElse
            '   Long.Parse(drProvincias(Entidades.CompraImpuesto.Columnas.Numero.ToString()).ToString()) = 0 Then
            '   algunErrorPercepciones = True
            '   errorActual = True
            '   Dim mensaje As String = "Debe ingresar Numero de Percepción"
            '   stbErrorActual.AppendFormat("  - {0}", mensaje).AppendLine()
            '   drProvincias.SetColumnError(Entidades.CompraImpuesto.Columnas.Numero.ToString(), mensaje)
            'End If

            'No son obligatorias para la exportación. Solicitado sacar el control
            'If Not IsNumeric(drProvincias(Entidades.CompraImpuesto.Columnas.BaseImponible.ToString())) OrElse
            '   Decimal.Parse(drProvincias(Entidades.CompraImpuesto.Columnas.BaseImponible.ToString()).ToString()) = 0 Then
            '   algunErrorPercepciones = True
            '   errorActual = True
            '   Dim mensaje As String = "Debe ingresar Base Imponible de Percepción"
            '   stbErrorActual.AppendFormat("  - {0}", mensaje).AppendLine()
            '   drProvincias.SetColumnError(Entidades.CompraImpuesto.Columnas.BaseImponible.ToString(), mensaje)
            'End If
            'If Not IsNumeric(drProvincias(Entidades.CompraImpuesto.Columnas.Alicuota.ToString())) OrElse
            '   Decimal.Parse(drProvincias(Entidades.CompraImpuesto.Columnas.Alicuota.ToString()).ToString()) = 0 Then
            '   algunErrorPercepciones = True
            '   errorActual = True
            '   Dim mensaje As String = "Debe ingresar Alicuota de Percepción"
            '   stbErrorActual.AppendFormat("  - {0}", mensaje).AppendLine()
            '   drProvincias.SetColumnError(Entidades.CompraImpuesto.Columnas.Alicuota.ToString(), mensaje)
            'End If

            If errorActual Then
               stbErrorPercepciones.AppendFormat("Falta completar información para Perc. IIBB de {0}",
                                                 drProvincias(Entidades.Provincia.Columnas.NombreProvincia.ToString())).AppendLine()
               stbErrorPercepciones.AppendFormat(stbErrorActual.ToString())
            End If
         End If

      Next

      If algunErrorPercepciones Then
         Return New ValidaProvinciasResult(False, stbErrorPercepciones.ToString())
      End If
      Return New ValidaProvinciasResult(True, String.Empty)
   End Function


   Private Sub GrabarComprobante()

      'Le quito el Foco al campo que lo tenga, porque podria ser uno de valor (pesos, transferencia) y que no haya dado enter.
      ProductoFocus()

      Dim conciliado As Boolean = False
      'Si tiene importe de transferencia, tiene acceso a la opción de menú de Libro de Bancos, pregunta si se desea conciliar la transferencia (si está habilitado el parámetro)
      If IsNumeric(txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(txtTransferenciaBancaria.Text) <> 0 AndAlso
         New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "LibroBancos") AndAlso
         Reglas.Publicos.CtaCteProv.PagoProvConciliaAutomaticamenteTransferencias Then
         Dim result As DialogResult = MessageBox.Show("¿Desea conciliar automáticamente la transferencia ingresada?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
         If result = Windows.Forms.DialogResult.Cancel Then
            Return
         ElseIf result = Windows.Forms.DialogResult.Yes Then
            conciliado = True
         End If
      End If

      If Me.ValidarComprobante() Then

         Me.tsbGrabar.Enabled = False

         _InformeNumero = String.Empty
         _InformeLink = String.Empty

         Dim oMovimientos = GetNewReglaMovimientoCompras()
         Dim oMov = GetNewEntidadMovimientoCompras()
         Dim oCF As Entidades.CategoriaFiscal = Nothing

         With oMov
            .Sucursal = New Reglas.Sucursales().GetUna(actual.Sucursal.Id, False)
            .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
            '.Sucursal2 = 

            .TipoMovimiento = New Reglas.TiposMovimientos().GetUnoPorComprobanteAsociado(Me.cboTipoComprobante.SelectedValue.ToString())
            .FechaMovimiento = Me.dtpFecha.Value

            .DescuentoRecargo = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

            .Compra.Comprador = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado)

            .Total = Decimal.Parse(Me.txtTotalGeneral.Text)

            .Proveedor = Me._proveedor

            .Compra.Letra = Me.cboLetra.SelectedValue.ToString
            .Compra.CentroEmisor = Short.Parse(Me.txtEmisorFactura.Text)
            .Compra.NumeroComprobante = Long.Parse(Me.txtNumeroFactura.Text)
            .Compra.TipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.cboTipoComprobante.SelectedValue.ToString())

            'EsComercial=True excluye los Tipo de SALDOINICIAL.
            If .Compra.TipoComprobante.EsComercial Or .Compra.TipoComprobante.GeneraContabilidad Then
               .Compra.IdEmpresa = actual.Sucursal.IdEmpresa
               If .Compra.TipoComprobante.GrabaLibro Then
                  .Compra.PeriodoFiscal = Integer.Parse(Me.cboPeriodoFiscal.SelectedValue.ToString())
               Else
                  .Compra.PeriodoFiscal = Integer.Parse(.FechaMovimiento.ToString("yyyyMM"))
               End If
            End If

            'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
            Dim coe As Integer = .Compra.TipoComprobante.CoeficienteValores

            '--REQ-40359.- -------------------------

            '---------------------------------------


            '------------------------------------------
            'If Not oCF.IvaDiscriminado Then
            '   .Compra.Bruto210 = Decimal.Round((.Compra.Bruto210 / (1 + (.PorcentajeIVA / 100))), 2)
            'End If

            .Compra.DescuentoRecargo = .DescuentoRecargo * coe
            .Compra.DescuentoRecargoPorc = Decimal.Parse(Me.txtPorcDescRecargoGral.Text) * coe

            .Compra.IVAModificadoManual = chbAjusteManualIVA.Checked

            .Compra.PorcentajeIVA = .PorcentajeIVA * coe
            .Compra.ImporteTotal = .Total * coe
            '-------------------------------------------

            .Compra.Fecha = Me.dtpFecha.Value
            .Compra.FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(Me.cboFormaPago.SelectedValue.ToString()))
            .Compra.Observacion = Me.bscObservacion.Text
            'TODO: Analizar
            .Compra.PorcentajeIVA = 21    'Decimal.Parse(Me.lblPorcentaje.Text)
            .Compra.FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(Me.cboFormaPago.SelectedValue.ToString()))
            .Compra.IdSucursal = .Sucursal.Id
            .Compra.Rubro = New Reglas.RubrosCompras().GetUno(Integer.Parse(Me.cboRubro.SelectedValue.ToString()))

            .Compra.PercepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text) * coe
            .Compra.PercepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text) * coe
            .Compra.PercepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text) * coe
            .Compra.PercepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text) * coe
            .Compra.ImpuestosInternos = Decimal.Parse(Me.txtImpuestosInternos.Text) * coe


            If .Compra.TipoComprobante.AfectaCaja Then
               'controlo el pago que se realiza si no va a la cuenta corriente
               If .Compra.FormaPago.Dias = 0 Then
                  If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
                     If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                        If Not Reglas.Publicos.ComprasContadoEsEnPesos AndAlso MessageBox.Show("El pago se realizara totalmente en pesos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                           Me.tbpPagosEfectivo.Focus()
                           Me.txtEfectivo.Focus()
                           Exit Sub
                        Else
                           If .Compra.FormaPago.IdCuentaBancariaEfectivo IsNot Nothing And .Compra.FormaPago.RequiereTransferencia Then
                              If .Compra.FormaPago.CountRequiere = 1 Then
                                 Dim CtaBancaria As Entidades.CuentaBancaria = New Reglas.CuentasBancarias().GetUna(Integer.Parse(.Compra.FormaPago.IdCuentaBancariaEfectivo.ToString()))
                                 Me.txtTransferenciaBancaria.Text = Me.txtTotalGeneral.Text
                                 Me.bscCuentaBancariaTransfBanc.Text = CtaBancaria.NombreCuenta.ToString()
                                 Me.bscCuentaBancariaTransfBanc.PresionarBoton()
                              Else
                                 Dim fPago = cboFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)
                                 Dim medio = "pesos"
                                 Dim ctaBancaria = New Reglas.CuentasBancarias().GetUna(fPago.IdCuentaBancariaEfectivo.IfNull(-1), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
                                 If fPago.IdCuentaBancariaEfectivo.HasValue Then
                                    medio = String.Format("transferencia a la cuenta {0}", ctaBancaria.NombreCuenta)
                                 End If

                                 txtTransferenciaBancaria.Text = txtTotalGeneral.Text
                                 bscCodigoCuentaBancariaTransfBanc.Text = fPago.IdCuentaBancariaEfectivo.Value.ToString()
                                 bscCodigoCuentaBancariaTransfBanc.Visible = True
                                 bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
                                 bscCodigoCuentaBancariaTransfBanc.Visible = False


                                 Me.tbcDetalle.SelectedTab = tbpPagosEfectivo
                                 Me.txtEfectivo.Focus()
                                 Throw New Exception("Debe seleccionar medio de Pago.")
                              End If
                           Else
                              Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
                           End If
                        End If
                     End If
                  Else
                     'si puso algo en pagos, se debe controlar que la diferencia este en cero
                     If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                        Me.tbpPagosEfectivo.Focus()
                        Me.txtEfectivo.Focus()
                        Throw New Exception("El pago debe ser igual al total del comprobante.")
                     End If
                  End If
               End If
            Else
               Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
            End If

            .Compra.ChequesPropios = Me._chequesPropios
            .Compra.ChequesTerceros = Me._chequesTerceros

            .Compra.ImportePesos = Decimal.Parse(Me.txtEfectivo.Text) * coe
            .Compra.ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text) * coe
            '.Compra.ImporteCheques = (Decimal.Parse(Me.txtChequesPropios.Text) + Decimal.Parse(Me.txtChequesTerceros.Text)) * coe

            'Dim rTarjetasCupones = New Reglas.TarjetasCupones()
            Dim rComprasTarjetas = New Reglas.ComprasTarjetas()
            .Compra.CuponesTarjetasLiquidacion = rComprasTarjetas.GetTodosPantallaSeleccion(ugCuponesTarjetas.DataSource(Of DataTable))

            'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Me.bscCuentaBancariaTransfBanc.Selecciono Then
            '   .Compra.ImporteTransfBancaria = Decimal.Parse(Me.txtTransferenciaBancaria.Text) * coe
            '   .Compra.CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
            '   .Compra.Conciliado = conciliado
            'End If

            If txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) > 0 And bscCuentaBancariaTransfBanc.Selecciono Then
               .Compra.ImporteTransfBancaria = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)
               .Compra.CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(bscCuentaBancariaTransfBanc.Tag.ToString())) ''._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
               ' .FechaTransferencia = Me.dtpFechaTransferencia.Value
            End If

            .Compra.Transferencias = _transferencias

            'cargo las Observaciones
            .Compra.ComprasObservaciones = Me._comprasObservaciones

            'cargo cotizacion dolar
            .Compra.CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text)

            .PercepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
            .PercepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
            .PercepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
            .PercepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)
            .ImpuestosInternos = Decimal.Parse(Me.txtImpuestosInternos.Text)
            '.Compra.ComprasImpuestos.Clear()

            .Compra.ConceptoCM05 = If(chbAFIPConceptoCM05.Checked, cmbAFIPConceptoCM05.ItemSeleccionado(Of Entidades.AFIPConceptoCM05)(), Nothing)

            .Compra.ComprasImpuestos = New List(Of Entidades.CompraImpuesto)()

            For Each ci As Entidades.CompraImpuesto In _comprasImpuestos
               .Compra.ComprasImpuestos.Add(ci)
            Next

            For Each drProvincias As DataRow In _dtProvincias.Rows
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               With ci
                  .IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIIBB.ToString()
                  .TipoTipoImpuesto = "PERCEPCION"
                  .IdProvincia = drProvincias("IdProvincia").ToString()
                  .NombreProvincia = drProvincias("NombreProvincia").ToString()
                  '.Emisor = Integer.Parse(drProvincias("Emisor").ToString())
                  '.Numero = Long.Parse(drProvincias("Numero").ToString())
                  .BaseImponible = Decimal.Parse(drProvincias("BaseImponible").ToString())
                  .Alicuota = Decimal.Parse(drProvincias("Alicuota").ToString())
                  .Importe = Decimal.Parse(drProvincias("Importe").ToString())
               End With
               .Compra.ComprasImpuestos.Add(ci)
            Next

            If .PercepcionGanancias <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PGANA.ToString()
               ci.TipoTipoImpuesto = "PERCEPCION"
               ci.Importe = .PercepcionGanancias
               .Compra.ComprasImpuestos.Add(ci)
            End If
            If .PercepcionIVA <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA.ToString()
               ci.TipoTipoImpuesto = "PERCEPCION"
               ci.Importe = .PercepcionIVA
               .Compra.ComprasImpuestos.Add(ci)
            End If
            If .PercepcionVarias <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PVAR.ToString()
               ci.TipoTipoImpuesto = "PERCEPCION"
               ci.Importe = .PercepcionVarias
               .Compra.ComprasImpuestos.Add(ci)
            End If

            If .ImpuestosInternos <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT.ToString()
               ci.TipoTipoImpuesto = "PERCEPCION"
               ci.Importe = .ImpuestosInternos
               .Compra.ComprasImpuestos.Add(ci)
            End If

            If .Compra.TipoComprobante.EsDespachoImportacion Then
               For Each cid As Entidades.CompraImpuesto In _comprasImpuestosDespachoImportacion
                  Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
                  ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
                  ci.TipoTipoImpuesto = "PERCEPCION"
                  ci.BaseImponible = cid.BaseImponible
                  ci.Alicuota = cid.Alicuota
                  ci.Importe = cid.Importe
                  ci.EsDespacho = True
                  .Compra.ComprasImpuestos.Add(ci)
               Next

               .Compra.FechaOficializacionDespacho = dtpFechaOficializacion.Value
               .Compra.IdAduana = Integer.Parse(bscCodigoAduana.Text.ToString())
               .Compra.IdDestinacion = bscCodigoDestinacion.Text.ToString()

               .Compra.NumeroDespacho = Long.Parse(txtNumeroDespacho.Text)
               .Compra.DigitoVerificadorDespacho = txtDigitoVerificador.Text
               .Compra.NumeroManifiestoDespacho = txtNumeroManifiesto.Text

               .Compra.IdDespachante = Integer.Parse(bscCodigoDespachante.Text.ToString())
               .Compra.IdAgenteTransporte = Integer.Parse(bscCodigoAgenteTransporte.Text.ToString())

               .Compra.DerechoAduanero = Decimal.Parse(txtDerechoAduana.Text)
               .Compra.BienCapitalDespacho = chbBienCapital.Checked
            End If

            Dim clteVinc As Entidades.Cliente = Nothing
            If _proveedor.IdClienteVinculado.HasValue Then
               clteVinc = New Reglas.Clientes()._GetUno(_proveedor.IdClienteVinculado.Value)
            End If

            .Compra.Retenciones.Clear()
            If txtTotalRetenciones.ValorNumericoPorDefecto(0D) <> 0 Then
               If clteVinc Is Nothing Then
                  Throw New Exception("El Proveedor seleccionado no tiene configurado un Cliente Vinculado. No es posible registrar retenciones.")
               End If
               Dim rCompraReten = New Reglas.ComprasRetenciones()
               .Compra.Retenciones = rCompraReten.CreaRetenciones(clteVinc, txtRetencionIVA.ValorNumericoPorDefecto(0D), _dtProvinciasRetenciones, txtRetencionGanancias.ValorNumericoPorDefecto(0D))
            End If

            .Comentarios = bscObservacion.Text.Trim()
            .Observacion = bscObservacion.Text

            If Not .Compra.TipoComprobante.EsRemitoTransportista Then
               .Productos = Me._productos
            Else
               .Productos = Me._productosRT

               If IsNumeric(txtNumeroLote.Text) Then
                  .Compra.NumeroLote = Long.Parse(txtNumeroLote.Text)
               End If
               If IsNumeric(txtValorDeclarado.Text) Then
                  .Compra.ValorDeclarado = Decimal.Parse(txtValorDeclarado.Text)
               End If
               If IsNumeric(txtBultos.Text) Then
                  .Compra.Bultos = Integer.Parse(txtBultos.Text)
               End If

               .Compra.Transportista = _transportistaA

            End If

            '# Valido que de los productos ingresados, en caso de utilizar Lote, se hayan seleccionado.
            For Each p In .Productos
               If p.ProductoSucursal.Producto.Lote Then

                  '# Si no hay registros dentro de Productos Lotes es porque no se seleccionó/seleccionaron los lotes.
                  If _productosLotes.Count = 0 Then
                     Throw New Exception("No se seleccionó Lote para los productos")
                  End If

                  '# Si hay registros, busco puntualmente si se agregaron los lotes de los productos ingresados
                  For Each pLote As Entidades.ProductoLote In _productosLotes
                     If _productosLotes.Any(Function(x) x.ProductoSucursal.Producto.IdProducto.Equals(p.IdProducto) And p.IdLote = Nothing) Then
                        Throw New Exception(String.Format("ATENCIÓN: No se seleccionó Lote para el producto {0} de la linea {1}.",
                                            p.ProductoSucursal.Producto.NombreProducto,
                                            p.Orden))
                     End If
                  Next
               End If
            Next

            .ProductosLotes = Me._productosLotes
            .ProductosNrosSerie = Me._productosNrosSeries
            .Usuario = actual.Nombre


            'cargo los cheques emitidos (propios)
            .Compra.CuentaCorrienteProv.ChequesPropios = Me._chequesPropios

            'cargo los cheques de terceros
            .Compra.CuentaCorrienteProv.ChequesTerceros = Me._chequesTerceros

            'Cargo los Comprobantes Facturados (tal vez ninguno)
            .Compra.Facturables = Me._comprobantesSeleccionados

            'Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !
            If Me._comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 AndAlso .Compra.TipoComprobante.CoeficienteStock <> 0 Then
               .Compra.IdEstadoComprobante = "INVOCO"
               .Compra.CantidadInvocados = Me._comprobantesSeleccionados.Count
            Else
               .Compra.CantidadInvocados = 0
            End If

            .Compra.Usuario = actual.Nombre
            .Compra.FechaActualizacion = Date.Now()

            If Not Me._proveedor.EsProveedorGenerico Then
               .Compra.IdcategoriaFiscal = Me._proveedor.CategoriaFiscal.IdCategoriaFiscal
               .Compra.NombreProveedor = Me.bscProveedor2.Text
            Else
               .Compra.IdcategoriaFiscal = Integer.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString())
               .Compra.NombreProveedor = Me.txtNombreProveedorGenerico.Text
            End If
            .Compra.CuitProveedor = Me.txtCUIT.Text

            '# En principio todas las compras van incluidas
            .Compra.ExcluirDePasaje = False

            '-.PE-31849.-
            .Compra.MercEnviada = Me.chbMercaderiaEnviada.Checked

            If IsNumeric(Me.bscNroOrdenDeCompra.Text) Then
               .Compra.NumeroOrdenCompra = Long.Parse(Me.bscNroOrdenDeCompra.Text.ToString())
            End If
         End With


         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If oMov.Compra.TipoComprobante.ActualizaCtaCte Then
            If oMov.Compra.FormaPago.Dias > 0 Then
               'si el cliente compro el modulo de cuenta corriente
               If Reglas.Publicos.TieneModuloCuentaCorrienteProveedores Then

                  If Not Reglas.Publicos.CtaCteProv.UtilizaCuotasVencimientoCtaCteProveedores Then

                     If MessageBox.Show("Confirma enviar el Comprobante a Cuenta Corriente?", Me.Text, MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then
                        Me.tsbGrabar.Enabled = True
                        Exit Sub
                     End If

                     Dim oCCP As Entidades.CuentaCorrienteProvPago
                     oCCP = New Entidades.CuentaCorrienteProvPago()
                     oCCP.ImporteCuota = Decimal.Parse(Me.txtTotalGeneral.Text)
                     oCCP.SaldoCuota = oCCP.ImporteCuota
                     oCCP.FechaVencimiento = Me.dtpFecha.Value.AddDays(oMov.Compra.FormaPago.Dias)
                     oMov.Compra.CuentaCorrienteProv.Pagos.Add(oCCP)

                  Else

                     Dim cc As CuentaCorrienteProveedorV2 = New CuentaCorrienteProveedorV2(Me.dtpFecha.Value, Decimal.Parse(Me.txtTotalGeneral.Text), oMov.Compra.FormaPago.IdFormasPago)
                     If cc.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        'recuperar los datos para armar la cuenta corriente
                        Dim oCCP As Entidades.CuentaCorrienteProvPago
                        For Each dr As DataRow In cc.Pagos.Rows
                           oCCP = New Entidades.CuentaCorrienteProvPago()
                           oCCP.ImporteCuota = Decimal.Parse(dr("MontoAPagar").ToString())
                           oCCP.SaldoCuota = oCCP.ImporteCuota
                           oCCP.FechaVencimiento = DateTime.Parse(dr("FechaAPagar").ToString())
                           oMov.Compra.CuentaCorrienteProv.Pagos.Add(oCCP)
                        Next
                     Else
                        Me.tsbGrabar.Enabled = True
                        Throw New Exception("Debe ingresar la forma de pago para poder grabar e imprimir.")
                     End If

                  End If

               End If
            End If

         End If

#Region "Comentado"

         'SE ANULA PORQUE LA REGLA LO VA A VOLVER A SOLICITAR. CUANDO SE DE CURSO A ESTO, SE VE DE REIMPLEMENTAR.
         ' '' '' '' ''vml 29/09/12  - contabilidad
         '' '' '' ''If Publicos.ContabilidadEjecutarEnLinea Then

         '' '' '' ''   'Dim tablaContabilidad As DataTable
         '' '' '' ''   Dim oProcesoContable As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos()
         '' '' '' ''   Dim idplanCuenta As Integer = oProcesoContable.getPlanCtaxDoc(oMov.Compra.TipoComprobante.IdTipoComprobante)
         '' '' '' ''   Dim cantRubros As Integer = obtenerCantidadGrupos(oMov)

         '' '' '' ''   ' determino si muestro la pantalla de asientos o grabo automaticamente.
         '' '' '' ''   If cantRubros = 0 Then
         '' '' '' ''      Throw New Exception("El Producto no posee un rubro asociado. Debe cargar el rubro antes de procesar la compra")
         '' '' '' ''   End If

         '' '' '' ''   If cantRubros = 1 Then ' grabo automaticamente

         '' '' '' ''      oMov.tablaContabilidad = oProcesoContable.GetRubroCompra(oMov, idplanCuenta)

         '' '' '' ''      'ANULADO TEMPORALMENTE HASTA QUE REAVIVEMOS LA FUNCIONALIDAD
         '' '' '' ''      ''If oMov.tablaContabilidad.Rows.Count > 3 Then ' hay varias cuentas para imputar precio, muestro pantalla

         '' '' '' ''      ''   Dim dtRubrosCompra As DataTable
         '' '' '' ''      ''   dtRubrosCompra = oProcesoContable.GetRubroCompra(oMov, idplanCuenta, False)
         '' '' '' ''      ''   oMov.grabaAutomatico = False
         '' '' '' ''      ''   oMov.esMultipleRubro = True
         '' '' '' ''      ''   oMov.tablaContabilidad = ArmarTablaMultiplesRubros(oMov, dtRubrosCompra, dgvProductos)

         '' '' '' ''      ''   If oMov.tablaContabilidad.Rows.Count > 3 Then ' hay varias cuentas para imputar precio, muestro pantalla
         '' '' '' ''      ''      Dim frm As New ContabilidadAsientoInterno
         '' '' '' ''      ''      frm.origen = "COMPRAS"
         '' '' '' ''      ''      frm.frmPadre = Me
         '' '' '' ''      ''      frm.dtGrilla = dtRubrosCompra
         '' '' '' ''      ''      frm.concepto = GetDscAsiento(oMov)

         '' '' '' ''      ''      If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '' '' '' ''      ''         oMov.tablaContabilidad = Me.tablaAsientos
         '' '' '' ''      ''      Else

         '' '' '' ''      ''         Throw New Exception("No se puede ingresar la Compra. Ha cancelado la grabación del asiento contable")

         '' '' '' ''      ''      End If

         '' '' '' ''      ''   End If
         '' '' '' ''      ''End If

         '' '' '' ''   Else ' hay mas de un tipo de grupos de cuentas, abro pantalla para que elija.


         '' '' '' ''      Dim dtRubrosCompra As DataTable
         '' '' '' ''      dtRubrosCompra = oProcesoContable.GetRubroCompra(oMov, idplanCuenta)
         '' '' '' ''      oMov.tablaContabilidad = dtRubrosCompra '' ArmarTablaMultiplesRubros(oMov, dtRubrosCompra, dgvProductos)

         '' '' '' ''      'ANULADO TEMPORALMENTE HASTA QUE REAVIVEMOS LA FUNCIONALIDAD
         '' '' '' ''      ''If oMov.tablaContabilidad.Rows.Count > 6 Then ' hay varias cuentas para imputar precio, muestro pantalla
         '' '' '' ''      ''   Dim frm As New ContabilidadAsientoInterno
         '' '' '' ''      ''   frm.origen = "COMPRAS"
         '' '' '' ''      ''   frm.frmPadre = Me
         '' '' '' ''      ''   frm.dtGrilla = dtRubrosCompra
         '' '' '' ''      ''   frm.concepto = GetDscAsiento(oMov)

         '' '' '' ''      ''   If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '' '' '' ''      ''      oMov.tablaContabilidad = Me.tablaAsientos
         '' '' '' ''      ''   Else

         '' '' '' ''      ''      Throw New Exception("No se puede ingresar la Compra. Ha cancelado la grabación del asiento contable")

         '' '' '' ''      ''   End If

         '' '' '' ''      ''End If

         '' '' '' ''   End If

         '' '' '' ''End If

#End Region

         Me.Insertar(oMovimientos, oMov)
         ''oMovimientos.Insertar(oMov)

         MessageBox.Show("El Movimiento se ingresó con éxito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         'distribuir el descuento gral en todos los productos
         If oMov.Compra.DescuentoRecargoPorc <> 0 Then
            For Each dr As Entidades.MovimientoStockProducto In oMov.Productos
               dr.PrecioCostoNuevo = (dr.PrecioCostoNuevo * oMov.Compra.DescuentoRecargoPorc) / 100 + dr.PrecioCostoNuevo
               Dim porcentaje As Decimal = 0

               If dr.PrecioCostoO > 0 Then
                  porcentaje = Decimal.Round(dr.PrecioVentaActual / dr.PrecioCostoO, Me._decimalesRedondeoEnPrecio)
               End If
               dr.PrecioVentaNuevo = Decimal.Round(dr.PrecioCostoNuevo * porcentaje, Me._decimalesRedondeoEnPrecio)
            Next
         End If

         'Actualizo los precios de Compra y Venta
         If oMov.TipoMovimiento.CoeficienteStock > 0 And _ActualizaCostoYPrecioVenta Then

            Using frm As New ActualizarPreciosV2()
               frm.IdFuncion = Me.IdFuncion
               'frm.ShowDialog(Me._productos, oMov.Compra.Proveedor.CategoriaFiscal)
               frm.ShowDialog(Me, oMov)
            End Using


            'Dim Precios As Entidades.MovimientoCompra = New Entidades.MovimientoCompra()

            'For Each dr As Entidades.MovimientoCompraProducto In oMov.Productos
            '   If dr.PrecioCostoO <> dr.PrecioCostoNuevo Then
            '      Precios.Productos.Add(dr)
            '   End If
            'Next

            'If Precios.Productos.Count <> 0 Then
            '   Using prec As ActualizarPreciosCompras = New ActualizarPreciosCompras(Precios)
            '      prec.ShowDialog()
            '   End Using
            'End If

         End If


         If Publicos.VisualizaComprobantesDeCompra Or oMov.Compra.TipoComprobante.Imprime Then

            'Vuelvo a leer la compra para que cargue el campo ORDEN del detalle, 
            'sino da error en caso de repetir el produccto
            Dim oCompras As Reglas.Compras = New Reglas.Compras()

            Dim Compra As Entidades.Compra = oCompras.GetUna(actual.Sucursal.Id,
                        oMov.Compra.TipoComprobante.IdTipoComprobante,
                        oMov.Compra.Letra,
                        oMov.Compra.CentroEmisor,
                        oMov.Compra.NumeroComprobante,
                        oMov.Compra.Proveedor.IdProveedor)

            Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

            oImpr.ImprimirComprobante(Publicos.VisualizaComprobantesDeCompra, Me._decimalesAMostrarEnTotalXProducto)

         End If

         Me.Nuevo()

      End If

   End Sub

   Protected Overridable Function GetNewReglaMovimientoCompras() As Reglas.MovimientosStock
      Return New Reglas.MovimientosStock()
   End Function

   Protected Overridable Function GetNewEntidadMovimientoCompras() As Entidades.MovimientoStock
      Return New Entidades.MovimientoStock()
   End Function

   Protected Overridable Sub Insertar(oMovimientos As Reglas.MovimientosStock, oMov As Entidades.MovimientoStock)
      Dim _dt As DataTable = Nothing
      Try
         'PE-35257 / Terminar de copiar la funcionalidad desde el SISEN
         If Reglas.Publicos.TieneModuloExpensas Then
            If Reglas.Publicos.ExpensasRegistraComprasPor = Reglas.Publicos.ExpensasRegistraComprasPorEnum.AreaComun.ToString() Then
               _dt = New DataTable()

               _dt.Columns.Add(Entidades.AreaComun.Columnas.IdAreaComun.ToString(), GetType(String))
               _dt.Columns.Add(Entidades.AreaComun.Columnas.NombreAreaComun.ToString(), GetType(String))
               _dt.Columns.Add("importe", GetType(Decimal))

               Dim total As Decimal = oMov.Total
               If Not Reglas.Publicos.PasajeComprasIncluyeImpuestos Then
                  total = oMov.Compra.TotalNeto ' oMov.Neto105 + oMov.Neto210 + oMov.Neto270 + oMov.NetoNoGravado
               End If
               Using frm = New MovimientosDeCompraExpensas(total, _dt)
                  If frm.ShowDialog(Me) = Windows.Forms.DialogResult.No Then
                     Throw New Exception("No se puede ingresar la Compra. Ha cancelado la distribución de expensas")
                  End If
               End Using
            ElseIf Reglas.Publicos.ExpensasRegistraComprasPor = Reglas.Publicos.ExpensasRegistraComprasPorEnum.GrupoCama.ToString() Then
               _dt = New DataTable()

               _dt.Columns.Add(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString(), GetType(Integer))
               _dt.Columns.Add(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString(), GetType(String))
               _dt.Columns.Add("importe", GetType(Decimal))

               Dim total As Decimal = oMov.Total
               If Not Reglas.Publicos.PasajeComprasIncluyeImpuestos Then
                  total = oMov.Compra.TotalNeto 'oMov.Neto105 + oMov.Neto210 + oMov.Neto270 + oMov.NetoNoGravado
               End If
               Using frm = New MovimientosDeCompraPorGrupo(total, _dt)
                  If frm.ShowDialog(Me) = Windows.Forms.DialogResult.No Then
                     Throw New Exception("No se puede ingresar la Compra. Ha cancelado la distribución de expensas")
                  End If
               End Using
            Else
               'Reglas.Publicos.ExpensasRegistraComprasPor = Reglas.Publicos.ExpensasRegistraComprasPorEnum.NoAplica.ToString()
               'Casos en los que no aplica la solicitud de distribución de compras
            End If
         End If



         oMovimientos.Insertar(oMov, _dt, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
      Finally
         If _dt IsNot Nothing Then _dt.Dispose()
      End Try
   End Sub

   Private Function ArmarTablaMultiplesRubros(omov As Entidades.MovimientoStock _
                                          , rubrosCompra As DataTable _
                                          , grillaPantalla As DataGridView) As DataTable

      For Each filarubro As DataRow In rubrosCompra.Rows
         For Each prod In omov.Productos
            'prod.ProductoSucursal.Producto.IdProducto.ToString
            If filarubro("idProducto").ToString = prod.IdProducto.ToString Then
               Select Case filarubro("campo").ToString

                  Case ContabilidadPublicos.ConstantesCompra.IvaCompra ' "Iva Compra"
                     If CBool(filarubro("debe")) Then 'debe
                        filarubro("debeValor") = prod.IVA
                     Else 'haber
                        filarubro("haberValor") = prod.IVA
                     End If
                  Case ContabilidadPublicos.ConstantesCompra.ImporteTotalCompra '"Imp Total"
                     If CBool(filarubro("debe")) Then 'debe
                        filarubro("debeValor") = prod.TotalProducto ' totalProducto?
                     Else 'haber
                        filarubro("haberValor") = prod.TotalProducto
                     End If
                  Case ContabilidadPublicos.ConstantesCompra.SubTotal '"Sub Total"
                     If CBool(filarubro("debe")) Then 'debe
                        filarubro("debeValor") = prod.ImporteTotal ' prod.Precio - prod.IVA
                     Else 'haber
                        filarubro("haberValor") = prod.ImporteTotal ' prod.Precio - prod.IVA
                     End If
               End Select
            End If
         Next
      Next

      Return rubrosCompra

   End Function

   Private Function GetDscAsiento(omov As Entidades.MovimientoStock) As String
      Return omov.IdSucursal.ToString & "-" & omov.Compra.TipoComprobante.IdTipoComprobante.ToString & "-" & omov.Compra.Letra.ToString & "-" & omov.Compra.CentroEmisor.ToString & "-" & omov.Compra.NumeroComprobante.ToString & "-" & omov.Compra.Fecha.ToString
   End Function

   Private Function obtenerCantidadGrupos(omov As Entidades.MovimientoStock) As Integer
      Dim oProcesoContable As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos()

      Dim idplanCuenta As Integer = oProcesoContable.getPlanCtaxDoc(omov.Compra.TipoComprobante.IdTipoComprobante)
      Return oProcesoContable.GetCantRubrosCompra(omov, idplanCuenta)

   End Function

   Private Sub SetProductosDataSource()
      dgvProductos.DataSource = _productos.ToArray().OrderBy(Function(x) x.Orden).ToArray()
      AjustarColumnasGrillaProductos()
      EvaluaMuestraCantidadUMC()
   End Sub
   Private Sub SetProductosRTDataSource()
      dgvRemitoTransp.DataSource = _productosRT.ToArray()
      AjustarColumnasGrilla(dgvRemitoTransp, _titRemitoTransporte)
      EvaluaMuestraCantidadUMCompraRT()
      DisplayIndexProductoRT()
   End Sub

   Private Sub SeteaDetalleProducto()
      Me._productos = New System.Collections.Generic.List(Of Entidades.MovimientoStockProducto)
   End Sub

   Private Sub CalcularTotalProducto()
      If Me.txtCantidad.Text = "-" Then
         Me.txtCantidad.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      End If
      If Me.txtDescuentoRecargo.Text = "" Or Me.txtDescuentoRecargo.Text = "-" Then
         Me.txtDescuentoRecargo.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      End If
      Me.txtTotalProducto.Text = ((Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtCantidad.Text)) + Decimal.Parse(Me.txtDescuentoRecargo.Text)).ToString("#,##0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto))
   End Sub

   Private Sub LimpiarCamposProductos()

      _ordenProducto = 0

      Me.bscCodigoProducto2.Enabled = True
      Me.bscCodigoProducto2.Text = ""
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.Enabled = True
      Me.bscProducto2.Text = ""
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtStock.Text = "0"
      Me.txtStock.Tag = False
      Me.txtCantidad.Text = "0." + New String("0"c, Me._decimalesMostrarEnCantidad)
      Me.txtDescuentoRecargoPorc.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtDescuentoRecargo.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.cmbPorcentajeIVA.Enabled = True
      Me.cmbPorcentajeIVA.SelectedIndex = -1
      Me.txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto)
      Me.txtLote.Clear()
      chbConcepto.Checked = False

      '--REQ-35487.- -------------------------
      txtAtributo01.Text = String.Empty
      txtAtributo02.Text = String.Empty
      '---------------------------------------

      'Me.cmbConceptos.Enabled = False
      'Me.cmbConceptos.SelectedIndex = -1
      Me.dtpFechaActPrecios.Value = Date.Today()
      Me.txtPrecioLista.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtDescuento1.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtDescuento2.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtDescuento3.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtDescuento4.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtPrecioLista.ReadOnly = True
      Me.txtDescuento1.ReadOnly = True
      Me.txtDescuento2.ReadOnly = True
      Me.txtDescuento3.ReadOnly = True
      Me.txtDescuento4.ReadOnly = True
      Me.txtProductoObservacion.Text = String.Empty
      Me.txtProductoObservacion.Visible = False
      Me.cmbCentroCosto.SelectedIndex = -1
      bscProducto2.Visible = True
      grpPrecioDolares.Visible = False

      txtCantidadUMCompra.SetValor(0)
      txtCantidadUMCompra.Tag = 0D
      txtPrecioPorUMCompra.SetValor(0)
      txtUnidadesCompras.SetValor(0)

      pnlCantidadUMCompra.Visible = False
      pnlPrecioPorUMCompra.Visible = False
      pnlUnidadesCompras.Visible = False

   End Sub

   Private Sub ReCalculaImpuestos()
      _comprasImpuestos.Clear()
      ReCalculaImpuestos(Me._productos)
      ReCalculaImpuestos(Me._productosRT)

   End Sub
   Private Sub ReCalculaImpuestos(productos As List(Of Entidades.MovimientoStockProducto))

      Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()

      For Each pro In productos

         ci = _comprasImpuestos.FirstOrDefault(Function(x) x.Alicuota = pro.PorcentajeIVA And
                                                           x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString())

         If ci Is Nothing Then
            ci = New Entidades.CompraImpuesto() With {.Alicuota = pro.PorcentajeIVA,
                                                      .IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString(),
                                                      .TipoTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString(),
                                                      .NombreTipoImpuesto = _eTipoImpuestoIVA.NombreTipoImpuesto}
            _comprasImpuestos.Add(ci)
         End If

         ci.Bruto += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         ci.BaseImponible += Math.Round(pro.ImporteTotal + pro.DescRecGeneral, Me._decimalesRedondeoEnPrecio)
         ci.Importe += Math.Round(pro.IVA, Me._decimalesRedondeoEnPrecio)
         ci.Importe_Calculado += Math.Round(pro.IVA, Me._decimalesRedondeoEnPrecio)
      Next
      'UltraGrid1.DataSource = _comprasImpuestos.ToArray()
   End Sub

   Private Sub CalcularTotales()
      If Not chbAjusteManualIVA.Checked Then
         ReCalculaImpuestos()
      End If

      'Const formato As String = "#,##0." + New String("0"c, Me._decimalesAMostrar)

      Dim porcentajeDescuentoRecargo As Decimal = 0

      'brutos
      Dim brutoTotal As Decimal = 0

      ''netos
      Dim netoTotal As Decimal = 0

      ''ivas
      Dim ivaTotal As Decimal = 0

      'percepciones
      Dim percepcionIVA As Decimal = 0
      Dim percepcionIB As Decimal = 0
      Dim percepcionGanancias As Decimal = 0
      Dim percepcionVarias As Decimal = 0
      Dim impuestosInternos As Decimal = 0
      Dim percepcionTotal As Decimal = 0

      If Not Me.chbSinProductos.Checked Then
         'For Each pro As Entidades.MovimientoCompraProducto In Me._productos
         '   Select Case pro.PorcentajeIVA
         '      Case valorIVA210
         '         bruto210 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         '      Case valorIVA105
         '         bruto105 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         '      Case valorIVA270
         '         bruto270 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         '      Case valorNoGravado
         '         brutoNoGravado += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         '   End Select
         'Next

         'For Each pro As Entidades.MovimientoCompraProducto In Me._productosRT
         '   Select Case pro.PorcentajeIVA
         '      Case valorIVA210
         '         bruto210 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         '      Case valorIVA105
         '         bruto105 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         '      Case valorIVA270
         '         bruto270 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         '      Case valorNoGravado
         '         brutoNoGravado += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
         '   End Select
         'Next

         'Me.txtBruto210.Text = bruto210.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
         'Me.txtBruto105.Text = bruto105.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
         'Me.txtBruto270.Text = bruto270.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
         'Me.txtBrutoNoGravado.Text = brutoNoGravado.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

         Me.tsbGrabar.Enabled = (Me._productos.Count > 0 Or _productosRT.Count > 0)

      Else
         'bruto210 = Decimal.Parse(Me.txtBruto210.Text)
         'bruto105 = Decimal.Parse(Me.txtBruto105.Text)
         'bruto270 = Decimal.Parse(Me.txtBruto270.Text)
         'brutoNoGravado = Decimal.Parse(Me.txtBrutoNoGravado.Text)

         Me.tsbGrabar.Enabled = True

      End If

      'Me.txtBrutoTotal.Text = (bruto210 + bruto105 + bruto270 + brutoNoGravado).ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      'cargo el descuento/recargo
      porcentajeDescuentoRecargo = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

      For Each ci As Entidades.CompraImpuesto In _comprasImpuestos
         ivaTotal += ci.Importe
         netoTotal += ci.BaseImponible
         brutoTotal += ci.Bruto
      Next

      For Each vi As Entidades.CompraImpuesto In _comprasImpuestosDespachoImportacion
         ivaTotal += vi.Importe
      Next

      'suma las percepciones
      percepcionIVA = txtPercepcionIVA.ValorNumericoPorDefecto(0D)
      percepcionIB = txtPercepcionIIBB.ValorNumericoPorDefecto(0D)
      percepcionGanancias = txtPercepcionGanancias.ValorNumericoPorDefecto(0D)
      percepcionVarias = txtPercepcionVarias.ValorNumericoPorDefecto(0D)
      impuestosInternos = txtImpuestosInternos.ValorNumericoPorDefecto(0D)

      percepcionTotal = percepcionIVA + percepcionIB + percepcionGanancias + percepcionVarias
      Dim retencionTotal = txtRetencionIVA.ValorNumericoPorDefecto(0D) + txtRetencionIIBB.ValorNumericoPorDefecto(0D) + txtRetencionGanancias.ValorNumericoPorDefecto(0D)

      txtPercepcionTotal.SetValor(percepcionTotal)
      txtRetencionTotal.SetValor(retencionTotal)
      txtTotalImpuestosInternos.Text = impuestosInternos.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      'sacar totales
      txtTotalBruto.Text = brutoTotal.ToString("N2")     '"pepe" 'Me.txtBrutoTotal.Text
      txtTotalNeto.Text = netoTotal.ToString("N2")
      txtDescRecGral.Text = (brutoTotal - netoTotal).ToString("N2")
      txtTotalIVA.Text = ivaTotal.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales)) ''Me.txtIVATotal.Text
      txtTotalPercepciones.Text = percepcionTotal.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
      txtTotalRetenciones.SetValor(retencionTotal)

      txtTotalGeneral.Text = (netoTotal + ivaTotal + percepcionTotal + impuestosInternos + retencionTotal).ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
      txtTotalGeneralCabecera.Text = txtTotalGeneral.Text

      CalcularDiferenciaDePago()

   End Sub

   Private Sub Nuevo()

      _comprasImpuestosDespachoImportacion = New List(Of Entidades.CompraImpuesto)()
      ugImpuestosDespacho.DataSource = _comprasImpuestosDespachoImportacion
      AjustarColumnasGrilla()

      Me.tsbGrabar.Enabled = False

      Me._estado = Estados.Insercion

      Me._proveedor = Nothing

      Me.cboLetra.SelectedIndex = -1

      Me.cboTipoComprobante.Enabled = True
      If Me.cboTipoComprobante.Items.Count > 0 Then
         Me.cboTipoComprobante.SelectedIndex = 0   '-1
      End If

      Me.txtEmisorFactura.Text = ""
      Me.txtNumeroFactura.Text = ""

      Me.bscCodigoProveedor2.Permitido = True
      Me.bscCodigoProveedor2.Text = String.Empty
      Me.bscCodigoProveedor2.Tag = Nothing
      Me.bscCodigoProveedor2.FilaDevuelta = Nothing

      Me.bscProveedor2.Permitido = True
      Me.bscProveedor2.Text = String.Empty
      Me.bscProveedor2.FilaDevuelta = Nothing

      Me.chbProductosDelProveedor.Checked = False

      Me.txtCategoriaFiscal.Text = String.Empty

      Me.bscObservacion.Text = String.Empty
      Me.bscCuentaBancariaTransfBanc.Text = String.Empty

      Me.dtpFecha.Value = Date.Now
      Me.cboPeriodoFiscal.SelectedIndex = 0

      Me.cboFormaPago.SelectedIndex = 0   '-1
      Me.cboRubro.SelectedIndex = 0       '-1

      Me.txtTotalBruto.Enabled = True
      Me.txtTotalBruto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      'Me.txtNetoAl210.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTotalNeto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTotalIVA.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPorcDescRecargoGral.Enabled = True
      Me.txtPorcDescRecargoGral.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTotalGeneral.Enabled = True
      Me.txtTotalGeneral.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtTotalGeneralCabecera.Text = txtTotalGeneral.Text

      Me.txtPercepcionIVA.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPercepcionIIBB.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPercepcionVarias.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPercepcionGanancias.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      'txtPercepcionTotal.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtPercepcionTotal.SetValor(0)
      Me.txtImpuestosInternos.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      Me.txtTotalPercepciones.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      txtRetencionIVA.SetValor(0)
      txtRetencionIIBB.SetValor(0)
      txtRetencionGanancias.SetValor(0)
      txtRetencionTotal.SetValor(0)
      txtTotalRetenciones.SetValor(0)
      ugCuponesTarjetas.ClearFilas()
      txtTotalEnCartera.SetValor(0)
      txtTotalAcreditado.SetValor(0)
      txtTotalCupones.SetValor(0)

      Me._ModificaDetalle = "TODO"
      Me._ModificaDetalleRT = "TODO"

      Me._productos.Clear()

      '-- REQ-34986.- ----------------------------------------
      _titProductos.Remove("DescripcionAtributo01")
      _titProductos.Remove("DescripcionAtributo02")
      _titProductos.Remove("DescripcionAtributo03")
      _titProductos.Remove("DescripcionAtributo04")
      '-------------------------------------------------------
      Me.SetProductosDataSource()

      _comprasImpuestos.Clear()

      Me._productosRT.Clear()
      SetProductosRTDataSource()

      If Me._comprobantesSeleccionados IsNot Nothing Then
         Me._comprobantesSeleccionados.Clear()

         Me.dgvPedidos.DataSource = Me._comprobantesSeleccionados.ToArray()
         Me.dgvfacturables.DataSource = Me._comprobantesSeleccionados.ToArray()
      End If


      Me._productosLotes.Clear()
      Me._productosNrosSeries.Clear()

      Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.Text = String.Empty
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.txtStock.Text = String.Empty
      Me.txtStock.Tag = False
      Me.txtCantidad.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtPorcDescRecargoGral.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtDescuentoRecargoPorc.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      Me.txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto)

      chbAjusteManualIVA.Checked = False
      'PE-2054 : Se hablado con Augusto:
      'Vamos a sacar el tilde de "Sin detalle de Productos".
      'En el momento que alguno se queje vemos de tratar de convenserlo y si no es posible lo volvemos a poner.
      'If Publicos.TieneModuloContabilidad Then
      Me.chbSinProductos.Checked = False
      Me.chbSinProductos.Visible = False
      'Else
      '   Me.chbSinProductos.Checked = Publicos.ComprasSinProductos
      'End If

      Me.bscCodigoProveedor2.Focus()

      Me._publicos.CargaComboCajas(Me.cmbCajas, Me._Sucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

      'Me.HabilitarTiposComprobantes()
      'Me.HabilitarDestinatario()
      'Me.HabilitarRubro()

      _transportistaA = Nothing
      bscTransportista.Text = String.Empty
      txtBultos.Text = "0"
      txtNumeroLote.Text = "0"
      txtValorDeclarado.Text = "0.00"

      Me.LimpiarCamposProductos()
      LimpiarCamposProductosRT()

      Me.cmbPorcentajeIVA.Enabled = True
      Me.cmbPorcentajeIVA.SelectedIndex = -1

      Me._cargaPrecio = "PrecioCosto"

      Me.txtTotalPago.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtDiferencia.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      'Me.llbProveedor.Visible = False

      Me.txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtSaldoCtaCteVencido.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      Me.txtEfectivo.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTarjetas.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtChequesPropios.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtChequesTerceros.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTransferenciaBancaria.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      _transferencias = New List(Of Entidades.CompraTransferencia)()
      ugTransferenciasMultiples.DataSource = _transferencias

      Me._chequesPropios.Clear()
      Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()
      Me.LimpiarCamposChequePropio()
      Me._chequesTerceros.Clear()
      Me.dgvChequesTerceros.DataSource = Me._chequesTerceros.ToArray()
      Me._comprasObservaciones.Clear()
      Me.dgvObservaciones.DataSource = Me._comprasObservaciones.ToArray()

      dtpFechaOficializacion.Value = Today
      bscCodigoAduana.Text = ""
      bscAduana.Text = ""
      bscCodigoDestinacion.Text = ""
      bscDestinacion.Text = ""
      txtNumeroDespacho.Text = "0"
      txtDigitoVerificador.Text = ""
      txtNumeroManifiesto.Text = ""
      bscCodigoAgenteTransporte.Text = ""
      bscAgenteTransporte.Text = ""
      bscCodigoDespachante.Text = ""
      bscDespachante.Text = ""
      txtDerechoAduana.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      chbBienCapital.Checked = False
      Me._InvocaPedido = False

      _comprasImpuestosDespachoImportacion.Clear()

      Me.CargarLineasPermitidas()
      Me.LimpiarDetalle()
      LimpiarCamposDepachoImpuestos()

      Me._numeroOrden = 0
      Me.tbcDetalle.SelectedTab = Me.tbpProductos

      _dtProvincias = New Reglas.ComprasImpuestos().GetTodasLasProvincias()
      _dtProvinciasRetenciones = New Reglas.ComprasImpuestos().GetTodasLasProvincias()
      txtPercepcionIIBB.ReadOnly = False

      Me.bscProveedor2.Visible = True
      Me.txtNombreProveedorGenerico.Visible = False
      ' Me.lblCUIT.Enabled = False
      Me.txtCUIT.ReadOnly = True
      Me.txtCUIT.Text = ""
      Me.cmbCategoriaFiscal.Visible = False
      Me.txtCategoriaFiscal.Visible = True

      chbAFIPConceptoCM05.Checked = False
      If Not Reglas.Publicos.AFIPUtilizaCM05 Then
         chbAFIPConceptoCM05.Enabled = False
      End If

      bscCodigoProveedor2.Focus()

      ' Dejar el combo de comprador vacio para que sea obligatorio para el usuario seleccionarlo
      If Reglas.Publicos.ComprasSolicitaComprador Then
         Me.cmbComprador.SelectedIndex = -1
      End If

      'Si es X/R es remito, siempre debe tener esa letra, sino dejo la que esta.
      'If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Then
      If cboTipoComprobante.Any() Then
         If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Trim().Length = 1 Then
            Me.cboLetra.Text = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
         Else
            If Me._proveedor IsNot Nothing Then
               If Me._proveedor.EsProveedorGenerico Then
                  Me.cboLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscalCompra
               Else
                  Me.cboLetra.Text = Me._proveedor.CategoriaFiscal.LetraFiscalCompra
               End If

            Else
               Me.cboLetra.SelectedIndex = -1
            End If

            'If Me.bscCodigoProveedor.Selecciono Or Me.bscProveedor.Selecciono Then
            '   Me.cboLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
            'Else
            '  Me.cboLetra.SelectedIndex = -1
            'End If
         End If
      End If

      cmbDepositoOrigen.Enabled = True
      cmbDepositoOrigenRT.Enabled = True

      _transferencias.Clear()
      ugTransferenciasMultiples.Rows.Refresh(RefreshRow.ReloadData)
      txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
      bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()

   End Sub
   Private Function ValidaCuitProveedor() As Boolean
      If Me._proveedor IsNot Nothing Then
         If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
            If Not Me._proveedor.EsProveedorGenerico Then
               If String.IsNullOrWhiteSpace(_proveedor.CuitProveedor) OrElse Publicos.EsCuitValido(_proveedor.CuitProveedor) = False Then
                  MessageBox.Show("El Comprobante seleccionado graba en libro, y el proveedor no posee CUIT Valido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  AbrirPantallaProveedor()
                  Return False
               End If
            Else

               Dim result As Reglas.Validaciones.ValidacionResult
               result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                         With {.IdFiscal = txtCUIT.Text,
                                                                                               .SolicitaCUIT = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).SolicitaCUIT})
               If result.Error Then
                  MessageBox.Show(result.MensajeError.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  txtCUIT.Focus()
                  Return False
               End If


               'If String.IsNullOrWhiteSpace(Me.txtCUIT.Text) OrElse Publicos.EsCuitValido(Me.txtCUIT.Text.ToString()) = False Then
               '   MessageBox.Show("El Comprobante seleccionado graba en libro, y el proveedor no posee CUIT Valido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               '   Me.txtCUIT.Focus()
               '   Return False
               'End If
            End If

         End If
      End If
      Return True
   End Function
   Private Function ValidarInsertaProducto() As Boolean
      Dim prod As Entidades.Producto
      Try
         prod = New Reglas.Productos().GetUno(bscCodigoProducto2.Text.Trim())
      Catch ex As Exception
         prod = Nothing
      End Try
      If ValidaCuitProveedor() = False Then
         Return False
      End If
      'Solo lo valido en una compra, con el agregado de los distintas IVAs, se complico la pantalla
      If Double.Parse(Me.txtPrecio.Text) <= 0 And Me.cboTipoComprobante.Enabled And Not Reglas.Publicos.ComprasConProductosEnCero Then
         MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         NavegarPrecio(data:=Nothing)
         Return False
      End If

      If Me.txtCantidad.Text = "" Then
         MessageBox.Show("No puede ingresar sin cantidad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtCantidad.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtCantidad.Text) = 0 Then
         MessageBox.Show("La cantidad debe ser distinta de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtCantidad.Focus()
         Return False
      End If

      'En txtStock.Tag guardo propiedad "AfectaStock"
      If Decimal.Parse(Me.txtCantidad.Text) <= 0 And Boolean.Parse(Me.txtStock.Tag.ToString()) And Not Reglas.Publicos.Facturacion.FacturacionPermiteCantidadNegativa Then
         MessageBox.Show("La cantidad debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtCantidad.Focus()
         Return False
      End If

      'Dim cant As Int32 = DirectCast(Me.cmbTipoComprobante.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItems
      'If cant = 0 Then
      '   cant = 50
      'End If
      'If Me._productos.Count = cant Then
      '   MessageBox.Show("No puede ingresar mas de " & cant.ToString() & " productos para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.btnInsertar.Focus()
      '   Return False
      'End If


      'Ahora permito repetir el producto
      'controlo que no se repita el producto ingresado
      'Dim ent As Entidades.MovimientoCompraProducto
      'For i As Integer = 0 To Me._productos.Count - 1
      '   ent = Me._productos(i)
      '   If ent.IdProducto = Me.bscCodigoProducto2.Text Then
      '      If MessageBox.Show("El producto ya esta ingresado en este comprobante. ¿Desea agregar la cantidad al mismo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
      '         Me.txtCantidad.Text = (Decimal.Parse(Me.txtCantidad.Text) + ent.Cantidad).ToString("##0.00")
      '         Me.CalcularTotalProducto()
      '         Me._productos.RemoveAt(i)
      '         Return True
      '      Else
      '         Return False
      '      End If
      '   End If
      'Next

      If Me._proveedor.CategoriaFiscal.LetraFiscalCompra <> Me.cboLetra.Text Then
         If Me._proveedor.CategoriaFiscal.LetraFiscalCompra = "A" And Me.cboLetra.Text = "B" Then
            If Me.cmbPorcentajeIVA.Text <> "0.00" Then
               MessageBox.Show("El porcentaje de IVA debe ser 0% ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Return False
            End If
         End If
      End If

      If _utilizaCentroCostos Then
         If cmbCentroCosto.SelectedIndex = -1 Then
            ShowMessage("Debe seleccionar un centro de costos.")
            Me.cmbCentroCosto.Focus()
            Return False
         End If
      End If

      If chbConcepto.Checked And Me.cmbConceptos.SelectedIndex = -1 Then
         MessageBox.Show("Debe Asignar un Concepto de Expensas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbConceptos.Focus()
         Return False
      End If

      If prod IsNot Nothing Then
         If Reglas.Publicos.TieneModuloExpensas Then
            If Not Reglas.Publicos.ExpensasPermiteConSinConcepto Then
               'AndAlso prod.IncluirExpensas Then
               Dim incluyeExpensasActual As Boolean? = Me.IncluyeExpensasActual()
               If incluyeExpensasActual.HasValue AndAlso incluyeExpensasActual.Value <> prod.IncluirExpensas Then
                  MessageBox.Show("No se pueden mezclar productos que se incluyen en expensas con comprobantes que no se incluyen.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Return False
               End If
            End If
         End If
      End If
      Return True
   End Function

   Private Function IncluyeExpensasActual() As Boolean?
      Dim result As Boolean? = Nothing
      For Each vp In _productos
         Return vp.ProductoSucursal.Producto.IncluirExpensas
      Next
      Return result
   End Function

   Private Sub CargarProducto(dr As DataGridViewRow)

      If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 And Integer.Parse(dr.Cells("Atributos").Value.ToString()) > 0 Then
         MessageBox.Show("Producto con Atributos no es compatible con Comprobante que no Afecta Stock", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         bscCodigoProducto2.Focus()
         Exit Sub
      End If
      Dim oCF As Entidades.CategoriaFiscal = Nothing
      Dim PO As Decimal = 0
      Me._CodigoProductoProveedor = String.Empty
      Dim permiteModificarDescripcion As Boolean = False

      If Me._proveedor Is Nothing Then
         oCF = Me._categoriaFiscalEmpresa
      Else
         oCF = Me._proveedor.CategoriaFiscal
      End If

      Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      If _utilizaCentroCostos Then
         If Me.cmbCentroCosto.SelectedValue Is Nothing Then
            If producto.CentroCosto Is Nothing Then
               ShowMessage(String.Format("El producto '{0} - {1}' no tiene asignado Centro de Costos. Por favor verifique y vuelva a intentar.",
                                         producto.IdProducto, producto.NombreProducto))
               cmbCentroCosto.SelectedIndex = -1
            Else
               cmbCentroCosto.SelectedValue = producto.IdCentroCosto.Value
            End If
         End If
         cmbCentroCosto.Enabled = _permiteCambiarCentroCostosCompras
      End If

      informeCalidad = If(producto.InformeControlCalidad AndAlso
                           DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).SolicitaInformeCalidad, True, False)


      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Me._productoLoteTemporal = New Entidades.ProductoLote()

      Me._productoLoteTemporal.ProductoSucursal.Producto = producto ' New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

      permiteModificarDescripcion = Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

      Me.bscCodigoProducto2.Enabled = False
      Me.bscProducto2.Enabled = False
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.txtProductoObservacion.Text = dr.Cells("NombreProducto").Value.ToString()

      '-- REQ-43211.- ---------------------------------------------------------
      txtUnidadMedidaStock.Text = producto.UnidadDeMedida.IdUnidadDeMedida
      '------------------------------------------------------------------------

      '-- REQ-34986.- -------------------------------------------------------------------------------
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
            Using sap = New SeleccionaAtributosProductos()
               With sap
                  .Atributo01 = MovAtributo01
                  .Atributo02 = MovAtributo02
                  .Atributo03 = MovAtributo03
                  .Atributo04 = MovAtributo04
               End With
               '-- Invoca Formulario.- -----------------------------
               If sap.ShowDialog() = DialogResult.Cancel Then
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

      End If
      '----------------------------------------------
      txtAtributo01.Text = MovAtributo01.Descripcion
      txtAtributo02.Text = MovAtributo02.Descripcion
      '----------------------------------------------
      '----------------------------------------------------------------------------------------------

      Dim seteoEdicionProducto As Boolean = Reglas.Publicos.ComprasModificaDescripcionProducto And permiteModificarDescripcion

      If seteoEdicionProducto Then
         Me.txtProductoObservacion.Visible = True
         Me.bscProducto2.Visible = False
      Else
         Me.txtProductoObservacion.Visible = False
         Me.bscProducto2.Visible = True
      End If

      Dim PrecioVentaSinIVA As Decimal = 0
      Dim PrecioVentaConIVA As Decimal = 0

      Dim alicuota As Decimal = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())


      Me._IVAO = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())

      'decPrecio = 0

      If Me._cargaPrecio = "PrecioCosto" Or Me._cargaPrecio = "PrecioVenta" Then

         PrecioVentaSinIVA = Decimal.Parse(dr.Cells(Me._cargaPrecio).Value.ToString())
         PrecioVentaConIVA = Decimal.Parse(dr.Cells(Me._cargaPrecio).Value.ToString())

         'Si se guardan con IVA se lo quito, evito muchas preguntas posteriores.
         If Reglas.Publicos.PreciosConIVA Then
            Me._PO = PrecioVentaSinIVA
            PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA / (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
         Else
            Me._PO = PrecioVentaConIVA
            PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
         End If

         Dim PrecioVentaDolarSinIVA As Decimal? = Nothing
         Dim PrecioVentaDolarConIVA As Decimal? = Nothing

         grpPrecioDolares.Visible = False

         If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
            grpPrecioDolares.Visible = True
            PrecioVentaDolarSinIVA = PrecioVentaSinIVA
            PrecioVentaDolarConIVA = PrecioVentaConIVA
            PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
            PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         End If

         If (Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                  Me._proveedor.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                  DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then

            Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            If PrecioVentaDolarConIVA.HasValue Then
               txtPrecioDolares.Text = PrecioVentaDolarConIVA.Value.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            End If
         Else
            Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            If PrecioVentaDolarSinIVA.HasValue Then
               txtPrecioDolares.Text = PrecioVentaDolarSinIVA.Value.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            End If
         End If



         ''Exento sin IVA / Monotributo (por ahora lo dejo exento, mas sencillo para el IVA, pero deberia hacer lo mismo que facturacion.
         'If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
         '   Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
         '   Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then

         '   Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnItems))
         'Else
         '   Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnItems))
         'End If



      End If


      Me._precioVenta = Decimal.Parse(dr.Cells("PrecioVenta").Value.ToString())


      Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      Me.txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())
      Me.txtCantidad.Text = (1D).ToString("N" + _decimalesMostrarEnCantidad.ToString())

      Me.dtpFechaActPrecios.Value = Date.Parse(dr.Cells("FechaActualizacion").Value.ToString())

      If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
         pnlCantidadUMCompra.Visible = True
         pnlPrecioPorUMCompra.Visible = True
         pnlUnidadesCompras.Visible = True
         txtCantidadUMCompra.Tag = producto.FactorConversionCompra
         txtCantidadUMCompra.SetValor(RequerimientosComprasDetalle.CalculaCantidadUMCDesdeCantidad(txtCantidad.ValorNumericoPorDefecto(0D), producto.FactorConversionCompra))
         txtPrecioPorUMCompra.SetValor(txtPrecio.ValorNumericoPorDefecto(0D) / producto.FactorConversionCompra)
         txtUnidadesCompras.SetValor(txtCantidad.ValorNumericoPorDefecto(0D))
         lblCantidadUMCompra.Text = producto.UnidadDeMedidaCompra.NombreUnidadDeMedida
      End If

      Me._publicos.CargaComboConceptos(Me.cmbConceptos, Me.bscCodigoProducto2.Text)

      chbConcepto.Checked = cmbConceptos.Items.Count > 0
      If chbConcepto.Checked Then
         If Me.cmbConceptos.Items.Count > 1 Then
            Me.cmbConceptos.SelectedIndex = -1 'Obligo a cargarlo
         Else
            Me.cmbConceptos.SelectedIndex = 0
         End If
      End If

      'If Me.cmbConceptos.Items.Count > 0 Then
      '   Me.cmbConceptos.Enabled = True
      '   If Me.cmbConceptos.Items.Count > 1 Then
      '      Me.cmbConceptos.SelectedIndex = -1 'Obligo a cargarlo
      '   Else
      '      Me.cmbConceptos.SelectedIndex = 0
      '   End If
      'End If


      'Monotributista / Consumidor Final (no usan el iva)
      'If Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
      '   Me.cmbPorcentajeIVA.Text = alicuota.ToString()
      'Else
      '   Me.cmbPorcentajeIVA.Text = "0"
      'End If


      'Exento sin IVA / Monotributo (por ahora lo dejo exento, mas sencillo para el IVA, pero deberia hacer lo mismo que facturacion.
      If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
         Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or
         Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         Me.cmbPorcentajeIVA.Text = "0.00"
         Me.cmbPorcentajeIVA.Enabled = False
         If Reglas.Publicos.PreciosConIVA Then
            Me._alicuota = 0
         Else
            Me._alicuota = alicuota
         End If

      Else
         Me.cmbPorcentajeIVA.Enabled = True
         Me.cmbPorcentajeIVA.Text = alicuota.ToString()
         Me._alicuota = alicuota
      End If

      If Boolean.Parse(dr.Cells("FacturacionCantidadNegativa").Value.ToString()) Then
         Me.txtCantidad.Text = "-1." + New String("0"c, Me._decimalesEnCantidad)
         Me.txtStock.Tag = False
      End If


      If Reglas.Publicos.UtilizaPrecioDeCompra AndAlso Me._proveedor IsNot Nothing Then
         'If producto.ProductoProveedorHabitual IsNot Nothing Then
         '   'ver si es asi
         '   'If Me._proveedor.IdProveedor = producto.ProductoProveedorHabitual.IdProveedor Then
         '   Me.txtPrecioLista.Text = producto.ProductoProveedorHabitual.UltimoPrecioFabrica.ToString()
         '   Me.txtDescuento1.Text = producto.ProductoProveedorHabitual.DescuentoRecargoPorc1.ToString()
         '   Me.txtDescuento2.Text = producto.ProductoProveedorHabitual.DescuentoRecargoPorc2.ToString()
         '   Me.txtDescuento3.Text = producto.ProductoProveedorHabitual.DescuentoRecargoPorc3.ToString()
         '   Me.txtDescuento4.Text = producto.ProductoProveedorHabitual.DescuentoRecargoPorc4.ToString()
         '   Me._CodigoProductoProveedor = producto.ProductoProveedorHabitual.CodigoProductoProveedor
         '   'End If
         'End If
         Dim prodProv As Entidades.ProductoProveedor = New Eniac.Reglas.ProductosProveedores().GetUno(Me._proveedor.IdProveedor, producto.IdProducto)

         If prodProv IsNot Nothing Then
            Me.txtPrecioLista.Text = prodProv.UltimoPrecioFabrica.ToString()
            Me.txtDescuento1.Text = prodProv.DescuentoRecargoPorc1.ToString()
            Me.txtDescuento2.Text = prodProv.DescuentoRecargoPorc2.ToString()
            Me.txtDescuento3.Text = prodProv.DescuentoRecargoPorc3.ToString()
            Me.txtDescuento4.Text = prodProv.DescuentoRecargoPorc4.ToString()
            Me._CodigoProductoProveedor = prodProv.CodigoProductoProveedor
            Me.txtPrecioLista.ReadOnly = False
            Me.txtDescuento1.ReadOnly = False
            Me.txtDescuento2.ReadOnly = False
            Me.txtDescuento3.ReadOnly = False
            Me.txtDescuento4.ReadOnly = False
         Else
            Me.txtPrecioLista.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
            Me.txtDescuento1.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
            Me.txtDescuento2.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
            Me.txtDescuento3.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
            Me.txtDescuento4.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
            Me.txtPrecioLista.ReadOnly = True
            Me.txtDescuento1.ReadOnly = True
            Me.txtDescuento2.ReadOnly = True
            Me.txtDescuento3.ReadOnly = True
            Me.txtDescuento4.ReadOnly = True
         End If

      Else
         Me.txtPrecioLista.ReadOnly = True
         Me.txtDescuento1.ReadOnly = True
         Me.txtDescuento2.ReadOnly = True
         Me.txtDescuento3.ReadOnly = True
         Me.txtDescuento4.ReadOnly = True
      End If

      'Si esta habitada, seguramente la cambiaria
      If txtProductoObservacion.Visible Then
         txtCantidad.Focus()
         txtProductoObservacion.Focus()
      Else
         If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
            Navegar(txtCantidadUMCompra)
         Else
            txtCantidad.Focus()
            txtCantidad.SelectAll()
         End If
      End If

      '--------------------------------
      cmbDepositoOrigen.Enabled = True
      cmbDepositoOrigen.SelectedValue = Integer.Parse(dr.Cells("IdDepositoDefecto").Value.ToString.Trim())
      If cmbDepositoOrigen.SelectedIndex <> -1 Then
         cmbUbicacionOrigen.Enabled = True
         cmbUbicacionOrigen.SelectedValue = Integer.Parse(dr.Cells("IdUbicacionDefecto").Value.ToString.Trim())
      Else
         'ShowMessage("El usuario carece de permisos para el Depósito por Defecto del Producto. Se asume proximo depósito autorizado.")
         cmbDepositoOrigen.SelectedIndex = 0
      End If
      '--------------------------------

   End Sub

   Private _ordenProducto As Integer
   Private Sub CargarProductoCompleto(dr As DataGridViewRow,
                                       editarProductoDesdeGrilla As Boolean)

      Dim oProductos As Reglas.Productos = New Reglas.Productos()
      Dim oProdProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores()
      Dim PermiteModificarDescripcion As Boolean = False

      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Dim dtProd As DataTable
      If Me.chbProductosDelProveedor.Checked Then
         dtProd = oProdProv.GetPorProductoYProveedor(_proveedor.IdProveedor, Me.bscCodigoProducto2.Text.Trim())
         Me.bscCodigoProducto2.Text = dtProd.Rows(0).Item("CodigoProductoProveedor").ToString().Trim()
      Else
         dtProd = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, _listaPreciosPredeterminada, "COMPRAS", soloBuscaPorIdProducto:=editarProductoDesdeGrilla)
         Me.bscCodigoProducto2.Datos = dtProd
      End If

      cmbDepositoOrigen.SelectedValue = Integer.Parse(dr.Cells("IdDeposito").Value.ToString())
      cmbUbicacionOrigen.SelectedValue = Integer.Parse(dr.Cells("IdUbicacion").Value.ToString())

      If _utilizaCentroCostos Then
         If dr.Cells("IdCentroCosto").Value IsNot Nothing Then
            cmbCentroCosto.SelectedValue = Integer.Parse(dr.Cells("IdCentroCosto").Value.ToString())
         End If
      End If
      Me.bscCodigoProducto2.PresionarBoton()

      If Reglas.Publicos.ComprasConservaOrdenProductos Then
         _ordenProducto = ObjectExtensions.ValorNumericoPorDefecto(dr.Cells("Orden").Value, 0I)
      End If

      PermiteModificarDescripcion = Boolean.Parse(dtProd.Rows(0)("PermiteModificarDescripcion").ToString())

      Dim seteoEdicionProducto As Boolean = Reglas.Publicos.ComprasModificaDescripcionProducto And PermiteModificarDescripcion
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      txtProductoObservacion.Text = bscProducto2.Text

      Me._editarNrosSeries = DirectCast(DirectCast(dr, DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NrosSeries

      Me.bscCodigoProducto2.Enabled = False

      'Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscProducto2.Enabled = False

      'NO hace falta, el "PresionarBoton" llama a "CargarProducto" y lo asigna.
      ''Dejo lo que se cargo al presionar el boton.. tal vez cambio...
      'Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      'Me.txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

      Me.txtCantidad.Text = dr.Cells("Cantidad").Value.ToString()
      Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), Me._decimalesRedondeoEnPrecio).ToString("#,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))

      Me.cmbPorcentajeIVA.Text = dr.Cells("PorcentajeIVA").Value.ToString()

      If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
           Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or
           Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         Me.cmbPorcentajeIVA.Enabled = False
      End If

      Dim precio As Decimal = 0
      Decimal.TryParse(dr.Cells("Precio").Value.ToString(), precio)
      If precio <> 0 Then
         Me.txtDescuentoRecargoPorc.Text = (Decimal.Parse(dr.Cells("DescuentoRecargo").Value.ToString()) * 100 / precio / Decimal.Parse(dr.Cells("Cantidad").Value.ToString())).ToString("#0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      Else
         Me.txtDescuentoRecargoPorc.Text = precio.ToString("#0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      End If

      Me.txtDescuentoRecargo.Text = dr.Cells("DescuentoRecargo").Value.ToString()
      Me.txtTotalProducto.Text = dr.Cells("Importe").Value.ToString()
      'Me.cmbConceptos.Text = New Reglas.Conceptos().GetUno(Integer.Parse(dr.Cells("IdConcepto").Value.ToString())).NombreConcepto
      Me.cmbConceptos.SelectedValue = Integer.Parse(dr.Cells("IdConcepto").Value.ToString())

      If Not IsDBNull(dr.Cells("colIdLote").Value) AndAlso dr.Cells("colIdLote").Value IsNot Nothing Then
         Me.txtLote.Text = dr.Cells("colIdLote").Value.ToString()
      End If

      '-- REQ-34986.- -- Aloja los datos recuperados.- --
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
      '-- REQ-35487.- -------------------------------
      txtAtributo01.Text = MovAtributo01.Descripcion
      txtAtributo02.Text = MovAtributo02.Descripcion
      '----------------------------------------------
      _InformeNumero = dr.Cells("InformeCalidadNumero").ValorAs(String.Empty)
      _InformeLink = dr.Cells("InformeCalidadLink").ValorAs(String.Empty)
      '----------------------------------------------

      txtCantidadUMCompra.SetValor(dr.Cells(dgcProductosCantidadUMC.Name).ValorAs(0D))
      txtCantidadUMCompra.Tag = dr.Cells(dgcProductosFactorConversionCompra.Name).ValorAs(0D)
      txtPrecioPorUMCompra.SetValor(dr.Cells(dgcProductosPrecioPorUMC.Name).ValorAs(0D))
      txtUnidadesCompras.SetValor(dr.Cells("Cantidad").ValorAs(0D))

   End Sub

   Private Sub CalcularDescuentoRecargo()
      ''Me.txtTotalDescRec.Text = Decimal.Round((Decimal.Parse(Me.txtBruto.Text) * Decimal.Parse(Me.txtPorDescRec.Text) / 100), 2).ToString()
      For Each vPro In Me._productos
         vPro.DescRecGeneral = Decimal.Round((vPro.ImporteTotal * Decimal.Parse(Me.txtPorcDescRecargoGral.Text) / 100), Me._decimalesRedondeoEnPrecio)
         vPro.IVA = (vPro.ImporteTotal + vPro.DescRecGeneral) * vPro.PorcentajeIVA / 100
      Next
   End Sub

   Private Sub DefinirOrden(linea As Entidades.MovimientoStockProducto)
      With linea
         If _ordenProducto > 0 Then
            .Orden = _ordenProducto
         ElseIf _ordenProducto = 0 Then
            .Orden = _productos.MaxSecure(Function(x) x.Orden).IfNull() + 1
         End If
      End With
   End Sub

   Private Sub InsertarProducto()

      Me._numeroOrden += 1
      'Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim oLineaDetalle = New Entidades.MovimientoStockProducto()
      With oLineaDetalle
         .IdProducto = Me.bscCodigoProducto2.Text
         Dim Prod = New Reglas.Productos().GetUno(.IdProducto)
         If txtProductoObservacion.Visible Then
            .NombreProducto = txtProductoObservacion.Text
         Else
            .NombreProducto = Me.bscProducto2.Text
         End If
         .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)
         .DescuentoRecargo = Decimal.Parse(Me.txtDescuentoRecargo.Text)
         ''.DescRecGeneral = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

         .Precio = Decimal.Parse(Me.txtPrecio.Text.Trim())

         Dim ImporteBruto As Decimal
         Dim descRec1 As Decimal = Decimal.Round(.Precio * .DescuentoRecargoPorc / 100, Me._decimalesRedondeoEnPrecio)
         'Dim descRec As Decimal = Decimal.Round((.Precio + descRec1) * .DescRecGeneral / 100, Me._valorRedondeo)

         ImporteBruto = .Precio + descRec1

         '# Si el tipo de comprobante tiene coef. Stock negativo (x ej: una devolución de compra o nc), valido que la cantidad a devolver no sea mayor ->
         '# a la cantidad que se encuentra en stock (siempre y cuando el producto AFECTE STOCK)
         If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0 Then
            If Not String.IsNullOrEmpty(Me.txtStock.Text) AndAlso
               CDec(Me.txtStock.Text) < CDec(Me.txtCantidad.Text) AndAlso .ProductoSucursal.Producto.AfectaStock Then
               ShowMessage("No se puede realizar una devolución por más productos de los que se encuentran en stock.")
               Me.txtCantidad.Focus()
               Exit Sub
            End If
         End If

         .Cantidad = Decimal.Parse(Me.txtCantidad.Text)

         .CantidadUMCompra = txtCantidadUMCompra.ValorNumericoPorDefecto(0D)
         .FactorConversionCompra = txtCantidadUMCompra.TagNumericoPorDefecto(0D)
         .PrecioPorUMCompra = txtPrecioPorUMCompra.ValorNumericoPorDefecto(0D)
         .IdUnidadDeMedida = Prod.UnidadDeMedida.IdUnidadDeMedida
         .IdUnidadDeMedidaCompra = Prod.UnidadDeMedidaCompra.IdUnidadDeMedida

         .ImporteTotal = Decimal.Parse(Me.txtTotalProducto.Text)
         .PrecioCostoO = Me._PO

         .DescRecGeneral = Decimal.Round((.ImporteTotal * Decimal.Parse(Me.txtPorcDescRecargoGral.Text) / 100), Me._decimalesRedondeoEnPrecio)

         .PorcentajeIVA = Decimal.Parse(Me.cmbPorcentajeIVA.Text)
         .IVA = (.ImporteTotal + .DescRecGeneral) * .PorcentajeIVA / 100

         If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
                  Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or
                  Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then

            If Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
               .PrecioCostoNuevo = Decimal.Round(ImporteBruto / (1 + Me._IVAO / 100), Me._decimalesRedondeoEnPrecio)
            Else
               .PrecioCostoNuevo = ImporteBruto
            End If
         Else
            .PrecioCostoNuevo = ImporteBruto
         End If

         'Si no tiene IVA discriminado no deberia entrar
         If Reglas.Publicos.PreciosConIVA And Me._proveedor.CategoriaFiscal.IvaDiscriminado Then
            .PrecioCostoNuevo = Decimal.Round(.PrecioCostoNuevo * (1 + Me._IVAO / 100), Me._decimalesRedondeoEnPrecio)
         End If

         If Prod.Moneda.IdMoneda = 2 Then
            .PrecioCostoNuevo = .PrecioCostoNuevo / Decimal.Parse(Me.txtCotizacionDolar.Text)
         End If

         .PrecioVentaActual = Me._precioVenta

         Dim porcentaje As Decimal = 0

         If .PrecioCostoO > 0 Then
            porcentaje = Decimal.Round(.PrecioVentaActual / .PrecioCostoO, Me._decimalesRedondeoEnPrecio)
         End If

         If .PrecioVentaActual <> 0 Then
            .PorcentRecargo = (porcentaje - 1) * 100
         End If


         .PrecioVentaNuevo = Decimal.Round(.PrecioCostoNuevo * porcentaje, Me._decimalesRedondeoEnPrecio)
         'NO hace falta preguntar aca porque ahora lo bloqueo arriba.
         'If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
         '   Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
         '   Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         '   .PorcentajeIVA = 0
         '   .IVA = 0
         'Else

         'End If

         .TotalProducto = .ImporteTotal + .IVA
         'REG-36547.- -----------
         .IdSucursal = _sucStock
         .IdDeposito = _depStock
         .IdUbicacion = _ubiStock
         '-----------------------
         .NombreDeposito = cmbDepositoOrigen.Text
         .NombreUbicacion = cmbUbicacionOrigen.Text

         Dim var As Decimal = 0
         var = .PrecioCostoO - .PrecioCostoNuevo
         If .PrecioCostoNuevo <> 0 Then
            .PorcVar = (var / .PrecioCostoNuevo * 100) * -1
         Else
            If .PrecioCostoNuevo = var Then
               .PorcVar = 0
            Else
               .PorcVar = -100
            End If
         End If

         If Me.txtStock.Text.Length <> 0 Then
            .Stock = Decimal.Parse(Me.txtStock.Text)
         Else
            .Stock = 0
         End If
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .IdLote = ""
         .VtoLote = Nothing

         .InformeCalidadNumero = _InformeNumero
         .InformeCalidadLink = _InformeLink

         'ingreso los valores del Lote
         '##################
         '#     LOTES      #
         '##################
         If Me._productoLoteTemporal.ProductoSucursal.Producto.Lote And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> 0 Then
            Me.SeleccionDeLotes(oLineaDetalle, Me.txtLote.Text)
         End If

         'ingreso los nros. de serie
         ' VER PORQUE ELIMINA LOS RENGLONES QUE NO SE EDITARON

         oLineaDetalle.ProductoSucursal.Producto = Prod

         '# Nro. de Serie
         If oLineaDetalle.ProductoSucursal.Producto.NroSerie Then
            Me.CargarNumeroDeSerieProductosCompras(oLineaDetalle, Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()),
                                                                  Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString()))
         End If

         If chbConcepto.Checked Then ' Me.cmbConceptos.SelectedItem IsNot Nothing Then
            .IdConcepto = Integer.Parse(Me.cmbConceptos.SelectedValue.ToString())
            .NombreConcepto = Me.cmbConceptos.Text.ToString()
         End If

         .FechaActualizacion = Me.dtpFechaActPrecios.Value

         '--REQ-34986.- ---------------------------------------------
         .IdaAtributoProducto01 = MovAtributo01.IdaAtributoProducto
         .DescripcionAtributo01 = MovAtributo01.Descripcion
         .IdaAtributoProducto02 = MovAtributo02.IdaAtributoProducto
         .DescripcionAtributo02 = MovAtributo02.Descripcion
         .IdaAtributoProducto03 = MovAtributo03.IdaAtributoProducto
         .DescripcionAtributo03 = MovAtributo03.Descripcion
         .IdaAtributoProducto04 = MovAtributo04.IdaAtributoProducto
         .DescripcionAtributo04 = MovAtributo04.Descripcion
         '---------------------------------------------------------
      End With
      Me.DefinirOrden(oLineaDetalle)

      If oLineaDetalle.Orden = 0 Then
         oLineaDetalle.Orden = _numeroOrden
      End If

      If _utilizaCentroCostos Then
         oLineaDetalle.CentroCosto = DirectCast(cmbCentroCosto.SelectedItem, Entidades.ContabilidadCentroCosto)
      End If
      oLineaDetalle.CodigoProductoProveedor = Me._CodigoProductoProveedor

      Me._productos.Add(oLineaDetalle)

      'Dim ns1 As IEnumerable(Of Entidades.ProductoNroSerie)

      'ns1 = From el As Entidades.ProductoNroSerie In Me._productosNrosSeries _
      '      Where el.Producto.IdProducto = Me._productos(Me._productos.Count - 1).ProductoSucursal.Producto.IdProducto


      'For Each pns As Entidades.ProductoNroSerie In ns
      '   Me._productos(Me._productos.Count - 1).ProductoSucursal.Producto.NrosSeries.Add(pns)
      'Next

      'Me._productos(Me._productos.Count - 1).ProductoSucursal.Producto.NrosSeries = Me._productosNrosSeries

      '-- REQ-34986.- ------------------------------------------------------
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0 Then
         If Not _titProductos.ContainsKey("DescripcionAtributo01") Then _titProductos.Add("DescripcionAtributo01", "")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0 Then
         If Not _titProductos.ContainsKey("DescripcionAtributo02") Then _titProductos.Add("DescripcionAtributo02", "")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _titProductos.ContainsKey("DescripcionAtributo03") Then _titProductos.Add("DescripcionAtributo03", "")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _titProductos.ContainsKey("DescripcionAtributo04") Then _titProductos.Add("DescripcionAtributo04", "")
      End If
      '---------------------------------------------------------------------

      SetProductosDataSource()
      dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1


      Me.FormatearGrilla()
      dgvProductos.Refresh()
      'Me.CalcularTotalProducto()
      Me.LimpiarCamposProductos()
      Me.CalcularTotales()
      'Me.CalcularDescuentoRecargo()
      'Me.CalcularTotales()

      '      cmbDepositoOrigen.Enabled = (Not _productos.Count > 0)

      ProductoFocus()

      Me._vieneDelDobleClick = False
      '--REQ-34986.- --------------------------------
      InicializaAtributos()
      '---------------------------------------------
   End Sub

   Private Sub InicializaAtributos()
      MovAtributo01.IdaAtributoProducto = 0
      MovAtributo02.IdaAtributoProducto = 0
      MovAtributo03.IdaAtributoProducto = 0
      MovAtributo04.IdaAtributoProducto = 0
   End Sub

   Private Sub CargarNumeroDeSerieProductosCompras(prod As Entidades.MovimientoStockProducto, IdDeposito As Integer, IdUbicacion As Integer)

      Dim cantidadDeProductos As Integer = Integer.Parse(Math.Round(prod.Cantidad, 0).ToString())

      If _vieneDelDobleClick Then
         prod.ProductoSucursal.Producto.NrosSeries = _editarNrosSeries
      End If

      '# DEVOLUCIÓN DE COMPRA DE PRODUCTOS CON NRO.SERIE
      If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0 Then
         Me.CargarProductosNrosSerieADevolver(prod, cantidadDeProductos)

      Else '# COMPRA NORMAL

         Dim Ver As Boolean = False 'Para distinguir el llamado del boton Ver en Grilla
         Dim rProductoNroSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie
         Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos, prod.ProductoSucursal.Producto, _productosNrosSeries, Ver,
                                                                  IdDeposito, IdUbicacion)
         'Dim ePNS As Entidades.ProductoNroSerie

         If ins.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Me.btnInsertar.Focus()
            Throw New Exception("Si el producto esta marcado que utiliza Nro. de Serie los tiene que ingresar en la compra.")
         Else
            '# Toda la carga del Producto NroSerie se realiza dentro del método.
            Me.CargarProductoNroSerieEnLista(prod, ins.ProductosNrosSerie)

         End If
      End If

   End Sub

   Private Sub EliminarLineaProducto()
      Dim prodSeleccionado = dgvProductos.FilaSeleccionada(Of Entidades.MovimientoStockProducto)()
      EliminarLineaProducto(prodSeleccionado)
   End Sub

   Private Sub EliminarLineaProducto(prodSeleccionado As Entidades.MovimientoStockProducto)
      '# En caso que el producto tenga Nro. Serie, lo quito de la colección para que dicho Nro. pueda ser reutilizado 
      _productosNrosSeries.RemoveAll(Function(x) x.Producto.IdProducto = prodSeleccionado.IdProducto And x.OrdenCompra.Value = prodSeleccionado.Orden)

      _productos.Remove(prodSeleccionado)

      If prodSeleccionado.IdLote IsNot Nothing Then
         EliminarProductoLote(prodSeleccionado.IdLote, prodSeleccionado.IdSucursal, prodSeleccionado.IdProducto)
      End If

      If prodSeleccionado.IdProducto IsNot Nothing Then

         Dim colAux = New List(Of Entidades.ProductoNroSerie)()
         For Each nroSerie In _productosNrosSeries
            If nroSerie.Producto.IdProducto = prodSeleccionado.IdProducto Then
               For Each nroSerie2 In _editarNrosSeries
                  If nroSerie.NroSerie = nroSerie2.NroSerie Then
                     colAux.Add(nroSerie)
                  End If
               Next
            End If
         Next

         For Each nro In colAux
            _productosNrosSeries.Remove(nro)
         Next

      End If

      '-- REQ-34986.- ------------------------------------------------------
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() = 0 Then
         If _titProductos.ContainsKey("DescripcionAtributo01") Then _titProductos.Remove("DescripcionAtributo01")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() = 0 Then
         If _titProductos.ContainsKey("DescripcionAtributo02") Then _titProductos.Remove("DescripcionAtributo02")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() = 0 Then
         If _titProductos.ContainsKey("DescripcionAtributo03") Then _titProductos.Remove("DescripcionAtributo03")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() = 0 Then
         If _titProductos.ContainsKey("DescripcionAtributo04") Then _titProductos.Remove("DescripcionAtributo04")
      End If
      '---------------------------------------------------------------------

      SetProductosDataSource()

      CalcularTotales()
      CalcularDescuentoRecargo()
      CalcularTotales()
   End Sub

   Private Sub EliminarProductoLote(idLote As String, idSucursal As Integer, idProducto As String)
      Dim pl As Entidades.ProductoLote
      For i As Integer = 0 To Me._productosLotes.Count - 1
         pl = Me._productosLotes(i)
         If pl.IdLote = idLote And pl.ProductoSucursal.Sucursal.IdSucursal = idSucursal And pl.ProductoSucursal.Producto.IdProducto = idProducto Then
            Me._productosLotes.Remove(pl)
            Exit For
         End If
      Next
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscCodigoProveedor2.Text = dr.Cells("CodigoProveedor").Value.ToString
      Me.bscCodigoProveedor2.Tag = dr.Cells("IdProveedor").Value.ToString

      Me.bscProveedor2.Text = dr.Cells("NombreProveedor").Value.ToString

      Me.idCategoriaFiscal = Short.Parse(dr.Cells("idCategoriaFiscal").Value.ToString())

      Me.txtCategoriaFiscal.Text = dr.Cells("NombreCategoriaFiscal").Value.ToString

      'If Me.cboTipoComprobante.SelectedIndex >= 0 Then
      '   If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas <> "X" Then
      '      If Me.cboLetra.SelectedIndex >= 0 And FilaDevuelta.Cells("LetraFiscal").Value.ToString() <> Me.cboLetra.Text Then
      '         MessageBox.Show("La Letra del Proveedor '" & FilaDevuelta.Cells("LetraFiscal").Value.ToString() & "' NO coincide con del Comprobante '" & Me.cboLetra.Text & "'", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '         Me.cboLetra.SelectedIndex = -1
      '      End If
      '   End If
      'End If

      If Me.cboLetra.Text <> "X" And Me.cboLetra.Text <> "R" Then
         Me.cboLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
      End If

      Me.bscCodigoProveedor2.Permitido = False
      Me.bscProveedor2.Permitido = False

      'Me.bscCodigoProducto2.Enabled = True
      'Me.bscProducto2.Enabled = True
      'Me.txtCantidad.Enabled = True
      'Me.txtPrecio.Enabled = True
      'Me.txtPorDescuento.Enabled = True

      Dim o As Reglas.Proveedores = New Reglas.Proveedores()
      Me._proveedor = o.GetUno(Long.Parse(Me.bscCodigoProveedor2.Tag.ToString()))

      If Reglas.Publicos.AFIPUtilizaCM05 Then
         chbAFIPConceptoCM05.Enabled = True
         If _proveedor.IdConceptoCM05.HasValue Then
            chbAFIPConceptoCM05.Checked = True
            cmbAFIPConceptoCM05.SelectedValue = _proveedor.IdConceptoCM05.Value
         Else
            chbAFIPConceptoCM05.Checked = False
         End If
      End If

      Me.cboRubro.SelectedValue = Me._proveedor.RubroCompra.IdRubro

      If Me._proveedor.IdTipoComprobante <> "" Then

         Me.cboTipoComprobante.SelectedValue = Me._proveedor.IdTipoComprobante

         If Me.cboTipoComprobante.SelectedIndex = -1 And Me.cboTipoComprobante.Items.Count > 0 Then
            Me.cboTipoComprobante.SelectedIndex = 0
         End If

      End If

      If Me._proveedor.IdFormasPago > 0 Then

         Me.cboFormaPago.SelectedValue = Me._proveedor.IdFormasPago

         If Me.cboFormaPago.SelectedIndex = -1 And Me.cboFormaPago.Items.Count > 0 Then
            Me.cboFormaPago.SelectedIndex = 0
         End If

      End If

      Me.txtPorcDescRecargoGral.Text = Me._proveedor.DescuentoRecargoPorc.ToString()

      Me.CargarSaldosCtaCte()

      chbNumeroAutomatico.Checked = False
      cboLetra.Enabled = True
      txtEmisorFactura.Enabled = True
      txtNumeroFactura.Enabled = True
      chbNumeroAutomatico.Visible = False
      lblNumeroAutomatico.Visible = False
      lblNumeroFactura.Text = "Número"

      If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).NumeracionAutomatica Then
         Me.CargarProximoNumeroProveedor()
      ElseIf DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 And
         Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).AfectaCaja And
         Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).ActualizaCtaCte Then
         Me.CargarProximoNumero()
      Else
         Me.txtEmisorFactura.Text = ""
         Me.txtNumeroFactura.Text = ""
      End If

      'Me.llbProveedor.Visible = True

      If _proveedor.CategoriaFiscal IsNot Nothing Then
         txtPercepcionIVA.ReadOnly = Not _proveedor.CategoriaFiscal.IvaDiscriminado
         txtPercepcionIIBB.ReadOnly = Not _proveedor.CategoriaFiscal.IvaDiscriminado
         btnPercIIBB.Enabled = _proveedor.CategoriaFiscal.IvaDiscriminado
         txtPercepcionGanancias.ReadOnly = Not _proveedor.CategoriaFiscal.IvaDiscriminado
         txtPercepcionVarias.ReadOnly = Not _proveedor.CategoriaFiscal.IvaDiscriminado
         txtImpuestosInternos.ReadOnly = Not _proveedor.CategoriaFiscal.IvaDiscriminado
      End If

      Me.txtCUIT.Text = Me._proveedor.CuitProveedor.ToString()

      If Me._proveedor.EsProveedorGenerico Then
         Me.bscProveedor2.Visible = False
         Me.txtNombreProveedorGenerico.Visible = True
         'Me.lblCUIT.Enabled = True
         Me.txtCUIT.ReadOnly = False
         Me.cmbCategoriaFiscal.Visible = True
         Me.cmbCategoriaFiscal.SelectedValue = Me._proveedor.CategoriaFiscal.IdCategoriaFiscal
         Me.txtCategoriaFiscal.Visible = False
      End If

   End Sub

   Private Sub LimpiarDetalle()
      Dim ini As String = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)

      Me._productos.Clear()
      Me.SetProductosDataSource()
      Me.dgvProductos.Refresh()

      Me._productosLotes.Clear()
      Me._productosNrosSeries.Clear()

      Me.LimpiarCamposProductos()

      Me.txtPorcDescRecargoGral.Text = ini

      Me.txtTotalBruto.Text = ini
      Me.txtTotalNeto.Text = ini
      Me.txtTotalIVA.Text = ini
      Me.txtTotalPercepciones.Text = ini
      Me.txtTotalGeneral.Text = ini
      txtTotalGeneralCabecera.Text = txtTotalGeneral.Text

   End Sub

   'Private Sub PresionarTab(e As System.Windows.Forms.KeyEventArgs)
   '   If e.KeyCode = Keys.Enter Then
   '      Me.ProcessTabKey(True)
   '   End If
   'End Sub

   Private Function ValidarInsertarChequePropio() As Boolean

      If Not Me.bscCodigoProveedor2.Selecciono And Not Me.bscProveedor2.Selecciono Then
         ShowMessage("ATENCION: Debe elegir el Proveedor antes de cargar el Cheque.")
         Me.bscCodigoProveedor2.Focus()
         Return False
      End If

      If Not Me.bscCuentaBancariaPropio.Selecciono Then
         MessageBox.Show("Debe seleccionar una Cuenta Bancaria.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCuentaBancariaPropio.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtNroChequePropio.Text) = 0 Then
         MessageBox.Show("El número de cheque no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroChequePropio.Focus()
         Return False
      End If

      'En teorica nunca pasa porque toma de la cuenta Bancaria.
      If Integer.Parse(Me.txtCodPostalChequePropio.Text) = 0 Then
         MessageBox.Show("Debe ingresar un C.P. para el cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtCodPostalChequePropio.Focus()
         Return False
      Else
         If Not New Reglas.Localidades().Existe(Integer.Parse(Me.txtCodPostalChequePropio.Text)) Then
            MessageBox.Show("No existe la localidad del Cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCodPostalChequePropio.Focus()
            Return False
         End If
      End If

      If Decimal.Parse(Me.txtImporteChequePropio.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un cheque con importe cero o negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtImporteChequePropio.Focus()
         Return False
      End If

      'controlo que no se repita el cheque ingresado
      Dim ent As Entidades.Cheque
      For i As Integer = 0 To Me._chequesPropios.Count - 1
         ent = Me._chequesPropios(i)
         If ent.NumeroCheque = Integer.Parse(Me.txtNroChequePropio.Text) And
                  ent.Banco.IdBanco = Integer.Parse(Me.cmbBancoPropio.SelectedValue.ToString()) And
                  ent.IdBancoSucursal = Integer.Parse(Me.txtSucursalBancoPropio.Text) And
                  ent.Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalChequePropio.Text) Then
            MessageBox.Show("El cheque ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNroChequePropio.Focus()
            Return False
         End If
      Next

      If New Reglas.Cheques().Existe(actual.Sucursal.IdSucursal,
                                    Integer.Parse(Me.txtNroChequePropio.Text),
                                    Integer.Parse(Me.cmbBancoPropio.SelectedValue.ToString()),
                                    Integer.Parse(Me.txtSucursalBancoPropio.Text),
                                    Integer.Parse(Me.txtCodPostalChequePropio.Text),
                                    actual.Sucursal.Empresa.CuitEmpresa) Then
         MessageBox.Show("El Cheque fué Emitido con Anterioridad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroChequePropio.Focus()
         Return False
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

      If Me.cmbChequera.Items.Count = 0 Then
         ShowMessage("ATENCIÓN: No existen chequeras activas para la Cuenta Bancaria seleccionada.")
         Return False
      End If

      If Me.cmbChequera.SelectedIndex = -1 Then
         ShowMessage("ATENCIÓN: Debe seleccionar una Chequera.")
         Return False
      End If
      '# valido que el Nro. de Cheque se encuentre en el rango de la chequera
      Dim eChequera As Entidades.Chequera = DirectCast(Me.cmbChequera.SelectedItem, Entidades.Chequera)
      If CInt(Me.txtNroChequePropio.Text) > eChequera.NumeroHasta OrElse CInt(Me.txtNroChequePropio.Text) < eChequera.NumeroDesde Then
         ShowMessage("ATENCIÓN: El Nro. de Cheque ingresado no se encuentra en el rango de la chequera seleccionada.")

         Return False
      End If

      'Valida fecha cobro sea mayor a fecha emision
      If Me.dtpChequePropioCobro.Value.Date < Me.dtpChequePropioEmision.Value.Date Then
         Me.dtpChequePropioCobro.Focus()
         ShowMessage("La Fecha de Cobro NO puede ser menor a la Fecha de Emisión")
         Return False
      End If

      Return True

   End Function

   Private Sub InsertarChequePropioGrilla()

      Dim oLineaDetalle As Entidades.Cheque = New Entidades.Cheque()

      With oLineaDetalle
         .CuentaBancaria = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaPropio._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
         .Banco = New Reglas.Bancos().GetUno(Integer.Parse(Me.cmbBancoPropio.SelectedValue.ToString()))
         .IdBancoSucursal = Integer.Parse(Me.txtSucursalBancoPropio.Text)
         .Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalChequePropio.Text)
         .NumeroCheque = Integer.Parse(Me.txtNroChequePropio.Text)
         .FechaEmision = Me.dtpChequePropioEmision.Value
         .FechaCobro = Me.dtpChequePropioCobro.Value
         .Importe = Decimal.Parse(Me.txtImporteChequePropio.Text)
         .Proveedor.IdProveedor = _proveedor.IdProveedor
         .EsPropio = True
         .Usuario = actual.Nombre
         .IdTipoCheque = Me.cmbTipoCheque.SelectedValue.ToString()
         .NombreTipoCheque = Me.cmbTipoCheque.Text
         .NroOperacion = Me.txtNroOperacion.Text
         .Cuit = actual.Sucursal.Empresa.CuitEmpresa
         .IdChequera = CInt(Me.cmbChequera.SelectedValue)
      End With

      Me._chequesPropios.Add(oLineaDetalle)

      Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()
      Me.dgvChequesPropios.FirstDisplayedScrollingRowIndex = Me.dgvChequesPropios.Rows.Count - 1

      Me.dgvChequesPropios.Refresh()
      Me.LimpiarCamposChequePropio()
      Me.CalcularPagos()

   End Sub

   Private Sub EliminarLineaChequePropio()
      Me._chequesPropios.RemoveAt(Me.dgvChequesPropios.SelectedRows(0).Index)
      Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()
      Me.CalcularPagos()
   End Sub

   Private Sub LimpiarCamposChequePropio()
      Me.bscCuentaBancariaPropio.Text = ""
      Me.bscCuentaBancariaPropio.FilaDevuelta = Nothing
      _idCuentaBancariaSeleccionada = 0
      Me.cmbBancoPropio.SelectedIndex = -1
      Me.txtCodPostalChequePropio.Text = "0"
      Me.txtSucursalBancoPropio.Text = "0"
      Me.txtNroChequePropio.Text = "0"
      Me.dtpChequePropioCobro.Value = Date.Now
      Me.dtpChequePropioEmision.Value = Date.Now
      Me.txtImporteChequePropio.Text = "0.00"
      Me.cmbTipoCheque.SelectedValue = "F"

      Me.cmbChequera.DataSource = Nothing
      Me.txtNroOperacion.Clear()
   End Sub

   Private Sub CargarChequeCompleto(dr As DataGridViewRow)

      'Me.bscCuentaBancariaPropio.Datos = New Reglas.Bancos().Get1(Integer.Parse(dr.Cells("gchpIdCuentaBancaria").Value.ToString()))
      Me.bscCuentaBancariaPropio.Text = dr.Cells("gchpNombreCuentaBancaria").Value.ToString()
      Me.bscCuentaBancariaPropio.PresionarBoton()
      'Me.bscCuentaBancariaPropio.Selecciono = True
      'Me.cmbBancoPropio.SelectedValue = dr.Cells("gchpIdBanco").Value.ToString()
      'Me.txtCodPostalChequePropio.Text = dr.Cells("gchpCP").Value.ToString()
      'Me.txtSucursalBancoPropio.Text = dr.Cells("gchpIdBancoSucursal").Value.ToString()
      Me.txtNroChequePropio.Text = dr.Cells("gchpNumeroCheque").Value.ToString()
      Me.dtpChequePropioEmision.Value = Date.Parse(dr.Cells("gchpFechaEmision").Value.ToString())
      Me.dtpChequePropioCobro.Value = Date.Parse(dr.Cells("gchpFechaCobro").Value.ToString())
      Me.txtImporteChequePropio.Text = Decimal.Parse(dr.Cells("gchpImporte").Value.ToString()).ToString("#,##0.00")
      Me.cmbTipoCheque.SelectedValue = dr.Cells("IdTipoCheque").Value.ToString()
      Me.txtNroOperacion.Text = dr.Cells("NroOperacion").Value.ToString()
      Me.cmbChequera.SelectedValue = CInt(dr.Cells("IdChequera").Value)

   End Sub

   Private Sub EliminarLineaChequeTercero()
      Me._chequesTerceros.RemoveAt(Me.dgvChequesTerceros.SelectedRows(0).Index)
      Me.dgvChequesTerceros.DataSource = Me._chequesTerceros.ToArray()
      Me.CalcularPagos()
   End Sub

   Private Sub CalcularPagos()
      Dim pago As Decimal = 0
      Dim totcheq3ros As Decimal = 0
      Dim totcheqprop As Decimal = 0

      For i As Integer = 0 To Me._chequesPropios.Count - 1
         pago += Me._chequesPropios(i).Importe
         totcheqprop += Me._chequesPropios(i).Importe
      Next

      For i As Integer = 0 To Me._chequesTerceros.Count - 1
         pago += Me._chequesTerceros(i).Importe
         totcheq3ros += Me._chequesTerceros(i).Importe
      Next

      pago = Decimal.Round(pago, 2) +
               Decimal.Parse(Me.txtEfectivo.Text) +
               Decimal.Parse(Me.txtTarjetas.Text) +
               Decimal.Parse(Me.txtTransferenciaBancaria.Text) +
               Decimal.Parse(Me.txtRetenciones.Text)

      Me.txtTotalPago.Text = pago.ToString("#,##0.00")

      'VER DECIA TOTALCOMPROBANTES.TXT!!!!!!!!!!!!!!!!!
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - pago).ToString("#,##0.00")
      Me.txtChequesTerceros.Text = totcheq3ros.ToString("#,##0.00")
      Me.txtChequesTerceros2.Text = totcheq3ros.ToString("#,##0.00")
      Me.txtChequesPropios.Text = totcheqprop.ToString("#,##0.00")

      '- Decimal.Parse(Me.txtRetenciones.Text)
      Me.VerificarGrabarImprimir()
   End Sub

   Private Sub ActualizaGrillaChequesTerceros(dtCheques As DataTable)


      'Me._chequesTerceros.Clear()

      Dim blnInsertar As Boolean

      Dim oLineaDetalle As Entidades.Cheque

      'Siempre viene 1 registro, manejar directamente el datatable

      For Each cRow As DataRow In dtCheques.Rows
         oLineaDetalle = New Entidades.Cheque()
         With oLineaDetalle
            .IdCheque = cRow.Field(Of Long)(Entidades.Cheque.Columnas.IdCheque.ToString())
            .NumeroCheque = Integer.Parse(cRow("NumeroCheque").ToString())
            .Banco = New Reglas.Bancos().GetUno(Integer.Parse(cRow("IdBanco").ToString()))
            .IdBancoSucursal = Integer.Parse(cRow("IdBancoSucursal").ToString())
            .Localidad.IdLocalidad = Integer.Parse(cRow("IdLocalidad").ToString())
            .FechaEmision = Date.Parse(cRow("FechaEmision").ToString())
            .FechaCobro = Date.Parse(cRow("FechaCobro").ToString())
            .Titular = cRow("Titular").ToString()
            .Importe = Decimal.Parse(cRow("Importe").ToString())
            .Proveedor.IdProveedor = _proveedor.IdProveedor
            '.IdCajaIngreso = Int32.Parse(cRow("IdCajaIngreso").ToString())
            .Usuario = actual.Nombre
            .IdTipoCheque = cRow("IdTipoCheque").ToString()
            .NombreTipoCheque = cRow("NombreTipoCheque").ToString()
            .NroOperacion = cRow("NroOperacion").ToString()
            .Cuit = actual.Sucursal.Empresa.CuitEmpresa
         End With

         blnInsertar = True

         For i As Integer = 0 To Me._chequesTerceros.Count - 1
            If Me._chequesTerceros(i).NumeroCheque = Integer.Parse(cRow("NumeroCheque").ToString()) And
               Me._chequesTerceros(i).Banco.IdBanco = Integer.Parse(cRow("IdBanco").ToString()) And
               Me._chequesTerceros(i).IdBancoSucursal = Integer.Parse(cRow("IdBancoSucursal").ToString()) And
               Me._chequesTerceros(i).Localidad.IdLocalidad = Integer.Parse(cRow("IdLocalidad").ToString()) Then
               blnInsertar = False
               Exit For
            End If

         Next

         If blnInsertar Then

            Me._chequesTerceros.Add(oLineaDetalle)

         End If

      Next

      Me.dgvChequesTerceros.DataSource = Me._chequesTerceros.ToArray()
      Me.dgvChequesTerceros.FirstDisplayedScrollingRowIndex = Me.dgvChequesTerceros.Rows.Count - 1

      Me.dgvChequesTerceros.Refresh()
      'Me.LimpiarCamposChequesTerceros()
      Me.CalcularPagos()

   End Sub

   Private Sub VerificarGrabarImprimir()
      'Me.tsbGrabar.Enabled = (Decimal.Parse(Me.txtDiferencia.Text) <= 0)
   End Sub

   Private Sub CargarDatosCuentaBancaria(dr As DataGridViewRow)
      Me.bscCuentaBancariaPropio.Text = dr.Cells("NombreCuenta").Value.ToString()
      Me.cmbBancoPropio.SelectedValue = dr.Cells("IdBanco").Value
      Me.txtSucursalBancoPropio.Text = dr.Cells("IdBancoSucursal").Value.ToString.Trim()
      Me.txtCodPostalChequePropio.Text = dr.Cells("IdLocalidad").Value.ToString()
      'Me.txtNroChequePropio.Text = Me.ProximoChequeEmitido(Integer.Parse(dr.Cells("IdCuentaBancaria").Value.ToString())).ToString()

      '# Cargo el combo de chequeras disponibles según la Cuenta Bancaria seleccionada
      _idCuentaBancariaSeleccionada = CInt(dr.Cells("IdCuentaBancaria").Value)
      Me._publicos.CargaComboChequeras(Me.cmbChequera, _idCuentaBancariaSeleccionada)
   End Sub

   Private Function ProximoChequeEmitido(IdCuentaBancaria As Integer) As Long

      Dim Ultimo As Long = New Reglas.Cheques().GetUltimoEmitido(IdCuentaBancaria)

      Dim Proximo As Long = Ultimo

      'controlo que no se repita el cheque ingresado
      Dim ent As Entidades.Cheque
      For i As Integer = 0 To Me._chequesPropios.Count - 1
         ent = Me._chequesPropios(i)
         If ent.IdCuentaBancaria = IdCuentaBancaria And ent.NumeroCheque >= Proximo Then
            Proximo = ent.NumeroCheque
         End If
      Next

      Proximo += 1

      Return Proximo

   End Function

   Private Sub CalcularDiferenciaDePago()
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
   End Sub

   Private Sub CargarComprobantesFacturables(selec As List(Of Entidades.Compra))

      Me._comprobantesSeleccionados = New List(Of Entidades.Compra)

      For Each v As Entidades.Compra In selec
         Me._comprobantesSeleccionados.Add(v)

         If Me._cantMaxItemsObserv > 0 And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
            Me.bscObservacion.Text = "Invoco: " & v.TipoComprobante.Descripcion & " ´" & v.Letra & "´ " & v.CentroEmisor.ToString("0000") & "-" & v.NumeroComprobante.ToString("00000000") & ". Emision: " & v.Fecha.ToString("dd/MM/yyyy")

         End If
      Next

      If Me._comprobantesSeleccionados.Count > 0 Then
         If Me._InvocaPedido Then
            If Reglas.Publicos.MantieneFormaPagoPedidosProvInvocados Then
               Me.cboFormaPago.SelectedValue = Me._comprobantesSeleccionados(0).FormaPago.IdFormasPago
            End If
         End If
      End If


      Me.dgvfacturables.DataSource = Me._comprobantesSeleccionados.ToArray()

   End Sub

   Private Sub CargarProductosFacturables(selec As List(Of Entidades.Compra))

      'limpio todos los productos de la grilla
      Me._productos = Nothing
      Me._productos = New List(Of Entidades.MovimientoStockProducto)
      Me._productosRT = New List(Of Entidades.MovimientoStockProducto)

      'creo una coleccion para probar si existe codigos repetidos
      Dim codigos As List(Of String) = New List(Of String)

      Dim oSR As Reglas.SubRubros = New Reglas.SubRubros()

      Dim oCSR As Reglas.ClientesDescuentosSubRubros = New Reglas.ClientesDescuentosSubRubros()

      Dim blnEntrar As Boolean

      Dim CoefVal As Integer = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteValores

      'Si el invocador es una NCRED y A su vez Invoca Un comprobante Positivo debe multiplicar por 1 en lugar de -1.
      'Si es Factura es 1 asi que queda como invoca.
      If CoefVal = -1 And selec.Count > 0 Then
         If selec(0).TipoComprobante.CoeficienteValores = 1 Then
            CoefVal = 1
         End If
      End If

      '# Percepciones
      Dim percIVA As Decimal = 0
      Dim percIIBB As Decimal = 0
      Dim percGanancias As Decimal = 0
      Dim percVarias As Decimal = 0
      Dim percTotal As Decimal = 0
      Dim impInternos As Decimal = 0

      For Each v As Entidades.Compra In selec

         'En REMITO no tendria sentido que haya carga el descuento.
         'Poner el recargo general solo si cargo uno, si pone mas, se pierde.
         If selec.Count = 1 And Not v.TipoComprobante.CargaPrecioActual Then
            Me.txtDescuentoRecargoPorc.Text = v.DescuentoRecargoPorc.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            Me.txtPorcDescRecargoGral.Text = v.DescuentoRecargoPorc.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         End If

         For Each vp As Entidades.CompraProducto In v.ComprasProductos

            blnEntrar = True
            Me._numeroOrden += 1

            Dim oLineaDetalle = New Entidades.MovimientoStockProducto()
            With oLineaDetalle
               .IdProducto = vp.Producto.IdProducto
               .NombreProducto = vp.Producto.NombreProducto
               '--REQ-34986.- ---------------------------------------------
               .IdaAtributoProducto01 = vp.IdaAtributoProducto01
               .DescripcionAtributo01 = vp.DescripcionAtributo01
               .IdaAtributoProducto02 = vp.IdaAtributoProducto02
               .DescripcionAtributo02 = vp.DescripcionAtributo02
               .IdaAtributoProducto03 = vp.IdaAtributoProducto03
               .DescripcionAtributo03 = vp.DescripcionAtributo03
               .IdaAtributoProducto04 = vp.IdaAtributoProducto04
               .DescripcionAtributo04 = vp.DescripcionAtributo04
               .IdLote = vp.IdLote
               .InformeCalidadNumero = vp.InformeCalidadNumero
               .InformeCalidadLink = vp.InformeCalidadLink
               '---------------------------------------------------------
               .IdSucursal = vp.IdSucursal
               If vp.IdDeposito = 0 And vp.IdUbicacion = 0 Then
                  Dim rProdSucDepUbi = New Reglas.ProductosSucursales().ProductosSucursales_DepositoUbicacionDefecto(vp.IdSucursal, vp.Producto.IdProducto)
                  For Each dr As DataRow In rProdSucDepUbi.Rows

                     Dim rDeposito = New Reglas.SucursalesDepositosUsuarios()
                     If rDeposito.GetSeguridadUsuariosDepositos(Integer.Parse(dr("IdDepositoDefecto").ToString()), False).Rows.Count = 0 Then
                        Dim eDeposito = New Reglas.SucursalesDepositos().GetUno(Integer.Parse(dr("IdDepositoDefecto").ToString()), actual.Sucursal.IdSucursal)
                        MessageBox.Show(String.Format("ATENCION: No Posee autorización para el Deposito({0}).",
                                                      eDeposito.NombreDeposito), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                     End If
                     .IdDeposito = Integer.Parse(dr("IdDepositoDefecto").ToString())
                     .IdUbicacion = Integer.Parse(dr("IdUbicacionDefecto").ToString())
                  Next
               Else
                  .IdDeposito = vp.IdDeposito
                  .IdUbicacion = vp.IdUbicacion
               End If
               .NombreDeposito = New Reglas.SucursalesDepositos().GetUno(.IdDeposito, vp.IdSucursal).NombreDeposito
               .NombreUbicacion = New Reglas.SucursalesUbicaciones().GetUno(.IdDeposito, vp.IdSucursal, vp.IdUbicacion).NombreUbicacion
               If vp.IdDeposito > 0 Then
                  cmbDepositoOrigen.SelectedValue = vp.IdDeposito
               End If
               '---------------------------------------------------------
               .ProductoSucursal = New Reglas.ProductosSucursales().GetUno(vp.IdSucursal, vp.Producto.IdProducto)
               .DescuentoRecargoPorc = vp.DescuentoRecargoPorc
               .DescuentoRecargo = vp.DescuentoRecargo
               '--------------------------------------------------------------------------------------------------
               If v.TipoComprobante.CargaPrecioActual Then
                  Dim oCF As Entidades.CategoriaFiscal = Nothing

                  If Me._proveedor Is Nothing Then
                     oCF = Me._categoriaFiscalEmpresa
                  Else
                     oCF = Me._proveedor.CategoriaFiscal
                  End If

                  Dim PrecioVentaSinIVA As Decimal = 0
                  Dim PrecioVentaConIVA As Decimal = 0

                  Dim alicuota As Decimal = New Reglas.Productos().GetUno(vp.Producto.IdProducto).Alicuota

                  Dim prod As Entidades.ProductoSucursal = New Reglas.ProductosSucursales().GetUno(vp.IdSucursal, vp.Producto.IdProducto)

                  PrecioVentaSinIVA = prod.PrecioCosto
                  PrecioVentaConIVA = prod.PrecioCosto

                  'Si se guardan con IVA se lo quito, evito muchas preguntas posteriores.
                  If Reglas.Publicos.PreciosConIVA Then
                     PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA / (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
                  Else
                     PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
                  End If

                  If prod.Producto.Moneda.IdMoneda = 2 Then
                     PrecioVentaSinIVA = PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text)
                     PrecioVentaConIVA = PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text)
                  End If


                  'Exento sin IVA / Monotributo (por ahora lo dejo exento, mas sencillo para el IVA, pero deberia hacer lo mismo que facturacion.
                  If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
                     Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or
                     Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then

                     'If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                     '   .Precio = Decimal.Round(PrecioVentaConIVA / (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
                     'Else
                     .Precio = PrecioVentaConIVA
                     'End If
                     .PorcentajeIVA = 0
                  Else
                     .Precio = PrecioVentaSinIVA
                     .PorcentajeIVA = alicuota
                  End If
               Else
                  .Precio = vp.Precio
                  .PorcentajeIVA = vp.PorcentajeIVA

               End If

               '-------------------------------------
               .Cantidad = vp.Cantidad
               .CantidadUMCompra = vp.CantidadUMCompra
               .FactorConversionCompra = vp.FactorConversionCompra
               .PrecioPorUMCompra = vp.PrecioPorUMCompra
               .IdUnidadDeMedida = vp.Producto.UnidadDeMedida.IdUnidadDeMedida
               .IdUnidadDeMedidaCompra = vp.Producto.UnidadDeMedidaCompra.IdUnidadDeMedida

               Dim DescRecProd As Decimal = Decimal.Round((Decimal.Round(.Precio, Me._decimalesAMostrarEnPrecio) * .Cantidad * .DescuentoRecargoPorc / 100), Me._decimalesRedondeoEnPrecio)

               Dim ImporteTotal As Decimal = Math.Round((Decimal.Round(.Precio, Me._decimalesAMostrarEnPrecio) * .Cantidad) + DescRecProd, Me._decimalesRedondeoEnPrecio)

               .ImporteTotal = ImporteTotal
               .IVA = .ImporteTotal * .PorcentajeIVA / 100
               .TotalProducto = .ImporteTotal + .IVA
               If vp.Stock <> 0 Then
                  .Stock = vp.Stock
               Else
                  .Stock = 0
               End If
               .IdSucursal = vp.IdSucursal
               .Usuario = vp.Usuario

               .Orden = Me._numeroOrden

               '# Código del producto del proveedor seleccionado
               .CodigoProductoProveedor = vp.CodigoProductoProveedor
            End With

            '# Cargo el source según corresponda
            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
               Me._productosRT.Add(oLineaDetalle)
            Else
               Me._productos.Add(oLineaDetalle)
            End If

            If Not String.IsNullOrWhiteSpace(vp.IdLote) Then
               Dim pl = New Entidades.ProductoLote()

               pl.FechaVencimiento = vp.FechaVencimientoLote
               pl.PrecioCosto = vp.Precio

               pl.ProductoSucursal.Sucursal.IdSucursal = v.IdSucursal
               pl.ProductoSucursal.Producto.IdProducto = vp.Producto.IdProducto
               pl.Orden = vp.Orden
               pl.IdLote = vp.IdLote.ToUpper()

               pl.IdDeposito = vp.IdDeposito
               pl.IdUbicacion = vp.IdUbicacion

               pl.FechaIngreso = dtpFecha.Value

               pl.CantidadInicial = vp.Cantidad
               pl.CantidadActual = vp.Cantidad
               pl.Habilitado = True

               _productosLotes.Add(pl)
            End If

         Next

         '# Cargo los impuestos relacionados a la compra. En caso de ser +1 compra, las percepciones se van sumando. 
         percIVA += v.ComprasImpuestos.Where(Function(x) x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA.ToString()).Sum(Function(x) x.Importe)
         percIIBB += v.ComprasImpuestos.Where(Function(x) x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIIBB.ToString()).Sum(Function(x) x.Importe)
         percGanancias += v.ComprasImpuestos.Where(Function(x) x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PGANA.ToString()).Sum(Function(x) x.Importe)
         percVarias += v.ComprasImpuestos.Where(Function(x) x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PVAR.ToString()).Sum(Function(x) x.Importe)
         impInternos += v.ComprasImpuestos.Where(Function(x) x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT.ToString()).Sum(Function(x) x.Importe)

         '# IIBB discriminados x Provincia
         Me.IIBBxProvincia(v.ComprasImpuestos)
         Me.IIBBxProvincia(v.Retenciones)
         Me.txtPercepcionIIBB.ReadOnly = _dtProvincias.Select("Importe <> 0").Length > 1
         txtRetencionIIBB.ReadOnly = _dtProvinciasRetenciones.Any(Function(dr) dr.Field(Of Decimal)("Importe") <> 0)

         Me.txtPercepcionIVA.Text = percIVA.ToString()
         Me.txtPercepcionIIBB.Text = percIIBB.ToString()
         Me.txtPercepcionGanancias.Text = percGanancias.ToString()
         Me.txtPercepcionVarias.Text = percVarias.ToString()
         Me.txtImpuestosInternos.Text = impInternos.ToString()
         'txtPercepcionTotal.Text = (percIVA + percIIBB + percGanancias + percVarias + impInternos).ToString()
         txtPercepcionTotal.SetValor(percIVA + percIIBB + percGanancias + percVarias)
      Next

      'Elimino los de Cantidades en Cero (Puede suceder por una devolucion).
      Dim blnLlegoAlFin As Boolean = False
      Dim Cont As Integer
      Do While Not blnLlegoAlFin And Me._productos.Count > 0
         Cont = 0
         For Each pro In Me._productos
            If pro.Cantidad = 0 Then
               'Cada Vez que borro debo volver a Empezar porque se renumeran los indices y si continuo da error
               Me._productos.RemoveAt(Cont)
               Exit For
            End If
            Cont += 1
         Next
         If Cont = Me._productos.Count Then
            blnLlegoAlFin = True
         End If
      Loop
      '-- REQ-34986.- ------------------------------------------------------
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0 Then
         If Not _titProductos.ContainsKey("DescripcionAtributo01") Then _titProductos.Add("DescripcionAtributo01", "")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0 Then
         If Not _titProductos.ContainsKey("DescripcionAtributo02") Then _titProductos.Add("DescripcionAtributo02", "")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _titProductos.ContainsKey("DescripcionAtributo03") Then _titProductos.Add("DescripcionAtributo03", "")
      End If
      If _productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _titProductos.ContainsKey("DescripcionAtributo04") Then _titProductos.Add("DescripcionAtributo04", "")
      End If
      '---------------------------------------------------------------------
      Me.SetProductosDataSource()
      '------------------------------------------------------------------------

      ''# En caso que sea un remito
      If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
         SetProductosRTDataSource()
      End If

      Me.CalcularTotales()
      Me.tsbGrabar.Enabled = True

   End Sub

   Private Sub CargarComprobantesFacturablesCom(selec As List(Of Entidades.Compra))

      Me._comprobantesSeleccionados = New List(Of Entidades.Compra)

      For Each v As Entidades.Compra In selec
         Me._comprobantesSeleccionados.Add(v)

         If Me._cantMaxItemsObserv > 0 And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
            Me.bscObservacion.Text = "Invoco: " & v.TipoComprobante.Descripcion & " ´" & v.Letra & "´ " & v.CentroEmisor.ToString("0000") & "-" & v.NumeroComprobante.ToString("00000000") & ". Emision: " & v.Fecha.ToString("dd/MM/yyyy")
         End If

      Next

      Me.dgvfacturables.DataSource = Me._comprobantesSeleccionados.ToArray()

   End Sub

   'Private Sub CargarProductosFacturablesCom(selec As List(Of Entidades.Compra))

   '   'limpio todos los productos de la grilla
   '   Me._productosRT = Nothing
   '   Me._productosRT = New List(Of Entidades.MovimientoCompraProducto)

   '   Dim DescRec1 As Decimal, DescRec2 As Decimal
   '   Dim PrecioNeto As Decimal

   '   'creo una coleccion para probar si existe codigos repetidos
   '   Dim codigos As List(Of String) = New List(Of String)

   '   Dim Producto As Entidades.Producto

   '   Dim oSR As Reglas.SubRubros = New Reglas.SubRubros()
   '   Dim SubR As Entidades.SubRubro

   '   Dim oCSR As Reglas.ClientesDescuentosSubRubros = New Reglas.ClientesDescuentosSubRubros()

   '   Dim blnEntrar As Boolean

   '   Dim CoefVal As Integer = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteValores

   '   'Si el invocador es una NCRED y A su vez Invoca Un comprobante Positivo debe multiplicar por 1 en lugar de -1.
   '   'Si es Factura es 1 asi que queda como invoca.
   '   If CoefVal = -1 And selec.Count > 0 Then
   '      If selec(0).TipoComprobante.CoeficienteValores = 1 Then
   '         CoefVal = 1
   '      End If
   '   End If

   '   For Each v As Entidades.Compra In selec

   '      'En REMITO no tendria sentido que haya carga el descuento.
   '      'Poner el recargo general solo si cargo uno, si pone mas, se pierde.

   '      For Each vp As Entidades.MovimientoCompraProducto In v.ComprasProductos

   '         blnEntrar = True

   '         Producto = New Reglas.Productos().GetUno(vp.Producto.IdProducto)

   '         vp.Cantidad = vp.Cantidad * CoefVal

   '         'Los precios en la BASE siempre se guardan SIN IVA

   '         'Le agrego el IVA porque al momento de la grabacion se lo saca si cumple con esto. Se devuelve SIN IVA
   '         '1.
   '         'If Publicos.PreciosConIVA Then
   '         '   vp.PrecioLista = Decimal.Round((vp.PrecioLista * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
   '         '   vp.Costo = Decimal.Round((vp.Costo * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
   '         'End If

   '         'Indica si el comprobante elegido mantene el precio (PRESUPUESTO) o hay que cargar el actual (REMITO).
   '         If v.TipoComprobante.CargaPrecioActual Then

   '            'Si carga el precio actual y el mismo tiene valor. En los productos varios se deja en 0 (cero) para vender aquellos que no se detallan.
   '            If vp.Precio <> 0 Then
   '               'AHORA CAMBIA LA FORMA porque comente "1."
   '               If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
   '                  vp.Precio = Decimal.Round((vp.Precio * (1 + vp.PorcentajeIVA / 100)), Me._decimalesRedondeoEnPrecio)
   '               Else
   '                  vp.Precio = vp.Precio
   '               End If
   '            Else
   '               blnEntrar = False
   '               If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
   '                  vp.Precio = Decimal.Round((vp.Precio * (1 + vp.PorcentajeIVA / 100)), Me._decimalesRedondeoEnPrecio)
   '               End If
   '            End If

   '            'En REMITO no tendria sentido que haya carga el descuento.
   '            'vp.DescuentoRecargo = Decimal.Round((vp.Precio * vp.Cantidad * vp.DescuentoRecargoPorc / 100), Me._valorRedondeo)

   '            Producto = vp.Producto

   '            'Cargo el Descuento/Recargo cargado en el subrubro

   '            If Producto.IdSubRubro > 0 Then
   '               SubR = oSR.GetUno(Producto.IdSubRubro)
   '               vp.DescuentoRecargoPorc = SubR.DescuentoRecargo

   '            End If
   '            '---------------------------------------------------------------------------

   '         Else

   '            If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
   '               vp.Precio = Decimal.Round((vp.Precio * (1 + vp.PorcentajeIVA / 100)), Me._decimalesRedondeoEnPrecio)
   '            End If

   '         End If

   '         'Calculo el descuento Recargo CON/SIN IVA.
   '         DescRec1 = Decimal.Round((vp.Precio * vp.DescuentoRecargoPorc / 100), Me._decimalesRedondeoEnPrecio)

   '         vp.DescuentoRecargo = (DescRec1 + DescRec2) * vp.Cantidad

   '         'Calculo el Precio Neto CON/SIN IVA.
   '         PrecioNeto = vp.Precio + DescRec1 + DescRec2
   '         PrecioNeto = Decimal.Round(PrecioNeto * (1 + (v.DescuentoRecargoPorc / 100)), Me._decimalesRedondeoEnPrecio)
   '         'PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), Me._valorRedondeo)

   '         vp.PrecioNeto = PrecioNeto

   '         vp.ImporteTotal = (vp.Precio * vp.Cantidad) + vp.DescuentoRecargo

   '         'Solo se unifica en caso de facturar REMITOS, para presupuesto lo dejo separado porque ahora se puede digita separado.
   '         'Y en caso de NO poder modificar la descripcion del producto

   '         'If codigos.Contains(vp.Producto.IdProducto) And v.TipoComprobante.CargaPrecioActual And Not Publicos.FacturacionModificaDescripcionProducto And blnEntrar Then

   '         If codigos.Contains(vp.Producto.IdProducto) And v.TipoComprobante.CargaPrecioActual And Not vp.Producto.PermiteModificarDescripcion And blnEntrar Then
   '            Me._productosRT(codigos.IndexOf(vp.Producto.IdProducto)).Cantidad += vp.Cantidad
   '            Me._productosRT(codigos.IndexOf(vp.Producto.IdProducto)).ImporteTotal = Me._productosRT(codigos.IndexOf(vp.Producto.IdProducto)).Cantidad * Me._productosRT(codigos.IndexOf(vp.Producto.IdProducto)).Precio
   '         Else
   '            Me._numeroOrden += 1
   '            vp.Orden = Me._numeroOrden
   '            codigos.Add(vp.Producto.IdProducto)
   '            Me._productosRT.Add(vp)
   '         End If

   '      Next

   '   Next

   '   'Elimino los de Cantidades en Cero (Puede suceder por una devolucion).
   '   Dim blnLlegoAlFin As Boolean = False
   '   Dim Cont As Integer
   '   Do While Not blnLlegoAlFin And Me._productosRT.Count > 0
   '      Cont = 0
   '      For Each pro As Entidades.MovimientoCompraProducto In Me._productosRT
   '         If pro.Cantidad = 0 Then
   '            'Cada Vez que borro debo volver a Empezar porque se renumeran los indices y si continuo da error
   '            Me._comprasProductos.RemoveAt(Cont)
   '            Exit For
   '         End If
   '         Cont += 1
   '      Next
   '      If Cont = Me._comprasProductos.Count Then
   '         blnLlegoAlFin = True
   '      End If
   '   Loop
   '   '------------------------------------------------------------------------

   '   Me.dgvProductos.DataSource = Me._comprasProductos

   '   Me.tsbGrabar.Enabled = True

   'End Sub

   Private Sub LimpiarCamposObservDetalles()
      Me.bscObservacionDetalle.Text = ""
   End Sub

   Private Sub CargarObservacion(dr As DataGridViewRow)
      Me.bscObservacion.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub CargarObservDetalle(dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub CargarObservDetalleCompleto(dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("gobsObservacion").Value.ToString()
   End Sub

   Private Sub InsertarObservacion()

      Dim oLineaDetalle As Entidades.CompraObservacion = New Entidades.CompraObservacion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Linea = Me.dgvObservaciones.RowCount + 1
         .Observacion = Me.bscObservacionDetalle.Text
      End With

      Me._comprasObservaciones.Add(oLineaDetalle)

      Me.dgvObservaciones.DataSource = Me._comprasObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

      Me.LimpiarCamposObservDetalles()

      'Me.bscObservacionDetalle.Focus()

   End Sub

   Private Sub EliminarLineaObservacion()

      Me._comprasObservaciones.RemoveAt(Me.dgvObservaciones.SelectedRows(0).Index)
      Me.dgvObservaciones.DataSource = Me._comprasObservaciones.ToArray()

   End Sub

   Private Function ValidarInsertaObservacion() As Boolean

      If Me.dgvObservaciones.RowCount = Me._cantMaxItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = 0

      'Integer.Parse(IIf(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista, Me.dgvRemitoTransp.RowCount, Me.dgvProductos.RowCount).ToString())

      If LineasDetalle + Me.dgvObservaciones.RowCount = Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      Return True

   End Function

   Private Sub RenumerarObservacionesDetalle()

      Dim Linea As Integer = 0

      For Each vObs As Entidades.CompraObservacion In Me._comprasObservaciones
         Linea += 1
         vObs.Linea = Linea
      Next

      Me.dgvObservaciones.DataSource = Me._comprasObservaciones.ToArray()
      If Linea > 0 Then
         Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      End If
      Me.dgvObservaciones.Refresh()

   End Sub

   Private Sub CargarLineasPermitidas()

      If Me.cboTipoComprobante.SelectedValue IsNot Nothing Then

         Dim oComprobanteLetra As Entidades.TipoComprobanteLetra
         oComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(Me.cboTipoComprobante.SelectedValue.ToString(), Me.cboLetra.Text)

         'Toma las Lineas del reporte especifico.
         If oComprobanteLetra.TipoComprobante.IdTipoComprobante <> "" Then

            Me._cantMaxItems = oComprobanteLetra.CantidadItemsProductos
            Me._cantMaxItemsObserv = oComprobanteLetra.CantidadItemsObservaciones
            Me._imprime = oComprobanteLetra.Imprime

            'Toma las Lineas del Comprobante.
         Else

            Me._cantMaxItems = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItems
            Me._cantMaxItemsObserv = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItemsObserv
            Me._imprime = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).Imprime

         End If

      Else

         Me._cantMaxItems = 0
         Me._cantMaxItemsObserv = 0
         Me._imprime = False

      End If

      If Me._cantMaxItemsObserv > 0 Then
         If Not Me.tbcDetalle.TabPages.Contains(Me.tbpObservaciones) Then
            Me.tbcDetalle.TabPages.Add(Me.tbpObservaciones)
         End If
      Else
         If Me.tbcDetalle.TabPages.Contains(Me.tbpObservaciones) Then
            Me._comprasObservaciones.Clear()
            Me.dgvObservaciones.DataSource = Me._comprasObservaciones.ToArray()
            Me.tbcDetalle.TabPages.Remove(Me.tbpObservaciones)
         End If
      End If

   End Sub

   Private Sub CargarSaldosCtaCte()

      Dim oCtaCteProv As Reglas.CuentasCorrientesProvPagos = New Reglas.CuentasCorrientesProvPagos
      Dim idRubroCompra = 0

      Dim dt As DataTable
      dt = oCtaCteProv.GetSaldosCtaCte(-1, Nothing, _proveedor.IdProveedor, "", 0, "TODOS", idRubroCompra)

      Me.txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtSaldoCtaCteVencido.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      If dt.Rows.Count = 1 Then
         Me.txtSaldoCtaCte.Text = Decimal.Parse(dt.Rows(0)("Saldo").ToString()).ToString("##,##0.00")
         If Not String.IsNullOrEmpty(dt.Rows(0)("SaldoVencido").ToString()) Then
            Me.txtSaldoCtaCteVencido.Text = Decimal.Parse(dt.Rows(0)("SaldoVencido").ToString()).ToString("##,##0.00")
         End If
      End If

   End Sub

   Private Sub RecalcularTodo()

      Try

         If Me._productos IsNot Nothing Then

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            For Each pro In Me._productos

            Next

            Me.SetProductosDataSource()
            If Me.dgvProductos.Rows.Count > 0 Then
               Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            End If

            Me.dgvProductos.Refresh()

            Me.CalcularTotalProducto()

            Me.LimpiarCamposProductos()

            Me.CalcularTotales()

            Me.tsbGrabar.Enabled = True

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub


   Private Sub SeteaFormatosACampos()
      Me.txtPrecio.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
      Me.txtPrecioLista.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
      Me.txtDescuentoRecargo.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
      Me.txtDescuentoRecargoPorc.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
      Me.txtTotalProducto.Formato = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()
      Me.txtCantidad.Formato = "N" + _decimalesMostrarEnCantidad.ToString()

      '-- REQ-44315.- -----------------------------------------------------------------------
      txtCantidadUMCompra.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
      txtPrecioPorUMCompra.Formato = "##,##0." + New String("0"c, Me._decimalesMostrarEnCantidad)
      '--------------------------------------------------------------------------------------

      '# Length
      Me.txtPrecio.MaxLength = 8 + _decimalesAMostrarEnPrecio
      Me.txtPrecioLista.MaxLength = 8 + _decimalesAMostrarEnPrecio

      Dim formatoDecimal As String = ""

      formatoDecimal = "N" + Me._decimalesAMostrarEnPrecio.ToString()

      Me.dgvProductos.Columns("Precio").DefaultCellStyle.Format = formatoDecimal
      Me.dgvProductos.Columns("Importe").DefaultCellStyle.Format = formatoDecimal
      Me.dgvProductos.Columns("TotalProducto").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()

      txtTotalProducto.Enabled = _permiteModificarSubtotal
   End Sub

   Private Sub DisplayIndexProductoRT()
      DisplayIndexRT({Me.grtIdProducto, Me.grtProductoDesc, Me.grtNombreDeposito, Me.grtNombreUbicacion, Me.grtCantidad, Me.grtPrecio})
   End Sub

   Private Sub DisplayIndexRT(columnas As IEnumerable(Of DataGridViewColumn))
      Dim pos = 0
      columnas.ToList().ForEach(Sub(c)
                                   DisplayIndexRT(c, pos)
                                End Sub)
   End Sub
   Private Sub DisplayIndexRT(column As DataGridViewColumn, ByRef pos As Integer)
      dgvRemitoTransp.Columns(column.Name).DisplayIndex = pos
      pos += 1
      Console.WriteLine(String.Format("{1} : {0}", column.Name, pos))
   End Sub


   Private Sub DisplayIndexProducto()
      DisplayIndex({Me.NrosSerie,
                    Me.NrosLotes,
                    Me.IdProducto,
                    Me.NombreProducto,
                    Me.Cantidad,
                    Me.Precio,
                    Me.DescuentoRecargoPorc,
                    Me.DescuentoRecargo,
                    Me.Importe,
                    Me.TotalProducto,
                    Me.PorcentajeIVA,
                    Me.NombreDeposito,
                    Me.NombreUbicacion,
                    Me.IdUnidadDeMedida,
                    Me.IdUnidadDeMedidaCompra,
                    Me.CodigoProductoProveedor1,
                    Me.DescripcionAtributo01,
                    Me.DescripcionAtributo02,
                    Me.DescripcionAtributo03,
                    Me.DescripcionAtributo04,
                    Me.DescRecGeneral,
                    Me.Stock,
                    Me.IVAProducto,
                    Me.PorcVar,
                    Me.PrecioLista,
                    Me.Utilidad,
                    Me.Password,
                    Me.CentroEmisor,
                    Me.Costo,
                    Me.Usuario,
                    Me.NroComprobante,
                    Me.TipoDocumento,
                    Me.NroDocumento,
                    Me.IdSucursal,
                    Me.TipoComprobante,
                    Me.letra,
                    Me.Iva,
                    Me.MovimientoCompra,
                    Me.ProductoSucursal,
                    Me.colIdLote,
                    Me.VtoLote,
                    Me.Orden,
                    Me.PrecioO,
                    Me.PrecioCostoNuevo,
                    Me.PrecioVenta1,
                    Me.PorcentRecargo,
                    Me.PrecioVentaNuevo,
                    Me.IdConcepto,
                    Me.NombreConcepto,
                    Me.FechaActualizacion,
                    Me.CentroCosto,
                    Me.IdCentroCosto,
                    Me.NombreCentroCosto})
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

   Private Overloads Sub AjustarColumnasGrillaProductos()
      AjustarColumnasGrilla(dgvProductos, _titProductos)
      DisplayIndexProducto()

   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      AjustarColumnasGrilla(ugImpuestosDespacho, _tit)

      '# Lo pongo aca porque éste método es llamado solamente para ajustar la grilla de Impuesto Despacho.
      '# Quizas el nombre no es el más apropiado.
      Me.ugImpuestosDespacho.AgregarTotalesSuma({"Importe"})

   End Sub

   Private Sub CargarDatosDestinacion(dr As DataGridViewRow)
      bscCodigoDestinacion.Text = dr.Cells(Entidades.AduanaDestinacion.Columnas.IdDestinacion.ToString()).Value.ToString()
      bscDestinacion.Text = dr.Cells(Entidades.AduanaDestinacion.Columnas.NombreDestinacion.ToString()).Value.ToString()
   End Sub

   Private Sub CargarDatosDespachante(dr As DataGridViewRow)
      bscCodigoDespachante.Text = dr.Cells(Entidades.AduanaDespachante.Columnas.IdDespachante.ToString()).Value.ToString()
      bscDespachante.Text = dr.Cells(Entidades.AduanaDespachante.Columnas.NombreDespachante.ToString()).Value.ToString()
   End Sub

   Private Sub CargarDatosAduana(dr As DataGridViewRow)
      bscCodigoAduana.Text = dr.Cells(Entidades.Aduana.Columnas.IdAduana.ToString()).Value.ToString()
      bscAduana.Text = dr.Cells(Entidades.Aduana.Columnas.NombreAduana.ToString()).Value.ToString()
   End Sub

   Private Sub CargarDatosAgenteTransporte(dr As DataGridViewRow)
      bscCodigoAgenteTransporte.Text = dr.Cells(Entidades.AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString()).Value.ToString()
      bscAgenteTransporte.Text = dr.Cells(Entidades.AduanaAgenteTransporte.Columnas.NombreAgenteTransporte.ToString()).Value.ToString()
   End Sub

   Private Sub LimpiarCamposDepachoImpuestos()
      txtBaseImponibleDespacho.Text = "0.00"
      txtAlilcuotaDespacho.Text = "0.00"
      txtImporteDespacho.Text = "0.00"
   End Sub

   Private Sub FormatearGrilla()
      For Each dr As DataGridViewRow In Me.dgvProductos.Rows
         If IsNumeric(dr.Cells("PorcVar").Value) AndAlso Decimal.Round(Decimal.Parse(dr.Cells("PorcVar").Value.ToString()), _decimalesAMostrarEnPrecio) < 0 Then
            dr.Cells("PorcVar").Style.BackColor = Color.LightSkyBlue
         ElseIf Decimal.Round(Decimal.Parse(dr.Cells("PorcVar").Value.ToString()), _decimalesAMostrarEnPrecio) > 0 Then
            dr.Cells("PorcVar").Style.BackColor = Color.Coral
         Else
            dr.Cells("PorcVar").Style.BackColor = Color.LimeGreen
         End If
      Next
   End Sub


   Private Sub HabilitaIVA()
      HabilitaIVA(chbAjusteManualIVA.Checked)
   End Sub
   Private Sub HabilitaIVA(habilita As Boolean)
      If Not habilita Then
         ugIVAs.DisplayLayout.Bands(0).Columns(Entidades.CompraImpuesto.Columnas.Importe.ToString()).CellActivation = Activation.ActivateOnly
      Else
         ugIVAs.DisplayLayout.Bands(0).Columns(Entidades.CompraImpuesto.Columnas.Importe.ToString()).CellActivation = Activation.AllowEdit
      End If
   End Sub


   Private Sub ProductoFocus()
      If _comprasPosicionarNombreProducto Then
         Me.bscProducto2.Focus()
      Else
         Me.bscCodigoProducto2.Focus()
      End If
   End Sub

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

      txtCantidadUMCompraRT.SetValor(0)
      txtCantidadUMCompraRT.Tag = 0D
      'txtPrecioPorUMCrt.SetValor(0)
      txtUnidadesComprasRT.SetValor(0)

      pnlCantidadUMCRT.Visible = False
      'pnlPrecioPorUMCrt.Visible = False
      'pnlUnidadesUMCrt.Visible = False

   End Sub

   Private Sub CargarProductoRT(dr As DataGridViewRow)
      If dr IsNot Nothing Then

         Me.bscCodigoProducto2RT.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         Me.bscCodigoProducto2RT.Enabled = False

         Me.bscProducto2RT.Text = dr.Cells("NombreProducto").Value.ToString()
         Me.bscProducto2RT.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

         Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         Me._productoLoteTemporal = New Entidades.ProductoLote()

         Me._productoLoteTemporal.ProductoSucursal.Producto = producto

         Me.txtStockRT.Text = dr.Cells("Stock").Value.ToString()
         Me.txtStockRT.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

         Me.txtCantidadRT.Text = "1." + New String("0"c, Me._decimalesEnCantidad)

         Me.txtStockRT.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())
         If Boolean.Parse(dr.Cells("FacturacionCantidadNegativa").Value.ToString()) Then
            Me.txtCantidad.Text = "-1." + New String("0"c, Me._decimalesEnCantidad)
            Me.txtStockRT.Tag = False
         End If

         If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
            pnlCantidadUMCRT.Visible = True
            'pnlPrecioPorUMCRT.Visible = True
            'pnlUnidadesUMCRT.Visible = True
            txtCantidadUMCompraRT.Tag = producto.FactorConversionCompra
            txtCantidadUMCompraRT.SetValor(RequerimientosComprasDetalle.CalculaCantidadUMCDesdeCantidad(txtCantidadRT.ValorNumericoPorDefecto(0D), producto.FactorConversionCompra))
            'txtPrecioPorUMCRT.SetValor(txtPrecioRT.ValorNumericoPorDefecto(0D) / producto.FactorConversionCompra)
            txtUnidadesComprasRT.SetValor(txtCantidadRT.ValorNumericoPorDefecto(0D))
         End If


         If Not String.IsNullOrEmpty(dr.Cells("IdSubRubro").Value.ToString()) Then

            'Cargo el Descuento/Recargo cargado en el subrubro
            Dim oSR As Reglas.SubRubros = New Reglas.SubRubros()
            Dim SubR As Entidades.SubRubro

            SubR = oSR.GetUno(Integer.Parse(dr.Cells("IdSubRubro").Value.ToString()))
            DescRecPorc1RT = SubR.DescuentoRecargoPorc1

            'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
            Dim oCSR As Reglas.ClientesDescuentosSubRubros = New Reglas.ClientesDescuentosSubRubros()
            'Dim SubR2 As Entidades.SubRubro

            'SubR2 = oCSR.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdSubRubro").Value.ToString()))
            'DescRecPorc2RT = SubR2.DescuentoRecargo

         End If
         '---------------------------------------------------------------------------
         informeCalidad = If(producto.InformeControlCalidad AndAlso
                              DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).SolicitaInformeCalidad, True, False)
         '---------------------------------------------------------------------------
         'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
         Dim oCDM As Reglas.ClientesDescuentosMarcas = New Reglas.ClientesDescuentosMarcas()
         'Dim Marc As Entidades.Marca

         'Marc = oCDM.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdMarca").Value.ToString()))
         'If Marc.DescuentoRecargoPorc1 <> 0 Then
         '   If Decimal.Parse(Me.txtDescRecPorc1.Text) = 0 Then
         '      DescRecPorc1RT = Marc.DescuentoRecargoPorc1
         '   ElseIf DescRecPorc2RT = 0 Then
         '      DescRecPorc2RT = Marc.DescuentoRecargoPorc1
         '   End If
         'End If
         'If Marc.DescuentoRecargoPorc2 <> 0 Then
         '   If DescRecPorc1RT = 0 Then
         '      DescRecPorc1RT = Marc.DescuentoRecargoPorc2
         '   ElseIf DescRecPorc2RT = 0 Then
         '      DescRecPorc2RT = Marc.DescuentoRecargoPorc2
         '   End If
         'End If

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

         If (Me._proveedor.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
         Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            Me.txtPrecio.Tag = Me.txtPrecio.Text
         Else
            'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
            Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
            Me.txtPrecio.Tag = Me.txtPrecio.Text
         End If

         If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
            Navegar(txtCantidadUMCompraRT, data:=Nothing)
         Else
            Navegar(txtCantidadRT, data:=Nothing)
         End If
         'txtCantidadRT.Focus()
         'txtCantidadRT.SelectAll()

      End If
   End Sub

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
         Me.txtCantidadRT.Focus()
         Return False
      End If

      If Double.Parse(Me.txtCantidadRT.Text) < 0 And Boolean.Parse(Me.txtStockRT.Tag.ToString()) And Not Reglas.Publicos.Facturacion.FacturacionPermiteCantidadNegativa Then
         MessageBox.Show("No puede ingresar una cantidad negativa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidadRT.Focus()
         Return False
      End If

      If Double.Parse(Me.txtCantidadRT.Text) = 0 Then
         MessageBox.Show("La cantidad debe ser distinta de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidadRT.Focus()
         Return False
      End If

      If Me.dgvRemitoTransp.RowCount = Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas de Productos para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarRT.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.
      If Me.dgvRemitoTransp.RowCount + Me.dgvObservaciones.RowCount = Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarRT.Focus()
         Return False
      End If

      '*** Controlo la Facturacion Sin Stock ***

      'PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), ó invoco (no corresponde)
      'los valores posibles para el coeficientestock son 0, 1 y -1

      Dim blnControlarStock As Boolean = False

      If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0 Then

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
            Me.txtCantidadRT.Focus()
            Return False

         ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
            MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      End If

      '2 Parte. Del Producto ingreso mas lo que esta en la grilla.

      If Boolean.Parse(Me.txtStockRT.Tag.ToString()) And blnControlarStock Then

         Dim cantidadTotal As Decimal = Decimal.Parse(Me.txtCantidadRT.Text)

         For Each pro1 In Me._productosRT
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

   Private Sub InsertarProductoRT()
      Me._numeroOrden += 1
      Dim oLineaDetalle = New Entidades.MovimientoStockProducto()

      Dim costo As Decimal = 0
      Dim precioCosto As Decimal = 0
      Dim precioLista As Decimal = 0
      Dim stock As Decimal = 0

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

      alicuotaIVA = 0

      'Precio de Costo, Opciones: ACTUAL o PROMPOND;<meses>
      If Publicos.VentasPrecioCosto <> "ACTUAL" Then

         Dim CalculoCosto() As String = Publicos.VentasPrecioCosto.Split(";"c)

         Dim oCP As Reglas.ComprasProductos = New Reglas.ComprasProductos()

         Dim OtroPrecioCosto As Decimal = 0

         'Dejo preparado para distintas formas.
         If CalculoCosto(0) = "PROMPOND" Then
            OtroPrecioCosto = oCP.GetCostoPromedioPonderado(actual.Sucursal.Id,
                                                            Me.bscCodigoProducto2.Text,
                                                            Date.Today.AddMonths(Integer.Parse(CalculoCosto(1).ToString()) * (-1)),
                                                            Date.Today, decimalesRedondeoEnPrecio:=2)

            If OtroPrecioCosto <> 0 Then
               precioCosto = OtroPrecioCosto
            End If
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

      Dim precioProducto As Decimal = CDec(Me.txtPrecioRT.Text)
      Dim precioPorUMC = _precioPorUMCRT

      '##################
      '# Nros. De Serie #
      '##################
      oLineaDetalle.ProductoSucursal.Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2RT.Text)
      oLineaDetalle.Cantidad = CDec(Me.txtCantidadRT.Text)
      If oLineaDetalle.ProductoSucursal.Producto.NroSerie Then
         Me.CargarNumeroDeSerieProductosCompras(oLineaDetalle, Integer.Parse(cmbDepositoOrigenRT.SelectedValue.ToString()),
                                                               Integer.Parse(cmbUbicacionOrigenRT.SelectedValue.ToString()))
      End If

      With oLineaDetalle
         .IdProducto = Me.bscCodigoProducto2RT.Text
         .Cantidad = Decimal.Parse(Me.txtCantidadRT.Text)
      End With

      oLineaDetalle.InformeCalidadNumero = _InformeNumero.IfNull()
      oLineaDetalle.InformeCalidadLink = _InformeLink.IfNull()

      'ingreso los valores del Lote
      '##################
      '#     LOTES      #
      '##################
      If Me._productoLoteTemporal.ProductoSucursal.Producto.Lote And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> 0 Then
         Me.SeleccionDeLotes(oLineaDetalle, Me.txtNumeroLote.Text)
      End If

      'REG-36547.- -----------
      With oLineaDetalle
         .IdSucursal = _sucStock
         .IdDeposito = _depStock
         .IdUbicacion = _ubiStock
         .NombreDeposito = cmbDepositoOrigenRT.Text
         .NombreUbicacion = cmbUbicacionOrigenRT.Text
      End With
      '-----------------------

      'calculo el descuento total
      Dim descRecPorc1 As Decimal = DescRecPorc1RT
      Dim descRecPorc2 As Decimal = DescRecPorc2RT
      Dim descRecPorGeneral As Decimal = Decimal.Parse(Me.txtDescuentoRecargo.Text)

      'Fuerzo los calculos porque pudo no pasar Insertar sin los tab en los campos de descuento.
      Me.CalcularDescuentosProductosRT(precioLista)
      Me.CalcularTotalProductoRT(precioProducto)

      Dim descRecargo As Decimal = DescRecRT
      Dim importeTotal As Decimal = TotalProductoRT

      Dim centroCosto As Entidades.ContabilidadCentroCosto = Nothing

      Me.CalculaValoresRT(Decimal.Parse(Me.txtCantidadRT.Text), alicuotaIVA, precioProducto, descRecPorc1, descRecPorc2, descRecPorGeneral,
                        precioNeto, importeBruto, importeIva, importeTotal)


      Me.CargarUnArticulo(oLineaDetalle,
                          Me.bscCodigoProducto2RT.Text,
                          Me.bscProducto2RT.Text,
                          descRecPorc1,
                          descRecargo,
                          precioNeto,
                          Decimal.Parse(Me.txtCantidadRT.Text),
                          importeTotal,
                          stock,
                          txtCantidadUMCompraRT.ValorNumericoPorDefecto(0D),
                          txtCantidadUMCompraRT.TagNumericoPorDefecto(0D),                 'En txtCantidadUMCompraRT.Tag está el valor de Productos.FactorConversionCompra
                          precioPorUMC,
                          oLineaDetalle.ProductoSucursal.Producto.UnidadDeMedida.IdUnidadDeMedida,
                          oLineaDetalle.ProductoSucursal.Producto.UnidadDeMedidaCompra.IdUnidadDeMedida,
                          alicuotaIVA,
                          importeIva,
                          centroCosto)


      oLineaDetalle.Orden = Me._numeroOrden
      Me._productosRT.Add(oLineaDetalle)

      SetProductosRTDataSource()

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

      ReCalculaImpuestos()

      Me.CalcularTotales()
      Me.CalcularDatosDetalle()

      Me.CalcularTotalRemitoTransporte()

      Me.tsbGrabar.Enabled = True
      Me.bscCodigoProducto2RT.Focus()

   End Sub

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)

      Me.btnLimpiarProducto.Enabled = Habilitado
      Me.bscCodigoProducto2.Enabled = Habilitado
      Me.bscProducto2.Enabled = Habilitado
      Me.txtCantidad.Enabled = Habilitado
      Me.txtPrecio.Enabled = Habilitado
      Me.cmbPorcentajeIVA.Enabled = Habilitado
      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado

      'Por las que le toque habilitar, es factible que no corresponda
      If Habilitado Then
         Me.cmbPorcentajeIVA.Enabled = Me._proveedor.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos
      End If

      If Me.cboTipoComprobante.SelectedItem IsNot Nothing Then
         If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
            DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
            Me.cmbPorcentajeIVA.Enabled = False
         End If
      End If

   End Sub

   Private Sub EliminarLineaProductoRT()

      '# En caso que el producto tenga Nro. Serie, lo quito de la colección para que dicho Nro. pueda ser reutilizado 
      Me._productosNrosSeries.RemoveAll(Function(x)
                                           Return x.Producto.IdProducto = Me.dgvRemitoTransp.SelectedRows(0).Cells("grtIdProducto").Value.ToString() And x.OrdenCompra.Value = CInt(Me.dgvRemitoTransp.SelectedRows(0).Cells("grtOrden").Value)
                                        End Function)

      Me._productosRT.RemoveAt(Me.dgvRemitoTransp.SelectedRows(0).Index)

      SetProductosRTDataSource()

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

   Private Sub CambiarEstadoControlesDetalleRT(Habilitado As Boolean)

      Me.btnLimpiarProductoRT.Enabled = Habilitado
      Me.bscCodigoProducto2RT.Enabled = Habilitado
      Me.bscProducto2RT.Enabled = Habilitado
      Me.txtCantidadRT.Enabled = Habilitado
      Me.btnInsertarRT.Enabled = Habilitado
      Me.btnEliminarRT.Enabled = Habilitado

   End Sub

   Private Sub CargarDatosTransportista(dr As DataGridViewRow)
      Me.bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
      'Me.txtDireccionTransportista.Text = dr.Cells("DireccionTransportista").Value.ToString()
      'Me.txtLocalidadTransportista.Text = dr.Cells("NombreLocalidad").Value.ToString()
      'Me.txtTelefoTransportista.Text = dr.Cells("TelefonoTransportista").Value.ToString()

      Dim Transp As Reglas.Transportistas = New Reglas.Transportistas()
      Me._transportistaA = Transp.GetUno(Long.Parse(dr.Cells("IdTransportista").Value.ToString()))
   End Sub

   Private Sub CargarProductoCompletoRT(dr As DataGridViewRow,
                                        editarProductoDesdeGrilla As Boolean)

      Dim oProductos As Reglas.Productos = New Reglas.Productos

      Me.bscCodigoProducto2RT.Text = dr.Cells("grtIdProducto").Value.ToString.Trim()

      cmbDepositoOrigenRT.SelectedValue = Integer.Parse(dr.Cells("IdDeposito").Value.ToString())
      cmbUbicacionOrigenRT.SelectedValue = Integer.Parse(dr.Cells("IdUbicacion").Value.ToString())

      'Llamo al evento para cargar el objeto "FilaDevuelta" validado luego al insertar el producto.
      Me.bscCodigoProducto2RT.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2RT.Text.Trim(), actual.Sucursal.Id, _listaPreciosPredeterminada, "VENTAS", soloBuscaPorIdProducto:=editarProductoDesdeGrilla)
      Me.bscCodigoProducto2RT.PresionarBoton()

      If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(Me.bscCodigoProducto2RT.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
         'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
         Me.bscProducto2RT.Text = dr.Cells("DescripcionRT").Value.ToString()
      End If

      'Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
      Me.txtStockRT.Text = Me.bscCodigoProducto2RT.FilaDevuelta.Cells("Stock").Value.ToString()
      Me.txtTamanioRT.Text = Me.bscCodigoProducto2RT.FilaDevuelta.Cells("Tamano").Value.ToString()
      Me.txtUMRT.Text = Me.bscCodigoProducto2RT.FilaDevuelta.Cells("IdUnidadDeMedida").Value.ToString()

      Me.txtCantidadRT.Text = dr.Cells("grtCantidad").Value.ToString()
      Me.txtPrecioRT.Text = dr.Cells("grtPrecio").Value.ToString()


      If dr.Cells("IdLote").Value IsNot Nothing Then
         Me.txtNumeroLote.Text = dr.Cells("IdLote").Value.ToString()
      End If
      '----------------------------------------------
      If dr.Cells("InformeCalidadNumeroRT").Value IsNot Nothing Then
         _InformeNumero = dr.Cells("InformeCalidadNumeroRT").Value.ToString()
         _InformeLink = dr.Cells("InformeCalidadLinkRT").Value.ToString()
      End If
      '----------------------------------------------

      txtCantidadUMCompraRT.SetValor(dr.Cells(dgcProductosCantidadUMCRT.Name).ValorAs(0D))
      txtCantidadUMCompraRT.Tag = dr.Cells(dgcProductosFactorConversionCompraRT.Name).ValorAs(0D)
      _precioPorUMCRT = dr.Cells(dgcProductosPrecioPorUMCRT.Name).ValorAs(0D)
      txtUnidadesComprasRT.SetValor(dr.Cells("grtCantidad").ValorAs(0D))

   End Sub

   Private _precioPorUMCRT As Decimal

   Private Sub CalcularTotalProductoRT(PrecioLista As Decimal)
      TotalProductoRT = (PrecioLista * Decimal.Parse(Me.txtCantidadRT.Text)) + DescRecRT
   End Sub

   Private Sub CargarUnArticulo(linea As Entidades.MovimientoStockProducto,
                                idProducto As String,
                                productoDescripcion As String,
                                descuentoRecargoPorc1 As Decimal,
                                descuentoRecargo As Decimal,
                                precio As Decimal,
                                cantidad As Decimal,
                                importeTotal As Decimal,
                                stock As Decimal,
                                cantidadUMCompra As Decimal,
                                factorConversionCompra As Decimal,
                                precioPorUMCompra As Decimal,
                                idUnidadDeMedida As String,
                                idUnidadDeMedidaCompra As String,
                                porcentajeIva As Decimal,
                                importeIva As Decimal,
                                centroCosto As Entidades.ContabilidadCentroCosto)

      With linea
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .IdProducto = idProducto
         '.Producto = New Reglas.Productos().GetUno(idProducto)  'Luego uso ciertas caracteristicas (ej: LOTE).
         .NombreProducto = productoDescripcion   'Piso la descripcion por si tiene habilitado la posibilidad de cambiarlas.
         .DescuentoRecargoPorc = descuentoRecargoPorc1
         .DescuentoRecargo = descuentoRecargo
         .Precio = precio
         .Cantidad = cantidad
         .ImporteTotal = importeTotal
         .Stock = stock
         '.costo = costo
         '.PrecioLista = precioLista
         .CantidadUMCompra = cantidadUMCompra
         .FactorConversionCompra = factorConversionCompra
         .PrecioPorUMCompra = precioPorUMCompra
         .IdUnidadDeMedida = idUnidadDeMedida
         .IdUnidadDeMedidaCompra = idUnidadDeMedidaCompra
         '.Precio = precioNeto
         .PorcentajeIVA = porcentajeIva
         .IVA = importeIva
         .TotalProducto = .ImporteTotal + .IVA
         '.TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         '.ComisionVendedorPorc = 0
         '.ComisionVendedor = 0
         '.IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         '.NombreListaPrecios = Me.cmbListaDePrecios.Text
         '.FechaActualizacion = FechaActualizacion

         '.ModificoDescuentos = _descRecPorc1 <> descuentoRecargoPorc1 Or _descRecPorc2 <> descuentoRecargoPorc2
         '.ImporteImpuestoInterno = ImpuestoInterno

         .CentroCosto = centroCosto

      End With

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

      If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         importeIVA = Decimal.Round((precioNeto * cantidad) - (precioNeto * cantidad) / (1 + alicuotaIVASobre100), Me._decimalesRedondeoEnPrecio)
      Else
         importeIVA = Decimal.Round((precioNeto * cantidad) * alicuotaIVASobre100, Me._decimalesRedondeoEnPrecio)
      End If

   End Sub

   Private Sub CalcularDatosDetalle()

      If Me.idCategoriaFiscal = 0 Then Exit Sub

      'If Publicos.DescuentoMaximo > 0 And Decimal.Parse(Me.txtDescRecGralPorc.Text.ToString()) < 0 And Math.Abs(Decimal.Parse(Me.txtDescRecGralPorc.Text.ToString())) > Publicos.DescuentoMaximo Then
      '   MessageBox.Show("ATENCION: no puede asignar un Descuento mayor al: " & Publicos.DescuentoMaximo.ToString("N2") + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '   Me.txtDescRecGralPorc.Focus()
      '   Exit Sub
      'End If

      For Each vPro In Me._productosRT
         Dim importeTotalParaDescuento As Decimal
         If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
               DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
               importeTotalParaDescuento = vPro.ImporteTotal '- vPro.ImporteImpuestoInterno
            Else
               importeTotalParaDescuento = vPro.ImporteTotal
            End If
            ''precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
         Else
            importeTotalParaDescuento = vPro.ImporteTotal
         End If


         vPro.DescRecGeneral = Decimal.Round((importeTotalParaDescuento * Decimal.Parse(Me.txtDescuentoRecargo.Text) / 100), Me._decimalesRedondeoEnPrecio)

         Me.CalcularTotales()

      Next

      Me.dgvProductos.Refresh()
      Me.dgvRemitoTransp.Refresh()

      Me.RecalcularSubtotales()
      Me.CalcularTotales()

   End Sub

   Private Sub CalcularTotalRemitoTransporte()
      Me.txtValorDeclarado.Text = Me.txtTotalNeto.Text
      Me.txtTotalGeneral.Text = txtValorDeclarado.Text
      txtTotalGeneralCabecera.Text = txtTotalGeneral.Text
   End Sub

   Private Sub RecalcularSubtotales()

      'Me._subTotales.Clear()
      Dim olineaTotales As Entidades.VentaImpuesto
      Dim entro As Boolean = False

      Dim descRec1 As Decimal = 0
      Dim descRec2 As Decimal = 0
      Dim importeCosto As Decimal = 0
      Dim importeBruto As Decimal = 0
      Dim importeNeto As Decimal = 0
      Dim importeNetoTotal As Decimal = 0
      Dim Utilidad As Decimal = 0
      Dim impuestoInterno As Decimal = 0

      For Each dr In Me._productosRT

         'impuestoInterno = dr.ImporteImpuestoInterno

         Dim precioParaDescuento As Decimal
         If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
               DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
               Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
               precioParaDescuento = dr.Precio - (impuestoInterno / dr.Cantidad)
            Else
               precioParaDescuento = dr.Precio
            End If
         Else
            precioParaDescuento = dr.Precio
         End If

         'descRec1 = Decimal.Round(precioParaDescuento * dr.DescuentoRecargoPorc1 / 100, Me._decimalesRedondeoEnPrecio)
         'descRec2 = Decimal.Round((precioParaDescuento + descRec1) * dr.DescuentoRecargoPorc2 / 100, Me._decimalesRedondeoEnPrecio)

         Dim costo As Decimal = New Reglas.ProductosSucursales().GetUno(dr.IdSucursal, dr.IdProducto).PrecioCosto

         'If Publicos.PreciosConIVA Then
         '   'Le quito el IVA que el producto tiene en forma predeterminada.
         '   costo = Decimal.Round((costo - (dr.ImporteImpuestoInterno / dr.Cantidad)) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
         'End If

         'If dr.Producto.Moneda.IdMoneda = 2 Then
         '   costo = costo * Decimal.Parse(Me.txtCotizacionDolar.Text.ToString())

         'End If

         'If dr.Producto.PrecioPorEmbalaje Then
         '   dr.Costo = costo / dr.Producto.Embalaje
         'Else
         '   dr.Costo = costo
         'End If

         'importeCosto = dr.Costo * dr.Cantidad
         importeBruto = (dr.Precio + descRec1 + descRec2) * dr.Cantidad
         importeNeto = dr.Precio * dr.Cantidad

         'If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         '   importeBruto = Decimal.Round((importeBruto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
         '   importeNeto = Decimal.Round((importeNeto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
         'End If

         Utilidad += (importeNeto - importeCosto)
         importeNetoTotal += importeNeto

         entro = False

         'For Each vi As Entidades.VentaImpuesto In Me._subTotales
         '   If vi.Alicuota = dr.AlicuotaImpuesto And vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA Then
         '      vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA

         '      vi.Bruto += importeBruto
         '      vi.Neto += importeNeto

         '      vi.Importe += dr.ImporteImpuesto
         '      vi.Total += (importeNeto + dr.ImporteImpuesto)
         '      entro = True
         '   End If
         'Next
         If Not entro Then

            olineaTotales = New Entidades.VentaImpuesto()

            Me.CalcularTotales()

         End If

         If impuestoInterno <> 0 Then
            entro = False
            'For Each vi As Entidades.VentaImpuesto In Me._subTotales
            '   If vi.Alicuota = 0 And vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
            '      vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT

            '      vi.Bruto += 0
            '      vi.Neto += 0

            '      vi.Importe += impuestoInterno
            '      vi.Total += impuestoInterno
            '      entro = True
            '   End If
            'Next
            If Not entro Then

               olineaTotales = New Entidades.VentaImpuesto()

               Me.CalcularTotales()

            End If
         End If

      Next

      'Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      'If importeNetoTotal <> 0 Then

      '   Dim PorcentajeUtilidad As Decimal = Decimal.Round(Utilidad / importeNetoTotal * 100, Me._decimalesRedondeoEnPrecio)

      '   'Me.txtSemaforoRentabilidad.Text = PorcentajeUtilidad.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      '   Dim colo As Color = System.Drawing.Color.FromArgb(New Reglas.SemaforoVentasUtilidades().ColorSemaforo(PorcentajeUtilidad))

      '   'Me.txtSemaforoRentabilidad.BackColor = colo

      '   'If colo.ToArgb() = Color.Black.ToArgb() Then
      '   '   Me.txtSemaforoRentabilidad.ForeColor = Color.White
      '   'Else
      '   '   Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
      '   'End If

      '   'Me.txtSemaforoRentabilidad.Key = Utilidad.ToString()

      'Else

      '   Me.txtSemaforoRentabilidad.Text = ""
      '   Me.txtSemaforoRentabilidad.BackColor = Me.txtLetra.BackColor
      '   Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
      '   Me.txtSemaforoRentabilidad.Key = "0"

      'End If

   End Sub

   Private Sub CalcularDescuentosProductosRT(PrecioLista As Decimal)
      Dim DescRec1 As Decimal
      Dim DescRec2 As Decimal
      Dim DescRecT As Decimal

      DescRec1 = PrecioLista * DescRecPorc1RT / 100

      DescRec2 = (PrecioLista + DescRec1) * DescRecPorc2RT / 100

      DescRecT = Decimal.Round((DescRec1 + DescRec2) * Decimal.Parse(Me.txtCantidadRT.Text), Me._decimalesRedondeoEnPrecio)

      DescRecRT = DescRecT

   End Sub

   Private Sub SetPrecioCostoDesdePrecioCompra()
      If txtPrecioDolares.Visible Then
         txtPrecioDolares.Text = Math.Round(GetPrecioCostoDesdePrecioCompra(), _decimalesRedondeoEnPrecio).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
      Else
         txtPrecio.Text = Math.Round(GetPrecioCostoDesdePrecioCompra(), _decimalesRedondeoEnPrecio).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
      End If
      CalcularTotalProducto()
   End Sub

   Private Function GetPrecioCostoDesdePrecioCompra() As Decimal
      'Dim precioCosto As Decimal = 0
      Dim precioCompra As Decimal = 0
      Dim desc1 As Decimal = 0
      Dim desc2 As Decimal = 0
      Dim desc3 As Decimal = 0
      Dim desc4 As Decimal = 0

      Decimal.TryParse(Me.txtPrecioLista.Text, precioCompra)
      Decimal.TryParse(Me.txtDescuento1.Text, desc1)
      Decimal.TryParse(Me.txtDescuento2.Text, desc2)
      Decimal.TryParse(Me.txtDescuento3.Text, desc3)
      Decimal.TryParse(Me.txtDescuento4.Text, desc4)

      'precioCosto = precioCompra

      desc1 = precioCompra * desc1 / 100
      precioCompra = precioCompra + desc1

      desc2 = precioCompra * desc2 / 100
      precioCompra = precioCompra + desc2

      desc3 = precioCompra * desc3 / 100
      precioCompra = precioCompra + desc3

      desc4 = precioCompra * desc4 / 100
      precioCompra = precioCompra + desc4

      Return precioCompra
   End Function

#End Region

   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      If Me.cmbTipoCheque.SelectedIndex <> -1 Then
         If Not DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion Then
            Me.txtNroOperacion.Clear()
            Me.txtNroOperacion.Enabled = False
         Else
            Me.txtNroOperacion.Enabled = True
         End If
      Else
         Me.txtNroOperacion.Clear()
         Me.txtNroOperacion.Enabled = False
      End If
   End Sub

   Private Sub txtImpuestosInternos_Leave(sender As Object, e As EventArgs) Handles txtImpuestosInternos.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub GetProximoChequeDeChequera()
      '# Busco el siguiente número de cheque disponible en mi chequera
      Dim rChequeras As Reglas.Chequeras = New Reglas.Chequeras()
      Dim nxt As Integer = rChequeras.GetSiguienteChequeDisponible(_idCuentaBancariaSeleccionada, Me.cmbChequera.ValorSeleccionado(Of Integer))

      '# Antes de asignar el siguiente número, veo si no se encuentra ya agregado en la grilla
      Dim maxEnGrilla As Integer = 0
      If _chequesPropios.Count > 0 Then
         Dim cheques = _chequesPropios.Where(Function(c) c.IdCuentaBancaria = _idCuentaBancariaSeleccionada And c.IdChequera.IfNull() = cmbChequera.ValorSeleccionado(Of Integer))
         If cheques.Count() > 0 Then
            maxEnGrilla = cheques.Max(Function(c) c.NumeroCheque) + 1
         End If
      End If

      Me.txtNroChequePropio.Text = If(nxt >= maxEnGrilla, nxt.ToString(), maxEnGrilla.ToString())

      If Me.cmbChequera.Items.Count = 1 Then
         Me.txtNroChequePropio.Focus()
      End If
   End Sub

   Private Sub cmbChequera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChequera.SelectedIndexChanged
      Try
         If Me.cmbChequera.SelectedIndex <> -1 AndAlso Me.bscCuentaBancariaPropio.Selecciono Then
            Me.GetProximoChequeDeChequera()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dgvRemitoTransp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRemitoTransp.CellClick
      Try
         If Me.dgvRemitoTransp.Rows.Count = 0 Then Exit Sub

         If Me.dgvRemitoTransp.SelectedRows.Count = 0 Then Exit Sub

         '# Ver Lotes
         If Me.dgvRemitoTransp.Columns(e.ColumnIndex).Name = "NrosLote2" Then
            If Not DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.Lote Then
               ShowMessage("Este producto no utiliza Lote.")
               Exit Sub
            Else
               Dim eMCP As Entidades.MovimientoStockProducto = DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto)
               Me.SeleccionDeLotes(eMCP, loteSeleccionado:=eMCP.IdLote)
               Me.tsbGrabar.Enabled = True
            End If
         End If

         '# Ver NrosSerie
         If Me.dgvRemitoTransp.Columns(e.ColumnIndex).Name = "NrosSerie2" Then
            If e.RowIndex <> -1 Then
               If DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NroSerie Then

                  Dim cantidadDeProductos As Integer = DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NrosSeries.Count

                  Dim Ver As Boolean = True
                  Dim movProv = DirectCast(dgvRemitoTransp.SelectedRows(0).DataBoundItem, Entidades.MovimientoStockProducto)

                  If DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NrosSeries.Count <
                                                               DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto).Cantidad Then
                     cantidadDeProductos = CInt(DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto).Cantidad)



                     Me.CargarNumeroDeSerieProductosCompras(DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                               Entidades.MovimientoStockProducto), movProv.IdDeposito, movProv.IdUbicacion)

                  Else
                     Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos,
                                                                                         DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem,
                                                                                         Entidades.MovimientoStockProducto).ProductoSucursal.Producto,
                                                                                         _productosNrosSeries,
                                                                                         Ver,
                                                                                         Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()),
                                                                                         Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString()))
                     ins.ShowDialog()

                  End If


               Else
                  ShowMessage("Este producto no utiliza Nro. Serie.")
                  Exit Sub
               End If
            End If
         End If

         'If Me.dgvRemitoTransp.Columns(e.ColumnIndex).Name = "NrosSerie2" Then
         '   If Not DirectCast(DirectCast(Me.dgvRemitoTransp.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NroSerie Then
         '      ShowMessage("Este producto no utiliza Nro. Serie.")
         '      Exit Sub
         '   Else
         '      Dim movProv = DirectCast(dgvRemitoTransp.SelectedRows(0).DataBoundItem, Entidades.MovimientoStockProducto)
         '      Dim cantidadDeProductos As Integer = movProv.ProductoSucursal.Producto.NrosSeries.Count
         '      Dim Ver As Boolean = True
         '      Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos,
         '                                                               movProv.ProductoSucursal.Producto,
         '                                                               _productosNrosSeries,
         '                                                               Ver,
         '                                                               movProv.IdDeposito, movProv.IdUbicacion)
         '      ins.ShowDialog()
         '      Me.tsbGrabar.Enabled = True
         '   End If
         'End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      _depStock = 0
      If cmbDepositoOrigen.SelectedValue IsNot Nothing Then
         _depStock = Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString())
         _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, _depStock, _sucStock)
         cmbUbicacionOrigen.SelectedIndex = 0
      End If
   End Sub

   Private Sub cmbDepositoOrigenRT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigenRT.SelectedIndexChanged
      'If Not _cargaComboDestino Then
      _depStock = Integer.Parse(cmbDepositoOrigenRT.SelectedValue.ToString())
      _publicos.CargaComboUbicaciones(cmbUbicacionOrigenRT, _depStock, _sucStock)
      cmbUbicacionOrigenRT.SelectedIndex = 0
      'End If
   End Sub
   Private Sub cmbUbicacionOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionOrigen.SelectedIndexChanged
      If Not _cargaComboDestino Then
         If cmbUbicacionOrigen.SelectedValue Is Nothing Then
            _ubiStock = 0
         Else
            _ubiStock = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
         End If
         Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(_depStock, _sucStock, _ubiStock, bscCodigoProducto2.Text())
         If dt.Rows.Count > 0 Then
            txtStock.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
         End If
      End If
   End Sub

   Private Sub cmbUbicacionOrigenRT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionOrigenRT.SelectedIndexChanged
      If Not _cargaComboDestino Then
         If cmbUbicacionOrigenRT.SelectedValue Is Nothing Then
            _ubiStock = 0
         Else
            _ubiStock = Integer.Parse(cmbUbicacionOrigenRT.SelectedValue.ToString())
         End If
         Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(_depStock, _sucStock, _ubiStock, bscCodigoProducto2RT.Text())
         If dt.Rows.Count > 0 Then
            txtStockRT.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
         End If
      End If
   End Sub

   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Throw New NotImplementedException()
   End Function

   Public Sub EvaluaMuestraCantidadUMCompraRT()
      Dim algunProductoConUMC = dgvRemitoTransp.DataSource(Of IEnumerable(Of Entidades.MovimientoStockProducto)).AnySecure(Function(rq) rq.FactorConversionCompra <> 0)
      dgvRemitoTransp.Columns(dgcProductosCantidadUMCRT.Name).Visible = algunProductoConUMC
      dgvRemitoTransp.Columns(dgcProductosFactorConversionCompraRT.Name).Visible = False
      dgvRemitoTransp.Columns(dgcProductosPrecioPorUMCRT.Name).Visible = False
   End Sub
   Public Sub EvaluaMuestraCantidadUMC()
      Dim algunProductoConUMC = dgvProductos.DataSource(Of IEnumerable(Of Entidades.MovimientoStockProducto)).AnySecure(Function(rq) rq.FactorConversionCompra <> 0)
      dgvProductos.Columns(dgcProductosCantidadUMC.Name).Visible = algunProductoConUMC
      dgvProductos.Columns(dgcProductosFactorConversionCompra.Name).Visible = False
      dgvProductos.Columns(dgcProductosPrecioPorUMC.Name).Visible = algunProductoConUMC
   End Sub

#Region "IFormConNavegacion Methods - Navegación"
   Private Sub presionarTab_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoCheque.KeyDown, txtNroOperacion.KeyDown, cboTipoComprobante.KeyDown, cboLetra.KeyDown, txtEmisorFactura.KeyDown, txtNumeroFactura.KeyDown,
                                                                                 dtpFecha.KeyDown, cboPeriodoFiscal.KeyDown, cmbComprador.KeyDown, cboFormaPago.KeyDown, cboRubro.KeyDown, txtEfectivo.KeyDown,
                                                                                 chbSinProductos.KeyDown, chbAjusteManualIVA.KeyDown, txtPorcDescRecargoGral.KeyDown,
                                                                                 txtPercepcionIVA.KeyDown, txtPercepcionIIBB.KeyDown, txtPercepcionGanancias.KeyDown, txtPercepcionVarias.KeyDown, txtImpuestosInternos.KeyDown,
                                                                                 txtRetencionIVA.KeyDown, txtRetencionIIBB.KeyDown, txtRetencionGanancias.KeyDown,
                                                                                 txtCodPostalChequePropio.KeyDown, dtpChequePropioEmision.KeyDown, dtpChequePropioCobro.KeyDown, txtImporteChequePropio.KeyDown, txtNroChequePropio.KeyDown, txtSucursalBancoPropio.KeyDown,
                                                                                 txtNumeroDespacho.KeyDown, txtImporteDespacho.KeyDown, txtDigitoVerificador.KeyDown, txtDerechoAduana.KeyDown, txtBaseImponibleDespacho.KeyDown, txtAlilcuotaDespacho.KeyDown, dtpFechaOficializacion.KeyDown, chbBienCapital.KeyDown, txtNumeroManifiesto.KeyDown, txtNumeroManifiesto.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub navegacionConEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles _
                                       txtProductoObservacion.KeyDown, txtCantidad.KeyDown, txtPrecio.KeyDown, txtPrecioDolares.KeyDown, txtDescuentoRecargoPorc.KeyDown, txtDescuentoRecargo.KeyDown, cmbPorcentajeIVA.KeyDown,
                                       txtCantidadUMCompra.KeyDown, txtPrecioPorUMCompra.KeyDown, txtUnidadesCompras.KeyDown, cmbConceptos.KeyDown, cmbCentroCosto.KeyDown,
                                       txtPrecioLista.KeyDown, txtDescuento1.KeyDown, txtDescuento2.KeyDown, txtDescuento3.KeyDown, txtDescuento4.KeyDown,
                                       txtBultos.KeyDown, txtValorDeclarado.KeyDown, txtNumeroLote.KeyDown, txtCantidadRT.KeyDown, txtCantidadUMCompraRT.KeyDown, txtUnidadesComprasRT.KeyDown  'RT
      TryCatched(Sub() If TypeOf (sender) Is Control Then NavegacionConEnter(e, DirectCast(sender, Control)))
   End Sub

   ''' <summary>
   ''' Permite ordenar la navegación con ENTER cuando la misma requiere de alguna lógica y no se puede manejar con un simple PresionarTab(e). Navegación codicional, si está activo el control destino paso a ese, sino a otro.
   ''' </summary>
   ''' <param name="controlOrigen">Control donde se presiona ENTER</param>
   ''' <param name="data">Implementación de IDatosNavegacion. Podría ser requerida para la navegación. Generalmente es NULL, pero podría tener una instancia.</param>
   ''' <remarks>
   ''' Lo que nos importa definir aquí es como es el flujo de navegación de la pantalla. O sea, dado un control, a donde debe viajar el foco cuando presiono ENTER.
   ''' La navegacuón la pudo haber ejecutado un Evento de KeyDown o un llamado en el código ejecutando, tipicamente, Navegar(ctrl, data) donde ctrl es a donde deseo navegar y 
   ''' data cualquier información que pudiera ser necesaria para tomar deciciones de navegación.
   ''' En caso de que el control al que se desea Navegar esté habilitado, visible y editable (Not ReadOnly) hace foco en el mismo.
   ''' En caso de que el control destino no se pueda navegar ejecuta la navegación hacial el siguiente control (NavegacionConEnter)
   ''' El parametro ControlOrigen es la instancia que está solicitando la navegación. Entra en el IF y evalua a que control debe navegar naturalmente sin preocuparse si está o no habilitado.
   ''' 
   ''' Ejemplo:
   '''      Enter en txtCantidad. Naturalmente debe navegar a txtPrecio.
   '''      Se evalua que el txtPrecio esté disponible. Si lo está, hace Focus() allí. En caso de que no esté disponible busca a donde debería naturalmente navegar, supongamos txtDescRecPorc.
   '''      Se evalua que el txtDescRecPorc esté disponible. Si lo está, hace Focus() allí. En caso de que no esté disponible busca a donde debería naturalmente navegar, supongamos txtDescRec.
   '''      Se evalua que el txtDescRec esté disponible. Si lo está, hace Focus() allí. En caso de que no esté disponible busca a donde debería naturalmente navegar, supongamos btnInsertar.
   '''      
   '''      Escenario 1: txtPrecio está Disponible
   '''         Luego de txtCantidad hace foco en txtPrecio
   '''
   '''      Escenario 2: txtPrecio, txtDescRecPorc y txtDescRec NO están Disponibles
   '''         Luego de txtCantidad hace foco en btnInsertar
   ''' </remarks>
   Public Sub NavegacionConEnter(controlOrigen As Control, data As IDatosNavegacion) Implements IFormConNavegacion.NavegacionConEnter
      If controlOrigen.Equals(txtCantidad) Then
         NavegarPrecio(data)     ' Tengo un método específico porque la lógica es compleja y se usa más de una vez
      ElseIf controlOrigen.Equals(txtPrecioDolares) Then
         Navegar(txtPrecio, data)
      ElseIf controlOrigen.Equals(txtPrecio) Then
         Navegar(txtDescuentoRecargoPorc, data)
      ElseIf controlOrigen.Equals(txtDescuentoRecargoPorc) Then
         Navegar(txtDescuentoRecargo, data)
      ElseIf controlOrigen.Equals(txtDescuentoRecargo) Then
         Navegar(cmbPorcentajeIVA, data)
      ElseIf controlOrigen.Equals(cmbPorcentajeIVA) Then
         Navegar(btnInsertar, data)

      ElseIf controlOrigen.Equals(cmbConceptos) Then
         Navegar(cmbCentroCosto, data)
      ElseIf controlOrigen.Equals(cmbCentroCosto) Then
         Navegar(btnInsertar, data)

      ElseIf controlOrigen.Equals(txtProductoObservacion) Then
         Navegar(txtCantidadUMCompra, data)

      ElseIf controlOrigen.Equals(txtCantidadUMCompra) Then
         Navegar(txtPrecioPorUMCompra, data)
      ElseIf controlOrigen.Equals(txtPrecioPorUMCompra) Then
         Navegar(txtUnidadesCompras, data)
      ElseIf controlOrigen.Equals(txtUnidadesCompras) Then
         Navegar(txtCantidad, data)

      ElseIf controlOrigen.Equals(txtPrecioLista) Then
         Navegar(txtDescuento1, data)
      ElseIf controlOrigen.Equals(txtDescuento1) Then
         Navegar(txtDescuento2, data)
      ElseIf controlOrigen.Equals(txtDescuento2) Then
         Navegar(txtDescuento3, data)
      ElseIf controlOrigen.Equals(txtDescuento3) Then
         Navegar(txtDescuento4, data)
      ElseIf controlOrigen.Equals(txtDescuento4) Then
         NavegarPrecio(data)

      ElseIf controlOrigen.Equals(txtBultos) Then
         Navegar(txtValorDeclarado, data)
      ElseIf controlOrigen.Equals(txtValorDeclarado) Then
         Navegar(bscTransportista, data)
      ElseIf controlOrigen.Equals(bscTransportista) Then
         Navegar(txtNumeroLote, data)
      ElseIf controlOrigen.Equals(txtNumeroLote) Then
         Navegar(bscProducto2RT, data)

      ElseIf controlOrigen.Equals(bscProducto2RT) Or controlOrigen.Equals(bscCodigoProducto2RT) Then
         Navegar(txtCantidadUMCompraRT, data)
      ElseIf controlOrigen.Equals(txtCantidadUMCompraRT) Then
         Navegar(txtUnidadesComprasRT, data)
      ElseIf controlOrigen.Equals(txtUnidadesComprasRT) Then
         Navegar(txtCantidadRT, data)
      ElseIf controlOrigen.Equals(txtCantidadRT) Then
         Navegar(btnInsertarRT, data)

      End If
   End Sub

   Private Sub NavegarPrecio(data As IDatosNavegacion)
      If grpPrecioDolares.Visible And txtPrecioDolares.Visible And txtPrecioDolares.Enabled Then
         Navegar(txtPrecioDolares, data)  ' txtPrecioDolares.Focus()
      Else
         Navegar(txtPrecio, data)         ' txtPrecio.Focus()
      End If
   End Sub

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
            CalcularPagos()
         End If
      End Sub)
   End Sub
   Private Sub btnQuitarImporteTransfMultiple_Click(sender As Object, e As EventArgs) Handles btnQuitarImporteTransfMultiple.Click
      TryCatched(
      Sub()
         If ugTransferenciasMultiples.ActiveRow IsNot Nothing Then
            QuitarTransferenciaMultiple()
            CalcularPagos()
         End If
      End Sub)
   End Sub

   Private Sub InsertarTransferenciaMultiple()
      If _transferencias Is Nothing Then _transferencias = New List(Of Entidades.CompraTransferencia)
      _transferencias.Add(New Entidades.CompraTransferencia With
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
      Dim dr = ugTransferenciasMultiples.FilaSeleccionada(Of Entidades.CompraTransferencia)
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
               '  dtpFechaTransferencia.Select()
            End If
         End Sub)
   End Sub

   Private Sub btnInsertarCuponesTarjetas_Click(sender As Object, e As EventArgs) Handles btnInsertarCuponesTarjetas.Click
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(Reglas.Publicos.ComprasProductoLiquidacionTarjetas) Then
            Throw New Exception("No está configurado ningún producto como 'Cod. De Prod. Totalizar Cupones (Liq. Tarj.)' en Parametros -> Compras")
         End If
         If Not New Reglas.Productos().Existe(Reglas.Publicos.ComprasProductoLiquidacionTarjetas) Then
            Throw New Exception(String.Format("El producto como 'Cod. De Prod. Totalizar Cupones (Liq. Tarj.)' en Parametros -> Compras: '{0}' no existe en el sistema", Reglas.Publicos.ComprasProductoLiquidacionTarjetas))
         End If
         Using frm = New CajaDetallesAyudaCuponesTarjetas()
            Dim estados = {Entidades.TarjetaCupon.Estados.ENCARTERA, Entidades.TarjetaCupon.Estados.ACREDITADO}
            frm.cajaCupones = Integer.Parse(cmbCajas.SelectedValue.ToString())
            If frm.ShowDialog(Me, estados) = DialogResult.OK Then
               SetCuponesTarjetasDataSource(frm.CuponesSeleccionados)
               SetTotalCupones()
            End If
         End Using
      End Sub)
   End Sub

   Private Sub btnEliminarCuponesTarjetas_Click(sender As Object, e As EventArgs) Handles btnEliminarCuponesTarjetas.Click
      TryCatched(
      Sub()
         Dim drs = ugCuponesTarjetas.FilasSeleccionadas(Of DataRow)
         If drs.AnySecure() Then
            If ShowPregunta("¿Desea eliminar los cupones seleccionados?") = DialogResult.Yes Then
               drs.ForEachSecure(Sub(dr) dr.Delete())
               ugCuponesTarjetas.DataSource(Of DataTable).AcceptChanges()
               ugCuponesTarjetas.Rows.Refresh(RefreshRow.ReloadData)
               SetTotalCupones()
            End If
         Else
            ShowMessage("Debe seleccionar al menos un cupón para poder eliminar.")
         End If
      End Sub)
   End Sub
   Private Sub SetCuponesTarjetasDataSource(dt As DataTable)
      Dim tit = GetColumnasVisiblesGrilla(ugCuponesTarjetas)
      ugCuponesTarjetas.DataSource = dt
      AjustarColumnasGrilla(ugCuponesTarjetas, tit)
   End Sub
   Private Sub SetTotalCupones()
      Dim totalEnCartera = ugCuponesTarjetas.DataSource(Of DataTable).
                                       Where(Function(dr) dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString()) = Entidades.TarjetaCupon.Estados.ENCARTERA.ToString()).
                                       SumSecure(Function(dr) dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())).IfNull()
      Dim totalAcreditado = ugCuponesTarjetas.DataSource(Of DataTable).
                                       Where(Function(dr) dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString()) = Entidades.TarjetaCupon.Estados.ACREDITADO.ToString()).
                                       SumSecure(Function(dr) dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())).IfNull()
      Dim totalCupones = totalEnCartera + totalAcreditado

      txtTotalEnCartera.SetValor(totalEnCartera)
      txtTotalAcreditado.SetValor(totalAcreditado)
      txtTotalCupones.SetValor(totalCupones)


      Dim msp = _productos.Where(Function(dr) dr.IdProducto = Reglas.Publicos.ComprasProductoLiquidacionTarjetas)
      If msp.AnySecure() Then
         EliminarLineaProducto(msp.First())
      End If

      tbcDetalle.SelectedTab = tbpProductos
      bscCodigoProducto2.Text = Reglas.Publicos.ComprasProductoLiquidacionTarjetas
      bscCodigoProducto2.PresionarBoton()

      txtPrecio.SetValor(totalCupones)
      txtTotalProducto.SetValor(totalCupones)

      btnInsertar.Focus()
      btnInsertar.PerformClick()

      tbcDetalle.SelectedTab = tbpCuponesTarjetas

      txtTotalGeneralCabecera.Text = (totalCupones).ToString("N2")
   End Sub

   Private Sub chbNroOrdenDeCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroOrdenDeCompra.CheckedChanged
      TryCatched(Sub() chbNroOrdenDeCompra.FiltroCheckedChanged(usaPermitido:=True, bscNroOrdenDeCompra))
   End Sub

   Private Sub bscNroOrdenDeCompra_BuscadorClick() Handles bscNroOrdenDeCompra.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaOrdenDeCompra(bscNroOrdenDeCompra)
            Dim nroOrdenDeCompra = bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L)
            bscNroOrdenDeCompra.Datos = New Reglas.OrdenesCompra().GetPorCodigo(actual.Sucursal.Id, nroOrdenDeCompra)
         End Sub)
   End Sub

   Private Sub bscNroOrdenDeCompra_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNroOrdenDeCompra.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               bscNroOrdenDeCompra.Text = e.FilaDevuelta.Cells("NumeroOrdenCompra").Value.ToString()
               bscNroOrdenDeCompra.Permitido = False
            End If
         End Sub)
   End Sub

   Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
      If Reglas.Publicos.UtilizaPrecioDeCompra Then
         txtPrecioLista.Focus()
      Else
         txtPrecio.Focus()
      End If
   End Sub

   Private Sub txtDescuento4_Leave(sender As Object, e As EventArgs) Handles txtDescuento4.Leave
      TryCatched(Sub() SetPrecioCostoDesdePrecioCompra())
      If Reglas.Publicos.UtilizaPrecioDeCompra Then
         txtPrecio.Focus()
      End If
   End Sub


#End Region
End Class