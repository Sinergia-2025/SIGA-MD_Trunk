<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosTurismoDetalle
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
      Me.txtNombreEstado = New Eniac.Controles.TextBox()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.txtIdEstado = New Eniac.Controles.TextBox()
      Me.chbFinalizado = New Eniac.Controles.CheckBox()
      Me.chbPorDefecto = New Eniac.Controles.CheckBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.chbSolicitaPasajeros = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(191, 139)
      Me.btnAceptar.TabIndex = 7
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(277, 139)
      Me.btnCancelar.TabIndex = 8
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(90, 139)
      Me.btnCopiar.TabIndex = 13
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(31, 139)
      Me.btnAplicar.TabIndex = 12
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(9, 42)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 10
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombreEstado
      '
      Me.txtNombreEstado.BindearPropiedadControl = "Text"
      Me.txtNombreEstado.BindearPropiedadEntidad = "NombreEstadoTurismo"
      Me.txtNombreEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEstado.Formato = ""
      Me.txtNombreEstado.IsDecimal = False
      Me.txtNombreEstado.IsNumber = False
      Me.txtNombreEstado.IsPK = False
      Me.txtNombreEstado.IsRequired = True
      Me.txtNombreEstado.Key = ""
      Me.txtNombreEstado.LabelAsoc = Me.lblDescripcion
      Me.txtNombreEstado.Location = New System.Drawing.Point(86, 38)
      Me.txtNombreEstado.MaxLength = 20
      Me.txtNombreEstado.Name = "txtNombreEstado"
      Me.txtNombreEstado.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreEstado.TabIndex = 1
      '
      'lblPosicion
      '
      Me.lblPosicion.AutoSize = True
      Me.lblPosicion.LabelAsoc = Nothing
      Me.lblPosicion.Location = New System.Drawing.Point(9, 67)
      Me.lblPosicion.Name = "lblPosicion"
      Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
      Me.lblPosicion.TabIndex = 11
      Me.lblPosicion.Text = "Posición"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(9, 16)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 9
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
      Me.txtPosicion.TabIndex = 2
      Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtIdEstado
      '
      Me.txtIdEstado.BindearPropiedadControl = "Text"
      Me.txtIdEstado.BindearPropiedadEntidad = "IdEstadoTurismo"
      Me.txtIdEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdEstado.Formato = ""
      Me.txtIdEstado.IsDecimal = False
      Me.txtIdEstado.IsNumber = True
      Me.txtIdEstado.IsPK = True
      Me.txtIdEstado.IsRequired = True
      Me.txtIdEstado.Key = ""
      Me.txtIdEstado.LabelAsoc = Me.lblCodigo
      Me.txtIdEstado.Location = New System.Drawing.Point(86, 12)
      Me.txtIdEstado.MaxLength = 10
      Me.txtIdEstado.Name = "txtIdEstado"
      Me.txtIdEstado.Size = New System.Drawing.Size(54, 20)
      Me.txtIdEstado.TabIndex = 0
      Me.txtIdEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.chbFinalizado.TabIndex = 5
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
      Me.chbPorDefecto.TabIndex = 4
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
      Me.txtColor.TabIndex = 3
      Me.txtColor.TabStop = False
      '
      'lblColorSemadoro
      '
      Me.lblColorSemadoro.AutoSize = True
      Me.lblColorSemadoro.LabelAsoc = Nothing
      Me.lblColorSemadoro.Location = New System.Drawing.Point(166, 67)
      Me.lblColorSemadoro.Name = "lblColorSemadoro"
      Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
      Me.lblColorSemadoro.TabIndex = 14
      Me.lblColorSemadoro.Text = "Color"
      '
      'btnColor
      '
      Me.btnColor.Location = New System.Drawing.Point(291, 62)
      Me.btnColor.Name = "btnColor"
      Me.btnColor.Size = New System.Drawing.Size(57, 23)
      Me.btnColor.TabIndex = 15
      Me.btnColor.Text = "Paleta"
      Me.btnColor.UseVisualStyleBackColor = True
      '
      'chbSolicitaPasajeros
      '
      Me.chbSolicitaPasajeros.AutoSize = True
      Me.chbSolicitaPasajeros.BindearPropiedadControl = "Checked"
      Me.chbSolicitaPasajeros.BindearPropiedadEntidad = "SolicitaPasajeros"
      Me.chbSolicitaPasajeros.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSolicitaPasajeros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSolicitaPasajeros.IsPK = False
      Me.chbSolicitaPasajeros.IsRequired = False
      Me.chbSolicitaPasajeros.Key = Nothing
      Me.chbSolicitaPasajeros.LabelAsoc = Nothing
      Me.chbSolicitaPasajeros.Location = New System.Drawing.Point(86, 113)
      Me.chbSolicitaPasajeros.Name = "chbSolicitaPasajeros"
      Me.chbSolicitaPasajeros.Size = New System.Drawing.Size(109, 17)
      Me.chbSolicitaPasajeros.TabIndex = 6
      Me.chbSolicitaPasajeros.Text = "Solicita Pasajeros"
      Me.chbSolicitaPasajeros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.chbSolicitaPasajeros.UseVisualStyleBackColor = True
      '
      'EstadosTurismoDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(366, 174)
      Me.Controls.Add(Me.chbSolicitaPasajeros)
      Me.Controls.Add(Me.txtColor)
      Me.Controls.Add(Me.lblColorSemadoro)
      Me.Controls.Add(Me.btnColor)
      Me.Controls.Add(Me.chbPorDefecto)
      Me.Controls.Add(Me.chbFinalizado)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreEstado)
      Me.Controls.Add(Me.lblPosicion)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtPosicion)
      Me.Controls.Add(Me.txtIdEstado)
      Me.Name = "EstadosTurismoDetalle"
      Me.Text = "Estado "
      Me.Controls.SetChildIndex(Me.txtIdEstado, 0)
      Me.Controls.SetChildIndex(Me.txtPosicion, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblPosicion, 0)
      Me.Controls.SetChildIndex(Me.txtNombreEstado, 0)
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
      Me.Controls.SetChildIndex(Me.chbSolicitaPasajeros, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombreEstado As Eniac.Controles.TextBox
   Friend WithEvents lblPosicion As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtPosicion As Eniac.Controles.TextBox
   Friend WithEvents txtIdEstado As Eniac.Controles.TextBox
   Friend WithEvents chbFinalizado As Eniac.Controles.CheckBox
   Friend WithEvents chbPorDefecto As Eniac.Controles.CheckBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents chbSolicitaPasajeros As Eniac.Controles.CheckBox
End Class
