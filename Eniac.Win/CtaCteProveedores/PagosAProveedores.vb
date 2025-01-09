Imports Eniac.Reglas.Publicos

Public Class PagosAProveedores

#Region "Campos"

   Private _ComprobantesGrilla As New List(Of Entidades.CuentaCorrienteProvPago)
   Private _chequesPropios As List(Of Entidades.Cheque)
   Private _chequesTerceros As List(Of Entidades.Cheque)
   Private _publicos As Publicos
   Private _proveedorGrilla As Entidades.Proveedor
   Private _pago As Entidades.TipoComprobante
   Private _percepciones As List(Of Entidades.RetencionCompra)
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True
   Private _ConfiguracionImpresoras As Boolean
   'Private _PagaOriginal As Decimal = 0
   Private _cargandoPantalla As Boolean = True
   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""
   Private _idCuentaBancariaSeleccionada As Integer = 0
   Private ObservacionCtaCte As String
   Private _idFormaDePagoContado As Integer
   Private _idFormaDePagoCtaCte As Integer
   Private _comprobanteAutomatico As Boolean = False
   Private _transferencias As List(Of Entidades.CuentaCorrienteProvTransferencia)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _cargoBienLaPantalla = False

         _publicos = New Publicos()
         _transferencias = New List(Of Entidades.CuentaCorrienteProvTransferencia)
         _chequesPropios = New List(Of Entidades.Cheque)()
         _chequesTerceros = New List(Of Entidades.Cheque)()
         _percepciones = New List(Of Entidades.RetencionCompra)()

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, Entidades.TipoComprobante.Tipos.COMPRAS.ToString(), Entidades.TipoComprobante.Tipos.CTACTE.ToString())
         _publicos.CargaComboBancos(cmbBancoPropio)
         _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantesPag, True, "CTACTEPROV")

         '# Tipos de Cheque
         _publicos.CargaComboTiposCheques(cmbTipoCheque)

         If cmbTiposComprobantesPag.Items.Count = 0 Then
            _ConfiguracionImpresoras = True
         End If

         'si no retiene ganancias no muestro el tab
         If Not Reglas.Publicos.RetieneGanancias Then
            tbcCompPagos.TabPages.Remove(tbpPercepciones)
         End If

         If Not Reglas.Publicos.CtaCteProv.CtaCteProveedoresSeparar Then
            lblSaldoGeneral.Visible = False
            txtSaldoGeneral.Visible = False
         End If

         Me._idFormaDePagoContado = New Reglas.VentasFormasPago().GetUna("COMPRAS", True).IdFormasPago
         Me._idFormaDePagoCtaCte = New Reglas.VentasFormasPago().GetUna("COMPRAS", False).IdFormasPago

         LimpiarCamposComprobante()

         Nuevo()

         If cmbTiposComprobantesPag.Items.Count > 0 Then
            _pago = New Reglas.TiposComprobantes().GetUno(cmbTiposComprobantesPag.SelectedValue.ToString())
         End If

         _cargandoPantalla = False

         _cargoBienLaPantalla = True

         If Reglas.Publicos.CtaCteProv.MostrarObservaciondeComprobantes Then
            chbMostrarObs.Checked = True
         Else
            chbMostrarObs.Checked = False
         End If

         If chbMostrarObs.Checked Then
            dgvComprobantes.Columns("Observacion").Visible = True
         Else
            dgvComprobantes.Columns("Observacion").Visible = False
         End If

      Catch ex As Exception
         _mensajeDeErrorEnCarga = ex.Message
         _cargoBienLaPantalla = False
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData
         Case Keys.F4
            If tsbGenerarNCND.Visible AndAlso tsbGenerarNCND.Enabled Then
               tsbGenerarNCND.PerformClick()
            Else
               tsbGrabar.PerformClick()
            End If
         Case Keys.F9
            tbcDetalle.SelectedTab = tbpComprobantes
         Case Keys.F11
            tbcDetalle.SelectedTab = tbpPagos1
         Case Keys.F12
            tbcDetalle.SelectedTab = tbpPagos2
         Case Else
            Return MyBase.ProcessCmdKey(msg, keyData)
      End Select
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
      TryCatched(
         Sub()
            _chequesTerceros.Clear()
            dgvChequesTerceros.DataSource = _chequesTerceros.ToArray()

            CalcularPagos()
         End Sub)
   End Sub

   Private Sub btnImputAutomat_Click(sender As Object, e As EventArgs) Handles btnImputAutomat.Click
      TryCatched(Sub() ImputacionAutomatica())
   End Sub

   Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown

      If e.KeyCode = Keys.Enter And Reglas.Publicos.CtaCteProv.PagoSolicitaFecha Then
         Me.bscComprobante.Focus()
      Else
         Me.PresionarTab(e)
      End If

   End Sub

   Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
      Try
         If Not Me._cargandoPantalla Then
            'Al cambiar la fecha puedo cambiar el MES y afecta el calculo.
            Me.CalcularComprobantes()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCodPostalChequePropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodPostalChequePropio.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaEmisionPropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpChequePropioEmision.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaCobroPropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpChequePropioCobro.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtImporteChequePropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtImporteChequePropio.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPaga_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaga.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEfectivo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEfectivo.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEfectivo_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTickets_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTickets.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTickets_Leave(sender As Object, e As EventArgs) Handles txtTickets.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtImporteDolares_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtImporteDolares.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtImporteDolares_Leave(sender As Object, e As EventArgs) Handles txtImporteDolares.Leave
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

      If Me._proveedorGrilla Is Nothing Then
         MessageBox.Show("ATENCION: Debe elegir el Proveedor antes de cargar el Cheque de Tercero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Me.bscCodigoProveedor.Focus()
         Exit Sub
      End If

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

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         Select Case Me.tbcDetalle.SelectedTab.Name
            Case "tbpComprobantes"
               Me.bscComprobante.Focus()
            Case "tbpPagos1"
               Me.txtEfectivo.Focus()
            Case "tbpPagos2"
               Me.btnInsertarChequeTercero.Focus()
         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtNroChequePropio_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNroChequePropio.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtSucursalBancoPropio_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSucursalBancoPropio.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNroCheque_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)
      Me.PresionarTab(e)
   End Sub

   Private Sub txtSucursalBanco_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
      Me.PresionarTab(e)
   End Sub

   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      Try
         Me.Nuevo()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub bscComprobante_BuscadorClick() Handles bscComprobante.BuscadorClick
      TryCatched(
      Sub()
         Dim strComprobantesAsociados = New Reglas.TiposComprobantes().GetUno(cmbTiposComprobantesPag.ValorSeleccionado(Of String)).ComprobantesAsociados

         Dim numero = bscComprobante.Text.ValorNumericoPorDefecto(0L)
         PreparaGrillaComprobantes2(bscComprobante)
         bscComprobante.Datos = New Reglas.CuentasCorrientesProv().BuscarPendientes(actual.Sucursal.Id, _proveedorGrilla, strComprobantesAsociados, numero)
      End Sub)
   End Sub

   Private Sub bscComprobante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscComprobante.BuscadorSeleccion
      TryCatched(Sub() CargarComprobante(e.FilaDevuelta))
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub() GrabarComprobante())
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick

      Dim codigoProveedor As Long = -1

      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            '    Me.bscCodigoProducto.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
         Me.Nuevo()
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            '      Me.bscCodigoProducto.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
         Me.Nuevo()
      End Try
   End Sub

   Private Sub llbProveedor_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbProveedor.LinkClicked

      Try
         Dim PantProveedor As ProveedoresDetalle

         If Me.bscCodigoProveedor.Selecciono Or Me.bscProveedor.Selecciono Then
            Dim Prov = New Entidades.Proveedor()
            Dim blnIncluirFoto As Boolean = True
            Prov = New Reglas.Proveedores()._GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), blnIncluirFoto)
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

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         'If (Not Me.bscComprobante.FilaDevuelta Is Nothing) And Me.txtCuota.Text <> "" Then
         If Me.ValidarInsertarComprobante() Then
            Me.InsertarComprobanteGrilla()
            Me.bscComprobante.Focus()
         End If
         'End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvComprobantes.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el pago seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaComprobante()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtImporte_LostFocus(sender As Object, e As EventArgs) Handles txtImporte.LostFocus
      Try
         If Me.txtImporte.Text.Trim().Length = 0 Then
            Me.txtImporte.Text = "0.00"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCuota_LostFocus(sender As Object, e As EventArgs) Handles txtCuota.LostFocus
      Try
         If Me.txtCuota.Text.Trim().Length = 0 Then

         Else
            If Me.txtImporte.Text = "-" Then
               Me.txtImporte.Text = "0.00"
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCuota_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCuota.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtImporte.Focus()
      End If
   End Sub

   Private Sub txtComprobantes_LostFocus(sender As Object, e As EventArgs) Handles txtTotalComprobantes.LostFocus, txtAnticipo.LostFocus
      If Me.txtTotalComprobantes.Text.Trim().Length = 0 Then
         Me.txtTotalComprobantes.Text = "0"
      End If
   End Sub

   Private Sub btnLimpiarComprobante_Click(sender As Object, e As EventArgs) Handles btnLimpiarComprobante.Click

      Me.LimpiarCamposComprobante()
      Me.bscComprobante.Focus()

   End Sub

   Private Sub dgvComprobantes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComprobantes.CellClick
      Try
         If e.RowIndex <> -1 And Me.dgvComprobantes.Columns(e.ColumnIndex).HeaderText = "Ver" Then
            Me.Cursor = Cursors.WaitCursor

            Dim regTipoComp As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
            Dim oTipoComprobante As Entidades.TipoComprobante = regTipoComp.GetUno(Me.dgvComprobantes.Rows(e.RowIndex).Cells("TipoComprobante").Value.ToString())

            Dim rCompras As Reglas.Compras = New Reglas.Compras
            Dim eCompra As Entidades.Compra = rCompras.GetUna(actual.Sucursal.Id,
                        Me.dgvComprobantes.Rows(e.RowIndex).Cells("TipoComprobante").Value.ToString(),
                        Me.dgvComprobantes.Rows(e.RowIndex).Cells("letra").Value.ToString(),
                        Short.Parse(Me.dgvComprobantes.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()),
                        Long.Parse(Me.dgvComprobantes.Rows(e.RowIndex).Cells("NroComprobante").Value.ToString()),
                        _proveedorGrilla.IdProveedor)

            Dim rImpresion As ImpresionCompra = New ImpresionCompra(eCompra)
            rImpresion.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvComprobantes_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComprobantes.CellDoubleClick

      Try
         'Limpia los textbox, y demas controles
         Me.LimpiarCamposComprobante()

         'Carga el Comprobante seleccionado de la grilla en los textbox 
         Me.CargarComprobanteCompleto(Me.dgvComprobantes.Rows(e.RowIndex))

         'Elimina el comprobante de la grilla
         Me.EliminarLineaComprobante()

         Me.txtPaga.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaPropio_BuscadorClick() Handles bscCuentaBancariaPropio.BuscadorClick
      TryCatched(
         Sub()
            If bscCodigoProveedor.Enabled And _proveedorGrilla Is Nothing Then
               ShowMessage("ATENCION: Debe cargar el Proveedor antes de cargar un cheque")
               bscCodigoProveedor.Focus()
               bscCodigoProveedor.Datos = Nothing
               Return
            End If
            _publicos.PreparaGrillaCuentasBancarias(bscCuentaBancariaPropio)
            bscCuentaBancariaPropio.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaPropio.Text.Trim(), Entidades.Moneda.Peso)
         End Sub)
   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaPropio.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaBancaria(e.FilaDevuelta)
            Me.GetProximoChequeDeChequera()
            Me.txtNroChequePropio.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   'Private Sub bscCuentaBancariaTransfBanc_BuscadorClick()
   '   TryCatched(
   '      Sub()
   '         _publicos.PreparaGrillaCuentasBancarias(bscCuentaBancariaTransfBanc)
   '         bscCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim())
   '         CalcularPagos()
   '      End Sub)
   'End Sub

   'Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs)
   '   TryCatched(
   '      Sub()
   '         If Not e.FilaDevuelta Is Nothing Then
   '            bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
   '            bscCuentaBancariaTransfBanc.Tag = New Reglas.CuentasBancarias().GetUna(Integer.Parse(e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
   '            CalcularPagos()
   '            dtpFechaTransferencia.Focus()
   '         End If
   '      End Sub)
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

   Private Sub cmbTipoCheque_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNroOperacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNroOperacion.KeyDown
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

   Private Sub cmbTiposComprobantesPag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesPag.SelectedIndexChanged
      Try
         If Me.cmbTiposComprobantesPag.SelectedValue IsNot Nothing Then

            'Si es X/R siempre debe tener esa letra, sino dejo la del Cliente
            If DirectCast(Me.cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Or
               DirectCast(Me.cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "R" Then
               Me.txtLetraPago.Text = DirectCast(Me.cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me._proveedorGrilla IsNot Nothing Then
                  Me.txtLetraPago.Text = Me._proveedorGrilla.CategoriaFiscal.LetraFiscal
               Else
                  Me.txtLetraPago.Text = ""
               End If
            End If

            '-- REQ-30966 --
            txtRefProveedores.Enabled = cmbTiposComprobantesPag.ItemSeleccionado(Of Entidades.TipoComprobante).RequiereReferenciaCtaCte
            If Not txtRefProveedores.Enabled Then
               txtRefProveedores.Text = ""
            End If

            If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
               Me._ComprobantesGrilla.Clear()
               Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
               Me.CalcularTotales()
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTiposComprobantesPag_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbTiposComprobantesPag.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub btnSeleccionMultiple_Click(sender As Object, e As EventArgs) Handles btnSeleccionMultiple.Click
      Try
         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            Exit Sub
         End If

         Dim IdTipoComprobante As String = String.Empty

         Dim oFactAyuda As ComprobantesPendientesProvAyuda

         If Me.dgvComprobantes.RowCount > 0 Then
            If Me._ComprobantesGrilla IsNot Nothing Then
               If Me._ComprobantesGrilla.Count > 0 Then
                  IdTipoComprobante = Me._ComprobantesGrilla(0).TipoComprobante.IdTipoComprobante
               End If
            End If
         Else
            IdTipoComprobante = ""
         End If

         Dim grabaLibro As Boolean = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesPag.SelectedValue.ToString()).GrabaLibro
         'TODO DRV
         If Me.dgvComprobantes.Rows.Count = 0 Then
            oFactAyuda = New ComprobantesPendientesProvAyuda(Me.cmbTiposComprobantesPag.SelectedValue.ToString(), IdTipoComprobante, _proveedorGrilla.IdProveedor, grabaLibro)
         Else
            oFactAyuda = New ComprobantesPendientesProvAyuda(Me.cmbTiposComprobantesPag.SelectedValue.ToString(), IdTipoComprobante, _proveedorGrilla.IdProveedor, Me._ComprobantesGrilla, grabaLibro)
         End If

         oFactAyuda.ShowDialog()

         Me.CargarComprobantesSeleccionados(oFactAyuda.ComprobantesSeleccionados)
         Me.CalcularComprobantes()
         ''Me.CalcularTotales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub PagosAProveedores_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         If _ConfiguracionImpresoras Then
            MessageBox.Show("No Existe la PC en Configuraciones/Impresoras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         End If
         If Not Me._cargoBienLaPantalla Then
            MessageBox.Show(_mensajeDeErrorEnCarga, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub cmbRegimen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegimenIVA.SelectedIndexChanged, cmbRegimenIIBB.SelectedIndexChanged, cmbRegimenIIBBComplem.SelectedIndexChanged, cmbRegimenGanancias.SelectedIndexChanged
      Try
         CalcularComprobantes()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtDescuentoRecargoPorc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescuentoRecargoPorc.KeyDown, txtDescuentoRecargoImporte.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtDescuentoRecargoPorc_LostFocus(sender As Object, e As EventArgs) Handles txtDescuentoRecargoPorc.LostFocus
      Try

         If Math.Abs(Decimal.Parse(Me.txtDescuentoRecargoPorc.Text.ToString())) >= 100 Then
            MessageBox.Show("El porcentaje no es correcto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtDescuentoRecargoPorc.Text = "0.00"
            Me.txtDescuentoRecargoPorc.Focus()
            Exit Sub
         End If

         'Me.txtPaga.Text = Me._PagaOriginal.ToString()
         txtPaga.Text = txtSaldo.Text
         If Me.txtDescuentoRecargoPorc.Text = "" Or Me.txtDescuentoRecargoPorc.Text = "-" Then
            Me.txtDescuentoRecargoPorc.Text = "0.00"
            Me.txtPaga.Text = Me.txtSaldo.Text
         Else

            Me.CalcularTotalAPagarComprobante()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtAnticipo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnticipo.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub chbAnticipo_CheckedChanged(sender As Object, e As EventArgs) Handles chbAnticipo.CheckedChanged
      TryCatched(Sub()
                    Me.txtAnticipo.ReadOnly = Not chbAnticipo.Checked
                    Me.CalcularPagos()
                    If chbAnticipo.Checked Then
                       Me.txtAnticipo.Focus()
                    End If
                 End Sub)
   End Sub

   Private Sub txtAnticipo_Leave(sender As Object, e As EventArgs) Handles txtAnticipo.Leave
      Try
         If Not txtAnticipo.ReadOnly Then
            RealizarRetenciones()
            CalcularTotales()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub PagosAProveedores_FormClosed(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

      Dim valida As Boolean = False
      Dim stbMensaje As StringBuilder = New StringBuilder()

      stbMensaje.AppendFormatLine("¿ Desea Salir del Formulario ?").AppendLine()
      stbMensaje.AppendFormatLine("       Verifique:").AppendLine()

      If dgvChequesPropios.RowCount > 0 Then
         stbMensaje.AppendFormatLine("Tiene Cheques Propios Cargados.").AppendLine()
         valida = True
      End If
      If dgvChequesTerceros.RowCount > 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Tiene Cheques de Terceros Cargadas.").AppendLine()
      End If

      If dgvComprobantes.RowCount > 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Tiene Comprobantes Cargados.").AppendLine()
      End If
      If Decimal.Parse(Me.txtTotalPagos.Text.ToString()) <> 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Total Pagos es Diferente de cero.").AppendLine()
      End If
      If valida Then
         If MessageBox.Show(stbMensaje.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
         End If
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

   Private Sub chbAjusteManual_CheckedChanged(sender As Object, e As EventArgs) Handles chbAjusteManual.CheckedChanged
      Try
         Me.dgvPercepciones.Columns(String.Concat("gret", Entidades.RetencionCompra.Columnas.ImporteTotal.ToString())).ReadOnly = Not Me.chbAjusteManual.Checked
         Me.dgvPercepciones.Columns(String.Concat("gret", Entidades.RetencionCompra.Columnas.BaseImponible.ToString())).ReadOnly = Not Me.chbAjusteManual.Checked

         Me.CalcularPagos()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dgvPercepciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPercepciones.CellEndEdit
      Try
         Me.dgvPercepciones.EndEdit()

         Me.CalcularPagos()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbChequera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChequera.SelectedIndexChanged
      If Me.cmbChequera.SelectedIndex <> -1 AndAlso Me.bscCuentaBancariaPropio.Selecciono Then
         Me.GetProximoChequeDeChequera()
      End If
   End Sub

   Private Sub chbMostrarObs_CheckedChanged(sender As Object, e As EventArgs) Handles chbMostrarObs.CheckedChanged

      If chbMostrarObs.Checked Then
         dgvComprobantes.Columns("Observacion").Visible = True
      Else
         dgvComprobantes.Columns("Observacion").Visible = False
      End If

   End Sub

   Private Sub tsbGenerarNCND_Click(sender As Object, e As EventArgs) Handles tsbGenerarNCND.Click
      TryCatched(
       Sub()
          If GenerarCreditosDebitos() Then
             tsbGrabar.PerformClick()
          End If
       End Sub)
   End Sub

#End Region

#Region "Metodos"

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
         Me.txtNroChequePropio.Focus()
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
         .Proveedor.IdProveedor = _proveedorGrilla.IdProveedor
         .Proveedor.CodigoProveedor = _proveedorGrilla.CodigoProveedor
         .EsPropio = True
         .Usuario = actual.Nombre
         .IdTipoCheque = Me.cmbTipoCheque.SelectedValue.ToString()
         .NombreTipoCheque = Me.cmbTipoCheque.Text
         .NroOperacion = Me.txtNroOperacion.Text
         .Cuit = actual.Sucursal.Empresa.CuitEmpresa
         .IdChequera = CInt(Me.cmbChequera.SelectedValue)
         .ImporteDias = Decimal.Parse(Me.txtImporteChequePropio.Text) * DateDiff(DateInterval.Day, dtpFecha.Value.Date, dtpChequePropioCobro.Value.Date)
      End With

      _chequesPropios.Add(oLineaDetalle)

      dgvChequesPropios.DataSource = _chequesPropios.ToArray()
      dgvChequesPropios.FirstDisplayedScrollingRowIndex = dgvChequesPropios.Rows.Count - 1

      dgvChequesPropios.Refresh()
      LimpiarCamposChequePropio()
      CalcularPagos()

   End Sub

   Private Sub EliminarLineaChequePropio()
      Me._chequesPropios.RemoveAt(Me.dgvChequesPropios.SelectedRows(0).Index)
      Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()
      Me.CalcularPagos()
   End Sub

   Private Sub LimpiarCamposChequePropio()
      Me.bscCuentaBancariaPropio.Text = ""
      Me.bscCuentaBancariaPropio.FilaDevuelta = Nothing
      Me.cmbChequera.DataSource = Nothing
      Me.cmbBancoPropio.SelectedIndex = -1
      Me.txtCodPostalChequePropio.Text = "0"
      Me.txtSucursalBancoPropio.Text = "0"
      Me.txtNroChequePropio.Text = "0"
      Me.dtpChequePropioCobro.Value = Date.Now
      Me.dtpChequePropioEmision.Value = Date.Now
      Me.txtImporteChequePropio.Text = "0.00"
      Me.txtNroOperacion.Clear()
      Me.cmbTipoCheque.SelectedValue = "F"
   End Sub

   Private Sub CargarChequeCompleto(dr As DataGridViewRow)

      Me.bscCuentaBancariaPropio.Text = dr.Cells("gchpNombreCuentaBancaria").Value.ToString()
      Me.bscCuentaBancariaPropio.PresionarBoton()
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

   Public Sub PreparaGrillaComprobantes(buscador As Eniac.Controles.Buscador)
      With buscador
         .Titulo = "Comprobantes pendientes"
         .ColumnasOcultas = New String() {"Sucursal", "IdProveedor", "CodigoProveedor", "IdFormasPago", "IdTipoComprobante"}
         .ColumnasTitulos = New String() {"Sucursal", "Vencimiento", "Tipo", "Letra", "Emisor", "Número", "Cuota", "Emisión", "Importe", "Saldo", "Observacion"}
         .ColumnasFormato = New String() {"", "dd/MM/yyyy", "", "", "", "", "", "dd/MM/yyyy", "#,##0.00", "#,##0.00", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight}
         .ColumnasAncho = New Integer() {0, 70, 100, 40, 40, 60, 40, 70, 70, 70, 70}

      End With
   End Sub

   Private Sub PreparaGrillaComprobantes2(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Comprobantes pendientes",
                                .AnchoAyuda = 712}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "Sucursal"
         col.Titulo = ""
         col.Ancho = 0
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "FechaVencimiento"
         col.Titulo = "Vencimiento"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "Tipo"
         col.Titulo = "Tipo"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 130
         .ColumnasVisibles.Add(col)
         ''-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 4
         col.Nombre = "Letra"
         col.Titulo = "Letra"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 50
         .ColumnasVisibles.Add(col)
         ''-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 5
         col.Nombre = "Emisor"
         col.Titulo = "Emisor"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 50
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 6
         col.Nombre = "Numero"
         col.Titulo = "Número"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         ''--
         col = New Controles.ColumnaBuscador
         col.Orden = 7
         col.Nombre = "Cuota"
         col.Titulo = "Cuota"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 50
         .ColumnasVisibles.Add(col)
         ''--
         col = New Controles.ColumnaBuscador
         col.Orden = 8
         col.Nombre = "Fecha"
         col.Titulo = "Emision"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         ''--
         col = New Controles.ColumnaBuscador
         col.Orden = 9
         col.Nombre = "Importe"
         col.Titulo = "Importe Total"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 100
         col.Formato = "N2"
         .ColumnasVisibles.Add(col)
         ''--
         col = New Controles.ColumnaBuscador
         col.Orden = 10
         col.Nombre = "Saldo"
         col.Titulo = "Saldo"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 100
         col.Formato = "N2"
         .ColumnasVisibles.Add(col)
         ''--
         col = New Controles.ColumnaBuscador
         col.Orden = 11
         col.Nombre = "Observacion"
         col.Titulo = "Observacion"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 150
         .ColumnasVisibles.Add(col)
      End With
   End Sub

   Private Function ValidarComprobante() As Boolean

      Dim sistema As Entidades.Sistema = Publicos.GetSistema()

      If sistema.FechaVencimiento.Subtract(Me.dtpFecha.Value).Days < 0 Then
         MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpFecha.Focus()
         Return False
      End If

      If Me.bscCodigoProveedor.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Código del Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProveedor.Focus()
         Return False
      End If

      If Me.bscProveedor.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscProveedor.Focus()
         Return False
      End If

      If Not _transferencias.Any() AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 And Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
         MessageBox.Show("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If
      'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
      '   MessageBox.Show("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Return False
      'End If

      If Me.dtpFecha.Value.Date > Date.Now.Date Then
         MessageBox.Show("La Fecha del Recibo NO puede ser Mayor al dia de Hoy", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If Decimal.Parse(Me.txtTickets.Text) < 0 Then
         MessageBox.Show("El importe de Tickets no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If Decimal.Parse(Me.txtTarjetas.Text) < 0 Then
         MessageBox.Show("El importe de Tarjetas no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If Decimal.Parse(Me.txtTransferenciaBancaria.Text) < 0 Then
         MessageBox.Show("El importe de Transferencia Bancaria no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If chbNroOrdenDeCompra.Checked And Not bscNroOrdenDeCompra.Selecciono Then
         bscNroOrdenDeCompra.Select()
         ShowMessage("Falta cargar el Nro. de Orden de Compra")
         Return False
      End If

      'Dejo que sea en cero, porque si aplica una NC y FACT puede quedar en cero.
      'If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
      '   MessageBox.Show("No se calcularon los montos de la operación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Return False
      'End If

      'valida que ningun comprobante tenga fecha de emisión posterior a la fecha de emisión del recibo
      If Not Reglas.Publicos.CtaCteProv.CtaCteProveedoresPermitirComprobantesEmisionPosterior Then
         Dim FechaHoraAControlar As Date
         If Me.dtpFecha.Value.Date = Date.Now.Date Then
            FechaHoraAControlar = DateTime.Now.AddMinutes(1) 'Para que no queden silimar (en segundos) a comprobantes automaticos
         Else
            'Toma la fecha y le coloco la hora/min/seg actual porque pudo generar comprobantes automaticos y quedan igual o bien generarlos desde facturacion.
            FechaHoraAControlar = Me.dtpFecha.Value.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second)
         End If

         Dim ent As Entidades.CuentaCorrienteProvPago
         For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1
            ent = Me._ComprobantesGrilla(i)
            If ent.Fecha > FechaHoraAControlar Then
               MessageBox.Show("El Comprobante " & ent.TipoComprobante.IdTipoComprobante & " '" & ent.Letra & "' " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString() & ", fué Emitido el " & ent.Fecha.ToString("dd/MM/yyyy HH:mm:ss") & ", posterior a la Emisión del Pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Return False
            End If
         Next
      End If

      'SPC: Por el momento no se puede generar pagos a cuenta al proveedor se le retiene.
      If New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesPag.SelectedValue.ToString()).GrabaLibro AndAlso (_proveedorGrilla.EsPasibleRetencion Or _proveedorGrilla.EsPasibleRetencionIVA) Then
         'Si imputo comprobantes y la diferencia es cero, significa que aplico todo.
         If Me.dgvComprobantes.RowCount > 0 And Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
            MessageBox.Show("Si al proveedor se le retiene Ganancias o IVA NO es posible generarle un anticipo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      End If

      'valida si se el importe que paga es mayor al importe de los comprobantes.
      If Decimal.Parse(Me.txtAnticipo.Text) > 0 Then
         If ShowPregunta(String.Format("¿Esta seguro de generar un anticipo de {0} a favor nuestro?", txtAnticipo.Text)) = Windows.Forms.DialogResult.No Then
            Return False
         End If
      End If

      Dim TipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
      TipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesPag.SelectedValue.ToString())
      Dim ImporteMinimo As Decimal = TipoComprobante.ImporteMinimo
      Dim ImporteTope As Decimal = TipoComprobante.ImporteTope

      Select Case True
         Case ImporteTope = 0 And Decimal.Parse(Me.txtTotalPagos.Text.ToString()) <> 0
            MessageBox.Show("El Tipo de Recibo Solo Permite Total en Cero (Aplicar Comprobantes entre SI).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalPagos.Text.ToString()) = 0
            MessageBox.Show("El Tipo de Recibo NO Permite Total en Cero (Debe Aplicar Comprobantes).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case ImporteTope < 0 And Decimal.Parse(Me.txtTotalPagos.Text.ToString()) > 0
            MessageBox.Show("El Tipo de Recibo Solo Permite Total en Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case Decimal.Parse(Me.txtTotalPagos.Text.ToString()) < ImporteMinimo
            MessageBox.Show("El Importe Total es Menor al Importe Minimo Permitido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case Decimal.Parse(Me.txtTotalPagos.Text.ToString()) > ImporteTope
            MessageBox.Show("El Importe Total es Mayor al Importe Maximo Permitido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case Else
      End Select

      If cmbTiposComprobantesPag.SelectedItem IsNot Nothing AndAlso
    DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).ImporteTope > 0 AndAlso
    Decimal.Parse(txtTotalPagos.Text) < 0 And Decimal.Parse(txtTotalComprobantes.Text) = 0 Then
         If MessageBox.Show(String.Format("¿Está seguro que desea generar un {0} con importe negativo sin aplicar comprobantes?",
                                          DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante),
                            Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Return False
         End If
      End If

      Return True

   End Function

   Private Sub GrabarComprobante()
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      If Decimal.Parse(txtDiferencia.Text) <> 0 Then
         ShowMessage("La diferencia debe ser cero")
         Return
      End If

      'Le quito el Foco al campo que lo tenga, porque podria ser uno de valor (pesos, transferencia) y que no haya dado enter.
      Me.txtObservacion.Focus()

      CalcularTotales()
      If Not tsbGrabar.Enabled Then Return

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

      If ValidarComprobante() Then

         tsbGrabar.Enabled = False


         Dim oCtaCteProv = GetCtaCteProv(conciliado)

         Dim rCtaCteProv = New Reglas.CuentasCorrientesProv()
         rCtaCteProv.Insertar(oCtaCteProv, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

         MessageBox.Show("Se ingreso el Pago número " & oCtaCteProv.NumeroComprobante,
                           Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         TryCatched(
         Sub()
            'Por ahora pregunto aca, aunque podria ser en la funcion abajo.
            If oCtaCteProv.TipoComprobante.Imprime Or Publicos.VisualizaPagoAProveedor Then
               rCtaCteProv = New Reglas.CuentasCorrientesProv()
               oCtaCteProv = rCtaCteProv.GetUna(oCtaCteProv.IdSucursal, oCtaCteProv.Proveedor.IdProveedor,
                                                oCtaCteProv.TipoComprobante.IdTipoComprobante,
                                                oCtaCteProv.Letra, oCtaCteProv.CentroEmisor,
                                                oCtaCteProv.NumeroComprobante)

               Dim ir = New PagosImprimir()
               ir.ImprimirPago(oCtaCteProv, Publicos.VisualizaPagoAProveedor)
            End If

            If Reglas.Publicos.RetieneGanancias Then
               If oCtaCteProv.Retenciones.Count > 0 Then
                  Dim ret As RetencionImprimir = New RetencionImprimir()
                  ret.ImprimirRetencion(oCtaCteProv)
               End If
               'If _proveedorGrilla.EsPasibleRetencion Then
               'End If
            End If
         End Sub)

         Nuevo()

      End If

   End Sub

   Private Function GetCtaCteProv(conciliado As Boolean) As Entidades.CuentaCorrienteProv

      Dim oCtaCteProv As Entidades.CuentaCorrienteProv = New Entidades.CuentaCorrienteProv()

      With oCtaCteProv

         .TipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesPag.SelectedValue.ToString())

         'GAR: 16/02/2016
         'Debe respetar lo del combo en la linea anterior.
         'If .TipoComprobante.GrabaLibro Then
         '   .TipoComprobante = New Reglas.TiposComprobantes().GetUno(Entidades.TipoComprobante.Tipos.PAGO.ToString())
         'Else
         '   .TipoComprobante = New Reglas.TiposComprobantes().GetUno(Entidades.TipoComprobante.Tipos.PAGOPROV.ToString())
         'End If
         '-------------------------

         .CentroEmisor = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante).CentroEmisor

         .Letra = Me.txtLetraPago.Text

         'Actualiza la fecha de hoy, si se dejo la pantalla abierta mucho tiempo
         If Me.dtpFecha.Value.Date = Date.Now.Date Then
            .Fecha = DateTime.Now.AddMinutes(1) 'Para que no queden silimar (en segundos) a comprobantes automaticos
         Else
            'Toma la fecha y le coloco la hora/min/seg actual porque pudo generar comprobantes automaticos y quedan igual o bien generarlos desde facturacion.
            .Fecha = Me.dtpFecha.Value.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second)
         End If

         .FechaVencimiento = .Fecha

         .FormaPago = New Reglas.VentasFormasPago().GetUna("COMPRAS", True) 'Contado

         'cargo el Proveedor
         .Proveedor = Me._proveedorGrilla

         .Observacion = Me.txtObservacion.Text
         .RefProveedor = Me.txtRefProveedores.Text

         'cargo valores del comprobante
         .ImporteTotal = Decimal.Parse(Me.txtTotalPagos.Text)

         'cargo los comprobantes
         .Pagos = Me._ComprobantesGrilla

         'cargo el efectivo para tenerlo discriminado
         .ImportePesos = Decimal.Parse(Me.txtEfectivo.Text)
         '  .ImporteDolares = 0
         .ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text)
         .ImporteTickets = Decimal.Parse(Me.txtTickets.Text)
         .ImporteDolares = If(IsNumeric(txtImporteDolares.Text), Decimal.Parse(txtImporteDolares.Text), 0)
         .CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text.ToString())


         If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And (Me.bscCuentaBancariaTransfBanc.Selecciono Or Not String.IsNullOrEmpty(bscCodigoCuentaBancariaTransfBanc.Text)) Then
            .ImporteTransfBancaria = Decimal.Parse(Me.txtTransferenciaBancaria.Text)
            .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
            .FechaTransferencia = Me.dtpFechaTransferencia.Value.Date
            .Conciliado = conciliado
         End If

         If Not _transferencias.AnySecure() AndAlso .ImporteTransfBancaria <> 0 Then
            If _transferencias Is Nothing Then _transferencias = New List(Of Entidades.CuentaCorrienteProvTransferencia)
            _transferencias.Add(New Entidades.CuentaCorrienteProvTransferencia With
                                   {
                                       .IdCuentaBancaria = oCtaCteProv.CuentaBancariaTransfBanc.IdCuentaBancaria,
                                       .Orden = _transferencias.MaxSecure(Function(t) t.Orden).IfNull() + 1,
                                       .Importe = oCtaCteProv.ImporteTransfBancaria
                                   })
         Else
            If _transferencias.Count > 0 Then
               If .ImporteTransfBancaria <> _transferencias(0).Importe Then
                  _transferencias = New List(Of Entidades.CuentaCorrienteProvTransferencia)
                  _transferencias.Add(New Entidades.CuentaCorrienteProvTransferencia With
                                      {
                                          .IdCuentaBancaria = oCtaCteProv.CuentaBancariaTransfBanc.IdCuentaBancaria,
                                          .Orden = _transferencias.MaxSecure(Function(t) t.Orden).IfNull() + 1,
                                          .Importe = oCtaCteProv.ImporteTransfBancaria
                                      })
               End If
            End If
         End If
         .CCTransferencias = _transferencias

         .ImporteRetenciones = Decimal.Parse(Me.txtRetenciones.Text)

         .PromedioDiasPago = txtPromPagosDiasPromedioPago.ValorNumericoPorDefecto(0D)

         'cargo los cheques emitidos (propios)
         .ChequesPropios = Me._chequesPropios

         'cargo los cheques de terceros
         .ChequesTerceros = Me._chequesTerceros

         'cargo la caja
         .CajaDetalle.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

         'cargo datos generales del comprobante
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre

         '# Seteo el valor de AjusteManual antes de grabar
         _percepciones.All(Function(x)
                              x.AjusteManual = Me.chbAjusteManual.Checked
                              Return True
                           End Function)

         .Retenciones = Me._percepciones

         .NumeroOrdenCompra = bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L)

      End With
      Return oCtaCteProv

   End Function

   Private Sub LimpiarCamposComprobante()
      If Me.cmbTiposComprobantes.Items.Count > 0 Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      End If
      Me.txtLetra.Text = ""
      Me.txtEmisor.Text = ""
      Me.bscComprobante.Text = ""
      Me.bscComprobante.FilaDevuelta = Nothing
      Me.txtCuota.Text = ""
      Me.dtpComprobanteEmision.Value = Date.Now
      Me.dtpComprobanteVencimiento.Value = Date.Now
      Me.txtImporte.Text = "0.00"
      Me.txtSaldo.Text = "0.00"
      Me.txtPaga.Text = "0.00"
      Me.txtDescuentoRecargoPorc.Text = "0.00"
      Me.txtDescuentoRecargoImporte.Text = "0.00"

   End Sub

   'Private Sub LimpiarCamposChequesTerceros()
   '   Me.bscBancoTercero.Text = ""
   '   Me.bscBancoTercero.FilaDevuelta = Nothing
   '   Me.dtpFechaCobroTercero.Value = DateTime.Now
   '   Me.dtpFechaEmisionTercero.Value = DateTime.Now
   '   Me.txtImporteChequeTercero.Text = "0.00"
   '   Me.txtNroChequeTercero.Text = "0"
   '   Me.txtCodPostalChequeTercero.Text = "0"
   '   Me.txtSucursalBancoTercero.Text = "0"
   '   Me.txtTitularChequeTercero.Text = ""
   'End Sub

   Private Sub CalcularComprobantes()

      Dim TotalNCND As Decimal = 0

      Dim bruto As Decimal = 0

      If Reglas.Publicos.RetieneGanancias Then
         If Not Me._proveedorGrilla Is Nothing Then
            If Me._proveedorGrilla.EsPasibleRetencion Or
                  Me._proveedorGrilla.EsPasibleRetencionIVA Or
                     Me._proveedorGrilla.EsPasibleRetencionIIBB Or
                        _proveedorGrilla.RegimenIIBBComplem.IdRegimen > 0 Then
               Me.RealizarRetenciones()
            End If
            'If Me._proveedorGrilla.EsPasibleRetencionIVA Then
            '   Me.RealizarRetencionesIVA()
            'End If
         End If
      End If

      For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1

         bruto += Me._ComprobantesGrilla(i).Paga

         If Not _ComprobantesGrilla(i).TipoComprobante.GrabaLibro AndAlso tsbGenerarNCND.Visible Then
            TotalNCND += Me._ComprobantesGrilla(i).DescuentoRecargo
         End If

      Next

      'If Me.tsbGenerarNCND.Visible Then
      '   bruto += TotalNCND
      'End If

      bruto = Decimal.Round(bruto, 2)

      Me.txtTotalComprobantes.Text = bruto.ToString("N2")
      Me.CalcularPagos()

      If Not chbAnticipo.Checked Then
         txtAnticipo.Text = Math.Max(Decimal.Parse(Me.txtTotalPagos.Text) - bruto, 0).ToString("N2")
         RealizarRetenciones()
      End If

      Me.txtDiferencia.Text = (bruto + Decimal.Parse(txtAnticipo.Text) - Decimal.Parse(Me.txtTotalPagos.Text)).ToString("N2")

      Me.txtTotalNCND.Text = TotalNCND.ToString("#,##0.00")
      '  Me.txtTotalPago.Text = rete.ToString("#,##0.00")

      Me.VerificarGrabarImprimir()

   End Sub

   Private Sub VerificarGrabarImprimir()

      'Pudo generar un comprobante luego de levantar la pantalla
      'carga el saldo del Proveedor de la cuenta corriente
      Dim oCtaCte As Eniac.Reglas.CuentasCorrientesProv = New Eniac.Reglas.CuentasCorrientesProv()
      If Me._proveedorGrilla IsNot Nothing Then
         Me.txtSaldoGeneral.Text = oCtaCte.GetSaldoProveedor(actual.Sucursal.Id, Me._proveedorGrilla).ToString("#,##0.00")

         If Reglas.Publicos.CtaCteProv.CtaCteProveedoresSeparar Then
            ' Dim grabaLibro As String = IIf(New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesPag.SelectedValue.ToString()).GrabaLibro, "SI", "NO").ToString()
            Dim strComprobantesAsociados As String = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesPag.SelectedValue.ToString()).ComprobantesAsociados
            Me.txtSaldoActual.Text = oCtaCte.GetSaldoProveedor(actual.Sucursal.Id, Me._proveedorGrilla, , , , strComprobantesAsociados).ToString("#,##0.00")
         Else
            Me.txtSaldoActual.Text = Me.txtSaldoGeneral.Text
         End If
      End If

      Dim anticipo As Decimal = Decimal.Parse(Me.txtAnticipo.Text)
      anticipo *= -1 'Lo doy vuelta porque las validaciones estaban pensadas para la Deferencia negativa y ahora cambió el signo en pantalla.



      'Si imputo comprobantes y la diferencia es cero, significa que aplico todo.
      If Me.dgvComprobantes.RowCount > 0 And anticipo = 0 Then
         Me.tsbGrabar.Enabled = True
         'Si aplico mas pagos que comprobantes y NO tiene saldo 
      ElseIf anticipo < 0 And Decimal.Parse(Me.txtSaldoActual.Text) <= 0 Then
         Me.tsbGrabar.Enabled = True
         'Si aplico mas pagos que comprobantes y Aplico todos los comprobantes pendientes
      ElseIf anticipo < 0 And Decimal.Parse(Me.txtTotalComprobantes.Text) = Decimal.Parse(Me.txtSaldoActual.Text) Then
         Me.tsbGrabar.Enabled = True
         'Si aplico Pagos y tiene habilitado la posibilidad de Ancitipos aun con Comprobantes Pendientes
      ElseIf anticipo <= 0 And Decimal.Parse(Me.txtTotalPagos.Text) > 0 And Reglas.Publicos.CtaCteProv.PermitePagoSinAplicarComprobantes Then
         Me.tsbGrabar.Enabled = True
      Else
         Me.tsbGrabar.Enabled = False
      End If

      If Me.dgvComprobantes.RowCount > 0 And Decimal.Parse(Me.txtDiferencia.Text) = 0 And tsbGenerarNCND.Visible Then
         Me.tsbGrabar.Enabled = True
      End If

      Me.tsbGenerarNCND.Enabled = (Decimal.Parse(Me.txtTotalNCND.Text) <> 0) And Me.tsbGrabar.Enabled = True
      Me.tsbGrabar.Visible = Not Me.tsbGenerarNCND.Enabled Or Not Me.tsbGenerarNCND.Visible

      If cmbTiposComprobantesPag.SelectedItem IsNot Nothing AndAlso
     DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).ImporteTope > 0 AndAlso
     Decimal.Parse(txtTotalPagos.Text) < 0 And Decimal.Parse(txtTotalComprobantes.Text) = 0 Then
         tsbGrabar.Enabled = True
      End If

   End Sub

   Private Sub CalcularPagos()
      If Not Reglas.Publicos.CtaCteProv.RetencionesGananciasCalculoRecursivo Then
         CalcularPagos1()
      Else
         For i = 1 To Reglas.Publicos.CtaCteProv.RetencionesGananciasCalculoRecursivoCantidadRepeticiones
            CalcularPagos1()
         Next
      End If

   End Sub
   Private Sub CalcularPagos1()
      Dim ImporteDias As Decimal = 0

      Dim dolaresConvertidos = txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D)
      Dim transferenciasConv = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)
      If bscCuentaBancariaTransfBanc.Selecciono AndAlso bscCuentaBancariaTransfBanc.FilaDevuelta IsNot Nothing Then
         Dim idMoneda = Integer.Parse(bscCuentaBancariaTransfBanc.FilaDevuelta.Cells("IdMoneda").Value.ToString())
         If idMoneda = Entidades.Moneda.Dolar Then
            transferenciasConv *= txtCotizacionDolar.ValorNumericoPorDefecto(0D)
         End If
      End If

      If Not chbAnticipo.Checked Then

         Dim p = _chequesPropios.Sum(Function(dr) dr.Importe) +
                 _chequesTerceros.Sum(Function(dr) dr.Importe)

         p = Decimal.Round(p, 2) +
             txtEfectivo.ValorNumericoPorDefecto(0D) +
             txtTarjetas.ValorNumericoPorDefecto(0D) +
             txtTickets.ValorNumericoPorDefecto(0D) +
             transferenciasConv +
             txtRetenciones.ValorNumericoPorDefecto(0D) +
             dolaresConvertidos
         txtAnticipo.Text = Math.Max(p - txtTotalComprobantes.ValorNumericoPorDefecto(0D), 0).ToString("N2")
      End If
      RealizarRetenciones()

      Dim totcheqprop = _chequesPropios.Sum(Function(dr) dr.Importe)
      ImporteDias += _chequesPropios.Sum(Function(dr) dr.ImporteDias)

      Dim totcheq3ros = _chequesTerceros.Sum(Function(dr) dr.Importe)
      ImporteDias += _chequesTerceros.Sum(Function(dr) dr.ImporteDias)

      Dim pago = Decimal.Round(totcheqprop + totcheq3ros, 2)


      pago += txtEfectivo.ValorNumericoPorDefecto(0D)
      ImporteDias += txtEfectivo.ValorNumericoPorDefecto(0D)
      pago += txtTarjetas.ValorNumericoPorDefecto(0D)
      ImporteDias += txtTarjetas.ValorNumericoPorDefecto(0D)
      pago += txtTickets.ValorNumericoPorDefecto(0D)
      ImporteDias += txtTickets.ValorNumericoPorDefecto(0D)
      pago += transferenciasConv
      ImporteDias += (transferenciasConv * DateDiff(DateInterval.Day, dtpFecha.Value.Date, dtpFechaTransferencia.Value.Date))
      pago += txtRetenciones.ValorNumericoPorDefecto(0D)
      pago += dolaresConvertidos
      ImporteDias += dolaresConvertidos

      txtTotalPagos.Text = pago.ToString("N2")
      txtDiferencia.Text = (txtTotalComprobantes.ValorNumericoPorDefecto(0D) + txtAnticipo.ValorNumericoPorDefecto(0D) - pago).ToString("N2")
      txtChequesTerceros.Text = totcheq3ros.ToString("N2")
      txtChequesTerceros2.Text = totcheq3ros.ToString("N2")
      txtChequesPropios.Text = totcheqprop.ToString("N2")

      '-- Fecha Promedio Pagos.- -------------
      If pago <> 0 Then
         txtFechaPromedioPagos.Text = (ImporteDias / pago).ToString("N2")
      End If
      Dim calculo = CalculoPromedioPago()
      txtFechaPromedioPagos.SetValor(calculo.DiasPromedioPago)

      '- Decimal.Parse(Me.txtRetenciones.Text)
      VerificarGrabarImprimir()
   End Sub

   Private Function CalculoPromedioPago() As Reglas.CalculosPagoProvResult
      Dim calculo = Reglas.CalculosPagoProv.
                        CalcularPromedioPago(dtpFecha.Value, _ComprobantesGrilla,
                                             txtEfectivo.ValorNumericoPorDefecto(0D),
                                             txtImporteDolares.ValorNumericoPorDefecto(0D),
                                             txtTarjetas.ValorNumericoPorDefecto(0D),
                                             txtTickets.ValorNumericoPorDefecto(0D),
                                             txtTransferenciaBancaria.ValorNumericoPorDefecto(0D),
                                             dtpFechaTransferencia.Value,
                                             _chequesPropios, _chequesTerceros, _percepciones)
      ugPromPagoComprobantes.DataSource = calculo.Comprobantes
      ugPromPagoPagos.DataSource = calculo.Pagos

      ugPromPagoComprobantes.AgregarTotalesSuma({"ImporteTotal", "Saldo", "Paga", "ImportePonderado"})
      ugPromPagoPagos.AgregarTotalesSuma({"Importe", "ImportePonderado"})

      txtPromPagosDiasPromedioEmision.SetValor(calculo.DiasPromedioEmision)
      txtPromPagosFechaPromedioEmision.SetValor(calculo.FechaPromedioComprobantes)

      txtPromPagosDiasPromedioPago.SetValor(calculo.DiasPromedioPago)
      txtPromPagosFechaPromedioPago.SetValor(calculo.FechaPromedioPago)

      Return calculo
   End Function

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      Me.txtDireccion.Text = dr.Cells("DireccionProveedor").Value.ToString()
      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      'Me.txtTelefono.Text = dr.Cells("TelefonoProveedor").Value.ToString()
      Me.txtCategoriaFiscal.Text = dr.Cells("NombreCategoriaFiscal").Value.ToString()
      Me.txtCategoriaFiscal.Tag = dr.Cells("IdCategoriaFiscal").Value

      'Si el Pago emite numeracion X siempre debe salir asi, sino, debe tomar la letra del Cliente.
      If Me.txtLetraPago.Text <> "X" And Me.txtLetraPago.Text <> "R" Then
         Me.txtLetraPago.Text = dr.Cells("LetraFiscal").Value.ToString()
      End If

      Me.tbcDetalle.Enabled = True
      Me.bscProveedor.Permitido = False
      Me.bscCodigoProveedor.Permitido = False
      Me.btnSeleccionMultiple.Enabled = True

      Me.CambiarEstadoControlesDetalle(True)

      Dim oProveedor As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores()
      Me._proveedorGrilla = oProveedor.GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))
      Me.btnImputAutomat.Enabled = True

      'carga el saldo del Proveedor de la cuenta corriente
      Dim oCtaCte As Eniac.Reglas.CuentasCorrientesProv = New Eniac.Reglas.CuentasCorrientesProv()

      Me.txtSaldoGeneral.Text = oCtaCte.GetSaldoProveedor(actual.Sucursal.Id, Me._proveedorGrilla).ToString("#,##0.00")

      If Reglas.Publicos.CtaCteProv.CtaCteProveedoresSeparar Then
         ' Dim grabaLibro As String = IIf(New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesPag.SelectedValue.ToString()).GrabaLibro, "SI", "NO").ToString()
         Dim strComprobantesAsociados As String = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesPag.SelectedValue.ToString()).ComprobantesAsociados
         Me.txtSaldoActual.Text = oCtaCte.GetSaldoProveedor(actual.Sucursal.Id, Me._proveedorGrilla, , , , strComprobantesAsociados).ToString("#,##0.00")
      Else
         Me.txtSaldoActual.Text = Me.txtSaldoGeneral.Text
      End If

      cmbRegimenGanancias.Visible = False
      cmbRegimenGanancias.LabelAsoc.Visible = cmbRegimenGanancias.Visible
      cmbRegimenIVA.Visible = False
      cmbRegimenIVA.LabelAsoc.Visible = cmbRegimenIVA.Visible
      cmbRegimenIIBB.Visible = False
      cmbRegimenIIBB.LabelAsoc.Visible = cmbRegimenIIBB.Visible
      cmbRegimenIIBBComplem.Visible = False
      cmbRegimenIIBBComplem.LabelAsoc.Visible = cmbRegimenIIBBComplem.Visible

      If Reglas.Publicos.RetieneGanancias Then
         cmbRegimenGanancias.Visible = _proveedorGrilla.EsPasibleRetencion
         cmbRegimenGanancias.LabelAsoc.Visible = cmbRegimenGanancias.Visible
         cmbRegimenIVA.Visible = _proveedorGrilla.EsPasibleRetencionIVA
         cmbRegimenIVA.LabelAsoc.Visible = cmbRegimenIVA.Visible
         cmbRegimenIIBB.Visible = _proveedorGrilla.EsPasibleRetencionIIBB
         cmbRegimenIIBB.LabelAsoc.Visible = cmbRegimenIIBB.Visible
         cmbRegimenIIBBComplem.Visible = _proveedorGrilla.RegimenIIBBComplem.IdRegimen > 0
         cmbRegimenIIBBComplem.LabelAsoc.Visible = cmbRegimenIIBBComplem.Visible
      End If

      With cmbRegimenGanancias
         .Items.Clear()
         If _proveedorGrilla.Regimen IsNot Nothing Then .Items.Add(_proveedorGrilla.Regimen)
         If _proveedorGrilla.RegimenGan IsNot Nothing Then .Items.Add(_proveedorGrilla.RegimenGan)
         .DisplayMember = Entidades.Regimen.Columnas.ConceptoRegimen.ToString()
         .ValueMember = Entidades.Regimen.Columnas.IdRegimen.ToString()
         If .Items.Count > 0 Then .SelectedIndex = 0
      End With

      With cmbRegimenIVA
         .Items.Clear()
         If _proveedorGrilla.RegimenIVA IsNot Nothing Then .Items.Add(_proveedorGrilla.RegimenIVA)
         .DisplayMember = Entidades.Regimen.Columnas.ConceptoRegimen.ToString()
         .ValueMember = Entidades.Regimen.Columnas.IdRegimen.ToString()
         If .Items.Count > 0 Then .SelectedIndex = 0
      End With

      With cmbRegimenIIBB
         .Items.Clear()
         If _proveedorGrilla.RegimenIIBB IsNot Nothing Then .Items.Add(_proveedorGrilla.RegimenIIBB)
         .DisplayMember = Entidades.Regimen.Columnas.ConceptoRegimen.ToString()
         .ValueMember = Entidades.Regimen.Columnas.IdRegimen.ToString()
         If .Items.Count > 0 Then .SelectedIndex = 0
      End With

      With cmbRegimenIIBBComplem
         .Items.Clear()
         If _proveedorGrilla.RegimenIIBBComplem IsNot Nothing Then .Items.Add(_proveedorGrilla.RegimenIIBBComplem)
         .DisplayMember = Entidades.Regimen.Columnas.ConceptoRegimen.ToString()
         .ValueMember = Entidades.Regimen.Columnas.IdRegimen.ToString()
         If .Items.Count > 0 Then .SelectedIndex = 0
      End With

      'controlo los focos y si tengo que solicitar la fecha
      If Reglas.Publicos.CtaCteProv.PagoSolicitaFecha Then
         Me.dtpFecha.Focus()
      Else
         Me.bscComprobante.Focus()
      End If

   End Sub

   'Private Sub CargarDatosBancos(dr As DataGridViewRow)
   '   Me.bscBancoTercero.Text = dr.Cells("NombreBanco").Value.ToString()
   'End Sub

   Private Sub Nuevo()
      txtTotalPagos.Enabled = True
      tbcDetalle.SelectedTab = Me.tbpComprobantes
      tbcDetalle.Enabled = True
      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Tag = Nothing
      bscProveedor.Text = String.Empty
      txtTotalComprobantes.Enabled = True
      bscProveedor.Permitido = True
      bscCodigoProveedor.Permitido = True
      txtObservacion.Text = String.Empty
      txtRefProveedores.Text = String.Empty
      _ComprobantesGrilla.Clear()
      dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
      txtLocalidad.Text = String.Empty
      'Me.txtTelefono.Text = String.Empty
      dtpFechaTransferencia.Value = Date.Now
      Me.txtTotalComprobantes.Text = "0.00"
      Me.txtDireccion.Text = String.Empty
      Me.dtpFecha.Value = DateTime.Now
      Me.txtTotalPagos.Text = "0.00"
      Me.txtSaldo.Text = String.Empty
      Me.txtLetra.Text = ""
      Me.txtEmisor.Text = ""
      Me.bscComprobante.Text = String.Empty
      Me.txtCuota.Text = ""
      Me.txtImporte.Text = "0.00"
      Me.txtPaga.Text = "0.00"
      Me.btnInsertar.Enabled = True
      Me.btnEliminar.Enabled = True

      dtpFecha.Value = DateTime.Now
      txtTotalPagos.Text = "0.00"
      txtSaldo.Text = String.Empty
      txtSaldoGeneral.Text = "0.00"
      txtLetra.Text = ""
      txtEmisor.Text = ""
      bscComprobante.Text = String.Empty
      txtCuota.Text = ""
      txtImporte.Text = "0.00"
      txtPaga.Text = "0.00"
      txtFechaPromedioPagos.Text = "0.00"
      btnInsertar.Enabled = True
      btnEliminar.Enabled = True

      If Me.cmbTiposComprobantesPag.Items.Count > 0 Then
         Me.cmbTiposComprobantesPag.SelectedIndex = -1   'Fuerzo el evento de Changed
         Me.cmbTiposComprobantesPag.SelectedIndex = 0
         'Else
         '   Me.cmbTiposComprobantesPag.SelectedIndex = -1
      End If

      'If Me._pago.LetrasHabilitadas = "X" Then
      '    Me.txtLetraPago.Text = "X"
      'Else
      '    Me.txtLetraPago.Text = String.Empty
      'End If
      Me.txtSaldoGeneral.Text = "0.00"
      Me.txtCategoriaFiscal.Text = String.Empty
      Me.tsbGrabar.Enabled = False
      Me.txtEfectivo.Text = "0.00"
      Me.txtTarjetas.Text = "0.00"
      Me.txtTickets.Text = "0.00"
      Me.txtImporteDolares.Text = "0.00"

      Me.txtTransferenciaBancaria.Text = "0.00"
      Me.bscCuentaBancariaTransfBanc.Text = ""
      Me.bscCuentaBancariaTransfBanc.FilaDevuelta = Nothing

      _transferencias.Clear()
      ugTransferenciasMultiples.ClearFilas()
      txtImporteTransferenciaMultiple.Text = "0.00"
      'txtTransferenciaBancaria.ReadOnly = False
      txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
      bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()


      Me.txtSaldoActual.Text = "0.00"
      Me._chequesPropios.Clear()
      Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()
      Me._chequesTerceros.Clear()
      Me.dgvChequesTerceros.DataSource = Me._chequesTerceros.ToArray()

      Me._percepciones.Clear()
      Me.dgvPercepciones.DataSource = Me._percepciones.ToArray()
      Me.txtRetenciones.Text = "0.00"
      txtAnticipo.Text = "0.00"
      Me.txtDiferencia.Text = "0.00"

      Me.LimpiarCamposChequePropio()

      'Me.LimpiarCamposChequesTerceros()

      Me.tbcDetalle.SelectedTab = Me.tbpComprobantes

      Me._proveedorGrilla = Nothing

      cmbRegimenGanancias.Visible = False
      cmbRegimenGanancias.LabelAsoc.Visible = False
      cmbRegimenIVA.Visible = False
      cmbRegimenIVA.LabelAsoc.Visible = False
      cmbRegimenIIBB.Visible = False
      cmbRegimenIIBB.LabelAsoc.Visible = False

      cmbRegimenIIBBComplem.Visible = False
      cmbRegimenIIBBComplem.LabelAsoc.Visible = False


      cmbRegimenGanancias.Items.Clear()
      cmbRegimenIVA.Items.Clear()
      cmbRegimenIIBB.Items.Clear()
      cmbRegimenIIBBComplem.Items.Clear()

      Me.CambiarEstadoControlesDetalle(False)

      'Me.cmbCajas.SelectedIndex = 0
      Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")

      Me.chbAjusteManual.Checked = False

      Me.bscCodigoProveedor.Focus()

      tsbGenerarNCND.Visible = Reglas.Publicos.CtaCteProv.RealizaNCNDAutomaticaDescRec
      tsbGenerarNCND.Enabled = False

      chbNroOrdenDeCompra.Checked = False

   End Sub

   Private Function ValidarInsertarComprobante() As Boolean

      'Positivos: Facturas, Notas de Debito, otros.
      If Decimal.Parse(Me.txtImporte.Text) > 0 Then

         If Decimal.Parse(Me.txtPaga.Text) <= 0 Then
            MessageBox.Show("El importe a cancelar NO puede ser menor o igual a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPaga.Focus()
            Return False
         End If

         If Decimal.Parse(Me.txtPaga.Text) > Decimal.Parse(Me.txtSaldo.Text) Then
            MessageBox.Show("No puede pagar mas de lo que tiene como saldo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPaga.Focus()
            Return False
         End If

         'Nota de Credito
      Else

         If Decimal.Parse(Me.txtPaga.Text) >= 0 Then
            MessageBox.Show("El importe a cancelar NO puede ser mayor o igual a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPaga.Focus()
            Return False
         End If

         If Decimal.Parse(Me.txtPaga.Text) < Decimal.Parse(Me.txtSaldo.Text) Then
            MessageBox.Show("No puede pagar mas de lo que tiene como saldo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPaga.Focus()
            Return False
         End If
      End If

      If Math.Abs(Decimal.Parse(Me.txtDescuentoRecargoPorc.Text.ToString())) >= 100 Then
         MessageBox.Show("El porcentaje no es correcto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtDescuentoRecargoPorc.Focus()
         Return False
      End If
      'If Me._ComprobantesGrilla.Count = cant Then
      '   MessageBox.Show("No puede ingresar mas de " & cant.ToString() & " productos para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.btnInsertar.Focus()
      '   Return False
      'End If

      'controlo que no se repita el producto ingresado
      Dim ent As Entidades.CuentaCorrienteProvPago
      For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1
         ent = Me._ComprobantesGrilla(i)
         If ent.IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString() And
                  ent.Letra = Me.txtLetra.Text And
                  ent.CentroEmisor = Integer.Parse(Me.txtEmisor.Text) And
                  ent.NumeroComprobante = Long.Parse(Me.bscComprobante.Text) And
                  ent.Cuota = Integer.Parse(Me.txtCuota.Text) Then
            MessageBox.Show("La cuota de este comprobante ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      Next

      Return True

   End Function

   Private Sub CargarComprobante(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         cmbTiposComprobantes.SelectedValue = dr.Cells("IdTipoComprobante").Value.ToString()
         txtLetra.Text = dr.Cells("Letra").Value.ToString()
         txtEmisor.Text = dr.Cells("Emisor").Value.ToString()
         bscComprobante.Text = dr.Cells("Numero").Value.ToString()
         txtCuota.Text = dr.Cells("Cuota").Value.ToString()
         dtpComprobanteEmision.Value = Date.Parse(dr.Cells("Fecha").Value.ToString())
         dtpComprobanteVencimiento.Value = Date.Parse(dr.Cells("FechaVencimiento").Value.ToString())
         txtImporte.Text = Decimal.Parse(dr.Cells("Importe").Value.ToString()).ToString("N2")

         Dim saldo = Decimal.Parse(dr.Cells("Saldo").Value.ToString())
         Dim porcDR = If(Reglas.Publicos.CtaCteProv.ImputacionAutomaticaDRFormaPago, Decimal.Parse(dr.Cells("Porcentaje").Value.ToString()), 0D)
         Dim impoDR = saldo * porcDR / 100

         txtSaldo.Text = saldo.ToString("N2")
         txtDescuentoRecargoPorc.Text = porcDR.ToString("N2")
         txtDescuentoRecargoImporte.Text = impoDR.ToString("N2")

         '_PagaOriginal = Decimal.Parse(Me.txtSaldo.Text.ToString())
         txtPaga.Text = (saldo + impoDR).ToString("N2")
         ObservacionCtaCte = dr.Cells("Observacion").Value.ToString()

         txtPaga.Focus()
      End If
   End Sub

   Private Sub CargarComprobanteCompleto(dr As DataGridViewRow)


      cmbTiposComprobantes.SelectedValue = dr.Cells("TipoComprobante").Value.ToString()
      txtEmisor.Text = dr.Cells("CentroEmisor").Value.ToString()
      txtLetra.Text = dr.Cells("Letra").Value.ToString()
      bscComprobante.Text = dr.Cells("NroComprobante").Value.ToString()

      'Dim oComprobantes As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv

      'Me.bscComprobante.Datos = oComprobantes.GetComprobante(actual.Sucursal.IdSucursal, dr.Cells("TipoComprobante").Value.ToString(), dr.Cells("Letra").Value.ToString(), _
      '                                                       Integer.Parse(dr.Cells("CentroEmisor").Value.ToString()), Long.Parse(dr.Cells("NroComprobante").Value.ToString()))
      'Me.bscComprobante.PresionarBoton()
      bscComprobante.Selecciono = True

      txtCuota.Text = dr.Cells("Cuota").Value.ToString()
      dtpComprobanteEmision.Text = dr.Cells("Fecha").Value.ToString()
      dtpComprobanteVencimiento.Text = dr.Cells("FechaVencimiento").Value.ToString()
      txtImporte.Text = Decimal.Round(Decimal.Parse(dr.Cells("Importe").Value.ToString()), 2).ToString("N2")
      txtSaldo.Text = dr.Cells("Stock").Value.ToString()
      txtPaga.Text = dr.Cells("Paga").Value.ToString()
      txtDescuentoRecargoPorc.Text = dr.Cells("DescuentoRecargoPorc").Value.ToString()
      txtDescuentoRecargoImporte.Text = dr.Cells("DescuentoRecargo").Value.ToString()
      If dr.Cells("Observacion").Value IsNot Nothing Then
         ObservacionCtaCte = dr.Cells("Observacion").Value.ToString()
      End If

   End Sub

   Private Sub InsertarComprobanteGrilla()
      Dim lineaDetalle = New Entidades.CuentaCorrienteProvPago()

      With lineaDetalle
         .TipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)
         .Letra = txtLetra.Text
         .CentroEmisor = txtEmisor.ValorNumericoPorDefecto(0S)
         .NumeroComprobante = bscComprobante.Text.ValorNumericoPorDefecto(0L)
         .Cuota = txtCuota.ValorNumericoPorDefecto(0I)
         .Fecha = dtpComprobanteEmision.Value
         .FechaVencimiento = dtpComprobanteVencimiento.Value
         .ImporteCuota = txtImporte.ValorNumericoPorDefecto(0D)
         .SaldoCuota = txtSaldo.ValorNumericoPorDefecto(0D)
         .Paga = txtPaga.ValorNumericoPorDefecto(0D)
         .DescuentoRecargoPorc = txtDescuentoRecargoPorc.ValorNumericoPorDefecto(0D)
         .DescuentoRecargo = txtDescuentoRecargoImporte.ValorNumericoPorDefecto(0D)
         .IdSucursal = actual.Sucursal.IdSucursal
         .Usuario = actual.Nombre

         If chbMostrarObs.Checked Then
            .Observacion = ObservacionCtaCte
         End If

      End With
      _ComprobantesGrilla.Add(lineaDetalle)

      dgvComprobantes.DataSource = _ComprobantesGrilla.ToArray()
      If dgvComprobantes.Rows.Count > 0 Then
         dgvComprobantes.FirstDisplayedScrollingRowIndex = dgvComprobantes.Rows.Count - 1
      End If

      dgvComprobantes.Refresh()
      LimpiarCamposComprobante()
      CalcularComprobantes()

      'tsbGrabar.Enabled = True
   End Sub

   Private Sub RealizarRetenciones()

      If Reglas.Publicos.RetieneGanancias Then
         If Not Me.chbAjusteManual.Checked Then

            Dim ret As Reglas.RetencionesCompras = New Reglas.RetencionesCompras()

            Dim Pagos As Decimal = 0

            ' # Valido el tipo de comprobante para saber si debo calcular las Retenciones o no.
            If Me.cmbTiposComprobantesPag.Items.Count > 0 Then
               If DirectCast(Me.cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
                  For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1
                     'Solo contempla Facturas y NCRED en blanco
                     If Me._ComprobantesGrilla(i).TipoComprobante.GrabaLibro Then
                        Pagos += Me._ComprobantesGrilla(i).Paga
                     End If
                  Next
                  Pagos += Decimal.Parse(txtAnticipo.Text)
               End If
            End If

            If Pagos > 0 Then
               Dim regimenGan As Entidades.Regimen = Nothing
               Dim regimenIVA As Entidades.Regimen = Nothing
               Dim regimenIIBB As Entidades.Regimen = Nothing
               Dim regimenIIBBC As Entidades.Regimen = Nothing

               If cmbRegimenGanancias.SelectedItem IsNot Nothing AndAlso TypeOf (cmbRegimenGanancias.SelectedItem) Is Entidades.Regimen Then regimenGan = DirectCast(cmbRegimenGanancias.SelectedItem, Entidades.Regimen)
               If cmbRegimenIVA.SelectedItem IsNot Nothing AndAlso TypeOf (cmbRegimenIVA.SelectedItem) Is Entidades.Regimen Then regimenIVA = DirectCast(cmbRegimenIVA.SelectedItem, Entidades.Regimen)
               If cmbRegimenIIBB.SelectedItem IsNot Nothing AndAlso TypeOf (cmbRegimenIIBB.SelectedItem) Is Entidades.Regimen Then regimenIIBB = DirectCast(cmbRegimenIIBB.SelectedItem, Entidades.Regimen)
               If cmbRegimenIIBBComplem.SelectedItem IsNot Nothing AndAlso TypeOf (cmbRegimenIIBBComplem.SelectedItem) Is Entidades.Regimen Then regimenIIBBC = DirectCast(cmbRegimenIIBBComplem.SelectedItem, Entidades.Regimen)

               Dim anticipo = txtAnticipo.Text.ValorNumericoPorDefecto(0D)
               If Not Reglas.Publicos.CtaCteProv.RetencionesGananciasCalculoRecursivo Then
                  If anticipo <> 0 Then
                     anticipo -= _percepciones.Sum(Function(r) r.ImporteTotal)
                     anticipo = Math.Max(anticipo, 0)
                  End If
               End If

               Me._percepciones = ret.GetRetencionesCalculadas(Me.GetCtaCteProv(False), anticipo, regimenGan, regimenIVA, regimenIIBB, regimenIIBBC)

            Else
               Me._percepciones = New List(Of Entidades.RetencionCompra)()
            End If

            Me.dgvPercepciones.DataSource = Me._percepciones.ToArray()
         End If
      End If

      Dim rete As Decimal = 0
      For Each re As Entidades.RetencionCompra In Me._percepciones
         rete += re.ImporteTotal
      Next
      Me.txtRetenciones.Text = rete.ToString("N2")

      Me.dgvPercepciones.Refresh()

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
            .Proveedor.IdProveedor = _proveedorGrilla.IdProveedor
            .Proveedor.CodigoProveedor = _proveedorGrilla.CodigoProveedor
            '.IdCajaIngreso = Int32.Parse(cRow("IdCajaIngreso").ToString())
            .Usuario = actual.Nombre
            .IdTipoCheque = cRow("IdTipoCheque").ToString()
            .NombreTipoCheque = cRow("NombreTipoCheque").ToString()
            .NroOperacion = cRow("NroOperacion").ToString()
            .Cuit = cRow("Cuit").ToString()
            .ImporteDias = Decimal.Parse(cRow("Importe").ToString()) * DateDiff(DateInterval.Day, dtpFecha.Value.Date, Date.Parse(cRow("FechaCobro").ToString()).Date)
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

   Private Sub EliminarLineaComprobante()
      Me._ComprobantesGrilla.RemoveAt(Me.dgvComprobantes.SelectedRows(0).Index)

      Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()

      Me.CalcularComprobantes()
   End Sub

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)
      Me.btnLimpiarComprobante.Enabled = Habilitado
      Me.bscComprobante.Enabled = Habilitado
      Me.txtImporte.Enabled = Habilitado
      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado
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

   Private Sub CargarComprobantesSeleccionados(selec As List(Of Entidades.CuentaCorrienteProvPago))

      Me._ComprobantesGrilla = New List(Of Entidades.CuentaCorrienteProvPago)


      For Each v As Entidades.CuentaCorrienteProvPago In selec
         Me._ComprobantesGrilla.Add(v)

      Next

      Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla

      Me.dgvComprobantes.Refresh()

   End Sub

   Private Sub CalcularTotales()

      Dim TotalComprobantes As Decimal = 0
      Dim TotalNCND As Decimal = 0

      For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1
         TotalComprobantes += Me._ComprobantesGrilla(i).Paga

         If Not _ComprobantesGrilla(i).TipoComprobante.GrabaLibro AndAlso tsbGenerarNCND.Visible Then
            TotalNCND += Me._ComprobantesGrilla(i).DescuentoRecargo
         End If

      Next

      'Si el boton es visible es porque todavia no lo genero, entonces lo sumo para facili
      'If Me.tsbGenerarNCND.Visible Then
      '   TotalComprobantes += TotalNCND
      'End If

      Me.txtTotalComprobantes.Text = TotalComprobantes.ToString("#,##0.00")

      If Not chbAnticipo.Checked And Not _comprobanteAutomatico Then
         Me.txtAnticipo.Text = Math.Max(Decimal.Parse(Me.txtTotalPagos.Text) - Decimal.Parse(Me.txtTotalComprobantes.Text), 0).ToString("N2")
         RealizarRetenciones()
      End If
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalComprobantes.Text) + Decimal.Parse(txtAnticipo.Text) - Decimal.Parse(Me.txtTotalPagos.Text)).ToString("N2")

      Me.txtTotalNCND.Text = TotalNCND.ToString("#,##0.00")

      Me.VerificarGrabarImprimir()

   End Sub

   Private Sub CalcularTotalAPagarComprobante()

      Dim DescRec1 As Decimal

      DescRec1 = Math.Round((Decimal.Parse(Me.txtPaga.Text) * Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)) / 100, 2)

      txtDescuentoRecargoImporte.Text = DescRec1.ToString("N2")

      'If Not tsbGenerarNCND.Visible AndAlso DescRec1 <> 0 Then
      Me.txtPaga.Text = (Decimal.Parse(Me.txtPaga.Text) + DescRec1).ToString("#,##0.00")
      'End If

   End Sub

   Private Function GenerarCreditosDebitos() As Boolean
      If ValidarComprobante() Then

         Dim totalNegro As Decimal = 0
         Dim colObservacionesNegro = New List(Of Entidades.CompraObservacion)()
         Dim oLineaObservacion = New Entidades.CompraObservacion()

         For i = 0 To _ComprobantesGrilla.Count - 1

            If _ComprobantesGrilla(i).DescuentoRecargoPorc <> 0 Then

               oLineaObservacion = New Entidades.CompraObservacion()

               totalNegro += Me._ComprobantesGrilla(i).DescuentoRecargo

               With oLineaObservacion
                  .IdSucursal = actual.Sucursal.Id
                  .Usuario = actual.Nombre
                  .Linea = colObservacionesNegro.Count + 1
                  .Observacion = Strings.Left("Aplico: " & Me._ComprobantesGrilla(i).TipoComprobante.Descripcion & " ´" & Me._ComprobantesGrilla(i).Letra & "´ " & Me._ComprobantesGrilla(i).CentroEmisor.ToString("0000") & "-" & Me._ComprobantesGrilla(i).NumeroComprobante.ToString("00000000") & ". Emision: " & Me._ComprobantesGrilla(i).Fecha.ToString("dd/MM/yyyy") & ". Pago: " & Me._ComprobantesGrilla(i).Paga.ToString("##,##0.00") & ". Porc: " & Me._ComprobantesGrilla(i).DescuentoRecargoPorc.ToString("##0.00") & ". Monto: " & Me._ComprobantesGrilla(i).DescuentoRecargo.ToString("#,##0.00") & ".", 100)

                  'Luego de la grabacion del recibo, deberia agregar el recibo.
                  '.Observacion = Strings.Left(oVentas.TipoComprobante.DescripcionAbrev & " " & oVentas.LetraComprobante & " " & oVentas.Impresora.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & IIf(oVentas.Cheques.Count > 0, " - Cantidad Cheq. Tercero: " + oVentas.Cheques.Count.ToString(), "").ToString() & ". " & oVentas.Cliente.NombreCliente, 100)

               End With

               colObservacionesNegro.Add(oLineaObservacion)

            End If

         Next

         Dim comprobante As Entidades.Compra = Nothing
         Dim idTipoComprobante As String
         Dim idProveedor As Long = _proveedorGrilla.IdProveedor
         Dim fecha As Date = dtpFecha.Value
         Dim cache = New Eniac.Reglas.BusquedasCacheadas()
         Dim idComprador = cache.GetPrimerComprador()
         Dim idProducto As String
         Dim Rubro As Integer = New Reglas.RubrosCompras().GetTodos().FirstOrDefault().IdRubro

         If Not String.IsNullOrEmpty(Reglas.Publicos.CtaCteProv.IDProductoDescuentoRecargo) Then
            idProducto = Reglas.Publicos.CtaCteProv.IDProductoDescuentoRecargo
         Else
            MessageBox.Show("No esta definido el Producto para generar NC/ND.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If

         If totalNegro <> 0 Then


            idTipoComprobante = IIf(totalNegro > 0, Eniac.Reglas.Publicos.IdNotaDebitoNoGrabaLibroProv, Eniac.Reglas.Publicos.IdNotaCreditoNoGrabaLibroProv).ToString()

            If String.IsNullOrEmpty(idTipoComprobante) Then
               MessageBox.Show("No esta definido el tipo de comprobante para generar NC/ND.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Return False
            End If

            If totalNegro > 0 Then
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNDeb) Then
                  idTipoComprobante = DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNDeb
               End If
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdProductoNDeb) Then
                  idProducto = DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdProductoNDeb
               End If
            ElseIf totalNegro < 0 Then
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNCred) Then
                  idTipoComprobante = DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNCred
               End If
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdProductoNCred) Then
                  idProducto = DirectCast(cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).IdProductoNCred
               End If
            End If

            totalNegro = Math.Abs(totalNegro)

            Dim rReglaCompra2 = New Reglas.Compras()

            Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante)

            Dim asoc As Entidades.Compra() = {}
            'If tipoComprobante.AFIPWSRequiereComprobanteAsociado Then
            '               asoc = _ComprobantesGrilla.
            '                     Where(Function(x) Not x.TipoComprobante.GrabaLibro And
            '                                       x.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString() And
            '                                             x.DescuentoRecargo <> 0).
            '                     ToList().ConvertAll(Function(x) New Entidades.Compra() With
            '                                                      {.IdSucursal = x.IdSucursal,
            '                                                       .TipoComprobante = x.TipoComprobante,
            '                                                 .Letra = x.Letra,
            '                                                 .CentroEmisor = Convert.ToInt16(x.CentroEmisor),
            '                                                       .NumeroComprobante = x.NumeroComprobante,
            '                                                 .Fecha = x.Fecha,
            '                                                 .Proveedor = x.CuentaCorrienteProv.Proveedor}).ToArray()
            'End If

            Dim Productos As List(Of Entidades.CompraProducto) = New List(Of Entidades.CompraProducto)
            Dim Producto As Entidades.CompraProducto = New Entidades.CompraProducto()
            With Producto
               .Producto = New Reglas.Productos().GetUno(idProducto)
               .Cantidad = 1
            End With
            Productos.Add(Producto)

            comprobante = rReglaCompra2.GrabarComprobante(actual.Sucursal.Id,
                                                            idTipoComprobante,
                                                            idProveedor,
                                                            Integer.Parse(Me.cmbCajas.SelectedValue.ToString()),
                                                            fecha,
                                                            idComprador,
                                                            _idFormaDePagoCtaCte,
                                                            "Generado Automatico.",
                                                            totalNegro,
                                                            Productos,
                                                            colObservacionesNegro,
                                                            contactos:=Nothing,
                                                            nombreProducto:=String.Empty,
                                                            cobrador:=Nothing,
                                                            comprobantesAsociados:=asoc,
                                                            Rubro,
                                                            metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Automatico,
                                                            idFuncion:=Me.IdFuncion)

            Me.InsertarComprobanteAutomatico(comprobante)

         End If

         Me.tsbGenerarNCND.Visible = False   'Por ahora. Para que solo pueda entrar 1 vez.

         Me.CalcularTotales()

         Me.tsbGrabar.Enabled = True
         Me.tsbGrabar.Visible = True

         _comprobanteAutomatico = False
         Return True
      Else
         Return False
      End If
   End Function

   Private Sub InsertarComprobanteAutomatico(Comprobante As Entidades.Compra)

      _comprobanteAutomatico = True

      Dim oLineaDetalle As Entidades.CuentaCorrienteProvPago = New Entidades.CuentaCorrienteProvPago()

      With oLineaDetalle
         .TipoComprobante = Comprobante.TipoComprobante
         .Letra = Comprobante.Letra
         .CentroEmisor = Comprobante.CentroEmisor
         .NumeroComprobante = Comprobante.NumeroComprobante
         .Cuota = 1
         .Fecha = Comprobante.Fecha
         ' .FechaVencimiento = Comprobante.Fecha.AddDays(Me._idFormaDePgoCtaCte)
         .ImporteCuota = Comprobante.ImporteTotal
         .SaldoCuota = Comprobante.ImporteTotal
         .Paga = Comprobante.ImporteTotal
         .DescuentoRecargoPorc = 0
         .DescuentoRecargo = 0
         .IdSucursal = actual.Sucursal.IdSucursal
         .Usuario = actual.Nombre
      End With

      _ComprobantesGrilla.ForEach(Sub(c) c.Paga -= c.DescuentoRecargo)

      Me._ComprobantesGrilla.Add(oLineaDetalle)

      Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
      '  Me.AjustarColumnasGrilla(Me.dgvComprobantes, Me._tit)
      Me.dgvComprobantes.FirstDisplayedScrollingRowIndex = Me.dgvComprobantes.Rows.Count - 1

      Me.dgvComprobantes.Refresh()
      'Me.LimpiarCamposComprobante()
      Me.CalcularTotales()

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

   Private Sub dtpFechaTransferencia_Leave(sender As Object, e As EventArgs) Handles dtpFechaTransferencia.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbNroOrdenDeCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroOrdenDeCompra.CheckedChanged
      TryCatched(Sub() chbNroOrdenDeCompra.FiltroCheckedChanged(usaPermitido:=True, bscNroOrdenDeCompra))
   End Sub

   Private Sub dtpFechaTransferencia_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpFechaTransferencia.KeyUp
      If e.KeyCode = Keys.Enter Then
         If String.IsNullOrEmpty(Me.txtTransferenciaBancaria.Text) Or Decimal.Parse(Me.txtTransferenciaBancaria.Text) = 0 Then
            Me.txtTransferenciaBancaria.Focus()
         End If
      End If
   End Sub


   Private Sub ImputacionAutomatica()
      If txtTotalPagos.ValorNumericoPorDefecto(0D) <> 0 Then
         _ComprobantesGrilla.Clear()

         Dim strComprobantesAsociados = New Reglas.TiposComprobantes().GetUno(cmbTiposComprobantesPag.ValorSeleccionado(Of String)).ComprobantesAsociados

         Dim oComprobantes = New Reglas.CuentasCorrientesProv()
         Using dt = oComprobantes.BuscarPendientes(actual.Sucursal.Id, _proveedorGrilla, strComprobantesAsociados, 0)
            Dim paga = txtTotalPagos.ValorNumericoPorDefecto(0D)
            Using dt1 = dt.Clone()
               dt1.Columns.Add("Paga", GetType(Decimal))
               dt1.Columns.Add("DescuentoRecargoPorc", GetType(Decimal))
               dt1.Columns.Add("DescuentoRecargo", GetType(Decimal))
               For Each dr In dt.AsEnumerable()
                  If Not paga = 0 Then
                     Dim saldo = dr.Field(Of Decimal?)("Saldo").IfNull()
                     Dim porcDR = If(Reglas.Publicos.CtaCteProv.ImputacionAutomaticaDRFormaPago, dr.Field(Of Decimal?)("Porcentaje").IfNull(), 0D)
                     Dim impoDR = saldo * (porcDR / 100)
                     saldo += impoDR
                     Dim dr2 = dt1.NewRow()
                     dr2.ItemArray = dr.ItemArray

                     If saldo <= paga Then
                        dr2("Paga") = saldo
                        paga = paga - saldo
                     Else
                        dr2("Paga") = paga
                        paga = 0
                     End If

                     dr2("DescuentoRecargoPorc") = porcDR
                     dr2("DescuentoRecargo") = impoDR

                     dt1.Rows.Add(dr2)
                     dt1.AcceptChanges()
                  End If
               Next

               For Each dr1 In dt1.AsEnumerable()
                  Dim lineaDetalle = New Entidades.CuentaCorrienteProvPago()
                  With lineaDetalle
                     Dim otipocomp = New Reglas.TiposComprobantes()
                     .TipoComprobante = otipocomp.GetUno(dr1.Field(Of String)("IdTipoComprobante").IfNull())
                     .Letra = dr1.Field(Of String)("Letra").IfNull()
                     .CentroEmisor = dr1.Field(Of Integer)("Emisor").ToShort()
                     .NumeroComprobante = dr1.Field(Of Long)("Numero").ToInteger()
                     .Cuota = dr1.Field(Of Integer)("Cuota")
                     .Fecha = dr1.Field(Of Date)("Fecha")
                     .FechaVencimiento = dr1.Field(Of Date)("FechaVencimiento")
                     .ImporteCuota = dr1.Field(Of Decimal)("Importe")
                     .SaldoCuota = dr1.Field(Of Decimal)("Saldo")
                     .DescuentoRecargo = dr1.Field(Of Decimal)("DescuentoRecargo")
                     .DescuentoRecargoPorc = dr1.Field(Of Decimal)("DescuentoRecargoPorc")
                     .Paga = dr1.Field(Of Decimal?)("Paga").IfNull()
                     .IdSucursal = dr1.Field(Of Integer)("Sucursal")
                     .Usuario = actual.Nombre
                     .Observacion = dr1.Field(Of String)("Observacion").IfNull()

                  End With
                  _ComprobantesGrilla.Add(lineaDetalle)
               Next
            End Using
         End Using

         dgvComprobantes.DataSource = _ComprobantesGrilla.ToArray()

         If dgvComprobantes.Rows.Count > 0 Then
            dgvComprobantes.FirstDisplayedScrollingRowIndex = dgvComprobantes.Rows.Count - 1
         End If

         dgvComprobantes.Refresh()

         CalcularComprobantes()
      End If
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
      If _transferencias Is Nothing Then _transferencias = New List(Of Entidades.CuentaCorrienteProvTransferencia)
      _transferencias.Add(New Entidades.CuentaCorrienteProvTransferencia With
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
      Dim dr = ugTransferenciasMultiples.FilaSeleccionada(Of Entidades.CuentaCorrienteProvTransferencia)
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
               dtpFechaTransferencia.Select()
            End If
         End Sub)
   End Sub

   Private Sub dtpFecha_Leave(sender As Object, e As EventArgs) Handles dtpFecha.Leave
      Try
         If IsNumeric(txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(txtTransferenciaBancaria.Text) <> 0 Then
            If dtpFechaTransferencia.Value.Date <> dtpFecha.Value.Date Then
               If ShowPregunta("La fecha de transferencia es diferente a la fecha del pago, ¿desea ajustar la fecha de transferencia a la fecha del pago?") = Windows.Forms.DialogResult.Yes Then
                  dtpFechaTransferencia.Value = dtpFecha.Value.Date
               End If
            End If
         Else
            dtpFechaTransferencia.Value = dtpFecha.Value.Date
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class