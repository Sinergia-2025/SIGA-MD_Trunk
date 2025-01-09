<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistrarMovCtaCteClientes
   Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistrarMovCtaCteClientes))
      Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.cmbBusquedaDomicilio = New Eniac.Controles.ComboBox()
        Me.bscDireccion = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
        Me.lblCotizacionDolar = New Eniac.Controles.Label()
        Me.chbNumeroDeCtaCte = New Eniac.Controles.CheckBox()
        Me.lblEmisor = New Eniac.Controles.Label()
        Me.txtEmisorComprobante = New Eniac.Controles.TextBox()
        Me.lblImporte = New Eniac.Controles.Label()
        Me.txtImporte = New Eniac.Controles.TextBox()
        Me.lblFechaVencimiento = New Eniac.Controles.Label()
        Me.dtpFechaVencimiento = New Eniac.Controles.DateTimePicker()
        Me.lblFechaEmision = New Eniac.Controles.Label()
        Me.dtpFechaEmision = New Eniac.Controles.DateTimePicker()
        Me.lblNumeroComprobante = New Eniac.Controles.Label()
        Me.txtNumeroComprobante = New Eniac.Controles.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.lblComprobante = New Eniac.Controles.Label()
        Me.lblObservacion = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.lblLetra = New Eniac.Controles.Label()
        Me.txtLetra = New Eniac.Controles.TextBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.lblVendedor = New Eniac.Controles.Label()
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
        Me.grbCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbCliente.Controls.Add(Me.cmbBusquedaDomicilio)
        Me.grbCliente.Controls.Add(Me.bscDireccion)
        Me.grbCliente.Controls.Add(Me.txtCotizacionDolar)
        Me.grbCliente.Controls.Add(Me.lblCotizacionDolar)
        Me.grbCliente.Controls.Add(Me.chbNumeroDeCtaCte)
        Me.grbCliente.Controls.Add(Me.lblEmisor)
        Me.grbCliente.Controls.Add(Me.txtEmisorComprobante)
        Me.grbCliente.Controls.Add(Me.lblImporte)
        Me.grbCliente.Controls.Add(Me.txtImporte)
        Me.grbCliente.Controls.Add(Me.lblFechaVencimiento)
        Me.grbCliente.Controls.Add(Me.dtpFechaVencimiento)
        Me.grbCliente.Controls.Add(Me.lblFechaEmision)
        Me.grbCliente.Controls.Add(Me.dtpFechaEmision)
        Me.grbCliente.Controls.Add(Me.lblNumeroComprobante)
        Me.grbCliente.Controls.Add(Me.txtNumeroComprobante)
        Me.grbCliente.Controls.Add(Me.lblCliente)
        Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
        Me.grbCliente.Controls.Add(Me.bscCliente)
        Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
        Me.grbCliente.Controls.Add(Me.lblNombre)
        Me.grbCliente.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbCliente.Controls.Add(Me.lblObservacion)
        Me.grbCliente.Controls.Add(Me.txtObservacion)
        Me.grbCliente.Controls.Add(Me.lblLetra)
        Me.grbCliente.Controls.Add(Me.txtLetra)
        Me.grbCliente.Controls.Add(Me.cmbVendedor)
        Me.grbCliente.Controls.Add(Me.lblVendedor)
        Me.grbCliente.Controls.Add(Me.lblComprobante)
        Me.grbCliente.Location = New System.Drawing.Point(6, 31)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(592, 232)
        Me.grbCliente.TabIndex = 0
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Detalle"
        '
        'cmbBusquedaDomicilio
        '
        Me.cmbBusquedaDomicilio.BindearPropiedadControl = Nothing
        Me.cmbBusquedaDomicilio.BindearPropiedadEntidad = Nothing
        Me.cmbBusquedaDomicilio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusquedaDomicilio.Enabled = False
        Me.cmbBusquedaDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbBusquedaDomicilio.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBusquedaDomicilio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBusquedaDomicilio.FormattingEnabled = True
        Me.cmbBusquedaDomicilio.IsPK = False
        Me.cmbBusquedaDomicilio.IsRequired = False
        Me.cmbBusquedaDomicilio.Key = Nothing
        Me.cmbBusquedaDomicilio.LabelAsoc = Nothing
        Me.cmbBusquedaDomicilio.Location = New System.Drawing.Point(158, 20)
        Me.cmbBusquedaDomicilio.Name = "cmbBusquedaDomicilio"
        Me.cmbBusquedaDomicilio.Size = New System.Drawing.Size(106, 21)
        Me.cmbBusquedaDomicilio.TabIndex = 82
        '
        'bscDireccion
        '
        Me.bscDireccion.ActivarFiltroEnGrilla = True
        Me.bscDireccion.AutoSize = True
        Me.bscDireccion.BindearPropiedadControl = Nothing
        Me.bscDireccion.BindearPropiedadEntidad = Nothing
        Me.bscDireccion.ConfigBuscador = Nothing
        Me.bscDireccion.Datos = Nothing
        Me.bscDireccion.FilaDevuelta = Nothing
        Me.bscDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDireccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDireccion.IsDecimal = False
        Me.bscDireccion.IsNumber = False
        Me.bscDireccion.IsPK = False
        Me.bscDireccion.IsRequired = False
        Me.bscDireccion.Key = ""
        Me.bscDireccion.LabelAsoc = Me.lblNombre
        Me.bscDireccion.Location = New System.Drawing.Point(271, 20)
        Me.bscDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.bscDireccion.MaxLengh = "32767"
        Me.bscDireccion.Name = "bscDireccion"
        Me.bscDireccion.Permitido = True
        Me.bscDireccion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscDireccion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscDireccion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscDireccion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscDireccion.Selecciono = False
        Me.bscDireccion.Size = New System.Drawing.Size(177, 23)
        Me.bscDireccion.TabIndex = 81
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(154, 47)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre"
        '
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.BackColor = System.Drawing.SystemColors.Window
        Me.txtCotizacionDolar.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolar.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolar.Formato = "##0.00"
        Me.txtCotizacionDolar.IsDecimal = True
        Me.txtCotizacionDolar.IsNumber = True
        Me.txtCotizacionDolar.IsPK = False
        Me.txtCotizacionDolar.IsRequired = False
        Me.txtCotizacionDolar.Key = ""
        Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(503, 66)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(48, 20)
        Me.txtCotizacionDolar.TabIndex = 68
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCotizacionDolar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(471, 68)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(33, 18)
        Me.lblCotizacionDolar.TabIndex = 67
        Me.lblCotizacionDolar.Text = "Dólar"
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.chbNumeroDeCtaCte.Location = New System.Drawing.Point(460, 14)
        Me.chbNumeroDeCtaCte.Name = "chbNumeroDeCtaCte"
        Me.chbNumeroDeCtaCte.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbNumeroDeCtaCte.Size = New System.Drawing.Size(113, 17)
        Me.chbNumeroDeCtaCte.TabIndex = 24
        Me.chbNumeroDeCtaCte.Text = "Numero de CtaCte"
        Me.chbNumeroDeCtaCte.UseVisualStyleBackColor = True
        '
        'lblEmisor
        '
        Me.lblEmisor.AutoSize = True
        Me.lblEmisor.LabelAsoc = Nothing
        Me.lblEmisor.Location = New System.Drawing.Point(321, 140)
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
        Me.txtEmisorComprobante.Location = New System.Drawing.Point(313, 155)
        Me.txtEmisorComprobante.MaxLength = 4
        Me.txtEmisorComprobante.Name = "txtEmisorComprobante"
        Me.txtEmisorComprobante.Size = New System.Drawing.Size(46, 20)
        Me.txtEmisorComprobante.TabIndex = 16
        Me.txtEmisorComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.LabelAsoc = Nothing
        Me.lblImporte.Location = New System.Drawing.Point(457, 159)
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
        Me.txtImporte.Location = New System.Drawing.Point(503, 155)
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
        Me.lblFechaVencimiento.Location = New System.Drawing.Point(167, 109)
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
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(236, 105)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaVencimiento.TabIndex = 8
        '
        'lblFechaEmision
        '
        Me.lblFechaEmision.AutoSize = True
        Me.lblFechaEmision.LabelAsoc = Nothing
        Me.lblFechaEmision.Location = New System.Drawing.Point(9, 109)
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
        Me.dtpFechaEmision.Location = New System.Drawing.Point(60, 105)
        Me.dtpFechaEmision.Name = "dtpFechaEmision"
        Me.dtpFechaEmision.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaEmision.TabIndex = 6
        '
        'lblNumeroComprobante
        '
        Me.lblNumeroComprobante.AutoSize = True
        Me.lblNumeroComprobante.LabelAsoc = Nothing
        Me.lblNumeroComprobante.Location = New System.Drawing.Point(395, 140)
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
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(364, 155)
        Me.txtNumeroComprobante.MaxLength = 8
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(75, 20)
        Me.txtNumeroComprobante.TabIndex = 18
        Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(9, 65)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "Cliente"
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
        Me.bscCodigoCliente.IsNumber = True
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(60, 63)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 2
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(57, 47)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 1
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
        Me.bscCliente.Location = New System.Drawing.Point(157, 63)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 4
        Me.bscCliente.Titulo = Nothing
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
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(81, 155)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(196, 21)
        Me.cmbTiposComprobantes.TabIndex = 12
        '
        'lblComprobante
        '
        Me.lblComprobante.AutoSize = True
        Me.lblComprobante.LabelAsoc = Nothing
        Me.lblComprobante.Location = New System.Drawing.Point(7, 159)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
        Me.lblComprobante.TabIndex = 11
        Me.lblComprobante.Text = "Comprobante"
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(6, 189)
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
        Me.txtObservacion.Location = New System.Drawing.Point(81, 185)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(491, 20)
        Me.txtObservacion.TabIndex = 22
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.LabelAsoc = Nothing
        Me.lblLetra.Location = New System.Drawing.Point(278, 140)
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
        Me.txtLetra.Location = New System.Drawing.Point(281, 155)
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.ReadOnly = True
        Me.txtLetra.Size = New System.Drawing.Size(25, 20)
        Me.txtLetra.TabIndex = 14
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.cmbVendedor.Location = New System.Drawing.Point(397, 105)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(175, 21)
        Me.cmbVendedor.TabIndex = 10
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.LabelAsoc = Nothing
        Me.lblVendedor.Location = New System.Drawing.Point(338, 109)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lblVendedor.TabIndex = 9
        Me.lblVendedor.Text = "Vendedor"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
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
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
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
        'RegistrarMovCtaCteClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 269)
        Me.Controls.Add(Me.grbCliente)
        Me.Controls.Add(Me.tspMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "RegistrarMovCtaCteClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Movimientos en Cta.Cte. Clientes"
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        Me.tspMenu.ResumeLayout(False)
        Me.tspMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
    Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
    Friend WithEvents bscCliente As Eniac.Controles.Buscador
    Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
    Friend WithEvents lblVendedor As Eniac.Controles.Label
    Friend WithEvents lblObservacion As Eniac.Controles.Label
    Friend WithEvents txtObservacion As Eniac.Controles.TextBox
    Friend WithEvents lblLetra As Eniac.Controles.Label
    Friend WithEvents txtLetra As Eniac.Controles.TextBox
    Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
    Friend WithEvents lblComprobante As Eniac.Controles.Label
    Friend WithEvents lblImporte As Eniac.Controles.Label
    Friend WithEvents txtImporte As Eniac.Controles.TextBox
    Friend WithEvents lblFechaVencimiento As Eniac.Controles.Label
    Friend WithEvents dtpFechaVencimiento As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaEmision As Eniac.Controles.Label
    Friend WithEvents dtpFechaEmision As Eniac.Controles.DateTimePicker
    Friend WithEvents lblNumeroComprobante As Eniac.Controles.Label
    Friend WithEvents txtNumeroComprobante As Eniac.Controles.TextBox
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbsSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspMenu As System.Windows.Forms.ToolStrip
   Friend WithEvents lblEmisor As Eniac.Controles.Label
    Friend WithEvents txtEmisorComprobante As Eniac.Controles.TextBox
   Friend WithEvents chbNumeroDeCtaCte As Eniac.Controles.CheckBox
   Friend WithEvents txtCotizacionDolar As Eniac.Controles.TextBox
   Friend WithEvents lblCotizacionDolar As Eniac.Controles.Label
    Friend WithEvents cmbBusquedaDomicilio As Controles.ComboBox
    Friend WithEvents bscDireccion As Controles.Buscador2
End Class
