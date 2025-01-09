<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AFIPConceptosCM05Detalle
   Inherits BaseDetalle

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
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.cmbTipoConceptoCM05 = New Eniac.Controles.ComboBox()
      Me.lblTipoConceptoCM05 = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(179, 119)
        Me.btnAceptar.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(265, 119)
        Me.btnCancelar.TabIndex = 7
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(78, 119)
        Me.btnCopiar.TabIndex = 9
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(21, 119)
        Me.btnAplicar.TabIndex = 8
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "DescripcionConceptoCM05"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(80, 38)
        Me.txtNombre.MaxLength = 30
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(250, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(10, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = "Text"
        Me.txtCodigo.BindearPropiedadEntidad = "IdConceptoCM05"
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = True
        Me.txtCodigo.IsPK = True
        Me.txtCodigo.IsRequired = True
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(80, 12)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(61, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Text = "0"
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(10, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'cmbTipoConceptoCM05
        '
        Me.cmbTipoConceptoCM05.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoConceptoCM05.BindearPropiedadEntidad = "TipoConceptoCM05"
        Me.cmbTipoConceptoCM05.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoConceptoCM05.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoConceptoCM05.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoConceptoCM05.FormattingEnabled = True
        Me.cmbTipoConceptoCM05.IsPK = False
        Me.cmbTipoConceptoCM05.IsRequired = True
        Me.cmbTipoConceptoCM05.Key = Nothing
        Me.cmbTipoConceptoCM05.LabelAsoc = Me.lblTipoConceptoCM05
        Me.cmbTipoConceptoCM05.Location = New System.Drawing.Point(80, 64)
        Me.cmbTipoConceptoCM05.Name = "cmbTipoConceptoCM05"
        Me.cmbTipoConceptoCM05.Size = New System.Drawing.Size(142, 21)
        Me.cmbTipoConceptoCM05.TabIndex = 5
        '
        'lblTipoConceptoCM05
        '
        Me.lblTipoConceptoCM05.AutoSize = True
        Me.lblTipoConceptoCM05.LabelAsoc = Nothing
        Me.lblTipoConceptoCM05.Location = New System.Drawing.Point(10, 67)
        Me.lblTipoConceptoCM05.Name = "lblTipoConceptoCM05"
        Me.lblTipoConceptoCM05.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoConceptoCM05.TabIndex = 4
        Me.lblTipoConceptoCM05.Text = "Tipo"
        '
        'AFIPConceptosCM05Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 154)
        Me.Controls.Add(Me.cmbTipoConceptoCM05)
        Me.Controls.Add(Me.lblTipoConceptoCM05)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblCodigo)
        Me.Name = "AFIPConceptosCM05Detalle"
        Me.Text = "Concepto CM05"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblTipoConceptoCM05, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoConceptoCM05, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtCodigo As Controles.TextBox
   Friend WithEvents lblCodigo As Controles.Label
   Friend WithEvents cmbTipoConceptoCM05 As Controles.ComboBox
   Friend WithEvents lblTipoConceptoCM05 As Controles.Label
End Class
