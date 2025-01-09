<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosListasControlDetalle
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
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreEstadoNovedad = New Eniac.Controles.TextBox()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.txtIdEstadoNovedad = New Eniac.Controles.TextBox()
      Me.chbFinalizado = New Eniac.Controles.CheckBox()
      Me.chbPorDefecto = New Eniac.Controles.CheckBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(182, 128)
      Me.btnAceptar.TabIndex = 17
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(268, 128)
      Me.btnCancelar.TabIndex = 18
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(81, 128)
      Me.btnCopiar.TabIndex = 20
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(22, 128)
      Me.btnAplicar.TabIndex = 19
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(9, 42)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombreEstadoNovedad
      '
      Me.txtNombreEstadoNovedad.BindearPropiedadControl = "Text"
      Me.txtNombreEstadoNovedad.BindearPropiedadEntidad = "NombreEstadoCalidad"
      Me.txtNombreEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEstadoNovedad.Formato = ""
      Me.txtNombreEstadoNovedad.IsDecimal = False
      Me.txtNombreEstadoNovedad.IsNumber = False
      Me.txtNombreEstadoNovedad.IsPK = False
      Me.txtNombreEstadoNovedad.IsRequired = True
      Me.txtNombreEstadoNovedad.Key = ""
      Me.txtNombreEstadoNovedad.LabelAsoc = Me.lblDescripcion
      Me.txtNombreEstadoNovedad.Location = New System.Drawing.Point(86, 38)
      Me.txtNombreEstadoNovedad.MaxLength = 20
      Me.txtNombreEstadoNovedad.Name = "txtNombreEstadoNovedad"
      Me.txtNombreEstadoNovedad.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreEstadoNovedad.TabIndex = 3
      '
      'lblPosicion
      '
      Me.lblPosicion.AutoSize = True
      Me.lblPosicion.LabelAsoc = Nothing
      Me.lblPosicion.Location = New System.Drawing.Point(9, 67)
      Me.lblPosicion.Name = "lblPosicion"
      Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
      Me.lblPosicion.TabIndex = 6
      Me.lblPosicion.Text = "Posición"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(9, 16)
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
      Me.txtPosicion.Location = New System.Drawing.Point(86, 64)
      Me.txtPosicion.MaxLength = 4
      Me.txtPosicion.Name = "txtPosicion"
      Me.txtPosicion.Size = New System.Drawing.Size(54, 20)
      Me.txtPosicion.TabIndex = 7
      Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtIdEstadoNovedad
      '
      Me.txtIdEstadoNovedad.BindearPropiedadControl = "Text"
      Me.txtIdEstadoNovedad.BindearPropiedadEntidad = "IdEstadoCalidad"
      Me.txtIdEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdEstadoNovedad.Formato = ""
      Me.txtIdEstadoNovedad.IsDecimal = False
      Me.txtIdEstadoNovedad.IsNumber = True
      Me.txtIdEstadoNovedad.IsPK = True
      Me.txtIdEstadoNovedad.IsRequired = True
      Me.txtIdEstadoNovedad.Key = ""
      Me.txtIdEstadoNovedad.LabelAsoc = Me.lblCodigo
      Me.txtIdEstadoNovedad.Location = New System.Drawing.Point(86, 12)
      Me.txtIdEstadoNovedad.MaxLength = 10
      Me.txtIdEstadoNovedad.Name = "txtIdEstadoNovedad"
      Me.txtIdEstadoNovedad.Size = New System.Drawing.Size(54, 20)
      Me.txtIdEstadoNovedad.TabIndex = 1
      Me.txtIdEstadoNovedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbFinalizado
      '
      Me.chbFinalizado.AutoSize = True
      Me.chbFinalizado.BindearPropiedadControl = "Checked"
      Me.chbFinalizado.BindearPropiedadEntidad = "Finalizado"
      Me.chbFinalizado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFinalizado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFinalizado.IsPK = False
      Me.chbFinalizado.IsRequired = False
      Me.chbFinalizado.Key = Nothing
      Me.chbFinalizado.LabelAsoc = Nothing
      Me.chbFinalizado.Location = New System.Drawing.Point(203, 90)
      Me.chbFinalizado.Name = "chbFinalizado"
      Me.chbFinalizado.Size = New System.Drawing.Size(73, 17)
      Me.chbFinalizado.TabIndex = 12
      Me.chbFinalizado.Text = "Finalizado"
      Me.chbFinalizado.UseVisualStyleBackColor = True
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
      Me.chbPorDefecto.Location = New System.Drawing.Point(86, 90)
      Me.chbPorDefecto.Name = "chbPorDefecto"
      Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
      Me.chbPorDefecto.TabIndex = 14
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
      Me.txtColor.Location = New System.Drawing.Point(203, 63)
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
      Me.lblColorSemadoro.Location = New System.Drawing.Point(166, 67)
      Me.lblColorSemadoro.Name = "lblColorSemadoro"
      Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
      Me.lblColorSemadoro.TabIndex = 8
      Me.lblColorSemadoro.Text = "Color"
      '
      'btnColor
      '
      Me.btnColor.Location = New System.Drawing.Point(291, 62)
      Me.btnColor.Name = "btnColor"
      Me.btnColor.Size = New System.Drawing.Size(57, 23)
      Me.btnColor.TabIndex = 10
      Me.btnColor.Text = "Paleta"
      Me.btnColor.UseVisualStyleBackColor = True
      '
      'EstadosListasControlDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(357, 163)
      Me.Controls.Add(Me.txtColor)
      Me.Controls.Add(Me.lblColorSemadoro)
      Me.Controls.Add(Me.btnColor)
      Me.Controls.Add(Me.chbPorDefecto)
      Me.Controls.Add(Me.chbFinalizado)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreEstadoNovedad)
      Me.Controls.Add(Me.lblPosicion)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtPosicion)
      Me.Controls.Add(Me.txtIdEstadoNovedad)
      Me.Name = "EstadosListasControlDetalle"
      Me.Text = "Estado Listas de Control"
      Me.Controls.SetChildIndex(Me.txtIdEstadoNovedad, 0)
      Me.Controls.SetChildIndex(Me.txtPosicion, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblPosicion, 0)
      Me.Controls.SetChildIndex(Me.txtNombreEstadoNovedad, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.chbFinalizado, 0)
      Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
      Me.Controls.SetChildIndex(Me.btnColor, 0)
      Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
      Me.Controls.SetChildIndex(Me.txtColor, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombreEstadoNovedad As Eniac.Controles.TextBox
   Friend WithEvents lblPosicion As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtPosicion As Eniac.Controles.TextBox
   Friend WithEvents txtIdEstadoNovedad As Eniac.Controles.TextBox
   Friend WithEvents chbFinalizado As Eniac.Controles.CheckBox
   Friend WithEvents chbPorDefecto As Eniac.Controles.CheckBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
End Class
