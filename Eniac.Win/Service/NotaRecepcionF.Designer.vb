<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotaRecepcionF
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotaRecepcionF))
      Me.dtpFechaRecepcion = New Eniac.Controles.DateTimePicker()
      Me.lblFechaRecepcion = New Eniac.Controles.Label()
      Me.txtCodigoProducto = New Eniac.Controles.TextBox()
      Me.lblCodigoProducto = New Eniac.Controles.Label()
      Me.txtNombreProducto = New Eniac.Controles.TextBox()
      Me.lblNombreProducto = New Eniac.Controles.Label()
      Me.grbProducto = New System.Windows.Forms.GroupBox()
      Me.lblFechaCompra = New Eniac.Controles.Label()
      Me.dtpFechaCompra = New Eniac.Controles.DateTimePicker()
      Me.txtCostoReparacion = New Eniac.Controles.TextBox()
      Me.lblCostoReparacion = New Eniac.Controles.Label()
      Me.txtDefectoProducto = New Eniac.Controles.TextBox()
      Me.lblDefectoProducto = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.txtCantidadProductos = New Eniac.Controles.TextBox()
      Me.lblCantidadProductos = New Eniac.Controles.Label()
      Me.grbProducto.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(402, 252)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(488, 252)
      Me.btnCancelar.TabIndex = 7
      '
      'dtpFechaRecepcion
      '
      Me.dtpFechaRecepcion.BindearPropiedadControl = "Value"
      Me.dtpFechaRecepcion.BindearPropiedadEntidad = "FechaNota"
      Me.dtpFechaRecepcion.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaRecepcion.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaRecepcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaRecepcion.IsPK = False
      Me.dtpFechaRecepcion.IsRequired = False
      Me.dtpFechaRecepcion.Key = ""
      Me.dtpFechaRecepcion.LabelAsoc = Me.lblFechaRecepcion
      Me.dtpFechaRecepcion.Location = New System.Drawing.Point(11, 33)
      Me.dtpFechaRecepcion.Name = "dtpFechaRecepcion"
      Me.dtpFechaRecepcion.Size = New System.Drawing.Size(90, 20)
      Me.dtpFechaRecepcion.TabIndex = 0
      '
      'lblFechaRecepcion
      '
      Me.lblFechaRecepcion.AutoSize = True
      Me.lblFechaRecepcion.Location = New System.Drawing.Point(11, 17)
      Me.lblFechaRecepcion.Name = "lblFechaRecepcion"
      Me.lblFechaRecepcion.Size = New System.Drawing.Size(102, 13)
      Me.lblFechaRecepcion.TabIndex = 8
      Me.lblFechaRecepcion.Text = "Fecha de recepción"
      '
      'txtCodigoProducto
      '
      Me.txtCodigoProducto.BindearPropiedadControl = "Text"
      Me.txtCodigoProducto.BindearPropiedadEntidad = "Producto.IdProducto"
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
      Me.txtCodigoProducto.Size = New System.Drawing.Size(107, 20)
      Me.txtCodigoProducto.TabIndex = 0
      Me.txtCodigoProducto.TabStop = False
      Me.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.txtNombreProducto.BindearPropiedadEntidad = "Producto.NombreProducto"
      Me.txtNombreProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreProducto.Formato = ""
      Me.txtNombreProducto.IsDecimal = False
      Me.txtNombreProducto.IsNumber = False
      Me.txtNombreProducto.IsPK = False
      Me.txtNombreProducto.IsRequired = False
      Me.txtNombreProducto.Key = ""
      Me.txtNombreProducto.LabelAsoc = Me.lblNombreProducto
      Me.txtNombreProducto.Location = New System.Drawing.Point(121, 32)
      Me.txtNombreProducto.Name = "txtNombreProducto"
      Me.txtNombreProducto.ReadOnly = True
      Me.txtNombreProducto.Size = New System.Drawing.Size(317, 20)
      Me.txtNombreProducto.TabIndex = 1
      Me.txtNombreProducto.TabStop = False
      '
      'lblNombreProducto
      '
      Me.lblNombreProducto.AutoSize = True
      Me.lblNombreProducto.Location = New System.Drawing.Point(118, 16)
      Me.lblNombreProducto.Name = "lblNombreProducto"
      Me.lblNombreProducto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProducto.TabIndex = 3
      Me.lblNombreProducto.Text = "Nombre"
      '
      'grbProducto
      '
      Me.grbProducto.Controls.Add(Me.lblCodigoProducto)
      Me.grbProducto.Controls.Add(Me.txtNombreProducto)
      Me.grbProducto.Controls.Add(Me.txtCodigoProducto)
      Me.grbProducto.Controls.Add(Me.lblNombreProducto)
      Me.grbProducto.Location = New System.Drawing.Point(120, 17)
      Me.grbProducto.Name = "grbProducto"
      Me.grbProducto.Size = New System.Drawing.Size(448, 59)
      Me.grbProducto.TabIndex = 14
      Me.grbProducto.TabStop = False
      Me.grbProducto.Text = "Producto"
      '
      'lblFechaCompra
      '
      Me.lblFechaCompra.AutoSize = True
      Me.lblFechaCompra.Location = New System.Drawing.Point(11, 56)
      Me.lblFechaCompra.Name = "lblFechaCompra"
      Me.lblFechaCompra.Size = New System.Drawing.Size(90, 13)
      Me.lblFechaCompra.TabIndex = 9
      Me.lblFechaCompra.Text = "Fecha de compra"
      '
      'dtpFechaCompra
      '
      Me.dtpFechaCompra.BindearPropiedadControl = "Value"
      Me.dtpFechaCompra.BindearPropiedadEntidad = "Ficha.FechaOperacion"
      Me.dtpFechaCompra.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaCompra.Enabled = False
      Me.dtpFechaCompra.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaCompra.IsPK = False
      Me.dtpFechaCompra.IsRequired = False
      Me.dtpFechaCompra.Key = ""
      Me.dtpFechaCompra.LabelAsoc = Me.lblFechaCompra
      Me.dtpFechaCompra.Location = New System.Drawing.Point(11, 72)
      Me.dtpFechaCompra.Name = "dtpFechaCompra"
      Me.dtpFechaCompra.Size = New System.Drawing.Size(90, 20)
      Me.dtpFechaCompra.TabIndex = 1
      '
      'txtCostoReparacion
      '
      Me.txtCostoReparacion.BindearPropiedadControl = "Text"
      Me.txtCostoReparacion.BindearPropiedadEntidad = "CostoReparacion"
      Me.txtCostoReparacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCostoReparacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCostoReparacion.Formato = ""
      Me.txtCostoReparacion.IsDecimal = True
      Me.txtCostoReparacion.IsNumber = True
      Me.txtCostoReparacion.IsPK = False
      Me.txtCostoReparacion.IsRequired = False
      Me.txtCostoReparacion.Key = ""
      Me.txtCostoReparacion.LabelAsoc = Me.lblCostoReparacion
      Me.txtCostoReparacion.Location = New System.Drawing.Point(412, 95)
      Me.txtCostoReparacion.Name = "txtCostoReparacion"
      Me.txtCostoReparacion.Size = New System.Drawing.Size(70, 20)
      Me.txtCostoReparacion.TabIndex = 3
      Me.txtCostoReparacion.Text = "0.00"
      Me.txtCostoReparacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCostoReparacion
      '
      Me.lblCostoReparacion.AutoSize = True
      Me.lblCostoReparacion.Location = New System.Drawing.Point(369, 79)
      Me.lblCostoReparacion.Name = "lblCostoReparacion"
      Me.lblCostoReparacion.Size = New System.Drawing.Size(113, 13)
      Me.lblCostoReparacion.TabIndex = 12
      Me.lblCostoReparacion.Text = "Costo de la reparación"
      '
      'txtDefectoProducto
      '
      Me.txtDefectoProducto.BindearPropiedadControl = "Text"
      Me.txtDefectoProducto.BindearPropiedadEntidad = "DefectoProducto"
      Me.txtDefectoProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDefectoProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDefectoProducto.Formato = ""
      Me.txtDefectoProducto.IsDecimal = False
      Me.txtDefectoProducto.IsNumber = False
      Me.txtDefectoProducto.IsPK = False
      Me.txtDefectoProducto.IsRequired = True
      Me.txtDefectoProducto.Key = ""
      Me.txtDefectoProducto.LabelAsoc = Me.lblDefectoProducto
      Me.txtDefectoProducto.Location = New System.Drawing.Point(12, 121)
      Me.txtDefectoProducto.MaxLength = 1000
      Me.txtDefectoProducto.Multiline = True
      Me.txtDefectoProducto.Name = "txtDefectoProducto"
      Me.txtDefectoProducto.Size = New System.Drawing.Size(556, 49)
      Me.txtDefectoProducto.TabIndex = 4
      '
      'lblDefectoProducto
      '
      Me.lblDefectoProducto.AutoSize = True
      Me.lblDefectoProducto.Location = New System.Drawing.Point(9, 105)
      Me.lblDefectoProducto.Name = "lblDefectoProducto"
      Me.lblDefectoProducto.Size = New System.Drawing.Size(107, 13)
      Me.lblDefectoProducto.TabIndex = 10
      Me.lblDefectoProducto.Text = "Defecto del producto"
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
      Me.txtObservacion.IsRequired = True
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Me.lblObservacion
      Me.txtObservacion.Location = New System.Drawing.Point(15, 190)
      Me.txtObservacion.MaxLength = 1000
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(553, 55)
      Me.txtObservacion.TabIndex = 5
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.Location = New System.Drawing.Point(12, 174)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 13
      Me.lblObservacion.Text = "Observación"
      '
      'txtCantidadProductos
      '
      Me.txtCantidadProductos.BindearPropiedadControl = "Text"
      Me.txtCantidadProductos.BindearPropiedadEntidad = "CantidadProductos"
      Me.txtCantidadProductos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadProductos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadProductos.Formato = ""
      Me.txtCantidadProductos.IsDecimal = True
      Me.txtCantidadProductos.IsNumber = True
      Me.txtCantidadProductos.IsPK = False
      Me.txtCantidadProductos.IsRequired = False
      Me.txtCantidadProductos.Key = ""
      Me.txtCantidadProductos.LabelAsoc = Me.lblCantidadProductos
      Me.txtCantidadProductos.Location = New System.Drawing.Point(210, 95)
      Me.txtCantidadProductos.Name = "txtCantidadProductos"
      Me.txtCantidadProductos.Size = New System.Drawing.Size(70, 20)
      Me.txtCantidadProductos.TabIndex = 2
      Me.txtCantidadProductos.Text = "0"
      Me.txtCantidadProductos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCantidadProductos
      '
      Me.lblCantidadProductos.AutoSize = True
      Me.lblCantidadProductos.Location = New System.Drawing.Point(207, 79)
      Me.lblCantidadProductos.Name = "lblCantidadProductos"
      Me.lblCantidadProductos.Size = New System.Drawing.Size(114, 13)
      Me.lblCantidadProductos.TabIndex = 11
      Me.lblCantidadProductos.Text = "Cantidad de productos"
      '
      'NotaRecepcionF
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(581, 294)
      Me.Controls.Add(Me.txtCantidadProductos)
      Me.Controls.Add(Me.lblCantidadProductos)
      Me.Controls.Add(Me.txtObservacion)
      Me.Controls.Add(Me.lblObservacion)
      Me.Controls.Add(Me.txtDefectoProducto)
      Me.Controls.Add(Me.lblDefectoProducto)
      Me.Controls.Add(Me.txtCostoReparacion)
      Me.Controls.Add(Me.lblCostoReparacion)
      Me.Controls.Add(Me.lblFechaCompra)
      Me.Controls.Add(Me.dtpFechaCompra)
      Me.Controls.Add(Me.grbProducto)
      Me.Controls.Add(Me.lblFechaRecepcion)
      Me.Controls.Add(Me.dtpFechaRecepcion)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "NotaRecepcionF"
      Me.Text = "Nota de Recepción"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaRecepcion, 0)
      Me.Controls.SetChildIndex(Me.lblFechaRecepcion, 0)
      Me.Controls.SetChildIndex(Me.grbProducto, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaCompra, 0)
      Me.Controls.SetChildIndex(Me.lblFechaCompra, 0)
      Me.Controls.SetChildIndex(Me.lblCostoReparacion, 0)
      Me.Controls.SetChildIndex(Me.txtCostoReparacion, 0)
      Me.Controls.SetChildIndex(Me.lblDefectoProducto, 0)
      Me.Controls.SetChildIndex(Me.txtDefectoProducto, 0)
      Me.Controls.SetChildIndex(Me.lblObservacion, 0)
      Me.Controls.SetChildIndex(Me.txtObservacion, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblCantidadProductos, 0)
      Me.Controls.SetChildIndex(Me.txtCantidadProductos, 0)
      Me.grbProducto.ResumeLayout(False)
      Me.grbProducto.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dtpFechaRecepcion As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaRecepcion As Eniac.Controles.Label
   Friend WithEvents txtCodigoProducto As Eniac.Controles.TextBox
   Friend WithEvents lblCodigoProducto As Eniac.Controles.Label
   Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
   Friend WithEvents lblNombreProducto As Eniac.Controles.Label
   Friend WithEvents grbProducto As System.Windows.Forms.GroupBox
   Friend WithEvents lblFechaCompra As Eniac.Controles.Label
   Friend WithEvents dtpFechaCompra As Eniac.Controles.DateTimePicker
   Friend WithEvents txtCostoReparacion As Eniac.Controles.TextBox
   Friend WithEvents lblCostoReparacion As Eniac.Controles.Label
   Friend WithEvents txtDefectoProducto As Eniac.Controles.TextBox
   Friend WithEvents lblDefectoProducto As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents txtCantidadProductos As Eniac.Controles.TextBox
   Friend WithEvents lblCantidadProductos As Eniac.Controles.Label
End Class
