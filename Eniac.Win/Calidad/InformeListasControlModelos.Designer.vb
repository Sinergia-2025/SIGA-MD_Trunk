<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InformeListasControlModelos
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
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Cabecera", -1)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaControl")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaControl")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoModelo")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoModelo")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeListasControlModelos))
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.MenuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ListaDeControlPorProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.chbModelo = New Eniac.Controles.CheckBox()
        Me.bscModelo2 = New Eniac.Controles.Buscador2()
        Me.chbExpandAll = New Eniac.Controles.CheckBox()
        Me.chbListasControl = New Eniac.Controles.CheckBox()
        Me.cmbListasControl = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuContext.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance14
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
        UltraGridColumn10.Header.VisiblePosition = 4
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.VisiblePosition = 5
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.VisiblePosition = 6
        UltraGridColumn12.Hidden = True
        UltraGridColumn25.Header.Caption = "Lista de Control"
        UltraGridColumn25.Header.VisiblePosition = 1
        UltraGridColumn25.Width = 412
        UltraGridColumn31.Header.VisiblePosition = 3
        UltraGridColumn31.Hidden = True
        UltraGridColumn32.Header.Caption = "Modelo"
        UltraGridColumn32.Header.VisiblePosition = 0
        UltraGridColumn32.Width = 225
        UltraGridColumn33.Header.VisiblePosition = 2
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn25, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33})
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
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = " Arrastrar la Columna que desea agrupar"
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
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
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
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance12.BackColor = System.Drawing.Color.SkyBlue
        Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(11, 125)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(756, 411)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'MenuContext
        '
        Me.MenuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListaDeControlPorProductosToolStripMenuItem})
        Me.MenuContext.Name = "MenuContext"
        Me.MenuContext.Size = New System.Drawing.Size(236, 26)
        '
        'ListaDeControlPorProductosToolStripMenuItem
        '
        Me.ListaDeControlPorProductosToolStripMenuItem.Name = "ListaDeControlPorProductosToolStripMenuItem"
        Me.ListaDeControlPorProductosToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.ListaDeControlPorProductosToolStripMenuItem.Text = "Lista de Control por Productos"
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.chbModelo)
        Me.grbFiltros.Controls.Add(Me.bscModelo2)
        Me.grbFiltros.Controls.Add(Me.chbExpandAll)
        Me.grbFiltros.Controls.Add(Me.chbListasControl)
        Me.grbFiltros.Controls.Add(Me.cmbListasControl)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(11, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(756, 87)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'chbModelo
        '
        Me.chbModelo.AutoSize = True
        Me.chbModelo.BindearPropiedadControl = Nothing
        Me.chbModelo.BindearPropiedadEntidad = Nothing
        Me.chbModelo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbModelo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbModelo.IsPK = False
        Me.chbModelo.IsRequired = False
        Me.chbModelo.Key = Nothing
        Me.chbModelo.LabelAsoc = Nothing
        Me.chbModelo.Location = New System.Drawing.Point(9, 18)
        Me.chbModelo.Name = "chbModelo"
        Me.chbModelo.Size = New System.Drawing.Size(61, 17)
        Me.chbModelo.TabIndex = 48
        Me.chbModelo.Text = "Modelo"
        Me.chbModelo.UseVisualStyleBackColor = True
        '
        'bscModelo2
        '
        Me.bscModelo2.ActivarFiltroEnGrilla = True
        Me.bscModelo2.BindearPropiedadControl = Nothing
        Me.bscModelo2.BindearPropiedadEntidad = Nothing
        Me.bscModelo2.ConfigBuscador = Nothing
        Me.bscModelo2.Datos = Nothing
        Me.bscModelo2.Enabled = False
        Me.bscModelo2.FilaDevuelta = Nothing
        Me.bscModelo2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscModelo2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscModelo2.IsDecimal = False
        Me.bscModelo2.IsNumber = False
        Me.bscModelo2.IsPK = False
        Me.bscModelo2.IsRequired = False
        Me.bscModelo2.Key = ""
        Me.bscModelo2.LabelAsoc = Nothing
        Me.bscModelo2.Location = New System.Drawing.Point(116, 16)
        Me.bscModelo2.MaxLengh = "32767"
        Me.bscModelo2.Name = "bscModelo2"
        Me.bscModelo2.Permitido = True
        Me.bscModelo2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscModelo2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscModelo2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscModelo2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscModelo2.Selecciono = False
        Me.bscModelo2.Size = New System.Drawing.Size(316, 20)
        Me.bscModelo2.TabIndex = 46
        '
        'chbExpandAll
        '
        Me.chbExpandAll.AutoSize = True
        Me.chbExpandAll.BindearPropiedadControl = Nothing
        Me.chbExpandAll.BindearPropiedadEntidad = Nothing
        Me.chbExpandAll.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExpandAll.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExpandAll.IsPK = False
        Me.chbExpandAll.IsRequired = False
        Me.chbExpandAll.Key = Nothing
        Me.chbExpandAll.LabelAsoc = Nothing
        Me.chbExpandAll.Location = New System.Drawing.Point(459, 60)
        Me.chbExpandAll.Name = "chbExpandAll"
        Me.chbExpandAll.Size = New System.Drawing.Size(104, 17)
        Me.chbExpandAll.TabIndex = 45
        Me.chbExpandAll.Text = "Expandir Grupos"
        Me.chbExpandAll.UseVisualStyleBackColor = True
        '
        'chbListasControl
        '
        Me.chbListasControl.AutoSize = True
        Me.chbListasControl.BindearPropiedadControl = Nothing
        Me.chbListasControl.BindearPropiedadEntidad = Nothing
        Me.chbListasControl.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListasControl.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListasControl.IsPK = False
        Me.chbListasControl.IsRequired = False
        Me.chbListasControl.Key = Nothing
        Me.chbListasControl.LabelAsoc = Nothing
        Me.chbListasControl.Location = New System.Drawing.Point(9, 52)
        Me.chbListasControl.Name = "chbListasControl"
        Me.chbListasControl.Size = New System.Drawing.Size(104, 17)
        Me.chbListasControl.TabIndex = 29
        Me.chbListasControl.Text = "Listas de Control"
        Me.chbListasControl.UseVisualStyleBackColor = True
        '
        'cmbListasControl
        '
        Me.cmbListasControl.BindearPropiedadControl = "SelectedValue"
        Me.cmbListasControl.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
        Me.cmbListasControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListasControl.Enabled = False
        Me.cmbListasControl.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListasControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListasControl.FormattingEnabled = True
        Me.cmbListasControl.IsPK = False
        Me.cmbListasControl.IsRequired = False
        Me.cmbListasControl.Key = Nothing
        Me.cmbListasControl.LabelAsoc = Nothing
        Me.cmbListasControl.Location = New System.Drawing.Point(116, 51)
        Me.cmbListasControl.Name = "cmbListasControl"
        Me.cmbListasControl.Size = New System.Drawing.Size(316, 21)
        Me.cmbListasControl.TabIndex = 30
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(459, 9)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 45)
        Me.btnConsultar.TabIndex = 11
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(779, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(700, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(779, 29)
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
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
        'InformeListasControlModelos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 561)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InformeListasControlModelos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Listas de Control por Modelos"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuContext.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnConsultar As Eniac.Controles.Button
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ListaDeControlPorProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chbListasControl As Eniac.Controles.CheckBox
    Friend WithEvents cmbListasControl As Eniac.Controles.ComboBox
    Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chbExpandAll As Eniac.Controles.CheckBox
    Friend WithEvents chbModelo As Controles.CheckBox
    Friend WithEvents bscModelo2 As Controles.Buscador2
End Class
