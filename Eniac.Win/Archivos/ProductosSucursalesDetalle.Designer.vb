<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosSucursalesDetalle
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
      Me.lblIdSucursal = New Eniac.Controles.Label()
      Me.txtPrecioVenta = New Eniac.Controles.TextBox()
      Me.lblPrecioVenta = New Eniac.Controles.Label()
      Me.txtPrecioCosto = New Eniac.Controles.TextBox()
      Me.lblPrecioCosto = New Eniac.Controles.Label()
      Me.cmbSucursal = New Eniac.Controles.ComboBox()
      Me.txtPuntoDePedido = New Eniac.Controles.TextBox()
      Me.lblPuntoDePedido = New Eniac.Controles.Label()
      Me.txtStockMinimo = New Eniac.Controles.TextBox()
      Me.lblStockMinimo = New Eniac.Controles.Label()
      Me.txtStockActual = New Eniac.Controles.TextBox()
      Me.lblStockActual = New Eniac.Controles.Label()
      Me.lblNombreProducto = New Eniac.Controles.Label()
      Me.txtNombreProducto = New Eniac.Controles.TextBox()
      Me.lblIdProducto = New Eniac.Controles.Label()
      Me.txtIdProducto = New Eniac.Controles.TextBox()
      Me.txtRubroNombre = New Eniac.Controles.TextBox()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.txtMarcaNombre = New Eniac.Controles.TextBox()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.txtRubroCodigo = New Eniac.Controles.TextBox()
      Me.txtMarcaCodigo = New Eniac.Controles.TextBox()
      Me.txtStockMaximo = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(362, 219)
      Me.btnAceptar.TabIndex = 12
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(448, 219)
      Me.btnCancelar.TabIndex = 13
      '
      'lblIdSucursal
      '
      Me.lblIdSucursal.AutoSize = True
      Me.lblIdSucursal.Location = New System.Drawing.Point(6, 10)
      Me.lblIdSucursal.Name = "lblIdSucursal"
      Me.lblIdSucursal.Size = New System.Drawing.Size(48, 13)
      Me.lblIdSucursal.TabIndex = 14
      Me.lblIdSucursal.Text = "Sucursal"
      '
      'txtPrecioVenta
      '
      Me.txtPrecioVenta.BindearPropiedadControl = ""
      Me.txtPrecioVenta.BindearPropiedadEntidad = ""
      Me.txtPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrecioVenta.Formato = "##0.00"
      Me.txtPrecioVenta.IsDecimal = True
      Me.txtPrecioVenta.IsNumber = True
      Me.txtPrecioVenta.IsPK = True
      Me.txtPrecioVenta.IsRequired = False
      Me.txtPrecioVenta.Key = ""
      Me.txtPrecioVenta.LabelAsoc = Me.lblPrecioVenta
      Me.txtPrecioVenta.Location = New System.Drawing.Point(269, 151)
      Me.txtPrecioVenta.MaxLength = 13
      Me.txtPrecioVenta.Name = "txtPrecioVenta"
      Me.txtPrecioVenta.Size = New System.Drawing.Size(84, 20)
      Me.txtPrecioVenta.TabIndex = 3
      Me.txtPrecioVenta.Text = "0.00"
      Me.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPrecioVenta
      '
      Me.lblPrecioVenta.AutoSize = True
      Me.lblPrecioVenta.Location = New System.Drawing.Point(194, 155)
      Me.lblPrecioVenta.Name = "lblPrecioVenta"
      Me.lblPrecioVenta.Size = New System.Drawing.Size(68, 13)
      Me.lblPrecioVenta.TabIndex = 2
      Me.lblPrecioVenta.Text = "Precio Venta"
      '
      'txtPrecioCosto
      '
      Me.txtPrecioCosto.BindearPropiedadControl = "Text"
      Me.txtPrecioCosto.BindearPropiedadEntidad = "PrecioCosto"
      Me.txtPrecioCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrecioCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrecioCosto.Formato = "##0.00"
      Me.txtPrecioCosto.IsDecimal = True
      Me.txtPrecioCosto.IsNumber = True
      Me.txtPrecioCosto.IsPK = True
      Me.txtPrecioCosto.IsRequired = False
      Me.txtPrecioCosto.Key = ""
      Me.txtPrecioCosto.LabelAsoc = Me.lblPrecioCosto
      Me.txtPrecioCosto.Location = New System.Drawing.Point(95, 151)
      Me.txtPrecioCosto.MaxLength = 13
      Me.txtPrecioCosto.Name = "txtPrecioCosto"
      Me.txtPrecioCosto.Size = New System.Drawing.Size(84, 20)
      Me.txtPrecioCosto.TabIndex = 1
      Me.txtPrecioCosto.Text = "0.00"
      Me.txtPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPrecioCosto
      '
      Me.lblPrecioCosto.AutoSize = True
      Me.lblPrecioCosto.Location = New System.Drawing.Point(6, 155)
      Me.lblPrecioCosto.Name = "lblPrecioCosto"
      Me.lblPrecioCosto.Size = New System.Drawing.Size(67, 13)
      Me.lblPrecioCosto.TabIndex = 0
      Me.lblPrecioCosto.Text = "Precio Costo"
      '
      'cmbSucursal
      '
      Me.cmbSucursal.BindearPropiedadControl = "SelectedValue"
      Me.cmbSucursal.BindearPropiedadEntidad = "Sucursal.Id"
      Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursal.FormattingEnabled = True
      Me.cmbSucursal.IsPK = True
      Me.cmbSucursal.IsRequired = True
      Me.cmbSucursal.Key = Nothing
      Me.cmbSucursal.LabelAsoc = Me.lblIdSucursal
      Me.cmbSucursal.Location = New System.Drawing.Point(95, 6)
      Me.cmbSucursal.Name = "cmbSucursal"
      Me.cmbSucursal.Size = New System.Drawing.Size(167, 21)
      Me.cmbSucursal.TabIndex = 15
      Me.cmbSucursal.TabStop = False
      '
      'txtPuntoDePedido
      '
      Me.txtPuntoDePedido.BindearPropiedadControl = "Text"
      Me.txtPuntoDePedido.BindearPropiedadEntidad = "PuntoDePedido"
      Me.txtPuntoDePedido.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPuntoDePedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPuntoDePedido.Formato = "##0.00"
      Me.txtPuntoDePedido.IsDecimal = True
      Me.txtPuntoDePedido.IsNumber = True
      Me.txtPuntoDePedido.IsPK = False
      Me.txtPuntoDePedido.IsRequired = False
      Me.txtPuntoDePedido.Key = ""
      Me.txtPuntoDePedido.LabelAsoc = Me.lblPuntoDePedido
      Me.txtPuntoDePedido.Location = New System.Drawing.Point(95, 182)
      Me.txtPuntoDePedido.MaxLength = 13
      Me.txtPuntoDePedido.Name = "txtPuntoDePedido"
      Me.txtPuntoDePedido.Size = New System.Drawing.Size(84, 20)
      Me.txtPuntoDePedido.TabIndex = 5
      Me.txtPuntoDePedido.Text = "0.00"
      Me.txtPuntoDePedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPuntoDePedido
      '
      Me.lblPuntoDePedido.AutoSize = True
      Me.lblPuntoDePedido.Location = New System.Drawing.Point(6, 186)
      Me.lblPuntoDePedido.Name = "lblPuntoDePedido"
      Me.lblPuntoDePedido.Size = New System.Drawing.Size(86, 13)
      Me.lblPuntoDePedido.TabIndex = 4
      Me.lblPuntoDePedido.Text = "Punto de Pedido"
      '
      'txtStockMinimo
      '
      Me.txtStockMinimo.BindearPropiedadControl = "Text"
      Me.txtStockMinimo.BindearPropiedadEntidad = "StockMinimo"
      Me.txtStockMinimo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtStockMinimo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtStockMinimo.Formato = "##0.00"
      Me.txtStockMinimo.IsDecimal = True
      Me.txtStockMinimo.IsNumber = True
      Me.txtStockMinimo.IsPK = False
      Me.txtStockMinimo.IsRequired = False
      Me.txtStockMinimo.Key = ""
      Me.txtStockMinimo.LabelAsoc = Me.lblStockMinimo
      Me.txtStockMinimo.Location = New System.Drawing.Point(269, 182)
      Me.txtStockMinimo.MaxLength = 13
      Me.txtStockMinimo.Name = "txtStockMinimo"
      Me.txtStockMinimo.Size = New System.Drawing.Size(84, 20)
      Me.txtStockMinimo.TabIndex = 7
      Me.txtStockMinimo.Text = "0.00"
      Me.txtStockMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblStockMinimo
      '
      Me.lblStockMinimo.AutoSize = True
      Me.lblStockMinimo.Location = New System.Drawing.Point(194, 186)
      Me.lblStockMinimo.Name = "lblStockMinimo"
      Me.lblStockMinimo.Size = New System.Drawing.Size(71, 13)
      Me.lblStockMinimo.TabIndex = 6
      Me.lblStockMinimo.Text = "Stock Minimo"
      '
      'txtStockActual
      '
      Me.txtStockActual.BindearPropiedadControl = "Text"
      Me.txtStockActual.BindearPropiedadEntidad = "Stock"
      Me.txtStockActual.ForeColorFocus = System.Drawing.Color.Red
      Me.txtStockActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtStockActual.Formato = "##0.00"
      Me.txtStockActual.IsDecimal = True
      Me.txtStockActual.IsNumber = True
      Me.txtStockActual.IsPK = False
      Me.txtStockActual.IsRequired = False
      Me.txtStockActual.Key = ""
      Me.txtStockActual.LabelAsoc = Me.lblStockActual
      Me.txtStockActual.Location = New System.Drawing.Point(442, 182)
      Me.txtStockActual.MaxLength = 13
      Me.txtStockActual.Name = "txtStockActual"
      Me.txtStockActual.ReadOnly = True
      Me.txtStockActual.Size = New System.Drawing.Size(84, 20)
      Me.txtStockActual.TabIndex = 9
      Me.txtStockActual.TabStop = False
      Me.txtStockActual.Text = "0.00"
      Me.txtStockActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblStockActual
      '
      Me.lblStockActual.AutoSize = True
      Me.lblStockActual.Location = New System.Drawing.Point(369, 186)
      Me.lblStockActual.Name = "lblStockActual"
      Me.lblStockActual.Size = New System.Drawing.Size(68, 13)
      Me.lblStockActual.TabIndex = 8
      Me.lblStockActual.Text = "Stock Actual"
      '
      'lblNombreProducto
      '
      Me.lblNombreProducto.AutoSize = True
      Me.lblNombreProducto.Location = New System.Drawing.Point(6, 65)
      Me.lblNombreProducto.Name = "lblNombreProducto"
      Me.lblNombreProducto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProducto.TabIndex = 18
      Me.lblNombreProducto.Text = "Nombre"
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
      Me.txtNombreProducto.Location = New System.Drawing.Point(95, 61)
      Me.txtNombreProducto.MaxLength = 60
      Me.txtNombreProducto.Name = "txtNombreProducto"
      Me.txtNombreProducto.ReadOnly = True
      Me.txtNombreProducto.Size = New System.Drawing.Size(422, 20)
      Me.txtNombreProducto.TabIndex = 19
      Me.txtNombreProducto.TabStop = False
      '
      'lblIdProducto
      '
      Me.lblIdProducto.AutoSize = True
      Me.lblIdProducto.Location = New System.Drawing.Point(6, 38)
      Me.lblIdProducto.Name = "lblIdProducto"
      Me.lblIdProducto.Size = New System.Drawing.Size(50, 13)
      Me.lblIdProducto.TabIndex = 16
      Me.lblIdProducto.Text = "Producto"
      '
      'txtIdProducto
      '
      Me.txtIdProducto.BindearPropiedadControl = "Text"
      Me.txtIdProducto.BindearPropiedadEntidad = "Producto.IdProducto"
      Me.txtIdProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProducto.Formato = ""
      Me.txtIdProducto.IsDecimal = False
      Me.txtIdProducto.IsNumber = False
      Me.txtIdProducto.IsPK = False
      Me.txtIdProducto.IsRequired = False
      Me.txtIdProducto.Key = ""
      Me.txtIdProducto.LabelAsoc = Me.lblIdProducto
      Me.txtIdProducto.Location = New System.Drawing.Point(95, 34)
      Me.txtIdProducto.MaxLength = 15
      Me.txtIdProducto.Name = "txtIdProducto"
      Me.txtIdProducto.ReadOnly = True
      Me.txtIdProducto.Size = New System.Drawing.Size(151, 20)
      Me.txtIdProducto.TabIndex = 17
      Me.txtIdProducto.TabStop = False
      '
      'txtRubroNombre
      '
      Me.txtRubroNombre.BindearPropiedadControl = ""
      Me.txtRubroNombre.BindearPropiedadEntidad = ""
      Me.txtRubroNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRubroNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRubroNombre.Formato = "##0"
      Me.txtRubroNombre.IsDecimal = False
      Me.txtRubroNombre.IsNumber = False
      Me.txtRubroNombre.IsPK = False
      Me.txtRubroNombre.IsRequired = False
      Me.txtRubroNombre.Key = ""
      Me.txtRubroNombre.LabelAsoc = Me.lblRubro
      Me.txtRubroNombre.Location = New System.Drawing.Point(174, 119)
      Me.txtRubroNombre.MaxLength = 13
      Me.txtRubroNombre.Name = "txtRubroNombre"
      Me.txtRubroNombre.ReadOnly = True
      Me.txtRubroNombre.Size = New System.Drawing.Size(266, 20)
      Me.txtRubroNombre.TabIndex = 25
      Me.txtRubroNombre.TabStop = False
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.Location = New System.Drawing.Point(6, 123)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(36, 13)
      Me.lblRubro.TabIndex = 23
      Me.lblRubro.Text = "Rubro"
      '
      'txtMarcaNombre
      '
      Me.txtMarcaNombre.BindearPropiedadControl = ""
      Me.txtMarcaNombre.BindearPropiedadEntidad = ""
      Me.txtMarcaNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMarcaNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMarcaNombre.Formato = "##0"
      Me.txtMarcaNombre.IsDecimal = False
      Me.txtMarcaNombre.IsNumber = False
      Me.txtMarcaNombre.IsPK = False
      Me.txtMarcaNombre.IsRequired = False
      Me.txtMarcaNombre.Key = ""
      Me.txtMarcaNombre.LabelAsoc = Me.lblMarca
      Me.txtMarcaNombre.Location = New System.Drawing.Point(174, 89)
      Me.txtMarcaNombre.MaxLength = 13
      Me.txtMarcaNombre.Name = "txtMarcaNombre"
      Me.txtMarcaNombre.ReadOnly = True
      Me.txtMarcaNombre.Size = New System.Drawing.Size(266, 20)
      Me.txtMarcaNombre.TabIndex = 22
      Me.txtMarcaNombre.TabStop = False
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.Location = New System.Drawing.Point(6, 93)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(37, 13)
      Me.lblMarca.TabIndex = 20
      Me.lblMarca.Text = "Marca"
      '
      'txtRubroCodigo
      '
      Me.txtRubroCodigo.BindearPropiedadControl = "Text"
      Me.txtRubroCodigo.BindearPropiedadEntidad = "Producto.IdRubro"
      Me.txtRubroCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRubroCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRubroCodigo.Formato = "##0"
      Me.txtRubroCodigo.IsDecimal = False
      Me.txtRubroCodigo.IsNumber = True
      Me.txtRubroCodigo.IsPK = False
      Me.txtRubroCodigo.IsRequired = False
      Me.txtRubroCodigo.Key = ""
      Me.txtRubroCodigo.LabelAsoc = Me.lblRubro
      Me.txtRubroCodigo.Location = New System.Drawing.Point(95, 119)
      Me.txtRubroCodigo.MaxLength = 13
      Me.txtRubroCodigo.Name = "txtRubroCodigo"
      Me.txtRubroCodigo.ReadOnly = True
      Me.txtRubroCodigo.Size = New System.Drawing.Size(72, 20)
      Me.txtRubroCodigo.TabIndex = 24
      Me.txtRubroCodigo.TabStop = False
      Me.txtRubroCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtMarcaCodigo
      '
      Me.txtMarcaCodigo.BindearPropiedadControl = "Text"
      Me.txtMarcaCodigo.BindearPropiedadEntidad = "Producto.IdMarca"
      Me.txtMarcaCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMarcaCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMarcaCodigo.Formato = "##0"
      Me.txtMarcaCodigo.IsDecimal = False
      Me.txtMarcaCodigo.IsNumber = True
      Me.txtMarcaCodigo.IsPK = False
      Me.txtMarcaCodigo.IsRequired = False
      Me.txtMarcaCodigo.Key = ""
      Me.txtMarcaCodigo.LabelAsoc = Me.lblMarca
      Me.txtMarcaCodigo.Location = New System.Drawing.Point(95, 89)
      Me.txtMarcaCodigo.MaxLength = 13
      Me.txtMarcaCodigo.Name = "txtMarcaCodigo"
      Me.txtMarcaCodigo.ReadOnly = True
      Me.txtMarcaCodigo.Size = New System.Drawing.Size(72, 20)
      Me.txtMarcaCodigo.TabIndex = 21
      Me.txtMarcaCodigo.TabStop = False
      Me.txtMarcaCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtStockMaximo
      '
      Me.txtStockMaximo.BindearPropiedadControl = "Text"
      Me.txtStockMaximo.BindearPropiedadEntidad = "StockMaximo"
      Me.txtStockMaximo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtStockMaximo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtStockMaximo.Formato = "##0.00"
      Me.txtStockMaximo.IsDecimal = True
      Me.txtStockMaximo.IsNumber = True
      Me.txtStockMaximo.IsPK = False
      Me.txtStockMaximo.IsRequired = False
      Me.txtStockMaximo.Key = ""
      Me.txtStockMaximo.LabelAsoc = Me.Label1
      Me.txtStockMaximo.Location = New System.Drawing.Point(269, 214)
      Me.txtStockMaximo.MaxLength = 13
      Me.txtStockMaximo.Name = "txtStockMaximo"
      Me.txtStockMaximo.Size = New System.Drawing.Size(84, 20)
      Me.txtStockMaximo.TabIndex = 11
      Me.txtStockMaximo.Text = "0.00"
      Me.txtStockMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(194, 218)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(74, 13)
      Me.Label1.TabIndex = 10
      Me.Label1.Text = "Stock Maximo"
      '
      'ProductosSucursalesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(537, 254)
      Me.Controls.Add(Me.txtStockMaximo)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtRubroNombre)
      Me.Controls.Add(Me.txtMarcaNombre)
      Me.Controls.Add(Me.txtRubroCodigo)
      Me.Controls.Add(Me.txtMarcaCodigo)
      Me.Controls.Add(Me.lblRubro)
      Me.Controls.Add(Me.lblMarca)
      Me.Controls.Add(Me.lblNombreProducto)
      Me.Controls.Add(Me.txtNombreProducto)
      Me.Controls.Add(Me.lblIdProducto)
      Me.Controls.Add(Me.txtIdProducto)
      Me.Controls.Add(Me.txtStockActual)
      Me.Controls.Add(Me.lblStockActual)
      Me.Controls.Add(Me.txtPuntoDePedido)
      Me.Controls.Add(Me.lblPuntoDePedido)
      Me.Controls.Add(Me.txtStockMinimo)
      Me.Controls.Add(Me.lblStockMinimo)
      Me.Controls.Add(Me.lblIdSucursal)
      Me.Controls.Add(Me.txtPrecioVenta)
      Me.Controls.Add(Me.lblPrecioVenta)
      Me.Controls.Add(Me.txtPrecioCosto)
      Me.Controls.Add(Me.lblPrecioCosto)
      Me.Controls.Add(Me.cmbSucursal)
      Me.Name = "ProductosSucursalesDetalle"
      Me.Text = "Productos por Sucursal"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.cmbSucursal, 0)
      Me.Controls.SetChildIndex(Me.lblPrecioCosto, 0)
      Me.Controls.SetChildIndex(Me.txtPrecioCosto, 0)
      Me.Controls.SetChildIndex(Me.lblPrecioVenta, 0)
      Me.Controls.SetChildIndex(Me.txtPrecioVenta, 0)
      Me.Controls.SetChildIndex(Me.lblIdSucursal, 0)
      Me.Controls.SetChildIndex(Me.lblStockMinimo, 0)
      Me.Controls.SetChildIndex(Me.txtStockMinimo, 0)
      Me.Controls.SetChildIndex(Me.lblPuntoDePedido, 0)
      Me.Controls.SetChildIndex(Me.txtPuntoDePedido, 0)
      Me.Controls.SetChildIndex(Me.lblStockActual, 0)
      Me.Controls.SetChildIndex(Me.txtStockActual, 0)
      Me.Controls.SetChildIndex(Me.txtIdProducto, 0)
      Me.Controls.SetChildIndex(Me.lblIdProducto, 0)
      Me.Controls.SetChildIndex(Me.txtNombreProducto, 0)
      Me.Controls.SetChildIndex(Me.lblNombreProducto, 0)
      Me.Controls.SetChildIndex(Me.lblMarca, 0)
      Me.Controls.SetChildIndex(Me.lblRubro, 0)
      Me.Controls.SetChildIndex(Me.txtMarcaCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtRubroCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtMarcaNombre, 0)
      Me.Controls.SetChildIndex(Me.txtRubroNombre, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtStockMaximo, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblIdSucursal As Eniac.Controles.Label
   Friend WithEvents txtPrecioVenta As Eniac.Controles.TextBox
   Friend WithEvents lblPrecioVenta As Eniac.Controles.Label
   Friend WithEvents txtPrecioCosto As Eniac.Controles.TextBox
   Friend WithEvents lblPrecioCosto As Eniac.Controles.Label
   Friend WithEvents cmbSucursal As Eniac.Controles.ComboBox
   Friend WithEvents txtPuntoDePedido As Eniac.Controles.TextBox
   Friend WithEvents lblPuntoDePedido As Eniac.Controles.Label
   Friend WithEvents txtStockMinimo As Eniac.Controles.TextBox
   Friend WithEvents lblStockMinimo As Eniac.Controles.Label
   Friend WithEvents txtStockActual As Eniac.Controles.TextBox
   Friend WithEvents lblStockActual As Eniac.Controles.Label
   Friend WithEvents lblNombreProducto As Eniac.Controles.Label
   Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
   Friend WithEvents lblIdProducto As Eniac.Controles.Label
   Friend WithEvents txtIdProducto As Eniac.Controles.TextBox
   Friend WithEvents txtRubroNombre As Eniac.Controles.TextBox
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents txtMarcaNombre As Eniac.Controles.TextBox
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents txtRubroCodigo As Eniac.Controles.TextBox
    Friend WithEvents txtMarcaCodigo As Eniac.Controles.TextBox
    Friend WithEvents txtStockMaximo As Eniac.Controles.TextBox
    Friend WithEvents Label1 As Eniac.Controles.Label

End Class
