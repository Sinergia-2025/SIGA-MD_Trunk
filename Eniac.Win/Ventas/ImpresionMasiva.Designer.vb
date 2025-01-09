<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionMasiva
   Inherits BaseForm

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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Imprime = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.colVer = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.TipoImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescripcionAbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FormaDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TotalImpuestos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colFechaImpresion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.lblExportado = New Eniac.Controles.Label()
      Me.cmbOrigenCategoria = New Eniac.Controles.ComboBox()
      Me.cmbExportado = New Eniac.Controles.ComboBox()
      Me.lblAfectaCaja = New Eniac.Controles.Label()
      Me.cmbCategoria = New Eniac.Win.ComboBoxCategorias()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.txtNroRepartoHasta = New Eniac.Controles.TextBox()
      Me.lblNroRepartoHasta = New Eniac.Controles.Label()
      Me.txtNroReparto = New Eniac.Controles.TextBox()
      Me.chbOrdenInverso = New Eniac.Controles.CheckBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.chbFormaPago = New Eniac.Controles.CheckBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.cmbAfectaCaja = New Eniac.Controles.ComboBox()
      Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
      Me.lblGrabanLibro = New Eniac.Controles.Label()
      Me.cmbEstadoComprobante = New Eniac.Controles.ComboBox()
      Me.chbEstadoComprobante = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbLetra = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.cmbImpreso = New Eniac.Controles.ComboBox()
      Me.lblImpreso = New Eniac.Controles.Label()
      Me.txtEmisor = New Eniac.Controles.TextBox()
      Me.lblEmisor = New Eniac.Controles.Label()
      Me.cmbLetras = New Eniac.Controles.ComboBox()
      Me.txtNroHasta = New Eniac.Controles.TextBox()
      Me.lblNroHasta = New Eniac.Controles.Label()
      Me.txtNroDesde = New Eniac.Controles.TextBox()
      Me.lblNroDesde = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.chbNumeroRep = New Eniac.Controles.CheckBox()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.tstBarra.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbExportar, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 3
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
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(77, 26)
        Me.tsbExportar.Text = "&Exportar"
        Me.tsbExportar.ToolTipText = "Imprimir"
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Imprime, Me.colVer, Me.TipoImpresora, Me.IdTipoComprobante, Me.DescripcionAbrev, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.Fecha, Me.IdCliente, Me.CodigoCliente, Me.NombreCliente, Me.NombreVendedor, Me.NombreCategoriaFiscal, Me.FormaDePago, Me.SubTotal, Me.TotalImpuestos, Me.ImporteTotal, Me.colFechaImpresion, Me.colIdSucursal})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDetalle.Location = New System.Drawing.Point(5, 235)
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
        Me.dgvDetalle.Size = New System.Drawing.Size(972, 302)
        Me.dgvDetalle.TabIndex = 2
        '
        'Imprime
        '
        Me.Imprime.DataPropertyName = "Imprime"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.NullValue = False
        Me.Imprime.DefaultCellStyle = DataGridViewCellStyle2
        Me.Imprime.HeaderText = "I."
        Me.Imprime.Name = "Imprime"
        Me.Imprime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Imprime.Width = 20
        '
        'colVer
        '
        Me.colVer.DataPropertyName = "Ver"
        Me.colVer.HeaderText = "V."
        Me.colVer.Name = "colVer"
        Me.colVer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colVer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colVer.Width = 20
        '
        'TipoImpresora
        '
        Me.TipoImpresora.DataPropertyName = "TipoImpresora"
        Me.TipoImpresora.HeaderText = "TipoImpresora"
        Me.TipoImpresora.Name = "TipoImpresora"
        Me.TipoImpresora.ReadOnly = True
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle3
        Me.Letra.HeaderText = "Let."
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Width = 30
        '
        'CentroEmisor
        '
        Me.CentroEmisor.DataPropertyName = "CentroEmisor"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle4
        Me.CentroEmisor.HeaderText = "Emisor"
        Me.CentroEmisor.Name = "CentroEmisor"
        Me.CentroEmisor.ReadOnly = True
        Me.CentroEmisor.Width = 40
        '
        'NumeroComprobante
        '
        Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle5
        Me.NumeroComprobante.HeaderText = "Numero"
        Me.NumeroComprobante.Name = "NumeroComprobante"
        Me.NumeroComprobante.ReadOnly = True
        Me.NumeroComprobante.Width = 55
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "dd/MM/yyyy HH:mm"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle6
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'IdCliente
        '
        Me.IdCliente.DataPropertyName = "IdCliente"
        Me.IdCliente.HeaderText = "IdCliente"
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.ReadOnly = True
        Me.IdCliente.Visible = False
        Me.IdCliente.Width = 55
        '
        'CodigoCliente
        '
        Me.CodigoCliente.DataPropertyName = "CodigoCliente"
        Me.CodigoCliente.HeaderText = "CodigoCliente"
        Me.CodigoCliente.Name = "CodigoCliente"
        Me.CodigoCliente.ReadOnly = True
        Me.CodigoCliente.Visible = False
        Me.CodigoCliente.Width = 80
        '
        'NombreCliente
        '
        Me.NombreCliente.DataPropertyName = "NombreCliente"
        Me.NombreCliente.HeaderText = "Cliente"
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.ReadOnly = True
        Me.NombreCliente.Width = 137
        '
        'NombreVendedor
        '
        Me.NombreVendedor.DataPropertyName = "NombreVendedor"
        Me.NombreVendedor.HeaderText = "Vendedor"
        Me.NombreVendedor.Name = "NombreVendedor"
        Me.NombreVendedor.ReadOnly = True
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
        Me.FormaDePago.Width = 64
        '
        'SubTotal
        '
        Me.SubTotal.DataPropertyName = "SubTotal"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle7
        Me.SubTotal.HeaderText = "Neto"
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.ReadOnly = True
        Me.SubTotal.Width = 70
        '
        'TotalImpuestos
        '
        Me.TotalImpuestos.DataPropertyName = "TotalImpuestos"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.TotalImpuestos.DefaultCellStyle = DataGridViewCellStyle8
        Me.TotalImpuestos.HeaderText = "Impuestos"
        Me.TotalImpuestos.Name = "TotalImpuestos"
        Me.TotalImpuestos.ReadOnly = True
        Me.TotalImpuestos.Width = 70
        '
        'ImporteTotal
        '
        Me.ImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle9
        Me.ImporteTotal.HeaderText = "Total"
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.ReadOnly = True
        Me.ImporteTotal.Width = 70
        '
        'colFechaImpresion
        '
        Me.colFechaImpresion.DataPropertyName = "FechaImpresion"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "dd/MM/yyyy HH:mm"
        Me.colFechaImpresion.DefaultCellStyle = DataGridViewCellStyle10
        Me.colFechaImpresion.HeaderText = "Impreso"
        Me.colFechaImpresion.Name = "colFechaImpresion"
        Me.colFechaImpresion.ReadOnly = True
        '
        'colIdSucursal
        '
        Me.colIdSucursal.DataPropertyName = "IdSucursal"
        Me.colIdSucursal.HeaderText = "Sucursal"
        Me.colIdSucursal.Name = "colIdSucursal"
        Me.colIdSucursal.ReadOnly = True
        Me.colIdSucursal.Visible = False
        '
        'stsStado
        '
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 540)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 4
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
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.lblExportado)
        Me.grbFiltros.Controls.Add(Me.cmbOrigenCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbExportado)
        Me.grbFiltros.Controls.Add(Me.cmbCategoria)
        Me.grbFiltros.Controls.Add(Me.lblCategoria)
        Me.grbFiltros.Controls.Add(Me.txtNroRepartoHasta)
        Me.grbFiltros.Controls.Add(Me.txtNroReparto)
        Me.grbFiltros.Controls.Add(Me.chbOrdenInverso)
        Me.grbFiltros.Controls.Add(Me.chbUsuario)
        Me.grbFiltros.Controls.Add(Me.cmbUsuario)
        Me.grbFiltros.Controls.Add(Me.chbFormaPago)
        Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbAfectaCaja)
        Me.grbFiltros.Controls.Add(Me.lblNroRepartoHasta)
        Me.grbFiltros.Controls.Add(Me.lblAfectaCaja)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.cmbEstadoComprobante)
        Me.grbFiltros.Controls.Add(Me.chbEstadoComprobante)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.chbLetra)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.cmbImpreso)
        Me.grbFiltros.Controls.Add(Me.lblImpreso)
        Me.grbFiltros.Controls.Add(Me.txtEmisor)
        Me.grbFiltros.Controls.Add(Me.lblEmisor)
        Me.grbFiltros.Controls.Add(Me.cmbLetras)
        Me.grbFiltros.Controls.Add(Me.txtNroHasta)
        Me.grbFiltros.Controls.Add(Me.lblNroHasta)
        Me.grbFiltros.Controls.Add(Me.txtNroDesde)
        Me.grbFiltros.Controls.Add(Me.lblNroDesde)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grbFiltros.Controls.Add(Me.chbNumeroRep)
        Me.grbFiltros.Location = New System.Drawing.Point(5, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(972, 176)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'lblExportado
        '
        Me.lblExportado.AutoSize = True
        Me.lblExportado.LabelAsoc = Nothing
        Me.lblExportado.Location = New System.Drawing.Point(2, 148)
        Me.lblExportado.Name = "lblExportado"
        Me.lblExportado.Size = New System.Drawing.Size(55, 13)
        Me.lblExportado.TabIndex = 42
        Me.lblExportado.Text = "Exportado"
        '
        'cmbOrigenCategoria
        '
        Me.cmbOrigenCategoria.BindearPropiedadControl = Nothing
        Me.cmbOrigenCategoria.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenCategoria.FormattingEnabled = True
        Me.cmbOrigenCategoria.IsPK = False
        Me.cmbOrigenCategoria.IsRequired = False
        Me.cmbOrigenCategoria.Key = Nothing
        Me.cmbOrigenCategoria.LabelAsoc = Nothing
        Me.cmbOrigenCategoria.Location = New System.Drawing.Point(883, 55)
        Me.cmbOrigenCategoria.Name = "cmbOrigenCategoria"
        Me.cmbOrigenCategoria.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenCategoria.TabIndex = 20
        '
        'cmbExportado
        '
        Me.cmbExportado.BindearPropiedadControl = Nothing
        Me.cmbExportado.BindearPropiedadEntidad = Nothing
        Me.cmbExportado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExportado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbExportado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbExportado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbExportado.FormattingEnabled = True
        Me.cmbExportado.IsPK = False
        Me.cmbExportado.IsRequired = False
        Me.cmbExportado.Key = Nothing
        Me.cmbExportado.LabelAsoc = Me.lblAfectaCaja
        Me.cmbExportado.Location = New System.Drawing.Point(91, 145)
        Me.cmbExportado.Name = "cmbExportado"
        Me.cmbExportado.Size = New System.Drawing.Size(83, 21)
        Me.cmbExportado.TabIndex = 43
        '
        'lblAfectaCaja
        '
        Me.lblAfectaCaja.AutoSize = True
        Me.lblAfectaCaja.LabelAsoc = Nothing
        Me.lblAfectaCaja.Location = New System.Drawing.Point(773, 20)
        Me.lblAfectaCaja.Name = "lblAfectaCaja"
        Me.lblAfectaCaja.Size = New System.Drawing.Size(62, 13)
        Me.lblAfectaCaja.TabIndex = 9
        Me.lblAfectaCaja.Text = "Afecta Caja"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BindearPropiedadControl = Nothing
        Me.cmbCategoria.BindearPropiedadEntidad = Nothing
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.IsPK = False
        Me.cmbCategoria.IsRequired = False
        Me.cmbCategoria.Key = Nothing
        Me.cmbCategoria.LabelAsoc = Me.lblCategoria
        Me.cmbCategoria.Location = New System.Drawing.Point(734, 55)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(147, 21)
        Me.cmbCategoria.TabIndex = 19
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.LabelAsoc = Nothing
        Me.lblCategoria.Location = New System.Drawing.Point(679, 58)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(54, 13)
        Me.lblCategoria.TabIndex = 18
        Me.lblCategoria.Text = "Categoría"
        '
        'txtNroRepartoHasta
        '
        Me.txtNroRepartoHasta.BindearPropiedadControl = Nothing
        Me.txtNroRepartoHasta.BindearPropiedadEntidad = Nothing
        Me.txtNroRepartoHasta.Enabled = False
        Me.txtNroRepartoHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroRepartoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroRepartoHasta.Formato = "##0"
        Me.txtNroRepartoHasta.IsDecimal = False
        Me.txtNroRepartoHasta.IsNumber = True
        Me.txtNroRepartoHasta.IsPK = False
        Me.txtNroRepartoHasta.IsRequired = False
        Me.txtNroRepartoHasta.Key = ""
        Me.txtNroRepartoHasta.LabelAsoc = Me.lblNroRepartoHasta
        Me.txtNroRepartoHasta.Location = New System.Drawing.Point(789, 85)
        Me.txtNroRepartoHasta.MaxLength = 8
        Me.txtNroRepartoHasta.Name = "txtNroRepartoHasta"
        Me.txtNroRepartoHasta.Size = New System.Drawing.Size(57, 20)
        Me.txtNroRepartoHasta.TabIndex = 34
        Me.txtNroRepartoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroRepartoHasta
        '
        Me.lblNroRepartoHasta.AutoSize = True
        Me.lblNroRepartoHasta.LabelAsoc = Nothing
        Me.lblNroRepartoHasta.Location = New System.Drawing.Point(776, 88)
        Me.lblNroRepartoHasta.Name = "lblNroRepartoHasta"
        Me.lblNroRepartoHasta.Size = New System.Drawing.Size(13, 13)
        Me.lblNroRepartoHasta.TabIndex = 33
        Me.lblNroRepartoHasta.Text = "a"
        '
        'txtNroReparto
        '
        Me.txtNroReparto.BindearPropiedadControl = Nothing
        Me.txtNroReparto.BindearPropiedadEntidad = Nothing
        Me.txtNroReparto.Enabled = False
        Me.txtNroReparto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroReparto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroReparto.Formato = "##0"
        Me.txtNroReparto.IsDecimal = False
        Me.txtNroReparto.IsNumber = True
        Me.txtNroReparto.IsPK = False
        Me.txtNroReparto.IsRequired = False
        Me.txtNroReparto.Key = ""
        Me.txtNroReparto.LabelAsoc = Nothing
        Me.txtNroReparto.Location = New System.Drawing.Point(718, 85)
        Me.txtNroReparto.MaxLength = 8
        Me.txtNroReparto.Name = "txtNroReparto"
        Me.txtNroReparto.Size = New System.Drawing.Size(57, 20)
        Me.txtNroReparto.TabIndex = 32
        Me.txtNroReparto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbOrdenInverso
        '
        Me.chbOrdenInverso.AutoSize = True
        Me.chbOrdenInverso.BindearPropiedadControl = Nothing
        Me.chbOrdenInverso.BindearPropiedadEntidad = Nothing
        Me.chbOrdenInverso.Checked = True
        Me.chbOrdenInverso.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOrdenInverso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenInverso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenInverso.IsPK = False
        Me.chbOrdenInverso.IsRequired = False
        Me.chbOrdenInverso.Key = Nothing
        Me.chbOrdenInverso.LabelAsoc = Nothing
        Me.chbOrdenInverso.Location = New System.Drawing.Point(753, 120)
        Me.chbOrdenInverso.Name = "chbOrdenInverso"
        Me.chbOrdenInverso.Size = New System.Drawing.Size(93, 17)
        Me.chbOrdenInverso.TabIndex = 41
        Me.chbOrdenInverso.Text = "Orden Inverso"
        Me.chbOrdenInverso.UseVisualStyleBackColor = True
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
        Me.chbUsuario.Location = New System.Drawing.Point(507, 120)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 39
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
        Me.cmbUsuario.Location = New System.Drawing.Point(580, 118)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(148, 21)
        Me.cmbUsuario.TabIndex = 40
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
        Me.chbFormaPago.Location = New System.Drawing.Point(274, 120)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFormaPago.TabIndex = 37
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
        Me.cmbFormaPago.Location = New System.Drawing.Point(376, 118)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(119, 21)
        Me.cmbFormaPago.TabIndex = 38
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
        Me.chbVendedor.Location = New System.Drawing.Point(5, 120)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 35
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
        Me.cmbVendedor.Location = New System.Drawing.Point(91, 118)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(162, 21)
        Me.cmbVendedor.TabIndex = 36
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
        Me.cmbAfectaCaja.Location = New System.Drawing.Point(839, 16)
        Me.cmbAfectaCaja.Name = "cmbAfectaCaja"
        Me.cmbAfectaCaja.Size = New System.Drawing.Size(83, 21)
        Me.cmbAfectaCaja.TabIndex = 10
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
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(676, 15)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
        Me.cmbGrabanLibro.TabIndex = 8
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(602, 19)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 7
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'cmbEstadoComprobante
        '
        Me.cmbEstadoComprobante.BindearPropiedadControl = Nothing
        Me.cmbEstadoComprobante.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoComprobante.Enabled = False
        Me.cmbEstadoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoComprobante.FormattingEnabled = True
        Me.cmbEstadoComprobante.IsPK = False
        Me.cmbEstadoComprobante.IsRequired = False
        Me.cmbEstadoComprobante.Key = Nothing
        Me.cmbEstadoComprobante.LabelAsoc = Nothing
        Me.cmbEstadoComprobante.Location = New System.Drawing.Point(530, 55)
        Me.cmbEstadoComprobante.Name = "cmbEstadoComprobante"
        Me.cmbEstadoComprobante.Size = New System.Drawing.Size(143, 21)
        Me.cmbEstadoComprobante.TabIndex = 17
        Me.cmbEstadoComprobante.TabStop = False
        '
        'chbEstadoComprobante
        '
        Me.chbEstadoComprobante.AutoSize = True
        Me.chbEstadoComprobante.BindearPropiedadControl = Nothing
        Me.chbEstadoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbEstadoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstadoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstadoComprobante.IsPK = False
        Me.chbEstadoComprobante.IsRequired = False
        Me.chbEstadoComprobante.Key = Nothing
        Me.chbEstadoComprobante.LabelAsoc = Nothing
        Me.chbEstadoComprobante.Location = New System.Drawing.Point(472, 57)
        Me.chbEstadoComprobante.Name = "chbEstadoComprobante"
        Me.chbEstadoComprobante.Size = New System.Drawing.Size(59, 17)
        Me.chbEstadoComprobante.TabIndex = 16
        Me.chbEstadoComprobante.Text = "Estado"
        Me.chbEstadoComprobante.UseVisualStyleBackColor = True
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(67, 57)
        Me.bscCodigoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 13
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(64, 41)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 12
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
        Me.bscCliente.Location = New System.Drawing.Point(164, 57)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(290, 27)
        Me.bscCliente.TabIndex = 15
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(161, 41)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 14
        Me.lblNombre.Text = "Nombre"
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
        Me.chbCliente.Location = New System.Drawing.Point(5, 57)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 11
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'chbLetra
        '
        Me.chbLetra.AutoSize = True
        Me.chbLetra.BindearPropiedadControl = Nothing
        Me.chbLetra.BindearPropiedadEntidad = Nothing
        Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLetra.IsPK = False
        Me.chbLetra.IsRequired = False
        Me.chbLetra.Key = Nothing
        Me.chbLetra.LabelAsoc = Nothing
        Me.chbLetra.Location = New System.Drawing.Point(260, 88)
        Me.chbLetra.Name = "chbLetra"
        Me.chbLetra.Size = New System.Drawing.Size(50, 17)
        Me.chbLetra.TabIndex = 23
        Me.chbLetra.Text = "Letra"
        Me.chbLetra.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(5, 17)
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
        Me.dtpHasta.Location = New System.Drawing.Point(314, 15)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(277, 19)
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
        Me.dtpDesde.Location = New System.Drawing.Point(146, 15)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(102, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'cmbImpreso
        '
        Me.cmbImpreso.BindearPropiedadControl = Nothing
        Me.cmbImpreso.BindearPropiedadEntidad = Nothing
        Me.cmbImpreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbImpreso.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbImpreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbImpreso.FormattingEnabled = True
        Me.cmbImpreso.IsPK = False
        Me.cmbImpreso.IsRequired = False
        Me.cmbImpreso.ItemHeight = 13
        Me.cmbImpreso.Key = Nothing
        Me.cmbImpreso.LabelAsoc = Me.lblImpreso
        Me.cmbImpreso.Location = New System.Drawing.Point(519, 16)
        Me.cmbImpreso.Name = "cmbImpreso"
        Me.cmbImpreso.Size = New System.Drawing.Size(71, 21)
        Me.cmbImpreso.TabIndex = 6
        '
        'lblImpreso
        '
        Me.lblImpreso.AutoSize = True
        Me.lblImpreso.LabelAsoc = Nothing
        Me.lblImpreso.Location = New System.Drawing.Point(470, 20)
        Me.lblImpreso.Name = "lblImpreso"
        Me.lblImpreso.Size = New System.Drawing.Size(44, 13)
        Me.lblImpreso.TabIndex = 5
        Me.lblImpreso.Text = "Impreso"
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
        Me.txtEmisor.LabelAsoc = Me.lblEmisor
        Me.txtEmisor.Location = New System.Drawing.Point(401, 86)
        Me.txtEmisor.MaxLength = 12
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New System.Drawing.Size(35, 20)
        Me.txtEmisor.TabIndex = 26
        Me.txtEmisor.Text = "1"
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEmisor
        '
        Me.lblEmisor.AutoSize = True
        Me.lblEmisor.LabelAsoc = Nothing
        Me.lblEmisor.Location = New System.Drawing.Point(360, 90)
        Me.lblEmisor.Name = "lblEmisor"
        Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
        Me.lblEmisor.TabIndex = 25
        Me.lblEmisor.Text = "Emisor"
        '
        'cmbLetras
        '
        Me.cmbLetras.BindearPropiedadControl = Nothing
        Me.cmbLetras.BindearPropiedadEntidad = Nothing
        Me.cmbLetras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLetras.Enabled = False
        Me.cmbLetras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbLetras.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLetras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLetras.FormattingEnabled = True
        Me.cmbLetras.IsPK = False
        Me.cmbLetras.IsRequired = False
        Me.cmbLetras.ItemHeight = 13
        Me.cmbLetras.Items.AddRange(New Object() {"X", "A", "B", "C", "M"})
        Me.cmbLetras.Key = Nothing
        Me.cmbLetras.LabelAsoc = Nothing
        Me.cmbLetras.Location = New System.Drawing.Point(311, 86)
        Me.cmbLetras.Name = "cmbLetras"
        Me.cmbLetras.Size = New System.Drawing.Size(44, 21)
        Me.cmbLetras.TabIndex = 24
        '
        'txtNroHasta
        '
        Me.txtNroHasta.BindearPropiedadControl = Nothing
        Me.txtNroHasta.BindearPropiedadEntidad = Nothing
        Me.txtNroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroHasta.Formato = ""
        Me.txtNroHasta.IsDecimal = False
        Me.txtNroHasta.IsNumber = True
        Me.txtNroHasta.IsPK = False
        Me.txtNroHasta.IsRequired = False
        Me.txtNroHasta.Key = ""
        Me.txtNroHasta.LabelAsoc = Me.lblNroHasta
        Me.txtNroHasta.Location = New System.Drawing.Point(570, 86)
        Me.txtNroHasta.MaxLength = 12
        Me.txtNroHasta.Name = "txtNroHasta"
        Me.txtNroHasta.Size = New System.Drawing.Size(67, 20)
        Me.txtNroHasta.TabIndex = 30
        Me.txtNroHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroHasta
        '
        Me.lblNroHasta.AutoSize = True
        Me.lblNroHasta.LabelAsoc = Nothing
        Me.lblNroHasta.Location = New System.Drawing.Point(556, 90)
        Me.lblNroHasta.Name = "lblNroHasta"
        Me.lblNroHasta.Size = New System.Drawing.Size(13, 13)
        Me.lblNroHasta.TabIndex = 29
        Me.lblNroHasta.Text = "a"
        '
        'txtNroDesde
        '
        Me.txtNroDesde.BindearPropiedadControl = Nothing
        Me.txtNroDesde.BindearPropiedadEntidad = Nothing
        Me.txtNroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDesde.Formato = ""
        Me.txtNroDesde.IsDecimal = False
        Me.txtNroDesde.IsNumber = True
        Me.txtNroDesde.IsPK = False
        Me.txtNroDesde.IsRequired = False
        Me.txtNroDesde.Key = ""
        Me.txtNroDesde.LabelAsoc = Me.lblNroDesde
        Me.txtNroDesde.Location = New System.Drawing.Point(485, 86)
        Me.txtNroDesde.MaxLength = 12
        Me.txtNroDesde.Name = "txtNroDesde"
        Me.txtNroDesde.Size = New System.Drawing.Size(67, 20)
        Me.txtNroDesde.TabIndex = 28
        Me.txtNroDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroDesde
        '
        Me.lblNroDesde.AutoSize = True
        Me.lblNroDesde.LabelAsoc = Nothing
        Me.lblNroDesde.Location = New System.Drawing.Point(441, 90)
        Me.lblNroDesde.Name = "lblNroDesde"
        Me.lblNroDesde.Size = New System.Drawing.Size(44, 13)
        Me.lblNroDesde.TabIndex = 27
        Me.lblNroDesde.Text = "Número"
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
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(91, 86)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(162, 21)
        Me.cmbTiposComprobantes.TabIndex = 22
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(868, 95)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(98, 45)
        Me.btnConsultar.TabIndex = 44
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
        Me.chbTipoComprobante.Location = New System.Drawing.Point(5, 88)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(89, 17)
        Me.chbTipoComprobante.TabIndex = 21
        Me.chbTipoComprobante.Text = "Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'chbNumeroRep
        '
        Me.chbNumeroRep.AutoSize = True
        Me.chbNumeroRep.BindearPropiedadControl = Nothing
        Me.chbNumeroRep.BindearPropiedadEntidad = Nothing
        Me.chbNumeroRep.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroRep.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroRep.IsPK = False
        Me.chbNumeroRep.IsRequired = False
        Me.chbNumeroRep.Key = Nothing
        Me.chbNumeroRep.LabelAsoc = Nothing
        Me.chbNumeroRep.Location = New System.Drawing.Point(655, 87)
        Me.chbNumeroRep.Name = "chbNumeroRep"
        Me.chbNumeroRep.Size = New System.Drawing.Size(64, 17)
        Me.chbNumeroRep.TabIndex = 31
        Me.chbNumeroRep.Text = "Reparto"
        Me.chbNumeroRep.UseVisualStyleBackColor = True
        '
        'chbTodos
        '
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(4, 210)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(124, 22)
        Me.chbTodos.TabIndex = 1
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Seleccione la carpeta donde desea exportar los archivos"
        '
        'ImpresionMasiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.chbTodos)
        Me.KeyPreview = True
        Me.Name = "ImpresionMasiva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión Masiva"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents txtNroDesde As Eniac.Controles.TextBox
   Friend WithEvents lblNroDesde As Eniac.Controles.Label
   Friend WithEvents txtNroHasta As Eniac.Controles.TextBox
   Friend WithEvents lblNroHasta As Eniac.Controles.Label
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents lblEmisor As Eniac.Controles.Label
   Friend WithEvents cmbLetras As Eniac.Controles.ComboBox
   Friend WithEvents cmbImpreso As Eniac.Controles.ComboBox
   Friend WithEvents lblImpreso As Eniac.Controles.Label
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents cmbEstadoComprobante As Eniac.Controles.ComboBox
   Friend WithEvents chbEstadoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents cmbAfectaCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblAfectaCaja As Eniac.Controles.Label
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbOrdenInverso As Eniac.Controles.CheckBox
   Friend WithEvents txtNroReparto As Eniac.Controles.TextBox
   Friend WithEvents chbNumeroRep As Eniac.Controles.CheckBox
   Friend WithEvents txtNroRepartoHasta As Eniac.Controles.TextBox
   Friend WithEvents lblNroRepartoHasta As Eniac.Controles.Label
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Private WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
   Friend WithEvents Imprime As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents colVer As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents TipoImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescripcionAbrev As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FormaDePago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalImpuestos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colFechaImpresion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblCategoria As Eniac.Controles.Label
   Friend WithEvents cmbCategoria As Eniac.Win.ComboBoxCategorias
   Friend WithEvents cmbOrigenCategoria As Eniac.Controles.ComboBox
   Friend WithEvents cmbExportado As Eniac.Controles.ComboBox
   Friend WithEvents lblExportado As Eniac.Controles.Label
End Class
