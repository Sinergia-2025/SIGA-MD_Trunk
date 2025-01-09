<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposTurnosDetalle
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
      Me.lblNombreTipoTurno = New Eniac.Controles.Label()
      Me.txtNombreTipoTurno = New Eniac.Controles.TextBox()
      Me.lblIdTipoTurno = New Eniac.Controles.Label()
      Me.txtIdTipoTurno = New Eniac.Controles.TextBox()
      Me.cmbTipoCalendario = New Eniac.Controles.ComboBox()
      Me.lblTipoCalendario = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(211, 110)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(297, 110)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 110)
      Me.btnCopiar.TabIndex = 9
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(50, 110)
      Me.btnAplicar.TabIndex = 8
      '
      'lblNombreTipoTurno
      '
      Me.lblNombreTipoTurno.AutoSize = True
      Me.lblNombreTipoTurno.LabelAsoc = Nothing
      Me.lblNombreTipoTurno.Location = New System.Drawing.Point(27, 53)
      Me.lblNombreTipoTurno.Name = "lblNombreTipoTurno"
      Me.lblNombreTipoTurno.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreTipoTurno.TabIndex = 2
      Me.lblNombreTipoTurno.Text = "Descripción"
      '
      'txtNombreTipoTurno
      '
      Me.txtNombreTipoTurno.BindearPropiedadControl = "Text"
      Me.txtNombreTipoTurno.BindearPropiedadEntidad = "NombreTipoTurno"
      Me.txtNombreTipoTurno.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoTurno.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoTurno.Formato = ""
      Me.txtNombreTipoTurno.IsDecimal = False
      Me.txtNombreTipoTurno.IsNumber = False
      Me.txtNombreTipoTurno.IsPK = False
      Me.txtNombreTipoTurno.IsRequired = True
      Me.txtNombreTipoTurno.Key = ""
      Me.txtNombreTipoTurno.LabelAsoc = Me.lblNombreTipoTurno
      Me.txtNombreTipoTurno.Location = New System.Drawing.Point(110, 49)
      Me.txtNombreTipoTurno.MaxLength = 50
      Me.txtNombreTipoTurno.Name = "txtNombreTipoTurno"
      Me.txtNombreTipoTurno.Size = New System.Drawing.Size(223, 20)
      Me.txtNombreTipoTurno.TabIndex = 3
      '
      'lblIdTipoTurno
      '
      Me.lblIdTipoTurno.AutoSize = True
      Me.lblIdTipoTurno.LabelAsoc = Nothing
      Me.lblIdTipoTurno.Location = New System.Drawing.Point(27, 27)
      Me.lblIdTipoTurno.Name = "lblIdTipoTurno"
      Me.lblIdTipoTurno.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoTurno.TabIndex = 0
      Me.lblIdTipoTurno.Text = "Codigo"
      '
      'txtIdTipoTurno
      '
      Me.txtIdTipoTurno.BindearPropiedadControl = "Text"
      Me.txtIdTipoTurno.BindearPropiedadEntidad = "IdTipoTurno"
      Me.txtIdTipoTurno.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoTurno.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoTurno.Formato = ""
      Me.txtIdTipoTurno.IsDecimal = False
      Me.txtIdTipoTurno.IsNumber = False
      Me.txtIdTipoTurno.IsPK = True
      Me.txtIdTipoTurno.IsRequired = True
      Me.txtIdTipoTurno.Key = ""
      Me.txtIdTipoTurno.LabelAsoc = Me.lblIdTipoTurno
      Me.txtIdTipoTurno.Location = New System.Drawing.Point(110, 23)
      Me.txtIdTipoTurno.MaxLength = 10
      Me.txtIdTipoTurno.Name = "txtIdTipoTurno"
      Me.txtIdTipoTurno.Size = New System.Drawing.Size(95, 20)
      Me.txtIdTipoTurno.TabIndex = 1
      Me.txtIdTipoTurno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbTipoCalendario
      '
      Me.cmbTipoCalendario.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoCalendario.BindearPropiedadEntidad = "IdTipoCalendario"
      Me.cmbTipoCalendario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoCalendario.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoCalendario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoCalendario.FormattingEnabled = True
      Me.cmbTipoCalendario.IsPK = False
      Me.cmbTipoCalendario.IsRequired = False
      Me.cmbTipoCalendario.Key = Nothing
      Me.cmbTipoCalendario.LabelAsoc = Me.lblTipoCalendario
      Me.cmbTipoCalendario.Location = New System.Drawing.Point(110, 75)
      Me.cmbTipoCalendario.Name = "cmbTipoCalendario"
      Me.cmbTipoCalendario.Size = New System.Drawing.Size(223, 21)
      Me.cmbTipoCalendario.TabIndex = 5
      '
      'lblTipoCalendario
      '
      Me.lblTipoCalendario.AutoSize = True
      Me.lblTipoCalendario.LabelAsoc = Nothing
      Me.lblTipoCalendario.Location = New System.Drawing.Point(27, 79)
      Me.lblTipoCalendario.Name = "lblTipoCalendario"
      Me.lblTipoCalendario.Size = New System.Drawing.Size(81, 13)
      Me.lblTipoCalendario.TabIndex = 4
      Me.lblTipoCalendario.Text = "Tipo Calendario"
      '
      'TiposTurnosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 145)
      Me.Controls.Add(Me.cmbTipoCalendario)
      Me.Controls.Add(Me.lblTipoCalendario)
      Me.Controls.Add(Me.lblNombreTipoTurno)
      Me.Controls.Add(Me.txtNombreTipoTurno)
      Me.Controls.Add(Me.lblIdTipoTurno)
      Me.Controls.Add(Me.txtIdTipoTurno)
      Me.Name = "TiposTurnosDetalle"
      Me.Text = "Tipo de Turno"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoTurno, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoTurno, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoTurno, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoTurno, 0)
      Me.Controls.SetChildIndex(Me.lblTipoCalendario, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoCalendario, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoTurno As Eniac.Controles.Label
   Friend WithEvents txtNombreTipoTurno As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoTurno As Eniac.Controles.Label
   Friend WithEvents txtIdTipoTurno As Eniac.Controles.TextBox
   Protected WithEvents cmbTipoCalendario As Eniac.Controles.ComboBox
   Protected WithEvents lblTipoCalendario As Eniac.Controles.Label
End Class
