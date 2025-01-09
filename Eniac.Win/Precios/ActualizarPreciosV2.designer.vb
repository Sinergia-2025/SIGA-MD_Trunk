<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizarPreciosV2
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActualizarPreciosV2))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
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
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.lblPrecioCostoMonto = New Eniac.Controles.Label()
      Me.txtPrecioCostoMonto = New Eniac.Controles.TextBox()
      Me.chbAjusteA = New Eniac.Controles.CheckBox()
      Me.rdbCostoDesdeFormula = New Eniac.Controles.RadioButton()
      Me.rdbCostoSiMismo = New Eniac.Controles.RadioButton()
      Me.lblPrecioCostoPorc2 = New Eniac.Controles.Label()
      Me.txtPrecioCostoPorc = New Eniac.Controles.TextBox()
      Me.lblListasDePrecios = New Eniac.Controles.Label()
      Me.dgvListasPrecios = New Eniac.Controles.DataGridView()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssProcesoImportacion = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.chbFechaActualizado = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.cboCompuestos = New Eniac.Controles.ComboBox()
      Me.lblCompuestos = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador2()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chbSinVenta = New Eniac.Controles.CheckBox()
      Me.chbSinCosto = New Eniac.Controles.CheckBox()
      Me.chbSubRubro = New Eniac.Controles.CheckBox()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.lblSucursales = New Eniac.Controles.Label()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.clbSucursales = New Eniac.Controles.CheckedListBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportarExcel = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.TbpFiltros = New System.Windows.Forms.TabPage()
      Me.chbConStock = New Eniac.Controles.CheckBox()
      Me.cmbConStock = New Eniac.Controles.ComboBox()
      Me.cmbSubSubRubro = New Eniac.Win.ComboBoxSubSubRubro()
      Me.cmbSubRubro = New Eniac.Win.ComboBoxSubRubro()
      Me.chbSubSubRubro = New Eniac.Controles.CheckBox()
      Me.pnlFiltros = New Eniac.Controles.Panel()
      Me.chbMoneda = New Eniac.Controles.CheckBox()
      Me.cmbMoneda = New Eniac.Controles.ComboBox()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.cmbMarca = New Eniac.Win.ComboBoxMarcas()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.cmbRubro = New Eniac.Win.ComboBoxRubro()
      Me.btnTodosListas = New System.Windows.Forms.Button()
      Me.cmbTodosListas = New Eniac.Controles.ComboBox()
      Me.cmbEsOferta = New Eniac.Controles.ComboBox()
      Me.Label15 = New Eniac.Controles.Label()
      Me.chbProveedorHabitual = New Eniac.Controles.CheckBox()
      Me.dgvSeleccionListaPrecios = New Eniac.Controles.DataGridView()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lblCodigoProductoProveedor = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtCodigoProductoProveedor = New Eniac.Controles.TextBox()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.txtProducto = New Eniac.Controles.TextBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.TbpCalcular = New System.Windows.Forms.TabPage()
      Me.grpRedondeo = New System.Windows.Forms.GroupBox()
      Me.lblEnteroPrecioVentaBaseRedondeo = New Eniac.Controles.Label()
      Me.txtEnteroPrecioVentaBaseRedondeo = New Eniac.Controles.TextBox()
      Me.txtEnteroPrecioVenta = New Eniac.Controles.TextBox()
      Me.radEnteroPrecioVenta = New System.Windows.Forms.RadioButton()
      Me.txtRedondeoPrecioVenta = New Eniac.Controles.TextBox()
      Me.radRedondeoPrecioVenta = New System.Windows.Forms.RadioButton()
      Me.txtAjusteA = New Eniac.Controles.TextBox()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.chbPorcActual = New Eniac.Controles.CheckBox()
      Me.chbSobreVenta = New Eniac.Controles.CheckBox()
      Me.chbSobreCosto = New Eniac.Controles.CheckBox()
      Me.chbDesdeFormula = New Eniac.Controles.CheckBox()
      Me.btnCalcular = New Eniac.Controles.Button()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.rdbCostoFabrica = New Eniac.Controles.RadioButton()
      Me.grbPrecioCompra = New System.Windows.Forms.GroupBox()
      Me.rdbFabricaSiMismo = New Eniac.Controles.RadioButton()
      Me.lblPorcPrecioFabrica = New Eniac.Controles.Label()
      Me.txtPorcenFabrica = New Eniac.Controles.TextBox()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.btnDescuentoRecargoPorc1 = New Eniac.Controles.Button()
      Me.txtDescuentoRecargoPorc1 = New Eniac.Controles.TextBox()
      Me.lblDescuentoRecargoPorc1 = New Eniac.Controles.Label()
      Me.lblDescuentoRecargoPorc2 = New Eniac.Controles.Label()
      Me.txtDescuentoRecargoPorc2 = New Eniac.Controles.TextBox()
      Me.btnDescuentoRecargoPorc2 = New Eniac.Controles.Button()
      Me.lblDescuentoRecargoPorc3 = New Eniac.Controles.Label()
      Me.txtDescuentoRecargoPorc3 = New Eniac.Controles.TextBox()
      Me.btnDescuentoRecargoPorc3 = New Eniac.Controles.Button()
      Me.lblDescuentoRecargoPorc4 = New Eniac.Controles.Label()
      Me.txtDescuentoRecargoPorc4 = New Eniac.Controles.TextBox()
      Me.btnDescuentoRecargoPorc4 = New Eniac.Controles.Button()
      Me.lblDescuentoRecargoPorc5 = New Eniac.Controles.Label()
      Me.txtDescuentoRecargoPorc5 = New Eniac.Controles.TextBox()
      Me.btnDescuentoRecargoPorc5 = New Eniac.Controles.Button()
      Me.lblDescuentoRecargoPorc6 = New Eniac.Controles.Label()
      Me.txtDescuentoRecargoPorc6 = New Eniac.Controles.TextBox()
      Me.btnDescuentoRecargoPorc6 = New Eniac.Controles.Button()
      Me.ugPrecios = New Eniac.Win.UltraGridEditable()
      Me.FilterManager1 = New Eniac.Win.FilterManager.FilterManager(Me.components)
        CType(Me.dgvListasPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.tbcDetalle.SuspendLayout()
        Me.TbpFiltros.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        CType(Me.dgvSeleccionListaPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbpCalcular.SuspendLayout()
        Me.grpRedondeo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbPrecioCompra.SuspendLayout()
        CType(Me.ugPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgIconos
        '
        Me.imgIconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgIconos.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblPrecioCostoMonto
        '
        Me.lblPrecioCostoMonto.AutoSize = True
        Me.lblPrecioCostoMonto.LabelAsoc = Nothing
        Me.lblPrecioCostoMonto.Location = New System.Drawing.Point(106, 20)
        Me.lblPrecioCostoMonto.Name = "lblPrecioCostoMonto"
        Me.lblPrecioCostoMonto.Size = New System.Drawing.Size(13, 13)
        Me.lblPrecioCostoMonto.TabIndex = 2
        Me.lblPrecioCostoMonto.Text = "$"
        '
        'txtPrecioCostoMonto
        '
        Me.txtPrecioCostoMonto.BindearPropiedadControl = Nothing
        Me.txtPrecioCostoMonto.BindearPropiedadEntidad = Nothing
        Me.txtPrecioCostoMonto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioCostoMonto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioCostoMonto.Formato = "##0.00"
        Me.txtPrecioCostoMonto.IsDecimal = True
        Me.txtPrecioCostoMonto.IsNumber = True
        Me.txtPrecioCostoMonto.IsPK = False
        Me.txtPrecioCostoMonto.IsRequired = False
        Me.txtPrecioCostoMonto.Key = ""
        Me.txtPrecioCostoMonto.LabelAsoc = Nothing
        Me.txtPrecioCostoMonto.Location = New System.Drawing.Point(122, 17)
        Me.txtPrecioCostoMonto.Name = "txtPrecioCostoMonto"
        Me.txtPrecioCostoMonto.Size = New System.Drawing.Size(55, 20)
        Me.txtPrecioCostoMonto.TabIndex = 3
        Me.txtPrecioCostoMonto.Text = "0.00"
        Me.txtPrecioCostoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbAjusteA
        '
        Me.chbAjusteA.AutoSize = True
        Me.chbAjusteA.BindearPropiedadControl = Nothing
        Me.chbAjusteA.BindearPropiedadEntidad = Nothing
        Me.chbAjusteA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAjusteA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAjusteA.IsPK = False
        Me.chbAjusteA.IsRequired = False
        Me.chbAjusteA.Key = Nothing
        Me.chbAjusteA.LabelAsoc = Nothing
        Me.chbAjusteA.Location = New System.Drawing.Point(162, 17)
        Me.chbAjusteA.Name = "chbAjusteA"
        Me.chbAjusteA.Size = New System.Drawing.Size(64, 17)
        Me.chbAjusteA.TabIndex = 2
        Me.chbAjusteA.Text = "Ajuste a"
        Me.chbAjusteA.UseVisualStyleBackColor = True
        '
        'rdbCostoDesdeFormula
        '
        Me.rdbCostoDesdeFormula.AutoSize = True
        Me.rdbCostoDesdeFormula.BindearPropiedadControl = Nothing
        Me.rdbCostoDesdeFormula.BindearPropiedadEntidad = Nothing
        Me.rdbCostoDesdeFormula.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbCostoDesdeFormula.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbCostoDesdeFormula.IsPK = False
        Me.rdbCostoDesdeFormula.IsRequired = False
        Me.rdbCostoDesdeFormula.Key = Nothing
        Me.rdbCostoDesdeFormula.LabelAsoc = Nothing
        Me.rdbCostoDesdeFormula.Location = New System.Drawing.Point(190, 38)
        Me.rdbCostoDesdeFormula.Name = "rdbCostoDesdeFormula"
        Me.rdbCostoDesdeFormula.Size = New System.Drawing.Size(96, 17)
        Me.rdbCostoDesdeFormula.TabIndex = 5
        Me.rdbCostoDesdeFormula.TabStop = True
        Me.rdbCostoDesdeFormula.Text = "Desde Formula"
        Me.rdbCostoDesdeFormula.UseVisualStyleBackColor = True
        '
        'rdbCostoSiMismo
        '
        Me.rdbCostoSiMismo.AutoSize = True
        Me.rdbCostoSiMismo.BindearPropiedadControl = Nothing
        Me.rdbCostoSiMismo.BindearPropiedadEntidad = Nothing
        Me.rdbCostoSiMismo.Checked = True
        Me.rdbCostoSiMismo.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbCostoSiMismo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbCostoSiMismo.IsPK = False
        Me.rdbCostoSiMismo.IsRequired = False
        Me.rdbCostoSiMismo.Key = Nothing
        Me.rdbCostoSiMismo.LabelAsoc = Nothing
        Me.rdbCostoSiMismo.Location = New System.Drawing.Point(190, 16)
        Me.rdbCostoSiMismo.Name = "rdbCostoSiMismo"
        Me.rdbCostoSiMismo.Size = New System.Drawing.Size(98, 17)
        Me.rdbCostoSiMismo.TabIndex = 4
        Me.rdbCostoSiMismo.TabStop = True
        Me.rdbCostoSiMismo.Text = "Sobre Si Mismo"
        Me.rdbCostoSiMismo.UseVisualStyleBackColor = True
        '
        'lblPrecioCostoPorc2
        '
        Me.lblPrecioCostoPorc2.AutoSize = True
        Me.lblPrecioCostoPorc2.LabelAsoc = Nothing
        Me.lblPrecioCostoPorc2.Location = New System.Drawing.Point(80, 20)
        Me.lblPrecioCostoPorc2.Name = "lblPrecioCostoPorc2"
        Me.lblPrecioCostoPorc2.Size = New System.Drawing.Size(15, 13)
        Me.lblPrecioCostoPorc2.TabIndex = 1
        Me.lblPrecioCostoPorc2.Text = "%"
        '
        'txtPrecioCostoPorc
        '
        Me.txtPrecioCostoPorc.BindearPropiedadControl = Nothing
        Me.txtPrecioCostoPorc.BindearPropiedadEntidad = Nothing
        Me.txtPrecioCostoPorc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioCostoPorc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioCostoPorc.Formato = "##0.00"
        Me.txtPrecioCostoPorc.IsDecimal = True
        Me.txtPrecioCostoPorc.IsNumber = True
        Me.txtPrecioCostoPorc.IsPK = False
        Me.txtPrecioCostoPorc.IsRequired = False
        Me.txtPrecioCostoPorc.Key = ""
        Me.txtPrecioCostoPorc.LabelAsoc = Nothing
        Me.txtPrecioCostoPorc.Location = New System.Drawing.Point(10, 16)
        Me.txtPrecioCostoPorc.Name = "txtPrecioCostoPorc"
        Me.txtPrecioCostoPorc.Size = New System.Drawing.Size(68, 20)
        Me.txtPrecioCostoPorc.TabIndex = 0
        Me.txtPrecioCostoPorc.Text = "0.00"
        Me.txtPrecioCostoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblListasDePrecios
        '
        Me.lblListasDePrecios.AutoSize = True
        Me.lblListasDePrecios.ForeColor = System.Drawing.Color.Blue
        Me.lblListasDePrecios.LabelAsoc = Nothing
        Me.lblListasDePrecios.Location = New System.Drawing.Point(447, 11)
        Me.lblListasDePrecios.Name = "lblListasDePrecios"
        Me.lblListasDePrecios.Size = New System.Drawing.Size(133, 13)
        Me.lblListasDePrecios.TabIndex = 4
        Me.lblListasDePrecios.Text = "Listas de Precios de Venta"
        '
        'dgvListasPrecios
        '
        Me.dgvListasPrecios.AllowUserToAddRows = False
        Me.dgvListasPrecios.AllowUserToDeleteRows = False
        Me.dgvListasPrecios.AllowUserToResizeColumns = False
        Me.dgvListasPrecios.AllowUserToResizeRows = False
        Me.dgvListasPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListasPrecios.Location = New System.Drawing.Point(450, 48)
        Me.dgvListasPrecios.MultiSelect = False
        Me.dgvListasPrecios.Name = "dgvListasPrecios"
        Me.dgvListasPrecios.RowHeadersVisible = False
        Me.dgvListasPrecios.RowHeadersWidth = 10
        Me.dgvListasPrecios.RowTemplate.Height = 20
        Me.dgvListasPrecios.Size = New System.Drawing.Size(500, 139)
        Me.dgvListasPrecios.TabIndex = 6
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssProcesoImportacion, Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 22
        Me.stsStado.Text = "statusStrip1"
        '
        'tssProcesoImportacion
        '
        Me.tssProcesoImportacion.Name = "tssProcesoImportacion"
        Me.tssProcesoImportacion.Size = New System.Drawing.Size(0, 17)
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'chbFechaActualizado
        '
        Me.chbFechaActualizado.AutoSize = True
        Me.chbFechaActualizado.BindearPropiedadControl = Nothing
        Me.chbFechaActualizado.BindearPropiedadEntidad = Nothing
        Me.chbFechaActualizado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaActualizado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaActualizado.IsPK = False
        Me.chbFechaActualizado.IsRequired = False
        Me.chbFechaActualizado.Key = Nothing
        Me.chbFechaActualizado.LabelAsoc = Nothing
        Me.chbFechaActualizado.Location = New System.Drawing.Point(581, 183)
        Me.chbFechaActualizado.Name = "chbFechaActualizado"
        Me.chbFechaActualizado.Size = New System.Drawing.Size(114, 17)
        Me.chbFechaActualizado.TabIndex = 35
        Me.chbFechaActualizado.Text = "Fecha Actualizado"
        Me.chbFechaActualizado.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(734, 191)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 39
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(691, 195)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 38
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
        Me.dtpDesde.Location = New System.Drawing.Point(734, 165)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 37
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(690, 169)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 36
        Me.lblDesde.Text = "Desde"
        '
        'cboCompuestos
        '
        Me.cboCompuestos.BindearPropiedadControl = Nothing
        Me.cboCompuestos.BindearPropiedadEntidad = Nothing
        Me.cboCompuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompuestos.ForeColorFocus = System.Drawing.Color.Red
        Me.cboCompuestos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboCompuestos.FormattingEnabled = True
        Me.cboCompuestos.IsPK = False
        Me.cboCompuestos.IsRequired = False
        Me.cboCompuestos.Key = Nothing
        Me.cboCompuestos.LabelAsoc = Me.lblCompuestos
        Me.cboCompuestos.Location = New System.Drawing.Point(518, 117)
        Me.cboCompuestos.Name = "cboCompuestos"
        Me.cboCompuestos.Size = New System.Drawing.Size(82, 21)
        Me.cboCompuestos.TabIndex = 18
        '
        'lblCompuestos
        '
        Me.lblCompuestos.AutoSize = True
        Me.lblCompuestos.LabelAsoc = Nothing
        Me.lblCompuestos.Location = New System.Drawing.Point(515, 102)
        Me.lblCompuestos.Name = "lblCompuestos"
        Me.lblCompuestos.Size = New System.Drawing.Size(65, 13)
        Me.lblCompuestos.TabIndex = 17
        Me.lblCompuestos.Text = "Compuestos"
        '
        'bscProveedor
        '
        Me.bscProveedor.ActivarFiltroEnGrilla = True
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ConfigBuscador = Nothing
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
        Me.bscProveedor.Location = New System.Drawing.Point(187, 143)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(257, 23)
        Me.bscProveedor.TabIndex = 25
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
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
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(82, 143)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 24
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
        Me.chbProveedor.Location = New System.Drawing.Point(8, 146)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 23
        Me.chbProveedor.Text = "Pro&veedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'chbSinVenta
        '
        Me.chbSinVenta.AutoSize = True
        Me.chbSinVenta.BindearPropiedadControl = Nothing
        Me.chbSinVenta.BindearPropiedadEntidad = Nothing
        Me.chbSinVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSinVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSinVenta.IsPK = False
        Me.chbSinVenta.IsRequired = False
        Me.chbSinVenta.Key = Nothing
        Me.chbSinVenta.LabelAsoc = Nothing
        Me.chbSinVenta.Location = New System.Drawing.Point(449, 40)
        Me.chbSinVenta.Name = "chbSinVenta"
        Me.chbSinVenta.Size = New System.Drawing.Size(171, 17)
        Me.chbSinVenta.TabIndex = 9
        Me.chbSinVenta.Text = "Productos Sin Precio de Venta"
        Me.chbSinVenta.UseVisualStyleBackColor = True
        '
        'chbSinCosto
        '
        Me.chbSinCosto.AutoSize = True
        Me.chbSinCosto.BindearPropiedadControl = Nothing
        Me.chbSinCosto.BindearPropiedadEntidad = Nothing
        Me.chbSinCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSinCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSinCosto.IsPK = False
        Me.chbSinCosto.IsRequired = False
        Me.chbSinCosto.Key = Nothing
        Me.chbSinCosto.LabelAsoc = Nothing
        Me.chbSinCosto.Location = New System.Drawing.Point(449, 13)
        Me.chbSinCosto.Name = "chbSinCosto"
        Me.chbSinCosto.Size = New System.Drawing.Size(170, 17)
        Me.chbSinCosto.TabIndex = 8
        Me.chbSinCosto.Text = "Productos Sin Precio de Costo"
        Me.chbSinCosto.UseVisualStyleBackColor = True
        '
        'chbSubRubro
        '
        Me.chbSubRubro.AutoSize = True
        Me.chbSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubRubro.IsPK = False
        Me.chbSubRubro.IsRequired = False
        Me.chbSubRubro.Key = Nothing
        Me.chbSubRubro.LabelAsoc = Nothing
        Me.chbSubRubro.Location = New System.Drawing.Point(150, 65)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 6
        Me.chbSubRubro.Text = "SubRubro"
        Me.chbSubRubro.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(863, 166)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(89, 40)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblSucursales
        '
        Me.lblSucursales.AutoSize = True
        Me.lblSucursales.LabelAsoc = Nothing
        Me.lblSucursales.Location = New System.Drawing.Point(1, 4)
        Me.lblSucursales.Name = "lblSucursales"
        Me.lblSucursales.Size = New System.Drawing.Size(59, 13)
        Me.lblSucursales.TabIndex = 0
        Me.lblSucursales.Text = "Sucursales"
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(8, 117)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 14
        Me.chbProducto.Text = "&Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'clbSucursales
        '
        Me.clbSucursales.CheckOnClick = True
        Me.clbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.clbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.clbSucursales.FormattingEnabled = True
        Me.clbSucursales.IsPK = False
        Me.clbSucursales.IsRequired = False
        Me.clbSucursales.Key = Nothing
        Me.clbSucursales.LabelAsoc = Me.lblSucursales
        Me.clbSucursales.Location = New System.Drawing.Point(4, 18)
        Me.clbSucursales.Name = "clbSucursales"
        Me.clbSucursales.Size = New System.Drawing.Size(131, 64)
        Me.clbSucursales.TabIndex = 1
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbGrabar, Me.toolStripSeparator3, Me.tsbImportarExcel, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 23
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
        'tsbGrabar
        '
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImportarExcel
        '
        Me.tsbImportarExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsbImportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportarExcel.Name = "tsbImportarExcel"
        Me.tsbImportarExcel.Size = New System.Drawing.Size(122, 26)
        Me.tsbImportarExcel.Text = "Obtener de &Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'tbcDetalle
        '
        Me.tbcDetalle.Controls.Add(Me.TbpFiltros)
        Me.tbcDetalle.Controls.Add(Me.TbpCalcular)
        Me.tbcDetalle.ItemSize = New System.Drawing.Size(42, 20)
        Me.tbcDetalle.Location = New System.Drawing.Point(11, 32)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(964, 241)
        Me.tbcDetalle.TabIndex = 0
        '
        'TbpFiltros
        '
        Me.TbpFiltros.BackColor = System.Drawing.SystemColors.Control
        Me.TbpFiltros.Controls.Add(Me.chbConStock)
        Me.TbpFiltros.Controls.Add(Me.cmbConStock)
        Me.TbpFiltros.Controls.Add(Me.cmbSubSubRubro)
        Me.TbpFiltros.Controls.Add(Me.cmbSubRubro)
        Me.TbpFiltros.Controls.Add(Me.chbSubSubRubro)
        Me.TbpFiltros.Controls.Add(Me.pnlFiltros)
        Me.TbpFiltros.Controls.Add(Me.chbMoneda)
        Me.TbpFiltros.Controls.Add(Me.cmbMoneda)
        Me.TbpFiltros.Controls.Add(Me.lblMarca)
        Me.TbpFiltros.Controls.Add(Me.cmbMarca)
        Me.TbpFiltros.Controls.Add(Me.lblRubro)
        Me.TbpFiltros.Controls.Add(Me.cmbRubro)
        Me.TbpFiltros.Controls.Add(Me.btnTodosListas)
        Me.TbpFiltros.Controls.Add(Me.cmbTodosListas)
        Me.TbpFiltros.Controls.Add(Me.cmbEsOferta)
        Me.TbpFiltros.Controls.Add(Me.Label15)
        Me.TbpFiltros.Controls.Add(Me.chbProveedorHabitual)
        Me.TbpFiltros.Controls.Add(Me.dgvSeleccionListaPrecios)
        Me.TbpFiltros.Controls.Add(Me.Label1)
        Me.TbpFiltros.Controls.Add(Me.lblCodigoProductoProveedor)
        Me.TbpFiltros.Controls.Add(Me.lblCodigo)
        Me.TbpFiltros.Controls.Add(Me.txtCodigoProductoProveedor)
        Me.TbpFiltros.Controls.Add(Me.txtCodigo)
        Me.TbpFiltros.Controls.Add(Me.lblProducto)
        Me.TbpFiltros.Controls.Add(Me.txtProducto)
        Me.TbpFiltros.Controls.Add(Me.bscProducto2)
        Me.TbpFiltros.Controls.Add(Me.bscCodigoProducto2)
        Me.TbpFiltros.Controls.Add(Me.chbFechaActualizado)
        Me.TbpFiltros.Controls.Add(Me.chbSinCosto)
        Me.TbpFiltros.Controls.Add(Me.dtpHasta)
        Me.TbpFiltros.Controls.Add(Me.chbProducto)
        Me.TbpFiltros.Controls.Add(Me.dtpDesde)
        Me.TbpFiltros.Controls.Add(Me.cboCompuestos)
        Me.TbpFiltros.Controls.Add(Me.lblHasta)
        Me.TbpFiltros.Controls.Add(Me.lblCompuestos)
        Me.TbpFiltros.Controls.Add(Me.lblDesde)
        Me.TbpFiltros.Controls.Add(Me.btnBuscar)
        Me.TbpFiltros.Controls.Add(Me.bscProveedor)
        Me.TbpFiltros.Controls.Add(Me.chbSubRubro)
        Me.TbpFiltros.Controls.Add(Me.bscCodigoProveedor)
        Me.TbpFiltros.Controls.Add(Me.chbSinVenta)
        Me.TbpFiltros.Controls.Add(Me.chbProveedor)
        Me.TbpFiltros.Location = New System.Drawing.Point(4, 24)
        Me.TbpFiltros.Name = "TbpFiltros"
        Me.TbpFiltros.Padding = New System.Windows.Forms.Padding(3)
        Me.TbpFiltros.Size = New System.Drawing.Size(956, 213)
        Me.TbpFiltros.TabIndex = 0
        Me.TbpFiltros.Text = "Filtros (F11)"
        '
        'chbConStock
        '
        Me.chbConStock.AutoSize = True
        Me.chbConStock.BindearPropiedadControl = Nothing
        Me.chbConStock.BindearPropiedadEntidad = Nothing
        Me.chbConStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConStock.IsPK = False
        Me.chbConStock.IsRequired = False
        Me.chbConStock.Key = Nothing
        Me.chbConStock.LabelAsoc = Nothing
        Me.chbConStock.Location = New System.Drawing.Point(524, 147)
        Me.chbConStock.Name = "chbConStock"
        Me.chbConStock.Size = New System.Drawing.Size(76, 17)
        Me.chbConStock.TabIndex = 40
        Me.chbConStock.Text = "Con Stock"
        Me.chbConStock.UseVisualStyleBackColor = True
        '
        'cmbConStock
        '
        Me.cmbConStock.BindearPropiedadControl = Nothing
        Me.cmbConStock.BindearPropiedadEntidad = Nothing
        Me.cmbConStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConStock.Enabled = False
        Me.cmbConStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConStock.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbConStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbConStock.FormattingEnabled = True
        Me.cmbConStock.IsPK = False
        Me.cmbConStock.IsRequired = False
        Me.cmbConStock.Key = Nothing
        Me.cmbConStock.LabelAsoc = Nothing
        Me.cmbConStock.Location = New System.Drawing.Point(606, 145)
        Me.cmbConStock.Name = "cmbConStock"
        Me.cmbConStock.Size = New System.Drawing.Size(83, 21)
        Me.cmbConStock.TabIndex = 41
        '
        'cmbSubSubRubro
        '
        Me.cmbSubSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubSubRubro.ConcatenarNombreSubRubro = False
        Me.cmbSubSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubSubRubro.Enabled = False
        Me.cmbSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubSubRubro.FormattingEnabled = True
        Me.cmbSubSubRubro.IsPK = False
        Me.cmbSubSubRubro.IsRequired = False
        Me.cmbSubSubRubro.Key = Nothing
        Me.cmbSubSubRubro.LabelAsoc = Nothing
        Me.cmbSubSubRubro.Location = New System.Drawing.Point(541, 63)
        Me.cmbSubSubRubro.Name = "cmbSubSubRubro"
        Me.cmbSubSubRubro.Size = New System.Drawing.Size(147, 21)
        Me.cmbSubSubRubro.TabIndex = 11
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro.ConcatenarNombreRubro = False
        Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro.Enabled = False
        Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro.FormattingEnabled = True
        Me.cmbSubRubro.IsPK = False
        Me.cmbSubRubro.IsRequired = False
        Me.cmbSubRubro.Key = Nothing
        Me.cmbSubRubro.LabelAsoc = Nothing
        Me.cmbSubRubro.Location = New System.Drawing.Point(222, 63)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(213, 21)
        Me.cmbSubRubro.TabIndex = 7
        '
        'chbSubSubRubro
        '
        Me.chbSubSubRubro.AutoSize = True
        Me.chbSubSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubSubRubro.Enabled = False
        Me.chbSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubSubRubro.IsPK = False
        Me.chbSubSubRubro.IsRequired = False
        Me.chbSubSubRubro.Key = Nothing
        Me.chbSubSubRubro.LabelAsoc = Nothing
        Me.chbSubSubRubro.Location = New System.Drawing.Point(449, 65)
        Me.chbSubSubRubro.Name = "chbSubSubRubro"
        Me.chbSubSubRubro.Size = New System.Drawing.Size(93, 17)
        Me.chbSubSubRubro.TabIndex = 10
        Me.chbSubSubRubro.Text = "SubSubRubro"
        Me.chbSubSubRubro.UseVisualStyleBackColor = True
        Me.chbSubSubRubro.Visible = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Controls.Add(Me.clbSucursales)
        Me.pnlFiltros.Controls.Add(Me.lblSucursales)
        Me.pnlFiltros.Location = New System.Drawing.Point(8, 6)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(136, 85)
        Me.pnlFiltros.TabIndex = 1
        '
        'chbMoneda
        '
        Me.chbMoneda.AutoSize = True
        Me.chbMoneda.BindearPropiedadControl = Nothing
        Me.chbMoneda.BindearPropiedadEntidad = Nothing
        Me.chbMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMoneda.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMoneda.IsPK = False
        Me.chbMoneda.IsRequired = False
        Me.chbMoneda.Key = Nothing
        Me.chbMoneda.LabelAsoc = Nothing
        Me.chbMoneda.Location = New System.Drawing.Point(427, 188)
        Me.chbMoneda.Name = "chbMoneda"
        Me.chbMoneda.Size = New System.Drawing.Size(65, 17)
        Me.chbMoneda.TabIndex = 33
        Me.chbMoneda.Text = "Moneda"
        Me.chbMoneda.UseVisualStyleBackColor = True
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BindearPropiedadControl = Nothing
        Me.cmbMoneda.BindearPropiedadEntidad = Nothing
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.Enabled = False
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.IsPK = False
        Me.cmbMoneda.IsRequired = False
        Me.cmbMoneda.Key = Nothing
        Me.cmbMoneda.LabelAsoc = Nothing
        Me.cmbMoneda.Location = New System.Drawing.Point(492, 186)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(83, 21)
        Me.cmbMoneda.TabIndex = 34
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.LabelAsoc = Nothing
        Me.lblMarca.Location = New System.Drawing.Point(164, 13)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 2
        Me.lblMarca.Text = "Marca"
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = False
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Me.lblMarca
        Me.cmbMarca.Location = New System.Drawing.Point(222, 10)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(213, 21)
        Me.cmbMarca.TabIndex = 3
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(165, 40)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 4
        Me.lblRubro.Text = "Rubro"
        '
        'cmbRubro
        '
        Me.cmbRubro.BindearPropiedadControl = Nothing
        Me.cmbRubro.BindearPropiedadEntidad = Nothing
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.IsPK = False
        Me.cmbRubro.IsRequired = False
        Me.cmbRubro.Key = Nothing
        Me.cmbRubro.LabelAsoc = Me.lblRubro
        Me.cmbRubro.Location = New System.Drawing.Point(222, 37)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(213, 21)
        Me.cmbRubro.TabIndex = 5
        '
        'btnTodosListas
        '
        Me.btnTodosListas.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodosListas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodosListas.Location = New System.Drawing.Point(816, 116)
        Me.btnTodosListas.Name = "btnTodosListas"
        Me.btnTodosListas.Size = New System.Drawing.Size(75, 23)
        Me.btnTodosListas.TabIndex = 22
        Me.btnTodosListas.Text = "Aplicar"
        Me.btnTodosListas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodosListas.UseVisualStyleBackColor = True
        '
        'cmbTodosListas
        '
        Me.cmbTodosListas.BindearPropiedadControl = Nothing
        Me.cmbTodosListas.BindearPropiedadEntidad = Nothing
        Me.cmbTodosListas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodosListas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodosListas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodosListas.FormattingEnabled = True
        Me.cmbTodosListas.IsPK = False
        Me.cmbTodosListas.IsRequired = False
        Me.cmbTodosListas.Key = Nothing
        Me.cmbTodosListas.LabelAsoc = Nothing
        Me.cmbTodosListas.Location = New System.Drawing.Point(694, 117)
        Me.cmbTodosListas.Name = "cmbTodosListas"
        Me.cmbTodosListas.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodosListas.TabIndex = 21
        '
        'cmbEsOferta
        '
        Me.cmbEsOferta.BindearPropiedadControl = ""
        Me.cmbEsOferta.BindearPropiedadEntidad = ""
        Me.cmbEsOferta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsOferta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsOferta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsOferta.FormattingEnabled = True
        Me.cmbEsOferta.IsPK = False
        Me.cmbEsOferta.IsRequired = False
        Me.cmbEsOferta.Items.AddRange(New Object() {"TODOS", "NO", "SI"})
        Me.cmbEsOferta.Key = Nothing
        Me.cmbEsOferta.LabelAsoc = Nothing
        Me.cmbEsOferta.Location = New System.Drawing.Point(606, 117)
        Me.cmbEsOferta.Name = "cmbEsOferta"
        Me.cmbEsOferta.Size = New System.Drawing.Size(82, 21)
        Me.cmbEsOferta.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.LabelAsoc = Nothing
        Me.Label15.Location = New System.Drawing.Point(603, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Es Oferta"
        '
        'chbProveedorHabitual
        '
        Me.chbProveedorHabitual.AutoSize = True
        Me.chbProveedorHabitual.BindearPropiedadControl = Nothing
        Me.chbProveedorHabitual.BindearPropiedadEntidad = Nothing
        Me.chbProveedorHabitual.Enabled = False
        Me.chbProveedorHabitual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedorHabitual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedorHabitual.IsPK = False
        Me.chbProveedorHabitual.IsRequired = False
        Me.chbProveedorHabitual.Key = Nothing
        Me.chbProveedorHabitual.LabelAsoc = Nothing
        Me.chbProveedorHabitual.Location = New System.Drawing.Point(451, 146)
        Me.chbProveedorHabitual.Name = "chbProveedorHabitual"
        Me.chbProveedorHabitual.Size = New System.Drawing.Size(65, 17)
        Me.chbProveedorHabitual.TabIndex = 26
        Me.chbProveedorHabitual.Text = "Habitual"
        Me.chbProveedorHabitual.UseVisualStyleBackColor = True
        '
        'dgvSeleccionListaPrecios
        '
        Me.dgvSeleccionListaPrecios.AllowUserToAddRows = False
        Me.dgvSeleccionListaPrecios.AllowUserToDeleteRows = False
        Me.dgvSeleccionListaPrecios.AllowUserToResizeColumns = False
        Me.dgvSeleccionListaPrecios.AllowUserToResizeRows = False
        Me.dgvSeleccionListaPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionListaPrecios.Location = New System.Drawing.Point(694, 17)
        Me.dgvSeleccionListaPrecios.MultiSelect = False
        Me.dgvSeleccionListaPrecios.Name = "dgvSeleccionListaPrecios"
        Me.dgvSeleccionListaPrecios.RowHeadersVisible = False
        Me.dgvSeleccionListaPrecios.RowHeadersWidth = 10
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSeleccionListaPrecios.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSeleccionListaPrecios.RowTemplate.Height = 20
        Me.dgvSeleccionListaPrecios.Size = New System.Drawing.Size(256, 98)
        Me.dgvSeleccionListaPrecios.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(691, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Listas de Precios de Venta "
        '
        'lblCodigoProductoProveedor
        '
        Me.lblCodigoProductoProveedor.AutoSize = True
        Me.lblCodigoProductoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProductoProveedor.Location = New System.Drawing.Point(310, 171)
        Me.lblCodigoProductoProveedor.Name = "lblCodigoProductoProveedor"
        Me.lblCodigoProductoProveedor.Size = New System.Drawing.Size(109, 13)
        Me.lblCodigoProductoProveedor.TabIndex = 31
        Me.lblCodigoProductoProveedor.Text = "Código del Proveedor"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(5, 171)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 27
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigoProductoProveedor
        '
        Me.txtCodigoProductoProveedor.BindearPropiedadControl = Nothing
        Me.txtCodigoProductoProveedor.BindearPropiedadEntidad = Nothing
        Me.txtCodigoProductoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoProductoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoProductoProveedor.Formato = ""
        Me.txtCodigoProductoProveedor.IsDecimal = False
        Me.txtCodigoProductoProveedor.IsNumber = False
        Me.txtCodigoProductoProveedor.IsPK = False
        Me.txtCodigoProductoProveedor.IsRequired = False
        Me.txtCodigoProductoProveedor.Key = ""
        Me.txtCodigoProductoProveedor.LabelAsoc = Me.lblCodigoProductoProveedor
        Me.txtCodigoProductoProveedor.Location = New System.Drawing.Point(313, 187)
        Me.txtCodigoProductoProveedor.MaxLength = 15
        Me.txtCodigoProductoProveedor.Name = "txtCodigoProductoProveedor"
        Me.txtCodigoProductoProveedor.Size = New System.Drawing.Size(111, 20)
        Me.txtCodigoProductoProveedor.TabIndex = 32
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = Nothing
        Me.txtCodigo.BindearPropiedadEntidad = Nothing
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = False
        Me.txtCodigo.IsPK = False
        Me.txtCodigo.IsRequired = False
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(8, 187)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(74, 20)
        Me.txtCodigo.TabIndex = 28
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(80, 171)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 29
        Me.lblProducto.Text = "Producto"
        '
        'txtProducto
        '
        Me.txtProducto.BindearPropiedadControl = Nothing
        Me.txtProducto.BindearPropiedadEntidad = Nothing
        Me.txtProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProducto.Formato = ""
        Me.txtProducto.IsDecimal = False
        Me.txtProducto.IsNumber = False
        Me.txtProducto.IsPK = False
        Me.txtProducto.IsRequired = False
        Me.txtProducto.Key = ""
        Me.txtProducto.LabelAsoc = Me.lblProducto
        Me.txtProducto.Location = New System.Drawing.Point(83, 187)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(229, 20)
        Me.txtProducto.TabIndex = 30
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.Enabled = False
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(242, 117)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(275, 20)
        Me.bscProducto2.TabIndex = 16
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.Enabled = False
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(81, 116)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto2.TabIndex = 15
        '
        'TbpCalcular
        '
        Me.TbpCalcular.BackColor = System.Drawing.SystemColors.Control
        Me.TbpCalcular.Controls.Add(Me.grpRedondeo)
        Me.TbpCalcular.Controls.Add(Me.TableLayoutPanel1)
        Me.TbpCalcular.Controls.Add(Me.btnCalcular)
        Me.TbpCalcular.Controls.Add(Me.GroupBox1)
        Me.TbpCalcular.Controls.Add(Me.grbPrecioCompra)
        Me.TbpCalcular.Controls.Add(Me.dgvListasPrecios)
        Me.TbpCalcular.Controls.Add(Me.lblListasDePrecios)
        Me.TbpCalcular.Location = New System.Drawing.Point(4, 24)
        Me.TbpCalcular.Name = "TbpCalcular"
        Me.TbpCalcular.Padding = New System.Windows.Forms.Padding(3)
        Me.TbpCalcular.Size = New System.Drawing.Size(956, 213)
        Me.TbpCalcular.TabIndex = 1
        Me.TbpCalcular.Text = "Calculos (F12)"
        '
        'grpRedondeo
        '
        Me.grpRedondeo.Controls.Add(Me.lblEnteroPrecioVentaBaseRedondeo)
        Me.grpRedondeo.Controls.Add(Me.txtEnteroPrecioVentaBaseRedondeo)
        Me.grpRedondeo.Controls.Add(Me.txtEnteroPrecioVenta)
        Me.grpRedondeo.Controls.Add(Me.radEnteroPrecioVenta)
        Me.grpRedondeo.Controls.Add(Me.txtRedondeoPrecioVenta)
        Me.grpRedondeo.Controls.Add(Me.chbAjusteA)
        Me.grpRedondeo.Controls.Add(Me.radRedondeoPrecioVenta)
        Me.grpRedondeo.Controls.Add(Me.txtAjusteA)
        Me.grpRedondeo.Location = New System.Drawing.Point(6, 143)
        Me.grpRedondeo.Name = "grpRedondeo"
        Me.grpRedondeo.Size = New System.Drawing.Size(292, 64)
        Me.grpRedondeo.TabIndex = 3
        Me.grpRedondeo.TabStop = False
        Me.grpRedondeo.Text = "Redondeo"
        '
        'lblEnteroPrecioVentaBaseRedondeo
        '
        Me.lblEnteroPrecioVentaBaseRedondeo.AutoSize = True
        Me.lblEnteroPrecioVentaBaseRedondeo.LabelAsoc = Nothing
        Me.lblEnteroPrecioVentaBaseRedondeo.Location = New System.Drawing.Point(159, 45)
        Me.lblEnteroPrecioVentaBaseRedondeo.Name = "lblEnteroPrecioVentaBaseRedondeo"
        Me.lblEnteroPrecioVentaBaseRedondeo.Size = New System.Drawing.Size(79, 13)
        Me.lblEnteroPrecioVentaBaseRedondeo.TabIndex = 6
        Me.lblEnteroPrecioVentaBaseRedondeo.Text = "Base redondeo"
        '
        'txtEnteroPrecioVentaBaseRedondeo
        '
        Me.txtEnteroPrecioVentaBaseRedondeo.BindearPropiedadControl = Nothing
        Me.txtEnteroPrecioVentaBaseRedondeo.BindearPropiedadEntidad = Nothing
        Me.txtEnteroPrecioVentaBaseRedondeo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEnteroPrecioVentaBaseRedondeo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEnteroPrecioVentaBaseRedondeo.Formato = "0"
        Me.txtEnteroPrecioVentaBaseRedondeo.IsDecimal = False
        Me.txtEnteroPrecioVentaBaseRedondeo.IsNumber = True
        Me.txtEnteroPrecioVentaBaseRedondeo.IsPK = False
        Me.txtEnteroPrecioVentaBaseRedondeo.IsRequired = False
        Me.txtEnteroPrecioVentaBaseRedondeo.Key = ""
        Me.txtEnteroPrecioVentaBaseRedondeo.LabelAsoc = Nothing
        Me.txtEnteroPrecioVentaBaseRedondeo.Location = New System.Drawing.Point(244, 40)
        Me.txtEnteroPrecioVentaBaseRedondeo.MaxLength = 5
        Me.txtEnteroPrecioVentaBaseRedondeo.Name = "txtEnteroPrecioVentaBaseRedondeo"
        Me.txtEnteroPrecioVentaBaseRedondeo.Size = New System.Drawing.Size(31, 20)
        Me.txtEnteroPrecioVentaBaseRedondeo.TabIndex = 7
        Me.txtEnteroPrecioVentaBaseRedondeo.Text = "10"
        Me.txtEnteroPrecioVentaBaseRedondeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEnteroPrecioVenta
        '
        Me.txtEnteroPrecioVenta.BindearPropiedadControl = Nothing
        Me.txtEnteroPrecioVenta.BindearPropiedadEntidad = Nothing
        Me.txtEnteroPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEnteroPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEnteroPrecioVenta.Formato = "0"
        Me.txtEnteroPrecioVenta.IsDecimal = False
        Me.txtEnteroPrecioVenta.IsNumber = True
        Me.txtEnteroPrecioVenta.IsPK = False
        Me.txtEnteroPrecioVenta.IsRequired = False
        Me.txtEnteroPrecioVenta.Key = ""
        Me.txtEnteroPrecioVenta.LabelAsoc = Nothing
        Me.txtEnteroPrecioVenta.Location = New System.Drawing.Point(98, 41)
        Me.txtEnteroPrecioVenta.MaxLength = 5
        Me.txtEnteroPrecioVenta.Name = "txtEnteroPrecioVenta"
        Me.txtEnteroPrecioVenta.Size = New System.Drawing.Size(31, 20)
        Me.txtEnteroPrecioVenta.TabIndex = 5
        Me.txtEnteroPrecioVenta.Text = "1"
        Me.txtEnteroPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'radEnteroPrecioVenta
        '
        Me.radEnteroPrecioVenta.AutoSize = True
        Me.radEnteroPrecioVenta.Location = New System.Drawing.Point(20, 43)
        Me.radEnteroPrecioVenta.Name = "radEnteroPrecioVenta"
        Me.radEnteroPrecioVenta.Size = New System.Drawing.Size(61, 17)
        Me.radEnteroPrecioVenta.TabIndex = 4
        Me.radEnteroPrecioVenta.Text = "Enteros"
        Me.radEnteroPrecioVenta.UseVisualStyleBackColor = True
        '
        'txtRedondeoPrecioVenta
        '
        Me.txtRedondeoPrecioVenta.BindearPropiedadControl = Nothing
        Me.txtRedondeoPrecioVenta.BindearPropiedadEntidad = Nothing
        Me.txtRedondeoPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRedondeoPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRedondeoPrecioVenta.Formato = "0"
        Me.txtRedondeoPrecioVenta.IsDecimal = False
        Me.txtRedondeoPrecioVenta.IsNumber = True
        Me.txtRedondeoPrecioVenta.IsPK = False
        Me.txtRedondeoPrecioVenta.IsRequired = False
        Me.txtRedondeoPrecioVenta.Key = ""
        Me.txtRedondeoPrecioVenta.LabelAsoc = Nothing
        Me.txtRedondeoPrecioVenta.Location = New System.Drawing.Point(98, 15)
        Me.txtRedondeoPrecioVenta.MaxLength = 5
        Me.txtRedondeoPrecioVenta.Name = "txtRedondeoPrecioVenta"
        Me.txtRedondeoPrecioVenta.Size = New System.Drawing.Size(31, 20)
        Me.txtRedondeoPrecioVenta.TabIndex = 1
        Me.txtRedondeoPrecioVenta.Text = "2"
        Me.txtRedondeoPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'radRedondeoPrecioVenta
        '
        Me.radRedondeoPrecioVenta.AutoSize = True
        Me.radRedondeoPrecioVenta.Checked = True
        Me.radRedondeoPrecioVenta.Location = New System.Drawing.Point(20, 17)
        Me.radRedondeoPrecioVenta.Name = "radRedondeoPrecioVenta"
        Me.radRedondeoPrecioVenta.Size = New System.Drawing.Size(74, 17)
        Me.radRedondeoPrecioVenta.TabIndex = 0
        Me.radRedondeoPrecioVenta.TabStop = True
        Me.radRedondeoPrecioVenta.Text = "Decimales"
        '
        'txtAjusteA
        '
        Me.txtAjusteA.BindearPropiedadControl = Nothing
        Me.txtAjusteA.BindearPropiedadEntidad = Nothing
        Me.txtAjusteA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAjusteA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAjusteA.Formato = "0"
        Me.txtAjusteA.IsDecimal = False
        Me.txtAjusteA.IsNumber = True
        Me.txtAjusteA.IsPK = False
        Me.txtAjusteA.IsRequired = False
        Me.txtAjusteA.Key = ""
        Me.txtAjusteA.LabelAsoc = Nothing
        Me.txtAjusteA.Location = New System.Drawing.Point(244, 15)
        Me.txtAjusteA.MaxLength = 5
        Me.txtAjusteA.Name = "txtAjusteA"
        Me.txtAjusteA.Size = New System.Drawing.Size(31, 20)
        Me.txtAjusteA.TabIndex = 3
        Me.txtAjusteA.Text = "9"
        Me.txtAjusteA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.chbPorcActual, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbSobreVenta, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbSobreCosto, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbDesdeFormula, 4, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(450, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(500, 24)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'chbPorcActual
        '
        Me.chbPorcActual.BindearPropiedadControl = Nothing
        Me.chbPorcActual.BindearPropiedadEntidad = Nothing
        Me.chbPorcActual.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbPorcActual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorcActual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorcActual.IsPK = False
        Me.chbPorcActual.IsRequired = False
        Me.chbPorcActual.Key = Nothing
        Me.chbPorcActual.LabelAsoc = Nothing
        Me.chbPorcActual.Location = New System.Drawing.Point(303, 3)
        Me.chbPorcActual.Name = "chbPorcActual"
        Me.chbPorcActual.Size = New System.Drawing.Size(44, 18)
        Me.chbPorcActual.TabIndex = 0
        Me.chbPorcActual.UseVisualStyleBackColor = True
        '
        'chbSobreVenta
        '
        Me.chbSobreVenta.BindearPropiedadControl = Nothing
        Me.chbSobreVenta.BindearPropiedadEntidad = Nothing
        Me.chbSobreVenta.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbSobreVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSobreVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSobreVenta.IsPK = False
        Me.chbSobreVenta.IsRequired = False
        Me.chbSobreVenta.Key = Nothing
        Me.chbSobreVenta.LabelAsoc = Nothing
        Me.chbSobreVenta.Location = New System.Drawing.Point(353, 3)
        Me.chbSobreVenta.Name = "chbSobreVenta"
        Me.chbSobreVenta.Size = New System.Drawing.Size(44, 18)
        Me.chbSobreVenta.TabIndex = 1
        Me.chbSobreVenta.UseVisualStyleBackColor = True
        '
        'chbSobreCosto
        '
        Me.chbSobreCosto.BindearPropiedadControl = Nothing
        Me.chbSobreCosto.BindearPropiedadEntidad = Nothing
        Me.chbSobreCosto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbSobreCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSobreCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSobreCosto.IsPK = False
        Me.chbSobreCosto.IsRequired = False
        Me.chbSobreCosto.Key = Nothing
        Me.chbSobreCosto.LabelAsoc = Nothing
        Me.chbSobreCosto.Location = New System.Drawing.Point(403, 3)
        Me.chbSobreCosto.Name = "chbSobreCosto"
        Me.chbSobreCosto.Size = New System.Drawing.Size(44, 18)
        Me.chbSobreCosto.TabIndex = 2
        Me.chbSobreCosto.UseVisualStyleBackColor = True
        '
        'chbDesdeFormula
        '
        Me.chbDesdeFormula.BindearPropiedadControl = Nothing
        Me.chbDesdeFormula.BindearPropiedadEntidad = Nothing
        Me.chbDesdeFormula.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbDesdeFormula.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDesdeFormula.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDesdeFormula.IsPK = False
        Me.chbDesdeFormula.IsRequired = False
        Me.chbDesdeFormula.Key = Nothing
        Me.chbDesdeFormula.LabelAsoc = Nothing
        Me.chbDesdeFormula.Location = New System.Drawing.Point(453, 3)
        Me.chbDesdeFormula.Name = "chbDesdeFormula"
        Me.chbDesdeFormula.Size = New System.Drawing.Size(44, 18)
        Me.chbDesdeFormula.TabIndex = 3
        Me.chbDesdeFormula.UseVisualStyleBackColor = True
        '
        'btnCalcular
        '
        Me.btnCalcular.Image = Global.Eniac.Win.My.Resources.Resources.calculator
        Me.btnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalcular.Location = New System.Drawing.Point(341, 30)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(103, 40)
        Me.btnCalcular.TabIndex = 0
        Me.btnCalcular.Text = "Ca&lcular (F8)"
        Me.btnCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbCostoFabrica)
        Me.GroupBox1.Controls.Add(Me.rdbCostoDesdeFormula)
        Me.GroupBox1.Controls.Add(Me.txtPrecioCostoPorc)
        Me.GroupBox1.Controls.Add(Me.lblPrecioCostoMonto)
        Me.GroupBox1.Controls.Add(Me.lblPrecioCostoPorc2)
        Me.GroupBox1.Controls.Add(Me.txtPrecioCostoMonto)
        Me.GroupBox1.Controls.Add(Me.rdbCostoSiMismo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 84)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Precio Costo"
        '
        'rdbCostoFabrica
        '
        Me.rdbCostoFabrica.AutoSize = True
        Me.rdbCostoFabrica.BindearPropiedadControl = Nothing
        Me.rdbCostoFabrica.BindearPropiedadEntidad = Nothing
        Me.rdbCostoFabrica.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbCostoFabrica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbCostoFabrica.IsPK = False
        Me.rdbCostoFabrica.IsRequired = False
        Me.rdbCostoFabrica.Key = Nothing
        Me.rdbCostoFabrica.LabelAsoc = Nothing
        Me.rdbCostoFabrica.Location = New System.Drawing.Point(190, 61)
        Me.rdbCostoFabrica.Name = "rdbCostoFabrica"
        Me.rdbCostoFabrica.Size = New System.Drawing.Size(92, 17)
        Me.rdbCostoFabrica.TabIndex = 6
        Me.rdbCostoFabrica.TabStop = True
        Me.rdbCostoFabrica.Text = "Sobre Compra"
        Me.rdbCostoFabrica.UseVisualStyleBackColor = True
        '
        'grbPrecioCompra
        '
        Me.grbPrecioCompra.Controls.Add(Me.rdbFabricaSiMismo)
        Me.grbPrecioCompra.Controls.Add(Me.lblPorcPrecioFabrica)
        Me.grbPrecioCompra.Controls.Add(Me.txtPorcenFabrica)
        Me.grbPrecioCompra.Location = New System.Drawing.Point(6, 98)
        Me.grbPrecioCompra.Name = "grbPrecioCompra"
        Me.grbPrecioCompra.Size = New System.Drawing.Size(292, 43)
        Me.grbPrecioCompra.TabIndex = 2
        Me.grbPrecioCompra.TabStop = False
        Me.grbPrecioCompra.Text = "Precio Compra"
        '
        'rdbFabricaSiMismo
        '
        Me.rdbFabricaSiMismo.AutoSize = True
        Me.rdbFabricaSiMismo.BindearPropiedadControl = Nothing
        Me.rdbFabricaSiMismo.BindearPropiedadEntidad = Nothing
        Me.rdbFabricaSiMismo.Checked = True
        Me.rdbFabricaSiMismo.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbFabricaSiMismo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbFabricaSiMismo.IsPK = False
        Me.rdbFabricaSiMismo.IsRequired = False
        Me.rdbFabricaSiMismo.Key = Nothing
        Me.rdbFabricaSiMismo.LabelAsoc = Nothing
        Me.rdbFabricaSiMismo.Location = New System.Drawing.Point(98, 19)
        Me.rdbFabricaSiMismo.Name = "rdbFabricaSiMismo"
        Me.rdbFabricaSiMismo.Size = New System.Drawing.Size(96, 17)
        Me.rdbFabricaSiMismo.TabIndex = 2
        Me.rdbFabricaSiMismo.TabStop = True
        Me.rdbFabricaSiMismo.Text = "sobre Si Mismo"
        Me.rdbFabricaSiMismo.UseVisualStyleBackColor = True
        '
        'lblPorcPrecioFabrica
        '
        Me.lblPorcPrecioFabrica.AutoSize = True
        Me.lblPorcPrecioFabrica.LabelAsoc = Nothing
        Me.lblPorcPrecioFabrica.Location = New System.Drawing.Point(80, 22)
        Me.lblPorcPrecioFabrica.Name = "lblPorcPrecioFabrica"
        Me.lblPorcPrecioFabrica.Size = New System.Drawing.Size(15, 13)
        Me.lblPorcPrecioFabrica.TabIndex = 1
        Me.lblPorcPrecioFabrica.Text = "%"
        '
        'txtPorcenFabrica
        '
        Me.txtPorcenFabrica.BindearPropiedadControl = Nothing
        Me.txtPorcenFabrica.BindearPropiedadEntidad = Nothing
        Me.txtPorcenFabrica.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcenFabrica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcenFabrica.Formato = "##0.00"
        Me.txtPorcenFabrica.IsDecimal = True
        Me.txtPorcenFabrica.IsNumber = True
        Me.txtPorcenFabrica.IsPK = False
        Me.txtPorcenFabrica.IsRequired = False
        Me.txtPorcenFabrica.Key = ""
        Me.txtPorcenFabrica.LabelAsoc = Me.lblPorcPrecioFabrica
        Me.txtPorcenFabrica.Location = New System.Drawing.Point(10, 19)
        Me.txtPorcenFabrica.MaxLength = 5
        Me.txtPorcenFabrica.Name = "txtPorcenFabrica"
        Me.txtPorcenFabrica.Size = New System.Drawing.Size(68, 20)
        Me.txtPorcenFabrica.TabIndex = 0
        Me.txtPorcenFabrica.Text = "0.00"
        Me.txtPorcenFabrica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(133, 275)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 20
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
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
        Me.cmbTodos.Location = New System.Drawing.Point(11, 276)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 19
        '
        'btnDescuentoRecargoPorc1
        '
        Me.btnDescuentoRecargoPorc1.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnDescuentoRecargoPorc1.Location = New System.Drawing.Point(317, 275)
        Me.btnDescuentoRecargoPorc1.Name = "btnDescuentoRecargoPorc1"
        Me.btnDescuentoRecargoPorc1.Size = New System.Drawing.Size(22, 22)
        Me.btnDescuentoRecargoPorc1.TabIndex = 3
        Me.btnDescuentoRecargoPorc1.Tag = "DescuentoRecargoPorcNuevo1"
        Me.btnDescuentoRecargoPorc1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoRecargoPorc1.UseVisualStyleBackColor = True
        '
        'txtDescuentoRecargoPorc1
        '
        Me.txtDescuentoRecargoPorc1.BindearPropiedadControl = Nothing
        Me.txtDescuentoRecargoPorc1.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoRecargoPorc1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc1.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc1.IsDecimal = True
        Me.txtDescuentoRecargoPorc1.IsNumber = True
        Me.txtDescuentoRecargoPorc1.IsPK = False
        Me.txtDescuentoRecargoPorc1.IsRequired = False
        Me.txtDescuentoRecargoPorc1.Key = ""
        Me.txtDescuentoRecargoPorc1.LabelAsoc = Me.lblDescuentoRecargoPorc1
        Me.txtDescuentoRecargoPorc1.Location = New System.Drawing.Point(267, 276)
        Me.txtDescuentoRecargoPorc1.Name = "txtDescuentoRecargoPorc1"
        Me.txtDescuentoRecargoPorc1.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoRecargoPorc1.TabIndex = 2
        Me.txtDescuentoRecargoPorc1.Text = "0,00"
        Me.txtDescuentoRecargoPorc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargoPorc1
        '
        Me.lblDescuentoRecargoPorc1.AutoSize = True
        Me.lblDescuentoRecargoPorc1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargoPorc1.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc1.Location = New System.Drawing.Point(219, 280)
        Me.lblDescuentoRecargoPorc1.Name = "lblDescuentoRecargoPorc1"
        Me.lblDescuentoRecargoPorc1.Size = New System.Drawing.Size(48, 13)
        Me.lblDescuentoRecargoPorc1.TabIndex = 1
        Me.lblDescuentoRecargoPorc1.Text = "% D/R 1"
        '
        'lblDescuentoRecargoPorc2
        '
        Me.lblDescuentoRecargoPorc2.AutoSize = True
        Me.lblDescuentoRecargoPorc2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargoPorc2.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc2.Location = New System.Drawing.Point(339, 280)
        Me.lblDescuentoRecargoPorc2.Name = "lblDescuentoRecargoPorc2"
        Me.lblDescuentoRecargoPorc2.Size = New System.Drawing.Size(48, 13)
        Me.lblDescuentoRecargoPorc2.TabIndex = 4
        Me.lblDescuentoRecargoPorc2.Text = "% D/R 2"
        '
        'txtDescuentoRecargoPorc2
        '
        Me.txtDescuentoRecargoPorc2.BindearPropiedadControl = Nothing
        Me.txtDescuentoRecargoPorc2.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoRecargoPorc2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc2.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc2.IsDecimal = True
        Me.txtDescuentoRecargoPorc2.IsNumber = True
        Me.txtDescuentoRecargoPorc2.IsPK = False
        Me.txtDescuentoRecargoPorc2.IsRequired = False
        Me.txtDescuentoRecargoPorc2.Key = ""
        Me.txtDescuentoRecargoPorc2.LabelAsoc = Me.lblDescuentoRecargoPorc2
        Me.txtDescuentoRecargoPorc2.Location = New System.Drawing.Point(387, 276)
        Me.txtDescuentoRecargoPorc2.Name = "txtDescuentoRecargoPorc2"
        Me.txtDescuentoRecargoPorc2.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoRecargoPorc2.TabIndex = 5
        Me.txtDescuentoRecargoPorc2.Text = "0,00"
        Me.txtDescuentoRecargoPorc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDescuentoRecargoPorc2
        '
        Me.btnDescuentoRecargoPorc2.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnDescuentoRecargoPorc2.Location = New System.Drawing.Point(437, 275)
        Me.btnDescuentoRecargoPorc2.Name = "btnDescuentoRecargoPorc2"
        Me.btnDescuentoRecargoPorc2.Size = New System.Drawing.Size(22, 22)
        Me.btnDescuentoRecargoPorc2.TabIndex = 6
        Me.btnDescuentoRecargoPorc2.Tag = "DescuentoRecargoPorcNuevo2"
        Me.btnDescuentoRecargoPorc2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoRecargoPorc2.UseVisualStyleBackColor = True
        '
        'lblDescuentoRecargoPorc3
        '
        Me.lblDescuentoRecargoPorc3.AutoSize = True
        Me.lblDescuentoRecargoPorc3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargoPorc3.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc3.Location = New System.Drawing.Point(459, 280)
        Me.lblDescuentoRecargoPorc3.Name = "lblDescuentoRecargoPorc3"
        Me.lblDescuentoRecargoPorc3.Size = New System.Drawing.Size(48, 13)
        Me.lblDescuentoRecargoPorc3.TabIndex = 7
        Me.lblDescuentoRecargoPorc3.Text = "% D/R 3"
        '
        'txtDescuentoRecargoPorc3
        '
        Me.txtDescuentoRecargoPorc3.BindearPropiedadControl = Nothing
        Me.txtDescuentoRecargoPorc3.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoRecargoPorc3.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc3.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc3.IsDecimal = True
        Me.txtDescuentoRecargoPorc3.IsNumber = True
        Me.txtDescuentoRecargoPorc3.IsPK = False
        Me.txtDescuentoRecargoPorc3.IsRequired = False
        Me.txtDescuentoRecargoPorc3.Key = ""
        Me.txtDescuentoRecargoPorc3.LabelAsoc = Me.lblDescuentoRecargoPorc3
        Me.txtDescuentoRecargoPorc3.Location = New System.Drawing.Point(507, 276)
        Me.txtDescuentoRecargoPorc3.Name = "txtDescuentoRecargoPorc3"
        Me.txtDescuentoRecargoPorc3.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoRecargoPorc3.TabIndex = 8
        Me.txtDescuentoRecargoPorc3.Text = "0,00"
        Me.txtDescuentoRecargoPorc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDescuentoRecargoPorc3
        '
        Me.btnDescuentoRecargoPorc3.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnDescuentoRecargoPorc3.Location = New System.Drawing.Point(557, 275)
        Me.btnDescuentoRecargoPorc3.Name = "btnDescuentoRecargoPorc3"
        Me.btnDescuentoRecargoPorc3.Size = New System.Drawing.Size(22, 22)
        Me.btnDescuentoRecargoPorc3.TabIndex = 9
        Me.btnDescuentoRecargoPorc3.Tag = "DescuentoRecargoPorcNuevo3"
        Me.btnDescuentoRecargoPorc3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoRecargoPorc3.UseVisualStyleBackColor = True
        '
        'lblDescuentoRecargoPorc4
        '
        Me.lblDescuentoRecargoPorc4.AutoSize = True
        Me.lblDescuentoRecargoPorc4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargoPorc4.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc4.Location = New System.Drawing.Point(579, 280)
        Me.lblDescuentoRecargoPorc4.Name = "lblDescuentoRecargoPorc4"
        Me.lblDescuentoRecargoPorc4.Size = New System.Drawing.Size(48, 13)
        Me.lblDescuentoRecargoPorc4.TabIndex = 10
        Me.lblDescuentoRecargoPorc4.Text = "% D/R 4"
        '
        'txtDescuentoRecargoPorc4
        '
        Me.txtDescuentoRecargoPorc4.BindearPropiedadControl = Nothing
        Me.txtDescuentoRecargoPorc4.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoRecargoPorc4.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc4.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc4.IsDecimal = True
        Me.txtDescuentoRecargoPorc4.IsNumber = True
        Me.txtDescuentoRecargoPorc4.IsPK = False
        Me.txtDescuentoRecargoPorc4.IsRequired = False
        Me.txtDescuentoRecargoPorc4.Key = ""
        Me.txtDescuentoRecargoPorc4.LabelAsoc = Me.lblDescuentoRecargoPorc4
        Me.txtDescuentoRecargoPorc4.Location = New System.Drawing.Point(627, 276)
        Me.txtDescuentoRecargoPorc4.Name = "txtDescuentoRecargoPorc4"
        Me.txtDescuentoRecargoPorc4.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoRecargoPorc4.TabIndex = 11
        Me.txtDescuentoRecargoPorc4.Text = "0,00"
        Me.txtDescuentoRecargoPorc4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDescuentoRecargoPorc4
        '
        Me.btnDescuentoRecargoPorc4.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnDescuentoRecargoPorc4.Location = New System.Drawing.Point(677, 275)
        Me.btnDescuentoRecargoPorc4.Name = "btnDescuentoRecargoPorc4"
        Me.btnDescuentoRecargoPorc4.Size = New System.Drawing.Size(22, 22)
        Me.btnDescuentoRecargoPorc4.TabIndex = 12
        Me.btnDescuentoRecargoPorc4.Tag = "DescuentoRecargoPorcNuevo4"
        Me.btnDescuentoRecargoPorc4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoRecargoPorc4.UseVisualStyleBackColor = True
        '
        'lblDescuentoRecargoPorc5
        '
        Me.lblDescuentoRecargoPorc5.AutoSize = True
        Me.lblDescuentoRecargoPorc5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargoPorc5.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc5.Location = New System.Drawing.Point(699, 280)
        Me.lblDescuentoRecargoPorc5.Name = "lblDescuentoRecargoPorc5"
        Me.lblDescuentoRecargoPorc5.Size = New System.Drawing.Size(48, 13)
        Me.lblDescuentoRecargoPorc5.TabIndex = 13
        Me.lblDescuentoRecargoPorc5.Text = "% D/R 5"
        '
        'txtDescuentoRecargoPorc5
        '
        Me.txtDescuentoRecargoPorc5.BindearPropiedadControl = Nothing
        Me.txtDescuentoRecargoPorc5.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoRecargoPorc5.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc5.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc5.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc5.IsDecimal = True
        Me.txtDescuentoRecargoPorc5.IsNumber = True
        Me.txtDescuentoRecargoPorc5.IsPK = False
        Me.txtDescuentoRecargoPorc5.IsRequired = False
        Me.txtDescuentoRecargoPorc5.Key = ""
        Me.txtDescuentoRecargoPorc5.LabelAsoc = Me.lblDescuentoRecargoPorc5
        Me.txtDescuentoRecargoPorc5.Location = New System.Drawing.Point(747, 276)
        Me.txtDescuentoRecargoPorc5.Name = "txtDescuentoRecargoPorc5"
        Me.txtDescuentoRecargoPorc5.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoRecargoPorc5.TabIndex = 14
        Me.txtDescuentoRecargoPorc5.Text = "0,00"
        Me.txtDescuentoRecargoPorc5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDescuentoRecargoPorc5
        '
        Me.btnDescuentoRecargoPorc5.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnDescuentoRecargoPorc5.Location = New System.Drawing.Point(797, 275)
        Me.btnDescuentoRecargoPorc5.Name = "btnDescuentoRecargoPorc5"
        Me.btnDescuentoRecargoPorc5.Size = New System.Drawing.Size(22, 22)
        Me.btnDescuentoRecargoPorc5.TabIndex = 15
        Me.btnDescuentoRecargoPorc5.Tag = "DescuentoRecargoPorcNuevo5"
        Me.btnDescuentoRecargoPorc5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoRecargoPorc5.UseVisualStyleBackColor = True
        '
        'lblDescuentoRecargoPorc6
        '
        Me.lblDescuentoRecargoPorc6.AutoSize = True
        Me.lblDescuentoRecargoPorc6.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc6.Location = New System.Drawing.Point(819, 280)
        Me.lblDescuentoRecargoPorc6.Name = "lblDescuentoRecargoPorc6"
        Me.lblDescuentoRecargoPorc6.Size = New System.Drawing.Size(48, 13)
        Me.lblDescuentoRecargoPorc6.TabIndex = 16
        Me.lblDescuentoRecargoPorc6.Text = "% D/R 6"
        '
        'txtDescuentoRecargoPorc6
        '
        Me.txtDescuentoRecargoPorc6.BindearPropiedadControl = Nothing
        Me.txtDescuentoRecargoPorc6.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoRecargoPorc6.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc6.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc6.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc6.IsDecimal = True
        Me.txtDescuentoRecargoPorc6.IsNumber = True
        Me.txtDescuentoRecargoPorc6.IsPK = False
        Me.txtDescuentoRecargoPorc6.IsRequired = False
        Me.txtDescuentoRecargoPorc6.Key = ""
        Me.txtDescuentoRecargoPorc6.LabelAsoc = Me.lblDescuentoRecargoPorc6
        Me.txtDescuentoRecargoPorc6.Location = New System.Drawing.Point(867, 276)
        Me.txtDescuentoRecargoPorc6.Name = "txtDescuentoRecargoPorc6"
        Me.txtDescuentoRecargoPorc6.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoRecargoPorc6.TabIndex = 17
        Me.txtDescuentoRecargoPorc6.Text = "0.00"
        Me.txtDescuentoRecargoPorc6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDescuentoRecargoPorc6
        '
        Me.btnDescuentoRecargoPorc6.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnDescuentoRecargoPorc6.Location = New System.Drawing.Point(917, 275)
        Me.btnDescuentoRecargoPorc6.Name = "btnDescuentoRecargoPorc6"
        Me.btnDescuentoRecargoPorc6.Size = New System.Drawing.Size(22, 22)
        Me.btnDescuentoRecargoPorc6.TabIndex = 18
        Me.btnDescuentoRecargoPorc6.Tag = "DescuentoRecargoPorcNuevo6"
        Me.btnDescuentoRecargoPorc6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoRecargoPorc6.UseVisualStyleBackColor = True
        '
        'ugPrecios
        '
        Me.ugPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugPrecios.DisplayLayout.Appearance = Appearance1
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugPrecios.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugPrecios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPrecios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPrecios.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPrecios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugPrecios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPrecios.DisplayLayout.GroupByBox.Prompt = " Arrastrar la Columna que desea agrupar"
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPrecios.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugPrecios.DisplayLayout.MaxColScrollRegions = 1
        Me.ugPrecios.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugPrecios.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugPrecios.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugPrecios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugPrecios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPrecios.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugPrecios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugPrecios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugPrecios.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugPrecios.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugPrecios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugPrecios.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPrecios.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugPrecios.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugPrecios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugPrecios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugPrecios.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugPrecios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPrecios.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugPrecios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugPrecios.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugPrecios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugPrecios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugPrecios.EnterMueveACeldaDeAbajo = True
        Me.ugPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugPrecios.Location = New System.Drawing.Point(11, 304)
        Me.ugPrecios.Name = "ugPrecios"
        Me.ugPrecios.Size = New System.Drawing.Size(964, 232)
        Me.ugPrecios.TabIndex = 21
        Me.ugPrecios.Text = "UltraGrid1"
        Me.ugPrecios.ToolStripLabelRegistros = Nothing
        Me.ugPrecios.ToolStripMenuExpandir = Nothing
        Me.ugPrecios.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
        '
        'FilterManager1
        '
        Me.FilterManager1.BotonRefrescar = Me.tsbRefrescar
        Me.FilterManager1.PanelFiltro = Me.pnlFiltros
        '
        'ActualizarPreciosV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.ugPrecios)
        Me.Controls.Add(Me.btnDescuentoRecargoPorc6)
        Me.Controls.Add(Me.btnDescuentoRecargoPorc5)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc6)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc5)
        Me.Controls.Add(Me.btnDescuentoRecargoPorc4)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc4)
        Me.Controls.Add(Me.btnDescuentoRecargoPorc3)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc6)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc3)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc5)
        Me.Controls.Add(Me.btnDescuentoRecargoPorc2)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc4)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc2)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc3)
        Me.Controls.Add(Me.btnDescuentoRecargoPorc1)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc2)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc1)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc1)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ActualizarPreciosV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualización de precios"
        CType(Me.dgvListasPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.tbcDetalle.ResumeLayout(False)
        Me.TbpFiltros.ResumeLayout(False)
        Me.TbpFiltros.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        CType(Me.dgvSeleccionListaPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbpCalcular.ResumeLayout(False)
        Me.TbpCalcular.PerformLayout()
        Me.grpRedondeo.ResumeLayout(False)
        Me.grpRedondeo.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbPrecioCompra.ResumeLayout(False)
        Me.grbPrecioCompra.PerformLayout()
        CType(Me.ugPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblSucursales As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents dgvListasPrecios As Eniac.Controles.DataGridView
   Friend WithEvents lblListasDePrecios As Eniac.Controles.Label
   Friend WithEvents tsbImportarExcel As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents lblPrecioCostoPorc2 As Eniac.Controles.Label
   Friend WithEvents txtPrecioCostoPorc As Eniac.Controles.TextBox
   Friend WithEvents chbSinVenta As Eniac.Controles.CheckBox
   Friend WithEvents chbSinCosto As Eniac.Controles.CheckBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents cboCompuestos As Eniac.Controles.ComboBox
   Friend WithEvents lblCompuestos As Eniac.Controles.Label
   Friend WithEvents rdbCostoSiMismo As Eniac.Controles.RadioButton
   Friend WithEvents rdbCostoDesdeFormula As Eniac.Controles.RadioButton
   Friend WithEvents chbAjusteA As Eniac.Controles.CheckBox
   Friend WithEvents lblPrecioCostoMonto As Eniac.Controles.Label
   Friend WithEvents txtPrecioCostoMonto As Eniac.Controles.TextBox
   Friend WithEvents chbFechaActualizado As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents TbpFiltros As System.Windows.Forms.TabPage
   Friend WithEvents TbpCalcular As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents grbPrecioCompra As System.Windows.Forms.GroupBox
   Friend WithEvents rdbFabricaSiMismo As Eniac.Controles.RadioButton
   Friend WithEvents lblPorcPrecioFabrica As Eniac.Controles.Label
   Friend WithEvents txtPorcenFabrica As Eniac.Controles.TextBox
   Friend WithEvents btnCalcular As Eniac.Controles.Button
   Friend WithEvents rdbCostoFabrica As Eniac.Controles.RadioButton
   Friend WithEvents txtAjusteA As Eniac.Controles.TextBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents txtProducto As Eniac.Controles.TextBox
   Friend WithEvents radRedondeoPrecioVenta As RadioButton
   Friend WithEvents txtRedondeoPrecioVenta As Eniac.Controles.TextBox
   Friend WithEvents dgvSeleccionListaPrecios As Eniac.Controles.DataGridView
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbProveedorHabitual As Eniac.Controles.CheckBox
   Friend WithEvents cmbEsOferta As Eniac.Controles.ComboBox
   Friend WithEvents Label15 As Eniac.Controles.Label
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Friend WithEvents btnTodosListas As System.Windows.Forms.Button
   Friend WithEvents cmbTodosListas As Eniac.Controles.ComboBox
   Friend WithEvents lblCodigoProductoProveedor As Eniac.Controles.Label
   Friend WithEvents txtCodigoProductoProveedor As Eniac.Controles.TextBox
   Friend WithEvents btnDescuentoRecargoPorc1 As Eniac.Controles.Button
   Friend WithEvents txtDescuentoRecargoPorc1 As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargoPorc1 As Eniac.Controles.Label
   Friend WithEvents lblDescuentoRecargoPorc2 As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargoPorc2 As Eniac.Controles.TextBox
   Friend WithEvents btnDescuentoRecargoPorc2 As Eniac.Controles.Button
   Friend WithEvents lblDescuentoRecargoPorc3 As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargoPorc3 As Eniac.Controles.TextBox
   Friend WithEvents btnDescuentoRecargoPorc3 As Eniac.Controles.Button
   Friend WithEvents lblDescuentoRecargoPorc4 As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargoPorc4 As Eniac.Controles.TextBox
   Friend WithEvents btnDescuentoRecargoPorc4 As Eniac.Controles.Button
   Friend WithEvents lblDescuentoRecargoPorc5 As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargoPorc5 As Eniac.Controles.TextBox
   Friend WithEvents btnDescuentoRecargoPorc5 As Eniac.Controles.Button
   Friend WithEvents lblDescuentoRecargoPorc6 As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargoPorc6 As Eniac.Controles.TextBox
   Friend WithEvents btnDescuentoRecargoPorc6 As Eniac.Controles.Button
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents chbPorcActual As Eniac.Controles.CheckBox
   Friend WithEvents chbSobreVenta As Eniac.Controles.CheckBox
   Friend WithEvents chbSobreCosto As Eniac.Controles.CheckBox
   Friend WithEvents chbDesdeFormula As Eniac.Controles.CheckBox
   Friend WithEvents ugPrecios As Eniac.Win.UltraGridEditable
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbRubro As Eniac.Win.ComboBoxRubro
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents cmbMarca As Eniac.Win.ComboBoxMarcas
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents cmbMoneda As Eniac.Controles.ComboBox
   Friend WithEvents chbMoneda As Eniac.Controles.CheckBox
   Friend WithEvents pnlFiltros As Eniac.Controles.Panel
   Friend WithEvents FilterManager1 As Eniac.Win.FilterManager.FilterManager
   Friend WithEvents chbSubSubRubro As Controles.CheckBox
   Friend WithEvents cmbSubRubro As ComboBoxSubRubro
   Friend WithEvents cmbSubSubRubro As ComboBoxSubSubRubro
   Friend WithEvents chbConStock As Controles.CheckBox
   Friend WithEvents cmbConStock As Controles.ComboBox
   Friend WithEvents tssProcesoImportacion As ToolStripStatusLabel
   Friend WithEvents grpRedondeo As GroupBox
   Friend WithEvents radEnteroPrecioVenta As RadioButton
   Friend WithEvents txtEnteroPrecioVenta As Controles.TextBox
   Friend WithEvents lblEnteroPrecioVentaBaseRedondeo As Controles.Label
   Friend WithEvents txtEnteroPrecioVentaBaseRedondeo As Controles.TextBox
End Class
