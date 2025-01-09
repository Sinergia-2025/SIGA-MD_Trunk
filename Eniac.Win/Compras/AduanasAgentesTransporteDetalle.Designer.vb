<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AduanasAgentesTransporteDetalle
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
      Me.lblNombreAgenteTransporte = New Eniac.Controles.Label()
      Me.txtNombreAgenteTransporte = New Eniac.Controles.TextBox()
      Me.lblIdAgenteTransporte = New Eniac.Controles.Label()
      Me.txtIdAgenteTransporte = New Eniac.Controles.TextBox()
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
      'lblNombreAgenteTransporte
      '
      Me.lblNombreAgenteTransporte.AutoSize = True
      Me.lblNombreAgenteTransporte.Location = New System.Drawing.Point(8, 42)
      Me.lblNombreAgenteTransporte.Name = "lblNombreAgenteTransporte"
      Me.lblNombreAgenteTransporte.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreAgenteTransporte.TabIndex = 6
      Me.lblNombreAgenteTransporte.Text = "Nombre"
      '
      'txtNombreAgenteTransporte
      '
      Me.txtNombreAgenteTransporte.BindearPropiedadControl = "Text"
      Me.txtNombreAgenteTransporte.BindearPropiedadEntidad = "NombreAgenteTransporte"
      Me.txtNombreAgenteTransporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreAgenteTransporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreAgenteTransporte.Formato = ""
      Me.txtNombreAgenteTransporte.IsDecimal = False
      Me.txtNombreAgenteTransporte.IsNumber = False
      Me.txtNombreAgenteTransporte.IsPK = False
      Me.txtNombreAgenteTransporte.IsRequired = True
      Me.txtNombreAgenteTransporte.Key = ""
      Me.txtNombreAgenteTransporte.LabelAsoc = Me.lblNombreAgenteTransporte
      Me.txtNombreAgenteTransporte.Location = New System.Drawing.Point(53, 38)
      Me.txtNombreAgenteTransporte.MaxLength = 50
      Me.txtNombreAgenteTransporte.Name = "txtNombreAgenteTransporte"
      Me.txtNombreAgenteTransporte.Size = New System.Drawing.Size(351, 20)
      Me.txtNombreAgenteTransporte.TabIndex = 1
      '
      'lblIdAgenteTransporte
      '
      Me.lblIdAgenteTransporte.AutoSize = True
      Me.lblIdAgenteTransporte.Location = New System.Drawing.Point(8, 16)
      Me.lblIdAgenteTransporte.Name = "lblIdAgenteTransporte"
      Me.lblIdAgenteTransporte.Size = New System.Drawing.Size(40, 13)
      Me.lblIdAgenteTransporte.TabIndex = 5
      Me.lblIdAgenteTransporte.Text = "Código"
      '
      'txtIdAgenteTransporte
      '
      Me.txtIdAgenteTransporte.BindearPropiedadControl = "Text"
      Me.txtIdAgenteTransporte.BindearPropiedadEntidad = "IdAgenteTransporte"
      Me.txtIdAgenteTransporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdAgenteTransporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdAgenteTransporte.Formato = ""
      Me.txtIdAgenteTransporte.IsDecimal = False
      Me.txtIdAgenteTransporte.IsNumber = True
      Me.txtIdAgenteTransporte.IsPK = True
      Me.txtIdAgenteTransporte.IsRequired = True
      Me.txtIdAgenteTransporte.Key = ""
      Me.txtIdAgenteTransporte.LabelAsoc = Me.lblIdAgenteTransporte
      Me.txtIdAgenteTransporte.Location = New System.Drawing.Point(53, 12)
      Me.txtIdAgenteTransporte.MaxLength = 5
      Me.txtIdAgenteTransporte.Name = "txtIdAgenteTransporte"
      Me.txtIdAgenteTransporte.Size = New System.Drawing.Size(60, 20)
      Me.txtIdAgenteTransporte.TabIndex = 0
      Me.txtIdAgenteTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      'AduanasAgentesTransporteDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(417, 123)
      Me.Controls.Add(Me.lblCuit)
      Me.Controls.Add(Me.txtCuit)
      Me.Controls.Add(Me.lblNombreAgenteTransporte)
      Me.Controls.Add(Me.txtNombreAgenteTransporte)
      Me.Controls.Add(Me.lblIdAgenteTransporte)
      Me.Controls.Add(Me.txtIdAgenteTransporte)
      Me.Name = "AduanasAgentesTransporteDetalle"
      Me.Text = "Agente de Transporte"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdAgenteTransporte, 0)
      Me.Controls.SetChildIndex(Me.lblIdAgenteTransporte, 0)
      Me.Controls.SetChildIndex(Me.txtNombreAgenteTransporte, 0)
      Me.Controls.SetChildIndex(Me.lblNombreAgenteTransporte, 0)
      Me.Controls.SetChildIndex(Me.txtCuit, 0)
      Me.Controls.SetChildIndex(Me.lblCuit, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreAgenteTransporte As Eniac.Controles.Label
   Friend WithEvents txtNombreAgenteTransporte As Eniac.Controles.TextBox
   Friend WithEvents lblIdAgenteTransporte As Eniac.Controles.Label
   Friend WithEvents txtIdAgenteTransporte As Eniac.Controles.TextBox
   Friend WithEvents lblCuit As Eniac.Controles.Label
   Friend WithEvents txtCuit As Eniac.Controles.TextBox
End Class
