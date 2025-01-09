<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmisionDeEtiquetasDePrecios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmisionDeEtiquetasDePrecios))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.chbFormaPago = New Eniac.Controles.CheckBox()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.lblRubro = New Eniac.Controles.Label()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.cmbListasDePrecios2 = New Eniac.Controles.ComboBox()
        Me.lblListasDePrecios2 = New Eniac.Controles.Label()
        Me.lblMarca = New Eniac.Controles.Label()
        Me.cmbFormatos = New Eniac.Controles.ComboBox()
        Me.lblListaPrecios = New Eniac.Controles.Label()
        Me.cmbRubro = New Eniac.Win.ComboBoxRubro()
        Me.cmbMarca = New Eniac.Win.ComboBoxMarcas()
        Me.txtCabecera = New Eniac.Controles.TextBox()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.lblFormato = New System.Windows.Forms.Label()
        Me.chbStockPositivo = New Eniac.Controles.CheckBox()
        Me.chbFechaActualizado = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.txtCodigo = New Eniac.Controles.TextBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.txtProducto = New Eniac.Controles.TextBox()
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.Imprime = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PrecioListaDePreciosConIVA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioListaDePreciosSinIVA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioListaDePreciosSinIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioListaDePreciosConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCorto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCostoSinIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCostoConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVentaSinIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVentaConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVentaConIVA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVentaSinIVA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaActualizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockInicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alicuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoDeBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListaPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListaPrecio1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidHasta1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UHPorc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.dgvSeleccionados = New Eniac.Controles.DataGridView()
        Me.gImprime = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gPrecioListaDePreciosSinIVA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPrecioListaDePreciosSinIVA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPrecioListaDePreciosConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPrecioListaDePreciosSinIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gNombreSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gNombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPrecioCostoSinIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPrecioCostoConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPrecioVentaSinIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPrecioVentaConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVentaSinIVA11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVentaConIVA11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gNombreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gNombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gFechaActualizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gIdRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gStockInicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gAlicuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gCodigoDeBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListaPrecio0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListaPrecio10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gUnidHasta1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gUHPorc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPrecioDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbConsultar.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbConsultar
        '
        Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbConsultar.Controls.Add(Me.chbFormaPago)
        Me.grbConsultar.Controls.Add(Me.cmbFormaPago)
        Me.grbConsultar.Controls.Add(Me.lblRubro)
        Me.grbConsultar.Controls.Add(Me.chbConIVA)
        Me.grbConsultar.Controls.Add(Me.cmbListasDePrecios2)
        Me.grbConsultar.Controls.Add(Me.lblMarca)
        Me.grbConsultar.Controls.Add(Me.lblListasDePrecios2)
        Me.grbConsultar.Controls.Add(Me.cmbFormatos)
        Me.grbConsultar.Controls.Add(Me.cmbRubro)
        Me.grbConsultar.Controls.Add(Me.cmbMarca)
        Me.grbConsultar.Controls.Add(Me.txtCabecera)
        Me.grbConsultar.Controls.Add(Me.lblFormato)
        Me.grbConsultar.Controls.Add(Me.chbStockPositivo)
        Me.grbConsultar.Controls.Add(Me.chbFechaActualizado)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Controls.Add(Me.cmbListaDePrecios)
        Me.grbConsultar.Controls.Add(Me.lblListaPrecios)
        Me.grbConsultar.Controls.Add(Me.lblCodigo)
        Me.grbConsultar.Controls.Add(Me.txtCodigo)
        Me.grbConsultar.Controls.Add(Me.btnBuscar)
        Me.grbConsultar.Controls.Add(Me.lblProducto)
        Me.grbConsultar.Controls.Add(Me.txtProducto)
        Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(1014, 125)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Filtros"
        '
        'chbFormaPago
        '
        Me.chbFormaPago.AutoSize = True
        Me.chbFormaPago.BindearPropiedadControl = Nothing
        Me.chbFormaPago.BindearPropiedadEntidad = Nothing
        Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormaPago.IsPK = False
        Me.chbFormaPago.IsRequired = False
        Me.chbFormaPago.Key = Nothing
        Me.chbFormaPago.LabelAsoc = Nothing
        Me.chbFormaPago.Location = New System.Drawing.Point(685, 63)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(102, 17)
        Me.chbFormaPago.TabIndex = 55
        Me.chbFormaPago.Text = "F. de Pago D/R"
        Me.chbFormaPago.UseVisualStyleBackColor = True
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
        Me.cmbFormaPago.LabelAsoc = Me.chbFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(793, 61)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(109, 21)
        Me.cmbFormaPago.TabIndex = 56
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(251, 64)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 53
        Me.lblRubro.Text = "Rubro"
        '
        'chbConIVA
        '
        Me.chbConIVA.AutoSize = True
        Me.chbConIVA.BindearPropiedadControl = Nothing
        Me.chbConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConIVA.IsPK = False
        Me.chbConIVA.IsRequired = False
        Me.chbConIVA.Key = Nothing
        Me.chbConIVA.LabelAsoc = Nothing
        Me.chbConIVA.Location = New System.Drawing.Point(601, 63)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 50
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
        '
        'cmbListasDePrecios2
        '
        Me.cmbListasDePrecios2.BindearPropiedadControl = Nothing
        Me.cmbListasDePrecios2.BindearPropiedadEntidad = Nothing
        Me.cmbListasDePrecios2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListasDePrecios2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListasDePrecios2.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListasDePrecios2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListasDePrecios2.FormattingEnabled = True
        Me.cmbListasDePrecios2.IsPK = False
        Me.cmbListasDePrecios2.IsRequired = False
        Me.cmbListasDePrecios2.Key = Nothing
        Me.cmbListasDePrecios2.LabelAsoc = Me.lblListasDePrecios2
        Me.cmbListasDePrecios2.Location = New System.Drawing.Point(815, 98)
        Me.cmbListasDePrecios2.Name = "cmbListasDePrecios2"
        Me.cmbListasDePrecios2.Size = New System.Drawing.Size(139, 21)
        Me.cmbListasDePrecios2.TabIndex = 20
        Me.cmbListasDePrecios2.Visible = False
        '
        'lblListasDePrecios2
        '
        Me.lblListasDePrecios2.AutoSize = True
        Me.lblListasDePrecios2.LabelAsoc = Nothing
        Me.lblListasDePrecios2.Location = New System.Drawing.Point(718, 102)
        Me.lblListasDePrecios2.Name = "lblListasDePrecios2"
        Me.lblListasDePrecios2.Size = New System.Drawing.Size(91, 13)
        Me.lblListasDePrecios2.TabIndex = 21
        Me.lblListasDePrecios2.Text = "Lista de Precios 2"
        Me.lblListasDePrecios2.Visible = False
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.LabelAsoc = Nothing
        Me.lblMarca.Location = New System.Drawing.Point(5, 64)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 54
        Me.lblMarca.Text = "Marca"
        '
        'cmbFormatos
        '
        Me.cmbFormatos.BindearPropiedadControl = Nothing
        Me.cmbFormatos.BindearPropiedadEntidad = Nothing
        Me.cmbFormatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormatos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormatos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormatos.FormattingEnabled = True
        Me.cmbFormatos.IsPK = False
        Me.cmbFormatos.IsRequired = False
        Me.cmbFormatos.Key = Nothing
        Me.cmbFormatos.LabelAsoc = Me.lblListaPrecios
        Me.cmbFormatos.Location = New System.Drawing.Point(551, 98)
        Me.cmbFormatos.Name = "cmbFormatos"
        Me.cmbFormatos.Size = New System.Drawing.Size(160, 21)
        Me.cmbFormatos.TabIndex = 19
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.LabelAsoc = Nothing
        Me.lblListaPrecios.Location = New System.Drawing.Point(468, 23)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 5
        Me.lblListaPrecios.Text = "Lista de Precios"
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
        Me.cmbRubro.Location = New System.Drawing.Point(293, 61)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(191, 21)
        Me.cmbRubro.TabIndex = 52
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
        Me.cmbMarca.Location = New System.Drawing.Point(48, 61)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(195, 21)
        Me.cmbMarca.TabIndex = 51
        '
        'txtCabecera
        '
        Me.txtCabecera.BindearPropiedadControl = Nothing
        Me.txtCabecera.BindearPropiedadEntidad = Nothing
        Me.txtCabecera.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCabecera.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCabecera.Formato = ""
        Me.txtCabecera.IsDecimal = False
        Me.txtCabecera.IsNumber = False
        Me.txtCabecera.IsPK = False
        Me.txtCabecera.IsRequired = False
        Me.txtCabecera.Key = ""
        Me.txtCabecera.LabelAsoc = Me.lblProducto
        Me.txtCabecera.Location = New System.Drawing.Point(717, 98)
        Me.txtCabecera.MaxLength = 22
        Me.txtCabecera.Name = "txtCabecera"
        Me.txtCabecera.Size = New System.Drawing.Size(169, 20)
        Me.txtCabecera.TabIndex = 18
        Me.txtCabecera.Visible = False
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(148, 23)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 3
        Me.lblProducto.Text = "Producto"
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.Location = New System.Drawing.Point(500, 101)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(45, 13)
        Me.lblFormato.TabIndex = 15
        Me.lblFormato.Text = "Formato"
        '
        'chbStockPositivo
        '
        Me.chbStockPositivo.AutoSize = True
        Me.chbStockPositivo.BindearPropiedadControl = Nothing
        Me.chbStockPositivo.BindearPropiedadEntidad = Nothing
        Me.chbStockPositivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbStockPositivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbStockPositivo.IsPK = False
        Me.chbStockPositivo.IsRequired = False
        Me.chbStockPositivo.Key = Nothing
        Me.chbStockPositivo.LabelAsoc = Nothing
        Me.chbStockPositivo.Location = New System.Drawing.Point(501, 63)
        Me.chbStockPositivo.Name = "chbStockPositivo"
        Me.chbStockPositivo.Size = New System.Drawing.Size(94, 17)
        Me.chbStockPositivo.TabIndex = 13
        Me.chbStockPositivo.Text = "Stock Positivo"
        Me.chbStockPositivo.UseVisualStyleBackColor = True
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
        Me.chbFechaActualizado.Location = New System.Drawing.Point(11, 99)
        Me.chbFechaActualizado.Name = "chbFechaActualizado"
        Me.chbFechaActualizado.Size = New System.Drawing.Size(114, 17)
        Me.chbFechaActualizado.TabIndex = 8
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
        Me.dtpHasta.Location = New System.Drawing.Point(359, 97)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 12
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(322, 101)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 11
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
        Me.dtpDesde.Location = New System.Drawing.Point(179, 97)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 10
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(135, 101)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 9
        Me.lblDesde.Text = "Desde"
        '
        'cmbListaDePrecios
        '
        Me.cmbListaDePrecios.BindearPropiedadControl = Nothing
        Me.cmbListaDePrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaDePrecios.FormattingEnabled = True
        Me.cmbListaDePrecios.IsPK = False
        Me.cmbListaDePrecios.IsRequired = False
        Me.cmbListaDePrecios.Key = Nothing
        Me.cmbListaDePrecios.LabelAsoc = Me.lblListaPrecios
        Me.cmbListaDePrecios.Location = New System.Drawing.Point(557, 20)
        Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
        Me.cmbListaDePrecios.Size = New System.Drawing.Size(154, 21)
        Me.cmbListaDePrecios.TabIndex = 4
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(7, 23)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 1
        Me.lblCodigo.Text = "Codigo"
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
        Me.txtCodigo.Location = New System.Drawing.Point(50, 20)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(92, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(916, 45)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(92, 47)
        Me.btnBuscar.TabIndex = 14
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
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
        Me.txtProducto.Location = New System.Drawing.Point(202, 20)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(260, 20)
        Me.txtProducto.TabIndex = 2
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeight = 44
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Imprime, Me.PrecioListaDePreciosConIVA1, Me.PrecioListaDePreciosSinIVA1, Me.PrecioListaDePreciosSinIVA, Me.PrecioListaDePreciosConIVA, Me.IdSucursal, Me.NombreSucursal, Me.IdProducto, Me.NombreProducto, Me.NombreCorto, Me.PrecioCostoSinIVA, Me.PrecioCostoConIVA, Me.PrecioVentaSinIVA, Me.PrecioVentaConIVA, Me.PrecioVentaConIVA1, Me.PrecioVentaSinIVA1, Me.Stock, Me.NombreMarca, Me.NombreRubro, Me.FechaActualizacion, Me.IdMarca, Me.IdRubro, Me.StockInicial, Me.Alicuota, Me.CodigoDeBarras, Me.ListaPrecio, Me.ListaPrecio1, Me.Lote, Me.UnidHasta1, Me.UHPorc1, Me.PrecioDesc})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 163)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowHeadersWidth = 15
        Me.dgvDetalle.Size = New System.Drawing.Size(971, 181)
        Me.dgvDetalle.TabIndex = 1
        '
        'Imprime
        '
        Me.Imprime.DataPropertyName = "Imprime"
        Me.Imprime.HeaderText = "Imp."
        Me.Imprime.Name = "Imprime"
        Me.Imprime.Width = 40
        '
        'PrecioListaDePreciosConIVA1
        '
        Me.PrecioListaDePreciosConIVA1.DataPropertyName = "PrecioListaDePreciosConIVA1"
        Me.PrecioListaDePreciosConIVA1.HeaderText = "PrecioListaDePreciosConIVA1"
        Me.PrecioListaDePreciosConIVA1.Name = "PrecioListaDePreciosConIVA1"
        Me.PrecioListaDePreciosConIVA1.Visible = False
        '
        'PrecioListaDePreciosSinIVA1
        '
        Me.PrecioListaDePreciosSinIVA1.DataPropertyName = "PrecioListaDePreciosSinIVA1"
        Me.PrecioListaDePreciosSinIVA1.HeaderText = "PrecioListaDePreciosSinIVA1"
        Me.PrecioListaDePreciosSinIVA1.Name = "PrecioListaDePreciosSinIVA1"
        Me.PrecioListaDePreciosSinIVA1.Visible = False
        '
        'PrecioListaDePreciosSinIVA
        '
        Me.PrecioListaDePreciosSinIVA.DataPropertyName = "PrecioListaDePreciosSinIVA"
        Me.PrecioListaDePreciosSinIVA.HeaderText = "PrecioListaDePreciosSinIVA"
        Me.PrecioListaDePreciosSinIVA.Name = "PrecioListaDePreciosSinIVA"
        Me.PrecioListaDePreciosSinIVA.Visible = False
        '
        'PrecioListaDePreciosConIVA
        '
        Me.PrecioListaDePreciosConIVA.DataPropertyName = "PrecioListaDePreciosConIVA"
        Me.PrecioListaDePreciosConIVA.HeaderText = "PrecioListaDePreciosConIVA"
        Me.PrecioListaDePreciosConIVA.Name = "PrecioListaDePreciosConIVA"
        Me.PrecioListaDePreciosConIVA.Visible = False
        '
        'IdSucursal
        '
        Me.IdSucursal.DataPropertyName = "IdSucursal"
        Me.IdSucursal.HeaderText = "IdSucursal"
        Me.IdSucursal.Name = "IdSucursal"
        Me.IdSucursal.Visible = False
        '
        'NombreSucursal
        '
        Me.NombreSucursal.DataPropertyName = "NombreSucursal"
        Me.NombreSucursal.HeaderText = "Sucursal"
        Me.NombreSucursal.Name = "NombreSucursal"
        Me.NombreSucursal.ReadOnly = True
        Me.NombreSucursal.Visible = False
        Me.NombreSucursal.Width = 80
        '
        'IdProducto
        '
        Me.IdProducto.DataPropertyName = "IdProducto"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdProducto.DefaultCellStyle = DataGridViewCellStyle1
        Me.IdProducto.HeaderText = "Producto"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        '
        'NombreProducto
        '
        Me.NombreProducto.DataPropertyName = "NombreProducto"
        Me.NombreProducto.HeaderText = "Nombre Producto"
        Me.NombreProducto.Name = "NombreProducto"
        Me.NombreProducto.ReadOnly = True
        Me.NombreProducto.Width = 233
        '
        'NombreCorto
        '
        Me.NombreCorto.DataPropertyName = "NombreCorto"
        Me.NombreCorto.HeaderText = "NombreCorto"
        Me.NombreCorto.Name = "NombreCorto"
        Me.NombreCorto.Visible = False
        '
        'PrecioCostoSinIVA
        '
        Me.PrecioCostoSinIVA.DataPropertyName = "PrecioCostoSinIVA"
        Me.PrecioCostoSinIVA.HeaderText = "PrecioCostoSinIVA"
        Me.PrecioCostoSinIVA.Name = "PrecioCostoSinIVA"
        Me.PrecioCostoSinIVA.Visible = False
        '
        'PrecioCostoConIVA
        '
        Me.PrecioCostoConIVA.DataPropertyName = "PrecioCostoConIVA"
        Me.PrecioCostoConIVA.HeaderText = "PrecioCostoConIVA"
        Me.PrecioCostoConIVA.Name = "PrecioCostoConIVA"
        Me.PrecioCostoConIVA.Visible = False
        '
        'PrecioVentaSinIVA
        '
        Me.PrecioVentaSinIVA.DataPropertyName = "PrecioVentaSinIVA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PrecioVentaSinIVA.DefaultCellStyle = DataGridViewCellStyle2
        Me.PrecioVentaSinIVA.HeaderText = "P. Venta Sin IVA"
        Me.PrecioVentaSinIVA.Name = "PrecioVentaSinIVA"
        Me.PrecioVentaSinIVA.ReadOnly = True
        Me.PrecioVentaSinIVA.Visible = False
        Me.PrecioVentaSinIVA.Width = 70
        '
        'PrecioVentaConIVA
        '
        Me.PrecioVentaConIVA.DataPropertyName = "PrecioVentaConIVA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Format = "N2"
        Me.PrecioVentaConIVA.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrecioVentaConIVA.HeaderText = "P. Venta Con IVA"
        Me.PrecioVentaConIVA.Name = "PrecioVentaConIVA"
        Me.PrecioVentaConIVA.Width = 70
        '
        'PrecioVentaConIVA1
        '
        Me.PrecioVentaConIVA1.DataPropertyName = "PrecioVentaConIVA1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.PrecioVentaConIVA1.DefaultCellStyle = DataGridViewCellStyle4
        Me.PrecioVentaConIVA1.HeaderText = "P. Venta Con IVA 2"
        Me.PrecioVentaConIVA1.Name = "PrecioVentaConIVA1"
        Me.PrecioVentaConIVA1.Visible = False
        Me.PrecioVentaConIVA1.Width = 70
        '
        'PrecioVentaSinIVA1
        '
        Me.PrecioVentaSinIVA1.DataPropertyName = "PrecioVentaSinIVA1"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.PrecioVentaSinIVA1.DefaultCellStyle = DataGridViewCellStyle5
        Me.PrecioVentaSinIVA1.HeaderText = "P. Venta Sin IVA1"
        Me.PrecioVentaSinIVA1.Name = "PrecioVentaSinIVA1"
        Me.PrecioVentaSinIVA1.Visible = False
        Me.PrecioVentaSinIVA1.Width = 70
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "Stock"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle6
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 65
        '
        'NombreMarca
        '
        Me.NombreMarca.DataPropertyName = "NombreMarca"
        Me.NombreMarca.HeaderText = "Marca"
        Me.NombreMarca.Name = "NombreMarca"
        Me.NombreMarca.ReadOnly = True
        Me.NombreMarca.Width = 130
        '
        'NombreRubro
        '
        Me.NombreRubro.DataPropertyName = "NombreRubro"
        Me.NombreRubro.HeaderText = "Rubro"
        Me.NombreRubro.Name = "NombreRubro"
        Me.NombreRubro.ReadOnly = True
        Me.NombreRubro.Width = 130
        '
        'FechaActualizacion
        '
        Me.FechaActualizacion.DataPropertyName = "FechaActualizacion"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "dd/MM/yyyy HH:mm"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.FechaActualizacion.DefaultCellStyle = DataGridViewCellStyle7
        Me.FechaActualizacion.HeaderText = "Actualizado"
        Me.FechaActualizacion.Name = "FechaActualizacion"
        Me.FechaActualizacion.ReadOnly = True
        '
        'IdMarca
        '
        Me.IdMarca.DataPropertyName = "IdMarca"
        Me.IdMarca.HeaderText = "IdMarca"
        Me.IdMarca.Name = "IdMarca"
        Me.IdMarca.Visible = False
        '
        'IdRubro
        '
        Me.IdRubro.DataPropertyName = "IdRubro"
        Me.IdRubro.HeaderText = "IdRubro"
        Me.IdRubro.Name = "IdRubro"
        Me.IdRubro.Visible = False
        '
        'StockInicial
        '
        Me.StockInicial.DataPropertyName = "StockInicial"
        Me.StockInicial.HeaderText = "StockInicial"
        Me.StockInicial.Name = "StockInicial"
        Me.StockInicial.Visible = False
        '
        'Alicuota
        '
        Me.Alicuota.DataPropertyName = "Alicuota"
        Me.Alicuota.HeaderText = "Alicuota"
        Me.Alicuota.Name = "Alicuota"
        Me.Alicuota.Visible = False
        '
        'CodigoDeBarras
        '
        Me.CodigoDeBarras.DataPropertyName = "CodigoDeBarras"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CodigoDeBarras.DefaultCellStyle = DataGridViewCellStyle8
        Me.CodigoDeBarras.HeaderText = "Codigo De Barras"
        Me.CodigoDeBarras.Name = "CodigoDeBarras"
        Me.CodigoDeBarras.ReadOnly = True
        '
        'ListaPrecio
        '
        Me.ListaPrecio.DataPropertyName = "ListaPrecio"
        Me.ListaPrecio.HeaderText = "ListaPrecio"
        Me.ListaPrecio.Name = "ListaPrecio"
        Me.ListaPrecio.Visible = False
        '
        'ListaPrecio1
        '
        Me.ListaPrecio1.DataPropertyName = "ListaPrecio1"
        Me.ListaPrecio1.HeaderText = "ListaPrecio1"
        Me.ListaPrecio1.Name = "ListaPrecio1"
        Me.ListaPrecio1.Visible = False
        '
        'Lote
        '
        Me.Lote.DataPropertyName = "Lote"
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.Visible = False
        '
        'UnidHasta1
        '
        Me.UnidHasta1.DataPropertyName = "UnidHasta1"
        Me.UnidHasta1.HeaderText = "UnidHasta1"
        Me.UnidHasta1.Name = "UnidHasta1"
        Me.UnidHasta1.Visible = False
        '
        'UHPorc1
        '
        Me.UHPorc1.DataPropertyName = "UHPorc1"
        Me.UHPorc1.HeaderText = "UHPorc1"
        Me.UHPorc1.Name = "UHPorc1"
        Me.UHPorc1.Visible = False
        '
        'PrecioDesc
        '
        Me.PrecioDesc.DataPropertyName = "PrecioDesc"
        Me.PrecioDesc.HeaderText = "PrecioDesc"
        Me.PrecioDesc.Name = "PrecioDesc"
        Me.PrecioDesc.Visible = False
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1034, 29)
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
        Me.ToolStripSeparator1.AccessibleDescription = "C"
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.AccessibleDescription = "C"
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.AccessibleDescription = "C"
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.AccessibleDescription = "V"
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
        Me.stsStado.Location = New System.Drawing.Point(0, 549)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1034, 22)
        Me.stsStado.TabIndex = 3
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(955, 17)
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
        Me.chbTodos.Enabled = False
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.ImageIndex = 3
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(12, 350)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(119, 24)
        Me.chbTodos.TabIndex = 2
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(989, 381)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 23
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.Location = New System.Drawing.Point(989, 307)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 22
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.AllowUserToDeleteRows = False
        Me.dgvSeleccionados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSeleccionados.ColumnHeadersHeight = 44
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gImprime, Me.gPrecioListaDePreciosSinIVA1, Me.gPrecioListaDePreciosSinIVA2, Me.gPrecioListaDePreciosConIVA, Me.gPrecioListaDePreciosSinIVA, Me.gIdSucursal, Me.gNombreSucursal, Me.gIdProducto, Me.gNombreProducto, Me.gPrecioCostoSinIVA, Me.gPrecioCostoConIVA, Me.gPrecioVentaSinIVA, Me.gPrecioVentaConIVA, Me.PrecioVentaSinIVA11, Me.PrecioVentaConIVA11, Me.gStock, Me.gNombreMarca, Me.gNombreRubro, Me.gFechaActualizacion, Me.gIdMarca, Me.gIdRubro, Me.gStockInicial, Me.gAlicuota, Me.gCodigoDeBarras, Me.ListaPrecio0, Me.ListaPrecio10, Me.Lote2, Me.gUnidHasta1, Me.gUHPorc1, Me.gPrecioDesc})
        Me.dgvSeleccionados.Location = New System.Drawing.Point(12, 381)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.RowHeadersWidth = 15
        Me.dgvSeleccionados.Size = New System.Drawing.Size(971, 158)
        Me.dgvSeleccionados.TabIndex = 24
        '
        'gImprime
        '
        Me.gImprime.DataPropertyName = "Imprime"
        Me.gImprime.HeaderText = "Imp."
        Me.gImprime.Name = "gImprime"
        Me.gImprime.Width = 40
        '
        'gPrecioListaDePreciosSinIVA1
        '
        Me.gPrecioListaDePreciosSinIVA1.DataPropertyName = "PrecioListaDePreciosConIVA1"
        Me.gPrecioListaDePreciosSinIVA1.HeaderText = "PrecioListaDePreciosSinIVA1"
        Me.gPrecioListaDePreciosSinIVA1.Name = "gPrecioListaDePreciosSinIVA1"
        Me.gPrecioListaDePreciosSinIVA1.Visible = False
        '
        'gPrecioListaDePreciosSinIVA2
        '
        Me.gPrecioListaDePreciosSinIVA2.DataPropertyName = "PrecioListaDePreciosSinIVA1"
        Me.gPrecioListaDePreciosSinIVA2.HeaderText = "PrecioListaDePreciosSinIVA1"
        Me.gPrecioListaDePreciosSinIVA2.Name = "gPrecioListaDePreciosSinIVA2"
        Me.gPrecioListaDePreciosSinIVA2.Visible = False
        '
        'gPrecioListaDePreciosConIVA
        '
        Me.gPrecioListaDePreciosConIVA.DataPropertyName = "PrecioListaDePreciosConIVA"
        Me.gPrecioListaDePreciosConIVA.HeaderText = "PrecioListaDePreciosConIVA"
        Me.gPrecioListaDePreciosConIVA.Name = "gPrecioListaDePreciosConIVA"
        Me.gPrecioListaDePreciosConIVA.Visible = False
        '
        'gPrecioListaDePreciosSinIVA
        '
        Me.gPrecioListaDePreciosSinIVA.DataPropertyName = "PrecioListaDePreciosSinIVA"
        Me.gPrecioListaDePreciosSinIVA.HeaderText = "PrecioListaDePreciosSinIVA"
        Me.gPrecioListaDePreciosSinIVA.Name = "gPrecioListaDePreciosSinIVA"
        Me.gPrecioListaDePreciosSinIVA.Visible = False
        '
        'gIdSucursal
        '
        Me.gIdSucursal.DataPropertyName = "IdSucursal"
        Me.gIdSucursal.HeaderText = "IdSucursal"
        Me.gIdSucursal.Name = "gIdSucursal"
        Me.gIdSucursal.Visible = False
        '
        'gNombreSucursal
        '
        Me.gNombreSucursal.DataPropertyName = "NombreSucursal"
        Me.gNombreSucursal.HeaderText = "Sucursal"
        Me.gNombreSucursal.Name = "gNombreSucursal"
        Me.gNombreSucursal.ReadOnly = True
        Me.gNombreSucursal.Visible = False
        Me.gNombreSucursal.Width = 80
        '
        'gIdProducto
        '
        Me.gIdProducto.DataPropertyName = "IdProducto"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gIdProducto.DefaultCellStyle = DataGridViewCellStyle9
        Me.gIdProducto.HeaderText = "Producto"
        Me.gIdProducto.Name = "gIdProducto"
        Me.gIdProducto.ReadOnly = True
        '
        'gNombreProducto
        '
        Me.gNombreProducto.DataPropertyName = "NombreProducto"
        Me.gNombreProducto.HeaderText = "Nombre Producto"
        Me.gNombreProducto.Name = "gNombreProducto"
        Me.gNombreProducto.ReadOnly = True
        Me.gNombreProducto.Width = 233
        '
        'gPrecioCostoSinIVA
        '
        Me.gPrecioCostoSinIVA.DataPropertyName = "PrecioCostoSinIVA"
        Me.gPrecioCostoSinIVA.HeaderText = "PrecioCostoSinIVA"
        Me.gPrecioCostoSinIVA.Name = "gPrecioCostoSinIVA"
        Me.gPrecioCostoSinIVA.Visible = False
        '
        'gPrecioCostoConIVA
        '
        Me.gPrecioCostoConIVA.DataPropertyName = "PrecioCostoConIVA"
        Me.gPrecioCostoConIVA.HeaderText = "PrecioCostoConIVA"
        Me.gPrecioCostoConIVA.Name = "gPrecioCostoConIVA"
        Me.gPrecioCostoConIVA.Visible = False
        '
        'gPrecioVentaSinIVA
        '
        Me.gPrecioVentaSinIVA.DataPropertyName = "PrecioVentaSinIVA"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.gPrecioVentaSinIVA.DefaultCellStyle = DataGridViewCellStyle10
        Me.gPrecioVentaSinIVA.HeaderText = "P. Venta Sin IVA"
        Me.gPrecioVentaSinIVA.Name = "gPrecioVentaSinIVA"
        Me.gPrecioVentaSinIVA.ReadOnly = True
        Me.gPrecioVentaSinIVA.Visible = False
        Me.gPrecioVentaSinIVA.Width = 70
        '
        'gPrecioVentaConIVA
        '
        Me.gPrecioVentaConIVA.DataPropertyName = "PrecioVentaConIVA"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.Format = "N2"
        Me.gPrecioVentaConIVA.DefaultCellStyle = DataGridViewCellStyle11
        Me.gPrecioVentaConIVA.HeaderText = "P. Venta Con IVA"
        Me.gPrecioVentaConIVA.Name = "gPrecioVentaConIVA"
        Me.gPrecioVentaConIVA.Width = 70
        '
        'PrecioVentaSinIVA11
        '
        Me.PrecioVentaSinIVA11.DataPropertyName = "PrecioVentaSinIVA1"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        Me.PrecioVentaSinIVA11.DefaultCellStyle = DataGridViewCellStyle12
        Me.PrecioVentaSinIVA11.HeaderText = "P. Venta Sin IVA 2"
        Me.PrecioVentaSinIVA11.Name = "PrecioVentaSinIVA11"
        Me.PrecioVentaSinIVA11.Visible = False
        Me.PrecioVentaSinIVA11.Width = 70
        '
        'PrecioVentaConIVA11
        '
        Me.PrecioVentaConIVA11.DataPropertyName = "PrecioVentaConIVA1"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        Me.PrecioVentaConIVA11.DefaultCellStyle = DataGridViewCellStyle13
        Me.PrecioVentaConIVA11.HeaderText = "P. Venta Con IVA 2"
        Me.PrecioVentaConIVA11.Name = "PrecioVentaConIVA11"
        Me.PrecioVentaConIVA11.Visible = False
        Me.PrecioVentaConIVA11.Width = 70
        '
        'gStock
        '
        Me.gStock.DataPropertyName = "Stock"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.gStock.DefaultCellStyle = DataGridViewCellStyle14
        Me.gStock.HeaderText = "Stock"
        Me.gStock.Name = "gStock"
        Me.gStock.ReadOnly = True
        Me.gStock.Width = 65
        '
        'gNombreMarca
        '
        Me.gNombreMarca.DataPropertyName = "NombreMarca"
        Me.gNombreMarca.HeaderText = "Marca"
        Me.gNombreMarca.Name = "gNombreMarca"
        Me.gNombreMarca.ReadOnly = True
        Me.gNombreMarca.Width = 130
        '
        'gNombreRubro
        '
        Me.gNombreRubro.DataPropertyName = "NombreRubro"
        Me.gNombreRubro.HeaderText = "Rubro"
        Me.gNombreRubro.Name = "gNombreRubro"
        Me.gNombreRubro.ReadOnly = True
        Me.gNombreRubro.Width = 130
        '
        'gFechaActualizacion
        '
        Me.gFechaActualizacion.DataPropertyName = "FechaActualizacion"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.Format = "dd/MM/yyyy HH:mm"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.gFechaActualizacion.DefaultCellStyle = DataGridViewCellStyle15
        Me.gFechaActualizacion.HeaderText = "Actualizado"
        Me.gFechaActualizacion.Name = "gFechaActualizacion"
        Me.gFechaActualizacion.ReadOnly = True
        '
        'gIdMarca
        '
        Me.gIdMarca.DataPropertyName = "IdMarca"
        Me.gIdMarca.HeaderText = "IdMarca"
        Me.gIdMarca.Name = "gIdMarca"
        Me.gIdMarca.Visible = False
        '
        'gIdRubro
        '
        Me.gIdRubro.DataPropertyName = "IdRubro"
        Me.gIdRubro.HeaderText = "IdRubro"
        Me.gIdRubro.Name = "gIdRubro"
        Me.gIdRubro.Visible = False
        '
        'gStockInicial
        '
        Me.gStockInicial.DataPropertyName = "StockInicial"
        Me.gStockInicial.HeaderText = "StockInicial"
        Me.gStockInicial.Name = "gStockInicial"
        Me.gStockInicial.Visible = False
        '
        'gAlicuota
        '
        Me.gAlicuota.DataPropertyName = "Alicuota"
        Me.gAlicuota.HeaderText = "Alicuota"
        Me.gAlicuota.Name = "gAlicuota"
        Me.gAlicuota.Visible = False
        '
        'gCodigoDeBarras
        '
        Me.gCodigoDeBarras.DataPropertyName = "CodigoDeBarras"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gCodigoDeBarras.DefaultCellStyle = DataGridViewCellStyle16
        Me.gCodigoDeBarras.HeaderText = "Codigo De Barras"
        Me.gCodigoDeBarras.Name = "gCodigoDeBarras"
        Me.gCodigoDeBarras.ReadOnly = True
        '
        'ListaPrecio0
        '
        Me.ListaPrecio0.DataPropertyName = "ListaPrecio"
        Me.ListaPrecio0.HeaderText = "Lista Precio"
        Me.ListaPrecio0.Name = "ListaPrecio0"
        Me.ListaPrecio0.Visible = False
        Me.ListaPrecio0.Width = 40
        '
        'ListaPrecio10
        '
        Me.ListaPrecio10.DataPropertyName = "ListaPrecio1"
        Me.ListaPrecio10.HeaderText = "Lista Precio 2"
        Me.ListaPrecio10.Name = "ListaPrecio10"
        Me.ListaPrecio10.Visible = False
        Me.ListaPrecio10.Width = 40
        '
        'Lote2
        '
        Me.Lote2.DataPropertyName = "Lote"
        Me.Lote2.HeaderText = "Lote"
        Me.Lote2.Name = "Lote2"
        Me.Lote2.Visible = False
        '
        'gUnidHasta1
        '
        Me.gUnidHasta1.DataPropertyName = "UnidHasta1"
        Me.gUnidHasta1.HeaderText = "UnidHasta1"
        Me.gUnidHasta1.Name = "gUnidHasta1"
        Me.gUnidHasta1.Visible = False
        '
        'gUHPorc1
        '
        Me.gUHPorc1.DataPropertyName = "UHPorc1"
        Me.gUHPorc1.HeaderText = "UHPorc1"
        Me.gUHPorc1.Name = "gUHPorc1"
        Me.gUHPorc1.Visible = False
        '
        'gPrecioDesc
        '
        Me.gPrecioDesc.DataPropertyName = "PrecioDesc"
        Me.gPrecioDesc.HeaderText = "PrecioDesc"
        Me.gPrecioDesc.Name = "gPrecioDesc"
        Me.gPrecioDesc.Visible = False
        '
        'EmisionDeEtiquetasDePrecios
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 571)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnInsertar)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.grbConsultar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "EmisionDeEtiquetasDePrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Emisión de Etiquetas de Precios"
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents txtProducto As Eniac.Controles.TextBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents lblListaPrecios As Eniac.Controles.Label
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbFechaActualizado As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbStockPositivo As Eniac.Controles.CheckBox
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents dgvSeleccionados As Eniac.Controles.DataGridView
   Friend WithEvents txtCabecera As Eniac.Controles.TextBox
   Friend WithEvents lblFormato As System.Windows.Forms.Label
   Friend WithEvents cmbFormatos As Eniac.Controles.ComboBox
   Friend WithEvents cmbListasDePrecios2 As Eniac.Controles.ComboBox
   Friend WithEvents lblListasDePrecios2 As Eniac.Controles.Label
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents cmbRubro As Eniac.Win.ComboBoxRubro
   Friend WithEvents cmbMarca As Eniac.Win.ComboBoxMarcas
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
    Friend WithEvents gImprime As DataGridViewCheckBoxColumn
    Friend WithEvents gPrecioListaDePreciosSinIVA1 As DataGridViewTextBoxColumn
    Friend WithEvents gPrecioListaDePreciosSinIVA2 As DataGridViewTextBoxColumn
    Friend WithEvents gPrecioListaDePreciosConIVA As DataGridViewTextBoxColumn
    Friend WithEvents gPrecioListaDePreciosSinIVA As DataGridViewTextBoxColumn
    Friend WithEvents gIdSucursal As DataGridViewTextBoxColumn
    Friend WithEvents gNombreSucursal As DataGridViewTextBoxColumn
    Friend WithEvents gIdProducto As DataGridViewTextBoxColumn
    Friend WithEvents gNombreProducto As DataGridViewTextBoxColumn
    Friend WithEvents gPrecioCostoSinIVA As DataGridViewTextBoxColumn
    Friend WithEvents gPrecioCostoConIVA As DataGridViewTextBoxColumn
    Friend WithEvents gPrecioVentaSinIVA As DataGridViewTextBoxColumn
    Friend WithEvents gPrecioVentaConIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVentaSinIVA11 As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVentaConIVA11 As DataGridViewTextBoxColumn
    Friend WithEvents gStock As DataGridViewTextBoxColumn
    Friend WithEvents gNombreMarca As DataGridViewTextBoxColumn
    Friend WithEvents gNombreRubro As DataGridViewTextBoxColumn
    Friend WithEvents gFechaActualizacion As DataGridViewTextBoxColumn
    Friend WithEvents gIdMarca As DataGridViewTextBoxColumn
    Friend WithEvents gIdRubro As DataGridViewTextBoxColumn
    Friend WithEvents gStockInicial As DataGridViewTextBoxColumn
    Friend WithEvents gAlicuota As DataGridViewTextBoxColumn
    Friend WithEvents gCodigoDeBarras As DataGridViewTextBoxColumn
    Friend WithEvents ListaPrecio0 As DataGridViewTextBoxColumn
    Friend WithEvents ListaPrecio10 As DataGridViewTextBoxColumn
    Friend WithEvents Lote2 As DataGridViewTextBoxColumn
    Friend WithEvents gUnidHasta1 As DataGridViewTextBoxColumn
    Friend WithEvents gUHPorc1 As DataGridViewTextBoxColumn
    Friend WithEvents gPrecioDesc As DataGridViewTextBoxColumn
    Friend WithEvents Imprime As DataGridViewCheckBoxColumn
    Friend WithEvents PrecioListaDePreciosConIVA1 As DataGridViewTextBoxColumn
    Friend WithEvents PrecioListaDePreciosSinIVA1 As DataGridViewTextBoxColumn
    Friend WithEvents PrecioListaDePreciosSinIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioListaDePreciosConIVA As DataGridViewTextBoxColumn
    Friend WithEvents IdSucursal As DataGridViewTextBoxColumn
    Friend WithEvents NombreSucursal As DataGridViewTextBoxColumn
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
    Friend WithEvents NombreProducto As DataGridViewTextBoxColumn
    Friend WithEvents NombreCorto As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCostoSinIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCostoConIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVentaSinIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVentaConIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVentaConIVA1 As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVentaSinIVA1 As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents NombreMarca As DataGridViewTextBoxColumn
    Friend WithEvents NombreRubro As DataGridViewTextBoxColumn
    Friend WithEvents FechaActualizacion As DataGridViewTextBoxColumn
    Friend WithEvents IdMarca As DataGridViewTextBoxColumn
    Friend WithEvents IdRubro As DataGridViewTextBoxColumn
    Friend WithEvents StockInicial As DataGridViewTextBoxColumn
    Friend WithEvents Alicuota As DataGridViewTextBoxColumn
    Friend WithEvents CodigoDeBarras As DataGridViewTextBoxColumn
    Friend WithEvents ListaPrecio As DataGridViewTextBoxColumn
    Friend WithEvents ListaPrecio1 As DataGridViewTextBoxColumn
    Friend WithEvents Lote As DataGridViewTextBoxColumn
    Friend WithEvents UnidHasta1 As DataGridViewTextBoxColumn
    Friend WithEvents UHPorc1 As DataGridViewTextBoxColumn
    Friend WithEvents PrecioDesc As DataGridViewTextBoxColumn
End Class
