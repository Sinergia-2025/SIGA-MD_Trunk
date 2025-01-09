<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasePrincipal
    Inherits Eniac.Win.BaseForm

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
      Me.components = New System.ComponentModel.Container()
      Me.stsPrincipal = New System.Windows.Forms.StatusStrip()
      Me.cmsMenucito = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.tsmAlertas = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmRecargarAlertas = New System.Windows.Forms.ToolStripMenuItem()
      Me.tssError = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssCurrentUICulture = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssVencimiento = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssUsuario = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssEmpresa = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssSucursal = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssVersion = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspProgreso = New System.Windows.Forms.ToolStripProgressBar()
      Me.mnsPrincipal = New System.Windows.Forms.MenuStrip()
      Me.tlsPrincipal = New System.Windows.Forms.ToolStrip()
      Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.stsPrincipal.SuspendLayout()
        Me.cmsMenucito.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsPrincipal
        '
        Me.stsPrincipal.ContextMenuStrip = Me.cmsMenucito
        Me.stsPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssError, Me.tssInfo, Me.tssCurrentUICulture, Me.tssVencimiento, Me.tssUsuario, Me.tssEmpresa, Me.tssSucursal, Me.tssVersion, Me.tspProgreso})
        Me.stsPrincipal.Location = New System.Drawing.Point(0, 528)
        Me.stsPrincipal.Name = "stsPrincipal"
        Me.stsPrincipal.Size = New System.Drawing.Size(800, 22)
        Me.stsPrincipal.TabIndex = 1
        Me.stsPrincipal.Text = "StatusStrip1"
        '
        'cmsMenucito
        '
        Me.cmsMenucito.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAlertas, Me.tsmRecargarAlertas})
        Me.cmsMenucito.Name = "cmsMenucito"
        Me.cmsMenucito.Size = New System.Drawing.Size(160, 48)
        '
        'tsmAlertas
        '
        Me.tsmAlertas.Checked = True
        Me.tsmAlertas.CheckOnClick = True
        Me.tsmAlertas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmAlertas.Name = "tsmAlertas"
        Me.tsmAlertas.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.tsmAlertas.Size = New System.Drawing.Size(159, 22)
        Me.tsmAlertas.Text = "Alertas"
        '
        'tsmRecargarAlertas
        '
        Me.tsmRecargarAlertas.Name = "tsmRecargarAlertas"
        Me.tsmRecargarAlertas.Size = New System.Drawing.Size(159, 22)
        Me.tsmRecargarAlertas.Text = "Recargar Alertas"
        '
        'tssError
        '
        Me.tssError.BackColor = System.Drawing.Color.Red
        Me.tssError.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssError.ForeColor = System.Drawing.Color.White
        Me.tssError.Name = "tssError"
        Me.tssError.Size = New System.Drawing.Size(0, 17)
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(667, 17)
        Me.tssInfo.Spring = True
        '
        'tssCurrentUICulture
        '
        Me.tssCurrentUICulture.Name = "tssCurrentUICulture"
        Me.tssCurrentUICulture.Size = New System.Drawing.Size(38, 17)
        Me.tssCurrentUICulture.Text = "es-AR"
        '
        'tssVencimiento
        '
        Me.tssVencimiento.Image = Global.Eniac.Win.My.Resources.Resources._stop
        Me.tssVencimiento.Name = "tssVencimiento"
        Me.tssVencimiento.Size = New System.Drawing.Size(16, 17)
        '
        'tssUsuario
        '
        Me.tssUsuario.Image = Global.Eniac.Win.My.Resources.Resources.user1
        Me.tssUsuario.Name = "tssUsuario"
        Me.tssUsuario.Size = New System.Drawing.Size(16, 17)
        '
        'tssEmpresa
        '
        Me.tssEmpresa.Image = Global.Eniac.Win.My.Resources.Resources.houses
        Me.tssEmpresa.Name = "tssEmpresa"
        Me.tssEmpresa.Size = New System.Drawing.Size(16, 17)
        '
        'tssSucursal
        '
        Me.tssSucursal.Image = Global.Eniac.Win.My.Resources.Resources.earth_location
        Me.tssSucursal.Name = "tssSucursal"
        Me.tssSucursal.Size = New System.Drawing.Size(16, 17)
        '
        'tssVersion
        '
        Me.tssVersion.Image = Global.Eniac.Win.My.Resources.Resources.application
        Me.tssVersion.Name = "tssVersion"
        Me.tssVersion.Size = New System.Drawing.Size(16, 17)
        '
        'tspProgreso
        '
        Me.tspProgreso.Name = "tspProgreso"
        Me.tspProgreso.Size = New System.Drawing.Size(100, 16)
        Me.tspProgreso.Visible = False
        '
        'mnsPrincipal
        '
        Me.mnsPrincipal.ContextMenuStrip = Me.cmsMenucito
        Me.mnsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.mnsPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.mnsPrincipal.Name = "mnsPrincipal"
        Me.mnsPrincipal.Size = New System.Drawing.Size(800, 4)
        Me.mnsPrincipal.TabIndex = 2
        '
        'tlsPrincipal
        '
        Me.tlsPrincipal.ContextMenuStrip = Me.cmsMenucito
        Me.tlsPrincipal.Location = New System.Drawing.Point(0, 4)
        Me.tlsPrincipal.Name = "tlsPrincipal"
        Me.tlsPrincipal.Size = New System.Drawing.Size(800, 25)
        Me.tlsPrincipal.TabIndex = 3
        Me.tlsPrincipal.Text = "ToolStrip1"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(797, 29)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 499)
        Me.Splitter1.TabIndex = 6
        Me.Splitter1.TabStop = False
        '
        'BasePrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 550)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.tlsPrincipal)
        Me.Controls.Add(Me.stsPrincipal)
        Me.Controls.Add(Me.mnsPrincipal)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnsPrincipal
        Me.Name = "BasePrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.stsPrincipal.ResumeLayout(False)
        Me.stsPrincipal.PerformLayout()
        Me.cmsMenucito.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents stsPrincipal As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents mnsPrincipal As System.Windows.Forms.MenuStrip
   Protected Friend WithEvents tlsPrincipal As System.Windows.Forms.ToolStrip
   Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tssUsuario As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspProgreso As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents tssVersion As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tssSucursal As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tssEmpresa As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
   Friend WithEvents cmsMenucito As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents tsmAlertas As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmRecargarAlertas As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tssVencimiento As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tssCurrentUICulture As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tssError As System.Windows.Forms.ToolStripStatusLabel
End Class
