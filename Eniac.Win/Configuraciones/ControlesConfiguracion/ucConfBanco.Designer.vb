<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfBanco
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.grbLibroBanco = New System.Windows.Forms.GroupBox()
      Me.txtColorConciliado = New Eniac.Controles.TextBox()
      Me.lblColorConciliado = New Eniac.Controles.Label()
      Me.txtColorDesconciliado = New Eniac.Controles.TextBox()
      Me.lblDesconciliado = New Eniac.Controles.Label()
      Me.btnColorConciliado = New System.Windows.Forms.Button()
      Me.btnColorDesconciliado = New System.Windows.Forms.Button()
      Me.grbCuentasDeBanco = New System.Windows.Forms.GroupBox()
      Me.txtCuentaBancoLiquidacionesTarjetas = New Eniac.Controles.TextBox()
      Me.lblCuentaBancoLiquidacionesTarjetas = New Eniac.Controles.Label()
      Me.lblCuentaBancoPagoProveedores = New Eniac.Controles.Label()
      Me.txtCuentaBancoExtraccion = New Eniac.Controles.TextBox()
      Me.lblCuentaBancoExtraccion = New Eniac.Controles.Label()
      Me.lblCuentaBancoDeposito = New Eniac.Controles.Label()
      Me.lblCuentaBancoTransfBancaria = New Eniac.Controles.Label()
      Me.txtCuentaBancoAcredTarjeta = New Eniac.Controles.TextBox()
      Me.lblCuentaBancoAcredTarjeta = New Eniac.Controles.Label()
      Me.txtCuentaBancoPagoProveedores = New Eniac.Controles.TextBox()
      Me.txtCuentaBancoDeposito = New Eniac.Controles.TextBox()
      Me.txtCuentaBancoTransfBancaria = New Eniac.Controles.TextBox()
      Me.chbDepositoMuestraClienteXTitular = New Eniac.Controles.CheckBox()
      Me.chbUnificaLibrosDeBanco = New Eniac.Controles.CheckBox()
      Me.txtDiasVisualizacionLibroBanco = New Eniac.Controles.TextBox()
      Me.lblDiasVisualizacionLibroBanco = New Eniac.Controles.Label()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.grbLibroBanco.SuspendLayout()
      Me.grbCuentasDeBanco.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbLibroBanco
      '
      Me.grbLibroBanco.Controls.Add(Me.txtColorConciliado)
      Me.grbLibroBanco.Controls.Add(Me.txtColorDesconciliado)
      Me.grbLibroBanco.Controls.Add(Me.btnColorConciliado)
      Me.grbLibroBanco.Controls.Add(Me.lblDesconciliado)
      Me.grbLibroBanco.Controls.Add(Me.lblColorConciliado)
      Me.grbLibroBanco.Controls.Add(Me.btnColorDesconciliado)
      Me.grbLibroBanco.Location = New System.Drawing.Point(578, 68)
      Me.grbLibroBanco.Name = "grbLibroBanco"
      Me.grbLibroBanco.Size = New System.Drawing.Size(309, 85)
      Me.grbLibroBanco.TabIndex = 64
      Me.grbLibroBanco.TabStop = False
      Me.grbLibroBanco.Text = "Libro Banco Utiliza Color"
      '
      'txtColorConciliado
      '
      Me.txtColorConciliado.BindearPropiedadControl = "Key"
      Me.txtColorConciliado.BindearPropiedadEntidad = "COLORCONCILIADO"
      Me.txtColorConciliado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtColorConciliado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtColorConciliado.Formato = ""
      Me.txtColorConciliado.IsDecimal = False
      Me.txtColorConciliado.IsNumber = False
      Me.txtColorConciliado.IsPK = False
      Me.txtColorConciliado.IsRequired = False
      Me.txtColorConciliado.Key = ""
      Me.txtColorConciliado.LabelAsoc = Me.lblColorConciliado
      Me.txtColorConciliado.Location = New System.Drawing.Point(134, 19)
      Me.txtColorConciliado.Name = "txtColorConciliado"
      Me.txtColorConciliado.ReadOnly = True
      Me.txtColorConciliado.Size = New System.Drawing.Size(82, 20)
      Me.txtColorConciliado.TabIndex = 36
      Me.txtColorConciliado.TabStop = False
      '
      'lblColorConciliado
      '
      Me.lblColorConciliado.AutoSize = True
      Me.lblColorConciliado.LabelAsoc = Nothing
      Me.lblColorConciliado.Location = New System.Drawing.Point(32, 23)
      Me.lblColorConciliado.Name = "lblColorConciliado"
      Me.lblColorConciliado.Size = New System.Drawing.Size(56, 13)
      Me.lblColorConciliado.TabIndex = 35
      Me.lblColorConciliado.Text = "Conciliado"
      '
      'txtColorDesconciliado
      '
      Me.txtColorDesconciliado.BindearPropiedadControl = "Key"
      Me.txtColorDesconciliado.BindearPropiedadEntidad = "COLORDESCONCILIADO"
      Me.txtColorDesconciliado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtColorDesconciliado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtColorDesconciliado.Formato = ""
      Me.txtColorDesconciliado.IsDecimal = False
      Me.txtColorDesconciliado.IsNumber = False
      Me.txtColorDesconciliado.IsPK = False
      Me.txtColorDesconciliado.IsRequired = False
      Me.txtColorDesconciliado.Key = ""
      Me.txtColorDesconciliado.LabelAsoc = Me.lblDesconciliado
      Me.txtColorDesconciliado.Location = New System.Drawing.Point(134, 53)
      Me.txtColorDesconciliado.Name = "txtColorDesconciliado"
      Me.txtColorDesconciliado.ReadOnly = True
      Me.txtColorDesconciliado.Size = New System.Drawing.Size(82, 20)
      Me.txtColorDesconciliado.TabIndex = 39
      Me.txtColorDesconciliado.TabStop = False
      '
      'lblDesconciliado
      '
      Me.lblDesconciliado.AutoSize = True
      Me.lblDesconciliado.LabelAsoc = Nothing
      Me.lblDesconciliado.Location = New System.Drawing.Point(32, 57)
      Me.lblDesconciliado.Name = "lblDesconciliado"
      Me.lblDesconciliado.Size = New System.Drawing.Size(73, 13)
      Me.lblDesconciliado.TabIndex = 38
      Me.lblDesconciliado.Text = "No Conciliado"
      '
      'btnColorConciliado
      '
      Me.btnColorConciliado.Location = New System.Drawing.Point(222, 18)
      Me.btnColorConciliado.Name = "btnColorConciliado"
      Me.btnColorConciliado.Size = New System.Drawing.Size(57, 23)
      Me.btnColorConciliado.TabIndex = 37
      Me.btnColorConciliado.Text = "Paleta"
      Me.btnColorConciliado.UseVisualStyleBackColor = True
      '
      'btnColorDesconciliado
      '
      Me.btnColorDesconciliado.Location = New System.Drawing.Point(222, 52)
      Me.btnColorDesconciliado.Name = "btnColorDesconciliado"
      Me.btnColorDesconciliado.Size = New System.Drawing.Size(57, 23)
      Me.btnColorDesconciliado.TabIndex = 40
      Me.btnColorDesconciliado.Text = "Paleta"
      Me.btnColorDesconciliado.UseVisualStyleBackColor = True
      '
      'grbCuentasDeBanco
      '
      Me.grbCuentasDeBanco.Controls.Add(Me.txtCuentaBancoLiquidacionesTarjetas)
      Me.grbCuentasDeBanco.Controls.Add(Me.lblCuentaBancoLiquidacionesTarjetas)
      Me.grbCuentasDeBanco.Controls.Add(Me.lblCuentaBancoPagoProveedores)
      Me.grbCuentasDeBanco.Controls.Add(Me.txtCuentaBancoExtraccion)
      Me.grbCuentasDeBanco.Controls.Add(Me.lblCuentaBancoDeposito)
      Me.grbCuentasDeBanco.Controls.Add(Me.lblCuentaBancoExtraccion)
      Me.grbCuentasDeBanco.Controls.Add(Me.lblCuentaBancoTransfBancaria)
      Me.grbCuentasDeBanco.Controls.Add(Me.txtCuentaBancoAcredTarjeta)
      Me.grbCuentasDeBanco.Controls.Add(Me.txtCuentaBancoPagoProveedores)
      Me.grbCuentasDeBanco.Controls.Add(Me.lblCuentaBancoAcredTarjeta)
      Me.grbCuentasDeBanco.Controls.Add(Me.txtCuentaBancoDeposito)
      Me.grbCuentasDeBanco.Controls.Add(Me.txtCuentaBancoTransfBancaria)
      Me.grbCuentasDeBanco.Location = New System.Drawing.Point(14, 159)
      Me.grbCuentasDeBanco.Name = "grbCuentasDeBanco"
      Me.grbCuentasDeBanco.Size = New System.Drawing.Size(374, 181)
      Me.grbCuentasDeBanco.TabIndex = 63
      Me.grbCuentasDeBanco.TabStop = False
      Me.grbCuentasDeBanco.Text = "Configuración de Cuentas de Banco"
      '
      'txtCuentaBancoLiquidacionesTarjetas
      '
      Me.txtCuentaBancoLiquidacionesTarjetas.BindearPropiedadControl = Nothing
      Me.txtCuentaBancoLiquidacionesTarjetas.BindearPropiedadEntidad = Nothing
      Me.txtCuentaBancoLiquidacionesTarjetas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuentaBancoLiquidacionesTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuentaBancoLiquidacionesTarjetas.Formato = ""
      Me.txtCuentaBancoLiquidacionesTarjetas.IsDecimal = False
      Me.txtCuentaBancoLiquidacionesTarjetas.IsNumber = True
      Me.txtCuentaBancoLiquidacionesTarjetas.IsPK = False
      Me.txtCuentaBancoLiquidacionesTarjetas.IsRequired = False
      Me.txtCuentaBancoLiquidacionesTarjetas.Key = ""
      Me.txtCuentaBancoLiquidacionesTarjetas.LabelAsoc = Me.lblCuentaBancoLiquidacionesTarjetas
      Me.txtCuentaBancoLiquidacionesTarjetas.Location = New System.Drawing.Point(13, 152)
      Me.txtCuentaBancoLiquidacionesTarjetas.MaxLength = 7
      Me.txtCuentaBancoLiquidacionesTarjetas.Name = "txtCuentaBancoLiquidacionesTarjetas"
      Me.txtCuentaBancoLiquidacionesTarjetas.Size = New System.Drawing.Size(35, 20)
      Me.txtCuentaBancoLiquidacionesTarjetas.TabIndex = 34
      Me.txtCuentaBancoLiquidacionesTarjetas.Tag = "CTABANCOLIQUIDACIONTARJETA"
      Me.txtCuentaBancoLiquidacionesTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCuentaBancoLiquidacionesTarjetas
      '
      Me.lblCuentaBancoLiquidacionesTarjetas.AutoSize = True
      Me.lblCuentaBancoLiquidacionesTarjetas.LabelAsoc = Nothing
      Me.lblCuentaBancoLiquidacionesTarjetas.Location = New System.Drawing.Point(54, 155)
      Me.lblCuentaBancoLiquidacionesTarjetas.Name = "lblCuentaBancoLiquidacionesTarjetas"
      Me.lblCuentaBancoLiquidacionesTarjetas.Size = New System.Drawing.Size(309, 13)
      Me.lblCuentaBancoLiquidacionesTarjetas.TabIndex = 35
      Me.lblCuentaBancoLiquidacionesTarjetas.Text = "Define la cuenta para movimientos de Liquidaciones de Tarjetas"
      '
      'lblCuentaBancoPagoProveedores
      '
      Me.lblCuentaBancoPagoProveedores.AutoSize = True
      Me.lblCuentaBancoPagoProveedores.LabelAsoc = Nothing
      Me.lblCuentaBancoPagoProveedores.Location = New System.Drawing.Point(54, 25)
      Me.lblCuentaBancoPagoProveedores.Name = "lblCuentaBancoPagoProveedores"
      Me.lblCuentaBancoPagoProveedores.Size = New System.Drawing.Size(290, 13)
      Me.lblCuentaBancoPagoProveedores.TabIndex = 27
      Me.lblCuentaBancoPagoProveedores.Text = "Define la cuenta para movimientos de Pagos a Proveedores"
      '
      'txtCuentaBancoExtraccion
      '
      Me.txtCuentaBancoExtraccion.BindearPropiedadControl = Nothing
      Me.txtCuentaBancoExtraccion.BindearPropiedadEntidad = Nothing
      Me.txtCuentaBancoExtraccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuentaBancoExtraccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuentaBancoExtraccion.Formato = ""
      Me.txtCuentaBancoExtraccion.IsDecimal = False
      Me.txtCuentaBancoExtraccion.IsNumber = True
      Me.txtCuentaBancoExtraccion.IsPK = False
      Me.txtCuentaBancoExtraccion.IsRequired = False
      Me.txtCuentaBancoExtraccion.Key = ""
      Me.txtCuentaBancoExtraccion.LabelAsoc = Me.lblCuentaBancoExtraccion
      Me.txtCuentaBancoExtraccion.Location = New System.Drawing.Point(13, 126)
      Me.txtCuentaBancoExtraccion.MaxLength = 7
      Me.txtCuentaBancoExtraccion.Name = "txtCuentaBancoExtraccion"
      Me.txtCuentaBancoExtraccion.Size = New System.Drawing.Size(35, 20)
      Me.txtCuentaBancoExtraccion.TabIndex = 32
      Me.txtCuentaBancoExtraccion.Tag = ""
      Me.txtCuentaBancoExtraccion.Text = "3"
      Me.txtCuentaBancoExtraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCuentaBancoExtraccion
      '
      Me.lblCuentaBancoExtraccion.AutoSize = True
      Me.lblCuentaBancoExtraccion.LabelAsoc = Nothing
      Me.lblCuentaBancoExtraccion.Location = New System.Drawing.Point(54, 129)
      Me.lblCuentaBancoExtraccion.Name = "lblCuentaBancoExtraccion"
      Me.lblCuentaBancoExtraccion.Size = New System.Drawing.Size(299, 13)
      Me.lblCuentaBancoExtraccion.TabIndex = 33
      Me.lblCuentaBancoExtraccion.Text = "Define la cuenta para movimientos de Extracciones Bancarias"
      '
      'lblCuentaBancoDeposito
      '
      Me.lblCuentaBancoDeposito.AutoSize = True
      Me.lblCuentaBancoDeposito.LabelAsoc = Nothing
      Me.lblCuentaBancoDeposito.Location = New System.Drawing.Point(54, 77)
      Me.lblCuentaBancoDeposito.Name = "lblCuentaBancoDeposito"
      Me.lblCuentaBancoDeposito.Size = New System.Drawing.Size(285, 13)
      Me.lblCuentaBancoDeposito.TabIndex = 28
      Me.lblCuentaBancoDeposito.Text = "Define la cuenta para movimientos de Depositos Bancarios"
      '
      'lblCuentaBancoTransfBancaria
      '
      Me.lblCuentaBancoTransfBancaria.AutoSize = True
      Me.lblCuentaBancoTransfBancaria.LabelAsoc = Nothing
      Me.lblCuentaBancoTransfBancaria.Location = New System.Drawing.Point(54, 51)
      Me.lblCuentaBancoTransfBancaria.Name = "lblCuentaBancoTransfBancaria"
      Me.lblCuentaBancoTransfBancaria.Size = New System.Drawing.Size(308, 13)
      Me.lblCuentaBancoTransfBancaria.TabIndex = 29
      Me.lblCuentaBancoTransfBancaria.Text = "Define la cuenta para movimientos de Transferencias Bancarias"
      '
      'txtCuentaBancoAcredTarjeta
      '
      Me.txtCuentaBancoAcredTarjeta.BindearPropiedadControl = Nothing
      Me.txtCuentaBancoAcredTarjeta.BindearPropiedadEntidad = Nothing
      Me.txtCuentaBancoAcredTarjeta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuentaBancoAcredTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuentaBancoAcredTarjeta.Formato = ""
      Me.txtCuentaBancoAcredTarjeta.IsDecimal = False
      Me.txtCuentaBancoAcredTarjeta.IsNumber = True
      Me.txtCuentaBancoAcredTarjeta.IsPK = False
      Me.txtCuentaBancoAcredTarjeta.IsRequired = False
      Me.txtCuentaBancoAcredTarjeta.Key = ""
      Me.txtCuentaBancoAcredTarjeta.LabelAsoc = Me.lblCuentaBancoAcredTarjeta
      Me.txtCuentaBancoAcredTarjeta.Location = New System.Drawing.Point(13, 99)
      Me.txtCuentaBancoAcredTarjeta.MaxLength = 7
      Me.txtCuentaBancoAcredTarjeta.Name = "txtCuentaBancoAcredTarjeta"
      Me.txtCuentaBancoAcredTarjeta.Size = New System.Drawing.Size(35, 20)
      Me.txtCuentaBancoAcredTarjeta.TabIndex = 30
      Me.txtCuentaBancoAcredTarjeta.Tag = ""
      Me.txtCuentaBancoAcredTarjeta.Text = "11"
      Me.txtCuentaBancoAcredTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCuentaBancoAcredTarjeta
      '
      Me.lblCuentaBancoAcredTarjeta.AutoSize = True
      Me.lblCuentaBancoAcredTarjeta.LabelAsoc = Nothing
      Me.lblCuentaBancoAcredTarjeta.Location = New System.Drawing.Point(54, 103)
      Me.lblCuentaBancoAcredTarjeta.Name = "lblCuentaBancoAcredTarjeta"
      Me.lblCuentaBancoAcredTarjeta.Size = New System.Drawing.Size(238, 13)
      Me.lblCuentaBancoAcredTarjeta.TabIndex = 31
      Me.lblCuentaBancoAcredTarjeta.Text = "Define la cuenta acreditación Tarjetas de Crédito"
      '
      'txtCuentaBancoPagoProveedores
      '
      Me.txtCuentaBancoPagoProveedores.BindearPropiedadControl = Nothing
      Me.txtCuentaBancoPagoProveedores.BindearPropiedadEntidad = Nothing
      Me.txtCuentaBancoPagoProveedores.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuentaBancoPagoProveedores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuentaBancoPagoProveedores.Formato = ""
      Me.txtCuentaBancoPagoProveedores.IsDecimal = False
      Me.txtCuentaBancoPagoProveedores.IsNumber = True
      Me.txtCuentaBancoPagoProveedores.IsPK = False
      Me.txtCuentaBancoPagoProveedores.IsRequired = False
      Me.txtCuentaBancoPagoProveedores.Key = ""
      Me.txtCuentaBancoPagoProveedores.LabelAsoc = Me.lblCuentaBancoPagoProveedores
      Me.txtCuentaBancoPagoProveedores.Location = New System.Drawing.Point(13, 22)
      Me.txtCuentaBancoPagoProveedores.MaxLength = 7
      Me.txtCuentaBancoPagoProveedores.Name = "txtCuentaBancoPagoProveedores"
      Me.txtCuentaBancoPagoProveedores.Size = New System.Drawing.Size(35, 20)
      Me.txtCuentaBancoPagoProveedores.TabIndex = 24
      Me.txtCuentaBancoPagoProveedores.Tag = ""
      Me.txtCuentaBancoPagoProveedores.Text = "4"
      Me.txtCuentaBancoPagoProveedores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCuentaBancoDeposito
      '
      Me.txtCuentaBancoDeposito.BindearPropiedadControl = Nothing
      Me.txtCuentaBancoDeposito.BindearPropiedadEntidad = Nothing
      Me.txtCuentaBancoDeposito.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuentaBancoDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuentaBancoDeposito.Formato = ""
      Me.txtCuentaBancoDeposito.IsDecimal = False
      Me.txtCuentaBancoDeposito.IsNumber = True
      Me.txtCuentaBancoDeposito.IsPK = False
      Me.txtCuentaBancoDeposito.IsRequired = False
      Me.txtCuentaBancoDeposito.Key = ""
      Me.txtCuentaBancoDeposito.LabelAsoc = Me.lblCuentaBancoDeposito
      Me.txtCuentaBancoDeposito.Location = New System.Drawing.Point(13, 74)
      Me.txtCuentaBancoDeposito.MaxLength = 7
      Me.txtCuentaBancoDeposito.Name = "txtCuentaBancoDeposito"
      Me.txtCuentaBancoDeposito.Size = New System.Drawing.Size(35, 20)
      Me.txtCuentaBancoDeposito.TabIndex = 26
      Me.txtCuentaBancoDeposito.Tag = ""
      Me.txtCuentaBancoDeposito.Text = "6"
      Me.txtCuentaBancoDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCuentaBancoTransfBancaria
      '
      Me.txtCuentaBancoTransfBancaria.BindearPropiedadControl = Nothing
      Me.txtCuentaBancoTransfBancaria.BindearPropiedadEntidad = Nothing
      Me.txtCuentaBancoTransfBancaria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuentaBancoTransfBancaria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuentaBancoTransfBancaria.Formato = ""
      Me.txtCuentaBancoTransfBancaria.IsDecimal = False
      Me.txtCuentaBancoTransfBancaria.IsNumber = True
      Me.txtCuentaBancoTransfBancaria.IsPK = False
      Me.txtCuentaBancoTransfBancaria.IsRequired = False
      Me.txtCuentaBancoTransfBancaria.Key = ""
      Me.txtCuentaBancoTransfBancaria.LabelAsoc = Me.lblCuentaBancoTransfBancaria
      Me.txtCuentaBancoTransfBancaria.Location = New System.Drawing.Point(13, 48)
      Me.txtCuentaBancoTransfBancaria.MaxLength = 7
      Me.txtCuentaBancoTransfBancaria.Name = "txtCuentaBancoTransfBancaria"
      Me.txtCuentaBancoTransfBancaria.Size = New System.Drawing.Size(35, 20)
      Me.txtCuentaBancoTransfBancaria.TabIndex = 25
      Me.txtCuentaBancoTransfBancaria.Tag = ""
      Me.txtCuentaBancoTransfBancaria.Text = "5"
      Me.txtCuentaBancoTransfBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbDepositoMuestraClienteXTitular
      '
      Me.chbDepositoMuestraClienteXTitular.BindearPropiedadControl = Nothing
      Me.chbDepositoMuestraClienteXTitular.BindearPropiedadEntidad = Nothing
      Me.chbDepositoMuestraClienteXTitular.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDepositoMuestraClienteXTitular.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDepositoMuestraClienteXTitular.IsPK = False
      Me.chbDepositoMuestraClienteXTitular.IsRequired = False
      Me.chbDepositoMuestraClienteXTitular.Key = Nothing
      Me.chbDepositoMuestraClienteXTitular.LabelAsoc = Nothing
      Me.chbDepositoMuestraClienteXTitular.Location = New System.Drawing.Point(29, 127)
      Me.chbDepositoMuestraClienteXTitular.Name = "chbDepositoMuestraClienteXTitular"
      Me.chbDepositoMuestraClienteXTitular.Size = New System.Drawing.Size(321, 26)
      Me.chbDepositoMuestraClienteXTitular.TabIndex = 62
      Me.chbDepositoMuestraClienteXTitular.Tag = "DEPOSITOMUESTRACLIENTEXTITULAR"
      Me.chbDepositoMuestraClienteXTitular.Text = "Muestra Cliente en lugar de Titular en Depósito Bancario"
      Me.chbDepositoMuestraClienteXTitular.UseVisualStyleBackColor = True
      '
      'chbUnificaLibrosDeBanco
      '
      Me.chbUnificaLibrosDeBanco.BindearPropiedadControl = Nothing
      Me.chbUnificaLibrosDeBanco.BindearPropiedadEntidad = Nothing
      Me.chbUnificaLibrosDeBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUnificaLibrosDeBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUnificaLibrosDeBanco.IsPK = False
      Me.chbUnificaLibrosDeBanco.IsRequired = False
      Me.chbUnificaLibrosDeBanco.Key = Nothing
      Me.chbUnificaLibrosDeBanco.LabelAsoc = Nothing
      Me.chbUnificaLibrosDeBanco.Location = New System.Drawing.Point(29, 61)
      Me.chbUnificaLibrosDeBanco.Name = "chbUnificaLibrosDeBanco"
      Me.chbUnificaLibrosDeBanco.Size = New System.Drawing.Size(266, 26)
      Me.chbUnificaLibrosDeBanco.TabIndex = 59
      Me.chbUnificaLibrosDeBanco.Tag = "UNIFICALIBROSDEBANCO"
      Me.chbUnificaLibrosDeBanco.Text = "Unifica el Libro de Banco de las Sucursales"
      Me.chbUnificaLibrosDeBanco.UseVisualStyleBackColor = True
      '
      'txtDiasVisualizacionLibroBanco
      '
      Me.txtDiasVisualizacionLibroBanco.BindearPropiedadControl = Nothing
      Me.txtDiasVisualizacionLibroBanco.BindearPropiedadEntidad = Nothing
      Me.txtDiasVisualizacionLibroBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDiasVisualizacionLibroBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDiasVisualizacionLibroBanco.Formato = ""
      Me.txtDiasVisualizacionLibroBanco.IsDecimal = False
      Me.txtDiasVisualizacionLibroBanco.IsNumber = True
      Me.txtDiasVisualizacionLibroBanco.IsPK = False
      Me.txtDiasVisualizacionLibroBanco.IsRequired = False
      Me.txtDiasVisualizacionLibroBanco.Key = ""
      Me.txtDiasVisualizacionLibroBanco.LabelAsoc = Me.lblDiasVisualizacionLibroBanco
      Me.txtDiasVisualizacionLibroBanco.Location = New System.Drawing.Point(29, 97)
      Me.txtDiasVisualizacionLibroBanco.MaxLength = 3
      Me.txtDiasVisualizacionLibroBanco.Name = "txtDiasVisualizacionLibroBanco"
      Me.txtDiasVisualizacionLibroBanco.Size = New System.Drawing.Size(35, 20)
      Me.txtDiasVisualizacionLibroBanco.TabIndex = 60
      Me.txtDiasVisualizacionLibroBanco.Tag = "DIASVISUALIZACIONLIBROBANCO"
      Me.txtDiasVisualizacionLibroBanco.Text = "2"
      Me.txtDiasVisualizacionLibroBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiasVisualizacionLibroBanco
      '
      Me.lblDiasVisualizacionLibroBanco.AutoSize = True
      Me.lblDiasVisualizacionLibroBanco.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDiasVisualizacionLibroBanco.LabelAsoc = Nothing
      Me.lblDiasVisualizacionLibroBanco.Location = New System.Drawing.Point(78, 101)
      Me.lblDiasVisualizacionLibroBanco.Name = "lblDiasVisualizacionLibroBanco"
      Me.lblDiasVisualizacionLibroBanco.Size = New System.Drawing.Size(217, 13)
      Me.lblDiasVisualizacionLibroBanco.TabIndex = 61
      Me.lblDiasVisualizacionLibroBanco.Text = "Cantidad de dias a Visualizar Libro de Banco"
      '
      'ucConfBanco
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.grbLibroBanco)
      Me.Controls.Add(Me.grbCuentasDeBanco)
      Me.Controls.Add(Me.chbDepositoMuestraClienteXTitular)
      Me.Controls.Add(Me.chbUnificaLibrosDeBanco)
      Me.Controls.Add(Me.txtDiasVisualizacionLibroBanco)
      Me.Controls.Add(Me.lblDiasVisualizacionLibroBanco)
      Me.Name = "ucConfBanco"
      Me.Controls.SetChildIndex(Me.lblDiasVisualizacionLibroBanco, 0)
      Me.Controls.SetChildIndex(Me.txtDiasVisualizacionLibroBanco, 0)
      Me.Controls.SetChildIndex(Me.chbUnificaLibrosDeBanco, 0)
      Me.Controls.SetChildIndex(Me.chbDepositoMuestraClienteXTitular, 0)
      Me.Controls.SetChildIndex(Me.grbCuentasDeBanco, 0)
      Me.Controls.SetChildIndex(Me.grbLibroBanco, 0)
      Me.grbLibroBanco.ResumeLayout(False)
      Me.grbLibroBanco.PerformLayout()
      Me.grbCuentasDeBanco.ResumeLayout(False)
      Me.grbCuentasDeBanco.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents grbLibroBanco As GroupBox
   Friend WithEvents txtColorConciliado As Controles.TextBox
   Friend WithEvents lblColorConciliado As Controles.Label
   Friend WithEvents txtColorDesconciliado As Controles.TextBox
   Friend WithEvents lblDesconciliado As Controles.Label
   Friend WithEvents btnColorConciliado As Button
   Friend WithEvents btnColorDesconciliado As Button
   Friend WithEvents grbCuentasDeBanco As GroupBox
   Friend WithEvents txtCuentaBancoLiquidacionesTarjetas As Controles.TextBox
   Friend WithEvents lblCuentaBancoLiquidacionesTarjetas As Controles.Label
   Friend WithEvents lblCuentaBancoPagoProveedores As Controles.Label
   Friend WithEvents txtCuentaBancoExtraccion As Controles.TextBox
   Friend WithEvents lblCuentaBancoExtraccion As Controles.Label
   Friend WithEvents lblCuentaBancoDeposito As Controles.Label
   Friend WithEvents lblCuentaBancoTransfBancaria As Controles.Label
   Friend WithEvents txtCuentaBancoAcredTarjeta As Controles.TextBox
   Friend WithEvents lblCuentaBancoAcredTarjeta As Controles.Label
   Friend WithEvents txtCuentaBancoPagoProveedores As Controles.TextBox
   Friend WithEvents txtCuentaBancoDeposito As Controles.TextBox
   Friend WithEvents txtCuentaBancoTransfBancaria As Controles.TextBox
   Friend WithEvents chbDepositoMuestraClienteXTitular As Controles.CheckBox
   Friend WithEvents chbUnificaLibrosDeBanco As Controles.CheckBox
   Friend WithEvents txtDiasVisualizacionLibroBanco As Controles.TextBox
   Friend WithEvents lblDiasVisualizacionLibroBanco As Controles.Label
   Friend WithEvents cdColor As ColorDialog
End Class
