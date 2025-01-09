<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InformeSituacionCrediticiaClientes
   Inherits Eniac.Win.BaseForm

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
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCobrador")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmpleado")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCobrador")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE2")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LimiteDeCredito")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoLimiteDeCredito")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SitCrediticia")
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
        Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreVendedor")
        Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCliente")
        Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoCliente")
        Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoria")
        Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCobrador")
        Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdEmpleado")
        Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCobrador")
        Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreEstadoCliente")
        Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cuit")
        Dim UltraDataColumn38 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreZonaGeografica")
        Dim UltraDataColumn39 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Telefonos")
        Dim UltraDataColumn40 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Total")
        Dim UltraDataColumn41 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Saldo")
        Dim UltraDataColumn42 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantDiasPromedio")
        Dim UltraDataColumn43 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("SaldoVencido")
        Dim UltraDataColumn44 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantDiasPromedioVencido")
        Dim UltraDataColumn45 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IMPORTE2")
        Dim UltraDataColumn46 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreLocalidad")
        Dim UltraDataColumn47 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
        Dim UltraDataColumn48 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdVendedor")
        Dim UltraDataColumn49 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaInicioSaldo")
        Dim UltraDataColumn50 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Direccion")
        Dim UltraDataColumn51 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodVin")
        Dim UltraDataColumn52 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreVin")
        Dim UltraDataColumn53 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdClienteCtaCte")
        Dim UltraDataColumn54 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDeFantasia")
        Dim UltraDataColumn55 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreVendedor")
        Dim UltraDataColumn56 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCliente")
        Dim UltraDataColumn57 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoCliente")
        Dim UltraDataColumn58 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn59 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoria")
        Dim UltraDataColumn60 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCobrador")
        Dim UltraDataColumn61 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdEmpleado")
        Dim UltraDataColumn62 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCobrador")
        Dim UltraDataColumn63 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreEstadoCliente")
        Dim UltraDataColumn64 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cuit")
        Dim UltraDataColumn65 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreZonaGeografica")
        Dim UltraDataColumn66 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Telefonos")
        Dim UltraDataColumn67 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Total")
        Dim UltraDataColumn68 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Saldo")
        Dim UltraDataColumn69 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantDiasPromedio")
        Dim UltraDataColumn70 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("SaldoVencido")
        Dim UltraDataColumn71 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantDiasPromedioVencido")
        Dim UltraDataColumn72 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IMPORTE2")
        Dim UltraDataColumn73 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreLocalidad")
        Dim UltraDataColumn74 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
        Dim UltraDataColumn75 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdVendedor")
        Dim UltraDataColumn76 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaInicioSaldo")
        Dim UltraDataColumn77 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Direccion")
        Dim UltraDataColumn78 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodVin")
        Dim UltraDataColumn79 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreVin")
        Dim UltraDataColumn80 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdClienteCtaCte")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeSituacionCrediticiaClientes))
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UltraDataSource3 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbFiltros = New System.Windows.Forms.ToolStripButton()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New Eniac.Controles.GroupBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.chbAgruparSaldosCHFecha = New Eniac.Controles.CheckBox()
        Me.dtpFechaCobroCheques = New Eniac.Controles.DateTimePicker()
        Me.cmbTipoCliente = New Eniac.Controles.ComboBox()
        Me.lblCliente = New Eniac.Controles.Label()
        Me.chbCobrador = New Eniac.Controles.CheckBox()
        Me.cmbCobrador = New Eniac.Controles.ComboBox()
        Me.cmbOrigenCobrador = New Eniac.Controles.ComboBox()
        Me.cmbOrigenVendedor = New Eniac.Controles.ComboBox()
        Me.cmbOrigenCategoria = New Eniac.Controles.ComboBox()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.chbAgregarClientesSinSaldo = New Eniac.Controles.CheckBox()
        Me.chbIncluyeChTerceros = New Eniac.Controles.CheckBox()
        Me.chbExcluirPreComprobantes = New Eniac.Controles.CheckBox()
        Me.chbExcluirAnticipos = New Eniac.Controles.CheckBox()
        Me.chkExpandAll = New Eniac.Controles.CheckBox()
        Me.cmbActivos = New Eniac.Controles.ComboBox()
        Me.lblActivos = New Eniac.Controles.Label()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.chbCategoria = New Eniac.Controles.CheckBox()
        Me.cmbCategoria = New Eniac.Controles.ComboBox()
        Me.chbExcluirSaldosNegativos = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.FiltersManager1 = New Eniac.Win.FilterManager.FilterManager(Me.components)
        Me.pnlMain = New System.Windows.Forms.Panel()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.pnlMain.SuspendLayout()
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
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "Vendedor"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Width = 117
        UltraGridColumn2.Header.VisiblePosition = 15
        UltraGridColumn2.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.Caption = "Codigo"
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn4.Width = 65
        UltraGridColumn6.Header.Caption = "Cliente"
        UltraGridColumn6.Header.VisiblePosition = 3
        UltraGridColumn6.Width = 138
        UltraGridColumn7.Header.Caption = "Categoria"
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 86
        UltraGridColumn8.Header.VisiblePosition = 4
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.VisiblePosition = 5
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.Header.Caption = "Cobrador"
        UltraGridColumn10.Header.VisiblePosition = 17
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.VisiblePosition = 6
        UltraGridColumn11.Width = 84
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance3
        UltraGridColumn12.Format = "N2"
        UltraGridColumn12.Header.VisiblePosition = 14
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 90
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance4
        UltraGridColumn13.Format = "N2"
        UltraGridColumn13.Header.Caption = "Cuenta Corriente"
        UltraGridColumn13.Header.VisiblePosition = 10
        UltraGridColumn13.MinWidth = 90
        UltraGridColumn13.Width = 102
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance5
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.Caption = "Cheques"
        UltraGridColumn15.Header.VisiblePosition = 11
        UltraGridColumn15.MinWidth = 90
        UltraGridColumn15.Width = 102
        UltraGridColumn18.Header.Caption = "Localidad"
        UltraGridColumn18.Header.VisiblePosition = 8
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 101
        UltraGridColumn19.Header.Caption = "S."
        UltraGridColumn19.Header.VisiblePosition = 0
        UltraGridColumn19.MinWidth = 25
        UltraGridColumn19.Width = 25
        UltraGridColumn33.Header.VisiblePosition = 16
        UltraGridColumn33.Hidden = True
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance6
        UltraGridColumn34.Format = "N2"
        UltraGridColumn34.Header.Caption = "Límite de Crédito"
        UltraGridColumn34.Header.VisiblePosition = 9
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance7
        UltraGridColumn35.Format = "N2"
        UltraGridColumn35.Header.Caption = "Saldo Límite de Crédito"
        UltraGridColumn35.Header.VisiblePosition = 13
        UltraGridColumn35.Width = 130
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance8
        UltraGridColumn36.Format = "N2"
        UltraGridColumn36.Header.Caption = "Situación Crediticia"
        UltraGridColumn36.Header.VisiblePosition = 12
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn4, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn15, UltraGridColumn18, UltraGridColumn19, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36})
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
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
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
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
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
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance18
        Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 321)
        Me.ugDetalle.TabIndex = 0
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'UltraDataSource3
        '
        Me.UltraDataSource3.Band.Columns.AddRange(New Object() {UltraDataColumn28, UltraDataColumn29, UltraDataColumn30, UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35, UltraDataColumn36, UltraDataColumn37, UltraDataColumn38, UltraDataColumn39, UltraDataColumn40, UltraDataColumn41, UltraDataColumn42, UltraDataColumn43, UltraDataColumn44, UltraDataColumn45, UltraDataColumn46, UltraDataColumn47, UltraDataColumn48, UltraDataColumn49, UltraDataColumn50, UltraDataColumn51, UltraDataColumn52, UltraDataColumn53, UltraDataColumn54})
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn55, UltraDataColumn56, UltraDataColumn57, UltraDataColumn58, UltraDataColumn59, UltraDataColumn60, UltraDataColumn61, UltraDataColumn62, UltraDataColumn63, UltraDataColumn64, UltraDataColumn65, UltraDataColumn66, UltraDataColumn67, UltraDataColumn68, UltraDataColumn69, UltraDataColumn70, UltraDataColumn71, UltraDataColumn72, UltraDataColumn73, UltraDataColumn74, UltraDataColumn75, UltraDataColumn76, UltraDataColumn77, UltraDataColumn78, UltraDataColumn79, UltraDataColumn80})
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
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbFiltros, Me.tsbPreferencias, Me.ToolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 3
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
        '
        'tsbFiltros
        '
        Me.tsbFiltros.Image = Global.Eniac.Win.My.Resources.Resources.filter_data_24
        Me.tsbFiltros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFiltros.Name = "tsbFiltros"
        Me.tsbFiltros.Size = New System.Drawing.Size(65, 26)
        Me.tsbFiltros.Text = "Filtros"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.chbAgruparSaldosCHFecha)
        Me.grbFiltros.Controls.Add(Me.dtpFechaCobroCheques)
        Me.grbFiltros.Controls.Add(Me.cmbTipoCliente)
        Me.grbFiltros.Controls.Add(Me.lblCliente)
        Me.grbFiltros.Controls.Add(Me.chbCobrador)
        Me.grbFiltros.Controls.Add(Me.cmbCobrador)
        Me.grbFiltros.Controls.Add(Me.cmbOrigenCobrador)
        Me.grbFiltros.Controls.Add(Me.cmbOrigenVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbOrigenCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.chbAgregarClientesSinSaldo)
        Me.grbFiltros.Controls.Add(Me.chbIncluyeChTerceros)
        Me.grbFiltros.Controls.Add(Me.chbExcluirPreComprobantes)
        Me.grbFiltros.Controls.Add(Me.chbExcluirAnticipos)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.cmbActivos)
        Me.grbFiltros.Controls.Add(Me.lblActivos)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.chbCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbCategoria)
        Me.grbFiltros.Controls.Add(Me.chbExcluirSaldosNegativos)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.chbFecha)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(984, 189)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(3, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Fecha Desde de Cobro Cheques"
        '
        'chbAgruparSaldosCHFecha
        '
        Me.chbAgruparSaldosCHFecha.AutoSize = True
        Me.chbAgruparSaldosCHFecha.BindearPropiedadControl = Nothing
        Me.chbAgruparSaldosCHFecha.BindearPropiedadEntidad = Nothing
        Me.chbAgruparSaldosCHFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAgruparSaldosCHFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAgruparSaldosCHFecha.IsPK = False
        Me.chbAgruparSaldosCHFecha.IsRequired = False
        Me.chbAgruparSaldosCHFecha.Key = Nothing
        Me.chbAgruparSaldosCHFecha.LabelAsoc = Nothing
        Me.chbAgruparSaldosCHFecha.Location = New System.Drawing.Point(654, 142)
        Me.chbAgruparSaldosCHFecha.Name = "chbAgruparSaldosCHFecha"
        Me.chbAgruparSaldosCHFecha.Size = New System.Drawing.Size(255, 17)
        Me.chbAgruparSaldosCHFecha.TabIndex = 43
        Me.chbAgruparSaldosCHFecha.Text = "Agrupar Saldos de Cheques por Fecha de Cobro"
        Me.chbAgruparSaldosCHFecha.UseVisualStyleBackColor = True
        '
        'dtpFechaCobroCheques
        '
        Me.dtpFechaCobroCheques.BindearPropiedadControl = Nothing
        Me.dtpFechaCobroCheques.BindearPropiedadEntidad = Nothing
        Me.dtpFechaCobroCheques.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCobroCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCobroCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCobroCheques.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCobroCheques.IsPK = False
        Me.dtpFechaCobroCheques.IsRequired = False
        Me.dtpFechaCobroCheques.Key = ""
        Me.dtpFechaCobroCheques.LabelAsoc = Nothing
        Me.dtpFechaCobroCheques.Location = New System.Drawing.Point(171, 69)
        Me.dtpFechaCobroCheques.Name = "dtpFechaCobroCheques"
        Me.dtpFechaCobroCheques.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaCobroCheques.TabIndex = 42
        '
        'cmbTipoCliente
        '
        Me.cmbTipoCliente.BindearPropiedadControl = Nothing
        Me.cmbTipoCliente.BindearPropiedadEntidad = Nothing
        Me.cmbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoCliente.FormattingEnabled = True
        Me.cmbTipoCliente.IsPK = False
        Me.cmbTipoCliente.IsRequired = False
        Me.cmbTipoCliente.Key = Nothing
        Me.cmbTipoCliente.LabelAsoc = Nothing
        Me.cmbTipoCliente.Location = New System.Drawing.Point(404, 95)
        Me.cmbTipoCliente.Name = "cmbTipoCliente"
        Me.cmbTipoCliente.Size = New System.Drawing.Size(110, 21)
        Me.cmbTipoCliente.TabIndex = 8
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Location = New System.Drawing.Point(328, 98)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(66, 13)
        Me.lblCliente.TabIndex = 7
        Me.lblCliente.Text = "Tipo Cliente "
        '
        'chbCobrador
        '
        Me.chbCobrador.AutoSize = True
        Me.chbCobrador.BindearPropiedadControl = Nothing
        Me.chbCobrador.BindearPropiedadEntidad = Nothing
        Me.chbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCobrador.IsPK = False
        Me.chbCobrador.IsRequired = False
        Me.chbCobrador.Key = Nothing
        Me.chbCobrador.LabelAsoc = Nothing
        Me.chbCobrador.Location = New System.Drawing.Point(6, 151)
        Me.chbCobrador.Name = "chbCobrador"
        Me.chbCobrador.Size = New System.Drawing.Size(69, 17)
        Me.chbCobrador.TabIndex = 25
        Me.chbCobrador.Text = "Cobrador"
        Me.chbCobrador.UseVisualStyleBackColor = True
        '
        'cmbCobrador
        '
        Me.cmbCobrador.BindearPropiedadControl = Nothing
        Me.cmbCobrador.BindearPropiedadEntidad = Nothing
        Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCobrador.Enabled = False
        Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCobrador.FormattingEnabled = True
        Me.cmbCobrador.IsPK = False
        Me.cmbCobrador.IsRequired = False
        Me.cmbCobrador.Key = Nothing
        Me.cmbCobrador.LabelAsoc = Me.chbCobrador
        Me.cmbCobrador.Location = New System.Drawing.Point(104, 149)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.Size = New System.Drawing.Size(118, 21)
        Me.cmbCobrador.TabIndex = 26
        '
        'cmbOrigenCobrador
        '
        Me.cmbOrigenCobrador.BindearPropiedadControl = Nothing
        Me.cmbOrigenCobrador.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenCobrador.Enabled = False
        Me.cmbOrigenCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenCobrador.FormattingEnabled = True
        Me.cmbOrigenCobrador.IsPK = False
        Me.cmbOrigenCobrador.IsRequired = False
        Me.cmbOrigenCobrador.Key = Nothing
        Me.cmbOrigenCobrador.LabelAsoc = Nothing
        Me.cmbOrigenCobrador.Location = New System.Drawing.Point(224, 149)
        Me.cmbOrigenCobrador.Name = "cmbOrigenCobrador"
        Me.cmbOrigenCobrador.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenCobrador.TabIndex = 27
        '
        'cmbOrigenVendedor
        '
        Me.cmbOrigenVendedor.BindearPropiedadControl = Nothing
        Me.cmbOrigenVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenVendedor.Enabled = False
        Me.cmbOrigenVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenVendedor.FormattingEnabled = True
        Me.cmbOrigenVendedor.IsPK = False
        Me.cmbOrigenVendedor.IsRequired = False
        Me.cmbOrigenVendedor.Key = Nothing
        Me.cmbOrigenVendedor.LabelAsoc = Nothing
        Me.cmbOrigenVendedor.Location = New System.Drawing.Point(224, 95)
        Me.cmbOrigenVendedor.Name = "cmbOrigenVendedor"
        Me.cmbOrigenVendedor.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenVendedor.TabIndex = 13
        '
        'cmbOrigenCategoria
        '
        Me.cmbOrigenCategoria.BindearPropiedadControl = Nothing
        Me.cmbOrigenCategoria.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenCategoria.Enabled = False
        Me.cmbOrigenCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenCategoria.FormattingEnabled = True
        Me.cmbOrigenCategoria.IsPK = False
        Me.cmbOrigenCategoria.IsRequired = False
        Me.cmbOrigenCategoria.Key = Nothing
        Me.cmbOrigenCategoria.LabelAsoc = Nothing
        Me.cmbOrigenCategoria.Location = New System.Drawing.Point(224, 122)
        Me.cmbOrigenCategoria.Name = "cmbOrigenCategoria"
        Me.cmbOrigenCategoria.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenCategoria.TabIndex = 20
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
        Me.cmbSucursal.Location = New System.Drawing.Point(103, 15)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(119, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(23, 19)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'chbAgregarClientesSinSaldo
        '
        Me.chbAgregarClientesSinSaldo.AutoSize = True
        Me.chbAgregarClientesSinSaldo.BindearPropiedadControl = Nothing
        Me.chbAgregarClientesSinSaldo.BindearPropiedadEntidad = Nothing
        Me.chbAgregarClientesSinSaldo.Checked = True
        Me.chbAgregarClientesSinSaldo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbAgregarClientesSinSaldo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAgregarClientesSinSaldo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAgregarClientesSinSaldo.IsPK = False
        Me.chbAgregarClientesSinSaldo.IsRequired = False
        Me.chbAgregarClientesSinSaldo.Key = Nothing
        Me.chbAgregarClientesSinSaldo.LabelAsoc = Nothing
        Me.chbAgregarClientesSinSaldo.Location = New System.Drawing.Point(654, 19)
        Me.chbAgregarClientesSinSaldo.Name = "chbAgregarClientesSinSaldo"
        Me.chbAgregarClientesSinSaldo.Size = New System.Drawing.Size(149, 17)
        Me.chbAgregarClientesSinSaldo.TabIndex = 34
        Me.chbAgregarClientesSinSaldo.Text = "Agregar Clientes sin Saldo"
        Me.chbAgregarClientesSinSaldo.UseVisualStyleBackColor = True
        '
        'chbIncluyeChTerceros
        '
        Me.chbIncluyeChTerceros.AutoSize = True
        Me.chbIncluyeChTerceros.BindearPropiedadControl = Nothing
        Me.chbIncluyeChTerceros.BindearPropiedadEntidad = Nothing
        Me.chbIncluyeChTerceros.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIncluyeChTerceros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIncluyeChTerceros.IsPK = False
        Me.chbIncluyeChTerceros.IsRequired = False
        Me.chbIncluyeChTerceros.Key = Nothing
        Me.chbIncluyeChTerceros.LabelAsoc = Nothing
        Me.chbIncluyeChTerceros.Location = New System.Drawing.Point(654, 42)
        Me.chbIncluyeChTerceros.Name = "chbIncluyeChTerceros"
        Me.chbIncluyeChTerceros.Size = New System.Drawing.Size(202, 17)
        Me.chbIncluyeChTerceros.TabIndex = 36
        Me.chbIncluyeChTerceros.Text = "Sumar Cheques de Terceros al Saldo"
        Me.chbIncluyeChTerceros.UseVisualStyleBackColor = True
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
        Me.chbExcluirPreComprobantes.Location = New System.Drawing.Point(654, 117)
        Me.chbExcluirPreComprobantes.Name = "chbExcluirPreComprobantes"
        Me.chbExcluirPreComprobantes.Size = New System.Drawing.Size(147, 17)
        Me.chbExcluirPreComprobantes.TabIndex = 39
        Me.chbExcluirPreComprobantes.Text = "Excluir Pre-Comprobantes"
        Me.chbExcluirPreComprobantes.UseVisualStyleBackColor = True
        '
        'chbExcluirAnticipos
        '
        Me.chbExcluirAnticipos.AutoSize = True
        Me.chbExcluirAnticipos.BindearPropiedadControl = Nothing
        Me.chbExcluirAnticipos.BindearPropiedadEntidad = Nothing
        Me.chbExcluirAnticipos.Checked = True
        Me.chbExcluirAnticipos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbExcluirAnticipos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirAnticipos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirAnticipos.IsPK = False
        Me.chbExcluirAnticipos.IsRequired = False
        Me.chbExcluirAnticipos.Key = Nothing
        Me.chbExcluirAnticipos.LabelAsoc = Nothing
        Me.chbExcluirAnticipos.Location = New System.Drawing.Point(654, 67)
        Me.chbExcluirAnticipos.Name = "chbExcluirAnticipos"
        Me.chbExcluirAnticipos.Size = New System.Drawing.Size(103, 17)
        Me.chbExcluirAnticipos.TabIndex = 37
        Me.chbExcluirAnticipos.Text = "Excluir Anticipos"
        Me.chbExcluirAnticipos.UseVisualStyleBackColor = True
        '
        'chkExpandAll
        '
        Me.chkExpandAll.BindearPropiedadControl = Nothing
        Me.chkExpandAll.BindearPropiedadEntidad = Nothing
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.ForeColorFocus = System.Drawing.Color.Red
        Me.chkExpandAll.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkExpandAll.IsPK = False
        Me.chkExpandAll.IsRequired = False
        Me.chkExpandAll.Key = Nothing
        Me.chkExpandAll.LabelAsoc = Nothing
        Me.chkExpandAll.Location = New System.Drawing.Point(874, 171)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 40
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'cmbActivos
        '
        Me.cmbActivos.BindearPropiedadControl = Nothing
        Me.cmbActivos.BindearPropiedadEntidad = Nothing
        Me.cmbActivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActivos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActivos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActivos.FormattingEnabled = True
        Me.cmbActivos.IsPK = False
        Me.cmbActivos.IsRequired = False
        Me.cmbActivos.Key = Nothing
        Me.cmbActivos.LabelAsoc = Me.lblActivos
        Me.cmbActivos.Location = New System.Drawing.Point(404, 147)
        Me.cmbActivos.Name = "cmbActivos"
        Me.cmbActivos.Size = New System.Drawing.Size(110, 21)
        Me.cmbActivos.TabIndex = 10
        '
        'lblActivos
        '
        Me.lblActivos.AutoSize = True
        Me.lblActivos.LabelAsoc = Nothing
        Me.lblActivos.Location = New System.Drawing.Point(328, 152)
        Me.lblActivos.Name = "lblActivos"
        Me.lblActivos.Size = New System.Drawing.Size(42, 13)
        Me.lblActivos.TabIndex = 9
        Me.lblActivos.Text = "Activos"
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
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(404, 121)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(110, 21)
        Me.cmbGrabanLibro.TabIndex = 29
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(328, 125)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 28
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
        Me.chbCategoria.Location = New System.Drawing.Point(6, 124)
        Me.chbCategoria.Name = "chbCategoria"
        Me.chbCategoria.Size = New System.Drawing.Size(73, 17)
        Me.chbCategoria.TabIndex = 18
        Me.chbCategoria.Text = "Categoría"
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
        Me.cmbCategoria.LabelAsoc = Me.chbCategoria
        Me.cmbCategoria.Location = New System.Drawing.Point(104, 122)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(118, 21)
        Me.cmbCategoria.TabIndex = 19
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
        Me.chbExcluirSaldosNegativos.Location = New System.Drawing.Point(654, 92)
        Me.chbExcluirSaldosNegativos.Name = "chbExcluirSaldosNegativos"
        Me.chbExcluirSaldosNegativos.Size = New System.Drawing.Size(143, 17)
        Me.chbExcluirSaldosNegativos.TabIndex = 38
        Me.chbExcluirSaldosNegativos.Text = "Excluir Saldos Negativos"
        Me.chbExcluirSaldosNegativos.UseVisualStyleBackColor = True
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
        Me.chbVendedor.Location = New System.Drawing.Point(6, 97)
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
        Me.cmbVendedor.LabelAsoc = Me.chbVendedor
        Me.cmbVendedor.Location = New System.Drawing.Point(103, 95)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(119, 21)
        Me.cmbVendedor.TabIndex = 12
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
        Me.chbCliente.Location = New System.Drawing.Point(223, 45)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 2
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
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = True
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(285, 42)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 3
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
        Me.bscCliente.LabelAsoc = Nothing
        Me.bscCliente.Location = New System.Drawing.Point(377, 42)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = False
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(260, 23)
        Me.bscCliente.TabIndex = 4
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
        Me.chbFecha.Location = New System.Drawing.Point(6, 44)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(87, 17)
        Me.chbFecha.TabIndex = 5
        Me.chbFecha.Text = "Fecha Hasta"
        Me.chbFecha.UseVisualStyleBackColor = True
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
        Me.dtpHasta.LabelAsoc = Me.chbFecha
        Me.dtpHasta.Location = New System.Drawing.Point(103, 42)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(101, 20)
        Me.dtpHasta.TabIndex = 6
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(870, 3)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'FiltersManager1
        '
        Me.FiltersManager1.BotonRefrescar = Me.tsbRefrescar
        Me.FiltersManager1.PanelFiltro = Me.grbFiltros
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.btnConsultar)
        Me.pnlMain.Controls.Add(Me.ugDetalle)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 218)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(984, 321)
        Me.pnlMain.TabIndex = 1
        '
        'InformeSituacionCrediticiaClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "InformeSituacionCrediticiaClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Situación Crediticia de Clientes"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As Eniac.Controles.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chbCliente As Eniac.Controles.CheckBox
    Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
    Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
    Friend WithEvents chbExcluirSaldosNegativos As Eniac.Controles.CheckBox
    Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
    Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
    Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
    Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
    Friend WithEvents ugDetalle As UltraGridSiga
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents chkExpandAll As Controles.CheckBox
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chbExcluirAnticipos As Eniac.Controles.CheckBox
    Friend WithEvents chbExcluirPreComprobantes As Eniac.Controles.CheckBox
    Friend WithEvents chbIncluyeChTerceros As Eniac.Controles.CheckBox
    Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chbAgregarClientesSinSaldo As Controles.CheckBox
    Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
    Friend WithEvents lblSucursal As Eniac.Controles.Label
    Friend WithEvents cmbOrigenVendedor As Eniac.Controles.ComboBox
    Friend WithEvents cmbOrigenCategoria As Eniac.Controles.ComboBox
    Friend WithEvents chbCobrador As Eniac.Controles.CheckBox
    Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
    Friend WithEvents cmbOrigenCobrador As Eniac.Controles.ComboBox
    Friend WithEvents tsbFiltros As System.Windows.Forms.ToolStripButton
    Friend WithEvents FiltersManager1 As Eniac.Win.FilterManager.FilterManager
   Friend WithEvents cmbTipoCliente As Controles.ComboBox
   Friend WithEvents lblCliente As Controles.Label
   Friend WithEvents UltraDataSource3 As UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraDataSource2 As UltraWinDataSource.UltraDataSource
   Friend WithEvents cmbActivos As Controles.ComboBox
   Friend WithEvents lblActivos As Controles.Label
   Friend WithEvents pnlMain As Panel
    Friend WithEvents chbAgruparSaldosCHFecha As Controles.CheckBox
    Friend WithEvents dtpFechaCobroCheques As Controles.DateTimePicker
    Friend WithEvents Label1 As Controles.Label
End Class
