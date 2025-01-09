<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMMediosComunicacionesNovedadesDetalle
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
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreMedioComunicacionNovedad = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.txtIdMedioComunicacionNovedad = New Eniac.Controles.TextBox()
      Me.chbPorDefecto = New Eniac.Controles.CheckBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(191, 144)
      Me.btnAceptar.TabIndex = 12
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(277, 144)
      Me.btnCancelar.TabIndex = 13
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(91, 144)
      Me.btnCopiar.TabIndex = 14
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(31, 144)
      Me.btnAplicar.TabIndex = 15
      '
      'cmbTipoNovedad
      '
      Me.cmbTipoNovedad.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoNovedad.BindearPropiedadEntidad = "TipoNovedad.IdTipoNovedad"
      Me.cmbTipoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoNovedad.FormattingEnabled = True
      Me.cmbTipoNovedad.IsPK = False
      Me.cmbTipoNovedad.IsRequired = False
      Me.cmbTipoNovedad.Key = Nothing
      Me.cmbTipoNovedad.LabelAsoc = Nothing
      Me.cmbTipoNovedad.Location = New System.Drawing.Point(87, 64)
      Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
      Me.cmbTipoNovedad.Size = New System.Drawing.Size(262, 21)
      Me.cmbTipoNovedad.TabIndex = 5
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(10, 42)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombreMedioComunicacionNovedad
      '
      Me.txtNombreMedioComunicacionNovedad.BindearPropiedadControl = "Text"
      Me.txtNombreMedioComunicacionNovedad.BindearPropiedadEntidad = "NombreMedioComunicacionNovedad"
      Me.txtNombreMedioComunicacionNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreMedioComunicacionNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreMedioComunicacionNovedad.Formato = ""
      Me.txtNombreMedioComunicacionNovedad.IsDecimal = False
      Me.txtNombreMedioComunicacionNovedad.IsNumber = False
      Me.txtNombreMedioComunicacionNovedad.IsPK = False
      Me.txtNombreMedioComunicacionNovedad.IsRequired = True
      Me.txtNombreMedioComunicacionNovedad.Key = ""
      Me.txtNombreMedioComunicacionNovedad.LabelAsoc = Me.lblDescripcion
      Me.txtNombreMedioComunicacionNovedad.Location = New System.Drawing.Point(87, 38)
      Me.txtNombreMedioComunicacionNovedad.MaxLength = 20
      Me.txtNombreMedioComunicacionNovedad.Name = "txtNombreMedioComunicacionNovedad"
      Me.txtNombreMedioComunicacionNovedad.Size = New System.Drawing.Size(225, 20)
      Me.txtNombreMedioComunicacionNovedad.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(10, 67)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(75, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Tipo Novedad"
      '
      'lblPosicion
      '
      Me.lblPosicion.AutoSize = True
      Me.lblPosicion.LabelAsoc = Nothing
      Me.lblPosicion.Location = New System.Drawing.Point(10, 95)
      Me.lblPosicion.Name = "lblPosicion"
      Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
      Me.lblPosicion.TabIndex = 6
      Me.lblPosicion.Text = "Posición"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(10, 16)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Codigo"
      '
      'txtPosicion
      '
      Me.txtPosicion.BindearPropiedadControl = "Text"
      Me.txtPosicion.BindearPropiedadEntidad = "Posicion"
      Me.txtPosicion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPosicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPosicion.Formato = ""
      Me.txtPosicion.IsDecimal = False
      Me.txtPosicion.IsNumber = True
      Me.txtPosicion.IsPK = False
      Me.txtPosicion.IsRequired = True
      Me.txtPosicion.Key = ""
      Me.txtPosicion.LabelAsoc = Me.lblPosicion
      Me.txtPosicion.Location = New System.Drawing.Point(87, 91)
      Me.txtPosicion.MaxLength = 4
      Me.txtPosicion.Name = "txtPosicion"
      Me.txtPosicion.Size = New System.Drawing.Size(54, 20)
      Me.txtPosicion.TabIndex = 7
      Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtIdMedioComunicacionNovedad
      '
      Me.txtIdMedioComunicacionNovedad.BindearPropiedadControl = "Text"
      Me.txtIdMedioComunicacionNovedad.BindearPropiedadEntidad = "IdMedioComunicacionNovedad"
      Me.txtIdMedioComunicacionNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdMedioComunicacionNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdMedioComunicacionNovedad.Formato = ""
      Me.txtIdMedioComunicacionNovedad.IsDecimal = False
      Me.txtIdMedioComunicacionNovedad.IsNumber = True
      Me.txtIdMedioComunicacionNovedad.IsPK = True
      Me.txtIdMedioComunicacionNovedad.IsRequired = True
      Me.txtIdMedioComunicacionNovedad.Key = ""
      Me.txtIdMedioComunicacionNovedad.LabelAsoc = Me.lblCodigo
      Me.txtIdMedioComunicacionNovedad.Location = New System.Drawing.Point(87, 12)
      Me.txtIdMedioComunicacionNovedad.MaxLength = 10
      Me.txtIdMedioComunicacionNovedad.Name = "txtIdMedioComunicacionNovedad"
      Me.txtIdMedioComunicacionNovedad.Size = New System.Drawing.Size(54, 20)
      Me.txtIdMedioComunicacionNovedad.TabIndex = 1
      Me.txtIdMedioComunicacionNovedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.chbPorDefecto.Location = New System.Drawing.Point(87, 117)
      Me.chbPorDefecto.Name = "chbPorDefecto"
      Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
      Me.chbPorDefecto.TabIndex = 11
      Me.chbPorDefecto.Text = "Por Defecto"
      Me.chbPorDefecto.UseVisualStyleBackColor = True
      '
      'txtColor
      '
      Me.txtColor.BindearPropiedadControl = "Key"
      Me.txtColor.BindearPropiedadEntidad = "Color"
      Me.txtColor.Enabled = False
      Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtColor.Formato = ""
      Me.txtColor.IsDecimal = False
      Me.txtColor.IsNumber = False
      Me.txtColor.IsPK = False
      Me.txtColor.IsRequired = False
      Me.txtColor.Key = ""
      Me.txtColor.LabelAsoc = Me.lblColorSemadoro
      Me.txtColor.Location = New System.Drawing.Point(204, 92)
      Me.txtColor.Name = "txtColor"
      Me.txtColor.ReadOnly = True
      Me.txtColor.Size = New System.Drawing.Size(82, 20)
      Me.txtColor.TabIndex = 9
      Me.txtColor.TabStop = False
      '
      'lblColorSemadoro
      '
      Me.lblColorSemadoro.AutoSize = True
      Me.lblColorSemadoro.LabelAsoc = Nothing
      Me.lblColorSemadoro.Location = New System.Drawing.Point(167, 96)
      Me.lblColorSemadoro.Name = "lblColorSemadoro"
      Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
      Me.lblColorSemadoro.TabIndex = 8
      Me.lblColorSemadoro.Text = "Color"
      '
      'btnColor
      '
      Me.btnColor.Location = New System.Drawing.Point(292, 91)
      Me.btnColor.Name = "btnColor"
      Me.btnColor.Size = New System.Drawing.Size(57, 23)
      Me.btnColor.TabIndex = 10
      Me.btnColor.Text = "Paleta"
      Me.btnColor.UseVisualStyleBackColor = True
      '
      'CRMMediosComunicacionesNovedadesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(366, 179)
      Me.Controls.Add(Me.txtColor)
      Me.Controls.Add(Me.lblColorSemadoro)
      Me.Controls.Add(Me.btnColor)
      Me.Controls.Add(Me.chbPorDefecto)
      Me.Controls.Add(Me.cmbTipoNovedad)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreMedioComunicacionNovedad)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblPosicion)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtPosicion)
      Me.Controls.Add(Me.txtIdMedioComunicacionNovedad)
      Me.Name = "CRMMediosComunicacionesNovedadesDetalle"
      Me.Text = "Medio Comunicación Novedades"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdMedioComunicacionNovedad, 0)
      Me.Controls.SetChildIndex(Me.txtPosicion, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblPosicion, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtNombreMedioComunicacionNovedad, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoNovedad, 0)
      Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
      Me.Controls.SetChildIndex(Me.btnColor, 0)
      Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
      Me.Controls.SetChildIndex(Me.txtColor, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombreMedioComunicacionNovedad As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents lblPosicion As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtPosicion As Eniac.Controles.TextBox
   Friend WithEvents txtIdMedioComunicacionNovedad As Eniac.Controles.TextBox
   Friend WithEvents chbPorDefecto As Eniac.Controles.CheckBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
End Class
