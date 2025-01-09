<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UsuariosDetalle
   Inherits Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UsuariosDetalle))

      Me._publicos = New Eniac.Win.Publicos()

      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblClave = New Eniac.Controles.Label()
      Me.txtClave = New Eniac.Controles.TextBox()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.dtpFechaUltimaModContraseña = New Eniac.Controles.DateTimePicker()
      Me.lblFechaIngreso = New Eniac.Controles.Label()
      Me.txtCorreoElectronico = New Eniac.Controles.TextBox()
      Me.lblCorreoElectronico = New Eniac.Controles.Label()
      Me.grbCorreoElectronico = New System.Windows.Forms.GroupBox()
      Me.chbUtilizaComoPredeterminado = New Eniac.Controles.CheckBox()
      Me.lblCantidadMailsPorHora = New Eniac.Controles.Label()
      Me.lblCantidadMailsPorMinuto = New Eniac.Controles.Label()
      Me.txtCantidadMailsPorHora = New Eniac.Controles.TextBox()
      Me.txtCantidadMailsPorMinuto = New Eniac.Controles.TextBox()
      Me.chbMailRequiereSSL = New Eniac.Controles.CheckBox()
      Me.chbMailRequiereAutenticacion = New Eniac.Controles.CheckBox()
      Me.txtMailPuertoSalida = New Eniac.Controles.TextBox()
      Me.lblMailServidor = New Eniac.Controles.Label()
      Me.txtMailDireccion = New Eniac.Controles.TextBox()
      Me.lblMailDireccion = New Eniac.Controles.Label()
      Me.txtMailPassword = New Eniac.Controles.TextBox()
      Me.lblMailPassword = New Eniac.Controles.Label()
      Me.txtMailUsuario = New Eniac.Controles.TextBox()
      Me.lblMailUsuario = New Eniac.Controles.Label()
      Me.txtMailServidor = New Eniac.Controles.TextBox()
      Me.txtNivelAutorizacion = New Eniac.Controles.TextBox()
      Me.lblNivelAutorizacion = New Eniac.Controles.Label()
      Me.cmbTipoUsuario = New Eniac.Controles.ComboBox()
      Me.lblTipoUsuario = New Eniac.Controles.Label()
      Me.grbCorreoElectronico.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(328, 368)
      Me.btnAceptar.TabIndex = 14
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(414, 368)
      Me.btnCancelar.TabIndex = 15
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(229, 368)
      Me.btnCopiar.TabIndex = 17
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(169, 368)
      Me.btnAplicar.TabIndex = 16
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.LabelAsoc = Nothing
      Me.lblId.Location = New System.Drawing.Point(19, 23)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(70, 13)
      Me.lblId.TabIndex = 0
      Me.lblId.Text = "Identificacion"
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "Id"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = False
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(92, 19)
      Me.txtId.MaxLength = 10
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(103, 20)
      Me.txtId.TabIndex = 1
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(19, 49)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "Nombre"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(92, 45)
      Me.txtNombre.MaxLength = 50
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(401, 20)
      Me.txtNombre.TabIndex = 3
      '
      'lblClave
      '
      Me.lblClave.AutoSize = True
      Me.lblClave.LabelAsoc = Nothing
      Me.lblClave.Location = New System.Drawing.Point(19, 75)
      Me.lblClave.Name = "lblClave"
      Me.lblClave.Size = New System.Drawing.Size(34, 13)
      Me.lblClave.TabIndex = 4
      Me.lblClave.Text = "Clave"
      '
      'txtClave
      '
      Me.txtClave.BindearPropiedadControl = "Text"
      Me.txtClave.BindearPropiedadEntidad = "Clave"
      Me.txtClave.ForeColorFocus = System.Drawing.Color.Red
      Me.txtClave.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtClave.Formato = ""
      Me.txtClave.IsDecimal = False
      Me.txtClave.IsNumber = False
      Me.txtClave.IsPK = False
      Me.txtClave.IsRequired = True
      Me.txtClave.Key = ""
      Me.txtClave.LabelAsoc = Me.lblClave
      Me.txtClave.Location = New System.Drawing.Point(92, 71)
      Me.txtClave.MaxLength = 15
      Me.txtClave.Name = "txtClave"
      Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtClave.Size = New System.Drawing.Size(103, 20)
      Me.txtClave.TabIndex = 5
      Me.txtClave.UseSystemPasswordChar = True
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
      Me.chbActivo.Location = New System.Drawing.Point(437, 21)
      Me.chbActivo.Name = "chbActivo"
      Me.chbActivo.Size = New System.Drawing.Size(56, 17)
      Me.chbActivo.TabIndex = 13
      Me.chbActivo.Text = "Activo"
      Me.chbActivo.UseVisualStyleBackColor = True
      '
      'dtpFechaUltimaModContraseña
      '
      Me.dtpFechaUltimaModContraseña.BindearPropiedadControl = "Value"
      Me.dtpFechaUltimaModContraseña.BindearPropiedadEntidad = "FechaUltimaModContraseña"
      Me.dtpFechaUltimaModContraseña.CustomFormat = "dd/MM/yyyy "
      Me.dtpFechaUltimaModContraseña.Enabled = False
      Me.dtpFechaUltimaModContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpFechaUltimaModContraseña.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaUltimaModContraseña.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaUltimaModContraseña.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaUltimaModContraseña.IsPK = False
      Me.dtpFechaUltimaModContraseña.IsRequired = False
      Me.dtpFechaUltimaModContraseña.Key = ""
      Me.dtpFechaUltimaModContraseña.LabelAsoc = Me.lblFechaIngreso
      Me.dtpFechaUltimaModContraseña.Location = New System.Drawing.Point(395, 71)
      Me.dtpFechaUltimaModContraseña.Name = "dtpFechaUltimaModContraseña"
      Me.dtpFechaUltimaModContraseña.Size = New System.Drawing.Size(98, 20)
      Me.dtpFechaUltimaModContraseña.TabIndex = 7
      '
      'lblFechaIngreso
      '
      Me.lblFechaIngreso.AutoSize = True
      Me.lblFechaIngreso.LabelAsoc = Nothing
      Me.lblFechaIngreso.Location = New System.Drawing.Point(203, 75)
      Me.lblFechaIngreso.Name = "lblFechaIngreso"
      Me.lblFechaIngreso.Size = New System.Drawing.Size(189, 13)
      Me.lblFechaIngreso.TabIndex = 6
      Me.lblFechaIngreso.Text = "Fecha Ultima Modificación Contraseña"
      '
      'txtCorreoElectronico
      '
      Me.txtCorreoElectronico.BindearPropiedadControl = "Text"
      Me.txtCorreoElectronico.BindearPropiedadEntidad = "CorreoElectronico"
      Me.txtCorreoElectronico.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCorreoElectronico.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCorreoElectronico.Formato = ""
      Me.txtCorreoElectronico.IsDecimal = False
      Me.txtCorreoElectronico.IsNumber = False
      Me.txtCorreoElectronico.IsPK = False
      Me.txtCorreoElectronico.IsRequired = False
      Me.txtCorreoElectronico.Key = ""
      Me.txtCorreoElectronico.LabelAsoc = Me.lblCorreoElectronico
      Me.txtCorreoElectronico.Location = New System.Drawing.Point(92, 97)
      Me.txtCorreoElectronico.MaxLength = 100
      Me.txtCorreoElectronico.Name = "txtCorreoElectronico"
      Me.txtCorreoElectronico.Size = New System.Drawing.Size(401, 20)
      Me.txtCorreoElectronico.TabIndex = 9
      '
      'lblCorreoElectronico
      '
      Me.lblCorreoElectronico.AutoSize = True
      Me.lblCorreoElectronico.LabelAsoc = Nothing
      Me.lblCorreoElectronico.Location = New System.Drawing.Point(19, 101)
      Me.lblCorreoElectronico.Name = "lblCorreoElectronico"
      Me.lblCorreoElectronico.Size = New System.Drawing.Size(65, 13)
      Me.lblCorreoElectronico.TabIndex = 8
      Me.lblCorreoElectronico.Text = "Correo Elec."
      '
      'grbCorreoElectronico
      '
      Me.grbCorreoElectronico.Controls.Add(Me.chbUtilizaComoPredeterminado)
      Me.grbCorreoElectronico.Controls.Add(Me.lblCantidadMailsPorHora)
      Me.grbCorreoElectronico.Controls.Add(Me.lblCantidadMailsPorMinuto)
      Me.grbCorreoElectronico.Controls.Add(Me.txtCantidadMailsPorHora)
      Me.grbCorreoElectronico.Controls.Add(Me.txtCantidadMailsPorMinuto)
      Me.grbCorreoElectronico.Controls.Add(Me.chbMailRequiereSSL)
      Me.grbCorreoElectronico.Controls.Add(Me.chbMailRequiereAutenticacion)
      Me.grbCorreoElectronico.Controls.Add(Me.txtMailPuertoSalida)
      Me.grbCorreoElectronico.Controls.Add(Me.txtMailDireccion)
      Me.grbCorreoElectronico.Controls.Add(Me.lblMailDireccion)
      Me.grbCorreoElectronico.Controls.Add(Me.txtMailPassword)
      Me.grbCorreoElectronico.Controls.Add(Me.lblMailPassword)
      Me.grbCorreoElectronico.Controls.Add(Me.txtMailUsuario)
      Me.grbCorreoElectronico.Controls.Add(Me.lblMailUsuario)
      Me.grbCorreoElectronico.Controls.Add(Me.txtMailServidor)
      Me.grbCorreoElectronico.Controls.Add(Me.lblMailServidor)
      Me.grbCorreoElectronico.Location = New System.Drawing.Point(22, 150)
      Me.grbCorreoElectronico.Name = "grbCorreoElectronico"
      Me.grbCorreoElectronico.Size = New System.Drawing.Size(471, 212)
      Me.grbCorreoElectronico.TabIndex = 12
      Me.grbCorreoElectronico.TabStop = False
      Me.grbCorreoElectronico.Text = "Correo Electronico "
      '
      'chbUtilizaComoPredeterminado
      '
      Me.chbUtilizaComoPredeterminado.BindearPropiedadControl = ""
      Me.chbUtilizaComoPredeterminado.BindearPropiedadEntidad = ""
      Me.chbUtilizaComoPredeterminado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUtilizaComoPredeterminado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUtilizaComoPredeterminado.IsPK = False
      Me.chbUtilizaComoPredeterminado.IsRequired = False
      Me.chbUtilizaComoPredeterminado.Key = Nothing
      Me.chbUtilizaComoPredeterminado.LabelAsoc = Nothing
      Me.chbUtilizaComoPredeterminado.Location = New System.Drawing.Point(16, 13)
      Me.chbUtilizaComoPredeterminado.Name = "chbUtilizaComoPredeterminado"
      Me.chbUtilizaComoPredeterminado.Size = New System.Drawing.Size(284, 32)
      Me.chbUtilizaComoPredeterminado.TabIndex = 0
      Me.chbUtilizaComoPredeterminado.Tag = ""
      Me.chbUtilizaComoPredeterminado.Text = "Utiliza este correo como predeterminado"
      Me.chbUtilizaComoPredeterminado.UseVisualStyleBackColor = True
      '
      'lblCantidadMailsPorHora
      '
      Me.lblCantidadMailsPorHora.AutoSize = True
      Me.lblCantidadMailsPorHora.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCantidadMailsPorHora.LabelAsoc = Nothing
      Me.lblCantidadMailsPorHora.Location = New System.Drawing.Point(293, 185)
      Me.lblCantidadMailsPorHora.Name = "lblCantidadMailsPorHora"
      Me.lblCantidadMailsPorHora.Size = New System.Drawing.Size(115, 13)
      Me.lblCantidadMailsPorHora.TabIndex = 14
      Me.lblCantidadMailsPorHora.Text = "Cant. Correos por Hora"
      '
      'lblCantidadMailsPorMinuto
      '
      Me.lblCantidadMailsPorMinuto.AutoSize = True
      Me.lblCantidadMailsPorMinuto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCantidadMailsPorMinuto.LabelAsoc = Nothing
      Me.lblCantidadMailsPorMinuto.Location = New System.Drawing.Point(293, 159)
      Me.lblCantidadMailsPorMinuto.Name = "lblCantidadMailsPorMinuto"
      Me.lblCantidadMailsPorMinuto.Size = New System.Drawing.Size(124, 13)
      Me.lblCantidadMailsPorMinuto.TabIndex = 11
      Me.lblCantidadMailsPorMinuto.Text = "Cant. Correos por Minuto"
      '
      'txtCantidadMailsPorHora
      '
      Me.txtCantidadMailsPorHora.BindearPropiedadControl = ""
      Me.txtCantidadMailsPorHora.BindearPropiedadEntidad = ""
      Me.txtCantidadMailsPorHora.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadMailsPorHora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadMailsPorHora.Formato = ""
      Me.txtCantidadMailsPorHora.IsDecimal = False
      Me.txtCantidadMailsPorHora.IsNumber = True
      Me.txtCantidadMailsPorHora.IsPK = False
      Me.txtCantidadMailsPorHora.IsRequired = False
      Me.txtCantidadMailsPorHora.Key = ""
      Me.txtCantidadMailsPorHora.LabelAsoc = Me.lblCantidadMailsPorHora
      Me.txtCantidadMailsPorHora.Location = New System.Drawing.Point(418, 178)
      Me.txtCantidadMailsPorHora.MaxLength = 4
      Me.txtCantidadMailsPorHora.Name = "txtCantidadMailsPorHora"
      Me.txtCantidadMailsPorHora.Size = New System.Drawing.Size(47, 20)
      Me.txtCantidadMailsPorHora.TabIndex = 15
      Me.txtCantidadMailsPorHora.Tag = ""
      Me.txtCantidadMailsPorHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCantidadMailsPorMinuto
      '
      Me.txtCantidadMailsPorMinuto.BindearPropiedadControl = ""
      Me.txtCantidadMailsPorMinuto.BindearPropiedadEntidad = ""
      Me.txtCantidadMailsPorMinuto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadMailsPorMinuto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadMailsPorMinuto.Formato = ""
      Me.txtCantidadMailsPorMinuto.IsDecimal = False
      Me.txtCantidadMailsPorMinuto.IsNumber = True
      Me.txtCantidadMailsPorMinuto.IsPK = False
      Me.txtCantidadMailsPorMinuto.IsRequired = False
      Me.txtCantidadMailsPorMinuto.Key = ""
      Me.txtCantidadMailsPorMinuto.LabelAsoc = Me.lblCantidadMailsPorMinuto
      Me.txtCantidadMailsPorMinuto.Location = New System.Drawing.Point(417, 152)
      Me.txtCantidadMailsPorMinuto.MaxLength = 3
      Me.txtCantidadMailsPorMinuto.Name = "txtCantidadMailsPorMinuto"
      Me.txtCantidadMailsPorMinuto.Size = New System.Drawing.Size(47, 20)
      Me.txtCantidadMailsPorMinuto.TabIndex = 12
      Me.txtCantidadMailsPorMinuto.Tag = ""
      Me.txtCantidadMailsPorMinuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbMailRequiereSSL
      '
      Me.chbMailRequiereSSL.AutoSize = True
      Me.chbMailRequiereSSL.BindearPropiedadControl = ""
      Me.chbMailRequiereSSL.BindearPropiedadEntidad = ""
      Me.chbMailRequiereSSL.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMailRequiereSSL.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMailRequiereSSL.IsPK = False
      Me.chbMailRequiereSSL.IsRequired = False
      Me.chbMailRequiereSSL.Key = Nothing
      Me.chbMailRequiereSSL.LabelAsoc = Nothing
      Me.chbMailRequiereSSL.Location = New System.Drawing.Point(16, 154)
      Me.chbMailRequiereSSL.Name = "chbMailRequiereSSL"
      Me.chbMailRequiereSSL.Size = New System.Drawing.Size(200, 17)
      Me.chbMailRequiereSSL.TabIndex = 10
      Me.chbMailRequiereSSL.Tag = "MAILREQUIERESSL"
      Me.chbMailRequiereSSL.Text = "Requiere una conexión segura (SSL)"
      Me.chbMailRequiereSSL.UseVisualStyleBackColor = True
      '
      'chbMailRequiereAutenticacion
      '
      Me.chbMailRequiereAutenticacion.AutoSize = True
      Me.chbMailRequiereAutenticacion.BindearPropiedadControl = ""
      Me.chbMailRequiereAutenticacion.BindearPropiedadEntidad = ""
      Me.chbMailRequiereAutenticacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMailRequiereAutenticacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMailRequiereAutenticacion.IsPK = False
      Me.chbMailRequiereAutenticacion.IsRequired = False
      Me.chbMailRequiereAutenticacion.Key = Nothing
      Me.chbMailRequiereAutenticacion.LabelAsoc = Nothing
      Me.chbMailRequiereAutenticacion.Location = New System.Drawing.Point(16, 180)
      Me.chbMailRequiereAutenticacion.Name = "chbMailRequiereAutenticacion"
      Me.chbMailRequiereAutenticacion.Size = New System.Drawing.Size(190, 17)
      Me.chbMailRequiereAutenticacion.TabIndex = 13
      Me.chbMailRequiereAutenticacion.Tag = "MAILREQUIEREAUTENTICACION"
      Me.chbMailRequiereAutenticacion.Text = "El Servidor Requiere autenticación"
      Me.chbMailRequiereAutenticacion.UseVisualStyleBackColor = True
      '
      'txtMailPuertoSalida
      '
      Me.txtMailPuertoSalida.BindearPropiedadControl = ""
      Me.txtMailPuertoSalida.BindearPropiedadEntidad = ""
      Me.txtMailPuertoSalida.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailPuertoSalida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailPuertoSalida.Formato = ""
      Me.txtMailPuertoSalida.IsDecimal = False
      Me.txtMailPuertoSalida.IsNumber = True
      Me.txtMailPuertoSalida.IsPK = False
      Me.txtMailPuertoSalida.IsRequired = False
      Me.txtMailPuertoSalida.Key = ""
      Me.txtMailPuertoSalida.LabelAsoc = Me.lblMailServidor
      Me.txtMailPuertoSalida.Location = New System.Drawing.Point(435, 50)
      Me.txtMailPuertoSalida.MaxLength = 4
      Me.txtMailPuertoSalida.Name = "txtMailPuertoSalida"
      Me.txtMailPuertoSalida.Size = New System.Drawing.Size(30, 20)
      Me.txtMailPuertoSalida.TabIndex = 3
      Me.txtMailPuertoSalida.Tag = ""
      Me.txtMailPuertoSalida.Text = "25"
      '
      'lblMailServidor
      '
      Me.lblMailServidor.AutoSize = True
      Me.lblMailServidor.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailServidor.LabelAsoc = Nothing
      Me.lblMailServidor.Location = New System.Drawing.Point(13, 53)
      Me.lblMailServidor.Name = "lblMailServidor"
      Me.lblMailServidor.Size = New System.Drawing.Size(79, 13)
      Me.lblMailServidor.TabIndex = 1
      Me.lblMailServidor.Text = "Servidor SMTP"
      '
      'txtMailDireccion
      '
      Me.txtMailDireccion.BindearPropiedadControl = ""
      Me.txtMailDireccion.BindearPropiedadEntidad = ""
      Me.txtMailDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailDireccion.Formato = ""
      Me.txtMailDireccion.IsDecimal = False
      Me.txtMailDireccion.IsNumber = False
      Me.txtMailDireccion.IsPK = False
      Me.txtMailDireccion.IsRequired = False
      Me.txtMailDireccion.Key = ""
      Me.txtMailDireccion.LabelAsoc = Me.lblMailDireccion
      Me.txtMailDireccion.Location = New System.Drawing.Point(117, 76)
      Me.txtMailDireccion.MaxLength = 100
      Me.txtMailDireccion.Name = "txtMailDireccion"
      Me.txtMailDireccion.Size = New System.Drawing.Size(347, 20)
      Me.txtMailDireccion.TabIndex = 5
      Me.txtMailDireccion.Tag = "MAILDIRECCION"
      '
      'lblMailDireccion
      '
      Me.lblMailDireccion.AutoSize = True
      Me.lblMailDireccion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailDireccion.LabelAsoc = Nothing
      Me.lblMailDireccion.Location = New System.Drawing.Point(13, 80)
      Me.lblMailDireccion.Name = "lblMailDireccion"
      Me.lblMailDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblMailDireccion.TabIndex = 4
      Me.lblMailDireccion.Text = "Dirección"
      '
      'txtMailPassword
      '
      Me.txtMailPassword.BindearPropiedadControl = ""
      Me.txtMailPassword.BindearPropiedadEntidad = ""
      Me.txtMailPassword.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailPassword.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailPassword.Formato = ""
      Me.txtMailPassword.IsDecimal = False
      Me.txtMailPassword.IsNumber = False
      Me.txtMailPassword.IsPK = False
      Me.txtMailPassword.IsRequired = False
      Me.txtMailPassword.Key = ""
      Me.txtMailPassword.LabelAsoc = Me.lblMailPassword
      Me.txtMailPassword.Location = New System.Drawing.Point(117, 126)
      Me.txtMailPassword.MaxLength = 100
      Me.txtMailPassword.Name = "txtMailPassword"
      Me.txtMailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtMailPassword.Size = New System.Drawing.Size(347, 20)
      Me.txtMailPassword.TabIndex = 9
      Me.txtMailPassword.Tag = "MAILPASSWORD"
      '
      'lblMailPassword
      '
      Me.lblMailPassword.AutoSize = True
      Me.lblMailPassword.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailPassword.LabelAsoc = Nothing
      Me.lblMailPassword.Location = New System.Drawing.Point(13, 130)
      Me.lblMailPassword.Name = "lblMailPassword"
      Me.lblMailPassword.Size = New System.Drawing.Size(53, 13)
      Me.lblMailPassword.TabIndex = 8
      Me.lblMailPassword.Text = "Password"
      '
      'txtMailUsuario
      '
      Me.txtMailUsuario.BindearPropiedadControl = ""
      Me.txtMailUsuario.BindearPropiedadEntidad = ""
      Me.txtMailUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailUsuario.Formato = ""
      Me.txtMailUsuario.IsDecimal = False
      Me.txtMailUsuario.IsNumber = False
      Me.txtMailUsuario.IsPK = False
      Me.txtMailUsuario.IsRequired = False
      Me.txtMailUsuario.Key = ""
      Me.txtMailUsuario.LabelAsoc = Me.lblMailUsuario
      Me.txtMailUsuario.Location = New System.Drawing.Point(117, 100)
      Me.txtMailUsuario.MaxLength = 100
      Me.txtMailUsuario.Name = "txtMailUsuario"
      Me.txtMailUsuario.Size = New System.Drawing.Size(347, 20)
      Me.txtMailUsuario.TabIndex = 7
      Me.txtMailUsuario.Tag = ""
      '
      'lblMailUsuario
      '
      Me.lblMailUsuario.AutoSize = True
      Me.lblMailUsuario.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailUsuario.LabelAsoc = Nothing
      Me.lblMailUsuario.Location = New System.Drawing.Point(13, 104)
      Me.lblMailUsuario.Name = "lblMailUsuario"
      Me.lblMailUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblMailUsuario.TabIndex = 6
      Me.lblMailUsuario.Text = "Usuario"
      '
      'txtMailServidor
      '
      Me.txtMailServidor.BindearPropiedadControl = ""
      Me.txtMailServidor.BindearPropiedadEntidad = ""
      Me.txtMailServidor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailServidor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailServidor.Formato = ""
      Me.txtMailServidor.IsDecimal = False
      Me.txtMailServidor.IsNumber = False
      Me.txtMailServidor.IsPK = False
      Me.txtMailServidor.IsRequired = False
      Me.txtMailServidor.Key = ""
      Me.txtMailServidor.LabelAsoc = Me.lblMailServidor
      Me.txtMailServidor.Location = New System.Drawing.Point(117, 49)
      Me.txtMailServidor.MaxLength = 100
      Me.txtMailServidor.Name = "txtMailServidor"
      Me.txtMailServidor.Size = New System.Drawing.Size(312, 20)
      Me.txtMailServidor.TabIndex = 2
      Me.txtMailServidor.Tag = ""
      '
      'txtNivelAutorizacion
      '
      Me.txtNivelAutorizacion.BindearPropiedadControl = "Text"
      Me.txtNivelAutorizacion.BindearPropiedadEntidad = "NivelAutorizacion"
      Me.txtNivelAutorizacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNivelAutorizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNivelAutorizacion.Formato = ""
      Me.txtNivelAutorizacion.IsDecimal = False
      Me.txtNivelAutorizacion.IsNumber = True
      Me.txtNivelAutorizacion.IsPK = False
      Me.txtNivelAutorizacion.IsRequired = True
      Me.txtNivelAutorizacion.Key = ""
      Me.txtNivelAutorizacion.LabelAsoc = Me.lblNivelAutorizacion
      Me.txtNivelAutorizacion.Location = New System.Drawing.Point(132, 123)
      Me.txtNivelAutorizacion.MaxLength = 10
      Me.txtNivelAutorizacion.Name = "txtNivelAutorizacion"
      Me.txtNivelAutorizacion.Size = New System.Drawing.Size(63, 20)
      Me.txtNivelAutorizacion.TabIndex = 11
      '
      'lblNivelAutorizacion
      '
      Me.lblNivelAutorizacion.AutoSize = True
      Me.lblNivelAutorizacion.LabelAsoc = Nothing
      Me.lblNivelAutorizacion.Location = New System.Drawing.Point(19, 126)
      Me.lblNivelAutorizacion.Name = "lblNivelAutorizacion"
      Me.lblNivelAutorizacion.Size = New System.Drawing.Size(107, 13)
      Me.lblNivelAutorizacion.TabIndex = 10
      Me.lblNivelAutorizacion.Text = "Nivel de Autorización"
      '
      'cmbTipoUsuario
      '
      Me.cmbTipoUsuario.BindearPropiedadControl = Nothing
      Me.cmbTipoUsuario.BindearPropiedadEntidad = Nothing
      Me.cmbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoUsuario.Enabled = False
      Me.cmbTipoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTipoUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoUsuario.FormattingEnabled = True
      Me.cmbTipoUsuario.IsPK = False
      Me.cmbTipoUsuario.IsRequired = False
      Me.cmbTipoUsuario.Key = Nothing
      Me.cmbTipoUsuario.LabelAsoc = Me.lblTipoUsuario
      Me.cmbTipoUsuario.Location = New System.Drawing.Point(293, 124)
      Me.cmbTipoUsuario.Name = "cmbTipoUsuario"
      Me.cmbTipoUsuario.Size = New System.Drawing.Size(200, 21)
      Me.cmbTipoUsuario.TabIndex = 19
      '
      'lblTipoUsuario
      '
      Me.lblTipoUsuario.AutoSize = True
      Me.lblTipoUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblTipoUsuario.LabelAsoc = Nothing
      Me.lblTipoUsuario.Location = New System.Drawing.Point(203, 127)
      Me.lblTipoUsuario.Name = "lblTipoUsuario"
      Me.lblTipoUsuario.Size = New System.Drawing.Size(82, 13)
      Me.lblTipoUsuario.TabIndex = 18
      Me.lblTipoUsuario.Text = "Tipo de Usuario"
      '
      'UsuariosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(506, 403)
      Me.Controls.Add(Me.cmbTipoUsuario)
      Me.Controls.Add(Me.lblTipoUsuario)
      Me.Controls.Add(Me.grbCorreoElectronico)
      Me.Controls.Add(Me.txtCorreoElectronico)
      Me.Controls.Add(Me.dtpFechaUltimaModContraseña)
      Me.Controls.Add(Me.lblFechaIngreso)
      Me.Controls.Add(Me.lblCorreoElectronico)
      Me.Controls.Add(Me.chbActivo)
      Me.Controls.Add(Me.lblClave)
      Me.Controls.Add(Me.txtClave)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblNivelAutorizacion)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtNivelAutorizacion)
      Me.Controls.Add(Me.txtId)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "UsuariosDetalle"
      Me.Text = "Usuario"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.txtNivelAutorizacion, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.lblNivelAutorizacion, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtClave, 0)
      Me.Controls.SetChildIndex(Me.lblClave, 0)
      Me.Controls.SetChildIndex(Me.chbActivo, 0)
      Me.Controls.SetChildIndex(Me.lblCorreoElectronico, 0)
      Me.Controls.SetChildIndex(Me.lblFechaIngreso, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaUltimaModContraseña, 0)
      Me.Controls.SetChildIndex(Me.txtCorreoElectronico, 0)
      Me.Controls.SetChildIndex(Me.grbCorreoElectronico, 0)
      Me.Controls.SetChildIndex(Me.lblTipoUsuario, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoUsuario, 0)
      Me.grbCorreoElectronico.ResumeLayout(False)
      Me.grbCorreoElectronico.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblClave As Eniac.Controles.Label
   Friend WithEvents txtClave As Eniac.Controles.TextBox
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaUltimaModContraseña As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaIngreso As Eniac.Controles.Label
   Friend WithEvents txtCorreoElectronico As Eniac.Controles.TextBox
   Friend WithEvents lblCorreoElectronico As Eniac.Controles.Label
   Friend WithEvents grbCorreoElectronico As System.Windows.Forms.GroupBox
   Friend WithEvents chbUtilizaComoPredeterminado As Eniac.Controles.CheckBox
   Friend WithEvents lblCantidadMailsPorHora As Eniac.Controles.Label
   Friend WithEvents lblCantidadMailsPorMinuto As Eniac.Controles.Label
   Friend WithEvents txtCantidadMailsPorHora As Eniac.Controles.TextBox
   Friend WithEvents txtCantidadMailsPorMinuto As Eniac.Controles.TextBox
   Friend WithEvents chbMailRequiereSSL As Eniac.Controles.CheckBox
   Friend WithEvents chbMailRequiereAutenticacion As Eniac.Controles.CheckBox
   Friend WithEvents txtMailPuertoSalida As Eniac.Controles.TextBox
   Friend WithEvents lblMailServidor As Eniac.Controles.Label
   Friend WithEvents txtMailDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblMailDireccion As Eniac.Controles.Label
   Friend WithEvents txtMailPassword As Eniac.Controles.TextBox
   Friend WithEvents lblMailPassword As Eniac.Controles.Label
   Friend WithEvents txtMailUsuario As Eniac.Controles.TextBox
   Friend WithEvents lblMailUsuario As Eniac.Controles.Label
   Friend WithEvents txtMailServidor As Eniac.Controles.TextBox
   Friend WithEvents txtNivelAutorizacion As Eniac.Controles.TextBox
   Friend WithEvents lblNivelAutorizacion As Eniac.Controles.Label
   Friend WithEvents cmbTipoUsuario As Controles.ComboBox
   Friend WithEvents lblTipoUsuario As Controles.Label
End Class
