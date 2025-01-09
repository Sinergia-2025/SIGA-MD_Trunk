<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LibrodeIvaVentasV2
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LibrodeIvaVentasV2))
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CUIT")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NetoNoGravado")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Neto")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Percepciones")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteBruto")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoComprobante")
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
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
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
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.grbImpresionFinal = New System.Windows.Forms.GroupBox()
      Me.lblNumeroInicialHoja = New Eniac.Controles.Label()
      Me.txtNumeroInicialHoja = New Eniac.Controles.TextBox()
      Me.chkVersionFinal = New Eniac.Controles.CheckBox()
      Me.chbFormatoHorizontal = New Eniac.Controles.CheckBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.optPorProvinciaImpuesto = New System.Windows.Forms.RadioButton()
      Me.optPorFecha = New System.Windows.Forms.RadioButton()
      Me.optPorProvincia = New System.Windows.Forms.RadioButton()
      Me.chkConVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedores = New Eniac.Controles.ComboBox()
      Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
      Me.lblPeriodoFiscal = New Eniac.Controles.Label()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbConsultar.SuspendLayout()
      Me.grbImpresionFinal.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.UltraGridPrintDocument1.FitWidthToPages = 1
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
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(849, 30)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(105, 51)
      Me.btnConsultar.TabIndex = 6
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbImprimir2, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 5
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
      'grbConsultar
      '
      Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbConsultar.Controls.Add(Me.grbImpresionFinal)
      Me.grbConsultar.Controls.Add(Me.chbFormatoHorizontal)
      Me.grbConsultar.Controls.Add(Me.GroupBox1)
      Me.grbConsultar.Controls.Add(Me.chkConVendedor)
      Me.grbConsultar.Controls.Add(Me.cmbVendedores)
      Me.grbConsultar.Controls.Add(Me.dtpPeriodoFiscal)
      Me.grbConsultar.Controls.Add(Me.lblPeriodoFiscal)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 30)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(960, 96)
      Me.grbConsultar.TabIndex = 0
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'grbImpresionFinal
      '
      Me.grbImpresionFinal.Controls.Add(Me.lblNumeroInicialHoja)
      Me.grbImpresionFinal.Controls.Add(Me.txtNumeroInicialHoja)
      Me.grbImpresionFinal.Controls.Add(Me.chkVersionFinal)
      Me.grbImpresionFinal.Location = New System.Drawing.Point(629, 17)
      Me.grbImpresionFinal.Name = "grbImpresionFinal"
      Me.grbImpresionFinal.Size = New System.Drawing.Size(214, 71)
      Me.grbImpresionFinal.TabIndex = 7
      Me.grbImpresionFinal.TabStop = False
      Me.grbImpresionFinal.Text = "Impresión Final (MES COMPLETO)"
      '
      'lblNumeroInicialHoja
      '
      Me.lblNumeroInicialHoja.AutoSize = True
      Me.lblNumeroInicialHoja.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNumeroInicialHoja.LabelAsoc = Nothing
      Me.lblNumeroInicialHoja.Location = New System.Drawing.Point(8, 47)
      Me.lblNumeroInicialHoja.Name = "lblNumeroInicialHoja"
      Me.lblNumeroInicialHoja.Size = New System.Drawing.Size(63, 13)
      Me.lblNumeroInicialHoja.TabIndex = 26
      Me.lblNumeroInicialHoja.Text = "Nro. Inicial :"
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
      Me.txtNumeroInicialHoja.Location = New System.Drawing.Point(77, 44)
      Me.txtNumeroInicialHoja.Name = "txtNumeroInicialHoja"
      Me.txtNumeroInicialHoja.Size = New System.Drawing.Size(92, 20)
      Me.txtNumeroInicialHoja.TabIndex = 25
      Me.txtNumeroInicialHoja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'chkVersionFinal
      '
      Me.chkVersionFinal.AutoSize = True
      Me.chkVersionFinal.BindearPropiedadControl = Nothing
      Me.chkVersionFinal.BindearPropiedadEntidad = Nothing
      Me.chkVersionFinal.ForeColorFocus = System.Drawing.Color.Red
      Me.chkVersionFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkVersionFinal.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chkVersionFinal.IsPK = False
      Me.chkVersionFinal.IsRequired = False
      Me.chkVersionFinal.Key = Nothing
      Me.chkVersionFinal.LabelAsoc = Nothing
      Me.chkVersionFinal.Location = New System.Drawing.Point(11, 19)
      Me.chkVersionFinal.Name = "chkVersionFinal"
      Me.chkVersionFinal.Size = New System.Drawing.Size(195, 17)
      Me.chkVersionFinal.TabIndex = 24
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
      Me.chbFormatoHorizontal.Location = New System.Drawing.Point(109, 44)
      Me.chbFormatoHorizontal.Name = "chbFormatoHorizontal"
      Me.chbFormatoHorizontal.Size = New System.Drawing.Size(73, 17)
      Me.chbFormatoHorizontal.TabIndex = 3
      Me.chbFormatoHorizontal.Text = "Horizontal"
      Me.chbFormatoHorizontal.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.optPorProvinciaImpuesto)
      Me.GroupBox1.Controls.Add(Me.optPorFecha)
      Me.GroupBox1.Controls.Add(Me.optPorProvincia)
      Me.GroupBox1.Location = New System.Drawing.Point(496, 17)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(127, 71)
      Me.GroupBox1.TabIndex = 6
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Orden"
      '
      'optPorProvinciaImpuesto
      '
      Me.optPorProvinciaImpuesto.AutoSize = True
      Me.optPorProvinciaImpuesto.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.optPorProvinciaImpuesto.Location = New System.Drawing.Point(6, 50)
      Me.optPorProvinciaImpuesto.Name = "optPorProvinciaImpuesto"
      Me.optPorProvinciaImpuesto.Size = New System.Drawing.Size(115, 17)
      Me.optPorProvinciaImpuesto.TabIndex = 2
      Me.optPorProvinciaImpuesto.TabStop = True
      Me.optPorProvinciaImpuesto.Text = "Por Prov. Impuesto"
      Me.optPorProvinciaImpuesto.UseVisualStyleBackColor = True
      '
      'optPorFecha
      '
      Me.optPorFecha.AutoSize = True
      Me.optPorFecha.Checked = True
      Me.optPorFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.optPorFecha.Location = New System.Drawing.Point(6, 18)
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
      Me.optPorProvincia.Location = New System.Drawing.Point(6, 34)
      Me.optPorProvincia.Name = "optPorProvincia"
      Me.optPorProvincia.Size = New System.Drawing.Size(104, 17)
      Me.optPorProvincia.TabIndex = 1
      Me.optPorProvincia.TabStop = True
      Me.optPorProvincia.Text = "Por Prov. Cliente"
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
      Me.chkConVendedor.Location = New System.Drawing.Point(188, 44)
      Me.chkConVendedor.Name = "chkConVendedor"
      Me.chkConVendedor.Size = New System.Drawing.Size(91, 17)
      Me.chkConVendedor.TabIndex = 4
      Me.chkConVendedor.Text = "Por Vendedor"
      Me.chkConVendedor.UseVisualStyleBackColor = True
      '
      'cmbVendedores
      '
      Me.cmbVendedores.BindearPropiedadControl = Nothing
      Me.cmbVendedores.BindearPropiedadEntidad = Nothing
      Me.cmbVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedores.Enabled = False
      Me.cmbVendedores.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedores.FormattingEnabled = True
      Me.cmbVendedores.IsPK = False
      Me.cmbVendedores.IsRequired = False
      Me.cmbVendedores.Key = Nothing
      Me.cmbVendedores.LabelAsoc = Nothing
      Me.cmbVendedores.Location = New System.Drawing.Point(285, 42)
      Me.cmbVendedores.Name = "cmbVendedores"
      Me.cmbVendedores.Size = New System.Drawing.Size(189, 21)
      Me.cmbVendedores.TabIndex = 5
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
      Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(18, 43)
      Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
      Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(71, 20)
      Me.dtpPeriodoFiscal.TabIndex = 2
      '
      'lblPeriodoFiscal
      '
      Me.lblPeriodoFiscal.AutoSize = True
      Me.lblPeriodoFiscal.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblPeriodoFiscal.LabelAsoc = Nothing
      Me.lblPeriodoFiscal.Location = New System.Drawing.Point(16, 27)
      Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
      Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
      Me.lblPeriodoFiscal.TabIndex = 1
      Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance2.BackColor = System.Drawing.SystemColors.Window
      Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance2
      UltraGridColumn8.Format = "dd"
      UltraGridColumn8.Header.Caption = "Dia"
      UltraGridColumn8.Header.VisiblePosition = 0
      UltraGridColumn8.Width = 30
      UltraGridColumn12.Header.Caption = "Tipo"
      UltraGridColumn12.Header.VisiblePosition = 1
      UltraGridColumn12.Width = 70
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Hidden = True
      UltraGridColumn2.Width = 55
      UltraGridColumn3.Header.Caption = ""
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Width = 20
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance3
      UltraGridColumn9.Header.Caption = "Emisor"
      UltraGridColumn9.Header.VisiblePosition = 4
      UltraGridColumn9.Width = 50
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance4
      UltraGridColumn11.Header.Caption = "Numero"
      UltraGridColumn11.Header.VisiblePosition = 5
      UltraGridColumn11.Width = 70
      UltraGridColumn5.Header.Caption = "Cliente"
      UltraGridColumn5.Header.VisiblePosition = 6
      UltraGridColumn5.Width = 150
      UltraGridColumn6.Header.Caption = "Categoria"
      UltraGridColumn6.Header.VisiblePosition = 7
      UltraGridColumn6.Width = 90
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance5
      UltraGridColumn7.Header.VisiblePosition = 8
      UltraGridColumn7.Width = 85
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn15.CellAppearance = Appearance6
      UltraGridColumn15.Format = "N2"
      UltraGridColumn15.Header.Caption = "Neto No Gravado"
      UltraGridColumn15.Header.TextOrientation = New Infragistics.Win.TextOrientationInfo(0, Infragistics.Win.TextFlowDirection.Horizontal)
      UltraGridColumn15.Header.VisiblePosition = 9
      UltraGridColumn15.Width = 80
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn10.CellAppearance = Appearance7
      UltraGridColumn10.Format = "N2"
      UltraGridColumn10.Header.Caption = "Neto Gravado"
      UltraGridColumn10.Header.VisiblePosition = 10
      UltraGridColumn10.Width = 80
      UltraGridColumn1.Header.VisiblePosition = 12
      UltraGridColumn1.Hidden = True
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn14.CellAppearance = Appearance8
      UltraGridColumn14.Format = "N2"
      UltraGridColumn14.Header.VisiblePosition = 11
      UltraGridColumn14.Width = 80
      UltraGridColumn4.Header.VisiblePosition = 13
      UltraGridColumn4.Hidden = True
      UltraGridColumn13.Header.VisiblePosition = 14
      UltraGridColumn13.Hidden = True
      UltraGridColumn16.Header.VisiblePosition = 15
      UltraGridColumn16.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn8, UltraGridColumn12, UltraGridColumn2, UltraGridColumn3, UltraGridColumn9, UltraGridColumn11, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn15, UltraGridColumn10, UltraGridColumn1, UltraGridColumn14, UltraGridColumn4, UltraGridColumn13, UltraGridColumn16})
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
      Me.ugDetalle.Location = New System.Drawing.Point(12, 132)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(961, 391)
      Me.ugDetalle.TabIndex = 5
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'LibrodeIvaVentasV2
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
      Me.Name = "LibrodeIvaVentasV2"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Libro de I.V.A. Ventas V2"
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.grbImpresionFinal.ResumeLayout(False)
      Me.grbImpresionFinal.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
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
   Friend WithEvents cmbVendedores As Eniac.Controles.ComboBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents optPorProvinciaImpuesto As System.Windows.Forms.RadioButton
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
End Class
