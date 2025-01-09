<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovimientosDeComprasParametros
   Inherits BaseForm

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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovimientosDeComprasParametros))
      Me.GroupBox5 = New System.Windows.Forms.GroupBox()
      Me.txtComprasDecimalesRedondeoEnCantidad = New Eniac.Controles.TextBox()
      Me.lblComprasDecimalesRedondeoEnCantidad = New Eniac.Controles.Label()
      Me.lblComprasDecimalesMostrarEnCantidad = New Eniac.Controles.Label()
      Me.txtComprasDecimalesRedondeoEnPrecio = New Eniac.Controles.TextBox()
      Me.lblComprasDecimalesRedondeoEnPrecio = New Eniac.Controles.Label()
      Me.lblComprasDecimalesMostrarEnItems = New Eniac.Controles.Label()
      Me.lblComprasDecimalesEnTotal = New Eniac.Controles.Label()
      Me.lblComprasDecimalesEnTotalXProducto = New Eniac.Controles.Label()
      Me.txtComprasDecimalesMostrarEnCantidad = New Eniac.Controles.TextBox()
      Me.txtComprasDecimalesEnTotal = New Eniac.Controles.TextBox()
      Me.txtComprasDecimalesEnTotalXProducto = New Eniac.Controles.TextBox()
      Me.txtComprasDecimalesMostrarEnItems = New Eniac.Controles.TextBox()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.chbPermiteModificarSubtotal = New System.Windows.Forms.CheckBox()
      Me.GroupBox5.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox5
      '
      Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesRedondeoEnCantidad)
      Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesMostrarEnCantidad)
      Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesRedondeoEnPrecio)
      Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesMostrarEnItems)
      Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesRedondeoEnCantidad)
      Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesEnTotal)
      Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesEnTotalXProducto)
      Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesRedondeoEnPrecio)
      Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesMostrarEnCantidad)
      Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesEnTotal)
      Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesEnTotalXProducto)
      Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesMostrarEnItems)
      Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox5.Name = "GroupBox5"
      Me.GroupBox5.Size = New System.Drawing.Size(408, 98)
      Me.GroupBox5.TabIndex = 0
      Me.GroupBox5.TabStop = False
      Me.GroupBox5.Text = "Cantidad de decimales"
      '
      'txtComprasDecimalesRedondeoEnCantidad
      '
      Me.txtComprasDecimalesRedondeoEnCantidad.BindearPropiedadControl = Nothing
      Me.txtComprasDecimalesRedondeoEnCantidad.BindearPropiedadEntidad = Nothing
      Me.txtComprasDecimalesRedondeoEnCantidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComprasDecimalesRedondeoEnCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComprasDecimalesRedondeoEnCantidad.Formato = ""
      Me.txtComprasDecimalesRedondeoEnCantidad.IsDecimal = False
      Me.txtComprasDecimalesRedondeoEnCantidad.IsNumber = True
      Me.txtComprasDecimalesRedondeoEnCantidad.IsPK = False
      Me.txtComprasDecimalesRedondeoEnCantidad.IsRequired = False
      Me.txtComprasDecimalesRedondeoEnCantidad.Key = ""
      Me.txtComprasDecimalesRedondeoEnCantidad.LabelAsoc = Me.lblComprasDecimalesRedondeoEnCantidad
      Me.txtComprasDecimalesRedondeoEnCantidad.Location = New System.Drawing.Point(218, 19)
      Me.txtComprasDecimalesRedondeoEnCantidad.MaxLength = 3
      Me.txtComprasDecimalesRedondeoEnCantidad.Name = "txtComprasDecimalesRedondeoEnCantidad"
      Me.txtComprasDecimalesRedondeoEnCantidad.Size = New System.Drawing.Size(35, 20)
      Me.txtComprasDecimalesRedondeoEnCantidad.TabIndex = 6
      Me.txtComprasDecimalesRedondeoEnCantidad.Text = "2"
      Me.txtComprasDecimalesRedondeoEnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblComprasDecimalesRedondeoEnCantidad
      '
      Me.lblComprasDecimalesRedondeoEnCantidad.AutoSize = True
      Me.lblComprasDecimalesRedondeoEnCantidad.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblComprasDecimalesRedondeoEnCantidad.Location = New System.Drawing.Point(256, 23)
      Me.lblComprasDecimalesRedondeoEnCantidad.Name = "lblComprasDecimalesRedondeoEnCantidad"
      Me.lblComprasDecimalesRedondeoEnCantidad.Size = New System.Drawing.Size(117, 13)
      Me.lblComprasDecimalesRedondeoEnCantidad.TabIndex = 7
      Me.lblComprasDecimalesRedondeoEnCantidad.Text = "Redondeo en Cantidad"
      '
      'lblComprasDecimalesMostrarEnCantidad
      '
      Me.lblComprasDecimalesMostrarEnCantidad.AutoSize = True
      Me.lblComprasDecimalesMostrarEnCantidad.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblComprasDecimalesMostrarEnCantidad.Location = New System.Drawing.Point(256, 49)
      Me.lblComprasDecimalesMostrarEnCantidad.Name = "lblComprasDecimalesMostrarEnCantidad"
      Me.lblComprasDecimalesMostrarEnCantidad.Size = New System.Drawing.Size(102, 13)
      Me.lblComprasDecimalesMostrarEnCantidad.TabIndex = 9
      Me.lblComprasDecimalesMostrarEnCantidad.Text = "Mostrar en Cantidad"
      '
      'txtComprasDecimalesRedondeoEnPrecio
      '
      Me.txtComprasDecimalesRedondeoEnPrecio.BindearPropiedadControl = Nothing
      Me.txtComprasDecimalesRedondeoEnPrecio.BindearPropiedadEntidad = Nothing
      Me.txtComprasDecimalesRedondeoEnPrecio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComprasDecimalesRedondeoEnPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComprasDecimalesRedondeoEnPrecio.Formato = ""
      Me.txtComprasDecimalesRedondeoEnPrecio.IsDecimal = False
      Me.txtComprasDecimalesRedondeoEnPrecio.IsNumber = True
      Me.txtComprasDecimalesRedondeoEnPrecio.IsPK = False
      Me.txtComprasDecimalesRedondeoEnPrecio.IsRequired = False
      Me.txtComprasDecimalesRedondeoEnPrecio.Key = ""
      Me.txtComprasDecimalesRedondeoEnPrecio.LabelAsoc = Me.lblComprasDecimalesRedondeoEnPrecio
      Me.txtComprasDecimalesRedondeoEnPrecio.Location = New System.Drawing.Point(6, 19)
      Me.txtComprasDecimalesRedondeoEnPrecio.MaxLength = 3
      Me.txtComprasDecimalesRedondeoEnPrecio.Name = "txtComprasDecimalesRedondeoEnPrecio"
      Me.txtComprasDecimalesRedondeoEnPrecio.Size = New System.Drawing.Size(35, 20)
      Me.txtComprasDecimalesRedondeoEnPrecio.TabIndex = 0
      Me.txtComprasDecimalesRedondeoEnPrecio.Text = "2"
      Me.txtComprasDecimalesRedondeoEnPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblComprasDecimalesRedondeoEnPrecio
      '
      Me.lblComprasDecimalesRedondeoEnPrecio.AutoSize = True
      Me.lblComprasDecimalesRedondeoEnPrecio.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblComprasDecimalesRedondeoEnPrecio.Location = New System.Drawing.Point(44, 23)
      Me.lblComprasDecimalesRedondeoEnPrecio.Name = "lblComprasDecimalesRedondeoEnPrecio"
      Me.lblComprasDecimalesRedondeoEnPrecio.Size = New System.Drawing.Size(105, 13)
      Me.lblComprasDecimalesRedondeoEnPrecio.TabIndex = 1
      Me.lblComprasDecimalesRedondeoEnPrecio.Text = "Redondeo en Precio"
      '
      'lblComprasDecimalesMostrarEnItems
      '
      Me.lblComprasDecimalesMostrarEnItems.AutoSize = True
      Me.lblComprasDecimalesMostrarEnItems.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblComprasDecimalesMostrarEnItems.Location = New System.Drawing.Point(44, 49)
      Me.lblComprasDecimalesMostrarEnItems.Name = "lblComprasDecimalesMostrarEnItems"
      Me.lblComprasDecimalesMostrarEnItems.Size = New System.Drawing.Size(90, 13)
      Me.lblComprasDecimalesMostrarEnItems.TabIndex = 3
      Me.lblComprasDecimalesMostrarEnItems.Text = "Mostrar en Precio"
      '
      'lblComprasDecimalesEnTotal
      '
      Me.lblComprasDecimalesEnTotal.AutoSize = True
      Me.lblComprasDecimalesEnTotal.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblComprasDecimalesEnTotal.Location = New System.Drawing.Point(256, 75)
      Me.lblComprasDecimalesEnTotal.Name = "lblComprasDecimalesEnTotal"
      Me.lblComprasDecimalesEnTotal.Size = New System.Drawing.Size(146, 13)
      Me.lblComprasDecimalesEnTotal.TabIndex = 11
      Me.lblComprasDecimalesEnTotal.Text = "Mostrar en Totales Generales"
      '
      'lblComprasDecimalesEnTotalXProducto
      '
      Me.lblComprasDecimalesEnTotalXProducto.AutoSize = True
      Me.lblComprasDecimalesEnTotalXProducto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblComprasDecimalesEnTotalXProducto.Location = New System.Drawing.Point(44, 75)
      Me.lblComprasDecimalesEnTotalXProducto.Name = "lblComprasDecimalesEnTotalXProducto"
      Me.lblComprasDecimalesEnTotalXProducto.Size = New System.Drawing.Size(138, 13)
      Me.lblComprasDecimalesEnTotalXProducto.TabIndex = 5
      Me.lblComprasDecimalesEnTotalXProducto.Text = "Mostrar en Total x Producto"
      '
      'txtComprasDecimalesMostrarEnCantidad
      '
      Me.txtComprasDecimalesMostrarEnCantidad.BindearPropiedadControl = Nothing
      Me.txtComprasDecimalesMostrarEnCantidad.BindearPropiedadEntidad = Nothing
      Me.txtComprasDecimalesMostrarEnCantidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComprasDecimalesMostrarEnCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComprasDecimalesMostrarEnCantidad.Formato = ""
      Me.txtComprasDecimalesMostrarEnCantidad.IsDecimal = False
      Me.txtComprasDecimalesMostrarEnCantidad.IsNumber = True
      Me.txtComprasDecimalesMostrarEnCantidad.IsPK = False
      Me.txtComprasDecimalesMostrarEnCantidad.IsRequired = False
      Me.txtComprasDecimalesMostrarEnCantidad.Key = ""
      Me.txtComprasDecimalesMostrarEnCantidad.LabelAsoc = Me.lblComprasDecimalesMostrarEnCantidad
      Me.txtComprasDecimalesMostrarEnCantidad.Location = New System.Drawing.Point(218, 45)
      Me.txtComprasDecimalesMostrarEnCantidad.MaxLength = 3
      Me.txtComprasDecimalesMostrarEnCantidad.Name = "txtComprasDecimalesMostrarEnCantidad"
      Me.txtComprasDecimalesMostrarEnCantidad.Size = New System.Drawing.Size(35, 20)
      Me.txtComprasDecimalesMostrarEnCantidad.TabIndex = 8
      Me.txtComprasDecimalesMostrarEnCantidad.Text = "2"
      Me.txtComprasDecimalesMostrarEnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtComprasDecimalesEnTotal
      '
      Me.txtComprasDecimalesEnTotal.BindearPropiedadControl = Nothing
      Me.txtComprasDecimalesEnTotal.BindearPropiedadEntidad = Nothing
      Me.txtComprasDecimalesEnTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComprasDecimalesEnTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComprasDecimalesEnTotal.Formato = ""
      Me.txtComprasDecimalesEnTotal.IsDecimal = False
      Me.txtComprasDecimalesEnTotal.IsNumber = True
      Me.txtComprasDecimalesEnTotal.IsPK = False
      Me.txtComprasDecimalesEnTotal.IsRequired = False
      Me.txtComprasDecimalesEnTotal.Key = ""
      Me.txtComprasDecimalesEnTotal.LabelAsoc = Me.lblComprasDecimalesEnTotal
      Me.txtComprasDecimalesEnTotal.Location = New System.Drawing.Point(218, 71)
      Me.txtComprasDecimalesEnTotal.MaxLength = 3
      Me.txtComprasDecimalesEnTotal.Name = "txtComprasDecimalesEnTotal"
      Me.txtComprasDecimalesEnTotal.Size = New System.Drawing.Size(35, 20)
      Me.txtComprasDecimalesEnTotal.TabIndex = 10
      Me.txtComprasDecimalesEnTotal.Text = "2"
      Me.txtComprasDecimalesEnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtComprasDecimalesEnTotalXProducto
      '
      Me.txtComprasDecimalesEnTotalXProducto.BindearPropiedadControl = Nothing
      Me.txtComprasDecimalesEnTotalXProducto.BindearPropiedadEntidad = Nothing
      Me.txtComprasDecimalesEnTotalXProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComprasDecimalesEnTotalXProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComprasDecimalesEnTotalXProducto.Formato = ""
      Me.txtComprasDecimalesEnTotalXProducto.IsDecimal = False
      Me.txtComprasDecimalesEnTotalXProducto.IsNumber = True
      Me.txtComprasDecimalesEnTotalXProducto.IsPK = False
      Me.txtComprasDecimalesEnTotalXProducto.IsRequired = False
      Me.txtComprasDecimalesEnTotalXProducto.Key = ""
      Me.txtComprasDecimalesEnTotalXProducto.LabelAsoc = Me.lblComprasDecimalesEnTotalXProducto
      Me.txtComprasDecimalesEnTotalXProducto.Location = New System.Drawing.Point(6, 71)
      Me.txtComprasDecimalesEnTotalXProducto.MaxLength = 3
      Me.txtComprasDecimalesEnTotalXProducto.Name = "txtComprasDecimalesEnTotalXProducto"
      Me.txtComprasDecimalesEnTotalXProducto.Size = New System.Drawing.Size(35, 20)
      Me.txtComprasDecimalesEnTotalXProducto.TabIndex = 4
      Me.txtComprasDecimalesEnTotalXProducto.Text = "2"
      Me.txtComprasDecimalesEnTotalXProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtComprasDecimalesMostrarEnItems
      '
      Me.txtComprasDecimalesMostrarEnItems.BindearPropiedadControl = Nothing
      Me.txtComprasDecimalesMostrarEnItems.BindearPropiedadEntidad = Nothing
      Me.txtComprasDecimalesMostrarEnItems.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComprasDecimalesMostrarEnItems.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComprasDecimalesMostrarEnItems.Formato = ""
      Me.txtComprasDecimalesMostrarEnItems.IsDecimal = False
      Me.txtComprasDecimalesMostrarEnItems.IsNumber = True
      Me.txtComprasDecimalesMostrarEnItems.IsPK = False
      Me.txtComprasDecimalesMostrarEnItems.IsRequired = False
      Me.txtComprasDecimalesMostrarEnItems.Key = ""
      Me.txtComprasDecimalesMostrarEnItems.LabelAsoc = Me.lblComprasDecimalesMostrarEnItems
      Me.txtComprasDecimalesMostrarEnItems.Location = New System.Drawing.Point(6, 45)
      Me.txtComprasDecimalesMostrarEnItems.MaxLength = 3
      Me.txtComprasDecimalesMostrarEnItems.Name = "txtComprasDecimalesMostrarEnItems"
      Me.txtComprasDecimalesMostrarEnItems.Size = New System.Drawing.Size(35, 20)
      Me.txtComprasDecimalesMostrarEnItems.TabIndex = 2
      Me.txtComprasDecimalesMostrarEnItems.Text = "2"
      Me.txtComprasDecimalesMostrarEnItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(254, 149)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 2
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(340, 149)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 3
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'chbPermiteModificarSubtotal
      '
      Me.chbPermiteModificarSubtotal.AutoSize = True
      Me.chbPermiteModificarSubtotal.Location = New System.Drawing.Point(18, 116)
      Me.chbPermiteModificarSubtotal.Name = "chbPermiteModificarSubtotal"
      Me.chbPermiteModificarSubtotal.Size = New System.Drawing.Size(226, 17)
      Me.chbPermiteModificarSubtotal.TabIndex = 1
      Me.chbPermiteModificarSubtotal.Text = "Permite modificar el subtotal de cada línea"
      Me.chbPermiteModificarSubtotal.UseVisualStyleBackColor = True
      '
      'MovimientosDeComprasParametros
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(432, 191)
      Me.Controls.Add(Me.chbPermiteModificarSubtotal)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.GroupBox5)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "MovimientosDeComprasParametros"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Parámetros de Movimientos de Compras"
      Me.GroupBox5.ResumeLayout(False)
      Me.GroupBox5.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
   Friend WithEvents txtComprasDecimalesRedondeoEnCantidad As Eniac.Controles.TextBox
   Friend WithEvents lblComprasDecimalesRedondeoEnCantidad As Eniac.Controles.Label
   Friend WithEvents lblComprasDecimalesMostrarEnCantidad As Eniac.Controles.Label
   Friend WithEvents txtComprasDecimalesRedondeoEnPrecio As Eniac.Controles.TextBox
   Friend WithEvents lblComprasDecimalesRedondeoEnPrecio As Eniac.Controles.Label
   Friend WithEvents lblComprasDecimalesMostrarEnItems As Eniac.Controles.Label
   Friend WithEvents lblComprasDecimalesEnTotal As Eniac.Controles.Label
   Friend WithEvents lblComprasDecimalesEnTotalXProducto As Eniac.Controles.Label
   Friend WithEvents txtComprasDecimalesMostrarEnCantidad As Eniac.Controles.TextBox
   Friend WithEvents txtComprasDecimalesEnTotal As Eniac.Controles.TextBox
   Friend WithEvents txtComprasDecimalesEnTotalXProducto As Eniac.Controles.TextBox
   Friend WithEvents txtComprasDecimalesMostrarEnItems As Eniac.Controles.TextBox
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents chbPermiteModificarSubtotal As System.Windows.Forms.CheckBox
End Class
