<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConcesionariosAdicionalesDetalle
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
      Me.lblIdAdicional = New Eniac.Controles.Label()
      Me.lblNombreAdicional = New Eniac.Controles.Label()
      Me.lblDescripcionAdicional = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.chkSolicitaDetalle = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(255, 120)
        Me.btnAceptar.TabIndex = 7
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(341, 120)
        Me.btnCancelar.TabIndex = 8
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(154, 120)
        Me.btnCopiar.TabIndex = 10
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(97, 120)
        Me.btnAplicar.TabIndex = 9
        '
        'lblIdAdicional
        '
        Me.lblIdAdicional.AutoSize = True
        Me.lblIdAdicional.LabelAsoc = Nothing
        Me.lblIdAdicional.Location = New System.Drawing.Point(38, 18)
        Me.lblIdAdicional.Name = "lblIdAdicional"
        Me.lblIdAdicional.Size = New System.Drawing.Size(40, 13)
        Me.lblIdAdicional.TabIndex = 0
        Me.lblIdAdicional.Text = "Código"
        '
        'lblNombreAdicional
        '
        Me.lblNombreAdicional.AutoSize = True
        Me.lblNombreAdicional.LabelAsoc = Nothing
        Me.lblNombreAdicional.Location = New System.Drawing.Point(38, 43)
        Me.lblNombreAdicional.Name = "lblNombreAdicional"
        Me.lblNombreAdicional.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreAdicional.TabIndex = 2
        Me.lblNombreAdicional.Text = "Nombre"
        '
        'lblDescripcionAdicional
        '
        Me.lblDescripcionAdicional.AutoSize = True
        Me.lblDescripcionAdicional.LabelAsoc = Nothing
        Me.lblDescripcionAdicional.Location = New System.Drawing.Point(38, 69)
        Me.lblDescripcionAdicional.Name = "lblDescripcionAdicional"
        Me.lblDescripcionAdicional.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcionAdicional.TabIndex = 4
        Me.lblDescripcionAdicional.Text = "Descripción"
        '
        'txtId
        '
        Me.txtId.BindearPropiedadControl = "Text"
        Me.txtId.BindearPropiedadEntidad = "IdAdicional"
        Me.txtId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtId.Formato = ""
        Me.txtId.IsDecimal = False
        Me.txtId.IsNumber = True
        Me.txtId.IsPK = True
        Me.txtId.IsRequired = True
        Me.txtId.Key = ""
        Me.txtId.LabelAsoc = Me.lblIdAdicional
        Me.txtId.Location = New System.Drawing.Point(106, 16)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(45, 20)
        Me.txtId.TabIndex = 1
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "DescripcionAdicional"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = ""
        Me.txtDescripcion.LabelAsoc = Me.lblDescripcionAdicional
        Me.txtDescripcion.Location = New System.Drawing.Point(106, 66)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(315, 20)
        Me.txtDescripcion.TabIndex = 5
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreAdicional"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombreAdicional
        Me.txtNombre.Location = New System.Drawing.Point(106, 40)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(315, 20)
        Me.txtNombre.TabIndex = 3
        '
        'chkSolicitaDetalle
        '
        Me.chkSolicitaDetalle.AutoSize = True
        Me.chkSolicitaDetalle.BindearPropiedadControl = "Checked"
        Me.chkSolicitaDetalle.BindearPropiedadEntidad = "SolicitaDetalle"
        Me.chkSolicitaDetalle.ForeColorFocus = System.Drawing.Color.Red
        Me.chkSolicitaDetalle.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkSolicitaDetalle.IsPK = False
        Me.chkSolicitaDetalle.IsRequired = True
        Me.chkSolicitaDetalle.Key = Nothing
        Me.chkSolicitaDetalle.LabelAsoc = Nothing
        Me.chkSolicitaDetalle.Location = New System.Drawing.Point(106, 92)
        Me.chkSolicitaDetalle.Name = "chkSolicitaDetalle"
        Me.chkSolicitaDetalle.Size = New System.Drawing.Size(96, 17)
        Me.chkSolicitaDetalle.TabIndex = 6
        Me.chkSolicitaDetalle.Text = "Solicita Detalle"
        Me.chkSolicitaDetalle.UseVisualStyleBackColor = True
        '
        'ConcesionariosAdicionalesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 162)
        Me.Controls.Add(Me.chkSolicitaDetalle)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.lblDescripcionAdicional)
        Me.Controls.Add(Me.lblNombreAdicional)
        Me.Controls.Add(Me.lblIdAdicional)
        Me.Name = "ConcesionariosAdicionalesDetalle"
        Me.Text = "Adicional"
        Me.Controls.SetChildIndex(Me.lblIdAdicional, 0)
        Me.Controls.SetChildIndex(Me.lblNombreAdicional, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcionAdicional, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.txtId, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.chkSolicitaDetalle, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIdAdicional As Eniac.Controles.Label
   Friend WithEvents lblNombreAdicional As Eniac.Controles.Label
   Friend WithEvents lblDescripcionAdicional As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents chkSolicitaDetalle As Eniac.Controles.CheckBox
End Class
