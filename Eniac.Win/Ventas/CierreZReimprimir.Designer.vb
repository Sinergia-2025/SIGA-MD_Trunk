<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CierreZReimprimir
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
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.btnProceder = New Eniac.Controles.Button()
      Me.txtNumeroDesde = New Eniac.Controles.TextBox()
      Me.lblNumeroDesde = New Eniac.Controles.Label()
      Me.lblNumeroHasta = New Eniac.Controles.Label()
      Me.txtNumeroHasta = New Eniac.Controles.TextBox()
      Me.ToolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(295, 31)
      Me.ToolStrip1.TabIndex = 5
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(67, 28)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'btnProceder
      '
      Me.btnProceder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnProceder.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
      Me.btnProceder.Location = New System.Drawing.Point(53, 131)
      Me.btnProceder.Name = "btnProceder"
      Me.btnProceder.Size = New System.Drawing.Size(179, 105)
      Me.btnProceder.TabIndex = 4
      Me.btnProceder.Text = "&Proceder"
      Me.btnProceder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.btnProceder.UseVisualStyleBackColor = True
      '
      'txtNumeroDesde
      '
      Me.txtNumeroDesde.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumeroDesde.BindearPropiedadControl = Nothing
      Me.txtNumeroDesde.BindearPropiedadEntidad = Nothing
      Me.txtNumeroDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroDesde.Formato = ""
      Me.txtNumeroDesde.IsDecimal = False
      Me.txtNumeroDesde.IsNumber = True
      Me.txtNumeroDesde.IsPK = False
      Me.txtNumeroDesde.IsRequired = True
      Me.txtNumeroDesde.Key = ""
      Me.txtNumeroDesde.LabelAsoc = Me.lblNumeroDesde
      Me.txtNumeroDesde.Location = New System.Drawing.Point(80, 48)
      Me.txtNumeroDesde.MaxLength = 5
      Me.txtNumeroDesde.Name = "txtNumeroDesde"
      Me.txtNumeroDesde.Size = New System.Drawing.Size(48, 20)
      Me.txtNumeroDesde.TabIndex = 0
      Me.txtNumeroDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroDesde
      '
      Me.lblNumeroDesde.AutoSize = True
      Me.lblNumeroDesde.Location = New System.Drawing.Point(36, 52)
      Me.lblNumeroDesde.Name = "lblNumeroDesde"
      Me.lblNumeroDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblNumeroDesde.TabIndex = 1
      Me.lblNumeroDesde.Text = "Desde"
      '
      'lblNumeroHasta
      '
      Me.lblNumeroHasta.AutoSize = True
      Me.lblNumeroHasta.Location = New System.Drawing.Point(162, 52)
      Me.lblNumeroHasta.Name = "lblNumeroHasta"
      Me.lblNumeroHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblNumeroHasta.TabIndex = 3
      Me.lblNumeroHasta.Text = "Hasta"
      '
      'txtNumeroHasta
      '
      Me.txtNumeroHasta.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumeroHasta.BindearPropiedadControl = Nothing
      Me.txtNumeroHasta.BindearPropiedadEntidad = Nothing
      Me.txtNumeroHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroHasta.Formato = ""
      Me.txtNumeroHasta.IsDecimal = False
      Me.txtNumeroHasta.IsNumber = True
      Me.txtNumeroHasta.IsPK = False
      Me.txtNumeroHasta.IsRequired = True
      Me.txtNumeroHasta.Key = ""
      Me.txtNumeroHasta.LabelAsoc = Me.lblNumeroHasta
      Me.txtNumeroHasta.Location = New System.Drawing.Point(202, 48)
      Me.txtNumeroHasta.MaxLength = 5
      Me.txtNumeroHasta.Name = "txtNumeroHasta"
      Me.txtNumeroHasta.Size = New System.Drawing.Size(48, 20)
      Me.txtNumeroHasta.TabIndex = 2
      Me.txtNumeroHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'CierreZReimprimir
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(295, 271)
      Me.Controls.Add(Me.txtNumeroHasta)
      Me.Controls.Add(Me.lblNumeroHasta)
      Me.Controls.Add(Me.lblNumeroDesde)
      Me.Controls.Add(Me.txtNumeroDesde)
      Me.Controls.Add(Me.btnProceder)
      Me.Controls.Add(Me.ToolStrip1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "CierreZReimprimir"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Reimprimir Cierre ""Z"" Anteriores"
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnProceder As Eniac.Controles.Button
   Friend WithEvents txtNumeroDesde As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroHasta As Eniac.Controles.Label
   Friend WithEvents lblNumeroDesde As Eniac.Controles.Label
   Friend WithEvents txtNumeroHasta As Eniac.Controles.TextBox
   'Friend WithEvents EpsonFP As AxEpsonFPHostControlX.AxEpsonFPHostControl
End Class
