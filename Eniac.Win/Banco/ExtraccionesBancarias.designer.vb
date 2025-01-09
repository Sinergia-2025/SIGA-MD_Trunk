<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtraccionesBancarias
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.txtTotalTickets = New Eniac.Controles.TextBox()
      Me.lblTotalTickets = New Eniac.Controles.Label()
      Me.txtTotalTarjeta = New Eniac.Controles.TextBox()
      Me.lblTotalTarjeta = New Eniac.Controles.Label()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.lblTotal = New Eniac.Controles.Label()
      Me.txtTotalEfectivo = New Eniac.Controles.TextBox()
      Me.lblTotalEfectivo = New Eniac.Controles.Label()
      Me.txtTotalCheqPropios = New Eniac.Controles.TextBox()
      Me.lblChequesPropios = New Eniac.Controles.Label()
      Me.txtTotalCheqTerceros = New Eniac.Controles.TextBox()
      Me.lblChequesTerceros = New Eniac.Controles.Label()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.tbpDepositos2 = New System.Windows.Forms.TabPage()
      Me.grbChequesPropios = New System.Windows.Forms.GroupBox()
      Me.bscCuentaBancariaPropiaCodigo = New Eniac.Controles.Buscador()
      Me.txtNroOperacion = New Eniac.Controles.TextBox()
      Me.lblNroOperacion = New System.Windows.Forms.Label()
      Me.lblTipoCheque = New Eniac.Controles.Label()
      Me.cmbTipoCheque = New Eniac.Controles.ComboBox()
      Me.cmbBancoPropio = New Eniac.Controles.ComboBox()
      Me.lblBancoPropio = New Eniac.Controles.Label()
      Me.lblNroChequePropio = New Eniac.Controles.Label()
      Me.lblCuentaBancariaPropio = New Eniac.Controles.Label()
      Me.lblImporteChequePropio = New Eniac.Controles.Label()
      Me.txtCodPostalChequePropio = New Eniac.Controles.TextBox()
      Me.lblCodPostalPropio = New Eniac.Controles.Label()
      Me.dtpFechaCobroPropio = New Eniac.Controles.DateTimePicker()
      Me.lblFechaCobroPropio = New Eniac.Controles.Label()
      Me.txtNroChequePropio = New Eniac.Controles.TextBox()
      Me.txtImporteChequePropio = New Eniac.Controles.TextBox()
      Me.dtpFechaEmisionPropio = New Eniac.Controles.DateTimePicker()
      Me.lblFechaEmisionPropio = New Eniac.Controles.Label()
      Me.lblSucursalPropio = New Eniac.Controles.Label()
      Me.txtSucursalBancoPropio = New Eniac.Controles.TextBox()
      Me.dgvChequesPropios = New Eniac.Controles.DataGridView()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreTipoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.BancoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CP = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Localidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroPlanillaRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroMovimientoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroPlanillaEntregado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroMovimientoEntregado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.EsPropio = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Titular2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdEstadoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdEstadoChequeAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.RowState = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gchtIdSucursal2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gchpIdCajaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gchpIdCajaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FotoFrente1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FotoDorso1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CajaDetalleParaIngresoDirectoPorABM = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCuentaCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdProveedorPreasignado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoProveedorPreasignado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ProveedorPreasignado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cuit = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.btnInsertarChequePropio = New Eniac.Controles.Button()
      Me.btnEliminarChequePropio = New Eniac.Controles.Button()
      Me.bscCuentaBancariaPropio = New Eniac.Controles.Buscador()
      Me.txtIdCheque = New Eniac.Controles.TextBox()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
      Me.lblCotizacionDolar = New Eniac.Controles.Label()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblFechaAplicacion = New Eniac.Controles.Label()
      Me.dtpFechaAplicacion = New Eniac.Controles.DateTimePicker()
      Me.optFechaAplicacion = New Eniac.Controles.RadioButton()
      Me.optFechaCheque = New Eniac.Controles.RadioButton()
      Me.lblFechaAplicada = New Eniac.Controles.Label()
      Me.lblCuentaBancariaDestino = New Eniac.Controles.Label()
      Me.bscCuentaBancariaDestino = New Eniac.Controles.Buscador2()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblFechaDeposito = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tbcDetalle.SuspendLayout()
        Me.tbpDepositos2.SuspendLayout()
        Me.grbChequesPropios.SuspendLayout()
        CType(Me.dgvChequesPropios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCliente.SuspendLayout()
        Me.tspFacturacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTotalTickets
        '
        Me.txtTotalTickets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalTickets.BindearPropiedadControl = Nothing
        Me.txtTotalTickets.BindearPropiedadEntidad = Nothing
        Me.txtTotalTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTickets.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalTickets.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalTickets.Formato = "##,##0.00"
        Me.txtTotalTickets.IsDecimal = True
        Me.txtTotalTickets.IsNumber = True
        Me.txtTotalTickets.IsPK = False
        Me.txtTotalTickets.IsRequired = False
        Me.txtTotalTickets.Key = ""
        Me.txtTotalTickets.LabelAsoc = Me.lblTotalTickets
        Me.txtTotalTickets.Location = New System.Drawing.Point(304, 392)
        Me.txtTotalTickets.Name = "txtTotalTickets"
        Me.txtTotalTickets.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalTickets.TabIndex = 7
        Me.txtTotalTickets.Text = "0.00"
        Me.txtTotalTickets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalTickets.Visible = False
        '
        'lblTotalTickets
        '
        Me.lblTotalTickets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalTickets.AutoSize = True
        Me.lblTotalTickets.LabelAsoc = Nothing
        Me.lblTotalTickets.Location = New System.Drawing.Point(261, 396)
        Me.lblTotalTickets.Name = "lblTotalTickets"
        Me.lblTotalTickets.Size = New System.Drawing.Size(42, 13)
        Me.lblTotalTickets.TabIndex = 6
        Me.lblTotalTickets.Text = "Tickets"
        Me.lblTotalTickets.Visible = False
        '
        'txtTotalTarjeta
        '
        Me.txtTotalTarjeta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalTarjeta.BindearPropiedadControl = Nothing
        Me.txtTotalTarjeta.BindearPropiedadEntidad = Nothing
        Me.txtTotalTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalTarjeta.Formato = "##,##0.00"
        Me.txtTotalTarjeta.IsDecimal = True
        Me.txtTotalTarjeta.IsNumber = True
        Me.txtTotalTarjeta.IsPK = False
        Me.txtTotalTarjeta.IsRequired = False
        Me.txtTotalTarjeta.Key = ""
        Me.txtTotalTarjeta.LabelAsoc = Me.lblTotalTarjeta
        Me.txtTotalTarjeta.Location = New System.Drawing.Point(183, 393)
        Me.txtTotalTarjeta.Name = "txtTotalTarjeta"
        Me.txtTotalTarjeta.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalTarjeta.TabIndex = 5
        Me.txtTotalTarjeta.Text = "0.00"
        Me.txtTotalTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalTarjeta.Visible = False
        '
        'lblTotalTarjeta
        '
        Me.lblTotalTarjeta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalTarjeta.AutoSize = True
        Me.lblTotalTarjeta.LabelAsoc = Nothing
        Me.lblTotalTarjeta.Location = New System.Drawing.Point(140, 397)
        Me.lblTotalTarjeta.Name = "lblTotalTarjeta"
        Me.lblTotalTarjeta.Size = New System.Drawing.Size(40, 13)
        Me.lblTotalTarjeta.TabIndex = 4
        Me.lblTotalTarjeta.Text = "Tarjeta"
        Me.lblTotalTarjeta.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.BindearPropiedadControl = Nothing
        Me.txtTotal.BindearPropiedadEntidad = Nothing
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotal.Formato = "##,##0.00"
        Me.txtTotal.IsDecimal = True
        Me.txtTotal.IsNumber = True
        Me.txtTotal.IsPK = False
        Me.txtTotal.IsRequired = False
        Me.txtTotal.Key = ""
        Me.txtTotal.LabelAsoc = Me.lblTotal
        Me.txtTotal.Location = New System.Drawing.Point(718, 393)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(80, 21)
        Me.txtTotal.TabIndex = 13
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.LabelAsoc = Nothing
        Me.lblTotal.Location = New System.Drawing.Point(684, 397)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(31, 13)
        Me.lblTotal.TabIndex = 12
        Me.lblTotal.Text = "Total"
        '
        'txtTotalEfectivo
        '
        Me.txtTotalEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalEfectivo.BindearPropiedadControl = Nothing
        Me.txtTotalEfectivo.BindearPropiedadEntidad = Nothing
        Me.txtTotalEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEfectivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalEfectivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalEfectivo.Formato = "##,##0.00"
        Me.txtTotalEfectivo.IsDecimal = True
        Me.txtTotalEfectivo.IsNumber = True
        Me.txtTotalEfectivo.IsPK = False
        Me.txtTotalEfectivo.IsRequired = False
        Me.txtTotalEfectivo.Key = ""
        Me.txtTotalEfectivo.LabelAsoc = Me.lblTotalEfectivo
        Me.txtTotalEfectivo.Location = New System.Drawing.Point(65, 393)
        Me.txtTotalEfectivo.Name = "txtTotalEfectivo"
        Me.txtTotalEfectivo.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalEfectivo.TabIndex = 3
        Me.txtTotalEfectivo.Text = "0.00"
        Me.txtTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalEfectivo
        '
        Me.lblTotalEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalEfectivo.AutoSize = True
        Me.lblTotalEfectivo.LabelAsoc = Nothing
        Me.lblTotalEfectivo.Location = New System.Drawing.Point(16, 397)
        Me.lblTotalEfectivo.Name = "lblTotalEfectivo"
        Me.lblTotalEfectivo.Size = New System.Drawing.Size(46, 13)
        Me.lblTotalEfectivo.TabIndex = 2
        Me.lblTotalEfectivo.Text = "Efectivo"
        '
        'txtTotalCheqPropios
        '
        Me.txtTotalCheqPropios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCheqPropios.BindearPropiedadControl = Nothing
        Me.txtTotalCheqPropios.BindearPropiedadEntidad = Nothing
        Me.txtTotalCheqPropios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCheqPropios.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalCheqPropios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalCheqPropios.Formato = "##,##0.00"
        Me.txtTotalCheqPropios.IsDecimal = True
        Me.txtTotalCheqPropios.IsNumber = True
        Me.txtTotalCheqPropios.IsPK = False
        Me.txtTotalCheqPropios.IsRequired = False
        Me.txtTotalCheqPropios.Key = ""
        Me.txtTotalCheqPropios.LabelAsoc = Me.lblChequesPropios
        Me.txtTotalCheqPropios.Location = New System.Drawing.Point(610, 393)
        Me.txtTotalCheqPropios.Name = "txtTotalCheqPropios"
        Me.txtTotalCheqPropios.ReadOnly = True
        Me.txtTotalCheqPropios.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalCheqPropios.TabIndex = 11
        Me.txtTotalCheqPropios.TabStop = False
        Me.txtTotalCheqPropios.Text = "0.00"
        Me.txtTotalCheqPropios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblChequesPropios
        '
        Me.lblChequesPropios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblChequesPropios.AutoSize = True
        Me.lblChequesPropios.LabelAsoc = Nothing
        Me.lblChequesPropios.Location = New System.Drawing.Point(534, 397)
        Me.lblChequesPropios.Name = "lblChequesPropios"
        Me.lblChequesPropios.Size = New System.Drawing.Size(73, 13)
        Me.lblChequesPropios.TabIndex = 10
        Me.lblChequesPropios.Text = "Cheq. Propios"
        '
        'txtTotalCheqTerceros
        '
        Me.txtTotalCheqTerceros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCheqTerceros.BindearPropiedadControl = Nothing
        Me.txtTotalCheqTerceros.BindearPropiedadEntidad = Nothing
        Me.txtTotalCheqTerceros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCheqTerceros.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalCheqTerceros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalCheqTerceros.Formato = "##,##0.00"
        Me.txtTotalCheqTerceros.IsDecimal = True
        Me.txtTotalCheqTerceros.IsNumber = True
        Me.txtTotalCheqTerceros.IsPK = False
        Me.txtTotalCheqTerceros.IsRequired = False
        Me.txtTotalCheqTerceros.Key = ""
        Me.txtTotalCheqTerceros.LabelAsoc = Me.lblChequesTerceros
        Me.txtTotalCheqTerceros.Location = New System.Drawing.Point(454, 393)
        Me.txtTotalCheqTerceros.Name = "txtTotalCheqTerceros"
        Me.txtTotalCheqTerceros.ReadOnly = True
        Me.txtTotalCheqTerceros.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalCheqTerceros.TabIndex = 9
        Me.txtTotalCheqTerceros.TabStop = False
        Me.txtTotalCheqTerceros.Text = "0.00"
        Me.txtTotalCheqTerceros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalCheqTerceros.Visible = False
        '
        'lblChequesTerceros
        '
        Me.lblChequesTerceros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblChequesTerceros.AutoSize = True
        Me.lblChequesTerceros.LabelAsoc = Nothing
        Me.lblChequesTerceros.Location = New System.Drawing.Point(385, 397)
        Me.lblChequesTerceros.Name = "lblChequesTerceros"
        Me.lblChequesTerceros.Size = New System.Drawing.Size(63, 13)
        Me.lblChequesTerceros.TabIndex = 8
        Me.lblChequesTerceros.Text = "Cheq. Terc."
        Me.lblChequesTerceros.Visible = False
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle.Controls.Add(Me.tbpDepositos2)
        Me.tbcDetalle.Location = New System.Drawing.Point(3, 123)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(799, 263)
        Me.tbcDetalle.TabIndex = 1
        Me.tbcDetalle.TabStop = False
        '
        'tbpDepositos2
        '
        Me.tbpDepositos2.Controls.Add(Me.grbChequesPropios)
        Me.tbpDepositos2.Location = New System.Drawing.Point(4, 22)
        Me.tbpDepositos2.Name = "tbpDepositos2"
        Me.tbpDepositos2.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDepositos2.Size = New System.Drawing.Size(791, 237)
        Me.tbpDepositos2.TabIndex = 1
        Me.tbpDepositos2.Text = "Cheques Propios"
        Me.tbpDepositos2.UseVisualStyleBackColor = True
        '
        'grbChequesPropios
        '
        Me.grbChequesPropios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbChequesPropios.Controls.Add(Me.bscCuentaBancariaPropiaCodigo)
        Me.grbChequesPropios.Controls.Add(Me.txtNroOperacion)
        Me.grbChequesPropios.Controls.Add(Me.lblNroOperacion)
        Me.grbChequesPropios.Controls.Add(Me.lblTipoCheque)
        Me.grbChequesPropios.Controls.Add(Me.cmbTipoCheque)
        Me.grbChequesPropios.Controls.Add(Me.cmbBancoPropio)
        Me.grbChequesPropios.Controls.Add(Me.lblBancoPropio)
        Me.grbChequesPropios.Controls.Add(Me.lblNroChequePropio)
        Me.grbChequesPropios.Controls.Add(Me.lblCuentaBancariaPropio)
        Me.grbChequesPropios.Controls.Add(Me.lblImporteChequePropio)
        Me.grbChequesPropios.Controls.Add(Me.txtCodPostalChequePropio)
        Me.grbChequesPropios.Controls.Add(Me.lblCodPostalPropio)
        Me.grbChequesPropios.Controls.Add(Me.dtpFechaCobroPropio)
        Me.grbChequesPropios.Controls.Add(Me.txtNroChequePropio)
        Me.grbChequesPropios.Controls.Add(Me.lblFechaCobroPropio)
        Me.grbChequesPropios.Controls.Add(Me.txtImporteChequePropio)
        Me.grbChequesPropios.Controls.Add(Me.dtpFechaEmisionPropio)
        Me.grbChequesPropios.Controls.Add(Me.lblSucursalPropio)
        Me.grbChequesPropios.Controls.Add(Me.lblFechaEmisionPropio)
        Me.grbChequesPropios.Controls.Add(Me.txtSucursalBancoPropio)
        Me.grbChequesPropios.Controls.Add(Me.dgvChequesPropios)
        Me.grbChequesPropios.Controls.Add(Me.btnInsertarChequePropio)
        Me.grbChequesPropios.Controls.Add(Me.btnEliminarChequePropio)
        Me.grbChequesPropios.Controls.Add(Me.bscCuentaBancariaPropio)
        Me.grbChequesPropios.Controls.Add(Me.txtIdCheque)
        Me.grbChequesPropios.Location = New System.Drawing.Point(4, 3)
        Me.grbChequesPropios.Name = "grbChequesPropios"
        Me.grbChequesPropios.Size = New System.Drawing.Size(784, 228)
        Me.grbChequesPropios.TabIndex = 0
        Me.grbChequesPropios.TabStop = False
        '
        'bscCuentaBancariaPropiaCodigo
        '
        Me.bscCuentaBancariaPropiaCodigo.AyudaAncho = 608
        Me.bscCuentaBancariaPropiaCodigo.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaPropiaCodigo.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaPropiaCodigo.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaPropiaCodigo.ColumnasAncho = Nothing
        Me.bscCuentaBancariaPropiaCodigo.ColumnasFormato = Nothing
        Me.bscCuentaBancariaPropiaCodigo.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaPropiaCodigo.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaPropiaCodigo.Datos = Nothing
        Me.bscCuentaBancariaPropiaCodigo.FilaDevuelta = Nothing
        Me.bscCuentaBancariaPropiaCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaPropiaCodigo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaPropiaCodigo.IsDecimal = False
        Me.bscCuentaBancariaPropiaCodigo.IsNumber = False
        Me.bscCuentaBancariaPropiaCodigo.IsPK = False
        Me.bscCuentaBancariaPropiaCodigo.IsRequired = False
        Me.bscCuentaBancariaPropiaCodigo.Key = ""
        Me.bscCuentaBancariaPropiaCodigo.LabelAsoc = Nothing
        Me.bscCuentaBancariaPropiaCodigo.Location = New System.Drawing.Point(265, 19)
        Me.bscCuentaBancariaPropiaCodigo.MaxLengh = "32767"
        Me.bscCuentaBancariaPropiaCodigo.Name = "bscCuentaBancariaPropiaCodigo"
        Me.bscCuentaBancariaPropiaCodigo.Permitido = True
        Me.bscCuentaBancariaPropiaCodigo.Selecciono = False
        Me.bscCuentaBancariaPropiaCodigo.Size = New System.Drawing.Size(84, 20)
        Me.bscCuentaBancariaPropiaCodigo.TabIndex = 24
        Me.bscCuentaBancariaPropiaCodigo.Titulo = "Clientes"
        Me.bscCuentaBancariaPropiaCodigo.Visible = False
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
        Me.txtNroOperacion.Location = New System.Drawing.Point(390, 68)
        Me.txtNroOperacion.MaxLength = 15
        Me.txtNroOperacion.Name = "txtNroOperacion"
        Me.txtNroOperacion.Size = New System.Drawing.Size(109, 20)
        Me.txtNroOperacion.TabIndex = 13
        '
        'lblNroOperacion
        '
        Me.lblNroOperacion.AutoSize = True
        Me.lblNroOperacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNroOperacion.Location = New System.Drawing.Point(387, 53)
        Me.lblNroOperacion.Name = "lblNroOperacion"
        Me.lblNroOperacion.Size = New System.Drawing.Size(79, 13)
        Me.lblNroOperacion.TabIndex = 12
        Me.lblNroOperacion.Text = "Nro. Operación"
        '
        'lblTipoCheque
        '
        Me.lblTipoCheque.AutoSize = True
        Me.lblTipoCheque.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoCheque.LabelAsoc = Nothing
        Me.lblTipoCheque.Location = New System.Drawing.Point(2, 22)
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
        Me.cmbTipoCheque.Location = New System.Drawing.Point(91, 19)
        Me.cmbTipoCheque.Name = "cmbTipoCheque"
        Me.cmbTipoCheque.Size = New System.Drawing.Size(99, 21)
        Me.cmbTipoCheque.TabIndex = 1
        '
        'cmbBancoPropio
        '
        Me.cmbBancoPropio.BindearPropiedadControl = "SelectedValue"
        Me.cmbBancoPropio.BindearPropiedadEntidad = "Banco.idBanco"
        Me.cmbBancoPropio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancoPropio.Enabled = False
        Me.cmbBancoPropio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBancoPropio.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBancoPropio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBancoPropio.FormattingEnabled = True
        Me.cmbBancoPropio.IsPK = False
        Me.cmbBancoPropio.IsRequired = True
        Me.cmbBancoPropio.Key = Nothing
        Me.cmbBancoPropio.LabelAsoc = Me.lblBancoPropio
        Me.cmbBancoPropio.Location = New System.Drawing.Point(193, 67)
        Me.cmbBancoPropio.Name = "cmbBancoPropio"
        Me.cmbBancoPropio.Size = New System.Drawing.Size(123, 21)
        Me.cmbBancoPropio.TabIndex = 7
        '
        'lblBancoPropio
        '
        Me.lblBancoPropio.AutoSize = True
        Me.lblBancoPropio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBancoPropio.LabelAsoc = Nothing
        Me.lblBancoPropio.Location = New System.Drawing.Point(191, 53)
        Me.lblBancoPropio.Name = "lblBancoPropio"
        Me.lblBancoPropio.Size = New System.Drawing.Size(38, 13)
        Me.lblBancoPropio.TabIndex = 6
        Me.lblBancoPropio.Text = "Banco"
        '
        'lblNroChequePropio
        '
        Me.lblNroChequePropio.AutoSize = True
        Me.lblNroChequePropio.LabelAsoc = Nothing
        Me.lblNroChequePropio.Location = New System.Drawing.Point(128, 53)
        Me.lblNroChequePropio.Name = "lblNroChequePropio"
        Me.lblNroChequePropio.Size = New System.Drawing.Size(58, 13)
        Me.lblNroChequePropio.TabIndex = 4
        Me.lblNroChequePropio.Text = "N. Cheque"
        '
        'lblCuentaBancariaPropio
        '
        Me.lblCuentaBancariaPropio.AutoSize = True
        Me.lblCuentaBancariaPropio.LabelAsoc = Nothing
        Me.lblCuentaBancariaPropio.Location = New System.Drawing.Point(6, 52)
        Me.lblCuentaBancariaPropio.Name = "lblCuentaBancariaPropio"
        Me.lblCuentaBancariaPropio.Size = New System.Drawing.Size(86, 13)
        Me.lblCuentaBancariaPropio.TabIndex = 2
        Me.lblCuentaBancariaPropio.Text = "Cuenta Bancaria"
        '
        'lblImporteChequePropio
        '
        Me.lblImporteChequePropio.AutoSize = True
        Me.lblImporteChequePropio.LabelAsoc = Nothing
        Me.lblImporteChequePropio.Location = New System.Drawing.Point(685, 53)
        Me.lblImporteChequePropio.Name = "lblImporteChequePropio"
        Me.lblImporteChequePropio.Size = New System.Drawing.Size(42, 13)
        Me.lblImporteChequePropio.TabIndex = 18
        Me.lblImporteChequePropio.Text = "Importe"
        '
        'txtCodPostalChequePropio
        '
        Me.txtCodPostalChequePropio.BindearPropiedadControl = Nothing
        Me.txtCodPostalChequePropio.BindearPropiedadEntidad = Nothing
        Me.txtCodPostalChequePropio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodPostalChequePropio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodPostalChequePropio.Formato = "0"
        Me.txtCodPostalChequePropio.IsDecimal = False
        Me.txtCodPostalChequePropio.IsNumber = True
        Me.txtCodPostalChequePropio.IsPK = False
        Me.txtCodPostalChequePropio.IsRequired = False
        Me.txtCodPostalChequePropio.Key = ""
        Me.txtCodPostalChequePropio.LabelAsoc = Me.lblCodPostalPropio
        Me.txtCodPostalChequePropio.Location = New System.Drawing.Point(353, 68)
        Me.txtCodPostalChequePropio.MaxLength = 4
        Me.txtCodPostalChequePropio.Name = "txtCodPostalChequePropio"
        Me.txtCodPostalChequePropio.ReadOnly = True
        Me.txtCodPostalChequePropio.Size = New System.Drawing.Size(31, 20)
        Me.txtCodPostalChequePropio.TabIndex = 11
        Me.txtCodPostalChequePropio.Text = "0"
        Me.txtCodPostalChequePropio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodPostalPropio
        '
        Me.lblCodPostalPropio.AutoSize = True
        Me.lblCodPostalPropio.LabelAsoc = Nothing
        Me.lblCodPostalPropio.Location = New System.Drawing.Point(355, 53)
        Me.lblCodPostalPropio.Name = "lblCodPostalPropio"
        Me.lblCodPostalPropio.Size = New System.Drawing.Size(27, 13)
        Me.lblCodPostalPropio.TabIndex = 10
        Me.lblCodPostalPropio.Text = "C.P."
        '
        'dtpFechaCobroPropio
        '
        Me.dtpFechaCobroPropio.BindearPropiedadControl = Nothing
        Me.dtpFechaCobroPropio.BindearPropiedadEntidad = Nothing
        Me.dtpFechaCobroPropio.CustomFormat = "dd/MM/yy"
        Me.dtpFechaCobroPropio.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCobroPropio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCobroPropio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCobroPropio.IsPK = False
        Me.dtpFechaCobroPropio.IsRequired = False
        Me.dtpFechaCobroPropio.Key = ""
        Me.dtpFechaCobroPropio.LabelAsoc = Me.lblFechaCobroPropio
        Me.dtpFechaCobroPropio.Location = New System.Drawing.Point(586, 68)
        Me.dtpFechaCobroPropio.Name = "dtpFechaCobroPropio"
        Me.dtpFechaCobroPropio.Size = New System.Drawing.Size(75, 20)
        Me.dtpFechaCobroPropio.TabIndex = 17
        '
        'lblFechaCobroPropio
        '
        Me.lblFechaCobroPropio.AutoSize = True
        Me.lblFechaCobroPropio.LabelAsoc = Nothing
        Me.lblFechaCobroPropio.Location = New System.Drawing.Point(583, 54)
        Me.lblFechaCobroPropio.Name = "lblFechaCobroPropio"
        Me.lblFechaCobroPropio.Size = New System.Drawing.Size(68, 13)
        Me.lblFechaCobroPropio.TabIndex = 16
        Me.lblFechaCobroPropio.Text = "Fecha Cobro"
        '
        'txtNroChequePropio
        '
        Me.txtNroChequePropio.BindearPropiedadControl = Nothing
        Me.txtNroChequePropio.BindearPropiedadEntidad = Nothing
        Me.txtNroChequePropio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroChequePropio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroChequePropio.Formato = "0"
        Me.txtNroChequePropio.IsDecimal = False
        Me.txtNroChequePropio.IsNumber = True
        Me.txtNroChequePropio.IsPK = False
        Me.txtNroChequePropio.IsRequired = False
        Me.txtNroChequePropio.Key = ""
        Me.txtNroChequePropio.LabelAsoc = Me.lblNroChequePropio
        Me.txtNroChequePropio.Location = New System.Drawing.Point(133, 68)
        Me.txtNroChequePropio.MaxLength = 8
        Me.txtNroChequePropio.Name = "txtNroChequePropio"
        Me.txtNroChequePropio.Size = New System.Drawing.Size(57, 20)
        Me.txtNroChequePropio.TabIndex = 5
        Me.txtNroChequePropio.Text = "0"
        Me.txtNroChequePropio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteChequePropio
        '
        Me.txtImporteChequePropio.BindearPropiedadControl = Nothing
        Me.txtImporteChequePropio.BindearPropiedadEntidad = Nothing
        Me.txtImporteChequePropio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteChequePropio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteChequePropio.Formato = "N2"
        Me.txtImporteChequePropio.IsDecimal = True
        Me.txtImporteChequePropio.IsNumber = True
        Me.txtImporteChequePropio.IsPK = False
        Me.txtImporteChequePropio.IsRequired = False
        Me.txtImporteChequePropio.Key = ""
        Me.txtImporteChequePropio.LabelAsoc = Me.lblImporteChequePropio
        Me.txtImporteChequePropio.Location = New System.Drawing.Point(667, 68)
        Me.txtImporteChequePropio.MaxLength = 10
        Me.txtImporteChequePropio.Name = "txtImporteChequePropio"
        Me.txtImporteChequePropio.Size = New System.Drawing.Size(60, 20)
        Me.txtImporteChequePropio.TabIndex = 19
        Me.txtImporteChequePropio.Text = "0.00"
        Me.txtImporteChequePropio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFechaEmisionPropio
        '
        Me.dtpFechaEmisionPropio.BindearPropiedadControl = Nothing
        Me.dtpFechaEmisionPropio.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEmisionPropio.CustomFormat = "dd/MM/yy"
        Me.dtpFechaEmisionPropio.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEmisionPropio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEmisionPropio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEmisionPropio.IsPK = False
        Me.dtpFechaEmisionPropio.IsRequired = False
        Me.dtpFechaEmisionPropio.Key = ""
        Me.dtpFechaEmisionPropio.LabelAsoc = Me.lblFechaEmisionPropio
        Me.dtpFechaEmisionPropio.Location = New System.Drawing.Point(505, 68)
        Me.dtpFechaEmisionPropio.Name = "dtpFechaEmisionPropio"
        Me.dtpFechaEmisionPropio.Size = New System.Drawing.Size(75, 20)
        Me.dtpFechaEmisionPropio.TabIndex = 15
        '
        'lblFechaEmisionPropio
        '
        Me.lblFechaEmisionPropio.AutoSize = True
        Me.lblFechaEmisionPropio.LabelAsoc = Nothing
        Me.lblFechaEmisionPropio.Location = New System.Drawing.Point(502, 54)
        Me.lblFechaEmisionPropio.Name = "lblFechaEmisionPropio"
        Me.lblFechaEmisionPropio.Size = New System.Drawing.Size(76, 13)
        Me.lblFechaEmisionPropio.TabIndex = 14
        Me.lblFechaEmisionPropio.Text = "Fecha Emision"
        '
        'lblSucursalPropio
        '
        Me.lblSucursalPropio.AutoSize = True
        Me.lblSucursalPropio.LabelAsoc = Nothing
        Me.lblSucursalPropio.Location = New System.Drawing.Point(321, 53)
        Me.lblSucursalPropio.Name = "lblSucursalPropio"
        Me.lblSucursalPropio.Size = New System.Drawing.Size(29, 13)
        Me.lblSucursalPropio.TabIndex = 8
        Me.lblSucursalPropio.Text = "Suc."
        '
        'txtSucursalBancoPropio
        '
        Me.txtSucursalBancoPropio.BindearPropiedadControl = Nothing
        Me.txtSucursalBancoPropio.BindearPropiedadEntidad = Nothing
        Me.txtSucursalBancoPropio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSucursalBancoPropio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSucursalBancoPropio.Formato = "0"
        Me.txtSucursalBancoPropio.IsDecimal = False
        Me.txtSucursalBancoPropio.IsNumber = True
        Me.txtSucursalBancoPropio.IsPK = False
        Me.txtSucursalBancoPropio.IsRequired = False
        Me.txtSucursalBancoPropio.Key = ""
        Me.txtSucursalBancoPropio.LabelAsoc = Me.lblSucursalPropio
        Me.txtSucursalBancoPropio.Location = New System.Drawing.Point(319, 68)
        Me.txtSucursalBancoPropio.MaxLength = 3
        Me.txtSucursalBancoPropio.Name = "txtSucursalBancoPropio"
        Me.txtSucursalBancoPropio.ReadOnly = True
        Me.txtSucursalBancoPropio.Size = New System.Drawing.Size(31, 20)
        Me.txtSucursalBancoPropio.TabIndex = 9
        Me.txtSucursalBancoPropio.Text = "0"
        Me.txtSucursalBancoPropio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvChequesPropios
        '
        Me.dgvChequesPropios.AllowUserToAddRows = False
        Me.dgvChequesPropios.AllowUserToDeleteRows = False
        Me.dgvChequesPropios.AllowUserToResizeRows = False
        Me.dgvChequesPropios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvChequesPropios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChequesPropios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSucursal, Me.IdCheque, Me.NombreTipoCheque, Me.CuentaBancaria, Me.IdCuentaBancaria, Me.NombreCuentaBancaria, Me.Banco, Me.IdBanco, Me.BancoNombre, Me.Sucursal, Me.CP, Me.Localidad, Me.NumeroCheque, Me.NroOperacion, Me.FechaEmision, Me.FechaCobro, Me.Importe, Me.NroPlanillaRecibo, Me.Cliente, Me.NroMovimientoRecibo, Me.NroPlanillaEntregado, Me.Proveedor, Me.NroMovimientoEntregado, Me.Usuario, Me.Password, Me.EsPropio, Me.Titular2, Me.IdEstadoCheque, Me.IdEstadoChequeAnt, Me.RowState, Me.gchtIdSucursal2, Me.gchpIdCajaIngreso, Me.gchpIdCajaEgreso, Me.FotoFrente1, Me.FotoDorso1, Me.CajaDetalleParaIngresoDirectoPorABM, Me.IdCuentaCaja, Me.IdProveedorPreasignado, Me.CodigoProveedorPreasignado, Me.ProveedorPreasignado, Me.Cuit, Me.IdTipoCheque})
        Me.dgvChequesPropios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvChequesPropios.Location = New System.Drawing.Point(2, 94)
        Me.dgvChequesPropios.MultiSelect = False
        Me.dgvChequesPropios.Name = "dgvChequesPropios"
        Me.dgvChequesPropios.ReadOnly = True
        Me.dgvChequesPropios.RowHeadersWidth = 20
        Me.dgvChequesPropios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvChequesPropios.Size = New System.Drawing.Size(780, 128)
        Me.dgvChequesPropios.TabIndex = 22
        '
        'IdSucursal
        '
        Me.IdSucursal.DataPropertyName = "IdSucursal"
        Me.IdSucursal.HeaderText = "IdSucursal"
        Me.IdSucursal.Name = "IdSucursal"
        Me.IdSucursal.ReadOnly = True
        Me.IdSucursal.Visible = False
        '
        'IdCheque
        '
        Me.IdCheque.DataPropertyName = "IdCheque"
        Me.IdCheque.HeaderText = "IdCheque"
        Me.IdCheque.Name = "IdCheque"
        Me.IdCheque.ReadOnly = True
        Me.IdCheque.Visible = False
        '
        'NombreTipoCheque
        '
        Me.NombreTipoCheque.DataPropertyName = "NombreTipoCheque"
        Me.NombreTipoCheque.HeaderText = "Tipo de Cheque"
        Me.NombreTipoCheque.Name = "NombreTipoCheque"
        Me.NombreTipoCheque.ReadOnly = True
        '
        'CuentaBancaria
        '
        Me.CuentaBancaria.DataPropertyName = "CuentaBancaria"
        Me.CuentaBancaria.HeaderText = "CuentaBancaria"
        Me.CuentaBancaria.Name = "CuentaBancaria"
        Me.CuentaBancaria.ReadOnly = True
        Me.CuentaBancaria.Visible = False
        '
        'IdCuentaBancaria
        '
        Me.IdCuentaBancaria.DataPropertyName = "IdCuentaBancaria"
        Me.IdCuentaBancaria.HeaderText = "IdCuentaBancaria"
        Me.IdCuentaBancaria.Name = "IdCuentaBancaria"
        Me.IdCuentaBancaria.ReadOnly = True
        Me.IdCuentaBancaria.Visible = False
        '
        'NombreCuentaBancaria
        '
        Me.NombreCuentaBancaria.DataPropertyName = "NombreCuentaBancaria"
        Me.NombreCuentaBancaria.HeaderText = "Cuenta Bancaria"
        Me.NombreCuentaBancaria.Name = "NombreCuentaBancaria"
        Me.NombreCuentaBancaria.ReadOnly = True
        Me.NombreCuentaBancaria.Width = 60
        '
        'Banco
        '
        Me.Banco.DataPropertyName = "Banco"
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.ReadOnly = True
        Me.Banco.Visible = False
        '
        'IdBanco
        '
        Me.IdBanco.DataPropertyName = "IdBanco"
        Me.IdBanco.HeaderText = "IdBanco"
        Me.IdBanco.Name = "IdBanco"
        Me.IdBanco.ReadOnly = True
        Me.IdBanco.Visible = False
        '
        'BancoNombre
        '
        Me.BancoNombre.DataPropertyName = "NombreBanco"
        Me.BancoNombre.HeaderText = "Nombre Banco"
        Me.BancoNombre.Name = "BancoNombre"
        Me.BancoNombre.ReadOnly = True
        Me.BancoNombre.Width = 130
        '
        'Sucursal
        '
        Me.Sucursal.DataPropertyName = "IdBancoSucursal"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Sucursal.DefaultCellStyle = DataGridViewCellStyle1
        Me.Sucursal.HeaderText = "Suc."
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.ReadOnly = True
        Me.Sucursal.Width = 40
        '
        'CP
        '
        Me.CP.DataPropertyName = "CP"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CP.DefaultCellStyle = DataGridViewCellStyle2
        Me.CP.HeaderText = "C.P."
        Me.CP.Name = "CP"
        Me.CP.ReadOnly = True
        Me.CP.Width = 40
        '
        'Localidad
        '
        Me.Localidad.DataPropertyName = "Localidad"
        Me.Localidad.HeaderText = "Localidad"
        Me.Localidad.Name = "Localidad"
        Me.Localidad.ReadOnly = True
        Me.Localidad.Visible = False
        '
        'NumeroCheque
        '
        Me.NumeroCheque.DataPropertyName = "NumeroCheque"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroCheque.DefaultCellStyle = DataGridViewCellStyle3
        Me.NumeroCheque.HeaderText = "Numero"
        Me.NumeroCheque.Name = "NumeroCheque"
        Me.NumeroCheque.ReadOnly = True
        Me.NumeroCheque.Width = 80
        '
        'NroOperacion
        '
        Me.NroOperacion.DataPropertyName = "NroOperacion"
        Me.NroOperacion.HeaderText = "Nro. Operación"
        Me.NroOperacion.Name = "NroOperacion"
        Me.NroOperacion.ReadOnly = True
        '
        'FechaEmision
        '
        Me.FechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.FechaEmision.DefaultCellStyle = DataGridViewCellStyle4
        Me.FechaEmision.HeaderText = "Emision"
        Me.FechaEmision.Name = "FechaEmision"
        Me.FechaEmision.ReadOnly = True
        Me.FechaEmision.Width = 70
        '
        'FechaCobro
        '
        Me.FechaCobro.DataPropertyName = "FechaCobro"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        Me.FechaCobro.DefaultCellStyle = DataGridViewCellStyle5
        Me.FechaCobro.HeaderText = "Cobro"
        Me.FechaCobro.Name = "FechaCobro"
        Me.FechaCobro.ReadOnly = True
        Me.FechaCobro.Width = 70
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle6
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 90
        '
        'NroPlanillaRecibo
        '
        Me.NroPlanillaRecibo.DataPropertyName = "NroPlanillaIngreso"
        Me.NroPlanillaRecibo.HeaderText = "NroPlanillaRecibo"
        Me.NroPlanillaRecibo.Name = "NroPlanillaRecibo"
        Me.NroPlanillaRecibo.ReadOnly = True
        Me.NroPlanillaRecibo.Visible = False
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Visible = False
        '
        'NroMovimientoRecibo
        '
        Me.NroMovimientoRecibo.DataPropertyName = "NroMovimientoIngreso"
        Me.NroMovimientoRecibo.HeaderText = "NroMovimientoRecibo"
        Me.NroMovimientoRecibo.Name = "NroMovimientoRecibo"
        Me.NroMovimientoRecibo.ReadOnly = True
        Me.NroMovimientoRecibo.Visible = False
        '
        'NroPlanillaEntregado
        '
        Me.NroPlanillaEntregado.DataPropertyName = "NroPlanillaEgreso"
        Me.NroPlanillaEntregado.HeaderText = "NroPlanillaEntregado"
        Me.NroPlanillaEntregado.Name = "NroPlanillaEntregado"
        Me.NroPlanillaEntregado.ReadOnly = True
        Me.NroPlanillaEntregado.Visible = False
        '
        'Proveedor
        '
        Me.Proveedor.DataPropertyName = "Proveedor"
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Visible = False
        '
        'NroMovimientoEntregado
        '
        Me.NroMovimientoEntregado.DataPropertyName = "NroMovimientoEgreso"
        Me.NroMovimientoEntregado.HeaderText = "NroMovimientoEntregado"
        Me.NroMovimientoEntregado.Name = "NroMovimientoEntregado"
        Me.NroMovimientoEntregado.ReadOnly = True
        Me.NroMovimientoEntregado.Visible = False
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        Me.Usuario.Visible = False
        '
        'Password
        '
        Me.Password.DataPropertyName = "Password"
        Me.Password.HeaderText = "PwdCheque"
        Me.Password.Name = "Password"
        Me.Password.ReadOnly = True
        Me.Password.Visible = False
        '
        'EsPropio
        '
        Me.EsPropio.DataPropertyName = "EsPropio"
        Me.EsPropio.HeaderText = "EsPropio"
        Me.EsPropio.Name = "EsPropio"
        Me.EsPropio.ReadOnly = True
        Me.EsPropio.Visible = False
        '
        'Titular2
        '
        Me.Titular2.DataPropertyName = "Titular"
        Me.Titular2.HeaderText = "Titular2"
        Me.Titular2.Name = "Titular2"
        Me.Titular2.ReadOnly = True
        Me.Titular2.Visible = False
        '
        'IdEstadoCheque
        '
        Me.IdEstadoCheque.DataPropertyName = "IdEstadoCheque"
        Me.IdEstadoCheque.HeaderText = "IdEstadoCheque"
        Me.IdEstadoCheque.Name = "IdEstadoCheque"
        Me.IdEstadoCheque.ReadOnly = True
        Me.IdEstadoCheque.Visible = False
        '
        'IdEstadoChequeAnt
        '
        Me.IdEstadoChequeAnt.DataPropertyName = "IdEstadoChequeAnt"
        Me.IdEstadoChequeAnt.HeaderText = "IdEstadoChequeAnt"
        Me.IdEstadoChequeAnt.Name = "IdEstadoChequeAnt"
        Me.IdEstadoChequeAnt.ReadOnly = True
        Me.IdEstadoChequeAnt.Visible = False
        '
        'RowState
        '
        Me.RowState.DataPropertyName = "RowState"
        Me.RowState.HeaderText = "RowState"
        Me.RowState.Name = "RowState"
        Me.RowState.ReadOnly = True
        Me.RowState.Visible = False
        '
        'gchtIdSucursal2
        '
        Me.gchtIdSucursal2.DataPropertyName = "IdSucursal2"
        Me.gchtIdSucursal2.HeaderText = "IdSucursal2"
        Me.gchtIdSucursal2.Name = "gchtIdSucursal2"
        Me.gchtIdSucursal2.ReadOnly = True
        Me.gchtIdSucursal2.Visible = False
        '
        'gchpIdCajaIngreso
        '
        Me.gchpIdCajaIngreso.DataPropertyName = "IdCajaIngreso"
        Me.gchpIdCajaIngreso.HeaderText = "IdCajaIngreso"
        Me.gchpIdCajaIngreso.Name = "gchpIdCajaIngreso"
        Me.gchpIdCajaIngreso.ReadOnly = True
        Me.gchpIdCajaIngreso.Visible = False
        '
        'gchpIdCajaEgreso
        '
        Me.gchpIdCajaEgreso.DataPropertyName = "IdCajaEgreso"
        Me.gchpIdCajaEgreso.HeaderText = "IdCajaEgreso"
        Me.gchpIdCajaEgreso.Name = "gchpIdCajaEgreso"
        Me.gchpIdCajaEgreso.ReadOnly = True
        Me.gchpIdCajaEgreso.Visible = False
        '
        'FotoFrente1
        '
        Me.FotoFrente1.DataPropertyName = "FotoFrente"
        Me.FotoFrente1.HeaderText = "FotoFrente"
        Me.FotoFrente1.Name = "FotoFrente1"
        Me.FotoFrente1.ReadOnly = True
        Me.FotoFrente1.Visible = False
        '
        'FotoDorso1
        '
        Me.FotoDorso1.DataPropertyName = "FotoDorso"
        Me.FotoDorso1.HeaderText = "FotoDorso"
        Me.FotoDorso1.Name = "FotoDorso1"
        Me.FotoDorso1.ReadOnly = True
        Me.FotoDorso1.Visible = False
        '
        'CajaDetalleParaIngresoDirectoPorABM
        '
        Me.CajaDetalleParaIngresoDirectoPorABM.DataPropertyName = "CajaDetalleParaIngresoDirectoPorABM"
        Me.CajaDetalleParaIngresoDirectoPorABM.HeaderText = "CajaDetalleParaIngresoDirectoPorABM"
        Me.CajaDetalleParaIngresoDirectoPorABM.Name = "CajaDetalleParaIngresoDirectoPorABM"
        Me.CajaDetalleParaIngresoDirectoPorABM.ReadOnly = True
        Me.CajaDetalleParaIngresoDirectoPorABM.Visible = False
        '
        'IdCuentaCaja
        '
        Me.IdCuentaCaja.DataPropertyName = "IdCuentaDeCaja"
        Me.IdCuentaCaja.HeaderText = "IdCuentaCaja"
        Me.IdCuentaCaja.Name = "IdCuentaCaja"
        Me.IdCuentaCaja.ReadOnly = True
        Me.IdCuentaCaja.Visible = False
        '
        'IdProveedorPreasignado
        '
        Me.IdProveedorPreasignado.DataPropertyName = "IdProveedorPreasignado"
        Me.IdProveedorPreasignado.HeaderText = "IdProveedorReasignado"
        Me.IdProveedorPreasignado.Name = "IdProveedorPreasignado"
        Me.IdProveedorPreasignado.ReadOnly = True
        Me.IdProveedorPreasignado.Visible = False
        '
        'CodigoProveedorPreasignado
        '
        Me.CodigoProveedorPreasignado.DataPropertyName = "CodigoProveedorPreasignado"
        Me.CodigoProveedorPreasignado.HeaderText = "CodigoProveedorePreasignado"
        Me.CodigoProveedorPreasignado.Name = "CodigoProveedorPreasignado"
        Me.CodigoProveedorPreasignado.ReadOnly = True
        Me.CodigoProveedorPreasignado.Visible = False
        '
        'ProveedorPreasignado
        '
        Me.ProveedorPreasignado.DataPropertyName = "ProveedorPreasignado"
        Me.ProveedorPreasignado.HeaderText = "ProveedorPreasigando"
        Me.ProveedorPreasignado.Name = "ProveedorPreasignado"
        Me.ProveedorPreasignado.ReadOnly = True
        Me.ProveedorPreasignado.Visible = False
        '
        'Cuit
        '
        Me.Cuit.DataPropertyName = "Cuit"
        Me.Cuit.HeaderText = "Cuit"
        Me.Cuit.Name = "Cuit"
        Me.Cuit.ReadOnly = True
        Me.Cuit.Visible = False
        '
        'IdTipoCheque
        '
        Me.IdTipoCheque.DataPropertyName = "IdTipoCheque"
        Me.IdTipoCheque.HeaderText = "IdTipoCheque"
        Me.IdTipoCheque.Name = "IdTipoCheque"
        Me.IdTipoCheque.ReadOnly = True
        Me.IdTipoCheque.Visible = False
        '
        'btnInsertarChequePropio
        '
        Me.btnInsertarChequePropio.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsertarChequePropio.Image = Global.Eniac.Win.My.Resources.Resources.add_24
        Me.btnInsertarChequePropio.Location = New System.Drawing.Point(604, 11)
        Me.btnInsertarChequePropio.Name = "btnInsertarChequePropio"
        Me.btnInsertarChequePropio.Size = New System.Drawing.Size(84, 36)
        Me.btnInsertarChequePropio.TabIndex = 20
        Me.btnInsertarChequePropio.Text = "&Insertar"
        Me.btnInsertarChequePropio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarChequePropio.UseVisualStyleBackColor = True
        '
        'btnEliminarChequePropio
        '
        Me.btnEliminarChequePropio.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarChequePropio.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnEliminarChequePropio.Location = New System.Drawing.Point(694, 11)
        Me.btnEliminarChequePropio.Name = "btnEliminarChequePropio"
        Me.btnEliminarChequePropio.Size = New System.Drawing.Size(84, 36)
        Me.btnEliminarChequePropio.TabIndex = 21
        Me.btnEliminarChequePropio.Text = "&Eliminar"
        Me.btnEliminarChequePropio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarChequePropio.UseVisualStyleBackColor = True
        '
        'bscCuentaBancariaPropio
        '
        Me.bscCuentaBancariaPropio.AyudaAncho = 608
        Me.bscCuentaBancariaPropio.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaPropio.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaPropio.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaPropio.ColumnasAncho = Nothing
        Me.bscCuentaBancariaPropio.ColumnasFormato = Nothing
        Me.bscCuentaBancariaPropio.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaPropio.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaPropio.Datos = Nothing
        Me.bscCuentaBancariaPropio.FilaDevuelta = Nothing
        Me.bscCuentaBancariaPropio.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaPropio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaPropio.IsDecimal = False
        Me.bscCuentaBancariaPropio.IsNumber = False
        Me.bscCuentaBancariaPropio.IsPK = False
        Me.bscCuentaBancariaPropio.IsRequired = False
        Me.bscCuentaBancariaPropio.Key = ""
        Me.bscCuentaBancariaPropio.LabelAsoc = Nothing
        Me.bscCuentaBancariaPropio.Location = New System.Drawing.Point(5, 67)
        Me.bscCuentaBancariaPropio.MaxLengh = "32767"
        Me.bscCuentaBancariaPropio.Name = "bscCuentaBancariaPropio"
        Me.bscCuentaBancariaPropio.Permitido = True
        Me.bscCuentaBancariaPropio.Selecciono = False
        Me.bscCuentaBancariaPropio.Size = New System.Drawing.Size(125, 20)
        Me.bscCuentaBancariaPropio.TabIndex = 3
        Me.bscCuentaBancariaPropio.Titulo = "Clientes"
        '
        'txtIdCheque
        '
        Me.txtIdCheque.BindearPropiedadControl = ""
        Me.txtIdCheque.BindearPropiedadEntidad = ""
        Me.txtIdCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdCheque.Formato = ""
        Me.txtIdCheque.IsDecimal = False
        Me.txtIdCheque.IsNumber = True
        Me.txtIdCheque.IsPK = False
        Me.txtIdCheque.IsRequired = False
        Me.txtIdCheque.Key = ""
        Me.txtIdCheque.LabelAsoc = Nothing
        Me.txtIdCheque.Location = New System.Drawing.Point(733, 67)
        Me.txtIdCheque.MaxLength = 15
        Me.txtIdCheque.Name = "txtIdCheque"
        Me.txtIdCheque.Size = New System.Drawing.Size(45, 20)
        Me.txtIdCheque.TabIndex = 25
        Me.txtIdCheque.Visible = False
        '
        'grbCliente
        '
        Me.grbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbCliente.Controls.Add(Me.txtCotizacionDolar)
        Me.grbCliente.Controls.Add(Me.lblCotizacionDolar)
        Me.grbCliente.Controls.Add(Me.lblCaja)
        Me.grbCliente.Controls.Add(Me.cmbCajas)
        Me.grbCliente.Controls.Add(Me.lblFechaAplicacion)
        Me.grbCliente.Controls.Add(Me.dtpFechaAplicacion)
        Me.grbCliente.Controls.Add(Me.optFechaAplicacion)
        Me.grbCliente.Controls.Add(Me.optFechaCheque)
        Me.grbCliente.Controls.Add(Me.lblFechaAplicada)
        Me.grbCliente.Controls.Add(Me.lblCuentaBancariaDestino)
        Me.grbCliente.Controls.Add(Me.bscCuentaBancariaDestino)
        Me.grbCliente.Controls.Add(Me.lblObservacion)
        Me.grbCliente.Controls.Add(Me.txtObservacion)
        Me.grbCliente.Controls.Add(Me.lblFechaDeposito)
        Me.grbCliente.Controls.Add(Me.dtpFecha)
        Me.grbCliente.Location = New System.Drawing.Point(3, 39)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(795, 78)
        Me.grbCliente.TabIndex = 0
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Detalle"
        '
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.BackColor = System.Drawing.SystemColors.Window
        Me.txtCotizacionDolar.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolar.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolar.Formato = "##0.00"
        Me.txtCotizacionDolar.IsDecimal = True
        Me.txtCotizacionDolar.IsNumber = True
        Me.txtCotizacionDolar.IsPK = False
        Me.txtCotizacionDolar.IsRequired = False
        Me.txtCotizacionDolar.Key = ""
        Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(727, 50)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(59, 20)
        Me.txtCotizacionDolar.TabIndex = 14
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.AutoSize = True
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCotizacionDolar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(669, 54)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(64, 13)
        Me.lblCotizacionDolar.TabIndex = 13
        Me.lblCotizacionDolar.Text = "Dólar Cotiz. "
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(629, 22)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 6
        Me.lblCaja.Text = "Caja"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = ""
        Me.cmbCajas.BindearPropiedadEntidad = ""
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCaja
        Me.cmbCajas.Location = New System.Drawing.Point(661, 18)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
        Me.cmbCajas.TabIndex = 7
        '
        'lblFechaAplicacion
        '
        Me.lblFechaAplicacion.AutoSize = True
        Me.lblFechaAplicacion.LabelAsoc = Nothing
        Me.lblFechaAplicacion.Location = New System.Drawing.Point(470, 22)
        Me.lblFechaAplicacion.Name = "lblFechaAplicacion"
        Me.lblFechaAplicacion.Size = New System.Drawing.Size(56, 13)
        Me.lblFechaAplicacion.TabIndex = 4
        Me.lblFechaAplicacion.Text = "Aplicacion"
        '
        'dtpFechaAplicacion
        '
        Me.dtpFechaAplicacion.BindearPropiedadControl = Nothing
        Me.dtpFechaAplicacion.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAplicacion.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAplicacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaAplicacion.IsPK = False
        Me.dtpFechaAplicacion.IsRequired = False
        Me.dtpFechaAplicacion.Key = ""
        Me.dtpFechaAplicacion.LabelAsoc = Me.lblFechaAplicacion
        Me.dtpFechaAplicacion.Location = New System.Drawing.Point(528, 18)
        Me.dtpFechaAplicacion.Name = "dtpFechaAplicacion"
        Me.dtpFechaAplicacion.Size = New System.Drawing.Size(84, 20)
        Me.dtpFechaAplicacion.TabIndex = 5
        '
        'optFechaAplicacion
        '
        Me.optFechaAplicacion.AutoSize = True
        Me.optFechaAplicacion.BindearPropiedadControl = Nothing
        Me.optFechaAplicacion.BindearPropiedadEntidad = Nothing
        Me.optFechaAplicacion.Checked = True
        Me.optFechaAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.optFechaAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optFechaAplicacion.IsPK = False
        Me.optFechaAplicacion.IsRequired = False
        Me.optFechaAplicacion.Key = Nothing
        Me.optFechaAplicacion.LabelAsoc = Nothing
        Me.optFechaAplicacion.Location = New System.Drawing.Point(146, 52)
        Me.optFechaAplicacion.Name = "optFechaAplicacion"
        Me.optFechaAplicacion.Size = New System.Drawing.Size(107, 17)
        Me.optFechaAplicacion.TabIndex = 9
        Me.optFechaAplicacion.TabStop = True
        Me.optFechaAplicacion.Text = "Fecha Aplicación"
        Me.optFechaAplicacion.UseVisualStyleBackColor = True
        '
        'optFechaCheque
        '
        Me.optFechaCheque.AutoSize = True
        Me.optFechaCheque.BindearPropiedadControl = Nothing
        Me.optFechaCheque.BindearPropiedadEntidad = Nothing
        Me.optFechaCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.optFechaCheque.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optFechaCheque.IsPK = False
        Me.optFechaCheque.IsRequired = False
        Me.optFechaCheque.Key = Nothing
        Me.optFechaCheque.LabelAsoc = Nothing
        Me.optFechaCheque.Location = New System.Drawing.Point(262, 52)
        Me.optFechaCheque.Name = "optFechaCheque"
        Me.optFechaCheque.Size = New System.Drawing.Size(95, 17)
        Me.optFechaCheque.TabIndex = 10
        Me.optFechaCheque.Text = "Fecha Cheque"
        Me.optFechaCheque.UseVisualStyleBackColor = True
        '
        'lblFechaAplicada
        '
        Me.lblFechaAplicada.AutoSize = True
        Me.lblFechaAplicada.LabelAsoc = Nothing
        Me.lblFechaAplicada.Location = New System.Drawing.Point(15, 54)
        Me.lblFechaAplicada.Name = "lblFechaAplicada"
        Me.lblFechaAplicada.Size = New System.Drawing.Size(126, 13)
        Me.lblFechaAplicada.TabIndex = 8
        Me.lblFechaAplicada.Text = "Acreditacion de Cheques"
        '
        'lblCuentaBancariaDestino
        '
        Me.lblCuentaBancariaDestino.AutoSize = True
        Me.lblCuentaBancariaDestino.LabelAsoc = Nothing
        Me.lblCuentaBancariaDestino.Location = New System.Drawing.Point(10, 22)
        Me.lblCuentaBancariaDestino.Name = "lblCuentaBancariaDestino"
        Me.lblCuentaBancariaDestino.Size = New System.Drawing.Size(86, 13)
        Me.lblCuentaBancariaDestino.TabIndex = 0
        Me.lblCuentaBancariaDestino.Text = "Cuenta Bancaria"
        '
        'bscCuentaBancariaDestino
        '
        Me.bscCuentaBancariaDestino.ActivarFiltroEnGrilla = True
        Me.bscCuentaBancariaDestino.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaDestino.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaDestino.ConfigBuscador = Nothing
        Me.bscCuentaBancariaDestino.Datos = Nothing
        Me.bscCuentaBancariaDestino.FilaDevuelta = Nothing
        Me.bscCuentaBancariaDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaDestino.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaDestino.IsDecimal = False
        Me.bscCuentaBancariaDestino.IsNumber = False
        Me.bscCuentaBancariaDestino.IsPK = False
        Me.bscCuentaBancariaDestino.IsRequired = False
        Me.bscCuentaBancariaDestino.Key = ""
        Me.bscCuentaBancariaDestino.LabelAsoc = Me.lblCuentaBancariaDestino
        Me.bscCuentaBancariaDestino.Location = New System.Drawing.Point(98, 18)
        Me.bscCuentaBancariaDestino.MaxLengh = "32767"
        Me.bscCuentaBancariaDestino.Name = "bscCuentaBancariaDestino"
        Me.bscCuentaBancariaDestino.Permitido = True
        Me.bscCuentaBancariaDestino.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCuentaBancariaDestino.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancariaDestino.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCuentaBancariaDestino.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancariaDestino.Selecciono = False
        Me.bscCuentaBancariaDestino.Size = New System.Drawing.Size(209, 20)
        Me.bscCuentaBancariaDestino.TabIndex = 1
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(365, 54)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 11
        Me.lblObservacion.Text = "Observación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtObservacion
        '
        Me.txtObservacion.BindearPropiedadControl = Nothing
        Me.txtObservacion.BindearPropiedadEntidad = Nothing
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = ""
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = ""
        Me.txtObservacion.LabelAsoc = Me.lblObservacion
        Me.txtObservacion.Location = New System.Drawing.Point(436, 50)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(233, 20)
        Me.txtObservacion.TabIndex = 12
        '
        'lblFechaDeposito
        '
        Me.lblFechaDeposito.AutoSize = True
        Me.lblFechaDeposito.LabelAsoc = Nothing
        Me.lblFechaDeposito.Location = New System.Drawing.Point(316, 22)
        Me.lblFechaDeposito.Name = "lblFechaDeposito"
        Me.lblFechaDeposito.Size = New System.Drawing.Size(57, 13)
        Me.lblFechaDeposito.TabIndex = 2
        Me.lblFechaDeposito.Text = "Extracción"
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = Nothing
        Me.dtpFecha.BindearPropiedadEntidad = Nothing
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFechaDeposito
        Me.dtpFecha.Location = New System.Drawing.Point(376, 18)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(84, 20)
        Me.dtpFecha.TabIndex = 3
        '
        'tspFacturacion
        '
        Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.tspFacturacion.Name = "tspFacturacion"
        Me.tspFacturacion.Size = New System.Drawing.Size(804, 31)
        Me.tspFacturacion.TabIndex = 14
        Me.tspFacturacion.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.Eniac.Win.My.Resources.Resources.document_add
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(70, 28)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(151, 28)
        Me.tsbGrabar.Text = "&Grabar e Imprimir (F4)"
        Me.tsbGrabar.ToolTipText = "Grabar e Imprimir (F4)"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(67, 28)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'ExtraccionesBancarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(804, 426)
        Me.Controls.Add(Me.txtTotalTickets)
        Me.Controls.Add(Me.lblTotalTickets)
        Me.Controls.Add(Me.txtTotalTarjeta)
        Me.Controls.Add(Me.lblTotalTarjeta)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.txtTotalEfectivo)
        Me.Controls.Add(Me.lblTotalEfectivo)
        Me.Controls.Add(Me.txtTotalCheqPropios)
        Me.Controls.Add(Me.lblChequesPropios)
        Me.Controls.Add(Me.txtTotalCheqTerceros)
        Me.Controls.Add(Me.lblChequesTerceros)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Controls.Add(Me.grbCliente)
        Me.Controls.Add(Me.tspFacturacion)
        Me.KeyPreview = True
        Me.Name = "ExtraccionesBancarias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extracciones Bancarias"
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpDepositos2.ResumeLayout(False)
        Me.grbChequesPropios.ResumeLayout(False)
        Me.grbChequesPropios.PerformLayout()
        CType(Me.dgvChequesPropios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.tspFacturacion.ResumeLayout(False)
        Me.tspFacturacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents tbpDepositos2 As System.Windows.Forms.TabPage
   Friend WithEvents dgvChequesPropios As Eniac.Controles.DataGridView
   Friend WithEvents btnEliminarChequePropio As Eniac.Controles.Button
   Friend WithEvents btnInsertarChequePropio As Eniac.Controles.Button
   Friend WithEvents grbChequesPropios As System.Windows.Forms.GroupBox
   Friend WithEvents lblBancoPropio As Eniac.Controles.Label
   Friend WithEvents lblCuentaBancariaPropio As Eniac.Controles.Label
   Friend WithEvents lblNroChequePropio As Eniac.Controles.Label
   Friend WithEvents lblImporteChequePropio As Eniac.Controles.Label
   Friend WithEvents txtCodPostalChequePropio As Eniac.Controles.TextBox
   Friend WithEvents lblCodPostalPropio As Eniac.Controles.Label
   Friend WithEvents dtpFechaCobroPropio As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCobroPropio As Eniac.Controles.Label
   Friend WithEvents txtNroChequePropio As Eniac.Controles.TextBox
   Friend WithEvents txtImporteChequePropio As Eniac.Controles.TextBox
   Friend WithEvents dtpFechaEmisionPropio As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaEmisionPropio As Eniac.Controles.Label
   Friend WithEvents lblSucursalPropio As Eniac.Controles.Label
   Friend WithEvents txtSucursalBancoPropio As Eniac.Controles.TextBox
   Friend WithEvents bscCuentaBancariaPropio As Eniac.Controles.Buscador
   Friend WithEvents cmbBancoPropio As Eniac.Controles.ComboBox
   Friend WithEvents lblFechaDeposito As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents txtTotalEfectivo As Eniac.Controles.TextBox
   Friend WithEvents lblTotalEfectivo As Eniac.Controles.Label
   Friend WithEvents txtTotalCheqPropios As Eniac.Controles.TextBox
   Friend WithEvents lblChequesPropios As Eniac.Controles.Label
   Friend WithEvents txtTotalCheqTerceros As Eniac.Controles.TextBox
   Friend WithEvents lblChequesTerceros As Eniac.Controles.Label
   Friend WithEvents lblCuentaBancariaDestino As Eniac.Controles.Label
   Friend WithEvents bscCuentaBancariaDestino As Eniac.Controles.Buscador2
   Friend WithEvents lblFechaAplicada As Eniac.Controles.Label
   Friend WithEvents optFechaCheque As Eniac.Controles.RadioButton
   Friend WithEvents optFechaAplicacion As Eniac.Controles.RadioButton
   Friend WithEvents txtTotalTarjeta As Eniac.Controles.TextBox
   Friend WithEvents lblTotalTarjeta As Eniac.Controles.Label
   Friend WithEvents lblFechaAplicacion As Eniac.Controles.Label
   Friend WithEvents dtpFechaAplicacion As Eniac.Controles.DateTimePicker
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents txtTotalTickets As Eniac.Controles.TextBox
   Friend WithEvents lblTotalTickets As Eniac.Controles.Label
   Friend WithEvents txtNroOperacion As Eniac.Controles.TextBox
   Friend WithEvents lblNroOperacion As System.Windows.Forms.Label
   Friend WithEvents lblTipoCheque As Eniac.Controles.Label
   Friend WithEvents cmbTipoCheque As Eniac.Controles.ComboBox
    Friend WithEvents bscCuentaBancariaPropiaCodigo As Eniac.Controles.Buscador
    Friend WithEvents IdSucursal As DataGridViewTextBoxColumn
    Friend WithEvents IdCheque As DataGridViewTextBoxColumn
    Friend WithEvents NombreTipoCheque As DataGridViewTextBoxColumn
    Friend WithEvents CuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents IdCuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents NombreCuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents Banco As DataGridViewTextBoxColumn
    Friend WithEvents IdBanco As DataGridViewTextBoxColumn
    Friend WithEvents BancoNombre As DataGridViewTextBoxColumn
    Friend WithEvents Sucursal As DataGridViewTextBoxColumn
    Friend WithEvents CP As DataGridViewTextBoxColumn
    Friend WithEvents Localidad As DataGridViewTextBoxColumn
    Friend WithEvents NumeroCheque As DataGridViewTextBoxColumn
    Friend WithEvents NroOperacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaEmision As DataGridViewTextBoxColumn
    Friend WithEvents FechaCobro As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents NroPlanillaRecibo As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents NroMovimientoRecibo As DataGridViewTextBoxColumn
    Friend WithEvents NroPlanillaEntregado As DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As DataGridViewTextBoxColumn
    Friend WithEvents NroMovimientoEntregado As DataGridViewTextBoxColumn
    Friend WithEvents Usuario As DataGridViewTextBoxColumn
    Friend WithEvents Password As DataGridViewTextBoxColumn
    Friend WithEvents EsPropio As DataGridViewTextBoxColumn
    Friend WithEvents Titular2 As DataGridViewTextBoxColumn
    Friend WithEvents IdEstadoCheque As DataGridViewTextBoxColumn
    Friend WithEvents IdEstadoChequeAnt As DataGridViewTextBoxColumn
    Friend WithEvents RowState As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdSucursal2 As DataGridViewTextBoxColumn
    Friend WithEvents gchpIdCajaIngreso As DataGridViewTextBoxColumn
    Friend WithEvents gchpIdCajaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents FotoFrente1 As DataGridViewTextBoxColumn
    Friend WithEvents FotoDorso1 As DataGridViewTextBoxColumn
    Friend WithEvents CajaDetalleParaIngresoDirectoPorABM As DataGridViewTextBoxColumn
    Friend WithEvents IdCuentaCaja As DataGridViewTextBoxColumn
    Friend WithEvents IdProveedorPreasignado As DataGridViewTextBoxColumn
    Friend WithEvents CodigoProveedorPreasignado As DataGridViewTextBoxColumn
    Friend WithEvents ProveedorPreasignado As DataGridViewTextBoxColumn
    Friend WithEvents Cuit As DataGridViewTextBoxColumn
    Friend WithEvents IdTipoCheque As DataGridViewTextBoxColumn
    Friend WithEvents txtIdCheque As Controles.TextBox
    Friend WithEvents txtCotizacionDolar As Controles.TextBox
    Friend WithEvents lblCotizacionDolar As Controles.Label
End Class
