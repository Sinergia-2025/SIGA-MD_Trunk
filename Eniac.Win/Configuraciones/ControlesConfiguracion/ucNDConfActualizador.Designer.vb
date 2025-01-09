<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNDConfActualizador
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
      Me.lblPathDescargaMSIActualizador = New Eniac.Controles.Label()
      Me.txtPathDescargaMSIActualizador = New Eniac.Controles.TextBox()
      Me.txtURLActualizador = New System.Windows.Forms.TextBox()
      Me.lblURLActualizador = New System.Windows.Forms.Label()
      Me.cmdDestinoArchivosMSI = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPathDescargaMSIActualizador
        '
        Me.lblPathDescargaMSIActualizador.AutoSize = True
        Me.lblPathDescargaMSIActualizador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPathDescargaMSIActualizador.LabelAsoc = Nothing
        Me.lblPathDescargaMSIActualizador.Location = New System.Drawing.Point(13, 89)
        Me.lblPathDescargaMSIActualizador.Name = "lblPathDescargaMSIActualizador"
        Me.lblPathDescargaMSIActualizador.Size = New System.Drawing.Size(100, 13)
        Me.lblPathDescargaMSIActualizador.TabIndex = 63
        Me.lblPathDescargaMSIActualizador.Text = "Path Descarga MSI"
        '
        'txtPathDescargaMSIActualizador
        '
        Me.txtPathDescargaMSIActualizador.BindearPropiedadControl = Nothing
        Me.txtPathDescargaMSIActualizador.BindearPropiedadEntidad = Nothing
        Me.txtPathDescargaMSIActualizador.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPathDescargaMSIActualizador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPathDescargaMSIActualizador.Formato = ""
        Me.txtPathDescargaMSIActualizador.IsDecimal = False
        Me.txtPathDescargaMSIActualizador.IsNumber = False
        Me.txtPathDescargaMSIActualizador.IsPK = False
        Me.txtPathDescargaMSIActualizador.IsRequired = False
        Me.txtPathDescargaMSIActualizador.Key = ""
        Me.txtPathDescargaMSIActualizador.LabelAsoc = Me.lblPathDescargaMSIActualizador
        Me.txtPathDescargaMSIActualizador.Location = New System.Drawing.Point(120, 86)
        Me.txtPathDescargaMSIActualizador.Name = "txtPathDescargaMSIActualizador"
        Me.txtPathDescargaMSIActualizador.Size = New System.Drawing.Size(271, 20)
        Me.txtPathDescargaMSIActualizador.TabIndex = 62
        Me.txtPathDescargaMSIActualizador.Tag = "UBICACIONMSI"
        '
        'txtURLActualizador
        '
        Me.txtURLActualizador.Location = New System.Drawing.Point(120, 55)
        Me.txtURLActualizador.MaxLength = 110
        Me.txtURLActualizador.Name = "txtURLActualizador"
        Me.txtURLActualizador.Size = New System.Drawing.Size(305, 20)
        Me.txtURLActualizador.TabIndex = 60
        '
        'lblURLActualizador
        '
        Me.lblURLActualizador.AutoSize = True
        Me.lblURLActualizador.Location = New System.Drawing.Point(13, 58)
        Me.lblURLActualizador.Name = "lblURLActualizador"
        Me.lblURLActualizador.Size = New System.Drawing.Size(107, 13)
        Me.lblURLActualizador.TabIndex = 59
        Me.lblURLActualizador.Text = "URL del Actualizador"
        '
        'cmdDestinoArchivosMSI
        '
        Me.cmdDestinoArchivosMSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDestinoArchivosMSI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDestinoArchivosMSI.Location = New System.Drawing.Point(397, 84)
        Me.cmdDestinoArchivosMSI.Name = "cmdDestinoArchivosMSI"
        Me.cmdDestinoArchivosMSI.Size = New System.Drawing.Size(28, 23)
        Me.cmdDestinoArchivosMSI.TabIndex = 61
        Me.cmdDestinoArchivosMSI.Text = "..."
        Me.cmdDestinoArchivosMSI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDestinoArchivosMSI.UseVisualStyleBackColor = True
        '
        'ucNDConfActualizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPathDescargaMSIActualizador)
        Me.Controls.Add(Me.txtPathDescargaMSIActualizador)
        Me.Controls.Add(Me.txtURLActualizador)
        Me.Controls.Add(Me.lblURLActualizador)
        Me.Controls.Add(Me.cmdDestinoArchivosMSI)
        Me.Name = "ucNDConfActualizador"
        Me.Controls.SetChildIndex(Me.cmdDestinoArchivosMSI, 0)
        Me.Controls.SetChildIndex(Me.lblURLActualizador, 0)
        Me.Controls.SetChildIndex(Me.txtURLActualizador, 0)
        Me.Controls.SetChildIndex(Me.txtPathDescargaMSIActualizador, 0)
        Me.Controls.SetChildIndex(Me.lblPathDescargaMSIActualizador, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPathDescargaMSIActualizador As Controles.Label
   Friend WithEvents txtPathDescargaMSIActualizador As Controles.TextBox
   Friend WithEvents txtURLActualizador As TextBox
   Friend WithEvents lblURLActualizador As Label
   Friend WithEvents cmdDestinoArchivosMSI As Button
End Class
