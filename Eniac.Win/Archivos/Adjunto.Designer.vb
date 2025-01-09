<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Adjunto
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
      Me.txtNombreAdjunto = New Eniac.Controles.TextBox()
      Me.btnAbrir = New Eniac.Controles.Button()
      Me.btnGuardar = New Eniac.Controles.Button()
      Me.lblTamano = New Eniac.Controles.Label()
      Me.txtTamano = New Eniac.Controles.TextBox()
      Me.btnBuscarAdjunto = New System.Windows.Forms.Button()
      Me.cmbTipoAdjunto = New Eniac.Controles.ComboBox()
      Me.lblTipoAdjunto = New Eniac.Controles.Label()
      Me.lblObservaciones = New Eniac.Controles.Label()
      Me.txtObservaciones = New Eniac.Controles.TextBox()
      Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
      Me.txtNivelAutorizacion = New Eniac.Controles.TextBox()
      Me.lblNivelAutorizacion = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(395, 209)
      Me.btnAceptar.TabIndex = 13
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(481, 209)
      Me.btnCancelar.TabIndex = 14
      '
      'btnCopiar
      '
      Me.btnCopiar.Enabled = False
      Me.btnCopiar.Location = New System.Drawing.Point(72, 209)
      Me.btnCopiar.TabIndex = 16
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(12, 209)
      Me.btnAplicar.TabIndex = 15
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(10, 54)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombreAdjunto
      '
      Me.txtNombreAdjunto.BindearPropiedadControl = "Text"
      Me.txtNombreAdjunto.BindearPropiedadEntidad = "NombreAdjunto"
      Me.txtNombreAdjunto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreAdjunto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreAdjunto.Formato = ""
      Me.txtNombreAdjunto.IsDecimal = False
      Me.txtNombreAdjunto.IsNumber = False
      Me.txtNombreAdjunto.IsPK = True
      Me.txtNombreAdjunto.IsRequired = True
      Me.txtNombreAdjunto.Key = ""
      Me.txtNombreAdjunto.LabelAsoc = Me.lblNombre
      Me.txtNombreAdjunto.Location = New System.Drawing.Point(94, 50)
      Me.txtNombreAdjunto.MaxLength = 1
      Me.txtNombreAdjunto.Name = "txtNombreAdjunto"
      Me.txtNombreAdjunto.ReadOnly = True
      Me.txtNombreAdjunto.Size = New System.Drawing.Size(422, 20)
      Me.txtNombreAdjunto.TabIndex = 3
      '
      'btnAbrir
      '
      Me.btnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAbrir.Image = Global.Eniac.Win.My.Resources.Resources.copy_ok_24
      Me.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAbrir.Location = New System.Drawing.Point(223, 209)
      Me.btnAbrir.Name = "btnAbrir"
      Me.btnAbrir.Size = New System.Drawing.Size(80, 30)
      Me.btnAbrir.TabIndex = 11
      Me.btnAbrir.Text = "Abrir"
      Me.btnAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAbrir.UseVisualStyleBackColor = True
      '
      'btnGuardar
      '
      Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnGuardar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_16
      Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGuardar.Location = New System.Drawing.Point(309, 209)
      Me.btnGuardar.Name = "btnGuardar"
      Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
      Me.btnGuardar.TabIndex = 12
      Me.btnGuardar.Text = "Guardar"
      Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGuardar.UseVisualStyleBackColor = True
      '
      'lblTamano
      '
      Me.lblTamano.AutoSize = True
      Me.lblTamano.LabelAsoc = Nothing
      Me.lblTamano.Location = New System.Drawing.Point(366, 80)
      Me.lblTamano.Name = "lblTamano"
      Me.lblTamano.Size = New System.Drawing.Size(46, 13)
      Me.lblTamano.TabIndex = 7
      Me.lblTamano.Text = "Tamaño"
      '
      'txtTamano
      '
      Me.txtTamano.BindearPropiedadControl = ""
      Me.txtTamano.BindearPropiedadEntidad = ""
      Me.txtTamano.Enabled = False
      Me.txtTamano.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTamano.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTamano.Formato = ""
      Me.txtTamano.IsDecimal = False
      Me.txtTamano.IsNumber = False
      Me.txtTamano.IsPK = False
      Me.txtTamano.IsRequired = False
      Me.txtTamano.Key = ""
      Me.txtTamano.LabelAsoc = Nothing
      Me.txtTamano.Location = New System.Drawing.Point(421, 76)
      Me.txtTamano.MaxLength = 5
      Me.txtTamano.Name = "txtTamano"
      Me.txtTamano.Size = New System.Drawing.Size(128, 20)
      Me.txtTamano.TabIndex = 8
      Me.txtTamano.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnBuscarAdjunto
      '
      Me.btnBuscarAdjunto.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
      Me.btnBuscarAdjunto.Location = New System.Drawing.Point(522, 49)
      Me.btnBuscarAdjunto.Name = "btnBuscarAdjunto"
      Me.btnBuscarAdjunto.Size = New System.Drawing.Size(27, 23)
      Me.btnBuscarAdjunto.TabIndex = 4
      Me.btnBuscarAdjunto.UseVisualStyleBackColor = True
      '
      'cmbTipoAdjunto
      '
      Me.cmbTipoAdjunto.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoAdjunto.BindearPropiedadEntidad = "IdTipoAdjunto"
      Me.cmbTipoAdjunto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoAdjunto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoAdjunto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoAdjunto.FormattingEnabled = True
      Me.cmbTipoAdjunto.IsPK = False
      Me.cmbTipoAdjunto.IsRequired = True
      Me.cmbTipoAdjunto.Key = Nothing
      Me.cmbTipoAdjunto.LabelAsoc = Me.lblTipoAdjunto
      Me.cmbTipoAdjunto.Location = New System.Drawing.Point(94, 76)
      Me.cmbTipoAdjunto.Name = "cmbTipoAdjunto"
      Me.cmbTipoAdjunto.Size = New System.Drawing.Size(181, 21)
      Me.cmbTipoAdjunto.TabIndex = 6
      '
      'lblTipoAdjunto
      '
      Me.lblTipoAdjunto.AutoSize = True
      Me.lblTipoAdjunto.LabelAsoc = Nothing
      Me.lblTipoAdjunto.Location = New System.Drawing.Point(10, 80)
      Me.lblTipoAdjunto.Name = "lblTipoAdjunto"
      Me.lblTipoAdjunto.Size = New System.Drawing.Size(28, 13)
      Me.lblTipoAdjunto.TabIndex = 5
      Me.lblTipoAdjunto.Text = "Tipo"
      '
      'lblObservaciones
      '
      Me.lblObservaciones.AutoSize = True
      Me.lblObservaciones.LabelAsoc = Nothing
      Me.lblObservaciones.Location = New System.Drawing.Point(10, 103)
      Me.lblObservaciones.Name = "lblObservaciones"
      Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
      Me.lblObservaciones.TabIndex = 9
      Me.lblObservaciones.Text = "Observaciones"
      '
      'txtObservaciones
      '
      Me.txtObservaciones.BindearPropiedadControl = "Text"
      Me.txtObservaciones.BindearPropiedadEntidad = "Observaciones"
      Me.txtObservaciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservaciones.Formato = ""
      Me.txtObservaciones.IsDecimal = False
      Me.txtObservaciones.IsNumber = False
      Me.txtObservaciones.IsPK = False
      Me.txtObservaciones.IsRequired = False
      Me.txtObservaciones.Key = ""
      Me.txtObservaciones.LabelAsoc = Nothing
      Me.txtObservaciones.Location = New System.Drawing.Point(94, 103)
      Me.txtObservaciones.MaxLength = 1000
      Me.txtObservaciones.Multiline = True
      Me.txtObservaciones.Name = "txtObservaciones"
      Me.txtObservaciones.Size = New System.Drawing.Size(455, 88)
      Me.txtObservaciones.TabIndex = 10
      '
      'DialogoAbrirArchivo
      '
      Me.DialogoAbrirArchivo.Filter = "Todos los Archivos (*.*)|*.*"
      Me.DialogoAbrirArchivo.RestoreDirectory = True
      '
      'txtNivelAutorizacion
      '
      Me.txtNivelAutorizacion.BindearPropiedadControl = "Text"
      Me.txtNivelAutorizacion.BindearPropiedadEntidad = "NivelAutorizacion"
      Me.txtNivelAutorizacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNivelAutorizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNivelAutorizacion.Formato = ""
      Me.txtNivelAutorizacion.IsDecimal = False
      Me.txtNivelAutorizacion.IsNumber = True
      Me.txtNivelAutorizacion.IsPK = False
      Me.txtNivelAutorizacion.IsRequired = True
      Me.txtNivelAutorizacion.Key = ""
      Me.txtNivelAutorizacion.LabelAsoc = Me.lblNivelAutorizacion
      Me.txtNivelAutorizacion.Location = New System.Drawing.Point(505, 6)
      Me.txtNivelAutorizacion.MaxLength = 12
      Me.txtNivelAutorizacion.Name = "txtNivelAutorizacion"
      Me.txtNivelAutorizacion.Size = New System.Drawing.Size(42, 20)
      Me.txtNivelAutorizacion.TabIndex = 1
      Me.txtNivelAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNivelAutorizacion
      '
      Me.lblNivelAutorizacion.AutoSize = True
      Me.lblNivelAutorizacion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblNivelAutorizacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNivelAutorizacion.LabelAsoc = Nothing
      Me.lblNivelAutorizacion.Location = New System.Drawing.Point(392, 9)
      Me.lblNivelAutorizacion.Name = "lblNivelAutorizacion"
      Me.lblNivelAutorizacion.Size = New System.Drawing.Size(107, 13)
      Me.lblNivelAutorizacion.TabIndex = 0
      Me.lblNivelAutorizacion.Text = "Nivel de Autorización"
      '
      'Adjunto
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(570, 247)
      Me.Controls.Add(Me.txtNivelAutorizacion)
      Me.Controls.Add(Me.lblNivelAutorizacion)
      Me.Controls.Add(Me.cmbTipoAdjunto)
      Me.Controls.Add(Me.lblTipoAdjunto)
      Me.Controls.Add(Me.btnBuscarAdjunto)
      Me.Controls.Add(Me.txtObservaciones)
      Me.Controls.Add(Me.lblObservaciones)
      Me.Controls.Add(Me.txtTamano)
      Me.Controls.Add(Me.lblTamano)
      Me.Controls.Add(Me.btnGuardar)
      Me.Controls.Add(Me.btnAbrir)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombreAdjunto)
      Me.Name = "Adjunto"
      Me.Text = "Archivo Adjunto"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreAdjunto, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.btnAbrir, 0)
      Me.Controls.SetChildIndex(Me.btnGuardar, 0)
      Me.Controls.SetChildIndex(Me.lblTamano, 0)
      Me.Controls.SetChildIndex(Me.txtTamano, 0)
      Me.Controls.SetChildIndex(Me.lblObservaciones, 0)
      Me.Controls.SetChildIndex(Me.txtObservaciones, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnBuscarAdjunto, 0)
      Me.Controls.SetChildIndex(Me.lblTipoAdjunto, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoAdjunto, 0)
      Me.Controls.SetChildIndex(Me.lblNivelAutorizacion, 0)
      Me.Controls.SetChildIndex(Me.txtNivelAutorizacion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreAdjunto As Eniac.Controles.TextBox
   Friend WithEvents btnAbrir As Eniac.Controles.Button
   Friend WithEvents btnGuardar As Eniac.Controles.Button
   Friend WithEvents lblTamano As Eniac.Controles.Label
   Friend WithEvents txtTamano As Eniac.Controles.TextBox
   Friend WithEvents btnBuscarAdjunto As System.Windows.Forms.Button
   Friend WithEvents cmbTipoAdjunto As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoAdjunto As Eniac.Controles.Label
   Friend WithEvents lblObservaciones As Eniac.Controles.Label
   Friend WithEvents txtObservaciones As Eniac.Controles.TextBox
   Friend WithEvents DialogoAbrirArchivo As System.Windows.Forms.OpenFileDialog
   Protected WithEvents txtNivelAutorizacion As Eniac.Controles.TextBox
   Friend WithEvents lblNivelAutorizacion As Eniac.Controles.Label
End Class
