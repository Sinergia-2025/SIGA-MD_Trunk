<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirCRMEnOtroEstado
   Inherits BaseDetalle

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
      Me.cmbEstadoCRM = New Eniac.Controles.ComboBox()
      Me.lblEstado = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(114, 82)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(200, 82)
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(13, 82)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(-44, 82)
      '
      'cmbEstadoCRM
      '
      Me.cmbEstadoCRM.BindearPropiedadControl = Nothing
      Me.cmbEstadoCRM.BindearPropiedadEntidad = Nothing
      Me.cmbEstadoCRM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoCRM.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoCRM.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoCRM.FormattingEnabled = True
      Me.cmbEstadoCRM.IsPK = False
      Me.cmbEstadoCRM.IsRequired = False
      Me.cmbEstadoCRM.Key = Nothing
      Me.cmbEstadoCRM.LabelAsoc = Nothing
      Me.cmbEstadoCRM.Location = New System.Drawing.Point(78, 32)
      Me.cmbEstadoCRM.Name = "cmbEstadoCRM"
      Me.cmbEstadoCRM.Size = New System.Drawing.Size(169, 21)
      Me.cmbEstadoCRM.TabIndex = 5
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.Location = New System.Drawing.Point(32, 35)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 6
      Me.lblEstado.Text = "Estado"
      '
      'ImprimirCRMEnOtroEstado
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(289, 117)
      Me.Controls.Add(Me.lblEstado)
      Me.Controls.Add(Me.cmbEstadoCRM)
      Me.Name = "ImprimirCRMEnOtroEstado"
      Me.Text = "Seleccionar Estado"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.cmbEstadoCRM, 0)
      Me.Controls.SetChildIndex(Me.lblEstado, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbEstadoCRM As Eniac.Controles.ComboBox
   Friend WithEvents lblEstado As System.Windows.Forms.Label
End Class
