<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TarjetasCuponesDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.tbc_TarjetasCupones = New System.Windows.Forms.TabControl()
      Me.tbpDetalle = New System.Windows.Forms.TabPage()
      Me.grbDetalle = New System.Windows.Forms.GroupBox()
      Me.lblNroCupon = New Eniac.Controles.Label()
      Me.lblCuota = New Eniac.Controles.Label()
      Me.txtTarMonto = New Eniac.Controles.TextBox()
      Me.lblImporte = New Eniac.Controles.Label()
      Me.bscTarBanco = New Eniac.Controles.Buscador()
      Me.lblBanco = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.txtCuota = New Eniac.Controles.TextBox()
      Me.lblSituacion = New Eniac.Controles.Label()
      Me.cmbSituacionTarjetaCupones = New Eniac.Controles.ComboBox()
      Me.txtNroCupon = New Eniac.Controles.TextBox()
      Me.lblTarjeta = New Eniac.Controles.Label()
      Me.cmbTarTarjeta = New Eniac.Controles.ComboBox()
      Me.txtNumeroLote = New Eniac.Controles.TextBox()
      Me.lblNumeroLote = New Eniac.Controles.Label()
      Me.dtpFechaEmision = New Eniac.Controles.DateTimePicker()
      Me.lblFechaEmision = New Eniac.Controles.Label()
      Me.grbEstado = New System.Windows.Forms.GroupBox()
      Me.txtEstadoActual = New Eniac.Controles.TextBox()
      Me.lblEstadoActual = New Eniac.Controles.Label()
      Me.tbpIngresoCaja = New System.Windows.Forms.TabPage()
      Me.tbc_TarjetasCupones.SuspendLayout()
      Me.tbpDetalle.SuspendLayout()
      Me.grbDetalle.SuspendLayout()
      Me.grbEstado.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(439, 314)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(525, 314)
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(121, 170)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(64, 170)
      '
      'tbc_TarjetasCupones
      '
      Me.tbc_TarjetasCupones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbc_TarjetasCupones.Controls.Add(Me.tbpDetalle)
      Me.tbc_TarjetasCupones.Controls.Add(Me.tbpIngresoCaja)
      Me.tbc_TarjetasCupones.Location = New System.Drawing.Point(11, 12)
      Me.tbc_TarjetasCupones.Name = "tbc_TarjetasCupones"
      Me.tbc_TarjetasCupones.SelectedIndex = 0
      Me.tbc_TarjetasCupones.Size = New System.Drawing.Size(598, 296)
      Me.tbc_TarjetasCupones.TabIndex = 5
      '
      'tbpDetalle
      '
      Me.tbpDetalle.BackColor = System.Drawing.SystemColors.Control
      Me.tbpDetalle.Controls.Add(Me.grbDetalle)
      Me.tbpDetalle.Controls.Add(Me.grbEstado)
      Me.tbpDetalle.Location = New System.Drawing.Point(4, 22)
      Me.tbpDetalle.Name = "tbpDetalle"
      Me.tbpDetalle.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpDetalle.Size = New System.Drawing.Size(590, 270)
      Me.tbpDetalle.TabIndex = 0
      Me.tbpDetalle.Text = "General"
      '
      'grbDetalle
      '
      Me.grbDetalle.Controls.Add(Me.lblNroCupon)
      Me.grbDetalle.Controls.Add(Me.lblCuota)
      Me.grbDetalle.Controls.Add(Me.txtTarMonto)
      Me.grbDetalle.Controls.Add(Me.bscTarBanco)
      Me.grbDetalle.Controls.Add(Me.bscCliente)
      Me.grbDetalle.Controls.Add(Me.bscCodigoCliente)
      Me.grbDetalle.Controls.Add(Me.lblCodigoCliente)
      Me.grbDetalle.Controls.Add(Me.lblNombre)
      Me.grbDetalle.Controls.Add(Me.txtCuota)
      Me.grbDetalle.Controls.Add(Me.lblSituacion)
      Me.grbDetalle.Controls.Add(Me.cmbSituacionTarjetaCupones)
      Me.grbDetalle.Controls.Add(Me.txtNroCupon)
      Me.grbDetalle.Controls.Add(Me.lblTarjeta)
      Me.grbDetalle.Controls.Add(Me.cmbTarTarjeta)
      Me.grbDetalle.Controls.Add(Me.lblImporte)
      Me.grbDetalle.Controls.Add(Me.txtNumeroLote)
      Me.grbDetalle.Controls.Add(Me.lblNumeroLote)
      Me.grbDetalle.Controls.Add(Me.lblBanco)
      Me.grbDetalle.Controls.Add(Me.dtpFechaEmision)
      Me.grbDetalle.Controls.Add(Me.lblFechaEmision)
      Me.grbDetalle.Location = New System.Drawing.Point(8, 5)
      Me.grbDetalle.Name = "grbDetalle"
      Me.grbDetalle.Size = New System.Drawing.Size(558, 151)
      Me.grbDetalle.TabIndex = 0
      Me.grbDetalle.TabStop = False
      Me.grbDetalle.Text = "Detalle"
      '
      'lblNroCupon
      '
      Me.lblNroCupon.AutoSize = True
      Me.lblNroCupon.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNroCupon.LabelAsoc = Nothing
      Me.lblNroCupon.Location = New System.Drawing.Point(198, 87)
      Me.lblNroCupon.Name = "lblNroCupon"
      Me.lblNroCupon.Size = New System.Drawing.Size(76, 13)
      Me.lblNroCupon.TabIndex = 10
      Me.lblNroCupon.Text = "Nro. de Cupon"
      '
      'lblCuota
      '
      Me.lblCuota.AutoSize = True
      Me.lblCuota.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblCuota.LabelAsoc = Nothing
      Me.lblCuota.Location = New System.Drawing.Point(198, 116)
      Me.lblCuota.Name = "lblCuota"
      Me.lblCuota.Size = New System.Drawing.Size(35, 13)
      Me.lblCuota.TabIndex = 16
      Me.lblCuota.Text = "Cuota"
      '
      'txtTarMonto
      '
      Me.txtTarMonto.BindearPropiedadControl = "Text"
      Me.txtTarMonto.BindearPropiedadEntidad = "Monto"
      Me.txtTarMonto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTarMonto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTarMonto.Formato = "##0.00"
      Me.txtTarMonto.IsDecimal = True
      Me.txtTarMonto.IsNumber = True
      Me.txtTarMonto.IsPK = False
      Me.txtTarMonto.IsRequired = False
      Me.txtTarMonto.Key = ""
      Me.txtTarMonto.LabelAsoc = Me.lblImporte
      Me.txtTarMonto.Location = New System.Drawing.Point(57, 113)
      Me.txtTarMonto.MaxLength = 10
      Me.txtTarMonto.Name = "txtTarMonto"
      Me.txtTarMonto.Size = New System.Drawing.Size(135, 20)
      Me.txtTarMonto.TabIndex = 15
      Me.txtTarMonto.Text = "0.00"
      Me.txtTarMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblImporte
      '
      Me.lblImporte.AutoSize = True
      Me.lblImporte.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblImporte.LabelAsoc = Nothing
      Me.lblImporte.Location = New System.Drawing.Point(8, 116)
      Me.lblImporte.Name = "lblImporte"
      Me.lblImporte.Size = New System.Drawing.Size(42, 13)
      Me.lblImporte.TabIndex = 14
      Me.lblImporte.Text = "Importe"
      '
      'bscTarBanco
      '
      Me.bscTarBanco.AyudaAncho = 608
      Me.bscTarBanco.BindearPropiedadControl = ""
      Me.bscTarBanco.BindearPropiedadEntidad = ""
      Me.bscTarBanco.ColumnasAlineacion = Nothing
      Me.bscTarBanco.ColumnasAncho = Nothing
      Me.bscTarBanco.ColumnasFormato = Nothing
      Me.bscTarBanco.ColumnasOcultas = Nothing
      Me.bscTarBanco.ColumnasTitulos = Nothing
      Me.bscTarBanco.Datos = Nothing
      Me.bscTarBanco.FilaDevuelta = Nothing
      Me.bscTarBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.bscTarBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscTarBanco.IsDecimal = False
      Me.bscTarBanco.IsNumber = False
      Me.bscTarBanco.IsPK = False
      Me.bscTarBanco.IsRequired = False
      Me.bscTarBanco.Key = ""
      Me.bscTarBanco.LabelAsoc = Me.lblBanco
      Me.bscTarBanco.Location = New System.Drawing.Point(318, 54)
      Me.bscTarBanco.MaxLengh = "32767"
      Me.bscTarBanco.Name = "bscTarBanco"
      Me.bscTarBanco.Permitido = True
      Me.bscTarBanco.Selecciono = False
      Me.bscTarBanco.Size = New System.Drawing.Size(224, 20)
      Me.bscTarBanco.TabIndex = 7
      Me.bscTarBanco.Titulo = Nothing
      '
      'lblBanco
      '
      Me.lblBanco.AutoSize = True
      Me.lblBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblBanco.LabelAsoc = Nothing
      Me.lblBanco.Location = New System.Drawing.Point(274, 57)
      Me.lblBanco.Name = "lblBanco"
      Me.lblBanco.Size = New System.Drawing.Size(38, 13)
      Me.lblBanco.TabIndex = 6
      Me.lblBanco.Text = "Banco"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ConfigBuscador = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.lblNombre
      Me.bscCliente.Location = New System.Drawing.Point(204, 21)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(338, 23)
      Me.bscCliente.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(153, 25)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "&Nombre"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ConfigBuscador = Nothing
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(57, 21)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoCliente.TabIndex = 1
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(11, 25)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 0
      Me.lblCodigoCliente.Text = "Código"
      '
      'txtCuota
      '
      Me.txtCuota.BindearPropiedadControl = "Text"
      Me.txtCuota.BindearPropiedadEntidad = "Cuotas"
      Me.txtCuota.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuota.Formato = ""
      Me.txtCuota.IsDecimal = False
      Me.txtCuota.IsNumber = False
      Me.txtCuota.IsPK = False
      Me.txtCuota.IsRequired = False
      Me.txtCuota.Key = ""
      Me.txtCuota.LabelAsoc = Me.lblCuota
      Me.txtCuota.Location = New System.Drawing.Point(239, 113)
      Me.txtCuota.MaxLength = 15
      Me.txtCuota.Name = "txtCuota"
      Me.txtCuota.Size = New System.Drawing.Size(67, 20)
      Me.txtCuota.TabIndex = 17
      Me.txtCuota.Text = "0"
      Me.txtCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSituacion
      '
      Me.lblSituacion.AutoSize = True
      Me.lblSituacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblSituacion.LabelAsoc = Nothing
      Me.lblSituacion.Location = New System.Drawing.Point(315, 118)
      Me.lblSituacion.Name = "lblSituacion"
      Me.lblSituacion.Size = New System.Drawing.Size(51, 13)
      Me.lblSituacion.TabIndex = 18
      Me.lblSituacion.Text = "Situación"
      '
      'cmbSituacionTarjetaCupones
      '
      Me.cmbSituacionTarjetaCupones.BindearPropiedadControl = "SelectedValue"
      Me.cmbSituacionTarjetaCupones.BindearPropiedadEntidad = "IdSituacionCupon"
      Me.cmbSituacionTarjetaCupones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSituacionTarjetaCupones.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSituacionTarjetaCupones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSituacionTarjetaCupones.FormattingEnabled = True
      Me.cmbSituacionTarjetaCupones.IsPK = False
      Me.cmbSituacionTarjetaCupones.IsRequired = False
      Me.cmbSituacionTarjetaCupones.Key = Nothing
      Me.cmbSituacionTarjetaCupones.LabelAsoc = Me.lblSituacion
      Me.cmbSituacionTarjetaCupones.Location = New System.Drawing.Point(372, 115)
      Me.cmbSituacionTarjetaCupones.Name = "cmbSituacionTarjetaCupones"
      Me.cmbSituacionTarjetaCupones.Size = New System.Drawing.Size(170, 21)
      Me.cmbSituacionTarjetaCupones.TabIndex = 19
      '
      'txtNroCupon
      '
      Me.txtNroCupon.BindearPropiedadControl = "Text"
      Me.txtNroCupon.BindearPropiedadEntidad = "NumeroCupon"
      Me.txtNroCupon.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroCupon.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroCupon.Formato = ""
      Me.txtNroCupon.IsDecimal = False
      Me.txtNroCupon.IsNumber = False
      Me.txtNroCupon.IsPK = False
      Me.txtNroCupon.IsRequired = False
      Me.txtNroCupon.Key = ""
      Me.txtNroCupon.LabelAsoc = Me.lblNroCupon
      Me.txtNroCupon.Location = New System.Drawing.Point(277, 83)
      Me.txtNroCupon.MaxLength = 15
      Me.txtNroCupon.Name = "txtNroCupon"
      Me.txtNroCupon.Size = New System.Drawing.Size(115, 20)
      Me.txtNroCupon.TabIndex = 11
      Me.txtNroCupon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTarjeta
      '
      Me.lblTarjeta.AutoSize = True
      Me.lblTarjeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblTarjeta.LabelAsoc = Nothing
      Me.lblTarjeta.Location = New System.Drawing.Point(8, 56)
      Me.lblTarjeta.Name = "lblTarjeta"
      Me.lblTarjeta.Size = New System.Drawing.Size(40, 13)
      Me.lblTarjeta.TabIndex = 4
      Me.lblTarjeta.Text = "Tarjeta"
      '
      'cmbTarTarjeta
      '
      Me.cmbTarTarjeta.BindearPropiedadControl = "SelectedValue"
      Me.cmbTarTarjeta.BindearPropiedadEntidad = "IdTarjeta"
      Me.cmbTarTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTarTarjeta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTarTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTarTarjeta.FormattingEnabled = True
      Me.cmbTarTarjeta.IsPK = False
      Me.cmbTarTarjeta.IsRequired = False
      Me.cmbTarTarjeta.Key = Nothing
      Me.cmbTarTarjeta.LabelAsoc = Me.lblTarjeta
      Me.cmbTarTarjeta.Location = New System.Drawing.Point(57, 53)
      Me.cmbTarTarjeta.Name = "cmbTarTarjeta"
      Me.cmbTarTarjeta.Size = New System.Drawing.Size(211, 21)
      Me.cmbTarTarjeta.TabIndex = 5
      '
      'txtNumeroLote
      '
      Me.txtNumeroLote.BindearPropiedadControl = "Text"
      Me.txtNumeroLote.BindearPropiedadEntidad = "NumeroLote"
      Me.txtNumeroLote.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroLote.Formato = ""
      Me.txtNumeroLote.IsDecimal = False
      Me.txtNumeroLote.IsNumber = False
      Me.txtNumeroLote.IsPK = False
      Me.txtNumeroLote.IsRequired = False
      Me.txtNumeroLote.Key = ""
      Me.txtNumeroLote.LabelAsoc = Me.lblNumeroLote
      Me.txtNumeroLote.Location = New System.Drawing.Point(77, 83)
      Me.txtNumeroLote.MaxLength = 9
      Me.txtNumeroLote.Name = "txtNumeroLote"
      Me.txtNumeroLote.Size = New System.Drawing.Size(115, 20)
      Me.txtNumeroLote.TabIndex = 9
      Me.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroLote
      '
      Me.lblNumeroLote.AutoSize = True
      Me.lblNumeroLote.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNumeroLote.LabelAsoc = Nothing
      Me.lblNumeroLote.Location = New System.Drawing.Point(8, 86)
      Me.lblNumeroLote.Name = "lblNumeroLote"
      Me.lblNumeroLote.Size = New System.Drawing.Size(63, 13)
      Me.lblNumeroLote.TabIndex = 8
      Me.lblNumeroLote.Text = "Nro de Lote"
      '
      'dtpFechaEmision
      '
      Me.dtpFechaEmision.BindearPropiedadControl = "Value"
      Me.dtpFechaEmision.BindearPropiedadEntidad = "FechaEmision"
      Me.dtpFechaEmision.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaEmision.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEmision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEmision.IsPK = False
      Me.dtpFechaEmision.IsRequired = True
      Me.dtpFechaEmision.Key = ""
      Me.dtpFechaEmision.LabelAsoc = Me.lblFechaEmision
      Me.dtpFechaEmision.Location = New System.Drawing.Point(447, 83)
      Me.dtpFechaEmision.Name = "dtpFechaEmision"
      Me.dtpFechaEmision.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaEmision.TabIndex = 13
      Me.dtpFechaEmision.Value = New Date(2008, 10, 28, 0, 29, 13, 0)
      '
      'lblFechaEmision
      '
      Me.lblFechaEmision.AutoSize = True
      Me.lblFechaEmision.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblFechaEmision.LabelAsoc = Nothing
      Me.lblFechaEmision.Location = New System.Drawing.Point(398, 87)
      Me.lblFechaEmision.Name = "lblFechaEmision"
      Me.lblFechaEmision.Size = New System.Drawing.Size(43, 13)
      Me.lblFechaEmision.TabIndex = 12
      Me.lblFechaEmision.Text = "Emisión"
      '
      'grbEstado
      '
      Me.grbEstado.Controls.Add(Me.txtEstadoActual)
      Me.grbEstado.Controls.Add(Me.lblEstadoActual)
      Me.grbEstado.Location = New System.Drawing.Point(8, 163)
      Me.grbEstado.Name = "grbEstado"
      Me.grbEstado.Size = New System.Drawing.Size(558, 50)
      Me.grbEstado.TabIndex = 1
      Me.grbEstado.TabStop = False
      Me.grbEstado.Text = "Estado"
      '
      'txtEstadoActual
      '
      Me.txtEstadoActual.BindearPropiedadControl = "Text"
      Me.txtEstadoActual.BindearPropiedadEntidad = "IdEstadoTarjeta"
      Me.txtEstadoActual.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEstadoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEstadoActual.Formato = ""
      Me.txtEstadoActual.IsDecimal = False
      Me.txtEstadoActual.IsNumber = False
      Me.txtEstadoActual.IsPK = False
      Me.txtEstadoActual.IsRequired = False
      Me.txtEstadoActual.Key = ""
      Me.txtEstadoActual.LabelAsoc = Me.lblEstadoActual
      Me.txtEstadoActual.Location = New System.Drawing.Point(57, 19)
      Me.txtEstadoActual.MaxLength = 100
      Me.txtEstadoActual.Name = "txtEstadoActual"
      Me.txtEstadoActual.ReadOnly = True
      Me.txtEstadoActual.Size = New System.Drawing.Size(135, 20)
      Me.txtEstadoActual.TabIndex = 1
      Me.txtEstadoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblEstadoActual
      '
      Me.lblEstadoActual.AutoSize = True
      Me.lblEstadoActual.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblEstadoActual.LabelAsoc = Nothing
      Me.lblEstadoActual.Location = New System.Drawing.Point(11, 23)
      Me.lblEstadoActual.Name = "lblEstadoActual"
      Me.lblEstadoActual.Size = New System.Drawing.Size(37, 13)
      Me.lblEstadoActual.TabIndex = 0
      Me.lblEstadoActual.Text = "Actual"
      '
      'tbpIngresoCaja
      '
      Me.tbpIngresoCaja.BackColor = System.Drawing.SystemColors.Control
      Me.tbpIngresoCaja.Location = New System.Drawing.Point(4, 22)
      Me.tbpIngresoCaja.Name = "tbpIngresoCaja"
      Me.tbpIngresoCaja.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpIngresoCaja.Size = New System.Drawing.Size(590, 270)
      Me.tbpIngresoCaja.TabIndex = 3
      Me.tbpIngresoCaja.Text = "Ingreso por Caja"
      '
      'TarjetasCuponesDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(619, 355)
      Me.Controls.Add(Me.tbc_TarjetasCupones)
      Me.Name = "TarjetasCuponesDetalle"
      Me.Text = "CuponesDeTarjetasDetalle"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.tbc_TarjetasCupones, 0)
      Me.tbc_TarjetasCupones.ResumeLayout(False)
      Me.tbpDetalle.ResumeLayout(False)
      Me.grbDetalle.ResumeLayout(False)
      Me.grbDetalle.PerformLayout()
      Me.grbEstado.ResumeLayout(False)
      Me.grbEstado.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents tbc_TarjetasCupones As TabControl
   Friend WithEvents tbpDetalle As TabPage
   Friend WithEvents grbDetalle As GroupBox
   Friend WithEvents lblSituacion As Controles.Label
   Friend WithEvents cmbSituacionTarjetaCupones As Controles.ComboBox
   Friend WithEvents txtNroCupon As Controles.TextBox
   Friend WithEvents lblTarjeta As Controles.Label
   Friend WithEvents cmbTarTarjeta As Controles.ComboBox
   Friend WithEvents lblImporte As Controles.Label
   Friend WithEvents txtNumeroLote As Controles.TextBox
   Friend WithEvents lblNumeroLote As Controles.Label
   Friend WithEvents lblBanco As Controles.Label
   Friend WithEvents dtpFechaEmision As Controles.DateTimePicker
   Friend WithEvents lblFechaEmision As Controles.Label
   Friend WithEvents grbEstado As GroupBox
   Friend WithEvents txtEstadoActual As Controles.TextBox
   Friend WithEvents lblEstadoActual As Controles.Label
   Friend WithEvents tbpIngresoCaja As TabPage
    Friend WithEvents txtCuota As Controles.TextBox
    Friend WithEvents bscCliente As Controles.Buscador2
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents bscCodigoCliente As Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Controles.Label
   Friend WithEvents bscTarBanco As Controles.Buscador
   Friend WithEvents txtTarMonto As Controles.TextBox
   Friend WithEvents lblNroCupon As Controles.Label
   Friend WithEvents lblCuota As Controles.Label
End Class
