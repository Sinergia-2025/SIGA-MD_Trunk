<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadListadoLibroMayor
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadListadoLibroMayor))
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimirPrediseñado = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.fraFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbCentroCosto = New Eniac.Controles.ComboBox()
      Me.lblCentroCosto = New Eniac.Controles.Label()
      Me.chbMostrarCentroCosto = New Eniac.Controles.CheckBox()
      Me.chbMostrarComprobanteOrigen = New Eniac.Controles.CheckBox()
      Me.chbSaldoInicial = New Eniac.Controles.CheckBox()
      Me.chbCentroCosto = New Eniac.Controles.CheckBox()
      Me.chbReferencia = New Eniac.Controles.CheckBox()
      Me.cmbTipoReferencia = New Eniac.Controles.ComboBox()
      Me.bscCodigoReferencia = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscReferencia = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.radRango = New System.Windows.Forms.RadioButton()
      Me.radUnaCuenta = New System.Windows.Forms.RadioButton()
      Me.cmbPlanEnArbolHasta = New System.Windows.Forms.Button()
      Me.cmbPlanEnArbol = New System.Windows.Forms.Button()
      Me.lblDesc = New Eniac.Controles.Label()
      Me.bscDescripcionHasta = New Eniac.Controles.Buscador()
      Me.bscDescripcion = New Eniac.Controles.Buscador()
      Me.bscCodCuentaHasta = New Eniac.Controles.Buscador()
      Me.bscCodCuenta = New Eniac.Controles.Buscador()
      Me.lblCta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lbldesde = New Eniac.Controles.Label()
      Me.cmbPlan = New Eniac.Controles.ComboBox()
      Me.lblPlan = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.Label3 = New Eniac.Controles.Label()
      Me.clbSucursales = New Eniac.Controles.CheckedListBox()
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.fraFiltros.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
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
      Me.ugDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
      Me.ugDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
      Me.ugDetalle.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
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
      Me.ugDetalle.Location = New System.Drawing.Point(11, 244)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(951, 275)
      Me.ugDetalle.TabIndex = 1
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 529)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(974, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(895, 17)
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimirPrediseñado, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(974, 29)
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
      'tsbImprimirPrediseñado
      '
      Me.tsbImprimirPrediseñado.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimirPrediseñado.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimirPrediseñado.Name = "tsbImprimirPrediseñado"
      Me.tsbImprimirPrediseñado.Size = New System.Drawing.Size(147, 26)
      Me.tsbImprimirPrediseñado.Text = "&Imprimir Prediseñado"
      Me.tsbImprimirPrediseñado.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'fraFiltros
      '
      Me.fraFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.fraFiltros.Controls.Add(Me.cmbCentroCosto)
      Me.fraFiltros.Controls.Add(Me.lblCentroCosto)
      Me.fraFiltros.Controls.Add(Me.chbMostrarCentroCosto)
      Me.fraFiltros.Controls.Add(Me.chbMostrarComprobanteOrigen)
      Me.fraFiltros.Controls.Add(Me.chbSaldoInicial)
      Me.fraFiltros.Controls.Add(Me.chbCentroCosto)
      Me.fraFiltros.Controls.Add(Me.chbReferencia)
      Me.fraFiltros.Controls.Add(Me.cmbTipoReferencia)
      Me.fraFiltros.Controls.Add(Me.bscCodigoReferencia)
      Me.fraFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.fraFiltros.Controls.Add(Me.bscReferencia)
      Me.fraFiltros.Controls.Add(Me.lblNombre)
      Me.fraFiltros.Controls.Add(Me.dtpHasta)
      Me.fraFiltros.Controls.Add(Me.lblHasta)
      Me.fraFiltros.Controls.Add(Me.GroupBox1)
      Me.fraFiltros.Controls.Add(Me.dtpDesde)
      Me.fraFiltros.Controls.Add(Me.lbldesde)
      Me.fraFiltros.Controls.Add(Me.cmbPlan)
      Me.fraFiltros.Controls.Add(Me.btnConsultar)
      Me.fraFiltros.Controls.Add(Me.lblPlan)
      Me.fraFiltros.Controls.Add(Me.Label3)
      Me.fraFiltros.Controls.Add(Me.clbSucursales)
      Me.fraFiltros.Location = New System.Drawing.Point(12, 32)
      Me.fraFiltros.Name = "fraFiltros"
      Me.fraFiltros.Size = New System.Drawing.Size(951, 206)
      Me.fraFiltros.TabIndex = 0
      Me.fraFiltros.TabStop = False
      Me.fraFiltros.Text = "Filtros"
      '
      'cmbCentroCosto
      '
      Me.cmbCentroCosto.BindearPropiedadControl = Nothing
      Me.cmbCentroCosto.BindearPropiedadEntidad = Nothing
      Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCentroCosto.Enabled = False
      Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCentroCosto.FormattingEnabled = True
      Me.cmbCentroCosto.IsPK = False
      Me.cmbCentroCosto.IsRequired = False
      Me.cmbCentroCosto.Key = Nothing
      Me.cmbCentroCosto.LabelAsoc = Me.lblCentroCosto
      Me.cmbCentroCosto.Location = New System.Drawing.Point(249, 177)
      Me.cmbCentroCosto.Name = "cmbCentroCosto"
      Me.cmbCentroCosto.Size = New System.Drawing.Size(138, 21)
      Me.cmbCentroCosto.TabIndex = 19
      '
      'lblCentroCosto
      '
      Me.lblCentroCosto.AutoSize = True
      Me.lblCentroCosto.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCentroCosto.Location = New System.Drawing.Point(156, 181)
      Me.lblCentroCosto.Name = "lblCentroCosto"
      Me.lblCentroCosto.Size = New System.Drawing.Size(87, 13)
      Me.lblCentroCosto.TabIndex = 18
      Me.lblCentroCosto.Text = "Centro de costos"
      Me.lblCentroCosto.Visible = False
      '
      'chbMostrarCentroCosto
      '
      Me.chbMostrarCentroCosto.AutoSize = True
      Me.chbMostrarCentroCosto.BindearPropiedadControl = Nothing
      Me.chbMostrarCentroCosto.BindearPropiedadEntidad = Nothing
      Me.chbMostrarCentroCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMostrarCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMostrarCentroCosto.IsPK = False
      Me.chbMostrarCentroCosto.IsRequired = False
      Me.chbMostrarCentroCosto.Key = Nothing
      Me.chbMostrarCentroCosto.LabelAsoc = Nothing
      Me.chbMostrarCentroCosto.Location = New System.Drawing.Point(402, 181)
      Me.chbMostrarCentroCosto.Name = "chbMostrarCentroCosto"
      Me.chbMostrarCentroCosto.Size = New System.Drawing.Size(197, 17)
      Me.chbMostrarCentroCosto.TabIndex = 10
      Me.chbMostrarCentroCosto.Text = "Mostrar Centro de Costos en el Libro"
      Me.chbMostrarCentroCosto.UseVisualStyleBackColor = True
      '
      'chbMostrarComprobanteOrigen
      '
      Me.chbMostrarComprobanteOrigen.AutoSize = True
      Me.chbMostrarComprobanteOrigen.BindearPropiedadControl = Nothing
      Me.chbMostrarComprobanteOrigen.BindearPropiedadEntidad = Nothing
      Me.chbMostrarComprobanteOrigen.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMostrarComprobanteOrigen.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMostrarComprobanteOrigen.IsPK = False
      Me.chbMostrarComprobanteOrigen.IsRequired = False
      Me.chbMostrarComprobanteOrigen.Key = Nothing
      Me.chbMostrarComprobanteOrigen.LabelAsoc = Nothing
      Me.chbMostrarComprobanteOrigen.Location = New System.Drawing.Point(92, 117)
      Me.chbMostrarComprobanteOrigen.Name = "chbMostrarComprobanteOrigen"
      Me.chbMostrarComprobanteOrigen.Size = New System.Drawing.Size(196, 17)
      Me.chbMostrarComprobanteOrigen.TabIndex = 10
      Me.chbMostrarComprobanteOrigen.Text = "Mostrar comprobante que dio origen"
      Me.chbMostrarComprobanteOrigen.UseVisualStyleBackColor = True
      '
      'chbSaldoInicial
      '
      Me.chbSaldoInicial.AutoSize = True
      Me.chbSaldoInicial.BindearPropiedadControl = Nothing
      Me.chbSaldoInicial.BindearPropiedadEntidad = Nothing
      Me.chbSaldoInicial.Checked = True
      Me.chbSaldoInicial.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbSaldoInicial.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSaldoInicial.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSaldoInicial.IsPK = False
      Me.chbSaldoInicial.IsRequired = False
      Me.chbSaldoInicial.Key = Nothing
      Me.chbSaldoInicial.LabelAsoc = Nothing
      Me.chbSaldoInicial.Location = New System.Drawing.Point(679, 14)
      Me.chbSaldoInicial.Name = "chbSaldoInicial"
      Me.chbSaldoInicial.Size = New System.Drawing.Size(111, 17)
      Me.chbSaldoInicial.TabIndex = 8
      Me.chbSaldoInicial.Text = "Incluir saldo inicial"
      Me.chbSaldoInicial.UseVisualStyleBackColor = True
      '
      'chbCentroCosto
      '
      Me.chbCentroCosto.AutoSize = True
      Me.chbCentroCosto.BindearPropiedadControl = Nothing
      Me.chbCentroCosto.BindearPropiedadEntidad = Nothing
      Me.chbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCentroCosto.IsPK = False
      Me.chbCentroCosto.IsRequired = False
      Me.chbCentroCosto.Key = Nothing
      Me.chbCentroCosto.LabelAsoc = Nothing
      Me.chbCentroCosto.Location = New System.Drawing.Point(139, 181)
      Me.chbCentroCosto.Name = "chbCentroCosto"
      Me.chbCentroCosto.Size = New System.Drawing.Size(15, 14)
      Me.chbCentroCosto.TabIndex = 17
      Me.chbCentroCosto.UseVisualStyleBackColor = True
      '
      'chbReferencia
      '
      Me.chbReferencia.AutoSize = True
      Me.chbReferencia.BindearPropiedadControl = Nothing
      Me.chbReferencia.BindearPropiedadEntidad = Nothing
      Me.chbReferencia.ForeColorFocus = System.Drawing.Color.Red
      Me.chbReferencia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbReferencia.IsPK = False
      Me.chbReferencia.IsRequired = False
      Me.chbReferencia.Key = Nothing
      Me.chbReferencia.LabelAsoc = Nothing
      Me.chbReferencia.Location = New System.Drawing.Point(139, 151)
      Me.chbReferencia.Name = "chbReferencia"
      Me.chbReferencia.Size = New System.Drawing.Size(78, 17)
      Me.chbReferencia.TabIndex = 11
      Me.chbReferencia.Text = "Referencia"
      Me.chbReferencia.UseVisualStyleBackColor = True
      '
      'cmbTipoReferencia
      '
      Me.cmbTipoReferencia.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoReferencia.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.cmbTipoReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoReferencia.Enabled = False
      Me.cmbTipoReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoReferencia.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoReferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoReferencia.FormattingEnabled = True
      Me.cmbTipoReferencia.IsPK = False
      Me.cmbTipoReferencia.IsRequired = True
      Me.cmbTipoReferencia.Key = Nothing
      Me.cmbTipoReferencia.LabelAsoc = Nothing
      Me.cmbTipoReferencia.Location = New System.Drawing.Point(223, 149)
      Me.cmbTipoReferencia.Name = "cmbTipoReferencia"
      Me.cmbTipoReferencia.Size = New System.Drawing.Size(90, 21)
      Me.cmbTipoReferencia.TabIndex = 12
      '
      'bscCodigoReferencia
      '
      Me.bscCodigoReferencia.AyudaAncho = 608
      Me.bscCodigoReferencia.BindearPropiedadControl = Nothing
      Me.bscCodigoReferencia.BindearPropiedadEntidad = Nothing
      Me.bscCodigoReferencia.ColumnasAlineacion = Nothing
      Me.bscCodigoReferencia.ColumnasAncho = Nothing
      Me.bscCodigoReferencia.ColumnasFormato = Nothing
      Me.bscCodigoReferencia.ColumnasOcultas = Nothing
      Me.bscCodigoReferencia.ColumnasTitulos = Nothing
      Me.bscCodigoReferencia.Datos = Nothing
      Me.bscCodigoReferencia.Enabled = False
      Me.bscCodigoReferencia.FilaDevuelta = Nothing
      Me.bscCodigoReferencia.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoReferencia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoReferencia.IsDecimal = False
      Me.bscCodigoReferencia.IsNumber = False
      Me.bscCodigoReferencia.IsPK = False
      Me.bscCodigoReferencia.IsRequired = False
      Me.bscCodigoReferencia.Key = ""
      Me.bscCodigoReferencia.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoReferencia.Location = New System.Drawing.Point(319, 148)
      Me.bscCodigoReferencia.MaxLengh = "32767"
      Me.bscCodigoReferencia.Name = "bscCodigoReferencia"
      Me.bscCodigoReferencia.Permitido = True
      Me.bscCodigoReferencia.Selecciono = False
      Me.bscCodigoReferencia.Size = New System.Drawing.Size(96, 23)
      Me.bscCodigoReferencia.TabIndex = 14
      Me.bscCodigoReferencia.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(316, 133)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 13
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscReferencia
      '
      Me.bscReferencia.AutoSize = True
      Me.bscReferencia.AyudaAncho = 608
      Me.bscReferencia.BindearPropiedadControl = Nothing
      Me.bscReferencia.BindearPropiedadEntidad = Nothing
      Me.bscReferencia.ColumnasAlineacion = Nothing
      Me.bscReferencia.ColumnasAncho = Nothing
      Me.bscReferencia.ColumnasFormato = Nothing
      Me.bscReferencia.ColumnasOcultas = Nothing
      Me.bscReferencia.ColumnasTitulos = Nothing
      Me.bscReferencia.Datos = Nothing
      Me.bscReferencia.Enabled = False
      Me.bscReferencia.FilaDevuelta = Nothing
      Me.bscReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscReferencia.ForeColorFocus = System.Drawing.Color.Red
      Me.bscReferencia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscReferencia.IsDecimal = False
      Me.bscReferencia.IsNumber = False
      Me.bscReferencia.IsPK = False
      Me.bscReferencia.IsRequired = False
      Me.bscReferencia.Key = ""
      Me.bscReferencia.LabelAsoc = Me.lblNombre
      Me.bscReferencia.Location = New System.Drawing.Point(420, 148)
      Me.bscReferencia.Margin = New System.Windows.Forms.Padding(4)
      Me.bscReferencia.MaxLengh = "32767"
      Me.bscReferencia.Name = "bscReferencia"
      Me.bscReferencia.Permitido = True
      Me.bscReferencia.Selecciono = False
      Me.bscReferencia.Size = New System.Drawing.Size(413, 23)
      Me.bscReferencia.TabIndex = 16
      Me.bscReferencia.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(417, 132)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 15
      Me.lblNombre.Text = "Nombre"
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = ""
      Me.dtpHasta.BindearPropiedadEntidad = ""
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(573, 12)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(89, 20)
      Me.dtpHasta.TabIndex = 7
      Me.dtpHasta.Value = New Date(2012, 7, 2, 23, 27, 0, 0)
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(501, 16)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(68, 13)
      Me.lblHasta.TabIndex = 6
      Me.lblHasta.Text = "Fecha Hasta"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.radRango)
      Me.GroupBox1.Controls.Add(Me.radUnaCuenta)
      Me.GroupBox1.Controls.Add(Me.cmbPlanEnArbolHasta)
      Me.GroupBox1.Controls.Add(Me.cmbPlanEnArbol)
      Me.GroupBox1.Controls.Add(Me.lblDesc)
      Me.GroupBox1.Controls.Add(Me.bscDescripcionHasta)
      Me.GroupBox1.Controls.Add(Me.bscDescripcion)
      Me.GroupBox1.Controls.Add(Me.bscCodCuentaHasta)
      Me.GroupBox1.Controls.Add(Me.bscCodCuenta)
      Me.GroupBox1.Controls.Add(Me.lblCta)
      Me.GroupBox1.Location = New System.Drawing.Point(310, 35)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(635, 95)
      Me.GroupBox1.TabIndex = 9
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Cuenta"
      '
      'radRango
      '
      Me.radRango.AutoSize = True
      Me.radRango.Location = New System.Drawing.Point(244, 9)
      Me.radRango.Name = "radRango"
      Me.radRango.Size = New System.Drawing.Size(113, 17)
      Me.radRango.TabIndex = 1
      Me.radRango.Text = "Rango de cuentas"
      Me.radRango.UseVisualStyleBackColor = True
      '
      'radUnaCuenta
      '
      Me.radUnaCuenta.AutoSize = True
      Me.radUnaCuenta.Checked = True
      Me.radUnaCuenta.Location = New System.Drawing.Point(77, 9)
      Me.radUnaCuenta.Name = "radUnaCuenta"
      Me.radUnaCuenta.Size = New System.Drawing.Size(154, 17)
      Me.radUnaCuenta.TabIndex = 0
      Me.radUnaCuenta.TabStop = True
      Me.radUnaCuenta.Text = "Una Cuenta (y subcuentas)"
      Me.radUnaCuenta.UseVisualStyleBackColor = True
      '
      'cmbPlanEnArbolHasta
      '
      Me.cmbPlanEnArbolHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbPlanEnArbolHasta.Enabled = False
      Me.cmbPlanEnArbolHasta.Location = New System.Drawing.Point(529, 65)
      Me.cmbPlanEnArbolHasta.Name = "cmbPlanEnArbolHasta"
      Me.cmbPlanEnArbolHasta.Size = New System.Drawing.Size(103, 23)
      Me.cmbPlanEnArbolHasta.TabIndex = 9
      Me.cmbPlanEnArbolHasta.TabStop = False
      Me.cmbPlanEnArbolHasta.Text = "Ver Plan..."
      Me.cmbPlanEnArbolHasta.UseVisualStyleBackColor = True
      '
      'cmbPlanEnArbol
      '
      Me.cmbPlanEnArbol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbPlanEnArbol.Location = New System.Drawing.Point(529, 39)
      Me.cmbPlanEnArbol.Name = "cmbPlanEnArbol"
      Me.cmbPlanEnArbol.Size = New System.Drawing.Size(103, 23)
      Me.cmbPlanEnArbol.TabIndex = 6
      Me.cmbPlanEnArbol.TabStop = False
      Me.cmbPlanEnArbol.Text = "Ver Plan..."
      Me.cmbPlanEnArbol.UseVisualStyleBackColor = True
      '
      'lblDesc
      '
      Me.lblDesc.AutoSize = True
      Me.lblDesc.Location = New System.Drawing.Point(107, 26)
      Me.lblDesc.Name = "lblDesc"
      Me.lblDesc.Size = New System.Drawing.Size(63, 13)
      Me.lblDesc.TabIndex = 4
      Me.lblDesc.Text = "Descripción"
      '
      'bscDescripcionHasta
      '
      Me.bscDescripcionHasta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscDescripcionHasta.AyudaAncho = 608
      Me.bscDescripcionHasta.BindearPropiedadControl = Nothing
      Me.bscDescripcionHasta.BindearPropiedadEntidad = Nothing
      Me.bscDescripcionHasta.ColumnasAlineacion = Nothing
      Me.bscDescripcionHasta.ColumnasAncho = Nothing
      Me.bscDescripcionHasta.ColumnasFormato = Nothing
      Me.bscDescripcionHasta.ColumnasOcultas = Nothing
      Me.bscDescripcionHasta.ColumnasTitulos = Nothing
      Me.bscDescripcionHasta.Datos = Nothing
      Me.bscDescripcionHasta.Enabled = False
      Me.bscDescripcionHasta.FilaDevuelta = Nothing
      Me.bscDescripcionHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDescripcionHasta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDescripcionHasta.IsDecimal = False
      Me.bscDescripcionHasta.IsNumber = False
      Me.bscDescripcionHasta.IsPK = False
      Me.bscDescripcionHasta.IsRequired = False
      Me.bscDescripcionHasta.Key = ""
      Me.bscDescripcionHasta.LabelAsoc = Nothing
      Me.bscDescripcionHasta.Location = New System.Drawing.Point(110, 68)
      Me.bscDescripcionHasta.MaxLengh = "32767"
      Me.bscDescripcionHasta.Name = "bscDescripcionHasta"
      Me.bscDescripcionHasta.Permitido = True
      Me.bscDescripcionHasta.Selecciono = False
      Me.bscDescripcionHasta.Size = New System.Drawing.Size(413, 20)
      Me.bscDescripcionHasta.TabIndex = 8
      Me.bscDescripcionHasta.Titulo = Nothing
      '
      'bscDescripcion
      '
      Me.bscDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
      Me.bscDescripcion.Location = New System.Drawing.Point(110, 42)
      Me.bscDescripcion.MaxLengh = "32767"
      Me.bscDescripcion.Name = "bscDescripcion"
      Me.bscDescripcion.Permitido = True
      Me.bscDescripcion.Selecciono = False
      Me.bscDescripcion.Size = New System.Drawing.Size(413, 20)
      Me.bscDescripcion.TabIndex = 5
      Me.bscDescripcion.Titulo = Nothing
      '
      'bscCodCuentaHasta
      '
      Me.bscCodCuentaHasta.AyudaAncho = 608
      Me.bscCodCuentaHasta.BindearPropiedadControl = Nothing
      Me.bscCodCuentaHasta.BindearPropiedadEntidad = Nothing
      Me.bscCodCuentaHasta.ColumnasAlineacion = Nothing
      Me.bscCodCuentaHasta.ColumnasAncho = Nothing
      Me.bscCodCuentaHasta.ColumnasFormato = Nothing
      Me.bscCodCuentaHasta.ColumnasOcultas = Nothing
      Me.bscCodCuentaHasta.ColumnasTitulos = Nothing
      Me.bscCodCuentaHasta.Datos = Nothing
      Me.bscCodCuentaHasta.Enabled = False
      Me.bscCodCuentaHasta.FilaDevuelta = Nothing
      Me.bscCodCuentaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodCuentaHasta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodCuentaHasta.IsDecimal = False
      Me.bscCodCuentaHasta.IsNumber = True
      Me.bscCodCuentaHasta.IsPK = False
      Me.bscCodCuentaHasta.IsRequired = False
      Me.bscCodCuentaHasta.Key = ""
      Me.bscCodCuentaHasta.LabelAsoc = Nothing
      Me.bscCodCuentaHasta.Location = New System.Drawing.Point(10, 68)
      Me.bscCodCuentaHasta.MaxLengh = "32767"
      Me.bscCodCuentaHasta.Name = "bscCodCuentaHasta"
      Me.bscCodCuentaHasta.Permitido = True
      Me.bscCodCuentaHasta.Selecciono = False
      Me.bscCodCuentaHasta.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuentaHasta.TabIndex = 7
      Me.bscCodCuentaHasta.Titulo = Nothing
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
      Me.bscCodCuenta.Location = New System.Drawing.Point(10, 42)
      Me.bscCodCuenta.MaxLengh = "32767"
      Me.bscCodCuenta.Name = "bscCodCuenta"
      Me.bscCodCuenta.Permitido = True
      Me.bscCodCuenta.Selecciono = False
      Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuenta.TabIndex = 3
      Me.bscCodCuenta.Titulo = Nothing
      '
      'lblCta
      '
      Me.lblCta.AutoSize = True
      Me.lblCta.Location = New System.Drawing.Point(7, 26)
      Me.lblCta.Name = "lblCta"
      Me.lblCta.Size = New System.Drawing.Size(40, 13)
      Me.lblCta.TabIndex = 2
      Me.lblCta.Text = "Código"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = ""
      Me.dtpDesde.BindearPropiedadEntidad = ""
      Me.dtpDesde.Checked = False
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lbldesde
      Me.dtpDesde.Location = New System.Drawing.Point(391, 12)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.ShowCheckBox = True
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 5
      Me.dtpDesde.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
      '
      'lbldesde
      '
      Me.lbldesde.AutoSize = True
      Me.lbldesde.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lbldesde.Location = New System.Drawing.Point(316, 16)
      Me.lbldesde.Name = "lbldesde"
      Me.lbldesde.Size = New System.Drawing.Size(71, 13)
      Me.lbldesde.TabIndex = 4
      Me.lbldesde.Text = "Fecha Desde"
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
      Me.cmbPlan.Location = New System.Drawing.Point(92, 84)
      Me.cmbPlan.Name = "cmbPlan"
      Me.cmbPlan.Size = New System.Drawing.Size(196, 21)
      Me.cmbPlan.TabIndex = 3
      '
      'lblPlan
      '
      Me.lblPlan.AutoSize = True
      Me.lblPlan.Location = New System.Drawing.Point(6, 87)
      Me.lblPlan.Name = "lblPlan"
      Me.lblPlan.Size = New System.Drawing.Size(80, 13)
      Me.lblPlan.TabIndex = 2
      Me.lblPlan.Text = "Plan de Cuenta"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(845, 155)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 20
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(6, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Sucursales"
      '
      'clbSucursales
      '
      Me.clbSucursales.CheckOnClick = True
      Me.clbSucursales.FormattingEnabled = True
      Me.clbSucursales.Location = New System.Drawing.Point(92, 24)
      Me.clbSucursales.Name = "clbSucursales"
      Me.clbSucursales.Size = New System.Drawing.Size(196, 49)
      Me.clbSucursales.TabIndex = 1
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance13
      Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
      Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
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
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'ContabilidadListadoLibroMayor
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(974, 551)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.fraFiltros)
      Me.KeyPreview = True
      Me.Name = "ContabilidadListadoLibroMayor"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Libro Mayor"
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.fraFiltros.ResumeLayout(False)
      Me.fraFiltros.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
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
   Friend WithEvents tsbImprimirPrediseñado As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents cmbPlanEnArbol As System.Windows.Forms.Button
   Friend WithEvents lblDesc As Eniac.Controles.Label
   Friend WithEvents bscDescripcion As Eniac.Controles.Buscador
   Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador
   Friend WithEvents lblCta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lbldesde As Eniac.Controles.Label
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbReferencia As Eniac.Controles.CheckBox
   Friend WithEvents cmbTipoReferencia As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoReferencia As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscReferencia As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbMostrarComprobanteOrigen As Eniac.Controles.CheckBox
   Friend WithEvents chbSaldoInicial As Eniac.Controles.CheckBox
   Friend WithEvents radRango As System.Windows.Forms.RadioButton
   Friend WithEvents radUnaCuenta As System.Windows.Forms.RadioButton
   Friend WithEvents cmbPlanEnArbolHasta As System.Windows.Forms.Button
   Friend WithEvents bscDescripcionHasta As Eniac.Controles.Buscador
   Friend WithEvents bscCodCuentaHasta As Eniac.Controles.Buscador
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents cmbCentroCosto As Eniac.Controles.ComboBox
   Friend WithEvents lblCentroCosto As Eniac.Controles.Label
   Friend WithEvents chbCentroCosto As Eniac.Controles.CheckBox
   Friend WithEvents chbMostrarCentroCosto As Eniac.Controles.CheckBox
End Class
