<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfComprobantesCtaCteClientesFecha
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
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante2")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra2")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor2")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante2")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver", 0)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfComprobantesCtaCteClientesFecha))
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbFormaDePago = New Eniac.Win.ComboBoxFormaDePago()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtCatActual = New System.Windows.Forms.RadioButton()
        Me.rbtCatMovimiento = New System.Windows.Forms.RadioButton()
        Me.chbProvincia = New Eniac.Controles.CheckBox()
        Me.cmbProvincia = New Eniac.Controles.ComboBox()
        Me.chbExcluirPreComprobantes = New Eniac.Controles.CheckBox()
        Me.chbExcluirAnticipos = New Eniac.Controles.CheckBox()
        Me.cmbGrupos = New Eniac.Controles.ComboBox()
        Me.chbGrupo = New Eniac.Controles.CheckBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.chbCategoria = New Eniac.Controles.CheckBox()
        Me.cmbCategoria = New Eniac.Controles.ComboBox()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
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
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn12.Header.Caption = "Vendedor"
        UltraGridColumn12.Header.VisiblePosition = 1
        UltraGridColumn12.Width = 95
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Código"
        UltraGridColumn1.Header.VisiblePosition = 2
        UltraGridColumn1.Width = 65
        UltraGridColumn2.Header.Caption = "Cliente"
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.Width = 222
        UltraGridColumn3.Header.Caption = "Categoria"
        UltraGridColumn3.Header.VisiblePosition = 5
        UltraGridColumn3.Width = 75
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.Caption = "Comprobante"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 100
        UltraGridColumn6.Header.Caption = "Let."
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridColumn6.Width = 29
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance3
        UltraGridColumn7.Header.Caption = "Emis"
        UltraGridColumn7.Header.VisiblePosition = 9
        UltraGridColumn7.Width = 37
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance4
        UltraGridColumn8.Header.Caption = "Numero"
        UltraGridColumn8.Header.VisiblePosition = 10
        UltraGridColumn8.Width = 71
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn9.CellAppearance = Appearance5
        UltraGridColumn9.Header.Caption = "Emisión"
        UltraGridColumn9.Header.VisiblePosition = 11
        UltraGridColumn9.Width = 85
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance6
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.Caption = "Saldo"
        UltraGridColumn10.Header.VisiblePosition = 12
        UltraGridColumn10.Width = 93
        UltraGridColumn13.Header.Caption = "GB"
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.Width = 42
        UltraGridColumn14.Header.Caption = "F. de Pago"
        UltraGridColumn14.Header.VisiblePosition = 7
        UltraGridColumn14.Width = 65
        UltraGridColumn15.Header.Caption = "Dirección"
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn16.Header.Caption = "Localidad"
        UltraGridColumn16.Header.VisiblePosition = 15
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn11.CellAppearance = Appearance7
        UltraGridColumn11.Header.VisiblePosition = 0
        UltraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn11.Width = 37
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn11})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance8
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance9
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance10.BackColor2 = System.Drawing.SystemColors.Control
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance10
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.Highlight
        Appearance12.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance13
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance14
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance15.BackColor = System.Drawing.SystemColors.Control
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance15
        Appearance16.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance16
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(7, 195)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1037, 322)
        Me.ugDetalle.TabIndex = 2
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 524)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1056, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(977, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.tsbImprimir2, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1056, 29)
        Me.tstBarra.TabIndex = 0
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
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
        Me.ToolStripSeparator4.Visible = False
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
        'tsbImprimir2
        '
        Me.tsbImprimir2.Image = CType(resources.GetObject("tsbImprimir2.Image"), System.Drawing.Image)
        Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir2.Name = "tsbImprimir2"
        Me.tsbImprimir2.Size = New System.Drawing.Size(125, 26)
        Me.tsbImprimir2.Text = "Imp. &Prediseñado"
        Me.tsbImprimir2.ToolTipText = "Imprimir Reporte Prediseñado"
        Me.tsbImprimir2.Visible = False
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbFormaDePago)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.GroupBox1)
        Me.grbFiltros.Controls.Add(Me.chbProvincia)
        Me.grbFiltros.Controls.Add(Me.cmbProvincia)
        Me.grbFiltros.Controls.Add(Me.chbExcluirPreComprobantes)
        Me.grbFiltros.Controls.Add(Me.chbExcluirAnticipos)
        Me.grbFiltros.Controls.Add(Me.cmbGrupos)
        Me.grbFiltros.Controls.Add(Me.chbGrupo)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.chbCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbCategoria)
        Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grbFiltros.Location = New System.Drawing.Point(7, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1037, 151)
        Me.grbFiltros.TabIndex = 1
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'cmbFormaDePago
        '
        Me.cmbFormaDePago.BindearPropiedadControl = Nothing
        Me.cmbFormaDePago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaDePago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaDePago.FormattingEnabled = True
        Me.cmbFormaDePago.IsPK = False
        Me.cmbFormaDePago.IsRequired = False
        Me.cmbFormaDePago.Key = Nothing
        Me.cmbFormaDePago.LabelAsoc = Nothing
        Me.cmbFormaDePago.Location = New System.Drawing.Point(654, 25)
        Me.cmbFormaDePago.Name = "cmbFormaDePago"
        Me.cmbFormaDePago.Size = New System.Drawing.Size(121, 21)
        Me.cmbFormaDePago.TabIndex = 29
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
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(210, 25)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(73, 23)
        Me.bscCodigoCliente.TabIndex = 4
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(207, 12)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 3
        Me.lblCodigoCliente.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(557, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Forma de Pago"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtCatActual)
        Me.GroupBox1.Controls.Add(Me.rbtCatMovimiento)
        Me.GroupBox1.Location = New System.Drawing.Point(596, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(194, 33)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Categoría"
        '
        'rbtCatActual
        '
        Me.rbtCatActual.AutoSize = True
        Me.rbtCatActual.Checked = True
        Me.rbtCatActual.Location = New System.Drawing.Point(10, 12)
        Me.rbtCatActual.Name = "rbtCatActual"
        Me.rbtCatActual.Size = New System.Drawing.Size(55, 17)
        Me.rbtCatActual.TabIndex = 0
        Me.rbtCatActual.TabStop = True
        Me.rbtCatActual.Text = "Actual"
        Me.rbtCatActual.UseVisualStyleBackColor = True
        '
        'rbtCatMovimiento
        '
        Me.rbtCatMovimiento.AutoSize = True
        Me.rbtCatMovimiento.Location = New System.Drawing.Point(110, 12)
        Me.rbtCatMovimiento.Name = "rbtCatMovimiento"
        Me.rbtCatMovimiento.Size = New System.Drawing.Size(79, 17)
        Me.rbtCatMovimiento.TabIndex = 1
        Me.rbtCatMovimiento.Text = "Movimiento"
        Me.rbtCatMovimiento.UseVisualStyleBackColor = True
        '
        'chbProvincia
        '
        Me.chbProvincia.AutoSize = True
        Me.chbProvincia.BindearPropiedadControl = Nothing
        Me.chbProvincia.BindearPropiedadEntidad = Nothing
        Me.chbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProvincia.IsPK = False
        Me.chbProvincia.IsRequired = False
        Me.chbProvincia.Key = Nothing
        Me.chbProvincia.LabelAsoc = Nothing
        Me.chbProvincia.Location = New System.Drawing.Point(319, 126)
        Me.chbProvincia.Name = "chbProvincia"
        Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
        Me.chbProvincia.TabIndex = 23
        Me.chbProvincia.Text = "Provincia"
        Me.chbProvincia.UseVisualStyleBackColor = True
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
        Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Enabled = False
        Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.IsPK = False
        Me.cmbProvincia.IsRequired = True
        Me.cmbProvincia.Key = Nothing
        Me.cmbProvincia.LabelAsoc = Nothing
        Me.cmbProvincia.Location = New System.Drawing.Point(393, 124)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(150, 21)
        Me.cmbProvincia.TabIndex = 24
        '
        'chbExcluirPreComprobantes
        '
        Me.chbExcluirPreComprobantes.AutoSize = True
        Me.chbExcluirPreComprobantes.BindearPropiedadControl = Nothing
        Me.chbExcluirPreComprobantes.BindearPropiedadEntidad = Nothing
        Me.chbExcluirPreComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirPreComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirPreComprobantes.IsPK = False
        Me.chbExcluirPreComprobantes.IsRequired = False
        Me.chbExcluirPreComprobantes.Key = Nothing
        Me.chbExcluirPreComprobantes.LabelAsoc = Nothing
        Me.chbExcluirPreComprobantes.Location = New System.Drawing.Point(598, 127)
        Me.chbExcluirPreComprobantes.Name = "chbExcluirPreComprobantes"
        Me.chbExcluirPreComprobantes.Size = New System.Drawing.Size(147, 17)
        Me.chbExcluirPreComprobantes.TabIndex = 25
        Me.chbExcluirPreComprobantes.Text = "Excluir Pre-Comprobantes"
        Me.chbExcluirPreComprobantes.UseVisualStyleBackColor = True
        '
        'chbExcluirAnticipos
        '
        Me.chbExcluirAnticipos.AutoSize = True
        Me.chbExcluirAnticipos.BindearPropiedadControl = Nothing
        Me.chbExcluirAnticipos.BindearPropiedadEntidad = Nothing
        Me.chbExcluirAnticipos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirAnticipos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirAnticipos.IsPK = False
        Me.chbExcluirAnticipos.IsRequired = False
        Me.chbExcluirAnticipos.Key = Nothing
        Me.chbExcluirAnticipos.LabelAsoc = Nothing
        Me.chbExcluirAnticipos.Location = New System.Drawing.Point(598, 96)
        Me.chbExcluirAnticipos.Name = "chbExcluirAnticipos"
        Me.chbExcluirAnticipos.Size = New System.Drawing.Size(103, 17)
        Me.chbExcluirAnticipos.TabIndex = 20
        Me.chbExcluirAnticipos.Text = "Excluir Anticipos"
        Me.chbExcluirAnticipos.UseVisualStyleBackColor = True
        '
        'cmbGrupos
        '
        Me.cmbGrupos.BindearPropiedadControl = Nothing
        Me.cmbGrupos.BindearPropiedadEntidad = Nothing
        Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupos.Enabled = False
        Me.cmbGrupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupos.FormattingEnabled = True
        Me.cmbGrupos.IsPK = False
        Me.cmbGrupos.IsRequired = False
        Me.cmbGrupos.ItemHeight = 13
        Me.cmbGrupos.Key = Nothing
        Me.cmbGrupos.LabelAsoc = Nothing
        Me.cmbGrupos.Location = New System.Drawing.Point(393, 95)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(150, 21)
        Me.cmbGrupos.TabIndex = 19
        '
        'chbGrupo
        '
        Me.chbGrupo.AutoSize = True
        Me.chbGrupo.BindearPropiedadControl = Nothing
        Me.chbGrupo.BindearPropiedadEntidad = Nothing
        Me.chbGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrupo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrupo.IsPK = False
        Me.chbGrupo.IsRequired = False
        Me.chbGrupo.Key = Nothing
        Me.chbGrupo.LabelAsoc = Nothing
        Me.chbGrupo.Location = New System.Drawing.Point(319, 97)
        Me.chbGrupo.Name = "chbGrupo"
        Me.chbGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chbGrupo.TabIndex = 18
        Me.chbGrupo.Text = "Grupo"
        Me.chbGrupo.UseVisualStyleBackColor = True
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
        Me.chbCliente.Location = New System.Drawing.Point(153, 27)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 2
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
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
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(289, 25)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(261, 23)
        Me.bscCliente.TabIndex = 6
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(286, 12)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(917, 120)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 18)
        Me.chkExpandAll.TabIndex = 27
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'cmbGrabanLibro
        '
        Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
        Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
        Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrabanLibro.FormattingEnabled = True
        Me.cmbGrabanLibro.IsPK = False
        Me.cmbGrabanLibro.IsRequired = False
        Me.cmbGrabanLibro.Key = Nothing
        Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabanLibro
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(867, 25)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
        Me.cmbGrabanLibro.TabIndex = 10
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(799, 28)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 9
        Me.lblGrabanLibro.Text = "Graban Libro"
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
        Me.chbCategoria.Location = New System.Drawing.Point(319, 66)
        Me.chbCategoria.Name = "chbCategoria"
        Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoria.TabIndex = 13
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
        Me.cmbCategoria.Location = New System.Drawing.Point(393, 64)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(150, 21)
        Me.cmbCategoria.TabIndex = 14
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
        Me.chbZonaGeografica.Location = New System.Drawing.Point(13, 124)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
        Me.chbZonaGeografica.TabIndex = 21
        Me.chbZonaGeografica.Text = "Zona Geográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
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
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(128, 122)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(151, 21)
        Me.cmbZonaGeografica.TabIndex = 22
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
        Me.chbVendedor.Location = New System.Drawing.Point(14, 66)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 11
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
        Me.cmbVendedor.Location = New System.Drawing.Point(128, 64)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(153, 21)
        Me.cmbVendedor.TabIndex = 12
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(47, 26)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
        Me.dtpHasta.TabIndex = 1
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(6, 30)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 0
        Me.lblHasta.Text = "Hasta"
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
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(128, 93)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(151, 21)
        Me.cmbTiposComprobantes.TabIndex = 17
        '
        'btnConsultar
        '
        Me.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(917, 69)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 26
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.chbTipoComprobante.Location = New System.Drawing.Point(13, 96)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 16
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'InfComprobantesCtaCteClientesFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 546)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.KeyPreview = True
        Me.Name = "InfComprobantesCtaCteClientesFecha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Comprobantes de Cuenta Corriente de Clientes a Fecha"
        Me.TopMost = True
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents cmbGrupos As Eniac.Controles.ComboBox
   Friend WithEvents chbGrupo As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirAnticipos As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirPreComprobantes As Eniac.Controles.CheckBox
   Friend WithEvents chbProvincia As Eniac.Controles.CheckBox
   Public WithEvents cmbProvincia As Eniac.Controles.ComboBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtCatActual As System.Windows.Forms.RadioButton
   Friend WithEvents rbtCatMovimiento As System.Windows.Forms.RadioButton
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbFormaDePago As Eniac.Win.ComboBoxFormaDePago
End Class
