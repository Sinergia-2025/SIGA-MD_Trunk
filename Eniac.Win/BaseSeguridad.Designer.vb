<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseSeguridad
   Inherits Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseSeguridad))
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.txtPwd = New Eniac.Controles.TextBox
      Me.lblContrasena = New Eniac.Controles.Label
      Me.txtUsuario = New Eniac.Controles.TextBox
      Me.lblUsuario = New Eniac.Controles.Label
      Me.btnAceptar = New System.Windows.Forms.Button
      Me.btnCancelar = New System.Windows.Forms.Button
      Me.pictureBox2 = New System.Windows.Forms.PictureBox
      Me.pictureBox1 = New System.Windows.Forms.PictureBox
      CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "check2.ico")
      Me.imgIconos.Images.SetKeyName(1, "delete2.ico")
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
      Me.txtPwd.Location = New System.Drawing.Point(95, 62)
      Me.txtPwd.MaxLength = 15
      Me.txtPwd.Name = "txtPwd"
      Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtPwd.Size = New System.Drawing.Size(100, 20)
      Me.txtPwd.TabIndex = 1
      '
      'lblContrasena
      '
      Me.lblContrasena.AutoSize = True
      Me.lblContrasena.Location = New System.Drawing.Point(29, 66)
      Me.lblContrasena.Name = "lblContrasena"
      Me.lblContrasena.Size = New System.Drawing.Size(61, 13)
      Me.lblContrasena.TabIndex = 6
      Me.lblContrasena.Text = "Contraseña"
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
      Me.txtUsuario.Location = New System.Drawing.Point(95, 26)
      Me.txtUsuario.MaxLength = 15
      Me.txtUsuario.Name = "txtUsuario"
      Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
      Me.txtUsuario.TabIndex = 0
      '
      'lblUsuario
      '
      Me.lblUsuario.AutoSize = True
      Me.lblUsuario.Location = New System.Drawing.Point(29, 30)
      Me.lblUsuario.Name = "lblUsuario"
      Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblUsuario.TabIndex = 5
      Me.lblUsuario.Text = "Usuario"
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageKey = "check2.ico"
      Me.btnAceptar.ImageList = Me.imgIconos
      Me.btnAceptar.Location = New System.Drawing.Point(52, 95)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 3
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgIconos
      Me.btnCancelar.Location = New System.Drawing.Point(143, 95)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 4
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'pictureBox2
      '
      Me.pictureBox2.Image = Global.Eniac.Win.My.Resources.Resources.keys
      Me.pictureBox2.Location = New System.Drawing.Point(199, 62)
      Me.pictureBox2.Name = "pictureBox2"
      Me.pictureBox2.Size = New System.Drawing.Size(22, 22)
      Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.pictureBox2.TabIndex = 15
      Me.pictureBox2.TabStop = False
      '
      'pictureBox1
      '
      Me.pictureBox1.Image = Global.Eniac.Win.My.Resources.Resources.user1
      Me.pictureBox1.Location = New System.Drawing.Point(199, 24)
      Me.pictureBox1.Name = "pictureBox1"
      Me.pictureBox1.Size = New System.Drawing.Size(22, 22)
      Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.pictureBox1.TabIndex = 14
      Me.pictureBox1.TabStop = False
      '
      'BaseSeguridad
      '
      Me.AcceptButton = Me.btnAceptar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.Control
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(253, 137)
      Me.Controls.Add(Me.pictureBox2)
      Me.Controls.Add(Me.pictureBox1)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.txtPwd)
      Me.Controls.Add(Me.txtUsuario)
      Me.Controls.Add(Me.lblContrasena)
      Me.Controls.Add(Me.lblUsuario)
      Me.ForeColor = System.Drawing.SystemColors.ControlText
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "BaseSeguridad"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seguridad"
      CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents imgIconos As System.Windows.Forms.ImageList
   Private WithEvents pictureBox2 As System.Windows.Forms.PictureBox
   Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
   Private WithEvents btnCancelar As System.Windows.Forms.Button
   Private WithEvents btnAceptar As System.Windows.Forms.Button
   Private WithEvents lblContrasena As Eniac.Controles.Label
   Private WithEvents lblUsuario As Eniac.Controles.Label
   Public WithEvents txtPwd As Eniac.Controles.TextBox
   Public WithEvents txtUsuario As Eniac.Controles.TextBox
End Class
