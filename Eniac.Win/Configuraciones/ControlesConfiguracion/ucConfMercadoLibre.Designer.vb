<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfMercadoLibre
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
        Me.lblCajasML = New Eniac.Controles.Label()
        Me.cmbCajasML = New Eniac.Controles.ComboBox()
        Me.txtCategoriaDefaultML = New Eniac.Controles.TextBox()
        Me.lblCategoriaDefaultML = New Eniac.Controles.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtCodigoClientSecretML = New Eniac.Controles.TextBox()
        Me.lblCodigoClientSecretML = New Eniac.Controles.Label()
        Me.txtCodigoAplicationIDML = New Eniac.Controles.TextBox()
        Me.lblCodigoAplicationIDML = New Eniac.Controles.Label()
        Me.txtCodigoResellerML = New Eniac.Controles.TextBox()
        Me.lblCodigoResellerML = New Eniac.Controles.Label()
        Me.txtFechaRefreshTokenML = New Eniac.Controles.TextBox()
        Me.lblFechaRefreshTokenML = New Eniac.Controles.Label()
        Me.lblCodigoRefreshTokenML = New Eniac.Controles.Label()
        Me.txtCodigoImagenDefaultML = New Eniac.Controles.TextBox()
        Me.lblCodigoImagenDefaultML = New Eniac.Controles.Label()
        Me.txtCodigoRefreshTokenML = New Eniac.Controles.TextBox()
        Me.txtMercadoLibreToken = New Eniac.Controles.TextBox()
        Me.lblMercadoLibreToken = New Eniac.Controles.Label()
        Me.lblMercadoLibreURLBase = New Eniac.Controles.Label()
        Me.txtMercadoLibreCorreoNotificaciones = New Eniac.Controles.TextBox()
        Me.lblMercadoLibreCorreoNotificaciones = New Eniac.Controles.Label()
        Me.gbPedidosMercadoLibre = New System.Windows.Forms.GroupBox()
        Me.lblMercadoLibreIdProductoEnvio = New Eniac.Controles.Label()
        Me.txtMercadoLibreIdProductoEnvio = New Eniac.Controles.TextBox()
        Me.lblMercadoLibrePedidosFormaDePago = New Eniac.Controles.Label()
        Me.cmbMercadoLibrePedidosFormaDePago = New Eniac.Controles.ComboBox()
        Me.lblMercadoLibrePedidosCriticidad = New Eniac.Controles.Label()
        Me.cmbMercadoLibrePedidosCriticidad = New Eniac.Controles.ComboBox()
        Me.cmbMercadoLibrePedidosTipoComprobante = New Eniac.Controles.ComboBox()
        Me.lblMercadoLibrePedidosTipoComprobante = New Eniac.Controles.Label()
        Me.cmbMercadoLibreVendedor = New Eniac.Controles.ComboBox()
        Me.cmbMercadoLibreCategoriaFiscalCliente = New Eniac.Controles.ComboBox()
        Me.cmbMercadoLibreCategoriaCliente = New Eniac.Controles.ComboBox()
        Me.cmbMercadoLibreListaPrecios = New Eniac.Controles.ComboBox()
        Me.lblMercadoLibreVendedor = New Eniac.Controles.Label()
        Me.lblMercadoLibreCategoriaFiscalCliente = New Eniac.Controles.Label()
        Me.lblMercadoLibreCategoriaCliente = New Eniac.Controles.Label()
        Me.txtMercadoLibreURLBase = New Eniac.Controles.TextBox()
        Me.lblMercadoLibreListaPrecios = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chbProductoPrecioEmbalaje = New Eniac.Controles.CheckBox()
        Me.gbPedidosMercadoLibre.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCajasML
        '
        Me.lblCajasML.AutoSize = True
        Me.lblCajasML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajasML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCajasML.LabelAsoc = Nothing
        Me.lblCajasML.Location = New System.Drawing.Point(3, 205)
        Me.lblCajasML.Name = "lblCajasML"
        Me.lblCajasML.Size = New System.Drawing.Size(78, 13)
        Me.lblCajasML.TabIndex = 89
        Me.lblCajasML.Text = "Caja Asignada:"
        '
        'cmbCajasML
        '
        Me.cmbCajasML.BindearPropiedadControl = Nothing
        Me.cmbCajasML.BindearPropiedadEntidad = Nothing
        Me.cmbCajasML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajasML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajasML.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajasML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajasML.FormattingEnabled = True
        Me.cmbCajasML.IsPK = False
        Me.cmbCajasML.IsRequired = False
        Me.cmbCajasML.Key = Nothing
        Me.cmbCajasML.LabelAsoc = Nothing
        Me.cmbCajasML.Location = New System.Drawing.Point(131, 202)
        Me.cmbCajasML.Name = "cmbCajasML"
        Me.cmbCajasML.Size = New System.Drawing.Size(146, 21)
        Me.cmbCajasML.TabIndex = 90
        Me.cmbCajasML.Tag = ""
        '
        'txtCategoriaDefaultML
        '
        Me.txtCategoriaDefaultML.BindearPropiedadControl = Nothing
        Me.txtCategoriaDefaultML.BindearPropiedadEntidad = Nothing
        Me.txtCategoriaDefaultML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoriaDefaultML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCategoriaDefaultML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCategoriaDefaultML.Formato = ""
        Me.txtCategoriaDefaultML.IsDecimal = False
        Me.txtCategoriaDefaultML.IsNumber = False
        Me.txtCategoriaDefaultML.IsPK = False
        Me.txtCategoriaDefaultML.IsRequired = False
        Me.txtCategoriaDefaultML.Key = ""
        Me.txtCategoriaDefaultML.LabelAsoc = Me.lblCategoriaDefaultML
        Me.txtCategoriaDefaultML.Location = New System.Drawing.Point(777, 64)
        Me.txtCategoriaDefaultML.MaxLength = 200
        Me.txtCategoriaDefaultML.Name = "txtCategoriaDefaultML"
        Me.txtCategoriaDefaultML.Size = New System.Drawing.Size(121, 20)
        Me.txtCategoriaDefaultML.TabIndex = 88
        Me.txtCategoriaDefaultML.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCategoriaDefaultML
        '
        Me.lblCategoriaDefaultML.AutoSize = True
        Me.lblCategoriaDefaultML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDefaultML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCategoriaDefaultML.LabelAsoc = Nothing
        Me.lblCategoriaDefaultML.Location = New System.Drawing.Point(658, 67)
        Me.lblCategoriaDefaultML.Name = "lblCategoriaDefaultML"
        Me.lblCategoriaDefaultML.Size = New System.Drawing.Size(114, 13)
        Me.lblCategoriaDefaultML.TabIndex = 87
        Me.lblCategoriaDefaultML.Text = "Cod. Categoria Default"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(338, 63)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 22)
        Me.Button2.TabIndex = 86
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtCodigoClientSecretML
        '
        Me.txtCodigoClientSecretML.BindearPropiedadControl = Nothing
        Me.txtCodigoClientSecretML.BindearPropiedadEntidad = Nothing
        Me.txtCodigoClientSecretML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoClientSecretML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoClientSecretML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoClientSecretML.Formato = ""
        Me.txtCodigoClientSecretML.IsDecimal = False
        Me.txtCodigoClientSecretML.IsNumber = False
        Me.txtCodigoClientSecretML.IsPK = False
        Me.txtCodigoClientSecretML.IsRequired = False
        Me.txtCodigoClientSecretML.Key = ""
        Me.txtCodigoClientSecretML.LabelAsoc = Me.lblCodigoClientSecretML
        Me.txtCodigoClientSecretML.Location = New System.Drawing.Point(689, 94)
        Me.txtCodigoClientSecretML.MaxLength = 200
        Me.txtCodigoClientSecretML.Name = "txtCodigoClientSecretML"
        Me.txtCodigoClientSecretML.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCodigoClientSecretML.ReadOnly = True
        Me.txtCodigoClientSecretML.Size = New System.Drawing.Size(209, 20)
        Me.txtCodigoClientSecretML.TabIndex = 85
        Me.txtCodigoClientSecretML.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCodigoClientSecretML
        '
        Me.lblCodigoClientSecretML.AutoSize = True
        Me.lblCodigoClientSecretML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoClientSecretML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoClientSecretML.LabelAsoc = Nothing
        Me.lblCodigoClientSecretML.Location = New System.Drawing.Point(616, 97)
        Me.lblCodigoClientSecretML.Name = "lblCodigoClientSecretML"
        Me.lblCodigoClientSecretML.Size = New System.Drawing.Size(67, 13)
        Me.lblCodigoClientSecretML.TabIndex = 84
        Me.lblCodigoClientSecretML.Text = "Client Secret"
        '
        'txtCodigoAplicationIDML
        '
        Me.txtCodigoAplicationIDML.BindearPropiedadControl = Nothing
        Me.txtCodigoAplicationIDML.BindearPropiedadEntidad = Nothing
        Me.txtCodigoAplicationIDML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoAplicationIDML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoAplicationIDML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoAplicationIDML.Formato = ""
        Me.txtCodigoAplicationIDML.IsDecimal = False
        Me.txtCodigoAplicationIDML.IsNumber = False
        Me.txtCodigoAplicationIDML.IsPK = False
        Me.txtCodigoAplicationIDML.IsRequired = False
        Me.txtCodigoAplicationIDML.Key = ""
        Me.txtCodigoAplicationIDML.LabelAsoc = Me.lblCodigoAplicationIDML
        Me.txtCodigoAplicationIDML.Location = New System.Drawing.Point(461, 94)
        Me.txtCodigoAplicationIDML.MaxLength = 200
        Me.txtCodigoAplicationIDML.Name = "txtCodigoAplicationIDML"
        Me.txtCodigoAplicationIDML.ReadOnly = True
        Me.txtCodigoAplicationIDML.Size = New System.Drawing.Size(149, 20)
        Me.txtCodigoAplicationIDML.TabIndex = 83
        Me.txtCodigoAplicationIDML.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCodigoAplicationIDML
        '
        Me.lblCodigoAplicationIDML.AutoSize = True
        Me.lblCodigoAplicationIDML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoAplicationIDML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoAplicationIDML.LabelAsoc = Nothing
        Me.lblCodigoAplicationIDML.Location = New System.Drawing.Point(383, 97)
        Me.lblCodigoAplicationIDML.Name = "lblCodigoAplicationIDML"
        Me.lblCodigoAplicationIDML.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoAplicationIDML.TabIndex = 82
        Me.lblCodigoAplicationIDML.Text = "App ID"
        '
        'txtCodigoResellerML
        '
        Me.txtCodigoResellerML.BindearPropiedadControl = Nothing
        Me.txtCodigoResellerML.BindearPropiedadEntidad = Nothing
        Me.txtCodigoResellerML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoResellerML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoResellerML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoResellerML.Formato = ""
        Me.txtCodigoResellerML.IsDecimal = False
        Me.txtCodigoResellerML.IsNumber = False
        Me.txtCodigoResellerML.IsPK = False
        Me.txtCodigoResellerML.IsRequired = False
        Me.txtCodigoResellerML.Key = ""
        Me.txtCodigoResellerML.LabelAsoc = Me.lblCodigoResellerML
        Me.txtCodigoResellerML.Location = New System.Drawing.Point(777, 37)
        Me.txtCodigoResellerML.MaxLength = 200
        Me.txtCodigoResellerML.Name = "txtCodigoResellerML"
        Me.txtCodigoResellerML.ReadOnly = True
        Me.txtCodigoResellerML.Size = New System.Drawing.Size(121, 20)
        Me.txtCodigoResellerML.TabIndex = 81
        Me.txtCodigoResellerML.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCodigoResellerML
        '
        Me.lblCodigoResellerML.AutoSize = True
        Me.lblCodigoResellerML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoResellerML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoResellerML.LabelAsoc = Nothing
        Me.lblCodigoResellerML.Location = New System.Drawing.Point(690, 40)
        Me.lblCodigoResellerML.Name = "lblCodigoResellerML"
        Me.lblCodigoResellerML.Size = New System.Drawing.Size(81, 13)
        Me.lblCodigoResellerML.TabIndex = 80
        Me.lblCodigoResellerML.Text = "Codigo Reseller"
        '
        'txtFechaRefreshTokenML
        '
        Me.txtFechaRefreshTokenML.BindearPropiedadControl = Nothing
        Me.txtFechaRefreshTokenML.BindearPropiedadEntidad = Nothing
        Me.txtFechaRefreshTokenML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaRefreshTokenML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaRefreshTokenML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaRefreshTokenML.Formato = ""
        Me.txtFechaRefreshTokenML.IsDecimal = False
        Me.txtFechaRefreshTokenML.IsNumber = False
        Me.txtFechaRefreshTokenML.IsPK = False
        Me.txtFechaRefreshTokenML.IsRequired = False
        Me.txtFechaRefreshTokenML.Key = ""
        Me.txtFechaRefreshTokenML.LabelAsoc = Me.lblFechaRefreshTokenML
        Me.txtFechaRefreshTokenML.Location = New System.Drawing.Point(511, 65)
        Me.txtFechaRefreshTokenML.MaxLength = 200
        Me.txtFechaRefreshTokenML.Name = "txtFechaRefreshTokenML"
        Me.txtFechaRefreshTokenML.ReadOnly = True
        Me.txtFechaRefreshTokenML.Size = New System.Drawing.Size(141, 20)
        Me.txtFechaRefreshTokenML.TabIndex = 79
        '
        'lblFechaRefreshTokenML
        '
        Me.lblFechaRefreshTokenML.AutoSize = True
        Me.lblFechaRefreshTokenML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaRefreshTokenML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaRefreshTokenML.LabelAsoc = Nothing
        Me.lblFechaRefreshTokenML.Location = New System.Drawing.Point(383, 68)
        Me.lblFechaRefreshTokenML.Name = "lblFechaRefreshTokenML"
        Me.lblFechaRefreshTokenML.Size = New System.Drawing.Size(111, 13)
        Me.lblFechaRefreshTokenML.TabIndex = 74
        Me.lblFechaRefreshTokenML.Text = "Fecha Refresh Token"
        '
        'lblCodigoRefreshTokenML
        '
        Me.lblCodigoRefreshTokenML.AutoSize = True
        Me.lblCodigoRefreshTokenML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoRefreshTokenML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoRefreshTokenML.LabelAsoc = Nothing
        Me.lblCodigoRefreshTokenML.Location = New System.Drawing.Point(383, 40)
        Me.lblCodigoRefreshTokenML.Name = "lblCodigoRefreshTokenML"
        Me.lblCodigoRefreshTokenML.Size = New System.Drawing.Size(114, 13)
        Me.lblCodigoRefreshTokenML.TabIndex = 78
        Me.lblCodigoRefreshTokenML.Text = "Codigo Refresh Token"
        '
        'txtCodigoImagenDefaultML
        '
        Me.txtCodigoImagenDefaultML.BindearPropiedadControl = Nothing
        Me.txtCodigoImagenDefaultML.BindearPropiedadEntidad = Nothing
        Me.txtCodigoImagenDefaultML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoImagenDefaultML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoImagenDefaultML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoImagenDefaultML.Formato = ""
        Me.txtCodigoImagenDefaultML.IsDecimal = False
        Me.txtCodigoImagenDefaultML.IsNumber = False
        Me.txtCodigoImagenDefaultML.IsPK = False
        Me.txtCodigoImagenDefaultML.IsRequired = False
        Me.txtCodigoImagenDefaultML.Key = ""
        Me.txtCodigoImagenDefaultML.LabelAsoc = Me.lblCodigoImagenDefaultML
        Me.txtCodigoImagenDefaultML.Location = New System.Drawing.Point(131, 64)
        Me.txtCodigoImagenDefaultML.MaxLength = 200
        Me.txtCodigoImagenDefaultML.Name = "txtCodigoImagenDefaultML"
        Me.txtCodigoImagenDefaultML.ReadOnly = True
        Me.txtCodigoImagenDefaultML.Size = New System.Drawing.Size(204, 20)
        Me.txtCodigoImagenDefaultML.TabIndex = 77
        '
        'lblCodigoImagenDefaultML
        '
        Me.lblCodigoImagenDefaultML.AutoSize = True
        Me.lblCodigoImagenDefaultML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoImagenDefaultML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoImagenDefaultML.LabelAsoc = Nothing
        Me.lblCodigoImagenDefaultML.Location = New System.Drawing.Point(3, 67)
        Me.lblCodigoImagenDefaultML.Name = "lblCodigoImagenDefaultML"
        Me.lblCodigoImagenDefaultML.Size = New System.Drawing.Size(115, 13)
        Me.lblCodigoImagenDefaultML.TabIndex = 76
        Me.lblCodigoImagenDefaultML.Text = "Codigo Imagen Default"
        '
        'txtCodigoRefreshTokenML
        '
        Me.txtCodigoRefreshTokenML.BindearPropiedadControl = Nothing
        Me.txtCodigoRefreshTokenML.BindearPropiedadEntidad = Nothing
        Me.txtCodigoRefreshTokenML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoRefreshTokenML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoRefreshTokenML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoRefreshTokenML.Formato = ""
        Me.txtCodigoRefreshTokenML.IsDecimal = False
        Me.txtCodigoRefreshTokenML.IsNumber = False
        Me.txtCodigoRefreshTokenML.IsPK = False
        Me.txtCodigoRefreshTokenML.IsRequired = False
        Me.txtCodigoRefreshTokenML.Key = ""
        Me.txtCodigoRefreshTokenML.LabelAsoc = Me.lblCodigoRefreshTokenML
        Me.txtCodigoRefreshTokenML.Location = New System.Drawing.Point(511, 38)
        Me.txtCodigoRefreshTokenML.MaxLength = 200
        Me.txtCodigoRefreshTokenML.Name = "txtCodigoRefreshTokenML"
        Me.txtCodigoRefreshTokenML.ReadOnly = True
        Me.txtCodigoRefreshTokenML.Size = New System.Drawing.Size(173, 20)
        Me.txtCodigoRefreshTokenML.TabIndex = 75
        '
        'txtMercadoLibreToken
        '
        Me.txtMercadoLibreToken.BindearPropiedadControl = Nothing
        Me.txtMercadoLibreToken.BindearPropiedadEntidad = Nothing
        Me.txtMercadoLibreToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMercadoLibreToken.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMercadoLibreToken.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMercadoLibreToken.Formato = ""
        Me.txtMercadoLibreToken.IsDecimal = False
        Me.txtMercadoLibreToken.IsNumber = False
        Me.txtMercadoLibreToken.IsPK = False
        Me.txtMercadoLibreToken.IsRequired = False
        Me.txtMercadoLibreToken.Key = ""
        Me.txtMercadoLibreToken.LabelAsoc = Me.lblMercadoLibreToken
        Me.txtMercadoLibreToken.Location = New System.Drawing.Point(511, 11)
        Me.txtMercadoLibreToken.MaxLength = 200
        Me.txtMercadoLibreToken.Name = "txtMercadoLibreToken"
        Me.txtMercadoLibreToken.ReadOnly = True
        Me.txtMercadoLibreToken.Size = New System.Drawing.Size(387, 20)
        Me.txtMercadoLibreToken.TabIndex = 73
        '
        'lblMercadoLibreToken
        '
        Me.lblMercadoLibreToken.AutoSize = True
        Me.lblMercadoLibreToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercadoLibreToken.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibreToken.LabelAsoc = Nothing
        Me.lblMercadoLibreToken.Location = New System.Drawing.Point(383, 14)
        Me.lblMercadoLibreToken.Name = "lblMercadoLibreToken"
        Me.lblMercadoLibreToken.Size = New System.Drawing.Size(74, 13)
        Me.lblMercadoLibreToken.TabIndex = 59
        Me.lblMercadoLibreToken.Text = "Codigo Token"
        '
        'lblMercadoLibreURLBase
        '
        Me.lblMercadoLibreURLBase.AutoSize = True
        Me.lblMercadoLibreURLBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercadoLibreURLBase.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibreURLBase.LabelAsoc = Nothing
        Me.lblMercadoLibreURLBase.Location = New System.Drawing.Point(3, 13)
        Me.lblMercadoLibreURLBase.Name = "lblMercadoLibreURLBase"
        Me.lblMercadoLibreURLBase.Size = New System.Drawing.Size(56, 13)
        Me.lblMercadoLibreURLBase.TabIndex = 72
        Me.lblMercadoLibreURLBase.Text = "URL Base"
        '
        'txtMercadoLibreCorreoNotificaciones
        '
        Me.txtMercadoLibreCorreoNotificaciones.BindearPropiedadControl = Nothing
        Me.txtMercadoLibreCorreoNotificaciones.BindearPropiedadEntidad = Nothing
        Me.txtMercadoLibreCorreoNotificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMercadoLibreCorreoNotificaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMercadoLibreCorreoNotificaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMercadoLibreCorreoNotificaciones.Formato = ""
        Me.txtMercadoLibreCorreoNotificaciones.IsDecimal = False
        Me.txtMercadoLibreCorreoNotificaciones.IsNumber = False
        Me.txtMercadoLibreCorreoNotificaciones.IsPK = False
        Me.txtMercadoLibreCorreoNotificaciones.IsRequired = False
        Me.txtMercadoLibreCorreoNotificaciones.Key = ""
        Me.txtMercadoLibreCorreoNotificaciones.LabelAsoc = Me.lblMercadoLibreCorreoNotificaciones
        Me.txtMercadoLibreCorreoNotificaciones.Location = New System.Drawing.Point(131, 37)
        Me.txtMercadoLibreCorreoNotificaciones.MaxLength = 200
        Me.txtMercadoLibreCorreoNotificaciones.Name = "txtMercadoLibreCorreoNotificaciones"
        Me.txtMercadoLibreCorreoNotificaciones.Size = New System.Drawing.Size(240, 20)
        Me.txtMercadoLibreCorreoNotificaciones.TabIndex = 71
        '
        'lblMercadoLibreCorreoNotificaciones
        '
        Me.lblMercadoLibreCorreoNotificaciones.AutoSize = True
        Me.lblMercadoLibreCorreoNotificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercadoLibreCorreoNotificaciones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibreCorreoNotificaciones.LabelAsoc = Nothing
        Me.lblMercadoLibreCorreoNotificaciones.Location = New System.Drawing.Point(3, 40)
        Me.lblMercadoLibreCorreoNotificaciones.Name = "lblMercadoLibreCorreoNotificaciones"
        Me.lblMercadoLibreCorreoNotificaciones.Size = New System.Drawing.Size(108, 13)
        Me.lblMercadoLibreCorreoNotificaciones.TabIndex = 70
        Me.lblMercadoLibreCorreoNotificaciones.Text = "Correo Notificaciones"
        '
        'gbPedidosMercadoLibre
        '
        Me.gbPedidosMercadoLibre.Controls.Add(Me.lblMercadoLibreIdProductoEnvio)
        Me.gbPedidosMercadoLibre.Controls.Add(Me.txtMercadoLibreIdProductoEnvio)
        Me.gbPedidosMercadoLibre.Controls.Add(Me.lblMercadoLibrePedidosFormaDePago)
        Me.gbPedidosMercadoLibre.Controls.Add(Me.cmbMercadoLibrePedidosFormaDePago)
        Me.gbPedidosMercadoLibre.Controls.Add(Me.lblMercadoLibrePedidosCriticidad)
        Me.gbPedidosMercadoLibre.Controls.Add(Me.cmbMercadoLibrePedidosCriticidad)
        Me.gbPedidosMercadoLibre.Controls.Add(Me.cmbMercadoLibrePedidosTipoComprobante)
        Me.gbPedidosMercadoLibre.Controls.Add(Me.lblMercadoLibrePedidosTipoComprobante)
        Me.gbPedidosMercadoLibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPedidosMercadoLibre.Location = New System.Drawing.Point(292, 121)
        Me.gbPedidosMercadoLibre.Name = "gbPedidosMercadoLibre"
        Me.gbPedidosMercadoLibre.Size = New System.Drawing.Size(606, 102)
        Me.gbPedidosMercadoLibre.TabIndex = 69
        Me.gbPedidosMercadoLibre.TabStop = False
        Me.gbPedidosMercadoLibre.Text = "Pedidos"
        '
        'lblMercadoLibreIdProductoEnvio
        '
        Me.lblMercadoLibreIdProductoEnvio.AutoSize = True
        Me.lblMercadoLibreIdProductoEnvio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibreIdProductoEnvio.LabelAsoc = Nothing
        Me.lblMercadoLibreIdProductoEnvio.Location = New System.Drawing.Point(302, 67)
        Me.lblMercadoLibreIdProductoEnvio.Name = "lblMercadoLibreIdProductoEnvio"
        Me.lblMercadoLibreIdProductoEnvio.Size = New System.Drawing.Size(89, 13)
        Me.lblMercadoLibreIdProductoEnvio.TabIndex = 17
        Me.lblMercadoLibreIdProductoEnvio.Text = "Cód. Prod. Envío"
        '
        'txtMercadoLibreIdProductoEnvio
        '
        Me.txtMercadoLibreIdProductoEnvio.BindearPropiedadControl = Nothing
        Me.txtMercadoLibreIdProductoEnvio.BindearPropiedadEntidad = Nothing
        Me.txtMercadoLibreIdProductoEnvio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMercadoLibreIdProductoEnvio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMercadoLibreIdProductoEnvio.Formato = ""
        Me.txtMercadoLibreIdProductoEnvio.IsDecimal = False
        Me.txtMercadoLibreIdProductoEnvio.IsNumber = False
        Me.txtMercadoLibreIdProductoEnvio.IsPK = False
        Me.txtMercadoLibreIdProductoEnvio.IsRequired = False
        Me.txtMercadoLibreIdProductoEnvio.Key = ""
        Me.txtMercadoLibreIdProductoEnvio.LabelAsoc = Me.lblMercadoLibreToken
        Me.txtMercadoLibreIdProductoEnvio.Location = New System.Drawing.Point(397, 64)
        Me.txtMercadoLibreIdProductoEnvio.MaxLength = 15
        Me.txtMercadoLibreIdProductoEnvio.Name = "txtMercadoLibreIdProductoEnvio"
        Me.txtMercadoLibreIdProductoEnvio.Size = New System.Drawing.Size(78, 20)
        Me.txtMercadoLibreIdProductoEnvio.TabIndex = 16
        Me.txtMercadoLibreIdProductoEnvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMercadoLibrePedidosFormaDePago
        '
        Me.lblMercadoLibrePedidosFormaDePago.AutoSize = True
        Me.lblMercadoLibrePedidosFormaDePago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibrePedidosFormaDePago.LabelAsoc = Nothing
        Me.lblMercadoLibrePedidosFormaDePago.Location = New System.Drawing.Point(302, 30)
        Me.lblMercadoLibrePedidosFormaDePago.Name = "lblMercadoLibrePedidosFormaDePago"
        Me.lblMercadoLibrePedidosFormaDePago.Size = New System.Drawing.Size(79, 13)
        Me.lblMercadoLibrePedidosFormaDePago.TabIndex = 4
        Me.lblMercadoLibrePedidosFormaDePago.Text = "Forma de Pago"
        '
        'cmbMercadoLibrePedidosFormaDePago
        '
        Me.cmbMercadoLibrePedidosFormaDePago.BindearPropiedadControl = Nothing
        Me.cmbMercadoLibrePedidosFormaDePago.BindearPropiedadEntidad = Nothing
        Me.cmbMercadoLibrePedidosFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercadoLibrePedidosFormaDePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercadoLibrePedidosFormaDePago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercadoLibrePedidosFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercadoLibrePedidosFormaDePago.FormattingEnabled = True
        Me.cmbMercadoLibrePedidosFormaDePago.IsPK = False
        Me.cmbMercadoLibrePedidosFormaDePago.IsRequired = False
        Me.cmbMercadoLibrePedidosFormaDePago.Key = Nothing
        Me.cmbMercadoLibrePedidosFormaDePago.LabelAsoc = Nothing
        Me.cmbMercadoLibrePedidosFormaDePago.Location = New System.Drawing.Point(397, 27)
        Me.cmbMercadoLibrePedidosFormaDePago.Name = "cmbMercadoLibrePedidosFormaDePago"
        Me.cmbMercadoLibrePedidosFormaDePago.Size = New System.Drawing.Size(197, 21)
        Me.cmbMercadoLibrePedidosFormaDePago.TabIndex = 5
        Me.cmbMercadoLibrePedidosFormaDePago.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'lblMercadoLibrePedidosCriticidad
        '
        Me.lblMercadoLibrePedidosCriticidad.AutoSize = True
        Me.lblMercadoLibrePedidosCriticidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibrePedidosCriticidad.LabelAsoc = Nothing
        Me.lblMercadoLibrePedidosCriticidad.Location = New System.Drawing.Point(19, 67)
        Me.lblMercadoLibrePedidosCriticidad.Name = "lblMercadoLibrePedidosCriticidad"
        Me.lblMercadoLibrePedidosCriticidad.Size = New System.Drawing.Size(50, 13)
        Me.lblMercadoLibrePedidosCriticidad.TabIndex = 2
        Me.lblMercadoLibrePedidosCriticidad.Text = "Criticidad"
        '
        'cmbMercadoLibrePedidosCriticidad
        '
        Me.cmbMercadoLibrePedidosCriticidad.BindearPropiedadControl = Nothing
        Me.cmbMercadoLibrePedidosCriticidad.BindearPropiedadEntidad = Nothing
        Me.cmbMercadoLibrePedidosCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercadoLibrePedidosCriticidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercadoLibrePedidosCriticidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercadoLibrePedidosCriticidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercadoLibrePedidosCriticidad.FormattingEnabled = True
        Me.cmbMercadoLibrePedidosCriticidad.IsPK = False
        Me.cmbMercadoLibrePedidosCriticidad.IsRequired = False
        Me.cmbMercadoLibrePedidosCriticidad.Key = Nothing
        Me.cmbMercadoLibrePedidosCriticidad.LabelAsoc = Nothing
        Me.cmbMercadoLibrePedidosCriticidad.Location = New System.Drawing.Point(120, 64)
        Me.cmbMercadoLibrePedidosCriticidad.Name = "cmbMercadoLibrePedidosCriticidad"
        Me.cmbMercadoLibrePedidosCriticidad.Size = New System.Drawing.Size(169, 21)
        Me.cmbMercadoLibrePedidosCriticidad.TabIndex = 3
        Me.cmbMercadoLibrePedidosCriticidad.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'cmbMercadoLibrePedidosTipoComprobante
        '
        Me.cmbMercadoLibrePedidosTipoComprobante.BindearPropiedadControl = Nothing
        Me.cmbMercadoLibrePedidosTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.cmbMercadoLibrePedidosTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercadoLibrePedidosTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercadoLibrePedidosTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercadoLibrePedidosTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercadoLibrePedidosTipoComprobante.FormattingEnabled = True
        Me.cmbMercadoLibrePedidosTipoComprobante.IsPK = False
        Me.cmbMercadoLibrePedidosTipoComprobante.IsRequired = False
        Me.cmbMercadoLibrePedidosTipoComprobante.Key = Nothing
        Me.cmbMercadoLibrePedidosTipoComprobante.LabelAsoc = Nothing
        Me.cmbMercadoLibrePedidosTipoComprobante.Location = New System.Drawing.Point(120, 27)
        Me.cmbMercadoLibrePedidosTipoComprobante.Name = "cmbMercadoLibrePedidosTipoComprobante"
        Me.cmbMercadoLibrePedidosTipoComprobante.Size = New System.Drawing.Size(169, 21)
        Me.cmbMercadoLibrePedidosTipoComprobante.TabIndex = 1
        Me.cmbMercadoLibrePedidosTipoComprobante.Tag = ""
        '
        'lblMercadoLibrePedidosTipoComprobante
        '
        Me.lblMercadoLibrePedidosTipoComprobante.AutoSize = True
        Me.lblMercadoLibrePedidosTipoComprobante.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibrePedidosTipoComprobante.LabelAsoc = Nothing
        Me.lblMercadoLibrePedidosTipoComprobante.Location = New System.Drawing.Point(19, 30)
        Me.lblMercadoLibrePedidosTipoComprobante.Name = "lblMercadoLibrePedidosTipoComprobante"
        Me.lblMercadoLibrePedidosTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.lblMercadoLibrePedidosTipoComprobante.TabIndex = 0
        Me.lblMercadoLibrePedidosTipoComprobante.Text = "Tipo Comprobante"
        '
        'cmbMercadoLibreVendedor
        '
        Me.cmbMercadoLibreVendedor.BindearPropiedadControl = Nothing
        Me.cmbMercadoLibreVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbMercadoLibreVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercadoLibreVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercadoLibreVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercadoLibreVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercadoLibreVendedor.FormattingEnabled = True
        Me.cmbMercadoLibreVendedor.IsPK = False
        Me.cmbMercadoLibreVendedor.IsRequired = False
        Me.cmbMercadoLibreVendedor.Key = Nothing
        Me.cmbMercadoLibreVendedor.LabelAsoc = Nothing
        Me.cmbMercadoLibreVendedor.Location = New System.Drawing.Point(131, 174)
        Me.cmbMercadoLibreVendedor.Name = "cmbMercadoLibreVendedor"
        Me.cmbMercadoLibreVendedor.Size = New System.Drawing.Size(146, 21)
        Me.cmbMercadoLibreVendedor.TabIndex = 68
        Me.cmbMercadoLibreVendedor.Tag = ""
        '
        'cmbMercadoLibreCategoriaFiscalCliente
        '
        Me.cmbMercadoLibreCategoriaFiscalCliente.BindearPropiedadControl = Nothing
        Me.cmbMercadoLibreCategoriaFiscalCliente.BindearPropiedadEntidad = Nothing
        Me.cmbMercadoLibreCategoriaFiscalCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercadoLibreCategoriaFiscalCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercadoLibreCategoriaFiscalCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercadoLibreCategoriaFiscalCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercadoLibreCategoriaFiscalCliente.FormattingEnabled = True
        Me.cmbMercadoLibreCategoriaFiscalCliente.IsPK = False
        Me.cmbMercadoLibreCategoriaFiscalCliente.IsRequired = False
        Me.cmbMercadoLibreCategoriaFiscalCliente.Key = Nothing
        Me.cmbMercadoLibreCategoriaFiscalCliente.LabelAsoc = Nothing
        Me.cmbMercadoLibreCategoriaFiscalCliente.Location = New System.Drawing.Point(131, 146)
        Me.cmbMercadoLibreCategoriaFiscalCliente.Name = "cmbMercadoLibreCategoriaFiscalCliente"
        Me.cmbMercadoLibreCategoriaFiscalCliente.Size = New System.Drawing.Size(146, 21)
        Me.cmbMercadoLibreCategoriaFiscalCliente.TabIndex = 66
        Me.cmbMercadoLibreCategoriaFiscalCliente.Tag = ""
        '
        'cmbMercadoLibreCategoriaCliente
        '
        Me.cmbMercadoLibreCategoriaCliente.BindearPropiedadControl = Nothing
        Me.cmbMercadoLibreCategoriaCliente.BindearPropiedadEntidad = Nothing
        Me.cmbMercadoLibreCategoriaCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercadoLibreCategoriaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercadoLibreCategoriaCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercadoLibreCategoriaCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercadoLibreCategoriaCliente.FormattingEnabled = True
        Me.cmbMercadoLibreCategoriaCliente.IsPK = False
        Me.cmbMercadoLibreCategoriaCliente.IsRequired = False
        Me.cmbMercadoLibreCategoriaCliente.Key = Nothing
        Me.cmbMercadoLibreCategoriaCliente.LabelAsoc = Nothing
        Me.cmbMercadoLibreCategoriaCliente.Location = New System.Drawing.Point(131, 119)
        Me.cmbMercadoLibreCategoriaCliente.Name = "cmbMercadoLibreCategoriaCliente"
        Me.cmbMercadoLibreCategoriaCliente.Size = New System.Drawing.Size(146, 21)
        Me.cmbMercadoLibreCategoriaCliente.TabIndex = 64
        Me.cmbMercadoLibreCategoriaCliente.Tag = ""
        '
        'cmbMercadoLibreListaPrecios
        '
        Me.cmbMercadoLibreListaPrecios.BindearPropiedadControl = Nothing
        Me.cmbMercadoLibreListaPrecios.BindearPropiedadEntidad = Nothing
        Me.cmbMercadoLibreListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercadoLibreListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercadoLibreListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercadoLibreListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercadoLibreListaPrecios.FormattingEnabled = True
        Me.cmbMercadoLibreListaPrecios.IsPK = False
        Me.cmbMercadoLibreListaPrecios.IsRequired = False
        Me.cmbMercadoLibreListaPrecios.Key = Nothing
        Me.cmbMercadoLibreListaPrecios.LabelAsoc = Nothing
        Me.cmbMercadoLibreListaPrecios.Location = New System.Drawing.Point(131, 93)
        Me.cmbMercadoLibreListaPrecios.Name = "cmbMercadoLibreListaPrecios"
        Me.cmbMercadoLibreListaPrecios.Size = New System.Drawing.Size(240, 21)
        Me.cmbMercadoLibreListaPrecios.TabIndex = 62
        Me.cmbMercadoLibreListaPrecios.Tag = ""
        '
        'lblMercadoLibreVendedor
        '
        Me.lblMercadoLibreVendedor.AutoSize = True
        Me.lblMercadoLibreVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercadoLibreVendedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibreVendedor.LabelAsoc = Nothing
        Me.lblMercadoLibreVendedor.Location = New System.Drawing.Point(3, 177)
        Me.lblMercadoLibreVendedor.Name = "lblMercadoLibreVendedor"
        Me.lblMercadoLibreVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lblMercadoLibreVendedor.TabIndex = 67
        Me.lblMercadoLibreVendedor.Text = "Vendedor"
        '
        'lblMercadoLibreCategoriaFiscalCliente
        '
        Me.lblMercadoLibreCategoriaFiscalCliente.AutoSize = True
        Me.lblMercadoLibreCategoriaFiscalCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercadoLibreCategoriaFiscalCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibreCategoriaFiscalCliente.LabelAsoc = Nothing
        Me.lblMercadoLibreCategoriaFiscalCliente.Location = New System.Drawing.Point(3, 149)
        Me.lblMercadoLibreCategoriaFiscalCliente.Name = "lblMercadoLibreCategoriaFiscalCliente"
        Me.lblMercadoLibreCategoriaFiscalCliente.Size = New System.Drawing.Size(119, 13)
        Me.lblMercadoLibreCategoriaFiscalCliente.TabIndex = 65
        Me.lblMercadoLibreCategoriaFiscalCliente.Text = "Categoría Fiscal Cliente"
        '
        'lblMercadoLibreCategoriaCliente
        '
        Me.lblMercadoLibreCategoriaCliente.AutoSize = True
        Me.lblMercadoLibreCategoriaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercadoLibreCategoriaCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibreCategoriaCliente.LabelAsoc = Nothing
        Me.lblMercadoLibreCategoriaCliente.Location = New System.Drawing.Point(3, 122)
        Me.lblMercadoLibreCategoriaCliente.Name = "lblMercadoLibreCategoriaCliente"
        Me.lblMercadoLibreCategoriaCliente.Size = New System.Drawing.Size(106, 13)
        Me.lblMercadoLibreCategoriaCliente.TabIndex = 63
        Me.lblMercadoLibreCategoriaCliente.Text = "Categoría del Cliente"
        '
        'txtMercadoLibreURLBase
        '
        Me.txtMercadoLibreURLBase.BindearPropiedadControl = Nothing
        Me.txtMercadoLibreURLBase.BindearPropiedadEntidad = Nothing
        Me.txtMercadoLibreURLBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMercadoLibreURLBase.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMercadoLibreURLBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMercadoLibreURLBase.Formato = ""
        Me.txtMercadoLibreURLBase.IsDecimal = False
        Me.txtMercadoLibreURLBase.IsNumber = False
        Me.txtMercadoLibreURLBase.IsPK = False
        Me.txtMercadoLibreURLBase.IsRequired = False
        Me.txtMercadoLibreURLBase.Key = ""
        Me.txtMercadoLibreURLBase.LabelAsoc = Me.lblMercadoLibreURLBase
        Me.txtMercadoLibreURLBase.Location = New System.Drawing.Point(131, 11)
        Me.txtMercadoLibreURLBase.MaxLength = 200
        Me.txtMercadoLibreURLBase.Name = "txtMercadoLibreURLBase"
        Me.txtMercadoLibreURLBase.Size = New System.Drawing.Size(241, 20)
        Me.txtMercadoLibreURLBase.TabIndex = 60
        '
        'lblMercadoLibreListaPrecios
        '
        Me.lblMercadoLibreListaPrecios.AutoSize = True
        Me.lblMercadoLibreListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercadoLibreListaPrecios.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMercadoLibreListaPrecios.LabelAsoc = Nothing
        Me.lblMercadoLibreListaPrecios.Location = New System.Drawing.Point(3, 96)
        Me.lblMercadoLibreListaPrecios.Name = "lblMercadoLibreListaPrecios"
        Me.lblMercadoLibreListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblMercadoLibreListaPrecios.TabIndex = 61
        Me.lblMercadoLibreListaPrecios.Text = "Lista de Precios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 238)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(891, 100)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Actualizaciones"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(6, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(873, 74)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.chbProductoPrecioEmbalaje)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(865, 48)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Productos"
        '
        'chbProductoPrecioEmbalaje
        '
        Me.chbProductoPrecioEmbalaje.AutoSize = True
        Me.chbProductoPrecioEmbalaje.BindearPropiedadControl = Nothing
        Me.chbProductoPrecioEmbalaje.BindearPropiedadEntidad = Nothing
        Me.chbProductoPrecioEmbalaje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoPrecioEmbalaje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoPrecioEmbalaje.IsPK = False
        Me.chbProductoPrecioEmbalaje.IsRequired = False
        Me.chbProductoPrecioEmbalaje.Key = Nothing
        Me.chbProductoPrecioEmbalaje.LabelAsoc = Nothing
        Me.chbProductoPrecioEmbalaje.Location = New System.Drawing.Point(6, 16)
        Me.chbProductoPrecioEmbalaje.Name = "chbProductoPrecioEmbalaje"
        Me.chbProductoPrecioEmbalaje.Size = New System.Drawing.Size(161, 17)
        Me.chbProductoPrecioEmbalaje.TabIndex = 6
        Me.chbProductoPrecioEmbalaje.Tag = ""
        Me.chbProductoPrecioEmbalaje.Text = "Publicar Precio por Embalaje"
        Me.chbProductoPrecioEmbalaje.UseVisualStyleBackColor = True
        '
        'ucConfMercadoLibre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCajasML)
        Me.Controls.Add(Me.cmbCajasML)
        Me.Controls.Add(Me.txtCategoriaDefaultML)
        Me.Controls.Add(Me.lblCategoriaDefaultML)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtCodigoClientSecretML)
        Me.Controls.Add(Me.lblCodigoClientSecretML)
        Me.Controls.Add(Me.txtCodigoAplicationIDML)
        Me.Controls.Add(Me.lblCodigoAplicationIDML)
        Me.Controls.Add(Me.txtCodigoResellerML)
        Me.Controls.Add(Me.lblCodigoResellerML)
        Me.Controls.Add(Me.txtFechaRefreshTokenML)
        Me.Controls.Add(Me.lblCodigoRefreshTokenML)
        Me.Controls.Add(Me.txtCodigoImagenDefaultML)
        Me.Controls.Add(Me.lblCodigoImagenDefaultML)
        Me.Controls.Add(Me.txtCodigoRefreshTokenML)
        Me.Controls.Add(Me.lblFechaRefreshTokenML)
        Me.Controls.Add(Me.txtMercadoLibreToken)
        Me.Controls.Add(Me.lblMercadoLibreURLBase)
        Me.Controls.Add(Me.txtMercadoLibreCorreoNotificaciones)
        Me.Controls.Add(Me.lblMercadoLibreCorreoNotificaciones)
        Me.Controls.Add(Me.gbPedidosMercadoLibre)
        Me.Controls.Add(Me.cmbMercadoLibreVendedor)
        Me.Controls.Add(Me.cmbMercadoLibreCategoriaFiscalCliente)
        Me.Controls.Add(Me.cmbMercadoLibreCategoriaCliente)
        Me.Controls.Add(Me.cmbMercadoLibreListaPrecios)
        Me.Controls.Add(Me.lblMercadoLibreVendedor)
        Me.Controls.Add(Me.lblMercadoLibreCategoriaFiscalCliente)
        Me.Controls.Add(Me.lblMercadoLibreCategoriaCliente)
        Me.Controls.Add(Me.txtMercadoLibreURLBase)
        Me.Controls.Add(Me.lblMercadoLibreToken)
        Me.Controls.Add(Me.lblMercadoLibreListaPrecios)
        Me.Name = "ucConfMercadoLibre"
        Me.Size = New System.Drawing.Size(912, 373)
        Me.Controls.SetChildIndex(Me.lblMercadoLibreListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.lblMercadoLibreToken, 0)
        Me.Controls.SetChildIndex(Me.txtMercadoLibreURLBase, 0)
        Me.Controls.SetChildIndex(Me.lblMercadoLibreCategoriaCliente, 0)
        Me.Controls.SetChildIndex(Me.lblMercadoLibreCategoriaFiscalCliente, 0)
        Me.Controls.SetChildIndex(Me.lblMercadoLibreVendedor, 0)
        Me.Controls.SetChildIndex(Me.cmbMercadoLibreListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.cmbMercadoLibreCategoriaCliente, 0)
        Me.Controls.SetChildIndex(Me.cmbMercadoLibreCategoriaFiscalCliente, 0)
        Me.Controls.SetChildIndex(Me.cmbMercadoLibreVendedor, 0)
        Me.Controls.SetChildIndex(Me.gbPedidosMercadoLibre, 0)
        Me.Controls.SetChildIndex(Me.lblMercadoLibreCorreoNotificaciones, 0)
        Me.Controls.SetChildIndex(Me.txtMercadoLibreCorreoNotificaciones, 0)
        Me.Controls.SetChildIndex(Me.lblMercadoLibreURLBase, 0)
        Me.Controls.SetChildIndex(Me.txtMercadoLibreToken, 0)
        Me.Controls.SetChildIndex(Me.lblFechaRefreshTokenML, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoRefreshTokenML, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoImagenDefaultML, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoImagenDefaultML, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoRefreshTokenML, 0)
        Me.Controls.SetChildIndex(Me.txtFechaRefreshTokenML, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoResellerML, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoResellerML, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoAplicationIDML, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoAplicationIDML, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoClientSecretML, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoClientSecretML, 0)
        Me.Controls.SetChildIndex(Me.Button2, 0)
        Me.Controls.SetChildIndex(Me.lblCategoriaDefaultML, 0)
        Me.Controls.SetChildIndex(Me.txtCategoriaDefaultML, 0)
        Me.Controls.SetChildIndex(Me.cmbCajasML, 0)
        Me.Controls.SetChildIndex(Me.lblCajasML, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.gbPedidosMercadoLibre.ResumeLayout(False)
        Me.gbPedidosMercadoLibre.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCajasML As Controles.Label
    Friend WithEvents cmbCajasML As Controles.ComboBox
    Friend WithEvents txtCategoriaDefaultML As Controles.TextBox
    Friend WithEvents lblCategoriaDefaultML As Controles.Label
    Friend WithEvents Button2 As Button
    Friend WithEvents txtCodigoClientSecretML As Controles.TextBox
    Friend WithEvents lblCodigoClientSecretML As Controles.Label
    Friend WithEvents txtCodigoAplicationIDML As Controles.TextBox
    Friend WithEvents lblCodigoAplicationIDML As Controles.Label
    Friend WithEvents txtCodigoResellerML As Controles.TextBox
    Friend WithEvents lblCodigoResellerML As Controles.Label
    Friend WithEvents txtFechaRefreshTokenML As Controles.TextBox
    Friend WithEvents lblFechaRefreshTokenML As Controles.Label
    Friend WithEvents lblCodigoRefreshTokenML As Controles.Label
    Friend WithEvents txtCodigoImagenDefaultML As Controles.TextBox
    Friend WithEvents lblCodigoImagenDefaultML As Controles.Label
    Friend WithEvents txtCodigoRefreshTokenML As Controles.TextBox
    Friend WithEvents txtMercadoLibreToken As Controles.TextBox
    Friend WithEvents lblMercadoLibreToken As Controles.Label
    Friend WithEvents lblMercadoLibreURLBase As Controles.Label
    Friend WithEvents txtMercadoLibreCorreoNotificaciones As Controles.TextBox
    Friend WithEvents lblMercadoLibreCorreoNotificaciones As Controles.Label
    Friend WithEvents gbPedidosMercadoLibre As GroupBox
    Friend WithEvents lblMercadoLibreIdProductoEnvio As Controles.Label
    Friend WithEvents txtMercadoLibreIdProductoEnvio As Controles.TextBox
    Friend WithEvents lblMercadoLibrePedidosFormaDePago As Controles.Label
    Friend WithEvents cmbMercadoLibrePedidosFormaDePago As Controles.ComboBox
    Friend WithEvents lblMercadoLibrePedidosCriticidad As Controles.Label
    Friend WithEvents cmbMercadoLibrePedidosCriticidad As Controles.ComboBox
    Friend WithEvents cmbMercadoLibrePedidosTipoComprobante As Controles.ComboBox
    Friend WithEvents lblMercadoLibrePedidosTipoComprobante As Controles.Label
    Friend WithEvents cmbMercadoLibreVendedor As Controles.ComboBox
    Friend WithEvents cmbMercadoLibreCategoriaFiscalCliente As Controles.ComboBox
    Friend WithEvents cmbMercadoLibreCategoriaCliente As Controles.ComboBox
    Friend WithEvents cmbMercadoLibreListaPrecios As Controles.ComboBox
    Friend WithEvents lblMercadoLibreVendedor As Controles.Label
    Friend WithEvents lblMercadoLibreCategoriaFiscalCliente As Controles.Label
    Friend WithEvents lblMercadoLibreCategoriaCliente As Controles.Label
    Friend WithEvents txtMercadoLibreURLBase As Controles.TextBox
    Friend WithEvents lblMercadoLibreListaPrecios As Controles.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents chbProductoPrecioEmbalaje As Controles.CheckBox
End Class
