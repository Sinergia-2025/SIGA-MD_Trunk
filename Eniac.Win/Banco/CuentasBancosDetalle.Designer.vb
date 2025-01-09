<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentasBancosDetalle
   Inherits Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CuentasBancosDetalle))
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblTipo = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblPideCheque = New Eniac.Controles.Label()
      Me.chbPideCheque = New Eniac.Controles.CheckBox()
      Me.lblEsPosdatado = New Eniac.Controles.Label()
      Me.chbEsPosdatado = New Eniac.Controles.CheckBox()
      Me.optEgreso = New Eniac.Controles.RadioButton()
      Me.optIngreso = New Eniac.Controles.RadioButton()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.gpoContabilidad = New System.Windows.Forms.GroupBox()
      Me.bscNombreCentroCosto = New Eniac.Controles.Buscador2()
      Me.lblCentroCostos = New Eniac.Controles.Label()
      Me.bscCodigoCentroCosto = New Eniac.Controles.Buscador2()
      Me.lblDebe = New Eniac.Controles.Label()
      Me.lblDesc = New Eniac.Controles.Label()
      Me.bscDescCuenta = New Eniac.Controles.Buscador()
      Me.bscCodCuenta = New Eniac.Controles.Buscador()
      Me.txtIdGrupoCuenta = New Eniac.Controles.TextBox()
      Me.lblGrupoCuenta = New Eniac.Controles.Label()
        Me.cmbAFIPConceptoCM05 = New Eniac.Controles.ComboBox()
        Me.chbAFIPConceptoCM05 = New Eniac.Controles.CheckBox()
        Me.gpoContabilidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(381, 273)
        Me.btnAceptar.TabIndex = 16
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(467, 273)
        Me.btnCancelar.TabIndex = 17
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(16, 17)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código "
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(16, 49)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(16, 84)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 4
        Me.lblTipo.Text = "Tipo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = "Text"
        Me.txtCodigo.BindearPropiedadEntidad = "IdCuentaBanco"
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = True
        Me.txtCodigo.IsPK = True
        Me.txtCodigo.IsRequired = True
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(99, 14)
        Me.txtCodigo.MaxLength = 6
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(59, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPideCheque
        '
        Me.lblPideCheque.AutoSize = True
        Me.lblPideCheque.LabelAsoc = Nothing
        Me.lblPideCheque.Location = New System.Drawing.Point(272, 120)
        Me.lblPideCheque.Name = "lblPideCheque"
        Me.lblPideCheque.Size = New System.Drawing.Size(68, 13)
        Me.lblPideCheque.TabIndex = 9
        Me.lblPideCheque.Text = "Pide Cheque"
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
        Me.chbPideCheque.Location = New System.Drawing.Point(355, 119)
        Me.chbPideCheque.Name = "chbPideCheque"
        Me.chbPideCheque.Size = New System.Drawing.Size(15, 14)
        Me.chbPideCheque.TabIndex = 10
        Me.chbPideCheque.TabStop = False
        Me.chbPideCheque.UseVisualStyleBackColor = True
        '
        'lblEsPosdatado
        '
        Me.lblEsPosdatado.AutoSize = True
        Me.lblEsPosdatado.LabelAsoc = Nothing
        Me.lblEsPosdatado.Location = New System.Drawing.Point(16, 120)
        Me.lblEsPosdatado.Name = "lblEsPosdatado"
        Me.lblEsPosdatado.Size = New System.Drawing.Size(73, 13)
        Me.lblEsPosdatado.TabIndex = 7
        Me.lblEsPosdatado.Text = "Es Posdatado"
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
        Me.chbEsPosdatado.Location = New System.Drawing.Point(99, 119)
        Me.chbEsPosdatado.Name = "chbEsPosdatado"
        Me.chbEsPosdatado.Size = New System.Drawing.Size(15, 14)
        Me.chbEsPosdatado.TabIndex = 8
        Me.chbEsPosdatado.TabStop = False
        Me.chbEsPosdatado.UseVisualStyleBackColor = True
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
        Me.optEgreso.Location = New System.Drawing.Point(167, 82)
        Me.optEgreso.Name = "optEgreso"
        Me.optEgreso.Size = New System.Drawing.Size(58, 17)
        Me.optEgreso.TabIndex = 6
        Me.optEgreso.Text = "Egreso"
        Me.optEgreso.UseVisualStyleBackColor = True
        '
        'optIngreso
        '
        Me.optIngreso.AutoSize = True
        Me.optIngreso.BindearPropiedadControl = Nothing
        Me.optIngreso.BindearPropiedadEntidad = Nothing
        Me.optIngreso.Checked = True
        Me.optIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.optIngreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optIngreso.IsPK = False
        Me.optIngreso.IsRequired = False
        Me.optIngreso.Key = Nothing
        Me.optIngreso.LabelAsoc = Me.lblTipo
        Me.optIngreso.Location = New System.Drawing.Point(99, 82)
        Me.optIngreso.Name = "optIngreso"
        Me.optIngreso.Size = New System.Drawing.Size(60, 17)
        Me.optIngreso.TabIndex = 5
        Me.optIngreso.TabStop = True
        Me.optIngreso.Text = "Ingreso"
        Me.optIngreso.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreCuentaBanco"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(99, 46)
        Me.txtNombre.MaxLength = 40
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(300, 20)
        Me.txtNombre.TabIndex = 3
        '
        'gpoContabilidad
        '
        Me.gpoContabilidad.Controls.Add(Me.bscNombreCentroCosto)
        Me.gpoContabilidad.Controls.Add(Me.bscCodigoCentroCosto)
        Me.gpoContabilidad.Controls.Add(Me.lblCentroCostos)
        Me.gpoContabilidad.Controls.Add(Me.lblDebe)
        Me.gpoContabilidad.Controls.Add(Me.lblDesc)
        Me.gpoContabilidad.Controls.Add(Me.bscDescCuenta)
        Me.gpoContabilidad.Controls.Add(Me.bscCodCuenta)
        Me.gpoContabilidad.Location = New System.Drawing.Point(12, 178)
        Me.gpoContabilidad.Name = "gpoContabilidad"
        Me.gpoContabilidad.Size = New System.Drawing.Size(544, 89)
        Me.gpoContabilidad.TabIndex = 15
        Me.gpoContabilidad.TabStop = False
        Me.gpoContabilidad.Text = "Contabilidad"
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
        Me.bscNombreCentroCosto.Location = New System.Drawing.Point(198, 51)
        Me.bscNombreCentroCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCentroCosto.MaxLengh = "32767"
        Me.bscNombreCentroCosto.Name = "bscNombreCentroCosto"
        Me.bscNombreCentroCosto.Permitido = True
        Me.bscNombreCentroCosto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCentroCosto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCentroCosto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCentroCosto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCentroCosto.Selecciono = False
        Me.bscNombreCentroCosto.Size = New System.Drawing.Size(337, 23)
        Me.bscNombreCentroCosto.TabIndex = 33
        '
        'lblCentroCostos
        '
        Me.lblCentroCostos.AutoSize = True
        Me.lblCentroCostos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCentroCostos.LabelAsoc = Nothing
        Me.lblCentroCostos.Location = New System.Drawing.Point(7, 55)
        Me.lblCentroCostos.Name = "lblCentroCostos"
        Me.lblCentroCostos.Size = New System.Drawing.Size(88, 13)
        Me.lblCentroCostos.TabIndex = 32
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
        Me.bscCodigoCentroCosto.Location = New System.Drawing.Point(98, 51)
        Me.bscCodigoCentroCosto.MaxLengh = "32767"
        Me.bscCodigoCentroCosto.Name = "bscCodigoCentroCosto"
        Me.bscCodigoCentroCosto.Permitido = True
        Me.bscCodigoCentroCosto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCentroCosto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCentroCosto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCentroCosto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCentroCosto.Selecciono = False
        Me.bscCodigoCentroCosto.Size = New System.Drawing.Size(95, 23)
        Me.bscCodigoCentroCosto.TabIndex = 31
        '
        'lblDebe
        '
        Me.lblDebe.AutoSize = True
        Me.lblDebe.LabelAsoc = Nothing
        Me.lblDebe.Location = New System.Drawing.Point(18, 25)
        Me.lblDebe.Name = "lblDebe"
        Me.lblDebe.Size = New System.Drawing.Size(77, 13)
        Me.lblDebe.TabIndex = 0
        Me.lblDebe.Text = "Cuenta Código"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.LabelAsoc = Nothing
        Me.lblDesc.Location = New System.Drawing.Point(199, 25)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(100, 13)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "Cuenta Descripción"
        '
        'bscDescCuenta
        '
        Me.bscDescCuenta.AyudaAncho = 608
        Me.bscDescCuenta.BindearPropiedadControl = ""
        Me.bscDescCuenta.BindearPropiedadEntidad = ""
        Me.bscDescCuenta.ColumnasAlineacion = Nothing
        Me.bscDescCuenta.ColumnasAncho = Nothing
        Me.bscDescCuenta.ColumnasFormato = Nothing
        Me.bscDescCuenta.ColumnasOcultas = Nothing
        Me.bscDescCuenta.ColumnasTitulos = Nothing
        Me.bscDescCuenta.Datos = Nothing
        Me.bscDescCuenta.FilaDevuelta = Nothing
        Me.bscDescCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDescCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDescCuenta.IsDecimal = False
        Me.bscDescCuenta.IsNumber = False
        Me.bscDescCuenta.IsPK = False
        Me.bscDescCuenta.IsRequired = False
        Me.bscDescCuenta.Key = ""
        Me.bscDescCuenta.LabelAsoc = Me.lblDesc
        Me.bscDescCuenta.Location = New System.Drawing.Point(306, 25)
        Me.bscDescCuenta.MaxLengh = "32767"
        Me.bscDescCuenta.Name = "bscDescCuenta"
        Me.bscDescCuenta.Permitido = True
        Me.bscDescCuenta.Selecciono = False
        Me.bscDescCuenta.Size = New System.Drawing.Size(229, 20)
        Me.bscDescCuenta.TabIndex = 3
        Me.bscDescCuenta.Titulo = Nothing
        '
        'bscCodCuenta
        '
        Me.bscCodCuenta.AyudaAncho = 608
        Me.bscCodCuenta.BindearPropiedadControl = "Text"
        Me.bscCodCuenta.BindearPropiedadEntidad = "idCuentacontable"
        Me.bscCodCuenta.ColumnasAlineacion = Nothing
        Me.bscCodCuenta.ColumnasAncho = Nothing
        Me.bscCodCuenta.ColumnasFormato = Nothing
        Me.bscCodCuenta.ColumnasOcultas = Nothing
        Me.bscCodCuenta.ColumnasTitulos = Nothing
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
        Me.bscCodCuenta.Location = New System.Drawing.Point(98, 25)
        Me.bscCodCuenta.MaxLengh = "32767"
        Me.bscCodCuenta.Name = "bscCodCuenta"
        Me.bscCodCuenta.Permitido = True
        Me.bscCodCuenta.Selecciono = False
        Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
        Me.bscCodCuenta.TabIndex = 1
        Me.bscCodCuenta.Titulo = Nothing
        '
        'txtIdGrupoCuenta
        '
        Me.txtIdGrupoCuenta.BindearPropiedadControl = "Text"
        Me.txtIdGrupoCuenta.BindearPropiedadEntidad = "IdGrupoCuenta"
        Me.txtIdGrupoCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdGrupoCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdGrupoCuenta.Formato = ""
        Me.txtIdGrupoCuenta.IsDecimal = False
        Me.txtIdGrupoCuenta.IsNumber = False
        Me.txtIdGrupoCuenta.IsPK = False
        Me.txtIdGrupoCuenta.IsRequired = True
        Me.txtIdGrupoCuenta.Key = ""
        Me.txtIdGrupoCuenta.LabelAsoc = Me.lblGrupoCuenta
        Me.txtIdGrupoCuenta.Location = New System.Drawing.Point(99, 149)
        Me.txtIdGrupoCuenta.MaxLength = 15
        Me.txtIdGrupoCuenta.Name = "txtIdGrupoCuenta"
        Me.txtIdGrupoCuenta.Size = New System.Drawing.Size(150, 20)
        Me.txtIdGrupoCuenta.TabIndex = 12
        '
        'lblGrupoCuenta
        '
        Me.lblGrupoCuenta.AutoSize = True
        Me.lblGrupoCuenta.LabelAsoc = Nothing
        Me.lblGrupoCuenta.Location = New System.Drawing.Point(16, 152)
        Me.lblGrupoCuenta.Name = "lblGrupoCuenta"
        Me.lblGrupoCuenta.Size = New System.Drawing.Size(36, 13)
        Me.lblGrupoCuenta.TabIndex = 11
        Me.lblGrupoCuenta.Text = "Grupo"
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
        Me.cmbAFIPConceptoCM05.Location = New System.Drawing.Point(364, 148)
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
        Me.chbAFIPConceptoCM05.Location = New System.Drawing.Point(255, 150)
        Me.chbAFIPConceptoCM05.Name = "chbAFIPConceptoCM05"
        Me.chbAFIPConceptoCM05.Size = New System.Drawing.Size(103, 17)
        Me.chbAFIPConceptoCM05.TabIndex = 13
        Me.chbAFIPConceptoCM05.Text = "Concepto CM05"
        Me.chbAFIPConceptoCM05.UseVisualStyleBackColor = True
        '
        'CuentasBancosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(566, 315)
        Me.Controls.Add(Me.cmbAFIPConceptoCM05)
        Me.Controls.Add(Me.chbAFIPConceptoCM05)
        Me.Controls.Add(Me.lblGrupoCuenta)
        Me.Controls.Add(Me.txtIdGrupoCuenta)
        Me.Controls.Add(Me.gpoContabilidad)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.optEgreso)
        Me.Controls.Add(Me.optIngreso)
        Me.Controls.Add(Me.lblPideCheque)
        Me.Controls.Add(Me.chbPideCheque)
        Me.Controls.Add(Me.lblEsPosdatado)
        Me.Controls.Add(Me.chbEsPosdatado)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.lblNombre)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CuentasBancosDetalle"
        Me.Text = "Cuentas Bancos"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblTipo, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.chbEsPosdatado, 0)
        Me.Controls.SetChildIndex(Me.lblEsPosdatado, 0)
        Me.Controls.SetChildIndex(Me.chbPideCheque, 0)
        Me.Controls.SetChildIndex(Me.lblPideCheque, 0)
        Me.Controls.SetChildIndex(Me.optIngreso, 0)
        Me.Controls.SetChildIndex(Me.optEgreso, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.gpoContabilidad, 0)
        Me.Controls.SetChildIndex(Me.txtIdGrupoCuenta, 0)
        Me.Controls.SetChildIndex(Me.lblGrupoCuenta, 0)
        Me.Controls.SetChildIndex(Me.chbAFIPConceptoCM05, 0)
        Me.Controls.SetChildIndex(Me.cmbAFIPConceptoCM05, 0)
        Me.gpoContabilidad.ResumeLayout(False)
        Me.gpoContabilidad.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblTipo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents lblPideCheque As Eniac.Controles.Label
   Friend WithEvents chbPideCheque As Eniac.Controles.CheckBox
   Friend WithEvents lblEsPosdatado As Eniac.Controles.Label
   Friend WithEvents chbEsPosdatado As Eniac.Controles.CheckBox
   Friend WithEvents optEgreso As Eniac.Controles.RadioButton
   Friend WithEvents optIngreso As Eniac.Controles.RadioButton
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents gpoContabilidad As System.Windows.Forms.GroupBox
   Friend WithEvents lblDebe As Eniac.Controles.Label
   Friend WithEvents lblDesc As Eniac.Controles.Label
   Friend WithEvents bscDescCuenta As Eniac.Controles.Buscador
   Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador
   Friend WithEvents txtIdGrupoCuenta As Eniac.Controles.TextBox
   Friend WithEvents lblGrupoCuenta As Eniac.Controles.Label
   Friend WithEvents bscNombreCentroCosto As Eniac.Controles.Buscador2
   Friend WithEvents lblCentroCostos As Eniac.Controles.Label
   Friend WithEvents bscCodigoCentroCosto As Eniac.Controles.Buscador2
    Public WithEvents cmbAFIPConceptoCM05 As Controles.ComboBox
    Friend WithEvents chbAFIPConceptoCM05 As Controles.CheckBox
End Class
