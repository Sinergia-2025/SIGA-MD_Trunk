<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesVehiculos
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
      Me.bscCodigoVehiculo = New Eniac.Controles.Buscador2()
      Me.txtModeloVehiculo = New Eniac.Controles.TextBox()
      Me.txtMarcaVehiculo = New Eniac.Controles.TextBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.txtAnioPatentamiento = New Eniac.Controles.TextBox()
        Me.llbCliente = New Eniac.Controles.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtColor)
        Me.GroupBox1.Controls.Add(Me.txtAnioPatentamiento)
        Me.GroupBox1.Controls.Add(Me.txtModeloVehiculo)
        Me.GroupBox1.Controls.Add(Me.txtMarcaVehiculo)
        Me.GroupBox1.Controls.Add(Me.bscCodigoVehiculo)
        Me.GroupBox1.Controls.Add(Me.llbCliente)
        Me.GroupBox1.Size = New System.Drawing.Size(385, 70)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.Text = "Vehículos"
        '
        'bscCodigoVehiculo
        '
        Me.bscCodigoVehiculo.ActivarFiltroEnGrilla = True
        Me.bscCodigoVehiculo.BindearPropiedadControl = ""
        Me.bscCodigoVehiculo.BindearPropiedadEntidad = ""
        Me.bscCodigoVehiculo.ConfigBuscador = Nothing
        Me.bscCodigoVehiculo.Datos = Nothing
        Me.bscCodigoVehiculo.FilaDevuelta = Nothing
        Me.bscCodigoVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoVehiculo.IsDecimal = False
        Me.bscCodigoVehiculo.IsNumber = False
        Me.bscCodigoVehiculo.IsPK = False
        Me.bscCodigoVehiculo.IsRequired = False
        Me.bscCodigoVehiculo.Key = ""
        Me.bscCodigoVehiculo.LabelAsoc = Nothing
        Me.bscCodigoVehiculo.Location = New System.Drawing.Point(10, 24)
        Me.bscCodigoVehiculo.MaxLengh = "32767"
        Me.bscCodigoVehiculo.Name = "bscCodigoVehiculo"
        Me.bscCodigoVehiculo.Permitido = True
        Me.bscCodigoVehiculo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoVehiculo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoVehiculo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoVehiculo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoVehiculo.Selecciono = False
        Me.bscCodigoVehiculo.Size = New System.Drawing.Size(145, 20)
        Me.bscCodigoVehiculo.TabIndex = 0
        '
        'txtModeloVehiculo
        '
        Me.txtModeloVehiculo.BindearPropiedadControl = Nothing
        Me.txtModeloVehiculo.BindearPropiedadEntidad = Nothing
        Me.txtModeloVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtModeloVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtModeloVehiculo.Formato = ""
        Me.txtModeloVehiculo.IsDecimal = False
        Me.txtModeloVehiculo.IsNumber = False
        Me.txtModeloVehiculo.IsPK = False
        Me.txtModeloVehiculo.IsRequired = False
        Me.txtModeloVehiculo.Key = ""
        Me.txtModeloVehiculo.LabelAsoc = Nothing
        Me.txtModeloVehiculo.Location = New System.Drawing.Point(195, 46)
        Me.txtModeloVehiculo.MaxLength = 100
        Me.txtModeloVehiculo.Name = "txtModeloVehiculo"
        Me.txtModeloVehiculo.ReadOnly = True
        Me.txtModeloVehiculo.Size = New System.Drawing.Size(180, 20)
        Me.txtModeloVehiculo.TabIndex = 4
        '
        'txtMarcaVehiculo
        '
        Me.txtMarcaVehiculo.BindearPropiedadControl = Nothing
        Me.txtMarcaVehiculo.BindearPropiedadEntidad = Nothing
        Me.txtMarcaVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMarcaVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMarcaVehiculo.Formato = ""
        Me.txtMarcaVehiculo.IsDecimal = False
        Me.txtMarcaVehiculo.IsNumber = False
        Me.txtMarcaVehiculo.IsPK = False
        Me.txtMarcaVehiculo.IsRequired = False
        Me.txtMarcaVehiculo.Key = ""
        Me.txtMarcaVehiculo.LabelAsoc = Nothing
        Me.txtMarcaVehiculo.Location = New System.Drawing.Point(10, 46)
        Me.txtMarcaVehiculo.MaxLength = 100
        Me.txtMarcaVehiculo.Name = "txtMarcaVehiculo"
        Me.txtMarcaVehiculo.ReadOnly = True
        Me.txtMarcaVehiculo.Size = New System.Drawing.Size(180, 20)
        Me.txtMarcaVehiculo.TabIndex = 3
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = Nothing
        Me.txtColor.BindearPropiedadEntidad = Nothing
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Nothing
        Me.txtColor.Location = New System.Drawing.Point(270, 24)
        Me.txtColor.MaxLength = 100
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(105, 20)
        Me.txtColor.TabIndex = 2
        '
        'txtAnioPatentamiento
        '
        Me.txtAnioPatentamiento.BindearPropiedadControl = Nothing
        Me.txtAnioPatentamiento.BindearPropiedadEntidad = Nothing
        Me.txtAnioPatentamiento.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAnioPatentamiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAnioPatentamiento.Formato = ""
        Me.txtAnioPatentamiento.IsDecimal = False
        Me.txtAnioPatentamiento.IsNumber = False
        Me.txtAnioPatentamiento.IsPK = False
        Me.txtAnioPatentamiento.IsRequired = False
        Me.txtAnioPatentamiento.Key = ""
        Me.txtAnioPatentamiento.LabelAsoc = Nothing
        Me.txtAnioPatentamiento.Location = New System.Drawing.Point(161, 24)
        Me.txtAnioPatentamiento.MaxLength = 100
        Me.txtAnioPatentamiento.Name = "txtAnioPatentamiento"
        Me.txtAnioPatentamiento.ReadOnly = True
        Me.txtAnioPatentamiento.Size = New System.Drawing.Size(105, 20)
        Me.txtAnioPatentamiento.TabIndex = 1
        '
        'llbCliente
        '
        Me.llbCliente.AutoSize = True
        Me.llbCliente.LabelAsoc = Nothing
        Me.llbCliente.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbCliente.Location = New System.Drawing.Point(7, 11)
        Me.llbCliente.Name = "llbCliente"
        Me.llbCliente.Size = New System.Drawing.Size(55, 13)
        Me.llbCliente.TabIndex = 5
        Me.llbCliente.TabStop = True
        Me.llbCliente.Text = "más info..."
        '
        'ucNovedadesVehiculos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.MaximumSize = New System.Drawing.Size(400, 70)
        Me.Name = "ucNovedadesVehiculos"
        Me.Size = New System.Drawing.Size(385, 70)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bscCodigoVehiculo As Controles.Buscador2
   Friend WithEvents txtModeloVehiculo As Controles.TextBox
   Friend WithEvents txtMarcaVehiculo As Controles.TextBox
   Friend WithEvents txtColor As Controles.TextBox
   Friend WithEvents txtAnioPatentamiento As Controles.TextBox
    Friend WithEvents llbCliente As Controles.LinkLabel
End Class
