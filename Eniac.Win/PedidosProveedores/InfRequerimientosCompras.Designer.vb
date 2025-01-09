<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InfRequerimientosCompras
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
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.pnlMarcas = New System.Windows.Forms.Panel()
      Me.lblMarcas = New Eniac.Controles.Label()
      Me.cmbMarcas = New Eniac.Win.ComboBoxMarcas()
      Me.pnlModelos = New System.Windows.Forms.Panel()
      Me.cmbModelos = New Eniac.Win.ComboBoxModelos()
      Me.lblModelos = New Eniac.Controles.Label()
      Me.pnlRubros = New System.Windows.Forms.Panel()
      Me.cmbRubros = New Eniac.Win.ComboBoxRubro()
      Me.lblRubros = New Eniac.Controles.Label()
      Me.pnlSubRubros = New System.Windows.Forms.Panel()
      Me.cmbSubRubros = New Eniac.Win.ComboBoxSubRubro()
      Me.lblSubRubros = New Eniac.Controles.Label()
      Me.pnlSubSubRubros = New System.Windows.Forms.Panel()
      Me.cmbSubSubRubros = New Eniac.Win.ComboBoxSubSubRubro()
      Me.lblSubSubRubros = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.lblAsignados = New Eniac.Controles.Label()
      Me.chbIdRequerimiento = New Eniac.Controles.CheckBox()
      Me.txtIdRequerimiento = New Eniac.Controles.TextBox()
      Me.cmbAsignados = New Eniac.Controles.ComboBox()
      Me.chbUsuarioAlta = New Eniac.Controles.CheckBox()
      Me.cmbUsuarioAlta = New Eniac.Controles.ComboBox()
      Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.bscProducto = New Eniac.Controles.Buscador2()
      Me.chkMesCompletoEntrega = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpEntregaHasta = New Eniac.Controles.DateTimePicker()
      Me.lblEntregaHasta = New Eniac.Controles.Label()
      Me.dtpEntregaDesde = New Eniac.Controles.DateTimePicker()
      Me.lblEntregaDesde = New Eniac.Controles.Label()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Win.ButtonConsultar()
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.pnlAcciones = New System.Windows.Forms.Panel()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbConsultar.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMarcas.SuspendLayout()
        Me.pnlModelos.SuspendLayout()
        Me.pnlRubros.SuspendLayout()
        Me.pnlSubRubros.SuspendLayout()
        Me.pnlSubSubRubros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1016, 17)
        Me.tssInfo.Spring = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1095, 22)
        Me.stsStado.TabIndex = 4
        Me.stsStado.Text = "statusStrip1"
        '
        'ugDetalle
        '
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
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
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
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
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
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 204)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1095, 335)
        Me.ugDetalle.TabIndex = 3
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        '
        'grbConsultar
        '
        Me.grbConsultar.AutoSize = True
        Me.grbConsultar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grbConsultar.Controls.Add(Me.FlowLayoutPanel1)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.chbFechaEntrega)
        Me.grbConsultar.Controls.Add(Me.chbFecha)
        Me.grbConsultar.Controls.Add(Me.lblAsignados)
        Me.grbConsultar.Controls.Add(Me.chbIdRequerimiento)
        Me.grbConsultar.Controls.Add(Me.txtIdRequerimiento)
        Me.grbConsultar.Controls.Add(Me.cmbAsignados)
        Me.grbConsultar.Controls.Add(Me.chbUsuarioAlta)
        Me.grbConsultar.Controls.Add(Me.cmbUsuarioAlta)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProducto)
        Me.grbConsultar.Controls.Add(Me.bscProducto)
        Me.grbConsultar.Controls.Add(Me.chbProducto)
        Me.grbConsultar.Controls.Add(Me.chkMesCompletoEntrega)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpEntregaHasta)
        Me.grbConsultar.Controls.Add(Me.dtpEntregaDesde)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.lblEntregaHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblEntregaDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbConsultar.Location = New System.Drawing.Point(0, 29)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Padding = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.grbConsultar.Size = New System.Drawing.Size(1095, 158)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Filtros"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMarcas)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlModelos)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubSubRubros)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 97)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1037, 48)
        Me.FlowLayoutPanel1.TabIndex = 24
        '
        'pnlMarcas
        '
        Me.pnlMarcas.AutoSize = True
        Me.pnlMarcas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlMarcas.Controls.Add(Me.lblMarcas)
        Me.pnlMarcas.Controls.Add(Me.cmbMarcas)
        Me.pnlMarcas.Location = New System.Drawing.Point(3, 0)
        Me.pnlMarcas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlMarcas.Name = "pnlMarcas"
        Me.pnlMarcas.Size = New System.Drawing.Size(248, 21)
        Me.pnlMarcas.TabIndex = 0
        '
        'lblMarcas
        '
        Me.lblMarcas.AutoSize = True
        Me.lblMarcas.LabelAsoc = Nothing
        Me.lblMarcas.Location = New System.Drawing.Point(3, 4)
        Me.lblMarcas.Name = "lblMarcas"
        Me.lblMarcas.Size = New System.Drawing.Size(42, 13)
        Me.lblMarcas.TabIndex = 0
        Me.lblMarcas.Text = "Marcas"
        '
        'cmbMarcas
        '
        Me.cmbMarcas.BindearPropiedadControl = Nothing
        Me.cmbMarcas.BindearPropiedadEntidad = Nothing
        Me.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarcas.FormattingEnabled = True
        Me.cmbMarcas.IsPK = False
        Me.cmbMarcas.IsRequired = False
        Me.cmbMarcas.Key = Nothing
        Me.cmbMarcas.LabelAsoc = Me.lblMarcas
        Me.cmbMarcas.Location = New System.Drawing.Point(48, 0)
        Me.cmbMarcas.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbMarcas.Name = "cmbMarcas"
        Me.cmbMarcas.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarcas.TabIndex = 1
        '
        'pnlModelos
        '
        Me.pnlModelos.AutoSize = True
        Me.pnlModelos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlModelos.Controls.Add(Me.cmbModelos)
        Me.pnlModelos.Controls.Add(Me.lblModelos)
        Me.pnlModelos.Location = New System.Drawing.Point(257, 0)
        Me.pnlModelos.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlModelos.Name = "pnlModelos"
        Me.pnlModelos.Size = New System.Drawing.Size(253, 21)
        Me.pnlModelos.TabIndex = 1
        '
        'cmbModelos
        '
        Me.cmbModelos.BindearPropiedadControl = Nothing
        Me.cmbModelos.BindearPropiedadEntidad = Nothing
        Me.cmbModelos.ConcatenarNombreMarca = False
        Me.cmbModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModelos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModelos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModelos.FormattingEnabled = True
        Me.cmbModelos.IsPK = False
        Me.cmbModelos.IsRequired = False
        Me.cmbModelos.Key = Nothing
        Me.cmbModelos.LabelAsoc = Me.lblModelos
        Me.cmbModelos.Location = New System.Drawing.Point(53, 0)
        Me.cmbModelos.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbModelos.Name = "cmbModelos"
        Me.cmbModelos.Size = New System.Drawing.Size(200, 21)
        Me.cmbModelos.TabIndex = 1
        '
        'lblModelos
        '
        Me.lblModelos.AutoSize = True
        Me.lblModelos.LabelAsoc = Nothing
        Me.lblModelos.Location = New System.Drawing.Point(3, 4)
        Me.lblModelos.Name = "lblModelos"
        Me.lblModelos.Size = New System.Drawing.Size(47, 13)
        Me.lblModelos.TabIndex = 0
        Me.lblModelos.Text = "Modelos"
        '
        'pnlRubros
        '
        Me.pnlRubros.AutoSize = True
        Me.pnlRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlRubros.Controls.Add(Me.cmbRubros)
        Me.pnlRubros.Controls.Add(Me.lblRubros)
        Me.pnlRubros.Location = New System.Drawing.Point(516, 0)
        Me.pnlRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlRubros.Name = "pnlRubros"
        Me.pnlRubros.Size = New System.Drawing.Size(247, 21)
        Me.pnlRubros.TabIndex = 2
        '
        'cmbRubros
        '
        Me.cmbRubros.BindearPropiedadControl = Nothing
        Me.cmbRubros.BindearPropiedadEntidad = Nothing
        Me.cmbRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubros.FormattingEnabled = True
        Me.cmbRubros.IsPK = False
        Me.cmbRubros.IsRequired = False
        Me.cmbRubros.Key = Nothing
        Me.cmbRubros.LabelAsoc = Me.lblRubros
        Me.cmbRubros.Location = New System.Drawing.Point(47, 0)
        Me.cmbRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbRubros.Name = "cmbRubros"
        Me.cmbRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbRubros.TabIndex = 1
        '
        'lblRubros
        '
        Me.lblRubros.AutoSize = True
        Me.lblRubros.LabelAsoc = Nothing
        Me.lblRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblRubros.Name = "lblRubros"
        Me.lblRubros.Size = New System.Drawing.Size(41, 13)
        Me.lblRubros.TabIndex = 0
        Me.lblRubros.Text = "Rubros"
        '
        'pnlSubRubros
        '
        Me.pnlSubRubros.AutoSize = True
        Me.pnlSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSubRubros.Controls.Add(Me.cmbSubRubros)
        Me.pnlSubRubros.Controls.Add(Me.lblSubRubros)
        Me.pnlSubRubros.Location = New System.Drawing.Point(769, 0)
        Me.pnlSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubRubros.Name = "pnlSubRubros"
        Me.pnlSubRubros.Size = New System.Drawing.Size(265, 21)
        Me.pnlSubRubros.TabIndex = 3
        '
        'cmbSubRubros
        '
        Me.cmbSubRubros.BindearPropiedadControl = Nothing
        Me.cmbSubRubros.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubros.ConcatenarNombreRubro = False
        Me.cmbSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubros.FormattingEnabled = True
        Me.cmbSubRubros.IsPK = False
        Me.cmbSubRubros.IsRequired = False
        Me.cmbSubRubros.Key = Nothing
        Me.cmbSubRubros.LabelAsoc = Me.lblSubRubros
        Me.cmbSubRubros.Location = New System.Drawing.Point(65, 0)
        Me.cmbSubRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSubRubros.Name = "cmbSubRubros"
        Me.cmbSubRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubRubros.TabIndex = 1
        '
        'lblSubRubros
        '
        Me.lblSubRubros.AutoSize = True
        Me.lblSubRubros.LabelAsoc = Nothing
        Me.lblSubRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblSubRubros.Name = "lblSubRubros"
        Me.lblSubRubros.Size = New System.Drawing.Size(60, 13)
        Me.lblSubRubros.TabIndex = 0
        Me.lblSubRubros.Text = "SubRubros"
        '
        'pnlSubSubRubros
        '
        Me.pnlSubSubRubros.AutoSize = True
        Me.pnlSubSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSubSubRubros.Controls.Add(Me.cmbSubSubRubros)
        Me.pnlSubSubRubros.Controls.Add(Me.lblSubSubRubros)
        Me.pnlSubSubRubros.Location = New System.Drawing.Point(3, 24)
        Me.pnlSubSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubSubRubros.Name = "pnlSubSubRubros"
        Me.pnlSubSubRubros.Size = New System.Drawing.Size(281, 21)
        Me.pnlSubSubRubros.TabIndex = 4
        '
        'cmbSubSubRubros
        '
        Me.cmbSubSubRubros.BindearPropiedadControl = Nothing
        Me.cmbSubSubRubros.BindearPropiedadEntidad = Nothing
        Me.cmbSubSubRubros.ConcatenarNombreSubRubro = False
        Me.cmbSubSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubSubRubros.FormattingEnabled = True
        Me.cmbSubSubRubros.IsPK = False
        Me.cmbSubSubRubros.IsRequired = False
        Me.cmbSubSubRubros.Key = Nothing
        Me.cmbSubSubRubros.LabelAsoc = Me.lblSubSubRubros
        Me.cmbSubSubRubros.Location = New System.Drawing.Point(81, 0)
        Me.cmbSubSubRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSubSubRubros.Name = "cmbSubSubRubros"
        Me.cmbSubSubRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubSubRubros.TabIndex = 1
        '
        'lblSubSubRubros
        '
        Me.lblSubSubRubros.AutoSize = True
        Me.lblSubSubRubros.LabelAsoc = Nothing
        Me.lblSubSubRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblSubSubRubros.Name = "lblSubSubRubros"
        Me.lblSubSubRubros.Size = New System.Drawing.Size(79, 13)
        Me.lblSubSubRubros.TabIndex = 0
        Me.lblSubSubRubros.Text = "SubSubRubros"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(691, 15)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(140, 21)
        Me.cmbTiposComprobantes.TabIndex = 13
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(576, 19)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(109, 13)
        Me.lblTipoComprobante.TabIndex = 12
        Me.lblTipoComprobante.Text = "Tipo Comprobrobante"
        '
        'chbFechaEntrega
        '
        Me.chbFechaEntrega.AutoSize = True
        Me.chbFechaEntrega.BindearPropiedadControl = Nothing
        Me.chbFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.chbFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEntrega.IsPK = False
        Me.chbFechaEntrega.IsRequired = False
        Me.chbFechaEntrega.Key = Nothing
        Me.chbFechaEntrega.LabelAsoc = Nothing
        Me.chbFechaEntrega.Location = New System.Drawing.Point(10, 43)
        Me.chbFechaEntrega.Name = "chbFechaEntrega"
        Me.chbFechaEntrega.Size = New System.Drawing.Size(93, 17)
        Me.chbFechaEntrega.TabIndex = 6
        Me.chbFechaEntrega.Text = "FechaEntrega"
        Me.chbFechaEntrega.UseVisualStyleBackColor = True
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
        Me.chbFecha.Location = New System.Drawing.Point(10, 17)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 0
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'lblAsignados
        '
        Me.lblAsignados.AutoSize = True
        Me.lblAsignados.LabelAsoc = Nothing
        Me.lblAsignados.Location = New System.Drawing.Point(629, 45)
        Me.lblAsignados.Name = "lblAsignados"
        Me.lblAsignados.Size = New System.Drawing.Size(56, 13)
        Me.lblAsignados.TabIndex = 16
        Me.lblAsignados.Text = "Asignados"
        '
        'chbIdRequerimiento
        '
        Me.chbIdRequerimiento.AutoSize = True
        Me.chbIdRequerimiento.BindearPropiedadControl = Nothing
        Me.chbIdRequerimiento.BindearPropiedadEntidad = Nothing
        Me.chbIdRequerimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIdRequerimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIdRequerimiento.IsPK = False
        Me.chbIdRequerimiento.IsRequired = False
        Me.chbIdRequerimiento.Key = Nothing
        Me.chbIdRequerimiento.LabelAsoc = Nothing
        Me.chbIdRequerimiento.Location = New System.Drawing.Point(845, 17)
        Me.chbIdRequerimiento.Name = "chbIdRequerimiento"
        Me.chbIdRequerimiento.Size = New System.Drawing.Size(63, 17)
        Me.chbIdRequerimiento.TabIndex = 14
        Me.chbIdRequerimiento.Text = "Número"
        Me.chbIdRequerimiento.UseVisualStyleBackColor = True
        '
        'txtIdRequerimiento
        '
        Me.txtIdRequerimiento.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdRequerimiento.BindearPropiedadControl = Nothing
        Me.txtIdRequerimiento.BindearPropiedadEntidad = Nothing
        Me.txtIdRequerimiento.Enabled = False
        Me.txtIdRequerimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdRequerimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdRequerimiento.Formato = ""
        Me.txtIdRequerimiento.IsDecimal = False
        Me.txtIdRequerimiento.IsNumber = True
        Me.txtIdRequerimiento.IsPK = False
        Me.txtIdRequerimiento.IsRequired = False
        Me.txtIdRequerimiento.Key = ""
        Me.txtIdRequerimiento.LabelAsoc = Nothing
        Me.txtIdRequerimiento.Location = New System.Drawing.Point(912, 15)
        Me.txtIdRequerimiento.MaxLength = 8
        Me.txtIdRequerimiento.Name = "txtIdRequerimiento"
        Me.txtIdRequerimiento.Size = New System.Drawing.Size(65, 20)
        Me.txtIdRequerimiento.TabIndex = 15
        Me.txtIdRequerimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbAsignados
        '
        Me.cmbAsignados.BindearPropiedadControl = ""
        Me.cmbAsignados.BindearPropiedadEntidad = ""
        Me.cmbAsignados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAsignados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAsignados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAsignados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAsignados.FormattingEnabled = True
        Me.cmbAsignados.IsPK = False
        Me.cmbAsignados.IsRequired = False
        Me.cmbAsignados.Key = Nothing
        Me.cmbAsignados.LabelAsoc = Me.lblAsignados
        Me.cmbAsignados.Location = New System.Drawing.Point(691, 41)
        Me.cmbAsignados.Name = "cmbAsignados"
        Me.cmbAsignados.Size = New System.Drawing.Size(140, 21)
        Me.cmbAsignados.TabIndex = 17
        '
        'chbUsuarioAlta
        '
        Me.chbUsuarioAlta.AutoSize = True
        Me.chbUsuarioAlta.BindearPropiedadControl = Nothing
        Me.chbUsuarioAlta.BindearPropiedadEntidad = Nothing
        Me.chbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuarioAlta.IsPK = False
        Me.chbUsuarioAlta.IsRequired = False
        Me.chbUsuarioAlta.Key = Nothing
        Me.chbUsuarioAlta.LabelAsoc = Nothing
        Me.chbUsuarioAlta.Location = New System.Drawing.Point(845, 43)
        Me.chbUsuarioAlta.Name = "chbUsuarioAlta"
        Me.chbUsuarioAlta.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuarioAlta.TabIndex = 18
        Me.chbUsuarioAlta.Text = "Usuario"
        Me.chbUsuarioAlta.UseVisualStyleBackColor = True
        '
        'cmbUsuarioAlta
        '
        Me.cmbUsuarioAlta.BindearPropiedadControl = Nothing
        Me.cmbUsuarioAlta.BindearPropiedadEntidad = Nothing
        Me.cmbUsuarioAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarioAlta.Enabled = False
        Me.cmbUsuarioAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuarioAlta.FormattingEnabled = True
        Me.cmbUsuarioAlta.IsPK = False
        Me.cmbUsuarioAlta.IsRequired = False
        Me.cmbUsuarioAlta.Key = Nothing
        Me.cmbUsuarioAlta.LabelAsoc = Nothing
        Me.cmbUsuarioAlta.Location = New System.Drawing.Point(912, 41)
        Me.cmbUsuarioAlta.Name = "cmbUsuarioAlta"
        Me.cmbUsuarioAlta.Size = New System.Drawing.Size(140, 21)
        Me.cmbUsuarioAlta.TabIndex = 19
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Me.chbProducto
        Me.bscCodigoProducto.Location = New System.Drawing.Point(85, 68)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = False
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProducto.TabIndex = 21
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(10, 71)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 20
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'bscProducto
        '
        Me.bscProducto.ActivarFiltroEnGrilla = True
        Me.bscProducto.AutoSize = True
        Me.bscProducto.BindearPropiedadControl = Nothing
        Me.bscProducto.BindearPropiedadEntidad = Nothing
        Me.bscProducto.ConfigBuscador = Nothing
        Me.bscProducto.Datos = Nothing
        Me.bscProducto.FilaDevuelta = Nothing
        Me.bscProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto.IsDecimal = False
        Me.bscProducto.IsNumber = False
        Me.bscProducto.IsPK = False
        Me.bscProducto.IsRequired = False
        Me.bscProducto.Key = ""
        Me.bscProducto.LabelAsoc = Me.chbProducto
        Me.bscProducto.Location = New System.Drawing.Point(182, 68)
        Me.bscProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProducto.MaxLengh = "32767"
        Me.bscProducto.Name = "bscProducto"
        Me.bscProducto.Permitido = False
        Me.bscProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto.Selecciono = False
        Me.bscProducto.Size = New System.Drawing.Size(300, 23)
        Me.bscProducto.TabIndex = 22
        '
        'chkMesCompletoEntrega
        '
        Me.chkMesCompletoEntrega.AutoSize = True
        Me.chkMesCompletoEntrega.BindearPropiedadControl = Nothing
        Me.chkMesCompletoEntrega.BindearPropiedadEntidad = Nothing
        Me.chkMesCompletoEntrega.Enabled = False
        Me.chkMesCompletoEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompletoEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompletoEntrega.IsPK = False
        Me.chkMesCompletoEntrega.IsRequired = False
        Me.chkMesCompletoEntrega.Key = Nothing
        Me.chkMesCompletoEntrega.LabelAsoc = Nothing
        Me.chkMesCompletoEntrega.Location = New System.Drawing.Point(109, 43)
        Me.chkMesCompletoEntrega.Name = "chkMesCompletoEntrega"
        Me.chkMesCompletoEntrega.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompletoEntrega.TabIndex = 7
        Me.chkMesCompletoEntrega.Text = "Mes Completo"
        Me.chkMesCompletoEntrega.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(109, 17)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 1
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpEntregaHasta
        '
        Me.dtpEntregaHasta.BindearPropiedadControl = Nothing
        Me.dtpEntregaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpEntregaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpEntregaHasta.Enabled = False
        Me.dtpEntregaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpEntregaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpEntregaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEntregaHasta.IsPK = False
        Me.dtpEntregaHasta.IsRequired = False
        Me.dtpEntregaHasta.Key = ""
        Me.dtpEntregaHasta.LabelAsoc = Me.lblEntregaHasta
        Me.dtpEntregaHasta.Location = New System.Drawing.Point(430, 41)
        Me.dtpEntregaHasta.Name = "dtpEntregaHasta"
        Me.dtpEntregaHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpEntregaHasta.TabIndex = 11
        '
        'lblEntregaHasta
        '
        Me.lblEntregaHasta.AutoSize = True
        Me.lblEntregaHasta.LabelAsoc = Nothing
        Me.lblEntregaHasta.Location = New System.Drawing.Point(389, 45)
        Me.lblEntregaHasta.Name = "lblEntregaHasta"
        Me.lblEntregaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblEntregaHasta.TabIndex = 10
        Me.lblEntregaHasta.Text = "Hasta"
        '
        'dtpEntregaDesde
        '
        Me.dtpEntregaDesde.BindearPropiedadControl = Nothing
        Me.dtpEntregaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpEntregaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpEntregaDesde.Enabled = False
        Me.dtpEntregaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpEntregaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEntregaDesde.IsPK = False
        Me.dtpEntregaDesde.IsRequired = False
        Me.dtpEntregaDesde.Key = ""
        Me.dtpEntregaDesde.LabelAsoc = Me.lblEntregaDesde
        Me.dtpEntregaDesde.Location = New System.Drawing.Point(252, 41)
        Me.dtpEntregaDesde.Name = "dtpEntregaDesde"
        Me.dtpEntregaDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpEntregaDesde.TabIndex = 9
        '
        'lblEntregaDesde
        '
        Me.lblEntregaDesde.AutoSize = True
        Me.lblEntregaDesde.LabelAsoc = Nothing
        Me.lblEntregaDesde.Location = New System.Drawing.Point(208, 45)
        Me.lblEntregaDesde.Name = "lblEntregaDesde"
        Me.lblEntregaDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblEntregaDesde.TabIndex = 8
        Me.lblEntregaDesde.Text = "Desde"
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(430, 15)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(389, 19)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(252, 15)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 3
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(208, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 2
        Me.lblDesde.Text = "Desde"
        '
        'btnConsultar
        '
        Me.btnConsultar.AnchoredControl = Me.ugDetalle
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(985, 208)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(104, 30)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.tsbSalir, Me.ToolStripSeparator4})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1095, 29)
        Me.tstBarra.TabIndex = 5
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(75, 26)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.chkExpandAll)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 187)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1095, 17)
        Me.pnlAcciones.TabIndex = 1
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(985, 0)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 0
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'InfRequerimientosCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 561)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.KeyPreview = True
        Me.Name = "InfRequerimientosCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Requerimientos de Compra"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.pnlMarcas.ResumeLayout(False)
        Me.pnlMarcas.PerformLayout()
        Me.pnlModelos.ResumeLayout(False)
        Me.pnlModelos.PerformLayout()
        Me.pnlRubros.ResumeLayout(False)
        Me.pnlRubros.PerformLayout()
        Me.pnlSubRubros.ResumeLayout(False)
        Me.pnlSubRubros.PerformLayout()
        Me.pnlSubSubRubros.ResumeLayout(False)
        Me.pnlSubSubRubros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Friend WithEvents ugDetalle As UltraGridSiga
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
    Friend WithEvents chbFecha As Eniac.Controles.CheckBox
    Friend WithEvents chbIdRequerimiento As Eniac.Controles.CheckBox
    Friend WithEvents txtIdRequerimiento As Eniac.Controles.TextBox
    Friend WithEvents chbUsuarioAlta As Eniac.Controles.CheckBox
    Friend WithEvents cmbUsuarioAlta As Eniac.Controles.ComboBox
    Friend WithEvents btnConsultar As ButtonConsultar
    Friend WithEvents bscCodigoProducto As Eniac.Controles.Buscador2
    Friend WithEvents bscProducto As Eniac.Controles.Buscador2
    Friend WithEvents chbProducto As Eniac.Controles.CheckBox
    Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblHasta As Eniac.Controles.Label
    Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
    Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
    Public WithEvents tsbPreferencias As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents chbFechaEntrega As Controles.CheckBox
    Friend WithEvents lblAsignados As Controles.Label
    Friend WithEvents cmbAsignados As Controles.ComboBox
    Friend WithEvents chkMesCompletoEntrega As Controles.CheckBox
    Friend WithEvents dtpEntregaHasta As Controles.DateTimePicker
    Friend WithEvents lblEntregaHasta As Controles.Label
    Friend WithEvents dtpEntregaDesde As Controles.DateTimePicker
    Friend WithEvents lblEntregaDesde As Controles.Label
    Friend WithEvents pnlMarcas As Panel
    Friend WithEvents lblMarcas As Controles.Label
    Friend WithEvents cmbMarcas As ComboBoxMarcas
    Friend WithEvents pnlModelos As Panel
    Friend WithEvents cmbModelos As ComboBoxModelos
    Friend WithEvents lblModelos As Controles.Label
    Friend WithEvents pnlRubros As Panel
    Friend WithEvents cmbRubros As ComboBoxRubro
    Friend WithEvents lblRubros As Controles.Label
    Friend WithEvents pnlSubRubros As Panel
    Friend WithEvents cmbSubRubros As ComboBoxSubRubro
    Friend WithEvents lblSubRubros As Controles.Label
    Friend WithEvents pnlSubSubRubros As Panel
    Friend WithEvents cmbSubSubRubros As ComboBoxSubSubRubro
    Friend WithEvents lblSubSubRubros As Controles.Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents chkExpandAll As CheckBox
End Class
