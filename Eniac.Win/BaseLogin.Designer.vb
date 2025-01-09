<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BaseLogin
    Inherits BaseForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseLogin))
        Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkCambiarContra = New Eniac.Controles.LinkLabel()
        Me.cmbSucursales = New Eniac.Controles.ComboBox()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.txtPwd = New Eniac.Controles.TextBox()
        Me.lblContrasena = New Eniac.Controles.Label()
        Me.txtUsuario = New Eniac.Controles.TextBox()
        Me.lblUsuario = New Eniac.Controles.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lnkCambiarBase = New Eniac.Controles.LinkLabel()
        Me.lnkActualizaSistema = New Eniac.Controles.LinkLabel()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.lblVersion = New Eniac.Controles.Label()
        Me.lblVersionBD = New Eniac.Controles.Label()
        Me.txtPaginaWeb = New System.Windows.Forms.LinkLabel()
        Me.txtCorreoElectronico = New System.Windows.Forms.LinkLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFijoSoporte = New System.Windows.Forms.Label()
        Me.lblFijoSoporte1 = New System.Windows.Forms.Label()
        Me.lblTelefonosCelulares = New System.Windows.Forms.Label()
        Me.lblCelularSoporte = New System.Windows.Forms.Label()
        Me.lblCelularAdministracion1 = New System.Windows.Forms.Label()
        Me.lblPaginaWeb = New System.Windows.Forms.Label()
        Me.lblCorreoSoporte = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCelularSoporte1 = New System.Windows.Forms.Label()
        Me.lblTelefonosFijos = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblCaducidad = New Eniac.Controles.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.picVersion = New System.Windows.Forms.PictureBox()
        Me.pnlSinergiaGestion = New System.Windows.Forms.Panel()
        Me.pnlSinergiaPedidos = New System.Windows.Forms.Panel()
        Me.pnlSinergiaCobranza = New System.Windows.Forms.Panel()
        Me.pnlSinergiaSoporte = New System.Windows.Forms.Panel()
        Me.pnlSinergiaSoftware = New System.Windows.Forms.Panel()
        Me.pnlGooglePlayStore = New System.Windows.Forms.Panel()
        Me.pnlAppleAppStore = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerMultiClick = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgIconos
        '
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIconos.Images.SetKeyName(0, "check2.ico")
        Me.imgIconos.Images.SetKeyName(1, "delete2.ico")
        Me.imgIconos.Images.SetKeyName(2, "gear_run.ico")
        '
        'lnkCambiarContra
        '
        Me.lnkCambiarContra.ActiveLinkColor = System.Drawing.Color.Blue
        Me.lnkCambiarContra.AutoSize = True
        Me.lnkCambiarContra.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkCambiarContra.Location = New System.Drawing.Point(166, 174)
        Me.lnkCambiarContra.Name = "lnkCambiarContra"
        Me.lnkCambiarContra.Size = New System.Drawing.Size(88, 12)
        Me.lnkCambiarContra.TabIndex = 11
        Me.lnkCambiarContra.TabStop = True
        Me.lnkCambiarContra.Text = "Ca&mbiar contraseña"
        '
        'cmbSucursales
        '
        Me.cmbSucursales.BindearPropiedadControl = Nothing
        Me.cmbSucursales.BindearPropiedadEntidad = Nothing
        Me.cmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.IsPK = False
        Me.cmbSucursales.IsRequired = False
        Me.cmbSucursales.Key = Nothing
        Me.cmbSucursales.LabelAsoc = Nothing
        Me.cmbSucursales.Location = New System.Drawing.Point(96, 99)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.Size = New System.Drawing.Size(124, 21)
        Me.cmbSucursales.TabIndex = 5
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(30, 103)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 4
        Me.lblSucursal.Text = "&Sucursal"
        '
        'txtPwd
        '
        Me.txtPwd.BindearPropiedadControl = Nothing
        Me.txtPwd.BindearPropiedadEntidad = Nothing
        Me.txtPwd.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPwd.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPwd.Formato = ""
        Me.txtPwd.IsDecimal = False
        Me.txtPwd.IsNumber = False
        Me.txtPwd.IsPK = False
        Me.txtPwd.IsRequired = False
        Me.txtPwd.Key = ""
        Me.txtPwd.LabelAsoc = Me.lblContrasena
        Me.txtPwd.Location = New System.Drawing.Point(96, 62)
        Me.txtPwd.MaxLength = 15
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(100, 20)
        Me.txtPwd.TabIndex = 3
        '
        'lblContrasena
        '
        Me.lblContrasena.AutoSize = True
        Me.lblContrasena.LabelAsoc = Nothing
        Me.lblContrasena.Location = New System.Drawing.Point(30, 66)
        Me.lblContrasena.Name = "lblContrasena"
        Me.lblContrasena.Size = New System.Drawing.Size(61, 13)
        Me.lblContrasena.TabIndex = 2
        Me.lblContrasena.Text = "&Contraseña"
        '
        'txtUsuario
        '
        Me.txtUsuario.BindearPropiedadControl = Nothing
        Me.txtUsuario.BindearPropiedadEntidad = Nothing
        Me.txtUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUsuario.Formato = ""
        Me.txtUsuario.IsDecimal = False
        Me.txtUsuario.IsNumber = False
        Me.txtUsuario.IsPK = False
        Me.txtUsuario.IsRequired = False
        Me.txtUsuario.Key = ""
        Me.txtUsuario.LabelAsoc = Me.lblUsuario
        Me.txtUsuario.Location = New System.Drawing.Point(96, 26)
        Me.txtUsuario.MaxLength = 15
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuario.TabIndex = 1
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.LabelAsoc = Nothing
        Me.lblUsuario.Location = New System.Drawing.Point(30, 30)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "&Usuario"
        '
        'btnLogin
        '
        Me.btnLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogin.ImageKey = "check2.ico"
        Me.btnLogin.ImageList = Me.imgIconos
        Me.btnLogin.Location = New System.Drawing.Point(42, 133)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(80, 30)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "&Login"
        Me.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.ImageKey = "delete2.ico"
        Me.btnSalir.ImageList = Me.imgIconos
        Me.btnSalir.Location = New System.Drawing.Point(133, 133)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 30)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pictureBox2
        '
        Me.pictureBox2.Image = Global.Eniac.Win.My.Resources.Resources.keys
        Me.pictureBox2.Location = New System.Drawing.Point(200, 62)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(22, 22)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox2.TabIndex = 15
        Me.pictureBox2.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.Eniac.Win.My.Resources.Resources.user1
        Me.pictureBox1.Location = New System.Drawing.Point(200, 24)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(22, 22)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 14
        Me.pictureBox1.TabStop = False
        '
        'lnkCambiarBase
        '
        Me.lnkCambiarBase.ActiveLinkColor = System.Drawing.Color.Blue
        Me.lnkCambiarBase.AutoSize = True
        Me.lnkCambiarBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkCambiarBase.Location = New System.Drawing.Point(1, 174)
        Me.lnkCambiarBase.Name = "lnkCambiarBase"
        Me.lnkCambiarBase.Size = New System.Drawing.Size(26, 12)
        Me.lnkCambiarBase.TabIndex = 9
        Me.lnkCambiarBase.TabStop = True
        Me.lnkCambiarBase.Text = "&Base"
        Me.lnkCambiarBase.Visible = False
        '
        'lnkActualizaSistema
        '
        Me.lnkActualizaSistema.ActiveLinkColor = System.Drawing.Color.Blue
        Me.lnkActualizaSistema.AutoSize = True
        Me.lnkActualizaSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkActualizaSistema.LinkColor = System.Drawing.Color.Red
        Me.lnkActualizaSistema.Location = New System.Drawing.Point(45, 174)
        Me.lnkActualizaSistema.Name = "lnkActualizaSistema"
        Me.lnkActualizaSistema.Size = New System.Drawing.Size(111, 13)
        Me.lnkActualizaSistema.TabIndex = 10
        Me.lnkActualizaSistema.TabStop = True
        Me.lnkActualizaSistema.Text = "Ac&tualizar Sistema"
        Me.lnkActualizaSistema.Visible = False
        '
        'btnConfig
        '
        Me.btnConfig.ImageKey = "gear_run.ico"
        Me.btnConfig.ImageList = Me.imgIconos
        Me.btnConfig.Location = New System.Drawing.Point(219, 133)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(30, 30)
        Me.btnConfig.TabIndex = 8
        Me.btnConfig.TabStop = False
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Blue
        Me.lblVersion.LabelAsoc = Nothing
        Me.lblVersion.Location = New System.Drawing.Point(198, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(60, 12)
        Me.lblVersion.TabIndex = 12
        Me.lblVersion.TabStop = True
        Me.lblVersion.Text = "v"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersionBD
        '
        Me.lblVersionBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersionBD.ForeColor = System.Drawing.Color.Blue
        Me.lblVersionBD.LabelAsoc = Nothing
        Me.lblVersionBD.Location = New System.Drawing.Point(198, 10)
        Me.lblVersionBD.Name = "lblVersionBD"
        Me.lblVersionBD.Size = New System.Drawing.Size(60, 12)
        Me.lblVersionBD.TabIndex = 13
        Me.lblVersionBD.TabStop = True
        Me.lblVersionBD.Text = "v"
        Me.lblVersionBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblVersionBD.Visible = False
        '
        'txtPaginaWeb
        '
        Me.txtPaginaWeb.AutoSize = True
        Me.txtPaginaWeb.Location = New System.Drawing.Point(102, 116)
        Me.txtPaginaWeb.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.txtPaginaWeb.MaximumSize = New System.Drawing.Size(0, 17)
        Me.txtPaginaWeb.Name = "txtPaginaWeb"
        Me.txtPaginaWeb.Size = New System.Drawing.Size(145, 13)
        Me.txtPaginaWeb.TabIndex = 18
        Me.txtPaginaWeb.TabStop = True
        Me.txtPaginaWeb.Text = "www.sinergiasoftware.com.ar"
        '
        'txtCorreoElectronico
        '
        Me.txtCorreoElectronico.AutoSize = True
        Me.txtCorreoElectronico.Location = New System.Drawing.Point(102, 132)
        Me.txtCorreoElectronico.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.txtCorreoElectronico.MaximumSize = New System.Drawing.Size(0, 17)
        Me.txtCorreoElectronico.Name = "txtCorreoElectronico"
        Me.txtCorreoElectronico.Size = New System.Drawing.Size(144, 17)
        Me.txtCorreoElectronico.TabIndex = 19
        Me.txtCorreoElectronico.TabStop = True
        Me.txtCorreoElectronico.Text = "soporte@sinergiasoftware.com.ar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AllowDrop = True
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblFijoSoporte, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFijoSoporte1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTelefonosCelulares, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCelularSoporte, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCelularAdministracion1, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPaginaWeb, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPaginaWeb, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCorreoSoporte, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCorreoElectronico, 2, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCelularSoporte1, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTelefonosFijos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDomicilio, 0, 7)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(423, 204)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 11
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(271, 189)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblFijoSoporte
        '
        Me.lblFijoSoporte.AutoSize = True
        Me.lblFijoSoporte.Location = New System.Drawing.Point(13, 13)
        Me.lblFijoSoporte.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblFijoSoporte.MaximumSize = New System.Drawing.Size(0, 17)
        Me.lblFijoSoporte.Name = "lblFijoSoporte"
        Me.lblFijoSoporte.Size = New System.Drawing.Size(44, 13)
        Me.lblFijoSoporte.TabIndex = 24
        Me.lblFijoSoporte.Text = "Soporte"
        '
        'lblFijoSoporte1
        '
        Me.lblFijoSoporte1.AutoSize = True
        Me.lblFijoSoporte1.Location = New System.Drawing.Point(102, 13)
        Me.lblFijoSoporte1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblFijoSoporte1.Name = "lblFijoSoporte1"
        Me.lblFijoSoporte1.Size = New System.Drawing.Size(85, 13)
        Me.lblFijoSoporte1.TabIndex = 25
        Me.lblFijoSoporte1.Text = "(0341) 430-0770"
        '
        'lblTelefonosCelulares
        '
        Me.lblTelefonosCelulares.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTelefonosCelulares, 3)
        Me.lblTelefonosCelulares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonosCelulares.Location = New System.Drawing.Point(3, 29)
        Me.lblTelefonosCelulares.MaximumSize = New System.Drawing.Size(0, 17)
        Me.lblTelefonosCelulares.Name = "lblTelefonosCelulares"
        Me.lblTelefonosCelulares.Size = New System.Drawing.Size(119, 13)
        Me.lblTelefonosCelulares.TabIndex = 0
        Me.lblTelefonosCelulares.Text = "Teléfonos Celulares"
        '
        'lblCelularSoporte
        '
        Me.lblCelularSoporte.AutoSize = True
        Me.lblCelularSoporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelularSoporte.Location = New System.Drawing.Point(13, 42)
        Me.lblCelularSoporte.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblCelularSoporte.MaximumSize = New System.Drawing.Size(0, 17)
        Me.lblCelularSoporte.Name = "lblCelularSoporte"
        Me.lblCelularSoporte.Size = New System.Drawing.Size(44, 13)
        Me.lblCelularSoporte.TabIndex = 26
        Me.lblCelularSoporte.Text = "Soporte"
        '
        'lblCelularAdministracion1
        '
        Me.lblCelularAdministracion1.AutoSize = True
        Me.lblCelularAdministracion1.Location = New System.Drawing.Point(102, 58)
        Me.lblCelularAdministracion1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblCelularAdministracion1.Name = "lblCelularAdministracion1"
        Me.lblCelularAdministracion1.Size = New System.Drawing.Size(100, 13)
        Me.lblCelularAdministracion1.TabIndex = 30
        Me.lblCelularAdministracion1.Text = "(0341) 15 257-0900"
        '
        'lblPaginaWeb
        '
        Me.lblPaginaWeb.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblPaginaWeb, 2)
        Me.lblPaginaWeb.Location = New System.Drawing.Point(3, 116)
        Me.lblPaginaWeb.Name = "lblPaginaWeb"
        Me.lblPaginaWeb.Size = New System.Drawing.Size(63, 13)
        Me.lblPaginaWeb.TabIndex = 31
        Me.lblPaginaWeb.Text = "Página web"
        '
        'lblCorreoSoporte
        '
        Me.lblCorreoSoporte.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblCorreoSoporte, 2)
        Me.lblCorreoSoporte.Location = New System.Drawing.Point(3, 132)
        Me.lblCorreoSoporte.Name = "lblCorreoSoporte"
        Me.lblCorreoSoporte.Size = New System.Drawing.Size(78, 13)
        Me.lblCorreoSoporte.TabIndex = 32
        Me.lblCorreoSoporte.Text = "Correo Soporte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(102, 74)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "(0341) 15 576-7535"
        '
        'lblCelularSoporte1
        '
        Me.lblCelularSoporte1.AutoSize = True
        Me.lblCelularSoporte1.Location = New System.Drawing.Point(102, 42)
        Me.lblCelularSoporte1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblCelularSoporte1.Name = "lblCelularSoporte1"
        Me.lblCelularSoporte1.Size = New System.Drawing.Size(100, 13)
        Me.lblCelularSoporte1.TabIndex = 27
        Me.lblCelularSoporte1.Text = "(0341) 15 255-5815"
        '
        'lblTelefonosFijos
        '
        Me.lblTelefonosFijos.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTelefonosFijos, 2)
        Me.lblTelefonosFijos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonosFijos.Location = New System.Drawing.Point(3, 0)
        Me.lblTelefonosFijos.MaximumSize = New System.Drawing.Size(0, 17)
        Me.lblTelefonosFijos.Name = "lblTelefonosFijos"
        Me.lblTelefonosFijos.Size = New System.Drawing.Size(93, 13)
        Me.lblTelefonosFijos.TabIndex = 1
        Me.lblTelefonosFijos.Text = "Teléfonos Fijos"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDomicilio, 3)
        Me.txtDomicilio.Location = New System.Drawing.Point(3, 100)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.txtDomicilio.MaximumSize = New System.Drawing.Size(0, 17)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(176, 13)
        Me.txtDomicilio.TabIndex = 20
        Me.txtDomicilio.Text = "Alsina 1070 P.B., Rosario, Santa Fe"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'lblCaducidad
        '
        Me.lblCaducidad.AutoSize = True
        Me.lblCaducidad.LabelAsoc = Nothing
        Me.lblCaducidad.Location = New System.Drawing.Point(-3, -1)
        Me.lblCaducidad.Name = "lblCaducidad"
        Me.lblCaducidad.Size = New System.Drawing.Size(0, 13)
        Me.lblCaducidad.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.picVersion)
        Me.Panel2.Controls.Add(Me.lblVersion)
        Me.Panel2.Controls.Add(Me.lblUsuario)
        Me.Panel2.Controls.Add(Me.lblCaducidad)
        Me.Panel2.Controls.Add(Me.lblContrasena)
        Me.Panel2.Controls.Add(Me.txtUsuario)
        Me.Panel2.Controls.Add(Me.lblVersionBD)
        Me.Panel2.Controls.Add(Me.txtPwd)
        Me.Panel2.Controls.Add(Me.btnConfig)
        Me.Panel2.Controls.Add(Me.btnLogin)
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.lnkActualizaSistema)
        Me.Panel2.Controls.Add(Me.pictureBox1)
        Me.Panel2.Controls.Add(Me.lnkCambiarBase)
        Me.Panel2.Controls.Add(Me.pictureBox2)
        Me.Panel2.Controls.Add(Me.lnkCambiarContra)
        Me.Panel2.Controls.Add(Me.lblSucursal)
        Me.Panel2.Controls.Add(Me.cmbSucursales)
        Me.Panel2.Location = New System.Drawing.Point(420, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 198)
        Me.Panel2.TabIndex = 0
        '
        'picVersion
        '
        Me.picVersion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picVersion.Image = Global.Eniac.Win.My.Resources.Resources.info_32
        Me.picVersion.Location = New System.Drawing.Point(7, 133)
        Me.picVersion.Name = "picVersion"
        Me.picVersion.Size = New System.Drawing.Size(32, 32)
        Me.picVersion.TabIndex = 16
        Me.picVersion.TabStop = False
        Me.picVersion.Visible = False
        '
        'pnlSinergiaGestion
        '
        Me.pnlSinergiaGestion.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinergiaGestion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlSinergiaGestion.Location = New System.Drawing.Point(12, 146)
        Me.pnlSinergiaGestion.Name = "pnlSinergiaGestion"
        Me.pnlSinergiaGestion.Size = New System.Drawing.Size(406, 42)
        Me.pnlSinergiaGestion.TabIndex = 2
        '
        'pnlSinergiaPedidos
        '
        Me.pnlSinergiaPedidos.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinergiaPedidos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlSinergiaPedidos.Location = New System.Drawing.Point(12, 202)
        Me.pnlSinergiaPedidos.Name = "pnlSinergiaPedidos"
        Me.pnlSinergiaPedidos.Size = New System.Drawing.Size(406, 42)
        Me.pnlSinergiaPedidos.TabIndex = 3
        '
        'pnlSinergiaCobranza
        '
        Me.pnlSinergiaCobranza.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinergiaCobranza.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlSinergiaCobranza.Location = New System.Drawing.Point(12, 255)
        Me.pnlSinergiaCobranza.Name = "pnlSinergiaCobranza"
        Me.pnlSinergiaCobranza.Size = New System.Drawing.Size(406, 42)
        Me.pnlSinergiaCobranza.TabIndex = 4
        '
        'pnlSinergiaSoporte
        '
        Me.pnlSinergiaSoporte.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinergiaSoporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlSinergiaSoporte.Location = New System.Drawing.Point(12, 310)
        Me.pnlSinergiaSoporte.Name = "pnlSinergiaSoporte"
        Me.pnlSinergiaSoporte.Size = New System.Drawing.Size(406, 42)
        Me.pnlSinergiaSoporte.TabIndex = 5
        '
        'pnlSinergiaSoftware
        '
        Me.pnlSinergiaSoftware.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinergiaSoftware.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlSinergiaSoftware.Location = New System.Drawing.Point(80, 9)
        Me.pnlSinergiaSoftware.Name = "pnlSinergiaSoftware"
        Me.pnlSinergiaSoftware.Size = New System.Drawing.Size(250, 74)
        Me.pnlSinergiaSoftware.TabIndex = 6
        '
        'pnlGooglePlayStore
        '
        Me.pnlGooglePlayStore.BackColor = System.Drawing.Color.Transparent
        Me.pnlGooglePlayStore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlGooglePlayStore.Location = New System.Drawing.Point(21, 359)
        Me.pnlGooglePlayStore.Name = "pnlGooglePlayStore"
        Me.pnlGooglePlayStore.Size = New System.Drawing.Size(83, 28)
        Me.pnlGooglePlayStore.TabIndex = 7
        '
        'pnlAppleAppStore
        '
        Me.pnlAppleAppStore.BackColor = System.Drawing.Color.Transparent
        Me.pnlAppleAppStore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlAppleAppStore.Location = New System.Drawing.Point(107, 359)
        Me.pnlAppleAppStore.Name = "pnlAppleAppStore"
        Me.pnlAppleAppStore.Size = New System.Drawing.Size(92, 28)
        Me.pnlAppleAppStore.TabIndex = 8
        '
        'TimerMultiClick
        '
        Me.TimerMultiClick.Interval = 1000
        '
        'BaseLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.Login
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(697, 397)
        Me.Controls.Add(Me.pnlAppleAppStore)
        Me.Controls.Add(Me.pnlGooglePlayStore)
        Me.Controls.Add(Me.pnlSinergiaSoftware)
        Me.Controls.Add(Me.pnlSinergiaSoporte)
        Me.Controls.Add(Me.pnlSinergiaCobranza)
        Me.Controls.Add(Me.pnlSinergiaPedidos)
        Me.Controls.Add(Me.pnlSinergiaGestion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BaseLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents txtPwd As Eniac.Controles.TextBox
    Public WithEvents txtUsuario As Eniac.Controles.TextBox
    Public WithEvents imgIconos As System.Windows.Forms.ImageList
    Public WithEvents pictureBox2 As System.Windows.Forms.PictureBox
    Public WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents btnSalir As System.Windows.Forms.Button
    Public WithEvents btnLogin As System.Windows.Forms.Button
    Public WithEvents lblContrasena As Eniac.Controles.Label
    Public WithEvents lblUsuario As Eniac.Controles.Label
    Public WithEvents lnkCambiarContra As Eniac.Controles.LinkLabel
    Public WithEvents lblSucursal As Eniac.Controles.Label
    Public WithEvents cmbSucursales As Eniac.Controles.ComboBox
    Public WithEvents lnkCambiarBase As Eniac.Controles.LinkLabel
    Public WithEvents lnkActualizaSistema As Eniac.Controles.LinkLabel
    Public WithEvents btnConfig As System.Windows.Forms.Button
    Public WithEvents lblVersion As Eniac.Controles.Label
    Public WithEvents lblVersionBD As Eniac.Controles.Label
    Public WithEvents txtPaginaWeb As System.Windows.Forms.LinkLabel
    Public WithEvents txtCorreoElectronico As System.Windows.Forms.LinkLabel
    Public WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents lblTelefonosFijos As System.Windows.Forms.Label
    Public WithEvents lblFijoSoporte As System.Windows.Forms.Label
    Public WithEvents lblFijoSoporte1 As System.Windows.Forms.Label
    Public WithEvents lblTelefonosCelulares As System.Windows.Forms.Label
    Public WithEvents lblCelularSoporte As System.Windows.Forms.Label
    Public WithEvents txtDomicilio As System.Windows.Forms.Label
    Public WithEvents lblCelularAdministracion1 As System.Windows.Forms.Label
    Public WithEvents lblPaginaWeb As System.Windows.Forms.Label
    Public WithEvents lblCorreoSoporte As System.Windows.Forms.Label
    Public WithEvents lblCelularSoporte1 As System.Windows.Forms.Label
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents lblCaducidad As Eniac.Controles.Label
    Public WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents pnlSinergiaGestion As System.Windows.Forms.Panel
    Public WithEvents pnlSinergiaPedidos As System.Windows.Forms.Panel
    Public WithEvents pnlSinergiaCobranza As System.Windows.Forms.Panel
    Public WithEvents pnlSinergiaSoporte As System.Windows.Forms.Panel
    Public WithEvents pnlSinergiaSoftware As System.Windows.Forms.Panel
    Public WithEvents pnlGooglePlayStore As System.Windows.Forms.Panel
    Public WithEvents pnlAppleAppStore As System.Windows.Forms.Panel
    Friend WithEvents picVersion As PictureBox
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Public WithEvents TimerMultiClick As Timer
End Class
