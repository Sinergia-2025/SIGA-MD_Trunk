<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarLotesDeProductos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarLotesDeProductos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLote")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaIngreso")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadInicial")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadActual")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.dgvDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.chbStockUnificado = New Eniac.Controles.CheckBox()
        Me.cmbTipoDeposito = New Eniac.Controles.ComboBox()
        Me.chbTipoDeposito = New Eniac.Controles.CheckBox()
        Me.cmbDepositos = New Eniac.Win.ComboBoxDepositos()
        Me.chbDeposito = New Eniac.Controles.Label()
        Me.chbConStock = New System.Windows.Forms.CheckBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.cmbSubRubro = New Eniac.Controles.ComboBox()
        Me.clbSucursales = New Eniac.Controles.CheckedListBox()
        Me.grbVencimiento = New System.Windows.Forms.GroupBox()
        Me.optVencVencidos = New Eniac.Controles.RadioButton()
        Me.optVencTodos = New Eniac.Controles.RadioButton()
        Me.chkFechaLote = New Eniac.Controles.CheckBox()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbSubRubro = New Eniac.Controles.CheckBox()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.tstBarra.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.grbVencimiento.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(914, 29)
        Me.tstBarra.TabIndex = 33
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
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "Sucursal"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 103
        UltraGridColumn2.Header.Caption = "Lote"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 142
        UltraGridColumn3.Header.Caption = "Codigo"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.Header.Caption = "Producto"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 280
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn5.CellAppearance = Appearance2
        UltraGridColumn5.Header.Caption = "Ingreso"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 90
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance3
        UltraGridColumn6.Header.Caption = "Vencimiento"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 90
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance4
        UltraGridColumn7.Header.Caption = "Cant. Inicial"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 80
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance5
        UltraGridColumn8.Header.Caption = "Cant. Actual"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 80
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance6
        UltraGridColumn9.Header.Caption = "Depósito"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 70
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance7
        UltraGridColumn10.Header.Caption = "Ubicación"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 70
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
        Me.dgvDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvDetalle.DisplayLayout.GroupByBox.Appearance = Appearance8
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance9
        Me.dgvDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvDetalle.DisplayLayout.GroupByBox.Prompt = " Arrastrar la Columna que desea agrupar"
        Appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance10.BackColor2 = System.Drawing.SystemColors.Control
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance10
        Me.dgvDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.Highlight
        Appearance12.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance12
        Me.dgvDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgvDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Me.dgvDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance13
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgvDetalle.DisplayLayout.Override.CellAppearance = Appearance14
        Me.dgvDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgvDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance15.BackColor = System.Drawing.SystemColors.Control
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance15
        Appearance16.TextHAlignAsString = "Left"
        Me.dgvDetalle.DisplayLayout.Override.HeaderAppearance = Appearance16
        Me.dgvDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgvDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Me.dgvDetalle.DisplayLayout.Override.RowAppearance = Appearance17
        Me.dgvDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgvDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.dgvDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 197)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(890, 272)
        Me.dgvDetalle.TabIndex = 34
        Me.dgvDetalle.Text = "UltraGrid1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Lista de Precios Múltiples"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.dgvDetalle
        Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance19
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
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.chbStockUnificado)
        Me.grbFiltros.Controls.Add(Me.cmbTipoDeposito)
        Me.grbFiltros.Controls.Add(Me.chbTipoDeposito)
        Me.grbFiltros.Controls.Add(Me.cmbDepositos)
        Me.grbFiltros.Controls.Add(Me.chbDeposito)
        Me.grbFiltros.Controls.Add(Me.chbConStock)
        Me.grbFiltros.Controls.Add(Me.bscProducto2)
        Me.grbFiltros.Controls.Add(Me.bscCodigoProducto2)
        Me.grbFiltros.Controls.Add(Me.cmbSubRubro)
        Me.grbFiltros.Controls.Add(Me.clbSucursales)
        Me.grbFiltros.Controls.Add(Me.grbVencimiento)
        Me.grbFiltros.Controls.Add(Me.chkFechaLote)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.chbRubro)
        Me.grbFiltros.Controls.Add(Me.cmbRubro)
        Me.grbFiltros.Controls.Add(Me.chbMarca)
        Me.grbFiltros.Controls.Add(Me.cmbMarca)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbProducto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.chbSubRubro)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(890, 159)
        Me.grbFiltros.TabIndex = 87
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'chbStockUnificado
        '
        Me.chbStockUnificado.AutoSize = True
        Me.chbStockUnificado.BindearPropiedadControl = Nothing
        Me.chbStockUnificado.BindearPropiedadEntidad = Nothing
        Me.chbStockUnificado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbStockUnificado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbStockUnificado.IsPK = False
        Me.chbStockUnificado.IsRequired = False
        Me.chbStockUnificado.Key = Nothing
        Me.chbStockUnificado.LabelAsoc = Nothing
        Me.chbStockUnificado.Location = New System.Drawing.Point(306, 100)
        Me.chbStockUnificado.Name = "chbStockUnificado"
        Me.chbStockUnificado.Size = New System.Drawing.Size(102, 17)
        Me.chbStockUnificado.TabIndex = 112
        Me.chbStockUnificado.Text = "Stock Unificado"
        Me.chbStockUnificado.UseVisualStyleBackColor = True
        '
        'cmbTipoDeposito
        '
        Me.cmbTipoDeposito.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoDeposito.BindearPropiedadEntidad = "TipoDeposito"
        Me.cmbTipoDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDeposito.Enabled = False
        Me.cmbTipoDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDeposito.FormattingEnabled = True
        Me.cmbTipoDeposito.IsPK = False
        Me.cmbTipoDeposito.IsRequired = False
        Me.cmbTipoDeposito.Key = Nothing
        Me.cmbTipoDeposito.LabelAsoc = Me.chbTipoDeposito
        Me.cmbTipoDeposito.Location = New System.Drawing.Point(396, 71)
        Me.cmbTipoDeposito.Name = "cmbTipoDeposito"
        Me.cmbTipoDeposito.Size = New System.Drawing.Size(148, 21)
        Me.cmbTipoDeposito.TabIndex = 111
        '
        'chbTipoDeposito
        '
        Me.chbTipoDeposito.AutoSize = True
        Me.chbTipoDeposito.BindearPropiedadControl = Nothing
        Me.chbTipoDeposito.BindearPropiedadEntidad = Nothing
        Me.chbTipoDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoDeposito.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoDeposito.IsPK = False
        Me.chbTipoDeposito.IsRequired = False
        Me.chbTipoDeposito.Key = Nothing
        Me.chbTipoDeposito.LabelAsoc = Nothing
        Me.chbTipoDeposito.Location = New System.Drawing.Point(306, 73)
        Me.chbTipoDeposito.Name = "chbTipoDeposito"
        Me.chbTipoDeposito.Size = New System.Drawing.Size(92, 17)
        Me.chbTipoDeposito.TabIndex = 110
        Me.chbTipoDeposito.Text = "Tipo Depósito"
        '
        'cmbDepositos
        '
        Me.cmbDepositos.BindearPropiedadControl = Nothing
        Me.cmbDepositos.BindearPropiedadEntidad = Nothing
        Me.cmbDepositos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositos.FormattingEnabled = True
        Me.cmbDepositos.IsPK = False
        Me.cmbDepositos.IsRequired = False
        Me.cmbDepositos.Key = Nothing
        Me.cmbDepositos.LabelAsoc = Nothing
        Me.cmbDepositos.Location = New System.Drawing.Point(396, 44)
        Me.cmbDepositos.Name = "cmbDepositos"
        Me.cmbDepositos.Size = New System.Drawing.Size(148, 21)
        Me.cmbDepositos.TabIndex = 109
        '
        'chbDeposito
        '
        Me.chbDeposito.AutoSize = True
        Me.chbDeposito.LabelAsoc = Nothing
        Me.chbDeposito.Location = New System.Drawing.Point(306, 52)
        Me.chbDeposito.Name = "chbDeposito"
        Me.chbDeposito.Size = New System.Drawing.Size(49, 13)
        Me.chbDeposito.TabIndex = 108
        Me.chbDeposito.Text = "Depósito"
        '
        'chbConStock
        '
        Me.chbConStock.Checked = True
        Me.chbConStock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbConStock.Location = New System.Drawing.Point(589, 17)
        Me.chbConStock.Name = "chbConStock"
        Me.chbConStock.Size = New System.Drawing.Size(96, 20)
        Me.chbConStock.TabIndex = 107
        Me.chbConStock.Text = "Con Stock"
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
        Me.bscProducto2.Location = New System.Drawing.Point(232, 17)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(334, 20)
        Me.bscProducto2.TabIndex = 106
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(78, 17)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(148, 20)
        Me.bscCodigoProducto2.TabIndex = 105
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro.Enabled = False
        Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro.FormattingEnabled = True
        Me.cmbSubRubro.IsPK = False
        Me.cmbSubRubro.IsRequired = False
        Me.cmbSubRubro.Key = Nothing
        Me.cmbSubRubro.LabelAsoc = Nothing
        Me.cmbSubRubro.Location = New System.Drawing.Point(82, 98)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(209, 21)
        Me.cmbSubRubro.TabIndex = 104
        '
        'clbSucursales
        '
        Me.clbSucursales.CheckOnClick = True
        Me.clbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.clbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.clbSucursales.FormattingEnabled = True
        Me.clbSucursales.IsPK = False
        Me.clbSucursales.IsRequired = False
        Me.clbSucursales.Key = Nothing
        Me.clbSucursales.LabelAsoc = Nothing
        Me.clbSucursales.Location = New System.Drawing.Point(589, 46)
        Me.clbSucursales.Name = "clbSucursales"
        Me.clbSucursales.Size = New System.Drawing.Size(169, 79)
        Me.clbSucursales.TabIndex = 102
        Me.clbSucursales.Visible = False
        '
        'grbVencimiento
        '
        Me.grbVencimiento.Controls.Add(Me.optVencVencidos)
        Me.grbVencimiento.Controls.Add(Me.optVencTodos)
        Me.grbVencimiento.Location = New System.Drawing.Point(394, 118)
        Me.grbVencimiento.Name = "grbVencimiento"
        Me.grbVencimiento.Size = New System.Drawing.Size(152, 35)
        Me.grbVencimiento.TabIndex = 101
        Me.grbVencimiento.TabStop = False
        Me.grbVencimiento.Text = "Vencimiento"
        '
        'optVencVencidos
        '
        Me.optVencVencidos.AutoSize = True
        Me.optVencVencidos.BindearPropiedadControl = Nothing
        Me.optVencVencidos.BindearPropiedadEntidad = Nothing
        Me.optVencVencidos.ForeColorFocus = System.Drawing.Color.Red
        Me.optVencVencidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optVencVencidos.IsPK = False
        Me.optVencVencidos.IsRequired = False
        Me.optVencVencidos.Key = Nothing
        Me.optVencVencidos.LabelAsoc = Nothing
        Me.optVencVencidos.Location = New System.Drawing.Point(76, 14)
        Me.optVencVencidos.Name = "optVencVencidos"
        Me.optVencVencidos.Size = New System.Drawing.Size(69, 17)
        Me.optVencVencidos.TabIndex = 1
        Me.optVencVencidos.Text = "Vencidos"
        Me.optVencVencidos.UseVisualStyleBackColor = True
        '
        'optVencTodos
        '
        Me.optVencTodos.AutoSize = True
        Me.optVencTodos.BindearPropiedadControl = Nothing
        Me.optVencTodos.BindearPropiedadEntidad = Nothing
        Me.optVencTodos.Checked = True
        Me.optVencTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.optVencTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optVencTodos.IsPK = False
        Me.optVencTodos.IsRequired = False
        Me.optVencTodos.Key = Nothing
        Me.optVencTodos.LabelAsoc = Nothing
        Me.optVencTodos.Location = New System.Drawing.Point(15, 14)
        Me.optVencTodos.Name = "optVencTodos"
        Me.optVencTodos.Size = New System.Drawing.Size(55, 17)
        Me.optVencTodos.TabIndex = 0
        Me.optVencTodos.TabStop = True
        Me.optVencTodos.Text = "Todos"
        Me.optVencTodos.UseVisualStyleBackColor = True
        '
        'chkFechaLote
        '
        Me.chkFechaLote.AutoSize = True
        Me.chkFechaLote.BindearPropiedadControl = Nothing
        Me.chkFechaLote.BindearPropiedadEntidad = Nothing
        Me.chkFechaLote.ForeColorFocus = System.Drawing.Color.Red
        Me.chkFechaLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkFechaLote.IsPK = False
        Me.chkFechaLote.IsRequired = False
        Me.chkFechaLote.Key = Nothing
        Me.chkFechaLote.LabelAsoc = Nothing
        Me.chkFechaLote.Location = New System.Drawing.Point(11, 130)
        Me.chkFechaLote.Name = "chkFechaLote"
        Me.chkFechaLote.Size = New System.Drawing.Size(102, 17)
        Me.chkFechaLote.TabIndex = 100
        Me.chkFechaLote.Text = "Fecha Vto Lote:"
        Me.chkFechaLote.UseVisualStyleBackColor = True
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Location = New System.Drawing.Point(776, 125)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(96, 20)
        Me.chkExpandAll.TabIndex = 99
        Me.chkExpandAll.Text = "Expandir todo"
        '
        'chbRubro
        '
        Me.chbRubro.AutoSize = True
        Me.chbRubro.BindearPropiedadControl = Nothing
        Me.chbRubro.BindearPropiedadEntidad = Nothing
        Me.chbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRubro.IsPK = False
        Me.chbRubro.IsRequired = False
        Me.chbRubro.Key = Nothing
        Me.chbRubro.LabelAsoc = Nothing
        Me.chbRubro.Location = New System.Drawing.Point(11, 73)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 97
        Me.chbRubro.Text = "Rubro"
        Me.chbRubro.UseVisualStyleBackColor = True
        '
        'cmbRubro
        '
        Me.cmbRubro.BindearPropiedadControl = Nothing
        Me.cmbRubro.BindearPropiedadEntidad = Nothing
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.Enabled = False
        Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.IsPK = False
        Me.cmbRubro.IsRequired = False
        Me.cmbRubro.Key = Nothing
        Me.cmbRubro.LabelAsoc = Nothing
        Me.cmbRubro.Location = New System.Drawing.Point(82, 71)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(209, 21)
        Me.cmbRubro.TabIndex = 98
        '
        'chbMarca
        '
        Me.chbMarca.AutoSize = True
        Me.chbMarca.BindearPropiedadControl = Nothing
        Me.chbMarca.BindearPropiedadEntidad = Nothing
        Me.chbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarca.IsPK = False
        Me.chbMarca.IsRequired = False
        Me.chbMarca.Key = Nothing
        Me.chbMarca.LabelAsoc = Nothing
        Me.chbMarca.Location = New System.Drawing.Point(11, 46)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 95
        Me.chbMarca.Text = "Marca"
        Me.chbMarca.UseVisualStyleBackColor = True
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = False
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Nothing
        Me.cmbMarca.Location = New System.Drawing.Point(82, 44)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(209, 21)
        Me.cmbMarca.TabIndex = 96
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(776, 74)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 94
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.chbProducto.Location = New System.Drawing.Point(11, 19)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 89
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(289, 128)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(88, 20)
        Me.dtpHasta.TabIndex = 88
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(251, 132)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 93
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(155, 128)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(88, 20)
        Me.dtpDesde.TabIndex = 87
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(115, 132)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 92
        Me.lblDesde.Text = "Desde"
        '
        'chbSubRubro
        '
        Me.chbSubRubro.AutoSize = True
        Me.chbSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubRubro.IsPK = False
        Me.chbSubRubro.IsRequired = False
        Me.chbSubRubro.Key = Nothing
        Me.chbSubRubro.LabelAsoc = Nothing
        Me.chbSubRubro.Location = New System.Drawing.Point(11, 101)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 103
        Me.chbSubRubro.Text = "SubRubro"
        Me.chbSubRubro.UseVisualStyleBackColor = True
        '
        'ConsultarLotesDeProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 484)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ConsultarLotesDeProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Lotes de Productos"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.grbVencimiento.ResumeLayout(False)
        Me.grbVencimiento.PerformLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dgvDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents chkFechaLote As Eniac.Controles.CheckBox
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents grbVencimiento As System.Windows.Forms.GroupBox
   Friend WithEvents optVencVencidos As Eniac.Controles.RadioButton
   Friend WithEvents optVencTodos As Eniac.Controles.RadioButton
   Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
    Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbConStock As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipoDeposito As Controles.ComboBox
    Friend WithEvents chbTipoDeposito As Controles.CheckBox
    Friend WithEvents cmbDepositos As ComboBoxDepositos
    Friend WithEvents chbDeposito As Controles.Label
    Friend WithEvents chbStockUnificado As Controles.CheckBox
End Class
