<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnviarProductoF
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnviarProductoF))
      Me.grbProducto = New System.Windows.Forms.GroupBox
      Me.lblCodigoProducto = New Eniac.Controles.Label
      Me.txtNombreProducto = New Eniac.Controles.TextBox
      Me.lblNombreProducto = New Eniac.Controles.Label
      Me.txtCodigoProducto = New Eniac.Controles.TextBox
      Me.lblProveedor = New Eniac.Controles.Label
      Me.bscProveedor = New Eniac.Controles.Buscador
      Me.txtObservacion = New Eniac.Controles.TextBox
      Me.lblObservacion = New Eniac.Controles.Label
      Me.lblFechaEnvio = New Eniac.Controles.Label
      Me.dtpFecha = New Eniac.Controles.DateTimePicker
      Me.grbProducto.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(205, 264)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(291, 264)
      Me.btnCancelar.TabIndex = 4
      '
      'grbProducto
      '
      Me.grbProducto.Controls.Add(Me.lblCodigoProducto)
      Me.grbProducto.Controls.Add(Me.txtNombreProducto)
      Me.grbProducto.Controls.Add(Me.txtCodigoProducto)
      Me.grbProducto.Controls.Add(Me.lblNombreProducto)
      Me.grbProducto.Location = New System.Drawing.Point(9, 12)
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
      'lblProveedor
      '
      Me.lblProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblProveedor.AutoSize = True
      Me.lblProveedor.Location = New System.Drawing.Point(6, 79)
      Me.lblProveedor.Name = "lblProveedor"
      Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
      Me.lblProveedor.TabIndex = 6
      Me.lblProveedor.Text = "Proveedor"
      '
      'bscProveedor
      '
      Me.bscProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProveedor.BindearPropiedadControl = ""
      Me.bscProveedor.BindearPropiedadEntidad = ""
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Me.lblProveedor
      Me.bscProveedor.Location = New System.Drawing.Point(9, 95)
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(276, 20)
      Me.bscProveedor.TabIndex = 0
      Me.bscProveedor.Titulo = Nothing
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
      Me.txtObservacion.Location = New System.Drawing.Point(12, 135)
      Me.txtObservacion.MaxLength = 150
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(364, 123)
      Me.txtObservacion.TabIndex = 2
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.Location = New System.Drawing.Point(9, 119)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 8
      Me.lblObservacion.Text = "Observación"
      '
      'lblFechaEnvio
      '
      Me.lblFechaEnvio.AutoSize = True
      Me.lblFechaEnvio.Location = New System.Drawing.Point(288, 79)
      Me.lblFechaEnvio.Name = "lblFechaEnvio"
      Me.lblFechaEnvio.Size = New System.Drawing.Size(68, 13)
      Me.lblFechaEnvio.TabIndex = 7
      Me.lblFechaEnvio.Text = "Fecha envío"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = "Value"
      Me.dtpFecha.BindearPropiedadEntidad = "FechaEntrega"
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFechaEnvio
      Me.dtpFecha.Location = New System.Drawing.Point(291, 96)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(83, 20)
      Me.dtpFecha.TabIndex = 1
      '
      'EnviarProducto
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(380, 299)
      Me.Controls.Add(Me.txtObservacion)
      Me.Controls.Add(Me.lblObservacion)
      Me.Controls.Add(Me.lblFechaEnvio)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.lblProveedor)
      Me.Controls.Add(Me.bscProveedor)
      Me.Controls.Add(Me.grbProducto)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "EnviarProducto"
      Me.Text = "Enviar Producto"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.grbProducto, 0)
      Me.Controls.SetChildIndex(Me.bscProveedor, 0)
      Me.Controls.SetChildIndex(Me.lblProveedor, 0)
      Me.Controls.SetChildIndex(Me.dtpFecha, 0)
      Me.Controls.SetChildIndex(Me.lblFechaEnvio, 0)
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
   Friend WithEvents lblProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents lblFechaEnvio As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
End Class
