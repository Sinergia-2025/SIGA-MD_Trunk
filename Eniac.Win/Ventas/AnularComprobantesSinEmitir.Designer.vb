<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnularComprobantesSinEmitir
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnularComprobantesSinEmitir))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tspFichas = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.LetraFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobanteRelacionado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.txtNumeroTope = New Eniac.Controles.TextBox()
      Me.lblProximoNumero = New Eniac.Controles.Label()
      Me.cmbCategoriaFiscal = New Eniac.Controles.ComboBox()
      Me.lblVendedor = New Eniac.Controles.Label()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.lblCategoriaFiscal = New System.Windows.Forms.Label()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.cmbCobrador = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.tspFichas.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbCliente.SuspendLayout()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "row_add.ico")
      Me.imgIconos.Images.SetKeyName(1, "row_delete.ico")
      Me.imgIconos.Images.SetKeyName(2, "disk_blue.ico")
      '
      'tspFichas
      '
      Me.tspFichas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbAnular, Me.tsbSalir})
      Me.tspFichas.Location = New System.Drawing.Point(0, 0)
      Me.tspFichas.Name = "tspFichas"
      Me.tspFichas.Size = New System.Drawing.Size(884, 25)
      Me.tspFichas.TabIndex = 3
      Me.tspFichas.Text = "Números de comprobantes"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(75, 22)
      Me.tsbRefrescar.Text = "&Refrescar"
      '
      'tsbAnular
      '
      Me.tsbAnular.Image = Global.Eniac.Win.My.Resources.Resources.delete2
      Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbAnular.Name = "tsbAnular"
      Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
      Me.tsbAnular.Text = "&Anular"
      Me.tsbAnular.ToolTipText = "Grabar (F4)"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTipoComprobante, Me.TipoComprobante, Me.LetraFiscal, Me.CentroEmisor, Me.Numero, Me.IdTipoComprobanteRelacionado})
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle5
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 35)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(860, 407)
      Me.dgvDetalle.TabIndex = 12
      '
      'IdTipoComprobante
      '
      Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.IdTipoComprobante.HeaderText = "IdTipoComprobante"
      Me.IdTipoComprobante.Name = "IdTipoComprobante"
      Me.IdTipoComprobante.Visible = False
      '
      'TipoComprobante
      '
      Me.TipoComprobante.DataPropertyName = "TipoComprobante"
      Me.TipoComprobante.HeaderText = "Tipo Comprobante"
      Me.TipoComprobante.Name = "TipoComprobante"
      Me.TipoComprobante.ReadOnly = True
      Me.TipoComprobante.Width = 150
      '
      'LetraFiscal
      '
      Me.LetraFiscal.DataPropertyName = "LetraFiscal"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.LetraFiscal.DefaultCellStyle = DataGridViewCellStyle2
      Me.LetraFiscal.HeaderText = "Letra"
      Me.LetraFiscal.Name = "LetraFiscal"
      Me.LetraFiscal.ReadOnly = True
      Me.LetraFiscal.Width = 60
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
      Me.CentroEmisor.HeaderText = "Emisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.ReadOnly = True
      Me.CentroEmisor.Width = 60
      '
      'Numero
      '
      Me.Numero.DataPropertyName = "Numero"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle4.Format = "N0"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.Numero.DefaultCellStyle = DataGridViewCellStyle4
      Me.Numero.HeaderText = "Ultimo Número"
      Me.Numero.Name = "Numero"
      Me.Numero.ReadOnly = True
      '
      'IdTipoComprobanteRelacionado
      '
      Me.IdTipoComprobanteRelacionado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.IdTipoComprobanteRelacionado.DataPropertyName = "IdTipoComprobanteRelacionado"
      Me.IdTipoComprobanteRelacionado.HeaderText = "Tipos de Comprobantes Relacionados"
      Me.IdTipoComprobanteRelacionado.Name = "IdTipoComprobanteRelacionado"
      '
      'grbCliente
      '
      Me.grbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbCliente.Controls.Add(Me.cmbCobrador)
      Me.grbCliente.Controls.Add(Me.Label1)
      Me.grbCliente.Controls.Add(Me.txtNumeroTope)
      Me.grbCliente.Controls.Add(Me.lblProximoNumero)
      Me.grbCliente.Controls.Add(Me.cmbCategoriaFiscal)
      Me.grbCliente.Controls.Add(Me.cmbFormaPago)
      Me.grbCliente.Controls.Add(Me.lblFormaPago)
      Me.grbCliente.Controls.Add(Me.lblCategoriaFiscal)
      Me.grbCliente.Controls.Add(Me.cmbVendedor)
      Me.grbCliente.Controls.Add(Me.lblVendedor)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Controls.Add(Me.dtpFecha)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.lblFecha)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Location = New System.Drawing.Point(11, 441)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(863, 118)
      Me.grbCliente.TabIndex = 61
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Detalle"
      '
      'txtNumeroTope
      '
      Me.txtNumeroTope.BackColor = System.Drawing.Color.White
      Me.txtNumeroTope.BindearPropiedadControl = Nothing
      Me.txtNumeroTope.BindearPropiedadEntidad = Nothing
      Me.txtNumeroTope.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroTope.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroTope.Formato = ""
      Me.txtNumeroTope.IsDecimal = False
      Me.txtNumeroTope.IsNumber = True
      Me.txtNumeroTope.IsPK = False
      Me.txtNumeroTope.IsRequired = True
      Me.txtNumeroTope.Key = ""
      Me.txtNumeroTope.LabelAsoc = Me.lblProximoNumero
      Me.txtNumeroTope.Location = New System.Drawing.Point(178, 21)
      Me.txtNumeroTope.MaxLength = 8
      Me.txtNumeroTope.Name = "txtNumeroTope"
      Me.txtNumeroTope.Size = New System.Drawing.Size(81, 20)
      Me.txtNumeroTope.TabIndex = 61
      Me.txtNumeroTope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblProximoNumero
      '
      Me.lblProximoNumero.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblProximoNumero.AutoSize = True
      Me.lblProximoNumero.LabelAsoc = Nothing
      Me.lblProximoNumero.Location = New System.Drawing.Point(12, 24)
      Me.lblProximoNumero.Name = "lblProximoNumero"
      Me.lblProximoNumero.Size = New System.Drawing.Size(159, 13)
      Me.lblProximoNumero.TabIndex = 62
      Me.lblProximoNumero.Text = "Numero hasta donde se Anulara"
      '
      'cmbCategoriaFiscal
      '
      Me.cmbCategoriaFiscal.BindearPropiedadControl = Nothing
      Me.cmbCategoriaFiscal.BindearPropiedadEntidad = Nothing
      Me.cmbCategoriaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoriaFiscal.FormattingEnabled = True
      Me.cmbCategoriaFiscal.IsPK = False
      Me.cmbCategoriaFiscal.IsRequired = False
      Me.cmbCategoriaFiscal.Key = Nothing
      Me.cmbCategoriaFiscal.LabelAsoc = Me.lblVendedor
      Me.cmbCategoriaFiscal.Location = New System.Drawing.Point(432, 25)
      Me.cmbCategoriaFiscal.Name = "cmbCategoriaFiscal"
      Me.cmbCategoriaFiscal.Size = New System.Drawing.Size(181, 21)
      Me.cmbCategoriaFiscal.TabIndex = 48
      '
      'lblVendedor
      '
      Me.lblVendedor.AutoSize = True
      Me.lblVendedor.LabelAsoc = Nothing
      Me.lblVendedor.Location = New System.Drawing.Point(633, 9)
      Me.lblVendedor.Name = "lblVendedor"
      Me.lblVendedor.Size = New System.Drawing.Size(53, 13)
      Me.lblVendedor.TabIndex = 25
      Me.lblVendedor.Text = "Vendedor"
      '
      'cmbFormaPago
      '
      Me.cmbFormaPago.BindearPropiedadControl = Nothing
      Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
      Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormaPago.FormattingEnabled = True
      Me.cmbFormaPago.IsPK = False
      Me.cmbFormaPago.IsRequired = False
      Me.cmbFormaPago.Key = Nothing
      Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
      Me.cmbFormaPago.Location = New System.Drawing.Point(432, 64)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(181, 21)
      Me.cmbFormaPago.TabIndex = 8
      '
      'lblFormaPago
      '
      Me.lblFormaPago.AutoSize = True
      Me.lblFormaPago.LabelAsoc = Nothing
      Me.lblFormaPago.Location = New System.Drawing.Point(429, 47)
      Me.lblFormaPago.Name = "lblFormaPago"
      Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
      Me.lblFormaPago.TabIndex = 39
      Me.lblFormaPago.Text = "Forma de Pago"
      '
      'lblCategoriaFiscal
      '
      Me.lblCategoriaFiscal.AutoSize = True
      Me.lblCategoriaFiscal.Location = New System.Drawing.Point(431, 9)
      Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
      Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
      Me.lblCategoriaFiscal.TabIndex = 35
      Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
      '
      'cmbVendedor
      '
      Me.cmbVendedor.BindearPropiedadControl = Nothing
      Me.cmbVendedor.BindearPropiedadEntidad = Nothing
      Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedor.FormattingEnabled = True
      Me.cmbVendedor.IsPK = False
      Me.cmbVendedor.IsRequired = False
      Me.cmbVendedor.Key = Nothing
      Me.cmbVendedor.LabelAsoc = Me.lblVendedor
      Me.cmbVendedor.Location = New System.Drawing.Point(636, 25)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(151, 21)
      Me.cmbVendedor.TabIndex = 7
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
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(15, 63)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoCliente.TabIndex = 0
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(11, 46)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 4
      Me.lblCodigoCliente.Text = "Código"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = Nothing
      Me.dtpFecha.BindearPropiedadEntidad = Nothing
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(339, 24)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(84, 20)
      Me.dtpFecha.TabIndex = 11
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.LabelAsoc = Nothing
      Me.lblFecha.Location = New System.Drawing.Point(295, 27)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 7
      Me.lblFecha.Text = "Fecha"
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
      Me.bscCliente.Location = New System.Drawing.Point(112, 63)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 1
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(109, 50)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 1
      Me.lblNombre.Text = "Nombre"
      '
      'cmbCobrador
      '
      Me.cmbCobrador.BindearPropiedadControl = Nothing
      Me.cmbCobrador.BindearPropiedadEntidad = Nothing
      Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCobrador.FormattingEnabled = True
      Me.cmbCobrador.IsPK = False
      Me.cmbCobrador.IsRequired = False
      Me.cmbCobrador.Key = Nothing
      Me.cmbCobrador.LabelAsoc = Me.Label1
      Me.cmbCobrador.Location = New System.Drawing.Point(636, 65)
      Me.cmbCobrador.Name = "cmbCobrador"
      Me.cmbCobrador.Size = New System.Drawing.Size(151, 21)
      Me.cmbCobrador.TabIndex = 63
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(633, 49)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(50, 13)
      Me.Label1.TabIndex = 64
      Me.Label1.Text = "Cobrador"
      '
      'AnularComprobantesSinEmitir
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(884, 571)
      Me.Controls.Add(Me.grbCliente)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.tspFichas)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "AnularComprobantesSinEmitir"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anular Comprobantes Sin Emitir"
      Me.tspFichas.ResumeLayout(False)
      Me.tspFichas.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents tspFichas As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents txtNumeroTope As Eniac.Controles.TextBox
   Friend WithEvents lblProximoNumero As Eniac.Controles.Label
   Friend WithEvents cmbCategoriaFiscal As Eniac.Controles.ComboBox
   Friend WithEvents lblVendedor As Eniac.Controles.Label
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents lblCategoriaFiscal As System.Windows.Forms.Label
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents LetraFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobanteRelacionado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
End Class
