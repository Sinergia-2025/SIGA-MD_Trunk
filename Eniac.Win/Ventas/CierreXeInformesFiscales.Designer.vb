<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CierreXeInformesFiscales
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.btnProceder = New Eniac.Controles.Button
      Me.optCierreX = New System.Windows.Forms.RadioButton
      Me.optAuditoriaPorFecha = New System.Windows.Forms.RadioButton
      Me.optAuditoriaPorNroCierre = New System.Windows.Forms.RadioButton
      Me.ToolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(367, 25)
      Me.ToolStrip1.TabIndex = 0
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'btnProceder
      '
      Me.btnProceder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnProceder.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
      Me.btnProceder.Location = New System.Drawing.Point(110, 115)
      Me.btnProceder.Name = "btnProceder"
      Me.btnProceder.Size = New System.Drawing.Size(145, 76)
      Me.btnProceder.TabIndex = 2
      Me.btnProceder.Text = "&Proceder"
      Me.btnProceder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.btnProceder.UseVisualStyleBackColor = True
      '
      'optCierreX
      '
      Me.optCierreX.AutoSize = True
      Me.optCierreX.Checked = True
      Me.optCierreX.Location = New System.Drawing.Point(14, 59)
      Me.optCierreX.Name = "optCierreX"
      Me.optCierreX.Size = New System.Drawing.Size(72, 17)
      Me.optCierreX.TabIndex = 3
      Me.optCierreX.TabStop = True
      Me.optCierreX.Text = "Cierre ""X"""
      Me.optCierreX.UseVisualStyleBackColor = True
      '
      'optAuditoriaPorFecha
      '
      Me.optAuditoriaPorFecha.AutoSize = True
      Me.optAuditoriaPorFecha.Location = New System.Drawing.Point(94, 59)
      Me.optAuditoriaPorFecha.Name = "optAuditoriaPorFecha"
      Me.optAuditoriaPorFecha.Size = New System.Drawing.Size(117, 17)
      Me.optAuditoriaPorFecha.TabIndex = 4
      Me.optAuditoriaPorFecha.Text = "Auditoria por Fecha"
      Me.optAuditoriaPorFecha.UseVisualStyleBackColor = True
      '
      'optAuditoriaPorNroCierre
      '
      Me.optAuditoriaPorNroCierre.AutoSize = True
      Me.optAuditoriaPorNroCierre.Location = New System.Drawing.Point(219, 59)
      Me.optAuditoriaPorNroCierre.Name = "optAuditoriaPorNroCierre"
      Me.optAuditoriaPorNroCierre.Size = New System.Drawing.Size(137, 17)
      Me.optAuditoriaPorNroCierre.TabIndex = 5
      Me.optAuditoriaPorNroCierre.Text = "Auditoria por Nro. Cierre"
      Me.optAuditoriaPorNroCierre.UseVisualStyleBackColor = True
      '
      'CierreXeInformesFiscales
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(367, 234)
      Me.Controls.Add(Me.optAuditoriaPorNroCierre)
      Me.Controls.Add(Me.optAuditoriaPorFecha)
      Me.Controls.Add(Me.optCierreX)
      Me.Controls.Add(Me.btnProceder)
      Me.Controls.Add(Me.ToolStrip1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "CierreXeInformesFiscales"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Emisión de Cierre ""X"" e Informes de Auditorías"
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnProceder As Eniac.Controles.Button
   Friend WithEvents optCierreX As System.Windows.Forms.RadioButton
   Friend WithEvents optAuditoriaPorFecha As System.Windows.Forms.RadioButton
   Friend WithEvents optAuditoriaPorNroCierre As System.Windows.Forms.RadioButton
End Class
