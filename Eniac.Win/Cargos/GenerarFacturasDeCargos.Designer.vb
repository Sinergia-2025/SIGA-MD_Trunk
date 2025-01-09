<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarFacturasDeCargos
   'Inherits BaseForm
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteExpensas")
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteVarios")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAlquiler")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotalAdicionales")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerarFacturasDeCargos))
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.toolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbEliminarFacturas = New System.Windows.Forms.ToolStripButton()
      Me.tss4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGenerarFacturas = New System.Windows.Forms.ToolStripButton()
      Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tss5 = New System.Windows.Forms.ToolStripSeparator()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbTiposLiquidacion = New Eniac.Controles.ComboBox()
      Me.txtTotalGastosOperativos = New Eniac.Controles.TextBox()
      Me.lblTotalGastosOperativos = New Eniac.Controles.Label()
      Me.dtpPeriodo = New Eniac.Controles.DateTimePicker()
      Me.lblPeriodo = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.lblFechaComprobantes = New Eniac.Controles.Label()
      Me.dtpFechaComprobantes = New Eniac.Controles.DateTimePicker()
      Me.grpFactura = New System.Windows.Forms.GroupBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.txtObservaciones = New Eniac.Controles.TextBox()
      Me.lblObservaciones = New Eniac.Controles.Label()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.lblVencimiento = New Eniac.Controles.Label()
      Me.dtpVencimiento = New Eniac.Controles.DateTimePicker()
      Me.stsStado.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.grpFactura.SuspendLayout()
      Me.SuspendLayout()
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.toolStripProgressBar1, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 540)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(952, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(873, 17)
      Me.tssInfo.Spring = True
      '
      'toolStripProgressBar1
      '
      Me.toolStripProgressBar1.Name = "toolStripProgressBar1"
      Me.toolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
      Me.toolStripProgressBar1.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Cliente"
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Width = 170
      UltraGridColumn3.Header.Caption = "Categoria Cliente"
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Width = 155
      Appearance1.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance1
      UltraGridColumn7.Format = "N2"
      UltraGridColumn7.Header.Caption = "$ Expensas"
      UltraGridColumn7.Header.VisiblePosition = 4
      UltraGridColumn7.Hidden = True
      UltraGridColumn7.Width = 80
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance2
      UltraGridColumn8.Format = "N2"
      UltraGridColumn8.Header.Caption = "Cargos"
      UltraGridColumn8.Header.VisiblePosition = 5
      UltraGridColumn8.Width = 104
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance3
      UltraGridColumn9.Format = "N2"
      UltraGridColumn9.Header.Caption = "$ Alquiler"
      UltraGridColumn9.Header.VisiblePosition = 6
      UltraGridColumn9.Hidden = True
      UltraGridColumn9.Width = 80
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn10.CellAppearance = Appearance4
      UltraGridColumn10.Format = "N2"
      UltraGridColumn10.Header.Caption = "Total"
      UltraGridColumn10.Header.VisiblePosition = 8
      UltraGridColumn10.Hidden = True
      UltraGridColumn10.Width = 70
      UltraGridColumn11.Header.VisiblePosition = 7
      UltraGridColumn11.Hidden = True
      UltraGridColumn6.Header.Caption = "Comprobante"
      UltraGridColumn6.Header.VisiblePosition = 9
      UltraGridColumn6.Width = 107
      UltraGridColumn17.Header.Caption = "Let"
      UltraGridColumn17.Header.VisiblePosition = 10
      UltraGridColumn17.Width = 37
      UltraGridColumn18.Header.Caption = "Emisor"
      UltraGridColumn18.Header.VisiblePosition = 11
      UltraGridColumn18.Width = 56
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn19.CellAppearance = Appearance5
      UltraGridColumn19.Header.Caption = "Numero "
      UltraGridColumn19.Header.VisiblePosition = 12
      UltraGridColumn19.Width = 78
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance6
      UltraGridColumn5.Format = "N2"
      UltraGridColumn5.Header.Caption = "Importe Total"
      UltraGridColumn5.Header.VisiblePosition = 13
      UltraGridColumn5.Width = 93
      UltraGridColumn4.Header.Caption = "Codigo"
      UltraGridColumn4.Header.VisiblePosition = 1
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn6, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn5, UltraGridColumn4})
      UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
      Appearance7.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Appearance8.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.FixedHeaderAppearance = Appearance8
      Appearance9.ForeColor = System.Drawing.Color.ForestGreen
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Appearance10.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance10
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance11
      Appearance12.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(8, 123)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(936, 414)
      Me.ugDetalle.TabIndex = 2
      Me.ugDetalle.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'tss1
      '
      Me.tss1.Name = "tss1"
      Me.tss1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbEliminarFacturas
      '
      Me.tsbEliminarFacturas.Enabled = False
      Me.tsbEliminarFacturas.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.tsbEliminarFacturas.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEliminarFacturas.Name = "tsbEliminarFacturas"
      Me.tsbEliminarFacturas.Size = New System.Drawing.Size(123, 26)
      Me.tsbEliminarFacturas.Text = "&Eliminar Facturas"
      '
      'tss4
      '
      Me.tss4.Name = "tss4"
      Me.tss4.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Enabled = False
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
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbGenerarFacturas, Me.tss2, Me.tsbEliminarFacturas, Me.tss3, Me.tsbImprimir, Me.tss4, Me.tsddExportar, Me.tss5, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(952, 29)
      Me.tstBarra.TabIndex = 4
      '
      'tsbGenerarFacturas
      '
      Me.tsbGenerarFacturas.Enabled = False
      Me.tsbGenerarFacturas.Image = Global.Eniac.Win.My.Resources.Resources.form_yellow
      Me.tsbGenerarFacturas.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGenerarFacturas.Name = "tsbGenerarFacturas"
      Me.tsbGenerarFacturas.Size = New System.Drawing.Size(121, 26)
      Me.tsbGenerarFacturas.Text = "Generar &Facturas"
      '
      'tss2
      '
      Me.tss2.Name = "tss2"
      Me.tss2.Size = New System.Drawing.Size(6, 29)
      '
      'tss3
      '
      Me.tss3.Name = "tss3"
      Me.tss3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Enabled = False
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'tss5
      '
      Me.tss5.Name = "tss5"
      Me.tss5.Size = New System.Drawing.Size(6, 29)
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
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.Label1)
      Me.grbFiltros.Controls.Add(Me.cmbTiposLiquidacion)
      Me.grbFiltros.Controls.Add(Me.txtTotalGastosOperativos)
      Me.grbFiltros.Controls.Add(Me.lblTotalGastosOperativos)
      Me.grbFiltros.Controls.Add(Me.dtpPeriodo)
      Me.grbFiltros.Controls.Add(Me.lblPeriodo)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chkExpandAll)
      Me.grbFiltros.Location = New System.Drawing.Point(8, 32)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(348, 85)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(7, 40)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(85, 13)
      Me.Label1.TabIndex = 58
      Me.Label1.Text = "Tipo Liquidacion"
      '
      'cmbTiposLiquidacion
      '
      Me.cmbTiposLiquidacion.BindearPropiedadControl = ""
      Me.cmbTiposLiquidacion.BindearPropiedadEntidad = ""
      Me.cmbTiposLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposLiquidacion.FormattingEnabled = True
      Me.cmbTiposLiquidacion.IsPK = False
      Me.cmbTiposLiquidacion.IsRequired = True
      Me.cmbTiposLiquidacion.Key = Nothing
      Me.cmbTiposLiquidacion.LabelAsoc = Nothing
      Me.cmbTiposLiquidacion.Location = New System.Drawing.Point(102, 36)
      Me.cmbTiposLiquidacion.Name = "cmbTiposLiquidacion"
      Me.cmbTiposLiquidacion.Size = New System.Drawing.Size(120, 21)
      Me.cmbTiposLiquidacion.TabIndex = 57
      '
      'txtTotalGastosOperativos
      '
      Me.txtTotalGastosOperativos.BindearPropiedadControl = ""
      Me.txtTotalGastosOperativos.BindearPropiedadEntidad = ""
      Me.txtTotalGastosOperativos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalGastosOperativos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalGastosOperativos.Formato = "N2"
      Me.txtTotalGastosOperativos.IsDecimal = True
      Me.txtTotalGastosOperativos.IsNumber = True
      Me.txtTotalGastosOperativos.IsPK = False
      Me.txtTotalGastosOperativos.IsRequired = False
      Me.txtTotalGastosOperativos.Key = ""
      Me.txtTotalGastosOperativos.LabelAsoc = Me.lblTotalGastosOperativos
      Me.txtTotalGastosOperativos.Location = New System.Drawing.Point(102, 60)
      Me.txtTotalGastosOperativos.MaxLength = 12
      Me.txtTotalGastosOperativos.Name = "txtTotalGastosOperativos"
      Me.txtTotalGastosOperativos.ReadOnly = True
      Me.txtTotalGastosOperativos.Size = New System.Drawing.Size(80, 20)
      Me.txtTotalGastosOperativos.TabIndex = 3
      Me.txtTotalGastosOperativos.Text = "0.00"
      Me.txtTotalGastosOperativos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalGastosOperativos
      '
      Me.lblTotalGastosOperativos.AutoSize = True
      Me.lblTotalGastosOperativos.LabelAsoc = Nothing
      Me.lblTotalGastosOperativos.Location = New System.Drawing.Point(7, 64)
      Me.lblTotalGastosOperativos.Name = "lblTotalGastosOperativos"
      Me.lblTotalGastosOperativos.Size = New System.Drawing.Size(80, 13)
      Me.lblTotalGastosOperativos.TabIndex = 2
      Me.lblTotalGastosOperativos.Text = "Total Liquidado"
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.BindearPropiedadControl = Nothing
      Me.dtpPeriodo.BindearPropiedadEntidad = Nothing
      Me.dtpPeriodo.CalendarMonthBackground = System.Drawing.Color.Tomato
      Me.dtpPeriodo.CustomFormat = "MM/yyyy"
      Me.dtpPeriodo.Enabled = False
      Me.dtpPeriodo.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPeriodo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.IsPK = False
      Me.dtpPeriodo.IsRequired = False
      Me.dtpPeriodo.Key = ""
      Me.dtpPeriodo.LabelAsoc = Me.lblPeriodo
      Me.dtpPeriodo.Location = New System.Drawing.Point(102, 14)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(65, 20)
      Me.dtpPeriodo.TabIndex = 1
      '
      'lblPeriodo
      '
      Me.lblPeriodo.AutoSize = True
      Me.lblPeriodo.LabelAsoc = Nothing
      Me.lblPeriodo.Location = New System.Drawing.Point(7, 18)
      Me.lblPeriodo.Name = "lblPeriodo"
      Me.lblPeriodo.Size = New System.Drawing.Size(45, 13)
      Me.lblPeriodo.TabIndex = 0
      Me.lblPeriodo.Text = "Período"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(238, 13)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(94, 45)
      Me.btnConsultar.TabIndex = 4
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(238, 62)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chkExpandAll.TabIndex = 5
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'lblFechaComprobantes
      '
      Me.lblFechaComprobantes.AutoSize = True
      Me.lblFechaComprobantes.LabelAsoc = Nothing
      Me.lblFechaComprobantes.Location = New System.Drawing.Point(8, 22)
      Me.lblFechaComprobantes.Name = "lblFechaComprobantes"
      Me.lblFechaComprobantes.Size = New System.Drawing.Size(43, 13)
      Me.lblFechaComprobantes.TabIndex = 0
      Me.lblFechaComprobantes.Text = "Emision"
      '
      'dtpFechaComprobantes
      '
      Me.dtpFechaComprobantes.BindearPropiedadControl = "Value"
      Me.dtpFechaComprobantes.BindearPropiedadEntidad = "FechaNovedad"
      Me.dtpFechaComprobantes.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaComprobantes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaComprobantes.IsPK = False
      Me.dtpFechaComprobantes.IsRequired = False
      Me.dtpFechaComprobantes.Key = ""
      Me.dtpFechaComprobantes.LabelAsoc = Me.lblFechaComprobantes
      Me.dtpFechaComprobantes.Location = New System.Drawing.Point(83, 18)
      Me.dtpFechaComprobantes.Name = "dtpFechaComprobantes"
      Me.dtpFechaComprobantes.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaComprobantes.TabIndex = 1
      '
      'grpFactura
      '
      Me.grpFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpFactura.Controls.Add(Me.cmbCajas)
      Me.grpFactura.Controls.Add(Me.lblCaja)
      Me.grpFactura.Controls.Add(Me.txtObservaciones)
      Me.grpFactura.Controls.Add(Me.lblObservaciones)
      Me.grpFactura.Controls.Add(Me.cmbFormaPago)
      Me.grpFactura.Controls.Add(Me.lblFormaPago)
      Me.grpFactura.Controls.Add(Me.lblVencimiento)
      Me.grpFactura.Controls.Add(Me.lblFechaComprobantes)
      Me.grpFactura.Controls.Add(Me.dtpVencimiento)
      Me.grpFactura.Controls.Add(Me.dtpFechaComprobantes)
      Me.grpFactura.Location = New System.Drawing.Point(362, 32)
      Me.grpFactura.Name = "grpFactura"
      Me.grpFactura.Size = New System.Drawing.Size(582, 85)
      Me.grpFactura.TabIndex = 1
      Me.grpFactura.TabStop = False
      Me.grpFactura.Text = "Datos para Facturar"
      Me.grpFactura.Visible = False
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
      Me.cmbCajas.Location = New System.Drawing.Point(442, 17)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
      Me.cmbCajas.TabIndex = 5
      '
      'lblCaja
      '
      Me.lblCaja.AutoSize = True
      Me.lblCaja.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCaja.LabelAsoc = Nothing
      Me.lblCaja.Location = New System.Drawing.Point(408, 22)
      Me.lblCaja.Name = "lblCaja"
      Me.lblCaja.Size = New System.Drawing.Size(28, 13)
      Me.lblCaja.TabIndex = 4
      Me.lblCaja.Text = "Caja"
      '
      'txtObservaciones
      '
      Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtObservaciones.BindearPropiedadControl = ""
      Me.txtObservaciones.BindearPropiedadEntidad = ""
      Me.txtObservaciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservaciones.Formato = "N2"
      Me.txtObservaciones.IsDecimal = False
      Me.txtObservaciones.IsNumber = False
      Me.txtObservaciones.IsPK = False
      Me.txtObservaciones.IsRequired = False
      Me.txtObservaciones.Key = ""
      Me.txtObservaciones.LabelAsoc = Me.lblObservaciones
      Me.txtObservaciones.Location = New System.Drawing.Point(83, 44)
      Me.txtObservaciones.MaxLength = 100
      Me.txtObservaciones.Name = "txtObservaciones"
      Me.txtObservaciones.Size = New System.Drawing.Size(312, 20)
      Me.txtObservaciones.TabIndex = 7
      '
      'lblObservaciones
      '
      Me.lblObservaciones.AutoSize = True
      Me.lblObservaciones.LabelAsoc = Nothing
      Me.lblObservaciones.Location = New System.Drawing.Point(10, 48)
      Me.lblObservaciones.Name = "lblObservaciones"
      Me.lblObservaciones.Size = New System.Drawing.Size(67, 13)
      Me.lblObservaciones.TabIndex = 6
      Me.lblObservaciones.Text = "Observacion"
      '
      'cmbFormaPago
      '
      Me.cmbFormaPago.BindearPropiedadControl = Nothing
      Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
      Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormaPago.FormattingEnabled = True
      Me.cmbFormaPago.IsPK = False
      Me.cmbFormaPago.IsRequired = False
      Me.cmbFormaPago.Key = Nothing
      Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
      Me.cmbFormaPago.Location = New System.Drawing.Point(275, 17)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(120, 21)
      Me.cmbFormaPago.TabIndex = 3
      '
      'lblFormaPago
      '
      Me.lblFormaPago.AutoSize = True
      Me.lblFormaPago.LabelAsoc = Nothing
      Me.lblFormaPago.Location = New System.Drawing.Point(192, 22)
      Me.lblFormaPago.Name = "lblFormaPago"
      Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
      Me.lblFormaPago.TabIndex = 2
      Me.lblFormaPago.Text = "Forma de &Pago"
      '
      'lblVencimiento
      '
      Me.lblVencimiento.AutoSize = True
      Me.lblVencimiento.Enabled = False
      Me.lblVencimiento.LabelAsoc = Nothing
      Me.lblVencimiento.Location = New System.Drawing.Point(402, 48)
      Me.lblVencimiento.Name = "lblVencimiento"
      Me.lblVencimiento.Size = New System.Drawing.Size(65, 13)
      Me.lblVencimiento.TabIndex = 8
      Me.lblVencimiento.Text = "Vencimiento"
      Me.lblVencimiento.Visible = False
      '
      'dtpVencimiento
      '
      Me.dtpVencimiento.AllowDrop = True
      Me.dtpVencimiento.BindearPropiedadControl = ""
      Me.dtpVencimiento.BindearPropiedadEntidad = ""
      Me.dtpVencimiento.CustomFormat = "dd/MM/yyyy"
      Me.dtpVencimiento.Enabled = False
      Me.dtpVencimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpVencimiento.IsPK = False
      Me.dtpVencimiento.IsRequired = False
      Me.dtpVencimiento.Key = ""
      Me.dtpVencimiento.LabelAsoc = Me.lblVencimiento
      Me.dtpVencimiento.Location = New System.Drawing.Point(472, 44)
      Me.dtpVencimiento.Name = "dtpVencimiento"
      Me.dtpVencimiento.Size = New System.Drawing.Size(95, 20)
      Me.dtpVencimiento.TabIndex = 9
      Me.dtpVencimiento.Visible = False
      '
      'GenerarFacturasDeCargos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(952, 562)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.grpFactura)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "GenerarFacturasDeCargos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Generar Facturas de Cargos"
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.grpFactura.ResumeLayout(False)
      Me.grpFactura.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents toolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbEliminarFacturas As System.Windows.Forms.ToolStripButton
   Private WithEvents tss4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Private WithEvents tss5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbGenerarFacturas As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents dtpPeriodo As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodo As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents txtTotalGastosOperativos As Eniac.Controles.TextBox
   Friend WithEvents lblTotalGastosOperativos As Eniac.Controles.Label
   Friend WithEvents lblFechaComprobantes As Eniac.Controles.Label
   Friend WithEvents dtpFechaComprobantes As Eniac.Controles.DateTimePicker
   Friend WithEvents grpFactura As System.Windows.Forms.GroupBox
   Friend WithEvents txtObservaciones As Eniac.Controles.TextBox
   Friend WithEvents lblObservaciones As Eniac.Controles.Label
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents lblVencimiento As Eniac.Controles.Label
   Friend WithEvents dtpVencimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbTiposLiquidacion As Eniac.Controles.ComboBox
End Class
