<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorReportes
   'Inherits BaseForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisorReportes))
      Me.rvReporte = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.btnEnviarPorMail = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'rvReporte
      '
      Me.rvReporte.Dock = System.Windows.Forms.DockStyle.Fill
      Me.rvReporte.Location = New System.Drawing.Point(0, 0)
      Me.rvReporte.Name = "rvReporte"
      Me.rvReporte.Size = New System.Drawing.Size(766, 420)
      Me.rvReporte.TabIndex = 0
      '
      'btnEnviarPorMail
      '
      Me.btnEnviarPorMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEnviarPorMail.Location = New System.Drawing.Point(666, 2)
      Me.btnEnviarPorMail.Name = "btnEnviarPorMail"
      Me.btnEnviarPorMail.Size = New System.Drawing.Size(97, 23)
      Me.btnEnviarPorMail.TabIndex = 1
      Me.btnEnviarPorMail.Text = "Enviar por mail..."
      Me.btnEnviarPorMail.UseVisualStyleBackColor = True
      '
      'VisorReportes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(766, 420)
      Me.Controls.Add(Me.btnEnviarPorMail)
      Me.Controls.Add(Me.rvReporte)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "VisorReportes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "VisorReportes"
      Me.ResumeLayout(False)

   End Sub
   Public WithEvents rvReporte As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents btnEnviarPorMail As System.Windows.Forms.Button
   'Friend WithEvents MarinzaldiDataSet As Eniac.Marinzaldi.Win.MarinzaldiDataSet

End Class
