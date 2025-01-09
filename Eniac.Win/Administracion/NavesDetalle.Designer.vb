<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NavesDetalle
   Inherits Eniac.Win.BaseDetalle

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
        Me.lblIdNave = New Eniac.Controles.Label()
        Me.txtIdNave = New Eniac.Controles.TextBox()
        Me.lblNombreNave = New Eniac.Controles.Label()
        Me.txtNombreNave = New Eniac.Controles.TextBox()
        Me.txtNombrePC = New Eniac.Controles.TextBox()
        Me.lblNombrePC = New Eniac.Controles.Label()
        Me.chbMantenimiento = New Eniac.Controles.CheckBox()
        Me.txtLimiteDeKilos = New Eniac.Controles.TextBox()
        Me.lblLimiteDeKilos = New Eniac.Controles.Label()
        Me.lblTipoNave = New Eniac.Controles.Label()
        Me.cmbTipoNave = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(131, 188)
        Me.btnAceptar.TabIndex = 11
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(224, 188)
        Me.btnCancelar.TabIndex = 12
        '
        'btnCopiar
        '
        Me.btnCopiar.TabIndex = 14
        '
        'btnAplicar
        '
        Me.btnAplicar.TabIndex = 13
        '
        'lblIdNave
        '
        Me.lblIdNave.AutoSize = True
        Me.lblIdNave.LabelAsoc = Nothing
        Me.lblIdNave.Location = New System.Drawing.Point(22, 28)
        Me.lblIdNave.Name = "lblIdNave"
        Me.lblIdNave.Size = New System.Drawing.Size(40, 13)
        Me.lblIdNave.TabIndex = 0
        Me.lblIdNave.Text = "Codigo"
        '
        'txtIdNave
        '
        Me.txtIdNave.BindearPropiedadControl = "Text"
        Me.txtIdNave.BindearPropiedadEntidad = "IdNave"
        Me.txtIdNave.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdNave.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdNave.Formato = ""
        Me.txtIdNave.IsDecimal = False
        Me.txtIdNave.IsNumber = True
        Me.txtIdNave.IsPK = True
        Me.txtIdNave.IsRequired = True
        Me.txtIdNave.Key = ""
        Me.txtIdNave.LabelAsoc = Me.lblIdNave
        Me.txtIdNave.Location = New System.Drawing.Point(104, 25)
        Me.txtIdNave.MaxLength = 1
        Me.txtIdNave.Name = "txtIdNave"
        Me.txtIdNave.Size = New System.Drawing.Size(25, 20)
        Me.txtIdNave.TabIndex = 1
        Me.txtIdNave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreNave
        '
        Me.lblNombreNave.AutoSize = True
        Me.lblNombreNave.LabelAsoc = Nothing
        Me.lblNombreNave.Location = New System.Drawing.Point(22, 55)
        Me.lblNombreNave.Name = "lblNombreNave"
        Me.lblNombreNave.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreNave.TabIndex = 2
        Me.lblNombreNave.Text = "Nombre"
        '
        'txtNombreNave
        '
        Me.txtNombreNave.BindearPropiedadControl = "Text"
        Me.txtNombreNave.BindearPropiedadEntidad = "NombreNave"
        Me.txtNombreNave.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreNave.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreNave.Formato = ""
        Me.txtNombreNave.IsDecimal = False
        Me.txtNombreNave.IsNumber = False
        Me.txtNombreNave.IsPK = False
        Me.txtNombreNave.IsRequired = True
        Me.txtNombreNave.Key = ""
        Me.txtNombreNave.LabelAsoc = Me.lblNombreNave
        Me.txtNombreNave.Location = New System.Drawing.Point(104, 52)
        Me.txtNombreNave.MaxLength = 20
        Me.txtNombreNave.Name = "txtNombreNave"
        Me.txtNombreNave.Size = New System.Drawing.Size(90, 20)
        Me.txtNombreNave.TabIndex = 3
        '
        'txtNombrePC
        '
        Me.txtNombrePC.BindearPropiedadControl = "Text"
        Me.txtNombrePC.BindearPropiedadEntidad = "NombrePC"
        Me.txtNombrePC.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombrePC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombrePC.Formato = ""
        Me.txtNombrePC.IsDecimal = False
        Me.txtNombrePC.IsNumber = False
        Me.txtNombrePC.IsPK = False
        Me.txtNombrePC.IsRequired = True
        Me.txtNombrePC.Key = ""
        Me.txtNombrePC.LabelAsoc = Me.lblNombrePC
        Me.txtNombrePC.Location = New System.Drawing.Point(104, 78)
        Me.txtNombrePC.MaxLength = 20
        Me.txtNombrePC.Name = "txtNombrePC"
        Me.txtNombrePC.Size = New System.Drawing.Size(90, 20)
        Me.txtNombrePC.TabIndex = 5
        '
        'lblNombrePC
        '
        Me.lblNombrePC.AutoSize = True
        Me.lblNombrePC.LabelAsoc = Nothing
        Me.lblNombrePC.Location = New System.Drawing.Point(22, 81)
        Me.lblNombrePC.Name = "lblNombrePC"
        Me.lblNombrePC.Size = New System.Drawing.Size(21, 13)
        Me.lblNombrePC.TabIndex = 4
        Me.lblNombrePC.Text = "PC"
        '
        'chbMantenimiento
        '
        Me.chbMantenimiento.AutoSize = True
        Me.chbMantenimiento.BindearPropiedadControl = "Checked"
        Me.chbMantenimiento.BindearPropiedadEntidad = "EnMantenimiento"
        Me.chbMantenimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMantenimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMantenimiento.IsPK = False
        Me.chbMantenimiento.IsRequired = False
        Me.chbMantenimiento.Key = Nothing
        Me.chbMantenimiento.LabelAsoc = Nothing
        Me.chbMantenimiento.Location = New System.Drawing.Point(104, 158)
        Me.chbMantenimiento.Name = "chbMantenimiento"
        Me.chbMantenimiento.Size = New System.Drawing.Size(111, 17)
        Me.chbMantenimiento.TabIndex = 10
        Me.chbMantenimiento.Text = "En Mantenimiento"
        Me.chbMantenimiento.UseVisualStyleBackColor = True
        '
        'txtLimiteDeKilos
        '
        Me.txtLimiteDeKilos.BindearPropiedadControl = "Text"
        Me.txtLimiteDeKilos.BindearPropiedadEntidad = "LimiteDeKilos"
        Me.txtLimiteDeKilos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLimiteDeKilos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLimiteDeKilos.Formato = ""
        Me.txtLimiteDeKilos.IsDecimal = False
        Me.txtLimiteDeKilos.IsNumber = True
        Me.txtLimiteDeKilos.IsPK = False
        Me.txtLimiteDeKilos.IsRequired = True
        Me.txtLimiteDeKilos.Key = ""
        Me.txtLimiteDeKilos.LabelAsoc = Me.lblLimiteDeKilos
        Me.txtLimiteDeKilos.Location = New System.Drawing.Point(104, 104)
        Me.txtLimiteDeKilos.MaxLength = 20
        Me.txtLimiteDeKilos.Name = "txtLimiteDeKilos"
        Me.txtLimiteDeKilos.Size = New System.Drawing.Size(60, 20)
        Me.txtLimiteDeKilos.TabIndex = 7
        Me.txtLimiteDeKilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLimiteDeKilos
        '
        Me.lblLimiteDeKilos.AutoSize = True
        Me.lblLimiteDeKilos.LabelAsoc = Nothing
        Me.lblLimiteDeKilos.Location = New System.Drawing.Point(22, 107)
        Me.lblLimiteDeKilos.Name = "lblLimiteDeKilos"
        Me.lblLimiteDeKilos.Size = New System.Drawing.Size(74, 13)
        Me.lblLimiteDeKilos.TabIndex = 6
        Me.lblLimiteDeKilos.Text = "Limite de Kilos"
        '
        'lblTipoNave
        '
        Me.lblTipoNave.AutoSize = True
        Me.lblTipoNave.LabelAsoc = Nothing
        Me.lblTipoNave.Location = New System.Drawing.Point(22, 134)
        Me.lblTipoNave.Name = "lblTipoNave"
        Me.lblTipoNave.Size = New System.Drawing.Size(70, 13)
        Me.lblTipoNave.TabIndex = 8
        Me.lblTipoNave.Text = "Tipo de nave"
        '
        'cmbTipoNave
        '
        Me.cmbTipoNave.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoNave.BindearPropiedadEntidad = "IdTipoNave"
        Me.cmbTipoNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNave.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoNave.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoNave.FormattingEnabled = True
        Me.cmbTipoNave.IsPK = False
        Me.cmbTipoNave.IsRequired = True
        Me.cmbTipoNave.Key = Nothing
        Me.cmbTipoNave.LabelAsoc = Me.lblTipoNave
        Me.cmbTipoNave.Location = New System.Drawing.Point(104, 131)
        Me.cmbTipoNave.Name = "cmbTipoNave"
        Me.cmbTipoNave.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoNave.TabIndex = 9
        '
        'NavesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 236)
        Me.Controls.Add(Me.cmbTipoNave)
        Me.Controls.Add(Me.txtLimiteDeKilos)
        Me.Controls.Add(Me.lblTipoNave)
        Me.Controls.Add(Me.lblLimiteDeKilos)
        Me.Controls.Add(Me.chbMantenimiento)
        Me.Controls.Add(Me.txtNombrePC)
        Me.Controls.Add(Me.lblNombrePC)
        Me.Controls.Add(Me.txtNombreNave)
        Me.Controls.Add(Me.lblNombreNave)
        Me.Controls.Add(Me.lblIdNave)
        Me.Controls.Add(Me.txtIdNave)
        Me.Name = "NavesDetalle"
        Me.Text = "Nave"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtIdNave, 0)
        Me.Controls.SetChildIndex(Me.lblIdNave, 0)
        Me.Controls.SetChildIndex(Me.lblNombreNave, 0)
        Me.Controls.SetChildIndex(Me.txtNombreNave, 0)
        Me.Controls.SetChildIndex(Me.lblNombrePC, 0)
        Me.Controls.SetChildIndex(Me.txtNombrePC, 0)
        Me.Controls.SetChildIndex(Me.chbMantenimiento, 0)
        Me.Controls.SetChildIndex(Me.lblLimiteDeKilos, 0)
        Me.Controls.SetChildIndex(Me.lblTipoNave, 0)
        Me.Controls.SetChildIndex(Me.txtLimiteDeKilos, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoNave, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIdNave As Eniac.Controles.Label
    Friend WithEvents txtIdNave As Eniac.Controles.TextBox
    Friend WithEvents lblNombreNave As Eniac.Controles.Label
    Friend WithEvents txtNombreNave As Eniac.Controles.TextBox
    Friend WithEvents txtNombrePC As Eniac.Controles.TextBox
    Friend WithEvents lblNombrePC As Eniac.Controles.Label
    Friend WithEvents chbMantenimiento As Eniac.Controles.CheckBox
    Friend WithEvents txtLimiteDeKilos As Eniac.Controles.TextBox
    Friend WithEvents lblLimiteDeKilos As Eniac.Controles.Label
    Friend WithEvents lblTipoNave As Eniac.Controles.Label
    Friend WithEvents cmbTipoNave As Eniac.Controles.ComboBox
End Class
