<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportacionCitiCompras
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportacionCitiCompras))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Proceso")
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CUIT")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteBruto")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Neto")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Percepciones")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoComprobante")
      Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoDocumento")
      Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
      Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadDeAlicuotas")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EstaAnulada")
      Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
      Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsDespachoImportacion")
      Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDespachoCompleto")
      Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImporteImpuesto")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosInternos")
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
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Proceso")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CUIT")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Neto")
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPIVA")
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Percepciones")
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoComprobante")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoDocumento")
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadDeAlicuotas")
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
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
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Proceso")
      Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
      Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDespachoCompleto")
      Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoComprobante")
      Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoDocumento")
      Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseImponible")
      Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
      Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteImpuesto")
      Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPIVA")
      Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
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
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
      Me.lblPeriodoFiscal = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbVerRegistrosConErrores = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TbpComprobantes = New System.Windows.Forms.TabPage()
      Me.Label1 = New Eniac.Controles.Label()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.btnExaminarComprobantes = New Eniac.Controles.Button()
      Me.txtArchivoDestinoComprobantes = New Eniac.Controles.TextBox()
      Me.lblArchivoDestinoComprobantes = New Eniac.Controles.Label()
      Me.tbpAlicuotas = New System.Windows.Forms.TabPage()
      Me.ugAlicuotas = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.CheckBox2 = New Eniac.Controles.CheckBox()
      Me.btnExaminarAlicuotas = New Eniac.Controles.Button()
      Me.txtArchivoDestinoAlicuotas = New Eniac.Controles.TextBox()
      Me.lblArchivoDestinoAlicuotas = New Eniac.Controles.Label()
      Me.tbpDespachoImportacion = New System.Windows.Forms.TabPage()
      Me.chbDespacho = New Eniac.Controles.CheckBox()
      Me.txtArchivoDespacho = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.btnExaminarDespacho = New Eniac.Controles.Button()
      Me.ugDespachoImportacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.CitiVentasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DsAFIP = New Eniac.Win.dsAFIP()
      Me.CitiVentasAlicuotasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.grbFiltros.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TbpComprobantes.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpAlicuotas.SuspendLayout()
      CType(Me.ugAlicuotas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpDespachoImportacion.SuspendLayout()
      CType(Me.ugDespachoImportacion, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.CitiVentasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DsAFIP, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.CitiVentasAlicuotasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
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
      Me.grbFiltros.TabIndex = 0
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
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbExportar, Me.ToolStripSeparator5, Me.tsbVerRegistrosConErrores, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(987, 29)
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
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(987, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(908, 17)
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
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "document_find.ico")
      Me.imgGrabar.Images.SetKeyName(1, "folder.ico")
      Me.imgGrabar.Images.SetKeyName(2, "row_add.ico")
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
      Me.TabControl1.TabIndex = 1
      '
      'TbpComprobantes
      '
      Me.TbpComprobantes.BackColor = System.Drawing.SystemColors.Control
      Me.TbpComprobantes.Controls.Add(Me.Label1)
      Me.TbpComprobantes.Controls.Add(Me.ugDetalle)
      Me.TbpComprobantes.Controls.Add(Me.chbTodos)
      Me.TbpComprobantes.Controls.Add(Me.btnExaminarComprobantes)
      Me.TbpComprobantes.Controls.Add(Me.txtArchivoDestinoComprobantes)
      Me.TbpComprobantes.Controls.Add(Me.lblArchivoDestinoComprobantes)
      Me.TbpComprobantes.Location = New System.Drawing.Point(4, 22)
      Me.TbpComprobantes.Name = "TbpComprobantes"
      Me.TbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
      Me.TbpComprobantes.Size = New System.Drawing.Size(962, 402)
      Me.TbpComprobantes.TabIndex = 0
      Me.TbpComprobantes.Text = "Comprobantes"
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
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn44.Header.Caption = "Procesar"
      UltraGridColumn44.Header.VisiblePosition = 0
      UltraGridColumn44.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn44.Width = 55
      UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn45.CellAppearance = Appearance2
      UltraGridColumn45.Header.Caption = "Línea"
      UltraGridColumn45.Header.VisiblePosition = 1
      UltraGridColumn45.Width = 40
      UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn46.Header.VisiblePosition = 2
      UltraGridColumn46.Hidden = True
      UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn47.Header.Caption = "Comprobante"
      UltraGridColumn47.Header.VisiblePosition = 3
      UltraGridColumn47.Width = 82
      UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn48.CellAppearance = Appearance3
      UltraGridColumn48.Header.VisiblePosition = 4
      UltraGridColumn48.Width = 40
      UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn49.CellAppearance = Appearance4
      UltraGridColumn49.Header.Caption = "Emisor"
      UltraGridColumn49.Header.VisiblePosition = 5
      UltraGridColumn49.Width = 45
      UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn50.CellAppearance = Appearance5
      UltraGridColumn50.Header.Caption = "Nro. Comp."
      UltraGridColumn50.Header.VisiblePosition = 6
      UltraGridColumn50.Width = 65
      UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance6.TextHAlignAsString = "Center"
      UltraGridColumn51.CellAppearance = Appearance6
      UltraGridColumn51.Format = "dd/MM/yyyy"
      UltraGridColumn51.Header.VisiblePosition = 8
      UltraGridColumn51.Width = 70
      UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn56.Header.Caption = "Categ. Fiscal"
      UltraGridColumn56.Header.VisiblePosition = 9
      UltraGridColumn56.Width = 70
      UltraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn57.Header.VisiblePosition = 10
      UltraGridColumn57.Width = 85
      UltraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn58.Header.Caption = "Proveedor"
      UltraGridColumn58.Header.VisiblePosition = 11
      UltraGridColumn58.Width = 150
      UltraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn59.CellAppearance = Appearance7
      UltraGridColumn59.Format = "N2"
      UltraGridColumn59.Header.Caption = "Bruto"
      UltraGridColumn59.Header.VisiblePosition = 12
      UltraGridColumn59.Width = 80
      UltraGridColumn60.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn60.CellAppearance = Appearance8
      UltraGridColumn60.Format = "N2"
      UltraGridColumn60.Header.VisiblePosition = 13
      UltraGridColumn60.Width = 80
      UltraGridColumn61.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn61.CellAppearance = Appearance9
      UltraGridColumn61.Format = "N2"
      UltraGridColumn61.Header.VisiblePosition = 14
      UltraGridColumn61.Width = 80
      UltraGridColumn62.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn62.CellAppearance = Appearance10
      UltraGridColumn62.Format = "N2"
      UltraGridColumn62.Header.VisiblePosition = 15
      UltraGridColumn62.Width = 80
      UltraGridColumn65.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn65.CellAppearance = Appearance11
      UltraGridColumn65.Format = "N2"
      UltraGridColumn65.Header.VisiblePosition = 17
      UltraGridColumn65.Width = 80
      UltraGridColumn66.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn66.Header.VisiblePosition = 18
      UltraGridColumn66.Hidden = True
      UltraGridColumn67.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn67.Header.VisiblePosition = 19
      UltraGridColumn67.Hidden = True
      UltraGridColumn88.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn88.Header.VisiblePosition = 20
      UltraGridColumn88.Hidden = True
      UltraGridColumn89.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance12.TextHAlignAsString = "Right"
      UltraGridColumn89.CellAppearance = Appearance12
      UltraGridColumn89.Header.Caption = "Cant. Alicuotas"
      UltraGridColumn89.Header.VisiblePosition = 21
      UltraGridColumn89.Width = 62
      UltraGridColumn90.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn90.Header.Caption = "Anulada"
      UltraGridColumn90.Header.VisiblePosition = 22
      UltraGridColumn90.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn90.Width = 56
      UltraGridColumn91.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn91.Header.Caption = "Error"
      UltraGridColumn91.Header.VisiblePosition = 23
      UltraGridColumn91.Width = 350
      UltraGridColumn92.Header.VisiblePosition = 24
      UltraGridColumn92.Hidden = True
      UltraGridColumn92.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn93.Header.Caption = "Despacho"
      UltraGridColumn93.Header.VisiblePosition = 7
      UltraGridColumn93.Hidden = True
      UltraGridColumn93.Width = 134
      UltraGridColumn94.Header.VisiblePosition = 25
      UltraGridColumn94.Hidden = True
      Appearance13.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance13
      UltraGridColumn1.Format = "N2"
      UltraGridColumn1.Header.Caption = "Imp. Internos"
      UltraGridColumn1.Header.VisiblePosition = 16
      UltraGridColumn1.Width = 80
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn1})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance14
      Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance16.BackColor2 = System.Drawing.SystemColors.Control
      Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance17
      Appearance18.BackColor = System.Drawing.SystemColors.Highlight
      Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance18
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance19
      Appearance20.BorderColor = System.Drawing.Color.Silver
      Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance20
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance21.BackColor = System.Drawing.SystemColors.Control
      Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance21.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance21
      Appearance22.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance22
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance23.BackColor = System.Drawing.SystemColors.Window
      Appearance23.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance23
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Location = New System.Drawing.Point(3, 19)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(953, 339)
      Me.ugDetalle.TabIndex = 9
      Me.ugDetalle.Text = "UltraGrid1"
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
      'btnExaminarComprobantes
      '
      Me.btnExaminarComprobantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminarComprobantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminarComprobantes.ImageKey = "folder.ico"
      Me.btnExaminarComprobantes.ImageList = Me.imgGrabar
      Me.btnExaminarComprobantes.Location = New System.Drawing.Point(612, 359)
      Me.btnExaminarComprobantes.Name = "btnExaminarComprobantes"
      Me.btnExaminarComprobantes.Size = New System.Drawing.Size(93, 40)
      Me.btnExaminarComprobantes.TabIndex = 4
      Me.btnExaminarComprobantes.Text = "&Examinar..."
      Me.btnExaminarComprobantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminarComprobantes.UseVisualStyleBackColor = True
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
      Me.tbpAlicuotas.Controls.Add(Me.ugAlicuotas)
      Me.tbpAlicuotas.Controls.Add(Me.CheckBox2)
      Me.tbpAlicuotas.Controls.Add(Me.btnExaminarAlicuotas)
      Me.tbpAlicuotas.Controls.Add(Me.txtArchivoDestinoAlicuotas)
      Me.tbpAlicuotas.Controls.Add(Me.lblArchivoDestinoAlicuotas)
      Me.tbpAlicuotas.Location = New System.Drawing.Point(4, 22)
      Me.tbpAlicuotas.Name = "tbpAlicuotas"
      Me.tbpAlicuotas.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpAlicuotas.Size = New System.Drawing.Size(962, 402)
      Me.tbpAlicuotas.TabIndex = 1
      Me.tbpAlicuotas.Text = "Alicuotas"
      '
      'ugAlicuotas
      '
      Me.ugAlicuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance25.BackColor = System.Drawing.SystemColors.Window
      Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugAlicuotas.DisplayLayout.Appearance = Appearance25
      UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn23.Header.Caption = "Procesar"
      UltraGridColumn23.Header.VisiblePosition = 0
      UltraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn23.Width = 55
      UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance26.TextHAlignAsString = "Right"
      UltraGridColumn24.CellAppearance = Appearance26
      UltraGridColumn24.Header.Caption = "Línea"
      UltraGridColumn24.Header.VisiblePosition = 1
      UltraGridColumn24.Width = 45
      UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn25.Header.VisiblePosition = 2
      UltraGridColumn25.Hidden = True
      UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn26.Header.Caption = "Comprobante"
      UltraGridColumn26.Header.VisiblePosition = 3
      UltraGridColumn26.Width = 80
      UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance27.TextHAlignAsString = "Center"
      UltraGridColumn27.CellAppearance = Appearance27
      UltraGridColumn27.Header.VisiblePosition = 4
      UltraGridColumn27.Width = 40
      UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance28.TextHAlignAsString = "Right"
      UltraGridColumn28.CellAppearance = Appearance28
      UltraGridColumn28.Header.Caption = "Emisor"
      UltraGridColumn28.Header.VisiblePosition = 5
      UltraGridColumn28.Width = 45
      UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance29.TextHAlignAsString = "Right"
      UltraGridColumn29.CellAppearance = Appearance29
      UltraGridColumn29.Header.Caption = "Nro. Comp."
      UltraGridColumn29.Header.VisiblePosition = 6
      UltraGridColumn29.Width = 90
      UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn30.Header.VisiblePosition = 7
      UltraGridColumn30.Hidden = True
      UltraGridColumn30.Width = 90
      UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn31.Header.VisiblePosition = 8
      UltraGridColumn31.Hidden = True
      UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn32.Header.VisiblePosition = 9
      UltraGridColumn32.Hidden = True
      UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn33.Header.VisiblePosition = 10
      UltraGridColumn33.Hidden = True
      UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance30.TextHAlignAsString = "Right"
      UltraGridColumn34.CellAppearance = Appearance30
      UltraGridColumn34.Format = "N2"
      UltraGridColumn34.Header.VisiblePosition = 11
      UltraGridColumn34.Width = 80
      UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance31.TextHAlignAsString = "Right"
      UltraGridColumn35.CellAppearance = Appearance31
      UltraGridColumn35.Header.Caption = "Alicuota"
      UltraGridColumn35.Header.VisiblePosition = 12
      UltraGridColumn35.Width = 70
      UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance32.TextHAlignAsString = "Right"
      UltraGridColumn36.CellAppearance = Appearance32
      UltraGridColumn36.Format = "N2"
      UltraGridColumn36.Header.VisiblePosition = 13
      UltraGridColumn36.Width = 80
      UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance33.TextHAlignAsString = "Right"
      UltraGridColumn37.CellAppearance = Appearance33
      UltraGridColumn37.Format = "N2"
      UltraGridColumn37.Header.VisiblePosition = 14
      UltraGridColumn37.Width = 80
      UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance34.TextHAlignAsString = "Right"
      UltraGridColumn38.CellAppearance = Appearance34
      UltraGridColumn38.Format = "N2"
      UltraGridColumn38.Header.VisiblePosition = 15
      UltraGridColumn38.Width = 80
      UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn39.Header.VisiblePosition = 16
      UltraGridColumn39.Hidden = True
      UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn40.Header.VisiblePosition = 17
      UltraGridColumn40.Hidden = True
      UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn41.Header.VisiblePosition = 18
      UltraGridColumn41.Hidden = True
      UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn42.Header.Caption = "Error"
      UltraGridColumn42.Header.VisiblePosition = 19
      UltraGridColumn42.Width = 350
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42})
      Me.ugAlicuotas.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.ugAlicuotas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugAlicuotas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance35.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance35.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance35.BorderColor = System.Drawing.SystemColors.Window
      Me.ugAlicuotas.DisplayLayout.GroupByBox.Appearance = Appearance35
      Appearance36.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugAlicuotas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance36
      Me.ugAlicuotas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance37.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance37.BackColor2 = System.Drawing.SystemColors.Control
      Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance37.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugAlicuotas.DisplayLayout.GroupByBox.PromptAppearance = Appearance37
      Me.ugAlicuotas.DisplayLayout.MaxColScrollRegions = 1
      Me.ugAlicuotas.DisplayLayout.MaxRowScrollRegions = 1
      Appearance38.BackColor = System.Drawing.SystemColors.Window
      Appearance38.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugAlicuotas.DisplayLayout.Override.ActiveCellAppearance = Appearance38
      Appearance39.BackColor = System.Drawing.SystemColors.Highlight
      Appearance39.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugAlicuotas.DisplayLayout.Override.ActiveRowAppearance = Appearance39
      Me.ugAlicuotas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugAlicuotas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance40.BackColor = System.Drawing.SystemColors.Window
      Me.ugAlicuotas.DisplayLayout.Override.CardAreaAppearance = Appearance40
      Appearance41.BorderColor = System.Drawing.Color.Silver
      Appearance41.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugAlicuotas.DisplayLayout.Override.CellAppearance = Appearance41
      Me.ugAlicuotas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugAlicuotas.DisplayLayout.Override.CellPadding = 0
      Appearance42.BackColor = System.Drawing.SystemColors.Control
      Appearance42.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance42.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance42.BorderColor = System.Drawing.SystemColors.Window
      Me.ugAlicuotas.DisplayLayout.Override.GroupByRowAppearance = Appearance42
      Appearance43.TextHAlignAsString = "Left"
      Me.ugAlicuotas.DisplayLayout.Override.HeaderAppearance = Appearance43
      Me.ugAlicuotas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugAlicuotas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance44.BackColor = System.Drawing.SystemColors.Window
      Appearance44.BorderColor = System.Drawing.Color.Silver
      Me.ugAlicuotas.DisplayLayout.Override.RowAppearance = Appearance44
      Me.ugAlicuotas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance45.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugAlicuotas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance45
      Me.ugAlicuotas.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugAlicuotas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugAlicuotas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugAlicuotas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugAlicuotas.Location = New System.Drawing.Point(3, 3)
      Me.ugAlicuotas.Name = "ugAlicuotas"
      Me.ugAlicuotas.Size = New System.Drawing.Size(953, 355)
      Me.ugAlicuotas.TabIndex = 37
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
      'btnExaminarAlicuotas
      '
      Me.btnExaminarAlicuotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminarAlicuotas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminarAlicuotas.ImageKey = "folder.ico"
      Me.btnExaminarAlicuotas.ImageList = Me.imgGrabar
      Me.btnExaminarAlicuotas.Location = New System.Drawing.Point(612, 359)
      Me.btnExaminarAlicuotas.Name = "btnExaminarAlicuotas"
      Me.btnExaminarAlicuotas.Size = New System.Drawing.Size(93, 40)
      Me.btnExaminarAlicuotas.TabIndex = 29
      Me.btnExaminarAlicuotas.Text = "&Examinar..."
      Me.btnExaminarAlicuotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminarAlicuotas.UseVisualStyleBackColor = True
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
      Me.tbpDespachoImportacion.Controls.Add(Me.chbDespacho)
      Me.tbpDespachoImportacion.Controls.Add(Me.txtArchivoDespacho)
      Me.tbpDespachoImportacion.Controls.Add(Me.Label2)
      Me.tbpDespachoImportacion.Controls.Add(Me.btnExaminarDespacho)
      Me.tbpDespachoImportacion.Controls.Add(Me.ugDespachoImportacion)
      Me.tbpDespachoImportacion.Location = New System.Drawing.Point(4, 22)
      Me.tbpDespachoImportacion.Name = "tbpDespachoImportacion"
      Me.tbpDespachoImportacion.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpDespachoImportacion.Size = New System.Drawing.Size(962, 402)
      Me.tbpDespachoImportacion.TabIndex = 2
      Me.tbpDespachoImportacion.Text = "Despacho Importación"
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
      'txtArchivoDespacho
      '
      Me.txtArchivoDespacho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtArchivoDespacho.BindearPropiedadControl = ""
      Me.txtArchivoDespacho.BindearPropiedadEntidad = ""
      Me.txtArchivoDespacho.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoDespacho.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoDespacho.Formato = ""
      Me.txtArchivoDespacho.IsDecimal = False
      Me.txtArchivoDespacho.IsNumber = False
      Me.txtArchivoDespacho.IsPK = False
      Me.txtArchivoDespacho.IsRequired = False
      Me.txtArchivoDespacho.Key = ""
      Me.txtArchivoDespacho.LabelAsoc = Me.Label2
      Me.txtArchivoDespacho.Location = New System.Drawing.Point(166, 369)
      Me.txtArchivoDespacho.Name = "txtArchivoDespacho"
      Me.txtArchivoDespacho.Size = New System.Drawing.Size(434, 20)
      Me.txtArchivoDespacho.TabIndex = 43
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
      'btnExaminarDespacho
      '
      Me.btnExaminarDespacho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminarDespacho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminarDespacho.ImageKey = "folder.ico"
      Me.btnExaminarDespacho.ImageList = Me.imgGrabar
      Me.btnExaminarDespacho.Location = New System.Drawing.Point(612, 359)
      Me.btnExaminarDespacho.Name = "btnExaminarDespacho"
      Me.btnExaminarDespacho.Size = New System.Drawing.Size(93, 40)
      Me.btnExaminarDespacho.TabIndex = 41
      Me.btnExaminarDespacho.Text = "&Examinar..."
      Me.btnExaminarDespacho.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminarDespacho.UseVisualStyleBackColor = True
      '
      'ugDespachoImportacion
      '
      Me.ugDespachoImportacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance46.BackColor = System.Drawing.SystemColors.Window
      Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDespachoImportacion.DisplayLayout.Appearance = Appearance46
      UltraGridColumn95.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn95.Header.Caption = "Procesar"
      UltraGridColumn95.Header.VisiblePosition = 0
      UltraGridColumn95.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn95.Width = 56
      Appearance47.TextHAlignAsString = "Right"
      UltraGridColumn96.CellAppearance = Appearance47
      UltraGridColumn96.Header.VisiblePosition = 2
      UltraGridColumn96.Width = 41
      UltraGridColumn97.Header.VisiblePosition = 1
      UltraGridColumn97.Hidden = True
      UltraGridColumn98.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn98.Header.VisiblePosition = 3
      UltraGridColumn98.Hidden = True
      UltraGridColumn99.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn99.Header.Caption = "Comprobante"
      UltraGridColumn99.Header.VisiblePosition = 4
      UltraGridColumn99.Hidden = True
      UltraGridColumn99.Width = 80
      UltraGridColumn100.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance48.TextHAlignAsString = "Center"
      UltraGridColumn100.CellAppearance = Appearance48
      UltraGridColumn100.Header.VisiblePosition = 5
      UltraGridColumn100.Hidden = True
      UltraGridColumn100.Width = 40
      UltraGridColumn101.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance49.TextHAlignAsString = "Right"
      UltraGridColumn101.CellAppearance = Appearance49
      UltraGridColumn101.Header.Caption = "Emisor"
      UltraGridColumn101.Header.VisiblePosition = 6
      UltraGridColumn101.Hidden = True
      UltraGridColumn101.Width = 45
      UltraGridColumn102.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance50.TextHAlignAsString = "Right"
      UltraGridColumn102.CellAppearance = Appearance50
      UltraGridColumn102.Header.Caption = "Nro. Comp."
      UltraGridColumn102.Header.VisiblePosition = 8
      UltraGridColumn102.Hidden = True
      UltraGridColumn102.Width = 90
      UltraGridColumn103.Header.Caption = "Despacho"
      UltraGridColumn103.Header.VisiblePosition = 7
      UltraGridColumn103.Width = 160
      UltraGridColumn104.Header.VisiblePosition = 9
      UltraGridColumn104.Hidden = True
      UltraGridColumn105.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn105.Header.VisiblePosition = 15
      UltraGridColumn105.Hidden = True
      UltraGridColumn106.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn106.Header.VisiblePosition = 17
      UltraGridColumn106.Hidden = True
      Appearance51.TextHAlignAsString = "Right"
      UltraGridColumn107.CellAppearance = Appearance51
      UltraGridColumn107.Format = "N2"
      UltraGridColumn107.Header.Caption = "Base Imponible"
      UltraGridColumn107.Header.VisiblePosition = 10
      Appearance52.TextHAlignAsString = "Right"
      UltraGridColumn108.CellAppearance = Appearance52
      UltraGridColumn108.Header.VisiblePosition = 11
      UltraGridColumn108.Hidden = True
      Appearance53.TextHAlignAsString = "Right"
      UltraGridColumn109.CellAppearance = Appearance53
      UltraGridColumn109.Format = "N2"
      UltraGridColumn109.Header.Caption = "Importe"
      UltraGridColumn109.Header.VisiblePosition = 13
      UltraGridColumn110.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance54.TextHAlignAsString = "Right"
      UltraGridColumn110.CellAppearance = Appearance54
      UltraGridColumn110.Format = "N2"
      UltraGridColumn110.Header.VisiblePosition = 14
      UltraGridColumn110.Width = 80
      Appearance55.TextHAlignAsString = "Right"
      UltraGridColumn111.CellAppearance = Appearance55
      UltraGridColumn111.Header.Caption = "Alicuota"
      UltraGridColumn111.Header.VisiblePosition = 12
      UltraGridColumn112.Header.Caption = "Error"
      UltraGridColumn112.Header.VisiblePosition = 16
      UltraGridColumn112.Width = 557
      UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112})
      Me.ugDespachoImportacion.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
      Me.ugDespachoImportacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDespachoImportacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance56.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance56.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDespachoImportacion.DisplayLayout.GroupByBox.Appearance = Appearance56
      Appearance57.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDespachoImportacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance57
      Me.ugDespachoImportacion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance58.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance58.BackColor2 = System.Drawing.SystemColors.Control
      Appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance58.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDespachoImportacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance58
      Me.ugDespachoImportacion.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDespachoImportacion.DisplayLayout.MaxRowScrollRegions = 1
      Appearance59.BackColor = System.Drawing.SystemColors.Window
      Appearance59.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDespachoImportacion.DisplayLayout.Override.ActiveCellAppearance = Appearance59
      Appearance60.BackColor = System.Drawing.SystemColors.Highlight
      Appearance60.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDespachoImportacion.DisplayLayout.Override.ActiveRowAppearance = Appearance60
      Me.ugDespachoImportacion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDespachoImportacion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance61.BackColor = System.Drawing.SystemColors.Window
      Me.ugDespachoImportacion.DisplayLayout.Override.CardAreaAppearance = Appearance61
      Appearance62.BorderColor = System.Drawing.Color.Silver
      Appearance62.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDespachoImportacion.DisplayLayout.Override.CellAppearance = Appearance62
      Me.ugDespachoImportacion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDespachoImportacion.DisplayLayout.Override.CellPadding = 0
      Appearance63.BackColor = System.Drawing.SystemColors.Control
      Appearance63.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance63.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance63.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDespachoImportacion.DisplayLayout.Override.GroupByRowAppearance = Appearance63
      Appearance64.TextHAlignAsString = "Left"
      Me.ugDespachoImportacion.DisplayLayout.Override.HeaderAppearance = Appearance64
      Me.ugDespachoImportacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDespachoImportacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance65.BackColor = System.Drawing.SystemColors.Window
      Appearance65.BorderColor = System.Drawing.Color.Silver
      Me.ugDespachoImportacion.DisplayLayout.Override.RowAppearance = Appearance65
      Me.ugDespachoImportacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance66.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDespachoImportacion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance66
      Me.ugDespachoImportacion.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDespachoImportacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDespachoImportacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDespachoImportacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDespachoImportacion.Location = New System.Drawing.Point(3, 3)
      Me.ugDespachoImportacion.Name = "ugDespachoImportacion"
      Me.ugDespachoImportacion.Size = New System.Drawing.Size(953, 355)
      Me.ugDespachoImportacion.TabIndex = 40
      Me.ugDespachoImportacion.Text = "UltraGrid2"
      '
      'CitiVentasBindingSource
      '
      Me.CitiVentasBindingSource.DataMember = "CitiVentas"
      Me.CitiVentasBindingSource.DataSource = Me.DsAFIP
      '
      'DsAFIP
      '
      Me.DsAFIP.DataSetName = "dsAFIP"
      Me.DsAFIP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'CitiVentasAlicuotasBindingSource
      '
      Me.CitiVentasAlicuotasBindingSource.DataMember = "CitiVentasAlicuotas"
      Me.CitiVentasAlicuotasBindingSource.DataSource = Me.DsAFIP
      '
      'ExportacionCitiCompras
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(987, 561)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ExportacionCitiCompras"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Exportacion para CITI Compras"
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
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
      CType(Me.CitiVentasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DsAFIP, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.CitiVentasAlicuotasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents DsAFIP As Eniac.Win.dsAFIP
   Friend WithEvents CitiVentasBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents tsbVerRegistrosConErrores As System.Windows.Forms.ToolStripButton
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents btnExaminarComprobantes As Eniac.Controles.Button
   Friend WithEvents txtArchivoDestinoComprobantes As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestinoComprobantes As Eniac.Controles.Label
   Friend WithEvents tbpAlicuotas As System.Windows.Forms.TabPage
   Friend WithEvents CheckBox2 As Eniac.Controles.CheckBox
   Friend WithEvents btnExaminarAlicuotas As Eniac.Controles.Button
   Friend WithEvents txtArchivoDestinoAlicuotas As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestinoAlicuotas As Eniac.Controles.Label
   Friend WithEvents CitiVentasAlicuotasBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents TipoDocProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugAlicuotas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents tbpDespachoImportacion As System.Windows.Forms.TabPage
   Friend WithEvents ugDespachoImportacion As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbDespacho As Eniac.Controles.CheckBox
   Friend WithEvents txtArchivoDespacho As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents btnExaminarDespacho As Eniac.Controles.Button
End Class
