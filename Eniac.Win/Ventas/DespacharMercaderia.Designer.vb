<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DespacharMercaderia
   Inherits Eniac.Win.BaseForm

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DespacharMercaderia))
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbMercDespachada = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.chbNumeroReparto = New Eniac.Controles.CheckBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.txtNumeroReparto = New Eniac.Controles.TextBox()
        Me.txtNumero = New Eniac.Controles.TextBox()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.chbFormaPago = New Eniac.Controles.CheckBox()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.cmbAfectaCaja = New Eniac.Controles.ComboBox()
        Me.lblAfectaCaja = New Eniac.Controles.Label()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDespachar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnularDespacho = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.lblTotales = New Eniac.Controles.Label()
        Me.txtImpuestos = New Eniac.Controles.TextBox()
        Me.txtSubtotal = New Eniac.Controles.TextBox()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.Seleccionado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MercDespachada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colVer = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TipoImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormaDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalImpuestos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCAEVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroReparto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreTransportista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdTipoMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumeroMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionado, Me.MercDespachada, Me.colVer, Me.TipoImpresora, Me.IdTipoComprobante, Me.DescripcionAbrev, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.Fecha, Me.TipoDocCliente, Me.NroDocCliente, Me.NombreCliente, Me.NombreCategoriaFiscal, Me.FormaDePago, Me.SubTotal, Me.TotalImpuestos, Me.ImporteTotal, Me.colCAE, Me.colCAEVencimiento, Me.NumeroReparto, Me.FechaEnvio, Me.NombreTransportista, Me.Usuario, Me.Observacion, Me.colIdTipoMovimiento, Me.colNumeroMovimiento, Me.colIdSucursal, Me.IdCliente, Me.IdSucursal})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 158)
        Me.dgvDetalle.MultiSelect = False
        Me.dgvDetalle.Name = "dgvDetalle"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowHeadersWidth = 4
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(1003, 347)
        Me.dgvDetalle.TabIndex = 1
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbMercDespachada)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.chbNumeroReparto)
        Me.grbFiltros.Controls.Add(Me.chbNumero)
        Me.grbFiltros.Controls.Add(Me.txtNumeroReparto)
        Me.grbFiltros.Controls.Add(Me.txtNumero)
        Me.grbFiltros.Controls.Add(Me.chbUsuario)
        Me.grbFiltros.Controls.Add(Me.cmbUsuario)
        Me.grbFiltros.Controls.Add(Me.chbFormaPago)
        Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbAfectaCaja)
        Me.grbFiltros.Controls.Add(Me.lblAfectaCaja)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1003, 116)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'cmbMercDespachada
        '
        Me.cmbMercDespachada.BindearPropiedadControl = Nothing
        Me.cmbMercDespachada.BindearPropiedadEntidad = Nothing
        Me.cmbMercDespachada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercDespachada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercDespachada.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercDespachada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercDespachada.FormattingEnabled = True
        Me.cmbMercDespachada.IsPK = False
        Me.cmbMercDespachada.IsRequired = False
        Me.cmbMercDespachada.Key = Nothing
        Me.cmbMercDespachada.LabelAsoc = Me.Label1
        Me.cmbMercDespachada.Location = New System.Drawing.Point(909, 88)
        Me.cmbMercDespachada.Name = "cmbMercDespachada"
        Me.cmbMercDespachada.Size = New System.Drawing.Size(83, 21)
        Me.cmbMercDespachada.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(808, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Merc. Despachada"
        '
        'chbNumeroReparto
        '
        Me.chbNumeroReparto.AutoSize = True
        Me.chbNumeroReparto.BindearPropiedadControl = Nothing
        Me.chbNumeroReparto.BindearPropiedadEntidad = Nothing
        Me.chbNumeroReparto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroReparto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroReparto.IsPK = False
        Me.chbNumeroReparto.IsRequired = False
        Me.chbNumeroReparto.Key = Nothing
        Me.chbNumeroReparto.LabelAsoc = Nothing
        Me.chbNumeroReparto.Location = New System.Drawing.Point(497, 62)
        Me.chbNumeroReparto.Name = "chbNumeroReparto"
        Me.chbNumeroReparto.Size = New System.Drawing.Size(64, 17)
        Me.chbNumeroReparto.TabIndex = 14
        Me.chbNumeroReparto.Text = "Reparto"
        Me.chbNumeroReparto.UseVisualStyleBackColor = True
        '
        'chbNumero
        '
        Me.chbNumero.AutoSize = True
        Me.chbNumero.BindearPropiedadControl = Nothing
        Me.chbNumero.BindearPropiedadEntidad = Nothing
        Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumero.IsPK = False
        Me.chbNumero.IsRequired = False
        Me.chbNumero.Key = Nothing
        Me.chbNumero.LabelAsoc = Nothing
        Me.chbNumero.Location = New System.Drawing.Point(698, 22)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 7
        Me.chbNumero.Text = "Número"
        Me.chbNumero.UseVisualStyleBackColor = True
        '
        'txtNumeroReparto
        '
        Me.txtNumeroReparto.BindearPropiedadControl = Nothing
        Me.txtNumeroReparto.BindearPropiedadEntidad = Nothing
        Me.txtNumeroReparto.Enabled = False
        Me.txtNumeroReparto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroReparto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroReparto.Formato = "##0"
        Me.txtNumeroReparto.IsDecimal = False
        Me.txtNumeroReparto.IsNumber = True
        Me.txtNumeroReparto.IsPK = False
        Me.txtNumeroReparto.IsRequired = False
        Me.txtNumeroReparto.Key = ""
        Me.txtNumeroReparto.LabelAsoc = Nothing
        Me.txtNumeroReparto.Location = New System.Drawing.Point(564, 60)
        Me.txtNumeroReparto.MaxLength = 8
        Me.txtNumeroReparto.Name = "txtNumeroReparto"
        Me.txtNumeroReparto.Size = New System.Drawing.Size(73, 20)
        Me.txtNumeroReparto.TabIndex = 15
        Me.txtNumeroReparto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumero
        '
        Me.txtNumero.BindearPropiedadControl = Nothing
        Me.txtNumero.BindearPropiedadEntidad = Nothing
        Me.txtNumero.Enabled = False
        Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumero.Formato = "##0"
        Me.txtNumero.IsDecimal = False
        Me.txtNumero.IsNumber = True
        Me.txtNumero.IsPK = False
        Me.txtNumero.IsRequired = False
        Me.txtNumero.Key = ""
        Me.txtNumero.LabelAsoc = Nothing
        Me.txtNumero.Location = New System.Drawing.Point(765, 20)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(73, 20)
        Me.txtNumero.TabIndex = 8
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbUsuario
        '
        Me.chbUsuario.AutoSize = True
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Location = New System.Drawing.Point(670, 62)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 16
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'cmbUsuario
        '
        Me.cmbUsuario.BindearPropiedadControl = Nothing
        Me.cmbUsuario.BindearPropiedadEntidad = Nothing
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.Enabled = False
        Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.IsPK = False
        Me.cmbUsuario.IsRequired = False
        Me.cmbUsuario.Key = Nothing
        Me.cmbUsuario.LabelAsoc = Nothing
        Me.cmbUsuario.Location = New System.Drawing.Point(743, 60)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(148, 21)
        Me.cmbUsuario.TabIndex = 17
        '
        'chbFormaPago
        '
        Me.chbFormaPago.AutoSize = True
        Me.chbFormaPago.BindearPropiedadControl = Nothing
        Me.chbFormaPago.BindearPropiedadEntidad = Nothing
        Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormaPago.IsPK = False
        Me.chbFormaPago.IsRequired = False
        Me.chbFormaPago.Key = Nothing
        Me.chbFormaPago.LabelAsoc = Nothing
        Me.chbFormaPago.Location = New System.Drawing.Point(564, 90)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFormaPago.TabIndex = 24
        Me.chbFormaPago.Text = "Forma de Pago"
        Me.chbFormaPago.UseVisualStyleBackColor = True
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Nothing
        Me.cmbFormaPago.Location = New System.Drawing.Point(665, 88)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(119, 21)
        Me.cmbFormaPago.TabIndex = 25
        '
        'chbVendedor
        '
        Me.chbVendedor.AutoSize = True
        Me.chbVendedor.BindearPropiedadControl = Nothing
        Me.chbVendedor.BindearPropiedadEntidad = Nothing
        Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVendedor.IsPK = False
        Me.chbVendedor.IsRequired = False
        Me.chbVendedor.Key = Nothing
        Me.chbVendedor.LabelAsoc = Nothing
        Me.chbVendedor.Location = New System.Drawing.Point(337, 90)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 22
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Enabled = False
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Location = New System.Drawing.Point(412, 88)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(129, 21)
        Me.cmbVendedor.TabIndex = 23
        '
        'cmbAfectaCaja
        '
        Me.cmbAfectaCaja.BindearPropiedadControl = Nothing
        Me.cmbAfectaCaja.BindearPropiedadEntidad = Nothing
        Me.cmbAfectaCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAfectaCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAfectaCaja.FormattingEnabled = True
        Me.cmbAfectaCaja.IsPK = False
        Me.cmbAfectaCaja.IsRequired = False
        Me.cmbAfectaCaja.Key = Nothing
        Me.cmbAfectaCaja.LabelAsoc = Me.lblAfectaCaja
        Me.cmbAfectaCaja.Location = New System.Drawing.Point(239, 88)
        Me.cmbAfectaCaja.Name = "cmbAfectaCaja"
        Me.cmbAfectaCaja.Size = New System.Drawing.Size(83, 21)
        Me.cmbAfectaCaja.TabIndex = 21
        '
        'lblAfectaCaja
        '
        Me.lblAfectaCaja.AutoSize = True
        Me.lblAfectaCaja.LabelAsoc = Nothing
        Me.lblAfectaCaja.Location = New System.Drawing.Point(174, 92)
        Me.lblAfectaCaja.Name = "lblAfectaCaja"
        Me.lblAfectaCaja.Size = New System.Drawing.Size(62, 13)
        Me.lblAfectaCaja.TabIndex = 20
        Me.lblAfectaCaja.Text = "Afecta Caja"
        '
        'cmbGrabanLibro
        '
        Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
        Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
        Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrabanLibro.FormattingEnabled = True
        Me.cmbGrabanLibro.IsPK = False
        Me.cmbGrabanLibro.IsRequired = False
        Me.cmbGrabanLibro.Key = Nothing
        Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabanLibro
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(75, 88)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
        Me.cmbGrabanLibro.TabIndex = 19
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(4, 92)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 18
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 608
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ColumnasAlineacion = Nothing
        Me.bscCodigoCliente.ColumnasAncho = Nothing
        Me.bscCodigoCliente.ColumnasFormato = Nothing
        Me.bscCodigoCliente.ColumnasOcultas = Nothing
        Me.bscCodigoCliente.ColumnasTitulos = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(75, 59)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 11
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(72, 44)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 10
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 608
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ColumnasAlineacion = Nothing
        Me.bscCliente.ColumnasAncho = Nothing
        Me.bscCliente.ColumnasFormato = Nothing
        Me.bscCliente.ColumnasOcultas = Nothing
        Me.bscCliente.ColumnasTitulos = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.Enabled = False
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(172, 59)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 13
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(169, 44)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 12
        Me.lblNombre.Text = "Nombre"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Enabled = False
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(564, 20)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(123, 21)
        Me.cmbTiposComprobantes.TabIndex = 6
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(897, 31)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(102, 45)
        Me.btnConsultar.TabIndex = 28
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(13, 62)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 9
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.BindearPropiedadControl = Nothing
        Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobante.IsPK = False
        Me.chbTipoComprobante.IsRequired = False
        Me.chbTipoComprobante.Key = Nothing
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(448, 22)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 5
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(13, 23)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(310, 22)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(273, 25)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(144, 21)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(105, 24)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbDespachar, Me.tsbAnularDespacho, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1028, 29)
        Me.tstBarra.TabIndex = 8
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbDespachar
        '
        Me.tsbDespachar.Enabled = False
        Me.tsbDespachar.Image = Global.Eniac.Win.My.Resources.Resources.package_ok
        Me.tsbDespachar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDespachar.Name = "tsbDespachar"
        Me.tsbDespachar.Size = New System.Drawing.Size(88, 26)
        Me.tsbDespachar.Text = "&Despachar"
        Me.tsbDespachar.ToolTipText = "Despachar"
        '
        'tsbAnularDespacho
        '
        Me.tsbAnularDespacho.Enabled = False
        Me.tsbAnularDespacho.Image = Global.Eniac.Win.My.Resources.Resources.delete2
        Me.tsbAnularDespacho.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnularDespacho.Name = "tsbAnularDespacho"
        Me.tsbAnularDespacho.Size = New System.Drawing.Size(123, 26)
        Me.tsbAnularDespacho.Text = "&Anular Despacho"
        Me.tsbAnularDespacho.ToolTipText = "Despachar/Anular Despacho"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 537)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1028, 22)
        Me.stsStado.TabIndex = 7
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(949, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.BindearPropiedadControl = Nothing
        Me.txtTotal.BindearPropiedadEntidad = Nothing
        Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotal.Formato = ""
        Me.txtTotal.IsDecimal = False
        Me.txtTotal.IsNumber = False
        Me.txtTotal.IsPK = False
        Me.txtTotal.IsRequired = False
        Me.txtTotal.Key = ""
        Me.txtTotal.LabelAsoc = Nothing
        Me.txtTotal.Location = New System.Drawing.Point(890, 511)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(70, 20)
        Me.txtTotal.TabIndex = 6
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotales
        '
        Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotales.AutoSize = True
        Me.lblTotales.LabelAsoc = Nothing
        Me.lblTotales.Location = New System.Drawing.Point(699, 515)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(45, 13)
        Me.lblTotales.TabIndex = 3
        Me.lblTotales.Text = "Totales:"
        '
        'txtImpuestos
        '
        Me.txtImpuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImpuestos.BindearPropiedadControl = Nothing
        Me.txtImpuestos.BindearPropiedadEntidad = Nothing
        Me.txtImpuestos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImpuestos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImpuestos.Formato = "##0.00"
        Me.txtImpuestos.IsDecimal = True
        Me.txtImpuestos.IsNumber = True
        Me.txtImpuestos.IsPK = False
        Me.txtImpuestos.IsRequired = False
        Me.txtImpuestos.Key = ""
        Me.txtImpuestos.LabelAsoc = Nothing
        Me.txtImpuestos.Location = New System.Drawing.Point(820, 511)
        Me.txtImpuestos.Name = "txtImpuestos"
        Me.txtImpuestos.ReadOnly = True
        Me.txtImpuestos.Size = New System.Drawing.Size(70, 20)
        Me.txtImpuestos.TabIndex = 5
        Me.txtImpuestos.Text = "0.00"
        Me.txtImpuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotal.BindearPropiedadControl = Nothing
        Me.txtSubtotal.BindearPropiedadEntidad = Nothing
        Me.txtSubtotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSubtotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSubtotal.Formato = "##0.00"
        Me.txtSubtotal.IsDecimal = True
        Me.txtSubtotal.IsNumber = True
        Me.txtSubtotal.IsPK = False
        Me.txtSubtotal.IsRequired = False
        Me.txtSubtotal.Key = ""
        Me.txtSubtotal.LabelAsoc = Nothing
        Me.txtSubtotal.Location = New System.Drawing.Point(750, 511)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(70, 20)
        Me.txtSubtotal.TabIndex = 4
        Me.txtSubtotal.Text = "0.00"
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbTodos
        '
        Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.ImageIndex = 3
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(12, 510)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(119, 24)
        Me.chbTodos.TabIndex = 2
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'Seleccionado
        '
        Me.Seleccionado.DataPropertyName = "Seleccionado"
        Me.Seleccionado.HeaderText = "Sel."
        Me.Seleccionado.Name = "Seleccionado"
        Me.Seleccionado.Width = 40
        '
        'MercDespachada
        '
        Me.MercDespachada.DataPropertyName = "MercDespachada"
        Me.MercDespachada.HeaderText = "Desp."
        Me.MercDespachada.Name = "MercDespachada"
        Me.MercDespachada.ReadOnly = True
        Me.MercDespachada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MercDespachada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MercDespachada.Width = 40
        '
        'colVer
        '
        Me.colVer.DataPropertyName = "Ver"
        Me.colVer.HeaderText = "Ver"
        Me.colVer.Name = "colVer"
        Me.colVer.ReadOnly = True
        Me.colVer.Text = "..."
        Me.colVer.Width = 30
        '
        'TipoImpresora
        '
        Me.TipoImpresora.DataPropertyName = "TipoImpresora"
        Me.TipoImpresora.HeaderText = "TipoImpresora"
        Me.TipoImpresora.Name = "TipoImpresora"
        Me.TipoImpresora.Visible = False
        '
        'IdTipoComprobante
        '
        Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.IdTipoComprobante.HeaderText = "Comprobante"
        Me.IdTipoComprobante.Name = "IdTipoComprobante"
        Me.IdTipoComprobante.ReadOnly = True
        Me.IdTipoComprobante.Visible = False
        Me.IdTipoComprobante.Width = 80
        '
        'DescripcionAbrev
        '
        Me.DescripcionAbrev.DataPropertyName = "DescripcionAbrev"
        Me.DescripcionAbrev.HeaderText = "Comprobante"
        Me.DescripcionAbrev.Name = "DescripcionAbrev"
        Me.DescripcionAbrev.ReadOnly = True
        Me.DescripcionAbrev.Width = 75
        '
        'Letra
        '
        Me.Letra.DataPropertyName = "Letra"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
        Me.Letra.HeaderText = "Let."
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Width = 30
        '
        'CentroEmisor
        '
        Me.CentroEmisor.DataPropertyName = "CentroEmisor"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
        Me.CentroEmisor.HeaderText = "Emisor"
        Me.CentroEmisor.Name = "CentroEmisor"
        Me.CentroEmisor.ReadOnly = True
        Me.CentroEmisor.Width = 40
        '
        'NumeroComprobante
        '
        Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle4
        Me.NumeroComprobante.HeaderText = "Numero"
        Me.NumeroComprobante.Name = "NumeroComprobante"
        Me.NumeroComprobante.ReadOnly = True
        Me.NumeroComprobante.Width = 55
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "dd/MM/yyyy HH:mm"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle5
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'TipoDocCliente
        '
        Me.TipoDocCliente.DataPropertyName = "TipoDocCliente"
        Me.TipoDocCliente.HeaderText = "Tipo Doc."
        Me.TipoDocCliente.Name = "TipoDocCliente"
        Me.TipoDocCliente.Visible = False
        Me.TipoDocCliente.Width = 55
        '
        'NroDocCliente
        '
        Me.NroDocCliente.DataPropertyName = "NroDocCliente"
        Me.NroDocCliente.HeaderText = "Nro. Doc."
        Me.NroDocCliente.Name = "NroDocCliente"
        Me.NroDocCliente.Visible = False
        Me.NroDocCliente.Width = 80
        '
        'NombreCliente
        '
        Me.NombreCliente.DataPropertyName = "NombreCliente"
        Me.NombreCliente.HeaderText = "Cliente"
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.ReadOnly = True
        Me.NombreCliente.Width = 200
        '
        'NombreCategoriaFiscal
        '
        Me.NombreCategoriaFiscal.DataPropertyName = "NombreCategoriaFiscal"
        Me.NombreCategoriaFiscal.HeaderText = "Categ. Fiscal"
        Me.NombreCategoriaFiscal.Name = "NombreCategoriaFiscal"
        Me.NombreCategoriaFiscal.ReadOnly = True
        Me.NombreCategoriaFiscal.Width = 70
        '
        'FormaDePago
        '
        Me.FormaDePago.DataPropertyName = "FormaDePago"
        Me.FormaDePago.HeaderText = "F. de Pago"
        Me.FormaDePago.Name = "FormaDePago"
        Me.FormaDePago.ReadOnly = True
        Me.FormaDePago.Width = 80
        '
        'SubTotal
        '
        Me.SubTotal.DataPropertyName = "SubTotal"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.SubTotal.HeaderText = "Neto"
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.ReadOnly = True
        Me.SubTotal.Width = 70
        '
        'TotalImpuestos
        '
        Me.TotalImpuestos.DataPropertyName = "TotalImpuestos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TotalImpuestos.DefaultCellStyle = DataGridViewCellStyle7
        Me.TotalImpuestos.HeaderText = "Impuestos"
        Me.TotalImpuestos.Name = "TotalImpuestos"
        Me.TotalImpuestos.ReadOnly = True
        Me.TotalImpuestos.Width = 70
        '
        'ImporteTotal
        '
        Me.ImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle8
        Me.ImporteTotal.HeaderText = "Total"
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.ReadOnly = True
        Me.ImporteTotal.Width = 70
        '
        'colCAE
        '
        Me.colCAE.DataPropertyName = "CAE"
        Me.colCAE.HeaderText = "CAE"
        Me.colCAE.Name = "colCAE"
        Me.colCAE.ReadOnly = True
        Me.colCAE.Visible = False
        '
        'colCAEVencimiento
        '
        Me.colCAEVencimiento.DataPropertyName = "CAEVencimiento"
        Me.colCAEVencimiento.HeaderText = "Venc. CAE"
        Me.colCAEVencimiento.Name = "colCAEVencimiento"
        Me.colCAEVencimiento.ReadOnly = True
        Me.colCAEVencimiento.Visible = False
        Me.colCAEVencimiento.Width = 80
        '
        'NumeroReparto
        '
        Me.NumeroReparto.DataPropertyName = "NumeroReparto"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroReparto.DefaultCellStyle = DataGridViewCellStyle9
        Me.NumeroReparto.HeaderText = "Num. Reparto"
        Me.NumeroReparto.Name = "NumeroReparto"
        Me.NumeroReparto.Width = 80
        '
        'FechaEnvio
        '
        Me.FechaEnvio.DataPropertyName = "FechaEnvio"
        DataGridViewCellStyle10.Format = "d"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.FechaEnvio.DefaultCellStyle = DataGridViewCellStyle10
        Me.FechaEnvio.HeaderText = "Fecha Envío"
        Me.FechaEnvio.Name = "FechaEnvio"
        Me.FechaEnvio.Width = 80
        '
        'NombreTransportista
        '
        Me.NombreTransportista.DataPropertyName = "NombreTransportista"
        Me.NombreTransportista.HeaderText = "Transportista"
        Me.NombreTransportista.Name = "NombreTransportista"
        Me.NombreTransportista.Width = 150
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        Me.Usuario.Width = 60
        '
        'Observacion
        '
        Me.Observacion.DataPropertyName = "Observacion"
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        Me.Observacion.Width = 250
        '
        'colIdTipoMovimiento
        '
        Me.colIdTipoMovimiento.DataPropertyName = "IdTipoMovimiento"
        Me.colIdTipoMovimiento.HeaderText = "IdTipoMovimiento"
        Me.colIdTipoMovimiento.Name = "colIdTipoMovimiento"
        Me.colIdTipoMovimiento.Visible = False
        '
        'colNumeroMovimiento
        '
        Me.colNumeroMovimiento.DataPropertyName = "NumeroMovimiento"
        Me.colNumeroMovimiento.HeaderText = "NumeroMovimiento"
        Me.colNumeroMovimiento.Name = "colNumeroMovimiento"
        Me.colNumeroMovimiento.Visible = False
        '
        'colIdSucursal
        '
        Me.colIdSucursal.DataPropertyName = "IdSucursal"
        Me.colIdSucursal.HeaderText = "Sucursal"
        Me.colIdSucursal.Name = "colIdSucursal"
        Me.colIdSucursal.Visible = False
        '
        'IdCliente
        '
        Me.IdCliente.DataPropertyName = "IdCliente"
        Me.IdCliente.HeaderText = "IdCliente"
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.Visible = False
        '
        'IdSucursal
        '
        Me.IdSucursal.DataPropertyName = "IdSucursal"
        Me.IdSucursal.HeaderText = "IdSucursal"
        Me.IdSucursal.Name = "IdSucursal"
        Me.IdSucursal.Visible = False
        '
        'DespacharMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 559)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotales)
        Me.Controls.Add(Me.txtImpuestos)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "DespacharMercaderia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Despachar Mercadería"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents cmbAfectaCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblAfectaCaja As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtImpuestos As Eniac.Controles.TextBox
   Friend WithEvents txtSubtotal As Eniac.Controles.TextBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents tsbDespachar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents cmbMercDespachada As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents tsbAnularDespacho As System.Windows.Forms.ToolStripButton
    Friend WithEvents chbNumeroReparto As Eniac.Controles.CheckBox
    Friend WithEvents txtNumeroReparto As Eniac.Controles.TextBox
    Friend WithEvents Seleccionado As DataGridViewCheckBoxColumn
    Friend WithEvents MercDespachada As DataGridViewCheckBoxColumn
    Friend WithEvents colVer As DataGridViewButtonColumn
    Friend WithEvents TipoImpresora As DataGridViewTextBoxColumn
    Friend WithEvents IdTipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAbrev As DataGridViewTextBoxColumn
    Friend WithEvents Letra As DataGridViewTextBoxColumn
    Friend WithEvents CentroEmisor As DataGridViewTextBoxColumn
    Friend WithEvents NumeroComprobante As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents TipoDocCliente As DataGridViewTextBoxColumn
    Friend WithEvents NroDocCliente As DataGridViewTextBoxColumn
    Friend WithEvents NombreCliente As DataGridViewTextBoxColumn
    Friend WithEvents NombreCategoriaFiscal As DataGridViewTextBoxColumn
    Friend WithEvents FormaDePago As DataGridViewTextBoxColumn
    Friend WithEvents SubTotal As DataGridViewTextBoxColumn
    Friend WithEvents TotalImpuestos As DataGridViewTextBoxColumn
    Friend WithEvents ImporteTotal As DataGridViewTextBoxColumn
    Friend WithEvents colCAE As DataGridViewTextBoxColumn
    Friend WithEvents colCAEVencimiento As DataGridViewTextBoxColumn
    Friend WithEvents NumeroReparto As DataGridViewTextBoxColumn
    Friend WithEvents FechaEnvio As DataGridViewTextBoxColumn
    Friend WithEvents NombreTransportista As DataGridViewTextBoxColumn
    Friend WithEvents Usuario As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents colIdTipoMovimiento As DataGridViewTextBoxColumn
    Friend WithEvents colNumeroMovimiento As DataGridViewTextBoxColumn
    Friend WithEvents colIdSucursal As DataGridViewTextBoxColumn
    Friend WithEvents IdCliente As DataGridViewTextBoxColumn
    Friend WithEvents IdSucursal As DataGridViewTextBoxColumn
End Class
