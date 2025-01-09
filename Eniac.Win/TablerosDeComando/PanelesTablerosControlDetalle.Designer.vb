<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PanelesTablerosControlDetalle
    Inherits Win.BaseDetalle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblNombrePanel = New Eniac.Controles.Label()
        Me.txtNombrePanel = New Eniac.Controles.TextBox()
        Me.lblIdPanelTableroControl = New Eniac.Controles.Label()
        Me.txtIdPanelTableroControl = New Eniac.Controles.TextBox()
        Me.lblParametros = New Eniac.Controles.Label()
        Me.txtParametros = New Eniac.Controles.TextBox()
        Me.lblIdController = New Eniac.Controles.Label()
        Me.TextBox2 = New Eniac.Controles.TextBox()
        Me.txtColor1 = New Eniac.Controles.TextBox()
        Me.lblColor1 = New Eniac.Controles.Label()
        Me.btnBackColor1 = New System.Windows.Forms.Button()
        Me.btnForeColor1 = New System.Windows.Forms.Button()
        Me.btnBackColor2 = New System.Windows.Forms.Button()
        Me.lblColor2 = New Eniac.Controles.Label()
        Me.txtColor2 = New Eniac.Controles.TextBox()
        Me.btnForeColor2 = New System.Windows.Forms.Button()
        Me.chbBackColor1 = New Eniac.Controles.CheckBox()
        Me.chbBackColor2 = New Eniac.Controles.CheckBox()
        Me.chbForeColor2 = New Eniac.Controles.CheckBox()
        Me.chbForeColor1 = New Eniac.Controles.CheckBox()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(208, 206)
        Me.btnAceptar.TabIndex = 20
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(294, 206)
        Me.btnCancelar.TabIndex = 21
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(107, 206)
        Me.btnCopiar.TabIndex = 23
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(50, 206)
        Me.btnAplicar.TabIndex = 22
        '
        'lblNombrePanel
        '
        Me.lblNombrePanel.AutoSize = True
        Me.lblNombrePanel.LabelAsoc = Nothing
        Me.lblNombrePanel.Location = New System.Drawing.Point(5, 41)
        Me.lblNombrePanel.Name = "lblNombrePanel"
        Me.lblNombrePanel.Size = New System.Drawing.Size(44, 13)
        Me.lblNombrePanel.TabIndex = 2
        Me.lblNombrePanel.Text = "Nombre"
        '
        'txtNombrePanel
        '
        Me.txtNombrePanel.BindearPropiedadControl = "Text"
        Me.txtNombrePanel.BindearPropiedadEntidad = "NombrePanel"
        Me.txtNombrePanel.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombrePanel.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombrePanel.Formato = ""
        Me.txtNombrePanel.IsDecimal = False
        Me.txtNombrePanel.IsNumber = False
        Me.txtNombrePanel.IsPK = False
        Me.txtNombrePanel.IsRequired = True
        Me.txtNombrePanel.Key = ""
        Me.txtNombrePanel.LabelAsoc = Me.lblNombrePanel
        Me.txtNombrePanel.Location = New System.Drawing.Point(72, 38)
        Me.txtNombrePanel.MaxLength = 50
        Me.txtNombrePanel.Name = "txtNombrePanel"
        Me.txtNombrePanel.Size = New System.Drawing.Size(297, 20)
        Me.txtNombrePanel.TabIndex = 3
        '
        'lblIdPanelTableroControl
        '
        Me.lblIdPanelTableroControl.AutoSize = True
        Me.lblIdPanelTableroControl.LabelAsoc = Nothing
        Me.lblIdPanelTableroControl.Location = New System.Drawing.Point(5, 15)
        Me.lblIdPanelTableroControl.Name = "lblIdPanelTableroControl"
        Me.lblIdPanelTableroControl.Size = New System.Drawing.Size(40, 13)
        Me.lblIdPanelTableroControl.TabIndex = 0
        Me.lblIdPanelTableroControl.Text = "Código"
        '
        'txtIdPanelTableroControl
        '
        Me.txtIdPanelTableroControl.BindearPropiedadControl = "Text"
        Me.txtIdPanelTableroControl.BindearPropiedadEntidad = "IdTableroControlPanel"
        Me.txtIdPanelTableroControl.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdPanelTableroControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdPanelTableroControl.Formato = ""
        Me.txtIdPanelTableroControl.IsDecimal = False
        Me.txtIdPanelTableroControl.IsNumber = True
        Me.txtIdPanelTableroControl.IsPK = True
        Me.txtIdPanelTableroControl.IsRequired = True
        Me.txtIdPanelTableroControl.Key = ""
        Me.txtIdPanelTableroControl.LabelAsoc = Me.lblIdPanelTableroControl
        Me.txtIdPanelTableroControl.Location = New System.Drawing.Point(72, 12)
        Me.txtIdPanelTableroControl.MaxLength = 4
        Me.txtIdPanelTableroControl.Name = "txtIdPanelTableroControl"
        Me.txtIdPanelTableroControl.Size = New System.Drawing.Size(77, 20)
        Me.txtIdPanelTableroControl.TabIndex = 1
        Me.txtIdPanelTableroControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblParametros
        '
        Me.lblParametros.AutoSize = True
        Me.lblParametros.LabelAsoc = Nothing
        Me.lblParametros.Location = New System.Drawing.Point(5, 67)
        Me.lblParametros.Name = "lblParametros"
        Me.lblParametros.Size = New System.Drawing.Size(60, 13)
        Me.lblParametros.TabIndex = 4
        Me.lblParametros.Text = "Parametros"
        '
        'txtParametros
        '
        Me.txtParametros.BindearPropiedadControl = "Text"
        Me.txtParametros.BindearPropiedadEntidad = "Parametros"
        Me.txtParametros.ForeColorFocus = System.Drawing.Color.Red
        Me.txtParametros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtParametros.Formato = ""
        Me.txtParametros.IsDecimal = False
        Me.txtParametros.IsNumber = False
        Me.txtParametros.IsPK = False
        Me.txtParametros.IsRequired = True
        Me.txtParametros.Key = ""
        Me.txtParametros.LabelAsoc = Me.lblParametros
        Me.txtParametros.Location = New System.Drawing.Point(72, 64)
        Me.txtParametros.MaxLength = 50
        Me.txtParametros.Name = "txtParametros"
        Me.txtParametros.Size = New System.Drawing.Size(297, 20)
        Me.txtParametros.TabIndex = 5
        '
        'lblIdController
        '
        Me.lblIdController.AutoSize = True
        Me.lblIdController.LabelAsoc = Nothing
        Me.lblIdController.Location = New System.Drawing.Point(5, 93)
        Me.lblIdController.Name = "lblIdController"
        Me.lblIdController.Size = New System.Drawing.Size(61, 13)
        Me.lblIdController.TabIndex = 6
        Me.lblIdController.Text = "Controlador"
        '
        'TextBox2
        '
        Me.TextBox2.BindearPropiedadControl = "Text"
        Me.TextBox2.BindearPropiedadEntidad = "IdController"
        Me.TextBox2.ForeColorFocus = System.Drawing.Color.Red
        Me.TextBox2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.TextBox2.Formato = ""
        Me.TextBox2.IsDecimal = False
        Me.TextBox2.IsNumber = False
        Me.TextBox2.IsPK = False
        Me.TextBox2.IsRequired = True
        Me.TextBox2.Key = ""
        Me.TextBox2.LabelAsoc = Me.lblIdController
        Me.TextBox2.Location = New System.Drawing.Point(72, 90)
        Me.TextBox2.MaxLength = 50
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(297, 20)
        Me.TextBox2.TabIndex = 7
        '
        'txtColor1
        '
        Me.txtColor1.BindearPropiedadControl = ""
        Me.txtColor1.BindearPropiedadEntidad = ""
        Me.txtColor1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor1.Formato = ""
        Me.txtColor1.IsDecimal = False
        Me.txtColor1.IsNumber = False
        Me.txtColor1.IsPK = False
        Me.txtColor1.IsRequired = False
        Me.txtColor1.Key = ""
        Me.txtColor1.LabelAsoc = Me.lblColor1
        Me.txtColor1.Location = New System.Drawing.Point(72, 137)
        Me.txtColor1.Name = "txtColor1"
        Me.txtColor1.Size = New System.Drawing.Size(119, 20)
        Me.txtColor1.TabIndex = 9
        Me.txtColor1.TabStop = False
        Me.txtColor1.Text = "AaBbCcDdEeFf"
        Me.txtColor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblColor1
        '
        Me.lblColor1.AutoSize = True
        Me.lblColor1.LabelAsoc = Nothing
        Me.lblColor1.Location = New System.Drawing.Point(5, 141)
        Me.lblColor1.Name = "lblColor1"
        Me.lblColor1.Size = New System.Drawing.Size(40, 13)
        Me.lblColor1.TabIndex = 8
        Me.lblColor1.Text = "Color 1"
        '
        'btnBackColor1
        '
        Me.btnBackColor1.Enabled = False
        Me.btnBackColor1.Location = New System.Drawing.Point(218, 136)
        Me.btnBackColor1.Name = "btnBackColor1"
        Me.btnBackColor1.Size = New System.Drawing.Size(62, 23)
        Me.btnBackColor1.TabIndex = 11
        Me.btnBackColor1.Text = "Fondo"
        Me.btnBackColor1.UseVisualStyleBackColor = True
        '
        'btnForeColor1
        '
        Me.btnForeColor1.Enabled = False
        Me.btnForeColor1.Location = New System.Drawing.Point(307, 136)
        Me.btnForeColor1.Name = "btnForeColor1"
        Me.btnForeColor1.Size = New System.Drawing.Size(62, 23)
        Me.btnForeColor1.TabIndex = 13
        Me.btnForeColor1.Text = "Letra"
        Me.btnForeColor1.UseVisualStyleBackColor = True
        '
        'btnBackColor2
        '
        Me.btnBackColor2.Enabled = False
        Me.btnBackColor2.Location = New System.Drawing.Point(218, 163)
        Me.btnBackColor2.Name = "btnBackColor2"
        Me.btnBackColor2.Size = New System.Drawing.Size(62, 23)
        Me.btnBackColor2.TabIndex = 17
        Me.btnBackColor2.Text = "Fondo"
        Me.btnBackColor2.UseVisualStyleBackColor = True
        '
        'lblColor2
        '
        Me.lblColor2.AutoSize = True
        Me.lblColor2.LabelAsoc = Nothing
        Me.lblColor2.Location = New System.Drawing.Point(5, 168)
        Me.lblColor2.Name = "lblColor2"
        Me.lblColor2.Size = New System.Drawing.Size(40, 13)
        Me.lblColor2.TabIndex = 14
        Me.lblColor2.Text = "Color 2"
        '
        'txtColor2
        '
        Me.txtColor2.BindearPropiedadControl = ""
        Me.txtColor2.BindearPropiedadEntidad = ""
        Me.txtColor2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor2.Formato = ""
        Me.txtColor2.IsDecimal = False
        Me.txtColor2.IsNumber = False
        Me.txtColor2.IsPK = False
        Me.txtColor2.IsRequired = False
        Me.txtColor2.Key = ""
        Me.txtColor2.LabelAsoc = Me.lblColor2
        Me.txtColor2.Location = New System.Drawing.Point(72, 164)
        Me.txtColor2.Name = "txtColor2"
        Me.txtColor2.Size = New System.Drawing.Size(119, 20)
        Me.txtColor2.TabIndex = 15
        Me.txtColor2.TabStop = False
        Me.txtColor2.Text = "AaBbCcDdEeFf"
        Me.txtColor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnForeColor2
        '
        Me.btnForeColor2.Enabled = False
        Me.btnForeColor2.Location = New System.Drawing.Point(307, 163)
        Me.btnForeColor2.Name = "btnForeColor2"
        Me.btnForeColor2.Size = New System.Drawing.Size(62, 23)
        Me.btnForeColor2.TabIndex = 19
        Me.btnForeColor2.Text = "Letra"
        Me.btnForeColor2.UseVisualStyleBackColor = True
        '
        'chbBackColor1
        '
        Me.chbBackColor1.AutoSize = True
        Me.chbBackColor1.BindearPropiedadControl = ""
        Me.chbBackColor1.BindearPropiedadEntidad = ""
        Me.chbBackColor1.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBackColor1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBackColor1.IsPK = False
        Me.chbBackColor1.IsRequired = False
        Me.chbBackColor1.Key = Nothing
        Me.chbBackColor1.LabelAsoc = Nothing
        Me.chbBackColor1.Location = New System.Drawing.Point(197, 140)
        Me.chbBackColor1.Name = "chbBackColor1"
        Me.chbBackColor1.Size = New System.Drawing.Size(15, 14)
        Me.chbBackColor1.TabIndex = 10
        Me.chbBackColor1.UseVisualStyleBackColor = True
        '
        'chbBackColor2
        '
        Me.chbBackColor2.AutoSize = True
        Me.chbBackColor2.BindearPropiedadControl = ""
        Me.chbBackColor2.BindearPropiedadEntidad = ""
        Me.chbBackColor2.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBackColor2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBackColor2.IsPK = False
        Me.chbBackColor2.IsRequired = False
        Me.chbBackColor2.Key = Nothing
        Me.chbBackColor2.LabelAsoc = Nothing
        Me.chbBackColor2.Location = New System.Drawing.Point(197, 167)
        Me.chbBackColor2.Name = "chbBackColor2"
        Me.chbBackColor2.Size = New System.Drawing.Size(15, 14)
        Me.chbBackColor2.TabIndex = 16
        Me.chbBackColor2.UseVisualStyleBackColor = True
        '
        'chbForeColor2
        '
        Me.chbForeColor2.AutoSize = True
        Me.chbForeColor2.BindearPropiedadControl = ""
        Me.chbForeColor2.BindearPropiedadEntidad = ""
        Me.chbForeColor2.ForeColorFocus = System.Drawing.Color.Red
        Me.chbForeColor2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbForeColor2.IsPK = False
        Me.chbForeColor2.IsRequired = False
        Me.chbForeColor2.Key = Nothing
        Me.chbForeColor2.LabelAsoc = Nothing
        Me.chbForeColor2.Location = New System.Drawing.Point(286, 167)
        Me.chbForeColor2.Name = "chbForeColor2"
        Me.chbForeColor2.Size = New System.Drawing.Size(15, 14)
        Me.chbForeColor2.TabIndex = 18
        Me.chbForeColor2.UseVisualStyleBackColor = True
        '
        'chbForeColor1
        '
        Me.chbForeColor1.AutoSize = True
        Me.chbForeColor1.BindearPropiedadControl = ""
        Me.chbForeColor1.BindearPropiedadEntidad = ""
        Me.chbForeColor1.ForeColorFocus = System.Drawing.Color.Red
        Me.chbForeColor1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbForeColor1.IsPK = False
        Me.chbForeColor1.IsRequired = False
        Me.chbForeColor1.Key = Nothing
        Me.chbForeColor1.LabelAsoc = Nothing
        Me.chbForeColor1.Location = New System.Drawing.Point(286, 140)
        Me.chbForeColor1.Name = "chbForeColor1"
        Me.chbForeColor1.Size = New System.Drawing.Size(15, 14)
        Me.chbForeColor1.TabIndex = 12
        Me.chbForeColor1.UseVisualStyleBackColor = True
        '
        'PanelesTablerosControlDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 248)
        Me.Controls.Add(Me.chbForeColor1)
        Me.Controls.Add(Me.chbForeColor2)
        Me.Controls.Add(Me.chbBackColor2)
        Me.Controls.Add(Me.chbBackColor1)
        Me.Controls.Add(Me.btnForeColor2)
        Me.Controls.Add(Me.btnForeColor1)
        Me.Controls.Add(Me.txtColor2)
        Me.Controls.Add(Me.lblColor2)
        Me.Controls.Add(Me.txtColor1)
        Me.Controls.Add(Me.btnBackColor2)
        Me.Controls.Add(Me.lblColor1)
        Me.Controls.Add(Me.btnBackColor1)
        Me.Controls.Add(Me.lblIdController)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.lblParametros)
        Me.Controls.Add(Me.txtParametros)
        Me.Controls.Add(Me.lblNombrePanel)
        Me.Controls.Add(Me.txtNombrePanel)
        Me.Controls.Add(Me.lblIdPanelTableroControl)
        Me.Controls.Add(Me.txtIdPanelTableroControl)
        Me.Name = "PanelesTablerosControlDetalle"
        Me.Text = "Panel de Control"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtIdPanelTableroControl, 0)
        Me.Controls.SetChildIndex(Me.lblIdPanelTableroControl, 0)
        Me.Controls.SetChildIndex(Me.txtNombrePanel, 0)
        Me.Controls.SetChildIndex(Me.lblNombrePanel, 0)
        Me.Controls.SetChildIndex(Me.txtParametros, 0)
        Me.Controls.SetChildIndex(Me.lblParametros, 0)
        Me.Controls.SetChildIndex(Me.TextBox2, 0)
        Me.Controls.SetChildIndex(Me.lblIdController, 0)
        Me.Controls.SetChildIndex(Me.btnBackColor1, 0)
        Me.Controls.SetChildIndex(Me.lblColor1, 0)
        Me.Controls.SetChildIndex(Me.btnBackColor2, 0)
        Me.Controls.SetChildIndex(Me.txtColor1, 0)
        Me.Controls.SetChildIndex(Me.lblColor2, 0)
        Me.Controls.SetChildIndex(Me.txtColor2, 0)
        Me.Controls.SetChildIndex(Me.btnForeColor1, 0)
        Me.Controls.SetChildIndex(Me.btnForeColor2, 0)
        Me.Controls.SetChildIndex(Me.chbBackColor1, 0)
        Me.Controls.SetChildIndex(Me.chbBackColor2, 0)
        Me.Controls.SetChildIndex(Me.chbForeColor2, 0)
        Me.Controls.SetChildIndex(Me.chbForeColor1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombrePanel As Controles.Label
    Friend WithEvents txtNombrePanel As Controles.TextBox
    Friend WithEvents lblIdPanelTableroControl As Controles.Label
    Friend WithEvents txtIdPanelTableroControl As Controles.TextBox
    Friend WithEvents lblParametros As Controles.Label
    Friend WithEvents txtParametros As Controles.TextBox
    Friend WithEvents lblIdController As Controles.Label
    Friend WithEvents TextBox2 As Controles.TextBox
    Friend WithEvents txtColor1 As Controles.TextBox
    Friend WithEvents lblColor1 As Controles.Label
    Friend WithEvents btnBackColor1 As Button
    Friend WithEvents btnForeColor1 As Button
    Friend WithEvents btnBackColor2 As Button
    Friend WithEvents lblColor2 As Controles.Label
    Friend WithEvents txtColor2 As Controles.TextBox
    Friend WithEvents btnForeColor2 As Button
    Friend WithEvents chbBackColor1 As Controles.CheckBox
    Friend WithEvents chbBackColor2 As Controles.CheckBox
    Friend WithEvents chbForeColor2 As Controles.CheckBox
    Friend WithEvents chbForeColor1 As Controles.CheckBox
    Friend WithEvents cdColor As ColorDialog
End Class
