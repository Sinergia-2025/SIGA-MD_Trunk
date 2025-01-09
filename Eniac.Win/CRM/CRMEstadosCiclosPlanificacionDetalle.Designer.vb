<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CRMEstadosCiclosPlanificacionDetalle
   Inherits Eniac.Win.BaseDetalle


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
      Me.lblTipoEstado = New Eniac.Controles.Label()
      Me.lblIdEstado = New Eniac.Controles.Label()
      Me.txtIdEstado = New Eniac.Controles.TextBox()
      Me.lblOrden = New Eniac.Controles.Label()
      Me.txtOrden = New Eniac.Controles.TextBox()
      Me.txtBackColor = New Eniac.Controles.TextBox()
      Me.lblBackColor = New Eniac.Controles.CheckBox()
      Me.btnBackColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.btnForeColor = New System.Windows.Forms.Button()
      Me.lblForeColor = New Eniac.Controles.CheckBox()
      Me.txtForeColor = New Eniac.Controles.TextBox()
      Me.cmbTiposEstados = New Eniac.Controles.ComboBox()
      Me.lblEjemploColor = New Eniac.Controles.Label()
      Me.lblEjemploColorLabel = New Eniac.Controles.Label()
        Me.chbPorDefecto = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(165, 179)
        Me.btnAceptar.TabIndex = 15
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(257, 179)
        Me.btnCancelar.TabIndex = 16
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(64, 179)
        Me.btnCopiar.TabIndex = 18
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(4, 179)
        Me.btnAplicar.TabIndex = 17
        '
        'lblTipoEstado
        '
        Me.lblTipoEstado.AutoSize = True
        Me.lblTipoEstado.LabelAsoc = Nothing
        Me.lblTipoEstado.Location = New System.Drawing.Point(26, 42)
        Me.lblTipoEstado.Name = "lblTipoEstado"
        Me.lblTipoEstado.Size = New System.Drawing.Size(64, 13)
        Me.lblTipoEstado.TabIndex = 2
        Me.lblTipoEstado.Text = "Tipo Estado"
        '
        'lblIdEstado
        '
        Me.lblIdEstado.AutoSize = True
        Me.lblIdEstado.LabelAsoc = Nothing
        Me.lblIdEstado.Location = New System.Drawing.Point(26, 16)
        Me.lblIdEstado.Name = "lblIdEstado"
        Me.lblIdEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblIdEstado.TabIndex = 0
        Me.lblIdEstado.Text = "Estado"
        '
        'txtIdEstado
        '
        Me.txtIdEstado.BindearPropiedadControl = "Text"
        Me.txtIdEstado.BindearPropiedadEntidad = "IdEstadoCicloPlanificacion"
        Me.txtIdEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdEstado.Formato = ""
        Me.txtIdEstado.IsDecimal = False
        Me.txtIdEstado.IsNumber = False
        Me.txtIdEstado.IsPK = True
        Me.txtIdEstado.IsRequired = True
        Me.txtIdEstado.Key = ""
        Me.txtIdEstado.LabelAsoc = Me.lblIdEstado
        Me.txtIdEstado.Location = New System.Drawing.Point(110, 12)
        Me.txtIdEstado.MaxLength = 15
        Me.txtIdEstado.Name = "txtIdEstado"
        Me.txtIdEstado.Size = New System.Drawing.Size(139, 20)
        Me.txtIdEstado.TabIndex = 1
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.LabelAsoc = Nothing
        Me.lblOrden.Location = New System.Drawing.Point(26, 69)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 4
        Me.lblOrden.Text = "Orden"
        '
        'txtOrden
        '
        Me.txtOrden.BindearPropiedadControl = "Text"
        Me.txtOrden.BindearPropiedadEntidad = "Orden"
        Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrden.Formato = ""
        Me.txtOrden.IsDecimal = False
        Me.txtOrden.IsNumber = True
        Me.txtOrden.IsPK = False
        Me.txtOrden.IsRequired = True
        Me.txtOrden.Key = ""
        Me.txtOrden.LabelAsoc = Me.lblOrden
        Me.txtOrden.Location = New System.Drawing.Point(110, 65)
        Me.txtOrden.MaxLength = 2
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(29, 20)
        Me.txtOrden.TabIndex = 5
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBackColor
        '
        Me.txtBackColor.BindearPropiedadControl = ""
        Me.txtBackColor.BindearPropiedadEntidad = ""
        Me.txtBackColor.Enabled = False
        Me.txtBackColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBackColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBackColor.Formato = ""
        Me.txtBackColor.IsDecimal = False
        Me.txtBackColor.IsNumber = False
        Me.txtBackColor.IsPK = False
        Me.txtBackColor.IsRequired = False
        Me.txtBackColor.Key = ""
        Me.txtBackColor.LabelAsoc = Me.lblBackColor
        Me.txtBackColor.Location = New System.Drawing.Point(110, 91)
        Me.txtBackColor.Name = "txtBackColor"
        Me.txtBackColor.ReadOnly = True
        Me.txtBackColor.Size = New System.Drawing.Size(82, 20)
        Me.txtBackColor.TabIndex = 8
        '
        'lblBackColor
        '
        Me.lblBackColor.AutoSize = True
        Me.lblBackColor.BindearPropiedadControl = Nothing
        Me.lblBackColor.BindearPropiedadEntidad = Nothing
        Me.lblBackColor.ForeColorFocus = System.Drawing.Color.Red
        Me.lblBackColor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.lblBackColor.IsPK = False
        Me.lblBackColor.IsRequired = False
        Me.lblBackColor.Key = Nothing
        Me.lblBackColor.LabelAsoc = Nothing
        Me.lblBackColor.Location = New System.Drawing.Point(26, 95)
        Me.lblBackColor.Name = "lblBackColor"
        Me.lblBackColor.Size = New System.Drawing.Size(83, 17)
        Me.lblBackColor.TabIndex = 7
        Me.lblBackColor.Text = "Color Fondo"
        '
        'btnBackColor
        '
        Me.btnBackColor.Enabled = False
        Me.btnBackColor.Location = New System.Drawing.Point(198, 90)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(57, 23)
        Me.btnBackColor.TabIndex = 9
        Me.btnBackColor.Text = "Paleta"
        Me.btnBackColor.UseVisualStyleBackColor = True
        '
        'btnForeColor
        '
        Me.btnForeColor.Enabled = False
        Me.btnForeColor.Location = New System.Drawing.Point(198, 116)
        Me.btnForeColor.Name = "btnForeColor"
        Me.btnForeColor.Size = New System.Drawing.Size(57, 23)
        Me.btnForeColor.TabIndex = 13
        Me.btnForeColor.Text = "Paleta"
        Me.btnForeColor.UseVisualStyleBackColor = True
        '
        'lblForeColor
        '
        Me.lblForeColor.AutoSize = True
        Me.lblForeColor.BindearPropiedadControl = Nothing
        Me.lblForeColor.BindearPropiedadEntidad = Nothing
        Me.lblForeColor.ForeColorFocus = System.Drawing.Color.Red
        Me.lblForeColor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.lblForeColor.IsPK = False
        Me.lblForeColor.IsRequired = False
        Me.lblForeColor.Key = Nothing
        Me.lblForeColor.LabelAsoc = Nothing
        Me.lblForeColor.Location = New System.Drawing.Point(26, 121)
        Me.lblForeColor.Name = "lblForeColor"
        Me.lblForeColor.Size = New System.Drawing.Size(77, 17)
        Me.lblForeColor.TabIndex = 11
        Me.lblForeColor.Text = "Color Letra"
        '
        'txtForeColor
        '
        Me.txtForeColor.BindearPropiedadControl = ""
        Me.txtForeColor.BindearPropiedadEntidad = ""
        Me.txtForeColor.Enabled = False
        Me.txtForeColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtForeColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtForeColor.Formato = ""
        Me.txtForeColor.IsDecimal = False
        Me.txtForeColor.IsNumber = False
        Me.txtForeColor.IsPK = False
        Me.txtForeColor.IsRequired = False
        Me.txtForeColor.Key = ""
        Me.txtForeColor.LabelAsoc = Me.lblForeColor
        Me.txtForeColor.Location = New System.Drawing.Point(110, 117)
        Me.txtForeColor.Name = "txtForeColor"
        Me.txtForeColor.ReadOnly = True
        Me.txtForeColor.Size = New System.Drawing.Size(82, 20)
        Me.txtForeColor.TabIndex = 12
        '
        'cmbTiposEstados
        '
        Me.cmbTiposEstados.BindearPropiedadControl = "Text"
        Me.cmbTiposEstados.BindearPropiedadEntidad = "TipoEstadoCicloPlanificacion"
        Me.cmbTiposEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiposEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposEstados.FormattingEnabled = True
        Me.cmbTiposEstados.IsPK = False
        Me.cmbTiposEstados.IsRequired = True
        Me.cmbTiposEstados.Key = Nothing
        Me.cmbTiposEstados.LabelAsoc = Me.lblTipoEstado
        Me.cmbTiposEstados.Location = New System.Drawing.Point(110, 38)
        Me.cmbTiposEstados.Name = "cmbTiposEstados"
        Me.cmbTiposEstados.Size = New System.Drawing.Size(139, 21)
        Me.cmbTiposEstados.TabIndex = 3
        '
        'lblEjemploColor
        '
        Me.lblEjemploColor.AutoSize = True
        Me.lblEjemploColor.LabelAsoc = Nothing
        Me.lblEjemploColor.Location = New System.Drawing.Point(264, 116)
        Me.lblEjemploColor.Name = "lblEjemploColor"
        Me.lblEjemploColor.Size = New System.Drawing.Size(50, 13)
        Me.lblEjemploColor.TabIndex = 14
        Me.lblEjemploColor.Text = "(Ejemplo)"
        '
        'lblEjemploColorLabel
        '
        Me.lblEjemploColorLabel.AutoSize = True
        Me.lblEjemploColorLabel.LabelAsoc = Nothing
        Me.lblEjemploColorLabel.Location = New System.Drawing.Point(264, 98)
        Me.lblEjemploColorLabel.Name = "lblEjemploColorLabel"
        Me.lblEjemploColorLabel.Size = New System.Drawing.Size(44, 13)
        Me.lblEjemploColorLabel.TabIndex = 10
        Me.lblEjemploColorLabel.Text = "Ejemplo"
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
        Me.chbPorDefecto.Location = New System.Drawing.Point(145, 69)
        Me.chbPorDefecto.Name = "chbPorDefecto"
        Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
        Me.chbPorDefecto.TabIndex = 6
        Me.chbPorDefecto.Text = "Por Defecto"
        Me.chbPorDefecto.UseVisualStyleBackColor = True
        '
        'CRMEstadosCiclosPlanificacionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 221)
        Me.Controls.Add(Me.chbPorDefecto)
        Me.Controls.Add(Me.lblEjemploColorLabel)
        Me.Controls.Add(Me.lblEjemploColor)
        Me.Controls.Add(Me.txtForeColor)
        Me.Controls.Add(Me.lblForeColor)
        Me.Controls.Add(Me.txtBackColor)
        Me.Controls.Add(Me.btnForeColor)
        Me.Controls.Add(Me.lblBackColor)
        Me.Controls.Add(Me.btnBackColor)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.lblIdEstado)
        Me.Controls.Add(Me.txtIdEstado)
        Me.Controls.Add(Me.lblTipoEstado)
        Me.Controls.Add(Me.cmbTiposEstados)
        Me.Name = "CRMEstadosCiclosPlanificacionDetalle"
        Me.Text = "Estado de Ciclo de Planificación"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.cmbTiposEstados, 0)
        Me.Controls.SetChildIndex(Me.lblTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.txtIdEstado, 0)
        Me.Controls.SetChildIndex(Me.lblIdEstado, 0)
        Me.Controls.SetChildIndex(Me.txtOrden, 0)
        Me.Controls.SetChildIndex(Me.lblOrden, 0)
        Me.Controls.SetChildIndex(Me.btnBackColor, 0)
        Me.Controls.SetChildIndex(Me.lblBackColor, 0)
        Me.Controls.SetChildIndex(Me.btnForeColor, 0)
        Me.Controls.SetChildIndex(Me.txtBackColor, 0)
        Me.Controls.SetChildIndex(Me.lblForeColor, 0)
        Me.Controls.SetChildIndex(Me.txtForeColor, 0)
        Me.Controls.SetChildIndex(Me.lblEjemploColor, 0)
        Me.Controls.SetChildIndex(Me.lblEjemploColorLabel, 0)
        Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTipoEstado As Eniac.Controles.Label
   Friend WithEvents cmbTiposEstados As Eniac.Controles.ComboBox
   Friend WithEvents lblIdEstado As Eniac.Controles.Label
   Friend WithEvents txtIdEstado As Eniac.Controles.TextBox
   Friend WithEvents lblOrden As Eniac.Controles.Label
   Friend WithEvents txtOrden As Eniac.Controles.TextBox
   Friend WithEvents txtBackColor As Eniac.Controles.TextBox
   Friend WithEvents lblBackColor As Eniac.Controles.CheckBox
   Friend WithEvents btnBackColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents btnForeColor As Button
   Friend WithEvents lblForeColor As Controles.CheckBox
   Friend WithEvents txtForeColor As Controles.TextBox
   Friend WithEvents lblEjemploColor As Controles.Label
   Friend WithEvents lblEjemploColorLabel As Controles.Label
    Friend WithEvents chbPorDefecto As Controles.CheckBox
End Class
