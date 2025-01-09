<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNDConfExpensas
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.chbPasajeComprasIncluyeImpuestos = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'chbPasajeComprasIncluyeImpuestos
      '
      Me.chbPasajeComprasIncluyeImpuestos.BindearPropiedadControl = Nothing
      Me.chbPasajeComprasIncluyeImpuestos.BindearPropiedadEntidad = Nothing
      Me.chbPasajeComprasIncluyeImpuestos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPasajeComprasIncluyeImpuestos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPasajeComprasIncluyeImpuestos.IsPK = False
      Me.chbPasajeComprasIncluyeImpuestos.IsRequired = False
      Me.chbPasajeComprasIncluyeImpuestos.Key = Nothing
      Me.chbPasajeComprasIncluyeImpuestos.LabelAsoc = Nothing
      Me.chbPasajeComprasIncluyeImpuestos.Location = New System.Drawing.Point(20, 46)
      Me.chbPasajeComprasIncluyeImpuestos.Name = "chbPasajeComprasIncluyeImpuestos"
      Me.chbPasajeComprasIncluyeImpuestos.Size = New System.Drawing.Size(203, 28)
      Me.chbPasajeComprasIncluyeImpuestos.TabIndex = 59
      Me.chbPasajeComprasIncluyeImpuestos.Text = "Pasaje de compras incluye impuestos"
      Me.chbPasajeComprasIncluyeImpuestos.UseVisualStyleBackColor = True
      '
      'ucNDConfExpensas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.chbPasajeComprasIncluyeImpuestos)
      Me.Name = "ucNDConfExpensas"
      Me.Controls.SetChildIndex(Me.chbPasajeComprasIncluyeImpuestos, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents chbPasajeComprasIncluyeImpuestos As Controles.CheckBox
End Class
