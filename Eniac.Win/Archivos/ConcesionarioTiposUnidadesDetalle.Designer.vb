<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConcesionarioTiposUnidadesDetalle
   Inherits Win.BaseDetalle

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
        Me.txtNombre = New Eniac.Controles.TextBox()
        Me.lblId = New Eniac.Controles.Label()
        Me.txtId = New Eniac.Controles.TextBox()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtDescripcion = New Eniac.Controles.TextBox()
        Me.chbAutoincremental = New Eniac.Controles.CheckBox()
        Me.CheckBox1 = New Eniac.Controles.CheckBox()
        Me.CheckBox2 = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(273, 143)
        Me.btnAceptar.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(359, 143)
        Me.btnCancelar.TabIndex = 7
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(172, 143)
        Me.btnCopiar.TabIndex = 8
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(115, 143)
        Me.btnAplicar.TabIndex = 9
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(25, 46)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreTipoUnidad"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(99, 42)
        Me.txtNombre.MaxLength = 100
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(329, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(25, 20)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Código"
        '
        'txtId
        '
        Me.txtId.BindearPropiedadControl = "Text"
        Me.txtId.BindearPropiedadEntidad = "IdTipoUnidad"
        Me.txtId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtId.Formato = ""
        Me.txtId.IsDecimal = False
        Me.txtId.IsNumber = True
        Me.txtId.IsPK = True
        Me.txtId.IsRequired = True
        Me.txtId.Key = ""
        Me.txtId.LabelAsoc = Me.lblId
        Me.txtId.Location = New System.Drawing.Point(99, 16)
        Me.txtId.MaxLength = 3
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(48, 20)
        Me.txtId.TabIndex = 1
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(25, 72)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 4
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "DescripcionTipoUnidad"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = False
        Me.txtDescripcion.Key = ""
        Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
        Me.txtDescripcion.Location = New System.Drawing.Point(99, 68)
        Me.txtDescripcion.MaxLength = 100
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(329, 20)
        Me.txtDescripcion.TabIndex = 5
        '
        'chbAutoincremental
        '
        Me.chbAutoincremental.AutoSize = True
        Me.chbAutoincremental.BindearPropiedadControl = "Checked"
        Me.chbAutoincremental.BindearPropiedadEntidad = "SolicitaDistribucionEje"
        Me.chbAutoincremental.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAutoincremental.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAutoincremental.IsPK = False
        Me.chbAutoincremental.IsRequired = False
        Me.chbAutoincremental.Key = Nothing
        Me.chbAutoincremental.LabelAsoc = Nothing
        Me.chbAutoincremental.Location = New System.Drawing.Point(277, 104)
        Me.chbAutoincremental.Name = "chbAutoincremental"
        Me.chbAutoincremental.Size = New System.Drawing.Size(151, 17)
        Me.chbAutoincremental.TabIndex = 10
        Me.chbAutoincremental.Text = "Solicita Distribucion de Eje"
        Me.chbAutoincremental.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BindearPropiedadControl = "Checked"
        Me.CheckBox1.BindearPropiedadEntidad = "MuestraEnCeroKM"
        Me.CheckBox1.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox1.IsPK = False
        Me.CheckBox1.IsRequired = False
        Me.CheckBox1.Key = Nothing
        Me.CheckBox1.LabelAsoc = Nothing
        Me.CheckBox1.Location = New System.Drawing.Point(25, 104)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(122, 17)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Muestra en Cero Km"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BindearPropiedadControl = "Checked"
        Me.CheckBox2.BindearPropiedadEntidad = "MuestraEnUsado"
        Me.CheckBox2.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox2.IsPK = False
        Me.CheckBox2.IsRequired = False
        Me.CheckBox2.Key = Nothing
        Me.CheckBox2.LabelAsoc = Nothing
        Me.CheckBox2.Location = New System.Drawing.Point(153, 104)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(118, 17)
        Me.CheckBox2.TabIndex = 12
        Me.CheckBox2.Text = "Muestra en Usados"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'ConcesionarioTiposUnidadesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 178)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.chbAutoincremental)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Name = "ConcesionarioTiposUnidadesDetalle"
        Me.Text = "Unidad"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtId, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.chbAutoincremental, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox2, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombre As Controles.Label
    Friend WithEvents txtNombre As Controles.TextBox
    Friend WithEvents lblId As Controles.Label
    Friend WithEvents txtId As Controles.TextBox
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtDescripcion As Controles.TextBox
    Friend WithEvents chbAutoincremental As Controles.CheckBox
    Friend WithEvents CheckBox1 As Controles.CheckBox
    Friend WithEvents CheckBox2 As Controles.CheckBox
End Class
