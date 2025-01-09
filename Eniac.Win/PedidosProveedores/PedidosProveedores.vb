Imports System.ComponentModel

Public Class PedidosProveedores
   Implements IConParametros

   Private _IdCategoriaFiscalOriginal As Short = 0
   Private _ConfiguracionImpresoras As Boolean
   Private _titContactos As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tipoTipoComprobante As String
   Private _permitePrecioCero As Boolean?
   Private _solicitaPrecioVentaPorTamano As Boolean = False
   Private _cotizacionDolar_Prev As Decimal
   Private _calculaPreciosSegunFormula As Boolean
   Private _CodigoProductoProveedor1 As String

   Private _ordenProducto As Integer

   Public Property NumeroOrdenCompra As Long
   Private _drProductosDesdeStockColeccion As DataRow()

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Public Sub New(pedido As Entidades.PedidoProveedor)
      Me.New()
      PedidoAEditar = pedido
   End Sub

#Region "Constantes"

   Private Const funcionActual As String = "Ventas"
   Private Const funcionSupervisor As String = "FacturacionRapidaSuper"

#End Region

#Region "Campos"

   Private _pedidosProductos As List(Of Entidades.PedidoProductoProveedor)
   'Lo comentamos para cuando se active la funcionalidad de ProveedorContacto
   'Private _pedidosContactos As List(Of Entidades.ClienteContacto)

   Private _subTotales As List(Of Entidades.VentaImpuesto)
   Private _estado As Estados
   Private _publicos As Publicos
   Private _numeroComprobante As Integer
   Private _eProveedor As Entidades.Proveedor
   Private _comprobantesSeleccionados As List(Of Entidades.Venta)
   Private _ModificaDetalle As String
   Private _cheques As List(Of Entidades.Cheque)
   Private _tarjetas As List(Of Entidades.VentaTarjeta)
   Private _pedidosObservaciones As List(Of Entidades.PedidoObservacionProveedor)
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

   Private _editarProductoDesdeGrilla As Boolean

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
   Private _decimalesEnUMCompra As Integer = 3
   Private _decimalesEnTotales As Integer = 2
   Private formatoEnTotales As String = "N" + _decimalesEnTotales.ToString()
   Private strCeroEnTotales As String = (0).ToString(formatoEnTotales)


   'Private _decimalesEnTotales As Integer = 2
   'Private _valorRedondeo As Integer = 2     '4 Se ajusto hasta que grabemos directamente los campos con IVA
   'Private _decimalesAMostrar As Integer = 2
   'Private _decimalesEnKilos As Integer = 3
   Private _fc As FacturacionComunes
   Private _DescRecGralPorc As Decimal = 0
   Private _modificoDescuentos As Boolean
   Private _titProductos As Dictionary(Of String, String) = New Dictionary(Of String, String)()

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

   Private _pedidoAEditar As Eniac.Entidades.PedidoProveedor
   Public Property PedidoAEditar() As Eniac.Entidades.PedidoProveedor
      Get
         Return Me._pedidoAEditar
      End Get
      Private Set(value As Eniac.Entidades.PedidoProveedor)
         Me._pedidoAEditar = value
      End Set
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try
         'Lo comentamos para cuando se active la funcionalidad de ProveedorContacto
         'tbcDetalle.SelectedTab = tbpContactos
         '_titContactos = GetColumnasVisiblesGrilla(ugContactos)
         tbcDetalle.TabPages.Remove(tbpContactos)

         tbcDetalle.SelectedTab = tbpProductos

         Me._decimalesRedondeoEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         Me._decimalesAMostrarEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
         _formatoPrecios = "N" + _decimalesAMostrarEnPrecio.ToString()
         Me._decimalesAMostrarEnTotalXProducto = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto
         _decimalesEnDescRec = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec

         _decimalesRedondeoEnTamanio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnTamano
         _decimalesMostrarEnTamanio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnTamano
         _formatoTamanio = "N" + _decimalesMostrarEnTamanio.ToString()

         Me.txtPrecio.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Me.txtDescRec.Formato = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Me.txtTotalProducto.Formato = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()
         Me.dgvProductos.Columns("Costo").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Me.dgvProductos.Columns("DescuentoRecargo").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString() 'Oculto por el momento
         Me.dgvProductos.Columns("CostoNeto").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Me.dgvProductos.Columns("Importe").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnTotalXProducto.ToString()

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            Me._decimalesEnCantidad = 0
            Me.txtCantidad.Formato = "N0"
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
            Me.dgvProductos.Columns("Cantidad").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()
         Else
            _decimalesEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad
            _decimalesMostrarEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad
            _formatoCantidades = "N" + _decimalesMostrarEnCantidad.ToString()
            Me.txtCantidad.Formato = "N" + _decimalesMostrarEnCantidad.ToString()
            Me.dgvProductos.Columns("Cantidad").DefaultCellStyle.Format = "N" + _decimalesMostrarEnCantidad.ToString()
         End If

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

         'GAR: 12/12/2017 - No se encuentra dicho permiso en Proveedores.
         'Seguridad del Descuento/Recargo General
         'Me.txtDescRecGralPorc.ReadOnly = Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes", "Clientes-DescRecGeneralPorc")
         Me.txtDescRecGralPorc.ReadOnly = Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "PedidosAdminProv-Modif")
         '-------------------------------------------------------------------

         txtDescRecGralPorc.Formato = "N" + _decimalesEnDescRec.ToString()
         txtDescRecPorc1.Formato = "N" + _decimalesEnDescRec.ToString()
         Me.dgvProductos.Columns("DescuentoRecargoPorc").DefaultCellStyle.Format = "N" + Me._decimalesEnDescRec.ToString()
         Me.dgvProductos.Columns("DescuentoRecargoPorc2").DefaultCellStyle.Format = "N" + Me._decimalesEnDescRec.ToString()

         Me.dgvProductos.Columns("Utilidad").DefaultCellStyle.Format = "N" + Me._decimalesAMostrarEnPrecio.ToString()

         'GAR: 12/12/2017 - No se encuentra dicho permiso en Proveedores.
         'Seguridad del Precio y Descuento/Recargo por Producto
         Me.chbModificaPrecio.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "PedidosAdminProv-Modif")
         Me.chbModificaDescRecargo.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "PedidosAdminProv-Modif")


         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         Me.llbProveedor.Visible = True 'oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes", "Clientes-PuedeUsarMasInfo")
         '---------------------------------------

         Me._publicos = New Publicos()
         Me._fc = New FacturacionComunes()

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         If PedidoAEditar IsNot Nothing Then
            Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, _tipoTipoComprobante, , , , )
         Else
            Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, _tipoTipoComprobante, , , , True)
         End If
         If Me.cmbTiposComprobantes.Items.Count = 0 Then
            Me._ConfiguracionImpresoras = True
         End If

         '   Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantesFact, False, "VENTAS")

         Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
         Me._publicos.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR)

         If PedidoAEditar IsNot Nothing Then
            If PedidoAEditar.PedidosProductos.Count = 0 Then
               Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisita, True, Nothing)
            Else
               Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisita, Nothing, True)
            End If
         Else
            Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisita, Nothing, True)
         End If

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

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me._publicos.CargaComboImpuestos(Me.cmbPorcentajeIva)

         Me._publicos.CargaComboTransportistas(Me.cmbRespDistribucion)

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True
         '  Me._publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, blnMiraUsuario, blnMiraPC)

         Me.SeteaDetalles()

         Me._estaCargando = False

         Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            Me.txtCantidad.Formato = "##,##0"
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         End If

         If Reglas.Publicos.VisualizaNrosSerie Then
            dgvProductos.Columns("NrosSerie").Visible = True
         End If

         Me.dgvProductos.Columns("FechaEntrega").DefaultCellStyle.Format() = "dd/MM/yyyy"

         '' ''txtTamanio.Visible = Publicos.DetallePedido.PedidosMostrarTamano
         '' ''txtUM.Visible = Publicos.DetallePedido.PedidosMostrarUM
         '' ''pnlTamanio.Visible = txtTamanio.Visible Or txtUM.Visible
         '' ''pnlPrecioLista.Visible = Publicos.DetallePedido.PedidosMostrarCosto
         '' ''pnlPrecioVentaPorTamano.Visible = Publicos.DetallePedido.PedidosMostrarPrecioVentaPorTamano
         '' ''lblPrecioVentaPorTamano2.Text = String.Empty
         '' ''pnlMoneda.Visible = Publicos.DetallePedido.PedidosMostrarMoneda
         '' ''pnlSemaforoRentabilidadDetalle.Visible = Publicos.DetallePedido.PedidosMostrarSemaforoRentabilidadDetalle
         '' ''pnlRentabilidadDetalle.Visible = pnlSemaforoRentabilidadDetalle.Visible

         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.Tamano.ToString()).Visible = txtTamanio.Visible
         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).Visible = txtUM.Visible
         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.Costo.ToString()).Visible = pnlPrecioLista.Visible
         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString()).Visible = pnlPrecioVentaPorTamano.Visible
         '' ''dgvProductos.Columns(Entidades.Moneda.Columnas.NombreMoneda.ToString()).Visible = pnlMoneda.Visible
         '' ''dgvProductos.Columns("ContribucionMarginalPorc").Visible = pnlSemaforoRentabilidadDetalle.Visible
         '' ''dgvProductos.Columns("Utilidad").Visible = pnlRentabilidadDetalle.Visible

         '' ''pnlProductoEspmm.Visible = Publicos.DetallePedido.PedidosMostrarProductoEspmm
         '' ''pnlProductoEspPulgadas.Visible = Publicos.DetallePedido.PedidosMostrarProductoEspPulgadas
         '' ''pnlProductoSAE.Visible = Publicos.DetallePedido.PedidosMostrarProductoSAE
         '' ''pnlProductoProduccionProceso.Visible = Publicos.DetallePedido.PedidosMostrarProductoProduccionProceso
         '' ''pnlProductoProduccionForma.Visible = Publicos.DetallePedido.PedidosMostrarProductoProduccionForma
         '' ''pnlProductoLargoExtAlto.Visible = Publicos.DetallePedido.PedidosMostrarProductoLargoExtAlto
         '' ''pnlProductoAnchoIntBase.Visible = Publicos.DetallePedido.PedidosMostrarProductoAnchoIntBase
         '' ''pnlProductoUrlPlano.Visible = Publicos.DetallePedido.PedidosMostrarUrlPlanoDetalle

         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.Espmm.ToString()).Visible = pnlProductoEspmm.Visible
         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.EspPulgadas.ToString()).Visible = pnlProductoEspPulgadas.Visible
         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.CodigoSAE.ToString()).Visible = pnlProductoSAE.Visible
         '' ''dgvProductos.Columns(Entidades.ProduccionProceso.Columnas.NombreProduccionProceso.ToString()).Visible = pnlProductoProduccionProceso.Visible
         '' ''dgvProductos.Columns(Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString()).Visible = pnlProductoProduccionForma.Visible
         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.LargoExtAlto.ToString()).Visible = pnlProductoLargoExtAlto.Visible
         '' ''dgvProductos.Columns(Entidades.PedidoProducto.Columnas.AnchoIntBase.ToString()).Visible = pnlProductoAnchoIntBase.Visible
         '' ''dgvProductos.Columns("UrlPlanoCount").Visible = pnlProductoUrlPlano.Visible

         '' ''pnlFormula.Visible = Publicos.DetallePedido.PedidosMostrarFormula
         '' ''dgvProductos.Columns("NombreFormula").Visible = pnlFormula.Visible

         '' ''If pnlProductoProduccionProceso.Visible Then
         '' ''   _publicos.CargaComboProduccionProcesos(cmbProductoProduccionProceso)
         '' ''End If
         '' ''If pnlProductoProduccionForma.Visible Then
         '' ''   _publicos.CargaComboProduccionFormas(cmbProductoProduccionForma)
         '' ''End If

         _titProductos = GetColumnasVisiblesGrilla(dgvProductos)

         If Not _ConfiguracionImpresoras Then
            Me.Nuevo()
         End If

         If PedidoAEditar IsNot Nothing Then
            MostrarPedidoEditable()
         End If

         cmbRespDistribucion.Visible = Reglas.Publicos.PedidosSolicitaTransportista
         cmbRespDistribucion.LabelAsoc.Visible = cmbRespDistribucion.Visible

         '  cmbTiposComprobantesFact.Visible = Reglas.Publicos.PedidosSolicitaComprobanteGenerar
         'cmbTiposComprobantesFact.LabelAsoc.Visible = cmbTiposComprobantesFact.Visible

         OrdenarGrillaProductos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
#End Region

#Region "Eventos"
#Region "Eventos KeyDown"
   Private Sub presionarTab_KeyDown(sender As Object, e As KeyEventArgs) Handles _
                                       txtCotizacionDolar.KeyDown, cmbCategoriaFiscal.KeyDown, cmbEstadoVisita.KeyDown, cmbComprador.KeyDown, txtObservacion.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub navegacionConEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles _
                                       txtProductoObservacion.KeyDown, txtCantidad.KeyDown, cmbPorcentajeIva.KeyDown, txtPrecio.KeyDown, txtDescRecPorc1.KeyDown,
                                       cmbCriticidad.KeyDown, dtpFechaEntregaProd.KeyDown, txtPrecioDolares.KeyDown,
                                       txtCantidadUMC.KeyDown, txtPrecioPorUMCompra.KeyDown, txtUnidadesCompras.KeyDown,
                                       txtDescRecGralPorc.KeyDown,
                                       txtPercepcionIVA.KeyDown, txtPercepcionIIBB.KeyDown, txtPercepcionGanancias.KeyDown, txtPercepcionVarias.KeyDown
      TryCatched(Sub() If TypeOf (sender) Is Control Then NavegacionConEnter(e, DirectCast(sender, Control)))
   End Sub
   Private Sub txtProductoObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoObservacion.KeyDown
      TryCatched(Sub() If TypeOf (sender) Is Control Then NavegacionConEnter(e, DirectCast(sender, Control),
                                                                             Function(ctrl) New DatosNavegacion() With {.Producto = New Reglas.Productos().GetUno(bscCodigoProducto2.Text)}))
   End Sub
#End Region
   'Private Sub dtpFechaEntregaProd_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaEntregaProd.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      Me.btnInsertar.Focus()
   '   End If
   'End Sub

   'Private Sub cmbCriticidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbCriticidad.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      If Me.dtpFechaEntregaProd.Visible Then
   '         Me.dtpFechaEntregaProd.Focus()
   '      Else
   '         Me.btnInsertar.Focus()
   '      End If
   '   End If
   'End Sub

   Private Sub Facturacion_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

      Select Case e.KeyCode
         Case Keys.F5
            If Me.tsbNuevo.Enabled And Me.tsbNuevo.Visible Then
               Me.tsbNuevo.PerformClick()
            End If
         Case Keys.F4
            If Me.tsbGrabar.Enabled Then
               Me.tsbGrabar.PerformClick()
            End If
         Case Keys.F7
            Try
               Me.BuscarProductoConConsultaPrecios()
            Catch ex As Exception
               MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
         Case Keys.F9
            Me.tbcDetalle.SelectedTab = Me.tbpProductos
            Me.bscCodigoProducto2.Focus()
         Case Keys.F12
            Me.tbcDetalle.SelectedTab = Me.tbpTotales
            Me.txtDescRecGralPorc.Focus()
         Case Keys.Add
            If e.Control Then
               Me.btnInsertar.PerformClick()
            End If
         Case Keys.Subtract, Keys.OemMinus
            If e.Control Then
               If Me.dgvProductos.SelectedRows.Count > 0 Then
                  Me.btnEliminar.PerformClick()
                  If Me.dgvProductos.Rows.Count > 0 Then
                     Me.dgvProductos.Focus()
                  Else
                     Me.bscCodigoProducto2.Focus()
                  End If
               End If
            End If
         Case Keys.Escape
            Me.btnLimpiarProducto.PerformClick()
            'Case Keys.D
            '   If e.Control Then
            '      Me.cmbVendedor.Focus()
            '   End If
            'Case Keys.F
            '   If e.Control Then
            '      Me.dtpFecha.Focus()
            '   End If
         Case Keys.G
            If e.Control Then
               If Me.dgvProductos.RowCount > 0 Then
                  Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
                  Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
                  Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Selected = True
               End If
               Me.dgvProductos.Focus()
            End If
         Case Else

      End Select

   End Sub


   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      Try
         If ShowPregunta(Traducciones.TraducirTexto("ATENCION: ¿Desea Realizar un Pedido Nuevo?", Me, "__ConfirmarNuevoComprobante")) = Windows.Forms.DialogResult.Yes Then
            Me.Nuevo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         If Me.bscCodigoProveedor.Enabled And Me._eProveedor Is Nothing Then
            MessageBox.Show("ATENCION: Debe cargar el Proveedor antes de cargar el producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.bscCodigoProducto2.Text = ""
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Dim oProdProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores()

         Dim listaPreciosPredeterminada As Integer = Publicos.ListaPreciosPredeterminada
         If Me.chbProductosDelProveedor.Checked Then

            Me._publicos.PreparaGrillaProductosProveedor2(Me.bscCodigoProducto2)
            Me.bscCodigoProducto2.Datos = oProdProv.GetPorCodigoProdProv(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, listaPreciosPredeterminada, "COMPRAS", _eProveedor.IdProveedor, soloCompuestos:=False, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
         Else
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
            Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, listaPreciosPredeterminada, "COMPRAS", soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         If Me.bscCodigoProveedor.Enabled And Me._eProveedor Is Nothing Then
            MessageBox.Show("ATENCION: Debe cargar el Proveedor antes de cargar el producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.bscProducto2.Text = ""
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtDescuento_LostFocus(sender As Object, e As EventArgs) Handles txtDescRec.LostFocus
      Try
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'Private Sub txtDescRecPorc1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescRecPorc1.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      cmbCriticidad.Focus()
   '   End If
   'End Sub

   Private Sub txtDescRecPorc1_LostFocus(sender As Object, e As EventArgs) Handles txtDescRecPorc1.LostFocus
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

   'Private Sub txtKilosModDesc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
   '   If e.KeyCode = Keys.Enter Then
   '      Me.cmbCriticidad.Focus()
   '   End If
   'End Sub


   Private Sub txtDescRecGralPorc_GotFocus(sender As Object, e As EventArgs) Handles txtDescRecGralPorc.GotFocus
      Me.txtDescRecGralPorc.SelectAll()
   End Sub

   'Private Sub txtDescRecGralPorc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescRecGralPorc.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      Me.txtTotalGeneral.Focus()
   '   End If
   'End Sub

   Private Sub txtDescRecGralPorc_Leave(sender As Object, e As EventArgs) Handles txtDescRecGralPorc.Leave
      Try
         Me.CalcularDatosDetalle()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtTotalDescRec_LostFocus(sender As Object, e As EventArgs) Handles txtDescRecGral.LostFocus
      Me.CalcularTotales()
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
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

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
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
         Try
            Me.Nuevo()
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedor As Reglas.Proveedores = New Reglas.Proveedores
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedor.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
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
         Try
            Me.Nuevo()
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Try
   End Sub


   Private Sub llbProveedor_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbProveedor.LinkClicked

      Try

         Dim PantProveedor As ProveedoresDetalle

         If Me.bscCodigoProveedor.Selecciono Or Me.bscProveedor.Selecciono Then
            Dim Prov As Eniac.Entidades.Proveedor = New Eniac.Entidades.Proveedor
            Dim blnIncluirFoto As Boolean = True
            Prov = New Eniac.Reglas.Proveedores().GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), blnIncluirFoto)
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
            'Me.bscCodigoCliente.Tag = PantCliente.txtCodigoCliente.Tag
            Me.bscCodigoProveedor.Text = PantProveedor.txtCodigoProveedor.Text
            Me.bscCodigoProveedor.PresionarBoton()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If (Not bscProducto2.FilaDevuelta Is Nothing Or Not bscCodigoProducto2.FilaDevuelta Is Nothing) And txtCantidad.Text <> "" Then
            btnInsertar.Focus()
            If ValidarInsertaProducto() Then
               InsertarProducto()
               bscCodigoProducto2.Focus()
               If _ModificaDetalle <> "TODO" Then
                  CambiarEstadoControlesDetalle(False)
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvProductos.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaProducto()
               Me.bscCodigoProducto2.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub chbModificaPrecioyBonificaciones_CheckedChanged(sender As Object, e As EventArgs) Handles chbModificaPrecio.CheckedChanged

      SoloLecturaPrecios(Not Me.chbModificaPrecio.Checked)

      If Me.chbModificaPrecio.Checked Then
         FocusPrecio()
      Else
         Me.txtCantidad.Focus()
         Me.txtCantidad.SelectAll()
      End If

   End Sub

   'Private Sub txtPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      If Me.chbModificaDescRecargo.Checked Then
   '         Me.txtDescRecPorc1.Focus()
   '         Me.txtDescRecPorc1.SelectAll()
   '      Else
   '         Me.btnInsertar.Focus()
   '      End If
   '      'Me.txtDescRecPorc1.Focus()
   '   End If
   'End Sub

   Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
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

   Private Sub txtCantidad_LostFocus(sender As Object, e As EventArgs) Handles txtCantidad.LostFocus
      Try

         If Me.txtCantidad.Text.Trim().Length = 0 Then
            Me.txtCantidad.Text = "1." + New String("0"c, Me._decimalesEnCantidad)
         Else
            If Me.txtPrecio.Text = "-" Then
               Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
            End If
         End If

         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'Private Sub txtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      '' ''If txtProductoLargoExtAlto.Enabled AndAlso txtProductoLargoExtAlto.Visible Then
   '      '' ''   txtProductoLargoExtAlto.Focus()
   '      '' ''ElseIf txtProductoAnchoIntBase.Enabled AndAlso txtProductoAnchoIntBase.Visible Then
   '      '' ''   txtProductoAnchoIntBase.Focus()
   '      '' ''Else
   '      If Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
   '         FocusPrecio()
   '      ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
   '         Me.txtDescRecPorc1.Focus()
   '      Else
   '         Me.btnInsertar.Focus()
   '      End If
   '   End If
   'End Sub

   'Private Sub cmbPorcentajeIva_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbPorcentajeIva.KeyDown
   '   'If e.KeyCode = Keys.Enter Then
   '   'Me.PresionarTab(e)
   '   'End If
   '   If e.KeyCode = Keys.Enter Then
   '      If Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
   '         FocusPrecio()
   '      ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
   '         Me.txtDescRecPorc1.Focus()
   '      Else
   '         Me.btnInsertar.Focus()
   '      End If
   '   End If
   'End Sub

   Private Sub cmbPorcentajeIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPorcentajeIva.SelectedIndexChanged
      Try
         If Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing And Me.cmbPorcentajeIva.Tag IsNot Nothing Then
            If (Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
               Me._eProveedor.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Dim actualPrecio As Decimal = Decimal.Parse(Me.txtPrecio.Tag.ToString())
               'Dim impuestoInterno As Decimal = Decimal.Parse(Me.txtImpuestoInterno.Text)
               Dim importeImpuestoInternoProducto As Decimal = 0
               Dim porcImpuestoInterno As Decimal = 0

               With bscCodigoProducto2.FilaDevuelta
                  importeImpuestoInternoProducto = Decimal.Parse(.Cells("ImporteImpuestoInterno").Value.ToString())
                  porcImpuestoInterno = Decimal.Parse(.Cells("PorcImpuestoInterno").Value.ToString())
               End With

               actualPrecio = Decimal.Round((actualPrecio - importeImpuestoInternoProducto) / (1 +
                                                                                (Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()) / 100) +
                                                                                (porcImpuestoInterno / 100)), Me._decimalesRedondeoEnPrecio)
               actualPrecio = Decimal.Round((actualPrecio * (1 +
                                                             (Decimal.Parse(Me.cmbPorcentajeIva.Text) / 100) +
                                                             (porcImpuestoInterno / 100))) + importeImpuestoInternoProducto, Me._decimalesRedondeoEnPrecio)
               Me.txtPrecio.Text = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
               Me.txtPrecio.Tag = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      Me.LimpiarCamposProductos()
      Me.bscCodigoProducto2.Focus()
   End Sub

   Private Sub dgvProductos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
      Try
         If e.RowIndex <> -1 Then
            If _ModificaDetalle <> "NO" Then
               'limpia los textbox, y demas controles
               Me.LimpiarCamposProductos()
               'carga el producto seleccionado de la grilla en los textbox 

               '#Seteo el valor de la propiedad
               _editarProductoDesdeGrilla = True
               Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex), editarProductoDesdeGrilla:=_editarProductoDesdeGrilla)
               'elimina el producto de la grilla
               Me.EliminarLineaProducto()

               ' # Ordeno la grilla de productos
               Me.OrdenarGrillaProductos()

               If Me._ModificaDetalle = "SOLOPRECIOS" Then
                  Me.txtPrecio.Enabled = True
                  Me.txtDescRecPorc1.Enabled = True

                  'Si Cliente utiliza impuestos, y Empresa utiliza impuestos, y es un comprobante en negro
                  'If Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
                  '############## ver
                  Me.cmbPorcentajeIva.Enabled = True
                  'End If

                  Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
                  Me.btnInsertar.Enabled = True
                  FocusPrecio()
               Else
                  If pnlCantidadUMC.Enabled And pnlCantidadUMC.Visible Then
                     Navegar(txtCantidadUMC)
                  Else
                     txtCantidad.Focus()
                     txtCantidad.SelectAll()
                  End If
               End If
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub





   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
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

   'Private Sub txtCotizacionDolar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCotizacionDolar.KeyDown
   '   PresionarTab(e)
   'End Sub

   'Private Sub cmbCategoriaFiscal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbCategoriaFiscal.KeyDown, cmbEstadoVisita.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      If cmbTiposComprobantes.SelectedIndex < 0 Then
         Exit Sub
      End If

      Try
         'Si es X es remito y siempre debe tener esa letra
         If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "B" Or Me.txtLetra.Text = "C" Or Me.txtLetra.Text = "E") And Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
            Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
         End If

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

         If Me._eProveedor IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then

            Me._eProveedor.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString()))

            'Exento sin IVA (Cliente o Empresa). 
            If Not Me._eProveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
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

            Me.RecalcularTodo(recuperaCosto:=False)
            Me.LimpiarCamposProductos()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   'Private Sub cmbVendedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbComprador.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   Private Sub txtPercepcionIVA_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIVA.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'Private Sub txtPercepcionIVA_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionIVA.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      Me.txtPercepcionIIBB.Focus()
   '   End If
   'End Sub

   'Private Sub txtPercepcionIIBB_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionIIBB.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      Me.txtPercepcionGanancias.Focus()
   '   End If
   'End Sub

   Private Sub txtPercepcionIIBB_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIIBB.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionGanancias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'Private Sub txtPercepcionGanancias_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionGanancias.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      Me.txtPercepcionVarias.Focus()
   '   End If
   'End Sub

   Private Sub txtPercepcionVarias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionVarias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'Private Sub txtPercepcionVarias_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionVarias.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      Me.txtTotalPercepcion.Focus()
   '   End If
   'End Sub

   'Private Sub txtProductoObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoObservacion.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      Dim oProd As Reglas.Productos = New Reglas.Productos()
   '      Dim prod As Entidades.Producto = New Entidades.Producto()
   '      prod = oProd.GetUno(Me.bscCodigoProducto2.Text)

   '      If txtCantidad.Enabled And Not prod.EsObservacion Then
   '         Me.txtCantidad.Focus()
   '      Else
   '         Me.btnInsertar.Focus()
   '      End If
   '   End If
   'End Sub


   Private Sub dgvProductos_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvProductos.KeyUp
      If Me.dgvProductos.SelectedRows.Count > 0 Then
         'Control y la tecla "-" de un teclado o nobebook.
         If e.Control And (e.KeyCode = Keys.Subtract Or e.KeyCode = Keys.OemMinus) Then
            Me.btnEliminar.PerformClick()
            Me.dgvProductos.Focus()
         End If
      End If
   End Sub


   Private Sub txtPrecioDolares_Leave(sender As Object, e As EventArgs) Handles txtPrecioDolares.Leave
      Try
         txtPrecio.Text = Math.Round(Decimal.Parse(txtPrecioDolares.Text) * Decimal.Parse(txtCotizacionDolar.Text), _decimalesRedondeoEnPrecio).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
         FocusPrecio()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   'Private Sub txtPrecioDolares_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioDolares.KeyDown
   '   If e.KeyCode = Keys.Enter Then
   '      txtPrecio.Focus()
   '      FocusPrecio()
   '   End If
   'End Sub

   Private Sub txtCantidadUMC_Leave(sender As Object, e As EventArgs) Handles txtCantidadUMC.Leave
      TryCatched(Sub() txtUnidadesCompras.SetValor(RequerimientosComprasDetalle.CalculaCantidadDesdeCantidadUMC(txtCantidadUMC.ValorNumericoPorDefecto(0D), txtCantidadUMC.TagNumericoPorDefecto(0D))))
   End Sub
   Private Sub txtUnidadesCompras_Leave(sender As Object, e As EventArgs) Handles txtUnidadesCompras.Leave, txtPrecioPorUMCompra.Leave, txtCantidadUMC.Leave
      TryCatched(
      Sub()
         txtCantidad.SetValor(txtUnidadesCompras.ValorNumericoPorDefecto(0D))
         If txtUnidadesCompras.ValorNumericoPorDefecto(0D) <> 0 Then
            txtPrecio.SetValor(txtCantidadUMC.ValorNumericoPorDefecto(0D) * txtPrecioPorUMCompra.ValorNumericoPorDefecto(0D) / txtUnidadesCompras.ValorNumericoPorDefecto(0D))
         Else
            txtPrecio.SetValor(0)
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Public Sub ModificarPedido(pedido As Eniac.Entidades.PedidoProveedor, owner As System.Windows.Forms.IWin32Window)
      If pedido Is Nothing Then
         Throw New Exception(Traducciones.TraducirTexto("Debe pasar un pedido a modificar.", Me, "__PedidoNoSuministrado"))
      End If

      Dim regPedidos As Reglas.PedidosProveedores = New Reglas.PedidosProveedores()
      regPedidos.VerificaPedidoModificable(pedido)

      PedidoAEditar = pedido

      ShowDialog(owner)
   End Sub

   Private Sub CalcularDescuentosProductos()

      'Dim DescRec1 As Decimal
      'Dim DescRec2 As Decimal
      'Dim DescRecT As Decimal

      'Dim precio As Decimal = Decimal.Parse(Me.txtPrecio.Text) - Decimal.Parse(txtImpuestosInternos.Text)

      'DescRec1 = precio * Decimal.Parse(Me.txtDescRecPorc1.Text) / 100

      'DescRec2 = (precio + DescRec1) * Decimal.Parse(Me.txtDescRecPorc2.Text) / 100

      'DescRecT = Decimal.Round((DescRec1 + DescRec2) * Decimal.Parse(Me.txtCantidad.Text), Me._decimalesRedondeoEnPrecio)

      Me.txtDescRec.Text = CalculaDescuentosProductos(Decimal.Parse(Me.txtPrecio.Text),
                                                      Decimal.Parse(txtImpuestoInterno.Text),
                                                      Decimal.Parse(Me.txtDescRecPorc1.Text),
                                                      0,
                                                      Decimal.Parse(Me.txtCantidad.Text)).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      'Me.txtDescRec.Text = DescRecT.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))

   End Sub

   Private Function CalculaDescuentosProductos(precioProducto As Decimal, impInt As Decimal, descRecPorc1 As Decimal, descRecPorc2 As Decimal, cantidad As Decimal) As Decimal
      Dim DescRec1 As Decimal
      Dim DescRec2 As Decimal
      Dim DescRecT As Decimal

      Dim precio As Decimal = precioProducto - impInt

      DescRec1 = precio * descRecPorc1 / 100

      DescRec2 = (precio + DescRec1) * descRecPorc2 / 100

      DescRecT = Decimal.Round((DescRec1 + DescRec2) * cantidad, Me._decimalesRedondeoEnPrecio)

      Return DescRecT
   End Function


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


      If Me.bscCodigoProveedor.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Código del Proveedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCodigoProveedor.Focus()
         Return False
      End If

      If Me.bscProveedor.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del Proveedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscProveedor.Focus()
         Return False
      End If

      If Me._pedidosProductos.Count = 0 Then
         MessageBox.Show("No se cargó ningún producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.tbcDetalle.SelectedTab = Me.tbpProductos
         Me.bscCodigoProducto2.Focus()
         Return False
      End If

      If Me.txtOrdenDeCompra.Text <> "" Then
         Dim OC As DataTable = New Reglas.OrdenesCompra().Get1(actual.Sucursal.IdSucursal, Long.Parse(Me.txtOrdenDeCompra.Text.ToString()))
         If OC.Rows.Count = 0 Then
            If Reglas.Publicos.UtilizaOrdenCompraPedidos Then
               MessageBox.Show("No existe la Orden de Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Me.txtOrdenDeCompra.Focus()
               Return False
            End If
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

      For Each pro As Entidades.PedidoProductoProveedor In Me._pedidosProductos

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

         If DateDiff(DateInterval.Day, Me.dtpFecha.Value.Date, pro.FechaEntrega.Date) < 0 Then
            ShowMessage(String.Format(Traducciones.TraducirTexto("La Fecha de Entrega del producto (Código {0}) es menor a la Fecha del Pedido ({1:dd/MM/yyyy}).", Me, "__ErrorFechaEntregaInvalida"),
                                      pro.IdProducto, dtpFecha.Value))
            Me.dtpFecha.Focus()
            Return False
         End If

         producto = pro.IdProducto
         'Sumo cantidades en productos repetidos para controlar stock
         For Each pro1 As Entidades.PedidoProductoProveedor In Me._pedidosProductos

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

      If Me.cmbComprador.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el comprador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbComprador.Focus()
         Return False
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
      'If Reglas.Publicos.PedidosSolicitaComprobanteGenerar Then
      '   If cmbTiposComprobantesFact.SelectedIndex = -1 Then
      '      ShowMessage("Falta cargar el comprobante a generar.")
      '      cmbTiposComprobantesFact.Focus()
      '      cmbTiposComprobantesFact.DroppedDown = True
      '      Return False
      '   End If
      'End If
      'End If

      If Not Me.chbNumeroAutomatico.Checked And Long.Parse(Me.txtNumeroPosible.Text) <= 0 Then
         MessageBox.Show("El número de comprobante digitado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtNumeroPosible.Focus()
         Return False
      End If

      Dim ImporteTope As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteTope
      If ImporteTope > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) > ImporteTope Then
         MessageBox.Show("El Comprobante Superó el Límite Permitido de $ " & ImporteTope.ToString("N" + Me._decimalesEnTotales.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      Dim ImporteMinimo As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteMinimo
      If ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) < ImporteMinimo Then
         MessageBox.Show("El Comprobante No Alcanzó el Mínimo Requerido de $ " & ImporteMinimo.ToString("N" + Me._decimalesEnTotales.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      'A Raymundo cada tanto le pasa que no genera el descuento, no dan enter!
      If Decimal.Parse(Me.txtDescRecGralPorc.Text) <> 0 And Decimal.Parse(Me.txtDescRecGral.Text) = 0 Then
         MessageBox.Show("No se calculó el Descuento/Recargo General, por favor de enter para confirmarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtDescRecGralPorc.Focus()
         Return False
      End If

      Return True

   End Function

   'Private Function EsComprobanteFiscal() As Boolean
   '    Return DirectCast("PEDIDO", Entidades.TipoComprobante).EsFiscal
   'End Function

   Private Sub GrabarComprobante()

      If Me.ValidarComprobante() Then

         Me.tsbGrabar.Enabled = False


         Dim oPedido As Reglas.PedidosProveedores = New Reglas.PedidosProveedores()
         Dim oPedidos As New Entidades.PedidoProveedor

         With oPedidos
            'cargo el comprobante
            .TipoComprobante = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)

            'cargo el Proveedor ----------
            .Proveedor = Me._eProveedor
            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)

            .LetraComprobante = Me.txtLetra.Text

            If Not Me.chbNumeroAutomatico.Checked Or (.TipoComprobante.EsFiscal And Not .TipoComprobante.GrabaLibro) Or PedidoAEditar IsNot Nothing Then
               .NumeroPedido = Long.Parse(Me.txtNumeroPosible.Text)
            End If

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre

            'Pudo levantar la pantalla y grabar despues. Vuelvo a asignarlo para que tome la hora.
            If Me.dtpFecha.Value.Date = New Reglas.Generales().GetServerDBFechaHora.Date Then
               Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora
            End If
            .Fecha = Me.dtpFecha.Value

            .Comprador = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado)

            .Observacion = Me.txtObservacion.Text

            .EstadoVisita = DirectCast(Me.cmbEstadoVisita.SelectedItem, Entidades.EstadoVisita)

            '.VentasImpuestos = Me._subTotales
            '.ImpuestosVarios = Me._fc.ImpuestosVarios

            ''cargo valores del comprobante
            .ImporteBruto = Decimal.Parse(Me.txtTotalBruto.Text)
            .DescuentoRecargo = Decimal.Parse(Me.txtDescRecGral.Text)
            .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescRecGralPorc.Text)
            .SubTotal = Decimal.Parse(Me.txtTotalNeto.Text)
            .TotalImpuestos = Decimal.Parse(Me.txtTotalImpuestos.Text) '+ Decimal.Parse(Me.txtTotalPercepcion.Text)
            .TotalImpuestoInterno = Decimal.Parse(Me.txtTotalImpuestosInternos.Text)
            .ImporteTotal = Decimal.Parse(Me.txtTotalGeneral.Text)

            .CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text)

            'cargo la impresora
            '.Impresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal())
            .Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

            If Me.txtOrdenDeCompra.Text <> "" Then
               .NumeroOrdenCompra = Long.Parse(Me.txtOrdenDeCompra.Text.ToString())
            End If

            'cargo la orden de compra si tiene una
            If Me.NumeroOrdenCompra <> 0 Then
               .NumeroOrdenCompra = Me.NumeroOrdenCompra
            End If

            'cargo los productos
            .PedidosProductos = Me._pedidosProductos



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
            'If Reglas.Publicos.PedidosSolicitaComprobanteGenerar Then
            '   If cmbTiposComprobantesFact.SelectedIndex >= -1 Then
            '      .TipoComprobanteFact = DirectCast(cmbTiposComprobantesFact.SelectedItem, Entidades.TipoComprobante)
            '   End If
            'End If
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

            '.ComisionVendedor = 0  'Se calcula despues

            For Each pp As Entidades.PedidoProductoProveedor In .PedidosProductos
               '' '' '' ''   If Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
               '' '' '' ''      pp.Costo = Decimal.Round((pp.Costo - (pp.ImporteImpuestoInterno / pp.Cantidad)) / (1 + (pp.AlicuotaImpuesto / 100) + (pp.PorcImpuestoInterno / 100)), Me._decimalesRedondeoEnPrecio)
               '' '' '' ''   End If
               pp.Proveedor = .Proveedor
            Next

            'grabo la caja
            ' .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

            'Lo comentamos para cuando se active la funcionalidad de ProveedorContacto
            '.PedidosContactos.Clear()
            'For Each contacto As Entidades.ClienteContacto In _pedidosContactos
            '   .PedidosContactos.Add(New Entidades.PedidoClienteContacto(contacto))
            'Next
         End With


         If PedidoAEditar Is Nothing Then
            oPedido.Insertar(oPedidos)
         Else
            oPedidos.CentroEmisor = PedidoAEditar.CentroEmisor
            oPedido.Actualizar(oPedidos)
         End If


         'verifica si el tipo de comprobante se puede imprimir, sino no hace nada
         Try
            'Luego cambiar al otro parametro.
            If Publicos.PedidosVisualiza Then
               Me.ImprimirPedido(oPedidos, Publicos.PedidosVisualiza, True)
               MessageBox.Show("Grabación e Impresión Exitosa!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Me.ImprimeComprobante() Then
               Me.ImprimirPedido(oPedidos, False, True)
               MessageBox.Show("Grabación e Impresión Exitosa!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub ImprimirPedido(oPedido As Entidades.PedidoProveedor, Visualizar As Boolean, EnviarMail As Boolean)
      Dim impresion As ImpresionPedidosProv = New ImpresionPedidosProv()
      impresion.ImprimirPedido(oPedido, Visualizar, EnviarMail)
   End Sub


   Private Function ImprimeComprobante() As Boolean
      'Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime
      Return Me._imprime
   End Function

   Private Sub SeteaDetalles()
      Me._pedidosProductos = New List(Of Entidades.PedidoProductoProveedor)
      'Lo comentamos para cuando se active la funcionalidad de ProveedorContacto
      '_pedidosContactos = New List(Of Entidades.ClienteContacto)()
      Me._subTotales = New List(Of Entidades.VentaImpuesto)()
      Me._pedidosObservaciones = New List(Of Entidades.PedidoObservacionProveedor)()
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

   Private Sub LimpiarCamposProductos()
      _ordenProducto = 0

      Dim precioCero As String = (0).ToString("N" + Me._decimalesAMostrarEnPrecio.ToString())
      Dim cantidadCero As String = (0).ToString("N" + Me._decimalesEnCantidad.ToString())

      _editarProductoDesdeGrilla = False
      bscCodigoProducto2.Enabled = True
      bscCodigoProducto2.Text = ""
      bscCodigoProducto2.FilaDevuelta = Nothing
      bscProducto2.Enabled = True
      bscProducto2.Text = ""
      bscProducto2.FilaDevuelta = Nothing
      txtPrecio.Text = precioCero
      txtStock.Text = "0"
      txtStock.Tag = False
      txtCantidad.Text = cantidadCero
      txtDescRec.Text = precioCero
      txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto)
      txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      cmbCriticidad.SelectedIndex = 0
      dtpFechaEntregaProd.Value = Date.Today
      txtProductoObservacion.Text = String.Empty
      txtProductoObservacion.Visible = False
      dtpFechaActPrecios.Value = Date.Today
      grpPrecioDolares.Visible = False

      MuestraImpuestosInternos(0, 0)

      txtCantidadUMC.SetValor(0)
      txtCantidadUMC.Tag = 0D
      txtPrecioPorUMCompra.SetValor(0)
      txtUnidadesCompras.SetValor(0)

      pnlCantidadUMC.Visible = False
      pnlPrecioPorUMCompra.Visible = False
      pnlUnidadesCompras.Visible = False

      _modificoDescuentos = False

      SetearDescuentosPorCantidad(Nothing)
   End Sub

   Private Sub CalcularImpuestoInterno()
      If bscCodigoProducto2.FilaDevuelta IsNot Nothing Then
         Dim importeImpuestoInternoProducto As Decimal = 0
         Dim porcImpuestoInterno As Decimal = 0

         With bscCodigoProducto2.FilaDevuelta
            importeImpuestoInternoProducto = Decimal.Parse(.Cells("ImporteImpuestoInterno").Value.ToString())
            porcImpuestoInterno = Decimal.Parse(.Cells("PorcImpuestoInterno").Value.ToString())
         End With

         If porcImpuestoInterno = 0 Then
            MuestraImpuestosInternos(importeImpuestoInternoProducto, porcImpuestoInterno)
         Else
            If Not IsNumeric(txtPrecio.Text) Then txtPrecio.Text = (0).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
            Dim precioNeto As Decimal
            Dim descRecPorc1 As Decimal = Decimal.Parse(txtDescRecPorc1.Text)
            Dim descRecGralPorc As Decimal = Decimal.Parse(txtDescRecGralPorc.Text)

            Dim alicuotaIVA As Decimal = Decimal.Parse(cmbPorcentajeIva.Text)

            If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
               Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               precioNeto = Decimal.Parse(txtPrecio.Text)
            Else
               precioNeto = (Decimal.Parse(txtPrecio.Text) - importeImpuestoInternoProducto) / (1 + (alicuotaIVA / 100) + (porcImpuestoInterno / 100))
            End If

            precioNeto = precioNeto * (1 + (descRecPorc1 / 100))
            precioNeto = precioNeto * (1 + (descRecGralPorc / 100))

            Dim impuestoInterno As Decimal

            'If DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado Then
            If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
                Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               'El precio en pantalla está sin IVA
               impuestoInterno = importeImpuestoInternoProducto + (precioNeto * porcImpuestoInterno / 100)
            Else
               'El precio en pantalla está con IVA
               impuestoInterno = importeImpuestoInternoProducto + (precioNeto * porcImpuestoInterno / 100)
            End If

            MuestraImpuestosInternos(impuestoInterno, porcImpuestoInterno)
         End If

      End If

   End Sub

   Private Function MuestraImpuestosInternos(importe As Decimal, porcentaje As Decimal) As Decimal
      txtImpuestoInterno.Text = importe.ToString("N2")
      txtImpuestoInterno.Visible = importe <> 0
      txtImpuestoInterno.LabelAsoc.Visible = txtImpuestoInterno.Visible

      txtPorcImpuestoInterno.Text = porcentaje.ToString("N2")
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
      Dim CantProductos As Integer
      Dim percepcionIVA As Decimal = 0
      Dim percepcionIB As Decimal = 0
      Dim percepcionGanancias As Decimal = 0
      Dim percepcionVarias As Decimal = 0
      Dim percepcionTotal As Decimal = 0

      'If Me.dgvProductos.Rows.Count > 0 Then

      Dim totalKilosItems As Reglas.Ventas.TotalKilosItems = New Reglas.PedidosProveedores().CalculaTotalKilosItems(_pedidosProductos)
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

      ' Me.CalcularDiferenciaDePago()

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

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      Dim idProveedor As Long = Long.Parse(dr.Cells(Entidades.Proveedor.Columnas.IdProveedor.ToString()).Value.ToString())

      Me._eProveedor = New Reglas.Proveedores().GetUno(idProveedor)

      Me.bscProveedor.Text = _eProveedor.NombreProveedor
      Me.bscCodigoProveedor.Text = _eProveedor.CodigoProveedor.ToString().Trim()
      Me.bscCodigoProveedor.Tag = _eProveedor.IdProveedor.ToString()
      Me.txtDireccionYLocalidad.Text = _eProveedor.DireccionProveedor & " - " & _eProveedor.NombreLocalidad
      Me.txtTelefonos.Text = _eProveedor.TelefonoProveedor '& " " & dr.Cells("Celular").Value.ToString()
      'Me.txtLimiteDeCredito.Text = dr.Cells("LimiteDeCredito").Value.ToString()

      Me.cmbCategoriaFiscal.SelectedValue = _eProveedor.CategoriaFiscal.IdCategoriaFiscal.ToString()
      Me._IdCategoriaFiscalOriginal = _eProveedor.CategoriaFiscal.IdCategoriaFiscal

      'Si es X es remito y siempre debe tener esa letra
      'If Me.txtLetra.Text <> "X" And Me.txtLetra.Text <> "R" Then
      '    Me.txtLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
      'End If

      Me.txtCategoria.Text = _eProveedor.Categoria.NombreCategoria
      Me.tbcDetalle.Enabled = True

      'GAR: 12/12/2017 - Chequear la funcionalidad 
      'If Publicos.PermiteModificarClientePedido Then
      '   Me.bscProveedor.Permitido = True
      '   Me.bscCodigoProveedor.Permitido = True
      'Else
      Me.bscProveedor.Permitido = False
      Me.bscCodigoProveedor.Permitido = False
      'End If

      'If Me._eProveedor.IdTipoComprobante <> "" Then
      '   Me.cmbTiposComprobantesFact.SelectedValue = Me._eProveedor.IdTipoComprobante
      'End If
      'If Me.cmbTiposComprobantesFact.SelectedIndex = -1 And Me.cmbTiposComprobantesFact.Items.Count > 0 Then
      '   Me.cmbTiposComprobantesFact.SelectedIndex = 0
      'End If

      If Me._eProveedor.IdFormasPago <> 0 Then
         Me.cmbFormaPago.SelectedValue = Me._eProveedor.IdFormasPago
         If Me.cmbFormaPago.SelectedIndex = -1 And Me.cmbFormaPago.Items.Count > 0 Then
            Me.cmbFormaPago.SelectedIndex = 0
         End If
      End If


      Me.CambiarEstadoControlesDetalle(True)

      Me.txtDescRecGralPorc.Text = Me._eProveedor.DescuentoRecargoPorc.ToString("N" + _decimalesEnTotales.ToString())

      'Me.cmbCategoriaFiscal.Enabled = False
      Me.CargarProximoNumero()

      Me.CargarSaldosCtaCte()

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

      ''controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
      'If Publicos.FacturacionSolicitaComprobante Then
      '    Me.cmbTiposComprobantes.SelectedIndex = -1
      '    Me.cmbTiposComprobantes.Focus()
      'End If

      ''If Publicos.FacturacionSolicitaVendedor Then
      ''   Me.cmbComprador.SelectedIndex = -1
      ''   Me.cmbComprador.Focus()
      ''End If


      ''If Not Publicos.FacturacionSolicitaComprobante And Not Publicos.FacturacionSolicitaVendedor Then
      ''   Me.bscCodigoProducto2.Focus()
      ''End If

      'Lo dejamos para cuando se implemente ProveedoresContactos
      '_publicos.CargaComboClientesContactos(cmbContacto, Long.Parse(dr.Cells("IdCliente").Value.ToString()), True)

      If _drProductosDesdeStockColeccion IsNot Nothing AndAlso _drProductosDesdeStockColeccion.Length > 0 Then
         For Each drProductosDesdeStock As DataRow In _drProductosDesdeStockColeccion
            Dim bscCodigoProducto2_enabled As Boolean = bscCodigoProducto2.Enabled
            bscCodigoProducto2.Enabled = True
            bscCodigoProducto2.Text = drProductosDesdeStock("IdProducto").ToString()
            bscCodigoProducto2.PresionarBoton()
            bscCodigoProducto2.Enabled = bscCodigoProducto2_enabled
            txtCantidad.Text = drProductosDesdeStock("Pedido").ToString()
            If drProductosDesdeStock.Table.Columns.Contains("RespetaPreciosOrdenCompra") AndAlso
               drProductosDesdeStock.Table.Columns.Contains("PrecioCosto") AndAlso
               Boolean.Parse(drProductosDesdeStock.Table.Columns.Contains("RespetaPreciosOrdenCompra").ToString()) AndAlso
               IsNumeric(drProductosDesdeStock.Table.Columns.Contains("PrecioCosto")) Then
               txtPrecio.Text = drProductosDesdeStock("PrecioCosto").ToString()
            End If
            If Publicos.GenerarPedidosProveedorDesdeStockModificaPrecioCosto Then

               Dim oProducto As Entidades.Producto = New Entidades.Producto()
               oProducto = New Reglas.Productos().GetUno(drProductosDesdeStock("IdProducto").ToString())

               If Reglas.Publicos.PreciosConIVA Then

                  If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
                   Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
                     txtPrecio.Text = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(Decimal.Parse(drProductosDesdeStock("PrecioCosto").ToString()), oProducto).ToString()
                  Else
                     txtPrecio.Text = drProductosDesdeStock("PrecioCosto").ToString()

                  End If

               Else
                  If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
                   Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
                     txtPrecio.Text = drProductosDesdeStock("PrecioCosto").ToString()
                  Else
                     txtPrecio.Text = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(Decimal.Parse(drProductosDesdeStock("PrecioCosto").ToString()), oProducto).ToString()

                  End If
               End If

            End If
            btnInsertar.PerformClick()
         Next
         ToolTip1.SetToolTip(bscCodigoProveedor, String.Empty)
      End If

   End Sub

   Private Sub CargarSaldosCtaCte()
      Dim oCtaCteProv As Reglas.CuentasCorrientesProvPagos = New Reglas.CuentasCorrientesProvPagos
      Dim idRubroCompra = 0

      Dim dt As DataTable = oCtaCteProv.GetSaldosCtaCte(-1, Nothing, _eProveedor.IdProveedor, "", 0, "TODOS", idRubroCompra)

      Me.txtSaldoCtaCte.Text = strCeroEnTotales
      Me.txtSaldoCtaCteVencido.Text = strCeroEnTotales

      If dt.Rows.Count = 1 Then
         Me.txtSaldoCtaCte.Text = Decimal.Parse(dt.Rows(0)("Saldo").ToString()).ToString(formatoEnTotales)
         If Not String.IsNullOrEmpty(dt.Rows(0)("SaldoVencido").ToString()) Then
            Me.txtSaldoCtaCteVencido.Text = Decimal.Parse(dt.Rows(0)("SaldoVencido").ToString()).ToString(formatoEnTotales)
         End If
      End If

      'Para cuando se habilite Limite de Credito en Proveedores
      'If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
      '   If Decimal.Parse(Me.txtSaldoCtaCte.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
      '      If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
      '         Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
      '      End If
      '   End If
      'End If

   End Sub



   Private Sub Nuevo()

      Me.tsbGrabar.Enabled = False
      Me._estado = Estados.Insercion
      'Me.Text = "Facturación"


      Me.cmbComprador.Enabled = True

      Me.txtTotalGeneral.Enabled = True
      Me.txtDescRecGral.Enabled = True
      Me.tbcDetalle.SelectedTab = Me.tbpProductos
      Me.tbcDetalle.Enabled = True
      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscProveedor.Text = String.Empty
      'Me.txtBruto.Enabled = True
      Me.bscProveedor.Permitido = True
      Me.bscCodigoProveedor.Permitido = True
      Me._eProveedor = Nothing

      'Me.dtpFecha.Enabled = True
      Me.txtObservacion.Text = String.Empty
      Me._pedidosProductos.Clear()

      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      '----------------------------------------------------------------------------------------------

      'Lo comentamos para cuando se active la funcionalidad de ProveedorContacto
      '_pedidosContactos.Clear()
      'ugContactos.DataSource = _pedidosContactos
      'AjustarColumnasGrilla(ugContactos, _titContactos)

      _productosLotes.Clear()
      _subTotales.Clear()
      dgvIvas.DataSource = Me._subTotales.ToArray()

      txtTelefonos.Text = String.Empty
      txtLimiteDeCredito.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtSaldoCtaCteVencido.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      'Me.txtBruto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtDireccionYLocalidad.Text = String.Empty
      dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
      txtTotalGeneral.Text = "0." + New String("0"c, Me._decimalesEnTotales)
      txtCantidadProductos.Text = "0"
      '----
      bscCodigoProducto2.Text = String.Empty
      bscProducto2.Text = String.Empty
      txtProductoObservacion.Visible = False
      txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
      txtStock.Text = String.Empty
      txtStock.Tag = False
      txtCantidad.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrarEnPrecio)
      txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto)
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


      If cmbComprador.Items.Count > 0 Then
         cmbComprador.SelectedIndex = 0
      Else
         cmbComprador.SelectedIndex = -1
      End If

      txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesEnDescRec)
      txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesEnTotales)

      'Me.txtCategoriaFiscal.Text = String.Empty
      'Me.txtCategoria.Text = String.Empty

      cmbCategoriaFiscal.Enabled = True
      cmbCategoriaFiscal.SelectedIndex = -1

      CambiarEstadoControlesDetalle(False)

      _ModificaDetalle = "TODO"

      txtCotizacionDolar.Enabled = Reglas.Publicos.PedidosPermiteModificarCambio

      If Me._comprobantesSeleccionados IsNot Nothing Then
         Me._comprobantesSeleccionados.Clear()
      End If

      _transportistaA = Nothing

      _pedidosObservaciones.Clear()

      dgvObservaciones.DataSource = Me._pedidosObservaciones.ToArray()

      _numeroOrden = 0
      _DescRecGralPorc = 0

      CargarProximoNumero()

      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

      chbModificaPrecio.Checked = Reglas.Publicos.Facturacion.FacturacionModificaPrecioProducto
      chbModificaDescRecargo.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescRecProducto

      ' Me.cmbCajas.SelectedIndex = 0

      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Focus()

      cmbTiposComprobantes.SelectedIndex = 0
      '  cmbTiposComprobantesFact.SelectedIndex = -1

      dtpFechaEntrega.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now

      txtOrdenDeCompra.Text = ""

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
      End If

      If Decimal.Parse(Me.txtPrecio.Text) <= 0 And Not _permitePrecioCero.IfNull(Reglas.Publicos.PedidosProvConProductosEnCero) And _drProductosDesdeStockColeccion Is Nothing Then
         MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         FocusPrecio()
         Return False
      End If

      If Me.txtCantidad.Text = "" Then
         MessageBox.Show("No puede ingresar sin cantidad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidad.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtCantidad.Text) = 0 Then
         MessageBox.Show("La cantidad debe ser distinta de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidad.Focus()
         Return False
      End If

      'En txtStock.Tag guardo propiedad "AfectaStock"
      If Decimal.Parse(Me.txtCantidad.Text) <= 0 And Boolean.Parse(Me.txtStock.Tag.ToString()) Then
         MessageBox.Show("La cantidad debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidad.Focus()
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



      'If Me.dgvProductos.RowCount = Me._cantMaxItems Then
      '    MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas de Productos para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '    Me.btnInsertar.Focus()
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
      '      Me.txtCantidad.Focus()
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

      '''''Esta Habilitado si permite Modificar la Descripcion.
      ''''If Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible Then
      ''''   If Reglas.Publicos.Facturacion.FacturacionModificaDescripSolicitaKilos Then
      ''''      If Not IsNumeric(txtKilosModDesc.Text) Then txtKilosModDesc.Text = "0.00"
      ''''      If Decimal.Parse(Me.txtKilosModDesc.Text) = 0 Then
      ''''         MessageBox.Show("Debe Ingresar Kilos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      ''''         Me.txtKilosModDesc.Focus()
      ''''         Return False
      ''''      End If
      ''''   End If
      ''''End If

      Return True

   End Function

   Private Sub CargarProducto(dr As DataGridViewRow)

      If Integer.Parse(dr.Cells("Atributos").Value.ToString()) = 0 Then

         Dim oCF As Entidades.CategoriaFiscal = Nothing
         Dim PO As Decimal = 0
         Me._CodigoProductoProveedor1 = String.Empty

         If Me._eProveedor Is Nothing Then
            oCF = Me._categoriaFiscalEmpresa
         Else
            oCF = Me._eProveedor.CategoriaFiscal
         End If

         Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

         Me.bscCodigoProducto2.Enabled = False
         Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         Me.bscProducto2.Enabled = Reglas.Publicos.ComprasModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

         txtProductoObservacion.Text = Me.bscProducto2.Text
         If Reglas.Publicos.ComprasModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()) Then
            txtProductoObservacion.Visible = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
            txtProductoObservacion.BringToFront()
         End If

         '-- REQ-43206.- ---------------------------------------------------------
         txtUnidadMedidaStock.Text = producto.UnidadDeMedida.IdUnidadDeMedida
         '------------------------------------------------------------------------

         Dim PrecioVentaSinIVA As Decimal = 0
         Dim PrecioVentaConIVA As Decimal = 0

         Dim alicuota As Decimal = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())

         PrecioVentaSinIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
         PrecioVentaConIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())

         'Si se guardan con IVA se lo quito, evito muchas preguntas posteriores.
         If Reglas.Publicos.PreciosConIVA Then
            'Me._PO = PrecioVentaSinIVA
            PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA / (1 + alicuota / 100), Me._decimalesRedondeoEnPrecio)
         Else
            'Me._PO = PrecioVentaConIVA
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

         If (Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
              Me._eProveedor.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then

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
         'If Not Me._eProveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
         '   Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
         '   Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then

         '   Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnItems))
         'Else
         '   Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnItems))
         'End If


         'Me._precioVenta = Decimal.Parse(dr.Cells("PrecioVenta").Value.ToString())


         txtStock.Text = dr.Cells("Stock").Value.ToString()
         txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())
         txtCantidad.Text = (1D).ToString("N" + _decimalesMostrarEnCantidad.ToString())

         dtpFechaActPrecios.Value = Date.Parse(dr.Cells("FechaActualizacion").Value.ToString())

         If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
            pnlCantidadUMC.Visible = True
            pnlPrecioPorUMCompra.Visible = True
            pnlUnidadesCompras.Visible = True
         End If
         txtCantidadUMC.Tag = producto.FactorConversionCompra
         txtCantidadUMC.SetValor(RequerimientosComprasDetalle.CalculaCantidadUMCDesdeCantidad(txtCantidad.ValorNumericoPorDefecto(0D), producto.FactorConversionCompra))
         txtPrecioPorUMCompra.SetValor(txtPrecio.ValorNumericoPorDefecto(0D) / producto.FactorConversionCompra)
         txtUnidadesCompras.SetValor(txtCantidad.ValorNumericoPorDefecto(0D))
         lblCantidadUMC.Text = producto.UnidadDeMedidaCompra.NombreUnidadDeMedida

         ''Me._publicos.CargaComboConceptos(Me.cmbConceptos, Me.bscCodigoProducto2.Text)

         ''If Me.cmbConceptos.Items.Count > 0 Then
         ''   Me.cmbConceptos.Enabled = True
         ''   If Me.cmbConceptos.Items.Count > 1 Then
         ''      Me.cmbConceptos.SelectedIndex = -1 'Obligo a cargarlo
         ''   Else
         ''      Me.cmbConceptos.SelectedIndex = 0
         ''   End If
         ''End If


         'Monotributista / Consumidor Final (no usan el iva)
         'If Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
         '   Me.cmbPorcentajeIVA.Text = alicuota.ToString()
         'Else
         '   Me.cmbPorcentajeIVA.Text = "0"
         'End If


         'Exento sin IVA / Monotributo (por ahora lo dejo exento, mas sencillo para el IVA, pero deberia hacer lo mismo que facturacion.
         If Not Me._eProveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
         Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or
         Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            Me.cmbPorcentajeIva.Text = "0.00"
            Me.cmbPorcentajeIva.Enabled = False
         Else
            Me.cmbPorcentajeIva.Enabled = True
            Me.cmbPorcentajeIva.Text = alicuota.ToString()
         End If
         If Reglas.Publicos.UtilizaPrecioDeCompra Then
            If producto.ProductoProveedorHabitual IsNot Nothing Then
               'ver si es asi
               If Me._eProveedor.IdProveedor = producto.ProductoProveedorHabitual.IdProveedor Then
                  Me.txtPrecioLista.Text = producto.ProductoProveedorHabitual.UltimoPrecioFabrica.ToString()
                  Me.txtDescuento1.Text = producto.ProductoProveedorHabitual.DescuentoRecargoPorc1.ToString()
                  Me.txtDescuento2.Text = producto.ProductoProveedorHabitual.DescuentoRecargoPorc2.ToString()
                  Me.txtDescuento3.Text = producto.ProductoProveedorHabitual.DescuentoRecargoPorc3.ToString()
                  Me.txtDescuento4.Text = producto.ProductoProveedorHabitual.DescuentoRecargoPorc4.ToString()
                  Me._CodigoProductoProveedor1 = producto.ProductoProveedorHabitual.CodigoProductoProveedor
               End If
            End If
         End If
         ''Si esta habitada, seguramente la cambiaria
         If Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible Then
            If Reglas.Publicos.Facturacion.FacturacionModificaDescriProdCantidad Then
               If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
                  Navegar(txtCantidadUMC)
               Else
                  txtCantidad.Focus()
                  txtCantidad.SelectAll()
               End If
            Else
               txtProductoObservacion.Focus()
               'Me.bscProducto2.Focus()
               'Me.bscProducto2.SelectAll()
            End If
         Else
            If Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()) Then
               txtProductoObservacion.Focus()
            Else
               If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
                  Navegar(txtCantidadUMC)
               Else
                  txtCantidad.Focus()
                  txtCantidad.SelectAll()
               End If
            End If
         End If
      Else
         MessageBox.Show(String.Format("No es posible cargar el producto ({0}), el mismo utiliza SubRubro con Atributo", dr.Cells("NombreProducto").Value.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         bscCodigoProducto2.Selecciono = False
         bscProducto2.Selecciono = False
         bscCodigoProducto2.Focus()
      End If

#Region "Codigo Comentado"

      '' '' '' ''Me._CodigoProductoProveedor = String.Empty
      '' '' '' ''Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      '' '' '' ''Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      '' '' '' ''Me.bscCodigoProducto2.Enabled = False

      '' '' '' ''Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      '' '' '' ''Me.bscProducto2.Enabled = False
      '' '' '' '' ''Me.bscProducto2.Enabled = Publicos.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
      '' '' '' ''txtProductoObservacion.Text = Me.bscProducto2.Text
      '' '' '' ''If Publicos.ComprasModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()) Then
      '' '' '' ''   txtProductoObservacion.Visible = Publicos.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
      '' '' '' ''End If

      '' '' '' ''_calculaPreciosSegunFormula = producto.CalculaPreciosSegunFormula

      '' '' '' '' ''Dim impuestoInterno As Decimal = MuestraImpuestosInternos(Decimal.Parse(dr.Cells("ImporteImpuestoInterno").Value.ToString()))


      ' '' '' '' ''P1035 - REPASAR COMO APLICAR LOS COSTOS. SI IGUAL QUE COMPRAS O YA QUE ESTAMOS ARREGLAMOS CON IMPUESTOS INTERNOS
      '' '' '' ''Me.cmbPorcentajeIva.Text = dr.Cells("Alicuota").Value.ToString()
      '' '' '' ''Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
      '' '' '' '' ''--------------------------------------------------------------------------------------------------------------------------------
      '' '' '' ''Dim PrecioPorEmbalaje As Boolean = Boolean.Parse(dr.Cells("PrecioPorEmbalaje").Value.ToString())

      '' '' '' ''Dim PrecioVentaSinIVA As Decimal = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
      '' '' '' ''Dim PrecioVentaConIVA As Decimal = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())

      '' '' '' ''Dim PrecioCostoSinIVA As Decimal
      '' '' '' ''Dim PrecioCostoConIVA As Decimal
      '' '' '' ''Dim PrecioCosto As Decimal

      '' '' '' ''If Publicos.PreciosConIVA Then
      '' '' '' ''   PrecioCostoConIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
      '' '' '' ''   PrecioCostoSinIVA = (PrecioCostoConIVA - Producto.ImporteImpuestoInterno) / (1 + (Producto.Alicuota / 100) + (Producto.PorcImpuestoInterno / 100))
      '' '' '' ''Else
      '' '' '' ''   PrecioCostoSinIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
      '' '' '' ''   PrecioCostoConIVA = (PrecioCostoSinIVA * (1 + (Producto.Alicuota / 100) + (Producto.PorcImpuestoInterno / 100))) + Producto.ImporteImpuestoInterno
      '' '' '' ''End If


      '' '' '' ''If PrecioPorEmbalaje Then
      '' '' '' ''   PrecioVentaSinIVA = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()) / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
      '' '' '' ''   PrecioVentaConIVA = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()) / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
      '' '' '' ''   PrecioCostoConIVA = PrecioCostoConIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
      '' '' '' ''   PrecioCostoSinIVA = PrecioCostoSinIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
      '' '' '' ''End If

      '' '' '' '' ''Si el producto pertenece a una Marca que tiene lista de Precios especifica.. vuelvo a tomar los precios.

      '' '' '' ''Dim dt As DataTable
      '' '' '' ''dt = New Reglas.ClientesMarcasListasDePrecios().GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), Integer.Parse(dr.Cells("IdMarca").Value.ToString()))

      '' '' '' ''If dt.Rows.Count = 1 Then

      '' '' '' ''   Dim IdListaDePrecio As Integer
      '' '' '' ''   IdListaDePrecio = Integer.Parse(dt.Rows(0)("IdListaPrecios").ToString())

      '' '' '' ''   dt = Nothing
      '' '' '' ''   dt = New Reglas.Productos().GetPorCodigo(Me.bscCodigoProducto2.Text, actual.Sucursal.Id, IdListaDePrecio, "VENTAS")

      '' '' '' ''   PrecioVentaSinIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaSinIVA").ToString())
      '' '' '' ''   PrecioVentaConIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaConIVA").ToString())

      '' '' '' ''   If Publicos.PreciosConIVA Then
      '' '' '' ''      PrecioCostoConIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
      '' '' '' ''      PrecioCostoSinIVA = (PrecioCostoConIVA - Producto.ImporteImpuestoInterno) / (1 + (Producto.Alicuota / 100) + (Producto.PorcImpuestoInterno / 100))
      '' '' '' ''   Else
      '' '' '' ''      PrecioCostoSinIVA = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
      '' '' '' ''      PrecioCostoConIVA = (PrecioCostoSinIVA * (1 + (Producto.Alicuota / 100) + (Producto.PorcImpuestoInterno / 100))) + Producto.ImporteImpuestoInterno
      '' '' '' ''   End If
      '' '' '' ''End If
      '' '' '' '' ''----------------------------------------------------------------------------------------------------------------------------------

      '' '' '' '' ''Precio de Venta, Opciones: ACTUAL o ULTIMO
      '' '' '' ''If Publicos.VentasPrecioVenta <> "ACTUAL" Then

      '' '' '' ''   Dim CalculoVenta() As String = Publicos.VentasPrecioVenta.Split(";"c)

      '' '' '' ''   Dim OtroPrecioVenta As Decimal = 0

      '' '' '' ''   Select Case CalculoVenta(0).ToString()

      '' '' '' ''      Case "ULTIMO"

      '' '' '' ''         Dim oVP As Reglas.VentasProductos = New Reglas.VentasProductos()

      '' '' '' ''         OtroPrecioVenta = 0
      '' '' '' ''         '################ ver
      '' '' '' ''         'OtroPrecioVenta = oVP.GetUltimoDeProducto(actual.Sucursal.Id, _
      '' '' '' ''         '                                          Me.cmbTiposComprobantes.SelectedValue.ToString(), _
      '' '' '' ''         '                                          Me.bscCodigoProducto2.Text, _
      '' '' '' ''         '                                          Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)

      '' '' '' ''      Case Else
      '' '' '' ''         Throw New Exception("ATENCION: el sistema tiene configurado el Tipo de VENTA '" & CalculoVenta(0).ToString() & "' (incorrecto), verifíquelo en Parametros")

      '' '' '' ''   End Select

      '' '' '' ''   If OtroPrecioVenta <> 0 Then
      '' '' '' ''      PrecioVentaSinIVA = OtroPrecioVenta
      '' '' '' ''      PrecioVentaConIVA = Decimal.Round(PrecioVentaSinIVA * (1 + (Decimal.Parse(dr.Cells("Alicuota").Value.ToString()) / 100)), Me._decimalesRedondeoEnPrecio)
      '' '' '' ''   End If

      '' '' '' ''End If
      '' '' '' '' ''------------------------------------------

      '' '' '' ''If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
      '' '' '' ''   PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      '' '' '' ''   PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      '' '' '' ''   PrecioCostoSinIVA = Decimal.Round(PrecioCostoSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      '' '' '' ''   PrecioCostoConIVA = Decimal.Round(PrecioCostoConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      '' '' '' ''End If

      '' '' '' ''If (Me._eProveedor.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or _
      '' '' '' ''Not Me._eProveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
      '' '' '' ''   Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      '' '' '' ''   Me.txtPrecio.Tag = Me.txtPrecio.Text
      '' '' '' ''   PrecioCosto = PrecioCostoSinIVA
      '' '' '' ''Else
      '' '' '' ''   'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
      '' '' '' ''   Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      '' '' '' ''   Me.txtPrecio.Tag = Me.txtPrecio.Text
      '' '' '' ''   PrecioCosto = PrecioCostoConIVA
      '' '' '' ''End If

      '' '' '' ''CalcularImpuestoInterno()

      '' '' '' ''Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      '' '' '' ''Me.txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

      '' '' '' ''Me.txtTamanio.Text = dr.Cells("Tamano").Value.ToString()
      '' '' '' ''Me.txtUM.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
      '' '' '' ''Me.txtCantidad.Text = "1.00"

      '' '' '' ''Me.txtKilosModDesc.Text = dr.Cells("Kilos").Value.ToString()

      '' '' '' ''Me.dtpFechaActPrecios.Value = Date.Parse(dr.Cells("FechaActualizacion").Value.ToString())

      '' '' '' '' ''Se calculan los descuentos correspondientes al Cliente/Producto/Cantidad
      '' '' '' '' ''-------------------------------------------------------------------------
      '' '' '' ''Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.FacturacionDescuentoRecargo2CargaManual
      '' '' '' ''If Reglas.Publicos.FacturacionDescuentosAgrupaCantidadesPorRubro Then
      '' '' '' ''   _txtCantidad_prev = Nothing
      '' '' '' ''   Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

      '' '' '' ''   For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
      '' '' '' ''      If vp.Producto.IdRubro = Producto.IdRubro Then
      '' '' '' ''         cantidad += vp.Cantidad
      '' '' '' ''      End If
      '' '' '' ''   Next

      '' '' '' ''   'P1035 - Ver como calcula los descuentos Compras
      '' '' '' ''   'Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_eProveedor, Producto, cantidad, Me._decimalesEnTotales)

      '' '' '' ''   For Each vp As Entidades.PedidoProducto In Me._pedidosProductos
      '' '' '' ''      If vp.Producto.IdRubro = Producto.IdRubro Then
      '' '' '' ''         vp.DescuentoRecargoPorc = _DescuentosRecargosProd.DescuentoRecargo1
      '' '' '' ''         If calculaDescuentoRecargo2 Then
      '' '' '' ''            vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
      '' '' '' ''         End If
      '' '' '' ''      End If
      '' '' '' ''      vp.DescuentoRecargoProducto = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
      '' '' '' ''                                                               vp.DescuentoRecargoPorc, vp.DescuentoRecargoPorc2, vp.Cantidad)
      '' '' '' ''   Next

      '' '' '' ''   'RecalcularTodo()

      '' '' '' ''Else
      '' '' '' ''   'P1035 - Ver como calcula los descuentos Compras
      '' '' '' ''   'Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargo(_eProveedor, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), Me._decimalesEnTotales)
      '' '' '' ''End If

      '' '' '' ''txtCosto.Text = PrecioCosto.ToString("N" + _decimalesAMostrarEnPrecio.ToString())
      '' '' '' ''lblPrecioVentaPorTamano2.Text = String.Format("x {0}", Producto.UnidadDeMedida.NombreUnidadDeMedida)
      '' '' '' ''Dim idMoneda As Integer = Publicos.DetallePedido.PedidosMonedaPrecioVentaPorTamano
      '' '' '' ''If idMoneda = 0 Then
      '' '' '' ''   cmbMoneda.SelectedValue = Producto.Moneda.IdMoneda
      '' '' '' ''Else
      '' '' '' ''   cmbMoneda.SelectedValue = idMoneda
      '' '' '' ''End If
      '' '' '' ''_solicitaPrecioVentaPorTamano = Producto.SolicitaPrecioVentaPorTamano
      '' '' '' ''txtPrecioVentaPorTamano.Enabled = _solicitaPrecioVentaPorTamano

      '' '' '' ''txtProductoEspPulgadas.Text = Producto.EspPulgadas
      '' '' '' ''txtProductoEspmm.Text = Producto.Espmm.ToString("N" + _decimalesEnCantidad.ToString())
      '' '' '' ''txtProductoSAE.Text = Producto.CodigoSAE.ToString()
      '' '' '' ''cmbProductoProduccionProceso.SelectedValue = Producto.IdProduccionProceso
      '' '' '' ''cmbProductoProduccionForma.SelectedValue = Producto.IdProduccionForma


      '' '' '' ''Me.txtDescRecPorc1.Text = Me._DescuentosRecargosProd.DescuentoRecargo1.ToString("N" + _decimalesEnTotales.ToString())
      '' '' '' ''If calculaDescuentoRecargo2 Then
      '' '' '' ''   Me.txtDescRecPorc2.Text = Me._DescuentosRecargosProd.DescuentoRecargo2.ToString("N" + _decimalesEnTotales.ToString())
      '' '' '' ''End If

      '' '' '' ''If _calculaPreciosSegunFormula Then
      '' '' '' ''   _publicos.CargaComboFormulasDeProductos(cmbFormula, Producto.IdProducto)
      '' '' '' ''   If cmbFormula.Items.Count = 0 Then
      '' '' '' ''      cmbFormula.SelectedIndex = -1
      '' '' '' ''   Else
      '' '' '' ''      cmbFormula.SelectedValue = Producto.IdFormula
      '' '' '' ''   End If
      '' '' '' ''   cmbFormula.Enabled = True
      '' '' '' ''Else
      '' '' '' ''   cmbFormula.SelectedIndex = -1
      '' '' '' ''   cmbFormula.Enabled = False
      '' '' '' ''End If

      '' '' '' ''Me.HabilidaPrecios(Me._eProveedor IsNot Nothing)

      '' '' '' ''If Me._DescuentosRecargosProd.Mensaje <> "" Then
      '' '' '' ''   MessageBox.Show(Me._DescuentosRecargosProd.Mensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '' '' '' ''End If
      '' '' '' '' ''--------------------------------------------------------------------------

      '' '' '' ''Me._productoLoteTemporal = New Entidades.VentaProductoLote()
      '' '' '' ''Me._productoLoteTemporal.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

      '' '' '' ''Me.txtCantidad.Focus()
      '' '' '' ''Me.txtCantidad.SelectAll()

      '' '' '' '' ''Si esta habitada, seguramente la cambiaria
      '' '' '' ''If Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible Then
      '' '' '' ''   If Publicos.FacturacionModificaDescriProdCantidad Then
      '' '' '' ''      Me.txtCantidad.Focus()
      '' '' '' ''      Me.txtCantidad.SelectAll()
      '' '' '' ''   Else
      '' '' '' ''      txtProductoObservacion.Focus()
      '' '' '' ''      'Me.bscProducto2.Focus()
      '' '' '' ''      'Me.bscProducto2.SelectAll()
      '' '' '' ''   End If
      '' '' '' ''   If Publicos.FacturacionModificaDescripSolicitaKilos Then
      '' '' '' ''      Me.lblKilosModDesc.Visible = True
      '' '' '' ''      Me.txtKilosModDesc.Visible = True
      '' '' '' ''   Else
      '' '' '' ''      Me.lblKilosModDesc.Visible = False
      '' '' '' ''      Me.txtKilosModDesc.Visible = False
      '' '' '' ''   End If
      '' '' '' ''Else
      '' '' '' ''   Me.lblKilosModDesc.Visible = False
      '' '' '' ''   Me.txtKilosModDesc.Visible = False
      '' '' '' ''   If Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()) Then
      '' '' '' ''      txtProductoObservacion.Focus()
      '' '' '' ''   Else
      '' '' '' ''      Me.txtCantidad.Focus()
      '' '' '' ''      Me.txtCantidad.SelectAll()
      '' '' '' ''   End If
      '' '' '' ''End If

      '' '' '' ''SetearDescuentosPorCantidad(producto)
#End Region

   End Sub


   Private Sub CargarProductoCompleto(dr As DataGridViewRow, editarProductoDesdeGrilla As Boolean)

      Dim oProductos = New Reglas.Productos()

      Dim Prod = oProductos.GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      Dim pedidoProducto = DirectCast(dr.DataBoundItem, Entidades.PedidoProductoProveedor)

      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      '# Se trae la misma lógica que tiene Movimientos de Compras V2
      Dim dtProd As DataTable
      Dim rProductosProveedores As Reglas.ProductosProveedores = New Reglas.ProductosProveedores
      If Me.chbProductosDelProveedor.Checked Then
         dtProd = rProductosProveedores.GetPorProductoYProveedor(_eProveedor.IdProveedor, Me.bscCodigoProducto2.Text.Trim())
         Me.bscCodigoProducto2.Text = dtProd.Rows(0).Item("CodigoProductoProveedor").ToString().Trim()
      Else
         dtProd = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", soloBuscaPorIdProducto:=editarProductoDesdeGrilla)
         Me.bscCodigoProducto2.Datos = dtProd
      End If
      Me.bscCodigoProducto2.PresionarBoton()
      '------------------------------------------------------
      If Reglas.Publicos.PedidosProveedoresConservaOrdenProductos Then
         _ordenProducto = pedidoProducto.Orden  '  Integer.Parse(dr.Cells("Orden").Value.ToString())
      End If
      '------------------------------------------------------
      If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto AndAlso Me.bscCodigoProducto2.FilaDevuelta IsNot Nothing AndAlso Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
         'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
         Me.bscProducto2.Text = dr.Cells("ProductoDesc").Value.ToString()
         Me.txtProductoObservacion.Text = dr.Cells("ProductoDesc").Value.ToString()
      End If

      'NO hace falta, el "PresionarBoton" llama a "CargarProducto" y lo asigna.
      ''Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
      'Me.txtStock.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("Stock").Value.ToString()
      'Me.txtStock.Tag = Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("AfectaStock").Value.ToString())


      Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Costo").Value.ToString()), Me._decimalesRedondeoEnPrecio).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      Me.txtCantidad.Text = dr.Cells("Cantidad").Value.ToString()
      Me.cmbPorcentajeIva.Text = dr.Cells("AlicuotaImpuesto").Value.ToString()
      Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
      If Decimal.Parse(dr.Cells("Costo").Value.ToString()) <> 0 Then
         Me.txtDescRecPorc1.Text = Decimal.Parse(dr.Cells("DescuentoRecargoPorc").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesEnDescRec))
      End If

      txtCantidadUMC.SetValor(pedidoProducto.CantidadUMCompra)
      txtCantidadUMC.Tag = pedidoProducto.FactorConversionCompra
      txtPrecioPorUMCompra.SetValor(pedidoProducto.PrecioPorUMCompra)
      txtUnidadesCompras.SetValor(pedidoProducto.Cantidad)

      CalcularImpuestoInterno()

      Me.txtDescRec.Text = Decimal.Parse(dr.Cells("DescuentoRecargoProducto").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnPrecio))
      Me.txtTotalProducto.Text = Decimal.Parse(dr.Cells("Importe").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrarEnTotalXProducto))

      Me.dtpFechaEntregaProd.Value = DateTime.Parse(dr.Cells("FechaEntrega").Value.ToString())

      SetearDescuentosPorCantidad(Prod)
   End Sub

   Private Sub CalcularDatosDetalle()

      If Me.cmbCategoriaFiscal.SelectedItem Is Nothing Then Exit Sub

      For Each vPro As Entidades.PedidoProductoProveedor In Me._pedidosProductos

         vPro.DescRecGeneral = Decimal.Round((vPro.ImporteTotal * Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100), Me._decimalesRedondeoEnPrecio)

         Me.CalculaValores(vPro.Cantidad, vPro.AlicuotaImpuesto, vPro.ImporteImpuestoInterno, vPro.Costo,
               vPro.DescuentoRecargoPorc, vPro.DescuentoRecargoPorc2, Decimal.Parse(Me.txtDescRecGralPorc.Text),
               vPro.CostoNeto, 0, vPro.ImporteImpuesto, vPro.ImporteTotal)

         'vPro.DescuentoRecargoProducto = (vPro.PrecioNeto - vPro.Precio) * vPro.Cantidad

      Next

      Me.dgvProductos.Refresh()
      '     Me.dgvRemitoTransp.Refresh()

      Me.RecalcularSubtotales()
      Me.CalcularTotales()

   End Sub


   Private Sub CargarUnArticulo(linea As Entidades.PedidoProductoProveedor,
                                idProducto As String,
                                productoDescripcion As String,
                                descuentoRecargoPorc1 As Decimal,
                                descuentoRecargoPorc2 As Decimal,
                                descuentoRecargo As Decimal,
                                precio As Decimal,
                                cantidad As Decimal,
                                importeTotal As Decimal,
                                stock As Decimal,
                                costoLista As Decimal,
                                cantidadUMCompra As Decimal,
                                factorConversionCompra As Decimal,
                                precioPorUMCompra As Decimal,
                                idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                porcentajeIva As Decimal,
                                importeIva As Decimal,
                                precioNeto As Decimal,
                                criticidad As String,
                                fechaEntrega As Date,
                                fechaActualizacion As Date,
                                ImpuestoInterno As Decimal,
                                porcImpuestoInterno As Decimal)

      With linea
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         '.Producto.IdProducto = idProducto
         .Producto = New Reglas.Productos().GetUno(idProducto)  'Luego uso ciertas caracteristicas (ej: LOTE).
         .Producto.NombreProducto = productoDescripcion   'Piso la descripcion por si tiene habilitado la posibilidad de cambiarlas.
         .CodigoProductoProveedor = If(.Producto.ProductoProveedorHabitual IsNot Nothing, .Producto.ProductoProveedorHabitual.CodigoProductoProveedor, Nothing)
         .DescuentoRecargoPorc = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         .DescuentoRecargoProducto = descuentoRecargo
         .Costo = precio
         .Cantidad = cantidad
         .ImporteTotal = importeTotal
         .Stock = stock
         .CostoLista = costoLista
         .IdUnidadDeMedida = .Producto.UnidadDeMedida.IdUnidadDeMedida
         .IdUnidadDeMedidaCompra = .Producto.UnidadDeMedidaCompra.IdUnidadDeMedida

         If .IdUnidadDeMedida = .IdUnidadDeMedidaCompra Then
            .CantidadUMCompra = cantidad
            .FactorConversionCompra = 1
            .PrecioPorUMCompra = precio
         Else
            .CantidadUMCompra = cantidadUMCompra
            .FactorConversionCompra = factorConversionCompra
            .PrecioPorUMCompra = precioPorUMCompra
         End If

         .CostoNeto = precioNeto
         .AlicuotaImpuesto = porcentajeIva
         .ImporteImpuesto = importeIva
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .IdCriticidad = criticidad
         .FechaEntrega = fechaEntrega
         '.IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         '.NombreListaPrecios = Me.cmbListaDePrecios.Text
         .FechaActualizacion = fechaActualizacion
         .ImporteImpuestoInterno = ImpuestoInterno
         .PorcImpuestoInterno = porcImpuestoInterno

         If _ordenProducto > 0 Then
            .Orden = _ordenProducto
         ElseIf _ordenProducto = 0 Then
            .Orden = _pedidosProductos.MaxSecure(Function(x) x.Orden).IfNull() + 1
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

   Private Sub InsertarProducto()

      'Fuerzo los calculos porque pudo no pasar Insertar sin los tab en los campos de descuento.
      Me.CalcularDescuentosProductos()
      Me.CalcularTotalProducto()
      '------------------------------------------------------------------------------------------

      'cargo los valores de los controles a variables locales---------------------
      Dim oLineaDetalle As Entidades.PedidoProductoProveedor = New Entidades.PedidoProductoProveedor()
      Dim oLineaImpuestos As Entidades.VentaImpuesto = New Entidades.VentaImpuesto()

      Dim stock As Decimal = 0
      Dim precioCosto As Decimal = 0
      Dim precioLista As Decimal = 0

      Dim importeBruto As Decimal = 0
      Dim importeNeto As Decimal = 0
      Dim importeIva As Decimal = 0
      Dim importeTotal As Decimal = 0

      Dim descRecPorc1 As Decimal = Decimal.Parse(Me.txtDescRecPorc1.Text)
      Dim descRecargo As Decimal = Decimal.Parse(Me.txtDescRec.Text)

      If Me.txtStock.Text.Length <> 0 Then
         stock = Decimal.Parse(Me.txtStock.Text)
      End If

      Dim alicuotaIVA As Decimal
      Dim IdMoneda As Integer

      If bscCodigoProducto2.FilaDevuelta Is Nothing Then
         precioLista = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscProducto2.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      Else
         precioLista = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscCodigoProducto2.FilaDevuelta.Cells("IdMoneda").Value.ToString())
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

      If Reglas.Publicos.PreciosConIVA Then
         'Le quito el IVA que el producto tiene en forma predeterminada.
         precioCosto = Decimal.Round(precioCosto / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
         precioLista = Decimal.Round(precioLista / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
      End If

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

      'If (Me.bscProducto2.Enabled Or Me.txtProductoObservacion.Visible) And Publicos.FacturacionModificaDescripSolicitaKilos Then
      '   kilosProducto = Decimal.Parse(Me.txtKilosModDesc.Text.ToString())
      'Else
      '   If bscCodigoProducto2.FilaDevuelta Is Nothing Then
      '      kilosProducto = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("Kilos").Value.ToString())
      '   Else
      '      kilosProducto = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("Kilos").Value.ToString())
      '   End If
      'End If


      Dim precioProductoSinIVA As Decimal = Decimal.Parse(Me.txtPrecio.Text.Trim())
      Dim precioProductoConIVA As Decimal = 0

      Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text)

      Dim descRecPorGeneral As Decimal = Decimal.Parse(Me.txtDescRecGralPorc.Text)

      Dim precioNeto As Decimal = 0

      Dim criticidad As String = Me.cmbCriticidad.SelectedValue().ToString()
      Dim fechaEntrega As Date = Me.dtpFechaEntregaProd.Value()

      Me._numeroOrden += 1

      Dim impuestoInterno As Decimal = Decimal.Round(Decimal.Parse(Me.txtImpuestoInterno.Text) * cantidad, _decimalesRedondeoEnPrecio)
      CalculaValores(cantidad, alicuotaIVA, impuestoInterno, precioProductoSinIVA, descRecPorc1, 0, descRecPorGeneral,
                     precioNeto, importeBruto, importeIva, importeTotal)

      CargarUnArticulo(oLineaDetalle,
                       Me.bscCodigoProducto2.Text,
                       txtProductoObservacion.Text,
                       descRecPorc1,
                       0,
                       descRecargo,
                       precioProductoSinIVA,
                       cantidad,
                       importeTotal,
                       stock,
                       precioCosto,
                       txtCantidadUMC.ValorNumericoPorDefecto(0D),
                       txtCantidadUMC.TagNumericoPorDefecto(0D),                 'En txtCantidadUMC.Tag está el valor de Productos.FactorConversionCompras
                       txtPrecioPorUMCompra.ValorNumericoPorDefecto(0D),
                       _tipoImpuestoIVA,
                       alicuotaIVA,
                       importeIva,
                       precioNeto,
                       criticidad,
                       fechaEntrega,
                       Me.dtpFechaActPrecios.Value,
                       impuestoInterno,
                       Decimal.Parse(txtPorcImpuestoInterno.Text))

      'PE-38428 - Al insertar un Producto que utiliza NS no debe solicitar el mismo.
      '''''Selecciono los nros. de serie SOLO si el producto permite
      ''''If oLineaDetalle.Producto.NroSerie Then
      ''''   Dim nrosSerie As DataTable
      ''''   Dim onrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()
      ''''   '-- REQ-32489.- ---------------------------------------------------------
      ''''   nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, Me.bscCodigoProducto2.Text)
      ''''   Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidad.Text), 0).ToString())
      ''''   Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, oLineaDetalle.Producto, nrosSerie)
      ''''   If sel.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      ''''      MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie debe seleccionar los numeros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      ''''      Me.btnInsertar.Focus()
      ''''      Exit Sub
      ''''   Else
      ''''      For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
      ''''         oLineaDetalle.Producto.NrosSeries.Add(ns)
      ''''      Next
      ''''   End If
      ''''End If


      If oLineaDetalle.Orden = 0 Then
         oLineaDetalle.Orden = Me._numeroOrden
      End If
      Me._pedidosProductos.Add(oLineaDetalle)

      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
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

      'importeBruto = precioProducto * cantidad
      importeNeto = precioNeto * cantidad

      'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
      If (Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) Then
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
      Me.CalcularTotales()
      Me.CalcularDatosDetalle()
      'Me.CalcularTotales()
      Me.OrdenarGrillaProductos()

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
                              ByRef importeTotalProducto As Decimal)

      Dim alicuotaIVASobre100 As Decimal = (alicuotaIVA / 100)

      Dim precioParaDescuento As Decimal
      If Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
      Else
         precioParaDescuento = precioProducto
      End If

      Dim DescRec1 As Decimal = Decimal.Round((Math.Round(precioParaDescuento, Me._decimalesAMostrarEnPrecio) * descRecPorc1 / 100), Me._decimalesRedondeoEnPrecio)
      Dim DescRec2 As Decimal = Decimal.Round(((precioParaDescuento + DescRec1) * descRecPorc2 / 100), Me._decimalesRedondeoEnPrecio)

      'Dim descRec1 As Decimal = Decimal.Round(precioParaDescuento * descRecPorc1 / 100, Me._decimalesAMostrarEnPrecio)
      'Dim descRec2 As Decimal = Decimal.Round((precioParaDescuento + descRec1) * descRecPorc2 / 100, Me._decimalesAMostrarEnPrecio)
      Dim descRec As Decimal = Decimal.Round((precioParaDescuento + DescRec1 + DescRec2) * descRecPorGeneral / 100, Me._decimalesAMostrarEnPrecio)

      precioNeto = Decimal.Round(precioProducto, Me._decimalesAMostrarEnPrecio) + DescRec1 + DescRec2 + descRec

      Dim DescuentoRecargoProducto As Decimal = Math.Round((DescRec1 + DescRec2) * cantidad, Me._decimalesAMostrarEnPrecio)

      importeBruto = Decimal.Round(precioProducto, Me._decimalesAMostrarEnPrecio) * cantidad + DescuentoRecargoProducto

      'Lo calcula despues
      'importeTotalProducto = precioNeto * cantidad
      '------------------------------------
      'En Pantalla debe mostrar el total bruto (sin aplicar el descuento General)
      importeTotalProducto = importeBruto

      If Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         importeIVA = Decimal.Round(((precioNeto * cantidad) - impuestoInterno) - ((precioNeto * cantidad) - impuestoInterno) / (1 + alicuotaIVASobre100), Me._decimalesRedondeoEnPrecio)
      Else
         importeIVA = Decimal.Round((precioNeto * cantidad) * alicuotaIVASobre100, Me._decimalesRedondeoEnPrecio)
      End If

   End Sub

   Private Sub SetProductosDataSource()
      dgvProductos.DataSource = _pedidosProductos.ToArray().OrderBy(Function(x) x.Orden).ToArray()
      AjustarColumnasGrilla(dgvProductos, _titProductos)
      EvaluaMuestraUMCompras()
   End Sub

   '-- REQ-32596.- -------------------------------------------------------------------------------
   Private Sub EliminarLineaProducto()
      EliminarLineaProducto(dgvProductos.FilaSeleccionada(Of Entidades.PedidoProductoProveedor)())
   End Sub
   '----------------------------------------------------------------------------------------------

   Private Sub EliminarLineaProducto(vpro As Entidades.PedidoProductoProveedor)

      Dim producto As Entidades.Producto = vpro.Producto

      _pedidosProductos.Remove(vpro)

      'Dim producto As Entidades.Producto = _pedidosProductos(dgvProductos.SelectedRows(0).Index).Producto
      'Me._pedidosProductos.RemoveAt(Me.dgvProductos.SelectedRows(0).Index)

      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      '----------------------------------------------------------------------------------------------
      'Me.OrdenarGrillaProductos()

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
      Me.OrdenarGrillaProductos()

   End Sub

   Private Sub SetOrdenGrilla(column As DataGridViewColumn, ByRef orden As Integer)
      column.DisplayIndex = orden
      orden += 1
   End Sub

   Private Sub OrdenarGrillaProductos()
      Dim canti As Integer = 0
      With dgvProductos
         SetOrdenGrilla(.Columns("NrosSerie"), canti)
         SetOrdenGrilla(.Columns("IdProducto"), canti)
         SetOrdenGrilla(.Columns("ProductoDesc"), canti)

         If Reglas.Publicos.PedidosProvMuestraProvHabitual Then
            .Columns("CodigoProductoProveedor").Visible = True
            SetOrdenGrilla(.Columns("CodigoProductoProveedor"), canti)
         End If

         SetOrdenGrilla(.Columns("Cantidad"), canti)
         SetOrdenGrilla(.Columns("Costo"), canti)
         SetOrdenGrilla(.Columns("DescuentoRecargoPorc"), canti)
         SetOrdenGrilla(.Columns("DescuentoRecargoProducto"), canti)
         SetOrdenGrilla(.Columns("PrecioIVA"), canti)
         SetOrdenGrilla(.Columns("AlicuotaImpuesto"), canti)
         SetOrdenGrilla(.Columns("ImporteImpuesto"), canti)
         SetOrdenGrilla(.Columns("Importe"), canti)

         SetOrdenGrilla(.Columns("CantidadUMCompra"), canti)
         SetOrdenGrilla(.Columns("PrecioPorUMCompra"), canti)

         SetOrdenGrilla(.Columns("IdUnidadDeMedidaCompra"), canti)
         SetOrdenGrilla(.Columns("IdUnidadDeMedida"), canti)

         SetOrdenGrilla(.Columns("Stock"), canti)
         SetOrdenGrilla(.Columns("CostoNeto"), canti)
         SetOrdenGrilla(.Columns("IdTipoImpuesto"), canti)
         SetOrdenGrilla(.Columns("DescuentoRecargoPorc2"), canti)

         If Me._eProveedor IsNot Nothing AndAlso
            ((Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
             Me._eProveedor.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos) Then
            .Columns("PrecioIVA").Visible = False
         Else
            .Columns("PrecioIVA").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarPrecioConIVA
         End If

         .Columns("CostoNeto").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarPrecioUnitario
         .Columns("DescuentoRecargoPorc").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarDesc1
         .Columns("DescuentoRecargoPorc2").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarDesc2
         '.Columns(Entidades.PedidoProductoProveedor.Columnas.CantidadUMCompra.ToString()).Visible = Reglas.Publicos.Facturacion.FacturacionMostrarKilos
         .Columns("Stock").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarStock

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
   End Sub

   Private Sub HabilidaPrecios(Habilitado As Boolean)
      If _solicitaPrecioVentaPorTamano Then
         Me.txtPrecio.Enabled = False
      Else
         Me.txtPrecio.Enabled = Habilitado
      End If
   End Sub

   Private Sub FocusPrecio()
      txtPrecio.Focus()
      Me.txtPrecio.SelectAll()
   End Sub

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)

      Me.btnLimpiarProducto.Enabled = Habilitado

      Me.bscCodigoProducto2.Enabled = Habilitado
      Me.bscProducto2.Enabled = Habilitado
      Me.txtCantidad.Enabled = Habilitado
      HabilidaPrecios(Habilitado)
      Me.txtDescRecPorc1.Enabled = Habilitado
      Me.cmbPorcentajeIva.Enabled = Habilitado

      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado
      Me.cmbCriticidad.Enabled = Habilitado
      Me.dtpFechaEntregaProd.Enabled = Habilitado

      'Por las que le toque habilitar, es factible que no corresponda
      If Habilitado Then
         Me.cmbPorcentajeIva.Enabled = Me._eProveedor.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos
      End If

      'If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
      '    If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
      '        Me.cmbPorcentajeIva.Enabled = False
      '    End If
      'End If

   End Sub

   Private Function GetVendedorCombo(id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbComprador.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub RecalcularTodo(recuperaCosto As Boolean)

      Try

         If Me._pedidosProductos IsNot Nothing Then

            'Dim oProductos As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            'Dim pro1 As Entidades.ProductoSucursal

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Dim ProdDT As DataTable


            Dim DescRec1 As Decimal, DescRec2 As Decimal
            Dim PrecioNeto As Decimal

            For Each pro As Entidades.PedidoProductoProveedor In Me._pedidosProductos

               ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")

               Dim embalaje As Integer = 1
               If Boolean.Parse(ProdDT.Rows(0)("PrecioPorEmbalaje").ToString()) Then
                  embalaje = Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString())
               End If

               'If Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
               '   pro.Costo = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()) / embalaje
               'Else
               '   pro.Costo = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()) / embalaje
               'End If

               If recuperaCosto Then
                  Dim PrecioCostoSinIVA As Decimal
                  Dim PrecioCostoConIVA As Decimal
                  'Dim PrecioCosto As Decimal

                  If Reglas.Publicos.PreciosConIVA Then
                     PrecioCostoConIVA = Decimal.Parse(ProdDT.Rows(0)("PrecioCosto").ToString())
                     PrecioCostoSinIVA = (PrecioCostoConIVA - pro.Producto.ImporteImpuestoInterno) / (1 + (pro.Producto.Alicuota / 100) + (pro.PorcImpuestoInterno / 100))
                  Else
                     PrecioCostoSinIVA = Decimal.Parse(ProdDT.Rows(0)("PrecioCosto").ToString())
                     PrecioCostoConIVA = (PrecioCostoSinIVA * (1 + (pro.Producto.Alicuota / 100) + (pro.PorcImpuestoInterno / 100))) + pro.Producto.ImporteImpuestoInterno
                  End If

                  PrecioCostoConIVA = PrecioCostoConIVA
                  PrecioCostoSinIVA = PrecioCostoSinIVA

                  If Me._eProveedor.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                     pro.Costo = PrecioCostoSinIVA
                  Else
                     pro.Costo = PrecioCostoConIVA
                  End If

                  If pro.Producto.Moneda.IdMoneda = 2 Then
                     Dim cotizacion As Decimal = 1
                     Decimal.TryParse(txtCotizacionDolar.Text, cotizacion)
                     pro.Costo = pro.Costo * cotizacion
                  End If

               End If

               'Calculo el Nuevo Descuento/Recargo
               DescRec1 = Decimal.Round((Math.Round(pro.Costo, Me._decimalesAMostrarEnPrecio) * pro.DescuentoRecargoPorc / 100), Me._decimalesRedondeoEnPrecio)
               DescRec2 = Decimal.Round(((pro.Costo + DescRec1) * pro.DescuentoRecargoPorc2 / 100), Me._decimalesRedondeoEnPrecio)

               pro.DescuentoRecargoProducto = Math.Round((DescRec1 + DescRec2) * pro.Cantidad, Me._decimalesAMostrarEnPrecio)

               'Calculo el Nuevo Precio Neto
               PrecioNeto = Math.Round(pro.Costo, Me._decimalesAMostrarEnPrecio) + DescRec1 + DescRec2
               PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), Me._decimalesRedondeoEnPrecio)

               pro.CostoNeto = PrecioNeto

               pro.ImporteTotal = (Math.Round(pro.Costo, Me._decimalesAMostrarEnPrecio) * pro.Cantidad) + pro.DescuentoRecargoProducto

               pro.ImporteImpuesto = Math.Round(pro.ImporteImpuesto, Me._decimalesAMostrarEnPrecio)

            Next
            '-- REQ-32596.- -------------------------------------------------------------------------------
            SetProductosDataSource()
            'Me.dgvProductos.DataSource = _pedidosProductos.ToArray()
            'AjustarColumnasGrilla(dgvProductos, _titProductos)
            '----------------------------------------------------------------------------------------------

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

      If PedidoAEditar Is Nothing Then
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

      For Each dr As Entidades.PedidoProductoProveedor In Me._pedidosProductos

         impuestoInterno = dr.ImporteImpuestoInterno

         Dim precioParaDescuento As Decimal
         If Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            precioParaDescuento = dr.Costo - (impuestoInterno / dr.Cantidad)
         Else
            precioParaDescuento = dr.Costo
         End If

         'descRec1 = Decimal.Round(precioParaDescuento * dr.DescuentoRecargoPorc / 100, Me._decimalesRedondeoEnPrecio)
         'descRec2 = Decimal.Round((precioParaDescuento + descRec1) * dr.DescuentoRecargoPorc2 / 100, Me._decimalesRedondeoEnPrecio)
         descRec1 = Decimal.Round((Math.Round(precioParaDescuento, Me._decimalesAMostrarEnPrecio) * dr.DescuentoRecargoPorc / 100), Me._decimalesRedondeoEnPrecio)
         descRec2 = Decimal.Round(((precioParaDescuento + descRec1) * dr.DescuentoRecargoPorc2 / 100), Me._decimalesRedondeoEnPrecio)

         Dim DescuentoRecargoProducto As Decimal = Math.Round((descRec1 + descRec2) * dr.Cantidad, Me._decimalesAMostrarEnPrecio)

         importeCosto = dr.Costo * dr.Cantidad
         importeBruto = Math.Round(dr.Costo, Me._decimalesAMostrarEnPrecio) * dr.Cantidad + DescuentoRecargoProducto
         importeNeto = dr.CostoNeto * dr.Cantidad

         If Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            importeBruto = Decimal.Round((importeBruto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
            importeNeto = Decimal.Round((importeNeto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
            importeCosto = Decimal.Round((importeCosto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
         End If

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

   End Sub


   Private Function ProductosConLote() As Integer
      Dim Cantidad As Integer = 0
      For Each vp As Entidades.PedidoProductoProveedor In Me._pedidosProductos
         If vp.Producto.Lote Then
            Cantidad += 1
         End If
      Next
      Return Cantidad
   End Function

   Private Sub LimpiarDetalle()

      Me._pedidosProductos = Nothing
      Me._pedidosProductos = New List(Of Entidades.PedidoProductoProveedor)
      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      '----------------------------------------------------------------------------------------------

      'Lo comentamos para cuando se active la funcionalidad de ProveedorContacto
      '_pedidosContactos = New List(Of Entidades.ClienteContacto)()
      'ugContactos.DataSource = _pedidosContactos
      'AjustarColumnasGrilla(ugContactos, _titContactos)

      '  Me.dgvRemitoTransp.DataSource = Me._ventasProductos.ToArray()

      'Me.OrdenarGrillaProductos()

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

#End Region

   Private Sub MostrarPedidoEditable()
      Me.cmbTiposComprobantes.SelectedValue = PedidoAEditar.IdTipoComprobante

      txtLetra.Text = PedidoAEditar.LetraComprobante
      txtNumeroPosible.Text = PedidoAEditar.NumeroPedido.ToString()

      bscCodigoProveedor.Text = PedidoAEditar.Proveedor.CodigoProveedor.ToString()
      bscCodigoProveedor.PresionarBoton()

      'If Not String.IsNullOrWhiteSpace(PedidoAEditar.IdTipoComprobanteFact) Then
      '   Me.cmbTiposComprobantesFact.SelectedValue = PedidoAEditar.IdTipoComprobanteFact
      'Else
      '   Me.cmbTiposComprobantesFact.SelectedIndex = -1
      'End If

      cmbRespDistribucion.SelectedValue = PedidoAEditar.IdTransportista
      cmbCategoriaFiscal.SelectedValue = PedidoAEditar.CategoriaFiscal.IdCategoriaFiscal
      cmbComprador.SelectedItem = GetVendedorCombo(PedidoAEditar.Comprador.IdEmpleado)
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

      'If PedidoAEditar.PedidosProductos.Count > 0 Then
      '   cmbListaDePrecios.SelectedValue = PedidoAEditar.PedidosProductos(0).IdListaPrecios
      'End If

      Me._pedidosProductos = PedidoAEditar.PedidosProductos
      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
      'AjustarColumnasGrilla(dgvProductos, _titProductos)
      '----------------------------------------------------------------------------------------------

      _pedidosObservaciones = PedidoAEditar.PedidosObservaciones
      dgvObservaciones.DataSource = _pedidosObservaciones.ToArray()

      Me.RecalcularTodo(recuperaCosto:=False)
      'Me.CalcularTotales()
      'Me.CalcularDatosDetalle()

      cmbTiposComprobantes.Enabled = False
      txtLetra.Enabled = False
      chbNumeroAutomatico.Enabled = False
      txtNumeroPosible.Enabled = False
      txtNumeroPosible.Text = PedidoAEditar.NumeroPedido.ToString()
      txtOrdenDeCompra.Text = PedidoAEditar.NumeroOrdenCompra.ToString()

      tsbNuevo.Visible = False
      tsbGrabar.Enabled = True

      If Not Reglas.Publicos.PedidosPermiteFechaEntregaDistintas AndAlso Me._pedidosProductos.Count > 0 Then
         dtpFechaEntrega.Value = _pedidosProductos(0).FechaEntrega
      End If

      'Lo comentamos para cuando se active la funcionalidad de ProveedorContacto
      '_pedidosContactos.Clear()
      'For Each contacto As Entidades.PedidoClienteContacto In _pedidoAEditar.PedidosContactos
      '   _pedidosContactos.Add(contacto.Contacto)
      'Next
      'ugContactos.DataSource = _pedidosContactos

      Dim pedidoOriginal As Entidades.PedidoProveedor = New Reglas.PedidosProveedores().GetPedidoOrigen(_pedidoAEditar)
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

   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged
      ', cmbTiposComprobantesFact.SelectedIndexChanged
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

         If Me.bscCodigoProveedor.Selecciono Or Me.bscProveedor.Selecciono Then
            'P1035 - Ver como calcula los descuentos Compras
            'Me._DescRecGralPorc = New Reglas.Ventas().DescuentoRecargo(_eProveedor, DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante))
            Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
         End If


         'solo habilito el boton de Facturables segun corresponde (si Eligio Factura en blanco o negro, tickets, etc)
         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
            Me.cmbCategoriaFiscal.Enabled = True
            If Me._eProveedor IsNot Nothing Then
               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then

                  'Vuelvo a asignarlo para saber si lo cambio.
                  Me._eProveedor = New Reglas.Proveedores().GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))

                  Me.cmbCategoriaFiscal.Enabled = False
                  'Si cambio la categoria... le vuelvo la original
                  If DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal <> Me._IdCategoriaFiscalOriginal Then
                     Me.cmbCategoriaFiscal.SelectedValue = Me._IdCategoriaFiscalOriginal
                     'Exit Sub
                  End If

               Else

                  'Solo para los comprobantes en negro (los Pre-Eelctronicos son en blanco)
                  'If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
                  'Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
                  'Else
                  'Pudo cambiarla.
                  Me.cmbCategoriaFiscal.SelectedValue = Me._IdCategoriaFiscalOriginal
                  'End If

               End If
            End If
            '-----------------------------------------------------------


            'Si es X es remito, siempre debe tener esa letra, sino dejo la que esta.
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Length = 1 Then
               Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
                  Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
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

            '-- REQ-32596.- -------------------------------------------------------------------------------
            SetProductosDataSource()
            'Me.dgvProductos.DataSource = Me._pedidosProductos.ToArray()
            'AjustarColumnasGrilla(dgvProductos, _titProductos)
            '----------------------------------------------------------------------------------------------

            If Me.dgvProductos.Rows.Count > 0 Then
               Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            End If
            Me.dgvProductos.Refresh()
            Me.OrdenarGrillaProductos()

         End If

         Me.CambiarEstadoControlesDetalle(Me._eProveedor IsNot Nothing)

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

         'Por ahora , pero hay que hacerlo mas profundo (poner o quitar el IVA, etc).
         Me.CalcularTotales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

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
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub dgvProductos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProductos.CellFormatting
      If e.ColumnIndex = PrecioIVA.Index Then
         e.FormattingApplied = True
         Dim row As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
         If (Not Me._eProveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
            Me._eProveedor.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            e.Value = String.Format("{0:N2}", CDec(row.Cells(Costo.Name).Value))
         Else
            e.Value = String.Format("{0:N2}", (CDec(row.Cells(Costo.Name).Value) * (CDec(row.Cells(AlicuotaImpuesto.Name).Value) + 100) / 100) +
                                              CDec(row.Cells(ImporteImpuestoInterno.Name).Value))
         End If
      End If
   End Sub

   Private Sub chbModificaDescRecargo_CheckedChanged(sender As Object, e As EventArgs) Handles chbModificaDescRecargo.CheckedChanged

      Me.txtDescRecPorc1.ReadOnly = Not Me.chbModificaDescRecargo.Checked

      If Me.chbModificaDescRecargo.Checked Then
         Me.txtDescRecPorc1.Focus()
         Me.txtDescRecPorc1.SelectAll()
      ElseIf Me.chbModificaPrecio.Checked Then
         FocusPrecio()
      Else
         Me.txtCantidad.Focus()
         Me.txtCantidad.SelectAll()
      End If

   End Sub

   Private Sub SetearDescuentosPorCantidad(producto As Entidades.Producto)
      txtCantidad.Tag = Nothing
      ToolTip1.SetToolTip(txtCantidad, String.Empty)
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
            ToolTip1.Show(stb.ToString(), txtCantidad, New Point(0, 17))
            txtCantidad.Tag = stb.ToString()
         End If
      End If
   End Sub

   Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidad.Enter
      Try
         If txtCantidad.Tag IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtCantidad.Tag.ToString()) Then
            ToolTip1.Show(txtCantidad.Tag.ToString(), txtCantidad, New Point(0, 17))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
      Try
         ToolTip1.Hide(txtCantidad)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub PedidosProveedores_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         If _ConfiguracionImpresoras Then
            ShowMessage("No Existe la PC en Configuraciones/Impresoras")
            FormEnabled(value:=False, {grbProveedor, tbcDetalle}, tspFacturacion, {tsbSalir})
            'Me.Close()
         End If
         bscCodigoProveedor.Focus()

         If PedidoAEditar IsNot Nothing Then
            Dim cotizacionActualDolar As Decimal = New Reglas.Monedas().GetUna(2).FactorConversion
            'Dim cambioDolar As Boolean
            If PedidoAEditar.CotizacionDolar <> cotizacionActualDolar Then
               If ShowPregunta(String.Format("La cotización del dolar del presente Presupuesto difiere de la cotización actual del sistema." + Environment.NewLine + Environment.NewLine +
                                             "Presupuesto: {0:N2}" + Environment.NewLine +
                                             "Sistema: {1:N2}" + Environment.NewLine + Environment.NewLine +
                                             "¿Desea actualizar la cotización del dolar del Presupuesto?",
                                       PedidoAEditar.CotizacionDolar, cotizacionActualDolar)) = Windows.Forms.DialogResult.Yes Then
                  txtCotizacionDolar.Text = cotizacionActualDolar.ToString("N2")
                  RecalcularTodo(recuperaCosto:=True)
               End If
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
      Try
         BuscarProductoConConsultaPrecios()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub BuscarProductoConConsultaPrecios()
      If bscProducto2.Enabled Then
         Using frm As New ConsultarPrecios("SI", "TODOS")
            frm.ConsultarAutomaticamente = True
            If frm.ShowDialogParaBusqueda(bscCodigoProducto2.Text, bscProducto2.Text, Publicos.ListaPreciosPredeterminada) = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrWhiteSpace(frm.IdProductoDevuelta) Then
                  bscCodigoProducto2.Text = frm.IdProductoDevuelta
                  bscCodigoProducto2.PresionarBoton()
               End If
            End If
         End Using
      End If
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      Dim _parametros = New ParametrosFuncion()
      ConParametrosAyudante.Parse(parametros, GetType(ParametrosPermitidos), _parametros)

      _tipoTipoComprobante = _parametros.GetValor(Of String)(ParametrosPermitidos.TipoTipoComprobante)
      Dim permitePrecioCero = _parametros.GetValor(Of String)(ParametrosPermitidos.PermitePrecioCero)
      _permitePrecioCero = If(permitePrecioCero = "SI", True, If(permitePrecioCero = "NO", False, DirectCast(Nothing, Boolean?)))
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return ConParametrosAyudante.ParametrosDisponiblesAyuda(GetType(ParametrosPermitidos))
   End Function

   Public Enum ParametrosPermitidos
      <DefaultValue("PEDIDOSPROV"), Description("Definir el tipo de Tipo de Comprobante para usar en la pantalla")> TipoTipoComprobante
      <DefaultValue("DEFAULT"), Description("Indica si se permiten precios en Cero (SI/NO/DEFAULT)")> PermitePrecioCero
   End Enum


#Region "Contactos"
   'Lo comentamos para cuando se active la funcionalidad de ProveedorContacto
   'Private Sub btnLimpiarContacto_Click(sender As Object, e As EventArgs) Handles btnLimpiarContacto.Click
   '   RefrescarContactos()
   'End Sub

   'Private Sub RefrescarContactos()
   '   cmbContacto.SelectedIndex = -1
   '   cmbContacto.Focus()
   'End Sub


   'Private Sub btnInsertarContacto_Click(sender As Object, e As EventArgs) Handles btnInsertarContacto.Click
   '   Try
   '      InsertarContacto()
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   'Private Sub InsertarContacto()
   '   If cmbContacto.SelectedIndex >= 0 Then
   '      Dim existe As Boolean = False
   '      Dim contactoCombo As Entidades.ClienteContacto = DirectCast(cmbContacto.SelectedItem, Entidades.ClienteContacto)
   '      For Each contacto As Entidades.ClienteContacto In _pedidosContactos
   '         If contacto.IdContacto = contactoCombo.IdContacto Then
   '            existe = True
   '         End If
   '      Next
   '      If Not existe Then
   '         _pedidosContactos.Add(DirectCast(cmbContacto.SelectedItem, Entidades.ClienteContacto))
   '         ugContactos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
   '      End If
   '      RefrescarContactos()
   '   End If
   'End Sub

   'Private Sub btnEliminarContacto_Click(sender As Object, e As EventArgs) Handles btnEliminarContacto.Click
   '   Try
   '      If ugContactos.ActiveRow IsNot Nothing AndAlso
   '         ugContactos.ActiveRow.ListObject IsNot Nothing AndAlso
   '         TypeOf (ugContactos.ActiveRow.ListObject) Is Entidades.ClienteContacto Then
   '         _pedidosContactos.Remove(DirectCast(ugContactos.ActiveRow.ListObject, Entidades.ClienteContacto))
   '         ugContactos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
   '      End If
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   'Private Sub cmbContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbContacto.KeyDown
   '   Try
   '      If e.KeyCode = Keys.Enter Then
   '         InsertarContacto()
   '      End If
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub
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

   Private Sub btnInsertarObservacion_Click(sender As Object, e As EventArgs) Handles btnInsertarObservacion.Click
      Try
         If Me.bscObservacionDetalle.Text <> "" Then
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

            Me.bscObservacionDetalle.Focus()
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
   End Sub

   Private Sub InsertarObservacion()
      Dim oLineaDetalle As Entidades.PedidoObservacionProveedor = New Entidades.PedidoObservacionProveedor()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Linea = Me.dgvObservaciones.RowCount + 1
         .Observacion = Me.bscObservacionDetalle.Text
      End With

      Me._pedidosObservaciones.Add(oLineaDetalle)

      Me.dgvObservaciones.DataSource = Me._pedidosObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

      Me.LimpiarCamposObservDetalles()

   End Sub

   Private Sub LimpiarCamposObservDetalles()
      Me.bscObservacionDetalle.Text = ""
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

      For Each vObs As Entidades.PedidoObservacionProveedor In Me._pedidosObservaciones
         Linea += 1
         vObs.Linea = Linea
      Next

      Me.dgvObservaciones.DataSource = Me._pedidosObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

   End Sub
#End Region

   Private Function CalculaPrecioDesdePrecioPorTamano(precioVentaPorTamano As Decimal,
                                                      tamano As Decimal,
                                                      cotizacionDolar As Decimal) As Decimal
      Return Decimal.Round((precioVentaPorTamano * tamano * cotizacionDolar), _decimalesRedondeoEnPrecio)
   End Function

   Private Sub txtTotalProducto_TextChanged(sender As Object, e As EventArgs) Handles txtTotalProducto.TextChanged
      Try
         Dim utilidad As Decimal = 0
         Dim cantidad As Decimal = 0
         Dim importeNeto As Decimal = 0
         Dim importeCosto As Decimal = 0
         Dim PorcentajeUtilidad As Decimal = 0

         Decimal.TryParse(txtCantidad.Text, cantidad)
         Decimal.TryParse(txtTotalProducto.Text, importeNeto)

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

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCotizacionDolar_Leave(sender As Object, e As EventArgs) Handles txtCotizacionDolar.Leave
      Try
         Dim cotizacionDolar As Decimal
         If Not Decimal.TryParse(txtCotizacionDolar.Text, cotizacionDolar) Then
            cotizacionDolar = 0
         End If
         'SOLO REPROCESO SI CAMBIA EL TIPO DE CAMBIO. SI NO CAMBIÓ NO HAGO NADA
         If cotizacionDolar <> _cotizacionDolar_Prev Then
            RecalcularTodo(recuperaCosto:=True)
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

   Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
      Try
         CalcularImpuestoInterno()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecPorc1_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc1.Leave
      Try
         CalcularImpuestoInterno()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   'Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown
   '   Me.PresionarTab(e)
   'End Sub


   Public Sub CreaDesdeStock(codigoProveedor As Long?, dtProductos As DataTable)
      _drProductosDesdeStockColeccion = dtProductos.Select(String.Format("{0} <> 0", "Pedido"))
      If codigoProveedor.HasValue Then
         bscCodigoProveedor.Text = codigoProveedor.Value.ToString()
         bscCodigoProveedor.PresionarBoton()
      Else
         ToolTip1.Show("Luego de ingresar el proveedor se cargaran los productos del pedido.", bscCodigoProveedor, New Point(0, 17))
      End If
      If Reglas.Publicos.UtilizaOrdenCompraPedidos Then
         txtOrdenDeCompra.Text = NumeroOrdenCompra.ToString()
      End If
   End Sub


   Public Sub EvaluaMuestraUMCompras()
      Dim algunProductoConUMC = dgvProductos.DataSource(Of IEnumerable(Of Entidades.PedidoProductoProveedor)).AnySecure(Function(rq) rq.FactorConversionCompra <> 0)
      dgvProductos.Columns(Entidades.PedidoProductoProveedor.Columnas.CantidadUMCompra.ToString()).Visible = algunProductoConUMC
      dgvProductos.Columns(Entidades.PedidoProductoProveedor.Columnas.FactorConversionCompra.ToString()).Visible = False ' algunProductoConKilos
      dgvProductos.Columns(Entidades.PedidoProductoProveedor.Columnas.PrecioPorUMCompra.ToString()).Visible = algunProductoConUMC
   End Sub


#Region "Navegación"
   Private Sub NavegacionConEnter(e As KeyEventArgs, controlOrigen As Control)
      NavegacionConEnter(e, controlOrigen, Function(ctrl) New DatosNavegacion())
   End Sub
   Private Sub NavegacionConEnter(e As KeyEventArgs, controlOrigen As Control, getDatosNavegacion As Func(Of Control, DatosNavegacion))
      If e.KeyCode = Keys.Enter Then
         NavegacionConEnter(controlOrigen, getDatosNavegacion(controlOrigen))
      End If
   End Sub
   Private Sub NavegacionConEnter(controlOrigen As Control)
      NavegacionConEnter(controlOrigen, data:=New DatosNavegacion())
   End Sub

   Private Sub NavegacionConEnter(controlOrigen As Control, data As DatosNavegacion)
      If controlOrigen.Equals(txtDescRecGralPorc) Then
         Navegar(txtTotalGeneral, data)

      ElseIf controlOrigen.Equals(txtProductoObservacion) Then
         If data.Producto IsNot Nothing AndAlso data.Producto.EsObservacion Then
            Navegar(txtCantidad, data)
         Else
            Navegar(btnInsertar, data)
         End If

      ElseIf controlOrigen.Equals(txtCantidad) Then
         If chbModificaPrecio.Checked Or Decimal.Parse(txtPrecio.Text) = 0 Then
            Navegar(txtPrecio, data)
         Else
            Navegar(txtDescRecPorc1, data)
         End If
      ElseIf controlOrigen.Equals(cmbPorcentajeIva) Then
         Navegar(txtDescRecPorc1, data)

      ElseIf controlOrigen.Equals(txtPrecio) Then
         Navegar(txtDescRecPorc1, data)
      ElseIf controlOrigen.Equals(txtDescRecPorc1) Then
         Navegar(cmbCriticidad, data)
      ElseIf controlOrigen.Equals(cmbCriticidad) Then
         Navegar(dtpFechaEntregaProd, data)

      ElseIf controlOrigen.Equals(txtPrecioDolares) Then
         Navegar(txtPrecio, data)

      ElseIf controlOrigen.Equals(txtCantidadUMC) Then
         Navegar(txtPrecioPorUMCompra, data)
      ElseIf controlOrigen.Equals(txtPrecioPorUMCompra) Then
         Navegar(txtUnidadesCompras, data)
      ElseIf controlOrigen.Equals(txtUnidadesCompras) Then
         Navegar(txtCantidad, data)

      ElseIf controlOrigen.Equals(dtpFechaEntregaProd) Then
         Navegar(btnInsertar, data)

      ElseIf controlOrigen.Equals(txtPercepcionIVA) Then
         Navegar(txtPercepcionIIBB, data)
      ElseIf controlOrigen.Equals(txtPercepcionIIBB) Then
         Navegar(txtPercepcionGanancias, data)
      ElseIf controlOrigen.Equals(txtPercepcionGanancias) Then
         Navegar(txtPercepcionVarias, data)
      ElseIf controlOrigen.Equals(txtPercepcionVarias) Then
         Navegar(txtTotalPercepcion, data)

      End If
   End Sub
   Private Sub Navegar(controlDestino As Control)
      Navegar(controlDestino, New DatosNavegacion())
   End Sub
   Private Sub Navegar(controlDestino As Control, data As DatosNavegacion)
      If controlDestino.EsEditable AndAlso controlDestino.Visible Then
         controlDestino.Focus()
      Else
         NavegacionConEnter(controlDestino, data)
      End If
   End Sub
   Private Class DatosNavegacion
      Public Property Producto As Entidades.Producto
   End Class
#End Region


End Class