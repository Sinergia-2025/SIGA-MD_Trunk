<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarCompras
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarCompras))
		Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
		Me.tstBarra = New System.Windows.Forms.ToolStrip()
		Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.tsbModificar = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
		Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
		Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
		Me.grbFiltros = New System.Windows.Forms.GroupBox()
		Me.rdbAmbos = New System.Windows.Forms.RadioButton()
		Me.rdbPorFechas = New System.Windows.Forms.RadioButton()
		Me.rdbPorPeriodoFiscal = New System.Windows.Forms.RadioButton()
		Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
		Me.lblPeriodoFiscal = New Eniac.Controles.Label()
		Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
		Me.lblCodigoProveedor = New Eniac.Controles.Label()
		Me.bscProveedor = New Eniac.Controles.Buscador()
		Me.lblNombreProv = New Eniac.Controles.Label()
		Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
		Me.btnConsultar = New Eniac.Controles.Button()
		Me.chbProveedor = New Eniac.Controles.CheckBox()
		Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
		Me.chkMesCompleto = New Eniac.Controles.CheckBox()
		Me.dtpHasta = New Eniac.Controles.DateTimePicker()
		Me.lblHasta = New Eniac.Controles.Label()
		Me.dtpDesde = New Eniac.Controles.DateTimePicker()
		Me.lblDesde = New Eniac.Controles.Label()
		Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
		Me.stsStado = New System.Windows.Forms.StatusStrip()
		Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
		Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
		Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
		Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
		Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
		Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
		Me.tstBarra.SuspendLayout()
		Me.grbFiltros.SuspendLayout()
		CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.stsStado.SuspendLayout()
		Me.SuspendLayout()
		'
		'tstBarra
		'
		Me.tstBarra.AllowItemReorder = True
		Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
		Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbModificar, Me.ToolStripSeparator4, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.tsbSalir})
		Me.tstBarra.Location = New System.Drawing.Point(0, 0)
		Me.tstBarra.Name = "tstBarra"
		Me.tstBarra.Size = New System.Drawing.Size(1042, 29)
		Me.tstBarra.TabIndex = 9
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
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
		'
		'tsbModificar
		'
		Me.tsbModificar.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
		Me.tsbModificar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbModificar.Name = "tsbModificar"
		Me.tsbModificar.Size = New System.Drawing.Size(84, 26)
		Me.tsbModificar.Text = "&Modificar"
		'
		'ToolStripSeparator4
		'
		Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
		Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
		'
		'tsddExportar
		'
		Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
		Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
		Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsddExportar.Name = "tsddExportar"
		Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
		Me.tsddExportar.Text = "Exportar"
		'
		'tsmiAExcel
		'
		Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
		Me.tsmiAExcel.Name = "tsmiAExcel"
		Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
		Me.tsmiAExcel.Text = "a Excel"
		'
		'tsmiAPDF
		'
		Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
		Me.tsmiAPDF.Name = "tsmiAPDF"
		Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
		Me.tsmiAPDF.Text = "a PDF"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
		'
		'tsbPreferencias
		'
		Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
		Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbPreferencias.Name = "tsbPreferencias"
		Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
		Me.tsbPreferencias.Text = "&Preferencias"
		Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
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
		Me.grbFiltros.Controls.Add(Me.rdbAmbos)
		Me.grbFiltros.Controls.Add(Me.rdbPorFechas)
		Me.grbFiltros.Controls.Add(Me.rdbPorPeriodoFiscal)
		Me.grbFiltros.Controls.Add(Me.dtpPeriodoFiscal)
		Me.grbFiltros.Controls.Add(Me.lblPeriodoFiscal)
		Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
		Me.grbFiltros.Controls.Add(Me.bscProveedor)
		Me.grbFiltros.Controls.Add(Me.lblCodigoProveedor)
		Me.grbFiltros.Controls.Add(Me.lblNombreProv)
		Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
		Me.grbFiltros.Controls.Add(Me.btnConsultar)
		Me.grbFiltros.Controls.Add(Me.chbProveedor)
		Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
		Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
		Me.grbFiltros.Controls.Add(Me.dtpHasta)
		Me.grbFiltros.Controls.Add(Me.dtpDesde)
		Me.grbFiltros.Controls.Add(Me.lblHasta)
		Me.grbFiltros.Controls.Add(Me.lblDesde)
		Me.grbFiltros.Location = New System.Drawing.Point(5, 30)
		Me.grbFiltros.Name = "grbFiltros"
		Me.grbFiltros.Size = New System.Drawing.Size(1024, 101)
		Me.grbFiltros.TabIndex = 0
		Me.grbFiltros.TabStop = False
		Me.grbFiltros.Text = "Filtros"
		'
		'rdbAmbos
		'
		Me.rdbAmbos.AutoSize = True
		Me.rdbAmbos.Location = New System.Drawing.Point(759, 23)
		Me.rdbAmbos.Name = "rdbAmbos"
		Me.rdbAmbos.Size = New System.Drawing.Size(57, 17)
		Me.rdbAmbos.TabIndex = 9
		Me.rdbAmbos.Text = "Ambos"
		Me.rdbAmbos.UseVisualStyleBackColor = True
		'
		'rdbPorFechas
		'
		Me.rdbPorFechas.AutoSize = True
		Me.rdbPorFechas.Checked = True
		Me.rdbPorFechas.Location = New System.Drawing.Point(580, 23)
		Me.rdbPorFechas.Name = "rdbPorFechas"
		Me.rdbPorFechas.Size = New System.Drawing.Size(79, 17)
		Me.rdbPorFechas.TabIndex = 7
		Me.rdbPorFechas.TabStop = True
		Me.rdbPorFechas.Text = "Por Fechas"
		Me.rdbPorFechas.UseVisualStyleBackColor = True
		'
		'rdbPorPeriodoFiscal
		'
		Me.rdbPorPeriodoFiscal.AutoSize = True
		Me.rdbPorPeriodoFiscal.Location = New System.Drawing.Point(670, 23)
		Me.rdbPorPeriodoFiscal.Name = "rdbPorPeriodoFiscal"
		Me.rdbPorPeriodoFiscal.Size = New System.Drawing.Size(80, 17)
		Me.rdbPorPeriodoFiscal.TabIndex = 8
		Me.rdbPorPeriodoFiscal.Text = "Por Periodo"
		Me.rdbPorPeriodoFiscal.UseVisualStyleBackColor = True
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
		Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(492, 21)
		Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
		Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(71, 20)
		Me.dtpPeriodoFiscal.TabIndex = 6
		'
		'lblPeriodoFiscal
		'
		Me.lblPeriodoFiscal.AutoSize = True
		Me.lblPeriodoFiscal.LabelAsoc = Nothing
		Me.lblPeriodoFiscal.Location = New System.Drawing.Point(413, 25)
		Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
		Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
		Me.lblPeriodoFiscal.TabIndex = 5
		Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
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
		Me.bscCodigoProveedor.IsNumber = False
		Me.bscCodigoProveedor.IsPK = False
		Me.bscCodigoProveedor.IsRequired = False
		Me.bscCodigoProveedor.Key = ""
		Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
		Me.bscCodigoProveedor.Location = New System.Drawing.Point(94, 66)
		Me.bscCodigoProveedor.MaxLengh = "32767"
		Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
		Me.bscCodigoProveedor.Permitido = True
		Me.bscCodigoProveedor.Selecciono = False
		Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
		Me.bscCodigoProveedor.TabIndex = 11
		Me.bscCodigoProveedor.Titulo = Nothing
		'
		'lblCodigoProveedor
		'
		Me.lblCodigoProveedor.AutoSize = True
		Me.lblCodigoProveedor.LabelAsoc = Nothing
		Me.lblCodigoProveedor.Location = New System.Drawing.Point(91, 50)
		Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
		Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
		Me.lblCodigoProveedor.TabIndex = 12
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
		Me.bscProveedor.LabelAsoc = Me.lblNombreProv
		Me.bscProveedor.Location = New System.Drawing.Point(191, 66)
		Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
		Me.bscProveedor.MaxLengh = "32767"
		Me.bscProveedor.Name = "bscProveedor"
		Me.bscProveedor.Permitido = True
		Me.bscProveedor.Selecciono = False
		Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
		Me.bscProveedor.TabIndex = 13
		Me.bscProveedor.Titulo = Nothing
		'
		'lblNombreProv
		'
		Me.lblNombreProv.AutoSize = True
		Me.lblNombreProv.LabelAsoc = Nothing
		Me.lblNombreProv.Location = New System.Drawing.Point(188, 50)
		Me.lblNombreProv.Name = "lblNombreProv"
		Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
		Me.lblNombreProv.TabIndex = 14
		Me.lblNombreProv.Text = "Nombre"
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
		Me.cmbTiposComprobantes.Location = New System.Drawing.Point(620, 66)
		Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
		Me.cmbTiposComprobantes.Size = New System.Drawing.Size(140, 21)
		Me.cmbTiposComprobantes.TabIndex = 16
		'
		'btnConsultar
		'
		Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
		Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnConsultar.Location = New System.Drawing.Point(918, 47)
		Me.btnConsultar.Name = "btnConsultar"
		Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
		Me.btnConsultar.TabIndex = 17
		Me.btnConsultar.Text = "&Consultar"
		Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnConsultar.UseVisualStyleBackColor = True
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
		Me.chbProveedor.Location = New System.Drawing.Point(13, 66)
		Me.chbProveedor.Name = "chbProveedor"
		Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
		Me.chbProveedor.TabIndex = 10
		Me.chbProveedor.Text = "Proveedor"
		Me.chbProveedor.UseVisualStyleBackColor = True
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
		Me.chbTipoComprobante.Location = New System.Drawing.Point(503, 68)
		Me.chbTipoComprobante.Name = "chbTipoComprobante"
		Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
		Me.chbTipoComprobante.TabIndex = 15
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
		Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
		Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
		Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.dtpHasta.IsPK = False
		Me.dtpHasta.IsRequired = False
		Me.dtpHasta.Key = ""
		Me.dtpHasta.LabelAsoc = Me.lblHasta
		Me.dtpHasta.Location = New System.Drawing.Point(303, 21)
		Me.dtpHasta.Name = "dtpHasta"
		Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
		Me.dtpHasta.TabIndex = 4
		'
		'lblHasta
		'
		Me.lblHasta.AutoSize = True
		Me.lblHasta.LabelAsoc = Nothing
		Me.lblHasta.Location = New System.Drawing.Point(262, 25)
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
		Me.dtpDesde.Location = New System.Drawing.Point(154, 21)
		Me.dtpDesde.Name = "dtpDesde"
		Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
		Me.dtpDesde.TabIndex = 2
		'
		'lblDesde
		'
		Me.lblDesde.AutoSize = True
		Me.lblDesde.LabelAsoc = Nothing
		Me.lblDesde.Location = New System.Drawing.Point(110, 25)
		Me.lblDesde.Name = "lblDesde"
		Me.lblDesde.Size = New System.Drawing.Size(38, 13)
		Me.lblDesde.TabIndex = 1
		Me.lblDesde.Text = "Desde"
		'
		'ugDetalle
		'
		Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Appearance1.BackColor = System.Drawing.SystemColors.Window
		Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
		Me.ugDetalle.DisplayLayout.Appearance = Appearance1
		Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
		Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
		Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
		Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
		Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
		Appearance2.BorderColor = System.Drawing.SystemColors.Window
		Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance2
		Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
		Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
		Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
		Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar."
		Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
		Appearance4.BackColor2 = System.Drawing.SystemColors.Control
		Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
		Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
		Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
		Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
		Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
		Appearance5.BackColor = System.Drawing.SystemColors.Window
		Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
		Appearance6.BackColor = System.Drawing.SystemColors.Highlight
		Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
		Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
		Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
		Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
		Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
		Appearance7.BackColor = System.Drawing.SystemColors.Window
		Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance7
		Appearance8.BorderColor = System.Drawing.Color.Silver
		Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
		Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance8
		Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
		Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
		Appearance9.BackColor = System.Drawing.SystemColors.Control
		Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
		Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
		Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
		Appearance9.BorderColor = System.Drawing.SystemColors.Window
		Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance9
		Appearance10.TextHAlignAsString = "Left"
		Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance10
		Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
		Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
		Appearance11.BackColor = System.Drawing.SystemColors.Window
		Appearance11.BorderColor = System.Drawing.Color.Silver
		Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance11
		Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
		Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
		Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
		Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
		Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
		Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
		Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
		Me.ugDetalle.Location = New System.Drawing.Point(5, 134)
		Me.ugDetalle.Name = "ugDetalle"
		Me.ugDetalle.Size = New System.Drawing.Size(1031, 355)
		Me.ugDetalle.TabIndex = 10
		Me.ugDetalle.Text = "UltraGrid1"
		'
		'stsStado
		'
		Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
		Me.stsStado.Location = New System.Drawing.Point(0, 490)
		Me.stsStado.Name = "stsStado"
		Me.stsStado.Size = New System.Drawing.Size(1042, 22)
		Me.stsStado.TabIndex = 11
		Me.stsStado.Text = "statusStrip1"
		'
		'tssInfo
		'
		Me.tssInfo.Name = "tssInfo"
		Me.tssInfo.Size = New System.Drawing.Size(963, 17)
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
		'UltraGridPrintDocument1
		'
		Me.UltraGridPrintDocument1.DocumentName = "Informe"
		Me.UltraGridPrintDocument1.Footer.TextCenter = ""
		Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
		Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
		Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
		Me.UltraGridPrintDocument1.Header.Appearance = Appearance13
		Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
		Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
		Me.UltraGridPrintDocument1.Header.TextCenter = ""
		Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
		Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
		Me.UltraGridPrintDocument1.Page.Margins.Left = 2
		Me.UltraGridPrintDocument1.Page.Margins.Right = 2
		Me.UltraGridPrintDocument1.Page.Margins.Top = 2
		Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
		Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
		Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
		Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
		Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
		'
		'ModificarCompras
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1042, 512)
		Me.Controls.Add(Me.stsStado)
		Me.Controls.Add(Me.ugDetalle)
		Me.Controls.Add(Me.grbFiltros)
		Me.Controls.Add(Me.tstBarra)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.Name = "ModificarCompras"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Modificar Compras"
		Me.tstBarra.ResumeLayout(False)
		Me.tstBarra.PerformLayout()
		Me.grbFiltros.ResumeLayout(False)
		Me.grbFiltros.PerformLayout()
		CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
		Me.stsStado.ResumeLayout(False)
		Me.stsStado.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbModificar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents rdbAmbos As System.Windows.Forms.RadioButton
   Friend WithEvents rdbPorFechas As System.Windows.Forms.RadioButton
   Friend WithEvents rdbPorPeriodoFiscal As System.Windows.Forms.RadioButton
   Protected WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
End Class
