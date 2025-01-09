<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesProveedores
   Inherits ucNovedades

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucNovedadesProveedores))
      Me.llbProveedor = New Eniac.Controles.LinkLabel()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtTelefonos = New Eniac.Controles.TextBox()
      Me.lblTelefonos = New Eniac.Controles.Label()
      Me.txtCorreo = New Eniac.Controles.TextBox()
      Me.lblCorreo = New Eniac.Controles.Label()
      Me.txtCategoria = New Eniac.Controles.TextBox()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.txtTelefonos)
      Me.GroupBox1.Controls.Add(Me.txtCorreo)
      Me.GroupBox1.Controls.Add(Me.txtCategoria)
      Me.GroupBox1.Controls.Add(Me.lblTelefonos)
      Me.GroupBox1.Controls.Add(Me.lblCorreo)
      Me.GroupBox1.Controls.Add(Me.lblCategoria)
      Me.GroupBox1.Controls.Add(Me.llbProveedor)
      Me.GroupBox1.Controls.Add(Me.bscCodigoProveedor)
      Me.GroupBox1.Controls.Add(Me.bscProveedor)
      Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
      Me.GroupBox1.Controls.Add(Me.lblNombre)
      Me.GroupBox1.Size = New System.Drawing.Size(385, 95)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.Text = "Proveedor"
      '
      'llbProveedor
      '
      Me.llbProveedor.AutoSize = True
      Me.llbProveedor.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
      Me.llbProveedor.Location = New System.Drawing.Point(147, 14)
      Me.llbProveedor.Name = "llbProveedor"
      Me.llbProveedor.Size = New System.Drawing.Size(55, 13)
      Me.llbProveedor.TabIndex = 4
      Me.llbProveedor.TabStop = True
      Me.llbProveedor.Text = "más info..."
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ColumnasCondiciones = CType(resources.GetObject("bscCodigoProveedor.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoProveedor.ColumnasVisibles = CType(resources.GetObject("bscCodigoProveedor.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = False
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(6, 28)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoProveedor.TabIndex = 1
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(6, 14)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 0
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscProveedor
      '
      Me.bscProveedor.ActivarFiltroEnGrilla = True
      Me.bscProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasCondiciones = CType(resources.GetObject("bscProveedor.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscProveedor.ColumnasVisibles = CType(resources.GetObject("bscProveedor.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Me.lblNombre
      Me.bscProveedor.Location = New System.Drawing.Point(100, 27)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(280, 23)
      Me.bscProveedor.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(97, 14)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "&Nombre"
      '
      'txtTelefonos
      '
      Me.txtTelefonos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTelefonos.BindearPropiedadControl = ""
      Me.txtTelefonos.BindearPropiedadEntidad = ""
      Me.txtTelefonos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefonos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefonos.Formato = ""
      Me.txtTelefonos.IsDecimal = False
      Me.txtTelefonos.IsNumber = False
      Me.txtTelefonos.IsPK = False
      Me.txtTelefonos.IsRequired = False
      Me.txtTelefonos.Key = ""
      Me.txtTelefonos.LabelAsoc = Me.lblTelefonos
      Me.txtTelefonos.Location = New System.Drawing.Point(60, 74)
      Me.txtTelefonos.Margin = New System.Windows.Forms.Padding(1)
      Me.txtTelefonos.Name = "txtTelefonos"
      Me.txtTelefonos.ReadOnly = True
      Me.txtTelefonos.Size = New System.Drawing.Size(320, 20)
      Me.txtTelefonos.TabIndex = 10
      '
      'lblTelefonos
      '
      Me.lblTelefonos.AutoSize = True
      Me.lblTelefonos.Location = New System.Drawing.Point(5, 77)
      Me.lblTelefonos.Name = "lblTelefonos"
      Me.lblTelefonos.Size = New System.Drawing.Size(54, 13)
      Me.lblTelefonos.TabIndex = 9
      Me.lblTelefonos.Text = "Teléfonos"
      '
      'txtCorreo
      '
      Me.txtCorreo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCorreo.BindearPropiedadControl = ""
      Me.txtCorreo.BindearPropiedadEntidad = ""
      Me.txtCorreo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCorreo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCorreo.Formato = ""
      Me.txtCorreo.IsDecimal = False
      Me.txtCorreo.IsNumber = False
      Me.txtCorreo.IsPK = False
      Me.txtCorreo.IsRequired = False
      Me.txtCorreo.Key = ""
      Me.txtCorreo.LabelAsoc = Me.lblCorreo
      Me.txtCorreo.Location = New System.Drawing.Point(255, 52)
      Me.txtCorreo.Margin = New System.Windows.Forms.Padding(1)
      Me.txtCorreo.Name = "txtCorreo"
      Me.txtCorreo.ReadOnly = True
      Me.txtCorreo.Size = New System.Drawing.Size(125, 20)
      Me.txtCorreo.TabIndex = 8
      '
      'lblCorreo
      '
      Me.lblCorreo.AutoSize = True
      Me.lblCorreo.Location = New System.Drawing.Point(211, 55)
      Me.lblCorreo.Name = "lblCorreo"
      Me.lblCorreo.Size = New System.Drawing.Size(38, 13)
      Me.lblCorreo.TabIndex = 7
      Me.lblCorreo.Text = "Correo"
      '
      'txtCategoria
      '
      Me.txtCategoria.BindearPropiedadControl = ""
      Me.txtCategoria.BindearPropiedadEntidad = ""
      Me.txtCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCategoria.Formato = ""
      Me.txtCategoria.IsDecimal = False
      Me.txtCategoria.IsNumber = False
      Me.txtCategoria.IsPK = False
      Me.txtCategoria.IsRequired = False
      Me.txtCategoria.Key = ""
      Me.txtCategoria.LabelAsoc = Me.lblCategoria
      Me.txtCategoria.Location = New System.Drawing.Point(60, 52)
      Me.txtCategoria.Margin = New System.Windows.Forms.Padding(1)
      Me.txtCategoria.Name = "txtCategoria"
      Me.txtCategoria.ReadOnly = True
      Me.txtCategoria.Size = New System.Drawing.Size(140, 20)
      Me.txtCategoria.TabIndex = 6
      '
      'lblCategoria
      '
      Me.lblCategoria.AutoSize = True
      Me.lblCategoria.Location = New System.Drawing.Point(5, 55)
      Me.lblCategoria.Name = "lblCategoria"
      Me.lblCategoria.Size = New System.Drawing.Size(54, 13)
      Me.lblCategoria.TabIndex = 5
      Me.lblCategoria.Text = "Categoría"
      '
      'ucNovedadesProveedores
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Margin = New System.Windows.Forms.Padding(0)
      Me.MaximumSize = New System.Drawing.Size(395, 95)
      Me.Name = "ucNovedadesProveedores"
      Me.Size = New System.Drawing.Size(385, 95)
      Me.GroupBox1.ResumeLayout(false)
      Me.GroupBox1.PerformLayout
      Me.ResumeLayout(false)

End Sub
   Friend WithEvents llbProveedor As Eniac.Controles.LinkLabel
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtTelefonos As Eniac.Controles.TextBox
   Friend WithEvents lblTelefonos As Eniac.Controles.Label
   Friend WithEvents txtCorreo As Eniac.Controles.TextBox
   Friend WithEvents lblCorreo As Eniac.Controles.Label
   Friend WithEvents txtCategoria As Eniac.Controles.TextBox
   Friend WithEvents lblCategoria As Eniac.Controles.Label

End Class
