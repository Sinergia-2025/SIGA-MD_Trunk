<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosPersonalDetalle
    Inherits Eniac.Win.BaseDetalle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form DesigneR.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosPersonalDetalle))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.cmbLocalidad = New Eniac.Controles.ComboBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.txtDireccion = New Eniac.Controles.TextBox()
      Me.lblCuil = New Eniac.Controles.Label()
      Me.txtCuil = New Eniac.Controles.TextBox()
      Me.cmbTipoDoc = New Eniac.Controles.ComboBox()
      Me.lblTipoDoc = New Eniac.Controles.Label()
      Me.txtNroDoc = New Eniac.Controles.TextBox()
      Me.lblNroDoc = New Eniac.Controles.Label()
      Me.lblCategoriaFiscal = New Eniac.Controles.Label()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.dtpFechaNacimiento = New Eniac.Controles.DateTimePicker()
      Me.lblFechaNac = New Eniac.Controles.Label()
      Me.txtLegaoMinTrabajo = New Eniac.Controles.TextBox()
      Me.lblLegajoMinTrabajo = New Eniac.Controles.Label()
      Me.dtpFechaIngreso = New Eniac.Controles.DateTimePicker()
      Me.lblFechaIngreso = New Eniac.Controles.Label()
      Me.dtpFechaBaja = New Eniac.Controles.DateTimePicker()
      Me.txtCodObraSocial = New Eniac.Controles.TextBox()
      Me.lblCodObraSocial = New Eniac.Controles.Label()
      Me.txtSueldoBasico = New Eniac.Controles.TextBox()
      Me.lblSueldoBasico = New Eniac.Controles.Label()
      Me.lblEstadoCivil = New Eniac.Controles.Label()
      Me.cmbEstadoCivil = New Eniac.Controles.ComboBox()
      Me.grpSexo = New System.Windows.Forms.GroupBox()
      Me.RadioSexoFemenino = New System.Windows.Forms.RadioButton()
      Me.RadioSexoMasculino = New System.Windows.Forms.RadioButton()
      Me.cmbObraSocial = New Eniac.Controles.ComboBox()
      Me.lblObraSocial = New Eniac.Controles.Label()
      Me.txtLegajo = New Eniac.Controles.TextBox()
      Me.lblLegajo = New Eniac.Controles.Label()
      Me.grbInfoIngreso = New System.Windows.Forms.GroupBox()
      Me.chbFechaBaja = New Eniac.Controles.CheckBox()
      Me.cmbLugarActividad = New Eniac.Controles.ComboBox()
      Me.lblLugarActividad = New Eniac.Controles.Label()
      Me.cmbMotivoBaja = New Eniac.Controles.ComboBox()
      Me.lblMotivoBaja = New Eniac.Controles.Label()
      Me.grbDatosFamiliares = New System.Windows.Forms.GroupBox()
      Me.txtDatosFamiliares = New Eniac.Controles.TextBox()
      Me.grbDatosBancarios = New System.Windows.Forms.GroupBox()
      Me.txtCBU = New Eniac.Controles.TextBox()
      Me.lblCBU = New Eniac.Controles.Label()
      Me.txtNroCuenta = New Eniac.Controles.TextBox()
      Me.lblNroCuenta = New Eniac.Controles.Label()
      Me.lblClaseDeCuenta = New Eniac.Controles.Label()
      Me.cmbClaseDeCuenta = New Eniac.Controles.ComboBox()
      Me.lblBanco = New Eniac.Controles.Label()
      Me.cmbBanco = New Eniac.Controles.ComboBox()
      Me.gpbHijos = New System.Windows.Forms.GroupBox()
      Me.cmbVinculoFamiliar = New Eniac.Controles.ComboBox()
      Me.cmbSexoFamiliar = New Eniac.Controles.ComboBox()
      Me.txtCuilFamiliar = New System.Windows.Forms.TextBox()
      Me.dtpFechaNacFamiliar = New Eniac.Controles.DateTimePicker()
      Me.btnRefrescarFamiliar = New System.Windows.Forms.Button()
      Me.btnEliminarFamiliar = New System.Windows.Forms.Button()
      Me.btnInsertarFamiliar = New System.Windows.Forms.Button()
      Me.lblVinculo = New System.Windows.Forms.Label()
      Me.lblSexo = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.CuilHijo = New System.Windows.Forms.Label()
      Me.txtNombreFamiliar = New System.Windows.Forms.TextBox()
      Me.dgvPersonalFamiliares = New System.Windows.Forms.DataGridView()
      Me.IdLegajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoVinculoFamiliar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cuil = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreFamiliar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaNacimientoFamiliar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.SexoFamiliar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreVinculoFamiliar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNacionalidad = New Eniac.Controles.Label()
        Me.cmbNacionalidad = New Eniac.Controles.ComboBox()
        Me.grpSexo.SuspendLayout()
        Me.grbInfoIngreso.SuspendLayout()
        Me.grbDatosFamiliares.SuspendLayout()
        Me.grbDatosBancarios.SuspendLayout()
        Me.gpbHijos.SuspendLayout()
        CType(Me.dgvPersonalFamiliares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(510, 554)
        Me.btnAceptar.TabIndex = 21
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(596, 554)
        Me.btnCancelar.TabIndex = 22
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(409, 554)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(349, 554)
        '
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.LabelAsoc = Nothing
        Me.lblLocalidad.Location = New System.Drawing.Point(225, 77)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lblLocalidad.TabIndex = 10
        Me.lblLocalidad.Text = "Localidad"
        '
        'cmbLocalidad
        '
        Me.cmbLocalidad.BindearPropiedadControl = "SelectedValue"
        Me.cmbLocalidad.BindearPropiedadEntidad = "IdLocalidad"
        Me.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLocalidad.FormattingEnabled = True
        Me.cmbLocalidad.IsPK = False
        Me.cmbLocalidad.IsRequired = True
        Me.cmbLocalidad.Key = Nothing
        Me.cmbLocalidad.LabelAsoc = Me.lblLocalidad
        Me.cmbLocalidad.Location = New System.Drawing.Point(225, 90)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(142, 21)
        Me.cmbLocalidad.TabIndex = 5
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(298, 50)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 6
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombrePersonal"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(347, 46)
        Me.txtNombre.MaxLength = 100
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(324, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.LabelAsoc = Nothing
        Me.lblDireccion.Location = New System.Drawing.Point(12, 76)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
        Me.lblDireccion.TabIndex = 8
        Me.lblDireccion.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.BindearPropiedadControl = "Text"
        Me.txtDireccion.BindearPropiedadEntidad = "Domicilio"
        Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDireccion.Formato = ""
        Me.txtDireccion.IsDecimal = False
        Me.txtDireccion.IsNumber = False
        Me.txtDireccion.IsPK = False
        Me.txtDireccion.IsRequired = True
        Me.txtDireccion.Key = ""
        Me.txtDireccion.LabelAsoc = Me.lblDireccion
        Me.txtDireccion.Location = New System.Drawing.Point(15, 90)
        Me.txtDireccion.MaxLength = 100
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(204, 20)
        Me.txtDireccion.TabIndex = 4
        '
        'lblCuil
        '
        Me.lblCuil.AutoSize = True
        Me.lblCuil.LabelAsoc = Nothing
        Me.lblCuil.Location = New System.Drawing.Point(533, 16)
        Me.lblCuil.Name = "lblCuil"
        Me.lblCuil.Size = New System.Drawing.Size(31, 13)
        Me.lblCuil.TabIndex = 10
        Me.lblCuil.Text = "CUIL"
        '
        'txtCuil
        '
        Me.txtCuil.BindearPropiedadControl = "Text"
        Me.txtCuil.BindearPropiedadEntidad = "Cuil"
        Me.txtCuil.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuil.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuil.Formato = ""
        Me.txtCuil.IsDecimal = False
        Me.txtCuil.IsNumber = True
        Me.txtCuil.IsPK = False
        Me.txtCuil.IsRequired = True
        Me.txtCuil.Key = ""
        Me.txtCuil.LabelAsoc = Me.lblCuil
        Me.txtCuil.Location = New System.Drawing.Point(536, 30)
        Me.txtCuil.MaxLength = 11
        Me.txtCuil.Name = "txtCuil"
        Me.txtCuil.Size = New System.Drawing.Size(98, 20)
        Me.txtCuil.TabIndex = 6
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoDoc.BindearPropiedadEntidad = "TipoDocPersonal"
        Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDoc.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.IsPK = False
        Me.cmbTipoDoc.IsRequired = True
        Me.cmbTipoDoc.Key = Nothing
        Me.cmbTipoDoc.LabelAsoc = Me.lblTipoDoc
        Me.cmbTipoDoc.Location = New System.Drawing.Point(74, 46)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(62, 21)
        Me.cmbTipoDoc.TabIndex = 1
        '
        'lblTipoDoc
        '
        Me.lblTipoDoc.AutoSize = True
        Me.lblTipoDoc.LabelAsoc = Nothing
        Me.lblTipoDoc.Location = New System.Drawing.Point(12, 50)
        Me.lblTipoDoc.Name = "lblTipoDoc"
        Me.lblTipoDoc.Size = New System.Drawing.Size(54, 13)
        Me.lblTipoDoc.TabIndex = 2
        Me.lblTipoDoc.Text = "Tipo Doc."
        '
        'txtNroDoc
        '
        Me.txtNroDoc.BindearPropiedadControl = "Text"
        Me.txtNroDoc.BindearPropiedadEntidad = "NroDocPersonal"
        Me.txtNroDoc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDoc.Formato = ""
        Me.txtNroDoc.IsDecimal = False
        Me.txtNroDoc.IsNumber = True
        Me.txtNroDoc.IsPK = False
        Me.txtNroDoc.IsRequired = True
        Me.txtNroDoc.Key = ""
        Me.txtNroDoc.LabelAsoc = Me.lblNroDoc
        Me.txtNroDoc.Location = New System.Drawing.Point(192, 46)
        Me.txtNroDoc.MaxLength = 12
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.Size = New System.Drawing.Size(100, 20)
        Me.txtNroDoc.TabIndex = 2
        Me.txtNroDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroDoc
        '
        Me.lblNroDoc.AutoSize = True
        Me.lblNroDoc.LabelAsoc = Nothing
        Me.lblNroDoc.Location = New System.Drawing.Point(142, 50)
        Me.lblNroDoc.Name = "lblNroDoc"
        Me.lblNroDoc.Size = New System.Drawing.Size(53, 13)
        Me.lblNroDoc.TabIndex = 4
        Me.lblNroDoc.Text = "Nro. Doc."
        '
        'lblCategoriaFiscal
        '
        Me.lblCategoriaFiscal.AutoSize = True
        Me.lblCategoriaFiscal.LabelAsoc = Nothing
        Me.lblCategoriaFiscal.Location = New System.Drawing.Point(268, 54)
        Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
        Me.lblCategoriaFiscal.Size = New System.Drawing.Size(52, 13)
        Me.lblCategoriaFiscal.TabIndex = 16
        Me.lblCategoriaFiscal.Text = "Categoria"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoria.BindearPropiedadEntidad = "IdCategoria"
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.IsPK = False
        Me.cmbCategoria.IsRequired = True
        Me.cmbCategoria.Key = Nothing
        Me.cmbCategoria.LabelAsoc = Me.lblCategoriaFiscal
        Me.cmbCategoria.Location = New System.Drawing.Point(271, 69)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(163, 21)
        Me.cmbCategoria.TabIndex = 9
        '
        'dtpFechaNacimiento
        '
        Me.dtpFechaNacimiento.BindearPropiedadControl = "Value"
        Me.dtpFechaNacimiento.BindearPropiedadEntidad = "FechaNacimiento"
        Me.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaNacimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaNacimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaNacimiento.IsPK = False
        Me.dtpFechaNacimiento.IsRequired = False
        Me.dtpFechaNacimiento.Key = ""
        Me.dtpFechaNacimiento.LabelAsoc = Me.lblFechaNac
        Me.dtpFechaNacimiento.Location = New System.Drawing.Point(484, 90)
        Me.dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        Me.dtpFechaNacimiento.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaNacimiento.TabIndex = 7
        '
        'lblFechaNac
        '
        Me.lblFechaNac.AutoSize = True
        Me.lblFechaNac.LabelAsoc = Nothing
        Me.lblFechaNac.Location = New System.Drawing.Point(481, 77)
        Me.lblFechaNac.Name = "lblFechaNac"
        Me.lblFechaNac.Size = New System.Drawing.Size(93, 13)
        Me.lblFechaNac.TabIndex = 14
        Me.lblFechaNac.Text = "Fecha Nacimiento"
        '
        'txtLegaoMinTrabajo
        '
        Me.txtLegaoMinTrabajo.BindearPropiedadControl = "Text"
        Me.txtLegaoMinTrabajo.BindearPropiedadEntidad = "LegajoMinTrabajo"
        Me.txtLegaoMinTrabajo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLegaoMinTrabajo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLegaoMinTrabajo.Formato = ""
        Me.txtLegaoMinTrabajo.IsDecimal = False
        Me.txtLegaoMinTrabajo.IsNumber = True
        Me.txtLegaoMinTrabajo.IsPK = False
        Me.txtLegaoMinTrabajo.IsRequired = False
        Me.txtLegaoMinTrabajo.Key = ""
        Me.txtLegaoMinTrabajo.LabelAsoc = Me.lblLegajoMinTrabajo
        Me.txtLegaoMinTrabajo.Location = New System.Drawing.Point(371, 31)
        Me.txtLegaoMinTrabajo.MaxLength = 8
        Me.txtLegaoMinTrabajo.Name = "txtLegaoMinTrabajo"
        Me.txtLegaoMinTrabajo.Size = New System.Drawing.Size(63, 20)
        Me.txtLegaoMinTrabajo.TabIndex = 4
        Me.txtLegaoMinTrabajo.Text = "0"
        Me.txtLegaoMinTrabajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLegajoMinTrabajo
        '
        Me.lblLegajoMinTrabajo.AutoSize = True
        Me.lblLegajoMinTrabajo.LabelAsoc = Nothing
        Me.lblLegajoMinTrabajo.Location = New System.Drawing.Point(351, 16)
        Me.lblLegajoMinTrabajo.Name = "lblLegajoMinTrabajo"
        Me.lblLegajoMinTrabajo.Size = New System.Drawing.Size(101, 13)
        Me.lblLegajoMinTrabajo.TabIndex = 6
        Me.lblLegajoMinTrabajo.Text = "Legajo Min. Trabajo"
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.BindearPropiedadControl = "Value"
        Me.dtpFechaIngreso.BindearPropiedadEntidad = "FechaIngreso"
        Me.dtpFechaIngreso.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIngreso.IsPK = False
        Me.dtpFechaIngreso.IsRequired = False
        Me.dtpFechaIngreso.Key = ""
        Me.dtpFechaIngreso.LabelAsoc = Me.lblFechaIngreso
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(9, 31)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaIngreso.TabIndex = 0
        '
        'lblFechaIngreso
        '
        Me.lblFechaIngreso.AutoSize = True
        Me.lblFechaIngreso.LabelAsoc = Nothing
        Me.lblFechaIngreso.Location = New System.Drawing.Point(6, 16)
        Me.lblFechaIngreso.Name = "lblFechaIngreso"
        Me.lblFechaIngreso.Size = New System.Drawing.Size(75, 13)
        Me.lblFechaIngreso.TabIndex = 0
        Me.lblFechaIngreso.Text = "Fecha Ingreso"
        '
        'dtpFechaBaja
        '
        Me.dtpFechaBaja.BindearPropiedadControl = "Value"
        Me.dtpFechaBaja.BindearPropiedadEntidad = "FechaBaja"
        Me.dtpFechaBaja.Checked = False
        Me.dtpFechaBaja.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaBaja.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaBaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaBaja.IsPK = False
        Me.dtpFechaBaja.IsRequired = False
        Me.dtpFechaBaja.Key = ""
        Me.dtpFechaBaja.LabelAsoc = Nothing
        Me.dtpFechaBaja.Location = New System.Drawing.Point(100, 32)
        Me.dtpFechaBaja.Name = "dtpFechaBaja"
        Me.dtpFechaBaja.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaBaja.TabIndex = 2
        '
        'txtCodObraSocial
        '
        Me.txtCodObraSocial.BindearPropiedadControl = "Text"
        Me.txtCodObraSocial.BindearPropiedadEntidad = "CodObraSocial"
        Me.txtCodObraSocial.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodObraSocial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodObraSocial.Formato = ""
        Me.txtCodObraSocial.IsDecimal = False
        Me.txtCodObraSocial.IsNumber = True
        Me.txtCodObraSocial.IsPK = False
        Me.txtCodObraSocial.IsRequired = False
        Me.txtCodObraSocial.Key = ""
        Me.txtCodObraSocial.LabelAsoc = Me.lblCodObraSocial
        Me.txtCodObraSocial.Location = New System.Drawing.Point(185, 70)
        Me.txtCodObraSocial.MaxLength = 6
        Me.txtCodObraSocial.Name = "txtCodObraSocial"
        Me.txtCodObraSocial.Size = New System.Drawing.Size(74, 20)
        Me.txtCodObraSocial.TabIndex = 8
        Me.txtCodObraSocial.Text = "0"
        Me.txtCodObraSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodObraSocial
        '
        Me.lblCodObraSocial.AutoSize = True
        Me.lblCodObraSocial.LabelAsoc = Nothing
        Me.lblCodObraSocial.Location = New System.Drawing.Point(179, 55)
        Me.lblCodObraSocial.Name = "lblCodObraSocial"
        Me.lblCodObraSocial.Size = New System.Drawing.Size(87, 13)
        Me.lblCodObraSocial.TabIndex = 14
        Me.lblCodObraSocial.Text = "Cod. Obra Social"
        '
        'txtSueldoBasico
        '
        Me.txtSueldoBasico.BindearPropiedadControl = "Text"
        Me.txtSueldoBasico.BindearPropiedadEntidad = "SueldoBasico"
        Me.txtSueldoBasico.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSueldoBasico.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSueldoBasico.Formato = ""
        Me.txtSueldoBasico.IsDecimal = True
        Me.txtSueldoBasico.IsNumber = True
        Me.txtSueldoBasico.IsPK = False
        Me.txtSueldoBasico.IsRequired = True
        Me.txtSueldoBasico.Key = ""
        Me.txtSueldoBasico.LabelAsoc = Me.lblSueldoBasico
        Me.txtSueldoBasico.Location = New System.Drawing.Point(452, 30)
        Me.txtSueldoBasico.MaxLength = 10
        Me.txtSueldoBasico.Name = "txtSueldoBasico"
        Me.txtSueldoBasico.Size = New System.Drawing.Size(72, 20)
        Me.txtSueldoBasico.TabIndex = 5
        Me.txtSueldoBasico.Text = "0"
        Me.txtSueldoBasico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSueldoBasico
        '
        Me.lblSueldoBasico.AutoSize = True
        Me.lblSueldoBasico.LabelAsoc = Nothing
        Me.lblSueldoBasico.Location = New System.Drawing.Point(449, 16)
        Me.lblSueldoBasico.Name = "lblSueldoBasico"
        Me.lblSueldoBasico.Size = New System.Drawing.Size(75, 13)
        Me.lblSueldoBasico.TabIndex = 8
        Me.lblSueldoBasico.Text = "Sueldo Basico"
        '
        'lblEstadoCivil
        '
        Me.lblEstadoCivil.AutoSize = True
        Me.lblEstadoCivil.LabelAsoc = Nothing
        Me.lblEstadoCivil.Location = New System.Drawing.Point(370, 77)
        Me.lblEstadoCivil.Name = "lblEstadoCivil"
        Me.lblEstadoCivil.Size = New System.Drawing.Size(62, 13)
        Me.lblEstadoCivil.TabIndex = 12
        Me.lblEstadoCivil.Text = "Estado Civil"
        '
        'cmbEstadoCivil
        '
        Me.cmbEstadoCivil.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoCivil.BindearPropiedadEntidad = "idEstadoCivil"
        Me.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCivil.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoCivil.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoCivil.FormattingEnabled = True
        Me.cmbEstadoCivil.IsPK = False
        Me.cmbEstadoCivil.IsRequired = True
        Me.cmbEstadoCivil.Key = Nothing
        Me.cmbEstadoCivil.LabelAsoc = Me.lblEstadoCivil
        Me.cmbEstadoCivil.Location = New System.Drawing.Point(373, 90)
        Me.cmbEstadoCivil.Name = "cmbEstadoCivil"
        Me.cmbEstadoCivil.Size = New System.Drawing.Size(106, 21)
        Me.cmbEstadoCivil.TabIndex = 6
        '
        'grpSexo
        '
        Me.grpSexo.Controls.Add(Me.RadioSexoFemenino)
        Me.grpSexo.Controls.Add(Me.RadioSexoMasculino)
        Me.grpSexo.Location = New System.Drawing.Point(575, 69)
        Me.grpSexo.Name = "grpSexo"
        Me.grpSexo.Size = New System.Drawing.Size(96, 43)
        Me.grpSexo.TabIndex = 16
        Me.grpSexo.TabStop = False
        '
        'RadioSexoFemenino
        '
        Me.RadioSexoFemenino.AutoSize = True
        Me.RadioSexoFemenino.Location = New System.Drawing.Point(12, 23)
        Me.RadioSexoFemenino.Name = "RadioSexoFemenino"
        Me.RadioSexoFemenino.Size = New System.Drawing.Size(71, 17)
        Me.RadioSexoFemenino.TabIndex = 1
        Me.RadioSexoFemenino.TabStop = True
        Me.RadioSexoFemenino.Text = "Femenino"
        Me.RadioSexoFemenino.UseVisualStyleBackColor = True
        '
        'RadioSexoMasculino
        '
        Me.RadioSexoMasculino.AutoSize = True
        Me.RadioSexoMasculino.Location = New System.Drawing.Point(12, 8)
        Me.RadioSexoMasculino.Name = "RadioSexoMasculino"
        Me.RadioSexoMasculino.Size = New System.Drawing.Size(73, 17)
        Me.RadioSexoMasculino.TabIndex = 0
        Me.RadioSexoMasculino.TabStop = True
        Me.RadioSexoMasculino.Text = "Masculino"
        Me.RadioSexoMasculino.UseVisualStyleBackColor = True
        '
        'cmbObraSocial
        '
        Me.cmbObraSocial.BindearPropiedadControl = "SelectedValue"
        Me.cmbObraSocial.BindearPropiedadEntidad = "idObraSocial"
        Me.cmbObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbObraSocial.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbObraSocial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbObraSocial.FormattingEnabled = True
        Me.cmbObraSocial.IsPK = False
        Me.cmbObraSocial.IsRequired = True
        Me.cmbObraSocial.Key = Nothing
        Me.cmbObraSocial.LabelAsoc = Me.lblObraSocial
        Me.cmbObraSocial.Location = New System.Drawing.Point(9, 70)
        Me.cmbObraSocial.Name = "cmbObraSocial"
        Me.cmbObraSocial.Size = New System.Drawing.Size(165, 21)
        Me.cmbObraSocial.TabIndex = 7
        '
        'lblObraSocial
        '
        Me.lblObraSocial.AutoSize = True
        Me.lblObraSocial.LabelAsoc = Nothing
        Me.lblObraSocial.Location = New System.Drawing.Point(6, 54)
        Me.lblObraSocial.Name = "lblObraSocial"
        Me.lblObraSocial.Size = New System.Drawing.Size(62, 13)
        Me.lblObraSocial.TabIndex = 12
        Me.lblObraSocial.Text = "Obra Social"
        '
        'txtLegajo
        '
        Me.txtLegajo.BindearPropiedadControl = "Text"
        Me.txtLegajo.BindearPropiedadEntidad = "idLegajo"
        Me.txtLegajo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLegajo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLegajo.Formato = ""
        Me.txtLegajo.IsDecimal = False
        Me.txtLegajo.IsNumber = True
        Me.txtLegajo.IsPK = True
        Me.txtLegajo.IsRequired = True
        Me.txtLegajo.Key = ""
        Me.txtLegajo.LabelAsoc = Me.lblLegajo
        Me.txtLegajo.Location = New System.Drawing.Point(74, 16)
        Me.txtLegajo.MaxLength = 12
        Me.txtLegajo.Name = "txtLegajo"
        Me.txtLegajo.Size = New System.Drawing.Size(62, 20)
        Me.txtLegajo.TabIndex = 0
        Me.txtLegajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLegajo
        '
        Me.lblLegajo.AutoSize = True
        Me.lblLegajo.LabelAsoc = Nothing
        Me.lblLegajo.Location = New System.Drawing.Point(12, 20)
        Me.lblLegajo.Name = "lblLegajo"
        Me.lblLegajo.Size = New System.Drawing.Size(39, 13)
        Me.lblLegajo.TabIndex = 0
        Me.lblLegajo.Text = "Legajo"
        '
        'grbInfoIngreso
        '
        Me.grbInfoIngreso.Controls.Add(Me.chbFechaBaja)
        Me.grbInfoIngreso.Controls.Add(Me.cmbLugarActividad)
        Me.grbInfoIngreso.Controls.Add(Me.lblLugarActividad)
        Me.grbInfoIngreso.Controls.Add(Me.cmbMotivoBaja)
        Me.grbInfoIngreso.Controls.Add(Me.lblMotivoBaja)
        Me.grbInfoIngreso.Controls.Add(Me.dtpFechaIngreso)
        Me.grbInfoIngreso.Controls.Add(Me.lblFechaIngreso)
        Me.grbInfoIngreso.Controls.Add(Me.cmbObraSocial)
        Me.grbInfoIngreso.Controls.Add(Me.lblObraSocial)
        Me.grbInfoIngreso.Controls.Add(Me.dtpFechaBaja)
        Me.grbInfoIngreso.Controls.Add(Me.txtCodObraSocial)
        Me.grbInfoIngreso.Controls.Add(Me.txtLegaoMinTrabajo)
        Me.grbInfoIngreso.Controls.Add(Me.lblCodObraSocial)
        Me.grbInfoIngreso.Controls.Add(Me.cmbCategoria)
        Me.grbInfoIngreso.Controls.Add(Me.lblLegajoMinTrabajo)
        Me.grbInfoIngreso.Controls.Add(Me.lblCategoriaFiscal)
        Me.grbInfoIngreso.Controls.Add(Me.txtSueldoBasico)
        Me.grbInfoIngreso.Controls.Add(Me.lblSueldoBasico)
        Me.grbInfoIngreso.Controls.Add(Me.lblCuil)
        Me.grbInfoIngreso.Controls.Add(Me.txtCuil)
        Me.grbInfoIngreso.Location = New System.Drawing.Point(15, 152)
        Me.grbInfoIngreso.Name = "grbInfoIngreso"
        Me.grbInfoIngreso.Size = New System.Drawing.Size(656, 99)
        Me.grbInfoIngreso.TabIndex = 17
        Me.grbInfoIngreso.TabStop = False
        '
        'chbFechaBaja
        '
        Me.chbFechaBaja.AutoSize = True
        Me.chbFechaBaja.BindearPropiedadControl = Nothing
        Me.chbFechaBaja.BindearPropiedadEntidad = Nothing
        Me.chbFechaBaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaBaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaBaja.IsPK = False
        Me.chbFechaBaja.IsRequired = False
        Me.chbFechaBaja.Key = Nothing
        Me.chbFechaBaja.LabelAsoc = Nothing
        Me.chbFechaBaja.Location = New System.Drawing.Point(100, 15)
        Me.chbFechaBaja.Name = "chbFechaBaja"
        Me.chbFechaBaja.Size = New System.Drawing.Size(80, 17)
        Me.chbFechaBaja.TabIndex = 1
        Me.chbFechaBaja.Text = "Fecha Baja"
        Me.chbFechaBaja.UseVisualStyleBackColor = True
        '
        'cmbLugarActividad
        '
        Me.cmbLugarActividad.BindearPropiedadControl = "SelectedValue"
        Me.cmbLugarActividad.BindearPropiedadEntidad = "LugarActividad.IdLugarActividad"
        Me.cmbLugarActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLugarActividad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLugarActividad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLugarActividad.FormattingEnabled = True
        Me.cmbLugarActividad.IsPK = False
        Me.cmbLugarActividad.IsRequired = True
        Me.cmbLugarActividad.Key = Nothing
        Me.cmbLugarActividad.LabelAsoc = Me.lblLugarActividad
        Me.cmbLugarActividad.Location = New System.Drawing.Point(452, 69)
        Me.cmbLugarActividad.Name = "cmbLugarActividad"
        Me.cmbLugarActividad.Size = New System.Drawing.Size(181, 21)
        Me.cmbLugarActividad.TabIndex = 10
        '
        'lblLugarActividad
        '
        Me.lblLugarActividad.AutoSize = True
        Me.lblLugarActividad.LabelAsoc = Nothing
        Me.lblLugarActividad.Location = New System.Drawing.Point(449, 54)
        Me.lblLugarActividad.Name = "lblLugarActividad"
        Me.lblLugarActividad.Size = New System.Drawing.Size(95, 13)
        Me.lblLugarActividad.TabIndex = 18
        Me.lblLugarActividad.Text = "Lugar de actividad"
        '
        'cmbMotivoBaja
        '
        Me.cmbMotivoBaja.BindearPropiedadControl = "SelectedValue"
        Me.cmbMotivoBaja.BindearPropiedadEntidad = "MotivoBaja.IdMotivoBaja"
        Me.cmbMotivoBaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivoBaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMotivoBaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMotivoBaja.FormattingEnabled = True
        Me.cmbMotivoBaja.IsPK = False
        Me.cmbMotivoBaja.IsRequired = False
        Me.cmbMotivoBaja.Key = Nothing
        Me.cmbMotivoBaja.LabelAsoc = Me.lblMotivoBaja
        Me.cmbMotivoBaja.Location = New System.Drawing.Point(210, 30)
        Me.cmbMotivoBaja.Name = "cmbMotivoBaja"
        Me.cmbMotivoBaja.Size = New System.Drawing.Size(142, 21)
        Me.cmbMotivoBaja.TabIndex = 3
        '
        'lblMotivoBaja
        '
        Me.lblMotivoBaja.AutoSize = True
        Me.lblMotivoBaja.LabelAsoc = Nothing
        Me.lblMotivoBaja.Location = New System.Drawing.Point(207, 16)
        Me.lblMotivoBaja.Name = "lblMotivoBaja"
        Me.lblMotivoBaja.Size = New System.Drawing.Size(63, 13)
        Me.lblMotivoBaja.TabIndex = 4
        Me.lblMotivoBaja.Text = "Motivo Baja"
        '
        'grbDatosFamiliares
        '
        Me.grbDatosFamiliares.Controls.Add(Me.txtDatosFamiliares)
        Me.grbDatosFamiliares.Location = New System.Drawing.Point(15, 254)
        Me.grbDatosFamiliares.Name = "grbDatosFamiliares"
        Me.grbDatosFamiliares.Size = New System.Drawing.Size(656, 60)
        Me.grbDatosFamiliares.TabIndex = 18
        Me.grbDatosFamiliares.TabStop = False
        Me.grbDatosFamiliares.Text = "Datos Familiares"
        '
        'txtDatosFamiliares
        '
        Me.txtDatosFamiliares.BindearPropiedadControl = "Text"
        Me.txtDatosFamiliares.BindearPropiedadEntidad = "DatosFamiliares"
        Me.txtDatosFamiliares.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDatosFamiliares.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDatosFamiliares.Formato = ""
        Me.txtDatosFamiliares.IsDecimal = False
        Me.txtDatosFamiliares.IsNumber = False
        Me.txtDatosFamiliares.IsPK = False
        Me.txtDatosFamiliares.IsRequired = False
        Me.txtDatosFamiliares.Key = ""
        Me.txtDatosFamiliares.LabelAsoc = Nothing
        Me.txtDatosFamiliares.Location = New System.Drawing.Point(9, 19)
        Me.txtDatosFamiliares.MaxLength = 300
        Me.txtDatosFamiliares.Multiline = True
        Me.txtDatosFamiliares.Name = "txtDatosFamiliares"
        Me.txtDatosFamiliares.Size = New System.Drawing.Size(625, 35)
        Me.txtDatosFamiliares.TabIndex = 0
        '
        'grbDatosBancarios
        '
        Me.grbDatosBancarios.Controls.Add(Me.txtCBU)
        Me.grbDatosBancarios.Controls.Add(Me.lblCBU)
        Me.grbDatosBancarios.Controls.Add(Me.txtNroCuenta)
        Me.grbDatosBancarios.Controls.Add(Me.lblNroCuenta)
        Me.grbDatosBancarios.Controls.Add(Me.lblClaseDeCuenta)
        Me.grbDatosBancarios.Controls.Add(Me.cmbClaseDeCuenta)
        Me.grbDatosBancarios.Controls.Add(Me.lblBanco)
        Me.grbDatosBancarios.Controls.Add(Me.cmbBanco)
        Me.grbDatosBancarios.Location = New System.Drawing.Point(15, 316)
        Me.grbDatosBancarios.Name = "grbDatosBancarios"
        Me.grbDatosBancarios.Size = New System.Drawing.Size(656, 61)
        Me.grbDatosBancarios.TabIndex = 19
        Me.grbDatosBancarios.TabStop = False
        Me.grbDatosBancarios.Text = "Datos Bancarios"
        '
        'txtCBU
        '
        Me.txtCBU.BindearPropiedadControl = "Text"
        Me.txtCBU.BindearPropiedadEntidad = "CBU"
        Me.txtCBU.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCBU.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCBU.Formato = ""
        Me.txtCBU.IsDecimal = False
        Me.txtCBU.IsNumber = True
        Me.txtCBU.IsPK = False
        Me.txtCBU.IsRequired = False
        Me.txtCBU.Key = ""
        Me.txtCBU.LabelAsoc = Me.lblCBU
        Me.txtCBU.Location = New System.Drawing.Point(470, 32)
        Me.txtCBU.MaxLength = 22
        Me.txtCBU.Name = "txtCBU"
        Me.txtCBU.Size = New System.Drawing.Size(155, 20)
        Me.txtCBU.TabIndex = 3
        '
        'lblCBU
        '
        Me.lblCBU.AutoSize = True
        Me.lblCBU.LabelAsoc = Nothing
        Me.lblCBU.Location = New System.Drawing.Point(470, 16)
        Me.lblCBU.Name = "lblCBU"
        Me.lblCBU.Size = New System.Drawing.Size(155, 13)
        Me.lblCBU.TabIndex = 6
        Me.lblCBU.Text = "Clave Bancaria Uniforme (CBU)"
        '
        'txtNroCuenta
        '
        Me.txtNroCuenta.BindearPropiedadControl = "Text"
        Me.txtNroCuenta.BindearPropiedadEntidad = "NumeroCuentaBancaria"
        Me.txtNroCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroCuenta.Formato = ""
        Me.txtNroCuenta.IsDecimal = False
        Me.txtNroCuenta.IsNumber = False
        Me.txtNroCuenta.IsPK = False
        Me.txtNroCuenta.IsRequired = False
        Me.txtNroCuenta.Key = ""
        Me.txtNroCuenta.LabelAsoc = Me.lblNroCuenta
        Me.txtNroCuenta.Location = New System.Drawing.Point(339, 32)
        Me.txtNroCuenta.MaxLength = 12
        Me.txtNroCuenta.Name = "txtNroCuenta"
        Me.txtNroCuenta.Size = New System.Drawing.Size(125, 20)
        Me.txtNroCuenta.TabIndex = 2
        Me.txtNroCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroCuenta
        '
        Me.lblNroCuenta.AutoSize = True
        Me.lblNroCuenta.LabelAsoc = Nothing
        Me.lblNroCuenta.Location = New System.Drawing.Point(336, 16)
        Me.lblNroCuenta.Name = "lblNroCuenta"
        Me.lblNroCuenta.Size = New System.Drawing.Size(64, 13)
        Me.lblNroCuenta.TabIndex = 4
        Me.lblNroCuenta.Text = "Nro. Cuenta"
        '
        'lblClaseDeCuenta
        '
        Me.lblClaseDeCuenta.AutoSize = True
        Me.lblClaseDeCuenta.LabelAsoc = Nothing
        Me.lblClaseDeCuenta.Location = New System.Drawing.Point(189, 16)
        Me.lblClaseDeCuenta.Name = "lblClaseDeCuenta"
        Me.lblClaseDeCuenta.Size = New System.Drawing.Size(85, 13)
        Me.lblClaseDeCuenta.TabIndex = 2
        Me.lblClaseDeCuenta.Text = "Clase de Cuenta"
        '
        'cmbClaseDeCuenta
        '
        Me.cmbClaseDeCuenta.BindearPropiedadControl = "SelectedValue"
        Me.cmbClaseDeCuenta.BindearPropiedadEntidad = "CuentaBancariaClase.IdCuentaBancariaClase"
        Me.cmbClaseDeCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClaseDeCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbClaseDeCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbClaseDeCuenta.FormattingEnabled = True
        Me.cmbClaseDeCuenta.IsPK = False
        Me.cmbClaseDeCuenta.IsRequired = False
        Me.cmbClaseDeCuenta.Key = Nothing
        Me.cmbClaseDeCuenta.LabelAsoc = Me.lblClaseDeCuenta
        Me.cmbClaseDeCuenta.Location = New System.Drawing.Point(192, 32)
        Me.cmbClaseDeCuenta.Name = "cmbClaseDeCuenta"
        Me.cmbClaseDeCuenta.Size = New System.Drawing.Size(141, 21)
        Me.cmbClaseDeCuenta.TabIndex = 1
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.LabelAsoc = Nothing
        Me.lblBanco.Location = New System.Drawing.Point(6, 16)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(38, 13)
        Me.lblBanco.TabIndex = 0
        Me.lblBanco.Text = "Banco"
        '
        'cmbBanco
        '
        Me.cmbBanco.BindearPropiedadControl = "SelectedValue"
        Me.cmbBanco.BindearPropiedadEntidad = "Banco.IdBanco"
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.IsPK = False
        Me.cmbBanco.IsRequired = False
        Me.cmbBanco.Key = Nothing
        Me.cmbBanco.LabelAsoc = Me.lblBanco
        Me.cmbBanco.Location = New System.Drawing.Point(9, 32)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(177, 21)
        Me.cmbBanco.TabIndex = 0
        '
        'gpbHijos
        '
        Me.gpbHijos.Controls.Add(Me.cmbVinculoFamiliar)
        Me.gpbHijos.Controls.Add(Me.cmbSexoFamiliar)
        Me.gpbHijos.Controls.Add(Me.txtCuilFamiliar)
        Me.gpbHijos.Controls.Add(Me.dtpFechaNacFamiliar)
        Me.gpbHijos.Controls.Add(Me.btnRefrescarFamiliar)
        Me.gpbHijos.Controls.Add(Me.btnEliminarFamiliar)
        Me.gpbHijos.Controls.Add(Me.btnInsertarFamiliar)
        Me.gpbHijos.Controls.Add(Me.lblVinculo)
        Me.gpbHijos.Controls.Add(Me.lblSexo)
        Me.gpbHijos.Controls.Add(Me.Label3)
        Me.gpbHijos.Controls.Add(Me.Label2)
        Me.gpbHijos.Controls.Add(Me.CuilHijo)
        Me.gpbHijos.Controls.Add(Me.txtNombreFamiliar)
        Me.gpbHijos.Controls.Add(Me.dgvPersonalFamiliares)
        Me.gpbHijos.Location = New System.Drawing.Point(15, 377)
        Me.gpbHijos.Name = "gpbHijos"
        Me.gpbHijos.Size = New System.Drawing.Size(656, 168)
        Me.gpbHijos.TabIndex = 20
        Me.gpbHijos.TabStop = False
        Me.gpbHijos.Text = "Hijos"
        '
        'cmbVinculoFamiliar
        '
        Me.cmbVinculoFamiliar.BindearPropiedadControl = ""
        Me.cmbVinculoFamiliar.BindearPropiedadEntidad = ""
        Me.cmbVinculoFamiliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVinculoFamiliar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVinculoFamiliar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVinculoFamiliar.FormattingEnabled = True
        Me.cmbVinculoFamiliar.IsPK = False
        Me.cmbVinculoFamiliar.IsRequired = False
        Me.cmbVinculoFamiliar.Key = Nothing
        Me.cmbVinculoFamiliar.LabelAsoc = Nothing
        Me.cmbVinculoFamiliar.Location = New System.Drawing.Point(484, 32)
        Me.cmbVinculoFamiliar.Name = "cmbVinculoFamiliar"
        Me.cmbVinculoFamiliar.Size = New System.Drawing.Size(120, 21)
        Me.cmbVinculoFamiliar.TabIndex = 4
        '
        'cmbSexoFamiliar
        '
        Me.cmbSexoFamiliar.BindearPropiedadControl = ""
        Me.cmbSexoFamiliar.BindearPropiedadEntidad = ""
        Me.cmbSexoFamiliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSexoFamiliar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSexoFamiliar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSexoFamiliar.FormattingEnabled = True
        Me.cmbSexoFamiliar.IsPK = False
        Me.cmbSexoFamiliar.IsRequired = False
        Me.cmbSexoFamiliar.Items.AddRange(New Object() {"M", "F"})
        Me.cmbSexoFamiliar.Key = Nothing
        Me.cmbSexoFamiliar.LabelAsoc = Nothing
        Me.cmbSexoFamiliar.Location = New System.Drawing.Point(418, 32)
        Me.cmbSexoFamiliar.Name = "cmbSexoFamiliar"
        Me.cmbSexoFamiliar.Size = New System.Drawing.Size(60, 21)
        Me.cmbSexoFamiliar.TabIndex = 3
        '
        'txtCuilFamiliar
        '
        Me.txtCuilFamiliar.Location = New System.Drawing.Point(43, 32)
        Me.txtCuilFamiliar.MaxLength = 11
        Me.txtCuilFamiliar.Name = "txtCuilFamiliar"
        Me.txtCuilFamiliar.Size = New System.Drawing.Size(88, 20)
        Me.txtCuilFamiliar.TabIndex = 0
        '
        'dtpFechaNacFamiliar
        '
        Me.dtpFechaNacFamiliar.BindearPropiedadControl = Nothing
        Me.dtpFechaNacFamiliar.BindearPropiedadEntidad = Nothing
        Me.dtpFechaNacFamiliar.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaNacFamiliar.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaNacFamiliar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaNacFamiliar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaNacFamiliar.IsPK = False
        Me.dtpFechaNacFamiliar.IsRequired = False
        Me.dtpFechaNacFamiliar.Key = ""
        Me.dtpFechaNacFamiliar.LabelAsoc = Nothing
        Me.dtpFechaNacFamiliar.Location = New System.Drawing.Point(315, 32)
        Me.dtpFechaNacFamiliar.Name = "dtpFechaNacFamiliar"
        Me.dtpFechaNacFamiliar.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaNacFamiliar.TabIndex = 2
        '
        'btnRefrescarFamiliar
        '
        Me.btnRefrescarFamiliar.Image = CType(resources.GetObject("btnRefrescarFamiliar.Image"), System.Drawing.Image)
        Me.btnRefrescarFamiliar.Location = New System.Drawing.Point(11, 26)
        Me.btnRefrescarFamiliar.Name = "btnRefrescarFamiliar"
        Me.btnRefrescarFamiliar.Size = New System.Drawing.Size(26, 26)
        Me.btnRefrescarFamiliar.TabIndex = 7
        Me.btnRefrescarFamiliar.UseVisualStyleBackColor = True
        '
        'btnEliminarFamiliar
        '
        Me.btnEliminarFamiliar.Image = CType(resources.GetObject("btnEliminarFamiliar.Image"), System.Drawing.Image)
        Me.btnEliminarFamiliar.Location = New System.Drawing.Point(610, 56)
        Me.btnEliminarFamiliar.Name = "btnEliminarFamiliar"
        Me.btnEliminarFamiliar.Size = New System.Drawing.Size(35, 35)
        Me.btnEliminarFamiliar.TabIndex = 6
        Me.btnEliminarFamiliar.UseVisualStyleBackColor = True
        '
        'btnInsertarFamiliar
        '
        Me.btnInsertarFamiliar.Image = CType(resources.GetObject("btnInsertarFamiliar.Image"), System.Drawing.Image)
        Me.btnInsertarFamiliar.Location = New System.Drawing.Point(610, 17)
        Me.btnInsertarFamiliar.Name = "btnInsertarFamiliar"
        Me.btnInsertarFamiliar.Size = New System.Drawing.Size(35, 35)
        Me.btnInsertarFamiliar.TabIndex = 5
        Me.btnInsertarFamiliar.UseVisualStyleBackColor = True
        '
        'lblVinculo
        '
        Me.lblVinculo.AutoSize = True
        Me.lblVinculo.Location = New System.Drawing.Point(481, 16)
        Me.lblVinculo.Name = "lblVinculo"
        Me.lblVinculo.Size = New System.Drawing.Size(44, 13)
        Me.lblVinculo.TabIndex = 2
        Me.lblVinculo.Text = "Vínculo"
        '
        'lblSexo
        '
        Me.lblSexo.AutoSize = True
        Me.lblSexo.Location = New System.Drawing.Point(417, 17)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(31, 13)
        Me.lblSexo.TabIndex = 2
        Me.lblSexo.Text = "Sexo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(312, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Nac."
        '
        'CuilHijo
        '
        Me.CuilHijo.AutoSize = True
        Me.CuilHijo.Location = New System.Drawing.Point(40, 16)
        Me.CuilHijo.Name = "CuilHijo"
        Me.CuilHijo.Size = New System.Drawing.Size(31, 13)
        Me.CuilHijo.TabIndex = 0
        Me.CuilHijo.Text = "CUIL"
        '
        'txtNombreFamiliar
        '
        Me.txtNombreFamiliar.Location = New System.Drawing.Point(137, 32)
        Me.txtNombreFamiliar.MaxLength = 50
        Me.txtNombreFamiliar.Name = "txtNombreFamiliar"
        Me.txtNombreFamiliar.Size = New System.Drawing.Size(172, 20)
        Me.txtNombreFamiliar.TabIndex = 1
        '
        'dgvPersonalFamiliares
        '
        Me.dgvPersonalFamiliares.AllowUserToAddRows = False
        Me.dgvPersonalFamiliares.AllowUserToDeleteRows = False
        Me.dgvPersonalFamiliares.AllowUserToResizeColumns = False
        Me.dgvPersonalFamiliares.AllowUserToResizeRows = False
        Me.dgvPersonalFamiliares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPersonalFamiliares.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdLegajo, Me.IdTipoVinculoFamiliar, Me.Cuil, Me.NombreFamiliar, Me.FechaNacimientoFamiliar, Me.SexoFamiliar, Me.NombreVinculoFamiliar})
        Me.dgvPersonalFamiliares.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPersonalFamiliares.Location = New System.Drawing.Point(11, 58)
        Me.dgvPersonalFamiliares.Name = "dgvPersonalFamiliares"
        Me.dgvPersonalFamiliares.RowHeadersVisible = False
        Me.dgvPersonalFamiliares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPersonalFamiliares.Size = New System.Drawing.Size(593, 104)
        Me.dgvPersonalFamiliares.TabIndex = 8
        '
        'IdLegajo
        '
        Me.IdLegajo.DataPropertyName = "IdLegajo"
        Me.IdLegajo.HeaderText = "IdLegajo"
        Me.IdLegajo.Name = "IdLegajo"
        Me.IdLegajo.Visible = False
        '
        'IdTipoVinculoFamiliar
        '
        Me.IdTipoVinculoFamiliar.DataPropertyName = "IdTipoVinculoFamiliar"
        Me.IdTipoVinculoFamiliar.HeaderText = "IdTipoVinculoFamiliar"
        Me.IdTipoVinculoFamiliar.Name = "IdTipoVinculoFamiliar"
        Me.IdTipoVinculoFamiliar.Visible = False
        '
        'Cuil
        '
        Me.Cuil.DataPropertyName = "CuilFamiliar"
        Me.Cuil.HeaderText = "CUIL"
        Me.Cuil.Name = "Cuil"
        Me.Cuil.Width = 120
        '
        'NombreFamiliar
        '
        Me.NombreFamiliar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreFamiliar.DataPropertyName = "NombreFamiliar"
        Me.NombreFamiliar.HeaderText = "Nombre"
        Me.NombreFamiliar.Name = "NombreFamiliar"
        '
        'FechaNacimientoFamiliar
        '
        Me.FechaNacimientoFamiliar.DataPropertyName = "FechaNacimientoFamiliar"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.FechaNacimientoFamiliar.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechaNacimientoFamiliar.HeaderText = "Fecha Nac."
        Me.FechaNacimientoFamiliar.Name = "FechaNacimientoFamiliar"
        '
        'SexoFamiliar
        '
        Me.SexoFamiliar.DataPropertyName = "SexoFamiliar"
        Me.SexoFamiliar.HeaderText = "Sexo"
        Me.SexoFamiliar.Name = "SexoFamiliar"
        Me.SexoFamiliar.Width = 70
        '
        'NombreVinculoFamiliar
        '
        Me.NombreVinculoFamiliar.DataPropertyName = "NombreVinculoFamiliar"
        Me.NombreVinculoFamiliar.HeaderText = "Vínculo"
        Me.NombreVinculoFamiliar.Name = "NombreVinculoFamiliar"
        Me.NombreVinculoFamiliar.Width = 120
        '
        'lblNacionalidad
        '
        Me.lblNacionalidad.AutoSize = True
        Me.lblNacionalidad.LabelAsoc = Nothing
        Me.lblNacionalidad.Location = New System.Drawing.Point(15, 117)
        Me.lblNacionalidad.Name = "lblNacionalidad"
        Me.lblNacionalidad.Size = New System.Drawing.Size(69, 13)
        Me.lblNacionalidad.TabIndex = 24
        Me.lblNacionalidad.Text = "Nacionalidad"
        '
        'cmbNacionalidad
        '
        Me.cmbNacionalidad.BindearPropiedadControl = "SelectedValue"
        Me.cmbNacionalidad.BindearPropiedadEntidad = "IdNacionalidad"
        Me.cmbNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNacionalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbNacionalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbNacionalidad.FormattingEnabled = True
        Me.cmbNacionalidad.IsPK = False
        Me.cmbNacionalidad.IsRequired = True
        Me.cmbNacionalidad.Key = Nothing
        Me.cmbNacionalidad.LabelAsoc = Me.lblNacionalidad
        Me.cmbNacionalidad.Location = New System.Drawing.Point(15, 130)
        Me.cmbNacionalidad.Name = "cmbNacionalidad"
        Me.cmbNacionalidad.Size = New System.Drawing.Size(142, 21)
        Me.cmbNacionalidad.TabIndex = 23
        '
        'SueldosPersonalDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(683, 589)
        Me.Controls.Add(Me.lblNacionalidad)
        Me.Controls.Add(Me.cmbNacionalidad)
        Me.Controls.Add(Me.gpbHijos)
        Me.Controls.Add(Me.grbDatosBancarios)
        Me.Controls.Add(Me.grbDatosFamiliares)
        Me.Controls.Add(Me.grbInfoIngreso)
        Me.Controls.Add(Me.txtLegajo)
        Me.Controls.Add(Me.lblLegajo)
        Me.Controls.Add(Me.grpSexo)
        Me.Controls.Add(Me.lblEstadoCivil)
        Me.Controls.Add(Me.cmbEstadoCivil)
        Me.Controls.Add(Me.dtpFechaNacimiento)
        Me.Controls.Add(Me.lblFechaNac)
        Me.Controls.Add(Me.cmbTipoDoc)
        Me.Controls.Add(Me.lblTipoDoc)
        Me.Controls.Add(Me.txtNroDoc)
        Me.Controls.Add(Me.lblNroDoc)
        Me.Controls.Add(Me.lblDireccion)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.lblLocalidad)
        Me.Controls.Add(Me.cmbLocalidad)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SueldosPersonalDetalle"
        Me.Text = "Personal"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.cmbLocalidad, 0)
        Me.Controls.SetChildIndex(Me.lblLocalidad, 0)
        Me.Controls.SetChildIndex(Me.txtDireccion, 0)
        Me.Controls.SetChildIndex(Me.lblDireccion, 0)
        Me.Controls.SetChildIndex(Me.lblNroDoc, 0)
        Me.Controls.SetChildIndex(Me.txtNroDoc, 0)
        Me.Controls.SetChildIndex(Me.lblTipoDoc, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoDoc, 0)
        Me.Controls.SetChildIndex(Me.lblFechaNac, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaNacimiento, 0)
        Me.Controls.SetChildIndex(Me.cmbEstadoCivil, 0)
        Me.Controls.SetChildIndex(Me.lblEstadoCivil, 0)
        Me.Controls.SetChildIndex(Me.grpSexo, 0)
        Me.Controls.SetChildIndex(Me.lblLegajo, 0)
        Me.Controls.SetChildIndex(Me.txtLegajo, 0)
        Me.Controls.SetChildIndex(Me.grbInfoIngreso, 0)
        Me.Controls.SetChildIndex(Me.grbDatosFamiliares, 0)
        Me.Controls.SetChildIndex(Me.grbDatosBancarios, 0)
        Me.Controls.SetChildIndex(Me.gpbHijos, 0)
        Me.Controls.SetChildIndex(Me.cmbNacionalidad, 0)
        Me.Controls.SetChildIndex(Me.lblNacionalidad, 0)
        Me.grpSexo.ResumeLayout(False)
        Me.grpSexo.PerformLayout()
        Me.grbInfoIngreso.ResumeLayout(False)
        Me.grbInfoIngreso.PerformLayout()
        Me.grbDatosFamiliares.ResumeLayout(False)
        Me.grbDatosFamiliares.PerformLayout()
        Me.grbDatosBancarios.ResumeLayout(False)
        Me.grbDatosBancarios.PerformLayout()
        Me.gpbHijos.ResumeLayout(False)
        Me.gpbHijos.PerformLayout()
        CType(Me.dgvPersonalFamiliares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblCuil As Eniac.Controles.Label
   Friend WithEvents txtCuil As Eniac.Controles.TextBox
   Friend WithEvents cmbTipoDoc As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoDoc As Eniac.Controles.Label
   Friend WithEvents txtNroDoc As Eniac.Controles.TextBox
   Friend WithEvents lblNroDoc As Eniac.Controles.Label
   Friend WithEvents lblCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents dtpFechaNacimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaNac As Eniac.Controles.Label
   Friend WithEvents txtLegaoMinTrabajo As Eniac.Controles.TextBox
   Friend WithEvents lblLegajoMinTrabajo As Eniac.Controles.Label
   Friend WithEvents dtpFechaIngreso As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaIngreso As Eniac.Controles.Label
   Friend WithEvents dtpFechaBaja As Eniac.Controles.DateTimePicker
   Friend WithEvents txtCodObraSocial As Eniac.Controles.TextBox
   Friend WithEvents lblCodObraSocial As Eniac.Controles.Label
   Friend WithEvents txtSueldoBasico As Eniac.Controles.TextBox
   Friend WithEvents lblSueldoBasico As Eniac.Controles.Label
   Friend WithEvents lblEstadoCivil As Eniac.Controles.Label
   Friend WithEvents cmbEstadoCivil As Eniac.Controles.ComboBox
   Friend WithEvents grpSexo As System.Windows.Forms.GroupBox
   Friend WithEvents RadioSexoFemenino As System.Windows.Forms.RadioButton
   Friend WithEvents RadioSexoMasculino As System.Windows.Forms.RadioButton
   Friend WithEvents cmbObraSocial As Eniac.Controles.ComboBox
   Friend WithEvents lblObraSocial As Eniac.Controles.Label
   Friend WithEvents txtLegajo As Eniac.Controles.TextBox
   Friend WithEvents lblLegajo As Eniac.Controles.Label
   Friend WithEvents grbInfoIngreso As System.Windows.Forms.GroupBox
   Friend WithEvents cmbMotivoBaja As Eniac.Controles.ComboBox
   Friend WithEvents lblMotivoBaja As Eniac.Controles.Label
   Friend WithEvents grbDatosFamiliares As System.Windows.Forms.GroupBox
   Friend WithEvents txtDatosFamiliares As Eniac.Controles.TextBox
   Friend WithEvents grbDatosBancarios As System.Windows.Forms.GroupBox
   Friend WithEvents txtCBU As Eniac.Controles.TextBox
   Friend WithEvents lblCBU As Eniac.Controles.Label
   Friend WithEvents txtNroCuenta As Eniac.Controles.TextBox
   Friend WithEvents lblNroCuenta As Eniac.Controles.Label
   Friend WithEvents lblClaseDeCuenta As Eniac.Controles.Label
   Friend WithEvents cmbClaseDeCuenta As Eniac.Controles.ComboBox
   Friend WithEvents lblBanco As Eniac.Controles.Label
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents cmbLugarActividad As Eniac.Controles.ComboBox
   Friend WithEvents lblLugarActividad As Eniac.Controles.Label
   Friend WithEvents chbFechaBaja As Eniac.Controles.CheckBox
   Friend WithEvents gpbHijos As System.Windows.Forms.GroupBox
   Friend WithEvents dgvPersonalFamiliares As System.Windows.Forms.DataGridView
   Friend WithEvents CuilHijo As System.Windows.Forms.Label
   Friend WithEvents txtNombreFamiliar As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents btnRefrescarFamiliar As System.Windows.Forms.Button
   Friend WithEvents btnEliminarFamiliar As System.Windows.Forms.Button
   Friend WithEvents btnInsertarFamiliar As System.Windows.Forms.Button
   Friend WithEvents dtpFechaNacFamiliar As Eniac.Controles.DateTimePicker
   Friend WithEvents txtCuilFamiliar As System.Windows.Forms.TextBox
   Friend WithEvents cmbVinculoFamiliar As Eniac.Controles.ComboBox
   Friend WithEvents cmbSexoFamiliar As Eniac.Controles.ComboBox
   Friend WithEvents lblVinculo As System.Windows.Forms.Label
   Friend WithEvents lblSexo As System.Windows.Forms.Label
   Friend WithEvents IdLegajo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoVinculoFamiliar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cuil As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreFamiliar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaNacimientoFamiliar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SexoFamiliar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreVinculoFamiliar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNacionalidad As Controles.Label
    Friend WithEvents cmbNacionalidad As Controles.ComboBox
End Class
