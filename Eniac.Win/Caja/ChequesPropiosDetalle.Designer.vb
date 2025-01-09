<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequesPropiosDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChequesPropiosDetalle))
      Me.grbDetalle = New System.Windows.Forms.GroupBox()
      Me.txtNroOperacion = New Eniac.Controles.TextBox()
      Me.lblNroOperacion = New System.Windows.Forms.Label()
      Me.lblTipoCheque = New Eniac.Controles.Label()
      Me.cmbTipoCheque = New Eniac.Controles.ComboBox()
      Me.grbCuenta = New System.Windows.Forms.GroupBox()
      Me.cmbBanco = New Eniac.Controles.ComboBox()
      Me.lblBanco = New Eniac.Controles.Label()
      Me.txtBancoSucursal = New Eniac.Controles.TextBox()
      Me.lblSucursalBanco = New Eniac.Controles.Label()
      Me.cmbLocalidad = New Eniac.Controles.ComboBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.cmbCuentas = New Eniac.Controles.ComboBox()
      Me.lblCuentas = New Eniac.Controles.Label()
      Me.txtImporte = New Eniac.Controles.TextBox()
      Me.lblImporte = New Eniac.Controles.Label()
      Me.txtNumeroCheque = New Eniac.Controles.TextBox()
      Me.lblNumeroCheque = New Eniac.Controles.Label()
      Me.dtpFechaCobro = New Eniac.Controles.DateTimePicker()
      Me.lblFechaCobro = New Eniac.Controles.Label()
      Me.dtpFechaEmision = New Eniac.Controles.DateTimePicker()
      Me.lblFechaEmision = New Eniac.Controles.Label()
      Me.grbMovimientosDeCaja = New System.Windows.Forms.GroupBox()
      Me.lblEgreso = New Eniac.Controles.Label()
      Me.IdCajaEgreso = New Eniac.Controles.TextBox()
      Me.lblPlanillaEgreso = New Eniac.Controles.Label()
      Me.txtNombreCajaEgreso = New Eniac.Controles.TextBox()
      Me.lblCajaEgreso = New Eniac.Controles.Label()
      Me.txtNroMovimientoEgreso = New Eniac.Controles.TextBox()
      Me.lblMovimientoEgreso = New Eniac.Controles.Label()
      Me.txtNroPlanillaEgreso = New Eniac.Controles.TextBox()
      Me.lblProveedor = New Eniac.Controles.Label()
      Me.txtCodigoProveedor = New Eniac.Controles.TextBox()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.lblNombreProv = New Eniac.Controles.Label()
      Me.TextBox2 = New Eniac.Controles.TextBox()
      Me.grbDetalle.SuspendLayout()
      Me.grbCuenta.SuspendLayout()
      Me.grbMovimientosDeCaja.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(405, 373)
      Me.btnAceptar.TabIndex = 0
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(491, 373)
      Me.btnCancelar.TabIndex = 1
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 218)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(53, 218)
      '
      'grbDetalle
      '
      Me.grbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetalle.Controls.Add(Me.txtNroOperacion)
      Me.grbDetalle.Controls.Add(Me.lblNroOperacion)
      Me.grbDetalle.Controls.Add(Me.lblTipoCheque)
      Me.grbDetalle.Controls.Add(Me.cmbTipoCheque)
      Me.grbDetalle.Controls.Add(Me.grbCuenta)
      Me.grbDetalle.Controls.Add(Me.cmbCuentas)
      Me.grbDetalle.Controls.Add(Me.lblCuentas)
      Me.grbDetalle.Controls.Add(Me.txtImporte)
      Me.grbDetalle.Controls.Add(Me.lblImporte)
      Me.grbDetalle.Controls.Add(Me.txtNumeroCheque)
      Me.grbDetalle.Controls.Add(Me.lblNumeroCheque)
      Me.grbDetalle.Controls.Add(Me.dtpFechaCobro)
      Me.grbDetalle.Controls.Add(Me.lblFechaCobro)
      Me.grbDetalle.Controls.Add(Me.dtpFechaEmision)
      Me.grbDetalle.Controls.Add(Me.lblFechaEmision)
      Me.grbDetalle.Location = New System.Drawing.Point(12, 12)
      Me.grbDetalle.Name = "grbDetalle"
      Me.grbDetalle.Size = New System.Drawing.Size(559, 253)
      Me.grbDetalle.TabIndex = 0
      Me.grbDetalle.TabStop = False
      Me.grbDetalle.Text = "Detalle"
      '
      'txtNroOperacion
      '
      Me.txtNroOperacion.BindearPropiedadControl = "Text"
      Me.txtNroOperacion.BindearPropiedadEntidad = "NroOperacion"
      Me.txtNroOperacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroOperacion.Formato = ""
      Me.txtNroOperacion.IsDecimal = False
      Me.txtNroOperacion.IsNumber = False
      Me.txtNroOperacion.IsPK = False
      Me.txtNroOperacion.IsRequired = False
      Me.txtNroOperacion.Key = ""
      Me.txtNroOperacion.LabelAsoc = Nothing
      Me.txtNroOperacion.Location = New System.Drawing.Point(261, 172)
      Me.txtNroOperacion.MaxLength = 15
      Me.txtNroOperacion.Name = "txtNroOperacion"
      Me.txtNroOperacion.Size = New System.Drawing.Size(162, 20)
      Me.txtNroOperacion.TabIndex = 8
      '
      'lblNroOperacion
      '
      Me.lblNroOperacion.AutoSize = True
      Me.lblNroOperacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNroOperacion.Location = New System.Drawing.Point(176, 175)
      Me.lblNroOperacion.Name = "lblNroOperacion"
      Me.lblNroOperacion.Size = New System.Drawing.Size(79, 13)
      Me.lblNroOperacion.TabIndex = 7
      Me.lblNroOperacion.Text = "Nro. Operación"
      '
      'lblTipoCheque
      '
      Me.lblTipoCheque.AutoSize = True
      Me.lblTipoCheque.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblTipoCheque.LabelAsoc = Nothing
      Me.lblTipoCheque.Location = New System.Drawing.Point(24, 23)
      Me.lblTipoCheque.Name = "lblTipoCheque"
      Me.lblTipoCheque.Size = New System.Drawing.Size(83, 13)
      Me.lblTipoCheque.TabIndex = 0
      Me.lblTipoCheque.Text = "Tipo de Cheque"
      '
      'cmbTipoCheque
      '
      Me.cmbTipoCheque.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoCheque.BindearPropiedadEntidad = "IdTipoCheque"
      Me.cmbTipoCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoCheque.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoCheque.FormattingEnabled = True
      Me.cmbTipoCheque.IsPK = False
      Me.cmbTipoCheque.IsRequired = False
      Me.cmbTipoCheque.Key = Nothing
      Me.cmbTipoCheque.LabelAsoc = Nothing
      Me.cmbTipoCheque.Location = New System.Drawing.Point(113, 20)
      Me.cmbTipoCheque.Name = "cmbTipoCheque"
      Me.cmbTipoCheque.Size = New System.Drawing.Size(121, 21)
      Me.cmbTipoCheque.TabIndex = 1
      '
      'grbCuenta
      '
      Me.grbCuenta.Controls.Add(Me.cmbBanco)
      Me.grbCuenta.Controls.Add(Me.lblBanco)
      Me.grbCuenta.Controls.Add(Me.txtBancoSucursal)
      Me.grbCuenta.Controls.Add(Me.lblSucursalBanco)
      Me.grbCuenta.Controls.Add(Me.cmbLocalidad)
      Me.grbCuenta.Controls.Add(Me.lblLocalidad)
      Me.grbCuenta.Enabled = False
      Me.grbCuenta.Location = New System.Drawing.Point(23, 80)
      Me.grbCuenta.Name = "grbCuenta"
      Me.grbCuenta.Size = New System.Drawing.Size(443, 84)
      Me.grbCuenta.TabIndex = 4
      Me.grbCuenta.TabStop = False
      Me.grbCuenta.Text = "Datos de la Cuenta"
      '
      'cmbBanco
      '
      Me.cmbBanco.BindearPropiedadControl = "SelectedValue"
      Me.cmbBanco.BindearPropiedadEntidad = "Banco.idBanco"
      Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbBanco.FormattingEnabled = True
      Me.cmbBanco.IsPK = True
      Me.cmbBanco.IsRequired = True
      Me.cmbBanco.Key = Nothing
      Me.cmbBanco.LabelAsoc = Me.lblBanco
      Me.cmbBanco.Location = New System.Drawing.Point(71, 22)
      Me.cmbBanco.Name = "cmbBanco"
      Me.cmbBanco.Size = New System.Drawing.Size(192, 21)
      Me.cmbBanco.TabIndex = 1
      Me.cmbBanco.TabStop = False
      '
      'lblBanco
      '
      Me.lblBanco.AutoSize = True
      Me.lblBanco.LabelAsoc = Nothing
      Me.lblBanco.Location = New System.Drawing.Point(12, 26)
      Me.lblBanco.Name = "lblBanco"
      Me.lblBanco.Size = New System.Drawing.Size(38, 13)
      Me.lblBanco.TabIndex = 0
      Me.lblBanco.Text = "Banco"
      '
      'txtBancoSucursal
      '
      Me.txtBancoSucursal.BindearPropiedadControl = "Text"
      Me.txtBancoSucursal.BindearPropiedadEntidad = "IdBancoSucursal"
      Me.txtBancoSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBancoSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBancoSucursal.Formato = ""
      Me.txtBancoSucursal.IsDecimal = False
      Me.txtBancoSucursal.IsNumber = True
      Me.txtBancoSucursal.IsPK = False
      Me.txtBancoSucursal.IsRequired = True
      Me.txtBancoSucursal.Key = ""
      Me.txtBancoSucursal.LabelAsoc = Me.lblSucursalBanco
      Me.txtBancoSucursal.Location = New System.Drawing.Point(358, 26)
      Me.txtBancoSucursal.MaxLength = 4
      Me.txtBancoSucursal.Name = "txtBancoSucursal"
      Me.txtBancoSucursal.Size = New System.Drawing.Size(45, 20)
      Me.txtBancoSucursal.TabIndex = 3
      Me.txtBancoSucursal.TabStop = False
      Me.txtBancoSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSucursalBanco
      '
      Me.lblSucursalBanco.AutoSize = True
      Me.lblSucursalBanco.LabelAsoc = Nothing
      Me.lblSucursalBanco.Location = New System.Drawing.Point(293, 29)
      Me.lblSucursalBanco.Name = "lblSucursalBanco"
      Me.lblSucursalBanco.Size = New System.Drawing.Size(63, 13)
      Me.lblSucursalBanco.TabIndex = 2
      Me.lblSucursalBanco.Text = "Banco Suc."
      '
      'cmbLocalidad
      '
      Me.cmbLocalidad.BindearPropiedadControl = "SelectedValue"
      Me.cmbLocalidad.BindearPropiedadEntidad = "Localidad.IdLocalidad"
      Me.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLocalidad.FormattingEnabled = True
      Me.cmbLocalidad.IsPK = False
      Me.cmbLocalidad.IsRequired = True
      Me.cmbLocalidad.Key = Nothing
      Me.cmbLocalidad.LabelAsoc = Me.lblLocalidad
      Me.cmbLocalidad.Location = New System.Drawing.Point(71, 53)
      Me.cmbLocalidad.Name = "cmbLocalidad"
      Me.cmbLocalidad.Size = New System.Drawing.Size(192, 21)
      Me.cmbLocalidad.TabIndex = 5
      Me.cmbLocalidad.TabStop = False
      '
      'lblLocalidad
      '
      Me.lblLocalidad.AutoSize = True
      Me.lblLocalidad.LabelAsoc = Nothing
      Me.lblLocalidad.Location = New System.Drawing.Point(12, 57)
      Me.lblLocalidad.Name = "lblLocalidad"
      Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
      Me.lblLocalidad.TabIndex = 4
      Me.lblLocalidad.Text = "Localidad"
      '
      'cmbCuentas
      '
      Me.cmbCuentas.BindearPropiedadControl = "SelectedValue"
      Me.cmbCuentas.BindearPropiedadEntidad = "CuentaBancaria.IdCuentaBancaria"
      Me.cmbCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCuentas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCuentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCuentas.FormattingEnabled = True
      Me.cmbCuentas.IsPK = True
      Me.cmbCuentas.IsRequired = False
      Me.cmbCuentas.Key = Nothing
      Me.cmbCuentas.LabelAsoc = Nothing
      Me.cmbCuentas.Location = New System.Drawing.Point(113, 47)
      Me.cmbCuentas.Name = "cmbCuentas"
      Me.cmbCuentas.Size = New System.Drawing.Size(257, 21)
      Me.cmbCuentas.TabIndex = 3
      '
      'lblCuentas
      '
      Me.lblCuentas.AutoSize = True
      Me.lblCuentas.LabelAsoc = Nothing
      Me.lblCuentas.Location = New System.Drawing.Point(20, 50)
      Me.lblCuentas.Name = "lblCuentas"
      Me.lblCuentas.Size = New System.Drawing.Size(86, 13)
      Me.lblCuentas.TabIndex = 2
      Me.lblCuentas.Text = "Cuenta Bancaria"
      '
      'txtImporte
      '
      Me.txtImporte.BindearPropiedadControl = "Text"
      Me.txtImporte.BindearPropiedadEntidad = "Importe"
      Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtImporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporte.Formato = "#,##0.00"
      Me.txtImporte.IsDecimal = True
      Me.txtImporte.IsNumber = True
      Me.txtImporte.IsPK = False
      Me.txtImporte.IsRequired = True
      Me.txtImporte.Key = ""
      Me.txtImporte.LabelAsoc = Me.lblImporte
      Me.txtImporte.Location = New System.Drawing.Point(77, 224)
      Me.txtImporte.MaxLength = 100
      Me.txtImporte.Name = "txtImporte"
      Me.txtImporte.Size = New System.Drawing.Size(85, 23)
      Me.txtImporte.TabIndex = 14
      Me.txtImporte.Text = "0.00"
      Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblImporte
      '
      Me.lblImporte.AutoSize = True
      Me.lblImporte.LabelAsoc = Nothing
      Me.lblImporte.Location = New System.Drawing.Point(29, 228)
      Me.lblImporte.Name = "lblImporte"
      Me.lblImporte.Size = New System.Drawing.Size(42, 13)
      Me.lblImporte.TabIndex = 13
      Me.lblImporte.Text = "Importe"
      '
      'txtNumeroCheque
      '
      Me.txtNumeroCheque.BindearPropiedadControl = "Text"
      Me.txtNumeroCheque.BindearPropiedadEntidad = "NumeroCheque"
      Me.txtNumeroCheque.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroCheque.Formato = ""
      Me.txtNumeroCheque.IsDecimal = False
      Me.txtNumeroCheque.IsNumber = True
      Me.txtNumeroCheque.IsPK = True
      Me.txtNumeroCheque.IsRequired = True
      Me.txtNumeroCheque.Key = ""
      Me.txtNumeroCheque.LabelAsoc = Me.lblNumeroCheque
      Me.txtNumeroCheque.Location = New System.Drawing.Point(77, 172)
      Me.txtNumeroCheque.MaxLength = 8
      Me.txtNumeroCheque.Name = "txtNumeroCheque"
      Me.txtNumeroCheque.Size = New System.Drawing.Size(85, 20)
      Me.txtNumeroCheque.TabIndex = 6
      Me.txtNumeroCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroCheque
      '
      Me.lblNumeroCheque.AutoSize = True
      Me.lblNumeroCheque.LabelAsoc = Nothing
      Me.lblNumeroCheque.Location = New System.Drawing.Point(29, 175)
      Me.lblNumeroCheque.Name = "lblNumeroCheque"
      Me.lblNumeroCheque.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroCheque.TabIndex = 5
      Me.lblNumeroCheque.Text = "Número"
      '
      'dtpFechaCobro
      '
      Me.dtpFechaCobro.BindearPropiedadControl = "Value"
      Me.dtpFechaCobro.BindearPropiedadEntidad = "FechaCobro"
      Me.dtpFechaCobro.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaCobro.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaCobro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaCobro.IsPK = False
      Me.dtpFechaCobro.IsRequired = True
      Me.dtpFechaCobro.Key = ""
      Me.dtpFechaCobro.LabelAsoc = Me.lblFechaCobro
      Me.dtpFechaCobro.Location = New System.Drawing.Point(261, 198)
      Me.dtpFechaCobro.Name = "dtpFechaCobro"
      Me.dtpFechaCobro.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaCobro.TabIndex = 12
      '
      'lblFechaCobro
      '
      Me.lblFechaCobro.AutoSize = True
      Me.lblFechaCobro.LabelAsoc = Nothing
      Me.lblFechaCobro.Location = New System.Drawing.Point(213, 202)
      Me.lblFechaCobro.Name = "lblFechaCobro"
      Me.lblFechaCobro.Size = New System.Drawing.Size(35, 13)
      Me.lblFechaCobro.TabIndex = 11
      Me.lblFechaCobro.Text = "Cobro"
      '
      'dtpFechaEmision
      '
      Me.dtpFechaEmision.BindearPropiedadControl = "Value"
      Me.dtpFechaEmision.BindearPropiedadEntidad = "FechaEmision"
      Me.dtpFechaEmision.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaEmision.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEmision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEmision.IsPK = False
      Me.dtpFechaEmision.IsRequired = True
      Me.dtpFechaEmision.Key = ""
      Me.dtpFechaEmision.LabelAsoc = Nothing
      Me.dtpFechaEmision.Location = New System.Drawing.Point(77, 198)
      Me.dtpFechaEmision.Name = "dtpFechaEmision"
      Me.dtpFechaEmision.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaEmision.TabIndex = 10
      Me.dtpFechaEmision.Value = New Date(2008, 10, 28, 0, 29, 13, 0)
      '
      'lblFechaEmision
      '
      Me.lblFechaEmision.AutoSize = True
      Me.lblFechaEmision.LabelAsoc = Nothing
      Me.lblFechaEmision.Location = New System.Drawing.Point(29, 201)
      Me.lblFechaEmision.Name = "lblFechaEmision"
      Me.lblFechaEmision.Size = New System.Drawing.Size(43, 13)
      Me.lblFechaEmision.TabIndex = 9
      Me.lblFechaEmision.Text = "Emisión"
      '
      'grbMovimientosDeCaja
      '
      Me.grbMovimientosDeCaja.Controls.Add(Me.lblEgreso)
      Me.grbMovimientosDeCaja.Controls.Add(Me.IdCajaEgreso)
      Me.grbMovimientosDeCaja.Controls.Add(Me.txtNombreCajaEgreso)
      Me.grbMovimientosDeCaja.Controls.Add(Me.lblCajaEgreso)
      Me.grbMovimientosDeCaja.Controls.Add(Me.txtNroMovimientoEgreso)
      Me.grbMovimientosDeCaja.Controls.Add(Me.lblMovimientoEgreso)
      Me.grbMovimientosDeCaja.Controls.Add(Me.txtNroPlanillaEgreso)
      Me.grbMovimientosDeCaja.Controls.Add(Me.lblPlanillaEgreso)
      Me.grbMovimientosDeCaja.Controls.Add(Me.lblProveedor)
      Me.grbMovimientosDeCaja.Controls.Add(Me.txtCodigoProveedor)
      Me.grbMovimientosDeCaja.Controls.Add(Me.lblCodigoProveedor)
      Me.grbMovimientosDeCaja.Controls.Add(Me.lblNombreProv)
      Me.grbMovimientosDeCaja.Controls.Add(Me.TextBox2)
      Me.grbMovimientosDeCaja.Location = New System.Drawing.Point(12, 271)
      Me.grbMovimientosDeCaja.Name = "grbMovimientosDeCaja"
      Me.grbMovimientosDeCaja.Size = New System.Drawing.Size(559, 96)
      Me.grbMovimientosDeCaja.TabIndex = 2
      Me.grbMovimientosDeCaja.TabStop = False
      Me.grbMovimientosDeCaja.Text = "Movimientos de Caja"
      '
      'lblEgreso
      '
      Me.lblEgreso.AutoSize = True
      Me.lblEgreso.LabelAsoc = Nothing
      Me.lblEgreso.Location = New System.Drawing.Point(13, 27)
      Me.lblEgreso.Name = "lblEgreso"
      Me.lblEgreso.Size = New System.Drawing.Size(52, 13)
      Me.lblEgreso.TabIndex = 38
      Me.lblEgreso.Text = "EGRESO"
      '
      'IdCajaEgreso
      '
      Me.IdCajaEgreso.BindearPropiedadControl = "Text"
      Me.IdCajaEgreso.BindearPropiedadEntidad = "NroPlanillaEgreso"
      Me.IdCajaEgreso.ForeColorFocus = System.Drawing.Color.Red
      Me.IdCajaEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.IdCajaEgreso.Formato = ""
      Me.IdCajaEgreso.IsDecimal = False
      Me.IdCajaEgreso.IsNumber = True
      Me.IdCajaEgreso.IsPK = False
      Me.IdCajaEgreso.IsRequired = False
      Me.IdCajaEgreso.Key = Nothing
      Me.IdCajaEgreso.LabelAsoc = Me.lblPlanillaEgreso
      Me.IdCajaEgreso.Location = New System.Drawing.Point(83, 23)
      Me.IdCajaEgreso.MaxLength = 100
      Me.IdCajaEgreso.Name = "IdCajaEgreso"
      Me.IdCajaEgreso.ReadOnly = True
      Me.IdCajaEgreso.Size = New System.Drawing.Size(27, 20)
      Me.IdCajaEgreso.TabIndex = 37
      Me.IdCajaEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.IdCajaEgreso.Visible = False
      '
      'lblPlanillaEgreso
      '
      Me.lblPlanillaEgreso.AutoSize = True
      Me.lblPlanillaEgreso.LabelAsoc = Nothing
      Me.lblPlanillaEgreso.Location = New System.Drawing.Point(287, 27)
      Me.lblPlanillaEgreso.Name = "lblPlanillaEgreso"
      Me.lblPlanillaEgreso.Size = New System.Drawing.Size(40, 13)
      Me.lblPlanillaEgreso.TabIndex = 31
      Me.lblPlanillaEgreso.Text = "Planilla"
      '
      'txtNombreCajaEgreso
      '
      Me.txtNombreCajaEgreso.BindearPropiedadControl = ""
      Me.txtNombreCajaEgreso.BindearPropiedadEntidad = ""
      Me.txtNombreCajaEgreso.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCajaEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCajaEgreso.Formato = ""
      Me.txtNombreCajaEgreso.IsDecimal = False
      Me.txtNombreCajaEgreso.IsNumber = True
      Me.txtNombreCajaEgreso.IsPK = False
      Me.txtNombreCajaEgreso.IsRequired = False
      Me.txtNombreCajaEgreso.Key = Nothing
      Me.txtNombreCajaEgreso.LabelAsoc = Me.lblCajaEgreso
      Me.txtNombreCajaEgreso.Location = New System.Drawing.Point(171, 23)
      Me.txtNombreCajaEgreso.MaxLength = 100
      Me.txtNombreCajaEgreso.Name = "txtNombreCajaEgreso"
      Me.txtNombreCajaEgreso.ReadOnly = True
      Me.txtNombreCajaEgreso.Size = New System.Drawing.Size(100, 20)
      Me.txtNombreCajaEgreso.TabIndex = 36
      Me.txtNombreCajaEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblCajaEgreso
      '
      Me.lblCajaEgreso.AutoSize = True
      Me.lblCajaEgreso.LabelAsoc = Nothing
      Me.lblCajaEgreso.Location = New System.Drawing.Point(134, 27)
      Me.lblCajaEgreso.Name = "lblCajaEgreso"
      Me.lblCajaEgreso.Size = New System.Drawing.Size(28, 13)
      Me.lblCajaEgreso.TabIndex = 35
      Me.lblCajaEgreso.Text = "Caja"
      '
      'txtNroMovimientoEgreso
      '
      Me.txtNroMovimientoEgreso.BindearPropiedadControl = "Text"
      Me.txtNroMovimientoEgreso.BindearPropiedadEntidad = "NroMovimientoEgreso"
      Me.txtNroMovimientoEgreso.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroMovimientoEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroMovimientoEgreso.Formato = ""
      Me.txtNroMovimientoEgreso.IsDecimal = False
      Me.txtNroMovimientoEgreso.IsNumber = True
      Me.txtNroMovimientoEgreso.IsPK = False
      Me.txtNroMovimientoEgreso.IsRequired = False
      Me.txtNroMovimientoEgreso.Key = Nothing
      Me.txtNroMovimientoEgreso.LabelAsoc = Me.lblMovimientoEgreso
      Me.txtNroMovimientoEgreso.Location = New System.Drawing.Point(465, 23)
      Me.txtNroMovimientoEgreso.MaxLength = 100
      Me.txtNroMovimientoEgreso.Name = "txtNroMovimientoEgreso"
      Me.txtNroMovimientoEgreso.ReadOnly = True
      Me.txtNroMovimientoEgreso.Size = New System.Drawing.Size(80, 20)
      Me.txtNroMovimientoEgreso.TabIndex = 34
      Me.txtNroMovimientoEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblMovimientoEgreso
      '
      Me.lblMovimientoEgreso.AutoSize = True
      Me.lblMovimientoEgreso.LabelAsoc = Nothing
      Me.lblMovimientoEgreso.Location = New System.Drawing.Point(398, 27)
      Me.lblMovimientoEgreso.Name = "lblMovimientoEgreso"
      Me.lblMovimientoEgreso.Size = New System.Drawing.Size(61, 13)
      Me.lblMovimientoEgreso.TabIndex = 33
      Me.lblMovimientoEgreso.Text = "Movimiento"
      '
      'txtNroPlanillaEgreso
      '
      Me.txtNroPlanillaEgreso.BindearPropiedadControl = "Text"
      Me.txtNroPlanillaEgreso.BindearPropiedadEntidad = "NroPlanillaEgreso"
      Me.txtNroPlanillaEgreso.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroPlanillaEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroPlanillaEgreso.Formato = ""
      Me.txtNroPlanillaEgreso.IsDecimal = False
      Me.txtNroPlanillaEgreso.IsNumber = True
      Me.txtNroPlanillaEgreso.IsPK = False
      Me.txtNroPlanillaEgreso.IsRequired = False
      Me.txtNroPlanillaEgreso.Key = Nothing
      Me.txtNroPlanillaEgreso.LabelAsoc = Me.lblPlanillaEgreso
      Me.txtNroPlanillaEgreso.Location = New System.Drawing.Point(331, 23)
      Me.txtNroPlanillaEgreso.MaxLength = 100
      Me.txtNroPlanillaEgreso.Name = "txtNroPlanillaEgreso"
      Me.txtNroPlanillaEgreso.ReadOnly = True
      Me.txtNroPlanillaEgreso.Size = New System.Drawing.Size(50, 20)
      Me.txtNroPlanillaEgreso.TabIndex = 32
      Me.txtNroPlanillaEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblProveedor
      '
      Me.lblProveedor.AutoSize = True
      Me.lblProveedor.LabelAsoc = Nothing
      Me.lblProveedor.Location = New System.Drawing.Point(12, 68)
      Me.lblProveedor.Name = "lblProveedor"
      Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
      Me.lblProveedor.TabIndex = 29
      Me.lblProveedor.Text = "Proveedor"
      '
      'txtCodigoProveedor
      '
      Me.txtCodigoProveedor.BindearPropiedadControl = "Text"
      Me.txtCodigoProveedor.BindearPropiedadEntidad = "Proveedor.CodigoProveedor"
      Me.txtCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigoProveedor.Formato = ""
      Me.txtCodigoProveedor.IsDecimal = False
      Me.txtCodigoProveedor.IsNumber = False
      Me.txtCodigoProveedor.IsPK = False
      Me.txtCodigoProveedor.IsRequired = False
      Me.txtCodigoProveedor.Key = ""
      Me.txtCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
      Me.txtCodigoProveedor.Location = New System.Drawing.Point(80, 65)
      Me.txtCodigoProveedor.MaxLength = 12
      Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
      Me.txtCodigoProveedor.ReadOnly = True
      Me.txtCodigoProveedor.Size = New System.Drawing.Size(90, 20)
      Me.txtCodigoProveedor.TabIndex = 24
      Me.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.LabelAsoc = Nothing
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(80, 49)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 27
      Me.lblCodigoProveedor.Text = "Codigo"
      '
      'lblNombreProv
      '
      Me.lblNombreProv.AutoSize = True
      Me.lblNombreProv.LabelAsoc = Nothing
      Me.lblNombreProv.Location = New System.Drawing.Point(175, 49)
      Me.lblNombreProv.Name = "lblNombreProv"
      Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProv.TabIndex = 28
      Me.lblNombreProv.Text = "Nombre"
      '
      'TextBox2
      '
      Me.TextBox2.BindearPropiedadControl = "Text"
      Me.TextBox2.BindearPropiedadEntidad = "Proveedor.NombreProveedor"
      Me.TextBox2.ForeColorFocus = System.Drawing.Color.Red
      Me.TextBox2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.TextBox2.Formato = ""
      Me.TextBox2.IsDecimal = False
      Me.TextBox2.IsNumber = False
      Me.TextBox2.IsPK = False
      Me.TextBox2.IsRequired = False
      Me.TextBox2.Key = ""
      Me.TextBox2.LabelAsoc = Me.lblNombreProv
      Me.TextBox2.Location = New System.Drawing.Point(176, 65)
      Me.TextBox2.MaxLength = 100
      Me.TextBox2.Name = "TextBox2"
      Me.TextBox2.ReadOnly = True
      Me.TextBox2.Size = New System.Drawing.Size(307, 20)
      Me.TextBox2.TabIndex = 25
      '
      'ChequesPropiosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Nothing
      Me.ClientSize = New System.Drawing.Size(580, 412)
      Me.Controls.Add(Me.grbMovimientosDeCaja)
      Me.Controls.Add(Me.grbDetalle)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ChequesPropiosDetalle"
      Me.Text = "Cheque Propio"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.grbDetalle, 0)
      Me.Controls.SetChildIndex(Me.grbMovimientosDeCaja, 0)
      Me.grbDetalle.ResumeLayout(False)
      Me.grbDetalle.PerformLayout()
      Me.grbCuenta.ResumeLayout(False)
      Me.grbCuenta.PerformLayout()
      Me.grbMovimientosDeCaja.ResumeLayout(False)
      Me.grbMovimientosDeCaja.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents grbDetalle As System.Windows.Forms.GroupBox
   Friend WithEvents txtBancoSucursal As Eniac.Controles.TextBox
   Friend WithEvents lblSucursalBanco As Eniac.Controles.Label
   Friend WithEvents txtImporte As Eniac.Controles.TextBox
   Friend WithEvents lblImporte As Eniac.Controles.Label
   Friend WithEvents txtNumeroCheque As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroCheque As Eniac.Controles.Label
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents lblBanco As Eniac.Controles.Label
   Friend WithEvents dtpFechaCobro As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCobro As Eniac.Controles.Label
   Friend WithEvents dtpFechaEmision As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaEmision As Eniac.Controles.Label
   Friend WithEvents lblCuentas As Eniac.Controles.Label
   Friend WithEvents cmbCuentas As Eniac.Controles.ComboBox
   Friend WithEvents grbCuenta As System.Windows.Forms.GroupBox
   Friend WithEvents grbMovimientosDeCaja As System.Windows.Forms.GroupBox
   Friend WithEvents lblProveedor As Eniac.Controles.Label
   Friend WithEvents txtCodigoProveedor As Eniac.Controles.TextBox
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents TextBox2 As Eniac.Controles.TextBox
   Friend WithEvents lblEgreso As Eniac.Controles.Label
   Friend WithEvents IdCajaEgreso As Eniac.Controles.TextBox
   Friend WithEvents lblPlanillaEgreso As Eniac.Controles.Label
   Friend WithEvents txtNombreCajaEgreso As Eniac.Controles.TextBox
   Friend WithEvents lblCajaEgreso As Eniac.Controles.Label
   Friend WithEvents txtNroMovimientoEgreso As Eniac.Controles.TextBox
   Friend WithEvents lblMovimientoEgreso As Eniac.Controles.Label
   Friend WithEvents txtNroPlanillaEgreso As Eniac.Controles.TextBox
   Friend WithEvents txtNroOperacion As Eniac.Controles.TextBox
   Friend WithEvents lblNroOperacion As System.Windows.Forms.Label
   Friend WithEvents lblTipoCheque As Eniac.Controles.Label
   Friend WithEvents cmbTipoCheque As Eniac.Controles.ComboBox
End Class
