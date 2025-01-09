Imports Eniac.Entidades

Public Class OrdenesDeProduccion

   Private _decimalesEnTotales As Integer = 2
   Private _IdCategoriaFiscalOriginal As Short = 0
   Private _ConfiguracionImpresoras As Boolean
   Private _calculaPreciosSegunFormula As Boolean
   Private _formatoCantidades As String = "N2"
   Private _decimalesAnchoLargo As Integer = 0
   Private _formatoAnchoLargo As String = "N0"

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Public Sub New(OrdenProduccion As Entidades.OrdenProduccion)
      Me.New()
      OrdenProduccionAEditar = OrdenProduccion
   End Sub

#Region "Constantes"

   Private Const funcionActual As String = "Ventas"
   Private Const funcionSupervisor As String = "FacturacionRapidaSuper"

#End Region

#Region "Campos"

   Private _ordenesProduccionProductos As List(Of Entidades.OrdenProduccionProducto)
   Private _opProductosFormulasActual As Entidades.ProductoArbol
   Private _opProductosFormulas As New Dictionary(Of Entidades.OrdenProduccionProducto, Entidades.ProductoArbol)()
   Private _subTotales As List(Of Entidades.VentaImpuesto)
   Private _estado As Estados
   Private _publicos As Publicos
   Private _numeroComprobante As Integer
   Private _clienteE As Entidades.Cliente
   Private _comprobantesSeleccionados As List(Of Entidades.Venta)
   Private _ModificaDetalle As String
   Private _cheques As List(Of Entidades.Cheque)
   Private _tarjetas As List(Of Entidades.VentaTarjeta)
   Private _ventasObservaciones As List(Of Entidades.VentaObservacion)
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
   Private _valorRedondeo As Integer = 2     '4 Se ajusto hasta que grabemos directamente los campos con IVA
   Private _decimalesAMostrar As Integer = 2
   Private _fc As FacturacionComunes
   Private _DescuentosRecargosProd As Eniac.Reglas.DescuentoRecargoProducto
   Private _txtCantidad_prev As Decimal?
   Private _modificoDescuentos As Boolean
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _ordenesProduccionObservaciones As List(Of Entidades.OrdenProduccionObservacion)

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

   Private _OrdenProduccionAEditar As Entidades.OrdenProduccion
   Private _cargandoComboFormula As Boolean = False
   Private _cargandoProductoDesdeCompleto As Boolean = False

   Public Property OrdenProduccionAEditar() As Entidades.OrdenProduccion
      Get
         Return Me._OrdenProduccionAEditar
      End Get
      Private Set(value As Entidades.OrdenProduccion)
         Me._OrdenProduccionAEditar = value
      End Set
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         'Seguridad de la Lista de Precios
         Dim rUsuario = New Reglas.Usuarios()
         cmbListaDePrecios.Enabled = rUsuario.TienePermisos("Facturacion-ListaDePrecios")

         'Seguridad del Descuento/Recargo General
         txtDescRecGralPorc.ReadOnly = Not rUsuario.TienePermisos("Clientes-DescRecGeneralPorc")

         'Seguridad del Precio y Descuento/Recargo por Producto
         chbModificaPrecio.Visible = rUsuario.TienePermisos("Facturacion-ModifPrecioProd")
         chbModificaDescRecargo.Visible = rUsuario.TienePermisos("Facturacion-ModifDescRecProd")


         _decimalesAnchoLargo = Reglas.Publicos.ProduccionDecimalesVariablesModeloForma
         _formatoAnchoLargo = "N" + _decimalesAnchoLargo.ToString()

         txtProductoAnchoIntBase.Formato = _formatoAnchoLargo
         txtProductoLargoExtAlto.Formato = _formatoAnchoLargo
         txtProductoArchitrave.Formato = _formatoAnchoLargo
         dgvProductos.Columns(LargoExtAlto.Name).DefaultCellStyle.Format = _formatoAnchoLargo
         dgvProductos.Columns(AnchoIntBase.Name).DefaultCellStyle.Format = _formatoAnchoLargo
         dgvProductos.Columns(Architrave.Name).DefaultCellStyle.Format = _formatoAnchoLargo

         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         llbCliente.Visible = rUsuario.TienePermisos("Clientes-PuedeUsarMasInfo")
         '---------------------------------------
         _publicos = New Publicos()
         _fc = New FacturacionComunes()

         If OrdenProduccionAEditar IsNot Nothing Then
            _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, True, "PRODUCCION", , , , )
         Else
            _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, True, "PRODUCCION", , , , True)
         End If
         If cmbTiposComprobantes.Items.Count = 0 Then
            _ConfiguracionImpresoras = True
         End If

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantesFact, False, "VENTAS")

         _publicos.CargaComboCategoriasFiscales(cmbCategoriaFiscal)
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         _publicos.CargaComboEmpleados(cmbResponsable, Entidades.Publicos.TiposEmpleados.RESPPROD)
         If cmbResponsable.Items.Count = 1 Then
            cmbResponsable.SelectedIndex = 0
         Else
            cmbResponsable.SelectedIndex = -1
         End If

         If OrdenProduccionAEditar IsNot Nothing Then
            If OrdenProduccionAEditar.OrdenesProduccionProductos.Count = 0 Then
               _publicos.CargaComboEstadoVisita(cmbEstadoVisita, True, Nothing)
            Else
               _publicos.CargaComboEstadoVisita(cmbEstadoVisita, Nothing, True)
            End If
         Else
            _publicos.CargaComboEstadoVisita(cmbEstadoVisita, Nothing, True)
         End If

         'GAR: 13/01/2017
         'Si tiene varios estados pongo predeterminado el Normal.
         'Luego parametrizar
         If cmbEstadoVisita.Items.Count > 0 And cmbEstadoVisita.SelectedIndex = -1 Then
            cmbEstadoVisita.Text = "Normal"
         End If
         '-- Ajuste a Revisar
         Dim blnPermiteFechaEntregaDistintas As Boolean

         blnPermiteFechaEntregaDistintas = Reglas.Publicos.PedidosPermiteFechaEntregaDistintas

         lblFechaEntrega.Visible = Not blnPermiteFechaEntregaDistintas
         dtpFechaEntrega.Visible = Not blnPermiteFechaEntregaDistintas

         lblFechaEntregaProd.Visible = blnPermiteFechaEntregaDistintas
         dtpFechaEntregaProd.Visible = blnPermiteFechaEntregaDistintas

         '-----------------


         _publicos.CargaComboCriticidadesOP(cmbCriticidad)
         cmbCriticidad.SelectedIndex = 0

         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         _publicos.CargaComboListaDePrecios(cmbListaDePrecios)
         _publicos.CargaComboImpuestos(cmbPorcentajeIva)

         _publicos.CargaComboTransportistas(cmbRespDistribucion)

         _publicos.CargaComboProduccionModeloForma(cmbProductoProduccionModeloForma)

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True
         '  Me._publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, blnMiraUsuario, blnMiraPC)

         'Me.lblSemaforoRentabilidad.Visible = Reglas.Publicos.Facturacion.FacturacionVisualizaSemaforoUtilidad
         'Me.txtSemaforoRentabilidad.Visible = Me.lblSemaforoRentabilidad.Visible
         'Me.lblSemaforoPorcentaje.Visible = Me.lblSemaforoRentabilidad.Visible

         SeteaDetalles()

         _estaCargando = False

         _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            txtCantidad.Formato = "##,##0"
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         End If

         If Reglas.Publicos.VisualizaNrosSerie Then
            dgvProductos.Columns("NrosSerie").Visible = True
         End If

         dgvProductos.Columns("FechaEntrega").DefaultCellStyle.Format() = "dd/MM/yyyy"

         pnlCosto.Visible = Reglas.Publicos.DetalleProduccion.OrdProdMostrarCosto
         pnlProductoLargoExtAlto.Visible = Reglas.Publicos.DetalleProduccion.OrdProdMostrarProductoLargoExtAlto
         pnlProductoAnchoIntBase.Visible = Reglas.Publicos.DetalleProduccion.OrdProdMostrarProductoAnchoIntBase
         pnlProductoArchitrave.Visible = Reglas.Publicos.DetalleProduccion.OrdProdMostrarProductoArchitrave
         pnlFormula.Visible = Reglas.Publicos.DetalleProduccion.OrdProdMostrarFormula

         pnlProductoProduccionModeloForma.Visible = Reglas.Publicos.DetalleProduccion.OrdProdMostrarProductoModeloForma
         dgvProductos.Columns(Entidades.ProduccionModeloForma.Columnas.NombreProduccionModeloForma.ToString()).Visible = pnlProductoProduccionModeloForma.Visible

         dgvProductos.Columns(Entidades.OrdenProduccionProducto.Columnas.Costo.ToString()).Visible = pnlCosto.Visible
         dgvProductos.Columns(Entidades.OrdenProduccionProducto.Columnas.LargoExtAlto.ToString()).Visible = pnlProductoLargoExtAlto.Visible
         dgvProductos.Columns(Entidades.OrdenProduccionProducto.Columnas.AnchoIntBase.ToString()).Visible = pnlProductoAnchoIntBase.Visible
         dgvProductos.Columns(Entidades.OrdenProduccionProducto.Columnas.Architrave.ToString()).Visible = pnlProductoArchitrave.Visible
         dgvProductos.Columns("NombreFormula").Visible = pnlFormula.Visible

         pnlProcesoProductivo.Visible = Reglas.Publicos.DetallePedido.PedidosMostrarFormula
         dgvProductos.Columns("DescripcionProcesoProductivo").Visible = pnlProcesoProductivo.Visible

         OrdenarGrillaProductos()
         _tit = New Dictionary(Of String, String)()
         For Each col As DataGridViewColumn In dgvProductos.Columns
            If col.Visible Then
               _tit.Add(col.Name, String.Empty)
            End If
         Next

         If Not _ConfiguracionImpresoras Then
            Nuevo()
         End If

         If OrdenProduccionAEditar IsNot Nothing Then
            MostrarOrdenProduccionEditable()
         End If

         cmbRespDistribucion.Visible = Reglas.Publicos.PedidosSolicitaTransportista
         cmbRespDistribucion.LabelAsoc.Visible = cmbRespDistribucion.Visible

         cmbTiposComprobantesFact.Visible = Reglas.Publicos.PedidosSolicitaComprobanteGenerar
         cmbTiposComprobantesFact.LabelAsoc.Visible = cmbTiposComprobantesFact.Visible
      End Sub)
   End Sub

   Private Sub OcultaCampos()
      Dim visible = Reglas.Publicos.DetalleProduccion.OrdProdMostrarVenta

      lblAlicutotaIVA.Visible = visible
      cmbPorcentajeIva.Visible = visible
      chbModificaPrecio.Visible = visible
      txtPrecio.Visible = visible
      lblDescRecPorc1.Visible = visible
      txtDescRecPorc1.Visible = visible
      lblDescRecPorc2.Visible = visible
      txtDescRecPorc2.Visible = visible
      lblDescRec.Visible = visible
      txtDescRec.Visible = visible
      llbTotalProducto.Visible = visible
      txtTotalProducto.Visible = visible
      lblImpuestosInternos.Visible = visible
      txtImpuestosInternos.Visible = visible
      Label4.Visible = visible
      dtpFechaActPrecios.Visible = visible
      tbcDetalle.TabPages.Remove(tbpTotales)
      lblTotalGeneral.Visible = visible
      txtTotalGeneral.Visible = visible
      chbModificaDescRecargo.Visible = visible
   End Sub
#End Region

#Region "Eventos"

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

   Private Sub dgvObservaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvObservaciones.CellDoubleClick

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
      Dim oLineaDetalle As Entidades.OrdenProduccionObservacion = New Entidades.OrdenProduccionObservacion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Linea = Me.dgvObservaciones.RowCount + 1
         .Observacion = Me.bscObservacionDetalle.Text
      End With

      Me._ordenesProduccionObservaciones.Add(oLineaDetalle)

      Me.dgvObservaciones.DataSource = Me._ordenesProduccionObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

      Me.LimpiarCamposObservDetalles()

   End Sub

   Private Sub LimpiarCamposObservDetalles()
      Me.bscObservacionDetalle.Text = ""
   End Sub

   Private Function ValidarInsertaObservacion() As Boolean

      Return True
   End Function

   Private Sub EliminarLineaObservacion()
      Me._ordenesProduccionObservaciones.RemoveAt(Me.dgvObservaciones.SelectedRows(0).Index)
      Me.dgvObservaciones.DataSource = Me._ordenesProduccionObservaciones.ToArray()
   End Sub

   Private Sub RenumerarObservacionesDetalle()

      Dim Linea As Integer = 0

      For Each vObs As Entidades.OrdenProduccionObservacion In Me._ordenesProduccionObservaciones
         Linea += 1
         vObs.Linea = Linea
      Next

      Me.dgvObservaciones.DataSource = Me._ordenesProduccionObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

   End Sub

#End Region

   Private Sub dtpFechaEntregaProd_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaEntregaProd.KeyDown
      If e.KeyCode = Keys.Enter Then
         If cmbFormula.Visible Then
            cmbFormula.Focus()
         ElseIf txtProductoLargoExtAlto.Visible Then
            txtProductoLargoExtAlto.Focus()
         ElseIf txtProductoAnchoIntBase.Visible Then
            txtProductoAnchoIntBase.Focus()
         Else
            Me.btnInsertar.Focus()
         End If
      End If
   End Sub

   Private Sub cmbResponsable_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbResponsable.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.cmbCriticidad.Focus()
      End If
   End Sub
   Private Sub cmbCriticidad_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCriticidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.dtpFechaEntregaProd.Visible Then
            Me.dtpFechaEntregaProd.Focus()
            'ElseIf cmbFormula.Visible Then
            '   cmbFormula.Focus()
            'ElseIf txtProductoLargoExtAlto.Visible Then
            '   txtProductoLargoExtAlto.Focus()
            'ElseIf txtProductoAnchoIntBase.Visible Then
            '   txtProductoAnchoIntBase.Focus()
         Else
            Me.btnInsertar.Focus()
         End If
      End If
   End Sub

   Private Sub cmbFormula_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbFormula.KeyDown
      If e.KeyCode = Keys.Enter Then
         If txtProductoLargoExtAlto.Visible Then
            txtProductoLargoExtAlto.Focus()
         ElseIf txtProductoAnchoIntBase.Visible Then
            txtProductoAnchoIntBase.Focus()
         Else
            Me.btnInsertar.Focus()
         End If
      End If
   End Sub

   Private Sub Facturacion_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

      Select Case e.KeyCode
         Case Keys.F5
            If Me.tsbNuevo.Enabled And Me.tsbNuevo.Visible Then
               Me.tsbNuevo.PerformClick()
            End If
         Case Keys.F4
            If Me.tsbGrabar.Enabled Then
               Me.tsbGrabar.PerformClick()
            End If
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
         If MessageBox.Show("ATENCION: ¿Desea realizar un Pedido Nuevo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            Nuevo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", True)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
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

   Private Sub txtDescRecPorc1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecPorc1.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtDescRecPorc2.Focus()
      End If
   End Sub

   Private Sub txtDescRecPorc1_LostFocus(sender As Object, e As EventArgs) Handles txtDescRecPorc1.LostFocus
      Try
         If Me.txtDescRecPorc1.Text = "" Or Me.txtDescRecPorc1.Text = "-" Then
            Me.txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesAMostrar)
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtDescRecPorc2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecPorc2.KeyDown
      If e.KeyCode = Keys.Enter Then
         cmbResponsable.Focus()
      End If
   End Sub

   Private Sub txtDescRecPorc2_LostFocus(sender As Object, e As EventArgs) Handles txtDescRecPorc2.LostFocus
      Try
         If Me.txtDescRecPorc2.Text = "" Or Me.txtDescRecPorc2.Text = "-" Then
            Me.txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesAMostrar)
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
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

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
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

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
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
      End Try
   End Sub

   Private Sub llbCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked

      Try

         Dim PantCliente As ClientesDetalle

         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
            Dim Clie As Entidades.Cliente = New Eniac.Entidades.Cliente
            Dim blnIncluirFoto As Boolean = True
            Clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), blnIncluirFoto)
            Clie.Usuario = actual.Nombre
            PantCliente = New ClientesDetalle(Clie)
            PantCliente.CierraAutomaticamente = True
            PantCliente.StateForm = Eniac.Win.StateForm.Actualizar
         Else
            PantCliente = New ClientesDetalle(New Entidades.Cliente())
            PantCliente.CierraAutomaticamente = True
            PantCliente.StateForm = Eniac.Win.StateForm.Insertar
         End If

         If PantCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Me.bscCodigoCliente.Tag = PantCliente.txtCodigoCliente.Tag
            Me.bscCodigoCliente.Text = PantCliente.txtCodigoCliente.Text
            Me.bscCodigoCliente.PresionarBoton()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If (Not Me.bscProducto2.FilaDevuelta Is Nothing Or Not Me.bscCodigoProducto2.FilaDevuelta Is Nothing) And Me.txtCantidad.Text <> "" Then
            If Me.ValidarInsertaProducto() Then
               Me.InsertarProducto()
               Me.bscCodigoProducto2.Focus()
               If Me._ModificaDetalle <> "TODO" Then
                  Me.CambiarEstadoControlesDetalle(False)
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
            Dim ordProdProducto As Entidades.OrdenProduccionProducto = DirectCast(dgvProductos.SelectedRows(0).DataBoundItem, Entidades.OrdenProduccionProducto)
            If ordProdProducto.PedidoEstadoQueOrigino.Count > 0 Then
               Throw New Exception("Esta línea fue generada desde un pedido. No es posible eliminarla.")
            End If
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

      Me.txtPrecio.ReadOnly = Not Me.chbModificaPrecio.Checked

      If Me.chbModificaPrecio.Checked Then
         Me.txtPrecio.Focus()
         Me.txtPrecio.SelectAll()
      Else
         Me.txtCantidad.Focus()
         Me.txtCantidad.SelectAll()
      End If

   End Sub

   Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
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

   Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
      Try
         If Me.txtPrecio.Text.Trim().Length = 0 Then
            Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
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
            Me.txtCantidad.Text = "1"
         Else
            If Me.txtPrecio.Text = "-" Then
               Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
            End If
         End If

         'El Sub "Nuevo" ejecuta este evento y daba error porque 
         If Not String.IsNullOrEmpty(Me.bscCodigoProducto2.Text) Then

            'Se calculan los decuentos por Cantidad/Rubro
            Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text.ToString())
            _DescuentosRecargosProd = New CalculosDescuentosRecargos().DescuentoRecargo(_clienteE, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), _decimalesEnTotales)

            Dim cambia As Boolean = False
            If Not _txtCantidad_prev.HasValue OrElse _txtCantidad_prev.Value <> Decimal.Parse(Me.txtCantidad.Text.ToString()) Then

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
                                                            Decimal.Parse(Me.txtDescRecPorc2.Text)), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes
                  End If
               End If
            End If

            'SIGNIFICA QUE DEBE CAMBIAR LOS DESCUENTOS DE LA PANTALLA
            If cambia Then
               Me.txtDescRecPorc1.Text = Me._DescuentosRecargosProd.DescuentoRecargo1.ToString("N" + _decimalesEnTotales.ToString())
               Me.txtDescRecPorc2.Text = Me._DescuentosRecargosProd.DescuentoRecargo2.ToString("N" + _decimalesEnTotales.ToString())
            End If

         End If

         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         If txtProductoAnchoIntBase.Enabled AndAlso txtProductoAnchoIntBase.Visible Then
            txtProductoAnchoIntBase.Focus()

         ElseIf txtProductoLargoExtAlto.Enabled AndAlso txtProductoLargoExtAlto.Visible Then
            txtProductoLargoExtAlto.Focus()

         ElseIf txtProductoArchitrave.Enabled AndAlso txtProductoArchitrave.Visible Then
            txtProductoArchitrave.Focus()
         ElseIf cmbProductoProduccionModeloForma.Enabled AndAlso cmbProductoProduccionModeloForma.Visible Then
            cmbProductoProduccionModeloForma.Focus()

         ElseIf Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtPrecio.Focus()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            Me.btnInsertar.Focus()
         End If
      End If
   End Sub

   Private Sub cmbPorcentajeIva_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPorcentajeIva.KeyDown
      'If e.KeyCode = Keys.Enter Then
      'Me.PresionarTab(e)
      'End If
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtPrecio.Focus()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            Me.btnInsertar.Focus()
         End If
      End If
   End Sub

   Private Sub cmbPorcentajeIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPorcentajeIva.SelectedIndexChanged
      Try
         If Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing And Me.cmbPorcentajeIva.Tag IsNot Nothing Then
            If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
               Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Dim actualPrecio As Decimal = Decimal.Parse(Me.txtPrecio.Tag.ToString())
               Dim impuestoInterno As Decimal = Decimal.Parse(Me.txtImpuestosInternos.Text)
               actualPrecio = Decimal.Round((actualPrecio - impuestoInterno) / (1 + (Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()) / 100)), 4)
               actualPrecio = Decimal.Round((actualPrecio * (1 + (Decimal.Parse(Me.cmbPorcentajeIva.Text) / 100))) + impuestoInterno, 4)
               Me.txtPrecio.Text = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
               Me.txtPrecio.Tag = actualPrecio.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
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

   Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
      Try
         'limpia los textbox, y demas controles
         Me.LimpiarCamposProductos()
         'carga el producto seleccionado de la grilla en los textbox 
         Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex))
         'elimina el producto de la grilla
         Me.EliminarLineaProducto()

         If Me._ModificaDetalle = "SOLOPRECIOS" Then
            Me.txtPrecio.Enabled = True
            Me.txtDescRecPorc1.Enabled = True
            Me.txtDescRecPorc2.Enabled = True

            'Si Cliente utiliza impuestos, y Empresa utiliza impuestos, y es un comprobante en negro
            'If Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
            '############## ver
            Me.cmbPorcentajeIva.Enabled = True
            'End If

            Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
            Me.btnInsertar.Enabled = True
            Me.txtPrecio.Focus()
         Else
            Me.txtCantidad.Focus()
            Me.txtCantidad.SelectAll()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

   Private Sub cmbListaDePrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbListaDePrecios.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbListaDePrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaDePrecios.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         If Reglas.Publicos.ActualizaPreciosDeVenta Then
            Me.RecalcularTodo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs)
      Me.PresionarTab(e)
   End Sub

   Private Sub txtCotizacionDolar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCotizacionDolar.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbCategoriaFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCategoriaFiscal.KeyDown, cmbEstadoVisita.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

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

         If Me._clienteE IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then

            Me._clienteE.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString()))

            'Exento sin IVA (Cliente o Empresa). 
            If Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Me.cmbPorcentajeIva.Text = "0.00"
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

            Me.RecalcularTodo()
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

   Private Sub txtPercepcionIVA_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIVA.Leave
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

   Private Sub txtPercepcionGanancias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionGanancias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionVarias.Focus()
      End If
   End Sub

   Private Sub txtPercepcionVarias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionVarias.Leave
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

   Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
      TryCatched(
      Sub()
         Dim opProducto = dgvProductos.FilaSeleccionada(Of Entidades.OrdenProduccionProducto)
         'If Me.dgvProductos.Rows.Count = 0 Then Exit Sub
         'If Me.dgvProductos.SelectedRows.Count = 0 Then Exit Sub
         'If e.RowIndex <> -1 Then
         If opProducto IsNot Nothing Then
            If dgvProductos.Columns(e.ColumnIndex).Name = "NrosSerie" Then
               If opProducto.Producto.NrosSeries.Count > 0 Then
                  Dim rNrosSerie = New Reglas.ProductosNrosSerie()
                  Dim cantidadDeProductos = opProducto.Producto.NrosSeries.Count
                  '-- REQ-32489.- ---------------------------------------------------------
                  Using nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, opProducto.Producto.IdDeposito, opProducto.Producto.IdUbicacion, opProducto.Producto.IdProducto)
                     Using frmSel = New SeleccionoNrosSerie(cantidadDeProductos, opProducto.Producto, nrosSerie)
                        If frmSel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                           opProducto.Producto.NrosSeries.Clear()
                           opProducto.Producto.NrosSeries = frmSel.ProductosNrosSerie
                        End If
                     End Using
                  End Using
               End If
            ElseIf dgvProductos.Columns(e.ColumnIndex).Name = dgvProductos_verFormula.Name Then
               Using frm = New EstructuraProductos()
                  Dim forma = cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma)
                  frm.ShowDialog(Me, _opProductosFormulas(opProducto), GetValoresForma(opProducto, False), opProducto.ProduccionModeloForma,
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

   Public Sub ModificarOrdenProduccion(OrdenProduccion As Entidades.OrdenProduccion, owner As IWin32Window)
      If OrdenProduccion Is Nothing Then
         Throw New Exception("Debe pasar un OrdenProduccion a modificar.")
      End If

      Dim regOrdenesProduccion As Reglas.OrdenesProduccion = New Reglas.OrdenesProduccion()
      regOrdenesProduccion.VerificaOrdenProduccionModificable(OrdenProduccion)

      OrdenProduccionAEditar = OrdenProduccion

      ShowDialog(owner)
   End Sub

   Private Sub CalcularDescuentosProductos()

      Dim DescRec1 As Decimal
      Dim DescRec2 As Decimal
      Dim DescRecT As Decimal

      Dim precio As Decimal = Decimal.Parse(Me.txtPrecio.Text) - Decimal.Parse(txtImpuestosInternos.Text)

      DescRec1 = precio * Decimal.Parse(Me.txtDescRecPorc1.Text) / 100

      DescRec2 = (precio + DescRec1) * Decimal.Parse(Me.txtDescRecPorc2.Text) / 100

      DescRecT = Decimal.Round((DescRec1 + DescRec2) * Decimal.Parse(Me.txtCantidad.Text), Me._valorRedondeo)

      Me.txtDescRec.Text = DescRecT.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))

   End Sub

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

      Dim estadoSeleccionado As Entidades.EstadoOrdenProduccion
      Dim cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

      estadoSeleccionado = cache.BuscaEstadosOrdenesProduccion(Entidades.EstadoOrdenProduccion.ESTADO_ALTA)

      If estadoSeleccionado.ReservaMateriaPrima And estadoSeleccionado.IdDeposito = 0 Then
         ShowMessage(String.Format("El estado {0}, reserva materia Prima. Debe seleccionar Deposito y Ubicacion Por Defecto.", Entidades.EstadoOrdenProduccion.ESTADO_ALTA))
         Return False
      End If

      If Me.bscCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCliente.Focus()
         Return False
      End If

      If Me._ordenesProduccionProductos.Count = 0 Then
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

      For Each pro As Entidades.OrdenProduccionProducto In Me._ordenesProduccionProductos

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
            MessageBox.Show("La Fecha de Entrega del producto (Código " & pro.IdProducto.ToString() & ") es menor a la Fecha del Pedido (" _
                            & Me.dtpFecha.Value.ToString("dd/MM/yyyy") & ").", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         End If

         producto = pro.IdProducto
         'Sumo cantidades en productos repetidos para controlar stock
         For Each pro1 As Entidades.OrdenProduccionProducto In Me._ordenesProduccionProductos

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

      If Me.cmbVendedor.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbVendedor.Focus()
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

      Dim ImporteTope As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteTope
      If ImporteTope > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) > ImporteTope Then
         MessageBox.Show("El Comprobante Superó el Límite Permitido de $ " & ImporteTope.ToString("N" + Me._decimalesAMostrar.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      Dim ImporteMinimo As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteMinimo
      If ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) < ImporteMinimo Then
         MessageBox.Show("El Comprobante No Alcanzó el Mínimo Requerido de $ " & ImporteMinimo.ToString("N." + Me._decimalesAMostrar.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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


         Dim oOrdenProduccion As Reglas.OrdenesProduccion = New Reglas.OrdenesProduccion()
         Dim oOrdenesProduccion As New Entidades.OrdenProduccion

         With oOrdenesProduccion
            'cargo el comprobante
            .TipoComprobante = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)

            'cargo el cliente ----------
            .Cliente = Me._clienteE
            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)

            .LetraComprobante = Me.txtLetra.Text

            If Not Me.chbNumeroAutomatico.Checked Or (.TipoComprobante.EsFiscal And Not .TipoComprobante.GrabaLibro) Or OrdenProduccionAEditar IsNot Nothing Then
               .NumeroOrdenProduccion = Long.Parse(Me.txtNumeroPosible.Text)
            End If

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre

            'Pudo levantar la pantalla y grabar despues. Vuelvo a asignarlo para que tome la hora.
            If Me.dtpFecha.Value.Date = New Reglas.Generales().GetServerDBFechaHora.Date Then
               Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora
            End If
            .Fecha = Me.dtpFecha.Value

            If Me.cmbVendedor.SelectedIndex <> -1 Then
               .Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
            End If

            .Observacion = Me.txtdesc.Text

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
            '.Kilos = Decimal.Parse(Me.txtKilos.Text)

            'cargo la impresora
            '.Impresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal())
            .Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

            If Me.txtOrdenDeCompra.Text <> "" Then
               .NumeroOrdenCompra = Long.Parse(Me.txtOrdenDeCompra.Text.ToString())
            End If

            'cargo los productos
            .OrdenesProduccionProductos = Me._ordenesProduccionProductos

            .OrdenesProduccionProductos.ForEach(
               Sub(pp)
                  If _opProductosFormulas.ContainsKey(pp) AndAlso _opProductosFormulas(pp) IsNot Nothing Then
                     pp.OrdenesProduccionProductosFormulas = _opProductosFormulas(pp).ConvertToOPProductosFormula()
                  End If
               End Sub)

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
            .OrdenesProduccionObservaciones = Me._ordenesProduccionObservaciones

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
            ' .Utilidad = Decimal.Parse(Me.txtSemaforoRentabilidad.Key)

            '.ComisionVendedor = 0  'Se calcula despues

            'grabo la caja
            ' .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

         End With


         If OrdenProduccionAEditar Is Nothing Then
            oOrdenProduccion.Insertar(oOrdenesProduccion)
         Else
            oOrdenesProduccion.CentroEmisor = OrdenProduccionAEditar.CentroEmisor
            oOrdenProduccion.Actualizar(oOrdenesProduccion)
         End If


         'verifica si el tipo de comprobante se puede imprimir, sino no hace nada
         Try

            'Luego cambiar al otro parametro.
            If Publicos.PedidosVisualiza Then
               Me.ImprimirOrdenProduccion(oOrdenesProduccion, Publicos.PedidosVisualiza)
               MessageBox.Show("Grabación e Impresión Exitosa!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Me.ImprimeComprobante() Then
               Me.ImprimirOrdenProduccion(oOrdenesProduccion, False)
               MessageBox.Show("Grabación e Impresión Exitosa!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               MessageBox.Show("Grabación Exitosa!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         Catch ex As Exception
            'si da error en la impresión solo muestra el mensaje y sigue para borrar la pantalla.
            'sino no borraba la pantalla y era como que no se grababa la factura, mientras que si se graba
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try

         If OrdenProduccionAEditar Is Nothing Then
            Me.Nuevo()
         Else
            Close()
         End If

      End If

   End Sub

   Private Sub ImprimirOrdenProduccion(oOrdenProduccion As Entidades.OrdenProduccion, Visualizar As Boolean)
      Dim impresion As ImpresionOrdenesProduccion = New ImpresionOrdenesProduccion()
      impresion.ImprimirOrdenProduccion(oOrdenProduccion, Visualizar)
   End Sub


   Private Function ImprimeComprobante() As Boolean
      'Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime
      Return Me._imprime
   End Function

   Private Sub SeteaDetalles()
      Me._ordenesProduccionProductos = New List(Of Entidades.OrdenProduccionProducto)
      Me._subTotales = New List(Of Entidades.VentaImpuesto)()
      Me._ventasObservaciones = New List(Of Entidades.VentaObservacion)()
      Me._ordenesProduccionObservaciones = New List(Of Entidades.OrdenProduccionObservacion)()
      Me._cheques = New List(Of Entidades.Cheque)()
      Me._tarjetas = New List(Of Entidades.VentaTarjeta)()
      Me._chequesRechazados = New List(Of Entidades.Cheque)()
      Me._productosLotes = New List(Of Entidades.VentaProductoLote)()

   End Sub

   Private Sub CalcularTotalProducto()
      If Me.txtCantidad.Text = "-" Then
         Me.txtCantidad.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      End If
      If Me.txtDescRec.Text = "" Or Me.txtDescRec.Text = "-" Then
         Me.txtDescRec.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      End If
      Me.txtTotalProducto.Text = ((Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtCantidad.Text)) + Decimal.Parse(Me.txtDescRec.Text)).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
   End Sub

   Private Sub LimpiarCamposProductos()
      Dim precioCero As String = (0).ToString("N" + Me._decimalesAMostrar.ToString())
      Dim cantidadCero As String = (0).ToString("N" + Me._decimalesAMostrar.ToString())
      Dim cantidadCeroAnchoLargo = (0).ToString(_formatoAnchoLargo)

      Me.bscCodigoProducto2.Enabled = True
      Me.bscCodigoProducto2.Text = ""
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.Enabled = True
      Me.bscProducto2.Text = ""
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.txtPrecio.Text = precioCero
      Me.txtStock.Text = cantidadCero
      Me.txtStock.Tag = False
      Me.txtCantidad.Text = cantidadCero
      Me.txtDescRec.Text = precioCero
      Me.txtTotalProducto.Text = precioCero
      Me.txtDescRecPorc1.Text = precioCero
      Me.txtDescRecPorc2.Text = precioCero
      Me.txtTamanio.Text = precioCero
      Me.txtUM.Text = ""
      Me.cmbCriticidad.SelectedIndex = 0
      If cmbResponsable.Items.Count = 1 Then
         cmbResponsable.SelectedIndex = 0
      Else
         cmbResponsable.SelectedIndex = -1
      End If
      Me.dtpFechaEntregaProd.Value = Date.Today
      Me.dtpFechaActPrecios.Value = Date.Today

      txtProductoLargoExtAlto.Text = cantidadCeroAnchoLargo
      txtProductoAnchoIntBase.Text = cantidadCeroAnchoLargo
      txtProductoArchitrave.Text = cantidadCeroAnchoLargo
      cmbFormula.SelectedIndex = -1
      cmbProcesoProductivo.SelectedIndex = -1

      cmbProductoProduccionModeloForma.SelectedIndex = -1

      MuestraImpuestosInternos(0)

      _modificoDescuentos = False
      _txtCantidad_prev = Nothing

      _opProductosFormulasActual = Nothing

   End Sub

   Private Function MuestraImpuestosInternos(importe As Decimal) As Decimal
      txtImpuestosInternos.Text = importe.ToString("N2")
      txtImpuestosInternos.Visible = importe <> 0
      txtImpuestosInternos.LabelAsoc.Visible = txtImpuestosInternos.Visible
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
      Dim percepcionIVA As Decimal = 0
      Dim percepcionIB As Decimal = 0
      Dim percepcionGanancias As Decimal = 0
      Dim percepcionVarias As Decimal = 0
      Dim percepcionTotal As Decimal = 0

      'If Me.dgvProductos.Rows.Count > 0 Then

      For Each vp As Entidades.OrdenProduccionProducto In Me._ordenesProduccionProductos
         Kilos += vp.Kilos
      Next

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

      Me.txtTotalPercepcion.Text = percepcionTotal.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalBruto.Text = bruto.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtDescRecGral.Text = (subTotal - bruto).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalNeto.Text = subTotal.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalSubtotales.Text = totalGeneral.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalImpuestos.Text = iva.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalImpuestosInternos.Text = impInt.ToString("##,##0." + New String("0"c, Me._decimalesEnTotales))
      Me.txtTotalGeneral.Text = totalGeneral.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))

      ' Me.CalcularDiferenciaDePago()

      Me.txtKilos.Text = Kilos.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))

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

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.txtDireccionYLocalidad.Text = dr.Cells("Direccion").Value.ToString() & " - " & dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtTelefonos.Text = dr.Cells("Telefono").Value.ToString() & " " & dr.Cells("Celular").Value.ToString()
      Me.txtLimiteDeCredito.Text = dr.Cells("LimiteDeCredito").Value.ToString()

      Me.cmbCategoriaFiscal.SelectedValue = dr.Cells("IdCategoriaFiscal").Value
      Me._IdCategoriaFiscalOriginal = Short.Parse(dr.Cells("IdCategoriaFiscal").Value.ToString())

      'Si es X es remito y siempre debe tener esa letra
      'If Me.txtLetra.Text <> "X" And Me.txtLetra.Text <> "R" Then
      '    Me.txtLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
      'End If

      Me.txtCategoria.Text = dr.Cells("NombreCategoria").Value.ToString()
      Me.tbcDetalle.Enabled = True

      If Reglas.Publicos.PermiteModificarClientePedido Then
         bscCliente.Permitido = True
         bscCodigoCliente.Permitido = True
      Else
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
      End If

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
         'Me.cmbFormaPago.SelectedValue = Me._clienteE.IdFormasPago
         'If Me.cmbFormaPago.SelectedIndex = -1 And Me.cmbFormaPago.Items.Count > 0 Then
         '    Me.cmbFormaPago.SelectedIndex = 0
         'End If
      End If


      Me.CambiarEstadoControlesDetalle(True)

      'Me.cmbPorcentajeIva.Enabled = Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos

      'Cargo el Descuento/Recargo cargado en la categoria
      Dim oCat As Reglas.Categorias = New Reglas.Categorias()
      Dim Cat As Entidades.Categoria

      Cat = oCat.GetUno(Integer.Parse(dr.Cells("IdCategoria").Value.ToString()))
      Me.txtDescRecGralPorc.Text = Cat.DescuentoRecargo.ToString()
      '---------------------------------------------------------------------------

      'Si el Cliente tiene Descuento/Recargo, prevalece por el de la Categoria.
      If Decimal.Parse(dr.Cells("DescuentoRecargoPorc").Value.ToString()) <> 0 Then
         Me.txtDescRecGralPorc.Text = dr.Cells("DescuentoRecargoPorc").Value.ToString()
      End If

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

      If Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
         Me.cmbVendedor.SelectedIndex = -1
         Me.cmbVendedor.Focus()
      End If


      If Not Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante And Not Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
         Me.bscCodigoProducto2.Focus()
      End If


   End Sub

   Private Sub CargarSaldosCtaCte()

      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos

      Dim dt As DataTable

      dt = oCtaCteDet.GetSaldosCtaCte(Nothing, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Nothing, 0)

      Me.txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtSaldoCtaCteVencido.Text = "0." + New String("0"c, Me._decimalesAMostrar)

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

   End Sub



   Private Sub Nuevo()

      Me.tsbGrabar.Enabled = False
      Me._estado = Estados.Insercion
      'Me.Text = "Facturación"

      Me.cmbVendedor.Enabled = True

      Me.txtTotalGeneral.Enabled = True
      Me.txtDescRecGral.Enabled = True
      Me.tbcDetalle.SelectedTab = Me.tbpProductos
      Me.tbcDetalle.Enabled = True
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty
      'Me.txtBruto.Enabled = True
      Me.bscCliente.Permitido = True
      Me.bscCodigoCliente.Permitido = True
      Me._clienteE = Nothing

      'Me.dtpFecha.Enabled = True
      Me.txtdesc.Text = String.Empty
      Me._ordenesProduccionProductos.Clear()
      Me.dgvProductos.DataSource = Me._ordenesProduccionProductos.ToArray()
      AjustarColumnasGrilla()
      Me._productosLotes.Clear()
      Me._subTotales.Clear()
      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      Me.txtTelefonos.Text = String.Empty
      Me.txtLimiteDeCredito.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtSaldoCtaCteVencido.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      'Me.txtBruto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDireccionYLocalidad.Text = String.Empty
      Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
      Me.txtTotalGeneral.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtKilos.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      '----
      Me.bscCodigoProducto2.Text = String.Empty
      Me.bscProducto2.Text = String.Empty
      Me.txtDescRecPorc1.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDescRecPorc2.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtStock.Text = String.Empty
      Me.txtStock.Tag = False
      Me.txtCantidad.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTamanio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtUM.Text = ""
      Me.btnInsertar.Enabled = True
      Me.btnEliminar.Enabled = True
      '----

      Me.txtTotalBruto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalNeto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalSubtotales.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalImpuestos.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPercepcionIVA.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPercepcionIIBB.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPercepcionGanancias.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPercepcionVarias.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalPercepcion.Text = "0." + New String("0"c, Me._decimalesAMostrar)


      If Me.cmbVendedor.Items.Count > 0 Then
         Me.cmbVendedor.SelectedIndex = 0
      Else
         Me.cmbVendedor.SelectedIndex = -1
      End If

      Me.cmbListaDePrecios.SelectedIndex = 0

      Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesAMostrar)

      'Me.txtCategoriaFiscal.Text = String.Empty
      'Me.txtCategoria.Text = String.Empty

      Me.cmbCategoriaFiscal.Enabled = True
      Me.cmbCategoriaFiscal.SelectedIndex = -1

      Me.CambiarEstadoControlesDetalle(False)

      Me._ModificaDetalle = "TODO"

      If Me._comprobantesSeleccionados IsNot Nothing Then
         Me._comprobantesSeleccionados.Clear()
      End If

      Me._transportistaA = Nothing

      Me._ventasObservaciones.Clear()

      Me._numeroOrden = 0

      Me.CargarProximoNumero()

      'Me.txtSemaforoRentabilidad.Text = ""
      'Me.txtSemaforoRentabilidad.Key = "0"

      Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("#0.00")

      Me.chbModificaPrecio.Checked = Reglas.Publicos.Facturacion.FacturacionModificaPrecioProducto
      Me.chbModificaDescRecargo.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescRecProducto

      ' Me.cmbCajas.SelectedIndex = 0

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Focus()

      Me.cmbTiposComprobantes.SelectedIndex = 0
      Me.cmbTiposComprobantesFact.SelectedIndex = -1

      Me.dtpFechaEntrega.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now

      Me.txtOrdenDeCompra.Text = ""

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

      If Reglas.Publicos.DetalleProduccion.OrdProdMostrarVenta Then
         If Decimal.Parse(Me.txtPrecio.Text) <= 0 And Not Reglas.Publicos.VentasConProductosEnCero Then
            MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtPrecio.Focus()
            Return False
         End If
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
            MessageBox.Show("La Fecha de Entrega es menor a la Fecha del Pedido (" & Me.dtpFecha.Value.ToString("dd/MM/yyyy") & ").", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFechaEntregaProd.Focus()
            Return False
         End If
      End If

      If pnlFormula.Visible And cmbFormula.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar una fórmula")
         Me.cmbFormula.Focus()
         Return False
      End If

      If pnlProcesoProductivo.Visible And cmbProcesoProductivo.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un Proceso Productivo")
         Me.cmbProcesoProductivo.Focus()
         Return False
      End If


      If cmbResponsable.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un Responsable.")
         Me.cmbResponsable.Focus()
         Return False
      End If

      Dim estadoAlta = New Reglas.EstadosOrdenesProduccion().GetUno(Entidades.EstadoOrdenProduccion.ESTADO_ALTA)
      If estadoAlta.ReservaMateriaPrima AndAlso True Then
         If pnlFormula.Visible Then
            Dim comp = New Reglas.ProductosComponentes().GetComponentes(actual.Sucursal.IdSucursal, bscCodigoProducto2.Text, cmbFormula.ValorSeleccionado(0I), cmbListaDePrecios.ValorSeleccionado(0I))
            Dim invalidos = comp.Where(Function(dr) dr.Field(Of Boolean)("ComponenteUsaLote") Or dr.Field(Of Boolean)("ComponenteUsaNroSerie"))
            If invalidos.AnySecure() Then
               Dim stbMensaje = New StringBuilder()
               stbMensaje.AppendFormatLine("El estado {0} está marcado como Reserva Materia Prima", estadoAlta.IdEstado).AppendLine()
               stbMensaje.AppendFormatLine("El producto tiene los siguientes componentes que no pueden cargarse directamente con Reserva Materia Prima")
               For Each inv In invalidos
                  stbMensaje.AppendFormatLine("  * {0} - {1}: Usa {2}",
                                              inv.Field(Of String)("IdProducto"), inv.Field(Of String)("NombreProducto"),
                                              If(inv.Field(Of Boolean)("ComponenteUsaLote"), "Lote", "Nro. Serie"))

               Next
               stbMensaje.AppendFormatLine("No es posible continuar")
               ShowMessage(stbMensaje.ToString())
               bscCodigoProducto2.Focus()
               Return False
            End If
         End If
         If pnlProcesoProductivo.Visible Then
            ShowMessage(String.Format("El estado {0} está marcado como Reserva Materia Prima. No se puede Reservar Materia Prima de productos que utilizan Proceso Productivo", estadoAlta.IdEstado))
            bscCodigoProducto2.Focus()
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

      Return True

   End Function

   Private Sub CargarProducto(dr As DataGridViewRow)

      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscCodigoProducto2.Enabled = False

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscProducto2.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

      Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      _calculaPreciosSegunFormula = Producto.CalculaPreciosSegunFormula

      Dim impuestoInterno As Decimal = MuestraImpuestosInternos(Decimal.Parse(dr.Cells("ImporteImpuestoInterno").Value.ToString()))

      Me.cmbPorcentajeIva.Text = dr.Cells("Alicuota").Value.ToString()
      Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
      '--------------------------------------------------------------------------------------------------------------------------------

      Dim PrecioVentaSinIVA As Decimal = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString())
      Dim PrecioVentaConIVA As Decimal = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString())

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
            PrecioVentaConIVA = Decimal.Round(PrecioVentaSinIVA * (1 + (Decimal.Parse(dr.Cells("Alicuota").Value.ToString()) / 100)), Me._valorRedondeo)
         End If

      End If
      '------------------------------------------

      If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
         PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
         PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
      End If

      If (Me._clienteE.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
      Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
         Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
         Me.txtPrecio.Tag = Me.txtPrecio.Text
      Else
         'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
         Me.txtPrecio.Text = PrecioVentaConIVA.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
         Me.txtPrecio.Tag = Me.txtPrecio.Text
      End If

      Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      Me.txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

      Me.txtTamanio.Text = dr.Cells("Tamano").Value.ToString()
      Me.txtUM.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
      Me.txtCantidad.Text = "1.00"

      Me.dtpFechaActPrecios.Value = Date.Parse(dr.Cells("FechaActualizacion").Value.ToString())


      'Se calculan los descuentos correspondientes al Cliente/Producto/Cantidad
      '-------------------------------------------------------------------------
      _DescuentosRecargosProd = New CalculosDescuentosRecargos().DescuentoRecargo(_clienteE, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), _decimalesEnTotales)

      Me.txtDescRecPorc1.Text = Me._DescuentosRecargosProd.DescuentoRecargo1.ToString("N" + _decimalesEnTotales.ToString())

      Me.txtDescRecPorc2.Text = Me._DescuentosRecargosProd.DescuentoRecargo2.ToString("N" + _decimalesEnTotales.ToString())

      If Me._DescuentosRecargosProd.Mensaje <> "" Then
         MessageBox.Show(Me._DescuentosRecargosProd.Mensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
      '--------------------------------------------------------------------------
      '-- REQ-40408.- --
      pnlProcesoProductivo.Visible = (Producto.EsCompuesto And Producto.IdProcesoProductivoDefecto IsNot Nothing)
      pnlFormula.Visible = Producto.EsCompuesto And Producto.IdFormula <> 0
      '--------------------------------------------------------------------------

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

      txtProductoAnchoIntBase.Enabled = Producto.CalculaPreciosSegunFormula
      txtProductoLargoExtAlto.Enabled = Producto.CalculaPreciosSegunFormula
      txtProductoArchitrave.Enabled = Producto.CalculaPreciosSegunFormula


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
      'If Me.cmbTiposComprobantes.SelectedIndex <> -1 Then
      '    If Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or _
      '          Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
      '          Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
      '        Me.cmbPorcentajeIva.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      '        Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
      '    End If
      'End If

      Me._productoLoteTemporal = New Entidades.VentaProductoLote()
      Me._productoLoteTemporal.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

      Me.txtCantidad.Focus()
      Me.txtCantidad.SelectAll()

      'Controla multiples Ivas en producto
      'If dr.Cells("Alicuota2").Value.ToString() <> Nothing Then
      '    Me.cmbPorcentajeIva.Enabled = True
      '    'Me._publicos.CargaComboImpuestos(Me.cmbPorcentajeIva)
      'End If

   End Sub



   Private Sub CargarProductoCompleto(dr As DataGridViewRow)

      Try
         _cargandoProductoDesdeCompleto = True

         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Dim Prod As Entidades.Producto

         Prod = oProductos.GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         Dim ordProdProducto As Entidades.OrdenProduccionProducto = DirectCast(dr.DataBoundItem, Entidades.OrdenProduccionProducto)

         If ordProdProducto.PedidoEstadoQueOrigino.Count > 0 Then
            Throw New Exception("Esta línea fue generada desde un pedido. No es posible modificarla.")
         End If

         If _opProductosFormulas.ContainsKey(ordProdProducto) Then
            _opProductosFormulasActual = _opProductosFormulas(ordProdProducto)
         End If

         Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

         'Llamo al evento para cargar el objeto "FilaDevuelta" validado luego al insertar el producto.
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")
         Me.bscCodigoProducto2.PresionarBoton()

         If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
            'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
            Me.bscProducto2.Text = dr.Cells("ProductoDesc").Value.ToString()
         End If

         'NO hace falta, el "PresionarBoton" llama a "CargarProducto" y lo asigna.
         ''Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
         'Me.txtStock.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("Stock").Value.ToString()
         'Me.txtStock.Tag = Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("AfectaStock").Value.ToString())

         cmbFormula.SelectedValue = ordProdProducto.IdFormula
         cmbProcesoProductivo.SelectedIndex = -1
         _cargandoProductoDesdeCompleto = False
         cmbFormula.SelectedValue = ordProdProducto.IdFormula
         cmbProcesoProductivo.SelectedValue = ordProdProducto.IdProcesoProductivo
         txtProductoLargoExtAlto.Text = ordProdProducto.LargoExtAlto.ToString(_formatoCantidades)
         txtProductoAnchoIntBase.Text = ordProdProducto.AnchoIntBase.ToString(_formatoCantidades)

         txtProductoArchitrave.Text = ordProdProducto.Architrave.ToString(_formatoCantidades)
         cmbProductoProduccionModeloForma.SelectedValue = ordProdProducto.IdProduccionModeloForma

         If Not _calculaPreciosSegunFormula OrElse _opProductosFormulasActual Is Nothing Then
            Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), Me._valorRedondeo).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
         End If

         Me.txtCantidad.Text = dr.Cells("Cantidad").Value.ToString()
         Me.cmbPorcentajeIva.Text = dr.Cells("AlicuotaImpuesto").Value.ToString()
         Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
         If Decimal.Parse(dr.Cells("Precio").Value.ToString()) <> 0 Then
            Me.txtDescRecPorc1.Text = Decimal.Parse(dr.Cells("DescuentoRecargoPorc").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
            Me.txtDescRecPorc2.Text = Decimal.Parse(dr.Cells("DescuentoRecargoPorc2").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
         End If
         Me.txtDescRec.Text = Decimal.Parse(dr.Cells("DescuentoRecargoProducto").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
         Me.txtTotalProducto.Text = Decimal.Parse(dr.Cells("Importe").Value.ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))

         Me.txtTamanio.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("Tamano").Value.ToString()
         Me.txtUM.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("IdUnidadDeMedida").Value.ToString()

         Me.dtpFechaEntregaProd.Value = DateTime.Parse(dr.Cells("FechaEntrega").Value.ToString())

         cmbCriticidad.SelectedValue = ordProdProducto.IdCriticidad
         For Each resp As Entidades.Empleado In cmbResponsable.Items
            If resp.IdEmpleado = ordProdProducto.IdResponsable Then
               cmbResponsable.SelectedItem = resp
               Exit For
            End If
         Next

         '_modificoDescuentos = CBool(dr.Cells("ModificoDescuentos").Value)
         _txtCantidad_prev = Decimal.Parse(dr.Cells("Cantidad").Value.ToString())
      Finally
         _cargandoProductoDesdeCompleto = False
      End Try
   End Sub

   Private Sub CalcularDatosDetalle()

      If Me.cmbCategoriaFiscal.SelectedItem Is Nothing Then Exit Sub

      For Each vPro As Entidades.OrdenProduccionProducto In Me._ordenesProduccionProductos

         vPro.DescRecGeneral = Decimal.Round((vPro.ImporteTotal * Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100), Me._valorRedondeo)

         Me.CalculaValores(vPro.Cantidad, vPro.AlicuotaImpuesto, vPro.ImporteImpuestoInterno, vPro.Precio,
               vPro.DescuentoRecargoPorc, vPro.DescuentoRecargoPorc2, Decimal.Parse(Me.txtDescRecGralPorc.Text),
               vPro.PrecioNeto, 0, vPro.ImporteImpuesto, vPro.ImporteTotal)

      Next

      Me.dgvProductos.Refresh()
      '     Me.dgvRemitoTransp.Refresh()

      Me.RecalcularSubtotales()
      Me.CalcularTotales()

   End Sub


   Private Sub CargarUnArticulo(linea As Entidades.OrdenProduccionProducto,
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
                                idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                porcentajeIva As Decimal,
                                importeIva As Decimal,
                                precioNeto As Decimal,
                                criticidad As String,
                                fechaEntrega As Date,
                                fechaActualizacion As Date,
                                ImpuestoInterno As Decimal,
                                idFormula As Integer,
                                nombreFormula As String,
                                largoExtAlto As Decimal,
                                anchoIntBase As Decimal,
                                architrave As Decimal,
                                modeloForma As Entidades.ProduccionModeloForma,
                                IdResponsable As Integer,
                                idProcesoProductivo As Long, codigoProcesoProductivo As String, descripcionProcesoProductivo As String)

      With linea
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         '.Producto.IdProducto = idProducto
         .Producto = New Reglas.Productos().GetUno(idProducto)  'Luego uso ciertas caracteristicas (ej: LOTE).
         .Producto.NombreProducto = productoDescripcion   'Piso la descripcion por si tiene habilitado la posibilidad de cambiarlas.
         .DescuentoRecargoPorc = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         .DescuentoRecargoProducto = descuentoRecargo
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
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .IdCriticidad = criticidad
         .FechaEntrega = fechaEntrega
         .IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         .NombreListaPrecios = Me.cmbListaDePrecios.Text
         .FechaActualizacion = fechaActualizacion
         .ImporteImpuestoInterno = ImpuestoInterno
         .IdFormula = idFormula
         .NombreFormula = nombreFormula
         .LargoExtAlto = largoExtAlto
         .AnchoIntBase = anchoIntBase
         .Architrave = architrave
         .ProduccionModeloForma = modeloForma
         .IdResponsable = IdResponsable
         '-- Carga los datos del Proceso Productivo.- -----------------------------------------------------------------------------------
         .IdProcesoProductivo = idProcesoProductivo
         .CodigoProcesoProductivo = codigoProcesoProductivo
         .DescripcionProcesoProductivo = descripcionProcesoProductivo
         If idProcesoProductivo > 0 Then
            .OrdenesProduccionMRP = New Reglas.OrdenesProduccionMRP().CargaOrdenProduccionMRP(idProducto, idProcesoProductivo, cantidad)
         End If
         '-------------------------------------------------------------------------------------------------------------------------------
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
      Dim oLineaDetalle As Entidades.OrdenProduccionProducto = New Entidades.OrdenProduccionProducto()
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
         precioCosto = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("PrecioCosto").Value.ToString())
         precioLista = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscProducto2.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      Else
         precioCosto = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("PrecioCosto").Value.ToString())
         precioLista = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscCodigoProducto2.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      End If

      Dim producto = New Reglas.Productos().GetUno(bscCodigoProducto2.Text)

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
         precioCosto = Decimal.Round(precioCosto / (1 + alicuotaIVA / 100), Me._valorRedondeo)
         precioLista = Decimal.Round(precioLista / (1 + alicuotaIVA / 100), Me._valorRedondeo)
      End If

      '----------------------------------------------------

      If IdMoneda = 2 Then
         precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
         precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
      End If

      'Asigno el nuevo iva (puedo cambiar o no)
      alicuotaIVA = Decimal.Parse(Me.cmbPorcentajeIva.Text)

      'If Me.txtUM.Text <> "" Then
      '   Dim Conversion As Decimal
      '   Dim oUM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
      '   Conversion = oUM.GetUno(Me.txtUM.Text).ConversionAKilos
      '   Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * Decimal.Parse(Me.txtTamanio.Text) * Conversion, 3)
      'End If

      Dim kilosProducto As Decimal = 0
      If bscCodigoProducto2.FilaDevuelta Is Nothing Then
         kilosProducto = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("Kilos").Value.ToString())
      Else
         kilosProducto = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("Kilos").Value.ToString())
      End If
      Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * kilosProducto, 3)


      Dim precioProductoSinIVA As Decimal = Decimal.Parse(Me.txtPrecio.Text.Trim())
      Dim precioProductoConIVA As Decimal = 0

      Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text)

      Dim descRecPorGeneral As Decimal = Decimal.Parse(Me.txtDescRecGralPorc.Text)

      Dim precioNeto As Decimal = 0

      Dim criticidad As String = Me.cmbCriticidad.SelectedValue().ToString()
      Dim fechaEntrega As Date = Me.dtpFechaEntregaProd.Value()

      Dim idFormula As Integer = 0
      Dim nombreFormula As String = String.Empty

      If pnlFormula.Visible And cmbFormula.SelectedIndex > -1 Then
         idFormula = Integer.Parse(Me.cmbFormula.SelectedValue().ToString())
         nombreFormula = cmbFormula.SelectedText
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

      Dim largoExtAlto As Decimal = Decimal.Parse(txtProductoLargoExtAlto.Text)
      Dim anchoIntBase As Decimal = Decimal.Parse(txtProductoAnchoIntBase.Text)

      Dim IdResponable As Integer = DirectCast(cmbResponsable.SelectedItem, Entidades.Empleado).IdEmpleado

      Me._numeroOrden += 1

      '--------------------------------------------------------------------------------
      Dim idProcesoP As Integer = 0
      Dim nombreProcesoP As String = String.Empty

      If pnlProcesoProductivo.Visible And cmbProcesoProductivo.SelectedIndex > -1 Then
         idProcesoP = Integer.Parse(Me.cmbProcesoProductivo.SelectedValue().ToString())
         oLineaDetalle.IdProcesoProductivo = idProcesoP

         nombreProcesoP = cmbProcesoProductivo.Text
         oLineaDetalle.DescripcionProcesoProductivo = nombreProcesoP
         'txtCosto.Text = precioCosto.ToString
      End If





      'ingreso los valores del Lote '.... por ahora solo de hace Nota de Credito
      'If Me._productoLoteTemporal.Producto.Lote And _
      '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> 0 Then

      '    'Si es NCRE , valido fechas.. sino.. que exista
      '    If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock > 0 Then

      '        'En caso de NCRED no debe seleccionarlo... debe crearlo.
      '        'Dim idL As SeleccionDeLote = New SeleccionDeLote(Me.bscCodigoProducto2.Text, Decimal.Parse(Me.txtCantidad.Text))
      '        Dim idL As IngresoDeLote = New IngresoDeLote()

      '        If idL.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      '            MessageBox.Show("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '            Me.btnInsertar.Focus()
      '            Exit Sub
      '        End If

      '        'Controlar la fecha de la factura con la fecha de vencimiento del lote
      '        If idL.dtpFechaVencimiento.Value.Date = Me.dtpFecha.Value.Date Then
      '            If MessageBox.Show("La fecha del lote es igual a la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
      '                Exit Sub
      '            End If
      '        ElseIf idL.dtpFechaVencimiento.Value.Date < Me.dtpFecha.Value.Date Then
      '            If MessageBox.Show("La fecha del lote es menor que la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
      '                Exit Sub
      '            End If
      '        End If

      '        Me._productoLoteTemporal.FechaVencimiento = idL.dtpFechaVencimiento.Value

      '        Me._productoLoteTemporal.IdSucursal = actual.Sucursal.Id
      '        Me._productoLoteTemporal.IdLote = idL.txtIdLote.Text.ToUpper()
      '        Me._productoLoteTemporal.Cantidad = Decimal.Parse(Me.txtCantidad.Text)
      '        Me._productoLoteTemporal.Orden = Me._numeroOrden
      '        Me._productosLotes.Add(Me._productoLoteTemporal)

      '        'Valido que Exista
      '    Else

      'Dim oProductoLote As Entidades.ProductoLote
      'oProductoLote = New Reglas.ProductosLotes().GetUno(idL.txtIdLote.Text.ToUpper(), actual.Sucursal.Id, Me.bscCodigoProducto2.Text)

      'Dim DispProdLotes As Decimal
      '##############ver que hago con los lotes????

      'DispProdLotes = New Reglas.ProductosLotes().GetDisponiblePorProducto(actual.Sucursal.Id, Me.bscCodigoProducto2.Text)

      'If DispProdLotes = 0 Then
      '    MessageBox.Show("No existen Lotes para el Producto seleccionado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '    Exit Sub
      'End If

      'If DispProdLotes < Decimal.Parse(Me.txtCantidad.Text) Then
      '    MessageBox.Show("El Producto tiene en Stock " & DispProdLotes.ToString() & " quedaría en Cantidad Negativa, No es posible con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '    Exit Sub
      'End If

      ''Le pongo la fecha del Lote original
      'Me._productoLoteTemporal.FechaVencimiento = oProductoLote.FechaVencimiento.Date

      '   End If

      ' End If

      '--------------------------------------------------------------------------------

      Dim impuestoInterno As Decimal = Decimal.Round(Decimal.Parse(Me.txtImpuestosInternos.Text) * cantidad, 2)
      Me.CalculaValores(cantidad, alicuotaIVA, impuestoInterno, precioProductoSinIVA, descRecPorc1, descRecPorc2, descRecPorGeneral,
                        precioNeto, importeBruto, importeIva, importeTotal)

      Me.CargarUnArticulo(oLineaDetalle,
                          Me.bscCodigoProducto2.Text,
                          Me.bscProducto2.Text,
                          descRecPorc1,
                          descRecPorc2,
                          descRecargo,
                          precioProductoSinIVA,
                          cantidad,
                          importeTotal,
                          stock,
                          precioCosto,
                          precioLista,
                          Kilos,
                          Me._tipoImpuestoIVA,
                          alicuotaIVA,
                          importeIva,
                          precioNeto,
                          criticidad,
                          fechaEntrega,
                          Me.dtpFechaActPrecios.Value,
                          impuestoInterno,
                          idFormula,
                          nombreFormula,
                          largoExtAlto,
                          anchoIntBase,
                          txtProductoArchitrave.ValorNumericoPorDefecto(0D), cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma),
                          IdResponable,
                          idProcesoProductivo, codigoProcesoProductivo, descripcionProcesoProductivo)

      'Selecciono los nros. de serie SOLO si el producto permite
      If oLineaDetalle.Producto.NroSerie Then
         Dim nrosSerie As DataTable
         Dim onrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()
         '-- REQ-32489.- -----------------------------------------------------------------------------------------------
         nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, producto.IdDeposito, producto.IdUbicacion, bscCodigoProducto2.Text)

         Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidad.Text), 0).ToString())
         Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, oLineaDetalle.Producto, nrosSerie)
         If sel.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie debe seleccionar los numeros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnInsertar.Focus()
            Exit Sub
         Else
            For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
               oLineaDetalle.Producto.NrosSeries.Add(ns)
            Next
         End If
      End If
      '--
      If _ordenesProduccionProductos.Count > 0 Then
         With oLineaDetalle
            .IdSucursalPedido = _ordenesProduccionProductos(0).IdSucursalPedido
            .IdTipoComprobantePedido = _ordenesProduccionProductos(0).IdTipoComprobantePedido
            .LetraPedido = _ordenesProduccionProductos(0).LetraPedido
            .CentroEmisorPedido = _ordenesProduccionProductos(0).CentroEmisorPedido
            .NumeroPedido = _ordenesProduccionProductos(0).NumeroPedido
            .OrdenPedido = _ordenesProduccionProductos(0).OrdenPedido
            .IdProductoPedido = _ordenesProduccionProductos(0).IdProductoPedido
         End With
      End If
      '--
      oLineaDetalle.Orden = Me._numeroOrden
      Me._ordenesProduccionProductos.Add(oLineaDetalle)

      If _opProductosFormulas.ContainsKey(oLineaDetalle) Then
         _opProductosFormulas.Add(oLineaDetalle, _opProductosFormulasActual)
      Else
         _opProductosFormulas(oLineaDetalle) = _opProductosFormulasActual
      End If
      _opProductosFormulasActual = Nothing

      Me.dgvProductos.DataSource = Me._ordenesProduccionProductos.ToArray()
      AjustarColumnasGrilla()
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
      If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) Then
         importeBruto = Decimal.Round((importeBruto - impuestoInterno) / (1 + alicuotaIVA / 100), Me._valorRedondeo)
         importeNeto = Decimal.Round((importeNeto - impuestoInterno) / (1 + alicuotaIVA / 100), Me._valorRedondeo)
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
         If vi.Alicuota = alicuotaIVA Then
            vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA
            vi.Bruto += importeBruto      'precioProducto * cantidad
            vi.Neto += importeNeto   'importeTotal
            vi.Importe += importeIva
            vi.Total += (importeNeto + importeIva)
            entro = True
         End If
      Next

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

      If Not entro Then
         Me._subTotales.Add(oLineaImpuestos)
      End If
      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      'Me.CalcularTotalProducto()
      Me.CalcularTotales()
      Me.CalcularDatosDetalle()
      'Me.CalcularTotales()
      Me.OrdenarGrillaProductos()

      Me.tsbGrabar.Enabled = True
      Me.bscCodigoProducto2.Focus()

      Me.LimpiarCamposProductos()
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
      If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
      Else
         precioParaDescuento = precioProducto
      End If

      Dim descRec1 As Decimal = Decimal.Round(precioParaDescuento * descRecPorc1 / 100, Me._valorRedondeo)
      Dim descRec2 As Decimal = Decimal.Round((precioParaDescuento + descRec1) * descRecPorc2 / 100, Me._valorRedondeo)
      Dim descRec As Decimal = Decimal.Round((precioParaDescuento + descRec1 + descRec2) * descRecPorGeneral / 100, Me._valorRedondeo)

      precioNeto = precioProducto + descRec1 + descRec2 + descRec

      importeBruto = (precioProducto + descRec1 + descRec2) * cantidad

      'Lo calcula despues
      'importeTotalProducto = precioNeto * cantidad
      '------------------------------------
      'En Pantalla debe mostrar el total bruto (sin aplicar el descuento General)
      importeTotalProducto = importeBruto

      If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         importeIVA = Decimal.Round(((precioNeto * cantidad) - impuestoInterno) - ((precioNeto * cantidad) - impuestoInterno) / (1 + alicuotaIVASobre100), Me._valorRedondeo)
      Else
         importeIVA = Decimal.Round((precioNeto * cantidad) * alicuotaIVASobre100, Me._valorRedondeo)
      End If

   End Sub





   Private Sub EliminarLineaProducto()

      Dim vpro = dgvProductos.FilaSeleccionada(Of Entidades.OrdenProduccionProducto)()

      If _opProductosFormulas.ContainsKey(vpro) Then
         _opProductosFormulas.Remove(vpro)
      End If

      Me._ordenesProduccionProductos.RemoveAt(Me.dgvProductos.SelectedRows(0).Index)
      Me.dgvProductos.DataSource = Me._ordenesProduccionProductos.ToArray()
      AjustarColumnasGrilla()
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

      Me.RecalcularSubtotales()
      Me.CalcularTotales()

   End Sub

   Private Sub OrdenarGrillaProductos()
      Dim canti As Integer = 0
      With Me.dgvProductos
         .Columns("NrosSerie").DisplayIndex = 0
         .Columns("IdProducto").DisplayIndex = 1
         .Columns("ProductoDesc").DisplayIndex = 2
         .Columns("Cantidad").DisplayIndex = 3
         .Columns("Stock").DisplayIndex = 4
         .Columns("Precio").DisplayIndex = 5
         .Columns("PrecioIVA").DisplayIndex = 6
         .Columns("DescuentoRecargoPorc").DisplayIndex = 7
         .Columns("DescuentoRecargoPorc2").DisplayIndex = 8
         .Columns("PrecioNeto").DisplayIndex = 9
         .Columns("IdTipoImpuesto").DisplayIndex = 10
         .Columns("AlicuotaImpuesto").DisplayIndex = 11
         .Columns("ImporteImpuesto").DisplayIndex = 12
         .Columns("Importe").DisplayIndex = 13

         If Me._clienteE IsNot Nothing AndAlso
            ((Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
             Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos) Then
            .Columns("PrecioIVA").Visible = False
         Else
            .Columns("PrecioIVA").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarPrecioConIVA
         End If

         Dim visible = Reglas.Publicos.DetalleProduccion.OrdProdMostrarVenta
         .Columns("Precio").Visible = visible
         .Columns("PrecioNeto").Visible = visible
         .Columns("DescuentoRecargoPorc").Visible = visible
         .Columns("DescuentoRecargoPorc2").Visible = visible
         .Columns("PrecioNeto").Visible = visible
         .Columns("IdTipoImpuesto").Visible = visible
         .Columns("AlicuotaImpuesto").Visible = visible
         .Columns("ImporteImpuesto").Visible = visible
         .Columns("Importe").Visible = visible

         .Columns("Kilos").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarKilos
         .Columns("Stock").Visible = Reglas.Publicos.Facturacion.FacturacionMostrarStock

         If pnlProcesoProductivo.Visible And cmbProcesoProductivo.SelectedIndex > -1 Then
            .Columns("dgvProductos_verFormula").Visible = False

            .Columns("IdProcesoProductivo").Visible = False
            .Columns("DescripcionProcesoProductivo").DisplayIndex = 14
         End If

         '.Columns("IdSucursalPedido").DisplayIndex = 15
         '.Columns("IdTipoComprobantePedido").DisplayIndex = 16
         '.Columns("LetraPedido").DisplayIndex = 17
         '.Columns("CentroEmisorPedido").DisplayIndex = 18
         '.Columns("NumeroPedido").DisplayIndex = 19
         '.Columns("OrdenPedido").DisplayIndex = 20


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

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)

      Me.btnLimpiarProducto.Enabled = Habilitado

      Me.bscCodigoProducto2.Enabled = Habilitado
      Me.bscProducto2.Enabled = Habilitado
      Me.txtCantidad.Enabled = Habilitado
      Me.txtPrecio.Enabled = Habilitado
      Me.txtDescRecPorc1.Enabled = Habilitado
      Me.txtDescRecPorc2.Enabled = Habilitado
      Me.cmbPorcentajeIva.Enabled = Habilitado

      txtProductoAnchoIntBase.Enabled = Habilitado
      txtProductoLargoExtAlto.Enabled = Habilitado
      txtProductoArchitrave.Enabled = Habilitado
      cmbProductoProduccionModeloForma.Enabled = Habilitado

      cmbFormula.Enabled = Habilitado
      cmbProcesoProductivo.Enabled = Habilitado
      btnEditarFormula.Enabled = cmbFormula.Enabled

      cmbProcesoProductivo.Enabled = Habilitado

      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado
      Me.cmbCriticidad.Enabled = Habilitado
      cmbResponsable.Enabled = Habilitado
      Me.dtpFechaEntregaProd.Enabled = Habilitado

      'Por las que le toque habilitar, es factible que no corresponda
      If Habilitado Then
         Me.cmbPorcentajeIva.Enabled = Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos
      End If

      'If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
      '    If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
      '        Me.cmbPorcentajeIva.Enabled = False
      '    End If
      'End If

   End Sub

   Private Function GetVendedorCombo(id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub RecalcularTodo()

      Try

         If Me._ordenesProduccionProductos IsNot Nothing Then

            'Dim oProductos As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            'Dim pro1 As Entidades.ProductoSucursal

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Dim ProdDT As DataTable


            Dim DescRec1 As Decimal, DescRec2 As Decimal
            Dim PrecioNeto As Decimal

            For Each pro As Entidades.OrdenProduccionProducto In Me._ordenesProduccionProductos

               ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")

               If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then

                  pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString())

               Else

                  pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())

               End If

               'Calculo el Nuevo Descuento/Recargo
               DescRec1 = Decimal.Round((pro.Precio * pro.DescuentoRecargoPorc / 100), Me._valorRedondeo)
               DescRec2 = Decimal.Round(((pro.Precio + DescRec1) * pro.DescuentoRecargoPorc2 / 100), Me._valorRedondeo)

               pro.DescuentoRecargoProducto = (DescRec1 + DescRec2) * pro.Cantidad

               'Calculo el Nuevo Precio Neto
               PrecioNeto = pro.Precio + DescRec1 + DescRec2
               PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), Me._valorRedondeo)

               pro.PrecioNeto = PrecioNeto

               pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargoProducto

            Next

            Me.dgvProductos.DataSource = _ordenesProduccionProductos.ToArray()
            AjustarColumnasGrilla()
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

      If OrdenProduccionAEditar Is Nothing Then
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
         Me.txtNumeroPosible.Text = OrdenProduccionAEditar.NumeroOrdenProduccion.ToString()
      End If

      Me.CargarLineasPermitidas()

      Me.OrdenarGrillaProductos()

      Me.OrdenarSolapas()

   End Sub

   Private Sub CargarLineasPermitidas()

      Dim oComprobanteLetra As Entidades.TipoComprobanteLetra
      oComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno("ORDENPRODUCCION", "X")

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
      Dim Utilidad As Decimal = 0
      Dim impuestoInterno As Decimal = 0

      For Each dr As Entidades.OrdenProduccionProducto In Me._ordenesProduccionProductos

         impuestoInterno = dr.ImporteImpuestoInterno

         Dim precioParaDescuento As Decimal
         If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            precioParaDescuento = dr.Precio - (impuestoInterno / dr.Cantidad)
         Else
            precioParaDescuento = dr.Precio
         End If

         descRec1 = Decimal.Round(precioParaDescuento * dr.DescuentoRecargoPorc / 100, Me._valorRedondeo)
         descRec2 = Decimal.Round((precioParaDescuento + descRec1) * dr.DescuentoRecargoPorc2 / 100, Me._valorRedondeo)

         importeCosto = dr.Costo * dr.Cantidad
         importeBruto = (dr.Precio + descRec1 + descRec2) * dr.Cantidad
         importeNeto = dr.PrecioNeto * dr.Cantidad

         If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            importeBruto = Decimal.Round((importeBruto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
            importeNeto = Decimal.Round((importeNeto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
         End If

         Utilidad += (importeNeto - importeCosto)
         importeNetoTotal += importeNeto

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

      If importeNetoTotal <> 0 Then

         Dim PorcentajeUtilidad As Decimal = Decimal.Round(Utilidad / importeNetoTotal * 100, Me._valorRedondeo)

         ' Me.txtSemaforoRentabilidad.Text = PorcentajeUtilidad.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
         'Dim colo As Color = System.Drawing.Color.FromArgb(New Reglas.SemaforoVentasUtilidades().ColorSemaforo(PorcentajeUtilidad, Entidades.SemaforoVentaUtilidad.TiposSemaforos.RENTABILIDAD))



         '  Me.txtSemaforoRentabilidad.BackColor = colo

         'If colo.ToArgb() = Color.Black.ToArgb() Then
         '    Me.txtSemaforoRentabilidad.ForeColor = Color.White
         'Else
         '    ' Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
         'End If

         'Me.txtSemaforoRentabilidad.Key = Utilidad.ToString()

      Else

         '  Me.txtSemaforoRentabilidad.Text = ""
         ' Me.txtSemaforoRentabilidad.BackColor = Me.txtLetra.BackColor
         ' Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
         '  Me.txtSemaforoRentabilidad.Key = "0"

      End If

   End Sub


   Private Function ProductosConLote() As Integer
      Dim Cantidad As Integer = 0
      For Each vp As Entidades.OrdenProduccionProducto In Me._ordenesProduccionProductos
         If vp.Producto.Lote Then
            Cantidad += 1
         End If
      Next
      Return Cantidad
   End Function

   Private Sub LimpiarDetalle()

      Me._ordenesProduccionProductos = Nothing
      Me._ordenesProduccionProductos = New List(Of Entidades.OrdenProduccionProducto)
      Me.dgvProductos.DataSource = Me._ordenesProduccionProductos.ToArray()
      AjustarColumnasGrilla()
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

   Private Function GetValoresForma(dr As Entidades.OrdenProduccionProducto, incluyaModelo As Boolean) As Entidades.ProduccionFormasVariablesList
      Return GetValoresForma(dr.Espmm,
                             dr.LargoExtAlto,
                             dr.AnchoIntBase,
                             dr.Architrave,
                             If(incluyaModelo, dr.ProduccionModeloForma, Nothing))
   End Function

   Private Function GetValoresForma(forma As Entidades.ProduccionModeloForma) As Entidades.ProduccionFormasVariablesList
      Return GetValoresForma(0, 'txtProductoEspmm.ValorNumericoPorDefecto(0D),
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
         'If _solicitaModificarFormulaLuegoDelProducto Then
         '   'MD-PROD: Cambiar la apertura de la pantalla de edición de formula por la nueva que use la colección de ProductosArbol.
         '   '         También definir la conversión de ProductoArbol a PedidoProductoFormula.
         '   '   Using frm As New FormulasABM()
         '   '      If frm.ShowDialog(bscCodigoProducto2.Text, Integer.Parse(cmbFormula.SelectedValue.ToString()), _pedidosProductosFormulasActual) = Windows.Forms.DialogResult.OK Then
         '   '         _pedidosProductosFormulasActual = frm.Componentes.Copy()
         '   '      End If
         '   '   End Using
         'Else
         Dim forma = cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma)
         Dim _valoresFormulas = GetValoresForma(forma)
         Dim rEstructuraProducto = New Reglas.EstructuraProductos()
         _opProductosFormulasActual = rEstructuraProducto.CreaEstructura(bscCodigoProducto2.Text, idFormula, idListaDePrecios, txtCantidad.ValorNumericoPorDefecto(0D),
                                                                         muestraPrecio:=True, _valoresFormulas, moneda:=Entidades.Moneda.Peso,
                                                                         txtCotizacionDolar.ValorNumericoPorDefecto(0D)).FirstOrDefault()
         'End If
      End If
   End Sub

#End Region

   Private Sub MostrarOrdenProduccionEditable()
      Me.cmbTiposComprobantes.SelectedValue = OrdenProduccionAEditar.IdTipoComprobante
      If Not String.IsNullOrWhiteSpace(OrdenProduccionAEditar.IdTipoComprobanteFact) Then
         Me.cmbTiposComprobantesFact.SelectedValue = OrdenProduccionAEditar.IdTipoComprobanteFact
      Else
         Me.cmbTiposComprobantesFact.SelectedIndex = -1
      End If

      txtLetra.Text = OrdenProduccionAEditar.LetraComprobante
      txtNumeroPosible.Text = OrdenProduccionAEditar.NumeroOrdenProduccion.ToString()

      bscCodigoCliente.Text = OrdenProduccionAEditar.Cliente.CodigoCliente.ToString()
      bscCodigoCliente.PresionarBoton()

      cmbRespDistribucion.SelectedValue = OrdenProduccionAEditar.IdTransportista
      cmbCategoriaFiscal.SelectedValue = OrdenProduccionAEditar.CategoriaFiscal.IdCategoriaFiscal
      cmbVendedor.SelectedItem = GetVendedorCombo(OrdenProduccionAEditar.Vendedor.IdEmpleado)
      cmbEstadoVisita.SelectedValue = OrdenProduccionAEditar.IdEstadoVisita

      If OrdenProduccionAEditar.IdFormaPago.HasValue Then
         cmbFormaPago.SelectedValue = OrdenProduccionAEditar.IdFormaPago.Value
      Else
         cmbFormaPago.SelectedIndex = -1
      End If

      If OrdenProduccionAEditar.IdFormaPago.HasValue Then
         cmbFormaPago.SelectedValue = OrdenProduccionAEditar.IdFormaPago.Value
      Else
         cmbFormaPago.SelectedIndex = -1
      End If

      dtpFecha.Value = OrdenProduccionAEditar.Fecha

      txtDescRecGralPorc.Text = OrdenProduccionAEditar.DescuentoRecargoPorc.ToString()
      txtCotizacionDolar.Text = OrdenProduccionAEditar.CotizacionDolar.ToString()

      txtdesc.Text = OrdenProduccionAEditar.Observacion

      If OrdenProduccionAEditar.OrdenesProduccionProductos.Count > 0 Then
         cmbListaDePrecios.SelectedValue = OrdenProduccionAEditar.OrdenesProduccionProductos(0).IdListaPrecios
      End If

      If True Then  ' _solicitaModificarFormulaLuegoDelProducto Then
         Dim oComponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
         'Dim dtComponentes As DataTable
         Dim converter = New Reglas.ProductoArbolConverter()
         For Each pp In OrdenProduccionAEditar.OrdenesProduccionProductos
            If True Then ' pp.Producto.CalculaPreciosSegunFormula Then
               Dim formula = converter.ConvertFromOPProductosFormula(pp.OrdenesProduccionProductosFormulas)

               Dim rEstr = New Reglas.EstructuraProductos()
               rEstr.RecalculaCantidades(formula, GetValoresForma(pp, True))
               _opProductosFormulas.Add(pp, formula)
            End If
         Next
      End If

      Me._ordenesProduccionProductos = OrdenProduccionAEditar.OrdenesProduccionProductos
      Me._ordenesProduccionObservaciones = OrdenProduccionAEditar.OrdenesProduccionObservaciones

      Me.dgvProductos.DataSource = Me._ordenesProduccionProductos.ToArray()
      Me.dgvObservaciones.DataSource = Me._ordenesProduccionObservaciones.ToArray()

      AjustarColumnasGrilla()

      Me.CalcularTotales()
      Me.CalcularDatosDetalle()

      cmbTiposComprobantes.Enabled = False
      txtLetra.Enabled = False
      chbNumeroAutomatico.Enabled = False
      txtNumeroPosible.Enabled = False
      txtNumeroPosible.Text = OrdenProduccionAEditar.NumeroOrdenProduccion.ToString()
      txtOrdenDeCompra.Text = OrdenProduccionAEditar.NumeroOrdenCompra.ToString()

      tsbNuevo.Visible = False
      tsbGrabar.Enabled = True

      If Not Reglas.Publicos.PedidosPermiteFechaEntregaDistintas AndAlso Me._ordenesProduccionProductos.Count > 0 Then
         dtpFechaEntrega.Value = _ordenesProduccionProductos(0).FechaEntrega
      End If

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
            Dim _DescRecGralPorc As Decimal = 0
            _DescRecGralPorc = New CalculosDescuentosRecargos().DescuentoRecargo(_clienteE,
                                                                                 cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).GrabaLibro,
                                                                                 cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante).EsPreElectronico,
                                                                                 cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                                 _ordenesProduccionProductos.Count)
            Me.txtDescRecGralPorc.Text = _DescRecGralPorc.ToString("N" + _decimalesEnTotales.ToString())
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
                  If DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal <> Me._IdCategoriaFiscalOriginal Then
                     Me.cmbCategoriaFiscal.SelectedValue = Me._IdCategoriaFiscalOriginal
                     'Exit Sub
                  End If

               Else

                  'Solo para los comprobantes en negro (los Pre-Eelctronicos son en blanco)
                  If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
                     Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
                  Else
                     'Pudo cambiarla.
                     Me.cmbCategoriaFiscal.SelectedValue = Me._IdCategoriaFiscalOriginal
                  End If

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

            Me.dgvProductos.DataSource = Me._ordenesProduccionProductos.ToArray()
            AjustarColumnasGrilla()
            If Me.dgvProductos.Rows.Count > 0 Then
               Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            End If
            Me.dgvProductos.Refresh()
            Me.OrdenarGrillaProductos()

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
         If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
            Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            e.Value = String.Format("{0:N2}", CDec(row.Cells(Precio.Name).Value))
         Else
            e.Value = String.Format("{0:N2}", (CDec(row.Cells(Precio.Name).Value) * (CDec(row.Cells(AlicuotaImpuesto.Name).Value) + 100) / 100) +
                                              CDec(row.Cells(ImporteImpuestoInterno.Name).Value))
         End If
      End If
   End Sub

   Private Sub chbModificaDescRecargo_CheckedChanged(sender As Object, e As EventArgs) Handles chbModificaDescRecargo.CheckedChanged

      Me.txtDescRecPorc1.ReadOnly = Not Me.chbModificaDescRecargo.Checked
      Me.txtDescRecPorc2.ReadOnly = Not Me.chbModificaDescRecargo.Checked

      If Me.chbModificaDescRecargo.Checked Then
         Me.txtDescRecPorc1.Focus()
         Me.txtDescRecPorc1.SelectAll()
      ElseIf Me.chbModificaPrecio.Checked Then
         Me.txtPrecio.Focus()
         Me.txtPrecio.SelectAll()
      Else
         Me.txtCantidad.Focus()
         Me.txtCantidad.SelectAll()
      End If

   End Sub

   Private Sub AjustarColumnasGrilla()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      For Each col As DataGridViewColumn In dgvProductos.Columns
         col.Visible = _tit.ContainsKey(col.Name)
         If _tit.ContainsKey(col.Name) Then
            If Not String.IsNullOrWhiteSpace(_tit(col.Name)) Then
               col.HeaderText = _tit(col.Name)
            End If
         End If
      Next
   End Sub

   Private Sub OrdenesProduccionClientesV2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         '-- Segun parametro deja de visualizar dichos campos.- ----
         OcultaCampos()
         '----------------------------------------------------------
         If _ConfiguracionImpresoras Then
            MessageBox.Show("No Existe la PC en Configuraciones/Impresoras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub



   Private Sub cmbFormula_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFormula.SelectedValueChanged
      TryCatched(Sub() If Not _cargandoComboFormula And Not _cargandoProductoDesdeCompleto Then CalculaPreciosSegunFormula(True))
   End Sub

   Private Sub btnEditarFormula_Click(sender As Object, e As EventArgs) Handles btnEditarFormula.Click
      TryCatched(
      Sub()
         If _opProductosFormulasActual IsNot Nothing Then
            Using frm = New EstructuraProductos()
               Dim forma = cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma)
               If frm.ShowDialog(Me, _opProductosFormulasActual,
                                 GetValoresForma(forma:=Nothing),
                                 cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma),
                                 txtCotizacionDolar.ValorNumericoPorDefecto(0D),
                                 StateForm.Actualizar) = DialogResult.OK Then
                  _opProductosFormulasActual = frm.GetRaizEditada
               End If
            End Using
         End If
      End Sub)
   End Sub

   Private Sub txtProductoAnchoIntBase_Leave(sender As Object, e As EventArgs) Handles txtProductoAnchoIntBase.Leave, txtProductoLargoExtAlto.Leave, txtProductoArchitrave.Leave, cmbProductoProduccionModeloForma.SelectedValueChanged
      TryCatched(Sub() CalculaPreciosSegunFormula(False))
   End Sub

   Private Sub cmbProductoProduccionModeloForma_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProductoProduccionModeloForma.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            txtPrecio.Focus()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            btnInsertar.Select()
         End If
      End If
   End Sub

   Private Sub txtProductoArchitrave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoArchitrave.KeyDown
      If e.KeyCode = Keys.Enter Then
         If cmbProductoProduccionModeloForma.Enabled AndAlso cmbProductoProduccionModeloForma.Visible Then
            cmbProductoProduccionModeloForma.Focus()

         ElseIf Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            txtPrecio.Focus()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            btnInsertar.Select()
         End If
      End If
   End Sub

   Private Sub txtProductoLargoExtAlto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoLargoExtAlto.KeyDown
      If e.KeyCode = Keys.Enter Then
         If txtProductoArchitrave.Enabled AndAlso txtProductoArchitrave.Visible Then
            txtProductoArchitrave.Focus()
         ElseIf cmbProductoProduccionModeloForma.Enabled AndAlso cmbProductoProduccionModeloForma.Visible Then
            cmbProductoProduccionModeloForma.Focus()

         ElseIf Me.chbModificaPrecio.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            txtPrecio.Focus()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            btnInsertar.Select()
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
            txtPrecio.Focus()
         ElseIf Me.chbModificaDescRecargo.Checked Or Decimal.Parse(Me.txtPrecio.Text) = 0 Then
            Me.txtDescRecPorc1.Focus()
         Else
            btnInsertar.Select()
         End If
      End If
   End Sub


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
         'Dim rProductoComponente As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
         ''MD-PROD: Tomar valores nuevos de formulas
         'Dim preciosProducto = rProductoComponente.CalculaPreciosSegunFormula(actual.Sucursal.Id, bscCodigoProducto2.Text, idFormula, idListaDePrecios,
         '                                                                     0, txtProductoLargoExtAlto.ValorNumericoPorDefecto(0D), txtProductoAnchoIntBase.ValorNumericoPorDefecto(0D),
         '                                                                     0, Nothing,
         '                                                                     dtComponentes:=Nothing, cotizacionDolar:=New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)

         Dim rEstructuraProducto = New Reglas.EstructuraProductos()
         Dim forma = cmbProductoProduccionModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma)
         rEstructuraProducto.RecalculaCantidades(_opProductosFormulasActual, GetValoresForma(forma))

         Dim preciosProducto = {_opProductosFormulasActual}.ToList().
                                 ConvertAll(Function(e) New Entidades.PreciosProducto(actual.Sucursal.Id, e.IdProducto, idListaDePrecios) With
                                             {
                                                .PrecioCostoSinIVA = e.CostoSinImpuestos,
                                                .PrecioCostoConIVA = e.CostoConImpuestos,
                                                .PrecioVentaSinIVA = e.PrecioSinImpuestos,
                                                .PrecioVentaConIVA = e.PrecioConImpuestos
                                             }).FirstOrDefault()

         If (Me._clienteE.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
         Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            txtPrecio.Text = preciosProducto.PrecioVentaSinIVA.ToString("N" + _decimalesAMostrar.ToString())
            txtCosto.Text = preciosProducto.PrecioCostoSinIVA.ToString("N" + _decimalesAMostrar.ToString())
            If bscCodigoProducto2.FilaDevuelta IsNot Nothing Then bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value = preciosProducto.PrecioVentaSinIVA
         Else
            txtPrecio.Text = preciosProducto.PrecioVentaConIVA.ToString("N" + _decimalesAMostrar.ToString())
            txtCosto.Text = preciosProducto.PrecioCostoConIVA.ToString("N" + _decimalesAMostrar.ToString())
            If bscCodigoProducto2.FilaDevuelta IsNot Nothing Then bscCodigoProducto2.FilaDevuelta.Cells("PrecioVenta").Value = preciosProducto.PrecioVentaConIVA
         End If

      End If
   End Sub

End Class