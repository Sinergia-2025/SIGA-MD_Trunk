<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistrarMovCtaCteProveedores
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistrarMovCtaCteProveedores))
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.chbNumeroDeCtaCte = New Eniac.Controles.CheckBox()
      Me.lblEmisor = New Eniac.Controles.Label()
      Me.txtEmisorComprobante = New Eniac.Controles.TextBox()
      Me.lblNumeroComprobante = New Eniac.Controles.Label()
      Me.txtNumeroComprobante = New Eniac.Controles.TextBox()
      Me.lblImporte = New Eniac.Controles.Label()
      Me.txtImporte = New Eniac.Controles.TextBox()
      Me.lblFechaVencimiento = New Eniac.Controles.Label()
      Me.dtpFechaVencimiento = New Eniac.Controles.DateTimePicker()
      Me.lblFechaEmision = New Eniac.Controles.Label()
      Me.dtpFechaEmision = New Eniac.Controles.DateTimePicker()
      Me.lblProveedor = New System.Windows.Forms.Label()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tbsSalir = New System.Windows.Forms.ToolStripButton()
      Me.tspMenu = New System.Windows.Forms.ToolStrip()
      Me.grbCliente.SuspendLayout()
      Me.tspMenu.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbCliente
      '
      Me.grbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbCliente.Controls.Add(Me.chbNumeroDeCtaCte)
      Me.grbCliente.Controls.Add(Me.lblEmisor)
      Me.grbCliente.Controls.Add(Me.txtEmisorComprobante)
      Me.grbCliente.Controls.Add(Me.lblNumeroComprobante)
      Me.grbCliente.Controls.Add(Me.txtNumeroComprobante)
      Me.grbCliente.Controls.Add(Me.lblImporte)
      Me.grbCliente.Controls.Add(Me.txtImporte)
      Me.grbCliente.Controls.Add(Me.lblFechaVencimiento)
      Me.grbCliente.Controls.Add(Me.dtpFechaVencimiento)
      Me.grbCliente.Controls.Add(Me.lblFechaEmision)
      Me.grbCliente.Controls.Add(Me.dtpFechaEmision)
      Me.grbCliente.Controls.Add(Me.lblProveedor)
      Me.grbCliente.Controls.Add(Me.bscCodigoProveedor)
      Me.grbCliente.Controls.Add(Me.bscProveedor)
      Me.grbCliente.Controls.Add(Me.lblCodigoProveedor)
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbCliente.Controls.Add(Me.lblObservacion)
      Me.grbCliente.Controls.Add(Me.txtObservacion)
      Me.grbCliente.Controls.Add(Me.lblLetra)
      Me.grbCliente.Controls.Add(Me.txtLetra)
      Me.grbCliente.Controls.Add(Me.lblComprobante)
      Me.grbCliente.Location = New System.Drawing.Point(6, 31)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(592, 203)
      Me.grbCliente.TabIndex = 0
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Detalle"
      '
      'chbNumeroDeCtaCte
      '
      Me.chbNumeroDeCtaCte.AutoSize = True
      Me.chbNumeroDeCtaCte.BindearPropiedadControl = "Checked"
      Me.chbNumeroDeCtaCte.BindearPropiedadEntidad = "Activo"
      Me.chbNumeroDeCtaCte.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumeroDeCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumeroDeCtaCte.IsPK = False
      Me.chbNumeroDeCtaCte.IsRequired = False
      Me.chbNumeroDeCtaCte.Key = Nothing
      Me.chbNumeroDeCtaCte.LabelAsoc = Nothing
      Me.chbNumeroDeCtaCte.Location = New System.Drawing.Point(459, 17)
      Me.chbNumeroDeCtaCte.Name = "chbNumeroDeCtaCte"
      Me.chbNumeroDeCtaCte.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbNumeroDeCtaCte.Size = New System.Drawing.Size(113, 17)
      Me.chbNumeroDeCtaCte.TabIndex = 25
      Me.chbNumeroDeCtaCte.Text = "Numero de CtaCte"
      Me.chbNumeroDeCtaCte.UseVisualStyleBackColor = True
      '
      'lblEmisor
      '
      Me.lblEmisor.AutoSize = True
      Me.lblEmisor.LabelAsoc = Nothing
      Me.lblEmisor.Location = New System.Drawing.Point(320, 117)
      Me.lblEmisor.Name = "lblEmisor"
      Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisor.TabIndex = 15
      Me.lblEmisor.Text = "Emisor"
      '
      'txtEmisorComprobante
      '
      Me.txtEmisorComprobante.BindearPropiedadControl = Nothing
      Me.txtEmisorComprobante.BindearPropiedadEntidad = Nothing
      Me.txtEmisorComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisorComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisorComprobante.Formato = ""
      Me.txtEmisorComprobante.IsDecimal = False
      Me.txtEmisorComprobante.IsNumber = True
      Me.txtEmisorComprobante.IsPK = False
      Me.txtEmisorComprobante.IsRequired = False
      Me.txtEmisorComprobante.Key = ""
      Me.txtEmisorComprobante.LabelAsoc = Me.lblEmisor
      Me.txtEmisorComprobante.Location = New System.Drawing.Point(312, 132)
      Me.txtEmisorComprobante.MaxLength = 4
      Me.txtEmisorComprobante.Name = "txtEmisorComprobante"
      Me.txtEmisorComprobante.Size = New System.Drawing.Size(46, 20)
      Me.txtEmisorComprobante.TabIndex = 16
      Me.txtEmisorComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroComprobante
      '
      Me.lblNumeroComprobante.AutoSize = True
      Me.lblNumeroComprobante.LabelAsoc = Nothing
      Me.lblNumeroComprobante.Location = New System.Drawing.Point(394, 117)
      Me.lblNumeroComprobante.Name = "lblNumeroComprobante"
      Me.lblNumeroComprobante.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroComprobante.TabIndex = 17
      Me.lblNumeroComprobante.Text = "Numero"
      '
      'txtNumeroComprobante
      '
      Me.txtNumeroComprobante.BindearPropiedadControl = Nothing
      Me.txtNumeroComprobante.BindearPropiedadEntidad = Nothing
      Me.txtNumeroComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroComprobante.Formato = ""
      Me.txtNumeroComprobante.IsDecimal = False
      Me.txtNumeroComprobante.IsNumber = True
      Me.txtNumeroComprobante.IsPK = False
      Me.txtNumeroComprobante.IsRequired = False
      Me.txtNumeroComprobante.Key = ""
      Me.txtNumeroComprobante.LabelAsoc = Me.lblNumeroComprobante
      Me.txtNumeroComprobante.Location = New System.Drawing.Point(363, 132)
      Me.txtNumeroComprobante.MaxLength = 8
      Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
      Me.txtNumeroComprobante.Size = New System.Drawing.Size(75, 20)
      Me.txtNumeroComprobante.TabIndex = 18
      Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblImporte
      '
      Me.lblImporte.AutoSize = True
      Me.lblImporte.LabelAsoc = Nothing
      Me.lblImporte.Location = New System.Drawing.Point(457, 136)
      Me.lblImporte.Name = "lblImporte"
      Me.lblImporte.Size = New System.Drawing.Size(42, 13)
      Me.lblImporte.TabIndex = 19
      Me.lblImporte.Text = "Importe"
      '
      'txtImporte
      '
      Me.txtImporte.BindearPropiedadControl = Nothing
      Me.txtImporte.BindearPropiedadEntidad = Nothing
      Me.txtImporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporte.Formato = "##0.00"
      Me.txtImporte.IsDecimal = True
      Me.txtImporte.IsNumber = True
      Me.txtImporte.IsPK = False
      Me.txtImporte.IsRequired = False
      Me.txtImporte.Key = ""
      Me.txtImporte.LabelAsoc = Me.lblImporte
      Me.txtImporte.Location = New System.Drawing.Point(503, 132)
      Me.txtImporte.Name = "txtImporte"
      Me.txtImporte.Size = New System.Drawing.Size(69, 20)
      Me.txtImporte.TabIndex = 20
      Me.txtImporte.Text = "0.00"
      Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblFechaVencimiento
      '
      Me.lblFechaVencimiento.AutoSize = True
      Me.lblFechaVencimiento.LabelAsoc = Nothing
      Me.lblFechaVencimiento.Location = New System.Drawing.Point(167, 86)
      Me.lblFechaVencimiento.Name = "lblFechaVencimiento"
      Me.lblFechaVencimiento.Size = New System.Drawing.Size(65, 13)
      Me.lblFechaVencimiento.TabIndex = 7
      Me.lblFechaVencimiento.Text = "Vencimiento"
      '
      'dtpFechaVencimiento
      '
      Me.dtpFechaVencimiento.BindearPropiedadControl = Nothing
      Me.dtpFechaVencimiento.BindearPropiedadEntidad = Nothing
      Me.dtpFechaVencimiento.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaVencimiento.IsPK = False
      Me.dtpFechaVencimiento.IsRequired = False
      Me.dtpFechaVencimiento.Key = ""
      Me.dtpFechaVencimiento.LabelAsoc = Me.lblFechaVencimiento
      Me.dtpFechaVencimiento.Location = New System.Drawing.Point(236, 82)
      Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
      Me.dtpFechaVencimiento.Size = New System.Drawing.Size(85, 20)
      Me.dtpFechaVencimiento.TabIndex = 8
      '
      'lblFechaEmision
      '
      Me.lblFechaEmision.AutoSize = True
      Me.lblFechaEmision.LabelAsoc = Nothing
      Me.lblFechaEmision.Location = New System.Drawing.Point(9, 86)
      Me.lblFechaEmision.Name = "lblFechaEmision"
      Me.lblFechaEmision.Size = New System.Drawing.Size(43, 13)
      Me.lblFechaEmision.TabIndex = 5
      Me.lblFechaEmision.Text = "Emisión"
      '
      'dtpFechaEmision
      '
      Me.dtpFechaEmision.BindearPropiedadControl = Nothing
      Me.dtpFechaEmision.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEmision.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaEmision.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEmision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEmision.IsPK = False
      Me.dtpFechaEmision.IsRequired = False
      Me.dtpFechaEmision.Key = ""
      Me.dtpFechaEmision.LabelAsoc = Me.lblFechaEmision
      Me.dtpFechaEmision.Location = New System.Drawing.Point(68, 82)
      Me.dtpFechaEmision.Name = "dtpFechaEmision"
      Me.dtpFechaEmision.Size = New System.Drawing.Size(85, 20)
      Me.dtpFechaEmision.TabIndex = 6
      '
      'lblProveedor
      '
      Me.lblProveedor.AutoSize = True
      Me.lblProveedor.Location = New System.Drawing.Point(9, 42)
      Me.lblProveedor.Name = "lblProveedor"
      Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
      Me.lblProveedor.TabIndex = 0
      Me.lblProveedor.Text = "Proveedor"
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ConfigBuscador = Nothing
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = True
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(68, 40)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 2
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.LabelAsoc = Nothing
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(68, 24)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 1
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
      Me.bscProveedor.Location = New System.Drawing.Point(165, 40)
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
      Me.bscProveedor.TabIndex = 4
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(162, 24)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.ItemHeight = 13
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Me.lblComprobante
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(81, 132)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(196, 21)
      Me.cmbTiposComprobantes.TabIndex = 12
      '
      'lblComprobante
      '
      Me.lblComprobante.AutoSize = True
      Me.lblComprobante.LabelAsoc = Nothing
      Me.lblComprobante.Location = New System.Drawing.Point(7, 136)
      Me.lblComprobante.Name = "lblComprobante"
      Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
      Me.lblComprobante.TabIndex = 11
      Me.lblComprobante.Text = "Comprobante"
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.LabelAsoc = Nothing
      Me.lblObservacion.Location = New System.Drawing.Point(6, 166)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 21
      Me.lblObservacion.Text = "Observación"
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = Nothing
      Me.txtObservacion.BindearPropiedadEntidad = Nothing
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Me.lblObservacion
      Me.txtObservacion.Location = New System.Drawing.Point(81, 162)
      Me.txtObservacion.MaxLength = 100
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(491, 20)
      Me.txtObservacion.TabIndex = 22
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.LabelAsoc = Nothing
      Me.lblLetra.Location = New System.Drawing.Point(279, 117)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(28, 13)
      Me.lblLetra.TabIndex = 13
      Me.lblLetra.Text = "Tipo"
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = Nothing
      Me.txtLetra.BindearPropiedadEntidad = Nothing
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
      Me.txtLetra.Location = New System.Drawing.Point(282, 132)
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.ReadOnly = True
      Me.txtLetra.Size = New System.Drawing.Size(25, 20)
      Me.txtLetra.TabIndex = 14
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'tsbNuevo
      '
      Me.tsbNuevo.Image = Global.Eniac.Win.My.Resources.Resources.document_add
      Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbNuevo.Name = "tsbNuevo"
      Me.tsbNuevo.Size = New System.Drawing.Size(70, 28)
      Me.tsbNuevo.Text = "Nuevo"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Enabled = False
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(93, 28)
      Me.tsbGrabar.Text = "Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
      '
      'tbsSalir
      '
      Me.tbsSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tbsSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tbsSalir.Name = "tbsSalir"
      Me.tbsSalir.Size = New System.Drawing.Size(67, 28)
      Me.tbsSalir.Text = "Cerrar"
      '
      'tspMenu
      '
      Me.tspMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me.tspMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.ToolStripSeparator1, Me.tsbGrabar, Me.ToolStripSeparator2, Me.tbsSalir})
      Me.tspMenu.Location = New System.Drawing.Point(0, 0)
      Me.tspMenu.Name = "tspMenu"
      Me.tspMenu.Size = New System.Drawing.Size(610, 31)
      Me.tspMenu.TabIndex = 1
      Me.tspMenu.Text = "ToolStrip1"
      '
      'RegistrarMovCtaCteProveedores
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(610, 244)
      Me.Controls.Add(Me.grbCliente)
      Me.Controls.Add(Me.tspMenu)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "RegistrarMovCtaCteProveedores"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Registrar Movimientos en Cta.Cte. Proveedores"
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.tspMenu.ResumeLayout(False)
      Me.tspMenu.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents lblProveedor As System.Windows.Forms.Label
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
    Friend WithEvents lblObservacion As Eniac.Controles.Label
    Friend WithEvents txtObservacion As Eniac.Controles.TextBox
    Friend WithEvents lblLetra As Eniac.Controles.Label
    Friend WithEvents txtLetra As Eniac.Controles.TextBox
    Friend WithEvents lblComprobante As Eniac.Controles.Label
    Friend WithEvents lblImporte As Eniac.Controles.Label
    Friend WithEvents txtImporte As Eniac.Controles.TextBox
    Friend WithEvents lblFechaVencimiento As Eniac.Controles.Label
    Friend WithEvents dtpFechaVencimiento As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaEmision As Eniac.Controles.Label
    Friend WithEvents dtpFechaEmision As Eniac.Controles.DateTimePicker
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbsSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspMenu As System.Windows.Forms.ToolStrip
   Friend WithEvents lblEmisor As Eniac.Controles.Label
   Friend WithEvents txtEmisorComprobante As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroComprobante As Eniac.Controles.Label
   Friend WithEvents txtNumeroComprobante As Eniac.Controles.TextBox
    Friend WithEvents chbNumeroDeCtaCte As Controles.CheckBox
End Class
