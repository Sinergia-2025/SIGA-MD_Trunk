Public Class DepositosBancarios
   Implements IConParametros

#Region "Campos"

   Private _ComprobantesGrilla As New List(Of Entidades.CuentaCorrienteProvPago)
   Private _chequesPropios As List(Of Entidades.Cheque)
   Private _chequesTerceros As List(Of Entidades.Cheque)
   Private _estado As Estados
   Private _publicos As Eniac.Win.Publicos
   Private _proveedorGrilla As Eniac.Entidades.Proveedor
   Private _saldoCuota As Decimal = 0
   Private _Suc As Integer = 0
   Private _idCaja As Integer = 0
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = True
   Private _blnCajasModificables As Boolean = True
   Private _titChequesPropios As Dictionary(Of String, String)
   Private _tipoComprobante As String
   Private _eDepositosCuentasBancos As List(Of Entidades.DepositosCuentasBancos)
   Private _dtCupones As DataTable
   Private _idCuentaBanco As Integer
   Private _finalizoCargaDePantalla As Boolean
   Private _totalImportesCtaBancos As Decimal = 0 '-.PE-32070.-

#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         _chequesPropios = New List(Of Entidades.Cheque)()
         _chequesTerceros = New List(Of Entidades.Cheque)()

         _titChequesPropios = GetColumnasVisiblesGrilla(ugChequesPropios)
         AjustarColumnasGrilla(ugChequesPropios, _titChequesPropios)

         Dim oBancos = New Reglas.Bancos()
         cmbBancoPropio.DisplayMember = "Nombrebanco"
         cmbBancoPropio.ValueMember = "IdBanco"
         cmbBancoPropio.DataSource = oBancos.GetAll()
         cmbBancoPropio.SelectedIndex = -1

         '# Tipos de Cheque
         _publicos.CargaComboTiposCheques(Me.cmbTipoCheque)

         _Suc = actual.Sucursal.Id

         _publicos.CargaComboCajas(cmbCajas, _Suc, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         ugChequesTerceros.AgregarFiltroEnLinea({"Cliente", "Titular"}, {"Selecciono"})
         ugChequesPropios.AgregarFiltroEnLinea({"Banco"})

         ugDetalleCupones.AgregarFiltroEnLinea({"Banco", "NumeroCupon", "NombreCliente"})

         Nuevo()

         '------------------

         '# Si la pantalla NO proviene de la función Liquidaciones Tarjetas, quito la solapa Cupones y Cuentas de Banco
         '# Caso contrario preparo la pantalla para Liquidaciones de Tarjetas
         If _tipoComprobante = "LIQUIDATARJETA" Then
            PrepararLiquidacionesTarjeta()

            '# Tarjetas
            _publicos.CargaComboTarjetas(cmbTarjeta)
            cmbTarjeta.SelectedIndex = -1
         Else
            _tipoComprobante = "DEPOSITO"
            'tbcDetalle.TabPages.Remove(tbpCupones)

            '# Oculto el combo de Tarjeta y completo el espacio vacio con el control de Banco
            lblTarjeta.Visible = False
            cmbTarjeta.Visible = False

         End If

         _finalizoCargaDePantalla = True
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos"

   'Private Sub txtCodPostalChequePropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodPostalChequePropio.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   'Private Sub txtCodPostalCheque_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodPostalChequePropio.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   'Private Sub dtpFechaEmisionPropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaEmisionPropio.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   'Private Sub dtpFechaCobroPropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaCobroPropio.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   'Private Sub txtNroChequePropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNroChequePropio.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   'Private Sub txtImporteChequePropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtImporteChequePropio.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   Private Sub txtImporteChequePropio_Leave(sender As Object, e As EventArgs) Handles txtImporteChequePropio.Leave
      TryCatched(
         Sub()
            If txtImporteChequePropio.Text.Trim().Length = 0 Then
               txtImporteChequePropio.Text = "0.00"
            End If
         End Sub)
   End Sub

   'Private Sub txtSucursalBancoPropio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSucursalBancoPropio.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   Private Sub txtTotalEfectivo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTotalEfectivo.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub txtTotalEfectivo_Leave(sender As Object, e As EventArgs) Handles txtTotalEfectivo.Leave
      TryCatched(Sub() CalcularTotalDeposito())
   End Sub

   Private Sub txtTotalTarjeta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTotalTarjeta.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub txtTotalTarjeta_Leave(sender As Object, e As EventArgs) Handles txtTotalTarjeta.Leave
      TryCatched(Sub() CalcularTotalDeposito())
   End Sub

   Private Sub txtTotalTickets_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTotalTickets.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub cmbTipoCheque_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoCheque.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub txtNroOperacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNroOperacion.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub txtTotalTickets_Leave(sender As Object, e As EventArgs) Handles txtTotalTickets.Leave
      TryCatched(Sub() CalcularTotalDeposito())
   End Sub

   Private Sub btnInsertarChequePropio_Click(sender As Object, e As EventArgs) Handles btnInsertarChequePropio.Click
      TryCatched(
         Sub()
            If (Not bscCuentaBancariaPropio.FilaDevuelta Is Nothing Or
               Not bscCuentaBancariaPropiaCodigo.FilaDevuelta Is Nothing) And
               txtImporteChequePropio.Text <> "" Then
               If ValidarInsertarChequePropio() Then
                  InsertarChequePropioGrilla()
                  bscCuentaBancariaPropio.Focus()
               End If
            End If
         End Sub)
   End Sub

   Private Sub btnEliminarChequePropio_Click(sender As Object, e As EventArgs) Handles btnEliminarChequePropio.Click
      TryCatched(
         Sub()
            If ugChequesPropios.Rows.Count = 0 Then Exit Sub
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               EliminarLineaChequePropio()
            End If
         End Sub)
   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      TryCatched(
         Sub()
            Select Case Me.tbcDetalle.SelectedTab.Name
               Case "tbpDepositos1"
                  bscCuentaBancariaDestino.Focus()

               Case "tbpDepositos2"
                  bscCuentaBancariaPropio.Focus()

            End Select
         End Sub)
   End Sub

   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      TryCatched(Sub() Nuevo())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub() GrabarComprobante())
   End Sub

   Private Sub DepositosBancarios_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      TryCatched(
         Sub()
            If e.KeyCode = Keys.F4 And Me.tsbGrabar.Enabled Then
               tsbGrabar_Click(Me.tsbGrabar, New EventArgs())
            End If
         End Sub)
   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorClick() Handles bscCuentaBancariaDestino.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaDestino)
            Dim oCBancarias = New Reglas.CuentasBancarias()
            bscCuentaBancariaDestino.Datos = oCBancarias.GetFiltradoPorNombre(bscCuentaBancariaDestino.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaDestino.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCuentaBancariaDestino(e.FilaDevuelta)
               VerificarGrabarImprimir()
               optFechaAplicacion.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoCuentaBancariaDestino_BuscadorClick() Handles bscCodigoCuentaBancariaDestino.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias(bscCodigoCuentaBancariaDestino)
            Dim oCBancarias = New Reglas.CuentasBancarias()
            bscCodigoCuentaBancariaDestino.Datos = oCBancarias.GetFiltradoPorCodigo(bscCodigoCuentaBancariaDestino.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub

   Private Sub bscCodigoCuentaBancariaDestino_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCuentaBancariaDestino.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscCodigoCuentaBancariaDestino.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               bscCuentaBancariaDestino.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCuentaBancariaDestino.FilaDevuelta = e.FilaDevuelta
               VerificarGrabarImprimir()
            End If
         End Sub)
   End Sub

   Private Sub bscCuentaBancariaPropio_BuscadorClick() Handles bscCuentaBancariaPropio.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias(bscCuentaBancariaPropio)
            Dim oCBancarias = New Reglas.CuentasBancarias()
            bscCuentaBancariaPropio.Datos = oCBancarias.GetFiltradoPorNombre(bscCuentaBancariaPropio.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCuentaBancariaPropio_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaPropio.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing And Not bscCuentaBancariaDestino.FilaDevuelta Is Nothing Then

               If e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString() = bscCuentaBancariaDestino.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString() Then
                  MessageBox.Show("Ha seleccionado la misma Cuenta Bancaria que el Destino, NO es posible", Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Exit Sub
               End If

               CargarDatosCuentaBancaria(e.FilaDevuelta)
               txtNroChequePropio.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCuentaBancariaPropiaCodigo_BuscadorClick() Handles bscCuentaBancariaPropiaCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias(bscCuentaBancariaPropiaCodigo)
            Dim oCBancarias = New Reglas.CuentasBancarias()
            Dim codigo = bscCuentaBancariaPropiaCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCuentaBancariaPropiaCodigo.Datos = oCBancarias.GetFiltradoPorCodigo(codigo)
         End Sub)
   End Sub

   Private Sub bscCuentaBancariaPropiaCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaPropiaCodigo.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscCuentaBancariaPropiaCodigo.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               bscCuentaBancariaPropio.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCuentaBancariaPropio.FilaDevuelta = e.FilaDevuelta
               txtNroChequePropio.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
         Sub()
            For Each dr As DataRow In DirectCast(ugChequesTerceros.DataSource, DataTable).Rows
               dr("Selecciono") = chbTodos.Checked
            Next
            CalcularTotalChequesTerceros()
            CalcularTotalDeposito()
         End Sub)
   End Sub

   Private Sub chbTodosCupones_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodosCupones.CheckedChanged
      TryCatched(
         Sub()
            For Each dr As DataRow In DirectCast(ugDetalleCupones.DataSource, DataTable).Rows
               dr("Selecciono") = chbTodosCupones.Checked
            Next

            '# Calculo el total de los cupones
            CalcularTotalCupones()
            VerificarGrabarImprimir()
         End Sub)
   End Sub

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
         Sub()
            Dim TipoDeMovimiento As String = "E"
            Dim Banco As Integer = 0
            Dim blnCheqPropios As Boolean = False

            Dim rCheques = New Reglas.Cheques()
            Dim dtChequesTerceros = rCheques.GetTodos(actual.Sucursal.Id,
                                                      Integer.Parse(cmbCajas.SelectedValue.ToString()),
                                                      dtpChequeTerceroDesde.Value,
                                                      dtpChequeTerceroHasta.Value,
                                                      TipoDeMovimiento,
                                                      Banco,
                                                      0,
                                                      blnCheqPropios)


            ugChequesTerceros.DataSource = dtChequesTerceros
            chbTodos.Enabled = (ugChequesTerceros.Rows.Count > 0)

            txtTotalCheqTerceros.Text = "0.00"
            CalcularTotalDeposito()
         End Sub)
   End Sub

   Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
      TryCatched(Sub() CargarValoresInicialesChequesPropios())
   End Sub

   Private Sub ugChequesTerceros_CellChange(sender As Object, e As CellEventArgs) Handles ugChequesTerceros.CellChange
      TryCatched(
         Sub()
            CalcularTotalChequesTerceros()
            CalcularTotalDeposito()
         End Sub)
   End Sub

   Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
      TryCatched(Sub() CargarValoresInicialesChequesPropios())
   End Sub

#End Region

#Region "Metodos"

   Public Function ValidarCupones() As Boolean

      'If cmbTarjeta.SelectedIndex = -1 Then
      '   ShowMessage("ATENCIÓN: Debe seleccionar una Tarjeta.")
      '   cmbTarjeta.Focus()
      '   Return False
      'End If

      ''# Valido que la tarjeta tenga una cuenta bancaria asociada. Caso contrario, no se permite continuar.
      'Dim rTarjeta As Reglas.Tarjetas = New Reglas.Tarjetas
      'Dim eTarjeta As Entidades.Tarjeta = rTarjeta.GetUno(Integer.Parse(Me.cmbTarjeta.SelectedValue.ToString()))
      'If eTarjeta.CuentaBancaria.IdCuentaBancaria = 0 Then
      '   bscCuentaBancariaDestino.Text = ""
      '   ShowMessage("La Tarjeta seleccionada no tiene asociada una Cuenta Bancaria Destino. Debe asociar una para poder continuar.")
      '   cmbTarjeta.SelectedIndex = -1
      '   Return False
      'End If

      Return True
   End Function

   Private Sub PrepararLiquidacionesTarjeta()

      '# Título de la página
      Text = "Liquidaciones de Tarjetas"

      '# Fechas
      dtpFechaDesdeCupones.Value = Date.Now.AddMonths(-1)
      dtpFechaHastaCupones.Value = Date.Now

      '# En caso de que la función provenga de Liquidaciones Tarjetas.
      '# Quitar solapas de Cheques
      tbcDetalle.TabPages.Remove(tbpDepositos1)
      tbcDetalle.TabPages.Remove(tbpDepositos2)
      tbcDetalle.SelectedTab = tbpCupones

      '# De los TXT y Labels del pie de la página, dejar solamente visible el de Total
      lblTotalEfectivo.Visible = False
      txtTotalEfectivo.Visible = False
      lblTotalTarjeta.Visible = False
      txtTotalTarjeta.Visible = False
      lblTotalTickets.Visible = False
      txtTotalTickets.Visible = False
      lblChequesTerceros.Visible = False
      txtTotalCheqTerceros.Visible = False
      lblChequesPropios.Visible = False
      txtTotalCheqPropios.Visible = False
      optFechaAplicacion.Visible = False
      optFechaCheque.Visible = False
      lblFechaAplicada.Visible = False
      chbTodosCupones.Checked = False
      chbTodosCupones.Enabled = False
      cmbTarjeta.SelectedIndex = -1

      '# La cuenta bancaria destino se debe elegir seleccionando la tarjeta
      bscCuentaBancariaDestino.Enabled = False
      bscCuentaBancariaDestino.Text = ""

      '# Bancos
      LimpiarSolapaBancos()

   End Sub

   Private Sub LimpiarSolapaBancos()

      '# Cuentas de Banco
      bscCuentaBancoCodigo.FilaDevuelta = Nothing
      bscCuentaBancoNombre.FilaDevuelta = Nothing
      txtImporte.Text = "0.00"
      txtObservacionCuentaBanco.Clear()
      optIngreso.Checked = False
      optEgreso.Checked = False

      '# Grilla
      If _eDepositosCuentasBancos IsNot Nothing Then
         _eDepositosCuentasBancos.Clear()
         ugCuentasBancos.Rows.Refresh(RefreshRow.ReloadData)
      End If
      If _dtCupones IsNot Nothing Then
         _dtCupones.Clear()
         ugDetalleCupones.Rows.Refresh(RefreshRow.ReloadData)
      End If

   End Sub

   Private Function ValidarDeposito() As Boolean

      'If Me.cmbTipoDoc.SelectedIndex = -1 Then
      '   MessageBox.Show("Falta cargar el tipo de documento del Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.cmbTipoDoc.Focus()
      '   Return False
      'End If

      'If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
      '   MessageBox.Show("Falta cargar el Nro. de Documento del Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.bscCodigoCliente.Focus()
      '   Return False
      'End If

      For i As Integer = 0 To _chequesPropios.Count - 1
         If _chequesPropios(i).CuentaBancaria.IdCuentaBancaria = Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()) Then
            MessageBox.Show("Existe al menos un cheque que coincide con la Cuenta Bancaria Destino, NO es posible Grabar el Depósito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
         End If
      Next

      Return True

   End Function

   Private Sub GrabarComprobante()

      If ValidarDeposito() Then

         tsbGrabar.Enabled = False

         DejaChequesTercerosMarcados()

         Dim oReglasDepositos = New Reglas.Depositos()

         Dim oDeposito = New Entidades.Deposito()

         With oDeposito

            .CuentaBancaria = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))

            .Fecha = dtpFecha.Value
            .FechaAplicado = dtpFechaAplicacion.Value

            .UsoFechaCheque = optFechaCheque.Checked

            'cargo valores del comprobante
            .ImporteTotal = Decimal.Parse(txtTotal.Text)

            .Observacion = txtObservacion.Text

            If Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("IdMoneda").Value.ToString()) = Entidades.Moneda.Peso Then
               'cargo el efectivo para tenerlo discriminado
               .ImportePesos = txtTotalEfectivo.ValorNumericoPorDefecto(0D)
            Else
               'cargo el efectivo para tenerlo discriminado
               .ImporteDolares = txtTotalEfectivo.ValorNumericoPorDefecto(0D)
            End If

            '# Si el TipoComprobante es LIQUIDATARJETA, ImporteTarjetas = ImporteTotal (Importe total de los cupones liquidados)
            '.ImporteTarjetas = If(_tipoComprobante = "LIQUIDATARJETA", Decimal.Parse(Me.txtTotal.Text), Decimal.Parse(Me.txtTotalTarjeta.Text))

            .ImporteTarjetas = Decimal.Parse(Me.txtTotalTarjeta.Text)

            .ImporteTickets = Decimal.Parse(Me.txtTotalTickets.Text)

            .ImporteCheques = Decimal.Parse(Me.txtTotalCheqPropios.Text) + Decimal.Parse(Me.txtTotalCheqTerceros.Text)

            'cargo los Cheques Emitidos
            .ChequesPropios = Me._chequesPropios

            'cargo los cheques de terceros

            .ChequesTerceros = Me._chequesTerceros

            .CotizacionDolar = txtCotizacionDolar.ValorNumericoPorDefecto(0D)

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .IdCaja = Int32.Parse(Me.cmbCajas.SelectedValue.ToString())
            .NombreCaja = Me.cmbCajas.Text
            .Usuario = actual.Nombre
            .IdEstado = "NORMAL"

            '# Posibles comprobantes: LIQUIDATARJETA / DEPOSITO
            .TipoComprobante = New Reglas.TiposComprobantes().GetUno(_tipoComprobante)

            '# Proceso la información de Cupones antes de guardarla en la propiedad.
            '# En caso que no se esté usando la pantalla de Liquidaciones de Tarjetas, la propiedad queda vacia para que luego al visualizar el reporte, éste se visualice correctamente.
            Dim dtCupones As SistemaDataSet.TarjetasCuponesDataTable = New SistemaDataSet.TarjetasCuponesDataTable
            Dim drCupones As SistemaDataSet.TarjetasCuponesRow
            'If .TipoComprobante.IdTipoComprobante = "LIQUIDATARJETA" Then
            If Me.ugDetalleCupones.DataSource IsNot Nothing Then
               For Each e As DataRow In DirectCast(Me.ugDetalleCupones.DataSource, DataTable).Rows
                  If e("Selecciono").ToString() = Boolean.TrueString Then
                     drCupones = dtCupones.NewTarjetasCuponesRow
                     drCupones.IdTarjetaCupon = Integer.Parse(e(Entidades.DepositosTarjetasCupones.Columnas.IdTarjetaCupon.ToString()).ToString())
                     drCupones.NombreTarjeta = e(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()).ToString()
                     drCupones.NombreBanco = e("NombreBanco").ToString()
                     drCupones.IdTarjeta = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.IdTarjeta.ToString()).ToString())
                     drCupones.IdBanco = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.IdBanco.ToString()).ToString())
                     drCupones.FechaEmision = DateTime.Parse(e(Entidades.TarjetaCupon.Columnas.FechaEmision.ToString()).ToString())
                     drCupones.NumeroCupon = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.NumeroCupon.ToString()).ToString())
                     drCupones.NumeroLote = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.NumeroLote.ToString()).ToString())
                     drCupones.Cuotas = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.Cuotas.ToString()).ToString())
                     drCupones.Monto = Decimal.Parse(e(Entidades.TarjetaCupon.Columnas.Monto.ToString()).ToString())
                     drCupones.CodigoCliente = Long.Parse(e(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
                     drCupones.NombreCliente = e(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()

                     dtCupones.Rows.Add(drCupones)
                  End If
               Next
            End If
            'End If
            .TarjetasCupones = dtCupones

            '# Cuentas Banco asociadas
            .CuentasBancos = If(_eDepositosCuentasBancos IsNot Nothing, _eDepositosCuentasBancos, Nothing)
         End With

         oReglasDepositos.Insertar(oDeposito)

         If _tipoComprobante = "LIQUIDATARJETA" Then
            MessageBox.Show("Se ingresó la Liquidación Número" & oDeposito.NumeroDeposito, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show("Se ingresó el Depósito Número " & oDeposito.NumeroDeposito, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

         Dim di = New DepositosImprimir()
         di.ImprimirDeposito(oDeposito)

         Nuevo()

      End If

   End Sub

   Private Sub LimpiarCamposChequesPropios()
      bscCuentaBancariaPropio.Text = ""
      bscCuentaBancariaPropio.FilaDevuelta = Nothing
      bscCuentaBancariaPropiaCodigo.FilaDevuelta = Nothing
      cmbBancoPropio.SelectedIndex = -1
      txtNroChequePropio.Text = "0"
      txtCodPostalChequePropio.Text = "0"
      txtSucursalBancoPropio.Text = "0"
      dtpFechaCobroPropio.Value = Date.Now
      dtpFechaEmisionPropio.Value = Date.Now
      txtImporteChequePropio.Text = "0.00"
      cmbTipoCheque.SelectedValue = "F"
      txtNroOperacion.Clear()
   End Sub

   Private Sub VerificarGrabarImprimir()
      Me.tsbGrabar.Enabled = ((Me.bscCuentaBancariaDestino.Selecciono Or Me.bscCodigoCuentaBancariaDestino.Selecciono) And Decimal.Parse(Me.txtTotal.Text) > 0)
   End Sub

   Private Sub CalcularTotalCupones()

      Dim pago As Decimal

      If Me.ugDetalleCupones.Rows.Count = 0 Then Exit Sub
      For Each dr As DataRow In DirectCast(Me.ugDetalleCupones.DataSource, DataTable).Rows
         If Boolean.Parse(dr("Selecciono").ToString()) Then
            pago += Decimal.Parse(dr(Entidades.TarjetaCupon.Columnas.Monto.ToString()).ToString())
         End If
      Next

      pago += _totalImportesCtaBancos
      txtTotalTarjeta.Text = pago.ToString("N2")
   End Sub

   Private Sub CalcularTotalDeposito()

      Dim pago As Decimal = 0

      pago += Decimal.Parse(Me.txtTotalEfectivo.Text)

      pago += Decimal.Parse(Me.txtTotalTarjeta.Text)

      pago += Decimal.Parse(Me.txtTotalTickets.Text)

      pago += +Decimal.Parse(Me.txtTotalCheqTerceros.Text)

      pago += +Decimal.Parse(Me.txtTotalCheqPropios.Text)

      Me.txtTotal.Text = pago.ToString("#,##0.00")

      Me.VerificarGrabarImprimir()

   End Sub

   Private Sub CalcularTotalCuentasDeBancos() '-.PE-32070.-
      Dim importe As Decimal = 0

      For Each dr As UltraGridRow In Me.ugCuentasBancos.Rows
         importe += Decimal.Parse(dr.Cells("Importe").Value.ToString())

         If dr.Cells("IdTipoCuenta").Value.ToString() = "E" Then
            importe = importe * -1
         End If
      Next

      _totalImportesCtaBancos = importe
   End Sub


   Private Sub CalcularTotalChequesTerceros()
      Me.ugChequesTerceros.UpdateData()
      Dim pago As Decimal = 0

      For Each dr As DataRow In DirectCast(ugChequesTerceros.DataSource, DataTable).Rows
         If Boolean.Parse(dr("Selecciono").ToString()) Then
            pago += Decimal.Parse(dr("Importe").ToString())
         End If
      Next

      Me.txtTotalCheqTerceros.Text = pago.ToString("#,##0.00")

   End Sub

   Private Sub CalcularTotalChequesPropios()

      Dim pago As Decimal = 0

      For i As Integer = 0 To Me._chequesPropios.Count - 1
         pago += Me._chequesPropios(i).Importe
      Next

      Me.txtTotalCheqPropios.Text = pago.ToString("#,##0.00")

   End Sub

   Private Sub Nuevo()

      HabilitaSegunMoneda(Entidades.Moneda.Peso)

      bscCuentaBancariaDestino.Text = ""
      bscCuentaBancariaDestino.FilaDevuelta = Nothing
      _estado = Estados.Insercion
      txtTotalCheqPropios.Enabled = True
      txtObservacion.Text = String.Empty
      _ComprobantesGrilla.Clear()
      dtpFecha.Value = Date.Now
      dtpFechaAplicacion.Value = Date.Now
      txtTotalEfectivo.Text = "0.00"
      txtTotalTarjeta.Text = "0.00"
      txtTotalTickets.Text = "0.00"
      txtTotalCheqTerceros.Text = "0.00"
      txtTotalCheqPropios.Text = "0.00"
      txtTotal.Text = "0.00"
      tsbGrabar.Enabled = False

      '# Si la pantalla es Liquidaciones de Tarjeta preparo la pantalla como al inicio. Caso contrario mantengo el comportamiento estándar.
      If _tipoComprobante = "LIQUIDATARJETA" Then
         PrepararLiquidacionesTarjeta()
         Exit Sub
      End If

      tbcDetalle.SelectedTab = tbpDepositos1
      tbcDetalle.Enabled = True
      txtTotalCheqTerceros.Enabled = True

      _chequesPropios.Clear()

      ugChequesPropios.DataSource = _chequesPropios.ToArray()

      LimpiarCamposChequesPropios()

      CargarValoresInicialesChequesPropios()

      tbcDetalle.SelectedTab = tbpDepositos1

      _proveedorGrilla = Nothing

      CambiarEstadoControlesDetalle(False)

      'Me.cmbCajas.SelectedIndex = 0
      _publicos.CargaComboCajas(cmbCajas, _Suc, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

      bscCuentaBancariaDestino.Focus()

      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")

      '# Bancos
      LimpiarSolapaBancos()

   End Sub

   Private Sub InsertarChequePropioGrilla()

      Dim oLineaDetalle = New Entidades.Cheque()

      With oLineaDetalle
         '.IdCheque = 
         .CuentaBancaria = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaPropio.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
         .NumeroCheque = Integer.Parse(Me.txtNroChequePropio.Text)
         .Banco = New Reglas.Bancos().GetUno(Integer.Parse(Me.cmbBancoPropio.SelectedValue.ToString()))
         .IdBancoSucursal = Integer.Parse(Me.txtSucursalBancoPropio.Text)
         .Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalChequePropio.Text)
         .FechaEmision = Me.dtpFechaEmisionPropio.Value
         .FechaCobro = Me.dtpFechaCobroPropio.Value
         .Importe = Decimal.Parse(Me.txtImporteChequePropio.Text)
         '.Proveedor.IdProveedor = 0
         .EsPropio = True
         .Usuario = actual.Nombre
         .IdTipoCheque = Me.cmbTipoCheque.SelectedValue.ToString()
         .NombreTipoCheque = Me.cmbTipoCheque.Text
         .NroOperacion = Me.txtNroOperacion.Text
         .Cuit = actual.Sucursal.Empresa.CuitEmpresa
      End With

      _chequesPropios.Add(oLineaDetalle)

      ugChequesPropios.DataSource = Me._chequesPropios.ToArray()

      ugChequesPropios.Refresh()
      LimpiarCamposChequesPropios()
      CalcularTotalChequesPropios()
      CalcularTotalDeposito()

   End Sub

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)
      'Me.btnLimpiarComprobante.Enabled = Habilitado
      'Me.bscComprobante.Enabled = Habilitado
      'Me.txtImporte.Enabled = Habilitado
      'Me.btnInsertar.Enabled = Habilitado
      'Me.btnEliminar.Enabled = Habilitado
   End Sub

   Private Sub CargarDatosCuentaBancariaDestino(dr As DataGridViewRow)
      bscCuentaBancariaDestino.Text = dr.Cells("NombreCuenta").Value.ToString()
      HabilitaSegunMoneda(dr.Cells("IdMoneda").Value.ToString().ValorNumericoPorDefecto(0I))
   End Sub

   Private Sub HabilitaSegunMoneda(idMoneda As Integer)

      'txtTotalEfectivo.Enabled = idMoneda = Entidades.Moneda.Peso

      tbcDetalle.Enabled = idMoneda = Entidades.Moneda.Peso
      txtTotalTarjeta.Enabled = idMoneda = Entidades.Moneda.Peso
      txtTotalTickets.Enabled = idMoneda = Entidades.Moneda.Peso
   End Sub

   Private Sub CargarDatosCuentaBancaria(dr As DataGridViewRow)
      bscCuentaBancariaPropio.Text = dr.Cells("NombreCuenta").Value.ToString()
      cmbBancoPropio.SelectedValue = dr.Cells("IdBanco").Value
      txtSucursalBancoPropio.Text = dr.Cells("IdBancoSucursal").Value.ToString.Trim()
      txtCodPostalChequePropio.Text = dr.Cells("IdLocalidad").Value.ToString()
      txtNroChequePropio.Text = Me.ProximoChequeEmitido(Integer.Parse(dr.Cells("IdCuentaBancaria").Value.ToString())).ToString()
   End Sub

   Private Function ProximoChequeEmitido(IdCuentaBancaria As Integer) As Long

      Dim Ultimo = New Reglas.Cheques().GetUltimoEmitido(IdCuentaBancaria)

      Dim Proximo = Ultimo

      'controlo que no se repita el cheque ingresado
      Dim ent As Entidades.Cheque
      For i = 0 To _chequesPropios.Count - 1
         ent = _chequesPropios(i)
         If ent.IdCuentaBancaria = IdCuentaBancaria And ent.NumeroCheque >= Proximo Then
            Proximo = ent.NumeroCheque
         End If
      Next

      Proximo += 1

      Return Proximo

   End Function

   Private Sub EliminarLineaChequePropio()

      Dim dr = ugChequesPropios.FilaSeleccionada(Of Entidades.Cheque)()
      If dr IsNot Nothing Then
         _chequesPropios.Remove(dr)
         ugChequesPropios.DataSource = _chequesPropios.ToArray()

         CalcularTotalChequesPropios()
         CalcularTotalDeposito()
      End If

   End Sub

   Private Function ValidarInsertarChequePropio() As Boolean

      If Not Me.bscCuentaBancariaPropio.Selecciono And Not Me.bscCuentaBancariaPropiaCodigo.Selecciono Then
         MessageBox.Show("Debe seleccionar una Cuenta Bancaria.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCuentaBancariaPropio.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtImporteChequePropio.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un cheque con importe cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtImporteChequePropio.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtNroChequePropio.Text) = 0 Then
         MessageBox.Show("El número de cheque no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

      'controlo que no se repita el cheque ingresado
      Dim ent As Entidades.Cheque
      For i As Integer = 0 To Me._chequesPropios.Count - 1
         ent = Me._chequesPropios(i)
         If ent.NumeroCheque = Int32.Parse(Me.txtNroChequePropio.Text) And
                ent.Banco.IdBanco = Int32.Parse(Me.cmbBancoPropio.SelectedValue.ToString()) And
                ent.IdBancoSucursal = Int32.Parse(Me.txtSucursalBancoPropio.Text) And
                ent.Localidad.IdLocalidad = Int32.Parse(Me.txtCodPostalChequePropio.Text) Then
            MessageBox.Show("El cheque ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      Next


      Return True

   End Function

   Private Sub CargarValoresInicialesChequesPropios()

      Me.dtpChequeTerceroDesde.Value = Date.Now.AddMonths(-1)
      Me.dtpChequeTerceroHasta.Value = Date.Now

      Me._chequesTerceros.Clear()

      If TypeOf (ugChequesTerceros.DataSource) Is DataTable Then
         DirectCast(ugChequesTerceros.DataSource, DataTable).Rows.Clear()
      End If

      Me.chbTodos.Enabled = False

   End Sub


   Private Sub DejaChequesTercerosMarcados()


      Dim oLineaDetalle As Entidades.Cheque

      Me._chequesTerceros.Clear()

      For Each dr As UltraGridRow In Me.ugChequesTerceros.Rows
         'Si nunco lo marco esta nothing, luego pregunto si esta marcado o no
         If Not dr.Cells("Selecciono").Value Is Nothing Then
            If Boolean.Parse(dr.Cells("Selecciono").Value.ToString()) Then

               oLineaDetalle = New Entidades.Cheque()

               With oLineaDetalle
                  .IdCheque = Convert.ToInt64(dr.Cells("IdCheque").Value.ToString())
                  .CuentaBancaria = Nothing
                  .NumeroCheque = Int32.Parse(dr.Cells("NumeroCheque").Value.ToString())
                  .Banco = New Reglas.Bancos().GetUno(Int32.Parse(dr.Cells("IdBanco").Value.ToString()))
                  .IdBancoSucursal = Int32.Parse(dr.Cells("IdBancoSucursal").Value.ToString())
                  .Localidad.IdLocalidad = Int32.Parse(dr.Cells("IdLocalidad").Value.ToString())
                  .FechaEmision = Date.Parse(dr.Cells("FechaEmision").Value.ToString())
                  .FechaCobro = Date.Parse(dr.Cells("FechaCobro").Value.ToString())
                  .Importe = Decimal.Parse(dr.Cells("Importe").Value.ToString())
                  .EsPropio = False
                  .Usuario = actual.Nombre
                  .Titular = dr.Cells("Titular").Value.ToString()
                  .Cuit = dr.Cells("CUIT").Value.ToString()
               End With

               Me._chequesTerceros.Add(oLineaDetalle)

            End If
         End If
      Next

   End Sub

#End Region

#Region "Métodos Públicos"

   '# Implemento la I para setear el tipo de comprobante, en caso que venga de la funcion Liquidaciones de Tarjetas
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: LIQUIDATARJETA")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

#End Region

   Private Sub btnBuscarCupones_Click(sender As Object, e As EventArgs) Handles btnBuscarCupones.Click
      If Not ValidarCupones() Then Exit Sub
      TryCatched(
         Sub()
            Dim rTarjetasCupones = New Reglas.TarjetasCupones
            Dim fechaDesde = dtpFechaDesdeCupones.Value
            Dim fechaHasta = dtpFechaHastaCupones.Value
            Dim idTarjeta = 0
            Dim idCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

            _dtCupones = New DataTable()
            _dtCupones = rTarjetasCupones.GetInformeCupones({actual.Sucursal},
                                                            idTarjetaCupon:=0,
                                                            fechaIngresoDesde:=fechaDesde,
                                                            fechaIngresoHasta:=fechaHasta,
                                                            idEstadoTarjeta:=Entidades.TarjetaCupon.Estados.ENCARTERA.ToString(),
                                                            fechaLiquidacionDesde:=Nothing,
                                                            fechaLiquidacionHasta:=Nothing,
                                                            numeroCupon:=0,
                                                            numeroLote:=0,
                                                            fechaEnCarteraAl:=Nothing,
                                                            idCaja:=idCaja,
                                                            idBanco:=0,
                                                            idCliente:=0,
                                                            idTarjeta:=idTarjeta,
                                                            idSituacion:=0)
            '# Agrego la columna "Selecciono"
            _dtCupones.Columns.Add("Selecciono")
            For Each dr As DataRow In _dtCupones.Rows
               dr("Selecciono") = False
            Next

            Me.ugDetalleCupones.DataSource = _dtCupones
            Me.chbTodosCupones.Enabled = (Me.ugDetalleCupones.Rows.Count > 0)

            If _dtCupones.Rows.Count = 0 Then
               ShowMessage("NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

   Private Sub btnLimpiarCB_Click(sender As Object, e As EventArgs) Handles btnLimpiarCB.Click
      TryCatched(
         Sub()
            bscCuentaBancoCodigo.Text = ""
            bscCuentaBancoNombre.Text = ""
            bscCuentaBancoCodigo.Enabled = True
            bscCuentaBancoNombre.Enabled = True
            txtImporte.Text = "0.00"
            optEgreso.Checked = False
            optIngreso.Checked = False
            txtObservacionCuentaBanco.Clear()

            bscCuentaBancoCodigo.FilaDevuelta = Nothing
            bscCuentaBancoNombre.FilaDevuelta = Nothing
            bscCuentaBancoCodigo.Focus()

            FormatearGrillaCuentasBancos()
         End Sub)
   End Sub

   Private Sub bscCuentaBancoCodigo_BuscadorClick() Handles bscCuentaBancoCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscCuentaBancoCodigo)
            Dim rCuentasBancos = New Reglas.CuentasBancos()
            bscCuentaBancoCodigo.Datos = rCuentasBancos.GetTodosPorCodigo(bscCuentaBancoCodigo.Text.Trim())

            If Not bscCuentaBancoCodigo.FilaDevuelta Is Nothing Then
               txtImporte.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCuentaBancoNombre_BuscadorClick() Handles bscCuentaBancoNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscCuentaBancoNombre)
            Dim rCuentasBancos = New Reglas.CuentasBancos()
            bscCuentaBancoNombre.Datos = rCuentasBancos.GetTodosPorNombre(bscCuentaBancoNombre.Text.Trim())

            If Not bscCuentaBancoNombre.FilaDevuelta Is Nothing Then
               txtImporte.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCuentaBancoNombre_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancoNombre.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not bscCuentaBancoNombre.FilaDevuelta Is Nothing Then
               bscCuentaBancoNombre.Text = bscCuentaBancoNombre.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.NombreCuentaBanco.ToString()).Value.ToString()
               bscCuentaBancoCodigo.Text = bscCuentaBancoNombre.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdCuentaBanco.ToString()).Value.ToString()
               _idCuentaBanco = Integer.Parse(bscCuentaBancoNombre.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdCuentaBanco.ToString()).Value.ToString())
               Dim tipoCuenta As String = bscCuentaBancoNombre.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdTipoCuenta.ToString()).Value.ToString()

               '# Tipo de Cuenta
               If tipoCuenta = "Ingreso" Then
                  optIngreso.Checked = True
                  optEgreso.Checked = False
               Else
                  optIngreso.Checked = False
                  optEgreso.Checked = True
               End If

               bscCuentaBancoCodigo.Enabled = False
               bscCuentaBancoNombre.Enabled = False

               txtImporte.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCuentaBancoCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancoCodigo.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not bscCuentaBancoCodigo.FilaDevuelta Is Nothing Then
               bscCuentaBancoCodigo.Text = bscCuentaBancoCodigo.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdCuentaBanco.ToString()).Value.ToString()
               bscCuentaBancoNombre.Text = bscCuentaBancoCodigo.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.NombreCuentaBanco.ToString()).Value.ToString()
               _idCuentaBanco = Integer.Parse(bscCuentaBancoCodigo.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdCuentaBanco.ToString()).Value.ToString())
               Dim tipoCuenta As String = bscCuentaBancoCodigo.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdTipoCuenta.ToString()).Value.ToString()

               '# Tipo de Cuenta
               If tipoCuenta = "Ingreso" Then
                  optIngreso.Checked = True
                  optEgreso.Checked = False
               Else
                  optIngreso.Checked = False
                  optEgreso.Checked = True
               End If

               bscCuentaBancoCodigo.Enabled = False
               bscCuentaBancoNombre.Enabled = False

               txtImporte.Focus()
            End If
         End Sub)
   End Sub

   Private Sub btnLimpiarCupones_Click(sender As Object, e As EventArgs) Handles btnLimpiarCupones.Click
      TryCatched(
         Sub()
            dtpFechaDesdeCupones.Value = Date.Now.AddMonths(-1)
            dtpFechaHastaCupones.Value = Date.Now

            If ugDetalleCupones.Rows.Count > 0 Then
               _dtCupones.Clear()
               ugDetalleCupones.Rows.Refresh(RefreshRow.ReloadData)
            End If

            txtTotal.Text = "0.00"

            chbTodosCupones.Enabled = False
            chbTodosCupones.Checked = False
            tsbGrabar.Enabled = False
         End Sub)
   End Sub

   Private Sub btnInsertarCB_Click(sender As Object, e As EventArgs) Handles btnInsertarCB.Click
      TryCatched(
         Sub()
            If Not Me.bscCuentaBancoCodigo.Selecciono And Not Me.bscCuentaBancoNombre.Selecciono Then Exit Sub

            If Decimal.Parse(Me.txtImporte.Text) = 0 Then
               ShowMessage("El importe ingresado no puede ser $0.00.")
               Me.txtImporte.Focus()
               Exit Sub
            End If

            '# Valido que la Cuenta Banco no esté en la grilla
            If DirectCast(Me._eDepositosCuentasBancos, List(Of Entidades.DepositosCuentasBancos)) IsNot Nothing Then
               If DirectCast(Me._eDepositosCuentasBancos, List(Of Entidades.DepositosCuentasBancos)).Exists(Function(x) x.IdCuentaBanco = _idCuentaBanco) Then
                  ShowMessage("Esta Cuenta Banco ya fué agregada.")
                  Me.btnLimpiarCupones.Focus()
                  Exit Sub
               End If
            End If

            '# Armo mis variables a utilizar
            Dim importe = Decimal.Parse(txtImporte.Text)
            Dim tipoCuenta = If(optIngreso.Checked, "I", "E")
            Dim nombreCuenta = bscCuentaBancoNombre.Text
            Dim observacion = txtObservacionCuentaBanco.Text

            '# Agrego la CuentaBanco
            If _eDepositosCuentasBancos Is Nothing Then
               _eDepositosCuentasBancos = New List(Of Entidades.DepositosCuentasBancos)
               Me.ugCuentasBancos.DataSource = _eDepositosCuentasBancos
            End If
            DirectCast(Me._eDepositosCuentasBancos, List(Of Entidades.DepositosCuentasBancos)).Add(New Entidades.DepositosCuentasBancos() _
                                                                                                   With {.IdCuentaBanco = _idCuentaBanco,
                                                                                                         .NombreCuentaBanco = nombreCuenta,
                                                                                                         .IdTipoCuenta = tipoCuenta,
                                                                                                         .Importe = importe,
                                                                                                         .Observacion = observacion
                                                                                                      })
            '# Recargo el Source de la grilla
            ugCuentasBancos.Rows.Refresh(RefreshRow.ReloadData)

            btnLimpiarCB_Click(sender, e)
         End Sub)
   End Sub

   Private Sub btnEliminarCB_Click(sender As Object, e As EventArgs) Handles btnEliminarCB.Click
      Try
         If Me.ugCuentasBancos.Rows.Count = 0 Then Exit Sub

         Dim cuentaBanco As Entidades.DepositosCuentasBancos = GetCuentaBancoSeleccionada()
         If cuentaBanco IsNot Nothing Then
            DirectCast(Me._eDepositosCuentasBancos, List(Of Entidades.DepositosCuentasBancos)).Remove(cuentaBanco)
            Me.ugCuentasBancos.Rows.Refresh(RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub FormatearGrillaCuentasBancos()
      For Each col As UltraGridColumn In ugCuentasBancos.DisplayLayout.Bands(0).Columns
         col.Hidden = False
         If col.Key = Entidades.DepositosCuentasBancos.Columnas.NumeroDeposito.ToString() Or
            col.Key = Entidades.DepositosCuentasBancos.Columnas.IdSucursal.ToString() Or
            col.Key = "Password" Or
            col.Key = "Usuario" Or
            col.Key = Entidades.DepositosCuentasBancos.Columnas.IdTipoComprobante.ToString() Then
            col.Hidden = True
         End If
      Next
   End Sub

   Private Function GetCuentaBancoSeleccionada() As Entidades.DepositosCuentasBancos
      If ugCuentasBancos.ActiveRow IsNot Nothing AndAlso
         ugCuentasBancos.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugCuentasBancos.ActiveRow.ListObject) Is Entidades.DepositosCuentasBancos Then
         Return DirectCast(ugCuentasBancos.ActiveRow.ListObject, Entidades.DepositosCuentasBancos)
      End If
      Return Nothing
   End Function

   Private Function GetChequeSeleccionado() As Entidades.Cheque
      If ugChequesPropios.ActiveRow IsNot Nothing AndAlso
         ugChequesPropios.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugChequesPropios.ActiveRow.ListObject) Is Entidades.Cheque Then
         Return DirectCast(ugChequesPropios.ActiveRow.ListObject, Entidades.Cheque)
      End If
      Return Nothing
   End Function

   Private Sub ugDetalleCupones_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalleCupones.AfterRowActivate
      Try

         If ugDetalleCupones.Rows.Count = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         '# Calculo el total de los cupones
         Me.CalcularTotalCupones()
         Me.VerificarGrabarImprimir()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugDetalleCupones_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalleCupones.CellChange
      Try

         Me.ugDetalleCupones.UpdateData()

         If ugDetalleCupones.Rows.Count = 0 Then Exit Sub
         Me.Cursor = Cursors.WaitCursor

         '' Calculo total de ajustes realizados en Cuentas de Bancos
         'Me.CalcularTotalCuentasDeBancos()

         ''# Calculo el total de los cupones
         'Me.CalcularTotalCupones()

         TryCatched(
            Sub()
               Me.CalcularTotalCupones()
               CalcularTotalDeposito()
            End Sub)


         'Me.VerificarGrabarImprimir()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugCuentasBancos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugCuentasBancos.DoubleClickCell

      Try
         If Me.ugCuentasBancos.Rows.Count = 0 Then Exit Sub

         Dim cuentaBanco As Entidades.DepositosCuentasBancos = GetCuentaBancoSeleccionada()
         If cuentaBanco IsNot Nothing Then
            Me.bscCuentaBancoCodigo.Text = cuentaBanco.IdCuentaBanco.ToString()
            Me._idCuentaBanco = cuentaBanco.IdCuentaBanco
            Me.bscCuentaBancoNombre.Text = cuentaBanco.NombreCuentaBanco
            Me.txtImporte.Text = cuentaBanco.Importe.ToString()
            If cuentaBanco.IdTipoCuenta = "E" Then
               Me.optEgreso.Checked = True
               Me.optIngreso.Checked = Not optEgreso.Checked
            Else
               Me.optEgreso.Checked = False
               'Me.optIngreso.Checked = True
               Me.optIngreso.Checked = Not optEgreso.Checked
            End If
            Me.txtObservacionCuentaBanco.Text = cuentaBanco.Observacion

            Me.bscCuentaBancoCodigo.Enabled = False
            Me.bscCuentaBancoNombre.Enabled = False
            Me.bscCuentaBancoCodigo.Selecciono = True

            '# Elimino la CB de la grilla
            DirectCast(Me._eDepositosCuentasBancos, List(Of Entidades.DepositosCuentasBancos)).Remove(cuentaBanco)
            Me.ugCuentasBancos.Rows.Refresh(RefreshRow.ReloadData)

            Me.txtImporte.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

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

   Private Sub ugChequesPropios_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugChequesPropios.DoubleClickCell
      Try
         If Me.ugChequesPropios.Rows.Count = 0 Then Exit Sub

         Dim cheque As Entidades.Cheque = GetChequeSeleccionado()
         If cheque IsNot Nothing Then
            Me.cmbTipoCheque.SelectedValue = cheque.IdTipoCheque.ToString()
            Me.bscCuentaBancariaPropiaCodigo.Text = cheque.IdCuentaBancaria.ToString()
            Me.bscCuentaBancariaPropiaCodigo.PresionarBoton()
            Me.txtNroChequePropio.Text = cheque.NumeroCheque.ToString()
            Me.cmbBancoPropio.SelectedValue = cheque.IdBanco.ToString()
            Me.txtSucursalBancoPropio.Text = cheque.IdBancoSucursal.ToString()
            Me.txtCodPostalChequePropio.Text = cheque.Localidad.IdLocalidad.ToString()
            Me.txtNroOperacion.Text = cheque.NroOperacion.ToString()
            Me.dtpFechaEmisionPropio.Value = cheque.FechaEmision
            Me.dtpFechaCobroPropio.Value = cheque.FechaCobro
            Me.txtImporteChequePropio.Text = cheque.Importe.ToString()
            Me.txtImporte.Text = cheque.Importe.ToString()

            '# Elimino el cheque de la grilla
            EliminarLineaChequePropio()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbTarjeta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTarjeta.SelectedIndexChanged
      If _finalizoCargaDePantalla AndAlso Me.cmbTarjeta.SelectedIndex <> -1 Then

         Dim idCuentaBancaria As String = DirectCast(Me.cmbTarjeta.SelectedItem, DataRowView).Row(Entidades.CuentaBancaria.Columnas.IdCuentaBancaria.ToString()).ToString()
         If Not String.IsNullOrEmpty(idCuentaBancaria) Then
            Me.bscCodigoCuentaBancariaDestino.Text = idCuentaBancaria
            Me.bscCodigoCuentaBancariaDestino.PresionarBoton()

         Else

            Me.bscCodigoCuentaBancariaDestino.Selecciono = Nothing
            Me.bscCuentaBancariaDestino.Text = ""
         End If
      End If
   End Sub

End Class