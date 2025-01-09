<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosLotesDetalle
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
      Me.txtIdLote = New Eniac.Controles.TextBox()
      Me.lblIdLote = New Eniac.Controles.Label()
      Me.cmbSucursal = New Eniac.Controles.ComboBox()
      Me.lblIdProducto = New Eniac.Controles.Label()
      Me.cmbProducto = New Eniac.Controles.ComboBox()
      Me.txtStock = New Eniac.Controles.TextBox()
      Me.lblStock = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(418, 330)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(504, 330)
      Me.btnCancelar.TabIndex = 7
      '
      'lblIdSucursal
      '
      Me.lblIdSucursal.AutoSize = True
      Me.lblIdSucursal.Location = New System.Drawing.Point(6, 152)
      Me.lblIdSucursal.Name = "lblIdSucursal"
      Me.lblIdSucursal.Size = New System.Drawing.Size(48, 13)
      Me.lblIdSucursal.TabIndex = 9
      Me.lblIdSucursal.Text = "Sucursal"
      '
      'txtPrecioVenta
      '
      Me.txtPrecioVenta.BindearPropiedadControl = "Text"
      Me.txtPrecioVenta.BindearPropiedadEntidad = "PrecioVenta"
      Me.txtPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrecioVenta.Formato = "##0.00"
      Me.txtPrecioVenta.IsDecimal = True
      Me.txtPrecioVenta.IsNumber = True
      Me.txtPrecioVenta.IsPK = False
      Me.txtPrecioVenta.IsRequired = False
      Me.txtPrecioVenta.Key = ""
      Me.txtPrecioVenta.LabelAsoc = Me.lblPrecioVenta
      Me.txtPrecioVenta.Location = New System.Drawing.Point(84, 211)
      Me.txtPrecioVenta.MaxLength = 13
      Me.txtPrecioVenta.Name = "txtPrecioVenta"
      Me.txtPrecioVenta.Size = New System.Drawing.Size(97, 20)
      Me.txtPrecioVenta.TabIndex = 4
      Me.txtPrecioVenta.Text = "0.00"
      Me.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPrecioVenta
      '
      Me.lblPrecioVenta.AutoSize = True
      Me.lblPrecioVenta.Location = New System.Drawing.Point(221, 28)
      Me.lblPrecioVenta.Name = "lblPrecioVenta"
      Me.lblPrecioVenta.Size = New System.Drawing.Size(68, 13)
      Me.lblPrecioVenta.TabIndex = 12
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
      Me.txtPrecioCosto.IsPK = False
      Me.txtPrecioCosto.IsRequired = False
      Me.txtPrecioCosto.Key = ""
      Me.txtPrecioCosto.LabelAsoc = Me.lblPrecioCosto
      Me.txtPrecioCosto.Location = New System.Drawing.Point(264, 174)
      Me.txtPrecioCosto.MaxLength = 13
      Me.txtPrecioCosto.Name = "txtPrecioCosto"
      Me.txtPrecioCosto.Size = New System.Drawing.Size(97, 20)
      Me.txtPrecioCosto.TabIndex = 3
      Me.txtPrecioCosto.Text = "0.00"
      Me.txtPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPrecioCosto
      '
      Me.lblPrecioCosto.AutoSize = True
      Me.lblPrecioCosto.Location = New System.Drawing.Point(192, 181)
      Me.lblPrecioCosto.Name = "lblPrecioCosto"
      Me.lblPrecioCosto.Size = New System.Drawing.Size(67, 13)
      Me.lblPrecioCosto.TabIndex = 11
      Me.lblPrecioCosto.Text = "Precio Costo"
      '
      'txtIdLote
      '
      Me.txtIdLote.BindearPropiedadControl = "Text"
      Me.txtIdLote.BindearPropiedadEntidad = "IdLote"
      Me.txtIdLote.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdLote.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdLote.Formato = ""
      Me.txtIdLote.IsDecimal = False
      Me.txtIdLote.IsNumber = False
      Me.txtIdLote.IsPK = False
      Me.txtIdLote.IsRequired = False
      Me.txtIdLote.Key = ""
      Me.txtIdLote.LabelAsoc = Me.lblIdLote
      Me.txtIdLote.Location = New System.Drawing.Point(64, 25)
      Me.txtIdLote.MaxLength = 30
      Me.txtIdLote.Name = "txtIdLote"
      Me.txtIdLote.Size = New System.Drawing.Size(141, 20)
      Me.txtIdLote.TabIndex = 2
      Me.txtIdLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdLote
      '
      Me.lblIdLote.AutoSize = True
      Me.lblIdLote.Location = New System.Drawing.Point(12, 28)
      Me.lblIdLote.Name = "lblIdLote"
      Me.lblIdLote.Size = New System.Drawing.Size(28, 13)
      Me.lblIdLote.TabIndex = 10
      Me.lblIdLote.Text = "Lote"
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
      Me.cmbSucursal.Location = New System.Drawing.Point(84, 144)
      Me.cmbSucursal.Name = "cmbSucursal"
      Me.cmbSucursal.Size = New System.Drawing.Size(151, 21)
      Me.cmbSucursal.TabIndex = 1
      '
      'lblIdProducto
      '
      Me.lblIdProducto.AutoSize = True
      Me.lblIdProducto.Location = New System.Drawing.Point(6, 125)
      Me.lblIdProducto.Name = "lblIdProducto"
      Me.lblIdProducto.Size = New System.Drawing.Size(50, 13)
      Me.lblIdProducto.TabIndex = 8
      Me.lblIdProducto.Text = "Producto"
      '
      'cmbProducto
      '
      Me.cmbProducto.BindearPropiedadControl = "SelectedValue"
      Me.cmbProducto.BindearPropiedadEntidad = "Producto.IdProducto"
      Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbProducto.FormattingEnabled = True
      Me.cmbProducto.IsPK = True
      Me.cmbProducto.IsRequired = True
      Me.cmbProducto.Key = Nothing
      Me.cmbProducto.LabelAsoc = Me.lblIdProducto
      Me.cmbProducto.Location = New System.Drawing.Point(85, 117)
      Me.cmbProducto.Name = "cmbProducto"
      Me.cmbProducto.Size = New System.Drawing.Size(276, 21)
      Me.cmbProducto.TabIndex = 0
      '
      'txtStock
      '
      Me.txtStock.BindearPropiedadControl = "Text"
      Me.txtStock.BindearPropiedadEntidad = "Stock"
      Me.txtStock.Enabled = False
      Me.txtStock.ForeColorFocus = System.Drawing.Color.Red
      Me.txtStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtStock.Formato = "##0.00"
      Me.txtStock.IsDecimal = True
      Me.txtStock.IsNumber = True
      Me.txtStock.IsPK = False
      Me.txtStock.IsRequired = False
      Me.txtStock.Key = ""
      Me.txtStock.LabelAsoc = Me.lblStock
      Me.txtStock.Location = New System.Drawing.Point(264, 211)
      Me.txtStock.MaxLength = 13
      Me.txtStock.Name = "txtStock"
      Me.txtStock.Size = New System.Drawing.Size(97, 20)
      Me.txtStock.TabIndex = 5
      Me.txtStock.Text = "0.00"
      Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblStock
      '
      Me.lblStock.AutoSize = True
      Me.lblStock.Location = New System.Drawing.Point(192, 218)
      Me.lblStock.Name = "lblStock"
      Me.lblStock.Size = New System.Drawing.Size(35, 13)
      Me.lblStock.TabIndex = 13
      Me.lblStock.Text = "Stock"
      '
      'ProductosLotesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(593, 365)
      Me.Controls.Add(Me.txtStock)
      Me.Controls.Add(Me.lblStock)
      Me.Controls.Add(Me.cmbProducto)
      Me.Controls.Add(Me.lblIdSucursal)
      Me.Controls.Add(Me.txtPrecioVenta)
      Me.Controls.Add(Me.lblPrecioVenta)
      Me.Controls.Add(Me.txtPrecioCosto)
      Me.Controls.Add(Me.lblPrecioCosto)
      Me.Controls.Add(Me.txtIdLote)
      Me.Controls.Add(Me.lblIdLote)
      Me.Controls.Add(Me.cmbSucursal)
      Me.Controls.Add(Me.lblIdProducto)
      Me.Name = "ProductosLotesDetalle"
      Me.Text = "Productos por Lote"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblIdProducto, 0)
      Me.Controls.SetChildIndex(Me.cmbSucursal, 0)
      Me.Controls.SetChildIndex(Me.lblIdLote, 0)
      Me.Controls.SetChildIndex(Me.txtIdLote, 0)
      Me.Controls.SetChildIndex(Me.lblPrecioCosto, 0)
      Me.Controls.SetChildIndex(Me.txtPrecioCosto, 0)
      Me.Controls.SetChildIndex(Me.lblPrecioVenta, 0)
      Me.Controls.SetChildIndex(Me.txtPrecioVenta, 0)
      Me.Controls.SetChildIndex(Me.lblIdSucursal, 0)
      Me.Controls.SetChildIndex(Me.cmbProducto, 0)
      Me.Controls.SetChildIndex(Me.lblStock, 0)
      Me.Controls.SetChildIndex(Me.txtStock, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblIdSucursal As Eniac.Controles.Label
   Friend WithEvents txtPrecioVenta As Eniac.Controles.TextBox
   Friend WithEvents lblPrecioVenta As Eniac.Controles.Label
   Friend WithEvents txtPrecioCosto As Eniac.Controles.TextBox
   Friend WithEvents lblPrecioCosto As Eniac.Controles.Label
   Friend WithEvents txtIdLote As Eniac.Controles.TextBox
   Friend WithEvents lblIdLote As Eniac.Controles.Label
   Friend WithEvents cmbSucursal As Eniac.Controles.ComboBox
   Friend WithEvents lblIdProducto As Eniac.Controles.Label
   Friend WithEvents cmbProducto As Eniac.Controles.ComboBox
   Friend WithEvents txtStock As Eniac.Controles.TextBox
   Friend WithEvents lblStock As Eniac.Controles.Label

End Class
