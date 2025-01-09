<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirPlanilla
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImprimirPlanilla))
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.grbComprador = New System.Windows.Forms.GroupBox()
      Me.optVertical = New Eniac.Controles.RadioButton()
      Me.optHorizontal = New Eniac.Controles.RadioButton()
      Me.btnCerrar = New System.Windows.Forms.Button()
      Me.chkObservaciones = New System.Windows.Forms.CheckBox()
      Me.btnImprimir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.grbComprador.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grbComprador)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.chkObservaciones)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 149)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'grbComprador
        '
        Me.grbComprador.Controls.Add(Me.optVertical)
        Me.grbComprador.Controls.Add(Me.optHorizontal)
        Me.grbComprador.Location = New System.Drawing.Point(15, 19)
        Me.grbComprador.Name = "grbComprador"
        Me.grbComprador.Size = New System.Drawing.Size(182, 47)
        Me.grbComprador.TabIndex = 1
        Me.grbComprador.TabStop = False
        Me.grbComprador.Text = "Tipo de Reporte"
        '
        'optVertical
        '
        Me.optVertical.AutoSize = True
        Me.optVertical.BindearPropiedadControl = Nothing
        Me.optVertical.BindearPropiedadEntidad = Nothing
        Me.optVertical.Checked = True
        Me.optVertical.ForeColorFocus = System.Drawing.Color.Red
        Me.optVertical.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optVertical.IsPK = False
        Me.optVertical.IsRequired = False
        Me.optVertical.Key = Nothing
        Me.optVertical.LabelAsoc = Nothing
        Me.optVertical.Location = New System.Drawing.Point(17, 20)
        Me.optVertical.Name = "optVertical"
        Me.optVertical.Size = New System.Drawing.Size(60, 17)
        Me.optVertical.TabIndex = 0
        Me.optVertical.TabStop = True
        Me.optVertical.Text = "Vertical"
        Me.optVertical.UseVisualStyleBackColor = True
        '
        'optHorizontal
        '
        Me.optHorizontal.AutoSize = True
        Me.optHorizontal.BindearPropiedadControl = Nothing
        Me.optHorizontal.BindearPropiedadEntidad = Nothing
        Me.optHorizontal.ForeColorFocus = System.Drawing.Color.Red
        Me.optHorizontal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optHorizontal.IsPK = False
        Me.optHorizontal.IsRequired = False
        Me.optHorizontal.Key = Nothing
        Me.optHorizontal.LabelAsoc = Nothing
        Me.optHorizontal.Location = New System.Drawing.Point(95, 20)
        Me.optHorizontal.Name = "optHorizontal"
        Me.optHorizontal.Size = New System.Drawing.Size(72, 17)
        Me.optHorizontal.TabIndex = 1
        Me.optHorizontal.Text = "Horizontal"
        Me.optHorizontal.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(191, 98)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(100, 45)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'chkObservaciones
        '
        Me.chkObservaciones.AutoSize = True
        Me.chkObservaciones.Location = New System.Drawing.Point(15, 75)
        Me.chkObservaciones.Name = "chkObservaciones"
        Me.chkObservaciones.Size = New System.Drawing.Size(133, 17)
        Me.chkObservaciones.TabIndex = 2
        Me.chkObservaciones.Text = "Detalla Observaciones"
        Me.chkObservaciones.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(80, 98)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(100, 45)
        Me.btnImprimir.TabIndex = 3
        Me.btnImprimir.Text = "&Imprimir..."
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'ImprimirPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 175)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImprimirPlanilla"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Impresión de Planilla de Caja.."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbComprador.ResumeLayout(False)
        Me.grbComprador.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chkObservaciones As System.Windows.Forms.CheckBox
   Friend WithEvents btnImprimir As System.Windows.Forms.Button
   Friend WithEvents btnCerrar As System.Windows.Forms.Button
   Friend WithEvents grbComprador As System.Windows.Forms.GroupBox
   Friend WithEvents optVertical As Eniac.Controles.RadioButton
   Friend WithEvents optHorizontal As Eniac.Controles.RadioButton
End Class
