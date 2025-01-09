<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidosAdminCambioUbicacion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PedidosAdminCambioUbicacion))
      Me.grbDetalle = New System.Windows.Forms.GroupBox()
        Me.lblStockReserva = New Eniac.Controles.Label()
        Me.txtStockReserva = New Eniac.Controles.TextBox()
        Me.lblStockActual = New Eniac.Controles.Label()
        Me.txtStockActual = New Eniac.Controles.TextBox()
        Me.lblCantidadAfectada = New Eniac.Controles.Label()
        Me.txtCantidadAfectada = New Eniac.Controles.TextBox()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbUbicacion = New Eniac.Controles.ComboBox()
        Me.lblUbicacionOrigen = New Eniac.Controles.Label()
        Me.cmbDepositos = New Eniac.Controles.ComboBox()
        Me.lblDepositoOrigen = New Eniac.Controles.Label()
        Me.lblSucursalOrigen = New Eniac.Controles.Label()
        Me.gpbAgregarUbicacion = New System.Windows.Forms.GroupBox()
        Me.Label5 = New Eniac.Controles.Label()
        Me.txtStockReservaII = New Eniac.Controles.TextBox()
        Me.Label6 = New Eniac.Controles.Label()
        Me.txtStockActualII = New Eniac.Controles.TextBox()
        Me.Label7 = New Eniac.Controles.Label()
        Me.txtCantidadAfectadaII = New Eniac.Controles.TextBox()
        Me.lblSucursalII = New Eniac.Controles.Label()
        Me.cmbUbicacionII = New Eniac.Controles.ComboBox()
        Me.Label9 = New Eniac.Controles.Label()
        Me.cmbDepositosII = New Eniac.Controles.ComboBox()
        Me.Label10 = New Eniac.Controles.Label()
        Me.Label11 = New Eniac.Controles.Label()
        Me.chbAgregaUbicacion = New System.Windows.Forms.CheckBox()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grbDetalle.SuspendLayout()
        Me.gpbAgregarUbicacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbDetalle
        '
        Me.grbDetalle.Controls.Add(Me.lblStockReserva)
        Me.grbDetalle.Controls.Add(Me.txtStockReserva)
        Me.grbDetalle.Controls.Add(Me.lblStockActual)
        Me.grbDetalle.Controls.Add(Me.txtStockActual)
        Me.grbDetalle.Controls.Add(Me.lblCantidadAfectada)
        Me.grbDetalle.Controls.Add(Me.txtCantidadAfectada)
        Me.grbDetalle.Controls.Add(Me.lblSucursal)
        Me.grbDetalle.Controls.Add(Me.cmbUbicacion)
        Me.grbDetalle.Controls.Add(Me.lblUbicacionOrigen)
        Me.grbDetalle.Controls.Add(Me.cmbDepositos)
        Me.grbDetalle.Controls.Add(Me.lblDepositoOrigen)
        Me.grbDetalle.Controls.Add(Me.lblSucursalOrigen)
        Me.grbDetalle.Location = New System.Drawing.Point(10, 11)
        Me.grbDetalle.Name = "grbDetalle"
        Me.grbDetalle.Size = New System.Drawing.Size(296, 196)
        Me.grbDetalle.TabIndex = 0
        Me.grbDetalle.TabStop = False
        Me.grbDetalle.Text = "Detalle"
        '
        'lblStockReserva
        '
        Me.lblStockReserva.AutoSize = True
        Me.lblStockReserva.LabelAsoc = Nothing
        Me.lblStockReserva.Location = New System.Drawing.Point(23, 160)
        Me.lblStockReserva.Name = "lblStockReserva"
        Me.lblStockReserva.Size = New System.Drawing.Size(125, 13)
        Me.lblStockReserva.TabIndex = 62
        Me.lblStockReserva.Text = "Stock luego de Reservar"
        '
        'txtStockReserva
        '
        Me.txtStockReserva.BindearPropiedadControl = "Text"
        Me.txtStockReserva.BindearPropiedadEntidad = "CodigoUbicacion"
        Me.txtStockReserva.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStockReserva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStockReserva.Formato = ""
        Me.txtStockReserva.IsDecimal = True
        Me.txtStockReserva.IsNumber = True
        Me.txtStockReserva.IsPK = False
        Me.txtStockReserva.IsRequired = False
        Me.txtStockReserva.Key = ""
        Me.txtStockReserva.LabelAsoc = Me.lblStockReserva
        Me.txtStockReserva.Location = New System.Drawing.Point(154, 156)
        Me.txtStockReserva.MaxLength = 30
        Me.txtStockReserva.Name = "txtStockReserva"
        Me.txtStockReserva.ReadOnly = True
        Me.txtStockReserva.Size = New System.Drawing.Size(117, 20)
        Me.txtStockReserva.TabIndex = 63
        Me.txtStockReserva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStockActual
        '
        Me.lblStockActual.AutoSize = True
        Me.lblStockActual.LabelAsoc = Nothing
        Me.lblStockActual.Location = New System.Drawing.Point(23, 134)
        Me.lblStockActual.Name = "lblStockActual"
        Me.lblStockActual.Size = New System.Drawing.Size(68, 13)
        Me.lblStockActual.TabIndex = 60
        Me.lblStockActual.Text = "Stock Actual"
        '
        'txtStockActual
        '
        Me.txtStockActual.BindearPropiedadControl = "Text"
        Me.txtStockActual.BindearPropiedadEntidad = "CodigoUbicacion"
        Me.txtStockActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStockActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStockActual.Formato = ""
        Me.txtStockActual.IsDecimal = True
        Me.txtStockActual.IsNumber = True
        Me.txtStockActual.IsPK = False
        Me.txtStockActual.IsRequired = False
        Me.txtStockActual.Key = ""
        Me.txtStockActual.LabelAsoc = Me.lblStockActual
        Me.txtStockActual.Location = New System.Drawing.Point(154, 130)
        Me.txtStockActual.MaxLength = 30
        Me.txtStockActual.Name = "txtStockActual"
        Me.txtStockActual.ReadOnly = True
        Me.txtStockActual.Size = New System.Drawing.Size(117, 20)
        Me.txtStockActual.TabIndex = 61
        Me.txtStockActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadAfectada
        '
        Me.lblCantidadAfectada.AutoSize = True
        Me.lblCantidadAfectada.LabelAsoc = Nothing
        Me.lblCantidadAfectada.Location = New System.Drawing.Point(23, 108)
        Me.lblCantidadAfectada.Name = "lblCantidadAfectada"
        Me.lblCantidadAfectada.Size = New System.Drawing.Size(78, 13)
        Me.lblCantidadAfectada.TabIndex = 58
        Me.lblCantidadAfectada.Text = "Cant. Afectada"
        '
        'txtCantidadAfectada
        '
        Me.txtCantidadAfectada.BindearPropiedadControl = "Text"
        Me.txtCantidadAfectada.BindearPropiedadEntidad = "CodigoUbicacion"
        Me.txtCantidadAfectada.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadAfectada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadAfectada.Formato = ""
        Me.txtCantidadAfectada.IsDecimal = True
        Me.txtCantidadAfectada.IsNumber = True
        Me.txtCantidadAfectada.IsPK = False
        Me.txtCantidadAfectada.IsRequired = False
        Me.txtCantidadAfectada.Key = ""
        Me.txtCantidadAfectada.LabelAsoc = Me.lblCantidadAfectada
        Me.txtCantidadAfectada.Location = New System.Drawing.Point(154, 104)
        Me.txtCantidadAfectada.MaxLength = 30
        Me.txtCantidadAfectada.Name = "txtCantidadAfectada"
        Me.txtCantidadAfectada.Size = New System.Drawing.Size(117, 20)
        Me.txtCantidadAfectada.TabIndex = 59
        Me.txtCantidadAfectada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(71, 23)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(10, 13)
        Me.lblSucursal.TabIndex = 39
        Me.lblSucursal.Text = "-"
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbUbicacion.BindearPropiedadEntidad = "IdDeposito"
        Me.cmbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacion.FormattingEnabled = True
        Me.cmbUbicacion.IsPK = True
        Me.cmbUbicacion.IsRequired = False
        Me.cmbUbicacion.Key = Nothing
        Me.cmbUbicacion.LabelAsoc = Me.lblUbicacionOrigen
        Me.cmbUbicacion.Location = New System.Drawing.Point(73, 74)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.Size = New System.Drawing.Size(198, 21)
        Me.cmbUbicacion.TabIndex = 10
        Me.cmbUbicacion.TabStop = False
        '
        'lblUbicacionOrigen
        '
        Me.lblUbicacionOrigen.AutoSize = True
        Me.lblUbicacionOrigen.LabelAsoc = Nothing
        Me.lblUbicacionOrigen.Location = New System.Drawing.Point(13, 77)
        Me.lblUbicacionOrigen.Name = "lblUbicacionOrigen"
        Me.lblUbicacionOrigen.Size = New System.Drawing.Size(55, 13)
        Me.lblUbicacionOrigen.TabIndex = 9
        Me.lblUbicacionOrigen.Text = "Ubicacion"
        '
        'cmbDepositos
        '
        Me.cmbDepositos.BindearPropiedadControl = "SelectedValue"
        Me.cmbDepositos.BindearPropiedadEntidad = "IdDeposito"
        Me.cmbDepositos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositos.FormattingEnabled = True
        Me.cmbDepositos.IsPK = True
        Me.cmbDepositos.IsRequired = False
        Me.cmbDepositos.Key = Nothing
        Me.cmbDepositos.LabelAsoc = Me.lblDepositoOrigen
        Me.cmbDepositos.Location = New System.Drawing.Point(73, 46)
        Me.cmbDepositos.Name = "cmbDepositos"
        Me.cmbDepositos.Size = New System.Drawing.Size(198, 21)
        Me.cmbDepositos.TabIndex = 8
        Me.cmbDepositos.TabStop = False
        '
        'lblDepositoOrigen
        '
        Me.lblDepositoOrigen.AutoSize = True
        Me.lblDepositoOrigen.LabelAsoc = Nothing
        Me.lblDepositoOrigen.Location = New System.Drawing.Point(12, 50)
        Me.lblDepositoOrigen.Name = "lblDepositoOrigen"
        Me.lblDepositoOrigen.Size = New System.Drawing.Size(49, 13)
        Me.lblDepositoOrigen.TabIndex = 7
        Me.lblDepositoOrigen.Text = "Depósito"
        '
        'lblSucursalOrigen
        '
        Me.lblSucursalOrigen.AutoSize = True
        Me.lblSucursalOrigen.LabelAsoc = Nothing
        Me.lblSucursalOrigen.Location = New System.Drawing.Point(12, 23)
        Me.lblSucursalOrigen.Name = "lblSucursalOrigen"
        Me.lblSucursalOrigen.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursalOrigen.TabIndex = 5
        Me.lblSucursalOrigen.Text = "Sucursal"
        '
        'gpbAgregarUbicacion
        '
        Me.gpbAgregarUbicacion.Controls.Add(Me.Label5)
        Me.gpbAgregarUbicacion.Controls.Add(Me.txtStockReservaII)
        Me.gpbAgregarUbicacion.Controls.Add(Me.Label6)
        Me.gpbAgregarUbicacion.Controls.Add(Me.txtStockActualII)
        Me.gpbAgregarUbicacion.Controls.Add(Me.Label7)
        Me.gpbAgregarUbicacion.Controls.Add(Me.txtCantidadAfectadaII)
        Me.gpbAgregarUbicacion.Controls.Add(Me.lblSucursalII)
        Me.gpbAgregarUbicacion.Controls.Add(Me.cmbUbicacionII)
        Me.gpbAgregarUbicacion.Controls.Add(Me.Label9)
        Me.gpbAgregarUbicacion.Controls.Add(Me.cmbDepositosII)
        Me.gpbAgregarUbicacion.Controls.Add(Me.Label10)
        Me.gpbAgregarUbicacion.Controls.Add(Me.Label11)
        Me.gpbAgregarUbicacion.Enabled = False
        Me.gpbAgregarUbicacion.Location = New System.Drawing.Point(312, 12)
        Me.gpbAgregarUbicacion.Name = "gpbAgregarUbicacion"
        Me.gpbAgregarUbicacion.Size = New System.Drawing.Size(299, 196)
        Me.gpbAgregarUbicacion.TabIndex = 1
        Me.gpbAgregarUbicacion.TabStop = False
        Me.gpbAgregarUbicacion.Text = "                                     "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(35, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Stock luego de Reservar"
        '
        'txtStockReservaII
        '
        Me.txtStockReservaII.BindearPropiedadControl = "Text"
        Me.txtStockReservaII.BindearPropiedadEntidad = "CodigoUbicacion"
        Me.txtStockReservaII.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStockReservaII.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStockReservaII.Formato = "N2"
        Me.txtStockReservaII.IsDecimal = True
        Me.txtStockReservaII.IsNumber = True
        Me.txtStockReservaII.IsPK = False
        Me.txtStockReservaII.IsRequired = False
        Me.txtStockReservaII.Key = ""
        Me.txtStockReservaII.LabelAsoc = Me.Label5
        Me.txtStockReservaII.Location = New System.Drawing.Point(166, 152)
        Me.txtStockReservaII.MaxLength = 30
        Me.txtStockReservaII.Name = "txtStockReservaII"
        Me.txtStockReservaII.ReadOnly = True
        Me.txtStockReservaII.Size = New System.Drawing.Size(117, 20)
        Me.txtStockReservaII.TabIndex = 57
        Me.txtStockReservaII.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(35, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Stock Actual"
        '
        'txtStockActualII
        '
        Me.txtStockActualII.BindearPropiedadControl = "Text"
        Me.txtStockActualII.BindearPropiedadEntidad = "CodigoUbicacion"
        Me.txtStockActualII.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStockActualII.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStockActualII.Formato = "N2"
        Me.txtStockActualII.IsDecimal = True
        Me.txtStockActualII.IsNumber = True
        Me.txtStockActualII.IsPK = False
        Me.txtStockActualII.IsRequired = False
        Me.txtStockActualII.Key = ""
        Me.txtStockActualII.LabelAsoc = Me.Label6
        Me.txtStockActualII.Location = New System.Drawing.Point(166, 126)
        Me.txtStockActualII.MaxLength = 30
        Me.txtStockActualII.Name = "txtStockActualII"
        Me.txtStockActualII.ReadOnly = True
        Me.txtStockActualII.Size = New System.Drawing.Size(117, 20)
        Me.txtStockActualII.TabIndex = 55
        Me.txtStockActualII.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(35, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Cant. Afectada"
        '
        'txtCantidadAfectadaII
        '
        Me.txtCantidadAfectadaII.BindearPropiedadControl = "Text"
        Me.txtCantidadAfectadaII.BindearPropiedadEntidad = "CodigoUbicacion"
        Me.txtCantidadAfectadaII.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadAfectadaII.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadAfectadaII.Formato = "N2"
        Me.txtCantidadAfectadaII.IsDecimal = True
        Me.txtCantidadAfectadaII.IsNumber = True
        Me.txtCantidadAfectadaII.IsPK = False
        Me.txtCantidadAfectadaII.IsRequired = False
        Me.txtCantidadAfectadaII.Key = ""
        Me.txtCantidadAfectadaII.LabelAsoc = Me.Label7
        Me.txtCantidadAfectadaII.Location = New System.Drawing.Point(166, 100)
        Me.txtCantidadAfectadaII.MaxLength = 30
        Me.txtCantidadAfectadaII.Name = "txtCantidadAfectadaII"
        Me.txtCantidadAfectadaII.Size = New System.Drawing.Size(117, 20)
        Me.txtCantidadAfectadaII.TabIndex = 53
        Me.txtCantidadAfectadaII.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSucursalII
        '
        Me.lblSucursalII.AutoSize = True
        Me.lblSucursalII.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSucursalII.LabelAsoc = Nothing
        Me.lblSucursalII.Location = New System.Drawing.Point(83, 22)
        Me.lblSucursalII.Name = "lblSucursalII"
        Me.lblSucursalII.Size = New System.Drawing.Size(10, 13)
        Me.lblSucursalII.TabIndex = 51
        Me.lblSucursalII.Text = "-"
        '
        'cmbUbicacionII
        '
        Me.cmbUbicacionII.BindearPropiedadControl = "SelectedValue"
        Me.cmbUbicacionII.BindearPropiedadEntidad = "IdDeposito"
        Me.cmbUbicacionII.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionII.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionII.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionII.FormattingEnabled = True
        Me.cmbUbicacionII.IsPK = True
        Me.cmbUbicacionII.IsRequired = False
        Me.cmbUbicacionII.Key = Nothing
        Me.cmbUbicacionII.LabelAsoc = Me.Label9
        Me.cmbUbicacionII.Location = New System.Drawing.Point(85, 73)
        Me.cmbUbicacionII.Name = "cmbUbicacionII"
        Me.cmbUbicacionII.Size = New System.Drawing.Size(198, 21)
        Me.cmbUbicacionII.TabIndex = 50
        Me.cmbUbicacionII.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.LabelAsoc = Nothing
        Me.Label9.Location = New System.Drawing.Point(25, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Ubicacion"
        '
        'cmbDepositosII
        '
        Me.cmbDepositosII.BindearPropiedadControl = "SelectedValue"
        Me.cmbDepositosII.BindearPropiedadEntidad = "IdDeposito"
        Me.cmbDepositosII.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositosII.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositosII.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositosII.FormattingEnabled = True
        Me.cmbDepositosII.IsPK = True
        Me.cmbDepositosII.IsRequired = False
        Me.cmbDepositosII.Key = Nothing
        Me.cmbDepositosII.LabelAsoc = Me.Label10
        Me.cmbDepositosII.Location = New System.Drawing.Point(85, 45)
        Me.cmbDepositosII.Name = "cmbDepositosII"
        Me.cmbDepositosII.Size = New System.Drawing.Size(198, 21)
        Me.cmbDepositosII.TabIndex = 48
        Me.cmbDepositosII.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.LabelAsoc = Nothing
        Me.Label10.Location = New System.Drawing.Point(24, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Depósito"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.LabelAsoc = Nothing
        Me.Label11.Location = New System.Drawing.Point(24, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Sucursal"
        '
        'chbAgregaUbicacion
        '
        Me.chbAgregaUbicacion.AutoSize = True
        Me.chbAgregaUbicacion.Location = New System.Drawing.Point(325, 9)
        Me.chbAgregaUbicacion.Name = "chbAgregaUbicacion"
        Me.chbAgregaUbicacion.Size = New System.Drawing.Size(114, 17)
        Me.chbAgregaUbicacion.TabIndex = 2
        Me.chbAgregaUbicacion.Text = "Agregar Ubicacion"
        Me.chbAgregaUbicacion.UseVisualStyleBackColor = True
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(445, 214)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(531, 214)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'PedidosAdminCambioUbicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 254)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.grbDetalle)
        Me.Controls.Add(Me.chbAgregaUbicacion)
        Me.Controls.Add(Me.gpbAgregarUbicacion)
        Me.Name = "PedidosAdminCambioUbicacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Ubicacion"
        Me.grbDetalle.ResumeLayout(False)
        Me.grbDetalle.PerformLayout()
        Me.gpbAgregarUbicacion.ResumeLayout(False)
        Me.gpbAgregarUbicacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grbDetalle As GroupBox
   Friend WithEvents gpbAgregarUbicacion As GroupBox
   Friend WithEvents chbAgregaUbicacion As CheckBox
   Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents cmbUbicacion As Controles.ComboBox
   Friend WithEvents lblUbicacionOrigen As Controles.Label
   Friend WithEvents cmbDepositos As Controles.ComboBox
   Friend WithEvents lblDepositoOrigen As Controles.Label
   Friend WithEvents lblSucursalOrigen As Controles.Label
   Friend WithEvents lblSucursal As Controles.Label
   Friend WithEvents lblStockReserva As Controles.Label
   Friend WithEvents txtStockReserva As Controles.TextBox
   Friend WithEvents lblStockActual As Controles.Label
   Friend WithEvents txtStockActual As Controles.TextBox
   Friend WithEvents lblCantidadAfectada As Controles.Label
   Friend WithEvents txtCantidadAfectada As Controles.TextBox
   Friend WithEvents Label5 As Controles.Label
   Friend WithEvents txtStockReservaII As Controles.TextBox
   Friend WithEvents Label6 As Controles.Label
   Friend WithEvents txtStockActualII As Controles.TextBox
   Friend WithEvents Label7 As Controles.Label
   Friend WithEvents txtCantidadAfectadaII As Controles.TextBox
   Friend WithEvents lblSucursalII As Controles.Label
   Friend WithEvents cmbUbicacionII As Controles.ComboBox
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents cmbDepositosII As Controles.ComboBox
   Friend WithEvents Label10 As Controles.Label
   Friend WithEvents Label11 As Controles.Label
End Class
