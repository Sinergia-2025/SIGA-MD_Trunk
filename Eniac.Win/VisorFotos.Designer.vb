<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorFotos
   Inherits Eniac.Win.BaseForm

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
      Me.pcbFoto = New System.Windows.Forms.PictureBox()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.tsbDescargar = New System.Windows.Forms.ToolStripButton()
      Me.sfdArchivo = New System.Windows.Forms.SaveFileDialog()
      CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ToolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'pcbFoto
      '
      Me.pcbFoto.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pcbFoto.InitialImage = Nothing
      Me.pcbFoto.Location = New System.Drawing.Point(0, 25)
      Me.pcbFoto.Name = "pcbFoto"
      Me.pcbFoto.Size = New System.Drawing.Size(592, 541)
      Me.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
      Me.pcbFoto.TabIndex = 2
      Me.pcbFoto.TabStop = False
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDescargar})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(592, 25)
      Me.ToolStrip1.TabIndex = 3
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'tsbDescargar
      '
      Me.tsbDescargar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
      Me.tsbDescargar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbDescargar.Name = "tsbDescargar"
      Me.tsbDescargar.Size = New System.Drawing.Size(79, 22)
      Me.tsbDescargar.Text = "Descargar"
      '
      'sfdArchivo
      '
      Me.sfdArchivo.Title = "Descargar Archivo"
      '
      'VisorFotos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(592, 566)
      Me.Controls.Add(Me.pcbFoto)
      Me.Controls.Add(Me.ToolStrip1)
      Me.MinimizeBox = False
      Me.Name = "VisorFotos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Visor de Fotos"
      CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents pcbFoto As System.Windows.Forms.PictureBox
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbDescargar As System.Windows.Forms.ToolStripButton
   Friend WithEvents sfdArchivo As System.Windows.Forms.SaveFileDialog
End Class
