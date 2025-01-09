<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministracionDeVersiones
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministracionDeVersiones))
      Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.tbcEnvioMail = New System.Windows.Forms.TabControl()
      Me.tbpClientes = New System.Windows.Forms.TabPage()
      Me.ugClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.sspPie = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbCategoriasClientes = New Eniac.Win.ComboBoxCategorias()
      Me.cmbVersionHasta = New Eniac.Controles.ComboBox()
      Me.cmbVersionDesde = New Eniac.Controles.ComboBox()
      Me.cmbAplicacion = New Eniac.Controles.ComboBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.lblVersionDesde = New Eniac.Controles.Label()
      Me.lblVersionHasta = New Eniac.Controles.Label()
      Me.lblVersion = New Eniac.Controles.Label()
      Me.chbCobrador = New Eniac.Controles.CheckBox()
      Me.cmbCobrador = New Eniac.Controles.ComboBox()
      Me.lblComenzarPorNombreCliente = New Eniac.Controles.Label()
      Me.txtComenzarPorNombreCliente = New Eniac.Controles.TextBox()
      Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
      Me.chbCategoriaCliente = New Eniac.Controles.Label()
      Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
      Me.bscNombreCliente = New Eniac.Controles.Buscador()
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbActualizarVersion = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tbcEnvioMail.SuspendLayout()
        Me.tbpClientes.SuspendLayout()
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sspPie.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'DialogoAbrirArchivo
        '
        Me.DialogoAbrirArchivo.FileName = "OpenFileDialog1"
        Me.DialogoAbrirArchivo.Filter = "Adobe Reader (*.pdf)|*.pdf|Todos los Archivos (*.*)|*.*"
        Me.DialogoAbrirArchivo.RestoreDirectory = True
        '
        'tbcEnvioMail
        '
        Me.tbcEnvioMail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcEnvioMail.Controls.Add(Me.tbpClientes)
        Me.tbcEnvioMail.Location = New System.Drawing.Point(15, 180)
        Me.tbcEnvioMail.Name = "tbcEnvioMail"
        Me.tbcEnvioMail.SelectedIndex = 0
        Me.tbcEnvioMail.Size = New System.Drawing.Size(907, 357)
        Me.tbcEnvioMail.TabIndex = 8
        '
        'tbpClientes
        '
        Me.tbpClientes.BackColor = System.Drawing.SystemColors.Control
        Me.tbpClientes.Controls.Add(Me.ugClientes)
        Me.tbpClientes.Location = New System.Drawing.Point(4, 22)
        Me.tbpClientes.Name = "tbpClientes"
        Me.tbpClientes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpClientes.Size = New System.Drawing.Size(899, 331)
        Me.tbpClientes.TabIndex = 0
        Me.tbpClientes.Text = "Clientes"
        '
        'ugClientes
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.ugClientes.DisplayLayout.Appearance = Appearance1
        Me.ugClientes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugClientes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientes.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugClientes.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugClientes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugClientes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugClientes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugClientes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugClientes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugClientes.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientes.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugClientes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugClientes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugClientes.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugClientes.DisplayLayout.Override.CellPadding = 0
        Me.ugClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.Color.Tomato
        Appearance9.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Me.ugClientes.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance10.TextHAlignAsString = "Left"
        Me.ugClientes.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugClientes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugClientes.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugClientes.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientes.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientes.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientes.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugClientes.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance12.BackColor = System.Drawing.Color.LimeGreen
        Appearance12.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugClientes.DisplayLayout.Override.SummaryValueAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugClientes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugClientes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugClientes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugClientes.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugClientes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugClientes.Location = New System.Drawing.Point(3, 3)
        Me.ugClientes.Name = "ugClientes"
        Me.ugClientes.Size = New System.Drawing.Size(893, 325)
        Me.ugClientes.TabIndex = 6
        Me.ugClientes.Text = "UltraGrid1"
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(148, 152)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 2
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(21, 153)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 1
        '
        'sspPie
        '
        Me.sspPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.sspPie.Location = New System.Drawing.Point(0, 540)
        Me.sspPie.Name = "sspPie"
        Me.sspPie.Size = New System.Drawing.Size(934, 22)
        Me.sspPie.TabIndex = 7
        Me.sspPie.Text = "StatusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(855, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Step = 1
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.cmbCategoriasClientes)
        Me.grbFiltros.Controls.Add(Me.cmbVersionHasta)
        Me.grbFiltros.Controls.Add(Me.cmbVersionDesde)
        Me.grbFiltros.Controls.Add(Me.cmbAplicacion)
        Me.grbFiltros.Controls.Add(Me.lblCodigo)
        Me.grbFiltros.Controls.Add(Me.lblVersionDesde)
        Me.grbFiltros.Controls.Add(Me.lblVersionHasta)
        Me.grbFiltros.Controls.Add(Me.lblVersion)
        Me.grbFiltros.Controls.Add(Me.chbCobrador)
        Me.grbFiltros.Controls.Add(Me.cmbCobrador)
        Me.grbFiltros.Controls.Add(Me.lblComenzarPorNombreCliente)
        Me.grbFiltros.Controls.Add(Me.txtComenzarPorNombreCliente)
        Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.chbCategoriaCliente)
        Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.bscNombreCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombreCliente)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(13, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(909, 114)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'cmbCategoriasClientes
        '
        Me.cmbCategoriasClientes.BindearPropiedadControl = Nothing
        Me.cmbCategoriasClientes.BindearPropiedadEntidad = Nothing
        Me.cmbCategoriasClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriasClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriasClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriasClientes.FormattingEnabled = True
        Me.cmbCategoriasClientes.IsPK = False
        Me.cmbCategoriasClientes.IsRequired = False
        Me.cmbCategoriasClientes.Key = Nothing
        Me.cmbCategoriasClientes.LabelAsoc = Nothing
        Me.cmbCategoriasClientes.Location = New System.Drawing.Point(648, 13)
        Me.cmbCategoriasClientes.Name = "cmbCategoriasClientes"
        Me.cmbCategoriasClientes.Size = New System.Drawing.Size(140, 21)
        Me.cmbCategoriasClientes.TabIndex = 13
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
        Me.cmbVersionHasta.Location = New System.Drawing.Point(403, 26)
        Me.cmbVersionHasta.Name = "cmbVersionHasta"
        Me.cmbVersionHasta.Size = New System.Drawing.Size(114, 21)
        Me.cmbVersionHasta.TabIndex = 6
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
        Me.cmbVersionDesde.Location = New System.Drawing.Point(239, 25)
        Me.cmbVersionDesde.Name = "cmbVersionDesde"
        Me.cmbVersionDesde.Size = New System.Drawing.Size(114, 21)
        Me.cmbVersionDesde.TabIndex = 4
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
        Me.cmbAplicacion.Location = New System.Drawing.Point(68, 25)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.Size = New System.Drawing.Size(102, 21)
        Me.cmbAplicacion.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(11, 29)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(56, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Aplicación"
        '
        'lblVersionDesde
        '
        Me.lblVersionDesde.AutoSize = True
        Me.lblVersionDesde.LabelAsoc = Nothing
        Me.lblVersionDesde.Location = New System.Drawing.Point(195, 29)
        Me.lblVersionDesde.Name = "lblVersionDesde"
        Me.lblVersionDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblVersionDesde.TabIndex = 3
        Me.lblVersionDesde.Text = "Desde"
        '
        'lblVersionHasta
        '
        Me.lblVersionHasta.AutoSize = True
        Me.lblVersionHasta.LabelAsoc = Nothing
        Me.lblVersionHasta.Location = New System.Drawing.Point(362, 31)
        Me.lblVersionHasta.Name = "lblVersionHasta"
        Me.lblVersionHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblVersionHasta.TabIndex = 5
        Me.lblVersionHasta.Text = "Hasta"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.LabelAsoc = Nothing
        Me.lblVersion.Location = New System.Drawing.Point(191, 13)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Versión"
        '
        'chbCobrador
        '
        Me.chbCobrador.AutoSize = True
        Me.chbCobrador.BindearPropiedadControl = Nothing
        Me.chbCobrador.BindearPropiedadEntidad = Nothing
        Me.chbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCobrador.IsPK = False
        Me.chbCobrador.IsRequired = False
        Me.chbCobrador.Key = Nothing
        Me.chbCobrador.LabelAsoc = Nothing
        Me.chbCobrador.Location = New System.Drawing.Point(536, 40)
        Me.chbCobrador.Name = "chbCobrador"
        Me.chbCobrador.Size = New System.Drawing.Size(69, 17)
        Me.chbCobrador.TabIndex = 14
        Me.chbCobrador.Text = "Cobrador"
        Me.chbCobrador.UseVisualStyleBackColor = True
        '
        'cmbCobrador
        '
        Me.cmbCobrador.BindearPropiedadControl = Nothing
        Me.cmbCobrador.BindearPropiedadEntidad = Nothing
        Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCobrador.Enabled = False
        Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCobrador.FormattingEnabled = True
        Me.cmbCobrador.IsPK = False
        Me.cmbCobrador.IsRequired = False
        Me.cmbCobrador.Key = Nothing
        Me.cmbCobrador.LabelAsoc = Nothing
        Me.cmbCobrador.Location = New System.Drawing.Point(648, 38)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.Size = New System.Drawing.Size(140, 21)
        Me.cmbCobrador.TabIndex = 15
        '
        'lblComenzarPorNombreCliente
        '
        Me.lblComenzarPorNombreCliente.AutoSize = True
        Me.lblComenzarPorNombreCliente.LabelAsoc = Nothing
        Me.lblComenzarPorNombreCliente.Location = New System.Drawing.Point(494, 93)
        Me.lblComenzarPorNombreCliente.Name = "lblComenzarPorNombreCliente"
        Me.lblComenzarPorNombreCliente.Size = New System.Drawing.Size(148, 13)
        Me.lblComenzarPorNombreCliente.TabIndex = 18
        Me.lblComenzarPorNombreCliente.Text = "Comenzar Por Nombre Cliente"
        '
        'txtComenzarPorNombreCliente
        '
        Me.txtComenzarPorNombreCliente.BindearPropiedadControl = ""
        Me.txtComenzarPorNombreCliente.BindearPropiedadEntidad = ""
        Me.txtComenzarPorNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComenzarPorNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComenzarPorNombreCliente.Formato = "N2"
        Me.txtComenzarPorNombreCliente.IsDecimal = False
        Me.txtComenzarPorNombreCliente.IsNumber = False
        Me.txtComenzarPorNombreCliente.IsPK = False
        Me.txtComenzarPorNombreCliente.IsRequired = False
        Me.txtComenzarPorNombreCliente.Key = ""
        Me.txtComenzarPorNombreCliente.LabelAsoc = Me.lblComenzarPorNombreCliente
        Me.txtComenzarPorNombreCliente.Location = New System.Drawing.Point(648, 88)
        Me.txtComenzarPorNombreCliente.MaxLength = 60
        Me.txtComenzarPorNombreCliente.Name = "txtComenzarPorNombreCliente"
        Me.txtComenzarPorNombreCliente.Size = New System.Drawing.Size(140, 20)
        Me.txtComenzarPorNombreCliente.TabIndex = 19
        '
        'chbZonaGeografica
        '
        Me.chbZonaGeografica.AutoSize = True
        Me.chbZonaGeografica.BindearPropiedadControl = Nothing
        Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbZonaGeografica.IsPK = False
        Me.chbZonaGeografica.IsRequired = False
        Me.chbZonaGeografica.Key = Nothing
        Me.chbZonaGeografica.LabelAsoc = Nothing
        Me.chbZonaGeografica.Location = New System.Drawing.Point(536, 65)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(109, 17)
        Me.chbZonaGeografica.TabIndex = 16
        Me.chbZonaGeografica.Text = "Zona Greográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
        '
        'chbCategoriaCliente
        '
        Me.chbCategoriaCliente.AutoSize = True
        Me.chbCategoriaCliente.LabelAsoc = Nothing
        Me.chbCategoriaCliente.Location = New System.Drawing.Point(552, 15)
        Me.chbCategoriaCliente.Name = "chbCategoriaCliente"
        Me.chbCategoriaCliente.Size = New System.Drawing.Size(52, 13)
        Me.chbCategoriaCliente.TabIndex = 12
        Me.chbCategoriaCliente.Text = "Categoria"
        '
        'cmbZonaGeografica
        '
        Me.cmbZonaGeografica.BindearPropiedadControl = ""
        Me.cmbZonaGeografica.BindearPropiedadEntidad = ""
        Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaGeografica.Enabled = False
        Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbZonaGeografica.FormattingEnabled = True
        Me.cmbZonaGeografica.IsPK = False
        Me.cmbZonaGeografica.IsRequired = True
        Me.cmbZonaGeografica.Key = Nothing
        Me.cmbZonaGeografica.LabelAsoc = Nothing
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(648, 63)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(140, 21)
        Me.cmbZonaGeografica.TabIndex = 17
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.AyudaAncho = 608
        Me.bscNombreCliente.BindearPropiedadControl = Nothing
        Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
        Me.bscNombreCliente.ColumnasAlineacion = Nothing
        Me.bscNombreCliente.ColumnasAncho = Nothing
        Me.bscNombreCliente.ColumnasFormato = Nothing
        Me.bscNombreCliente.ColumnasOcultas = Nothing
        Me.bscNombreCliente.ColumnasTitulos = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.Enabled = False
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Me.lblNombreCliente
        Me.bscNombreCliente.Location = New System.Drawing.Point(177, 75)
        Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = True
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(257, 23)
        Me.bscNombreCliente.TabIndex = 11
        Me.bscNombreCliente.Titulo = Nothing
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.LabelAsoc = Nothing
        Me.lblNombreCliente.Location = New System.Drawing.Point(174, 63)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreCliente.TabIndex = 10
        Me.lblNombreCliente.Text = "Nombre"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 608
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ColumnasAlineacion = Nothing
        Me.bscCodigoCliente.ColumnasAncho = Nothing
        Me.bscCodigoCliente.ColumnasFormato = Nothing
        Me.bscCodigoCliente.ColumnasOcultas = Nothing
        Me.bscCodigoCliente.ColumnasTitulos = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(70, 75)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(100, 23)
        Me.bscCodigoCliente.TabIndex = 9
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(67, 63)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 8
        Me.lblCodigoCliente.Text = "Codigo"
        '
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(8, 78)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 7
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(804, 62)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 45)
        Me.btnConsultar.TabIndex = 20
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbActualizarVersion, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(934, 29)
        Me.tstBarra.TabIndex = 6
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
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
        'tsbActualizarVersion
        '
        Me.tsbActualizarVersion.Enabled = False
        Me.tsbActualizarVersion.Image = Global.Eniac.Win.My.Resources.Resources.files_config_48
        Me.tsbActualizarVersion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbActualizarVersion.Name = "tsbActualizarVersion"
        Me.tsbActualizarVersion.Size = New System.Drawing.Size(150, 26)
        Me.tsbActualizarVersion.Text = "Actualizar a versión ...."
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'AdministracionDeVersiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 562)
        Me.Controls.Add(Me.tbcEnvioMail)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.sspPie)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdministracionDeVersiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de Versiones"
        Me.tbcEnvioMail.ResumeLayout(False)
        Me.tbpClientes.ResumeLayout(False)
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sspPie.ResumeLayout(False)
        Me.sspPie.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents ugClientes As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents sspPie As System.Windows.Forms.StatusStrip
   Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoriaCliente As Eniac.Controles.Label
   Friend WithEvents lblComenzarPorNombreCliente As Eniac.Controles.Label
   Friend WithEvents txtComenzarPorNombreCliente As Eniac.Controles.TextBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents DialogoAbrirArchivo As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbCobrador As Eniac.Controles.CheckBox
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
   Friend WithEvents lblVersionDesde As Eniac.Controles.Label
   Friend WithEvents lblVersionHasta As Eniac.Controles.Label
   Friend WithEvents lblVersion As Eniac.Controles.Label
   Friend WithEvents tbcEnvioMail As System.Windows.Forms.TabControl
   Friend WithEvents tbpClientes As System.Windows.Forms.TabPage
   Friend WithEvents cmbAplicacion As Eniac.Controles.ComboBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents cmbVersionHasta As Eniac.Controles.ComboBox
   Friend WithEvents cmbVersionDesde As Eniac.Controles.ComboBox
   Friend WithEvents cmbCategoriasClientes As Eniac.Win.ComboBoxCategorias
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents tsbActualizarVersion As System.Windows.Forms.ToolStripButton
End Class
