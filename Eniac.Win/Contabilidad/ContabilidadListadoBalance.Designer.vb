<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadListadoBalance
    Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadListadoBalance))
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
      Me.fraFiltros = New System.Windows.Forms.GroupBox()
      Me.chbIncluirCuentasSinMovimientos = New System.Windows.Forms.CheckBox()
      Me.dtpBalanceDesde = New Eniac.Controles.DateTimePicker()
      Me.dtpBalance = New Eniac.Controles.DateTimePicker()
      Me.lblFechaBalance = New Eniac.Controles.Label()
      Me.lblFechaBalanceDesde = New Eniac.Controles.Label()
      Me.cmbColumnas = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbPlan = New Eniac.Controles.ComboBox()
      Me.lblPlan = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.Label3 = New Eniac.Controles.Label()
      Me.clbSucursales = New Eniac.Controles.CheckedListBox()
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
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.fraFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'fraFiltros
      '
      Me.fraFiltros.Controls.Add(Me.chbIncluirCuentasSinMovimientos)
      Me.fraFiltros.Controls.Add(Me.dtpBalanceDesde)
      Me.fraFiltros.Controls.Add(Me.dtpBalance)
      Me.fraFiltros.Controls.Add(Me.lblFechaBalance)
      Me.fraFiltros.Controls.Add(Me.lblFechaBalanceDesde)
      Me.fraFiltros.Controls.Add(Me.cmbColumnas)
      Me.fraFiltros.Controls.Add(Me.cmbPlan)
      Me.fraFiltros.Controls.Add(Me.Label1)
      Me.fraFiltros.Controls.Add(Me.btnConsultar)
      Me.fraFiltros.Controls.Add(Me.lblPlan)
      Me.fraFiltros.Controls.Add(Me.Label3)
      Me.fraFiltros.Controls.Add(Me.clbSucursales)
      Me.fraFiltros.Location = New System.Drawing.Point(3, 32)
      Me.fraFiltros.Name = "fraFiltros"
      Me.fraFiltros.Size = New System.Drawing.Size(861, 102)
      Me.fraFiltros.TabIndex = 0
      Me.fraFiltros.TabStop = False
      Me.fraFiltros.Text = "Filtros"
      '
      'chbIncluirCuentasSinMovimientos
      '
      Me.chbIncluirCuentasSinMovimientos.AutoSize = True
      Me.chbIncluirCuentasSinMovimientos.Location = New System.Drawing.Point(529, 48)
      Me.chbIncluirCuentasSinMovimientos.Name = "chbIncluirCuentasSinMovimientos"
      Me.chbIncluirCuentasSinMovimientos.Size = New System.Drawing.Size(172, 17)
      Me.chbIncluirCuentasSinMovimientos.TabIndex = 9
      Me.chbIncluirCuentasSinMovimientos.Text = "Incluir cuentas sin movimientos"
      Me.chbIncluirCuentasSinMovimientos.UseVisualStyleBackColor = True
      '
      'dtpBalanceDesde
      '
      Me.dtpBalanceDesde.BindearPropiedadControl = ""
      Me.dtpBalanceDesde.BindearPropiedadEntidad = ""
      Me.dtpBalanceDesde.Checked = False
      Me.dtpBalanceDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpBalanceDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpBalanceDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpBalanceDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpBalanceDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBalanceDesde.IsPK = False
      Me.dtpBalanceDesde.IsRequired = False
      Me.dtpBalanceDesde.Key = ""
      Me.dtpBalanceDesde.LabelAsoc = Nothing
      Me.dtpBalanceDesde.Location = New System.Drawing.Point(370, 21)
      Me.dtpBalanceDesde.Name = "dtpBalanceDesde"
      Me.dtpBalanceDesde.ShowCheckBox = True
      Me.dtpBalanceDesde.Size = New System.Drawing.Size(103, 20)
      Me.dtpBalanceDesde.TabIndex = 3
      '
      'dtpBalance
      '
      Me.dtpBalance.BindearPropiedadControl = ""
      Me.dtpBalance.BindearPropiedadEntidad = ""
      Me.dtpBalance.CustomFormat = "dd/MM/yyyy"
      Me.dtpBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpBalance.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpBalance.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpBalance.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBalance.IsPK = False
      Me.dtpBalance.IsRequired = False
      Me.dtpBalance.Key = ""
      Me.dtpBalance.LabelAsoc = Me.lblFechaBalance
      Me.dtpBalance.Location = New System.Drawing.Point(514, 21)
      Me.dtpBalance.Name = "dtpBalance"
      Me.dtpBalance.Size = New System.Drawing.Size(82, 20)
      Me.dtpBalance.TabIndex = 5
      '
      'lblFechaBalance
      '
      Me.lblFechaBalance.AutoSize = True
      Me.lblFechaBalance.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFechaBalance.LabelAsoc = Nothing
      Me.lblFechaBalance.Location = New System.Drawing.Point(478, 25)
      Me.lblFechaBalance.Name = "lblFechaBalance"
      Me.lblFechaBalance.Size = New System.Drawing.Size(33, 13)
      Me.lblFechaBalance.TabIndex = 4
      Me.lblFechaBalance.Text = "hasta"
      '
      'lblFechaBalanceDesde
      '
      Me.lblFechaBalanceDesde.AutoSize = True
      Me.lblFechaBalanceDesde.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFechaBalanceDesde.LabelAsoc = Nothing
      Me.lblFechaBalanceDesde.Location = New System.Drawing.Point(284, 25)
      Me.lblFechaBalanceDesde.Name = "lblFechaBalanceDesde"
      Me.lblFechaBalanceDesde.Size = New System.Drawing.Size(79, 13)
      Me.lblFechaBalanceDesde.TabIndex = 2
      Me.lblFechaBalanceDesde.Text = "Desde la fecha"
      '
      'cmbColumnas
      '
      Me.cmbColumnas.BindearPropiedadControl = ""
      Me.cmbColumnas.BindearPropiedadEntidad = ""
      Me.cmbColumnas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbColumnas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbColumnas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbColumnas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbColumnas.FormattingEnabled = True
      Me.cmbColumnas.IsPK = False
      Me.cmbColumnas.IsRequired = True
      Me.cmbColumnas.Key = Nothing
      Me.cmbColumnas.LabelAsoc = Me.Label1
      Me.cmbColumnas.Location = New System.Drawing.Point(370, 72)
      Me.cmbColumnas.Name = "cmbColumnas"
      Me.cmbColumnas.Size = New System.Drawing.Size(153, 21)
      Me.cmbColumnas.TabIndex = 7
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(284, 77)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(45, 13)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Formato"
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
      Me.cmbPlan.Location = New System.Drawing.Point(370, 46)
      Me.cmbPlan.Name = "cmbPlan"
      Me.cmbPlan.Size = New System.Drawing.Size(153, 21)
      Me.cmbPlan.TabIndex = 7
      '
      'lblPlan
      '
      Me.lblPlan.AutoSize = True
      Me.lblPlan.LabelAsoc = Nothing
      Me.lblPlan.Location = New System.Drawing.Point(284, 51)
      Me.lblPlan.Name = "lblPlan"
      Me.lblPlan.Size = New System.Drawing.Size(80, 13)
      Me.lblPlan.TabIndex = 6
      Me.lblPlan.Text = "Plan de Cuenta"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(755, 51)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 8
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(12, 21)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Sucursales"
      '
      'clbSucursales
      '
      Me.clbSucursales.CheckOnClick = True
      Me.clbSucursales.FormattingEnabled = True
      Me.clbSucursales.Location = New System.Drawing.Point(77, 21)
      Me.clbSucursales.Name = "clbSucursales"
      Me.clbSucursales.Size = New System.Drawing.Size(196, 49)
      Me.clbSucursales.TabIndex = 1
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 486)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(874, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(795, 17)
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(874, 29)
      Me.tstBarra.TabIndex = 2
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
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
      Me.ugDetalle.Location = New System.Drawing.Point(3, 140)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(861, 343)
      Me.ugDetalle.TabIndex = 1
      Me.ugDetalle.Text = "UltraGrid1"
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
      'ContabilidadListadoBalance
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(874, 508)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.fraFiltros)
      Me.KeyPreview = True
      Me.Name = "ContabilidadListadoBalance"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Balance de Sumas y Saldos"
      Me.fraFiltros.ResumeLayout(False)
      Me.fraFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents fraFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents lblPlan As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpBalance As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaBalanceDesde As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents dtpBalanceDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaBalance As Eniac.Controles.Label
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbColumnas As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbIncluirCuentasSinMovimientos As System.Windows.Forms.CheckBox
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
End Class
