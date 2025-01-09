<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AduanasDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.lblNombreAduana = New Eniac.Controles.Label()
      Me.txtNombreAduana = New Eniac.Controles.TextBox()
      Me.lblIdAduana = New Eniac.Controles.Label()
      Me.txtIdAduana = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(239, 71)
      Me.btnAceptar.TabIndex = 2
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(325, 71)
      Me.btnCancelar.TabIndex = 3
      '
      'lblNombreAduana
      '
      Me.lblNombreAduana.AutoSize = True
      Me.lblNombreAduana.Location = New System.Drawing.Point(4, 44)
      Me.lblNombreAduana.Name = "lblNombreAduana"
      Me.lblNombreAduana.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreAduana.TabIndex = 5
      Me.lblNombreAduana.Text = "Nombre"
      '
      'txtNombreAduana
      '
      Me.txtNombreAduana.BindearPropiedadControl = "Text"
      Me.txtNombreAduana.BindearPropiedadEntidad = "NombreAduana"
      Me.txtNombreAduana.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreAduana.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreAduana.Formato = ""
      Me.txtNombreAduana.IsDecimal = False
      Me.txtNombreAduana.IsNumber = False
      Me.txtNombreAduana.IsPK = False
      Me.txtNombreAduana.IsRequired = True
      Me.txtNombreAduana.Key = ""
      Me.txtNombreAduana.LabelAsoc = Me.lblNombreAduana
      Me.txtNombreAduana.Location = New System.Drawing.Point(53, 40)
      Me.txtNombreAduana.MaxLength = 50
      Me.txtNombreAduana.Name = "txtNombreAduana"
      Me.txtNombreAduana.Size = New System.Drawing.Size(351, 20)
      Me.txtNombreAduana.TabIndex = 1
      '
      'lblIdAduana
      '
      Me.lblIdAduana.AutoSize = True
      Me.lblIdAduana.Location = New System.Drawing.Point(4, 16)
      Me.lblIdAduana.Name = "lblIdAduana"
      Me.lblIdAduana.Size = New System.Drawing.Size(40, 13)
      Me.lblIdAduana.TabIndex = 4
      Me.lblIdAduana.Text = "Código"
      '
      'txtIdAduana
      '
      Me.txtIdAduana.BindearPropiedadControl = "Text"
      Me.txtIdAduana.BindearPropiedadEntidad = "IdAduana"
      Me.txtIdAduana.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdAduana.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdAduana.Formato = ""
      Me.txtIdAduana.IsDecimal = False
      Me.txtIdAduana.IsNumber = True
      Me.txtIdAduana.IsPK = True
      Me.txtIdAduana.IsRequired = True
      Me.txtIdAduana.Key = ""
      Me.txtIdAduana.LabelAsoc = Me.lblIdAduana
      Me.txtIdAduana.Location = New System.Drawing.Point(53, 12)
      Me.txtIdAduana.MaxLength = 5
      Me.txtIdAduana.Name = "txtIdAduana"
      Me.txtIdAduana.Size = New System.Drawing.Size(60, 20)
      Me.txtIdAduana.TabIndex = 0
      Me.txtIdAduana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'AduanasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(417, 113)
      Me.Controls.Add(Me.lblNombreAduana)
      Me.Controls.Add(Me.txtNombreAduana)
      Me.Controls.Add(Me.lblIdAduana)
      Me.Controls.Add(Me.txtIdAduana)
      Me.Name = "AduanasDetalle"
      Me.Text = "Aduana"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdAduana, 0)
      Me.Controls.SetChildIndex(Me.lblIdAduana, 0)
      Me.Controls.SetChildIndex(Me.txtNombreAduana, 0)
      Me.Controls.SetChildIndex(Me.lblNombreAduana, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreAduana As Eniac.Controles.Label
   Friend WithEvents txtNombreAduana As Eniac.Controles.TextBox
   Friend WithEvents lblIdAduana As Eniac.Controles.Label
   Friend WithEvents txtIdAduana As Eniac.Controles.TextBox
End Class
