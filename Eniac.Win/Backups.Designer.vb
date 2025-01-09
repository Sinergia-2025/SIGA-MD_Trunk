<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Backups
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Backups))
      Me.txtBaseDestino = New Eniac.Controles.TextBox()
      Me.lblBaseDestino = New Eniac.Controles.Label()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.grbBase = New System.Windows.Forms.GroupBox()
      Me.lblMotorNombre = New Eniac.Controles.Label()
      Me.lblMotor = New Eniac.Controles.Label()
      Me.lblEspacio = New Eniac.Controles.Label()
      Me.lblEspacioDisponible = New Eniac.Controles.Label()
      Me.btnBuscarDestino = New Eniac.Controles.Button()
      Me.imgIconos32 = New System.Windows.Forms.ImageList(Me.components)
      Me.fbdBase = New System.Windows.Forms.FolderBrowserDialog()
      Me.lblCopiando = New Eniac.Controles.Label()
      Me.prbCopiando = New System.Windows.Forms.ProgressBar()
      Me.btnCopiar = New Eniac.Controles.Button()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.grbBase.SuspendLayout()
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
      Me.txtBaseDestino.Location = New System.Drawing.Point(59, 30)
      Me.txtBaseDestino.Name = "txtBaseDestino"
      Me.txtBaseDestino.ReadOnly = True
      Me.txtBaseDestino.Size = New System.Drawing.Size(431, 20)
      Me.txtBaseDestino.TabIndex = 3
      '
      'lblBaseDestino
      '
      Me.lblBaseDestino.AutoSize = True
      Me.lblBaseDestino.LabelAsoc = Nothing
      Me.lblBaseDestino.Location = New System.Drawing.Point(10, 34)
      Me.lblBaseDestino.Name = "lblBaseDestino"
      Me.lblBaseDestino.Size = New System.Drawing.Size(43, 13)
      Me.lblBaseDestino.TabIndex = 2
      Me.lblBaseDestino.Text = "Destino"
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
      Me.grbBase.Controls.Add(Me.lblMotorNombre)
      Me.grbBase.Controls.Add(Me.lblMotor)
      Me.grbBase.Controls.Add(Me.lblEspacio)
      Me.grbBase.Controls.Add(Me.lblEspacioDisponible)
      Me.grbBase.Controls.Add(Me.btnBuscarDestino)
      Me.grbBase.Controls.Add(Me.txtBaseDestino)
      Me.grbBase.Controls.Add(Me.lblBaseDestino)
      Me.grbBase.Location = New System.Drawing.Point(12, 15)
      Me.grbBase.Name = "grbBase"
      Me.grbBase.Size = New System.Drawing.Size(561, 120)
      Me.grbBase.TabIndex = 8
      Me.grbBase.TabStop = False
      Me.grbBase.Text = "Base"
      '
      'lblMotorNombre
      '
      Me.lblMotorNombre.BackColor = System.Drawing.SystemColors.Control
      Me.lblMotorNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMotorNombre.ForeColor = System.Drawing.Color.Blue
      Me.lblMotorNombre.LabelAsoc = Nothing
      Me.lblMotorNombre.Location = New System.Drawing.Point(56, 92)
      Me.lblMotorNombre.Name = "lblMotorNombre"
      Me.lblMotorNombre.Size = New System.Drawing.Size(490, 13)
      Me.lblMotorNombre.TabIndex = 9
      Me.lblMotorNombre.Text = "..."
      '
      'lblMotor
      '
      Me.lblMotor.AutoSize = True
      Me.lblMotor.BackColor = System.Drawing.SystemColors.Control
      Me.lblMotor.LabelAsoc = Nothing
      Me.lblMotor.Location = New System.Drawing.Point(10, 92)
      Me.lblMotor.Name = "lblMotor"
      Me.lblMotor.Size = New System.Drawing.Size(40, 13)
      Me.lblMotor.TabIndex = 8
      Me.lblMotor.Text = "Motor: "
      '
      'lblEspacio
      '
      Me.lblEspacio.AutoSize = True
      Me.lblEspacio.BackColor = System.Drawing.SystemColors.Control
      Me.lblEspacio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblEspacio.ForeColor = System.Drawing.Color.Red
      Me.lblEspacio.LabelAsoc = Nothing
      Me.lblEspacio.Location = New System.Drawing.Point(162, 67)
      Me.lblEspacio.Name = "lblEspacio"
      Me.lblEspacio.Size = New System.Drawing.Size(14, 13)
      Me.lblEspacio.TabIndex = 7
      Me.lblEspacio.Text = "0"
      '
      'lblEspacioDisponible
      '
      Me.lblEspacioDisponible.AutoSize = True
      Me.lblEspacioDisponible.BackColor = System.Drawing.SystemColors.Control
      Me.lblEspacioDisponible.LabelAsoc = Nothing
      Me.lblEspacioDisponible.Location = New System.Drawing.Point(10, 67)
      Me.lblEspacioDisponible.Name = "lblEspacioDisponible"
      Me.lblEspacioDisponible.Size = New System.Drawing.Size(148, 13)
      Me.lblEspacioDisponible.TabIndex = 6
      Me.lblEspacioDisponible.Text = "Espacio disponible en MBytes"
      '
      'btnBuscarDestino
      '
      Me.btnBuscarDestino.AutoSize = True
      Me.btnBuscarDestino.ImageIndex = 0
      Me.btnBuscarDestino.ImageList = Me.imgIconos32
      Me.btnBuscarDestino.Location = New System.Drawing.Point(499, 16)
      Me.btnBuscarDestino.Name = "btnBuscarDestino"
      Me.btnBuscarDestino.Size = New System.Drawing.Size(47, 48)
      Me.btnBuscarDestino.TabIndex = 5
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
      Me.lblCopiando.AutoSize = True
      Me.lblCopiando.LabelAsoc = Nothing
      Me.lblCopiando.Location = New System.Drawing.Point(8, 150)
      Me.lblCopiando.Name = "lblCopiando"
      Me.lblCopiando.Size = New System.Drawing.Size(61, 13)
      Me.lblCopiando.TabIndex = 9
      Me.lblCopiando.Text = "Copiando..."
      Me.lblCopiando.Visible = False
      '
      'prbCopiando
      '
      Me.prbCopiando.Location = New System.Drawing.Point(71, 145)
      Me.prbCopiando.Name = "prbCopiando"
      Me.prbCopiando.Size = New System.Drawing.Size(306, 23)
      Me.prbCopiando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbCopiando.TabIndex = 10
      Me.prbCopiando.Visible = False
      '
      'btnCopiar
      '
      Me.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCopiar.ImageKey = "disk_blue.ico"
      Me.btnCopiar.ImageList = Me.imgIconos
      Me.btnCopiar.Location = New System.Drawing.Point(393, 141)
      Me.btnCopiar.Name = "btnCopiar"
      Me.btnCopiar.Size = New System.Drawing.Size(85, 30)
      Me.btnCopiar.TabIndex = 6
      Me.btnCopiar.Text = "&Backup"
      Me.btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCopiar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgIconos
      Me.btnCancelar.Location = New System.Drawing.Point(488, 141)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 7
      Me.btnCancelar.Text = "&Salir"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'Backups
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(582, 188)
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
   Friend WithEvents imgIconos32 As System.Windows.Forms.ImageList
   Friend WithEvents lblEspacio As Eniac.Controles.Label
   Friend WithEvents lblEspacioDisponible As Eniac.Controles.Label
   Friend WithEvents lblMotorNombre As Eniac.Controles.Label
   Friend WithEvents lblMotor As Eniac.Controles.Label
End Class
