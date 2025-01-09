<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CuentasDeCajasDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CuentasDeCajasDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.chbEsPosdatado = New Eniac.Controles.CheckBox()
      Me.lblEsPosdatado = New Eniac.Controles.Label()
      Me.lblTipo = New Eniac.Controles.Label()
      Me.lblPideCheque = New Eniac.Controles.Label()
      Me.chbPideCheque = New Eniac.Controles.CheckBox()
      Me.txtGrupo = New Eniac.Controles.TextBox()
      Me.lblGrupo = New Eniac.Controles.Label()
      Me.optEgreso = New Eniac.Controles.RadioButton()
      Me.optIngreso = New Eniac.Controles.RadioButton()
      Me.gpoContabilidad = New System.Windows.Forms.GroupBox()
      Me.chbGeneraContabilidad = New Eniac.Controles.CheckBox()
      Me.bscNombreCentroCosto = New Eniac.Controles.Buscador2()
      Me.lblCentroCostos = New Eniac.Controles.Label()
      Me.bscCodigoCentroCosto = New Eniac.Controles.Buscador2()
      Me.lblCta = New Eniac.Controles.Label()
      Me.bscDescCuenta = New Eniac.Controles.Buscador2()
      Me.bscCodCuenta = New Eniac.Controles.Buscador2()
      Me.cmbAFIPConceptoCM05 = New Eniac.Controles.ComboBox()
      Me.chbAFIPConceptoCM05 = New Eniac.Controles.CheckBox()
      Me.gpoContabilidad.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(304, 259)
      Me.btnAceptar.TabIndex = 16
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(390, 259)
      Me.btnCancelar.TabIndex = 17
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(141, 255)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(84, 254)
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(20, 46)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(20, 20)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Código"
      '
      'txtCodigo
      '
      Me.txtCodigo.BindearPropiedadControl = "Text"
      Me.txtCodigo.BindearPropiedadEntidad = "IdCuentaCaja"
      Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigo.Formato = ""
      Me.txtCodigo.IsDecimal = False
      Me.txtCodigo.IsNumber = True
      Me.txtCodigo.IsPK = True
      Me.txtCodigo.IsRequired = True
      Me.txtCodigo.Key = ""
      Me.txtCodigo.LabelAsoc = Me.lblCodigo
      Me.txtCodigo.Location = New System.Drawing.Point(132, 16)
      Me.txtCodigo.MaxLength = 6
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(59, 20)
      Me.txtCodigo.TabIndex = 1
      Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreCuentaCaja"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(132, 42)
      Me.txtNombre.MaxLength = 40
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(300, 20)
      Me.txtNombre.TabIndex = 3
      '
      'chbEsPosdatado
      '
      Me.chbEsPosdatado.AutoSize = True
      Me.chbEsPosdatado.BindearPropiedadControl = "Checked"
      Me.chbEsPosdatado.BindearPropiedadEntidad = "EsPosdatado"
      Me.chbEsPosdatado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEsPosdatado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEsPosdatado.IsPK = False
      Me.chbEsPosdatado.IsRequired = False
      Me.chbEsPosdatado.Key = Nothing
      Me.chbEsPosdatado.LabelAsoc = Me.lblEsPosdatado
      Me.chbEsPosdatado.Location = New System.Drawing.Point(382, 71)
      Me.chbEsPosdatado.Name = "chbEsPosdatado"
      Me.chbEsPosdatado.Size = New System.Drawing.Size(15, 14)
      Me.chbEsPosdatado.TabIndex = 8
      Me.chbEsPosdatado.UseVisualStyleBackColor = True
      Me.chbEsPosdatado.Visible = False
      '
      'lblEsPosdatado
      '
      Me.lblEsPosdatado.AutoSize = True
      Me.lblEsPosdatado.LabelAsoc = Nothing
      Me.lblEsPosdatado.Location = New System.Drawing.Point(300, 72)
      Me.lblEsPosdatado.Name = "lblEsPosdatado"
      Me.lblEsPosdatado.Size = New System.Drawing.Size(73, 13)
      Me.lblEsPosdatado.TabIndex = 7
      Me.lblEsPosdatado.Text = "Es Posdatado"
      Me.lblEsPosdatado.Visible = False
      '
      'lblTipo
      '
      Me.lblTipo.AutoSize = True
      Me.lblTipo.LabelAsoc = Nothing
      Me.lblTipo.Location = New System.Drawing.Point(20, 72)
      Me.lblTipo.Name = "lblTipo"
      Me.lblTipo.Size = New System.Drawing.Size(28, 13)
      Me.lblTipo.TabIndex = 4
      Me.lblTipo.Text = "Tipo"
      '
      'lblPideCheque
      '
      Me.lblPideCheque.AutoSize = True
      Me.lblPideCheque.LabelAsoc = Nothing
      Me.lblPideCheque.Location = New System.Drawing.Point(300, 101)
      Me.lblPideCheque.Name = "lblPideCheque"
      Me.lblPideCheque.Size = New System.Drawing.Size(68, 13)
      Me.lblPideCheque.TabIndex = 11
      Me.lblPideCheque.Text = "Pide Cheque"
      Me.lblPideCheque.Visible = False
      '
      'chbPideCheque
      '
      Me.chbPideCheque.AutoSize = True
      Me.chbPideCheque.BindearPropiedadControl = "Checked"
      Me.chbPideCheque.BindearPropiedadEntidad = "PideCheque"
      Me.chbPideCheque.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPideCheque.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPideCheque.IsPK = False
      Me.chbPideCheque.IsRequired = False
      Me.chbPideCheque.Key = Nothing
      Me.chbPideCheque.LabelAsoc = Me.lblPideCheque
      Me.chbPideCheque.Location = New System.Drawing.Point(382, 100)
      Me.chbPideCheque.Name = "chbPideCheque"
      Me.chbPideCheque.Size = New System.Drawing.Size(15, 14)
      Me.chbPideCheque.TabIndex = 12
      Me.chbPideCheque.UseVisualStyleBackColor = True
      Me.chbPideCheque.Visible = False
      '
      'txtGrupo
      '
      Me.txtGrupo.BindearPropiedadControl = "Text"
      Me.txtGrupo.BindearPropiedadEntidad = "IdGrupoCuenta"
      Me.txtGrupo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtGrupo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtGrupo.Formato = ""
      Me.txtGrupo.IsDecimal = False
      Me.txtGrupo.IsNumber = False
      Me.txtGrupo.IsPK = False
      Me.txtGrupo.IsRequired = True
      Me.txtGrupo.Key = ""
      Me.txtGrupo.LabelAsoc = Me.lblGrupo
      Me.txtGrupo.Location = New System.Drawing.Point(132, 97)
      Me.txtGrupo.MaxLength = 15
      Me.txtGrupo.Name = "txtGrupo"
      Me.txtGrupo.Size = New System.Drawing.Size(138, 20)
      Me.txtGrupo.TabIndex = 10
      '
      'lblGrupo
      '
      Me.lblGrupo.AutoSize = True
      Me.lblGrupo.LabelAsoc = Nothing
      Me.lblGrupo.Location = New System.Drawing.Point(20, 101)
      Me.lblGrupo.Name = "lblGrupo"
      Me.lblGrupo.Size = New System.Drawing.Size(36, 13)
      Me.lblGrupo.TabIndex = 9
      Me.lblGrupo.Text = "Grupo"
      '
      'optEgreso
      '
      Me.optEgreso.AutoSize = True
      Me.optEgreso.BindearPropiedadControl = Nothing
      Me.optEgreso.BindearPropiedadEntidad = Nothing
      Me.optEgreso.Checked = True
      Me.optEgreso.ForeColorFocus = System.Drawing.Color.Red
      Me.optEgreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optEgreso.IsPK = False
      Me.optEgreso.IsRequired = False
      Me.optEgreso.Key = Nothing
      Me.optEgreso.LabelAsoc = Me.lblTipo
      Me.optEgreso.Location = New System.Drawing.Point(201, 72)
      Me.optEgreso.Name = "optEgreso"
      Me.optEgreso.Size = New System.Drawing.Size(58, 17)
      Me.optEgreso.TabIndex = 6
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
      Me.optIngreso.Location = New System.Drawing.Point(131, 72)
      Me.optIngreso.Name = "optIngreso"
      Me.optIngreso.Size = New System.Drawing.Size(60, 17)
      Me.optIngreso.TabIndex = 5
      Me.optIngreso.Text = "Ingreso"
      Me.optIngreso.UseVisualStyleBackColor = True
      '
      'gpoContabilidad
      '
      Me.gpoContabilidad.Controls.Add(Me.chbGeneraContabilidad)
      Me.gpoContabilidad.Controls.Add(Me.bscNombreCentroCosto)
      Me.gpoContabilidad.Controls.Add(Me.bscCodigoCentroCosto)
      Me.gpoContabilidad.Controls.Add(Me.lblCentroCostos)
      Me.gpoContabilidad.Controls.Add(Me.lblCta)
      Me.gpoContabilidad.Controls.Add(Me.bscDescCuenta)
      Me.gpoContabilidad.Controls.Add(Me.bscCodCuenta)
      Me.gpoContabilidad.Location = New System.Drawing.Point(22, 151)
      Me.gpoContabilidad.Name = "gpoContabilidad"
      Me.gpoContabilidad.Size = New System.Drawing.Size(448, 102)
      Me.gpoContabilidad.TabIndex = 15
      Me.gpoContabilidad.TabStop = False
      Me.gpoContabilidad.Text = "Contabilidad"
      '
      'chbGeneraContabilidad
      '
      Me.chbGeneraContabilidad.AutoSize = True
      Me.chbGeneraContabilidad.BindearPropiedadControl = "Checked"
      Me.chbGeneraContabilidad.BindearPropiedadEntidad = "GeneraContabilidad"
      Me.chbGeneraContabilidad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbGeneraContabilidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbGeneraContabilidad.IsPK = False
      Me.chbGeneraContabilidad.IsRequired = False
      Me.chbGeneraContabilidad.Key = Nothing
      Me.chbGeneraContabilidad.LabelAsoc = Me.lblPideCheque
      Me.chbGeneraContabilidad.Location = New System.Drawing.Point(24, 19)
      Me.chbGeneraContabilidad.Name = "chbGeneraContabilidad"
      Me.chbGeneraContabilidad.Size = New System.Drawing.Size(122, 17)
      Me.chbGeneraContabilidad.TabIndex = 31
      Me.chbGeneraContabilidad.Text = "Genera Contabilidad"
      Me.chbGeneraContabilidad.UseVisualStyleBackColor = True
      '
      'bscNombreCentroCosto
      '
      Me.bscNombreCentroCosto.ActivarFiltroEnGrilla = True
      Me.bscNombreCentroCosto.AutoSize = True
      Me.bscNombreCentroCosto.BindearPropiedadControl = Nothing
      Me.bscNombreCentroCosto.BindearPropiedadEntidad = Nothing
      Me.bscNombreCentroCosto.ConfigBuscador = Nothing
      Me.bscNombreCentroCosto.Datos = Nothing
      Me.bscNombreCentroCosto.FilaDevuelta = Nothing
      Me.bscNombreCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreCentroCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCentroCosto.IsDecimal = False
      Me.bscNombreCentroCosto.IsNumber = False
      Me.bscNombreCentroCosto.IsPK = False
      Me.bscNombreCentroCosto.IsRequired = False
      Me.bscNombreCentroCosto.Key = ""
      Me.bscNombreCentroCosto.LabelAsoc = Me.lblCentroCostos
      Me.bscNombreCentroCosto.Location = New System.Drawing.Point(213, 74)
      Me.bscNombreCentroCosto.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreCentroCosto.MaxLengh = "32767"
      Me.bscNombreCentroCosto.Name = "bscNombreCentroCosto"
      Me.bscNombreCentroCosto.Permitido = True
      Me.bscNombreCentroCosto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreCentroCosto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreCentroCosto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreCentroCosto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreCentroCosto.Selecciono = False
      Me.bscNombreCentroCosto.Size = New System.Drawing.Size(229, 23)
      Me.bscNombreCentroCosto.TabIndex = 30
      '
      'lblCentroCostos
      '
      Me.lblCentroCostos.AutoSize = True
      Me.lblCentroCostos.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCentroCostos.LabelAsoc = Nothing
      Me.lblCentroCostos.Location = New System.Drawing.Point(21, 79)
      Me.lblCentroCostos.Name = "lblCentroCostos"
      Me.lblCentroCostos.Size = New System.Drawing.Size(88, 13)
      Me.lblCentroCostos.TabIndex = 29
      Me.lblCentroCostos.Text = "Centro de Costos"
      '
      'bscCodigoCentroCosto
      '
      Me.bscCodigoCentroCosto.ActivarFiltroEnGrilla = True
      Me.bscCodigoCentroCosto.BindearPropiedadControl = ""
      Me.bscCodigoCentroCosto.BindearPropiedadEntidad = ""
      Me.bscCodigoCentroCosto.ConfigBuscador = Nothing
      Me.bscCodigoCentroCosto.Datos = Nothing
      Me.bscCodigoCentroCosto.FilaDevuelta = Nothing
      Me.bscCodigoCentroCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCentroCosto.IsDecimal = False
      Me.bscCodigoCentroCosto.IsNumber = False
      Me.bscCodigoCentroCosto.IsPK = False
      Me.bscCodigoCentroCosto.IsRequired = False
      Me.bscCodigoCentroCosto.Key = ""
      Me.bscCodigoCentroCosto.LabelAsoc = Me.lblCentroCostos
      Me.bscCodigoCentroCosto.Location = New System.Drawing.Point(112, 74)
      Me.bscCodigoCentroCosto.MaxLengh = "32767"
      Me.bscCodigoCentroCosto.Name = "bscCodigoCentroCosto"
      Me.bscCodigoCentroCosto.Permitido = True
      Me.bscCodigoCentroCosto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCentroCosto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCentroCosto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCentroCosto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCentroCosto.Selecciono = False
      Me.bscCodigoCentroCosto.Size = New System.Drawing.Size(94, 23)
      Me.bscCodigoCentroCosto.TabIndex = 28
      '
      'lblCta
      '
      Me.lblCta.AutoSize = True
      Me.lblCta.LabelAsoc = Nothing
      Me.lblCta.Location = New System.Drawing.Point(21, 52)
      Me.lblCta.Name = "lblCta"
      Me.lblCta.Size = New System.Drawing.Size(86, 13)
      Me.lblCta.TabIndex = 27
      Me.lblCta.Text = "Cuenta Contable"
      '
      'bscDescCuenta
      '
      Me.bscDescCuenta.BindearPropiedadControl = ""
      Me.bscDescCuenta.BindearPropiedadEntidad = ""
      Me.bscDescCuenta.Datos = Nothing
      Me.bscDescCuenta.FilaDevuelta = Nothing
      Me.bscDescCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDescCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDescCuenta.IsDecimal = False
      Me.bscDescCuenta.IsNumber = False
      Me.bscDescCuenta.IsPK = False
      Me.bscDescCuenta.IsRequired = False
      Me.bscDescCuenta.Key = ""
      Me.bscDescCuenta.LabelAsoc = Nothing
      Me.bscDescCuenta.Location = New System.Drawing.Point(213, 48)
      Me.bscDescCuenta.MaxLengh = "32767"
      Me.bscDescCuenta.Name = "bscDescCuenta"
      Me.bscDescCuenta.Permitido = True
      Me.bscDescCuenta.Selecciono = False
      Me.bscDescCuenta.Size = New System.Drawing.Size(229, 20)
      Me.bscDescCuenta.TabIndex = 25
      '
      'bscCodCuenta
      '
      Me.bscCodCuenta.BindearPropiedadControl = "Text"
      Me.bscCodCuenta.BindearPropiedadEntidad = "idCuentaContable"
      Me.bscCodCuenta.Datos = Nothing
      Me.bscCodCuenta.FilaDevuelta = Nothing
      Me.bscCodCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodCuenta.IsDecimal = False
      Me.bscCodCuenta.IsNumber = True
      Me.bscCodCuenta.IsPK = False
      Me.bscCodCuenta.IsRequired = False
      Me.bscCodCuenta.Key = ""
      Me.bscCodCuenta.LabelAsoc = Nothing
      Me.bscCodCuenta.Location = New System.Drawing.Point(112, 48)
      Me.bscCodCuenta.MaxLengh = "32767"
      Me.bscCodCuenta.Name = "bscCodCuenta"
      Me.bscCodCuenta.Permitido = True
      Me.bscCodCuenta.Selecciono = False
      Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuenta.TabIndex = 23
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
      Me.cmbAFIPConceptoCM05.Location = New System.Drawing.Point(132, 123)
      Me.cmbAFIPConceptoCM05.Name = "cmbAFIPConceptoCM05"
      Me.cmbAFIPConceptoCM05.Size = New System.Drawing.Size(183, 21)
      Me.cmbAFIPConceptoCM05.TabIndex = 14
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
      Me.chbAFIPConceptoCM05.Location = New System.Drawing.Point(23, 125)
      Me.chbAFIPConceptoCM05.Name = "chbAFIPConceptoCM05"
      Me.chbAFIPConceptoCM05.Size = New System.Drawing.Size(103, 17)
      Me.chbAFIPConceptoCM05.TabIndex = 13
      Me.chbAFIPConceptoCM05.Text = "Concepto CM05"
      Me.chbAFIPConceptoCM05.UseVisualStyleBackColor = True
      '
      'CuentasDeCajasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(476, 301)
      Me.Controls.Add(Me.cmbAFIPConceptoCM05)
      Me.Controls.Add(Me.chbAFIPConceptoCM05)
      Me.Controls.Add(Me.gpoContabilidad)
      Me.Controls.Add(Me.optEgreso)
      Me.Controls.Add(Me.optIngreso)
      Me.Controls.Add(Me.txtGrupo)
      Me.Controls.Add(Me.lblGrupo)
      Me.Controls.Add(Me.lblPideCheque)
      Me.Controls.Add(Me.chbPideCheque)
      Me.Controls.Add(Me.lblEsPosdatado)
      Me.Controls.Add(Me.lblTipo)
      Me.Controls.Add(Me.chbEsPosdatado)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.txtCodigo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CuentasDeCajasDetalle"
      Me.Text = "Cuentas de Caja"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.chbEsPosdatado, 0)
      Me.Controls.SetChildIndex(Me.lblTipo, 0)
      Me.Controls.SetChildIndex(Me.lblEsPosdatado, 0)
      Me.Controls.SetChildIndex(Me.chbPideCheque, 0)
      Me.Controls.SetChildIndex(Me.lblPideCheque, 0)
      Me.Controls.SetChildIndex(Me.lblGrupo, 0)
      Me.Controls.SetChildIndex(Me.txtGrupo, 0)
      Me.Controls.SetChildIndex(Me.optIngreso, 0)
      Me.Controls.SetChildIndex(Me.optEgreso, 0)
      Me.Controls.SetChildIndex(Me.gpoContabilidad, 0)
      Me.Controls.SetChildIndex(Me.chbAFIPConceptoCM05, 0)
      Me.Controls.SetChildIndex(Me.cmbAFIPConceptoCM05, 0)
      Me.gpoContabilidad.ResumeLayout(False)
      Me.gpoContabilidad.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents chbEsPosdatado As Eniac.Controles.CheckBox
   Friend WithEvents lblTipo As Eniac.Controles.Label
   Friend WithEvents lblEsPosdatado As Eniac.Controles.Label
   Friend WithEvents lblPideCheque As Eniac.Controles.Label
   Friend WithEvents chbPideCheque As Eniac.Controles.CheckBox
   Friend WithEvents txtGrupo As Eniac.Controles.TextBox
   Friend WithEvents lblGrupo As Eniac.Controles.Label
   Friend WithEvents optEgreso As Eniac.Controles.RadioButton
   Friend WithEvents optIngreso As Eniac.Controles.RadioButton
   Friend WithEvents gpoContabilidad As System.Windows.Forms.GroupBox
   Friend WithEvents lblCta As Eniac.Controles.Label
   Friend WithEvents bscDescCuenta As Eniac.Controles.Buscador2
   Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador2
   Friend WithEvents bscNombreCentroCosto As Eniac.Controles.Buscador2
   Friend WithEvents lblCentroCostos As Eniac.Controles.Label
   Friend WithEvents bscCodigoCentroCosto As Eniac.Controles.Buscador2
   Friend WithEvents chbGeneraContabilidad As Eniac.Controles.CheckBox
   Public WithEvents cmbAFIPConceptoCM05 As Controles.ComboBox
   Friend WithEvents chbAFIPConceptoCM05 As Controles.CheckBox
End Class
