<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrestarProductoF
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrestarProductoF))
      Me.grbProducto = New System.Windows.Forms.GroupBox()
      Me.lblCodigoProducto = New Eniac.Controles.Label()
      Me.txtNombreProducto = New Eniac.Controles.TextBox()
      Me.lblNombreProducto = New Eniac.Controles.Label()
      Me.txtCodigoProducto = New Eniac.Controles.TextBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
      Me.lblCodProducto = New Eniac.Controles.Label()
      Me.bscProducto = New Eniac.Controles.Buscador2()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.txtCantidadProductos = New Eniac.Controles.TextBox()
      Me.lblCantidadProductos = New Eniac.Controles.Label()
      Me.grbProducto.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(209, 290)
      Me.btnAceptar.TabIndex = 1
      '
      'btnCancelar
      '
      Me.btnCancelar.ImageIndex = -1
      Me.btnCancelar.ImageList = Nothing
      Me.btnCancelar.Location = New System.Drawing.Point(295, 290)
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
      Me.grbProducto.TabIndex = 3
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
      Me.txtCodigoProducto.Size = New System.Drawing.Size(74, 20)
      Me.txtCodigoProducto.TabIndex = 0
      Me.txtCodigoProducto.TabStop = False
      Me.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.bscCodigoProducto)
      Me.GroupBox1.Controls.Add(Me.lblCodProducto)
      Me.GroupBox1.Controls.Add(Me.bscProducto)
      Me.GroupBox1.Controls.Add(Me.lblProducto)
      Me.GroupBox1.Controls.Add(Me.txtObservacion)
      Me.GroupBox1.Controls.Add(Me.lblObservacion)
      Me.GroupBox1.Controls.Add(Me.txtCantidadProductos)
      Me.GroupBox1.Controls.Add(Me.lblCantidadProductos)
      Me.GroupBox1.Location = New System.Drawing.Point(10, 77)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(362, 207)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Producto a prestar"
      '
      'bscCodigoProducto
      '
      Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto.BindearPropiedadControl = "Text"
      Me.bscCodigoProducto.BindearPropiedadEntidad = "ProductoPrestado.IdProducto"
      Me.bscCodigoProducto.ColumnasCondiciones = CType(resources.GetObject("bscCodigoProducto.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoProducto.ColumnasVisibles = CType(resources.GetObject("bscCodigoProducto.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCodigoProducto.Datos = Nothing
      Me.bscCodigoProducto.FilaDevuelta = Nothing
      Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto.IsDecimal = False
      Me.bscCodigoProducto.IsNumber = False
      Me.bscCodigoProducto.IsPK = False
      Me.bscCodigoProducto.IsRequired = True
      Me.bscCodigoProducto.Key = ""
      Me.bscCodigoProducto.LabelAsoc = Me.lblCodProducto
      Me.bscCodigoProducto.Location = New System.Drawing.Point(11, 34)
      Me.bscCodigoProducto.MaxLengh = "32767"
      Me.bscCodigoProducto.Name = "bscCodigoProducto"
      Me.bscCodigoProducto.Permitido = True
      Me.bscCodigoProducto.Selecciono = False
      Me.bscCodigoProducto.Size = New System.Drawing.Size(97, 20)
      Me.bscCodigoProducto.TabIndex = 0
      '
      'lblCodProducto
      '
      Me.lblCodProducto.AutoSize = True
      Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCodProducto.Location = New System.Drawing.Point(11, 18)
      Me.lblCodProducto.Name = "lblCodProducto"
      Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
      Me.lblCodProducto.TabIndex = 4
      Me.lblCodProducto.Text = "Código"
      '
      'bscProducto
      '
      Me.bscProducto.ActivarFiltroEnGrilla = True
      Me.bscProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto.BindearPropiedadControl = "Text"
      Me.bscProducto.BindearPropiedadEntidad = "ProductoPrestado.NombreProducto"
      Me.bscProducto.ColumnasCondiciones = CType(resources.GetObject("bscProducto.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscProducto.ColumnasVisibles = CType(resources.GetObject("bscProducto.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscProducto.Datos = Nothing
      Me.bscProducto.FilaDevuelta = Nothing
      Me.bscProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto.IsDecimal = False
      Me.bscProducto.IsNumber = False
      Me.bscProducto.IsPK = False
      Me.bscProducto.IsRequired = True
      Me.bscProducto.Key = ""
      Me.bscProducto.LabelAsoc = Me.lblProducto
      Me.bscProducto.Location = New System.Drawing.Point(114, 33)
      Me.bscProducto.MaxLengh = "32767"
      Me.bscProducto.Name = "bscProducto"
      Me.bscProducto.Permitido = True
      Me.bscProducto.Selecciono = False
      Me.bscProducto.Size = New System.Drawing.Size(239, 20)
      Me.bscProducto.TabIndex = 1
      '
      'lblProducto
      '
      Me.lblProducto.AutoSize = True
      Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblProducto.Location = New System.Drawing.Point(114, 17)
      Me.lblProducto.Name = "lblProducto"
      Me.lblProducto.Size = New System.Drawing.Size(50, 13)
      Me.lblProducto.TabIndex = 5
      Me.lblProducto.Text = "Producto"
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = "Text"
      Me.txtObservacion.BindearPropiedadEntidad = "ObservacionPrestamo"
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Me.lblObservacion
      Me.txtObservacion.Location = New System.Drawing.Point(11, 114)
      Me.txtObservacion.MaxLength = 300
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(345, 87)
      Me.txtObservacion.TabIndex = 3
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.Location = New System.Drawing.Point(8, 98)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(114, 13)
      Me.lblObservacion.TabIndex = 7
      Me.lblObservacion.Text = "Observación Prestamo"
      '
      'txtCantidadProductos
      '
      Me.txtCantidadProductos.BindearPropiedadControl = "Text"
      Me.txtCantidadProductos.BindearPropiedadEntidad = "CantidadPrestada"
      Me.txtCantidadProductos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadProductos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadProductos.Formato = ""
      Me.txtCantidadProductos.IsDecimal = True
      Me.txtCantidadProductos.IsNumber = True
      Me.txtCantidadProductos.IsPK = False
      Me.txtCantidadProductos.IsRequired = False
      Me.txtCantidadProductos.Key = ""
      Me.txtCantidadProductos.LabelAsoc = Me.lblCantidadProductos
      Me.txtCantidadProductos.Location = New System.Drawing.Point(11, 73)
      Me.txtCantidadProductos.Name = "txtCantidadProductos"
      Me.txtCantidadProductos.Size = New System.Drawing.Size(70, 20)
      Me.txtCantidadProductos.TabIndex = 2
      Me.txtCantidadProductos.Text = "0"
      Me.txtCantidadProductos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCantidadProductos
      '
      Me.lblCantidadProductos.AutoSize = True
      Me.lblCantidadProductos.Location = New System.Drawing.Point(8, 57)
      Me.lblCantidadProductos.Name = "lblCantidadProductos"
      Me.lblCantidadProductos.Size = New System.Drawing.Size(114, 13)
      Me.lblCantidadProductos.TabIndex = 6
      Me.lblCantidadProductos.Text = "Cantidad de productos"
      '
      'PrestarProductoF
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(384, 325)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.grbProducto)
      Me.Name = "PrestarProductoF"
      Me.Text = "Prestar Producto"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.grbProducto, 0)
      Me.Controls.SetChildIndex(Me.GroupBox1, 0)
      Me.grbProducto.ResumeLayout(False)
      Me.grbProducto.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents grbProducto As System.Windows.Forms.GroupBox
   Friend WithEvents lblCodigoProducto As Eniac.Controles.Label
   Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
   Friend WithEvents lblNombreProducto As Eniac.Controles.Label
   Friend WithEvents txtCodigoProducto As Eniac.Controles.TextBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents txtCantidadProductos As Eniac.Controles.TextBox
   Friend WithEvents lblCantidadProductos As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents bscCodigoProducto As Eniac.Controles.Buscador2
   Friend WithEvents lblCodProducto As Eniac.Controles.Label
   Friend WithEvents bscProducto As Eniac.Controles.Buscador2
   Friend WithEvents lblProducto As Eniac.Controles.Label
End Class
