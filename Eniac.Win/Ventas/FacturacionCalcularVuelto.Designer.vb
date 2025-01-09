<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturacionCalcularVuelto
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
   '<System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturacionCalcularVuelto))
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.lblVuelto = New Eniac.Controles.Label()
      Me.txtVuelto = New Eniac.Controles.TextBox()
      Me.lblPago = New Eniac.Controles.Label()
      Me.txtPago = New Eniac.Controles.TextBox()
      Me.lblTotalComprobante = New Eniac.Controles.Label()
      Me.txtTotalComprobante = New Eniac.Controles.TextBox()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      Me.imgIconos.Images.SetKeyName(1, "check2.ico")
      Me.imgIconos.Images.SetKeyName(2, "delete2.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(662, 29)
      Me.tstBarra.TabIndex = 6
      Me.tstBarra.Text = "toolStrip1"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'lblVuelto
      '
      Me.lblVuelto.AutoSize = True
      Me.lblVuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblVuelto.Location = New System.Drawing.Point(248, 195)
      Me.lblVuelto.Name = "lblVuelto"
      Me.lblVuelto.Size = New System.Drawing.Size(134, 46)
      Me.lblVuelto.TabIndex = 2
      Me.lblVuelto.Text = "Vuelto"
      '
      'txtVuelto
      '
      Me.txtVuelto.BindearPropiedadControl = Nothing
      Me.txtVuelto.BindearPropiedadEntidad = Nothing
      Me.txtVuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtVuelto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtVuelto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtVuelto.Formato = "##,##0.00"
      Me.txtVuelto.IsDecimal = True
      Me.txtVuelto.IsNumber = True
      Me.txtVuelto.IsPK = False
      Me.txtVuelto.IsRequired = False
      Me.txtVuelto.Key = ""
      Me.txtVuelto.LabelAsoc = Me.lblVuelto
      Me.txtVuelto.Location = New System.Drawing.Point(388, 192)
      Me.txtVuelto.Name = "txtVuelto"
      Me.txtVuelto.ReadOnly = True
      Me.txtVuelto.Size = New System.Drawing.Size(252, 53)
      Me.txtVuelto.TabIndex = 3
      Me.txtVuelto.TabStop = False
      Me.txtVuelto.Text = "0.00"
      Me.txtVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPago
      '
      Me.lblPago.AutoSize = True
      Me.lblPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblPago.Location = New System.Drawing.Point(268, 129)
      Me.lblPago.Name = "lblPago"
      Me.lblPago.Size = New System.Drawing.Size(114, 46)
      Me.lblPago.TabIndex = 0
      Me.lblPago.Text = "Pago"
      '
      'txtPago
      '
      Me.txtPago.BindearPropiedadControl = Nothing
      Me.txtPago.BindearPropiedadEntidad = Nothing
      Me.txtPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPago.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPago.Formato = "##,##0.00"
      Me.txtPago.IsDecimal = True
      Me.txtPago.IsNumber = True
      Me.txtPago.IsPK = False
      Me.txtPago.IsRequired = False
      Me.txtPago.Key = ""
      Me.txtPago.LabelAsoc = Me.lblPago
      Me.txtPago.Location = New System.Drawing.Point(388, 126)
      Me.txtPago.MaxLength = 10
      Me.txtPago.Name = "txtPago"
      Me.txtPago.Size = New System.Drawing.Size(252, 53)
      Me.txtPago.TabIndex = 1
      Me.txtPago.Text = "0.00"
      Me.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalComprobante
      '
      Me.lblTotalComprobante.AutoSize = True
      Me.lblTotalComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotalComprobante.Location = New System.Drawing.Point(20, 61)
      Me.lblTotalComprobante.Name = "lblTotalComprobante"
      Me.lblTotalComprobante.Size = New System.Drawing.Size(362, 46)
      Me.lblTotalComprobante.TabIndex = 4
      Me.lblTotalComprobante.Text = "Total Comprobante"
      '
      'txtTotalComprobante
      '
      Me.txtTotalComprobante.BindearPropiedadControl = Nothing
      Me.txtTotalComprobante.BindearPropiedadEntidad = Nothing
      Me.txtTotalComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotalComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalComprobante.Formato = "##,##0.00"
      Me.txtTotalComprobante.IsDecimal = True
      Me.txtTotalComprobante.IsNumber = True
      Me.txtTotalComprobante.IsPK = False
      Me.txtTotalComprobante.IsRequired = False
      Me.txtTotalComprobante.Key = ""
      Me.txtTotalComprobante.LabelAsoc = Me.lblTotalComprobante
      Me.txtTotalComprobante.Location = New System.Drawing.Point(388, 58)
      Me.txtTotalComprobante.Name = "txtTotalComprobante"
      Me.txtTotalComprobante.ReadOnly = True
      Me.txtTotalComprobante.Size = New System.Drawing.Size(252, 53)
      Me.txtTotalComprobante.TabIndex = 5
      Me.txtTotalComprobante.TabStop = False
      Me.txtTotalComprobante.Text = "0.00"
      Me.txtTotalComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'FacturacionCalcularVuelto
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(662, 268)
      Me.Controls.Add(Me.lblVuelto)
      Me.Controls.Add(Me.txtVuelto)
      Me.Controls.Add(Me.lblPago)
      Me.Controls.Add(Me.txtPago)
      Me.Controls.Add(Me.lblTotalComprobante)
      Me.Controls.Add(Me.txtTotalComprobante)
      Me.Controls.Add(Me.tstBarra)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FacturacionCalcularVuelto"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Facturación - Calcular Vuelto de Comprobante"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblVuelto As Eniac.Controles.Label
   Friend WithEvents txtVuelto As Eniac.Controles.TextBox
   Friend WithEvents lblPago As Eniac.Controles.Label
   Friend WithEvents txtPago As Eniac.Controles.TextBox
   Friend WithEvents lblTotalComprobante As Eniac.Controles.Label
   Friend WithEvents txtTotalComprobante As Eniac.Controles.TextBox
End Class
