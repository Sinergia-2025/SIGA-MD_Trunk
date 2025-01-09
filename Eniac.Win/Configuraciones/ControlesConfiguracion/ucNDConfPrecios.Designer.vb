<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNDConfPrecios
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
      Me.chbPreciosConIVA = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'chbPreciosConIVA
      '
      Me.chbPreciosConIVA.BindearPropiedadControl = Nothing
      Me.chbPreciosConIVA.BindearPropiedadEntidad = Nothing
      Me.chbPreciosConIVA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPreciosConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPreciosConIVA.IsPK = False
      Me.chbPreciosConIVA.IsRequired = False
      Me.chbPreciosConIVA.Key = Nothing
      Me.chbPreciosConIVA.LabelAsoc = Nothing
      Me.chbPreciosConIVA.Location = New System.Drawing.Point(7, 6)
      Me.chbPreciosConIVA.Name = "chbPreciosConIVA"
      Me.chbPreciosConIVA.Size = New System.Drawing.Size(219, 19)
      Me.chbPreciosConIVA.TabIndex = 59
      Me.chbPreciosConIVA.Tag = "PRECIOCONIVA"
      Me.chbPreciosConIVA.Text = "Precios con IVA en la lista de precios"
      Me.chbPreciosConIVA.UseVisualStyleBackColor = True
      '
      'ucNDConfPrecios
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.chbPreciosConIVA)
      Me.Name = "ucNDConfPrecios"
      Me.Controls.SetChildIndex(Me.chbPreciosConIVA, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents chbPreciosConIVA As Controles.CheckBox
End Class
