<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LinkItemListaControl
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
      Me.txtNombreLink = New Eniac.Controles.TextBox()
      Me.btnAbrir = New Eniac.Controles.Button()
      Me.btnGuardar = New Eniac.Controles.Button()
      Me.btnBuscarLink = New System.Windows.Forms.Button()
      Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(373, 98)
      Me.btnAceptar.TabIndex = 2
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(459, 98)
      Me.btnCancelar.TabIndex = 3
      '
      'btnCopiar
      '
      Me.btnCopiar.Enabled = False
      Me.btnCopiar.Location = New System.Drawing.Point(50, 98)
      Me.btnCopiar.TabIndex = 8
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(-10, 98)
      Me.btnAplicar.TabIndex = 7
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(12, 55)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(27, 13)
      Me.lblNombre.TabIndex = 6
      Me.lblNombre.Text = "Link"
      '
      'txtNombreLink
      '
      Me.txtNombreLink.AcceptsReturn = True
      Me.txtNombreLink.BindearPropiedadControl = "Text"
      Me.txtNombreLink.BindearPropiedadEntidad = "Link"
      Me.txtNombreLink.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreLink.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreLink.Formato = ""
      Me.txtNombreLink.IsDecimal = False
      Me.txtNombreLink.IsNumber = False
      Me.txtNombreLink.IsPK = True
      Me.txtNombreLink.IsRequired = True
      Me.txtNombreLink.Key = ""
      Me.txtNombreLink.LabelAsoc = Me.lblNombre
      Me.txtNombreLink.Location = New System.Drawing.Point(74, 51)
      Me.txtNombreLink.MaxLength = 1000
      Me.txtNombreLink.Name = "txtNombreLink"
      Me.txtNombreLink.Size = New System.Drawing.Size(422, 20)
      Me.txtNombreLink.TabIndex = 1
      '
      'btnAbrir
      '
      Me.btnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAbrir.Image = Global.Eniac.Win.My.Resources.Resources.copy_ok_24
      Me.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAbrir.Location = New System.Drawing.Point(201, 98)
      Me.btnAbrir.Name = "btnAbrir"
      Me.btnAbrir.Size = New System.Drawing.Size(80, 30)
      Me.btnAbrir.TabIndex = 9
      Me.btnAbrir.Text = "Abrir"
      Me.btnAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAbrir.UseVisualStyleBackColor = True
      Me.btnAbrir.Visible = False
      '
      'btnGuardar
      '
      Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnGuardar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_16
      Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGuardar.Location = New System.Drawing.Point(287, 98)
      Me.btnGuardar.Name = "btnGuardar"
      Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
      Me.btnGuardar.TabIndex = 10
      Me.btnGuardar.Text = "Guardar"
      Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGuardar.UseVisualStyleBackColor = True
      Me.btnGuardar.Visible = False
      '
      'btnBuscarLink
      '
      Me.btnBuscarLink.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
      Me.btnBuscarLink.Location = New System.Drawing.Point(502, 50)
      Me.btnBuscarLink.Name = "btnBuscarLink"
      Me.btnBuscarLink.Size = New System.Drawing.Size(27, 23)
      Me.btnBuscarLink.TabIndex = 4
      Me.btnBuscarLink.UseVisualStyleBackColor = True
      '
      'DialogoAbrirArchivo
      '
      Me.DialogoAbrirArchivo.Filter = "Todos los Archivos (*.*)|*.*"
      Me.DialogoAbrirArchivo.RestoreDirectory = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(10, 26)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(63, 13)
      Me.Label1.TabIndex = 5
      Me.Label1.Text = "Descripción"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = True
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.Label1
      Me.txtDescripcion.Location = New System.Drawing.Point(74, 22)
      Me.txtDescripcion.MaxLength = 100
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(422, 20)
      Me.txtDescripcion.TabIndex = 0
      '
      'LinkItemListaControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(548, 136)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.btnBuscarLink)
      Me.Controls.Add(Me.btnGuardar)
      Me.Controls.Add(Me.btnAbrir)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombreLink)
      Me.Name = "LinkItemListaControl"
      Me.Text = "Agregar Link Lista de Control"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreLink, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.btnAbrir, 0)
      Me.Controls.SetChildIndex(Me.btnGuardar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnBuscarLink, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreLink As Eniac.Controles.TextBox
   Friend WithEvents btnAbrir As Eniac.Controles.Button
   Friend WithEvents btnGuardar As Eniac.Controles.Button
   Friend WithEvents btnBuscarLink As System.Windows.Forms.Button
   Friend WithEvents DialogoAbrirArchivo As System.Windows.Forms.OpenFileDialog
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
End Class
