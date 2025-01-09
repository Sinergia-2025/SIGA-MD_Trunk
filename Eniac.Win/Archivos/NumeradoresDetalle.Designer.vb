<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NumeradoresDetalle
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
      Me.lblNumerador = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.lblNumero = New Eniac.Controles.Label()
      Me.txtIdNumerador = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(211, 133)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(297, 133)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 133)
      Me.btnCopiar.TabIndex = 9
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(53, 133)
      Me.btnAplicar.TabIndex = 8
      '
      'lblNumerador
      '
      Me.lblNumerador.AutoSize = True
      Me.lblNumerador.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblNumerador.LabelAsoc = Nothing
      Me.lblNumerador.Location = New System.Drawing.Point(28, 24)
      Me.lblNumerador.Name = "lblNumerador"
      Me.lblNumerador.Size = New System.Drawing.Size(59, 13)
      Me.lblNumerador.TabIndex = 0
      Me.lblNumerador.Text = "Numerador"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = False
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
      Me.txtDescripcion.Location = New System.Drawing.Point(110, 75)
      Me.txtDescripcion.MaxLength = 30
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(250, 20)
      Me.txtDescripcion.TabIndex = 5
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(28, 78)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 4
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = "Text"
      Me.txtNumero.BindearPropiedadEntidad = "Numero"
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = "N0"
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = True
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Me.lblNumero
      Me.txtNumero.Location = New System.Drawing.Point(110, 48)
      Me.txtNumero.MaxLength = 15
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(63, 20)
      Me.txtNumero.TabIndex = 3
      Me.txtNumero.Text = "0"
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumero
      '
      Me.lblNumero.AutoSize = True
      Me.lblNumero.LabelAsoc = Nothing
      Me.lblNumero.Location = New System.Drawing.Point(28, 52)
      Me.lblNumero.Name = "lblNumero"
      Me.lblNumero.Size = New System.Drawing.Size(76, 13)
      Me.lblNumero.TabIndex = 2
      Me.lblNumero.Text = "Último Número"
      '
      'txtIdNumerador
      '
      Me.txtIdNumerador.BindearPropiedadControl = "Text"
      Me.txtIdNumerador.BindearPropiedadEntidad = "IdNumerador"
      Me.txtIdNumerador.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdNumerador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdNumerador.Formato = ""
      Me.txtIdNumerador.IsDecimal = False
      Me.txtIdNumerador.IsNumber = False
      Me.txtIdNumerador.IsPK = True
      Me.txtIdNumerador.IsRequired = True
      Me.txtIdNumerador.Key = ""
      Me.txtIdNumerador.LabelAsoc = Me.lblNumerador
      Me.txtIdNumerador.Location = New System.Drawing.Point(110, 22)
      Me.txtIdNumerador.MaxLength = 30
      Me.txtIdNumerador.Name = "txtIdNumerador"
      Me.txtIdNumerador.Size = New System.Drawing.Size(137, 20)
      Me.txtIdNumerador.TabIndex = 1
      '
      'NumeradoresDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 168)
      Me.Controls.Add(Me.txtIdNumerador)
      Me.Controls.Add(Me.lblNumerador)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.txtNumero)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.lblNumero)
      Me.Name = "NumeradoresDetalle"
      Me.Text = "Numerador"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.lblNumero, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.txtNumero, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblNumerador, 0)
      Me.Controls.SetChildIndex(Me.txtIdNumerador, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNumerador As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents lblNumero As Eniac.Controles.Label
   Friend WithEvents txtIdNumerador As Eniac.Controles.TextBox
End Class
