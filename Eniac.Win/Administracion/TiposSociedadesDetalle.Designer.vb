<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposSociedadesDetalle
   Inherits Win.BaseDetalle

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
      Me.lblNombreTipoSociedad = New Eniac.Controles.Label()
      Me.txtNombreTipoSociedad = New Eniac.Controles.TextBox()
      Me.lblIdTipoSociedad = New Eniac.Controles.Label()
      Me.txtIdTipoSociedad = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(202, 113)
        Me.btnAceptar.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(295, 113)
        Me.btnCancelar.TabIndex = 5
        '
        'lblNombreTipoSociedad
        '
        Me.lblNombreTipoSociedad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombreTipoSociedad.AutoSize = True
        Me.lblNombreTipoSociedad.LabelAsoc = Nothing
        Me.lblNombreTipoSociedad.Location = New System.Drawing.Point(12, 42)
        Me.lblNombreTipoSociedad.Name = "lblNombreTipoSociedad"
        Me.lblNombreTipoSociedad.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreTipoSociedad.TabIndex = 2
        Me.lblNombreTipoSociedad.Text = "Nombre"
        '
        'txtNombreTipoSociedad
        '
        Me.txtNombreTipoSociedad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombreTipoSociedad.BindearPropiedadControl = "Text"
        Me.txtNombreTipoSociedad.BindearPropiedadEntidad = "NombreTipoSociedad"
        Me.txtNombreTipoSociedad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreTipoSociedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreTipoSociedad.Formato = ""
        Me.txtNombreTipoSociedad.IsDecimal = False
        Me.txtNombreTipoSociedad.IsNumber = False
        Me.txtNombreTipoSociedad.IsPK = False
        Me.txtNombreTipoSociedad.IsRequired = True
        Me.txtNombreTipoSociedad.Key = ""
        Me.txtNombreTipoSociedad.LabelAsoc = Me.lblNombreTipoSociedad
        Me.txtNombreTipoSociedad.Location = New System.Drawing.Point(78, 39)
        Me.txtNombreTipoSociedad.MaxLength = 50
        Me.txtNombreTipoSociedad.Name = "txtNombreTipoSociedad"
        Me.txtNombreTipoSociedad.Size = New System.Drawing.Size(297, 20)
        Me.txtNombreTipoSociedad.TabIndex = 3
        '
        'lblIdTipoSociedad
        '
        Me.lblIdTipoSociedad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdTipoSociedad.AutoSize = True
        Me.lblIdTipoSociedad.LabelAsoc = Nothing
        Me.lblIdTipoSociedad.Location = New System.Drawing.Point(12, 16)
        Me.lblIdTipoSociedad.Name = "lblIdTipoSociedad"
        Me.lblIdTipoSociedad.Size = New System.Drawing.Size(40, 13)
        Me.lblIdTipoSociedad.TabIndex = 0
        Me.lblIdTipoSociedad.Text = "Código"
        '
        'txtIdTipoSociedad
        '
        Me.txtIdTipoSociedad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIdTipoSociedad.BindearPropiedadControl = "Text"
        Me.txtIdTipoSociedad.BindearPropiedadEntidad = "IdTipoSociedad"
        Me.txtIdTipoSociedad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTipoSociedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTipoSociedad.Formato = ""
        Me.txtIdTipoSociedad.IsDecimal = False
        Me.txtIdTipoSociedad.IsNumber = True
        Me.txtIdTipoSociedad.IsPK = True
        Me.txtIdTipoSociedad.IsRequired = True
        Me.txtIdTipoSociedad.Key = ""
        Me.txtIdTipoSociedad.LabelAsoc = Me.lblIdTipoSociedad
        Me.txtIdTipoSociedad.Location = New System.Drawing.Point(78, 13)
        Me.txtIdTipoSociedad.MaxLength = 4
        Me.txtIdTipoSociedad.Name = "txtIdTipoSociedad"
        Me.txtIdTipoSociedad.Size = New System.Drawing.Size(77, 20)
        Me.txtIdTipoSociedad.TabIndex = 1
        Me.txtIdTipoSociedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TiposSociedadesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 149)
        Me.Controls.Add(Me.lblNombreTipoSociedad)
        Me.Controls.Add(Me.txtNombreTipoSociedad)
        Me.Controls.Add(Me.lblIdTipoSociedad)
        Me.Controls.Add(Me.txtIdTipoSociedad)
        Me.Name = "TiposSociedadesDetalle"
        Me.Text = "TiposSociedadesDetalle"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtIdTipoSociedad, 0)
        Me.Controls.SetChildIndex(Me.lblIdTipoSociedad, 0)
        Me.Controls.SetChildIndex(Me.txtNombreTipoSociedad, 0)
        Me.Controls.SetChildIndex(Me.lblNombreTipoSociedad, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreTipoSociedad As Controles.Label
   Friend WithEvents txtNombreTipoSociedad As Controles.TextBox
   Friend WithEvents lblIdTipoSociedad As Controles.Label
   Friend WithEvents txtIdTipoSociedad As Controles.TextBox
End Class
