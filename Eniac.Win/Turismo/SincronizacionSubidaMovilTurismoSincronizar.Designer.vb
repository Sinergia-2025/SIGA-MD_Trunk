<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizacionSubidaMovilTurismoSincronizar
   Inherits BaseForm

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
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnSubir = New System.Windows.Forms.Button()
      Me.btnDescargar = New System.Windows.Forms.Button()
      Me.btnSubirDescargar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.delete2
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(201, 222)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(130, 45)
      Me.btnCancelar.TabIndex = 3
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnSubir
      '
      Me.btnSubir.Image = Global.Eniac.Win.My.Resources.Resources.world_up_64
      Me.btnSubir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnSubir.Location = New System.Drawing.Point(12, 12)
      Me.btnSubir.Name = "btnSubir"
      Me.btnSubir.Size = New System.Drawing.Size(319, 64)
      Me.btnSubir.TabIndex = 0
      Me.btnSubir.Text = "&Subir Información"
      Me.btnSubir.UseVisualStyleBackColor = True
      '
      'btnDescargar
      '
      Me.btnDescargar.Image = Global.Eniac.Win.My.Resources.Resources.world_down_64
      Me.btnDescargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnDescargar.Location = New System.Drawing.Point(12, 82)
      Me.btnDescargar.Name = "btnDescargar"
      Me.btnDescargar.Size = New System.Drawing.Size(319, 64)
      Me.btnDescargar.TabIndex = 1
      Me.btnDescargar.Text = "&Descargar Reservas"
      Me.btnDescargar.UseVisualStyleBackColor = True
      '
      'btnSubirDescargar
      '
      Me.btnSubirDescargar.Image = Global.Eniac.Win.My.Resources.Resources.world_refresh_64
      Me.btnSubirDescargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnSubirDescargar.Location = New System.Drawing.Point(12, 152)
      Me.btnSubirDescargar.Name = "btnSubirDescargar"
      Me.btnSubirDescargar.Size = New System.Drawing.Size(319, 64)
      Me.btnSubirDescargar.TabIndex = 2
      Me.btnSubirDescargar.Text = "Subir Información &y Descargar Reservas"
      Me.btnSubirDescargar.UseVisualStyleBackColor = True
      '
      'SincronizacionSubidaMovilTurismoSincronizar
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(343, 279)
      Me.Controls.Add(Me.btnSubirDescargar)
      Me.Controls.Add(Me.btnDescargar)
      Me.Controls.Add(Me.btnSubir)
      Me.Controls.Add(Me.btnCancelar)
      Me.Name = "SincronizacionSubidaMovilTurismoSincronizar"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleccione qué desea sincronizar"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnSubir As System.Windows.Forms.Button
   Friend WithEvents btnDescargar As System.Windows.Forms.Button
   Friend WithEvents btnSubirDescargar As System.Windows.Forms.Button
End Class
