<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarPrecios
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
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Simbolo")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoSinIVA")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoConIVA")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaSinIVA")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaConIVA")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Embalaje")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoEmbalajeSinIVA")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoEmbalajeConIVA")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VentaEmbalajeSinIVA")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VentaEmbalajeConIVA")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockReservado")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockDefectuoso")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockFuturo")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockFuturoReservado")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockTotal")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreModelo")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubSubRubro")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Activo")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeBarras")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UltimoProv")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UltimaFechaCompra")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProductoProveedor")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ubicacion")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta1")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta2")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta3")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta4")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UnidHasta5")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc1")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc2")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc3")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc4")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UHPorc5")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion_Fecha")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion_Hora")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacionCosto")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacionCosto_Fecha")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacionCosto_Hora")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockMinimo")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockMaximo")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PuntoDePedido")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioListaSinIVA")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioListaConIVA")
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcRecargoCostoVSVenta", 0)
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarPrecios))
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn117 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn118 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
        Dim UltraGridColumn119 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn120 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn121 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
        Dim UltraGridColumn122 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
        Dim UltraGridColumn123 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito")
        Dim UltraGridColumn124 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion")
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn127 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Actualizacion")
        Dim UltraGridColumn128 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDeposito")
        Dim UltraGridColumn130 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeposito", 0)
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.btnBuscar = New Eniac.Win.ButtonConsultar()
        Me.txtObservaciones = New Eniac.Controles.TextBox()
        Me.lblDescRecCantidad = New System.Windows.Forms.Label()
        Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
        Me.lblCotizacionDolar = New Eniac.Controles.Label()
        Me.chbVerStockReservado = New Eniac.Controles.CheckBox()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbProductosProveedor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.pnlFlowFiltros = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlFiltrosEs = New System.Windows.Forms.Panel()
        Me.lblAfectaStock = New Eniac.Controles.Label()
        Me.cmbAfectaStock = New Eniac.Controles.ComboBox()
        Me.cmbEsDeVentas = New Eniac.Controles.ComboBox()
        Me.cmbEsDeCompras = New Eniac.Controles.ComboBox()
        Me.lblEsDeCompras = New Eniac.Controles.Label()
        Me.cmbEsOferta = New Eniac.Controles.ComboBox()
        Me.lblEsDeVentas = New Eniac.Controles.Label()
        Me.lblEsOferta = New Eniac.Controles.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlMarcas = New System.Windows.Forms.Panel()
        Me.lblMarcas = New Eniac.Controles.Label()
        Me.cmbMarcas = New Eniac.Win.ComboBoxMarcas()
        Me.pnlModelos = New System.Windows.Forms.Panel()
        Me.cmbModelos = New Eniac.Win.ComboBoxModelos()
        Me.lblModelos = New Eniac.Controles.Label()
        Me.pnlRubros = New System.Windows.Forms.Panel()
        Me.cmbRubros = New Eniac.Win.ComboBoxRubro()
        Me.lblRubros = New Eniac.Controles.Label()
        Me.pnlSubRubros = New System.Windows.Forms.Panel()
        Me.cmbSubRubros = New Eniac.Win.ComboBoxSubRubro()
        Me.lblSubRubros = New Eniac.Controles.Label()
        Me.pnlSubSubRubros = New System.Windows.Forms.Panel()
        Me.cmbSubSubRubros = New Eniac.Win.ComboBoxSubSubRubro()
        Me.lblSubSubRubros = New Eniac.Controles.Label()
        Me.chbConPrecio = New Eniac.Controles.CheckBox()
        Me.chbConStock = New Eniac.Controles.CheckBox()
        Me.chbInactivos = New Eniac.Controles.CheckBox()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.cmbSucursales = New Eniac.Win.ComboBoxSucursales()
        Me.pnlCodigoDescripcion = New System.Windows.Forms.FlowLayoutPanel()
        Me.radCodigoYDescripcion = New System.Windows.Forms.RadioButton()
        Me.radCodigoODescripcion = New System.Windows.Forms.RadioButton()
        Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
        Me.lblListaPrecios = New Eniac.Controles.Label()
        Me.lblSucursales = New Eniac.Controles.Label()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.txtCodigo = New Eniac.Controles.TextBox()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.txtProducto = New Eniac.Controles.TextBox()
        Me.chbEmbalaje = New Eniac.Controles.CheckBox()
        Me.chbVerStockDefectuoso = New Eniac.Controles.CheckBox()
        Me.pnlVerStock = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New Eniac.Controles.Label()
        Me.chbVerStockFuturo = New Eniac.Controles.CheckBox()
        Me.chbVerStockFuturoReservado = New Eniac.Controles.CheckBox()
        Me.lblMoneda = New Eniac.Controles.Label()
        Me.ugStockPorSucusal = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbcInformeStock = New System.Windows.Forms.TabControl()
        Me.tbpPrecios = New System.Windows.Forms.TabPage()
        Me.tbpAtributoProducto = New System.Windows.Forms.TabPage()
        Me.ugStockAtributo = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpStockDepositos = New System.Windows.Forms.TabPage()
        Me.lblDetalleProducto = New Eniac.Controles.Label()
        Me.ugStockDepositos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.cmbMoneda = New Eniac.Controles.ComboBox()
        Me.UltraSplitter1 = New Infragistics.Win.Misc.UltraSplitter()
        Me.pnlPrincipalFiltros = New System.Windows.Forms.Panel()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.pnlFlowFiltros.SuspendLayout()
        Me.pnlFiltrosEs.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMarcas.SuspendLayout()
        Me.pnlModelos.SuspendLayout()
        Me.pnlRubros.SuspendLayout()
        Me.pnlSubRubros.SuspendLayout()
        Me.pnlSubSubRubros.SuspendLayout()
        Me.pnlPrincipal.SuspendLayout()
        Me.pnlCodigoDescripcion.SuspendLayout()
        Me.pnlVerStock.SuspendLayout()
        CType(Me.ugStockPorSucusal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcInformeStock.SuspendLayout()
        Me.tbpPrecios.SuspendLayout()
        Me.tbpAtributoProducto.SuspendLayout()
        CType(Me.ugStockAtributo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpStockDepositos.SuspendLayout()
        CType(Me.ugStockDepositos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetalle.SuspendLayout()
        Me.pnlPrincipalFiltros.SuspendLayout()
        Me.SuspendLayout()
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
        Appearance45.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance45
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
        UltraGridColumn10.Header.VisiblePosition = 0
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.Caption = "Sucursal"
        UltraGridColumn11.Header.VisiblePosition = 1
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.Caption = "Producto"
        UltraGridColumn12.Header.VisiblePosition = 2
        UltraGridColumn13.Header.Caption = "Nombre Producto"
        UltraGridColumn13.Header.VisiblePosition = 3
        UltraGridColumn13.Width = 250
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn14.CellAppearance = Appearance2
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.Caption = "IVA"
        UltraGridColumn14.Header.VisiblePosition = 4
        UltraGridColumn14.Width = 43
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn15.CellAppearance = Appearance3
        UltraGridColumn15.Header.Caption = "M."
        UltraGridColumn15.Header.VisiblePosition = 5
        UltraGridColumn15.Width = 28
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance4
        UltraGridColumn16.Format = ""
        UltraGridColumn16.Header.Caption = "Costo s/IVA"
        UltraGridColumn16.Header.VisiblePosition = 6
        UltraGridColumn16.Width = 70
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance5
        UltraGridColumn17.Format = ""
        UltraGridColumn17.Header.Caption = "Costo c/IVA"
        UltraGridColumn17.Header.VisiblePosition = 7
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 70
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance6
        UltraGridColumn18.Format = ""
        UltraGridColumn18.Header.Caption = "Venta s/IVA"
        UltraGridColumn18.Header.VisiblePosition = 12
        UltraGridColumn18.Width = 70
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance7
        UltraGridColumn19.Format = ""
        UltraGridColumn19.Header.Caption = "Venta c/IVA"
        UltraGridColumn19.Header.VisiblePosition = 13
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 70
        UltraGridColumn20.Header.VisiblePosition = 14
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 48
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance8
        UltraGridColumn21.Format = ""
        UltraGridColumn21.Header.Caption = "Embalaje COSTO Sin IVA"
        UltraGridColumn21.Header.VisiblePosition = 15
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 70
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance9
        UltraGridColumn22.Format = ""
        UltraGridColumn22.Header.Caption = "Embalaje COSTO Con IVA"
        UltraGridColumn22.Header.VisiblePosition = 11
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 70
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance10
        UltraGridColumn23.Format = ""
        UltraGridColumn23.Header.Caption = "Embalaje VENTA Sin IVA"
        UltraGridColumn23.Header.VisiblePosition = 16
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 70
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance11
        UltraGridColumn24.Format = ""
        UltraGridColumn24.Header.Caption = "Embalaje VENTA Con IVA"
        UltraGridColumn24.Header.VisiblePosition = 17
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 70
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance12
        UltraGridColumn25.Format = "N2"
        UltraGridColumn25.Header.VisiblePosition = 24
        UltraGridColumn25.Width = 67
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance13
        UltraGridColumn26.Format = "N2"
        UltraGridColumn26.Header.Caption = "Stock Reservado"
        UltraGridColumn26.Header.VisiblePosition = 25
        UltraGridColumn26.Width = 67
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance14
        UltraGridColumn27.Format = "N2"
        UltraGridColumn27.Header.Caption = "Stock Defectuoso"
        UltraGridColumn27.Header.VisiblePosition = 26
        UltraGridColumn27.Width = 67
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance15
        UltraGridColumn28.Format = "N2"
        UltraGridColumn28.Header.Caption = "Stock Futuro"
        UltraGridColumn28.Header.VisiblePosition = 28
        UltraGridColumn28.Width = 67
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance16
        UltraGridColumn29.Format = "N2"
        UltraGridColumn29.Header.Caption = "Stock Futuro Reservado"
        UltraGridColumn29.Header.VisiblePosition = 29
        UltraGridColumn29.Width = 67
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance17
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "Stock Total"
        UltraGridColumn3.Header.VisiblePosition = 22
        UltraGridColumn3.Width = 67
        UltraGridColumn71.Header.Caption = "Marca"
        UltraGridColumn71.Header.VisiblePosition = 18
        UltraGridColumn71.Width = 110
        UltraGridColumn1.Header.Caption = "Modelo"
        UltraGridColumn1.Header.VisiblePosition = 19
        UltraGridColumn1.Width = 110
        UltraGridColumn72.Header.Caption = "Rubro"
        UltraGridColumn72.Header.VisiblePosition = 20
        UltraGridColumn72.Width = 110
        UltraGridColumn73.Header.Caption = "Sub Rubro"
        UltraGridColumn73.Header.VisiblePosition = 21
        UltraGridColumn73.Width = 110
        UltraGridColumn2.Header.Caption = "Sub Sub Rubro"
        UltraGridColumn2.Header.VisiblePosition = 23
        UltraGridColumn2.Width = 110
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn74.CellAppearance = Appearance18
        UltraGridColumn74.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn74.Header.Caption = "Actualizado Venta"
        UltraGridColumn74.Header.VisiblePosition = 34
        UltraGridColumn74.Hidden = True
        UltraGridColumn74.Width = 100
        UltraGridColumn37.Header.VisiblePosition = 49
        UltraGridColumn37.Width = 43
        UltraGridColumn38.Header.Caption = "Codigo De Barras"
        UltraGridColumn38.Header.VisiblePosition = 44
        UltraGridColumn38.Width = 130
        UltraGridColumn39.Header.Caption = "Prov. Ult. Compra"
        UltraGridColumn39.Header.VisiblePosition = 38
        UltraGridColumn39.Width = 124
        Appearance19.TextHAlignAsString = "Center"
        UltraGridColumn40.CellAppearance = Appearance19
        UltraGridColumn40.Header.Caption = "F. Ult. Compra"
        UltraGridColumn40.Header.VisiblePosition = 39
        UltraGridColumn41.Header.Caption = "Proveedor Habitual"
        UltraGridColumn41.Header.VisiblePosition = 40
        UltraGridColumn41.Width = 124
        UltraGridColumn42.Header.Caption = "Cód. Prod. Proveedor"
        UltraGridColumn42.Header.VisiblePosition = 41
        UltraGridColumn42.Width = 125
        UltraGridColumn43.Header.VisiblePosition = 37
        UltraGridColumn43.Width = 120
        UltraGridColumn44.Header.VisiblePosition = 42
        UltraGridColumn44.Hidden = True
        UltraGridColumn45.Header.VisiblePosition = 43
        UltraGridColumn45.Hidden = True
        UltraGridColumn46.Header.VisiblePosition = 45
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.Header.VisiblePosition = 50
        UltraGridColumn47.Hidden = True
        UltraGridColumn48.Header.VisiblePosition = 46
        UltraGridColumn48.Hidden = True
        UltraGridColumn49.Header.VisiblePosition = 47
        UltraGridColumn49.Hidden = True
        UltraGridColumn50.Header.VisiblePosition = 48
        UltraGridColumn50.Hidden = True
        Appearance20.TextHAlignAsString = "Center"
        UltraGridColumn98.CellAppearance = Appearance20
        UltraGridColumn98.Header.Caption = "Oferta"
        UltraGridColumn98.Header.VisiblePosition = 30
        UltraGridColumn98.Hidden = True
        UltraGridColumn98.Width = 43
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn100.CellAppearance = Appearance21
        UltraGridColumn100.Format = "N2"
        UltraGridColumn100.Header.Caption = "Stock Total"
        UltraGridColumn100.Header.VisiblePosition = 27
        UltraGridColumn100.Hidden = True
        UltraGridColumn100.Width = 67
        UltraGridColumn104.Header.VisiblePosition = 51
        UltraGridColumn104.Hidden = True
        UltraGridColumn105.Header.VisiblePosition = 52
        UltraGridColumn105.Hidden = True
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn106.CellAppearance = Appearance22
        UltraGridColumn106.Format = "dd/MM/yyyy"
        UltraGridColumn106.Header.Caption = "Fecha Act. Venta"
        UltraGridColumn106.Header.VisiblePosition = 35
        UltraGridColumn106.Width = 80
        Appearance23.TextHAlignAsString = "Center"
        UltraGridColumn107.CellAppearance = Appearance23
        UltraGridColumn107.Format = "HH:mm"
        UltraGridColumn107.Header.Caption = "Hora Act. Venta"
        UltraGridColumn107.Header.VisiblePosition = 36
        UltraGridColumn107.Width = 50
        Appearance24.TextHAlignAsString = "Center"
        UltraGridColumn108.CellAppearance = Appearance24
        UltraGridColumn108.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn108.Header.Caption = "Actualizacion Costo"
        UltraGridColumn108.Header.VisiblePosition = 31
        UltraGridColumn108.Hidden = True
        UltraGridColumn108.Width = 100
        Appearance25.TextHAlignAsString = "Center"
        UltraGridColumn109.CellAppearance = Appearance25
        UltraGridColumn109.Format = "dd/MM/yyyy"
        UltraGridColumn109.Header.Caption = "Fecha Act. Costo"
        UltraGridColumn109.Header.VisiblePosition = 32
        UltraGridColumn109.Hidden = True
        UltraGridColumn109.Width = 80
        Appearance26.TextHAlignAsString = "Center"
        UltraGridColumn110.CellAppearance = Appearance26
        UltraGridColumn110.Format = "HH:mm"
        UltraGridColumn110.Header.Caption = "Hora Act. Costo"
        UltraGridColumn110.Header.VisiblePosition = 33
        UltraGridColumn110.Hidden = True
        UltraGridColumn110.Width = 50
        UltraGridColumn111.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance27.TextHAlignAsString = "Right"
        UltraGridColumn111.CellAppearance = Appearance27
        UltraGridColumn111.Format = "N2"
        UltraGridColumn111.Header.Caption = "Stock Mínimo"
        UltraGridColumn111.Header.VisiblePosition = 53
        UltraGridColumn111.Width = 75
        UltraGridColumn112.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn112.CellAppearance = Appearance28
        UltraGridColumn112.Format = "N2"
        UltraGridColumn112.Header.Caption = "Stock Máximo"
        UltraGridColumn112.Header.VisiblePosition = 54
        UltraGridColumn112.Width = 70
        UltraGridColumn113.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance29.TextHAlignAsString = "Right"
        UltraGridColumn113.CellAppearance = Appearance29
        UltraGridColumn113.Format = "N2"
        UltraGridColumn113.Header.Caption = "Punto de Pedido"
        UltraGridColumn113.Header.VisiblePosition = 55
        UltraGridColumn113.Width = 79
        Appearance30.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance30
        UltraGridColumn4.Header.Caption = "Pr.Lista s/IVA"
        UltraGridColumn4.Header.VisiblePosition = 9
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 70
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance31
        UltraGridColumn5.Header.Caption = "Pr.Lista c/IVA"
        UltraGridColumn5.Header.VisiblePosition = 10
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 70
        Appearance32.TextHAlignAsString = "Right"
        UltraGridColumn115.CellAppearance = Appearance32
        UltraGridColumn115.Format = "N2"
        UltraGridColumn115.Header.Caption = "%"
        UltraGridColumn115.Header.VisiblePosition = 8
        UltraGridColumn115.Width = 50
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn3, UltraGridColumn71, UltraGridColumn1, UltraGridColumn72, UltraGridColumn73, UltraGridColumn2, UltraGridColumn74, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn98, UltraGridColumn100, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn4, UltraGridColumn5, UltraGridColumn115})
        Appearance33.TextHAlignAsString = "Center"
        UltraGridBand1.Override.HeaderAppearance = Appearance33
        UltraGridBand1.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance34.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance34.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance34.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance34
        Appearance35.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance35
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastrar las columnas aquí para agrupar"
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance36.BackColor2 = System.Drawing.SystemColors.Control
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance36.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance36
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Appearance37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance37
        Appearance38.BackColor = System.Drawing.SystemColors.Highlight
        Appearance38.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance38
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance39.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance39
        Appearance40.BorderColor = System.Drawing.Color.Silver
        Appearance40.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance40
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance41.BackColor = System.Drawing.SystemColors.Control
        Appearance41.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance41.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance41.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance41
        Appearance42.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance42
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Appearance43.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance43
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance44.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance44
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(2, 2)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1011, 240)
        Me.ugDetalle.TabIndex = 0
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'btnBuscar
        '
        Me.btnBuscar.AnchoredControl = Me.ugDetalle
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(912, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(96, 30)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar (F3)"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.BindearPropiedadControl = Nothing
        Me.txtObservaciones.BindearPropiedadEntidad = Nothing
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservaciones.Formato = ""
        Me.txtObservaciones.IsDecimal = False
        Me.txtObservaciones.IsNumber = False
        Me.txtObservaciones.IsPK = False
        Me.txtObservaciones.IsRequired = False
        Me.txtObservaciones.Key = ""
        Me.txtObservaciones.LabelAsoc = Nothing
        Me.txtObservaciones.Location = New System.Drawing.Point(505, 297)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(513, 79)
        Me.txtObservaciones.TabIndex = 9
        Me.txtObservaciones.Text = "{Observaciones}"
        '
        'lblDescRecCantidad
        '
        Me.lblDescRecCantidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescRecCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescRecCantidad.Location = New System.Drawing.Point(5, 297)
        Me.lblDescRecCantidad.Name = "lblDescRecCantidad"
        Me.lblDescRecCantidad.Size = New System.Drawing.Size(263, 79)
        Me.lblDescRecCantidad.TabIndex = 8
        Me.lblDescRecCantidad.Text = "{Descuentos y Recargos por Cantidad}"
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
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(325, 0)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(48, 20)
        Me.txtCotizacionDolar.TabIndex = 3
        Me.txtCotizacionDolar.Text = "0,00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotizacionDolar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(291, 1)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(33, 18)
        Me.lblCotizacionDolar.TabIndex = 2
        Me.lblCotizacionDolar.Text = "Dolar"
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbVerStockReservado
        '
        Me.chbVerStockReservado.AutoSize = True
        Me.chbVerStockReservado.BindearPropiedadControl = Nothing
        Me.chbVerStockReservado.BindearPropiedadEntidad = Nothing
        Me.chbVerStockReservado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVerStockReservado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVerStockReservado.IsPK = False
        Me.chbVerStockReservado.IsRequired = False
        Me.chbVerStockReservado.Key = Nothing
        Me.chbVerStockReservado.LabelAsoc = Nothing
        Me.chbVerStockReservado.Location = New System.Drawing.Point(63, 3)
        Me.chbVerStockReservado.Name = "chbVerStockReservado"
        Me.chbVerStockReservado.Size = New System.Drawing.Size(78, 17)
        Me.chbVerStockReservado.TabIndex = 1
        Me.chbVerStockReservado.Text = "Reservado"
        Me.chbVerStockReservado.UseVisualStyleBackColor = True
        '
        'chbConIVA
        '
        Me.chbConIVA.AutoSize = True
        Me.chbConIVA.BindearPropiedadControl = Nothing
        Me.chbConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConIVA.IsPK = False
        Me.chbConIVA.IsRequired = False
        Me.chbConIVA.Key = Nothing
        Me.chbConIVA.LabelAsoc = Nothing
        Me.chbConIVA.Location = New System.Drawing.Point(945, 2)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 6
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1029, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(950, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.tss2, Me.tsbProductosProveedor, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1029, 29)
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
        'tss1
        '
        Me.tss1.Name = "tss1"
        Me.tss1.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        'tss2
        '
        Me.tss2.Name = "tss2"
        Me.tss2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbProductosProveedor
        '
        Me.tsbProductosProveedor.Image = CType(resources.GetObject("tsbProductosProveedor.Image"), System.Drawing.Image)
        Me.tsbProductosProveedor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbProductosProveedor.Name = "tsbProductosProveedor"
        Me.tsbProductosProveedor.Size = New System.Drawing.Size(192, 26)
        Me.tsbProductosProveedor.Text = "Pr&oductos del Proveedor (F12)"
        Me.tsbProductosProveedor.ToolTipText = "Cerrar el formulario"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'grbConsultar
        '
        Me.grbConsultar.AutoSize = True
        Me.grbConsultar.Controls.Add(Me.pnlFlowFiltros)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbConsultar.Location = New System.Drawing.Point(0, 0)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(1029, 115)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Filtros"
        '
        'pnlFlowFiltros
        '
        Me.pnlFlowFiltros.AutoSize = True
        Me.pnlFlowFiltros.ColumnCount = 2
        Me.pnlFlowFiltros.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 850.0!))
        Me.pnlFlowFiltros.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlFlowFiltros.Controls.Add(Me.pnlFiltrosEs, 1, 0)
        Me.pnlFlowFiltros.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.pnlFlowFiltros.Controls.Add(Me.pnlPrincipal, 0, 0)
        Me.pnlFlowFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFlowFiltros.Location = New System.Drawing.Point(3, 16)
        Me.pnlFlowFiltros.Name = "pnlFlowFiltros"
        Me.pnlFlowFiltros.RowCount = 2
        Me.pnlFlowFiltros.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.pnlFlowFiltros.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlFlowFiltros.Size = New System.Drawing.Size(1023, 96)
        Me.pnlFlowFiltros.TabIndex = 0
        '
        'pnlFiltrosEs
        '
        Me.pnlFiltrosEs.Controls.Add(Me.lblAfectaStock)
        Me.pnlFiltrosEs.Controls.Add(Me.cmbAfectaStock)
        Me.pnlFiltrosEs.Controls.Add(Me.cmbEsDeVentas)
        Me.pnlFiltrosEs.Controls.Add(Me.cmbEsDeCompras)
        Me.pnlFiltrosEs.Controls.Add(Me.lblEsDeCompras)
        Me.pnlFiltrosEs.Controls.Add(Me.cmbEsOferta)
        Me.pnlFiltrosEs.Controls.Add(Me.lblEsDeVentas)
        Me.pnlFiltrosEs.Controls.Add(Me.lblEsOferta)
        Me.pnlFiltrosEs.Location = New System.Drawing.Point(850, 0)
        Me.pnlFiltrosEs.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFiltrosEs.Name = "pnlFiltrosEs"
        Me.pnlFlowFiltros.SetRowSpan(Me.pnlFiltrosEs, 2)
        Me.pnlFiltrosEs.Size = New System.Drawing.Size(173, 96)
        Me.pnlFiltrosEs.TabIndex = 1
        '
        'lblAfectaStock
        '
        Me.lblAfectaStock.LabelAsoc = Nothing
        Me.lblAfectaStock.Location = New System.Drawing.Point(8, 66)
        Me.lblAfectaStock.Name = "lblAfectaStock"
        Me.lblAfectaStock.Size = New System.Drawing.Size(69, 24)
        Me.lblAfectaStock.TabIndex = 21
        Me.lblAfectaStock.Text = "Afecta Stock"
        Me.lblAfectaStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbAfectaStock
        '
        Me.cmbAfectaStock.BindearPropiedadControl = Nothing
        Me.cmbAfectaStock.BindearPropiedadEntidad = Nothing
        Me.cmbAfectaStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaStock.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAfectaStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAfectaStock.FormattingEnabled = True
        Me.cmbAfectaStock.IsPK = False
        Me.cmbAfectaStock.IsRequired = False
        Me.cmbAfectaStock.Key = Nothing
        Me.cmbAfectaStock.LabelAsoc = Me.lblAfectaStock
        Me.cmbAfectaStock.Location = New System.Drawing.Point(83, 69)
        Me.cmbAfectaStock.Name = "cmbAfectaStock"
        Me.cmbAfectaStock.Size = New System.Drawing.Size(70, 21)
        Me.cmbAfectaStock.TabIndex = 22
        '
        'cmbEsDeVentas
        '
        Me.cmbEsDeVentas.BindearPropiedadControl = ""
        Me.cmbEsDeVentas.BindearPropiedadEntidad = ""
        Me.cmbEsDeVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsDeVentas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsDeVentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsDeVentas.FormattingEnabled = True
        Me.cmbEsDeVentas.IsPK = False
        Me.cmbEsDeVentas.IsRequired = False
        Me.cmbEsDeVentas.Items.AddRange(New Object() {"TODOS", "NO", "SI"})
        Me.cmbEsDeVentas.Key = Nothing
        Me.cmbEsDeVentas.LabelAsoc = Nothing
        Me.cmbEsDeVentas.Location = New System.Drawing.Point(83, 0)
        Me.cmbEsDeVentas.Name = "cmbEsDeVentas"
        Me.cmbEsDeVentas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbEsDeVentas.Size = New System.Drawing.Size(70, 21)
        Me.cmbEsDeVentas.TabIndex = 1
        '
        'cmbEsDeCompras
        '
        Me.cmbEsDeCompras.BindearPropiedadControl = ""
        Me.cmbEsDeCompras.BindearPropiedadEntidad = ""
        Me.cmbEsDeCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsDeCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsDeCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsDeCompras.FormattingEnabled = True
        Me.cmbEsDeCompras.IsPK = False
        Me.cmbEsDeCompras.IsRequired = False
        Me.cmbEsDeCompras.Items.AddRange(New Object() {"TODOS", "NO", "SI"})
        Me.cmbEsDeCompras.Key = Nothing
        Me.cmbEsDeCompras.LabelAsoc = Nothing
        Me.cmbEsDeCompras.Location = New System.Drawing.Point(83, 23)
        Me.cmbEsDeCompras.Name = "cmbEsDeCompras"
        Me.cmbEsDeCompras.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbEsDeCompras.Size = New System.Drawing.Size(70, 21)
        Me.cmbEsDeCompras.TabIndex = 3
        '
        'lblEsDeCompras
        '
        Me.lblEsDeCompras.AutoSize = True
        Me.lblEsDeCompras.LabelAsoc = Nothing
        Me.lblEsDeCompras.Location = New System.Drawing.Point(2, 27)
        Me.lblEsDeCompras.Name = "lblEsDeCompras"
        Me.lblEsDeCompras.Size = New System.Drawing.Size(78, 13)
        Me.lblEsDeCompras.TabIndex = 2
        Me.lblEsDeCompras.Text = "Es de Compras"
        '
        'cmbEsOferta
        '
        Me.cmbEsOferta.BindearPropiedadControl = ""
        Me.cmbEsOferta.BindearPropiedadEntidad = ""
        Me.cmbEsOferta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsOferta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsOferta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsOferta.FormattingEnabled = True
        Me.cmbEsOferta.IsPK = False
        Me.cmbEsOferta.IsRequired = False
        Me.cmbEsOferta.Items.AddRange(New Object() {"TODOS", "NO", "SI"})
        Me.cmbEsOferta.Key = Nothing
        Me.cmbEsOferta.LabelAsoc = Nothing
        Me.cmbEsOferta.Location = New System.Drawing.Point(83, 46)
        Me.cmbEsOferta.Name = "cmbEsOferta"
        Me.cmbEsOferta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbEsOferta.Size = New System.Drawing.Size(70, 21)
        Me.cmbEsOferta.TabIndex = 5
        '
        'lblEsDeVentas
        '
        Me.lblEsDeVentas.AutoSize = True
        Me.lblEsDeVentas.LabelAsoc = Nothing
        Me.lblEsDeVentas.Location = New System.Drawing.Point(10, 3)
        Me.lblEsDeVentas.Name = "lblEsDeVentas"
        Me.lblEsDeVentas.Size = New System.Drawing.Size(70, 13)
        Me.lblEsDeVentas.TabIndex = 0
        Me.lblEsDeVentas.Text = "Es de Ventas"
        '
        'lblEsOferta
        '
        Me.lblEsOferta.AutoSize = True
        Me.lblEsOferta.LabelAsoc = Nothing
        Me.lblEsOferta.Location = New System.Drawing.Point(26, 50)
        Me.lblEsOferta.Name = "lblEsOferta"
        Me.lblEsOferta.Size = New System.Drawing.Size(51, 13)
        Me.lblEsOferta.TabIndex = 4
        Me.lblEsOferta.Text = "Es Oferta"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMarcas)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlModelos)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubSubRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.chbConPrecio)
        Me.FlowLayoutPanel1.Controls.Add(Me.chbConStock)
        Me.FlowLayoutPanel1.Controls.Add(Me.chbInactivos)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 44)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(850, 52)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'pnlMarcas
        '
        Me.pnlMarcas.AutoSize = True
        Me.pnlMarcas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlMarcas.Controls.Add(Me.lblMarcas)
        Me.pnlMarcas.Controls.Add(Me.cmbMarcas)
        Me.pnlMarcas.Location = New System.Drawing.Point(3, 0)
        Me.pnlMarcas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlMarcas.Name = "pnlMarcas"
        Me.pnlMarcas.Size = New System.Drawing.Size(248, 21)
        Me.pnlMarcas.TabIndex = 0
        '
        'lblMarcas
        '
        Me.lblMarcas.AutoSize = True
        Me.lblMarcas.LabelAsoc = Nothing
        Me.lblMarcas.Location = New System.Drawing.Point(3, 4)
        Me.lblMarcas.Name = "lblMarcas"
        Me.lblMarcas.Size = New System.Drawing.Size(42, 13)
        Me.lblMarcas.TabIndex = 0
        Me.lblMarcas.Text = "Marcas"
        '
        'cmbMarcas
        '
        Me.cmbMarcas.BindearPropiedadControl = Nothing
        Me.cmbMarcas.BindearPropiedadEntidad = Nothing
        Me.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarcas.FormattingEnabled = True
        Me.cmbMarcas.IsPK = False
        Me.cmbMarcas.IsRequired = False
        Me.cmbMarcas.Key = Nothing
        Me.cmbMarcas.LabelAsoc = Me.lblMarcas
        Me.cmbMarcas.Location = New System.Drawing.Point(48, 0)
        Me.cmbMarcas.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbMarcas.Name = "cmbMarcas"
        Me.cmbMarcas.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarcas.TabIndex = 1
        '
        'pnlModelos
        '
        Me.pnlModelos.AutoSize = True
        Me.pnlModelos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlModelos.Controls.Add(Me.cmbModelos)
        Me.pnlModelos.Controls.Add(Me.lblModelos)
        Me.pnlModelos.Location = New System.Drawing.Point(257, 0)
        Me.pnlModelos.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlModelos.Name = "pnlModelos"
        Me.pnlModelos.Size = New System.Drawing.Size(253, 21)
        Me.pnlModelos.TabIndex = 1
        '
        'cmbModelos
        '
        Me.cmbModelos.BindearPropiedadControl = Nothing
        Me.cmbModelos.BindearPropiedadEntidad = Nothing
        Me.cmbModelos.ConcatenarNombreMarca = False
        Me.cmbModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModelos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModelos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModelos.FormattingEnabled = True
        Me.cmbModelos.IsPK = False
        Me.cmbModelos.IsRequired = False
        Me.cmbModelos.Key = Nothing
        Me.cmbModelos.LabelAsoc = Me.lblModelos
        Me.cmbModelos.Location = New System.Drawing.Point(53, 0)
        Me.cmbModelos.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbModelos.Name = "cmbModelos"
        Me.cmbModelos.Size = New System.Drawing.Size(200, 21)
        Me.cmbModelos.TabIndex = 1
        '
        'lblModelos
        '
        Me.lblModelos.AutoSize = True
        Me.lblModelos.LabelAsoc = Nothing
        Me.lblModelos.Location = New System.Drawing.Point(3, 4)
        Me.lblModelos.Name = "lblModelos"
        Me.lblModelos.Size = New System.Drawing.Size(47, 13)
        Me.lblModelos.TabIndex = 0
        Me.lblModelos.Text = "Modelos"
        '
        'pnlRubros
        '
        Me.pnlRubros.AutoSize = True
        Me.pnlRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlRubros.Controls.Add(Me.cmbRubros)
        Me.pnlRubros.Controls.Add(Me.lblRubros)
        Me.pnlRubros.Location = New System.Drawing.Point(516, 0)
        Me.pnlRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlRubros.Name = "pnlRubros"
        Me.pnlRubros.Size = New System.Drawing.Size(247, 21)
        Me.pnlRubros.TabIndex = 2
        '
        'cmbRubros
        '
        Me.cmbRubros.BindearPropiedadControl = Nothing
        Me.cmbRubros.BindearPropiedadEntidad = Nothing
        Me.cmbRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubros.FormattingEnabled = True
        Me.cmbRubros.IsPK = False
        Me.cmbRubros.IsRequired = False
        Me.cmbRubros.Key = Nothing
        Me.cmbRubros.LabelAsoc = Me.lblRubros
        Me.cmbRubros.Location = New System.Drawing.Point(47, 0)
        Me.cmbRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbRubros.Name = "cmbRubros"
        Me.cmbRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbRubros.TabIndex = 1
        '
        'lblRubros
        '
        Me.lblRubros.AutoSize = True
        Me.lblRubros.LabelAsoc = Nothing
        Me.lblRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblRubros.Name = "lblRubros"
        Me.lblRubros.Size = New System.Drawing.Size(41, 13)
        Me.lblRubros.TabIndex = 0
        Me.lblRubros.Text = "Rubros"
        '
        'pnlSubRubros
        '
        Me.pnlSubRubros.AutoSize = True
        Me.pnlSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSubRubros.Controls.Add(Me.cmbSubRubros)
        Me.pnlSubRubros.Controls.Add(Me.lblSubRubros)
        Me.pnlSubRubros.Location = New System.Drawing.Point(3, 24)
        Me.pnlSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubRubros.Name = "pnlSubRubros"
        Me.pnlSubRubros.Size = New System.Drawing.Size(265, 21)
        Me.pnlSubRubros.TabIndex = 3
        '
        'cmbSubRubros
        '
        Me.cmbSubRubros.BindearPropiedadControl = Nothing
        Me.cmbSubRubros.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubros.ConcatenarNombreRubro = False
        Me.cmbSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubros.FormattingEnabled = True
        Me.cmbSubRubros.IsPK = False
        Me.cmbSubRubros.IsRequired = False
        Me.cmbSubRubros.Key = Nothing
        Me.cmbSubRubros.LabelAsoc = Me.lblSubRubros
        Me.cmbSubRubros.Location = New System.Drawing.Point(65, 0)
        Me.cmbSubRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSubRubros.Name = "cmbSubRubros"
        Me.cmbSubRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubRubros.TabIndex = 1
        '
        'lblSubRubros
        '
        Me.lblSubRubros.AutoSize = True
        Me.lblSubRubros.LabelAsoc = Nothing
        Me.lblSubRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblSubRubros.Name = "lblSubRubros"
        Me.lblSubRubros.Size = New System.Drawing.Size(60, 13)
        Me.lblSubRubros.TabIndex = 0
        Me.lblSubRubros.Text = "SubRubros"
        '
        'pnlSubSubRubros
        '
        Me.pnlSubSubRubros.AutoSize = True
        Me.pnlSubSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSubSubRubros.Controls.Add(Me.cmbSubSubRubros)
        Me.pnlSubSubRubros.Controls.Add(Me.lblSubSubRubros)
        Me.pnlSubSubRubros.Location = New System.Drawing.Point(274, 24)
        Me.pnlSubSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubSubRubros.Name = "pnlSubSubRubros"
        Me.pnlSubSubRubros.Size = New System.Drawing.Size(281, 21)
        Me.pnlSubSubRubros.TabIndex = 4
        '
        'cmbSubSubRubros
        '
        Me.cmbSubSubRubros.BindearPropiedadControl = Nothing
        Me.cmbSubSubRubros.BindearPropiedadEntidad = Nothing
        Me.cmbSubSubRubros.ConcatenarNombreSubRubro = False
        Me.cmbSubSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubSubRubros.FormattingEnabled = True
        Me.cmbSubSubRubros.IsPK = False
        Me.cmbSubSubRubros.IsRequired = False
        Me.cmbSubSubRubros.Key = Nothing
        Me.cmbSubSubRubros.LabelAsoc = Me.lblSubSubRubros
        Me.cmbSubSubRubros.Location = New System.Drawing.Point(81, 0)
        Me.cmbSubSubRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSubSubRubros.Name = "cmbSubSubRubros"
        Me.cmbSubSubRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubSubRubros.TabIndex = 1
        '
        'lblSubSubRubros
        '
        Me.lblSubSubRubros.AutoSize = True
        Me.lblSubSubRubros.LabelAsoc = Nothing
        Me.lblSubSubRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblSubSubRubros.Name = "lblSubSubRubros"
        Me.lblSubSubRubros.Size = New System.Drawing.Size(79, 13)
        Me.lblSubSubRubros.TabIndex = 0
        Me.lblSubSubRubros.Text = "SubSubRubros"
        '
        'chbConPrecio
        '
        Me.chbConPrecio.AutoSize = True
        Me.chbConPrecio.BindearPropiedadControl = Nothing
        Me.chbConPrecio.BindearPropiedadEntidad = Nothing
        Me.chbConPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConPrecio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConPrecio.IsPK = False
        Me.chbConPrecio.IsRequired = False
        Me.chbConPrecio.Key = Nothing
        Me.chbConPrecio.LabelAsoc = Nothing
        Me.chbConPrecio.Location = New System.Drawing.Point(561, 24)
        Me.chbConPrecio.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.chbConPrecio.Name = "chbConPrecio"
        Me.chbConPrecio.Size = New System.Drawing.Size(78, 17)
        Me.chbConPrecio.TabIndex = 5
        Me.chbConPrecio.Text = "Con Precio"
        Me.chbConPrecio.UseVisualStyleBackColor = True
        '
        'chbConStock
        '
        Me.chbConStock.AutoSize = True
        Me.chbConStock.BindearPropiedadControl = Nothing
        Me.chbConStock.BindearPropiedadEntidad = Nothing
        Me.chbConStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConStock.IsPK = False
        Me.chbConStock.IsRequired = False
        Me.chbConStock.Key = Nothing
        Me.chbConStock.LabelAsoc = Nothing
        Me.chbConStock.Location = New System.Drawing.Point(645, 24)
        Me.chbConStock.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.chbConStock.Name = "chbConStock"
        Me.chbConStock.Size = New System.Drawing.Size(76, 17)
        Me.chbConStock.TabIndex = 6
        Me.chbConStock.Text = "Con Stock"
        Me.chbConStock.UseVisualStyleBackColor = True
        '
        'chbInactivos
        '
        Me.chbInactivos.AutoSize = True
        Me.chbInactivos.BindearPropiedadControl = ""
        Me.chbInactivos.BindearPropiedadEntidad = ""
        Me.chbInactivos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbInactivos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbInactivos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbInactivos.IsPK = False
        Me.chbInactivos.IsRequired = False
        Me.chbInactivos.Key = Nothing
        Me.chbInactivos.LabelAsoc = Nothing
        Me.chbInactivos.Location = New System.Drawing.Point(727, 24)
        Me.chbInactivos.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.chbInactivos.Name = "chbInactivos"
        Me.chbInactivos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbInactivos.Size = New System.Drawing.Size(69, 17)
        Me.chbInactivos.TabIndex = 7
        Me.chbInactivos.Text = "Inactivos"
        Me.chbInactivos.UseVisualStyleBackColor = True
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.cmbSucursales)
        Me.pnlPrincipal.Controls.Add(Me.pnlCodigoDescripcion)
        Me.pnlPrincipal.Controls.Add(Me.cmbListaDePrecios)
        Me.pnlPrincipal.Controls.Add(Me.lblListaPrecios)
        Me.pnlPrincipal.Controls.Add(Me.lblSucursales)
        Me.pnlPrincipal.Controls.Add(Me.lblCodigo)
        Me.pnlPrincipal.Controls.Add(Me.txtCodigo)
        Me.pnlPrincipal.Controls.Add(Me.lblProducto)
        Me.pnlPrincipal.Controls.Add(Me.txtProducto)
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(850, 44)
        Me.pnlPrincipal.TabIndex = 0
        '
        'cmbSucursales
        '
        Me.cmbSucursales.BindearPropiedadControl = Nothing
        Me.cmbSucursales.BindearPropiedadEntidad = Nothing
        Me.cmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.IsPK = False
        Me.cmbSucursales.IsRequired = False
        Me.cmbSucursales.Key = Nothing
        Me.cmbSucursales.LabelAsoc = Nothing
        Me.cmbSucursales.Location = New System.Drawing.Point(0, 21)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.Size = New System.Drawing.Size(173, 21)
        Me.cmbSucursales.TabIndex = 1
        '
        'pnlCodigoDescripcion
        '
        Me.pnlCodigoDescripcion.Controls.Add(Me.radCodigoYDescripcion)
        Me.pnlCodigoDescripcion.Controls.Add(Me.radCodigoODescripcion)
        Me.pnlCodigoDescripcion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlCodigoDescripcion.Location = New System.Drawing.Point(358, 0)
        Me.pnlCodigoDescripcion.Name = "pnlCodigoDescripcion"
        Me.pnlCodigoDescripcion.Size = New System.Drawing.Size(260, 18)
        Me.pnlCodigoDescripcion.TabIndex = 5
        Me.pnlCodigoDescripcion.TabStop = True
        '
        'radCodigoYDescripcion
        '
        Me.radCodigoYDescripcion.AutoSize = True
        Me.radCodigoYDescripcion.Checked = True
        Me.radCodigoYDescripcion.Location = New System.Drawing.Point(3, 3)
        Me.radCodigoYDescripcion.Name = "radCodigoYDescripcion"
        Me.radCodigoYDescripcion.Size = New System.Drawing.Size(127, 17)
        Me.radCodigoYDescripcion.TabIndex = 0
        Me.radCodigoYDescripcion.TabStop = True
        Me.radCodigoYDescripcion.Text = "Código Y Descripción"
        Me.radCodigoYDescripcion.UseVisualStyleBackColor = True
        '
        'radCodigoODescripcion
        '
        Me.radCodigoODescripcion.AutoSize = True
        Me.radCodigoODescripcion.Location = New System.Drawing.Point(136, 3)
        Me.radCodigoODescripcion.Name = "radCodigoODescripcion"
        Me.radCodigoODescripcion.Size = New System.Drawing.Size(128, 17)
        Me.radCodigoODescripcion.TabIndex = 1
        Me.radCodigoODescripcion.Text = "Código O Descripción"
        Me.radCodigoODescripcion.UseVisualStyleBackColor = True
        '
        'cmbListaDePrecios
        '
        Me.cmbListaDePrecios.BindearPropiedadControl = Nothing
        Me.cmbListaDePrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaDePrecios.FormattingEnabled = True
        Me.cmbListaDePrecios.IsPK = False
        Me.cmbListaDePrecios.IsRequired = False
        Me.cmbListaDePrecios.Key = Nothing
        Me.cmbListaDePrecios.LabelAsoc = Me.lblListaPrecios
        Me.cmbListaDePrecios.Location = New System.Drawing.Point(624, 21)
        Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
        Me.cmbListaDePrecios.Size = New System.Drawing.Size(194, 21)
        Me.cmbListaDePrecios.TabIndex = 8
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.LabelAsoc = Nothing
        Me.lblListaPrecios.Location = New System.Drawing.Point(624, 6)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 7
        Me.lblListaPrecios.Text = "Lista de Precios"
        '
        'lblSucursales
        '
        Me.lblSucursales.AutoSize = True
        Me.lblSucursales.LabelAsoc = Nothing
        Me.lblSucursales.Location = New System.Drawing.Point(0, 6)
        Me.lblSucursales.Name = "lblSucursales"
        Me.lblSucursales.Size = New System.Drawing.Size(59, 13)
        Me.lblSucursales.TabIndex = 0
        Me.lblSucursales.Text = "Sucursales"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(176, 6)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 1
        Me.lblCodigo.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = Nothing
        Me.txtCodigo.BindearPropiedadEntidad = Nothing
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = False
        Me.txtCodigo.IsPK = False
        Me.txtCodigo.IsRequired = False
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(179, 21)
        Me.txtCodigo.MaxLength = 50
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(115, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(297, 6)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 3
        Me.lblProducto.Text = "Producto"
        '
        'txtProducto
        '
        Me.txtProducto.BindearPropiedadControl = Nothing
        Me.txtProducto.BindearPropiedadEntidad = Nothing
        Me.txtProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProducto.Formato = ""
        Me.txtProducto.IsDecimal = False
        Me.txtProducto.IsNumber = False
        Me.txtProducto.IsPK = False
        Me.txtProducto.IsRequired = False
        Me.txtProducto.Key = ""
        Me.txtProducto.LabelAsoc = Me.lblProducto
        Me.txtProducto.Location = New System.Drawing.Point(300, 21)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(318, 20)
        Me.txtProducto.TabIndex = 4
        '
        'chbEmbalaje
        '
        Me.chbEmbalaje.AutoSize = True
        Me.chbEmbalaje.BindearPropiedadControl = Nothing
        Me.chbEmbalaje.BindearPropiedadEntidad = Nothing
        Me.chbEmbalaje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmbalaje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmbalaje.IsPK = False
        Me.chbEmbalaje.IsRequired = False
        Me.chbEmbalaje.Key = Nothing
        Me.chbEmbalaje.LabelAsoc = Nothing
        Me.chbEmbalaje.Location = New System.Drawing.Point(800, 2)
        Me.chbEmbalaje.Name = "chbEmbalaje"
        Me.chbEmbalaje.Size = New System.Drawing.Size(120, 17)
        Me.chbEmbalaje.TabIndex = 5
        Me.chbEmbalaje.Text = "Precio por Embalaje"
        Me.chbEmbalaje.UseVisualStyleBackColor = True
        '
        'chbVerStockDefectuoso
        '
        Me.chbVerStockDefectuoso.AutoSize = True
        Me.chbVerStockDefectuoso.BindearPropiedadControl = Nothing
        Me.chbVerStockDefectuoso.BindearPropiedadEntidad = Nothing
        Me.chbVerStockDefectuoso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVerStockDefectuoso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVerStockDefectuoso.IsPK = False
        Me.chbVerStockDefectuoso.IsRequired = False
        Me.chbVerStockDefectuoso.Key = Nothing
        Me.chbVerStockDefectuoso.LabelAsoc = Nothing
        Me.chbVerStockDefectuoso.Location = New System.Drawing.Point(147, 3)
        Me.chbVerStockDefectuoso.Name = "chbVerStockDefectuoso"
        Me.chbVerStockDefectuoso.Size = New System.Drawing.Size(81, 17)
        Me.chbVerStockDefectuoso.TabIndex = 2
        Me.chbVerStockDefectuoso.Text = "Defectuoso"
        Me.chbVerStockDefectuoso.UseVisualStyleBackColor = True
        '
        'pnlVerStock
        '
        Me.pnlVerStock.Controls.Add(Me.Label3)
        Me.pnlVerStock.Controls.Add(Me.chbVerStockReservado)
        Me.pnlVerStock.Controls.Add(Me.chbVerStockDefectuoso)
        Me.pnlVerStock.Controls.Add(Me.chbVerStockFuturo)
        Me.pnlVerStock.Controls.Add(Me.chbVerStockFuturoReservado)
        Me.pnlVerStock.Location = New System.Drawing.Point(379, 0)
        Me.pnlVerStock.Name = "pnlVerStock"
        Me.pnlVerStock.Size = New System.Drawing.Size(415, 20)
        Me.pnlVerStock.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ver Stock"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbVerStockFuturo
        '
        Me.chbVerStockFuturo.AutoSize = True
        Me.chbVerStockFuturo.BindearPropiedadControl = Nothing
        Me.chbVerStockFuturo.BindearPropiedadEntidad = Nothing
        Me.chbVerStockFuturo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVerStockFuturo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVerStockFuturo.IsPK = False
        Me.chbVerStockFuturo.IsRequired = False
        Me.chbVerStockFuturo.Key = Nothing
        Me.chbVerStockFuturo.LabelAsoc = Nothing
        Me.chbVerStockFuturo.Location = New System.Drawing.Point(234, 3)
        Me.chbVerStockFuturo.Name = "chbVerStockFuturo"
        Me.chbVerStockFuturo.Size = New System.Drawing.Size(56, 17)
        Me.chbVerStockFuturo.TabIndex = 3
        Me.chbVerStockFuturo.Text = "Futuro"
        Me.chbVerStockFuturo.UseVisualStyleBackColor = True
        '
        'chbVerStockFuturoReservado
        '
        Me.chbVerStockFuturoReservado.AutoSize = True
        Me.chbVerStockFuturoReservado.BindearPropiedadControl = Nothing
        Me.chbVerStockFuturoReservado.BindearPropiedadEntidad = Nothing
        Me.chbVerStockFuturoReservado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVerStockFuturoReservado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVerStockFuturoReservado.IsPK = False
        Me.chbVerStockFuturoReservado.IsRequired = False
        Me.chbVerStockFuturoReservado.Key = Nothing
        Me.chbVerStockFuturoReservado.LabelAsoc = Nothing
        Me.chbVerStockFuturoReservado.Location = New System.Drawing.Point(296, 3)
        Me.chbVerStockFuturoReservado.Name = "chbVerStockFuturoReservado"
        Me.chbVerStockFuturoReservado.Size = New System.Drawing.Size(111, 17)
        Me.chbVerStockFuturoReservado.TabIndex = 4
        Me.chbVerStockFuturoReservado.Text = "Futuro Reservado"
        Me.chbVerStockFuturoReservado.UseVisualStyleBackColor = True
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.LabelAsoc = Nothing
        Me.lblMoneda.Location = New System.Drawing.Point(11, 4)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(139, 13)
        Me.lblMoneda.TabIndex = 0
        Me.lblMoneda.Text = "Precio Utilizando la Moneda"
        '
        'ugStockPorSucusal
        '
        Me.ugStockPorSucusal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugStockPorSucusal.DisplayLayout.Appearance = Appearance46
        UltraGridColumn117.Header.VisiblePosition = 0
        UltraGridColumn117.Hidden = True
        UltraGridColumn118.Header.Caption = "Sucursal"
        UltraGridColumn118.Header.VisiblePosition = 1
        UltraGridColumn118.Width = 140
        Appearance47.TextHAlignAsString = "Right"
        UltraGridColumn119.CellAppearance = Appearance47
        UltraGridColumn119.Format = "N2"
        UltraGridColumn119.Header.VisiblePosition = 2
        UltraGridColumn119.Width = 70
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn117, UltraGridColumn118, UltraGridColumn119})
        Appearance48.TextHAlignAsString = "Center"
        UltraGridBand2.Override.HeaderAppearance = Appearance48
        UltraGridBand2.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugStockPorSucusal.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugStockPorSucusal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugStockPorSucusal.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance49.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance49.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockPorSucusal.DisplayLayout.GroupByBox.Appearance = Appearance49
        Appearance50.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockPorSucusal.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance50
        Me.ugStockPorSucusal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugStockPorSucusal.DisplayLayout.GroupByBox.Hidden = True
        Me.ugStockPorSucusal.DisplayLayout.GroupByBox.Prompt = "Arrastrar las columnas aquí para agrupar"
        Appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance51.BackColor2 = System.Drawing.SystemColors.Control
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockPorSucusal.DisplayLayout.GroupByBox.PromptAppearance = Appearance51
        Me.ugStockPorSucusal.DisplayLayout.MaxColScrollRegions = 1
        Me.ugStockPorSucusal.DisplayLayout.MaxRowScrollRegions = 1
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Appearance52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugStockPorSucusal.DisplayLayout.Override.ActiveCellAppearance = Appearance52
        Appearance53.BackColor = System.Drawing.SystemColors.Highlight
        Appearance53.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugStockPorSucusal.DisplayLayout.Override.ActiveRowAppearance = Appearance53
        Me.ugStockPorSucusal.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockPorSucusal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugStockPorSucusal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance54.BackColor = System.Drawing.SystemColors.Window
        Me.ugStockPorSucusal.DisplayLayout.Override.CardAreaAppearance = Appearance54
        Appearance55.BorderColor = System.Drawing.Color.Silver
        Appearance55.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugStockPorSucusal.DisplayLayout.Override.CellAppearance = Appearance55
        Me.ugStockPorSucusal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugStockPorSucusal.DisplayLayout.Override.CellPadding = 0
        Appearance56.BackColor = System.Drawing.SystemColors.Control
        Appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance56.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance56.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockPorSucusal.DisplayLayout.Override.GroupByRowAppearance = Appearance56
        Appearance57.TextHAlignAsString = "Left"
        Me.ugStockPorSucusal.DisplayLayout.Override.HeaderAppearance = Appearance57
        Me.ugStockPorSucusal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugStockPorSucusal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Appearance58.BorderColor = System.Drawing.Color.Silver
        Me.ugStockPorSucusal.DisplayLayout.Override.RowAppearance = Appearance58
        Me.ugStockPorSucusal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance59.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugStockPorSucusal.DisplayLayout.Override.TemplateAddRowAppearance = Appearance59
        Me.ugStockPorSucusal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugStockPorSucusal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugStockPorSucusal.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugStockPorSucusal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugStockPorSucusal.Location = New System.Drawing.Point(266, 295)
        Me.ugStockPorSucusal.Name = "ugStockPorSucusal"
        Me.ugStockPorSucusal.Size = New System.Drawing.Size(241, 81)
        Me.ugStockPorSucusal.TabIndex = 10
        Me.ugStockPorSucusal.Text = "UltraGrid1"
        '
        'tbcInformeStock
        '
        Me.tbcInformeStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcInformeStock.Controls.Add(Me.tbpPrecios)
        Me.tbcInformeStock.Controls.Add(Me.tbpAtributoProducto)
        Me.tbcInformeStock.Controls.Add(Me.tbpStockDepositos)
        Me.tbcInformeStock.Location = New System.Drawing.Point(4, 22)
        Me.tbcInformeStock.Margin = New System.Windows.Forms.Padding(2)
        Me.tbcInformeStock.Name = "tbcInformeStock"
        Me.tbcInformeStock.Padding = New System.Drawing.Point(0, 0)
        Me.tbcInformeStock.SelectedIndex = 0
        Me.tbcInformeStock.Size = New System.Drawing.Size(1023, 270)
        Me.tbcInformeStock.TabIndex = 7
        '
        'tbpPrecios
        '
        Me.tbpPrecios.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPrecios.Controls.Add(Me.btnBuscar)
        Me.tbpPrecios.Controls.Add(Me.ugDetalle)
        Me.tbpPrecios.Location = New System.Drawing.Point(4, 22)
        Me.tbpPrecios.Margin = New System.Windows.Forms.Padding(2)
        Me.tbpPrecios.Name = "tbpPrecios"
        Me.tbpPrecios.Padding = New System.Windows.Forms.Padding(2)
        Me.tbpPrecios.Size = New System.Drawing.Size(1015, 244)
        Me.tbpPrecios.TabIndex = 1
        Me.tbpPrecios.Text = "Precios"
        '
        'tbpAtributoProducto
        '
        Me.tbpAtributoProducto.BackColor = System.Drawing.Color.Transparent
        Me.tbpAtributoProducto.Controls.Add(Me.ugStockAtributo)
        Me.tbpAtributoProducto.Location = New System.Drawing.Point(4, 22)
        Me.tbpAtributoProducto.Name = "tbpAtributoProducto"
        Me.tbpAtributoProducto.Size = New System.Drawing.Size(1015, 244)
        Me.tbpAtributoProducto.TabIndex = 2
        Me.tbpAtributoProducto.Text = "-"
        Me.tbpAtributoProducto.UseVisualStyleBackColor = True
        '
        'ugStockAtributo
        '
        Me.ugStockAtributo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance60.BackColor = System.Drawing.SystemColors.Window
        Appearance60.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugStockAtributo.DisplayLayout.Appearance = Appearance60
        Me.ugStockAtributo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugStockAtributo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance61.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance61.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance61.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockAtributo.DisplayLayout.GroupByBox.Appearance = Appearance61
        Appearance62.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockAtributo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance62
        Me.ugStockAtributo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugStockAtributo.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance63.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance63.BackColor2 = System.Drawing.SystemColors.Control
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance63.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockAtributo.DisplayLayout.GroupByBox.PromptAppearance = Appearance63
        Me.ugStockAtributo.DisplayLayout.MaxColScrollRegions = 1
        Me.ugStockAtributo.DisplayLayout.MaxRowScrollRegions = 1
        Appearance64.BackColor = System.Drawing.SystemColors.Window
        Appearance64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugStockAtributo.DisplayLayout.Override.ActiveCellAppearance = Appearance64
        Appearance65.BackColor = System.Drawing.SystemColors.Highlight
        Appearance65.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugStockAtributo.DisplayLayout.Override.ActiveRowAppearance = Appearance65
        Me.ugStockAtributo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugStockAtributo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockAtributo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugStockAtributo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance66.BackColor = System.Drawing.SystemColors.Window
        Me.ugStockAtributo.DisplayLayout.Override.CardAreaAppearance = Appearance66
        Appearance67.BorderColor = System.Drawing.Color.Silver
        Appearance67.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugStockAtributo.DisplayLayout.Override.CellAppearance = Appearance67
        Me.ugStockAtributo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugStockAtributo.DisplayLayout.Override.CellPadding = 0
        Appearance68.BackColor = System.Drawing.SystemColors.Control
        Appearance68.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance68.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance68.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockAtributo.DisplayLayout.Override.GroupByRowAppearance = Appearance68
        Appearance69.TextHAlignAsString = "Left"
        Me.ugStockAtributo.DisplayLayout.Override.HeaderAppearance = Appearance69
        Me.ugStockAtributo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugStockAtributo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Appearance70.BorderColor = System.Drawing.Color.Silver
        Me.ugStockAtributo.DisplayLayout.Override.RowAppearance = Appearance70
        Me.ugStockAtributo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockAtributo.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance71.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugStockAtributo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance71
        Me.ugStockAtributo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugStockAtributo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugStockAtributo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugStockAtributo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugStockAtributo.Location = New System.Drawing.Point(3, 3)
        Me.ugStockAtributo.Name = "ugStockAtributo"
        Me.ugStockAtributo.Size = New System.Drawing.Size(993, 361)
        Me.ugStockAtributo.TabIndex = 89
        '
        'tbpStockDepositos
        '
        Me.tbpStockDepositos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpStockDepositos.Controls.Add(Me.lblDetalleProducto)
        Me.tbpStockDepositos.Controls.Add(Me.ugStockDepositos)
        Me.tbpStockDepositos.Location = New System.Drawing.Point(4, 22)
        Me.tbpStockDepositos.Name = "tbpStockDepositos"
        Me.tbpStockDepositos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpStockDepositos.Size = New System.Drawing.Size(1015, 244)
        Me.tbpStockDepositos.TabIndex = 3
        Me.tbpStockDepositos.Text = "Stock x Deposito"
        '
        'lblDetalleProducto
        '
        Me.lblDetalleProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetalleProducto.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblDetalleProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalleProducto.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDetalleProducto.LabelAsoc = Nothing
        Me.lblDetalleProducto.Location = New System.Drawing.Point(592, 16)
        Me.lblDetalleProducto.Name = "lblDetalleProducto"
        Me.lblDetalleProducto.Size = New System.Drawing.Size(390, 13)
        Me.lblDetalleProducto.TabIndex = 14
        Me.lblDetalleProducto.Text = "Producto XX"
        Me.lblDetalleProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ugStockDepositos
        '
        Appearance72.BackColor = System.Drawing.SystemColors.Window
        Appearance72.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugStockDepositos.DisplayLayout.Appearance = Appearance72
        Me.ugStockDepositos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn120.Header.VisiblePosition = 0
        UltraGridColumn120.Hidden = True
        UltraGridColumn120.Width = 104
        UltraGridColumn121.Header.Caption = "Sucursal"
        UltraGridColumn121.Header.VisiblePosition = 1
        UltraGridColumn121.Width = 175
        UltraGridColumn122.Header.VisiblePosition = 2
        UltraGridColumn122.Hidden = True
        UltraGridColumn122.Width = 118
        UltraGridColumn123.Header.Caption = "Deposito"
        UltraGridColumn123.Header.VisiblePosition = 4
        UltraGridColumn123.Width = 171
        UltraGridColumn124.Header.VisiblePosition = 6
        UltraGridColumn124.Hidden = True
        UltraGridColumn124.Width = 133
        UltraGridColumn125.Header.Caption = "Ubicacion"
        UltraGridColumn125.Header.VisiblePosition = 7
        UltraGridColumn125.Width = 181
        Appearance73.TextHAlignAsString = "Right"
        Appearance73.TextVAlignAsString = "Middle"
        UltraGridColumn126.CellAppearance = Appearance73
        UltraGridColumn126.Header.VisiblePosition = 8
        UltraGridColumn126.Width = 155
        UltraGridColumn127.Header.VisiblePosition = 9
        UltraGridColumn127.Hidden = True
        UltraGridColumn127.Width = 153
        UltraGridColumn128.Header.Caption = "Tipo Deposito"
        UltraGridColumn128.Header.VisiblePosition = 5
        UltraGridColumn128.Width = 152
        UltraGridColumn130.Header.Caption = "Codigo Deposito"
        UltraGridColumn130.Header.VisiblePosition = 3
        UltraGridColumn130.Width = 173
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn120, UltraGridColumn121, UltraGridColumn122, UltraGridColumn123, UltraGridColumn124, UltraGridColumn125, UltraGridColumn126, UltraGridColumn127, UltraGridColumn128, UltraGridColumn130})
        Me.ugStockDepositos.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugStockDepositos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugStockDepositos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance74.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance74.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance74.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockDepositos.DisplayLayout.GroupByBox.Appearance = Appearance74
        Appearance75.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockDepositos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance75
        Me.ugStockDepositos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance76.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance76.BackColor2 = System.Drawing.SystemColors.Control
        Appearance76.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance76.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockDepositos.DisplayLayout.GroupByBox.PromptAppearance = Appearance76
        Me.ugStockDepositos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugStockDepositos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance77.BackColor = System.Drawing.SystemColors.Window
        Appearance77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugStockDepositos.DisplayLayout.Override.ActiveCellAppearance = Appearance77
        Appearance78.BackColor = System.Drawing.SystemColors.Highlight
        Appearance78.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugStockDepositos.DisplayLayout.Override.ActiveRowAppearance = Appearance78
        Me.ugStockDepositos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugStockDepositos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockDepositos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockDepositos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugStockDepositos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance79.BackColor = System.Drawing.SystemColors.Window
        Me.ugStockDepositos.DisplayLayout.Override.CardAreaAppearance = Appearance79
        Appearance80.BorderColor = System.Drawing.Color.Silver
        Appearance80.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugStockDepositos.DisplayLayout.Override.CellAppearance = Appearance80
        Me.ugStockDepositos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugStockDepositos.DisplayLayout.Override.CellPadding = 0
        Appearance81.BackColor = System.Drawing.SystemColors.Control
        Appearance81.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance81.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance81.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockDepositos.DisplayLayout.Override.GroupByRowAppearance = Appearance81
        Appearance82.TextHAlignAsString = "Left"
        Me.ugStockDepositos.DisplayLayout.Override.HeaderAppearance = Appearance82
        Me.ugStockDepositos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugStockDepositos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance83.BackColor = System.Drawing.SystemColors.Window
        Appearance83.BorderColor = System.Drawing.Color.Silver
        Me.ugStockDepositos.DisplayLayout.Override.RowAppearance = Appearance83
        Me.ugStockDepositos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance84.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugStockDepositos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance84
        Me.ugStockDepositos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugStockDepositos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugStockDepositos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugStockDepositos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugStockDepositos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugStockDepositos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ugStockDepositos.Location = New System.Drawing.Point(3, 3)
        Me.ugStockDepositos.Name = "ugStockDepositos"
        Me.ugStockDepositos.Size = New System.Drawing.Size(1009, 238)
        Me.ugStockDepositos.TabIndex = 12
        Me.ugStockDepositos.Text = "UltraGrid1"
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Controls.Add(Me.tbcInformeStock)
        Me.pnlDetalle.Controls.Add(Me.ugStockPorSucusal)
        Me.pnlDetalle.Controls.Add(Me.cmbMoneda)
        Me.pnlDetalle.Controls.Add(Me.lblMoneda)
        Me.pnlDetalle.Controls.Add(Me.pnlVerStock)
        Me.pnlDetalle.Controls.Add(Me.chbEmbalaje)
        Me.pnlDetalle.Controls.Add(Me.txtObservaciones)
        Me.pnlDetalle.Controls.Add(Me.lblDescRecCantidad)
        Me.pnlDetalle.Controls.Add(Me.txtCotizacionDolar)
        Me.pnlDetalle.Controls.Add(Me.lblCotizacionDolar)
        Me.pnlDetalle.Controls.Add(Me.chbConIVA)
        Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetalle.Location = New System.Drawing.Point(0, 159)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(1029, 380)
        Me.pnlDetalle.TabIndex = 1
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
        Me.cmbMoneda.Items.AddRange(New Object() {"del producto", "del producto"})
        Me.cmbMoneda.Key = Nothing
        Me.cmbMoneda.LabelAsoc = Me.lblMoneda
        Me.cmbMoneda.Location = New System.Drawing.Point(164, 1)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(127, 21)
        Me.cmbMoneda.TabIndex = 15
        '
        'UltraSplitter1
        '
        Me.UltraSplitter1.BackColor = System.Drawing.SystemColors.Control
        Me.UltraSplitter1.ButtonExtent = 350
        Me.UltraSplitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraSplitter1.Location = New System.Drawing.Point(0, 144)
        Me.UltraSplitter1.MinSize = 60
        Me.UltraSplitter1.Name = "UltraSplitter1"
        Me.UltraSplitter1.RestoreExtent = 115
        Me.UltraSplitter1.Size = New System.Drawing.Size(1029, 15)
        Me.UltraSplitter1.TabIndex = 4
        '
        'pnlPrincipalFiltros
        '
        Me.pnlPrincipalFiltros.Controls.Add(Me.grbConsultar)
        Me.pnlPrincipalFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrincipalFiltros.Location = New System.Drawing.Point(0, 29)
        Me.pnlPrincipalFiltros.Name = "pnlPrincipalFiltros"
        Me.pnlPrincipalFiltros.Size = New System.Drawing.Size(1029, 115)
        Me.pnlPrincipalFiltros.TabIndex = 0
        '
        'ConsultarPrecios
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 561)
        Me.Controls.Add(Me.pnlDetalle)
        Me.Controls.Add(Me.UltraSplitter1)
        Me.Controls.Add(Me.pnlPrincipalFiltros)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ConsultarPrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Precios"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.pnlFlowFiltros.ResumeLayout(False)
        Me.pnlFlowFiltros.PerformLayout()
        Me.pnlFiltrosEs.ResumeLayout(False)
        Me.pnlFiltrosEs.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.pnlMarcas.ResumeLayout(False)
        Me.pnlMarcas.PerformLayout()
        Me.pnlModelos.ResumeLayout(False)
        Me.pnlModelos.PerformLayout()
        Me.pnlRubros.ResumeLayout(False)
        Me.pnlRubros.PerformLayout()
        Me.pnlSubRubros.ResumeLayout(False)
        Me.pnlSubRubros.PerformLayout()
        Me.pnlSubSubRubros.ResumeLayout(False)
        Me.pnlSubSubRubros.PerformLayout()
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlPrincipal.PerformLayout()
        Me.pnlCodigoDescripcion.ResumeLayout(False)
        Me.pnlCodigoDescripcion.PerformLayout()
        Me.pnlVerStock.ResumeLayout(False)
        Me.pnlVerStock.PerformLayout()
        CType(Me.ugStockPorSucusal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcInformeStock.ResumeLayout(False)
        Me.tbpPrecios.ResumeLayout(False)
        Me.tbpAtributoProducto.ResumeLayout(False)
        CType(Me.ugStockAtributo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpStockDepositos.ResumeLayout(False)
        CType(Me.ugStockDepositos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        Me.pnlPrincipalFiltros.ResumeLayout(False)
        Me.pnlPrincipalFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents txtProducto As Eniac.Controles.TextBox
   Friend WithEvents btnBuscar As ButtonConsultar
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblSucursales As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents lblListaPrecios As Eniac.Controles.Label
   Friend WithEvents chbConStock As Eniac.Controles.CheckBox
   Friend WithEvents chbConPrecio As Eniac.Controles.CheckBox
   Friend WithEvents chbInactivos As Eniac.Controles.CheckBox
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents txtCotizacionDolar As Eniac.Controles.TextBox
   Friend WithEvents lblCotizacionDolar As Eniac.Controles.Label
   Friend WithEvents chbEmbalaje As Eniac.Controles.CheckBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbProductosProveedor As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbEsOferta As Eniac.Controles.ComboBox
   Friend WithEvents lblEsOferta As Eniac.Controles.Label
   Friend WithEvents chbVerStockReservado As Eniac.Controles.CheckBox
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents lblDescRecCantidad As System.Windows.Forms.Label
   Friend WithEvents txtObservaciones As Eniac.Controles.TextBox
   Friend WithEvents cmbEsDeVentas As Eniac.Controles.ComboBox
   Friend WithEvents lblEsDeVentas As Eniac.Controles.Label
   Friend WithEvents cmbEsDeCompras As Eniac.Controles.ComboBox
   Friend WithEvents lblEsDeCompras As Eniac.Controles.Label
   Friend WithEvents chbVerStockDefectuoso As Eniac.Controles.CheckBox
   Friend WithEvents pnlVerStock As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents chbVerStockFuturo As Eniac.Controles.CheckBox
   Friend WithEvents chbVerStockFuturoReservado As Eniac.Controles.CheckBox
   Friend WithEvents pnlCodigoDescripcion As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents radCodigoYDescripcion As System.Windows.Forms.RadioButton
   Friend WithEvents radCodigoODescripcion As System.Windows.Forms.RadioButton
   Friend WithEvents cmbMoneda As Eniac.Controles.ComboBox
   Friend WithEvents lblMoneda As Eniac.Controles.Label
   Friend WithEvents ugStockPorSucusal As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tbcInformeStock As TabControl
    Friend WithEvents tbpPrecios As TabPage
    Friend WithEvents tbpAtributoProducto As TabPage
    Friend WithEvents ugStockAtributo As UltraGrid
    Friend WithEvents pnlDetalle As Panel
    Friend WithEvents cmbSucursales As ComboBoxSucursales
    Friend WithEvents pnlMarcas As Panel
    Friend WithEvents lblMarcas As Controles.Label
    Friend WithEvents cmbMarcas As ComboBoxMarcas
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents pnlRubros As Panel
    Friend WithEvents cmbRubros As ComboBoxRubro
    Friend WithEvents lblRubros As Controles.Label
    Friend WithEvents pnlSubRubros As Panel
   Friend WithEvents cmbSubRubros As ComboBoxSubRubro
   Friend WithEvents lblSubRubros As Controles.Label
    Friend WithEvents pnlSubSubRubros As Panel
   Friend WithEvents cmbSubSubRubros As ComboBoxSubSubRubro
   Friend WithEvents lblSubSubRubros As Controles.Label
    Friend WithEvents pnlModelos As Panel
   Friend WithEvents cmbModelos As ComboBoxModelos
   Friend WithEvents lblModelos As Controles.Label
   Friend WithEvents pnlFlowFiltros As TableLayoutPanel
   Friend WithEvents pnlFiltrosEs As Panel
   Friend WithEvents pnlPrincipal As Panel
   Friend WithEvents UltraSplitter1 As Misc.UltraSplitter
   Friend WithEvents pnlPrincipalFiltros As Panel
    Friend WithEvents tbpStockDepositos As TabPage
    Friend WithEvents ugStockDepositos As UltraGrid
    Friend WithEvents lblDetalleProducto As Controles.Label
    Friend WithEvents lblAfectaStock As Controles.Label
    Friend WithEvents cmbAfectaStock As Controles.ComboBox
End Class
