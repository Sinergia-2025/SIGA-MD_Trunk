<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfCtaCteDetalleProximoPago
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
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoImpresora")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente2")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuotaNumero")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasFactura")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasVencido")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCuota")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCuota")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Interes")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdClienteHijo")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoClienteHijo")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreClienteHijo")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfCtaCteDetalleProximoPago))
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
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimirPrediseñado = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbGrupoCategoria = New Eniac.Controles.ComboBox()
      Me.chbGrupoCategoria = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.chbMostrarDetalle = New Eniac.Controles.CheckBox()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.chbMuestraDeudaAnterior = New System.Windows.Forms.CheckBox()
      Me.chbExcluirMinutas = New Eniac.Controles.CheckBox()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.rbtVenActual = New System.Windows.Forms.RadioButton()
      Me.rbtVenMovimiento = New System.Windows.Forms.RadioButton()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.rbtCatActual = New System.Windows.Forms.RadioButton()
      Me.rbtCatMovimiento = New System.Windows.Forms.RadioButton()
      Me.chbProvincia = New Eniac.Controles.CheckBox()
      Me.cmbProvincia = New Eniac.Controles.ComboBox()
      Me.chbExcluirPreComprobantes = New Eniac.Controles.CheckBox()
      Me.chbExcluirAnticipos = New Eniac.Controles.CheckBox()
      Me.chbExcluirSaldosNegativos = New Eniac.Controles.CheckBox()
      Me.cmbGrupos = New Eniac.Controles.ComboBox()
      Me.chbGrupo = New Eniac.Controles.CheckBox()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
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
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.chbAgruparIdClienteCtaCte = New System.Windows.Forms.CheckBox()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
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
      Appearance29.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance29.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance29
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
      Me.ugDetalle.DataMember = Nothing
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
      UltraGridColumn1.Width = 32
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn2.CellAppearance = Appearance3
      UltraGridColumn2.Header.Caption = "Tipo"
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Hidden = True
      UltraGridColumn2.Width = 40
      UltraGridColumn5.Header.Caption = "Vendedor"
      UltraGridColumn5.Header.VisiblePosition = 3
      UltraGridColumn5.Width = 83
      UltraGridColumn22.Header.VisiblePosition = 25
      UltraGridColumn22.Hidden = True
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn23.CellAppearance = Appearance4
      UltraGridColumn23.Header.Caption = "Código"
      UltraGridColumn23.Header.VisiblePosition = 4
      UltraGridColumn23.Width = 58
      UltraGridColumn8.Header.Caption = "Cliente"
      UltraGridColumn8.Header.VisiblePosition = 5
      UltraGridColumn8.Width = 173
      UltraGridColumn28.Header.Caption = "Cliente con Datos"
      UltraGridColumn28.Header.VisiblePosition = 7
      UltraGridColumn28.Hidden = True
      UltraGridColumn28.Width = 300
      UltraGridColumn9.Header.Caption = "Comprobante"
      UltraGridColumn9.Header.VisiblePosition = 9
      UltraGridColumn9.Width = 81
      Appearance5.TextHAlignAsString = "Center"
      UltraGridColumn10.CellAppearance = Appearance5
      UltraGridColumn10.Header.Caption = "Let."
      UltraGridColumn10.Header.VisiblePosition = 10
      UltraGridColumn10.Width = 30
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance6
      UltraGridColumn11.Header.Caption = "Emisor"
      UltraGridColumn11.Header.VisiblePosition = 11
      UltraGridColumn11.Width = 40
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn12.CellAppearance = Appearance7
      UltraGridColumn12.Header.Caption = "Numero"
      UltraGridColumn12.Header.VisiblePosition = 12
      UltraGridColumn12.Width = 60
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance8
      UltraGridColumn6.Header.Caption = "Cta."
      UltraGridColumn6.Header.VisiblePosition = 14
      UltraGridColumn6.Width = 47
      Appearance9.TextHAlignAsString = "Center"
      UltraGridColumn14.CellAppearance = Appearance9
      UltraGridColumn14.Format = "dd/MM/yyyy"
      UltraGridColumn14.Header.Caption = "Emision"
      UltraGridColumn14.Header.VisiblePosition = 15
      UltraGridColumn14.Width = 70
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn13.CellAppearance = Appearance10
      UltraGridColumn13.Header.Caption = "D.F."
      UltraGridColumn13.Header.VisiblePosition = 16
      UltraGridColumn13.Width = 32
      Appearance11.TextHAlignAsString = "Center"
      UltraGridColumn15.CellAppearance = Appearance11
      UltraGridColumn15.Format = "dd/MM/yyyy"
      UltraGridColumn15.Header.Caption = "Vencimiento"
      UltraGridColumn15.Header.VisiblePosition = 17
      UltraGridColumn15.Width = 70
      Appearance12.TextHAlignAsString = "Right"
      UltraGridColumn16.CellAppearance = Appearance12
      UltraGridColumn16.Header.Caption = "D.V."
      UltraGridColumn16.Header.VisiblePosition = 18
      UltraGridColumn16.Width = 33
      UltraGridColumn17.Header.Caption = "Forma de Pago"
      UltraGridColumn17.Header.VisiblePosition = 19
      UltraGridColumn17.Hidden = True
      UltraGridColumn17.Width = 100
      Appearance13.TextHAlignAsString = "Right"
      UltraGridColumn18.CellAppearance = Appearance13
      UltraGridColumn18.Format = "N2"
      UltraGridColumn18.Header.Caption = "Importe"
      UltraGridColumn18.Header.VisiblePosition = 20
      UltraGridColumn18.Width = 80
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn19.CellAppearance = Appearance14
      UltraGridColumn19.Format = "N2"
      UltraGridColumn19.Header.Caption = "Saldo"
      UltraGridColumn19.Header.VisiblePosition = 21
      UltraGridColumn19.Width = 80
      UltraGridColumn20.Header.VisiblePosition = 24
      UltraGridColumn20.Width = 400
      Appearance15.TextHAlignAsString = "Right"
      UltraGridColumn21.CellAppearance = Appearance15
      UltraGridColumn21.Format = "N2"
      UltraGridColumn21.Header.VisiblePosition = 23
      UltraGridColumn21.Width = 80
      UltraGridColumn7.Header.Caption = "Categoria"
      UltraGridColumn7.Header.VisiblePosition = 28
      Appearance16.TextHAlignAsString = "Right"
      UltraGridColumn25.CellAppearance = Appearance16
      UltraGridColumn25.Format = "N2"
      UltraGridColumn25.Header.VisiblePosition = 22
      UltraGridColumn25.Width = 80
      UltraGridColumn24.Header.VisiblePosition = 26
      UltraGridColumn26.Header.Caption = "Cod. Asoc"
      UltraGridColumn26.Header.VisiblePosition = 6
      UltraGridColumn26.Hidden = True
      UltraGridColumn26.Width = 60
      UltraGridColumn27.Header.Caption = "Cliente Asoc"
      UltraGridColumn27.Header.VisiblePosition = 8
      UltraGridColumn27.Hidden = True
      UltraGridColumn27.Width = 130
      Appearance17.TextHAlignAsString = "Right"
      UltraGridColumn29.CellAppearance = Appearance17
      UltraGridColumn29.Header.Caption = "S."
      UltraGridColumn29.Header.VisiblePosition = 1
      UltraGridColumn29.Width = 23
      UltraGridColumn30.Header.Caption = "Detalle"
      UltraGridColumn30.Header.VisiblePosition = 13
      UltraGridColumn30.Hidden = True
      UltraGridColumn30.Width = 280
      UltraGridColumn31.Header.VisiblePosition = 27
      UltraGridColumn31.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn5, UltraGridColumn22, UltraGridColumn23, UltraGridColumn8, UltraGridColumn28, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn6, UltraGridColumn14, UltraGridColumn13, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn7, UltraGridColumn25, UltraGridColumn24, UltraGridColumn26, UltraGridColumn27, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance18.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance18
      Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance20.BackColor2 = System.Drawing.SystemColors.Control
      Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance21.BackColor = System.Drawing.SystemColors.Window
      Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance21
      Appearance22.BackColor = System.Drawing.SystemColors.Highlight
      Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance22
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance23.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance23
      Appearance24.BorderColor = System.Drawing.Color.Silver
      Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance24
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance25.BackColor = System.Drawing.SystemColors.Control
      Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance25.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance25
      Appearance26.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance26
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance27.BackColor = System.Drawing.SystemColors.Window
      Appearance27.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance27
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(7, 218)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(1018, 299)
      Me.ugDetalle.TabIndex = 1
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
      Me.stsStado.Size = New System.Drawing.Size(1037, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(958, 17)
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbImprimirPrediseñado, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1037, 29)
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
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimirPrediseñado
      '
      Me.tsbImprimirPrediseñado.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimirPrediseñado.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimirPrediseñado.Name = "tsbImprimirPrediseñado"
      Me.tsbImprimirPrediseñado.Size = New System.Drawing.Size(125, 26)
      Me.tsbImprimirPrediseñado.Text = "Imp. &Prediseñado"
      Me.tsbImprimirPrediseñado.ToolTipText = "Imprimir Reporte Prediseñado"
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
      Me.tsmiAPDF.Text = "a PDF"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      Me.grbFiltros.Controls.Add(Me.cmbGrupoCategoria)
      Me.grbFiltros.Controls.Add(Me.chbGrupoCategoria)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.chbMostrarDetalle)
      Me.grbFiltros.Controls.Add(Me.cmbSucursal)
      Me.grbFiltros.Controls.Add(Me.lblSucursal)
      Me.grbFiltros.Controls.Add(Me.chbMuestraDeudaAnterior)
      Me.grbFiltros.Controls.Add(Me.chbExcluirMinutas)
      Me.grbFiltros.Controls.Add(Me.GroupBox3)
      Me.grbFiltros.Controls.Add(Me.GroupBox2)
      Me.grbFiltros.Controls.Add(Me.chbProvincia)
      Me.grbFiltros.Controls.Add(Me.cmbProvincia)
      Me.grbFiltros.Controls.Add(Me.chbExcluirPreComprobantes)
      Me.grbFiltros.Controls.Add(Me.chbExcluirAnticipos)
      Me.grbFiltros.Controls.Add(Me.chbExcluirSaldosNegativos)
      Me.grbFiltros.Controls.Add(Me.cmbGrupos)
      Me.grbFiltros.Controls.Add(Me.chbGrupo)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
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
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.chbAgruparIdClienteCtaCte)
      Me.grbFiltros.Location = New System.Drawing.Point(7, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(1018, 174)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'cmbGrupoCategoria
      '
      Me.cmbGrupoCategoria.BindearPropiedadControl = Nothing
      Me.cmbGrupoCategoria.BindearPropiedadEntidad = Nothing
      Me.cmbGrupoCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGrupoCategoria.Enabled = False
      Me.cmbGrupoCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbGrupoCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbGrupoCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbGrupoCategoria.FormattingEnabled = True
      Me.cmbGrupoCategoria.IsPK = False
      Me.cmbGrupoCategoria.IsRequired = False
      Me.cmbGrupoCategoria.Key = Nothing
      Me.cmbGrupoCategoria.LabelAsoc = Nothing
      Me.cmbGrupoCategoria.Location = New System.Drawing.Point(365, 144)
      Me.cmbGrupoCategoria.Name = "cmbGrupoCategoria"
      Me.cmbGrupoCategoria.Size = New System.Drawing.Size(65, 21)
      Me.cmbGrupoCategoria.TabIndex = 52
      '
      'chbGrupoCategoria
      '
      Me.chbGrupoCategoria.AutoSize = True
      Me.chbGrupoCategoria.BindearPropiedadControl = Nothing
      Me.chbGrupoCategoria.BindearPropiedadEntidad = Nothing
      Me.chbGrupoCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbGrupoCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbGrupoCategoria.IsPK = False
      Me.chbGrupoCategoria.IsRequired = False
      Me.chbGrupoCategoria.Key = Nothing
      Me.chbGrupoCategoria.LabelAsoc = Nothing
      Me.chbGrupoCategoria.Location = New System.Drawing.Point(254, 146)
      Me.chbGrupoCategoria.Name = "chbGrupoCategoria"
      Me.chbGrupoCategoria.Size = New System.Drawing.Size(105, 17)
      Me.chbGrupoCategoria.TabIndex = 53
      Me.chbGrupoCategoria.Text = "Grupo Categoría"
      Me.chbGrupoCategoria.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.Checked = False
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(395, 27)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.ShowCheckBox = True
      Me.dtpHasta.Size = New System.Drawing.Size(112, 20)
      Me.dtpHasta.TabIndex = 5
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(362, 31)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(33, 13)
      Me.lblHasta.TabIndex = 4
      Me.lblHasta.Text = "hasta"
      '
      'chbMostrarDetalle
      '
      Me.chbMostrarDetalle.AutoSize = True
      Me.chbMostrarDetalle.BindearPropiedadControl = Nothing
      Me.chbMostrarDetalle.BindearPropiedadEntidad = Nothing
      Me.chbMostrarDetalle.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMostrarDetalle.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMostrarDetalle.IsPK = False
      Me.chbMostrarDetalle.IsRequired = False
      Me.chbMostrarDetalle.Key = Nothing
      Me.chbMostrarDetalle.LabelAsoc = Nothing
      Me.chbMostrarDetalle.Location = New System.Drawing.Point(459, 146)
      Me.chbMostrarDetalle.Name = "chbMostrarDetalle"
      Me.chbMostrarDetalle.Size = New System.Drawing.Size(163, 17)
      Me.chbMostrarDetalle.TabIndex = 32
      Me.chbMostrarDetalle.Text = "Mostrar Detalle de Productos"
      Me.chbMostrarDetalle.UseVisualStyleBackColor = True
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
      Me.cmbSucursal.Location = New System.Drawing.Point(62, 27)
      Me.cmbSucursal.Name = "cmbSucursal"
      Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
      Me.cmbSucursal.TabIndex = 1
      '
      'lblSucursal
      '
      Me.lblSucursal.AutoSize = True
      Me.lblSucursal.LabelAsoc = Nothing
      Me.lblSucursal.Location = New System.Drawing.Point(8, 31)
      Me.lblSucursal.Name = "lblSucursal"
      Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
      Me.lblSucursal.TabIndex = 0
      Me.lblSucursal.Text = "Sucursal"
      '
      'chbMuestraDeudaAnterior
      '
      Me.chbMuestraDeudaAnterior.AutoSize = True
      Me.chbMuestraDeudaAnterior.Checked = True
      Me.chbMuestraDeudaAnterior.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbMuestraDeudaAnterior.Location = New System.Drawing.Point(512, 29)
      Me.chbMuestraDeudaAnterior.Name = "chbMuestraDeudaAnterior"
      Me.chbMuestraDeudaAnterior.Size = New System.Drawing.Size(138, 17)
      Me.chbMuestraDeudaAnterior.TabIndex = 6
      Me.chbMuestraDeudaAnterior.Text = "Muestra Deuda Anterior"
      Me.chbMuestraDeudaAnterior.UseVisualStyleBackColor = True
      '
      'chbExcluirMinutas
      '
      Me.chbExcluirMinutas.AutoSize = True
      Me.chbExcluirMinutas.BindearPropiedadControl = Nothing
      Me.chbExcluirMinutas.BindearPropiedadEntidad = Nothing
      Me.chbExcluirMinutas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExcluirMinutas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExcluirMinutas.IsPK = False
      Me.chbExcluirMinutas.IsRequired = False
      Me.chbExcluirMinutas.Key = Nothing
      Me.chbExcluirMinutas.LabelAsoc = Nothing
      Me.chbExcluirMinutas.Location = New System.Drawing.Point(730, 151)
      Me.chbExcluirMinutas.Name = "chbExcluirMinutas"
      Me.chbExcluirMinutas.Size = New System.Drawing.Size(97, 17)
      Me.chbExcluirMinutas.TabIndex = 33
      Me.chbExcluirMinutas.Text = "Excluir Minutas"
      Me.chbExcluirMinutas.UseVisualStyleBackColor = True
      Me.chbExcluirMinutas.Visible = False
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.rbtVenActual)
      Me.GroupBox3.Controls.Add(Me.rbtVenMovimiento)
      Me.GroupBox3.Location = New System.Drawing.Point(260, 58)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(173, 39)
      Me.GroupBox3.TabIndex = 14
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Vendedor"
      '
      'rbtVenActual
      '
      Me.rbtVenActual.AutoSize = True
      Me.rbtVenActual.Checked = True
      Me.rbtVenActual.Location = New System.Drawing.Point(10, 14)
      Me.rbtVenActual.Name = "rbtVenActual"
      Me.rbtVenActual.Size = New System.Drawing.Size(55, 17)
      Me.rbtVenActual.TabIndex = 0
      Me.rbtVenActual.TabStop = True
      Me.rbtVenActual.Text = "Actual"
      Me.rbtVenActual.UseVisualStyleBackColor = True
      '
      'rbtVenMovimiento
      '
      Me.rbtVenMovimiento.AutoSize = True
      Me.rbtVenMovimiento.Location = New System.Drawing.Point(79, 14)
      Me.rbtVenMovimiento.Name = "rbtVenMovimiento"
      Me.rbtVenMovimiento.Size = New System.Drawing.Size(79, 17)
      Me.rbtVenMovimiento.TabIndex = 1
      Me.rbtVenMovimiento.Text = "Movimiento"
      Me.rbtVenMovimiento.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.rbtCatActual)
      Me.GroupBox2.Controls.Add(Me.rbtCatMovimiento)
      Me.GroupBox2.Location = New System.Drawing.Point(260, 99)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(173, 39)
      Me.GroupBox2.TabIndex = 20
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Categoría"
      '
      'rbtCatActual
      '
      Me.rbtCatActual.AutoSize = True
      Me.rbtCatActual.Checked = True
      Me.rbtCatActual.Location = New System.Drawing.Point(10, 15)
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
      Me.rbtCatMovimiento.Location = New System.Drawing.Point(79, 15)
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
      Me.chbProvincia.Location = New System.Drawing.Point(13, 120)
      Me.chbProvincia.Name = "chbProvincia"
      Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
      Me.chbProvincia.TabIndex = 29
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
      Me.cmbProvincia.Location = New System.Drawing.Point(120, 116)
      Me.cmbProvincia.Name = "cmbProvincia"
      Me.cmbProvincia.Size = New System.Drawing.Size(111, 21)
      Me.cmbProvincia.TabIndex = 30
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
      Me.chbExcluirPreComprobantes.Location = New System.Drawing.Point(730, 105)
      Me.chbExcluirPreComprobantes.Name = "chbExcluirPreComprobantes"
      Me.chbExcluirPreComprobantes.Size = New System.Drawing.Size(147, 17)
      Me.chbExcluirPreComprobantes.TabIndex = 28
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
      Me.chbExcluirAnticipos.Location = New System.Drawing.Point(730, 59)
      Me.chbExcluirAnticipos.Name = "chbExcluirAnticipos"
      Me.chbExcluirAnticipos.Size = New System.Drawing.Size(103, 17)
      Me.chbExcluirAnticipos.TabIndex = 17
      Me.chbExcluirAnticipos.Text = "Excluir Anticipos"
      Me.chbExcluirAnticipos.UseVisualStyleBackColor = True
      '
      'chbExcluirSaldosNegativos
      '
      Me.chbExcluirSaldosNegativos.AutoSize = True
      Me.chbExcluirSaldosNegativos.BindearPropiedadControl = Nothing
      Me.chbExcluirSaldosNegativos.BindearPropiedadEntidad = Nothing
      Me.chbExcluirSaldosNegativos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExcluirSaldosNegativos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExcluirSaldosNegativos.IsPK = False
      Me.chbExcluirSaldosNegativos.IsRequired = False
      Me.chbExcluirSaldosNegativos.Key = Nothing
      Me.chbExcluirSaldosNegativos.LabelAsoc = Nothing
      Me.chbExcluirSaldosNegativos.Location = New System.Drawing.Point(730, 82)
      Me.chbExcluirSaldosNegativos.Name = "chbExcluirSaldosNegativos"
      Me.chbExcluirSaldosNegativos.Size = New System.Drawing.Size(143, 17)
      Me.chbExcluirSaldosNegativos.TabIndex = 23
      Me.chbExcluirSaldosNegativos.Text = "Excluir Saldos Negativos"
      Me.chbExcluirSaldosNegativos.UseVisualStyleBackColor = True
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
      Me.cmbGrupos.Location = New System.Drawing.Point(578, 89)
      Me.cmbGrupos.Name = "cmbGrupos"
      Me.cmbGrupos.Size = New System.Drawing.Size(131, 21)
      Me.cmbGrupos.TabIndex = 22
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
      Me.chbGrupo.Location = New System.Drawing.Point(459, 91)
      Me.chbGrupo.Name = "chbGrupo"
      Me.chbGrupo.Size = New System.Drawing.Size(88, 17)
      Me.chbGrupo.TabIndex = 21
      Me.chbGrupo.Text = "Grupo Comp."
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
      Me.chbCliente.Location = New System.Drawing.Point(653, 29)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 7
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
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(711, 26)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 9
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(708, 10)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 8
      Me.lblCodigoCliente.Text = "Código"
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
      Me.bscCliente.Location = New System.Drawing.Point(803, 26)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(208, 23)
      Me.bscCliente.TabIndex = 11
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(805, 10)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 10
      Me.lblNombre.Text = "Nombre"
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(911, 153)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
      Me.chkExpandAll.TabIndex = 35
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
      Me.cmbGrabanLibro.Location = New System.Drawing.Point(578, 116)
      Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
      Me.cmbGrabanLibro.Size = New System.Drawing.Size(68, 21)
      Me.cmbGrabanLibro.TabIndex = 27
      '
      'lblGrabanLibro
      '
      Me.lblGrabanLibro.AutoSize = True
      Me.lblGrabanLibro.LabelAsoc = Nothing
      Me.lblGrabanLibro.Location = New System.Drawing.Point(460, 120)
      Me.lblGrabanLibro.Name = "lblGrabanLibro"
      Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
      Me.lblGrabanLibro.TabIndex = 26
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
      Me.chbCategoria.Location = New System.Drawing.Point(13, 146)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 18
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
      Me.cmbCategoria.Location = New System.Drawing.Point(120, 144)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(111, 21)
      Me.cmbCategoria.TabIndex = 19
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
      Me.chbZonaGeografica.Location = New System.Drawing.Point(13, 91)
      Me.chbZonaGeografica.Name = "chbZonaGeografica"
      Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
      Me.chbZonaGeografica.TabIndex = 24
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
      Me.cmbZonaGeografica.Location = New System.Drawing.Point(120, 89)
      Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
      Me.cmbZonaGeografica.Size = New System.Drawing.Size(111, 21)
      Me.cmbZonaGeografica.TabIndex = 25
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
      Me.chbVendedor.Location = New System.Drawing.Point(13, 64)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 12
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
      Me.cmbVendedor.Location = New System.Drawing.Point(120, 62)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(111, 21)
      Me.cmbVendedor.TabIndex = 13
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(263, 27)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 3
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(193, 31)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(69, 13)
      Me.lblDesde.TabIndex = 2
      Me.lblDesde.Text = "Fecha desde"
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
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(578, 62)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(131, 21)
      Me.cmbTiposComprobantes.TabIndex = 16
      '
      'btnConsultar
      '
      Me.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(911, 102)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 34
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
      Me.chbTipoComprobante.Location = New System.Drawing.Point(459, 64)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
      Me.chbTipoComprobante.TabIndex = 15
      Me.chbTipoComprobante.Text = "Tipo Comprobante"
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
      '
      'chbAgruparIdClienteCtaCte
      '
      Me.chbAgruparIdClienteCtaCte.AutoSize = True
      Me.chbAgruparIdClienteCtaCte.Location = New System.Drawing.Point(730, 128)
      Me.chbAgruparIdClienteCtaCte.Name = "chbAgruparIdClienteCtaCte"
      Me.chbAgruparIdClienteCtaCte.Size = New System.Drawing.Size(184, 17)
      Me.chbAgruparIdClienteCtaCte.TabIndex = 31
      Me.chbAgruparIdClienteCtaCte.Text = "Agrupado por Cliente de Cta. Cte."
      Me.chbAgruparIdClienteCtaCte.UseVisualStyleBackColor = True
      '
      'InfCtaCteDetalleProximoPago
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1037, 546)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.KeyPreview = True
      Me.Name = "InfCtaCteDetalleProximoPago"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Cta. Cte. Detalle de Clientes - Próximo Pago"
      Me.TopMost = True
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
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
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
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
   Friend WithEvents tsbImprimirPrediseñado As System.Windows.Forms.ToolStripButton
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
   Friend WithEvents chbExcluirSaldosNegativos As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirPreComprobantes As Eniac.Controles.CheckBox
   Friend WithEvents chbProvincia As Eniac.Controles.CheckBox
   Public WithEvents cmbProvincia As Eniac.Controles.ComboBox
   Friend WithEvents chbAgruparIdClienteCtaCte As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtCatActual As System.Windows.Forms.RadioButton
   Friend WithEvents rbtCatMovimiento As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtVenActual As System.Windows.Forms.RadioButton
   Friend WithEvents rbtVenMovimiento As System.Windows.Forms.RadioButton
   Friend WithEvents chbExcluirMinutas As Eniac.Controles.CheckBox
   Friend WithEvents chbMuestraDeudaAnterior As System.Windows.Forms.CheckBox
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents chbMostrarDetalle As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents cmbGrupoCategoria As Eniac.Controles.ComboBox
   Friend WithEvents chbGrupoCategoria As Eniac.Controles.CheckBox
End Class
