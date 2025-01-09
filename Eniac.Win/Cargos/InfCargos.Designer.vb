<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfCargos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfCargos))
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selecciono")
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodoLiquidacion")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.cmbLiquidado = New Eniac.Controles.ComboBox()
      Me.chbLetra = New Eniac.Controles.CheckBox()
      Me.chbEmisor = New Eniac.Controles.CheckBox()
      Me.cmbEmisor = New Eniac.Controles.ComboBox()
      Me.cboLetra = New Eniac.Controles.ComboBox()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbTiposLiquidacion = New Eniac.Controles.ComboBox()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbCategorias = New Eniac.Controles.ComboBox()
      Me.bscNombreCliente = New Eniac.Controles.Buscador()
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.lblPeriodo = New Eniac.Controles.Label()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.lblTotal = New Eniac.Controles.Label()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.grbConsultar.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbConsultar
      '
      Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbConsultar.Controls.Add(Me.Label2)
      Me.grbConsultar.Controls.Add(Me.cmbLiquidado)
      Me.grbConsultar.Controls.Add(Me.chbLetra)
      Me.grbConsultar.Controls.Add(Me.chbEmisor)
      Me.grbConsultar.Controls.Add(Me.cmbEmisor)
      Me.grbConsultar.Controls.Add(Me.cboLetra)
      Me.grbConsultar.Controls.Add(Me.chbNumero)
      Me.grbConsultar.Controls.Add(Me.txtNumero)
      Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbConsultar.Controls.Add(Me.chbTipoComprobante)
      Me.grbConsultar.Controls.Add(Me.Label1)
      Me.grbConsultar.Controls.Add(Me.cmbTiposLiquidacion)
      Me.grbConsultar.Controls.Add(Me.chbCategoria)
      Me.grbConsultar.Controls.Add(Me.cmbCategorias)
      Me.grbConsultar.Controls.Add(Me.bscNombreCliente)
      Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.chbCliente)
      Me.grbConsultar.Controls.Add(Me.lblPeriodo)
      Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.lblNombreCliente)
      Me.grbConsultar.Controls.Add(Me.chkExpandAll)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Controls.Add(Me.dtpHasta)
      Me.grbConsultar.Controls.Add(Me.dtpDesde)
      Me.grbConsultar.Controls.Add(Me.lblHasta)
      Me.grbConsultar.Controls.Add(Me.lblDesde)
      Me.grbConsultar.Location = New System.Drawing.Point(4, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(923, 140)
      Me.grbConsultar.TabIndex = 0
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Filtros"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(615, 29)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(53, 13)
      Me.Label2.TabIndex = 7
      Me.Label2.Text = "Liquidado"
      '
      'cmbLiquidado
      '
      Me.cmbLiquidado.BindearPropiedadControl = ""
      Me.cmbLiquidado.BindearPropiedadEntidad = ""
      Me.cmbLiquidado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLiquidado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLiquidado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLiquidado.FormattingEnabled = True
      Me.cmbLiquidado.IsPK = False
      Me.cmbLiquidado.IsRequired = True
      Me.cmbLiquidado.Key = Nothing
      Me.cmbLiquidado.LabelAsoc = Nothing
      Me.cmbLiquidado.Location = New System.Drawing.Point(674, 24)
      Me.cmbLiquidado.Name = "cmbLiquidado"
      Me.cmbLiquidado.Size = New System.Drawing.Size(68, 21)
      Me.cmbLiquidado.TabIndex = 8
      '
      'chbLetra
      '
      Me.chbLetra.AutoSize = True
      Me.chbLetra.BindearPropiedadControl = Nothing
      Me.chbLetra.BindearPropiedadEntidad = Nothing
      Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLetra.IsPK = False
      Me.chbLetra.IsRequired = False
      Me.chbLetra.Key = Nothing
      Me.chbLetra.LabelAsoc = Nothing
      Me.chbLetra.Location = New System.Drawing.Point(264, 63)
      Me.chbLetra.Name = "chbLetra"
      Me.chbLetra.Size = New System.Drawing.Size(50, 17)
      Me.chbLetra.TabIndex = 11
      Me.chbLetra.Text = "Letra"
      Me.chbLetra.UseVisualStyleBackColor = True
      '
      'chbEmisor
      '
      Me.chbEmisor.AutoSize = True
      Me.chbEmisor.BindearPropiedadControl = Nothing
      Me.chbEmisor.BindearPropiedadEntidad = Nothing
      Me.chbEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEmisor.IsPK = False
      Me.chbEmisor.IsRequired = False
      Me.chbEmisor.Key = Nothing
      Me.chbEmisor.LabelAsoc = Nothing
      Me.chbEmisor.Location = New System.Drawing.Point(365, 63)
      Me.chbEmisor.Name = "chbEmisor"
      Me.chbEmisor.Size = New System.Drawing.Size(57, 17)
      Me.chbEmisor.TabIndex = 13
      Me.chbEmisor.Text = "Emisor"
      Me.chbEmisor.UseVisualStyleBackColor = True
      '
      'cmbEmisor
      '
      Me.cmbEmisor.BindearPropiedadControl = Nothing
      Me.cmbEmisor.BindearPropiedadEntidad = Nothing
      Me.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEmisor.Enabled = False
      Me.cmbEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEmisor.FormattingEnabled = True
      Me.cmbEmisor.IsPK = False
      Me.cmbEmisor.IsRequired = False
      Me.cmbEmisor.Key = Nothing
      Me.cmbEmisor.LabelAsoc = Me.chbEmisor
      Me.cmbEmisor.Location = New System.Drawing.Point(423, 61)
      Me.cmbEmisor.Name = "cmbEmisor"
      Me.cmbEmisor.Size = New System.Drawing.Size(40, 21)
      Me.cmbEmisor.TabIndex = 14
      '
      'cboLetra
      '
      Me.cboLetra.BindearPropiedadControl = Nothing
      Me.cboLetra.BindearPropiedadEntidad = Nothing
      Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLetra.Enabled = False
      Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.IsPK = False
      Me.cboLetra.IsRequired = False
      Me.cboLetra.Key = Nothing
      Me.cboLetra.LabelAsoc = Me.chbLetra
      Me.cboLetra.Location = New System.Drawing.Point(319, 61)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(38, 21)
      Me.cboLetra.TabIndex = 12
      '
      'chbNumero
      '
      Me.chbNumero.AutoSize = True
      Me.chbNumero.BindearPropiedadControl = Nothing
      Me.chbNumero.BindearPropiedadEntidad = Nothing
      Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumero.IsPK = False
      Me.chbNumero.IsRequired = False
      Me.chbNumero.Key = Nothing
      Me.chbNumero.LabelAsoc = Nothing
      Me.chbNumero.Location = New System.Drawing.Point(472, 63)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(63, 17)
      Me.chbNumero.TabIndex = 15
      Me.chbNumero.Text = "Numero"
      Me.chbNumero.UseVisualStyleBackColor = True
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.Enabled = False
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = "##0"
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Me.chbNumero
      Me.txtNumero.Location = New System.Drawing.Point(537, 61)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(59, 20)
      Me.txtNumero.TabIndex = 16
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.cmbTiposComprobantes.LabelAsoc = Me.chbTipoComprobante
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(116, 61)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
      Me.cmbTiposComprobantes.TabIndex = 10
      '
      'chbTipoComprobante
      '
      Me.chbTipoComprobante.AutoSize = True
      Me.chbTipoComprobante.BindearPropiedadControl = Nothing
      Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoComprobante.IsPK = False
      Me.chbTipoComprobante.IsRequired = False
      Me.chbTipoComprobante.Key = Nothing
      Me.chbTipoComprobante.LabelAsoc = Nothing
      Me.chbTipoComprobante.Location = New System.Drawing.Point(15, 63)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(95, 17)
      Me.chbTipoComprobante.TabIndex = 9
      Me.chbTipoComprobante.Text = "Tipo Comprob."
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(384, 28)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(85, 13)
      Me.Label1.TabIndex = 5
      Me.Label1.Text = "Tipo Liquidacion"
      '
      'cmbTiposLiquidacion
      '
      Me.cmbTiposLiquidacion.BindearPropiedadControl = ""
      Me.cmbTiposLiquidacion.BindearPropiedadEntidad = ""
      Me.cmbTiposLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposLiquidacion.FormattingEnabled = True
      Me.cmbTiposLiquidacion.IsPK = False
      Me.cmbTiposLiquidacion.IsRequired = True
      Me.cmbTiposLiquidacion.Key = Nothing
      Me.cmbTiposLiquidacion.LabelAsoc = Nothing
      Me.cmbTiposLiquidacion.Location = New System.Drawing.Point(476, 24)
      Me.cmbTiposLiquidacion.Name = "cmbTiposLiquidacion"
      Me.cmbTiposLiquidacion.Size = New System.Drawing.Size(120, 21)
      Me.cmbTiposLiquidacion.TabIndex = 6
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
      Me.chbCategoria.Location = New System.Drawing.Point(440, 109)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 22
      Me.chbCategoria.Text = "Categoria"
      Me.chbCategoria.UseVisualStyleBackColor = True
      '
      'cmbCategorias
      '
      Me.cmbCategorias.BindearPropiedadControl = ""
      Me.cmbCategorias.BindearPropiedadEntidad = ""
      Me.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategorias.Enabled = False
      Me.cmbCategorias.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategorias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategorias.FormattingEnabled = True
      Me.cmbCategorias.IsPK = False
      Me.cmbCategorias.IsRequired = True
      Me.cmbCategorias.Key = Nothing
      Me.cmbCategorias.LabelAsoc = Nothing
      Me.cmbCategorias.Location = New System.Drawing.Point(518, 107)
      Me.cmbCategorias.Name = "cmbCategorias"
      Me.cmbCategorias.Size = New System.Drawing.Size(150, 21)
      Me.cmbCategorias.TabIndex = 23
      '
      'bscNombreCliente
      '
      Me.bscNombreCliente.AyudaAncho = 608
      Me.bscNombreCliente.BindearPropiedadControl = Nothing
      Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
      Me.bscNombreCliente.ColumnasAlineacion = Nothing
      Me.bscNombreCliente.ColumnasAncho = Nothing
      Me.bscNombreCliente.ColumnasFormato = Nothing
      Me.bscNombreCliente.ColumnasOcultas = Nothing
      Me.bscNombreCliente.ColumnasTitulos = Nothing
      Me.bscNombreCliente.Datos = Nothing
      Me.bscNombreCliente.Enabled = False
      Me.bscNombreCliente.FilaDevuelta = Nothing
      Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCliente.IsDecimal = False
      Me.bscNombreCliente.IsNumber = False
      Me.bscNombreCliente.IsPK = False
      Me.bscNombreCliente.IsRequired = False
      Me.bscNombreCliente.Key = ""
      Me.bscNombreCliente.LabelAsoc = Me.lblNombreCliente
      Me.bscNombreCliente.Location = New System.Drawing.Point(202, 107)
      Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.bscNombreCliente.MaxLengh = "32767"
      Me.bscNombreCliente.Name = "bscNombreCliente"
      Me.bscNombreCliente.Permitido = True
      Me.bscNombreCliente.Selecciono = False
      Me.bscNombreCliente.Size = New System.Drawing.Size(227, 23)
      Me.bscNombreCliente.TabIndex = 21
      Me.bscNombreCliente.Titulo = Nothing
      '
      'lblNombreCliente
      '
      Me.lblNombreCliente.AutoSize = True
      Me.lblNombreCliente.LabelAsoc = Nothing
      Me.lblNombreCliente.Location = New System.Drawing.Point(202, 91)
      Me.lblNombreCliente.Name = "lblNombreCliente"
      Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCliente.TabIndex = 20
      Me.lblNombreCliente.Text = "Nombre"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasAlineacion = Nothing
      Me.bscCodigoCliente.ColumnasAncho = Nothing
      Me.bscCodigoCliente.ColumnasFormato = Nothing
      Me.bscCodigoCliente.ColumnasOcultas = Nothing
      Me.bscCodigoCliente.ColumnasTitulos = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(75, 107)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(118, 23)
      Me.bscCodigoCliente.TabIndex = 19
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(75, 91)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 18
      Me.lblCodigoCliente.Text = "Codigo"
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
      Me.chbCliente.Location = New System.Drawing.Point(15, 109)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 17
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'lblPeriodo
      '
      Me.lblPeriodo.AutoSize = True
      Me.lblPeriodo.LabelAsoc = Nothing
      Me.lblPeriodo.Location = New System.Drawing.Point(12, 27)
      Me.lblPeriodo.Name = "lblPeriodo"
      Me.lblPeriodo.Size = New System.Drawing.Size(100, 13)
      Me.lblPeriodo.TabIndex = 0
      Me.lblPeriodo.Text = "Periodo Liquidacion"
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(797, 84)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 19)
      Me.chkExpandAll.TabIndex = 25
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(797, 35)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 24
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(294, 23)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(80, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(254, 27)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(160, 23)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(80, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(116, 27)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(933, 29)
      Me.tstBarra.TabIndex = 4
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
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
      'tsbPreferencias
      '
      Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
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
      'lblTotal
      '
      Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotal.AutoSize = True
      Me.lblTotal.LabelAsoc = Nothing
      Me.lblTotal.Location = New System.Drawing.Point(798, 538)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(34, 13)
      Me.lblTotal.TabIndex = 3
      Me.lblTotal.Text = "Total:"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance12
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
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance1.TextHAlignAsString = "Center"
      UltraGridColumn8.CellAppearance = Appearance1
      UltraGridColumn8.Header.Caption = "Liquidado"
      UltraGridColumn8.Header.VisiblePosition = 0
      UltraGridColumn8.Width = 73
      UltraGridColumn30.Format = "0000/00"
      UltraGridColumn30.Header.Caption = "Periodo"
      UltraGridColumn30.Header.VisiblePosition = 1
      UltraGridColumn30.Width = 60
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.Caption = "Codigo"
      UltraGridColumn1.Header.VisiblePosition = 2
      UltraGridColumn1.Width = 60
      UltraGridColumn19.Header.Caption = "Nombre Cliente"
      UltraGridColumn19.Header.VisiblePosition = 3
      UltraGridColumn19.Width = 200
      UltraGridColumn9.Header.Caption = "Nombre de Fantasia"
      UltraGridColumn9.Header.VisiblePosition = 4
      UltraGridColumn20.Header.Caption = "Categoría"
      UltraGridColumn20.Header.VisiblePosition = 5
      UltraGridColumn20.Width = 130
      UltraGridColumn10.Header.Caption = "Zona Geografica"
      UltraGridColumn10.Header.VisiblePosition = 6
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance3
      UltraGridColumn4.Header.Caption = "Comprobante"
      UltraGridColumn4.Header.VisiblePosition = 7
      UltraGridColumn4.Width = 80
      UltraGridColumn5.Header.Caption = "Let"
      UltraGridColumn5.Header.VisiblePosition = 8
      UltraGridColumn5.Width = 37
      UltraGridColumn6.Header.Caption = "Emisor"
      UltraGridColumn6.Header.VisiblePosition = 9
      UltraGridColumn6.Width = 50
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance4
      UltraGridColumn7.Header.Caption = "Numero"
      UltraGridColumn7.Header.VisiblePosition = 10
      UltraGridColumn7.Width = 60
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn33.CellAppearance = Appearance5
      UltraGridColumn33.Format = "N2"
      UltraGridColumn33.Header.Caption = "Total"
      UltraGridColumn33.Header.VisiblePosition = 11
      UltraGridColumn33.Width = 100
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn8, UltraGridColumn30, UltraGridColumn1, UltraGridColumn19, UltraGridColumn9, UltraGridColumn20, UltraGridColumn10, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn33})
      UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
      Appearance6.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Appearance7.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.FixedHeaderAppearance = Appearance7
      Appearance8.ForeColor = System.Drawing.Color.ForestGreen
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Appearance9.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance9
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance10
      Appearance11.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(909, 327)
      Me.ugDetalle.TabIndex = 22
      Me.ugDetalle.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 540)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(933, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(854, 17)
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
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
      Me.TabPage1.Controls.Add(Me.ugDetalle)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage1.Size = New System.Drawing.Size(915, 333)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Liquidación"
      '
      'TabControl1
      '
      Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Location = New System.Drawing.Point(4, 178)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(923, 359)
      Me.TabControl1.TabIndex = 25
      '
      'UltraDataSource1
      '
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
      '
      'InfCargos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(933, 562)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.lblTotal)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbConsultar)
      Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
      Me.KeyPreview = true
      Me.Name = "InfCargos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Liquidacion de Cargos"
      Me.grbConsultar.ResumeLayout(false)
      Me.grbConsultar.PerformLayout
      Me.tstBarra.ResumeLayout(false)
      Me.tstBarra.PerformLayout
      CType(Me.ugDetalle,System.ComponentModel.ISupportInitialize).EndInit
      Me.stsStado.ResumeLayout(false)
      Me.stsStado.PerformLayout
      Me.TabPage1.ResumeLayout(false)
      Me.TabControl1.ResumeLayout(false)
      CType(Me.UltraDataSource1,System.ComponentModel.ISupportInitialize).EndInit
      Me.ResumeLayout(false)
      Me.PerformLayout

End Sub
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents lblTotal As Eniac.Controles.Label
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
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents lblPeriodo As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
    Friend WithEvents cmbCategorias As Eniac.Controles.ComboBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbTiposLiquidacion As Eniac.Controles.ComboBox
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents chbEmisor As Eniac.Controles.CheckBox
   Friend WithEvents cmbEmisor As Eniac.Controles.ComboBox
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents cmbLiquidado As Eniac.Controles.ComboBox
End Class
