<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SincronizarPanelDeControl
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SincronizarPanelDeControl))
      Me.bkgSincronizar = New System.ComponentModel.BackgroundWorker()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.btnSincronizar = New System.Windows.Forms.Button()
      Me.chbExportarPanelDeControl = New Eniac.Controles.CheckBox()
      Me.chbEnviarWebPanelDeControl = New Eniac.Controles.CheckBox()
      Me.chbReenviar = New Eniac.Controles.CheckBox()
      Me.chbExportarPanelDeFechasSalida = New Eniac.Controles.CheckBox()
      Me.chbEnviarWebPanelDeFechasSalida = New Eniac.Controles.CheckBox()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'bkgSincronizar
      '
      Me.bkgSincronizar.WorkerReportsProgress = True
      Me.bkgSincronizar.WorkerSupportsCancellation = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(464, 29)
      Me.tstBarra.TabIndex = 11
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
      Me.stsStado.Location = New System.Drawing.Point(0, 197)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(464, 22)
      Me.stsStado.TabIndex = 10
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(385, 17)
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
      Me.btnSincronizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnSincronizar.Location = New System.Drawing.Point(12, 32)
      Me.btnSincronizar.Name = "btnSincronizar"
      Me.btnSincronizar.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
      Me.btnSincronizar.Size = New System.Drawing.Size(440, 99)
      Me.btnSincronizar.TabIndex = 12
      Me.btnSincronizar.Text = "Sincronizar "
      Me.btnSincronizar.UseVisualStyleBackColor = True
      '
      'chbExportarPanelDeControl
      '
      Me.chbExportarPanelDeControl.AutoSize = True
      Me.chbExportarPanelDeControl.BindearPropiedadControl = Nothing
      Me.chbExportarPanelDeControl.BindearPropiedadEntidad = Nothing
      Me.chbExportarPanelDeControl.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExportarPanelDeControl.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExportarPanelDeControl.IsPK = False
      Me.chbExportarPanelDeControl.IsRequired = False
      Me.chbExportarPanelDeControl.Key = Nothing
      Me.chbExportarPanelDeControl.LabelAsoc = Nothing
      Me.chbExportarPanelDeControl.Location = New System.Drawing.Point(264, 148)
      Me.chbExportarPanelDeControl.Name = "chbExportarPanelDeControl"
      Me.chbExportarPanelDeControl.Size = New System.Drawing.Size(146, 17)
      Me.chbExportarPanelDeControl.TabIndex = 16
      Me.chbExportarPanelDeControl.Text = "Exportar Panel de Control"
      Me.chbExportarPanelDeControl.UseVisualStyleBackColor = True
      '
      'chbEnviarWebPanelDeControl
      '
      Me.chbEnviarWebPanelDeControl.AutoSize = True
      Me.chbEnviarWebPanelDeControl.BindearPropiedadControl = Nothing
      Me.chbEnviarWebPanelDeControl.BindearPropiedadEntidad = Nothing
      Me.chbEnviarWebPanelDeControl.Checked = True
      Me.chbEnviarWebPanelDeControl.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbEnviarWebPanelDeControl.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEnviarWebPanelDeControl.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEnviarWebPanelDeControl.IsPK = False
      Me.chbEnviarWebPanelDeControl.IsRequired = False
      Me.chbEnviarWebPanelDeControl.Key = Nothing
      Me.chbEnviarWebPanelDeControl.LabelAsoc = Nothing
      Me.chbEnviarWebPanelDeControl.Location = New System.Drawing.Point(88, 148)
      Me.chbEnviarWebPanelDeControl.Name = "chbEnviarWebPanelDeControl"
      Me.chbEnviarWebPanelDeControl.Size = New System.Drawing.Size(137, 17)
      Me.chbEnviarWebPanelDeControl.TabIndex = 17
      Me.chbEnviarWebPanelDeControl.Text = "Enviar Panel de Control"
      Me.chbEnviarWebPanelDeControl.UseVisualStyleBackColor = True
      '
      'chbReenviar
      '
      Me.chbReenviar.AutoSize = True
      Me.chbReenviar.BindearPropiedadControl = Nothing
      Me.chbReenviar.BindearPropiedadEntidad = Nothing
      Me.chbReenviar.Checked = True
      Me.chbReenviar.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbReenviar.ForeColorFocus = System.Drawing.Color.Red
      Me.chbReenviar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbReenviar.IsPK = False
      Me.chbReenviar.IsRequired = False
      Me.chbReenviar.Key = Nothing
      Me.chbReenviar.LabelAsoc = Nothing
      Me.chbReenviar.Location = New System.Drawing.Point(13, 148)
      Me.chbReenviar.Name = "chbReenviar"
      Me.chbReenviar.Size = New System.Drawing.Size(69, 17)
      Me.chbReenviar.TabIndex = 18
      Me.chbReenviar.Text = "Reenviar"
      Me.chbReenviar.UseVisualStyleBackColor = True
      '
      'chbExportarPanelDeFechasSalida
      '
      Me.chbExportarPanelDeFechasSalida.AutoSize = True
      Me.chbExportarPanelDeFechasSalida.BindearPropiedadControl = Nothing
      Me.chbExportarPanelDeFechasSalida.BindearPropiedadEntidad = Nothing
      Me.chbExportarPanelDeFechasSalida.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExportarPanelDeFechasSalida.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExportarPanelDeFechasSalida.IsPK = False
      Me.chbExportarPanelDeFechasSalida.IsRequired = False
      Me.chbExportarPanelDeFechasSalida.Key = Nothing
      Me.chbExportarPanelDeFechasSalida.LabelAsoc = Nothing
      Me.chbExportarPanelDeFechasSalida.Location = New System.Drawing.Point(264, 171)
      Me.chbExportarPanelDeFechasSalida.Name = "chbExportarPanelDeFechasSalida"
      Me.chbExportarPanelDeFechasSalida.Size = New System.Drawing.Size(180, 17)
      Me.chbExportarPanelDeFechasSalida.TabIndex = 19
      Me.chbExportarPanelDeFechasSalida.Text = "Exportar Panel de Fechas Salida"
      Me.chbExportarPanelDeFechasSalida.UseVisualStyleBackColor = True
      '
      'chbEnviarWebPanelDeFechasSalida
      '
      Me.chbEnviarWebPanelDeFechasSalida.AutoSize = True
      Me.chbEnviarWebPanelDeFechasSalida.BindearPropiedadControl = Nothing
      Me.chbEnviarWebPanelDeFechasSalida.BindearPropiedadEntidad = Nothing
      Me.chbEnviarWebPanelDeFechasSalida.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEnviarWebPanelDeFechasSalida.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEnviarWebPanelDeFechasSalida.IsPK = False
      Me.chbEnviarWebPanelDeFechasSalida.IsRequired = False
      Me.chbEnviarWebPanelDeFechasSalida.Key = Nothing
      Me.chbEnviarWebPanelDeFechasSalida.LabelAsoc = Nothing
      Me.chbEnviarWebPanelDeFechasSalida.Location = New System.Drawing.Point(88, 171)
      Me.chbEnviarWebPanelDeFechasSalida.Name = "chbEnviarWebPanelDeFechasSalida"
      Me.chbEnviarWebPanelDeFechasSalida.Size = New System.Drawing.Size(171, 17)
      Me.chbEnviarWebPanelDeFechasSalida.TabIndex = 20
      Me.chbEnviarWebPanelDeFechasSalida.Text = "Enviar Panel de Fechas Salida"
      Me.chbEnviarWebPanelDeFechasSalida.UseVisualStyleBackColor = True
      '
      'SincronizarPanelDeControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(464, 219)
      Me.Controls.Add(Me.chbExportarPanelDeFechasSalida)
      Me.Controls.Add(Me.chbEnviarWebPanelDeFechasSalida)
      Me.Controls.Add(Me.chbExportarPanelDeControl)
      Me.Controls.Add(Me.chbEnviarWebPanelDeControl)
      Me.Controls.Add(Me.chbReenviar)
      Me.Controls.Add(Me.btnSincronizar)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.stsStado)
      Me.Name = "SincronizarPanelDeControl"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Sincronizar Panel de Control"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents bkgSincronizar As System.ComponentModel.BackgroundWorker
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents btnSincronizar As System.Windows.Forms.Button
   Friend WithEvents chbExportarPanelDeControl As Controles.CheckBox
   Friend WithEvents chbEnviarWebPanelDeControl As Controles.CheckBox
   Friend WithEvents chbReenviar As Controles.CheckBox
   Friend WithEvents chbExportarPanelDeFechasSalida As Controles.CheckBox
   Friend WithEvents chbEnviarWebPanelDeFechasSalida As Controles.CheckBox
End Class
