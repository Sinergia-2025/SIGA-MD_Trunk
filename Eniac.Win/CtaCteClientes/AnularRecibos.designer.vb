<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnularRecibos
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnularRecibos))
        Me.tbcDetalle = New System.Windows.Forms.TabControl()
        Me.tbpComprobantes = New System.Windows.Forms.TabPage()
        Me.dgvComprobantes = New Eniac.Controles.DataGridView()
        Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargoPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaCorriente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobante1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormasPagoDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpPagos = New System.Windows.Forms.TabPage()
        Me.dtpFechaTransferencia = New Eniac.Controles.DateTimePicker()
        Me.lblTransferenciaBancaria = New Eniac.Controles.Label()
        Me.lblFechaTransferencia = New Eniac.Controles.Label()
        Me.bscCuentaBancariaTransfBanc = New Eniac.Controles.Buscador()
        Me.tbcDetalle2 = New System.Windows.Forms.TabControl()
        Me.tbpCheques = New System.Windows.Forms.TabPage()
        Me.dgvCheques = New Eniac.Controles.DataGridView()
        Me.gchIdBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchNombreBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchIdBancoSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchCP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchNumeroCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchFechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchFechaCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchTitular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchClienteTipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchClienteNroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchNroPlanillaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchNroMovimientoIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchNroPlanillaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchNroMovimientoEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchIdCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchNombreCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchEsPropio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchIdEstadoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchIdEstadoChequeAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchRowState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchIdSucursal2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCajaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCajaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FotoFrente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FotoDorso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProveedorPreasignado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoProveedorPreasignado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProveedorPreasignado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CajaDetalleParaIngresoDirectoPorABM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCuentaDeCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpRetenciones = New System.Windows.Forms.TabPage()
        Me.dgvRetenciones = New Eniac.Controles.DataGridView()
        Me.gretIdTipoImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretNombreTipoImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretEmisorRetencion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretNumeroRetencion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretFechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretBaseImponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretAlicuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretClienteTipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretClienteNroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretTipoImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretNroPlanillaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretNroMovimientoIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretIdEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretRowState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretIdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretLetraComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretEmisorComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretNumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretFechaComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gretImporteComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRetenciones = New Eniac.Controles.Label()
        Me.txtRetenciones = New Eniac.Controles.TextBox()
        Me.txtTransferenciaBancaria = New Eniac.Controles.TextBox()
        Me.lblCheques = New Eniac.Controles.Label()
        Me.txtCheques = New Eniac.Controles.TextBox()
        Me.lblTarjetas = New Eniac.Controles.Label()
        Me.txtTarjetas = New Eniac.Controles.TextBox()
        Me.lblEfectivo = New Eniac.Controles.Label()
        Me.txtEfectivo = New Eniac.Controles.TextBox()
        Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.chbNroOrdenDeCompra = New Eniac.Controles.CheckBox()
        Me.bscNroOrdenDeCompra = New Eniac.Controles.Buscador2()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.dtpFechaEmision = New Eniac.Controles.DateTimePicker()
        Me.cmbTiposComprobantesRec = New Eniac.Controles.ComboBox()
        Me.lblTipoComprobanteRec = New Eniac.Controles.Label()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.txtNombreVendedor = New Eniac.Controles.TextBox()
        Me.lblLocalidad = New Eniac.Controles.Label()
        Me.lblNombreVendedor = New System.Windows.Forms.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.txtNombreCliente = New Eniac.Controles.TextBox()
        Me.lblNombreCliente = New Eniac.Controles.Label()
        Me.txtCodigoCliente = New Eniac.Controles.TextBox()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.lblEmisorRecibo = New Eniac.Controles.Label()
        Me.txtEmisor = New Eniac.Controles.TextBox()
        Me.lblLetra = New Eniac.Controles.Label()
        Me.txtLetra = New Eniac.Controles.TextBox()
        Me.lblNroRecibo = New Eniac.Controles.Label()
        Me.txtNroRecibo = New Eniac.Controles.TextBox()
        Me.lblObservacion = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTotalNCND = New Eniac.Controles.TextBox()
        Me.lblTotalNCND = New Eniac.Controles.Label()
        Me.txtSaldoActual = New Eniac.Controles.TextBox()
        Me.lblSaldoActual = New Eniac.Controles.Label()
        Me.txtDiferencia = New Eniac.Controles.TextBox()
        Me.lblDiferencia = New Eniac.Controles.Label()
        Me.txtComprobantes = New Eniac.Controles.TextBox()
        Me.lblBruto = New Eniac.Controles.Label()
        Me.txtTotalPago = New Eniac.Controles.TextBox()
        Me.lblTotal = New Eniac.Controles.Label()
        Me.Label5 = New Eniac.Controles.Label()
        Me.txtCategoriaFiscal = New Eniac.Controles.TextBox()
        Me.lblCategoriaFiscal = New System.Windows.Forms.Label()
        Me.txtLocalidad = New Eniac.Controles.TextBox()
        Me.txtDireccion = New Eniac.Controles.TextBox()
        Me.lblDireccion = New Eniac.Controles.Label()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbcDetalle.SuspendLayout()
        Me.tbpComprobantes.SuspendLayout()
        CType(Me.dgvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpPagos.SuspendLayout()
        Me.tbcDetalle2.SuspendLayout()
        Me.tbpCheques.SuspendLayout()
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpRetenciones.SuspendLayout()
        CType(Me.dgvRetenciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCliente.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tspFacturacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle.Controls.Add(Me.tbpComprobantes)
        Me.tbcDetalle.Controls.Add(Me.tbpPagos)
        Me.tbcDetalle.Location = New System.Drawing.Point(3, 225)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(957, 288)
        Me.tbcDetalle.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.tbcDetalle.TabIndex = 1
        Me.tbcDetalle.TabStop = False
        '
        'tbpComprobantes
        '
        Me.tbpComprobantes.BackColor = System.Drawing.SystemColors.Control
        Me.tbpComprobantes.Controls.Add(Me.dgvComprobantes)
        Me.tbpComprobantes.ImageKey = "form_blue.ico"
        Me.tbpComprobantes.Location = New System.Drawing.Point(4, 22)
        Me.tbpComprobantes.Name = "tbpComprobantes"
        Me.tbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpComprobantes.Size = New System.Drawing.Size(949, 262)
        Me.tbpComprobantes.TabIndex = 0
        Me.tbpComprobantes.Text = "Comprobantes"
        '
        'dgvComprobantes
        '
        Me.dgvComprobantes.AllowUserToAddRows = False
        Me.dgvComprobantes.AllowUserToDeleteRows = False
        Me.dgvComprobantes.AllowUserToResizeRows = False
        Me.dgvComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprobantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoComprobante, Me.letra, Me.CentroEmisor, Me.NroComprobante, Me.Cuota, Me.FechaEmision, Me.FechaVencimiento, Me.Importe, Me.Stock, Me.Paga, Me.DescuentoRecargoPorc, Me.DescuentoRecargo, Me.Usuario, Me.Password, Me.IdSucursal, Me.CuentaCorriente, Me.TipoComprobante1, Me.FormaPago, Me.FormasPagoDescripcion})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvComprobantes.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvComprobantes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComprobantes.Location = New System.Drawing.Point(3, 6)
        Me.dgvComprobantes.MultiSelect = False
        Me.dgvComprobantes.Name = "dgvComprobantes"
        Me.dgvComprobantes.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprobantes.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvComprobantes.RowHeadersWidth = 20
        Me.dgvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComprobantes.Size = New System.Drawing.Size(883, 225)
        Me.dgvComprobantes.TabIndex = 9
        '
        'TipoComprobante
        '
        Me.TipoComprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.TipoComprobante.HeaderText = "Tipo"
        Me.TipoComprobante.Name = "TipoComprobante"
        Me.TipoComprobante.ReadOnly = True
        '
        'letra
        '
        Me.letra.DataPropertyName = "Letra"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.letra.DefaultCellStyle = DataGridViewCellStyle2
        Me.letra.HeaderText = "Letra"
        Me.letra.Name = "letra"
        Me.letra.ReadOnly = True
        Me.letra.Width = 50
        '
        'CentroEmisor
        '
        Me.CentroEmisor.DataPropertyName = "CentroEmisor"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
        Me.CentroEmisor.HeaderText = "Emisor"
        Me.CentroEmisor.Name = "CentroEmisor"
        Me.CentroEmisor.ReadOnly = True
        Me.CentroEmisor.Width = 50
        '
        'NroComprobante
        '
        Me.NroComprobante.DataPropertyName = "NumeroComprobante"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroComprobante.DefaultCellStyle = DataGridViewCellStyle4
        Me.NroComprobante.HeaderText = "Numero"
        Me.NroComprobante.Name = "NroComprobante"
        Me.NroComprobante.ReadOnly = True
        Me.NroComprobante.Width = 70
        '
        'Cuota
        '
        Me.Cuota.DataPropertyName = "Cuota"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cuota.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cuota.HeaderText = "Cuota"
        Me.Cuota.Name = "Cuota"
        Me.Cuota.ReadOnly = True
        Me.Cuota.Width = 50
        '
        'FechaEmision
        '
        Me.FechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "dd/MM/yyyy"
        Me.FechaEmision.DefaultCellStyle = DataGridViewCellStyle6
        Me.FechaEmision.HeaderText = "Emision"
        Me.FechaEmision.Name = "FechaEmision"
        Me.FechaEmision.ReadOnly = True
        Me.FechaEmision.Width = 75
        '
        'FechaVencimiento
        '
        Me.FechaVencimiento.DataPropertyName = "FechaVencimiento"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "dd/MM/yyyy"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle7
        Me.FechaVencimiento.HeaderText = "Vence"
        Me.FechaVencimiento.Name = "FechaVencimiento"
        Me.FechaVencimiento.ReadOnly = True
        Me.FechaVencimiento.Width = 75
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "ImporteCuota"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle8
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 75
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "SaldoCuota"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle9
        Me.Stock.HeaderText = "Saldo"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 75
        '
        'Paga
        '
        Me.Paga.DataPropertyName = "Paga"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.Paga.DefaultCellStyle = DataGridViewCellStyle10
        Me.Paga.HeaderText = "Paga"
        Me.Paga.Name = "Paga"
        Me.Paga.ReadOnly = True
        Me.Paga.Width = 75
        '
        'DescuentoRecargoPorc
        '
        Me.DescuentoRecargoPorc.DataPropertyName = "DescuentoRecargoPorc"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.DescuentoRecargoPorc.DefaultCellStyle = DataGridViewCellStyle11
        Me.DescuentoRecargoPorc.HeaderText = "% D/R"
        Me.DescuentoRecargoPorc.Name = "DescuentoRecargoPorc"
        Me.DescuentoRecargoPorc.ReadOnly = True
        Me.DescuentoRecargoPorc.Width = 65
        '
        'DescuentoRecargo
        '
        Me.DescuentoRecargo.DataPropertyName = "DescuentoRecargo"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        Me.DescuentoRecargo.DefaultCellStyle = DataGridViewCellStyle12
        Me.DescuentoRecargo.HeaderText = "$ D/R"
        Me.DescuentoRecargo.Name = "DescuentoRecargo"
        Me.DescuentoRecargo.ReadOnly = True
        Me.DescuentoRecargo.Width = 65
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
        Me.Password.HeaderText = "Password"
        Me.Password.Name = "Password"
        Me.Password.ReadOnly = True
        Me.Password.Visible = False
        '
        'IdSucursal
        '
        Me.IdSucursal.DataPropertyName = "IdSucursal"
        Me.IdSucursal.HeaderText = "IdSucursal"
        Me.IdSucursal.Name = "IdSucursal"
        Me.IdSucursal.ReadOnly = True
        Me.IdSucursal.Visible = False
        '
        'CuentaCorriente
        '
        Me.CuentaCorriente.DataPropertyName = "CuentaCorriente"
        Me.CuentaCorriente.HeaderText = "CuentaCorriente"
        Me.CuentaCorriente.Name = "CuentaCorriente"
        Me.CuentaCorriente.ReadOnly = True
        Me.CuentaCorriente.Visible = False
        '
        'TipoComprobante1
        '
        Me.TipoComprobante1.DataPropertyName = "TipoComprobante"
        Me.TipoComprobante1.HeaderText = "TipoComprobante"
        Me.TipoComprobante1.Name = "TipoComprobante1"
        Me.TipoComprobante1.ReadOnly = True
        Me.TipoComprobante1.Visible = False
        '
        'FormaPago
        '
        Me.FormaPago.DataPropertyName = "FormaPago"
        Me.FormaPago.HeaderText = "FormaPago"
        Me.FormaPago.Name = "FormaPago"
        Me.FormaPago.ReadOnly = True
        Me.FormaPago.Visible = False
        '
        'FormasPagoDescripcion
        '
        Me.FormasPagoDescripcion.DataPropertyName = "FormasPagoDescripcion"
        Me.FormasPagoDescripcion.HeaderText = "FormasPagoDescripcion"
        Me.FormasPagoDescripcion.Name = "FormasPagoDescripcion"
        Me.FormasPagoDescripcion.ReadOnly = True
        Me.FormasPagoDescripcion.Visible = False
        '
        'tbpPagos
        '
        Me.tbpPagos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPagos.Controls.Add(Me.dtpFechaTransferencia)
        Me.tbpPagos.Controls.Add(Me.lblFechaTransferencia)
        Me.tbpPagos.Controls.Add(Me.bscCuentaBancariaTransfBanc)
        Me.tbpPagos.Controls.Add(Me.tbcDetalle2)
        Me.tbpPagos.Controls.Add(Me.lblRetenciones)
        Me.tbpPagos.Controls.Add(Me.txtRetenciones)
        Me.tbpPagos.Controls.Add(Me.lblTransferenciaBancaria)
        Me.tbpPagos.Controls.Add(Me.txtTransferenciaBancaria)
        Me.tbpPagos.Controls.Add(Me.lblCheques)
        Me.tbpPagos.Controls.Add(Me.txtCheques)
        Me.tbpPagos.Controls.Add(Me.lblTarjetas)
        Me.tbpPagos.Controls.Add(Me.txtTarjetas)
        Me.tbpPagos.Controls.Add(Me.lblEfectivo)
        Me.tbpPagos.Controls.Add(Me.txtEfectivo)
        Me.tbpPagos.ImageKey = "money2.ico"
        Me.tbpPagos.Location = New System.Drawing.Point(4, 22)
        Me.tbpPagos.Name = "tbpPagos"
        Me.tbpPagos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPagos.Size = New System.Drawing.Size(949, 262)
        Me.tbpPagos.TabIndex = 1
        Me.tbpPagos.Text = "Pagos"
        '
        'dtpFechaTransferencia
        '
        Me.dtpFechaTransferencia.BindearPropiedadControl = Nothing
        Me.dtpFechaTransferencia.BindearPropiedadEntidad = Nothing
        Me.dtpFechaTransferencia.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaTransferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaTransferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaTransferencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaTransferencia.IsPK = False
        Me.dtpFechaTransferencia.IsRequired = False
        Me.dtpFechaTransferencia.Key = ""
        Me.dtpFechaTransferencia.LabelAsoc = Me.lblTransferenciaBancaria
        Me.dtpFechaTransferencia.Location = New System.Drawing.Point(580, 23)
        Me.dtpFechaTransferencia.Name = "dtpFechaTransferencia"
        Me.dtpFechaTransferencia.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaTransferencia.TabIndex = 34
        '
        'lblTransferenciaBancaria
        '
        Me.lblTransferenciaBancaria.AutoSize = True
        Me.lblTransferenciaBancaria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTransferenciaBancaria.LabelAsoc = Nothing
        Me.lblTransferenciaBancaria.Location = New System.Drawing.Point(230, 26)
        Me.lblTransferenciaBancaria.Name = "lblTransferenciaBancaria"
        Me.lblTransferenciaBancaria.Size = New System.Drawing.Size(71, 13)
        Me.lblTransferenciaBancaria.TabIndex = 4
        Me.lblTransferenciaBancaria.Text = "Transf. Banc."
        '
        'lblFechaTransferencia
        '
        Me.lblFechaTransferencia.AutoSize = True
        Me.lblFechaTransferencia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaTransferencia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFechaTransferencia.LabelAsoc = Nothing
        Me.lblFechaTransferencia.Location = New System.Drawing.Point(577, 7)
        Me.lblFechaTransferencia.Name = "lblFechaTransferencia"
        Me.lblFechaTransferencia.Size = New System.Drawing.Size(105, 13)
        Me.lblFechaTransferencia.TabIndex = 33
        Me.lblFechaTransferencia.Text = "Fecha Transferencia"
        '
        'bscCuentaBancariaTransfBanc
        '
        Me.bscCuentaBancariaTransfBanc.AyudaAncho = 608
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaTransfBanc.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaTransfBanc.ColumnasAncho = Nothing
        Me.bscCuentaBancariaTransfBanc.ColumnasFormato = Nothing
        Me.bscCuentaBancariaTransfBanc.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaTransfBanc.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCuentaBancariaTransfBanc.Enabled = False
        Me.bscCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCuentaBancariaTransfBanc.IsPK = False
        Me.bscCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCuentaBancariaTransfBanc.Key = ""
        Me.bscCuentaBancariaTransfBanc.LabelAsoc = Nothing
        Me.bscCuentaBancariaTransfBanc.Location = New System.Drawing.Point(371, 22)
        Me.bscCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCuentaBancariaTransfBanc.Name = "bscCuentaBancariaTransfBanc"
        Me.bscCuentaBancariaTransfBanc.Permitido = True
        Me.bscCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCuentaBancariaTransfBanc.Size = New System.Drawing.Size(200, 20)
        Me.bscCuentaBancariaTransfBanc.TabIndex = 13
        Me.bscCuentaBancariaTransfBanc.Titulo = "Clientes"
        '
        'tbcDetalle2
        '
        Me.tbcDetalle2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle2.Controls.Add(Me.tbpCheques)
        Me.tbcDetalle2.Controls.Add(Me.tbpRetenciones)
        Me.tbcDetalle2.Location = New System.Drawing.Point(2, 50)
        Me.tbcDetalle2.Name = "tbcDetalle2"
        Me.tbcDetalle2.SelectedIndex = 0
        Me.tbcDetalle2.Size = New System.Drawing.Size(941, 207)
        Me.tbcDetalle2.TabIndex = 12
        '
        'tbpCheques
        '
        Me.tbpCheques.Controls.Add(Me.dgvCheques)
        Me.tbpCheques.Location = New System.Drawing.Point(4, 22)
        Me.tbpCheques.Name = "tbpCheques"
        Me.tbpCheques.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCheques.Size = New System.Drawing.Size(933, 181)
        Me.tbpCheques.TabIndex = 0
        Me.tbpCheques.Text = "Cheques"
        Me.tbpCheques.UseVisualStyleBackColor = True
        '
        'dgvCheques
        '
        Me.dgvCheques.AllowUserToAddRows = False
        Me.dgvCheques.AllowUserToDeleteRows = False
        Me.dgvCheques.AllowUserToResizeRows = False
        Me.dgvCheques.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gchIdBanco, Me.gchNombreBanco, Me.gchIdBancoSucursal, Me.gchCP, Me.gchNumeroCheque, Me.gchLocalidad, Me.gchFechaEmision, Me.gchFechaCobro, Me.gchTitular, Me.CUIT, Me.gchImporte, Me.gchClienteTipoDocumento, Me.gchClienteNroDocumento, Me.gchBanco, Me.gchNroPlanillaIngreso, Me.gchNroMovimientoIngreso, Me.gchNroPlanillaEgreso, Me.gchNroMovimientoEgreso, Me.gchUsuario, Me.gchPassword, Me.gchIdSucursal, Me.gchCliente, Me.gchCuentaBancaria, Me.gchIdCuentaBancaria, Me.gchNombreCuentaBancaria, Me.gchEsPropio, Me.gchIdEstadoCheque, Me.gchIdEstadoChequeAnt, Me.gchProveedor, Me.gchRowState, Me.gchIdSucursal2, Me.IdCajaIngreso, Me.IdCajaEgreso, Me.FotoFrente, Me.FotoDorso, Me.IdProveedorPreasignado, Me.CodigoProveedorPreasignado, Me.ProveedorPreasignado, Me.CajaDetalleParaIngresoDirectoPorABM, Me.IdCuentaDeCaja})
        Me.dgvCheques.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCheques.Location = New System.Drawing.Point(4, 6)
        Me.dgvCheques.MultiSelect = False
        Me.dgvCheques.Name = "dgvCheques"
        Me.dgvCheques.ReadOnly = True
        Me.dgvCheques.RowHeadersVisible = False
        Me.dgvCheques.RowHeadersWidth = 20
        Me.dgvCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCheques.Size = New System.Drawing.Size(926, 169)
        Me.dgvCheques.TabIndex = 38
        '
        'gchIdBanco
        '
        Me.gchIdBanco.DataPropertyName = "IdBanco"
        Me.gchIdBanco.HeaderText = "IdBanco"
        Me.gchIdBanco.Name = "gchIdBanco"
        Me.gchIdBanco.ReadOnly = True
        Me.gchIdBanco.Visible = False
        '
        'gchNombreBanco
        '
        Me.gchNombreBanco.DataPropertyName = "NombreBanco"
        Me.gchNombreBanco.HeaderText = "Nombre Banco"
        Me.gchNombreBanco.Name = "gchNombreBanco"
        Me.gchNombreBanco.ReadOnly = True
        Me.gchNombreBanco.Width = 150
        '
        'gchIdBancoSucursal
        '
        Me.gchIdBancoSucursal.DataPropertyName = "IdBancoSucursal"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gchIdBancoSucursal.DefaultCellStyle = DataGridViewCellStyle15
        Me.gchIdBancoSucursal.HeaderText = "Suc."
        Me.gchIdBancoSucursal.Name = "gchIdBancoSucursal"
        Me.gchIdBancoSucursal.ReadOnly = True
        Me.gchIdBancoSucursal.Width = 40
        '
        'gchCP
        '
        Me.gchCP.DataPropertyName = "CP"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gchCP.DefaultCellStyle = DataGridViewCellStyle16
        Me.gchCP.HeaderText = "C.P."
        Me.gchCP.Name = "gchCP"
        Me.gchCP.ReadOnly = True
        Me.gchCP.Width = 40
        '
        'gchNumeroCheque
        '
        Me.gchNumeroCheque.DataPropertyName = "NumeroCheque"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gchNumeroCheque.DefaultCellStyle = DataGridViewCellStyle17
        Me.gchNumeroCheque.HeaderText = "Numero"
        Me.gchNumeroCheque.Name = "gchNumeroCheque"
        Me.gchNumeroCheque.ReadOnly = True
        Me.gchNumeroCheque.Width = 70
        '
        'gchLocalidad
        '
        Me.gchLocalidad.DataPropertyName = "Localidad"
        Me.gchLocalidad.HeaderText = "Localidad"
        Me.gchLocalidad.Name = "gchLocalidad"
        Me.gchLocalidad.ReadOnly = True
        Me.gchLocalidad.Visible = False
        '
        'gchFechaEmision
        '
        Me.gchFechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.Format = "d"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.gchFechaEmision.DefaultCellStyle = DataGridViewCellStyle18
        Me.gchFechaEmision.HeaderText = "Emision"
        Me.gchFechaEmision.Name = "gchFechaEmision"
        Me.gchFechaEmision.ReadOnly = True
        Me.gchFechaEmision.Width = 70
        '
        'gchFechaCobro
        '
        Me.gchFechaCobro.DataPropertyName = "FechaCobro"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.Format = "d"
        Me.gchFechaCobro.DefaultCellStyle = DataGridViewCellStyle19
        Me.gchFechaCobro.HeaderText = "Cobro"
        Me.gchFechaCobro.Name = "gchFechaCobro"
        Me.gchFechaCobro.ReadOnly = True
        Me.gchFechaCobro.Width = 70
        '
        'gchTitular
        '
        Me.gchTitular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gchTitular.DataPropertyName = "Titular"
        Me.gchTitular.HeaderText = "Titular"
        Me.gchTitular.Name = "gchTitular"
        Me.gchTitular.ReadOnly = True
        '
        'CUIT
        '
        Me.CUIT.DataPropertyName = "CUIT"
        Me.CUIT.HeaderText = "CUIT"
        Me.CUIT.Name = "CUIT"
        Me.CUIT.ReadOnly = True
        Me.CUIT.Width = 90
        '
        'gchImporte
        '
        Me.gchImporte.DataPropertyName = "Importe"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.gchImporte.DefaultCellStyle = DataGridViewCellStyle20
        Me.gchImporte.HeaderText = "Importe"
        Me.gchImporte.Name = "gchImporte"
        Me.gchImporte.ReadOnly = True
        Me.gchImporte.Width = 90
        '
        'gchClienteTipoDocumento
        '
        Me.gchClienteTipoDocumento.DataPropertyName = "ClienteTipoDocumento"
        Me.gchClienteTipoDocumento.HeaderText = "ClienteTipoDocumento"
        Me.gchClienteTipoDocumento.Name = "gchClienteTipoDocumento"
        Me.gchClienteTipoDocumento.ReadOnly = True
        Me.gchClienteTipoDocumento.Visible = False
        '
        'gchClienteNroDocumento
        '
        Me.gchClienteNroDocumento.DataPropertyName = "ClienteNroDocumento"
        Me.gchClienteNroDocumento.HeaderText = "ClienteNroDocumento"
        Me.gchClienteNroDocumento.Name = "gchClienteNroDocumento"
        Me.gchClienteNroDocumento.ReadOnly = True
        Me.gchClienteNroDocumento.Visible = False
        '
        'gchBanco
        '
        Me.gchBanco.DataPropertyName = "Banco"
        Me.gchBanco.HeaderText = "Banco"
        Me.gchBanco.Name = "gchBanco"
        Me.gchBanco.ReadOnly = True
        Me.gchBanco.Visible = False
        '
        'gchNroPlanillaIngreso
        '
        Me.gchNroPlanillaIngreso.DataPropertyName = "NroPlanillaIngreso"
        Me.gchNroPlanillaIngreso.HeaderText = "NroPlanillaRecibo"
        Me.gchNroPlanillaIngreso.Name = "gchNroPlanillaIngreso"
        Me.gchNroPlanillaIngreso.ReadOnly = True
        Me.gchNroPlanillaIngreso.Visible = False
        '
        'gchNroMovimientoIngreso
        '
        Me.gchNroMovimientoIngreso.DataPropertyName = "NroMovimientoIngreso"
        Me.gchNroMovimientoIngreso.HeaderText = "NroMovimientoRecibo"
        Me.gchNroMovimientoIngreso.Name = "gchNroMovimientoIngreso"
        Me.gchNroMovimientoIngreso.ReadOnly = True
        Me.gchNroMovimientoIngreso.Visible = False
        '
        'gchNroPlanillaEgreso
        '
        Me.gchNroPlanillaEgreso.DataPropertyName = "NroPlanillaEgreso"
        Me.gchNroPlanillaEgreso.HeaderText = "NroPlanillaEntregado"
        Me.gchNroPlanillaEgreso.Name = "gchNroPlanillaEgreso"
        Me.gchNroPlanillaEgreso.ReadOnly = True
        Me.gchNroPlanillaEgreso.Visible = False
        '
        'gchNroMovimientoEgreso
        '
        Me.gchNroMovimientoEgreso.DataPropertyName = "NroMovimientoEgreso"
        Me.gchNroMovimientoEgreso.HeaderText = "NroMovimientoEntregado"
        Me.gchNroMovimientoEgreso.Name = "gchNroMovimientoEgreso"
        Me.gchNroMovimientoEgreso.ReadOnly = True
        Me.gchNroMovimientoEgreso.Visible = False
        '
        'gchUsuario
        '
        Me.gchUsuario.DataPropertyName = "Usuario"
        Me.gchUsuario.HeaderText = "Usuario"
        Me.gchUsuario.Name = "gchUsuario"
        Me.gchUsuario.ReadOnly = True
        Me.gchUsuario.Visible = False
        '
        'gchPassword
        '
        Me.gchPassword.DataPropertyName = "Password"
        Me.gchPassword.HeaderText = "PwdCheque"
        Me.gchPassword.Name = "gchPassword"
        Me.gchPassword.ReadOnly = True
        Me.gchPassword.Visible = False
        '
        'gchIdSucursal
        '
        Me.gchIdSucursal.DataPropertyName = "IdSucursal"
        Me.gchIdSucursal.HeaderText = "IdSucursalCheque"
        Me.gchIdSucursal.Name = "gchIdSucursal"
        Me.gchIdSucursal.ReadOnly = True
        Me.gchIdSucursal.Visible = False
        '
        'gchCliente
        '
        Me.gchCliente.DataPropertyName = "Cliente"
        Me.gchCliente.HeaderText = "Cliente"
        Me.gchCliente.Name = "gchCliente"
        Me.gchCliente.ReadOnly = True
        Me.gchCliente.Visible = False
        '
        'gchCuentaBancaria
        '
        Me.gchCuentaBancaria.DataPropertyName = "CuentaBancaria"
        Me.gchCuentaBancaria.HeaderText = "CuentaBancaria"
        Me.gchCuentaBancaria.Name = "gchCuentaBancaria"
        Me.gchCuentaBancaria.ReadOnly = True
        Me.gchCuentaBancaria.Visible = False
        '
        'gchIdCuentaBancaria
        '
        Me.gchIdCuentaBancaria.DataPropertyName = "IdCuentaBancaria"
        Me.gchIdCuentaBancaria.HeaderText = "IdCuentaBancaria"
        Me.gchIdCuentaBancaria.Name = "gchIdCuentaBancaria"
        Me.gchIdCuentaBancaria.ReadOnly = True
        Me.gchIdCuentaBancaria.Visible = False
        '
        'gchNombreCuentaBancaria
        '
        Me.gchNombreCuentaBancaria.DataPropertyName = "NombreCuentaBancaria"
        Me.gchNombreCuentaBancaria.HeaderText = "NombreCuentaBancaria"
        Me.gchNombreCuentaBancaria.Name = "gchNombreCuentaBancaria"
        Me.gchNombreCuentaBancaria.ReadOnly = True
        Me.gchNombreCuentaBancaria.Visible = False
        '
        'gchEsPropio
        '
        Me.gchEsPropio.DataPropertyName = "EsPropio"
        Me.gchEsPropio.HeaderText = "EsPropio"
        Me.gchEsPropio.Name = "gchEsPropio"
        Me.gchEsPropio.ReadOnly = True
        Me.gchEsPropio.Visible = False
        '
        'gchIdEstadoCheque
        '
        Me.gchIdEstadoCheque.DataPropertyName = "IdEstadoCheque"
        Me.gchIdEstadoCheque.HeaderText = "IdEstadoCheque"
        Me.gchIdEstadoCheque.Name = "gchIdEstadoCheque"
        Me.gchIdEstadoCheque.ReadOnly = True
        Me.gchIdEstadoCheque.Visible = False
        '
        'gchIdEstadoChequeAnt
        '
        Me.gchIdEstadoChequeAnt.DataPropertyName = "IdEstadoChequeAnt"
        Me.gchIdEstadoChequeAnt.HeaderText = "IdEstadoChequeAnt"
        Me.gchIdEstadoChequeAnt.Name = "gchIdEstadoChequeAnt"
        Me.gchIdEstadoChequeAnt.ReadOnly = True
        Me.gchIdEstadoChequeAnt.Visible = False
        '
        'gchProveedor
        '
        Me.gchProveedor.DataPropertyName = "Proveedor"
        Me.gchProveedor.HeaderText = "Proveedor"
        Me.gchProveedor.Name = "gchProveedor"
        Me.gchProveedor.ReadOnly = True
        Me.gchProveedor.Visible = False
        '
        'gchRowState
        '
        Me.gchRowState.DataPropertyName = "RowState"
        Me.gchRowState.HeaderText = "RowState"
        Me.gchRowState.Name = "gchRowState"
        Me.gchRowState.ReadOnly = True
        Me.gchRowState.Visible = False
        '
        'gchIdSucursal2
        '
        Me.gchIdSucursal2.DataPropertyName = "IdSucursal2"
        Me.gchIdSucursal2.HeaderText = "IdSucursal2"
        Me.gchIdSucursal2.Name = "gchIdSucursal2"
        Me.gchIdSucursal2.ReadOnly = True
        Me.gchIdSucursal2.Visible = False
        '
        'IdCajaIngreso
        '
        Me.IdCajaIngreso.DataPropertyName = "IdCajaIngreso"
        Me.IdCajaIngreso.HeaderText = "IdCajaIngreso"
        Me.IdCajaIngreso.Name = "IdCajaIngreso"
        Me.IdCajaIngreso.ReadOnly = True
        Me.IdCajaIngreso.Visible = False
        '
        'IdCajaEgreso
        '
        Me.IdCajaEgreso.DataPropertyName = "IdCajaEgreso"
        Me.IdCajaEgreso.HeaderText = "IdCajaEgreso"
        Me.IdCajaEgreso.Name = "IdCajaEgreso"
        Me.IdCajaEgreso.ReadOnly = True
        Me.IdCajaEgreso.Visible = False
        '
        'FotoFrente
        '
        Me.FotoFrente.DataPropertyName = "FotoFrente"
        Me.FotoFrente.HeaderText = "FotoFrente"
        Me.FotoFrente.Name = "FotoFrente"
        Me.FotoFrente.ReadOnly = True
        Me.FotoFrente.Visible = False
        '
        'FotoDorso
        '
        Me.FotoDorso.DataPropertyName = "FotoDorso"
        Me.FotoDorso.HeaderText = "FotoDorso"
        Me.FotoDorso.Name = "FotoDorso"
        Me.FotoDorso.ReadOnly = True
        Me.FotoDorso.Visible = False
        '
        'IdProveedorPreasignado
        '
        Me.IdProveedorPreasignado.DataPropertyName = "IdProveedorPreasignado"
        Me.IdProveedorPreasignado.HeaderText = "IdProveedorPreasignado"
        Me.IdProveedorPreasignado.Name = "IdProveedorPreasignado"
        Me.IdProveedorPreasignado.ReadOnly = True
        Me.IdProveedorPreasignado.Visible = False
        '
        'CodigoProveedorPreasignado
        '
        Me.CodigoProveedorPreasignado.DataPropertyName = "CodigoProveedorPreasignado"
        Me.CodigoProveedorPreasignado.HeaderText = "CodigoProveedorPreasignado"
        Me.CodigoProveedorPreasignado.Name = "CodigoProveedorPreasignado"
        Me.CodigoProveedorPreasignado.ReadOnly = True
        Me.CodigoProveedorPreasignado.Visible = False
        '
        'ProveedorPreasignado
        '
        Me.ProveedorPreasignado.DataPropertyName = "ProveedorPreasignado"
        Me.ProveedorPreasignado.HeaderText = "ProveedorPreasignado"
        Me.ProveedorPreasignado.Name = "ProveedorPreasignado"
        Me.ProveedorPreasignado.ReadOnly = True
        Me.ProveedorPreasignado.Visible = False
        '
        'CajaDetalleParaIngresoDirectoPorABM
        '
        Me.CajaDetalleParaIngresoDirectoPorABM.DataPropertyName = "CajaDetalleParaIngresoDirectoPorABM"
        Me.CajaDetalleParaIngresoDirectoPorABM.HeaderText = "CajaDetalleParaIngresoDirectoPorABM"
        Me.CajaDetalleParaIngresoDirectoPorABM.Name = "CajaDetalleParaIngresoDirectoPorABM"
        Me.CajaDetalleParaIngresoDirectoPorABM.ReadOnly = True
        Me.CajaDetalleParaIngresoDirectoPorABM.Visible = False
        '
        'IdCuentaDeCaja
        '
        Me.IdCuentaDeCaja.DataPropertyName = "IdCuentaDeCaja"
        Me.IdCuentaDeCaja.HeaderText = "IdCuentaDeCaja"
        Me.IdCuentaDeCaja.Name = "IdCuentaDeCaja"
        Me.IdCuentaDeCaja.ReadOnly = True
        Me.IdCuentaDeCaja.Visible = False
        '
        'tbpRetenciones
        '
        Me.tbpRetenciones.Controls.Add(Me.dgvRetenciones)
        Me.tbpRetenciones.Location = New System.Drawing.Point(4, 22)
        Me.tbpRetenciones.Name = "tbpRetenciones"
        Me.tbpRetenciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpRetenciones.Size = New System.Drawing.Size(933, 181)
        Me.tbpRetenciones.TabIndex = 1
        Me.tbpRetenciones.Text = "Retenciones"
        Me.tbpRetenciones.UseVisualStyleBackColor = True
        '
        'dgvRetenciones
        '
        Me.dgvRetenciones.AllowUserToAddRows = False
        Me.dgvRetenciones.AllowUserToDeleteRows = False
        Me.dgvRetenciones.AllowUserToResizeRows = False
        Me.dgvRetenciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRetenciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRetenciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gretIdTipoImpuesto, Me.gretNombreTipoImpuesto, Me.gretEmisorRetencion, Me.gretNumeroRetencion, Me.gretFechaEmision, Me.gretBaseImponible, Me.gretAlicuota, Me.gretImporteTotal, Me.gretClienteTipoDocumento, Me.gretClienteNroDocumento, Me.gretTipoImpuesto, Me.gretNroPlanillaIngreso, Me.gretNroMovimientoIngreso, Me.gretUsuario, Me.gretPassword, Me.gretIdSucursal, Me.gretCliente, Me.gretIdEstado, Me.gretRowState, Me.gretIdTipoComprobante, Me.gretTipoComprobante, Me.gretLetraComprobante, Me.gretEmisorComprobante, Me.gretNumeroComprobante, Me.gretFechaComprobante, Me.gretImporteComprobante})
        Me.dgvRetenciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvRetenciones.Location = New System.Drawing.Point(5, 6)
        Me.dgvRetenciones.MultiSelect = False
        Me.dgvRetenciones.Name = "dgvRetenciones"
        Me.dgvRetenciones.ReadOnly = True
        Me.dgvRetenciones.RowHeadersVisible = False
        Me.dgvRetenciones.RowHeadersWidth = 20
        Me.dgvRetenciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRetenciones.Size = New System.Drawing.Size(926, 172)
        Me.dgvRetenciones.TabIndex = 16
        '
        'gretIdTipoImpuesto
        '
        Me.gretIdTipoImpuesto.DataPropertyName = "IdTipoImpuesto"
        Me.gretIdTipoImpuesto.HeaderText = "IdTipoImpuesto"
        Me.gretIdTipoImpuesto.Name = "gretIdTipoImpuesto"
        Me.gretIdTipoImpuesto.ReadOnly = True
        Me.gretIdTipoImpuesto.Visible = False
        '
        'gretNombreTipoImpuesto
        '
        Me.gretNombreTipoImpuesto.DataPropertyName = "NombreTipoImpuesto"
        Me.gretNombreTipoImpuesto.HeaderText = "Tipo Impuesto"
        Me.gretNombreTipoImpuesto.Name = "gretNombreTipoImpuesto"
        Me.gretNombreTipoImpuesto.ReadOnly = True
        Me.gretNombreTipoImpuesto.Width = 180
        '
        'gretEmisorRetencion
        '
        Me.gretEmisorRetencion.DataPropertyName = "EmisorRetencion"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gretEmisorRetencion.DefaultCellStyle = DataGridViewCellStyle21
        Me.gretEmisorRetencion.HeaderText = "Emisor"
        Me.gretEmisorRetencion.Name = "gretEmisorRetencion"
        Me.gretEmisorRetencion.ReadOnly = True
        Me.gretEmisorRetencion.Width = 50
        '
        'gretNumeroRetencion
        '
        Me.gretNumeroRetencion.DataPropertyName = "NumeroRetencion"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gretNumeroRetencion.DefaultCellStyle = DataGridViewCellStyle22
        Me.gretNumeroRetencion.HeaderText = "Numero"
        Me.gretNumeroRetencion.Name = "gretNumeroRetencion"
        Me.gretNumeroRetencion.ReadOnly = True
        Me.gretNumeroRetencion.Width = 90
        '
        'gretFechaEmision
        '
        Me.gretFechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.Format = "d"
        DataGridViewCellStyle23.NullValue = Nothing
        Me.gretFechaEmision.DefaultCellStyle = DataGridViewCellStyle23
        Me.gretFechaEmision.HeaderText = "Emision"
        Me.gretFechaEmision.Name = "gretFechaEmision"
        Me.gretFechaEmision.ReadOnly = True
        Me.gretFechaEmision.Width = 90
        '
        'gretBaseImponible
        '
        Me.gretBaseImponible.DataPropertyName = "BaseImponible"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.Format = "N2"
        DataGridViewCellStyle24.NullValue = Nothing
        Me.gretBaseImponible.DefaultCellStyle = DataGridViewCellStyle24
        Me.gretBaseImponible.HeaderText = "Base Imp."
        Me.gretBaseImponible.Name = "gretBaseImponible"
        Me.gretBaseImponible.ReadOnly = True
        Me.gretBaseImponible.Width = 90
        '
        'gretAlicuota
        '
        Me.gretAlicuota.DataPropertyName = "Alicuota"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.Format = "N2"
        Me.gretAlicuota.DefaultCellStyle = DataGridViewCellStyle25
        Me.gretAlicuota.HeaderText = "Alicuota"
        Me.gretAlicuota.Name = "gretAlicuota"
        Me.gretAlicuota.ReadOnly = True
        Me.gretAlicuota.Width = 50
        '
        'gretImporteTotal
        '
        Me.gretImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.Format = "N2"
        Me.gretImporteTotal.DefaultCellStyle = DataGridViewCellStyle26
        Me.gretImporteTotal.HeaderText = "ImporteTotal"
        Me.gretImporteTotal.Name = "gretImporteTotal"
        Me.gretImporteTotal.ReadOnly = True
        Me.gretImporteTotal.Width = 90
        '
        'gretClienteTipoDocumento
        '
        Me.gretClienteTipoDocumento.DataPropertyName = "ClienteTipoDocumento"
        Me.gretClienteTipoDocumento.HeaderText = "ClienteTipoDocumento"
        Me.gretClienteTipoDocumento.Name = "gretClienteTipoDocumento"
        Me.gretClienteTipoDocumento.ReadOnly = True
        Me.gretClienteTipoDocumento.Visible = False
        '
        'gretClienteNroDocumento
        '
        Me.gretClienteNroDocumento.DataPropertyName = "ClienteNroDocumento"
        Me.gretClienteNroDocumento.HeaderText = "ClienteNroDocumento"
        Me.gretClienteNroDocumento.Name = "gretClienteNroDocumento"
        Me.gretClienteNroDocumento.ReadOnly = True
        Me.gretClienteNroDocumento.Visible = False
        '
        'gretTipoImpuesto
        '
        Me.gretTipoImpuesto.DataPropertyName = "TipoImpuesto"
        Me.gretTipoImpuesto.HeaderText = "TipoImpuesto"
        Me.gretTipoImpuesto.Name = "gretTipoImpuesto"
        Me.gretTipoImpuesto.ReadOnly = True
        Me.gretTipoImpuesto.Visible = False
        '
        'gretNroPlanillaIngreso
        '
        Me.gretNroPlanillaIngreso.DataPropertyName = "NroPlanillaIngreso"
        Me.gretNroPlanillaIngreso.HeaderText = "NroPlanillaIngreso"
        Me.gretNroPlanillaIngreso.Name = "gretNroPlanillaIngreso"
        Me.gretNroPlanillaIngreso.ReadOnly = True
        Me.gretNroPlanillaIngreso.Visible = False
        '
        'gretNroMovimientoIngreso
        '
        Me.gretNroMovimientoIngreso.DataPropertyName = "NroMovimientoIngreso"
        Me.gretNroMovimientoIngreso.HeaderText = "NroMovimientoIngreso"
        Me.gretNroMovimientoIngreso.Name = "gretNroMovimientoIngreso"
        Me.gretNroMovimientoIngreso.ReadOnly = True
        Me.gretNroMovimientoIngreso.Visible = False
        '
        'gretUsuario
        '
        Me.gretUsuario.DataPropertyName = "Usuario"
        Me.gretUsuario.HeaderText = "Usuario"
        Me.gretUsuario.Name = "gretUsuario"
        Me.gretUsuario.ReadOnly = True
        Me.gretUsuario.Visible = False
        '
        'gretPassword
        '
        Me.gretPassword.DataPropertyName = "Password"
        Me.gretPassword.HeaderText = "Password"
        Me.gretPassword.Name = "gretPassword"
        Me.gretPassword.ReadOnly = True
        Me.gretPassword.Visible = False
        '
        'gretIdSucursal
        '
        Me.gretIdSucursal.DataPropertyName = "IdSucursal"
        Me.gretIdSucursal.HeaderText = "IdSucursal"
        Me.gretIdSucursal.Name = "gretIdSucursal"
        Me.gretIdSucursal.ReadOnly = True
        Me.gretIdSucursal.Visible = False
        '
        'gretCliente
        '
        Me.gretCliente.DataPropertyName = "Cliente"
        Me.gretCliente.HeaderText = "Cliente"
        Me.gretCliente.Name = "gretCliente"
        Me.gretCliente.ReadOnly = True
        Me.gretCliente.Visible = False
        '
        'gretIdEstado
        '
        Me.gretIdEstado.DataPropertyName = "IdEstado"
        Me.gretIdEstado.HeaderText = "IdEstado"
        Me.gretIdEstado.Name = "gretIdEstado"
        Me.gretIdEstado.ReadOnly = True
        Me.gretIdEstado.Visible = False
        '
        'gretRowState
        '
        Me.gretRowState.DataPropertyName = "RowState"
        Me.gretRowState.HeaderText = "RowState"
        Me.gretRowState.Name = "gretRowState"
        Me.gretRowState.ReadOnly = True
        Me.gretRowState.Visible = False
        '
        'gretIdTipoComprobante
        '
        Me.gretIdTipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.gretIdTipoComprobante.HeaderText = "IdTipoComprobante"
        Me.gretIdTipoComprobante.Name = "gretIdTipoComprobante"
        Me.gretIdTipoComprobante.ReadOnly = True
        Me.gretIdTipoComprobante.Visible = False
        '
        'gretTipoComprobante
        '
        Me.gretTipoComprobante.DataPropertyName = "TipoComprobante"
        Me.gretTipoComprobante.HeaderText = "TipoComprobante"
        Me.gretTipoComprobante.Name = "gretTipoComprobante"
        Me.gretTipoComprobante.ReadOnly = True
        Me.gretTipoComprobante.Visible = False
        '
        'gretLetraComprobante
        '
        Me.gretLetraComprobante.DataPropertyName = "LetraComprobante"
        Me.gretLetraComprobante.HeaderText = "LetraComprobante"
        Me.gretLetraComprobante.Name = "gretLetraComprobante"
        Me.gretLetraComprobante.ReadOnly = True
        Me.gretLetraComprobante.Visible = False
        '
        'gretEmisorComprobante
        '
        Me.gretEmisorComprobante.DataPropertyName = "EmisorComprobante"
        Me.gretEmisorComprobante.HeaderText = "EmisorComprobante"
        Me.gretEmisorComprobante.Name = "gretEmisorComprobante"
        Me.gretEmisorComprobante.ReadOnly = True
        Me.gretEmisorComprobante.Visible = False
        '
        'gretNumeroComprobante
        '
        Me.gretNumeroComprobante.DataPropertyName = "NumeroComprobante"
        Me.gretNumeroComprobante.HeaderText = "NumeroComprobante"
        Me.gretNumeroComprobante.Name = "gretNumeroComprobante"
        Me.gretNumeroComprobante.ReadOnly = True
        Me.gretNumeroComprobante.Visible = False
        '
        'gretFechaComprobante
        '
        Me.gretFechaComprobante.DataPropertyName = "FechaComprobante"
        Me.gretFechaComprobante.HeaderText = "FechaComprobante"
        Me.gretFechaComprobante.Name = "gretFechaComprobante"
        Me.gretFechaComprobante.ReadOnly = True
        Me.gretFechaComprobante.Visible = False
        '
        'gretImporteComprobante
        '
        Me.gretImporteComprobante.DataPropertyName = "ImporteComprobante"
        Me.gretImporteComprobante.HeaderText = "ImporteComprobante"
        Me.gretImporteComprobante.Name = "gretImporteComprobante"
        Me.gretImporteComprobante.ReadOnly = True
        Me.gretImporteComprobante.Visible = False
        '
        'lblRetenciones
        '
        Me.lblRetenciones.AutoSize = True
        Me.lblRetenciones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRetenciones.LabelAsoc = Nothing
        Me.lblRetenciones.Location = New System.Drawing.Point(812, 27)
        Me.lblRetenciones.Name = "lblRetenciones"
        Me.lblRetenciones.Size = New System.Drawing.Size(67, 13)
        Me.lblRetenciones.TabIndex = 10
        Me.lblRetenciones.Text = "Retenciones"
        '
        'txtRetenciones
        '
        Me.txtRetenciones.BindearPropiedadControl = Nothing
        Me.txtRetenciones.BindearPropiedadEntidad = Nothing
        Me.txtRetenciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRetenciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRetenciones.Formato = "##0.00"
        Me.txtRetenciones.IsDecimal = True
        Me.txtRetenciones.IsNumber = True
        Me.txtRetenciones.IsPK = False
        Me.txtRetenciones.IsRequired = False
        Me.txtRetenciones.Key = ""
        Me.txtRetenciones.LabelAsoc = Me.lblRetenciones
        Me.txtRetenciones.Location = New System.Drawing.Point(881, 23)
        Me.txtRetenciones.Name = "txtRetenciones"
        Me.txtRetenciones.ReadOnly = True
        Me.txtRetenciones.Size = New System.Drawing.Size(60, 20)
        Me.txtRetenciones.TabIndex = 11
        Me.txtRetenciones.Text = "0.00"
        Me.txtRetenciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTransferenciaBancaria
        '
        Me.txtTransferenciaBancaria.BindearPropiedadControl = Nothing
        Me.txtTransferenciaBancaria.BindearPropiedadEntidad = Nothing
        Me.txtTransferenciaBancaria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTransferenciaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTransferenciaBancaria.Formato = "##0.00"
        Me.txtTransferenciaBancaria.IsDecimal = True
        Me.txtTransferenciaBancaria.IsNumber = True
        Me.txtTransferenciaBancaria.IsPK = False
        Me.txtTransferenciaBancaria.IsRequired = False
        Me.txtTransferenciaBancaria.Key = ""
        Me.txtTransferenciaBancaria.LabelAsoc = Me.lblTransferenciaBancaria
        Me.txtTransferenciaBancaria.Location = New System.Drawing.Point(305, 22)
        Me.txtTransferenciaBancaria.Name = "txtTransferenciaBancaria"
        Me.txtTransferenciaBancaria.ReadOnly = True
        Me.txtTransferenciaBancaria.Size = New System.Drawing.Size(60, 20)
        Me.txtTransferenciaBancaria.TabIndex = 5
        Me.txtTransferenciaBancaria.Text = "0.00"
        Me.txtTransferenciaBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCheques
        '
        Me.lblCheques.AutoSize = True
        Me.lblCheques.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCheques.LabelAsoc = Nothing
        Me.lblCheques.Location = New System.Drawing.Point(689, 27)
        Me.lblCheques.Name = "lblCheques"
        Me.lblCheques.Size = New System.Drawing.Size(49, 13)
        Me.lblCheques.TabIndex = 8
        Me.lblCheques.Text = "Cheques"
        '
        'txtCheques
        '
        Me.txtCheques.BindearPropiedadControl = Nothing
        Me.txtCheques.BindearPropiedadEntidad = Nothing
        Me.txtCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCheques.Formato = "##0.00"
        Me.txtCheques.IsDecimal = True
        Me.txtCheques.IsNumber = True
        Me.txtCheques.IsPK = False
        Me.txtCheques.IsRequired = False
        Me.txtCheques.Key = ""
        Me.txtCheques.LabelAsoc = Me.lblCheques
        Me.txtCheques.Location = New System.Drawing.Point(742, 23)
        Me.txtCheques.Name = "txtCheques"
        Me.txtCheques.ReadOnly = True
        Me.txtCheques.Size = New System.Drawing.Size(60, 20)
        Me.txtCheques.TabIndex = 9
        Me.txtCheques.Text = "0.00"
        Me.txtCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTarjetas
        '
        Me.lblTarjetas.AutoSize = True
        Me.lblTarjetas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTarjetas.LabelAsoc = Nothing
        Me.lblTarjetas.Location = New System.Drawing.Point(114, 26)
        Me.lblTarjetas.Name = "lblTarjetas"
        Me.lblTarjetas.Size = New System.Drawing.Size(45, 13)
        Me.lblTarjetas.TabIndex = 2
        Me.lblTarjetas.Text = "Tarjetas"
        '
        'txtTarjetas
        '
        Me.txtTarjetas.BindearPropiedadControl = Nothing
        Me.txtTarjetas.BindearPropiedadEntidad = Nothing
        Me.txtTarjetas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarjetas.Formato = "##0.00"
        Me.txtTarjetas.IsDecimal = True
        Me.txtTarjetas.IsNumber = True
        Me.txtTarjetas.IsPK = False
        Me.txtTarjetas.IsRequired = False
        Me.txtTarjetas.Key = ""
        Me.txtTarjetas.LabelAsoc = Me.lblTarjetas
        Me.txtTarjetas.Location = New System.Drawing.Point(162, 22)
        Me.txtTarjetas.Name = "txtTarjetas"
        Me.txtTarjetas.ReadOnly = True
        Me.txtTarjetas.Size = New System.Drawing.Size(60, 20)
        Me.txtTarjetas.TabIndex = 3
        Me.txtTarjetas.Text = "0.00"
        Me.txtTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEfectivo.LabelAsoc = Nothing
        Me.lblEfectivo.Location = New System.Drawing.Point(7, 26)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(36, 13)
        Me.lblEfectivo.TabIndex = 0
        Me.lblEfectivo.Text = "Pesos"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.BindearPropiedadControl = Nothing
        Me.txtEfectivo.BindearPropiedadEntidad = Nothing
        Me.txtEfectivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEfectivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEfectivo.Formato = "##0.00"
        Me.txtEfectivo.IsDecimal = True
        Me.txtEfectivo.IsNumber = True
        Me.txtEfectivo.IsPK = False
        Me.txtEfectivo.IsRequired = False
        Me.txtEfectivo.Key = ""
        Me.txtEfectivo.LabelAsoc = Me.lblEfectivo
        Me.txtEfectivo.Location = New System.Drawing.Point(48, 22)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.ReadOnly = True
        Me.txtEfectivo.Size = New System.Drawing.Size(60, 20)
        Me.txtEfectivo.TabIndex = 1
        Me.txtEfectivo.Text = "0,00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grbCliente
        '
        Me.grbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbCliente.Controls.Add(Me.chbNroOrdenDeCompra)
        Me.grbCliente.Controls.Add(Me.bscNroOrdenDeCompra)
        Me.grbCliente.Controls.Add(Me.cmbVendedor)
        Me.grbCliente.Controls.Add(Me.dtpFechaEmision)
        Me.grbCliente.Controls.Add(Me.cmbTiposComprobantesRec)
        Me.grbCliente.Controls.Add(Me.lblTipoComprobanteRec)
        Me.grbCliente.Controls.Add(Me.cmbCajas)
        Me.grbCliente.Controls.Add(Me.lblCaja)
        Me.grbCliente.Controls.Add(Me.txtNombreVendedor)
        Me.grbCliente.Controls.Add(Me.lblNombreVendedor)
        Me.grbCliente.Controls.Add(Me.btnConsultar)
        Me.grbCliente.Controls.Add(Me.txtNombreCliente)
        Me.grbCliente.Controls.Add(Me.txtCodigoCliente)
        Me.grbCliente.Controls.Add(Me.lblEmisorRecibo)
        Me.grbCliente.Controls.Add(Me.txtEmisor)
        Me.grbCliente.Controls.Add(Me.lblLetra)
        Me.grbCliente.Controls.Add(Me.txtLetra)
        Me.grbCliente.Controls.Add(Me.lblNroRecibo)
        Me.grbCliente.Controls.Add(Me.txtNroRecibo)
        Me.grbCliente.Controls.Add(Me.lblObservacion)
        Me.grbCliente.Controls.Add(Me.txtObservacion)
        Me.grbCliente.Controls.Add(Me.GroupBox1)
        Me.grbCliente.Controls.Add(Me.txtCategoriaFiscal)
        Me.grbCliente.Controls.Add(Me.lblCategoriaFiscal)
        Me.grbCliente.Controls.Add(Me.txtLocalidad)
        Me.grbCliente.Controls.Add(Me.lblLocalidad)
        Me.grbCliente.Controls.Add(Me.txtDireccion)
        Me.grbCliente.Controls.Add(Me.lblDireccion)
        Me.grbCliente.Controls.Add(Me.lblFecha)
        Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
        Me.grbCliente.Controls.Add(Me.lblNombreCliente)
        Me.grbCliente.Location = New System.Drawing.Point(3, 36)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(953, 183)
        Me.grbCliente.TabIndex = 0
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Detalle"
        '
        'chbNroOrdenDeCompra
        '
        Me.chbNroOrdenDeCompra.AutoSize = True
        Me.chbNroOrdenDeCompra.BindearPropiedadControl = Nothing
        Me.chbNroOrdenDeCompra.BindearPropiedadEntidad = Nothing
        Me.chbNroOrdenDeCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chbNroOrdenDeCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNroOrdenDeCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNroOrdenDeCompra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbNroOrdenDeCompra.IsPK = False
        Me.chbNroOrdenDeCompra.IsRequired = False
        Me.chbNroOrdenDeCompra.Key = Nothing
        Me.chbNroOrdenDeCompra.LabelAsoc = Nothing
        Me.chbNroOrdenDeCompra.Location = New System.Drawing.Point(632, 160)
        Me.chbNroOrdenDeCompra.Name = "chbNroOrdenDeCompra"
        Me.chbNroOrdenDeCompra.Size = New System.Drawing.Size(50, 17)
        Me.chbNroOrdenDeCompra.TabIndex = 44
        Me.chbNroOrdenDeCompra.Text = "O. C."
        '
        'bscNroOrdenDeCompra
        '
        Me.bscNroOrdenDeCompra.ActivarFiltroEnGrilla = True
        Me.bscNroOrdenDeCompra.BindearPropiedadControl = Nothing
        Me.bscNroOrdenDeCompra.BindearPropiedadEntidad = Nothing
        Me.bscNroOrdenDeCompra.ConfigBuscador = Nothing
        Me.bscNroOrdenDeCompra.Datos = Nothing
        Me.bscNroOrdenDeCompra.FilaDevuelta = Nothing
        Me.bscNroOrdenDeCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNroOrdenDeCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNroOrdenDeCompra.IsDecimal = False
        Me.bscNroOrdenDeCompra.IsNumber = True
        Me.bscNroOrdenDeCompra.IsPK = False
        Me.bscNroOrdenDeCompra.IsRequired = False
        Me.bscNroOrdenDeCompra.Key = ""
        Me.bscNroOrdenDeCompra.LabelAsoc = Me.chbNroOrdenDeCompra
        Me.bscNroOrdenDeCompra.Location = New System.Drawing.Point(688, 157)
        Me.bscNroOrdenDeCompra.MaxLengh = "32767"
        Me.bscNroOrdenDeCompra.Name = "bscNroOrdenDeCompra"
        Me.bscNroOrdenDeCompra.Permitido = False
        Me.bscNroOrdenDeCompra.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNroOrdenDeCompra.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNroOrdenDeCompra.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNroOrdenDeCompra.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNroOrdenDeCompra.Selecciono = False
        Me.bscNroOrdenDeCompra.Size = New System.Drawing.Size(94, 20)
        Me.bscNroOrdenDeCompra.TabIndex = 43
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Location = New System.Drawing.Point(441, 118)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(122, 21)
        Me.cmbVendedor.TabIndex = 21
        Me.cmbVendedor.Visible = False
        '
        'dtpFechaEmision
        '
        Me.dtpFechaEmision.BindearPropiedadControl = Nothing
        Me.dtpFechaEmision.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEmision.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEmision.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEmision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEmision.IsPK = False
        Me.dtpFechaEmision.IsRequired = False
        Me.dtpFechaEmision.Key = ""
        Me.dtpFechaEmision.LabelAsoc = Nothing
        Me.dtpFechaEmision.Location = New System.Drawing.Point(370, 30)
        Me.dtpFechaEmision.Name = "dtpFechaEmision"
        Me.dtpFechaEmision.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEmision.TabIndex = 9
        Me.dtpFechaEmision.Value = New Date(2019, 10, 22, 0, 0, 0, 0)
        '
        'cmbTiposComprobantesRec
        '
        Me.cmbTiposComprobantesRec.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantesRec.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantesRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantesRec.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesRec.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesRec.FormattingEnabled = True
        Me.cmbTiposComprobantesRec.IsPK = False
        Me.cmbTiposComprobantesRec.IsRequired = False
        Me.cmbTiposComprobantesRec.ItemHeight = 13
        Me.cmbTiposComprobantesRec.Key = Nothing
        Me.cmbTiposComprobantesRec.LabelAsoc = Me.lblTipoComprobanteRec
        Me.cmbTiposComprobantesRec.Location = New System.Drawing.Point(7, 32)
        Me.cmbTiposComprobantesRec.Name = "cmbTiposComprobantesRec"
        Me.cmbTiposComprobantesRec.Size = New System.Drawing.Size(120, 21)
        Me.cmbTiposComprobantesRec.TabIndex = 0
        '
        'lblTipoComprobanteRec
        '
        Me.lblTipoComprobanteRec.AutoSize = True
        Me.lblTipoComprobanteRec.LabelAsoc = Nothing
        Me.lblTipoComprobanteRec.Location = New System.Drawing.Point(4, 16)
        Me.lblTipoComprobanteRec.Name = "lblTipoComprobanteRec"
        Me.lblTipoComprobanteRec.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobanteRec.TabIndex = 1
        Me.lblTipoComprobanteRec.Text = "&Tipo Comprobante"
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
        Me.cmbCajas.Location = New System.Drawing.Point(688, 118)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
        Me.cmbCajas.TabIndex = 27
        Me.cmbCajas.TabStop = False
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(629, 122)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 26
        Me.lblCaja.Text = "Caja"
        '
        'txtNombreVendedor
        '
        Me.txtNombreVendedor.BindearPropiedadControl = Nothing
        Me.txtNombreVendedor.BindearPropiedadEntidad = Nothing
        Me.txtNombreVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreVendedor.Formato = ""
        Me.txtNombreVendedor.IsDecimal = False
        Me.txtNombreVendedor.IsNumber = False
        Me.txtNombreVendedor.IsPK = False
        Me.txtNombreVendedor.IsRequired = False
        Me.txtNombreVendedor.Key = ""
        Me.txtNombreVendedor.LabelAsoc = Me.lblLocalidad
        Me.txtNombreVendedor.Location = New System.Drawing.Point(443, 118)
        Me.txtNombreVendedor.Name = "txtNombreVendedor"
        Me.txtNombreVendedor.ReadOnly = True
        Me.txtNombreVendedor.Size = New System.Drawing.Size(120, 20)
        Me.txtNombreVendedor.TabIndex = 22
        '
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.LabelAsoc = Nothing
        Me.lblLocalidad.Location = New System.Drawing.Point(193, 101)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lblLocalidad.TabIndex = 18
        Me.lblLocalidad.Text = "Localidad"
        '
        'lblNombreVendedor
        '
        Me.lblNombreVendedor.AutoSize = True
        Me.lblNombreVendedor.Location = New System.Drawing.Point(438, 104)
        Me.lblNombreVendedor.Name = "lblNombreVendedor"
        Me.lblNombreVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lblNombreVendedor.TabIndex = 23
        Me.lblNombreVendedor.Text = "Vendedor"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.zoom_32
        Me.btnConsultar.Location = New System.Drawing.Point(309, 19)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(36, 36)
        Me.btnConsultar.TabIndex = 8
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BindearPropiedadControl = Nothing
        Me.txtNombreCliente.BindearPropiedadEntidad = Nothing
        Me.txtNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCliente.Formato = ""
        Me.txtNombreCliente.IsDecimal = False
        Me.txtNombreCliente.IsNumber = False
        Me.txtNombreCliente.IsPK = False
        Me.txtNombreCliente.IsRequired = False
        Me.txtNombreCliente.Key = ""
        Me.txtNombreCliente.LabelAsoc = Me.lblNombreCliente
        Me.txtNombreCliente.Location = New System.Drawing.Point(103, 77)
        Me.txtNombreCliente.MaxLength = 100
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(300, 20)
        Me.txtNombreCliente.TabIndex = 13
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.LabelAsoc = Nothing
        Me.lblNombreCliente.Location = New System.Drawing.Point(100, 64)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(79, 13)
        Me.lblNombreCliente.TabIndex = 14
        Me.lblNombreCliente.Text = "Nombre Cliente"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BindearPropiedadControl = Nothing
        Me.txtCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.txtCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoCliente.Formato = ""
        Me.txtCodigoCliente.IsDecimal = False
        Me.txtCodigoCliente.IsNumber = False
        Me.txtCodigoCliente.IsPK = False
        Me.txtCodigoCliente.IsRequired = False
        Me.txtCodigoCliente.Key = ""
        Me.txtCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.txtCodigoCliente.Location = New System.Drawing.Point(7, 77)
        Me.txtCodigoCliente.MaxLength = 12
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.ReadOnly = True
        Me.txtCodigoCliente.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigoCliente.TabIndex = 11
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(7, 64)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 12
        Me.lblCodigoCliente.Text = "Código"
        '
        'lblEmisorRecibo
        '
        Me.lblEmisorRecibo.AutoSize = True
        Me.lblEmisorRecibo.LabelAsoc = Nothing
        Me.lblEmisorRecibo.Location = New System.Drawing.Point(170, 16)
        Me.lblEmisorRecibo.Name = "lblEmisorRecibo"
        Me.lblEmisorRecibo.Size = New System.Drawing.Size(38, 13)
        Me.lblEmisorRecibo.TabIndex = 5
        Me.lblEmisorRecibo.Text = "Emisor"
        '
        'txtEmisor
        '
        Me.txtEmisor.BindearPropiedadControl = Nothing
        Me.txtEmisor.BindearPropiedadEntidad = Nothing
        Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEmisor.Formato = ""
        Me.txtEmisor.IsDecimal = False
        Me.txtEmisor.IsNumber = True
        Me.txtEmisor.IsPK = False
        Me.txtEmisor.IsRequired = False
        Me.txtEmisor.Key = ""
        Me.txtEmisor.LabelAsoc = Me.lblEmisorRecibo
        Me.txtEmisor.Location = New System.Drawing.Point(167, 32)
        Me.txtEmisor.MaxLength = 4
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New System.Drawing.Size(42, 20)
        Me.txtEmisor.TabIndex = 4
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.LabelAsoc = Nothing
        Me.lblLetra.Location = New System.Drawing.Point(134, 16)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(28, 13)
        Me.lblLetra.TabIndex = 3
        Me.lblLetra.Text = "Tipo"
        '
        'txtLetra
        '
        Me.txtLetra.BindearPropiedadControl = Nothing
        Me.txtLetra.BindearPropiedadEntidad = Nothing
        Me.txtLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLetra.Formato = ""
        Me.txtLetra.IsDecimal = False
        Me.txtLetra.IsNumber = False
        Me.txtLetra.IsPK = False
        Me.txtLetra.IsRequired = False
        Me.txtLetra.Key = ""
        Me.txtLetra.LabelAsoc = Me.lblLetra
        Me.txtLetra.Location = New System.Drawing.Point(137, 32)
        Me.txtLetra.MaxLength = 1
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(25, 20)
        Me.txtLetra.TabIndex = 2
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNroRecibo
        '
        Me.lblNroRecibo.AutoSize = True
        Me.lblNroRecibo.LabelAsoc = Nothing
        Me.lblNroRecibo.Location = New System.Drawing.Point(244, 16)
        Me.lblNroRecibo.Name = "lblNroRecibo"
        Me.lblNroRecibo.Size = New System.Drawing.Size(44, 13)
        Me.lblNroRecibo.TabIndex = 7
        Me.lblNroRecibo.Text = "Numero"
        '
        'txtNroRecibo
        '
        Me.txtNroRecibo.BindearPropiedadControl = Nothing
        Me.txtNroRecibo.BindearPropiedadEntidad = Nothing
        Me.txtNroRecibo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroRecibo.Formato = ""
        Me.txtNroRecibo.IsDecimal = False
        Me.txtNroRecibo.IsNumber = True
        Me.txtNroRecibo.IsPK = False
        Me.txtNroRecibo.IsRequired = False
        Me.txtNroRecibo.Key = ""
        Me.txtNroRecibo.LabelAsoc = Me.lblNroRecibo
        Me.txtNroRecibo.Location = New System.Drawing.Point(214, 32)
        Me.txtNroRecibo.MaxLength = 9
        Me.txtNroRecibo.Name = "txtNroRecibo"
        Me.txtNroRecibo.Size = New System.Drawing.Size(79, 20)
        Me.txtNroRecibo.TabIndex = 6
        Me.txtNroRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(6, 142)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 25
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
        Me.txtObservacion.Location = New System.Drawing.Point(6, 157)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.Size = New System.Drawing.Size(557, 20)
        Me.txtObservacion.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalNCND)
        Me.GroupBox1.Controls.Add(Me.lblTotalNCND)
        Me.GroupBox1.Controls.Add(Me.txtSaldoActual)
        Me.GroupBox1.Controls.Add(Me.lblSaldoActual)
        Me.GroupBox1.Controls.Add(Me.txtDiferencia)
        Me.GroupBox1.Controls.Add(Me.lblDiferencia)
        Me.GroupBox1.Controls.Add(Me.txtComprobantes)
        Me.GroupBox1.Controls.Add(Me.lblBruto)
        Me.GroupBox1.Controls.Add(Me.txtTotalPago)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(569, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 102)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totales"
        '
        'txtTotalNCND
        '
        Me.txtTotalNCND.BindearPropiedadControl = Nothing
        Me.txtTotalNCND.BindearPropiedadEntidad = Nothing
        Me.txtTotalNCND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNCND.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalNCND.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalNCND.Formato = "##,##0.00"
        Me.txtTotalNCND.IsDecimal = True
        Me.txtTotalNCND.IsNumber = True
        Me.txtTotalNCND.IsPK = False
        Me.txtTotalNCND.IsRequired = False
        Me.txtTotalNCND.Key = ""
        Me.txtTotalNCND.LabelAsoc = Me.lblTotalNCND
        Me.txtTotalNCND.Location = New System.Drawing.Point(236, 14)
        Me.txtTotalNCND.Name = "txtTotalNCND"
        Me.txtTotalNCND.ReadOnly = True
        Me.txtTotalNCND.Size = New System.Drawing.Size(80, 21)
        Me.txtTotalNCND.TabIndex = 10
        Me.txtTotalNCND.TabStop = False
        Me.txtTotalNCND.Text = "0.00"
        Me.txtTotalNCND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalNCND
        '
        Me.lblTotalNCND.AutoSize = True
        Me.lblTotalNCND.LabelAsoc = Nothing
        Me.lblTotalNCND.Location = New System.Drawing.Point(190, 18)
        Me.lblTotalNCND.Name = "lblTotalNCND"
        Me.lblTotalNCND.Size = New System.Drawing.Size(43, 13)
        Me.lblTotalNCND.TabIndex = 0
        Me.lblTotalNCND.Text = "NC/ND"
        '
        'txtSaldoActual
        '
        Me.txtSaldoActual.BindearPropiedadControl = Nothing
        Me.txtSaldoActual.BindearPropiedadEntidad = Nothing
        Me.txtSaldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoActual.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoActual.Formato = "##,##0.00"
        Me.txtSaldoActual.IsDecimal = True
        Me.txtSaldoActual.IsNumber = True
        Me.txtSaldoActual.IsPK = False
        Me.txtSaldoActual.IsRequired = False
        Me.txtSaldoActual.Key = ""
        Me.txtSaldoActual.LabelAsoc = Me.lblSaldoActual
        Me.txtSaldoActual.Location = New System.Drawing.Point(236, 72)
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.ReadOnly = True
        Me.txtSaldoActual.Size = New System.Drawing.Size(80, 21)
        Me.txtSaldoActual.TabIndex = 8
        Me.txtSaldoActual.TabStop = False
        Me.txtSaldoActual.Text = "0.00"
        Me.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSaldoActual.LabelAsoc = Nothing
        Me.lblSaldoActual.Location = New System.Drawing.Point(165, 76)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(67, 13)
        Me.lblSaldoActual.TabIndex = 9
        Me.lblSaldoActual.Text = "Saldo Actual"
        '
        'txtDiferencia
        '
        Me.txtDiferencia.BindearPropiedadControl = Nothing
        Me.txtDiferencia.BindearPropiedadEntidad = Nothing
        Me.txtDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiferencia.Formato = "##,##0.00"
        Me.txtDiferencia.IsDecimal = True
        Me.txtDiferencia.IsNumber = True
        Me.txtDiferencia.IsPK = False
        Me.txtDiferencia.IsRequired = False
        Me.txtDiferencia.Key = ""
        Me.txtDiferencia.LabelAsoc = Me.lblDiferencia
        Me.txtDiferencia.Location = New System.Drawing.Point(81, 72)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.ReadOnly = True
        Me.txtDiferencia.Size = New System.Drawing.Size(80, 21)
        Me.txtDiferencia.TabIndex = 5
        Me.txtDiferencia.TabStop = False
        Me.txtDiferencia.Text = "0.00"
        Me.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiferencia
        '
        Me.lblDiferencia.AutoSize = True
        Me.lblDiferencia.LabelAsoc = Nothing
        Me.lblDiferencia.Location = New System.Drawing.Point(6, 76)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(55, 13)
        Me.lblDiferencia.TabIndex = 6
        Me.lblDiferencia.Text = "Diferencia"
        '
        'txtComprobantes
        '
        Me.txtComprobantes.BindearPropiedadControl = Nothing
        Me.txtComprobantes.BindearPropiedadEntidad = Nothing
        Me.txtComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprobantes.Formato = "##,##0.00"
        Me.txtComprobantes.IsDecimal = True
        Me.txtComprobantes.IsNumber = True
        Me.txtComprobantes.IsPK = False
        Me.txtComprobantes.IsRequired = False
        Me.txtComprobantes.Key = ""
        Me.txtComprobantes.LabelAsoc = Me.lblBruto
        Me.txtComprobantes.Location = New System.Drawing.Point(81, 14)
        Me.txtComprobantes.Name = "txtComprobantes"
        Me.txtComprobantes.ReadOnly = True
        Me.txtComprobantes.Size = New System.Drawing.Size(80, 21)
        Me.txtComprobantes.TabIndex = 0
        Me.txtComprobantes.TabStop = False
        Me.txtComprobantes.Text = "0.00"
        Me.txtComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBruto
        '
        Me.lblBruto.AutoSize = True
        Me.lblBruto.LabelAsoc = Nothing
        Me.lblBruto.Location = New System.Drawing.Point(5, 18)
        Me.lblBruto.Name = "lblBruto"
        Me.lblBruto.Size = New System.Drawing.Size(75, 13)
        Me.lblBruto.TabIndex = 1
        Me.lblBruto.Text = "Comprobantes"
        '
        'txtTotalPago
        '
        Me.txtTotalPago.BindearPropiedadControl = Nothing
        Me.txtTotalPago.BindearPropiedadEntidad = Nothing
        Me.txtTotalPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPago.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalPago.Formato = "##,##0.00"
        Me.txtTotalPago.IsDecimal = True
        Me.txtTotalPago.IsNumber = True
        Me.txtTotalPago.IsPK = False
        Me.txtTotalPago.IsRequired = False
        Me.txtTotalPago.Key = ""
        Me.txtTotalPago.LabelAsoc = Me.lblTotal
        Me.txtTotalPago.Location = New System.Drawing.Point(81, 37)
        Me.txtTotalPago.Name = "txtTotalPago"
        Me.txtTotalPago.ReadOnly = True
        Me.txtTotalPago.Size = New System.Drawing.Size(80, 21)
        Me.txtTotalPago.TabIndex = 3
        Me.txtTotalPago.TabStop = False
        Me.txtTotalPago.Text = "0.00"
        Me.txtTotalPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.LabelAsoc = Nothing
        Me.lblTotal.Location = New System.Drawing.Point(5, 44)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblTotal.TabIndex = 4
        Me.lblTotal.Text = "Pagos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(79, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "_____________"
        '
        'txtCategoriaFiscal
        '
        Me.txtCategoriaFiscal.BindearPropiedadControl = Nothing
        Me.txtCategoriaFiscal.BindearPropiedadEntidad = Nothing
        Me.txtCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCategoriaFiscal.Formato = ""
        Me.txtCategoriaFiscal.IsDecimal = False
        Me.txtCategoriaFiscal.IsNumber = False
        Me.txtCategoriaFiscal.IsPK = False
        Me.txtCategoriaFiscal.IsRequired = False
        Me.txtCategoriaFiscal.Key = ""
        Me.txtCategoriaFiscal.LabelAsoc = Me.lblLocalidad
        Me.txtCategoriaFiscal.Location = New System.Drawing.Point(319, 118)
        Me.txtCategoriaFiscal.Name = "txtCategoriaFiscal"
        Me.txtCategoriaFiscal.ReadOnly = True
        Me.txtCategoriaFiscal.Size = New System.Drawing.Size(120, 20)
        Me.txtCategoriaFiscal.TabIndex = 19
        '
        'lblCategoriaFiscal
        '
        Me.lblCategoriaFiscal.AutoSize = True
        Me.lblCategoriaFiscal.Location = New System.Drawing.Point(316, 104)
        Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
        Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
        Me.lblCategoriaFiscal.TabIndex = 20
        Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
        '
        'txtLocalidad
        '
        Me.txtLocalidad.BindearPropiedadControl = Nothing
        Me.txtLocalidad.BindearPropiedadEntidad = Nothing
        Me.txtLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLocalidad.Formato = ""
        Me.txtLocalidad.IsDecimal = False
        Me.txtLocalidad.IsNumber = False
        Me.txtLocalidad.IsPK = False
        Me.txtLocalidad.IsRequired = False
        Me.txtLocalidad.Key = ""
        Me.txtLocalidad.LabelAsoc = Me.lblLocalidad
        Me.txtLocalidad.Location = New System.Drawing.Point(196, 118)
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.ReadOnly = True
        Me.txtLocalidad.Size = New System.Drawing.Size(120, 20)
        Me.txtLocalidad.TabIndex = 17
        '
        'txtDireccion
        '
        Me.txtDireccion.BindearPropiedadControl = Nothing
        Me.txtDireccion.BindearPropiedadEntidad = Nothing
        Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDireccion.Formato = ""
        Me.txtDireccion.IsDecimal = False
        Me.txtDireccion.IsNumber = False
        Me.txtDireccion.IsPK = False
        Me.txtDireccion.IsRequired = False
        Me.txtDireccion.Key = ""
        Me.txtDireccion.LabelAsoc = Me.lblDireccion
        Me.txtDireccion.Location = New System.Drawing.Point(6, 118)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(183, 20)
        Me.txtDireccion.TabIndex = 15
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.LabelAsoc = Nothing
        Me.lblDireccion.Location = New System.Drawing.Point(6, 102)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
        Me.lblDireccion.TabIndex = 16
        Me.lblDireccion.Text = "Dirección"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(367, 16)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 10
        Me.lblFecha.Text = "Fecha"
        '
        'tspFacturacion
        '
        Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbGrabar, Me.tsbSalir, Me.tsbAnular})
        Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.tspFacturacion.Name = "tspFacturacion"
        Me.tspFacturacion.Size = New System.Drawing.Size(962, 25)
        Me.tspFacturacion.TabIndex = 2
        Me.tspFacturacion.Text = "ToolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(98, 22)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(85, 22)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        Me.tsbGrabar.ToolTipText = "Anular (F4)"
        Me.tsbGrabar.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'tsbAnular
        '
        Me.tsbAnular.Enabled = False
        Me.tsbAnular.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(85, 22)
        Me.tsbAnular.Text = "&Anular (F4)"
        Me.tsbAnular.ToolTipText = "Anular (F4)"
        '
        'AnularRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(962, 515)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Controls.Add(Me.grbCliente)
        Me.Controls.Add(Me.tspFacturacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "AnularRecibos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpComprobantes.ResumeLayout(False)
        CType(Me.dgvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpPagos.ResumeLayout(False)
        Me.tbpPagos.PerformLayout()
        Me.tbcDetalle2.ResumeLayout(False)
        Me.tbpCheques.ResumeLayout(False)
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpRetenciones.ResumeLayout(False)
        CType(Me.dgvRetenciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tspFacturacion.ResumeLayout(False)
        Me.tspFacturacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents txtLocalidad As Eniac.Controles.TextBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents txtTotalPago As Eniac.Controles.TextBox
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents txtComprobantes As Eniac.Controles.TextBox
   Friend WithEvents lblBruto As Eniac.Controles.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
   Friend WithEvents tbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents dgvComprobantes As Eniac.Controles.DataGridView
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents txtCategoriaFiscal As Eniac.Controles.TextBox
   Friend WithEvents lblCategoriaFiscal As System.Windows.Forms.Label
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents tbpPagos As System.Windows.Forms.TabPage
   Friend WithEvents lblEfectivo As Eniac.Controles.Label
   Friend WithEvents txtEfectivo As Eniac.Controles.TextBox
   Friend WithEvents txtDiferencia As Eniac.Controles.TextBox
   Friend WithEvents lblDiferencia As Eniac.Controles.Label
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents txtSaldoActual As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoActual As Eniac.Controles.Label
   Friend WithEvents lblTarjetas As Eniac.Controles.Label
   Friend WithEvents txtTarjetas As Eniac.Controles.TextBox
   Friend WithEvents txtNroRecibo As Eniac.Controles.TextBox
   Friend WithEvents lblNroRecibo As Eniac.Controles.Label
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents txtLetra As Eniac.Controles.TextBox
   Friend WithEvents lblEmisorRecibo As Eniac.Controles.Label
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents lblCheques As Eniac.Controles.Label
   Friend WithEvents txtCheques As Eniac.Controles.TextBox
   Friend WithEvents txtNombreCliente As Eniac.Controles.TextBox
   Friend WithEvents txtCodigoCliente As Eniac.Controles.TextBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents lblTransferenciaBancaria As Eniac.Controles.Label
   Friend WithEvents txtTransferenciaBancaria As Eniac.Controles.TextBox
   Friend WithEvents txtNombreVendedor As Eniac.Controles.TextBox
   Friend WithEvents lblNombreVendedor As System.Windows.Forms.Label
   Friend WithEvents lblRetenciones As Eniac.Controles.Label
   Friend WithEvents txtRetenciones As Eniac.Controles.TextBox
   Friend WithEvents tbcDetalle2 As System.Windows.Forms.TabControl
   Friend WithEvents tbpCheques As System.Windows.Forms.TabPage
   Friend WithEvents dgvCheques As Eniac.Controles.DataGridView
   Friend WithEvents tbpRetenciones As System.Windows.Forms.TabPage
   Friend WithEvents dgvRetenciones As Eniac.Controles.DataGridView
   Friend WithEvents gretIdTipoImpuesto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretNombreTipoImpuesto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretEmisorRetencion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretNumeroRetencion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretFechaEmision As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretBaseImponible As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretAlicuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretClienteTipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretClienteNroDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretTipoImpuesto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretNroPlanillaIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretNroMovimientoIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretPassword As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretIdEstado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretRowState As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretIdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretLetraComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretEmisorComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretNumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretFechaComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gretImporteComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents txtTotalNCND As Eniac.Controles.TextBox
   Friend WithEvents lblTotalNCND As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantesRec As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoComprobanteRec As Eniac.Controles.Label
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscCuentaBancariaTransfBanc As Eniac.Controles.Buscador
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaEmision As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Paga As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargoPorc As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CuentaCorriente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobante1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FormaPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FormasPagoDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents dtpFechaEmision As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpFechaTransferencia As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaTransferencia As Eniac.Controles.Label
   Friend WithEvents gchIdBanco As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchNombreBanco As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchIdBancoSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchCP As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchNumeroCheque As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchFechaEmision As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchFechaCobro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchTitular As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CUIT As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchImporte As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchClienteTipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchClienteNroDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchBanco As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchNroPlanillaIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchNroMovimientoIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchNroPlanillaEgreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchNroMovimientoEgreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchPassword As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchCuentaBancaria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchIdCuentaBancaria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchNombreCuentaBancaria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchEsPropio As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchIdEstadoCheque As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchIdEstadoChequeAnt As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchRowState As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gchIdSucursal2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCajaIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCajaEgreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FotoFrente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FotoDorso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProveedorPreasignado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoProveedorPreasignado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ProveedorPreasignado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CajaDetalleParaIngresoDirectoPorABM As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCuentaDeCaja As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cmbVendedor As Controles.ComboBox
    Friend WithEvents chbNroOrdenDeCompra As Controles.CheckBox
    Friend WithEvents bscNroOrdenDeCompra As Controles.Buscador2
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
End Class
