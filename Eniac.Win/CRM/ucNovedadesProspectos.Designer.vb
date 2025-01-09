<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesProspectos
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
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.llbCliente = New Eniac.Controles.LinkLabel()
        Me.txtTelefonos = New Eniac.Controles.TextBox()
        Me.lblTelefonos = New Eniac.Controles.Label()
        Me.txtCorreo = New Eniac.Controles.TextBox()
        Me.lblCorreo = New Eniac.Controles.Label()
        Me.txtCategoria = New Eniac.Controles.TextBox()
        Me.lblCategoria = New Eniac.Controles.Label()
        Me.lblTipoCliente = New Eniac.Controles.Label()
        Me.txtTipoCliente = New Eniac.Controles.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTipoCliente)
        Me.GroupBox1.Controls.Add(Me.txtTipoCliente)
        Me.GroupBox1.Controls.Add(Me.txtTelefonos)
        Me.GroupBox1.Controls.Add(Me.txtCorreo)
        Me.GroupBox1.Controls.Add(Me.txtCategoria)
        Me.GroupBox1.Controls.Add(Me.lblTelefonos)
        Me.GroupBox1.Controls.Add(Me.lblCorreo)
        Me.GroupBox1.Controls.Add(Me.lblCategoria)
        Me.GroupBox1.Controls.Add(Me.llbCliente)
        Me.GroupBox1.Controls.Add(Me.bscCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.bscCliente)
        Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Size = New System.Drawing.Size(385, 115)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.Text = "Prospecto"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(6, 26)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoCliente.TabIndex = 1
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(6, 12)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 0
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(100, 25)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(281, 23)
        Me.bscCliente.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(97, 12)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "&Nombre"
        '
        'llbCliente
        '
        Me.llbCliente.AutoSize = True
        Me.llbCliente.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbCliente.Location = New System.Drawing.Point(147, 12)
        Me.llbCliente.Name = "llbCliente"
        Me.llbCliente.Size = New System.Drawing.Size(55, 13)
        Me.llbCliente.TabIndex = 4
        Me.llbCliente.TabStop = True
        Me.llbCliente.Text = "más info..."
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
        Me.txtTelefonos.Location = New System.Drawing.Point(61, 70)
        Me.txtTelefonos.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTelefonos.Name = "txtTelefonos"
        Me.txtTelefonos.ReadOnly = True
        Me.txtTelefonos.Size = New System.Drawing.Size(320, 20)
        Me.txtTelefonos.TabIndex = 10
        '
        'lblTelefonos
        '
        Me.lblTelefonos.AutoSize = True
        Me.lblTelefonos.LabelAsoc = Nothing
        Me.lblTelefonos.Location = New System.Drawing.Point(6, 73)
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
        Me.txtCorreo.Location = New System.Drawing.Point(61, 93)
        Me.txtCorreo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.ReadOnly = True
        Me.txtCorreo.Size = New System.Drawing.Size(320, 20)
        Me.txtCorreo.TabIndex = 8
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.LabelAsoc = Nothing
        Me.lblCorreo.Location = New System.Drawing.Point(6, 96)
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
        Me.txtCategoria.Location = New System.Drawing.Point(61, 48)
        Me.txtCategoria.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(140, 20)
        Me.txtCategoria.TabIndex = 6
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.LabelAsoc = Nothing
        Me.lblCategoria.Location = New System.Drawing.Point(6, 51)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(54, 13)
        Me.lblCategoria.TabIndex = 5
        Me.lblCategoria.Text = "Categoría"
        '
        'lblTipoCliente
        '
        Me.lblTipoCliente.AutoSize = True
        Me.lblTipoCliente.LabelAsoc = Nothing
        Me.lblTipoCliente.Location = New System.Drawing.Point(205, 51)
        Me.lblTipoCliente.Name = "lblTipoCliente"
        Me.lblTipoCliente.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoCliente.TabIndex = 14
        Me.lblTipoCliente.Text = "Tipo"
        '
        'txtTipoCliente
        '
        Me.txtTipoCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTipoCliente.BindearPropiedadControl = ""
        Me.txtTipoCliente.BindearPropiedadEntidad = ""
        Me.txtTipoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoCliente.Formato = ""
        Me.txtTipoCliente.IsDecimal = False
        Me.txtTipoCliente.IsNumber = False
        Me.txtTipoCliente.IsPK = False
        Me.txtTipoCliente.IsRequired = False
        Me.txtTipoCliente.Key = ""
        Me.txtTipoCliente.LabelAsoc = Me.lblTipoCliente
        Me.txtTipoCliente.Location = New System.Drawing.Point(237, 48)
        Me.txtTipoCliente.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTipoCliente.Name = "txtTipoCliente"
        Me.txtTipoCliente.ReadOnly = True
        Me.txtTipoCliente.Size = New System.Drawing.Size(144, 20)
        Me.txtTipoCliente.TabIndex = 15
        '
        'ucNovedadesProspectos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MaximumSize = New System.Drawing.Size(385, 115)
        Me.Name = "ucNovedadesProspectos"
        Me.Size = New System.Drawing.Size(385, 115)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents llbCliente As Eniac.Controles.LinkLabel
   Friend WithEvents txtTelefonos As Eniac.Controles.TextBox
   Friend WithEvents lblTelefonos As Eniac.Controles.Label
   Friend WithEvents txtCorreo As Eniac.Controles.TextBox
   Friend WithEvents lblCorreo As Eniac.Controles.Label
   Friend WithEvents txtCategoria As Eniac.Controles.TextBox
   Friend WithEvents lblCategoria As Eniac.Controles.Label
    Friend WithEvents lblTipoCliente As Controles.Label
    Friend WithEvents txtTipoCliente As Controles.TextBox
End Class
