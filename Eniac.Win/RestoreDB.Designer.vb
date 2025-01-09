<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RestoreDB
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RestoreDB))
      Me.txtBaseOrigen = New Eniac.Controles.TextBox
      Me.lblBaseDestino = New Eniac.Controles.Label
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.grbBase = New System.Windows.Forms.GroupBox
      Me.btnBuscarDestino = New Eniac.Controles.Button
      Me.lblCopiando = New Eniac.Controles.Label
      Me.prbCopiando = New System.Windows.Forms.ProgressBar
      Me.tstMenu = New System.Windows.Forms.ToolStrip
      Me.tscBase = New System.Windows.Forms.ToolStripComboBox
      Me.tsbRestore = New System.Windows.Forms.ToolStripButton
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton
      Me.ofdBase = New System.Windows.Forms.OpenFileDialog
      Me.grbBase.SuspendLayout()
      Me.tstMenu.SuspendLayout()
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
      Me.txtBaseOrigen.LabelAsoc = Me.lblBaseDestino
      Me.txtBaseOrigen.Location = New System.Drawing.Point(59, 21)
      Me.txtBaseOrigen.Name = "txtBaseOrigen"
      Me.txtBaseOrigen.ReadOnly = True
      Me.txtBaseOrigen.Size = New System.Drawing.Size(433, 20)
      Me.txtBaseOrigen.TabIndex = 3
      '
      'lblBaseDestino
      '
      Me.lblBaseDestino.AutoSize = True
      Me.lblBaseDestino.Location = New System.Drawing.Point(10, 24)
      Me.lblBaseDestino.Name = "lblBaseDestino"
      Me.lblBaseDestino.Size = New System.Drawing.Size(43, 13)
      Me.lblBaseDestino.TabIndex = 2
      Me.lblBaseDestino.Text = "Archivo"
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "disk_blue.ico")
      Me.imgIconos.Images.SetKeyName(1, "delete2.ico")
      Me.imgIconos.Images.SetKeyName(2, "folder.ico")
      '
      'grbBase
      '
      Me.grbBase.Controls.Add(Me.btnBuscarDestino)
      Me.grbBase.Controls.Add(Me.txtBaseOrigen)
      Me.grbBase.Controls.Add(Me.lblBaseDestino)
      Me.grbBase.Location = New System.Drawing.Point(12, 44)
      Me.grbBase.Name = "grbBase"
      Me.grbBase.Size = New System.Drawing.Size(528, 56)
      Me.grbBase.TabIndex = 8
      Me.grbBase.TabStop = False
      Me.grbBase.Text = "Origen Base"
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
      Me.lblCopiando.Location = New System.Drawing.Point(12, 128)
      Me.lblCopiando.Name = "lblCopiando"
      Me.lblCopiando.Size = New System.Drawing.Size(62, 13)
      Me.lblCopiando.TabIndex = 9
      Me.lblCopiando.Text = "Cargando..."
      Me.lblCopiando.Visible = False
      '
      'prbCopiando
      '
      Me.prbCopiando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbCopiando.Location = New System.Drawing.Point(80, 123)
      Me.prbCopiando.Name = "prbCopiando"
      Me.prbCopiando.Size = New System.Drawing.Size(433, 23)
      Me.prbCopiando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbCopiando.TabIndex = 10
      Me.prbCopiando.Visible = False
      '
      'tstMenu
      '
      Me.tstMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me.tstMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscBase, Me.tsbRestore, Me.tsbCerrar})
      Me.tstMenu.Location = New System.Drawing.Point(0, 0)
      Me.tstMenu.Name = "tstMenu"
      Me.tstMenu.Size = New System.Drawing.Size(566, 31)
      Me.tstMenu.TabIndex = 11
      '
      'tscBase
      '
      Me.tscBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.tscBase.Name = "tscBase"
      Me.tscBase.Size = New System.Drawing.Size(200, 31)
      '
      'tsbRestore
      '
      Me.tsbRestore.Image = Global.Eniac.Win.My.Resources.Resources.cabinet_back_24
      Me.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRestore.Name = "tsbRestore"
      Me.tsbRestore.Size = New System.Drawing.Size(83, 28)
      Me.tsbRestore.Text = "&Restaurar"
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(66, 28)
      Me.tsbCerrar.Text = "&Cerrar"
      '
      'ofdBase
      '
      Me.ofdBase.Filter = "Backups (*.bak)|*.bak|Todos los Archivos (*.*)|*.*"
      '
      'RestoreDB
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(566, 159)
      Me.Controls.Add(Me.tstMenu)
      Me.Controls.Add(Me.prbCopiando)
      Me.Controls.Add(Me.lblCopiando)
      Me.Controls.Add(Me.grbBase)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "RestoreDB"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Restaurar Backup de otro Local"
      Me.grbBase.ResumeLayout(False)
      Me.grbBase.PerformLayout()
      Me.tstMenu.ResumeLayout(False)
      Me.tstMenu.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtBaseOrigen As Eniac.Controles.TextBox
   Friend WithEvents lblBaseDestino As Eniac.Controles.Label
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents grbBase As System.Windows.Forms.GroupBox
   Friend WithEvents btnBuscarDestino As Eniac.Controles.Button
   Friend WithEvents lblCopiando As Eniac.Controles.Label
   Friend WithEvents prbCopiando As System.Windows.Forms.ProgressBar
   Friend WithEvents tstMenu As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tscBase As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents tsbRestore As System.Windows.Forms.ToolStripButton
   Friend WithEvents ofdBase As System.Windows.Forms.OpenFileDialog
End Class
