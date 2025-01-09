<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EnvioDeOrdenesDeCompra
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
      Dim UltraDataBand1 As Infragistics.Win.UltraWinDataSource.UltraDataBand = New Infragistics.Win.UltraWinDataSource.UltraDataBand("Detalle")
      Dim UltraDataBand2 As Infragistics.Win.UltraWinDataSource.UltraDataBand = New Infragistics.Win.UltraWinDataSource.UltraDataBand("Comprobante")
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCaja")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroPlanilla")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroMovimiento")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImportePesos")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotal")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdPedido")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaPedido")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocumento")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocumento")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProveedor")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("idProducto")
      Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Tamano")
      Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
      Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("fechaEstado")
      Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("idEstado")
      Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantEstado")
      Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantPendiente")
      Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
      Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
      Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
      Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
      Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUsuario")
      Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
      Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Imprimir")
      Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCriticidad")
      Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaEntrega")
      Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdPedido")
      Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaPedido")
      Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocumento")
      Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescripcionAbrev")
      Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocumento")
      Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProveedor")
      Dim UltraDataColumn38 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdPeriodo")
      Dim UltraDataColumn39 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
      Dim UltraDataColumn40 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvioDeOrdenesDeCompra))
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Cabecera", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcPendiente")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcPendienteImporte")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaReprogEntrega")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAutorizacion")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("acti")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CorreoElectronico")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Envio")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestos")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteBruto")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Metodo")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaReprogEnvio")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadContactos", 0)
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VerCabecera", 1)
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dif", 2)
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dif1", 3)
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dif2", 4)
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Envios", 5)
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NoEnv", 6)
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("ImporteTotal", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "ImporteTotal", 13, True, "Cabecera", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "ImporteTotal", 13, True)
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.chbFechaEnvio = New Eniac.Controles.CheckBox()
        Me.txtNroHasta = New Eniac.Controles.TextBox()
        Me.dtpFechaEnviohasta = New Eniac.Controles.DateTimePicker()
        Me.Label6 = New Eniac.Controles.Label()
        Me.dtpFechaEnvioDesde = New Eniac.Controles.DateTimePicker()
        Me.Label7 = New Eniac.Controles.Label()
        Me.cmbCorreoEnviado = New Eniac.Controles.ComboBox()
        Me.lblCorreoEnviado = New Eniac.Controles.Label()
        Me.dtpFechaAutorizacionHasta = New Eniac.Controles.DateTimePicker()
        Me.Label14 = New Eniac.Controles.Label()
        Me.dtpFechaAutorizacionDesde = New Eniac.Controles.DateTimePicker()
        Me.Label15 = New Eniac.Controles.Label()
        Me.chbFechaAutorizacion = New Eniac.Controles.CheckBox()
        Me.txtMaxRango = New Eniac.Controles.TextBox()
        Me.txtMinRango = New Eniac.Controles.TextBox()
        Me.chbIdPedido = New Eniac.Controles.CheckBox()
        Me.txtNroDesde = New Eniac.Controles.TextBox()
        Me.chbRangoImporte = New Eniac.Controles.CheckBox()
        Me.dtpFechaEntregaHasta = New Eniac.Controles.DateTimePicker()
        Me.Label2 = New Eniac.Controles.Label()
        Me.dtpFechaEntregaDesde = New Eniac.Controles.DateTimePicker()
        Me.Label3 = New Eniac.Controles.Label()
        Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.cmbEstados = New Eniac.Controles.ComboBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.Label4 = New Eniac.Controles.Label()
        Me.Label5 = New Eniac.Controles.Label()
        Me.cmbActivadas = New Eniac.Controles.ComboBox()
        Me.Label10 = New Eniac.Controles.Label()
        Me.Label9 = New Eniac.Controles.Label()
        Me.chbMesCompletoFechaEnvio = New Eniac.Controles.CheckBox()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEnviarFacturas = New System.Windows.Forms.ToolStripButton()
        Me.tsbCorreoPrueba = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbVerErroresEnvio = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblCantidadDeErrores = New System.Windows.Forms.Label()
        Me.btnNoEnviar = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpOC = New System.Windows.Forms.TabPage()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpConfig = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMailCuerpo = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New Eniac.Controles.Label()
        Me.btnExaminar4 = New Eniac.Controles.Button()
        Me.txtArchivo4 = New Eniac.Controles.TextBox()
        Me.lblArchivo4 = New Eniac.Controles.Label()
        Me.txtCopiaOculta = New Eniac.Controles.TextBox()
        Me.btnExaminar3 = New Eniac.Controles.Button()
        Me.txtArchivo3 = New Eniac.Controles.TextBox()
        Me.lblArchivo3 = New Eniac.Controles.Label()
        Me.btnExaminar2 = New Eniac.Controles.Button()
        Me.txtArchivo2 = New Eniac.Controles.TextBox()
        Me.lblArchivo2 = New Eniac.Controles.Label()
        Me.btnExpandirHtml = New Eniac.Controles.Button()
        Me.btnExaminar1 = New Eniac.Controles.Button()
        Me.txtArchivo1 = New Eniac.Controles.TextBox()
        Me.lblArchivo1 = New Eniac.Controles.Label()
        Me.lblCuerpo = New Eniac.Controles.Label()
        Me.rtbCuerpoMail = New MSDN.Html.Editor.HtmlEditorControl()
        Me.chbOcultarFiltros = New Eniac.Controles.CheckBox()
        Me.sspPie = New System.Windows.Forms.StatusStrip()
        Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.chbReprogramadas = New Eniac.Controles.CheckBox()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbConsultar.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbpOC.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpConfig.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.sspPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource1
        '
        UltraDataBand2.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7})
        UltraDataBand1.ChildBands.AddRange(New Object() {UltraDataBand2})
        UltraDataColumn30.DataType = GetType(Date)
        UltraDataBand1.Columns.AddRange(New Object() {UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27, UltraDataColumn28, UltraDataColumn29, UltraDataColumn30})
        Me.UltraDataSource1.Band.ChildBands.AddRange(New Object() {UltraDataBand1})
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35, UltraDataColumn36, UltraDataColumn37, UltraDataColumn38, UltraDataColumn39, UltraDataColumn40})
        Me.UltraDataSource1.Band.Key = "Cabecera"
        '
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.chbReprogramadas)
        Me.grbConsultar.Controls.Add(Me.chbFechaEnvio)
        Me.grbConsultar.Controls.Add(Me.txtNroHasta)
        Me.grbConsultar.Controls.Add(Me.dtpFechaEnviohasta)
        Me.grbConsultar.Controls.Add(Me.dtpFechaEnvioDesde)
        Me.grbConsultar.Controls.Add(Me.Label6)
        Me.grbConsultar.Controls.Add(Me.Label7)
        Me.grbConsultar.Controls.Add(Me.cmbCorreoEnviado)
        Me.grbConsultar.Controls.Add(Me.lblCorreoEnviado)
        Me.grbConsultar.Controls.Add(Me.dtpFechaAutorizacionHasta)
        Me.grbConsultar.Controls.Add(Me.dtpFechaAutorizacionDesde)
        Me.grbConsultar.Controls.Add(Me.Label14)
        Me.grbConsultar.Controls.Add(Me.Label15)
        Me.grbConsultar.Controls.Add(Me.chbFechaAutorizacion)
        Me.grbConsultar.Controls.Add(Me.txtMaxRango)
        Me.grbConsultar.Controls.Add(Me.txtMinRango)
        Me.grbConsultar.Controls.Add(Me.chbIdPedido)
        Me.grbConsultar.Controls.Add(Me.txtNroDesde)
        Me.grbConsultar.Controls.Add(Me.chbRangoImporte)
        Me.grbConsultar.Controls.Add(Me.dtpFechaEntregaHasta)
        Me.grbConsultar.Controls.Add(Me.dtpFechaEntregaDesde)
        Me.grbConsultar.Controls.Add(Me.Label2)
        Me.grbConsultar.Controls.Add(Me.Label3)
        Me.grbConsultar.Controls.Add(Me.chbFechaEntrega)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.chbFecha)
        Me.grbConsultar.Controls.Add(Me.cmbEstados)
        Me.grbConsultar.Controls.Add(Me.chkExpandAll)
        Me.grbConsultar.Controls.Add(Me.chbUsuario)
        Me.grbConsultar.Controls.Add(Me.cmbUsuario)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.bscProveedor)
        Me.grbConsultar.Controls.Add(Me.chbProveedor)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Controls.Add(Me.Label4)
        Me.grbConsultar.Controls.Add(Me.Label5)
        Me.grbConsultar.Controls.Add(Me.cmbActivadas)
        Me.grbConsultar.Controls.Add(Me.Label10)
        Me.grbConsultar.Controls.Add(Me.Label9)
        Me.grbConsultar.Controls.Add(Me.chbMesCompletoFechaEnvio)
        Me.grbConsultar.Controls.Add(Me.lblEstado)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbConsultar.Location = New System.Drawing.Point(0, 0)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(1071, 148)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'chbFechaEnvio
        '
        Me.chbFechaEnvio.AutoSize = True
        Me.chbFechaEnvio.BindearPropiedadControl = Nothing
        Me.chbFechaEnvio.BindearPropiedadEntidad = Nothing
        Me.chbFechaEnvio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEnvio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEnvio.IsPK = False
        Me.chbFechaEnvio.IsRequired = False
        Me.chbFechaEnvio.Key = Nothing
        Me.chbFechaEnvio.LabelAsoc = Nothing
        Me.chbFechaEnvio.Location = New System.Drawing.Point(212, 17)
        Me.chbFechaEnvio.Name = "chbFechaEnvio"
        Me.chbFechaEnvio.Size = New System.Drawing.Size(88, 17)
        Me.chbFechaEnvio.TabIndex = 60
        Me.chbFechaEnvio.Text = "Fecha Envío"
        Me.chbFechaEnvio.UseVisualStyleBackColor = True
        '
        'txtNroHasta
        '
        Me.txtNroHasta.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroHasta.BindearPropiedadControl = Nothing
        Me.txtNroHasta.BindearPropiedadEntidad = Nothing
        Me.txtNroHasta.Enabled = False
        Me.txtNroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroHasta.Formato = ""
        Me.txtNroHasta.IsDecimal = False
        Me.txtNroHasta.IsNumber = True
        Me.txtNroHasta.IsPK = False
        Me.txtNroHasta.IsRequired = False
        Me.txtNroHasta.Key = ""
        Me.txtNroHasta.LabelAsoc = Nothing
        Me.txtNroHasta.Location = New System.Drawing.Point(881, 45)
        Me.txtNroHasta.MaxLength = 8
        Me.txtNroHasta.Name = "txtNroHasta"
        Me.txtNroHasta.Size = New System.Drawing.Size(65, 20)
        Me.txtNroHasta.TabIndex = 11
        Me.txtNroHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFechaEnviohasta
        '
        Me.dtpFechaEnviohasta.BindearPropiedadControl = Nothing
        Me.dtpFechaEnviohasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEnviohasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaEnviohasta.Enabled = False
        Me.dtpFechaEnviohasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEnviohasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEnviohasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEnviohasta.IsPK = False
        Me.dtpFechaEnviohasta.IsRequired = False
        Me.dtpFechaEnviohasta.Key = ""
        Me.dtpFechaEnviohasta.LabelAsoc = Me.Label6
        Me.dtpFechaEnviohasta.Location = New System.Drawing.Point(570, 15)
        Me.dtpFechaEnviohasta.Name = "dtpFechaEnviohasta"
        Me.dtpFechaEnviohasta.Size = New System.Drawing.Size(126, 20)
        Me.dtpFechaEnviohasta.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(535, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Hasta"
        '
        'dtpFechaEnvioDesde
        '
        Me.dtpFechaEnvioDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaEnvioDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEnvioDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaEnvioDesde.Enabled = False
        Me.dtpFechaEnvioDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEnvioDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEnvioDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEnvioDesde.IsPK = False
        Me.dtpFechaEnvioDesde.IsRequired = False
        Me.dtpFechaEnvioDesde.Key = ""
        Me.dtpFechaEnvioDesde.LabelAsoc = Me.Label7
        Me.dtpFechaEnvioDesde.Location = New System.Drawing.Point(398, 15)
        Me.dtpFechaEnvioDesde.Name = "dtpFechaEnvioDesde"
        Me.dtpFechaEnvioDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaEnvioDesde.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(354, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Desde"
        '
        'cmbCorreoEnviado
        '
        Me.cmbCorreoEnviado.BindearPropiedadControl = ""
        Me.cmbCorreoEnviado.BindearPropiedadEntidad = ""
        Me.cmbCorreoEnviado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorreoEnviado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCorreoEnviado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCorreoEnviado.FormattingEnabled = True
        Me.cmbCorreoEnviado.IsPK = False
        Me.cmbCorreoEnviado.IsRequired = True
        Me.cmbCorreoEnviado.Key = Nothing
        Me.cmbCorreoEnviado.LabelAsoc = Me.lblCorreoEnviado
        Me.cmbCorreoEnviado.Location = New System.Drawing.Point(83, 15)
        Me.cmbCorreoEnviado.Name = "cmbCorreoEnviado"
        Me.cmbCorreoEnviado.Size = New System.Drawing.Size(118, 21)
        Me.cmbCorreoEnviado.TabIndex = 0
        '
        'lblCorreoEnviado
        '
        Me.lblCorreoEnviado.AutoSize = True
        Me.lblCorreoEnviado.LabelAsoc = Nothing
        Me.lblCorreoEnviado.Location = New System.Drawing.Point(29, 18)
        Me.lblCorreoEnviado.Name = "lblCorreoEnviado"
        Me.lblCorreoEnviado.Size = New System.Drawing.Size(46, 13)
        Me.lblCorreoEnviado.TabIndex = 51
        Me.lblCorreoEnviado.Text = "Enviado"
        '
        'dtpFechaAutorizacionHasta
        '
        Me.dtpFechaAutorizacionHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaAutorizacionHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAutorizacionHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaAutorizacionHasta.Enabled = False
        Me.dtpFechaAutorizacionHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAutorizacionHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAutorizacionHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaAutorizacionHasta.IsPK = False
        Me.dtpFechaAutorizacionHasta.IsRequired = False
        Me.dtpFechaAutorizacionHasta.Key = ""
        Me.dtpFechaAutorizacionHasta.LabelAsoc = Me.Label14
        Me.dtpFechaAutorizacionHasta.Location = New System.Drawing.Point(332, 118)
        Me.dtpFechaAutorizacionHasta.Name = "dtpFechaAutorizacionHasta"
        Me.dtpFechaAutorizacionHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpFechaAutorizacionHasta.TabIndex = 23
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.LabelAsoc = Nothing
        Me.Label14.Location = New System.Drawing.Point(291, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Hasta"
        '
        'dtpFechaAutorizacionDesde
        '
        Me.dtpFechaAutorizacionDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaAutorizacionDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAutorizacionDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaAutorizacionDesde.Enabled = False
        Me.dtpFechaAutorizacionDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAutorizacionDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAutorizacionDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaAutorizacionDesde.IsPK = False
        Me.dtpFechaAutorizacionDesde.IsRequired = False
        Me.dtpFechaAutorizacionDesde.Key = ""
        Me.dtpFechaAutorizacionDesde.LabelAsoc = Me.Label15
        Me.dtpFechaAutorizacionDesde.Location = New System.Drawing.Point(160, 118)
        Me.dtpFechaAutorizacionDesde.Name = "dtpFechaAutorizacionDesde"
        Me.dtpFechaAutorizacionDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpFechaAutorizacionDesde.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.LabelAsoc = Nothing
        Me.Label15.Location = New System.Drawing.Point(123, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Desde"
        '
        'chbFechaAutorizacion
        '
        Me.chbFechaAutorizacion.AutoSize = True
        Me.chbFechaAutorizacion.BindearPropiedadControl = Nothing
        Me.chbFechaAutorizacion.BindearPropiedadEntidad = Nothing
        Me.chbFechaAutorizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaAutorizacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaAutorizacion.IsPK = False
        Me.chbFechaAutorizacion.IsRequired = False
        Me.chbFechaAutorizacion.Key = Nothing
        Me.chbFechaAutorizacion.LabelAsoc = Nothing
        Me.chbFechaAutorizacion.Location = New System.Drawing.Point(13, 121)
        Me.chbFechaAutorizacion.Name = "chbFechaAutorizacion"
        Me.chbFechaAutorizacion.Size = New System.Drawing.Size(117, 17)
        Me.chbFechaAutorizacion.TabIndex = 20
        Me.chbFechaAutorizacion.Text = "Fecha Autorización"
        Me.chbFechaAutorizacion.UseVisualStyleBackColor = True
        '
        'txtMaxRango
        '
        Me.txtMaxRango.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaxRango.BindearPropiedadControl = Nothing
        Me.txtMaxRango.BindearPropiedadEntidad = Nothing
        Me.txtMaxRango.Enabled = False
        Me.txtMaxRango.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMaxRango.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMaxRango.Formato = "N2"
        Me.txtMaxRango.IsDecimal = True
        Me.txtMaxRango.IsNumber = True
        Me.txtMaxRango.IsPK = False
        Me.txtMaxRango.IsRequired = False
        Me.txtMaxRango.Key = ""
        Me.txtMaxRango.LabelAsoc = Nothing
        Me.txtMaxRango.Location = New System.Drawing.Point(741, 91)
        Me.txtMaxRango.MaxLength = 8
        Me.txtMaxRango.Name = "txtMaxRango"
        Me.txtMaxRango.Size = New System.Drawing.Size(81, 20)
        Me.txtMaxRango.TabIndex = 26
        Me.txtMaxRango.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinRango
        '
        Me.txtMinRango.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinRango.BindearPropiedadControl = Nothing
        Me.txtMinRango.BindearPropiedadEntidad = Nothing
        Me.txtMinRango.Enabled = False
        Me.txtMinRango.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMinRango.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMinRango.Formato = "N2"
        Me.txtMinRango.IsDecimal = True
        Me.txtMinRango.IsNumber = True
        Me.txtMinRango.IsPK = False
        Me.txtMinRango.IsRequired = False
        Me.txtMinRango.Key = ""
        Me.txtMinRango.LabelAsoc = Nothing
        Me.txtMinRango.Location = New System.Drawing.Point(617, 90)
        Me.txtMinRango.MaxLength = 8
        Me.txtMinRango.Name = "txtMinRango"
        Me.txtMinRango.Size = New System.Drawing.Size(81, 20)
        Me.txtMinRango.TabIndex = 25
        Me.txtMinRango.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbIdPedido
        '
        Me.chbIdPedido.AutoSize = True
        Me.chbIdPedido.BindearPropiedadControl = Nothing
        Me.chbIdPedido.BindearPropiedadEntidad = Nothing
        Me.chbIdPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIdPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIdPedido.IsPK = False
        Me.chbIdPedido.IsRequired = False
        Me.chbIdPedido.Key = Nothing
        Me.chbIdPedido.LabelAsoc = Nothing
        Me.chbIdPedido.Location = New System.Drawing.Point(682, 46)
        Me.chbIdPedido.Name = "chbIdPedido"
        Me.chbIdPedido.Size = New System.Drawing.Size(63, 17)
        Me.chbIdPedido.TabIndex = 9
        Me.chbIdPedido.Text = "Número"
        Me.chbIdPedido.UseVisualStyleBackColor = True
        '
        'txtNroDesde
        '
        Me.txtNroDesde.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroDesde.BindearPropiedadControl = Nothing
        Me.txtNroDesde.BindearPropiedadEntidad = Nothing
        Me.txtNroDesde.Enabled = False
        Me.txtNroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDesde.Formato = ""
        Me.txtNroDesde.IsDecimal = False
        Me.txtNroDesde.IsNumber = True
        Me.txtNroDesde.IsPK = False
        Me.txtNroDesde.IsRequired = False
        Me.txtNroDesde.Key = ""
        Me.txtNroDesde.LabelAsoc = Nothing
        Me.txtNroDesde.Location = New System.Drawing.Point(779, 45)
        Me.txtNroDesde.MaxLength = 8
        Me.txtNroDesde.Name = "txtNroDesde"
        Me.txtNroDesde.Size = New System.Drawing.Size(65, 20)
        Me.txtNroDesde.TabIndex = 10
        Me.txtNroDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbRangoImporte
        '
        Me.chbRangoImporte.AutoSize = True
        Me.chbRangoImporte.BindearPropiedadControl = Nothing
        Me.chbRangoImporte.BindearPropiedadEntidad = Nothing
        Me.chbRangoImporte.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRangoImporte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRangoImporte.IsPK = False
        Me.chbRangoImporte.IsRequired = False
        Me.chbRangoImporte.Key = Nothing
        Me.chbRangoImporte.LabelAsoc = Nothing
        Me.chbRangoImporte.Location = New System.Drawing.Point(477, 94)
        Me.chbRangoImporte.Name = "chbRangoImporte"
        Me.chbRangoImporte.Size = New System.Drawing.Size(96, 17)
        Me.chbRangoImporte.TabIndex = 24
        Me.chbRangoImporte.Text = "Rango Importe"
        Me.chbRangoImporte.UseVisualStyleBackColor = True
        '
        'dtpFechaEntregaHasta
        '
        Me.dtpFechaEntregaHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaEntregaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntregaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaEntregaHasta.Enabled = False
        Me.dtpFechaEntregaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntregaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntregaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntregaHasta.IsPK = False
        Me.dtpFechaEntregaHasta.IsRequired = False
        Me.dtpFechaEntregaHasta.Key = ""
        Me.dtpFechaEntregaHasta.LabelAsoc = Me.Label2
        Me.dtpFechaEntregaHasta.Location = New System.Drawing.Point(332, 92)
        Me.dtpFechaEntregaHasta.Name = "dtpFechaEntregaHasta"
        Me.dtpFechaEntregaHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpFechaEntregaHasta.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(291, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Hasta"
        '
        'dtpFechaEntregaDesde
        '
        Me.dtpFechaEntregaDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaEntregaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntregaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaEntregaDesde.Enabled = False
        Me.dtpFechaEntregaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntregaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntregaDesde.IsPK = False
        Me.dtpFechaEntregaDesde.IsRequired = False
        Me.dtpFechaEntregaDesde.Key = ""
        Me.dtpFechaEntregaDesde.LabelAsoc = Me.Label3
        Me.dtpFechaEntregaDesde.Location = New System.Drawing.Point(160, 92)
        Me.dtpFechaEntregaDesde.Name = "dtpFechaEntregaDesde"
        Me.dtpFechaEntregaDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpFechaEntregaDesde.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(123, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Desde"
        '
        'chbFechaEntrega
        '
        Me.chbFechaEntrega.AutoSize = True
        Me.chbFechaEntrega.BindearPropiedadControl = Nothing
        Me.chbFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.chbFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEntrega.IsPK = False
        Me.chbFechaEntrega.IsRequired = False
        Me.chbFechaEntrega.Key = Nothing
        Me.chbFechaEntrega.LabelAsoc = Nothing
        Me.chbFechaEntrega.Location = New System.Drawing.Point(13, 95)
        Me.chbFechaEntrega.Name = "chbFechaEntrega"
        Me.chbFechaEntrega.Size = New System.Drawing.Size(96, 17)
        Me.chbFechaEntrega.TabIndex = 16
        Me.chbFechaEntrega.Text = "Fecha Entrega"
        Me.chbFechaEntrega.UseVisualStyleBackColor = True
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(779, 14)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(140, 21)
        Me.cmbTiposComprobantes.TabIndex = 3
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(706, 17)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(76, 13)
        Me.lblTipoComprobante.TabIndex = 8
        Me.lblTipoComprobante.Text = "Tipo Comprob."
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
        Me.chbFecha.Location = New System.Drawing.Point(12, 70)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 12
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'cmbEstados
        '
        Me.cmbEstados.BindearPropiedadControl = ""
        Me.cmbEstados.BindearPropiedadEntidad = ""
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.IsPK = False
        Me.cmbEstados.IsRequired = False
        Me.cmbEstados.Key = Nothing
        Me.cmbEstados.LabelAsoc = Me.lblEstado
        Me.cmbEstados.Location = New System.Drawing.Point(83, 42)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(169, 21)
        Me.cmbEstados.TabIndex = 5
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(4, 48)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(80, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Estado Artículo"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(949, 124)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 24
        Me.chkExpandAll.Text = "Expandir Grupos"
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
        Me.chbUsuario.Location = New System.Drawing.Point(476, 121)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 19
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        Me.chbUsuario.Visible = False
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
        Me.cmbUsuario.Location = New System.Drawing.Point(544, 119)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(140, 21)
        Me.cmbUsuario.TabIndex = 27
        Me.cmbUsuario.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(946, 72)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(104, 45)
        Me.btnConsultar.TabIndex = 23
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.AyudaAncho = 608
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
        Me.bscCodigoProveedor.ColumnasAncho = Nothing
        Me.bscCodigoProveedor.ColumnasFormato = Nothing
        Me.bscCodigoProveedor.ColumnasOcultas = Nothing
        Me.bscCodigoProveedor.ColumnasTitulos = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.Enabled = False
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(336, 44)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 7
        Me.bscCodigoProveedor.Titulo = Nothing
        '
        'bscProveedor
        '
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.AyudaAncho = 608
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ColumnasAlineacion = Nothing
        Me.bscProveedor.ColumnasAncho = Nothing
        Me.bscProveedor.ColumnasFormato = Nothing
        Me.bscProveedor.ColumnasOcultas = Nothing
        Me.bscProveedor.ColumnasTitulos = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.Enabled = False
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Nothing
        Me.bscProveedor.Location = New System.Drawing.Point(433, 44)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(242, 23)
        Me.bscProveedor.TabIndex = 8
        Me.bscProveedor.Titulo = Nothing
        '
        'chbProveedor
        '
        Me.chbProveedor.AutoSize = True
        Me.chbProveedor.BindearPropiedadControl = Nothing
        Me.chbProveedor.BindearPropiedadEntidad = Nothing
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Location = New System.Drawing.Point(261, 46)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 6
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(74, 71)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompleto.TabIndex = 3
        Me.chkMesCompleto.Text = "Mes C."
        Me.chkMesCompleto.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(355, 68)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 15
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(314, 72)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 6
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
        Me.dtpDesde.Location = New System.Drawing.Point(177, 68)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 14
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(133, 72)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 13
        Me.lblDesde.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(574, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Mínimo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(700, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Máximo"
        '
        'cmbActivadas
        '
        Me.cmbActivadas.BindearPropiedadControl = ""
        Me.cmbActivadas.BindearPropiedadEntidad = ""
        Me.cmbActivadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActivadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActivadas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActivadas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActivadas.FormattingEnabled = True
        Me.cmbActivadas.IsPK = False
        Me.cmbActivadas.IsRequired = False
        Me.cmbActivadas.Items.AddRange(New Object() {"SI", "NO", "TODAS"})
        Me.cmbActivadas.Key = Nothing
        Me.cmbActivadas.LabelAsoc = Nothing
        Me.cmbActivadas.Location = New System.Drawing.Point(81, 42)
        Me.cmbActivadas.Name = "cmbActivadas"
        Me.cmbActivadas.Size = New System.Drawing.Size(93, 21)
        Me.cmbActivadas.TabIndex = 26
        Me.cmbActivadas.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.LabelAsoc = Nothing
        Me.Label10.Location = New System.Drawing.Point(847, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.LabelAsoc = Nothing
        Me.Label9.Location = New System.Drawing.Point(743, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "Desde"
        '
        'chbMesCompletoFechaEnvio
        '
        Me.chbMesCompletoFechaEnvio.AutoSize = True
        Me.chbMesCompletoFechaEnvio.BindearPropiedadControl = Nothing
        Me.chbMesCompletoFechaEnvio.BindearPropiedadEntidad = Nothing
        Me.chbMesCompletoFechaEnvio.Enabled = False
        Me.chbMesCompletoFechaEnvio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMesCompletoFechaEnvio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMesCompletoFechaEnvio.IsPK = False
        Me.chbMesCompletoFechaEnvio.IsRequired = False
        Me.chbMesCompletoFechaEnvio.Key = Nothing
        Me.chbMesCompletoFechaEnvio.LabelAsoc = Nothing
        Me.chbMesCompletoFechaEnvio.Location = New System.Drawing.Point(300, 18)
        Me.chbMesCompletoFechaEnvio.Name = "chbMesCompletoFechaEnvio"
        Me.chbMesCompletoFechaEnvio.Size = New System.Drawing.Size(59, 17)
        Me.chbMesCompletoFechaEnvio.TabIndex = 61
        Me.chbMesCompletoFechaEnvio.Text = "Mes C."
        Me.chbMesCompletoFechaEnvio.UseVisualStyleBackColor = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(128, 20)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 58
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridExcelExporter1
        '
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbEnviarFacturas, Me.tsbCorreoPrueba, Me.tsbImprimir, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbVerErroresEnvio, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1095, 29)
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
        'tsbEnviarFacturas
        '
        Me.tsbEnviarFacturas.Enabled = False
        Me.tsbEnviarFacturas.ForeColor = System.Drawing.Color.ForestGreen
        Me.tsbEnviarFacturas.Image = Global.Eniac.Win.My.Resources.Resources.mail_next_32
        Me.tsbEnviarFacturas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarFacturas.Name = "tsbEnviarFacturas"
        Me.tsbEnviarFacturas.Size = New System.Drawing.Size(65, 26)
        Me.tsbEnviarFacturas.Text = "Enviar"
        Me.tsbEnviarFacturas.Visible = False
        '
        'tsbCorreoPrueba
        '
        Me.tsbCorreoPrueba.Image = Global.Eniac.Win.My.Resources.Resources.mail_server
        Me.tsbCorreoPrueba.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCorreoPrueba.Name = "tsbCorreoPrueba"
        Me.tsbCorreoPrueba.Size = New System.Drawing.Size(125, 26)
        Me.tsbCorreoPrueba.Text = "C&orreo de Prueba"
        Me.tsbCorreoPrueba.ToolTipText = "Cerrar el formulario"
        Me.tsbCorreoPrueba.Visible = False
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        Me.tsbImprimir.Visible = False
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
        'tsbVerErroresEnvio
        '
        Me.tsbVerErroresEnvio.Image = Global.Eniac.Win.My.Resources.Resources.mail_config_32
        Me.tsbVerErroresEnvio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVerErroresEnvio.Name = "tsbVerErroresEnvio"
        Me.tsbVerErroresEnvio.Size = New System.Drawing.Size(136, 26)
        Me.tsbVerErroresEnvio.Text = "Ver Errores de Envío"
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
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 50)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grbConsultar)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1071, 486)
        Me.SplitContainer1.SplitterDistance = 148
        Me.SplitContainer1.TabIndex = 46
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1071, 334)
        Me.SplitContainer2.SplitterDistance = 55
        Me.SplitContainer2.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblCantidadDeErrores)
        Me.GroupBox2.Controls.Add(Me.btnNoEnviar)
        Me.GroupBox2.Controls.Add(Me.btnEnviar)
        Me.GroupBox2.Controls.Add(Me.btnTodos)
        Me.GroupBox2.Controls.Add(Me.cmbTodos)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1071, 55)
        Me.GroupBox2.TabIndex = 61
        Me.GroupBox2.TabStop = False
        '
        'lblCantidadDeErrores
        '
        Me.lblCantidadDeErrores.AutoSize = True
        Me.lblCantidadDeErrores.ForeColor = System.Drawing.Color.Red
        Me.lblCantidadDeErrores.Location = New System.Drawing.Point(764, 26)
        Me.lblCantidadDeErrores.Name = "lblCantidadDeErrores"
        Me.lblCantidadDeErrores.Size = New System.Drawing.Size(0, 13)
        Me.lblCantidadDeErrores.TabIndex = 61
        Me.lblCantidadDeErrores.Visible = False
        '
        'btnNoEnviar
        '
        Me.btnNoEnviar.Image = Global.Eniac.Win.My.Resources.Resources.cancel_32
        Me.btnNoEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNoEnviar.Location = New System.Drawing.Point(336, 14)
        Me.btnNoEnviar.Name = "btnNoEnviar"
        Me.btnNoEnviar.Size = New System.Drawing.Size(92, 36)
        Me.btnNoEnviar.TabIndex = 60
        Me.btnNoEnviar.Text = "No Enviar"
        Me.btnNoEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNoEnviar.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Image = Global.Eniac.Win.My.Resources.Resources.mail_next_32
        Me.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviar.Location = New System.Drawing.Point(232, 14)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(83, 36)
        Me.btnEnviar.TabIndex = 59
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviar.UseVisualStyleBackColor = True
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
        Me.cmbTodos.Location = New System.Drawing.Point(12, 21)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(110, 21)
        Me.cmbTodos.TabIndex = 57
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpOC)
        Me.TabControl1.Controls.Add(Me.tbpConfig)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1071, 275)
        Me.TabControl1.TabIndex = 6
        '
        'tbpOC
        '
        Me.tbpOC.Controls.Add(Me.ugDetalle)
        Me.tbpOC.Location = New System.Drawing.Point(4, 22)
        Me.tbpOC.Name = "tbpOC"
        Me.tbpOC.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOC.Size = New System.Drawing.Size(1063, 249)
        Me.tbpOC.TabIndex = 0
        Me.tbpOC.Text = "Ordenes de Compra"
        Me.tbpOC.UseVisualStyleBackColor = True
        '
        'ugDetalle
        '
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance2
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn1.Header.Caption = "Sucursal"
        UltraGridColumn1.Header.VisiblePosition = 3
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.Header.Caption = "Tipo"
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 70
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn3.Header.Caption = "Tipo"
        UltraGridColumn3.Header.VisiblePosition = 5
        UltraGridColumn3.Width = 45
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn4.Header.Caption = "L."
        UltraGridColumn4.Header.VisiblePosition = 6
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 25
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "Emisor"
        UltraGridColumn5.Header.VisiblePosition = 7
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 50
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance4
        UltraGridColumn6.Header.Caption = "Orden Compra"
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridColumn6.Width = 51
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance5
        UltraGridColumn7.Format = "dd/MM/yyyy"
        UltraGridColumn7.Header.Caption = "Fecha Emisión (FEmi)"
        UltraGridColumn7.Header.VisiblePosition = 14
        UltraGridColumn7.Width = 80
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.Header.VisiblePosition = 22
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn9.Header.Caption = "Cod. Proveedor"
        UltraGridColumn9.Header.VisiblePosition = 23
        UltraGridColumn9.Width = 62
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn10.Header.Caption = "Razón Social Proveedor"
        UltraGridColumn10.Header.VisiblePosition = 24
        UltraGridColumn10.Width = 182
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn11.Header.Caption = "Observación"
        UltraGridColumn11.Header.VisiblePosition = 33
        UltraGridColumn11.Width = 250
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn12.Header.VisiblePosition = 32
        UltraGridColumn12.Width = 70
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance6
        UltraGridColumn13.Header.Caption = "Orden Compra"
        UltraGridColumn13.Header.VisiblePosition = 25
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 74
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance7
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.Caption = "Total"
        UltraGridColumn14.Header.VisiblePosition = 29
        UltraGridColumn14.Width = 100
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance8
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.Caption = "% Importe Pendiente"
        UltraGridColumn15.Header.VisiblePosition = 30
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 85
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance9
        UltraGridColumn16.Format = "N2"
        UltraGridColumn16.Header.Caption = "% Importe Pendiente"
        UltraGridColumn16.Header.VisiblePosition = 31
        UltraGridColumn16.Width = 85
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn17.CellAppearance = Appearance10
        UltraGridColumn17.Header.Caption = "Fecha Entrega (FEnt)"
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.Width = 84
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn18.CellAppearance = Appearance11
        UltraGridColumn18.Header.Caption = "Fecha Gestión (FGest)"
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.Width = 80
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn19.CellAppearance = Appearance12
        UltraGridColumn19.Format = "dd/MM/yyyy"
        UltraGridColumn19.Header.Caption = "Fecha Autorización"
        UltraGridColumn19.Header.VisiblePosition = 15
        UltraGridColumn19.Width = 80
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn20.Header.Caption = "Act"
        UltraGridColumn20.Header.VisiblePosition = 2
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn20.Width = 40
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn27.Header.Caption = "Correo Electronico"
        UltraGridColumn27.Header.VisiblePosition = 26
        UltraGridColumn27.Width = 169
        UltraGridColumn26.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        UltraGridColumn26.Header.Caption = ""
        UltraGridColumn26.Header.VisiblePosition = 0
        UltraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn26.Width = 30
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance13.TextHAlignAsString = "Center"
        UltraGridColumn28.CellAppearance = Appearance13
        UltraGridColumn28.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn28.Header.Caption = "Fecha Envío"
        UltraGridColumn28.Header.VisiblePosition = 9
        UltraGridColumn28.Width = 101
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance14
        UltraGridColumn30.Format = "N2"
        UltraGridColumn30.Header.Caption = "Total Impuestos"
        UltraGridColumn30.Header.VisiblePosition = 28
        UltraGridColumn30.Width = 100
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance15
        UltraGridColumn31.Format = "N2"
        UltraGridColumn31.Header.Caption = "Total Neto"
        UltraGridColumn31.Header.VisiblePosition = 27
        UltraGridColumn31.Width = 100
        Appearance16.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance16
        UltraGridColumn33.Header.VisiblePosition = 10
        UltraGridColumn33.Width = 48
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance17.TextHAlignAsString = "Center"
        UltraGridColumn34.CellAppearance = Appearance17
        UltraGridColumn34.Format = "dd/MM/yyyy"
        UltraGridColumn34.Header.Caption = "Fecha Reprogramación Envío"
        UltraGridColumn34.Header.VisiblePosition = 11
        UltraGridColumn34.Width = 101
        UltraGridColumn21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn21.CellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance19.BackColor2 = System.Drawing.Color.Silver
        Appearance19.BorderColor3DBase = System.Drawing.Color.LightGray
        UltraGridColumn21.CellButtonAppearance = Appearance19
        UltraGridColumn21.Header.Caption = "Contactos"
        UltraGridColumn21.Header.VisiblePosition = 21
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn21.Width = 63
        UltraGridColumn22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance20.Image = CType(resources.GetObject("Appearance20.Image"), Object)
        Appearance20.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance20.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn22.CellButtonAppearance = Appearance20
        UltraGridColumn22.Header.Caption = ""
        UltraGridColumn22.Header.VisiblePosition = 1
        UltraGridColumn22.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn22.Width = 30
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance21.TextHAlignAsString = "Center"
        UltraGridColumn23.CellAppearance = Appearance21
        UltraGridColumn23.Header.Caption = "Dias entre FGest-FEnt"
        UltraGridColumn23.Header.VisiblePosition = 18
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 65
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn24.CellAppearance = Appearance22
        UltraGridColumn24.Header.Caption = "Dias entre FEmi-FEnt"
        UltraGridColumn24.Header.VisiblePosition = 19
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 65
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance23.TextHAlignAsString = "Center"
        UltraGridColumn25.CellAppearance = Appearance23
        UltraGridColumn25.Header.Caption = "Dias atraso FAct-FEnt"
        UltraGridColumn25.Header.VisiblePosition = 20
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 65
        UltraGridColumn29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance24.Image = Global.Eniac.Win.My.Resources.Resources.mail_next_32
        Appearance24.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance24.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn29.CellButtonAppearance = Appearance24
        UltraGridColumn29.Header.Caption = "Env"
        UltraGridColumn29.Header.VisiblePosition = 12
        UltraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn29.Width = 30
        UltraGridColumn32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance25.Image = Global.Eniac.Win.My.Resources.Resources.cancel_32
        Appearance25.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance25.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn32.CellButtonAppearance = Appearance25
        UltraGridColumn32.Header.VisiblePosition = 13
        UltraGridColumn32.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn32.Width = 30
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn27, UltraGridColumn26, UltraGridColumn28, UltraGridColumn30, UltraGridColumn31, UltraGridColumn33, UltraGridColumn34, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn29, UltraGridColumn32})
        UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[True]
        Appearance26.BackColor = System.Drawing.Color.Gainsboro
        UltraGridBand1.Override.CellAppearance = Appearance26
        UltraGridBand1.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.Button
        UltraGridBand1.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top
        Appearance27.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance27
        SummarySettings1.DisplayFormat = "{0:N2}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance28
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance31.BackColor2 = System.Drawing.SystemColors.Control
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance31
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance32
        Appearance33.BackColor = System.Drawing.SystemColors.Highlight
        Appearance33.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance34
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance35
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance36.BackColor = System.Drawing.SystemColors.Control
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance36
        Appearance37.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance38
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance39.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance39
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1057, 243)
        Me.ugDetalle.TabIndex = 5
        '
        'tbpConfig
        '
        Me.tbpConfig.BackColor = System.Drawing.SystemColors.Control
        Me.tbpConfig.Controls.Add(Me.GroupBox1)
        Me.tbpConfig.Location = New System.Drawing.Point(4, 22)
        Me.tbpConfig.Name = "tbpConfig"
        Me.tbpConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpConfig.Size = New System.Drawing.Size(1063, 249)
        Me.tbpConfig.TabIndex = 1
        Me.tbpConfig.Text = "Configuración Mail"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMailCuerpo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnExaminar4)
        Me.GroupBox1.Controls.Add(Me.txtArchivo4)
        Me.GroupBox1.Controls.Add(Me.txtCopiaOculta)
        Me.GroupBox1.Controls.Add(Me.lblArchivo4)
        Me.GroupBox1.Controls.Add(Me.btnExaminar3)
        Me.GroupBox1.Controls.Add(Me.txtArchivo3)
        Me.GroupBox1.Controls.Add(Me.lblArchivo3)
        Me.GroupBox1.Controls.Add(Me.btnExaminar2)
        Me.GroupBox1.Controls.Add(Me.txtArchivo2)
        Me.GroupBox1.Controls.Add(Me.lblArchivo2)
        Me.GroupBox1.Controls.Add(Me.btnExpandirHtml)
        Me.GroupBox1.Controls.Add(Me.btnExaminar1)
        Me.GroupBox1.Controls.Add(Me.txtArchivo1)
        Me.GroupBox1.Controls.Add(Me.lblArchivo1)
        Me.GroupBox1.Controls.Add(Me.lblCuerpo)
        Me.GroupBox1.Controls.Add(Me.rtbCuerpoMail)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1057, 243)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Envío"
        '
        'txtMailCuerpo
        '
        Me.txtMailCuerpo.Enabled = False
        Me.txtMailCuerpo.Location = New System.Drawing.Point(254, 27)
        Me.txtMailCuerpo.Name = "txtMailCuerpo"
        Me.txtMailCuerpo.Size = New System.Drawing.Size(222, 83)
        Me.txtMailCuerpo.TabIndex = 61
        Me.txtMailCuerpo.Text = resources.GetString("txtMailCuerpo.Text")
        Me.txtMailCuerpo.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.LabelAsoc = Nothing
        Me.Label8.Location = New System.Drawing.Point(501, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Con Copia a"
        '
        'btnExaminar4
        '
        Me.btnExaminar4.Image = CType(resources.GetObject("btnExaminar4.Image"), System.Drawing.Image)
        Me.btnExaminar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar4.Location = New System.Drawing.Point(406, 213)
        Me.btnExaminar4.Name = "btnExaminar4"
        Me.btnExaminar4.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar4.TabIndex = 15
        Me.btnExaminar4.Text = "Exam..."
        Me.btnExaminar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar4.UseVisualStyleBackColor = True
        '
        'txtArchivo4
        '
        Me.txtArchivo4.BindearPropiedadControl = "Text"
        Me.txtArchivo4.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo4.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo4.Formato = ""
        Me.txtArchivo4.IsDecimal = False
        Me.txtArchivo4.IsNumber = False
        Me.txtArchivo4.IsPK = False
        Me.txtArchivo4.IsRequired = False
        Me.txtArchivo4.Key = ""
        Me.txtArchivo4.LabelAsoc = Me.lblArchivo4
        Me.txtArchivo4.Location = New System.Drawing.Point(67, 213)
        Me.txtArchivo4.Name = "txtArchivo4"
        Me.txtArchivo4.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo4.TabIndex = 14
        '
        'lblArchivo4
        '
        Me.lblArchivo4.AutoSize = True
        Me.lblArchivo4.LabelAsoc = Nothing
        Me.lblArchivo4.Location = New System.Drawing.Point(13, 217)
        Me.lblArchivo4.Name = "lblArchivo4"
        Me.lblArchivo4.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo4.TabIndex = 13
        Me.lblArchivo4.Text = "Archivo 4"
        '
        'txtCopiaOculta
        '
        Me.txtCopiaOculta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCopiaOculta.BindearPropiedadControl = ""
        Me.txtCopiaOculta.BindearPropiedadEntidad = ""
        Me.txtCopiaOculta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCopiaOculta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCopiaOculta.Formato = "N2"
        Me.txtCopiaOculta.IsDecimal = False
        Me.txtCopiaOculta.IsNumber = False
        Me.txtCopiaOculta.IsPK = False
        Me.txtCopiaOculta.IsRequired = False
        Me.txtCopiaOculta.Key = ""
        Me.txtCopiaOculta.LabelAsoc = Nothing
        Me.txtCopiaOculta.Location = New System.Drawing.Point(570, 30)
        Me.txtCopiaOculta.MaxLength = 60
        Me.txtCopiaOculta.Name = "txtCopiaOculta"
        Me.txtCopiaOculta.ReadOnly = True
        Me.txtCopiaOculta.Size = New System.Drawing.Size(332, 20)
        Me.txtCopiaOculta.TabIndex = 60
        '
        'btnExaminar3
        '
        Me.btnExaminar3.Image = CType(resources.GetObject("btnExaminar3.Image"), System.Drawing.Image)
        Me.btnExaminar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar3.Location = New System.Drawing.Point(406, 185)
        Me.btnExaminar3.Name = "btnExaminar3"
        Me.btnExaminar3.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar3.TabIndex = 12
        Me.btnExaminar3.Text = "Exam..."
        Me.btnExaminar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar3.UseVisualStyleBackColor = True
        '
        'txtArchivo3
        '
        Me.txtArchivo3.BindearPropiedadControl = "Text"
        Me.txtArchivo3.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo3.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo3.Formato = ""
        Me.txtArchivo3.IsDecimal = False
        Me.txtArchivo3.IsNumber = False
        Me.txtArchivo3.IsPK = False
        Me.txtArchivo3.IsRequired = False
        Me.txtArchivo3.Key = ""
        Me.txtArchivo3.LabelAsoc = Me.lblArchivo3
        Me.txtArchivo3.Location = New System.Drawing.Point(67, 185)
        Me.txtArchivo3.Name = "txtArchivo3"
        Me.txtArchivo3.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo3.TabIndex = 11
        '
        'lblArchivo3
        '
        Me.lblArchivo3.AutoSize = True
        Me.lblArchivo3.LabelAsoc = Nothing
        Me.lblArchivo3.Location = New System.Drawing.Point(13, 189)
        Me.lblArchivo3.Name = "lblArchivo3"
        Me.lblArchivo3.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo3.TabIndex = 10
        Me.lblArchivo3.Text = "Archivo 3"
        '
        'btnExaminar2
        '
        Me.btnExaminar2.Image = CType(resources.GetObject("btnExaminar2.Image"), System.Drawing.Image)
        Me.btnExaminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar2.Location = New System.Drawing.Point(406, 160)
        Me.btnExaminar2.Name = "btnExaminar2"
        Me.btnExaminar2.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar2.TabIndex = 9
        Me.btnExaminar2.Text = "Exam..."
        Me.btnExaminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar2.UseVisualStyleBackColor = True
        '
        'txtArchivo2
        '
        Me.txtArchivo2.BindearPropiedadControl = "Text"
        Me.txtArchivo2.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo2.Formato = ""
        Me.txtArchivo2.IsDecimal = False
        Me.txtArchivo2.IsNumber = False
        Me.txtArchivo2.IsPK = False
        Me.txtArchivo2.IsRequired = False
        Me.txtArchivo2.Key = ""
        Me.txtArchivo2.LabelAsoc = Me.lblArchivo2
        Me.txtArchivo2.Location = New System.Drawing.Point(67, 160)
        Me.txtArchivo2.Name = "txtArchivo2"
        Me.txtArchivo2.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo2.TabIndex = 8
        '
        'lblArchivo2
        '
        Me.lblArchivo2.AutoSize = True
        Me.lblArchivo2.LabelAsoc = Nothing
        Me.lblArchivo2.Location = New System.Drawing.Point(13, 164)
        Me.lblArchivo2.Name = "lblArchivo2"
        Me.lblArchivo2.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo2.TabIndex = 7
        Me.lblArchivo2.Text = "Archivo 2"
        '
        'btnExpandirHtml
        '
        Me.btnExpandirHtml.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.btnExpandirHtml.Location = New System.Drawing.Point(17, 70)
        Me.btnExpandirHtml.Name = "btnExpandirHtml"
        Me.btnExpandirHtml.Size = New System.Drawing.Size(40, 40)
        Me.btnExpandirHtml.TabIndex = 6
        Me.btnExpandirHtml.Text = "..."
        Me.btnExpandirHtml.UseVisualStyleBackColor = True
        Me.btnExpandirHtml.Visible = False
        '
        'btnExaminar1
        '
        Me.btnExaminar1.Image = CType(resources.GetObject("btnExaminar1.Image"), System.Drawing.Image)
        Me.btnExaminar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar1.Location = New System.Drawing.Point(406, 135)
        Me.btnExaminar1.Name = "btnExaminar1"
        Me.btnExaminar1.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar1.TabIndex = 6
        Me.btnExaminar1.Text = "Exam..."
        Me.btnExaminar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar1.UseVisualStyleBackColor = True
        '
        'txtArchivo1
        '
        Me.txtArchivo1.BindearPropiedadControl = "Text"
        Me.txtArchivo1.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo1.Formato = ""
        Me.txtArchivo1.IsDecimal = False
        Me.txtArchivo1.IsNumber = False
        Me.txtArchivo1.IsPK = False
        Me.txtArchivo1.IsRequired = False
        Me.txtArchivo1.Key = ""
        Me.txtArchivo1.LabelAsoc = Me.lblArchivo1
        Me.txtArchivo1.Location = New System.Drawing.Point(67, 135)
        Me.txtArchivo1.Name = "txtArchivo1"
        Me.txtArchivo1.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo1.TabIndex = 5
        '
        'lblArchivo1
        '
        Me.lblArchivo1.AutoSize = True
        Me.lblArchivo1.LabelAsoc = Nothing
        Me.lblArchivo1.Location = New System.Drawing.Point(13, 139)
        Me.lblArchivo1.Name = "lblArchivo1"
        Me.lblArchivo1.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo1.TabIndex = 4
        Me.lblArchivo1.Text = "Archivo 1"
        '
        'lblCuerpo
        '
        Me.lblCuerpo.AutoSize = True
        Me.lblCuerpo.LabelAsoc = Nothing
        Me.lblCuerpo.Location = New System.Drawing.Point(12, 30)
        Me.lblCuerpo.Name = "lblCuerpo"
        Me.lblCuerpo.Size = New System.Drawing.Size(41, 13)
        Me.lblCuerpo.TabIndex = 2
        Me.lblCuerpo.Text = "Cuerpo"
        '
        'rtbCuerpoMail
        '
        Me.rtbCuerpoMail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rtbCuerpoMail.Enabled = False
        Me.rtbCuerpoMail.InnerText = Nothing
        Me.rtbCuerpoMail.Location = New System.Drawing.Point(59, 29)
        Me.rtbCuerpoMail.Name = "rtbCuerpoMail"
        Me.rtbCuerpoMail.Size = New System.Drawing.Size(413, 81)
        Me.rtbCuerpoMail.TabIndex = 3
        '
        'chbOcultarFiltros
        '
        Me.chbOcultarFiltros.AutoSize = True
        Me.chbOcultarFiltros.BindearPropiedadControl = Nothing
        Me.chbOcultarFiltros.BindearPropiedadEntidad = Nothing
        Me.chbOcultarFiltros.Checked = True
        Me.chbOcultarFiltros.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOcultarFiltros.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOcultarFiltros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOcultarFiltros.IsPK = False
        Me.chbOcultarFiltros.IsRequired = False
        Me.chbOcultarFiltros.Key = Nothing
        Me.chbOcultarFiltros.LabelAsoc = Nothing
        Me.chbOcultarFiltros.Location = New System.Drawing.Point(12, 32)
        Me.chbOcultarFiltros.Name = "chbOcultarFiltros"
        Me.chbOcultarFiltros.Size = New System.Drawing.Size(72, 17)
        Me.chbOcultarFiltros.TabIndex = 105
        Me.chbOcultarFiltros.Text = "Ver Filtros"
        Me.chbOcultarFiltros.UseVisualStyleBackColor = True
        '
        'sspPie
        '
        Me.sspPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto, Me.tspBarra})
        Me.sspPie.Location = New System.Drawing.Point(0, 539)
        Me.sspPie.Name = "sspPie"
        Me.sspPie.Size = New System.Drawing.Size(1095, 22)
        Me.sspPie.TabIndex = 106
        Me.sspPie.Text = "StatusStrip1"
        '
        'tslTexto
        '
        Me.tslTexto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tslTexto.Name = "tslTexto"
        Me.tslTexto.Size = New System.Drawing.Size(978, 17)
        Me.tslTexto.Spring = True
        Me.tslTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Step = 1
        '
        'chbReprogramadas
        '
        Me.chbReprogramadas.AutoSize = True
        Me.chbReprogramadas.BindearPropiedadControl = Nothing
        Me.chbReprogramadas.BindearPropiedadEntidad = Nothing
        Me.chbReprogramadas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbReprogramadas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbReprogramadas.IsPK = False
        Me.chbReprogramadas.IsRequired = False
        Me.chbReprogramadas.Key = Nothing
        Me.chbReprogramadas.LabelAsoc = Nothing
        Me.chbReprogramadas.Location = New System.Drawing.Point(476, 121)
        Me.chbReprogramadas.Name = "chbReprogramadas"
        Me.chbReprogramadas.Size = New System.Drawing.Size(217, 17)
        Me.chbReprogramadas.TabIndex = 62
        Me.chbReprogramadas.Text = "Ver Ordenes de Compra Reprogramadas"
        Me.chbReprogramadas.UseVisualStyleBackColor = True
        '
        'EnvioDeOrdenesDeCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 561)
        Me.Controls.Add(Me.sspPie)
        Me.Controls.Add(Me.chbOcultarFiltros)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "EnvioDeOrdenesDeCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío de Ordenes de Compra"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpOC.ResumeLayout(False)
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpConfig.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.sspPie.ResumeLayout(False)
        Me.sspPie.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents chbIdPedido As Eniac.Controles.CheckBox
   Friend WithEvents txtNroDesde As Eniac.Controles.TextBox
   Friend WithEvents cmbEstados As Eniac.Controles.ComboBox
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
    Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents Label5 As Controles.Label
   Friend WithEvents Label4 As Controles.Label
   Friend WithEvents chbRangoImporte As Controles.CheckBox
   Friend WithEvents dtpFechaEntregaHasta As Controles.DateTimePicker
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents dtpFechaEntregaDesde As Controles.DateTimePicker
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents chbFechaEntrega As Controles.CheckBox
   Friend WithEvents cmbActivadas As Controles.ComboBox
   Friend WithEvents txtMaxRango As Controles.TextBox
   Friend WithEvents txtMinRango As Controles.TextBox
   Friend WithEvents SplitContainer1 As SplitContainer
   Friend WithEvents chbOcultarFiltros As Controles.CheckBox
   Friend WithEvents dtpFechaAutorizacionHasta As Controles.DateTimePicker
   Friend WithEvents Label14 As Controles.Label
   Friend WithEvents dtpFechaAutorizacionDesde As Controles.DateTimePicker
   Friend WithEvents Label15 As Controles.Label
   Friend WithEvents chbFechaAutorizacion As Controles.CheckBox
   Friend WithEvents cmbCorreoEnviado As Controles.ComboBox
   Friend WithEvents lblCorreoEnviado As Controles.Label
   Friend WithEvents tsbEnviarFacturas As ToolStripButton
   Friend WithEvents ugDetalle As UltraGrid
   Friend WithEvents dtpFechaEnviohasta As Controles.DateTimePicker
   Friend WithEvents Label6 As Controles.Label
   Friend WithEvents dtpFechaEnvioDesde As Controles.DateTimePicker
   Friend WithEvents Label7 As Controles.Label
   Friend WithEvents btnTodos As Button
   Friend WithEvents cmbTodos As Controles.ComboBox
   Public WithEvents tsbCorreoPrueba As ToolStripButton
   Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
   Friend WithEvents sspPie As StatusStrip
   Friend WithEvents tslTexto As ToolStripStatusLabel
   Friend WithEvents tspBarra As ToolStripProgressBar
   Friend WithEvents SplitContainer2 As SplitContainer
   Friend WithEvents TabControl1 As TabControl
   Friend WithEvents tbpOC As TabPage
   Friend WithEvents tbpConfig As TabPage
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents btnExaminar4 As Controles.Button
   Friend WithEvents txtArchivo4 As Controles.TextBox
   Friend WithEvents lblArchivo4 As Controles.Label
   Friend WithEvents btnExaminar3 As Controles.Button
   Friend WithEvents txtArchivo3 As Controles.TextBox
   Friend WithEvents lblArchivo3 As Controles.Label
   Friend WithEvents btnExaminar2 As Controles.Button
   Friend WithEvents txtArchivo2 As Controles.TextBox
   Friend WithEvents lblArchivo2 As Controles.Label
   Friend WithEvents btnExpandirHtml As Controles.Button
   Friend WithEvents btnExaminar1 As Controles.Button
   Friend WithEvents txtArchivo1 As Controles.TextBox
   Friend WithEvents lblArchivo1 As Controles.Label
   Friend WithEvents lblCuerpo As Controles.Label
   Friend WithEvents rtbCuerpoMail As MSDN.Html.Editor.HtmlEditorControl
   Friend WithEvents GroupBox2 As GroupBox
   Friend WithEvents txtCopiaOculta As Controles.TextBox
   Friend WithEvents Label8 As Controles.Label
   Friend WithEvents btnEnviar As Button
   Friend WithEvents txtMailCuerpo As RichTextBox
   Friend WithEvents txtNroHasta As Controles.TextBox
   Friend WithEvents Label10 As Controles.Label
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents btnNoEnviar As Button
   Friend WithEvents chbFechaEnvio As Controles.CheckBox
   Friend WithEvents chbMesCompletoFechaEnvio As Controles.CheckBox
   Friend WithEvents lblCantidadDeErrores As Label
   Public WithEvents tsbVerErroresEnvio As ToolStripButton
    Friend WithEvents chbReprogramadas As Controles.CheckBox
End Class
