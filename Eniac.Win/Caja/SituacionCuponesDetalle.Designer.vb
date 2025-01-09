<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SituacionCuponesDetalle
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.chbPorDefecto = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(242, 105)
        Me.btnAceptar.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(328, 105)
        Me.btnCancelar.TabIndex = 6
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(141, 105)
        Me.btnCopiar.TabIndex = 8
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(84, 105)
        Me.btnAplicar.TabIndex = 7
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(23, 47)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreSituacionCupon"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(97, 43)
        Me.txtNombre.MaxLength = 100
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(294, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(23, 21)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Código"
        '
        'txtId
        '
        Me.txtId.BindearPropiedadControl = "Text"
        Me.txtId.BindearPropiedadEntidad = "IdSituacionCupon"
        Me.txtId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtId.Formato = ""
        Me.txtId.IsDecimal = False
        Me.txtId.IsNumber = False
        Me.txtId.IsPK = True
        Me.txtId.IsRequired = True
        Me.txtId.Key = ""
        Me.txtId.LabelAsoc = Me.lblId
        Me.txtId.Location = New System.Drawing.Point(97, 17)
        Me.txtId.MaxLength = 3
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(48, 20)
        Me.txtId.TabIndex = 1
        '
        'chbPorDefecto
        '
        Me.chbPorDefecto.AutoSize = True
        Me.chbPorDefecto.BindearPropiedadControl = "Checked"
        Me.chbPorDefecto.BindearPropiedadEntidad = "PorDefecto"
        Me.chbPorDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorDefecto.IsPK = False
        Me.chbPorDefecto.IsRequired = False
        Me.chbPorDefecto.Key = Nothing
        Me.chbPorDefecto.LabelAsoc = Nothing
        Me.chbPorDefecto.Location = New System.Drawing.Point(97, 69)
        Me.chbPorDefecto.Name = "chbPorDefecto"
        Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
        Me.chbPorDefecto.TabIndex = 4
        Me.chbPorDefecto.Text = "Por Defecto"
        Me.chbPorDefecto.UseVisualStyleBackColor = True
        '
        'SituacionCuponesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 140)
        Me.Controls.Add(Me.chbPorDefecto)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Name = "SituacionCuponesDetalle"
        Me.Text = "Situación de Cupones"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtId, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents lblId As Controles.Label
   Friend WithEvents txtId As Controles.TextBox
   Friend WithEvents chbPorDefecto As Controles.CheckBox
End Class
