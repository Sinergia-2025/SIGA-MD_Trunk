<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfCRMEnvioCorreo
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
      Me.grpCRMGenerarVersion = New System.Windows.Forms.GroupBox()
      Me.txtCRMGenerarVersionPara = New Eniac.Controles.TextBox()
      Me.lblCRMGenerarVersionPara = New Eniac.Controles.Label()
      Me.txtCRMAsuntoGenerarVersion = New Eniac.Controles.TextBox()
      Me.lblCRMAsuntoGenerarVersion = New Eniac.Controles.Label()
      Me.lblCRMAsuntoGenerarVersion_ref1 = New Eniac.Controles.Label()
      Me.lblCRMAsuntoGenerarVersion_ref2 = New Eniac.Controles.Label()
      Me.txtCRMGenerarVersionCopiaOculta = New Eniac.Controles.TextBox()
      Me.lblCRMGenerarVersionCopiaOculta = New Eniac.Controles.Label()
      Me.grpCRMEnvioMasivoMail = New System.Windows.Forms.GroupBox()
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail = New Eniac.Controles.TextBox()
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail = New Eniac.Controles.Label()
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1 = New Eniac.Controles.Label()
      Me.Label14 = New Eniac.Controles.Label()
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2 = New Eniac.Controles.Label()
      Me.txtCRMEnvioMailNovedadesCopiaOculta = New Eniac.Controles.TextBox()
      Me.lblCRMEnvioMailCopiaOculta = New Eniac.Controles.Label()
      Me.cmbConfiguracionMailCRM = New Eniac.Controles.ComboBox()
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3 = New Eniac.Controles.Label()
      Me.grpCRMGenerarVersion.SuspendLayout()
      Me.grpCRMEnvioMasivoMail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grpCRMGenerarVersion
      '
      Me.grpCRMGenerarVersion.Controls.Add(Me.txtCRMGenerarVersionPara)
      Me.grpCRMGenerarVersion.Controls.Add(Me.lblCRMGenerarVersionPara)
      Me.grpCRMGenerarVersion.Controls.Add(Me.txtCRMAsuntoGenerarVersion)
      Me.grpCRMGenerarVersion.Controls.Add(Me.lblCRMAsuntoGenerarVersion_ref1)
      Me.grpCRMGenerarVersion.Controls.Add(Me.lblCRMAsuntoGenerarVersion_ref2)
      Me.grpCRMGenerarVersion.Controls.Add(Me.lblCRMAsuntoGenerarVersion)
      Me.grpCRMGenerarVersion.Controls.Add(Me.txtCRMGenerarVersionCopiaOculta)
      Me.grpCRMGenerarVersion.Controls.Add(Me.lblCRMGenerarVersionCopiaOculta)
      Me.grpCRMGenerarVersion.Location = New System.Drawing.Point(3, 197)
      Me.grpCRMGenerarVersion.Name = "grpCRMGenerarVersion"
      Me.grpCRMGenerarVersion.Size = New System.Drawing.Size(887, 150)
      Me.grpCRMGenerarVersion.TabIndex = 60
      Me.grpCRMGenerarVersion.TabStop = False
      Me.grpCRMGenerarVersion.Text = "Generar Versión"
      '
      'txtCRMGenerarVersionPara
      '
      Me.txtCRMGenerarVersionPara.BindearPropiedadControl = Nothing
      Me.txtCRMGenerarVersionPara.BindearPropiedadEntidad = Nothing
      Me.txtCRMGenerarVersionPara.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCRMGenerarVersionPara.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCRMGenerarVersionPara.Formato = ""
      Me.txtCRMGenerarVersionPara.IsDecimal = False
      Me.txtCRMGenerarVersionPara.IsNumber = False
      Me.txtCRMGenerarVersionPara.IsPK = False
      Me.txtCRMGenerarVersionPara.IsRequired = False
      Me.txtCRMGenerarVersionPara.Key = ""
      Me.txtCRMGenerarVersionPara.LabelAsoc = Me.lblCRMGenerarVersionPara
      Me.txtCRMGenerarVersionPara.Location = New System.Drawing.Point(291, 83)
      Me.txtCRMGenerarVersionPara.MaxLength = 200
      Me.txtCRMGenerarVersionPara.Name = "txtCRMGenerarVersionPara"
      Me.txtCRMGenerarVersionPara.Size = New System.Drawing.Size(373, 20)
      Me.txtCRMGenerarVersionPara.TabIndex = 6
      Me.txtCRMGenerarVersionPara.Tag = "CRMENVIOMAILCOPIAOCULTA"
      '
      'lblCRMGenerarVersionPara
      '
      Me.lblCRMGenerarVersionPara.AutoSize = True
      Me.lblCRMGenerarVersionPara.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMGenerarVersionPara.LabelAsoc = Nothing
      Me.lblCRMGenerarVersionPara.Location = New System.Drawing.Point(60, 86)
      Me.lblCRMGenerarVersionPara.Name = "lblCRMGenerarVersionPara"
      Me.lblCRMGenerarVersionPara.Size = New System.Drawing.Size(170, 13)
      Me.lblCRMGenerarVersionPara.TabIndex = 5
      Me.lblCRMGenerarVersionPara.Text = "Email para envio de nueva versión"
      '
      'txtCRMAsuntoGenerarVersion
      '
      Me.txtCRMAsuntoGenerarVersion.BindearPropiedadControl = Nothing
      Me.txtCRMAsuntoGenerarVersion.BindearPropiedadEntidad = Nothing
      Me.txtCRMAsuntoGenerarVersion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCRMAsuntoGenerarVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCRMAsuntoGenerarVersion.Formato = ""
      Me.txtCRMAsuntoGenerarVersion.IsDecimal = False
      Me.txtCRMAsuntoGenerarVersion.IsNumber = False
      Me.txtCRMAsuntoGenerarVersion.IsPK = False
      Me.txtCRMAsuntoGenerarVersion.IsRequired = False
      Me.txtCRMAsuntoGenerarVersion.Key = ""
      Me.txtCRMAsuntoGenerarVersion.LabelAsoc = Me.lblCRMAsuntoGenerarVersion
      Me.txtCRMAsuntoGenerarVersion.Location = New System.Drawing.Point(291, 19)
      Me.txtCRMAsuntoGenerarVersion.MaxLength = 200
      Me.txtCRMAsuntoGenerarVersion.Name = "txtCRMAsuntoGenerarVersion"
      Me.txtCRMAsuntoGenerarVersion.Size = New System.Drawing.Size(373, 20)
      Me.txtCRMAsuntoGenerarVersion.TabIndex = 1
      '
      'lblCRMAsuntoGenerarVersion
      '
      Me.lblCRMAsuntoGenerarVersion.AutoSize = True
      Me.lblCRMAsuntoGenerarVersion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMAsuntoGenerarVersion.LabelAsoc = Nothing
      Me.lblCRMAsuntoGenerarVersion.Location = New System.Drawing.Point(60, 22)
      Me.lblCRMAsuntoGenerarVersion.Name = "lblCRMAsuntoGenerarVersion"
      Me.lblCRMAsuntoGenerarVersion.Size = New System.Drawing.Size(188, 13)
      Me.lblCRMAsuntoGenerarVersion.TabIndex = 0
      Me.lblCRMAsuntoGenerarVersion.Text = "Asunto envio masivo novedades email"
      '
      'lblCRMAsuntoGenerarVersion_ref1
      '
      Me.lblCRMAsuntoGenerarVersion_ref1.AutoSize = True
      Me.lblCRMAsuntoGenerarVersion_ref1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMAsuntoGenerarVersion_ref1.LabelAsoc = Nothing
      Me.lblCRMAsuntoGenerarVersion_ref1.Location = New System.Drawing.Point(288, 41)
      Me.lblCRMAsuntoGenerarVersion_ref1.Name = "lblCRMAsuntoGenerarVersion_ref1"
      Me.lblCRMAsuntoGenerarVersion_ref1.Size = New System.Drawing.Size(82, 13)
      Me.lblCRMAsuntoGenerarVersion_ref1.TabIndex = 2
      Me.lblCRMAsuntoGenerarVersion_ref1.Text = "{0} = Aplicación"
      '
      'lblCRMAsuntoGenerarVersion_ref2
      '
      Me.lblCRMAsuntoGenerarVersion_ref2.AutoSize = True
      Me.lblCRMAsuntoGenerarVersion_ref2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMAsuntoGenerarVersion_ref2.LabelAsoc = Nothing
      Me.lblCRMAsuntoGenerarVersion_ref2.Location = New System.Drawing.Point(288, 54)
      Me.lblCRMAsuntoGenerarVersion_ref2.Name = "lblCRMAsuntoGenerarVersion_ref2"
      Me.lblCRMAsuntoGenerarVersion_ref2.Size = New System.Drawing.Size(220, 13)
      Me.lblCRMAsuntoGenerarVersion_ref2.TabIndex = 3
      Me.lblCRMAsuntoGenerarVersion_ref2.Text = "{1} = Versión desde / {2} = Fecha de Versión"
      '
      'txtCRMGenerarVersionCopiaOculta
      '
      Me.txtCRMGenerarVersionCopiaOculta.BindearPropiedadControl = Nothing
      Me.txtCRMGenerarVersionCopiaOculta.BindearPropiedadEntidad = Nothing
      Me.txtCRMGenerarVersionCopiaOculta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCRMGenerarVersionCopiaOculta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCRMGenerarVersionCopiaOculta.Formato = ""
      Me.txtCRMGenerarVersionCopiaOculta.IsDecimal = False
      Me.txtCRMGenerarVersionCopiaOculta.IsNumber = False
      Me.txtCRMGenerarVersionCopiaOculta.IsPK = False
      Me.txtCRMGenerarVersionCopiaOculta.IsRequired = False
      Me.txtCRMGenerarVersionCopiaOculta.Key = ""
      Me.txtCRMGenerarVersionCopiaOculta.LabelAsoc = Me.lblCRMGenerarVersionCopiaOculta
      Me.txtCRMGenerarVersionCopiaOculta.Location = New System.Drawing.Point(291, 109)
      Me.txtCRMGenerarVersionCopiaOculta.MaxLength = 200
      Me.txtCRMGenerarVersionCopiaOculta.Name = "txtCRMGenerarVersionCopiaOculta"
      Me.txtCRMGenerarVersionCopiaOculta.Size = New System.Drawing.Size(373, 20)
      Me.txtCRMGenerarVersionCopiaOculta.TabIndex = 8
      Me.txtCRMGenerarVersionCopiaOculta.Tag = "CRMENVIOMAILCOPIAOCULTA"
      '
      'lblCRMGenerarVersionCopiaOculta
      '
      Me.lblCRMGenerarVersionCopiaOculta.AutoSize = True
      Me.lblCRMGenerarVersionCopiaOculta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMGenerarVersionCopiaOculta.LabelAsoc = Nothing
      Me.lblCRMGenerarVersionCopiaOculta.Location = New System.Drawing.Point(60, 112)
      Me.lblCRMGenerarVersionCopiaOculta.Name = "lblCRMGenerarVersionCopiaOculta"
      Me.lblCRMGenerarVersionCopiaOculta.Size = New System.Drawing.Size(231, 13)
      Me.lblCRMGenerarVersionCopiaOculta.TabIndex = 7
      Me.lblCRMGenerarVersionCopiaOculta.Text = "Email copia oculta para envio de nueva versión"
      '
      'grpCRMEnvioMasivoMail
      '
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.txtCRMAsuntoEnvioMasivoNovedadesEmail)
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1)
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.Label14)
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2)
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.lblCRMAsuntoEnvioMasivoNovedadesEmail)
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.txtCRMEnvioMailNovedadesCopiaOculta)
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.cmbConfiguracionMailCRM)
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3)
      Me.grpCRMEnvioMasivoMail.Controls.Add(Me.lblCRMEnvioMailCopiaOculta)
      Me.grpCRMEnvioMasivoMail.Location = New System.Drawing.Point(3, 46)
      Me.grpCRMEnvioMasivoMail.Name = "grpCRMEnvioMasivoMail"
      Me.grpCRMEnvioMasivoMail.Size = New System.Drawing.Size(887, 145)
      Me.grpCRMEnvioMasivoMail.TabIndex = 59
      Me.grpCRMEnvioMasivoMail.TabStop = False
      Me.grpCRMEnvioMasivoMail.Text = "Envio Masivo de Novedades"
      '
      'txtCRMAsuntoEnvioMasivoNovedadesEmail
      '
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.BindearPropiedadControl = Nothing
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.BindearPropiedadEntidad = Nothing
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.Formato = ""
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.IsDecimal = False
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.IsNumber = False
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.IsPK = False
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.IsRequired = False
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.Key = ""
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.LabelAsoc = Me.lblCRMAsuntoEnvioMasivoNovedadesEmail
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.Location = New System.Drawing.Point(291, 19)
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.MaxLength = 200
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.Name = "txtCRMAsuntoEnvioMasivoNovedadesEmail"
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.Size = New System.Drawing.Size(373, 20)
      Me.txtCRMAsuntoEnvioMasivoNovedadesEmail.TabIndex = 1
      '
      'lblCRMAsuntoEnvioMasivoNovedadesEmail
      '
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail.AutoSize = True
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail.LabelAsoc = Nothing
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail.Location = New System.Drawing.Point(103, 22)
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail.Name = "lblCRMAsuntoEnvioMasivoNovedadesEmail"
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail.Size = New System.Drawing.Size(188, 13)
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail.TabIndex = 0
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail.Text = "Asunto envio masivo novedades email"
      '
      'lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1
      '
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1.AutoSize = True
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1.LabelAsoc = Nothing
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1.Location = New System.Drawing.Point(288, 41)
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1.Name = "lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1"
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1.Size = New System.Drawing.Size(82, 13)
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1.TabIndex = 2
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1.Text = "{0} = Aplicación"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label14.LabelAsoc = Nothing
      Me.Label14.Location = New System.Drawing.Point(103, 112)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(157, 13)
      Me.Label14.TabIndex = 7
      Me.Label14.Text = "Cliente Envio Mails Novedades:"
      '
      'lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2
      '
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2.AutoSize = True
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2.LabelAsoc = Nothing
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2.Location = New System.Drawing.Point(288, 54)
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2.Name = "lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2"
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2.Size = New System.Drawing.Size(201, 13)
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2.TabIndex = 3
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2.Text = "{1} = Versión desde / {2} = Versión hasta"
      '
      'txtCRMEnvioMailNovedadesCopiaOculta
      '
      Me.txtCRMEnvioMailNovedadesCopiaOculta.BindearPropiedadControl = Nothing
      Me.txtCRMEnvioMailNovedadesCopiaOculta.BindearPropiedadEntidad = Nothing
      Me.txtCRMEnvioMailNovedadesCopiaOculta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCRMEnvioMailNovedadesCopiaOculta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCRMEnvioMailNovedadesCopiaOculta.Formato = ""
      Me.txtCRMEnvioMailNovedadesCopiaOculta.IsDecimal = False
      Me.txtCRMEnvioMailNovedadesCopiaOculta.IsNumber = False
      Me.txtCRMEnvioMailNovedadesCopiaOculta.IsPK = False
      Me.txtCRMEnvioMailNovedadesCopiaOculta.IsRequired = False
      Me.txtCRMEnvioMailNovedadesCopiaOculta.Key = ""
      Me.txtCRMEnvioMailNovedadesCopiaOculta.LabelAsoc = Me.lblCRMEnvioMailCopiaOculta
      Me.txtCRMEnvioMailNovedadesCopiaOculta.Location = New System.Drawing.Point(291, 83)
      Me.txtCRMEnvioMailNovedadesCopiaOculta.MaxLength = 200
      Me.txtCRMEnvioMailNovedadesCopiaOculta.Name = "txtCRMEnvioMailNovedadesCopiaOculta"
      Me.txtCRMEnvioMailNovedadesCopiaOculta.Size = New System.Drawing.Size(373, 20)
      Me.txtCRMEnvioMailNovedadesCopiaOculta.TabIndex = 6
      Me.txtCRMEnvioMailNovedadesCopiaOculta.Tag = "CRMENVIOMAILCOPIAOCULTA"
      '
      'lblCRMEnvioMailCopiaOculta
      '
      Me.lblCRMEnvioMailCopiaOculta.AutoSize = True
      Me.lblCRMEnvioMailCopiaOculta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMEnvioMailCopiaOculta.LabelAsoc = Nothing
      Me.lblCRMEnvioMailCopiaOculta.Location = New System.Drawing.Point(103, 86)
      Me.lblCRMEnvioMailCopiaOculta.Name = "lblCRMEnvioMailCopiaOculta"
      Me.lblCRMEnvioMailCopiaOculta.Size = New System.Drawing.Size(182, 13)
      Me.lblCRMEnvioMailCopiaOculta.TabIndex = 5
      Me.lblCRMEnvioMailCopiaOculta.Text = "Email copia oculta para envio masivo"
      '
      'cmbConfiguracionMailCRM
      '
      Me.cmbConfiguracionMailCRM.BindearPropiedadControl = Nothing
      Me.cmbConfiguracionMailCRM.BindearPropiedadEntidad = Nothing
      Me.cmbConfiguracionMailCRM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbConfiguracionMailCRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbConfiguracionMailCRM.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbConfiguracionMailCRM.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbConfiguracionMailCRM.FormattingEnabled = True
      Me.cmbConfiguracionMailCRM.IsPK = False
      Me.cmbConfiguracionMailCRM.IsRequired = False
      Me.cmbConfiguracionMailCRM.Key = Nothing
      Me.cmbConfiguracionMailCRM.LabelAsoc = Me.Label14
      Me.cmbConfiguracionMailCRM.Location = New System.Drawing.Point(291, 109)
      Me.cmbConfiguracionMailCRM.Name = "cmbConfiguracionMailCRM"
      Me.cmbConfiguracionMailCRM.Size = New System.Drawing.Size(243, 21)
      Me.cmbConfiguracionMailCRM.TabIndex = 8
      Me.cmbConfiguracionMailCRM.Tag = ""
      '
      'lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3
      '
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3.AutoSize = True
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3.LabelAsoc = Nothing
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3.Location = New System.Drawing.Point(288, 67)
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3.Name = "lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3"
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3.Size = New System.Drawing.Size(193, 13)
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3.TabIndex = 4
      Me.lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3.Text = "{3} = Empresa / {4} = Nombre Fantasía"
      '
      'ucConfCRMEnvioCorreo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.grpCRMGenerarVersion)
      Me.Controls.Add(Me.grpCRMEnvioMasivoMail)
      Me.Name = "ucConfCRMEnvioCorreo"
      Me.Controls.SetChildIndex(Me.grpCRMEnvioMasivoMail, 0)
      Me.Controls.SetChildIndex(Me.grpCRMGenerarVersion, 0)
      Me.grpCRMGenerarVersion.ResumeLayout(False)
      Me.grpCRMGenerarVersion.PerformLayout()
      Me.grpCRMEnvioMasivoMail.ResumeLayout(False)
      Me.grpCRMEnvioMasivoMail.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents grpCRMGenerarVersion As GroupBox
   Friend WithEvents txtCRMGenerarVersionPara As Controles.TextBox
   Friend WithEvents lblCRMGenerarVersionPara As Controles.Label
   Friend WithEvents txtCRMAsuntoGenerarVersion As Controles.TextBox
   Friend WithEvents lblCRMAsuntoGenerarVersion As Controles.Label
   Friend WithEvents lblCRMAsuntoGenerarVersion_ref1 As Controles.Label
   Friend WithEvents lblCRMAsuntoGenerarVersion_ref2 As Controles.Label
   Friend WithEvents txtCRMGenerarVersionCopiaOculta As Controles.TextBox
   Friend WithEvents lblCRMGenerarVersionCopiaOculta As Controles.Label
   Friend WithEvents grpCRMEnvioMasivoMail As GroupBox
   Friend WithEvents txtCRMAsuntoEnvioMasivoNovedadesEmail As Controles.TextBox
   Friend WithEvents lblCRMAsuntoEnvioMasivoNovedadesEmail As Controles.Label
   Friend WithEvents lblCRMAsuntoEnvioMasivoNovedadesEmail_ref1 As Controles.Label
   Friend WithEvents Label14 As Controles.Label
   Friend WithEvents lblCRMAsuntoEnvioMasivoNovedadesEmail_ref2 As Controles.Label
   Friend WithEvents txtCRMEnvioMailNovedadesCopiaOculta As Controles.TextBox
   Friend WithEvents lblCRMEnvioMailCopiaOculta As Controles.Label
   Friend WithEvents cmbConfiguracionMailCRM As Controles.ComboBox
   Friend WithEvents lblCRMAsuntoEnvioMasivoNovedadesEmail_ref3 As Controles.Label
End Class
