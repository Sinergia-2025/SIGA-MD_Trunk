<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Actualizador
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
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tslPie = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspProgresito = New System.Windows.Forms.ToolStripProgressBar()
      Me.lblVersionActual = New System.Windows.Forms.Label()
      Me.txtVersionActual = New System.Windows.Forms.TextBox()
      Me.prbBarraDeProgreso = New System.Windows.Forms.ProgressBar()
      Me.txtPathDownload = New System.Windows.Forms.TextBox()
      Me.lblCopiarEn = New System.Windows.Forms.Label()
      Me.txtAplicacion = New System.Windows.Forms.TextBox()
      Me.lblAplicacion = New System.Windows.Forms.Label()
      Me.grbInformacion = New System.Windows.Forms.GroupBox()
      Me.txtBase = New System.Windows.Forms.TextBox()
      Me.lblBase = New System.Windows.Forms.Label()
      Me.pcbImagen = New System.Windows.Forms.PictureBox()
      Me.txtClave = New System.Windows.Forms.TextBox()
      Me.lblClave = New System.Windows.Forms.Label()
      Me.txtCodigo = New System.Windows.Forms.TextBox()
      Me.lblCodigo = New System.Windows.Forms.Label()
      Me.lblMensajeActualizacion = New System.Windows.Forms.Label()
      Me.lblTextoBarraDownload = New System.Windows.Forms.Label()
      Me.btnInstalar = New System.Windows.Forms.Button()
      Me.btnBajarActualizacion = New System.Windows.Forms.Button()
      Me.btnBuscarActualizaciones = New System.Windows.Forms.Button()
      Me.StatusStrip1.SuspendLayout()
      Me.grbInformacion.SuspendLayout()
      CType(Me.pcbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslPie, Me.tspProgresito})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 307)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(603, 22)
      Me.StatusStrip1.TabIndex = 0
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tslPie
      '
      Me.tslPie.Name = "tslPie"
      Me.tslPie.Size = New System.Drawing.Size(588, 17)
      Me.tslPie.Spring = True
      Me.tslPie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tspProgresito
      '
      Me.tspProgresito.Name = "tspProgresito"
      Me.tspProgresito.Size = New System.Drawing.Size(100, 16)
      Me.tspProgresito.Visible = False
      '
      'lblVersionActual
      '
      Me.lblVersionActual.AutoSize = True
      Me.lblVersionActual.Location = New System.Drawing.Point(109, 26)
      Me.lblVersionActual.Name = "lblVersionActual"
      Me.lblVersionActual.Size = New System.Drawing.Size(74, 13)
      Me.lblVersionActual.TabIndex = 1
      Me.lblVersionActual.Text = "Version actual"
      '
      'txtVersionActual
      '
      Me.txtVersionActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtVersionActual.Location = New System.Drawing.Point(112, 42)
      Me.txtVersionActual.Name = "txtVersionActual"
      Me.txtVersionActual.ReadOnly = True
      Me.txtVersionActual.Size = New System.Drawing.Size(85, 20)
      Me.txtVersionActual.TabIndex = 2
      '
      'prbBarraDeProgreso
      '
      Me.prbBarraDeProgreso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbBarraDeProgreso.Location = New System.Drawing.Point(13, 251)
      Me.prbBarraDeProgreso.Name = "prbBarraDeProgreso"
      Me.prbBarraDeProgreso.Size = New System.Drawing.Size(582, 20)
      Me.prbBarraDeProgreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbBarraDeProgreso.TabIndex = 13
      '
      'txtPathDownload
      '
      Me.txtPathDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPathDownload.Location = New System.Drawing.Point(76, 279)
      Me.txtPathDownload.Name = "txtPathDownload"
      Me.txtPathDownload.ReadOnly = True
      Me.txtPathDownload.Size = New System.Drawing.Size(519, 20)
      Me.txtPathDownload.TabIndex = 14
      '
      'lblCopiarEn
      '
      Me.lblCopiarEn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCopiarEn.AutoSize = True
      Me.lblCopiarEn.Location = New System.Drawing.Point(10, 284)
      Me.lblCopiarEn.Name = "lblCopiarEn"
      Me.lblCopiarEn.Size = New System.Drawing.Size(64, 13)
      Me.lblCopiarEn.TabIndex = 15
      Me.lblCopiarEn.Text = "Copiar en...."
      '
      'txtAplicacion
      '
      Me.txtAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtAplicacion.Location = New System.Drawing.Point(20, 42)
      Me.txtAplicacion.Name = "txtAplicacion"
      Me.txtAplicacion.ReadOnly = True
      Me.txtAplicacion.Size = New System.Drawing.Size(86, 20)
      Me.txtAplicacion.TabIndex = 20
      '
      'lblAplicacion
      '
      Me.lblAplicacion.AutoSize = True
      Me.lblAplicacion.Location = New System.Drawing.Point(17, 26)
      Me.lblAplicacion.Name = "lblAplicacion"
      Me.lblAplicacion.Size = New System.Drawing.Size(56, 13)
      Me.lblAplicacion.TabIndex = 19
      Me.lblAplicacion.Text = "Aplicación"
      '
      'grbInformacion
      '
      Me.grbInformacion.Controls.Add(Me.txtBase)
      Me.grbInformacion.Controls.Add(Me.lblBase)
      Me.grbInformacion.Controls.Add(Me.pcbImagen)
      Me.grbInformacion.Controls.Add(Me.txtClave)
      Me.grbInformacion.Controls.Add(Me.lblClave)
      Me.grbInformacion.Controls.Add(Me.txtCodigo)
      Me.grbInformacion.Controls.Add(Me.lblCodigo)
      Me.grbInformacion.Controls.Add(Me.txtAplicacion)
      Me.grbInformacion.Controls.Add(Me.lblAplicacion)
      Me.grbInformacion.Controls.Add(Me.txtVersionActual)
      Me.grbInformacion.Controls.Add(Me.lblVersionActual)
      Me.grbInformacion.Location = New System.Drawing.Point(15, 6)
      Me.grbInformacion.Name = "grbInformacion"
      Me.grbInformacion.Size = New System.Drawing.Size(580, 78)
      Me.grbInformacion.TabIndex = 21
      Me.grbInformacion.TabStop = False
      Me.grbInformacion.Text = "Información"
      '
      'txtBase
      '
      Me.txtBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBase.Location = New System.Drawing.Point(419, 42)
      Me.txtBase.Name = "txtBase"
      Me.txtBase.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtBase.ReadOnly = True
      Me.txtBase.Size = New System.Drawing.Size(82, 20)
      Me.txtBase.TabIndex = 27
      Me.txtBase.Visible = False
      '
      'lblBase
      '
      Me.lblBase.AutoSize = True
      Me.lblBase.Location = New System.Drawing.Point(419, 26)
      Me.lblBase.Name = "lblBase"
      Me.lblBase.Size = New System.Drawing.Size(31, 13)
      Me.lblBase.TabIndex = 26
      Me.lblBase.Text = "Base"
      Me.lblBase.Visible = False
      '
      'pcbImagen
      '
      Me.pcbImagen.Image = Global.Eniac.Win.My.Resources.Resources.lamp_48
      Me.pcbImagen.Location = New System.Drawing.Point(521, 15)
      Me.pcbImagen.Name = "pcbImagen"
      Me.pcbImagen.Size = New System.Drawing.Size(54, 57)
      Me.pcbImagen.TabIndex = 25
      Me.pcbImagen.TabStop = False
      '
      'txtClave
      '
      Me.txtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtClave.Location = New System.Drawing.Point(311, 42)
      Me.txtClave.Name = "txtClave"
      Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtClave.ReadOnly = True
      Me.txtClave.Size = New System.Drawing.Size(102, 20)
      Me.txtClave.TabIndex = 24
      Me.txtClave.Visible = False
      '
      'lblClave
      '
      Me.lblClave.AutoSize = True
      Me.lblClave.Location = New System.Drawing.Point(311, 26)
      Me.lblClave.Name = "lblClave"
      Me.lblClave.Size = New System.Drawing.Size(34, 13)
      Me.lblClave.TabIndex = 23
      Me.lblClave.Text = "Clave"
      Me.lblClave.Visible = False
      '
      'txtCodigo
      '
      Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodigo.Location = New System.Drawing.Point(203, 42)
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.ReadOnly = True
      Me.txtCodigo.Size = New System.Drawing.Size(102, 20)
      Me.txtCodigo.TabIndex = 22
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(200, 26)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(75, 13)
      Me.lblCodigo.TabIndex = 21
      Me.lblCodigo.Text = "Código Cliente"
      '
      'lblMensajeActualizacion
      '
      Me.lblMensajeActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.lblMensajeActualizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblMensajeActualizacion.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMensajeActualizacion.Location = New System.Drawing.Point(12, 169)
      Me.lblMensajeActualizacion.Name = "lblMensajeActualizacion"
      Me.lblMensajeActualizacion.Size = New System.Drawing.Size(583, 72)
      Me.lblMensajeActualizacion.TabIndex = 22
      '
      'lblTextoBarraDownload
      '
      Me.lblTextoBarraDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTextoBarraDownload.AutoSize = True
      Me.lblTextoBarraDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTextoBarraDownload.Location = New System.Drawing.Point(16, 234)
      Me.lblTextoBarraDownload.Name = "lblTextoBarraDownload"
      Me.lblTextoBarraDownload.Size = New System.Drawing.Size(0, 13)
      Me.lblTextoBarraDownload.TabIndex = 23
      '
      'btnInstalar
      '
      Me.btnInstalar.Enabled = False
      Me.btnInstalar.Image = Global.Eniac.Win.My.Resources.Resources.files_config_48
      Me.btnInstalar.Location = New System.Drawing.Point(414, 90)
      Me.btnInstalar.Name = "btnInstalar"
      Me.btnInstalar.Size = New System.Drawing.Size(180, 72)
      Me.btnInstalar.TabIndex = 24
      Me.btnInstalar.Text = "Comenzar Instalación"
      Me.btnInstalar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.btnInstalar.UseVisualStyleBackColor = True
      '
      'btnBajarActualizacion
      '
      Me.btnBajarActualizacion.Enabled = False
      Me.btnBajarActualizacion.Image = Global.Eniac.Win.My.Resources.Resources.wan_down_48
      Me.btnBajarActualizacion.Location = New System.Drawing.Point(215, 90)
      Me.btnBajarActualizacion.Name = "btnBajarActualizacion"
      Me.btnBajarActualizacion.Size = New System.Drawing.Size(180, 72)
      Me.btnBajarActualizacion.TabIndex = 6
      Me.btnBajarActualizacion.Text = "Bajar actualización"
      Me.btnBajarActualizacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.btnBajarActualizacion.UseVisualStyleBackColor = True
      '
      'btnBuscarActualizaciones
      '
      Me.btnBuscarActualizaciones.Image = Global.Eniac.Win.My.Resources.Resources.wan_refresh_481
      Me.btnBuscarActualizaciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.btnBuscarActualizaciones.Location = New System.Drawing.Point(12, 90)
      Me.btnBuscarActualizaciones.Name = "btnBuscarActualizaciones"
      Me.btnBuscarActualizaciones.Size = New System.Drawing.Size(180, 72)
      Me.btnBuscarActualizaciones.TabIndex = 3
      Me.btnBuscarActualizaciones.Text = "Buscar actualizaciones"
      Me.btnBuscarActualizaciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.btnBuscarActualizaciones.UseVisualStyleBackColor = True
      '
      'Actualizador
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(603, 329)
      Me.Controls.Add(Me.btnInstalar)
      Me.Controls.Add(Me.lblTextoBarraDownload)
      Me.Controls.Add(Me.lblMensajeActualizacion)
      Me.Controls.Add(Me.grbInformacion)
      Me.Controls.Add(Me.lblCopiarEn)
      Me.Controls.Add(Me.txtPathDownload)
      Me.Controls.Add(Me.prbBarraDeProgreso)
      Me.Controls.Add(Me.btnBajarActualizacion)
      Me.Controls.Add(Me.btnBuscarActualizaciones)
      Me.Controls.Add(Me.StatusStrip1)
      Me.ForeColor = System.Drawing.SystemColors.ControlText
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Actualizador"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Actualizador de Versión"
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.grbInformacion.ResumeLayout(False)
      Me.grbInformacion.PerformLayout()
      CType(Me.pcbImagen, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents lblVersionActual As System.Windows.Forms.Label
   Friend WithEvents txtVersionActual As System.Windows.Forms.TextBox
   Friend WithEvents btnBuscarActualizaciones As System.Windows.Forms.Button
   Friend WithEvents btnBajarActualizacion As System.Windows.Forms.Button
   Private WithEvents prbBarraDeProgreso As System.Windows.Forms.ProgressBar
   Friend WithEvents txtPathDownload As System.Windows.Forms.TextBox
   Friend WithEvents lblCopiarEn As System.Windows.Forms.Label
   Friend WithEvents txtAplicacion As System.Windows.Forms.TextBox
   Friend WithEvents lblAplicacion As System.Windows.Forms.Label
   Friend WithEvents grbInformacion As System.Windows.Forms.GroupBox
   Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
   Friend WithEvents lblCodigo As System.Windows.Forms.Label
   Friend WithEvents txtClave As System.Windows.Forms.TextBox
   Friend WithEvents lblClave As System.Windows.Forms.Label
   Friend WithEvents tslPie As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspProgresito As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents lblMensajeActualizacion As System.Windows.Forms.Label
   Friend WithEvents lblTextoBarraDownload As System.Windows.Forms.Label
   Friend WithEvents btnInstalar As System.Windows.Forms.Button
   Friend WithEvents pcbImagen As System.Windows.Forms.PictureBox
   Friend WithEvents txtBase As System.Windows.Forms.TextBox
   Friend WithEvents lblBase As System.Windows.Forms.Label
End Class
