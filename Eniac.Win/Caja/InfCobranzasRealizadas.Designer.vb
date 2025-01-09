<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfCobranzasRealizadas
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfCobranzasRealizadas))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCobro")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteNeto")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante2")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra2")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor2")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante2")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuotaNumero2")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha2")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasCobranza")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
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
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblOrdenarPor = New System.Windows.Forms.Label()
        Me.rbtOrdenarCobranzaPorVendedor = New System.Windows.Forms.RadioButton()
        Me.rbtOrdenarCobranzaPorFecha = New System.Windows.Forms.RadioButton()
        Me.lblTipoComprobantesAplicados = New Eniac.Controles.Label()
        Me.cmbTiposComprobantesAplicados = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTipoComprobanteAplicador = New Eniac.Controles.Label()
        Me.cmbTiposComprobantesAplicador = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabaLibro = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbFomaPago = New Eniac.Controles.CheckBox()
        Me.lblGrupoComprobante = New Eniac.Controles.Label()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.cmbGrupos = New Eniac.Win.ComboBoxGrupoTiposComprobantes()
        Me.cmbComercial = New Eniac.Controles.ComboBox()
        Me.lblComercial = New Eniac.Controles.Label()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.cmbOrigenVendedor = New Eniac.Controles.ComboBox()
        Me.grbFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbOrigenVendedor)
        Me.grbFiltros.Controls.Add(Me.Panel2)
        Me.grbFiltros.Controls.Add(Me.lblTipoComprobantesAplicados)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantesAplicados)
        Me.grbFiltros.Controls.Add(Me.lblTipoComprobanteAplicador)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantesAplicador)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabaLibro)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.chbFomaPago)
        Me.grbFiltros.Controls.Add(Me.lblGrupoComprobante)
        Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
        Me.grbFiltros.Controls.Add(Me.cmbGrupos)
        Me.grbFiltros.Controls.Add(Me.cmbComercial)
        Me.grbFiltros.Controls.Add(Me.lblComercial)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 31)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1083, 149)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblOrdenarPor)
        Me.Panel2.Controls.Add(Me.rbtOrdenarCobranzaPorVendedor)
        Me.Panel2.Controls.Add(Me.rbtOrdenarCobranzaPorFecha)
        Me.Panel2.Location = New System.Drawing.Point(6, 121)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(371, 23)
        Me.Panel2.TabIndex = 27
        '
        'lblOrdenarPor
        '
        Me.lblOrdenarPor.AutoSize = True
        Me.lblOrdenarPor.Location = New System.Drawing.Point(5, 5)
        Me.lblOrdenarPor.Name = "lblOrdenarPor"
        Me.lblOrdenarPor.Size = New System.Drawing.Size(70, 13)
        Me.lblOrdenarPor.TabIndex = 0
        Me.lblOrdenarPor.Text = "Ordenar Por :"
        '
        'rbtOrdenarCobranzaPorVendedor
        '
        Me.rbtOrdenarCobranzaPorVendedor.AutoSize = True
        Me.rbtOrdenarCobranzaPorVendedor.Location = New System.Drawing.Point(217, 3)
        Me.rbtOrdenarCobranzaPorVendedor.Name = "rbtOrdenarCobranzaPorVendedor"
        Me.rbtOrdenarCobranzaPorVendedor.Size = New System.Drawing.Size(145, 17)
        Me.rbtOrdenarCobranzaPorVendedor.TabIndex = 2
        Me.rbtOrdenarCobranzaPorVendedor.TabStop = True
        Me.rbtOrdenarCobranzaPorVendedor.Text = "Vendedor / Comprobante"
        Me.rbtOrdenarCobranzaPorVendedor.UseVisualStyleBackColor = True
        '
        'rbtOrdenarCobranzaPorFecha
        '
        Me.rbtOrdenarCobranzaPorFecha.AutoSize = True
        Me.rbtOrdenarCobranzaPorFecha.Checked = True
        Me.rbtOrdenarCobranzaPorFecha.Location = New System.Drawing.Point(82, 3)
        Me.rbtOrdenarCobranzaPorFecha.Name = "rbtOrdenarCobranzaPorFecha"
        Me.rbtOrdenarCobranzaPorFecha.Size = New System.Drawing.Size(129, 17)
        Me.rbtOrdenarCobranzaPorFecha.TabIndex = 1
        Me.rbtOrdenarCobranzaPorFecha.TabStop = True
        Me.rbtOrdenarCobranzaPorFecha.Text = "Fecha / Comprobante"
        Me.rbtOrdenarCobranzaPorFecha.UseVisualStyleBackColor = True
        '
        'lblTipoComprobantesAplicados
        '
        Me.lblTipoComprobantesAplicados.AutoSize = True
        Me.lblTipoComprobantesAplicados.LabelAsoc = Nothing
        Me.lblTipoComprobantesAplicados.Location = New System.Drawing.Point(383, 98)
        Me.lblTipoComprobantesAplicados.Name = "lblTipoComprobantesAplicados"
        Me.lblTipoComprobantesAplicados.Size = New System.Drawing.Size(143, 13)
        Me.lblTipoComprobantesAplicados.TabIndex = 23
        Me.lblTipoComprobantesAplicados.Text = "Tipo Comprobante Aplicados"
        '
        'cmbTiposComprobantesAplicados
        '
        Me.cmbTiposComprobantesAplicados.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantesAplicados.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantesAplicados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesAplicados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantesAplicados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesAplicados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesAplicados.FormattingEnabled = True
        Me.cmbTiposComprobantesAplicados.IsPK = False
        Me.cmbTiposComprobantesAplicados.IsRequired = False
        Me.cmbTiposComprobantesAplicados.ItemHeight = 13
        Me.cmbTiposComprobantesAplicados.Key = Nothing
        Me.cmbTiposComprobantesAplicados.LabelAsoc = Me.lblTipoComprobantesAplicados
        Me.cmbTiposComprobantesAplicados.Location = New System.Drawing.Point(538, 94)
        Me.cmbTiposComprobantesAplicados.Name = "cmbTiposComprobantesAplicados"
        Me.cmbTiposComprobantesAplicados.Size = New System.Drawing.Size(200, 21)
        Me.cmbTiposComprobantesAplicados.TabIndex = 24
        '
        'lblTipoComprobanteAplicador
        '
        Me.lblTipoComprobanteAplicador.AutoSize = True
        Me.lblTipoComprobanteAplicador.LabelAsoc = Nothing
        Me.lblTipoComprobanteAplicador.Location = New System.Drawing.Point(6, 98)
        Me.lblTipoComprobanteAplicador.Name = "lblTipoComprobanteAplicador"
        Me.lblTipoComprobanteAplicador.Size = New System.Drawing.Size(141, 13)
        Me.lblTipoComprobanteAplicador.TabIndex = 21
        Me.lblTipoComprobanteAplicador.Text = "Tipo Comprobante Aplicador"
        '
        'cmbTiposComprobantesAplicador
        '
        Me.cmbTiposComprobantesAplicador.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantesAplicador.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantesAplicador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesAplicador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantesAplicador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesAplicador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesAplicador.FormattingEnabled = True
        Me.cmbTiposComprobantesAplicador.IsPK = False
        Me.cmbTiposComprobantesAplicador.IsRequired = False
        Me.cmbTiposComprobantesAplicador.ItemHeight = 13
        Me.cmbTiposComprobantesAplicador.Key = Nothing
        Me.cmbTiposComprobantesAplicador.LabelAsoc = Me.lblTipoComprobanteAplicador
        Me.cmbTiposComprobantesAplicador.Location = New System.Drawing.Point(155, 94)
        Me.cmbTiposComprobantesAplicador.Name = "cmbTiposComprobantesAplicador"
        Me.cmbTiposComprobantesAplicador.Size = New System.Drawing.Size(200, 21)
        Me.cmbTiposComprobantesAplicador.TabIndex = 22
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
        Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabaLibro
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(819, 26)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(70, 21)
        Me.cmbGrabanLibro.TabIndex = 10
        '
        'lblGrabaLibro
        '
        Me.lblGrabaLibro.AutoSize = True
        Me.lblGrabaLibro.LabelAsoc = Nothing
        Me.lblGrabaLibro.Location = New System.Drawing.Point(745, 30)
        Me.lblGrabaLibro.Name = "lblGrabaLibro"
        Me.lblGrabaLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabaLibro.TabIndex = 9
        Me.lblGrabaLibro.Text = "Graban Libro"
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
        Me.cmbSucursal.Location = New System.Drawing.Point(55, 26)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(119, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(6, 30)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.AutoSize = True
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(973, 125)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
        Me.chkExpandAll.TabIndex = 29
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'chbFomaPago
        '
        Me.chbFomaPago.AutoSize = True
        Me.chbFomaPago.BindearPropiedadControl = Nothing
        Me.chbFomaPago.BindearPropiedadEntidad = Nothing
        Me.chbFomaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFomaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFomaPago.IsPK = False
        Me.chbFomaPago.IsRequired = False
        Me.chbFomaPago.Key = Nothing
        Me.chbFomaPago.LabelAsoc = Nothing
        Me.chbFomaPago.Location = New System.Drawing.Point(719, 67)
        Me.chbFomaPago.Name = "chbFomaPago"
        Me.chbFomaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFomaPago.TabIndex = 19
        Me.chbFomaPago.Text = "Forma de Pago"
        Me.chbFomaPago.UseVisualStyleBackColor = True
        '
        'lblGrupoComprobante
        '
        Me.lblGrupoComprobante.AutoSize = True
        Me.lblGrupoComprobante.LabelAsoc = Nothing
        Me.lblGrupoComprobante.Location = New System.Drawing.Point(760, 98)
        Me.lblGrupoComprobante.Name = "lblGrupoComprobante"
        Me.lblGrupoComprobante.Size = New System.Drawing.Size(36, 13)
        Me.lblGrupoComprobante.TabIndex = 25
        Me.lblGrupoComprobante.Text = "Grupo"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Nothing
        Me.cmbFormaPago.Location = New System.Drawing.Point(819, 65)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(143, 21)
        Me.cmbFormaPago.TabIndex = 20
        '
        'cmbGrupos
        '
        Me.cmbGrupos.BindearPropiedadControl = Nothing
        Me.cmbGrupos.BindearPropiedadEntidad = Nothing
        Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupos.FormattingEnabled = True
        Me.cmbGrupos.IsPK = False
        Me.cmbGrupos.IsRequired = False
        Me.cmbGrupos.Key = Nothing
        Me.cmbGrupos.LabelAsoc = Me.lblGrupoComprobante
        Me.cmbGrupos.Location = New System.Drawing.Point(819, 94)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(143, 21)
        Me.cmbGrupos.TabIndex = 26
        '
        'cmbComercial
        '
        Me.cmbComercial.BindearPropiedadControl = Nothing
        Me.cmbComercial.BindearPropiedadEntidad = Nothing
        Me.cmbComercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComercial.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbComercial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbComercial.FormattingEnabled = True
        Me.cmbComercial.IsPK = False
        Me.cmbComercial.IsRequired = False
        Me.cmbComercial.Key = Nothing
        Me.cmbComercial.LabelAsoc = Me.lblComercial
        Me.cmbComercial.Location = New System.Drawing.Point(668, 26)
        Me.cmbComercial.Name = "cmbComercial"
        Me.cmbComercial.Size = New System.Drawing.Size(70, 21)
        Me.cmbComercial.TabIndex = 8
        '
        'lblComercial
        '
        Me.lblComercial.AutoSize = True
        Me.lblComercial.LabelAsoc = Nothing
        Me.lblComercial.Location = New System.Drawing.Point(609, 30)
        Me.lblComercial.Name = "lblComercial"
        Me.lblComercial.Size = New System.Drawing.Size(53, 13)
        Me.lblComercial.TabIndex = 7
        Me.lblComercial.Text = "Comercial"
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(184, 28)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 2
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
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
        Me.chbVendedor.Location = New System.Drawing.Point(381, 67)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 16
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
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Location = New System.Drawing.Point(453, 65)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(129, 21)
        Me.cmbVendedor.TabIndex = 17
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
        Me.chbCliente.Location = New System.Drawing.Point(6, 67)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 11
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(480, 26)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpHasta.TabIndex = 6
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(439, 30)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 5
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(328, 26)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesde.TabIndex = 4
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(284, 30)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 3
        Me.lblDesde.Text = "Desde"
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
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = True
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(70, 64)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(84, 23)
        Me.bscCodigoCliente.TabIndex = 13
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(67, 50)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 12
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 608
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ColumnasAlineacion = Nothing
        Me.bscCliente.ColumnasAncho = Nothing
        Me.bscCliente.ColumnasFormato = Nothing
        Me.bscCliente.ColumnasOcultas = Nothing
        Me.bscCliente.ColumnasTitulos = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.Enabled = False
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(161, 64)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(200, 23)
        Me.bscCliente.TabIndex = 15
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(161, 50)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 14
        Me.lblNombre.Text = "Nombre"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(973, 74)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 28
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbImprimir2, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1107, 29)
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
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
        'tsbImprimir2
        '
        Me.tsbImprimir2.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir2.Name = "tsbImprimir2"
        Me.tsbImprimir2.Size = New System.Drawing.Size(147, 26)
        Me.tsbImprimir2.Text = "&Imprimir Prediseñado"
        Me.tsbImprimir2.ToolTipText = "Imprimir y Grabar (F4)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 550)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1107, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1028, 17)
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
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "S."
        UltraGridColumn1.Header.VisiblePosition = 2
        UltraGridColumn1.Width = 32
        UltraGridColumn2.Header.Caption = "Emisión"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 73
        UltraGridColumn3.Header.Caption = "Comprobante"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Width = 100
        UltraGridColumn4.Header.Caption = "Let."
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 29
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "P.V."
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 33
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance4
        UltraGridColumn6.Header.Caption = "Numero"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 51
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Hidden = True
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance5
        UltraGridColumn8.Format = "N2"
        UltraGridColumn8.Header.Caption = "Neto"
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.Width = 70
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance6
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.Caption = "Total"
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn9.Width = 66
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.Caption = "Nombre Cliente"
        UltraGridColumn12.Header.VisiblePosition = 8
        UltraGridColumn12.Width = 143
        UltraGridColumn15.Header.Caption = "Nombre Vendedor"
        UltraGridColumn15.Header.VisiblePosition = 0
        UltraGridColumn15.Width = 104
        UltraGridColumn16.Header.Caption = "Comprob Aplic."
        UltraGridColumn16.Header.VisiblePosition = 13
        UltraGridColumn16.Width = 100
        UltraGridColumn17.Header.Caption = "Let."
        UltraGridColumn17.Header.VisiblePosition = 14
        UltraGridColumn17.Width = 31
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance7
        UltraGridColumn18.Header.Caption = "P.V."
        UltraGridColumn18.Header.VisiblePosition = 15
        UltraGridColumn18.Width = 30
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance8
        UltraGridColumn19.Header.Caption = "Numero"
        UltraGridColumn19.Header.VisiblePosition = 16
        UltraGridColumn19.Width = 52
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance9
        UltraGridColumn20.Header.Caption = "Cta."
        UltraGridColumn20.Header.VisiblePosition = 17
        UltraGridColumn20.Width = 37
        UltraGridColumn21.Header.Caption = "Fec. Comp."
        UltraGridColumn21.Header.VisiblePosition = 18
        UltraGridColumn21.Width = 65
        UltraGridColumn22.Header.Caption = "Dias Cob."
        UltraGridColumn22.Header.VisiblePosition = 19
        UltraGridColumn22.Width = 38
        UltraGridColumn23.Header.Caption = "Forma Pago"
        UltraGridColumn23.Header.VisiblePosition = 20
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 76
        UltraGridColumn24.Header.Caption = "Forma Pago"
        UltraGridColumn24.Header.VisiblePosition = 21
        UltraGridColumn24.Width = 72
        UltraGridColumn25.Header.VisiblePosition = 22
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.Header.VisiblePosition = 24
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.Header.VisiblePosition = 23
        UltraGridColumn27.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance10
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance12.BackColor2 = System.Drawing.SystemColors.Control
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.SystemColors.Highlight
        Appearance14.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance14
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance16
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance17.BackColor = System.Drawing.SystemColors.Control
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance17
        Appearance18.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance18
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(13, 184)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1082, 363)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance21
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
        'cmbOrigenVendedor
        '
        Me.cmbOrigenVendedor.BindearPropiedadControl = Nothing
        Me.cmbOrigenVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenVendedor.FormattingEnabled = True
        Me.cmbOrigenVendedor.IsPK = False
        Me.cmbOrigenVendedor.IsRequired = False
        Me.cmbOrigenVendedor.Key = Nothing
        Me.cmbOrigenVendedor.LabelAsoc = Me.lblComercial
        Me.cmbOrigenVendedor.Location = New System.Drawing.Point(588, 65)
        Me.cmbOrigenVendedor.Name = "cmbOrigenVendedor"
        Me.cmbOrigenVendedor.Size = New System.Drawing.Size(103, 21)
        Me.cmbOrigenVendedor.TabIndex = 18
        '
        'InfCobranzasRealizadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1107, 572)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InfCobranzasRealizadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Cobranzas Realizadas"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
    Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbComercial As Eniac.Controles.ComboBox
   Friend WithEvents lblComercial As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbFomaPago As Eniac.Controles.CheckBox
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents lblGrupoComprobante As Eniac.Controles.Label
   Friend WithEvents cmbGrupos As Eniac.Win.ComboBoxGrupoTiposComprobantes
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabaLibro As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantesAplicador As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents cmbTiposComprobantesAplicados As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobantesAplicados As Eniac.Controles.Label
   Friend WithEvents lblTipoComprobanteAplicador As Eniac.Controles.Label
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents lblOrdenarPor As System.Windows.Forms.Label
   Friend WithEvents rbtOrdenarCobranzaPorVendedor As System.Windows.Forms.RadioButton
   Friend WithEvents rbtOrdenarCobranzaPorFecha As System.Windows.Forms.RadioButton
    Friend WithEvents cmbOrigenVendedor As Controles.ComboBox
End Class
