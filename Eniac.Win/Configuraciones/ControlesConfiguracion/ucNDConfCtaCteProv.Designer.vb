<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNDConfCtaCteProv
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
      Me.chbMuestraObs = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'chbMuestraObs
      '
      Me.chbMuestraObs.BindearPropiedadControl = Nothing
      Me.chbMuestraObs.BindearPropiedadEntidad = Nothing
      Me.chbMuestraObs.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMuestraObs.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMuestraObs.IsPK = False
      Me.chbMuestraObs.IsRequired = False
      Me.chbMuestraObs.Key = Nothing
      Me.chbMuestraObs.LabelAsoc = Nothing
      Me.chbMuestraObs.Location = New System.Drawing.Point(16, 14)
      Me.chbMuestraObs.Name = "chbMuestraObs"
      Me.chbMuestraObs.Size = New System.Drawing.Size(288, 29)
      Me.chbMuestraObs.TabIndex = 59
      Me.chbMuestraObs.Tag = "MOSTRAROBSERVACIONDECOMPROBANTES"
      Me.chbMuestraObs.Text = "Mostrar Observaciones de Comprobante"
      Me.chbMuestraObs.UseVisualStyleBackColor = True
      '
      'ucNDConfCtaCteProv
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.chbMuestraObs)
      Me.Name = "ucNDConfCtaCteProv"
      Me.Controls.SetChildIndex(Me.chbMuestraObs, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents chbMuestraObs As Controles.CheckBox
End Class
