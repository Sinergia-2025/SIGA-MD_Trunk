<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfRepartosPorModelo
   Inherits Eniac.Win.BaseForm

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
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoComprobante")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocCliente")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocCliente")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoriaFiscal")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaDePago")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
      Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
      Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
      Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
      Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioLista")
      Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
      Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
      Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
      Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
      Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
      Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
      Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
      Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
      Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioEnvase")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePagado")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CopiarValor", 0)
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfRepartosPorModelo))
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.ugConsolidadoPorModelo = New Eniac.Win.UltraGridEditable()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.chbTransportista = New Eniac.Controles.CheckBox()
      Me.bscTransportista = New Eniac.Controles.Buscador()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.chbFormaPago = New Eniac.Controles.CheckBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugConsolidadoPorModelo, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.SuspendLayout()
      '
      'UltraDataSource1
      '
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
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
      Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance1.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance1
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
      'ugConsolidadoPorModelo
      '
      Me.ugConsolidadoPorModelo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance2.BackColor = System.Drawing.SystemColors.Window
      Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugConsolidadoPorModelo.DisplayLayout.Appearance = Appearance2
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance3
      UltraGridColumn4.Header.VisiblePosition = 0
      UltraGridColumn4.Hidden = True
      UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn55.CellAppearance = Appearance4
      UltraGridColumn55.Header.Caption = "Código"
      UltraGridColumn55.Header.VisiblePosition = 2
      UltraGridColumn55.Width = 49
      UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn56.Header.Caption = "Cliente"
      UltraGridColumn56.Header.VisiblePosition = 3
      UltraGridColumn56.Width = 170
      UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn7.Header.Caption = "Dirección"
      UltraGridColumn7.Header.VisiblePosition = 1
      UltraGridColumn7.Width = 170
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance5
      UltraGridColumn8.Format = "N2"
      UltraGridColumn8.Header.Caption = "Envase"
      UltraGridColumn8.Header.VisiblePosition = 5
      UltraGridColumn8.Width = 70
      UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance6
      UltraGridColumn9.Format = "N2"
      UltraGridColumn9.Header.Caption = "A Pagar"
      UltraGridColumn9.Header.VisiblePosition = 6
      UltraGridColumn9.Width = 70
      Appearance7.BackColor = System.Drawing.Color.LightCyan
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn10.CellAppearance = Appearance7
      UltraGridColumn10.Format = "N2"
      UltraGridColumn10.Header.Caption = "Pagado"
      UltraGridColumn10.Header.VisiblePosition = 8
      UltraGridColumn10.Width = 70
      UltraGridColumn11.Header.VisiblePosition = 9
      UltraGridColumn11.Hidden = True
      UltraGridColumn12.Header.VisiblePosition = 10
      UltraGridColumn12.Hidden = True
      UltraGridColumn1.Header.Caption = "Categoria"
      UltraGridColumn1.Header.VisiblePosition = 4
      UltraGridColumn13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
      UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance8.Image = Global.Eniac.Win.My.Resources.Resources.navigate_right
      Appearance8.ImageHAlign = Infragistics.Win.HAlign.Center
      UltraGridColumn13.CellButtonAppearance = Appearance8
      UltraGridColumn13.Header.Caption = ""
      UltraGridColumn13.Header.VisiblePosition = 7
      UltraGridColumn13.MaxWidth = 20
      UltraGridColumn13.MinWidth = 20
      UltraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
      UltraGridColumn13.Width = 20
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn55, UltraGridColumn56, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn1, UltraGridColumn13})
      Me.ugConsolidadoPorModelo.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugConsolidadoPorModelo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugConsolidadoPorModelo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugConsolidadoPorModelo.DisplayLayout.GroupByBox.Appearance = Appearance9
      Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugConsolidadoPorModelo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
      Me.ugConsolidadoPorModelo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance11.BackColor2 = System.Drawing.SystemColors.Control
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugConsolidadoPorModelo.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
      Me.ugConsolidadoPorModelo.DisplayLayout.MaxColScrollRegions = 1
      Me.ugConsolidadoPorModelo.DisplayLayout.MaxRowScrollRegions = 1
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.ActiveCellAppearance = Appearance12
      Appearance13.BackColor = System.Drawing.SystemColors.Highlight
      Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.ActiveRowAppearance = Appearance13
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance14.BackColor = System.Drawing.SystemColors.Window
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.CardAreaAppearance = Appearance14
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.CellAppearance = Appearance15
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.CellPadding = 0
      Appearance16.BackColor = System.Drawing.SystemColors.Control
      Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance16.BorderColor = System.Drawing.SystemColors.Window
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.GroupByRowAppearance = Appearance16
      Appearance17.TextHAlignAsString = "Left"
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.HeaderAppearance = Appearance17
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance18.BackColor = System.Drawing.SystemColors.Window
      Appearance18.BorderColor = System.Drawing.Color.Silver
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.RowAppearance = Appearance18
      Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
      Me.ugConsolidadoPorModelo.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugConsolidadoPorModelo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugConsolidadoPorModelo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugConsolidadoPorModelo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugConsolidadoPorModelo.Location = New System.Drawing.Point(12, 199)
      Me.ugConsolidadoPorModelo.Name = "ugConsolidadoPorModelo"
      Me.ugConsolidadoPorModelo.Size = New System.Drawing.Size(856, 325)
      Me.ugConsolidadoPorModelo.TabIndex = 3
      Me.ugConsolidadoPorModelo.Text = "UltraGrid1"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 540)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(884, 22)
      Me.stsStado.TabIndex = 6
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(805, 17)
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbImprimir, Me.tss2, Me.tsddExportar, Me.tss3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(884, 29)
      Me.tstBarra.TabIndex = 7
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
      'tss1
      '
      Me.tss1.Name = "tss1"
      Me.tss1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'tss2
      '
      Me.tss2.Name = "tss2"
      Me.tss2.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'tss3
      '
      Me.tss3.Name = "tss3"
      Me.tss3.Size = New System.Drawing.Size(6, 29)
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
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.chbCategoria)
      Me.grbFiltros.Controls.Add(Me.cmbCategoria)
      Me.grbFiltros.Controls.Add(Me.chbTransportista)
      Me.grbFiltros.Controls.Add(Me.bscTransportista)
      Me.grbFiltros.Controls.Add(Me.chbNumero)
      Me.grbFiltros.Controls.Add(Me.txtNumero)
      Me.grbFiltros.Controls.Add(Me.chbUsuario)
      Me.grbFiltros.Controls.Add(Me.cmbUsuario)
      Me.grbFiltros.Controls.Add(Me.chbFormaPago)
      Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
      Me.grbFiltros.Controls.Add(Me.chbVendedor)
      Me.grbFiltros.Controls.Add(Me.cmbVendedor)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(856, 155)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'chbCategoria
      '
      Me.chbCategoria.AutoSize = True
      Me.chbCategoria.BindearPropiedadControl = Nothing
      Me.chbCategoria.BindearPropiedadEntidad = Nothing
      Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCategoria.IsPK = False
      Me.chbCategoria.IsRequired = False
      Me.chbCategoria.Key = Nothing
      Me.chbCategoria.LabelAsoc = Nothing
      Me.chbCategoria.Location = New System.Drawing.Point(13, 93)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 10
      Me.chbCategoria.Text = "Categoria"
      Me.chbCategoria.UseVisualStyleBackColor = True
      '
      'cmbCategoria
      '
      Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
      Me.cmbCategoria.BindearPropiedadEntidad = "Categoria.IdCategoria"
      Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoria.Enabled = False
      Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoria.FormattingEnabled = True
      Me.cmbCategoria.IsPK = False
      Me.cmbCategoria.IsRequired = True
      Me.cmbCategoria.Key = Nothing
      Me.cmbCategoria.LabelAsoc = Nothing
      Me.cmbCategoria.Location = New System.Drawing.Point(90, 91)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(150, 21)
      Me.cmbCategoria.TabIndex = 11
      '
      'chbTransportista
      '
      Me.chbTransportista.AutoSize = True
      Me.chbTransportista.BindearPropiedadControl = Nothing
      Me.chbTransportista.BindearPropiedadEntidad = Nothing
      Me.chbTransportista.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTransportista.IsPK = False
      Me.chbTransportista.IsRequired = False
      Me.chbTransportista.Key = Nothing
      Me.chbTransportista.LabelAsoc = Nothing
      Me.chbTransportista.Location = New System.Drawing.Point(490, 23)
      Me.chbTransportista.Name = "chbTransportista"
      Me.chbTransportista.Size = New System.Drawing.Size(87, 17)
      Me.chbTransportista.TabIndex = 15
      Me.chbTransportista.Text = "Transportista"
      Me.chbTransportista.UseVisualStyleBackColor = True
      '
      'bscTransportista
      '
      Me.bscTransportista.AutoSize = True
      Me.bscTransportista.AyudaAncho = 140
      Me.bscTransportista.BindearPropiedadControl = Nothing
      Me.bscTransportista.BindearPropiedadEntidad = Nothing
      Me.bscTransportista.ColumnasAlineacion = Nothing
      Me.bscTransportista.ColumnasAncho = Nothing
      Me.bscTransportista.ColumnasFormato = Nothing
      Me.bscTransportista.ColumnasOcultas = Nothing
      Me.bscTransportista.ColumnasTitulos = Nothing
      Me.bscTransportista.Datos = Nothing
      Me.bscTransportista.Enabled = False
      Me.bscTransportista.FilaDevuelta = Nothing
      Me.bscTransportista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscTransportista.ForeColorFocus = System.Drawing.Color.Red
      Me.bscTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscTransportista.IsDecimal = False
      Me.bscTransportista.IsNumber = False
      Me.bscTransportista.IsPK = False
      Me.bscTransportista.IsRequired = False
      Me.bscTransportista.Key = ""
      Me.bscTransportista.LabelAsoc = Nothing
      Me.bscTransportista.Location = New System.Drawing.Point(608, 21)
      Me.bscTransportista.Margin = New System.Windows.Forms.Padding(4)
      Me.bscTransportista.MaxLengh = "32767"
      Me.bscTransportista.Name = "bscTransportista"
      Me.bscTransportista.Permitido = True
      Me.bscTransportista.Selecciono = False
      Me.bscTransportista.Size = New System.Drawing.Size(182, 23)
      Me.bscTransportista.TabIndex = 16
      Me.bscTransportista.Titulo = Nothing
      '
      'chbNumero
      '
      Me.chbNumero.AutoSize = True
      Me.chbNumero.BindearPropiedadControl = Nothing
      Me.chbNumero.BindearPropiedadEntidad = Nothing
      Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumero.IsPK = False
      Me.chbNumero.IsRequired = False
      Me.chbNumero.Key = Nothing
      Me.chbNumero.LabelAsoc = Nothing
      Me.chbNumero.Location = New System.Drawing.Point(490, 100)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(104, 17)
      Me.chbNumero.TabIndex = 21
      Me.chbNumero.Text = "Numero Reparto"
      Me.chbNumero.UseVisualStyleBackColor = True
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.Enabled = False
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = "##0"
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Nothing
      Me.txtNumero.Location = New System.Drawing.Point(609, 97)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(73, 20)
      Me.txtNumero.TabIndex = 22
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbUsuario
      '
      Me.chbUsuario.AutoSize = True
      Me.chbUsuario.BindearPropiedadControl = Nothing
      Me.chbUsuario.BindearPropiedadEntidad = Nothing
      Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuario.IsPK = False
      Me.chbUsuario.IsRequired = False
      Me.chbUsuario.Key = Nothing
      Me.chbUsuario.LabelAsoc = Nothing
      Me.chbUsuario.Location = New System.Drawing.Point(490, 74)
      Me.chbUsuario.Name = "chbUsuario"
      Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuario.TabIndex = 19
      Me.chbUsuario.Text = "Usuario"
      Me.chbUsuario.UseVisualStyleBackColor = True
      '
      'cmbUsuario
      '
      Me.cmbUsuario.BindearPropiedadControl = Nothing
      Me.cmbUsuario.BindearPropiedadEntidad = Nothing
      Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuario.Enabled = False
      Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuario.FormattingEnabled = True
      Me.cmbUsuario.IsPK = False
      Me.cmbUsuario.IsRequired = False
      Me.cmbUsuario.Key = Nothing
      Me.cmbUsuario.LabelAsoc = Nothing
      Me.cmbUsuario.Location = New System.Drawing.Point(609, 70)
      Me.cmbUsuario.Name = "cmbUsuario"
      Me.cmbUsuario.Size = New System.Drawing.Size(115, 21)
      Me.cmbUsuario.TabIndex = 20
      '
      'chbFormaPago
      '
      Me.chbFormaPago.AutoSize = True
      Me.chbFormaPago.BindearPropiedadControl = Nothing
      Me.chbFormaPago.BindearPropiedadEntidad = Nothing
      Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFormaPago.IsPK = False
      Me.chbFormaPago.IsRequired = False
      Me.chbFormaPago.Key = Nothing
      Me.chbFormaPago.LabelAsoc = Nothing
      Me.chbFormaPago.Location = New System.Drawing.Point(265, 126)
      Me.chbFormaPago.Name = "chbFormaPago"
      Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
      Me.chbFormaPago.TabIndex = 13
      Me.chbFormaPago.Text = "Forma de Pago"
      Me.chbFormaPago.UseVisualStyleBackColor = True
      '
      'cmbFormaPago
      '
      Me.cmbFormaPago.BindearPropiedadControl = Nothing
      Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
      Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormaPago.Enabled = False
      Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormaPago.FormattingEnabled = True
      Me.cmbFormaPago.IsPK = False
      Me.cmbFormaPago.IsRequired = False
      Me.cmbFormaPago.Key = Nothing
      Me.cmbFormaPago.LabelAsoc = Nothing
      Me.cmbFormaPago.Location = New System.Drawing.Point(366, 124)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(149, 21)
      Me.cmbFormaPago.TabIndex = 14
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
      Me.chbVendedor.Location = New System.Drawing.Point(13, 128)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 22
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
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
      Me.cmbVendedor.Location = New System.Drawing.Point(91, 124)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(149, 21)
      Me.cmbVendedor.TabIndex = 12
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
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(75, 60)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 7
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(72, 44)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 6
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAncho = 608
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
      Me.bscCliente.LabelAsoc = Me.lblNombre
      Me.bscCliente.Location = New System.Drawing.Point(172, 60)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(288, 23)
      Me.bscCliente.TabIndex = 9
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(169, 44)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 8
      Me.lblNombre.Text = "Nombre"
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Enabled = False
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.ItemHeight = 13
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Nothing
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(609, 45)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(115, 21)
      Me.cmbTiposComprobantes.TabIndex = 18
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(748, 78)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(102, 45)
      Me.btnConsultar.TabIndex = 23
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.chbCliente.Location = New System.Drawing.Point(13, 60)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 5
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'chbTipoComprobante
      '
      Me.chbTipoComprobante.AutoSize = True
      Me.chbTipoComprobante.BindearPropiedadControl = Nothing
      Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoComprobante.IsPK = False
      Me.chbTipoComprobante.IsRequired = False
      Me.chbTipoComprobante.Key = Nothing
      Me.chbTipoComprobante.LabelAsoc = Nothing
      Me.chbTipoComprobante.Location = New System.Drawing.Point(490, 48)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
      Me.chbTipoComprobante.TabIndex = 17
      Me.chbTipoComprobante.Text = "Tipo Comprobante"
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(13, 23)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 0
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(310, 22)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(273, 25)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(144, 21)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(105, 24)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'InfRepartosPorModelo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(884, 562)
      Me.Controls.Add(Me.ugConsolidadoPorModelo)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "InfRepartosPorModelo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Repartos por Modelo"
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugConsolidadoPorModelo, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Private WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Private WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents chbTransportista As Eniac.Controles.CheckBox
   Friend WithEvents bscTransportista As Eniac.Controles.Buscador
   Friend WithEvents ugConsolidadoPorModelo As Eniac.Win.UltraGridEditable
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
End Class
