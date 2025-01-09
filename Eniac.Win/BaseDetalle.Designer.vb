<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseDetalle
   Inherits Eniac.Win.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseDetalle))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnCopiar = New System.Windows.Forms.Button()
      Me.btnAplicar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(211, 199)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 3
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(297, 199)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 2
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnCopiar
      '
      Me.btnCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCopiar.ImageIndex = 0
      Me.btnCopiar.Location = New System.Drawing.Point(110, 199)
      Me.btnCopiar.Name = "btnCopiar"
      Me.btnCopiar.Size = New System.Drawing.Size(95, 30)
      Me.btnCopiar.TabIndex = 3
      Me.btnCopiar.Text = "&Aceptar y Copiar"
      Me.btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCopiar.UseVisualStyleBackColor = True
      Me.btnCopiar.Visible = False
      '
      'btnAplicar
      '
      Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAplicar.ImageIndex = 0
      Me.btnAplicar.Location = New System.Drawing.Point(53, 199)
      Me.btnAplicar.Name = "btnAplicar"
      Me.btnAplicar.Size = New System.Drawing.Size(54, 30)
      Me.btnAplicar.TabIndex = 4
      Me.btnAplicar.Text = "&Aplicar"
      Me.btnAplicar.UseVisualStyleBackColor = True
      Me.btnAplicar.Visible = False
      '
      'BaseDetalle
      '
      Me.AcceptButton = Me.btnAceptar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(386, 234)
      Me.Controls.Add(Me.btnAplicar)
      Me.Controls.Add(Me.btnCopiar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "BaseDetalle"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "BaseDetalle"
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Protected WithEvents btnCopiar As System.Windows.Forms.Button
   Protected WithEvents btnAplicar As System.Windows.Forms.Button
End Class
