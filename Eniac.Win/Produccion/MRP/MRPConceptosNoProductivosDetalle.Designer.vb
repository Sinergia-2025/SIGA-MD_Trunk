<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPConceptosNoProductivosDetalle
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
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.txtCodigoConceptoNoProductivo = New Eniac.Controles.TextBox()
      Me.lblCodigoConceptoNoProductivo = New Eniac.Controles.Label()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(324, 72)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(410, 72)
      Me.btnCancelar.TabIndex = 6
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(223, 72)
      Me.btnCopiar.TabIndex = 8
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(166, 72)
      Me.btnAplicar.TabIndex = 7
      '
      'chbActivo
      '
      Me.chbActivo.AutoSize = True
      Me.chbActivo.BindearPropiedadControl = "Checked"
      Me.chbActivo.BindearPropiedadEntidad = "Activo"
      Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActivo.IsPK = False
      Me.chbActivo.IsRequired = False
      Me.chbActivo.Key = Nothing
      Me.chbActivo.LabelAsoc = Nothing
      Me.chbActivo.Location = New System.Drawing.Point(421, 14)
      Me.chbActivo.Name = "chbActivo"
      Me.chbActivo.Size = New System.Drawing.Size(56, 17)
      Me.chbActivo.TabIndex = 4
      Me.chbActivo.Text = "Activa"
      Me.chbActivo.UseVisualStyleBackColor = True
      '
      'txtCodigoConceptoNoProductivo
      '
      Me.txtCodigoConceptoNoProductivo.BindearPropiedadControl = "Text"
      Me.txtCodigoConceptoNoProductivo.BindearPropiedadEntidad = "CodigoConceptoNoProductivo"
      Me.txtCodigoConceptoNoProductivo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigoConceptoNoProductivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigoConceptoNoProductivo.Formato = ""
      Me.txtCodigoConceptoNoProductivo.IsDecimal = False
      Me.txtCodigoConceptoNoProductivo.IsNumber = False
      Me.txtCodigoConceptoNoProductivo.IsPK = True
      Me.txtCodigoConceptoNoProductivo.IsRequired = True
      Me.txtCodigoConceptoNoProductivo.Key = ""
      Me.txtCodigoConceptoNoProductivo.LabelAsoc = Me.lblCodigoConceptoNoProductivo
      Me.txtCodigoConceptoNoProductivo.Location = New System.Drawing.Point(101, 12)
      Me.txtCodigoConceptoNoProductivo.MaxLength = 30
      Me.txtCodigoConceptoNoProductivo.Name = "txtCodigoConceptoNoProductivo"
      Me.txtCodigoConceptoNoProductivo.Size = New System.Drawing.Size(102, 20)
      Me.txtCodigoConceptoNoProductivo.TabIndex = 1
      '
      'lblCodigoConceptoNoProductivo
      '
      Me.lblCodigoConceptoNoProductivo.AutoSize = True
      Me.lblCodigoConceptoNoProductivo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCodigoConceptoNoProductivo.LabelAsoc = Nothing
      Me.lblCodigoConceptoNoProductivo.Location = New System.Drawing.Point(14, 15)
      Me.lblCodigoConceptoNoProductivo.Name = "lblCodigoConceptoNoProductivo"
      Me.lblCodigoConceptoNoProductivo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoConceptoNoProductivo.TabIndex = 0
      Me.lblCodigoConceptoNoProductivo.Text = "Código"
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(14, 41)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "NombreConceptoNoProductivo"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = "NombreEmpleado"
      Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
      Me.txtDescripcion.Location = New System.Drawing.Point(101, 38)
      Me.txtDescripcion.MaxLength = 50
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(376, 20)
      Me.txtDescripcion.TabIndex = 3
      '
      'MRPConceptosNoProductivosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(499, 107)
      Me.Controls.Add(Me.chbActivo)
      Me.Controls.Add(Me.txtCodigoConceptoNoProductivo)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.lblCodigoConceptoNoProductivo)
      Me.Name = "MRPConceptosNoProductivosDetalle"
      Me.Text = "Concepto no Productivo"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigoConceptoNoProductivo, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.txtCodigoConceptoNoProductivo, 0)
      Me.Controls.SetChildIndex(Me.chbActivo, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents chbActivo As Controles.CheckBox
   Friend WithEvents txtCodigoConceptoNoProductivo As Controles.TextBox
   Friend WithEvents lblCodigoConceptoNoProductivo As Controles.Label
   Friend WithEvents lblDescripcion As Controles.Label
   Friend WithEvents txtDescripcion As Controles.TextBox
End Class
