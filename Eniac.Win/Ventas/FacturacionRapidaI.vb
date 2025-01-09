Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class FacturacionRapidaI

#Region "Constantes"

   Private Const funcionActual As String = "FacturacionRapidaSuper"
   Private Const funcionSupervisor As String = "FacturacionRapida"

#End Region

#Region "Campos"

   Private _ventasProductos As System.Collections.Generic.List(Of Entidades.VentaProducto)
   Private _subTotales As System.Collections.Generic.List(Of Entidades.VentaImpuesto)
   Private _estado As Estados
   Private _publicos As Publicos
   Private _numeroComprobante As Integer
   Private _clienteE As Entidades.Cliente
   Private _ModificaDetalle As String
   Private _cheques As List(Of Entidades.Cheque)
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
   Private _productosNrosSeries As List(Of Entidades.ProductoNroSerie)
   Private _numeroOrden As Integer
   Private _modalidad As Modalidades
   Private _codigoBarrasCompleto As String
   Private _valorRedondeo As Integer = 4
   Private _decimalesAMostrar As Integer = 2
   Private _idCajaPorDefecto As Integer
   Private _fc As FacturacionComunes

   Private _cfiscal As ImpresionFiscal

#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

   Private Enum Modalidades
      NORMAL
      PESO
   End Enum

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         'Seguridad de la Lista de Precios
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         Me.cmbListaDePrecios.Enabled = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "FacturacionV2", "Facturacion-ListaDePrecios")

         'Seguridad del Descuento/Recargo General
         Me.txtDescRecGralPorc.ReadOnly = Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes", "Clientes-DescRecGeneralPorc")
         '---------------------------------------

         Me._publicos = New Publicos()
         Me._fc = New FacturacionComunes()

         Me._publicos.CargaComboTipoDocumento(Me.cmbTipoDoc)
         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "VENTAS", , , "SI", True)
         Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)
         Me._publicos.CargaComboImpuestos(Me.cmbPorcentajeIva)
         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True
         Me._publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, blnMiraUsuario, blnMiraPC)

         'si tiene mas de 1 caja asignada tiene que seleccionar cual es la por defecto
         If Me.cmbCajas.Items.Count > 1 Then
            Dim cd As SeleccionCajaDefecto = New SeleccionCajaDefecto()
            cd.ShowDialog()
            Me._idCajaPorDefecto = cd.IdCaja
         Else
            'si solo tiene una caja se la seteo
            Me._idCajaPorDefecto = Int32.Parse(Me.cmbCajas.SelectedValue.ToString())
         End If

         Me.SeteaDetalles()

         Me._estaCargando = False

         Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)

         If Publicos.ProductoUtilizaCantidadesEnteras Then
            Me.txtCantidad.Formato = "##,##0"
            'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         End If

         Me._modalidad = Modalidades.NORMAL
         Me.PreparaFormatosControles()

         Me.Nuevo()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)

      'Pido la clave de autorizacion si tiene productos.
      If Me.dgvProductos.RowCount > 0 Then
         If Not Me.PuedoCancelarVenta() Then
            e.Cancel = True
         End If
      End If
   End Sub

#End Region

#Region "Eventos"

   Private Sub Facturacion_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F2
            Me.tsbNuevo.PerformClick()
         Case Keys.F4
            If Me.tsbGrabar.Enabled Then
               Me.tsbGrabar.PerformClick()
            End If
         Case Keys.F8
            Me.tbcDetalle.SelectedTab = Me.tbpProductos
            Me.txtCantidad.Focus()
         Case Keys.F9
            Me.tbcDetalle.SelectedTab = Me.tbpProductos
            Me.bscCodigoProducto.Focus()
         Case Keys.F11
            If Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
               Me.tbcDetalle.SelectedTab = Me.tbpPagos
            End If
         Case Keys.F12
            Me.tbcDetalle.SelectedTab = Me.tbpTotales
            Me.txtDescRecGralPorc.Focus()
         Case Keys.G
            If e.Control Then
               'Voy a la ultima posicion, al tomar el foco suele posicionarse primero y engaña la vision.
               If Me.dgvProductos.RowCount > 0 Then
                  Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
                  Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
               End If
               Me.dgvProductos.Focus()
            End If
         Case Keys.Escape
            Me.btnLimpiarProducto.PerformClick()
         Case Keys.Add
            If e.Control Then
               Me.btnInsertar.PerformClick()
            End If
         Case Keys.L
            If e.Control Then
               Me.cmbListaDePrecios.Focus()
            End If
         Case Keys.T
            If e.Control Then
               Me.cmbTiposComprobantes.Focus()
            End If
         Case Else
      End Select

   End Sub

   Private Sub txtImporteCheque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporteCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTitularCheque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTitularCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaCobro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaCobro.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaEmision_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaEmision.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtCodPostalCheque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPostalCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtSucursalBanco_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSucursalBanco.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNroCheque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub bscBancos_BuscadorClick() Handles bscBancos.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscBancos)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscBancos.Datos = oBanco.GetFiltradoPorNombre(Me.bscBancos.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscBancos_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscBancos.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
            Me.txtNroCheque.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Nuevo()
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

   Private Sub txtTickes_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTickets.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTickets_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTickets.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEfectivo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEfectivo.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtEfectivo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEfectivo.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
      Try
         If Me.PuedoCancelarVenta() Then
            Me.Nuevo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos(Me.bscCodigoProducto)
         Dim codProd As String = String.Empty
         Me._codigoBarrasCompleto = Me.bscCodigoProducto.Text.Trim()

         codProd = Me.bscCodigoProducto.Text.Trim()

         Dim dt As DataTable
         dt = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")

         If dt.Rows.Count > 0 Then
            Me._modalidad = Modalidades.NORMAL
         Else
            codProd = Me.GetCodigoModalidadPeso()
            dt = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , Modalidades.PESO.ToString())
            If dt.Rows.Count > 0 Then
               Me._modalidad = Modalidades.PESO
            End If
         End If
         Me.bscCodigoProducto.Datos = dt
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnInsertar.PerformClick()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos(Me.bscProducto)
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnInsertar.PerformClick()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtDescRecGralPorc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescRecGralPorc.GotFocus
      Me.txtDescRecGralPorc.SelectAll()
   End Sub

   Private Sub txtDescRecGralPorc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescRecGralPorc.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtDescRecGral.Focus()
      End If
   End Sub

   Private Sub txtDescRecGralPorc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescRecGralPorc.Leave
      Try
         Me.CalcularDatosDetalle()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.GrabarComprobante()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         Me.tsbGrabar.Enabled = True
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorTipoYNroDocumento(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Nuevo()
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Nuevo()
      End Try
   End Sub

   Private Sub llbCliente_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked

      Try
         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then

            Dim clie As Eniac.Entidades.Cliente = New Eniac.Entidades.Cliente

            clie = New Eniac.Reglas.Clientes().GetUno(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)
            clie.Usuario = actual.Nombre

            Dim PantCliente As ClientesDetalle = New ClientesDetalle(clie)
            PantCliente.StateForm = Eniac.Win.StateForm.Actualizar
            PantCliente.CierraAutomaticamente = True
            PantCliente.ShowDialog()
            'If PantCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '   Me.bscCodigoCliente.Text = PantCliente.txtIDXXXX.Text
            '   Me.bscCodigoCliente.PresionarBoton()
            'End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub txtPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnInsertar.Focus()
         Me.btnInsertar.PerformClick()
      End If
   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      Try
         If Me.ValidarInsertaProducto() Then
            Me.InsertarProducto()
            Me.bscCodigoProducto.Focus()
            If Me._ModificaDetalle <> "TODO" Then
               Me.CambiarEstadoControlesDetalle(False)
            End If
            'Me.CargarCantidadItems()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.PuedoCancelarVenta() Then
            If Me.dgvProductos.SelectedRows.Count > 0 Then
               If MessageBox.Show("Esta seguro de eliminar el producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  Me.EliminarLineaProducto()
               End If
               'Me.CargarCantidadItems()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPrecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecio.LostFocus
      Try
         If Me.txtPrecio.Text.Trim().Length = 0 Then
            Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
         End If
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.LostFocus
      Try
         If Me.txtCantidad.Text.Trim().Length = 0 Then
            Me.txtCantidad.Text = "1." + New String("0"c, Me._decimalesAMostrar)
         Else
            If Me.txtPrecio.Text = "-" Then
               Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
            End If
         End If
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         'Me.bscCodigoProducto.Focus()
         Me.PresionarTab(e)
      End If
   End Sub

   Private Sub cmbPorcentajeIva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPorcentajeIva.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.PresionarTab(e)
      End If
   End Sub

   Private Sub cmbPorcentajeIva_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPorcentajeIva.SelectedIndexChanged
      Try
         If Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing And Me.cmbPorcentajeIva.Tag IsNot Nothing Then
            If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And _
               Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Dim actualPrecio As Decimal = Decimal.Parse(Me.txtPrecio.Tag.ToString())
               actualPrecio = Decimal.Round(actualPrecio / (1 + (Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()) / 100)), Me._valorRedondeo)
               actualPrecio = Decimal.Round(actualPrecio * (1 + (Decimal.Parse(Me.cmbPorcentajeIva.Text) / 100)), Me._valorRedondeo)
               Me.txtPrecio.Text = actualPrecio.ToString("0." + New String("0"c, Me._decimalesAMostrar))
               Me.txtPrecio.Tag = actualPrecio.ToString("0." + New String("0"c, Me._decimalesAMostrar))
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTiposComprobantes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTiposComprobantes.KeyDown
      If e.KeyCode = Keys.Enter And Publicos.FacturacionSolicitaComprobante Then
         Me.bscCodigoProducto.Focus()
      Else
         Me.PresionarTab(e)
      End If
   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try

         'cada vez que selecciono un comprobante, pongo la fecha de hoy en el comprobante y si es fiscal no lo permito modificar
         If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
            Exit Sub
         End If

         If Me.cmbTiposComprobantes.Items.Count > 0 And Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then

            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdNotaDebitoChequeRechazado Or _
               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdNotaDebitoChequeRechazado2 Or _
               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
               MessageBox.Show("ATENCION: este comprobante no es posible emitirlo con la Pantalla Rapida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.cmbTiposComprobantes.SelectedIndex = 0 'Esperemos el primero justo no sea un invalido, con -1 da error
               Exit Sub
            End If

            ''Por ahora no puede cambiar la fecha
            'Me.dtpFecha.Enabled = Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
            'If Not Me.dtpFecha.Enabled Then
            Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
            'End If
            ''-----------------------------------

            ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
            ''Habria que hacerlo mas general!
            'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal AndAlso Me._clienteE IsNot Nothing AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit) Then
            '   MessageBox.Show("El Comprobante requiere obligatorio el CUIT pero el Cliente NO lo tiene.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '   'Me.Nuevo()
            '   'Exit Sub
            'End If

            'Si es X es remito, siempre debe tener esa letra, sino dejo la que esta.
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Then
               Me.txtLetra.Text = "X"
            Else
               If Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
                  Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
               Else
                  Me.txtLetra.Text = ""
               End If
            End If

            If Me.cmbFormaPago.SelectedIndex >= 0 Then
               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja And DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
                  If Not Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
                     Me.tbcDetalle.TabPages.Add(Me.tbpPagos)
                  End If
               Else
                  If Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
                     Me._cheques.Clear()
                     Me.dgvCheques.DataSource = Me._cheques
                     Me.tbcDetalle.TabPages.Remove(Me.tbpPagos)
                  End If
               End If
            End If

            Me.chbNumeroAutomatico.Checked = True
            Me.chbNumeroAutomatico.Enabled = Publicos.FacturacionModificaNumeroComprobante And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal

            'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
            Me.cmbCategoriaFiscal.Enabled = True
            If Me._clienteE IsNot Nothing Then
               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then

                  'Vuelvo a asignarlo para saber si lo cambio.
                  Me._clienteE = New Reglas.Clientes().GetUno(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)

                  Me.cmbCategoriaFiscal.Enabled = False
                  'Si cambio la categoria... le vuelvo la original
                  If DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal <> Me._clienteE.CategoriaFiscal.IdCategoriaFiscal Then
                     Me.cmbCategoriaFiscal.SelectedValue = Me._clienteE.CategoriaFiscal.IdCategoriaFiscal
                     Exit Sub
                  End If

               End If
            End If
            '-----------------------------------------------------------

         End If

         Me.tbcDetalle.SelectedTab = Me.tbpProductos

         Me.CambiarEstadoControlesDetalle(Me._clienteE IsNot Nothing)

         'Si algun producto es con Lote tengo que limpiar el detalle, porque pudo cambiar de Factura a NCRED o viseversa, y lleva controles
         ' o que afecta stock si a no.
         If Me.ProductosConLote() > 0 Then
            Me.LimpiarDetalle()
         End If

         Me.CargarProximoNumero()

         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            'Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
            'Habria que hacerlo mas general!
            If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal AndAlso Me._clienteE IsNot Nothing AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit) Then
               MessageBox.Show("El Comprobante requiere obligatorio el CUIT pero el Cliente NO lo tiene.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               'Me.Nuevo()
               'Exit Sub
            End If

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
      Me.LimpiarCamposProductos()
      Me.bscCodigoProducto.Focus()
   End Sub

   'Si tiene Precio entra en un bucle y se termina duplicando el producto.
   'Private Sub dgvProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
   '   Try
   '      'limpia los textbox, y demas controles
   '      Me.LimpiarCamposProductos()
   '      'carga el producto seleccionado de la grilla en los textbox 
   '      Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex))
   '      'elimina el producto de la grilla
   '      Me.EliminarLineaProducto()

   '      If Me._ModificaDetalle = "SOLOPRECIOS" Then
   '         Me.txtPrecio.Enabled = True

   '         Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
   '         Me.btnInsertar.Enabled = True
   '         Me.txtPrecio.Focus()
   '      Else
   '         Me.txtCantidad.Focus()
   '         Me.txtCantidad.SelectAll()
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

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

         Me.txtObservacionDetalle.Focus()
         Me.txtObservacionDetalle.SelectAll()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnInsertarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarCheque.Click
      Try
         If (Not Me.bscBancos.FilaDevuelta Is Nothing) Then
            If Me.ValidarInsertarCheques() Then
               Me.InsertarChequesGrilla()
               Me.bscBancos.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCheque.Click
      Try
         If Me.dgvCheques.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaCheques()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbFormaPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbFormaPago.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         If Me.cmbTiposComprobantes.SelectedItem Is Nothing Then
            MessageBox.Show("Falta asignar el tipo de comprobante para una PC en impresoras.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If Me.cmbFormaPago.SelectedIndex <> -1 Then
            If DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).Dias = 0 And _
               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja Then
               If Not Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
                  Me.tbcDetalle.TabPages.Add(Me.tbpPagos)
               End If
            Else
               If Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
                  Me._cheques.Clear()
                  Me.dgvCheques.DataSource = Me._cheques
                  Me.tbcDetalle.TabPages.Remove(Me.tbpPagos)
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         If Me.tbcDetalle.Contains(Me.tbpProductos) Then
            If Me.tbcDetalle.SelectedTab Is Me.tbpProductos Then
               Me.bscCodigoProducto.Focus()
            End If
         End If

         If Me.tbcDetalle.Contains(Me.tbpPagos) Then
            If Me.tbcDetalle.SelectedTab Is Me.tbpPagos Then
               Me.txtEfectivo.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbListaDePrecios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbListaDePrecios.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbListaDePrecios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbListaDePrecios.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         If Publicos.ActualizaPreciosDeVenta Then
            Me.RecalcularTodo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cmbCategoriaFiscal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCategoriaFiscal.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         'Si es X es remito y siempre debe tener esa letra
         If Me.txtLetra.Text <> "X" And Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
            Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
         End If

         If Me._clienteE IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then

            Me._clienteE.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString()))

            'Exento sin IVA. 
            If Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Me.cmbPorcentajeIva.Text = "0." + New String("0"c, Me._decimalesAMostrar)
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
               Me.cmbPorcentajeIva.Enabled = False
            Else
               Me.cmbPorcentajeIva.Enabled = True
            End If

            'Si es un comprobante en blanco no deberia cambiar el IVA del producto
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
               Me.cmbPorcentajeIva.Enabled = False
            End If

            Me.RecalcularTodo()
            Me.LimpiarCamposProductos()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cmbVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbVendedor.KeyDown

      If e.KeyCode = Keys.Enter And Publicos.FacturacionSolicitaVendedor Then
         If Publicos.FacturacionSolicitaComprobante Then
            Me.cmbTiposComprobantes.Focus()
         Else
            Me.bscCodigoProducto.Focus()
         End If
      Else
         Me.PresionarTab(e)
      End If

   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      Me.txtNumeroPosible.ReadOnly = chbNumeroAutomatico.Checked
   End Sub

   Private Sub btnInsertarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarObservacion.Click
      Try
         If Me.txtObservacionDetalle.Text <> "" Then
            If Me.ValidarInsertaObservacion() Then
               Me.InsertarObservacion()
               Me.txtObservacionDetalle.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionIVA_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercepcionIVA.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionIVA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionIVA.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionIIBB.Focus()
      End If
   End Sub

   Private Sub txtPercepcionIIBB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionIIBB.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionGanancias.Focus()
      End If
   End Sub

   Private Sub txtPercepcionIIBB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercepcionIIBB.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercepcionGanancias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionGanancias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionVarias.Focus()
      End If
   End Sub

   Private Sub txtPercepcionVarias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercepcionVarias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPercepcionVarias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercepcionVarias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtTotalPercepcion.Focus()
      End If
   End Sub

   Private Sub dgvProductos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvProductos.KeyUp
      If Me.dgvProductos.SelectedRows.Count > 0 Then
         'Control y la tecla "-" de un teclado o nobebook.
         If e.Control And (e.KeyCode = Keys.Subtract Or e.KeyCode = Keys.OemMinus) Then
            Me.btnEliminar.PerformClick()
            Me.dgvProductos.Focus()
         End If
      End If
   End Sub

   Private Sub dgvProductos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvProductos.SelectionChanged
      Try
         If Me.dgvProductos.SelectedRows.Count > 0 And Me.dgvProductos.Focused Then
            Me.CargarFoto(Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value.ToString.Trim(), Decimal.Parse(Me.dgvProductos.SelectedRows(0).Cells("Precio").Value.ToString()))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Function PuedoCancelarVenta() As Boolean
      Return BaseSeguridad.ControloPermisos(Eniac.Entidades.Usuario.Actual.Sucursal.Id, Eniac.Ayudantes.Common.usuario, funcionActual, funcionSupervisor)
   End Function

   Private Sub PreparaFormatosControles()
      Me.txtCantidad.Formato = "#0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPrecio.Formato = "##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalProducto.Formato = "##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtKilos.Formato = "##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalBruto.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDescRecGral.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalNeto.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalImpuestos.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalPercepcion.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalSubtotales.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      'columnas grillas
      Me.Precio.DefaultCellStyle.Format = "N" + Me._decimalesAMostrar.ToString()
      Me.Importe.DefaultCellStyle.Format = "N" + Me._decimalesAMostrar.ToString()
   End Sub

   Private Function GetCodigoModalidadPeso() As String
      If Me._codigoBarrasCompleto.Length = 13 Then
         Dim num As Integer = 0
         Integer.TryParse(Me._codigoBarrasCompleto.Substring(1, 6), num)
         Return num.ToString()
      Else
         Return Me._codigoBarrasCompleto
      End If
   End Function

   Private Function GetPrecioModalidadPeso() As Decimal
      If Me._codigoBarrasCompleto.Length = 13 Then
         Return Decimal.Parse(Me._codigoBarrasCompleto.Substring(7, 5).Insert(3, "."))
      Else
         Return 0
      End If
   End Function

   Private Sub CargarDatosBancos(ByVal dr As DataGridViewRow)
      Me.bscBancos.Text = dr.Cells("NombreBanco").Value.ToString()
   End Sub

   Private Sub EliminarLineaCheques()
      Me._cheques.RemoveAt(Me.dgvCheques.SelectedRows(0).Index)

      Me.dgvCheques.DataSource = Me._cheques.ToArray()

      Me.CalcularPagos()
   End Sub

   Private Sub CalcularPagos()

      Dim pago As Decimal = 0

      For i As Integer = 0 To Me._cheques.Count - 1
         pago += Me._cheques(i).Importe
      Next

      If Me.txtTarjetas.Text.Length = 0 Then
         Me.txtTarjetas.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      End If
      If Me.txtTickets.Text.Length = 0 Then
         Me.txtTickets.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      End If
      If Me.txtEfectivo.Text.Length = 0 Then
         Me.txtEfectivo.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      End If

      pago = Math.Round(pago, Me._valorRedondeo) + Decimal.Parse(Me.txtEfectivo.Text) + Decimal.Parse(Me.txtTickets.Text) + Decimal.Parse(Me.txtTarjetas.Text)

      Me.txtTotalPago.Text = pago.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))

   End Sub

   Private Sub LimpiarCamposCheques()
      Me.bscBancos.Text = ""
      Me.bscBancos.FilaDevuelta = Nothing
      Me.dtpFechaCobro.Value = Date.Now
      Me.dtpFechaEmision.Value = Date.Now
      Me.txtImporteCheque.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtNroCheque.Text = "0"
      Me.txtCodPostalCheque.Text = "0"
      Me.txtSucursalBanco.Text = "0"
      Me.txtTitularCheque.Text = ""
   End Sub

   Private Function ValidarComprobante() As Boolean

      Dim sistema As Entidades.Sistema = Publicos.GetSistema()

      If DateDiff(DateInterval.Day, Me.dtpFecha.Value, sistema.FechaVencimiento) < 0 Then
         MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpFecha.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
         Dim dt As DataTable = oPF.Get1(Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
         If dt.Rows.Count = 0 Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            Return False
         End If
      End If

      If Me.cmbTipoDoc.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de documento del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTipoDoc.Focus()
         Return False
      End If

      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nro. de Documento del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If Me.bscCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCliente.Focus()
         Return False
      End If

      If Me._ventasProductos.Count = 0 Then
         MessageBox.Show("No se cargo ningún producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tbcDetalle.SelectedTab = Me.tbpProductos
         Me.bscCodigoProducto.Focus()
         Return False
      End If

      If Not Publicos.VentasConProductosEnCero Then
         'verifico que ningun producto tenga precio cero
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            If pro.ImporteTotal = 0 Then
               MessageBox.Show("No puede haber productos con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.tbcDetalle.SelectedTab = Me.tbpProductos
               Me.bscCodigoProducto.Focus()
               Return False
            End If
         Next
      End If

      If Decimal.Parse(Me.txtTotalGeneral.Text) = 0 Then
         MessageBox.Show("No se calcularon los totales de la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tbcDetalle.SelectedTab = Me.tbpProductos
         Me.bscCodigoProducto.Focus()
         Return False
      End If

      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If Me.cmbVendedor.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbVendedor.Focus()
         Return False
      End If

      If Me.cmbFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar la forma de pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbFormaPago.Focus()
         Return False
      End If

      'Si es Nota Credito o Dev. Proforma no puede aceptar cheques. Que lo arregle desde caja.
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores <= 0 And Me.dgvCheques.RowCount > 0 Then
         MessageBox.Show("Este comprobante no esta habilitado para ingresar cheque(s).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas <> "X" Then
         'Valida si el comprobante esta permitido para la letra fiscal
         Dim tip As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         If Not tip.LetraHabilitada(Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text) Then
            MessageBox.Show("Este comprobante no esta habilitado para esta Letra Fiscal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTiposComprobantes.Focus()
            Return False
         End If
      End If

      If Not Me.chbNumeroAutomatico.Checked And Long.Parse(Me.txtNumeroPosible.Text) <= 0 Then
         MessageBox.Show("El Numero de Comprobante digatado es Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroPosible.Focus()
         Return False
      End If


      'Validacion por si invoco comprobantes -------------------------------

      If Me.dgvObservaciones.RowCount > Me._cantMaxItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = Integer.Parse(Me.dgvProductos.RowCount.ToString())

      If LineasDetalle + Me.dgvObservaciones.RowCount > Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.btnEliminar.Focus()
         Return False
      End If
      '-------------------------------------------------------------------

      If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 Then
            If Decimal.Parse(Me.txtSaldoCtaCte.Text) + Decimal.Parse(Me.txtTotalGeneral.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
               If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                  Return False
               End If
            End If
         End If
      End If

      Dim ImporteTope As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteTope
      If ImporteTope > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) > ImporteTope Then
         MessageBox.Show("El Comprobante Superó el Límite Permitido de $ " & ImporteTope.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      Dim ImporteMinimo As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteMinimo
      If ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) < ImporteMinimo Then
         MessageBox.Show("El Comprobante No Alcanzó el Mínimo Requerido de $ " & ImporteMinimo.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      'A Raymundo cada tanto le pasa que no genera el descuento, no dan enter!
      If Decimal.Parse(Me.txtDescRecGralPorc.Text) <> 0 And Decimal.Parse(Me.txtDescRecGral.Text) = 0 Then
         MessageBox.Show("No se calculó el Descuento/Recargo General, por favor de enter para confirmarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDescRecGralPorc.Focus()
         Return False
      End If

      'Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
      'Habria que hacerlo mas general!
      If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal And String.IsNullOrEmpty(Me._clienteE.Cuit) Then
         MessageBox.Show("El Cliente NO tiene CUIT y es obligatorio para este comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      '------- Permitir comprobante con fecha y numeración anterior ---------
      Dim oVN As Reglas.VentasNumeros = New Reglas.VentasNumeros()
      Dim oImpresora As Entidades.Impresora
      Dim CentroEmisor As Short

      oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

      CentroEmisor = oImpresora.CentroEmisor

      Dim FechaComp As Date
      FechaComp = oVN.GetUltimaFecha(actual.Sucursal.IdSucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text, CentroEmisor)

      If Not Publicos.PermitirComprobFechaNumAnterior And Me.dtpFecha.Value.Date < FechaComp Then
         MessageBox.Show("No puede Grabar el Comprobante con una Fecha menor a " & FechaComp.ToString("dd/MM/yyyyy"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False
      End If

      Return True

   End Function

   Private Function EsComprobanteFiscal() As Boolean
      Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
   End Function

   Private Sub GrabarComprobante()

      If Me.ValidarComprobante() Then

         Me.tsbGrabar.Enabled = False

         If Me.tbcDetalle.Contains(Me.tbpPagos) Then
            Me.tbcDetalle.SelectedTab = Me.tbpPagos
         End If

         Dim oFacturacion As Reglas.Ventas = New Reglas.Ventas()
         Dim oVentas As New Entidades.Venta

         With oVentas
            'cargo el comprobante
            .TipoComprobante = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)

            'cargo el cliente ----------
            .Cliente = Me._clienteE

            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)

            .LetraComprobante = Me.txtLetra.Text

            If Not Me.chbNumeroAutomatico.Checked Or (.TipoComprobante.EsFiscal And Not .TipoComprobante.GrabaLibro) Then
               .NumeroComprobante = Long.Parse(Me.txtNumeroPosible.Text)
            End If

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .Fecha = Me.dtpFecha.Value
            If Me.cmbVendedor.SelectedIndex <> -1 Then
               .Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
            End If
            If Me.cmbFormaPago.SelectedIndex <> -1 Then
               .FormaPago = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago)
            End If
            .Observacion = String.Empty

            .VentasImpuestos = Me._subTotales
            .ImpuestosVarios = Me._fc.ImpuestosVarios

            'cargo valores del comprobante
            .ImporteBruto = Decimal.Parse(Me.txtTotalBruto.Text)
            .DescuentoRecargo = Decimal.Parse(Me.txtDescRecGral.Text)
            .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescRecGralPorc.Text)
            .Subtotal = Decimal.Parse(Me.txtTotalNeto.Text)
            .TotalImpuestos = Decimal.Parse(Me.txtTotalImpuestos.Text) + Decimal.Parse(Me.txtTotalPercepcion.Text)
            .ImporteTotal = Decimal.Parse(Me.txtTotalGeneral.Text)

            .Kilos = Decimal.Parse(Me.txtKilos.Text)

            'cargo la impresora
            '.Impresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal())
            .Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

            'cargo los productos
            .VentasProductos = Me._ventasProductos

            'Cargo los Comprobantes Facturados (tal vez ninguno)
            .Facturables = Nothing

            .IdEstadoComprobante = ""
            .CantidadInvocados = 0

            'cargo el Remito Transportista
            .Bultos = 0
            .ValorDeclarado = 0
            .Transportista = Me._transportistaA
            .NumeroLote = 0

            'cargo las Observaciones
            .VentasObservaciones = Me._ventasObservaciones

            If oVentas.TipoComprobante.AfectaCaja Then
               'controlo el pago que se realiza si no va a la cuenta corriente
               If oVentas.FormaPago.Dias = 0 Then
                  If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
                     If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                        If Not Publicos.FacturacionContadoEsEnPesos AndAlso MessageBox.Show("El pago se realizara totalmente en pesos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                           Me.tbpPagos.Focus()
                           Me.txtEfectivo.Focus()
                           Exit Sub
                        Else
                           Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
                        End If
                     End If
                  Else
                     'si puso algo en pagos, se debe controlar que la diferencia este en cero
                     If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                        Me.tbpPagos.Focus()
                        Me.txtEfectivo.Focus()
                        Throw New Exception("El pago debe ser igual al total del comprobante.")
                     End If
                  End If
               End If
            Else
               Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
            End If

            'carga los importes de pagos y cheques
            .Cheques = Me._cheques
            .ImportePesos = Decimal.Parse(Me.txtEfectivo.Text)
            .ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text)
            .ImporteTickets = Decimal.Parse(Me.txtTickets.Text)

            'carga los cheques rechazados
            .ChequesRechazados = Me._chequesRechazados

            'Informe los Productos que tuvieron Lotes.
            .CantidadLotes = 0   'Me.ProductosConLote()    ---- Luego le cargo el correcto segun la seleccion de lotes.

            'cargo los Lotes
            .VentasProductosLotes = Me._productosLotes

            'Cargo la utilidad
            .Utilidad = Decimal.Parse(Me.txtSemaforoRentabilidad.Key)

            .CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text)

            .ComisionVendedor = 0  'Se calcula despues

            'grabo la caja
            If .FormaPago.Dias = 0 Then
               .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
            End If

         End With

         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If oVentas.TipoComprobante.ActualizaCtaCte Then
            If oVentas.FormaPago.Dias > 0 Then
               'si el cliente compro el modulo de cuenta corriente
               If Publicos.TieneModuloCuentaCorrienteClientes Then

                  If Not Publicos.UtilizaCuotasVencimientoCtaCteClientes Then

                     If MessageBox.Show("Confirma enviar el Comprobante a Cuenta Corriente?", Me.Text, MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then
                        'Me.tsbGrabar.Enabled = True
                        Exit Sub
                     End If

                     Dim oCCP As Entidades.CuentaCorrientePago
                     oCCP = New Entidades.CuentaCorrientePago()
                     oCCP.ImporteCuota = Decimal.Parse(Me.txtTotalGeneral.Text)
                     oCCP.SaldoCuota = oCCP.ImporteCuota
                     oCCP.FechaVencimiento = Me.dtpFecha.Value.AddDays(oVentas.FormaPago.Dias)
                     oVentas.CuentaCorriente.Pagos.Add(oCCP)

                  Else

                     Dim cc As CuentaCorriente = New CuentaCorriente(Me.dtpFecha.Value, Decimal.Parse(Me.txtTotalGeneral.Text), oVentas.FormaPago.Dias)
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
                     Else
                        'Me.tsbGrabar.Enabled = True
                        Throw New Exception("Debe ingresar la forma de pago para poder grabar e imprimir.")
                     End If

                  End If

               End If
            End If
         End If

         Dim TextoGrabacion As String = "impreso y grabado."

         'si voy a imprimir en una impresora fiscal, primero imprimo y despues obtengo el nro. de comprobante
         'en otro caso, grabo y despues imprimo

         'Solo Fiscales LEGALES envio antes de grabar, los demas grabo primero.
         If Me.EsComprobanteFiscal() And oVentas.TipoComprobante.GrabaLibro Then
            If oVentas.Impresora.ImprimirLineaALinea Then
               Me._fc.ImpresionFiscal = Me._cfiscal
            End If

            If Me._fc.ImprimirComprobante(oVentas, Me.EsComprobanteFiscal()) Then
               oFacturacion.Insertar(oVentas)
            End If
         Else
            oFacturacion.Insertar(oVentas)

            Dim msg As System.Text.StringBuilder = New System.Text.StringBuilder()
            msg.AppendFormat("{0} Nro. {1}", oVentas.TipoComprobante.Descripcion, oVentas.NumeroComprobante.ToString()).AppendLine()
            msg.AppendFormat("de {0}", Me.bscCliente.Text).AppendLine()

            If oVentas.TipoComprobante.EsElectronico Then
               If Not String.IsNullOrEmpty(oVentas.AFIPCAE.CAE) Then
                  msg.AppendFormat("CAE {0} con vencimiento {1} ", oVentas.AFIPCAE.CAE, oVentas.AFIPCAE.CAEVencimiento.ToString("dd/MM/yyyy")).AppendLine()
               End If
            End If

            'verifica si el tipo de comprobante se puede imprimir, sino no hace nada
            If Me.ImprimeComprobante() Then
               Me._fc.ImprimirComprobante(oVentas, Me.EsComprobanteFiscal())
            Else
               TextoGrabacion = "grabado."
            End If
         End If

         If oVentas.TipoComprobante.AfectaCaja Then

            Dim OfreceCalcularVuelto As String = Publicos.FacturacionOfreceCalcularVuelto

            If OfreceCalcularVuelto <> "NOOFRECER" Then

               If OfreceCalcularVuelto = "OFRECER" Then

                  If MessageBox.Show(oVentas.TipoComprobante.Descripcion & " Numero " & oVentas.NumeroComprobante.ToString() & " del Cliente '" & Me.bscCliente.Text & "' fue " & TextoGrabacion & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter) & "¿ Desea Calcular el Vuelto ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                     Dim oFactCalcularVuelto As FacturacionCalcularVuelto
                     oFactCalcularVuelto = New FacturacionCalcularVuelto(oVentas.ImporteTotal)
                     oFactCalcularVuelto.ShowDialog()
                  End If

               Else

                  Dim oFactCalcularVuelto As FacturacionCalcularVuelto
                  oFactCalcularVuelto = New FacturacionCalcularVuelto(oVentas.ImporteTotal)
                  oFactCalcularVuelto.ShowDialog()

               End If

            Else

               MessageBox.Show(oVentas.TipoComprobante.Descripcion & " Nro. " & oVentas.NumeroComprobante.ToString() & Convert.ToChar(Keys.Enter) & " de " & Me.bscCliente.Text & Convert.ToChar(Keys.Enter) & " fue " & TextoGrabacion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

         End If

         Me.Nuevo()

      End If
   End Sub

   Private Function ImprimeComprobante() As Boolean
      'Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime
      Return Me._imprime
   End Function

   Private Sub SeteaDetalles()
      Me._ventasProductos = New System.Collections.Generic.List(Of Entidades.VentaProducto)
      Me._subTotales = New System.Collections.Generic.List(Of Entidades.VentaImpuesto)
      Me._ventasObservaciones = New List(Of Entidades.VentaObservacion)
      Me._cheques = New List(Of Entidades.Cheque)
      Me._chequesRechazados = New List(Of Entidades.Cheque)
      Me._productosLotes = New List(Of Entidades.VentaProductoLote)()
      Me._productosNrosSeries = New List(Of Entidades.ProductoNroSerie)()
   End Sub

   Private Sub CalcularTotalProducto()
      If Me.txtCantidad.Text = "-" Then
         Me.txtCantidad.Text = "1." + New String("0"c, Me._decimalesAMostrar)
      End If
      Me.txtTotalProducto.Text = ((Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtCantidad.Text))).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
   End Sub

   Private Sub LimpiarCamposProductos()
      Me.bscCodigoProducto.Enabled = True
      Me.bscCodigoProducto.Text = ""
      Me.bscCodigoProducto.FilaDevuelta = Nothing
      Me.bscProducto.Enabled = True
      Me.bscProducto.Text = ""
      Me.bscProducto.FilaDevuelta = Nothing
      Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtStock.Text = "0"
      Me.txtStock.Tag = False
      Me.txtCantidad.Text = "1." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTamanio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtUM.Text = ""
   End Sub

   Private Sub LimpiarCamposObservDetalles()
      Me.txtObservacionDetalle.Text = ""
   End Sub

   Private Sub CalcularTotales()

      Dim bruto As Decimal = 0
      Dim descuento As Decimal = 0
      Dim subTotal As Decimal = 0
      Dim iva As Decimal = 0
      Dim total As Decimal = 0
      Dim totalGeneral As Decimal = 0
      Dim Kilos As Decimal = 0
      Dim percepcionIVA As Decimal = 0
      Dim percepcionIB As Decimal = 0
      Dim percepcionGanancias As Decimal = 0
      Dim percepcionVarias As Decimal = 0
      Dim percepcionTotal As Decimal = 0
      Dim CantItems As Integer = 0

      'If Me.dgvProductos.Rows.Count > 0 Then

      For Each vp As Entidades.VentaProducto In Me._ventasProductos

         Kilos += vp.Kilos

         'Si NO tiene decimales lo sumo, sino solo sumo 1, pensando en productos con kilos (carnes, fiambres, clavos, etc).
         If Decimal.ToInt32(vp.Cantidad) = vp.Cantidad Then
            CantItems += Decimal.ToInt32(vp.Cantidad)
         Else
            CantItems += 1
         End If

      Next

      For Each vi As Entidades.VentaImpuesto In Me._subTotales
         bruto += vi.Bruto
         subTotal += vi.Neto
         iva += vi.Importe
         total += vi.Total
      Next

      percepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
      percepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
      percepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
      percepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)

      percepcionTotal = percepcionIVA + percepcionIB + percepcionGanancias + percepcionVarias

      totalGeneral = total + percepcionTotal

      'End If

      Me.txtTotalPercepcion.Text = percepcionTotal.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalBruto.Text = bruto.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtDescRecGral.Text = (subTotal - bruto).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalNeto.Text = subTotal.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalSubtotales.Text = totalGeneral.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalImpuestos.Text = iva.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtTotalGeneral.Text = totalGeneral.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))

      Me.CalcularDiferenciaDePago()

      Me.txtKilos.Text = Kilos.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))

      Me._fc.CargarRetenciones(Decimal.Parse(Me.txtPercepcionIVA.Text),
                                Decimal.Parse(Me.txtPercepcionIIBB.Text),
                                Decimal.Parse(Me.txtPercepcionGanancias.Text),
                                Decimal.Parse(Me.txtPercepcionVarias.Text))

      Me.txtCantidadProductos.Text = "Cant. de Productos: " + CantItems.ToString()
      Me.txtCantidadItems.Text = "Cantidad de Items: " + Me._ventasProductos.Count.ToString()

      If Me.dgvProductos.Rows.Count > 0 Then
         Me.cmbCategoriaFiscal.Enabled = False
      ElseIf Me.cmbTiposComprobantes.SelectedItem IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then
         'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
         Me.cmbCategoriaFiscal.Enabled = Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro
      End If

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("NroDocumento").Value.ToString()
      Me.cmbTipoDoc.Text = dr.Cells("TipoDocumento").Value.ToString()
      'Me.txtDireccion.Text = dr.Cells("Direccion").Value.ToString()
      'Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()

      Me.txtLimiteDeCredito.Text = dr.Cells("LimiteDeCredito").Value.ToString()

      Me.cmbCategoriaFiscal.SelectedValue = dr.Cells("IdCategoriaFiscal").Value

      'Si es X es remito y siempre debe tener esa letra
      If Me.txtLetra.Text <> "X" Then
         Me.txtLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
      End If

      Me.tbcDetalle.Enabled = True
      Me.bscCliente.Permitido = False
      Me.bscCodigoCliente.Permitido = False
      Me.cmbTipoDoc.Enabled = False

      Dim Vend As Reglas.Empleados = New Reglas.Empleados()
      Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(dr.Cells("TipoDocVendedor").Value.ToString(), dr.Cells("NroDocVendedor").Value.ToString())

      'Asigno al SelectedValue porque la numeracion de las listas, no necesamiente es correlativa y da error.
      Me.cmbListaDePrecios.SelectedValue = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())

      Dim oCliente As Reglas.Clientes = New Reglas.Clientes()
      Me._clienteE = oCliente.GetUno(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)

      If Me._clienteE.IdTipoComprobante <> "" Then

         Me.cmbTiposComprobantes.SelectedValue = Me._clienteE.IdTipoComprobante

         If Me.cmbTiposComprobantes.SelectedIndex = -1 And Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If

      End If

      If Me._clienteE.IdFormasPago <> 0 Then

         Me.cmbFormaPago.SelectedValue = Me._clienteE.IdFormasPago

         If Me.cmbFormaPago.SelectedIndex = -1 And Me.cmbFormaPago.Items.Count > 0 Then
            Me.cmbFormaPago.SelectedIndex = 0
         End If

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
      Me.cmbCategoriaFiscal.Enabled = Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro

      'Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
      'Habria que hacerlo mas general!
      If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal And String.IsNullOrEmpty(Me._clienteE.Cuit) Then
         MessageBox.Show("El Cliente NO tiene CUIT y es obligatorio para este comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         'Me.cmbTiposComprobantes.SelectedIndex = -1
         'Me.cmbTiposComprobantes.Focus()
         Me.Nuevo()
         Exit Sub
      End If

      'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
      If Publicos.FacturacionSolicitaComprobante Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me.cmbTiposComprobantes.Focus()
      End If
      If Publicos.FacturacionSolicitaVendedor Then
         Me.cmbVendedor.SelectedIndex = -1
         Me.cmbVendedor.Focus()
      End If
      If Not Publicos.FacturacionSolicitaComprobante And Not Publicos.FacturacionSolicitaVendedor Then
         Me.bscCodigoProducto.Focus()
      End If

   End Sub

   Private Sub CargarSaldosCtaCte()

      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos

      Dim dt As DataTable

      dt = oCtaCteDet.GetSaldosCtaCte(-1, , , , Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)

      Me.txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      'Me.txtSaldoCtaCteVencido.Text = "0.00"

      If dt.Rows.Count = 1 Then
         Me.txtSaldoCtaCte.Text = Decimal.Parse(dt.Rows(0)("Saldo").ToString()).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
         'If Not String.IsNullOrEmpty(dt.Rows(0)("SaldoVencido").ToString()) Then
         '   Me.txtSaldoCtaCteVencido.Text = Decimal.Parse(dt.Rows(0)("SaldoVencido").ToString()).ToString("##,##0.00")
         'End If
      End If

      If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
         If Decimal.Parse(Me.txtSaldoCtaCte.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
            If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
            End If
         End If
      End If

   End Sub

   Private Sub Nuevo()

      Me.tsbGrabar.Enabled = False
      Me._estado = Estados.Insercion
      'Me.Text = "Facturación"
      Me.cmbTiposComprobantes.Enabled = True
      Me.cmbVendedor.Enabled = True
      Me.cmbFormaPago.Enabled = True
      Me.txtTotalGeneral.Enabled = True
      Me.txtDescRecGral.Enabled = True
      Me.tbcDetalle.SelectedTab = Me.tbpProductos
      Me.tbcDetalle.Enabled = True
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty
      'Me.txtBruto.Enabled = True
      Me.bscCliente.Permitido = True
      Me.bscCodigoCliente.Permitido = True
      Me.cmbTipoDoc.Enabled = True
      Me.cmbTipoDoc.SelectedValue = Publicos.TipoDocumentoCliente()
      Me._clienteE = Nothing

      'Me.dtpFecha.Enabled = True
      'Me.txtObservacion.Text = String.Empty
      Me._ventasProductos.Clear()
      Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
      Me._subTotales.Clear()
      Me.dgvIvas.DataSource = Me._subTotales.ToArray()
      'Me.txtDireccion.Text = String.Empty
      'Me.txtLocalidad.Text = String.Empty
      Me.txtLimiteDeCredito.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtSaldoCtaCte.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      'Me.txtSaldoCtaCteVencido.Text = "0.00"
      'Me.txtBruto.Text = "0.00"
      Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
      Me.txtTotalGeneral.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtKilos.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.bscCodigoProducto.Text = String.Empty
      Me.bscProducto.Text = String.Empty
      Me.txtStock.Text = String.Empty
      Me.txtStock.Tag = False
      Me.txtCantidad.Text = "1." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPrecio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalProducto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTamanio.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtUM.Text = ""
      Me.btnInsertar.Enabled = True
      Me.btnEliminar.Enabled = True
      Me.txtTickets.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtEfectivo.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTarjetas.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalBruto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalNeto.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalSubtotales.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalImpuestos.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPercepcionIVA.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPercepcionIIBB.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPercepcionGanancias.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtPercepcionVarias.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalPercepcion.Text = "0." + New String("0"c, Me._decimalesAMostrar)

      Me.txtLetra.Text = String.Empty

      If Me.cmbTiposComprobantes.Items.Count > 0 Then
         Me.cmbTiposComprobantes.SelectedIndex = -1   'Fuerzo el evento de Changed
         Me.cmbTiposComprobantes.SelectedIndex = 0
      Else
         Me.cmbTiposComprobantes.SelectedIndex = -1
      End If
      If Me.cmbVendedor.Items.Count > 0 Then
         Me.cmbVendedor.SelectedIndex = 0
      Else
         Me.cmbVendedor.SelectedIndex = -1
      End If
      If Me.cmbFormaPago.Items.Count > 0 Then
         Me.cmbFormaPago.SelectedIndex = 0
      Else
         Me.cmbFormaPago.SelectedIndex = -1
      End If

      Me.cmbListaDePrecios.SelectedIndex = 0

      Me.txtDescRecGralPorc.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDescRecGral.Text = "0." + New String("0"c, Me._decimalesAMostrar)

      'Me.txtCategoriaFiscal.Text = String.Empty
      'Me.txtCategoria.Text = String.Empty

      Me.cmbCategoriaFiscal.Enabled = True
      Me.cmbCategoriaFiscal.SelectedIndex = -1

      Me.chbNumeroAutomatico.Checked = True
      Me.chbNumeroAutomatico.Enabled = Publicos.FacturacionModificaNumeroComprobante

      Me.CambiarEstadoControlesDetalle(False)

      Me._ModificaDetalle = "TODO"

      Me.txtTotalPago.Text = "0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDiferencia.Text = "0." + New String("0"c, Me._decimalesAMostrar)

      Me._cheques.Clear()
      Me.dgvCheques.DataSource = Me._cheques
      Me.LimpiarCamposCheques()

      Me._transportistaA = Nothing

      Me._ventasObservaciones.Clear()
      Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()

      Me.txtCantidadProductos.Text = "Cant. de Productos: "
      Me.txtCantidadItems.Text = "Cantidad de Items: "
      Me.txtPrecioMostrar.Text = Me.txtPrecio.Text
      Me.pcbFoto.Image = Nothing

      Me._numeroOrden = 0

      Me.CargarProximoNumero()

      Me.txtSemaforoRentabilidad.BackColor = Me.txtLetra.BackColor
      Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
      Me.txtSemaforoRentabilidad.Text = ""
      Me.txtSemaforoRentabilidad.Key = "0"

      Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("#0." + New String("0"c, Me._decimalesAMostrar))

      Me.cmbCajas.SelectedValue = Me._idCajaPorDefecto

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Focus()

   End Sub

   Private Function ValidarInsertaProducto() As Boolean

      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar un tipo de comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      'Esta Habilitado si permite Modificar la Descripcion.
      If Me.bscProducto.Enabled Then

         If Me.bscCodigoProducto.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Codigo de Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto.Focus()
            Return False
         End If
         If Me.bscProducto.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscProducto.Focus()
            Return False
         End If

         If Not Me.bscCodigoProducto.Selecciono And Not Me.bscProducto.Selecciono And (Me.bscCodigoProducto.Text.Trim.Length = 0 Or Me.bscProducto.Text.Trim.Length = 0) Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto.Focus()
            Return False
         End If

         'Significa que escribo en ambos casos y no dio enter, tiene que al menos buscar.
         If bscCodigoProducto.FilaDevuelta Is Nothing And bscProducto.FilaDevuelta Is Nothing Then
            MessageBox.Show("No eligió un Producto, solo los digito, falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto.Focus()
            Return False
         End If

      Else
         If Not Me.bscCodigoProducto.Selecciono And Not Me.bscProducto.Selecciono Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto.Focus()
            Return False
         End If
      End If

      If Decimal.Parse(Me.txtPrecio.Text) <= 0 And Not Publicos.VentasConProductosEnCero Then
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

      If Me.dgvProductos.RowCount = Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas de Productos para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.btnInsertar.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.
      If Me.dgvProductos.RowCount + Me.dgvObservaciones.RowCount = Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.btnInsertar.Focus()
         Return False
      End If

      '*** Controlo la Facturacion Sin Stock ***

      'PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), ó invoco (no corresponde)
      'los valores posibles para el coeficientestock son 0, 1 y -1

      Dim blnControlarStock As Boolean = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0

      If Decimal.Parse(Me.txtCantidad.Text) > Decimal.Parse(Me.txtStock.Text) And Boolean.Parse(Me.txtStock.Tag.ToString()) And blnControlarStock Then

         If Publicos.FacturarSinStock = "NOPERMITIR" Then
            MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCantidad.Focus()
            Return False

         ElseIf Publicos.FacturarSinStock = "AVISARYPERMITIR" Then
            MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      End If

      '-----------------------------------------

      ''controlo que no se repita el producto ingresado
      'Dim ent As Entidades.VentaProducto
      'For i As Integer = 0 To Me._ventasProductos.Count - 1
      '   ent = Me._ventasProductos(i)
      '   If ent.Producto = Me.bscCodigoProducto.Text Then
      '      If MessageBox.Show("El producto ya esta ingresado en este comprobante. ¿Desea agregar la cantidad al mismo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
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

   Private Function ValidarInsertaObservacion() As Boolean

      If Me.dgvObservaciones.RowCount = Me._cantMaxItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = Integer.Parse(Me.dgvProductos.RowCount.ToString())

      If LineasDetalle + Me.dgvObservaciones.RowCount = Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      Return True

   End Function

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscCodigoProducto.Enabled = False

      Me.bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscProducto.Enabled = Publicos.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

      Me.cmbPorcentajeIva.Text = dr.Cells("Alicuota").Value.ToString()
      Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text

      '----------------------------------------------------------------------------------------------------------------------------------
      Dim PrecioVentaSinIVA As Decimal = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString())
      Dim PrecioVentaConIVA As Decimal = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString())

      'Si el producto pertenece a una Marca que tiene lista de Precios especifica.. vuelvo a tomar los precios.

      Dim dt As DataTable
      dt = New Reglas.ClientesMarcasListasDePrecios().GetUno(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text, Integer.Parse(dr.Cells("IdMarca").Value.ToString()))

      If dt.Rows.Count = 1 Then

         Dim IdListaDePrecio As Integer
         IdListaDePrecio = Integer.Parse(dt.Rows(0)("IdListaPrecios").ToString())

         dt = Nothing
         dt = New Reglas.Productos().GetPorCodigo(Me.bscCodigoProducto.Text, actual.Sucursal.Id, IdListaDePrecio, "VENTAS")

         PrecioVentaSinIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaSinIVA").ToString())
         PrecioVentaConIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaConIVA").ToString())

      End If
      '----------------------------------------------------------------------------------------------------------------------------------

      If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
         PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
         PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
      End If

      'Si leyo el Precio de la Etiqueta lo asigno.
      If Me._modalidad = Modalidades.PESO And PrecioVentaConIVA = 0 Then
         PrecioVentaConIVA = Me.GetPrecioModalidadPeso()
         PrecioVentaSinIVA = Decimal.Round(PrecioVentaConIVA / (1 + Decimal.Parse(Me.cmbPorcentajeIva.Text) / 100), Me._valorRedondeo)
      End If

      If (Me._clienteE.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or _
       Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
         Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
         Me.txtPrecio.Tag = Me.txtPrecio.Text
      Else
         'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
         Me.txtPrecio.Text = PrecioVentaConIVA.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
         Me.txtPrecio.Tag = Me.txtPrecio.Text
      End If

      Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      Me.txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())

      Me.txtTamanio.Text = dr.Cells("Tamano").Value.ToString()
      Me.txtUM.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
      'Me.txtCantidad.Text = "1.00"

      '---------------------------------------------------------------------------

      'Exento sin IVA. 
      If Me.cmbTiposComprobantes.SelectedIndex <> -1 Then
         If Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or _
               Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
               Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
            Me.cmbPorcentajeIva.Text = "0." + New String("0"c, Me._decimalesAMostrar)
            Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
         End If
      End If

      Me._productoLoteTemporal = New Entidades.VentaProductoLote()
      Me._productoLoteTemporal.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

      Me.CargarFoto(dr.Cells("IdProducto").Value.ToString.Trim(), Decimal.Parse(Me.txtPrecio.Text))

      'Lo pase arriba pero trabajando sobre el precio, dejo cantidad en 1.
      'If Me._modalidad = Modalidades.PESO Then
      'If Decimal.Parse(Me.txtPrecio.Text) <> 0 Then
      '   Me.txtCantidad.Text = Decimal.Round(Me.GetPrecioModalidadPeso() / Decimal.Parse(Me.txtPrecio.Text), Me._valorRedondeo).ToString("0." + New String("0"c, Me._decimalesAMostrar))
      'End If
      'End If

      Me._modalidad = Modalidades.NORMAL

      Me.txtCantidad.Focus()
      Me.txtCantidad.SelectAll()

   End Sub

   Private Sub CargarFoto(ByVal idProducto As String, ByVal Precio As Decimal)
      Dim prod As Reglas.Productos = New Reglas.Productos()
      Dim produ As Entidades.Producto = prod.GetUno(idProducto)
      Me.pcbFoto.Image = produ.Foto
      Me.txtPrecioMostrar.Text = Precio.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
   End Sub

   Private Sub CargarProductoCompleto(ByVal dr As DataGridViewRow)

      Dim oProductos As Reglas.Productos = New Reglas.Productos

      Me.bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      'Llamo al evento para cargar el objeto "FilaDevuelta" validado luego al insertar el producto.
      Me.bscCodigoProducto.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")
      Me.bscCodigoProducto.PresionarBoton()

      If Publicos.FacturacionModificaDescripcionProducto And Boolean.Parse(Me.bscCodigoProducto.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
         'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
         Me.bscProducto.Text = dr.Cells("ProductoDesc").Value.ToString()
      End If

      'NO hace falta, el "PresionarBoton" llama a "CargarProducto" y lo asigna.
      ''Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
      'Me.txtStock.Text = Me.bscCodigoProducto.FilaDevuelta.Cells("Stock").Value.ToString()
      'Me.txtStock.Tag = Boolean.Parse(Me.bscCodigoProducto.FilaDevuelta.Cells("AfectaStock").Value.ToString())

      Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), Me._valorRedondeo).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtCantidad.Text = dr.Cells("Cantidad").Value.ToString()
      Me.cmbPorcentajeIva.Text = dr.Cells("AlicuotaImpuesto").Value.ToString()
      Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
      Me.txtTotalProducto.Text = Decimal.Parse(dr.Cells("Importe").Value.ToString()).ToString("#0." + New String("0"c, Me._decimalesAMostrar))

      Me.txtTamanio.Text = Me.bscCodigoProducto.FilaDevuelta.Cells("Tamano").Value.ToString()
      Me.txtUM.Text = Me.bscCodigoProducto.FilaDevuelta.Cells("IdUnidadDeMedida").Value.ToString()

   End Sub

   Private Sub CargarObservDetalleCompleto(ByVal dr As DataGridViewRow)

      Me.txtObservacionDetalle.Text = dr.Cells("gobsObservacion").Value.ToString()

   End Sub

   Private Sub CalcularDatosDetalle()

      If Me.cmbCategoriaFiscal.SelectedItem Is Nothing Then Exit Sub

      For Each vPro As Entidades.VentaProducto In Me._ventasProductos

         vPro.DescRecGeneral = Decimal.Round((vPro.ImporteTotal * Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100), Me._valorRedondeo)

         Me.CalculaValores(vPro.Cantidad, vPro.AlicuotaImpuesto, vPro.Precio, _
             vPro.DescuentoRecargoPorc1, vPro.DescuentoRecargoPorc2, Decimal.Parse(Me.txtDescRecGralPorc.Text), _
             vPro.PrecioNeto, 0, vPro.ImporteImpuesto, vPro.ImporteTotal)

      Next

      Me.dgvProductos.Refresh()
      Me.RecalcularSubtotales()
      Me.CalcularTotales()

   End Sub

   Private Sub RenumerarObservacionesDetalle()

      Dim Linea As Integer = 0

      For Each vObs As Entidades.VentaObservacion In Me._ventasObservaciones
         Linea += 1
         vObs.Linea = Linea
      Next

      Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

   End Sub

   Private Sub CargarUnArticulo(ByVal linea As Entidades.VentaProducto, _
                                 ByVal idProducto As String, _
                                 ByVal productoDescripcion As String, _
                                 ByVal descuentoRecargoPorc1 As Decimal, _
                                 ByVal descuentoRecargoPorc2 As Decimal, _
                                 ByVal descuentoRecargo As Decimal, _
                                 ByVal precio As Decimal, _
                                 ByVal cantidad As Decimal, _
                                 ByVal importeTotal As Decimal, _
                                 ByVal stock As Decimal, _
                                 ByVal costo As Decimal, _
                                 ByVal precioLista As Decimal, _
                                 ByVal kilos As Decimal, _
                                 ByVal idTipoImpuesto As Entidades.TipoImpuesto.Tipos, _
                                 ByVal porcentajeIva As Decimal, _
                                 ByVal importeIva As Decimal, _
                                 ByVal precioNeto As Decimal)

      With linea
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         '.Producto.IdProducto = idProducto
         .Producto = New Reglas.Productos().GetUno(idProducto)  'Luego uso ciertas caracteristicas (ej: LOTE).
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
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .ComisionVendedorPorc = 0
         .ComisionVendedor = 0
      End With

   End Sub

   Private Sub CargarTotales(ByVal impuesto As Entidades.VentaImpuesto, _
                             ByVal idTipoImpuesto As Entidades.TipoImpuesto.Tipos, _
                             ByVal alicuota As Decimal, _
                             ByVal bruto As Decimal, _
                             ByVal neto As Decimal, _
                             ByVal importeIva As Decimal, _
                             ByVal total As Decimal)

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
      'Me.CalcularDescuentosProductos()
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

      Dim descRecPorc1 As Decimal = 0  'Decimal.Parse(Me.txtDescRecPorc1.Text)
      Dim descRecPorc2 As Decimal = 0  'Decimal.Parse(Me.txtDescRecPorc2.Text)
      Dim descRecargo As Decimal = 0   'Decimal.Parse(Me.txtDescRec.Text)

      If Me.txtStock.Text.Length <> 0 Then
         stock = Decimal.Parse(Me.txtStock.Text)
      End If

      Dim alicuotaIVA As Decimal
      Dim IdMoneda As Integer

      If bscCodigoProducto.FilaDevuelta Is Nothing Then
         precioCosto = Decimal.Parse(bscProducto.FilaDevuelta.Cells("PrecioCosto").Value.ToString())
         precioLista = Decimal.Parse(bscProducto.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscProducto.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscProducto.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      Else
         precioCosto = Decimal.Parse(bscCodigoProducto.FilaDevuelta.Cells("PrecioCosto").Value.ToString())
         precioLista = Decimal.Parse(bscCodigoProducto.FilaDevuelta.Cells("PrecioVenta").Value.ToString())
         alicuotaIVA = Decimal.Parse(bscCodigoProducto.FilaDevuelta.Cells("Alicuota").Value.ToString())
         IdMoneda = Integer.Parse(bscCodigoProducto.FilaDevuelta.Cells("IdMoneda").Value.ToString())
      End If

      'Precio de Costo, Opciones: ACTUAL o PROMPOND;<meses>
      If Publicos.VentasPrecioCosto <> "ACTUAL" Then

         Dim CalculoCosto() As String = Publicos.VentasPrecioCosto.Split(";"c)

         Dim oCP As Reglas.ComprasProductos = New Reglas.ComprasProductos()

         Dim OtroPrecioCosto As Decimal = 0

         'Dejo preparado para distintas formas.
         If CalculoCosto(0) = "PROMPOND" Then
            OtroPrecioCosto = oCP.GetCostoPromedioPonderado(actual.Sucursal.Id, _
                                                            Me.bscCodigoProducto.Text, _
                                                            Date.Today.AddMonths(Integer.Parse(CalculoCosto(1).ToString()) * (-1)), _
                                                            Date.Today)

            If OtroPrecioCosto <> 0 Then
               precioCosto = OtroPrecioCosto
            End If
         End If

      End If

      If Publicos.PreciosConIVA Then
         'Le quito el IVA que el producto tiene en forma predeterminada.
         precioCosto = Decimal.Round(precioCosto / (1 + alicuotaIVA / 100), Me._valorRedondeo)
         precioLista = Decimal.Round(precioLista / (1 + alicuotaIVA / 100), Me._valorRedondeo)
      End If

      If IdMoneda = 2 Then
         precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
         precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
      End If

      'Asigno el nuevo iva (puedo cambiar o no)
      alicuotaIVA = Decimal.Parse(Me.cmbPorcentajeIva.Text)

      If Me.txtUM.Text <> "" Then
         Dim Conversion As Decimal
         Dim oUM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
         Conversion = oUM.GetUno(Me.txtUM.Text).ConversionAKilos
         Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * Decimal.Parse(Me.txtTamanio.Text) * Conversion, Me._valorRedondeo)
      End If

      Dim precioProducto As Decimal = Decimal.Parse(Me.txtPrecio.Text.Trim())

      Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text)

      Dim descRecPorGeneral As Decimal = Decimal.Parse(Me.txtDescRecGralPorc.Text)

      Dim precioNeto As Decimal = 0

      Me._numeroOrden += 1

      '--------------------------------------------------------------------------------

      'ingreso los valores del Lote '.... por ahora solo de hace Nota de Credito
      If Me._productoLoteTemporal.Producto.Lote And DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> 0 Then

         'Si es NCRE , valido fechas.. sino.. que exista
         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock > 0 Then

            'En caso de NCRED no debe seleccionarlo... debe crearlo.
            'Dim idL As SeleccionDeLote = New SeleccionDeLote(Me.bscCodigoProducto.Text, Decimal.Parse(Me.txtCantidad.Text))
            Dim idL As IngresoDeLote = New IngresoDeLote()

            If idL.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
               MessageBox.Show("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.btnInsertar.Focus()
               Exit Sub
            End If

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

            Me._productoLoteTemporal.IdSucursal = actual.Sucursal.Id
            Me._productoLoteTemporal.IdLote = idL.txtIdLote.Text.ToUpper()
            Me._productoLoteTemporal.Cantidad = Decimal.Parse(Me.txtCantidad.Text)
            Me._productoLoteTemporal.Orden = Me._numeroOrden
            Me._productosLotes.Add(Me._productoLoteTemporal)

            'Valido que Exista
         Else

            'Dim oProductoLote As Entidades.ProductoLote
            'oProductoLote = New Reglas.ProductosLotes().GetUno(idL.txtIdLote.Text.ToUpper(), actual.Sucursal.Id, Me.bscCodigoProducto.Text)

            Dim DispProdLotes As Decimal

            DispProdLotes = New Reglas.ProductosLotes().GetDisponiblePorProducto(actual.Sucursal.Id, Me.bscCodigoProducto.Text)

            If DispProdLotes = 0 Then
               MessageBox.Show("No existen Lotes para el Producto seleccionado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If


            If DispProdLotes < Decimal.Parse(Me.txtCantidad.Text) Then
               MessageBox.Show("El Producto tiene en Stock " & DispProdLotes.ToString() & " quedaría en Cantidad Negativa, No es posible con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            ''Le pongo la fecha del Lote original
            'Me._productoLoteTemporal.FechaVencimiento = oProductoLote.FechaVencimiento.Date

         End If

      End If

      ''ingreso los nros. de serie
      'If Me._productoLoteTemporal.ProductoSucursal.Producto.NroSerie Then
      '   Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidad.Text), 0).ToString())
      '   Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos, Me._productoLoteTemporal.ProductoSucursal.Producto)
      '   If ins.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      '      MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie los tiene que ingresar en la compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '      Me.btnInsertar.Focus()
      '      Exit Sub
      '   Else
      '      For Each ns As Entidades.ProductoNroSerie In ins.ProductosNrosSerie
      '         Me._productosNrosSeries.Add(ns)
      '      Next
      '   End If
      'End If

      '--------------------------------------------------------------------------------

      Me.CalculaValores(cantidad, alicuotaIVA, precioProducto, descRecPorc1, descRecPorc2, descRecPorGeneral, _
                        precioNeto, importeBruto, importeIva, importeTotal)

      Me.CargarUnArticulo(oLineaDetalle, _
                        Me.bscCodigoProducto.Text, _
                        Me.bscProducto.Text, _
                        descRecPorc1, _
                        descRecPorc2, _
                        descRecargo, _
                        precioProducto, _
                        cantidad, _
                        importeTotal, _
                        stock, _
                        precioCosto, _
                        precioLista, _
                        Kilos, _
                        Me._tipoImpuestoIVA, _
                        alicuotaIVA, _
                        importeIva, _
                        precioNeto)

      'Me._numeroOrden += 1
      oLineaDetalle.Orden = Me._numeroOrden
      Me._ventasProductos.Add(oLineaDetalle)

      Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
      'Me.OrdenarGrillaProductos()
      Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
      Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
      'Me.dgvProductos.Refresh()

      'importeBruto = precioProducto * cantidad
      importeNeto = precioNeto * cantidad

      'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
      If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) Then
         importeBruto = Decimal.Round(importeBruto / (1 + alicuotaIVA / 100), Me._valorRedondeo)
         importeNeto = Decimal.Round(importeNeto / (1 + alicuotaIVA / 100), Me._valorRedondeo)
      End If

      Me.CargarTotales(oLineaImpuestos, _
                    Me._tipoImpuestoIVA, _
                      alicuotaIVA, _
                      importeBruto, _
                       importeNeto, _
                      importeIva, _
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

      If Not entro Then
         Me._subTotales.Add(oLineaImpuestos)
      End If
      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      '---------------------------------------------------------------------------
      If Me.EsComprobanteFiscal() And DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then

         Dim oImpresora As Entidades.Impresora
         oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

         If oImpresora.ImprimirLineaALinea Then

            _cfiscal = New ImpresionFiscal(oImpresora.Modelo, oImpresora.Puerto)

            If Me._ventasProductos.Count = 1 Then
               'Apertura del comprobante

               Me._cfiscal.Comprobante = Me.GenerarComprobanteParaFiscalLineaALinea()

               Me._cfiscal.AbrirComprobanteFiscal()

            End If

            'Impresion del item

            Me._cfiscal.ImprimirItemFiscal(Me._ventasProductos.Item(Me._ventasProductos.Count - 1))

         End If

      End If
      '---------------------------------------------------------------------------



      'Me.CalcularTotalProducto()
      Me.txtPrecioMostrar.Text = Me.txtPrecio.Text
      Me.LimpiarCamposProductos()
      Me.CalcularTotales()
      Me.CalcularDatosDetalle()


      Me.tsbGrabar.Enabled = True
      Me.bscCodigoProducto.Focus()

   End Sub

   Private Sub CalculaValores(ByVal cantidad As Decimal, _
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

      Dim descRec1 As Decimal = Decimal.Round(precioProducto * descRecPorc1 / 100, Me._valorRedondeo)
      Dim descRec2 As Decimal = Decimal.Round((precioProducto + descRec1) * descRecPorc2 / 100, Me._valorRedondeo)
      Dim descRec As Decimal = Decimal.Round((precioProducto + descRec1 + descRec2) * descRecPorGeneral / 100, Me._valorRedondeo)

      precioNeto = precioProducto + descRec1 + descRec2 + descRec

      importeBruto = (precioProducto + descRec1 + descRec2) * cantidad

      'Lo calcula despues
      'importeTotalProducto = precioNeto * cantidad
      '------------------------------------
      'En Pantalla debe mostrar el total bruto (sin aplicar el descuento General)
      importeTotalProducto = importeBruto

      If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         importeIVA = Decimal.Round((precioNeto * cantidad) - (precioNeto * cantidad) / (1 + alicuotaIVASobre100), Me._valorRedondeo)
      Else
         importeIVA = Decimal.Round((precioNeto * cantidad) * alicuotaIVASobre100, Me._valorRedondeo)
      End If

   End Sub

   Private Sub InsertarObservacion()

      Dim oLineaDetalle As Entidades.VentaObservacion = New Entidades.VentaObservacion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Linea = Me.dgvObservaciones.RowCount + 1
         .Observacion = Me.txtObservacionDetalle.Text
      End With

      Me._ventasObservaciones.Add(oLineaDetalle)

      Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

      Me.LimpiarCamposObservDetalles()

      'Me.tsbGrabar.Enabled = True
      Me.txtObservacionDetalle.Focus()

   End Sub

   Private Sub EliminarLineaProducto()

      Me._ventasProductos.RemoveAt(Me.dgvProductos.SelectedRows(0).Index)
      Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
      'Me.OrdenarGrillaProductos()

      Me.RecalcularSubtotales()
      Me.CalcularTotales()

      If Me.dgvProductos.Rows.Count > 0 Then
         Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
         Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
      End If

      Me.dgvProductos.Focus()

      If Me.dgvProductos.SelectedRows.Count > 0 And Me.dgvProductos.Focused Then
         Me.CargarFoto(Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value.ToString.Trim(), Decimal.Parse(Me.dgvProductos.SelectedRows(0).Cells("Precio").Value.ToString()))
      Else
         Me.txtPrecioMostrar.Text = "0." + New String("0"c, Me._decimalesAMostrar)
         Me.pcbFoto.Image = Nothing
      End If

      Me.bscCodigoProducto.Focus()

   End Sub

   Private Sub EliminarLineaObservacion()

      Me._ventasObservaciones.RemoveAt(Me.dgvObservaciones.SelectedRows(0).Index)
      Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()

   End Sub

   Private Sub OrdenarGrillaProductos()
      With Me.dgvProductos
         .Columns("IdProducto").DisplayIndex = 0
         .Columns("ProductoDesc").DisplayIndex = 1
         .Columns("Cantidad").DisplayIndex = 2
         .Columns("Stock").DisplayIndex = 3
         .Columns("Precio").DisplayIndex = 4
         .Columns("DescuentoRecargoPorc1").DisplayIndex = 5
         .Columns("DescuentoRecargoPorc2").DisplayIndex = 6
         .Columns("PrecioNeto").DisplayIndex = 7
         .Columns("IdTipoImpuesto").DisplayIndex = 8
         .Columns("AlicuotaImpuesto").DisplayIndex = 9
         .Columns("ImporteImpuesto").DisplayIndex = 10
         .Columns("Importe").DisplayIndex = 11
      End With
   End Sub

   Private Sub CambiarEstadoControlesDetalle(ByVal Habilitado As Boolean)

      Me.btnLimpiarProducto.Enabled = Habilitado

      Me.bscCodigoProducto.Enabled = Habilitado
      Me.bscProducto.Enabled = Habilitado
      Me.txtCantidad.Enabled = Habilitado
      Me.txtPrecio.Enabled = Habilitado

      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado

      'Por las que le toque habilitar, es factible que no corresponda
      If Habilitado Then
         Me.cmbPorcentajeIva.Enabled = Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos
      End If

      If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
            Me.cmbPorcentajeIva.Enabled = False
         End If
      End If

   End Sub

   Private Sub InsertarChequesGrilla()

      Dim oLineaDetalle As Entidades.Cheque = New Entidades.Cheque()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .NumeroCheque = Integer.Parse(Me.txtNroCheque.Text)
         .Banco = New Reglas.Bancos().GetUno(Integer.Parse(Me.bscBancos._filaDevuelta.Cells("idBanco").Value.ToString()))
         .IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text)
         .Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalCheque.Text)
         .FechaEmision = Me.dtpFechaEmision.Value
         .FechaCobro = Me.dtpFechaCobro.Value
         .Titular = Me.txtTitularCheque.Text
         .Importe = Decimal.Parse(Me.txtImporteCheque.Text)
         .Cliente.TipoDocumento = Me.cmbTipoDoc.Text
         .Cliente.NroDocumento = Me.bscCodigoCliente.Text
         .Usuario = actual.Nombre
         .IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA
      End With

      Me._cheques.Add(oLineaDetalle)

      Me.dgvCheques.DataSource = Me._cheques.ToArray()
      Me.dgvCheques.FirstDisplayedScrollingRowIndex = Me.dgvCheques.Rows.Count - 1

      Me.dgvCheques.Refresh()
      Me.LimpiarCamposCheques()
      Me.CalcularPagos()

   End Sub

   Private Sub CalcularDiferenciaDePago()
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
   End Sub

   Private Function ValidarInsertarCheques() As Boolean

      If Decimal.Parse(Me.txtImporteCheque.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un cheque con importe cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtImporteCheque.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtNroCheque.Text) = 0 Then
         MessageBox.Show("El número de cheque no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroCheque.Focus()
         Return False
      End If

      If Not Me.bscBancos.Selecciono Then
         MessageBox.Show("Debe seleccionar un Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscBancos.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtSucursalBanco.Text) = 0 Then
         MessageBox.Show("La Sucursal Del Banco no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtSucursalBanco.Focus()
         Return False
      End If

      If Integer.Parse(Me.txtCodPostalCheque.Text) = 0 Then
         MessageBox.Show("Debe ingresar un C.P. para el cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtCodPostalCheque.Focus()
         Return False
      Else
         If Not New Reglas.Localidades().Existe(Integer.Parse(Me.txtCodPostalCheque.Text)) Then
            MessageBox.Show("No existe la localidad del Cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCodPostalCheque.Focus()
            Return False
         End If
      End If


      'controlo que no se repita el cheque ingresado
      Dim ent As Entidades.Cheque
      For i As Integer = 0 To Me._cheques.Count - 1
         ent = Me._cheques(i)
         If ent.NumeroCheque = Integer.Parse(Me.txtNroCheque.Text) And _
                ent.Banco.IdBanco = Integer.Parse(Me.bscBancos._filaDevuelta.Cells("idBanco").Value.ToString()) And _
                ent.IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text) And _
                ent.Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalCheque.Text) Then
            MessageBox.Show("El cheque ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      Next

      Return True

   End Function

   Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Function GetVendedorCombo(ByVal tipoDoc As String, ByVal nroDoc As String) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If tipoDoc = emp.TipoDocEmpleado And nroDoc = emp.NroDocEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub RecalcularTodo()

      Try

         If Me._ventasProductos IsNot Nothing Then

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Dim ProdDT As DataTable

            Dim DescRec1 As Decimal, DescRec2 As Decimal
            Dim PrecioNeto As Decimal

            For Each pro As Entidades.VentaProducto In Me._ventasProductos

               ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")

               If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                  pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString())
               Else
                  pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())
               End If

               'Calculo el Nuevo Descuento/Recargo
               DescRec1 = Decimal.Round((pro.Precio * pro.DescuentoRecargoPorc1 / 100), Me._valorRedondeo)
               DescRec2 = Decimal.Round(((pro.Precio + DescRec1) * pro.DescuentoRecargoPorc2 / 100), Me._valorRedondeo)

               pro.DescuentoRecargo = (DescRec1 + DescRec2) * pro.Cantidad

               'Calculo el Nuevo Precio Neto
               PrecioNeto = pro.Precio + DescRec1 + DescRec2
               PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), Me._valorRedondeo)

               pro.PrecioNeto = PrecioNeto

               pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargo

            Next

            Me.dgvProductos.DataSource = _ventasProductos.ToArray()
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
            Me.bscCodigoProducto.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub CargarProximoNumero()

      If Me.txtLetra.Text <> "" Then

         Dim oImpresora As Entidades.Impresora
         Dim oVentasNumeros As New Reglas.VentasNumeros
         Dim CentroEmisor As Short

         'CentroEmisor = oImpresoras.GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal()).CentroEmisor

         oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

         CentroEmisor = oImpresora.CentroEmisor

         Me.txtNumeroPosible.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal.Id, _
                                                              DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante, _
                                                              Me.txtLetra.Text, _
                                                              CentroEmisor).ToString()
         Me.txtNumeroPosible.Tag = oImpresora.Marca

      Else

         Me.txtNumeroPosible.Text = ""
         Me.txtNumeroPosible.Tag = ""

      End If

      Me.CargarLineasPermitidas()

      Me.OrdenarGrillaProductos()

   End Sub

   Private Sub CargarLineasPermitidas()

      If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

         Dim oComprobanteLetra As Entidades.TipoComprobanteLetra
         oComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text)

         'Toma las Lineas del reporte especifico.
         If oComprobanteLetra.TipoComprobante.IdTipoComprobante <> "" Then

            Me._cantMaxItems = oComprobanteLetra.CantidadItemsProductos
            Me._cantMaxItemsObserv = oComprobanteLetra.CantidadItemsObservaciones
            Me._imprime = oComprobanteLetra.Imprime

            'Toma las Lineas del Comprobante.
         Else

            Me._cantMaxItems = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItems
            Me._cantMaxItemsObserv = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItemsObserv
            Me._imprime = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime

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
            Me._ventasObservaciones.Clear()
            Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()
            Me.tbcDetalle.TabPages.Remove(Me.tbpObservaciones)
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
      Dim Utilidad As Decimal = 0

      For Each dr As Entidades.VentaProducto In Me._ventasProductos

         descRec1 = Decimal.Round(dr.Precio * dr.DescuentoRecargoPorc1 / 100, Me._valorRedondeo)
         descRec2 = Decimal.Round((dr.Precio + descRec1) * dr.DescuentoRecargoPorc2 / 100, Me._valorRedondeo)

         importeCosto = dr.Costo * dr.Cantidad
         importeBruto = (dr.Precio + descRec1 + descRec2) * dr.Cantidad
         importeNeto = dr.PrecioNeto * dr.Cantidad

         If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            importeBruto = Decimal.Round(importeBruto / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
            importeNeto = Decimal.Round(importeNeto / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
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

            Me.CargarTotales(olineaTotales, _
                  Me._tipoImpuestoIVA, _
                dr.AlicuotaImpuesto, _
                importeBruto, _
                importeNeto, _
                dr.ImporteImpuesto, _
                importeNeto + dr.ImporteImpuesto)

            Me._subTotales.Add(olineaTotales)
         End If
      Next

      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      If importeNetoTotal <> 0 Then

         Dim PorcentajeUtilidad As Decimal = Decimal.Round(Utilidad / importeNetoTotal * 100, Me._valorRedondeo)

         Me.txtSemaforoRentabilidad.Text = PorcentajeUtilidad.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar)) & " %"
         Dim colo As Color = System.Drawing.Color.FromArgb(New Reglas.SemaforoVentasUtilidades().ColorSemaforo(PorcentajeUtilidad))

         Me.txtSemaforoRentabilidad.BackColor = colo

         If colo.ToArgb() = Color.Black.ToArgb() Then
            Me.txtSemaforoRentabilidad.ForeColor = Color.White
         Else
            Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
         End If

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
      For Each vp As Entidades.VentaProducto In Me._ventasProductos
         If vp.Producto.Lote Then
            Cantidad += 1
         End If
      Next
      Return Cantidad
   End Function

   Private Sub LimpiarDetalle()

      Me._ventasProductos = Nothing
      Me._ventasProductos = New List(Of Entidades.VentaProducto)
      Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()

      'Me.OrdenarGrillaProductos()

      Me._subTotales = Nothing
      Me._subTotales = New List(Of Entidades.VentaImpuesto)
      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      'Pone todo en cero.
      Me.CalcularTotales()

   End Sub

   'Private Sub AcomodaNumeroOrden()
   '   For Each vp As Entidades.VentaProducto In Me._ventasProductos
   '   Next
   '   For Each vp As Entidades.VentaProductoLote In Me._productosLotes
   '   Next
   'End Sub

   Private Function ValidarComprobanteParaFiscalLineaALinea() As Boolean

      Dim sistema As Entidades.Sistema = Publicos.GetSistema()

      If DateDiff(DateInterval.Day, Me.dtpFecha.Value, sistema.FechaVencimiento) < 0 Then
         MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpFecha.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
         Dim dt As DataTable = oPF.Get1(Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
         If dt.Rows.Count = 0 Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            Return False
         End If
      End If

      If Me.cmbTipoDoc.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de documento del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTipoDoc.Focus()
         Return False
      End If

      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nro. de Documento del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If Me.bscCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCliente.Focus()
         Return False
      End If

      'If Me._ventasProductos.Count = 0 Then
      '   MessageBox.Show("No se cargo ningún producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.tbcDetalle.SelectedTab = Me.tbpProductos
      '   Me.bscCodigoProducto.Focus()
      '   Return False
      'End If

      If Not Publicos.VentasConProductosEnCero Then
         'verifico que ningun producto tenga precio cero
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            If pro.ImporteTotal = 0 Then
               MessageBox.Show("No puede haber productos con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.tbcDetalle.SelectedTab = Me.tbpProductos
               Me.bscCodigoProducto.Focus()
               Return False
            End If
         Next
      End If

      'If Decimal.Parse(Me.txtTotalGeneral.Text) = 0 Then
      '   MessageBox.Show("No se calcularon los totales de la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.tbcDetalle.SelectedTab = Me.tbpProductos
      '   Me.bscCodigoProducto.Focus()
      '   Return False
      'End If

      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If Me.cmbVendedor.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbVendedor.Focus()
         Return False
      End If

      If Me.cmbFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar la forma de pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbFormaPago.Focus()
         Return False
      End If

      'Si es Nota Credito o Dev. Proforma no puede aceptar cheques. Que lo arregle desde caja.
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores <= 0 And Me.dgvCheques.RowCount > 0 Then
         MessageBox.Show("Este comprobante no esta habilitado para ingresar cheque(s).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas <> "X" Then
         'Valida si el comprobante esta permitido para la letra fiscal
         Dim tip As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         If Not tip.LetraHabilitada(Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text) Then
            MessageBox.Show("Este comprobante no esta habilitado para esta Letra Fiscal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTiposComprobantes.Focus()
            Return False
         End If
      End If

      If Not Me.chbNumeroAutomatico.Checked And Long.Parse(Me.txtNumeroPosible.Text) <= 0 Then
         MessageBox.Show("El Numero de Comprobante digatado es Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroPosible.Focus()
         Return False
      End If


      'Validacion por si invoco comprobantes -------------------------------

      If Me.dgvObservaciones.RowCount > Me._cantMaxItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = Integer.Parse(Me.dgvProductos.RowCount.ToString())

      If LineasDetalle + Me.dgvObservaciones.RowCount > Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.btnEliminar.Focus()
         Return False
      End If
      '-------------------------------------------------------------------

      If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 Then
            If Decimal.Parse(Me.txtSaldoCtaCte.Text) + Decimal.Parse(Me.txtTotalGeneral.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
               If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                  Return False
               End If
            End If
         End If
      End If

      Dim ImporteTope As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteTope
      If ImporteTope > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) > ImporteTope Then
         MessageBox.Show("El Comprobante Superó el Límite Permitido de $ " & ImporteTope.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      Dim ImporteMinimo As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteMinimo
      If ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) < ImporteMinimo Then
         MessageBox.Show("El Comprobante No Alcanzó el Mínimo Requerido de $ " & ImporteMinimo.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      'A Raymundo cada tanto le pasa que no genera el descuento, no dan enter!
      If Decimal.Parse(Me.txtDescRecGralPorc.Text) <> 0 And Decimal.Parse(Me.txtDescRecGral.Text) = 0 Then
         MessageBox.Show("No se calculó el Descuento/Recargo General, por favor de enter para confirmarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDescRecGralPorc.Focus()
         Return False
      End If

      'Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
      'Habria que hacerlo mas general!
      If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal And String.IsNullOrEmpty(Me._clienteE.Cuit) Then
         MessageBox.Show("El Cliente NO tiene CUIT y es obligatorio para este comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      '------- Permitir comprobante con fecha y numeración anterior ---------
      Dim oVN As Reglas.VentasNumeros = New Reglas.VentasNumeros()
      Dim oImpresora As Entidades.Impresora
      Dim CentroEmisor As Short

      oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

      CentroEmisor = oImpresora.CentroEmisor

      Dim FechaComp As Date
      FechaComp = oVN.GetUltimaFecha(actual.Sucursal.IdSucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text, CentroEmisor)

      If Not Publicos.PermitirComprobFechaNumAnterior And Me.dtpFecha.Value.Date < FechaComp Then
         MessageBox.Show("No puede Grabar el Comprobante con una Fecha menor a " & FechaComp.ToString("dd/MM/yyyyy"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False
      End If

      Return True

   End Function

   Private Function GenerarComprobanteParaFiscalLineaALinea() As Entidades.Venta

      Dim oComprobante As New Entidades.Venta

      With oComprobante
         'cargo el comprobante
         .TipoComprobante = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)

         'cargo el cliente ----------
         .Cliente = Me._clienteE

         'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
         .CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)

         .LetraComprobante = Me.txtLetra.Text

         If Not Me.chbNumeroAutomatico.Checked Or (.TipoComprobante.EsFiscal And Not .TipoComprobante.GrabaLibro) Then
            .NumeroComprobante = Long.Parse(Me.txtNumeroPosible.Text)
         End If

         'cargo datos generales del comprobante
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Fecha = Me.dtpFecha.Value

      End With

      Return oComprobante

   End Function

#End Region

End Class
