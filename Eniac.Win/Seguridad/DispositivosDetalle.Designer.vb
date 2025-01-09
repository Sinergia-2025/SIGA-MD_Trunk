<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DispositivosDetalle
   Inherits Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
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
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombreDispositivo = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtIdDispositivo = New Eniac.Controles.TextBox()
      Me.dtpFechaUltLogin = New Eniac.Controles.DateTimePicker()
      Me.lblFechaUltimoLogin = New Eniac.Controles.Label()
      Me.lblUsuarioUltimoLogin = New Eniac.Controles.Label()
      Me.txtUsuarioUltLogin = New Eniac.Controles.TextBox()
      Me.lblIdTipoDispositivo = New Eniac.Controles.Label()
      Me.txtIdTipoDispositivo = New Eniac.Controles.TextBox()
      Me.lblSistemaOperativo = New Eniac.Controles.Label()
      Me.txtSistemaOperativo = New Eniac.Controles.TextBox()
      Me.gpBoxUltimoLogin = New System.Windows.Forms.GroupBox()
      Me.lblArquitecturaSO = New Eniac.Controles.Label()
      Me.txtArquitecturaSO = New Eniac.Controles.TextBox()
      Me.lblNumSerieDiscRig = New Eniac.Controles.Label()
      Me.txtBoxNumSerieHDD = New Eniac.Controles.TextBox()
      Me.lblDireccionMAC = New Eniac.Controles.Label()
      Me.txtBoxDirecMAC = New Eniac.Controles.TextBox()
        Me.chbActivo = New Eniac.Controles.CheckBox()
        Me.lblActivo = New Eniac.Controles.Label()
        Me.lblNumSerieDiscoPrimario = New Eniac.Controles.Label()
        Me.txtNumSerieDiscoPrimario = New Eniac.Controles.TextBox()
        Me.lblResolucionPantalla = New Eniac.Controles.Label()
        Me.txtResolucionPantalla = New Eniac.Controles.TextBox()
        Me.lblVersionFramework = New Eniac.Controles.Label()
        Me.txtVersionFramework = New Eniac.Controles.TextBox()
        Me.lblNumeroSerieMotherboard = New Eniac.Controles.Label()
        Me.txtNumeroSerieMotherboard = New Eniac.Controles.TextBox()
        Me.lblFechaUltimaInactivacion = New Eniac.Controles.Label()
        Me.txtFechaUltimaInactivacion = New Eniac.Controles.TextBox()
        Me.dtpFechaUltimaInactivacion = New Eniac.Controles.DateTimePicker()
        Me.gpBoxUltimoLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(410, 311)
        Me.btnAceptar.TabIndex = 27
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(496, 311)
        Me.btnCancelar.TabIndex = 28
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(309, 311)
        Me.btnCopiar.TabIndex = 30
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(252, 311)
        Me.btnAplicar.TabIndex = 29
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(149, 16)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombreDispositivo
        '
        Me.txtNombreDispositivo.BindearPropiedadControl = "Text"
        Me.txtNombreDispositivo.BindearPropiedadEntidad = "NombreDispositivo"
        Me.txtNombreDispositivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreDispositivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreDispositivo.Formato = ""
        Me.txtNombreDispositivo.IsDecimal = False
        Me.txtNombreDispositivo.IsNumber = False
        Me.txtNombreDispositivo.IsPK = False
        Me.txtNombreDispositivo.IsRequired = True
        Me.txtNombreDispositivo.Key = ""
        Me.txtNombreDispositivo.LabelAsoc = Me.lblNombre
        Me.txtNombreDispositivo.Location = New System.Drawing.Point(151, 33)
        Me.txtNombreDispositivo.MaxLength = 100
        Me.txtNombreDispositivo.Name = "txtNombreDispositivo"
        Me.txtNombreDispositivo.Size = New System.Drawing.Size(150, 20)
        Me.txtNombreDispositivo.TabIndex = 3
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(22, 16)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Código"
        '
        'txtIdDispositivo
        '
        Me.txtIdDispositivo.BindearPropiedadControl = "Text"
        Me.txtIdDispositivo.BindearPropiedadEntidad = "IdDispositivo"
        Me.txtIdDispositivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdDispositivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdDispositivo.Formato = ""
        Me.txtIdDispositivo.IsDecimal = False
        Me.txtIdDispositivo.IsNumber = True
        Me.txtIdDispositivo.IsPK = True
        Me.txtIdDispositivo.IsRequired = True
        Me.txtIdDispositivo.Key = ""
        Me.txtIdDispositivo.LabelAsoc = Me.lblId
        Me.txtIdDispositivo.Location = New System.Drawing.Point(23, 33)
        Me.txtIdDispositivo.MaxLength = 3
        Me.txtIdDispositivo.Name = "txtIdDispositivo"
        Me.txtIdDispositivo.Size = New System.Drawing.Size(120, 20)
        Me.txtIdDispositivo.TabIndex = 1
        '
        'dtpFechaUltLogin
        '
        Me.dtpFechaUltLogin.BindearPropiedadControl = "Value"
        Me.dtpFechaUltLogin.BindearPropiedadEntidad = "FechaUltimoLogin"
        Me.dtpFechaUltLogin.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaUltLogin.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaUltLogin.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaUltLogin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaUltLogin.IsPK = False
        Me.dtpFechaUltLogin.IsRequired = False
        Me.dtpFechaUltLogin.Key = ""
        Me.dtpFechaUltLogin.LabelAsoc = Me.lblFechaUltimoLogin
        Me.dtpFechaUltLogin.Location = New System.Drawing.Point(54, 21)
        Me.dtpFechaUltLogin.Name = "dtpFechaUltLogin"
        Me.dtpFechaUltLogin.Size = New System.Drawing.Size(126, 20)
        Me.dtpFechaUltLogin.TabIndex = 1
        '
        'lblFechaUltimoLogin
        '
        Me.lblFechaUltimoLogin.AutoSize = True
        Me.lblFechaUltimoLogin.LabelAsoc = Nothing
        Me.lblFechaUltimoLogin.Location = New System.Drawing.Point(11, 25)
        Me.lblFechaUltimoLogin.Name = "lblFechaUltimoLogin"
        Me.lblFechaUltimoLogin.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaUltimoLogin.TabIndex = 0
        Me.lblFechaUltimoLogin.Text = "Fecha"
        '
        'lblUsuarioUltimoLogin
        '
        Me.lblUsuarioUltimoLogin.AutoSize = True
        Me.lblUsuarioUltimoLogin.LabelAsoc = Nothing
        Me.lblUsuarioUltimoLogin.Location = New System.Drawing.Point(191, 26)
        Me.lblUsuarioUltimoLogin.Name = "lblUsuarioUltimoLogin"
        Me.lblUsuarioUltimoLogin.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuarioUltimoLogin.TabIndex = 2
        Me.lblUsuarioUltimoLogin.Text = "Usuario"
        '
        'txtUsuarioUltLogin
        '
        Me.txtUsuarioUltLogin.BindearPropiedadControl = "Text"
        Me.txtUsuarioUltLogin.BindearPropiedadEntidad = "UsuarioUltimoLogin"
        Me.txtUsuarioUltLogin.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUsuarioUltLogin.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUsuarioUltLogin.Formato = ""
        Me.txtUsuarioUltLogin.IsDecimal = False
        Me.txtUsuarioUltLogin.IsNumber = False
        Me.txtUsuarioUltLogin.IsPK = False
        Me.txtUsuarioUltLogin.IsRequired = True
        Me.txtUsuarioUltLogin.Key = ""
        Me.txtUsuarioUltLogin.LabelAsoc = Me.lblUsuarioUltimoLogin
        Me.txtUsuarioUltLogin.Location = New System.Drawing.Point(240, 22)
        Me.txtUsuarioUltLogin.MaxLength = 100
        Me.txtUsuarioUltLogin.Name = "txtUsuarioUltLogin"
        Me.txtUsuarioUltLogin.Size = New System.Drawing.Size(107, 20)
        Me.txtUsuarioUltLogin.TabIndex = 3
        '
        'lblIdTipoDispositivo
        '
        Me.lblIdTipoDispositivo.AutoSize = True
        Me.lblIdTipoDispositivo.LabelAsoc = Nothing
        Me.lblIdTipoDispositivo.Location = New System.Drawing.Point(304, 16)
        Me.lblIdTipoDispositivo.Name = "lblIdTipoDispositivo"
        Me.lblIdTipoDispositivo.Size = New System.Drawing.Size(28, 13)
        Me.lblIdTipoDispositivo.TabIndex = 4
        Me.lblIdTipoDispositivo.Text = "Tipo"
        '
        'txtIdTipoDispositivo
        '
        Me.txtIdTipoDispositivo.BindearPropiedadControl = "Text"
        Me.txtIdTipoDispositivo.BindearPropiedadEntidad = "IdTipoDispositivo"
        Me.txtIdTipoDispositivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTipoDispositivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTipoDispositivo.Formato = ""
        Me.txtIdTipoDispositivo.IsDecimal = False
        Me.txtIdTipoDispositivo.IsNumber = False
        Me.txtIdTipoDispositivo.IsPK = False
        Me.txtIdTipoDispositivo.IsRequired = True
        Me.txtIdTipoDispositivo.Key = ""
        Me.txtIdTipoDispositivo.LabelAsoc = Me.lblIdTipoDispositivo
        Me.txtIdTipoDispositivo.Location = New System.Drawing.Point(307, 33)
        Me.txtIdTipoDispositivo.MaxLength = 100
        Me.txtIdTipoDispositivo.Name = "txtIdTipoDispositivo"
        Me.txtIdTipoDispositivo.Size = New System.Drawing.Size(70, 20)
        Me.txtIdTipoDispositivo.TabIndex = 5
        '
        'lblSistemaOperativo
        '
        Me.lblSistemaOperativo.AutoSize = True
        Me.lblSistemaOperativo.LabelAsoc = Nothing
        Me.lblSistemaOperativo.Location = New System.Drawing.Point(20, 141)
        Me.lblSistemaOperativo.Name = "lblSistemaOperativo"
        Me.lblSistemaOperativo.Size = New System.Drawing.Size(93, 13)
        Me.lblSistemaOperativo.TabIndex = 13
        Me.lblSistemaOperativo.Text = "Sistema Operativo"
        '
        'txtSistemaOperativo
        '
        Me.txtSistemaOperativo.BindearPropiedadControl = "Text"
        Me.txtSistemaOperativo.BindearPropiedadEntidad = "SistemaOperativo"
        Me.txtSistemaOperativo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSistemaOperativo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSistemaOperativo.Formato = ""
        Me.txtSistemaOperativo.IsDecimal = False
        Me.txtSistemaOperativo.IsNumber = False
        Me.txtSistemaOperativo.IsPK = False
        Me.txtSistemaOperativo.IsRequired = True
        Me.txtSistemaOperativo.Key = ""
        Me.txtSistemaOperativo.LabelAsoc = Me.lblSistemaOperativo
        Me.txtSistemaOperativo.Location = New System.Drawing.Point(147, 137)
        Me.txtSistemaOperativo.MaxLength = 100
        Me.txtSistemaOperativo.Name = "txtSistemaOperativo"
        Me.txtSistemaOperativo.Size = New System.Drawing.Size(230, 20)
        Me.txtSistemaOperativo.TabIndex = 14
        '
        'gpBoxUltimoLogin
        '
        Me.gpBoxUltimoLogin.Controls.Add(Me.lblFechaUltimoLogin)
        Me.gpBoxUltimoLogin.Controls.Add(Me.dtpFechaUltLogin)
        Me.gpBoxUltimoLogin.Controls.Add(Me.lblUsuarioUltimoLogin)
        Me.gpBoxUltimoLogin.Controls.Add(Me.txtUsuarioUltLogin)
        Me.gpBoxUltimoLogin.Location = New System.Drawing.Point(12, 69)
        Me.gpBoxUltimoLogin.Name = "gpBoxUltimoLogin"
        Me.gpBoxUltimoLogin.Size = New System.Drawing.Size(365, 60)
        Me.gpBoxUltimoLogin.TabIndex = 10
        Me.gpBoxUltimoLogin.TabStop = False
        Me.gpBoxUltimoLogin.Text = "Último Login"
        '
        'lblArquitecturaSO
        '
        Me.lblArquitecturaSO.AutoSize = True
        Me.lblArquitecturaSO.LabelAsoc = Nothing
        Me.lblArquitecturaSO.Location = New System.Drawing.Point(396, 141)
        Me.lblArquitecturaSO.Name = "lblArquitecturaSO"
        Me.lblArquitecturaSO.Size = New System.Drawing.Size(64, 13)
        Me.lblArquitecturaSO.TabIndex = 15
        Me.lblArquitecturaSO.Text = "Arquitectura"
        '
        'txtArquitecturaSO
        '
        Me.txtArquitecturaSO.BindearPropiedadControl = "Text"
        Me.txtArquitecturaSO.BindearPropiedadEntidad = "ArquitecturaSO"
        Me.txtArquitecturaSO.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArquitecturaSO.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArquitecturaSO.Formato = ""
        Me.txtArquitecturaSO.IsDecimal = False
        Me.txtArquitecturaSO.IsNumber = False
        Me.txtArquitecturaSO.IsPK = False
        Me.txtArquitecturaSO.IsRequired = True
        Me.txtArquitecturaSO.Key = ""
        Me.txtArquitecturaSO.LabelAsoc = Me.lblArquitecturaSO
        Me.txtArquitecturaSO.Location = New System.Drawing.Point(465, 137)
        Me.txtArquitecturaSO.MaxLength = 100
        Me.txtArquitecturaSO.Name = "txtArquitecturaSO"
        Me.txtArquitecturaSO.Size = New System.Drawing.Size(41, 20)
        Me.txtArquitecturaSO.TabIndex = 16
        '
        'lblNumSerieDiscRig
        '
        Me.lblNumSerieDiscRig.AutoSize = True
        Me.lblNumSerieDiscRig.LabelAsoc = Nothing
        Me.lblNumSerieDiscRig.Location = New System.Drawing.Point(20, 193)
        Me.lblNumSerieDiscRig.Name = "lblNumSerieDiscRig"
        Me.lblNumSerieDiscRig.Size = New System.Drawing.Size(98, 13)
        Me.lblNumSerieDiscRig.TabIndex = 19
        Me.lblNumSerieDiscRig.Text = "Número Serie HDD"
        '
        'txtBoxNumSerieHDD
        '
        Me.txtBoxNumSerieHDD.BindearPropiedadControl = "Text"
        Me.txtBoxNumSerieHDD.BindearPropiedadEntidad = "NumeroSerieDiscoRigido"
        Me.txtBoxNumSerieHDD.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBoxNumSerieHDD.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBoxNumSerieHDD.Formato = ""
        Me.txtBoxNumSerieHDD.IsDecimal = False
        Me.txtBoxNumSerieHDD.IsNumber = False
        Me.txtBoxNumSerieHDD.IsPK = False
        Me.txtBoxNumSerieHDD.IsRequired = True
        Me.txtBoxNumSerieHDD.Key = ""
        Me.txtBoxNumSerieHDD.LabelAsoc = Me.lblNumSerieDiscRig
        Me.txtBoxNumSerieHDD.Location = New System.Drawing.Point(147, 190)
        Me.txtBoxNumSerieHDD.MaxLength = 100
        Me.txtBoxNumSerieHDD.Name = "txtBoxNumSerieHDD"
        Me.txtBoxNumSerieHDD.Size = New System.Drawing.Size(230, 20)
        Me.txtBoxNumSerieHDD.TabIndex = 20
        '
        'lblDireccionMAC
        '
        Me.lblDireccionMAC.AutoSize = True
        Me.lblDireccionMAC.LabelAsoc = Nothing
        Me.lblDireccionMAC.Location = New System.Drawing.Point(20, 248)
        Me.lblDireccionMAC.Name = "lblDireccionMAC"
        Me.lblDireccionMAC.Size = New System.Drawing.Size(78, 13)
        Me.lblDireccionMAC.TabIndex = 23
        Me.lblDireccionMAC.Text = "Dirección MAC"
        '
        'txtBoxDirecMAC
        '
        Me.txtBoxDirecMAC.BindearPropiedadControl = "Text"
        Me.txtBoxDirecMAC.BindearPropiedadEntidad = "DireccionMAC"
        Me.txtBoxDirecMAC.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBoxDirecMAC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBoxDirecMAC.Formato = ""
        Me.txtBoxDirecMAC.IsDecimal = False
        Me.txtBoxDirecMAC.IsNumber = False
        Me.txtBoxDirecMAC.IsPK = False
        Me.txtBoxDirecMAC.IsRequired = True
        Me.txtBoxDirecMAC.Key = ""
        Me.txtBoxDirecMAC.LabelAsoc = Me.lblDireccionMAC
        Me.txtBoxDirecMAC.Location = New System.Drawing.Point(147, 245)
        Me.txtBoxDirecMAC.MaxLength = 100
        Me.txtBoxDirecMAC.Name = "txtBoxDirecMAC"
        Me.txtBoxDirecMAC.Size = New System.Drawing.Size(230, 20)
        Me.txtBoxDirecMAC.TabIndex = 24
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Me.lblActivo
        Me.chbActivo.Location = New System.Drawing.Point(399, 36)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(15, 14)
        Me.chbActivo.TabIndex = 7
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.LabelAsoc = Nothing
        Me.lblActivo.Location = New System.Drawing.Point(387, 16)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 6
        Me.lblActivo.Text = "Activo"
        '
        'lblNumSerieDiscoPrimario
        '
        Me.lblNumSerieDiscoPrimario.AutoSize = True
        Me.lblNumSerieDiscoPrimario.LabelAsoc = Nothing
        Me.lblNumSerieDiscoPrimario.Location = New System.Drawing.Point(20, 166)
        Me.lblNumSerieDiscoPrimario.Name = "lblNumSerieDiscoPrimario"
        Me.lblNumSerieDiscoPrimario.Size = New System.Drawing.Size(121, 13)
        Me.lblNumSerieDiscoPrimario.TabIndex = 17
        Me.lblNumSerieDiscoPrimario.Text = "Nro Serie Disco Primario"
        '
        'txtNumSerieDiscoPrimario
        '
        Me.txtNumSerieDiscoPrimario.BindearPropiedadControl = "Text"
        Me.txtNumSerieDiscoPrimario.BindearPropiedadEntidad = "NumeroSerieDiscoPrimario"
        Me.txtNumSerieDiscoPrimario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumSerieDiscoPrimario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumSerieDiscoPrimario.Formato = ""
        Me.txtNumSerieDiscoPrimario.IsDecimal = False
        Me.txtNumSerieDiscoPrimario.IsNumber = False
        Me.txtNumSerieDiscoPrimario.IsPK = False
        Me.txtNumSerieDiscoPrimario.IsRequired = True
        Me.txtNumSerieDiscoPrimario.Key = ""
        Me.txtNumSerieDiscoPrimario.LabelAsoc = Me.lblNumSerieDiscoPrimario
        Me.txtNumSerieDiscoPrimario.Location = New System.Drawing.Point(147, 163)
        Me.txtNumSerieDiscoPrimario.MaxLength = 100
        Me.txtNumSerieDiscoPrimario.Name = "txtNumSerieDiscoPrimario"
        Me.txtNumSerieDiscoPrimario.Size = New System.Drawing.Size(230, 20)
        Me.txtNumSerieDiscoPrimario.TabIndex = 18
        '
        'lblResolucionPantalla
        '
        Me.lblResolucionPantalla.AutoSize = True
        Me.lblResolucionPantalla.LabelAsoc = Nothing
        Me.lblResolucionPantalla.Location = New System.Drawing.Point(20, 274)
        Me.lblResolucionPantalla.Name = "lblResolucionPantalla"
        Me.lblResolucionPantalla.Size = New System.Drawing.Size(116, 13)
        Me.lblResolucionPantalla.TabIndex = 25
        Me.lblResolucionPantalla.Text = "Resolucion de Pantalla"
        '
        'txtResolucionPantalla
        '
        Me.txtResolucionPantalla.BindearPropiedadControl = "Text"
        Me.txtResolucionPantalla.BindearPropiedadEntidad = "ResolucionPantalla"
        Me.txtResolucionPantalla.ForeColorFocus = System.Drawing.Color.Red
        Me.txtResolucionPantalla.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtResolucionPantalla.Formato = ""
        Me.txtResolucionPantalla.IsDecimal = False
        Me.txtResolucionPantalla.IsNumber = False
        Me.txtResolucionPantalla.IsPK = False
        Me.txtResolucionPantalla.IsRequired = True
        Me.txtResolucionPantalla.Key = ""
        Me.txtResolucionPantalla.LabelAsoc = Me.lblResolucionPantalla
        Me.txtResolucionPantalla.Location = New System.Drawing.Point(147, 271)
        Me.txtResolucionPantalla.MaxLength = 100
        Me.txtResolucionPantalla.Name = "txtResolucionPantalla"
        Me.txtResolucionPantalla.Size = New System.Drawing.Size(120, 20)
        Me.txtResolucionPantalla.TabIndex = 26
        '
        'lblVersionFramework
        '
        Me.lblVersionFramework.AutoSize = True
        Me.lblVersionFramework.LabelAsoc = Nothing
        Me.lblVersionFramework.Location = New System.Drawing.Point(396, 96)
        Me.lblVersionFramework.Name = "lblVersionFramework"
        Me.lblVersionFramework.Size = New System.Drawing.Size(97, 13)
        Me.lblVersionFramework.TabIndex = 11
        Me.lblVersionFramework.Text = "Version Framework"
        '
        'txtVersionFramework
        '
        Me.txtVersionFramework.BindearPropiedadControl = "Text"
        Me.txtVersionFramework.BindearPropiedadEntidad = "VersionFramework"
        Me.txtVersionFramework.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVersionFramework.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVersionFramework.Formato = ""
        Me.txtVersionFramework.IsDecimal = False
        Me.txtVersionFramework.IsNumber = False
        Me.txtVersionFramework.IsPK = False
        Me.txtVersionFramework.IsRequired = True
        Me.txtVersionFramework.Key = ""
        Me.txtVersionFramework.LabelAsoc = Me.lblVersionFramework
        Me.txtVersionFramework.Location = New System.Drawing.Point(496, 92)
        Me.txtVersionFramework.MaxLength = 100
        Me.txtVersionFramework.Name = "txtVersionFramework"
        Me.txtVersionFramework.Size = New System.Drawing.Size(80, 20)
        Me.txtVersionFramework.TabIndex = 12
        '
        'lblNumeroSerieMotherboard
        '
        Me.lblNumeroSerieMotherboard.AutoSize = True
        Me.lblNumeroSerieMotherboard.LabelAsoc = Nothing
        Me.lblNumeroSerieMotherboard.Location = New System.Drawing.Point(20, 222)
        Me.lblNumeroSerieMotherboard.Name = "lblNumeroSerieMotherboard"
        Me.lblNumeroSerieMotherboard.Size = New System.Drawing.Size(117, 13)
        Me.lblNumeroSerieMotherboard.TabIndex = 21
        Me.lblNumeroSerieMotherboard.Text = "Nro. Serie Motherboard"
        '
        'txtNumeroSerieMotherboard
        '
        Me.txtNumeroSerieMotherboard.BindearPropiedadControl = "Text"
        Me.txtNumeroSerieMotherboard.BindearPropiedadEntidad = "NumeroSerieMotherboard"
        Me.txtNumeroSerieMotherboard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroSerieMotherboard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroSerieMotherboard.Formato = ""
        Me.txtNumeroSerieMotherboard.IsDecimal = False
        Me.txtNumeroSerieMotherboard.IsNumber = False
        Me.txtNumeroSerieMotherboard.IsPK = False
        Me.txtNumeroSerieMotherboard.IsRequired = True
        Me.txtNumeroSerieMotherboard.Key = ""
        Me.txtNumeroSerieMotherboard.LabelAsoc = Me.lblNumeroSerieMotherboard
        Me.txtNumeroSerieMotherboard.Location = New System.Drawing.Point(147, 219)
        Me.txtNumeroSerieMotherboard.MaxLength = 100
        Me.txtNumeroSerieMotherboard.Name = "txtNumeroSerieMotherboard"
        Me.txtNumeroSerieMotherboard.Size = New System.Drawing.Size(230, 20)
        Me.txtNumeroSerieMotherboard.TabIndex = 22
        '
        'lblFechaUltimaInactivacion
        '
        Me.lblFechaUltimaInactivacion.AutoSize = True
        Me.lblFechaUltimaInactivacion.LabelAsoc = Nothing
        Me.lblFechaUltimaInactivacion.Location = New System.Drawing.Point(437, 16)
        Me.lblFechaUltimaInactivacion.Name = "lblFechaUltimaInactivacion"
        Me.lblFechaUltimaInactivacion.Size = New System.Drawing.Size(97, 13)
        Me.lblFechaUltimaInactivacion.TabIndex = 8
        Me.lblFechaUltimaInactivacion.Text = "Ultima Inactivacion"
        '
        'txtFechaUltimaInactivacion
        '
        Me.txtFechaUltimaInactivacion.BindearPropiedadControl = "Text"
        Me.txtFechaUltimaInactivacion.BindearPropiedadEntidad = "Control1"
        Me.txtFechaUltimaInactivacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaUltimaInactivacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaUltimaInactivacion.Formato = ""
        Me.txtFechaUltimaInactivacion.IsDecimal = False
        Me.txtFechaUltimaInactivacion.IsNumber = False
        Me.txtFechaUltimaInactivacion.IsPK = False
        Me.txtFechaUltimaInactivacion.IsRequired = True
        Me.txtFechaUltimaInactivacion.Key = ""
        Me.txtFechaUltimaInactivacion.LabelAsoc = Me.lblFechaUltimaInactivacion
        Me.txtFechaUltimaInactivacion.Location = New System.Drawing.Point(390, 56)
        Me.txtFechaUltimaInactivacion.MaxLength = 100
        Me.txtFechaUltimaInactivacion.Name = "txtFechaUltimaInactivacion"
        Me.txtFechaUltimaInactivacion.Size = New System.Drawing.Size(186, 20)
        Me.txtFechaUltimaInactivacion.TabIndex = 9
        '
        'dtpFechaUltimaInactivacion
        '
        Me.dtpFechaUltimaInactivacion.BindearPropiedadControl = ""
        Me.dtpFechaUltimaInactivacion.BindearPropiedadEntidad = ""
        Me.dtpFechaUltimaInactivacion.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaUltimaInactivacion.Enabled = False
        Me.dtpFechaUltimaInactivacion.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaUltimaInactivacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaUltimaInactivacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaUltimaInactivacion.IsPK = False
        Me.dtpFechaUltimaInactivacion.IsRequired = False
        Me.dtpFechaUltimaInactivacion.Key = ""
        Me.dtpFechaUltimaInactivacion.LabelAsoc = Me.lblFechaUltimoLogin
        Me.dtpFechaUltimaInactivacion.Location = New System.Drawing.Point(439, 32)
        Me.dtpFechaUltimaInactivacion.Name = "dtpFechaUltimaInactivacion"
        Me.dtpFechaUltimaInactivacion.Size = New System.Drawing.Size(117, 20)
        Me.dtpFechaUltimaInactivacion.TabIndex = 31
        '
        'DispositivosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 353)
        Me.Controls.Add(Me.dtpFechaUltimaInactivacion)
        Me.Controls.Add(Me.txtFechaUltimaInactivacion)
        Me.Controls.Add(Me.lblActivo)
        Me.Controls.Add(Me.lblFechaUltimaInactivacion)
        Me.Controls.Add(Me.lblNumeroSerieMotherboard)
        Me.Controls.Add(Me.txtNumeroSerieMotherboard)
        Me.Controls.Add(Me.lblVersionFramework)
        Me.Controls.Add(Me.txtVersionFramework)
        Me.Controls.Add(Me.lblResolucionPantalla)
        Me.Controls.Add(Me.txtResolucionPantalla)
        Me.Controls.Add(Me.lblNumSerieDiscoPrimario)
        Me.Controls.Add(Me.txtNumSerieDiscoPrimario)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.lblDireccionMAC)
        Me.Controls.Add(Me.txtBoxDirecMAC)
        Me.Controls.Add(Me.lblNumSerieDiscRig)
        Me.Controls.Add(Me.txtBoxNumSerieHDD)
        Me.Controls.Add(Me.lblArquitecturaSO)
        Me.Controls.Add(Me.txtArquitecturaSO)
        Me.Controls.Add(Me.gpBoxUltimoLogin)
        Me.Controls.Add(Me.lblSistemaOperativo)
        Me.Controls.Add(Me.txtSistemaOperativo)
        Me.Controls.Add(Me.lblIdTipoDispositivo)
        Me.Controls.Add(Me.txtIdTipoDispositivo)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombreDispositivo)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtIdDispositivo)
        Me.Name = "DispositivosDetalle"
        Me.Text = "Dispositivo"
        Me.Controls.SetChildIndex(Me.txtIdDispositivo, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtNombreDispositivo, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtIdTipoDispositivo, 0)
        Me.Controls.SetChildIndex(Me.lblIdTipoDispositivo, 0)
        Me.Controls.SetChildIndex(Me.txtSistemaOperativo, 0)
        Me.Controls.SetChildIndex(Me.lblSistemaOperativo, 0)
        Me.Controls.SetChildIndex(Me.gpBoxUltimoLogin, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtArquitecturaSO, 0)
        Me.Controls.SetChildIndex(Me.lblArquitecturaSO, 0)
        Me.Controls.SetChildIndex(Me.txtBoxNumSerieHDD, 0)
        Me.Controls.SetChildIndex(Me.lblNumSerieDiscRig, 0)
        Me.Controls.SetChildIndex(Me.txtBoxDirecMAC, 0)
        Me.Controls.SetChildIndex(Me.lblDireccionMAC, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.txtNumSerieDiscoPrimario, 0)
        Me.Controls.SetChildIndex(Me.lblNumSerieDiscoPrimario, 0)
        Me.Controls.SetChildIndex(Me.txtResolucionPantalla, 0)
        Me.Controls.SetChildIndex(Me.lblResolucionPantalla, 0)
        Me.Controls.SetChildIndex(Me.txtVersionFramework, 0)
        Me.Controls.SetChildIndex(Me.lblVersionFramework, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroSerieMotherboard, 0)
        Me.Controls.SetChildIndex(Me.lblNumeroSerieMotherboard, 0)
        Me.Controls.SetChildIndex(Me.lblFechaUltimaInactivacion, 0)
        Me.Controls.SetChildIndex(Me.lblActivo, 0)
        Me.Controls.SetChildIndex(Me.txtFechaUltimaInactivacion, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaUltimaInactivacion, 0)
        Me.gpBoxUltimoLogin.ResumeLayout(False)
        Me.gpBoxUltimoLogin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtNombreDispositivo As Controles.TextBox
   Friend WithEvents lblId As Controles.Label
   Friend WithEvents txtIdDispositivo As Controles.TextBox
   Friend WithEvents dtpFechaUltLogin As Controles.DateTimePicker
   Friend WithEvents lblFechaUltimoLogin As Controles.Label
   Friend WithEvents lblUsuarioUltimoLogin As Controles.Label
   Friend WithEvents txtUsuarioUltLogin As Controles.TextBox
   Friend WithEvents lblIdTipoDispositivo As Controles.Label
   Friend WithEvents txtIdTipoDispositivo As Controles.TextBox
   Friend WithEvents lblSistemaOperativo As Controles.Label
   Friend WithEvents txtSistemaOperativo As Controles.TextBox
   Friend WithEvents gpBoxUltimoLogin As GroupBox
   Friend WithEvents lblArquitecturaSO As Controles.Label
   Friend WithEvents txtArquitecturaSO As Controles.TextBox
   Friend WithEvents lblNumSerieDiscRig As Controles.Label
   Friend WithEvents txtBoxNumSerieHDD As Controles.TextBox
   Friend WithEvents lblDireccionMAC As Controles.Label
   Friend WithEvents txtBoxDirecMAC As Controles.TextBox
    Friend WithEvents chbActivo As Controles.CheckBox
    Friend WithEvents lblNumSerieDiscoPrimario As Controles.Label
    Friend WithEvents txtNumSerieDiscoPrimario As Controles.TextBox
    Friend WithEvents lblResolucionPantalla As Controles.Label
    Friend WithEvents txtResolucionPantalla As Controles.TextBox
    Friend WithEvents lblVersionFramework As Controles.Label
    Friend WithEvents txtVersionFramework As Controles.TextBox
    Friend WithEvents lblNumeroSerieMotherboard As Controles.Label
    Friend WithEvents txtNumeroSerieMotherboard As Controles.TextBox
    Friend WithEvents lblActivo As Controles.Label
    Friend WithEvents lblFechaUltimaInactivacion As Controles.Label
    Friend WithEvents txtFechaUltimaInactivacion As Controles.TextBox
    Friend WithEvents dtpFechaUltimaInactivacion As Controles.DateTimePicker
End Class
