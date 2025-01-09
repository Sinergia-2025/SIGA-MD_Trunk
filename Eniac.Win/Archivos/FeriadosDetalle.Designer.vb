<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FeriadosDetalle
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
      Me.lblNombreFeriado = New Eniac.Controles.Label()
      Me.txtNombreFeriado = New Eniac.Controles.TextBox()
      Me.lblFechaFeriado = New Eniac.Controles.Label()
      Me.dtpFechaFeriado = New Eniac.Controles.DateTimePicker()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(211, 105)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(297, 105)
      Me.btnCancelar.TabIndex = 5
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 105)
      Me.btnCopiar.TabIndex = 6
      '
      'lblNombreFeriado
      '
      Me.lblNombreFeriado.AutoSize = True
      Me.lblNombreFeriado.Location = New System.Drawing.Point(16, 56)
      Me.lblNombreFeriado.Name = "lblNombreFeriado"
      Me.lblNombreFeriado.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreFeriado.TabIndex = 2
      Me.lblNombreFeriado.Text = "Descripción"
      '
      'txtNombreFeriado
      '
      Me.txtNombreFeriado.BindearPropiedadControl = "Text"
      Me.txtNombreFeriado.BindearPropiedadEntidad = "NombreFeriado"
      Me.txtNombreFeriado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreFeriado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreFeriado.Formato = ""
      Me.txtNombreFeriado.IsDecimal = False
      Me.txtNombreFeriado.IsNumber = False
      Me.txtNombreFeriado.IsPK = False
      Me.txtNombreFeriado.IsRequired = True
      Me.txtNombreFeriado.Key = ""
      Me.txtNombreFeriado.LabelAsoc = Me.lblNombreFeriado
      Me.txtNombreFeriado.Location = New System.Drawing.Point(93, 52)
      Me.txtNombreFeriado.MaxLength = 100
      Me.txtNombreFeriado.Name = "txtNombreFeriado"
      Me.txtNombreFeriado.Size = New System.Drawing.Size(281, 20)
      Me.txtNombreFeriado.TabIndex = 3
      '
      'lblFechaFeriado
      '
      Me.lblFechaFeriado.AutoSize = True
      Me.lblFechaFeriado.Location = New System.Drawing.Point(16, 30)
      Me.lblFechaFeriado.Name = "lblFechaFeriado"
      Me.lblFechaFeriado.Size = New System.Drawing.Size(40, 13)
      Me.lblFechaFeriado.TabIndex = 0
      Me.lblFechaFeriado.Text = "Código"
      '
      'dtpFechaFeriado
      '
      Me.dtpFechaFeriado.BindearPropiedadControl = "Value"
      Me.dtpFechaFeriado.BindearPropiedadEntidad = "FechaFeriado"
      Me.dtpFechaFeriado.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaFeriado.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaFeriado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaFeriado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaFeriado.IsPK = True
      Me.dtpFechaFeriado.IsRequired = True
      Me.dtpFechaFeriado.Key = ""
      Me.dtpFechaFeriado.LabelAsoc = Nothing
      Me.dtpFechaFeriado.Location = New System.Drawing.Point(93, 26)
      Me.dtpFechaFeriado.Name = "dtpFechaFeriado"
      Me.dtpFechaFeriado.Size = New System.Drawing.Size(103, 20)
      Me.dtpFechaFeriado.TabIndex = 1
      '
      'FeriadosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 140)
      Me.Controls.Add(Me.dtpFechaFeriado)
      Me.Controls.Add(Me.lblNombreFeriado)
      Me.Controls.Add(Me.txtNombreFeriado)
      Me.Controls.Add(Me.lblFechaFeriado)
      Me.Name = "FeriadosDetalle"
      Me.Text = "Feriado"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblFechaFeriado, 0)
      Me.Controls.SetChildIndex(Me.txtNombreFeriado, 0)
      Me.Controls.SetChildIndex(Me.lblNombreFeriado, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaFeriado, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreFeriado As Eniac.Controles.Label
   Friend WithEvents txtNombreFeriado As Eniac.Controles.TextBox
   Friend WithEvents lblFechaFeriado As Eniac.Controles.Label
   Protected WithEvents dtpFechaFeriado As Eniac.Controles.DateTimePicker
End Class
