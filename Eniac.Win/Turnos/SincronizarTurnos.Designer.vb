<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizarTurnos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SincronizarTurnos))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.btnSincronizar = New System.Windows.Forms.Button()
      Me.bkgSincronizar = New System.ComponentModel.BackgroundWorker()
      Me.lblURLServicio = New Eniac.Controles.Label()
      Me.txtURLServicio = New Eniac.Controles.TextBox()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(565, 29)
      Me.tstBarra.TabIndex = 4
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 246)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(565, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(486, 17)
      Me.tssInfo.Spring = True
      Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'btnSincronizar
      '
      Me.btnSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnSincronizar.Image = Global.Eniac.Win.My.Resources.Resources.exchange
      Me.btnSincronizar.Location = New System.Drawing.Point(155, 71)
      Me.btnSincronizar.Name = "btnSincronizar"
      Me.btnSincronizar.Size = New System.Drawing.Size(230, 99)
      Me.btnSincronizar.TabIndex = 0
      Me.btnSincronizar.Text = "Sincronizar"
      Me.btnSincronizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnSincronizar.UseVisualStyleBackColor = True
      '
      'bkgSincronizar
      '
      Me.bkgSincronizar.WorkerReportsProgress = True
      Me.bkgSincronizar.WorkerSupportsCancellation = True
      '
      'lblURLServicio
      '
      Me.lblURLServicio.AutoSize = True
      Me.lblURLServicio.LabelAsoc = Nothing
      Me.lblURLServicio.Location = New System.Drawing.Point(7, 226)
      Me.lblURLServicio.Name = "lblURLServicio"
      Me.lblURLServicio.Size = New System.Drawing.Size(114, 13)
      Me.lblURLServicio.TabIndex = 1
      Me.lblURLServicio.Text = "URL de sincronización"
      '
      'txtURLServicio
      '
      Me.txtURLServicio.BindearPropiedadControl = Nothing
      Me.txtURLServicio.BindearPropiedadEntidad = Nothing
      Me.txtURLServicio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtURLServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtURLServicio.Formato = ""
      Me.txtURLServicio.IsDecimal = False
      Me.txtURLServicio.IsNumber = False
      Me.txtURLServicio.IsPK = False
      Me.txtURLServicio.IsRequired = False
      Me.txtURLServicio.Key = ""
      Me.txtURLServicio.LabelAsoc = Me.lblURLServicio
      Me.txtURLServicio.Location = New System.Drawing.Point(127, 223)
      Me.txtURLServicio.Name = "txtURLServicio"
      Me.txtURLServicio.ReadOnly = True
      Me.txtURLServicio.Size = New System.Drawing.Size(426, 20)
      Me.txtURLServicio.TabIndex = 2
      '
      'SincronizarTurnos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(565, 268)
      Me.Controls.Add(Me.lblURLServicio)
      Me.Controls.Add(Me.txtURLServicio)
      Me.Controls.Add(Me.btnSincronizar)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "SincronizarTurnos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Sincronizar Turnos"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents btnSincronizar As System.Windows.Forms.Button
   Friend WithEvents bkgSincronizar As System.ComponentModel.BackgroundWorker
   Friend WithEvents lblURLServicio As Eniac.Controles.Label
   Friend WithEvents txtURLServicio As Eniac.Controles.TextBox
End Class
