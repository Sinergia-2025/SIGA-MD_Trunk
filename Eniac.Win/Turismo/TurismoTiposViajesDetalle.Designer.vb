<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TurismoTiposViajesDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.cmbIntereses = New Eniac.Controles.ComboBox()
      Me.lblIntereses = New Eniac.Controles.Label()
        Me.txtCantidadDiasUltimaCuota = New Eniac.Controles.TextBox()
        Me.lblCantidadDiasUltimaCuota = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(218, 117)
        Me.btnAceptar.TabIndex = 8
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(304, 117)
        Me.btnCancelar.TabIndex = 9
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(117, 117)
        Me.btnCopiar.TabIndex = 11
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(60, 117)
        Me.btnAplicar.TabIndex = 10
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "DescripcionTipoViaje"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(137, 38)
        Me.txtNombre.MaxLength = 30
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(247, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(10, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = "Text"
        Me.txtCodigo.BindearPropiedadEntidad = "IdTipoViaje"
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = True
        Me.txtCodigo.IsPK = True
        Me.txtCodigo.IsRequired = True
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(137, 12)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(61, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Text = "0"
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(10, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'cmbIntereses
        '
        Me.cmbIntereses.BindearPropiedadControl = "SelectedValue"
        Me.cmbIntereses.BindearPropiedadEntidad = "IdInteres"
        Me.cmbIntereses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIntereses.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIntereses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIntereses.FormattingEnabled = True
        Me.cmbIntereses.IsPK = False
        Me.cmbIntereses.IsRequired = True
        Me.cmbIntereses.Key = Nothing
        Me.cmbIntereses.LabelAsoc = Me.lblIntereses
        Me.cmbIntereses.Location = New System.Drawing.Point(137, 90)
        Me.cmbIntereses.Name = "cmbIntereses"
        Me.cmbIntereses.Size = New System.Drawing.Size(247, 21)
        Me.cmbIntereses.TabIndex = 7
        '
        'lblIntereses
        '
        Me.lblIntereses.AutoSize = True
        Me.lblIntereses.LabelAsoc = Nothing
        Me.lblIntereses.Location = New System.Drawing.Point(10, 93)
        Me.lblIntereses.Name = "lblIntereses"
        Me.lblIntereses.Size = New System.Drawing.Size(50, 13)
        Me.lblIntereses.TabIndex = 6
        Me.lblIntereses.Text = "Intereses"
        '
        'txtCantidadDiasUltimaCuota
        '
        Me.txtCantidadDiasUltimaCuota.BindearPropiedadControl = "Text"
        Me.txtCantidadDiasUltimaCuota.BindearPropiedadEntidad = "CantidadDiasUltimaCuota"
        Me.txtCantidadDiasUltimaCuota.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadDiasUltimaCuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadDiasUltimaCuota.Formato = ""
        Me.txtCantidadDiasUltimaCuota.IsDecimal = False
        Me.txtCantidadDiasUltimaCuota.IsNumber = True
        Me.txtCantidadDiasUltimaCuota.IsPK = False
        Me.txtCantidadDiasUltimaCuota.IsRequired = True
        Me.txtCantidadDiasUltimaCuota.Key = ""
        Me.txtCantidadDiasUltimaCuota.LabelAsoc = Me.lblCantidadDiasUltimaCuota
        Me.txtCantidadDiasUltimaCuota.Location = New System.Drawing.Point(137, 64)
        Me.txtCantidadDiasUltimaCuota.Name = "txtCantidadDiasUltimaCuota"
        Me.txtCantidadDiasUltimaCuota.Size = New System.Drawing.Size(61, 20)
        Me.txtCantidadDiasUltimaCuota.TabIndex = 5
        Me.txtCantidadDiasUltimaCuota.Text = "0"
        Me.txtCantidadDiasUltimaCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadDiasUltimaCuota
        '
        Me.lblCantidadDiasUltimaCuota.AutoSize = True
        Me.lblCantidadDiasUltimaCuota.LabelAsoc = Nothing
        Me.lblCantidadDiasUltimaCuota.Location = New System.Drawing.Point(10, 68)
        Me.lblCantidadDiasUltimaCuota.Name = "lblCantidadDiasUltimaCuota"
        Me.lblCantidadDiasUltimaCuota.Size = New System.Drawing.Size(121, 13)
        Me.lblCantidadDiasUltimaCuota.TabIndex = 4
        Me.lblCantidadDiasUltimaCuota.Text = "Cant. Días Última Cuota"
        '
        'TurismoTiposViajesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 154)
        Me.Controls.Add(Me.txtCantidadDiasUltimaCuota)
        Me.Controls.Add(Me.lblCantidadDiasUltimaCuota)
        Me.Controls.Add(Me.cmbIntereses)
        Me.Controls.Add(Me.lblIntereses)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblCodigo)
        Me.Name = "TurismoTiposViajesDetalle"
        Me.Text = "Tipo de Viaje"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblIntereses, 0)
        Me.Controls.SetChildIndex(Me.cmbIntereses, 0)
        Me.Controls.SetChildIndex(Me.lblCantidadDiasUltimaCuota, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadDiasUltimaCuota, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtCodigo As Controles.TextBox
   Friend WithEvents lblCodigo As Controles.Label
   Friend WithEvents cmbIntereses As Controles.ComboBox
   Friend WithEvents lblIntereses As Controles.Label
    Friend WithEvents txtCantidadDiasUltimaCuota As Controles.TextBox
    Friend WithEvents lblCantidadDiasUltimaCuota As Controles.Label
End Class
