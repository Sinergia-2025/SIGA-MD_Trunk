<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarRespDistribucion
   Inherits System.Windows.Forms.Form

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiarRespDistribucion))
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtIdTipoComprobante = New System.Windows.Forms.TextBox()
      Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
      Me.txtLetra = New System.Windows.Forms.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.cmbRespDistribucion = New Eniac.Controles.ComboBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.cmbRespDistribucionNuevo = New Eniac.Controles.ComboBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.cmbCambioMasivo = New Eniac.Controles.ComboBox()
      Me.lblCambioMasivo = New Eniac.Controles.Label()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 49)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Pedido"
      '
      'txtIdTipoComprobante
      '
      Me.txtIdTipoComprobante.Enabled = False
      Me.txtIdTipoComprobante.Location = New System.Drawing.Point(58, 46)
      Me.txtIdTipoComprobante.Name = "txtIdTipoComprobante"
      Me.txtIdTipoComprobante.Size = New System.Drawing.Size(125, 20)
      Me.txtIdTipoComprobante.TabIndex = 1
      '
      'txtNumeroComprobante
      '
      Me.txtNumeroComprobante.Enabled = False
      Me.txtNumeroComprobante.Location = New System.Drawing.Point(239, 46)
      Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
      Me.txtNumeroComprobante.Size = New System.Drawing.Size(87, 20)
      Me.txtNumeroComprobante.TabIndex = 2
      Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtLetra
      '
      Me.txtLetra.Enabled = False
      Me.txtLetra.Location = New System.Drawing.Point(189, 46)
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.Size = New System.Drawing.Size(44, 20)
      Me.txtLetra.TabIndex = 3
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 90)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(127, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Responsable Distribución"
      '
      'cmbRespDistribucion
      '
      Me.cmbRespDistribucion.BindearPropiedadControl = "SelectedValue"
      Me.cmbRespDistribucion.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
      Me.cmbRespDistribucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRespDistribucion.Enabled = False
      Me.cmbRespDistribucion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRespDistribucion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRespDistribucion.FormattingEnabled = True
      Me.cmbRespDistribucion.IsPK = False
      Me.cmbRespDistribucion.IsRequired = True
      Me.cmbRespDistribucion.Key = Nothing
      Me.cmbRespDistribucion.LabelAsoc = Me.Label2
      Me.cmbRespDistribucion.Location = New System.Drawing.Point(180, 87)
      Me.cmbRespDistribucion.Name = "cmbRespDistribucion"
      Me.cmbRespDistribucion.Size = New System.Drawing.Size(181, 21)
      Me.cmbRespDistribucion.TabIndex = 54
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(384, 29)
      Me.tstBarra.TabIndex = 55
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "&Grabar"
      Me.tsbGrabar.ToolTipText = "Cerrar el formulario"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
      '
      'cmbRespDistribucionNuevo
      '
      Me.cmbRespDistribucionNuevo.BindearPropiedadControl = "SelectedValue"
      Me.cmbRespDistribucionNuevo.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
      Me.cmbRespDistribucionNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRespDistribucionNuevo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRespDistribucionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRespDistribucionNuevo.FormattingEnabled = True
      Me.cmbRespDistribucionNuevo.IsPK = False
      Me.cmbRespDistribucionNuevo.IsRequired = True
      Me.cmbRespDistribucionNuevo.Key = Nothing
      Me.cmbRespDistribucionNuevo.LabelAsoc = Me.Label3
      Me.cmbRespDistribucionNuevo.Location = New System.Drawing.Point(180, 114)
      Me.cmbRespDistribucionNuevo.Name = "cmbRespDistribucionNuevo"
      Me.cmbRespDistribucionNuevo.Size = New System.Drawing.Size(181, 21)
      Me.cmbRespDistribucionNuevo.TabIndex = 57
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 117)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(162, 13)
      Me.Label3.TabIndex = 56
      Me.Label3.Text = "Responsable Distribución Nuevo"
      '
      'cmbCambioMasivo
      '
      Me.cmbCambioMasivo.BindearPropiedadControl = "SelectedValue"
      Me.cmbCambioMasivo.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
      Me.cmbCambioMasivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCambioMasivo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCambioMasivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCambioMasivo.FormattingEnabled = True
      Me.cmbCambioMasivo.IsPK = False
      Me.cmbCambioMasivo.IsRequired = True
      Me.cmbCambioMasivo.Key = Nothing
      Me.cmbCambioMasivo.LabelAsoc = Me.lblCambioMasivo
      Me.cmbCambioMasivo.Location = New System.Drawing.Point(180, 141)
      Me.cmbCambioMasivo.Name = "cmbCambioMasivo"
      Me.cmbCambioMasivo.Size = New System.Drawing.Size(181, 21)
      Me.cmbCambioMasivo.TabIndex = 58
      '
      'lblCambioMasivo
      '
      Me.lblCambioMasivo.AutoSize = True
      Me.lblCambioMasivo.Location = New System.Drawing.Point(12, 144)
      Me.lblCambioMasivo.Name = "lblCambioMasivo"
      Me.lblCambioMasivo.Size = New System.Drawing.Size(45, 13)
      Me.lblCambioMasivo.TabIndex = 56
      Me.lblCambioMasivo.Text = "Cambiar"
      '
      'CambiarRespDistribucion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(384, 177)
      Me.Controls.Add(Me.cmbRespDistribucionNuevo)
      Me.Controls.Add(Me.lblCambioMasivo)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.cmbCambioMasivo)
      Me.Controls.Add(Me.cmbRespDistribucion)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtLetra)
      Me.Controls.Add(Me.txtNumeroComprobante)
      Me.Controls.Add(Me.txtIdTipoComprobante)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CambiarRespDistribucion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Responsable Distribución"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtIdTipoComprobante As System.Windows.Forms.TextBox
   Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
   Friend WithEvents txtLetra As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents cmbRespDistribucion As Eniac.Controles.ComboBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbRespDistribucionNuevo As Eniac.Controles.ComboBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cmbCambioMasivo As Eniac.Controles.ComboBox
   Friend WithEvents lblCambioMasivo As Eniac.Controles.Label
End Class
