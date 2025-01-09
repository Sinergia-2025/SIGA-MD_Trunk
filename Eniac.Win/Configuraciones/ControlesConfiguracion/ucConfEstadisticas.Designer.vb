<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfEstadisticas
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
      Me.Label15 = New Eniac.Controles.Label()
      Me.lblMinutosTableroComando = New Eniac.Controles.Label()
      Me.txtMinutosTableroComando = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label15.LabelAsoc = Nothing
      Me.Label15.Location = New System.Drawing.Point(14, 8)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(111, 13)
      Me.Label15.TabIndex = 61
      Me.Label15.Text = "Tablero de Comandos"
      '
      'lblMinutosTableroComando
      '
      Me.lblMinutosTableroComando.AutoSize = True
      Me.lblMinutosTableroComando.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMinutosTableroComando.LabelAsoc = Nothing
      Me.lblMinutosTableroComando.Location = New System.Drawing.Point(173, 8)
      Me.lblMinutosTableroComando.Name = "lblMinutosTableroComando"
      Me.lblMinutosTableroComando.Size = New System.Drawing.Size(173, 13)
      Me.lblMinutosTableroComando.TabIndex = 60
      Me.lblMinutosTableroComando.Text = "minutos - Actualización automática "
      '
      'txtMinutosTableroComando
      '
      Me.txtMinutosTableroComando.BindearPropiedadControl = Nothing
      Me.txtMinutosTableroComando.BindearPropiedadEntidad = Nothing
      Me.txtMinutosTableroComando.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMinutosTableroComando.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMinutosTableroComando.Formato = ""
      Me.txtMinutosTableroComando.IsDecimal = False
      Me.txtMinutosTableroComando.IsNumber = True
      Me.txtMinutosTableroComando.IsPK = False
      Me.txtMinutosTableroComando.IsRequired = False
      Me.txtMinutosTableroComando.Key = ""
      Me.txtMinutosTableroComando.LabelAsoc = Me.lblMinutosTableroComando
      Me.txtMinutosTableroComando.Location = New System.Drawing.Point(129, 5)
      Me.txtMinutosTableroComando.MaxLength = 5
      Me.txtMinutosTableroComando.Name = "txtMinutosTableroComando"
      Me.txtMinutosTableroComando.Size = New System.Drawing.Size(40, 20)
      Me.txtMinutosTableroComando.TabIndex = 59
      Me.txtMinutosTableroComando.Tag = ""
      Me.txtMinutosTableroComando.Text = "0"
      Me.txtMinutosTableroComando.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ucConfEstadisticas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.lblMinutosTableroComando)
      Me.Controls.Add(Me.txtMinutosTableroComando)
      Me.Name = "ucConfEstadisticas"
      Me.Controls.SetChildIndex(Me.txtMinutosTableroComando, 0)
      Me.Controls.SetChildIndex(Me.lblMinutosTableroComando, 0)
      Me.Controls.SetChildIndex(Me.Label15, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents Label15 As Controles.Label
   Friend WithEvents lblMinutosTableroComando As Controles.Label
   Friend WithEvents txtMinutosTableroComando As Controles.TextBox
End Class
