<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LibroBancos
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
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCuentaBancaria")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescCuentaBancaria")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroMovimiento")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCuentaBanco")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCuentaBanco")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoMovimiento")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Importe")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Saldo")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaMovimiento")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaAplicado")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Conciliado")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroCheque")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdBanco")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescCheque")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsModificable")
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("GeneraContabilidad")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdPlanCuenta")
        Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdAsiento")
        Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCentroCosto")
        Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCentroCosto")
        Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
        Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoComprobante")
        Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
        Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
        Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
        Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocCliente")
        Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocCliente")
        Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoriaFiscal")
        Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaDePago")
        Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
        Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
        Dim UltraDataColumn38 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
        Dim UltraDataColumn39 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn40 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioLista")
        Dim UltraDataColumn41 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn42 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
        Dim UltraDataColumn43 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
        Dim UltraDataColumn44 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
        Dim UltraDataColumn45 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
        Dim UltraDataColumn46 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
        Dim UltraDataColumn47 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
        Dim UltraDataColumn48 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
        Dim UltraDataColumn49 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selec")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescCuentaBancaria")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimiento")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBanco")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaBanco")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoMovimiento")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaMovimiento")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAplicado")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Conciliado")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescCheque")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsModificable")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GeneraContabilidad")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanCuenta")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAsiento")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCentroCosto")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCentroCosto")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDeposito")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCheque")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacionAsiento")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdConceptoCM05")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionConceptoCM05")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoConceptoCM05")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LibroBancos))
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.lblBuscar = New Eniac.Controles.Label()
        Me.lblConciliados = New Eniac.Controles.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optGeneral = New Eniac.Controles.RadioButton()
        Me.lblSaldoArrastre = New Eniac.Controles.Label()
        Me.optConciliado = New Eniac.Controles.RadioButton()
        Me.txtBuscar = New Eniac.Controles.TextBox()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.dpFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaHasta = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCuentaBanacaria = New Eniac.Controles.Label()
        Me.dpSaldoAl = New Eniac.Controles.DateTimePicker()
        Me.lblFechaSaldo = New Eniac.Controles.Label()
        Me.lblSaldoConciliado = New Eniac.Controles.Label()
        Me.txtSaldoConciliado = New Eniac.Controles.TextBox()
        Me.lblSaldoGeneral = New Eniac.Controles.Label()
        Me.txtSaldoGeneral = New Eniac.Controles.TextBox()
        Me.bscCuentaBancaria = New Eniac.Controles.Buscador2()
        Me.dpFechaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaDesde = New Eniac.Controles.Label()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNuevoMovimiento = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEditarMovimiento = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEliminarMovimiento = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbConciliar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDesconciliar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimirPred = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.cmbConciliado = New Eniac.Controles.ComboBox()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource2
        '
        UltraDataColumn10.DataType = GetType(Date)
        UltraDataColumn11.DataType = GetType(Date)
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22})
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27, UltraDataColumn28, UltraDataColumn29, UltraDataColumn30, UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35, UltraDataColumn36, UltraDataColumn37, UltraDataColumn38, UltraDataColumn39, UltraDataColumn40, UltraDataColumn41, UltraDataColumn42, UltraDataColumn43, UltraDataColumn44, UltraDataColumn45, UltraDataColumn46, UltraDataColumn47, UltraDataColumn48, UltraDataColumn49})
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
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn28.CellAppearance = Appearance2
        UltraGridColumn28.Header.Caption = ""
        UltraGridColumn28.Header.VisiblePosition = 0
        UltraGridColumn28.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn28.Width = 23
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.Header.Caption = "S."
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 22
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance3
        UltraGridColumn4.Header.Caption = "Mov."
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 46
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance4
        UltraGridColumn5.Header.Caption = "Cuenta"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 55
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "Descripcion"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 207
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance5
        UltraGridColumn7.Header.Caption = "T."
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 28
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance6
        UltraGridColumn8.Format = "N2"
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Width = 75
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance7
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Width = 81
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance8
        UltraGridColumn10.Format = "dd/MM/yyyy"
        UltraGridColumn10.Header.Caption = "Movimiento"
        UltraGridColumn10.Header.VisiblePosition = 10
        UltraGridColumn10.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn10.Width = 76
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn11.CellAppearance = Appearance9
        UltraGridColumn11.Format = "dd/MM/yyyy"
        UltraGridColumn11.Header.Caption = "Aplicado"
        UltraGridColumn11.Header.VisiblePosition = 11
        UltraGridColumn11.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn11.Width = 67
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn12.CellAppearance = Appearance10
        UltraGridColumn12.Header.Caption = "Conc."
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridColumn12.Width = 40
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.VisiblePosition = 14
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.Caption = "Cheque"
        UltraGridColumn15.Header.VisiblePosition = 15
        UltraGridColumn15.Width = 230
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn23.CellAppearance = Appearance11
        UltraGridColumn23.Format = "dd/MM/yyyy"
        UltraGridColumn23.Header.Caption = "Fecha Cobro"
        UltraGridColumn23.Header.VisiblePosition = 16
        UltraGridColumn23.Width = 80
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.Caption = "Observación"
        UltraGridColumn16.Header.VisiblePosition = 19
        UltraGridColumn16.Width = 348
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.Caption = "Mod."
        UltraGridColumn17.Header.VisiblePosition = 17
        UltraGridColumn17.Width = 40
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn22.CellAppearance = Appearance12
        UltraGridColumn22.Header.Caption = "Cntb"
        UltraGridColumn22.Header.VisiblePosition = 18
        UltraGridColumn22.Width = 40
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance13
        UltraGridColumn18.Header.Caption = "P."
        UltraGridColumn18.Header.VisiblePosition = 22
        UltraGridColumn18.Width = 25
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance14
        UltraGridColumn19.Header.Caption = "Asiento"
        UltraGridColumn19.Header.VisiblePosition = 23
        UltraGridColumn19.Width = 54
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance15
        UltraGridColumn20.Header.Caption = "C.C."
        UltraGridColumn20.Header.VisiblePosition = 24
        UltraGridColumn20.Width = 47
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.Caption = "Centro de Costos"
        UltraGridColumn21.Header.VisiblePosition = 25
        UltraGridColumn21.Width = 331
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.TextHAlignAsString = "Left"
        UltraGridColumn24.CellAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        UltraGridColumn24.FilterCellAppearance = Appearance17
        UltraGridColumn24.Header.Caption = "Comprobante"
        UltraGridColumn24.Header.VisiblePosition = 26
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn25.FilterCellAppearance = Appearance19
        UltraGridColumn25.Header.Caption = "Deposito"
        UltraGridColumn25.Header.VisiblePosition = 27
        UltraGridColumn25.Width = 64
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance20
        UltraGridColumn26.Header.VisiblePosition = 28
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance21.TextHAlignAsString = "Center"
        UltraGridColumn27.CellAppearance = Appearance21
        UltraGridColumn27.Format = "dd/MM/yyyy"
        UltraGridColumn27.Header.Caption = "Fecha Actualización"
        UltraGridColumn27.Header.VisiblePosition = 29
        UltraGridColumn27.Width = 117
        UltraGridColumn29.Header.VisiblePosition = 30
        UltraGridColumn29.Hidden = True
        UltraGridColumn30.Header.Caption = "Concepto CM05"
        UltraGridColumn30.Header.VisiblePosition = 20
        UltraGridColumn30.Width = 150
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn31.CellAppearance = Appearance22
        UltraGridColumn31.Header.Caption = "Tipo CM05"
        UltraGridColumn31.Header.VisiblePosition = 21
        UltraGridColumn31.Width = 80
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn28, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn23, UltraGridColumn16, UltraGridColumn17, UltraGridColumn22, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31})
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
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
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
        Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance33.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(4, 155)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(978, 368)
        Me.ugDetalle.TabIndex = 12
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.LabelAsoc = Nothing
        Me.lblBuscar.Location = New System.Drawing.Point(439, 95)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
        Me.lblBuscar.TabIndex = 8
        Me.lblBuscar.Text = "Buscar"
        '
        'lblConciliados
        '
        Me.lblConciliados.AutoSize = True
        Me.lblConciliados.LabelAsoc = Nothing
        Me.lblConciliados.Location = New System.Drawing.Point(283, 96)
        Me.lblConciliados.Name = "lblConciliados"
        Me.lblConciliados.Size = New System.Drawing.Size(61, 13)
        Me.lblConciliados.TabIndex = 6
        Me.lblConciliados.Text = "Conciliados"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optGeneral)
        Me.Panel1.Controls.Add(Me.lblSaldoArrastre)
        Me.Panel1.Controls.Add(Me.optConciliado)
        Me.Panel1.Location = New System.Drawing.Point(750, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 28)
        Me.Panel1.TabIndex = 11
        '
        'optGeneral
        '
        Me.optGeneral.AutoSize = True
        Me.optGeneral.BindearPropiedadControl = Nothing
        Me.optGeneral.BindearPropiedadEntidad = Nothing
        Me.optGeneral.Checked = True
        Me.optGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.optGeneral.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optGeneral.IsPK = False
        Me.optGeneral.IsRequired = False
        Me.optGeneral.Key = Nothing
        Me.optGeneral.LabelAsoc = Me.lblSaldoArrastre
        Me.optGeneral.Location = New System.Drawing.Point(85, 6)
        Me.optGeneral.Name = "optGeneral"
        Me.optGeneral.Size = New System.Drawing.Size(62, 17)
        Me.optGeneral.TabIndex = 2
        Me.optGeneral.TabStop = True
        Me.optGeneral.Text = "General"
        Me.optGeneral.UseVisualStyleBackColor = True
        '
        'lblSaldoArrastre
        '
        Me.lblSaldoArrastre.AutoSize = True
        Me.lblSaldoArrastre.LabelAsoc = Nothing
        Me.lblSaldoArrastre.Location = New System.Drawing.Point(4, 8)
        Me.lblSaldoArrastre.Name = "lblSaldoArrastre"
        Me.lblSaldoArrastre.Size = New System.Drawing.Size(76, 13)
        Me.lblSaldoArrastre.TabIndex = 1
        Me.lblSaldoArrastre.Text = "Saldo Arrastre:"
        '
        'optConciliado
        '
        Me.optConciliado.AutoSize = True
        Me.optConciliado.BindearPropiedadControl = Nothing
        Me.optConciliado.BindearPropiedadEntidad = Nothing
        Me.optConciliado.ForeColorFocus = System.Drawing.Color.Red
        Me.optConciliado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optConciliado.IsPK = False
        Me.optConciliado.IsRequired = False
        Me.optConciliado.Key = Nothing
        Me.optConciliado.LabelAsoc = Me.lblSaldoArrastre
        Me.optConciliado.Location = New System.Drawing.Point(151, 6)
        Me.optConciliado.Name = "optConciliado"
        Me.optConciliado.Size = New System.Drawing.Size(74, 17)
        Me.optConciliado.TabIndex = 0
        Me.optConciliado.Text = "Conciliado"
        Me.optConciliado.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.BindearPropiedadControl = "Text"
        Me.txtBuscar.BindearPropiedadEntidad = "NombreBanco"
        Me.txtBuscar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBuscar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBuscar.Formato = ""
        Me.txtBuscar.IsDecimal = False
        Me.txtBuscar.IsNumber = False
        Me.txtBuscar.IsPK = False
        Me.txtBuscar.IsRequired = False
        Me.txtBuscar.Key = ""
        Me.txtBuscar.LabelAsoc = Me.lblBuscar
        Me.txtBuscar.Location = New System.Drawing.Point(486, 92)
        Me.txtBuscar.MaxLength = 40
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(145, 20)
        Me.txtBuscar.TabIndex = 9
        '
        'stsStado
        '
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 544)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(990, 22)
        Me.stsStado.TabIndex = 13
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(911, 17)
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
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMostrar.Location = New System.Drawing.Point(644, 79)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(100, 45)
        Me.btnMostrar.TabIndex = 10
        Me.btnMostrar.Text = "Consultar"
        Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'dpFechaHasta
        '
        Me.dpFechaHasta.BindearPropiedadControl = Nothing
        Me.dpFechaHasta.BindearPropiedadEntidad = Nothing
        Me.dpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaHasta.IsPK = False
        Me.dpFechaHasta.IsRequired = False
        Me.dpFechaHasta.Key = ""
        Me.dpFechaHasta.LabelAsoc = Me.lblFechaHasta
        Me.dpFechaHasta.Location = New System.Drawing.Point(185, 92)
        Me.dpFechaHasta.Name = "dpFechaHasta"
        Me.dpFechaHasta.Size = New System.Drawing.Size(95, 20)
        Me.dpFechaHasta.TabIndex = 5
        Me.dpFechaHasta.Value = New Date(2008, 12, 30, 0, 0, 0, 0)
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.LabelAsoc = Nothing
        Me.lblFechaHasta.Location = New System.Drawing.Point(146, 96)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaHasta.TabIndex = 4
        Me.lblFechaHasta.Text = "Hasta"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCuentaBanacaria)
        Me.GroupBox1.Controls.Add(Me.dpSaldoAl)
        Me.GroupBox1.Controls.Add(Me.lblFechaSaldo)
        Me.GroupBox1.Controls.Add(Me.lblSaldoConciliado)
        Me.GroupBox1.Controls.Add(Me.txtSaldoConciliado)
        Me.GroupBox1.Controls.Add(Me.lblSaldoGeneral)
        Me.GroupBox1.Controls.Add(Me.txtSaldoGeneral)
        Me.GroupBox1.Controls.Add(Me.bscCuentaBancaria)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(971, 49)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblCuentaBanacaria
        '
        Me.lblCuentaBanacaria.AutoSize = True
        Me.lblCuentaBanacaria.LabelAsoc = Nothing
        Me.lblCuentaBanacaria.Location = New System.Drawing.Point(15, 21)
        Me.lblCuentaBanacaria.Name = "lblCuentaBanacaria"
        Me.lblCuentaBanacaria.Size = New System.Drawing.Size(86, 13)
        Me.lblCuentaBanacaria.TabIndex = 0
        Me.lblCuentaBanacaria.Text = "Cuenta Bancaria"
        '
        'dpSaldoAl
        '
        Me.dpSaldoAl.BindearPropiedadControl = Nothing
        Me.dpSaldoAl.BindearPropiedadEntidad = Nothing
        Me.dpSaldoAl.ForeColorFocus = System.Drawing.Color.Red
        Me.dpSaldoAl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dpSaldoAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpSaldoAl.IsPK = False
        Me.dpSaldoAl.IsRequired = False
        Me.dpSaldoAl.Key = ""
        Me.dpSaldoAl.LabelAsoc = Nothing
        Me.dpSaldoAl.Location = New System.Drawing.Point(859, 17)
        Me.dpSaldoAl.Name = "dpSaldoAl"
        Me.dpSaldoAl.Size = New System.Drawing.Size(95, 20)
        Me.dpSaldoAl.TabIndex = 7
        Me.dpSaldoAl.Value = New Date(2010, 1, 9, 0, 0, 0, 0)
        '
        'lblFechaSaldo
        '
        Me.lblFechaSaldo.AutoSize = True
        Me.lblFechaSaldo.LabelAsoc = Nothing
        Me.lblFechaSaldo.Location = New System.Drawing.Point(839, 21)
        Me.lblFechaSaldo.Name = "lblFechaSaldo"
        Me.lblFechaSaldo.Size = New System.Drawing.Size(16, 13)
        Me.lblFechaSaldo.TabIndex = 6
        Me.lblFechaSaldo.Text = "Al"
        '
        'lblSaldoConciliado
        '
        Me.lblSaldoConciliado.AutoSize = True
        Me.lblSaldoConciliado.LabelAsoc = Nothing
        Me.lblSaldoConciliado.Location = New System.Drawing.Point(617, 21)
        Me.lblSaldoConciliado.Name = "lblSaldoConciliado"
        Me.lblSaldoConciliado.Size = New System.Drawing.Size(86, 13)
        Me.lblSaldoConciliado.TabIndex = 4
        Me.lblSaldoConciliado.Text = "Saldo Conciliado"
        '
        'txtSaldoConciliado
        '
        Me.txtSaldoConciliado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtSaldoConciliado.BindearPropiedadControl = Nothing
        Me.txtSaldoConciliado.BindearPropiedadEntidad = Nothing
        Me.txtSaldoConciliado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoConciliado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoConciliado.Formato = "##,##0.00"
        Me.txtSaldoConciliado.IsDecimal = True
        Me.txtSaldoConciliado.IsNumber = True
        Me.txtSaldoConciliado.IsPK = False
        Me.txtSaldoConciliado.IsRequired = False
        Me.txtSaldoConciliado.Key = ""
        Me.txtSaldoConciliado.LabelAsoc = Me.lblSaldoConciliado
        Me.txtSaldoConciliado.Location = New System.Drawing.Point(707, 17)
        Me.txtSaldoConciliado.Name = "txtSaldoConciliado"
        Me.txtSaldoConciliado.ReadOnly = True
        Me.txtSaldoConciliado.Size = New System.Drawing.Size(90, 20)
        Me.txtSaldoConciliado.TabIndex = 5
        Me.txtSaldoConciliado.Text = "0.00"
        Me.txtSaldoConciliado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoGeneral
        '
        Me.lblSaldoGeneral.AutoSize = True
        Me.lblSaldoGeneral.LabelAsoc = Nothing
        Me.lblSaldoGeneral.Location = New System.Drawing.Point(435, 21)
        Me.lblSaldoGeneral.Name = "lblSaldoGeneral"
        Me.lblSaldoGeneral.Size = New System.Drawing.Size(74, 13)
        Me.lblSaldoGeneral.TabIndex = 2
        Me.lblSaldoGeneral.Text = "Saldo General"
        '
        'txtSaldoGeneral
        '
        Me.txtSaldoGeneral.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtSaldoGeneral.BindearPropiedadControl = Nothing
        Me.txtSaldoGeneral.BindearPropiedadEntidad = Nothing
        Me.txtSaldoGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoGeneral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoGeneral.Formato = "##,##0.00"
        Me.txtSaldoGeneral.IsDecimal = True
        Me.txtSaldoGeneral.IsNumber = True
        Me.txtSaldoGeneral.IsPK = False
        Me.txtSaldoGeneral.IsRequired = False
        Me.txtSaldoGeneral.Key = ""
        Me.txtSaldoGeneral.LabelAsoc = Me.lblSaldoGeneral
        Me.txtSaldoGeneral.Location = New System.Drawing.Point(513, 17)
        Me.txtSaldoGeneral.Name = "txtSaldoGeneral"
        Me.txtSaldoGeneral.ReadOnly = True
        Me.txtSaldoGeneral.Size = New System.Drawing.Size(90, 20)
        Me.txtSaldoGeneral.TabIndex = 3
        Me.txtSaldoGeneral.Text = "0.00"
        Me.txtSaldoGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCuentaBancaria
        '
        Me.bscCuentaBancaria.ActivarFiltroEnGrilla = True
        Me.bscCuentaBancaria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCuentaBancaria.BindearPropiedadControl = Nothing
        Me.bscCuentaBancaria.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancaria.ConfigBuscador = Nothing
        Me.bscCuentaBancaria.Datos = Nothing
        Me.bscCuentaBancaria.FilaDevuelta = Nothing
        Me.bscCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancaria.IsDecimal = False
        Me.bscCuentaBancaria.IsNumber = False
        Me.bscCuentaBancaria.IsPK = False
        Me.bscCuentaBancaria.IsRequired = False
        Me.bscCuentaBancaria.Key = ""
        Me.bscCuentaBancaria.LabelAsoc = Me.lblCuentaBanacaria
        Me.bscCuentaBancaria.Location = New System.Drawing.Point(103, 18)
        Me.bscCuentaBancaria.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCuentaBancaria.MaxLengh = "32767"
        Me.bscCuentaBancaria.Name = "bscCuentaBancaria"
        Me.bscCuentaBancaria.Permitido = True
        Me.bscCuentaBancaria.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCuentaBancaria.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancaria.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCuentaBancaria.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancaria.Selecciono = False
        Me.bscCuentaBancaria.Size = New System.Drawing.Size(325, 20)
        Me.bscCuentaBancaria.TabIndex = 1
        '
        'dpFechaDesde
        '
        Me.dpFechaDesde.BindearPropiedadControl = Nothing
        Me.dpFechaDesde.BindearPropiedadEntidad = Nothing
        Me.dpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaDesde.IsPK = False
        Me.dpFechaDesde.IsRequired = False
        Me.dpFechaDesde.Key = ""
        Me.dpFechaDesde.LabelAsoc = Me.lblFechaDesde
        Me.dpFechaDesde.Location = New System.Drawing.Point(49, 92)
        Me.dpFechaDesde.Name = "dpFechaDesde"
        Me.dpFechaDesde.Size = New System.Drawing.Size(95, 20)
        Me.dpFechaDesde.TabIndex = 3
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.LabelAsoc = Nothing
        Me.lblFechaDesde.Location = New System.Drawing.Point(8, 96)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaDesde.TabIndex = 2
        Me.lblFechaDesde.Text = "Desde"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbNuevoMovimiento, Me.ToolStripSeparator6, Me.tsbEditarMovimiento, Me.ToolStripSeparator5, Me.tsbEliminarMovimiento, Me.ToolStripSeparator4, Me.tsbConciliar, Me.ToolStripSeparator10, Me.tsbDesconciliar, Me.ToolStripSeparator1, Me.tsbImprimirPred, Me.ToolStripSeparator8, Me.tsbImprimir, Me.ToolStripSeparator9, Me.tsddExportar, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator7, Me.tsbCerrar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(990, 29)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbNuevoMovimiento
        '
        Me.tsbNuevoMovimiento.Image = Global.Eniac.Win.My.Resources.Resources.document_add
        Me.tsbNuevoMovimiento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevoMovimiento.Name = "tsbNuevoMovimiento"
        Me.tsbNuevoMovimiento.Size = New System.Drawing.Size(68, 26)
        Me.tsbNuevoMovimiento.Text = "&Nuevo"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 29)
        '
        'tsbEditarMovimiento
        '
        Me.tsbEditarMovimiento.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.tsbEditarMovimiento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarMovimiento.Name = "tsbEditarMovimiento"
        Me.tsbEditarMovimiento.Size = New System.Drawing.Size(63, 26)
        Me.tsbEditarMovimiento.Text = "&Editar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbEliminarMovimiento
        '
        Me.tsbEliminarMovimiento.Image = Global.Eniac.Win.My.Resources.Resources.document_delete
        Me.tsbEliminarMovimiento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminarMovimiento.Name = "tsbEliminarMovimiento"
        Me.tsbEliminarMovimiento.Size = New System.Drawing.Size(76, 26)
        Me.tsbEliminarMovimiento.Text = "E&liminar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbConciliar
        '
        Me.tsbConciliar.Image = Global.Eniac.Win.My.Resources.Resources.copy_ok_32
        Me.tsbConciliar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConciliar.Name = "tsbConciliar"
        Me.tsbConciliar.Size = New System.Drawing.Size(80, 26)
        Me.tsbConciliar.Text = "&Conciliar"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 29)
        '
        'tsbDesconciliar
        '
        Me.tsbDesconciliar.Image = Global.Eniac.Win.My.Resources.Resources.copy_ok_32
        Me.tsbDesconciliar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDesconciliar.Name = "tsbDesconciliar"
        Me.tsbDesconciliar.Size = New System.Drawing.Size(97, 26)
        Me.tsbDesconciliar.Text = "&Desconciliar"
        Me.tsbDesconciliar.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimirPred
        '
        Me.tsbImprimirPred.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimirPred.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirPred.Name = "tsbImprimirPred"
        Me.tsbImprimirPred.Size = New System.Drawing.Size(87, 26)
        Me.tsbImprimirPred.Text = "&Imp. Pred."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "I&mprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 29)
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
        Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCerrar
        '
        Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
        Me.tsbCerrar.Text = "&Cerrar"
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(138, 126)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 15
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(11, 128)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 14
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
        Me.cmbConciliado.Location = New System.Drawing.Point(350, 92)
        Me.cmbConciliado.Name = "cmbConciliado"
        Me.cmbConciliado.Size = New System.Drawing.Size(83, 21)
        Me.cmbConciliado.TabIndex = 7
        '
        'LibroBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 566)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.cmbConciliado)
        Me.Controls.Add(Me.lblConciliados)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.btnMostrar)
        Me.Controls.Add(Me.dpFechaHasta)
        Me.Controls.Add(Me.lblFechaHasta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dpFechaDesde)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.lblFechaDesde)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "LibroBancos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos de Bancos"
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bscCuentaBancaria As Eniac.Controles.Buscador2
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbNuevoMovimiento As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbEditarMovimiento As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbEliminarMovimiento As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimirPred As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblSaldoConciliado As Eniac.Controles.Label
   Friend WithEvents txtSaldoConciliado As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoGeneral As Eniac.Controles.Label
   Friend WithEvents txtSaldoGeneral As Eniac.Controles.TextBox
   Friend WithEvents tsbConciliar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblFechaDesde As Eniac.Controles.Label
   Friend WithEvents dpFechaDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaHasta As Eniac.Controles.Label
   Friend WithEvents dpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents btnMostrar As System.Windows.Forms.Button
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents dpSaldoAl As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaSaldo As Eniac.Controles.Label
   Friend WithEvents txtBuscar As Eniac.Controles.TextBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents optGeneral As Eniac.Controles.RadioButton
   Friend WithEvents lblSaldoArrastre As Eniac.Controles.Label
   Friend WithEvents optConciliado As Eniac.Controles.RadioButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents lblBuscar As Eniac.Controles.Label
   Friend WithEvents cmbConciliado As Eniac.Controles.ComboBox
   Friend WithEvents lblConciliados As Eniac.Controles.Label
   Friend WithEvents lblCuentaBanacaria As Eniac.Controles.Label
    Friend WithEvents btnTodos As Button
    Friend WithEvents cmbTodos As Controles.ComboBox
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents tsbDesconciliar As ToolStripButton
End Class
