<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MayorDeCuentaDeCaja
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
      Me.components = New System.ComponentModel.Container()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MayorDeCuentaDeCaja))
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.chbCaja = New Eniac.Controles.CheckBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.rdbFechaMovimiento = New Eniac.Controles.RadioButton()
      Me.rdbFechaPlanilla = New Eniac.Controles.RadioButton()
      Me.lblFechaDe = New Eniac.Controles.Label()
      Me.bscCuentaCaja = New Eniac.Controles.Buscador()
      Me.lblCuentaCaja = New Eniac.Controles.Label()
      Me.bscNombreCuentaCaja = New Eniac.Controles.Buscador()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.lblTotales = New Eniac.Controles.Label()
      Me.txtTotalIngresos = New Eniac.Controles.TextBox()
      Me.txtTotalEgresos = New Eniac.Controles.TextBox()
      Me.txtSaldo = New Eniac.Controles.TextBox()
      Me.lblSaldo = New Eniac.Controles.Label()
      Me.txtSaldoInicial = New Eniac.Controles.TextBox()
      Me.lblSaldoInicial = New Eniac.Controles.Label()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Egreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
      Me.dgvDetalle.AllowUserToResizeColumns = False
      Me.dgvDetalle.AllowUserToResizeRows = False
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSucursal, Me.NombreCaja, Me.FechaPlanilla, Me.FechaMovimiento, Me.NumeroPlanilla, Me.NumeroMovimiento, Me.Observacion, Me.Ingreso, Me.Egreso})
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle9
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 159)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(860, 340)
      Me.dgvDetalle.TabIndex = 1
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.cmbSucursal)
      Me.grbFiltros.Controls.Add(Me.lblSucursal)
      Me.grbFiltros.Controls.Add(Me.chbCaja)
      Me.grbFiltros.Controls.Add(Me.cmbCajas)
      Me.grbFiltros.Controls.Add(Me.rdbFechaMovimiento)
      Me.grbFiltros.Controls.Add(Me.rdbFechaPlanilla)
      Me.grbFiltros.Controls.Add(Me.lblFechaDe)
      Me.grbFiltros.Controls.Add(Me.bscCuentaCaja)
      Me.grbFiltros.Controls.Add(Me.bscNombreCuentaCaja)
      Me.grbFiltros.Controls.Add(Me.lblCuentaCaja)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(860, 93)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'cmbSucursal
      '
      Me.cmbSucursal.BindearPropiedadControl = Nothing
      Me.cmbSucursal.BindearPropiedadEntidad = Nothing
      Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursal.FormattingEnabled = True
      Me.cmbSucursal.IsPK = False
      Me.cmbSucursal.IsRequired = False
      Me.cmbSucursal.ItemHeight = 13
      Me.cmbSucursal.Key = Nothing
      Me.cmbSucursal.LabelAsoc = Me.lblSucursal
      Me.cmbSucursal.Location = New System.Drawing.Point(62, 16)
      Me.cmbSucursal.Name = "cmbSucursal"
      Me.cmbSucursal.Size = New System.Drawing.Size(118, 21)
      Me.cmbSucursal.TabIndex = 28
      '
      'lblSucursal
      '
      Me.lblSucursal.AutoSize = True
      Me.lblSucursal.LabelAsoc = Nothing
      Me.lblSucursal.Location = New System.Drawing.Point(8, 20)
      Me.lblSucursal.Name = "lblSucursal"
      Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
      Me.lblSucursal.TabIndex = 27
      Me.lblSucursal.Text = "Sucursal"
      '
      'chbCaja
      '
      Me.chbCaja.AutoSize = True
      Me.chbCaja.BindearPropiedadControl = Nothing
      Me.chbCaja.BindearPropiedadEntidad = Nothing
      Me.chbCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCaja.IsPK = False
      Me.chbCaja.IsRequired = False
      Me.chbCaja.Key = Nothing
      Me.chbCaja.LabelAsoc = Nothing
      Me.chbCaja.Location = New System.Drawing.Point(678, 21)
      Me.chbCaja.Name = "chbCaja"
      Me.chbCaja.Size = New System.Drawing.Size(47, 17)
      Me.chbCaja.TabIndex = 11
      Me.chbCaja.Text = "Caja"
      Me.chbCaja.UseVisualStyleBackColor = True
      '
      'cmbCajas
      '
      Me.cmbCajas.BindearPropiedadControl = ""
      Me.cmbCajas.BindearPropiedadEntidad = ""
      Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCajas.Enabled = False
      Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCajas.FormattingEnabled = True
      Me.cmbCajas.IsPK = False
      Me.cmbCajas.IsRequired = False
      Me.cmbCajas.Key = Nothing
      Me.cmbCajas.LabelAsoc = Nothing
      Me.cmbCajas.Location = New System.Drawing.Point(726, 19)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
      Me.cmbCajas.TabIndex = 12
      '
      'rdbFechaMovimiento
      '
      Me.rdbFechaMovimiento.AutoSize = True
      Me.rdbFechaMovimiento.BindearPropiedadControl = Nothing
      Me.rdbFechaMovimiento.BindearPropiedadEntidad = Nothing
      Me.rdbFechaMovimiento.Checked = True
      Me.rdbFechaMovimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.rdbFechaMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.rdbFechaMovimiento.IsPK = False
      Me.rdbFechaMovimiento.IsRequired = False
      Me.rdbFechaMovimiento.Key = Nothing
      Me.rdbFechaMovimiento.LabelAsoc = Nothing
      Me.rdbFechaMovimiento.Location = New System.Drawing.Point(461, 65)
      Me.rdbFechaMovimiento.Name = "rdbFechaMovimiento"
      Me.rdbFechaMovimiento.Size = New System.Drawing.Size(79, 17)
      Me.rdbFechaMovimiento.TabIndex = 9
      Me.rdbFechaMovimiento.TabStop = True
      Me.rdbFechaMovimiento.Text = "Movimiento"
      Me.rdbFechaMovimiento.UseVisualStyleBackColor = True
      '
      'rdbFechaPlanilla
      '
      Me.rdbFechaPlanilla.AutoSize = True
      Me.rdbFechaPlanilla.BindearPropiedadControl = Nothing
      Me.rdbFechaPlanilla.BindearPropiedadEntidad = Nothing
      Me.rdbFechaPlanilla.ForeColorFocus = System.Drawing.Color.Red
      Me.rdbFechaPlanilla.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.rdbFechaPlanilla.IsPK = False
      Me.rdbFechaPlanilla.IsRequired = False
      Me.rdbFechaPlanilla.Key = Nothing
      Me.rdbFechaPlanilla.LabelAsoc = Nothing
      Me.rdbFechaPlanilla.Location = New System.Drawing.Point(544, 65)
      Me.rdbFechaPlanilla.Name = "rdbFechaPlanilla"
      Me.rdbFechaPlanilla.Size = New System.Drawing.Size(58, 17)
      Me.rdbFechaPlanilla.TabIndex = 10
      Me.rdbFechaPlanilla.Text = "Planilla"
      Me.rdbFechaPlanilla.UseVisualStyleBackColor = True
      '
      'lblFechaDe
      '
      Me.lblFechaDe.AutoSize = True
      Me.lblFechaDe.LabelAsoc = Nothing
      Me.lblFechaDe.Location = New System.Drawing.Point(403, 67)
      Me.lblFechaDe.Name = "lblFechaDe"
      Me.lblFechaDe.Size = New System.Drawing.Size(52, 13)
      Me.lblFechaDe.TabIndex = 8
      Me.lblFechaDe.Text = "Fecha de"
      '
      'bscCuentaCaja
      '
      Me.bscCuentaCaja.AyudaAncho = 608
      Me.bscCuentaCaja.BindearPropiedadControl = Nothing
      Me.bscCuentaCaja.BindearPropiedadEntidad = Nothing
      Me.bscCuentaCaja.ColumnasAlineacion = Nothing
      Me.bscCuentaCaja.ColumnasAncho = Nothing
      Me.bscCuentaCaja.ColumnasFormato = Nothing
      Me.bscCuentaCaja.ColumnasOcultas = Nothing
      Me.bscCuentaCaja.ColumnasTitulos = Nothing
      Me.bscCuentaCaja.Datos = Nothing
      Me.bscCuentaCaja.FilaDevuelta = Nothing
      Me.bscCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCuentaCaja.IsDecimal = False
      Me.bscCuentaCaja.IsNumber = False
      Me.bscCuentaCaja.IsPK = False
      Me.bscCuentaCaja.IsRequired = False
      Me.bscCuentaCaja.Key = ""
      Me.bscCuentaCaja.LabelAsoc = Me.lblCuentaCaja
      Me.bscCuentaCaja.Location = New System.Drawing.Point(268, 17)
      Me.bscCuentaCaja.MaxLengh = "32767"
      Me.bscCuentaCaja.Name = "bscCuentaCaja"
      Me.bscCuentaCaja.Permitido = True
      Me.bscCuentaCaja.Selecciono = False
      Me.bscCuentaCaja.Size = New System.Drawing.Size(109, 23)
      Me.bscCuentaCaja.TabIndex = 0
      Me.bscCuentaCaja.Titulo = Nothing
      '
      'lblCuentaCaja
      '
      Me.lblCuentaCaja.AutoSize = True
      Me.lblCuentaCaja.LabelAsoc = Nothing
      Me.lblCuentaCaja.Location = New System.Drawing.Point(186, 20)
      Me.lblCuentaCaja.Name = "lblCuentaCaja"
      Me.lblCuentaCaja.Size = New System.Drawing.Size(80, 13)
      Me.lblCuentaCaja.TabIndex = 2
      Me.lblCuentaCaja.Text = "Cuenta de Caja"
      '
      'bscNombreCuentaCaja
      '
      Me.bscNombreCuentaCaja.AutoSize = True
      Me.bscNombreCuentaCaja.AyudaAncho = 608
      Me.bscNombreCuentaCaja.BindearPropiedadControl = Nothing
      Me.bscNombreCuentaCaja.BindearPropiedadEntidad = Nothing
      Me.bscNombreCuentaCaja.ColumnasAlineacion = Nothing
      Me.bscNombreCuentaCaja.ColumnasAncho = Nothing
      Me.bscNombreCuentaCaja.ColumnasFormato = Nothing
      Me.bscNombreCuentaCaja.ColumnasOcultas = Nothing
      Me.bscNombreCuentaCaja.ColumnasTitulos = Nothing
      Me.bscNombreCuentaCaja.Datos = Nothing
      Me.bscNombreCuentaCaja.FilaDevuelta = Nothing
      Me.bscNombreCuentaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCuentaCaja.IsDecimal = False
      Me.bscNombreCuentaCaja.IsNumber = False
      Me.bscNombreCuentaCaja.IsPK = False
      Me.bscNombreCuentaCaja.IsRequired = False
      Me.bscNombreCuentaCaja.Key = ""
      Me.bscNombreCuentaCaja.LabelAsoc = Nothing
      Me.bscNombreCuentaCaja.Location = New System.Drawing.Point(380, 17)
      Me.bscNombreCuentaCaja.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreCuentaCaja.MaxLengh = "32767"
      Me.bscNombreCuentaCaja.Name = "bscNombreCuentaCaja"
      Me.bscNombreCuentaCaja.Permitido = True
      Me.bscNombreCuentaCaja.Selecciono = False
      Me.bscNombreCuentaCaja.Size = New System.Drawing.Size(278, 23)
      Me.bscNombreCuentaCaja.TabIndex = 1
      Me.bscNombreCuentaCaja.Titulo = Nothing
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
      Me.btnConsultar.Location = New System.Drawing.Point(755, 44)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 13
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(13, 65)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 3
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
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
      Me.dtpHasta.Location = New System.Drawing.Point(291, 63)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
      Me.dtpHasta.TabIndex = 6
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(252, 67)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 7
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
      Me.dtpDesde.Location = New System.Drawing.Point(148, 63)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 4
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(106, 67)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 5
      Me.lblDesde.Text = "Desde"
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(889, 29)
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
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
      Me.stsStado.Location = New System.Drawing.Point(0, 556)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(889, 22)
      Me.stsStado.TabIndex = 7
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(810, 17)
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
      'lblTotales
      '
      Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotales.AutoSize = True
      Me.lblTotales.LabelAsoc = Nothing
      Me.lblTotales.Location = New System.Drawing.Point(616, 502)
      Me.lblTotales.Name = "lblTotales"
      Me.lblTotales.Size = New System.Drawing.Size(45, 13)
      Me.lblTotales.TabIndex = 2
      Me.lblTotales.Text = "Totales:"
      '
      'txtTotalIngresos
      '
      Me.txtTotalIngresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalIngresos.BindearPropiedadControl = Nothing
      Me.txtTotalIngresos.BindearPropiedadEntidad = Nothing
      Me.txtTotalIngresos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalIngresos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalIngresos.Formato = "##0.00"
      Me.txtTotalIngresos.IsDecimal = True
      Me.txtTotalIngresos.IsNumber = True
      Me.txtTotalIngresos.IsPK = False
      Me.txtTotalIngresos.IsRequired = False
      Me.txtTotalIngresos.Key = ""
      Me.txtTotalIngresos.LabelAsoc = Nothing
      Me.txtTotalIngresos.Location = New System.Drawing.Point(670, 499)
      Me.txtTotalIngresos.Name = "txtTotalIngresos"
      Me.txtTotalIngresos.ReadOnly = True
      Me.txtTotalIngresos.Size = New System.Drawing.Size(90, 20)
      Me.txtTotalIngresos.TabIndex = 3
      Me.txtTotalIngresos.Text = "0.00"
      Me.txtTotalIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalEgresos
      '
      Me.txtTotalEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalEgresos.BindearPropiedadControl = Nothing
      Me.txtTotalEgresos.BindearPropiedadEntidad = Nothing
      Me.txtTotalEgresos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalEgresos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalEgresos.Formato = "##0.00"
      Me.txtTotalEgresos.IsDecimal = True
      Me.txtTotalEgresos.IsNumber = True
      Me.txtTotalEgresos.IsPK = False
      Me.txtTotalEgresos.IsRequired = False
      Me.txtTotalEgresos.Key = ""
      Me.txtTotalEgresos.LabelAsoc = Nothing
      Me.txtTotalEgresos.Location = New System.Drawing.Point(760, 499)
      Me.txtTotalEgresos.Name = "txtTotalEgresos"
      Me.txtTotalEgresos.ReadOnly = True
      Me.txtTotalEgresos.Size = New System.Drawing.Size(90, 20)
      Me.txtTotalEgresos.TabIndex = 4
      Me.txtTotalEgresos.Text = "0.00"
      Me.txtTotalEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtSaldo
      '
      Me.txtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSaldo.BindearPropiedadControl = Nothing
      Me.txtSaldo.BindearPropiedadEntidad = Nothing
      Me.txtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = "##0.00"
      Me.txtSaldo.IsDecimal = True
      Me.txtSaldo.IsNumber = True
      Me.txtSaldo.IsPK = False
      Me.txtSaldo.IsRequired = False
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Nothing
      Me.txtSaldo.Location = New System.Drawing.Point(721, 522)
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.ReadOnly = True
      Me.txtSaldo.Size = New System.Drawing.Size(90, 20)
      Me.txtSaldo.TabIndex = 6
      Me.txtSaldo.Text = "0.00"
      Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSaldo
      '
      Me.lblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblSaldo.AutoSize = True
      Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblSaldo.LabelAsoc = Nothing
      Me.lblSaldo.Location = New System.Drawing.Point(670, 525)
      Me.lblSaldo.Name = "lblSaldo"
      Me.lblSaldo.Size = New System.Drawing.Size(43, 13)
      Me.lblSaldo.TabIndex = 5
      Me.lblSaldo.Text = "Saldo:"
      '
      'txtSaldoInicial
      '
      Me.txtSaldoInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSaldoInicial.BindearPropiedadControl = Nothing
      Me.txtSaldoInicial.BindearPropiedadEntidad = Nothing
      Me.txtSaldoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSaldoInicial.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldoInicial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldoInicial.Formato = ""
      Me.txtSaldoInicial.IsDecimal = True
      Me.txtSaldoInicial.IsNumber = True
      Me.txtSaldoInicial.IsPK = False
      Me.txtSaldoInicial.IsRequired = False
      Me.txtSaldoInicial.Key = ""
      Me.txtSaldoInicial.LabelAsoc = Nothing
      Me.txtSaldoInicial.Location = New System.Drawing.Point(792, 133)
      Me.txtSaldoInicial.Name = "txtSaldoInicial"
      Me.txtSaldoInicial.ReadOnly = True
      Me.txtSaldoInicial.Size = New System.Drawing.Size(80, 20)
      Me.txtSaldoInicial.TabIndex = 39
      Me.txtSaldoInicial.Text = "0.00"
      Me.txtSaldoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtSaldoInicial.Visible = False
      '
      'lblSaldoInicial
      '
      Me.lblSaldoInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblSaldoInicial.AutoSize = True
      Me.lblSaldoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblSaldoInicial.LabelAsoc = Nothing
      Me.lblSaldoInicial.Location = New System.Drawing.Point(721, 136)
      Me.lblSaldoInicial.Name = "lblSaldoInicial"
      Me.lblSaldoInicial.Size = New System.Drawing.Size(67, 13)
      Me.lblSaldoInicial.TabIndex = 38
      Me.lblSaldoInicial.Text = "Saldo Inicial:"
      Me.lblSaldoInicial.Visible = False
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdSucursal.DefaultCellStyle = DataGridViewCellStyle2
      Me.IdSucursal.HeaderText = "Suc."
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.ReadOnly = True
      Me.IdSucursal.Width = 30
      '
      'NombreCaja
      '
      Me.NombreCaja.DataPropertyName = "NombreCaja"
      Me.NombreCaja.HeaderText = "Caja"
      Me.NombreCaja.Name = "NombreCaja"
      Me.NombreCaja.ReadOnly = True
      '
      'FechaPlanilla
      '
      Me.FechaPlanilla.DataPropertyName = "FechaPlanilla"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle3.Format = "dd/MM/yyyy"
      DataGridViewCellStyle3.NullValue = Nothing
      Me.FechaPlanilla.DefaultCellStyle = DataGridViewCellStyle3
      Me.FechaPlanilla.HeaderText = "Fecha Planilla"
      Me.FechaPlanilla.Name = "FechaPlanilla"
      Me.FechaPlanilla.ReadOnly = True
      Me.FechaPlanilla.Width = 70
      '
      'FechaMovimiento
      '
      Me.FechaMovimiento.DataPropertyName = "FechaMovimiento"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle4.Format = "dd/MM/yyyy HH:mm"
      Me.FechaMovimiento.DefaultCellStyle = DataGridViewCellStyle4
      Me.FechaMovimiento.HeaderText = "Fecha Movim."
      Me.FechaMovimiento.Name = "FechaMovimiento"
      Me.FechaMovimiento.ReadOnly = True
      '
      'NumeroPlanilla
      '
      Me.NumeroPlanilla.DataPropertyName = "NumeroPlanilla"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroPlanilla.DefaultCellStyle = DataGridViewCellStyle5
      Me.NumeroPlanilla.HeaderText = "Nro. Planilla"
      Me.NumeroPlanilla.Name = "NumeroPlanilla"
      Me.NumeroPlanilla.ReadOnly = True
      Me.NumeroPlanilla.Width = 50
      '
      'NumeroMovimiento
      '
      Me.NumeroMovimiento.DataPropertyName = "NumeroMovimiento"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroMovimiento.DefaultCellStyle = DataGridViewCellStyle6
      Me.NumeroMovimiento.HeaderText = "Nro. Movim."
      Me.NumeroMovimiento.Name = "NumeroMovimiento"
      Me.NumeroMovimiento.ReadOnly = True
      Me.NumeroMovimiento.Width = 50
      '
      'Observacion
      '
      Me.Observacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observación"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.ReadOnly = True
      '
      'Ingreso
      '
      Me.Ingreso.DataPropertyName = "Ingreso"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.Ingreso.DefaultCellStyle = DataGridViewCellStyle7
      Me.Ingreso.HeaderText = "Ingreso"
      Me.Ingreso.Name = "Ingreso"
      Me.Ingreso.ReadOnly = True
      Me.Ingreso.Width = 90
      '
      'Egreso
      '
      Me.Egreso.DataPropertyName = "Egreso"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.Egreso.DefaultCellStyle = DataGridViewCellStyle8
      Me.Egreso.HeaderText = "Egreso"
      Me.Egreso.Name = "Egreso"
      Me.Egreso.ReadOnly = True
      Me.Egreso.Width = 90
      '
      'MayorDeCuentaDeCaja
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(889, 578)
      Me.Controls.Add(Me.txtSaldoInicial)
      Me.Controls.Add(Me.lblSaldoInicial)
      Me.Controls.Add(Me.txtSaldo)
      Me.Controls.Add(Me.lblSaldo)
      Me.Controls.Add(Me.txtTotalEgresos)
      Me.Controls.Add(Me.txtTotalIngresos)
      Me.Controls.Add(Me.lblTotales)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "MayorDeCuentaDeCaja"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Mayor de Cuenta de Caja"
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
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtTotalIngresos As Eniac.Controles.TextBox
   Friend WithEvents txtTotalEgresos As Eniac.Controles.TextBox
   Friend WithEvents bscCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents lblCuentaCaja As Eniac.Controles.Label
   Friend WithEvents bscNombreCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents lblSaldo As Eniac.Controles.Label
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents rdbFechaMovimiento As Eniac.Controles.RadioButton
   Friend WithEvents rdbFechaPlanilla As Eniac.Controles.RadioButton
   Friend WithEvents lblFechaDe As Eniac.Controles.Label
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents txtSaldoInicial As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoInicial As Eniac.Controles.Label
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCaja As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Ingreso As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Egreso As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
