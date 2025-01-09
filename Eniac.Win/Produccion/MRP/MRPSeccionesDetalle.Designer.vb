<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPSeccionesDetalle
   Inherits BaseDetalle

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.txtCodigoSeccion = New Eniac.Controles.TextBox()
      Me.lblCodigoSeccion = New Eniac.Controles.Label()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblClaseSeccion = New Eniac.Controles.Label()
      Me.cmbClaseSeccion = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(305, 72)
        Me.btnAceptar.TabIndex = 7
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(391, 72)
        Me.btnCancelar.TabIndex = 8
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(204, 138)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(147, 138)
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
        Me.chbActivo.Location = New System.Drawing.Point(417, 13)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 4
        Me.chbActivo.Text = "Activa"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'txtCodigoSeccion
        '
        Me.txtCodigoSeccion.BindearPropiedadControl = "Text"
        Me.txtCodigoSeccion.BindearPropiedadEntidad = "CodigoSeccion"
        Me.txtCodigoSeccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoSeccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoSeccion.Formato = ""
        Me.txtCodigoSeccion.IsDecimal = False
        Me.txtCodigoSeccion.IsNumber = False
        Me.txtCodigoSeccion.IsPK = True
        Me.txtCodigoSeccion.IsRequired = True
        Me.txtCodigoSeccion.Key = ""
        Me.txtCodigoSeccion.LabelAsoc = Me.lblCodigoSeccion
        Me.txtCodigoSeccion.Location = New System.Drawing.Point(76, 12)
        Me.txtCodigoSeccion.MaxLength = 12
        Me.txtCodigoSeccion.Name = "txtCodigoSeccion"
        Me.txtCodigoSeccion.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigoSeccion.TabIndex = 1
        '
        'lblCodigoSeccion
        '
        Me.lblCodigoSeccion.AutoSize = True
        Me.lblCodigoSeccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoSeccion.LabelAsoc = Nothing
        Me.lblCodigoSeccion.Location = New System.Drawing.Point(7, 15)
        Me.lblCodigoSeccion.Name = "lblCodigoSeccion"
        Me.lblCodigoSeccion.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoSeccion.TabIndex = 0
        Me.lblCodigoSeccion.Text = "Código"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(7, 41)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 5
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = "NombreEmpleado"
        Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
        Me.txtDescripcion.Location = New System.Drawing.Point(76, 38)
        Me.txtDescripcion.MaxLength = 100
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(392, 20)
        Me.txtDescripcion.TabIndex = 6
        '
        'lblClaseSeccion
        '
        Me.lblClaseSeccion.AutoSize = True
        Me.lblClaseSeccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblClaseSeccion.LabelAsoc = Nothing
        Me.lblClaseSeccion.Location = New System.Drawing.Point(172, 15)
        Me.lblClaseSeccion.Name = "lblClaseSeccion"
        Me.lblClaseSeccion.Size = New System.Drawing.Size(33, 13)
        Me.lblClaseSeccion.TabIndex = 2
        Me.lblClaseSeccion.Text = "Clase"
        '
        'cmbClaseSeccion
        '
        Me.cmbClaseSeccion.BindearPropiedadControl = "SelectedValue"
        Me.cmbClaseSeccion.BindearPropiedadEntidad = "ClaseSeccion"
        Me.cmbClaseSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClaseSeccion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbClaseSeccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbClaseSeccion.FormattingEnabled = True
        Me.cmbClaseSeccion.IsPK = False
        Me.cmbClaseSeccion.IsRequired = False
        Me.cmbClaseSeccion.Key = Nothing
        Me.cmbClaseSeccion.LabelAsoc = Me.lblClaseSeccion
        Me.cmbClaseSeccion.Location = New System.Drawing.Point(211, 11)
        Me.cmbClaseSeccion.Name = "cmbClaseSeccion"
        Me.cmbClaseSeccion.Size = New System.Drawing.Size(186, 21)
        Me.cmbClaseSeccion.TabIndex = 3
        '
        'MRPSeccionesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 107)
        Me.Controls.Add(Me.cmbClaseSeccion)
        Me.Controls.Add(Me.lblClaseSeccion)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.txtCodigoSeccion)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblCodigoSeccion)
        Me.Name = "MRPSeccionesDetalle"
        Me.Text = "Secciones"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoSeccion, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoSeccion, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.lblClaseSeccion, 0)
        Me.Controls.SetChildIndex(Me.cmbClaseSeccion, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbActivo As Controles.CheckBox
   Friend WithEvents txtCodigoSeccion As Controles.TextBox
   Friend WithEvents lblCodigoSeccion As Controles.Label
   Friend WithEvents lblDescripcion As Controles.Label
   Friend WithEvents txtDescripcion As Controles.TextBox
   Friend WithEvents lblClaseSeccion As Controles.Label
   Friend WithEvents cmbClaseSeccion As Controles.ComboBox
End Class
