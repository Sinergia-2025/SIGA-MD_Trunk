<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvisoProductoInexistente
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AvisoProductoInexistente))
      Me.lblLeyenda = New System.Windows.Forms.Label()
      Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
      Me.SuspendLayout()
      '
      'lblLeyenda
      '
      Me.lblLeyenda.Font = New System.Drawing.Font("Calibri", 110.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblLeyenda.ForeColor = System.Drawing.Color.Red
      Me.lblLeyenda.Location = New System.Drawing.Point(19, 31)
      Me.lblLeyenda.Name = "lblLeyenda"
      Me.lblLeyenda.Size = New System.Drawing.Size(853, 400)
      Me.lblLeyenda.TabIndex = 1
      Me.lblLeyenda.Text = "PRODUCTO NO EXISTE !!"
      '
      'Timer2
      '
      Me.Timer2.Enabled = True
      Me.Timer2.Interval = 1000
      '
      'AvisoProductoInexistente
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(884, 482)
      Me.Controls.Add(Me.lblLeyenda)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "AvisoProductoInexistente"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Producto Inexistente"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents lblLeyenda As System.Windows.Forms.Label
   Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
