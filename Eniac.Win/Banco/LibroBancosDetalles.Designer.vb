<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LibroBancosDetalles
    Inherits Eniac.Win.BaseForm

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
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LibroBancosDetalles))
      Me.lblTipo = New Eniac.Controles.Label()
      Me.optEgreso = New Eniac.Controles.RadioButton()
      Me.optIngreso = New Eniac.Controles.RadioButton()
      Me.lblCuenta = New Eniac.Controles.Label()
      Me.lblFechaMovimiento = New Eniac.Controles.Label()
      Me.dtpFechaMovimiento = New Eniac.Controles.DateTimePicker()
      Me.lblFechaAplicado = New Eniac.Controles.Label()
      Me.dtpFechaAplicado = New Eniac.Controles.DateTimePicker()
      Me.lblObservaciones = New Eniac.Controles.Label()
      Me.txtObservaciones = New Eniac.Controles.TextBox()
      Me.chkConciliado = New Eniac.Controles.CheckBox()
      Me.lblConciliado = New Eniac.Controles.Label()
      Me.lblImporte = New Eniac.Controles.Label()
      Me.txtImporte = New Eniac.Controles.TextBox()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.lblCheque = New Eniac.Controles.Label()
      Me.grbCheque = New System.Windows.Forms.GroupBox()
      Me.txtNombreBanco = New Eniac.Controles.MaskedTextBox()
      Me.lblBanco = New Eniac.Controles.Label()
      Me.txtNombreLocalidad = New Eniac.Controles.MaskedTextBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.lblNumeroCheque = New Eniac.Controles.Label()
      Me.bscCheques = New Eniac.Controles.Buscador()
      Me.txtNumeroCheque = New Eniac.Controles.MaskedTextBox()
      Me.txtBancoSucursal = New Eniac.Controles.TextBox()
      Me.lblSucursalBanco = New Eniac.Controles.Label()
      Me.bscCodigoCuenta = New Eniac.Controles.Buscador2()
      Me.bscNombreCuenta = New Eniac.Controles.Buscador2()
      Me.lblCuotas = New Eniac.Controles.Label()
      Me.chkCuotas = New Eniac.Controles.CheckBox()
      Me.txtCantidad = New Eniac.Controles.TextBox()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.lblSeparacion = New Eniac.Controles.Label()
      Me.txtSeparacion = New Eniac.Controles.TextBox()
      Me.chkPosdatado = New Eniac.Controles.CheckBox()
      Me.chkModificable = New Eniac.Controles.CheckBox()
      Me.cmbCentroCosto = New Eniac.Controles.ComboBox()
      Me.lblCentroCosto = New Eniac.Controles.Label()
      Me.chbGeneraContabilidad = New Eniac.Controles.CheckBox()
        Me.cmbAFIPConceptoCM05 = New Eniac.Controles.ComboBox()
        Me.chbAFIPConceptoCM05 = New Eniac.Controles.CheckBox()
        Me.grbCheque.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(13, 46)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 3
        Me.lblTipo.Text = "Tipo"
        '
        'optEgreso
        '
        Me.optEgreso.AutoSize = True
        Me.optEgreso.BindearPropiedadControl = Nothing
        Me.optEgreso.BindearPropiedadEntidad = Nothing
        Me.optEgreso.ForeColorFocus = System.Drawing.Color.Red
        Me.optEgreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optEgreso.IsPK = False
        Me.optEgreso.IsRequired = False
        Me.optEgreso.Key = Nothing
        Me.optEgreso.LabelAsoc = Me.lblTipo
        Me.optEgreso.Location = New System.Drawing.Point(200, 44)
        Me.optEgreso.Name = "optEgreso"
        Me.optEgreso.Size = New System.Drawing.Size(58, 17)
        Me.optEgreso.TabIndex = 5
        Me.optEgreso.TabStop = True
        Me.optEgreso.Text = "Egreso"
        Me.optEgreso.UseVisualStyleBackColor = True
        '
        'optIngreso
        '
        Me.optIngreso.AutoSize = True
        Me.optIngreso.BindearPropiedadControl = Nothing
        Me.optIngreso.BindearPropiedadEntidad = Nothing
        Me.optIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.optIngreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optIngreso.IsPK = False
        Me.optIngreso.IsRequired = False
        Me.optIngreso.Key = Nothing
        Me.optIngreso.LabelAsoc = Me.lblTipo
        Me.optIngreso.Location = New System.Drawing.Point(124, 44)
        Me.optIngreso.Name = "optIngreso"
        Me.optIngreso.Size = New System.Drawing.Size(60, 17)
        Me.optIngreso.TabIndex = 4
        Me.optIngreso.TabStop = True
        Me.optIngreso.Text = "Ingreso"
        Me.optIngreso.UseVisualStyleBackColor = True
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.LabelAsoc = Nothing
        Me.lblCuenta.Location = New System.Drawing.Point(12, 18)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(41, 13)
        Me.lblCuenta.TabIndex = 0
        Me.lblCuenta.Text = "Cuenta"
        '
        'lblFechaMovimiento
        '
        Me.lblFechaMovimiento.AutoSize = True
        Me.lblFechaMovimiento.LabelAsoc = Nothing
        Me.lblFechaMovimiento.Location = New System.Drawing.Point(13, 124)
        Me.lblFechaMovimiento.Name = "lblFechaMovimiento"
        Me.lblFechaMovimiento.Size = New System.Drawing.Size(61, 13)
        Me.lblFechaMovimiento.TabIndex = 12
        Me.lblFechaMovimiento.Text = "Movimiento"
        '
        'dtpFechaMovimiento
        '
        Me.dtpFechaMovimiento.BindearPropiedadControl = Nothing
        Me.dtpFechaMovimiento.BindearPropiedadEntidad = Nothing
        Me.dtpFechaMovimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaMovimiento.IsPK = False
        Me.dtpFechaMovimiento.IsRequired = False
        Me.dtpFechaMovimiento.Key = ""
        Me.dtpFechaMovimiento.LabelAsoc = Me.lblFechaMovimiento
        Me.dtpFechaMovimiento.Location = New System.Drawing.Point(124, 120)
        Me.dtpFechaMovimiento.Name = "dtpFechaMovimiento"
        Me.dtpFechaMovimiento.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaMovimiento.TabIndex = 13
        '
        'lblFechaAplicado
        '
        Me.lblFechaAplicado.AutoSize = True
        Me.lblFechaAplicado.LabelAsoc = Nothing
        Me.lblFechaAplicado.Location = New System.Drawing.Point(337, 124)
        Me.lblFechaAplicado.Name = "lblFechaAplicado"
        Me.lblFechaAplicado.Size = New System.Drawing.Size(48, 13)
        Me.lblFechaAplicado.TabIndex = 15
        Me.lblFechaAplicado.Text = "Aplicado"
        Me.lblFechaAplicado.Visible = False
        '
        'dtpFechaAplicado
        '
        Me.dtpFechaAplicado.BindearPropiedadControl = Nothing
        Me.dtpFechaAplicado.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAplicado.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAplicado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAplicado.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAplicado.IsPK = False
        Me.dtpFechaAplicado.IsRequired = False
        Me.dtpFechaAplicado.Key = ""
        Me.dtpFechaAplicado.LabelAsoc = Me.lblFechaAplicado
        Me.dtpFechaAplicado.Location = New System.Drawing.Point(391, 120)
        Me.dtpFechaAplicado.Name = "dtpFechaAplicado"
        Me.dtpFechaAplicado.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaAplicado.TabIndex = 16
        Me.dtpFechaAplicado.Visible = False
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.LabelAsoc = Nothing
        Me.lblObservaciones.Location = New System.Drawing.Point(13, 258)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 19
        Me.lblObservaciones.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BindearPropiedadControl = Nothing
        Me.txtObservaciones.BindearPropiedadEntidad = Nothing
        Me.txtObservaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservaciones.Formato = ""
        Me.txtObservaciones.IsDecimal = False
        Me.txtObservaciones.IsNumber = False
        Me.txtObservaciones.IsPK = False
        Me.txtObservaciones.IsRequired = False
        Me.txtObservaciones.Key = ""
        Me.txtObservaciones.LabelAsoc = Me.lblObservaciones
        Me.txtObservaciones.Location = New System.Drawing.Point(124, 254)
        Me.txtObservaciones.MaxLength = 100
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(459, 20)
        Me.txtObservaciones.TabIndex = 20
        '
        'chkConciliado
        '
        Me.chkConciliado.AutoSize = True
        Me.chkConciliado.BindearPropiedadControl = Nothing
        Me.chkConciliado.BindearPropiedadEntidad = Nothing
        Me.chkConciliado.ForeColorFocus = System.Drawing.Color.Red
        Me.chkConciliado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkConciliado.IsPK = False
        Me.chkConciliado.IsRequired = False
        Me.chkConciliado.Key = Nothing
        Me.chkConciliado.LabelAsoc = Me.lblConciliado
        Me.chkConciliado.Location = New System.Drawing.Point(124, 284)
        Me.chkConciliado.Name = "chkConciliado"
        Me.chkConciliado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkConciliado.Size = New System.Drawing.Size(15, 14)
        Me.chkConciliado.TabIndex = 22
        Me.chkConciliado.UseVisualStyleBackColor = True
        '
        'lblConciliado
        '
        Me.lblConciliado.AutoSize = True
        Me.lblConciliado.LabelAsoc = Nothing
        Me.lblConciliado.Location = New System.Drawing.Point(13, 285)
        Me.lblConciliado.Name = "lblConciliado"
        Me.lblConciliado.Size = New System.Drawing.Size(56, 13)
        Me.lblConciliado.TabIndex = 21
        Me.lblConciliado.Text = "Conciliado"
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.LabelAsoc = Nothing
        Me.lblImporte.Location = New System.Drawing.Point(13, 98)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(42, 13)
        Me.lblImporte.TabIndex = 10
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
        Me.txtImporte.Location = New System.Drawing.Point(124, 94)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(100, 20)
        Me.txtImporte.TabIndex = 11
        Me.txtImporte.Text = "0.00"
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(499, 307)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
        Me.btnCancelar.TabIndex = 32
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(395, 307)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 30)
        Me.btnAceptar.TabIndex = 31
        Me.btnAceptar.Text = "&Aceptar (F4)"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblCheque
        '
        Me.lblCheque.AutoSize = True
        Me.lblCheque.LabelAsoc = Nothing
        Me.lblCheque.Location = New System.Drawing.Point(13, 185)
        Me.lblCheque.Name = "lblCheque"
        Me.lblCheque.Size = New System.Drawing.Size(44, 13)
        Me.lblCheque.TabIndex = 17
        Me.lblCheque.Text = "Cheque"
        '
        'grbCheque
        '
        Me.grbCheque.Controls.Add(Me.txtNombreBanco)
        Me.grbCheque.Controls.Add(Me.txtNombreLocalidad)
        Me.grbCheque.Controls.Add(Me.lblNumeroCheque)
        Me.grbCheque.Controls.Add(Me.bscCheques)
        Me.grbCheque.Controls.Add(Me.txtNumeroCheque)
        Me.grbCheque.Controls.Add(Me.lblBanco)
        Me.grbCheque.Controls.Add(Me.txtBancoSucursal)
        Me.grbCheque.Controls.Add(Me.lblSucursalBanco)
        Me.grbCheque.Controls.Add(Me.lblLocalidad)
        Me.grbCheque.Location = New System.Drawing.Point(124, 146)
        Me.grbCheque.Name = "grbCheque"
        Me.grbCheque.Size = New System.Drawing.Size(455, 84)
        Me.grbCheque.TabIndex = 18
        Me.grbCheque.TabStop = False
        '
        'txtNombreBanco
        '
        Me.txtNombreBanco.BindearPropiedadControl = Nothing
        Me.txtNombreBanco.BindearPropiedadEntidad = Nothing
        Me.txtNombreBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreBanco.IsDecimal = False
        Me.txtNombreBanco.IsNumber = True
        Me.txtNombreBanco.IsPK = False
        Me.txtNombreBanco.IsRequired = True
        Me.txtNombreBanco.Key = ""
        Me.txtNombreBanco.LabelAsoc = Me.lblBanco
        Me.txtNombreBanco.Location = New System.Drawing.Point(61, 53)
        Me.txtNombreBanco.Name = "txtNombreBanco"
        Me.txtNombreBanco.ReadOnly = True
        Me.txtNombreBanco.Size = New System.Drawing.Size(181, 20)
        Me.txtNombreBanco.TabIndex = 5
        Me.txtNombreBanco.TabStop = False
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.LabelAsoc = Nothing
        Me.lblBanco.Location = New System.Drawing.Point(12, 56)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(38, 13)
        Me.lblBanco.TabIndex = 4
        Me.lblBanco.Text = "Banco"
        '
        'txtNombreLocalidad
        '
        Me.txtNombreLocalidad.BindearPropiedadControl = Nothing
        Me.txtNombreLocalidad.BindearPropiedadEntidad = Nothing
        Me.txtNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreLocalidad.IsDecimal = False
        Me.txtNombreLocalidad.IsNumber = True
        Me.txtNombreLocalidad.IsPK = False
        Me.txtNombreLocalidad.IsRequired = True
        Me.txtNombreLocalidad.Key = ""
        Me.txtNombreLocalidad.LabelAsoc = Me.lblLocalidad
        Me.txtNombreLocalidad.Location = New System.Drawing.Point(241, 19)
        Me.txtNombreLocalidad.Name = "txtNombreLocalidad"
        Me.txtNombreLocalidad.ReadOnly = True
        Me.txtNombreLocalidad.Size = New System.Drawing.Size(174, 20)
        Me.txtNombreLocalidad.TabIndex = 3
        Me.txtNombreLocalidad.TabStop = False
        '
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.LabelAsoc = Nothing
        Me.lblLocalidad.Location = New System.Drawing.Point(184, 23)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lblLocalidad.TabIndex = 2
        Me.lblLocalidad.Text = "Localidad"
        '
        'lblNumeroCheque
        '
        Me.lblNumeroCheque.AutoSize = True
        Me.lblNumeroCheque.LabelAsoc = Nothing
        Me.lblNumeroCheque.Location = New System.Drawing.Point(12, 23)
        Me.lblNumeroCheque.Name = "lblNumeroCheque"
        Me.lblNumeroCheque.Size = New System.Drawing.Size(44, 13)
        Me.lblNumeroCheque.TabIndex = 0
        Me.lblNumeroCheque.Text = "Número"
        '
        'bscCheques
        '
        Me.bscCheques.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCheques.AyudaAncho = 608
        Me.bscCheques.BindearPropiedadControl = Nothing
        Me.bscCheques.BindearPropiedadEntidad = Nothing
        Me.bscCheques.ColumnasAlineacion = Nothing
        Me.bscCheques.ColumnasAncho = Nothing
        Me.bscCheques.ColumnasFormato = Nothing
        Me.bscCheques.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCheques.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCheques.Datos = Nothing
        Me.bscCheques.FilaDevuelta = Nothing
        Me.bscCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCheques.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCheques.IsDecimal = False
        Me.bscCheques.IsNumber = False
        Me.bscCheques.IsPK = False
        Me.bscCheques.IsRequired = False
        Me.bscCheques.Key = ""
        Me.bscCheques.LabelAsoc = Nothing
        Me.bscCheques.Location = New System.Drawing.Point(417, 54)
        Me.bscCheques.MaxLengh = "32767"
        Me.bscCheques.Name = "bscCheques"
        Me.bscCheques.Permitido = True
        Me.bscCheques.Selecciono = False
        Me.bscCheques.Size = New System.Drawing.Size(32, 20)
        Me.bscCheques.TabIndex = 8
        Me.bscCheques.Titulo = "Cheques"
        Me.bscCheques.Visible = False
        '
        'txtNumeroCheque
        '
        Me.txtNumeroCheque.BindearPropiedadControl = Nothing
        Me.txtNumeroCheque.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCheque.IsDecimal = False
        Me.txtNumeroCheque.IsNumber = True
        Me.txtNumeroCheque.IsPK = False
        Me.txtNumeroCheque.IsRequired = True
        Me.txtNumeroCheque.Key = ""
        Me.txtNumeroCheque.LabelAsoc = Me.lblCheque
        Me.txtNumeroCheque.Location = New System.Drawing.Point(61, 20)
        Me.txtNumeroCheque.Name = "txtNumeroCheque"
        Me.txtNumeroCheque.ReadOnly = True
        Me.txtNumeroCheque.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroCheque.TabIndex = 1
        Me.txtNumeroCheque.TabStop = False
        '
        'txtBancoSucursal
        '
        Me.txtBancoSucursal.BindearPropiedadControl = "Text"
        Me.txtBancoSucursal.BindearPropiedadEntidad = "IdBancoSucursal"
        Me.txtBancoSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancoSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancoSucursal.Formato = ""
        Me.txtBancoSucursal.IsDecimal = False
        Me.txtBancoSucursal.IsNumber = True
        Me.txtBancoSucursal.IsPK = False
        Me.txtBancoSucursal.IsRequired = True
        Me.txtBancoSucursal.Key = ""
        Me.txtBancoSucursal.LabelAsoc = Me.lblSucursalBanco
        Me.txtBancoSucursal.Location = New System.Drawing.Point(315, 54)
        Me.txtBancoSucursal.MaxLength = 3
        Me.txtBancoSucursal.Name = "txtBancoSucursal"
        Me.txtBancoSucursal.ReadOnly = True
        Me.txtBancoSucursal.Size = New System.Drawing.Size(42, 20)
        Me.txtBancoSucursal.TabIndex = 7
        Me.txtBancoSucursal.TabStop = False
        Me.txtBancoSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSucursalBanco
        '
        Me.lblSucursalBanco.AutoSize = True
        Me.lblSucursalBanco.LabelAsoc = Nothing
        Me.lblSucursalBanco.Location = New System.Drawing.Point(250, 57)
        Me.lblSucursalBanco.Name = "lblSucursalBanco"
        Me.lblSucursalBanco.Size = New System.Drawing.Size(63, 13)
        Me.lblSucursalBanco.TabIndex = 6
        Me.lblSucursalBanco.Text = "Banco Suc."
        '
        'bscCodigoCuenta
        '
        Me.bscCodigoCuenta.ActivarFiltroEnGrilla = True
        Me.bscCodigoCuenta.BindearPropiedadControl = Nothing
        Me.bscCodigoCuenta.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCuenta.ConfigBuscador = Nothing
        Me.bscCodigoCuenta.Datos = Nothing
        Me.bscCodigoCuenta.FilaDevuelta = Nothing
        Me.bscCodigoCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCuenta.IsDecimal = False
        Me.bscCodigoCuenta.IsNumber = False
        Me.bscCodigoCuenta.IsPK = False
        Me.bscCodigoCuenta.IsRequired = False
        Me.bscCodigoCuenta.Key = ""
        Me.bscCodigoCuenta.LabelAsoc = Me.lblCuenta
        Me.bscCodigoCuenta.Location = New System.Drawing.Point(124, 14)
        Me.bscCodigoCuenta.MaxLengh = "32767"
        Me.bscCodigoCuenta.Name = "bscCodigoCuenta"
        Me.bscCodigoCuenta.Permitido = True
        Me.bscCodigoCuenta.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCuenta.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCuenta.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCuenta.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCuenta.Selecciono = False
        Me.bscCodigoCuenta.Size = New System.Drawing.Size(116, 20)
        Me.bscCodigoCuenta.TabIndex = 1
        '
        'bscNombreCuenta
        '
        Me.bscNombreCuenta.ActivarFiltroEnGrilla = True
        Me.bscNombreCuenta.AutoSize = True
        Me.bscNombreCuenta.BindearPropiedadControl = Nothing
        Me.bscNombreCuenta.BindearPropiedadEntidad = Nothing
        Me.bscNombreCuenta.ConfigBuscador = Nothing
        Me.bscNombreCuenta.Datos = Nothing
        Me.bscNombreCuenta.FilaDevuelta = Nothing
        Me.bscNombreCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCuenta.IsDecimal = False
        Me.bscNombreCuenta.IsNumber = False
        Me.bscNombreCuenta.IsPK = False
        Me.bscNombreCuenta.IsRequired = False
        Me.bscNombreCuenta.Key = ""
        Me.bscNombreCuenta.LabelAsoc = Me.lblCuenta
        Me.bscNombreCuenta.Location = New System.Drawing.Point(245, 13)
        Me.bscNombreCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCuenta.MaxLengh = "32767"
        Me.bscNombreCuenta.Name = "bscNombreCuenta"
        Me.bscNombreCuenta.Permitido = True
        Me.bscNombreCuenta.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCuenta.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCuenta.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCuenta.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCuenta.Selecciono = False
        Me.bscNombreCuenta.Size = New System.Drawing.Size(338, 23)
        Me.bscNombreCuenta.TabIndex = 2
        '
        'lblCuotas
        '
        Me.lblCuotas.AutoSize = True
        Me.lblCuotas.LabelAsoc = Nothing
        Me.lblCuotas.Location = New System.Drawing.Point(13, 315)
        Me.lblCuotas.Name = "lblCuotas"
        Me.lblCuotas.Size = New System.Drawing.Size(40, 13)
        Me.lblCuotas.TabIndex = 25
        Me.lblCuotas.Text = "Cuotas"
        Me.lblCuotas.Visible = False
        '
        'chkCuotas
        '
        Me.chkCuotas.AutoSize = True
        Me.chkCuotas.BindearPropiedadControl = Nothing
        Me.chkCuotas.BindearPropiedadEntidad = Nothing
        Me.chkCuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.chkCuotas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkCuotas.IsPK = False
        Me.chkCuotas.IsRequired = False
        Me.chkCuotas.Key = Nothing
        Me.chkCuotas.LabelAsoc = Me.lblCuotas
        Me.chkCuotas.Location = New System.Drawing.Point(124, 314)
        Me.chkCuotas.Name = "chkCuotas"
        Me.chkCuotas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkCuotas.Size = New System.Drawing.Size(15, 14)
        Me.chkCuotas.TabIndex = 26
        Me.chkCuotas.UseVisualStyleBackColor = True
        Me.chkCuotas.Visible = False
        '
        'txtCantidad
        '
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "##0"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblCantidad
        Me.txtCantidad.Location = New System.Drawing.Point(205, 311)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(42, 20)
        Me.txtCantidad.TabIndex = 28
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCantidad.Visible = False
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(153, 315)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 27
        Me.lblCantidad.Text = "Cantidad"
        Me.lblCantidad.Visible = False
        '
        'lblSeparacion
        '
        Me.lblSeparacion.AutoSize = True
        Me.lblSeparacion.LabelAsoc = Nothing
        Me.lblSeparacion.Location = New System.Drawing.Point(258, 315)
        Me.lblSeparacion.Name = "lblSeparacion"
        Me.lblSeparacion.Size = New System.Drawing.Size(61, 13)
        Me.lblSeparacion.TabIndex = 29
        Me.lblSeparacion.Text = "Separacion"
        Me.lblSeparacion.Visible = False
        '
        'txtSeparacion
        '
        Me.txtSeparacion.BindearPropiedadControl = Nothing
        Me.txtSeparacion.BindearPropiedadEntidad = Nothing
        Me.txtSeparacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSeparacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSeparacion.Formato = "##0"
        Me.txtSeparacion.IsDecimal = True
        Me.txtSeparacion.IsNumber = True
        Me.txtSeparacion.IsPK = False
        Me.txtSeparacion.IsRequired = False
        Me.txtSeparacion.Key = ""
        Me.txtSeparacion.LabelAsoc = Me.lblSeparacion
        Me.txtSeparacion.Location = New System.Drawing.Point(322, 311)
        Me.txtSeparacion.Name = "txtSeparacion"
        Me.txtSeparacion.Size = New System.Drawing.Size(42, 20)
        Me.txtSeparacion.TabIndex = 30
        Me.txtSeparacion.Text = "0"
        Me.txtSeparacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSeparacion.Visible = False
        '
        'chkPosdatado
        '
        Me.chkPosdatado.AutoSize = True
        Me.chkPosdatado.BindearPropiedadControl = Nothing
        Me.chkPosdatado.BindearPropiedadEntidad = Nothing
        Me.chkPosdatado.ForeColorFocus = System.Drawing.Color.Red
        Me.chkPosdatado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkPosdatado.IsPK = False
        Me.chkPosdatado.IsRequired = False
        Me.chkPosdatado.Key = Nothing
        Me.chkPosdatado.LabelAsoc = Nothing
        Me.chkPosdatado.Location = New System.Drawing.Point(242, 123)
        Me.chkPosdatado.Name = "chkPosdatado"
        Me.chkPosdatado.Size = New System.Drawing.Size(77, 17)
        Me.chkPosdatado.TabIndex = 14
        Me.chkPosdatado.Text = "Posdatado"
        Me.chkPosdatado.UseVisualStyleBackColor = True
        '
        'chkModificable
        '
        Me.chkModificable.AutoSize = True
        Me.chkModificable.BindearPropiedadControl = Nothing
        Me.chkModificable.BindearPropiedadEntidad = Nothing
        Me.chkModificable.ForeColorFocus = System.Drawing.Color.Red
        Me.chkModificable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkModificable.IsPK = False
        Me.chkModificable.IsRequired = False
        Me.chkModificable.Key = Nothing
        Me.chkModificable.LabelAsoc = Nothing
        Me.chkModificable.Location = New System.Drawing.Point(504, 284)
        Me.chkModificable.Name = "chkModificable"
        Me.chkModificable.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkModificable.Size = New System.Drawing.Size(80, 17)
        Me.chkModificable.TabIndex = 24
        Me.chkModificable.Text = "Modificable"
        Me.chkModificable.UseVisualStyleBackColor = True
        Me.chkModificable.Visible = False
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.BindearPropiedadControl = Nothing
        Me.cmbCentroCosto.BindearPropiedadEntidad = Nothing
        Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.IsPK = False
        Me.cmbCentroCosto.IsRequired = False
        Me.cmbCentroCosto.Key = Nothing
        Me.cmbCentroCosto.LabelAsoc = Me.lblCentroCosto
        Me.cmbCentroCosto.Location = New System.Drawing.Point(432, 43)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(151, 21)
        Me.cmbCentroCosto.TabIndex = 7
        Me.cmbCentroCosto.Visible = False
        '
        'lblCentroCosto
        '
        Me.lblCentroCosto.AutoSize = True
        Me.lblCentroCosto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCentroCosto.LabelAsoc = Nothing
        Me.lblCentroCosto.Location = New System.Drawing.Point(339, 46)
        Me.lblCentroCosto.Name = "lblCentroCosto"
        Me.lblCentroCosto.Size = New System.Drawing.Size(87, 13)
        Me.lblCentroCosto.TabIndex = 6
        Me.lblCentroCosto.Text = "Centro de costos"
        Me.lblCentroCosto.Visible = False
        '
        'chbGeneraContabilidad
        '
        Me.chbGeneraContabilidad.AutoSize = True
        Me.chbGeneraContabilidad.BindearPropiedadControl = Nothing
        Me.chbGeneraContabilidad.BindearPropiedadEntidad = Nothing
        Me.chbGeneraContabilidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGeneraContabilidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGeneraContabilidad.IsPK = False
        Me.chbGeneraContabilidad.IsRequired = False
        Me.chbGeneraContabilidad.Key = Nothing
        Me.chbGeneraContabilidad.LabelAsoc = Nothing
        Me.chbGeneraContabilidad.Location = New System.Drawing.Point(373, 284)
        Me.chbGeneraContabilidad.Name = "chbGeneraContabilidad"
        Me.chbGeneraContabilidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbGeneraContabilidad.Size = New System.Drawing.Size(122, 17)
        Me.chbGeneraContabilidad.TabIndex = 23
        Me.chbGeneraContabilidad.Text = "Genera Contabilidad"
        Me.chbGeneraContabilidad.UseVisualStyleBackColor = True
        Me.chbGeneraContabilidad.Visible = False
        '
        'cmbAFIPConceptoCM05
        '
        Me.cmbAFIPConceptoCM05.BindearPropiedadControl = "SelectedValue"
        Me.cmbAFIPConceptoCM05.BindearPropiedadEntidad = "IdConceptoCM05"
        Me.cmbAFIPConceptoCM05.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAFIPConceptoCM05.Enabled = False
        Me.cmbAFIPConceptoCM05.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAFIPConceptoCM05.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAFIPConceptoCM05.FormattingEnabled = True
        Me.cmbAFIPConceptoCM05.IsPK = False
        Me.cmbAFIPConceptoCM05.IsRequired = False
        Me.cmbAFIPConceptoCM05.Key = Nothing
        Me.cmbAFIPConceptoCM05.LabelAsoc = Me.chbAFIPConceptoCM05
        Me.cmbAFIPConceptoCM05.Location = New System.Drawing.Point(124, 67)
        Me.cmbAFIPConceptoCM05.Name = "cmbAFIPConceptoCM05"
        Me.cmbAFIPConceptoCM05.Size = New System.Drawing.Size(183, 21)
        Me.cmbAFIPConceptoCM05.TabIndex = 9
        '
        'chbAFIPConceptoCM05
        '
        Me.chbAFIPConceptoCM05.AutoSize = True
        Me.chbAFIPConceptoCM05.BindearPropiedadControl = ""
        Me.chbAFIPConceptoCM05.BindearPropiedadEntidad = ""
        Me.chbAFIPConceptoCM05.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPConceptoCM05.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPConceptoCM05.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbAFIPConceptoCM05.IsPK = False
        Me.chbAFIPConceptoCM05.IsRequired = False
        Me.chbAFIPConceptoCM05.Key = Nothing
        Me.chbAFIPConceptoCM05.LabelAsoc = Nothing
        Me.chbAFIPConceptoCM05.Location = New System.Drawing.Point(15, 71)
        Me.chbAFIPConceptoCM05.Name = "chbAFIPConceptoCM05"
        Me.chbAFIPConceptoCM05.Size = New System.Drawing.Size(103, 17)
        Me.chbAFIPConceptoCM05.TabIndex = 8
        Me.chbAFIPConceptoCM05.Text = "Concepto CM05"
        Me.chbAFIPConceptoCM05.UseVisualStyleBackColor = True
        '
        'LibroBancosDetalles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 355)
        Me.Controls.Add(Me.cmbAFIPConceptoCM05)
        Me.Controls.Add(Me.chbAFIPConceptoCM05)
        Me.Controls.Add(Me.cmbCentroCosto)
        Me.Controls.Add(Me.lblCentroCosto)
        Me.Controls.Add(Me.chkPosdatado)
        Me.Controls.Add(Me.lblSeparacion)
        Me.Controls.Add(Me.txtSeparacion)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblCuotas)
        Me.Controls.Add(Me.chkCuotas)
        Me.Controls.Add(Me.bscCodigoCuenta)
        Me.Controls.Add(Me.bscNombreCuenta)
        Me.Controls.Add(Me.grbCheque)
        Me.Controls.Add(Me.lblConciliado)
        Me.Controls.Add(Me.lblCheque)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblImporte)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.chbGeneraContabilidad)
        Me.Controls.Add(Me.chkModificable)
        Me.Controls.Add(Me.chkConciliado)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.lblFechaAplicado)
        Me.Controls.Add(Me.dtpFechaAplicado)
        Me.Controls.Add(Me.lblFechaMovimiento)
        Me.Controls.Add(Me.dtpFechaMovimiento)
        Me.Controls.Add(Me.lblCuenta)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.optEgreso)
        Me.Controls.Add(Me.optIngreso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "LibroBancosDetalles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Movimiento de Banco"
        Me.grbCheque.ResumeLayout(False)
        Me.grbCheque.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTipo As Eniac.Controles.Label
   Friend WithEvents optEgreso As Eniac.Controles.RadioButton
   Friend WithEvents optIngreso As Eniac.Controles.RadioButton
   Friend WithEvents lblCuenta As Eniac.Controles.Label
   Friend WithEvents lblFechaMovimiento As Eniac.Controles.Label
   Friend WithEvents dtpFechaMovimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAplicado As Eniac.Controles.Label
   Friend WithEvents dtpFechaAplicado As Eniac.Controles.DateTimePicker
   Friend WithEvents lblObservaciones As Eniac.Controles.Label
   Friend WithEvents txtObservaciones As Eniac.Controles.TextBox
   Friend WithEvents chkConciliado As Eniac.Controles.CheckBox
   Friend WithEvents lblImporte As Eniac.Controles.Label
   Friend WithEvents txtImporte As Eniac.Controles.TextBox
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents lblCheque As Eniac.Controles.Label
   Friend WithEvents lblConciliado As Eniac.Controles.Label
   Friend WithEvents grbCheque As System.Windows.Forms.GroupBox
   Friend WithEvents lblBanco As Eniac.Controles.Label
   Friend WithEvents txtBancoSucursal As Eniac.Controles.TextBox
   Friend WithEvents lblSucursalBanco As Eniac.Controles.Label
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents bscCheques As Eniac.Controles.Buscador
   Friend WithEvents txtNumeroCheque As Eniac.Controles.MaskedTextBox
   Friend WithEvents txtNombreLocalidad As Eniac.Controles.MaskedTextBox
   Friend WithEvents lblNumeroCheque As Eniac.Controles.Label
   Friend WithEvents txtNombreBanco As Eniac.Controles.MaskedTextBox
   Friend WithEvents bscCodigoCuenta As Eniac.Controles.Buscador2
   Friend WithEvents bscNombreCuenta As Eniac.Controles.Buscador2
   Friend WithEvents lblCuotas As Eniac.Controles.Label
   Friend WithEvents chkCuotas As Eniac.Controles.CheckBox
   Friend WithEvents txtCantidad As Eniac.Controles.TextBox
   Friend WithEvents lblCantidad As Eniac.Controles.Label
   Friend WithEvents lblSeparacion As Eniac.Controles.Label
   Friend WithEvents txtSeparacion As Eniac.Controles.TextBox
   Friend WithEvents chkPosdatado As Eniac.Controles.CheckBox
   Friend WithEvents chkModificable As Eniac.Controles.CheckBox
   Friend WithEvents cmbCentroCosto As Eniac.Controles.ComboBox
   Friend WithEvents lblCentroCosto As Eniac.Controles.Label
   Friend WithEvents chbGeneraContabilidad As Eniac.Controles.CheckBox
    Public WithEvents cmbAFIPConceptoCM05 As Controles.ComboBox
    Friend WithEvents chbAFIPConceptoCM05 As Controles.CheckBox
End Class
