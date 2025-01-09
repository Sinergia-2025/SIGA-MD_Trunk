<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposCalendariosDetalle
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
      Me.lblNombreTipoCalendario = New Eniac.Controles.Label()
      Me.txtNombreTipoCalendario = New Eniac.Controles.TextBox()
      Me.lblIdTipoCalendario = New Eniac.Controles.Label()
      Me.txtIdTipoCalendario = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(211, 110)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(297, 110)
      Me.btnCancelar.TabIndex = 5
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 110)
      Me.btnCopiar.TabIndex = 7
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(53, 110)
      Me.btnAplicar.TabIndex = 6
      '
      'lblNombreTipoCalendario
      '
      Me.lblNombreTipoCalendario.AutoSize = True
      Me.lblNombreTipoCalendario.LabelAsoc = Nothing
      Me.lblNombreTipoCalendario.Location = New System.Drawing.Point(33, 53)
      Me.lblNombreTipoCalendario.Name = "lblNombreTipoCalendario"
      Me.lblNombreTipoCalendario.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreTipoCalendario.TabIndex = 2
      Me.lblNombreTipoCalendario.Text = "Descripción"
      '
      'txtNombreTipoCalendario
      '
      Me.txtNombreTipoCalendario.BindearPropiedadControl = "Text"
      Me.txtNombreTipoCalendario.BindearPropiedadEntidad = "NombreTipoCalendario"
      Me.txtNombreTipoCalendario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoCalendario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoCalendario.Formato = ""
      Me.txtNombreTipoCalendario.IsDecimal = False
      Me.txtNombreTipoCalendario.IsNumber = False
      Me.txtNombreTipoCalendario.IsPK = False
      Me.txtNombreTipoCalendario.IsRequired = True
      Me.txtNombreTipoCalendario.Key = ""
      Me.txtNombreTipoCalendario.LabelAsoc = Me.lblNombreTipoCalendario
      Me.txtNombreTipoCalendario.Location = New System.Drawing.Point(110, 49)
      Me.txtNombreTipoCalendario.MaxLength = 50
      Me.txtNombreTipoCalendario.Name = "txtNombreTipoCalendario"
      Me.txtNombreTipoCalendario.Size = New System.Drawing.Size(223, 20)
      Me.txtNombreTipoCalendario.TabIndex = 3
      '
      'lblIdTipoCalendario
      '
      Me.lblIdTipoCalendario.AutoSize = True
      Me.lblIdTipoCalendario.LabelAsoc = Nothing
      Me.lblIdTipoCalendario.Location = New System.Drawing.Point(33, 27)
      Me.lblIdTipoCalendario.Name = "lblIdTipoCalendario"
      Me.lblIdTipoCalendario.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoCalendario.TabIndex = 0
      Me.lblIdTipoCalendario.Text = "Codigo"
      '
      'txtIdTipoCalendario
      '
      Me.txtIdTipoCalendario.BindearPropiedadControl = "Text"
      Me.txtIdTipoCalendario.BindearPropiedadEntidad = "IdTipoCalendario"
      Me.txtIdTipoCalendario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoCalendario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoCalendario.Formato = ""
      Me.txtIdTipoCalendario.IsDecimal = False
      Me.txtIdTipoCalendario.IsNumber = False
      Me.txtIdTipoCalendario.IsPK = True
      Me.txtIdTipoCalendario.IsRequired = True
      Me.txtIdTipoCalendario.Key = ""
      Me.txtIdTipoCalendario.LabelAsoc = Me.lblIdTipoCalendario
      Me.txtIdTipoCalendario.Location = New System.Drawing.Point(110, 23)
      Me.txtIdTipoCalendario.MaxLength = 10
      Me.txtIdTipoCalendario.Name = "txtIdTipoCalendario"
      Me.txtIdTipoCalendario.Size = New System.Drawing.Size(95, 20)
      Me.txtIdTipoCalendario.TabIndex = 1
      Me.txtIdTipoCalendario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'TiposCalendariosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 145)
      Me.Controls.Add(Me.lblNombreTipoCalendario)
      Me.Controls.Add(Me.txtNombreTipoCalendario)
      Me.Controls.Add(Me.lblIdTipoCalendario)
      Me.Controls.Add(Me.txtIdTipoCalendario)
      Me.Name = "TiposCalendariosDetalle"
      Me.Text = "Tipo de Calendario"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoCalendario, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoCalendario, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoCalendario, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoCalendario, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoCalendario As Eniac.Controles.Label
   Friend WithEvents txtNombreTipoCalendario As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoCalendario As Eniac.Controles.Label
   Friend WithEvents txtIdTipoCalendario As Eniac.Controles.TextBox
End Class
