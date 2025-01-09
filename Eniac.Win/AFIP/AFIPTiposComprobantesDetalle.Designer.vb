<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AFIPTiposComprobantesDetalle
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
      Me.lblNombreAFIPTipoComprobante = New Eniac.Controles.Label()
      Me.txtNombreAFIPTipoComprobante = New Eniac.Controles.TextBox()
      Me.lblIdAFIPTipoComprobante = New Eniac.Controles.Label()
      Me.txtIdAFIPTipoComprobante = New Eniac.Controles.TextBox()
      Me.cmbTipoDocumento = New Eniac.Controles.ComboBox()
      Me.chbTipoDocumento = New Eniac.Controles.CheckBox()
      Me.lblIncluyeFechaVencimiento = New Eniac.Controles.Label()
      Me.cmbIncluyeFechaVencimiento = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(329, 148)
        Me.btnAceptar.TabIndex = 8
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(415, 148)
        Me.btnCancelar.TabIndex = 9
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(228, 148)
        Me.btnCopiar.TabIndex = 11
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(171, 148)
        Me.btnAplicar.TabIndex = 10
        '
        'lblNombreAFIPTipoComprobante
        '
        Me.lblNombreAFIPTipoComprobante.AutoSize = True
        Me.lblNombreAFIPTipoComprobante.LabelAsoc = Nothing
        Me.lblNombreAFIPTipoComprobante.Location = New System.Drawing.Point(32, 55)
        Me.lblNombreAFIPTipoComprobante.Name = "lblNombreAFIPTipoComprobante"
        Me.lblNombreAFIPTipoComprobante.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreAFIPTipoComprobante.TabIndex = 2
        Me.lblNombreAFIPTipoComprobante.Text = "Nombre"
        '
        'txtNombreAFIPTipoComprobante
        '
        Me.txtNombreAFIPTipoComprobante.BindearPropiedadControl = "Text"
        Me.txtNombreAFIPTipoComprobante.BindearPropiedadEntidad = "NombreAFIPTipoComprobante"
        Me.txtNombreAFIPTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreAFIPTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreAFIPTipoComprobante.Formato = ""
        Me.txtNombreAFIPTipoComprobante.IsDecimal = False
        Me.txtNombreAFIPTipoComprobante.IsNumber = False
        Me.txtNombreAFIPTipoComprobante.IsPK = False
        Me.txtNombreAFIPTipoComprobante.IsRequired = True
        Me.txtNombreAFIPTipoComprobante.Key = ""
        Me.txtNombreAFIPTipoComprobante.LabelAsoc = Me.lblNombreAFIPTipoComprobante
        Me.txtNombreAFIPTipoComprobante.Location = New System.Drawing.Point(158, 51)
        Me.txtNombreAFIPTipoComprobante.MaxLength = 70
        Me.txtNombreAFIPTipoComprobante.Name = "txtNombreAFIPTipoComprobante"
        Me.txtNombreAFIPTipoComprobante.Size = New System.Drawing.Size(337, 20)
        Me.txtNombreAFIPTipoComprobante.TabIndex = 3
        '
        'lblIdAFIPTipoComprobante
        '
        Me.lblIdAFIPTipoComprobante.AutoSize = True
        Me.lblIdAFIPTipoComprobante.LabelAsoc = Nothing
        Me.lblIdAFIPTipoComprobante.Location = New System.Drawing.Point(32, 28)
        Me.lblIdAFIPTipoComprobante.Name = "lblIdAFIPTipoComprobante"
        Me.lblIdAFIPTipoComprobante.Size = New System.Drawing.Size(40, 13)
        Me.lblIdAFIPTipoComprobante.TabIndex = 0
        Me.lblIdAFIPTipoComprobante.Text = "Código"
        '
        'txtIdAFIPTipoComprobante
        '
        Me.txtIdAFIPTipoComprobante.BindearPropiedadControl = "Text"
        Me.txtIdAFIPTipoComprobante.BindearPropiedadEntidad = "IdAFIPTipoComprobante"
        Me.txtIdAFIPTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdAFIPTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdAFIPTipoComprobante.Formato = ""
        Me.txtIdAFIPTipoComprobante.IsDecimal = False
        Me.txtIdAFIPTipoComprobante.IsNumber = True
        Me.txtIdAFIPTipoComprobante.IsPK = True
        Me.txtIdAFIPTipoComprobante.IsRequired = True
        Me.txtIdAFIPTipoComprobante.Key = ""
        Me.txtIdAFIPTipoComprobante.LabelAsoc = Me.lblIdAFIPTipoComprobante
        Me.txtIdAFIPTipoComprobante.Location = New System.Drawing.Point(158, 25)
        Me.txtIdAFIPTipoComprobante.MaxLength = 6
        Me.txtIdAFIPTipoComprobante.Name = "txtIdAFIPTipoComprobante"
        Me.txtIdAFIPTipoComprobante.Size = New System.Drawing.Size(77, 20)
        Me.txtIdAFIPTipoComprobante.TabIndex = 1
        Me.txtIdAFIPTipoComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.BindearPropiedadControl = ""
        Me.cmbTipoDocumento.BindearPropiedadEntidad = ""
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.Enabled = False
        Me.cmbTipoDocumento.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDocumento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.IsPK = False
        Me.cmbTipoDocumento.IsRequired = False
        Me.cmbTipoDocumento.Key = Nothing
        Me.cmbTipoDocumento.LabelAsoc = Nothing
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(158, 77)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(242, 21)
        Me.cmbTipoDocumento.TabIndex = 5
        '
        'chbTipoDocumento
        '
        Me.chbTipoDocumento.AutoSize = True
        Me.chbTipoDocumento.BindearPropiedadControl = Nothing
        Me.chbTipoDocumento.BindearPropiedadEntidad = Nothing
        Me.chbTipoDocumento.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoDocumento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoDocumento.IsPK = False
        Me.chbTipoDocumento.IsRequired = False
        Me.chbTipoDocumento.Key = Nothing
        Me.chbTipoDocumento.LabelAsoc = Nothing
        Me.chbTipoDocumento.Location = New System.Drawing.Point(32, 80)
        Me.chbTipoDocumento.Name = "chbTipoDocumento"
        Me.chbTipoDocumento.Size = New System.Drawing.Size(120, 17)
        Me.chbTipoDocumento.TabIndex = 4
        Me.chbTipoDocumento.Text = "Tipo de Documento"
        '
        'lblIncluyeFechaVencimiento
        '
        Me.lblIncluyeFechaVencimiento.AutoSize = True
        Me.lblIncluyeFechaVencimiento.LabelAsoc = Nothing
        Me.lblIncluyeFechaVencimiento.Location = New System.Drawing.Point(32, 107)
        Me.lblIncluyeFechaVencimiento.Name = "lblIncluyeFechaVencimiento"
        Me.lblIncluyeFechaVencimiento.Size = New System.Drawing.Size(102, 13)
        Me.lblIncluyeFechaVencimiento.TabIndex = 6
        Me.lblIncluyeFechaVencimiento.Text = "Incluye Vencimiento"
        '
        'cmbIncluyeFechaVencimiento
        '
        Me.cmbIncluyeFechaVencimiento.BindearPropiedadControl = ""
        Me.cmbIncluyeFechaVencimiento.BindearPropiedadEntidad = ""
        Me.cmbIncluyeFechaVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIncluyeFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIncluyeFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIncluyeFechaVencimiento.FormattingEnabled = True
        Me.cmbIncluyeFechaVencimiento.IsPK = False
        Me.cmbIncluyeFechaVencimiento.IsRequired = True
        Me.cmbIncluyeFechaVencimiento.Key = Nothing
        Me.cmbIncluyeFechaVencimiento.LabelAsoc = Me.lblIncluyeFechaVencimiento
        Me.cmbIncluyeFechaVencimiento.Location = New System.Drawing.Point(158, 104)
        Me.cmbIncluyeFechaVencimiento.Name = "cmbIncluyeFechaVencimiento"
        Me.cmbIncluyeFechaVencimiento.Size = New System.Drawing.Size(116, 21)
        Me.cmbIncluyeFechaVencimiento.TabIndex = 7
        '
        'AFIPTiposComprobantesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 183)
        Me.Controls.Add(Me.lblNombreAFIPTipoComprobante)
        Me.Controls.Add(Me.txtNombreAFIPTipoComprobante)
        Me.Controls.Add(Me.lblIdAFIPTipoComprobante)
        Me.Controls.Add(Me.txtIdAFIPTipoComprobante)
        Me.Controls.Add(Me.cmbIncluyeFechaVencimiento)
        Me.Controls.Add(Me.lblIncluyeFechaVencimiento)
        Me.Controls.Add(Me.cmbTipoDocumento)
        Me.Controls.Add(Me.chbTipoDocumento)
        Me.Name = "AFIPTiposComprobantesDetalle"
        Me.Text = "Tipo de Comprobante AFIP"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.chbTipoDocumento, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoDocumento, 0)
        Me.Controls.SetChildIndex(Me.lblIncluyeFechaVencimiento, 0)
        Me.Controls.SetChildIndex(Me.cmbIncluyeFechaVencimiento, 0)
        Me.Controls.SetChildIndex(Me.txtIdAFIPTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.lblIdAFIPTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.txtNombreAFIPTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.lblNombreAFIPTipoComprobante, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreAFIPTipoComprobante As Eniac.Controles.Label
   Friend WithEvents txtNombreAFIPTipoComprobante As Eniac.Controles.TextBox
   Friend WithEvents lblIdAFIPTipoComprobante As Eniac.Controles.Label
   Friend WithEvents txtIdAFIPTipoComprobante As Eniac.Controles.TextBox
   Friend WithEvents cmbTipoDocumento As Eniac.Controles.ComboBox
   Friend WithEvents chbTipoDocumento As Eniac.Controles.CheckBox
   Friend WithEvents lblIncluyeFechaVencimiento As Eniac.Controles.Label
   Friend WithEvents cmbIncluyeFechaVencimiento As Eniac.Controles.ComboBox
End Class
