<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosClientesDetalle
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
      Me.txtIdEstadoCliente = New Eniac.Controles.TextBox()
      Me.lblIdEstadoCliente = New Eniac.Controles.Label()
      Me.lblNombreEstadoCliente = New Eniac.Controles.Label()
      Me.txtNombreEstadoCliente = New Eniac.Controles.TextBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.btnLimpiarTamaño = New Eniac.Controles.Button()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(105, 107)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(191, 107)
      Me.btnCancelar.TabIndex = 9
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(4, 107)
      Me.btnCopiar.TabIndex = 11
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(4, 100)
      Me.btnAplicar.TabIndex = 10
      '
      'txtIdEstadoCliente
      '
      Me.txtIdEstadoCliente.BindearPropiedadControl = "Text"
      Me.txtIdEstadoCliente.BindearPropiedadEntidad = "IdEstadoCliente"
      Me.txtIdEstadoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdEstadoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdEstadoCliente.Formato = ""
      Me.txtIdEstadoCliente.IsDecimal = False
      Me.txtIdEstadoCliente.IsNumber = True
      Me.txtIdEstadoCliente.IsPK = True
      Me.txtIdEstadoCliente.IsRequired = True
      Me.txtIdEstadoCliente.Key = ""
      Me.txtIdEstadoCliente.LabelAsoc = Me.lblIdEstadoCliente
      Me.txtIdEstadoCliente.Location = New System.Drawing.Point(67, 20)
      Me.txtIdEstadoCliente.MaxLength = 5
      Me.txtIdEstadoCliente.Name = "txtIdEstadoCliente"
      Me.txtIdEstadoCliente.Size = New System.Drawing.Size(59, 20)
      Me.txtIdEstadoCliente.TabIndex = 1
      Me.txtIdEstadoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdEstadoCliente
      '
      Me.lblIdEstadoCliente.AutoSize = True
      Me.lblIdEstadoCliente.Location = New System.Drawing.Point(12, 24)
      Me.lblIdEstadoCliente.Name = "lblIdEstadoCliente"
      Me.lblIdEstadoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblIdEstadoCliente.TabIndex = 0
      Me.lblIdEstadoCliente.Text = "Código"
      '
      'lblNombreEstadoCliente
      '
      Me.lblNombreEstadoCliente.AutoSize = True
      Me.lblNombreEstadoCliente.Location = New System.Drawing.Point(12, 52)
      Me.lblNombreEstadoCliente.Name = "lblNombreEstadoCliente"
      Me.lblNombreEstadoCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreEstadoCliente.TabIndex = 2
      Me.lblNombreEstadoCliente.Text = "Nombre"
      '
      'txtNombreEstadoCliente
      '
      Me.txtNombreEstadoCliente.BindearPropiedadControl = "Text"
      Me.txtNombreEstadoCliente.BindearPropiedadEntidad = "NombreEstadoCliente"
      Me.txtNombreEstadoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEstadoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEstadoCliente.Formato = ""
      Me.txtNombreEstadoCliente.IsDecimal = False
      Me.txtNombreEstadoCliente.IsNumber = False
      Me.txtNombreEstadoCliente.IsPK = False
      Me.txtNombreEstadoCliente.IsRequired = True
      Me.txtNombreEstadoCliente.Key = ""
      Me.txtNombreEstadoCliente.LabelAsoc = Me.lblNombreEstadoCliente
      Me.txtNombreEstadoCliente.Location = New System.Drawing.Point(67, 48)
      Me.txtNombreEstadoCliente.MaxLength = 25
      Me.txtNombreEstadoCliente.Name = "txtNombreEstadoCliente"
      Me.txtNombreEstadoCliente.Size = New System.Drawing.Size(204, 20)
      Me.txtNombreEstadoCliente.TabIndex = 3
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
      'EstadosClientesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(280, 142)
      Me.Controls.Add(Me.btnLimpiarTamaño)
      Me.Controls.Add(Me.txtColor)
      Me.Controls.Add(Me.lblColorSemadoro)
      Me.Controls.Add(Me.btnColor)
      Me.Controls.Add(Me.lblNombreEstadoCliente)
      Me.Controls.Add(Me.txtNombreEstadoCliente)
      Me.Controls.Add(Me.lblIdEstadoCliente)
      Me.Controls.Add(Me.txtIdEstadoCliente)
      Me.Name = "EstadosClientesDetalle"
      Me.Text = "Estado"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.txtIdEstadoCliente, 0)
      Me.Controls.SetChildIndex(Me.lblIdEstadoCliente, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreEstadoCliente, 0)
      Me.Controls.SetChildIndex(Me.lblNombreEstadoCliente, 0)
      Me.Controls.SetChildIndex(Me.btnColor, 0)
      Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
      Me.Controls.SetChildIndex(Me.txtColor, 0)
      Me.Controls.SetChildIndex(Me.btnLimpiarTamaño, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblIdEstadoCliente As Eniac.Controles.Label
   Friend WithEvents lblNombreEstadoCliente As Eniac.Controles.Label
   Public WithEvents txtIdEstadoCliente As Eniac.Controles.TextBox
   Public WithEvents txtNombreEstadoCliente As Eniac.Controles.TextBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents btnLimpiarTamaño As Eniac.Controles.Button

End Class
