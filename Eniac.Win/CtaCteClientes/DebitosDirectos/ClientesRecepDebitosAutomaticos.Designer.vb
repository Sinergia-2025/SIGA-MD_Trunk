<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClientesRecepDebitosAutomaticos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesRecepDebitosAutomaticos))
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
        Me.tsbGenerarPagos = New System.Windows.Forms.ToolStripButton()
        Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbCabecera = New System.Windows.Forms.GroupBox()
        Me.txtOtrosConceptos = New Eniac.Controles.TextBox()
        Me.txtComisiones = New Eniac.Controles.TextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.txtTotalAcreditar = New Eniac.Controles.TextBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.Label3 = New Eniac.Controles.Label()
        Me.chbCargo = New Eniac.Controles.CheckBox()
        Me.lblTipoLiquidacion = New Eniac.Controles.Label()
        Me.cmbTiposLiquidacion = New Eniac.Controles.ComboBox()
        Me.cmbTipo = New Eniac.Controles.ComboBox()
        Me.lblTipo = New Eniac.Controles.Label()
        Me.txtNroDeArchivo = New Eniac.Controles.TextBox()
        Me.txtFechaRespuesta = New Eniac.Controles.TextBox()
        Me.lblImporte = New Eniac.Controles.Label()
        Me.txtImporte = New Eniac.Controles.TextBox()
        Me.lblNroArchivo = New Eniac.Controles.Label()
        Me.lblFechaRespuesta = New Eniac.Controles.Label()
        Me.dtpFecha = New Eniac.Controles.DateTimePicker()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.bscCuentaBancariaTransfBanc = New Eniac.Controles.Buscador2()
        Me.lblCuentaBancaria = New Eniac.Controles.Label()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.cmbCobradores = New Eniac.Controles.ComboBox()
        Me.lblCobradores = New Eniac.Controles.Label()
        Me.cmbTipoRecibo = New Eniac.Controles.ComboBox()
        Me.lblTipoRecibo = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bscCodigoCuentaBancariaTransfBanc = New Eniac.Controles.Buscador2()
        Me.tstBarra.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCabecera.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbLeerArchivo, Me.tss2, Me.tsbGenerarPagos, Me.tss3, Me.tsbImprimir, Me.tsddExportar, Me.tss4, Me.tsbSalir})
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
        Me.tsbLeerArchivo.Image = CType(resources.GetObject("tsbLeerArchivo.Image"), System.Drawing.Image)
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
        'tsbGenerarPagos
        '
        Me.tsbGenerarPagos.Enabled = False
        Me.tsbGenerarPagos.Image = Global.Eniac.Win.My.Resources.Resources.cashier
        Me.tsbGenerarPagos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerarPagos.Name = "tsbGenerarPagos"
        Me.tsbGenerarPagos.Size = New System.Drawing.Size(109, 26)
        Me.tsbGenerarPagos.Text = "Generar Pagos"
        '
        'tss3
        '
        Me.tss3.Name = "tss3"
        Me.tss3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tssRegistros})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip1.TabIndex = 3
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
        Me.ugDetalle.Location = New System.Drawing.Point(0, 161)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 376)
        Me.ugDetalle.TabIndex = 2
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'grbCabecera
        '
        Me.grbCabecera.Controls.Add(Me.txtOtrosConceptos)
        Me.grbCabecera.Controls.Add(Me.txtComisiones)
        Me.grbCabecera.Controls.Add(Me.Label1)
        Me.grbCabecera.Controls.Add(Me.txtTotalAcreditar)
        Me.grbCabecera.Controls.Add(Me.Label2)
        Me.grbCabecera.Controls.Add(Me.Label3)
        Me.grbCabecera.Controls.Add(Me.chbCargo)
        Me.grbCabecera.Controls.Add(Me.lblTipoLiquidacion)
        Me.grbCabecera.Controls.Add(Me.cmbTiposLiquidacion)
        Me.grbCabecera.Controls.Add(Me.cmbTipo)
        Me.grbCabecera.Controls.Add(Me.lblTipo)
        Me.grbCabecera.Controls.Add(Me.txtNroDeArchivo)
        Me.grbCabecera.Controls.Add(Me.txtFechaRespuesta)
        Me.grbCabecera.Controls.Add(Me.lblImporte)
        Me.grbCabecera.Controls.Add(Me.txtImporte)
        Me.grbCabecera.Controls.Add(Me.lblNroArchivo)
        Me.grbCabecera.Controls.Add(Me.lblFechaRespuesta)
        Me.grbCabecera.Location = New System.Drawing.Point(12, 32)
        Me.grbCabecera.Name = "grbCabecera"
        Me.grbCabecera.Size = New System.Drawing.Size(391, 123)
        Me.grbCabecera.TabIndex = 0
        Me.grbCabecera.TabStop = False
        '
        'txtOtrosConceptos
        '
        Me.txtOtrosConceptos.BindearPropiedadControl = Nothing
        Me.txtOtrosConceptos.BindearPropiedadEntidad = Nothing
        Me.txtOtrosConceptos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOtrosConceptos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOtrosConceptos.Formato = ""
        Me.txtOtrosConceptos.IsDecimal = False
        Me.txtOtrosConceptos.IsNumber = False
        Me.txtOtrosConceptos.IsPK = False
        Me.txtOtrosConceptos.IsRequired = False
        Me.txtOtrosConceptos.Key = ""
        Me.txtOtrosConceptos.LabelAsoc = Nothing
        Me.txtOtrosConceptos.Location = New System.Drawing.Point(254, 73)
        Me.txtOtrosConceptos.Name = "txtOtrosConceptos"
        Me.txtOtrosConceptos.ReadOnly = True
        Me.txtOtrosConceptos.Size = New System.Drawing.Size(66, 20)
        Me.txtOtrosConceptos.TabIndex = 14
        Me.txtOtrosConceptos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComisiones
        '
        Me.txtComisiones.BindearPropiedadControl = Nothing
        Me.txtComisiones.BindearPropiedadEntidad = Nothing
        Me.txtComisiones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComisiones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComisiones.Formato = ""
        Me.txtComisiones.IsDecimal = False
        Me.txtComisiones.IsNumber = False
        Me.txtComisiones.IsPK = False
        Me.txtComisiones.IsRequired = False
        Me.txtComisiones.Key = ""
        Me.txtComisiones.LabelAsoc = Nothing
        Me.txtComisiones.Location = New System.Drawing.Point(157, 73)
        Me.txtComisiones.Name = "txtComisiones"
        Me.txtComisiones.ReadOnly = True
        Me.txtComisiones.Size = New System.Drawing.Size(96, 20)
        Me.txtComisiones.TabIndex = 12
        Me.txtComisiones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(317, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Total a Acred."
        '
        'txtTotalAcreditar
        '
        Me.txtTotalAcreditar.BindearPropiedadControl = Nothing
        Me.txtTotalAcreditar.BindearPropiedadEntidad = Nothing
        Me.txtTotalAcreditar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalAcreditar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalAcreditar.Formato = ""
        Me.txtTotalAcreditar.IsDecimal = False
        Me.txtTotalAcreditar.IsNumber = False
        Me.txtTotalAcreditar.IsPK = False
        Me.txtTotalAcreditar.IsRequired = False
        Me.txtTotalAcreditar.Key = ""
        Me.txtTotalAcreditar.LabelAsoc = Nothing
        Me.txtTotalAcreditar.Location = New System.Drawing.Point(321, 73)
        Me.txtTotalAcreditar.Name = "txtTotalAcreditar"
        Me.txtTotalAcreditar.ReadOnly = True
        Me.txtTotalAcreditar.Size = New System.Drawing.Size(64, 20)
        Me.txtTotalAcreditar.TabIndex = 16
        Me.txtTotalAcreditar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(251, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Otros Cptos."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(154, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Comisiones "
        '
        'chbCargo
        '
        Me.chbCargo.AutoSize = True
        Me.chbCargo.BindearPropiedadControl = Nothing
        Me.chbCargo.BindearPropiedadEntidad = Nothing
        Me.chbCargo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCargo.IsPK = False
        Me.chbCargo.IsRequired = False
        Me.chbCargo.Key = Nothing
        Me.chbCargo.LabelAsoc = Nothing
        Me.chbCargo.Location = New System.Drawing.Point(11, 100)
        Me.chbCargo.Name = "chbCargo"
        Me.chbCargo.Size = New System.Drawing.Size(54, 17)
        Me.chbCargo.TabIndex = 8
        Me.chbCargo.Text = "Cargo"
        Me.chbCargo.UseVisualStyleBackColor = True
        '
        'lblTipoLiquidacion
        '
        Me.lblTipoLiquidacion.AutoSize = True
        Me.lblTipoLiquidacion.LabelAsoc = Nothing
        Me.lblTipoLiquidacion.Location = New System.Drawing.Point(71, 101)
        Me.lblTipoLiquidacion.Name = "lblTipoLiquidacion"
        Me.lblTipoLiquidacion.Size = New System.Drawing.Size(85, 13)
        Me.lblTipoLiquidacion.TabIndex = 9
        Me.lblTipoLiquidacion.Text = "Tipo Liquidacion"
        '
        'cmbTiposLiquidacion
        '
        Me.cmbTiposLiquidacion.BindearPropiedadControl = ""
        Me.cmbTiposLiquidacion.BindearPropiedadEntidad = ""
        Me.cmbTiposLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposLiquidacion.Enabled = False
        Me.cmbTiposLiquidacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposLiquidacion.FormattingEnabled = True
        Me.cmbTiposLiquidacion.IsPK = False
        Me.cmbTiposLiquidacion.IsRequired = True
        Me.cmbTiposLiquidacion.Key = Nothing
        Me.cmbTiposLiquidacion.LabelAsoc = Nothing
        Me.cmbTiposLiquidacion.Location = New System.Drawing.Point(157, 97)
        Me.cmbTiposLiquidacion.Name = "cmbTiposLiquidacion"
        Me.cmbTiposLiquidacion.Size = New System.Drawing.Size(136, 21)
        Me.cmbTiposLiquidacion.TabIndex = 10
        '
        'cmbTipo
        '
        Me.cmbTipo.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipo.BindearPropiedadEntidad = "Cobrador.idCobrador"
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.IsPK = False
        Me.cmbTipo.IsRequired = False
        Me.cmbTipo.Items.AddRange(New Object() {"Macro", "Santander Rio", "Pago Mis Cuentas", "Roela Pago Mis Cuentas", "SIRPLUS"})
        Me.cmbTipo.Key = Nothing
        Me.cmbTipo.LabelAsoc = Nothing
        Me.cmbTipo.Location = New System.Drawing.Point(9, 34)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(141, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(6, 19)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 0
        Me.lblTipo.Text = "Tipo"
        '
        'txtNroDeArchivo
        '
        Me.txtNroDeArchivo.BindearPropiedadControl = Nothing
        Me.txtNroDeArchivo.BindearPropiedadEntidad = Nothing
        Me.txtNroDeArchivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDeArchivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDeArchivo.Formato = ""
        Me.txtNroDeArchivo.IsDecimal = False
        Me.txtNroDeArchivo.IsNumber = False
        Me.txtNroDeArchivo.IsPK = False
        Me.txtNroDeArchivo.IsRequired = False
        Me.txtNroDeArchivo.Key = ""
        Me.txtNroDeArchivo.LabelAsoc = Nothing
        Me.txtNroDeArchivo.Location = New System.Drawing.Point(253, 35)
        Me.txtNroDeArchivo.Name = "txtNroDeArchivo"
        Me.txtNroDeArchivo.ReadOnly = True
        Me.txtNroDeArchivo.Size = New System.Drawing.Size(66, 20)
        Me.txtNroDeArchivo.TabIndex = 5
        Me.txtNroDeArchivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaRespuesta
        '
        Me.txtFechaRespuesta.BindearPropiedadControl = Nothing
        Me.txtFechaRespuesta.BindearPropiedadEntidad = Nothing
        Me.txtFechaRespuesta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaRespuesta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaRespuesta.Formato = ""
        Me.txtFechaRespuesta.IsDecimal = False
        Me.txtFechaRespuesta.IsNumber = False
        Me.txtFechaRespuesta.IsPK = False
        Me.txtFechaRespuesta.IsRequired = False
        Me.txtFechaRespuesta.Key = ""
        Me.txtFechaRespuesta.LabelAsoc = Nothing
        Me.txtFechaRespuesta.Location = New System.Drawing.Point(156, 35)
        Me.txtFechaRespuesta.Name = "txtFechaRespuesta"
        Me.txtFechaRespuesta.ReadOnly = True
        Me.txtFechaRespuesta.Size = New System.Drawing.Size(96, 20)
        Me.txtFechaRespuesta.TabIndex = 3
        Me.txtFechaRespuesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.LabelAsoc = Nothing
        Me.lblImporte.Location = New System.Drawing.Point(324, 19)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(42, 13)
        Me.lblImporte.TabIndex = 6
        Me.lblImporte.Text = "Importe"
        '
        'txtImporte
        '
        Me.txtImporte.BindearPropiedadControl = Nothing
        Me.txtImporte.BindearPropiedadEntidad = Nothing
        Me.txtImporte.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporte.Formato = ""
        Me.txtImporte.IsDecimal = False
        Me.txtImporte.IsNumber = False
        Me.txtImporte.IsPK = False
        Me.txtImporte.IsRequired = False
        Me.txtImporte.Key = ""
        Me.txtImporte.LabelAsoc = Nothing
        Me.txtImporte.Location = New System.Drawing.Point(320, 35)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(64, 20)
        Me.txtImporte.TabIndex = 7
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroArchivo
        '
        Me.lblNroArchivo.AutoSize = True
        Me.lblNroArchivo.LabelAsoc = Nothing
        Me.lblNroArchivo.Location = New System.Drawing.Point(250, 19)
        Me.lblNroArchivo.Name = "lblNroArchivo"
        Me.lblNroArchivo.Size = New System.Drawing.Size(73, 13)
        Me.lblNroArchivo.TabIndex = 4
        Me.lblNroArchivo.Text = "Nro. de Conv."
        '
        'lblFechaRespuesta
        '
        Me.lblFechaRespuesta.AutoSize = True
        Me.lblFechaRespuesta.LabelAsoc = Nothing
        Me.lblFechaRespuesta.Location = New System.Drawing.Point(153, 19)
        Me.lblFechaRespuesta.Name = "lblFechaRespuesta"
        Me.lblFechaRespuesta.Size = New System.Drawing.Size(95, 13)
        Me.lblFechaRespuesta.TabIndex = 2
        Me.lblFechaRespuesta.Text = "Fecha Generación"
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
        Me.dtpFecha.Location = New System.Drawing.Point(357, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 3
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(301, 16)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "&Fecha"
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
        Me.cmbCajas.Location = New System.Drawing.Point(91, 65)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(200, 21)
        Me.cmbCajas.TabIndex = 8
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(2, 69)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 7
        Me.lblCaja.Text = "Caja"
        '
        'bscCuentaBancariaTransfBanc
        '
        Me.bscCuentaBancariaTransfBanc.ActivarFiltroEnGrilla = True
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaTransfBanc.ConfigBuscador = Nothing
        Me.bscCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCuentaBancariaTransfBanc.IsPK = False
        Me.bscCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCuentaBancariaTransfBanc.Key = ""
        Me.bscCuentaBancariaTransfBanc.LabelAsoc = Me.lblCuentaBancaria
        Me.bscCuentaBancariaTransfBanc.Location = New System.Drawing.Point(91, 12)
        Me.bscCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCuentaBancariaTransfBanc.Name = "bscCuentaBancariaTransfBanc"
        Me.bscCuentaBancariaTransfBanc.Permitido = True
        Me.bscCuentaBancariaTransfBanc.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCuentaBancariaTransfBanc.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancariaTransfBanc.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCuentaBancariaTransfBanc.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCuentaBancariaTransfBanc.Size = New System.Drawing.Size(200, 20)
        Me.bscCuentaBancariaTransfBanc.TabIndex = 1
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.AutoSize = True
        Me.lblCuentaBancaria.LabelAsoc = Nothing
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(2, 16)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(86, 13)
        Me.lblCuentaBancaria.TabIndex = 0
        Me.lblCuentaBancaria.Text = "Cuenta Bancaria"
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
        Me.cmbCobradores.Location = New System.Drawing.Point(357, 65)
        Me.cmbCobradores.Name = "cmbCobradores"
        Me.cmbCobradores.Size = New System.Drawing.Size(200, 21)
        Me.cmbCobradores.TabIndex = 10
        '
        'lblCobradores
        '
        Me.lblCobradores.AutoSize = True
        Me.lblCobradores.LabelAsoc = Nothing
        Me.lblCobradores.Location = New System.Drawing.Point(301, 69)
        Me.lblCobradores.Name = "lblCobradores"
        Me.lblCobradores.Size = New System.Drawing.Size(50, 13)
        Me.lblCobradores.TabIndex = 9
        Me.lblCobradores.Text = "Cobrador"
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
        Me.cmbTipoRecibo.Location = New System.Drawing.Point(91, 38)
        Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
        Me.cmbTipoRecibo.Size = New System.Drawing.Size(200, 21)
        Me.cmbTipoRecibo.TabIndex = 6
        '
        'lblTipoRecibo
        '
        Me.lblTipoRecibo.AutoSize = True
        Me.lblTipoRecibo.LabelAsoc = Nothing
        Me.lblTipoRecibo.Location = New System.Drawing.Point(2, 42)
        Me.lblTipoRecibo.Name = "lblTipoRecibo"
        Me.lblTipoRecibo.Size = New System.Drawing.Size(80, 13)
        Me.lblTipoRecibo.TabIndex = 5
        Me.lblTipoRecibo.Text = "Tipo de Recibo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bscCodigoCuentaBancariaTransfBanc)
        Me.GroupBox1.Controls.Add(Me.cmbCajas)
        Me.GroupBox1.Controls.Add(Me.cmbTipoRecibo)
        Me.GroupBox1.Controls.Add(Me.lblCaja)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.lblTipoRecibo)
        Me.GroupBox1.Controls.Add(Me.lblCobradores)
        Me.GroupBox1.Controls.Add(Me.bscCuentaBancariaTransfBanc)
        Me.GroupBox1.Controls.Add(Me.lblCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.cmbCobradores)
        Me.GroupBox1.Location = New System.Drawing.Point(409, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 123)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'bscCodigoCuentaBancariaTransfBanc
        '
        Me.bscCodigoCuentaBancariaTransfBanc.ActivarFiltroEnGrilla = True
        Me.bscCodigoCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ConfigBuscador = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsPK = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCodigoCuentaBancariaTransfBanc.Key = ""
        Me.bscCodigoCuentaBancariaTransfBanc.LabelAsoc = Me.lblCuentaBancaria
        Me.bscCodigoCuentaBancariaTransfBanc.Location = New System.Drawing.Point(472, 19)
        Me.bscCodigoCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCodigoCuentaBancariaTransfBanc.Name = "bscCodigoCuentaBancariaTransfBanc"
        Me.bscCodigoCuentaBancariaTransfBanc.Permitido = True
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCodigoCuentaBancariaTransfBanc.Size = New System.Drawing.Size(49, 20)
        Me.bscCodigoCuentaBancariaTransfBanc.TabIndex = 4
        Me.bscCodigoCuentaBancariaTransfBanc.Visible = False
        '
        'ClientesRecepDebitosAutomaticos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbCabecera)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ClientesRecepDebitosAutomaticos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leer Archivo de Respuesta de Débitos Automaticos"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCabecera.ResumeLayout(False)
        Me.grbCabecera.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbLeerArchivo As System.Windows.Forms.ToolStripButton
    Private WithEvents tss4 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaRespuesta As Eniac.Controles.Label
    Friend WithEvents txtFechaRespuesta As Eniac.Controles.TextBox
    Friend WithEvents lblNroArchivo As Eniac.Controles.Label
    Friend WithEvents txtNroDeArchivo As Eniac.Controles.TextBox
    Friend WithEvents lblImporte As Eniac.Controles.Label
    Friend WithEvents txtImporte As Eniac.Controles.TextBox
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGenerarPagos As System.Windows.Forms.ToolStripButton
    Friend WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbTipo As Eniac.Controles.ComboBox
    Friend WithEvents lblTipo As Eniac.Controles.Label
   Friend WithEvents bscCuentaBancariaTransfBanc As Eniac.Controles.Buscador2
   Friend WithEvents lblCuentaBancaria As Eniac.Controles.Label
    Friend WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
    Friend WithEvents lblCaja As Eniac.Controles.Label
    Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFecha As Eniac.Controles.Label
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chbCargo As Eniac.Controles.CheckBox
    Friend WithEvents lblTipoLiquidacion As Eniac.Controles.Label
    Friend WithEvents cmbTiposLiquidacion As Eniac.Controles.ComboBox
    Friend WithEvents cmbCobradores As Eniac.Controles.ComboBox
    Friend WithEvents lblCobradores As Eniac.Controles.Label
    Friend WithEvents cmbTipoRecibo As Eniac.Controles.ComboBox
    Friend WithEvents lblTipoRecibo As Eniac.Controles.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents bscCodigoCuentaBancariaTransfBanc As Eniac.Controles.Buscador2
    Friend WithEvents txtOtrosConceptos As Controles.TextBox
    Friend WithEvents txtComisiones As Controles.TextBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents txtTotalAcreditar As Controles.TextBox
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents Label3 As Controles.Label
End Class
