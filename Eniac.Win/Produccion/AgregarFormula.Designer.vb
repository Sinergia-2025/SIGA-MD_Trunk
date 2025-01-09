<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarFormula
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
      Me.btnAgregar = New Eniac.Controles.Button()
      Me.txtIdProducto = New Eniac.Controles.TextBox()
        Me.chbCopiarFormula = New Eniac.Controles.CheckBox()
        Me.cmbCopiarFormulas = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(16, 76)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(84, 13)
        Me.lblNombre.TabIndex = 5
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
        Me.txtNombreFormula.TabIndex = 6
        '
        'lblCodigoFormula
        '
        Me.lblCodigoFormula.AutoSize = True
        Me.lblCodigoFormula.LabelAsoc = Nothing
        Me.lblCodigoFormula.Location = New System.Drawing.Point(16, 48)
        Me.lblCodigoFormula.Name = "lblCodigoFormula"
        Me.lblCodigoFormula.Size = New System.Drawing.Size(80, 13)
        Me.lblCodigoFormula.TabIndex = 3
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
        Me.txtIdFormula.Size = New System.Drawing.Size(60, 20)
        Me.txtIdFormula.TabIndex = 4
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
        Me.txtNombreProducto.TabIndex = 2
        Me.txtNombreProducto.TabStop = False
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(16, 21)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Producto"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_a_16
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(515, 96)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(429, 96)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 30)
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.UseVisualStyleBackColor = True
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
        Me.txtIdProducto.TabIndex = 1
        Me.txtIdProducto.TabStop = False
        '
        'chbCopiarFormula
        '
        Me.chbCopiarFormula.AutoSize = True
        Me.chbCopiarFormula.BindearPropiedadControl = ""
        Me.chbCopiarFormula.BindearPropiedadEntidad = ""
        Me.chbCopiarFormula.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCopiarFormula.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCopiarFormula.IsPK = False
        Me.chbCopiarFormula.IsRequired = False
        Me.chbCopiarFormula.Key = Nothing
        Me.chbCopiarFormula.LabelAsoc = Nothing
        Me.chbCopiarFormula.Location = New System.Drawing.Point(19, 103)
        Me.chbCopiarFormula.Name = "chbCopiarFormula"
        Me.chbCopiarFormula.Size = New System.Drawing.Size(93, 17)
        Me.chbCopiarFormula.TabIndex = 7
        Me.chbCopiarFormula.Text = "Copiar fórmula"
        Me.chbCopiarFormula.UseVisualStyleBackColor = True
        '
        'cmbCopiarFormulas
        '
        Me.cmbCopiarFormulas.BindearPropiedadControl = Nothing
        Me.cmbCopiarFormulas.BindearPropiedadEntidad = Nothing
        Me.cmbCopiarFormulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCopiarFormulas.Enabled = False
        Me.cmbCopiarFormulas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCopiarFormulas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCopiarFormulas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCopiarFormulas.FormattingEnabled = True
        Me.cmbCopiarFormulas.IsPK = False
        Me.cmbCopiarFormulas.IsRequired = False
        Me.cmbCopiarFormulas.Key = Nothing
        Me.cmbCopiarFormulas.LabelAsoc = Me.chbCopiarFormula
        Me.cmbCopiarFormulas.Location = New System.Drawing.Point(116, 101)
        Me.cmbCopiarFormulas.Name = "cmbCopiarFormulas"
        Me.cmbCopiarFormulas.Size = New System.Drawing.Size(248, 21)
        Me.cmbCopiarFormulas.TabIndex = 8
        Me.cmbCopiarFormulas.TabStop = False
        '
        'AgregarFormula
        '
        Me.AcceptButton = Me.btnAgregar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 138)
        Me.Controls.Add(Me.chbCopiarFormula)
        Me.Controls.Add(Me.cmbCopiarFormulas)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.txtIdProducto)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtNombreProducto)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombreFormula)
        Me.Controls.Add(Me.lblCodigoFormula)
        Me.Controls.Add(Me.txtIdFormula)
        Me.Name = "AgregarFormula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Fórmula"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreFormula As Eniac.Controles.TextBox
   Friend WithEvents lblCodigoFormula As Eniac.Controles.Label
   Friend WithEvents txtIdFormula As Eniac.Controles.TextBox
   Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents btnAgregar As Eniac.Controles.Button
   Friend WithEvents txtIdProducto As Eniac.Controles.TextBox
   Friend WithEvents lblProducto As Eniac.Controles.Label
    Friend WithEvents chbCopiarFormula As Controles.CheckBox
    Friend WithEvents cmbCopiarFormulas As Controles.ComboBox
End Class
