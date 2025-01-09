<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportacionLibIvaDigVentas
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportacionLibIvaDigVentas))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Procesar")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobante")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoAlicuota")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Emisor")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteBruto")
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Neto")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Percepciones")
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestoInterno")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoDocumento")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadDeAlicuota")
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EstaAnulado")
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVto")
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadRealSinAlicuota")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Procesar")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Neto")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
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
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Procesar")
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea")
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobante")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaDeAnulacion")
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoError")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoComprobante")
      Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal")
      Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestos")
      Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tbcRegistros = New System.Windows.Forms.TabControl()
      Me.TbpComprobantes = New System.Windows.Forms.TabPage()
      Me.btnExaminarComprobantes = New Eniac.Controles.Button()
      Me.ugComprobantes = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.lblTotalesComp = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.txtImpuestosComp = New Eniac.Controles.TextBox()
      Me.txtTotalComp = New Eniac.Controles.TextBox()
      Me.txtArchivoDestinoComprobantes = New Eniac.Controles.TextBox()
      Me.lblArchivoDestinoComprobantes = New Eniac.Controles.Label()
      Me.txtSubtotalComp = New Eniac.Controles.TextBox()
      Me.tbpAlicuotas = New System.Windows.Forms.TabPage()
      Me.btnExaminarAlicuotas = New Eniac.Controles.Button()
      Me.ugAlicuotas = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.txtImpuestosAlic = New Eniac.Controles.TextBox()
      Me.txtTotalAlic = New Eniac.Controles.TextBox()
      Me.txtSubtotalAlic = New Eniac.Controles.TextBox()
      Me.lblTotalesAlic = New Eniac.Controles.Label()
      Me.txtArchivoDestinoAlicuotas = New Eniac.Controles.TextBox()
      Me.lblArchivoDestinoAlicuotas = New Eniac.Controles.Label()
      Me.tbpComprobantesAnulados = New System.Windows.Forms.TabPage()
      Me.btnExaminarComprobantesAnulados = New Eniac.Controles.Button()
      Me.txtImpuestosCompAnulados = New Eniac.Controles.TextBox()
      Me.txtTotalCompAnulados = New Eniac.Controles.TextBox()
      Me.txtSubTotalCompAnulados = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtArchivoDestinoComprobantesAnulados = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.ugComprobantesAnulados = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tbcRegistros.SuspendLayout()
        Me.TbpComprobantes.SuspendLayout()
        CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpAlicuotas.SuspendLayout()
        CType(Me.ugAlicuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpComprobantesAnulados.SuspendLayout()
        CType(Me.ugComprobantesAnulados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbExportar, Me.ToolStripSeparator5, Me.tsbVerRegistrosConErrores, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
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
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.dtpPeriodoFiscal)
        Me.grbFiltros.Controls.Add(Me.lblPeriodoFiscal)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(9, 33)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(965, 61)
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
        Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(105, 23)
        Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
        Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(65, 20)
        Me.dtpPeriodoFiscal.TabIndex = 1
        '
        'lblPeriodoFiscal
        '
        Me.lblPeriodoFiscal.AutoSize = True
        Me.lblPeriodoFiscal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriodoFiscal.LabelAsoc = Nothing
        Me.lblPeriodoFiscal.Location = New System.Drawing.Point(26, 27)
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
        Me.btnConsultar.Location = New System.Drawing.Point(197, 11)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 7
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
        'tbcRegistros
        '
        Me.tbcRegistros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcRegistros.Controls.Add(Me.TbpComprobantes)
        Me.tbcRegistros.Controls.Add(Me.tbpAlicuotas)
        Me.tbcRegistros.Controls.Add(Me.tbpComprobantesAnulados)
        Me.tbcRegistros.Location = New System.Drawing.Point(12, 100)
        Me.tbcRegistros.Name = "tbcRegistros"
        Me.tbcRegistros.SelectedIndex = 0
        Me.tbcRegistros.Size = New System.Drawing.Size(966, 436)
        Me.tbcRegistros.TabIndex = 8
        '
        'TbpComprobantes
        '
        Me.TbpComprobantes.BackColor = System.Drawing.SystemColors.Control
        Me.TbpComprobantes.Controls.Add(Me.btnExaminarComprobantes)
        Me.TbpComprobantes.Controls.Add(Me.ugComprobantes)
        Me.TbpComprobantes.Controls.Add(Me.lblTotalesComp)
        Me.TbpComprobantes.Controls.Add(Me.chbTodos)
        Me.TbpComprobantes.Controls.Add(Me.txtImpuestosComp)
        Me.TbpComprobantes.Controls.Add(Me.txtTotalComp)
        Me.TbpComprobantes.Controls.Add(Me.txtArchivoDestinoComprobantes)
        Me.TbpComprobantes.Controls.Add(Me.txtSubtotalComp)
        Me.TbpComprobantes.Controls.Add(Me.lblArchivoDestinoComprobantes)
        Me.TbpComprobantes.Location = New System.Drawing.Point(4, 22)
        Me.TbpComprobantes.Name = "TbpComprobantes"
        Me.TbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
        Me.TbpComprobantes.Size = New System.Drawing.Size(958, 410)
        Me.TbpComprobantes.TabIndex = 0
        Me.TbpComprobantes.Text = "Comprobantes"
        '
        'btnExaminarComprobantes
        '
        Me.btnExaminarComprobantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExaminarComprobantes.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnExaminarComprobantes.Image = CType(resources.GetObject("btnExaminarComprobantes.Image"), System.Drawing.Image)
        Me.btnExaminarComprobantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminarComprobantes.Location = New System.Drawing.Point(573, 352)
        Me.btnExaminarComprobantes.Name = "btnExaminarComprobantes"
        Me.btnExaminarComprobantes.Size = New System.Drawing.Size(104, 45)
        Me.btnExaminarComprobantes.TabIndex = 13
        Me.btnExaminarComprobantes.Text = "&Examinar..."
        Me.btnExaminarComprobantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminarComprobantes.UseVisualStyleBackColor = True
        '
        'ugComprobantes
        '
        Me.ugComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugComprobantes.DisplayLayout.Appearance = Appearance1
        UltraGridColumn12.Header.Caption = "P."
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.Width = 29
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn13.Width = 45
        UltraGridColumn14.Header.VisiblePosition = 2
        UltraGridColumn14.Width = 115
        UltraGridColumn15.Header.VisiblePosition = 3
        UltraGridColumn15.Width = 45
        UltraGridColumn18.Header.Caption = "AFIP"
        UltraGridColumn18.Header.VisiblePosition = 4
        UltraGridColumn19.Header.VisiblePosition = 5
        UltraGridColumn19.Width = 60
        UltraGridColumn20.Header.Caption = "Número Comp."
        UltraGridColumn20.Header.VisiblePosition = 6
        UltraGridColumn20.Width = 82
        UltraGridColumn21.Header.VisiblePosition = 7
        UltraGridColumn21.Width = 90
        UltraGridColumn24.Header.Caption = "Tipo Doc."
        UltraGridColumn24.Header.VisiblePosition = 8
        UltraGridColumn24.Width = 58
        UltraGridColumn25.Header.Caption = "Nro. Doc."
        UltraGridColumn25.Header.VisiblePosition = 9
        UltraGridColumn25.Width = 91
        UltraGridColumn31.Header.Caption = "Cliente"
        UltraGridColumn31.Header.VisiblePosition = 10
        UltraGridColumn31.Width = 232
        UltraGridColumn48.Header.Caption = "Categ. Fiscal"
        UltraGridColumn48.Header.VisiblePosition = 11
        UltraGridColumn48.Width = 87
        UltraGridColumn51.Header.Caption = "CUIT"
        UltraGridColumn51.Header.VisiblePosition = 12
        UltraGridColumn51.Width = 115
        UltraGridColumn52.Header.Caption = "Bruto"
        UltraGridColumn52.Header.VisiblePosition = 13
        UltraGridColumn53.Header.VisiblePosition = 14
        UltraGridColumn54.Header.VisiblePosition = 15
        UltraGridColumn54.Width = 102
        UltraGridColumn55.Header.VisiblePosition = 16
        UltraGridColumn55.Width = 102
        UltraGridColumn56.Header.Caption = "Imp. Interno"
        UltraGridColumn56.Header.VisiblePosition = 17
        UltraGridColumn57.Header.VisiblePosition = 18
        UltraGridColumn57.Width = 101
        UltraGridColumn58.Header.VisiblePosition = 19
        UltraGridColumn58.Hidden = True
        UltraGridColumn59.Header.VisiblePosition = 20
        UltraGridColumn59.Hidden = True
        UltraGridColumn60.Header.Caption = "Cant. Alícuotas"
        UltraGridColumn60.Header.VisiblePosition = 21
        UltraGridColumn60.Width = 71
        UltraGridColumn61.Header.Caption = "Anulada"
        UltraGridColumn61.Header.VisiblePosition = 22
        UltraGridColumn61.Width = 60
        UltraGridColumn62.Header.Caption = "Error"
        UltraGridColumn62.Header.VisiblePosition = 23
        UltraGridColumn62.Width = 600
        UltraGridColumn63.Header.VisiblePosition = 24
        UltraGridColumn63.Hidden = True
        UltraGridColumn64.Header.VisiblePosition = 25
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn24, UltraGridColumn25, UltraGridColumn31, UltraGridColumn48, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64})
        Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugComprobantes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComprobantes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugComprobantes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugComprobantes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugComprobantes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugComprobantes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugComprobantes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugComprobantes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugComprobantes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugComprobantes.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugComprobantes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugComprobantes.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugComprobantes.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugComprobantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugComprobantes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugComprobantes.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugComprobantes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugComprobantes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugComprobantes.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugComprobantes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugComprobantes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugComprobantes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugComprobantes.Location = New System.Drawing.Point(6, 6)
        Me.ugComprobantes.Name = "ugComprobantes"
        Me.ugComprobantes.Size = New System.Drawing.Size(946, 331)
        Me.ugComprobantes.TabIndex = 8
        Me.ugComprobantes.Text = "UltraGrid1"
        '
        'lblTotalesComp
        '
        Me.lblTotalesComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalesComp.AutoSize = True
        Me.lblTotalesComp.LabelAsoc = Nothing
        Me.lblTotalesComp.Location = New System.Drawing.Point(693, 347)
        Me.lblTotalesComp.Name = "lblTotalesComp"
        Me.lblTotalesComp.Size = New System.Drawing.Size(45, 13)
        Me.lblTotalesComp.TabIndex = 4
        Me.lblTotalesComp.Text = "Totales:"
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
        Me.chbTodos.Location = New System.Drawing.Point(9, 343)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(56, 17)
        Me.chbTodos.TabIndex = 0
        Me.chbTodos.Text = "Todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'txtImpuestosComp
        '
        Me.txtImpuestosComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImpuestosComp.BindearPropiedadControl = Nothing
        Me.txtImpuestosComp.BindearPropiedadEntidad = Nothing
        Me.txtImpuestosComp.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImpuestosComp.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImpuestosComp.Formato = "##0.00"
        Me.txtImpuestosComp.IsDecimal = True
        Me.txtImpuestosComp.IsNumber = True
        Me.txtImpuestosComp.IsPK = False
        Me.txtImpuestosComp.IsRequired = False
        Me.txtImpuestosComp.Key = ""
        Me.txtImpuestosComp.LabelAsoc = Nothing
        Me.txtImpuestosComp.Location = New System.Drawing.Point(814, 343)
        Me.txtImpuestosComp.Name = "txtImpuestosComp"
        Me.txtImpuestosComp.ReadOnly = True
        Me.txtImpuestosComp.Size = New System.Drawing.Size(70, 20)
        Me.txtImpuestosComp.TabIndex = 6
        Me.txtImpuestosComp.Text = "0.00"
        Me.txtImpuestosComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalComp
        '
        Me.txtTotalComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalComp.BindearPropiedadControl = Nothing
        Me.txtTotalComp.BindearPropiedadEntidad = Nothing
        Me.txtTotalComp.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalComp.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalComp.Formato = ""
        Me.txtTotalComp.IsDecimal = False
        Me.txtTotalComp.IsNumber = False
        Me.txtTotalComp.IsPK = False
        Me.txtTotalComp.IsRequired = False
        Me.txtTotalComp.Key = ""
        Me.txtTotalComp.LabelAsoc = Nothing
        Me.txtTotalComp.Location = New System.Drawing.Point(884, 343)
        Me.txtTotalComp.Name = "txtTotalComp"
        Me.txtTotalComp.ReadOnly = True
        Me.txtTotalComp.Size = New System.Drawing.Size(70, 20)
        Me.txtTotalComp.TabIndex = 7
        Me.txtTotalComp.Text = "0.00"
        Me.txtTotalComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtArchivoDestinoComprobantes.Location = New System.Drawing.Point(104, 364)
        Me.txtArchivoDestinoComprobantes.Name = "txtArchivoDestinoComprobantes"
        Me.txtArchivoDestinoComprobantes.Size = New System.Drawing.Size(463, 20)
        Me.txtArchivoDestinoComprobantes.TabIndex = 2
        '
        'lblArchivoDestinoComprobantes
        '
        Me.lblArchivoDestinoComprobantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArchivoDestinoComprobantes.AutoSize = True
        Me.lblArchivoDestinoComprobantes.LabelAsoc = Nothing
        Me.lblArchivoDestinoComprobantes.Location = New System.Drawing.Point(13, 368)
        Me.lblArchivoDestinoComprobantes.Name = "lblArchivoDestinoComprobantes"
        Me.lblArchivoDestinoComprobantes.Size = New System.Drawing.Size(85, 13)
        Me.lblArchivoDestinoComprobantes.TabIndex = 1
        Me.lblArchivoDestinoComprobantes.Text = "Archivo Destino:"
        '
        'txtSubtotalComp
        '
        Me.txtSubtotalComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotalComp.BindearPropiedadControl = Nothing
        Me.txtSubtotalComp.BindearPropiedadEntidad = Nothing
        Me.txtSubtotalComp.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSubtotalComp.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSubtotalComp.Formato = "##0.00"
        Me.txtSubtotalComp.IsDecimal = True
        Me.txtSubtotalComp.IsNumber = True
        Me.txtSubtotalComp.IsPK = False
        Me.txtSubtotalComp.IsRequired = False
        Me.txtSubtotalComp.Key = ""
        Me.txtSubtotalComp.LabelAsoc = Nothing
        Me.txtSubtotalComp.Location = New System.Drawing.Point(744, 343)
        Me.txtSubtotalComp.Name = "txtSubtotalComp"
        Me.txtSubtotalComp.ReadOnly = True
        Me.txtSubtotalComp.Size = New System.Drawing.Size(70, 20)
        Me.txtSubtotalComp.TabIndex = 5
        Me.txtSubtotalComp.Text = "0.00"
        Me.txtSubtotalComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbpAlicuotas
        '
        Me.tbpAlicuotas.BackColor = System.Drawing.SystemColors.Control
        Me.tbpAlicuotas.Controls.Add(Me.btnExaminarAlicuotas)
        Me.tbpAlicuotas.Controls.Add(Me.ugAlicuotas)
        Me.tbpAlicuotas.Controls.Add(Me.txtImpuestosAlic)
        Me.tbpAlicuotas.Controls.Add(Me.txtTotalAlic)
        Me.tbpAlicuotas.Controls.Add(Me.txtSubtotalAlic)
        Me.tbpAlicuotas.Controls.Add(Me.lblTotalesAlic)
        Me.tbpAlicuotas.Controls.Add(Me.txtArchivoDestinoAlicuotas)
        Me.tbpAlicuotas.Controls.Add(Me.lblArchivoDestinoAlicuotas)
        Me.tbpAlicuotas.Location = New System.Drawing.Point(4, 22)
        Me.tbpAlicuotas.Name = "tbpAlicuotas"
        Me.tbpAlicuotas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAlicuotas.Size = New System.Drawing.Size(958, 410)
        Me.tbpAlicuotas.TabIndex = 1
        Me.tbpAlicuotas.Text = "Alicuotas"
        '
        'btnExaminarAlicuotas
        '
        Me.btnExaminarAlicuotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExaminarAlicuotas.Image = CType(resources.GetObject("btnExaminarAlicuotas.Image"), System.Drawing.Image)
        Me.btnExaminarAlicuotas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminarAlicuotas.Location = New System.Drawing.Point(568, 352)
        Me.btnExaminarAlicuotas.Name = "btnExaminarAlicuotas"
        Me.btnExaminarAlicuotas.Size = New System.Drawing.Size(104, 45)
        Me.btnExaminarAlicuotas.TabIndex = 35
        Me.btnExaminarAlicuotas.Text = "&Examinar..."
        Me.btnExaminarAlicuotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminarAlicuotas.UseVisualStyleBackColor = True
        '
        'ugAlicuotas
        '
        Me.ugAlicuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugAlicuotas.DisplayLayout.Appearance = Appearance13
        UltraGridColumn1.Header.Caption = "P."
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 29
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 42
        UltraGridColumn9.Header.Caption = "Comprobante"
        UltraGridColumn9.Header.VisiblePosition = 2
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn23.Header.Caption = "Emisor"
        UltraGridColumn23.Header.VisiblePosition = 4
        UltraGridColumn7.Header.Caption = "Nro. Comp."
        UltraGridColumn7.Header.VisiblePosition = 5
        UltraGridColumn16.Header.VisiblePosition = 6
        UltraGridColumn17.Header.VisiblePosition = 7
        UltraGridColumn22.Header.VisiblePosition = 8
        UltraGridColumn26.Header.Caption = "Error"
        UltraGridColumn26.Header.VisiblePosition = 9
        UltraGridColumn26.Width = 600
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn9, UltraGridColumn4, UltraGridColumn23, UltraGridColumn7, UltraGridColumn16, UltraGridColumn17, UltraGridColumn22, UltraGridColumn26})
        Me.ugAlicuotas.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugAlicuotas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAlicuotas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAlicuotas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.ugAlicuotas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAlicuotas.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.ugAlicuotas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugAlicuotas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugAlicuotas.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugAlicuotas.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.ugAlicuotas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugAlicuotas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugAlicuotas.DisplayLayout.Override.CellAppearance = Appearance20
        Me.ugAlicuotas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugAlicuotas.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.ugAlicuotas.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.ugAlicuotas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugAlicuotas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.ugAlicuotas.DisplayLayout.Override.RowAppearance = Appearance23
        Me.ugAlicuotas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugAlicuotas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.ugAlicuotas.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAlicuotas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugAlicuotas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugAlicuotas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugAlicuotas.Location = New System.Drawing.Point(6, 6)
        Me.ugAlicuotas.Name = "ugAlicuotas"
        Me.ugAlicuotas.Size = New System.Drawing.Size(946, 331)
        Me.ugAlicuotas.TabIndex = 34
        Me.ugAlicuotas.Text = "UltraGrid1"
        '
        'txtImpuestosAlic
        '
        Me.txtImpuestosAlic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImpuestosAlic.BindearPropiedadControl = Nothing
        Me.txtImpuestosAlic.BindearPropiedadEntidad = Nothing
        Me.txtImpuestosAlic.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImpuestosAlic.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImpuestosAlic.Formato = "##0.00"
        Me.txtImpuestosAlic.IsDecimal = True
        Me.txtImpuestosAlic.IsNumber = True
        Me.txtImpuestosAlic.IsPK = False
        Me.txtImpuestosAlic.IsRequired = False
        Me.txtImpuestosAlic.Key = ""
        Me.txtImpuestosAlic.LabelAsoc = Nothing
        Me.txtImpuestosAlic.Location = New System.Drawing.Point(805, 344)
        Me.txtImpuestosAlic.Name = "txtImpuestosAlic"
        Me.txtImpuestosAlic.ReadOnly = True
        Me.txtImpuestosAlic.Size = New System.Drawing.Size(70, 20)
        Me.txtImpuestosAlic.TabIndex = 32
        Me.txtImpuestosAlic.Text = "0.00"
        Me.txtImpuestosAlic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalAlic
        '
        Me.txtTotalAlic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAlic.BindearPropiedadControl = Nothing
        Me.txtTotalAlic.BindearPropiedadEntidad = Nothing
        Me.txtTotalAlic.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalAlic.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalAlic.Formato = ""
        Me.txtTotalAlic.IsDecimal = False
        Me.txtTotalAlic.IsNumber = False
        Me.txtTotalAlic.IsPK = False
        Me.txtTotalAlic.IsRequired = False
        Me.txtTotalAlic.Key = ""
        Me.txtTotalAlic.LabelAsoc = Nothing
        Me.txtTotalAlic.Location = New System.Drawing.Point(875, 344)
        Me.txtTotalAlic.Name = "txtTotalAlic"
        Me.txtTotalAlic.ReadOnly = True
        Me.txtTotalAlic.Size = New System.Drawing.Size(70, 20)
        Me.txtTotalAlic.TabIndex = 33
        Me.txtTotalAlic.Text = "0.00"
        Me.txtTotalAlic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubtotalAlic
        '
        Me.txtSubtotalAlic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotalAlic.BindearPropiedadControl = Nothing
        Me.txtSubtotalAlic.BindearPropiedadEntidad = Nothing
        Me.txtSubtotalAlic.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSubtotalAlic.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSubtotalAlic.Formato = "##0.00"
        Me.txtSubtotalAlic.IsDecimal = True
        Me.txtSubtotalAlic.IsNumber = True
        Me.txtSubtotalAlic.IsPK = False
        Me.txtSubtotalAlic.IsRequired = False
        Me.txtSubtotalAlic.Key = ""
        Me.txtSubtotalAlic.LabelAsoc = Nothing
        Me.txtSubtotalAlic.Location = New System.Drawing.Point(735, 344)
        Me.txtSubtotalAlic.Name = "txtSubtotalAlic"
        Me.txtSubtotalAlic.ReadOnly = True
        Me.txtSubtotalAlic.Size = New System.Drawing.Size(70, 20)
        Me.txtSubtotalAlic.TabIndex = 31
        Me.txtSubtotalAlic.Text = "0.00"
        Me.txtSubtotalAlic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalesAlic
        '
        Me.lblTotalesAlic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalesAlic.AutoSize = True
        Me.lblTotalesAlic.LabelAsoc = Nothing
        Me.lblTotalesAlic.Location = New System.Drawing.Point(688, 347)
        Me.lblTotalesAlic.Name = "lblTotalesAlic"
        Me.lblTotalesAlic.Size = New System.Drawing.Size(45, 13)
        Me.lblTotalesAlic.TabIndex = 26
        Me.lblTotalesAlic.Text = "Totales:"
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
        Me.txtArchivoDestinoAlicuotas.Location = New System.Drawing.Point(99, 364)
        Me.txtArchivoDestinoAlicuotas.Name = "txtArchivoDestinoAlicuotas"
        Me.txtArchivoDestinoAlicuotas.Size = New System.Drawing.Size(463, 20)
        Me.txtArchivoDestinoAlicuotas.TabIndex = 28
        '
        'lblArchivoDestinoAlicuotas
        '
        Me.lblArchivoDestinoAlicuotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArchivoDestinoAlicuotas.AutoSize = True
        Me.lblArchivoDestinoAlicuotas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArchivoDestinoAlicuotas.LabelAsoc = Nothing
        Me.lblArchivoDestinoAlicuotas.Location = New System.Drawing.Point(8, 368)
        Me.lblArchivoDestinoAlicuotas.Name = "lblArchivoDestinoAlicuotas"
        Me.lblArchivoDestinoAlicuotas.Size = New System.Drawing.Size(85, 13)
        Me.lblArchivoDestinoAlicuotas.TabIndex = 27
        Me.lblArchivoDestinoAlicuotas.Text = "Archivo Destino:"
        '
        'tbpComprobantesAnulados
        '
        Me.tbpComprobantesAnulados.Controls.Add(Me.btnExaminarComprobantesAnulados)
        Me.tbpComprobantesAnulados.Controls.Add(Me.txtImpuestosCompAnulados)
        Me.tbpComprobantesAnulados.Controls.Add(Me.txtTotalCompAnulados)
        Me.tbpComprobantesAnulados.Controls.Add(Me.txtSubTotalCompAnulados)
        Me.tbpComprobantesAnulados.Controls.Add(Me.Label1)
        Me.tbpComprobantesAnulados.Controls.Add(Me.txtArchivoDestinoComprobantesAnulados)
        Me.tbpComprobantesAnulados.Controls.Add(Me.Label2)
        Me.tbpComprobantesAnulados.Controls.Add(Me.ugComprobantesAnulados)
        Me.tbpComprobantesAnulados.Location = New System.Drawing.Point(4, 22)
        Me.tbpComprobantesAnulados.Name = "tbpComprobantesAnulados"
        Me.tbpComprobantesAnulados.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpComprobantesAnulados.Size = New System.Drawing.Size(958, 410)
        Me.tbpComprobantesAnulados.TabIndex = 2
        Me.tbpComprobantesAnulados.Text = "Comprobantes Anulados"
        Me.tbpComprobantesAnulados.UseVisualStyleBackColor = True
        '
        'btnExaminarComprobantesAnulados
        '
        Me.btnExaminarComprobantesAnulados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExaminarComprobantesAnulados.Image = CType(resources.GetObject("btnExaminarComprobantesAnulados.Image"), System.Drawing.Image)
        Me.btnExaminarComprobantesAnulados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminarComprobantesAnulados.Location = New System.Drawing.Point(570, 348)
        Me.btnExaminarComprobantesAnulados.Name = "btnExaminarComprobantesAnulados"
        Me.btnExaminarComprobantesAnulados.Size = New System.Drawing.Size(104, 45)
        Me.btnExaminarComprobantesAnulados.TabIndex = 42
        Me.btnExaminarComprobantesAnulados.Text = "Examinar..."
        Me.btnExaminarComprobantesAnulados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminarComprobantesAnulados.UseVisualStyleBackColor = True
        '
        'txtImpuestosCompAnulados
        '
        Me.txtImpuestosCompAnulados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImpuestosCompAnulados.BindearPropiedadControl = Nothing
        Me.txtImpuestosCompAnulados.BindearPropiedadEntidad = Nothing
        Me.txtImpuestosCompAnulados.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImpuestosCompAnulados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImpuestosCompAnulados.Formato = "##0.00"
        Me.txtImpuestosCompAnulados.IsDecimal = True
        Me.txtImpuestosCompAnulados.IsNumber = True
        Me.txtImpuestosCompAnulados.IsPK = False
        Me.txtImpuestosCompAnulados.IsRequired = False
        Me.txtImpuestosCompAnulados.Key = ""
        Me.txtImpuestosCompAnulados.LabelAsoc = Nothing
        Me.txtImpuestosCompAnulados.Location = New System.Drawing.Point(807, 340)
        Me.txtImpuestosCompAnulados.Name = "txtImpuestosCompAnulados"
        Me.txtImpuestosCompAnulados.ReadOnly = True
        Me.txtImpuestosCompAnulados.Size = New System.Drawing.Size(70, 20)
        Me.txtImpuestosCompAnulados.TabIndex = 40
        Me.txtImpuestosCompAnulados.Text = "0.00"
        Me.txtImpuestosCompAnulados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCompAnulados
        '
        Me.txtTotalCompAnulados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCompAnulados.BindearPropiedadControl = Nothing
        Me.txtTotalCompAnulados.BindearPropiedadEntidad = Nothing
        Me.txtTotalCompAnulados.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalCompAnulados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalCompAnulados.Formato = ""
        Me.txtTotalCompAnulados.IsDecimal = False
        Me.txtTotalCompAnulados.IsNumber = False
        Me.txtTotalCompAnulados.IsPK = False
        Me.txtTotalCompAnulados.IsRequired = False
        Me.txtTotalCompAnulados.Key = ""
        Me.txtTotalCompAnulados.LabelAsoc = Nothing
        Me.txtTotalCompAnulados.Location = New System.Drawing.Point(877, 340)
        Me.txtTotalCompAnulados.Name = "txtTotalCompAnulados"
        Me.txtTotalCompAnulados.ReadOnly = True
        Me.txtTotalCompAnulados.Size = New System.Drawing.Size(70, 20)
        Me.txtTotalCompAnulados.TabIndex = 41
        Me.txtTotalCompAnulados.Text = "0.00"
        Me.txtTotalCompAnulados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotalCompAnulados
        '
        Me.txtSubTotalCompAnulados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotalCompAnulados.BindearPropiedadControl = Nothing
        Me.txtSubTotalCompAnulados.BindearPropiedadEntidad = Nothing
        Me.txtSubTotalCompAnulados.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSubTotalCompAnulados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSubTotalCompAnulados.Formato = "##0.00"
        Me.txtSubTotalCompAnulados.IsDecimal = True
        Me.txtSubTotalCompAnulados.IsNumber = True
        Me.txtSubTotalCompAnulados.IsPK = False
        Me.txtSubTotalCompAnulados.IsRequired = False
        Me.txtSubTotalCompAnulados.Key = ""
        Me.txtSubTotalCompAnulados.LabelAsoc = Nothing
        Me.txtSubTotalCompAnulados.Location = New System.Drawing.Point(737, 340)
        Me.txtSubTotalCompAnulados.Name = "txtSubTotalCompAnulados"
        Me.txtSubTotalCompAnulados.ReadOnly = True
        Me.txtSubTotalCompAnulados.Size = New System.Drawing.Size(70, 20)
        Me.txtSubTotalCompAnulados.TabIndex = 39
        Me.txtSubTotalCompAnulados.Text = "0.00"
        Me.txtSubTotalCompAnulados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(690, 343)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Totales:"
        '
        'txtArchivoDestinoComprobantesAnulados
        '
        Me.txtArchivoDestinoComprobantesAnulados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtArchivoDestinoComprobantesAnulados.BindearPropiedadControl = ""
        Me.txtArchivoDestinoComprobantesAnulados.BindearPropiedadEntidad = ""
        Me.txtArchivoDestinoComprobantesAnulados.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoDestinoComprobantesAnulados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoDestinoComprobantesAnulados.Formato = ""
        Me.txtArchivoDestinoComprobantesAnulados.IsDecimal = False
        Me.txtArchivoDestinoComprobantesAnulados.IsNumber = False
        Me.txtArchivoDestinoComprobantesAnulados.IsPK = False
        Me.txtArchivoDestinoComprobantesAnulados.IsRequired = False
        Me.txtArchivoDestinoComprobantesAnulados.Key = ""
        Me.txtArchivoDestinoComprobantesAnulados.LabelAsoc = Me.Label2
        Me.txtArchivoDestinoComprobantesAnulados.Location = New System.Drawing.Point(101, 360)
        Me.txtArchivoDestinoComprobantesAnulados.Name = "txtArchivoDestinoComprobantesAnulados"
        Me.txtArchivoDestinoComprobantesAnulados.Size = New System.Drawing.Size(463, 20)
        Me.txtArchivoDestinoComprobantesAnulados.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(10, 364)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Archivo Destino:"
        '
        'ugComprobantesAnulados
        '
        Me.ugComprobantesAnulados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugComprobantesAnulados.DisplayLayout.Appearance = Appearance25
        Appearance26.TextHAlignAsString = "Center"
        UltraGridColumn27.CellAppearance = Appearance26
        UltraGridColumn27.Header.Caption = "P."
        UltraGridColumn27.Header.VisiblePosition = 0
        UltraGridColumn27.Width = 29
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance27.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance27
        UltraGridColumn28.Header.VisiblePosition = 1
        UltraGridColumn28.Width = 45
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance28.TextHAlignAsString = "Center"
        UltraGridColumn34.CellAppearance = Appearance28
        UltraGridColumn34.Header.VisiblePosition = 2
        UltraGridColumn34.Width = 90
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn29.Header.Caption = "IdTipoComprobante"
        UltraGridColumn29.Header.VisiblePosition = 4
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Width = 115
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance29.TextHAlignAsString = "Center"
        UltraGridColumn30.CellAppearance = Appearance29
        UltraGridColumn30.Header.VisiblePosition = 5
        UltraGridColumn30.Width = 45
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance30.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance30
        UltraGridColumn5.Header.Caption = "Emisor"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance31
        UltraGridColumn33.Header.Caption = "Núm. Comp."
        UltraGridColumn33.Header.VisiblePosition = 7
        UltraGridColumn33.Width = 82
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance32.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance32
        UltraGridColumn3.Header.Caption = "Fecha de Anulación"
        UltraGridColumn3.Header.VisiblePosition = 12
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn35.Header.Caption = "Tipo Doc."
        UltraGridColumn35.Header.VisiblePosition = 9
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 58
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance33.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance33
        UltraGridColumn36.Header.Caption = "Nro. Doc."
        UltraGridColumn36.Header.VisiblePosition = 10
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 91
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn37.Header.Caption = "Cliente"
        UltraGridColumn37.Header.VisiblePosition = 8
        UltraGridColumn37.Width = 166
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance34.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance34
        UltraGridColumn39.Header.Caption = "CUIT"
        UltraGridColumn39.Header.VisiblePosition = 11
        UltraGridColumn39.Width = 94
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "Error"
        UltraGridColumn6.Header.VisiblePosition = 13
        UltraGridColumn6.Width = 600
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.Caption = "Comprobante"
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance35.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance35
        UltraGridColumn10.Header.VisiblePosition = 14
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance36
        UltraGridColumn11.Header.VisiblePosition = 15
        UltraGridColumn11.Hidden = True
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance37.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance37
        UltraGridColumn32.Header.Caption = "Impuestos"
        UltraGridColumn32.Header.VisiblePosition = 16
        UltraGridColumn32.Hidden = True
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance38.TextHAlignAsString = "Right"
        UltraGridColumn38.CellAppearance = Appearance38
        UltraGridColumn38.Header.Caption = "Total"
        UltraGridColumn38.Header.VisiblePosition = 17
        UltraGridColumn38.Hidden = True
        UltraGridColumn40.Header.VisiblePosition = 18
        UltraGridColumn40.Hidden = True
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn27, UltraGridColumn28, UltraGridColumn34, UltraGridColumn29, UltraGridColumn30, UltraGridColumn5, UltraGridColumn33, UltraGridColumn3, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn39, UltraGridColumn6, UltraGridColumn8, UltraGridColumn10, UltraGridColumn11, UltraGridColumn32, UltraGridColumn38, UltraGridColumn40})
        Me.ugComprobantesAnulados.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugComprobantesAnulados.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComprobantesAnulados.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance39.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance39.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantesAnulados.DisplayLayout.GroupByBox.Appearance = Appearance39
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantesAnulados.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance40
        Me.ugComprobantesAnulados.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance41.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance41.BackColor2 = System.Drawing.SystemColors.Control
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance41.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantesAnulados.DisplayLayout.GroupByBox.PromptAppearance = Appearance41
        Me.ugComprobantesAnulados.DisplayLayout.MaxColScrollRegions = 1
        Me.ugComprobantesAnulados.DisplayLayout.MaxRowScrollRegions = 1
        Appearance42.BackColor = System.Drawing.SystemColors.Window
        Appearance42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugComprobantesAnulados.DisplayLayout.Override.ActiveCellAppearance = Appearance42
        Appearance43.BackColor = System.Drawing.SystemColors.Highlight
        Appearance43.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugComprobantesAnulados.DisplayLayout.Override.ActiveRowAppearance = Appearance43
        Me.ugComprobantesAnulados.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugComprobantesAnulados.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Me.ugComprobantesAnulados.DisplayLayout.Override.CardAreaAppearance = Appearance44
        Appearance45.BorderColor = System.Drawing.Color.Silver
        Appearance45.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugComprobantesAnulados.DisplayLayout.Override.CellAppearance = Appearance45
        Me.ugComprobantesAnulados.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugComprobantesAnulados.DisplayLayout.Override.CellPadding = 0
        Appearance46.BackColor = System.Drawing.SystemColors.Control
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantesAnulados.DisplayLayout.Override.GroupByRowAppearance = Appearance46
        Appearance47.TextHAlignAsString = "Left"
        Me.ugComprobantesAnulados.DisplayLayout.Override.HeaderAppearance = Appearance47
        Me.ugComprobantesAnulados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugComprobantesAnulados.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance48.BackColor = System.Drawing.SystemColors.Window
        Appearance48.BorderColor = System.Drawing.Color.Silver
        Me.ugComprobantesAnulados.DisplayLayout.Override.RowAppearance = Appearance48
        Me.ugComprobantesAnulados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance49.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugComprobantesAnulados.DisplayLayout.Override.TemplateAddRowAppearance = Appearance49
        Me.ugComprobantesAnulados.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugComprobantesAnulados.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugComprobantesAnulados.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugComprobantesAnulados.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugComprobantesAnulados.Location = New System.Drawing.Point(6, 3)
        Me.ugComprobantesAnulados.Name = "ugComprobantesAnulados"
        Me.ugComprobantesAnulados.Size = New System.Drawing.Size(946, 331)
        Me.ugComprobantesAnulados.TabIndex = 9
        Me.ugComprobantesAnulados.Text = "Comprobantes Anulados"
        '
        'imgIconos
        '
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIconos.Images.SetKeyName(0, "find.ico")
        '
        'imgGrabar
        '
        Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
        Me.imgGrabar.Images.SetKeyName(0, "document_find.ico")
        Me.imgGrabar.Images.SetKeyName(1, "folder.ico")
        Me.imgGrabar.Images.SetKeyName(2, "row_add.ico")
        '
        'ExportacionLibIvaDigVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.tbcRegistros)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ExportacionLibIvaDigVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Libro IVA Digital Ventas"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tbcRegistros.ResumeLayout(False)
        Me.TbpComprobantes.ResumeLayout(False)
        Me.TbpComprobantes.PerformLayout()
        CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpAlicuotas.ResumeLayout(False)
        Me.tbpAlicuotas.PerformLayout()
        CType(Me.ugAlicuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpComprobantesAnulados.ResumeLayout(False)
        Me.tbpComprobantesAnulados.PerformLayout()
        CType(Me.ugComprobantesAnulados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tbcRegistros As System.Windows.Forms.TabControl
   Friend WithEvents TbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents lblTotalesComp As Eniac.Controles.Label
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents txtImpuestosComp As Eniac.Controles.TextBox
   Friend WithEvents txtTotalComp As Eniac.Controles.TextBox
   Friend WithEvents txtArchivoDestinoComprobantes As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestinoComprobantes As Eniac.Controles.Label
   Friend WithEvents txtSubtotalComp As Eniac.Controles.TextBox
   Friend WithEvents tbpAlicuotas As System.Windows.Forms.TabPage
   Friend WithEvents txtImpuestosAlic As Eniac.Controles.TextBox
   Friend WithEvents txtTotalAlic As Eniac.Controles.TextBox
   Friend WithEvents txtSubtotalAlic As Eniac.Controles.TextBox
   Friend WithEvents lblTotalesAlic As Eniac.Controles.Label
   Friend WithEvents txtArchivoDestinoAlicuotas As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestinoAlicuotas As Eniac.Controles.Label
   Friend WithEvents ugComprobantes As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugAlicuotas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents btnExaminarComprobantes As Eniac.Controles.Button
   Friend WithEvents btnExaminarAlicuotas As Eniac.Controles.Button
   Friend WithEvents tbpComprobantesAnulados As System.Windows.Forms.TabPage
   Friend WithEvents ugComprobantesAnulados As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnExaminarComprobantesAnulados As Eniac.Controles.Button
   Friend WithEvents txtImpuestosCompAnulados As Eniac.Controles.TextBox
   Friend WithEvents txtTotalCompAnulados As Eniac.Controles.TextBox
   Friend WithEvents txtSubTotalCompAnulados As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtArchivoDestinoComprobantesAnulados As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
End Class
