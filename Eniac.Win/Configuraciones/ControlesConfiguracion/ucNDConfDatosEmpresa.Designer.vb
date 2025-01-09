<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfNDDatosEmpresa
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
      Me.cmbAplicacionEdicion = New Eniac.Controles.ComboBox()
      Me.cmbCategoriaFiscal = New Eniac.Controles.ComboBox()
      Me.chbPermiteConsultarMultipleSucursal = New Eniac.Controles.CheckBox()
        Me.lblIDAplicacion = New System.Windows.Forms.Label()
        Me.lblCurrentUICulture = New System.Windows.Forms.Label()
        Me.lblClaveClienteSinergia = New System.Windows.Forms.Label()
        Me.lblCodigoClienteSinergia = New System.Windows.Forms.Label()
        Me.txtIDAplicacion = New Eniac.Controles.TextBox()
        Me.txtCurrentUICulture = New Eniac.Controles.TextBox()
        Me.txtClaveClienteSinergia = New Eniac.Controles.TextBox()
        Me.txtCodigoClienteSinergia = New Eniac.Controles.TextBox()
        Me.txtNombreFantasia = New Eniac.Controles.TextBox()
        Me.lblNombreFantasia = New Eniac.Controles.Label()
        Me.txtDiasVencimientoSistema = New Eniac.Controles.TextBox()
        Me.lblDiasVencimientoSistema = New Eniac.Controles.Label()
        Me.txtClaveActualizacion = New Eniac.Controles.TextBox()
        Me.lblClaveAtualizacion = New Eniac.Controles.Label()
        Me.txtCuitEmpresa = New Eniac.Controles.TextBox()
        Me.lblCuitEmpresa = New Eniac.Controles.Label()
        Me.txtVersionDB = New Eniac.Controles.TextBox()
        Me.lblVersionDB = New Eniac.Controles.Label()
        Me.txtNombreEmpresa = New Eniac.Controles.TextBox()
        Me.chbSincroniza = New Eniac.Controles.CheckBox()
        Me.lblCategoriaFiscalEmpresa = New Eniac.Controles.Label()
        Me.lblNombreEmpresa = New Eniac.Controles.Label()
        Me.txtDiasControlDeLicencias = New Eniac.Controles.TextBox()
        Me.lblDiasControlDeLicencias = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'cmbAplicacionEdicion
        '
        Me.cmbAplicacionEdicion.BindearPropiedadControl = "SelectedValue"
        Me.cmbAplicacionEdicion.BindearPropiedadEntidad = "CategoriaFiscal.idCategoriaFiscal"
        Me.cmbAplicacionEdicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAplicacionEdicion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAplicacionEdicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAplicacionEdicion.FormattingEnabled = True
        Me.cmbAplicacionEdicion.IsPK = False
        Me.cmbAplicacionEdicion.IsRequired = True
        Me.cmbAplicacionEdicion.Key = Nothing
        Me.cmbAplicacionEdicion.LabelAsoc = Nothing
        Me.cmbAplicacionEdicion.Location = New System.Drawing.Point(709, 98)
        Me.cmbAplicacionEdicion.Name = "cmbAplicacionEdicion"
        Me.cmbAplicacionEdicion.Size = New System.Drawing.Size(152, 21)
        Me.cmbAplicacionEdicion.TabIndex = 79
        Me.cmbAplicacionEdicion.Tag = "CATEGORIAFISCALEMPRESA"
        '
        'cmbCategoriaFiscal
        '
        Me.cmbCategoriaFiscal.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoriaFiscal.BindearPropiedadEntidad = "CategoriaFiscal.idCategoriaFiscal"
        Me.cmbCategoriaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriaFiscal.FormattingEnabled = True
        Me.cmbCategoriaFiscal.IsPK = False
        Me.cmbCategoriaFiscal.IsRequired = True
        Me.cmbCategoriaFiscal.Key = Nothing
        Me.cmbCategoriaFiscal.LabelAsoc = Nothing
        Me.cmbCategoriaFiscal.Location = New System.Drawing.Point(124, 124)
        Me.cmbCategoriaFiscal.Name = "cmbCategoriaFiscal"
        Me.cmbCategoriaFiscal.Size = New System.Drawing.Size(152, 21)
        Me.cmbCategoriaFiscal.TabIndex = 66
        Me.cmbCategoriaFiscal.Tag = "CATEGORIAFISCALEMPRESA"
        '
        'chbPermiteConsultarMultipleSucursal
        '
        Me.chbPermiteConsultarMultipleSucursal.AutoSize = True
        Me.chbPermiteConsultarMultipleSucursal.BindearPropiedadControl = Nothing
        Me.chbPermiteConsultarMultipleSucursal.BindearPropiedadEntidad = Nothing
        Me.chbPermiteConsultarMultipleSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteConsultarMultipleSucursal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteConsultarMultipleSucursal.IsPK = False
        Me.chbPermiteConsultarMultipleSucursal.IsRequired = False
        Me.chbPermiteConsultarMultipleSucursal.Key = Nothing
        Me.chbPermiteConsultarMultipleSucursal.LabelAsoc = Nothing
        Me.chbPermiteConsultarMultipleSucursal.Location = New System.Drawing.Point(60, 259)
        Me.chbPermiteConsultarMultipleSucursal.Name = "chbPermiteConsultarMultipleSucursal"
        Me.chbPermiteConsultarMultipleSucursal.Size = New System.Drawing.Size(191, 17)
        Me.chbPermiteConsultarMultipleSucursal.TabIndex = 76
        Me.chbPermiteConsultarMultipleSucursal.Text = "Permite Consultar Multiple Sucursal"
        Me.chbPermiteConsultarMultipleSucursal.UseVisualStyleBackColor = True
        '
        'lblIDAplicacion
        '
        Me.lblIDAplicacion.AutoSize = True
        Me.lblIDAplicacion.Location = New System.Drawing.Point(449, 102)
        Me.lblIDAplicacion.Name = "lblIDAplicacion"
        Me.lblIDAplicacion.Size = New System.Drawing.Size(56, 13)
        Me.lblIDAplicacion.TabIndex = 77
        Me.lblIDAplicacion.Text = "Aplicación"
        '
        'lblCurrentUICulture
        '
        Me.lblCurrentUICulture.AutoSize = True
        Me.lblCurrentUICulture.Location = New System.Drawing.Point(311, 128)
        Me.lblCurrentUICulture.Name = "lblCurrentUICulture"
        Me.lblCurrentUICulture.Size = New System.Drawing.Size(40, 13)
        Me.lblCurrentUICulture.TabIndex = 67
        Me.lblCurrentUICulture.Text = "Cultura"
        '
        'lblClaveClienteSinergia
        '
        Me.lblClaveClienteSinergia.AutoSize = True
        Me.lblClaveClienteSinergia.Location = New System.Drawing.Point(449, 154)
        Me.lblClaveClienteSinergia.Name = "lblClaveClienteSinergia"
        Me.lblClaveClienteSinergia.Size = New System.Drawing.Size(84, 13)
        Me.lblClaveClienteSinergia.TabIndex = 82
        Me.lblClaveClienteSinergia.Text = "Clave de Cliente"
        '
        'lblCodigoClienteSinergia
        '
        Me.lblCodigoClienteSinergia.AutoSize = True
        Me.lblCodigoClienteSinergia.Location = New System.Drawing.Point(449, 128)
        Me.lblCodigoClienteSinergia.Name = "lblCodigoClienteSinergia"
        Me.lblCodigoClienteSinergia.Size = New System.Drawing.Size(90, 13)
        Me.lblCodigoClienteSinergia.TabIndex = 80
        Me.lblCodigoClienteSinergia.Text = "Código de Cliente"
        '
        'txtIDAplicacion
        '
        Me.txtIDAplicacion.BindearPropiedadControl = Nothing
        Me.txtIDAplicacion.BindearPropiedadEntidad = Nothing
        Me.txtIDAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIDAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIDAplicacion.Formato = ""
        Me.txtIDAplicacion.IsDecimal = False
        Me.txtIDAplicacion.IsNumber = False
        Me.txtIDAplicacion.IsPK = False
        Me.txtIDAplicacion.IsRequired = False
        Me.txtIDAplicacion.Key = ""
        Me.txtIDAplicacion.LabelAsoc = Nothing
        Me.txtIDAplicacion.Location = New System.Drawing.Point(556, 98)
        Me.txtIDAplicacion.MaxLength = 110
        Me.txtIDAplicacion.Name = "txtIDAplicacion"
        Me.txtIDAplicacion.Size = New System.Drawing.Size(127, 20)
        Me.txtIDAplicacion.TabIndex = 78
        Me.txtIDAplicacion.Tag = ""
        '
        'txtCurrentUICulture
        '
        Me.txtCurrentUICulture.BindearPropiedadControl = Nothing
        Me.txtCurrentUICulture.BindearPropiedadEntidad = Nothing
        Me.txtCurrentUICulture.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCurrentUICulture.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCurrentUICulture.Formato = ""
        Me.txtCurrentUICulture.IsDecimal = False
        Me.txtCurrentUICulture.IsNumber = False
        Me.txtCurrentUICulture.IsPK = False
        Me.txtCurrentUICulture.IsRequired = False
        Me.txtCurrentUICulture.Key = ""
        Me.txtCurrentUICulture.LabelAsoc = Nothing
        Me.txtCurrentUICulture.Location = New System.Drawing.Point(357, 124)
        Me.txtCurrentUICulture.MaxLength = 110
        Me.txtCurrentUICulture.Name = "txtCurrentUICulture"
        Me.txtCurrentUICulture.Size = New System.Drawing.Size(37, 20)
        Me.txtCurrentUICulture.TabIndex = 68
        Me.txtCurrentUICulture.Tag = ""
        '
        'txtClaveClienteSinergia
        '
        Me.txtClaveClienteSinergia.BindearPropiedadControl = Nothing
        Me.txtClaveClienteSinergia.BindearPropiedadEntidad = Nothing
        Me.txtClaveClienteSinergia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtClaveClienteSinergia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtClaveClienteSinergia.Formato = ""
        Me.txtClaveClienteSinergia.IsDecimal = False
        Me.txtClaveClienteSinergia.IsNumber = False
        Me.txtClaveClienteSinergia.IsPK = False
        Me.txtClaveClienteSinergia.IsRequired = False
        Me.txtClaveClienteSinergia.Key = ""
        Me.txtClaveClienteSinergia.LabelAsoc = Nothing
        Me.txtClaveClienteSinergia.Location = New System.Drawing.Point(556, 150)
        Me.txtClaveClienteSinergia.MaxLength = 110
        Me.txtClaveClienteSinergia.Name = "txtClaveClienteSinergia"
        Me.txtClaveClienteSinergia.Size = New System.Drawing.Size(127, 20)
        Me.txtClaveClienteSinergia.TabIndex = 83
        Me.txtClaveClienteSinergia.Tag = ""
        '
        'txtCodigoClienteSinergia
        '
        Me.txtCodigoClienteSinergia.BindearPropiedadControl = Nothing
        Me.txtCodigoClienteSinergia.BindearPropiedadEntidad = Nothing
        Me.txtCodigoClienteSinergia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoClienteSinergia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoClienteSinergia.Formato = ""
        Me.txtCodigoClienteSinergia.IsDecimal = False
        Me.txtCodigoClienteSinergia.IsNumber = False
        Me.txtCodigoClienteSinergia.IsPK = False
        Me.txtCodigoClienteSinergia.IsRequired = False
        Me.txtCodigoClienteSinergia.Key = ""
        Me.txtCodigoClienteSinergia.LabelAsoc = Nothing
        Me.txtCodigoClienteSinergia.Location = New System.Drawing.Point(556, 124)
        Me.txtCodigoClienteSinergia.MaxLength = 110
        Me.txtCodigoClienteSinergia.Name = "txtCodigoClienteSinergia"
        Me.txtCodigoClienteSinergia.Size = New System.Drawing.Size(127, 20)
        Me.txtCodigoClienteSinergia.TabIndex = 81
        Me.txtCodigoClienteSinergia.Tag = ""
        '
        'txtNombreFantasia
        '
        Me.txtNombreFantasia.BindearPropiedadControl = Nothing
        Me.txtNombreFantasia.BindearPropiedadEntidad = Nothing
        Me.txtNombreFantasia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreFantasia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreFantasia.Formato = ""
        Me.txtNombreFantasia.IsDecimal = False
        Me.txtNombreFantasia.IsNumber = False
        Me.txtNombreFantasia.IsPK = False
        Me.txtNombreFantasia.IsRequired = False
        Me.txtNombreFantasia.Key = ""
        Me.txtNombreFantasia.LabelAsoc = Me.lblNombreFantasia
        Me.txtNombreFantasia.Location = New System.Drawing.Point(39, 98)
        Me.txtNombreFantasia.Name = "txtNombreFantasia"
        Me.txtNombreFantasia.Size = New System.Drawing.Size(227, 20)
        Me.txtNombreFantasia.TabIndex = 62
        Me.txtNombreFantasia.Tag = "NOMBREFANTASIA"
        Me.txtNombreFantasia.Text = "Fantasia"
        '
        'lblNombreFantasia
        '
        Me.lblNombreFantasia.AutoSize = True
        Me.lblNombreFantasia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombreFantasia.LabelAsoc = Nothing
        Me.lblNombreFantasia.Location = New System.Drawing.Point(36, 82)
        Me.lblNombreFantasia.Name = "lblNombreFantasia"
        Me.lblNombreFantasia.Size = New System.Drawing.Size(99, 13)
        Me.lblNombreFantasia.TabIndex = 61
        Me.lblNombreFantasia.Text = "Nombre de fantasia"
        '
        'txtDiasVencimientoSistema
        '
        Me.txtDiasVencimientoSistema.BindearPropiedadControl = Nothing
        Me.txtDiasVencimientoSistema.BindearPropiedadEntidad = Nothing
        Me.txtDiasVencimientoSistema.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasVencimientoSistema.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasVencimientoSistema.Formato = ""
        Me.txtDiasVencimientoSistema.IsDecimal = False
        Me.txtDiasVencimientoSistema.IsNumber = True
        Me.txtDiasVencimientoSistema.IsPK = False
        Me.txtDiasVencimientoSistema.IsRequired = False
        Me.txtDiasVencimientoSistema.Key = ""
        Me.txtDiasVencimientoSistema.LabelAsoc = Me.lblDiasVencimientoSistema
        Me.txtDiasVencimientoSistema.Location = New System.Drawing.Point(218, 233)
        Me.txtDiasVencimientoSistema.MaxLength = 3
        Me.txtDiasVencimientoSistema.Name = "txtDiasVencimientoSistema"
        Me.txtDiasVencimientoSistema.Size = New System.Drawing.Size(35, 20)
        Me.txtDiasVencimientoSistema.TabIndex = 75
        Me.txtDiasVencimientoSistema.Tag = "DIASAVISOVENCIMIENTOSISTEMA"
        Me.txtDiasVencimientoSistema.Text = "15"
        Me.txtDiasVencimientoSistema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiasVencimientoSistema
        '
        Me.lblDiasVencimientoSistema.AutoSize = True
        Me.lblDiasVencimientoSistema.LabelAsoc = Nothing
        Me.lblDiasVencimientoSistema.Location = New System.Drawing.Point(57, 237)
        Me.lblDiasVencimientoSistema.Name = "lblDiasVencimientoSistema"
        Me.lblDiasVencimientoSistema.Size = New System.Drawing.Size(158, 13)
        Me.lblDiasVencimientoSistema.TabIndex = 74
        Me.lblDiasVencimientoSistema.Text = "Días aviso vencimiento Sistema"
        Me.lblDiasVencimientoSistema.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtClaveActualizacion
        '
        Me.txtClaveActualizacion.BindearPropiedadControl = Nothing
        Me.txtClaveActualizacion.BindearPropiedadEntidad = Nothing
        Me.txtClaveActualizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtClaveActualizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtClaveActualizacion.Formato = ""
        Me.txtClaveActualizacion.IsDecimal = False
        Me.txtClaveActualizacion.IsNumber = False
        Me.txtClaveActualizacion.IsPK = False
        Me.txtClaveActualizacion.IsRequired = False
        Me.txtClaveActualizacion.Key = ""
        Me.txtClaveActualizacion.LabelAsoc = Me.lblClaveAtualizacion
        Me.txtClaveActualizacion.Location = New System.Drawing.Point(39, 207)
        Me.txtClaveActualizacion.Name = "txtClaveActualizacion"
        Me.txtClaveActualizacion.Size = New System.Drawing.Size(355, 20)
        Me.txtClaveActualizacion.TabIndex = 73
        Me.txtClaveActualizacion.Tag = "VENCIMIENTOSISTEMA"
        Me.txtClaveActualizacion.Text = "c22Z6r8w2EgQb6Vt7c7WAtKz/3e2DvnVVfeMpmL2GFs="
        '
        'lblClaveAtualizacion
        '
        Me.lblClaveAtualizacion.AutoSize = True
        Me.lblClaveAtualizacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblClaveAtualizacion.LabelAsoc = Nothing
        Me.lblClaveAtualizacion.Location = New System.Drawing.Point(36, 191)
        Me.lblClaveAtualizacion.Name = "lblClaveAtualizacion"
        Me.lblClaveAtualizacion.Size = New System.Drawing.Size(114, 13)
        Me.lblClaveAtualizacion.TabIndex = 72
        Me.lblClaveAtualizacion.Text = "Clave de actualización"
        '
        'txtCuitEmpresa
        '
        Me.txtCuitEmpresa.BindearPropiedadControl = Nothing
        Me.txtCuitEmpresa.BindearPropiedadEntidad = Nothing
        Me.txtCuitEmpresa.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuitEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuitEmpresa.Formato = ""
        Me.txtCuitEmpresa.IsDecimal = False
        Me.txtCuitEmpresa.IsNumber = True
        Me.txtCuitEmpresa.IsPK = False
        Me.txtCuitEmpresa.IsRequired = False
        Me.txtCuitEmpresa.Key = ""
        Me.txtCuitEmpresa.LabelAsoc = Me.lblCuitEmpresa
        Me.txtCuitEmpresa.Location = New System.Drawing.Point(272, 98)
        Me.txtCuitEmpresa.MaxLength = 11
        Me.txtCuitEmpresa.Name = "txtCuitEmpresa"
        Me.txtCuitEmpresa.Size = New System.Drawing.Size(122, 20)
        Me.txtCuitEmpresa.TabIndex = 64
        Me.txtCuitEmpresa.Tag = "CUITEMPRESA"
        Me.txtCuitEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCuitEmpresa
        '
        Me.lblCuitEmpresa.AutoSize = True
        Me.lblCuitEmpresa.LabelAsoc = Nothing
        Me.lblCuitEmpresa.Location = New System.Drawing.Point(269, 82)
        Me.lblCuitEmpresa.Name = "lblCuitEmpresa"
        Me.lblCuitEmpresa.Size = New System.Drawing.Size(102, 13)
        Me.lblCuitEmpresa.TabIndex = 63
        Me.lblCuitEmpresa.Text = "CUIT de la Empresa"
        '
        'txtVersionDB
        '
        Me.txtVersionDB.BindearPropiedadControl = Nothing
        Me.txtVersionDB.BindearPropiedadEntidad = Nothing
        Me.txtVersionDB.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVersionDB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVersionDB.Formato = ""
        Me.txtVersionDB.IsDecimal = False
        Me.txtVersionDB.IsNumber = False
        Me.txtVersionDB.IsPK = False
        Me.txtVersionDB.IsRequired = False
        Me.txtVersionDB.Key = ""
        Me.txtVersionDB.LabelAsoc = Me.lblVersionDB
        Me.txtVersionDB.Location = New System.Drawing.Point(337, 163)
        Me.txtVersionDB.MaxLength = 10
        Me.txtVersionDB.Name = "txtVersionDB"
        Me.txtVersionDB.Size = New System.Drawing.Size(57, 20)
        Me.txtVersionDB.TabIndex = 71
        Me.txtVersionDB.Tag = "VERSIONDB"
        Me.txtVersionDB.Text = "1.0.0.1"
        '
        'lblVersionDB
        '
        Me.lblVersionDB.AutoSize = True
        Me.lblVersionDB.LabelAsoc = Nothing
        Me.lblVersionDB.Location = New System.Drawing.Point(334, 147)
        Me.lblVersionDB.Name = "lblVersionDB"
        Me.lblVersionDB.Size = New System.Drawing.Size(60, 13)
        Me.lblVersionDB.TabIndex = 70
        Me.lblVersionDB.Text = "Version DB"
        '
        'txtNombreEmpresa
        '
        Me.txtNombreEmpresa.BindearPropiedadControl = Nothing
        Me.txtNombreEmpresa.BindearPropiedadEntidad = Nothing
        Me.txtNombreEmpresa.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreEmpresa.Formato = ""
        Me.txtNombreEmpresa.IsDecimal = False
        Me.txtNombreEmpresa.IsNumber = False
        Me.txtNombreEmpresa.IsPK = False
        Me.txtNombreEmpresa.IsRequired = False
        Me.txtNombreEmpresa.Key = ""
        Me.txtNombreEmpresa.LabelAsoc = Nothing
        Me.txtNombreEmpresa.Location = New System.Drawing.Point(39, 59)
        Me.txtNombreEmpresa.Name = "txtNombreEmpresa"
        Me.txtNombreEmpresa.Size = New System.Drawing.Size(355, 20)
        Me.txtNombreEmpresa.TabIndex = 60
        Me.txtNombreEmpresa.Tag = "NOMBREEMPRESA"
        Me.txtNombreEmpresa.Text = "Empresa"
        '
        'chbSincroniza
        '
        Me.chbSincroniza.BindearPropiedadControl = Nothing
        Me.chbSincroniza.BindearPropiedadEntidad = Nothing
        Me.chbSincroniza.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSincroniza.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSincroniza.IsPK = False
        Me.chbSincroniza.IsRequired = False
        Me.chbSincroniza.Key = Nothing
        Me.chbSincroniza.LabelAsoc = Nothing
        Me.chbSincroniza.Location = New System.Drawing.Point(39, 163)
        Me.chbSincroniza.Name = "chbSincroniza"
        Me.chbSincroniza.Size = New System.Drawing.Size(268, 20)
        Me.chbSincroniza.TabIndex = 69
        Me.chbSincroniza.Tag = "SINCRONIZA"
        Me.chbSincroniza.Text = "Realiza Sincronizaciones desde/hacia Sucursales"
        Me.chbSincroniza.UseVisualStyleBackColor = True
        '
        'lblCategoriaFiscalEmpresa
        '
        Me.lblCategoriaFiscalEmpresa.AutoSize = True
        Me.lblCategoriaFiscalEmpresa.LabelAsoc = Nothing
        Me.lblCategoriaFiscalEmpresa.Location = New System.Drawing.Point(36, 128)
        Me.lblCategoriaFiscalEmpresa.Name = "lblCategoriaFiscalEmpresa"
        Me.lblCategoriaFiscalEmpresa.Size = New System.Drawing.Size(82, 13)
        Me.lblCategoriaFiscalEmpresa.TabIndex = 65
        Me.lblCategoriaFiscalEmpresa.Text = "Categoria Fiscal"
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombreEmpresa.LabelAsoc = Nothing
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(36, 43)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(113, 13)
        Me.lblNombreEmpresa.TabIndex = 59
        Me.lblNombreEmpresa.Text = "Nombre de la empresa"
        '
        'txtDiasControlDeLicencias
        '
        Me.txtDiasControlDeLicencias.BindearPropiedadControl = Nothing
        Me.txtDiasControlDeLicencias.BindearPropiedadEntidad = Nothing
        Me.txtDiasControlDeLicencias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasControlDeLicencias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasControlDeLicencias.Formato = ""
        Me.txtDiasControlDeLicencias.IsDecimal = False
        Me.txtDiasControlDeLicencias.IsNumber = True
        Me.txtDiasControlDeLicencias.IsPK = False
        Me.txtDiasControlDeLicencias.IsRequired = False
        Me.txtDiasControlDeLicencias.Key = ""
        Me.txtDiasControlDeLicencias.LabelAsoc = Me.lblDiasControlDeLicencias
        Me.txtDiasControlDeLicencias.Location = New System.Drawing.Point(581, 206)
        Me.txtDiasControlDeLicencias.MaxLength = 4
        Me.txtDiasControlDeLicencias.Name = "txtDiasControlDeLicencias"
        Me.txtDiasControlDeLicencias.Size = New System.Drawing.Size(35, 20)
        Me.txtDiasControlDeLicencias.TabIndex = 85
        Me.txtDiasControlDeLicencias.Tag = "DIASCONTROLDELICENCIAS"
        Me.txtDiasControlDeLicencias.Text = "0"
        Me.txtDiasControlDeLicencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiasControlDeLicencias
        '
        Me.lblDiasControlDeLicencias.AutoSize = True
        Me.lblDiasControlDeLicencias.LabelAsoc = Nothing
        Me.lblDiasControlDeLicencias.Location = New System.Drawing.Point(449, 210)
        Me.lblDiasControlDeLicencias.Name = "lblDiasControlDeLicencias"
        Me.lblDiasControlDeLicencias.Size = New System.Drawing.Size(127, 13)
        Me.lblDiasControlDeLicencias.TabIndex = 84
        Me.lblDiasControlDeLicencias.Text = "Dias Control de Licencias"
        Me.lblDiasControlDeLicencias.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ucConfNDDatosEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtDiasControlDeLicencias)
        Me.Controls.Add(Me.lblDiasControlDeLicencias)
        Me.Controls.Add(Me.cmbAplicacionEdicion)
        Me.Controls.Add(Me.cmbCategoriaFiscal)
        Me.Controls.Add(Me.chbPermiteConsultarMultipleSucursal)
        Me.Controls.Add(Me.lblIDAplicacion)
        Me.Controls.Add(Me.lblCurrentUICulture)
        Me.Controls.Add(Me.lblClaveClienteSinergia)
        Me.Controls.Add(Me.lblCodigoClienteSinergia)
        Me.Controls.Add(Me.txtIDAplicacion)
        Me.Controls.Add(Me.txtCurrentUICulture)
        Me.Controls.Add(Me.txtClaveClienteSinergia)
        Me.Controls.Add(Me.txtCodigoClienteSinergia)
        Me.Controls.Add(Me.txtNombreFantasia)
        Me.Controls.Add(Me.lblNombreFantasia)
        Me.Controls.Add(Me.txtDiasVencimientoSistema)
        Me.Controls.Add(Me.txtClaveActualizacion)
        Me.Controls.Add(Me.txtCuitEmpresa)
        Me.Controls.Add(Me.txtVersionDB)
        Me.Controls.Add(Me.txtNombreEmpresa)
        Me.Controls.Add(Me.lblDiasVencimientoSistema)
        Me.Controls.Add(Me.lblClaveAtualizacion)
        Me.Controls.Add(Me.lblCuitEmpresa)
        Me.Controls.Add(Me.lblVersionDB)
        Me.Controls.Add(Me.chbSincroniza)
        Me.Controls.Add(Me.lblCategoriaFiscalEmpresa)
        Me.Controls.Add(Me.lblNombreEmpresa)
        Me.Name = "ucConfNDDatosEmpresa"
        Me.Controls.SetChildIndex(Me.lblNombreEmpresa, 0)
        Me.Controls.SetChildIndex(Me.lblCategoriaFiscalEmpresa, 0)
        Me.Controls.SetChildIndex(Me.chbSincroniza, 0)
        Me.Controls.SetChildIndex(Me.lblVersionDB, 0)
        Me.Controls.SetChildIndex(Me.lblCuitEmpresa, 0)
        Me.Controls.SetChildIndex(Me.lblClaveAtualizacion, 0)
        Me.Controls.SetChildIndex(Me.lblDiasVencimientoSistema, 0)
        Me.Controls.SetChildIndex(Me.txtNombreEmpresa, 0)
        Me.Controls.SetChildIndex(Me.txtVersionDB, 0)
        Me.Controls.SetChildIndex(Me.txtCuitEmpresa, 0)
        Me.Controls.SetChildIndex(Me.txtClaveActualizacion, 0)
        Me.Controls.SetChildIndex(Me.txtDiasVencimientoSistema, 0)
        Me.Controls.SetChildIndex(Me.lblNombreFantasia, 0)
        Me.Controls.SetChildIndex(Me.txtNombreFantasia, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoClienteSinergia, 0)
        Me.Controls.SetChildIndex(Me.txtClaveClienteSinergia, 0)
        Me.Controls.SetChildIndex(Me.txtCurrentUICulture, 0)
        Me.Controls.SetChildIndex(Me.txtIDAplicacion, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoClienteSinergia, 0)
        Me.Controls.SetChildIndex(Me.lblClaveClienteSinergia, 0)
        Me.Controls.SetChildIndex(Me.lblCurrentUICulture, 0)
        Me.Controls.SetChildIndex(Me.lblIDAplicacion, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteConsultarMultipleSucursal, 0)
        Me.Controls.SetChildIndex(Me.cmbCategoriaFiscal, 0)
        Me.Controls.SetChildIndex(Me.cmbAplicacionEdicion, 0)
        Me.Controls.SetChildIndex(Me.lblDiasControlDeLicencias, 0)
        Me.Controls.SetChildIndex(Me.txtDiasControlDeLicencias, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbAplicacionEdicion As Controles.ComboBox
   Friend WithEvents cmbCategoriaFiscal As Controles.ComboBox
   Friend WithEvents chbPermiteConsultarMultipleSucursal As Controles.CheckBox
    Friend WithEvents lblIDAplicacion As Label
    Friend WithEvents lblCurrentUICulture As Label
   Friend WithEvents lblClaveClienteSinergia As Label
   Friend WithEvents lblCodigoClienteSinergia As Label
   Friend WithEvents txtIDAplicacion As Controles.TextBox
   Friend WithEvents txtCurrentUICulture As Controles.TextBox
   Friend WithEvents txtClaveClienteSinergia As Controles.TextBox
   Friend WithEvents txtCodigoClienteSinergia As Controles.TextBox
   Friend WithEvents txtNombreFantasia As Controles.TextBox
   Friend WithEvents lblNombreFantasia As Controles.Label
   Friend WithEvents txtDiasVencimientoSistema As Controles.TextBox
   Friend WithEvents lblDiasVencimientoSistema As Controles.Label
   Friend WithEvents txtClaveActualizacion As Controles.TextBox
   Friend WithEvents lblClaveAtualizacion As Controles.Label
   Friend WithEvents txtCuitEmpresa As Controles.TextBox
   Friend WithEvents lblCuitEmpresa As Controles.Label
   Friend WithEvents txtVersionDB As Controles.TextBox
   Friend WithEvents lblVersionDB As Controles.Label
   Friend WithEvents txtNombreEmpresa As Controles.TextBox
   Friend WithEvents chbSincroniza As Controles.CheckBox
   Friend WithEvents lblCategoriaFiscalEmpresa As Controles.Label
   Friend WithEvents lblNombreEmpresa As Controles.Label
    Friend WithEvents txtDiasControlDeLicencias As Controles.TextBox
    Friend WithEvents lblDiasControlDeLicencias As Controles.Label
End Class
