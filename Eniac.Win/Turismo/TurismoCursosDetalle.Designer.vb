<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TurismoCursosDetalle
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
      Me.txtNombreCurso = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdCurso = New Eniac.Controles.TextBox()
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
      Me.lblDescripcion.Location = New System.Drawing.Point(12, 53)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombreCurso
      '
      Me.txtNombreCurso.BindearPropiedadControl = "Text"
      Me.txtNombreCurso.BindearPropiedadEntidad = "NombreCurso"
      Me.txtNombreCurso.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCurso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCurso.Formato = ""
      Me.txtNombreCurso.IsDecimal = False
      Me.txtNombreCurso.IsNumber = False
      Me.txtNombreCurso.IsPK = False
      Me.txtNombreCurso.IsRequired = True
      Me.txtNombreCurso.Key = ""
      Me.txtNombreCurso.LabelAsoc = Me.lblDescripcion
      Me.txtNombreCurso.Location = New System.Drawing.Point(81, 50)
      Me.txtNombreCurso.MaxLength = 20
      Me.txtNombreCurso.Name = "txtNombreCurso"
      Me.txtNombreCurso.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreCurso.TabIndex = 3
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(12, 28)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Código"
      '
      'txtIdCurso
      '
      Me.txtIdCurso.BindearPropiedadControl = "Text"
      Me.txtIdCurso.BindearPropiedadEntidad = "IdCurso"
      Me.txtIdCurso.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdCurso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdCurso.Formato = ""
      Me.txtIdCurso.IsDecimal = False
      Me.txtIdCurso.IsNumber = True
      Me.txtIdCurso.IsPK = True
      Me.txtIdCurso.IsRequired = True
      Me.txtIdCurso.Key = ""
      Me.txtIdCurso.LabelAsoc = Me.lblCodigo
      Me.txtIdCurso.Location = New System.Drawing.Point(81, 24)
      Me.txtIdCurso.MaxLength = 10
      Me.txtIdCurso.Name = "txtIdCurso"
      Me.txtIdCurso.Size = New System.Drawing.Size(54, 20)
      Me.txtIdCurso.TabIndex = 1
      Me.txtIdCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'TurismoCursosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(379, 144)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreCurso)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtIdCurso)
      Me.Name = "TurismoCursosDetalle"
      Me.Text = "Curso"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdCurso, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCurso, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombreCurso As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtIdCurso As Eniac.Controles.TextBox
End Class
