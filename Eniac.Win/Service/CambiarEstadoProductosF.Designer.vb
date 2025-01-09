<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarEstadoProductosF
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiarEstadoProductosF))
      Me.grbProducto = New System.Windows.Forms.GroupBox()
      Me.lblCodigoProducto = New Eniac.Controles.Label()
      Me.txtNombreProducto = New Eniac.Controles.TextBox()
      Me.lblNombreProducto = New Eniac.Controles.Label()
      Me.txtCodigoProducto = New Eniac.Controles.TextBox()
      Me.cmbEstado = New Eniac.Controles.ComboBox()
      Me.lblEstadoNuevo = New Eniac.Controles.Label()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.grbProducto.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(210, 261)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(296, 261)
      Me.btnCancelar.TabIndex = 4
      '
      'grbProducto
      '
      Me.grbProducto.Controls.Add(Me.lblCodigoProducto)
      Me.grbProducto.Controls.Add(Me.txtNombreProducto)
      Me.grbProducto.Controls.Add(Me.txtCodigoProducto)
      Me.grbProducto.Controls.Add(Me.lblNombreProducto)
      Me.grbProducto.Location = New System.Drawing.Point(12, 12)
      Me.grbProducto.Name = "grbProducto"
      Me.grbProducto.Size = New System.Drawing.Size(362, 59)
      Me.grbProducto.TabIndex = 5
      Me.grbProducto.TabStop = False
      Me.grbProducto.Text = "Producto"
      '
      'lblCodigoProducto
      '
      Me.lblCodigoProducto.AutoSize = True
      Me.lblCodigoProducto.Location = New System.Drawing.Point(6, 16)
      Me.lblCodigoProducto.Name = "lblCodigoProducto"
      Me.lblCodigoProducto.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProducto.TabIndex = 2
      Me.lblCodigoProducto.Text = "Código"
      '
      'txtNombreProducto
      '
      Me.txtNombreProducto.BindearPropiedadControl = "Text"
      Me.txtNombreProducto.BindearPropiedadEntidad = "Nota.Producto.NombreProducto"
      Me.txtNombreProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreProducto.Formato = ""
      Me.txtNombreProducto.IsDecimal = False
      Me.txtNombreProducto.IsNumber = False
      Me.txtNombreProducto.IsPK = False
      Me.txtNombreProducto.IsRequired = False
      Me.txtNombreProducto.Key = ""
      Me.txtNombreProducto.LabelAsoc = Me.lblNombreProducto
      Me.txtNombreProducto.Location = New System.Drawing.Point(90, 32)
      Me.txtNombreProducto.Name = "txtNombreProducto"
      Me.txtNombreProducto.ReadOnly = True
      Me.txtNombreProducto.Size = New System.Drawing.Size(266, 20)
      Me.txtNombreProducto.TabIndex = 1
      Me.txtNombreProducto.TabStop = False
      '
      'lblNombreProducto
      '
      Me.lblNombreProducto.AutoSize = True
      Me.lblNombreProducto.Location = New System.Drawing.Point(87, 16)
      Me.lblNombreProducto.Name = "lblNombreProducto"
      Me.lblNombreProducto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProducto.TabIndex = 3
      Me.lblNombreProducto.Text = "Nombre"
      '
      'txtCodigoProducto
      '
      Me.txtCodigoProducto.BindearPropiedadControl = "Text"
      Me.txtCodigoProducto.BindearPropiedadEntidad = "Nota.Producto.IdProducto"
      Me.txtCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigoProducto.Formato = ""
      Me.txtCodigoProducto.IsDecimal = False
      Me.txtCodigoProducto.IsNumber = False
      Me.txtCodigoProducto.IsPK = False
      Me.txtCodigoProducto.IsRequired = False
      Me.txtCodigoProducto.Key = ""
      Me.txtCodigoProducto.LabelAsoc = Me.lblCodigoProducto
      Me.txtCodigoProducto.Location = New System.Drawing.Point(9, 32)
      Me.txtCodigoProducto.Name = "txtCodigoProducto"
      Me.txtCodigoProducto.ReadOnly = True
      Me.txtCodigoProducto.Size = New System.Drawing.Size(74, 20)
      Me.txtCodigoProducto.TabIndex = 0
      Me.txtCodigoProducto.TabStop = False
      Me.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbEstado
      '
      Me.cmbEstado.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstado.BindearPropiedadEntidad = "Estado.IdEstado"
      Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstado.FormattingEnabled = True
      Me.cmbEstado.IsPK = False
      Me.cmbEstado.IsRequired = False
      Me.cmbEstado.Key = Nothing
      Me.cmbEstado.LabelAsoc = Me.lblEstadoNuevo
      Me.cmbEstado.Location = New System.Drawing.Point(12, 90)
      Me.cmbEstado.Name = "cmbEstado"
      Me.cmbEstado.Size = New System.Drawing.Size(187, 21)
      Me.cmbEstado.TabIndex = 0
      '
      'lblEstadoNuevo
      '
      Me.lblEstadoNuevo.AutoSize = True
      Me.lblEstadoNuevo.Location = New System.Drawing.Point(9, 74)
      Me.lblEstadoNuevo.Name = "lblEstadoNuevo"
      Me.lblEstadoNuevo.Size = New System.Drawing.Size(40, 13)
      Me.lblEstadoNuevo.TabIndex = 6
      Me.lblEstadoNuevo.Text = "Estado"
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.Location = New System.Drawing.Point(312, 74)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 8
      Me.lblFecha.Text = "Fecha"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = "Value"
      Me.dtpFecha.BindearPropiedadEntidad = "FechaEstado"
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(291, 91)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(83, 20)
      Me.dtpFecha.TabIndex = 1
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = "Text"
      Me.txtObservacion.BindearPropiedadEntidad = "Observacion"
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Me.lblObservacion
      Me.txtObservacion.Location = New System.Drawing.Point(12, 130)
      Me.txtObservacion.MaxLength = 1000
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(364, 123)
      Me.txtObservacion.TabIndex = 2
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.Location = New System.Drawing.Point(9, 114)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 7
      Me.lblObservacion.Text = "Observación"
      '
      'CambiarEstadoProductosF
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(385, 296)
      Me.Controls.Add(Me.txtObservacion)
      Me.Controls.Add(Me.lblObservacion)
      Me.Controls.Add(Me.lblFecha)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.cmbEstado)
      Me.Controls.Add(Me.lblEstadoNuevo)
      Me.Controls.Add(Me.grbProducto)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CambiarEstadoProductosF"
      Me.Text = "Cambiar Estado"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.grbProducto, 0)
      Me.Controls.SetChildIndex(Me.lblEstadoNuevo, 0)
      Me.Controls.SetChildIndex(Me.cmbEstado, 0)
      Me.Controls.SetChildIndex(Me.dtpFecha, 0)
      Me.Controls.SetChildIndex(Me.lblFecha, 0)
      Me.Controls.SetChildIndex(Me.lblObservacion, 0)
      Me.Controls.SetChildIndex(Me.txtObservacion, 0)
      Me.grbProducto.ResumeLayout(False)
      Me.grbProducto.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbProducto As System.Windows.Forms.GroupBox
   Friend WithEvents lblCodigoProducto As Eniac.Controles.Label
   Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
   Friend WithEvents lblNombreProducto As Eniac.Controles.Label
   Friend WithEvents txtCodigoProducto As Eniac.Controles.TextBox
   Friend WithEvents cmbEstado As Eniac.Controles.ComboBox
   Friend WithEvents lblEstadoNuevo As Eniac.Controles.Label
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
End Class
