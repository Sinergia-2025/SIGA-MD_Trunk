<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoDeLote
    Inherits BaseForm

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
      Me.dtpFechaVencimiento = New Eniac.Controles.DateTimePicker()
      Me.lblFechaVencimiento = New Eniac.Controles.Label()
      Me.lblIdLote = New Eniac.Controles.Label()
      Me.txtIdLote = New Eniac.Controles.TextBox()
      Me.btnAceptar = New Eniac.Controles.Button()
        Me.SuspendLayout()
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.BindearPropiedadControl = Nothing
        Me.dtpFechaVencimiento.BindearPropiedadEntidad = Nothing
        Me.dtpFechaVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaVencimiento.IsPK = False
        Me.dtpFechaVencimiento.IsRequired = False
        Me.dtpFechaVencimiento.Key = ""
        Me.dtpFechaVencimiento.LabelAsoc = Me.lblFechaVencimiento
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(83, 44)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaVencimiento.TabIndex = 3
        '
        'lblFechaVencimiento
        '
        Me.lblFechaVencimiento.AutoSize = True
        Me.lblFechaVencimiento.LabelAsoc = Nothing
        Me.lblFechaVencimiento.Location = New System.Drawing.Point(12, 48)
        Me.lblFechaVencimiento.Name = "lblFechaVencimiento"
        Me.lblFechaVencimiento.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaVencimiento.TabIndex = 2
        Me.lblFechaVencimiento.Text = "Vencimiento"
        '
        'lblIdLote
        '
        Me.lblIdLote.AutoSize = True
        Me.lblIdLote.LabelAsoc = Nothing
        Me.lblIdLote.Location = New System.Drawing.Point(12, 22)
        Me.lblIdLote.Name = "lblIdLote"
        Me.lblIdLote.Size = New System.Drawing.Size(28, 13)
        Me.lblIdLote.TabIndex = 0
        Me.lblIdLote.Text = "Lote"
        '
        'txtIdLote
        '
        Me.txtIdLote.BindearPropiedadControl = Nothing
        Me.txtIdLote.BindearPropiedadEntidad = Nothing
        Me.txtIdLote.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdLote.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdLote.Formato = ""
        Me.txtIdLote.IsDecimal = False
        Me.txtIdLote.IsNumber = False
        Me.txtIdLote.IsPK = False
        Me.txtIdLote.IsRequired = False
        Me.txtIdLote.Key = ""
        Me.txtIdLote.LabelAsoc = Me.lblIdLote
        Me.txtIdLote.Location = New System.Drawing.Point(83, 18)
        Me.txtIdLote.MaxLength = 30
        Me.txtIdLote.Name = "txtIdLote"
        Me.txtIdLote.Size = New System.Drawing.Size(141, 20)
        Me.txtIdLote.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_32
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(141, 85)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 35)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'IngresoDeLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(247, 132)
        Me.Controls.Add(Me.lblIdLote)
        Me.Controls.Add(Me.txtIdLote)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dtpFechaVencimiento)
        Me.Controls.Add(Me.lblFechaVencimiento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "IngresoDeLote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingrese los datos del Lote"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFechaVencimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaVencimiento As Eniac.Controles.Label
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents lblIdLote As Eniac.Controles.Label
   Friend WithEvents txtIdLote As Eniac.Controles.TextBox
End Class
