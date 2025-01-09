<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfKilosCompMensualPorClienteDobleRango
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
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Promedio")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total2")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Promedio2")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiferenciaTotal")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiferenciaPorc")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlMarcas = New System.Windows.Forms.Panel()
        Me.lblMarcas = New Eniac.Controles.Label()
        Me.pnlModelos = New System.Windows.Forms.Panel()
        Me.lblModelos = New Eniac.Controles.Label()
        Me.pnlRubros = New System.Windows.Forms.Panel()
        Me.lblRubros = New Eniac.Controles.Label()
        Me.pnlSubRubros = New System.Windows.Forms.Panel()
        Me.lblSubRubros = New Eniac.Controles.Label()
        Me.pnlSubSubRubros = New System.Windows.Forms.Panel()
        Me.lblSubSubRubros = New Eniac.Controles.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.rbtPorMonto = New System.Windows.Forms.RadioButton()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.rbtPorKilos = New System.Windows.Forms.RadioButton()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta2 = New Eniac.Controles.DateTimePicker()
        Me.lblDesde2 = New Eniac.Controles.Label()
        Me.lblHasta2 = New Eniac.Controles.Label()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.dtpDesde2 = New Eniac.Controles.DateTimePicker()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto2 = New Eniac.Controles.CheckBox()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.cmbMarcas = New Eniac.Win.ComboBoxMarcas()
        Me.cmbModelos = New Eniac.Win.ComboBoxModelos()
        Me.cmbRubros = New Eniac.Win.ComboBoxRubro()
        Me.cmbSubRubros = New Eniac.Win.ComboBoxSubRubro()
        Me.cmbSubSubRubros = New Eniac.Win.ComboBoxSubSubRubro()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.tstBarra.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbConsultar.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.pnlMarcas.SuspendLayout()
        Me.pnlModelos.SuspendLayout()
        Me.pnlRubros.SuspendLayout()
        Me.pnlSubRubros.SuspendLayout()
        Me.pnlSubSubRubros.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 4
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        Me.tsmiAPDF.Text = "a Pdf"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
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
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn6.Header.VisiblePosition = 0
        UltraGridColumn6.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance2
        UltraGridColumn5.Header.Caption = "Codigo"
        UltraGridColumn5.Header.VisiblePosition = 1
        UltraGridColumn5.Width = 80
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "Nombre"
        UltraGridColumn7.Header.VisiblePosition = 2
        UltraGridColumn7.Width = 225
        UltraGridColumn1.Header.Caption = "Localidad"
        UltraGridColumn1.Header.VisiblePosition = 3
        UltraGridColumn1.Width = 130
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Format = "N2"
        UltraGridColumn2.Header.Caption = "Total R1"
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.Width = 90
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "Promedio R1"
        UltraGridColumn3.Header.VisiblePosition = 5
        UltraGridColumn3.Width = 90
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance5
        UltraGridColumn4.Format = "N2"
        UltraGridColumn4.Header.Caption = "Total R2"
        UltraGridColumn4.Header.VisiblePosition = 6
        UltraGridColumn4.Width = 90
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance6
        UltraGridColumn8.Format = "N2"
        UltraGridColumn8.Header.Caption = "Promedio R2"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 90
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance7
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.Caption = "Dif. Totales"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 80
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance8
        UltraGridColumn11.Format = "N2"
        UltraGridColumn11.Header.Caption = "Dif. Porc"
        UltraGridColumn11.Header.VisiblePosition = 9
        UltraGridColumn11.Width = 60
        UltraGridColumn10.Header.VisiblePosition = 10
        UltraGridColumn10.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn6, UltraGridColumn5, UltraGridColumn7, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn8, UltraGridColumn9, UltraGridColumn11, UltraGridColumn10})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre las columnas aquí para agrupar."
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance18
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(9, 237)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(965, 350)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance20.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance20
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
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.TableLayoutPanel1)
        Me.grbConsultar.Location = New System.Drawing.Point(9, 42)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(965, 171)
        Me.grbConsultar.TabIndex = 5
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.44304!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.55696!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(960, 148)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlMarcas)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlModelos)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlRubros)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSubRubros)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSubSubRubros)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 126)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(937, 22)
        Me.FlowLayoutPanel2.TabIndex = 4
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
        Me.pnlMarcas.Size = New System.Drawing.Size(172, 21)
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
        'pnlModelos
        '
        Me.pnlModelos.AutoSize = True
        Me.pnlModelos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlModelos.Controls.Add(Me.cmbModelos)
        Me.pnlModelos.Controls.Add(Me.lblModelos)
        Me.pnlModelos.Location = New System.Drawing.Point(181, 0)
        Me.pnlModelos.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlModelos.Name = "pnlModelos"
        Me.pnlModelos.Size = New System.Drawing.Size(177, 21)
        Me.pnlModelos.TabIndex = 1
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
        Me.pnlRubros.Location = New System.Drawing.Point(364, 0)
        Me.pnlRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlRubros.Name = "pnlRubros"
        Me.pnlRubros.Size = New System.Drawing.Size(172, 21)
        Me.pnlRubros.TabIndex = 2
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
        Me.pnlSubRubros.Location = New System.Drawing.Point(542, 0)
        Me.pnlSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubRubros.Name = "pnlSubRubros"
        Me.pnlSubRubros.Size = New System.Drawing.Size(190, 21)
        Me.pnlSubRubros.TabIndex = 3
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
        Me.pnlSubSubRubros.Location = New System.Drawing.Point(738, 0)
        Me.pnlSubSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubSubRubros.Name = "pnlSubSubRubros"
        Me.pnlSubSubRubros.Size = New System.Drawing.Size(196, 21)
        Me.pnlSubSubRubros.TabIndex = 4
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnConsultar)
        Me.Panel1.Controls.Add(Me.rbtPorMonto)
        Me.Panel1.Controls.Add(Me.bscProducto2)
        Me.Panel1.Controls.Add(Me.rbtPorKilos)
        Me.Panel1.Controls.Add(Me.cmbSucursal)
        Me.Panel1.Controls.Add(Me.chbConIVA)
        Me.Panel1.Controls.Add(Me.bscCodigoProducto2)
        Me.Panel1.Controls.Add(Me.lblSucursal)
        Me.Panel1.Controls.Add(Me.bscCodigoLocalidad)
        Me.Panel1.Controls.Add(Me.dtpDesde)
        Me.Panel1.Controls.Add(Me.bscNombreLocalidad)
        Me.Panel1.Controls.Add(Me.lblDesde)
        Me.Panel1.Controls.Add(Me.lblHasta)
        Me.Panel1.Controls.Add(Me.dtpHasta)
        Me.Panel1.Controls.Add(Me.chkMesCompleto)
        Me.Panel1.Controls.Add(Me.dtpHasta2)
        Me.Panel1.Controls.Add(Me.lblDesde2)
        Me.Panel1.Controls.Add(Me.cmbZonaGeografica)
        Me.Panel1.Controls.Add(Me.lblHasta2)
        Me.Panel1.Controls.Add(Me.chbVendedor)
        Me.Panel1.Controls.Add(Me.dtpDesde2)
        Me.Panel1.Controls.Add(Me.cmbVendedor)
        Me.Panel1.Controls.Add(Me.chbProducto)
        Me.Panel1.Controls.Add(Me.chkMesCompleto2)
        Me.Panel1.Controls.Add(Me.bscCliente)
        Me.Panel1.Controls.Add(Me.bscCodigoCliente)
        Me.Panel1.Controls.Add(Me.chbCliente)
        Me.Panel1.Controls.Add(Me.chbZonaGeografica)
        Me.Panel1.Controls.Add(Me.chbLocalidad)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(945, 120)
        Me.Panel1.TabIndex = 0
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(834, 62)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 34
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'rbtPorMonto
        '
        Me.rbtPorMonto.AutoSize = True
        Me.rbtPorMonto.Location = New System.Drawing.Point(564, 96)
        Me.rbtPorMonto.Name = "rbtPorMonto"
        Me.rbtPorMonto.Size = New System.Drawing.Size(74, 17)
        Me.rbtPorMonto.TabIndex = 24
        Me.rbtPorMonto.Text = "Por Monto"
        Me.rbtPorMonto.UseVisualStyleBackColor = True
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.Enabled = False
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(189, 95)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(276, 20)
        Me.bscProducto2.TabIndex = 19
        '
        'rbtPorKilos
        '
        Me.rbtPorKilos.AutoSize = True
        Me.rbtPorKilos.Checked = True
        Me.rbtPorKilos.Location = New System.Drawing.Point(492, 96)
        Me.rbtPorKilos.Name = "rbtPorKilos"
        Me.rbtPorKilos.Size = New System.Drawing.Size(66, 17)
        Me.rbtPorKilos.TabIndex = 23
        Me.rbtPorKilos.TabStop = True
        Me.rbtPorKilos.Text = "Por Kilos"
        Me.rbtPorKilos.UseVisualStyleBackColor = True
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(12, 19)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
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
        Me.chbConIVA.Location = New System.Drawing.Point(654, 96)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 25
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
        Me.chbConIVA.Visible = False
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.Enabled = False
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(78, 95)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(109, 20)
        Me.bscCodigoProducto2.TabIndex = 18
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.AyudaAncho = 140
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidad"
        Me.bscCodigoLocalidad.ColumnasAlineacion = Nothing
        Me.bscCodigoLocalidad.ColumnasAncho = Nothing
        Me.bscCodigoLocalidad.ColumnasFormato = Nothing
        Me.bscCodigoLocalidad.ColumnasOcultas = Nothing
        Me.bscCodigoLocalidad.ColumnasTitulos = Nothing
        Me.bscCodigoLocalidad.Datos = Nothing
        Me.bscCodigoLocalidad.FilaDevuelta = Nothing
        Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoLocalidad.IsDecimal = False
        Me.bscCodigoLocalidad.IsNumber = False
        Me.bscCodigoLocalidad.IsPK = False
        Me.bscCodigoLocalidad.IsRequired = False
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Nothing
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(541, 59)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = False
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(97, 20)
        Me.bscCodigoLocalidad.TabIndex = 21
        Me.bscCodigoLocalidad.Titulo = Nothing
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "MM/yyyy"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(367, 5)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(70, 20)
        Me.dtpDesde.TabIndex = 4
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(285, 8)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(82, 13)
        Me.lblDesde.TabIndex = 3
        Me.lblDesde.Text = "Rango 1 Desde"
        '
        'bscNombreLocalidad
        '
        Me.bscNombreLocalidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscNombreLocalidad.AyudaAncho = 140
        Me.bscNombreLocalidad.BindearPropiedadControl = Nothing
        Me.bscNombreLocalidad.BindearPropiedadEntidad = Nothing
        Me.bscNombreLocalidad.ColumnasAlineacion = Nothing
        Me.bscNombreLocalidad.ColumnasAncho = Nothing
        Me.bscNombreLocalidad.ColumnasFormato = Nothing
        Me.bscNombreLocalidad.ColumnasOcultas = Nothing
        Me.bscNombreLocalidad.ColumnasTitulos = Nothing
        Me.bscNombreLocalidad.Datos = Nothing
        Me.bscNombreLocalidad.FilaDevuelta = Nothing
        Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreLocalidad.IsDecimal = False
        Me.bscNombreLocalidad.IsNumber = False
        Me.bscNombreLocalidad.IsPK = False
        Me.bscNombreLocalidad.IsRequired = False
        Me.bscNombreLocalidad.Key = ""
        Me.bscNombreLocalidad.LabelAsoc = Nothing
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(641, 59)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = False
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(187, 20)
        Me.bscNombreLocalidad.TabIndex = 22
        Me.bscNombreLocalidad.Titulo = Nothing
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(438, 8)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(79, 13)
        Me.lblHasta.TabIndex = 5
        Me.lblHasta.Text = "Rango 1 Hasta"
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(518, 5)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(70, 20)
        Me.dtpHasta.TabIndex = 6
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(200, 7)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(90, 17)
        Me.chkMesCompleto.TabIndex = 2
        Me.chkMesCompleto.Text = "Rango 1 Mes"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta2
        '
        Me.dtpHasta2.BindearPropiedadControl = Nothing
        Me.dtpHasta2.BindearPropiedadEntidad = Nothing
        Me.dtpHasta2.CustomFormat = "MM/yyyy"
        Me.dtpHasta2.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta2.IsPK = False
        Me.dtpHasta2.IsRequired = False
        Me.dtpHasta2.Key = ""
        Me.dtpHasta2.LabelAsoc = Nothing
        Me.dtpHasta2.Location = New System.Drawing.Point(518, 31)
        Me.dtpHasta2.Name = "dtpHasta2"
        Me.dtpHasta2.Size = New System.Drawing.Size(70, 20)
        Me.dtpHasta2.TabIndex = 11
        '
        'lblDesde2
        '
        Me.lblDesde2.AutoSize = True
        Me.lblDesde2.LabelAsoc = Nothing
        Me.lblDesde2.Location = New System.Drawing.Point(285, 35)
        Me.lblDesde2.Name = "lblDesde2"
        Me.lblDesde2.Size = New System.Drawing.Size(82, 13)
        Me.lblDesde2.TabIndex = 8
        Me.lblDesde2.Text = "Rango 2 Desde"
        '
        'lblHasta2
        '
        Me.lblHasta2.AutoSize = True
        Me.lblHasta2.LabelAsoc = Nothing
        Me.lblHasta2.Location = New System.Drawing.Point(438, 35)
        Me.lblHasta2.Name = "lblHasta2"
        Me.lblHasta2.Size = New System.Drawing.Size(79, 13)
        Me.lblHasta2.TabIndex = 10
        Me.lblHasta2.Text = "Rango 2 Hasta"
        '
        'chbVendedor
        '
        Me.chbVendedor.AutoSize = True
        Me.chbVendedor.BindearPropiedadControl = Nothing
        Me.chbVendedor.BindearPropiedadEntidad = Nothing
        Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVendedor.IsPK = False
        Me.chbVendedor.IsRequired = False
        Me.chbVendedor.Key = Nothing
        Me.chbVendedor.LabelAsoc = Nothing
        Me.chbVendedor.Location = New System.Drawing.Point(599, 6)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 26
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'dtpDesde2
        '
        Me.dtpDesde2.BindearPropiedadControl = Nothing
        Me.dtpDesde2.BindearPropiedadEntidad = Nothing
        Me.dtpDesde2.CustomFormat = "MM/yyyy"
        Me.dtpDesde2.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde2.IsPK = False
        Me.dtpDesde2.IsRequired = False
        Me.dtpDesde2.Key = ""
        Me.dtpDesde2.LabelAsoc = Nothing
        Me.dtpDesde2.Location = New System.Drawing.Point(367, 31)
        Me.dtpDesde2.Name = "dtpDesde2"
        Me.dtpDesde2.Size = New System.Drawing.Size(70, 20)
        Me.dtpDesde2.TabIndex = 9
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
        Me.chbProducto.Location = New System.Drawing.Point(14, 99)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 17
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'chkMesCompleto2
        '
        Me.chkMesCompleto2.AutoSize = True
        Me.chkMesCompleto2.BindearPropiedadControl = Nothing
        Me.chkMesCompleto2.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto2.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto2.IsPK = False
        Me.chkMesCompleto2.IsRequired = False
        Me.chkMesCompleto2.Key = Nothing
        Me.chkMesCompleto2.LabelAsoc = Nothing
        Me.chkMesCompleto2.Location = New System.Drawing.Point(200, 34)
        Me.chkMesCompleto2.Name = "chkMesCompleto2"
        Me.chkMesCompleto2.Size = New System.Drawing.Size(90, 17)
        Me.chkMesCompleto2.TabIndex = 7
        Me.chkMesCompleto2.Text = "Rango 2 Mes"
        Me.chkMesCompleto2.UseVisualStyleBackColor = True
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 140
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ColumnasAlineacion = Nothing
        Me.bscCliente.ColumnasAncho = Nothing
        Me.bscCliente.ColumnasFormato = Nothing
        Me.bscCliente.ColumnasOcultas = Nothing
        Me.bscCliente.ColumnasTitulos = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.Enabled = False
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Nothing
        Me.bscCliente.Location = New System.Drawing.Point(189, 58)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(276, 23)
        Me.bscCliente.TabIndex = 16
        Me.bscCliente.Titulo = Nothing
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 140
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
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(78, 58)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(109, 21)
        Me.bscCodigoCliente.TabIndex = 14
        Me.bscCodigoCliente.Titulo = Nothing
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
        Me.chbCliente.Location = New System.Drawing.Point(14, 60)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 12
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
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
        Me.chbZonaGeografica.Location = New System.Drawing.Point(599, 33)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
        Me.chbZonaGeografica.TabIndex = 28
        Me.chbZonaGeografica.Text = "Zona Geográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
        '
        'chbLocalidad
        '
        Me.chbLocalidad.AutoSize = True
        Me.chbLocalidad.BindearPropiedadControl = Nothing
        Me.chbLocalidad.BindearPropiedadEntidad = Nothing
        Me.chbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLocalidad.IsPK = False
        Me.chbLocalidad.IsRequired = False
        Me.chbLocalidad.Key = Nothing
        Me.chbLocalidad.LabelAsoc = Nothing
        Me.chbLocalidad.Location = New System.Drawing.Point(472, 62)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 20
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
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
        Me.cmbMarcas.Size = New System.Drawing.Size(124, 21)
        Me.cmbMarcas.TabIndex = 1
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
        Me.cmbModelos.Size = New System.Drawing.Size(124, 21)
        Me.cmbModelos.TabIndex = 1
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
        Me.cmbRubros.Size = New System.Drawing.Size(125, 21)
        Me.cmbRubros.TabIndex = 1
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
        Me.cmbSubRubros.Size = New System.Drawing.Size(125, 21)
        Me.cmbSubRubros.TabIndex = 1
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
        Me.cmbSubSubRubros.Size = New System.Drawing.Size(115, 21)
        Me.cmbSubSubRubros.TabIndex = 1
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(60, 15)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'cmbZonaGeografica
        '
        Me.cmbZonaGeografica.BindearPropiedadControl = Nothing
        Me.cmbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaGeografica.Enabled = False
        Me.cmbZonaGeografica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbZonaGeografica.FormattingEnabled = True
        Me.cmbZonaGeografica.IsPK = False
        Me.cmbZonaGeografica.IsRequired = False
        Me.cmbZonaGeografica.Key = Nothing
        Me.cmbZonaGeografica.LabelAsoc = Nothing
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(702, 31)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(162, 21)
        Me.cmbZonaGeografica.TabIndex = 29
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Enabled = False
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Location = New System.Drawing.Point(702, 4)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(162, 21)
        Me.cmbVendedor.TabIndex = 27
        '
        'InfKilosCompMensualPorClienteDobleRango
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 599)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "InfKilosCompMensualPorClienteDobleRango"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Kilos Comparativo Mensual por Cliente Doble Rango"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbConsultar.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grbConsultar As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnConsultar As Controles.Button
    Friend WithEvents rbtPorMonto As RadioButton
    Friend WithEvents bscProducto2 As Controles.Buscador2
    Friend WithEvents rbtPorKilos As RadioButton
    Friend WithEvents cmbSucursal As ComboBoxSucursales
    Friend WithEvents lblSucursal As Controles.Label
    Friend WithEvents chbConIVA As Controles.CheckBox
    Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
    Friend WithEvents bscCodigoLocalidad As Controles.Buscador
    Friend WithEvents dtpDesde As Controles.DateTimePicker
    Friend WithEvents lblDesde As Controles.Label
    Friend WithEvents bscNombreLocalidad As Controles.Buscador
    Friend WithEvents lblHasta As Controles.Label
    Friend WithEvents dtpHasta As Controles.DateTimePicker
    Friend WithEvents chkMesCompleto As Controles.CheckBox
    Friend WithEvents dtpHasta2 As Controles.DateTimePicker
    Friend WithEvents lblDesde2 As Controles.Label
    Friend WithEvents cmbZonaGeografica As Controles.ComboBox
    Friend WithEvents lblHasta2 As Controles.Label
    Friend WithEvents chbVendedor As Controles.CheckBox
    Friend WithEvents dtpDesde2 As Controles.DateTimePicker
    Friend WithEvents cmbVendedor As Controles.ComboBox
    Friend WithEvents chbProducto As Controles.CheckBox
    Friend WithEvents chkMesCompleto2 As Controles.CheckBox
    Friend WithEvents bscCliente As Controles.Buscador
    Friend WithEvents bscCodigoCliente As Controles.Buscador
    Friend WithEvents chbCliente As Controles.CheckBox
    Friend WithEvents chbZonaGeografica As Controles.CheckBox
    Friend WithEvents chbLocalidad As Controles.CheckBox
End Class
