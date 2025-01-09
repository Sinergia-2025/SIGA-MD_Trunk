<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposDeExensionDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TiposDeExensionDetalle))
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtNombreTipoDeExension = New Eniac.Controles.TextBox()
        Me.lblId = New Eniac.Controles.Label()
        Me.txtIdTipoDeExension = New Eniac.Controles.TextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.txtNombreTipoDeExensionAbrev = New Eniac.Controles.TextBox()
        Me.chbActivo = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(196, 115)
        Me.btnAceptar.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(292, 115)
        Me.btnCancelar.TabIndex = 7
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(28, 45)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombreTipoDeExension
        '
        Me.txtNombreTipoDeExension.BindearPropiedadControl = "Text"
        Me.txtNombreTipoDeExension.BindearPropiedadEntidad = "NombreTipoDeExension"
        Me.txtNombreTipoDeExension.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreTipoDeExension.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreTipoDeExension.Formato = ""
        Me.txtNombreTipoDeExension.IsDecimal = False
        Me.txtNombreTipoDeExension.IsNumber = False
        Me.txtNombreTipoDeExension.IsPK = False
        Me.txtNombreTipoDeExension.IsRequired = True
        Me.txtNombreTipoDeExension.Key = ""
        Me.txtNombreTipoDeExension.LabelAsoc = Me.lblNombre
        Me.txtNombreTipoDeExension.Location = New System.Drawing.Point(106, 41)
        Me.txtNombreTipoDeExension.MaxLength = 30
        Me.txtNombreTipoDeExension.Name = "txtNombreTipoDeExension"
        Me.txtNombreTipoDeExension.Size = New System.Drawing.Size(275, 20)
        Me.txtNombreTipoDeExension.TabIndex = 0
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(28, 17)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 1
        Me.lblId.Text = "Código"
        '
        'txtIdTipoDeExension
        '
        Me.txtIdTipoDeExension.BindearPropiedadControl = "Text"
        Me.txtIdTipoDeExension.BindearPropiedadEntidad = "IdTipoDeExension"
        Me.txtIdTipoDeExension.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTipoDeExension.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTipoDeExension.Formato = ""
        Me.txtIdTipoDeExension.IsDecimal = False
        Me.txtIdTipoDeExension.IsNumber = True
        Me.txtIdTipoDeExension.IsPK = True
        Me.txtIdTipoDeExension.IsRequired = True
        Me.txtIdTipoDeExension.Key = ""
        Me.txtIdTipoDeExension.LabelAsoc = Me.lblId
        Me.txtIdTipoDeExension.Location = New System.Drawing.Point(106, 13)
        Me.txtIdTipoDeExension.MaxLength = 4
        Me.txtIdTipoDeExension.Name = "txtIdTipoDeExension"
        Me.txtIdTipoDeExension.Size = New System.Drawing.Size(55, 20)
        Me.txtIdTipoDeExension.TabIndex = 0
        Me.txtIdTipoDeExension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Nombre Abrev."
        '
        'txtNombreTipoDeExensionAbrev
        '
        Me.txtNombreTipoDeExensionAbrev.BindearPropiedadControl = "Text"
        Me.txtNombreTipoDeExensionAbrev.BindearPropiedadEntidad = "NombreTipoDeExensionAbrev"
        Me.txtNombreTipoDeExensionAbrev.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreTipoDeExensionAbrev.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreTipoDeExensionAbrev.Formato = ""
        Me.txtNombreTipoDeExensionAbrev.IsDecimal = False
        Me.txtNombreTipoDeExensionAbrev.IsNumber = False
        Me.txtNombreTipoDeExensionAbrev.IsPK = False
        Me.txtNombreTipoDeExensionAbrev.IsRequired = True
        Me.txtNombreTipoDeExensionAbrev.Key = ""
        Me.txtNombreTipoDeExensionAbrev.LabelAsoc = Me.Label1
        Me.txtNombreTipoDeExensionAbrev.Location = New System.Drawing.Point(106, 73)
        Me.txtNombreTipoDeExensionAbrev.MaxLength = 10
        Me.txtNombreTipoDeExensionAbrev.Name = "txtNombreTipoDeExensionAbrev"
        Me.txtNombreTipoDeExensionAbrev.Size = New System.Drawing.Size(104, 20)
        Me.txtNombreTipoDeExensionAbrev.TabIndex = 1
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.Checked = True
        Me.chbActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(323, 15)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 10
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'TiposDeExensionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(391, 162)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombreTipoDeExensionAbrev)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombreTipoDeExension)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtIdTipoDeExension)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TiposDeExensionDetalle"
        Me.Text = "Tipos de Exensión"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtIdTipoDeExension, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtNombreTipoDeExension, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtNombreTipoDeExensionAbrev, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
    Friend WithEvents txtNombreTipoDeExension As Eniac.Controles.TextBox
    Friend WithEvents lblId As Eniac.Controles.Label
    Friend WithEvents txtIdTipoDeExension As Eniac.Controles.TextBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents txtNombreTipoDeExensionAbrev As Eniac.Controles.TextBox
    Friend WithEvents chbActivo As Eniac.Controles.CheckBox

End Class
