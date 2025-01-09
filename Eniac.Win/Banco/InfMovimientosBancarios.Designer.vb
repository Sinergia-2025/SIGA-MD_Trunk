<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfMovimientosBancarios
   Inherits Eniac.Win.BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfMovimientosBancarios))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuenta")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimiento")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaMovimiento")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBanco")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaBanco")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoMovimiento")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescCheque")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAplicado")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Conciliado")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdGrupoCuenta")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsModificable")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEjercicio")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanCuenta")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAsiento")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCentroCosto")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCentroCosto")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GeneraContabilidad")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDeposito")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCheque")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacionAsiento")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdConceptoCM05")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionConceptoCM05")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoConceptoCM05")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.bscCuentaBancaria = New Eniac.Controles.Buscador()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblMovimientoDesde = New Eniac.Controles.Label()
      Me.lblMovimientoHasta = New Eniac.Controles.Label()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.optPosTodos = New Eniac.Controles.RadioButton()
      Me.lblPosdatados = New Eniac.Controles.Label()
      Me.optPosdatados = New Eniac.Controles.RadioButton()
      Me.optNoPosdatados = New Eniac.Controles.RadioButton()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.bscNombreCuenta = New Eniac.Controles.Buscador2()
      Me.bscCodigoCuenta = New Eniac.Controles.Buscador2()
      Me.chbCuentaDeCaja = New Eniac.Controles.CheckBox()
      Me.chbCuentaBancaria = New Eniac.Controles.CheckBox()
      Me.cmbMonedas = New Eniac.Controles.ComboBox()
      Me.lblMoneda = New Eniac.Controles.Label()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbTipoFechaFiltro = New Eniac.Controles.ComboBox()
      Me.chbGrupo = New Eniac.Controles.CheckBox()
      Me.cmbGrupos = New Eniac.Controles.ComboBox()
      Me.cmbConciliado = New Eniac.Controles.ComboBox()
      Me.lblConciliados = New Eniac.Controles.Label()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(999, 29)
      Me.tstBarra.TabIndex = 0
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
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      Me.tsbSalir.ToolTipText = "Cerrar la Pantalla"
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn1.Width = 70
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Hidden = True
      UltraGridColumn13.Header.Caption = "Nombre Cuenta"
      UltraGridColumn13.Header.VisiblePosition = 2
      UltraGridColumn13.Width = 150
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn3.CellAppearance = Appearance2
      UltraGridColumn3.Header.Caption = "Mov."
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Width = 50
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn4.CellAppearance = Appearance3
      UltraGridColumn4.Format = "dd/MM/yyyy"
      UltraGridColumn4.Header.Caption = "Movimiento"
      UltraGridColumn4.Header.VisiblePosition = 9
      UltraGridColumn4.MaskInput = "{LOC}dd/mm/yyyy"
      UltraGridColumn4.Width = 75
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance4
      UltraGridColumn5.Header.Caption = "Cuenta"
      UltraGridColumn5.Header.VisiblePosition = 4
      UltraGridColumn5.Width = 50
      UltraGridColumn6.Header.Caption = "Descripción"
      UltraGridColumn6.Header.VisiblePosition = 6
      UltraGridColumn6.Width = 250
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance5
      UltraGridColumn7.Format = "N2"
      UltraGridColumn7.Header.VisiblePosition = 8
      UltraGridColumn7.Width = 75
      Appearance6.TextHAlignAsString = "Center"
      UltraGridColumn8.CellAppearance = Appearance6
      UltraGridColumn8.Header.Caption = "T."
      UltraGridColumn8.Header.VisiblePosition = 7
      UltraGridColumn8.Width = 20
      UltraGridColumn9.Header.Caption = "Cheque"
      UltraGridColumn9.Header.VisiblePosition = 13
      UltraGridColumn9.Width = 240
      Appearance7.TextHAlignAsString = "Center"
      UltraGridColumn14.CellAppearance = Appearance7
      UltraGridColumn14.Format = "dd/MM/yyyy"
      UltraGridColumn14.Header.Caption = "Fecha Cobro"
      UltraGridColumn14.Header.VisiblePosition = 14
      UltraGridColumn14.Width = 80
      Appearance8.TextHAlignAsString = "Center"
      UltraGridColumn10.CellAppearance = Appearance8
      UltraGridColumn10.Format = "dd/MM/yyyy"
      UltraGridColumn10.Header.Caption = "Aplicado"
      UltraGridColumn10.Header.VisiblePosition = 10
      UltraGridColumn10.MaskInput = "{LOC}dd/mm/yyyy"
      UltraGridColumn10.Width = 75
      Appearance9.TextHAlignAsString = "Center"
      UltraGridColumn11.CellAppearance = Appearance9
      UltraGridColumn11.Header.Caption = "Conc."
      UltraGridColumn11.Header.VisiblePosition = 11
      UltraGridColumn11.Width = 40
      UltraGridColumn12.Header.VisiblePosition = 12
      UltraGridColumn12.Width = 300
      Appearance10.TextHAlignAsString = "Left"
      UltraGridColumn15.CellAppearance = Appearance10
      UltraGridColumn15.Header.Caption = "Grupo"
      UltraGridColumn15.Header.VisiblePosition = 5
      UltraGridColumn15.Width = 83
      UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn16.Header.VisiblePosition = 15
      UltraGridColumn16.Hidden = True
      UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn17.Header.VisiblePosition = 16
      UltraGridColumn17.Hidden = True
      UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn18.Header.VisiblePosition = 17
      UltraGridColumn18.Hidden = True
      UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn19.Header.VisiblePosition = 18
      UltraGridColumn19.Hidden = True
      UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn20.Header.VisiblePosition = 19
      UltraGridColumn20.Hidden = True
      UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn21.Header.VisiblePosition = 20
      UltraGridColumn21.Hidden = True
      UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn22.Header.VisiblePosition = 21
      UltraGridColumn22.Hidden = True
      UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn23.Header.VisiblePosition = 22
      UltraGridColumn23.Hidden = True
      UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn24.Header.VisiblePosition = 23
      UltraGridColumn24.Hidden = True
      UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn25.CellAppearance = Appearance11
      UltraGridColumn25.Header.VisiblePosition = 24
      UltraGridColumn25.Hidden = True
      UltraGridColumn26.Format = "dd/MM/yyyy"
      UltraGridColumn26.Header.Caption = "Fecha Actualización"
      UltraGridColumn26.Header.VisiblePosition = 25
      UltraGridColumn27.Header.VisiblePosition = 28
      UltraGridColumn27.Hidden = True
      UltraGridColumn28.Header.Caption = "Concepto CM05"
      UltraGridColumn28.Header.VisiblePosition = 26
      UltraGridColumn28.Width = 150
      Appearance12.TextHAlignAsString = "Center"
      UltraGridColumn29.CellAppearance = Appearance12
      UltraGridColumn29.Header.Caption = "Tipo CM05"
      UltraGridColumn29.Header.VisiblePosition = 27
      UltraGridColumn29.Width = 80
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn13, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn14, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance13
      Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar"
      Appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance15.BackColor2 = System.Drawing.SystemColors.Control
      Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance16.BackColor = System.Drawing.SystemColors.Window
      Appearance16.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance16
      Appearance17.BackColor = System.Drawing.SystemColors.Highlight
      Appearance17.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance18.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance18
      Appearance19.BorderColor = System.Drawing.Color.Silver
      Appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance19
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance20.BackColor = System.Drawing.SystemColors.Control
      Appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance20.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance20
      Appearance21.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance21
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance22.BackColor = System.Drawing.SystemColors.Window
      Appearance22.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance22
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance23.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance23
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(5, 182)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(990, 330)
      Me.ugDetalle.TabIndex = 3
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'UltraDataSource1
      '
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 515)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(999, 22)
      Me.stsStado.TabIndex = 0
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(920, 17)
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
      Appearance24.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance24
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
      'bscCuentaBancaria
      '
      Me.bscCuentaBancaria.AyudaAncho = 608
      Me.bscCuentaBancaria.BindearPropiedadControl = Nothing
      Me.bscCuentaBancaria.BindearPropiedadEntidad = Nothing
      Me.bscCuentaBancaria.ColumnasAlineacion = Nothing
      Me.bscCuentaBancaria.ColumnasAncho = Nothing
      Me.bscCuentaBancaria.ColumnasFormato = Nothing
      Me.bscCuentaBancaria.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
      Me.bscCuentaBancaria.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
      Me.bscCuentaBancaria.Datos = Nothing
      Me.bscCuentaBancaria.Enabled = False
      Me.bscCuentaBancaria.FilaDevuelta = Nothing
      Me.bscCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCuentaBancaria.IsDecimal = False
      Me.bscCuentaBancaria.IsNumber = False
      Me.bscCuentaBancaria.IsPK = False
      Me.bscCuentaBancaria.IsRequired = False
      Me.bscCuentaBancaria.Key = ""
      Me.bscCuentaBancaria.LabelAsoc = Nothing
      Me.bscCuentaBancaria.Location = New System.Drawing.Point(121, 79)
      Me.bscCuentaBancaria.MaxLengh = "32767"
      Me.bscCuentaBancaria.Name = "bscCuentaBancaria"
      Me.bscCuentaBancaria.Permitido = True
      Me.bscCuentaBancaria.Selecciono = False
      Me.bscCuentaBancaria.Size = New System.Drawing.Size(270, 20)
      Me.bscCuentaBancaria.TabIndex = 12
      Me.bscCuentaBancaria.Titulo = "Clientes"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Nothing
      Me.dtpDesde.Location = New System.Drawing.Point(164, 53)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpDesde.TabIndex = 7
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Nothing
      Me.dtpHasta.Location = New System.Drawing.Point(307, 53)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpHasta.TabIndex = 9
      Me.dtpHasta.Value = New Date(2008, 12, 30, 0, 0, 0, 0)
      '
      'lblMovimientoDesde
      '
      Me.lblMovimientoDesde.AutoSize = True
      Me.lblMovimientoDesde.LabelAsoc = Nothing
      Me.lblMovimientoDesde.Location = New System.Drawing.Point(121, 57)
      Me.lblMovimientoDesde.Name = "lblMovimientoDesde"
      Me.lblMovimientoDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblMovimientoDesde.TabIndex = 6
      Me.lblMovimientoDesde.Text = "Desde"
      '
      'lblMovimientoHasta
      '
      Me.lblMovimientoHasta.AutoSize = True
      Me.lblMovimientoHasta.LabelAsoc = Nothing
      Me.lblMovimientoHasta.Location = New System.Drawing.Point(268, 57)
      Me.lblMovimientoHasta.Name = "lblMovimientoHasta"
      Me.lblMovimientoHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblMovimientoHasta.TabIndex = 8
      Me.lblMovimientoHasta.Text = "Hasta"
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(16, 55)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 5
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(851, 40)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 18
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.optPosTodos)
      Me.Panel2.Controls.Add(Me.lblPosdatados)
      Me.Panel2.Controls.Add(Me.optPosdatados)
      Me.Panel2.Controls.Add(Me.optNoPosdatados)
      Me.Panel2.Location = New System.Drawing.Point(188, 19)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(357, 26)
      Me.Panel2.TabIndex = 2
      '
      'optPosTodos
      '
      Me.optPosTodos.AutoSize = True
      Me.optPosTodos.BindearPropiedadControl = Nothing
      Me.optPosTodos.BindearPropiedadEntidad = Nothing
      Me.optPosTodos.Checked = True
      Me.optPosTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.optPosTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optPosTodos.IsPK = False
      Me.optPosTodos.IsRequired = False
      Me.optPosTodos.Key = Nothing
      Me.optPosTodos.LabelAsoc = Me.lblPosdatados
      Me.optPosTodos.Location = New System.Drawing.Point(93, 5)
      Me.optPosTodos.Name = "optPosTodos"
      Me.optPosTodos.Size = New System.Drawing.Size(55, 17)
      Me.optPosTodos.TabIndex = 1
      Me.optPosTodos.TabStop = True
      Me.optPosTodos.Text = "Todos"
      Me.optPosTodos.UseVisualStyleBackColor = True
      '
      'lblPosdatados
      '
      Me.lblPosdatados.AutoSize = True
      Me.lblPosdatados.LabelAsoc = Nothing
      Me.lblPosdatados.Location = New System.Drawing.Point(9, 7)
      Me.lblPosdatados.Name = "lblPosdatados"
      Me.lblPosdatados.Size = New System.Drawing.Size(63, 13)
      Me.lblPosdatados.TabIndex = 0
      Me.lblPosdatados.Text = "Posdatados"
      '
      'optPosdatados
      '
      Me.optPosdatados.AutoSize = True
      Me.optPosdatados.BindearPropiedadControl = Nothing
      Me.optPosdatados.BindearPropiedadEntidad = Nothing
      Me.optPosdatados.ForeColorFocus = System.Drawing.Color.Red
      Me.optPosdatados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optPosdatados.IsPK = False
      Me.optPosdatados.IsRequired = False
      Me.optPosdatados.Key = Nothing
      Me.optPosdatados.LabelAsoc = Me.lblPosdatados
      Me.optPosdatados.Location = New System.Drawing.Point(156, 5)
      Me.optPosdatados.Name = "optPosdatados"
      Me.optPosdatados.Size = New System.Drawing.Size(81, 17)
      Me.optPosdatados.TabIndex = 2
      Me.optPosdatados.Text = "Posdatados"
      Me.optPosdatados.UseVisualStyleBackColor = True
      '
      'optNoPosdatados
      '
      Me.optNoPosdatados.AutoSize = True
      Me.optNoPosdatados.BindearPropiedadControl = Nothing
      Me.optNoPosdatados.BindearPropiedadEntidad = Nothing
      Me.optNoPosdatados.ForeColorFocus = System.Drawing.Color.Red
      Me.optNoPosdatados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optNoPosdatados.IsPK = False
      Me.optNoPosdatados.IsRequired = False
      Me.optNoPosdatados.Key = Nothing
      Me.optNoPosdatados.LabelAsoc = Me.lblPosdatados
      Me.optNoPosdatados.Location = New System.Drawing.Point(251, 5)
      Me.optNoPosdatados.Name = "optNoPosdatados"
      Me.optNoPosdatados.Size = New System.Drawing.Size(98, 17)
      Me.optNoPosdatados.TabIndex = 3
      Me.optNoPosdatados.Text = "No Posdatados"
      Me.optNoPosdatados.UseVisualStyleBackColor = True
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(851, 91)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
      Me.chkExpandAll.TabIndex = 19
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'bscNombreCuenta
      '
      Me.bscNombreCuenta.ActivarFiltroEnGrilla = True
      Me.bscNombreCuenta.AutoSize = True
      Me.bscNombreCuenta.BindearPropiedadControl = Nothing
      Me.bscNombreCuenta.BindearPropiedadEntidad = Nothing
      Me.bscNombreCuenta.ConfigBuscador = Nothing
      Me.bscNombreCuenta.Datos = Nothing
      Me.bscNombreCuenta.Enabled = False
      Me.bscNombreCuenta.FilaDevuelta = Nothing
      Me.bscNombreCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCuenta.IsDecimal = False
      Me.bscNombreCuenta.IsNumber = False
      Me.bscNombreCuenta.IsPK = False
      Me.bscNombreCuenta.IsRequired = False
      Me.bscNombreCuenta.Key = ""
      Me.bscNombreCuenta.LabelAsoc = Nothing
      Me.bscNombreCuenta.Location = New System.Drawing.Point(242, 107)
      Me.bscNombreCuenta.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreCuenta.MaxLengh = "32767"
      Me.bscNombreCuenta.Name = "bscNombreCuenta"
      Me.bscNombreCuenta.Permitido = True
      Me.bscNombreCuenta.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreCuenta.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreCuenta.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreCuenta.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreCuenta.Selecciono = False
      Me.bscNombreCuenta.Size = New System.Drawing.Size(338, 23)
      Me.bscNombreCuenta.TabIndex = 17
      '
      'bscCodigoCuenta
      '
      Me.bscCodigoCuenta.ActivarFiltroEnGrilla = True
      Me.bscCodigoCuenta.BindearPropiedadControl = Nothing
      Me.bscCodigoCuenta.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCuenta.ConfigBuscador = Nothing
      Me.bscCodigoCuenta.Datos = Nothing
      Me.bscCodigoCuenta.Enabled = False
      Me.bscCodigoCuenta.FilaDevuelta = Nothing
      Me.bscCodigoCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCuenta.IsDecimal = False
      Me.bscCodigoCuenta.IsNumber = False
      Me.bscCodigoCuenta.IsPK = False
      Me.bscCodigoCuenta.IsRequired = False
      Me.bscCodigoCuenta.Key = ""
      Me.bscCodigoCuenta.LabelAsoc = Nothing
      Me.bscCodigoCuenta.Location = New System.Drawing.Point(121, 108)
      Me.bscCodigoCuenta.MaxLengh = "32767"
      Me.bscCodigoCuenta.Name = "bscCodigoCuenta"
      Me.bscCodigoCuenta.Permitido = True
      Me.bscCodigoCuenta.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCuenta.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCuenta.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCuenta.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCuenta.Selecciono = False
      Me.bscCodigoCuenta.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoCuenta.TabIndex = 16
      '
      'chbCuentaDeCaja
      '
      Me.chbCuentaDeCaja.AutoSize = True
      Me.chbCuentaDeCaja.BindearPropiedadControl = Nothing
      Me.chbCuentaDeCaja.BindearPropiedadEntidad = Nothing
      Me.chbCuentaDeCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCuentaDeCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCuentaDeCaja.IsPK = False
      Me.chbCuentaDeCaja.IsRequired = False
      Me.chbCuentaDeCaja.Key = Nothing
      Me.chbCuentaDeCaja.LabelAsoc = Nothing
      Me.chbCuentaDeCaja.Location = New System.Drawing.Point(16, 110)
      Me.chbCuentaDeCaja.Name = "chbCuentaDeCaja"
      Me.chbCuentaDeCaja.Size = New System.Drawing.Size(97, 17)
      Me.chbCuentaDeCaja.TabIndex = 15
      Me.chbCuentaDeCaja.Text = "Cuenta Movim."
      Me.chbCuentaDeCaja.UseVisualStyleBackColor = True
      '
      'chbCuentaBancaria
      '
      Me.chbCuentaBancaria.AutoSize = True
      Me.chbCuentaBancaria.BindearPropiedadControl = Nothing
      Me.chbCuentaBancaria.BindearPropiedadEntidad = Nothing
      Me.chbCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCuentaBancaria.IsPK = False
      Me.chbCuentaBancaria.IsRequired = False
      Me.chbCuentaBancaria.Key = Nothing
      Me.chbCuentaBancaria.LabelAsoc = Nothing
      Me.chbCuentaBancaria.Location = New System.Drawing.Point(16, 81)
      Me.chbCuentaBancaria.Name = "chbCuentaBancaria"
      Me.chbCuentaBancaria.Size = New System.Drawing.Size(105, 17)
      Me.chbCuentaBancaria.TabIndex = 11
      Me.chbCuentaBancaria.Text = "Cuenta Bancaria"
      Me.chbCuentaBancaria.UseVisualStyleBackColor = True
      '
      'cmbMonedas
      '
      Me.cmbMonedas.BindearPropiedadControl = "SelectedValue"
      Me.cmbMonedas.BindearPropiedadEntidad = "Moneda.IdMoneda"
      Me.cmbMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMonedas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMonedas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMonedas.FormattingEnabled = True
      Me.cmbMonedas.IsPK = False
      Me.cmbMonedas.IsRequired = True
      Me.cmbMonedas.Key = Nothing
      Me.cmbMonedas.LabelAsoc = Me.lblMoneda
      Me.cmbMonedas.Location = New System.Drawing.Point(68, 22)
      Me.cmbMonedas.Name = "cmbMonedas"
      Me.cmbMonedas.Size = New System.Drawing.Size(100, 21)
      Me.cmbMonedas.TabIndex = 1
      '
      'lblMoneda
      '
      Me.lblMoneda.AutoSize = True
      Me.lblMoneda.LabelAsoc = Nothing
      Me.lblMoneda.Location = New System.Drawing.Point(16, 26)
      Me.lblMoneda.Name = "lblMoneda"
      Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
      Me.lblMoneda.TabIndex = 0
      Me.lblMoneda.Text = "Moneda"
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.cmbTipoFechaFiltro)
      Me.grbFiltros.Controls.Add(Me.chbGrupo)
      Me.grbFiltros.Controls.Add(Me.cmbGrupos)
      Me.grbFiltros.Controls.Add(Me.cmbConciliado)
      Me.grbFiltros.Controls.Add(Me.lblConciliados)
      Me.grbFiltros.Controls.Add(Me.lblMoneda)
      Me.grbFiltros.Controls.Add(Me.cmbMonedas)
      Me.grbFiltros.Controls.Add(Me.chbCuentaBancaria)
      Me.grbFiltros.Controls.Add(Me.chbCuentaDeCaja)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCuenta)
      Me.grbFiltros.Controls.Add(Me.bscNombreCuenta)
      Me.grbFiltros.Controls.Add(Me.chkExpandAll)
      Me.grbFiltros.Controls.Add(Me.Panel2)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.lblMovimientoHasta)
      Me.grbFiltros.Controls.Add(Me.lblMovimientoDesde)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.bscCuentaBancaria)
      Me.grbFiltros.Location = New System.Drawing.Point(5, 34)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(990, 142)
      Me.grbFiltros.TabIndex = 1
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'cmbTipoFechaFiltro
      '
      Me.cmbTipoFechaFiltro.BindearPropiedadControl = ""
      Me.cmbTipoFechaFiltro.BindearPropiedadEntidad = ""
      Me.cmbTipoFechaFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoFechaFiltro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoFechaFiltro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoFechaFiltro.FormattingEnabled = True
      Me.cmbTipoFechaFiltro.IsPK = False
      Me.cmbTipoFechaFiltro.IsRequired = False
      Me.cmbTipoFechaFiltro.Key = Nothing
      Me.cmbTipoFechaFiltro.LabelAsoc = Nothing
      Me.cmbTipoFechaFiltro.Location = New System.Drawing.Point(408, 53)
      Me.cmbTipoFechaFiltro.Name = "cmbTipoFechaFiltro"
      Me.cmbTipoFechaFiltro.Size = New System.Drawing.Size(156, 21)
      Me.cmbTipoFechaFiltro.TabIndex = 10
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
      Me.chbGrupo.Location = New System.Drawing.Point(428, 81)
      Me.chbGrupo.Name = "chbGrupo"
      Me.chbGrupo.Size = New System.Drawing.Size(55, 17)
      Me.chbGrupo.TabIndex = 13
      Me.chbGrupo.Text = "Grupo"
      Me.chbGrupo.UseVisualStyleBackColor = True
      '
      'cmbGrupos
      '
      Me.cmbGrupos.BindearPropiedadControl = ""
      Me.cmbGrupos.BindearPropiedadEntidad = ""
      Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGrupos.Enabled = False
      Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbGrupos.FormattingEnabled = True
      Me.cmbGrupos.IsPK = False
      Me.cmbGrupos.IsRequired = False
      Me.cmbGrupos.Key = Nothing
      Me.cmbGrupos.LabelAsoc = Nothing
      Me.cmbGrupos.Location = New System.Drawing.Point(484, 79)
      Me.cmbGrupos.Name = "cmbGrupos"
      Me.cmbGrupos.Size = New System.Drawing.Size(96, 21)
      Me.cmbGrupos.TabIndex = 14
      '
      'cmbConciliado
      '
      Me.cmbConciliado.BindearPropiedadControl = Nothing
      Me.cmbConciliado.BindearPropiedadEntidad = Nothing
      Me.cmbConciliado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbConciliado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbConciliado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbConciliado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbConciliado.FormattingEnabled = True
      Me.cmbConciliado.IsPK = False
      Me.cmbConciliado.IsRequired = False
      Me.cmbConciliado.Key = Nothing
      Me.cmbConciliado.LabelAsoc = Me.lblConciliados
      Me.cmbConciliado.Location = New System.Drawing.Point(646, 22)
      Me.cmbConciliado.Name = "cmbConciliado"
      Me.cmbConciliado.Size = New System.Drawing.Size(83, 21)
      Me.cmbConciliado.TabIndex = 4
      '
      'lblConciliados
      '
      Me.lblConciliados.AutoSize = True
      Me.lblConciliados.LabelAsoc = Nothing
      Me.lblConciliados.Location = New System.Drawing.Point(566, 25)
      Me.lblConciliados.Name = "lblConciliados"
      Me.lblConciliados.Size = New System.Drawing.Size(61, 13)
      Me.lblConciliados.TabIndex = 3
      Me.lblConciliados.Text = "Conciliados"
      '
      'InfMovimientosBancarios
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(999, 537)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "InfMovimientosBancarios"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Movimientos Bancarios "
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bscCuentaBancaria As Eniac.Controles.Buscador
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblMovimientoDesde As Eniac.Controles.Label
   Friend WithEvents lblMovimientoHasta As Eniac.Controles.Label
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents optPosTodos As Eniac.Controles.RadioButton
   Friend WithEvents lblPosdatados As Eniac.Controles.Label
   Friend WithEvents optPosdatados As Eniac.Controles.RadioButton
   Friend WithEvents optNoPosdatados As Eniac.Controles.RadioButton
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents bscNombreCuenta As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoCuenta As Eniac.Controles.Buscador2
   Friend WithEvents chbCuentaDeCaja As Eniac.Controles.CheckBox
   Friend WithEvents chbCuentaBancaria As Eniac.Controles.CheckBox
   Friend WithEvents cmbMonedas As Eniac.Controles.ComboBox
    Friend WithEvents lblMoneda As Eniac.Controles.Label
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbConciliado As Eniac.Controles.ComboBox
    Friend WithEvents lblConciliados As Eniac.Controles.Label
    Friend WithEvents chbGrupo As Eniac.Controles.CheckBox
    Friend WithEvents cmbGrupos As Eniac.Controles.ComboBox
    Friend WithEvents cmbTipoFechaFiltro As Controles.ComboBox
End Class
