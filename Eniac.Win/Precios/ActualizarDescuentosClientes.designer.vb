<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizarDescuentosClientes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActualizarDescuentosClientes))
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.cboCompuestos = New Eniac.Controles.ComboBox()
      Me.lblCompuestos = New Eniac.Controles.Label()
      Me.lnkFiltroMultiplesRubros = New System.Windows.Forms.LinkLabel()
      Me.lnkFiltroMultiplesMarcas = New System.Windows.Forms.LinkLabel()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chbSubRubro = New Eniac.Controles.CheckBox()
      Me.cmbSubRubro = New Eniac.Controles.ComboBox()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.TbpFiltros = New System.Windows.Forms.TabPage()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.cmbEsOferta = New Eniac.Controles.ComboBox()
      Me.Label15 = New Eniac.Controles.Label()
      Me.chbProveedorHabitual = New Eniac.Controles.CheckBox()
      Me.lblCodigoProductoProveedor = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtCodigoProductoProveedor = New Eniac.Controles.TextBox()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.txtProducto = New Eniac.Controles.TextBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.btnDescuentoRecargoPorc1 = New Eniac.Controles.Button()
      Me.txtDescuentoRecargoPorc1 = New Eniac.Controles.TextBox()
      Me.lblDescuentoRecargoPorc1 = New Eniac.Controles.Label()
      Me.lblDescuentoRecargoPorc2 = New Eniac.Controles.Label()
      Me.txtDescuentoRecargoPorc2 = New Eniac.Controles.TextBox()
      Me.btnDescuentoRecargoPorc2 = New Eniac.Controles.Button()
      Me.dgvPrecios = New Eniac.Controles.DataGridView()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.tbcDetalle.SuspendLayout()
      Me.TbpFiltros.SuspendLayout()
      Me.grbCliente.SuspendLayout()
      CType(Me.dgvPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
      Me.imgIconos.ImageSize = New System.Drawing.Size(16, 16)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(934, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(855, 17)
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
      Me.cboCompuestos.Location = New System.Drawing.Point(728, 63)
      Me.cboCompuestos.Name = "cboCompuestos"
      Me.cboCompuestos.Size = New System.Drawing.Size(82, 21)
      Me.cboCompuestos.TabIndex = 8
      '
      'lblCompuestos
      '
      Me.lblCompuestos.AutoSize = True
      Me.lblCompuestos.Location = New System.Drawing.Point(657, 66)
      Me.lblCompuestos.Name = "lblCompuestos"
      Me.lblCompuestos.Size = New System.Drawing.Size(65, 13)
      Me.lblCompuestos.TabIndex = 7
      Me.lblCompuestos.Text = "Compuestos"
      '
      'lnkFiltroMultiplesRubros
      '
      Me.lnkFiltroMultiplesRubros.AutoSize = True
      Me.lnkFiltroMultiplesRubros.Location = New System.Drawing.Point(121, 71)
      Me.lnkFiltroMultiplesRubros.Name = "lnkFiltroMultiplesRubros"
      Me.lnkFiltroMultiplesRubros.Size = New System.Drawing.Size(90, 13)
      Me.lnkFiltroMultiplesRubros.TabIndex = 2
      Me.lnkFiltroMultiplesRubros.TabStop = True
      Me.lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
      '
      'lnkFiltroMultiplesMarcas
      '
      Me.lnkFiltroMultiplesMarcas.AutoSize = True
      Me.lnkFiltroMultiplesMarcas.Location = New System.Drawing.Point(13, 71)
      Me.lnkFiltroMultiplesMarcas.Name = "lnkFiltroMultiplesMarcas"
      Me.lnkFiltroMultiplesMarcas.Size = New System.Drawing.Size(91, 13)
      Me.lnkFiltroMultiplesMarcas.TabIndex = 1
      Me.lnkFiltroMultiplesMarcas.TabStop = True
      Me.lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
      '
      'bscProveedor
      '
      Me.bscProveedor.AutoSize = True
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
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
      Me.bscProveedor.Location = New System.Drawing.Point(187, 121)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(265, 23)
      Me.bscProveedor.TabIndex = 16
      Me.bscProveedor.Titulo = Nothing
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
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(90, 121)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 15
      Me.bscCodigoProveedor.Titulo = Nothing
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
      Me.chbProveedor.Location = New System.Drawing.Point(15, 124)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 14
      Me.chbProveedor.Text = "Pro&veedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
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
      Me.chbSubRubro.Location = New System.Drawing.Point(252, 67)
      Me.chbSubRubro.Name = "chbSubRubro"
      Me.chbSubRubro.Size = New System.Drawing.Size(65, 17)
      Me.chbSubRubro.TabIndex = 3
      Me.chbSubRubro.Text = "SubRub"
      Me.chbSubRubro.UseVisualStyleBackColor = True
      '
      'cmbSubRubro
      '
      Me.cmbSubRubro.BindearPropiedadControl = Nothing
      Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
      Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSubRubro.Enabled = False
      Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSubRubro.FormattingEnabled = True
      Me.cmbSubRubro.IsPK = False
      Me.cmbSubRubro.IsRequired = False
      Me.cmbSubRubro.Key = Nothing
      Me.cmbSubRubro.LabelAsoc = Nothing
      Me.cmbSubRubro.Location = New System.Drawing.Point(321, 66)
      Me.cmbSubRubro.Name = "cmbSubRubro"
      Me.cmbSubRubro.Size = New System.Drawing.Size(166, 21)
      Me.cmbSubRubro.TabIndex = 4
      '
      'btnBuscar
      '
      Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscar.Location = New System.Drawing.Point(728, 145)
      Me.btnBuscar.Name = "btnBuscar"
      Me.btnBuscar.Size = New System.Drawing.Size(89, 40)
      Me.btnBuscar.TabIndex = 29
      Me.btnBuscar.Text = "&Buscar"
      Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnBuscar.UseVisualStyleBackColor = True
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
      Me.chbProducto.Location = New System.Drawing.Point(15, 97)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 9
      Me.chbProducto.Text = "&Producto"
      Me.chbProducto.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbGrabar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(934, 29)
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
      Me.tbcDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcDetalle.Controls.Add(Me.TbpFiltros)
      Me.tbcDetalle.ItemSize = New System.Drawing.Size(42, 20)
      Me.tbcDetalle.Location = New System.Drawing.Point(11, 32)
      Me.tbcDetalle.Name = "tbcDetalle"
      Me.tbcDetalle.SelectedIndex = 0
      Me.tbcDetalle.Size = New System.Drawing.Size(916, 220)
      Me.tbcDetalle.TabIndex = 0
      Me.tbcDetalle.TabStop = False
      '
      'TbpFiltros
      '
      Me.TbpFiltros.BackColor = System.Drawing.SystemColors.Control
      Me.TbpFiltros.Controls.Add(Me.grbCliente)
      Me.TbpFiltros.Controls.Add(Me.cmbEsOferta)
      Me.TbpFiltros.Controls.Add(Me.Label15)
      Me.TbpFiltros.Controls.Add(Me.chbProveedorHabitual)
      Me.TbpFiltros.Controls.Add(Me.lblCodigoProductoProveedor)
      Me.TbpFiltros.Controls.Add(Me.lblCodigo)
      Me.TbpFiltros.Controls.Add(Me.txtCodigoProductoProveedor)
      Me.TbpFiltros.Controls.Add(Me.txtCodigo)
      Me.TbpFiltros.Controls.Add(Me.lblProducto)
      Me.TbpFiltros.Controls.Add(Me.txtProducto)
      Me.TbpFiltros.Controls.Add(Me.bscProducto2)
      Me.TbpFiltros.Controls.Add(Me.bscCodigoProducto2)
      Me.TbpFiltros.Controls.Add(Me.chbProducto)
      Me.TbpFiltros.Controls.Add(Me.cboCompuestos)
      Me.TbpFiltros.Controls.Add(Me.lblCompuestos)
      Me.TbpFiltros.Controls.Add(Me.lnkFiltroMultiplesRubros)
      Me.TbpFiltros.Controls.Add(Me.btnBuscar)
      Me.TbpFiltros.Controls.Add(Me.lnkFiltroMultiplesMarcas)
      Me.TbpFiltros.Controls.Add(Me.cmbSubRubro)
      Me.TbpFiltros.Controls.Add(Me.bscProveedor)
      Me.TbpFiltros.Controls.Add(Me.chbSubRubro)
      Me.TbpFiltros.Controls.Add(Me.bscCodigoProveedor)
      Me.TbpFiltros.Controls.Add(Me.chbProveedor)
      Me.TbpFiltros.Location = New System.Drawing.Point(4, 24)
      Me.TbpFiltros.Name = "TbpFiltros"
      Me.TbpFiltros.Padding = New System.Windows.Forms.Padding(3)
      Me.TbpFiltros.Size = New System.Drawing.Size(908, 192)
      Me.TbpFiltros.TabIndex = 0
      Me.TbpFiltros.Text = "Filtros"
      '
      'grbCliente
      '
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Location = New System.Drawing.Point(15, 1)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(420, 59)
      Me.grbCliente.TabIndex = 0
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Cliente"
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(108, 13)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(9, 13)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 0
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAncho = 136
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasAlineacion = Nothing
      Me.bscCliente.ColumnasAncho = Nothing
      Me.bscCliente.ColumnasFormato = Nothing
      Me.bscCliente.ColumnasOcultas = Nothing
      Me.bscCliente.ColumnasTitulos = Nothing
      Me.bscCliente.Datos = Nothing
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
      Me.bscCliente.Location = New System.Drawing.Point(109, 29)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 3
      Me.bscCliente.Titulo = Nothing
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 136
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasAlineacion = Nothing
      Me.bscCodigoCliente.ColumnasAncho = Nothing
      Me.bscCodigoCliente.ColumnasFormato = Nothing
      Me.bscCodigoCliente.ColumnasOcultas = Nothing
      Me.bscCodigoCliente.ColumnasTitulos = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(12, 29)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 1
      Me.bscCodigoCliente.Titulo = Nothing
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
      Me.cmbEsOferta.Location = New System.Drawing.Point(559, 65)
      Me.cmbEsOferta.Name = "cmbEsOferta"
      Me.cmbEsOferta.Size = New System.Drawing.Size(82, 21)
      Me.cmbEsOferta.TabIndex = 6
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(502, 71)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(51, 13)
      Me.Label15.TabIndex = 5
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
      Me.chbProveedorHabitual.Location = New System.Drawing.Point(459, 124)
      Me.chbProveedorHabitual.Name = "chbProveedorHabitual"
      Me.chbProveedorHabitual.Size = New System.Drawing.Size(65, 17)
      Me.chbProveedorHabitual.TabIndex = 17
      Me.chbProveedorHabitual.Text = "Habitual"
      Me.chbProveedorHabitual.UseVisualStyleBackColor = True
      '
      'lblCodigoProductoProveedor
      '
      Me.lblCodigoProductoProveedor.AutoSize = True
      Me.lblCodigoProductoProveedor.Location = New System.Drawing.Point(401, 149)
      Me.lblCodigoProductoProveedor.Name = "lblCodigoProductoProveedor"
      Me.lblCodigoProductoProveedor.Size = New System.Drawing.Size(109, 13)
      Me.lblCodigoProductoProveedor.TabIndex = 25
      Me.lblCodigoProductoProveedor.Text = "Código del Proveedor"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(13, 150)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 21
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
      Me.txtCodigoProductoProveedor.Location = New System.Drawing.Point(404, 165)
      Me.txtCodigoProductoProveedor.MaxLength = 15
      Me.txtCodigoProductoProveedor.Name = "txtCodigoProductoProveedor"
      Me.txtCodigoProductoProveedor.Size = New System.Drawing.Size(115, 20)
      Me.txtCodigoProductoProveedor.TabIndex = 26
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
      Me.txtCodigo.Location = New System.Drawing.Point(16, 166)
      Me.txtCodigo.MaxLength = 15
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(115, 20)
      Me.txtCodigo.TabIndex = 22
      '
      'lblProducto
      '
      Me.lblProducto.AutoSize = True
      Me.lblProducto.Location = New System.Drawing.Point(135, 150)
      Me.lblProducto.Name = "lblProducto"
      Me.lblProducto.Size = New System.Drawing.Size(50, 13)
      Me.lblProducto.TabIndex = 23
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
      Me.txtProducto.Location = New System.Drawing.Point(138, 166)
      Me.txtProducto.Name = "txtProducto"
      Me.txtProducto.Size = New System.Drawing.Size(260, 20)
      Me.txtProducto.TabIndex = 24
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ColumnasCondiciones = CType(resources.GetObject("bscProducto2.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscProducto2.ColumnasVisibles = CType(resources.GetObject("bscProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
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
      Me.bscProducto2.Location = New System.Drawing.Point(242, 97)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(279, 20)
      Me.bscProducto2.TabIndex = 11
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ColumnasCondiciones = CType(resources.GetObject("bscCodigoProducto2.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoProducto2.ColumnasVisibles = CType(resources.GetObject("bscCodigoProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
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
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(88, 96)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(150, 20)
      Me.bscCodigoProducto2.TabIndex = 10
      '
      'btnTodos
      '
      Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnTodos.Location = New System.Drawing.Point(133, 254)
      Me.btnTodos.Name = "btnTodos"
      Me.btnTodos.Size = New System.Drawing.Size(75, 23)
      Me.btnTodos.TabIndex = 3
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
      Me.cmbTodos.Location = New System.Drawing.Point(11, 255)
      Me.cmbTodos.Name = "cmbTodos"
      Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
      Me.cmbTodos.TabIndex = 2
      '
      'btnDescuentoRecargoPorc1
      '
      Me.btnDescuentoRecargoPorc1.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.btnDescuentoRecargoPorc1.Location = New System.Drawing.Point(317, 252)
      Me.btnDescuentoRecargoPorc1.Name = "btnDescuentoRecargoPorc1"
      Me.btnDescuentoRecargoPorc1.Size = New System.Drawing.Size(22, 22)
      Me.btnDescuentoRecargoPorc1.TabIndex = 6
      Me.btnDescuentoRecargoPorc1.Tag = "DescuentoRecargoPorc11"
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
      Me.txtDescuentoRecargoPorc1.Location = New System.Drawing.Point(267, 253)
      Me.txtDescuentoRecargoPorc1.Name = "txtDescuentoRecargoPorc1"
      Me.txtDescuentoRecargoPorc1.Size = New System.Drawing.Size(50, 20)
      Me.txtDescuentoRecargoPorc1.TabIndex = 5
      Me.txtDescuentoRecargoPorc1.Text = "0.00"
      Me.txtDescuentoRecargoPorc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDescuentoRecargoPorc1
      '
      Me.lblDescuentoRecargoPorc1.AutoSize = True
      Me.lblDescuentoRecargoPorc1.Location = New System.Drawing.Point(219, 257)
      Me.lblDescuentoRecargoPorc1.Name = "lblDescuentoRecargoPorc1"
      Me.lblDescuentoRecargoPorc1.Size = New System.Drawing.Size(48, 13)
      Me.lblDescuentoRecargoPorc1.TabIndex = 4
      Me.lblDescuentoRecargoPorc1.Text = "% D/R 1"
      '
      'lblDescuentoRecargoPorc2
      '
      Me.lblDescuentoRecargoPorc2.AutoSize = True
      Me.lblDescuentoRecargoPorc2.Location = New System.Drawing.Point(339, 257)
      Me.lblDescuentoRecargoPorc2.Name = "lblDescuentoRecargoPorc2"
      Me.lblDescuentoRecargoPorc2.Size = New System.Drawing.Size(48, 13)
      Me.lblDescuentoRecargoPorc2.TabIndex = 7
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
      Me.txtDescuentoRecargoPorc2.Location = New System.Drawing.Point(387, 253)
      Me.txtDescuentoRecargoPorc2.Name = "txtDescuentoRecargoPorc2"
      Me.txtDescuentoRecargoPorc2.Size = New System.Drawing.Size(50, 20)
      Me.txtDescuentoRecargoPorc2.TabIndex = 10
      Me.txtDescuentoRecargoPorc2.Text = "0.00"
      Me.txtDescuentoRecargoPorc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnDescuentoRecargoPorc2
      '
      Me.btnDescuentoRecargoPorc2.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.btnDescuentoRecargoPorc2.Location = New System.Drawing.Point(437, 252)
      Me.btnDescuentoRecargoPorc2.Name = "btnDescuentoRecargoPorc2"
      Me.btnDescuentoRecargoPorc2.Size = New System.Drawing.Size(22, 22)
      Me.btnDescuentoRecargoPorc2.TabIndex = 11
      Me.btnDescuentoRecargoPorc2.Tag = "DescuentoRecargoPorc21"
      Me.btnDescuentoRecargoPorc2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnDescuentoRecargoPorc2.UseVisualStyleBackColor = True
      '
      'dgvPrecios
      '
      Me.dgvPrecios.AllowUserToAddRows = False
      Me.dgvPrecios.AllowUserToDeleteRows = False
      Me.dgvPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvPrecios.ColumnHeadersHeight = 46
      Me.dgvPrecios.Location = New System.Drawing.Point(11, 277)
      Me.dgvPrecios.Name = "dgvPrecios"
      Me.dgvPrecios.RowHeadersVisible = False
      Me.dgvPrecios.RowHeadersWidth = 10
      Me.dgvPrecios.Size = New System.Drawing.Size(911, 259)
      Me.dgvPrecios.TabIndex = 1
      '
      'ActualizarDescuentosClientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(934, 561)
      Me.Controls.Add(Me.btnDescuentoRecargoPorc2)
      Me.Controls.Add(Me.txtDescuentoRecargoPorc2)
      Me.Controls.Add(Me.btnDescuentoRecargoPorc1)
      Me.Controls.Add(Me.lblDescuentoRecargoPorc2)
      Me.Controls.Add(Me.txtDescuentoRecargoPorc1)
      Me.Controls.Add(Me.lblDescuentoRecargoPorc1)
      Me.Controls.Add(Me.btnTodos)
      Me.Controls.Add(Me.cmbTodos)
      Me.Controls.Add(Me.tbcDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.dgvPrecios)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ActualizarDescuentosClientes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Actualización de descuentos de clientes"
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.tbcDetalle.ResumeLayout(False)
      Me.TbpFiltros.ResumeLayout(False)
      Me.TbpFiltros.PerformLayout()
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      CType(Me.dgvPrecios, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lnkFiltroMultiplesRubros As System.Windows.Forms.LinkLabel
   Friend WithEvents lnkFiltroMultiplesMarcas As System.Windows.Forms.LinkLabel
   Friend WithEvents cboCompuestos As Eniac.Controles.ComboBox
   Friend WithEvents lblCompuestos As Eniac.Controles.Label
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents TbpFiltros As System.Windows.Forms.TabPage
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents txtProducto As Eniac.Controles.TextBox
   Friend WithEvents chbProveedorHabitual As Eniac.Controles.CheckBox
   Friend WithEvents cmbEsOferta As Eniac.Controles.ComboBox
   Friend WithEvents Label15 As Eniac.Controles.Label
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Friend WithEvents lblCodigoProductoProveedor As Eniac.Controles.Label
   Friend WithEvents txtCodigoProductoProveedor As Eniac.Controles.TextBox
   Friend WithEvents btnDescuentoRecargoPorc1 As Eniac.Controles.Button
   Friend WithEvents txtDescuentoRecargoPorc1 As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargoPorc1 As Eniac.Controles.Label
   Friend WithEvents lblDescuentoRecargoPorc2 As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargoPorc2 As Eniac.Controles.TextBox
   Friend WithEvents btnDescuentoRecargoPorc2 As Eniac.Controles.Button
   Friend WithEvents dgvPrecios As Eniac.Controles.DataGridView
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
End Class
