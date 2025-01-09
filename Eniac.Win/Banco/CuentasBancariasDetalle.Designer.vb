<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentasBancariasDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CuentasBancariasDetalle))
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.lblBanco = New Eniac.Controles.Label()
      Me.lblBancoSucursal = New Eniac.Controles.Label()
      Me.cmbMonedas = New Eniac.Controles.ComboBox()
      Me.lblMoneda = New Eniac.Controles.Label()
      Me.cmbClaseCuenta = New Eniac.Controles.ComboBox()
      Me.lblClaseDeCuenta = New Eniac.Controles.Label()
      Me.lblCuentaBancaria = New Eniac.Controles.Label()
      Me.txtCuentaBancaria = New Eniac.Controles.MaskedTextBox()
      Me.cmbBanco = New Eniac.Controles.ComboBox()
      Me.cmbLocalidad = New Eniac.Controles.ComboBox()
      Me.grbBanco = New System.Windows.Forms.GroupBox()
      Me.txtBancoSucursal = New Eniac.Controles.TextBox()
      Me.lblNombreCuenta = New Eniac.Controles.Label()
      Me.txtNombreCuenta = New Eniac.Controles.TextBox()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.gpoContabilidad = New System.Windows.Forms.GroupBox()
      Me.lblDebe = New Eniac.Controles.Label()
      Me.lblDesc = New Eniac.Controles.Label()
      Me.bscDescCuenta = New Eniac.Controles.Buscador()
      Me.bscCodCuenta = New Eniac.Controles.Buscador()
      Me.Label3 = New Eniac.Controles.Label()
      Me.cmbPlan = New Eniac.Controles.ComboBox()
      Me.lblCbu = New Eniac.Controles.Label()
      Me.lblCbuAlias = New Eniac.Controles.Label()
      Me.txtCbu = New Eniac.Controles.TextBox()
      Me.txtCbuAlias = New Eniac.Controles.TextBox()
      Me.chbParaInformarEnFEC = New Eniac.Controles.CheckBox()
      Me.cmbEmpresas = New Eniac.Win.ComboBoxEmpresas()
      Me.chbTitularCtaBanc = New Eniac.Controles.CheckBox()
        Me.grbBanco.SuspendLayout()
        Me.gpoContabilidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(396, 406)
        Me.btnAceptar.TabIndex = 20
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(482, 406)
        Me.btnCancelar.TabIndex = 21
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(295, 406)
        Me.btnCopiar.TabIndex = 23
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(235, 406)
        Me.btnAplicar.TabIndex = 22
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(18, 29)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = "Text"
        Me.txtCodigo.BindearPropiedadEntidad = "IdCuentaBancaria"
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = True
        Me.txtCodigo.IsPK = True
        Me.txtCodigo.IsRequired = True
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(109, 27)
        Me.txtCodigo.MaxLength = 6
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(59, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.LabelAsoc = Nothing
        Me.lblLocalidad.Location = New System.Drawing.Point(246, 20)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lblLocalidad.TabIndex = 4
        Me.lblLocalidad.Text = "Localidad"
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.LabelAsoc = Nothing
        Me.lblBanco.Location = New System.Drawing.Point(3, 20)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(44, 13)
        Me.lblBanco.TabIndex = 0
        Me.lblBanco.Text = "Nombre"
        '
        'lblBancoSucursal
        '
        Me.lblBancoSucursal.AutoSize = True
        Me.lblBancoSucursal.LabelAsoc = Nothing
        Me.lblBancoSucursal.Location = New System.Drawing.Point(187, 20)
        Me.lblBancoSucursal.Name = "lblBancoSucursal"
        Me.lblBancoSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblBancoSucursal.TabIndex = 2
        Me.lblBancoSucursal.Text = "Sucursal"
        '
        'cmbMonedas
        '
        Me.cmbMonedas.BindearPropiedadControl = "SelectedValue"
        Me.cmbMonedas.BindearPropiedadEntidad = "Moneda.IdMoneda"
        Me.cmbMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonedas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMonedas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMonedas.FormattingEnabled = True
        Me.cmbMonedas.IsPK = False
        Me.cmbMonedas.IsRequired = True
        Me.cmbMonedas.Key = Nothing
        Me.cmbMonedas.LabelAsoc = Me.lblMoneda
        Me.cmbMonedas.Location = New System.Drawing.Point(334, 86)
        Me.cmbMonedas.Name = "cmbMonedas"
        Me.cmbMonedas.Size = New System.Drawing.Size(80, 21)
        Me.cmbMonedas.TabIndex = 7
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.LabelAsoc = Nothing
        Me.lblMoneda.Location = New System.Drawing.Point(269, 90)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblMoneda.TabIndex = 6
        Me.lblMoneda.Text = "Moneda"
        '
        'cmbClaseCuenta
        '
        Me.cmbClaseCuenta.BindearPropiedadControl = "SelectedValue"
        Me.cmbClaseCuenta.BindearPropiedadEntidad = "CuentaBancariaClase.IdCuentaBancariaClase"
        Me.cmbClaseCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClaseCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbClaseCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbClaseCuenta.FormattingEnabled = True
        Me.cmbClaseCuenta.IsPK = False
        Me.cmbClaseCuenta.IsRequired = True
        Me.cmbClaseCuenta.Key = Nothing
        Me.cmbClaseCuenta.LabelAsoc = Me.lblClaseDeCuenta
        Me.cmbClaseCuenta.Location = New System.Drawing.Point(109, 86)
        Me.cmbClaseCuenta.Name = "cmbClaseCuenta"
        Me.cmbClaseCuenta.Size = New System.Drawing.Size(130, 21)
        Me.cmbClaseCuenta.TabIndex = 5
        '
        'lblClaseDeCuenta
        '
        Me.lblClaseDeCuenta.AutoSize = True
        Me.lblClaseDeCuenta.LabelAsoc = Nothing
        Me.lblClaseDeCuenta.Location = New System.Drawing.Point(18, 90)
        Me.lblClaseDeCuenta.Name = "lblClaseDeCuenta"
        Me.lblClaseDeCuenta.Size = New System.Drawing.Size(33, 13)
        Me.lblClaseDeCuenta.TabIndex = 4
        Me.lblClaseDeCuenta.Text = "Clase"
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.AutoSize = True
        Me.lblCuentaBancaria.LabelAsoc = Nothing
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(18, 58)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(85, 13)
        Me.lblCuentaBancaria.TabIndex = 2
        Me.lblCuentaBancaria.Text = "Código Bancario"
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.BindearPropiedadControl = "Text"
        Me.txtCuentaBancaria.BindearPropiedadEntidad = "CodigoBancario"
        Me.txtCuentaBancaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaBancaria.IsDecimal = False
        Me.txtCuentaBancaria.IsNumber = False
        Me.txtCuentaBancaria.IsPK = False
        Me.txtCuentaBancaria.IsRequired = True
        Me.txtCuentaBancaria.Key = ""
        Me.txtCuentaBancaria.LabelAsoc = Me.lblCuentaBancaria
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(109, 56)
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(140, 20)
        Me.txtCuentaBancaria.TabIndex = 3
        '
        'cmbBanco
        '
        Me.cmbBanco.BindearPropiedadControl = "SelectedValue"
        Me.cmbBanco.BindearPropiedadEntidad = "Banco.idBanco"
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.IsPK = False
        Me.cmbBanco.IsRequired = True
        Me.cmbBanco.Key = Nothing
        Me.cmbBanco.LabelAsoc = Me.lblBanco
        Me.cmbBanco.Location = New System.Drawing.Point(6, 36)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(170, 21)
        Me.cmbBanco.TabIndex = 1
        '
        'cmbLocalidad
        '
        Me.cmbLocalidad.BindearPropiedadControl = "SelectedValue"
        Me.cmbLocalidad.BindearPropiedadEntidad = "Localidad.IdLocalidad"
        Me.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLocalidad.FormattingEnabled = True
        Me.cmbLocalidad.IsPK = False
        Me.cmbLocalidad.IsRequired = True
        Me.cmbLocalidad.Key = Nothing
        Me.cmbLocalidad.LabelAsoc = Me.lblLocalidad
        Me.cmbLocalidad.Location = New System.Drawing.Point(246, 35)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(170, 21)
        Me.cmbLocalidad.TabIndex = 5
        '
        'grbBanco
        '
        Me.grbBanco.Controls.Add(Me.txtBancoSucursal)
        Me.grbBanco.Controls.Add(Me.cmbBanco)
        Me.grbBanco.Controls.Add(Me.cmbLocalidad)
        Me.grbBanco.Controls.Add(Me.lblBanco)
        Me.grbBanco.Controls.Add(Me.lblLocalidad)
        Me.grbBanco.Controls.Add(Me.lblBancoSucursal)
        Me.grbBanco.Location = New System.Drawing.Point(109, 196)
        Me.grbBanco.Name = "grbBanco"
        Me.grbBanco.Size = New System.Drawing.Size(428, 67)
        Me.grbBanco.TabIndex = 16
        Me.grbBanco.TabStop = False
        Me.grbBanco.Text = "Banco"
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
        Me.txtBancoSucursal.IsRequired = False
        Me.txtBancoSucursal.Key = ""
        Me.txtBancoSucursal.LabelAsoc = Me.lblBancoSucursal
        Me.txtBancoSucursal.Location = New System.Drawing.Point(188, 35)
        Me.txtBancoSucursal.MaxLength = 4
        Me.txtBancoSucursal.Name = "txtBancoSucursal"
        Me.txtBancoSucursal.Size = New System.Drawing.Size(45, 20)
        Me.txtBancoSucursal.TabIndex = 3
        Me.txtBancoSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreCuenta
        '
        Me.lblNombreCuenta.AutoSize = True
        Me.lblNombreCuenta.LabelAsoc = Nothing
        Me.lblNombreCuenta.Location = New System.Drawing.Point(18, 123)
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        Me.lblNombreCuenta.Size = New System.Drawing.Size(81, 13)
        Me.lblNombreCuenta.TabIndex = 8
        Me.lblNombreCuenta.Text = "Nombre Cuenta"
        '
        'txtNombreCuenta
        '
        Me.txtNombreCuenta.BindearPropiedadControl = "Text"
        Me.txtNombreCuenta.BindearPropiedadEntidad = "NombreCuenta"
        Me.txtNombreCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCuenta.Formato = ""
        Me.txtNombreCuenta.IsDecimal = False
        Me.txtNombreCuenta.IsNumber = False
        Me.txtNombreCuenta.IsPK = False
        Me.txtNombreCuenta.IsRequired = True
        Me.txtNombreCuenta.Key = ""
        Me.txtNombreCuenta.LabelAsoc = Me.lblNombreCuenta
        Me.txtNombreCuenta.Location = New System.Drawing.Point(109, 115)
        Me.txtNombreCuenta.MaxLength = 50
        Me.txtNombreCuenta.Name = "txtNombreCuenta"
        Me.txtNombreCuenta.Size = New System.Drawing.Size(305, 20)
        Me.txtNombreCuenta.TabIndex = 9
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(349, 30)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(65, 17)
        Me.chbActivo.TabIndex = 19
        Me.chbActivo.Text = "ACTIVO"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'gpoContabilidad
        '
        Me.gpoContabilidad.Controls.Add(Me.lblDebe)
        Me.gpoContabilidad.Controls.Add(Me.lblDesc)
        Me.gpoContabilidad.Controls.Add(Me.bscDescCuenta)
        Me.gpoContabilidad.Controls.Add(Me.bscCodCuenta)
        Me.gpoContabilidad.Controls.Add(Me.Label3)
        Me.gpoContabilidad.Controls.Add(Me.cmbPlan)
        Me.gpoContabilidad.Location = New System.Drawing.Point(18, 305)
        Me.gpoContabilidad.Name = "gpoContabilidad"
        Me.gpoContabilidad.Size = New System.Drawing.Size(544, 85)
        Me.gpoContabilidad.TabIndex = 18
        Me.gpoContabilidad.TabStop = False
        Me.gpoContabilidad.Text = "Contabilidad"
        '
        'lblDebe
        '
        Me.lblDebe.AutoSize = True
        Me.lblDebe.LabelAsoc = Nothing
        Me.lblDebe.Location = New System.Drawing.Point(6, 47)
        Me.lblDebe.Name = "lblDebe"
        Me.lblDebe.Size = New System.Drawing.Size(77, 13)
        Me.lblDebe.TabIndex = 2
        Me.lblDebe.Text = "Cuenta Código"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.LabelAsoc = Nothing
        Me.lblDesc.Location = New System.Drawing.Point(187, 47)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(100, 13)
        Me.lblDesc.TabIndex = 4
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
        Me.bscDescCuenta.Location = New System.Drawing.Point(294, 47)
        Me.bscDescCuenta.MaxLengh = "32767"
        Me.bscDescCuenta.Name = "bscDescCuenta"
        Me.bscDescCuenta.Permitido = True
        Me.bscDescCuenta.Selecciono = False
        Me.bscDescCuenta.Size = New System.Drawing.Size(229, 20)
        Me.bscDescCuenta.TabIndex = 5
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
        Me.bscCodCuenta.Location = New System.Drawing.Point(86, 47)
        Me.bscCodCuenta.MaxLengh = "32767"
        Me.bscCodCuenta.Name = "bscCodCuenta"
        Me.bscCodCuenta.Permitido = True
        Me.bscCodCuenta.Selecciono = False
        Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
        Me.bscCodCuenta.TabIndex = 3
        Me.bscCodCuenta.Titulo = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(204, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Plan de Cuentas:"
        '
        'cmbPlan
        '
        Me.cmbPlan.BindearPropiedadControl = "SelectedValue"
        Me.cmbPlan.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlan.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPlan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPlan.FormattingEnabled = True
        Me.cmbPlan.IsPK = False
        Me.cmbPlan.IsRequired = False
        Me.cmbPlan.Key = Nothing
        Me.cmbPlan.LabelAsoc = Me.Label3
        Me.cmbPlan.Location = New System.Drawing.Point(298, 13)
        Me.cmbPlan.Name = "cmbPlan"
        Me.cmbPlan.Size = New System.Drawing.Size(163, 21)
        Me.cmbPlan.TabIndex = 1
        '
        'lblCbu
        '
        Me.lblCbu.AutoSize = True
        Me.lblCbu.LabelAsoc = Nothing
        Me.lblCbu.Location = New System.Drawing.Point(18, 150)
        Me.lblCbu.Name = "lblCbu"
        Me.lblCbu.Size = New System.Drawing.Size(38, 13)
        Me.lblCbu.TabIndex = 10
        Me.lblCbu.Text = "C.B.U."
        '
        'lblCbuAlias
        '
        Me.lblCbuAlias.AutoSize = True
        Me.lblCbuAlias.LabelAsoc = Nothing
        Me.lblCbuAlias.Location = New System.Drawing.Point(269, 150)
        Me.lblCbuAlias.Name = "lblCbuAlias"
        Me.lblCbuAlias.Size = New System.Drawing.Size(63, 13)
        Me.lblCbuAlias.TabIndex = 12
        Me.lblCbuAlias.Text = "C.B.U. Alias"
        '
        'txtCbu
        '
        Me.txtCbu.BindearPropiedadControl = "Text"
        Me.txtCbu.BindearPropiedadEntidad = "Cbu"
        Me.txtCbu.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCbu.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCbu.Formato = ""
        Me.txtCbu.IsDecimal = False
        Me.txtCbu.IsNumber = True
        Me.txtCbu.IsPK = False
        Me.txtCbu.IsRequired = False
        Me.txtCbu.Key = ""
        Me.txtCbu.LabelAsoc = Me.lblCbu
        Me.txtCbu.Location = New System.Drawing.Point(109, 146)
        Me.txtCbu.MaxLength = 22
        Me.txtCbu.Name = "txtCbu"
        Me.txtCbu.Size = New System.Drawing.Size(150, 20)
        Me.txtCbu.TabIndex = 11
        Me.txtCbu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCbuAlias
        '
        Me.txtCbuAlias.BindearPropiedadControl = "Text"
        Me.txtCbuAlias.BindearPropiedadEntidad = "CbuAlias"
        Me.txtCbuAlias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCbuAlias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCbuAlias.Formato = ""
        Me.txtCbuAlias.IsDecimal = False
        Me.txtCbuAlias.IsNumber = False
        Me.txtCbuAlias.IsPK = False
        Me.txtCbuAlias.IsRequired = False
        Me.txtCbuAlias.Key = ""
        Me.txtCbuAlias.LabelAsoc = Me.lblCbuAlias
        Me.txtCbuAlias.Location = New System.Drawing.Point(334, 146)
        Me.txtCbuAlias.MaxLength = 20
        Me.txtCbuAlias.Name = "txtCbuAlias"
        Me.txtCbuAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtCbuAlias.TabIndex = 13
        '
        'chbParaInformarEnFEC
        '
        Me.chbParaInformarEnFEC.AutoSize = True
        Me.chbParaInformarEnFEC.BindearPropiedadControl = "Checked"
        Me.chbParaInformarEnFEC.BindearPropiedadEntidad = "ParaInformarEnFEC"
        Me.chbParaInformarEnFEC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbParaInformarEnFEC.ForeColorFocus = System.Drawing.Color.Red
        Me.chbParaInformarEnFEC.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbParaInformarEnFEC.IsPK = False
        Me.chbParaInformarEnFEC.IsRequired = False
        Me.chbParaInformarEnFEC.Key = Nothing
        Me.chbParaInformarEnFEC.LabelAsoc = Nothing
        Me.chbParaInformarEnFEC.Location = New System.Drawing.Point(267, 277)
        Me.chbParaInformarEnFEC.Name = "chbParaInformarEnFEC"
        Me.chbParaInformarEnFEC.Size = New System.Drawing.Size(270, 17)
        Me.chbParaInformarEnFEC.TabIndex = 17
        Me.chbParaInformarEnFEC.Text = "Para Factura de Crédito Electrónica MiPyMEs (FCE)"
        Me.chbParaInformarEnFEC.UseVisualStyleBackColor = True
        '
        'cmbEmpresas
        '
        Me.cmbEmpresas.BindearPropiedadControl = "SelectedValue"
        Me.cmbEmpresas.BindearPropiedadEntidad = "IdEmpresa"
        Me.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresas.Enabled = False
        Me.cmbEmpresas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmpresas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmpresas.FormattingEnabled = True
        Me.cmbEmpresas.IsPK = False
        Me.cmbEmpresas.IsRequired = False
        Me.cmbEmpresas.Key = Nothing
        Me.cmbEmpresas.LabelAsoc = Nothing
        Me.cmbEmpresas.Location = New System.Drawing.Point(272, 175)
        Me.cmbEmpresas.Name = "cmbEmpresas"
        Me.cmbEmpresas.Size = New System.Drawing.Size(212, 21)
        Me.cmbEmpresas.TabIndex = 15
        '
        'chbTitularCtaBanc
        '
        Me.chbTitularCtaBanc.AutoSize = True
        Me.chbTitularCtaBanc.BindearPropiedadControl = Nothing
        Me.chbTitularCtaBanc.BindearPropiedadEntidad = Nothing
        Me.chbTitularCtaBanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbTitularCtaBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTitularCtaBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTitularCtaBanc.IsPK = False
        Me.chbTitularCtaBanc.IsRequired = False
        Me.chbTitularCtaBanc.Key = Nothing
        Me.chbTitularCtaBanc.LabelAsoc = Nothing
        Me.chbTitularCtaBanc.Location = New System.Drawing.Point(109, 177)
        Me.chbTitularCtaBanc.Name = "chbTitularCtaBanc"
        Me.chbTitularCtaBanc.Size = New System.Drawing.Size(160, 17)
        Me.chbTitularCtaBanc.TabIndex = 14
        Me.chbTitularCtaBanc.Text = "Titular Cuenta Bancaria"
        Me.chbTitularCtaBanc.UseVisualStyleBackColor = True
        '
        'CuentasBancariasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(572, 448)
        Me.Controls.Add(Me.chbTitularCtaBanc)
        Me.Controls.Add(Me.cmbEmpresas)
        Me.Controls.Add(Me.chbParaInformarEnFEC)
        Me.Controls.Add(Me.txtCbuAlias)
        Me.Controls.Add(Me.txtCbu)
        Me.Controls.Add(Me.lblCbuAlias)
        Me.Controls.Add(Me.lblCbu)
        Me.Controls.Add(Me.gpoContabilidad)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.txtNombreCuenta)
        Me.Controls.Add(Me.lblNombreCuenta)
        Me.Controls.Add(Me.grbBanco)
        Me.Controls.Add(Me.cmbMonedas)
        Me.Controls.Add(Me.lblMoneda)
        Me.Controls.Add(Me.cmbClaseCuenta)
        Me.Controls.Add(Me.lblClaseDeCuenta)
        Me.Controls.Add(Me.lblCuentaBancaria)
        Me.Controls.Add(Me.txtCuentaBancaria)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblCodigo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CuentasBancariasDetalle"
        Me.Text = "Cuentas Bancarias"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.txtCuentaBancaria, 0)
        Me.Controls.SetChildIndex(Me.lblCuentaBancaria, 0)
        Me.Controls.SetChildIndex(Me.lblClaseDeCuenta, 0)
        Me.Controls.SetChildIndex(Me.cmbClaseCuenta, 0)
        Me.Controls.SetChildIndex(Me.lblMoneda, 0)
        Me.Controls.SetChildIndex(Me.cmbMonedas, 0)
        Me.Controls.SetChildIndex(Me.grbBanco, 0)
        Me.Controls.SetChildIndex(Me.lblNombreCuenta, 0)
        Me.Controls.SetChildIndex(Me.txtNombreCuenta, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.gpoContabilidad, 0)
        Me.Controls.SetChildIndex(Me.lblCbu, 0)
        Me.Controls.SetChildIndex(Me.lblCbuAlias, 0)
        Me.Controls.SetChildIndex(Me.txtCbu, 0)
        Me.Controls.SetChildIndex(Me.txtCbuAlias, 0)
        Me.Controls.SetChildIndex(Me.chbParaInformarEnFEC, 0)
        Me.Controls.SetChildIndex(Me.cmbEmpresas, 0)
        Me.Controls.SetChildIndex(Me.chbTitularCtaBanc, 0)
        Me.grbBanco.ResumeLayout(False)
        Me.grbBanco.PerformLayout()
        Me.gpoContabilidad.ResumeLayout(False)
        Me.gpoContabilidad.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
    Friend WithEvents lblLocalidad As Eniac.Controles.Label
    Friend WithEvents lblBanco As Eniac.Controles.Label
   Friend WithEvents lblBancoSucursal As Eniac.Controles.Label
   Friend WithEvents cmbMonedas As Eniac.Controles.ComboBox
   Friend WithEvents lblMoneda As Eniac.Controles.Label
   Friend WithEvents cmbClaseCuenta As Eniac.Controles.ComboBox
   Friend WithEvents lblClaseDeCuenta As Eniac.Controles.Label
   Friend WithEvents lblCuentaBancaria As Eniac.Controles.Label
   Friend WithEvents txtCuentaBancaria As Eniac.Controles.MaskedTextBox
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents grbBanco As System.Windows.Forms.GroupBox
   Friend WithEvents lblNombreCuenta As Eniac.Controles.Label
   Friend WithEvents txtNombreCuenta As Eniac.Controles.TextBox
   Friend WithEvents txtBancoSucursal As Eniac.Controles.TextBox
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents gpoContabilidad As System.Windows.Forms.GroupBox
   Friend WithEvents lblDebe As Eniac.Controles.Label
   Friend WithEvents lblDesc As Eniac.Controles.Label
   Friend WithEvents bscDescCuenta As Eniac.Controles.Buscador
   Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents lblCbu As Eniac.Controles.Label
   Friend WithEvents lblCbuAlias As Eniac.Controles.Label
   Friend WithEvents txtCbu As Eniac.Controles.TextBox
   Friend WithEvents txtCbuAlias As Eniac.Controles.TextBox
   Friend WithEvents chbParaInformarEnFEC As Eniac.Controles.CheckBox
   Friend WithEvents cmbEmpresas As Eniac.Win.ComboBoxEmpresas
   Friend WithEvents chbTitularCtaBanc As Controles.CheckBox
End Class
