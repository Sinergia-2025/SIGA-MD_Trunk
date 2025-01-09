<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VinculacionToken
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
      Me.btnToken = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtToken = New System.Windows.Forms.TextBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnToken
      '
      Me.btnToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnToken.Image = Global.Eniac.Win.My.Resources.Resources.exchange
      Me.btnToken.Location = New System.Drawing.Point(77, 32)
      Me.btnToken.Name = "btnToken"
      Me.btnToken.Size = New System.Drawing.Size(220, 92)
      Me.btnToken.TabIndex = 20
      Me.btnToken.Text = "Generar Token"
      Me.btnToken.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnToken.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnToken.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(152, 135)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(71, 13)
      Me.Label1.TabIndex = 21
      Me.Label1.Text = "Token Actual"
      '
      'txtToken
      '
      Me.txtToken.Location = New System.Drawing.Point(22, 151)
      Me.txtToken.Name = "txtToken"
      Me.txtToken.ReadOnly = True
      Me.txtToken.Size = New System.Drawing.Size(333, 20)
      Me.txtToken.TabIndex = 22
      Me.txtToken.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(387, 29)
      Me.tstBarra.TabIndex = 27
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'VinculacionToken
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(387, 190)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.txtToken)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.btnToken)
      Me.Name = "VinculacionToken"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Tienda Nube - Vinculacion Token"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnToken As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtToken As System.Windows.Forms.TextBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
End Class
