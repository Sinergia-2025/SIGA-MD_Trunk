<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesProyectos
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
      Me.txtEstado = New Eniac.Controles.TextBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.bscCodigoProyecto = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscProyecto = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblPrioridad = New Eniac.Controles.Label()
      Me.txtPrioridad = New Eniac.Controles.TextBox()
      Me.lblClasificacion = New Eniac.Controles.Label()
      Me.txtClasificacion = New Eniac.Controles.TextBox()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.txtClasificacion)
      Me.GroupBox1.Controls.Add(Me.lblClasificacion)
      Me.GroupBox1.Controls.Add(Me.txtPrioridad)
      Me.GroupBox1.Controls.Add(Me.lblPrioridad)
      Me.GroupBox1.Controls.Add(Me.txtEstado)
      Me.GroupBox1.Controls.Add(Me.bscCodigoProyecto)
      Me.GroupBox1.Controls.Add(Me.lblEstado)
      Me.GroupBox1.Controls.Add(Me.bscProyecto)
      Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
      Me.GroupBox1.Controls.Add(Me.lblNombre)
      Me.GroupBox1.Size = New System.Drawing.Size(385, 75)
      Me.GroupBox1.Text = "Proyecto"
      '
      'txtEstado
      '
      Me.txtEstado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtEstado.BindearPropiedadControl = ""
      Me.txtEstado.BindearPropiedadEntidad = ""
      Me.txtEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEstado.Formato = ""
      Me.txtEstado.IsDecimal = False
      Me.txtEstado.IsNumber = False
      Me.txtEstado.IsPK = False
      Me.txtEstado.IsRequired = False
      Me.txtEstado.Key = ""
      Me.txtEstado.LabelAsoc = Me.lblEstado
      Me.txtEstado.Location = New System.Drawing.Point(295, 51)
      Me.txtEstado.Margin = New System.Windows.Forms.Padding(1)
      Me.txtEstado.Name = "txtEstado"
      Me.txtEstado.ReadOnly = True
      Me.txtEstado.Size = New System.Drawing.Size(85, 20)
      Me.txtEstado.TabIndex = 9
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(251, 54)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 8
      Me.lblEstado.Text = "Estado"
      '
      'bscCodigoProyecto
      '
      Me.bscCodigoProyecto.ActivarFiltroEnGrilla = True
      Me.bscCodigoProyecto.BindearPropiedadControl = Nothing
      Me.bscCodigoProyecto.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProyecto.ConfigBuscador = Nothing
      Me.bscCodigoProyecto.Datos = Nothing
      Me.bscCodigoProyecto.FilaDevuelta = Nothing
      Me.bscCodigoProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProyecto.IsDecimal = False
      Me.bscCodigoProyecto.IsNumber = False
      Me.bscCodigoProyecto.IsPK = False
      Me.bscCodigoProyecto.IsRequired = False
      Me.bscCodigoProyecto.Key = ""
      Me.bscCodigoProyecto.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoProyecto.Location = New System.Drawing.Point(5, 27)
      Me.bscCodigoProyecto.MaxLengh = "32767"
      Me.bscCodigoProyecto.Name = "bscCodigoProyecto"
      Me.bscCodigoProyecto.Permitido = True
      Me.bscCodigoProyecto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProyecto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProyecto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProyecto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProyecto.Selecciono = False
      Me.bscCodigoProyecto.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoProyecto.TabIndex = 1
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(5, 13)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 0
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscProyecto
      '
      Me.bscProyecto.ActivarFiltroEnGrilla = True
      Me.bscProyecto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProyecto.BindearPropiedadControl = Nothing
      Me.bscProyecto.BindearPropiedadEntidad = Nothing
      Me.bscProyecto.ConfigBuscador = Nothing
      Me.bscProyecto.Datos = Nothing
      Me.bscProyecto.FilaDevuelta = Nothing
      Me.bscProyecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProyecto.IsDecimal = False
      Me.bscProyecto.IsNumber = False
      Me.bscProyecto.IsPK = False
      Me.bscProyecto.IsRequired = False
      Me.bscProyecto.Key = ""
      Me.bscProyecto.LabelAsoc = Me.lblNombre
      Me.bscProyecto.Location = New System.Drawing.Point(99, 26)
      Me.bscProyecto.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProyecto.MaxLengh = "32767"
      Me.bscProyecto.Name = "bscProyecto"
      Me.bscProyecto.Permitido = True
      Me.bscProyecto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProyecto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProyecto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProyecto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProyecto.Selecciono = False
      Me.bscProyecto.Size = New System.Drawing.Size(281, 23)
      Me.bscProyecto.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(96, 13)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "&Nombre"
      '
      'lblPrioridad
      '
      Me.lblPrioridad.AutoSize = True
      Me.lblPrioridad.LabelAsoc = Nothing
      Me.lblPrioridad.Location = New System.Drawing.Point(2, 54)
      Me.lblPrioridad.Name = "lblPrioridad"
      Me.lblPrioridad.Size = New System.Drawing.Size(48, 13)
      Me.lblPrioridad.TabIndex = 4
      Me.lblPrioridad.Text = "Prioridad"
      '
      'txtPrioridad
      '
      Me.txtPrioridad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPrioridad.BindearPropiedadControl = ""
      Me.txtPrioridad.BindearPropiedadEntidad = ""
      Me.txtPrioridad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrioridad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrioridad.Formato = ""
      Me.txtPrioridad.IsDecimal = False
      Me.txtPrioridad.IsNumber = False
      Me.txtPrioridad.IsPK = False
      Me.txtPrioridad.IsRequired = False
      Me.txtPrioridad.Key = ""
      Me.txtPrioridad.LabelAsoc = Me.lblEstado
      Me.txtPrioridad.Location = New System.Drawing.Point(54, 51)
      Me.txtPrioridad.Margin = New System.Windows.Forms.Padding(1)
      Me.txtPrioridad.Name = "txtPrioridad"
      Me.txtPrioridad.ReadOnly = True
      Me.txtPrioridad.Size = New System.Drawing.Size(28, 20)
      Me.txtPrioridad.TabIndex = 5
      '
      'lblClasificacion
      '
      Me.lblClasificacion.AutoSize = True
      Me.lblClasificacion.LabelAsoc = Nothing
      Me.lblClasificacion.Location = New System.Drawing.Point(96, 53)
      Me.lblClasificacion.Name = "lblClasificacion"
      Me.lblClasificacion.Size = New System.Drawing.Size(66, 13)
      Me.lblClasificacion.TabIndex = 6
      Me.lblClasificacion.Text = "Clasificación"
      '
      'txtClasificacion
      '
      Me.txtClasificacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtClasificacion.BindearPropiedadControl = ""
      Me.txtClasificacion.BindearPropiedadEntidad = ""
      Me.txtClasificacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtClasificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtClasificacion.Formato = ""
      Me.txtClasificacion.IsDecimal = False
      Me.txtClasificacion.IsNumber = False
      Me.txtClasificacion.IsPK = False
      Me.txtClasificacion.IsRequired = False
      Me.txtClasificacion.Key = ""
      Me.txtClasificacion.LabelAsoc = Me.lblEstado
      Me.txtClasificacion.Location = New System.Drawing.Point(166, 50)
      Me.txtClasificacion.Margin = New System.Windows.Forms.Padding(1)
      Me.txtClasificacion.Name = "txtClasificacion"
      Me.txtClasificacion.ReadOnly = True
      Me.txtClasificacion.Size = New System.Drawing.Size(78, 20)
      Me.txtClasificacion.TabIndex = 7
      '
      'ucNovedadesProyectos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Margin = New System.Windows.Forms.Padding(0)
      Me.MaximumSize = New System.Drawing.Size(395, 100)
      Me.Name = "ucNovedadesProyectos"
      Me.Size = New System.Drawing.Size(385, 75)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents txtEstado As Eniac.Controles.TextBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents bscCodigoProyecto As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscProyecto As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtClasificacion As Eniac.Controles.TextBox
   Friend WithEvents lblClasificacion As Eniac.Controles.Label
   Friend WithEvents txtPrioridad As Eniac.Controles.TextBox
   Friend WithEvents lblPrioridad As Eniac.Controles.Label

End Class
