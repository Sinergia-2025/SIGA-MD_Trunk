#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Collections.Generic
Imports System.Text
Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class MovimientosDeCompras

#Region "Campos"

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titRemitoTransporte As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private _utilizaCentroCostos As Boolean = False
   Private _permiteCambiarCentroCostosCompras As Boolean = False

   Private _estado As Estados
   Private _publicos As Publicos
   Private idCategoriaFiscal As Short
   Private _productos As System.Collections.Generic.List(Of Entidades.MovimientoCompraProducto)
   Private _productosRT As System.Collections.Generic.List(Of Entidades.MovimientoCompraProducto)
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

   'vml 30/09/12 - contabilidad
   Public _tablaAsientos As DataTable

   Private _decimalesAMostrarEnTotalXProducto As Integer
   Private _decimalesAMostrarEnPrecio As Integer
   Private _decimalesRedondeoEnPrecio As Integer   '4
   Private _decimalesEnCantidad As Integer = 2
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
   Private _blnMiraPC As Boolean = Not Publicos.ComprasIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True
   Private _ConfiguracionImpresoras As Boolean

   Private _comprasImpuestosDespachoImportacion As List(Of Entidades.CompraImpuesto)

   Private _ModificaDetalle As String
   Private _ModificaDetalleRT As String
   Private DescRecPorc1RT As Decimal = 0
   Private DescRecPorc2RT As Decimal = 0

   Private TotalProductoRT As Decimal = 0
   Private DescRecRT As Decimal = 0

   Private _transportistaA As Entidades.Transportista
   Private _CodigoProductoProveedor As String
   Private _InvocaPedido As Boolean = False

   Private txtIVA105_Calculado As Decimal
   Private txtIVA210_Calculado As Decimal
   Private txtIVA270_Calculado As Decimal

   Private _comprasPosicionarNombreProducto As Boolean
#End Region

#Region "Propiedades"
   Public Property tablaAsientos() As DataTable
      Get
         Return _tablaAsientos
      End Get
      Set(ByVal value As DataTable)
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

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         _decimalesEnTotales = Publicos.ComprasDecimalesEnTotalGeneral
         _decimalesRedondeoEnPrecio = Publicos.ComprasDecimalesRedondeoEnPrecio
         _decimalesAMostrarEnPrecio = Publicos.ComprasDecimalesEnPrecio
         _decimalesAMostrarEnTotalXProducto = Publicos.ComprasDecimalesEnTotalXProducto

         _comprasPosicionarNombreProducto = Publicos.ComprasPosicionarNombreProducto

         If Publicos.ProductoUtilizaCantidadesEnteras Then
            Me._decimalesEnCantidad = 0
            _decimalesMostrarEnCantidad = 0
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         Else
            _decimalesEnCantidad = Publicos.ComprasDecimalesRedondeoEnCantidad
            _decimalesMostrarEnCantidad = Publicos.ComprasDecimalesMostrarEnCantidad
         End If

         Me._chequesPropios = New List(Of Entidades.Cheque)()
         Me._chequesTerceros = New List(Of Entidades.Cheque)()

         Me._productos = New System.Collections.Generic.List(Of Entidades.MovimientoCompraProducto)
         Me._productosRT = New System.Collections.Generic.List(Of Entidades.MovimientoCompraProducto)
         Me._productosLotes = New List(Of Entidades.ProductoLote)()
         Me._productosNrosSeries = New List(Of Entidades.ProductoNroSerie)()
         Me._comprasObservaciones = New List(Of Entidades.CompraObservacion)()

         Me._publicos = New Publicos()
         Me._publicos.CargaComboBancos(Me.cmbBancoPropio)
         Dim blnMiraPC As Boolean = True, blnUsaFacturacion As Boolean = True
         Me._publicos.CargaComboTiposComprobantes(Me.cboTipoComprobante, blnMiraPC, "COMPRAS", , , , blnUsaFacturacion)

         If Me.cboTipoComprobante.Items.Count = 0 Then
            Me._ConfiguracionImpresoras = True
         End If

         Me._publicos.CargaComboPeriodosFiscales(Me.cboPeriodoFiscal, "ABIERTO")

         If Me.cboPeriodoFiscal.Items.Count = 0 Then
            MessageBox.Show("NO Existen Periodos Fiscales Habilitados, no podra grabar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.tsbNuevo.Visible = False
            Me.tsbGrabar.Visible = False
            Exit Sub 'No logro hacer que salga, pero tampoco podra grabar nada.
         End If

         Me._publicos.CargaComboFormasDePago(Me.cboFormaPago, "COMPRAS")
         Me._publicos.CargaComboRubrosCompras(Me.cboRubro)
         Me._publicos.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR)
         _publicos.CargaComboCentroCostos(cmbCentroCosto)

         Me._Sucursal = Entidades.Usuario.Actual.Sucursal.Id

         Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

         'carga las cajas.

         Me._publicos.CargaComboCajas(Me.cmbCajas, Me._Sucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         _publicos.CargaComboLetraComprobanteCompra(cboLetra)

         Me._publicos.CargaComboImpuestos(Me.cmbPorcentajeIVA)

         Dim oCategFiscal As New Reglas.CategoriasFiscales()

         Me._categoriaFiscalEmpresa = oCategFiscal.GetUno(Publicos.CategoriaFiscalEmpresa)

         Me.grpPrecioCompra.Visible = Publicos.UtilizaPrecioDeCompra

         If Publicos.ProductoUtilizaCantidadesEnteras Then
            Me.txtCantidad.Formato = "##,##0"
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         End If

         If Publicos.VisualizaLote Then
            dgvProductos.Columns("ColIdLote").Visible = True
            dgvProductos.Columns("VtoLote").Visible = True
            'dgvProductos.Columns("VtoLote").DefaultCellStyle.Format = "dd/MM/yyyy"
         End If

         If Publicos.VisualizaNrosSerie Then
            dgvProductos.Columns("NrosSerie").Visible = True
         End If

         If Publicos.TieneModuloExpensas Then
            Me.dgvProductos.Columns("Stock").Visible = False
            Me.dgvProductos.Columns("NombreConcepto").Visible = True
            Me.lblConcepto.Visible = True
            Me.cmbConceptos.Visible = True
         End If


         Me.dgvProductos.Columns("CodigoProductoProveedor1").Visible = Publicos.ComprasVisualizaCodigoProveedor

         Me.dgvProductos.Columns("PorcVar").Visible = Publicos.ComprasVisualizaPorcVarCosto

         'Me._comprasProductos = New List(Of Entidades.CompraProducto)

         Me._estaCargando = False

         Me.tsbInvocarPedidos.Visible = Publicos.TieneModuloPedidosProv

         SeteaFormatosACampos()

         tbcDetalle.SelectedTab = tbpDespachoImportacion
         tbcDetalle.SelectedTab = tbpProductos

         _tit = GetColumnasVisiblesGrilla(ugImpuestosDespacho)
         _titRemitoTransporte = GetColumnasVisiblesGrilla(dgvRemitoTransp)

         ''tbcDetalle.TabPages.Remove(tbpDespachoImportacion)

         Me.Nuevo()

         _utilizaCentroCostos = Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos
         _permiteCambiarCentroCostosCompras = _utilizaCentroCostos AndAlso Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosCompras

         cmbCentroCosto.Visible = _utilizaCentroCostos
         cmbCentroCosto.LabelAsoc.Visible = _utilizaCentroCostos
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
      bscCodigoProveedor.Focus()
   End Sub

#End Region

#Region "Eventos"

   Private Sub MovimientosDeCompras_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         If _ConfiguracionImpresoras Then
            MessageBox.Show("No Existe la PC en Configuraciones/Impresoras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub MovimientosDeCompras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      Select Case e.KeyCode
         Case Keys.F2
            Me.tsbNuevo.PerformClick()
         Case Keys.F4
            If Me.tsbGrabar.Enabled Then
               Me.tsbGrabar.PerformClick()
            End If
         Case Keys.F9
            Me.tbcDetalle.SelectedTab = Me.tbpProductos
            ProductoFocus()
         Case Keys.F11
            Me.tbcDetalle.SelectedTab = Me.tbpPagosEfectivo
            Me.txtEfectivo.Focus()
         Case Keys.F12
            Me.tbcDetalle.SelectedTab = Me.tbpPagosChTerceros
            Me.btnInsertarChequeTercero.Focus()
         Case Else
      End Select
   End Sub

   Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
      Try
         If MessageBox.Show("ATENCION: ¿Desea Realizar un Comprobante Nuevo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            Me.Nuevo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.GrabarComprobante()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tsbGrabar.Enabled = True
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub cmbTipoDocProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Me.PresionarTab(e)
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.txtEmisorFactura.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedor As Reglas.Proveedores = New Reglas.Proveedores
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedor.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            If Short.Parse("0" & Me.txtEmisorFactura.Text) > 0 Then
               ProductoFocus()
            Else
               Me.txtEmisorFactura.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub llbProveedor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbProveedor.LinkClicked

      Try
         Dim PantProveedor As ProveedoresDetalle

         If Me.bscCodigoProveedor.Selecciono Or Me.bscProveedor.Selecciono Then
            Dim Prov As Eniac.Entidades.Proveedor = New Eniac.Entidades.Proveedor
            Dim blnIncluirFoto As Boolean = True
            Prov = New Eniac.Reglas.Proveedores().Proveedores_G1Todos(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), blnIncluirFoto)
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
            Me.bscCodigoProveedor.Text = PantProveedor.txtCodigoProveedor.Text
            Me.bscCodigoProveedor.PresionarBoton()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cboTipoComprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoComprobante.SelectedIndexChanged

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
            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Trim.Length = 1 Then
               Me.cboLetra.Text = DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               'If Me.bscCodigoProveedor.Selecciono Or Me.bscProveedor.Selecciono Then
               '   Me.cboLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
               'Else
               Me.cboLetra.SelectedIndex = -1
               'End If
            End If

            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).NumeracionAutomatica Then
               Me.CargarProximoNumeroProveedor()
            ElseIf DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 And _
               Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).AfectaCaja And _
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

         If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsDespachoImportacion Then
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

         If Me._proveedor IsNot Nothing Then
            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
               'Vuelvo a asignarlo para saber si lo cambio.
               Me._proveedor = New Reglas.Proveedores().GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))
            End If
         End If

         If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
            If Me.tbcDetalle.TabPages.Contains(Me.tbpProductos) Then
               Me.tbcDetalle.TabPages.Remove(Me.tbpProductos)
            End If
            If Not Me.tbcDetalle.TabPages.Contains(Me.tbpRemitoTransp) Then
               Me.tbcDetalle.TabPages.Insert(0, Me.tbpRemitoTransp)
            End If
            Me.tbcDetalle.SelectedTab = Me.tbpRemitoTransp
            AjustarColumnasGrilla(dgvRemitoTransp, _titRemitoTransporte)
         Else
            If Not Me.tbcDetalle.TabPages.Contains(Me.tbpProductos) Then
               Me.tbcDetalle.TabPages.Insert(0, Me.tbpProductos)
            End If
            If Me.tbcDetalle.TabPages.Contains(Me.tbpRemitoTransp) Then
               Me.tbcDetalle.TabPages.Remove(Me.tbpRemitoTransp)
            End If
            Me.tbcDetalle.SelectedTab = Me.tbpProductos
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cboTipoComprobante_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoComprobante.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbLetra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLetra.LostFocus

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

   Private Sub cboLetra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLetra.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEmisorFactura_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmisorFactura.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNumeroFactura_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroFactura.KeyDown
      Me.PresionarTab(e)
   End Sub

   'Private Sub txtNumeroFactura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroFactura.LostFocus

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
         If bscCodigoProveedor.Tag Is Nothing Then
            ShowMessage("ATENCION: Debe cargar el Proveedor")
            bscCodigoProveedor.Focus()
         Else
            Dim oCompras As New Reglas.Compras
            If oCompras.Existe(0, _
                              Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), _
                              Me.cboTipoComprobante.SelectedValue.ToString, _
                              Me.cboLetra.Text, _
                              Short.Parse("0" & Me.txtEmisorFactura.Text), _
                              Long.Parse("0" & Me.txtNumeroFactura.Text)) Then

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

   Private Sub dtpFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.LostFocus

      If Me.cboPeriodoFiscal.Enabled Then
         'Si la fecha del comprobante coincide con un periodo abierto le pongo esa fecha, sino, pongo la ultima
         If Me.cboPeriodoFiscal.FindStringExact(Me.dtpFecha.Value.ToString("yyyy/MM")) >= 0 Then
            Me.cboPeriodoFiscal.SelectedIndex = Me.cboPeriodoFiscal.FindStringExact(Me.dtpFecha.Value.ToString("yyyy/MM"))
         Else
            Me.cboPeriodoFiscal.SelectedIndex = 0
         End If
      End If

   End Sub

   Private Sub cboPeriodoFiscal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPeriodoFiscal.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbComprador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbComprador.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cboFormaPago_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFormaPago.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cboRubro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRubro.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub chbSinProductos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSinProductos.CheckedChanged

      Me.tbcDetalle.Enabled = Not Me.chbSinProductos.Checked
      Me.dgvProductos.Enabled = Not Me.chbSinProductos.Checked
      tsbInvocarComprobantes.Enabled = Not Me.chbSinProductos.Checked
      tsbInvocarPedidos.Enabled = Not Me.chbSinProductos.Checked

      If Me.chbSinProductos.Checked Then
         Me.LimpiarCamposProductos()

         Me._productos.Clear()
         Me.dgvProductos.DataSource = Me._productos.ToArray()
         Me._productosLotes.Clear()
         Me._productosNrosSeries.Clear()

         Me.txtBrutoNoGravado.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         Me.txtBruto105.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         Me.txtBruto210.Text = "0." + New String("0"c, Me._decimalesEnTotales)
         Me.txtBruto270.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      End If

      Me.txtBrutoNoGravado.ReadOnly = Not Me.chbSinProductos.Checked
      Me.txtBruto105.ReadOnly = Not Me.chbSinProductos.Checked
      Me.txtBruto210.ReadOnly = Not Me.chbSinProductos.Checked
      Me.txtBruto270.ReadOnly = Not Me.chbSinProductos.Checked

      If Not Me.chbSinProductos.Checked Then
         ProductoFocus()
      Else
         Me.txtBrutoNoGravado.Focus()
      End If

   End Sub

   Private Sub chbSinProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chbSinProductos.KeyDown, chbAjusteManualIVA.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
      Me.LimpiarCamposProductos()
      ProductoFocus()
      Me._vieneDelDobleClick = False
   End Sub

   Private Sub lnkProducto_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkProducto.LinkClicked
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

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick

      Try
         If Me.bscCodigoProveedor.Enabled And Me._proveedor Is Nothing Then
            MessageBox.Show("ATENCION: Debe cargar el Proveedor antes de cargar el producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.bscCodigoProducto2.Text = ""
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Dim oCompras As New Reglas.Compras
         If oCompras.Existe(0, _
                              Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), _
                              Me.cboTipoComprobante.SelectedValue.ToString, _
                              Me.cboLetra.Text, _
                              Short.Parse("0" & Me.txtEmisorFactura.Text), _
                              Long.Parse("0" & Me.txtNumeroFactura.Text)) Then

            MessageBox.Show("Este comprobante ya fue INGRESADO con ANTERIORIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroFactura.Focus()
            Exit Sub
         End If

         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Dim oProdProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores()

         Dim listaPreciosPredeterminada As Integer = Publicos.ListaPreciosPredeterminada
         If Me.chbProductosDelProveedor.Checked Then

            Me._publicos.PreparaGrillaProductosProveedor2(Me.bscCodigoProducto2)
            Me.bscCodigoProducto2.Datos = oProdProv.GetPorCodigoProdProv(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, listaPreciosPredeterminada, "COMPRAS", _proveedor.IdProveedor)
         Else
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
            Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, listaPreciosPredeterminada, "COMPRAS")
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            'Me.txtCantidad.Focus()
            'Me.txtCantidad.SelectAll()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick

      Try

         If Me.bscCodigoProveedor.Enabled And Me._proveedor Is Nothing Then
            MessageBox.Show("ATENCION: Debe cargar el Proveedor antes de cargar el producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.bscProducto2.Text = ""
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Dim oCompras As New Reglas.Compras
         If oCompras.Existe(0, _
                              Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), _
                              Me.cboTipoComprobante.SelectedValue.ToString, _
                              Me.cboLetra.Text, _
                              Short.Parse("0" & Me.txtEmisorFactura.Text), _
                              Long.Parse("0" & Me.txtNumeroFactura.Text)) Then

            MessageBox.Show("Este comprobante ya fue INGRESADO con ANTERIORIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroFactura.Focus()
            Exit Sub
         End If

         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            'Me.txtCantidad.Focus()
            'Me.txtCantidad.SelectAll()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPorcDescRecargo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescuentoRecargoPorc.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   Me.txtDescRecargo.Focus()
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPorcDescRecargo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescuentoRecargoPorc.LostFocus
      Try
         If Me.txtDescuentoRecargoPorc.Text = "" Or Me.txtDescuentoRecargoPorc.Text = "-" Then
            Me.txtDescuentoRecargoPorc.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.CalcularDescRecargoProductosXPorc()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtDescRecargo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescuentoRecargo.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   Me.cmbPorcentajeIVA.Focus()
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub txtDescRecargo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescuentoRecargo.LostFocus
      Try
         If Me.txtDescuentoRecargo.Text = "" Or Me.txtDescuentoRecargo.Text = "-" Then
            Me.txtDescuentoRecargo.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.CalcularDescRecargoProductosXMonto()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPorcDescRecargoGral_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPorcDescRecargoGral.GotFocus
      Me.txtPorcDescRecargoGral.SelectAll()
   End Sub

   Private Sub txtPorcDescRecargoGral_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorcDescRecargoGral.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPorcDescRecargoGral_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPorcDescRecargoGral.LostFocus
      Try
         Me.CalcularDescuentoRecargo()
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbConceptos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbConceptos.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub cmbCentroCosto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCentroCosto.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub


   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
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

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
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

   Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   If Me.txtPrecio.Enabled Then
      '      Me.txtPrecio.Focus()
      '   Else
      '      Me.btnInsertar.Focus()
      '   End If
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub txtCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.LostFocus
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

   Private Sub txtPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   If Me.txtPorcDescRecargo.Enabled Then
      '      Me.txtPorcDescRecargo.Focus()
      '   Else
      '      Me.btnInsertar.Focus()
      '   End If
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPrecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecio.LostFocus
      Try
         If Me.txtPrecio.Text.Trim().Length = 0 Then
            Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
         End If
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBruto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalBruto.LostFocus
      If Me.txtTotalBruto.Text.Trim().Length = 0 Then
         Me.txtTotalBruto.Text = "0"
      End If
   End Sub

   Private Sub cmbPorcentajeIVA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPorcentajeIVA.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   Me.btnInsertar.Focus()
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub dgvProductos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick
      Try
         If Me.dgvProductos.Rows.Count = 0 Then Exit Sub

         If Me.dgvProductos.SelectedRows.Count = 0 Then Exit Sub

         If Me.dgvProductos.Columns(e.ColumnIndex).Name = "NrosSerie" Then
            If e.RowIndex <> -1 Then
               If DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoCompraProducto).ProductoSucursal.Producto.NroSerie Then

                  Dim cantidadDeProductos As Integer = DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, 
                                                               Entidades.MovimientoCompraProducto).ProductoSucursal.Producto.NrosSeries.Count

                  Dim Ver As Boolean = True

                  Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos,
                                                                           DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, 
                                                                           Entidades.MovimientoCompraProducto).ProductoSucursal.Producto,
                                                                           _productosNrosSeries,
                                                                           Ver)
                  ins.ShowDialog()

               End If
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub dgvProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
      Try
         'limpia los textbox, y demas controles
         Me.LimpiarCamposProductos()
         'carga el producto seleccionado de la grilla en los textbox
         Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex))
         'elimina el producto de la grilla
         Me.EliminarLineaProducto()
         'hace foco en la cantidad
         Me.txtCantidad.Focus()
         Me.txtCantidad.SelectAll()
         Me._vieneDelDobleClick = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBrutoNoGravado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBrutoNoGravado.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtBrutoNoGravado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrutoNoGravado.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBruto105_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBruto105.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtBruto105_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBruto105.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBruto210_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBruto210.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtBruto210_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBruto210.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtBruto270_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBruto270.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtBruto270_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBruto270.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionIVA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionIVA.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   Me.txtPercepcionIB.Focus()
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPercepcionIVA_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercepcionIVA.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionIB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionIIBB.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   Me.txtPercepcionGanancias.Focus()
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPercepcionIB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercepcionIIBB.Leave
      Try
         Me.CalcularTotales()
         If Not txtPercepcionIIBB.ReadOnly AndAlso IsNumeric(txtPercepcionIIBB.Text) AndAlso Decimal.Parse(txtPercepcionIIBB.Text) <> 0 Then
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
               dr("Importe") = Decimal.Parse(txtPercepcionIIBB.Text)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionGanancias.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   Me.txtPercepcionVarias.Focus()
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPercepcionGanancias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercepcionGanancias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionVarias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionVarias.KeyDown
      'If e.KeyCode = Keys.Enter Then
      '   Me.txtPercepcionTotal.Focus()
      'End If
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPercepcionVarias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercepcionVarias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCodPostalChequePropio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPostalChequePropio.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaEmisionPropio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpChequePropioEmision.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaCobroPropio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpChequePropioCobro.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtImporteChequePropio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporteChequePropio.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEfectivo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEfectivo.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEfectivo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEfectivo.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnChequePropioInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChequePropioInsertar.Click
      Try
         If Me.ValidarInsertarChequePropio() Then
            Me.InsertarChequePropioGrilla()
            Me.bscCuentaBancariaPropio.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnChequePropioEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChequePropioEliminar.Click
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

   Private Sub dgvChequesPropios_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChequesPropios.CellDoubleClick

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

   Private Sub btnInsertarChequeTercero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarChequeTercero.Click

      If Me._proveedor Is Nothing Then
         MessageBox.Show("ATENCION: Debe elegir el Proveedor antes de cargar el Cheque de Tercero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Me.bscCodigoProveedor.Focus()
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

   Private Sub btnEliminarChequeTercero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarChequeTercero.Click
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

   Private Sub txtNroChequePropio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroChequePropio.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtSucursalBancoPropio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSucursalBancoPropio.KeyDown
      Me.PresionarTab(e)
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

   Private Sub bscCuentaBancaria_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaPropio.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaBancaria(e.FilaDevuelta)
            Me.txtNroChequePropio.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaTransfBanc)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaTransfBanc.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaTransfBanc.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            'Me.CargarDatosCuentasBancarias(e.FilaDevuelta)
            Me.bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancariaPropio.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub txtTarjetas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTarjetas.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTarjetas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTarjetas.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTransferenciaBancaria_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferenciaBancaria.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTransferenciaBancaria_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransferenciaBancaria.KeyUp
      If e.KeyCode = Keys.Enter Then
         If Not String.IsNullOrEmpty(Me.txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 Then
            Me.PresionarTab(e)
            'Me.bscCuentaBancariaTransfBanc.Focus()
         Else
            Me.bscCuentaBancariaPropio.Focus()
         End If
      End If
   End Sub

   Private Sub tsbInvocarPedidos_Click(sender As System.Object, e As System.EventArgs) Handles tsbInvocarPedidos.Click
      Try
         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
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
         Me.CalcularTotales()
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

   Private Sub tsbInvocarComprobantes_Click(sender As System.Object, e As System.EventArgs) Handles tsbInvocarComprobantes.Click
      Try
         'Valido que haya ingresado el Proveedor. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
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
            oFactAyuda = New FacturablesPendientesComAyuda(Me.cboTipoComprobante.SelectedValue.ToString(), IdTipoComprobante, _proveedor.IdProveedor)
         Else
            oFactAyuda = New FacturablesPendientesComAyuda(Me.cboTipoComprobante.SelectedValue.ToString(), IdTipoComprobante, _proveedor.IdProveedor, DirectCast(Me.dgvfacturables.DataSource, List(Of Entidades.Compra)))
         End If

         oFactAyuda.ShowDialog()

         Me.CargarComprobantesFacturables(oFactAyuda.ComprobantesSeleccionados)
         Me.CargarProductosFacturables(oFactAyuda.ComprobantesSeleccionados)

         'If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
         '   Me.CargarObservacionesFacturables(oFactAyuda.ComprobantesSeleccionados)
         'End If

         Me.LimpiarCamposProductos()
         Me.CalcularTotales()
         'Me.CalcularDatosDetalle()
         'Me.CalcularTotales()


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

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Private Sub dgvObservaciones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvObservaciones.CellDoubleClick

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

   Private Sub bscObservacion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscObservacion.BuscadorSeleccion
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

   Private Sub bscObservacionDetalle_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscObservacionDetalle.BuscadorSeleccion
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

   Private Sub btnInsertarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarObservacion.Click
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

   Private Sub btnEliminarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarObservacion.Click
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

   Private Sub dtpFechaOficializacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroDespacho.KeyDown, txtImporteDespacho.KeyDown, txtDigitoVerificador.KeyDown, txtDerechoAduana.KeyDown, txtBaseImponibleDespacho.KeyDown, txtAlilcuotaDespacho.KeyDown, dtpFechaOficializacion.KeyDown, chbBienCapital.KeyDown, txtNumeroManifiesto.KeyDown, txtNumeroManifiesto.KeyDown
      PresionarTab(e)
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

#Region "Propiedades por Edición Manual de IVA"
   Private Sub chbAjusteManualIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbAjusteManualIVA.CheckedChanged
      Try
         HabilitaIVA()
         If Not chbAjusteManualIVA.Checked Then
            txtIVA105.Text = txtIVA105_Calculado.ToString("N" + _decimalesEnTotales.ToString())
            txtIVA210.Text = txtIVA210_Calculado.ToString("N" + _decimalesEnTotales.ToString())
            txtIVA270.Text = txtIVA270_Calculado.ToString("N" + _decimalesEnTotales.ToString())
            Me.CalcularTotales()
         Else
            If IsNumeric(txtIVA105.Text) AndAlso Decimal.Parse(txtIVA105.Text) <> 0 Then
               txtIVA105.Focus()
            ElseIf IsNumeric(txtIVA210.Text) AndAlso Decimal.Parse(txtIVA210.Text) <> 0 Then
               txtIVA210.Focus()
            ElseIf IsNumeric(txtIVA270.Text) AndAlso Decimal.Parse(txtIVA270.Text) <> 0 Then
               txtIVA270.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtIVA105_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIVA105.KeyDown
      Me.PresionarTab(e)
   End Sub
   Private Sub txtIVA105_Leave(sender As Object, e As EventArgs) Handles txtIVA105.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub txtIVA210_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIVA210.KeyDown
      Me.PresionarTab(e)
   End Sub
   Private Sub txtIVA210_Leave(sender As Object, e As EventArgs) Handles txtIVA210.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub txtIVA270_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIVA270.KeyDown
      Me.PresionarTab(e)
   End Sub
   Private Sub txtIVA270_Leave(sender As Object, e As EventArgs) Handles txtIVA270.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region
#End Region

#Region "Metodos"

   Private Sub CargarProximoNumeroProveedor()
      Dim oVentasNumeros As New Reglas.VentasNumeros()

      Dim ventaNumero As Entidades.VentaNumero = oVentasNumeros.GetUnoPorRelacionado(DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante)
      If ventaNumero IsNot Nothing Then
         cboLetra.SelectedItem = ventaNumero.LetraFiscal
         txtEmisorFactura.Text = ventaNumero.CentroEmisor.ToString()
         txtNumeroFactura.Text = ventaNumero.Numero.ToString()
         txtNumeroFactura.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal.Id,
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

            Me.txtNumeroFactura.Text = oCompras.GetProximoNumero(actual.Sucursal.Id, _
                                                                  Long.Parse(Me.bscCodigoProveedor.Tag.ToString), _
                                                                  DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante, _
                                                                  Me.cboLetra.Text, _
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

         Me.txtNumeroFactura.Text = oCN.GetProximoNumero(actual.Sucursal.Id, _
                                                         DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante, _
                                                         Me.cboLetra.Text, _
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

   Protected Overridable Function ValidarComprobante() As Boolean

      Dim sistema As Entidades.Sistema = Publicos.GetSistema()

      If DateDiff(DateInterval.Day, Me.dtpFecha.Value, sistema.FechaVencimiento) < 0 Then
         MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpFecha.Focus()
         Return False
      End If

      If Not Me.bscCodigoProveedor.Selecciono() And Not Me.bscProveedor.Selecciono() Then
         MessageBox.Show("Debe cargar un Proveedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProveedor.Focus()
         Return False
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

      'controlo que el tipo de Comprobante Genere Contabilidad sino no valido los Periodos fiscales
      If tipoComprobante.GeneraContabilidad Then
         If tipoComprobante.GrabaLibro Then
            Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
            'No valido la fecha sino el periodo fiscal. (tal vez alguien lo cerro luego de ingresar).
            Dim dt As DataTable = oPF.Get1(Integer.Parse(Me.cboPeriodoFiscal.SelectedValue.ToString()))
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
            Dim dt As DataTable = oPF.Get1(Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
            'No deberia pasar.
            If dt.Rows.Count = 0 Then
               MessageBox.Show("El Período Fiscal del Comprobante NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.dtpFecha.Focus()
               Return False
            End If
         End If
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
         If Me._proveedor.CategoriaFiscal.LetraFiscalCompra <> Me.cboLetra.Text Then
            If Me._proveedor.CategoriaFiscal.LetraFiscalCompra = "A" And Me.cboLetra.Text = "B" Then
               If MessageBox.Show("Esta seguro de utilizar la Letra '" & Me.cboLetra.Text & "' ? NO coincide con la del Proveedor '" & Me._proveedor.CategoriaFiscal.LetraFiscalCompra & "'", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel Then
                  Me.cboLetra.SelectedIndex = -1
                  Return False
               Else
                  For Each cp As Entidades.MovimientoCompraProducto In Me._productos
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
      Dim oCompras As Reglas.Compras = New Reglas.Compras()
      If oCompras.Existe(0, _
                        Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), _
                        Me.cboTipoComprobante.SelectedValue.ToString, _
                        Me.cboLetra.Text, _
                        Short.Parse("0" & Me.txtEmisorFactura.Text), _
                        Long.Parse("0" & Me.txtNumeroFactura.Text)) Then

         MessageBox.Show("Este comprobante ya fue INGRESADO con ANTERIORIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroFactura.Focus()
         Return False
      End If

      Dim oCtasCtesProv As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
      If oCtasCtesProv.Existe(0, _
                        Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), _
                        Me.cboTipoComprobante.SelectedValue.ToString, _
                        Me.cboLetra.Text, _
                        Short.Parse("0" & Me.txtEmisorFactura.Text), _
                        Long.Parse("0" & Me.txtNumeroFactura.Text)) Then

         MessageBox.Show("Este comprobante ya EXISTE en Cuentas Corrientes de Proveedores", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroFactura.Focus()
         Return False
      End If

      'If Me.cboFormaPago.Enabled Then
      'End If
      If Me.cboFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar la forma de pago del documento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cboFormaPago.Focus()
         Return False
      End If

      'If Me.cboRubro.Enabled Then
      'End If
      If Me.cboRubro.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cboRubro.Focus()
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

      If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
         MessageBox.Show("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

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

      If Decimal.Parse(txtPercepcionIVA.Text) < 0 Then
         ShowMessage("Las Percepciones de IVA no pueden ser negativas.")
         Me.txtPercepcionIVA.Focus()
         Return False
      End If

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

      If Decimal.Parse(txtPercepcionVarias.Text) < 0 Then
         ShowMessage("Las Percepciones Varias no pueden ser negativas.")
         Me.txtPercepcionVarias.Focus()
         Return False
      End If

      Dim result As ValidaProvinciasResult = ValidaProvincias(_dtProvincias)
      If Not result.Valida Then
         ShowMessage(result.Mensaje)
         btnPercIIBB.PerformClick()
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

         If Long.Parse("0" & Me.txtNumeroLote.Text) <= 0 And Publicos.FacturacionRemitoTranspUtilizaLote Then
            MessageBox.Show("Debe ingresar el Lote del Remito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbcDetalle.SelectedTab = Me.tbpRemitoTransp
            Me.txtNumeroLote.Focus()
            Return False
         End If
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

      Dim ini As String = (0).ToString("N" + Me._decimalesEnTotales.ToString())
      If Not IsNumeric(txtIVA105.Text) Then txtIVA105.Text = ini
      If Not IsNumeric(txtIVA210.Text) Then txtIVA210.Text = ini
      If Not IsNumeric(txtIVA270.Text) Then txtIVA270.Text = ini

      Dim toleranciaIvaManual As Decimal = Publicos.ComprasToleranciaIvaManual '  0.05D

      'Si la diferencia entre el total de IVA ingresado por pantalla y el total de IVA calculado es mayor a la tolerancia
      If Math.Abs((Decimal.Parse(txtIVA105.Text) + Decimal.Parse(txtIVA210.Text) + Decimal.Parse(txtIVA270.Text)) -
                  (txtIVA105_Calculado + txtIVA210_Calculado + txtIVA270_Calculado)) > toleranciaIvaManual Then
         ShowMessage(String.Format("El total de IVA ingresado ({0:N2}) difiere del IVA calculado ({1:N2}) por más de {2:N2}. Por favor verifique los importes.",
                                   Decimal.Parse(txtIVA105.Text) + Decimal.Parse(txtIVA210.Text) + Decimal.Parse(txtIVA270.Text),
                                   txtIVA105_Calculado + txtIVA210_Calculado + txtIVA270_Calculado,
                                   toleranciaIvaManual))
         txtIVA105.Focus()
         Return False
      End If

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

      If Me.ValidarComprobante() Then

         Me.tsbGrabar.Enabled = False

         Dim oMovimientos As Reglas.MovimientosCompras = GetNewReglaMovimientoCompras()
         Dim oMov As Entidades.MovimientoCompra = GetNewEntidadMovimientoCompras()
         Dim oCF As Entidades.CategoriaFiscal = Nothing

         With oMov
            .Sucursal = New Reglas.Sucursales().GetUna(actual.Sucursal.Id)
            .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
            '.Sucursal2 = 

            .TipoMovimiento = New Reglas.TiposMovimientos().GetUnoPorComprobanteAsociado(Me.cboTipoComprobante.SelectedValue.ToString())
            .FechaMovimiento = Me.dtpFecha.Value

            .DescuentoRecargo = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

            .Compra.Comprador = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado)

            .Neto210 = Decimal.Parse(Me.txtNetoAl210.Text)
            .Neto105 = Decimal.Parse(Me.txtNetoAl105.Text)
            .Neto270 = Decimal.Parse(Me.txtNetoAl270.Text)
            .NetoNoGravado = Decimal.Parse(Me.txtNetoNoGravado.Text)

            .IVA210 = Decimal.Parse(Me.txtIVA210.Text)
            .IVA105 = Decimal.Parse(Me.txtIVA105.Text)
            .IVA270 = Decimal.Parse(Me.txtIVA270.Text)

            .Total = Decimal.Parse(Me.txtTotalGeneral.Text)

            'If Not oCF.IvaDiscriminado Then
            '   .Neto210 = Decimal.Round((.Neto210 / (1 + (.PorcentajeIVA / 100))), 2)
            '   .IVA105 = Decimal.Round((.Neto210 * .PorcentajeIVA / 100), 2)
            '   .DescuentoRecargo = Decimal.Round((.DescuentoRecargo / (1 + (.PorcentajeIVA / 100))), 2)
            'End If

            .Proveedor = Me._proveedor

            .Compra.Letra = Me.cboLetra.SelectedValue.ToString
            .Compra.CentroEmisor = Short.Parse(Me.txtEmisorFactura.Text)
            .Compra.NumeroComprobante = Long.Parse(Me.txtNumeroFactura.Text)
            .Compra.TipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.cboTipoComprobante.SelectedValue.ToString())

            'EsComercial=True excluye los Tipo de SALDOINICIAL.
            If .Compra.TipoComprobante.EsComercial Or .Compra.TipoComprobante.GeneraContabilidad Then
               If .Compra.TipoComprobante.GrabaLibro Then
                  .Compra.PeriodoFiscal = Integer.Parse(Me.cboPeriodoFiscal.SelectedValue.ToString())
               Else
                  .Compra.PeriodoFiscal = Integer.Parse(.FechaMovimiento.ToString("yyyyMM"))
               End If
            End If

            'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
            Dim coe As Integer = .Compra.TipoComprobante.CoeficienteValores


            '------------------------------------------
            'If Not oCF.IvaDiscriminado Then
            '   .Compra.Bruto210 = Decimal.Round((.Compra.Bruto210 / (1 + (.PorcentajeIVA / 100))), 2)
            'End If

            .Compra.DescuentoRecargo = .DescuentoRecargo * coe
            .Compra.DescuentoRecargoPorc = Decimal.Parse(Me.txtPorcDescRecargoGral.Text) * coe

            .Compra.Bruto210 = Decimal.Parse(Me.txtBruto210.Text) * coe
            .Compra.Bruto105 = Decimal.Parse(Me.txtBruto105.Text) * coe
            .Compra.Bruto270 = Decimal.Parse(Me.txtBruto270.Text) * coe
            .Compra.BrutoNoGravado = Decimal.Parse(Me.txtBrutoNoGravado.Text) * coe

            .Compra.Neto210 = .Neto210 * coe
            .Compra.Neto105 = .Neto105 * coe
            .Compra.Neto270 = .Neto270 * coe
            .Compra.NetoNoGravado = .NetoNoGravado * coe

            .Compra.IVA105 = .IVA105 * coe
            .Compra.IVA210 = .IVA210 * coe
            .Compra.IVA270 = .IVA270 * coe

            .Compra.IVA105Calculado = txtIVA105_Calculado * coe
            .Compra.IVA210Calculado = txtIVA210_Calculado * coe
            .Compra.IVA270Calculado = txtIVA270_Calculado * coe
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



            If .Compra.TipoComprobante.AfectaCaja Then
               'controlo el pago que se realiza si no va a la cuenta corriente
               If .Compra.FormaPago.Dias = 0 Then
                  If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
                     If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                        If Not Publicos.ComprasContadoEsEnPesos AndAlso MessageBox.Show("El pago se realizara totalmente en pesos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                           Me.tbpPagosEfectivo.Focus()
                           Me.txtEfectivo.Focus()
                           Exit Sub
                        Else
                           Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
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
            If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Me.bscCuentaBancariaTransfBanc.Selecciono Then
               .Compra.ImporteTransfBancaria = Decimal.Parse(Me.txtTransferenciaBancaria.Text)
               .Compra.CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
            End If

            'cargo las Observaciones
            .Compra.ComprasObservaciones = Me._comprasObservaciones

            'cargo cotizacion dolar
            .Compra.CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text)

            .PercepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
            .PercepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
            .PercepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
            .PercepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)

            .Compra.ComprasImpuestos.Clear()
            For Each drProvincias As DataRow In _dtProvincias.Rows
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               With ci
                  .IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIIBB.ToString()
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
               ci.Importe = .PercepcionGanancias
               .Compra.ComprasImpuestos.Add(ci)
            End If
            If .PercepcionIVA <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA.ToString()
               ci.Importe = .PercepcionIVA
               .Compra.ComprasImpuestos.Add(ci)
            End If
            If .PercepcionVarias <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PVAR.ToString()
               ci.Importe = .PercepcionVarias
               .Compra.ComprasImpuestos.Add(ci)
            End If

            If .NetoNoGravado <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
               ci.BaseImponible = .NetoNoGravado
               ci.Alicuota = 0
               ci.Importe = 0
               .Compra.ComprasImpuestos.Add(ci)
            End If

            If .Neto105 <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
               ci.BaseImponible = .Neto105
               ci.Alicuota = 10.5D
               ci.Importe = .IVA105
               .Compra.ComprasImpuestos.Add(ci)
            End If

            If .Neto210 <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
               ci.BaseImponible = .Neto210
               ci.Alicuota = 21
               ci.Importe = .IVA210
               .Compra.ComprasImpuestos.Add(ci)
            End If

            If .Neto270 <> 0 Then
               Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
               ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
               ci.BaseImponible = .Neto270
               ci.Alicuota = 27
               ci.Importe = .IVA270
               .Compra.ComprasImpuestos.Add(ci)
            End If

            If .Compra.TipoComprobante.EsDespachoImportacion Then
               For Each cid As Entidades.CompraImpuesto In _comprasImpuestosDespachoImportacion
                  Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
                  ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
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

            .Comentarios = Me.bscObservacion.Text.Trim()
            .Observacion = Me.bscObservacion.Text

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

         End With


         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If oMov.Compra.TipoComprobante.ActualizaCtaCte Then
            If oMov.Compra.FormaPago.Dias > 0 Then
               'si el cliente compro el modulo de cuenta corriente
               If Publicos.TieneModuloCuentaCorrienteProveedores Then

                  If Not Publicos.UtilizaCuotasVencimientoCtaCteProveedores Then

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

         Me.Insertar(oMovimientos, oMov)
         ''oMovimientos.Insertar(oMov)

         MessageBox.Show("El Movimiento se ingresó con éxito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         'distribuir el descuento gral en todos los productos
         If oMov.Compra.DescuentoRecargoPorc <> 0 Then
            For Each dr As Entidades.MovimientoCompraProducto In oMov.Productos
               dr.PrecioCostoNuevo = (dr.PrecioCostoNuevo * oMov.Compra.DescuentoRecargoPorc) / 100 + dr.PrecioCostoNuevo
               Dim porcentaje As Decimal = 0

               If dr.PrecioCostoO > 0 Then
                  porcentaje = Decimal.Round(dr.PrecioVentaActual / dr.PrecioCostoO, Me._decimalesRedondeoEnPrecio)
               End If
               dr.PrecioVentaNuevo = Decimal.Round(dr.PrecioCostoNuevo * porcentaje, Me._decimalesRedondeoEnPrecio)
            Next
         End If

         'Actualizo los precios de Compra y Venta
         If oMov.TipoMovimiento.CoeficienteStock > 0 And Publicos.ActualizaCostoYPrecioVenta Then

            Dim Precios As Entidades.MovimientoCompra = New Entidades.MovimientoCompra()

            For Each dr As Entidades.MovimientoCompraProducto In oMov.Productos
               If dr.PrecioCostoO <> dr.PrecioCostoNuevo Then
                  Precios.Productos.Add(dr)
               End If
            Next

            If Precios.Productos.Count <> 0 Then
               Using prec As ActualizarPreciosCompras = New ActualizarPreciosCompras(Precios)
                  prec.ShowDialog()
               End Using
            End If

         End If


         If Publicos.VisualizaComprobantesDeCompra Or oMov.Compra.TipoComprobante.Imprime Then

            'Vuelvo a leer la compra para que cargue el campo ORDEN del detalle, 
            'sino da error en caso de repetir el produccto
            Dim oCompras As Reglas.Compras = New Reglas.Compras()

            Dim Compra As Entidades.Compra = oCompras.GetUna(actual.Sucursal.Id, _
                        oMov.Compra.TipoComprobante.IdTipoComprobante, _
                        oMov.Compra.Letra, _
                        oMov.Compra.CentroEmisor, _
                        oMov.Compra.NumeroComprobante, _
                        oMov.Compra.Proveedor.IdProveedor)

            Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

            oImpr.ImprimirComprobante(Publicos.VisualizaComprobantesDeCompra, Me._decimalesAMostrarEnTotalXProducto)

         End If

         Me.Nuevo()

      End If

   End Sub

   Protected Overridable Function GetNewReglaMovimientoCompras() As Reglas.MovimientosCompras
      Return New Reglas.MovimientosCompras()
   End Function

   Protected Overridable Function GetNewEntidadMovimientoCompras() As Entidades.MovimientoCompra
      Return New Entidades.MovimientoCompra()
   End Function

   Protected Overridable Sub Insertar(oMovimientos As Reglas.MovimientosCompras, oMov As Entidades.MovimientoCompra)
      oMovimientos.Insertar(oMov, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
   End Sub

   Private Function ArmarTablaMultiplesRubros(ByVal omov As Entidades.MovimientoCompra _
                                          , ByVal rubrosCompra As DataTable _
                                          , ByVal grillaPantalla As DataGridView) As DataTable

      For Each filarubro As DataRow In rubrosCompra.Rows
         For Each prod As Entidades.MovimientoCompraProducto In omov.Productos
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

   Private Function GetDscAsiento(ByVal omov As Entidades.MovimientoCompra) As String
      Return omov.IdSucursal.ToString & "-" & omov.Compra.TipoComprobante.IdTipoComprobante.ToString & "-" & omov.Compra.Letra.ToString & "-" & omov.Compra.CentroEmisor.ToString & "-" & omov.Compra.NumeroComprobante.ToString & "-" & omov.Compra.Fecha.ToString
   End Function

   Private Function obtenerCantidadGrupos(ByVal omov As Entidades.MovimientoCompra) As Integer
      Dim oProcesoContable As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos()

      Dim idplanCuenta As Integer = oProcesoContable.getPlanCtaxDoc(omov.Compra.TipoComprobante.IdTipoComprobante)
      Return oProcesoContable.GetCantRubrosCompra(omov, idplanCuenta)

   End Function

   Private Sub SeteaDetalleProducto()
      Me._productos = New System.Collections.Generic.List(Of Entidades.MovimientoCompraProducto)
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
      Me.cmbConceptos.Enabled = False
      Me.cmbConceptos.SelectedIndex = -1
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

   End Sub

   Private Sub CalcularTotales()

      Const valorIVA210 As Decimal = 21D
      Const valorIVA105 As Decimal = 10.5D
      Const valorIVA270 As Decimal = 27D
      Const valorNoGravado As Decimal = 0D

      'Const formato As String = "#,##0." + New String("0"c, Me._decimalesAMostrar)

      Dim porcentajeDescuentoRecargo As Decimal = 0

      'brutos
      Dim bruto210 As Decimal = 0
      Dim bruto105 As Decimal = 0
      Dim bruto270 As Decimal = 0
      Dim brutoNoGravado As Decimal = 0

      'netos
      Dim neto210 As Decimal = 0
      Dim neto105 As Decimal = 0
      Dim neto270 As Decimal = 0
      Dim netoNoGravado As Decimal = 0
      Dim netoTotal As Decimal = 0

      'ivas
      Dim iva210 As Decimal = 0
      Dim iva105 As Decimal = 0
      Dim iva270 As Decimal = 0
      Dim ivaTotal As Decimal = 0

      'percepciones
      Dim percepcionIVA As Decimal = 0
      Dim percepcionIB As Decimal = 0
      Dim percepcionGanancias As Decimal = 0
      Dim percepcionVarias As Decimal = 0
      Dim percepcionTotal As Decimal = 0

      If Not Me.chbSinProductos.Checked Then
         For Each pro As Entidades.MovimientoCompraProducto In Me._productos
            Select Case pro.PorcentajeIVA
               Case valorIVA210
                  bruto210 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
               Case valorIVA105
                  bruto105 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
               Case valorIVA270
                  bruto270 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
               Case valorNoGravado
                  brutoNoGravado += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
            End Select
         Next

         For Each pro As Entidades.MovimientoCompraProducto In Me._productosRT
            Select Case pro.PorcentajeIVA
               Case valorIVA210
                  bruto210 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
               Case valorIVA105
                  bruto105 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
               Case valorIVA270
                  bruto270 += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
               Case valorNoGravado
                  brutoNoGravado += Math.Round(pro.ImporteTotal, Me._decimalesRedondeoEnPrecio)
            End Select
         Next

         Me.txtBruto210.Text = bruto210.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
         Me.txtBruto105.Text = bruto105.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
         Me.txtBruto270.Text = bruto270.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
         Me.txtBrutoNoGravado.Text = brutoNoGravado.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

         Me.tsbGrabar.Enabled = (Me._productos.Count > 0)

      Else
         bruto210 = Decimal.Parse(Me.txtBruto210.Text)
         bruto105 = Decimal.Parse(Me.txtBruto105.Text)
         bruto270 = Decimal.Parse(Me.txtBruto270.Text)
         brutoNoGravado = Decimal.Parse(Me.txtBrutoNoGravado.Text)

         Me.tsbGrabar.Enabled = True

      End If

      Me.txtBrutoTotal.Text = (bruto210 + bruto105 + bruto270 + brutoNoGravado).ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      'cargo el descuento/recargo
      porcentajeDescuentoRecargo = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

      'calcula los valores netos
      neto210 = bruto210 + (bruto210 * porcentajeDescuentoRecargo / 100)
      neto105 = bruto105 + (bruto105 * porcentajeDescuentoRecargo / 100)
      neto270 = bruto270 + (bruto270 * porcentajeDescuentoRecargo / 100)
      netoNoGravado = brutoNoGravado + (brutoNoGravado * porcentajeDescuentoRecargo / 100)

      Me.txtNetoAl210.Text = neto210.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtNetoAl105.Text = neto105.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtNetoAl270.Text = neto270.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtNetoNoGravado.Text = netoNoGravado.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      netoTotal = neto210 + neto105 + neto270 + netoNoGravado
      Me.txtNetoTotal.Text = netoTotal.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      'calcula los ivas
      iva210 = neto210 * valorIVA210 / 100
      iva105 = neto105 * valorIVA105 / 100
      iva270 = neto270 * valorIVA270 / 100

      If Not chbAjusteManualIVA.Checked Then
         Me.txtIVA105.Text = iva105.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
         Me.txtIVA210.Text = iva210.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
         Me.txtIVA270.Text = iva270.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))
      End If            'If Not chbAjusteManualIVA.Checked Then

      txtIVA105_Calculado = iva105
      txtIVA210_Calculado = iva210
      txtIVA270_Calculado = iva270

      ivaTotal = Decimal.Parse(txtIVA105.Text) + Decimal.Parse(txtIVA210.Text) + Decimal.Parse(txtIVA270.Text) '   iva210 + iva105 + iva270

      Me.txtIVATotal.Text = ivaTotal.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      For Each vi As Entidades.CompraImpuesto In _comprasImpuestosDespachoImportacion
         ivaTotal += vi.Importe
      Next

      'suma las percepciones
      percepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
      percepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
      percepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
      percepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)

      percepcionTotal = percepcionIVA + percepcionIB + percepcionGanancias + percepcionVarias
      Me.txtPercepcionTotal.Text = percepcionTotal.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      'sacar totales
      Me.txtTotalBruto.Text = Me.txtBrutoTotal.Text
      Me.txtTotalNeto.Text = Me.txtNetoTotal.Text
      Me.txtTotalIVA.Text = ivaTotal.ToString("#,##0." + New String("0"c, Me._decimalesEnTotales)) ''Me.txtIVATotal.Text
      Me.txtTotalPercepciones.Text = Me.txtPercepcionTotal.Text

      Me.txtTotalGeneral.Text = (netoTotal + ivaTotal + percepcionTotal).ToString("#,##0." + New String("0"c, Me._decimalesEnTotales))

      Me.CalcularDiferenciaDePago()

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

      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscCodigoProveedor.FilaDevuelta = Nothing

      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Text = String.Empty
      Me.bscProveedor.FilaDevuelta = Nothing

      Me.chbProductosDelProveedor.Checked = False

      Me.txtCategoriaFiscal.Text = String.Empty

      Me.bscObservacion.Text = String.Empty

      Me.dtpFecha.Value = Date.Now
      Me.cboPeriodoFiscal.SelectedIndex = 0

      Me.cboFormaPago.SelectedIndex = 0   '-1
      Me.cboRubro.SelectedIndex = 0       '-1

      Me.txtTotalBruto.Enabled = True
      Me.txtTotalBruto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtNetoAl210.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTotalNeto.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTotalIVA.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPorcDescRecargoGral.Enabled = True
      Me.txtPorcDescRecargoGral.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtTotalGeneral.Enabled = True
      Me.txtTotalGeneral.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      Me.txtPercepcionIVA.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPercepcionIIBB.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPercepcionVarias.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPercepcionGanancias.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      Me.txtPercepcionTotal.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      Me.txtTotalPercepciones.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      Me._ModificaDetalle = "TODO"
      Me._ModificaDetalleRT = "TODO"

      Me._productos.Clear()
      Me.dgvProductos.DataSource = Me._productos.ToArray()

      Me._productosRT.Clear()
      Me.dgvRemitoTransp.DataSource = Me._productosRT.ToArray()
      AjustarColumnasGrilla(dgvRemitoTransp, _titRemitoTransporte)

      If Me._comprobantesSeleccionados IsNot Nothing Then
         Me._comprobantesSeleccionados.Clear()
      End If

      Me.dgvPedidos.DataSource = Me._comprobantesSeleccionados
      Me.dgvfacturables.DataSource = Me._comprobantesSeleccionados

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

      Me.bscCodigoProveedor.Focus()

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
      Me._chequesPropios.Clear()
      Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()
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
      txtPercepcionIIBB.ReadOnly = False

      bscCodigoProveedor.Focus()

   End Sub

   Private Function ValidarInsertaProducto() As Boolean
      Dim prod As Entidades.Producto
      Try
         prod = New Reglas.Productos().GetUno(bscCodigoProducto2.Text.Trim())
      Catch ex As Exception
         prod = Nothing
      End Try

      'Solo lo valido en una compra, con el agregado de los distintas IVAs, se complico la pantalla
      If Double.Parse(Me.txtPrecio.Text) <= 0 And Me.cboTipoComprobante.Enabled And Not Boolean.Parse(New Reglas.Parametros().GetValor("COMPRASCONPRODUCTOSENCERO")) Then
         MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPrecio.Focus()
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
      If Decimal.Parse(Me.txtCantidad.Text) <= 0 And Boolean.Parse(Me.txtStock.Tag.ToString()) Then
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


      If Me.cmbConceptos.Visible And Me.cmbConceptos.SelectedIndex = -1 Then
         MessageBox.Show("Debe Asignar un Concepto de Expensas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbConceptos.Focus()
         Return False
      End If

      If prod IsNot Nothing Then
         If Publicos.TieneModuloExpensas Then
            'AndAlso prod.IncluirExpensas Then
            Dim incluyeExpensasActual As Boolean? = Me.IncluyeExpensasActual()
            If incluyeExpensasActual.HasValue AndAlso incluyeExpensasActual.Value <> prod.IncluirExpensas Then
               MessageBox.Show("No se pueden mesclar productos que se incluyen en expensas con comprobantes que no se incluyen.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Return False
            End If
         End If
      End If
      Return True
   End Function

   Private Function IncluyeExpensasActual() As Boolean?
      Dim result As Boolean? = Nothing
      For Each vp As Entidades.MovimientoCompraProducto In _productos
         Return vp.ProductoSucursal.Producto.IncluirExpensas
      Next
      Return result
   End Function

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      'Dim decPrecio As Decimal

      Dim oCF As Entidades.CategoriaFiscal = Nothing
      Dim PO As Decimal = 0
      Me._CodigoProductoProveedor = String.Empty

      If Me._proveedor Is Nothing Then
         oCF = Me._categoriaFiscalEmpresa
      Else
         oCF = Me._proveedor.CategoriaFiscal
      End If

      Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      If _utilizaCentroCostos Then
         If producto.CentroCosto Is Nothing Then
            ShowMessage(String.Format("El producto '{0} - {1}' no tiene asignado Centro de Costos. Por favor verifique y vuelva a intentar.",
                                      producto.IdProducto, producto.NombreProducto))
            cmbCentroCosto.SelectedIndex = -1
         Else
            cmbCentroCosto.SelectedValue = producto.IdCentroCosto.Value
         End If
         cmbCentroCosto.Enabled = _permiteCambiarCentroCostosCompras
      End If


      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Me._productoLoteTemporal = New Entidades.ProductoLote()

      Me._productoLoteTemporal.ProductoSucursal.Producto = producto ' New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

      Me.bscCodigoProducto2.Enabled = False
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscProducto2.Enabled = Publicos.ComprasModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
      ' Me.bscProducto2.Enabled = False

      Dim PrecioVentaSinIVA As Decimal = 0
      Dim PrecioVentaConIVA As Decimal = 0

      Dim alicuota As Decimal = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())


      Me._IVAO = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())

      'decPrecio = 0

      If Me._cargaPrecio = "PrecioCosto" Or Me._cargaPrecio = "PrecioVenta" Then

         PrecioVentaSinIVA = Decimal.Parse(dr.Cells(Me._cargaPrecio).Value.ToString())
         PrecioVentaConIVA = Decimal.Parse(dr.Cells(Me._cargaPrecio).Value.ToString())

         'Si se guardan con IVA se lo quito, evito muchas preguntas posteriores.
         If Publicos.PreciosConIVA Then
            Me._PO = PrecioVentaSinIVA
            PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA / (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
         Else
            Me._PO = PrecioVentaConIVA
            PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
         End If

         If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
            PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
            PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         End If

         If (Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And _
                  Me._proveedor.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                  DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then

            Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         Else
            Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
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

      Me._publicos.CargaComboConceptos(Me.cmbConceptos, Me.bscCodigoProducto2.Text)

      If Me.cmbConceptos.Items.Count > 0 Then
         Me.cmbConceptos.Enabled = True
         If Me.cmbConceptos.Items.Count > 1 Then
            Me.cmbConceptos.SelectedIndex = -1 'Obligo a cargarlo
         Else
            Me.cmbConceptos.SelectedIndex = 0
         End If
      End If


      'Monotributista / Consumidor Final (no usan el iva)
      'If Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
      '   Me.cmbPorcentajeIVA.Text = alicuota.ToString()
      'Else
      '   Me.cmbPorcentajeIVA.Text = "0"
      'End If


      'Exento sin IVA / Monotributo (por ahora lo dejo exento, mas sencillo para el IVA, pero deberia hacer lo mismo que facturacion.
      If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
         Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
         Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         Me.cmbPorcentajeIVA.Text = "0.00"
         Me.cmbPorcentajeIVA.Enabled = False
         If Publicos.PreciosConIVA Then
            Me._alicuota = 0
         Else
            Me._alicuota = alicuota
         End If

      Else
         Me.cmbPorcentajeIVA.Enabled = True
         Me.cmbPorcentajeIVA.Text = alicuota.ToString()
         Me._alicuota = alicuota
      End If

      If Publicos.UtilizaPrecioDeCompra AndAlso Me._proveedor IsNot Nothing Then
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
      If Me.bscProducto2.Enabled Then
         Me.bscProducto2.Focus()
         'Me.bscProducto2.SelectAll()
      Else
         Me.txtCantidad.Focus()
         Me.txtCantidad.SelectAll()
      End If

   End Sub

   Private Sub CargarProductoCompleto(ByVal dr As DataGridViewRow)

      Dim oProductos As Reglas.Productos = New Reglas.Productos()
      Dim oProdProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores()


      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      If Me.chbProductosDelProveedor.Checked Then
         Dim dtProdProv As DataTable = oProdProv.GetPorProductoYProveedor(_proveedor.IdProveedor, Me.bscCodigoProducto2.Text.Trim())
         Me.bscCodigoProducto2.Text = dtProdProv.Rows(0).Item("CodigoProductoProveedor").ToString().Trim()
      Else
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End If

      'Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      Me.bscCodigoProducto2.PresionarBoton()
      Me._editarNrosSeries = DirectCast(DirectCast(dr, DataGridViewRow).DataBoundItem, Entidades.MovimientoCompraProducto).ProductoSucursal.Producto.NrosSeries
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

      If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
         Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
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

      If _utilizaCentroCostos Then
         cmbCentroCosto.SelectedValue = Integer.Parse(dr.Cells("IdCentroCosto").Value.ToString())
      End If

   End Sub

   Private Sub CalcularDescuentoRecargo()
      ''Me.txtTotalDescRec.Text = Decimal.Round((Decimal.Parse(Me.txtBruto.Text) * Decimal.Parse(Me.txtPorDescRec.Text) / 100), 2).ToString()
      For Each vPro As Entidades.MovimientoCompraProducto In Me._productos
         vPro.DescRecGeneral = Decimal.Round((vPro.ImporteTotal * Decimal.Parse(Me.txtPorcDescRecargoGral.Text) / 100), Me._decimalesRedondeoEnPrecio)
      Next
   End Sub

   Private Sub InsertarProducto()

      Me._numeroOrden += 1
      'Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim oLineaDetalle As Entidades.MovimientoCompraProducto = New Entidades.MovimientoCompraProducto()
      With oLineaDetalle
         .IdProducto = Me.bscCodigoProducto2.Text
         .NombreProducto = Me.bscProducto2.Text
         .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)
         .DescuentoRecargo = Decimal.Parse(Me.txtDescuentoRecargo.Text)
         ''.DescRecGeneral = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

         .Precio = Decimal.Parse(Me.txtPrecio.Text.Trim())

         Dim ImporteBruto As Decimal
         Dim descRec1 As Decimal = Decimal.Round(.Precio * .DescuentoRecargoPorc / 100, Me._decimalesRedondeoEnPrecio)
         'Dim descRec As Decimal = Decimal.Round((.Precio + descRec1) * .DescRecGeneral / 100, Me._valorRedondeo)

         ImporteBruto = .Precio + descRec1

         .Cantidad = Decimal.Parse(Me.txtCantidad.Text)
         .ImporteTotal = Decimal.Parse(Me.txtTotalProducto.Text)
         .PrecioCostoO = Me._PO

         .DescRecGeneral = Decimal.Round((.ImporteTotal * Decimal.Parse(Me.txtPorcDescRecargoGral.Text) / 100), Me._decimalesRedondeoEnPrecio)

         .PorcentajeIVA = Decimal.Parse(Me.cmbPorcentajeIVA.Text)
         .IVA = .ImporteTotal * .PorcentajeIVA / 100

         Dim Prod As Entidades.Producto = New Reglas.Productos().GetUno(.IdProducto)

         If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
                  Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
                  Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then

            If Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
               .PrecioCostoNuevo = Decimal.Round(ImporteBruto / (1 + Me._IVAO / 100), Me._decimalesRedondeoEnPrecio)
            Else
               .PrecioCostoNuevo = ImporteBruto
            End If
         Else
            .PrecioCostoNuevo = ImporteBruto
         End If

         If Publicos.PreciosConIVA Then
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

         'ingreso los valores del Lote
         If Me._productoLoteTemporal.ProductoSucursal.Producto.Lote And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> 0 Then
            Dim idL As SeleccionDeLote = New SeleccionDeLote(.IdProducto, .Cantidad, DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock, True)
            If idL.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
               MessageBox.Show("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.btnInsertar.Focus()
               Exit Sub
            Else

               .IdLote = idL.bscLote.Text.ToUpper()
               .VtoLote = idL.dtpFechaVencimiento.Value.Date

               'Si Agrega, valido fechas.. sino.. que exista
               If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock > 0 Then

                  If Publicos.LoteSolicitaFechaVencimiento Then
                     'Controlar la fecha de la factura con la fecha de vencimiento del lote
                     If idL.dtpFechaVencimiento.Value.Date = Me.dtpFecha.Value.Date Then
                        If MessageBox.Show("La fecha del lote es igual a la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                           Exit Sub
                        End If
                     ElseIf idL.dtpFechaVencimiento.Value.Date < Me.dtpFecha.Value.Date Then
                        If MessageBox.Show("La fecha del lote es menor que la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                           Exit Sub
                        End If
                     End If

                     Me._productoLoteTemporal.FechaVencimiento = idL.dtpFechaVencimiento.Value
                  Else
                     _productoLoteTemporal.FechaVencimiento = Nothing
                  End If

                  'Valido que exista
               Else

                  Dim oProductoLote As Entidades.ProductoLote

                  oProductoLote = New Reglas.ProductosLotes().GetUno(idL.bscLote.Text.ToUpper(), actual.Sucursal.Id, Me.bscCodigoProducto2.Text)

                  If oProductoLote Is Nothing Then
                     MessageBox.Show("No existe el Lote informado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Sub
                  End If

                  If oProductoLote.CantidadActual < Math.Abs(Decimal.Parse(Me.txtCantidad.Text)) Then
                     MessageBox.Show("El Lote '" & idL.bscLote.Text & "' tiene en Stock " & oProductoLote.CantidadActual.ToString() & " quedaría en Cantidad Negativa en caso de Restarle " & Math.Abs(Decimal.Parse(Me.txtCantidad.Text)).ToString() & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Sub
                  End If

                  'Le pongo la fecha del Lote original
                  If oProductoLote.FechaVencimiento.HasValue Then
                     .VtoLote = oProductoLote.FechaVencimiento.Value.Date
                  Else
                     .VtoLote = Nothing
                  End If
                  Me._productoLoteTemporal.FechaVencimiento = .VtoLote

               End If

               Me._productoLoteTemporal.ProductoSucursal.Sucursal.IdSucursal = .IdSucursal
               Me._productoLoteTemporal.IdLote = .IdLote.ToUpper()
               Me._productoLoteTemporal.FechaIngreso = Me.dtpFecha.Value

               Me._productoLoteTemporal.CantidadInicial = .Cantidad
               Me._productoLoteTemporal.CantidadActual = .Cantidad
               Me._productoLoteTemporal.Habilitado = True
               'Por ahora no hace falta
               'Me._productoLoteTemporal.Orden = Me._numeroOrden
               Me._productosLotes.Add(Me._productoLoteTemporal)

            End If
         End If

         'ingreso los nros. de serie
         ' VER PORQUE ELIMINA LOS RENGLONES QUE NO SE EDITARON

         oLineaDetalle.ProductoSucursal.Producto = New Reglas.Productos().GetUno(.IdProducto)

         If oLineaDetalle.ProductoSucursal.Producto.NroSerie Then
            Dim cantidadDeProductos As Integer = Integer.Parse(Math.Round(.Cantidad, 0).ToString())

            If _vieneDelDobleClick Then
               oLineaDetalle.ProductoSucursal.Producto.NrosSeries = _editarNrosSeries
            End If

            Dim Ver As Boolean = False 'Para distinguir el llamado del boton Ver en Grilla
            Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos, oLineaDetalle.ProductoSucursal.Producto, _productosNrosSeries, Ver)

            If ins.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
               MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie los tiene que ingresar en la compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.btnInsertar.Focus()
               Exit Sub
            Else
               For Each ns As Entidades.ProductoNroSerie In ins.ProductosNrosSerie
                  Me._productosNrosSeries.Add(ns)
               Next

               If Not _vieneDelDobleClick Then
                  oLineaDetalle.ProductoSucursal.Producto.NrosSeries.Clear()
                  For Each pns As Entidades.ProductoNroSerie In ins.ProductosNrosSerie
                     oLineaDetalle.ProductoSucursal.Producto.NrosSeries.Add(pns)
                  Next
               End If
            End If

         End If
         If Me.cmbConceptos.SelectedItem IsNot Nothing Then
            .IdConcepto = Integer.Parse(Me.cmbConceptos.SelectedValue.ToString())
            .NombreConcepto = Me.cmbConceptos.Text.ToString()
         End If

         .FechaActualizacion = Me.dtpFechaActPrecios.Value

         .Orden = Me._numeroOrden
      End With

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

      Me.dgvProductos.DataSource = _productos.ToArray()
      Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1

      Me.FormatearGrilla()
      Me.dgvProductos.Refresh()
      'Me.CalcularTotalProducto()
      Me.LimpiarCamposProductos()
      Me.CalcularTotales()
      'Me.CalcularDescuentoRecargo()
      'Me.CalcularTotales()

      ProductoFocus()

      Me._vieneDelDobleClick = False
   End Sub

   Private Sub EliminarLineaProducto()
      Me._productos.RemoveAt(Me.dgvProductos.SelectedRows(0).Index)

      If Me.dgvProductos.SelectedRows(0).Cells("colIdLote").Value IsNot Nothing Then
         Me.EliminarProductoLote(Me.dgvProductos.SelectedRows(0).Cells("colIdLote").Value.ToString(), _
                     Integer.Parse(Me.dgvProductos.SelectedRows(0).Cells("IdSucursal").Value.ToString()), _
                     Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value.ToString())
      End If

      If Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value IsNot Nothing Then

         'Dim i As Integer = Me._productosNrosSeries.Count
         'Do While i > 0
         '   If Me._productosNrosSeries(i - 1).Producto.IdProducto = Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value.ToString() Then
         '      Me._productosNrosSeries.RemoveAt(i - 1)
         '   End If
         '   i -= 1
         'Loop

         Dim colAux As List(Of Entidades.ProductoNroSerie) = New List(Of Entidades.ProductoNroSerie)()
         For Each nroSerie As Entidades.ProductoNroSerie In Me._productosNrosSeries
            If nroSerie.Producto.IdProducto = Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value.ToString() Then
               For Each nroSerie2 As Entidades.ProductoNroSerie In Me._editarNrosSeries
                  If nroSerie.NroSerie = nroSerie2.NroSerie Then
                     colAux.Add(nroSerie)
                  End If
               Next
            End If
         Next

         For Each nro As Entidades.ProductoNroSerie In colAux
            Me._productosNrosSeries.Remove(nro)
         Next

      End If

      Me.dgvProductos.DataSource = Me._productos.ToArray()

      Me.CalcularTotales()
      Me.CalcularDescuentoRecargo()
      Me.CalcularTotales()
   End Sub

   Private Sub EliminarProductoLote(ByVal idLote As String, ByVal idSucursal As Integer, ByVal idProducto As String)
      Dim pl As Entidades.ProductoLote
      For i As Integer = 0 To Me._productosLotes.Count - 1
         pl = Me._productosLotes(i)
         If pl.IdLote = idLote And pl.ProductoSucursal.Sucursal.IdSucursal = idSucursal And pl.ProductoSucursal.Producto.IdProducto = idProducto Then
            Me._productosLotes.Remove(pl)
            Exit For
         End If
      Next
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString

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

      Me.bscCodigoProveedor.Permitido = False
      Me.bscProveedor.Permitido = False

      'Me.bscCodigoProducto2.Enabled = True
      'Me.bscProducto2.Enabled = True
      'Me.txtCantidad.Enabled = True
      'Me.txtPrecio.Enabled = True
      'Me.txtPorDescuento.Enabled = True

      Dim o As Reglas.Proveedores = New Reglas.Proveedores()
      Me._proveedor = o.Proveedores_G1Todos(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))

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
      ElseIf DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 And _
         Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).AfectaCaja And _
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
      End If

   End Sub

   Private Sub LimpiarDetalle()
      Dim ini As String = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)

      Me._productos.Clear()
      Me.dgvProductos.DataSource = Me._productos.ToArray()
      Me.dgvProductos.Refresh()

      Me._productosLotes.Clear()
      Me._productosNrosSeries.Clear()

      Me.LimpiarCamposProductos()

      Me.txtPorcDescRecargoGral.Text = ini

      Me.txtIVA210.Text = ini
      Me.txtIVA105.Text = ini
      Me.txtIVA270.Text = ini
      Me.txtIVATotal.Text = ini

      txtIVA105_Calculado = 0
      txtIVA210_Calculado = 0
      txtIVA270_Calculado = 0

      Me.txtBruto210.Text = ini
      Me.txtBruto105.Text = ini
      Me.txtBruto270.Text = ini
      Me.txtBrutoNoGravado.Text = ini
      Me.txtBrutoTotal.Text = ini

      Me.txtNetoAl210.Text = ini
      Me.txtNetoAl105.Text = ini
      Me.txtNetoAl270.Text = ini
      Me.txtNetoNoGravado.Text = ini
      Me.txtNetoTotal.Text = ini

      Me.txtTotalBruto.Text = ini
      Me.txtTotalNeto.Text = ini
      Me.txtTotalIVA.Text = ini
      Me.txtTotalPercepciones.Text = ini
      Me.txtTotalGeneral.Text = ini

   End Sub

   Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Function ValidarInsertarChequePropio() As Boolean

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
         If ent.NumeroCheque = Integer.Parse(Me.txtNroChequePropio.Text) And _
                  ent.Banco.IdBanco = Integer.Parse(Me.cmbBancoPropio.SelectedValue.ToString()) And _
                  ent.IdBancoSucursal = Integer.Parse(Me.txtSucursalBancoPropio.Text) And _
                  ent.Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalChequePropio.Text) Then
            MessageBox.Show("El cheque ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNroChequePropio.Focus()
            Return False
         End If
      Next

      If New Reglas.Cheques().Existe(actual.Sucursal.IdSucursal, _
                                    Integer.Parse(Me.txtNroChequePropio.Text), _
                                    Integer.Parse(Me.cmbBancoPropio.SelectedValue.ToString()), _
                                    Integer.Parse(Me.txtSucursalBancoPropio.Text), _
                                    Integer.Parse(Me.txtCodPostalChequePropio.Text)) Then
         MessageBox.Show("El Cheque fué Emitido con Anterioridad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroChequePropio.Focus()
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
      Me.cmbBancoPropio.SelectedIndex = -1
      Me.txtCodPostalChequePropio.Text = "0"
      Me.txtSucursalBancoPropio.Text = "0"
      Me.txtNroChequePropio.Text = "0"
      Me.dtpChequePropioCobro.Value = Date.Now
      Me.dtpChequePropioEmision.Value = Date.Now
      Me.txtImporteChequePropio.Text = "0.00"
   End Sub

   Private Sub CargarChequeCompleto(ByVal dr As DataGridViewRow)

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

      pago = Decimal.Round(pago, 2) + _
               Decimal.Parse(Me.txtEfectivo.Text) + _
               Decimal.Parse(Me.txtTarjetas.Text) + _
               Decimal.Parse(Me.txtTransferenciaBancaria.Text) + _
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

   Private Sub ActualizaGrillaChequesTerceros(ByVal dtCheques As DataTable)


      'Me._chequesTerceros.Clear()

      Dim blnInsertar As Boolean

      Dim oLineaDetalle As Entidades.Cheque

      'Siempre viene 1 registro, manejar directamente el datatable

      For Each cRow As DataRow In dtCheques.Rows
         oLineaDetalle = New Entidades.Cheque()
         With oLineaDetalle
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
         End With

         blnInsertar = True

         For i As Integer = 0 To Me._chequesTerceros.Count - 1
            If Me._chequesTerceros(i).NumeroCheque = Integer.Parse(cRow("NumeroCheque").ToString()) And _
               Me._chequesTerceros(i).Banco.IdBanco = Integer.Parse(cRow("IdBanco").ToString()) And _
               Me._chequesTerceros(i).IdBancoSucursal = Integer.Parse(cRow("IdBancoSucursal").ToString()) And _
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

   Private Sub CargarDatosCuentaBancaria(ByVal dr As DataGridViewRow)
      Me.bscCuentaBancariaPropio.Text = dr.Cells("NombreCuenta").Value.ToString()
      Me.cmbBancoPropio.SelectedValue = dr.Cells("IdBanco").Value
      Me.txtSucursalBancoPropio.Text = dr.Cells("IdBancoSucursal").Value.ToString.Trim()
      Me.txtCodPostalChequePropio.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.txtNroChequePropio.Text = Me.ProximoChequeEmitido(Integer.Parse(dr.Cells("IdCuentaBancaria").Value.ToString())).ToString()
   End Sub

   Private Function ProximoChequeEmitido(ByVal IdCuentaBancaria As Integer) As Long

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

   Private Sub CargarComprobantesFacturables(ByVal selec As List(Of Entidades.Compra))

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


      Me.dgvfacturables.DataSource = Me._comprobantesSeleccionados

   End Sub

   Private Sub CargarProductosFacturables(ByVal selec As List(Of Entidades.Compra))

      'limpio todos los productos de la grilla
      Me._productos = Nothing
      Me._productos = New List(Of Entidades.MovimientoCompraProducto)

      'creo una coleccion para probar si existe codigos repetidos
      Dim codigos As List(Of String) = New List(Of String)

      Dim Producto As Entidades.ProductoSucursal

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

      For Each v As Entidades.Compra In selec

         'En REMITO no tendria sentido que haya carga el descuento.
         'Poner el recargo general solo si cargo uno, si pone mas, se pierde.
         If selec.Count = 1 And Not v.TipoComprobante.CargaPrecioActual Then
            Me.txtDescuentoRecargoPorc.Text = v.DescuentoRecargoPorc.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         End If

         For Each vp As Entidades.CompraProducto In v.ComprasProductos

            blnEntrar = True
            Me._numeroOrden += 1

            Dim oLineaDetalle As Entidades.MovimientoCompraProducto = New Entidades.MovimientoCompraProducto()
            With oLineaDetalle
               .IdProducto = vp.Producto.IdProducto
               .NombreProducto = vp.Producto.NombreProducto

               Producto = New Reglas.ProductosSucursales().GetUno(vp.IdSucursal, vp.Producto.IdProducto)

               .DescuentoRecargoPorc = vp.DescuentoRecargoPorc
               .DescuentoRecargo = vp.DescuentoRecargo

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
                  If Publicos.PreciosConIVA Then
                     PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA / (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
                  Else
                     PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
                  End If

                  If prod.Producto.Moneda.IdMoneda = 2 Then
                     PrecioVentaSinIVA = PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text)
                     PrecioVentaConIVA = PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text)
                  End If


                  'Exento sin IVA / Monotributo (por ahora lo dejo exento, mas sencillo para el IVA, pero deberia hacer lo mismo que facturacion.
                  If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
                     Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
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
               .ImporteTotal = (.Precio * .Cantidad) + .DescuentoRecargo
               .IVA = .ImporteTotal * .PorcentajeIVA / 100
               .TotalProducto = .ImporteTotal + .IVA
               If vp.Stock <> 0 Then
                  .Stock = vp.Stock
               Else
                  .Stock = 0
               End If
               .IdSucursal = vp.IdSucursal
               .Usuario = vp.Usuario
               .IdLote = ""
               .VtoLote = Nothing

               .Orden = Me._numeroOrden
            End With

            Me._productos.Add(oLineaDetalle)

         Next

      Next

      'Elimino los de Cantidades en Cero (Puede suceder por una devolucion).
      Dim blnLlegoAlFin As Boolean = False
      Dim Cont As Integer
      Do While Not blnLlegoAlFin And Me._productos.Count > 0
         Cont = 0
         For Each pro As Entidades.MovimientoCompraProducto In Me._productos
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
      '------------------------------------------------------------------------

      Me.dgvProductos.DataSource = Me._productos
      Me.tsbGrabar.Enabled = True

   End Sub

   Private Sub CargarComprobantesFacturablesCom(ByVal selec As List(Of Entidades.Compra))

      Me._comprobantesSeleccionados = New List(Of Entidades.Compra)

      For Each v As Entidades.Compra In selec
         Me._comprobantesSeleccionados.Add(v)

         If Me._cantMaxItemsObserv > 0 And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GeneraObservConInvocados Then
            Me.bscObservacion.Text = "Invoco: " & v.TipoComprobante.Descripcion & " ´" & v.Letra & "´ " & v.CentroEmisor.ToString("0000") & "-" & v.NumeroComprobante.ToString("00000000") & ". Emision: " & v.Fecha.ToString("dd/MM/yyyy")
         End If

      Next

      Me.dgvfacturables.DataSource = Me._comprobantesSeleccionados

   End Sub

   'Private Sub CargarProductosFacturablesCom(ByVal selec As List(Of Entidades.Compra))

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

   Private Sub CargarObservacion(ByVal dr As DataGridViewRow)
      Me.bscObservacion.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub CargarObservDetalle(ByVal dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub CargarObservDetalleCompleto(ByVal dr As DataGridViewRow)
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

      Dim dt As DataTable

      dt = oCtaCteProv.GetSaldosCtaCte(-1, , _proveedor.IdProveedor)

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

            'Dim oProductos As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            'Dim pro1 As Entidades.ProductoSucursal

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Dim ProdDT As Entidades.Producto


            Dim DescRec1 As Decimal, DescRec2 As Decimal
            Dim PrecioNeto As Decimal

            For Each pro As Entidades.MovimientoCompraProducto In Me._productos




            Next

            Me.dgvProductos.DataSource = _productos.ToArray()
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
      Me.txtDescuentoRecargo.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
      Me.txtDescuentoRecargoPorc.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
      Me.txtTotalProducto.Formato = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()

      Me.txtCantidad.Formato = "N" + _decimalesMostrarEnCantidad.ToString()


      Dim formatoDecimal As String = ""

      formatoDecimal = "N" + Me._decimalesAMostrarEnPrecio.ToString()

      Me.dgvProductos.Columns("Precio").DefaultCellStyle.Format = formatoDecimal
      Me.dgvProductos.Columns("Importe").DefaultCellStyle.Format = formatoDecimal
      Me.dgvProductos.Columns("TotalProducto").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()

      txtTotalProducto.Enabled = _permiteModificarSubtotal
   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      AjustarColumnasGrilla(ugImpuestosDespacho, _tit)
   End Sub

   Private Sub CargarDatosDestinacion(ByVal dr As DataGridViewRow)
      bscCodigoDestinacion.Text = dr.Cells(Entidades.AduanaDestinacion.Columnas.IdDestinacion.ToString()).Value.ToString()
      bscDestinacion.Text = dr.Cells(Entidades.AduanaDestinacion.Columnas.NombreDestinacion.ToString()).Value.ToString()
   End Sub

   Private Sub CargarDatosDespachante(ByVal dr As DataGridViewRow)
      bscCodigoDespachante.Text = dr.Cells(Entidades.AduanaDespachante.Columnas.IdDespachante.ToString()).Value.ToString()
      bscDespachante.Text = dr.Cells(Entidades.AduanaDespachante.Columnas.NombreDespachante.ToString()).Value.ToString()
   End Sub

   Private Sub CargarDatosAduana(ByVal dr As DataGridViewRow)
      bscCodigoAduana.Text = dr.Cells(Entidades.Aduana.Columnas.IdAduana.ToString()).Value.ToString()
      bscAduana.Text = dr.Cells(Entidades.Aduana.Columnas.NombreAduana.ToString()).Value.ToString()
   End Sub

   Private Sub CargarDatosAgenteTransporte(ByVal dr As DataGridViewRow)
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
      txtIVA105.ReadOnly = Not habilita
      txtIVA210.ReadOnly = Not habilita
      txtIVA270.ReadOnly = Not habilita

      txtIVA105.TabStop = Not txtIVA105.ReadOnly
      txtIVA210.TabStop = Not txtIVA210.ReadOnly
      txtIVA270.TabStop = Not txtIVA270.ReadOnly
   End Sub

   Private Sub ProductoFocus()
      If _comprasPosicionarNombreProducto Then
         Me.bscProducto2.Focus()
      Else
         Me.bscCodigoProducto2.Focus()
      End If
   End Sub

#End Region

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

   Private Sub txtNumeroLote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroLote.KeyDown
      'Me.PresionarTab(e)
      If e.KeyCode = Keys.Enter Then
         Me.bscCodigoProducto2RT.Focus()
      End If
   End Sub

   Private Sub txtValorDeclarado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValorDeclarado.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtBultos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBultos.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtValorDeclarado_Leave(sender As Object, e As EventArgs) Handles txtValorDeclarado.Leave
      Me.txtValorDeclarado.Text = Decimal.Parse(Me.txtValorDeclarado.Text).ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtBrutoNoGravado.Text = txtValorDeclarado.Text
      Me.txtNetoNoGravado.Text = txtValorDeclarado.Text
      Me.txtBrutoTotal.Text = txtValorDeclarado.Text
      Me.txtNetoTotal.Text = txtValorDeclarado.Text
      Me.txtTotalBruto.Text = txtValorDeclarado.Text
      Me.txtTotalNeto.Text = txtValorDeclarado.Text
      Me.txtTotalGeneral.Text = txtValorDeclarado.Text
      'Se quiere que afecte el valor declarado en el calculo.
      'Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)
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

         Dim oCompras As New Reglas.Compras
         If oCompras.Existe(0, _
                              Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), _
                              Me.cboTipoComprobante.SelectedValue.ToString, _
                              Me.cboLetra.Text, _
                              Short.Parse("0" & Me.txtEmisorFactura.Text), _
                              Long.Parse("0" & Me.txtNumeroFactura.Text)) Then

            MessageBox.Show("Este comprobante ya fue INGRESADO con ANTERIORIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroFactura.Focus()
            Exit Sub
         End If

         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Dim oProdProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores()

         Dim listaPreciosPredeterminada As Integer = Publicos.ListaPreciosPredeterminada
         If Me.chbProductosDelProveedor.Checked Then

            Me._publicos.PreparaGrillaProductosProveedor2(Me.bscCodigoProducto2RT)
            Me.bscCodigoProducto2RT.Datos = oProdProv.GetPorCodigoProdProv(Me.bscCodigoProducto2RT.Text.Trim(), actual.Sucursal.Id, listaPreciosPredeterminada, "COMPRAS", _proveedor.IdProveedor)
         Else
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2RT)
            Me.bscCodigoProducto2RT.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2RT.Text.Trim(), actual.Sucursal.Id, listaPreciosPredeterminada, "COMPRAS")
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCodigoProducto2RT_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2RT.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProductoRT(e.FilaDevuelta)
            Me.txtCantidadRT.Focus()
            Me.txtCantidadRT.SelectAll()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2RT_BuscadorClick() Handles bscProducto2RT.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2RT)
         Me.bscProducto2RT.Datos = oProductos.GetPorNombre(Me.bscProducto2RT.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2RT_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2RT.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProductoRT(e.FilaDevuelta)
            Me.txtCantidadRT.Focus()
            Me.txtCantidadRT.SelectAll()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtCantidadRT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadRT.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnInsertarRT.Focus()
      End If
   End Sub

   Private Sub dgvRemitoTransp_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRemitoTransp.CellDoubleClick
      Try
         If Me._ModificaDetalleRT <> "NO" Then
            'limpia los textbox, y demas controles
            Me.LimpiarCamposProductosRT()
            'carga el producto seleccionado de la grilla en los textbox 
            Me.CargarProductoCompletoRT(Me.dgvRemitoTransp.Rows(e.RowIndex))
            'elimina el producto de la grilla
            Me.EliminarLineaProductoRT()

            If Me._ModificaDetalle = "SOLOPRECIOS" Then
               Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
               Me.btnInsertar.Enabled = True
               Me.txtCantidad.Focus()
               Me.txtCantidad.SelectAll()
            Else
               Me.txtCantidad.Focus()
               Me.txtCantidad.SelectAll()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub CargarProductoRT(ByVal dr As DataGridViewRow)

      Me.bscCodigoProducto2RT.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscCodigoProducto2RT.Enabled = False

      Me.bscProducto2RT.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscProducto2RT.Enabled = Publicos.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

      Me.txtStockRT.Text = dr.Cells("Stock").Value.ToString()
      Me.txtStockRT.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

      Me.txtCantidadRT.Text = "1." + New String("0"c, Me._decimalesEnCantidad)

      If Not String.IsNullOrEmpty(dr.Cells("IdSubRubro").Value.ToString()) Then

         'Cargo el Descuento/Recargo cargado en el subrubro
         Dim oSR As Reglas.SubRubros = New Reglas.SubRubros()
         Dim SubR As Entidades.SubRubro

         SubR = oSR.GetUno(Integer.Parse(dr.Cells("IdSubRubro").Value.ToString()))
         DescRecPorc1RT = SubR.DescuentoRecargo

         'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
         Dim oCSR As Reglas.ClientesDescuentosSubRubros = New Reglas.ClientesDescuentosSubRubros()
         Dim SubR2 As Entidades.SubRubro

         'SubR2 = oCSR.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdSubRubro").Value.ToString()))
         'DescRecPorc2RT = SubR2.DescuentoRecargo

      End If
      '---------------------------------------------------------------------------

      'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
      Dim oCDM As Reglas.ClientesDescuentosMarcas = New Reglas.ClientesDescuentosMarcas()
      Dim Marc As Entidades.Marca

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

      If (Me._proveedor.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or _
      Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
         Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         Me.txtPrecio.Tag = Me.txtPrecio.Text
      Else
         'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
         Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
         Me.txtPrecio.Tag = Me.txtPrecio.Text
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

      If Double.Parse(Me.txtCantidadRT.Text) < 0 Then
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

         If Publicos.FacturarSinStock = "NOPERMITIR" Then
            MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCantidadRT.Focus()
            Return False

         ElseIf Publicos.FacturarSinStock = "AVISARYPERMITIR" Then
            MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      End If

      '2 Parte. Del Producto ingreso mas lo que esta en la grilla.

      If Boolean.Parse(Me.txtStockRT.Tag.ToString()) And blnControlarStock Then

         Dim cantidadTotal As Decimal = Decimal.Parse(Me.txtCantidadRT.Text)

         For Each pro1 As Entidades.MovimientoCompraProducto In Me._productosRT
            If pro1.IdProducto = Me.bscCodigoProducto2RT.Text.Trim() Then
               cantidadTotal = cantidadTotal + pro1.Cantidad
            End If
         Next

         If cantidadTotal > Decimal.Parse(Me.txtStockRT.Text) Then

            If Publicos.FacturarSinStock = "NOPERMITIR" Then
               MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return False

            ElseIf Publicos.FacturarSinStock = "AVISARYPERMITIR" Then
               MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

         End If

      End If

      '-----------------------------------------

      Return True

   End Function

   Private Sub InsertarProductoRT()



      Dim oLineaDetalle As Entidades.MovimientoCompraProducto = New Entidades.MovimientoCompraProducto()

      Dim costo As Decimal = 0
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

      alicuotaIVA = 0

      'Precio de Costo, Opciones: ACTUAL o PROMPOND;<meses>
      If Publicos.VentasPrecioCosto <> "ACTUAL" Then

         Dim CalculoCosto() As String = Publicos.VentasPrecioCosto.Split(";"c)

         Dim oCP As Reglas.ComprasProductos = New Reglas.ComprasProductos()

         Dim OtroPrecioCosto As Decimal = 0

         'Dejo preparado para distintas formas.
         If CalculoCosto(0) = "PROMPOND" Then
            OtroPrecioCosto = oCP.GetCostoPromedioPonderado(actual.Sucursal.Id, _
                                                            Me.bscCodigoProducto2.Text, _
                                                            Date.Today.AddMonths(Integer.Parse(CalculoCosto(1).ToString()) * (-1)), _
                                                            Date.Today)

            If OtroPrecioCosto <> 0 Then
               precioCosto = OtroPrecioCosto
            End If
         End If

      End If

      'Le quito el IVA que el producto tiene en forma predeterminada.
      If Publicos.PreciosConIVA Then
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

      Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidadRT.Text) * kilosProducto, 3)

      Dim precioProducto As Decimal = precioCosto ' Decimal.Parse(Me.txtPrecio.Text.Trim())

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

      Me.CalculaValoresRT(Decimal.Parse(Me.txtCantidadRT.Text), alicuotaIVA, precioProducto, descRecPorc1, descRecPorc2, descRecPorGeneral, _
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
                          Kilos,
                          alicuotaIVA,
                          importeIva,
                          centroCosto)

      Me._numeroOrden += 1
      oLineaDetalle.Orden = Me._numeroOrden
      Me._productosRT.Add(oLineaDetalle)

      Me.dgvRemitoTransp.DataSource = Me._productosRT.ToArray()
      AjustarColumnasGrilla(dgvRemitoTransp, _titRemitoTransporte)
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

   Private Sub CambiarEstadoControlesDetalle(ByVal Habilitado As Boolean)

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
         If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or _
            DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
            Me.cmbPorcentajeIVA.Enabled = False
         End If
      End If

   End Sub

   Private Sub EliminarLineaProductoRT()

      Me._productosRT.RemoveAt(Me.dgvRemitoTransp.SelectedRows(0).Index)
      Me.dgvRemitoTransp.DataSource = Me._productosRT.ToArray()
      AjustarColumnasGrilla(dgvRemitoTransp, _titRemitoTransporte)

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

   Private Sub CambiarEstadoControlesDetalleRT(ByVal Habilitado As Boolean)

      Me.btnLimpiarProductoRT.Enabled = Habilitado
      Me.bscCodigoProducto2RT.Enabled = Habilitado
      Me.bscProducto2RT.Enabled = Habilitado
      Me.txtCantidadRT.Enabled = Habilitado
      Me.btnInsertarRT.Enabled = Habilitado
      Me.btnEliminarRT.Enabled = Habilitado

   End Sub

   Private Sub CargarDatosTransportista(ByVal dr As DataGridViewRow)
      Me.bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
      'Me.txtDireccionTransportista.Text = dr.Cells("DireccionTransportista").Value.ToString()
      'Me.txtLocalidadTransportista.Text = dr.Cells("NombreLocalidad").Value.ToString()
      'Me.txtTelefoTransportista.Text = dr.Cells("TelefonoTransportista").Value.ToString()

      Dim Transp As Reglas.Transportistas = New Reglas.Transportistas()
      Me._transportistaA = Transp.GetUno(Long.Parse(dr.Cells("IdTransportista").Value.ToString()))
   End Sub

   Private Sub CargarProductoCompletoRT(ByVal dr As DataGridViewRow)

      Dim oProductos As Reglas.Productos = New Reglas.Productos

      Me.bscCodigoProducto2RT.Text = dr.Cells("grtIdProducto").Value.ToString.Trim()

      'Llamo al evento para cargar el objeto "FilaDevuelta" validado luego al insertar el producto.
      Me.bscCodigoProducto2RT.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2RT.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Me.bscCodigoProducto2RT.PresionarBoton()

      If Publicos.FacturacionModificaDescripcionProducto And Boolean.Parse(Me.bscCodigoProducto2RT.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
         'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
         Me.bscProducto2RT.Text = dr.Cells("grtProductoDesc").Value.ToString()
      End If

      'Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
      Me.txtStockRT.Text = Me.bscCodigoProducto2RT.FilaDevuelta.Cells("Stock").Value.ToString()
      Me.txtTamanioRT.Text = Me.bscCodigoProducto2RT.FilaDevuelta.Cells("Tamano").Value.ToString()
      Me.txtUMRT.Text = Me.bscCodigoProducto2RT.FilaDevuelta.Cells("IdUnidadDeMedida").Value.ToString()

      Me.txtCantidadRT.Text = dr.Cells("grtCantidad").Value.ToString()

   End Sub

   Private Sub CalcularTotalProductoRT(ByVal PrecioLista As Decimal)
      TotalProductoRT = (PrecioLista * Decimal.Parse(Me.txtCantidadRT.Text)) + DescRecRT
   End Sub

   Private Sub CargarUnArticulo(linea As Entidades.MovimientoCompraProducto,
                              idProducto As String,
                              productoDescripcion As String,
                              descuentoRecargoPorc1 As Decimal,
                              descuentoRecargo As Decimal,
                              precio As Decimal,
                              cantidad As Decimal,
                              importeTotal As Decimal,
                              stock As Decimal,
                              kilos As Decimal,
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
         '.Kilos = kilos
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

   Private Sub CalculaValoresRT(ByVal cantidad As Decimal, _
                           ByVal alicuotaIVA As Decimal, _
                           ByRef precioProducto As Decimal, _
                           ByVal descRecPorc1 As Decimal, _
                           ByVal descRecPorc2 As Decimal, _
                           ByVal descRecPorGeneral As Decimal, _
                           ByRef precioNeto As Decimal, _
                           ByRef importeBruto As Decimal, _
                           ByRef importeIVA As Decimal, _
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

      For Each vPro As Entidades.MovimientoCompraProducto In Me._productosRT


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

      For Each dr As Entidades.MovimientoCompraProducto In Me._productosRT

         'impuestoInterno = dr.ImporteImpuestoInterno

         Dim precioParaDescuento As Decimal
         If Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            If DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
               DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
               Reglas.Publicos.FacturacionDescuentoImpIntIgualado Then
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

   Private Sub CalcularDescuentosProductosRT(ByVal PrecioLista As Decimal)
      Dim DescRec1 As Decimal
      Dim DescRec2 As Decimal
      Dim DescRecT As Decimal

      DescRec1 = PrecioLista * DescRecPorc1RT / 100

      DescRec2 = (PrecioLista + DescRec1) * DescRecPorc2RT / 100

      DescRecT = Decimal.Round((DescRec1 + DescRec2) * Decimal.Parse(Me.txtCantidadRT.Text), Me._decimalesRedondeoEnPrecio)

      DescRecRT = DescRecT

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

   Private Sub txtPrecioLista_Leave(sender As Object, e As EventArgs) Handles txtPrecioLista.Leave, txtDescuento1.Leave, txtDescuento2.Leave, txtDescuento3.Leave, txtDescuento4.Leave
      Try
         Me.txtPrecio.Text = Me.GetPrecioCostoDesdePrecioCompra().ToString("N" + Me._decimalesRedondeoEnPrecio.ToString())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub txtPrecioLista_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioLista.KeyDown, txtDescuento1.KeyDown, txtDescuento2.KeyDown, txtDescuento3.KeyDown
      Me.PresionarTab(e)
   End Sub


   Private Sub txtDescuento4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuento4.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPrecio.Focus()
      End If
   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      Me.txtNumeroFactura.Enabled = Not chbNumeroAutomatico.Checked
   End Sub
End Class