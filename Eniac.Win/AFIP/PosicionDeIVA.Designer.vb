<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosicionDeIVA
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosicionDeIVA))
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
        Me.lblPeriodoFiscal = New Eniac.Controles.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New Eniac.Controles.TextBox()
        Me.DataGridView5 = New Eniac.Controles.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label11 = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.grbTotalCompras = New System.Windows.Forms.GroupBox()
        Me.txtComprasImpInt = New Eniac.Controles.TextBox()
        Me.txtComprasTotal = New Eniac.Controles.TextBox()
        Me.txtComprasIVA = New Eniac.Controles.TextBox()
        Me.txtComprasNeto = New Eniac.Controles.TextBox()
        Me.dgvCompras = New Eniac.Controles.DataGridView()
        Me.Label8 = New Eniac.Controles.Label()
        Me.grbTotalVentas = New System.Windows.Forms.GroupBox()
        Me.txtVentasImpInt = New Eniac.Controles.TextBox()
        Me.txtVentasTotal = New Eniac.Controles.TextBox()
        Me.txtVentasIVA = New Eniac.Controles.TextBox()
        Me.dgvVentas = New Eniac.Controles.DataGridView()
        Me.txtVentasNeto = New Eniac.Controles.TextBox()
        Me.Label7 = New Eniac.Controles.Label()
        Me.txtPosicionTotal = New Eniac.Controles.TextBox()
        Me.txtPosicionIVA = New Eniac.Controles.TextBox()
        Me.txtPosicionNeto = New Eniac.Controles.TextBox()
        Me.lblPosicion = New Eniac.Controles.Label()
        Me.txtPercepciones = New Eniac.Controles.TextBox()
        Me.lblPercepcion = New Eniac.Controles.Label()
        Me.txtRetenciones = New Eniac.Controles.TextBox()
        Me.lblRetenciones = New Eniac.Controles.Label()
        Me.txtPosicionFinalIVA = New Eniac.Controles.TextBox()
        Me.lblPosicionFinalIVA = New Eniac.Controles.Label()
        Me.txtPosicionImpInt = New Eniac.Controles.TextBox()
        Me.gvNombreSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvImpuestosInternos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcNombreSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcImpuestosInternos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbTotalCompras.SuspendLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbTotalVentas.SuspendLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(715, 29)
        Me.tstBarra.TabIndex = 7
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
        Me.tsbImprimir.Text = "Imprimir"
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
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.dtpPeriodoFiscal)
        Me.grbFiltros.Controls.Add(Me.lblPeriodoFiscal)
        Me.grbFiltros.Controls.Add(Me.GroupBox2)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(6, 30)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(608, 68)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtro"
        '
        'dtpPeriodoFiscal
        '
        Me.dtpPeriodoFiscal.BindearPropiedadControl = Nothing
        Me.dtpPeriodoFiscal.BindearPropiedadEntidad = Nothing
        Me.dtpPeriodoFiscal.CustomFormat = "MM/yyyy"
        Me.dtpPeriodoFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpPeriodoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpPeriodoFiscal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoFiscal.IsPK = False
        Me.dtpPeriodoFiscal.IsRequired = False
        Me.dtpPeriodoFiscal.Key = ""
        Me.dtpPeriodoFiscal.LabelAsoc = Me.lblPeriodoFiscal
        Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(94, 24)
        Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
        Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(68, 20)
        Me.dtpPeriodoFiscal.TabIndex = 2
        '
        'lblPeriodoFiscal
        '
        Me.lblPeriodoFiscal.AutoSize = True
        Me.lblPeriodoFiscal.LabelAsoc = Nothing
        Me.lblPeriodoFiscal.Location = New System.Drawing.Point(16, 28)
        Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
        Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
        Me.lblPeriodoFiscal.TabIndex = 1
        Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.DataGridView5)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(44, 522)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(333, 171)
        Me.GroupBox2.TabIndex = 102
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Compras"
        '
        'TextBox2
        '
        Me.TextBox2.BindearPropiedadControl = Nothing
        Me.TextBox2.BindearPropiedadEntidad = Nothing
        Me.TextBox2.ForeColorFocus = System.Drawing.Color.Red
        Me.TextBox2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.TextBox2.Formato = ""
        Me.TextBox2.IsDecimal = False
        Me.TextBox2.IsNumber = False
        Me.TextBox2.IsPK = False
        Me.TextBox2.IsRequired = False
        Me.TextBox2.Key = ""
        Me.TextBox2.LabelAsoc = Nothing
        Me.TextBox2.Location = New System.Drawing.Point(266, 142)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(62, 20)
        Me.TextBox2.TabIndex = 97
        '
        'DataGridView5
        '
        Me.DataGridView5.AllowUserToAddRows = False
        Me.DataGridView5.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView5.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView5.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView5.Location = New System.Drawing.Point(16, 19)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView5.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView5.RowHeadersVisible = False
        Me.DataGridView5.Size = New System.Drawing.Size(311, 117)
        Me.DataGridView5.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sucursal"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Comprobante"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.LabelAsoc = Nothing
        Me.Label11.Location = New System.Drawing.Point(185, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 96
        Me.Label11.Text = "Total Compras"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(173, 12)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 3
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'grbTotalCompras
        '
        Me.grbTotalCompras.Controls.Add(Me.txtComprasImpInt)
        Me.grbTotalCompras.Controls.Add(Me.txtComprasTotal)
        Me.grbTotalCompras.Controls.Add(Me.txtComprasIVA)
        Me.grbTotalCompras.Controls.Add(Me.txtComprasNeto)
        Me.grbTotalCompras.Controls.Add(Me.dgvCompras)
        Me.grbTotalCompras.Controls.Add(Me.Label8)
        Me.grbTotalCompras.Location = New System.Drawing.Point(12, 282)
        Me.grbTotalCompras.Name = "grbTotalCompras"
        Me.grbTotalCompras.Size = New System.Drawing.Size(689, 180)
        Me.grbTotalCompras.TabIndex = 2
        Me.grbTotalCompras.TabStop = False
        Me.grbTotalCompras.Text = "Compras"
        '
        'txtComprasImpInt
        '
        Me.txtComprasImpInt.BindearPropiedadControl = Nothing
        Me.txtComprasImpInt.BindearPropiedadEntidad = Nothing
        Me.txtComprasImpInt.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasImpInt.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasImpInt.Formato = ""
        Me.txtComprasImpInt.IsDecimal = False
        Me.txtComprasImpInt.IsNumber = False
        Me.txtComprasImpInt.IsPK = False
        Me.txtComprasImpInt.IsRequired = False
        Me.txtComprasImpInt.Key = ""
        Me.txtComprasImpInt.LabelAsoc = Nothing
        Me.txtComprasImpInt.Location = New System.Drawing.Point(479, 154)
        Me.txtComprasImpInt.Name = "txtComprasImpInt"
        Me.txtComprasImpInt.ReadOnly = True
        Me.txtComprasImpInt.Size = New System.Drawing.Size(95, 20)
        Me.txtComprasImpInt.TabIndex = 6
        Me.txtComprasImpInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComprasTotal
        '
        Me.txtComprasTotal.BindearPropiedadControl = Nothing
        Me.txtComprasTotal.BindearPropiedadEntidad = Nothing
        Me.txtComprasTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasTotal.Formato = ""
        Me.txtComprasTotal.IsDecimal = False
        Me.txtComprasTotal.IsNumber = False
        Me.txtComprasTotal.IsPK = False
        Me.txtComprasTotal.IsRequired = False
        Me.txtComprasTotal.Key = ""
        Me.txtComprasTotal.LabelAsoc = Nothing
        Me.txtComprasTotal.Location = New System.Drawing.Point(574, 154)
        Me.txtComprasTotal.Name = "txtComprasTotal"
        Me.txtComprasTotal.ReadOnly = True
        Me.txtComprasTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtComprasTotal.TabIndex = 4
        Me.txtComprasTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComprasIVA
        '
        Me.txtComprasIVA.BindearPropiedadControl = Nothing
        Me.txtComprasIVA.BindearPropiedadEntidad = Nothing
        Me.txtComprasIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasIVA.Formato = ""
        Me.txtComprasIVA.IsDecimal = False
        Me.txtComprasIVA.IsNumber = False
        Me.txtComprasIVA.IsPK = False
        Me.txtComprasIVA.IsRequired = False
        Me.txtComprasIVA.Key = ""
        Me.txtComprasIVA.LabelAsoc = Nothing
        Me.txtComprasIVA.Location = New System.Drawing.Point(384, 154)
        Me.txtComprasIVA.Name = "txtComprasIVA"
        Me.txtComprasIVA.ReadOnly = True
        Me.txtComprasIVA.Size = New System.Drawing.Size(95, 20)
        Me.txtComprasIVA.TabIndex = 3
        Me.txtComprasIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComprasNeto
        '
        Me.txtComprasNeto.BindearPropiedadControl = Nothing
        Me.txtComprasNeto.BindearPropiedadEntidad = Nothing
        Me.txtComprasNeto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasNeto.Formato = ""
        Me.txtComprasNeto.IsDecimal = False
        Me.txtComprasNeto.IsNumber = False
        Me.txtComprasNeto.IsPK = False
        Me.txtComprasNeto.IsRequired = False
        Me.txtComprasNeto.Key = ""
        Me.txtComprasNeto.LabelAsoc = Nothing
        Me.txtComprasNeto.Location = New System.Drawing.Point(284, 154)
        Me.txtComprasNeto.Name = "txtComprasNeto"
        Me.txtComprasNeto.ReadOnly = True
        Me.txtComprasNeto.Size = New System.Drawing.Size(100, 20)
        Me.txtComprasNeto.TabIndex = 2
        Me.txtComprasNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvCompras
        '
        Me.dgvCompras.AllowUserToAddRows = False
        Me.dgvCompras.AllowUserToDeleteRows = False
        Me.dgvCompras.AllowUserToResizeColumns = False
        Me.dgvCompras.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCompras.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gcNombreSucursal, Me.gcDescripcion, Me.gcLetra, Me.gcNeto, Me.gcIVA, Me.gcImpuestosInternos, Me.gcTotal})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCompras.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvCompras.Location = New System.Drawing.Point(12, 19)
        Me.dgvCompras.Name = "dgvCompras"
        Me.dgvCompras.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCompras.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvCompras.RowHeadersVisible = False
        Me.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompras.Size = New System.Drawing.Size(662, 133)
        Me.dgvCompras.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.LabelAsoc = Nothing
        Me.Label8.Location = New System.Drawing.Point(203, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Total Compras"
        '
        'grbTotalVentas
        '
        Me.grbTotalVentas.Controls.Add(Me.txtVentasImpInt)
        Me.grbTotalVentas.Controls.Add(Me.txtVentasTotal)
        Me.grbTotalVentas.Controls.Add(Me.txtVentasIVA)
        Me.grbTotalVentas.Controls.Add(Me.dgvVentas)
        Me.grbTotalVentas.Controls.Add(Me.txtVentasNeto)
        Me.grbTotalVentas.Controls.Add(Me.Label7)
        Me.grbTotalVentas.Location = New System.Drawing.Point(12, 102)
        Me.grbTotalVentas.Name = "grbTotalVentas"
        Me.grbTotalVentas.Size = New System.Drawing.Size(689, 180)
        Me.grbTotalVentas.TabIndex = 1
        Me.grbTotalVentas.TabStop = False
        Me.grbTotalVentas.Text = "Ventas"
        '
        'txtVentasImpInt
        '
        Me.txtVentasImpInt.BindearPropiedadControl = Nothing
        Me.txtVentasImpInt.BindearPropiedadEntidad = Nothing
        Me.txtVentasImpInt.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVentasImpInt.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVentasImpInt.Formato = ""
        Me.txtVentasImpInt.IsDecimal = False
        Me.txtVentasImpInt.IsNumber = False
        Me.txtVentasImpInt.IsPK = False
        Me.txtVentasImpInt.IsRequired = False
        Me.txtVentasImpInt.Key = ""
        Me.txtVentasImpInt.LabelAsoc = Nothing
        Me.txtVentasImpInt.Location = New System.Drawing.Point(479, 152)
        Me.txtVentasImpInt.Name = "txtVentasImpInt"
        Me.txtVentasImpInt.ReadOnly = True
        Me.txtVentasImpInt.Size = New System.Drawing.Size(95, 20)
        Me.txtVentasImpInt.TabIndex = 5
        Me.txtVentasImpInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVentasTotal
        '
        Me.txtVentasTotal.BindearPropiedadControl = Nothing
        Me.txtVentasTotal.BindearPropiedadEntidad = Nothing
        Me.txtVentasTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVentasTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVentasTotal.Formato = ""
        Me.txtVentasTotal.IsDecimal = False
        Me.txtVentasTotal.IsNumber = False
        Me.txtVentasTotal.IsPK = False
        Me.txtVentasTotal.IsRequired = False
        Me.txtVentasTotal.Key = ""
        Me.txtVentasTotal.LabelAsoc = Nothing
        Me.txtVentasTotal.Location = New System.Drawing.Point(574, 152)
        Me.txtVentasTotal.Name = "txtVentasTotal"
        Me.txtVentasTotal.ReadOnly = True
        Me.txtVentasTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtVentasTotal.TabIndex = 4
        Me.txtVentasTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVentasIVA
        '
        Me.txtVentasIVA.BindearPropiedadControl = Nothing
        Me.txtVentasIVA.BindearPropiedadEntidad = Nothing
        Me.txtVentasIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVentasIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVentasIVA.Formato = ""
        Me.txtVentasIVA.IsDecimal = False
        Me.txtVentasIVA.IsNumber = False
        Me.txtVentasIVA.IsPK = False
        Me.txtVentasIVA.IsRequired = False
        Me.txtVentasIVA.Key = ""
        Me.txtVentasIVA.LabelAsoc = Nothing
        Me.txtVentasIVA.Location = New System.Drawing.Point(384, 152)
        Me.txtVentasIVA.Name = "txtVentasIVA"
        Me.txtVentasIVA.ReadOnly = True
        Me.txtVentasIVA.Size = New System.Drawing.Size(95, 20)
        Me.txtVentasIVA.TabIndex = 3
        Me.txtVentasIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvVentas
        '
        Me.dgvVentas.AllowUserToAddRows = False
        Me.dgvVentas.AllowUserToDeleteRows = False
        Me.dgvVentas.AllowUserToResizeColumns = False
        Me.dgvVentas.AllowUserToResizeRows = False
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvNombreSucursal, Me.gvDescripcion, Me.gvLetra, Me.gvNeto, Me.gvIVA, Me.gvImpuestosInternos, Me.gvTotal})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVentas.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgvVentas.Location = New System.Drawing.Point(13, 19)
        Me.dgvVentas.Name = "dgvVentas"
        Me.dgvVentas.ReadOnly = True
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvVentas.RowHeadersVisible = False
        Me.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVentas.Size = New System.Drawing.Size(661, 133)
        Me.dgvVentas.TabIndex = 0
        '
        'txtVentasNeto
        '
        Me.txtVentasNeto.BindearPropiedadControl = Nothing
        Me.txtVentasNeto.BindearPropiedadEntidad = Nothing
        Me.txtVentasNeto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVentasNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVentasNeto.Formato = ""
        Me.txtVentasNeto.IsDecimal = False
        Me.txtVentasNeto.IsNumber = False
        Me.txtVentasNeto.IsPK = False
        Me.txtVentasNeto.IsRequired = False
        Me.txtVentasNeto.Key = ""
        Me.txtVentasNeto.LabelAsoc = Nothing
        Me.txtVentasNeto.Location = New System.Drawing.Point(284, 152)
        Me.txtVentasNeto.Name = "txtVentasNeto"
        Me.txtVentasNeto.ReadOnly = True
        Me.txtVentasNeto.Size = New System.Drawing.Size(100, 20)
        Me.txtVentasNeto.TabIndex = 2
        Me.txtVentasNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(211, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Total Ventas"
        '
        'txtPosicionTotal
        '
        Me.txtPosicionTotal.BindearPropiedadControl = Nothing
        Me.txtPosicionTotal.BindearPropiedadEntidad = Nothing
        Me.txtPosicionTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPosicionTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPosicionTotal.Formato = ""
        Me.txtPosicionTotal.IsDecimal = False
        Me.txtPosicionTotal.IsNumber = False
        Me.txtPosicionTotal.IsPK = False
        Me.txtPosicionTotal.IsRequired = False
        Me.txtPosicionTotal.Key = ""
        Me.txtPosicionTotal.LabelAsoc = Nothing
        Me.txtPosicionTotal.Location = New System.Drawing.Point(586, 468)
        Me.txtPosicionTotal.Name = "txtPosicionTotal"
        Me.txtPosicionTotal.ReadOnly = True
        Me.txtPosicionTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtPosicionTotal.TabIndex = 6
        Me.txtPosicionTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPosicionIVA
        '
        Me.txtPosicionIVA.BindearPropiedadControl = Nothing
        Me.txtPosicionIVA.BindearPropiedadEntidad = Nothing
        Me.txtPosicionIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPosicionIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPosicionIVA.Formato = ""
        Me.txtPosicionIVA.IsDecimal = False
        Me.txtPosicionIVA.IsNumber = False
        Me.txtPosicionIVA.IsPK = False
        Me.txtPosicionIVA.IsRequired = False
        Me.txtPosicionIVA.Key = ""
        Me.txtPosicionIVA.LabelAsoc = Nothing
        Me.txtPosicionIVA.Location = New System.Drawing.Point(396, 468)
        Me.txtPosicionIVA.Name = "txtPosicionIVA"
        Me.txtPosicionIVA.ReadOnly = True
        Me.txtPosicionIVA.Size = New System.Drawing.Size(95, 20)
        Me.txtPosicionIVA.TabIndex = 5
        Me.txtPosicionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPosicionNeto
        '
        Me.txtPosicionNeto.BindearPropiedadControl = Nothing
        Me.txtPosicionNeto.BindearPropiedadEntidad = Nothing
        Me.txtPosicionNeto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPosicionNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPosicionNeto.Formato = ""
        Me.txtPosicionNeto.IsDecimal = False
        Me.txtPosicionNeto.IsNumber = False
        Me.txtPosicionNeto.IsPK = False
        Me.txtPosicionNeto.IsRequired = False
        Me.txtPosicionNeto.Key = ""
        Me.txtPosicionNeto.LabelAsoc = Nothing
        Me.txtPosicionNeto.Location = New System.Drawing.Point(296, 468)
        Me.txtPosicionNeto.Name = "txtPosicionNeto"
        Me.txtPosicionNeto.ReadOnly = True
        Me.txtPosicionNeto.Size = New System.Drawing.Size(100, 20)
        Me.txtPosicionNeto.TabIndex = 4
        Me.txtPosicionNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPosicion
        '
        Me.lblPosicion.AutoSize = True
        Me.lblPosicion.LabelAsoc = Nothing
        Me.lblPosicion.Location = New System.Drawing.Point(215, 470)
        Me.lblPosicion.Name = "lblPosicion"
        Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
        Me.lblPosicion.TabIndex = 3
        Me.lblPosicion.Text = "Posicion"
        '
        'txtPercepciones
        '
        Me.txtPercepciones.BindearPropiedadControl = Nothing
        Me.txtPercepciones.BindearPropiedadEntidad = Nothing
        Me.txtPercepciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPercepciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPercepciones.Formato = ""
        Me.txtPercepciones.IsDecimal = False
        Me.txtPercepciones.IsNumber = False
        Me.txtPercepciones.IsPK = False
        Me.txtPercepciones.IsRequired = False
        Me.txtPercepciones.Key = ""
        Me.txtPercepciones.LabelAsoc = Me.lblPercepcion
        Me.txtPercepciones.Location = New System.Drawing.Point(396, 490)
        Me.txtPercepciones.Name = "txtPercepciones"
        Me.txtPercepciones.ReadOnly = True
        Me.txtPercepciones.Size = New System.Drawing.Size(95, 20)
        Me.txtPercepciones.TabIndex = 8
        Me.txtPercepciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPercepcion
        '
        Me.lblPercepcion.AutoSize = True
        Me.lblPercepcion.LabelAsoc = Nothing
        Me.lblPercepcion.Location = New System.Drawing.Point(215, 494)
        Me.lblPercepcion.Name = "lblPercepcion"
        Me.lblPercepcion.Size = New System.Drawing.Size(72, 13)
        Me.lblPercepcion.TabIndex = 10
        Me.lblPercepcion.Text = "Percepciones"
        '
        'txtRetenciones
        '
        Me.txtRetenciones.BindearPropiedadControl = Nothing
        Me.txtRetenciones.BindearPropiedadEntidad = Nothing
        Me.txtRetenciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRetenciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRetenciones.Formato = ""
        Me.txtRetenciones.IsDecimal = False
        Me.txtRetenciones.IsNumber = False
        Me.txtRetenciones.IsPK = False
        Me.txtRetenciones.IsRequired = False
        Me.txtRetenciones.Key = ""
        Me.txtRetenciones.LabelAsoc = Me.lblRetenciones
        Me.txtRetenciones.Location = New System.Drawing.Point(396, 513)
        Me.txtRetenciones.Name = "txtRetenciones"
        Me.txtRetenciones.ReadOnly = True
        Me.txtRetenciones.Size = New System.Drawing.Size(95, 20)
        Me.txtRetenciones.TabIndex = 9
        Me.txtRetenciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRetenciones
        '
        Me.lblRetenciones.AutoSize = True
        Me.lblRetenciones.LabelAsoc = Nothing
        Me.lblRetenciones.Location = New System.Drawing.Point(215, 515)
        Me.lblRetenciones.Name = "lblRetenciones"
        Me.lblRetenciones.Size = New System.Drawing.Size(67, 13)
        Me.lblRetenciones.TabIndex = 11
        Me.lblRetenciones.Text = "Retenciones"
        '
        'txtPosicionFinalIVA
        '
        Me.txtPosicionFinalIVA.BindearPropiedadControl = Nothing
        Me.txtPosicionFinalIVA.BindearPropiedadEntidad = Nothing
        Me.txtPosicionFinalIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPosicionFinalIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPosicionFinalIVA.Formato = ""
        Me.txtPosicionFinalIVA.IsDecimal = False
        Me.txtPosicionFinalIVA.IsNumber = False
        Me.txtPosicionFinalIVA.IsPK = False
        Me.txtPosicionFinalIVA.IsRequired = False
        Me.txtPosicionFinalIVA.Key = ""
        Me.txtPosicionFinalIVA.LabelAsoc = Me.lblPosicionFinalIVA
        Me.txtPosicionFinalIVA.Location = New System.Drawing.Point(396, 537)
        Me.txtPosicionFinalIVA.Name = "txtPosicionFinalIVA"
        Me.txtPosicionFinalIVA.ReadOnly = True
        Me.txtPosicionFinalIVA.Size = New System.Drawing.Size(95, 20)
        Me.txtPosicionFinalIVA.TabIndex = 12
        Me.txtPosicionFinalIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPosicionFinalIVA
        '
        Me.lblPosicionFinalIVA.AutoSize = True
        Me.lblPosicionFinalIVA.LabelAsoc = Nothing
        Me.lblPosicionFinalIVA.Location = New System.Drawing.Point(215, 541)
        Me.lblPosicionFinalIVA.Name = "lblPosicionFinalIVA"
        Me.lblPosicionFinalIVA.Size = New System.Drawing.Size(70, 13)
        Me.lblPosicionFinalIVA.TabIndex = 13
        Me.lblPosicionFinalIVA.Text = "Neto a Pagar"
        '
        'txtPosicionImpInt
        '
        Me.txtPosicionImpInt.BindearPropiedadControl = Nothing
        Me.txtPosicionImpInt.BindearPropiedadEntidad = Nothing
        Me.txtPosicionImpInt.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPosicionImpInt.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPosicionImpInt.Formato = ""
        Me.txtPosicionImpInt.IsDecimal = False
        Me.txtPosicionImpInt.IsNumber = False
        Me.txtPosicionImpInt.IsPK = False
        Me.txtPosicionImpInt.IsRequired = False
        Me.txtPosicionImpInt.Key = ""
        Me.txtPosicionImpInt.LabelAsoc = Nothing
        Me.txtPosicionImpInt.Location = New System.Drawing.Point(491, 468)
        Me.txtPosicionImpInt.Name = "txtPosicionImpInt"
        Me.txtPosicionImpInt.ReadOnly = True
        Me.txtPosicionImpInt.Size = New System.Drawing.Size(95, 20)
        Me.txtPosicionImpInt.TabIndex = 14
        Me.txtPosicionImpInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gvNombreSucursal
        '
        Me.gvNombreSucursal.DataPropertyName = "NombreSucursal"
        Me.gvNombreSucursal.HeaderText = "Sucursal"
        Me.gvNombreSucursal.Name = "gvNombreSucursal"
        Me.gvNombreSucursal.ReadOnly = True
        Me.gvNombreSucursal.Width = 120
        '
        'gvDescripcion
        '
        Me.gvDescripcion.DataPropertyName = "Descripcion"
        Me.gvDescripcion.HeaderText = "Comprobante"
        Me.gvDescripcion.Name = "gvDescripcion"
        Me.gvDescripcion.ReadOnly = True
        '
        'gvLetra
        '
        Me.gvLetra.DataPropertyName = "Letra"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gvLetra.DefaultCellStyle = DataGridViewCellStyle14
        Me.gvLetra.HeaderText = "Letra"
        Me.gvLetra.Name = "gvLetra"
        Me.gvLetra.ReadOnly = True
        Me.gvLetra.Width = 40
        '
        'gvNeto
        '
        Me.gvNeto.DataPropertyName = "Neto"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        Me.gvNeto.DefaultCellStyle = DataGridViewCellStyle15
        Me.gvNeto.HeaderText = "Neto"
        Me.gvNeto.Name = "gvNeto"
        Me.gvNeto.ReadOnly = True
        '
        'gvIVA
        '
        Me.gvIVA.DataPropertyName = "TotalImpuestos"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        Me.gvIVA.DefaultCellStyle = DataGridViewCellStyle16
        Me.gvIVA.HeaderText = "IVA"
        Me.gvIVA.Name = "gvIVA"
        Me.gvIVA.ReadOnly = True
        Me.gvIVA.Width = 95
        '
        'gvImpuestosInternos
        '
        Me.gvImpuestosInternos.DataPropertyName = "TotalImpuestosInternos"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N2"
        Me.gvImpuestosInternos.DefaultCellStyle = DataGridViewCellStyle17
        Me.gvImpuestosInternos.HeaderText = "IMP. INT."
        Me.gvImpuestosInternos.Name = "gvImpuestosInternos"
        Me.gvImpuestosInternos.ReadOnly = True
        '
        'gvTotal
        '
        Me.gvTotal.DataPropertyName = "Total"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.gvTotal.DefaultCellStyle = DataGridViewCellStyle18
        Me.gvTotal.HeaderText = "Total"
        Me.gvTotal.Name = "gvTotal"
        Me.gvTotal.ReadOnly = True
        '
        'gcNombreSucursal
        '
        Me.gcNombreSucursal.DataPropertyName = "NombreSucursal"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gcNombreSucursal.DefaultCellStyle = DataGridViewCellStyle5
        Me.gcNombreSucursal.FillWeight = 188.5058!
        Me.gcNombreSucursal.HeaderText = "Sucursal"
        Me.gcNombreSucursal.Name = "gcNombreSucursal"
        Me.gcNombreSucursal.ReadOnly = True
        Me.gcNombreSucursal.Width = 120
        '
        'gcDescripcion
        '
        Me.gcDescripcion.DataPropertyName = "Descripcion"
        Me.gcDescripcion.FillWeight = 7.056602!
        Me.gcDescripcion.HeaderText = "Comprobante"
        Me.gcDescripcion.Name = "gcDescripcion"
        Me.gcDescripcion.ReadOnly = True
        '
        'gcLetra
        '
        Me.gcLetra.DataPropertyName = "Letra"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gcLetra.DefaultCellStyle = DataGridViewCellStyle6
        Me.gcLetra.HeaderText = "Letra"
        Me.gcLetra.Name = "gcLetra"
        Me.gcLetra.ReadOnly = True
        Me.gcLetra.Width = 40
        '
        'gcNeto
        '
        Me.gcNeto.DataPropertyName = "Neto"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.gcNeto.DefaultCellStyle = DataGridViewCellStyle7
        Me.gcNeto.HeaderText = "Neto"
        Me.gcNeto.Name = "gcNeto"
        Me.gcNeto.ReadOnly = True
        '
        'gcIVA
        '
        Me.gcIVA.DataPropertyName = "TotalImpuestos"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.gcIVA.DefaultCellStyle = DataGridViewCellStyle8
        Me.gcIVA.HeaderText = "IVA"
        Me.gcIVA.Name = "gcIVA"
        Me.gcIVA.ReadOnly = True
        Me.gcIVA.Width = 95
        '
        'gcImpuestosInternos
        '
        Me.gcImpuestosInternos.DataPropertyName = "TotalImpuestosInternos"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.gcImpuestosInternos.DefaultCellStyle = DataGridViewCellStyle9
        Me.gcImpuestosInternos.HeaderText = "IMP. INT."
        Me.gcImpuestosInternos.Name = "gcImpuestosInternos"
        Me.gcImpuestosInternos.ReadOnly = True
        '
        'gcTotal
        '
        Me.gcTotal.DataPropertyName = "Total"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.gcTotal.DefaultCellStyle = DataGridViewCellStyle10
        Me.gcTotal.FillWeight = 104.4376!
        Me.gcTotal.HeaderText = "Total"
        Me.gcTotal.Name = "gcTotal"
        Me.gcTotal.ReadOnly = True
        '
        'PosicionDeIVA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 561)
        Me.Controls.Add(Me.txtPosicionImpInt)
        Me.Controls.Add(Me.lblPosicionFinalIVA)
        Me.Controls.Add(Me.txtPosicionFinalIVA)
        Me.Controls.Add(Me.lblRetenciones)
        Me.Controls.Add(Me.lblPercepcion)
        Me.Controls.Add(Me.txtRetenciones)
        Me.Controls.Add(Me.txtPercepciones)
        Me.Controls.Add(Me.txtPosicionTotal)
        Me.Controls.Add(Me.txtPosicionIVA)
        Me.Controls.Add(Me.txtPosicionNeto)
        Me.Controls.Add(Me.lblPosicion)
        Me.Controls.Add(Me.grbTotalCompras)
        Me.Controls.Add(Me.grbTotalVentas)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PosicionDeIVA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Posicion de IVA"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbTotalCompras.ResumeLayout(False)
        Me.grbTotalCompras.PerformLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbTotalVentas.ResumeLayout(False)
        Me.grbTotalVentas.PerformLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents TextBox2 As Eniac.Controles.TextBox
   Friend WithEvents DataGridView5 As Eniac.Controles.DataGridView
   Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Label11 As Eniac.Controles.Label
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbTotalCompras As System.Windows.Forms.GroupBox
   Friend WithEvents txtComprasNeto As Eniac.Controles.TextBox
   Friend WithEvents dgvCompras As Eniac.Controles.DataGridView
   Friend WithEvents Label8 As Eniac.Controles.Label
   Friend WithEvents grbTotalVentas As System.Windows.Forms.GroupBox
   Friend WithEvents dgvVentas As Eniac.Controles.DataGridView
   Friend WithEvents txtVentasNeto As Eniac.Controles.TextBox
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents txtVentasTotal As Eniac.Controles.TextBox
   Friend WithEvents txtVentasIVA As Eniac.Controles.TextBox
   Friend WithEvents txtComprasTotal As Eniac.Controles.TextBox
   Friend WithEvents txtComprasIVA As Eniac.Controles.TextBox
   Friend WithEvents txtPosicionTotal As Eniac.Controles.TextBox
   Friend WithEvents txtPosicionIVA As Eniac.Controles.TextBox
   Friend WithEvents txtPosicionNeto As Eniac.Controles.TextBox
   Friend WithEvents lblPosicion As Eniac.Controles.Label
    Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
    Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
    Friend WithEvents txtPercepciones As Eniac.Controles.TextBox
    Friend WithEvents lblPercepcion As Eniac.Controles.Label
    Friend WithEvents txtRetenciones As Eniac.Controles.TextBox
    Friend WithEvents lblRetenciones As Eniac.Controles.Label
    Friend WithEvents txtPosicionFinalIVA As Eniac.Controles.TextBox
    Friend WithEvents lblPosicionFinalIVA As Eniac.Controles.Label
    Friend WithEvents txtComprasImpInt As Controles.TextBox
    Friend WithEvents txtVentasImpInt As Controles.TextBox
    Friend WithEvents txtPosicionImpInt As Controles.TextBox
    Friend WithEvents gcNombreSucursal As DataGridViewTextBoxColumn
    Friend WithEvents gcDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents gcLetra As DataGridViewTextBoxColumn
    Friend WithEvents gcNeto As DataGridViewTextBoxColumn
    Friend WithEvents gcIVA As DataGridViewTextBoxColumn
    Friend WithEvents gcImpuestosInternos As DataGridViewTextBoxColumn
    Friend WithEvents gcTotal As DataGridViewTextBoxColumn
    Friend WithEvents gvNombreSucursal As DataGridViewTextBoxColumn
    Friend WithEvents gvDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents gvLetra As DataGridViewTextBoxColumn
    Friend WithEvents gvNeto As DataGridViewTextBoxColumn
    Friend WithEvents gvIVA As DataGridViewTextBoxColumn
    Friend WithEvents gvImpuestosInternos As DataGridViewTextBoxColumn
    Friend WithEvents gvTotal As DataGridViewTextBoxColumn
End Class
