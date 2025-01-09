<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarCtaCteDetClientesDH
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
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuotaNumero")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha_Fecha")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha_Hora")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCuota")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCuota")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Debe")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Haber")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Interes")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionDetalle")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante2")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra2")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor2")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante2")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuotaNumero2")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ExisteCtaCte")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmbarcacion")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoEmbaracion")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmbarcacion")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCama", 0)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarCtaCteDetClientesDH))
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
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
        Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
        Me.tss4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.tss5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbAsignarComprobanteAplicado = New System.Windows.Forms.ToolStripButton()
        Me.tss6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.grbEmbarcacionCama = New System.Windows.Forms.Panel()
        Me.chbEmbarcacionCama = New Eniac.Controles.CheckBox()
        Me.bscCodigoEmbarcacionCama = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscNombreEmbarcacion = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbExcluirPreComprobantes = New Eniac.Controles.CheckBox()
        Me.chbMostrarComprobanteAplicado = New Eniac.Controles.CheckBox()
        Me.cmbTipoConversion = New Eniac.Controles.ComboBox()
        Me.lblMoneda = New Eniac.Controles.Label()
        Me.cmbMoneda = New Eniac.Controles.ComboBox()
        Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
        Me.lblCotizacionDolar = New Eniac.Controles.Label()
        Me.chbFechaInteres = New Eniac.Controles.CheckBox()
        Me.dtpFechaInteres = New Eniac.Controles.DateTimePicker()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.chbExcluirMinutas = New Eniac.Controles.CheckBox()
        Me.cmbGrupos = New Eniac.Controles.ComboBox()
        Me.chbGrupo = New Eniac.Controles.CheckBox()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.grbFiltroYOrden = New System.Windows.Forms.GroupBox()
        Me.optFechaVencimiento = New Eniac.Controles.RadioButton()
        Me.optFechaEmision = New Eniac.Controles.RadioButton()
        Me.lblCliente = New Eniac.Controles.Label()
        Me.chbFechas = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tbcDetalle = New System.Windows.Forms.TabControl()
        Me.tbpDetalle = New System.Windows.Forms.TabPage()
        Me.pnlSaldoInicial = New System.Windows.Forms.Panel()
        Me.txtSaldoActual = New Eniac.Controles.TextBox()
        Me.lblSaldoInicial = New Eniac.Controles.Label()
        Me.txtSaldoInicial = New Eniac.Controles.TextBox()
        Me.lblSaldoActual = New Eniac.Controles.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSaldoFinal = New Eniac.Controles.TextBox()
        Me.lblSaldoFinal = New Eniac.Controles.Label()
        Me.tbpKardex = New System.Windows.Forms.TabPage()
        Me.KardexComprobCtaCteClientesUC1 = New Eniac.Win.KardexComprobCtaCteClientesUC()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.grbEmbarcacionCama.SuspendLayout()
        Me.grbFiltroYOrden.SuspendLayout()
        Me.tbcDetalle.SuspendLayout()
        Me.tbpDetalle.SuspendLayout()
        Me.pnlSaldoInicial.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tbpKardex.SuspendLayout()
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
        Appearance34.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance34.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance34
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
        UltraGridColumn1.Header.Caption = "S."
        UltraGridColumn1.Header.VisiblePosition = 5
        UltraGridColumn1.Width = 20
        UltraGridColumn4.Header.Caption = "Nombre Vendedor"
        UltraGridColumn4.Header.VisiblePosition = 0
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 120
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance2
        UltraGridColumn5.Header.VisiblePosition = 1
        UltraGridColumn5.Hidden = True
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance3
        UltraGridColumn6.Header.Caption = "Código"
        UltraGridColumn6.Header.VisiblePosition = 2
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.Caption = "Nombre Cliente"
        UltraGridColumn7.Header.VisiblePosition = 3
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 180
        UltraGridColumn8.Header.Caption = "Comprobante"
        UltraGridColumn8.Header.VisiblePosition = 6
        UltraGridColumn8.Width = 100
        UltraGridColumn9.Header.Caption = "L."
        UltraGridColumn9.Header.VisiblePosition = 7
        UltraGridColumn9.Width = 20
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance4
        UltraGridColumn10.Header.Caption = "Emisor"
        UltraGridColumn10.Header.VisiblePosition = 8
        UltraGridColumn10.Width = 55
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance5
        UltraGridColumn11.Header.Caption = "Número"
        UltraGridColumn11.Header.VisiblePosition = 9
        UltraGridColumn11.Width = 70
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance6
        UltraGridColumn12.Header.Caption = "Cta."
        UltraGridColumn12.Header.VisiblePosition = 10
        UltraGridColumn12.Width = 50
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn13.CellAppearance = Appearance7
        UltraGridColumn13.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn13.Header.Caption = "Emisión Detalle"
        UltraGridColumn13.Header.VisiblePosition = 11
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 139
        UltraGridColumn3.Header.Caption = "Emisión"
        UltraGridColumn3.Header.VisiblePosition = 12
        UltraGridColumn3.Width = 88
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance8
        UltraGridColumn2.Header.Caption = "Hora de Emisión"
        UltraGridColumn2.Header.VisiblePosition = 13
        UltraGridColumn2.Width = 60
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn14.CellAppearance = Appearance9
        UltraGridColumn14.Header.Caption = "Vencimiento"
        UltraGridColumn14.Header.VisiblePosition = 14
        UltraGridColumn14.Width = 75
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance10
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.Caption = "Importe Cuota"
        UltraGridColumn15.Header.VisiblePosition = 15
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 75
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance11
        UltraGridColumn16.Format = "N2"
        UltraGridColumn16.Header.Caption = "Saldo Cuota"
        UltraGridColumn16.Header.VisiblePosition = 16
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 75
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance12
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.VisiblePosition = 17
        UltraGridColumn19.Width = 75
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance13
        UltraGridColumn20.Format = "N2"
        UltraGridColumn20.Header.VisiblePosition = 19
        UltraGridColumn20.Width = 75
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance14
        UltraGridColumn23.Format = "N2"
        UltraGridColumn23.Header.VisiblePosition = 20
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance15
        UltraGridColumn21.Format = "N2"
        UltraGridColumn21.Header.VisiblePosition = 21
        UltraGridColumn21.Width = 75
        UltraGridColumn17.Header.VisiblePosition = 18
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.Header.Caption = "Observación"
        UltraGridColumn18.Header.VisiblePosition = 22
        UltraGridColumn18.Width = 217
        UltraGridColumn22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance16.TextHAlignAsString = "Center"
        UltraGridColumn22.CellAppearance = Appearance16
        UltraGridColumn22.Header.VisiblePosition = 4
        UltraGridColumn22.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn22.Width = 30
        Appearance17.TextHAlignAsString = "Center"
        UltraGridColumn24.Header.Appearance = Appearance17
        UltraGridColumn24.Header.Caption = "Comprobante Aplicado"
        UltraGridColumn24.Header.VisiblePosition = 23
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 100
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn25.Header.Appearance = Appearance18
        UltraGridColumn25.Header.Caption = "L Apl."
        UltraGridColumn25.Header.VisiblePosition = 24
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 30
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance19
        UltraGridColumn26.Header.Caption = "Emisor Aplicado"
        UltraGridColumn26.Header.VisiblePosition = 25
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 55
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance20
        UltraGridColumn27.Header.Caption = "Numero Aplicado"
        UltraGridColumn27.Header.VisiblePosition = 26
        UltraGridColumn27.Hidden = True
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance21
        UltraGridColumn28.Header.Caption = "Cta Aplicada"
        UltraGridColumn28.Header.VisiblePosition = 27
        UltraGridColumn28.Hidden = True
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn29.Header.Appearance = Appearance22
        UltraGridColumn29.Header.Caption = "Existe CtaCte"
        UltraGridColumn29.Header.VisiblePosition = 29
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn29.Width = 50
        UltraGridColumn30.Header.VisiblePosition = 28
        UltraGridColumn30.Hidden = True
        UltraGridColumn35.Header.VisiblePosition = 30
        UltraGridColumn35.Hidden = True
        UltraGridColumn36.Header.VisiblePosition = 31
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 148
        UltraGridColumn37.Header.VisiblePosition = 32
        UltraGridColumn37.Hidden = True
        UltraGridColumn37.Width = 180
        UltraGridColumn31.Header.Caption = "Cama"
        UltraGridColumn31.Header.VisiblePosition = 33
        UltraGridColumn31.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn3, UltraGridColumn2, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn19, UltraGridColumn20, UltraGridColumn23, UltraGridColumn21, UltraGridColumn17, UltraGridColumn18, UltraGridColumn22, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn31})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance23
        Appearance24.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance24
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance25.BackColor2 = System.Drawing.SystemColors.Control
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance26
        Appearance27.BackColor = System.Drawing.SystemColors.Highlight
        Appearance27.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance28
        Appearance29.BorderColor = System.Drawing.Color.Silver
        Appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance30.BackColor = System.Drawing.SystemColors.Control
        Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance30.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance30
        Appearance31.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance31
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance33.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Location = New System.Drawing.Point(3, 27)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(918, 274)
        Me.ugDetalle.TabIndex = 4
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 524)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(934, 22)
        Me.stsStado.TabIndex = 9
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(855, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbImprimir, Me.tss2, Me.tsddExportar, Me.tss3, Me.tsbImprimir2, Me.tss4, Me.tsbPreferencias, Me.tss5, Me.tsbAsignarComprobanteAplicado, Me.tss6, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(934, 29)
        Me.tstBarra.TabIndex = 8
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
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
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
        'tss3
        '
        Me.tss3.Name = "tss3"
        Me.tss3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir2
        '
        Me.tsbImprimir2.Image = CType(resources.GetObject("tsbImprimir2.Image"), System.Drawing.Image)
        Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir2.Name = "tsbImprimir2"
        Me.tsbImprimir2.Size = New System.Drawing.Size(125, 26)
        Me.tsbImprimir2.Text = "Imp. &Prediseñado"
        Me.tsbImprimir2.ToolTipText = "Imprimir Reporte Prediseñado"
        '
        'tss4
        '
        Me.tss4.Name = "tss4"
        Me.tss4.Size = New System.Drawing.Size(6, 29)
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
        'tss5
        '
        Me.tss5.Name = "tss5"
        Me.tss5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbAsignarComprobanteAplicado
        '
        Me.tsbAsignarComprobanteAplicado.Image = Global.Eniac.Win.My.Resources.Resources.column_add
        Me.tsbAsignarComprobanteAplicado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAsignarComprobanteAplicado.Name = "tsbAsignarComprobanteAplicado"
        Me.tsbAsignarComprobanteAplicado.Size = New System.Drawing.Size(211, 26)
        Me.tsbAsignarComprobanteAplicado.Text = "&Modificar Comprobante Aplicado"
        Me.tsbAsignarComprobanteAplicado.ToolTipText = "Selector de Columnas"
        Me.tsbAsignarComprobanteAplicado.Visible = False
        '
        'tss6
        '
        Me.tss6.Name = "tss6"
        Me.tss6.Size = New System.Drawing.Size(6, 29)
        Me.tss6.Visible = False
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
        Me.grbFiltros.Controls.Add(Me.grbEmbarcacionCama)
        Me.grbFiltros.Controls.Add(Me.chbExcluirPreComprobantes)
        Me.grbFiltros.Controls.Add(Me.chbMostrarComprobanteAplicado)
        Me.grbFiltros.Controls.Add(Me.cmbTipoConversion)
        Me.grbFiltros.Controls.Add(Me.cmbMoneda)
        Me.grbFiltros.Controls.Add(Me.lblMoneda)
        Me.grbFiltros.Controls.Add(Me.txtCotizacionDolar)
        Me.grbFiltros.Controls.Add(Me.lblCotizacionDolar)
        Me.grbFiltros.Controls.Add(Me.chbFechaInteres)
        Me.grbFiltros.Controls.Add(Me.dtpFechaInteres)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.chbExcluirMinutas)
        Me.grbFiltros.Controls.Add(Me.cmbGrupos)
        Me.grbFiltros.Controls.Add(Me.chbGrupo)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.grbFiltroYOrden)
        Me.grbFiltros.Controls.Add(Me.lblCliente)
        Me.grbFiltros.Controls.Add(Me.chbFechas)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 35)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(928, 131)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'grbEmbarcacionCama
        '
        Me.grbEmbarcacionCama.Controls.Add(Me.chbEmbarcacionCama)
        Me.grbEmbarcacionCama.Controls.Add(Me.bscCodigoEmbarcacionCama)
        Me.grbEmbarcacionCama.Controls.Add(Me.bscNombreEmbarcacion)
        Me.grbEmbarcacionCama.Location = New System.Drawing.Point(519, 73)
        Me.grbEmbarcacionCama.Name = "grbEmbarcacionCama"
        Me.grbEmbarcacionCama.Size = New System.Drawing.Size(400, 28)
        Me.grbEmbarcacionCama.TabIndex = 64
        Me.grbEmbarcacionCama.Visible = False
        '
        'chbEmbarcacionCama
        '
        Me.chbEmbarcacionCama.AutoSize = True
        Me.chbEmbarcacionCama.BindearPropiedadControl = Nothing
        Me.chbEmbarcacionCama.BindearPropiedadEntidad = Nothing
        Me.chbEmbarcacionCama.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmbarcacionCama.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmbarcacionCama.IsPK = False
        Me.chbEmbarcacionCama.IsRequired = False
        Me.chbEmbarcacionCama.Key = Nothing
        Me.chbEmbarcacionCama.LabelAsoc = Nothing
        Me.chbEmbarcacionCama.Location = New System.Drawing.Point(7, 6)
        Me.chbEmbarcacionCama.Name = "chbEmbarcacionCama"
        Me.chbEmbarcacionCama.Size = New System.Drawing.Size(32, 17)
        Me.chbEmbarcacionCama.TabIndex = 60
        Me.chbEmbarcacionCama.Text = "--"
        Me.chbEmbarcacionCama.UseVisualStyleBackColor = True
        '
        'bscCodigoEmbarcacionCama
        '
        Me.bscCodigoEmbarcacionCama.ActivarFiltroEnGrilla = True
        Me.bscCodigoEmbarcacionCama.BindearPropiedadControl = Nothing
        Me.bscCodigoEmbarcacionCama.BindearPropiedadEntidad = Nothing
        Me.bscCodigoEmbarcacionCama.ConfigBuscador = Nothing
        Me.bscCodigoEmbarcacionCama.Datos = Nothing
        Me.bscCodigoEmbarcacionCama.Enabled = False
        Me.bscCodigoEmbarcacionCama.FilaDevuelta = Nothing
        Me.bscCodigoEmbarcacionCama.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoEmbarcacionCama.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoEmbarcacionCama.IsDecimal = False
        Me.bscCodigoEmbarcacionCama.IsNumber = True
        Me.bscCodigoEmbarcacionCama.IsPK = False
        Me.bscCodigoEmbarcacionCama.IsRequired = False
        Me.bscCodigoEmbarcacionCama.Key = ""
        Me.bscCodigoEmbarcacionCama.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoEmbarcacionCama.Location = New System.Drawing.Point(98, 5)
        Me.bscCodigoEmbarcacionCama.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bscCodigoEmbarcacionCama.MaxLengh = "32767"
        Me.bscCodigoEmbarcacionCama.Name = "bscCodigoEmbarcacionCama"
        Me.bscCodigoEmbarcacionCama.Permitido = True
        Me.bscCodigoEmbarcacionCama.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoEmbarcacionCama.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoEmbarcacionCama.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoEmbarcacionCama.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoEmbarcacionCama.Selecciono = False
        Me.bscCodigoEmbarcacionCama.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoEmbarcacionCama.TabIndex = 61
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(232, 9)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 3
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscNombreEmbarcacion
        '
        Me.bscNombreEmbarcacion.ActivarFiltroEnGrilla = True
        Me.bscNombreEmbarcacion.AutoSize = True
        Me.bscNombreEmbarcacion.BindearPropiedadControl = Nothing
        Me.bscNombreEmbarcacion.BindearPropiedadEntidad = Nothing
        Me.bscNombreEmbarcacion.ConfigBuscador = Nothing
        Me.bscNombreEmbarcacion.Datos = Nothing
        Me.bscNombreEmbarcacion.Enabled = False
        Me.bscNombreEmbarcacion.FilaDevuelta = Nothing
        Me.bscNombreEmbarcacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreEmbarcacion.IsDecimal = False
        Me.bscNombreEmbarcacion.IsNumber = False
        Me.bscNombreEmbarcacion.IsPK = False
        Me.bscNombreEmbarcacion.IsRequired = False
        Me.bscNombreEmbarcacion.Key = ""
        Me.bscNombreEmbarcacion.LabelAsoc = Me.lblNombre
        Me.bscNombreEmbarcacion.Location = New System.Drawing.Point(191, 5)
        Me.bscNombreEmbarcacion.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreEmbarcacion.MaxLengh = "32767"
        Me.bscNombreEmbarcacion.Name = "bscNombreEmbarcacion"
        Me.bscNombreEmbarcacion.Permitido = True
        Me.bscNombreEmbarcacion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreEmbarcacion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreEmbarcacion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreEmbarcacion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreEmbarcacion.Selecciono = False
        Me.bscNombreEmbarcacion.Size = New System.Drawing.Size(203, 23)
        Me.bscNombreEmbarcacion.TabIndex = 62
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(326, 9)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
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
        Me.chbExcluirPreComprobantes.Location = New System.Drawing.Point(303, 108)
        Me.chbExcluirPreComprobantes.Name = "chbExcluirPreComprobantes"
        Me.chbExcluirPreComprobantes.Size = New System.Drawing.Size(147, 17)
        Me.chbExcluirPreComprobantes.TabIndex = 51
        Me.chbExcluirPreComprobantes.Text = "Excluir Pre-Comprobantes"
        Me.chbExcluirPreComprobantes.UseVisualStyleBackColor = True
        '
        'chbMostrarComprobanteAplicado
        '
        Me.chbMostrarComprobanteAplicado.AutoSize = True
        Me.chbMostrarComprobanteAplicado.BindearPropiedadControl = Nothing
        Me.chbMostrarComprobanteAplicado.BindearPropiedadEntidad = Nothing
        Me.chbMostrarComprobanteAplicado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMostrarComprobanteAplicado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMostrarComprobanteAplicado.IsPK = False
        Me.chbMostrarComprobanteAplicado.IsRequired = False
        Me.chbMostrarComprobanteAplicado.Key = Nothing
        Me.chbMostrarComprobanteAplicado.LabelAsoc = Nothing
        Me.chbMostrarComprobanteAplicado.Location = New System.Drawing.Point(751, 106)
        Me.chbMostrarComprobanteAplicado.Name = "chbMostrarComprobanteAplicado"
        Me.chbMostrarComprobanteAplicado.Size = New System.Drawing.Size(171, 17)
        Me.chbMostrarComprobanteAplicado.TabIndex = 50
        Me.chbMostrarComprobanteAplicado.Text = "Mostrar Comprobante Aplicado"
        Me.chbMostrarComprobanteAplicado.UseVisualStyleBackColor = True
        '
        'cmbTipoConversion
        '
        Me.cmbTipoConversion.BindearPropiedadControl = Nothing
        Me.cmbTipoConversion.BindearPropiedadEntidad = Nothing
        Me.cmbTipoConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoConversion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoConversion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoConversion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoConversion.FormattingEnabled = True
        Me.cmbTipoConversion.IsPK = False
        Me.cmbTipoConversion.IsRequired = False
        Me.cmbTipoConversion.Key = Nothing
        Me.cmbTipoConversion.LabelAsoc = Me.lblMoneda
        Me.cmbTipoConversion.Location = New System.Drawing.Point(555, 105)
        Me.cmbTipoConversion.Name = "cmbTipoConversion"
        Me.cmbTipoConversion.Size = New System.Drawing.Size(103, 21)
        Me.cmbTipoConversion.TabIndex = 47
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.LabelAsoc = Nothing
        Me.lblMoneda.Location = New System.Drawing.Point(456, 109)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblMoneda.TabIndex = 45
        Me.lblMoneda.Text = "Moneda"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BindearPropiedadControl = Nothing
        Me.cmbMoneda.BindearPropiedadEntidad = Nothing
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.IsPK = False
        Me.cmbMoneda.IsRequired = False
        Me.cmbMoneda.Items.AddRange(New Object() {"del producto"})
        Me.cmbMoneda.Key = Nothing
        Me.cmbMoneda.LabelAsoc = Me.lblMoneda
        Me.cmbMoneda.Location = New System.Drawing.Point(500, 105)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(54, 21)
        Me.cmbMoneda.TabIndex = 46
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
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(692, 104)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(43, 20)
        Me.txtCotizacionDolar.TabIndex = 49
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCotizacionDolar.Visible = False
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(664, 104)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(33, 18)
        Me.lblCotizacionDolar.TabIndex = 48
        Me.lblCotizacionDolar.Text = "Cotiz."
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCotizacionDolar.Visible = False
        '
        'chbFechaInteres
        '
        Me.chbFechaInteres.AutoSize = True
        Me.chbFechaInteres.BindearPropiedadControl = Nothing
        Me.chbFechaInteres.BindearPropiedadEntidad = Nothing
        Me.chbFechaInteres.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaInteres.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaInteres.IsPK = False
        Me.chbFechaInteres.IsRequired = False
        Me.chbFechaInteres.Key = Nothing
        Me.chbFechaInteres.LabelAsoc = Nothing
        Me.chbFechaInteres.Location = New System.Drawing.Point(500, 52)
        Me.chbFechaInteres.Name = "chbFechaInteres"
        Me.chbFechaInteres.Size = New System.Drawing.Size(91, 17)
        Me.chbFechaInteres.TabIndex = 14
        Me.chbFechaInteres.Text = "Fecha Interes"
        Me.chbFechaInteres.UseVisualStyleBackColor = True
        '
        'dtpFechaInteres
        '
        Me.dtpFechaInteres.BindearPropiedadControl = Nothing
        Me.dtpFechaInteres.BindearPropiedadEntidad = Nothing
        Me.dtpFechaInteres.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaInteres.Enabled = False
        Me.dtpFechaInteres.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaInteres.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInteres.IsPK = False
        Me.dtpFechaInteres.IsRequired = False
        Me.dtpFechaInteres.Key = ""
        Me.dtpFechaInteres.LabelAsoc = Nothing
        Me.dtpFechaInteres.Location = New System.Drawing.Point(591, 50)
        Me.dtpFechaInteres.Name = "dtpFechaInteres"
        Me.dtpFechaInteres.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaInteres.TabIndex = 15
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
        Me.cmbSucursal.Location = New System.Drawing.Point(66, 23)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(119, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(14, 26)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'chbExcluirMinutas
        '
        Me.chbExcluirMinutas.AutoSize = True
        Me.chbExcluirMinutas.BindearPropiedadControl = Nothing
        Me.chbExcluirMinutas.BindearPropiedadEntidad = Nothing
        Me.chbExcluirMinutas.Checked = True
        Me.chbExcluirMinutas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbExcluirMinutas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirMinutas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirMinutas.IsPK = False
        Me.chbExcluirMinutas.IsRequired = False
        Me.chbExcluirMinutas.Key = Nothing
        Me.chbExcluirMinutas.LabelAsoc = Nothing
        Me.chbExcluirMinutas.Location = New System.Drawing.Point(200, 108)
        Me.chbExcluirMinutas.Name = "chbExcluirMinutas"
        Me.chbExcluirMinutas.Size = New System.Drawing.Size(97, 17)
        Me.chbExcluirMinutas.TabIndex = 18
        Me.chbExcluirMinutas.Text = "Excluir Minutas"
        Me.chbExcluirMinutas.UseVisualStyleBackColor = True
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
        Me.cmbGrupos.Location = New System.Drawing.Point(367, 79)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(134, 21)
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
        Me.chbGrupo.Location = New System.Drawing.Point(303, 81)
        Me.chbGrupo.Name = "chbGrupo"
        Me.chbGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chbGrupo.TabIndex = 17
        Me.chbGrupo.Text = "Grupo"
        Me.chbGrupo.UseVisualStyleBackColor = True
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
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(409, 49)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
        Me.cmbGrabanLibro.TabIndex = 13
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(341, 55)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 12
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'grbFiltroYOrden
        '
        Me.grbFiltroYOrden.Controls.Add(Me.optFechaVencimiento)
        Me.grbFiltroYOrden.Controls.Add(Me.optFechaEmision)
        Me.grbFiltroYOrden.Location = New System.Drawing.Point(17, 87)
        Me.grbFiltroYOrden.Name = "grbFiltroYOrden"
        Me.grbFiltroYOrden.Size = New System.Drawing.Size(177, 41)
        Me.grbFiltroYOrden.TabIndex = 16
        Me.grbFiltroYOrden.TabStop = False
        Me.grbFiltroYOrden.Text = "Filtro y Orden"
        '
        'optFechaVencimiento
        '
        Me.optFechaVencimiento.AutoSize = True
        Me.optFechaVencimiento.BindearPropiedadControl = Nothing
        Me.optFechaVencimiento.BindearPropiedadEntidad = Nothing
        Me.optFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.optFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optFechaVencimiento.IsPK = False
        Me.optFechaVencimiento.IsRequired = False
        Me.optFechaVencimiento.Key = Nothing
        Me.optFechaVencimiento.LabelAsoc = Nothing
        Me.optFechaVencimiento.Location = New System.Drawing.Point(85, 18)
        Me.optFechaVencimiento.Name = "optFechaVencimiento"
        Me.optFechaVencimiento.Size = New System.Drawing.Size(83, 17)
        Me.optFechaVencimiento.TabIndex = 1
        Me.optFechaVencimiento.Text = "Vencimiento"
        Me.optFechaVencimiento.UseVisualStyleBackColor = True
        '
        'optFechaEmision
        '
        Me.optFechaEmision.AutoSize = True
        Me.optFechaEmision.BindearPropiedadControl = Nothing
        Me.optFechaEmision.BindearPropiedadEntidad = Nothing
        Me.optFechaEmision.Checked = True
        Me.optFechaEmision.ForeColorFocus = System.Drawing.Color.Red
        Me.optFechaEmision.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optFechaEmision.IsPK = False
        Me.optFechaEmision.IsRequired = False
        Me.optFechaEmision.Key = Nothing
        Me.optFechaEmision.LabelAsoc = Nothing
        Me.optFechaEmision.Location = New System.Drawing.Point(17, 18)
        Me.optFechaEmision.Name = "optFechaEmision"
        Me.optFechaEmision.Size = New System.Drawing.Size(61, 17)
        Me.optFechaEmision.TabIndex = 0
        Me.optFechaEmision.TabStop = True
        Me.optFechaEmision.Text = "Emisión"
        Me.optFechaEmision.UseVisualStyleBackColor = True
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Location = New System.Drawing.Point(191, 26)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 2
        Me.lblCliente.Text = "Cliente"
        '
        'chbFechas
        '
        Me.chbFechas.AutoSize = True
        Me.chbFechas.BindearPropiedadControl = Nothing
        Me.chbFechas.BindearPropiedadEntidad = Nothing
        Me.chbFechas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechas.IsPK = False
        Me.chbFechas.IsRequired = False
        Me.chbFechas.Key = Nothing
        Me.chbFechas.LabelAsoc = Nothing
        Me.chbFechas.Location = New System.Drawing.Point(17, 53)
        Me.chbFechas.Name = "chbFechas"
        Me.chbFechas.Size = New System.Drawing.Size(56, 17)
        Me.chbFechas.TabIndex = 7
        Me.chbFechas.Text = "Fecha"
        Me.chbFechas.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(244, 51)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(89, 20)
        Me.dtpHasta.TabIndex = 11
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(206, 55)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 10
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
        Me.dtpDesde.Location = New System.Drawing.Point(114, 51)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(89, 20)
        Me.dtpDesde.TabIndex = 9
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(76, 55)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 8
        Me.lblDesde.Text = "Desde"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = True
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(231, 23)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 4
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
        Me.bscCliente.Datos = Nothing
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
        Me.bscCliente.Location = New System.Drawing.Point(328, 23)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(265, 23)
        Me.bscCliente.TabIndex = 6
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(819, 19)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 20
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle.Controls.Add(Me.tbpDetalle)
        Me.tbcDetalle.Controls.Add(Me.tbpKardex)
        Me.tbcDetalle.Location = New System.Drawing.Point(2, 168)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(932, 355)
        Me.tbcDetalle.TabIndex = 10
        '
        'tbpDetalle
        '
        Me.tbpDetalle.Controls.Add(Me.ugDetalle)
        Me.tbpDetalle.Controls.Add(Me.pnlSaldoInicial)
        Me.tbpDetalle.Controls.Add(Me.Panel2)
        Me.tbpDetalle.Location = New System.Drawing.Point(4, 22)
        Me.tbpDetalle.Name = "tbpDetalle"
        Me.tbpDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDetalle.Size = New System.Drawing.Size(924, 329)
        Me.tbpDetalle.TabIndex = 0
        Me.tbpDetalle.Text = "Detalle"
        Me.tbpDetalle.UseVisualStyleBackColor = True
        '
        'pnlSaldoInicial
        '
        Me.pnlSaldoInicial.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSaldoInicial.Controls.Add(Me.txtSaldoActual)
        Me.pnlSaldoInicial.Controls.Add(Me.lblSaldoInicial)
        Me.pnlSaldoInicial.Controls.Add(Me.txtSaldoInicial)
        Me.pnlSaldoInicial.Controls.Add(Me.lblSaldoActual)
        Me.pnlSaldoInicial.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSaldoInicial.Location = New System.Drawing.Point(3, 3)
        Me.pnlSaldoInicial.Name = "pnlSaldoInicial"
        Me.pnlSaldoInicial.Size = New System.Drawing.Size(918, 24)
        Me.pnlSaldoInicial.TabIndex = 2
        Me.pnlSaldoInicial.Visible = False
        '
        'txtSaldoActual
        '
        Me.txtSaldoActual.BindearPropiedadControl = Nothing
        Me.txtSaldoActual.BindearPropiedadEntidad = Nothing
        Me.txtSaldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoActual.ForeColor = System.Drawing.Color.Red
        Me.txtSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoActual.Formato = ""
        Me.txtSaldoActual.IsDecimal = False
        Me.txtSaldoActual.IsNumber = False
        Me.txtSaldoActual.IsPK = False
        Me.txtSaldoActual.IsRequired = False
        Me.txtSaldoActual.Key = ""
        Me.txtSaldoActual.LabelAsoc = Nothing
        Me.txtSaldoActual.Location = New System.Drawing.Point(273, 2)
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.ReadOnly = True
        Me.txtSaldoActual.Size = New System.Drawing.Size(80, 20)
        Me.txtSaldoActual.TabIndex = 3
        Me.txtSaldoActual.Text = "0.00"
        Me.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoActual.Visible = False
        '
        'lblSaldoInicial
        '
        Me.lblSaldoInicial.AutoSize = True
        Me.lblSaldoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoInicial.LabelAsoc = Nothing
        Me.lblSaldoInicial.Location = New System.Drawing.Point(520, 5)
        Me.lblSaldoInicial.Name = "lblSaldoInicial"
        Me.lblSaldoInicial.Size = New System.Drawing.Size(67, 13)
        Me.lblSaldoInicial.TabIndex = 4
        Me.lblSaldoInicial.Text = "Saldo Inicial:"
        Me.lblSaldoInicial.Visible = False
        '
        'txtSaldoInicial
        '
        Me.txtSaldoInicial.BindearPropiedadControl = Nothing
        Me.txtSaldoInicial.BindearPropiedadEntidad = Nothing
        Me.txtSaldoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoInicial.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoInicial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoInicial.Formato = ""
        Me.txtSaldoInicial.IsDecimal = True
        Me.txtSaldoInicial.IsNumber = True
        Me.txtSaldoInicial.IsPK = False
        Me.txtSaldoInicial.IsRequired = False
        Me.txtSaldoInicial.Key = ""
        Me.txtSaldoInicial.LabelAsoc = Nothing
        Me.txtSaldoInicial.Location = New System.Drawing.Point(591, 2)
        Me.txtSaldoInicial.Name = "txtSaldoInicial"
        Me.txtSaldoInicial.ReadOnly = True
        Me.txtSaldoInicial.Size = New System.Drawing.Size(76, 20)
        Me.txtSaldoInicial.TabIndex = 5
        Me.txtSaldoInicial.Text = "0.00"
        Me.txtSaldoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoInicial.Visible = False
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoActual.ForeColor = System.Drawing.Color.Red
        Me.lblSaldoActual.LabelAsoc = Nothing
        Me.lblSaldoActual.Location = New System.Drawing.Point(200, 5)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(70, 13)
        Me.lblSaldoActual.TabIndex = 2
        Me.lblSaldoActual.Text = "Saldo Actual:"
        Me.lblSaldoActual.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.txtSaldoFinal)
        Me.Panel2.Controls.Add(Me.lblSaldoFinal)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 301)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(918, 25)
        Me.Panel2.TabIndex = 3
        '
        'txtSaldoFinal
        '
        Me.txtSaldoFinal.BindearPropiedadControl = Nothing
        Me.txtSaldoFinal.BindearPropiedadEntidad = Nothing
        Me.txtSaldoFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoFinal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoFinal.Formato = ""
        Me.txtSaldoFinal.IsDecimal = True
        Me.txtSaldoFinal.IsNumber = True
        Me.txtSaldoFinal.IsPK = False
        Me.txtSaldoFinal.IsRequired = False
        Me.txtSaldoFinal.Key = ""
        Me.txtSaldoFinal.LabelAsoc = Nothing
        Me.txtSaldoFinal.Location = New System.Drawing.Point(591, 2)
        Me.txtSaldoFinal.Name = "txtSaldoFinal"
        Me.txtSaldoFinal.ReadOnly = True
        Me.txtSaldoFinal.Size = New System.Drawing.Size(76, 20)
        Me.txtSaldoFinal.TabIndex = 7
        Me.txtSaldoFinal.Text = "0.00"
        Me.txtSaldoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.AutoSize = True
        Me.lblSaldoFinal.LabelAsoc = Nothing
        Me.lblSaldoFinal.Location = New System.Drawing.Point(525, 5)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(62, 13)
        Me.lblSaldoFinal.TabIndex = 6
        Me.lblSaldoFinal.Text = "Saldo Final:"
        '
        'tbpKardex
        '
        Me.tbpKardex.Controls.Add(Me.KardexComprobCtaCteClientesUC1)
        Me.tbpKardex.Location = New System.Drawing.Point(4, 22)
        Me.tbpKardex.Name = "tbpKardex"
        Me.tbpKardex.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpKardex.Size = New System.Drawing.Size(924, 329)
        Me.tbpKardex.TabIndex = 1
        Me.tbpKardex.Text = "Kardex"
        Me.tbpKardex.UseVisualStyleBackColor = True
        '
        'KardexComprobCtaCteClientesUC1
        '
        Me.KardexComprobCtaCteClientesUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KardexComprobCtaCteClientesUC1.Location = New System.Drawing.Point(3, 3)
        Me.KardexComprobCtaCteClientesUC1.Name = "KardexComprobCtaCteClientesUC1"
        Me.KardexComprobCtaCteClientesUC1.Size = New System.Drawing.Size(918, 323)
        Me.KardexComprobCtaCteClientesUC1.TabIndex = 0
        '
        'ConsultarCtaCteDetClientesDH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 546)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tbcDetalle)
        Me.KeyPreview = True
        Me.Name = "ConsultarCtaCteDetClientesDH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Cta. Cte. Detallada de Cliente - Debe y Haber"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.grbEmbarcacionCama.ResumeLayout(False)
        Me.grbEmbarcacionCama.PerformLayout()
        Me.grbFiltroYOrden.ResumeLayout(False)
        Me.grbFiltroYOrden.PerformLayout()
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpDetalle.ResumeLayout(False)
        Me.pnlSaldoInicial.ResumeLayout(False)
        Me.pnlSaldoInicial.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tbpKardex.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents tss5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtSaldoActual As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoActual As Eniac.Controles.Label
   Friend WithEvents txtSaldoInicial As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoInicial As Eniac.Controles.Label
   Friend WithEvents txtSaldoFinal As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoFinal As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents chbFechas As Eniac.Controles.CheckBox
   Friend WithEvents lblCliente As Eniac.Controles.Label
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents grbFiltroYOrden As System.Windows.Forms.GroupBox
   Friend WithEvents optFechaVencimiento As Eniac.Controles.RadioButton
   Friend WithEvents optFechaEmision As Eniac.Controles.RadioButton
   Friend WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents cmbGrupos As Eniac.Controles.ComboBox
   Friend WithEvents chbGrupo As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirMinutas As Eniac.Controles.CheckBox
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Private WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents tss4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents chbFechaInteres As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaInteres As Eniac.Controles.DateTimePicker
   Friend WithEvents cmbTipoConversion As Eniac.Controles.ComboBox
   Friend WithEvents lblMoneda As Eniac.Controles.Label
   Friend WithEvents cmbMoneda As Eniac.Controles.ComboBox
   Friend WithEvents txtCotizacionDolar As Eniac.Controles.TextBox
   Friend WithEvents lblCotizacionDolar As Eniac.Controles.Label
   Friend WithEvents chbMostrarComprobanteAplicado As Eniac.Controles.CheckBox
   Public WithEvents tsbAsignarComprobanteAplicado As System.Windows.Forms.ToolStripButton
   Private WithEvents tss6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents tbpDetalle As System.Windows.Forms.TabPage
   Friend WithEvents tbpKardex As System.Windows.Forms.TabPage
   Friend WithEvents KardexComprobCtaCteClientesUC1 As Eniac.Win.KardexComprobCtaCteClientesUC
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents pnlSaldoInicial As System.Windows.Forms.Panel
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbExcluirPreComprobantes As Eniac.Controles.CheckBox
   Friend WithEvents grbEmbarcacionCama As Panel
   Friend WithEvents chbEmbarcacionCama As Controles.CheckBox
    Friend WithEvents bscCodigoEmbarcacionCama As Controles.Buscador2
    Friend WithEvents bscNombreEmbarcacion As Controles.Buscador2
End Class
