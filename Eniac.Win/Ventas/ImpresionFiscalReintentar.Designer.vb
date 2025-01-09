<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionFiscalReintentar
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpresionFiscalReintentar))
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbReintentarImpresion = New System.Windows.Forms.ToolStripButton()
      Me.txtMensaje = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tspFacturacion.SuspendLayout()
      Me.SuspendLayout()
      '
      'tspFacturacion
      '
      Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir, Me.ToolStripSeparator1, Me.tsbReintentarImpresion})
      Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
      Me.tspFacturacion.Name = "tspFacturacion"
      Me.tspFacturacion.Size = New System.Drawing.Size(298, 31)
      Me.tspFacturacion.TabIndex = 3
      Me.tspFacturacion.Text = "ToolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(67, 28)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
      '
      'tsbReintentarImpresion
      '
      Me.tsbReintentarImpresion.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbReintentarImpresion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbReintentarImpresion.Name = "tsbReintentarImpresion"
      Me.tsbReintentarImpresion.Size = New System.Drawing.Size(145, 28)
      Me.tsbReintentarImpresion.Text = "&Reintentar Impresión"
      '
      'txtMensaje
      '
      Me.txtMensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtMensaje.Enabled = False
      Me.txtMensaje.Location = New System.Drawing.Point(16, 65)
      Me.txtMensaje.Multiline = True
      Me.txtMensaje.Name = "txtMensaje"
      Me.txtMensaje.ReadOnly = True
      Me.txtMensaje.Size = New System.Drawing.Size(274, 56)
      Me.txtMensaje.TabIndex = 4
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Firebrick
      Me.Label1.Location = New System.Drawing.Point(14, 42)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(155, 13)
      Me.Label1.TabIndex = 5
      Me.Label1.Text = "Cantidad de Reintentos: 0"
      '
      'ImpresionFiscalReintentar
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(298, 133)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtMensaje)
      Me.Controls.Add(Me.tspFacturacion)
      Me.Name = "ImpresionFiscalReintentar"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Impresión Fiscal "
      Me.tspFacturacion.ResumeLayout(False)
      Me.tspFacturacion.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbReintentarImpresion As System.Windows.Forms.ToolStripButton
   Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
