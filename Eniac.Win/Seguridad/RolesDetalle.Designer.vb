<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RolesDetalle
    Inherits Win.BaseDetalle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RolesDetalle))
      Me.lblDescripcion = New Eniac.Controles.Label
      Me.txtDescripcion = New Eniac.Controles.TextBox
      Me.lblNombre = New Eniac.Controles.Label
      Me.txtNombre = New Eniac.Controles.TextBox
      Me.lblId = New Eniac.Controles.Label
      Me.txtId = New Eniac.Controles.TextBox
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(189, 114)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(275, 114)
      Me.btnCancelar.TabIndex = 4
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.Location = New System.Drawing.Point(14, 80)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 7
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = False
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
      Me.txtDescripcion.Location = New System.Drawing.Point(79, 73)
      Me.txtDescripcion.MaxLength = 150
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(274, 20)
      Me.txtDescripcion.TabIndex = 2
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(14, 54)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 6
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "Nombre"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(79, 47)
      Me.txtNombre.MaxLength = 50
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(210, 20)
      Me.txtNombre.TabIndex = 1
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(14, 28)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(16, 13)
      Me.lblId.TabIndex = 5
      Me.lblId.Text = "Id"
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "Id"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = False
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(79, 21)
      Me.txtId.MaxLength = 12
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(118, 20)
      Me.txtId.TabIndex = 0
      '
      'RolesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(364, 149)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtId)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "RolesDetalle"
      Me.Text = "Rol"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
    Friend WithEvents lblNombre As Eniac.Controles.Label
    Friend WithEvents txtNombre As Eniac.Controles.TextBox
    Friend WithEvents lblId As Eniac.Controles.Label
    Friend WithEvents txtId As Eniac.Controles.TextBox
End Class
