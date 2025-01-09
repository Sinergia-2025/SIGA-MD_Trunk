<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarFechaEnvio
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiarFechaEnvio))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtIdTipoComprobante = New System.Windows.Forms.TextBox()
      Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
      Me.txtLetra = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.dtpFechaEnvio = New Eniac.Controles.DateTimePicker()
      Me.dtpFechaEnvioNueva = New Eniac.Controles.DateTimePicker()
      Me.lblCambioMasivo = New Eniac.Controles.Label()
      Me.cmbCambioMasivo = New Eniac.Controles.ComboBox()
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
      Me.Label2.Size = New System.Drawing.Size(84, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Fecha de Envío"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(352, 29)
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
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 113)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(119, 13)
      Me.Label3.TabIndex = 56
      Me.Label3.Text = "Fecha de Envío Nueva"
      '
      'dtpFechaEnvio
      '
      Me.dtpFechaEnvio.BindearPropiedadControl = Nothing
      Me.dtpFechaEnvio.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEnvio.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaEnvio.Enabled = False
      Me.dtpFechaEnvio.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEnvio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEnvio.IsPK = False
      Me.dtpFechaEnvio.IsRequired = False
      Me.dtpFechaEnvio.Key = ""
      Me.dtpFechaEnvio.LabelAsoc = Nothing
      Me.dtpFechaEnvio.Location = New System.Drawing.Point(152, 81)
      Me.dtpFechaEnvio.Name = "dtpFechaEnvio"
      Me.dtpFechaEnvio.Size = New System.Drawing.Size(97, 20)
      Me.dtpFechaEnvio.TabIndex = 59
      '
      'dtpFechaEnvioNueva
      '
      Me.dtpFechaEnvioNueva.BindearPropiedadControl = Nothing
      Me.dtpFechaEnvioNueva.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEnvioNueva.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaEnvioNueva.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEnvioNueva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEnvioNueva.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEnvioNueva.IsPK = False
      Me.dtpFechaEnvioNueva.IsRequired = False
      Me.dtpFechaEnvioNueva.Key = ""
      Me.dtpFechaEnvioNueva.LabelAsoc = Nothing
      Me.dtpFechaEnvioNueva.Location = New System.Drawing.Point(152, 107)
      Me.dtpFechaEnvioNueva.Name = "dtpFechaEnvioNueva"
      Me.dtpFechaEnvioNueva.Size = New System.Drawing.Size(97, 20)
      Me.dtpFechaEnvioNueva.TabIndex = 60
      '
      'lblCambioMasivo
      '
      Me.lblCambioMasivo.AutoSize = True
      Me.lblCambioMasivo.Location = New System.Drawing.Point(12, 136)
      Me.lblCambioMasivo.Name = "lblCambioMasivo"
      Me.lblCambioMasivo.Size = New System.Drawing.Size(45, 13)
      Me.lblCambioMasivo.TabIndex = 71
      Me.lblCambioMasivo.Text = "Cambiar"
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
      Me.cmbCambioMasivo.Location = New System.Drawing.Point(152, 133)
      Me.cmbCambioMasivo.Name = "cmbCambioMasivo"
      Me.cmbCambioMasivo.Size = New System.Drawing.Size(181, 21)
      Me.cmbCambioMasivo.TabIndex = 70
      '
      'CambiarFechaEnvio
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(352, 166)
      Me.Controls.Add(Me.lblCambioMasivo)
      Me.Controls.Add(Me.cmbCambioMasivo)
      Me.Controls.Add(Me.dtpFechaEnvioNueva)
      Me.Controls.Add(Me.dtpFechaEnvio)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtLetra)
      Me.Controls.Add(Me.txtNumeroComprobante)
      Me.Controls.Add(Me.txtIdTipoComprobante)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CambiarFechaEnvio"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Fecha Envío"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtIdTipoComprobante As System.Windows.Forms.TextBox
   Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
   Friend WithEvents txtLetra As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents dtpFechaEnvio As Eniac.Controles.DateTimePicker
    Friend WithEvents dtpFechaEnvioNueva As Eniac.Controles.DateTimePicker
   Friend WithEvents lblCambioMasivo As Eniac.Controles.Label
   Friend WithEvents cmbCambioMasivo As Eniac.Controles.ComboBox
End Class
