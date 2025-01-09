<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportacionLibIvaDigCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportacionLibIvaDigCompras))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Procesar")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuitProveedor")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalBruto")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalBaseImponible")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Percepciones")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoComprobante")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoDocumento")
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadDeAlicuotas")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EstaAnulado")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsDespachoImportacion")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDespachoCompleto")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImporteImpuesto")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosInternos")
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
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Procesar")
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CUIT")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseImponible")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPIVA")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteImpuesto")
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Percepciones")
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoComprobante")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoDocumento")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadDeAlicuotas")
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoAlicuota")
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Procesar")
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDespachoCompleto")
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoComprobante")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoDocumento")
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseImponible")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteImpuesto")
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPIVA")
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bruto")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoAlicuota")
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TbpComprobantes = New System.Windows.Forms.TabPage()
        Me.btnExaminarComprobantes = New Eniac.Controles.Button()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label1 = New Eniac.Controles.Label()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.txtArchivoDestinoComprobantes = New Eniac.Controles.TextBox()
        Me.lblArchivoDestinoComprobantes = New Eniac.Controles.Label()
        Me.tbpAlicuotas = New System.Windows.Forms.TabPage()
        Me.btnExaminarAlicuotas = New Eniac.Controles.Button()
        Me.ugAlicuotas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CheckBox2 = New Eniac.Controles.CheckBox()
        Me.txtArchivoDestinoAlicuotas = New Eniac.Controles.TextBox()
        Me.lblArchivoDestinoAlicuotas = New Eniac.Controles.Label()
        Me.tbpDespachoImportacion = New System.Windows.Forms.TabPage()
        Me.btnExaminarDespacho = New Eniac.Controles.Button()
        Me.ugDespachoImportacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.chbDespacho = New Eniac.Controles.CheckBox()
        Me.txtDestinoDespacho = New Eniac.Controles.TextBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbVerRegistrosConErrores = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
        Me.lblPeriodoFiscal = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.TabControl1.SuspendLayout()
        Me.TbpComprobantes.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpAlicuotas.SuspendLayout()
        CType(Me.ugAlicuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpDespachoImportacion.SuspendLayout()
        CType(Me.ugDespachoImportacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TbpComprobantes)
        Me.TabControl1.Controls.Add(Me.tbpAlicuotas)
        Me.TabControl1.Controls.Add(Me.tbpDespachoImportacion)
        Me.TabControl1.Location = New System.Drawing.Point(12, 105)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(970, 428)
        Me.TabControl1.TabIndex = 5
        '
        'TbpComprobantes
        '
        Me.TbpComprobantes.BackColor = System.Drawing.SystemColors.Control
        Me.TbpComprobantes.Controls.Add(Me.btnExaminarComprobantes)
        Me.TbpComprobantes.Controls.Add(Me.ugDetalle)
        Me.TbpComprobantes.Controls.Add(Me.Label1)
        Me.TbpComprobantes.Controls.Add(Me.chbTodos)
        Me.TbpComprobantes.Controls.Add(Me.txtArchivoDestinoComprobantes)
        Me.TbpComprobantes.Controls.Add(Me.lblArchivoDestinoComprobantes)
        Me.TbpComprobantes.Location = New System.Drawing.Point(4, 22)
        Me.TbpComprobantes.Name = "TbpComprobantes"
        Me.TbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
        Me.TbpComprobantes.Size = New System.Drawing.Size(962, 402)
        Me.TbpComprobantes.TabIndex = 0
        Me.TbpComprobantes.Text = "Comprobantes"
        '
        'btnExaminarComprobantes
        '
        Me.btnExaminarComprobantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExaminarComprobantes.Image = CType(resources.GetObject("btnExaminarComprobantes.Image"), System.Drawing.Image)
        Me.btnExaminarComprobantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminarComprobantes.Location = New System.Drawing.Point(606, 351)
        Me.btnExaminarComprobantes.Name = "btnExaminarComprobantes"
        Me.btnExaminarComprobantes.Size = New System.Drawing.Size(104, 45)
        Me.btnExaminarComprobantes.TabIndex = 12
        Me.btnExaminarComprobantes.Text = "&Examinar..."
        Me.btnExaminarComprobantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminarComprobantes.UseVisualStyleBackColor = True
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
        UltraGridColumn2.CellAppearance = Appearance2
        UltraGridColumn2.Header.Caption = "P."
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Width = 25
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance3
        UltraGridColumn45.Header.Caption = "Línea"
        UltraGridColumn45.Header.VisiblePosition = 1
        UltraGridColumn45.Width = 40
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn46.Header.VisiblePosition = 2
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn47.Header.Caption = "Comprobante"
        UltraGridColumn47.Header.VisiblePosition = 3
        UltraGridColumn47.Width = 82
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn48.CellAppearance = Appearance4
        UltraGridColumn48.Header.VisiblePosition = 4
        UltraGridColumn48.Width = 40
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn49.CellAppearance = Appearance5
        UltraGridColumn49.Header.Caption = "Emisor"
        UltraGridColumn49.Header.VisiblePosition = 5
        UltraGridColumn49.Width = 45
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn50.CellAppearance = Appearance6
        UltraGridColumn50.Header.Caption = "Nro. Comp."
        UltraGridColumn50.Header.VisiblePosition = 6
        UltraGridColumn50.Width = 65
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn51.CellAppearance = Appearance7
        UltraGridColumn51.Format = "dd/MM/yyyy"
        UltraGridColumn51.Header.VisiblePosition = 8
        UltraGridColumn51.Width = 70
        UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn56.Header.Caption = "Categ. Fiscal"
        UltraGridColumn56.Header.VisiblePosition = 9
        UltraGridColumn56.Width = 70
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance8
        UltraGridColumn5.Header.Caption = "CUIT"
        UltraGridColumn5.Header.VisiblePosition = 10
        UltraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn58.Header.Caption = "Proveedor"
        UltraGridColumn58.Header.VisiblePosition = 11
        UltraGridColumn58.Width = 150
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance9
        UltraGridColumn6.Header.Caption = "Bruto"
        UltraGridColumn6.Header.VisiblePosition = 12
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance10
        UltraGridColumn7.Header.Caption = "Neto"
        UltraGridColumn7.Header.VisiblePosition = 13
        UltraGridColumn62.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn62.CellAppearance = Appearance11
        UltraGridColumn62.Format = "N2"
        UltraGridColumn62.Header.VisiblePosition = 15
        UltraGridColumn62.Width = 80
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance12
        UltraGridColumn8.Header.Caption = "Total"
        UltraGridColumn8.Header.VisiblePosition = 17
        UltraGridColumn66.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn66.Header.VisiblePosition = 18
        UltraGridColumn66.Hidden = True
        UltraGridColumn67.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn67.Header.VisiblePosition = 19
        UltraGridColumn67.Hidden = True
        UltraGridColumn88.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn88.CellAppearance = Appearance13
        UltraGridColumn88.Header.VisiblePosition = 20
        UltraGridColumn88.Hidden = True
        UltraGridColumn89.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn89.CellAppearance = Appearance14
        UltraGridColumn89.Header.Caption = "Cant. Alicuotas"
        UltraGridColumn89.Header.VisiblePosition = 21
        UltraGridColumn89.Width = 62
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance15
        UltraGridColumn3.Header.Caption = "Anulado"
        UltraGridColumn3.Header.VisiblePosition = 22
        UltraGridColumn91.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn91.Header.Caption = "Error"
        UltraGridColumn91.Header.VisiblePosition = 23
        UltraGridColumn91.Width = 350
        UltraGridColumn92.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn92.Header.VisiblePosition = 24
        UltraGridColumn92.Hidden = True
        UltraGridColumn92.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn93.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.TextHAlignAsString = "Left"
        UltraGridColumn93.CellAppearance = Appearance16
        UltraGridColumn93.Header.Caption = "Despacho"
        UltraGridColumn93.Header.VisiblePosition = 7
        UltraGridColumn93.Hidden = True
        UltraGridColumn93.Width = 134
        UltraGridColumn94.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn94.CellAppearance = Appearance17
        UltraGridColumn94.Header.Caption = "Impuestos"
        UltraGridColumn94.Header.VisiblePosition = 14
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance18
        UltraGridColumn1.Format = "N2"
        UltraGridColumn1.Header.Caption = "Imp. Internos"
        UltraGridColumn1.Header.VisiblePosition = 16
        UltraGridColumn1.Width = 80
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn2, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn56, UltraGridColumn5, UltraGridColumn58, UltraGridColumn6, UltraGridColumn7, UltraGridColumn62, UltraGridColumn8, UltraGridColumn66, UltraGridColumn67, UltraGridColumn88, UltraGridColumn89, UltraGridColumn3, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn1})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance19
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance21.BackColor2 = System.Drawing.SystemColors.Control
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance22
        Appearance23.BackColor = System.Drawing.SystemColors.Highlight
        Appearance23.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance23
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance24
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Appearance25.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance26.BackColor = System.Drawing.SystemColors.Control
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance26
        Appearance27.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Location = New System.Drawing.Point(6, 19)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(953, 326)
        Me.ugDetalle.TabIndex = 11
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(378, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "* Se informan solo las alicuotas de las Categorías Fiscales que Discriminan IVA"
        '
        'chbTodos
        '
        Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbTodos.AutoSize = True
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.Enabled = False
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(6, 371)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(56, 17)
        Me.chbTodos.TabIndex = 1
        Me.chbTodos.Text = "Todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'txtArchivoDestinoComprobantes
        '
        Me.txtArchivoDestinoComprobantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtArchivoDestinoComprobantes.BindearPropiedadControl = ""
        Me.txtArchivoDestinoComprobantes.BindearPropiedadEntidad = ""
        Me.txtArchivoDestinoComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoDestinoComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoDestinoComprobantes.Formato = ""
        Me.txtArchivoDestinoComprobantes.IsDecimal = False
        Me.txtArchivoDestinoComprobantes.IsNumber = False
        Me.txtArchivoDestinoComprobantes.IsPK = False
        Me.txtArchivoDestinoComprobantes.IsRequired = False
        Me.txtArchivoDestinoComprobantes.Key = ""
        Me.txtArchivoDestinoComprobantes.LabelAsoc = Me.lblArchivoDestinoComprobantes
        Me.txtArchivoDestinoComprobantes.Location = New System.Drawing.Point(166, 369)
        Me.txtArchivoDestinoComprobantes.Name = "txtArchivoDestinoComprobantes"
        Me.txtArchivoDestinoComprobantes.Size = New System.Drawing.Size(434, 20)
        Me.txtArchivoDestinoComprobantes.TabIndex = 3
        '
        'lblArchivoDestinoComprobantes
        '
        Me.lblArchivoDestinoComprobantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArchivoDestinoComprobantes.AutoSize = True
        Me.lblArchivoDestinoComprobantes.LabelAsoc = Nothing
        Me.lblArchivoDestinoComprobantes.Location = New System.Drawing.Point(75, 373)
        Me.lblArchivoDestinoComprobantes.Name = "lblArchivoDestinoComprobantes"
        Me.lblArchivoDestinoComprobantes.Size = New System.Drawing.Size(85, 13)
        Me.lblArchivoDestinoComprobantes.TabIndex = 2
        Me.lblArchivoDestinoComprobantes.Text = "Archivo Destino:"
        '
        'tbpAlicuotas
        '
        Me.tbpAlicuotas.BackColor = System.Drawing.SystemColors.Control
        Me.tbpAlicuotas.Controls.Add(Me.btnExaminarAlicuotas)
        Me.tbpAlicuotas.Controls.Add(Me.ugAlicuotas)
        Me.tbpAlicuotas.Controls.Add(Me.CheckBox2)
        Me.tbpAlicuotas.Controls.Add(Me.txtArchivoDestinoAlicuotas)
        Me.tbpAlicuotas.Controls.Add(Me.lblArchivoDestinoAlicuotas)
        Me.tbpAlicuotas.Location = New System.Drawing.Point(4, 22)
        Me.tbpAlicuotas.Name = "tbpAlicuotas"
        Me.tbpAlicuotas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAlicuotas.Size = New System.Drawing.Size(962, 402)
        Me.tbpAlicuotas.TabIndex = 1
        Me.tbpAlicuotas.Text = "Alicuotas"
        '
        'btnExaminarAlicuotas
        '
        Me.btnExaminarAlicuotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExaminarAlicuotas.Image = CType(resources.GetObject("btnExaminarAlicuotas.Image"), System.Drawing.Image)
        Me.btnExaminarAlicuotas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminarAlicuotas.Location = New System.Drawing.Point(606, 351)
        Me.btnExaminarAlicuotas.Name = "btnExaminarAlicuotas"
        Me.btnExaminarAlicuotas.Size = New System.Drawing.Size(104, 45)
        Me.btnExaminarAlicuotas.TabIndex = 39
        Me.btnExaminarAlicuotas.Text = "Examinar..."
        Me.btnExaminarAlicuotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminarAlicuotas.UseVisualStyleBackColor = True
        '
        'ugAlicuotas
        '
        Me.ugAlicuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugAlicuotas.DisplayLayout.Appearance = Appearance30
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance31.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance31
        UltraGridColumn4.Header.Caption = "P."
        UltraGridColumn4.Header.VisiblePosition = 0
        UltraGridColumn4.Width = 26
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance32.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance32
        UltraGridColumn24.Header.Caption = "Línea"
        UltraGridColumn24.Header.VisiblePosition = 1
        UltraGridColumn24.Width = 45
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn25.Header.VisiblePosition = 2
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.Caption = "Comprobante"
        UltraGridColumn26.Header.VisiblePosition = 3
        UltraGridColumn26.Width = 80
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance33.TextHAlignAsString = "Center"
        UltraGridColumn27.CellAppearance = Appearance33
        UltraGridColumn27.Header.VisiblePosition = 4
        UltraGridColumn27.Width = 40
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance34.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance34
        UltraGridColumn28.Header.Caption = "Emisor"
        UltraGridColumn28.Header.VisiblePosition = 5
        UltraGridColumn28.Width = 45
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance35.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance35
        UltraGridColumn29.Header.Caption = "Nro. Comp."
        UltraGridColumn29.Header.VisiblePosition = 6
        UltraGridColumn29.Width = 90
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn30.Header.VisiblePosition = 7
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 90
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn31.Header.VisiblePosition = 8
        UltraGridColumn31.Hidden = True
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn32.Header.VisiblePosition = 9
        UltraGridColumn32.Hidden = True
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance36
        UltraGridColumn33.Header.VisiblePosition = 10
        UltraGridColumn33.Hidden = True
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance37.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance37
        UltraGridColumn10.Header.Caption = "Neto"
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance38.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance38
        UltraGridColumn35.Header.Caption = "Alicuota"
        UltraGridColumn35.Header.VisiblePosition = 12
        UltraGridColumn35.Width = 70
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance39.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance39
        UltraGridColumn11.Header.Caption = "Impuestos"
        UltraGridColumn11.Header.VisiblePosition = 14
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance40.TextHAlignAsString = "Right"
        UltraGridColumn37.CellAppearance = Appearance40
        UltraGridColumn37.Format = "N2"
        UltraGridColumn37.Header.VisiblePosition = 15
        UltraGridColumn37.Width = 80
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance41.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance41
        UltraGridColumn12.Header.Caption = "Total"
        UltraGridColumn12.Header.VisiblePosition = 16
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn39.Header.VisiblePosition = 17
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn40.Header.VisiblePosition = 18
        UltraGridColumn40.Hidden = True
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance42.TextHAlignAsString = "Right"
        UltraGridColumn41.CellAppearance = Appearance42
        UltraGridColumn41.Header.VisiblePosition = 19
        UltraGridColumn41.Hidden = True
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn42.Header.Caption = "Error"
        UltraGridColumn42.Header.VisiblePosition = 20
        UltraGridColumn42.Width = 350
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance43.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance43
        UltraGridColumn13.Header.Caption = "Alìcuota"
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn10, UltraGridColumn35, UltraGridColumn11, UltraGridColumn37, UltraGridColumn12, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn13})
        Me.ugAlicuotas.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugAlicuotas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAlicuotas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance44.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance44.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.GroupByBox.Appearance = Appearance44
        Appearance45.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAlicuotas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance45
        Me.ugAlicuotas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance46.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance46.BackColor2 = System.Drawing.SystemColors.Control
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAlicuotas.DisplayLayout.GroupByBox.PromptAppearance = Appearance46
        Me.ugAlicuotas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugAlicuotas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugAlicuotas.DisplayLayout.Override.ActiveCellAppearance = Appearance47
        Appearance48.BackColor = System.Drawing.SystemColors.Highlight
        Appearance48.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugAlicuotas.DisplayLayout.Override.ActiveRowAppearance = Appearance48
        Me.ugAlicuotas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugAlicuotas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.Override.CardAreaAppearance = Appearance49
        Appearance50.BorderColor = System.Drawing.Color.Silver
        Appearance50.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugAlicuotas.DisplayLayout.Override.CellAppearance = Appearance50
        Me.ugAlicuotas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugAlicuotas.DisplayLayout.Override.CellPadding = 0
        Appearance51.BackColor = System.Drawing.SystemColors.Control
        Appearance51.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance51.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance51.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.Override.GroupByRowAppearance = Appearance51
        Appearance52.TextHAlignAsString = "Left"
        Me.ugAlicuotas.DisplayLayout.Override.HeaderAppearance = Appearance52
        Me.ugAlicuotas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugAlicuotas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Me.ugAlicuotas.DisplayLayout.Override.RowAppearance = Appearance53
        Me.ugAlicuotas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance54.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugAlicuotas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance54
        Me.ugAlicuotas.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAlicuotas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugAlicuotas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugAlicuotas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugAlicuotas.Location = New System.Drawing.Point(3, 3)
        Me.ugAlicuotas.Name = "ugAlicuotas"
        Me.ugAlicuotas.Size = New System.Drawing.Size(953, 345)
        Me.ugAlicuotas.TabIndex = 38
        Me.ugAlicuotas.Text = "UltraGrid2"
        '
        'CheckBox2
        '
        Me.CheckBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BindearPropiedadControl = Nothing
        Me.CheckBox2.BindearPropiedadEntidad = Nothing
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox2.IsPK = False
        Me.CheckBox2.IsRequired = False
        Me.CheckBox2.Key = Nothing
        Me.CheckBox2.LabelAsoc = Nothing
        Me.CheckBox2.Location = New System.Drawing.Point(6, 371)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox2.TabIndex = 30
        Me.CheckBox2.Text = "Todos"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'txtArchivoDestinoAlicuotas
        '
        Me.txtArchivoDestinoAlicuotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtArchivoDestinoAlicuotas.BindearPropiedadControl = ""
        Me.txtArchivoDestinoAlicuotas.BindearPropiedadEntidad = ""
        Me.txtArchivoDestinoAlicuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoDestinoAlicuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoDestinoAlicuotas.Formato = ""
        Me.txtArchivoDestinoAlicuotas.IsDecimal = False
        Me.txtArchivoDestinoAlicuotas.IsNumber = False
        Me.txtArchivoDestinoAlicuotas.IsPK = False
        Me.txtArchivoDestinoAlicuotas.IsRequired = False
        Me.txtArchivoDestinoAlicuotas.Key = ""
        Me.txtArchivoDestinoAlicuotas.LabelAsoc = Me.lblArchivoDestinoAlicuotas
        Me.txtArchivoDestinoAlicuotas.Location = New System.Drawing.Point(166, 369)
        Me.txtArchivoDestinoAlicuotas.Name = "txtArchivoDestinoAlicuotas"
        Me.txtArchivoDestinoAlicuotas.Size = New System.Drawing.Size(434, 20)
        Me.txtArchivoDestinoAlicuotas.TabIndex = 28
        '
        'lblArchivoDestinoAlicuotas
        '
        Me.lblArchivoDestinoAlicuotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArchivoDestinoAlicuotas.AutoSize = True
        Me.lblArchivoDestinoAlicuotas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArchivoDestinoAlicuotas.LabelAsoc = Nothing
        Me.lblArchivoDestinoAlicuotas.Location = New System.Drawing.Point(75, 373)
        Me.lblArchivoDestinoAlicuotas.Name = "lblArchivoDestinoAlicuotas"
        Me.lblArchivoDestinoAlicuotas.Size = New System.Drawing.Size(85, 13)
        Me.lblArchivoDestinoAlicuotas.TabIndex = 27
        Me.lblArchivoDestinoAlicuotas.Text = "Archivo Destino:"
        '
        'tbpDespachoImportacion
        '
        Me.tbpDespachoImportacion.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDespachoImportacion.Controls.Add(Me.btnExaminarDespacho)
        Me.tbpDespachoImportacion.Controls.Add(Me.ugDespachoImportacion)
        Me.tbpDespachoImportacion.Controls.Add(Me.chbDespacho)
        Me.tbpDespachoImportacion.Controls.Add(Me.txtDestinoDespacho)
        Me.tbpDespachoImportacion.Controls.Add(Me.Label2)
        Me.tbpDespachoImportacion.Location = New System.Drawing.Point(4, 22)
        Me.tbpDespachoImportacion.Name = "tbpDespachoImportacion"
        Me.tbpDespachoImportacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDespachoImportacion.Size = New System.Drawing.Size(962, 402)
        Me.tbpDespachoImportacion.TabIndex = 2
        Me.tbpDespachoImportacion.Text = "Despacho Importación"
        '
        'btnExaminarDespacho
        '
        Me.btnExaminarDespacho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExaminarDespacho.Image = CType(resources.GetObject("btnExaminarDespacho.Image"), System.Drawing.Image)
        Me.btnExaminarDespacho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminarDespacho.Location = New System.Drawing.Point(606, 351)
        Me.btnExaminarDespacho.Name = "btnExaminarDespacho"
        Me.btnExaminarDespacho.Size = New System.Drawing.Size(104, 45)
        Me.btnExaminarDespacho.TabIndex = 46
        Me.btnExaminarDespacho.Text = "&Examinar..."
        Me.btnExaminarDespacho.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminarDespacho.UseVisualStyleBackColor = True
        '
        'ugDespachoImportacion
        '
        Me.ugDespachoImportacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Appearance55.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDespachoImportacion.DisplayLayout.Appearance = Appearance55
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "P."
        UltraGridColumn9.Header.VisiblePosition = 0
        UltraGridColumn9.Width = 27
        UltraGridColumn96.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance56.TextHAlignAsString = "Right"
        UltraGridColumn96.CellAppearance = Appearance56
        UltraGridColumn96.Header.VisiblePosition = 2
        UltraGridColumn96.Width = 41
        UltraGridColumn97.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn97.Header.VisiblePosition = 1
        UltraGridColumn97.Hidden = True
        UltraGridColumn98.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn98.Header.VisiblePosition = 3
        UltraGridColumn98.Hidden = True
        UltraGridColumn99.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn99.Header.Caption = "Comprobante"
        UltraGridColumn99.Header.VisiblePosition = 4
        UltraGridColumn99.Hidden = True
        UltraGridColumn99.Width = 80
        UltraGridColumn100.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance57.TextHAlignAsString = "Center"
        UltraGridColumn100.CellAppearance = Appearance57
        UltraGridColumn100.Header.VisiblePosition = 5
        UltraGridColumn100.Hidden = True
        UltraGridColumn100.Width = 40
        UltraGridColumn101.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance58.TextHAlignAsString = "Right"
        UltraGridColumn101.CellAppearance = Appearance58
        UltraGridColumn101.Header.Caption = "Emisor"
        UltraGridColumn101.Header.VisiblePosition = 6
        UltraGridColumn101.Hidden = True
        UltraGridColumn101.Width = 45
        UltraGridColumn102.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance59.TextHAlignAsString = "Right"
        UltraGridColumn102.CellAppearance = Appearance59
        UltraGridColumn102.Header.Caption = "Nro. Comp."
        UltraGridColumn102.Header.VisiblePosition = 11
        UltraGridColumn102.Hidden = True
        UltraGridColumn102.Width = 90
        UltraGridColumn103.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn103.Header.Caption = "Despacho"
        UltraGridColumn103.Header.VisiblePosition = 7
        UltraGridColumn103.Width = 160
        UltraGridColumn104.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn104.Header.VisiblePosition = 12
        UltraGridColumn104.Hidden = True
        UltraGridColumn105.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn105.Header.VisiblePosition = 18
        UltraGridColumn105.Hidden = True
        UltraGridColumn106.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn106.Header.VisiblePosition = 22
        UltraGridColumn106.Hidden = True
        UltraGridColumn107.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance60.TextHAlignAsString = "Right"
        UltraGridColumn107.CellAppearance = Appearance60
        UltraGridColumn107.Format = "N2"
        UltraGridColumn107.Header.Caption = "Base Imponible"
        UltraGridColumn107.Header.VisiblePosition = 13
        UltraGridColumn108.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance61.TextHAlignAsString = "Right"
        UltraGridColumn108.CellAppearance = Appearance61
        UltraGridColumn108.Header.VisiblePosition = 14
        UltraGridColumn108.Hidden = True
        UltraGridColumn109.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance62.TextHAlignAsString = "Right"
        UltraGridColumn109.CellAppearance = Appearance62
        UltraGridColumn109.Format = "N2"
        UltraGridColumn109.Header.Caption = "Importe"
        UltraGridColumn109.Header.VisiblePosition = 17
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance63.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance63
        UltraGridColumn15.Header.Caption = "Total"
        UltraGridColumn15.Header.VisiblePosition = 20
        UltraGridColumn111.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance64.TextHAlignAsString = "Right"
        UltraGridColumn111.CellAppearance = Appearance64
        UltraGridColumn111.Header.Caption = "Alicuota"
        UltraGridColumn111.Header.VisiblePosition = 16
        UltraGridColumn111.Hidden = True
        UltraGridColumn112.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn112.Header.Caption = "Error"
        UltraGridColumn112.Header.VisiblePosition = 21
        UltraGridColumn112.Width = 557
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.VisiblePosition = 19
        UltraGridColumn17.Hidden = True
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.Caption = "Tipo Doc."
        UltraGridColumn19.Header.VisiblePosition = 8
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.Caption = "Nro. Doc."
        UltraGridColumn20.Header.VisiblePosition = 9
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.Caption = "CUIT"
        UltraGridColumn21.Header.VisiblePosition = 10
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn18.Header.VisiblePosition = 23
        UltraGridColumn18.Hidden = True
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance65.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance65
        UltraGridColumn16.Header.Caption = "Alícuota"
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn15, UltraGridColumn111, UltraGridColumn112, UltraGridColumn17, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn18, UltraGridColumn16})
        Me.ugDespachoImportacion.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugDespachoImportacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDespachoImportacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance66.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance66.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance66.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDespachoImportacion.DisplayLayout.GroupByBox.Appearance = Appearance66
        Appearance67.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDespachoImportacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance67
        Me.ugDespachoImportacion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance68.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance68.BackColor2 = System.Drawing.SystemColors.Control
        Appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance68.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDespachoImportacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance68
        Me.ugDespachoImportacion.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDespachoImportacion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance69.BackColor = System.Drawing.SystemColors.Window
        Appearance69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDespachoImportacion.DisplayLayout.Override.ActiveCellAppearance = Appearance69
        Appearance70.BackColor = System.Drawing.SystemColors.Highlight
        Appearance70.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDespachoImportacion.DisplayLayout.Override.ActiveRowAppearance = Appearance70
        Me.ugDespachoImportacion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDespachoImportacion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance71.BackColor = System.Drawing.SystemColors.Window
        Me.ugDespachoImportacion.DisplayLayout.Override.CardAreaAppearance = Appearance71
        Appearance72.BorderColor = System.Drawing.Color.Silver
        Appearance72.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDespachoImportacion.DisplayLayout.Override.CellAppearance = Appearance72
        Me.ugDespachoImportacion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDespachoImportacion.DisplayLayout.Override.CellPadding = 0
        Appearance73.BackColor = System.Drawing.SystemColors.Control
        Appearance73.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance73.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance73.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDespachoImportacion.DisplayLayout.Override.GroupByRowAppearance = Appearance73
        Appearance74.TextHAlignAsString = "Left"
        Me.ugDespachoImportacion.DisplayLayout.Override.HeaderAppearance = Appearance74
        Me.ugDespachoImportacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDespachoImportacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance75.BackColor = System.Drawing.SystemColors.Window
        Appearance75.BorderColor = System.Drawing.Color.Silver
        Me.ugDespachoImportacion.DisplayLayout.Override.RowAppearance = Appearance75
        Me.ugDespachoImportacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance76.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDespachoImportacion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance76
        Me.ugDespachoImportacion.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDespachoImportacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDespachoImportacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDespachoImportacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDespachoImportacion.Location = New System.Drawing.Point(3, 3)
        Me.ugDespachoImportacion.Name = "ugDespachoImportacion"
        Me.ugDespachoImportacion.Size = New System.Drawing.Size(953, 342)
        Me.ugDespachoImportacion.TabIndex = 45
        Me.ugDespachoImportacion.Text = "UltraGrid2"
        '
        'chbDespacho
        '
        Me.chbDespacho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbDespacho.AutoSize = True
        Me.chbDespacho.BindearPropiedadControl = Nothing
        Me.chbDespacho.BindearPropiedadEntidad = Nothing
        Me.chbDespacho.Enabled = False
        Me.chbDespacho.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDespacho.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDespacho.IsPK = False
        Me.chbDespacho.IsRequired = False
        Me.chbDespacho.Key = Nothing
        Me.chbDespacho.LabelAsoc = Nothing
        Me.chbDespacho.Location = New System.Drawing.Point(6, 371)
        Me.chbDespacho.Name = "chbDespacho"
        Me.chbDespacho.Size = New System.Drawing.Size(56, 17)
        Me.chbDespacho.TabIndex = 44
        Me.chbDespacho.Text = "Todos"
        Me.chbDespacho.UseVisualStyleBackColor = True
        '
        'txtDestinoDespacho
        '
        Me.txtDestinoDespacho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDestinoDespacho.BindearPropiedadControl = ""
        Me.txtDestinoDespacho.BindearPropiedadEntidad = ""
        Me.txtDestinoDespacho.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDestinoDespacho.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDestinoDespacho.Formato = ""
        Me.txtDestinoDespacho.IsDecimal = False
        Me.txtDestinoDespacho.IsNumber = False
        Me.txtDestinoDespacho.IsPK = False
        Me.txtDestinoDespacho.IsRequired = False
        Me.txtDestinoDespacho.Key = ""
        Me.txtDestinoDespacho.LabelAsoc = Me.Label2
        Me.txtDestinoDespacho.Location = New System.Drawing.Point(166, 369)
        Me.txtDestinoDespacho.Name = "txtDestinoDespacho"
        Me.txtDestinoDespacho.Size = New System.Drawing.Size(434, 20)
        Me.txtDestinoDespacho.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(75, 373)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Archivo Destino:"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 6
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbExportar, Me.ToolStripSeparator5, Me.tsbVerRegistrosConErrores, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Enabled = False
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(77, 26)
        Me.tsbExportar.Text = "&Exportar"
        Me.tsbExportar.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbVerRegistrosConErrores
        '
        Me.tsbVerRegistrosConErrores.Enabled = False
        Me.tsbVerRegistrosConErrores.Image = Global.Eniac.Win.My.Resources.Resources.note_info_32
        Me.tsbVerRegistrosConErrores.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVerRegistrosConErrores.Name = "tsbVerRegistrosConErrores"
        Me.tsbVerRegistrosConErrores.Size = New System.Drawing.Size(111, 26)
        Me.tsbVerRegistrosConErrores.Text = "Ver con errores"
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
        Me.grbFiltros.Controls.Add(Me.dtpPeriodoFiscal)
        Me.grbFiltros.Controls.Add(Me.lblPeriodoFiscal)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(970, 61)
        Me.grbFiltros.TabIndex = 4
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'dtpPeriodoFiscal
        '
        Me.dtpPeriodoFiscal.BindearPropiedadControl = Nothing
        Me.dtpPeriodoFiscal.BindearPropiedadEntidad = Nothing
        Me.dtpPeriodoFiscal.CustomFormat = "MM/yyyy"
        Me.dtpPeriodoFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpPeriodoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpPeriodoFiscal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoFiscal.IsPK = False
        Me.dtpPeriodoFiscal.IsRequired = False
        Me.dtpPeriodoFiscal.Key = ""
        Me.dtpPeriodoFiscal.LabelAsoc = Me.lblPeriodoFiscal
        Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(111, 24)
        Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
        Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(65, 20)
        Me.dtpPeriodoFiscal.TabIndex = 1
        '
        'lblPeriodoFiscal
        '
        Me.lblPeriodoFiscal.AutoSize = True
        Me.lblPeriodoFiscal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriodoFiscal.LabelAsoc = Nothing
        Me.lblPeriodoFiscal.Location = New System.Drawing.Point(32, 28)
        Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
        Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
        Me.lblPeriodoFiscal.TabIndex = 0
        Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.zoom_32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(226, 12)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'ExportacionLibIvaDigCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.KeyPreview = True
        Me.Name = "ExportacionLibIvaDigCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Libro IVA Digital Compras"
        Me.TabControl1.ResumeLayout(False)
        Me.TbpComprobantes.ResumeLayout(False)
        Me.TbpComprobantes.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpAlicuotas.ResumeLayout(False)
        Me.tbpAlicuotas.PerformLayout()
        CType(Me.ugAlicuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpDespachoImportacion.ResumeLayout(False)
        Me.tbpDespachoImportacion.PerformLayout()
        CType(Me.ugDespachoImportacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents txtArchivoDestinoComprobantes As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestinoComprobantes As Eniac.Controles.Label
   Friend WithEvents tbpAlicuotas As System.Windows.Forms.TabPage
   Friend WithEvents CheckBox2 As Eniac.Controles.CheckBox
   Friend WithEvents txtArchivoDestinoAlicuotas As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestinoAlicuotas As Eniac.Controles.Label
   Friend WithEvents tbpDespachoImportacion As System.Windows.Forms.TabPage
   Friend WithEvents chbDespacho As Eniac.Controles.CheckBox
   Friend WithEvents txtDestinoDespacho As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbVerRegistrosConErrores As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugAlicuotas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugDespachoImportacion As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnExaminarComprobantes As Eniac.Controles.Button
   Friend WithEvents btnExaminarAlicuotas As Eniac.Controles.Button
   Friend WithEvents btnExaminarDespacho As Eniac.Controles.Button
End Class
