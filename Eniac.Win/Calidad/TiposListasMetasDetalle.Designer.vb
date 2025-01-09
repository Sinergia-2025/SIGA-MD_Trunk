<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TiposListasMetasDetalle
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
      Me.lblSeccion = New Eniac.Controles.Label()
      Me.dtpIngreso = New Eniac.Controles.DateTimePicker()
      Me.Label9 = New Eniac.Controles.Label()
      Me.Label13 = New Eniac.Controles.Label()
      Me.txtMeta = New Eniac.Controles.TextBox()
      Me.cmbTipoListaControl = New Eniac.Controles.ComboBox()
      Me.cmbSolicitante = New Eniac.Controles.ComboBox()
      Me.Label6 = New Eniac.Controles.Label()
      Me.lblMes = New Eniac.Controles.Label()
      Me.dtpMes = New Eniac.Controles.DateTimePicker()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(126, 114)
      Me.btnAceptar.TabIndex = 19
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(212, 114)
      Me.btnCancelar.TabIndex = 20
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(25, 114)
      Me.btnCopiar.TabIndex = 0
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(-32, 114)
      Me.btnAplicar.TabIndex = 33
      '
      'lblSeccion
      '
      Me.lblSeccion.AutoSize = True
      Me.lblSeccion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSeccion.LabelAsoc = Nothing
      Me.lblSeccion.Location = New System.Drawing.Point(33, 23)
      Me.lblSeccion.Name = "lblSeccion"
      Me.lblSeccion.Size = New System.Drawing.Size(46, 13)
      Me.lblSeccion.TabIndex = 25
      Me.lblSeccion.Text = "Sección"
      '
      'dtpIngreso
      '
      Me.dtpIngreso.BindearPropiedadControl = "Value"
      Me.dtpIngreso.BindearPropiedadEntidad = "FechaModificacion"
      Me.dtpIngreso.CustomFormat = "dd/MM/yyyy"
      Me.dtpIngreso.Enabled = False
      Me.dtpIngreso.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpIngreso.IsPK = False
      Me.dtpIngreso.IsRequired = False
      Me.dtpIngreso.Key = ""
      Me.dtpIngreso.LabelAsoc = Nothing
      Me.dtpIngreso.Location = New System.Drawing.Point(271, 106)
      Me.dtpIngreso.Name = "dtpIngreso"
      Me.dtpIngreso.Size = New System.Drawing.Size(95, 20)
      Me.dtpIngreso.TabIndex = 3
      Me.dtpIngreso.Tag = "000"
      Me.dtpIngreso.Visible = False
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.LabelAsoc = Nothing
      Me.Label9.Location = New System.Drawing.Point(219, 109)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(40, 13)
      Me.Label9.TabIndex = 24
      Me.Label9.Text = "Fecha "
      Me.Label9.Visible = False
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.LabelAsoc = Nothing
      Me.Label13.Location = New System.Drawing.Point(12, 76)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(69, 13)
      Me.Label13.TabIndex = 27
      Me.Label13.Text = "Meta coches"
      '
      'txtMeta
      '
      Me.txtMeta.BindearPropiedadControl = "Text"
      Me.txtMeta.BindearPropiedadEntidad = "MetaCoches"
      Me.txtMeta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMeta.Formato = ""
      Me.txtMeta.IsDecimal = False
      Me.txtMeta.IsNumber = False
      Me.txtMeta.IsPK = False
      Me.txtMeta.IsRequired = True
      Me.txtMeta.Key = ""
      Me.txtMeta.LabelAsoc = Me.Label13
      Me.txtMeta.Location = New System.Drawing.Point(85, 73)
      Me.txtMeta.MaxLength = 300
      Me.txtMeta.Multiline = True
      Me.txtMeta.Name = "txtMeta"
      Me.txtMeta.Size = New System.Drawing.Size(53, 21)
      Me.txtMeta.TabIndex = 6
      Me.txtMeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbTipoListaControl
      '
      Me.cmbTipoListaControl.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoListaControl.BindearPropiedadEntidad = "IdListaControlTipo"
      Me.cmbTipoListaControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoListaControl.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoListaControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoListaControl.FormattingEnabled = True
      Me.cmbTipoListaControl.IsPK = True
      Me.cmbTipoListaControl.IsRequired = True
      Me.cmbTipoListaControl.Key = Nothing
      Me.cmbTipoListaControl.LabelAsoc = Me.lblSeccion
      Me.cmbTipoListaControl.Location = New System.Drawing.Point(85, 20)
      Me.cmbTipoListaControl.Name = "cmbTipoListaControl"
      Me.cmbTipoListaControl.Size = New System.Drawing.Size(162, 21)
      Me.cmbTipoListaControl.TabIndex = 4
      '
      'cmbSolicitante
      '
      Me.cmbSolicitante.BindearPropiedadControl = "SelectedValue"
      Me.cmbSolicitante.BindearPropiedadEntidad = "IdUsuario"
      Me.cmbSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSolicitante.Enabled = False
      Me.cmbSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbSolicitante.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSolicitante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSolicitante.FormattingEnabled = True
      Me.cmbSolicitante.IsPK = False
      Me.cmbSolicitante.IsRequired = False
      Me.cmbSolicitante.Key = Nothing
      Me.cmbSolicitante.LabelAsoc = Me.Label6
      Me.cmbSolicitante.Location = New System.Drawing.Point(85, 105)
      Me.cmbSolicitante.Name = "cmbSolicitante"
      Me.cmbSolicitante.Size = New System.Drawing.Size(119, 21)
      Me.cmbSolicitante.TabIndex = 2
      Me.cmbSolicitante.Visible = False
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.LabelAsoc = Nothing
      Me.Label6.Location = New System.Drawing.Point(15, 109)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(43, 13)
      Me.Label6.TabIndex = 23
      Me.Label6.Text = "Usuario"
      Me.Label6.Visible = False
      '
      'lblMes
      '
      Me.lblMes.AutoSize = True
      Me.lblMes.LabelAsoc = Me.lblMes
      Me.lblMes.Location = New System.Drawing.Point(52, 50)
      Me.lblMes.Name = "lblMes"
      Me.lblMes.Size = New System.Drawing.Size(27, 13)
      Me.lblMes.TabIndex = 35
      Me.lblMes.Text = "Mes"
      '
      'dtpMes
      '
      Me.dtpMes.BindearPropiedadControl = "Value"
      Me.dtpMes.BindearPropiedadEntidad = "Dia"
      Me.dtpMes.CustomFormat = ""
      Me.dtpMes.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpMes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpMes.IsPK = True
      Me.dtpMes.IsRequired = True
      Me.dtpMes.Key = ""
      Me.dtpMes.LabelAsoc = Nothing
      Me.dtpMes.Location = New System.Drawing.Point(85, 47)
      Me.dtpMes.Name = "dtpMes"
      Me.dtpMes.Size = New System.Drawing.Size(76, 20)
      Me.dtpMes.TabIndex = 34
      Me.dtpMes.Tag = "000"
      '
      'TiposListasMetasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(301, 149)
      Me.Controls.Add(Me.lblMes)
      Me.Controls.Add(Me.dtpMes)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.txtMeta)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.dtpIngreso)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.cmbSolicitante)
      Me.Controls.Add(Me.lblSeccion)
      Me.Controls.Add(Me.cmbTipoListaControl)
      Me.Name = "TiposListasMetasDetalle"
      Me.Text = "Meta Diaria de Coches por Sección"
      Me.Controls.SetChildIndex(Me.cmbTipoListaControl, 0)
      Me.Controls.SetChildIndex(Me.lblSeccion, 0)
      Me.Controls.SetChildIndex(Me.cmbSolicitante, 0)
      Me.Controls.SetChildIndex(Me.Label6, 0)
      Me.Controls.SetChildIndex(Me.dtpIngreso, 0)
      Me.Controls.SetChildIndex(Me.Label9, 0)
      Me.Controls.SetChildIndex(Me.txtMeta, 0)
      Me.Controls.SetChildIndex(Me.Label13, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.dtpMes, 0)
      Me.Controls.SetChildIndex(Me.lblMes, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblSeccion As Controles.Label
   Friend WithEvents cmbTipoListaControl As Controles.ComboBox
   Friend WithEvents dtpIngreso As Controles.DateTimePicker
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents Label13 As Controles.Label
   Friend WithEvents txtMeta As Controles.TextBox
   Friend WithEvents cmbSolicitante As Controles.ComboBox
   Friend WithEvents Label6 As Controles.Label
   Friend WithEvents lblMes As Controles.Label
   Friend WithEvents dtpMes As Controles.DateTimePicker
End Class
