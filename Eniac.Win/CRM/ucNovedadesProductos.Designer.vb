<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesProductos
   Inherits Eniac.Win.ucNovedades

   'UserControl overrides dispose to clean up the component list.
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
      Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscProducto = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNroChasis = New Eniac.Controles.TextBox()
      Me.txtNroCarroceria = New Eniac.Controles.TextBox()
      Me.lblNroChasis = New Eniac.Controles.Label()
      Me.lblNroCarroceria = New Eniac.Controles.Label()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.lblNroCarroceria)
      Me.GroupBox1.Controls.Add(Me.lblNroChasis)
      Me.GroupBox1.Controls.Add(Me.txtNroCarroceria)
      Me.GroupBox1.Controls.Add(Me.txtNroChasis)
      Me.GroupBox1.Controls.Add(Me.bscCodigoProducto)
      Me.GroupBox1.Controls.Add(Me.bscProducto)
      Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
      Me.GroupBox1.Controls.Add(Me.lblNombre)
      Me.GroupBox1.Size = New System.Drawing.Size(385, 82)
      Me.GroupBox1.Text = "Producto"
      '
      'bscCodigoProducto
      '
      Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto.ConfigBuscador = Nothing
      Me.bscCodigoProducto.Datos = Nothing
      Me.bscCodigoProducto.FilaDevuelta = Nothing
      Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto.IsDecimal = False
      Me.bscCodigoProducto.IsNumber = False
      Me.bscCodigoProducto.IsPK = False
      Me.bscCodigoProducto.IsRequired = False
      Me.bscCodigoProducto.Key = ""
      Me.bscCodigoProducto.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoProducto.Location = New System.Drawing.Point(6, 29)
      Me.bscCodigoProducto.MaxLengh = "32767"
      Me.bscCodigoProducto.Name = "bscCodigoProducto"
      Me.bscCodigoProducto.Permitido = True
      Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto.Selecciono = False
      Me.bscCodigoProducto.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoProducto.TabIndex = 1
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(6, 15)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 0
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscProducto
      '
      Me.bscProducto.ActivarFiltroEnGrilla = True
      Me.bscProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto.BindearPropiedadControl = Nothing
      Me.bscProducto.BindearPropiedadEntidad = Nothing
      Me.bscProducto.ConfigBuscador = Nothing
      Me.bscProducto.Datos = Nothing
      Me.bscProducto.FilaDevuelta = Nothing
      Me.bscProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto.IsDecimal = False
      Me.bscProducto.IsNumber = False
      Me.bscProducto.IsPK = False
      Me.bscProducto.IsRequired = False
      Me.bscProducto.Key = ""
      Me.bscProducto.LabelAsoc = Me.lblNombre
      Me.bscProducto.Location = New System.Drawing.Point(100, 28)
      Me.bscProducto.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProducto.MaxLengh = "32767"
      Me.bscProducto.Name = "bscProducto"
      Me.bscProducto.Permitido = True
      Me.bscProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto.Selecciono = False
      Me.bscProducto.Size = New System.Drawing.Size(281, 23)
      Me.bscProducto.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(97, 15)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "&Nombre"
      '
      'txtNroChasis
      '
      Me.txtNroChasis.BindearPropiedadControl = Nothing
      Me.txtNroChasis.BindearPropiedadEntidad = Nothing
      Me.txtNroChasis.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroChasis.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroChasis.Formato = ""
      Me.txtNroChasis.IsDecimal = False
      Me.txtNroChasis.IsNumber = False
      Me.txtNroChasis.IsPK = False
      Me.txtNroChasis.IsRequired = False
      Me.txtNroChasis.Key = ""
      Me.txtNroChasis.LabelAsoc = Nothing
      Me.txtNroChasis.Location = New System.Drawing.Point(66, 56)
      Me.txtNroChasis.Name = "txtNroChasis"
      Me.txtNroChasis.ReadOnly = True
      Me.txtNroChasis.Size = New System.Drawing.Size(123, 20)
      Me.txtNroChasis.TabIndex = 5
      Me.txtNroChasis.Text = "9532G82WOJR814100"
      '
      'txtNroCarroceria
      '
      Me.txtNroCarroceria.BindearPropiedadControl = Nothing
      Me.txtNroCarroceria.BindearPropiedadEntidad = Nothing
      Me.txtNroCarroceria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroCarroceria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroCarroceria.Formato = ""
      Me.txtNroCarroceria.IsDecimal = False
      Me.txtNroCarroceria.IsNumber = False
      Me.txtNroCarroceria.IsPK = False
      Me.txtNroCarroceria.IsRequired = False
      Me.txtNroCarroceria.Key = ""
      Me.txtNroCarroceria.LabelAsoc = Nothing
      Me.txtNroCarroceria.Location = New System.Drawing.Point(279, 56)
      Me.txtNroCarroceria.Name = "txtNroCarroceria"
      Me.txtNroCarroceria.ReadOnly = True
      Me.txtNroCarroceria.Size = New System.Drawing.Size(100, 20)
      Me.txtNroCarroceria.TabIndex = 7
      '
      'lblNroChasis
      '
      Me.lblNroChasis.AutoSize = True
      Me.lblNroChasis.LabelAsoc = Nothing
      Me.lblNroChasis.Location = New System.Drawing.Point(3, 59)
      Me.lblNroChasis.Name = "lblNroChasis"
      Me.lblNroChasis.Size = New System.Drawing.Size(61, 13)
      Me.lblNroChasis.TabIndex = 4
      Me.lblNroChasis.Text = "Nro. Chasis"
      '
      'lblNroCarroceria
      '
      Me.lblNroCarroceria.AutoSize = True
      Me.lblNroCarroceria.LabelAsoc = Nothing
      Me.lblNroCarroceria.Location = New System.Drawing.Point(195, 59)
      Me.lblNroCarroceria.Name = "lblNroCarroceria"
      Me.lblNroCarroceria.Size = New System.Drawing.Size(80, 13)
      Me.lblNroCarroceria.TabIndex = 6
      Me.lblNroCarroceria.Text = "Nro. Carrocería"
      '
      'ucNovedadesProductos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Margin = New System.Windows.Forms.Padding(0)
      Me.MaximumSize = New System.Drawing.Size(395, 100)
      Me.Name = "ucNovedadesProductos"
      Me.Size = New System.Drawing.Size(385, 82)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents bscCodigoProducto As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscProducto As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblNroCarroceria As Eniac.Controles.Label
   Friend WithEvents lblNroChasis As Eniac.Controles.Label
   Friend WithEvents txtNroCarroceria As Eniac.Controles.TextBox
   Friend WithEvents txtNroChasis As Eniac.Controles.TextBox

End Class
