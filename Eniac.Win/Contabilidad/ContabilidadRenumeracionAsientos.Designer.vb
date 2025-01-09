<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadRenumeracionAsientos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadRenumeracionAsientos))
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tstAvance = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tslInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGenerarAsientos = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.cmbEjercicio = New Eniac.Controles.ComboBox()
      Me.lblEjercicio = New Eniac.Controles.Label()
      Me.StatusStrip1.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstAvance, Me.tssInfo, Me.tslInfo, Me.tspBarra, Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 125)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(443, 22)
      Me.StatusStrip1.TabIndex = 75
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tstAvance
      '
      Me.tstAvance.Name = "tstAvance"
      Me.tstAvance.Size = New System.Drawing.Size(0, 17)
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(295, 17)
      Me.tssInfo.Spring = True
      Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tslInfo
      '
      Me.tslInfo.Name = "tslInfo"
      Me.tslInfo.Size = New System.Drawing.Size(0, 17)
      '
      'tspBarra
      '
      Me.tspBarra.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Step = 1
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(0, 17)
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbGenerarAsientos, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(443, 29)
      Me.tstBarra.TabIndex = 74
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGenerarAsientos
      '
      Me.tsbGenerarAsientos.Image = CType(resources.GetObject("tsbGenerarAsientos.Image"), System.Drawing.Image)
      Me.tsbGenerarAsientos.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGenerarAsientos.Name = "tsbGenerarAsientos"
      Me.tsbGenerarAsientos.Size = New System.Drawing.Size(139, 26)
      Me.tsbGenerarAsientos.Text = "Renumerar Asientos"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      'cmbEjercicio
      '
      Me.cmbEjercicio.BindearPropiedadControl = "SelectedValue"
      Me.cmbEjercicio.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEjercicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEjercicio.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEjercicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEjercicio.FormattingEnabled = True
      Me.cmbEjercicio.IsPK = False
      Me.cmbEjercicio.IsRequired = True
      Me.cmbEjercicio.Key = Nothing
      Me.cmbEjercicio.LabelAsoc = Me.lblEjercicio
      Me.cmbEjercicio.Location = New System.Drawing.Point(88, 60)
      Me.cmbEjercicio.Name = "cmbEjercicio"
      Me.cmbEjercicio.Size = New System.Drawing.Size(307, 21)
      Me.cmbEjercicio.TabIndex = 77
      '
      'lblEjercicio
      '
      Me.lblEjercicio.AutoSize = True
      Me.lblEjercicio.LabelAsoc = Nothing
      Me.lblEjercicio.Location = New System.Drawing.Point(35, 63)
      Me.lblEjercicio.Name = "lblEjercicio"
      Me.lblEjercicio.Size = New System.Drawing.Size(47, 13)
      Me.lblEjercicio.TabIndex = 76
      Me.lblEjercicio.Text = "Ejercicio"
      '
      'ContabilidadRenumeracionAsientos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(443, 147)
      Me.Controls.Add(Me.cmbEjercicio)
      Me.Controls.Add(Me.lblEjercicio)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "ContabilidadRenumeracionAsientos"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Renumeración de Asientos"
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tstAvance As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslInfo As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbGenerarAsientos As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbEjercicio As Eniac.Controles.ComboBox
   Friend WithEvents lblEjercicio As Eniac.Controles.Label
End Class
