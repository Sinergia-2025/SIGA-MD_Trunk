Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Text
Imports Infragistics.Win.UltraWinGrid

Public Class OtrasFormasPago

   Private _drPedido As dtsRegistracionPagos.PedidosRow
   Private _cliente As Eniac.Entidades.Cliente
   Private _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal

#Region "constructores"

   Private Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(ByVal FilaPago As dtsRegistracionPagos.PedidosRow)
      Me.New()
      _drPedido = FilaPago
      ''_dsRegistracionPagos = DirectCast(_drPedido.Table.DataSet, dtsRegistracionPagos)
   End Sub

#End Region

#Region "Campos"
   Private _publicos As Win.Publicos
   Private _publicosEniac As Eniac.Win.Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Win.Publicos()
         Me._publicosEniac = New Eniac.Win.Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me._publicos.CargaComboTiposCheques(Me.cmbTipoCheque)
         Me._publicos.CargaComboEstadosVenta(Me.cmbMotivo)

         _categoriaFiscalEmpresa = New Eniac.Reglas.CategoriasFiscales()._GetUno(Publicos.CategoriaFiscalEmpresa)

         Me.Nuevo()
         Me.CargarDatosCliente()

         bscCodigoCliente.Permitido = False

         Me.cmbMotivo.SelectedIndex = -1
         Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(_drPedido.IdVendedor)

         Me.txtComprobantes.Text = _drPedido.ImporteTotal.ToString("N2")

         Me.tbcDetalle.SelectedTab = Me.tbArticulos
         Me.grbCheques.Enabled = True

         bscBancos.Enabled = True

         DtsRegistracionPagosBindingSource.DataSource = _drPedido.Table.DataSet
         Dim filtro As String = String.Format("{0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                              DtsRegistracionPagos.Pedidos.IdSucursalColumn.ColumnName, _drPedido.IdSucursal,
                                              DtsRegistracionPagos.Pedidos.IdTipoComprobanteColumn.ColumnName, _drPedido.IdTipoComprobante,
                                              DtsRegistracionPagos.Pedidos.LetraColumn.ColumnName, _drPedido.Letra,
                                              DtsRegistracionPagos.Pedidos.CentroEmisorColumn.ColumnName, _drPedido.CentroEmisor,
                                              DtsRegistracionPagos.Pedidos.NumeroComprobanteColumn.ColumnName, _drPedido.NumeroComprobante)
         ChequesBindingSource.Filter = filtro
         ProductosBindingSource.Filter = filtro

         Me.txtEfectivo.Text = _drPedido.Efectivo.ToString("N2")
         Me.txtCuentaCorriente.Text = _drPedido.CuentaCorriente.ToString("N2")

         limpiarNC()
         Me.ugProductos.Focus()

         CalculaTotales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"
   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      Try
         If Me.cmbTipoCheque.SelectedIndex <> -1 Then

            If Not cmbTipoCheque.ItemSeleccionado(Of Entidades.TiposCheques).SolicitaNroOperacion Then
               Me.txtNroOperacion.Clear()
               Me.txtNroOperacion.Enabled = False
            Else
               Me.txtNroOperacion.Enabled = True
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub Recibos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F4
            If Me.tsbVolver.Enabled Then
               Me.tsbVolver_Click(sender, Nothing)
            End If
         Case Keys.F9
            Me.tbcDetalle.SelectedTab = Me.tbArticulos
         Case Keys.F11
            Me.tbcDetalle.SelectedTab = Me.tbpPagos
         Case Else
      End Select
   End Sub

   Private Sub txtEfectivo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEfectivo.Leave
      Try
         CalculaTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnInsertarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarCheque.Click
      Try
         If Me.ValidarInsertarCheques() Then
            Me.InsertarChequesGrilla()
            Me.bscBancos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnEliminarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCheque.Click
      Try
         Dim drCheque As dtsRegistracionPagos.ChequesRow = GetCurrentChequesRow()

         If drCheque IsNot Nothing Then
            If MessageBox.Show("¿Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaCheques(drCheque)
            End If
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscBancos_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscBancos.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
            Me.txtSucursalBanco.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         Select Case Me.tbcDetalle.SelectedTab.Name
            Case tbArticulos.Name
               Me.ugProductos.Focus()
            Case tbpPagos.Name
               Me.txtEfectivo.Focus()
         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      If MessageBox.Show("Perderá los cambios al salir. ¿Desea Continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         _drPedido.Table.DataSet.RejectChanges()
         Me.DialogResult = Windows.Forms.DialogResult.Cancel
         Me.Close()
      End If
   End Sub

   Private Sub tsbVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbVolver.Click

      CalculaTotales()

      If Decimal.Parse(Me.txtDiferencia.Text) > 0 Then
         MessageBox.Show("Esta Cancelando un importe MAYOR al valor del documento! Verifique los importes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         tbcDetalle.SelectedTab = tbpPagos
         txtEfectivo.Focus()
         Exit Sub
      End If

      If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
         If Decimal.Parse(txtEfectivo.Text) <> 0 Or Decimal.Parse(txtCuentaCorriente.Text) <> 0 Then
            MessageBox.Show("¡Esta Cancelando un importe MENOR al valor del documento! Verifique los importes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

      _drPedido.Efectivo = Decimal.Parse(Me.txtEfectivo.Text)
      _drPedido.CuentaCorriente = Decimal.Parse(Me.txtCuentaCorriente.Text)
      _drPedido.TotalCheques = Decimal.Parse(Me.txtTotalCheques.Text)
      _drPedido.TotalNC = Decimal.Parse(Me.txtTotalNC.Text)

      _drPedido.Table.DataSet.AcceptChanges()
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
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
      End Try
   End Sub

   Private Sub txtComprobantes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobantes.LostFocus
      If Not IsNumeric(Me.txtComprobantes.Text) Then
         Me.txtComprobantes.Text = "0.00"
      End If
   End Sub

   Private Sub txtCuentaCorriente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuentaCorriente.Leave
      Try
         Me.CalculaTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaTransfBanc)
         Dim oCBancarias As Eniac.Reglas.CuentasBancarias = New Eniac.Reglas.CuentasBancarias()
         Me.bscCuentaBancariaTransfBanc.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaTransfBanc.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscBancos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
         End If
         Me.txtNroCheque.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugProductos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugProductos.DoubleClickRow
      Dim drProducto As dtsRegistracionPagos.ProductosRow = GetCurrentProductoRow()
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

   Private Sub PresionarTab_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaEmision.KeyDown, dtpFechaCobro.KeyDown, txtTitularCheque.KeyDown, txtImporteCheque.KeyDown, txtEfectivo.KeyDown, txtNroCheque.KeyDown, txtSucursalBanco.KeyDown, txtCuentaCorriente.KeyDown, txtCantidad.KeyDown, cmbMotivo.KeyDown
      Me.PresionarTab(e)
   End Sub

#End Region

#Region "Metodos"


   Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub EliminarLineaCheques(drCheque As dtsRegistracionPagos.ChequesRow)
      DirectCast(_drPedido.Table.DataSet, dtsRegistracionPagos).Cheques.Rows.Remove(drCheque)
      CalculaTotales()
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

      If Not Me.bscBancos.Selecciono Then
         MessageBox.Show("Debe seleccionar un Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscBancos.Focus()
         Return False
      End If

      If Integer.Parse(Me.txtSucursalBanco.Text) = 0 Then
         MessageBox.Show("La sucursal del cheque no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtSucursalBanco.Focus()
         Return False
      End If

      If Not Me.bscCodigoLocalidad.Selecciono Then
         MessageBox.Show("Debe ingresar y confirmar un C.P. para el cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoLocalidad.Focus()
         Return False
      Else
         'If Not New Reglas.Localidades().Existe(Integer.Parse(Me.txtCodPostalCheque.Text)) Then
         '   MessageBox.Show("No existe la localidad del Cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.txtCodPostalCheque.Focus()
         '   Return False
         'End If
      End If

      If Long.Parse(Me.txtNroCheque.Text) = 0 Then
         MessageBox.Show("El número de cheque no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroCheque.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtImporteCheque.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un cheque con importe cero o negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

      For Each drCheque As dtsRegistracionPagos.ChequesRow In _drPedido.GetChequesRows()
         If drCheque.NumeroCheque = Integer.Parse(Me.txtNroCheque.Text) And _
            drCheque.IdBanco = Integer.Parse(Me.bscBancos._filaDevuelta.Cells("idBanco").Value.ToString()) And _
            drCheque.IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text) And _
            drCheque.IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text) Then
            MessageBox.Show("El cheque ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      Next

      Return True
   End Function

   Private Sub LimpiarCamposCheques()
      Me.bscBancos.Text = ""
      Me.bscBancos.FilaDevuelta = Nothing
      Me.dtpFechaCobro.Value = DateTime.Now
      Me.dtpFechaEmision.Value = DateTime.Now
      Me.txtImporteCheque.Text = "0.00"
      Me.txtNroCheque.Text = "0"
      Me.bscCodigoLocalidad.Text = "0"
      Me.txtSucursalBanco.Text = "0"
      Me.txtTitularCheque.Text = ""
      Me.txtCuitCheque.Clear()
      Me.txtNroOperacion.Clear()
      Me.cmbTipoCheque.SelectedValue = "F" '# Fisico
   End Sub

   Private Sub CargarDatosCliente()

      Me.bscCliente.Text = _drPedido.NombreCliente
      Me.bscCodigoCliente.Text = _drPedido.CodigoCliente.ToString()
      Me.bscCodigoCliente.PresionarBoton()

      CargarDatosCliente(Me.bscCodigoCliente._filaDevuelta)
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.txtDireccion.Text = dr.Cells("Direccion").Value.ToString()
      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtCategoriaFiscal.Text = dr.Cells("NombreCategoriaFiscal").Value.ToString()
      Me.txtCategoriaFiscal.Tag = dr.Cells("IdCategoriaFiscal").Value

      Me.tbcDetalle.Enabled = True
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False


      Dim oCliente As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
      Dim _clienteGrilla As Eniac.Entidades.Cliente = oCliente.GetUnoPorCodigo(Long.Parse(Me.bscCodigoCliente.Text))

      Dim Vend As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados()
      Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(Integer.Parse(dr.Cells("IdVendedor").Value.ToString()))

      'carga el saldo del cliente de la cuenta corriente
      Dim oCtaCte As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
      Me.txtSaldoActual.Text = oCtaCte.GetSaldoCliente(actual.Sucursal.Id, _clienteGrilla.IdCliente).ToString("#,##0.00")

      'Me.bscComprobante.Focus()

      _cliente = New Eniac.Reglas.Clientes().GetUno(CLng(dr.Cells("IdCliente").Value))

   End Sub


   Private Function GetVendedorCombo(ByVal IdEmpleado As Integer) As Object
      Dim empleados As List(Of Eniac.Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Eniac.Entidades.Empleado))
      For Each emp As Eniac.Entidades.Empleado In empleados
         If IdEmpleado = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub CargarDatosBancos(ByVal dr As DataGridViewRow)
      Me.bscBancos.Text = dr.Cells("NombreBanco").Value.ToString()
   End Sub

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
      Me.bscCuentaBancariaTransfBanc.Text = String.Empty
      ''Me._cheques.Clear()

      Me.LimpiarCamposCheques()

      Me.tbcDetalle.SelectedTab = Me.tbpPagos
      Me.tbcDetalle.Enabled = True

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub InsertarChequesGrilla()

      Dim drCheque As dtsRegistracionPagos.ChequesRow = DirectCast(_drPedido.Table.DataSet, dtsRegistracionPagos).Cheques.NewChequesRow()

      With drCheque
         .IdSucursal = _drPedido.IdSucursal
         .IdTipoComprobante = _drPedido.IdTipoComprobante
         .Letra = _drPedido.Letra
         .CentroEmisor = _drPedido.CentroEmisor
         .NumeroComprobante = _drPedido.NumeroComprobante
         .NumeroCheque = Integer.Parse(Me.txtNroCheque.Text)
         .IdBanco = Integer.Parse(Me.bscBancos._filaDevuelta.Cells("idBanco").Value.ToString())
         .IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text)
         .NombreBanco = Me.bscBancos.Text
         .IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         .Cuit = Me.txtCuitCheque.Text
         .FechaEmision = Me.dtpFechaEmision.Value
         .FechaCobro = Me.dtpFechaCobro.Value
         .Titular = Me.txtTitularCheque.Text
         .Importe = Decimal.Parse(Me.txtImporteCheque.Text)
         .CodigoCliente = Long.Parse(Me.bscCodigoCliente.Text)
         .Usuario = actual.Nombre
         .IdEstadoCheque = Eniac.Entidades.Cheque.Estados.ENCARTERA.ToString()
         .IdTipoCheque = Me.cmbTipoCheque.ValorSeleccionado(Of String)
         .NroOperacion = Me.txtNroOperacion.Text
      End With

      DirectCast(_drPedido.Table.DataSet, dtsRegistracionPagos).Cheques.AddChequesRow(drCheque)

      Me.LimpiarCamposCheques()

      CalculaTotales()

   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
   End Sub

#End Region


   Private Sub btnAgregarNC_Click(sender As Object, e As EventArgs) Handles btnAgregarNC.Click
      Try
         Dim drProducto As dtsRegistracionPagos.ProductosRow = GetCurrentProductoRow()
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
         drProducto.IdMotivo = CInt(cmbMotivo.SelectedValue)
         drProducto.Motivo = cmbMotivo.Text

         drProducto.ImporteDevuelve = Math.Round(drProducto.ImporteTotal / drProducto.Cantidad * drProducto.Devuelve, 2)

         CalculaTotales()
         limpiarNC()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub limpiarNC()
      Me.lblarticulo.Text = String.Empty
      Me.txtCantidad.Text = "0"
      cmbMotivo.SelectedIndex = -1
      btnAgregarNC.Enabled = False
      txtCantidad.Enabled = False
      btnAgregarNC.Enabled = False
   End Sub
   Private Sub btnEliminarNC_Click(sender As Object, e As EventArgs) Handles btnEliminarNC.Click

      Dim drProducto As dtsRegistracionPagos.ProductosRow = GetCurrentProductoRow()
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

      ''If lblarticulo.Text = String.Empty Or Me.txtCantidad.Text = String.Empty Or Me.txtCantidad.Text = "0" Then
      ''   MessageBox.Show("No hay Articulo o cantidad seleccionada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      ''   Exit Sub
      ''End If

      ''If Not (VerificaNCDuplicada(tipoPago.nc, CInt(Me.dgvArticulos.Rows(indiceFilaProd).Cells("IdSucursal").Value), _
      ''                        CStr(Me.dgvArticulos.Rows(indiceFilaProd).Cells("IdTipoComprobante").Value), _
      ''                        CStr(Me.dgvArticulos.Rows(indiceFilaProd).Cells("Letra").Value), _
      ''                        CInt(Me.dgvArticulos.Rows(indiceFilaProd).Cells("CentroEmisor").Value), _
      ''                        CInt(Me.dgvArticulos.Rows(indiceFilaProd).Cells("NumeroComprobante").Value), _
      ''                         CInt(Me.dgvArticulos.Rows(indiceFilaProd).Cells(8).Value))) Then
      ''   MessageBox.Show("Este Articulo no posee Notas de Crédito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      ''   Exit Sub
      ''End If



      ''If MessageBox.Show("Desea eliminar la Nota de Crédito?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      ''   QuitarNC(tipoPago.nc _
      ''            , CInt(Me.dgvArticulos.Rows(indiceFilaProd).Cells("IdSucursal").Value), _
      ''                        CStr(Me.dgvArticulos.Rows(indiceFilaProd).Cells("IdTipoComprobante").Value), _
      ''                        CStr(Me.dgvArticulos.Rows(indiceFilaProd).Cells("Letra").Value), _
      ''                         CInt(Me.dgvArticulos.Rows(indiceFilaProd).Cells("CentroEmisor").Value), _
      ''                        CInt(Me.dgvArticulos.Rows(indiceFilaProd).Cells("NumeroComprobante").Value), _
      ''                        CDec(Me.dgvArticulos.Rows(indiceFilaProd).Cells("dif").Value))

      ''   Me.txtTotalNC.Text = (CDec(Me.txtTotalNC.Text) - importeNC).ToString("#,##0.00")
      ''   CalcularPagosNuevo()
      ''End If




   End Sub


   Private Function GetCurrentProductoRow() As dtsRegistracionPagos.ProductosRow
      Dim drProducto As dtsRegistracionPagos.ProductosRow = Nothing

      If ugProductos.ActiveRow IsNot Nothing AndAlso
         ugProductos.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugProductos.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugProductos.ActiveRow.ListObject, DataRowView).Row IsNot Nothing AndAlso
         TypeOf (DirectCast(ugProductos.ActiveRow.ListObject, DataRowView).Row) Is dtsRegistracionPagos.ProductosRow Then
         drProducto = DirectCast(DirectCast(ugProductos.ActiveRow.ListObject, DataRowView).Row, dtsRegistracionPagos.ProductosRow)
      End If

      Return drProducto
   End Function
   Private Function GetCurrentChequesRow() As dtsRegistracionPagos.ChequesRow
      Dim drCheque As dtsRegistracionPagos.ChequesRow = Nothing

      If ugCheques.ActiveRow IsNot Nothing AndAlso
         ugCheques.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugCheques.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugCheques.ActiveRow.ListObject, DataRowView).Row IsNot Nothing AndAlso
         TypeOf (DirectCast(ugCheques.ActiveRow.ListObject, DataRowView).Row) Is dtsRegistracionPagos.ChequesRow Then
         drCheque = DirectCast(DirectCast(ugCheques.ActiveRow.ListObject, DataRowView).Row, dtsRegistracionPagos.ChequesRow)
      End If

      Return drCheque
   End Function


   Private Sub CalculaTotales()
      Dim efectivo As Decimal = 0
      Dim ctacte As Decimal = 0
      Dim nc As Decimal = 0
      Dim cheques As Decimal = 0

      efectivo = CDec("0" + txtEfectivo.Text)
      ctacte = CDec("0" + txtCuentaCorriente.Text)

      If _drPedido IsNot Nothing And _cliente IsNot Nothing Then
         For Each drProducto As dtsRegistracionPagos.ProductosRow In _drPedido.GetProductosRows

            Dim producto As Eniac.Entidades.Producto = New Eniac.Reglas.Productos().GetUno(drProducto.IdProducto, False, False)
            Dim importeDevuelve As Decimal = drProducto.ImporteDevuelve
            'importeDevuelve = Math.Round(Eniac.Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(importeDevuelve, drProducto.AlicuotaIVA,
            '                                                                                        producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno,
            '                                                                                        producto.OrigenPorcImpInt), 2)

            'If (_cliente.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or _
            '   Not _cliente.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Then
            '   importeDevuelve = Math.Round(importeDevuelve * (1 + (drProducto.AlicuotaIVA / 100)), 2)
            '   '' ''Else
            '   '' ''   'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
            '   '' ''   importeDevuelve = PrecioVentaConIVA
            'End If


            nc = nc + importeDevuelve
         Next

         For Each drCheque As dtsRegistracionPagos.ChequesRow In _drPedido.GetChequesRows
            cheques = cheques + drCheque.Importe
         Next
      End If

      txtTotalEf.Text = efectivo.ToString("N2")
      txtTotalCtaCte.Text = ctacte.ToString("N2")
      txtTotalNC.Text = nc.ToString("N2")
      txtTotalCheques.Text = cheques.ToString("N2")

      txtTotalParcial.Text = (efectivo + ctacte + nc + cheques).ToString("N2")

      txtDiferencia.Text = (CDec(txtTotalParcial.Text) - CDec(txtComprobantes.Text)).ToString("N2")
   End Sub

   Private Sub txtCuentaCorriente_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaCorriente.TextChanged
      Try
         'CalculaTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged
      Try
         'CalculaTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class