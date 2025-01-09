<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposNavesDetalle
    Inherits Win.BaseDetalle

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TiposNavesDetalle))
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtNombre = New Eniac.Controles.TextBox()
        Me.lblId = New Eniac.Controles.Label()
        Me.txtId = New Eniac.Controles.TextBox()
        Me.chkAreaComun = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(330, 203)
        Me.btnAceptar.TabIndex = 15
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(421, 203)
        Me.btnCancelar.TabIndex = 16
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(26, 50)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreTipoNave"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(76, 47)
        Me.txtNombre.MaxLength = 60
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(422, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(26, 24)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Código"
        '
        'txtId
        '
        Me.txtId.BindearPropiedadControl = "Text"
        Me.txtId.BindearPropiedadEntidad = "IdTipoNave"
        Me.txtId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtId.Formato = ""
        Me.txtId.IsDecimal = False
        Me.txtId.IsNumber = True
        Me.txtId.IsPK = True
        Me.txtId.IsRequired = True
        Me.txtId.Key = ""
        Me.txtId.LabelAsoc = Me.lblId
        Me.txtId.Location = New System.Drawing.Point(76, 21)
        Me.txtId.MaxLength = 5
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(88, 20)
        Me.txtId.TabIndex = 1
        '
        'chkAreaComun
        '
        Me.chkAreaComun.AutoSize = True
        Me.chkAreaComun.BindearPropiedadControl = "Checked"
        Me.chkAreaComun.BindearPropiedadEntidad = "Seco"
        Me.chkAreaComun.ForeColorFocus = System.Drawing.Color.Red
        Me.chkAreaComun.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkAreaComun.IsPK = False
        Me.chkAreaComun.IsRequired = False
        Me.chkAreaComun.Key = Nothing
        Me.chkAreaComun.LabelAsoc = Nothing
        Me.chkAreaComun.Location = New System.Drawing.Point(76, 73)
        Me.chkAreaComun.Name = "chkAreaComun"
        Me.chkAreaComun.Size = New System.Drawing.Size(51, 17)
        Me.chkAreaComun.TabIndex = 17
        Me.chkAreaComun.Text = "Seco"
        Me.chkAreaComun.UseVisualStyleBackColor = True
        '
        'TiposNavesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 238)
        Me.Controls.Add(Me.chkAreaComun)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TiposNavesDetalle"
        Me.Text = "Tipo de nave"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtId, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.chkAreaComun, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
    Friend WithEvents txtNombre As Eniac.Controles.TextBox
    Friend WithEvents lblId As Eniac.Controles.Label
    Friend WithEvents txtId As Eniac.Controles.TextBox
    Friend WithEvents chkAreaComun As Eniac.Controles.CheckBox
End Class
