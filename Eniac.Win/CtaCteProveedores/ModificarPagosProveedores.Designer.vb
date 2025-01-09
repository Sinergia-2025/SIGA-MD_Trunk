<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModificarPagosProveedores
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tbcDetalle = New System.Windows.Forms.TabControl()
        Me.tbpComprobantes = New System.Windows.Forms.TabPage()
        Me.dgvComprobantes = New Eniac.Controles.DataGridView()
        Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaCorrienteProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobante1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormasPagoDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargoPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpPagos1 = New System.Windows.Forms.TabPage()
        Me.bscCuentaBancariaTransfBanc = New Eniac.Controles.Buscador()
        Me.Label1 = New Eniac.Controles.Label()
        Me.txtDolares = New Eniac.Controles.TextBox()
        Me.lblRetenciones = New Eniac.Controles.Label()
        Me.txtRetenciones = New Eniac.Controles.TextBox()
        Me.lblTotal = New Eniac.Controles.Label()
        Me.lblTickets = New Eniac.Controles.Label()
        Me.lblChequesPropios = New Eniac.Controles.Label()
        Me.txtTickets = New Eniac.Controles.TextBox()
        Me.txtChequesPropios = New Eniac.Controles.TextBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.lblTarjetas = New Eniac.Controles.Label()
        Me.lblTransferenciaBancaria = New Eniac.Controles.Label()
        Me.txtTarjetas = New Eniac.Controles.TextBox()
        Me.txtTransferenciaBancaria = New Eniac.Controles.TextBox()
        Me.grbChequesPropios = New System.Windows.Forms.GroupBox()
        Me.dgvChequesPropios = New Eniac.Controles.DataGridView()
        Me.IdCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BancoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Localidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroPlanillaRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroMovimientoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroPlanillaEntregado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroMovimientoEntregado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PwdCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSucursalCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProveedorTipoDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProveedorNroDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gTitular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EsPropio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdEstadoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdEstadoChequeAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdSucursal2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdCajaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdCajaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FotoFrente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FotoDorso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblEfectivo = New Eniac.Controles.Label()
        Me.txtEfectivo = New Eniac.Controles.TextBox()
        Me.tbpPagos2 = New System.Windows.Forms.TabPage()
        Me.lblChequesTerceros = New Eniac.Controles.Label()
        Me.txtChequesTerceros = New Eniac.Controles.TextBox()
        Me.grbChequesTerceros = New System.Windows.Forms.GroupBox()
        Me.dgvChequesTerceros = New Eniac.Controles.DataGridView()
        Me.gchtNombreBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdBancoSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtCP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtNumeroCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtFechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtFechaCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtTitular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtRowState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtClienteTipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtClienteNroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtNroPlanillaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtNroMovimientoIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtNroPlanillaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtNroMovimientoEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtNombreCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtEsPropio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdEstadoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdEstadoChequeAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdSucursal2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdCajaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gchtIdCajaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FotoFrente1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FotoDorso1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblLocalidad = New Eniac.Controles.Label()
        Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.lblTipoComprobanteRec = New Eniac.Controles.Label()
        Me.grbCajas = New System.Windows.Forms.GroupBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.lblObservacion = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.txtNombreProveedor = New Eniac.Controles.TextBox()
        Me.lblNombreProveedor = New Eniac.Controles.Label()
        Me.txtCodigoProveedor = New Eniac.Controles.TextBox()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.lblEmisorRecibo = New Eniac.Controles.Label()
        Me.txtEmisor = New Eniac.Controles.TextBox()
        Me.lblLetra = New Eniac.Controles.Label()
        Me.txtLetra = New Eniac.Controles.TextBox()
        Me.lblNroPago = New Eniac.Controles.Label()
        Me.txtNroPago = New Eniac.Controles.TextBox()
        Me.txtCategoriaFiscal = New Eniac.Controles.TextBox()
        Me.lblCategoriaFiscal = New System.Windows.Forms.Label()
        Me.txtLocalidad = New Eniac.Controles.TextBox()
        Me.txtDireccion = New Eniac.Controles.TextBox()
        Me.lblDireccion = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSaldoActual = New Eniac.Controles.TextBox()
        Me.lblSaldoActual = New Eniac.Controles.Label()
        Me.txtDiferencia = New Eniac.Controles.TextBox()
        Me.lblDiferencia = New Eniac.Controles.Label()
        Me.txtComprobantes = New Eniac.Controles.TextBox()
        Me.lblBruto = New Eniac.Controles.Label()
        Me.txtTotalPago = New Eniac.Controles.TextBox()
        Me.Label5 = New Eniac.Controles.Label()
        Me.cmbTiposComprobantesPag = New Eniac.Controles.ComboBox()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.dtpFechaEmision = New Eniac.Controles.DateTimePicker()
        Me.tspFacturacion.SuspendLayout()
        Me.tbcDetalle.SuspendLayout()
        Me.tbpComprobantes.SuspendLayout()
        CType(Me.dgvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpPagos1.SuspendLayout()
        Me.grbChequesPropios.SuspendLayout()
        CType(Me.dgvChequesPropios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpPagos2.SuspendLayout()
        Me.grbChequesTerceros.SuspendLayout()
        CType(Me.dgvChequesTerceros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCliente.SuspendLayout()
        Me.grbCajas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tspFacturacion
        '
        Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbGrabar, Me.tsbSalir})
        Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.tspFacturacion.Name = "tspFacturacion"
        Me.tspFacturacion.Size = New System.Drawing.Size(894, 25)
        Me.tspFacturacion.TabIndex = 3
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
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(85, 22)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        Me.tsbGrabar.ToolTipText = "Anular (F4)"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle.Controls.Add(Me.tbpComprobantes)
        Me.tbcDetalle.Controls.Add(Me.tbpPagos1)
        Me.tbcDetalle.Controls.Add(Me.tbpPagos2)
        Me.tbcDetalle.Location = New System.Drawing.Point(3, 188)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(889, 266)
        Me.tbcDetalle.TabIndex = 5
        Me.tbcDetalle.TabStop = False
        '
        'tbpComprobantes
        '
        Me.tbpComprobantes.Controls.Add(Me.dgvComprobantes)
        Me.tbpComprobantes.Location = New System.Drawing.Point(4, 22)
        Me.tbpComprobantes.Name = "tbpComprobantes"
        Me.tbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpComprobantes.Size = New System.Drawing.Size(881, 240)
        Me.tbpComprobantes.TabIndex = 0
        Me.tbpComprobantes.Text = "Comprobantes"
        Me.tbpComprobantes.UseVisualStyleBackColor = True
        '
        'dgvComprobantes
        '
        Me.dgvComprobantes.AllowUserToAddRows = False
        Me.dgvComprobantes.AllowUserToDeleteRows = False
        Me.dgvComprobantes.AllowUserToResizeRows = False
        Me.dgvComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprobantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoComprobante, Me.letra, Me.CentroEmisor, Me.NroComprobante, Me.Cuota, Me.Fecha, Me.FechaVencimiento, Me.Importe, Me.Stock, Me.Paga, Me.Password, Me.Usuario, Me.IdSucursal, Me.CuentaCorrienteProv, Me.TipoComprobante1, Me.FormaPago, Me.FormasPagoDescripcion, Me.DescuentoRecargoPorc, Me.DescuentoRecargo})
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvComprobantes.DefaultCellStyle = DataGridViewCellStyle35
        Me.dgvComprobantes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComprobantes.Location = New System.Drawing.Point(3, 6)
        Me.dgvComprobantes.MultiSelect = False
        Me.dgvComprobantes.Name = "dgvComprobantes"
        Me.dgvComprobantes.ReadOnly = True
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComprobantes.RowHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.dgvComprobantes.RowHeadersWidth = 20
        Me.dgvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComprobantes.Size = New System.Drawing.Size(875, 228)
        Me.dgvComprobantes.TabIndex = 10
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
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.letra.DefaultCellStyle = DataGridViewCellStyle26
        Me.letra.HeaderText = "L."
        Me.letra.Name = "letra"
        Me.letra.ReadOnly = True
        Me.letra.Width = 40
        '
        'CentroEmisor
        '
        Me.CentroEmisor.DataPropertyName = "CentroEmisor"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle27
        Me.CentroEmisor.HeaderText = "Emisor"
        Me.CentroEmisor.Name = "CentroEmisor"
        Me.CentroEmisor.ReadOnly = True
        Me.CentroEmisor.Width = 50
        '
        'NroComprobante
        '
        Me.NroComprobante.DataPropertyName = "NumeroComprobante"
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroComprobante.DefaultCellStyle = DataGridViewCellStyle28
        Me.NroComprobante.HeaderText = "Numero"
        Me.NroComprobante.Name = "NroComprobante"
        Me.NroComprobante.ReadOnly = True
        Me.NroComprobante.Width = 70
        '
        'Cuota
        '
        Me.Cuota.DataPropertyName = "Cuota"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cuota.DefaultCellStyle = DataGridViewCellStyle29
        Me.Cuota.HeaderText = "Cuota"
        Me.Cuota.Name = "Cuota"
        Me.Cuota.ReadOnly = True
        Me.Cuota.Width = 40
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle30.Format = "dd/MM/yyyy"
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle30
        Me.Fecha.HeaderText = "Emisión"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 80
        '
        'FechaVencimiento
        '
        Me.FechaVencimiento.DataPropertyName = "FechaVencimiento"
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle31.Format = "dd/MM/yyyy"
        DataGridViewCellStyle31.NullValue = Nothing
        Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle31
        Me.FechaVencimiento.HeaderText = "Vence"
        Me.FechaVencimiento.Name = "FechaVencimiento"
        Me.FechaVencimiento.ReadOnly = True
        Me.FechaVencimiento.Width = 80
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "ImporteCuota"
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle32.Format = "N2"
        DataGridViewCellStyle32.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle32
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 90
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "SaldoCuota"
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle33.Format = "N2"
        DataGridViewCellStyle33.NullValue = Nothing
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle33
        Me.Stock.HeaderText = "Saldo"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 90
        '
        'Paga
        '
        Me.Paga.DataPropertyName = "Paga"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle34.Format = "N2"
        DataGridViewCellStyle34.NullValue = Nothing
        Me.Paga.DefaultCellStyle = DataGridViewCellStyle34
        Me.Paga.HeaderText = "Paga"
        Me.Paga.Name = "Paga"
        Me.Paga.ReadOnly = True
        Me.Paga.Width = 90
        '
        'Password
        '
        Me.Password.DataPropertyName = "Password"
        Me.Password.HeaderText = "Password"
        Me.Password.Name = "Password"
        Me.Password.ReadOnly = True
        Me.Password.Visible = False
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        Me.Usuario.Visible = False
        '
        'IdSucursal
        '
        Me.IdSucursal.DataPropertyName = "IdSucursal"
        Me.IdSucursal.HeaderText = "IdSucursal"
        Me.IdSucursal.Name = "IdSucursal"
        Me.IdSucursal.ReadOnly = True
        Me.IdSucursal.Visible = False
        '
        'CuentaCorrienteProv
        '
        Me.CuentaCorrienteProv.DataPropertyName = "CuentaCorrienteProv"
        Me.CuentaCorrienteProv.HeaderText = "CuentaCorrienteProv"
        Me.CuentaCorrienteProv.Name = "CuentaCorrienteProv"
        Me.CuentaCorrienteProv.ReadOnly = True
        Me.CuentaCorrienteProv.Visible = False
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
        'DescuentoRecargoPorc
        '
        Me.DescuentoRecargoPorc.DataPropertyName = "DescuentoRecargoPorc"
        Me.DescuentoRecargoPorc.HeaderText = "DescuentoRecargoPorc"
        Me.DescuentoRecargoPorc.Name = "DescuentoRecargoPorc"
        Me.DescuentoRecargoPorc.ReadOnly = True
        Me.DescuentoRecargoPorc.Visible = False
        '
        'DescuentoRecargo
        '
        Me.DescuentoRecargo.DataPropertyName = "DescuentoRecargo"
        Me.DescuentoRecargo.HeaderText = "DescuentoRecargo"
        Me.DescuentoRecargo.Name = "DescuentoRecargo"
        Me.DescuentoRecargo.ReadOnly = True
        Me.DescuentoRecargo.Visible = False
        '
        'tbpPagos1
        '
        Me.tbpPagos1.Controls.Add(Me.bscCuentaBancariaTransfBanc)
        Me.tbpPagos1.Controls.Add(Me.Label1)
        Me.tbpPagos1.Controls.Add(Me.txtDolares)
        Me.tbpPagos1.Controls.Add(Me.lblRetenciones)
        Me.tbpPagos1.Controls.Add(Me.txtRetenciones)
        Me.tbpPagos1.Controls.Add(Me.lblTickets)
        Me.tbpPagos1.Controls.Add(Me.lblChequesPropios)
        Me.tbpPagos1.Controls.Add(Me.txtTickets)
        Me.tbpPagos1.Controls.Add(Me.txtChequesPropios)
        Me.tbpPagos1.Controls.Add(Me.Label2)
        Me.tbpPagos1.Controls.Add(Me.lblTarjetas)
        Me.tbpPagos1.Controls.Add(Me.lblTransferenciaBancaria)
        Me.tbpPagos1.Controls.Add(Me.txtTarjetas)
        Me.tbpPagos1.Controls.Add(Me.txtTransferenciaBancaria)
        Me.tbpPagos1.Controls.Add(Me.grbChequesPropios)
        Me.tbpPagos1.Controls.Add(Me.lblEfectivo)
        Me.tbpPagos1.Controls.Add(Me.txtEfectivo)
        Me.tbpPagos1.Location = New System.Drawing.Point(4, 22)
        Me.tbpPagos1.Name = "tbpPagos1"
        Me.tbpPagos1.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPagos1.Size = New System.Drawing.Size(881, 240)
        Me.tbpPagos1.TabIndex = 1
        Me.tbpPagos1.Text = "Pagos (Efectivo y Cheques Propios)"
        Me.tbpPagos1.UseVisualStyleBackColor = True
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
        Me.bscCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCuentaBancariaTransfBanc.IsPK = False
        Me.bscCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCuentaBancariaTransfBanc.Key = ""
        Me.bscCuentaBancariaTransfBanc.LabelAsoc = Nothing
        Me.bscCuentaBancariaTransfBanc.Location = New System.Drawing.Point(590, 8)
        Me.bscCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCuentaBancariaTransfBanc.Name = "bscCuentaBancariaTransfBanc"
        Me.bscCuentaBancariaTransfBanc.Permitido = True
        Me.bscCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCuentaBancariaTransfBanc.Size = New System.Drawing.Size(200, 20)
        Me.bscCuentaBancariaTransfBanc.TabIndex = 98
        Me.bscCuentaBancariaTransfBanc.Titulo = "Clientes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(544, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Dólares"
        '
        'txtDolares
        '
        Me.txtDolares.BindearPropiedadControl = Nothing
        Me.txtDolares.BindearPropiedadEntidad = Nothing
        Me.txtDolares.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDolares.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDolares.Formato = "##0.00"
        Me.txtDolares.IsDecimal = True
        Me.txtDolares.IsNumber = True
        Me.txtDolares.IsPK = False
        Me.txtDolares.IsRequired = False
        Me.txtDolares.Key = ""
        Me.txtDolares.LabelAsoc = Me.Label1
        Me.txtDolares.Location = New System.Drawing.Point(589, 38)
        Me.txtDolares.Name = "txtDolares"
        Me.txtDolares.ReadOnly = True
        Me.txtDolares.Size = New System.Drawing.Size(70, 20)
        Me.txtDolares.TabIndex = 96
        Me.txtDolares.Text = "0.00"
        Me.txtDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRetenciones
        '
        Me.lblRetenciones.AutoSize = True
        Me.lblRetenciones.LabelAsoc = Nothing
        Me.lblRetenciones.Location = New System.Drawing.Point(377, 42)
        Me.lblRetenciones.Name = "lblRetenciones"
        Me.lblRetenciones.Size = New System.Drawing.Size(67, 13)
        Me.lblRetenciones.TabIndex = 95
        Me.lblRetenciones.Text = "Retenciones"
        '
        'txtRetenciones
        '
        Me.txtRetenciones.BindearPropiedadControl = Nothing
        Me.txtRetenciones.BindearPropiedadEntidad = Nothing
        Me.txtRetenciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetenciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRetenciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRetenciones.Formato = "##,##0.00"
        Me.txtRetenciones.IsDecimal = True
        Me.txtRetenciones.IsNumber = True
        Me.txtRetenciones.IsPK = False
        Me.txtRetenciones.IsRequired = False
        Me.txtRetenciones.Key = ""
        Me.txtRetenciones.LabelAsoc = Me.lblTotal
        Me.txtRetenciones.Location = New System.Drawing.Point(466, 38)
        Me.txtRetenciones.Name = "txtRetenciones"
        Me.txtRetenciones.ReadOnly = True
        Me.txtRetenciones.Size = New System.Drawing.Size(70, 20)
        Me.txtRetenciones.TabIndex = 94
        Me.txtRetenciones.TabStop = False
        Me.txtRetenciones.Text = "0.00"
        Me.txtRetenciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.LabelAsoc = Nothing
        Me.lblTotal.Location = New System.Drawing.Point(7, 44)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblTotal.TabIndex = 12
        Me.lblTotal.Text = "Pagos"
        '
        'lblTickets
        '
        Me.lblTickets.AutoSize = True
        Me.lblTickets.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTickets.LabelAsoc = Nothing
        Me.lblTickets.Location = New System.Drawing.Point(117, 42)
        Me.lblTickets.Name = "lblTickets"
        Me.lblTickets.Size = New System.Drawing.Size(42, 13)
        Me.lblTickets.TabIndex = 92
        Me.lblTickets.Text = "Tickets"
        '
        'lblChequesPropios
        '
        Me.lblChequesPropios.AutoSize = True
        Me.lblChequesPropios.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChequesPropios.LabelAsoc = Nothing
        Me.lblChequesPropios.Location = New System.Drawing.Point(245, 42)
        Me.lblChequesPropios.Name = "lblChequesPropios"
        Me.lblChequesPropios.Size = New System.Drawing.Size(49, 13)
        Me.lblChequesPropios.TabIndex = 92
        Me.lblChequesPropios.Text = "Cheques"
        '
        'txtTickets
        '
        Me.txtTickets.BindearPropiedadControl = Nothing
        Me.txtTickets.BindearPropiedadEntidad = Nothing
        Me.txtTickets.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTickets.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTickets.Formato = "##0.00"
        Me.txtTickets.IsDecimal = True
        Me.txtTickets.IsNumber = True
        Me.txtTickets.IsPK = False
        Me.txtTickets.IsRequired = False
        Me.txtTickets.Key = ""
        Me.txtTickets.LabelAsoc = Me.lblTickets
        Me.txtTickets.Location = New System.Drawing.Point(162, 38)
        Me.txtTickets.Name = "txtTickets"
        Me.txtTickets.ReadOnly = True
        Me.txtTickets.Size = New System.Drawing.Size(70, 20)
        Me.txtTickets.TabIndex = 91
        Me.txtTickets.Text = "0.00"
        Me.txtTickets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtChequesPropios
        '
        Me.txtChequesPropios.BindearPropiedadControl = Nothing
        Me.txtChequesPropios.BindearPropiedadEntidad = Nothing
        Me.txtChequesPropios.ForeColorFocus = System.Drawing.Color.Red
        Me.txtChequesPropios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtChequesPropios.Formato = "##0.00"
        Me.txtChequesPropios.IsDecimal = True
        Me.txtChequesPropios.IsNumber = True
        Me.txtChequesPropios.IsPK = False
        Me.txtChequesPropios.IsRequired = False
        Me.txtChequesPropios.Key = ""
        Me.txtChequesPropios.LabelAsoc = Me.lblChequesPropios
        Me.txtChequesPropios.Location = New System.Drawing.Point(298, 38)
        Me.txtChequesPropios.Name = "txtChequesPropios"
        Me.txtChequesPropios.ReadOnly = True
        Me.txtChequesPropios.Size = New System.Drawing.Size(70, 20)
        Me.txtChequesPropios.TabIndex = 91
        Me.txtChequesPropios.Text = "0.00"
        Me.txtChequesPropios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(546, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Cuenta"
        '
        'lblTarjetas
        '
        Me.lblTarjetas.AutoSize = True
        Me.lblTarjetas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTarjetas.LabelAsoc = Nothing
        Me.lblTarjetas.Location = New System.Drawing.Point(245, 12)
        Me.lblTarjetas.Name = "lblTarjetas"
        Me.lblTarjetas.Size = New System.Drawing.Size(45, 13)
        Me.lblTarjetas.TabIndex = 84
        Me.lblTarjetas.Text = "Tarjetas"
        '
        'lblTransferenciaBancaria
        '
        Me.lblTransferenciaBancaria.AutoSize = True
        Me.lblTransferenciaBancaria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTransferenciaBancaria.LabelAsoc = Nothing
        Me.lblTransferenciaBancaria.Location = New System.Drawing.Point(377, 12)
        Me.lblTransferenciaBancaria.Name = "lblTransferenciaBancaria"
        Me.lblTransferenciaBancaria.Size = New System.Drawing.Size(85, 13)
        Me.lblTransferenciaBancaria.TabIndex = 82
        Me.lblTransferenciaBancaria.Text = "Transf. Bancaria"
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
        Me.txtTarjetas.Location = New System.Drawing.Point(298, 9)
        Me.txtTarjetas.Name = "txtTarjetas"
        Me.txtTarjetas.ReadOnly = True
        Me.txtTarjetas.Size = New System.Drawing.Size(70, 20)
        Me.txtTarjetas.TabIndex = 1
        Me.txtTarjetas.Text = "0.00"
        Me.txtTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtTransferenciaBancaria.Location = New System.Drawing.Point(466, 9)
        Me.txtTransferenciaBancaria.Name = "txtTransferenciaBancaria"
        Me.txtTransferenciaBancaria.ReadOnly = True
        Me.txtTransferenciaBancaria.Size = New System.Drawing.Size(70, 20)
        Me.txtTransferenciaBancaria.TabIndex = 2
        Me.txtTransferenciaBancaria.Text = "0.00"
        Me.txtTransferenciaBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grbChequesPropios
        '
        Me.grbChequesPropios.Controls.Add(Me.dgvChequesPropios)
        Me.grbChequesPropios.Location = New System.Drawing.Point(4, 58)
        Me.grbChequesPropios.Name = "grbChequesPropios"
        Me.grbChequesPropios.Size = New System.Drawing.Size(871, 191)
        Me.grbChequesPropios.TabIndex = 74
        Me.grbChequesPropios.TabStop = False
        Me.grbChequesPropios.Text = "Cheques Propios"
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
        Me.dgvChequesPropios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCuentaBancaria, Me.NombreCuentaBancaria, Me.IdBanco, Me.BancoNombre, Me.Sucursal, Me.CP, Me.Localidad, Me.NroCheque, Me.FechaEmision, Me.FechaCobro, Me.ImporteCheque, Me.RowState, Me.Banco, Me.NroPlanillaRecibo, Me.NroMovimientoRecibo, Me.NroPlanillaEntregado, Me.NroMovimientoEntregado, Me.UsuarioCheque, Me.PwdCheque, Me.IdSucursalCheque, Me.Cliente, Me.ProveedorTipoDoc, Me.ProveedorNroDoc, Me.Proveedor, Me.gTitular, Me.CuentaBancaria, Me.EsPropio, Me.gIdEstadoCheque, Me.gIdEstadoChequeAnt, Me.gIdSucursal2, Me.gIdBanco, Me.gIdCajaIngreso, Me.gIdCajaEgreso, Me.FotoFrente, Me.FotoDorso})
        Me.dgvChequesPropios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvChequesPropios.Location = New System.Drawing.Point(2, 19)
        Me.dgvChequesPropios.MultiSelect = False
        Me.dgvChequesPropios.Name = "dgvChequesPropios"
        Me.dgvChequesPropios.ReadOnly = True
        Me.dgvChequesPropios.RowHeadersWidth = 20
        Me.dgvChequesPropios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvChequesPropios.Size = New System.Drawing.Size(867, 166)
        Me.dgvChequesPropios.TabIndex = 10
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
        Me.NombreCuentaBancaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreCuentaBancaria.DataPropertyName = "NombreCuentaBancaria"
        Me.NombreCuentaBancaria.HeaderText = "Cuenta Bancaria"
        Me.NombreCuentaBancaria.Name = "NombreCuentaBancaria"
        Me.NombreCuentaBancaria.ReadOnly = True
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
        Me.BancoNombre.Width = 150
        '
        'Sucursal
        '
        Me.Sucursal.DataPropertyName = "IdBancoSucursal"
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Sucursal.DefaultCellStyle = DataGridViewCellStyle37
        Me.Sucursal.HeaderText = "Suc."
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.ReadOnly = True
        Me.Sucursal.Width = 40
        '
        'CP
        '
        Me.CP.DataPropertyName = "CP"
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CP.DefaultCellStyle = DataGridViewCellStyle38
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
        Me.Localidad.Width = 120
        '
        'NroCheque
        '
        Me.NroCheque.DataPropertyName = "NumeroCheque"
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroCheque.DefaultCellStyle = DataGridViewCellStyle39
        Me.NroCheque.HeaderText = "Numero"
        Me.NroCheque.Name = "NroCheque"
        Me.NroCheque.ReadOnly = True
        Me.NroCheque.Width = 80
        '
        'FechaEmision
        '
        Me.FechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle40.Format = "dd/MM/yyyy"
        DataGridViewCellStyle40.NullValue = Nothing
        Me.FechaEmision.DefaultCellStyle = DataGridViewCellStyle40
        Me.FechaEmision.HeaderText = "Emision"
        Me.FechaEmision.Name = "FechaEmision"
        Me.FechaEmision.ReadOnly = True
        Me.FechaEmision.Width = 80
        '
        'FechaCobro
        '
        Me.FechaCobro.DataPropertyName = "FechaCobro"
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle41.Format = "dd/MM/yyyy"
        Me.FechaCobro.DefaultCellStyle = DataGridViewCellStyle41
        Me.FechaCobro.HeaderText = "Cobro"
        Me.FechaCobro.Name = "FechaCobro"
        Me.FechaCobro.ReadOnly = True
        Me.FechaCobro.Width = 80
        '
        'ImporteCheque
        '
        Me.ImporteCheque.DataPropertyName = "Importe"
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.Format = "N2"
        DataGridViewCellStyle42.NullValue = Nothing
        Me.ImporteCheque.DefaultCellStyle = DataGridViewCellStyle42
        Me.ImporteCheque.HeaderText = "Importe"
        Me.ImporteCheque.Name = "ImporteCheque"
        Me.ImporteCheque.ReadOnly = True
        '
        'RowState
        '
        Me.RowState.DataPropertyName = "RowState"
        Me.RowState.HeaderText = "RowState"
        Me.RowState.Name = "RowState"
        Me.RowState.ReadOnly = True
        Me.RowState.Visible = False
        '
        'Banco
        '
        Me.Banco.DataPropertyName = "Banco"
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.ReadOnly = True
        Me.Banco.Visible = False
        '
        'NroPlanillaRecibo
        '
        Me.NroPlanillaRecibo.DataPropertyName = "NroPlanillaIngreso"
        Me.NroPlanillaRecibo.HeaderText = "NroPlanillaRecibo"
        Me.NroPlanillaRecibo.Name = "NroPlanillaRecibo"
        Me.NroPlanillaRecibo.ReadOnly = True
        Me.NroPlanillaRecibo.Visible = False
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
        'NroMovimientoEntregado
        '
        Me.NroMovimientoEntregado.DataPropertyName = "NroMovimientoEgreso"
        Me.NroMovimientoEntregado.HeaderText = "NroMovimientoEntregado"
        Me.NroMovimientoEntregado.Name = "NroMovimientoEntregado"
        Me.NroMovimientoEntregado.ReadOnly = True
        Me.NroMovimientoEntregado.Visible = False
        '
        'UsuarioCheque
        '
        Me.UsuarioCheque.DataPropertyName = "Usuario"
        Me.UsuarioCheque.HeaderText = "Usuario"
        Me.UsuarioCheque.Name = "UsuarioCheque"
        Me.UsuarioCheque.ReadOnly = True
        Me.UsuarioCheque.Visible = False
        '
        'PwdCheque
        '
        Me.PwdCheque.DataPropertyName = "Password"
        Me.PwdCheque.HeaderText = "PwdCheque"
        Me.PwdCheque.Name = "PwdCheque"
        Me.PwdCheque.ReadOnly = True
        Me.PwdCheque.Visible = False
        '
        'IdSucursalCheque
        '
        Me.IdSucursalCheque.DataPropertyName = "IdSucursal"
        Me.IdSucursalCheque.HeaderText = "IdSucursalCheque"
        Me.IdSucursalCheque.Name = "IdSucursalCheque"
        Me.IdSucursalCheque.ReadOnly = True
        Me.IdSucursalCheque.Visible = False
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Visible = False
        '
        'ProveedorTipoDoc
        '
        Me.ProveedorTipoDoc.DataPropertyName = "ProveedorTipoDoc"
        Me.ProveedorTipoDoc.HeaderText = "ProveedorTipoDoc"
        Me.ProveedorTipoDoc.Name = "ProveedorTipoDoc"
        Me.ProveedorTipoDoc.ReadOnly = True
        Me.ProveedorTipoDoc.Visible = False
        '
        'ProveedorNroDoc
        '
        Me.ProveedorNroDoc.DataPropertyName = "ProveedorNroDoc"
        Me.ProveedorNroDoc.HeaderText = "ProveedorNroDoc"
        Me.ProveedorNroDoc.Name = "ProveedorNroDoc"
        Me.ProveedorNroDoc.ReadOnly = True
        Me.ProveedorNroDoc.Visible = False
        '
        'Proveedor
        '
        Me.Proveedor.DataPropertyName = "Proveedor"
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Visible = False
        '
        'gTitular
        '
        Me.gTitular.DataPropertyName = "Titular"
        Me.gTitular.HeaderText = "Titular"
        Me.gTitular.Name = "gTitular"
        Me.gTitular.ReadOnly = True
        Me.gTitular.Visible = False
        '
        'CuentaBancaria
        '
        Me.CuentaBancaria.DataPropertyName = "CuentaBancaria"
        Me.CuentaBancaria.HeaderText = "CuentaBancaria"
        Me.CuentaBancaria.Name = "CuentaBancaria"
        Me.CuentaBancaria.ReadOnly = True
        Me.CuentaBancaria.Visible = False
        Me.CuentaBancaria.Width = 110
        '
        'EsPropio
        '
        Me.EsPropio.DataPropertyName = "EsPropio"
        Me.EsPropio.HeaderText = "EsPropio"
        Me.EsPropio.Name = "EsPropio"
        Me.EsPropio.ReadOnly = True
        Me.EsPropio.Visible = False
        '
        'gIdEstadoCheque
        '
        Me.gIdEstadoCheque.DataPropertyName = "IdEstadoCheque"
        Me.gIdEstadoCheque.HeaderText = "IdEstadoCheque"
        Me.gIdEstadoCheque.Name = "gIdEstadoCheque"
        Me.gIdEstadoCheque.ReadOnly = True
        Me.gIdEstadoCheque.Visible = False
        '
        'gIdEstadoChequeAnt
        '
        Me.gIdEstadoChequeAnt.DataPropertyName = "IdEstadoChequeAnt"
        Me.gIdEstadoChequeAnt.HeaderText = "IdEstadoChequeAnt"
        Me.gIdEstadoChequeAnt.Name = "gIdEstadoChequeAnt"
        Me.gIdEstadoChequeAnt.ReadOnly = True
        Me.gIdEstadoChequeAnt.Visible = False
        '
        'gIdSucursal2
        '
        Me.gIdSucursal2.DataPropertyName = "IdSucursal2"
        Me.gIdSucursal2.HeaderText = "IdSucursal2"
        Me.gIdSucursal2.Name = "gIdSucursal2"
        Me.gIdSucursal2.ReadOnly = True
        Me.gIdSucursal2.Visible = False
        '
        'gIdBanco
        '
        Me.gIdBanco.DataPropertyName = "IdBanco"
        Me.gIdBanco.HeaderText = "gIdBanco"
        Me.gIdBanco.Name = "gIdBanco"
        Me.gIdBanco.ReadOnly = True
        Me.gIdBanco.Visible = False
        '
        'gIdCajaIngreso
        '
        Me.gIdCajaIngreso.DataPropertyName = "IdCajaIngreso"
        Me.gIdCajaIngreso.HeaderText = "gIdCajaIngreso"
        Me.gIdCajaIngreso.Name = "gIdCajaIngreso"
        Me.gIdCajaIngreso.ReadOnly = True
        Me.gIdCajaIngreso.Visible = False
        '
        'gIdCajaEgreso
        '
        Me.gIdCajaEgreso.DataPropertyName = "IdCajaEgreso"
        Me.gIdCajaEgreso.HeaderText = "gIdCajaEgreso"
        Me.gIdCajaEgreso.Name = "gIdCajaEgreso"
        Me.gIdCajaEgreso.ReadOnly = True
        Me.gIdCajaEgreso.Visible = False
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
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEfectivo.LabelAsoc = Nothing
        Me.lblEfectivo.Location = New System.Drawing.Point(123, 12)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(36, 13)
        Me.lblEfectivo.TabIndex = 63
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
        Me.txtEfectivo.Location = New System.Drawing.Point(162, 9)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.ReadOnly = True
        Me.txtEfectivo.Size = New System.Drawing.Size(70, 20)
        Me.txtEfectivo.TabIndex = 0
        Me.txtEfectivo.Text = "0,00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbpPagos2
        '
        Me.tbpPagos2.Controls.Add(Me.lblChequesTerceros)
        Me.tbpPagos2.Controls.Add(Me.txtChequesTerceros)
        Me.tbpPagos2.Controls.Add(Me.grbChequesTerceros)
        Me.tbpPagos2.Location = New System.Drawing.Point(4, 22)
        Me.tbpPagos2.Name = "tbpPagos2"
        Me.tbpPagos2.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPagos2.Size = New System.Drawing.Size(881, 240)
        Me.tbpPagos2.TabIndex = 2
        Me.tbpPagos2.Text = "Pagos (Cheques de Terceros)"
        Me.tbpPagos2.UseVisualStyleBackColor = True
        '
        'lblChequesTerceros
        '
        Me.lblChequesTerceros.AutoSize = True
        Me.lblChequesTerceros.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChequesTerceros.LabelAsoc = Nothing
        Me.lblChequesTerceros.Location = New System.Drawing.Point(648, 15)
        Me.lblChequesTerceros.Name = "lblChequesTerceros"
        Me.lblChequesTerceros.Size = New System.Drawing.Size(49, 13)
        Me.lblChequesTerceros.TabIndex = 94
        Me.lblChequesTerceros.Text = "Cheques"
        '
        'txtChequesTerceros
        '
        Me.txtChequesTerceros.BindearPropiedadControl = Nothing
        Me.txtChequesTerceros.BindearPropiedadEntidad = Nothing
        Me.txtChequesTerceros.ForeColorFocus = System.Drawing.Color.Red
        Me.txtChequesTerceros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtChequesTerceros.Formato = "##0.00"
        Me.txtChequesTerceros.IsDecimal = True
        Me.txtChequesTerceros.IsNumber = True
        Me.txtChequesTerceros.IsPK = False
        Me.txtChequesTerceros.IsRequired = False
        Me.txtChequesTerceros.Key = ""
        Me.txtChequesTerceros.LabelAsoc = Me.lblChequesTerceros
        Me.txtChequesTerceros.Location = New System.Drawing.Point(702, 12)
        Me.txtChequesTerceros.Name = "txtChequesTerceros"
        Me.txtChequesTerceros.ReadOnly = True
        Me.txtChequesTerceros.Size = New System.Drawing.Size(69, 20)
        Me.txtChequesTerceros.TabIndex = 93
        Me.txtChequesTerceros.Text = "0,00"
        Me.txtChequesTerceros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grbChequesTerceros
        '
        Me.grbChequesTerceros.Controls.Add(Me.dgvChequesTerceros)
        Me.grbChequesTerceros.Location = New System.Drawing.Point(3, 36)
        Me.grbChequesTerceros.Name = "grbChequesTerceros"
        Me.grbChequesTerceros.Size = New System.Drawing.Size(784, 213)
        Me.grbChequesTerceros.TabIndex = 75
        Me.grbChequesTerceros.TabStop = False
        Me.grbChequesTerceros.Text = "Cheques de Terceros"
        '
        'dgvChequesTerceros
        '
        Me.dgvChequesTerceros.AllowUserToAddRows = False
        Me.dgvChequesTerceros.AllowUserToDeleteRows = False
        Me.dgvChequesTerceros.AllowUserToResizeRows = False
        Me.dgvChequesTerceros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvChequesTerceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChequesTerceros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gchtNombreBanco, Me.gchtIdBancoSucursal, Me.gchtCP, Me.gchtNumeroCheque, Me.DataGridViewTextBoxColumn5, Me.gchtFechaEmision, Me.gchtFechaCobro, Me.gchtTitular, Me.gchtImporte, Me.gchtRowState, Me.gchtClienteTipoDocumento, Me.gchtClienteNroDocumento, Me.gchtBanco, Me.gchtNroPlanillaIngreso, Me.gchtNroMovimientoIngreso, Me.gchtNroPlanillaEgreso, Me.gchtNroMovimientoEgreso, Me.gchtUsuario, Me.gchtPassword, Me.gchtIdSucursal, Me.gchtCuentaBancaria, Me.gchtIdCuentaBancaria, Me.gchtNombreCuentaBancaria, Me.gchtEsPropio, Me.gchtIdEstadoCheque, Me.gchtIdEstadoChequeAnt, Me.gchtCliente, Me.gchtProveedor, Me.gchtIdSucursal2, Me.gchtIdBanco, Me.gchtIdCajaIngreso, Me.gchtIdCajaEgreso, Me.FotoFrente1, Me.FotoDorso1})
        Me.dgvChequesTerceros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvChequesTerceros.Location = New System.Drawing.Point(4, 19)
        Me.dgvChequesTerceros.MultiSelect = False
        Me.dgvChequesTerceros.Name = "dgvChequesTerceros"
        Me.dgvChequesTerceros.ReadOnly = True
        Me.dgvChequesTerceros.RowHeadersWidth = 20
        Me.dgvChequesTerceros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvChequesTerceros.Size = New System.Drawing.Size(780, 191)
        Me.dgvChequesTerceros.TabIndex = 13
        '
        'gchtNombreBanco
        '
        Me.gchtNombreBanco.DataPropertyName = "NombreBanco"
        Me.gchtNombreBanco.HeaderText = "Nombre Banco"
        Me.gchtNombreBanco.Name = "gchtNombreBanco"
        Me.gchtNombreBanco.ReadOnly = True
        Me.gchtNombreBanco.Width = 120
        '
        'gchtIdBancoSucursal
        '
        Me.gchtIdBancoSucursal.DataPropertyName = "IdBancoSucursal"
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gchtIdBancoSucursal.DefaultCellStyle = DataGridViewCellStyle43
        Me.gchtIdBancoSucursal.HeaderText = "Suc."
        Me.gchtIdBancoSucursal.Name = "gchtIdBancoSucursal"
        Me.gchtIdBancoSucursal.ReadOnly = True
        Me.gchtIdBancoSucursal.Width = 40
        '
        'gchtCP
        '
        Me.gchtCP.DataPropertyName = "CP"
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gchtCP.DefaultCellStyle = DataGridViewCellStyle44
        Me.gchtCP.HeaderText = "C.P."
        Me.gchtCP.Name = "gchtCP"
        Me.gchtCP.ReadOnly = True
        Me.gchtCP.Width = 40
        '
        'gchtNumeroCheque
        '
        Me.gchtNumeroCheque.DataPropertyName = "NumeroCheque"
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gchtNumeroCheque.DefaultCellStyle = DataGridViewCellStyle45
        Me.gchtNumeroCheque.HeaderText = "Numero"
        Me.gchtNumeroCheque.Name = "gchtNumeroCheque"
        Me.gchtNumeroCheque.ReadOnly = True
        Me.gchtNumeroCheque.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Localidad"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Localidad"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'gchtFechaEmision
        '
        Me.gchtFechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle46.Format = "d"
        DataGridViewCellStyle46.NullValue = Nothing
        Me.gchtFechaEmision.DefaultCellStyle = DataGridViewCellStyle46
        Me.gchtFechaEmision.HeaderText = "Emision"
        Me.gchtFechaEmision.Name = "gchtFechaEmision"
        Me.gchtFechaEmision.ReadOnly = True
        Me.gchtFechaEmision.Width = 70
        '
        'gchtFechaCobro
        '
        Me.gchtFechaCobro.DataPropertyName = "FechaCobro"
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle47.Format = "d"
        Me.gchtFechaCobro.DefaultCellStyle = DataGridViewCellStyle47
        Me.gchtFechaCobro.HeaderText = "Cobro"
        Me.gchtFechaCobro.Name = "gchtFechaCobro"
        Me.gchtFechaCobro.ReadOnly = True
        Me.gchtFechaCobro.Width = 70
        '
        'gchtTitular
        '
        Me.gchtTitular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gchtTitular.DataPropertyName = "Titular"
        Me.gchtTitular.HeaderText = "Titular"
        Me.gchtTitular.Name = "gchtTitular"
        Me.gchtTitular.ReadOnly = True
        '
        'gchtImporte
        '
        Me.gchtImporte.DataPropertyName = "Importe"
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle48.Format = "N2"
        DataGridViewCellStyle48.NullValue = Nothing
        Me.gchtImporte.DefaultCellStyle = DataGridViewCellStyle48
        Me.gchtImporte.HeaderText = "Importe"
        Me.gchtImporte.Name = "gchtImporte"
        Me.gchtImporte.ReadOnly = True
        '
        'gchtRowState
        '
        Me.gchtRowState.DataPropertyName = "RowState"
        Me.gchtRowState.HeaderText = "RowState"
        Me.gchtRowState.Name = "gchtRowState"
        Me.gchtRowState.ReadOnly = True
        Me.gchtRowState.Visible = False
        '
        'gchtClienteTipoDocumento
        '
        Me.gchtClienteTipoDocumento.DataPropertyName = "ClienteTipoDocumento"
        Me.gchtClienteTipoDocumento.HeaderText = "ClienteTipoDocumento"
        Me.gchtClienteTipoDocumento.Name = "gchtClienteTipoDocumento"
        Me.gchtClienteTipoDocumento.ReadOnly = True
        Me.gchtClienteTipoDocumento.Visible = False
        '
        'gchtClienteNroDocumento
        '
        Me.gchtClienteNroDocumento.DataPropertyName = "ClienteNroDocumento"
        Me.gchtClienteNroDocumento.HeaderText = "ClienteNroDocumento"
        Me.gchtClienteNroDocumento.Name = "gchtClienteNroDocumento"
        Me.gchtClienteNroDocumento.ReadOnly = True
        Me.gchtClienteNroDocumento.Visible = False
        '
        'gchtBanco
        '
        Me.gchtBanco.DataPropertyName = "Banco"
        Me.gchtBanco.HeaderText = "Banco"
        Me.gchtBanco.Name = "gchtBanco"
        Me.gchtBanco.ReadOnly = True
        Me.gchtBanco.Visible = False
        '
        'gchtNroPlanillaIngreso
        '
        Me.gchtNroPlanillaIngreso.DataPropertyName = "NroPlanillaIngreso"
        Me.gchtNroPlanillaIngreso.HeaderText = "NroPlanillaIngreso"
        Me.gchtNroPlanillaIngreso.Name = "gchtNroPlanillaIngreso"
        Me.gchtNroPlanillaIngreso.ReadOnly = True
        Me.gchtNroPlanillaIngreso.Visible = False
        '
        'gchtNroMovimientoIngreso
        '
        Me.gchtNroMovimientoIngreso.DataPropertyName = "NroMovimientoIngreso"
        Me.gchtNroMovimientoIngreso.HeaderText = "NroMovimientoIngreso"
        Me.gchtNroMovimientoIngreso.Name = "gchtNroMovimientoIngreso"
        Me.gchtNroMovimientoIngreso.ReadOnly = True
        Me.gchtNroMovimientoIngreso.Visible = False
        '
        'gchtNroPlanillaEgreso
        '
        Me.gchtNroPlanillaEgreso.DataPropertyName = "NroPlanillaEgreso"
        Me.gchtNroPlanillaEgreso.HeaderText = "NroPlanillaEgreso"
        Me.gchtNroPlanillaEgreso.Name = "gchtNroPlanillaEgreso"
        Me.gchtNroPlanillaEgreso.ReadOnly = True
        Me.gchtNroPlanillaEgreso.Visible = False
        '
        'gchtNroMovimientoEgreso
        '
        Me.gchtNroMovimientoEgreso.DataPropertyName = "NroMovimientoEgreso"
        Me.gchtNroMovimientoEgreso.HeaderText = "NroMovimientoEgreso"
        Me.gchtNroMovimientoEgreso.Name = "gchtNroMovimientoEgreso"
        Me.gchtNroMovimientoEgreso.ReadOnly = True
        Me.gchtNroMovimientoEgreso.Visible = False
        '
        'gchtUsuario
        '
        Me.gchtUsuario.DataPropertyName = "Usuario"
        Me.gchtUsuario.HeaderText = "Usuario"
        Me.gchtUsuario.Name = "gchtUsuario"
        Me.gchtUsuario.ReadOnly = True
        Me.gchtUsuario.Visible = False
        '
        'gchtPassword
        '
        Me.gchtPassword.DataPropertyName = "Password"
        Me.gchtPassword.HeaderText = "PwdCheque"
        Me.gchtPassword.Name = "gchtPassword"
        Me.gchtPassword.ReadOnly = True
        Me.gchtPassword.Visible = False
        '
        'gchtIdSucursal
        '
        Me.gchtIdSucursal.DataPropertyName = "IdSucursal"
        Me.gchtIdSucursal.HeaderText = "IdSucursalCheque"
        Me.gchtIdSucursal.Name = "gchtIdSucursal"
        Me.gchtIdSucursal.ReadOnly = True
        Me.gchtIdSucursal.Visible = False
        '
        'gchtCuentaBancaria
        '
        Me.gchtCuentaBancaria.DataPropertyName = "CuentaBancaria"
        Me.gchtCuentaBancaria.HeaderText = "CuentaBancaria"
        Me.gchtCuentaBancaria.Name = "gchtCuentaBancaria"
        Me.gchtCuentaBancaria.ReadOnly = True
        Me.gchtCuentaBancaria.Visible = False
        '
        'gchtIdCuentaBancaria
        '
        Me.gchtIdCuentaBancaria.DataPropertyName = "IdCuentaBancaria"
        Me.gchtIdCuentaBancaria.HeaderText = "IdCuentaBancaria"
        Me.gchtIdCuentaBancaria.Name = "gchtIdCuentaBancaria"
        Me.gchtIdCuentaBancaria.ReadOnly = True
        Me.gchtIdCuentaBancaria.Visible = False
        '
        'gchtNombreCuentaBancaria
        '
        Me.gchtNombreCuentaBancaria.DataPropertyName = "NombreCuentaBancaria"
        Me.gchtNombreCuentaBancaria.HeaderText = "NombreCuentaBancaria"
        Me.gchtNombreCuentaBancaria.Name = "gchtNombreCuentaBancaria"
        Me.gchtNombreCuentaBancaria.ReadOnly = True
        Me.gchtNombreCuentaBancaria.Visible = False
        '
        'gchtEsPropio
        '
        Me.gchtEsPropio.DataPropertyName = "EsPropio"
        Me.gchtEsPropio.HeaderText = "EsPropio"
        Me.gchtEsPropio.Name = "gchtEsPropio"
        Me.gchtEsPropio.ReadOnly = True
        Me.gchtEsPropio.Visible = False
        '
        'gchtIdEstadoCheque
        '
        Me.gchtIdEstadoCheque.DataPropertyName = "IdEstadoCheque"
        Me.gchtIdEstadoCheque.HeaderText = "IdEstadoCheque"
        Me.gchtIdEstadoCheque.Name = "gchtIdEstadoCheque"
        Me.gchtIdEstadoCheque.ReadOnly = True
        Me.gchtIdEstadoCheque.Visible = False
        '
        'gchtIdEstadoChequeAnt
        '
        Me.gchtIdEstadoChequeAnt.DataPropertyName = "IdEstadoChequeAnt"
        Me.gchtIdEstadoChequeAnt.HeaderText = "IdEstadoChequeAnt"
        Me.gchtIdEstadoChequeAnt.Name = "gchtIdEstadoChequeAnt"
        Me.gchtIdEstadoChequeAnt.ReadOnly = True
        Me.gchtIdEstadoChequeAnt.Visible = False
        '
        'gchtCliente
        '
        Me.gchtCliente.DataPropertyName = "Cliente"
        Me.gchtCliente.HeaderText = "Cliente"
        Me.gchtCliente.Name = "gchtCliente"
        Me.gchtCliente.ReadOnly = True
        Me.gchtCliente.Visible = False
        '
        'gchtProveedor
        '
        Me.gchtProveedor.DataPropertyName = "Proveedor"
        Me.gchtProveedor.HeaderText = "Proveedor"
        Me.gchtProveedor.Name = "gchtProveedor"
        Me.gchtProveedor.ReadOnly = True
        Me.gchtProveedor.Visible = False
        '
        'gchtIdSucursal2
        '
        Me.gchtIdSucursal2.DataPropertyName = "IdSucursal2"
        Me.gchtIdSucursal2.HeaderText = "IdSucursal2"
        Me.gchtIdSucursal2.Name = "gchtIdSucursal2"
        Me.gchtIdSucursal2.ReadOnly = True
        Me.gchtIdSucursal2.Visible = False
        '
        'gchtIdBanco
        '
        Me.gchtIdBanco.DataPropertyName = "IdBanco"
        Me.gchtIdBanco.HeaderText = "IdBanco"
        Me.gchtIdBanco.Name = "gchtIdBanco"
        Me.gchtIdBanco.ReadOnly = True
        Me.gchtIdBanco.Visible = False
        '
        'gchtIdCajaIngreso
        '
        Me.gchtIdCajaIngreso.DataPropertyName = "IdCajaIngreso"
        Me.gchtIdCajaIngreso.HeaderText = "IdCajaIngreso"
        Me.gchtIdCajaIngreso.Name = "gchtIdCajaIngreso"
        Me.gchtIdCajaIngreso.ReadOnly = True
        Me.gchtIdCajaIngreso.Visible = False
        '
        'gchtIdCajaEgreso
        '
        Me.gchtIdCajaEgreso.DataPropertyName = "IdCajaEgreso"
        Me.gchtIdCajaEgreso.HeaderText = "IdCajaEgreso"
        Me.gchtIdCajaEgreso.Name = "gchtIdCajaEgreso"
        Me.gchtIdCajaEgreso.ReadOnly = True
        Me.gchtIdCajaEgreso.Visible = False
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
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.LabelAsoc = Nothing
        Me.lblLocalidad.Location = New System.Drawing.Point(305, 97)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lblLocalidad.TabIndex = 64
        Me.lblLocalidad.Text = "Localidad"
        '
        'grbCliente
        '
        Me.grbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbCliente.Controls.Add(Me.dtpFechaEmision)
        Me.grbCliente.Controls.Add(Me.cmbTiposComprobantesPag)
        Me.grbCliente.Controls.Add(Me.lblTipoComprobanteRec)
        Me.grbCliente.Controls.Add(Me.grbCajas)
        Me.grbCliente.Controls.Add(Me.btnConsultar)
        Me.grbCliente.Controls.Add(Me.lblObservacion)
        Me.grbCliente.Controls.Add(Me.txtObservacion)
        Me.grbCliente.Controls.Add(Me.lblFecha)
        Me.grbCliente.Controls.Add(Me.txtNombreProveedor)
        Me.grbCliente.Controls.Add(Me.txtCodigoProveedor)
        Me.grbCliente.Controls.Add(Me.lblEmisorRecibo)
        Me.grbCliente.Controls.Add(Me.txtEmisor)
        Me.grbCliente.Controls.Add(Me.lblLetra)
        Me.grbCliente.Controls.Add(Me.txtLetra)
        Me.grbCliente.Controls.Add(Me.lblNroPago)
        Me.grbCliente.Controls.Add(Me.txtNroPago)
        Me.grbCliente.Controls.Add(Me.txtCategoriaFiscal)
        Me.grbCliente.Controls.Add(Me.lblCategoriaFiscal)
        Me.grbCliente.Controls.Add(Me.txtLocalidad)
        Me.grbCliente.Controls.Add(Me.lblLocalidad)
        Me.grbCliente.Controls.Add(Me.txtDireccion)
        Me.grbCliente.Controls.Add(Me.lblDireccion)
        Me.grbCliente.Controls.Add(Me.lblCodigoProveedor)
        Me.grbCliente.Controls.Add(Me.lblNombreProveedor)
        Me.grbCliente.Controls.Add(Me.GroupBox1)
        Me.grbCliente.Location = New System.Drawing.Point(3, 35)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(885, 147)
        Me.grbCliente.TabIndex = 4
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Detalle"
        '
        'lblTipoComprobanteRec
        '
        Me.lblTipoComprobanteRec.AutoSize = True
        Me.lblTipoComprobanteRec.LabelAsoc = Nothing
        Me.lblTipoComprobanteRec.Location = New System.Drawing.Point(11, 15)
        Me.lblTipoComprobanteRec.Name = "lblTipoComprobanteRec"
        Me.lblTipoComprobanteRec.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobanteRec.TabIndex = 77
        Me.lblTipoComprobanteRec.Text = "&Tipo Comprobante"
        '
        'grbCajas
        '
        Me.grbCajas.Controls.Add(Me.cmbCajas)
        Me.grbCajas.Controls.Add(Me.lblCaja)
        Me.grbCajas.Location = New System.Drawing.Point(540, 53)
        Me.grbCajas.Name = "grbCajas"
        Me.grbCajas.Size = New System.Drawing.Size(144, 51)
        Me.grbCajas.TabIndex = 75
        Me.grbCajas.TabStop = False
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(3, 8)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 16
        Me.lblCaja.Text = "Caja"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.Location = New System.Drawing.Point(300, 10)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(39, 40)
        Me.btnConsultar.TabIndex = 3
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(343, 13)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 73
        Me.lblFecha.Text = "Fecha"
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(427, 14)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 74
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
        Me.txtObservacion.Location = New System.Drawing.Point(447, 29)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(237, 20)
        Me.txtObservacion.TabIndex = 72
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.BindearPropiedadControl = Nothing
        Me.txtNombreProveedor.BindearPropiedadEntidad = Nothing
        Me.txtNombreProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreProveedor.Formato = ""
        Me.txtNombreProveedor.IsDecimal = False
        Me.txtNombreProveedor.IsNumber = False
        Me.txtNombreProveedor.IsPK = False
        Me.txtNombreProveedor.IsRequired = False
        Me.txtNombreProveedor.Key = ""
        Me.txtNombreProveedor.LabelAsoc = Me.lblNombreProveedor
        Me.txtNombreProveedor.Location = New System.Drawing.Point(111, 73)
        Me.txtNombreProveedor.MaxLength = 100
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.ReadOnly = True
        Me.txtNombreProveedor.Size = New System.Drawing.Size(330, 20)
        Me.txtNombreProveedor.TabIndex = 59
        '
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.AutoSize = True
        Me.lblNombreProveedor.LabelAsoc = Nothing
        Me.lblNombreProveedor.Location = New System.Drawing.Point(108, 58)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(96, 13)
        Me.lblNombreProveedor.TabIndex = 50
        Me.lblNombreProveedor.Text = "Nombre Proveedor"
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.BindearPropiedadControl = Nothing
        Me.txtCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.txtCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoProveedor.Formato = ""
        Me.txtCodigoProveedor.IsDecimal = False
        Me.txtCodigoProveedor.IsNumber = False
        Me.txtCodigoProveedor.IsPK = False
        Me.txtCodigoProveedor.IsRequired = False
        Me.txtCodigoProveedor.Key = ""
        Me.txtCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(15, 73)
        Me.txtCodigoProveedor.MaxLength = 12
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.ReadOnly = True
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigoProveedor.TabIndex = 57
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(12, 58)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(92, 13)
        Me.lblCodigoProveedor.TabIndex = 55
        Me.lblCodigoProveedor.Text = "Código Proveedor"
        '
        'lblEmisorRecibo
        '
        Me.lblEmisorRecibo.AutoSize = True
        Me.lblEmisorRecibo.LabelAsoc = Nothing
        Me.lblEmisorRecibo.Location = New System.Drawing.Point(165, 14)
        Me.lblEmisorRecibo.Name = "lblEmisorRecibo"
        Me.lblEmisorRecibo.Size = New System.Drawing.Size(38, 13)
        Me.lblEmisorRecibo.TabIndex = 69
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
        Me.txtEmisor.Location = New System.Drawing.Point(168, 30)
        Me.txtEmisor.MaxLength = 4
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New System.Drawing.Size(42, 20)
        Me.txtEmisor.TabIndex = 1
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.LabelAsoc = Nothing
        Me.lblLetra.Location = New System.Drawing.Point(135, 15)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(28, 13)
        Me.lblLetra.TabIndex = 68
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
        Me.txtLetra.Location = New System.Drawing.Point(138, 30)
        Me.txtLetra.MaxLength = 1
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(25, 20)
        Me.txtLetra.TabIndex = 0
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNroPago
        '
        Me.lblNroPago.AutoSize = True
        Me.lblNroPago.LabelAsoc = Nothing
        Me.lblNroPago.Location = New System.Drawing.Point(212, 14)
        Me.lblNroPago.Name = "lblNroPago"
        Me.lblNroPago.Size = New System.Drawing.Size(32, 13)
        Me.lblNroPago.TabIndex = 67
        Me.lblNroPago.Text = "Pago"
        '
        'txtNroPago
        '
        Me.txtNroPago.BindearPropiedadControl = Nothing
        Me.txtNroPago.BindearPropiedadEntidad = Nothing
        Me.txtNroPago.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPago.Formato = ""
        Me.txtNroPago.IsDecimal = False
        Me.txtNroPago.IsNumber = True
        Me.txtNroPago.IsPK = False
        Me.txtNroPago.IsRequired = False
        Me.txtNroPago.Key = ""
        Me.txtNroPago.LabelAsoc = Me.lblNroPago
        Me.txtNroPago.Location = New System.Drawing.Point(215, 30)
        Me.txtNroPago.MaxLength = 8
        Me.txtNroPago.Name = "txtNroPago"
        Me.txtNroPago.Size = New System.Drawing.Size(79, 20)
        Me.txtNroPago.TabIndex = 2
        Me.txtNroPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtCategoriaFiscal.Location = New System.Drawing.Point(452, 114)
        Me.txtCategoriaFiscal.Name = "txtCategoriaFiscal"
        Me.txtCategoriaFiscal.ReadOnly = True
        Me.txtCategoriaFiscal.Size = New System.Drawing.Size(136, 20)
        Me.txtCategoriaFiscal.TabIndex = 62
        '
        'lblCategoriaFiscal
        '
        Me.lblCategoriaFiscal.AutoSize = True
        Me.lblCategoriaFiscal.Location = New System.Drawing.Point(449, 100)
        Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
        Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
        Me.lblCategoriaFiscal.TabIndex = 65
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
        Me.txtLocalidad.Location = New System.Drawing.Point(308, 114)
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.ReadOnly = True
        Me.txtLocalidad.Size = New System.Drawing.Size(140, 20)
        Me.txtLocalidad.TabIndex = 61
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
        Me.txtDireccion.Location = New System.Drawing.Point(14, 114)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(287, 20)
        Me.txtDireccion.TabIndex = 60
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.LabelAsoc = Nothing
        Me.lblDireccion.Location = New System.Drawing.Point(12, 98)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
        Me.lblDireccion.TabIndex = 63
        Me.lblDireccion.Text = "Dirección"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSaldoActual)
        Me.GroupBox1.Controls.Add(Me.lblSaldoActual)
        Me.GroupBox1.Controls.Add(Me.txtDiferencia)
        Me.GroupBox1.Controls.Add(Me.lblDiferencia)
        Me.GroupBox1.Controls.Add(Me.txtComprobantes)
        Me.GroupBox1.Controls.Add(Me.lblBruto)
        Me.GroupBox1.Controls.Add(Me.txtTotalPago)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(692, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 128)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totales"
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
        Me.txtSaldoActual.Location = New System.Drawing.Point(86, 99)
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.ReadOnly = True
        Me.txtSaldoActual.Size = New System.Drawing.Size(88, 21)
        Me.txtSaldoActual.TabIndex = 17
        Me.txtSaldoActual.TabStop = False
        Me.txtSaldoActual.Text = "0.00"
        Me.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSaldoActual.LabelAsoc = Nothing
        Me.lblSaldoActual.Location = New System.Drawing.Point(8, 107)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(66, 13)
        Me.lblSaldoActual.TabIndex = 16
        Me.lblSaldoActual.Text = "Saldo actual"
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
        Me.txtDiferencia.Location = New System.Drawing.Point(86, 72)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.ReadOnly = True
        Me.txtDiferencia.Size = New System.Drawing.Size(88, 21)
        Me.txtDiferencia.TabIndex = 13
        Me.txtDiferencia.TabStop = False
        Me.txtDiferencia.Text = "0.00"
        Me.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiferencia
        '
        Me.lblDiferencia.AutoSize = True
        Me.lblDiferencia.LabelAsoc = Nothing
        Me.lblDiferencia.Location = New System.Drawing.Point(8, 79)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(55, 13)
        Me.lblDiferencia.TabIndex = 14
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
        Me.txtComprobantes.Location = New System.Drawing.Point(88, 11)
        Me.txtComprobantes.Name = "txtComprobantes"
        Me.txtComprobantes.ReadOnly = True
        Me.txtComprobantes.Size = New System.Drawing.Size(88, 21)
        Me.txtComprobantes.TabIndex = 0
        Me.txtComprobantes.TabStop = False
        Me.txtComprobantes.Text = "0.00"
        Me.txtComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBruto
        '
        Me.lblBruto.AutoSize = True
        Me.lblBruto.LabelAsoc = Nothing
        Me.lblBruto.Location = New System.Drawing.Point(7, 18)
        Me.lblBruto.Name = "lblBruto"
        Me.lblBruto.Size = New System.Drawing.Size(75, 13)
        Me.lblBruto.TabIndex = 7
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
        Me.txtTotalPago.Location = New System.Drawing.Point(88, 37)
        Me.txtTotalPago.Name = "txtTotalPago"
        Me.txtTotalPago.ReadOnly = True
        Me.txtTotalPago.Size = New System.Drawing.Size(88, 21)
        Me.txtTotalPago.TabIndex = 6
        Me.txtTotalPago.TabStop = False
        Me.txtTotalPago.Text = "0.00"
        Me.txtTotalPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(63, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "__________________"
        '
        'cmbTiposComprobantesPag
        '
        Me.cmbTiposComprobantesPag.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantesPag.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantesPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesPag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantesPag.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesPag.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesPag.FormattingEnabled = True
        Me.cmbTiposComprobantesPag.IsPK = False
        Me.cmbTiposComprobantesPag.IsRequired = False
        Me.cmbTiposComprobantesPag.ItemHeight = 13
        Me.cmbTiposComprobantesPag.Key = Nothing
        Me.cmbTiposComprobantesPag.LabelAsoc = Me.lblTipoComprobanteRec
        Me.cmbTiposComprobantesPag.Location = New System.Drawing.Point(14, 30)
        Me.cmbTiposComprobantesPag.Name = "cmbTiposComprobantesPag"
        Me.cmbTiposComprobantesPag.Size = New System.Drawing.Size(120, 21)
        Me.cmbTiposComprobantesPag.TabIndex = 76
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
        Me.cmbCajas.Location = New System.Drawing.Point(6, 24)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(132, 21)
        Me.cmbCajas.TabIndex = 17
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
        Me.dtpFechaEmision.Location = New System.Drawing.Point(346, 29)
        Me.dtpFechaEmision.Name = "dtpFechaEmision"
        Me.dtpFechaEmision.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEmision.TabIndex = 78
        Me.dtpFechaEmision.Value = New Date(2019, 10, 22, 0, 0, 0, 0)
        '
        'ModificarPagosProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 472)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Controls.Add(Me.grbCliente)
        Me.Controls.Add(Me.tspFacturacion)
        Me.Name = "ModificarPagosProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Recibo de Pago a Proveedor"
        Me.tspFacturacion.ResumeLayout(False)
        Me.tspFacturacion.PerformLayout()
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpComprobantes.ResumeLayout(False)
        CType(Me.dgvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpPagos1.ResumeLayout(False)
        Me.tbpPagos1.PerformLayout()
        Me.grbChequesPropios.ResumeLayout(False)
        CType(Me.dgvChequesPropios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpPagos2.ResumeLayout(False)
        Me.tbpPagos2.PerformLayout()
        Me.grbChequesTerceros.ResumeLayout(False)
        CType(Me.dgvChequesTerceros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.grbCajas.ResumeLayout(False)
        Me.grbCajas.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tspFacturacion As ToolStrip
    Friend WithEvents tsbRefrescar As ToolStripButton
    Friend WithEvents tsbGrabar As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents tbcDetalle As TabControl
    Friend WithEvents tbpComprobantes As TabPage
    Friend WithEvents dgvComprobantes As Controles.DataGridView
    Friend WithEvents TipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents letra As DataGridViewTextBoxColumn
    Friend WithEvents CentroEmisor As DataGridViewTextBoxColumn
    Friend WithEvents NroComprobante As DataGridViewTextBoxColumn
    Friend WithEvents Cuota As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents FechaVencimiento As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Paga As DataGridViewTextBoxColumn
    Friend WithEvents Password As DataGridViewTextBoxColumn
    Friend WithEvents Usuario As DataGridViewTextBoxColumn
    Friend WithEvents IdSucursal As DataGridViewTextBoxColumn
    Friend WithEvents CuentaCorrienteProv As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobante1 As DataGridViewTextBoxColumn
    Friend WithEvents FormaPago As DataGridViewTextBoxColumn
    Friend WithEvents FormasPagoDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents DescuentoRecargoPorc As DataGridViewTextBoxColumn
    Friend WithEvents DescuentoRecargo As DataGridViewTextBoxColumn
    Friend WithEvents tbpPagos1 As TabPage
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents txtDolares As Controles.TextBox
    Friend WithEvents lblRetenciones As Controles.Label
    Friend WithEvents txtRetenciones As Controles.TextBox
    Friend WithEvents lblTotal As Controles.Label
    Friend WithEvents lblLocalidad As Controles.Label
    Friend WithEvents lblTickets As Controles.Label
    Friend WithEvents lblChequesPropios As Controles.Label
    Friend WithEvents txtTickets As Controles.TextBox
    Friend WithEvents txtChequesPropios As Controles.TextBox
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents lblTarjetas As Controles.Label
    Friend WithEvents lblTransferenciaBancaria As Controles.Label
    Friend WithEvents txtTarjetas As Controles.TextBox
    Friend WithEvents txtTransferenciaBancaria As Controles.TextBox
    Friend WithEvents grbChequesPropios As GroupBox
    Friend WithEvents dgvChequesPropios As Controles.DataGridView
    Friend WithEvents IdCuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents NombreCuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents IdBanco As DataGridViewTextBoxColumn
    Friend WithEvents BancoNombre As DataGridViewTextBoxColumn
    Friend WithEvents Sucursal As DataGridViewTextBoxColumn
    Friend WithEvents CP As DataGridViewTextBoxColumn
    Friend WithEvents Localidad As DataGridViewTextBoxColumn
    Friend WithEvents NroCheque As DataGridViewTextBoxColumn
    Friend WithEvents FechaEmision As DataGridViewTextBoxColumn
    Friend WithEvents FechaCobro As DataGridViewTextBoxColumn
    Friend WithEvents ImporteCheque As DataGridViewTextBoxColumn
    Friend WithEvents RowState As DataGridViewTextBoxColumn
    Friend WithEvents Banco As DataGridViewTextBoxColumn
    Friend WithEvents NroPlanillaRecibo As DataGridViewTextBoxColumn
    Friend WithEvents NroMovimientoRecibo As DataGridViewTextBoxColumn
    Friend WithEvents NroPlanillaEntregado As DataGridViewTextBoxColumn
    Friend WithEvents NroMovimientoEntregado As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCheque As DataGridViewTextBoxColumn
    Friend WithEvents PwdCheque As DataGridViewTextBoxColumn
    Friend WithEvents IdSucursalCheque As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents ProveedorTipoDoc As DataGridViewTextBoxColumn
    Friend WithEvents ProveedorNroDoc As DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As DataGridViewTextBoxColumn
    Friend WithEvents gTitular As DataGridViewTextBoxColumn
    Friend WithEvents CuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents EsPropio As DataGridViewTextBoxColumn
    Friend WithEvents gIdEstadoCheque As DataGridViewTextBoxColumn
    Friend WithEvents gIdEstadoChequeAnt As DataGridViewTextBoxColumn
    Friend WithEvents gIdSucursal2 As DataGridViewTextBoxColumn
    Friend WithEvents gIdBanco As DataGridViewTextBoxColumn
    Friend WithEvents gIdCajaIngreso As DataGridViewTextBoxColumn
    Friend WithEvents gIdCajaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents FotoFrente As DataGridViewTextBoxColumn
    Friend WithEvents FotoDorso As DataGridViewTextBoxColumn
    Friend WithEvents lblEfectivo As Controles.Label
    Friend WithEvents txtEfectivo As Controles.TextBox
    Friend WithEvents tbpPagos2 As TabPage
    Friend WithEvents lblChequesTerceros As Controles.Label
    Friend WithEvents txtChequesTerceros As Controles.TextBox
    Friend WithEvents grbChequesTerceros As GroupBox
    Friend WithEvents dgvChequesTerceros As Controles.DataGridView
    Friend WithEvents gchtNombreBanco As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdBancoSucursal As DataGridViewTextBoxColumn
    Friend WithEvents gchtCP As DataGridViewTextBoxColumn
    Friend WithEvents gchtNumeroCheque As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents gchtFechaEmision As DataGridViewTextBoxColumn
    Friend WithEvents gchtFechaCobro As DataGridViewTextBoxColumn
    Friend WithEvents gchtTitular As DataGridViewTextBoxColumn
    Friend WithEvents gchtImporte As DataGridViewTextBoxColumn
    Friend WithEvents gchtRowState As DataGridViewTextBoxColumn
    Friend WithEvents gchtClienteTipoDocumento As DataGridViewTextBoxColumn
    Friend WithEvents gchtClienteNroDocumento As DataGridViewTextBoxColumn
    Friend WithEvents gchtBanco As DataGridViewTextBoxColumn
    Friend WithEvents gchtNroPlanillaIngreso As DataGridViewTextBoxColumn
    Friend WithEvents gchtNroMovimientoIngreso As DataGridViewTextBoxColumn
    Friend WithEvents gchtNroPlanillaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents gchtNroMovimientoEgreso As DataGridViewTextBoxColumn
    Friend WithEvents gchtUsuario As DataGridViewTextBoxColumn
    Friend WithEvents gchtPassword As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdSucursal As DataGridViewTextBoxColumn
    Friend WithEvents gchtCuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdCuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents gchtNombreCuentaBancaria As DataGridViewTextBoxColumn
    Friend WithEvents gchtEsPropio As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdEstadoCheque As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdEstadoChequeAnt As DataGridViewTextBoxColumn
    Friend WithEvents gchtCliente As DataGridViewTextBoxColumn
    Friend WithEvents gchtProveedor As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdSucursal2 As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdBanco As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdCajaIngreso As DataGridViewTextBoxColumn
    Friend WithEvents gchtIdCajaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents FotoFrente1 As DataGridViewTextBoxColumn
    Friend WithEvents FotoDorso1 As DataGridViewTextBoxColumn
    Friend WithEvents grbCliente As GroupBox
    Friend WithEvents cmbTiposComprobantesPag As Controles.ComboBox
    Friend WithEvents lblTipoComprobanteRec As Controles.Label
    Friend WithEvents grbCajas As GroupBox
    Friend WithEvents cmbCajas As Controles.ComboBox
    Friend WithEvents lblCaja As Controles.Label
    Friend WithEvents btnConsultar As Controles.Button
    Friend WithEvents lblFecha As Controles.Label
    Friend WithEvents lblObservacion As Controles.Label
    Friend WithEvents txtObservacion As Controles.TextBox
    Friend WithEvents txtNombreProveedor As Controles.TextBox
    Friend WithEvents lblNombreProveedor As Controles.Label
    Friend WithEvents txtCodigoProveedor As Controles.TextBox
    Friend WithEvents lblCodigoProveedor As Controles.Label
    Friend WithEvents lblEmisorRecibo As Controles.Label
    Friend WithEvents txtEmisor As Controles.TextBox
    Friend WithEvents lblLetra As Controles.Label
    Friend WithEvents txtLetra As Controles.TextBox
    Friend WithEvents lblNroPago As Controles.Label
    Friend WithEvents txtNroPago As Controles.TextBox
    Friend WithEvents txtCategoriaFiscal As Controles.TextBox
    Friend WithEvents lblCategoriaFiscal As Label
    Friend WithEvents txtLocalidad As Controles.TextBox
    Friend WithEvents txtDireccion As Controles.TextBox
    Friend WithEvents lblDireccion As Controles.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtSaldoActual As Controles.TextBox
    Friend WithEvents lblSaldoActual As Controles.Label
    Friend WithEvents txtDiferencia As Controles.TextBox
    Friend WithEvents lblDiferencia As Controles.Label
    Friend WithEvents txtComprobantes As Controles.TextBox
    Friend WithEvents lblBruto As Controles.Label
    Friend WithEvents txtTotalPago As Controles.TextBox
    Friend WithEvents Label5 As Controles.Label
    Friend WithEvents bscCuentaBancariaTransfBanc As Controles.Buscador
    Friend WithEvents dtpFechaEmision As Controles.DateTimePicker
End Class
