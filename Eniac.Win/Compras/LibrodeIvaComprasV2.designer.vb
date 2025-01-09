<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LibrodeIvaComprasV2
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LibrodeIvaComprasV2))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoComprobante")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ComprobanteFormat")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CUIT")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoImpuesto")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseImponibleNoGrabado")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseImponible")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePercepcion")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
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
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.chbAgrupar = New Eniac.Controles.CheckBox()
        Me.grbImpresionFinal = New System.Windows.Forms.GroupBox()
        Me.lblNumeroInicialHoja = New Eniac.Controles.Label()
        Me.txtNumeroInicialHoja = New Eniac.Controles.TextBox()
        Me.chkVersionFinal = New Eniac.Controles.CheckBox()
        Me.chbFormatoHorizontal = New Eniac.Controles.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optPorFecha = New System.Windows.Forms.RadioButton()
        Me.optPorProvincia = New System.Windows.Forms.RadioButton()
        Me.chkConVendedor = New Eniac.Controles.CheckBox()
        Me.cmbCompradores = New Eniac.Controles.ComboBox()
        Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
        Me.lblPeriodoFiscal = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grbConsultar.SuspendLayout()
        Me.grbImpresionFinal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbConsultar
        '
        Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbConsultar.Controls.Add(Me.chbAgrupar)
        Me.grbConsultar.Controls.Add(Me.grbImpresionFinal)
        Me.grbConsultar.Controls.Add(Me.chbFormatoHorizontal)
        Me.grbConsultar.Controls.Add(Me.GroupBox1)
        Me.grbConsultar.Controls.Add(Me.chkConVendedor)
        Me.grbConsultar.Controls.Add(Me.cmbCompradores)
        Me.grbConsultar.Controls.Add(Me.dtpPeriodoFiscal)
        Me.grbConsultar.Controls.Add(Me.lblPeriodoFiscal)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Location = New System.Drawing.Point(12, 30)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(960, 82)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'chbAgrupar
        '
        Me.chbAgrupar.AutoSize = True
        Me.chbAgrupar.BindearPropiedadControl = Nothing
        Me.chbAgrupar.BindearPropiedadEntidad = Nothing
        Me.chbAgrupar.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAgrupar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAgrupar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbAgrupar.IsPK = False
        Me.chbAgrupar.IsRequired = False
        Me.chbAgrupar.Key = Nothing
        Me.chbAgrupar.LabelAsoc = Nothing
        Me.chbAgrupar.Location = New System.Drawing.Point(103, 58)
        Me.chbAgrupar.Name = "chbAgrupar"
        Me.chbAgrupar.Size = New System.Drawing.Size(63, 17)
        Me.chbAgrupar.TabIndex = 8
        Me.chbAgrupar.Text = "Agrupar"
        Me.chbAgrupar.UseVisualStyleBackColor = True
        '
        'grbImpresionFinal
        '
        Me.grbImpresionFinal.Controls.Add(Me.lblNumeroInicialHoja)
        Me.grbImpresionFinal.Controls.Add(Me.txtNumeroInicialHoja)
        Me.grbImpresionFinal.Controls.Add(Me.chkVersionFinal)
        Me.grbImpresionFinal.Location = New System.Drawing.Point(631, 7)
        Me.grbImpresionFinal.Name = "grbImpresionFinal"
        Me.grbImpresionFinal.Size = New System.Drawing.Size(209, 63)
        Me.grbImpresionFinal.TabIndex = 6
        Me.grbImpresionFinal.TabStop = False
        Me.grbImpresionFinal.Text = "Impresión Final (MES COMPLETO)"
        '
        'lblNumeroInicialHoja
        '
        Me.lblNumeroInicialHoja.AutoSize = True
        Me.lblNumeroInicialHoja.LabelAsoc = Nothing
        Me.lblNumeroInicialHoja.Location = New System.Drawing.Point(8, 41)
        Me.lblNumeroInicialHoja.Name = "lblNumeroInicialHoja"
        Me.lblNumeroInicialHoja.Size = New System.Drawing.Size(57, 13)
        Me.lblNumeroInicialHoja.TabIndex = 1
        Me.lblNumeroInicialHoja.Text = "Nro. Inicial"
        '
        'txtNumeroInicialHoja
        '
        Me.txtNumeroInicialHoja.BindearPropiedadControl = Nothing
        Me.txtNumeroInicialHoja.BindearPropiedadEntidad = Nothing
        Me.txtNumeroInicialHoja.Enabled = False
        Me.txtNumeroInicialHoja.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroInicialHoja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroInicialHoja.Formato = ""
        Me.txtNumeroInicialHoja.IsDecimal = False
        Me.txtNumeroInicialHoja.IsNumber = True
        Me.txtNumeroInicialHoja.IsPK = False
        Me.txtNumeroInicialHoja.IsRequired = False
        Me.txtNumeroInicialHoja.Key = ""
        Me.txtNumeroInicialHoja.LabelAsoc = Me.lblNumeroInicialHoja
        Me.txtNumeroInicialHoja.Location = New System.Drawing.Point(69, 37)
        Me.txtNumeroInicialHoja.Name = "txtNumeroInicialHoja"
        Me.txtNumeroInicialHoja.Size = New System.Drawing.Size(92, 20)
        Me.txtNumeroInicialHoja.TabIndex = 2
        Me.txtNumeroInicialHoja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkVersionFinal
        '
        Me.chkVersionFinal.AutoSize = True
        Me.chkVersionFinal.BindearPropiedadControl = Nothing
        Me.chkVersionFinal.BindearPropiedadEntidad = Nothing
        Me.chkVersionFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.chkVersionFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkVersionFinal.IsPK = False
        Me.chkVersionFinal.IsRequired = False
        Me.chkVersionFinal.Key = Nothing
        Me.chkVersionFinal.LabelAsoc = Nothing
        Me.chkVersionFinal.Location = New System.Drawing.Point(11, 18)
        Me.chkVersionFinal.Name = "chkVersionFinal"
        Me.chkVersionFinal.Size = New System.Drawing.Size(195, 17)
        Me.chkVersionFinal.TabIndex = 0
        Me.chkVersionFinal.Text = "Versión Final (Guarda Numero Hoja)"
        Me.chkVersionFinal.UseVisualStyleBackColor = True
        '
        'chbFormatoHorizontal
        '
        Me.chbFormatoHorizontal.AutoSize = True
        Me.chbFormatoHorizontal.BindearPropiedadControl = Nothing
        Me.chbFormatoHorizontal.BindearPropiedadEntidad = Nothing
        Me.chbFormatoHorizontal.Checked = True
        Me.chbFormatoHorizontal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbFormatoHorizontal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormatoHorizontal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormatoHorizontal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbFormatoHorizontal.IsPK = False
        Me.chbFormatoHorizontal.IsRequired = False
        Me.chbFormatoHorizontal.Key = Nothing
        Me.chbFormatoHorizontal.LabelAsoc = Nothing
        Me.chbFormatoHorizontal.Location = New System.Drawing.Point(103, 35)
        Me.chbFormatoHorizontal.Name = "chbFormatoHorizontal"
        Me.chbFormatoHorizontal.Size = New System.Drawing.Size(73, 17)
        Me.chbFormatoHorizontal.TabIndex = 2
        Me.chbFormatoHorizontal.Text = "Horizontal"
        Me.chbFormatoHorizontal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optPorFecha)
        Me.GroupBox1.Controls.Add(Me.optPorProvincia)
        Me.GroupBox1.Location = New System.Drawing.Point(485, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(137, 63)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Orden"
        '
        'optPorFecha
        '
        Me.optPorFecha.AutoSize = True
        Me.optPorFecha.Checked = True
        Me.optPorFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.optPorFecha.Location = New System.Drawing.Point(11, 16)
        Me.optPorFecha.Name = "optPorFecha"
        Me.optPorFecha.Size = New System.Drawing.Size(74, 17)
        Me.optPorFecha.TabIndex = 0
        Me.optPorFecha.TabStop = True
        Me.optPorFecha.Text = "Por Fecha"
        Me.optPorFecha.UseVisualStyleBackColor = True
        '
        'optPorProvincia
        '
        Me.optPorProvincia.AutoSize = True
        Me.optPorProvincia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.optPorProvincia.Location = New System.Drawing.Point(11, 39)
        Me.optPorProvincia.Name = "optPorProvincia"
        Me.optPorProvincia.Size = New System.Drawing.Size(123, 17)
        Me.optPorProvincia.TabIndex = 1
        Me.optPorProvincia.TabStop = True
        Me.optPorProvincia.Text = "Por Provincia Cliente"
        Me.optPorProvincia.UseVisualStyleBackColor = True
        '
        'chkConVendedor
        '
        Me.chkConVendedor.AutoSize = True
        Me.chkConVendedor.BindearPropiedadControl = Nothing
        Me.chkConVendedor.BindearPropiedadEntidad = Nothing
        Me.chkConVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chkConVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkConVendedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkConVendedor.IsPK = False
        Me.chkConVendedor.IsRequired = False
        Me.chkConVendedor.Key = Nothing
        Me.chkConVendedor.LabelAsoc = Nothing
        Me.chkConVendedor.Location = New System.Drawing.Point(188, 35)
        Me.chkConVendedor.Name = "chkConVendedor"
        Me.chkConVendedor.Size = New System.Drawing.Size(96, 17)
        Me.chkConVendedor.TabIndex = 3
        Me.chkConVendedor.Text = "Por Comprador"
        Me.chkConVendedor.UseVisualStyleBackColor = True
        '
        'cmbCompradores
        '
        Me.cmbCompradores.BindearPropiedadControl = Nothing
        Me.cmbCompradores.BindearPropiedadEntidad = Nothing
        Me.cmbCompradores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompradores.Enabled = False
        Me.cmbCompradores.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCompradores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCompradores.FormattingEnabled = True
        Me.cmbCompradores.IsPK = False
        Me.cmbCompradores.IsRequired = False
        Me.cmbCompradores.Key = Nothing
        Me.cmbCompradores.LabelAsoc = Nothing
        Me.cmbCompradores.Location = New System.Drawing.Point(285, 33)
        Me.cmbCompradores.Name = "cmbCompradores"
        Me.cmbCompradores.Size = New System.Drawing.Size(189, 21)
        Me.cmbCompradores.TabIndex = 4
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
        Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(12, 33)
        Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
        Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(73, 20)
        Me.dtpPeriodoFiscal.TabIndex = 1
        '
        'lblPeriodoFiscal
        '
        Me.lblPeriodoFiscal.AutoSize = True
        Me.lblPeriodoFiscal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPeriodoFiscal.LabelAsoc = Nothing
        Me.lblPeriodoFiscal.Location = New System.Drawing.Point(10, 17)
        Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
        Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
        Me.lblPeriodoFiscal.TabIndex = 0
        Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(854, 21)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 7
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbImprimir2, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 2
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "Imprimir"
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
        'tsbImprimir2
        '
        Me.tsbImprimir2.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir2.Name = "tsbImprimir2"
        Me.tsbImprimir2.Size = New System.Drawing.Size(125, 26)
        Me.tsbImprimir2.Text = "Imp. &Prediseñado"
        Me.tsbImprimir2.ToolTipText = "Imprimir y Grabar (F4)"
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
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn15.Format = "dd/MM/yyyy"
        UltraGridColumn15.Header.VisiblePosition = 0
        UltraGridColumn15.Width = 70
        UltraGridColumn19.Header.Caption = "Tipo"
        UltraGridColumn19.Header.VisiblePosition = 1
        UltraGridColumn19.Width = 70
        UltraGridColumn20.Header.Caption = ""
        UltraGridColumn20.Header.VisiblePosition = 2
        UltraGridColumn20.Width = 20
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance2
        UltraGridColumn21.Header.Caption = "Emisor"
        UltraGridColumn21.Header.VisiblePosition = 3
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 50
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance3
        UltraGridColumn22.Header.Caption = "Numero"
        UltraGridColumn22.Header.VisiblePosition = 4
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 70
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance4
        UltraGridColumn23.Header.Caption = "Comprobante"
        UltraGridColumn23.Header.VisiblePosition = 5
        UltraGridColumn23.Width = 110
        UltraGridColumn24.Header.Caption = "Proveedor"
        UltraGridColumn24.Header.VisiblePosition = 6
        UltraGridColumn24.Width = 130
        UltraGridColumn25.Header.Caption = "Rubro"
        UltraGridColumn25.Header.VisiblePosition = 7
        UltraGridColumn25.Width = 125
        UltraGridColumn26.Header.Caption = "Categoria"
        UltraGridColumn26.Header.VisiblePosition = 8
        UltraGridColumn26.Width = 70
        UltraGridColumn27.Header.VisiblePosition = 9
        UltraGridColumn27.Width = 85
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance5
        UltraGridColumn28.Header.Caption = "Impuesto"
        UltraGridColumn28.Header.VisiblePosition = 10
        UltraGridColumn28.Width = 100
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance6
        UltraGridColumn29.Format = "N2"
        UltraGridColumn29.Header.Caption = "Neto No Gravado"
        UltraGridColumn29.Header.VisiblePosition = 11
        UltraGridColumn29.Width = 80
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance7
        UltraGridColumn30.Format = "N2"
        UltraGridColumn30.Header.Caption = "Neto Gravado"
        UltraGridColumn30.Header.VisiblePosition = 12
        UltraGridColumn30.Width = 80
        UltraGridColumn31.Header.Caption = "Percepciones"
        UltraGridColumn31.Header.VisiblePosition = 13
        UltraGridColumn31.Hidden = True
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance8
        UltraGridColumn32.Format = "N2"
        UltraGridColumn32.Header.Caption = "Total"
        UltraGridColumn32.Header.VisiblePosition = 14
        UltraGridColumn32.Width = 80
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn15, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32})
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
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance18
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Location = New System.Drawing.Point(12, 118)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(961, 418)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.FitWidthToPages = 1
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
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
        'LibrodeIvaComprasV2
        '
        Me.AcceptButton = Me.btnConsultar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.ugDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(850, 320)
        Me.Name = "LibrodeIvaComprasV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Libro de I.V.A. Compras  V2"
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.grbImpresionFinal.ResumeLayout(False)
        Me.grbImpresionFinal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents chkConVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbCompradores As Eniac.Controles.ComboBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents optPorFecha As System.Windows.Forms.RadioButton
   Friend WithEvents optPorProvincia As System.Windows.Forms.RadioButton
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbFormatoHorizontal As Eniac.Controles.CheckBox
   Friend WithEvents grbImpresionFinal As System.Windows.Forms.GroupBox
   Friend WithEvents lblNumeroInicialHoja As Eniac.Controles.Label
   Friend WithEvents txtNumeroInicialHoja As Eniac.Controles.TextBox
   Friend WithEvents chkVersionFinal As Eniac.Controles.CheckBox
    Friend WithEvents chbAgrupar As Controles.CheckBox
End Class
