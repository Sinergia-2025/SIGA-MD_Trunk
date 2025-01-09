<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContabilidadGeneraAsientoRefundicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadGeneraAsientoRefundicion))
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
        Me.tspBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiExportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbcGeneral = New System.Windows.Forms.TabControl()
        Me.tbpPeriodos = New System.Windows.Forms.TabPage()
        Me.ugAsientoRef = New Eniac.Win.UltraGridSiga()
        Me.grpFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbEjercicio = New Eniac.Controles.ComboBox()
        Me.lblEjercicio = New Eniac.Controles.Label()
        Me.Label3 = New Eniac.Controles.Label()
        Me.clbSucursales = New Eniac.Controles.CheckedListBox()
        Me.cmbPlan = New Eniac.Controles.ComboBox()
        Me.lblPlan = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCentroCosto = New Eniac.Controles.ComboBox()
        Me.lblCentroCosto = New Eniac.Controles.Label()
        Me.lblMonto = New Eniac.Controles.Label()
        Me.txtConcepto = New Eniac.Controles.TextBox()
        Me.lbloncept = New Eniac.Controles.Label()
        Me.lblDesc = New Eniac.Controles.Label()
        Me.bscDescripcion = New Eniac.Controles.Buscador()
        Me.bscCodCuenta = New Eniac.Controles.Buscador()
        Me.lblCta = New Eniac.Controles.Label()
        Me.btnGenerarAsiento = New Eniac.Controles.Button()
        Me.dtpFecha = New Eniac.Controles.DateTimePicker()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.tspBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tbcGeneral.SuspendLayout()
        Me.tbpPeriodos.SuspendLayout()
        CType(Me.ugAsientoRef, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tspBarra
        '
        Me.tspBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tspBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsddExportar, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tspBarra.Location = New System.Drawing.Point(0, 0)
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(987, 29)
        Me.tspBarra.TabIndex = 5
        Me.tspBarra.Text = "ToolStrip1"
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
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiExportarExcel})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiExportarExcel
        '
        Me.tsmiExportarExcel.Image = CType(resources.GetObject("tsmiExportarExcel.Image"), System.Drawing.Image)
        Me.tsmiExportarExcel.Name = "tsmiExportarExcel"
        Me.tsmiExportarExcel.Size = New System.Drawing.Size(186, 28)
        Me.tsmiExportarExcel.Text = "a Excel"
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'stsStado
        '
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.ToolStripProgressBar1, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 546)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(987, 22)
        Me.stsStado.TabIndex = 6
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(908, 17)
        Me.tssInfo.Spring = True
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ToolStripProgressBar1.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'tbcGeneral
        '
        Me.tbcGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcGeneral.Controls.Add(Me.tbpPeriodos)
        Me.tbcGeneral.Location = New System.Drawing.Point(0, 93)
        Me.tbcGeneral.Name = "tbcGeneral"
        Me.tbcGeneral.SelectedIndex = 0
        Me.tbcGeneral.Size = New System.Drawing.Size(988, 375)
        Me.tbcGeneral.TabIndex = 82
        '
        'tbpPeriodos
        '
        Me.tbpPeriodos.Controls.Add(Me.ugAsientoRef)
        Me.tbpPeriodos.Location = New System.Drawing.Point(4, 22)
        Me.tbpPeriodos.Name = "tbpPeriodos"
        Me.tbpPeriodos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPeriodos.Size = New System.Drawing.Size(980, 349)
        Me.tbpPeriodos.TabIndex = 0
        Me.tbpPeriodos.Text = "Asiento de Refundición"
        Me.tbpPeriodos.UseVisualStyleBackColor = True
        '
        'ugAsientoRef
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugAsientoRef.DisplayLayout.Appearance = Appearance1
        Me.ugAsientoRef.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAsientoRef.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAsientoRef.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAsientoRef.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugAsientoRef.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAsientoRef.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAsientoRef.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugAsientoRef.DisplayLayout.MaxBandDepth = 1
        Me.ugAsientoRef.DisplayLayout.MaxColScrollRegions = 1
        Me.ugAsientoRef.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugAsientoRef.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugAsientoRef.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugAsientoRef.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugAsientoRef.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugAsientoRef.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAsientoRef.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAsientoRef.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugAsientoRef.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugAsientoRef.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugAsientoRef.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugAsientoRef.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugAsientoRef.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAsientoRef.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugAsientoRef.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugAsientoRef.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugAsientoRef.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugAsientoRef.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugAsientoRef.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugAsientoRef.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugAsientoRef.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAsientoRef.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugAsientoRef.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugAsientoRef.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugAsientoRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugAsientoRef.ExitEditModeOnLeave = False
        Me.ugAsientoRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugAsientoRef.Location = New System.Drawing.Point(3, 3)
        Me.ugAsientoRef.Name = "ugAsientoRef"
        Me.ugAsientoRef.Size = New System.Drawing.Size(974, 343)
        Me.ugAsientoRef.TabIndex = 0
        Me.ugAsientoRef.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugAsientoRef.ToolStripMenuExpandir = Nothing
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.cmbEjercicio)
        Me.grpFiltros.Controls.Add(Me.lblEjercicio)
        Me.grpFiltros.Controls.Add(Me.Label3)
        Me.grpFiltros.Controls.Add(Me.clbSucursales)
        Me.grpFiltros.Controls.Add(Me.cmbPlan)
        Me.grpFiltros.Controls.Add(Me.lblPlan)
        Me.grpFiltros.Controls.Add(Me.btnConsultar)
        Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(987, 62)
        Me.grpFiltros.TabIndex = 81
        Me.grpFiltros.TabStop = False
        Me.grpFiltros.Text = "Filtros"
        '
        'cmbEjercicio
        '
        Me.cmbEjercicio.BindearPropiedadControl = "SelectedValue"
        Me.cmbEjercicio.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEjercicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEjercicio.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEjercicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEjercicio.FormattingEnabled = True
        Me.cmbEjercicio.IsPK = False
        Me.cmbEjercicio.IsRequired = True
        Me.cmbEjercicio.Key = Nothing
        Me.cmbEjercicio.LabelAsoc = Me.lblEjercicio
        Me.cmbEjercicio.Location = New System.Drawing.Point(319, 14)
        Me.cmbEjercicio.Name = "cmbEjercicio"
        Me.cmbEjercicio.Size = New System.Drawing.Size(255, 21)
        Me.cmbEjercicio.TabIndex = 79
        '
        'lblEjercicio
        '
        Me.lblEjercicio.AutoSize = True
        Me.lblEjercicio.LabelAsoc = Nothing
        Me.lblEjercicio.Location = New System.Drawing.Point(266, 22)
        Me.lblEjercicio.Name = "lblEjercicio"
        Me.lblEjercicio.Size = New System.Drawing.Size(47, 13)
        Me.lblEjercicio.TabIndex = 78
        Me.lblEjercicio.Text = "Ejercicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(580, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Sucursales"
        '
        'clbSucursales
        '
        Me.clbSucursales.CheckOnClick = True
        Me.clbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.clbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.clbSucursales.FormattingEnabled = True
        Me.clbSucursales.HorizontalExtent = 2
        Me.clbSucursales.HorizontalScrollbar = True
        Me.clbSucursales.IsPK = False
        Me.clbSucursales.IsRequired = False
        Me.clbSucursales.Key = Nothing
        Me.clbSucursales.LabelAsoc = Nothing
        Me.clbSucursales.Location = New System.Drawing.Point(645, 9)
        Me.clbSucursales.Name = "clbSucursales"
        Me.clbSucursales.Size = New System.Drawing.Size(165, 49)
        Me.clbSucursales.TabIndex = 28
        '
        'cmbPlan
        '
        Me.cmbPlan.BindearPropiedadControl = "SelectedValue"
        Me.cmbPlan.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlan.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPlan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPlan.FormattingEnabled = True
        Me.cmbPlan.IsPK = False
        Me.cmbPlan.IsRequired = True
        Me.cmbPlan.Key = Nothing
        Me.cmbPlan.LabelAsoc = Me.lblPlan
        Me.cmbPlan.Location = New System.Drawing.Point(99, 17)
        Me.cmbPlan.Name = "cmbPlan"
        Me.cmbPlan.Size = New System.Drawing.Size(159, 21)
        Me.cmbPlan.TabIndex = 26
        '
        'lblPlan
        '
        Me.lblPlan.AutoSize = True
        Me.lblPlan.LabelAsoc = Nothing
        Me.lblPlan.Location = New System.Drawing.Point(11, 22)
        Me.lblPlan.Name = "lblPlan"
        Me.lblPlan.Size = New System.Drawing.Size(80, 13)
        Me.lblPlan.TabIndex = 25
        Me.lblPlan.Text = "Plan de Cuenta"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnConsultar.Location = New System.Drawing.Point(831, 16)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 32)
        Me.btnConsultar.TabIndex = 24
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbCentroCosto)
        Me.GroupBox1.Controls.Add(Me.lblCentroCosto)
        Me.GroupBox1.Controls.Add(Me.lblMonto)
        Me.GroupBox1.Controls.Add(Me.txtConcepto)
        Me.GroupBox1.Controls.Add(Me.lbloncept)
        Me.GroupBox1.Controls.Add(Me.lblDesc)
        Me.GroupBox1.Controls.Add(Me.bscDescripcion)
        Me.GroupBox1.Controls.Add(Me.bscCodCuenta)
        Me.GroupBox1.Controls.Add(Me.lblCta)
        Me.GroupBox1.Controls.Add(Me.btnGenerarAsiento)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 468)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(983, 74)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generación..."
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.BindearPropiedadControl = Nothing
        Me.cmbCentroCosto.BindearPropiedadEntidad = Nothing
        Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.IsPK = False
        Me.cmbCentroCosto.IsRequired = False
        Me.cmbCentroCosto.Key = Nothing
        Me.cmbCentroCosto.LabelAsoc = Me.lblCentroCosto
        Me.cmbCentroCosto.Location = New System.Drawing.Point(512, 9)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(143, 21)
        Me.cmbCentroCosto.TabIndex = 81
        Me.cmbCentroCosto.Visible = False
        '
        'lblCentroCosto
        '
        Me.lblCentroCosto.AutoSize = True
        Me.lblCentroCosto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCentroCosto.LabelAsoc = Nothing
        Me.lblCentroCosto.Location = New System.Drawing.Point(422, 13)
        Me.lblCentroCosto.Name = "lblCentroCosto"
        Me.lblCentroCosto.Size = New System.Drawing.Size(88, 13)
        Me.lblCentroCosto.TabIndex = 80
        Me.lblCentroCosto.Text = "Centro de Costos"
        Me.lblCentroCosto.Visible = False
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.LabelAsoc = Nothing
        Me.lblMonto.Location = New System.Drawing.Point(733, 14)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(37, 13)
        Me.lblMonto.TabIndex = 87
        Me.lblMonto.Text = "Monto"
        '
        'txtConcepto
        '
        Me.txtConcepto.BindearPropiedadControl = "Text"
        Me.txtConcepto.BindearPropiedadEntidad = "NombreAsiento"
        Me.txtConcepto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtConcepto.Formato = ""
        Me.txtConcepto.IsDecimal = False
        Me.txtConcepto.IsNumber = False
        Me.txtConcepto.IsPK = False
        Me.txtConcepto.IsRequired = True
        Me.txtConcepto.Key = ""
        Me.txtConcepto.LabelAsoc = Me.lbloncept
        Me.txtConcepto.Location = New System.Drawing.Point(512, 36)
        Me.txtConcepto.MaxLength = 100
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(344, 20)
        Me.txtConcepto.TabIndex = 86
        '
        'lbloncept
        '
        Me.lbloncept.AutoSize = True
        Me.lbloncept.LabelAsoc = Nothing
        Me.lbloncept.Location = New System.Drawing.Point(458, 39)
        Me.lbloncept.Name = "lbloncept"
        Me.lbloncept.Size = New System.Drawing.Size(53, 13)
        Me.lbloncept.TabIndex = 85
        Me.lbloncept.Text = "Concepto"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.LabelAsoc = Nothing
        Me.lblDesc.Location = New System.Drawing.Point(110, 39)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(63, 13)
        Me.lblDesc.TabIndex = 83
        Me.lblDesc.Text = "Descripción"
        '
        'bscDescripcion
        '
        Me.bscDescripcion.AyudaAncho = 608
        Me.bscDescripcion.BindearPropiedadControl = Nothing
        Me.bscDescripcion.BindearPropiedadEntidad = Nothing
        Me.bscDescripcion.ColumnasAlineacion = Nothing
        Me.bscDescripcion.ColumnasAncho = Nothing
        Me.bscDescripcion.ColumnasFormato = Nothing
        Me.bscDescripcion.ColumnasOcultas = Nothing
        Me.bscDescripcion.ColumnasTitulos = Nothing
        Me.bscDescripcion.Datos = Nothing
        Me.bscDescripcion.FilaDevuelta = Nothing
        Me.bscDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDescripcion.IsDecimal = False
        Me.bscDescripcion.IsNumber = False
        Me.bscDescripcion.IsPK = False
        Me.bscDescripcion.IsRequired = False
        Me.bscDescripcion.Key = ""
        Me.bscDescripcion.LabelAsoc = Me.lblDesc
        Me.bscDescripcion.Location = New System.Drawing.Point(183, 37)
        Me.bscDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.bscDescripcion.MaxLengh = "32767"
        Me.bscDescripcion.Name = "bscDescripcion"
        Me.bscDescripcion.Permitido = True
        Me.bscDescripcion.Selecciono = False
        Me.bscDescripcion.Size = New System.Drawing.Size(275, 20)
        Me.bscDescripcion.TabIndex = 84
        Me.bscDescripcion.Titulo = Nothing
        '
        'bscCodCuenta
        '
        Me.bscCodCuenta.AyudaAncho = 608
        Me.bscCodCuenta.BindearPropiedadControl = Nothing
        Me.bscCodCuenta.BindearPropiedadEntidad = Nothing
        Me.bscCodCuenta.ColumnasAlineacion = Nothing
        Me.bscCodCuenta.ColumnasAncho = Nothing
        Me.bscCodCuenta.ColumnasFormato = Nothing
        Me.bscCodCuenta.ColumnasOcultas = Nothing
        Me.bscCodCuenta.ColumnasTitulos = Nothing
        Me.bscCodCuenta.Datos = Nothing
        Me.bscCodCuenta.FilaDevuelta = Nothing
        Me.bscCodCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodCuenta.IsDecimal = False
        Me.bscCodCuenta.IsNumber = True
        Me.bscCodCuenta.IsPK = False
        Me.bscCodCuenta.IsRequired = False
        Me.bscCodCuenta.Key = ""
        Me.bscCodCuenta.LabelAsoc = Me.lblCta
        Me.bscCodCuenta.Location = New System.Drawing.Point(184, 10)
        Me.bscCodCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodCuenta.MaxLengh = "32767"
        Me.bscCodCuenta.Name = "bscCodCuenta"
        Me.bscCodCuenta.Permitido = True
        Me.bscCodCuenta.Selecciono = False
        Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
        Me.bscCodCuenta.TabIndex = 82
        Me.bscCodCuenta.Titulo = Nothing
        '
        'lblCta
        '
        Me.lblCta.AutoSize = True
        Me.lblCta.LabelAsoc = Nothing
        Me.lblCta.Location = New System.Drawing.Point(110, 12)
        Me.lblCta.Name = "lblCta"
        Me.lblCta.Size = New System.Drawing.Size(40, 13)
        Me.lblCta.TabIndex = 81
        Me.lblCta.Text = "Código"
        '
        'btnGenerarAsiento
        '
        Me.btnGenerarAsiento.Enabled = False
        Me.btnGenerarAsiento.Image = Global.Eniac.Win.My.Resources.Resources.play_24
        Me.btnGenerarAsiento.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnGenerarAsiento.Location = New System.Drawing.Point(861, 13)
        Me.btnGenerarAsiento.Name = "btnGenerarAsiento"
        Me.btnGenerarAsiento.Size = New System.Drawing.Size(110, 32)
        Me.btnGenerarAsiento.TabIndex = 80
        Me.btnGenerarAsiento.Text = "&Generar"
        Me.btnGenerarAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerarAsiento.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = "Value"
        Me.dtpFecha.BindearPropiedadEntidad = "FechaAsiento"
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFecha
        Me.dtpFecha.Location = New System.Drawing.Point(10, 31)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 7
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(10, 14)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 6
        Me.lblFecha.Text = "Fecha"
        '
        'ContabilidadGeneraAsientoRefundicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 568)
        Me.Controls.Add(Me.tbcGeneral)
        Me.Controls.Add(Me.grpFiltros)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tspBarra)
        Me.Name = "ContabilidadGeneraAsientoRefundicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Genera Asiento Refundición de Resultados"
        Me.tspBarra.ResumeLayout(False)
        Me.tspBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tbcGeneral.ResumeLayout(False)
        Me.tbpPeriodos.ResumeLayout(False)
        CType(Me.ugAsientoRef, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tspBarra As ToolStrip
    Public WithEvents tsbRefrescar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsddExportar As ToolStripDropDownButton
    Friend WithEvents tsmiExportarExcel As ToolStripMenuItem
    Public WithEvents tsbPreferencias As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbSalir As ToolStripButton
    Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents tbcGeneral As TabControl
    Friend WithEvents tbpPeriodos As TabPage
    Friend WithEvents ugAsientoRef As UltraGridSiga
    Friend WithEvents grpFiltros As GroupBox
    Friend WithEvents cmbEjercicio As Controles.ComboBox
    Friend WithEvents lblEjercicio As Controles.Label
    Friend WithEvents Label3 As Controles.Label
    Friend WithEvents clbSucursales As Controles.CheckedListBox
    Friend WithEvents cmbPlan As Controles.ComboBox
    Friend WithEvents lblPlan As Controles.Label
    Friend WithEvents btnConsultar As Controles.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbCentroCosto As Controles.ComboBox
    Friend WithEvents lblCentroCosto As Controles.Label
    Friend WithEvents lblMonto As Controles.Label
    Friend WithEvents txtConcepto As Controles.TextBox
    Friend WithEvents lbloncept As Controles.Label
    Friend WithEvents lblDesc As Controles.Label
    Friend WithEvents bscDescripcion As Controles.Buscador
    Friend WithEvents bscCodCuenta As Controles.Buscador
    Friend WithEvents lblCta As Controles.Label
    Friend WithEvents btnGenerarAsiento As Controles.Button
    Friend WithEvents dtpFecha As Controles.DateTimePicker
    Friend WithEvents lblFecha As Controles.Label
    Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
End Class
