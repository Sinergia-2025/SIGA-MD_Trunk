<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelDeControlPorTipo
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
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadFechaIngreso")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadFechaEntProg")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadFechaEgreso")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadStatusLiberado")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadStatusEntregado")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadNumeroChasis")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadFechaEntReProg")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoModelo")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoModeloTipo")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PanelDeControlPorTipo))
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.MenuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ListaDeControlPorProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblCantidadCochesEnLinea = New System.Windows.Forms.Label()
      Me.chbMostrarReparaciones = New System.Windows.Forms.CheckBox()
      Me.chbActualizacionAutomatica = New System.Windows.Forms.CheckBox()
      Me.txtMinutos = New System.Windows.Forms.NumericUpDown()
      Me.lblSegundos = New Eniac.Controles.Label()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbLiberadoPDI = New Eniac.Controles.ComboBox()
      Me.lblLiberadosPDI = New Eniac.Controles.Label()
      Me.lblEntregados = New Eniac.Controles.Label()
      Me.cmbEntregados = New Eniac.Controles.ComboBox()
      Me.lblLiberados = New Eniac.Controles.Label()
      Me.cmbLiberado = New Eniac.Controles.ComboBox()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.chbUbicacion = New Eniac.Controles.CheckBox()
      Me.cmbUbicacion = New Eniac.Controles.ComboBox()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.chbEstado = New Eniac.Controles.CheckBox()
      Me.cmbEstadoCalidad = New Eniac.Controles.ComboBox()
      Me.chbMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbFInalizarListas = New System.Windows.Forms.ToolStripButton()
      Me.tssFinalizarListas = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.MenuContext.SuspendLayout()
      Me.Panel1.SuspendLayout()
      CType(Me.txtMinutos, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.UltraGridPrintDocument1.FitWidthToPages = 1
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance18
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
      UltraGridColumn23.Header.Caption = "Codigo"
      UltraGridColumn23.Header.VisiblePosition = 0
      UltraGridColumn23.Width = 83
      UltraGridColumn24.Header.Caption = "Producto"
      UltraGridColumn24.Header.VisiblePosition = 2
      UltraGridColumn24.Width = 150
      UltraGridColumn25.Header.Caption = "Cliente"
      UltraGridColumn25.Header.VisiblePosition = 5
      UltraGridColumn25.Width = 224
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn26.CellAppearance = Appearance2
      UltraGridColumn26.Header.Caption = "Fecha Ingreso"
      UltraGridColumn26.Header.VisiblePosition = 6
      UltraGridColumn26.Width = 85
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn27.CellAppearance = Appearance3
      UltraGridColumn27.Header.Caption = "Fecha Entrega Programada"
      UltraGridColumn27.Header.VisiblePosition = 7
      UltraGridColumn27.Hidden = True
      UltraGridColumn27.Width = 85
      Appearance4.TextHAlignAsString = "Center"
      UltraGridColumn28.CellAppearance = Appearance4
      UltraGridColumn28.Header.Caption = "Fecha Egreso"
      UltraGridColumn28.Header.VisiblePosition = 9
      UltraGridColumn28.Width = 85
      UltraGridColumn29.Header.Caption = "L"
      UltraGridColumn29.Header.VisiblePosition = 10
      UltraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn29.Width = 31
      UltraGridColumn30.Header.Caption = "E"
      UltraGridColumn30.Header.VisiblePosition = 11
      UltraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn30.Width = 27
      UltraGridColumn31.Header.Caption = "Nro de Chasis"
      UltraGridColumn31.Header.VisiblePosition = 4
      UltraGridColumn31.Width = 132
      Appearance5.TextHAlignAsString = "Center"
      UltraGridColumn32.CellAppearance = Appearance5
      UltraGridColumn32.Header.Caption = "Fecha Entrega Prog/Reprog."
      UltraGridColumn32.Header.VisiblePosition = 8
      UltraGridColumn32.Width = 85
      UltraGridColumn33.Header.Caption = "Modelo"
      UltraGridColumn33.Header.VisiblePosition = 3
      UltraGridColumn33.Hidden = True
      UltraGridColumn33.Width = 132
      UltraGridColumn34.Header.Caption = "Tipo Modelo"
      UltraGridColumn34.Header.VisiblePosition = 1
      UltraGridColumn34.Width = 87
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance6.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance6
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = " Arrastrar la Columna que desea agrupar"
      Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance8.BackColor2 = System.Drawing.SystemColors.Control
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance9
      Appearance10.BackColor = System.Drawing.SystemColors.Highlight
      Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance11
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance13.BackColor = System.Drawing.SystemColors.Control
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance16.BackColor = System.Drawing.Color.SkyBlue
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance16
      Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(0, 167)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(984, 372)
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
      'Timer1
      '
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.lblCantidadCochesEnLinea)
      Me.Panel1.Controls.Add(Me.chbMostrarReparaciones)
      Me.Panel1.Controls.Add(Me.chbActualizacionAutomatica)
      Me.Panel1.Controls.Add(Me.txtMinutos)
      Me.Panel1.Controls.Add(Me.lblSegundos)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 137)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(984, 30)
      Me.Panel1.TabIndex = 14
      '
      'lblCantidadCochesEnLinea
      '
      Me.lblCantidadCochesEnLinea.AutoSize = True
      Me.lblCantidadCochesEnLinea.Location = New System.Drawing.Point(464, 9)
      Me.lblCantidadCochesEnLinea.Name = "lblCantidadCochesEnLinea"
      Me.lblCantidadCochesEnLinea.Size = New System.Drawing.Size(0, 13)
      Me.lblCantidadCochesEnLinea.TabIndex = 4
      '
      'chbMostrarReparaciones
      '
      Me.chbMostrarReparaciones.AutoSize = True
      Me.chbMostrarReparaciones.Location = New System.Drawing.Point(277, 8)
      Me.chbMostrarReparaciones.Name = "chbMostrarReparaciones"
      Me.chbMostrarReparaciones.Size = New System.Drawing.Size(130, 17)
      Me.chbMostrarReparaciones.TabIndex = 3
      Me.chbMostrarReparaciones.Text = "Mostrar Reparaciones"
      Me.chbMostrarReparaciones.UseVisualStyleBackColor = True
      '
      'chbActualizacionAutomatica
      '
      Me.chbActualizacionAutomatica.AutoSize = True
      Me.chbActualizacionAutomatica.Checked = True
      Me.chbActualizacionAutomatica.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbActualizacionAutomatica.Location = New System.Drawing.Point(3, 7)
      Me.chbActualizacionAutomatica.Name = "chbActualizacionAutomatica"
      Me.chbActualizacionAutomatica.Size = New System.Drawing.Size(144, 17)
      Me.chbActualizacionAutomatica.TabIndex = 0
      Me.chbActualizacionAutomatica.Text = "Actualización automática"
      Me.chbActualizacionAutomatica.UseVisualStyleBackColor = True
      '
      'txtMinutos
      '
      Me.txtMinutos.Location = New System.Drawing.Point(148, 5)
      Me.txtMinutos.Name = "txtMinutos"
      Me.txtMinutos.Size = New System.Drawing.Size(60, 20)
      Me.txtMinutos.TabIndex = 1
      Me.txtMinutos.TabStop = False
      Me.txtMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtMinutos.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblSegundos
      '
      Me.lblSegundos.AutoSize = True
      Me.lblSegundos.LabelAsoc = Nothing
      Me.lblSegundos.Location = New System.Drawing.Point(211, 9)
      Me.lblSegundos.Name = "lblSegundos"
      Me.lblSegundos.Size = New System.Drawing.Size(43, 13)
      Me.lblSegundos.TabIndex = 2
      Me.lblSegundos.Text = "minutos"
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.cmbLiberadoPDI)
      Me.grbFiltros.Controls.Add(Me.lblEntregados)
      Me.grbFiltros.Controls.Add(Me.cmbEntregados)
      Me.grbFiltros.Controls.Add(Me.lblLiberados)
      Me.grbFiltros.Controls.Add(Me.cmbLiberado)
      Me.grbFiltros.Controls.Add(Me.chbFecha)
      Me.grbFiltros.Controls.Add(Me.chbUbicacion)
      Me.grbFiltros.Controls.Add(Me.cmbUbicacion)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.chbEstado)
      Me.grbFiltros.Controls.Add(Me.cmbEstadoCalidad)
      Me.grbFiltros.Controls.Add(Me.chbMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.bscProducto2)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProducto2)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbProducto)
      Me.grbFiltros.Controls.Add(Me.lblLiberadosPDI)
      Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
      Me.grbFiltros.Location = New System.Drawing.Point(0, 29)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(984, 108)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      '
      'cmbLiberadoPDI
      '
      Me.cmbLiberadoPDI.BindearPropiedadControl = "SelectedValue"
      Me.cmbLiberadoPDI.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbLiberadoPDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLiberadoPDI.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLiberadoPDI.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLiberadoPDI.FormattingEnabled = True
      Me.cmbLiberadoPDI.IsPK = False
      Me.cmbLiberadoPDI.IsRequired = False
      Me.cmbLiberadoPDI.Key = Nothing
      Me.cmbLiberadoPDI.LabelAsoc = Me.lblLiberadosPDI
      Me.cmbLiberadoPDI.Location = New System.Drawing.Point(786, 18)
      Me.cmbLiberadoPDI.Name = "cmbLiberadoPDI"
      Me.cmbLiberadoPDI.Size = New System.Drawing.Size(88, 21)
      Me.cmbLiberadoPDI.TabIndex = 22
      '
      'lblLiberadosPDI
      '
      Me.lblLiberadosPDI.AutoSize = True
      Me.lblLiberadosPDI.LabelAsoc = Nothing
      Me.lblLiberadosPDI.Location = New System.Drawing.Point(709, 22)
      Me.lblLiberadosPDI.Name = "lblLiberadosPDI"
      Me.lblLiberadosPDI.Size = New System.Drawing.Size(74, 13)
      Me.lblLiberadosPDI.TabIndex = 21
      Me.lblLiberadosPDI.Text = "Liberados PDI"
      '
      'lblEntregados
      '
      Me.lblEntregados.AutoSize = True
      Me.lblEntregados.LabelAsoc = Nothing
      Me.lblEntregados.Location = New System.Drawing.Point(709, 48)
      Me.lblEntregados.Name = "lblEntregados"
      Me.lblEntregados.Size = New System.Drawing.Size(61, 13)
      Me.lblEntregados.TabIndex = 8
      Me.lblEntregados.Text = "Entregados"
      '
      'cmbEntregados
      '
      Me.cmbEntregados.BindearPropiedadControl = "SelectedValue"
      Me.cmbEntregados.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbEntregados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEntregados.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEntregados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEntregados.FormattingEnabled = True
      Me.cmbEntregados.IsPK = False
      Me.cmbEntregados.IsRequired = False
      Me.cmbEntregados.Key = Nothing
      Me.cmbEntregados.LabelAsoc = Me.lblEntregados
      Me.cmbEntregados.Location = New System.Drawing.Point(786, 45)
      Me.cmbEntregados.Name = "cmbEntregados"
      Me.cmbEntregados.Size = New System.Drawing.Size(88, 21)
      Me.cmbEntregados.TabIndex = 9
      '
      'lblLiberados
      '
      Me.lblLiberados.AutoSize = True
      Me.lblLiberados.LabelAsoc = Nothing
      Me.lblLiberados.Location = New System.Drawing.Point(556, 21)
      Me.lblLiberados.Name = "lblLiberados"
      Me.lblLiberados.Size = New System.Drawing.Size(53, 13)
      Me.lblLiberados.TabIndex = 6
      Me.lblLiberados.Text = "Liberados"
      '
      'cmbLiberado
      '
      Me.cmbLiberado.BindearPropiedadControl = "SelectedValue"
      Me.cmbLiberado.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbLiberado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLiberado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLiberado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLiberado.FormattingEnabled = True
      Me.cmbLiberado.IsPK = False
      Me.cmbLiberado.IsRequired = False
      Me.cmbLiberado.Key = Nothing
      Me.cmbLiberado.LabelAsoc = Me.lblLiberados
      Me.cmbLiberado.Location = New System.Drawing.Point(615, 17)
      Me.cmbLiberado.Name = "cmbLiberado"
      Me.cmbLiberado.Size = New System.Drawing.Size(88, 21)
      Me.cmbLiberado.TabIndex = 7
      '
      'chbFecha
      '
      Me.chbFecha.AutoSize = True
      Me.chbFecha.BindearPropiedadControl = Nothing
      Me.chbFecha.BindearPropiedadEntidad = Nothing
      Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFecha.IsPK = False
      Me.chbFecha.IsRequired = False
      Me.chbFecha.Key = Nothing
      Me.chbFecha.LabelAsoc = Nothing
      Me.chbFecha.Location = New System.Drawing.Point(14, 19)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(94, 17)
      Me.chbFecha.TabIndex = 0
      Me.chbFecha.Text = "Fecha Ingreso"
      Me.chbFecha.UseVisualStyleBackColor = True
      '
      'chbUbicacion
      '
      Me.chbUbicacion.AutoSize = True
      Me.chbUbicacion.BindearPropiedadControl = Nothing
      Me.chbUbicacion.BindearPropiedadEntidad = Nothing
      Me.chbUbicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUbicacion.IsPK = False
      Me.chbUbicacion.IsRequired = False
      Me.chbUbicacion.Key = Nothing
      Me.chbUbicacion.LabelAsoc = Nothing
      Me.chbUbicacion.Location = New System.Drawing.Point(540, 47)
      Me.chbUbicacion.Name = "chbUbicacion"
      Me.chbUbicacion.Size = New System.Drawing.Size(74, 17)
      Me.chbUbicacion.TabIndex = 13
      Me.chbUbicacion.Text = "Ubicacion"
      Me.chbUbicacion.UseVisualStyleBackColor = True
      '
      'cmbUbicacion
      '
      Me.cmbUbicacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbUbicacion.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUbicacion.Enabled = False
      Me.cmbUbicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUbicacion.FormattingEnabled = True
      Me.cmbUbicacion.IsPK = False
      Me.cmbUbicacion.IsRequired = False
      Me.cmbUbicacion.Key = Nothing
      Me.cmbUbicacion.LabelAsoc = Nothing
      Me.cmbUbicacion.Location = New System.Drawing.Point(615, 45)
      Me.cmbUbicacion.Name = "cmbUbicacion"
      Me.cmbUbicacion.Size = New System.Drawing.Size(88, 21)
      Me.cmbUbicacion.TabIndex = 14
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
      Me.chbCliente.Location = New System.Drawing.Point(14, 74)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 15
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ConfigBuscador = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Nothing
      Me.bscCodigoCliente.Location = New System.Drawing.Point(113, 71)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(147, 23)
      Me.bscCodigoCliente.TabIndex = 16
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ConfigBuscador = Nothing
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
      Me.bscCliente.Location = New System.Drawing.Point(266, 71)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(268, 23)
      Me.bscCliente.TabIndex = 17
      '
      'chbEstado
      '
      Me.chbEstado.AutoSize = True
      Me.chbEstado.BindearPropiedadControl = Nothing
      Me.chbEstado.BindearPropiedadEntidad = Nothing
      Me.chbEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEstado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEstado.IsPK = False
      Me.chbEstado.IsRequired = False
      Me.chbEstado.Key = Nothing
      Me.chbEstado.LabelAsoc = Nothing
      Me.chbEstado.Location = New System.Drawing.Point(540, 74)
      Me.chbEstado.Name = "chbEstado"
      Me.chbEstado.Size = New System.Drawing.Size(67, 17)
      Me.chbEstado.TabIndex = 18
      Me.chbEstado.Text = "Estados "
      Me.chbEstado.UseVisualStyleBackColor = True
      '
      'cmbEstadoCalidad
      '
      Me.cmbEstadoCalidad.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoCalidad.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbEstadoCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoCalidad.Enabled = False
      Me.cmbEstadoCalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoCalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoCalidad.FormattingEnabled = True
      Me.cmbEstadoCalidad.IsPK = False
      Me.cmbEstadoCalidad.IsRequired = False
      Me.cmbEstadoCalidad.Key = Nothing
      Me.cmbEstadoCalidad.LabelAsoc = Nothing
      Me.cmbEstadoCalidad.Location = New System.Drawing.Point(615, 72)
      Me.cmbEstadoCalidad.Name = "cmbEstadoCalidad"
      Me.cmbEstadoCalidad.Size = New System.Drawing.Size(146, 21)
      Me.cmbEstadoCalidad.TabIndex = 19
      '
      'chbMesCompleto
      '
      Me.chbMesCompleto.AutoSize = True
      Me.chbMesCompleto.BindearPropiedadControl = Nothing
      Me.chbMesCompleto.BindearPropiedadEntidad = Nothing
      Me.chbMesCompleto.Enabled = False
      Me.chbMesCompleto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMesCompleto.IsPK = False
      Me.chbMesCompleto.IsRequired = False
      Me.chbMesCompleto.Key = Nothing
      Me.chbMesCompleto.LabelAsoc = Me.chbFecha
      Me.chbMesCompleto.Location = New System.Drawing.Point(114, 19)
      Me.chbMesCompleto.Name = "chbMesCompleto"
      Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chbMesCompleto.TabIndex = 1
      Me.chbMesCompleto.Text = "Mes Completo"
      Me.chbMesCompleto.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.Enabled = False
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(425, 17)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 5
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Enabled = False
      Me.lblHasta.LabelAsoc = Me.chbMesCompleto
      Me.lblHasta.Location = New System.Drawing.Point(386, 21)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 4
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(257, 17)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 3
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Enabled = False
      Me.lblDesde.LabelAsoc = Me.chbMesCompleto
      Me.lblDesde.Location = New System.Drawing.Point(213, 21)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 2
      Me.lblDesde.Text = "Desde"
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
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
      Me.bscProducto2.LabelAsoc = Me.chbProducto
      Me.bscProducto2.Location = New System.Drawing.Point(266, 45)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(268, 20)
      Me.bscProducto2.TabIndex = 12
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
      Me.chbProducto.Location = New System.Drawing.Point(14, 47)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 10
      Me.chbProducto.Text = "Producto"
      Me.chbProducto.UseVisualStyleBackColor = True
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
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
      Me.bscCodigoProducto2.LabelAsoc = Me.chbProducto
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(114, 45)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
      Me.bscCodigoProducto2.TabIndex = 11
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(881, 57)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(99, 45)
      Me.btnConsultar.TabIndex = 20
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
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
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbFInalizarListas, Me.tssFinalizarListas, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
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
      'tsbFInalizarListas
      '
      Me.tsbFInalizarListas.Image = Global.Eniac.Win.My.Resources.Resources.pda2_out
      Me.tsbFInalizarListas.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbFInalizarListas.Name = "tsbFInalizarListas"
      Me.tsbFInalizarListas.Size = New System.Drawing.Size(108, 26)
      Me.tsbFInalizarListas.Text = "&Finalizar Listas"
      '
      'tssFinalizarListas
      '
      Me.tssFinalizarListas.Name = "tssFinalizarListas"
      Me.tssFinalizarListas.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      'PanelDeControlPorTipo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "PanelDeControlPorTipo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Panel de Control"
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.MenuContext.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.txtMinutos, System.ComponentModel.ISupportInitialize).EndInit()
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
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
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
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbEstado As Eniac.Controles.CheckBox
   Friend WithEvents cmbEstadoCalidad As Eniac.Controles.ComboBox
   Friend WithEvents MenuContext As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ListaDeControlPorProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents chbUbicacion As Eniac.Controles.CheckBox
   Friend WithEvents cmbUbicacion As Eniac.Controles.ComboBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents lblLiberados As Eniac.Controles.Label
   Friend WithEvents cmbLiberado As Eniac.Controles.ComboBox
   Friend WithEvents lblEntregados As Eniac.Controles.Label
   Friend WithEvents cmbEntregados As Eniac.Controles.ComboBox
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents chbActualizacionAutomatica As System.Windows.Forms.CheckBox
   Friend WithEvents txtMinutos As System.Windows.Forms.NumericUpDown
   Friend WithEvents lblSegundos As Eniac.Controles.Label
    Friend WithEvents cmbLiberadoPDI As Controles.ComboBox
    Friend WithEvents lblLiberadosPDI As Controles.Label
   Friend WithEvents tsbFInalizarListas As ToolStripButton
   Friend WithEvents tssFinalizarListas As ToolStripSeparator
   Friend WithEvents chbMostrarReparaciones As CheckBox
   Friend WithEvents lblCantidadCochesEnLinea As Label
End Class
