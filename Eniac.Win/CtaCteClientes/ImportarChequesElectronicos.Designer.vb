<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportarChequesElectronicos
    Inherits BaseForm

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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
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
        Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLeerArchivo = New System.Windows.Forms.ToolStripButton()
        Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGenerarRecibos = New System.Windows.Forms.ToolStripButton()
        Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbCabecera = New System.Windows.Forms.GroupBox()
        Me.txtRangoCeldasColumnaHasta = New Eniac.Controles.TextBox()
        Me.lblRangoCeldas = New Eniac.Controles.Label()
        Me.txtRangoCeldasFilaDesde = New Eniac.Controles.TextBox()
        Me.txtRangoCeldasFilaHasta = New Eniac.Controles.TextBox()
        Me.txtRangoCeldasColumnaDesde = New Eniac.Controles.TextBox()
        Me.lblSeparadosCeldas = New Eniac.Controles.Label()
        Me.cmbTipo = New Eniac.Controles.ComboBox()
        Me.lblTipo = New Eniac.Controles.Label()
        Me.dtpFecha = New Eniac.Controles.DateTimePicker()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.lblCobradores = New Eniac.Controles.Label()
        Me.lblTipoRecibo = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.cmbTipoRecibo = New Eniac.Controles.ComboBox()
        Me.cmbCobradores = New Eniac.Controles.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCabecera.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbLeerArchivo, Me.tss2, Me.tsbGenerarRecibos, Me.tss3, Me.tsbImprimir, Me.tsddExportar, Me.tss4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 4
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        Me.tsbRefrescar.ToolTipText = "Cerrar el formulario"
        '
        'tss1
        '
        Me.tss1.Name = "tss1"
        Me.tss1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbLeerArchivo
        '
        Me.tsbLeerArchivo.Image = Global.Eniac.Win.My.Resources.Resources.import1
        Me.tsbLeerArchivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLeerArchivo.Name = "tsbLeerArchivo"
        Me.tsbLeerArchivo.Size = New System.Drawing.Size(99, 26)
        Me.tsbLeerArchivo.Text = "&Leer Archivo"
        '
        'tss2
        '
        Me.tss2.Name = "tss2"
        Me.tss2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbGenerarRecibos
        '
        Me.tsbGenerarRecibos.Enabled = False
        Me.tsbGenerarRecibos.Image = Global.Eniac.Win.My.Resources.Resources.cashier
        Me.tsbGenerarRecibos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerarRecibos.Name = "tsbGenerarRecibos"
        Me.tsbGenerarRecibos.Size = New System.Drawing.Size(118, 26)
        Me.tsbGenerarRecibos.Text = "Generar Recibos"
        '
        'tss3
        '
        Me.tss3.Name = "tss3"
        Me.tss3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
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
        'tss4
        '
        Me.tss4.Name = "tss4"
        Me.tss4.Size = New System.Drawing.Size(6, 29)
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
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridBand1.ColHeaderLines = 2
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
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
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
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
        Me.ugDetalle.Location = New System.Drawing.Point(0, 109)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 428)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'grbCabecera
        '
        Me.grbCabecera.Controls.Add(Me.txtRangoCeldasColumnaHasta)
        Me.grbCabecera.Controls.Add(Me.txtRangoCeldasFilaDesde)
        Me.grbCabecera.Controls.Add(Me.txtRangoCeldasFilaHasta)
        Me.grbCabecera.Controls.Add(Me.txtRangoCeldasColumnaDesde)
        Me.grbCabecera.Controls.Add(Me.lblRangoCeldas)
        Me.grbCabecera.Controls.Add(Me.lblSeparadosCeldas)
        Me.grbCabecera.Controls.Add(Me.cmbTipo)
        Me.grbCabecera.Controls.Add(Me.lblTipo)
        Me.grbCabecera.Location = New System.Drawing.Point(12, 32)
        Me.grbCabecera.Name = "grbCabecera"
        Me.grbCabecera.Size = New System.Drawing.Size(248, 71)
        Me.grbCabecera.TabIndex = 0
        Me.grbCabecera.TabStop = False
        '
        'txtRangoCeldasColumnaHasta
        '
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaHasta.Formato = ""
        Me.txtRangoCeldasColumnaHasta.IsDecimal = False
        Me.txtRangoCeldasColumnaHasta.IsNumber = False
        Me.txtRangoCeldasColumnaHasta.IsPK = False
        Me.txtRangoCeldasColumnaHasta.IsRequired = False
        Me.txtRangoCeldasColumnaHasta.Key = ""
        Me.txtRangoCeldasColumnaHasta.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasColumnaHasta.Location = New System.Drawing.Point(171, 38)
        Me.txtRangoCeldasColumnaHasta.Name = "txtRangoCeldasColumnaHasta"
        Me.txtRangoCeldasColumnaHasta.Size = New System.Drawing.Size(20, 20)
        Me.txtRangoCeldasColumnaHasta.TabIndex = 5
        Me.txtRangoCeldasColumnaHasta.Text = "-"
        Me.txtRangoCeldasColumnaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRangoCeldas
        '
        Me.lblRangoCeldas.AutoSize = True
        Me.lblRangoCeldas.LabelAsoc = Nothing
        Me.lblRangoCeldas.Location = New System.Drawing.Point(6, 41)
        Me.lblRangoCeldas.Name = "lblRangoCeldas"
        Me.lblRangoCeldas.Size = New System.Drawing.Size(88, 13)
        Me.lblRangoCeldas.TabIndex = 2
        Me.lblRangoCeldas.Text = "Rango de celdas"
        '
        'txtRangoCeldasFilaDesde
        '
        Me.txtRangoCeldasFilaDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRangoCeldasFilaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaDesde.Formato = ""
        Me.txtRangoCeldasFilaDesde.IsDecimal = False
        Me.txtRangoCeldasFilaDesde.IsNumber = False
        Me.txtRangoCeldasFilaDesde.IsPK = False
        Me.txtRangoCeldasFilaDesde.IsRequired = False
        Me.txtRangoCeldasFilaDesde.Key = ""
        Me.txtRangoCeldasFilaDesde.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasFilaDesde.Location = New System.Drawing.Point(133, 38)
        Me.txtRangoCeldasFilaDesde.Name = "txtRangoCeldasFilaDesde"
        Me.txtRangoCeldasFilaDesde.Size = New System.Drawing.Size(30, 20)
        Me.txtRangoCeldasFilaDesde.TabIndex = 4
        Me.txtRangoCeldasFilaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRangoCeldasFilaHasta
        '
        Me.txtRangoCeldasFilaHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRangoCeldasFilaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaHasta.Formato = ""
        Me.txtRangoCeldasFilaHasta.IsDecimal = False
        Me.txtRangoCeldasFilaHasta.IsNumber = False
        Me.txtRangoCeldasFilaHasta.IsPK = False
        Me.txtRangoCeldasFilaHasta.IsRequired = False
        Me.txtRangoCeldasFilaHasta.Key = ""
        Me.txtRangoCeldasFilaHasta.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasFilaHasta.Location = New System.Drawing.Point(190, 38)
        Me.txtRangoCeldasFilaHasta.Name = "txtRangoCeldasFilaHasta"
        Me.txtRangoCeldasFilaHasta.Size = New System.Drawing.Size(46, 20)
        Me.txtRangoCeldasFilaHasta.TabIndex = 6
        Me.txtRangoCeldasFilaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRangoCeldasColumnaDesde
        '
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaDesde.Formato = ""
        Me.txtRangoCeldasColumnaDesde.IsDecimal = False
        Me.txtRangoCeldasColumnaDesde.IsNumber = False
        Me.txtRangoCeldasColumnaDesde.IsPK = False
        Me.txtRangoCeldasColumnaDesde.IsRequired = False
        Me.txtRangoCeldasColumnaDesde.Key = ""
        Me.txtRangoCeldasColumnaDesde.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasColumnaDesde.Location = New System.Drawing.Point(114, 38)
        Me.txtRangoCeldasColumnaDesde.Name = "txtRangoCeldasColumnaDesde"
        Me.txtRangoCeldasColumnaDesde.Size = New System.Drawing.Size(20, 20)
        Me.txtRangoCeldasColumnaDesde.TabIndex = 3
        Me.txtRangoCeldasColumnaDesde.Text = "-"
        Me.txtRangoCeldasColumnaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSeparadosCeldas
        '
        Me.lblSeparadosCeldas.AutoSize = True
        Me.lblSeparadosCeldas.LabelAsoc = Nothing
        Me.lblSeparadosCeldas.Location = New System.Drawing.Point(162, 42)
        Me.lblSeparadosCeldas.Name = "lblSeparadosCeldas"
        Me.lblSeparadosCeldas.Size = New System.Drawing.Size(10, 13)
        Me.lblSeparadosCeldas.TabIndex = 17
        Me.lblSeparadosCeldas.Text = ":"
        Me.lblSeparadosCeldas.Visible = False
        '
        'cmbTipo
        '
        Me.cmbTipo.BindearPropiedadControl = ""
        Me.cmbTipo.BindearPropiedadEntidad = ""
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.IsPK = False
        Me.cmbTipo.IsRequired = False
        Me.cmbTipo.Items.AddRange(New Object() {"Macro", "Santander Rio", "Pago Mis Cuentas", "Roela Pago Mis Cuentas"})
        Me.cmbTipo.Key = Nothing
        Me.cmbTipo.LabelAsoc = Nothing
        Me.cmbTipo.Location = New System.Drawing.Point(40, 13)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(197, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(6, 16)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 0
        Me.lblTipo.Text = "Tipo"
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = Nothing
        Me.dtpFecha.BindearPropiedadEntidad = Nothing
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFecha
        Me.dtpFecha.Location = New System.Drawing.Point(320, 38)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 14
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(277, 40)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 13
        Me.lblFecha.Text = "&Fecha"
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(8, 42)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 2
        Me.lblCaja.Text = "Caja"
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
        'lblCobradores
        '
        Me.lblCobradores.AutoSize = True
        Me.lblCobradores.LabelAsoc = Nothing
        Me.lblCobradores.Location = New System.Drawing.Point(277, 16)
        Me.lblCobradores.Name = "lblCobradores"
        Me.lblCobradores.Size = New System.Drawing.Size(50, 13)
        Me.lblCobradores.TabIndex = 11
        Me.lblCobradores.Text = "Cobrador"
        '
        'lblTipoRecibo
        '
        Me.lblTipoRecibo.AutoSize = True
        Me.lblTipoRecibo.LabelAsoc = Nothing
        Me.lblTipoRecibo.Location = New System.Drawing.Point(8, 15)
        Me.lblTipoRecibo.Name = "lblTipoRecibo"
        Me.lblTipoRecibo.Size = New System.Drawing.Size(65, 13)
        Me.lblTipoRecibo.TabIndex = 0
        Me.lblTipoRecibo.Text = "Tipo Recibo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbCajas)
        Me.GroupBox1.Controls.Add(Me.cmbTipoRecibo)
        Me.GroupBox1.Controls.Add(Me.lblCaja)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.lblTipoRecibo)
        Me.GroupBox1.Controls.Add(Me.lblCobradores)
        Me.GroupBox1.Controls.Add(Me.cmbCobradores)
        Me.GroupBox1.Location = New System.Drawing.Point(266, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(706, 71)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
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
        Me.cmbCajas.Location = New System.Drawing.Point(79, 38)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(192, 21)
        Me.cmbCajas.TabIndex = 3
        '
        'cmbTipoRecibo
        '
        Me.cmbTipoRecibo.BindearPropiedadControl = ""
        Me.cmbTipoRecibo.BindearPropiedadEntidad = ""
        Me.cmbTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRecibo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoRecibo.FormattingEnabled = True
        Me.cmbTipoRecibo.IsPK = False
        Me.cmbTipoRecibo.IsRequired = False
        Me.cmbTipoRecibo.Key = Nothing
        Me.cmbTipoRecibo.LabelAsoc = Me.lblTipoRecibo
        Me.cmbTipoRecibo.Location = New System.Drawing.Point(79, 11)
        Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
        Me.cmbTipoRecibo.Size = New System.Drawing.Size(192, 21)
        Me.cmbTipoRecibo.TabIndex = 1
        '
        'cmbCobradores
        '
        Me.cmbCobradores.BindearPropiedadControl = ""
        Me.cmbCobradores.BindearPropiedadEntidad = ""
        Me.cmbCobradores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCobradores.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCobradores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCobradores.FormattingEnabled = True
        Me.cmbCobradores.IsPK = False
        Me.cmbCobradores.IsRequired = False
        Me.cmbCobradores.Key = Nothing
        Me.cmbCobradores.LabelAsoc = Me.lblCobradores
        Me.cmbCobradores.Location = New System.Drawing.Point(333, 12)
        Me.cmbCobradores.Name = "cmbCobradores"
        Me.cmbCobradores.Size = New System.Drawing.Size(219, 21)
        Me.cmbCobradores.TabIndex = 12
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tssRegistros})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(969, 17)
        Me.tssInfo.Spring = True
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(0, 17)
        Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImportarChequesElectronicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbCabecera)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ImportarChequesElectronicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importacion de Cheques Electrónicos"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCabecera.ResumeLayout(False)
        Me.grbCabecera.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbLeerArchivo As System.Windows.Forms.ToolStripButton
    Private WithEvents tss4 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGenerarRecibos As System.Windows.Forms.ToolStripButton
    Friend WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbTipo As Eniac.Controles.ComboBox
    Friend WithEvents lblTipo As Eniac.Controles.Label
    Friend WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
    Friend WithEvents lblCaja As Eniac.Controles.Label
    Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFecha As Eniac.Controles.Label
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbCobradores As Eniac.Controles.ComboBox
    Friend WithEvents lblCobradores As Eniac.Controles.Label
    Friend WithEvents cmbTipoRecibo As Eniac.Controles.ComboBox
    Friend WithEvents lblTipoRecibo As Eniac.Controles.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRangoCeldasColumnaHasta As Controles.TextBox
    Friend WithEvents lblRangoCeldas As Controles.Label
    Friend WithEvents txtRangoCeldasFilaDesde As Controles.TextBox
    Friend WithEvents txtRangoCeldasFilaHasta As Controles.TextBox
    Friend WithEvents txtRangoCeldasColumnaDesde As Controles.TextBox
    Friend WithEvents lblSeparadosCeldas As Controles.Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tssInfo As ToolStripStatusLabel
    Friend WithEvents tssRegistros As ToolStripStatusLabel
End Class
