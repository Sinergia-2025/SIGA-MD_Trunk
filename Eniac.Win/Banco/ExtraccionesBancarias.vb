Public Class ExtraccionesBancarias

#Region "Campos"

   Private _ComprobantesGrilla As New System.Collections.Generic.List(Of Entidades.CuentaCorrienteProvPago)
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

         _chequesPropios = New List(Of Entidades.Cheque)
         _chequesTerceros = New List(Of Entidades.Cheque)

         Dim oBancos = New Reglas.Bancos()
         cmbBancoPropio.DisplayMember = "Nombrebanco"
         cmbBancoPropio.ValueMember = "IdBanco"
         cmbBancoPropio.DataSource = oBancos.GetAll()
         cmbBancoPropio.SelectedIndex = -1

         '# Tipos de Cheque
         _publicos.CargaComboTiposCheques(cmbTipoCheque)

         _Suc = actual.Sucursal.Id

         _publicos.CargaComboCajas(cmbCajas, _Suc, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         Nuevo()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub txtImporteChequePropio_Leave(sender As Object, e As EventArgs) Handles txtImporteChequePropio.Leave
      Try
         If Me.txtImporteChequePropio.Text.Trim().Length = 0 Then
            Me.txtImporteChequePropio.Text = "0.00"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'Private Sub txtSucursalBancoPropio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSucursalBancoPropio.KeyDown
   '   Me.PresionarTab(e)
   'End Sub

   Private Sub txtTotalEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalEfectivo.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTotalEfectivo_Leave(sender As Object, e As EventArgs) Handles txtTotalEfectivo.Leave
      Try
         Me.CalcularTotalExtraccion()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTotalTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalTarjeta.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTotalTarjeta_Leave(sender As Object, e As EventArgs) Handles txtTotalTarjeta.Leave
      Try
         Me.CalcularTotalExtraccion()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTotalTickets_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalTickets.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTotalTickets_Leave(sender As Object, e As EventArgs) Handles txtTotalTickets.Leave
      Try
         Me.CalcularTotalExtraccion()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTipoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNroOperacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroOperacion.KeyDown
      Me.PresionarTab(e)
   End Sub


   Private Sub btnInsertarChequePropio_Click(sender As Object, e As EventArgs) Handles btnInsertarChequePropio.Click
      Try
         If (Not Me.bscCuentaBancariaPropio.FilaDevuelta Is Nothing Or
            Not Me.bscCuentaBancariaPropiaCodigo.FilaDevuelta Is Nothing) And
            Me.txtImporteChequePropio.Text <> "" Then
            If Me.ValidarInsertarChequePropio() Then
               Me.InsertarChequePropioGrilla()
               Me.bscCuentaBancariaPropio.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarChequePropio_Click(sender As Object, e As EventArgs) Handles btnEliminarChequePropio.Click
      Try
         If Me.dgvChequesPropios.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaChequePropio()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         Select Case Me.tbcDetalle.SelectedTab.Name
            Case "tbpExtraccions1"
               Me.bscCuentaBancariaDestino.Focus()

            Case "tbpExtraccions2"
               Me.bscCuentaBancariaPropio.Focus()

         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.GrabarComprobante()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ExtraccionesBancarias_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F4 And Me.tsbGrabar.Enabled Then
         Me.tsbGrabar_Click(Me.tsbGrabar, New EventArgs())
      End If
   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorClick() Handles bscCuentaBancariaDestino.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias2(Me.bscCuentaBancariaDestino)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaDestino.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaDestino.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaDestino.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosCuentaBancariaDestino(e.FilaDevuelta)
            VerificarGrabarImprimir()
            optFechaAplicacion.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaPropio_BuscadorClick() Handles bscCuentaBancariaPropio.BuscadorClick

      Try
         If TypeOf (bscCuentaBancariaPropio.Datos) Is DataTable Then DirectCast(bscCuentaBancariaPropio.Datos, DataTable).Clear()
         If Me.bscCuentaBancariaDestino.FilaDevuelta IsNot Nothing Then
            Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaPropio)
            Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
            Me.bscCuentaBancariaPropio.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaDestino.Text.Trim())
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaPropio_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaPropio.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing And Me.bscCuentaBancariaDestino.FilaDevuelta IsNot Nothing Then

            If e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString() <> Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString() Then
               MessageBox.Show("Debe seleccionar la misma Cuenta Bancaria de Origen y de Destino. Reintente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
               bscCuentaBancariaPropio.FilaDevuelta = Nothing
               Exit Sub
            End If

            Me.CargarDatosCuentaBancaria(e.FilaDevuelta)
            Me.txtNroChequePropio.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaPropiaCodigo_BuscadorClick() Handles bscCuentaBancariaPropiaCodigo.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaPropiaCodigo)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Dim codigo As Integer = If(Not String.IsNullOrEmpty(Me.bscCuentaBancariaPropiaCodigo.Text), Integer.Parse(Me.bscCuentaBancariaPropiaCodigo.Text), 0)
         Me.bscCuentaBancariaPropiaCodigo.Datos = oCBancarias.GetFiltradoPorCodigo(codigo)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCuentaBancariaPropiaCodigo_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaPropiaCodigo.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscCuentaBancariaPropiaCodigo.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
            Me.bscCuentaBancariaPropio.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancariaPropio.FilaDevuelta = e.FilaDevuelta
            Me.CargarDatosCuentaBancaria(e.FilaDevuelta)
            Me.txtNroChequePropio.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
      Try

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   'Private Sub PresionarTab(e As KeyEventArgs)
   '   If e.KeyCode = Keys.Enter Then
   '      Me.ProcessTabKey(True)
   '   End If
   'End Sub

   Private Function ValidarExtraccion() As Boolean

      For i As Integer = 0 To Me._chequesPropios.Count - 1
         If Me._chequesPropios(i).CuentaBancaria.IdCuentaBancaria <> Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()) Then
            MessageBox.Show("Existe al menos un cheque cuya Cuenta Bancaria con coincide no la cuenta de la operación. NO es posible Grabar el Depósito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
         End If
      Next

      Return True

   End Function

   Private Sub GrabarComprobante()

      If ValidarExtraccion() Then

         tsbGrabar.Enabled = False

         Dim oReglasDepositos = New Reglas.Depositos()

         Dim oExtraccion = New Entidades.Deposito()

         With oExtraccion

            .CuentaBancaria = New Reglas.CuentasBancarias().GetUna(Integer.Parse(bscCuentaBancariaDestino.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))

            .Fecha = dtpFecha.Value
            .FechaAplicado = dtpFechaAplicacion.Value

            .UsoFechaCheque = optFechaCheque.Checked

            'cargo valores del comprobante
            .ImporteTotal = Decimal.Parse(txtTotal.Text)

            .Observacion = txtObservacion.Text

            '-- REQ-32299.- ----------------------------------------
            If Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("IdMoneda").Value.ToString()) = Entidades.Moneda.Peso Then
               'cargo el efectivo para tenerlo discriminado
               .ImportePesos = txtTotalEfectivo.ValorNumericoPorDefecto(0D)
            Else
               'cargo el efectivo para tenerlo discriminado
               .ImporteDolares = txtTotalEfectivo.ValorNumericoPorDefecto(0D)
            End If
            '--------------------------------------------------------
            '*** CODIGO ANTERIROR A ALA MODIFICACION.- *** 32299.- --
            ''cargo el efectivo para tenerlo discriminado
            '.ImportePesos = Decimal.Parse(Me.txtTotalEfectivo.Text)
            ''TODO 
            '.ImporteDolares = 0
            '---------------------------------------------------------

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
            .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
            .NombreCaja = cmbCajas.Text
            .Usuario = actual.Nombre

            .IdEstado = "NORMAL"
            .TipoComprobante = New Reglas.TiposComprobantes().GetUno("EXTRACCION")

         End With

         oReglasDepositos.Insertar(oExtraccion)

         MessageBox.Show("Se ingreso la Extracción número " & oExtraccion.NumeroDeposito, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Dim di = New ExtraccionesImprimir()

         di.ImprimirExtraccion(oExtraccion)

         Nuevo()

      End If

   End Sub

   Private Sub LimpiarCamposChequesPropios()
      Me.bscCuentaBancariaPropio.Text = ""
      Me.bscCuentaBancariaPropio.FilaDevuelta = Nothing
      Me.bscCuentaBancariaPropiaCodigo.FilaDevuelta = Nothing
      Me.cmbBancoPropio.SelectedIndex = -1
      Me.txtNroChequePropio.Text = "0"
      Me.txtCodPostalChequePropio.Text = "0"
      Me.txtSucursalBancoPropio.Text = "0"
      Me.dtpFechaCobroPropio.Value = DateTime.Now
      Me.dtpFechaEmisionPropio.Value = DateTime.Now
      Me.txtImporteChequePropio.Text = "0.00"
      Me.cmbTipoCheque.SelectedValue = "F"
      Me.txtNroOperacion.Clear()
   End Sub

   Private Sub VerificarGrabarImprimir()
      Me.tsbGrabar.Enabled = (Me.bscCuentaBancariaDestino.Selecciono And Decimal.Parse(Me.txtTotal.Text) > 0)
   End Sub

   Private Sub CalcularTotalExtraccion()

      Dim pago As Decimal = 0

      pago += Decimal.Parse(Me.txtTotalEfectivo.Text)

      pago += Decimal.Parse(Me.txtTotalTarjeta.Text)

      pago += Decimal.Parse(Me.txtTotalTickets.Text)

      pago += +Decimal.Parse(Me.txtTotalCheqTerceros.Text)

      pago += +Decimal.Parse(Me.txtTotalCheqPropios.Text)

      Me.txtTotal.Text = pago.ToString("#,##0.00")

      Me.VerificarGrabarImprimir()

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

      txtIdCheque.Clear()
      bscCuentaBancariaDestino.Text = ""
      bscCuentaBancariaDestino.FilaDevuelta = Nothing
      _estado = Estados.Insercion
      txtTotalCheqPropios.Enabled = True
      tbcDetalle.SelectedTab = tbpDepositos2
      tbcDetalle.Enabled = True
      txtTotalCheqTerceros.Enabled = True
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
      _chequesPropios.Clear()
      dgvChequesPropios.DataSource = _chequesPropios.ToArray()

      LimpiarCamposChequesPropios()

      tbcDetalle.SelectedTab = tbpDepositos2

      _proveedorGrilla = Nothing

      CambiarEstadoControlesDetalle(False)

      'Me.cmbCajas.SelectedIndex = 0
      _publicos.CargaComboCajas(cmbCajas, _Suc, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")

      bscCuentaBancariaDestino.Focus()

   End Sub

   Private Sub InsertarChequePropioGrilla()

      Dim oLineaDetalle As Entidades.Cheque = New Entidades.Cheque()

      With oLineaDetalle

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
         '-- REQ-31054 - 31046 --
         .Cuit = Reglas.Publicos.CuitEmpresa
         '-----------------------
         .Usuario = actual.Nombre
         .IdTipoCheque = Me.cmbTipoCheque.SelectedValue.ToString()
         .NombreTipoCheque = Me.cmbTipoCheque.Text
         .NroOperacion = Me.txtNroOperacion.Text
      End With

      Me._chequesPropios.Add(oLineaDetalle)

      Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()
      Me.dgvChequesPropios.FirstDisplayedScrollingRowIndex = Me.dgvChequesPropios.Rows.Count - 1

      Me.dgvChequesPropios.Refresh()
      Me.LimpiarCamposChequesPropios()
      Me.CalcularTotalChequesPropios()
      Me.CalcularTotalExtraccion()

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

   Private Sub CargarDatosCuentaBancaria(dr As DataGridViewRow)
      Me.bscCuentaBancariaPropio.Text = dr.Cells("NombreCuenta").Value.ToString()
      Me.cmbBancoPropio.SelectedValue = dr.Cells("IdBanco").Value
      Me.txtSucursalBancoPropio.Text = dr.Cells("IdBancoSucursal").Value.ToString.Trim()
      Me.txtCodPostalChequePropio.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.txtNroChequePropio.Text = Me.ProximoChequeEmitido(Integer.Parse(dr.Cells("IdCuentaBancaria").Value.ToString())).ToString()
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

   Private Sub EliminarLineaChequePropio()
      Me._chequesPropios.RemoveAt(Me.dgvChequesPropios.SelectedRows(0).Index)

      Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()

      Me.CalcularTotalChequesPropios()
      Me.CalcularTotalExtraccion()
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

   Private Sub HabilitaSegunMoneda(idMoneda As Integer)

      'txtTotalEfectivo.Enabled = idMoneda = Entidades.Moneda.Peso

      tbcDetalle.Enabled = idMoneda = Entidades.Moneda.Peso
      txtTotalTarjeta.Enabled = idMoneda = Entidades.Moneda.Peso
      txtTotalTickets.Enabled = idMoneda = Entidades.Moneda.Peso
   End Sub

#End Region

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

   Private Sub dgvChequesPropios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvChequesPropios.CellDoubleClick
      Try
         If Me.dgvChequesPropios.Rows.Count = 0 Then Exit Sub

         Me.CargarChequeCompleto(Me.dgvChequesPropios.Rows(e.RowIndex))

         '# Elimino la linea de cheques
         Me._chequesPropios.RemoveAt(Me.dgvChequesPropios.SelectedRows(0).Index)
         Me.dgvChequesPropios.DataSource = Me._chequesPropios.ToArray()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarChequeCompleto(dr As DataGridViewRow)

      If dr IsNot Nothing AndAlso
         dr.DataBoundItem IsNot Nothing AndAlso
         TypeOf (dr.DataBoundItem) Is Entidades.Cheque Then

         Dim oCheque As Entidades.Cheque = DirectCast(dr.DataBoundItem, Entidades.Cheque)

         With oCheque

            Me.bscCuentaBancariaPropiaCodigo.Text = .IdCuentaBancaria.ToString()
            Me.bscCuentaBancariaPropiaCodigo.PresionarBoton()
            Me.txtSucursalBancoPropio.Text = .IdBancoSucursal.ToString()
            Me.txtCodPostalChequePropio.Text = .Localidad.IdLocalidad.ToString()
            Me.dtpFechaEmisionPropio.Value = .FechaEmision
            Me.dtpFechaCobroPropio.Value = .FechaCobro
            Me.txtNroChequePropio.Text = .NumeroCheque.ToString()
            Me.txtImporteChequePropio.Text = .Importe.ToString()
            Me.cmbTipoCheque.SelectedValue = .IdTipoCheque.ToString()
            Me.txtNroOperacion.Text = .NroOperacion.ToString()
         End With

      End If

   End Sub
End Class