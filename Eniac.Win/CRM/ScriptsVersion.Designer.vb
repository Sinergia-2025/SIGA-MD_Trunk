<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptsVersion
   Inherits BaseForm

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Resultados")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptsVersion))
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugScripts = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbVersionHasta = New Eniac.Controles.ComboBox()
        Me.cmbVersionDesde = New Eniac.Controles.ComboBox()
        Me.cmbAplicacion = New Eniac.Controles.ComboBox()
        Me.lblVersionHasta = New Eniac.Controles.Label()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.lblVersionDesde = New Eniac.Controles.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbcDatos = New System.Windows.Forms.TabControl()
        Me.tbpScripts = New System.Windows.Forms.TabPage()
        Me.tbpResultados = New System.Windows.Forms.TabPage()
        Me.trvResultados = New System.Windows.Forms.TreeView()
        Me.ofgScript = New System.Windows.Forms.OpenFileDialog()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnInsertar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnInsertarSeleccioMultiple = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSincronizacionWeb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbBase = New System.Windows.Forms.ToolStripTextBox()
        Me.tsbTesteaScripts = New System.Windows.Forms.ToolStripButton()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.bwImportarArchivos = New System.ComponentModel.BackgroundWorker()
        Me.bwSincronizar = New System.ComponentModel.BackgroundWorker()
        CType(Me.ugScripts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tbcDatos.SuspendLayout()
        Me.tbpScripts.SuspendLayout()
        Me.tbpResultados.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugScripts
        '
        Me.ugScripts.AllowDrop = True
        Me.ugScripts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.ugScripts.DisplayLayout.Appearance = Appearance1
        UltraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugScripts.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugScripts.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugScripts.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugScripts.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugScripts.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugScripts.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugScripts.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugScripts.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugScripts.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugScripts.DisplayLayout.MaxColScrollRegions = 1
        Me.ugScripts.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugScripts.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugScripts.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugScripts.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugScripts.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugScripts.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugScripts.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugScripts.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugScripts.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugScripts.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugScripts.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugScripts.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugScripts.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugScripts.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugScripts.DisplayLayout.Override.CellPadding = 0
        Me.ugScripts.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugScripts.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugScripts.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.Color.Tomato
        Appearance9.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugScripts.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Me.ugScripts.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance10.TextHAlignAsString = "Left"
        Me.ugScripts.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugScripts.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugScripts.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugScripts.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugScripts.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugScripts.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugScripts.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugScripts.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugScripts.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugScripts.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance12.BackColor = System.Drawing.Color.LimeGreen
        Appearance12.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugScripts.DisplayLayout.Override.SummaryValueAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugScripts.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugScripts.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugScripts.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugScripts.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugScripts.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugScripts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugScripts.Location = New System.Drawing.Point(3, 3)
        Me.ugScripts.Name = "ugScripts"
        Me.ugScripts.Size = New System.Drawing.Size(945, 307)
        Me.ugScripts.TabIndex = 0
        Me.ugScripts.Text = "UltraGrid1"
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.cmbVersionHasta)
        Me.grbFiltros.Controls.Add(Me.cmbVersionDesde)
        Me.grbFiltros.Controls.Add(Me.cmbAplicacion)
        Me.grbFiltros.Controls.Add(Me.lblVersionHasta)
        Me.grbFiltros.Controls.Add(Me.lblCodigo)
        Me.grbFiltros.Controls.Add(Me.lblVersionDesde)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(959, 65)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'cmbVersionHasta
        '
        Me.cmbVersionHasta.BindearPropiedadControl = "SelectedValue"
        Me.cmbVersionHasta.BindearPropiedadEntidad = "IdAplicacion"
        Me.cmbVersionHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersionHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVersionHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVersionHasta.FormattingEnabled = True
        Me.cmbVersionHasta.IsPK = True
        Me.cmbVersionHasta.IsRequired = True
        Me.cmbVersionHasta.Key = Nothing
        Me.cmbVersionHasta.LabelAsoc = Nothing
        Me.cmbVersionHasta.Location = New System.Drawing.Point(246, 29)
        Me.cmbVersionHasta.Name = "cmbVersionHasta"
        Me.cmbVersionHasta.Size = New System.Drawing.Size(114, 21)
        Me.cmbVersionHasta.TabIndex = 5
        '
        'cmbVersionDesde
        '
        Me.cmbVersionDesde.BindearPropiedadControl = "SelectedValue"
        Me.cmbVersionDesde.BindearPropiedadEntidad = "IdAplicacion"
        Me.cmbVersionDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersionDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVersionDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVersionDesde.FormattingEnabled = True
        Me.cmbVersionDesde.IsPK = True
        Me.cmbVersionDesde.IsRequired = True
        Me.cmbVersionDesde.Key = Nothing
        Me.cmbVersionDesde.LabelAsoc = Nothing
        Me.cmbVersionDesde.Location = New System.Drawing.Point(126, 29)
        Me.cmbVersionDesde.Name = "cmbVersionDesde"
        Me.cmbVersionDesde.Size = New System.Drawing.Size(114, 21)
        Me.cmbVersionDesde.TabIndex = 3
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbAplicacion.BindearPropiedadEntidad = "IdAplicacion"
        Me.cmbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAplicacion.FormattingEnabled = True
        Me.cmbAplicacion.IsPK = True
        Me.cmbAplicacion.IsRequired = True
        Me.cmbAplicacion.Key = Nothing
        Me.cmbAplicacion.LabelAsoc = Nothing
        Me.cmbAplicacion.Location = New System.Drawing.Point(6, 29)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.Size = New System.Drawing.Size(114, 21)
        Me.cmbAplicacion.TabIndex = 1
        '
        'lblVersionHasta
        '
        Me.lblVersionHasta.AutoSize = True
        Me.lblVersionHasta.LabelAsoc = Nothing
        Me.lblVersionHasta.Location = New System.Drawing.Point(243, 13)
        Me.lblVersionHasta.Name = "lblVersionHasta"
        Me.lblVersionHasta.Size = New System.Drawing.Size(42, 13)
        Me.lblVersionHasta.TabIndex = 4
        Me.lblVersionHasta.Text = "Versión"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(3, 13)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(56, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Aplicación"
        '
        'lblVersionDesde
        '
        Me.lblVersionDesde.AutoSize = True
        Me.lblVersionDesde.LabelAsoc = Nothing
        Me.lblVersionDesde.Location = New System.Drawing.Point(123, 13)
        Me.lblVersionDesde.Name = "lblVersionDesde"
        Me.lblVersionDesde.Size = New System.Drawing.Size(42, 13)
        Me.lblVersionDesde.TabIndex = 2
        Me.lblVersionDesde.Text = "Versión"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 442)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
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
        'tbcDatos
        '
        Me.tbcDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDatos.Controls.Add(Me.tbpScripts)
        Me.tbcDatos.Controls.Add(Me.tbpResultados)
        Me.tbcDatos.Location = New System.Drawing.Point(12, 103)
        Me.tbcDatos.Name = "tbcDatos"
        Me.tbcDatos.SelectedIndex = 0
        Me.tbcDatos.Size = New System.Drawing.Size(959, 336)
        Me.tbcDatos.TabIndex = 1
        '
        'tbpScripts
        '
        Me.tbpScripts.Controls.Add(Me.ugScripts)
        Me.tbpScripts.Location = New System.Drawing.Point(4, 22)
        Me.tbpScripts.Name = "tbpScripts"
        Me.tbpScripts.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpScripts.Size = New System.Drawing.Size(951, 310)
        Me.tbpScripts.TabIndex = 0
        Me.tbpScripts.Text = "Scripts"
        Me.tbpScripts.UseVisualStyleBackColor = True
        '
        'tbpResultados
        '
        Me.tbpResultados.Controls.Add(Me.trvResultados)
        Me.tbpResultados.Location = New System.Drawing.Point(4, 22)
        Me.tbpResultados.Name = "tbpResultados"
        Me.tbpResultados.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpResultados.Size = New System.Drawing.Size(951, 310)
        Me.tbpResultados.TabIndex = 1
        Me.tbpResultados.Text = "Resultados"
        Me.tbpResultados.UseVisualStyleBackColor = True
        '
        'trvResultados
        '
        Me.trvResultados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvResultados.Location = New System.Drawing.Point(6, 6)
        Me.trvResultados.Name = "trvResultados"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Resultados"
        Me.trvResultados.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.trvResultados.Size = New System.Drawing.Size(835, 298)
        Me.trvResultados.TabIndex = 0
        '
        'ofgScript
        '
        Me.ofgScript.DefaultExt = "png"
        Me.ofgScript.Filter = "Archivos de Texto (*.sql)|*.sql|Todos los Archivos (*.*)|*.*"
        Me.ofgScript.Multiselect = True
        Me.ofgScript.RestoreDirectory = True
        Me.ofgScript.Title = "Seleccione un archivo"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
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
        'btnInsertar
        '
        Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.document_add
        Me.btnInsertar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(68, 26)
        Me.btnInsertar.Text = "Nuevo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'btnInsertarSeleccioMultiple
        '
        Me.btnInsertarSeleccioMultiple.Image = Global.Eniac.Win.My.Resources.Resources.column_add
        Me.btnInsertarSeleccioMultiple.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertarSeleccioMultiple.Name = "btnInsertarSeleccioMultiple"
        Me.btnInsertarSeleccioMultiple.Size = New System.Drawing.Size(77, 26)
        Me.btnInsertarSeleccioMultiple.Text = "Multiple"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Eniac.Win.My.Resources.Resources.document_add
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(63, 26)
        Me.btnEditar.Text = "Editar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.document_delete
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(76, 26)
        Me.btnEliminar.Text = "Eliminar"
        '
        'tsbSincronizacionWeb
        '
        Me.tsbSincronizacionWeb.Image = Global.Eniac.Win.My.Resources.Resources.wan_refresh_481
        Me.tsbSincronizacionWeb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSincronizacionWeb.Name = "tsbSincronizacionWeb"
        Me.tsbSincronizacionWeb.Size = New System.Drawing.Size(91, 26)
        Me.tsbSincronizacionWeb.Text = "Sincronizar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'tsbBase
        '
        Me.tsbBase.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbBase.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tsbBase.MaxLength = 50
        Me.tsbBase.Name = "tsbBase"
        Me.tsbBase.Size = New System.Drawing.Size(100, 29)
        Me.tsbBase.Visible = False
        '
        'tsbTesteaScripts
        '
        Me.tsbTesteaScripts.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbTesteaScripts.Image = CType(resources.GetObject("tsbTesteaScripts.Image"), System.Drawing.Image)
        Me.tsbTesteaScripts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTesteaScripts.Name = "tsbTesteaScripts"
        Me.tsbTesteaScripts.Size = New System.Drawing.Size(122, 26)
        Me.tsbTesteaScripts.Text = "&Probar Scripts en"
        Me.tsbTesteaScripts.Visible = False
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.btnInsertar, Me.ToolStripSeparator2, Me.btnEditar, Me.ToolStripSeparator4, Me.btnEliminar, Me.ToolStripSeparator3, Me.btnInsertarSeleccioMultiple, Me.ToolStripSeparator5, Me.tsbImprimir, Me.tsddExportar, Me.ToolStripSeparator7, Me.tsbSincronizacionWeb, Me.ToolStripSeparator6, Me.tsbSalir, Me.tsbBase, Me.tsbTesteaScripts})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 3
        Me.tstBarra.Text = "toolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 29)
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.FitWidthToPages = 1
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugScripts
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'bwImportarArchivos
        '
        Me.bwImportarArchivos.WorkerReportsProgress = True
        Me.bwImportarArchivos.WorkerSupportsCancellation = True
        '
        'bwSincronizar
        '
        Me.bwSincronizar.WorkerReportsProgress = True
        Me.bwSincronizar.WorkerSupportsCancellation = True
        '
        'ScriptsVersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 464)
        Me.Controls.Add(Me.tbcDatos)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "ScriptsVersion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargar Scripts de Versión"
        CType(Me.ugScripts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tbcDatos.ResumeLayout(False)
        Me.tbpScripts.ResumeLayout(False)
        Me.tbpResultados.ResumeLayout(False)
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents cmbVersionDesde As Eniac.Controles.ComboBox
   Friend WithEvents cmbAplicacion As Eniac.Controles.ComboBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents lblVersionDesde As Eniac.Controles.Label
   Friend WithEvents ugScripts As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tbcDatos As System.Windows.Forms.TabControl
   Friend WithEvents tbpScripts As System.Windows.Forms.TabPage
   Friend WithEvents tbpResultados As System.Windows.Forms.TabPage
   Friend WithEvents trvResultados As System.Windows.Forms.TreeView
   Friend WithEvents ofgScript As System.Windows.Forms.OpenFileDialog
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents btnInsertar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents btnInsertarSeleccioMultiple As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSincronizacionWeb As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbBase As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents tsbTesteaScripts As System.Windows.Forms.ToolStripButton
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents cmbVersionHasta As Controles.ComboBox
    Friend WithEvents lblVersionHasta As Controles.Label
    Friend WithEvents bwImportarArchivos As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwSincronizar As System.ComponentModel.BackgroundWorker
End Class
