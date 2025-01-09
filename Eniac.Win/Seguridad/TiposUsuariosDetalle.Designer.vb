<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposUsuariosDetalle
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
        Me.txtNombreTipoUsuario = New Eniac.Controles.TextBox()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtIdTipoUsuario = New Eniac.Controles.TextBox()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.chbEsDeProceso = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(196, 118)
        Me.btnAceptar.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(282, 118)
        Me.btnCancelar.TabIndex = 6
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(95, 118)
        Me.btnCopiar.TabIndex = 8
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(38, 118)
        Me.btnAplicar.TabIndex = 7
        '
        'txtNombreTipoUsuario
        '
        Me.txtNombreTipoUsuario.BindearPropiedadControl = "Text"
        Me.txtNombreTipoUsuario.BindearPropiedadEntidad = "NombreTipoUsuario"
        Me.txtNombreTipoUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreTipoUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreTipoUsuario.Formato = ""
        Me.txtNombreTipoUsuario.IsDecimal = False
        Me.txtNombreTipoUsuario.IsNumber = False
        Me.txtNombreTipoUsuario.IsPK = False
        Me.txtNombreTipoUsuario.IsRequired = True
        Me.txtNombreTipoUsuario.Key = ""
        Me.txtNombreTipoUsuario.LabelAsoc = Me.lblNombre
        Me.txtNombreTipoUsuario.Location = New System.Drawing.Point(72, 38)
        Me.txtNombreTipoUsuario.MaxLength = 40
        Me.txtNombreTipoUsuario.Name = "txtNombreTipoUsuario"
        Me.txtNombreTipoUsuario.Size = New System.Drawing.Size(285, 20)
        Me.txtNombreTipoUsuario.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(15, 39)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtIdTipoUsuario
        '
        Me.txtIdTipoUsuario.BindearPropiedadControl = "Text"
        Me.txtIdTipoUsuario.BindearPropiedadEntidad = "IdTipoUsuario"
        Me.txtIdTipoUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTipoUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTipoUsuario.Formato = ""
        Me.txtIdTipoUsuario.IsDecimal = False
        Me.txtIdTipoUsuario.IsNumber = True
        Me.txtIdTipoUsuario.IsPK = True
        Me.txtIdTipoUsuario.IsRequired = True
        Me.txtIdTipoUsuario.Key = ""
        Me.txtIdTipoUsuario.LabelAsoc = Me.lblCodigo
        Me.txtIdTipoUsuario.Location = New System.Drawing.Point(72, 12)
        Me.txtIdTipoUsuario.MaxLength = 10
        Me.txtIdTipoUsuario.Name = "txtIdTipoUsuario"
        Me.txtIdTipoUsuario.Size = New System.Drawing.Size(120, 20)
        Me.txtIdTipoUsuario.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(15, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'chbEsDeProceso
        '
        Me.chbEsDeProceso.AutoSize = True
        Me.chbEsDeProceso.BindearPropiedadControl = "Checked"
        Me.chbEsDeProceso.BindearPropiedadEntidad = "EsDeProceso"
        Me.chbEsDeProceso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsDeProceso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsDeProceso.IsPK = False
        Me.chbEsDeProceso.IsRequired = False
        Me.chbEsDeProceso.Key = Nothing
        Me.chbEsDeProceso.LabelAsoc = Nothing
        Me.chbEsDeProceso.Location = New System.Drawing.Point(72, 64)
        Me.chbEsDeProceso.Name = "chbEsDeProceso"
        Me.chbEsDeProceso.Size = New System.Drawing.Size(200, 17)
        Me.chbEsDeProceso.TabIndex = 4
        Me.chbEsDeProceso.Tag = "MAILREQUIERESSL"
        Me.chbEsDeProceso.Text = "Requiere una conexión segura (SSL)"
        Me.chbEsDeProceso.UseVisualStyleBackColor = True
        '
        'TiposUsuariosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 153)
        Me.Controls.Add(Me.chbEsDeProceso)
        Me.Controls.Add(Me.txtNombreTipoUsuario)
        Me.Controls.Add(Me.txtIdTipoUsuario)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblCodigo)
        Me.Name = "TiposUsuariosDetalle"
        Me.Text = "Tipos de Usuarios"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtIdTipoUsuario, 0)
        Me.Controls.SetChildIndex(Me.txtNombreTipoUsuario, 0)
        Me.Controls.SetChildIndex(Me.chbEsDeProceso, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNombreTipoUsuario As Controles.TextBox
    Friend WithEvents lblNombre As Controles.Label
    Friend WithEvents txtIdTipoUsuario As Controles.TextBox
    Friend WithEvents lblCodigo As Controles.Label
    Friend WithEvents chbEsDeProceso As Controles.CheckBox
End Class
