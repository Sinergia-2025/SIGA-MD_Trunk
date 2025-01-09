<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarPalets
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiarPalets))
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtIdTipoComprobante = New System.Windows.Forms.TextBox()
      Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
      Me.txtLetra = New System.Windows.Forms.TextBox()
      Me.lblCantidadActual = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.lblNuevaCantidad = New Eniac.Controles.Label()
      Me.cmbCambioMasivo = New Eniac.Controles.ComboBox()
      Me.lblCambioMasivo = New Eniac.Controles.Label()
      Me.txtCantidaActual = New Eniac.Controles.TextBox()
      Me.txtNuevaCantidad = New Eniac.Controles.TextBox()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(12, 49)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Pedido"
      '
      'txtIdTipoComprobante
      '
      Me.txtIdTipoComprobante.Enabled = False
      Me.txtIdTipoComprobante.Location = New System.Drawing.Point(58, 46)
      Me.txtIdTipoComprobante.Name = "txtIdTipoComprobante"
      Me.txtIdTipoComprobante.Size = New System.Drawing.Size(125, 20)
      Me.txtIdTipoComprobante.TabIndex = 2
      Me.txtIdTipoComprobante.TabStop = False
      '
      'txtNumeroComprobante
      '
      Me.txtNumeroComprobante.Enabled = False
      Me.txtNumeroComprobante.Location = New System.Drawing.Point(239, 46)
      Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
      Me.txtNumeroComprobante.Size = New System.Drawing.Size(87, 20)
      Me.txtNumeroComprobante.TabIndex = 4
      Me.txtNumeroComprobante.TabStop = False
      Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtLetra
      '
      Me.txtLetra.Enabled = False
      Me.txtLetra.Location = New System.Drawing.Point(189, 46)
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.Size = New System.Drawing.Size(44, 20)
      Me.txtLetra.TabIndex = 3
      Me.txtLetra.TabStop = False
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblCantidadActual
      '
      Me.lblCantidadActual.AutoSize = True
      Me.lblCantidadActual.LabelAsoc = Nothing
      Me.lblCantidadActual.Location = New System.Drawing.Point(12, 88)
      Me.lblCantidadActual.Name = "lblCantidadActual"
      Me.lblCantidadActual.Size = New System.Drawing.Size(82, 13)
      Me.lblCantidadActual.TabIndex = 5
      Me.lblCantidadActual.Text = "Cantidad Actual"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(335, 29)
      Me.tstBarra.TabIndex = 0
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
      'lblNuevaCantidad
      '
      Me.lblNuevaCantidad.AutoSize = True
      Me.lblNuevaCantidad.LabelAsoc = Nothing
      Me.lblNuevaCantidad.Location = New System.Drawing.Point(10, 114)
      Me.lblNuevaCantidad.Name = "lblNuevaCantidad"
      Me.lblNuevaCantidad.Size = New System.Drawing.Size(84, 13)
      Me.lblNuevaCantidad.TabIndex = 7
      Me.lblNuevaCantidad.Text = "Nueva Cantidad"
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
      Me.cmbCambioMasivo.Location = New System.Drawing.Point(110, 136)
      Me.cmbCambioMasivo.Name = "cmbCambioMasivo"
      Me.cmbCambioMasivo.Size = New System.Drawing.Size(181, 21)
      Me.cmbCambioMasivo.TabIndex = 10
      '
      'lblCambioMasivo
      '
      Me.lblCambioMasivo.AutoSize = True
      Me.lblCambioMasivo.LabelAsoc = Nothing
      Me.lblCambioMasivo.Location = New System.Drawing.Point(12, 139)
      Me.lblCambioMasivo.Name = "lblCambioMasivo"
      Me.lblCambioMasivo.Size = New System.Drawing.Size(45, 13)
      Me.lblCambioMasivo.TabIndex = 9
      Me.lblCambioMasivo.Text = "Cambiar"
      '
      'txtCantidaActual
      '
      Me.txtCantidaActual.BindearPropiedadControl = Nothing
      Me.txtCantidaActual.BindearPropiedadEntidad = Nothing
      Me.txtCantidaActual.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidaActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidaActual.Formato = "##0"
      Me.txtCantidaActual.IsDecimal = False
      Me.txtCantidaActual.IsNumber = True
      Me.txtCantidaActual.IsPK = False
      Me.txtCantidaActual.IsRequired = False
      Me.txtCantidaActual.Key = ""
      Me.txtCantidaActual.LabelAsoc = Me.lblCantidadActual
      Me.txtCantidaActual.Location = New System.Drawing.Point(110, 85)
      Me.txtCantidaActual.MaxLength = 8
      Me.txtCantidaActual.Name = "txtCantidaActual"
      Me.txtCantidaActual.ReadOnly = True
      Me.txtCantidaActual.Size = New System.Drawing.Size(73, 20)
      Me.txtCantidaActual.TabIndex = 6
      Me.txtCantidaActual.TabStop = False
      Me.txtCantidaActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNuevaCantidad
      '
      Me.txtNuevaCantidad.BindearPropiedadControl = Nothing
      Me.txtNuevaCantidad.BindearPropiedadEntidad = Nothing
      Me.txtNuevaCantidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNuevaCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNuevaCantidad.Formato = "##0"
      Me.txtNuevaCantidad.IsDecimal = False
      Me.txtNuevaCantidad.IsNumber = True
      Me.txtNuevaCantidad.IsPK = False
      Me.txtNuevaCantidad.IsRequired = False
      Me.txtNuevaCantidad.Key = ""
      Me.txtNuevaCantidad.LabelAsoc = Me.lblNuevaCantidad
      Me.txtNuevaCantidad.Location = New System.Drawing.Point(110, 111)
      Me.txtNuevaCantidad.MaxLength = 8
      Me.txtNuevaCantidad.Name = "txtNuevaCantidad"
      Me.txtNuevaCantidad.Size = New System.Drawing.Size(73, 20)
      Me.txtNuevaCantidad.TabIndex = 8
      Me.txtNuevaCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'CambiarPalets
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(335, 177)
      Me.Controls.Add(Me.txtNuevaCantidad)
      Me.Controls.Add(Me.txtCantidaActual)
      Me.Controls.Add(Me.lblCambioMasivo)
      Me.Controls.Add(Me.lblNuevaCantidad)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.cmbCambioMasivo)
      Me.Controls.Add(Me.lblCantidadActual)
      Me.Controls.Add(Me.txtLetra)
      Me.Controls.Add(Me.txtNumeroComprobante)
      Me.Controls.Add(Me.txtIdTipoComprobante)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CambiarPalets"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Modificar Cantidad de Palets"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtIdTipoComprobante As System.Windows.Forms.TextBox
   Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
   Friend WithEvents txtLetra As System.Windows.Forms.TextBox
   Friend WithEvents lblCantidadActual As Eniac.Controles.Label
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblNuevaCantidad As Eniac.Controles.Label
   Friend WithEvents cmbCambioMasivo As Eniac.Controles.ComboBox
   Friend WithEvents lblCambioMasivo As Eniac.Controles.Label
   Friend WithEvents txtCantidaActual As Eniac.Controles.TextBox
   Friend WithEvents txtNuevaCantidad As Eniac.Controles.TextBox
End Class
