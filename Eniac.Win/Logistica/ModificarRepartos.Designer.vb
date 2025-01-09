<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarRepartos
   Inherits System.Windows.Forms.Form

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarRepartos))
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos", -1)
      Dim UltraGridColumn149 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn150 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn151 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn152 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn153 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn154 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn155 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn156 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn157 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn158 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn159 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn160 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
      Dim UltraGridColumn161 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn162 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
      Dim UltraGridColumn163 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
      Dim UltraGridColumn164 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn165 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
      Dim UltraGridColumn166 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn167 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn168 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn169 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
      Dim UltraGridColumn170 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
      Dim UltraGridColumn171 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn172 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
      Dim UltraGridColumn173 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
      Dim UltraGridColumn174 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo")
      Dim UltraGridColumn175 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuentaCorriente")
      Dim UltraGridColumn176 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
      Dim UltraGridColumn177 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
      Dim UltraGridColumn178 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
      Dim UltraGridColumn179 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioNueva")
      Dim UltraGridColumn180 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportistaNuevo")
      Dim UltraGridColumn181 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportistaNuevo")
      Dim UltraGridColumn182 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
      Dim UltraGridColumn183 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
      Dim UltraGridColumn184 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
      Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "ImporteTotal", 17, True, "Pedidos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
      Dim UltraGridColumn185 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn186 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn187 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn188 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn189 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn190 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn191 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn192 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn193 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn194 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn195 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn196 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn197 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
      Dim UltraGridColumn198 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
      Dim UltraGridColumn199 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn200 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
      Dim UltraGridColumn201 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim UltraGridColumn202 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
      Dim UltraGridColumn203 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
      Dim UltraGridColumn204 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
      Dim UltraGridColumn205 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
      Dim UltraGridColumn206 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn207 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn208 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn209 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn210 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim UltraGridColumn211 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
      Dim UltraGridColumn212 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
      Dim UltraGridColumn213 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
      Dim UltraGridColumn214 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
      Dim UltraGridColumn215 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
      Dim UltraGridColumn216 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
      Dim UltraGridColumn217 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
      Dim UltraGridColumn218 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim UltraGridColumn219 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn220 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn221 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
      Dim UltraGridColumn222 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbTransportista = New System.Windows.Forms.CheckBox()
      Me.chbFechaEnvio = New System.Windows.Forms.CheckBox()
      Me.cmbTransportista = New Eniac.Controles.ComboBox()
      Me.lblTransportista = New Eniac.Controles.Label()
      Me.dtpFechaEnvio = New Eniac.Controles.DateTimePicker()
      Me.bscReparto2 = New Eniac.Controles.Buscador2()
      Me.lblFechaEnvio = New Eniac.Controles.Label()
      Me.lblNumeroReparto = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.ugComprobantes = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.bscComprobante2 = New Eniac.Controles.Buscador2()
      Me.PedidosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DtsRegistracionPagos = New Eniac.Win.dtsRegistracionPagos()
      Me.PedidosProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PedidosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DtsRegistracionPagos, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PedidosProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(984, 22)
      Me.stsStado.TabIndex = 4
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbGrabar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.tss2, Me.tsddExportar, Me.tss3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 5
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
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
      Me.tsbGrabar.Text = "Grabar (F4)"
      Me.tsbGrabar.ToolTipText = "Grabar Modificaciones"
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
      'tss2
      '
      Me.tss2.Name = "tss2"
      Me.tss2.Size = New System.Drawing.Size(6, 29)
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
      'tss3
      '
      Me.tss3.Name = "tss3"
      Me.tss3.Size = New System.Drawing.Size(6, 29)
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
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.chbTransportista)
      Me.grbFiltros.Controls.Add(Me.chbFechaEnvio)
      Me.grbFiltros.Controls.Add(Me.cmbTransportista)
      Me.grbFiltros.Controls.Add(Me.dtpFechaEnvio)
      Me.grbFiltros.Controls.Add(Me.bscReparto2)
      Me.grbFiltros.Controls.Add(Me.lblTransportista)
      Me.grbFiltros.Controls.Add(Me.lblFechaEnvio)
      Me.grbFiltros.Controls.Add(Me.lblNumeroReparto)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(956, 61)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Reparto"
      '
      'chbTransportista
      '
      Me.chbTransportista.AutoSize = True
      Me.chbTransportista.Location = New System.Drawing.Point(417, 22)
      Me.chbTransportista.Name = "chbTransportista"
      Me.chbTransportista.Size = New System.Drawing.Size(15, 14)
      Me.chbTransportista.TabIndex = 5
      Me.chbTransportista.UseVisualStyleBackColor = True
      '
      'chbFechaEnvio
      '
      Me.chbFechaEnvio.AutoSize = True
      Me.chbFechaEnvio.Location = New System.Drawing.Point(202, 22)
      Me.chbFechaEnvio.Name = "chbFechaEnvio"
      Me.chbFechaEnvio.Size = New System.Drawing.Size(15, 14)
      Me.chbFechaEnvio.TabIndex = 2
      Me.chbFechaEnvio.UseVisualStyleBackColor = True
      '
      'cmbTransportista
      '
      Me.cmbTransportista.BindearPropiedadControl = "SelectedValue"
      Me.cmbTransportista.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
      Me.cmbTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTransportista.Enabled = False
      Me.cmbTransportista.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTransportista.FormattingEnabled = True
      Me.cmbTransportista.IsPK = False
      Me.cmbTransportista.IsRequired = True
      Me.cmbTransportista.Key = Nothing
      Me.cmbTransportista.LabelAsoc = Me.lblTransportista
      Me.cmbTransportista.Location = New System.Drawing.Point(529, 19)
      Me.cmbTransportista.Name = "cmbTransportista"
      Me.cmbTransportista.Size = New System.Drawing.Size(260, 21)
      Me.cmbTransportista.TabIndex = 7
      '
      'lblTransportista
      '
      Me.lblTransportista.AutoSize = True
      Me.lblTransportista.LabelAsoc = Nothing
      Me.lblTransportista.Location = New System.Drawing.Point(430, 23)
      Me.lblTransportista.Name = "lblTransportista"
      Me.lblTransportista.Size = New System.Drawing.Size(93, 13)
      Me.lblTransportista.TabIndex = 6
      Me.lblTransportista.Text = "Resp. Distribución"
      '
      'dtpFechaEnvio
      '
      Me.dtpFechaEnvio.BindearPropiedadControl = Nothing
      Me.dtpFechaEnvio.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEnvio.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaEnvio.Enabled = False
      Me.dtpFechaEnvio.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEnvio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEnvio.IsPK = False
      Me.dtpFechaEnvio.IsRequired = False
      Me.dtpFechaEnvio.Key = ""
      Me.dtpFechaEnvio.LabelAsoc = Nothing
      Me.dtpFechaEnvio.Location = New System.Drawing.Point(288, 19)
      Me.dtpFechaEnvio.Name = "dtpFechaEnvio"
      Me.dtpFechaEnvio.Size = New System.Drawing.Size(97, 20)
      Me.dtpFechaEnvio.TabIndex = 4
      '
      'bscReparto2
      '
      Me.bscReparto2.ActivarFiltroEnGrilla = True
      Me.bscReparto2.AutoSize = True
      Me.bscReparto2.BindearPropiedadControl = Nothing
      Me.bscReparto2.BindearPropiedadEntidad = Nothing
      Me.bscReparto2.ConfigBuscador = Nothing
      Me.bscReparto2.Datos = Nothing
      Me.bscReparto2.FilaDevuelta = Nothing
      Me.bscReparto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscReparto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscReparto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscReparto2.IsDecimal = False
      Me.bscReparto2.IsNumber = False
      Me.bscReparto2.IsPK = False
      Me.bscReparto2.IsRequired = False
      Me.bscReparto2.Key = ""
      Me.bscReparto2.LabelAsoc = Nothing
      Me.bscReparto2.Location = New System.Drawing.Point(80, 18)
      Me.bscReparto2.Margin = New System.Windows.Forms.Padding(4)
      Me.bscReparto2.MaxLengh = "32767"
      Me.bscReparto2.Name = "bscReparto2"
      Me.bscReparto2.Permitido = True
      Me.bscReparto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscReparto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscReparto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscReparto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscReparto2.Selecciono = False
      Me.bscReparto2.Size = New System.Drawing.Size(92, 23)
      Me.bscReparto2.TabIndex = 1
      '
      'lblFechaEnvio
      '
      Me.lblFechaEnvio.AutoSize = True
      Me.lblFechaEnvio.LabelAsoc = Nothing
      Me.lblFechaEnvio.Location = New System.Drawing.Point(215, 23)
      Me.lblFechaEnvio.Name = "lblFechaEnvio"
      Me.lblFechaEnvio.Size = New System.Drawing.Size(67, 13)
      Me.lblFechaEnvio.TabIndex = 3
      Me.lblFechaEnvio.Text = "Fecha Envio"
      '
      'lblNumeroReparto
      '
      Me.lblNumeroReparto.AutoSize = True
      Me.lblNumeroReparto.LabelAsoc = Nothing
      Me.lblNumeroReparto.Location = New System.Drawing.Point(32, 23)
      Me.lblNumeroReparto.Name = "lblNumeroReparto"
      Me.lblNumeroReparto.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroReparto.TabIndex = 0
      Me.lblNumeroReparto.Text = "Número"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(846, 9)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(102, 45)
      Me.btnConsultar.TabIndex = 8
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'ugComprobantes
      '
      Me.ugComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ugComprobantes.DataSource = Me.PedidosBindingSource
      Appearance1.TextHAlignAsString = "Right"
      UltraGridColumn149.CellAppearance = Appearance1
      UltraGridColumn149.Header.VisiblePosition = 16
      UltraGridColumn149.Hidden = True
      UltraGridColumn150.Header.Caption = "Tipo"
      UltraGridColumn150.Header.VisiblePosition = 6
      UltraGridColumn150.Width = 90
      UltraGridColumn151.Header.Caption = "L"
      UltraGridColumn151.Header.VisiblePosition = 7
      UltraGridColumn151.Width = 25
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn152.CellAppearance = Appearance2
      UltraGridColumn152.Header.Caption = "Emisor"
      UltraGridColumn152.Header.VisiblePosition = 8
      UltraGridColumn152.Width = 53
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn153.CellAppearance = Appearance3
      UltraGridColumn153.Header.Caption = "Nro."
      UltraGridColumn153.Header.VisiblePosition = 9
      UltraGridColumn153.Width = 62
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn154.CellAppearance = Appearance4
      UltraGridColumn154.Header.VisiblePosition = 17
      UltraGridColumn154.Hidden = True
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn155.CellAppearance = Appearance5
      UltraGridColumn155.Header.Caption = "Código"
      UltraGridColumn155.Header.VisiblePosition = 2
      UltraGridColumn155.Width = 50
      UltraGridColumn156.Header.VisiblePosition = 18
      UltraGridColumn156.Hidden = True
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn157.CellAppearance = Appearance6
      UltraGridColumn157.Header.VisiblePosition = 19
      UltraGridColumn157.Hidden = True
      UltraGridColumn158.Header.Caption = "Cliente"
      UltraGridColumn158.Header.VisiblePosition = 3
      UltraGridColumn158.Width = 130
      UltraGridColumn159.Header.VisiblePosition = 4
      UltraGridColumn159.Width = 110
      UltraGridColumn160.Header.Caption = "Resp. Distribución"
      UltraGridColumn160.Header.VisiblePosition = 12
      UltraGridColumn160.Width = 105
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn161.CellAppearance = Appearance7
      UltraGridColumn161.Header.VisiblePosition = 20
      UltraGridColumn161.Hidden = True
      UltraGridColumn162.Header.Caption = "Vendedor"
      UltraGridColumn162.Header.VisiblePosition = 14
      UltraGridColumn162.Width = 100
      UltraGridColumn163.Header.VisiblePosition = 15
      UltraGridColumn164.Header.Caption = "F. Pedido"
      UltraGridColumn164.Header.VisiblePosition = 13
      UltraGridColumn164.Width = 64
      UltraGridColumn165.Header.Caption = "F. Envio"
      UltraGridColumn165.Header.VisiblePosition = 11
      UltraGridColumn165.Width = 64
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn166.CellAppearance = Appearance8
      UltraGridColumn166.Format = "N2"
      UltraGridColumn166.Header.Caption = "Total"
      UltraGridColumn166.Header.VisiblePosition = 5
      UltraGridColumn166.MaskInput = "{double:-12.2}"
      UltraGridColumn166.Width = 70
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn167.CellAppearance = Appearance9
      UltraGridColumn167.Header.VisiblePosition = 21
      UltraGridColumn167.Hidden = True
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn168.CellAppearance = Appearance10
      UltraGridColumn168.Header.Caption = "Reparto"
      UltraGridColumn168.Header.VisiblePosition = 10
      UltraGridColumn169.Header.VisiblePosition = 22
      UltraGridColumn169.Hidden = True
      UltraGridColumn169.Width = 64
      UltraGridColumn170.Header.Caption = "F.P. Cliente"
      UltraGridColumn170.Header.VisiblePosition = 1
      UltraGridColumn170.Width = 69
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn171.CellAppearance = Appearance11
      UltraGridColumn171.Header.VisiblePosition = 23
      UltraGridColumn171.Hidden = True
      UltraGridColumn172.Header.VisiblePosition = 24
      UltraGridColumn172.Hidden = True
      UltraGridColumn173.Header.Caption = "Forma Pago"
      UltraGridColumn173.Header.VisiblePosition = 0
      UltraGridColumn173.Hidden = True
      UltraGridColumn174.Header.VisiblePosition = 25
      UltraGridColumn174.Hidden = True
      UltraGridColumn175.Header.VisiblePosition = 26
      UltraGridColumn175.Hidden = True
      UltraGridColumn176.Header.VisiblePosition = 27
      UltraGridColumn176.Hidden = True
      UltraGridColumn177.Header.VisiblePosition = 28
      UltraGridColumn177.Hidden = True
      UltraGridColumn178.Header.VisiblePosition = 29
      UltraGridColumn178.Hidden = True
      UltraGridColumn179.Header.VisiblePosition = 30
      UltraGridColumn179.Hidden = True
      UltraGridColumn180.Header.VisiblePosition = 31
      UltraGridColumn180.Hidden = True
      UltraGridColumn181.Header.VisiblePosition = 32
      UltraGridColumn181.Hidden = True
      UltraGridColumn182.Header.VisiblePosition = 33
      UltraGridColumn182.Hidden = True
      UltraGridColumn183.Header.VisiblePosition = 34
      UltraGridColumn184.Header.VisiblePosition = 35
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn149, UltraGridColumn150, UltraGridColumn151, UltraGridColumn152, UltraGridColumn153, UltraGridColumn154, UltraGridColumn155, UltraGridColumn156, UltraGridColumn157, UltraGridColumn158, UltraGridColumn159, UltraGridColumn160, UltraGridColumn161, UltraGridColumn162, UltraGridColumn163, UltraGridColumn164, UltraGridColumn165, UltraGridColumn166, UltraGridColumn167, UltraGridColumn168, UltraGridColumn169, UltraGridColumn170, UltraGridColumn171, UltraGridColumn172, UltraGridColumn173, UltraGridColumn174, UltraGridColumn175, UltraGridColumn176, UltraGridColumn177, UltraGridColumn178, UltraGridColumn179, UltraGridColumn180, UltraGridColumn181, UltraGridColumn182, UltraGridColumn183, UltraGridColumn184})
      SummarySettings1.DisplayFormat = "{0:N2}"
      SummarySettings1.GroupBySummaryValueAppearance = Appearance12
      SummarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
      UltraGridBand1.SummaryFooterCaption = "Total Pedidos:"
      Appearance13.TextHAlignAsString = "Right"
      UltraGridColumn185.CellAppearance = Appearance13
      UltraGridColumn185.Header.VisiblePosition = 0
      UltraGridColumn185.Hidden = True
      UltraGridColumn185.Width = 56
      UltraGridColumn186.Header.VisiblePosition = 1
      UltraGridColumn186.Hidden = True
      UltraGridColumn186.Width = 69
      UltraGridColumn187.Header.VisiblePosition = 2
      UltraGridColumn187.Hidden = True
      UltraGridColumn187.Width = 50
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn188.CellAppearance = Appearance14
      UltraGridColumn188.Header.VisiblePosition = 3
      UltraGridColumn188.Hidden = True
      UltraGridColumn188.Width = 130
      Appearance15.TextHAlignAsString = "Right"
      UltraGridColumn189.CellAppearance = Appearance15
      UltraGridColumn189.Header.VisiblePosition = 4
      UltraGridColumn189.Hidden = True
      UltraGridColumn189.Width = 110
      Appearance16.TextHAlignAsString = "Right"
      UltraGridColumn190.CellAppearance = Appearance16
      UltraGridColumn190.Header.Caption = "Código"
      UltraGridColumn190.Header.VisiblePosition = 6
      UltraGridColumn190.MaxWidth = 80
      UltraGridColumn190.Width = 80
      Appearance17.TextHAlignAsString = "Right"
      UltraGridColumn191.CellAppearance = Appearance17
      UltraGridColumn191.Header.VisiblePosition = 5
      UltraGridColumn191.MaxWidth = 50
      UltraGridColumn191.MinWidth = 50
      UltraGridColumn191.Width = 50
      UltraGridColumn192.Header.Caption = "Producto"
      UltraGridColumn192.Header.VisiblePosition = 7
      UltraGridColumn192.Width = 377
      Appearance18.TextHAlignAsString = "Right"
      UltraGridColumn193.CellAppearance = Appearance18
      UltraGridColumn193.Format = "N2"
      UltraGridColumn193.Header.VisiblePosition = 8
      UltraGridColumn193.MaskInput = "{double:-12.2}"
      UltraGridColumn193.MaxWidth = 60
      UltraGridColumn193.MinWidth = 60
      UltraGridColumn193.Width = 60
      Appearance19.TextHAlignAsString = "Right"
      UltraGridColumn194.CellAppearance = Appearance19
      UltraGridColumn194.Format = "N2"
      UltraGridColumn194.Header.VisiblePosition = 9
      UltraGridColumn194.Hidden = True
      UltraGridColumn194.MaskInput = "{double:-12.2}"
      UltraGridColumn194.MaxWidth = 60
      UltraGridColumn194.MinWidth = 60
      Appearance20.TextHAlignAsString = "Right"
      UltraGridColumn195.CellAppearance = Appearance20
      UltraGridColumn195.Format = "N2"
      UltraGridColumn195.Header.Caption = "Total"
      UltraGridColumn195.Header.VisiblePosition = 10
      UltraGridColumn195.MaskInput = "{double:-12.2}"
      UltraGridColumn195.MaxWidth = 60
      UltraGridColumn195.MinWidth = 60
      UltraGridColumn195.Width = 60
      Appearance21.TextHAlignAsString = "Right"
      UltraGridColumn196.CellAppearance = Appearance21
      UltraGridColumn196.Format = "N2"
      UltraGridColumn196.Header.VisiblePosition = 11
      UltraGridColumn196.Hidden = True
      UltraGridColumn196.MaskInput = "{double:-12.2}"
      UltraGridColumn196.MaxWidth = 60
      UltraGridColumn196.MinWidth = 60
      UltraGridColumn196.Width = 60
      UltraGridColumn197.Header.VisiblePosition = 12
      UltraGridColumn197.Hidden = True
      UltraGridColumn197.MaxWidth = 50
      UltraGridColumn198.Header.VisiblePosition = 13
      UltraGridColumn198.Hidden = True
      UltraGridColumn198.Width = 64
      Appearance22.TextHAlignAsString = "Right"
      UltraGridColumn199.CellAppearance = Appearance22
      UltraGridColumn199.Format = "N2"
      UltraGridColumn199.Header.VisiblePosition = 14
      UltraGridColumn199.Hidden = True
      UltraGridColumn199.MaskInput = "{double:-12.2}"
      UltraGridColumn199.MaxWidth = 60
      UltraGridColumn199.MinWidth = 60
      UltraGridColumn199.Width = 60
      UltraGridColumn200.Header.VisiblePosition = 15
      UltraGridColumn200.Hidden = True
      UltraGridColumn201.Header.VisiblePosition = 16
      UltraGridColumn202.Header.VisiblePosition = 17
      UltraGridColumn203.Header.VisiblePosition = 18
      UltraGridColumn204.Header.VisiblePosition = 19
      UltraGridColumn205.Header.VisiblePosition = 20
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn185, UltraGridColumn186, UltraGridColumn187, UltraGridColumn188, UltraGridColumn189, UltraGridColumn190, UltraGridColumn191, UltraGridColumn192, UltraGridColumn193, UltraGridColumn194, UltraGridColumn195, UltraGridColumn196, UltraGridColumn197, UltraGridColumn198, UltraGridColumn199, UltraGridColumn200, UltraGridColumn201, UltraGridColumn202, UltraGridColumn203, UltraGridColumn204, UltraGridColumn205})
      UltraGridColumn206.Header.VisiblePosition = 0
      UltraGridColumn207.Header.VisiblePosition = 1
      UltraGridColumn208.Header.VisiblePosition = 2
      UltraGridColumn209.Header.VisiblePosition = 3
      UltraGridColumn210.Header.VisiblePosition = 4
      UltraGridColumn211.Header.VisiblePosition = 5
      UltraGridColumn212.Header.VisiblePosition = 6
      UltraGridColumn213.Header.VisiblePosition = 7
      UltraGridColumn214.Header.VisiblePosition = 8
      UltraGridColumn215.Header.VisiblePosition = 9
      UltraGridColumn216.Header.VisiblePosition = 10
      UltraGridColumn217.Header.VisiblePosition = 11
      UltraGridColumn218.Header.VisiblePosition = 12
      UltraGridColumn219.Header.VisiblePosition = 13
      UltraGridColumn220.Header.VisiblePosition = 14
      UltraGridColumn221.Header.VisiblePosition = 15
      UltraGridColumn222.Header.VisiblePosition = 16
      UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn206, UltraGridColumn207, UltraGridColumn208, UltraGridColumn209, UltraGridColumn210, UltraGridColumn211, UltraGridColumn212, UltraGridColumn213, UltraGridColumn214, UltraGridColumn215, UltraGridColumn216, UltraGridColumn217, UltraGridColumn218, UltraGridColumn219, UltraGridColumn220, UltraGridColumn221, UltraGridColumn222})
      UltraGridBand3.Hidden = True
      Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
      Me.ugComprobantes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
      Me.ugComprobantes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance23.BorderColor = System.Drawing.SystemColors.Window
      Me.ugComprobantes.DisplayLayout.GroupByBox.Appearance = Appearance23
      Appearance24.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugComprobantes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance24
      Me.ugComprobantes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugComprobantes.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
      Appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance25.BackColor2 = System.Drawing.SystemColors.Control
      Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugComprobantes.DisplayLayout.GroupByBox.PromptAppearance = Appearance25
      Me.ugComprobantes.DisplayLayout.MaxColScrollRegions = 1
      Me.ugComprobantes.DisplayLayout.MaxRowScrollRegions = 1
      Appearance26.BackColor = System.Drawing.SystemColors.Window
      Appearance26.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugComprobantes.DisplayLayout.Override.ActiveCellAppearance = Appearance26
      Appearance27.BackColor = System.Drawing.SystemColors.Highlight
      Appearance27.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugComprobantes.DisplayLayout.Override.ActiveRowAppearance = Appearance27
      Me.ugComprobantes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugComprobantes.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
      Me.ugComprobantes.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
      Me.ugComprobantes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugComprobantes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugComprobantes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugComprobantes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance28.BackColor = System.Drawing.SystemColors.Window
      Me.ugComprobantes.DisplayLayout.Override.CardAreaAppearance = Appearance28
      Appearance29.BorderColor = System.Drawing.Color.Silver
      Appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugComprobantes.DisplayLayout.Override.CellAppearance = Appearance29
      Me.ugComprobantes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.ugComprobantes.DisplayLayout.Override.CellPadding = 0
      Appearance30.BackColor = System.Drawing.SystemColors.Control
      Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance30.BorderColor = System.Drawing.SystemColors.Window
      Me.ugComprobantes.DisplayLayout.Override.GroupByRowAppearance = Appearance30
      Appearance31.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Appearance31.TextHAlignAsString = "Left"
      Me.ugComprobantes.DisplayLayout.Override.HeaderAppearance = Appearance31
      Me.ugComprobantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugComprobantes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance32.BackColor = System.Drawing.SystemColors.Window
      Appearance32.BorderColor = System.Drawing.Color.Silver
      Me.ugComprobantes.DisplayLayout.Override.RowAppearance = Appearance32
      Me.ugComprobantes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
      Me.ugComprobantes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugComprobantes.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
      Me.ugComprobantes.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugComprobantes.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugComprobantes.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
      Me.ugComprobantes.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance33.BackColor = System.Drawing.Color.White
      Appearance33.BackColor2 = System.Drawing.Color.White
      Appearance33.TextVAlignAsString = "Bottom"
      Me.ugComprobantes.DisplayLayout.Override.SummaryFooterAppearance = Appearance33
      Appearance34.BackColor = System.Drawing.Color.Tomato
      Appearance34.BackColor2 = System.Drawing.Color.Silver
      Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Me.ugComprobantes.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance34
      Appearance35.BackColor = System.Drawing.Color.Tomato
      Appearance35.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance35.TextHAlignAsString = "Right"
      Me.ugComprobantes.DisplayLayout.Override.SummaryValueAppearance = Appearance35
      Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugComprobantes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
      Me.ugComprobantes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugComprobantes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugComprobantes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugComprobantes.Location = New System.Drawing.Point(12, 99)
      Me.ugComprobantes.Name = "ugComprobantes"
      Me.ugComprobantes.Size = New System.Drawing.Size(913, 437)
      Me.ugComprobantes.TabIndex = 1
      Me.ugComprobantes.Text = "UltraGrid1"
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
      Appearance37.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance37.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance37
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
      'btnInsertar
      '
      Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnInsertar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnInsertar.Location = New System.Drawing.Point(931, 99)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 2
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'btnEliminar
      '
      Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.btnEliminar.Location = New System.Drawing.Point(931, 142)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 3
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'bscComprobante2
      '
      Me.bscComprobante2.ActivarFiltroEnGrilla = True
      Me.bscComprobante2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscComprobante2.AutoSize = True
      Me.bscComprobante2.BindearPropiedadControl = Nothing
      Me.bscComprobante2.BindearPropiedadEntidad = Nothing
      Me.bscComprobante2.ConfigBuscador = Nothing
      Me.bscComprobante2.Datos = Nothing
      Me.bscComprobante2.FilaDevuelta = Nothing
      Me.bscComprobante2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscComprobante2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscComprobante2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscComprobante2.IsDecimal = False
      Me.bscComprobante2.IsNumber = False
      Me.bscComprobante2.IsPK = False
      Me.bscComprobante2.IsRequired = False
      Me.bscComprobante2.Key = ""
      Me.bscComprobante2.LabelAsoc = Nothing
      Me.bscComprobante2.Location = New System.Drawing.Point(933, 104)
      Me.bscComprobante2.Margin = New System.Windows.Forms.Padding(4)
      Me.bscComprobante2.MaxLengh = "32767"
      Me.bscComprobante2.Name = "bscComprobante2"
      Me.bscComprobante2.Permitido = True
      Me.bscComprobante2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscComprobante2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscComprobante2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscComprobante2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscComprobante2.Selecciono = False
      Me.bscComprobante2.Size = New System.Drawing.Size(32, 23)
      Me.bscComprobante2.TabIndex = 6
      Me.bscComprobante2.Visible = False
      '
      'PedidosBindingSource
      '
      Me.PedidosBindingSource.DataMember = "Pedidos"
      Me.PedidosBindingSource.DataSource = Me.DtsRegistracionPagos
      '
      'DtsRegistracionPagos
      '
      Me.DtsRegistracionPagos.DataSetName = "dtsRegistracionPagos"
      Me.DtsRegistracionPagos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'PedidosProductosBindingSource
      '
      Me.PedidosProductosBindingSource.DataMember = "Productos"
      Me.PedidosProductosBindingSource.DataSource = Me.DtsRegistracionPagos
      '
      'ModificarRepartos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Controls.Add(Me.btnInsertar)
      Me.Controls.Add(Me.btnEliminar)
      Me.Controls.Add(Me.ugComprobantes)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.bscComprobante2)
      Me.KeyPreview = True
      Me.Name = "ModificarRepartos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Modificar Repartos"
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PedidosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DtsRegistracionPagos, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PedidosProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents lblNumeroReparto As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents ugComprobantes As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents DtsRegistracionPagos As Eniac.Win.dtsRegistracionPagos
   Friend WithEvents PedidosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents PedidosProductosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents bscComprobante2 As Eniac.Controles.Buscador2
   Friend WithEvents bscReparto2 As Eniac.Controles.Buscador2
   Friend WithEvents dtpFechaEnvio As Eniac.Controles.DateTimePicker
   Friend WithEvents lblTransportista As Eniac.Controles.Label
   Friend WithEvents lblFechaEnvio As Eniac.Controles.Label
   Friend WithEvents cmbTransportista As Eniac.Controles.ComboBox
   Friend WithEvents chbTransportista As System.Windows.Forms.CheckBox
   Friend WithEvents chbFechaEnvio As System.Windows.Forms.CheckBox
End Class
