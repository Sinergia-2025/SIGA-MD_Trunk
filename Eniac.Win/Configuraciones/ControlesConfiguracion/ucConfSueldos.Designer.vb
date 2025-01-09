<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfSueldos
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
      Me.lblSueldosConceptoAguinaldo = New Eniac.Controles.Label()
      Me.txtSueldosConceptoAguinaldo = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'lblSueldosConceptoAguinaldo
      '
      Me.lblSueldosConceptoAguinaldo.AutoSize = True
      Me.lblSueldosConceptoAguinaldo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSueldosConceptoAguinaldo.LabelAsoc = Nothing
      Me.lblSueldosConceptoAguinaldo.Location = New System.Drawing.Point(65, 49)
      Me.lblSueldosConceptoAguinaldo.Name = "lblSueldosConceptoAguinaldo"
      Me.lblSueldosConceptoAguinaldo.Size = New System.Drawing.Size(118, 13)
      Me.lblSueldosConceptoAguinaldo.TabIndex = 1
      Me.lblSueldosConceptoAguinaldo.Text = "Concepto de Aguinaldo"
      '
      'txtSueldosConceptoAguinaldo
      '
      Me.txtSueldosConceptoAguinaldo.BindearPropiedadControl = Nothing
      Me.txtSueldosConceptoAguinaldo.BindearPropiedadEntidad = Nothing
      Me.txtSueldosConceptoAguinaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSueldosConceptoAguinaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSueldosConceptoAguinaldo.Formato = ""
      Me.txtSueldosConceptoAguinaldo.IsDecimal = False
      Me.txtSueldosConceptoAguinaldo.IsNumber = True
      Me.txtSueldosConceptoAguinaldo.IsPK = False
      Me.txtSueldosConceptoAguinaldo.IsRequired = False
      Me.txtSueldosConceptoAguinaldo.Key = ""
      Me.txtSueldosConceptoAguinaldo.LabelAsoc = Nothing
      Me.txtSueldosConceptoAguinaldo.Location = New System.Drawing.Point(20, 46)
      Me.txtSueldosConceptoAguinaldo.MaxLength = 5
      Me.txtSueldosConceptoAguinaldo.Name = "txtSueldosConceptoAguinaldo"
      Me.txtSueldosConceptoAguinaldo.Size = New System.Drawing.Size(40, 20)
      Me.txtSueldosConceptoAguinaldo.TabIndex = 0
      Me.txtSueldosConceptoAguinaldo.Tag = "SUELDOS_CONCEPTO_AGUINALDO"
      Me.txtSueldosConceptoAguinaldo.Text = "0"
      Me.txtSueldosConceptoAguinaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ucConfSueldos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.lblSueldosConceptoAguinaldo)
      Me.Controls.Add(Me.txtSueldosConceptoAguinaldo)
      Me.Name = "ucConfSueldos"
      Me.Controls.SetChildIndex(Me.txtSueldosConceptoAguinaldo, 0)
      Me.Controls.SetChildIndex(Me.lblSueldosConceptoAguinaldo, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents lblSueldosConceptoAguinaldo As Controles.Label
   Friend WithEvents txtSueldosConceptoAguinaldo As Controles.TextBox
End Class
