<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarjetasDetalle
   Inherits BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TarjetasDetalle))
      Me.chbHabilitada = New Eniac.Controles.CheckBox()
      Me.txtIdTarjeta = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.lblTipo = New Eniac.Controles.Label()
      Me.cmbTipo = New Eniac.Controles.ComboBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtTarCantDiasAcred = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.cmbCuentasBancarias = New Eniac.Controles.ComboBox()
      Me.gpbAcreditacion = New System.Windows.Forms.GroupBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.txtDiaMes = New Eniac.Controles.TextBox()
      Me.rbtDiaMes = New Eniac.Controles.RadioButton()
      Me.rbtPagoPosCorte = New Eniac.Controles.RadioButton()
      Me.rbtPagoPosVenta = New Eniac.Controles.RadioButton()
      Me.cmbDias = New Eniac.Controles.ComboBox()
      Me.chbAcreditacion = New System.Windows.Forms.CheckBox()
      Me.grpContabilidad = New System.Windows.Forms.GroupBox()
      Me.UcCuentas1 = New Eniac.Win.ucCuentas()
      Me.txtPorcIntereses = New Eniac.Controles.TextBox()
      Me.lblPorcIntereses = New Eniac.Controles.Label()
      Me.txtCantidadCuotas = New Eniac.Controles.TextBox()
      Me.lblCantidadCuotas = New Eniac.Controles.Label()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.bscProveedor = New Eniac.Controles.Buscador2()
        Me.gpbAcreditacion.SuspendLayout()
        Me.grpContabilidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(307, 381)
        Me.btnAceptar.TabIndex = 13
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(393, 381)
        Me.btnCancelar.TabIndex = 14
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(206, 381)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(149, 381)
        '
        'chbHabilitada
        '
        Me.chbHabilitada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbHabilitada.AutoSize = True
        Me.chbHabilitada.BindearPropiedadControl = "Checked"
        Me.chbHabilitada.BindearPropiedadEntidad = "Habilitada"
        Me.chbHabilitada.ForeColorFocus = System.Drawing.Color.Red
        Me.chbHabilitada.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbHabilitada.IsPK = False
        Me.chbHabilitada.IsRequired = False
        Me.chbHabilitada.Key = Nothing
        Me.chbHabilitada.LabelAsoc = Nothing
        Me.chbHabilitada.Location = New System.Drawing.Point(384, 12)
        Me.chbHabilitada.Name = "chbHabilitada"
        Me.chbHabilitada.Size = New System.Drawing.Size(73, 17)
        Me.chbHabilitada.TabIndex = 15
        Me.chbHabilitada.Text = "Habilitada"
        Me.chbHabilitada.UseVisualStyleBackColor = True
        '
        'txtIdTarjeta
        '
        Me.txtIdTarjeta.BindearPropiedadControl = "Text"
        Me.txtIdTarjeta.BindearPropiedadEntidad = "IdTarjeta"
        Me.txtIdTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTarjeta.Formato = ""
        Me.txtIdTarjeta.IsDecimal = False
        Me.txtIdTarjeta.IsNumber = True
        Me.txtIdTarjeta.IsPK = True
        Me.txtIdTarjeta.IsRequired = True
        Me.txtIdTarjeta.Key = ""
        Me.txtIdTarjeta.LabelAsoc = Me.lblId
        Me.txtIdTarjeta.Location = New System.Drawing.Point(87, 10)
        Me.txtIdTarjeta.MaxLength = 4
        Me.txtIdTarjeta.Name = "txtIdTarjeta"
        Me.txtIdTarjeta.Size = New System.Drawing.Size(62, 20)
        Me.txtIdTarjeta.TabIndex = 0
        Me.txtIdTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(20, 13)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 8
        Me.lblId.Text = "Codigo"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(20, 72)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 10
        Me.lblTipo.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.BindearPropiedadControl = ""
        Me.cmbTipo.BindearPropiedadEntidad = ""
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.IsPK = False
        Me.cmbTipo.IsRequired = False
        Me.cmbTipo.Key = Nothing
        Me.cmbTipo.LabelAsoc = Me.lblTipo
        Me.cmbTipo.Location = New System.Drawing.Point(87, 67)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(133, 21)
        Me.cmbTipo.TabIndex = 2
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(20, 41)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 9
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreTarjeta"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(87, 38)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(370, 20)
        Me.txtNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(5, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta depósito"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(7, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Acreditación"
        '
        'txtTarCantDiasAcred
        '
        Me.txtTarCantDiasAcred.BindearPropiedadControl = "Text"
        Me.txtTarCantDiasAcred.BindearPropiedadEntidad = "CantDiasAcredit"
        Me.txtTarCantDiasAcred.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarCantDiasAcred.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarCantDiasAcred.Formato = "0"
        Me.txtTarCantDiasAcred.IsDecimal = False
        Me.txtTarCantDiasAcred.IsNumber = True
        Me.txtTarCantDiasAcred.IsPK = False
        Me.txtTarCantDiasAcred.IsRequired = False
        Me.txtTarCantDiasAcred.Key = ""
        Me.txtTarCantDiasAcred.LabelAsoc = Nothing
        Me.txtTarCantDiasAcred.Location = New System.Drawing.Point(76, 71)
        Me.txtTarCantDiasAcred.MaxLength = 8
        Me.txtTarCantDiasAcred.Name = "txtTarCantDiasAcred"
        Me.txtTarCantDiasAcred.Size = New System.Drawing.Size(42, 20)
        Me.txtTarCantDiasAcred.TabIndex = 3
        Me.txtTarCantDiasAcred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(121, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "dias"
        '
        'cmbCuentasBancarias
        '
        Me.cmbCuentasBancarias.BindearPropiedadControl = "SelectedValue"
        Me.cmbCuentasBancarias.BindearPropiedadEntidad = "CuentaBancaria.IdCuentaBancaria"
        Me.cmbCuentasBancarias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentasBancarias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCuentasBancarias.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCuentasBancarias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCuentasBancarias.FormattingEnabled = True
        Me.cmbCuentasBancarias.IsPK = False
        Me.cmbCuentasBancarias.IsRequired = False
        Me.cmbCuentasBancarias.Key = Nothing
        Me.cmbCuentasBancarias.LabelAsoc = Nothing
        Me.cmbCuentasBancarias.Location = New System.Drawing.Point(95, 24)
        Me.cmbCuentasBancarias.Name = "cmbCuentasBancarias"
        Me.cmbCuentasBancarias.Size = New System.Drawing.Size(351, 21)
        Me.cmbCuentasBancarias.TabIndex = 1
        '
        'gpbAcreditacion
        '
        Me.gpbAcreditacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbAcreditacion.Controls.Add(Me.Label4)
        Me.gpbAcreditacion.Controls.Add(Me.txtDiaMes)
        Me.gpbAcreditacion.Controls.Add(Me.rbtDiaMes)
        Me.gpbAcreditacion.Controls.Add(Me.rbtPagoPosCorte)
        Me.gpbAcreditacion.Controls.Add(Me.rbtPagoPosVenta)
        Me.gpbAcreditacion.Controls.Add(Me.cmbDias)
        Me.gpbAcreditacion.Controls.Add(Me.cmbCuentasBancarias)
        Me.gpbAcreditacion.Controls.Add(Me.Label1)
        Me.gpbAcreditacion.Controls.Add(Me.Label3)
        Me.gpbAcreditacion.Controls.Add(Me.Label2)
        Me.gpbAcreditacion.Controls.Add(Me.txtTarCantDiasAcred)
        Me.gpbAcreditacion.Location = New System.Drawing.Point(11, 155)
        Me.gpbAcreditacion.Name = "gpbAcreditacion"
        Me.gpbAcreditacion.Size = New System.Drawing.Size(460, 137)
        Me.gpbAcreditacion.TabIndex = 6
        Me.gpbAcreditacion.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(304, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "de cada mes"
        '
        'txtDiaMes
        '
        Me.txtDiaMes.BindearPropiedadControl = "Text"
        Me.txtDiaMes.BindearPropiedadEntidad = "DiaMes"
        Me.txtDiaMes.Enabled = False
        Me.txtDiaMes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiaMes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiaMes.Formato = "0"
        Me.txtDiaMes.IsDecimal = False
        Me.txtDiaMes.IsNumber = True
        Me.txtDiaMes.IsPK = False
        Me.txtDiaMes.IsRequired = False
        Me.txtDiaMes.Key = ""
        Me.txtDiaMes.LabelAsoc = Nothing
        Me.txtDiaMes.Location = New System.Drawing.Point(254, 104)
        Me.txtDiaMes.MaxLength = 8
        Me.txtDiaMes.Name = "txtDiaMes"
        Me.txtDiaMes.Size = New System.Drawing.Size(42, 20)
        Me.txtDiaMes.TabIndex = 9
        Me.txtDiaMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbtDiaMes
        '
        Me.rbtDiaMes.AutoSize = True
        Me.rbtDiaMes.BindearPropiedadControl = "Checked"
        Me.rbtDiaMes.BindearPropiedadEntidad = "PagoDiaMes"
        Me.rbtDiaMes.ForeColorFocus = System.Drawing.Color.Red
        Me.rbtDiaMes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rbtDiaMes.IsPK = False
        Me.rbtDiaMes.IsRequired = False
        Me.rbtDiaMes.Key = Nothing
        Me.rbtDiaMes.LabelAsoc = Nothing
        Me.rbtDiaMes.Location = New System.Drawing.Point(197, 107)
        Me.rbtDiaMes.Name = "rbtDiaMes"
        Me.rbtDiaMes.Size = New System.Drawing.Size(53, 17)
        Me.rbtDiaMes.TabIndex = 8
        Me.rbtDiaMes.TabStop = True
        Me.rbtDiaMes.Text = "El día"
        Me.rbtDiaMes.UseVisualStyleBackColor = True
        '
        'rbtPagoPosCorte
        '
        Me.rbtPagoPosCorte.AutoSize = True
        Me.rbtPagoPosCorte.BindearPropiedadControl = "Checked"
        Me.rbtPagoPosCorte.BindearPropiedadEntidad = "PagoPosCorte"
        Me.rbtPagoPosCorte.ForeColorFocus = System.Drawing.Color.Red
        Me.rbtPagoPosCorte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rbtPagoPosCorte.IsPK = False
        Me.rbtPagoPosCorte.IsRequired = False
        Me.rbtPagoPosCorte.Key = Nothing
        Me.rbtPagoPosCorte.LabelAsoc = Nothing
        Me.rbtPagoPosCorte.Location = New System.Drawing.Point(197, 84)
        Me.rbtPagoPosCorte.Name = "rbtPagoPosCorte"
        Me.rbtPagoPosCorte.Size = New System.Drawing.Size(171, 17)
        Me.rbtPagoPosCorte.TabIndex = 6
        Me.rbtPagoPosCorte.TabStop = True
        Me.rbtPagoPosCorte.Text = "Pago Movimientos hasta último"
        Me.rbtPagoPosCorte.UseVisualStyleBackColor = True
        '
        'rbtPagoPosVenta
        '
        Me.rbtPagoPosVenta.AutoSize = True
        Me.rbtPagoPosVenta.BindearPropiedadControl = "Checked"
        Me.rbtPagoPosVenta.BindearPropiedadEntidad = "PagoPosVenta"
        Me.rbtPagoPosVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.rbtPagoPosVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rbtPagoPosVenta.IsPK = False
        Me.rbtPagoPosVenta.IsRequired = False
        Me.rbtPagoPosVenta.Key = Nothing
        Me.rbtPagoPosVenta.LabelAsoc = Nothing
        Me.rbtPagoPosVenta.Location = New System.Drawing.Point(197, 61)
        Me.rbtPagoPosVenta.Name = "rbtPagoPosVenta"
        Me.rbtPagoPosVenta.Size = New System.Drawing.Size(151, 17)
        Me.rbtPagoPosVenta.TabIndex = 5
        Me.rbtPagoPosVenta.TabStop = True
        Me.rbtPagoPosVenta.Text = "Posterior a fecha de Venta"
        Me.rbtPagoPosVenta.UseVisualStyleBackColor = True
        '
        'cmbDias
        '
        Me.cmbDias.BindearPropiedadControl = ""
        Me.cmbDias.BindearPropiedadEntidad = ""
        Me.cmbDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDias.Enabled = False
        Me.cmbDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDias.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDias.FormattingEnabled = True
        Me.cmbDias.IsPK = False
        Me.cmbDias.IsRequired = False
        Me.cmbDias.Key = Nothing
        Me.cmbDias.LabelAsoc = Nothing
        Me.cmbDias.Location = New System.Drawing.Point(368, 82)
        Me.cmbDias.Name = "cmbDias"
        Me.cmbDias.Size = New System.Drawing.Size(78, 21)
        Me.cmbDias.TabIndex = 7
        '
        'chbAcreditacion
        '
        Me.chbAcreditacion.AutoSize = True
        Me.chbAcreditacion.Location = New System.Drawing.Point(372, 72)
        Me.chbAcreditacion.Name = "chbAcreditacion"
        Me.chbAcreditacion.Size = New System.Drawing.Size(85, 17)
        Me.chbAcreditacion.TabIndex = 3
        Me.chbAcreditacion.Text = "Acreditación"
        Me.chbAcreditacion.UseVisualStyleBackColor = True
        '
        'grpContabilidad
        '
        Me.grpContabilidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContabilidad.Controls.Add(Me.UcCuentas1)
        Me.grpContabilidad.Location = New System.Drawing.Point(11, 298)
        Me.grpContabilidad.Name = "grpContabilidad"
        Me.grpContabilidad.Size = New System.Drawing.Size(460, 74)
        Me.grpContabilidad.TabIndex = 7
        Me.grpContabilidad.TabStop = False
        Me.grpContabilidad.Text = "Contabilidad"
        '
        'UcCuentas1
        '
        Me.UcCuentas1.Cuenta = Nothing
        Me.UcCuentas1.Location = New System.Drawing.Point(6, 32)
        Me.UcCuentas1.Name = "UcCuentas1"
        Me.UcCuentas1.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentas1.TabIndex = 0
        '
        'txtPorcIntereses
        '
        Me.txtPorcIntereses.BindearPropiedadControl = "Text"
        Me.txtPorcIntereses.BindearPropiedadEntidad = "PorcIntereses"
        Me.txtPorcIntereses.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcIntereses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcIntereses.Formato = "0"
        Me.txtPorcIntereses.IsDecimal = True
        Me.txtPorcIntereses.IsNumber = True
        Me.txtPorcIntereses.IsPK = False
        Me.txtPorcIntereses.IsRequired = True
        Me.txtPorcIntereses.Key = ""
        Me.txtPorcIntereses.LabelAsoc = Me.lblPorcIntereses
        Me.txtPorcIntereses.Location = New System.Drawing.Point(87, 94)
        Me.txtPorcIntereses.MaxLength = 8
        Me.txtPorcIntereses.Name = "txtPorcIntereses"
        Me.txtPorcIntereses.Size = New System.Drawing.Size(42, 20)
        Me.txtPorcIntereses.TabIndex = 4
        Me.txtPorcIntereses.Text = "0.00"
        Me.txtPorcIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcIntereses
        '
        Me.lblPorcIntereses.AutoSize = True
        Me.lblPorcIntereses.LabelAsoc = Nothing
        Me.lblPorcIntereses.Location = New System.Drawing.Point(20, 97)
        Me.lblPorcIntereses.Name = "lblPorcIntereses"
        Me.lblPorcIntereses.Size = New System.Drawing.Size(61, 13)
        Me.lblPorcIntereses.TabIndex = 11
        Me.lblPorcIntereses.Text = "% Intereses"
        '
        'txtCantidadCuotas
        '
        Me.txtCantidadCuotas.BindearPropiedadControl = "Text"
        Me.txtCantidadCuotas.BindearPropiedadEntidad = "CantidadCuotas"
        Me.txtCantidadCuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadCuotas.Formato = "0"
        Me.txtCantidadCuotas.IsDecimal = False
        Me.txtCantidadCuotas.IsNumber = True
        Me.txtCantidadCuotas.IsPK = False
        Me.txtCantidadCuotas.IsRequired = True
        Me.txtCantidadCuotas.Key = ""
        Me.txtCantidadCuotas.LabelAsoc = Me.lblCantidadCuotas
        Me.txtCantidadCuotas.Location = New System.Drawing.Point(265, 94)
        Me.txtCantidadCuotas.MaxLength = 8
        Me.txtCantidadCuotas.Name = "txtCantidadCuotas"
        Me.txtCantidadCuotas.Size = New System.Drawing.Size(42, 20)
        Me.txtCantidadCuotas.TabIndex = 5
        Me.txtCantidadCuotas.Text = "0"
        Me.txtCantidadCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadCuotas
        '
        Me.lblCantidadCuotas.AutoSize = True
        Me.lblCantidadCuotas.LabelAsoc = Nothing
        Me.lblCantidadCuotas.Location = New System.Drawing.Point(174, 97)
        Me.lblCantidadCuotas.Name = "lblCantidadCuotas"
        Me.lblCantidadCuotas.Size = New System.Drawing.Size(85, 13)
        Me.lblCantidadCuotas.TabIndex = 12
        Me.lblCantidadCuotas.Text = "Cantidad Cuotas"
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProveedor.BindearPropiedadControl = ""
        Me.bscCodigoProveedor.BindearPropiedadEntidad = ""
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
        Me.bscCodigoProveedor.LabelAsoc = Me.chbProveedor
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(102, 129)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(77, 20)
        Me.bscCodigoProveedor.TabIndex = 16
        '
        'chbProveedor
        '
        Me.chbProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbProveedor.AutoSize = True
        Me.chbProveedor.BindearPropiedadControl = ""
        Me.chbProveedor.BindearPropiedadEntidad = ""
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Location = New System.Drawing.Point(21, 132)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 18
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'bscProveedor
        '
        Me.bscProveedor.ActivarFiltroEnGrilla = True
        Me.bscProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ConfigBuscador = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.Enabled = False
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Me.chbProveedor
        Me.bscProveedor.Location = New System.Drawing.Point(185, 129)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(272, 20)
        Me.bscProveedor.TabIndex = 17
        '
        'TarjetasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 416)
        Me.Controls.Add(Me.chbProveedor)
        Me.Controls.Add(Me.bscCodigoProveedor)
        Me.Controls.Add(Me.bscProveedor)
        Me.Controls.Add(Me.grpContabilidad)
        Me.Controls.Add(Me.chbAcreditacion)
        Me.Controls.Add(Me.gpbAcreditacion)
        Me.Controls.Add(Me.chbHabilitada)
        Me.Controls.Add(Me.txtIdTarjeta)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblCantidadCuotas)
        Me.Controls.Add(Me.lblPorcIntereses)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCantidadCuotas)
        Me.Controls.Add(Me.txtPorcIntereses)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TarjetasDetalle"
        Me.Text = "Tarjeta"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtPorcIntereses, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadCuotas, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblPorcIntereses, 0)
        Me.Controls.SetChildIndex(Me.lblCantidadCuotas, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.cmbTipo, 0)
        Me.Controls.SetChildIndex(Me.lblTipo, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtIdTarjeta, 0)
        Me.Controls.SetChildIndex(Me.chbHabilitada, 0)
        Me.Controls.SetChildIndex(Me.gpbAcreditacion, 0)
        Me.Controls.SetChildIndex(Me.chbAcreditacion, 0)
        Me.Controls.SetChildIndex(Me.grpContabilidad, 0)
        Me.Controls.SetChildIndex(Me.bscProveedor, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoProveedor, 0)
        Me.Controls.SetChildIndex(Me.chbProveedor, 0)
        Me.gpbAcreditacion.ResumeLayout(False)
        Me.gpbAcreditacion.PerformLayout()
        Me.grpContabilidad.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chbHabilitada As Eniac.Controles.CheckBox
   Friend WithEvents txtIdTarjeta As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents lblTipo As Eniac.Controles.Label
   Friend WithEvents cmbTipo As Eniac.Controles.ComboBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtTarCantDiasAcred As Eniac.Controles.TextBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cmbCuentasBancarias As Eniac.Controles.ComboBox
   Friend WithEvents gpbAcreditacion As System.Windows.Forms.GroupBox
   Friend WithEvents chbAcreditacion As System.Windows.Forms.CheckBox
   Friend WithEvents cmbDias As Eniac.Controles.ComboBox
   Friend WithEvents rbtPagoPosCorte As Eniac.Controles.RadioButton
   Friend WithEvents rbtPagoPosVenta As Eniac.Controles.RadioButton
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents txtDiaMes As Eniac.Controles.TextBox
   Friend WithEvents rbtDiaMes As Eniac.Controles.RadioButton
   Friend WithEvents grpContabilidad As System.Windows.Forms.GroupBox
   Friend WithEvents UcCuentas1 As Eniac.Win.ucCuentas
   Friend WithEvents txtPorcIntereses As Eniac.Controles.TextBox
   Friend WithEvents lblPorcIntereses As Eniac.Controles.Label
   Friend WithEvents txtCantidadCuotas As Eniac.Controles.TextBox
   Friend WithEvents lblCantidadCuotas As Eniac.Controles.Label
    Friend WithEvents bscCodigoProveedor As Controles.Buscador2
    Friend WithEvents bscProveedor As Controles.Buscador2
    Friend WithEvents chbProveedor As Controles.CheckBox
End Class
