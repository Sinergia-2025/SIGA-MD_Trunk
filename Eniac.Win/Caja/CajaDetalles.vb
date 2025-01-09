Public Class CajaDetalles

   Private _publicos As Publicos
   Private dtCheques As DataTable = New DataTable()
   Private _CheqPropio As Boolean = False
   Private _utilizaCentroCostos As Boolean = False

#Region "Propiedades"
   Public Property IdSucursalMovimiento As Integer
   Public Property NumeroPlanilla() As Integer
   Public Property NroDeMovimiento() As Integer
   Public Property Operacion() As Reglas.CajaDetalles.TipoOperacion
   Public Property TipoDeMovimiento() As Reglas.CajaDetalles.TipoMovimiento

   Private _cajaNombre As Entidades.CajaNombre
   Public Property CajaNombre() As Entidades.CajaNombre
      Get
         If _cajaNombre Is Nothing Then
            _cajaNombre = New Entidades.CajaNombre()
         End If
         Return _cajaNombre
      End Get
      Set(value As Entidades.CajaNombre)
         _cajaNombre = value
      End Set
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            SetColumnIndexes()

            _publicos.CargaComboMonedas1(cmbMonedaBancos)
            cmbMonedaBancos.SelectedValue = Entidades.Moneda.Peso

            If Reglas.Publicos.TieneModuloContabilidad Then
               'txtTarjetas.Visible = False
               txtBancos.Visible = True
               'txtTarjetas.LabelAsoc.Visible = False
               txtBancos.LabelAsoc.Visible = True
               chbGeneraContabilidad.Visible = True

               If Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
                  _utilizaCentroCostos = True
                  _publicos.CargaComboCentroCostos(cmbCentroCosto)
                  cmbCentroCosto.Visible = True
                  cmbCentroCosto.LabelAsoc.Visible = True
                  cmbCentroCosto.Enabled = Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosCaja
               End If
            End If

            _publicos.CargaComboAFIPConceptoCM05(cmbAFIPConceptoCM05, tipo:=Nothing)

            If Operacion = Reglas.CajaDetalles.TipoOperacion.Modificacion Or Operacion = Reglas.CajaDetalles.TipoOperacion.Consulta Then

               If Operacion = Reglas.CajaDetalles.TipoOperacion.Modificacion Then
                  Text = "Editar Movimiento"
               Else
                  Text = "Consultar Movimiento"
               End If


               CargarMovimiento()
               tbcDetalle.SelectedTab = tbpCheques
               CargarCheques()
               tbcDetalle.SelectedTab = tbpCuponesTarjetas
               CargarCuponesTarjetas()
               tbcDetalle.SelectedTab = tbpCheques
               SetTotalCheques()
               SetTotalCupones()
               txtNMovimiento.Text = NroDeMovimiento.ToString()

               btnAgregarCuponTarjeta.Enabled = False
               btnEliminarCuponTarjeta.Enabled = False

            ElseIf Operacion = Reglas.CajaDetalles.TipoOperacion.Nuevo Then

               Text = "Nuevo Movimiento"
               dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   'Date.Now()
               txtCotizacionDolares.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
            End If

            If Not Reglas.Publicos.AFIPUtilizaCM05 Then
               chbAFIPConceptoCM05.Checked = False
               chbAFIPConceptoCM05.Enabled = False
            End If

            MostrarOcultarNroMovimiento()
            txtPlanillaActual.Text = NumeroPlanilla.ToString()
            txtCaja.Text = CajaNombre.NombreCaja
         End Sub)
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      bscCuentaCaja.Focus()
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      ElseIf keyData = (Keys.Alt Or Keys.C) Then
         tbcDetalle.SelectedTab = tbpCheques
      ElseIf keyData = (Keys.Alt Or Keys.T) Then
         tbcDetalle.SelectedTab = tbpCuponesTarjetas
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub bscCuentaCaja_BuscadorClick() Handles bscCuentaCaja.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCuentasDeCajas2(bscCuentaCaja)
         bscCuentaCaja.Datos = New Reglas.CuentasDeCajas().GetTodas(bscCuentaCaja.Text)
      End Sub)
   End Sub
   Private Sub bscNombreCuentaCaja_BuscadorClick() Handles bscNombreCuentaCaja.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCuentasDeCajas2(bscNombreCuentaCaja)
         bscNombreCuentaCaja.Datos = New Reglas.CuentasDeCajas().GetPorNombre(bscNombreCuentaCaja.Text)
      End Sub)
   End Sub

   Private Sub bscCuentaCaja_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaCaja.BuscadorSeleccion, bscNombreCuentaCaja.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            CargarDatosCuentaDeCaja(e.FilaDevuelta)
         End If
      End Sub)
   End Sub

   Private Sub optIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles optIngreso.CheckedChanged
      TryCatched(Sub() SetearTipoMovimiento())
   End Sub
   Private Sub optEgreso_CheckedChanged(sender As Object, e As EventArgs) Handles optEgreso.CheckedChanged
      TryCatched(Sub() SetearTipoMovimiento())
   End Sub

   Private Sub btnAgregarCheque_Click(sender As Object, e As EventArgs) Handles btnAgregarCheque.Click
      TryCatched(
      Sub()
         Using frmChequesDetalleAyuda = New ChequesDetalleAyuda(Me.CajaNombre.IdCaja, 0)
            If ValidarTipoDeMovimiento() Then
               frmChequesDetalleAyuda.TipoDeMovimiento = If(optIngreso.Checked, "I", "E")
               frmChequesDetalleAyuda.ShowDialog(Me)

               If frmChequesDetalleAyuda.blSeleccionados Then
                  AgregarCheques(frmChequesDetalleAyuda.dtSelectedCheques)
               End If

               SetTotalCheques()
            End If
         End Using
      End Sub)
   End Sub

   Private Sub btnEliminarCheque_Click(sender As Object, e As EventArgs) Handles btnEliminarCheque.Click
      TryCatched(
      Sub()
         If dgvCheques.SelectedRows.Count > 0 Then
            Dim mensaje As String = String.Empty

            If dgvCheques.SelectedColumns.Count > 1 Then
               mensaje = "¿Realmente desea eliminar los cheques de la lista?"
            Else
               mensaje = "¿Realmente desea eliminar el cheque de la lista?"
            End If

            If ShowPregunta(mensaje) = DialogResult.Yes Then

               For Each cgRow As DataGridViewRow In dgvCheques.SelectedRows
                  DirectCast(cgRow.DataBoundItem, DataRowView).Row.Delete()
               Next

               dgvCheques.DataSource = dtCheques
            End If

         Else
            ShowMessage("Por favor seleccione el cheque a eliminar.")
         End If

         SetTotalCheques()
      End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         If Operacion = Reglas.CajaDetalles.TipoOperacion.Nuevo Then
            If GuardarNuevoMovimiento() Then
               Close()
            End If

         ElseIf Operacion = Reglas.CajaDetalles.TipoOperacion.Modificacion Then
            If ActualizarMovimiento() Then
               Close()
            End If

         End If
      End Sub)
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub txtEfectivo_Enter(sender As Object, e As EventArgs) Handles _
               txtPesos.Enter, txtPesos.Click,
               txtDolares.Enter, txtDolares.MouseEnter,
               txtTickets.Enter, txtTickets.MouseEnter,
               txtTarjetas.Enter, txtTarjetas.MouseEnter,
               txtBancos.Enter, txtBancos.MouseEnter,
               txtCotizacionDolares.Enter, txtCotizacionDolares.MouseEnter
      TryCatched(
      Sub()
         If TypeOf (sender) Is TextBox Then
            DirectCast(sender, TextBox).SelectAll()
         End If
      End Sub)
   End Sub

   Private Sub txtBancos_TextChanged(sender As Object, e As EventArgs) Handles txtBancos.TextChanged
      TryCatched(Sub() cmbMonedaBancos.Enabled = txtBancos.ValorNumericoPorDefecto(0D) <> 0)
   End Sub

   Private Sub chbAFIPConceptoCM05_CheckedChanged(sender As Object, e As EventArgs) Handles chbAFIPConceptoCM05.CheckedChanged
      TryCatched(
      Sub()
         If Not chbAFIPConceptoCM05.Checked Then
            cmbAFIPConceptoCM05.SelectedIndex = -1
         End If

         cmbAFIPConceptoCM05.Enabled = chbAFIPConceptoCM05.Checked

         If chbAFIPConceptoCM05.Checked Then
            cmbAFIPConceptoCM05.Select()
         End If
      End Sub)
   End Sub

#Region "Eventos Cupones Tarjeta"
   Private Sub btnAgregarCuponTarjeta_Click(sender As Object, e As EventArgs) Handles btnAgregarCuponTarjeta.Click
      TryCatched(
      Sub()
         If ValidarTipoDeMovimiento() Then
            Using frm = New CajaDetallesAyudaCuponesTarjetas()
               frm.cajaCupones = CajaNombre.IdCaja
               Dim estados = If(optIngreso.Checked, {Entidades.TarjetaCupon.Estados.ALTA}, {Entidades.TarjetaCupon.Estados.ENCARTERA})
               If frm.ShowDialog(Me, estados) = DialogResult.OK Then
                  SetCuponesTarjetasDataSource(frm.CuponesSeleccionados)
                  SetTotalCupones()
               End If
            End Using
         End If
      End Sub)
   End Sub
   Private Sub btnEliminarCuponTarjeta_Click(sender As Object, e As EventArgs) Handles btnEliminarCuponTarjeta.Click
      TryCatched(
      Sub()
         Dim dr = ugCuponesTarjetas.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar el cupón seleccionado?") = DialogResult.Yes Then
               dr.Delete()
               ugCuponesTarjetas.DataSource(Of DataTable).AcceptChanges()
               ugCuponesTarjetas.Rows.Refresh(RefreshRow.ReloadData)
               SetTotalCupones()
            End If
         Else
            ShowMessage("Debe seleccionar un cupón para poder eliminar.")
         End If
      End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub CargarDatosCuentaDeCaja(dr As DataGridViewRow)

      bscCuentaCaja.Text = dr.Cells("IdCuentaCaja").Value.ToString()
      bscNombreCuentaCaja.Text = dr.Cells("NombreCuentaCaja").Value.ToString()

      If _utilizaCentroCostos Then
         cmbCentroCosto.SelectedValue = dr.Cells(Entidades.CuentaDeCaja.Columnas.IdCentroCosto.ToString()).Value
      End If

      'Me.bscNombreCuentaCaja.Enabled = False
      'Me.bscCuentaCaja.Enabled = False

      'Si esta NO habilitado es porque cargo un cheque, y no puedo cambiar el sentido de la cuenta
      If optIngreso.Enabled Then
         If dr.Cells("IdTipoCuenta").Value.ToString() = "I" Then
            optIngreso.Checked = True
         Else
            optEgreso.Checked = True
         End If
      End If

      Dim idConceptoCM05 As Integer? = Nothing
      Dim idConceptoCM05Dr As String = dr.Cells(Entidades.CuentaDeCaja.Columnas.IdConceptoCM05.ToString()).Value.ToString()
      If IsNumeric(idConceptoCM05Dr) Then
         idConceptoCM05 = Integer.Parse(idConceptoCM05Dr)
      End If
      If idConceptoCM05.HasValue Then
         chbAFIPConceptoCM05.Checked = True
         cmbAFIPConceptoCM05.SelectedValue = idConceptoCM05.Value
      Else
         chbAFIPConceptoCM05.Checked = False
      End If

      If Operacion = Reglas.CajaDetalles.TipoOperacion.Nuevo Then
         chbGeneraContabilidad.Checked = Boolean.Parse(dr.Cells(Entidades.CuentaDeCaja.Columnas.GeneraContabilidad.ToString()).Value.ToString())
      End If
      'If Reglas.Publicos.TieneModuloContabilidad = False Then

      '   txtBancos.ReadOnly = False
      'Else
      '   txtBancos.ReadOnly = chbGeneraContabilidad.Checked
      'End If
      txtPesos.Focus()

   End Sub

   Private Function ValidarForm() As Boolean
      Dim sistema = Publicos.GetSistema()
      If sistema.FechaVencimiento.Subtract(dtpFecha.Value).Days < 0 Then
         ShowMessage(String.Format("La fecha es mayor a la validez del sistema, el {0:dd/MM/yyyy}.", sistema.FechaVencimiento))
         dtpFecha.Select()
         Return False
      End If

      If Not bscCuentaCaja.Selecciono And Not bscNombreCuentaCaja.Selecciono Then
         ShowMessage("Por favor ingrese un código de cuenta.")
         bscCuentaCaja.Select()
         Return False
      End If

      'If Not ValidadCuentaDeCaja(CInt(Me.txtCodigoCuenta.Text)) Then
      '   MessageBox.Show("No existe ningun código de cuenta para el código ingreado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
      '   Me.bscCuentaCaja.Focus()
      '   Return False
      'End If

      'Debe ser opcional.
      'If Len(Me.txtObservaciones.Text.ToString()) = 0 Then
      '   MessageBox.Show("La observación no puede quedar en blanco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
      '   Me.txtObservaciones.Focus()
      '   Return False
      'End If

      If txtBancos.ValorNumericoPorDefecto(0D) <> 0 AndAlso cmbMonedaBancos.SelectedIndex = -1 Then
         ShowMessage("Debe indicar la moneda para el importe de bancos")
         cmbMonedaBancos.Select()
         Return False
      End If

      If Not ValidarTipoDeMovimiento() Then
         Return False
      End If

      If chbAFIPConceptoCM05.Checked And cmbAFIPConceptoCM05.SelectedIndex = -1 Then
         cmbAFIPConceptoCM05.Select()
         ShowMessage("ATENCION: Activo el Concepto de CM05 pero no seleccionó uno. Debe elegir una.")
         Return False
      End If


      If txtPesos.ValorNumericoPorDefecto(0D) = 0 And
         txtDolares.ValorNumericoPorDefecto(0D) = 0 And
         txtTickets.ValorNumericoPorDefecto(0D) = 0 And
         txtTotalCheques.ValorNumericoPorDefecto(0D) = 0 And
         txtTarjetas.ValorNumericoPorDefecto(0D) = 0 And
         txtBancos.ValorNumericoPorDefecto(0D) = 0 Then

         ShowMessage("Por favor ingrese un importe.")
         txtPesos.Select()
         Return False
      End If
      If Decimal.Parse(txtPesos.Text.ToString()) < 0 AndAlso Not Reglas.Publicos.PlanillaCajaImportesNegativosPesos Then
         ShowMessage("No se permiten importes negativos en Pesos.")
         Return False
      End If

      If Decimal.Parse(txtTickets.Text.ToString()) < 0 AndAlso Not Reglas.Publicos.PlanillaCajaImportesNegativosTickets Then
         ShowMessage("No se permiten importes negativos en Tickets.")
         Return False
      End If

      If Decimal.Parse(txtBancos.Text.ToString()) < 0 AndAlso Not Reglas.Publicos.PlanillaCajaImportesNegativosBancos Then
         ShowMessage("No se permiten importes negativos en Bancos.")
         Return False
      End If

      If Decimal.Parse(txtDolares.Text.ToString()) < 0 AndAlso Not Reglas.Publicos.PlanillaCajaImportesNegativosDolares Then
         ShowMessage("No se permiten importes negativos en Dólares.")
         Return False
      End If

      If Not Reglas.Publicos.PlanillaCajaImportesNegativosTotal Then
         Dim total As Decimal
         Dim bancos As Decimal = Decimal.Parse(txtBancos.Text.ToString()) * Decimal.Parse(IIf(cmbMonedaBancos.ValorSeleccionado(Of Integer) = Entidades.Moneda.Peso, 1, Decimal.Parse(Me.txtCotizacionDolares.Text.ToString())).ToString())
         Dim dolares As Decimal = Decimal.Parse(txtDolares.Text.ToString()) * Decimal.Parse(Me.txtCotizacionDolares.Text.ToString())

         total = Decimal.Parse(txtPesos.Text.ToString()) + Decimal.Parse(txtTotalCheques.Text.ToString()) +
                 Decimal.Parse(txtTarjetas.Text.ToString()) + Decimal.Parse(txtTickets.Text.ToString()) +
                 bancos + dolares

         If total < 0 Then
            ShowMessage("No se permiten importes negativos en Importe Total.")
            Return False
         End If

      End If

      Return True
   End Function

   Private Sub SetearTipoMovimiento()
      If optIngreso.Checked Then
         _TipoDeMovimiento = Reglas.CajaDetalles.TipoMovimiento.Ingreso
      ElseIf optEgreso.Checked Then
         _TipoDeMovimiento = Reglas.CajaDetalles.TipoMovimiento.Egreso
      End If
   End Sub

   Private Sub AgregarCheques(dtCheques As DataTable)
      '-- REQ-34410.- ----------------------------------
      If Me.dtCheques.Columns.Count = 0 Then
         Me.dtCheques = dtCheques.Clone()
      End If
      For Each cRow As DataRow In dtCheques.Rows
         If Me.dtCheques.Rows.Count = 0 Then
            Me.dtCheques.ImportRow(cRow)
            Me.dgvCheques.DataSource = Me.dtCheques
         Else
            Dim blnInsertar = True
            For Each drch As DataRow In Me.dtCheques.Rows
               If drch.RowState = DataRowState.Deleted Then
                  Continue For
               End If
               If drch("NumeroCheque").ToString() = cRow("NumeroCheque").ToString() And
                  drch("IdBanco").ToString() = cRow("IdBanco").ToString() And
                  drch("IdBancoSucursal").ToString() = cRow("IdBancoSucursal").ToString() And
                  drch("IdLocalidad").ToString() = cRow("IdLocalidad").ToString() Then
                  blnInsertar = False
                  Exit For
               End If
            Next
            If blnInsertar Then
               Me.dtCheques.ImportRow(cRow)
               Me.dgvCheques.DataSource = Me.dtCheques
            End If
         End If
      Next
      '-----------------------------------------------

      'For Each cRow As DataRow In dtCheques.Rows
      '   If dtCheques.Rows.Count = 0 Then
      '      dtCheques.ImportRow(cRow)
      '      dgvCheques.DataSource = dtCheques

      '   Else

      '      For Each drch As DataRow In Me.dtCheques.Rows
      '         If drch.RowState = DataRowState.Deleted Then
      '            Continue For
      '         End If
      '         If drch("NumeroCheque").ToString() = cRow("NumeroCheque").ToString() And
      '            drch("IdBanco").ToString() = cRow("IdBanco").ToString() And
      '            drch("IdBancoSucursal").ToString() = cRow("IdBancoSucursal").ToString() And
      '            drch("IdLocalidad").ToString() = cRow("IdLocalidad").ToString() Then
      '            blnInsertar = False
      '            Exit For
      '         End If
      '      Next

      '      If blnInsertar Then
      '         dtCheques.ImportRow(cRow)
      '         dgvCheques.DataSource = Me.dtCheques
      '      End If
      '   End If
      'Next
   End Sub

   Private Sub SetTotalCheques()
      Dim chTotal = 0D
      For Each cRow As DataGridViewRow In dgvCheques.Rows
         chTotal = chTotal + Decimal.Parse(cRow.Cells("Importe").Value.ToString())
      Next

      txtTotalCheques.Text = chTotal.ToString("F")
      EnableDisableTipoMovimiento()

   End Sub
   Private Sub SetTotalCupones()
      Dim totalCupones = ugCuponesTarjetas.DataSource(Of DataTable).AsEnumerable().SumSecure(Function(dr) dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())).IfNull()

      txtTarjetas.SetValor(totalCupones)
      EnableDisableTipoMovimiento()
   End Sub

   Private Sub EnableDisableTipoMovimiento()
      optIngreso.Enabled = (dgvCheques.Rows.Count = 0) And ugCuponesTarjetas.DataSource(Of DataTable).Count = 0
      optEgreso.Enabled = (dgvCheques.Rows.Count = 0) And ugCuponesTarjetas.DataSource(Of DataTable).Count = 0
   End Sub

   Private Sub MostrarOcultarNroMovimiento()
      If Operacion = Reglas.CajaDetalles.TipoOperacion.Nuevo Then
         lblNMovimientoActual.Visible = False
         txtNMovimiento.Visible = False

      ElseIf Operacion = Reglas.CajaDetalles.TipoOperacion.Modificacion Then
         lblNMovimientoActual.Visible = True
         txtNMovimiento.Visible = True

      ElseIf Operacion = Reglas.CajaDetalles.TipoOperacion.Consulta Then
         lblNMovimientoActual.Visible = True
         txtNMovimiento.Visible = True
         grbDetalle.Enabled = False
         grbCheques.Enabled = True
         btnAgregarCheque.Visible = False
         btnEliminarCheque.Visible = False

      End If
   End Sub

   Private Function GuardarNuevoMovimiento() As Boolean
      If ValidarForm() Then
         Dim eCajaDetalle = New Entidades.CajaDetalles(IdSucursalMovimiento, actual.Nombre, actual.Pwd)
         With eCajaDetalle
            .IdSucursal = IdSucursalMovimiento
            .IdCaja = CajaNombre.IdCaja
            .NumeroPlanilla = NumeroPlanilla
            .IdCuentaCaja = bscCuentaCaja.Text.ValorNumericoPorDefecto(0I)
            .IdTipoMovimiento = CChar(TipoDeMovimiento.ToString.Substring(0, 1))
            .Observacion = txtObservaciones.Text
            .FechaMovimiento = dtpFecha.Value
            .ImportePesos = txtPesos.ValorNumericoPorDefecto(0D)
            .ImporteCheques = txtTotalCheques.ValorNumericoPorDefecto(0D)
            .ImporteTarjetas = txtTarjetas.ValorNumericoPorDefecto(0D)
            .ImporteTickets = txtTickets.ValorNumericoPorDefecto(0D)
            .ImporteDolares = txtDolares.ValorNumericoPorDefecto(0D)
            .CotizacionDolar = txtCotizacionDolares.ValorNumericoPorDefecto(0D)
            .ImporteBancos = txtBancos.ValorNumericoPorDefecto(0D)

            .IdConceptoCM05 = cmbAFIPConceptoCM05.ValorSeleccionado(Of Integer?)(chbAFIPConceptoCM05, Nothing)

            If .ImporteBancos <> 0 Then
               .IdMonedaImporteBancos = cmbMonedaBancos.ValorSeleccionado(Of Integer?)
            Else
               .IdMonedaImporteBancos = Nothing
            End If

            'este campo es para ver si se puede modificar o no un movimiento de caja
            .EsModificable = True
            .GeneraContabilidad = chbGeneraContabilidad.Checked 'True

            If _utilizaCentroCostos Then
               .CentroCosto = cmbCentroCosto.ItemSeleccionado(Of Entidades.ContabilidadCentroCosto)
            End If

         End With

         Dim rCajaDetalle = New Reglas.CajaDetalles()
         rCajaDetalle.AgregarMovimiento(eCajaDetalle, ArmarArrayCheques(), Nothing, ugCuponesTarjetas.DataSource(Of DataTable))

         ShowMessage("El movimiento se ha ingresado correctamente.")

         Return True
      Else
         Return False
      End If
   End Function

   Private Function ArmarArrayCheques() As IEnumerable(Of Entidades.Cheque)

      Dim eCheques = New List(Of Entidades.Cheque)()
      Dim sCheque As Entidades.Cheque
      Dim rowVersion = DataRowVersion.Default

      'If Not Me.dtCheques Is Nothing Then
      For Each drCh As DataRow In dtCheques.Rows
         sCheque = New Entidades.Cheque(IdSucursalMovimiento, actual.Nombre, actual.Pwd)

         If drCh.RowState = DataRowState.Deleted Then rowVersion = DataRowVersion.Original
         If drCh.RowState = DataRowState.Added Then rowVersion = DataRowVersion.Default

         With sCheque
            .IdSucursal = IdSucursalMovimiento
            .IdCheque = drCh.Field(Of Long)("IdCheque", rowVersion)
            .NumeroCheque = Integer.Parse(drCh("NumeroCheque", rowVersion).ToString())
            .Banco.IdBanco = Integer.Parse(drCh("IdBanco", rowVersion).ToString())
            .IdBancoSucursal = Integer.Parse(drCh("IdBancoSucursal", rowVersion).ToString())
            .Localidad.IdLocalidad = Integer.Parse(drCh("IdLocalidad", rowVersion).ToString())
            .FechaEmision = Date.Parse(drCh("FechaEmision", rowVersion).ToString())
            .FechaCobro = Date.Parse(drCh("FechaCobro", rowVersion).ToString())
            .Titular = drCh("Titular", rowVersion).ToString()
            .Importe = Decimal.Parse(drCh("Importe", rowVersion).ToString())

            '-- REQ-32950.- --
            .Cuit = drCh("Cuit", rowVersion).ToString()

            If Not drCh("NroPlanillaIngreso", rowVersion) Is System.DBNull.Value Then
               .NroPlanillaIngreso = Integer.Parse(drCh("NroPlanillaIngreso", rowVersion).ToString())
               .NroMovimientoIngreso = Integer.Parse(drCh("NroMovimientoIngreso", rowVersion).ToString())
            Else
               .NroPlanillaIngreso = 0
               .NroMovimientoIngreso = 0
            End If

            If Not drCh("NroPlanillaEgreso", rowVersion) Is System.DBNull.Value Then
               .NroPlanillaEgreso = Integer.Parse(drCh("NroPlanillaEgreso", rowVersion).ToString())
               .NroMovimientoEgreso = Integer.Parse(drCh("NroMovimientoEgreso", rowVersion).ToString())
            Else
               .NroPlanillaEgreso = 0
               .NroMovimientoEgreso = 0
            End If

            .RowState = drCh.RowState

            .IdEstadoCheque = If(Me.optIngreso.Checked, Entidades.Cheque.Estados.ENCARTERA, Entidades.Cheque.Estados.EGRESOCAJA)

         End With

         eCheques.Add(sCheque)

      Next

      Return eCheques
   End Function

   Private Sub CargarMovimiento()
      Dim rMovimiento = New Reglas.CajaDetalles()

      Using dtMov = rMovimiento.GetMovimiento(IdSucursalMovimiento, CajaNombre.IdCaja, NumeroPlanilla, NroDeMovimiento)
         If dtMov.Rows.Count > 0 Then
            'Me.txtPlanillaActual.Text = Me.NumeroPlanilla.ToString()
            Dim drMov = dtMov.Rows(0)
            Dim fechaMovimiento = drMov.Field(Of Date?)("FechaMovimiento")
            If fechaMovimiento.HasValue Then
               'Si es la fecha del dia, le pone la hora actual.
               If fechaMovimiento.Value.Date = Date.Today Then
                  dtpFecha.Value = Date.Now
               Else
                  dtpFecha.Value = fechaMovimiento.Value
               End If
            End If
            txtNMovimiento.Text = NroDeMovimiento.ToString()


            bscCuentaCaja.Text = drMov.Field(Of Integer)("IdCuentaCaja").ToString()
            bscCuentaCaja.PresionarBoton()

            'Le quito el signo de Negativo
            Dim Coef As Integer

            If drMov.Field(Of String)("IdTipoMovimiento") = "I" Then
               optIngreso.Checked = True
               Coef = 1
            ElseIf drMov.Field(Of String)("IdTipoMovimiento") = "E" Then
               optEgreso.Checked = True
               Coef = -1
            End If

            chbGeneraContabilidad.Checked = drMov.Field(Of Boolean)(Entidades.CajaDetalles.Columnas.GeneraContabilidad.ToString())


            txtPesos.Text = (drMov.Field(Of Decimal)("ImportePesos") * Coef).ToString()
            txtDolares.Text = (drMov.Field(Of Decimal)("ImporteDolares") * Coef).ToString()
            txtCotizacionDolares.Text = (drMov.Field(Of Decimal)("CotizacionDolar")).ToString()
            txtTickets.Text = (drMov.Field(Of Decimal)("ImporteTickets") * Coef).ToString()
            txtTarjetas.Text = (drMov.Field(Of Decimal)("ImporteTarjetas") * Coef).ToString()
            txtBancos.Text = (drMov.Field(Of Decimal)("ImporteBancos") * Coef).ToString()

            txtObservaciones.Text = drMov.Field(Of String)("Observacion")

            If _utilizaCentroCostos Then
               cmbCentroCosto.SelectedValue = drMov.Field(Of Integer?)(Entidades.CajaDetalles.Columnas.IdCentroCosto.ToString()).IfNull()
            End If

            cmbMonedaBancos.SelectedValue = drMov.Field(Of Integer?)(Entidades.CajaDetalles.Columnas.IdMonedaImporteBancos.ToString()).IfNull(Entidades.Moneda.Peso)
            cmbMonedaBancos.Enabled = drMov.Field(Of Decimal)("ImporteBancos") <> 0

            Dim idConceptoCM05 = drMov.Field(Of Integer?)(Entidades.CajaDetalles.Columnas.IdConceptoCM05.ToString())
            chbAFIPConceptoCM05.Checked = idConceptoCM05.HasValue
            If idConceptoCM05.HasValue Then
               cmbAFIPConceptoCM05.SelectedValue = idConceptoCM05.Value
            End If

            If Not drMov.Field(Of Boolean)("EsModificable") Then
               dtpFecha.Enabled = False
               grbTipoMovimiento.Enabled = False
               txtPesos.ReadOnly = True
               txtTarjetas.ReadOnly = True
               txtTickets.ReadOnly = True
               txtBancos.ReadOnly = True
               txtDolares.ReadOnly = True
               txtCotizacionDolares.ReadOnly = True
               txtObservaciones.ReadOnly = True
               cmbAFIPConceptoCM05.Enabled = False
               chbAFIPConceptoCM05.Enabled = False
               btnAgregarCheque.Enabled = False
               btnEliminarCheque.Enabled = False
            End If
            If Reglas.Publicos.TieneModuloContabilidad = False Then
               txtBancos.ReadOnly = Not drMov.Field(Of Boolean)("EsModificable")
            Else
               If chbGeneraContabilidad.Checked = True Then
                  txtBancos.ReadOnly = True
               Else
                  If drMov.Field(Of Boolean)("EsModificable") Then
                     txtBancos.ReadOnly = False
                  Else
                     txtBancos.ReadOnly = True
                  End If

               End If
            End If

            If Not Reglas.Publicos.AFIPUtilizaCM05 Then
               chbAFIPConceptoCM05.Checked = False
               chbAFIPConceptoCM05.Enabled = False
            End If

         End If
      End Using
   End Sub

   Private Sub CargarCheques()
      Dim rCheques = New Reglas.Cheques()
      dtCheques = rCheques.GetChequesDeMovimiento(IdSucursalMovimiento, CajaNombre.IdCaja, NumeroPlanilla, NroDeMovimiento, _CheqPropio)
      dgvCheques.DataSource = dtCheques
   End Sub

   Private Sub CargarCuponesTarjetas()
      Dim rCupones = New Reglas.TarjetasCupones()
      Dim dtCupones = rCupones.GetAllDeMovimientoCaja(IdSucursalMovimiento, CajaNombre.IdCaja, NumeroPlanilla, NroDeMovimiento)
      SetCuponesTarjetasDataSource(dtCupones)
   End Sub
   Private Sub SetCuponesTarjetasDataSource(dt As DataTable)
      Dim tit = GetColumnasVisiblesGrilla(ugCuponesTarjetas)
      ugCuponesTarjetas.DataSource = dt
      AjustarColumnasGrilla(ugCuponesTarjetas, tit)
   End Sub

   Private Function ActualizarMovimiento() As Boolean
      If ValidarForm() Then
         Dim eCajaDetalle = New Entidades.CajaDetalles(IdSucursalMovimiento, actual.Nombre, actual.Pwd)
         With eCajaDetalle
            .IdSucursal = IdSucursalMovimiento
            .IdCaja = CajaNombre.IdCaja
            .NumeroPlanilla = NumeroPlanilla
            .NumeroMovimiento = NroDeMovimiento
            .IdCuentaCaja = bscCuentaCaja.Text.ValorNumericoPorDefecto(0I)
            .IdTipoMovimiento = CChar(TipoDeMovimiento.ToString.Substring(0, 1))
            .Observacion = txtObservaciones.Text
            .FechaMovimiento = dtpFecha.Value
            .ImportePesos = txtPesos.ValorNumericoPorDefecto(0D)
            .ImporteCheques = txtTotalCheques.ValorNumericoPorDefecto(0D)
            .ImporteTarjetas = txtTarjetas.ValorNumericoPorDefecto(0D)
            .ImporteTickets = txtTickets.ValorNumericoPorDefecto(0D)
            .ImporteDolares = txtDolares.ValorNumericoPorDefecto(0D)
            .CotizacionDolar = txtCotizacionDolares.ValorNumericoPorDefecto(0D)
            .ImporteBancos = txtBancos.ValorNumericoPorDefecto(0D)

            .IdConceptoCM05 = cmbAFIPConceptoCM05.ValorSeleccionado(Of Integer?)(chbAFIPConceptoCM05, Nothing)

            If .ImporteBancos <> 0 Then
               .IdMonedaImporteBancos = cmbMonedaBancos.ValorSeleccionado(Of Integer?)
            Else
               .IdMonedaImporteBancos = Nothing
            End If

            If _utilizaCentroCostos Then
               .CentroCosto = DirectCast(cmbCentroCosto.SelectedItem, Entidades.ContabilidadCentroCosto)
            End If

            If Reglas.Publicos.TieneModuloContabilidad And Reglas.Publicos.ContabilidadEjecutarEnLinea Then
               Using dtMov = New Reglas.CajaDetalles().GetMovimiento(IdSucursalMovimiento, CajaNombre.IdCaja, NumeroPlanilla, NroDeMovimiento)
                  If dtMov.Rows.Count > 0 Then
                     If Not IsDBNull(dtMov.Rows(0)("IdPlanCuenta")) Then
                        .IdPlanCuenta = CInt(dtMov.Rows(0)("IdPlanCuenta"))
                     End If
                     If Not IsDBNull(dtMov.Rows(0)("IdAsiento")) Then
                        .IdAsiento = CInt(dtMov.Rows(0)("IdAsiento"))
                     End If
                  End If
               End Using
            End If

            .EsModificable = True
            .GeneraContabilidad = True
         End With

         Dim rCajaDetalle = New Reglas.CajaDetalles()
         rCajaDetalle.ActualizarMovimiento(eCajaDetalle, ArmarArrayCheques(), AplicaCoeficiente:=True)

         ShowMessage("El movimiento se ha modificado correctamente.")
         Return True
      Else
         Return False
      End If

   End Function

   Private Function ValidarTipoDeMovimiento() As Boolean
      If Not optIngreso.Checked And Not optEgreso.Checked Then
         ShowMessage("Por favor seleccione el tipo de movimiento.")
         optIngreso.Focus()
         optIngreso.Checked = False
         Return False
      Else
         Return True
      End If
   End Function

   Public Function GetTipoDeMovimiento() As Reglas.CajaDetalles.TipoMovimiento
      Dim rValue = Reglas.CajaDetalles.TipoMovimiento.Ingreso
      If optIngreso.Checked Then
         rValue = Reglas.CajaDetalles.TipoMovimiento.Ingreso
      ElseIf optEgreso.Checked Then
         rValue = Reglas.CajaDetalles.TipoMovimiento.Egreso
      End If
      Return rValue
   End Function

   Private Sub SetColumnIndexes()
      IdSucursal.DisplayIndex = 0
      Importe.DisplayIndex = 1
      NumeroCheque.DisplayIndex = 2
      IdBanco.DisplayIndex = 3
      NombreBanco.DisplayIndex = 4
      NombreLocalidad.DisplayIndex = 5
      FechaCobro.DisplayIndex = 6
      FechaEmision.DisplayIndex = 7
      Titular.DisplayIndex = 8
      NroPlanillaIngreso.DisplayIndex = 9
      NroMovimientoIngreso.DisplayIndex = 10
      NroPlanillaEgreso.DisplayIndex = 11
      NroMovimientoEgreso.DisplayIndex = 12

   End Sub

#End Region

End Class