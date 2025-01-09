<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfPagosRealizados
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
      Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
      Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfPagosRealizados))
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbComercial = New Eniac.Controles.ComboBox()
      Me.lblComercial = New Eniac.Controles.Label()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.grbComprador = New System.Windows.Forms.GroupBox()
      Me.optCompradorProveedor = New Eniac.Controles.RadioButton()
      Me.optCompradorMovim = New Eniac.Controles.RadioButton()
      Me.chbComprador = New Eniac.Controles.CheckBox()
      Me.cmbComprador = New Eniac.Controles.ComboBox()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
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
      Me.txtTotalCtaCteFinal = New Eniac.Controles.TextBox()
      Me.lblTotalCtaCte = New Eniac.Controles.Label()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.txtTotalContadoFinal = New Eniac.Controles.TextBox()
      Me.lblTotalContado = New Eniac.Controles.Label()
      Me.txtTotalGeneralFinal = New Eniac.Controles.TextBox()
      Me.lblTotalGeneralFinal = New Eniac.Controles.Label()
      Me.txtTotalContadoNeto = New Eniac.Controles.TextBox()
      Me.txtTotalCtaCteNeto = New Eniac.Controles.TextBox()
      Me.txtTotalGeneralNeto = New Eniac.Controles.TextBox()
      Me.lblTotalGeneralNeto = New Eniac.Controles.Label()
      Me.ccIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccNombreComprador = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdComprador = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccIdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccCentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccNumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccIdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccCodigoProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccNombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccImporteNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccIdTipoComprobante2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccLetra2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccCentroEmisor2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccNumeroComprobante2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccCuotaNumero2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccFecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ccDiasPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbFiltros.SuspendLayout()
      Me.grbComprador.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.cmbComercial)
      Me.grbFiltros.Controls.Add(Me.lblComercial)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.grbComprador)
      Me.grbFiltros.Controls.Add(Me.chbComprador)
      Me.grbFiltros.Controls.Add(Me.cmbComprador)
      Me.grbFiltros.Controls.Add(Me.chbProveedor)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.bscProveedor)
      Me.grbFiltros.Controls.Add(Me.lblCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 31)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(1010, 110)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'cmbComercial
      '
      Me.cmbComercial.BindearPropiedadControl = Nothing
      Me.cmbComercial.BindearPropiedadEntidad = Nothing
      Me.cmbComercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbComercial.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbComercial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbComercial.FormattingEnabled = True
      Me.cmbComercial.IsPK = False
      Me.cmbComercial.IsRequired = False
      Me.cmbComercial.Key = Nothing
      Me.cmbComercial.LabelAsoc = Me.lblComercial
      Me.cmbComercial.Location = New System.Drawing.Point(704, 21)
      Me.cmbComercial.Name = "cmbComercial"
      Me.cmbComercial.Size = New System.Drawing.Size(70, 21)
      Me.cmbComercial.TabIndex = 7
      '
      'lblComercial
      '
      Me.lblComercial.AutoSize = True
      Me.lblComercial.LabelAsoc = Nothing
      Me.lblComercial.Location = New System.Drawing.Point(645, 25)
      Me.lblComercial.Name = "lblComercial"
      Me.lblComercial.Size = New System.Drawing.Size(53, 13)
      Me.lblComercial.TabIndex = 6
      Me.lblComercial.Text = "Comercial"
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(16, 23)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 0
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
      '
      'grbComprador
      '
      Me.grbComprador.Controls.Add(Me.optCompradorProveedor)
      Me.grbComprador.Controls.Add(Me.optCompradorMovim)
      Me.grbComprador.Location = New System.Drawing.Point(419, 8)
      Me.grbComprador.Name = "grbComprador"
      Me.grbComprador.Size = New System.Drawing.Size(182, 47)
      Me.grbComprador.TabIndex = 5
      Me.grbComprador.TabStop = False
      Me.grbComprador.Text = "Comprador"
      Me.grbComprador.Visible = False
      '
      'optCompradorProveedor
      '
      Me.optCompradorProveedor.AutoSize = True
      Me.optCompradorProveedor.BindearPropiedadControl = Nothing
      Me.optCompradorProveedor.BindearPropiedadEntidad = Nothing
      Me.optCompradorProveedor.Checked = True
      Me.optCompradorProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.optCompradorProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optCompradorProveedor.IsPK = False
      Me.optCompradorProveedor.IsRequired = False
      Me.optCompradorProveedor.Key = Nothing
      Me.optCompradorProveedor.LabelAsoc = Nothing
      Me.optCompradorProveedor.Location = New System.Drawing.Point(17, 20)
      Me.optCompradorProveedor.Name = "optCompradorProveedor"
      Me.optCompradorProveedor.Size = New System.Drawing.Size(74, 17)
      Me.optCompradorProveedor.TabIndex = 0
      Me.optCompradorProveedor.TabStop = True
      Me.optCompradorProveedor.Text = "Proveedor"
      Me.optCompradorProveedor.UseVisualStyleBackColor = True
      '
      'optCompradorMovim
      '
      Me.optCompradorMovim.AutoSize = True
      Me.optCompradorMovim.BindearPropiedadControl = Nothing
      Me.optCompradorMovim.BindearPropiedadEntidad = Nothing
      Me.optCompradorMovim.ForeColorFocus = System.Drawing.Color.Red
      Me.optCompradorMovim.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optCompradorMovim.IsPK = False
      Me.optCompradorMovim.IsRequired = False
      Me.optCompradorMovim.Key = Nothing
      Me.optCompradorMovim.LabelAsoc = Nothing
      Me.optCompradorMovim.Location = New System.Drawing.Point(95, 20)
      Me.optCompradorMovim.Name = "optCompradorMovim"
      Me.optCompradorMovim.Size = New System.Drawing.Size(79, 17)
      Me.optCompradorMovim.TabIndex = 1
      Me.optCompradorMovim.Text = "Movimiento"
      Me.optCompradorMovim.UseVisualStyleBackColor = True
      '
      'chbComprador
      '
      Me.chbComprador.AutoSize = True
      Me.chbComprador.BindearPropiedadControl = Nothing
      Me.chbComprador.BindearPropiedadEntidad = Nothing
      Me.chbComprador.ForeColorFocus = System.Drawing.Color.Red
      Me.chbComprador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbComprador.IsPK = False
      Me.chbComprador.IsRequired = False
      Me.chbComprador.Key = Nothing
      Me.chbComprador.LabelAsoc = Nothing
      Me.chbComprador.Location = New System.Drawing.Point(626, 77)
      Me.chbComprador.Name = "chbComprador"
      Me.chbComprador.Size = New System.Drawing.Size(77, 17)
      Me.chbComprador.TabIndex = 15
      Me.chbComprador.Text = "Comprador"
      Me.chbComprador.UseVisualStyleBackColor = True
      '
      'cmbComprador
      '
      Me.cmbComprador.BindearPropiedadControl = Nothing
      Me.cmbComprador.BindearPropiedadEntidad = Nothing
      Me.cmbComprador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComprador.Enabled = False
      Me.cmbComprador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbComprador.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbComprador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbComprador.FormattingEnabled = True
      Me.cmbComprador.IsPK = False
      Me.cmbComprador.IsRequired = False
      Me.cmbComprador.Key = Nothing
      Me.cmbComprador.LabelAsoc = Nothing
      Me.cmbComprador.Location = New System.Drawing.Point(704, 75)
      Me.cmbComprador.Name = "cmbComprador"
      Me.cmbComprador.Size = New System.Drawing.Size(150, 21)
      Me.cmbComprador.TabIndex = 16
      '
      'chbProveedor
      '
      Me.chbProveedor.AutoSize = True
      Me.chbProveedor.BindearPropiedadControl = Nothing
      Me.chbProveedor.BindearPropiedadEntidad = Nothing
      Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProveedor.IsPK = False
      Me.chbProveedor.IsRequired = False
      Me.chbProveedor.Key = Nothing
      Me.chbProveedor.LabelAsoc = Nothing
      Me.chbProveedor.Location = New System.Drawing.Point(16, 72)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 8
      Me.chbProveedor.Text = "Proveedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(302, 21)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(261, 25)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(160, 21)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(116, 25)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.AyudaAncho = 608
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
      Me.bscCodigoProveedor.ColumnasAncho = Nothing
      Me.bscCodigoProveedor.ColumnasFormato = Nothing
      Me.bscCodigoProveedor.ColumnasOcultas = Nothing
      Me.bscCodigoProveedor.ColumnasTitulos = Nothing
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.Enabled = False
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = True
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(97, 71)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 12
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.LabelAsoc = Nothing
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(94, 55)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 11
      Me.lblCodigoProveedor.Text = "Código"
      '
      'bscProveedor
      '
      Me.bscProveedor.AutoSize = True
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.Enabled = False
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Me.lblNombre
      Me.bscProveedor.Location = New System.Drawing.Point(194, 71)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
      Me.bscProveedor.TabIndex = 14
      Me.bscProveedor.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(191, 55)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 13
      Me.lblNombre.Text = "Nombre"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(887, 39)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 17
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1034, 29)
      Me.tstBarra.TabIndex = 13
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
      Me.stsStado.Location = New System.Drawing.Point(0, 550)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(1034, 22)
      Me.stsStado.TabIndex = 12
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(955, 17)
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
      'txtTotalCtaCteFinal
      '
      Me.txtTotalCtaCteFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalCtaCteFinal.BindearPropiedadControl = Nothing
      Me.txtTotalCtaCteFinal.BindearPropiedadEntidad = Nothing
      Me.txtTotalCtaCteFinal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalCtaCteFinal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalCtaCteFinal.Formato = ""
      Me.txtTotalCtaCteFinal.IsDecimal = False
      Me.txtTotalCtaCteFinal.IsNumber = False
      Me.txtTotalCtaCteFinal.IsPK = False
      Me.txtTotalCtaCteFinal.IsRequired = False
      Me.txtTotalCtaCteFinal.Key = ""
      Me.txtTotalCtaCteFinal.LabelAsoc = Me.lblTotalCtaCte
      Me.txtTotalCtaCteFinal.Location = New System.Drawing.Point(689, 522)
      Me.txtTotalCtaCteFinal.Name = "txtTotalCtaCteFinal"
      Me.txtTotalCtaCteFinal.ReadOnly = True
      Me.txtTotalCtaCteFinal.Size = New System.Drawing.Size(70, 20)
      Me.txtTotalCtaCteFinal.TabIndex = 7
      Me.txtTotalCtaCteFinal.Text = "0.00"
      Me.txtTotalCtaCteFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalCtaCte
      '
      Me.lblTotalCtaCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotalCtaCte.AutoSize = True
      Me.lblTotalCtaCte.LabelAsoc = Nothing
      Me.lblTotalCtaCte.Location = New System.Drawing.Point(563, 526)
      Me.lblTotalCtaCte.Name = "lblTotalCtaCte"
      Me.lblTotalCtaCte.Size = New System.Drawing.Size(48, 13)
      Me.lblTotalCtaCte.TabIndex = 5
      Me.lblTotalCtaCte.Text = "Cta.Cte.:"
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ccIdSucursal, Me.ccNombreComprador, Me.IdComprador, Me.ccFecha, Me.ccIdTipoComprobante, Me.ccLetra, Me.ccCentroEmisor, Me.ccNumeroComprobante, Me.ccIdProveedor, Me.ccCodigoProveedor, Me.ccNombreProveedor, Me.ccImporteNeto, Me.ccImporteTotal, Me.ccIdTipoComprobante2, Me.ccLetra2, Me.ccCentroEmisor2, Me.ccNumeroComprobante2, Me.ccCuotaNumero2, Me.ccFecha2, Me.ccDiasPago})
      DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle15
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 145)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(1010, 355)
      Me.dgvDetalle.TabIndex = 1
      '
      'txtTotalContadoFinal
      '
      Me.txtTotalContadoFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalContadoFinal.BindearPropiedadControl = Nothing
      Me.txtTotalContadoFinal.BindearPropiedadEntidad = Nothing
      Me.txtTotalContadoFinal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalContadoFinal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalContadoFinal.Formato = ""
      Me.txtTotalContadoFinal.IsDecimal = False
      Me.txtTotalContadoFinal.IsNumber = False
      Me.txtTotalContadoFinal.IsPK = False
      Me.txtTotalContadoFinal.IsRequired = False
      Me.txtTotalContadoFinal.Key = ""
      Me.txtTotalContadoFinal.LabelAsoc = Me.lblTotalContado
      Me.txtTotalContadoFinal.Location = New System.Drawing.Point(689, 501)
      Me.txtTotalContadoFinal.Name = "txtTotalContadoFinal"
      Me.txtTotalContadoFinal.ReadOnly = True
      Me.txtTotalContadoFinal.Size = New System.Drawing.Size(70, 20)
      Me.txtTotalContadoFinal.TabIndex = 4
      Me.txtTotalContadoFinal.Text = "0.00"
      Me.txtTotalContadoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalContado
      '
      Me.lblTotalContado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotalContado.AutoSize = True
      Me.lblTotalContado.LabelAsoc = Nothing
      Me.lblTotalContado.Location = New System.Drawing.Point(563, 505)
      Me.lblTotalContado.Name = "lblTotalContado"
      Me.lblTotalContado.Size = New System.Drawing.Size(50, 13)
      Me.lblTotalContado.TabIndex = 2
      Me.lblTotalContado.Text = "Contado:"
      '
      'txtTotalGeneralFinal
      '
      Me.txtTotalGeneralFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalGeneralFinal.BindearPropiedadControl = Nothing
      Me.txtTotalGeneralFinal.BindearPropiedadEntidad = Nothing
      Me.txtTotalGeneralFinal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalGeneralFinal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalGeneralFinal.Formato = ""
      Me.txtTotalGeneralFinal.IsDecimal = False
      Me.txtTotalGeneralFinal.IsNumber = False
      Me.txtTotalGeneralFinal.IsPK = False
      Me.txtTotalGeneralFinal.IsRequired = False
      Me.txtTotalGeneralFinal.Key = ""
      Me.txtTotalGeneralFinal.LabelAsoc = Me.lblTotalGeneralFinal
      Me.txtTotalGeneralFinal.Location = New System.Drawing.Point(876, 522)
      Me.txtTotalGeneralFinal.Name = "txtTotalGeneralFinal"
      Me.txtTotalGeneralFinal.ReadOnly = True
      Me.txtTotalGeneralFinal.Size = New System.Drawing.Size(80, 20)
      Me.txtTotalGeneralFinal.TabIndex = 11
      Me.txtTotalGeneralFinal.Text = "0.00"
      Me.txtTotalGeneralFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalGeneralFinal
      '
      Me.lblTotalGeneralFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotalGeneralFinal.AutoSize = True
      Me.lblTotalGeneralFinal.LabelAsoc = Nothing
      Me.lblTotalGeneralFinal.Location = New System.Drawing.Point(814, 526)
      Me.lblTotalGeneralFinal.Name = "lblTotalGeneralFinal"
      Me.lblTotalGeneralFinal.Size = New System.Drawing.Size(59, 13)
      Me.lblTotalGeneralFinal.TabIndex = 10
      Me.lblTotalGeneralFinal.Text = "Total Final:"
      '
      'txtTotalContadoNeto
      '
      Me.txtTotalContadoNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalContadoNeto.BindearPropiedadControl = Nothing
      Me.txtTotalContadoNeto.BindearPropiedadEntidad = Nothing
      Me.txtTotalContadoNeto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalContadoNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalContadoNeto.Formato = ""
      Me.txtTotalContadoNeto.IsDecimal = False
      Me.txtTotalContadoNeto.IsNumber = False
      Me.txtTotalContadoNeto.IsPK = False
      Me.txtTotalContadoNeto.IsRequired = False
      Me.txtTotalContadoNeto.Key = ""
      Me.txtTotalContadoNeto.LabelAsoc = Me.lblTotalContado
      Me.txtTotalContadoNeto.Location = New System.Drawing.Point(619, 501)
      Me.txtTotalContadoNeto.Name = "txtTotalContadoNeto"
      Me.txtTotalContadoNeto.ReadOnly = True
      Me.txtTotalContadoNeto.Size = New System.Drawing.Size(70, 20)
      Me.txtTotalContadoNeto.TabIndex = 3
      Me.txtTotalContadoNeto.Text = "0.00"
      Me.txtTotalContadoNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalCtaCteNeto
      '
      Me.txtTotalCtaCteNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalCtaCteNeto.BindearPropiedadControl = Nothing
      Me.txtTotalCtaCteNeto.BindearPropiedadEntidad = Nothing
      Me.txtTotalCtaCteNeto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalCtaCteNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalCtaCteNeto.Formato = ""
      Me.txtTotalCtaCteNeto.IsDecimal = False
      Me.txtTotalCtaCteNeto.IsNumber = False
      Me.txtTotalCtaCteNeto.IsPK = False
      Me.txtTotalCtaCteNeto.IsRequired = False
      Me.txtTotalCtaCteNeto.Key = ""
      Me.txtTotalCtaCteNeto.LabelAsoc = Me.lblTotalCtaCte
      Me.txtTotalCtaCteNeto.Location = New System.Drawing.Point(619, 522)
      Me.txtTotalCtaCteNeto.Name = "txtTotalCtaCteNeto"
      Me.txtTotalCtaCteNeto.ReadOnly = True
      Me.txtTotalCtaCteNeto.Size = New System.Drawing.Size(70, 20)
      Me.txtTotalCtaCteNeto.TabIndex = 6
      Me.txtTotalCtaCteNeto.Text = "0.00"
      Me.txtTotalCtaCteNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalGeneralNeto
      '
      Me.txtTotalGeneralNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalGeneralNeto.BindearPropiedadControl = Nothing
      Me.txtTotalGeneralNeto.BindearPropiedadEntidad = Nothing
      Me.txtTotalGeneralNeto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalGeneralNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalGeneralNeto.Formato = ""
      Me.txtTotalGeneralNeto.IsDecimal = False
      Me.txtTotalGeneralNeto.IsNumber = False
      Me.txtTotalGeneralNeto.IsPK = False
      Me.txtTotalGeneralNeto.IsRequired = False
      Me.txtTotalGeneralNeto.Key = ""
      Me.txtTotalGeneralNeto.LabelAsoc = Me.lblTotalGeneralNeto
      Me.txtTotalGeneralNeto.Location = New System.Drawing.Point(876, 501)
      Me.txtTotalGeneralNeto.Name = "txtTotalGeneralNeto"
      Me.txtTotalGeneralNeto.ReadOnly = True
      Me.txtTotalGeneralNeto.Size = New System.Drawing.Size(80, 20)
      Me.txtTotalGeneralNeto.TabIndex = 9
      Me.txtTotalGeneralNeto.Text = "0.00"
      Me.txtTotalGeneralNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalGeneralNeto
      '
      Me.lblTotalGeneralNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotalGeneralNeto.AutoSize = True
      Me.lblTotalGeneralNeto.LabelAsoc = Nothing
      Me.lblTotalGeneralNeto.Location = New System.Drawing.Point(814, 505)
      Me.lblTotalGeneralNeto.Name = "lblTotalGeneralNeto"
      Me.lblTotalGeneralNeto.Size = New System.Drawing.Size(60, 13)
      Me.lblTotalGeneralNeto.TabIndex = 8
      Me.lblTotalGeneralNeto.Text = "Total Neto:"
      '
      'ccIdSucursal
      '
      Me.ccIdSucursal.DataPropertyName = "IdSucursal"
      Me.ccIdSucursal.HeaderText = "IdSucursal"
      Me.ccIdSucursal.Name = "ccIdSucursal"
      Me.ccIdSucursal.ReadOnly = True
      Me.ccIdSucursal.Visible = False
      '
      'ccNombreComprador
      '
      Me.ccNombreComprador.DataPropertyName = "NombreComprador"
      Me.ccNombreComprador.HeaderText = "Comprador"
      Me.ccNombreComprador.Name = "ccNombreComprador"
      Me.ccNombreComprador.ReadOnly = True
      Me.ccNombreComprador.Width = 90
      '
      'IdComprador
      '
      Me.IdComprador.DataPropertyName = "IdComprador"
      Me.IdComprador.HeaderText = "IdComprador"
      Me.IdComprador.Name = "IdComprador"
      Me.IdComprador.ReadOnly = True
      Me.IdComprador.Visible = False
      '
      'ccFecha
      '
      Me.ccFecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Format = "dd/MM/yyyy"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.ccFecha.DefaultCellStyle = DataGridViewCellStyle2
      Me.ccFecha.HeaderText = "Emisión"
      Me.ccFecha.Name = "ccFecha"
      Me.ccFecha.ReadOnly = True
      Me.ccFecha.Width = 70
      '
      'ccIdTipoComprobante
      '
      Me.ccIdTipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.ccIdTipoComprobante.HeaderText = "Comprobante"
      Me.ccIdTipoComprobante.Name = "ccIdTipoComprobante"
      Me.ccIdTipoComprobante.ReadOnly = True
      Me.ccIdTipoComprobante.Width = 90
      '
      'ccLetra
      '
      Me.ccLetra.DataPropertyName = "Letra"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.ccLetra.DefaultCellStyle = DataGridViewCellStyle3
      Me.ccLetra.HeaderText = "Let."
      Me.ccLetra.Name = "ccLetra"
      Me.ccLetra.ReadOnly = True
      Me.ccLetra.Width = 30
      '
      'ccCentroEmisor
      '
      Me.ccCentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ccCentroEmisor.DefaultCellStyle = DataGridViewCellStyle4
      Me.ccCentroEmisor.HeaderText = "P.V."
      Me.ccCentroEmisor.Name = "ccCentroEmisor"
      Me.ccCentroEmisor.ReadOnly = True
      Me.ccCentroEmisor.Width = 30
      '
      'ccNumeroComprobante
      '
      Me.ccNumeroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ccNumeroComprobante.DefaultCellStyle = DataGridViewCellStyle5
      Me.ccNumeroComprobante.HeaderText = "Numero"
      Me.ccNumeroComprobante.Name = "ccNumeroComprobante"
      Me.ccNumeroComprobante.ReadOnly = True
      Me.ccNumeroComprobante.Width = 55
      '
      'ccIdProveedor
      '
      Me.ccIdProveedor.DataPropertyName = "IdProveedor"
      Me.ccIdProveedor.HeaderText = "IdProveedor"
      Me.ccIdProveedor.Name = "ccIdProveedor"
      Me.ccIdProveedor.ReadOnly = True
      Me.ccIdProveedor.Visible = False
      Me.ccIdProveedor.Width = 50
      '
      'ccCodigoProveedor
      '
      Me.ccCodigoProveedor.DataPropertyName = "CodigoProveedor"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ccCodigoProveedor.DefaultCellStyle = DataGridViewCellStyle6
      Me.ccCodigoProveedor.HeaderText = "CodigoProveedor"
      Me.ccCodigoProveedor.Name = "ccCodigoProveedor"
      Me.ccCodigoProveedor.ReadOnly = True
      Me.ccCodigoProveedor.Visible = False
      Me.ccCodigoProveedor.Width = 70
      '
      'ccNombreProveedor
      '
      Me.ccNombreProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.ccNombreProveedor.DataPropertyName = "NombreProveedor"
      Me.ccNombreProveedor.HeaderText = "Nombre Proveedor"
      Me.ccNombreProveedor.Name = "ccNombreProveedor"
      Me.ccNombreProveedor.ReadOnly = True
      '
      'ccImporteNeto
      '
      Me.ccImporteNeto.DataPropertyName = "ImporteNeto"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      Me.ccImporteNeto.DefaultCellStyle = DataGridViewCellStyle7
      Me.ccImporteNeto.HeaderText = "Neto"
      Me.ccImporteNeto.Name = "ccImporteNeto"
      Me.ccImporteNeto.ReadOnly = True
      Me.ccImporteNeto.Width = 70
      '
      'ccImporteTotal
      '
      Me.ccImporteTotal.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.ccImporteTotal.DefaultCellStyle = DataGridViewCellStyle8
      Me.ccImporteTotal.HeaderText = "Total"
      Me.ccImporteTotal.Name = "ccImporteTotal"
      Me.ccImporteTotal.ReadOnly = True
      Me.ccImporteTotal.Width = 70
      '
      'ccIdTipoComprobante2
      '
      Me.ccIdTipoComprobante2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
      Me.ccIdTipoComprobante2.DataPropertyName = "IdTipoComprobante2"
      Me.ccIdTipoComprobante2.HeaderText = "Comprob.  Ap."
      Me.ccIdTipoComprobante2.Name = "ccIdTipoComprobante2"
      Me.ccIdTipoComprobante2.ReadOnly = True
      Me.ccIdTipoComprobante2.Width = 99
      '
      'ccLetra2
      '
      Me.ccLetra2.DataPropertyName = "Letra2"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.ccLetra2.DefaultCellStyle = DataGridViewCellStyle9
      Me.ccLetra2.HeaderText = "Let."
      Me.ccLetra2.Name = "ccLetra2"
      Me.ccLetra2.ReadOnly = True
      Me.ccLetra2.Width = 30
      '
      'ccCentroEmisor2
      '
      Me.ccCentroEmisor2.DataPropertyName = "CentroEmisor2"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ccCentroEmisor2.DefaultCellStyle = DataGridViewCellStyle10
      Me.ccCentroEmisor2.HeaderText = "P.V."
      Me.ccCentroEmisor2.Name = "ccCentroEmisor2"
      Me.ccCentroEmisor2.ReadOnly = True
      Me.ccCentroEmisor2.Width = 40
      '
      'ccNumeroComprobante2
      '
      Me.ccNumeroComprobante2.DataPropertyName = "NumeroComprobante2"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ccNumeroComprobante2.DefaultCellStyle = DataGridViewCellStyle11
      Me.ccNumeroComprobante2.HeaderText = "Numero"
      Me.ccNumeroComprobante2.Name = "ccNumeroComprobante2"
      Me.ccNumeroComprobante2.ReadOnly = True
      Me.ccNumeroComprobante2.Width = 55
      '
      'ccCuotaNumero2
      '
      Me.ccCuotaNumero2.DataPropertyName = "CuotaNumero2"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ccCuotaNumero2.DefaultCellStyle = DataGridViewCellStyle12
      Me.ccCuotaNumero2.HeaderText = "Cta."
      Me.ccCuotaNumero2.Name = "ccCuotaNumero2"
      Me.ccCuotaNumero2.ReadOnly = True
      Me.ccCuotaNumero2.Width = 40
      '
      'ccFecha2
      '
      Me.ccFecha2.DataPropertyName = "Fecha2"
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle13.Format = "dd/MM/yyyy"
      Me.ccFecha2.DefaultCellStyle = DataGridViewCellStyle13
      Me.ccFecha2.HeaderText = "Fec.Comp."
      Me.ccFecha2.Name = "ccFecha2"
      Me.ccFecha2.ReadOnly = True
      Me.ccFecha2.Width = 70
      '
      'ccDiasPago
      '
      Me.ccDiasPago.DataPropertyName = "DiasPago"
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ccDiasPago.DefaultCellStyle = DataGridViewCellStyle14
      Me.ccDiasPago.HeaderText = "Dias Pago"
      Me.ccDiasPago.Name = "ccDiasPago"
      Me.ccDiasPago.ReadOnly = True
      Me.ccDiasPago.Width = 40
      '
      'InfPagosRealizados
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1034, 572)
      Me.Controls.Add(Me.txtTotalGeneralNeto)
      Me.Controls.Add(Me.lblTotalGeneralNeto)
      Me.Controls.Add(Me.txtTotalContadoNeto)
      Me.Controls.Add(Me.txtTotalCtaCteNeto)
      Me.Controls.Add(Me.txtTotalGeneralFinal)
      Me.Controls.Add(Me.lblTotalGeneralFinal)
      Me.Controls.Add(Me.txtTotalContadoFinal)
      Me.Controls.Add(Me.lblTotalContado)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.txtTotalCtaCteFinal)
      Me.Controls.Add(Me.lblTotalCtaCte)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
      Me.KeyPreview = true
      Me.Name = "InfPagosRealizados"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Pagos Realizados"
      Me.grbFiltros.ResumeLayout(false)
      Me.grbFiltros.PerformLayout
      Me.grbComprador.ResumeLayout(false)
      Me.grbComprador.PerformLayout
      Me.tstBarra.ResumeLayout(false)
      Me.tstBarra.PerformLayout
      Me.stsStado.ResumeLayout(false)
      Me.stsStado.PerformLayout
      CType(Me.dgvDetalle,System.ComponentModel.ISupportInitialize).EndInit
      Me.ResumeLayout(false)
      Me.PerformLayout

End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents txtTotalCtaCteFinal As Eniac.Controles.TextBox
   Friend WithEvents lblTotalCtaCte As Eniac.Controles.Label
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbComprador As Eniac.Controles.CheckBox
   Friend WithEvents cmbComprador As Eniac.Controles.ComboBox
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents grbComprador As System.Windows.Forms.GroupBox
   Friend WithEvents optCompradorProveedor As Eniac.Controles.RadioButton
   Friend WithEvents optCompradorMovim As Eniac.Controles.RadioButton
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents txtTotalContadoFinal As Eniac.Controles.TextBox
   Friend WithEvents lblTotalContado As Eniac.Controles.Label
   Friend WithEvents txtTotalGeneralFinal As Eniac.Controles.TextBox
   Friend WithEvents lblTotalGeneralFinal As Eniac.Controles.Label
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents txtTotalContadoNeto As Eniac.Controles.TextBox
   Friend WithEvents txtTotalCtaCteNeto As Eniac.Controles.TextBox
   Friend WithEvents txtTotalGeneralNeto As Eniac.Controles.TextBox
   Friend WithEvents lblTotalGeneralNeto As Eniac.Controles.Label
   Friend WithEvents cmbComercial As Eniac.Controles.ComboBox
   Friend WithEvents lblComercial As Eniac.Controles.Label
   Friend WithEvents ccIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccNombreComprador As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdComprador As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccFecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccIdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccLetra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccCentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccNumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccIdProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccCodigoProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccNombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccImporteNeto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccIdTipoComprobante2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccLetra2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccCentroEmisor2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccNumeroComprobante2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccCuotaNumero2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccFecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ccDiasPago As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
