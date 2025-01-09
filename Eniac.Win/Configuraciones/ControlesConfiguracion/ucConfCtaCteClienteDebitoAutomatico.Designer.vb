<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfCtaCteClienteDebitoAutomatico
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
      Me.grbPagoMisCuentas = New System.Windows.Forms.GroupBox()
      Me.cmbFormatoPMC = New Eniac.Controles.ComboBox()
      Me.lblFormato = New Eniac.Controles.Label()
      Me.txtNumeroEmpresaBanelco = New Eniac.Controles.TextBox()
      Me.lblNumeroEmpresaBanelco = New Eniac.Controles.Label()
      Me.grbCuenta = New System.Windows.Forms.GroupBox()
      Me.bscCodigoCuentaBancariaTransfBanc = New Eniac.Controles.Buscador()
      Me.lblCuentaBancaria = New Eniac.Controles.Label()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.cmbTipoRecibo = New Eniac.Controles.ComboBox()
      Me.lblTipoRecibo = New Eniac.Controles.Label()
      Me.lblCobradores = New Eniac.Controles.Label()
      Me.bscCuentaBancariaTransfBanc = New Eniac.Controles.Buscador()
      Me.cmbCobradores = New Eniac.Controles.ComboBox()
      Me.grbSantander = New System.Windows.Forms.GroupBox()
      Me.lblDebitoAutomaticoSantanderCodigoServicio = New Eniac.Controles.Label()
      Me.txtDebitoAutomaticoSantanderCodigoServicio = New Eniac.Controles.TextBox()
      Me.grbBancoMacro = New System.Windows.Forms.GroupBox()
      Me.lblCaracterRellenado = New Eniac.Controles.Label()
      Me.txtCaracterRellenado = New Eniac.Controles.TextBox()
      Me.cmbCtaCteCliMacroAlineacion = New Eniac.Controles.ComboBox()
      Me.lblAlineacionIDAdherente = New Eniac.Controles.Label()
        Me.grbRoela = New System.Windows.Forms.GroupBox()
        Me.cmbInteresesVencRoela = New Eniac.Controles.ComboBox()
        Me.lblRoelaInteresVencimientos = New Eniac.Controles.Label()
        Me.txtRoelaIdentificadorCuenta = New Eniac.Controles.TextBox()
        Me.lblIdentificadorCuenta = New Eniac.Controles.Label()
        Me.txtRoelaIdentificadorConcepto = New Eniac.Controles.TextBox()
        Me.lblIdentificadorConcepto = New Eniac.Controles.Label()
        Me.grbSirPlus = New System.Windows.Forms.GroupBox()
        Me.cmbTiposComprobantesSIRPLUS = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTiposComprobantesSIRPLUS = New Eniac.Controles.Label()
        Me.txtCBU = New Eniac.Controles.TextBox()
        Me.lblTitularCBU = New Eniac.Controles.Label()
        Me.txtTitularCBU = New Eniac.Controles.TextBox()
        Me.lblCBU = New Eniac.Controles.Label()
        Me.txtNroEmpresa = New Eniac.Controles.TextBox()
        Me.lblNroCta = New Eniac.Controles.Label()
        Me.txtPassword = New Eniac.Controles.TextBox()
        Me.lblPassword = New Eniac.Controles.Label()
        Me.txtIdentCuenta = New Eniac.Controles.TextBox()
        Me.lblIdentCta = New Eniac.Controles.Label()
        Me.txtRazonSocial = New Eniac.Controles.TextBox()
        Me.lblRazonSocial = New Eniac.Controles.Label()
        Me.grbPagoMisCuentas.SuspendLayout()
        Me.grbCuenta.SuspendLayout()
        Me.grbSantander.SuspendLayout()
        Me.grbBancoMacro.SuspendLayout()
        Me.grbRoela.SuspendLayout()
        Me.grbSirPlus.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbPagoMisCuentas
        '
        Me.grbPagoMisCuentas.Controls.Add(Me.cmbFormatoPMC)
        Me.grbPagoMisCuentas.Controls.Add(Me.lblFormato)
        Me.grbPagoMisCuentas.Controls.Add(Me.txtNumeroEmpresaBanelco)
        Me.grbPagoMisCuentas.Controls.Add(Me.lblNumeroEmpresaBanelco)
        Me.grbPagoMisCuentas.Location = New System.Drawing.Point(7, 328)
        Me.grbPagoMisCuentas.Name = "grbPagoMisCuentas"
        Me.grbPagoMisCuentas.Size = New System.Drawing.Size(624, 64)
        Me.grbPagoMisCuentas.TabIndex = 3
        Me.grbPagoMisCuentas.TabStop = False
        Me.grbPagoMisCuentas.Text = "Pago Mis Cuentas"
        '
        'cmbFormatoPMC
        '
        Me.cmbFormatoPMC.BindearPropiedadControl = Nothing
        Me.cmbFormatoPMC.BindearPropiedadEntidad = Nothing
        Me.cmbFormatoPMC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatoPMC.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormatoPMC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormatoPMC.FormattingEnabled = True
        Me.cmbFormatoPMC.IsPK = False
        Me.cmbFormatoPMC.IsRequired = False
        Me.cmbFormatoPMC.Key = Nothing
        Me.cmbFormatoPMC.LabelAsoc = Me.lblFormato
        Me.cmbFormatoPMC.Location = New System.Drawing.Point(346, 22)
        Me.cmbFormatoPMC.Name = "cmbFormatoPMC"
        Me.cmbFormatoPMC.Size = New System.Drawing.Size(160, 21)
        Me.cmbFormatoPMC.TabIndex = 3
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.LabelAsoc = Nothing
        Me.lblFormato.Location = New System.Drawing.Point(298, 26)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(45, 13)
        Me.lblFormato.TabIndex = 2
        Me.lblFormato.Text = "Formato"
        '
        'txtNumeroEmpresaBanelco
        '
        Me.txtNumeroEmpresaBanelco.BindearPropiedadControl = ""
        Me.txtNumeroEmpresaBanelco.BindearPropiedadEntidad = ""
        Me.txtNumeroEmpresaBanelco.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroEmpresaBanelco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroEmpresaBanelco.Formato = ""
        Me.txtNumeroEmpresaBanelco.IsDecimal = False
        Me.txtNumeroEmpresaBanelco.IsNumber = True
        Me.txtNumeroEmpresaBanelco.IsPK = False
        Me.txtNumeroEmpresaBanelco.IsRequired = False
        Me.txtNumeroEmpresaBanelco.Key = ""
        Me.txtNumeroEmpresaBanelco.LabelAsoc = Me.lblNumeroEmpresaBanelco
        Me.txtNumeroEmpresaBanelco.Location = New System.Drawing.Point(201, 23)
        Me.txtNumeroEmpresaBanelco.MaxLength = 4
        Me.txtNumeroEmpresaBanelco.Name = "txtNumeroEmpresaBanelco"
        Me.txtNumeroEmpresaBanelco.Size = New System.Drawing.Size(45, 20)
        Me.txtNumeroEmpresaBanelco.TabIndex = 1
        Me.txtNumeroEmpresaBanelco.Tag = "NROEMPRESABANELCO"
        Me.txtNumeroEmpresaBanelco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumeroEmpresaBanelco
        '
        Me.lblNumeroEmpresaBanelco.AutoSize = True
        Me.lblNumeroEmpresaBanelco.LabelAsoc = Nothing
        Me.lblNumeroEmpresaBanelco.Location = New System.Drawing.Point(15, 26)
        Me.lblNumeroEmpresaBanelco.Name = "lblNumeroEmpresaBanelco"
        Me.lblNumeroEmpresaBanelco.Size = New System.Drawing.Size(151, 13)
        Me.lblNumeroEmpresaBanelco.TabIndex = 0
        Me.lblNumeroEmpresaBanelco.Text = "Numero de Empresa (Banelco)"
        '
        'grbCuenta
        '
        Me.grbCuenta.Controls.Add(Me.bscCodigoCuentaBancariaTransfBanc)
        Me.grbCuenta.Controls.Add(Me.cmbCajas)
        Me.grbCuenta.Controls.Add(Me.cmbTipoRecibo)
        Me.grbCuenta.Controls.Add(Me.lblCaja)
        Me.grbCuenta.Controls.Add(Me.lblTipoRecibo)
        Me.grbCuenta.Controls.Add(Me.lblCobradores)
        Me.grbCuenta.Controls.Add(Me.bscCuentaBancariaTransfBanc)
        Me.grbCuenta.Controls.Add(Me.lblCuentaBancaria)
        Me.grbCuenta.Controls.Add(Me.cmbCobradores)
        Me.grbCuenta.Location = New System.Drawing.Point(7, 162)
        Me.grbCuenta.Name = "grbCuenta"
        Me.grbCuenta.Size = New System.Drawing.Size(309, 160)
        Me.grbCuenta.TabIndex = 2
        Me.grbCuenta.TabStop = False
        Me.grbCuenta.Text = "Detalle de Cuenta"
        '
        'bscCodigoCuentaBancariaTransfBanc
        '
        Me.bscCodigoCuentaBancariaTransfBanc.AyudaAncho = 608
        Me.bscCodigoCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ColumnasAlineacion = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ColumnasAncho = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ColumnasFormato = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCodigoCuentaBancariaTransfBanc.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCodigoCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsPK = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCodigoCuentaBancariaTransfBanc.Key = ""
        Me.bscCodigoCuentaBancariaTransfBanc.LabelAsoc = Me.lblCuentaBancaria
        Me.bscCodigoCuentaBancariaTransfBanc.Location = New System.Drawing.Point(247, 11)
        Me.bscCodigoCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCodigoCuentaBancariaTransfBanc.Name = "bscCodigoCuentaBancariaTransfBanc"
        Me.bscCodigoCuentaBancariaTransfBanc.Permitido = True
        Me.bscCodigoCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCodigoCuentaBancariaTransfBanc.Size = New System.Drawing.Size(49, 20)
        Me.bscCodigoCuentaBancariaTransfBanc.TabIndex = 8
        Me.bscCodigoCuentaBancariaTransfBanc.Titulo = "Clientes"
        Me.bscCodigoCuentaBancariaTransfBanc.Visible = False
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.AutoSize = True
        Me.lblCuentaBancaria.LabelAsoc = Nothing
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(10, 36)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(86, 13)
        Me.lblCuentaBancaria.TabIndex = 0
        Me.lblCuentaBancaria.Text = "Cuenta Bancaria"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = ""
        Me.cmbCajas.BindearPropiedadEntidad = ""
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCaja
        Me.cmbCajas.Location = New System.Drawing.Point(111, 92)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(185, 21)
        Me.cmbCajas.TabIndex = 3
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(10, 95)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 2
        Me.lblCaja.Text = "Caja"
        '
        'cmbTipoRecibo
        '
        Me.cmbTipoRecibo.BindearPropiedadControl = ""
        Me.cmbTipoRecibo.BindearPropiedadEntidad = ""
        Me.cmbTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRecibo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoRecibo.FormattingEnabled = True
        Me.cmbTipoRecibo.IsPK = False
        Me.cmbTipoRecibo.IsRequired = False
        Me.cmbTipoRecibo.Key = Nothing
        Me.cmbTipoRecibo.LabelAsoc = Me.lblTipoRecibo
        Me.cmbTipoRecibo.Location = New System.Drawing.Point(111, 61)
        Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
        Me.cmbTipoRecibo.Size = New System.Drawing.Size(185, 21)
        Me.cmbTipoRecibo.TabIndex = 5
        '
        'lblTipoRecibo
        '
        Me.lblTipoRecibo.AutoSize = True
        Me.lblTipoRecibo.LabelAsoc = Nothing
        Me.lblTipoRecibo.Location = New System.Drawing.Point(10, 65)
        Me.lblTipoRecibo.Name = "lblTipoRecibo"
        Me.lblTipoRecibo.Size = New System.Drawing.Size(80, 13)
        Me.lblTipoRecibo.TabIndex = 4
        Me.lblTipoRecibo.Text = "Tipo de Recibo"
        '
        'lblCobradores
        '
        Me.lblCobradores.AutoSize = True
        Me.lblCobradores.LabelAsoc = Nothing
        Me.lblCobradores.Location = New System.Drawing.Point(10, 126)
        Me.lblCobradores.Name = "lblCobradores"
        Me.lblCobradores.Size = New System.Drawing.Size(50, 13)
        Me.lblCobradores.TabIndex = 6
        Me.lblCobradores.Text = "Cobrador"
        '
        'bscCuentaBancariaTransfBanc
        '
        Me.bscCuentaBancariaTransfBanc.AyudaAncho = 608
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaTransfBanc.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaTransfBanc.ColumnasAncho = Nothing
        Me.bscCuentaBancariaTransfBanc.ColumnasFormato = Nothing
        Me.bscCuentaBancariaTransfBanc.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaTransfBanc.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCuentaBancariaTransfBanc.IsPK = False
        Me.bscCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCuentaBancariaTransfBanc.Key = ""
        Me.bscCuentaBancariaTransfBanc.LabelAsoc = Me.lblCuentaBancaria
        Me.bscCuentaBancariaTransfBanc.Location = New System.Drawing.Point(111, 32)
        Me.bscCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCuentaBancariaTransfBanc.Name = "bscCuentaBancariaTransfBanc"
        Me.bscCuentaBancariaTransfBanc.Permitido = True
        Me.bscCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCuentaBancariaTransfBanc.Size = New System.Drawing.Size(185, 20)
        Me.bscCuentaBancariaTransfBanc.TabIndex = 1
        Me.bscCuentaBancariaTransfBanc.Titulo = "Clientes"
        '
        'cmbCobradores
        '
        Me.cmbCobradores.BindearPropiedadControl = ""
        Me.cmbCobradores.BindearPropiedadEntidad = ""
        Me.cmbCobradores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCobradores.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCobradores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCobradores.FormattingEnabled = True
        Me.cmbCobradores.IsPK = False
        Me.cmbCobradores.IsRequired = False
        Me.cmbCobradores.Key = Nothing
        Me.cmbCobradores.LabelAsoc = Me.lblCobradores
        Me.cmbCobradores.Location = New System.Drawing.Point(111, 123)
        Me.cmbCobradores.Name = "cmbCobradores"
        Me.cmbCobradores.Size = New System.Drawing.Size(185, 21)
        Me.cmbCobradores.TabIndex = 7
        '
        'grbSantander
        '
        Me.grbSantander.Controls.Add(Me.lblDebitoAutomaticoSantanderCodigoServicio)
        Me.grbSantander.Controls.Add(Me.txtDebitoAutomaticoSantanderCodigoServicio)
        Me.grbSantander.Location = New System.Drawing.Point(7, 96)
        Me.grbSantander.Name = "grbSantander"
        Me.grbSantander.Size = New System.Drawing.Size(309, 60)
        Me.grbSantander.TabIndex = 1
        Me.grbSantander.TabStop = False
        Me.grbSantander.Text = "Banco Santander Rio exportación Debito Automatico"
        '
        'lblDebitoAutomaticoSantanderCodigoServicio
        '
        Me.lblDebitoAutomaticoSantanderCodigoServicio.AutoSize = True
        Me.lblDebitoAutomaticoSantanderCodigoServicio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDebitoAutomaticoSantanderCodigoServicio.LabelAsoc = Nothing
        Me.lblDebitoAutomaticoSantanderCodigoServicio.Location = New System.Drawing.Point(10, 26)
        Me.lblDebitoAutomaticoSantanderCodigoServicio.Name = "lblDebitoAutomaticoSantanderCodigoServicio"
        Me.lblDebitoAutomaticoSantanderCodigoServicio.Size = New System.Drawing.Size(96, 13)
        Me.lblDebitoAutomaticoSantanderCodigoServicio.TabIndex = 0
        Me.lblDebitoAutomaticoSantanderCodigoServicio.Text = "Código de Servicio"
        '
        'txtDebitoAutomaticoSantanderCodigoServicio
        '
        Me.txtDebitoAutomaticoSantanderCodigoServicio.BindearPropiedadControl = Nothing
        Me.txtDebitoAutomaticoSantanderCodigoServicio.BindearPropiedadEntidad = Nothing
        Me.txtDebitoAutomaticoSantanderCodigoServicio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDebitoAutomaticoSantanderCodigoServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDebitoAutomaticoSantanderCodigoServicio.Formato = ""
        Me.txtDebitoAutomaticoSantanderCodigoServicio.IsDecimal = False
        Me.txtDebitoAutomaticoSantanderCodigoServicio.IsNumber = False
        Me.txtDebitoAutomaticoSantanderCodigoServicio.IsPK = False
        Me.txtDebitoAutomaticoSantanderCodigoServicio.IsRequired = False
        Me.txtDebitoAutomaticoSantanderCodigoServicio.Key = ""
        Me.txtDebitoAutomaticoSantanderCodigoServicio.LabelAsoc = Me.lblDebitoAutomaticoSantanderCodigoServicio
        Me.txtDebitoAutomaticoSantanderCodigoServicio.Location = New System.Drawing.Point(112, 24)
        Me.txtDebitoAutomaticoSantanderCodigoServicio.MaxLength = 20
        Me.txtDebitoAutomaticoSantanderCodigoServicio.Name = "txtDebitoAutomaticoSantanderCodigoServicio"
        Me.txtDebitoAutomaticoSantanderCodigoServicio.Size = New System.Drawing.Size(185, 20)
        Me.txtDebitoAutomaticoSantanderCodigoServicio.TabIndex = 1
        '
        'grbBancoMacro
        '
        Me.grbBancoMacro.Controls.Add(Me.lblCaracterRellenado)
        Me.grbBancoMacro.Controls.Add(Me.txtCaracterRellenado)
        Me.grbBancoMacro.Controls.Add(Me.cmbCtaCteCliMacroAlineacion)
        Me.grbBancoMacro.Controls.Add(Me.lblAlineacionIDAdherente)
        Me.grbBancoMacro.Location = New System.Drawing.Point(7, 7)
        Me.grbBancoMacro.Name = "grbBancoMacro"
        Me.grbBancoMacro.Size = New System.Drawing.Size(309, 83)
        Me.grbBancoMacro.TabIndex = 0
        Me.grbBancoMacro.TabStop = False
        Me.grbBancoMacro.Text = "Banco Macro exportación Debito Automatico"
        '
        'lblCaracterRellenado
        '
        Me.lblCaracterRellenado.AutoSize = True
        Me.lblCaracterRellenado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCaracterRellenado.LabelAsoc = Nothing
        Me.lblCaracterRellenado.Location = New System.Drawing.Point(12, 52)
        Me.lblCaracterRellenado.Name = "lblCaracterRellenado"
        Me.lblCaracterRellenado.Size = New System.Drawing.Size(93, 13)
        Me.lblCaracterRellenado.TabIndex = 2
        Me.lblCaracterRellenado.Text = "Caracter rellenado"
        '
        'txtCaracterRellenado
        '
        Me.txtCaracterRellenado.BindearPropiedadControl = Nothing
        Me.txtCaracterRellenado.BindearPropiedadEntidad = Nothing
        Me.txtCaracterRellenado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCaracterRellenado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCaracterRellenado.Formato = ""
        Me.txtCaracterRellenado.IsDecimal = False
        Me.txtCaracterRellenado.IsNumber = False
        Me.txtCaracterRellenado.IsPK = False
        Me.txtCaracterRellenado.IsRequired = False
        Me.txtCaracterRellenado.Key = ""
        Me.txtCaracterRellenado.LabelAsoc = Me.lblCaracterRellenado
        Me.txtCaracterRellenado.Location = New System.Drawing.Point(136, 50)
        Me.txtCaracterRellenado.MaxLength = 20
        Me.txtCaracterRellenado.Name = "txtCaracterRellenado"
        Me.txtCaracterRellenado.Size = New System.Drawing.Size(39, 20)
        Me.txtCaracterRellenado.TabIndex = 3
        Me.txtCaracterRellenado.Tag = "MACROADHERENTERELLENADO"
        Me.txtCaracterRellenado.Text = "0"
        '
        'cmbCtaCteCliMacroAlineacion
        '
        Me.cmbCtaCteCliMacroAlineacion.BindearPropiedadControl = Nothing
        Me.cmbCtaCteCliMacroAlineacion.BindearPropiedadEntidad = Nothing
        Me.cmbCtaCteCliMacroAlineacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCtaCteCliMacroAlineacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCtaCteCliMacroAlineacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCtaCteCliMacroAlineacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCtaCteCliMacroAlineacion.FormattingEnabled = True
        Me.cmbCtaCteCliMacroAlineacion.IsPK = False
        Me.cmbCtaCteCliMacroAlineacion.IsRequired = False
        Me.cmbCtaCteCliMacroAlineacion.Items.AddRange(New Object() {"Derecha a Izquierda", "Izquierda a Derecha"})
        Me.cmbCtaCteCliMacroAlineacion.Key = Nothing
        Me.cmbCtaCteCliMacroAlineacion.LabelAsoc = Nothing
        Me.cmbCtaCteCliMacroAlineacion.Location = New System.Drawing.Point(136, 23)
        Me.cmbCtaCteCliMacroAlineacion.Name = "cmbCtaCteCliMacroAlineacion"
        Me.cmbCtaCteCliMacroAlineacion.Size = New System.Drawing.Size(160, 21)
        Me.cmbCtaCteCliMacroAlineacion.TabIndex = 1
        Me.cmbCtaCteCliMacroAlineacion.Tag = "MACROADHERENTEALINEACION"
        '
        'lblAlineacionIDAdherente
        '
        Me.lblAlineacionIDAdherente.AutoSize = True
        Me.lblAlineacionIDAdherente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAlineacionIDAdherente.LabelAsoc = Nothing
        Me.lblAlineacionIDAdherente.Location = New System.Drawing.Point(12, 27)
        Me.lblAlineacionIDAdherente.Name = "lblAlineacionIDAdherente"
        Me.lblAlineacionIDAdherente.Size = New System.Drawing.Size(121, 13)
        Me.lblAlineacionIDAdherente.TabIndex = 0
        Me.lblAlineacionIDAdherente.Text = "Alineación ID adherente"
        '
        'grbRoela
        '
        Me.grbRoela.Controls.Add(Me.cmbInteresesVencRoela)
        Me.grbRoela.Controls.Add(Me.lblRoelaInteresVencimientos)
        Me.grbRoela.Controls.Add(Me.txtRoelaIdentificadorCuenta)
        Me.grbRoela.Controls.Add(Me.lblIdentificadorCuenta)
        Me.grbRoela.Controls.Add(Me.txtRoelaIdentificadorConcepto)
        Me.grbRoela.Controls.Add(Me.lblIdentificadorConcepto)
        Me.grbRoela.Location = New System.Drawing.Point(335, 7)
        Me.grbRoela.Name = "grbRoela"
        Me.grbRoela.Size = New System.Drawing.Size(460, 91)
        Me.grbRoela.TabIndex = 59
        Me.grbRoela.TabStop = False
        Me.grbRoela.Text = "Roela"
        '
        'cmbInteresesVencRoela
        '
        Me.cmbInteresesVencRoela.BindearPropiedadControl = Nothing
        Me.cmbInteresesVencRoela.BindearPropiedadEntidad = Nothing
        Me.cmbInteresesVencRoela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInteresesVencRoela.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInteresesVencRoela.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbInteresesVencRoela.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbInteresesVencRoela.FormattingEnabled = True
        Me.cmbInteresesVencRoela.IsPK = False
        Me.cmbInteresesVencRoela.IsRequired = False
        Me.cmbInteresesVencRoela.Key = Nothing
        Me.cmbInteresesVencRoela.LabelAsoc = Me.lblRoelaInteresVencimientos
        Me.cmbInteresesVencRoela.Location = New System.Drawing.Point(211, 61)
        Me.cmbInteresesVencRoela.Name = "cmbInteresesVencRoela"
        Me.cmbInteresesVencRoela.Size = New System.Drawing.Size(164, 21)
        Me.cmbInteresesVencRoela.TabIndex = 5
        Me.cmbInteresesVencRoela.Tag = "TURISMOROELAINTERESVTO"
        '
        'lblRoelaInteresVencimientos
        '
        Me.lblRoelaInteresVencimientos.AutoSize = True
        Me.lblRoelaInteresVencimientos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRoelaInteresVencimientos.LabelAsoc = Nothing
        Me.lblRoelaInteresVencimientos.Location = New System.Drawing.Point(24, 64)
        Me.lblRoelaInteresVencimientos.Name = "lblRoelaInteresVencimientos"
        Me.lblRoelaInteresVencimientos.Size = New System.Drawing.Size(181, 13)
        Me.lblRoelaInteresVencimientos.TabIndex = 4
        Me.lblRoelaInteresVencimientos.Text = "Interes para calculo de Vencimientos"
        '
        'txtRoelaIdentificadorCuenta
        '
        Me.txtRoelaIdentificadorCuenta.BindearPropiedadControl = Nothing
        Me.txtRoelaIdentificadorCuenta.BindearPropiedadEntidad = Nothing
        Me.txtRoelaIdentificadorCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRoelaIdentificadorCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRoelaIdentificadorCuenta.Formato = ""
        Me.txtRoelaIdentificadorCuenta.IsDecimal = False
        Me.txtRoelaIdentificadorCuenta.IsNumber = False
        Me.txtRoelaIdentificadorCuenta.IsPK = False
        Me.txtRoelaIdentificadorCuenta.IsRequired = False
        Me.txtRoelaIdentificadorCuenta.Key = ""
        Me.txtRoelaIdentificadorCuenta.LabelAsoc = Me.lblIdentificadorCuenta
        Me.txtRoelaIdentificadorCuenta.Location = New System.Drawing.Point(159, 38)
        Me.txtRoelaIdentificadorCuenta.MaxLength = 110
        Me.txtRoelaIdentificadorCuenta.Name = "txtRoelaIdentificadorCuenta"
        Me.txtRoelaIdentificadorCuenta.Size = New System.Drawing.Size(144, 20)
        Me.txtRoelaIdentificadorCuenta.TabIndex = 3
        Me.txtRoelaIdentificadorCuenta.Tag = "TURISMOROELAIDCUENTA"
        '
        'lblIdentificadorCuenta
        '
        Me.lblIdentificadorCuenta.AutoSize = True
        Me.lblIdentificadorCuenta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentificadorCuenta.LabelAsoc = Nothing
        Me.lblIdentificadorCuenta.Location = New System.Drawing.Point(24, 41)
        Me.lblIdentificadorCuenta.Name = "lblIdentificadorCuenta"
        Me.lblIdentificadorCuenta.Size = New System.Drawing.Size(117, 13)
        Me.lblIdentificadorCuenta.TabIndex = 2
        Me.lblIdentificadorCuenta.Text = "Identificador de Cuenta"
        '
        'txtRoelaIdentificadorConcepto
        '
        Me.txtRoelaIdentificadorConcepto.BindearPropiedadControl = Nothing
        Me.txtRoelaIdentificadorConcepto.BindearPropiedadEntidad = Nothing
        Me.txtRoelaIdentificadorConcepto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRoelaIdentificadorConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRoelaIdentificadorConcepto.Formato = ""
        Me.txtRoelaIdentificadorConcepto.IsDecimal = False
        Me.txtRoelaIdentificadorConcepto.IsNumber = False
        Me.txtRoelaIdentificadorConcepto.IsPK = False
        Me.txtRoelaIdentificadorConcepto.IsRequired = False
        Me.txtRoelaIdentificadorConcepto.Key = ""
        Me.txtRoelaIdentificadorConcepto.LabelAsoc = Me.lblIdentificadorConcepto
        Me.txtRoelaIdentificadorConcepto.Location = New System.Drawing.Point(159, 14)
        Me.txtRoelaIdentificadorConcepto.MaxLength = 110
        Me.txtRoelaIdentificadorConcepto.Name = "txtRoelaIdentificadorConcepto"
        Me.txtRoelaIdentificadorConcepto.Size = New System.Drawing.Size(38, 20)
        Me.txtRoelaIdentificadorConcepto.TabIndex = 1
        Me.txtRoelaIdentificadorConcepto.Tag = "TURISMOROELAIDCONCEPTO"
        '
        'lblIdentificadorConcepto
        '
        Me.lblIdentificadorConcepto.AutoSize = True
        Me.lblIdentificadorConcepto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentificadorConcepto.LabelAsoc = Nothing
        Me.lblIdentificadorConcepto.Location = New System.Drawing.Point(24, 17)
        Me.lblIdentificadorConcepto.Name = "lblIdentificadorConcepto"
        Me.lblIdentificadorConcepto.Size = New System.Drawing.Size(129, 13)
        Me.lblIdentificadorConcepto.TabIndex = 0
        Me.lblIdentificadorConcepto.Text = "Identificador de Concepto"
        '
        'grbSirPlus
        '
        Me.grbSirPlus.Controls.Add(Me.cmbTiposComprobantesSIRPLUS)
        Me.grbSirPlus.Controls.Add(Me.lblTiposComprobantesSIRPLUS)
        Me.grbSirPlus.Controls.Add(Me.txtCBU)
        Me.grbSirPlus.Controls.Add(Me.txtTitularCBU)
        Me.grbSirPlus.Controls.Add(Me.lblTitularCBU)
        Me.grbSirPlus.Controls.Add(Me.lblCBU)
        Me.grbSirPlus.Controls.Add(Me.txtNroEmpresa)
        Me.grbSirPlus.Controls.Add(Me.lblNroCta)
        Me.grbSirPlus.Controls.Add(Me.txtPassword)
        Me.grbSirPlus.Controls.Add(Me.lblPassword)
        Me.grbSirPlus.Controls.Add(Me.txtIdentCuenta)
        Me.grbSirPlus.Controls.Add(Me.lblIdentCta)
        Me.grbSirPlus.Controls.Add(Me.txtRazonSocial)
        Me.grbSirPlus.Controls.Add(Me.lblRazonSocial)
        Me.grbSirPlus.Location = New System.Drawing.Point(335, 104)
        Me.grbSirPlus.Name = "grbSirPlus"
        Me.grbSirPlus.Size = New System.Drawing.Size(460, 218)
        Me.grbSirPlus.TabIndex = 60
        Me.grbSirPlus.TabStop = False
        Me.grbSirPlus.Text = "SIRPLUS"
        '
        'cmbTiposComprobantesSIRPLUS
        '
        Me.cmbTiposComprobantesSIRPLUS.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantesSIRPLUS.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantesSIRPLUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesSIRPLUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantesSIRPLUS.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesSIRPLUS.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesSIRPLUS.FormattingEnabled = True
        Me.cmbTiposComprobantesSIRPLUS.IsPK = False
        Me.cmbTiposComprobantesSIRPLUS.IsRequired = False
        Me.cmbTiposComprobantesSIRPLUS.ItemHeight = 13
        Me.cmbTiposComprobantesSIRPLUS.Key = Nothing
        Me.cmbTiposComprobantesSIRPLUS.LabelAsoc = Nothing
        Me.cmbTiposComprobantesSIRPLUS.Location = New System.Drawing.Point(148, 181)
        Me.cmbTiposComprobantesSIRPLUS.Name = "cmbTiposComprobantesSIRPLUS"
        Me.cmbTiposComprobantesSIRPLUS.Size = New System.Drawing.Size(143, 21)
        Me.cmbTiposComprobantesSIRPLUS.TabIndex = 13
        '
        'lblTiposComprobantesSIRPLUS
        '
        Me.lblTiposComprobantesSIRPLUS.AutoSize = True
        Me.lblTiposComprobantesSIRPLUS.LabelAsoc = Nothing
        Me.lblTiposComprobantesSIRPLUS.Location = New System.Drawing.Point(8, 185)
        Me.lblTiposComprobantesSIRPLUS.Name = "lblTiposComprobantesSIRPLUS"
        Me.lblTiposComprobantesSIRPLUS.Size = New System.Drawing.Size(70, 13)
        Me.lblTiposComprobantesSIRPLUS.TabIndex = 12
        Me.lblTiposComprobantesSIRPLUS.Text = "Comprobante"
        '
        'txtCBU
        '
        Me.txtCBU.AccessibleDescription = "txtCBU"
        Me.txtCBU.BindearPropiedadControl = Nothing
        Me.txtCBU.BindearPropiedadEntidad = Nothing
        Me.txtCBU.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCBU.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCBU.Formato = ""
        Me.txtCBU.IsDecimal = False
        Me.txtCBU.IsNumber = False
        Me.txtCBU.IsPK = False
        Me.txtCBU.IsRequired = False
        Me.txtCBU.Key = ""
        Me.txtCBU.LabelAsoc = Me.lblTitularCBU
        Me.txtCBU.Location = New System.Drawing.Point(148, 129)
        Me.txtCBU.MaxLength = 22
        Me.txtCBU.Name = "txtCBU"
        Me.txtCBU.Size = New System.Drawing.Size(298, 20)
        Me.txtCBU.TabIndex = 9
        Me.txtCBU.Tag = "TURISMOSIRPLUSCBUEMPRESA"
        '
        'lblTitularCBU
        '
        Me.lblTitularCBU.AutoSize = True
        Me.lblTitularCBU.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTitularCBU.LabelAsoc = Nothing
        Me.lblTitularCBU.Location = New System.Drawing.Point(7, 158)
        Me.lblTitularCBU.Name = "lblTitularCBU"
        Me.lblTitularCBU.Size = New System.Drawing.Size(105, 13)
        Me.lblTitularCBU.TabIndex = 10
        Me.lblTitularCBU.Text = "Titular CBU Empresa"
        '
        'txtTitularCBU
        '
        Me.txtTitularCBU.AccessibleDescription = "txtCBU"
        Me.txtTitularCBU.BindearPropiedadControl = Nothing
        Me.txtTitularCBU.BindearPropiedadEntidad = Nothing
        Me.txtTitularCBU.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTitularCBU.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTitularCBU.Formato = ""
        Me.txtTitularCBU.IsDecimal = False
        Me.txtTitularCBU.IsNumber = False
        Me.txtTitularCBU.IsPK = False
        Me.txtTitularCBU.IsRequired = False
        Me.txtTitularCBU.Key = ""
        Me.txtTitularCBU.LabelAsoc = Me.lblTitularCBU
        Me.txtTitularCBU.Location = New System.Drawing.Point(148, 155)
        Me.txtTitularCBU.MaxLength = 100
        Me.txtTitularCBU.Name = "txtTitularCBU"
        Me.txtTitularCBU.Size = New System.Drawing.Size(298, 20)
        Me.txtTitularCBU.TabIndex = 11
        Me.txtTitularCBU.Tag = "TURISMOSIRPLUSCBUEMPRESA"
        '
        'lblCBU
        '
        Me.lblCBU.AutoSize = True
        Me.lblCBU.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCBU.LabelAsoc = Nothing
        Me.lblCBU.Location = New System.Drawing.Point(7, 132)
        Me.lblCBU.Name = "lblCBU"
        Me.lblCBU.Size = New System.Drawing.Size(73, 13)
        Me.lblCBU.TabIndex = 8
        Me.lblCBU.Text = "CBU Empresa"
        '
        'txtNroEmpresa
        '
        Me.txtNroEmpresa.BindearPropiedadControl = Nothing
        Me.txtNroEmpresa.BindearPropiedadEntidad = Nothing
        Me.txtNroEmpresa.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroEmpresa.Formato = ""
        Me.txtNroEmpresa.IsDecimal = False
        Me.txtNroEmpresa.IsNumber = False
        Me.txtNroEmpresa.IsPK = False
        Me.txtNroEmpresa.IsRequired = False
        Me.txtNroEmpresa.Key = ""
        Me.txtNroEmpresa.LabelAsoc = Me.lblNroCta
        Me.txtNroEmpresa.Location = New System.Drawing.Point(148, 101)
        Me.txtNroEmpresa.MaxLength = 100
        Me.txtNroEmpresa.Name = "txtNroEmpresa"
        Me.txtNroEmpresa.Size = New System.Drawing.Size(298, 20)
        Me.txtNroEmpresa.TabIndex = 7
        Me.txtNroEmpresa.Tag = "TURISMOSIRPLUSCUENTAEMPRESA"
        '
        'lblNroCta
        '
        Me.lblNroCta.AutoSize = True
        Me.lblNroCta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNroCta.LabelAsoc = Nothing
        Me.lblNroCta.Location = New System.Drawing.Point(8, 104)
        Me.lblNroCta.Name = "lblNroCta"
        Me.lblNroCta.Size = New System.Drawing.Size(139, 13)
        Me.lblNroCta.TabIndex = 6
        Me.lblNroCta.Text = "Número de Cuenta empresa"
        '
        'txtPassword
        '
        Me.txtPassword.BindearPropiedadControl = Nothing
        Me.txtPassword.BindearPropiedadEntidad = Nothing
        Me.txtPassword.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPassword.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPassword.Formato = ""
        Me.txtPassword.IsDecimal = False
        Me.txtPassword.IsNumber = False
        Me.txtPassword.IsPK = False
        Me.txtPassword.IsRequired = False
        Me.txtPassword.Key = ""
        Me.txtPassword.LabelAsoc = Me.lblPassword
        Me.txtPassword.Location = New System.Drawing.Point(148, 73)
        Me.txtPassword.MaxLength = 110
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(298, 20)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.Tag = "TURISMOSIRPLUSPASS"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPassword.LabelAsoc = Nothing
        Me.lblPassword.Location = New System.Drawing.Point(8, 76)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password"
        '
        'txtIdentCuenta
        '
        Me.txtIdentCuenta.BindearPropiedadControl = Nothing
        Me.txtIdentCuenta.BindearPropiedadEntidad = Nothing
        Me.txtIdentCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdentCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdentCuenta.Formato = ""
        Me.txtIdentCuenta.IsDecimal = False
        Me.txtIdentCuenta.IsNumber = False
        Me.txtIdentCuenta.IsPK = False
        Me.txtIdentCuenta.IsRequired = False
        Me.txtIdentCuenta.Key = ""
        Me.txtIdentCuenta.LabelAsoc = Me.lblIdentCta
        Me.txtIdentCuenta.Location = New System.Drawing.Point(148, 46)
        Me.txtIdentCuenta.MaxLength = 4
        Me.txtIdentCuenta.Name = "txtIdentCuenta"
        Me.txtIdentCuenta.Size = New System.Drawing.Size(65, 20)
        Me.txtIdentCuenta.TabIndex = 3
        Me.txtIdentCuenta.Tag = "TURISMOSIRPLUSIDCUENTA"
        '
        'lblIdentCta
        '
        Me.lblIdentCta.AutoSize = True
        Me.lblIdentCta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentCta.LabelAsoc = Nothing
        Me.lblIdentCta.Location = New System.Drawing.Point(8, 49)
        Me.lblIdentCta.Name = "lblIdentCta"
        Me.lblIdentCta.Size = New System.Drawing.Size(98, 13)
        Me.lblIdentCta.TabIndex = 2
        Me.lblIdentCta.Text = "Número de Usuario"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BindearPropiedadControl = Nothing
        Me.txtRazonSocial.BindearPropiedadEntidad = Nothing
        Me.txtRazonSocial.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRazonSocial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRazonSocial.Formato = ""
        Me.txtRazonSocial.IsDecimal = False
        Me.txtRazonSocial.IsNumber = False
        Me.txtRazonSocial.IsPK = False
        Me.txtRazonSocial.IsRequired = False
        Me.txtRazonSocial.Key = ""
        Me.txtRazonSocial.LabelAsoc = Me.lblRazonSocial
        Me.txtRazonSocial.Location = New System.Drawing.Point(148, 21)
        Me.txtRazonSocial.MaxLength = 100
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(298, 20)
        Me.txtRazonSocial.TabIndex = 1
        Me.txtRazonSocial.Tag = "TURISMOSIRPLUSNOMBREEMPRESA"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRazonSocial.LabelAsoc = Nothing
        Me.lblRazonSocial.Location = New System.Drawing.Point(8, 24)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 0
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'ucConfCtaCteClienteDebitoAutomatico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grbSirPlus)
        Me.Controls.Add(Me.grbRoela)
        Me.Controls.Add(Me.grbPagoMisCuentas)
        Me.Controls.Add(Me.grbCuenta)
        Me.Controls.Add(Me.grbSantander)
        Me.Controls.Add(Me.grbBancoMacro)
        Me.Name = "ucConfCtaCteClienteDebitoAutomatico"
        Me.Controls.SetChildIndex(Me.grbBancoMacro, 0)
        Me.Controls.SetChildIndex(Me.grbSantander, 0)
        Me.Controls.SetChildIndex(Me.grbCuenta, 0)
        Me.Controls.SetChildIndex(Me.grbPagoMisCuentas, 0)
        Me.Controls.SetChildIndex(Me.grbRoela, 0)
        Me.Controls.SetChildIndex(Me.grbSirPlus, 0)
        Me.grbPagoMisCuentas.ResumeLayout(False)
        Me.grbPagoMisCuentas.PerformLayout()
        Me.grbCuenta.ResumeLayout(False)
        Me.grbCuenta.PerformLayout()
        Me.grbSantander.ResumeLayout(False)
        Me.grbSantander.PerformLayout()
        Me.grbBancoMacro.ResumeLayout(False)
        Me.grbBancoMacro.PerformLayout()
        Me.grbRoela.ResumeLayout(False)
        Me.grbRoela.PerformLayout()
        Me.grbSirPlus.ResumeLayout(False)
        Me.grbSirPlus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grbPagoMisCuentas As GroupBox
   Friend WithEvents cmbFormatoPMC As Controles.ComboBox
   Friend WithEvents lblFormato As Controles.Label
   Friend WithEvents txtNumeroEmpresaBanelco As Controles.TextBox
   Friend WithEvents lblNumeroEmpresaBanelco As Controles.Label
   Friend WithEvents grbCuenta As GroupBox
   Friend WithEvents bscCodigoCuentaBancariaTransfBanc As Controles.Buscador
   Friend WithEvents lblCuentaBancaria As Controles.Label
   Friend WithEvents cmbCajas As Controles.ComboBox
   Friend WithEvents lblCaja As Controles.Label
   Friend WithEvents cmbTipoRecibo As Controles.ComboBox
   Friend WithEvents lblTipoRecibo As Controles.Label
   Friend WithEvents lblCobradores As Controles.Label
   Friend WithEvents bscCuentaBancariaTransfBanc As Controles.Buscador
   Friend WithEvents cmbCobradores As Controles.ComboBox
   Friend WithEvents grbSantander As GroupBox
   Friend WithEvents lblDebitoAutomaticoSantanderCodigoServicio As Controles.Label
   Friend WithEvents txtDebitoAutomaticoSantanderCodigoServicio As Controles.TextBox
   Friend WithEvents grbBancoMacro As GroupBox
   Friend WithEvents lblCaracterRellenado As Controles.Label
   Friend WithEvents txtCaracterRellenado As Controles.TextBox
   Friend WithEvents cmbCtaCteCliMacroAlineacion As Controles.ComboBox
   Friend WithEvents lblAlineacionIDAdherente As Controles.Label
    Friend WithEvents grbRoela As GroupBox
    Friend WithEvents cmbInteresesVencRoela As Controles.ComboBox
    Friend WithEvents lblRoelaInteresVencimientos As Controles.Label
    Friend WithEvents txtRoelaIdentificadorCuenta As Controles.TextBox
    Friend WithEvents lblIdentificadorCuenta As Controles.Label
    Friend WithEvents txtRoelaIdentificadorConcepto As Controles.TextBox
    Friend WithEvents lblIdentificadorConcepto As Controles.Label
    Friend WithEvents grbSirPlus As GroupBox
    Friend WithEvents cmbTiposComprobantesSIRPLUS As ComboBoxTiposComprobantes
    Friend WithEvents lblTiposComprobantesSIRPLUS As Controles.Label
    Friend WithEvents txtCBU As Controles.TextBox
    Friend WithEvents lblTitularCBU As Controles.Label
    Friend WithEvents txtTitularCBU As Controles.TextBox
    Friend WithEvents lblCBU As Controles.Label
    Friend WithEvents txtNroEmpresa As Controles.TextBox
    Friend WithEvents lblNroCta As Controles.Label
    Friend WithEvents txtPassword As Controles.TextBox
    Friend WithEvents lblPassword As Controles.Label
    Friend WithEvents txtIdentCuenta As Controles.TextBox
    Friend WithEvents lblIdentCta As Controles.Label
    Friend WithEvents txtRazonSocial As Controles.TextBox
    Friend WithEvents lblRazonSocial As Controles.Label
End Class
