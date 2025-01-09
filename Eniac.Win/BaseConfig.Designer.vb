<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseConfig
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseConfig))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.chbEjecutaAlerta = New Eniac.Controles.CheckBox()
      Me.chbEjecutaAsync = New Eniac.Controles.CheckBox()
      Me.lblServidor = New Eniac.Controles.Label()
      Me.txtServidor = New Eniac.Controles.TextBox()
      Me.txtBaseDefecto = New Eniac.Controles.TextBox()
      Me.lblBaseDefecto = New Eniac.Controles.Label()
        Me.lblMinutosAlertas = New Eniac.Controles.Label()
        Me.txtMinutosAlertas = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(160, 134)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(246, 134)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'chbEjecutaAlerta
        '
        Me.chbEjecutaAlerta.AutoSize = True
        Me.chbEjecutaAlerta.BindearPropiedadControl = Nothing
        Me.chbEjecutaAlerta.BindearPropiedadEntidad = Nothing
        Me.chbEjecutaAlerta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEjecutaAlerta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEjecutaAlerta.IsPK = False
        Me.chbEjecutaAlerta.IsRequired = False
        Me.chbEjecutaAlerta.Key = Nothing
        Me.chbEjecutaAlerta.LabelAsoc = Nothing
        Me.chbEjecutaAlerta.Location = New System.Drawing.Point(16, 23)
        Me.chbEjecutaAlerta.Name = "chbEjecutaAlerta"
        Me.chbEjecutaAlerta.Size = New System.Drawing.Size(97, 17)
        Me.chbEjecutaAlerta.TabIndex = 0
        Me.chbEjecutaAlerta.Text = "Ejecuta Alertas"
        Me.chbEjecutaAlerta.UseVisualStyleBackColor = True
        '
        'chbEjecutaAsync
        '
        Me.chbEjecutaAsync.AutoSize = True
        Me.chbEjecutaAsync.BindearPropiedadControl = Nothing
        Me.chbEjecutaAsync.BindearPropiedadEntidad = Nothing
        Me.chbEjecutaAsync.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEjecutaAsync.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEjecutaAsync.IsPK = False
        Me.chbEjecutaAsync.IsRequired = False
        Me.chbEjecutaAsync.Key = Nothing
        Me.chbEjecutaAsync.LabelAsoc = Nothing
        Me.chbEjecutaAsync.Location = New System.Drawing.Point(16, 46)
        Me.chbEjecutaAsync.Name = "chbEjecutaAsync"
        Me.chbEjecutaAsync.Size = New System.Drawing.Size(153, 17)
        Me.chbEjecutaAsync.TabIndex = 3
        Me.chbEjecutaAsync.Text = "Ejecuta Alertas en Paralelo"
        Me.chbEjecutaAsync.UseVisualStyleBackColor = True
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = True
        Me.lblServidor.LabelAsoc = Nothing
        Me.lblServidor.Location = New System.Drawing.Point(13, 73)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(46, 13)
        Me.lblServidor.TabIndex = 4
        Me.lblServidor.Text = "Servidor"
        '
        'txtServidor
        '
        Me.txtServidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServidor.BindearPropiedadControl = ""
        Me.txtServidor.BindearPropiedadEntidad = ""
        Me.txtServidor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtServidor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtServidor.Formato = ""
        Me.txtServidor.IsDecimal = False
        Me.txtServidor.IsNumber = False
        Me.txtServidor.IsPK = False
        Me.txtServidor.IsRequired = True
        Me.txtServidor.Key = ""
        Me.txtServidor.LabelAsoc = Me.lblServidor
        Me.txtServidor.Location = New System.Drawing.Point(89, 69)
        Me.txtServidor.MaxLength = 50
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(237, 20)
        Me.txtServidor.TabIndex = 5
        '
        'txtBaseDefecto
        '
        Me.txtBaseDefecto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBaseDefecto.BindearPropiedadControl = ""
        Me.txtBaseDefecto.BindearPropiedadEntidad = ""
        Me.txtBaseDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBaseDefecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBaseDefecto.Formato = ""
        Me.txtBaseDefecto.IsDecimal = False
        Me.txtBaseDefecto.IsNumber = False
        Me.txtBaseDefecto.IsPK = False
        Me.txtBaseDefecto.IsRequired = True
        Me.txtBaseDefecto.Key = ""
        Me.txtBaseDefecto.LabelAsoc = Me.lblBaseDefecto
        Me.txtBaseDefecto.Location = New System.Drawing.Point(89, 95)
        Me.txtBaseDefecto.MaxLength = 50
        Me.txtBaseDefecto.Name = "txtBaseDefecto"
        Me.txtBaseDefecto.Size = New System.Drawing.Size(237, 20)
        Me.txtBaseDefecto.TabIndex = 7
        '
        'lblBaseDefecto
        '
        Me.lblBaseDefecto.AutoSize = True
        Me.lblBaseDefecto.LabelAsoc = Nothing
        Me.lblBaseDefecto.Location = New System.Drawing.Point(13, 99)
        Me.lblBaseDefecto.Name = "lblBaseDefecto"
        Me.lblBaseDefecto.Size = New System.Drawing.Size(70, 13)
        Me.lblBaseDefecto.TabIndex = 6
        Me.lblBaseDefecto.Text = "Base defecto"
        '
        'lblMinutosAlertas
        '
        Me.lblMinutosAlertas.AutoSize = True
        Me.lblMinutosAlertas.LabelAsoc = Nothing
        Me.lblMinutosAlertas.Location = New System.Drawing.Point(151, 24)
        Me.lblMinutosAlertas.Name = "lblMinutosAlertas"
        Me.lblMinutosAlertas.Size = New System.Drawing.Size(89, 13)
        Me.lblMinutosAlertas.TabIndex = 1
        Me.lblMinutosAlertas.Text = "Minutos de Alerta"
        '
        'txtMinutosAlertas
        '
        Me.txtMinutosAlertas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMinutosAlertas.BindearPropiedadControl = ""
        Me.txtMinutosAlertas.BindearPropiedadEntidad = ""
        Me.txtMinutosAlertas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMinutosAlertas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMinutosAlertas.Formato = ""
        Me.txtMinutosAlertas.IsDecimal = False
        Me.txtMinutosAlertas.IsNumber = False
        Me.txtMinutosAlertas.IsPK = False
        Me.txtMinutosAlertas.IsRequired = True
        Me.txtMinutosAlertas.Key = ""
        Me.txtMinutosAlertas.LabelAsoc = Me.lblMinutosAlertas
        Me.txtMinutosAlertas.Location = New System.Drawing.Point(246, 20)
        Me.txtMinutosAlertas.MaxLength = 50
        Me.txtMinutosAlertas.Name = "txtMinutosAlertas"
        Me.txtMinutosAlertas.Size = New System.Drawing.Size(70, 20)
        Me.txtMinutosAlertas.TabIndex = 2
        Me.txtMinutosAlertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BaseConfig
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(338, 176)
        Me.Controls.Add(Me.lblMinutosAlertas)
        Me.Controls.Add(Me.txtMinutosAlertas)
        Me.Controls.Add(Me.lblBaseDefecto)
        Me.Controls.Add(Me.lblServidor)
        Me.Controls.Add(Me.txtBaseDefecto)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.chbEjecutaAsync)
        Me.Controls.Add(Me.chbEjecutaAlerta)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "BaseConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents chbEjecutaAlerta As Eniac.Controles.CheckBox
   Friend WithEvents chbEjecutaAsync As Eniac.Controles.CheckBox
   Friend WithEvents lblServidor As Eniac.Controles.Label
   Friend WithEvents txtServidor As Eniac.Controles.TextBox
   Friend WithEvents txtBaseDefecto As Eniac.Controles.TextBox
   Friend WithEvents lblBaseDefecto As Eniac.Controles.Label
    Friend WithEvents lblMinutosAlertas As Controles.Label
    Friend WithEvents txtMinutosAlertas As Controles.TextBox
End Class
