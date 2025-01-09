<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackupsDBySegu
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BackupsDBySegu))
      Me.txtBaseDestino = New Eniac.Controles.TextBox
      Me.lblBaseDestino = New Eniac.Controles.Label
      Me.btnCopiar = New Eniac.Controles.Button
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New Eniac.Controles.Button
      Me.grbBase = New System.Windows.Forms.GroupBox
      Me.btnBuscarDestino = New Eniac.Controles.Button
      Me.fbdBase = New System.Windows.Forms.FolderBrowserDialog
      Me.lblCopiando = New Eniac.Controles.Label
      Me.prbCopiando = New System.Windows.Forms.ProgressBar
      Me.grbBaseSegu = New System.Windows.Forms.GroupBox
      Me.btnBuscarDestinoSegu = New Eniac.Controles.Button
      Me.txtBaseDestinoSegu = New Eniac.Controles.TextBox
      Me.Label1 = New Eniac.Controles.Label
      Me.chbBaseSeguridad = New Eniac.Controles.CheckBox
      Me.grbBase.SuspendLayout()
      Me.grbBaseSegu.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtBaseDestino
      '
      Me.txtBaseDestino.BindearPropiedadControl = Nothing
      Me.txtBaseDestino.BindearPropiedadEntidad = Nothing
      Me.txtBaseDestino.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBaseDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBaseDestino.Formato = ""
      Me.txtBaseDestino.IsDecimal = False
      Me.txtBaseDestino.IsNumber = False
      Me.txtBaseDestino.IsPK = False
      Me.txtBaseDestino.IsRequired = False
      Me.txtBaseDestino.Key = ""
      Me.txtBaseDestino.LabelAsoc = Me.lblBaseDestino
      Me.txtBaseDestino.Location = New System.Drawing.Point(59, 21)
      Me.txtBaseDestino.Name = "txtBaseDestino"
      Me.txtBaseDestino.ReadOnly = True
      Me.txtBaseDestino.Size = New System.Drawing.Size(431, 20)
      Me.txtBaseDestino.TabIndex = 3
      '
      'lblBaseDestino
      '
      Me.lblBaseDestino.AutoSize = True
      Me.lblBaseDestino.Location = New System.Drawing.Point(10, 24)
      Me.lblBaseDestino.Name = "lblBaseDestino"
      Me.lblBaseDestino.Size = New System.Drawing.Size(43, 13)
      Me.lblBaseDestino.TabIndex = 2
      Me.lblBaseDestino.Text = "Destino"
      '
      'btnCopiar
      '
      Me.btnCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCopiar.ImageKey = "disk_blue.ico"
      Me.btnCopiar.ImageList = Me.imgIconos
      Me.btnCopiar.Location = New System.Drawing.Point(367, 149)
      Me.btnCopiar.Name = "btnCopiar"
      Me.btnCopiar.Size = New System.Drawing.Size(85, 30)
      Me.btnCopiar.TabIndex = 6
      Me.btnCopiar.Text = "&Backup"
      Me.btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCopiar.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "disk_blue.ico")
      Me.imgIconos.Images.SetKeyName(1, "delete2.ico")
      Me.imgIconos.Images.SetKeyName(2, "folder.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgIconos
      Me.btnCancelar.Location = New System.Drawing.Point(458, 149)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 7
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'grbBase
      '
      Me.grbBase.Controls.Add(Me.btnBuscarDestino)
      Me.grbBase.Controls.Add(Me.txtBaseDestino)
      Me.grbBase.Controls.Add(Me.lblBaseDestino)
      Me.grbBase.Location = New System.Drawing.Point(12, 6)
      Me.grbBase.Name = "grbBase"
      Me.grbBase.Size = New System.Drawing.Size(528, 56)
      Me.grbBase.TabIndex = 8
      Me.grbBase.TabStop = False
      Me.grbBase.Text = "Base"
      '
      'btnBuscarDestino
      '
      Me.btnBuscarDestino.ImageKey = "folder.ico"
      Me.btnBuscarDestino.ImageList = Me.imgIconos
      Me.btnBuscarDestino.Location = New System.Drawing.Point(490, 19)
      Me.btnBuscarDestino.Name = "btnBuscarDestino"
      Me.btnBuscarDestino.Size = New System.Drawing.Size(29, 23)
      Me.btnBuscarDestino.TabIndex = 5
      Me.btnBuscarDestino.UseVisualStyleBackColor = True
      '
      'lblCopiando
      '
      Me.lblCopiando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCopiando.AutoSize = True
      Me.lblCopiando.Location = New System.Drawing.Point(12, 160)
      Me.lblCopiando.Name = "lblCopiando"
      Me.lblCopiando.Size = New System.Drawing.Size(61, 13)
      Me.lblCopiando.TabIndex = 9
      Me.lblCopiando.Text = "Copiando..."
      Me.lblCopiando.Visible = False
      '
      'prbCopiando
      '
      Me.prbCopiando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbCopiando.Location = New System.Drawing.Point(75, 155)
      Me.prbCopiando.Name = "prbCopiando"
      Me.prbCopiando.Size = New System.Drawing.Size(272, 23)
      Me.prbCopiando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbCopiando.TabIndex = 10
      Me.prbCopiando.Visible = False
      '
      'grbBaseSegu
      '
      Me.grbBaseSegu.Controls.Add(Me.btnBuscarDestinoSegu)
      Me.grbBaseSegu.Controls.Add(Me.txtBaseDestinoSegu)
      Me.grbBaseSegu.Controls.Add(Me.Label1)
      Me.grbBaseSegu.Enabled = False
      Me.grbBaseSegu.Location = New System.Drawing.Point(13, 85)
      Me.grbBaseSegu.Name = "grbBaseSegu"
      Me.grbBaseSegu.Size = New System.Drawing.Size(528, 56)
      Me.grbBaseSegu.TabIndex = 11
      Me.grbBaseSegu.TabStop = False
      Me.grbBaseSegu.Text = "Base Seguridad"
      '
      'btnBuscarDestinoSegu
      '
      Me.btnBuscarDestinoSegu.ImageKey = "folder.ico"
      Me.btnBuscarDestinoSegu.ImageList = Me.imgIconos
      Me.btnBuscarDestinoSegu.Location = New System.Drawing.Point(490, 19)
      Me.btnBuscarDestinoSegu.Name = "btnBuscarDestinoSegu"
      Me.btnBuscarDestinoSegu.Size = New System.Drawing.Size(29, 23)
      Me.btnBuscarDestinoSegu.TabIndex = 5
      Me.btnBuscarDestinoSegu.UseVisualStyleBackColor = True
      '
      'txtBaseDestinoSegu
      '
      Me.txtBaseDestinoSegu.BindearPropiedadControl = Nothing
      Me.txtBaseDestinoSegu.BindearPropiedadEntidad = Nothing
      Me.txtBaseDestinoSegu.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBaseDestinoSegu.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBaseDestinoSegu.Formato = ""
      Me.txtBaseDestinoSegu.IsDecimal = False
      Me.txtBaseDestinoSegu.IsNumber = False
      Me.txtBaseDestinoSegu.IsPK = False
      Me.txtBaseDestinoSegu.IsRequired = False
      Me.txtBaseDestinoSegu.Key = ""
      Me.txtBaseDestinoSegu.LabelAsoc = Me.Label1
      Me.txtBaseDestinoSegu.Location = New System.Drawing.Point(59, 21)
      Me.txtBaseDestinoSegu.Name = "txtBaseDestinoSegu"
      Me.txtBaseDestinoSegu.ReadOnly = True
      Me.txtBaseDestinoSegu.Size = New System.Drawing.Size(431, 20)
      Me.txtBaseDestinoSegu.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(10, 24)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(43, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Destino"
      '
      'chbBaseSeguridad
      '
      Me.chbBaseSeguridad.AutoSize = True
      Me.chbBaseSeguridad.BindearPropiedadControl = Nothing
      Me.chbBaseSeguridad.BindearPropiedadEntidad = Nothing
      Me.chbBaseSeguridad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbBaseSeguridad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbBaseSeguridad.IsPK = False
      Me.chbBaseSeguridad.IsRequired = False
      Me.chbBaseSeguridad.Key = Nothing
      Me.chbBaseSeguridad.LabelAsoc = Nothing
      Me.chbBaseSeguridad.Location = New System.Drawing.Point(13, 68)
      Me.chbBaseSeguridad.Name = "chbBaseSeguridad"
      Me.chbBaseSeguridad.Size = New System.Drawing.Size(216, 17)
      Me.chbBaseSeguridad.TabIndex = 6
      Me.chbBaseSeguridad.Text = "Agregar al backup la base de Seguridad"
      Me.chbBaseSeguridad.UseVisualStyleBackColor = True
      '
      'Backups
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(565, 191)
      Me.Controls.Add(Me.chbBaseSeguridad)
      Me.Controls.Add(Me.grbBaseSegu)
      Me.Controls.Add(Me.prbCopiando)
      Me.Controls.Add(Me.lblCopiando)
      Me.Controls.Add(Me.grbBase)
      Me.Controls.Add(Me.btnCopiar)
      Me.Controls.Add(Me.btnCancelar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Backups"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Backup"
      Me.grbBase.ResumeLayout(False)
      Me.grbBase.PerformLayout()
      Me.grbBaseSegu.ResumeLayout(False)
      Me.grbBaseSegu.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtBaseDestino As Eniac.Controles.TextBox
   Friend WithEvents lblBaseDestino As Eniac.Controles.Label
   Friend WithEvents btnCopiar As Eniac.Controles.Button
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents grbBase As System.Windows.Forms.GroupBox
   Friend WithEvents btnBuscarDestino As Eniac.Controles.Button
   Friend WithEvents fbdBase As System.Windows.Forms.FolderBrowserDialog
   Friend WithEvents lblCopiando As Eniac.Controles.Label
   Friend WithEvents prbCopiando As System.Windows.Forms.ProgressBar
   Friend WithEvents grbBaseSegu As System.Windows.Forms.GroupBox
   Friend WithEvents btnBuscarDestinoSegu As Eniac.Controles.Button
   Friend WithEvents txtBaseDestinoSegu As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbBaseSeguridad As Eniac.Controles.CheckBox
End Class
