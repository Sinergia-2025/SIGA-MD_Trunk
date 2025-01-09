<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RevertirPasajeMovimientos
   'Inherits BaseForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevertirPasajeMovimientos))
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubroConcepto")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubroConcepto", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdConcepto")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreConcepto")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImprimeProveedor")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoComprobante")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteALiquidar")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodoLiquidacion")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("seleccionado")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.cboComprobante = New Eniac.Controles.CheckBox()
      Me.lblEmisorComprobante = New Eniac.Controles.Label()
      Me.txtEmisorComprobante = New Eniac.Controles.TextBox()
      Me.lblNumeroComprobante = New Eniac.Controles.Label()
      Me.txtNumeroComprobante = New Eniac.Controles.TextBox()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.lblNroDocumentoProv = New Eniac.Controles.Label()
      Me.lblNombreProv = New Eniac.Controles.Label()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbConcepto = New Eniac.Controles.CheckBox()
      Me.bscIdConcepto = New Eniac.Controles.Buscador()
      Me.bscNombreConcepto = New Eniac.Controles.Buscador()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRevertir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.grbConsultar.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbConsultar
      '
      Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
      Me.grbConsultar.Controls.Add(Me.bscProveedor)
      Me.grbConsultar.Controls.Add(Me.cboComprobante)
      Me.grbConsultar.Controls.Add(Me.lblEmisorComprobante)
      Me.grbConsultar.Controls.Add(Me.txtEmisorComprobante)
      Me.grbConsultar.Controls.Add(Me.lblNumeroComprobante)
      Me.grbConsultar.Controls.Add(Me.txtNumeroComprobante)
      Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbConsultar.Controls.Add(Me.lblLetra)
      Me.grbConsultar.Controls.Add(Me.txtLetra)
      Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
      Me.grbConsultar.Controls.Add(Me.lblNroDocumentoProv)
      Me.grbConsultar.Controls.Add(Me.lblNombreProv)
      Me.grbConsultar.Controls.Add(Me.chbProveedor)
      Me.grbConsultar.Controls.Add(Me.chkExpandAll)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Controls.Add(Me.chbConcepto)
      Me.grbConsultar.Controls.Add(Me.bscIdConcepto)
      Me.grbConsultar.Controls.Add(Me.bscNombreConcepto)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(891, 104)
      Me.grbConsultar.TabIndex = 0
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
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
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = True
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Nothing
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(93, 74)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = False
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(97, 20)
      Me.bscCodigoProveedor.TabIndex = 3
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'bscProveedor
      '
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
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
      Me.bscProveedor.Location = New System.Drawing.Point(194, 74)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = False
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(302, 20)
      Me.bscProveedor.TabIndex = 4
      Me.bscProveedor.Titulo = Nothing
      '
      'cboComprobante
      '
      Me.cboComprobante.AutoSize = True
      Me.cboComprobante.BindearPropiedadControl = Nothing
      Me.cboComprobante.BindearPropiedadEntidad = Nothing
      Me.cboComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.cboComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.cboComprobante.IsPK = False
      Me.cboComprobante.IsRequired = False
      Me.cboComprobante.Key = Nothing
      Me.cboComprobante.LabelAsoc = Nothing
      Me.cboComprobante.Location = New System.Drawing.Point(510, 30)
      Me.cboComprobante.Name = "cboComprobante"
      Me.cboComprobante.Size = New System.Drawing.Size(71, 17)
      Me.cboComprobante.TabIndex = 14
      Me.cboComprobante.Text = "Comprob."
      Me.cboComprobante.UseVisualStyleBackColor = True
      '
      'lblEmisorComprobante
      '
      Me.lblEmisorComprobante.AutoSize = True
      Me.lblEmisorComprobante.Location = New System.Drawing.Point(762, 14)
      Me.lblEmisorComprobante.Name = "lblEmisorComprobante"
      Me.lblEmisorComprobante.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisorComprobante.TabIndex = 19
      Me.lblEmisorComprobante.Text = "Emisor"
      '
      'txtEmisorComprobante
      '
      Me.txtEmisorComprobante.BindearPropiedadControl = Nothing
      Me.txtEmisorComprobante.BindearPropiedadEntidad = Nothing
      Me.txtEmisorComprobante.Enabled = False
      Me.txtEmisorComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisorComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisorComprobante.Formato = ""
      Me.txtEmisorComprobante.IsDecimal = False
      Me.txtEmisorComprobante.IsNumber = True
      Me.txtEmisorComprobante.IsPK = False
      Me.txtEmisorComprobante.IsRequired = False
      Me.txtEmisorComprobante.Key = ""
      Me.txtEmisorComprobante.LabelAsoc = Me.lblEmisorComprobante
      Me.txtEmisorComprobante.Location = New System.Drawing.Point(754, 29)
      Me.txtEmisorComprobante.MaxLength = 4
      Me.txtEmisorComprobante.Name = "txtEmisorComprobante"
      Me.txtEmisorComprobante.Size = New System.Drawing.Size(46, 20)
      Me.txtEmisorComprobante.TabIndex = 7
      Me.txtEmisorComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroComprobante
      '
      Me.lblNumeroComprobante.AutoSize = True
      Me.lblNumeroComprobante.Location = New System.Drawing.Point(836, 14)
      Me.lblNumeroComprobante.Name = "lblNumeroComprobante"
      Me.lblNumeroComprobante.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroComprobante.TabIndex = 20
      Me.lblNumeroComprobante.Text = "Numero"
      '
      'txtNumeroComprobante
      '
      Me.txtNumeroComprobante.BindearPropiedadControl = Nothing
      Me.txtNumeroComprobante.BindearPropiedadEntidad = Nothing
      Me.txtNumeroComprobante.Enabled = False
      Me.txtNumeroComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroComprobante.Formato = ""
      Me.txtNumeroComprobante.IsDecimal = False
      Me.txtNumeroComprobante.IsNumber = True
      Me.txtNumeroComprobante.IsPK = False
      Me.txtNumeroComprobante.IsRequired = False
      Me.txtNumeroComprobante.Key = ""
      Me.txtNumeroComprobante.LabelAsoc = Me.lblNumeroComprobante
      Me.txtNumeroComprobante.Location = New System.Drawing.Point(805, 29)
      Me.txtNumeroComprobante.MaxLength = 8
      Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
      Me.txtNumeroComprobante.Size = New System.Drawing.Size(75, 20)
      Me.txtNumeroComprobante.TabIndex = 8
      Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Enabled = False
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.ItemHeight = 13
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Nothing
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(587, 29)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(132, 21)
      Me.cmbTiposComprobantes.TabIndex = 5
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.Location = New System.Drawing.Point(724, 14)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(22, 13)
      Me.lblLetra.TabIndex = 18
      Me.lblLetra.Text = "Let"
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = Nothing
      Me.txtLetra.BindearPropiedadEntidad = Nothing
      Me.txtLetra.Enabled = False
      Me.txtLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLetra.Formato = ""
      Me.txtLetra.IsDecimal = False
      Me.txtLetra.IsNumber = False
      Me.txtLetra.IsPK = False
      Me.txtLetra.IsRequired = False
      Me.txtLetra.Key = ""
      Me.txtLetra.LabelAsoc = Me.lblLetra
      Me.txtLetra.Location = New System.Drawing.Point(724, 29)
      Me.txtLetra.MaxLength = 1
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.Size = New System.Drawing.Size(25, 20)
      Me.txtLetra.TabIndex = 6
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.Location = New System.Drawing.Point(584, 13)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(28, 13)
      Me.lblTipoComprobante.TabIndex = 17
      Me.lblTipoComprobante.Text = "Tipo"
      '
      'lblNroDocumentoProv
      '
      Me.lblNroDocumentoProv.AutoSize = True
      Me.lblNroDocumentoProv.Location = New System.Drawing.Point(90, 58)
      Me.lblNroDocumentoProv.Name = "lblNroDocumentoProv"
      Me.lblNroDocumentoProv.Size = New System.Drawing.Size(40, 13)
      Me.lblNroDocumentoProv.TabIndex = 15
      Me.lblNroDocumentoProv.Text = "Código"
      '
      'lblNombreProv
      '
      Me.lblNombreProv.AutoSize = True
      Me.lblNombreProv.Location = New System.Drawing.Point(191, 58)
      Me.lblNombreProv.Name = "lblNombreProv"
      Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProv.TabIndex = 16
      Me.lblNombreProv.Text = "Nombre"
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
      Me.chbProveedor.Location = New System.Drawing.Point(12, 74)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 13
      Me.chbProveedor.Text = "Proveedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
      '
      'chkExpandAll
      '
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(672, 80)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chkExpandAll.TabIndex = 10
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(780, 55)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 9
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chbConcepto
      '
      Me.chbConcepto.AutoSize = True
      Me.chbConcepto.BindearPropiedadControl = Nothing
      Me.chbConcepto.BindearPropiedadEntidad = Nothing
      Me.chbConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConcepto.IsPK = False
      Me.chbConcepto.IsRequired = False
      Me.chbConcepto.Key = Nothing
      Me.chbConcepto.LabelAsoc = Nothing
      Me.chbConcepto.Location = New System.Drawing.Point(12, 31)
      Me.chbConcepto.Name = "chbConcepto"
      Me.chbConcepto.Size = New System.Drawing.Size(72, 17)
      Me.chbConcepto.TabIndex = 12
      Me.chbConcepto.Text = "Concepto"
      Me.chbConcepto.UseVisualStyleBackColor = True
      '
      'bscIdConcepto
      '
      Me.bscIdConcepto.AyudaAncho = 608
      Me.bscIdConcepto.BindearPropiedadControl = Nothing
      Me.bscIdConcepto.BindearPropiedadEntidad = Nothing
      Me.bscIdConcepto.ColumnasAlineacion = Nothing
      Me.bscIdConcepto.ColumnasAncho = Nothing
      Me.bscIdConcepto.ColumnasFormato = Nothing
      Me.bscIdConcepto.ColumnasOcultas = Nothing
      Me.bscIdConcepto.ColumnasTitulos = Nothing
      Me.bscIdConcepto.Datos = Nothing
      Me.bscIdConcepto.FilaDevuelta = Nothing
      Me.bscIdConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscIdConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscIdConcepto.IsDecimal = False
      Me.bscIdConcepto.IsNumber = False
      Me.bscIdConcepto.IsPK = False
      Me.bscIdConcepto.IsRequired = False
      Me.bscIdConcepto.Key = ""
      Me.bscIdConcepto.LabelAsoc = Nothing
      Me.bscIdConcepto.Location = New System.Drawing.Point(93, 29)
      Me.bscIdConcepto.MaxLengh = "32767"
      Me.bscIdConcepto.Name = "bscIdConcepto"
      Me.bscIdConcepto.Permitido = False
      Me.bscIdConcepto.Selecciono = False
      Me.bscIdConcepto.Size = New System.Drawing.Size(97, 20)
      Me.bscIdConcepto.TabIndex = 1
      Me.bscIdConcepto.Titulo = Nothing
      '
      'bscNombreConcepto
      '
      Me.bscNombreConcepto.AyudaAncho = 608
      Me.bscNombreConcepto.BindearPropiedadControl = Nothing
      Me.bscNombreConcepto.BindearPropiedadEntidad = Nothing
      Me.bscNombreConcepto.ColumnasAlineacion = Nothing
      Me.bscNombreConcepto.ColumnasAncho = Nothing
      Me.bscNombreConcepto.ColumnasFormato = Nothing
      Me.bscNombreConcepto.ColumnasOcultas = Nothing
      Me.bscNombreConcepto.ColumnasTitulos = Nothing
      Me.bscNombreConcepto.Datos = Nothing
      Me.bscNombreConcepto.FilaDevuelta = Nothing
      Me.bscNombreConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreConcepto.IsDecimal = False
      Me.bscNombreConcepto.IsNumber = False
      Me.bscNombreConcepto.IsPK = False
      Me.bscNombreConcepto.IsRequired = False
      Me.bscNombreConcepto.Key = ""
      Me.bscNombreConcepto.LabelAsoc = Nothing
      Me.bscNombreConcepto.Location = New System.Drawing.Point(194, 29)
      Me.bscNombreConcepto.MaxLengh = "32767"
      Me.bscNombreConcepto.Name = "bscNombreConcepto"
      Me.bscNombreConcepto.Permitido = False
      Me.bscNombreConcepto.Selecciono = False
      Me.bscNombreConcepto.Size = New System.Drawing.Size(302, 20)
      Me.bscNombreConcepto.TabIndex = 2
      Me.bscNombreConcepto.Titulo = Nothing
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbRevertir, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(915, 29)
      Me.tstBarra.TabIndex = 2
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
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbRevertir
      '
      Me.tsbRevertir.Image = Global.Eniac.Win.My.Resources.Resources.note_delete
      Me.tsbRevertir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRevertir.Name = "tsbRevertir"
      Me.tsbRevertir.Size = New System.Drawing.Size(73, 26)
      Me.tsbRevertir.Text = "&Revertir"
      Me.tsbRevertir.ToolTipText = "Revertir los pasajes de movimientos seleccionados."
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
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
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance17
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
      Me.ugDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn2.Header.Caption = "Rubro"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn3.Header.VisiblePosition = 4
      UltraGridColumn3.Hidden = True
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn4.Header.Caption = "Concepto"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 172
      UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn5.Header.Caption = "Código"
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn5.Width = 84
      UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn6.Header.VisiblePosition = 7
      UltraGridColumn6.Hidden = True
      UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn7.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
      UltraGridColumn7.Header.Caption = "Proveedor"
      UltraGridColumn7.Header.VisiblePosition = 6
      UltraGridColumn7.Width = 178
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn8.Header.VisiblePosition = 8
      UltraGridColumn8.Hidden = True
      UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn9.Header.VisiblePosition = 9
      UltraGridColumn9.Hidden = True
      UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn10.Header.Caption = "Comprobante"
      UltraGridColumn10.Header.VisiblePosition = 11
      UltraGridColumn10.Width = 84
      UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance1.TextHAlignAsString = "Center"
      UltraGridColumn11.CellAppearance = Appearance1
      UltraGridColumn11.Header.VisiblePosition = 12
      UltraGridColumn11.Width = 35
      UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn12.CellAppearance = Appearance2
      UltraGridColumn12.Header.Caption = "P.V."
      UltraGridColumn12.Header.VisiblePosition = 13
      UltraGridColumn12.Width = 35
      UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn13.CellAppearance = Appearance3
      UltraGridColumn13.Header.Caption = "Numero"
      UltraGridColumn13.Header.VisiblePosition = 14
      UltraGridColumn13.Width = 62
      UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn14.CellAppearance = Appearance4
      UltraGridColumn14.Format = "##,##0.00"
      UltraGridColumn14.Header.Caption = "Imp. Liquidar"
      UltraGridColumn14.Header.VisiblePosition = 15
      UltraGridColumn14.Width = 78
      UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn15.Header.VisiblePosition = 16
      UltraGridColumn15.Hidden = True
      UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance5.TextHAlignAsString = "Center"
      UltraGridColumn16.CellAppearance = Appearance5
      UltraGridColumn16.Header.VisiblePosition = 10
      UltraGridColumn16.Width = 84
      UltraGridColumn17.Header.Caption = ""
      UltraGridColumn17.Header.CheckBoxSynchronization = Infragistics.Win.UltraWinGrid.HeaderCheckBoxSynchronization.Band
      UltraGridColumn17.Header.VisiblePosition = 2
      UltraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn17.Width = 43
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17})
      UltraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance6.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance6
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance8.BackColor2 = System.Drawing.SystemColors.Control
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance9.BackColor = System.Drawing.SystemColors.Highlight
      Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Me.ugDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
      Me.ugDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
      Appearance11.BackColor = System.Drawing.Color.AntiqueWhite
      Me.ugDetalle.DisplayLayout.Override.FilterRowAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
      Appearance12.BackColor = System.Drawing.SystemColors.Control
      Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance12.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
      Appearance13.TextHAlignAsString = "Center"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Appearance14.BackColor = System.Drawing.SystemColors.Window
      Appearance14.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance15.BackColor = System.Drawing.Color.DarkSeaGreen
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 161)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(891, 373)
      Me.ugDetalle.TabIndex = 1
      Me.ugDetalle.Text = "UltraGrid1"
      Me.ugDetalle.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(915, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(836, 17)
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
      'chbTodos
      '
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(12, 138)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(124, 22)
      Me.chbTodos.TabIndex = 3
      Me.chbTodos.Text = "Chequear todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'RevertirPasajeMovimientos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(915, 561)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbConsultar)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "RevertirPasajeMovimientos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Revertir Pasaje de Movimientos para Liquidación de Expensas"
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscIdConcepto As Eniac.Controles.Buscador
   Friend WithEvents bscNombreConcepto As Eniac.Controles.Buscador
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbConcepto As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents lblNroDocumentoProv As Eniac.Controles.Label
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Protected WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents lblEmisorComprobante As Eniac.Controles.Label
   Friend WithEvents txtEmisorComprobante As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroComprobante As Eniac.Controles.Label
   Friend WithEvents txtNumeroComprobante As Eniac.Controles.TextBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents txtLetra As Eniac.Controles.TextBox
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents cboComprobante As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbRevertir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
End Class
