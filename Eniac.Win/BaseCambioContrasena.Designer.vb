<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseCambioContrasena
   Inherits Eniac.Win.BaseForm

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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseCambioContrasena))
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCerrar = New System.Windows.Forms.Button
      Me.btnCambiar = New System.Windows.Forms.Button
      Me.txtPwdActual = New Eniac.Controles.TextBox
      Me.lblContrasena = New Eniac.Controles.Label
      Me.txtUsuario = New Eniac.Controles.TextBox
      Me.lblUsuario = New Eniac.Controles.Label
      Me.txtPwdNueva = New Eniac.Controles.TextBox
      Me.lblContraNueva = New Eniac.Controles.Label
      Me.txtPwdNueva2 = New Eniac.Controles.TextBox
      Me.lblContraNueva2 = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "disk_blue_ok.ico")
      Me.imgIconos.Images.SetKeyName(1, "redo.ico")
      '
      'btnCerrar
      '
      Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCerrar.ImageKey = "redo.ico"
      Me.btnCerrar.ImageList = Me.imgIconos
      Me.btnCerrar.Location = New System.Drawing.Point(159, 124)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(80, 30)
      Me.btnCerrar.TabIndex = 5
      Me.btnCerrar.Text = "&Cerrar"
      Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCambiar
      '
      Me.btnCambiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCambiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCambiar.ImageKey = "disk_blue_ok.ico"
      Me.btnCambiar.ImageList = Me.imgIconos
      Me.btnCambiar.Location = New System.Drawing.Point(68, 124)
      Me.btnCambiar.Name = "btnCambiar"
      Me.btnCambiar.Size = New System.Drawing.Size(80, 30)
      Me.btnCambiar.TabIndex = 4
      Me.btnCambiar.Text = "&Cambiar"
      Me.btnCambiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPwdActual
      '
      Me.txtPwdActual.BindearPropiedadControl = Nothing
      Me.txtPwdActual.BindearPropiedadEntidad = Nothing
      Me.txtPwdActual.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPwdActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPwdActual.Formato = ""
      Me.txtPwdActual.IsDecimal = False
      Me.txtPwdActual.IsNumber = False
      Me.txtPwdActual.IsPK = False
      Me.txtPwdActual.IsRequired = False
      Me.txtPwdActual.Key = ""
      Me.txtPwdActual.LabelAsoc = Me.lblContrasena
      Me.txtPwdActual.Location = New System.Drawing.Point(113, 38)
      Me.txtPwdActual.MaxLength = 15
      Me.txtPwdActual.Name = "txtPwdActual"
      Me.txtPwdActual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtPwdActual.Size = New System.Drawing.Size(125, 20)
      Me.txtPwdActual.TabIndex = 1
      '
      'lblContrasena
      '
      Me.lblContrasena.AutoSize = True
      Me.lblContrasena.Location = New System.Drawing.Point(14, 42)
      Me.lblContrasena.Name = "lblContrasena"
      Me.lblContrasena.Size = New System.Drawing.Size(93, 13)
      Me.lblContrasena.TabIndex = 7
      Me.lblContrasena.Text = "Contraseña actual"
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
      Me.txtUsuario.Location = New System.Drawing.Point(113, 12)
      Me.txtUsuario.MaxLength = 15
      Me.txtUsuario.Name = "txtUsuario"
      Me.txtUsuario.Size = New System.Drawing.Size(125, 20)
      Me.txtUsuario.TabIndex = 0
      '
      'lblUsuario
      '
      Me.lblUsuario.AutoSize = True
      Me.lblUsuario.Location = New System.Drawing.Point(64, 16)
      Me.lblUsuario.Name = "lblUsuario"
      Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblUsuario.TabIndex = 6
      Me.lblUsuario.Text = "Usuario"
      '
      'txtPwdNueva
      '
      Me.txtPwdNueva.BindearPropiedadControl = Nothing
      Me.txtPwdNueva.BindearPropiedadEntidad = Nothing
      Me.txtPwdNueva.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPwdNueva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPwdNueva.Formato = ""
      Me.txtPwdNueva.IsDecimal = False
      Me.txtPwdNueva.IsNumber = False
      Me.txtPwdNueva.IsPK = False
      Me.txtPwdNueva.IsRequired = False
      Me.txtPwdNueva.Key = ""
      Me.txtPwdNueva.LabelAsoc = Me.lblContraNueva
      Me.txtPwdNueva.Location = New System.Drawing.Point(113, 64)
      Me.txtPwdNueva.MaxLength = 15
      Me.txtPwdNueva.Name = "txtPwdNueva"
      Me.txtPwdNueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtPwdNueva.Size = New System.Drawing.Size(125, 20)
      Me.txtPwdNueva.TabIndex = 2
      '
      'lblContraNueva
      '
      Me.lblContraNueva.AutoSize = True
      Me.lblContraNueva.Location = New System.Drawing.Point(14, 68)
      Me.lblContraNueva.Name = "lblContraNueva"
      Me.lblContraNueva.Size = New System.Drawing.Size(94, 13)
      Me.lblContraNueva.TabIndex = 8
      Me.lblContraNueva.Text = "Contraseña nueva"
      '
      'txtPwdNueva2
      '
      Me.txtPwdNueva2.BindearPropiedadControl = Nothing
      Me.txtPwdNueva2.BindearPropiedadEntidad = Nothing
      Me.txtPwdNueva2.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPwdNueva2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPwdNueva2.Formato = ""
      Me.txtPwdNueva2.IsDecimal = False
      Me.txtPwdNueva2.IsNumber = False
      Me.txtPwdNueva2.IsPK = False
      Me.txtPwdNueva2.IsRequired = False
      Me.txtPwdNueva2.Key = ""
      Me.txtPwdNueva2.LabelAsoc = Me.lblContraNueva2
      Me.txtPwdNueva2.Location = New System.Drawing.Point(113, 90)
      Me.txtPwdNueva2.MaxLength = 15
      Me.txtPwdNueva2.Name = "txtPwdNueva2"
      Me.txtPwdNueva2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtPwdNueva2.Size = New System.Drawing.Size(125, 20)
      Me.txtPwdNueva2.TabIndex = 3
      '
      'lblContraNueva2
      '
      Me.lblContraNueva2.AutoSize = True
      Me.lblContraNueva2.Location = New System.Drawing.Point(14, 94)
      Me.lblContraNueva2.Name = "lblContraNueva2"
      Me.lblContraNueva2.Size = New System.Drawing.Size(97, 13)
      Me.lblContraNueva2.TabIndex = 9
      Me.lblContraNueva2.Text = "Repetir contraseña"
      '
      'BaseCambioContrasena
      '
      Me.AcceptButton = Me.btnCambiar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.Control
      Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
      Me.CancelButton = Me.btnCerrar
      Me.ClientSize = New System.Drawing.Size(250, 166)
      Me.ControlBox = False
      Me.Controls.Add(Me.txtPwdNueva2)
      Me.Controls.Add(Me.lblContraNueva2)
      Me.Controls.Add(Me.txtPwdNueva)
      Me.Controls.Add(Me.lblContraNueva)
      Me.Controls.Add(Me.txtPwdActual)
      Me.Controls.Add(Me.txtUsuario)
      Me.Controls.Add(Me.lblContrasena)
      Me.Controls.Add(Me.lblUsuario)
      Me.Controls.Add(Me.btnCerrar)
      Me.Controls.Add(Me.btnCambiar)
      Me.DoubleBuffered = True
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "BaseCambioContrasena"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambio de contraseña"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents imgIconos As System.Windows.Forms.ImageList
   Private WithEvents btnCerrar As System.Windows.Forms.Button
   Private WithEvents btnCambiar As System.Windows.Forms.Button
   Protected Friend WithEvents txtPwdActual As Eniac.Controles.TextBox
   Private WithEvents lblContrasena As Eniac.Controles.Label
   Protected Friend WithEvents txtUsuario As Eniac.Controles.TextBox
   Private WithEvents lblUsuario As Eniac.Controles.Label
   Protected Friend WithEvents txtPwdNueva As Eniac.Controles.TextBox
   Private WithEvents lblContraNueva As Eniac.Controles.Label
   Protected Friend WithEvents txtPwdNueva2 As Eniac.Controles.TextBox
   Private WithEvents lblContraNueva2 As Eniac.Controles.Label
End Class
