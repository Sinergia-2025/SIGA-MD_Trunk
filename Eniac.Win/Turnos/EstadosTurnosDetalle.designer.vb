<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosTurnosDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.txtIdEstadoTurno = New Eniac.Controles.TextBox()
      Me.lblIdEstadoCliente = New Eniac.Controles.Label()
      Me.lblNombreEstadoCliente = New Eniac.Controles.Label()
      Me.txtNombreEstadoTurno = New Eniac.Controles.TextBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.btnLimpiarTamaño = New Eniac.Controles.Button()
      Me.chbFinalizado = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(105, 131)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(191, 131)
      Me.btnCancelar.TabIndex = 9
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(4, 131)
      Me.btnCopiar.TabIndex = 11
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(4, 124)
      Me.btnAplicar.TabIndex = 10
      '
      'txtIdEstadoTurno
      '
      Me.txtIdEstadoTurno.BindearPropiedadControl = "Text"
      Me.txtIdEstadoTurno.BindearPropiedadEntidad = "IdEstadoTurno"
      Me.txtIdEstadoTurno.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdEstadoTurno.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdEstadoTurno.Formato = ""
      Me.txtIdEstadoTurno.IsDecimal = False
      Me.txtIdEstadoTurno.IsNumber = False
      Me.txtIdEstadoTurno.IsPK = True
      Me.txtIdEstadoTurno.IsRequired = True
      Me.txtIdEstadoTurno.Key = ""
      Me.txtIdEstadoTurno.LabelAsoc = Me.lblIdEstadoCliente
      Me.txtIdEstadoTurno.Location = New System.Drawing.Point(67, 20)
      Me.txtIdEstadoTurno.MaxLength = 5
      Me.txtIdEstadoTurno.Name = "txtIdEstadoTurno"
      Me.txtIdEstadoTurno.Size = New System.Drawing.Size(59, 20)
      Me.txtIdEstadoTurno.TabIndex = 1
      Me.txtIdEstadoTurno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdEstadoCliente
      '
      Me.lblIdEstadoCliente.AutoSize = True
      Me.lblIdEstadoCliente.LabelAsoc = Nothing
      Me.lblIdEstadoCliente.Location = New System.Drawing.Point(12, 24)
      Me.lblIdEstadoCliente.Name = "lblIdEstadoCliente"
      Me.lblIdEstadoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblIdEstadoCliente.TabIndex = 0
      Me.lblIdEstadoCliente.Text = "Código"
      '
      'lblNombreEstadoCliente
      '
      Me.lblNombreEstadoCliente.AutoSize = True
      Me.lblNombreEstadoCliente.LabelAsoc = Nothing
      Me.lblNombreEstadoCliente.Location = New System.Drawing.Point(12, 52)
      Me.lblNombreEstadoCliente.Name = "lblNombreEstadoCliente"
      Me.lblNombreEstadoCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreEstadoCliente.TabIndex = 2
      Me.lblNombreEstadoCliente.Text = "Nombre"
      '
      'txtNombreEstadoTurno
      '
      Me.txtNombreEstadoTurno.BindearPropiedadControl = "Text"
      Me.txtNombreEstadoTurno.BindearPropiedadEntidad = "NombreEstadoTurno"
      Me.txtNombreEstadoTurno.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEstadoTurno.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEstadoTurno.Formato = ""
      Me.txtNombreEstadoTurno.IsDecimal = False
      Me.txtNombreEstadoTurno.IsNumber = False
      Me.txtNombreEstadoTurno.IsPK = False
      Me.txtNombreEstadoTurno.IsRequired = True
      Me.txtNombreEstadoTurno.Key = ""
      Me.txtNombreEstadoTurno.LabelAsoc = Me.lblNombreEstadoCliente
      Me.txtNombreEstadoTurno.Location = New System.Drawing.Point(67, 48)
      Me.txtNombreEstadoTurno.MaxLength = 25
      Me.txtNombreEstadoTurno.Name = "txtNombreEstadoTurno"
      Me.txtNombreEstadoTurno.Size = New System.Drawing.Size(204, 20)
      Me.txtNombreEstadoTurno.TabIndex = 3
      '
      'txtColor
      '
      Me.txtColor.BindearPropiedadControl = ""
      Me.txtColor.BindearPropiedadEntidad = ""
      Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtColor.Formato = ""
      Me.txtColor.IsDecimal = False
      Me.txtColor.IsNumber = False
      Me.txtColor.IsPK = False
      Me.txtColor.IsRequired = False
      Me.txtColor.Key = ""
      Me.txtColor.LabelAsoc = Me.lblColorSemadoro
      Me.txtColor.Location = New System.Drawing.Point(67, 74)
      Me.txtColor.Name = "txtColor"
      Me.txtColor.ReadOnly = True
      Me.txtColor.Size = New System.Drawing.Size(82, 20)
      Me.txtColor.TabIndex = 5
      Me.txtColor.TabStop = False
      '
      'lblColorSemadoro
      '
      Me.lblColorSemadoro.AutoSize = True
      Me.lblColorSemadoro.LabelAsoc = Nothing
      Me.lblColorSemadoro.Location = New System.Drawing.Point(12, 78)
      Me.lblColorSemadoro.Name = "lblColorSemadoro"
      Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
      Me.lblColorSemadoro.TabIndex = 4
      Me.lblColorSemadoro.Text = "Color"
      '
      'btnColor
      '
      Me.btnColor.Location = New System.Drawing.Point(155, 73)
      Me.btnColor.Name = "btnColor"
      Me.btnColor.Size = New System.Drawing.Size(57, 23)
      Me.btnColor.TabIndex = 6
      Me.btnColor.Text = "Paleta"
      Me.btnColor.UseVisualStyleBackColor = True
      '
      'btnLimpiarTamaño
      '
      Me.btnLimpiarTamaño.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.btnLimpiarTamaño.Location = New System.Drawing.Point(218, 71)
      Me.btnLimpiarTamaño.Name = "btnLimpiarTamaño"
      Me.btnLimpiarTamaño.Size = New System.Drawing.Size(30, 30)
      Me.btnLimpiarTamaño.TabIndex = 7
      Me.btnLimpiarTamaño.TabStop = False
      Me.btnLimpiarTamaño.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnLimpiarTamaño.UseVisualStyleBackColor = True
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
      Me.chbFinalizado.Location = New System.Drawing.Point(67, 102)
      Me.chbFinalizado.Name = "chbFinalizado"
      Me.chbFinalizado.Size = New System.Drawing.Size(73, 17)
      Me.chbFinalizado.TabIndex = 12
      Me.chbFinalizado.Text = "Finalizado"
      Me.chbFinalizado.UseVisualStyleBackColor = True
      '
      'EstadosTurnosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(280, 166)
      Me.Controls.Add(Me.chbFinalizado)
      Me.Controls.Add(Me.btnLimpiarTamaño)
      Me.Controls.Add(Me.txtColor)
      Me.Controls.Add(Me.lblColorSemadoro)
      Me.Controls.Add(Me.btnColor)
      Me.Controls.Add(Me.lblNombreEstadoCliente)
      Me.Controls.Add(Me.txtNombreEstadoTurno)
      Me.Controls.Add(Me.lblIdEstadoCliente)
      Me.Controls.Add(Me.txtIdEstadoTurno)
      Me.Name = "EstadosTurnosDetalle"
      Me.Text = "Estado Turno"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.txtIdEstadoTurno, 0)
      Me.Controls.SetChildIndex(Me.lblIdEstadoCliente, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreEstadoTurno, 0)
      Me.Controls.SetChildIndex(Me.lblNombreEstadoCliente, 0)
      Me.Controls.SetChildIndex(Me.btnColor, 0)
      Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
      Me.Controls.SetChildIndex(Me.txtColor, 0)
      Me.Controls.SetChildIndex(Me.btnLimpiarTamaño, 0)
      Me.Controls.SetChildIndex(Me.chbFinalizado, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblIdEstadoCliente As Eniac.Controles.Label
   Friend WithEvents lblNombreEstadoCliente As Eniac.Controles.Label
   Public WithEvents txtIdEstadoTurno As Eniac.Controles.TextBox
   Public WithEvents txtNombreEstadoTurno As Eniac.Controles.TextBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents btnLimpiarTamaño As Eniac.Controles.Button
   Friend WithEvents chbFinalizado As Eniac.Controles.CheckBox

End Class
