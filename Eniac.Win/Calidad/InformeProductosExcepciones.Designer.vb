<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InformeProductosExcepciones
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
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Responsable")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdExcepcion")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaControlTipo")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdExcepcionTipo")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaExcepcion")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AccionesCorrectivas")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Item")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario1")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario2")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario3")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaUsuario1")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaUsuario2")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaUsuario3")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dpto")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaControlTipo")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreExcepcionTipo")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeProductosExcepciones))
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.MenuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ListaDeControlPorProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.chbMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.chbDesvio = New Eniac.Controles.CheckBox()
      Me.chbSolicitante = New Eniac.Controles.CheckBox()
      Me.chbDpto = New Eniac.Controles.CheckBox()
      Me.ChbTipo = New Eniac.Controles.CheckBox()
      Me.chbSeccion = New Eniac.Controles.CheckBox()
      Me.cmbSolicitante = New Eniac.Controles.ComboBox()
      Me.cmbDpto = New Eniac.Controles.ComboBox()
      Me.cmbTiposExcepciones = New Eniac.Controles.ComboBox()
      Me.cmbTipoListaControl = New Eniac.Controles.ComboBox()
      Me.bscExcepcion2 = New Eniac.Controles.Buscador2()
      Me.chbExpandAll = New Eniac.Controles.CheckBox()
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
      UltraGridColumn1.Header.VisiblePosition = 5
      UltraGridColumn2.Header.Caption = "Fecha Asignación"
      UltraGridColumn2.Header.VisiblePosition = 3
      UltraGridColumn3.Header.Caption = "Desvío"
      UltraGridColumn3.Header.VisiblePosition = 0
      UltraGridColumn4.Header.Caption = "Sección"
      UltraGridColumn4.Header.VisiblePosition = 8
      UltraGridColumn4.Hidden = True
      UltraGridColumn5.Header.VisiblePosition = 11
      UltraGridColumn6.Header.Caption = "Tipo"
      UltraGridColumn6.Header.VisiblePosition = 9
      UltraGridColumn6.Hidden = True
      UltraGridColumn7.Header.Caption = "Fecha Desvío"
      UltraGridColumn7.Header.VisiblePosition = 13
      UltraGridColumn8.Header.VisiblePosition = 14
      UltraGridColumn9.Header.Caption = "Acciones Correctivas"
      UltraGridColumn9.Header.VisiblePosition = 12
      UltraGridColumn10.Header.VisiblePosition = 6
      UltraGridColumn11.Header.VisiblePosition = 15
      UltraGridColumn12.Header.VisiblePosition = 17
      UltraGridColumn13.Header.VisiblePosition = 19
      UltraGridColumn14.Header.VisiblePosition = 16
      UltraGridColumn15.Header.VisiblePosition = 18
      UltraGridColumn16.Header.VisiblePosition = 20
      UltraGridColumn17.Header.VisiblePosition = 4
      UltraGridColumn18.Header.Caption = "Sección"
      UltraGridColumn18.Header.VisiblePosition = 7
      UltraGridColumn19.Header.Caption = "Tipo"
      UltraGridColumn19.Header.VisiblePosition = 10
      UltraGridColumn20.Header.Caption = "Producto"
      UltraGridColumn20.Header.VisiblePosition = 2
      UltraGridColumn21.Header.Caption = "Código"
      UltraGridColumn21.Header.VisiblePosition = 1
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
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
      Me.ugDetalle.Location = New System.Drawing.Point(11, 166)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(869, 370)
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
      Me.grbFiltros.Controls.Add(Me.chbFecha)
      Me.grbFiltros.Controls.Add(Me.chbMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.bscProducto2)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProducto2)
      Me.grbFiltros.Controls.Add(Me.chbProducto)
      Me.grbFiltros.Controls.Add(Me.chbDesvio)
      Me.grbFiltros.Controls.Add(Me.chbSolicitante)
      Me.grbFiltros.Controls.Add(Me.chbDpto)
      Me.grbFiltros.Controls.Add(Me.ChbTipo)
      Me.grbFiltros.Controls.Add(Me.chbSeccion)
      Me.grbFiltros.Controls.Add(Me.cmbSolicitante)
      Me.grbFiltros.Controls.Add(Me.cmbDpto)
      Me.grbFiltros.Controls.Add(Me.cmbTiposExcepciones)
      Me.grbFiltros.Controls.Add(Me.cmbTipoListaControl)
      Me.grbFiltros.Controls.Add(Me.bscExcepcion2)
      Me.grbFiltros.Controls.Add(Me.chbExpandAll)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Location = New System.Drawing.Point(11, 32)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(869, 128)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
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
      Me.chbFecha.Location = New System.Drawing.Point(17, 19)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(59, 17)
      Me.chbFecha.TabIndex = 71
      Me.chbFecha.Text = "Fecha "
      Me.chbFecha.UseVisualStyleBackColor = True
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
      Me.chbMesCompleto.Location = New System.Drawing.Point(80, 20)
      Me.chbMesCompleto.Name = "chbMesCompleto"
      Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chbMesCompleto.TabIndex = 72
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
      Me.dtpHasta.Location = New System.Drawing.Point(391, 18)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 76
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Enabled = False
      Me.lblHasta.LabelAsoc = Me.chbMesCompleto
      Me.lblHasta.Location = New System.Drawing.Point(352, 22)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 75
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
      Me.dtpDesde.Location = New System.Drawing.Point(223, 18)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 74
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Enabled = False
      Me.lblDesde.LabelAsoc = Me.chbMesCompleto
      Me.lblDesde.Location = New System.Drawing.Point(179, 22)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 73
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
      Me.bscProducto2.Location = New System.Drawing.Point(236, 98)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(267, 20)
      Me.bscProducto2.TabIndex = 70
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
      Me.chbProducto.Location = New System.Drawing.Point(17, 99)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 68
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
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(87, 98)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
      Me.bscCodigoProducto2.TabIndex = 69
      '
      'chbDesvio
      '
      Me.chbDesvio.AutoSize = True
      Me.chbDesvio.BindearPropiedadControl = Nothing
      Me.chbDesvio.BindearPropiedadEntidad = Nothing
      Me.chbDesvio.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDesvio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDesvio.IsPK = False
      Me.chbDesvio.IsRequired = False
      Me.chbDesvio.Key = Nothing
      Me.chbDesvio.LabelAsoc = Nothing
      Me.chbDesvio.Location = New System.Drawing.Point(538, 20)
      Me.chbDesvio.Name = "chbDesvio"
      Me.chbDesvio.Size = New System.Drawing.Size(61, 17)
      Me.chbDesvio.TabIndex = 67
      Me.chbDesvio.Text = "Desvío"
      Me.chbDesvio.UseVisualStyleBackColor = True
      '
      'chbSolicitante
      '
      Me.chbSolicitante.AutoSize = True
      Me.chbSolicitante.BindearPropiedadControl = Nothing
      Me.chbSolicitante.BindearPropiedadEntidad = Nothing
      Me.chbSolicitante.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSolicitante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSolicitante.IsPK = False
      Me.chbSolicitante.IsRequired = False
      Me.chbSolicitante.Key = Nothing
      Me.chbSolicitante.LabelAsoc = Nothing
      Me.chbSolicitante.Location = New System.Drawing.Point(233, 70)
      Me.chbSolicitante.Name = "chbSolicitante"
      Me.chbSolicitante.Size = New System.Drawing.Size(75, 17)
      Me.chbSolicitante.TabIndex = 61
      Me.chbSolicitante.Text = "Solicitante"
      Me.chbSolicitante.UseVisualStyleBackColor = True
      '
      'chbDpto
      '
      Me.chbDpto.AutoSize = True
      Me.chbDpto.BindearPropiedadControl = Nothing
      Me.chbDpto.BindearPropiedadEntidad = Nothing
      Me.chbDpto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDpto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDpto.IsPK = False
      Me.chbDpto.IsRequired = False
      Me.chbDpto.Key = Nothing
      Me.chbDpto.LabelAsoc = Nothing
      Me.chbDpto.Location = New System.Drawing.Point(233, 46)
      Me.chbDpto.Name = "chbDpto"
      Me.chbDpto.Size = New System.Drawing.Size(93, 17)
      Me.chbDpto.TabIndex = 60
      Me.chbDpto.Text = "Departamento"
      Me.chbDpto.UseVisualStyleBackColor = True
      '
      'ChbTipo
      '
      Me.ChbTipo.AutoSize = True
      Me.ChbTipo.BindearPropiedadControl = Nothing
      Me.ChbTipo.BindearPropiedadEntidad = Nothing
      Me.ChbTipo.ForeColorFocus = System.Drawing.Color.Red
      Me.ChbTipo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.ChbTipo.IsPK = False
      Me.ChbTipo.IsRequired = False
      Me.ChbTipo.Key = Nothing
      Me.ChbTipo.LabelAsoc = Nothing
      Me.ChbTipo.Location = New System.Drawing.Point(17, 72)
      Me.ChbTipo.Name = "ChbTipo"
      Me.ChbTipo.Size = New System.Drawing.Size(47, 17)
      Me.ChbTipo.TabIndex = 59
      Me.ChbTipo.Text = "Tipo"
      Me.ChbTipo.UseVisualStyleBackColor = True
      '
      'chbSeccion
      '
      Me.chbSeccion.AutoSize = True
      Me.chbSeccion.BindearPropiedadControl = Nothing
      Me.chbSeccion.BindearPropiedadEntidad = Nothing
      Me.chbSeccion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSeccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSeccion.IsPK = False
      Me.chbSeccion.IsRequired = False
      Me.chbSeccion.Key = Nothing
      Me.chbSeccion.LabelAsoc = Nothing
      Me.chbSeccion.Location = New System.Drawing.Point(17, 47)
      Me.chbSeccion.Name = "chbSeccion"
      Me.chbSeccion.Size = New System.Drawing.Size(65, 17)
      Me.chbSeccion.TabIndex = 58
      Me.chbSeccion.Text = "Sección"
      Me.chbSeccion.UseVisualStyleBackColor = True
      '
      'cmbSolicitante
      '
      Me.cmbSolicitante.BindearPropiedadControl = "SelectedValue"
      Me.cmbSolicitante.BindearPropiedadEntidad = "IdUsuario"
      Me.cmbSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSolicitante.Enabled = False
      Me.cmbSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbSolicitante.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSolicitante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSolicitante.FormattingEnabled = True
      Me.cmbSolicitante.IsPK = False
      Me.cmbSolicitante.IsRequired = True
      Me.cmbSolicitante.Key = Nothing
      Me.cmbSolicitante.LabelAsoc = Nothing
      Me.cmbSolicitante.Location = New System.Drawing.Point(332, 68)
      Me.cmbSolicitante.Name = "cmbSolicitante"
      Me.cmbSolicitante.Size = New System.Drawing.Size(123, 21)
      Me.cmbSolicitante.TabIndex = 54
      '
      'cmbDpto
      '
      Me.cmbDpto.BindearPropiedadControl = "SelectedItem"
      Me.cmbDpto.BindearPropiedadEntidad = "Dpto"
      Me.cmbDpto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDpto.Enabled = False
      Me.cmbDpto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbDpto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbDpto.FormattingEnabled = True
      Me.cmbDpto.IsPK = False
      Me.cmbDpto.IsRequired = True
      Me.cmbDpto.Items.AddRange(New Object() {"COMPRAS y LOGISTICA", "INGENIERIA", "CALIDAD", "PRODUCCION"})
      Me.cmbDpto.Key = Nothing
      Me.cmbDpto.LabelAsoc = Nothing
      Me.cmbDpto.Location = New System.Drawing.Point(332, 43)
      Me.cmbDpto.Name = "cmbDpto"
      Me.cmbDpto.Size = New System.Drawing.Size(123, 21)
      Me.cmbDpto.TabIndex = 52
      '
      'cmbTiposExcepciones
      '
      Me.cmbTiposExcepciones.BindearPropiedadControl = "SelectedValue"
      Me.cmbTiposExcepciones.BindearPropiedadEntidad = "IdExcepcionTipo"
      Me.cmbTiposExcepciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposExcepciones.Enabled = False
      Me.cmbTiposExcepciones.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposExcepciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposExcepciones.FormattingEnabled = True
      Me.cmbTiposExcepciones.IsPK = False
      Me.cmbTiposExcepciones.IsRequired = False
      Me.cmbTiposExcepciones.Key = Nothing
      Me.cmbTiposExcepciones.LabelAsoc = Nothing
      Me.cmbTiposExcepciones.Location = New System.Drawing.Point(87, 70)
      Me.cmbTiposExcepciones.Name = "cmbTiposExcepciones"
      Me.cmbTiposExcepciones.Size = New System.Drawing.Size(123, 21)
      Me.cmbTiposExcepciones.TabIndex = 51
      '
      'cmbTipoListaControl
      '
      Me.cmbTipoListaControl.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoListaControl.BindearPropiedadEntidad = "IdListaControlTipo"
      Me.cmbTipoListaControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoListaControl.Enabled = False
      Me.cmbTipoListaControl.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoListaControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoListaControl.FormattingEnabled = True
      Me.cmbTipoListaControl.IsPK = False
      Me.cmbTipoListaControl.IsRequired = False
      Me.cmbTipoListaControl.Key = Nothing
      Me.cmbTipoListaControl.LabelAsoc = Nothing
      Me.cmbTipoListaControl.Location = New System.Drawing.Point(87, 44)
      Me.cmbTipoListaControl.Name = "cmbTipoListaControl"
      Me.cmbTipoListaControl.Size = New System.Drawing.Size(123, 21)
      Me.cmbTipoListaControl.TabIndex = 49
      '
      'bscExcepcion2
      '
      Me.bscExcepcion2.ActivarFiltroEnGrilla = True
      Me.bscExcepcion2.BindearPropiedadControl = Nothing
      Me.bscExcepcion2.BindearPropiedadEntidad = Nothing
      Me.bscExcepcion2.ConfigBuscador = Nothing
      Me.bscExcepcion2.Datos = Nothing
      Me.bscExcepcion2.Enabled = False
      Me.bscExcepcion2.FilaDevuelta = Nothing
      Me.bscExcepcion2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscExcepcion2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscExcepcion2.IsDecimal = False
      Me.bscExcepcion2.IsNumber = False
      Me.bscExcepcion2.IsPK = False
      Me.bscExcepcion2.IsRequired = False
      Me.bscExcepcion2.Key = ""
      Me.bscExcepcion2.LabelAsoc = Nothing
      Me.bscExcepcion2.Location = New System.Drawing.Point(601, 19)
      Me.bscExcepcion2.MaxLengh = "32767"
      Me.bscExcepcion2.Name = "bscExcepcion2"
      Me.bscExcepcion2.Permitido = True
      Me.bscExcepcion2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscExcepcion2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscExcepcion2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscExcepcion2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscExcepcion2.Selecciono = False
      Me.bscExcepcion2.Size = New System.Drawing.Size(105, 20)
      Me.bscExcepcion2.TabIndex = 46
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
      Me.chbExpandAll.Location = New System.Drawing.Point(679, 101)
      Me.chbExpandAll.Name = "chbExpandAll"
      Me.chbExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chbExpandAll.TabIndex = 45
      Me.chbExpandAll.Text = "Expandir Grupos"
      Me.chbExpandAll.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(679, 50)
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
      Me.stsStado.Size = New System.Drawing.Size(892, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(813, 17)
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
      Me.tstBarra.Size = New System.Drawing.Size(892, 29)
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
      'InformeProductosExcepciones
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(892, 561)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "InformeProductosExcepciones"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Desvíos de Productos"
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
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbExpandAll As Eniac.Controles.CheckBox
   Friend WithEvents cmbTiposExcepciones As Controles.ComboBox
   Friend WithEvents cmbTipoListaControl As Controles.ComboBox
   Friend WithEvents bscExcepcion2 As Controles.Buscador2
   Friend WithEvents cmbDpto As Controles.ComboBox
   Friend WithEvents cmbSolicitante As Controles.ComboBox
   Friend WithEvents chbSolicitante As Controles.CheckBox
   Friend WithEvents chbDpto As Controles.CheckBox
   Friend WithEvents ChbTipo As Controles.CheckBox
   Friend WithEvents chbSeccion As Controles.CheckBox
   Friend WithEvents chbDesvio As Controles.CheckBox
   Friend WithEvents bscProducto2 As Controles.Buscador2
   Friend WithEvents chbProducto As Controles.CheckBox
   Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
   Friend WithEvents chbFecha As Controles.CheckBox
   Friend WithEvents chbMesCompleto As Controles.CheckBox
   Friend WithEvents dtpHasta As Controles.DateTimePicker
   Friend WithEvents lblHasta As Controles.Label
   Friend WithEvents dtpDesde As Controles.DateTimePicker
   Friend WithEvents lblDesde As Controles.Label
End Class
