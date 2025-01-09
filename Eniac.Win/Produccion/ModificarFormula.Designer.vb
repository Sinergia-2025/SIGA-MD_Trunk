<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarFormula
   Inherits BaseForm

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
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombreFormula = New Eniac.Controles.TextBox()
      Me.lblCodigoFormula = New Eniac.Controles.Label()
      Me.txtIdFormula = New Eniac.Controles.TextBox()
      Me.txtNombreProducto = New Eniac.Controles.TextBox()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.btnModificar = New Eniac.Controles.Button()
      Me.txtIdProducto = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(16, 76)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(84, 13)
      Me.lblNombre.TabIndex = 0
      Me.lblNombre.Text = "Nombre Fórmula"
      '
      'txtNombreFormula
      '
      Me.txtNombreFormula.BindearPropiedadControl = "Text"
      Me.txtNombreFormula.BindearPropiedadEntidad = "NombreActividad"
      Me.txtNombreFormula.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreFormula.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreFormula.Formato = ""
      Me.txtNombreFormula.IsDecimal = False
      Me.txtNombreFormula.IsNumber = False
      Me.txtNombreFormula.IsPK = False
      Me.txtNombreFormula.IsRequired = True
      Me.txtNombreFormula.Key = ""
      Me.txtNombreFormula.LabelAsoc = Me.lblNombre
      Me.txtNombreFormula.Location = New System.Drawing.Point(116, 73)
      Me.txtNombreFormula.MaxLength = 30
      Me.txtNombreFormula.Name = "txtNombreFormula"
      Me.txtNombreFormula.Size = New System.Drawing.Size(250, 20)
      Me.txtNombreFormula.TabIndex = 1
      '
      'lblCodigoFormula
      '
      Me.lblCodigoFormula.AutoSize = True
      Me.lblCodigoFormula.Location = New System.Drawing.Point(16, 48)
      Me.lblCodigoFormula.Name = "lblCodigoFormula"
      Me.lblCodigoFormula.Size = New System.Drawing.Size(80, 13)
      Me.lblCodigoFormula.TabIndex = 4
      Me.lblCodigoFormula.Text = "Código Fórmula"
      '
      'txtIdFormula
      '
      Me.txtIdFormula.BindearPropiedadControl = "Text"
      Me.txtIdFormula.BindearPropiedadEntidad = "IdActividad"
      Me.txtIdFormula.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdFormula.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdFormula.Formato = ""
      Me.txtIdFormula.IsDecimal = False
      Me.txtIdFormula.IsNumber = True
      Me.txtIdFormula.IsPK = True
      Me.txtIdFormula.IsRequired = True
      Me.txtIdFormula.Key = ""
      Me.txtIdFormula.LabelAsoc = Me.lblCodigoFormula
      Me.txtIdFormula.Location = New System.Drawing.Point(116, 45)
      Me.txtIdFormula.MaxLength = 5
      Me.txtIdFormula.Name = "txtIdFormula"
      Me.txtIdFormula.ReadOnly = True
      Me.txtIdFormula.Size = New System.Drawing.Size(60, 20)
      Me.txtIdFormula.TabIndex = 5
      Me.txtIdFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNombreProducto
      '
      Me.txtNombreProducto.BindearPropiedadControl = ""
      Me.txtNombreProducto.BindearPropiedadEntidad = ""
      Me.txtNombreProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreProducto.Formato = ""
      Me.txtNombreProducto.IsDecimal = False
      Me.txtNombreProducto.IsNumber = False
      Me.txtNombreProducto.IsPK = False
      Me.txtNombreProducto.IsRequired = True
      Me.txtNombreProducto.Key = ""
      Me.txtNombreProducto.LabelAsoc = Me.lblProducto
      Me.txtNombreProducto.Location = New System.Drawing.Point(242, 17)
      Me.txtNombreProducto.MaxLength = 100
      Me.txtNombreProducto.Name = "txtNombreProducto"
      Me.txtNombreProducto.ReadOnly = True
      Me.txtNombreProducto.Size = New System.Drawing.Size(353, 20)
      Me.txtNombreProducto.TabIndex = 8
      Me.txtNombreProducto.TabStop = False
      '
      'lblProducto
      '
      Me.lblProducto.AutoSize = True
      Me.lblProducto.Location = New System.Drawing.Point(16, 21)
      Me.lblProducto.Name = "lblProducto"
      Me.lblProducto.Size = New System.Drawing.Size(50, 13)
      Me.lblProducto.TabIndex = 6
      Me.lblProducto.Text = "Producto"
      '
      'btnCancelar
      '
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_a_16
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(515, 104)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 3
      Me.btnCancelar.Text = "Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnModificar
      '
      Me.btnModificar.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnModificar.Location = New System.Drawing.Point(429, 104)
      Me.btnModificar.Name = "btnModificar"
      Me.btnModificar.Size = New System.Drawing.Size(80, 30)
      Me.btnModificar.TabIndex = 2
      Me.btnModificar.Text = "Modificar"
      Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnModificar.UseVisualStyleBackColor = True
      '
      'txtIdProducto
      '
      Me.txtIdProducto.BindearPropiedadControl = ""
      Me.txtIdProducto.BindearPropiedadEntidad = ""
      Me.txtIdProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProducto.Formato = ""
      Me.txtIdProducto.IsDecimal = False
      Me.txtIdProducto.IsNumber = False
      Me.txtIdProducto.IsPK = False
      Me.txtIdProducto.IsRequired = True
      Me.txtIdProducto.Key = ""
      Me.txtIdProducto.LabelAsoc = Me.lblProducto
      Me.txtIdProducto.Location = New System.Drawing.Point(116, 17)
      Me.txtIdProducto.MaxLength = 100
      Me.txtIdProducto.Name = "txtIdProducto"
      Me.txtIdProducto.ReadOnly = True
      Me.txtIdProducto.Size = New System.Drawing.Size(120, 20)
      Me.txtIdProducto.TabIndex = 7
      Me.txtIdProducto.TabStop = False
      '
      'ModificarFormula
      '
      Me.AcceptButton = Me.btnModificar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(607, 146)
      Me.Controls.Add(Me.lblProducto)
      Me.Controls.Add(Me.txtIdProducto)
      Me.Controls.Add(Me.btnModificar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.txtNombreProducto)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombreFormula)
      Me.Controls.Add(Me.lblCodigoFormula)
      Me.Controls.Add(Me.txtIdFormula)
      Me.Name = "ModificarFormula"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Modificar Fórmula"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreFormula As Eniac.Controles.TextBox
   Friend WithEvents lblCodigoFormula As Eniac.Controles.Label
   Friend WithEvents txtIdFormula As Eniac.Controles.TextBox
   Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents btnModificar As Eniac.Controles.Button
   Friend WithEvents txtIdProducto As Eniac.Controles.TextBox
   Friend WithEvents lblProducto As Eniac.Controles.Label
End Class
