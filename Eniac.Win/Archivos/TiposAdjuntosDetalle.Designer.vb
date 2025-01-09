<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposAdjuntosDetalle
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
      Me.txtNombreTipoAdjunto = New Eniac.Controles.TextBox()
      Me.lblNombreTipoAdjunto = New Eniac.Controles.Label()
      Me.txtIdTipoAdjunto = New Eniac.Controles.TextBox()
      Me.lblIdTipoAdjunto = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(211, 101)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(297, 101)
      Me.btnCancelar.TabIndex = 5
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 101)
      Me.btnCopiar.TabIndex = 6
      '
      'txtNombreTipoAdjunto
      '
      Me.txtNombreTipoAdjunto.BindearPropiedadControl = "Text"
      Me.txtNombreTipoAdjunto.BindearPropiedadEntidad = "NombreTipoAdjunto"
      Me.txtNombreTipoAdjunto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoAdjunto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoAdjunto.Formato = ""
      Me.txtNombreTipoAdjunto.IsDecimal = False
      Me.txtNombreTipoAdjunto.IsNumber = False
      Me.txtNombreTipoAdjunto.IsPK = False
      Me.txtNombreTipoAdjunto.IsRequired = True
      Me.txtNombreTipoAdjunto.Key = ""
      Me.txtNombreTipoAdjunto.LabelAsoc = Me.lblNombreTipoAdjunto
      Me.txtNombreTipoAdjunto.Location = New System.Drawing.Point(97, 38)
      Me.txtNombreTipoAdjunto.MaxLength = 20
      Me.txtNombreTipoAdjunto.Name = "txtNombreTipoAdjunto"
      Me.txtNombreTipoAdjunto.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreTipoAdjunto.TabIndex = 3
      '
      'lblNombreTipoAdjunto
      '
      Me.lblNombreTipoAdjunto.AutoSize = True
      Me.lblNombreTipoAdjunto.Location = New System.Drawing.Point(38, 42)
      Me.lblNombreTipoAdjunto.Name = "lblNombreTipoAdjunto"
      Me.lblNombreTipoAdjunto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreTipoAdjunto.TabIndex = 2
      Me.lblNombreTipoAdjunto.Text = "Nombre"
      '
      'txtIdTipoAdjunto
      '
      Me.txtIdTipoAdjunto.BindearPropiedadControl = "Text"
      Me.txtIdTipoAdjunto.BindearPropiedadEntidad = "IdTipoAdjunto"
      Me.txtIdTipoAdjunto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoAdjunto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoAdjunto.Formato = ""
      Me.txtIdTipoAdjunto.IsDecimal = False
      Me.txtIdTipoAdjunto.IsNumber = True
      Me.txtIdTipoAdjunto.IsPK = True
      Me.txtIdTipoAdjunto.IsRequired = True
      Me.txtIdTipoAdjunto.Key = ""
      Me.txtIdTipoAdjunto.LabelAsoc = Me.lblIdTipoAdjunto
      Me.txtIdTipoAdjunto.Location = New System.Drawing.Point(97, 12)
      Me.txtIdTipoAdjunto.MaxLength = 6
      Me.txtIdTipoAdjunto.Name = "txtIdTipoAdjunto"
      Me.txtIdTipoAdjunto.Size = New System.Drawing.Size(59, 20)
      Me.txtIdTipoAdjunto.TabIndex = 1
      Me.txtIdTipoAdjunto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdTipoAdjunto
      '
      Me.lblIdTipoAdjunto.AutoSize = True
      Me.lblIdTipoAdjunto.Location = New System.Drawing.Point(38, 16)
      Me.lblIdTipoAdjunto.Name = "lblIdTipoAdjunto"
      Me.lblIdTipoAdjunto.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoAdjunto.TabIndex = 0
      Me.lblIdTipoAdjunto.Text = "Código"
      '
      'TiposAdjuntosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 136)
      Me.Controls.Add(Me.txtNombreTipoAdjunto)
      Me.Controls.Add(Me.txtIdTipoAdjunto)
      Me.Controls.Add(Me.lblNombreTipoAdjunto)
      Me.Controls.Add(Me.lblIdTipoAdjunto)
      Me.Name = "TiposAdjuntosDetalle"
      Me.Text = "Tipo de Adjunto"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoAdjunto, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoAdjunto, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoAdjunto, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoAdjunto, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreTipoAdjunto As Eniac.Controles.TextBox
   Friend WithEvents lblNombreTipoAdjunto As Eniac.Controles.Label
   Friend WithEvents txtIdTipoAdjunto As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoAdjunto As Eniac.Controles.Label
End Class
