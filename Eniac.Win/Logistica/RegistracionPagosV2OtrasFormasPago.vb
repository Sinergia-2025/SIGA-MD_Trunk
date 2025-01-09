#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On

Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class RegistracionPagosV2OtrasFormasPago

#Region "Campos"
   Private _publicos As Publicos

   Private _drPedido As Entidades.dtsRegistracionPagosV2.ComprobantesRow
   Private _dsRegPagosV2 As Entidades.dtsRegistracionPagosV2
   Private _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal
#End Region

#Region "Constructores"

   Private Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(drComprobante As Entidades.dtsRegistracionPagosV2.ComprobantesRow)
      Me.New()
      _drPedido = drComprobante
      _dsRegPagosV2 = DirectCast(_drPedido.Table.DataSet, Entidades.dtsRegistracionPagosV2)
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _dsRegPagosV2.AcceptChanges()

         _publicos = New Win.Publicos()

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR) 'cambiar a txt
         _publicos.CargaComboEstadosVenta(cmbMotivo)
         _publicos.CargaComboTiposCheques(cmbTipoCheque)

         _categoriaFiscalEmpresa = New Eniac.Reglas.CategoriasFiscales()._GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         Nuevo()
         CargarDatosCliente()

         txtComprobantes.Text = _drPedido.ImporteTotal.ToString("N2")
         txtSaldoPendienteAplicar.Text = _drPedido.SaldoComprobante.ToString("N2")

         tbcDetalle.SelectedTab = tbArticulos

         DtsRegistracionPagosBindingSource.DataSource = _dsRegPagosV2
         Dim filtro = String.Format("{0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                    DtsRegistracionPagosV2.Comprobantes.IdSucursalColumn.ColumnName, _drPedido.IdSucursal,
                                    DtsRegistracionPagosV2.Comprobantes.IdTipoComprobanteColumn.ColumnName, _drPedido.IdTipoComprobante,
                                    DtsRegistracionPagosV2.Comprobantes.LetraColumn.ColumnName, _drPedido.Letra,
                                    DtsRegistracionPagosV2.Comprobantes.CentroEmisorColumn.ColumnName, _drPedido.CentroEmisor,
                                    DtsRegistracionPagosV2.Comprobantes.NumeroComprobanteColumn.ColumnName, _drPedido.NumeroComprobante)
         ChequesBindingSource.Filter = filtro
         ProductosBindingSource.Filter = filtro
         NCAplicadasBindingSource.Filter = filtro

         txtEfectivo.Text = _drPedido.TotalEfectivo.ToString("N2")
         txtCuentaCorriente.Text = _drPedido.TotalCuentaCorriente.ToString("N2")

         If Not _drPedido.IsTotalTransferenciaNull() AndAlso _drPedido.TotalTransferencia <> 0 Then
            txtTransferenciaBancaria.SetValor(_drPedido.TotalTransferencia)
            bscCodigoCuentaBancariaTransfBanc.Text = _drPedido.IdCuentaBancaria.ToString()
            tbcDetalle.SelectedTab = tbpPagos
            bscCodigoCuentaBancariaTransfBanc.Visible = True
            bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
            bscCodigoCuentaBancariaTransfBanc.Visible = False
            dtpFecha.Value = _drPedido.FechaTransferencia
         End If

         tbcDetalle.SelectedTab = tbArticulos

         ugProductos.AgregarFiltroEnLinea({DtsRegistracionPagosV2.Productos.IdProductoColumn.ColumnName,
                                           DtsRegistracionPagosV2.Productos.NombreProductoColumn.ColumnName,
                                           DtsRegistracionPagosV2.Productos.NotaColumn.ColumnName})
         ugCheques.AgregarFiltroEnLinea({DtsRegistracionPagosV2.Cheques.TitularColumn.ColumnName})
         ugNCAplicada.AgregarFiltroEnLinea({"NombreCliente", "NombreDeFantasia"})

         ugProductos.AgregarTotalesSuma({DtsRegistracionPagosV2.Productos.DevuelveColumn.ColumnName,
                                         DtsRegistracionPagosV2.Productos.ImporteDevuelveColumn.ColumnName})
         ugCheques.AgregarTotalesSuma({DtsRegistracionPagosV2.Cheques.ImporteColumn.ColumnName})
         ugNCAplicada.AgregarTotalesSuma({DtsRegistracionPagosV2.NCAplicadas.ImporteAplicadoColumn.ColumnName,
                                          DtsRegistracionPagosV2.NCAplicadas.SaldoComprobanteColumn.ColumnName})

         LimpiarNC()

         CargaNCParaAplicar()

         ugProductos.Focus()

         CalculaTotales()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         If ShowPregunta(String.Format("¿Desea cancelar la carga de {0}?", Text)) = Windows.Forms.DialogResult.Yes Then
            btnCancelar.PerformClick()
         End If
      ElseIf keyData = Keys.F9 Then
         tbcDetalle.SelectedTab = tbArticulos
      ElseIf keyData = Keys.F10 Then
         tbcDetalle.SelectedTab = tbpAplicarNC
      ElseIf keyData = Keys.F11 Then
         tbcDetalle.SelectedTab = tbpPagos
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   'Protected Overrides Sub OnShown(e As EventArgs)
   '   MyBase.OnShown(e)
   '   TryCatched(
   '      Sub()
   '         If Not _drPedido.IsTotalTransferenciaNull() AndAlso _drPedido.TotalTransferencia <> 0 Then
   '            txtTransferenciaBancaria.SetValor(_drPedido.TotalTransferencia)
   '            bscCodigoCuentaBancariaTransfBanc.Text = _drPedido.IdCuentaBancaria.ToString()
   '            tbcDetalle.SelectedTab = tbpPagos
   '            bscCodigoCuentaBancariaTransfBanc.Visible = True
   '            bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
   '            bscCodigoCuentaBancariaTransfBanc.Visible = False
   '            dtpFecha.Value = _drPedido.FechaTransferencia
   '         End If
   '         tbcDetalle.SelectedTab = tbArticulos
   '      End Sub)
   'End Sub
#End Region

#Region "Eventos"

   Private Sub dtpFecha_Leave(sender As Object, e As EventArgs) Handles dtpFecha.Leave
      TryCatched(
         Sub()
            If txtTransferenciaBancaria.Text.ValorNumericoPorDefecto(0D) <> 0 Then
               If dtpFechaTransferencia.Value.Date <> dtpFecha.Value.Date Then
                  If ShowPregunta("La fecha de transferencia es diferente a la fecha del recibo, ¿desea ajustar la fecha de transferencia a la fecha del recibo?") = Windows.Forms.DialogResult.Yes Then
                     dtpFechaTransferencia.Value = dtpFecha.Value.Date
                  End If
               End If
            Else
               dtpFechaTransferencia.Value = dtpFecha.Value.Date
            End If
         End Sub)
   End Sub


#Region "Eventos Pagos (F11)"
   Private Sub txtEfectivo_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave
      TryCatched(Sub() CalculaTotales())
   End Sub
   Private Sub txtCuentaCorriente_Leave(sender As Object, e As EventArgs) Handles txtCuentaCorriente.Leave
      TryCatched(Sub() CalculaTotales())
   End Sub
   Private Sub txtTransferenciaBancaria_Leave(sender As Object, e As EventArgs) Handles txtTransferenciaBancaria.Leave
      TryCatched(Sub() CalculaTotales())
   End Sub

   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbTipoCheque.SelectedIndex <> -1 Then
               If Not cmbTipoCheque.ItemSeleccionado(Of Entidades.TiposCheques).SolicitaNroOperacion Then
                  txtNroOperacion.Clear()
                  txtNroOperacion.Enabled = False
               Else
                  txtNroOperacion.Enabled = True
               End If
            End If
         End Sub)
   End Sub

   Private Sub btnInsertarCheque_Click(sender As Object, e As EventArgs) Handles btnInsertarCheque.Click
      TryCatched(
         Sub()
            If ValidarInsertarCheques() Then
               InsertarChequesGrilla()
               bscBancos.Focus()
            End If
         End Sub)
   End Sub
   Private Sub btnEliminarCheque_Click(sender As Object, e As EventArgs) Handles btnEliminarCheque.Click
      TryCatched(
         Sub()
            Dim drCheque = GetCurrentChequesRow()
            If drCheque IsNot Nothing Then
               If ShowPregunta("¿Esta seguro de eliminar el cheque seleccionado?") = Windows.Forms.DialogResult.Yes Then
                  EliminarLineaCheques(drCheque)
               End If
            End If
         End Sub)
   End Sub

#Region "Busqueda Foranea Bancos"
   Private Sub bscCodBancos_BuscadorClick() Handles bscCodBancos.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaBancos(bscCodBancos)
            bscCodBancos.Datos = New Reglas.Bancos().GetFiltradoPorCodigo(bscCodBancos.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscBancos_BuscadorClick() Handles bscBancos.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaBancos(bscBancos)
            bscBancos.Datos = New Reglas.Bancos().GetFiltradoPorNombre(bscBancos.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodBancos_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCodBancos.BuscadorSeleccion, bscBancos.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos Buscador Banco Transferencia"
   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBanc)
            bscCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim())
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
               CargarDatosCuentaBancariaTransfBanc(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

#Region "Busqueda Foranea Localidades"
   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaLocalidades(bscCodigoLocalidad)
            bscCodigoLocalidad.Datos = New Reglas.Localidades().GetPorCodigo(bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarLocalidad(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region
#End Region

#Region "Eventos Aplicar NC (F10)"
   Private Sub ugNCAplicada_CellChange(sender As Object, e As CellEventArgs) Handles ugNCAplicada.CellChange
      TryCatched(
         Sub()
            If e.Cell.Column.Key = _dsRegPagosV2.NCAplicadas.SeleccionadoColumn.ColumnName Then
               Dim dr = ugNCAplicada.FilaSeleccionada(Of Entidades.dtsRegistracionPagosV2.NCAplicadasRow)()
               ugNCAplicada.UpdateData()
               dr.ImporteAplicado = If(dr.Seleccionado, dr.SaldoComprobante, 0)

               CalculaTotales()
            End If
         End Sub)
   End Sub

   Private Sub btnAgregarNC_Click(sender As Object, e As EventArgs) Handles btnAgregarNC.Click
      TryCatched(
         Sub()
            Dim drProducto = GetCurrentProductoRow()
            If drProducto Is Nothing Then
               MessageBox.Show("No hay Articulo seleccionada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               ugProductos.Focus()
               Exit Sub
            End If

            If Not IsNumeric(txtCantidad.Text) Then
               MessageBox.Show("No ha una cantidad para devolver.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtCantidad.Focus()
               Exit Sub
            End If

            If cmbMotivo.SelectedIndex < 0 Then
               MessageBox.Show("No ha un motivo de devolución.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.cmbMotivo.Focus()
               Exit Sub
            End If

            If CDec(Me.txtCantidad.Text) > drProducto.Cantidad Then
               MessageBox.Show("La cantidad de articulos de la NC a generar debe ser menor o igual a la cantidad de artículos existente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtCantidad.Focus()
               Exit Sub
            End If

            If drProducto.Devuelve > 0 Then
               If MessageBox.Show("Este producto ya posee una NC de asignada. ¿Desea cambiar la misma?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                  Exit Sub
               End If
            End If

            drProducto.Devuelve = CDec(Me.txtCantidad.Text)
            If drProducto.Devuelve <> 0 Then
               drProducto.IdMotivo = CInt(cmbMotivo.SelectedValue)
               drProducto.Motivo = cmbMotivo.Text
            Else
               drProducto.IdMotivo = 0
               drProducto.Motivo = String.Empty
            End If

            drProducto.ImporteDevuelve = Math.Round(drProducto.ImporteTotal / drProducto.Cantidad * drProducto.Devuelve, 2)

            CalculaTotales()
            LimpiarNC()

            ugProductos.Focus()
         End Sub)
   End Sub
   Private Sub btnEliminarNC_Click(sender As Object, e As EventArgs) Handles btnEliminarNC.Click
      TryCatched(
         Sub()
            Dim drProducto = GetCurrentProductoRow()
            If drProducto Is Nothing Then
               MessageBox.Show("No hay Articulo seleccionada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               ugProductos.Focus()
               Exit Sub
            End If

            If drProducto.Devuelve = 0 Then
               MessageBox.Show("Este Articulo no posee Notas de Crédito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            If MessageBox.Show("¿Está seguro de eliminar la NC seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               drProducto.Devuelve = 0
               drProducto.Motivo = String.Empty
               drProducto.ImporteDevuelve = 0
            End If

            CalculaTotales()

            ugProductos.Focus()
         End Sub)
   End Sub
#End Region


#Region "Grillas"
   Private Sub ugProductos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugProductos.DoubleClickRow
      Try
         CargaProductoCompleto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles ugProductos.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            CargaProductoCompleto()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         Select Case Me.tbcDetalle.SelectedTab.Name
            Case tbArticulos.Name
               Me.ugProductos.Focus()
            Case tbpPagos.Name
               Me.txtEfectivo.Focus()
         End Select
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub PresionarTab_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaEmision.KeyDown, dtpFechaCobro.KeyDown, txtTitularCheque.KeyDown, txtImporteCheque.KeyDown, txtEfectivo.KeyDown, txtNroCheque.KeyDown, txtSucursalBanco.KeyDown, txtCuentaCorriente.KeyDown, txtCantidad.KeyDown, cmbMotivo.KeyDown, cmbTipoCheque.KeyDown, txtNroOperacion.KeyDown, txtTransferenciaBancaria.KeyDown, dtpFechaTransferencia.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         CalculaTotales()

         If txtDiferencia.ValorNumericoPorDefecto(0D) > 0 Then
            ShowMessage("Esta Cancelando un importe MAYOR al saldo del comprobante! Verifique los importes.")
            tbcDetalle.SelectedTab = tbpPagos
            txtEfectivo.Focus()
            Exit Sub
         End If

         If txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) <> 0 And Not bscCuentaBancariaTransfBanc.Selecciono Then
            ShowMessage("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta Bancaria")
            tbcDetalle.SelectedTab = tbpPagos
            bscCuentaBancariaTransfBanc.Focus()
            Exit Sub
         End If

         If txtDiferencia.ValorNumericoPorDefecto(0D) <> 0 Then
            If Decimal.Parse(txtEfectivo.Text) <> 0 Or Decimal.Parse(txtCuentaCorriente.Text) <> 0 Then
               ShowMessage("¡Esta Cancelando un importe MENOR al saldo del comprobante! Verifique los importes.")
               tbcDetalle.SelectedTab = tbpPagos
               txtEfectivo.Focus()
               Exit Sub
            Else
               Dim result As DialogResult
               result = MessageBox.Show("¡Esta Cancelando un importe MENOR al valor del documento!" + Environment.NewLine + Environment.NewLine +
                                        "¿Desea aplicar la diferencia como Efectivo?" + Environment.NewLine + Environment.NewLine +
                                        "SI: se aplica como Efectivo" + Environment.NewLine +
                                        "NO: se aplica como Cuenta Corriente" + Environment.NewLine +
                                        "Cancelar: permite ajustar manualmente",
                                        Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
               If result = Windows.Forms.DialogResult.Yes Then
                  txtEfectivo.Text = (Decimal.Parse(txtDiferencia.Text) * -1).ToString("N2")
               ElseIf result = Windows.Forms.DialogResult.No Then
                  txtCuentaCorriente.Text = (Decimal.Parse(txtDiferencia.Text) * -1).ToString("N2")
               Else
                  tbcDetalle.SelectedTab = tbpPagos
                  txtEfectivo.Focus()
                  Exit Sub
               End If
            End If
         End If

         _drPedido.TotalEfectivo = txtEfectivo.ValorNumericoPorDefecto(0D)
         _drPedido.TotalCuentaCorriente = txtCuentaCorriente.ValorNumericoPorDefecto(0D)
         _drPedido.TotalCheques = txtTotalCheques.ValorNumericoPorDefecto(0D)
         _drPedido.TotalNC = txtTotalNC.ValorNumericoPorDefecto(0D)
         _drPedido.TotalTransferencia = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)
         If _drPedido.TotalTransferencia <> 0 Then
            _drPedido.IdCuentaBancaria = bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I)
            _drPedido.FechaTransferencia = dtpFechaTransferencia.Value
         Else
            _drPedido.SetIdCuentaBancariaNull()
            _drPedido.SetFechaTransferenciaNull()
         End If

         _drPedido.GetNCAplicadasRows().All(Function(dr)
                                               If Not dr.Seleccionado Then
                                                  dr.Delete()
                                               End If
                                               Return True
                                            End Function)

         _dsRegPagosV2.AcceptChanges()
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         If ShowPregunta("Perderá los cambios al salir. ¿Desea Continuar?") = Windows.Forms.DialogResult.Yes Then
            _dsRegPagosV2.RejectChanges()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub Nuevo()
      Me.txtTotalEf.Enabled = True
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty
      Me.txtComprobantes.Enabled = True
      Me.bscCliente.Enabled = True
      Me.bscCodigoCliente.Enabled = True
      Me.txtObservacion.Text = String.Empty
      Me.cmbVendedor.SelectedIndex = -1
      Me.txtLocalidad.Text = String.Empty
      Me.txtComprobantes.Text = "0.00"
      Me.txtDireccion.Text = String.Empty
      Me.dtpFecha.Value = DateTime.Now
      Me.txtTotalEf.Text = "0.00"
      Me.txtCategoriaFiscal.Text = String.Empty
      Me.txtEfectivo.Text = "0.00"
      Me.txtCuentaCorriente.Text = "0.00"
      Me.txtSaldoActual.Text = "0.00"
      Me.txtDiferencia.Text = "0.00"
      ''Me._cheques.Clear()

      Me.cmbMotivo.SelectedIndex = -1

      Me.LimpiarCamposCheques()

      Me.tbcDetalle.SelectedTab = Me.tbpPagos
      Me.tbcDetalle.Enabled = True

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub CargarDatosCliente()

      bscCliente.Text = _drPedido.NombreCliente
      bscCodigoCliente.Text = _drPedido.CodigoCliente.ToString()
      txtDireccion.Text = _drPedido.Direccion
      txtLocalidad.Text = _drPedido.NombreLocalidad
      txtCategoriaFiscal.Text = _drPedido.NombreCategoriaFiscal
      txtCategoriaFiscal.Tag = _drPedido.IdCategoriaFiscal           'TODO: Verificar si es necesario
      txtSaldoActual.Text = _drPedido.SaldoCliente.ToString("N2")
      cmbVendedor.SelectedValue = _drPedido.IdVendedor

   End Sub

   Private Sub CargarDatosBancos(dr As DataGridViewRow)
      bscCodBancos.Text = dr.Cells("IdBanco").Value.ToString()
      bscBancos.Text = dr.Cells("NombreBanco").Value.ToString()
      bscCodBancos.Selecciono = True
      bscBancos.Selecciono = True
      txtNroCheque.Focus()
   End Sub
   Private Sub CargarLocalidad(dr As DataGridViewRow)
      bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      dtpFechaEmision.Focus()
   End Sub

   Private Sub CargarDatosCuentaBancariaTransfBanc(dr As DataGridViewRow)
      bscCodigoCuentaBancariaTransfBanc.Text = dr.Cells("IdCuentaBancaria").Value.ToString()
      bscCuentaBancariaTransfBanc.Text = dr.Cells("NombreCuenta").Value.ToString()

      If txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) = 0 Then
         txtTransferenciaBancaria.SetValor(txtDiferencia.ValorNumericoPorDefecto(0D) * -1)
      End If

      bscCodigoCuentaBancariaTransfBanc.Selecciono = True
      bscCuentaBancariaTransfBanc.Selecciono = True

      CalculaTotales()
      dtpFechaTransferencia.Focus()
   End Sub

   Private Sub LimpiarCamposCheques()
      Me.cmbTipoCheque.SelectedValue = "F" '# Fisico
      Me.bscCodBancos.Text = String.Empty
      Me.bscBancos.Text = String.Empty
      Me.bscBancos.FilaDevuelta = Nothing

      Me.txtNroCheque.Text = "0"
      Me.txtSucursalBanco.Text = "0"
      Me.bscCodigoLocalidad.Text = "0"
      Me.dtpFechaEmision.Value = DateTime.Today
      Me.txtNroOperacion.Text = String.Empty
      Me.dtpFechaCobro.Value = DateTime.Today
      Me.txtTitularCheque.Text = ""
      Me.txtImporteCheque.Text = "0.00"
      Me.txtCuitCheque.Clear()
   End Sub
   Private Function ValidarInsertarCheques() As Boolean
      '# Tipo de Cheque
      If Me.cmbTipoCheque.SelectedIndex = -1 Then
         Me.cmbTipoCheque.Focus()
         ShowMessage("ATENCIÓN: No seleccionó un Tipo de Cheque")
         Return False
      End If

      If Me.cmbTipoCheque.ItemSeleccionado(Of Entidades.TiposCheques).SolicitaNroOperacion AndAlso
         String.IsNullOrEmpty(Me.txtNroOperacion.Text) Then
         Me.txtNroOperacion.Focus()
         ShowMessage("ATENCIÓN: Debe ingresar un Número de Operación para el Tipo de Cheque seleccionado.")
         Return False
      End If

      If Not Me.bscBancos.Selecciono Or Not bscCodBancos.Selecciono Then
         ShowMessage("Debe seleccionar un Banco.")
         Me.bscCodBancos.Focus()
         Return False
      End If

      If Long.Parse(Me.txtNroCheque.Text) = 0 Then
         ShowMessage("El número de cheque no puede ser cero.")
         Me.txtNroCheque.Focus()
         Return False
      End If

      If Integer.Parse(Me.txtSucursalBanco.Text) = 0 Then
         ShowMessage("La sucursal del cheque no puede ser cero.")
         Me.txtSucursalBanco.Focus()
         Return False
      End If

      If Not Me.bscCodigoLocalidad.Selecciono Then
         ShowMessage("Debe ingresar y confirmar un C.P. para el cheque.")
         Me.bscCodigoLocalidad.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtImporteCheque.Text) <= 0 Then
         ShowMessage("No puede ingresar un cheque con importe cero o negativo.")
         Me.txtImporteCheque.Focus()
         Return False
      End If

      '# Validación del CUIT
      If String.IsNullOrEmpty(Me.txtCuitCheque.Text) Then
         ShowMessage("Debe ingresar un Nro. CUIT para el Cheque.")
         Return False
      Else

         Dim result As Reglas.Validaciones.ValidacionResult
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                     With {.IdFiscal = txtCuitCheque.Text,
                                                                                           .SolicitaCUIT = True}) '# Siempre solicitamos el CUIT al insertar el cheque por la nueva Alternative Key en BD
         If result.Error Then
            txtCuitCheque.Focus()
            ShowMessage(result.MensajeError)
            Return False
         End If

      End If

      For Each drCheque In _drPedido.GetChequesRows()
         If drCheque.NumeroCheque = Integer.Parse(Me.txtNroCheque.Text) And
            drCheque.IdBanco = Me.bscCodBancos.Text.ToInt64().IfNull() And
            drCheque.IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text) And
            drCheque.IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text) Then
            ShowMessage("El cheque ya esta ingresado.")
            Return False
         End If
      Next

      Return True
   End Function
   Private Sub InsertarChequesGrilla()

      Dim drCheque = _dsRegPagosV2.Cheques.NewChequesRow()

      With drCheque

         .IdSucursal = _drPedido.IdSucursal
         .IdTipoComprobante = _drPedido.IdTipoComprobante
         .Letra = _drPedido.Letra
         .CentroEmisor = _drPedido.CentroEmisor
         .NumeroComprobante = _drPedido.NumeroComprobante

         .IdTipoCheque = cmbTipoCheque.ValorSeleccionado(Of String)()
         .NombreTipoCheque = cmbTipoCheque.Text
         .IdBanco = Me.bscCodBancos.Text.ToInt32().IfNull()
         .NombreBanco = Me.bscBancos.Text

         .Cuit = Me.txtCuitCheque.Text
         .NumeroCheque = Integer.Parse(Me.txtNroCheque.Text)
         .IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text)
         .IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)

         .FechaEmision = Me.dtpFechaEmision.Value
         .NroOperacion = Me.txtNroOperacion.Text
         .FechaCobro = Me.dtpFechaCobro.Value

         .Titular = Me.txtTitularCheque.Text
         .Importe = Decimal.Parse(Me.txtImporteCheque.Text)
         .NroOperacion = Me.txtNroOperacion.Text

         .CodigoCliente = Long.Parse(Me.bscCodigoCliente.Text)
         .Usuario = actual.Nombre
         .IdEstadoCheque = Eniac.Entidades.Cheque.Estados.ENCARTERA.ToString()
      End With

      _dsRegPagosV2.Cheques.AddChequesRow(drCheque)

      Me.LimpiarCamposCheques()

      CalculaTotales()

   End Sub
   Private Sub EliminarLineaCheques(drCheque As Entidades.dtsRegistracionPagosV2.ChequesRow)
      _dsRegPagosV2.Cheques.RemoveChequesRow(drCheque)
      CalculaTotales()
   End Sub

   Private Sub CargaNCParaAplicar()
      _dsRegPagosV2.NCAplicadas.Clear()
      For Each drNC In _dsRegPagosV2.Comprobantes.Where(Function(x) Not x.Seleccionado And x.ImporteTotal < 0 And x.IdCliente = _drPedido.IdCliente)
         Dim drNuevo = _dsRegPagosV2.NCAplicadas.AddNCAplicadasRow(False,
                                                                   _drPedido.IdSucursal, _drPedido.IdTipoComprobante, _drPedido.Letra, _drPedido.CentroEmisor, _drPedido.NumeroComprobante,
                                                                   drNC.IdSucursal, drNC.IdTipoComprobante, drNC.Letra, drNC.CentroEmisor, drNC.NumeroComprobante,
                                                                   drNC.SaldoComprobante, 0, drNC.NombreCliente, drNC.NombreDeFantasia)
      Next
   End Sub

   Private Sub LimpiarNC()
      Me.lblarticulo.Text = String.Empty
      Me.txtCantidad.Text = "0"
      cmbMotivo.SelectedIndex = -1
      btnAgregarNC.Enabled = False
      txtCantidad.Enabled = False
      btnAgregarNC.Enabled = False
   End Sub


   Private Sub CalculaTotales()
      If _drPedido IsNot Nothing Then
         Dim efectivo = txtEfectivo.ValorNumericoPorDefecto(0D)
         Dim transferencia = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)
         Dim ctacte = txtCuentaCorriente.ValorNumericoPorDefecto(0D)
         Dim cheques = _drPedido.GetChequesRows().Sum(Function(x) x.Importe)
         Dim nc = _drPedido.GetProductosRows().Sum(Function(x) x.ImporteDevuelve)

         nc += _drPedido.GetNCAplicadasRows().Where(Function(x) x.Seleccionado).Sum(Function(x) x.ImporteAplicado * -1)

         Dim totalParcial = efectivo + transferencia + ctacte + nc + cheques
         Dim diferencia = totalParcial - _drPedido.SaldoComprobante

         txtTotalEf.Text = (efectivo + transferencia).ToString("N2")
         txtTotalCtaCte.Text = ctacte.ToString("N2")
         txtTotalNC.Text = nc.ToString("N2")
         txtTotalCheques.Text = cheques.ToString("N2")

         txtTotalParcial.Text = totalParcial.ToString("N2")
         txtDiferencia.Text = diferencia.ToString("N2")
      End If
   End Sub

   Private Sub CargaProductoCompleto()
      Dim drProducto = GetCurrentProductoRow()
      If drProducto IsNot Nothing Then
         Me.lblarticulo.Text = drProducto.NombreProducto
         If drProducto.Devuelve <> 0 Then
            Me.txtCantidad.Text = drProducto.Devuelve.ToString("N2")
         Else
            Me.txtCantidad.Text = drProducto.Cantidad.ToString("N2")
         End If

         btnAgregarNC.Enabled = True
         txtCantidad.Enabled = True
         btnAgregarNC.Enabled = True

         cmbMotivo.SelectedValue = drProducto.IdMotivo

         txtCantidad.Focus()

      End If
   End Sub

   Private Function GetCurrentProductoRow() As Entidades.dtsRegistracionPagosV2.ProductosRow
      Return ugProductos.FilaSeleccionada(Of Entidades.dtsRegistracionPagosV2.ProductosRow)()
   End Function
   Private Function GetCurrentChequesRow() As Entidades.dtsRegistracionPagosV2.ChequesRow
      Return ugCheques.FilaSeleccionada(Of Entidades.dtsRegistracionPagosV2.ChequesRow)()
   End Function

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      Me.lblarticulo.Text = String.Empty
      Me.txtCantidad.Text = "0.00"
      btnAgregarNC.Enabled = False
      txtCantidad.Enabled = False
      cmbMotivo.SelectedIndex = -1
   End Sub



#End Region

End Class