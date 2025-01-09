<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AduanasDespachantesDetalle
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
      Me.lblNombreDespachante = New Eniac.Controles.Label()
      Me.txtNombreDespachante = New Eniac.Controles.TextBox()
      Me.lblIdDespachante = New Eniac.Controles.Label()
      Me.txtIdDespachante = New Eniac.Controles.TextBox()
      Me.lblCuit = New Eniac.Controles.Label()
      Me.txtCuit = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(239, 81)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(325, 81)
      Me.btnCancelar.TabIndex = 4
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 209)
      '
      'lblNombreDespachante
      '
      Me.lblNombreDespachante.AutoSize = True
      Me.lblNombreDespachante.Location = New System.Drawing.Point(8, 42)
      Me.lblNombreDespachante.Name = "lblNombreDespachante"
      Me.lblNombreDespachante.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreDespachante.TabIndex = 6
      Me.lblNombreDespachante.Text = "Nombre"
      '
      'txtNombreDespachante
      '
      Me.txtNombreDespachante.BindearPropiedadControl = "Text"
      Me.txtNombreDespachante.BindearPropiedadEntidad = "NombreDespachante"
      Me.txtNombreDespachante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreDespachante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreDespachante.Formato = ""
      Me.txtNombreDespachante.IsDecimal = False
      Me.txtNombreDespachante.IsNumber = False
      Me.txtNombreDespachante.IsPK = False
      Me.txtNombreDespachante.IsRequired = True
      Me.txtNombreDespachante.Key = ""
      Me.txtNombreDespachante.LabelAsoc = Me.lblNombreDespachante
      Me.txtNombreDespachante.Location = New System.Drawing.Point(53, 38)
      Me.txtNombreDespachante.MaxLength = 50
      Me.txtNombreDespachante.Name = "txtNombreDespachante"
      Me.txtNombreDespachante.Size = New System.Drawing.Size(351, 20)
      Me.txtNombreDespachante.TabIndex = 1
      '
      'lblIdDespachante
      '
      Me.lblIdDespachante.AutoSize = True
      Me.lblIdDespachante.Location = New System.Drawing.Point(8, 16)
      Me.lblIdDespachante.Name = "lblIdDespachante"
      Me.lblIdDespachante.Size = New System.Drawing.Size(40, 13)
      Me.lblIdDespachante.TabIndex = 5
      Me.lblIdDespachante.Text = "Código"
      '
      'txtIdDespachante
      '
      Me.txtIdDespachante.BindearPropiedadControl = "Text"
      Me.txtIdDespachante.BindearPropiedadEntidad = "IdDespachante"
      Me.txtIdDespachante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdDespachante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdDespachante.Formato = ""
      Me.txtIdDespachante.IsDecimal = False
      Me.txtIdDespachante.IsNumber = True
      Me.txtIdDespachante.IsPK = True
      Me.txtIdDespachante.IsRequired = True
      Me.txtIdDespachante.Key = ""
      Me.txtIdDespachante.LabelAsoc = Me.lblIdDespachante
      Me.txtIdDespachante.Location = New System.Drawing.Point(53, 12)
      Me.txtIdDespachante.MaxLength = 5
      Me.txtIdDespachante.Name = "txtIdDespachante"
      Me.txtIdDespachante.Size = New System.Drawing.Size(60, 20)
      Me.txtIdDespachante.TabIndex = 0
      Me.txtIdDespachante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCuit
      '
      Me.lblCuit.AutoSize = True
      Me.lblCuit.Location = New System.Drawing.Point(8, 71)
      Me.lblCuit.Name = "lblCuit"
      Me.lblCuit.Size = New System.Drawing.Size(32, 13)
      Me.lblCuit.TabIndex = 7
      Me.lblCuit.Text = "CUIT"
      '
      'txtCuit
      '
      Me.txtCuit.BindearPropiedadControl = "Text"
      Me.txtCuit.BindearPropiedadEntidad = "Cuit"
      Me.txtCuit.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuit.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuit.Formato = ""
      Me.txtCuit.IsDecimal = False
      Me.txtCuit.IsNumber = True
      Me.txtCuit.IsPK = False
      Me.txtCuit.IsRequired = True
      Me.txtCuit.Key = ""
      Me.txtCuit.LabelAsoc = Me.lblCuit
      Me.txtCuit.Location = New System.Drawing.Point(53, 67)
      Me.txtCuit.MaxLength = 11
      Me.txtCuit.Name = "txtCuit"
      Me.txtCuit.Size = New System.Drawing.Size(96, 20)
      Me.txtCuit.TabIndex = 2
      Me.txtCuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'AduanasDespachantesDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(417, 123)
      Me.Controls.Add(Me.lblCuit)
      Me.Controls.Add(Me.txtCuit)
      Me.Controls.Add(Me.lblNombreDespachante)
      Me.Controls.Add(Me.txtNombreDespachante)
      Me.Controls.Add(Me.lblIdDespachante)
      Me.Controls.Add(Me.txtIdDespachante)
      Me.Name = "AduanasDespachantesDetalle"
      Me.Text = "Despachante de Aduana"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdDespachante, 0)
      Me.Controls.SetChildIndex(Me.lblIdDespachante, 0)
      Me.Controls.SetChildIndex(Me.txtNombreDespachante, 0)
      Me.Controls.SetChildIndex(Me.lblNombreDespachante, 0)
      Me.Controls.SetChildIndex(Me.txtCuit, 0)
      Me.Controls.SetChildIndex(Me.lblCuit, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreDespachante As Eniac.Controles.Label
   Friend WithEvents txtNombreDespachante As Eniac.Controles.TextBox
   Friend WithEvents lblIdDespachante As Eniac.Controles.Label
   Friend WithEvents txtIdDespachante As Eniac.Controles.TextBox
   Friend WithEvents lblCuit As Eniac.Controles.Label
   Friend WithEvents txtCuit As Eniac.Controles.TextBox
End Class
