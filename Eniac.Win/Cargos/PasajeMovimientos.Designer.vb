<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasajeMovimientos
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasajeMovimientos))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPasaje = New System.Windows.Forms.ToolStripButton()
      Me.toolExcluir = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExcluirDePasaje = New System.Windows.Forms.ToolStripButton()
      Me.tsbIncluirEnPasaje = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.chbFechaDesde = New Eniac.Controles.CheckBox()
      Me.cmbExcluirEnPasaje = New Eniac.Controles.ComboBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.cmbRubro = New Eniac.Controles.ComboBox()
      Me.chbRubro = New Eniac.Controles.CheckBox()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.txtIva270 = New Eniac.Controles.TextBox()
      Me.txtNeto = New Eniac.Controles.TextBox()
      Me.txtNetoNoGravado = New Eniac.Controles.TextBox()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.lblTotales = New Eniac.Controles.Label()
      Me.txtIva210 = New Eniac.Controles.TextBox()
      Me.txtIva105 = New Eniac.Controles.TextBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.txtImporteTotalSaldo = New Eniac.Controles.TextBox()
      Me.txtMontoAplicar = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Pasaje = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PorcentajeIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.MontoSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.MontoAplicar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CoeficienteValores = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ExcluirDePasaje_SN = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ExcluirDePasaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbPasaje, Me.toolExcluir, Me.tsbExcluirDePasaje, Me.tsbIncluirEnPasaje, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(976, 31)
      Me.tstBarra.TabIndex = 7
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(106, 28)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 31)
      '
      'tsbPasaje
      '
      Me.tsbPasaje.Enabled = False
      Me.tsbPasaje.ForeColor = System.Drawing.Color.ForestGreen
      Me.tsbPasaje.Image = Global.Eniac.Win.My.Resources.Resources.mail_next_32
      Me.tsbPasaje.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPasaje.Name = "tsbPasaje"
      Me.tsbPasaje.Size = New System.Drawing.Size(142, 28)
      Me.tsbPasaje.Text = "Pasaje a Liquidación"
      Me.tsbPasaje.ToolTipText = "Cerrar el formulario"
      '
      'toolExcluir
      '
      Me.toolExcluir.Name = "toolExcluir"
      Me.toolExcluir.Size = New System.Drawing.Size(6, 31)
      '
      'tsbExcluirDePasaje
      '
      Me.tsbExcluirDePasaje.Image = Global.Eniac.Win.My.Resources.Resources.delete2
      Me.tsbExcluirDePasaje.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbExcluirDePasaje.Name = "tsbExcluirDePasaje"
      Me.tsbExcluirDePasaje.Size = New System.Drawing.Size(70, 28)
      Me.tsbExcluirDePasaje.Text = "Excluir"
      Me.tsbExcluirDePasaje.Visible = False
      '
      'tsbIncluirEnPasaje
      '
      Me.tsbIncluirEnPasaje.Image = Global.Eniac.Win.My.Resources.Resources.document_check
      Me.tsbIncluirEnPasaje.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbIncluirEnPasaje.Name = "tsbIncluirEnPasaje"
      Me.tsbIncluirEnPasaje.Size = New System.Drawing.Size(68, 28)
      Me.tsbIncluirEnPasaje.Text = "Incluir"
      Me.tsbIncluirEnPasaje.Visible = False
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(67, 28)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.chbFechaDesde)
      Me.grbFiltros.Controls.Add(Me.cmbExcluirEnPasaje)
      Me.grbFiltros.Controls.Add(Me.Label2)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.bscProveedor)
      Me.grbFiltros.Controls.Add(Me.lblCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.cmbRubro)
      Me.grbFiltros.Controls.Add(Me.chbRubro)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbProveedor)
      Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Location = New System.Drawing.Point(13, 31)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(952, 107)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblHasta
      Me.dtpDesde.Location = New System.Drawing.Point(122, 19)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(98, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(226, 22)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'chbFechaDesde
      '
      Me.chbFechaDesde.AutoSize = True
      Me.chbFechaDesde.BindearPropiedadControl = Nothing
      Me.chbFechaDesde.BindearPropiedadEntidad = Nothing
      Me.chbFechaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaDesde.IsPK = False
      Me.chbFechaDesde.IsRequired = False
      Me.chbFechaDesde.Key = Nothing
      Me.chbFechaDesde.LabelAsoc = Nothing
      Me.chbFechaDesde.Location = New System.Drawing.Point(26, 21)
      Me.chbFechaDesde.Name = "chbFechaDesde"
      Me.chbFechaDesde.Size = New System.Drawing.Size(90, 17)
      Me.chbFechaDesde.TabIndex = 0
      Me.chbFechaDesde.Text = "Fecha Desde"
      Me.chbFechaDesde.UseVisualStyleBackColor = True
      '
      'cmbExcluirEnPasaje
      '
      Me.cmbExcluirEnPasaje.BindearPropiedadControl = Nothing
      Me.cmbExcluirEnPasaje.BindearPropiedadEntidad = Nothing
      Me.cmbExcluirEnPasaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbExcluirEnPasaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbExcluirEnPasaje.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbExcluirEnPasaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbExcluirEnPasaje.FormattingEnabled = True
      Me.cmbExcluirEnPasaje.IsPK = False
      Me.cmbExcluirEnPasaje.IsRequired = False
      Me.cmbExcluirEnPasaje.ItemHeight = 13
      Me.cmbExcluirEnPasaje.Key = Nothing
      Me.cmbExcluirEnPasaje.LabelAsoc = Nothing
      Me.cmbExcluirEnPasaje.Location = New System.Drawing.Point(691, 65)
      Me.cmbExcluirEnPasaje.Name = "cmbExcluirEnPasaje"
      Me.cmbExcluirEnPasaje.Size = New System.Drawing.Size(113, 21)
      Me.cmbExcluirEnPasaje.TabIndex = 15
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(600, 68)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(88, 13)
      Me.Label2.TabIndex = 14
      Me.Label2.Text = "Excluir en Pasaje"
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
      Me.bscCodigoProveedor.IsNumber = True
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(106, 66)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 11
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.LabelAsoc = Nothing
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(103, 50)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 10
      Me.lblCodigoProveedor.Text = "Código"
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
      Me.bscProveedor.LabelAsoc = Me.lblNombre
      Me.bscProveedor.Location = New System.Drawing.Point(203, 66)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
      Me.bscProveedor.TabIndex = 13
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(200, 50)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 12
      Me.lblNombre.Text = "Nombre"
      '
      'cmbRubro
      '
      Me.cmbRubro.BindearPropiedadControl = Nothing
      Me.cmbRubro.BindearPropiedadEntidad = Nothing
      Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRubro.Enabled = False
      Me.cmbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRubro.FormattingEnabled = True
      Me.cmbRubro.IsPK = False
      Me.cmbRubro.IsRequired = False
      Me.cmbRubro.ItemHeight = 13
      Me.cmbRubro.Key = Nothing
      Me.cmbRubro.LabelAsoc = Nothing
      Me.cmbRubro.Location = New System.Drawing.Point(736, 19)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(157, 21)
      Me.cmbRubro.TabIndex = 8
      '
      'chbRubro
      '
      Me.chbRubro.AutoSize = True
      Me.chbRubro.BindearPropiedadControl = Nothing
      Me.chbRubro.BindearPropiedadEntidad = Nothing
      Me.chbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRubro.IsPK = False
      Me.chbRubro.IsRequired = False
      Me.chbRubro.Key = Nothing
      Me.chbRubro.LabelAsoc = Nothing
      Me.chbRubro.Location = New System.Drawing.Point(675, 21)
      Me.chbRubro.Name = "chbRubro"
      Me.chbRubro.Size = New System.Drawing.Size(55, 17)
      Me.chbRubro.TabIndex = 7
      Me.chbRubro.Text = "Rubro"
      Me.chbRubro.UseVisualStyleBackColor = True
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
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(503, 19)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(157, 21)
      Me.cmbTiposComprobantes.TabIndex = 6
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(837, 50)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 16
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.chbProveedor.Location = New System.Drawing.Point(26, 69)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 9
      Me.chbProveedor.Text = "Proveedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
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
      Me.chbTipoComprobante.Location = New System.Drawing.Point(384, 21)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
      Me.chbTipoComprobante.TabIndex = 5
      Me.chbTipoComprobante.Text = "Tipo Comprobante"
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
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
      Me.dtpHasta.Location = New System.Drawing.Point(267, 19)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(98, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'txtIva270
      '
      Me.txtIva270.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtIva270.BindearPropiedadControl = Nothing
      Me.txtIva270.BindearPropiedadEntidad = Nothing
      Me.txtIva270.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIva270.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIva270.Formato = "##0.00"
      Me.txtIva270.IsDecimal = True
      Me.txtIva270.IsNumber = True
      Me.txtIva270.IsPK = False
      Me.txtIva270.IsRequired = False
      Me.txtIva270.Key = ""
      Me.txtIva270.LabelAsoc = Nothing
      Me.txtIva270.Location = New System.Drawing.Point(1047, 514)
      Me.txtIva270.Name = "txtIva270"
      Me.txtIva270.ReadOnly = True
      Me.txtIva270.Size = New System.Drawing.Size(55, 20)
      Me.txtIva270.TabIndex = 41
      Me.txtIva270.Text = "0.00"
      Me.txtIva270.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNeto
      '
      Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNeto.BindearPropiedadControl = Nothing
      Me.txtNeto.BindearPropiedadEntidad = Nothing
      Me.txtNeto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNeto.Formato = "##0.00"
      Me.txtNeto.IsDecimal = True
      Me.txtNeto.IsNumber = True
      Me.txtNeto.IsPK = False
      Me.txtNeto.IsRequired = False
      Me.txtNeto.Key = ""
      Me.txtNeto.LabelAsoc = Nothing
      Me.txtNeto.Location = New System.Drawing.Point(867, 514)
      Me.txtNeto.Name = "txtNeto"
      Me.txtNeto.ReadOnly = True
      Me.txtNeto.Size = New System.Drawing.Size(70, 20)
      Me.txtNeto.TabIndex = 40
      Me.txtNeto.Text = "0.00"
      Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNetoNoGravado
      '
      Me.txtNetoNoGravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNetoNoGravado.BindearPropiedadControl = Nothing
      Me.txtNetoNoGravado.BindearPropiedadEntidad = Nothing
      Me.txtNetoNoGravado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNetoNoGravado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNetoNoGravado.Formato = "##0.00"
      Me.txtNetoNoGravado.IsDecimal = True
      Me.txtNetoNoGravado.IsNumber = True
      Me.txtNetoNoGravado.IsPK = False
      Me.txtNetoNoGravado.IsRequired = False
      Me.txtNetoNoGravado.Key = ""
      Me.txtNetoNoGravado.LabelAsoc = Nothing
      Me.txtNetoNoGravado.Location = New System.Drawing.Point(797, 514)
      Me.txtNetoNoGravado.Name = "txtNetoNoGravado"
      Me.txtNetoNoGravado.ReadOnly = True
      Me.txtNetoNoGravado.Size = New System.Drawing.Size(70, 20)
      Me.txtNetoNoGravado.TabIndex = 39
      Me.txtNetoNoGravado.Text = "0.00"
      Me.txtNetoNoGravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotal
      '
      Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotal.BindearPropiedadControl = Nothing
      Me.txtTotal.BindearPropiedadEntidad = Nothing
      Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotal.Formato = ""
      Me.txtTotal.IsDecimal = False
      Me.txtTotal.IsNumber = False
      Me.txtTotal.IsPK = False
      Me.txtTotal.IsRequired = False
      Me.txtTotal.Key = ""
      Me.txtTotal.LabelAsoc = Nothing
      Me.txtTotal.Location = New System.Drawing.Point(1102, 514)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.txtTotal.Size = New System.Drawing.Size(75, 20)
      Me.txtTotal.TabIndex = 38
      Me.txtTotal.Text = "0.00"
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotales
      '
      Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotales.AutoSize = True
      Me.lblTotales.LabelAsoc = Nothing
      Me.lblTotales.Location = New System.Drawing.Point(747, 517)
      Me.lblTotales.Name = "lblTotales"
      Me.lblTotales.Size = New System.Drawing.Size(45, 13)
      Me.lblTotales.TabIndex = 37
      Me.lblTotales.Text = "Totales:"
      '
      'txtIva210
      '
      Me.txtIva210.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtIva210.BindearPropiedadControl = Nothing
      Me.txtIva210.BindearPropiedadEntidad = Nothing
      Me.txtIva210.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIva210.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIva210.Formato = "##0.00"
      Me.txtIva210.IsDecimal = True
      Me.txtIva210.IsNumber = True
      Me.txtIva210.IsPK = False
      Me.txtIva210.IsRequired = False
      Me.txtIva210.Key = ""
      Me.txtIva210.LabelAsoc = Nothing
      Me.txtIva210.Location = New System.Drawing.Point(937, 514)
      Me.txtIva210.Name = "txtIva210"
      Me.txtIva210.ReadOnly = True
      Me.txtIva210.Size = New System.Drawing.Size(55, 20)
      Me.txtIva210.TabIndex = 36
      Me.txtIva210.Text = "0.00"
      Me.txtIva210.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtIva105
      '
      Me.txtIva105.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtIva105.BindearPropiedadControl = Nothing
      Me.txtIva105.BindearPropiedadEntidad = Nothing
      Me.txtIva105.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIva105.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIva105.Formato = "##0.00"
      Me.txtIva105.IsDecimal = True
      Me.txtIva105.IsNumber = True
      Me.txtIva105.IsPK = False
      Me.txtIva105.IsRequired = False
      Me.txtIva105.Key = ""
      Me.txtIva105.LabelAsoc = Nothing
      Me.txtIva105.Location = New System.Drawing.Point(992, 514)
      Me.txtIva105.Name = "txtIva105"
      Me.txtIva105.ReadOnly = True
      Me.txtIva105.Size = New System.Drawing.Size(55, 20)
      Me.txtIva105.TabIndex = 35
      Me.txtIva105.Text = "0.00"
      Me.txtIva105.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 439)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(976, 22)
      Me.stsStado.TabIndex = 6
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(897, 17)
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
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      '
      'txtImporteTotalSaldo
      '
      Me.txtImporteTotalSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtImporteTotalSaldo.BindearPropiedadControl = Nothing
      Me.txtImporteTotalSaldo.BindearPropiedadEntidad = Nothing
      Me.txtImporteTotalSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporteTotalSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporteTotalSaldo.Formato = "##0.00"
      Me.txtImporteTotalSaldo.IsDecimal = True
      Me.txtImporteTotalSaldo.IsNumber = True
      Me.txtImporteTotalSaldo.IsPK = False
      Me.txtImporteTotalSaldo.IsRequired = False
      Me.txtImporteTotalSaldo.Key = ""
      Me.txtImporteTotalSaldo.LabelAsoc = Nothing
      Me.txtImporteTotalSaldo.Location = New System.Drawing.Point(819, 411)
      Me.txtImporteTotalSaldo.Name = "txtImporteTotalSaldo"
      Me.txtImporteTotalSaldo.ReadOnly = True
      Me.txtImporteTotalSaldo.Size = New System.Drawing.Size(75, 20)
      Me.txtImporteTotalSaldo.TabIndex = 4
      Me.txtImporteTotalSaldo.Text = "0.00"
      Me.txtImporteTotalSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtMontoAplicar
      '
      Me.txtMontoAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtMontoAplicar.BindearPropiedadControl = Nothing
      Me.txtMontoAplicar.BindearPropiedadEntidad = Nothing
      Me.txtMontoAplicar.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMontoAplicar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMontoAplicar.Formato = ""
      Me.txtMontoAplicar.IsDecimal = False
      Me.txtMontoAplicar.IsNumber = False
      Me.txtMontoAplicar.IsPK = False
      Me.txtMontoAplicar.IsRequired = False
      Me.txtMontoAplicar.Key = ""
      Me.txtMontoAplicar.LabelAsoc = Nothing
      Me.txtMontoAplicar.Location = New System.Drawing.Point(894, 411)
      Me.txtMontoAplicar.Name = "txtMontoAplicar"
      Me.txtMontoAplicar.ReadOnly = True
      Me.txtMontoAplicar.Size = New System.Drawing.Size(75, 20)
      Me.txtMontoAplicar.TabIndex = 5
      Me.txtMontoAplicar.Text = "0.00"
      Me.txtMontoAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(762, 414)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(45, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Totales:"
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pasaje, Me.IdSucursal, Me.IdTipoComprobante, Me.NombreTipoComprobante, Me.Letra, Me.CentroEmisor, Me.NroComprobante, Me.Fecha, Me.NombreProveedor, Me.IdConcepto, Me.Concepto, Me.IdProveedor, Me.Precio, Me.DescuentoRecargo, Me.ImporteTotal, Me.PorcentajeIVA, Me.IVA, Me.Importe, Me.MontoSaldo, Me.MontoAplicar, Me.Orden, Me.Sucursal, Me.CoeficienteValores, Me.ExcluirDePasaje_SN, Me.ExcluirDePasaje})
      DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle15
      Me.dgvDetalle.Location = New System.Drawing.Point(13, 174)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Tomato
      DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(956, 231)
      Me.dgvDetalle.TabIndex = 1
      '
      'Pasaje
      '
      Me.Pasaje.DataPropertyName = "PasajeMovimientos"
      Me.Pasaje.HeaderText = "Pasaje"
      Me.Pasaje.Name = "Pasaje"
      Me.Pasaje.Width = 45
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.Visible = False
      '
      'IdTipoComprobante
      '
      Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.IdTipoComprobante.HeaderText = "Comprobante"
      Me.IdTipoComprobante.Name = "IdTipoComprobante"
      Me.IdTipoComprobante.Visible = False
      Me.IdTipoComprobante.Width = 90
      '
      'NombreTipoComprobante
      '
      Me.NombreTipoComprobante.DataPropertyName = "NombreTipoComprobante"
      Me.NombreTipoComprobante.HeaderText = "Comprobante"
      Me.NombreTipoComprobante.Name = "NombreTipoComprobante"
      Me.NombreTipoComprobante.ReadOnly = True
      Me.NombreTipoComprobante.Width = 75
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
      Me.Letra.HeaderText = "Letra"
      Me.Letra.Name = "Letra"
      Me.Letra.ReadOnly = True
      Me.Letra.Width = 35
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
      Me.CentroEmisor.HeaderText = "Emisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.ReadOnly = True
      Me.CentroEmisor.Width = 40
      '
      'NroComprobante
      '
      Me.NroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroComprobante.DefaultCellStyle = DataGridViewCellStyle4
      Me.NroComprobante.HeaderText = "Numero"
      Me.NroComprobante.Name = "NroComprobante"
      Me.NroComprobante.ReadOnly = True
      Me.NroComprobante.Width = 60
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle5.Format = "d"
      DataGridViewCellStyle5.NullValue = Nothing
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle5
      Me.Fecha.HeaderText = "Fecha"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.ReadOnly = True
      Me.Fecha.Width = 70
      '
      'NombreProveedor
      '
      Me.NombreProveedor.DataPropertyName = "NombreProveedor"
      Me.NombreProveedor.HeaderText = "Proveedor"
      Me.NombreProveedor.Name = "NombreProveedor"
      Me.NombreProveedor.ReadOnly = True
      Me.NombreProveedor.Width = 170
      '
      'IdConcepto
      '
      Me.IdConcepto.DataPropertyName = "IdConcepto"
      Me.IdConcepto.HeaderText = "IdConcepto"
      Me.IdConcepto.Name = "IdConcepto"
      Me.IdConcepto.Visible = False
      '
      'Concepto
      '
      Me.Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Concepto.DataPropertyName = "NombreConcepto"
      Me.Concepto.HeaderText = "Concepto"
      Me.Concepto.Name = "Concepto"
      Me.Concepto.ReadOnly = True
      '
      'IdProveedor
      '
      Me.IdProveedor.DataPropertyName = "IdProveedor"
      Me.IdProveedor.HeaderText = "IdProveedor"
      Me.IdProveedor.Name = "IdProveedor"
      Me.IdProveedor.Visible = False
      Me.IdProveedor.Width = 80
      '
      'Precio
      '
      Me.Precio.DataPropertyName = "Precio"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "N2"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.Precio.DefaultCellStyle = DataGridViewCellStyle6
      Me.Precio.HeaderText = "Precio"
      Me.Precio.Name = "Precio"
      Me.Precio.ReadOnly = True
      Me.Precio.Visible = False
      Me.Precio.Width = 75
      '
      'DescuentoRecargo
      '
      Me.DescuentoRecargo.DataPropertyName = "DescuentoRecargo"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      Me.DescuentoRecargo.DefaultCellStyle = DataGridViewCellStyle7
      Me.DescuentoRecargo.HeaderText = "Desc. / Rec."
      Me.DescuentoRecargo.Name = "DescuentoRecargo"
      Me.DescuentoRecargo.ReadOnly = True
      Me.DescuentoRecargo.Visible = False
      Me.DescuentoRecargo.Width = 40
      '
      'ImporteTotal
      '
      Me.ImporteTotal.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle8
      Me.ImporteTotal.HeaderText = "Importe Total"
      Me.ImporteTotal.Name = "ImporteTotal"
      Me.ImporteTotal.ReadOnly = True
      Me.ImporteTotal.Visible = False
      Me.ImporteTotal.Width = 75
      '
      'PorcentajeIVA
      '
      Me.PorcentajeIVA.DataPropertyName = "PorcentajeIVA"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.PorcentajeIVA.DefaultCellStyle = DataGridViewCellStyle9
      Me.PorcentajeIVA.HeaderText = "% IVA"
      Me.PorcentajeIVA.Name = "PorcentajeIVA"
      Me.PorcentajeIVA.ReadOnly = True
      Me.PorcentajeIVA.Visible = False
      Me.PorcentajeIVA.Width = 40
      '
      'IVA
      '
      Me.IVA.DataPropertyName = "IVA"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle10.Format = "N2"
      DataGridViewCellStyle10.NullValue = Nothing
      Me.IVA.DefaultCellStyle = DataGridViewCellStyle10
      Me.IVA.HeaderText = "IVA"
      Me.IVA.Name = "IVA"
      Me.IVA.ReadOnly = True
      Me.IVA.Visible = False
      Me.IVA.Width = 60
      '
      'Importe
      '
      Me.Importe.DataPropertyName = "Importe"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle11.Format = "N2"
      DataGridViewCellStyle11.NullValue = Nothing
      Me.Importe.DefaultCellStyle = DataGridViewCellStyle11
      Me.Importe.HeaderText = "Importe"
      Me.Importe.Name = "Importe"
      Me.Importe.ReadOnly = True
      Me.Importe.Width = 75
      '
      'MontoSaldo
      '
      Me.MontoSaldo.DataPropertyName = "MontoSaldo"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle12.Format = "N2"
      DataGridViewCellStyle12.NullValue = Nothing
      Me.MontoSaldo.DefaultCellStyle = DataGridViewCellStyle12
      Me.MontoSaldo.HeaderText = "Saldo"
      Me.MontoSaldo.Name = "MontoSaldo"
      Me.MontoSaldo.ReadOnly = True
      Me.MontoSaldo.Width = 75
      '
      'MontoAplicar
      '
      Me.MontoAplicar.DataPropertyName = "MontoAplicar"
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle13.BackColor = System.Drawing.Color.Tomato
      DataGridViewCellStyle13.Format = "N2"
      Me.MontoAplicar.DefaultCellStyle = DataGridViewCellStyle13
      Me.MontoAplicar.HeaderText = "Monto a Aplicar"
      Me.MontoAplicar.Name = "MontoAplicar"
      Me.MontoAplicar.Width = 75
      '
      'Orden
      '
      Me.Orden.DataPropertyName = "Orden"
      Me.Orden.HeaderText = "Orden"
      Me.Orden.Name = "Orden"
      Me.Orden.Visible = False
      '
      'Sucursal
      '
      Me.Sucursal.DataPropertyName = "IdSucursal"
      Me.Sucursal.HeaderText = "Sucursal"
      Me.Sucursal.Name = "Sucursal"
      Me.Sucursal.Visible = False
      '
      'CoeficienteValores
      '
      Me.CoeficienteValores.DataPropertyName = "CoeficienteValores"
      Me.CoeficienteValores.HeaderText = "Coeficiente Valores"
      Me.CoeficienteValores.Name = "CoeficienteValores"
      Me.CoeficienteValores.Visible = False
      '
      'ExcluirDePasaje_SN
      '
      Me.ExcluirDePasaje_SN.DataPropertyName = "ExcluirDePasaje_SN"
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.ExcluirDePasaje_SN.DefaultCellStyle = DataGridViewCellStyle14
      Me.ExcluirDePasaje_SN.HeaderText = "Excluir"
      Me.ExcluirDePasaje_SN.Name = "ExcluirDePasaje_SN"
      Me.ExcluirDePasaje_SN.Width = 60
      '
      'ExcluirDePasaje
      '
      Me.ExcluirDePasaje.DataPropertyName = "ExcluirDePasaje"
      Me.ExcluirDePasaje.HeaderText = "ExcluirDePasaje"
      Me.ExcluirDePasaje.Name = "ExcluirDePasaje"
      Me.ExcluirDePasaje.Visible = False
      Me.ExcluirDePasaje.Width = 60
      '
      'chbTodos
      '
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(13, 144)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(124, 24)
      Me.chbTodos.TabIndex = 0
      Me.chbTodos.Text = "Chequear todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'PasajeMovimientos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(976, 461)
      Me.Controls.Add(Me.txtImporteTotalSaldo)
      Me.Controls.Add(Me.txtMontoAplicar)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.txtIva270)
      Me.Controls.Add(Me.txtNeto)
      Me.Controls.Add(Me.txtNetoNoGravado)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.lblTotales)
      Me.Controls.Add(Me.txtIva210)
      Me.Controls.Add(Me.txtIva105)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "PasajeMovimientos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Pasaje de Movimientos para Liquidación de Expensas"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents txtIva270 As Eniac.Controles.TextBox
   Friend WithEvents txtNeto As Eniac.Controles.TextBox
   Friend WithEvents txtNetoNoGravado As Eniac.Controles.TextBox
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtIva210 As Eniac.Controles.TextBox
   Friend WithEvents txtIva105 As Eniac.Controles.TextBox
   Public WithEvents tsbPasaje As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents toolExcluir As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents txtImporteTotalSaldo As Eniac.Controles.TextBox
   Friend WithEvents txtMontoAplicar As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents cmbExcluirEnPasaje As Eniac.Controles.ComboBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents tsbExcluirDePasaje As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbIncluirEnPasaje As System.Windows.Forms.ToolStripButton
   Friend WithEvents Pasaje As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PorcentajeIVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MontoSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MontoAplicar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CoeficienteValores As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ExcluirDePasaje_SN As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ExcluirDePasaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chbFechaDesde As Controles.CheckBox
    Friend WithEvents dtpDesde As Controles.DateTimePicker
End Class
