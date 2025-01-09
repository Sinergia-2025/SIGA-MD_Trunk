<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaisesDetalle
   Inherits BaseDetalle

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
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
        Me.txtCodigoAfip = New Eniac.Controles.TextBox()
        Me.lblCodigoAfip = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(254, 123)
        Me.btnAceptar.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(340, 123)
        Me.btnCancelar.TabIndex = 7
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(153, 123)
        Me.btnCopiar.TabIndex = 9
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(96, 123)
        Me.btnAplicar.TabIndex = 8
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(30, 48)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombrePais"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(102, 42)
        Me.txtNombre.MaxLength = 30
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(275, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(30, 20)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Código"
        '
        'txtId
        '
        Me.txtId.BindearPropiedadControl = "Text"
        Me.txtId.BindearPropiedadEntidad = "IdPais"
        Me.txtId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtId.Formato = ""
        Me.txtId.IsDecimal = False
        Me.txtId.IsNumber = False
        Me.txtId.IsPK = True
        Me.txtId.IsRequired = True
        Me.txtId.Key = ""
        Me.txtId.LabelAsoc = Me.lblId
        Me.txtId.Location = New System.Drawing.Point(102, 17)
        Me.txtId.MaxLength = 3
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(48, 20)
        Me.txtId.TabIndex = 1
        '
        'txtCodigoAfip
        '
        Me.txtCodigoAfip.BindearPropiedadControl = "Text"
        Me.txtCodigoAfip.BindearPropiedadEntidad = "IdAfipPais"
        Me.txtCodigoAfip.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoAfip.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoAfip.Formato = ""
        Me.txtCodigoAfip.IsDecimal = False
        Me.txtCodigoAfip.IsNumber = False
        Me.txtCodigoAfip.IsPK = False
        Me.txtCodigoAfip.IsRequired = True
        Me.txtCodigoAfip.Key = ""
        Me.txtCodigoAfip.LabelAsoc = Me.lblCodigoAfip
        Me.txtCodigoAfip.Location = New System.Drawing.Point(102, 73)
        Me.txtCodigoAfip.MaxLength = 30
        Me.txtCodigoAfip.Name = "txtCodigoAfip"
        Me.txtCodigoAfip.Size = New System.Drawing.Size(48, 20)
        Me.txtCodigoAfip.TabIndex = 5
        '
        'lblCodigoAfip
        '
        Me.lblCodigoAfip.AutoSize = True
        Me.lblCodigoAfip.LabelAsoc = Nothing
        Me.lblCodigoAfip.Location = New System.Drawing.Point(30, 76)
        Me.lblCodigoAfip.Name = "lblCodigoAfip"
        Me.lblCodigoAfip.Size = New System.Drawing.Size(66, 13)
        Me.lblCodigoAfip.TabIndex = 4
        Me.lblCodigoAfip.Text = "Código AFIP"
        '
        'PaisesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 158)
        Me.Controls.Add(Me.txtCodigoAfip)
        Me.Controls.Add(Me.lblCodigoAfip)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Name = "PaisesDetalle"
        Me.Text = "País"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtId, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoAfip, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoAfip, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
    Friend WithEvents txtCodigoAfip As Controles.TextBox
    Friend WithEvents lblCodigoAfip As Controles.Label
End Class
