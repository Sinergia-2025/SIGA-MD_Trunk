<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMNovedadesSeguimientoAdjunto
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
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.btnAbrir = New Eniac.Controles.Button()
      Me.btnGuardar = New Eniac.Controles.Button()
      Me.lblTamaño = New Eniac.Controles.Label()
      Me.txtTamaño = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Enabled = False
      Me.btnAceptar.Location = New System.Drawing.Point(123, 123)
      Me.btnAceptar.Visible = False
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(453, 110)
      '
      'btnCopiar
      '
      Me.btnCopiar.Enabled = False
      Me.btnCopiar.Location = New System.Drawing.Point(22, 123)
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(23, 29)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 8
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreAdjunto"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = True
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(78, 25)
      Me.txtNombre.MaxLength = 1
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.ReadOnly = True
      Me.txtNombre.Size = New System.Drawing.Size(455, 20)
      Me.txtNombre.TabIndex = 9
      '
      'btnAbrir
      '
      Me.btnAbrir.Image = Global.Eniac.Win.My.Resources.Resources.copy_ok_24
      Me.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAbrir.Location = New System.Drawing.Point(281, 110)
      Me.btnAbrir.Name = "btnAbrir"
      Me.btnAbrir.Size = New System.Drawing.Size(80, 30)
      Me.btnAbrir.TabIndex = 16
      Me.btnAbrir.Text = "Abrir"
      Me.btnAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAbrir.UseVisualStyleBackColor = True
      '
      'btnGuardar
      '
      Me.btnGuardar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_16
      Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGuardar.Location = New System.Drawing.Point(367, 110)
      Me.btnGuardar.Name = "btnGuardar"
      Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
      Me.btnGuardar.TabIndex = 17
      Me.btnGuardar.Text = "Guardar"
      Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGuardar.UseVisualStyleBackColor = True
      '
      'lblTamaño
      '
      Me.lblTamaño.AutoSize = True
      Me.lblTamaño.Location = New System.Drawing.Point(23, 76)
      Me.lblTamaño.Name = "lblTamaño"
      Me.lblTamaño.Size = New System.Drawing.Size(46, 13)
      Me.lblTamaño.TabIndex = 20
      Me.lblTamaño.Text = "Tamaño"
      '
      'txtTamaño
      '
      Me.txtTamaño.BindearPropiedadControl = ""
      Me.txtTamaño.BindearPropiedadEntidad = ""
      Me.txtTamaño.Enabled = False
      Me.txtTamaño.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTamaño.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTamaño.Formato = ""
      Me.txtTamaño.IsDecimal = False
      Me.txtTamaño.IsNumber = False
      Me.txtTamaño.IsPK = False
      Me.txtTamaño.IsRequired = True
      Me.txtTamaño.Key = ""
      Me.txtTamaño.LabelAsoc = Nothing
      Me.txtTamaño.Location = New System.Drawing.Point(78, 73)
      Me.txtTamaño.MaxLength = 5
      Me.txtTamaño.Name = "txtTamaño"
      Me.txtTamaño.Size = New System.Drawing.Size(128, 20)
      Me.txtTamaño.TabIndex = 21
      Me.txtTamaño.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'CRMNovedadesSeguimientoAdjunto
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(548, 170)
      Me.Controls.Add(Me.txtTamaño)
      Me.Controls.Add(Me.lblTamaño)
      Me.Controls.Add(Me.btnGuardar)
      Me.Controls.Add(Me.btnAbrir)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Name = "CRMNovedadesSeguimientoAdjunto"
      Me.Text = "Archivo Adjunto"
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.btnAbrir, 0)
      Me.Controls.SetChildIndex(Me.btnGuardar, 0)
      Me.Controls.SetChildIndex(Me.lblTamaño, 0)
      Me.Controls.SetChildIndex(Me.txtTamaño, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents btnAbrir As Eniac.Controles.Button
   Friend WithEvents btnGuardar As Eniac.Controles.Button
   Friend WithEvents lblTamaño As Eniac.Controles.Label
   Friend WithEvents txtTamaño As Eniac.Controles.TextBox
End Class
