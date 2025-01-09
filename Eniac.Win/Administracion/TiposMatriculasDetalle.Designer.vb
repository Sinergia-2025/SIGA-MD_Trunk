<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposMatriculasDetalle
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
      Me.lblNombreTipoMatricula = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblIdTipoMatricula = New Eniac.Controles.Label()
      Me.txtIdTipoMatricula = New Eniac.Controles.TextBox()
      Me.chbTieneNumeros = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(230, 107)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(323, 107)
      Me.btnCancelar.TabIndex = 6
      '
      'lblNombreTipoMatricula
      '
      Me.lblNombreTipoMatricula.AutoSize = True
      Me.lblNombreTipoMatricula.Location = New System.Drawing.Point(27, 46)
      Me.lblNombreTipoMatricula.Name = "lblNombreTipoMatricula"
      Me.lblNombreTipoMatricula.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreTipoMatricula.TabIndex = 3
      Me.lblNombreTipoMatricula.Text = "Descripción"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "NombreTipoMatricula"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblNombreTipoMatricula
      Me.txtDescripcion.Location = New System.Drawing.Point(110, 42)
      Me.txtDescripcion.MaxLength = 5
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(60, 20)
      Me.txtDescripcion.TabIndex = 2
      '
      'lblIdTipoMatricula
      '
      Me.lblIdTipoMatricula.AutoSize = True
      Me.lblIdTipoMatricula.Location = New System.Drawing.Point(27, 18)
      Me.lblIdTipoMatricula.Name = "lblIdTipoMatricula"
      Me.lblIdTipoMatricula.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoMatricula.TabIndex = 1
      Me.lblIdTipoMatricula.Text = "Codigo"
      '
      'txtIdTipoMatricula
      '
      Me.txtIdTipoMatricula.BindearPropiedadControl = "Text"
      Me.txtIdTipoMatricula.BindearPropiedadEntidad = "IdTipoMatricula"
      Me.txtIdTipoMatricula.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoMatricula.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoMatricula.Formato = ""
      Me.txtIdTipoMatricula.IsDecimal = False
      Me.txtIdTipoMatricula.IsNumber = True
      Me.txtIdTipoMatricula.IsPK = True
      Me.txtIdTipoMatricula.IsRequired = True
      Me.txtIdTipoMatricula.Key = ""
      Me.txtIdTipoMatricula.LabelAsoc = Me.lblIdTipoMatricula
      Me.txtIdTipoMatricula.Location = New System.Drawing.Point(110, 14)
      Me.txtIdTipoMatricula.MaxLength = 2
      Me.txtIdTipoMatricula.Name = "txtIdTipoMatricula"
      Me.txtIdTipoMatricula.Size = New System.Drawing.Size(30, 20)
      Me.txtIdTipoMatricula.TabIndex = 0
      '
      'chbTieneNumeros
      '
      Me.chbTieneNumeros.AutoSize = True
      Me.chbTieneNumeros.BindearPropiedadControl = "Checked"
      Me.chbTieneNumeros.BindearPropiedadEntidad = "TieneNumeros"
      Me.chbTieneNumeros.Checked = True
      Me.chbTieneNumeros.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbTieneNumeros.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTieneNumeros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTieneNumeros.IsPK = False
      Me.chbTieneNumeros.IsRequired = False
      Me.chbTieneNumeros.Key = Nothing
      Me.chbTieneNumeros.LabelAsoc = Nothing
      Me.chbTieneNumeros.Location = New System.Drawing.Point(27, 73)
      Me.chbTieneNumeros.Name = "chbTieneNumeros"
      Me.chbTieneNumeros.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbTieneNumeros.Size = New System.Drawing.Size(98, 17)
      Me.chbTieneNumeros.TabIndex = 4
      Me.chbTieneNumeros.Text = "Tiene Numeros"
      Me.chbTieneNumeros.UseVisualStyleBackColor = True
      '
      'TiposMatriculasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(415, 143)
      Me.Controls.Add(Me.chbTieneNumeros)
      Me.Controls.Add(Me.lblNombreTipoMatricula)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.lblIdTipoMatricula)
      Me.Controls.Add(Me.txtIdTipoMatricula)
      Me.Name = "TiposMatriculasDetalle"
      Me.Text = "Tipo de Matricula"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoMatricula, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoMatricula, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoMatricula, 0)
      Me.Controls.SetChildIndex(Me.chbTieneNumeros, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoMatricula As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoMatricula As Eniac.Controles.Label
   Friend WithEvents txtIdTipoMatricula As Eniac.Controles.TextBox
   Friend WithEvents chbTieneNumeros As Eniac.Controles.CheckBox
End Class
