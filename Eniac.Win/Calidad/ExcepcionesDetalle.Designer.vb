<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExcepcionesDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.lblNombreTipoCliente = New Eniac.Controles.Label()
      Me.txtNombreExcepcionTipo = New Eniac.Controles.TextBox()
      Me.lblIdTipoCliente = New Eniac.Controles.Label()
      Me.txtIdExcepcion = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.TextBox1 = New Eniac.Controles.TextBox()
      Me.Label6 = New Eniac.Controles.Label()
      Me.dtpIngreso = New Eniac.Controles.DateTimePicker()
      Me.Label9 = New Eniac.Controles.Label()
      Me.Label10 = New Eniac.Controles.Label()
      Me.dtpFechaAutorizante1 = New Eniac.Controles.DateTimePicker()
      Me.Label11 = New Eniac.Controles.Label()
      Me.dtpFechaAutorizante2 = New Eniac.Controles.DateTimePicker()
      Me.Label12 = New Eniac.Controles.Label()
      Me.dtpFechaAutorizante3 = New Eniac.Controles.DateTimePicker()
      Me.Label13 = New Eniac.Controles.Label()
      Me.TextBox2 = New Eniac.Controles.TextBox()
      Me.chbAutorizante1 = New Eniac.Controles.CheckBox()
      Me.chbAutorizante2 = New Eniac.Controles.CheckBox()
      Me.chbAutorizante3 = New Eniac.Controles.CheckBox()
      Me.cmbAutorizante2 = New Eniac.Controles.ComboBox()
      Me.cmbAutorizante3 = New Eniac.Controles.ComboBox()
      Me.cmbSolicitante = New Eniac.Controles.ComboBox()
      Me.cmbAutorizante1 = New Eniac.Controles.ComboBox()
      Me.cmbDpto = New Eniac.Controles.ComboBox()
      Me.cmbTiposExcepciones = New Eniac.Controles.ComboBox()
      Me.cmbTipoListaControl = New Eniac.Controles.ComboBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(252, 374)
      Me.btnAceptar.TabIndex = 19
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(338, 374)
      Me.btnCancelar.TabIndex = 20
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(151, 374)
      Me.btnCopiar.TabIndex = 0
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(94, 374)
      Me.btnAplicar.TabIndex = 33
      '
      'lblNombreTipoCliente
      '
      Me.lblNombreTipoCliente.AutoSize = True
      Me.lblNombreTipoCliente.LabelAsoc = Nothing
      Me.lblNombreTipoCliente.Location = New System.Drawing.Point(13, 158)
      Me.lblNombreTipoCliente.Name = "lblNombreTipoCliente"
      Me.lblNombreTipoCliente.Size = New System.Drawing.Size(39, 13)
      Me.lblNombreTipoCliente.TabIndex = 28
      Me.lblNombreTipoCliente.Text = "Motivo"
      '
      'txtNombreExcepcionTipo
      '
      Me.txtNombreExcepcionTipo.BindearPropiedadControl = "Text"
      Me.txtNombreExcepcionTipo.BindearPropiedadEntidad = "Motivo"
      Me.txtNombreExcepcionTipo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreExcepcionTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreExcepcionTipo.Formato = ""
      Me.txtNombreExcepcionTipo.IsDecimal = False
      Me.txtNombreExcepcionTipo.IsNumber = False
      Me.txtNombreExcepcionTipo.IsPK = False
      Me.txtNombreExcepcionTipo.IsRequired = True
      Me.txtNombreExcepcionTipo.Key = ""
      Me.txtNombreExcepcionTipo.LabelAsoc = Me.lblNombreTipoCliente
      Me.txtNombreExcepcionTipo.Location = New System.Drawing.Point(104, 155)
      Me.txtNombreExcepcionTipo.MaxLength = 300
      Me.txtNombreExcepcionTipo.Multiline = True
      Me.txtNombreExcepcionTipo.Name = "txtNombreExcepcionTipo"
      Me.txtNombreExcepcionTipo.Size = New System.Drawing.Size(300, 59)
      Me.txtNombreExcepcionTipo.TabIndex = 7
      '
      'lblIdTipoCliente
      '
      Me.lblIdTipoCliente.AutoSize = True
      Me.lblIdTipoCliente.LabelAsoc = Nothing
      Me.lblIdTipoCliente.Location = New System.Drawing.Point(13, 23)
      Me.lblIdTipoCliente.Name = "lblIdTipoCliente"
      Me.lblIdTipoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoCliente.TabIndex = 21
      Me.lblIdTipoCliente.Text = "Código"
      '
      'txtIdExcepcion
      '
      Me.txtIdExcepcion.BindearPropiedadControl = "Text"
      Me.txtIdExcepcion.BindearPropiedadEntidad = "IdExcepcion"
      Me.txtIdExcepcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdExcepcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdExcepcion.Formato = ""
      Me.txtIdExcepcion.IsDecimal = False
      Me.txtIdExcepcion.IsNumber = True
      Me.txtIdExcepcion.IsPK = True
      Me.txtIdExcepcion.IsRequired = True
      Me.txtIdExcepcion.Key = ""
      Me.txtIdExcepcion.LabelAsoc = Me.lblIdTipoCliente
      Me.txtIdExcepcion.Location = New System.Drawing.Point(106, 20)
      Me.txtIdExcepcion.MaxLength = 9
      Me.txtIdExcepcion.Name = "txtIdExcepcion"
      Me.txtIdExcepcion.Size = New System.Drawing.Size(51, 20)
      Me.txtIdExcepcion.TabIndex = 0
      Me.txtIdExcepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(13, 77)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(46, 13)
      Me.Label3.TabIndex = 25
      Me.Label3.Text = "Sección"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(13, 104)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(28, 13)
      Me.Label1.TabIndex = 26
      Me.Label1.Tag = ""
      Me.Label1.Text = "Tipo"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(195, 23)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(74, 13)
      Me.Label2.TabIndex = 22
      Me.Label2.Text = "Departamento"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(13, 223)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(60, 26)
      Me.Label4.TabIndex = 29
      Me.Label4.Text = "Acciones " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Correctivas"
      '
      'TextBox1
      '
      Me.TextBox1.BindearPropiedadControl = "Text"
      Me.TextBox1.BindearPropiedadEntidad = "AccionesCorrectivas"
      Me.TextBox1.ForeColorFocus = System.Drawing.Color.Red
      Me.TextBox1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.TextBox1.Formato = ""
      Me.TextBox1.IsDecimal = False
      Me.TextBox1.IsNumber = False
      Me.TextBox1.IsPK = False
      Me.TextBox1.IsRequired = True
      Me.TextBox1.Key = ""
      Me.TextBox1.LabelAsoc = Me.Label4
      Me.TextBox1.Location = New System.Drawing.Point(104, 220)
      Me.TextBox1.MaxLength = 300
      Me.TextBox1.Multiline = True
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(301, 59)
      Me.TextBox1.TabIndex = 8
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.LabelAsoc = Nothing
      Me.Label6.Location = New System.Drawing.Point(13, 50)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(56, 13)
      Me.Label6.TabIndex = 23
      Me.Label6.Text = "Solicitante"
      '
      'dtpIngreso
      '
      Me.dtpIngreso.BindearPropiedadControl = "Value"
      Me.dtpIngreso.BindearPropiedadEntidad = "FechaExcepcion"
      Me.dtpIngreso.CustomFormat = "dd/MM/yyyy"
      Me.dtpIngreso.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpIngreso.IsPK = False
      Me.dtpIngreso.IsRequired = True
      Me.dtpIngreso.Key = ""
      Me.dtpIngreso.LabelAsoc = Nothing
      Me.dtpIngreso.Location = New System.Drawing.Point(272, 48)
      Me.dtpIngreso.Name = "dtpIngreso"
      Me.dtpIngreso.Size = New System.Drawing.Size(95, 20)
      Me.dtpIngreso.TabIndex = 3
      Me.dtpIngreso.Tag = "000"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.LabelAsoc = Nothing
      Me.Label9.Location = New System.Drawing.Point(230, 51)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(40, 13)
      Me.Label9.TabIndex = 24
      Me.Label9.Text = "Fecha "
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.LabelAsoc = Nothing
      Me.Label10.Location = New System.Drawing.Point(235, 289)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(37, 13)
      Me.Label10.TabIndex = 30
      Me.Label10.Text = "Fecha"
      '
      'dtpFechaAutorizante1
      '
      Me.dtpFechaAutorizante1.BindearPropiedadControl = "Value"
      Me.dtpFechaAutorizante1.BindearPropiedadEntidad = "FechaUsuario1"
      Me.dtpFechaAutorizante1.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaAutorizante1.Enabled = False
      Me.dtpFechaAutorizante1.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAutorizante1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAutorizante1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAutorizante1.IsPK = False
      Me.dtpFechaAutorizante1.IsRequired = False
      Me.dtpFechaAutorizante1.Key = ""
      Me.dtpFechaAutorizante1.LabelAsoc = Nothing
      Me.dtpFechaAutorizante1.Location = New System.Drawing.Point(282, 286)
      Me.dtpFechaAutorizante1.Name = "dtpFechaAutorizante1"
      Me.dtpFechaAutorizante1.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaAutorizante1.TabIndex = 12
      Me.dtpFechaAutorizante1.Tag = "000"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.LabelAsoc = Nothing
      Me.Label11.Location = New System.Drawing.Point(235, 316)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(37, 13)
      Me.Label11.TabIndex = 31
      Me.Label11.Text = "Fecha"
      '
      'dtpFechaAutorizante2
      '
      Me.dtpFechaAutorizante2.BindearPropiedadControl = "Value"
      Me.dtpFechaAutorizante2.BindearPropiedadEntidad = "FechaUsuario2"
      Me.dtpFechaAutorizante2.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaAutorizante2.Enabled = False
      Me.dtpFechaAutorizante2.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAutorizante2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAutorizante2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAutorizante2.IsPK = False
      Me.dtpFechaAutorizante2.IsRequired = False
      Me.dtpFechaAutorizante2.Key = ""
      Me.dtpFechaAutorizante2.LabelAsoc = Nothing
      Me.dtpFechaAutorizante2.Location = New System.Drawing.Point(282, 313)
      Me.dtpFechaAutorizante2.Name = "dtpFechaAutorizante2"
      Me.dtpFechaAutorizante2.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaAutorizante2.TabIndex = 15
      Me.dtpFechaAutorizante2.Tag = "000"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.LabelAsoc = Nothing
      Me.Label12.Location = New System.Drawing.Point(235, 341)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(37, 13)
      Me.Label12.TabIndex = 32
      Me.Label12.Text = "Fecha"
      '
      'dtpFechaAutorizante3
      '
      Me.dtpFechaAutorizante3.BindearPropiedadControl = "Value"
      Me.dtpFechaAutorizante3.BindearPropiedadEntidad = "FechaUsuario3"
      Me.dtpFechaAutorizante3.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaAutorizante3.Enabled = False
      Me.dtpFechaAutorizante3.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAutorizante3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAutorizante3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAutorizante3.IsPK = False
      Me.dtpFechaAutorizante3.IsRequired = False
      Me.dtpFechaAutorizante3.Key = ""
      Me.dtpFechaAutorizante3.LabelAsoc = Nothing
      Me.dtpFechaAutorizante3.Location = New System.Drawing.Point(282, 338)
      Me.dtpFechaAutorizante3.Name = "dtpFechaAutorizante3"
      Me.dtpFechaAutorizante3.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaAutorizante3.TabIndex = 18
      Me.dtpFechaAutorizante3.Tag = "000"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.LabelAsoc = Nothing
      Me.Label13.Location = New System.Drawing.Point(13, 131)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(27, 13)
      Me.Label13.TabIndex = 27
      Me.Label13.Text = "Item"
      '
      'TextBox2
      '
      Me.TextBox2.BindearPropiedadControl = "Text"
      Me.TextBox2.BindearPropiedadEntidad = "Item"
      Me.TextBox2.ForeColorFocus = System.Drawing.Color.Red
      Me.TextBox2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.TextBox2.Formato = ""
      Me.TextBox2.IsDecimal = False
      Me.TextBox2.IsNumber = False
      Me.TextBox2.IsPK = False
      Me.TextBox2.IsRequired = True
      Me.TextBox2.Key = ""
      Me.TextBox2.LabelAsoc = Me.Label13
      Me.TextBox2.Location = New System.Drawing.Point(105, 128)
      Me.TextBox2.MaxLength = 300
      Me.TextBox2.Multiline = True
      Me.TextBox2.Name = "TextBox2"
      Me.TextBox2.Size = New System.Drawing.Size(300, 21)
      Me.TextBox2.TabIndex = 6
      '
      'chbAutorizante1
      '
      Me.chbAutorizante1.AutoSize = True
      Me.chbAutorizante1.BindearPropiedadControl = ""
      Me.chbAutorizante1.BindearPropiedadEntidad = ""
      Me.chbAutorizante1.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAutorizante1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAutorizante1.IsPK = False
      Me.chbAutorizante1.IsRequired = False
      Me.chbAutorizante1.Key = Nothing
      Me.chbAutorizante1.LabelAsoc = Nothing
      Me.chbAutorizante1.Location = New System.Drawing.Point(16, 288)
      Me.chbAutorizante1.Name = "chbAutorizante1"
      Me.chbAutorizante1.Size = New System.Drawing.Size(88, 17)
      Me.chbAutorizante1.TabIndex = 10
      Me.chbAutorizante1.Text = "Autorizante 1"
      Me.chbAutorizante1.UseVisualStyleBackColor = True
      '
      'chbAutorizante2
      '
      Me.chbAutorizante2.AutoSize = True
      Me.chbAutorizante2.BindearPropiedadControl = ""
      Me.chbAutorizante2.BindearPropiedadEntidad = ""
      Me.chbAutorizante2.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAutorizante2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAutorizante2.IsPK = False
      Me.chbAutorizante2.IsRequired = False
      Me.chbAutorizante2.Key = Nothing
      Me.chbAutorizante2.LabelAsoc = Nothing
      Me.chbAutorizante2.Location = New System.Drawing.Point(16, 314)
      Me.chbAutorizante2.Name = "chbAutorizante2"
      Me.chbAutorizante2.Size = New System.Drawing.Size(88, 17)
      Me.chbAutorizante2.TabIndex = 13
      Me.chbAutorizante2.Text = "Autorizante 2"
      Me.chbAutorizante2.UseVisualStyleBackColor = True
      '
      'chbAutorizante3
      '
      Me.chbAutorizante3.AutoSize = True
      Me.chbAutorizante3.BindearPropiedadControl = ""
      Me.chbAutorizante3.BindearPropiedadEntidad = ""
      Me.chbAutorizante3.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAutorizante3.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAutorizante3.IsPK = False
      Me.chbAutorizante3.IsRequired = False
      Me.chbAutorizante3.Key = Nothing
      Me.chbAutorizante3.LabelAsoc = Nothing
      Me.chbAutorizante3.Location = New System.Drawing.Point(16, 340)
      Me.chbAutorizante3.Name = "chbAutorizante3"
      Me.chbAutorizante3.Size = New System.Drawing.Size(88, 17)
      Me.chbAutorizante3.TabIndex = 16
      Me.chbAutorizante3.Text = "Autorizante 3"
      Me.chbAutorizante3.UseVisualStyleBackColor = True
      '
      'cmbAutorizante2
      '
      Me.cmbAutorizante2.BindearPropiedadControl = "SelectedValue"
      Me.cmbAutorizante2.BindearPropiedadEntidad = "IdUsuario2"
      Me.cmbAutorizante2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAutorizante2.Enabled = False
      Me.cmbAutorizante2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbAutorizante2.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAutorizante2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAutorizante2.FormattingEnabled = True
      Me.cmbAutorizante2.IsPK = False
      Me.cmbAutorizante2.IsRequired = False
      Me.cmbAutorizante2.Key = Nothing
      Me.cmbAutorizante2.LabelAsoc = Nothing
      Me.cmbAutorizante2.Location = New System.Drawing.Point(104, 312)
      Me.cmbAutorizante2.Name = "cmbAutorizante2"
      Me.cmbAutorizante2.Size = New System.Drawing.Size(119, 21)
      Me.cmbAutorizante2.TabIndex = 14
      '
      'cmbAutorizante3
      '
      Me.cmbAutorizante3.BindearPropiedadControl = "SelectedValue"
      Me.cmbAutorizante3.BindearPropiedadEntidad = "IdUsuario3"
      Me.cmbAutorizante3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAutorizante3.Enabled = False
      Me.cmbAutorizante3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbAutorizante3.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAutorizante3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAutorizante3.FormattingEnabled = True
      Me.cmbAutorizante3.IsPK = False
      Me.cmbAutorizante3.IsRequired = False
      Me.cmbAutorizante3.Key = Nothing
      Me.cmbAutorizante3.LabelAsoc = Nothing
      Me.cmbAutorizante3.Location = New System.Drawing.Point(104, 339)
      Me.cmbAutorizante3.Name = "cmbAutorizante3"
      Me.cmbAutorizante3.Size = New System.Drawing.Size(119, 21)
      Me.cmbAutorizante3.TabIndex = 17
      '
      'cmbSolicitante
      '
      Me.cmbSolicitante.BindearPropiedadControl = "SelectedValue"
      Me.cmbSolicitante.BindearPropiedadEntidad = "IdUsuario"
      Me.cmbSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbSolicitante.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSolicitante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSolicitante.FormattingEnabled = True
      Me.cmbSolicitante.IsPK = False
      Me.cmbSolicitante.IsRequired = True
      Me.cmbSolicitante.Key = Nothing
      Me.cmbSolicitante.LabelAsoc = Me.Label6
      Me.cmbSolicitante.Location = New System.Drawing.Point(105, 47)
      Me.cmbSolicitante.Name = "cmbSolicitante"
      Me.cmbSolicitante.Size = New System.Drawing.Size(119, 21)
      Me.cmbSolicitante.TabIndex = 2
      '
      'cmbAutorizante1
      '
      Me.cmbAutorizante1.BindearPropiedadControl = "SelectedValue"
      Me.cmbAutorizante1.BindearPropiedadEntidad = "IdUsuario1"
      Me.cmbAutorizante1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAutorizante1.Enabled = False
      Me.cmbAutorizante1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbAutorizante1.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAutorizante1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAutorizante1.FormattingEnabled = True
      Me.cmbAutorizante1.IsPK = False
      Me.cmbAutorizante1.IsRequired = False
      Me.cmbAutorizante1.Key = Nothing
      Me.cmbAutorizante1.LabelAsoc = Nothing
      Me.cmbAutorizante1.Location = New System.Drawing.Point(104, 285)
      Me.cmbAutorizante1.Name = "cmbAutorizante1"
      Me.cmbAutorizante1.Size = New System.Drawing.Size(119, 21)
      Me.cmbAutorizante1.TabIndex = 11
      '
      'cmbDpto
      '
      Me.cmbDpto.BindearPropiedadControl = "SelectedItem"
      Me.cmbDpto.BindearPropiedadEntidad = "Dpto"
      Me.cmbDpto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDpto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbDpto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbDpto.FormattingEnabled = True
      Me.cmbDpto.IsPK = False
      Me.cmbDpto.IsRequired = True
      Me.cmbDpto.Items.AddRange(New Object() {"COMPRAS y LOGISTICA", "INGENIERIA", "CALIDAD", "PRODUCCION"})
      Me.cmbDpto.Key = Nothing
      Me.cmbDpto.LabelAsoc = Nothing
      Me.cmbDpto.Location = New System.Drawing.Point(272, 20)
      Me.cmbDpto.Name = "cmbDpto"
      Me.cmbDpto.Size = New System.Drawing.Size(136, 21)
      Me.cmbDpto.TabIndex = 1
      '
      'cmbTiposExcepciones
      '
      Me.cmbTiposExcepciones.BindearPropiedadControl = "SelectedValue"
      Me.cmbTiposExcepciones.BindearPropiedadEntidad = "IdExcepcionTipo"
      Me.cmbTiposExcepciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposExcepciones.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposExcepciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposExcepciones.FormattingEnabled = True
      Me.cmbTiposExcepciones.IsPK = False
      Me.cmbTiposExcepciones.IsRequired = True
      Me.cmbTiposExcepciones.Key = Nothing
      Me.cmbTiposExcepciones.LabelAsoc = Nothing
      Me.cmbTiposExcepciones.Location = New System.Drawing.Point(105, 101)
      Me.cmbTiposExcepciones.Name = "cmbTiposExcepciones"
      Me.cmbTiposExcepciones.Size = New System.Drawing.Size(162, 21)
      Me.cmbTiposExcepciones.TabIndex = 5
      '
      'cmbTipoListaControl
      '
      Me.cmbTipoListaControl.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoListaControl.BindearPropiedadEntidad = "IdListaControlTipo"
      Me.cmbTipoListaControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoListaControl.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoListaControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoListaControl.FormattingEnabled = True
      Me.cmbTipoListaControl.IsPK = False
      Me.cmbTipoListaControl.IsRequired = True
      Me.cmbTipoListaControl.Key = Nothing
      Me.cmbTipoListaControl.LabelAsoc = Nothing
      Me.cmbTipoListaControl.Location = New System.Drawing.Point(105, 74)
      Me.cmbTipoListaControl.Name = "cmbTipoListaControl"
      Me.cmbTipoListaControl.Size = New System.Drawing.Size(162, 21)
      Me.cmbTipoListaControl.TabIndex = 4
      '
      'ExcepcionesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(427, 409)
      Me.Controls.Add(Me.chbAutorizante3)
      Me.Controls.Add(Me.chbAutorizante2)
      Me.Controls.Add(Me.chbAutorizante1)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.TextBox2)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.dtpFechaAutorizante3)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.dtpFechaAutorizante2)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.dtpFechaAutorizante1)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.dtpIngreso)
      Me.Controls.Add(Me.cmbAutorizante2)
      Me.Controls.Add(Me.cmbAutorizante3)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.cmbSolicitante)
      Me.Controls.Add(Me.cmbAutorizante1)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cmbDpto)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbTiposExcepciones)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cmbTipoListaControl)
      Me.Controls.Add(Me.lblNombreTipoCliente)
      Me.Controls.Add(Me.txtNombreExcepcionTipo)
      Me.Controls.Add(Me.lblIdTipoCliente)
      Me.Controls.Add(Me.txtIdExcepcion)
      Me.Name = "ExcepcionesDetalle"
      Me.Text = "Desvíos"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdExcepcion, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.txtNombreExcepcionTipo, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoListaControl, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.Controls.SetChildIndex(Me.cmbTiposExcepciones, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.cmbDpto, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.TextBox1, 0)
      Me.Controls.SetChildIndex(Me.Label4, 0)
      Me.Controls.SetChildIndex(Me.cmbAutorizante1, 0)
      Me.Controls.SetChildIndex(Me.cmbSolicitante, 0)
      Me.Controls.SetChildIndex(Me.Label6, 0)
      Me.Controls.SetChildIndex(Me.cmbAutorizante3, 0)
      Me.Controls.SetChildIndex(Me.cmbAutorizante2, 0)
      Me.Controls.SetChildIndex(Me.dtpIngreso, 0)
      Me.Controls.SetChildIndex(Me.Label9, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaAutorizante1, 0)
      Me.Controls.SetChildIndex(Me.Label10, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaAutorizante2, 0)
      Me.Controls.SetChildIndex(Me.Label11, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaAutorizante3, 0)
      Me.Controls.SetChildIndex(Me.Label12, 0)
      Me.Controls.SetChildIndex(Me.TextBox2, 0)
      Me.Controls.SetChildIndex(Me.Label13, 0)
      Me.Controls.SetChildIndex(Me.chbAutorizante1, 0)
      Me.Controls.SetChildIndex(Me.chbAutorizante2, 0)
      Me.Controls.SetChildIndex(Me.chbAutorizante3, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtNombreExcepcionTipo As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtIdExcepcion As Eniac.Controles.TextBox
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents cmbTipoListaControl As Controles.ComboBox
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents cmbTiposExcepciones As Controles.ComboBox
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents cmbDpto As Controles.ComboBox
   Friend WithEvents Label4 As Controles.Label
   Friend WithEvents TextBox1 As Controles.TextBox
   Friend WithEvents cmbAutorizante1 As Controles.ComboBox
   Friend WithEvents Label6 As Controles.Label
   Friend WithEvents cmbSolicitante As Controles.ComboBox
   Friend WithEvents cmbAutorizante3 As Controles.ComboBox
   Friend WithEvents cmbAutorizante2 As Controles.ComboBox
   Friend WithEvents dtpIngreso As Controles.DateTimePicker
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents Label10 As Controles.Label
   Friend WithEvents dtpFechaAutorizante1 As Controles.DateTimePicker
   Friend WithEvents Label11 As Controles.Label
   Friend WithEvents dtpFechaAutorizante2 As Controles.DateTimePicker
   Friend WithEvents Label12 As Controles.Label
   Friend WithEvents dtpFechaAutorizante3 As Controles.DateTimePicker
   Friend WithEvents Label13 As Controles.Label
   Friend WithEvents TextBox2 As Controles.TextBox
   Friend WithEvents chbAutorizante1 As Controles.CheckBox
   Friend WithEvents chbAutorizante2 As Controles.CheckBox
   Friend WithEvents chbAutorizante3 As Controles.CheckBox
End Class
