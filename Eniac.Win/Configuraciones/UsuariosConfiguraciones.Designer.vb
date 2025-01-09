<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsuariosConfiguraciones
   Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UsuariosConfiguraciones))
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
      Me.lblUsuario = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tslEstadoServicio = New System.Windows.Forms.ToolStripLabel()
      Me.tsbGuardar = New System.Windows.Forms.ToolStripButton()
      Me.tsbProbar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.grbCorreoElectronico.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
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
      Me.grbCorreoElectronico.Location = New System.Drawing.Point(12, 65)
      Me.grbCorreoElectronico.Name = "grbCorreoElectronico"
      Me.grbCorreoElectronico.Size = New System.Drawing.Size(360, 244)
      Me.grbCorreoElectronico.TabIndex = 1
      Me.grbCorreoElectronico.TabStop = False
      Me.grbCorreoElectronico.Text = "Correo Electronico"
      '
      'chbUtilizaComoPredeterminado
      '
      Me.chbUtilizaComoPredeterminado.BindearPropiedadControl = Nothing
      Me.chbUtilizaComoPredeterminado.BindearPropiedadEntidad = Nothing
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
      Me.lblCantidadMailsPorHora.Location = New System.Drawing.Point(166, 200)
      Me.lblCantidadMailsPorHora.Name = "lblCantidadMailsPorHora"
      Me.lblCantidadMailsPorHora.Size = New System.Drawing.Size(115, 13)
      Me.lblCantidadMailsPorHora.TabIndex = 15
      Me.lblCantidadMailsPorHora.Text = "Cant. Correos por Hora"
      '
      'lblCantidadMailsPorMinuto
      '
      Me.lblCantidadMailsPorMinuto.AutoSize = True
      Me.lblCantidadMailsPorMinuto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCantidadMailsPorMinuto.Location = New System.Drawing.Point(166, 162)
      Me.lblCantidadMailsPorMinuto.Name = "lblCantidadMailsPorMinuto"
      Me.lblCantidadMailsPorMinuto.Size = New System.Drawing.Size(124, 13)
      Me.lblCantidadMailsPorMinuto.TabIndex = 14
      Me.lblCantidadMailsPorMinuto.Text = "Cant. Correos por Minuto"
      '
      'txtCantidadMailsPorHora
      '
      Me.txtCantidadMailsPorHora.BindearPropiedadControl = Nothing
      Me.txtCantidadMailsPorHora.BindearPropiedadEntidad = Nothing
      Me.txtCantidadMailsPorHora.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadMailsPorHora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadMailsPorHora.Formato = ""
      Me.txtCantidadMailsPorHora.IsDecimal = False
      Me.txtCantidadMailsPorHora.IsNumber = True
      Me.txtCantidadMailsPorHora.IsPK = False
      Me.txtCantidadMailsPorHora.IsRequired = False
      Me.txtCantidadMailsPorHora.Key = ""
      Me.txtCantidadMailsPorHora.LabelAsoc = Me.lblCantidadMailsPorHora
      Me.txtCantidadMailsPorHora.Location = New System.Drawing.Point(291, 193)
      Me.txtCantidadMailsPorHora.MaxLength = 4
      Me.txtCantidadMailsPorHora.Name = "txtCantidadMailsPorHora"
      Me.txtCantidadMailsPorHora.Size = New System.Drawing.Size(47, 20)
      Me.txtCantidadMailsPorHora.TabIndex = 9
      Me.txtCantidadMailsPorHora.Tag = "CANTEMAILSPORHORA"
      Me.txtCantidadMailsPorHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCantidadMailsPorMinuto
      '
      Me.txtCantidadMailsPorMinuto.BindearPropiedadControl = Nothing
      Me.txtCantidadMailsPorMinuto.BindearPropiedadEntidad = Nothing
      Me.txtCantidadMailsPorMinuto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadMailsPorMinuto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadMailsPorMinuto.Formato = ""
      Me.txtCantidadMailsPorMinuto.IsDecimal = False
      Me.txtCantidadMailsPorMinuto.IsNumber = True
      Me.txtCantidadMailsPorMinuto.IsPK = False
      Me.txtCantidadMailsPorMinuto.IsRequired = False
      Me.txtCantidadMailsPorMinuto.Key = ""
      Me.txtCantidadMailsPorMinuto.LabelAsoc = Me.lblCantidadMailsPorMinuto
      Me.txtCantidadMailsPorMinuto.Location = New System.Drawing.Point(290, 155)
      Me.txtCantidadMailsPorMinuto.MaxLength = 3
      Me.txtCantidadMailsPorMinuto.Name = "txtCantidadMailsPorMinuto"
      Me.txtCantidadMailsPorMinuto.Size = New System.Drawing.Size(47, 20)
      Me.txtCantidadMailsPorMinuto.TabIndex = 8
      Me.txtCantidadMailsPorMinuto.Tag = "CANTEMAILSPORMINUTO"
      Me.txtCantidadMailsPorMinuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbMailRequiereSSL
      '
      Me.chbMailRequiereSSL.BindearPropiedadControl = Nothing
      Me.chbMailRequiereSSL.BindearPropiedadEntidad = Nothing
      Me.chbMailRequiereSSL.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMailRequiereSSL.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMailRequiereSSL.IsPK = False
      Me.chbMailRequiereSSL.IsRequired = False
      Me.chbMailRequiereSSL.Key = Nothing
      Me.chbMailRequiereSSL.LabelAsoc = Nothing
      Me.chbMailRequiereSSL.Location = New System.Drawing.Point(16, 152)
      Me.chbMailRequiereSSL.Name = "chbMailRequiereSSL"
      Me.chbMailRequiereSSL.Size = New System.Drawing.Size(144, 35)
      Me.chbMailRequiereSSL.TabIndex = 6
      Me.chbMailRequiereSSL.Tag = "MAILREQUIERESSL"
      Me.chbMailRequiereSSL.Text = "Requiere una conexión segura (SSL)"
      Me.chbMailRequiereSSL.UseVisualStyleBackColor = True
      '
      'chbMailRequiereAutenticacion
      '
      Me.chbMailRequiereAutenticacion.BindearPropiedadControl = Nothing
      Me.chbMailRequiereAutenticacion.BindearPropiedadEntidad = Nothing
      Me.chbMailRequiereAutenticacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMailRequiereAutenticacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMailRequiereAutenticacion.IsPK = False
      Me.chbMailRequiereAutenticacion.IsRequired = False
      Me.chbMailRequiereAutenticacion.Key = Nothing
      Me.chbMailRequiereAutenticacion.LabelAsoc = Nothing
      Me.chbMailRequiereAutenticacion.Location = New System.Drawing.Point(16, 187)
      Me.chbMailRequiereAutenticacion.Name = "chbMailRequiereAutenticacion"
      Me.chbMailRequiereAutenticacion.Size = New System.Drawing.Size(144, 41)
      Me.chbMailRequiereAutenticacion.TabIndex = 7
      Me.chbMailRequiereAutenticacion.Tag = "MAILREQUIEREAUTENTICACION"
      Me.chbMailRequiereAutenticacion.Text = "El Servidor Requiere autenticación"
      Me.chbMailRequiereAutenticacion.UseVisualStyleBackColor = True
      '
      'txtMailPuertoSalida
      '
      Me.txtMailPuertoSalida.BindearPropiedadControl = Nothing
      Me.txtMailPuertoSalida.BindearPropiedadEntidad = Nothing
      Me.txtMailPuertoSalida.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailPuertoSalida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailPuertoSalida.Formato = ""
      Me.txtMailPuertoSalida.IsDecimal = False
      Me.txtMailPuertoSalida.IsNumber = True
      Me.txtMailPuertoSalida.IsPK = False
      Me.txtMailPuertoSalida.IsRequired = False
      Me.txtMailPuertoSalida.Key = ""
      Me.txtMailPuertoSalida.LabelAsoc = Me.lblMailServidor
      Me.txtMailPuertoSalida.Location = New System.Drawing.Point(308, 49)
      Me.txtMailPuertoSalida.MaxLength = 4
      Me.txtMailPuertoSalida.Name = "txtMailPuertoSalida"
      Me.txtMailPuertoSalida.Size = New System.Drawing.Size(30, 20)
      Me.txtMailPuertoSalida.TabIndex = 2
      Me.txtMailPuertoSalida.Tag = "MAILPUERTOSALIDA"
      Me.txtMailPuertoSalida.Text = "25"
      '
      'lblMailServidor
      '
      Me.lblMailServidor.AutoSize = True
      Me.lblMailServidor.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailServidor.Location = New System.Drawing.Point(13, 53)
      Me.lblMailServidor.Name = "lblMailServidor"
      Me.lblMailServidor.Size = New System.Drawing.Size(79, 13)
      Me.lblMailServidor.TabIndex = 10
      Me.lblMailServidor.Text = "Servidor SMTP"
      '
      'txtMailDireccion
      '
      Me.txtMailDireccion.BindearPropiedadControl = Nothing
      Me.txtMailDireccion.BindearPropiedadEntidad = Nothing
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
      Me.txtMailDireccion.Size = New System.Drawing.Size(220, 20)
      Me.txtMailDireccion.TabIndex = 3
      Me.txtMailDireccion.Tag = "MAILDIRECCION"
      '
      'lblMailDireccion
      '
      Me.lblMailDireccion.AutoSize = True
      Me.lblMailDireccion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailDireccion.Location = New System.Drawing.Point(13, 80)
      Me.lblMailDireccion.Name = "lblMailDireccion"
      Me.lblMailDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblMailDireccion.TabIndex = 11
      Me.lblMailDireccion.Text = "Dirección"
      '
      'txtMailPassword
      '
      Me.txtMailPassword.BindearPropiedadControl = Nothing
      Me.txtMailPassword.BindearPropiedadEntidad = Nothing
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
      Me.txtMailPassword.Size = New System.Drawing.Size(220, 20)
      Me.txtMailPassword.TabIndex = 5
      Me.txtMailPassword.Tag = ""
      '
      'lblMailPassword
      '
      Me.lblMailPassword.AutoSize = True
      Me.lblMailPassword.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailPassword.Location = New System.Drawing.Point(13, 130)
      Me.lblMailPassword.Name = "lblMailPassword"
      Me.lblMailPassword.Size = New System.Drawing.Size(53, 13)
      Me.lblMailPassword.TabIndex = 13
      Me.lblMailPassword.Text = "Password"
      '
      'txtMailUsuario
      '
      Me.txtMailUsuario.BindearPropiedadControl = Nothing
      Me.txtMailUsuario.BindearPropiedadEntidad = Nothing
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
      Me.txtMailUsuario.Size = New System.Drawing.Size(220, 20)
      Me.txtMailUsuario.TabIndex = 4
      Me.txtMailUsuario.Tag = ""
      '
      'lblMailUsuario
      '
      Me.lblMailUsuario.AutoSize = True
      Me.lblMailUsuario.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailUsuario.Location = New System.Drawing.Point(13, 104)
      Me.lblMailUsuario.Name = "lblMailUsuario"
      Me.lblMailUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblMailUsuario.TabIndex = 12
      Me.lblMailUsuario.Text = "Usuario"
      '
      'txtMailServidor
      '
      Me.txtMailServidor.BindearPropiedadControl = Nothing
      Me.txtMailServidor.BindearPropiedadEntidad = Nothing
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
      Me.txtMailServidor.Size = New System.Drawing.Size(185, 20)
      Me.txtMailServidor.TabIndex = 1
      Me.txtMailServidor.Tag = "MAILSERVIDOR"
      '
      'lblUsuario
      '
      Me.lblUsuario.AutoSize = True
      Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblUsuario.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblUsuario.Location = New System.Drawing.Point(9, 33)
      Me.lblUsuario.Name = "lblUsuario"
      Me.lblUsuario.Size = New System.Drawing.Size(136, 17)
      Me.lblUsuario.TabIndex = 0
      Me.lblUsuario.Text = "Datos del usuario"
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslEstadoServicio, Me.tsbGuardar, Me.ToolStripSeparator1, Me.tsbProbar, Me.ToolStripSeparator4, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(386, 29)
      Me.tstBarra.TabIndex = 2
      Me.tstBarra.Text = "ToolStrip1"
      '
      'tslEstadoServicio
      '
      Me.tslEstadoServicio.Name = "tslEstadoServicio"
      Me.tslEstadoServicio.Size = New System.Drawing.Size(0, 26)
      '
      'tsbGuardar
      '
      Me.tsbGuardar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGuardar.Name = "tsbGuardar"
      Me.tsbGuardar.Size = New System.Drawing.Size(75, 26)
      Me.tsbGuardar.Text = "Guardar"
      '
      'tsbProbar
      '
      Me.tsbProbar.Image = Global.Eniac.Win.My.Resources.Resources.play_ok_32
      Me.tsbProbar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbProbar.Name = "tsbProbar"
      Me.tsbProbar.Size = New System.Drawing.Size(68, 26)
      Me.tsbProbar.Text = "Probar"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      Me.tsbCerrar.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'UsuariosConfiguraciones
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 326)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.lblUsuario)
      Me.Controls.Add(Me.grbCorreoElectronico)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "UsuariosConfiguraciones"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Mis Configuraciones"
      Me.grbCorreoElectronico.ResumeLayout(False)
      Me.grbCorreoElectronico.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbCorreoElectronico As System.Windows.Forms.GroupBox
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
   Friend WithEvents lblUsuario As Eniac.Controles.Label
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tslEstadoServicio As System.Windows.Forms.ToolStripLabel
   Friend WithEvents tsbGuardar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbProbar As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbUtilizaComoPredeterminado As Eniac.Controles.CheckBox
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
