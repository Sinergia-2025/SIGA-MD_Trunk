<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EstructuraProductos
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstructuraProductos))
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Key")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Value")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grpConsultar = New System.Windows.Forms.GroupBox()
        Me.cmbMonedaVenta = New Eniac.Controles.ComboBox()
        Me.lblMonedaVenta = New Eniac.Controles.Label()
        Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
        Me.lblCotizacionDolar = New Eniac.Controles.Label()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.dudNivelesGrillas = New System.Windows.Forms.DomainUpDown()
        Me.Label1 = New Eniac.Controles.Label()
        Me.txtCantidad = New Eniac.Controles.TextBox()
        Me.lblCantidad = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.lblCodProducto = New Eniac.Controles.Label()
        Me.lblFormula = New Eniac.Controles.Label()
        Me.cmbFormulas = New Eniac.Controles.ComboBox()
        Me.btnLimpiarProducto = New Eniac.Controles.Button()
        Me.ugVariables = New Eniac.Win.UltraGridEditable()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.pnlAceptarCancelar = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlCombos = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbModeloForma = New Eniac.Controles.ComboBox()
        Me.lblModeloForma = New Eniac.Controles.Label()
        Me.pnlGrillaDetalle = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbAgregarFormula = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbModificarFormula = New System.Windows.Forms.ToolStripButton()
        Me.tsbModificarRegistroGrillaDetalle = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEliminarFormula = New System.Windows.Forms.ToolStripButton()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.grpConsultar.SuspendLayout()
        CType(Me.ugVariables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlAceptarCancelar.SuspendLayout()
        Me.pnlCombos.SuspendLayout()
        Me.pnlGrillaDetalle.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugDetalle.DisplayLayout.MaxBandDepth = 10
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
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
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Location = New System.Drawing.Point(0, 29)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(899, 402)
        Me.ugDetalle.TabIndex = 2
        Me.ugDetalle.Text = "UltraGrid2"
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsddExportar, Me.tsbPreferencias, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1184, 29)
        Me.tstBarra.TabIndex = 0
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'grpConsultar
        '
        Me.grpConsultar.Controls.Add(Me.cmbMonedaVenta)
        Me.grpConsultar.Controls.Add(Me.lblMonedaVenta)
        Me.grpConsultar.Controls.Add(Me.txtCotizacionDolar)
        Me.grpConsultar.Controls.Add(Me.lblCotizacionDolar)
        Me.grpConsultar.Controls.Add(Me.chkExpandAll)
        Me.grpConsultar.Controls.Add(Me.chbConIVA)
        Me.grpConsultar.Controls.Add(Me.dudNivelesGrillas)
        Me.grpConsultar.Controls.Add(Me.Label1)
        Me.grpConsultar.Controls.Add(Me.txtCantidad)
        Me.grpConsultar.Controls.Add(Me.lblCantidad)
        Me.grpConsultar.Controls.Add(Me.btnConsultar)
        Me.grpConsultar.Controls.Add(Me.bscProducto2)
        Me.grpConsultar.Controls.Add(Me.bscCodigoProducto2)
        Me.grpConsultar.Controls.Add(Me.lblFormula)
        Me.grpConsultar.Controls.Add(Me.cmbFormulas)
        Me.grpConsultar.Controls.Add(Me.btnLimpiarProducto)
        Me.grpConsultar.Controls.Add(Me.lblCodProducto)
        Me.grpConsultar.Controls.Add(Me.lblProducto)
        Me.grpConsultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpConsultar.Location = New System.Drawing.Point(0, 29)
        Me.grpConsultar.Name = "grpConsultar"
        Me.grpConsultar.Size = New System.Drawing.Size(1184, 101)
        Me.grpConsultar.TabIndex = 1
        Me.grpConsultar.TabStop = False
        Me.grpConsultar.Text = "Selección de Producto"
        '
        'cmbMonedaVenta
        '
        Me.cmbMonedaVenta.BindearPropiedadControl = Nothing
        Me.cmbMonedaVenta.BindearPropiedadEntidad = Nothing
        Me.cmbMonedaVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonedaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbMonedaVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMonedaVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMonedaVenta.FormattingEnabled = True
        Me.cmbMonedaVenta.IsPK = False
        Me.cmbMonedaVenta.IsRequired = False
        Me.cmbMonedaVenta.Key = Nothing
        Me.cmbMonedaVenta.LabelAsoc = Me.lblMonedaVenta
        Me.cmbMonedaVenta.Location = New System.Drawing.Point(667, 73)
        Me.cmbMonedaVenta.Name = "cmbMonedaVenta"
        Me.cmbMonedaVenta.Size = New System.Drawing.Size(70, 21)
        Me.cmbMonedaVenta.TabIndex = 68
        '
        'lblMonedaVenta
        '
        Me.lblMonedaVenta.AutoSize = True
        Me.lblMonedaVenta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMonedaVenta.LabelAsoc = Nothing
        Me.lblMonedaVenta.Location = New System.Drawing.Point(615, 76)
        Me.lblMonedaVenta.Name = "lblMonedaVenta"
        Me.lblMonedaVenta.Size = New System.Drawing.Size(46, 13)
        Me.lblMonedaVenta.TabIndex = 67
        Me.lblMonedaVenta.Text = "Moneda"
        '
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.BackColor = System.Drawing.SystemColors.Window
        Me.txtCotizacionDolar.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolar.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolar.Formato = "##0.00"
        Me.txtCotizacionDolar.IsDecimal = True
        Me.txtCotizacionDolar.IsNumber = True
        Me.txtCotizacionDolar.IsPK = False
        Me.txtCotizacionDolar.IsRequired = False
        Me.txtCotizacionDolar.Key = ""
        Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(782, 73)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(48, 20)
        Me.txtCotizacionDolar.TabIndex = 70
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCotizacionDolar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(743, 73)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(33, 18)
        Me.lblCotizacionDolar.TabIndex = 69
        Me.lblCotizacionDolar.Text = "Dolar"
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkExpandAll
        '
        Me.chkExpandAll.BackColor = System.Drawing.Color.Transparent
        Me.chkExpandAll.Checked = True
        Me.chkExpandAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExpandAll.Location = New System.Drawing.Point(905, 76)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 18)
        Me.chkExpandAll.TabIndex = 11
        Me.chkExpandAll.Text = "Expandir Grupos"
        Me.chkExpandAll.UseVisualStyleBackColor = False
        '
        'chbConIVA
        '
        Me.chbConIVA.AutoSize = True
        Me.chbConIVA.BindearPropiedadControl = Nothing
        Me.chbConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConIVA.IsPK = False
        Me.chbConIVA.IsRequired = False
        Me.chbConIVA.Key = Nothing
        Me.chbConIVA.LabelAsoc = Nothing
        Me.chbConIVA.Location = New System.Drawing.Point(797, 48)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 13
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
        '
        'dudNivelesGrillas
        '
        Me.dudNivelesGrillas.AutoSize = True
        Me.dudNivelesGrillas.Items.Add("1")
        Me.dudNivelesGrillas.Items.Add("2")
        Me.dudNivelesGrillas.Items.Add("3")
        Me.dudNivelesGrillas.Items.Add("4")
        Me.dudNivelesGrillas.Items.Add("5")
        Me.dudNivelesGrillas.Items.Add("6")
        Me.dudNivelesGrillas.Items.Add("7")
        Me.dudNivelesGrillas.Items.Add("8")
        Me.dudNivelesGrillas.Items.Add("9")
        Me.dudNivelesGrillas.Items.Add("10")
        Me.dudNivelesGrillas.Items.Add("15")
        Me.dudNivelesGrillas.Items.Add("20")
        Me.dudNivelesGrillas.Items.Add("25")
        Me.dudNivelesGrillas.Items.Add("30")
        Me.dudNivelesGrillas.Items.Add("35")
        Me.dudNivelesGrillas.Items.Add("40")
        Me.dudNivelesGrillas.Items.Add("45")
        Me.dudNivelesGrillas.Items.Add("50")
        Me.dudNivelesGrillas.Location = New System.Drawing.Point(743, 44)
        Me.dudNivelesGrillas.Name = "dudNivelesGrillas"
        Me.dudNivelesGrillas.Size = New System.Drawing.Size(39, 20)
        Me.dudNivelesGrillas.TabIndex = 10
        Me.dudNivelesGrillas.Text = "99"
        Me.dudNivelesGrillas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(740, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Niveles"
        '
        'txtCantidad
        '
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "#0.00"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblCantidad
        Me.txtCantidad.Location = New System.Drawing.Point(667, 44)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(70, 20)
        Me.txtCantidad.TabIndex = 8
        Me.txtCantidad.Text = "1.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(664, 29)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(70, 13)
        Me.lblCantidad.TabIndex = 7
        Me.lblCantidad.Text = "Cantidad (F7)"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(899, 25)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(119, 45)
        Me.btnConsultar.TabIndex = 12
        Me.btnConsultar.Text = "&Consultar (F4)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Me.lblProducto
        Me.bscProducto2.Location = New System.Drawing.Point(185, 44)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(278, 20)
        Me.bscProducto2.TabIndex = 4
        '
        'lblProducto
        '
        Me.lblProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(182, 29)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 3
        Me.lblProducto.Text = "Producto"
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Me.lblCodProducto
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(59, 44)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(120, 20)
        Me.bscCodigoProducto2.TabIndex = 2
        '
        'lblCodProducto
        '
        Me.lblCodProducto.AutoSize = True
        Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodProducto.LabelAsoc = Nothing
        Me.lblCodProducto.Location = New System.Drawing.Point(56, 29)
        Me.lblCodProducto.Name = "lblCodProducto"
        Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodProducto.TabIndex = 1
        Me.lblCodProducto.Text = "Código"
        '
        'lblFormula
        '
        Me.lblFormula.AutoSize = True
        Me.lblFormula.LabelAsoc = Nothing
        Me.lblFormula.Location = New System.Drawing.Point(466, 29)
        Me.lblFormula.Name = "lblFormula"
        Me.lblFormula.Size = New System.Drawing.Size(65, 13)
        Me.lblFormula.TabIndex = 5
        Me.lblFormula.Text = "Fórmula (F6)"
        '
        'cmbFormulas
        '
        Me.cmbFormulas.BindearPropiedadControl = Nothing
        Me.cmbFormulas.BindearPropiedadEntidad = Nothing
        Me.cmbFormulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormulas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormulas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormulas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormulas.FormattingEnabled = True
        Me.cmbFormulas.IsPK = False
        Me.cmbFormulas.IsRequired = False
        Me.cmbFormulas.Key = Nothing
        Me.cmbFormulas.LabelAsoc = Me.lblFormula
        Me.cmbFormulas.Location = New System.Drawing.Point(469, 44)
        Me.cmbFormulas.Name = "cmbFormulas"
        Me.cmbFormulas.Size = New System.Drawing.Size(188, 21)
        Me.cmbFormulas.TabIndex = 6
        Me.cmbFormulas.TabStop = False
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(16, 29)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(37, 36)
        Me.btnLimpiarProducto.TabIndex = 0
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'ugVariables
        '
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugVariables.DisplayLayout.Appearance = Appearance14
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn1.Header.Caption = "Variable"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 130
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance15
        UltraGridColumn2.Header.Caption = "Valor"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 130
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
        Me.ugVariables.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugVariables.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVariables.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVariables.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.ugVariables.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugVariables.DisplayLayout.GroupByBox.Hidden = True
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVariables.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.ugVariables.DisplayLayout.MaxColScrollRegions = 1
        Me.ugVariables.DisplayLayout.MaxRowScrollRegions = 1
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugVariables.DisplayLayout.Override.ActiveCellAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Highlight
        Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugVariables.DisplayLayout.Override.ActiveRowAppearance = Appearance20
        Me.ugVariables.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugVariables.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.ugVariables.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugVariables.DisplayLayout.Override.CellAppearance = Appearance22
        Me.ugVariables.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugVariables.DisplayLayout.Override.CellPadding = 0
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVariables.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.ugVariables.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.ugVariables.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugVariables.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.ugVariables.DisplayLayout.Override.RowAppearance = Appearance25
        Me.ugVariables.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugVariables.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
        Me.ugVariables.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugVariables.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugVariables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugVariables.EnterMueveACeldaDeAbajo = True
        Me.ugVariables.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugVariables.Location = New System.Drawing.Point(0, 30)
        Me.ugVariables.Name = "ugVariables"
        Me.ugVariables.Size = New System.Drawing.Size(285, 305)
        Me.ugVariables.TabIndex = 13
        Me.ugVariables.Text = "Variables cálculo  (F8)"
        Me.ugVariables.ToolStripLabelRegistros = Nothing
        Me.ugVariables.ToolStripMenuExpandir = Nothing
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ugVariables)
        Me.Panel1.Controls.Add(Me.btnRecalcular)
        Me.Panel1.Controls.Add(Me.pnlAceptarCancelar)
        Me.Panel1.Controls.Add(Me.pnlCombos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(899, 130)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(285, 431)
        Me.Panel1.TabIndex = 14
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnRecalcular.Location = New System.Drawing.Point(0, 335)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(285, 45)
        Me.btnRecalcular.TabIndex = 14
        Me.btnRecalcular.Text = "Recalcular (F4)"
        Me.btnRecalcular.UseVisualStyleBackColor = True
        Me.btnRecalcular.Visible = False
        '
        'pnlAceptarCancelar
        '
        Me.pnlAceptarCancelar.Controls.Add(Me.btnAceptar)
        Me.pnlAceptarCancelar.Controls.Add(Me.btnCancelar)
        Me.pnlAceptarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAceptarCancelar.Location = New System.Drawing.Point(0, 380)
        Me.pnlAceptarCancelar.Name = "pnlAceptarCancelar"
        Me.pnlAceptarCancelar.Size = New System.Drawing.Size(285, 51)
        Me.pnlAceptarCancelar.TabIndex = 15
        Me.pnlAceptarCancelar.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(107, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        Me.imageList1.Images.SetKeyName(2, "document_edit.ico")
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(193, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlCombos
        '
        Me.pnlCombos.ColumnCount = 2
        Me.pnlCombos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlCombos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlCombos.Controls.Add(Me.cmbModeloForma, 0, 0)
        Me.pnlCombos.Controls.Add(Me.lblModeloForma, 0, 0)
        Me.pnlCombos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCombos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCombos.Name = "pnlCombos"
        Me.pnlCombos.RowCount = 2
        Me.pnlCombos.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlCombos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlCombos.Size = New System.Drawing.Size(285, 30)
        Me.pnlCombos.TabIndex = 16
        '
        'cmbModeloForma
        '
        Me.cmbModeloForma.BindearPropiedadControl = Nothing
        Me.cmbModeloForma.BindearPropiedadEntidad = Nothing
        Me.cmbModeloForma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModeloForma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModeloForma.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModeloForma.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModeloForma.FormattingEnabled = True
        Me.cmbModeloForma.IsPK = False
        Me.cmbModeloForma.IsRequired = False
        Me.cmbModeloForma.Key = Nothing
        Me.cmbModeloForma.LabelAsoc = Me.lblFormula
        Me.cmbModeloForma.Location = New System.Drawing.Point(51, 3)
        Me.cmbModeloForma.Name = "cmbModeloForma"
        Me.cmbModeloForma.Size = New System.Drawing.Size(188, 21)
        Me.cmbModeloForma.TabIndex = 7
        Me.cmbModeloForma.TabStop = False
        '
        'lblModeloForma
        '
        Me.lblModeloForma.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblModeloForma.AutoSize = True
        Me.lblModeloForma.LabelAsoc = Nothing
        Me.lblModeloForma.Location = New System.Drawing.Point(3, 7)
        Me.lblModeloForma.Name = "lblModeloForma"
        Me.lblModeloForma.Size = New System.Drawing.Size(42, 13)
        Me.lblModeloForma.TabIndex = 6
        Me.lblModeloForma.Text = "Modelo"
        '
        'pnlGrillaDetalle
        '
        Me.pnlGrillaDetalle.Controls.Add(Me.ugDetalle)
        Me.pnlGrillaDetalle.Controls.Add(Me.ToolStrip1)
        Me.pnlGrillaDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrillaDetalle.Location = New System.Drawing.Point(0, 130)
        Me.pnlGrillaDetalle.Name = "pnlGrillaDetalle"
        Me.pnlGrillaDetalle.Size = New System.Drawing.Size(899, 431)
        Me.pnlGrillaDetalle.TabIndex = 15
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAgregarFormula, Me.ToolStripSeparator1, Me.tsbModificarFormula, Me.tsbModificarRegistroGrillaDetalle, Me.ToolStripSeparator6, Me.tsbEliminarFormula})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(899, 29)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "toolStrip1"
        '
        'tsbAgregarFormula
        '
        Me.tsbAgregarFormula.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.tsbAgregarFormula.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAgregarFormula.Name = "tsbAgregarFormula"
        Me.tsbAgregarFormula.Size = New System.Drawing.Size(122, 26)
        Me.tsbAgregarFormula.Text = "&Agregar Fórmula"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbModificarFormula
        '
        Me.tsbModificarFormula.Image = Global.Eniac.Win.My.Resources.Resources.copy_save_32
        Me.tsbModificarFormula.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbModificarFormula.Name = "tsbModificarFormula"
        Me.tsbModificarFormula.Size = New System.Drawing.Size(172, 26)
        Me.tsbModificarFormula.Text = "&Cambiar Nombre Fórmula"
        '
        'tsbModificarRegistroGrillaDetalle
        '
        Me.tsbModificarRegistroGrillaDetalle.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.tsbModificarRegistroGrillaDetalle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbModificarRegistroGrillaDetalle.Name = "tsbModificarRegistroGrillaDetalle"
        Me.tsbModificarRegistroGrillaDetalle.Size = New System.Drawing.Size(110, 26)
        Me.tsbModificarRegistroGrillaDetalle.Text = "&Editar Fórmula"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 29)
        '
        'tsbEliminarFormula
        '
        Me.tsbEliminarFormula.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.tsbEliminarFormula.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminarFormula.Name = "tsbEliminarFormula"
        Me.tsbEliminarFormula.Size = New System.Drawing.Size(123, 26)
        Me.tsbEliminarFormula.Text = "&Eliminar Fórmula"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "check2.ico")
        Me.ImageList2.Images.SetKeyName(1, "delete2.ico")
        Me.ImageList2.Images.SetKeyName(2, "document_edit.ico")
        '
        'EstructuraProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 561)
        Me.Controls.Add(Me.pnlGrillaDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grpConsultar)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "EstructuraProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estructura de Producto"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grpConsultar.ResumeLayout(False)
        Me.grpConsultar.PerformLayout()
        CType(Me.ugVariables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlAceptarCancelar.ResumeLayout(False)
        Me.pnlCombos.ResumeLayout(False)
        Me.pnlCombos.PerformLayout()
        Me.pnlGrillaDetalle.ResumeLayout(False)
        Me.pnlGrillaDetalle.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpConsultar As GroupBox
    Friend WithEvents bscProducto2 As Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
   Friend WithEvents lblFormula As Controles.Label
   Friend WithEvents cmbFormulas As Controles.ComboBox
    Friend WithEvents btnLimpiarProducto As Controles.Button
    Friend WithEvents lblCodProducto As Controles.Label
    Friend WithEvents lblProducto As Controles.Label
    Friend WithEvents btnConsultar As Controles.Button
    Private WithEvents ugDetalle As UltraGrid
    Friend WithEvents txtCantidad As Controles.TextBox
    Friend WithEvents lblCantidad As Controles.Label
    Public WithEvents tstBarra As ToolStrip
    Public WithEvents tsbRefrescar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsddExportar As ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As ToolStripMenuItem
    Friend WithEvents tsmiAPDF As ToolStripMenuItem
    Private WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents tsbSalir As ToolStripButton
    Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
    Friend WithEvents sfdExportar As SaveFileDialog
    Friend WithEvents chkExpandAll As CheckBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents dudNivelesGrillas As DomainUpDown
   Friend WithEvents ugVariables As UltraGridEditable
   Friend WithEvents chbConIVA As Controles.CheckBox
   Friend WithEvents Panel1 As Panel
   Friend WithEvents btnRecalcular As Button
    Friend WithEvents pnlAceptarCancelar As Panel
    Protected WithEvents btnAceptar As Button
    Private WithEvents imageList1 As ImageList
    Protected WithEvents btnCancelar As Button
   Friend WithEvents pnlCombos As TableLayoutPanel
   Friend WithEvents cmbModeloForma As Controles.ComboBox
   Friend WithEvents lblModeloForma As Controles.Label
    Friend WithEvents pnlGrillaDetalle As Panel
    Private WithEvents ImageList2 As ImageList
    Public WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbAgregarFormula As ToolStripButton
    Friend WithEvents tsbModificarFormula As ToolStripButton
    Friend WithEvents tsbEliminarFormula As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsbModificarRegistroGrillaDetalle As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmbMonedaVenta As Controles.ComboBox
    Friend WithEvents lblMonedaVenta As Controles.Label
    Friend WithEvents txtCotizacionDolar As Controles.TextBox
    Friend WithEvents lblCotizacionDolar As Controles.Label
    Public WithEvents tsbPreferencias As ToolStripButton
End Class
