<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarCtaCteClientes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarCtaCteClientes))
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.TipoImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreZonaGeografica = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescripcionTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdFormasPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescripcionFormasPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.rbtVenActual = New System.Windows.Forms.RadioButton()
      Me.rbtVenMovimiento = New System.Windows.Forms.RadioButton()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.optConSaldo = New Eniac.Controles.RadioButton()
      Me.optTodos = New Eniac.Controles.RadioButton()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.rbtCatActual = New System.Windows.Forms.RadioButton()
      Me.rbtCatMovimiento = New System.Windows.Forms.RadioButton()
      Me.chbAgruparIdClienteCtaCte = New System.Windows.Forms.CheckBox()
      Me.cmbProvincia = New Eniac.Controles.ComboBox()
      Me.chbExcluirPreComprobantes = New Eniac.Controles.CheckBox()
      Me.chbExcluirSaldosNegativos = New Eniac.Controles.CheckBox()
      Me.chbExcluirAnticipos = New Eniac.Controles.CheckBox()
      Me.cmbGrupos = New Eniac.Controles.ComboBox()
      Me.chbGrupo = New Eniac.Controles.CheckBox()
      Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
      Me.lblGrabanLibro = New Eniac.Controles.Label()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
      Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.chbProvincia = New Eniac.Controles.CheckBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.lblTotal = New Eniac.Controles.Label()
      Me.txtSaldo = New Eniac.Controles.TextBox()
      Me.lblImpresion = New Eniac.Controles.Label()
      Me.rbtImpresion1PorHoja = New Eniac.Controles.RadioButton()
      Me.rbtImpresionNormal = New Eniac.Controles.RadioButton()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFiltros.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.TipoImpresora, Me.IdSucursal, Me.TipoDocVendedor, Me.NroDocVendedor, Me.NombreVendedor, Me.IdCliente, Me.CodigoCliente, Me.NombreCliente, Me.NombreCliente2, Me.NombreZonaGeografica, Me.IdTipoComprobante, Me.DescripcionTipoComprobante, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.Fecha, Me.FechaVencimiento, Me.ImporteTotal, Me.Saldo, Me.Total, Me.IdFormasPago, Me.DescripcionFormasPago, Me.Observacion})
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle13
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(5, 236)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(973, 277)
      Me.dgvDetalle.TabIndex = 1
      '
      'Ver
      '
      Me.Ver.DataPropertyName = "Ver"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.Ver.DefaultCellStyle = DataGridViewCellStyle2
      Me.Ver.HeaderText = "Ver"
      Me.Ver.Name = "Ver"
      Me.Ver.ReadOnly = True
      Me.Ver.Text = "Ver"
      Me.Ver.Width = 30
      '
      'TipoImpresora
      '
      Me.TipoImpresora.DataPropertyName = "TipoImpresora"
      Me.TipoImpresora.HeaderText = "TipoImpresora"
      Me.TipoImpresora.Name = "TipoImpresora"
      Me.TipoImpresora.ReadOnly = True
      Me.TipoImpresora.Visible = False
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.ReadOnly = True
      Me.IdSucursal.Visible = False
      '
      'TipoDocVendedor
      '
      Me.TipoDocVendedor.DataPropertyName = "TipoDocVendedor"
      Me.TipoDocVendedor.HeaderText = "T.D. V."
      Me.TipoDocVendedor.Name = "TipoDocVendedor"
      Me.TipoDocVendedor.ReadOnly = True
      Me.TipoDocVendedor.Visible = False
      Me.TipoDocVendedor.Width = 50
      '
      'NroDocVendedor
      '
      Me.NroDocVendedor.DataPropertyName = "NroDocVendedor"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroDocVendedor.DefaultCellStyle = DataGridViewCellStyle3
      Me.NroDocVendedor.HeaderText = "Doc. V."
      Me.NroDocVendedor.Name = "NroDocVendedor"
      Me.NroDocVendedor.ReadOnly = True
      Me.NroDocVendedor.Visible = False
      Me.NroDocVendedor.Width = 50
      '
      'NombreVendedor
      '
      Me.NombreVendedor.DataPropertyName = "NombreVendedor"
      Me.NombreVendedor.HeaderText = "Nombre Vendedor"
      Me.NombreVendedor.Name = "NombreVendedor"
      Me.NombreVendedor.ReadOnly = True
      Me.NombreVendedor.Width = 120
      '
      'IdCliente
      '
      Me.IdCliente.DataPropertyName = "IdCliente"
      Me.IdCliente.HeaderText = "IdCliente"
      Me.IdCliente.Name = "IdCliente"
      Me.IdCliente.ReadOnly = True
      Me.IdCliente.Visible = False
      '
      'CodigoCliente
      '
      Me.CodigoCliente.DataPropertyName = "CodigoCliente"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CodigoCliente.DefaultCellStyle = DataGridViewCellStyle4
      Me.CodigoCliente.HeaderText = "Código"
      Me.CodigoCliente.Name = "CodigoCliente"
      Me.CodigoCliente.ReadOnly = True
      Me.CodigoCliente.Width = 65
      '
      'NombreCliente
      '
      Me.NombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "Nombre Cliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      '
      'NombreCliente2
      '
      Me.NombreCliente2.DataPropertyName = "NombreCliente2"
      Me.NombreCliente2.HeaderText = "NombreCliente2"
      Me.NombreCliente2.Name = "NombreCliente2"
      Me.NombreCliente2.ReadOnly = True
      Me.NombreCliente2.Visible = False
      Me.NombreCliente2.Width = 198
      '
      'NombreZonaGeografica
      '
      Me.NombreZonaGeografica.DataPropertyName = "NombreZonaGeografica"
      Me.NombreZonaGeografica.HeaderText = "Zona Geografica"
      Me.NombreZonaGeografica.Name = "NombreZonaGeografica"
      Me.NombreZonaGeografica.ReadOnly = True
      Me.NombreZonaGeografica.Width = 120
      '
      'IdTipoComprobante
      '
      Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.IdTipoComprobante.HeaderText = "Comprobante"
      Me.IdTipoComprobante.Name = "IdTipoComprobante"
      Me.IdTipoComprobante.ReadOnly = True
      '
      'DescripcionTipoComprobante
      '
      Me.DescripcionTipoComprobante.DataPropertyName = "DescripcionTipoComprobante"
      Me.DescripcionTipoComprobante.HeaderText = "DescripcionTipoComprobante"
      Me.DescripcionTipoComprobante.Name = "DescripcionTipoComprobante"
      Me.DescripcionTipoComprobante.ReadOnly = True
      Me.DescripcionTipoComprobante.Visible = False
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle5
      Me.Letra.HeaderText = "Let."
      Me.Letra.Name = "Letra"
      Me.Letra.ReadOnly = True
      Me.Letra.Width = 30
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle6
      Me.CentroEmisor.HeaderText = "Emisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.ReadOnly = True
      Me.CentroEmisor.Width = 40
      '
      'NumeroComprobante
      '
      Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle7
      Me.NumeroComprobante.HeaderText = "Numero"
      Me.NumeroComprobante.Name = "NumeroComprobante"
      Me.NumeroComprobante.ReadOnly = True
      Me.NumeroComprobante.Width = 70
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "dd/MM/yyyy"
      DataGridViewCellStyle8.NullValue = Nothing
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle8
      Me.Fecha.HeaderText = "Emisión"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.ReadOnly = True
      Me.Fecha.Width = 70
      '
      'FechaVencimiento
      '
      Me.FechaVencimiento.DataPropertyName = "FechaVencimiento"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "dd/MM/yyyy"
      Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle9
      Me.FechaVencimiento.HeaderText = "Vencimiento"
      Me.FechaVencimiento.Name = "FechaVencimiento"
      Me.FechaVencimiento.ReadOnly = True
      Me.FechaVencimiento.Visible = False
      Me.FechaVencimiento.Width = 70
      '
      'ImporteTotal
      '
      Me.ImporteTotal.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle10.Format = "N2"
      Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle10
      Me.ImporteTotal.HeaderText = "Importe"
      Me.ImporteTotal.Name = "ImporteTotal"
      Me.ImporteTotal.ReadOnly = True
      Me.ImporteTotal.Width = 80
      '
      'Saldo
      '
      Me.Saldo.DataPropertyName = "Saldo"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle11.Format = "N2"
      Me.Saldo.DefaultCellStyle = DataGridViewCellStyle11
      Me.Saldo.HeaderText = "Saldo"
      Me.Saldo.Name = "Saldo"
      Me.Saldo.ReadOnly = True
      Me.Saldo.Width = 80
      '
      'Total
      '
      Me.Total.DataPropertyName = "Total"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle12.Format = "N2"
      Me.Total.DefaultCellStyle = DataGridViewCellStyle12
      Me.Total.HeaderText = "Total"
      Me.Total.Name = "Total"
      Me.Total.ReadOnly = True
      Me.Total.Visible = False
      Me.Total.Width = 80
      '
      'IdFormasPago
      '
      Me.IdFormasPago.DataPropertyName = "IdFormasPago"
      Me.IdFormasPago.HeaderText = "IdFormasPago"
      Me.IdFormasPago.Name = "IdFormasPago"
      Me.IdFormasPago.ReadOnly = True
      Me.IdFormasPago.Visible = False
      '
      'DescripcionFormasPago
      '
      Me.DescripcionFormasPago.DataPropertyName = "DescripcionFormasPago"
      Me.DescripcionFormasPago.HeaderText = "DescripcionFormasPago"
      Me.DescripcionFormasPago.Name = "DescripcionFormasPago"
      Me.DescripcionFormasPago.ReadOnly = True
      Me.DescripcionFormasPago.Visible = False
      '
      'Observacion
      '
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observacion"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.ReadOnly = True
      Me.Observacion.Visible = False
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.GroupBox3)
      Me.grbFiltros.Controls.Add(Me.GroupBox2)
      Me.grbFiltros.Controls.Add(Me.GroupBox1)
      Me.grbFiltros.Controls.Add(Me.chbAgruparIdClienteCtaCte)
      Me.grbFiltros.Controls.Add(Me.cmbProvincia)
      Me.grbFiltros.Controls.Add(Me.chbExcluirPreComprobantes)
      Me.grbFiltros.Controls.Add(Me.chbExcluirSaldosNegativos)
      Me.grbFiltros.Controls.Add(Me.chbExcluirAnticipos)
      Me.grbFiltros.Controls.Add(Me.cmbGrupos)
      Me.grbFiltros.Controls.Add(Me.chbGrupo)
      Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
      Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
      Me.grbFiltros.Controls.Add(Me.chbCategoria)
      Me.grbFiltros.Controls.Add(Me.cmbCategoria)
      Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
      Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
      Me.grbFiltros.Controls.Add(Me.chbVendedor)
      Me.grbFiltros.Controls.Add(Me.cmbVendedor)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.chbFecha)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.chbProvincia)
      Me.grbFiltros.Location = New System.Drawing.Point(5, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(973, 195)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.rbtVenActual)
      Me.GroupBox3.Controls.Add(Me.rbtVenMovimiento)
      Me.GroupBox3.Location = New System.Drawing.Point(250, 23)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(194, 33)
      Me.GroupBox3.TabIndex = 36
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Vendedor"
      '
      'rbtVenActual
      '
      Me.rbtVenActual.AutoSize = True
      Me.rbtVenActual.Checked = True
      Me.rbtVenActual.Location = New System.Drawing.Point(10, 12)
      Me.rbtVenActual.Name = "rbtVenActual"
      Me.rbtVenActual.Size = New System.Drawing.Size(55, 17)
      Me.rbtVenActual.TabIndex = 34
      Me.rbtVenActual.TabStop = True
      Me.rbtVenActual.Text = "Actual"
      Me.rbtVenActual.UseVisualStyleBackColor = True
      '
      'rbtVenMovimiento
      '
      Me.rbtVenMovimiento.AutoSize = True
      Me.rbtVenMovimiento.Location = New System.Drawing.Point(110, 12)
      Me.rbtVenMovimiento.Name = "rbtVenMovimiento"
      Me.rbtVenMovimiento.Size = New System.Drawing.Size(79, 17)
      Me.rbtVenMovimiento.TabIndex = 33
      Me.rbtVenMovimiento.Text = "Movimiento"
      Me.rbtVenMovimiento.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.optConSaldo)
      Me.GroupBox2.Controls.Add(Me.optTodos)
      Me.GroupBox2.Location = New System.Drawing.Point(304, 91)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(194, 36)
      Me.GroupBox2.TabIndex = 36
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Saldo"
      '
      'optConSaldo
      '
      Me.optConSaldo.AutoSize = True
      Me.optConSaldo.BindearPropiedadControl = Nothing
      Me.optConSaldo.BindearPropiedadEntidad = Nothing
      Me.optConSaldo.Checked = True
      Me.optConSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.optConSaldo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optConSaldo.IsPK = False
      Me.optConSaldo.IsRequired = False
      Me.optConSaldo.Key = Nothing
      Me.optConSaldo.LabelAsoc = Nothing
      Me.optConSaldo.Location = New System.Drawing.Point(11, 13)
      Me.optConSaldo.Name = "optConSaldo"
      Me.optConSaldo.Size = New System.Drawing.Size(97, 17)
      Me.optConSaldo.TabIndex = 12
      Me.optConSaldo.TabStop = True
      Me.optConSaldo.Text = "Solo con Saldo"
      Me.optConSaldo.UseVisualStyleBackColor = True
      '
      'optTodos
      '
      Me.optTodos.AutoSize = True
      Me.optTodos.BindearPropiedadControl = Nothing
      Me.optTodos.BindearPropiedadEntidad = Nothing
      Me.optTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.optTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optTodos.IsPK = False
      Me.optTodos.IsRequired = False
      Me.optTodos.Key = Nothing
      Me.optTodos.LabelAsoc = Nothing
      Me.optTodos.Location = New System.Drawing.Point(110, 13)
      Me.optTodos.Name = "optTodos"
      Me.optTodos.Size = New System.Drawing.Size(55, 17)
      Me.optTodos.TabIndex = 13
      Me.optTodos.Text = "Todos"
      Me.optTodos.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.rbtCatActual)
      Me.GroupBox1.Controls.Add(Me.rbtCatMovimiento)
      Me.GroupBox1.Location = New System.Drawing.Point(304, 140)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(194, 33)
      Me.GroupBox1.TabIndex = 35
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Categoría"
      '
      'rbtCatActual
      '
      Me.rbtCatActual.AutoSize = True
      Me.rbtCatActual.Checked = True
      Me.rbtCatActual.Location = New System.Drawing.Point(10, 12)
      Me.rbtCatActual.Name = "rbtCatActual"
      Me.rbtCatActual.Size = New System.Drawing.Size(55, 17)
      Me.rbtCatActual.TabIndex = 34
      Me.rbtCatActual.TabStop = True
      Me.rbtCatActual.Text = "Actual"
      Me.rbtCatActual.UseVisualStyleBackColor = True
      '
      'rbtCatMovimiento
      '
      Me.rbtCatMovimiento.AutoSize = True
      Me.rbtCatMovimiento.Location = New System.Drawing.Point(110, 12)
      Me.rbtCatMovimiento.Name = "rbtCatMovimiento"
      Me.rbtCatMovimiento.Size = New System.Drawing.Size(79, 17)
      Me.rbtCatMovimiento.TabIndex = 33
      Me.rbtCatMovimiento.Text = "Movimiento"
      Me.rbtCatMovimiento.UseVisualStyleBackColor = True
      '
      'chbAgruparIdClienteCtaCte
      '
      Me.chbAgruparIdClienteCtaCte.AutoSize = True
      Me.chbAgruparIdClienteCtaCte.Location = New System.Drawing.Point(534, 165)
      Me.chbAgruparIdClienteCtaCte.Name = "chbAgruparIdClienteCtaCte"
      Me.chbAgruparIdClienteCtaCte.Size = New System.Drawing.Size(222, 17)
      Me.chbAgruparIdClienteCtaCte.TabIndex = 31
      Me.chbAgruparIdClienteCtaCte.Text = "Agrupado por Cliente de Cuenta Corriente"
      Me.chbAgruparIdClienteCtaCte.UseVisualStyleBackColor = True
      '
      'cmbProvincia
      '
      Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
      Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
      Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbProvincia.Enabled = False
      Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbProvincia.FormattingEnabled = True
      Me.cmbProvincia.IsPK = False
      Me.cmbProvincia.IsRequired = True
      Me.cmbProvincia.Key = Nothing
      Me.cmbProvincia.LabelAsoc = Nothing
      Me.cmbProvincia.Location = New System.Drawing.Point(731, 59)
      Me.cmbProvincia.Name = "cmbProvincia"
      Me.cmbProvincia.Size = New System.Drawing.Size(91, 21)
      Me.cmbProvincia.TabIndex = 27
      '
      'chbExcluirPreComprobantes
      '
      Me.chbExcluirPreComprobantes.AutoSize = True
      Me.chbExcluirPreComprobantes.BindearPropiedadControl = Nothing
      Me.chbExcluirPreComprobantes.BindearPropiedadEntidad = Nothing
      Me.chbExcluirPreComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExcluirPreComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExcluirPreComprobantes.IsPK = False
      Me.chbExcluirPreComprobantes.IsRequired = False
      Me.chbExcluirPreComprobantes.Key = Nothing
      Me.chbExcluirPreComprobantes.LabelAsoc = Nothing
      Me.chbExcluirPreComprobantes.Location = New System.Drawing.Point(534, 142)
      Me.chbExcluirPreComprobantes.Name = "chbExcluirPreComprobantes"
      Me.chbExcluirPreComprobantes.Size = New System.Drawing.Size(147, 17)
      Me.chbExcluirPreComprobantes.TabIndex = 9
      Me.chbExcluirPreComprobantes.Text = "Excluir Pre-Comprobantes"
      Me.chbExcluirPreComprobantes.UseVisualStyleBackColor = True
      '
      'chbExcluirSaldosNegativos
      '
      Me.chbExcluirSaldosNegativos.AutoSize = True
      Me.chbExcluirSaldosNegativos.BindearPropiedadControl = Nothing
      Me.chbExcluirSaldosNegativos.BindearPropiedadEntidad = Nothing
      Me.chbExcluirSaldosNegativos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExcluirSaldosNegativos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExcluirSaldosNegativos.IsPK = False
      Me.chbExcluirSaldosNegativos.IsRequired = False
      Me.chbExcluirSaldosNegativos.Key = Nothing
      Me.chbExcluirSaldosNegativos.LabelAsoc = Nothing
      Me.chbExcluirSaldosNegativos.Location = New System.Drawing.Point(534, 96)
      Me.chbExcluirSaldosNegativos.Name = "chbExcluirSaldosNegativos"
      Me.chbExcluirSaldosNegativos.Size = New System.Drawing.Size(143, 17)
      Me.chbExcluirSaldosNegativos.TabIndex = 2
      Me.chbExcluirSaldosNegativos.Text = "Excluir Saldos Negativos"
      Me.chbExcluirSaldosNegativos.UseVisualStyleBackColor = True
      '
      'chbExcluirAnticipos
      '
      Me.chbExcluirAnticipos.AutoSize = True
      Me.chbExcluirAnticipos.BindearPropiedadControl = Nothing
      Me.chbExcluirAnticipos.BindearPropiedadEntidad = Nothing
      Me.chbExcluirAnticipos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExcluirAnticipos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExcluirAnticipos.IsPK = False
      Me.chbExcluirAnticipos.IsRequired = False
      Me.chbExcluirAnticipos.Key = Nothing
      Me.chbExcluirAnticipos.LabelAsoc = Nothing
      Me.chbExcluirAnticipos.Location = New System.Drawing.Point(534, 119)
      Me.chbExcluirAnticipos.Name = "chbExcluirAnticipos"
      Me.chbExcluirAnticipos.Size = New System.Drawing.Size(103, 17)
      Me.chbExcluirAnticipos.TabIndex = 5
      Me.chbExcluirAnticipos.Text = "Excluir Anticipos"
      Me.chbExcluirAnticipos.UseVisualStyleBackColor = True
      '
      'cmbGrupos
      '
      Me.cmbGrupos.BindearPropiedadControl = Nothing
      Me.cmbGrupos.BindearPropiedadEntidad = Nothing
      Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGrupos.Enabled = False
      Me.cmbGrupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbGrupos.FormattingEnabled = True
      Me.cmbGrupos.IsPK = False
      Me.cmbGrupos.IsRequired = False
      Me.cmbGrupos.ItemHeight = 13
      Me.cmbGrupos.Key = Nothing
      Me.cmbGrupos.LabelAsoc = Nothing
      Me.cmbGrupos.Location = New System.Drawing.Point(131, 119)
      Me.cmbGrupos.Name = "cmbGrupos"
      Me.cmbGrupos.Size = New System.Drawing.Size(144, 21)
      Me.cmbGrupos.TabIndex = 28
      '
      'chbGrupo
      '
      Me.chbGrupo.AutoSize = True
      Me.chbGrupo.BindearPropiedadControl = Nothing
      Me.chbGrupo.BindearPropiedadEntidad = Nothing
      Me.chbGrupo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbGrupo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbGrupo.IsPK = False
      Me.chbGrupo.IsRequired = False
      Me.chbGrupo.Key = Nothing
      Me.chbGrupo.LabelAsoc = Nothing
      Me.chbGrupo.Location = New System.Drawing.Point(12, 123)
      Me.chbGrupo.Name = "chbGrupo"
      Me.chbGrupo.Size = New System.Drawing.Size(55, 17)
      Me.chbGrupo.TabIndex = 10
      Me.chbGrupo.Text = "Grupo"
      Me.chbGrupo.UseVisualStyleBackColor = True
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
      Me.cmbGrabanLibro.Location = New System.Drawing.Point(131, 171)
      Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
      Me.cmbGrabanLibro.Size = New System.Drawing.Size(144, 21)
      Me.cmbGrabanLibro.TabIndex = 11
      '
      'lblGrabanLibro
      '
      Me.lblGrabanLibro.AutoSize = True
      Me.lblGrabanLibro.Location = New System.Drawing.Point(19, 174)
      Me.lblGrabanLibro.Name = "lblGrabanLibro"
      Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
      Me.lblGrabanLibro.TabIndex = 29
      Me.lblGrabanLibro.Text = "Graban Libro"
      '
      'chbCategoria
      '
      Me.chbCategoria.AutoSize = True
      Me.chbCategoria.BindearPropiedadControl = Nothing
      Me.chbCategoria.BindearPropiedadEntidad = Nothing
      Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCategoria.IsPK = False
      Me.chbCategoria.IsRequired = False
      Me.chbCategoria.Key = Nothing
      Me.chbCategoria.LabelAsoc = Nothing
      Me.chbCategoria.Location = New System.Drawing.Point(12, 149)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 7
      Me.chbCategoria.Text = "Categoria"
      Me.chbCategoria.UseVisualStyleBackColor = True
      '
      'cmbCategoria
      '
      Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
      Me.cmbCategoria.BindearPropiedadEntidad = "Categoria.IdCategoria"
      Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoria.Enabled = False
      Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoria.FormattingEnabled = True
      Me.cmbCategoria.IsPK = False
      Me.cmbCategoria.IsRequired = True
      Me.cmbCategoria.Key = Nothing
      Me.cmbCategoria.LabelAsoc = Nothing
      Me.cmbCategoria.Location = New System.Drawing.Point(131, 145)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(144, 21)
      Me.cmbCategoria.TabIndex = 26
      '
      'chbZonaGeografica
      '
      Me.chbZonaGeografica.AutoSize = True
      Me.chbZonaGeografica.BindearPropiedadControl = Nothing
      Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbZonaGeografica.IsPK = False
      Me.chbZonaGeografica.IsRequired = False
      Me.chbZonaGeografica.Key = Nothing
      Me.chbZonaGeografica.LabelAsoc = Nothing
      Me.chbZonaGeografica.Location = New System.Drawing.Point(456, 61)
      Me.chbZonaGeografica.Name = "chbZonaGeografica"
      Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
      Me.chbZonaGeografica.TabIndex = 4
      Me.chbZonaGeografica.Text = "Zona Geográfica"
      Me.chbZonaGeografica.UseVisualStyleBackColor = True
      '
      'cmbZonaGeografica
      '
      Me.cmbZonaGeografica.BindearPropiedadControl = Nothing
      Me.cmbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbZonaGeografica.Enabled = False
      Me.cmbZonaGeografica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbZonaGeografica.FormattingEnabled = True
      Me.cmbZonaGeografica.IsPK = False
      Me.cmbZonaGeografica.IsRequired = False
      Me.cmbZonaGeografica.Key = Nothing
      Me.cmbZonaGeografica.LabelAsoc = Nothing
      Me.cmbZonaGeografica.Location = New System.Drawing.Point(565, 59)
      Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
      Me.cmbZonaGeografica.Size = New System.Drawing.Size(92, 21)
      Me.cmbZonaGeografica.TabIndex = 24
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
      Me.chbVendedor.Location = New System.Drawing.Point(12, 31)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 0
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
      Me.cmbVendedor.Location = New System.Drawing.Point(89, 29)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(150, 21)
      Me.cmbVendedor.TabIndex = 15
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
      Me.chbCliente.Location = New System.Drawing.Point(456, 31)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 1
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'chbFecha
      '
      Me.chbFecha.AutoSize = True
      Me.chbFecha.BindearPropiedadControl = Nothing
      Me.chbFecha.BindearPropiedadEntidad = Nothing
      Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFecha.IsPK = False
      Me.chbFecha.IsRequired = False
      Me.chbFecha.Key = Nothing
      Me.chbFecha.LabelAsoc = Nothing
      Me.chbFecha.Location = New System.Drawing.Point(12, 62)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(56, 17)
      Me.chbFecha.TabIndex = 3
      Me.chbFecha.Text = "Fecha"
      Me.chbFecha.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.Enabled = False
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(252, 60)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
      Me.dtpHasta.TabIndex = 23
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(213, 64)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 22
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(104, 60)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 21
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(64, 64)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 20
      Me.lblDesde.Text = "Desde"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.AyudaAlto = 408
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasCondiciones = CType(resources.GetObject("bscCodigoCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoCliente.ColumnasVisibles = CType(resources.GetObject("bscCodigoCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(517, 28)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 17
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(514, 14)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 16
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAlto = 408
      Me.bscCliente.AyudaAncho = 608
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasCondiciones = CType(resources.GetObject("bscCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCliente.ColumnasVisibles = CType(resources.GetObject("bscCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
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
      Me.bscCliente.Location = New System.Drawing.Point(612, 28)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(319, 23)
      Me.bscCliente.TabIndex = 19
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(614, 14)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 18
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
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(131, 91)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(144, 21)
      Me.cmbTiposComprobantes.TabIndex = 25
      '
      'btnConsultar
      '
      Me.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(831, 121)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 14
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.chbTipoComprobante.Location = New System.Drawing.Point(12, 93)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
      Me.chbTipoComprobante.TabIndex = 6
      Me.chbTipoComprobante.Text = "Tipo Comprobante"
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
      '
      'chbProvincia
      '
      Me.chbProvincia.AutoSize = True
      Me.chbProvincia.BindearPropiedadControl = Nothing
      Me.chbProvincia.BindearPropiedadEntidad = Nothing
      Me.chbProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProvincia.IsPK = False
      Me.chbProvincia.IsRequired = False
      Me.chbProvincia.Key = Nothing
      Me.chbProvincia.LabelAsoc = Nothing
      Me.chbProvincia.Location = New System.Drawing.Point(663, 61)
      Me.chbProvincia.Name = "chbProvincia"
      Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
      Me.chbProvincia.TabIndex = 8
      Me.chbProvincia.Text = "Provincia"
      Me.chbProvincia.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 6
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      Me.stsStado.Location = New System.Drawing.Point(0, 540)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(984, 22)
      Me.stsStado.TabIndex = 5
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(905, 17)
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
      Me.txtTotal.Location = New System.Drawing.Point(800, 513)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.txtTotal.Size = New System.Drawing.Size(80, 20)
      Me.txtTotal.TabIndex = 3
      Me.txtTotal.Text = "0.00"
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotal
      '
      Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotal.AutoSize = True
      Me.lblTotal.Location = New System.Drawing.Point(755, 516)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(34, 13)
      Me.lblTotal.TabIndex = 2
      Me.lblTotal.Text = "Total:"
      '
      'txtSaldo
      '
      Me.txtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSaldo.BindearPropiedadControl = Nothing
      Me.txtSaldo.BindearPropiedadEntidad = Nothing
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = ""
      Me.txtSaldo.IsDecimal = False
      Me.txtSaldo.IsNumber = False
      Me.txtSaldo.IsPK = False
      Me.txtSaldo.IsRequired = False
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Nothing
      Me.txtSaldo.Location = New System.Drawing.Point(880, 513)
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.ReadOnly = True
      Me.txtSaldo.Size = New System.Drawing.Size(80, 20)
      Me.txtSaldo.TabIndex = 4
      Me.txtSaldo.Text = "0.00"
      Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblImpresion
      '
      Me.lblImpresion.AutoSize = True
      Me.lblImpresion.Location = New System.Drawing.Point(10, 520)
      Me.lblImpresion.Name = "lblImpresion"
      Me.lblImpresion.Size = New System.Drawing.Size(52, 13)
      Me.lblImpresion.TabIndex = 25
      Me.lblImpresion.Text = "Impresión"
      '
      'rbtImpresion1PorHoja
      '
      Me.rbtImpresion1PorHoja.AutoSize = True
      Me.rbtImpresion1PorHoja.BindearPropiedadControl = Nothing
      Me.rbtImpresion1PorHoja.BindearPropiedadEntidad = Nothing
      Me.rbtImpresion1PorHoja.ForeColorFocus = System.Drawing.Color.Red
      Me.rbtImpresion1PorHoja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.rbtImpresion1PorHoja.IsPK = False
      Me.rbtImpresion1PorHoja.IsRequired = False
      Me.rbtImpresion1PorHoja.Key = Nothing
      Me.rbtImpresion1PorHoja.LabelAsoc = Me.lblImpresion
      Me.rbtImpresion1PorHoja.Location = New System.Drawing.Point(136, 518)
      Me.rbtImpresion1PorHoja.Name = "rbtImpresion1PorHoja"
      Me.rbtImpresion1PorHoja.Size = New System.Drawing.Size(64, 17)
      Me.rbtImpresion1PorHoja.TabIndex = 27
      Me.rbtImpresion1PorHoja.Text = "1 x Hoja"
      Me.rbtImpresion1PorHoja.UseVisualStyleBackColor = True
      '
      'rbtImpresionNormal
      '
      Me.rbtImpresionNormal.AutoSize = True
      Me.rbtImpresionNormal.BindearPropiedadControl = Nothing
      Me.rbtImpresionNormal.BindearPropiedadEntidad = Nothing
      Me.rbtImpresionNormal.Checked = True
      Me.rbtImpresionNormal.ForeColorFocus = System.Drawing.Color.Red
      Me.rbtImpresionNormal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.rbtImpresionNormal.IsPK = False
      Me.rbtImpresionNormal.IsRequired = False
      Me.rbtImpresionNormal.Key = Nothing
      Me.rbtImpresionNormal.LabelAsoc = Me.lblImpresion
      Me.rbtImpresionNormal.Location = New System.Drawing.Point(70, 518)
      Me.rbtImpresionNormal.Name = "rbtImpresionNormal"
      Me.rbtImpresionNormal.Size = New System.Drawing.Size(58, 17)
      Me.rbtImpresionNormal.TabIndex = 26
      Me.rbtImpresionNormal.TabStop = True
      Me.rbtImpresionNormal.Text = "Normal"
      Me.rbtImpresionNormal.UseVisualStyleBackColor = True
      '
      'ConsultarCtaCteClientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 562)
      Me.Controls.Add(Me.lblImpresion)
      Me.Controls.Add(Me.rbtImpresion1PorHoja)
      Me.Controls.Add(Me.rbtImpresionNormal)
      Me.Controls.Add(Me.txtSaldo)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.lblTotal)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.dgvDetalle)
      Me.KeyPreview = True
      Me.Name = "ConsultarCtaCteClientes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar Cuenta Corriente de Clientes"
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
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
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents optTodos As Eniac.Controles.RadioButton
   Friend WithEvents optConSaldo As Eniac.Controles.RadioButton
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblImpresion As Eniac.Controles.Label
   Friend WithEvents rbtImpresion1PorHoja As Eniac.Controles.RadioButton
   Friend WithEvents rbtImpresionNormal As Eniac.Controles.RadioButton
   Friend WithEvents cmbGrupos As Eniac.Controles.ComboBox
   Friend WithEvents chbGrupo As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirAnticipos As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirSaldosNegativos As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirPreComprobantes As Eniac.Controles.CheckBox
   Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents TipoImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreZonaGeografica As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescripcionTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdFormasPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescripcionFormasPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents chbProvincia As Eniac.Controles.CheckBox
   Public WithEvents cmbProvincia As Eniac.Controles.ComboBox
   Friend WithEvents chbAgruparIdClienteCtaCte As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtCatActual As System.Windows.Forms.RadioButton
   Friend WithEvents rbtCatMovimiento As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtVenActual As System.Windows.Forms.RadioButton
   Friend WithEvents rbtVenMovimiento As System.Windows.Forms.RadioButton
End Class
