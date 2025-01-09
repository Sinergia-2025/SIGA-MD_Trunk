<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfAppMovilesSoporte
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
      Me.txtSimovilSoporteUsuarioDefault = New Eniac.Controles.TextBox()
      Me.lblSimovilSoporteUsuarioDefault = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'txtSimovilSoporteUsuarioDefault
      '
      Me.txtSimovilSoporteUsuarioDefault.BindearPropiedadControl = Nothing
      Me.txtSimovilSoporteUsuarioDefault.BindearPropiedadEntidad = Nothing
      Me.txtSimovilSoporteUsuarioDefault.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSimovilSoporteUsuarioDefault.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSimovilSoporteUsuarioDefault.Formato = ""
      Me.txtSimovilSoporteUsuarioDefault.IsDecimal = False
      Me.txtSimovilSoporteUsuarioDefault.IsNumber = False
      Me.txtSimovilSoporteUsuarioDefault.IsPK = False
      Me.txtSimovilSoporteUsuarioDefault.IsRequired = False
      Me.txtSimovilSoporteUsuarioDefault.Key = ""
      Me.txtSimovilSoporteUsuarioDefault.LabelAsoc = Me.lblSimovilSoporteUsuarioDefault
      Me.txtSimovilSoporteUsuarioDefault.Location = New System.Drawing.Point(81, 46)
      Me.txtSimovilSoporteUsuarioDefault.MaxLength = 200
      Me.txtSimovilSoporteUsuarioDefault.Name = "txtSimovilSoporteUsuarioDefault"
      Me.txtSimovilSoporteUsuarioDefault.Size = New System.Drawing.Size(120, 20)
      Me.txtSimovilSoporteUsuarioDefault.TabIndex = 60
      '
      'lblSimovilSoporteUsuarioDefault
      '
      Me.lblSimovilSoporteUsuarioDefault.AutoSize = True
      Me.lblSimovilSoporteUsuarioDefault.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSimovilSoporteUsuarioDefault.LabelAsoc = Nothing
      Me.lblSimovilSoporteUsuarioDefault.Location = New System.Drawing.Point(32, 49)
      Me.lblSimovilSoporteUsuarioDefault.Name = "lblSimovilSoporteUsuarioDefault"
      Me.lblSimovilSoporteUsuarioDefault.Size = New System.Drawing.Size(43, 13)
      Me.lblSimovilSoporteUsuarioDefault.TabIndex = 59
      Me.lblSimovilSoporteUsuarioDefault.Text = "Usuario"
      '
      'ucConfAppMovilesSoporte
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.txtSimovilSoporteUsuarioDefault)
      Me.Controls.Add(Me.lblSimovilSoporteUsuarioDefault)
      Me.Name = "ucConfAppMovilesSoporte"
      Me.Controls.SetChildIndex(Me.lblSimovilSoporteUsuarioDefault, 0)
      Me.Controls.SetChildIndex(Me.txtSimovilSoporteUsuarioDefault, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents txtSimovilSoporteUsuarioDefault As Controles.TextBox
   Friend WithEvents lblSimovilSoporteUsuarioDefault As Controles.Label
End Class
