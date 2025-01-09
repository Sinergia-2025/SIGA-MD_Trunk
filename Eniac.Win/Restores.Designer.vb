<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Restores
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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Restores))
      Me.txtBaseOrigen = New Eniac.Controles.TextBox
      Me.lblOrigen = New Eniac.Controles.Label
      Me.btnCopiar = New Eniac.Controles.Button
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New Eniac.Controles.Button
      Me.grbBase = New System.Windows.Forms.GroupBox
      Me.btnBuscarDestino = New Eniac.Controles.Button
      Me.imgIconos32 = New System.Windows.Forms.ImageList(Me.components)
      Me.lblCopiando = New Eniac.Controles.Label
      Me.prbCopiando = New System.Windows.Forms.ProgressBar
      Me.ofdBase = New System.Windows.Forms.OpenFileDialog
      Me.grbBase.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtBaseOrigen
      '
      Me.txtBaseOrigen.BindearPropiedadControl = Nothing
      Me.txtBaseOrigen.BindearPropiedadEntidad = Nothing
      Me.txtBaseOrigen.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBaseOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBaseOrigen.Formato = ""
      Me.txtBaseOrigen.IsDecimal = False
      Me.txtBaseOrigen.IsNumber = False
      Me.txtBaseOrigen.IsPK = False
      Me.txtBaseOrigen.IsRequired = False
      Me.txtBaseOrigen.Key = ""
      Me.txtBaseOrigen.LabelAsoc = Me.lblOrigen
      Me.txtBaseOrigen.Location = New System.Drawing.Point(59, 29)
      Me.txtBaseOrigen.Name = "txtBaseOrigen"
      Me.txtBaseOrigen.ReadOnly = True
      Me.txtBaseOrigen.Size = New System.Drawing.Size(433, 20)
      Me.txtBaseOrigen.TabIndex = 3
      '
      'lblOrigen
      '
      Me.lblOrigen.AutoSize = True
      Me.lblOrigen.Location = New System.Drawing.Point(10, 33)
      Me.lblOrigen.Name = "lblOrigen"
      Me.lblOrigen.Size = New System.Drawing.Size(38, 13)
      Me.lblOrigen.TabIndex = 2
      Me.lblOrigen.Text = "Origen"
      '
      'btnCopiar
      '
      Me.btnCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCopiar.ImageKey = "disk_blue.ico"
      Me.btnCopiar.ImageList = Me.imgIconos
      Me.btnCopiar.Location = New System.Drawing.Point(389, 121)
      Me.btnCopiar.Name = "btnCopiar"
      Me.btnCopiar.Size = New System.Drawing.Size(85, 30)
      Me.btnCopiar.TabIndex = 6
      Me.btnCopiar.Text = "&Restaurar"
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
      Me.btnCancelar.Location = New System.Drawing.Point(480, 121)
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
      Me.grbBase.Controls.Add(Me.txtBaseOrigen)
      Me.grbBase.Controls.Add(Me.lblOrigen)
      Me.grbBase.Location = New System.Drawing.Point(12, 20)
      Me.grbBase.Name = "grbBase"
      Me.grbBase.Size = New System.Drawing.Size(561, 73)
      Me.grbBase.TabIndex = 8
      Me.grbBase.TabStop = False
      Me.grbBase.Text = "Base"
      '
      'btnBuscarDestino
      '
      Me.btnBuscarDestino.AutoSize = True
      Me.btnBuscarDestino.ImageIndex = 0
      Me.btnBuscarDestino.ImageList = Me.imgIconos32
      Me.btnBuscarDestino.Location = New System.Drawing.Point(495, 15)
      Me.btnBuscarDestino.Name = "btnBuscarDestino"
      Me.btnBuscarDestino.Size = New System.Drawing.Size(47, 48)
      Me.btnBuscarDestino.TabIndex = 6
      Me.btnBuscarDestino.UseVisualStyleBackColor = True
      '
      'imgIconos32
      '
      Me.imgIconos32.ImageStream = CType(resources.GetObject("imgIconos32.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos32.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos32.Images.SetKeyName(0, "folder_32.ico")
      '
      'lblCopiando
      '
      Me.lblCopiando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCopiando.AutoSize = True
      Me.lblCopiando.Location = New System.Drawing.Point(12, 130)
      Me.lblCopiando.Name = "lblCopiando"
      Me.lblCopiando.Size = New System.Drawing.Size(77, 13)
      Me.lblCopiando.TabIndex = 9
      Me.lblCopiando.Text = "Restaurando..."
      Me.lblCopiando.Visible = False
      '
      'prbCopiando
      '
      Me.prbCopiando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbCopiando.Location = New System.Drawing.Point(91, 125)
      Me.prbCopiando.Name = "prbCopiando"
      Me.prbCopiando.Size = New System.Drawing.Size(294, 23)
      Me.prbCopiando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbCopiando.TabIndex = 10
      Me.prbCopiando.Visible = False
      '
      'ofdBase
      '
      Me.ofdBase.FileName = "OpenFileDialog1"
      '
      'Restores
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(587, 163)
      Me.Controls.Add(Me.prbCopiando)
      Me.Controls.Add(Me.lblCopiando)
      Me.Controls.Add(Me.grbBase)
      Me.Controls.Add(Me.btnCopiar)
      Me.Controls.Add(Me.btnCancelar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Restores"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Restaurar Información desde Backup"
      Me.grbBase.ResumeLayout(False)
      Me.grbBase.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtBaseOrigen As Eniac.Controles.TextBox
   Friend WithEvents lblOrigen As Eniac.Controles.Label
   Friend WithEvents btnCopiar As Eniac.Controles.Button
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents grbBase As System.Windows.Forms.GroupBox
   Friend WithEvents lblCopiando As Eniac.Controles.Label
   Friend WithEvents prbCopiando As System.Windows.Forms.ProgressBar
   Friend WithEvents ofdBase As System.Windows.Forms.OpenFileDialog
   Friend WithEvents imgIconos32 As System.Windows.Forms.ImageList
   Friend WithEvents btnBuscarDestino As Eniac.Controles.Button
End Class
