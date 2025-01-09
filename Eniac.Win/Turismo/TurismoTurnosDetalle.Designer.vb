<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TurismoTurnosDetalle
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
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreTurno = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdTurno = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(204, 109)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(290, 109)
      Me.btnCancelar.TabIndex = 5
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(103, 109)
      Me.btnCopiar.TabIndex = 6
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(46, 109)
      Me.btnAplicar.TabIndex = 7
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(12, 48)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombreTurno
      '
      Me.txtNombreTurno.BindearPropiedadControl = "Text"
      Me.txtNombreTurno.BindearPropiedadEntidad = "NombreTurno"
      Me.txtNombreTurno.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTurno.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTurno.Formato = ""
      Me.txtNombreTurno.IsDecimal = False
      Me.txtNombreTurno.IsNumber = False
      Me.txtNombreTurno.IsPK = False
      Me.txtNombreTurno.IsRequired = True
      Me.txtNombreTurno.Key = ""
      Me.txtNombreTurno.LabelAsoc = Me.lblDescripcion
      Me.txtNombreTurno.Location = New System.Drawing.Point(89, 44)
      Me.txtNombreTurno.MaxLength = 20
      Me.txtNombreTurno.Name = "txtNombreTurno"
      Me.txtNombreTurno.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreTurno.TabIndex = 3
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(12, 22)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Código"
      '
      'txtIdTurno
      '
      Me.txtIdTurno.BindearPropiedadControl = "Text"
      Me.txtIdTurno.BindearPropiedadEntidad = "IdTurno"
      Me.txtIdTurno.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTurno.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTurno.Formato = ""
      Me.txtIdTurno.IsDecimal = False
      Me.txtIdTurno.IsNumber = True
      Me.txtIdTurno.IsPK = True
      Me.txtIdTurno.IsRequired = True
      Me.txtIdTurno.Key = ""
      Me.txtIdTurno.LabelAsoc = Me.lblCodigo
      Me.txtIdTurno.Location = New System.Drawing.Point(89, 18)
      Me.txtIdTurno.MaxLength = 10
      Me.txtIdTurno.Name = "txtIdTurno"
      Me.txtIdTurno.Size = New System.Drawing.Size(54, 20)
      Me.txtIdTurno.TabIndex = 1
      Me.txtIdTurno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'TurismoTurnosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(379, 144)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreTurno)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtIdTurno)
      Me.Name = "TurismoTurnosDetalle"
      Me.Text = "Turno"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTurno, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTurno, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombreTurno As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtIdTurno As Eniac.Controles.TextBox
End Class
