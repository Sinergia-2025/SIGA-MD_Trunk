<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AduanasDestinacionesDetalle
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
      Me.lblNombreDestinacion = New Eniac.Controles.Label()
      Me.txtNombreDestinacion = New Eniac.Controles.TextBox()
      Me.lblIdDestinacion = New Eniac.Controles.Label()
      Me.txtIdDestinacion = New Eniac.Controles.TextBox()
      Me.lblRegimenArancelario = New Eniac.Controles.Label()
      Me.txtRegimenArancelario = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(330, 93)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(416, 93)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(201, 221)
      '
      'lblNombreDestinacion
      '
      Me.lblNombreDestinacion.AutoSize = True
      Me.lblNombreDestinacion.Location = New System.Drawing.Point(8, 42)
      Me.lblNombreDestinacion.Name = "lblNombreDestinacion"
      Me.lblNombreDestinacion.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreDestinacion.TabIndex = 2
      Me.lblNombreDestinacion.Text = "Nombre"
      '
      'txtNombreDestinacion
      '
      Me.txtNombreDestinacion.BindearPropiedadControl = "Text"
      Me.txtNombreDestinacion.BindearPropiedadEntidad = "NombreDestinacion"
      Me.txtNombreDestinacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreDestinacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreDestinacion.Formato = ""
      Me.txtNombreDestinacion.IsDecimal = False
      Me.txtNombreDestinacion.IsNumber = False
      Me.txtNombreDestinacion.IsPK = False
      Me.txtNombreDestinacion.IsRequired = True
      Me.txtNombreDestinacion.Key = ""
      Me.txtNombreDestinacion.LabelAsoc = Me.lblNombreDestinacion
      Me.txtNombreDestinacion.Location = New System.Drawing.Point(96, 38)
      Me.txtNombreDestinacion.MaxLength = 50
      Me.txtNombreDestinacion.Name = "txtNombreDestinacion"
      Me.txtNombreDestinacion.Size = New System.Drawing.Size(400, 20)
      Me.txtNombreDestinacion.TabIndex = 3
      '
      'lblIdDestinacion
      '
      Me.lblIdDestinacion.AutoSize = True
      Me.lblIdDestinacion.Location = New System.Drawing.Point(8, 16)
      Me.lblIdDestinacion.Name = "lblIdDestinacion"
      Me.lblIdDestinacion.Size = New System.Drawing.Size(40, 13)
      Me.lblIdDestinacion.TabIndex = 0
      Me.lblIdDestinacion.Text = "Código"
      '
      'txtIdDestinacion
      '
      Me.txtIdDestinacion.BindearPropiedadControl = "Text"
      Me.txtIdDestinacion.BindearPropiedadEntidad = "IdDestinacion"
      Me.txtIdDestinacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdDestinacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdDestinacion.Formato = ""
      Me.txtIdDestinacion.IsDecimal = False
      Me.txtIdDestinacion.IsNumber = False
      Me.txtIdDestinacion.IsPK = True
      Me.txtIdDestinacion.IsRequired = True
      Me.txtIdDestinacion.Key = ""
      Me.txtIdDestinacion.LabelAsoc = Me.lblIdDestinacion
      Me.txtIdDestinacion.Location = New System.Drawing.Point(96, 12)
      Me.txtIdDestinacion.MaxLength = 5
      Me.txtIdDestinacion.Name = "txtIdDestinacion"
      Me.txtIdDestinacion.Size = New System.Drawing.Size(60, 20)
      Me.txtIdDestinacion.TabIndex = 1
      Me.txtIdDestinacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegimenArancelario
      '
      Me.lblRegimenArancelario.AutoSize = True
      Me.lblRegimenArancelario.Location = New System.Drawing.Point(8, 69)
      Me.lblRegimenArancelario.Name = "lblRegimenArancelario"
      Me.lblRegimenArancelario.Size = New System.Drawing.Size(86, 13)
      Me.lblRegimenArancelario.TabIndex = 4
      Me.lblRegimenArancelario.Text = "Reg. Arancelario"
      '
      'txtRegimenArancelario
      '
      Me.txtRegimenArancelario.BindearPropiedadControl = "Text"
      Me.txtRegimenArancelario.BindearPropiedadEntidad = "RegimenArancelario"
      Me.txtRegimenArancelario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegimenArancelario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegimenArancelario.Formato = ""
      Me.txtRegimenArancelario.IsDecimal = False
      Me.txtRegimenArancelario.IsNumber = False
      Me.txtRegimenArancelario.IsPK = False
      Me.txtRegimenArancelario.IsRequired = True
      Me.txtRegimenArancelario.Key = ""
      Me.txtRegimenArancelario.LabelAsoc = Me.lblRegimenArancelario
      Me.txtRegimenArancelario.Location = New System.Drawing.Point(96, 65)
      Me.txtRegimenArancelario.MaxLength = 30
      Me.txtRegimenArancelario.Name = "txtRegimenArancelario"
      Me.txtRegimenArancelario.Size = New System.Drawing.Size(150, 20)
      Me.txtRegimenArancelario.TabIndex = 5
      '
      'AduanasDestinacionesDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(508, 135)
      Me.Controls.Add(Me.lblRegimenArancelario)
      Me.Controls.Add(Me.txtRegimenArancelario)
      Me.Controls.Add(Me.lblNombreDestinacion)
      Me.Controls.Add(Me.txtNombreDestinacion)
      Me.Controls.Add(Me.lblIdDestinacion)
      Me.Controls.Add(Me.txtIdDestinacion)
      Me.Name = "AduanasDestinacionesDetalle"
      Me.Text = "Destinación"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdDestinacion, 0)
      Me.Controls.SetChildIndex(Me.lblIdDestinacion, 0)
      Me.Controls.SetChildIndex(Me.txtNombreDestinacion, 0)
      Me.Controls.SetChildIndex(Me.lblNombreDestinacion, 0)
      Me.Controls.SetChildIndex(Me.txtRegimenArancelario, 0)
      Me.Controls.SetChildIndex(Me.lblRegimenArancelario, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreDestinacion As Eniac.Controles.Label
   Friend WithEvents txtNombreDestinacion As Eniac.Controles.TextBox
   Friend WithEvents lblIdDestinacion As Eniac.Controles.Label
   Friend WithEvents txtIdDestinacion As Eniac.Controles.TextBox
   Friend WithEvents lblRegimenArancelario As Eniac.Controles.Label
   Friend WithEvents txtRegimenArancelario As Eniac.Controles.TextBox
End Class
