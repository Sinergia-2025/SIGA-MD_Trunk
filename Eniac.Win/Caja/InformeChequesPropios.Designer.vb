<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeChequesPropios
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
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeChequesPropios))
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.cmbEstado = New Eniac.Win.ComboBoxEstadosCheques()
      Me.cmbCuentas = New Eniac.Controles.ComboBox()
      Me.chbCuenta = New Eniac.Controles.CheckBox()
      Me.chbEmision = New Eniac.Controles.CheckBox()
      Me.dtpHastaFechaEmi = New Eniac.Controles.DateTimePicker()
      Me.Label1 = New Eniac.Controles.Label()
      Me.dtpDesdeFechaEmi = New Eniac.Controles.DateTimePicker()
      Me.Label2 = New Eniac.Controles.Label()
      Me.chbCaja = New Eniac.Controles.CheckBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.lblNombreProv = New Eniac.Controles.Label()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chbFechaCobro = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbLocalidad = New Eniac.Controles.CheckBox()
      Me.cmbLocalidad = New Eniac.Controles.ComboBox()
      Me.cmbBanco = New Eniac.Controles.ComboBox()
      Me.chbBanco = New Eniac.Controles.CheckBox()
      Me.dtpFechaCobroHasta = New Eniac.Controles.DateTimePicker()
      Me.lblFechaCobroHasta = New Eniac.Controles.Label()
      Me.dtpFechaCobroDesde = New Eniac.Controles.DateTimePicker()
      Me.lblFechaCobroDesde = New Eniac.Controles.Label()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.SuspendLayout()
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
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
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre las columnas aquí para agrupar."
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
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Location = New System.Drawing.Point(12, 181)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(1057, 326)
      Me.ugDetalle.TabIndex = 1
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 510)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(1081, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(1002, 17)
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
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1081, 29)
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
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbPreferencias
      '
      Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
      Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPreferencias.Name = "tsbPreferencias"
      Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
      Me.tsbPreferencias.Text = "&Preferencias"
      Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      Me.grbFiltros.Controls.Add(Me.lblEstado)
      Me.grbFiltros.Controls.Add(Me.cmbEstado)
      Me.grbFiltros.Controls.Add(Me.cmbCuentas)
      Me.grbFiltros.Controls.Add(Me.chbCuenta)
      Me.grbFiltros.Controls.Add(Me.chbEmision)
      Me.grbFiltros.Controls.Add(Me.dtpHastaFechaEmi)
      Me.grbFiltros.Controls.Add(Me.dtpDesdeFechaEmi)
      Me.grbFiltros.Controls.Add(Me.Label1)
      Me.grbFiltros.Controls.Add(Me.Label2)
      Me.grbFiltros.Controls.Add(Me.chbCaja)
      Me.grbFiltros.Controls.Add(Me.cmbCajas)
      Me.grbFiltros.Controls.Add(Me.chbNumero)
      Me.grbFiltros.Controls.Add(Me.txtNumero)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.bscProveedor)
      Me.grbFiltros.Controls.Add(Me.lblCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.lblNombreProv)
      Me.grbFiltros.Controls.Add(Me.chbProveedor)
      Me.grbFiltros.Controls.Add(Me.chbFechaCobro)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbLocalidad)
      Me.grbFiltros.Controls.Add(Me.cmbLocalidad)
      Me.grbFiltros.Controls.Add(Me.cmbBanco)
      Me.grbFiltros.Controls.Add(Me.chbBanco)
      Me.grbFiltros.Controls.Add(Me.dtpFechaCobroHasta)
      Me.grbFiltros.Controls.Add(Me.dtpFechaCobroDesde)
      Me.grbFiltros.Controls.Add(Me.lblFechaCobroHasta)
      Me.grbFiltros.Controls.Add(Me.lblFechaCobroDesde)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(1057, 137)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(201, 22)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 37
      Me.lblEstado.Text = "Estado"
      '
      'cmbEstado
      '
      Me.cmbEstado.BindearPropiedadControl = Nothing
      Me.cmbEstado.BindearPropiedadEntidad = Nothing
      Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstado.FormattingEnabled = True
      Me.cmbEstado.IsPK = False
      Me.cmbEstado.IsRequired = False
      Me.cmbEstado.Key = Nothing
      Me.cmbEstado.LabelAsoc = Me.lblEstado
      Me.cmbEstado.Location = New System.Drawing.Point(255, 19)
      Me.cmbEstado.Name = "cmbEstado"
      Me.cmbEstado.Size = New System.Drawing.Size(125, 21)
      Me.cmbEstado.TabIndex = 3
      '
      'cmbCuentas
      '
      Me.cmbCuentas.BindearPropiedadControl = Nothing
      Me.cmbCuentas.BindearPropiedadEntidad = Nothing
      Me.cmbCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCuentas.Enabled = False
      Me.cmbCuentas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCuentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCuentas.FormattingEnabled = True
      Me.cmbCuentas.IsPK = False
      Me.cmbCuentas.IsRequired = False
      Me.cmbCuentas.Key = Nothing
      Me.cmbCuentas.LabelAsoc = Nothing
      Me.cmbCuentas.Location = New System.Drawing.Point(401, 91)
      Me.cmbCuentas.Name = "cmbCuentas"
      Me.cmbCuentas.Size = New System.Drawing.Size(209, 21)
      Me.cmbCuentas.TabIndex = 24
      '
      'chbCuenta
      '
      Me.chbCuenta.AutoSize = True
      Me.chbCuenta.BindearPropiedadControl = Nothing
      Me.chbCuenta.BindearPropiedadEntidad = Nothing
      Me.chbCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCuenta.IsPK = False
      Me.chbCuenta.IsRequired = False
      Me.chbCuenta.Key = Nothing
      Me.chbCuenta.LabelAsoc = Nothing
      Me.chbCuenta.Location = New System.Drawing.Point(293, 95)
      Me.chbCuenta.Name = "chbCuenta"
      Me.chbCuenta.Size = New System.Drawing.Size(105, 17)
      Me.chbCuenta.TabIndex = 23
      Me.chbCuenta.Text = "Cuenta Bancaria"
      Me.chbCuenta.UseVisualStyleBackColor = True
      '
      'chbEmision
      '
      Me.chbEmision.AutoSize = True
      Me.chbEmision.BindearPropiedadControl = Nothing
      Me.chbEmision.BindearPropiedadEntidad = Nothing
      Me.chbEmision.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEmision.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEmision.IsPK = False
      Me.chbEmision.IsRequired = False
      Me.chbEmision.Key = Nothing
      Me.chbEmision.LabelAsoc = Nothing
      Me.chbEmision.Location = New System.Drawing.Point(401, 21)
      Me.chbEmision.Name = "chbEmision"
      Me.chbEmision.Size = New System.Drawing.Size(62, 17)
      Me.chbEmision.TabIndex = 4
      Me.chbEmision.Text = "Emisión"
      Me.chbEmision.UseVisualStyleBackColor = True
      '
      'dtpHastaFechaEmi
      '
      Me.dtpHastaFechaEmi.BindearPropiedadControl = Nothing
      Me.dtpHastaFechaEmi.BindearPropiedadEntidad = Nothing
      Me.dtpHastaFechaEmi.CustomFormat = "dd/MM/yyyy"
      Me.dtpHastaFechaEmi.Enabled = False
      Me.dtpHastaFechaEmi.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHastaFechaEmi.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHastaFechaEmi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHastaFechaEmi.IsPK = False
      Me.dtpHastaFechaEmi.IsRequired = False
      Me.dtpHastaFechaEmi.Key = ""
      Me.dtpHastaFechaEmi.LabelAsoc = Me.Label1
      Me.dtpHastaFechaEmi.Location = New System.Drawing.Point(627, 19)
      Me.dtpHastaFechaEmi.Name = "dtpHastaFechaEmi"
      Me.dtpHastaFechaEmi.Size = New System.Drawing.Size(80, 20)
      Me.dtpHastaFechaEmi.TabIndex = 8
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(591, 23)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(35, 13)
      Me.Label1.TabIndex = 7
      Me.Label1.Text = "Hasta"
      '
      'dtpDesdeFechaEmi
      '
      Me.dtpDesdeFechaEmi.BindearPropiedadControl = Nothing
      Me.dtpDesdeFechaEmi.BindearPropiedadEntidad = Nothing
      Me.dtpDesdeFechaEmi.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesdeFechaEmi.Enabled = False
      Me.dtpDesdeFechaEmi.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesdeFechaEmi.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesdeFechaEmi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesdeFechaEmi.IsPK = False
      Me.dtpDesdeFechaEmi.IsRequired = False
      Me.dtpDesdeFechaEmi.Key = ""
      Me.dtpDesdeFechaEmi.LabelAsoc = Me.Label2
      Me.dtpDesdeFechaEmi.Location = New System.Drawing.Point(505, 19)
      Me.dtpDesdeFechaEmi.Name = "dtpDesdeFechaEmi"
      Me.dtpDesdeFechaEmi.Size = New System.Drawing.Size(80, 20)
      Me.dtpDesdeFechaEmi.TabIndex = 6
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(466, 23)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "Desde"
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
      Me.chbCaja.Location = New System.Drawing.Point(14, 21)
      Me.chbCaja.Name = "chbCaja"
      Me.chbCaja.Size = New System.Drawing.Size(47, 17)
      Me.chbCaja.TabIndex = 0
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
      Me.cmbCajas.Location = New System.Drawing.Point(64, 19)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
      Me.cmbCajas.TabIndex = 1
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
      Me.chbNumero.Location = New System.Drawing.Point(632, 60)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(63, 17)
      Me.chbNumero.TabIndex = 19
      Me.chbNumero.Text = "Numero"
      Me.chbNumero.UseVisualStyleBackColor = True
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
      Me.txtNumero.Location = New System.Drawing.Point(707, 58)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(73, 20)
      Me.txtNumero.TabIndex = 20
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(92, 58)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 16
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.LabelAsoc = Nothing
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(89, 44)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 15
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
      Me.bscProveedor.Location = New System.Drawing.Point(189, 58)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
      Me.bscProveedor.TabIndex = 18
      Me.bscProveedor.Titulo = Nothing
      '
      'lblNombreProv
      '
      Me.lblNombreProv.AutoSize = True
      Me.lblNombreProv.LabelAsoc = Nothing
      Me.lblNombreProv.Location = New System.Drawing.Point(186, 44)
      Me.lblNombreProv.Name = "lblNombreProv"
      Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProv.TabIndex = 17
      Me.lblNombreProv.Text = "Nombre"
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
      Me.chbProveedor.Location = New System.Drawing.Point(14, 61)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 14
      Me.chbProveedor.Text = "Proveedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
      '
      'chbFechaCobro
      '
      Me.chbFechaCobro.AutoSize = True
      Me.chbFechaCobro.BindearPropiedadControl = Nothing
      Me.chbFechaCobro.BindearPropiedadEntidad = Nothing
      Me.chbFechaCobro.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaCobro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaCobro.IsPK = False
      Me.chbFechaCobro.IsRequired = False
      Me.chbFechaCobro.Key = Nothing
      Me.chbFechaCobro.LabelAsoc = Nothing
      Me.chbFechaCobro.Location = New System.Drawing.Point(742, 21)
      Me.chbFechaCobro.Name = "chbFechaCobro"
      Me.chbFechaCobro.Size = New System.Drawing.Size(54, 17)
      Me.chbFechaCobro.TabIndex = 9
      Me.chbFechaCobro.Text = "Cobro"
      Me.chbFechaCobro.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(933, 61)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 27
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chbLocalidad
      '
      Me.chbLocalidad.AutoSize = True
      Me.chbLocalidad.BindearPropiedadControl = Nothing
      Me.chbLocalidad.BindearPropiedadEntidad = Nothing
      Me.chbLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLocalidad.IsPK = False
      Me.chbLocalidad.IsRequired = False
      Me.chbLocalidad.Key = Nothing
      Me.chbLocalidad.LabelAsoc = Nothing
      Me.chbLocalidad.Location = New System.Drawing.Point(632, 93)
      Me.chbLocalidad.Name = "chbLocalidad"
      Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
      Me.chbLocalidad.TabIndex = 25
      Me.chbLocalidad.Text = "Localidad"
      Me.chbLocalidad.UseVisualStyleBackColor = True
      '
      'cmbLocalidad
      '
      Me.cmbLocalidad.BindearPropiedadControl = ""
      Me.cmbLocalidad.BindearPropiedadEntidad = ""
      Me.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLocalidad.Enabled = False
      Me.cmbLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLocalidad.FormattingEnabled = True
      Me.cmbLocalidad.IsPK = False
      Me.cmbLocalidad.IsRequired = True
      Me.cmbLocalidad.Key = Nothing
      Me.cmbLocalidad.LabelAsoc = Nothing
      Me.cmbLocalidad.Location = New System.Drawing.Point(707, 91)
      Me.cmbLocalidad.Name = "cmbLocalidad"
      Me.cmbLocalidad.Size = New System.Drawing.Size(160, 21)
      Me.cmbLocalidad.TabIndex = 26
      '
      'cmbBanco
      '
      Me.cmbBanco.BindearPropiedadControl = ""
      Me.cmbBanco.BindearPropiedadEntidad = ""
      Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbBanco.Enabled = False
      Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbBanco.FormattingEnabled = True
      Me.cmbBanco.IsPK = True
      Me.cmbBanco.IsRequired = True
      Me.cmbBanco.Key = Nothing
      Me.cmbBanco.LabelAsoc = Nothing
      Me.cmbBanco.Location = New System.Drawing.Point(92, 91)
      Me.cmbBanco.Name = "cmbBanco"
      Me.cmbBanco.Size = New System.Drawing.Size(160, 21)
      Me.cmbBanco.TabIndex = 22
      '
      'chbBanco
      '
      Me.chbBanco.AutoSize = True
      Me.chbBanco.BindearPropiedadControl = Nothing
      Me.chbBanco.BindearPropiedadEntidad = Nothing
      Me.chbBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.chbBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbBanco.IsPK = False
      Me.chbBanco.IsRequired = False
      Me.chbBanco.Key = Nothing
      Me.chbBanco.LabelAsoc = Nothing
      Me.chbBanco.Location = New System.Drawing.Point(14, 96)
      Me.chbBanco.Name = "chbBanco"
      Me.chbBanco.Size = New System.Drawing.Size(57, 17)
      Me.chbBanco.TabIndex = 21
      Me.chbBanco.Text = "Banco"
      Me.chbBanco.UseVisualStyleBackColor = True
      '
      'dtpFechaCobroHasta
      '
      Me.dtpFechaCobroHasta.BindearPropiedadControl = Nothing
      Me.dtpFechaCobroHasta.BindearPropiedadEntidad = Nothing
      Me.dtpFechaCobroHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaCobroHasta.Enabled = False
      Me.dtpFechaCobroHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaCobroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaCobroHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaCobroHasta.IsPK = False
      Me.dtpFechaCobroHasta.IsRequired = False
      Me.dtpFechaCobroHasta.Key = ""
      Me.dtpFechaCobroHasta.LabelAsoc = Me.lblFechaCobroHasta
      Me.dtpFechaCobroHasta.Location = New System.Drawing.Point(968, 19)
      Me.dtpFechaCobroHasta.Name = "dtpFechaCobroHasta"
      Me.dtpFechaCobroHasta.Size = New System.Drawing.Size(80, 20)
      Me.dtpFechaCobroHasta.TabIndex = 13
      '
      'lblFechaCobroHasta
      '
      Me.lblFechaCobroHasta.AutoSize = True
      Me.lblFechaCobroHasta.LabelAsoc = Nothing
      Me.lblFechaCobroHasta.Location = New System.Drawing.Point(930, 23)
      Me.lblFechaCobroHasta.Name = "lblFechaCobroHasta"
      Me.lblFechaCobroHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblFechaCobroHasta.TabIndex = 12
      Me.lblFechaCobroHasta.Text = "Hasta"
      '
      'dtpFechaCobroDesde
      '
      Me.dtpFechaCobroDesde.BindearPropiedadControl = Nothing
      Me.dtpFechaCobroDesde.BindearPropiedadEntidad = Nothing
      Me.dtpFechaCobroDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaCobroDesde.Enabled = False
      Me.dtpFechaCobroDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaCobroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaCobroDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaCobroDesde.IsPK = False
      Me.dtpFechaCobroDesde.IsRequired = False
      Me.dtpFechaCobroDesde.Key = ""
      Me.dtpFechaCobroDesde.LabelAsoc = Me.lblFechaCobroDesde
      Me.dtpFechaCobroDesde.Location = New System.Drawing.Point(843, 19)
      Me.dtpFechaCobroDesde.Name = "dtpFechaCobroDesde"
      Me.dtpFechaCobroDesde.Size = New System.Drawing.Size(80, 20)
      Me.dtpFechaCobroDesde.TabIndex = 11
      '
      'lblFechaCobroDesde
      '
      Me.lblFechaCobroDesde.AutoSize = True
      Me.lblFechaCobroDesde.LabelAsoc = Nothing
      Me.lblFechaCobroDesde.Location = New System.Drawing.Point(802, 23)
      Me.lblFechaCobroDesde.Name = "lblFechaCobroDesde"
      Me.lblFechaCobroDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblFechaCobroDesde.TabIndex = 10
      Me.lblFechaCobroDesde.Text = "Desde"
      '
      'InformeChequesPropios
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1081, 532)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "InformeChequesPropios"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Cheques Propios"
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpFechaCobroHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCobroHasta As Eniac.Controles.Label
   Friend WithEvents dtpFechaCobroDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCobroDesde As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbBanco As Eniac.Controles.CheckBox
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbFechaCobro As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbEmision As Eniac.Controles.CheckBox
   Friend WithEvents dtpHastaFechaEmi As Eniac.Controles.DateTimePicker
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dtpDesdeFechaEmi As Eniac.Controles.DateTimePicker
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents cmbCuentas As Eniac.Controles.ComboBox
   Friend WithEvents chbCuenta As Eniac.Controles.CheckBox
   Friend WithEvents cmbEstado As Eniac.Win.ComboBoxEstadosCheques
   Friend WithEvents lblEstado As Eniac.Controles.Label
End Class
