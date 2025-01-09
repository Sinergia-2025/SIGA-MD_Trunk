<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarTipoComprobante
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiarTipoComprobante))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.cmbtComprNuevo = New Eniac.Controles.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtLetra = New System.Windows.Forms.TextBox()
      Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
      Me.txtIdTipoComprobante = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblcompActual = New System.Windows.Forms.Label()
      Me.lblCambioMasivo = New Eniac.Controles.Label()
      Me.cmbCambioMasivo = New Eniac.Controles.ComboBox()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(371, 29)
      Me.tstBarra.TabIndex = 75
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
      'cmbtComprNuevo
      '
      Me.cmbtComprNuevo.BindearPropiedadControl = "SelectedValue"
      Me.cmbtComprNuevo.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbtComprNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbtComprNuevo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbtComprNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbtComprNuevo.FormattingEnabled = True
      Me.cmbtComprNuevo.IsPK = False
      Me.cmbtComprNuevo.IsRequired = True
      Me.cmbtComprNuevo.Key = Nothing
      Me.cmbtComprNuevo.LabelAsoc = Nothing
      Me.cmbtComprNuevo.Location = New System.Drawing.Point(153, 130)
      Me.cmbtComprNuevo.Name = "cmbtComprNuevo"
      Me.cmbtComprNuevo.Size = New System.Drawing.Size(181, 21)
      Me.cmbtComprNuevo.TabIndex = 74
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(20, 133)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(129, 13)
      Me.Label3.TabIndex = 73
      Me.Label3.Text = "Tipo Comprobante Nuevo"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(20, 106)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(130, 13)
      Me.Label2.TabIndex = 71
      Me.Label2.Text = "Tipo Comprobante Actual:"
      '
      'txtLetra
      '
      Me.txtLetra.Enabled = False
      Me.txtLetra.Location = New System.Drawing.Point(197, 62)
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.Size = New System.Drawing.Size(44, 20)
      Me.txtLetra.TabIndex = 70
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtNumeroComprobante
      '
      Me.txtNumeroComprobante.Enabled = False
      Me.txtNumeroComprobante.Location = New System.Drawing.Point(247, 62)
      Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
      Me.txtNumeroComprobante.Size = New System.Drawing.Size(87, 20)
      Me.txtNumeroComprobante.TabIndex = 69
      Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtIdTipoComprobante
      '
      Me.txtIdTipoComprobante.Enabled = False
      Me.txtIdTipoComprobante.Location = New System.Drawing.Point(66, 62)
      Me.txtIdTipoComprobante.Name = "txtIdTipoComprobante"
      Me.txtIdTipoComprobante.Size = New System.Drawing.Size(125, 20)
      Me.txtIdTipoComprobante.TabIndex = 68
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(20, 65)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 67
      Me.Label1.Text = "Pedido"
      '
      'lblcompActual
      '
      Me.lblcompActual.AutoSize = True
      Me.lblcompActual.Location = New System.Drawing.Point(150, 106)
      Me.lblcompActual.Name = "lblcompActual"
      Me.lblcompActual.Size = New System.Drawing.Size(0, 13)
      Me.lblcompActual.TabIndex = 76
      '
      'lblCambioMasivo
      '
      Me.lblCambioMasivo.AutoSize = True
      Me.lblCambioMasivo.Location = New System.Drawing.Point(20, 160)
      Me.lblCambioMasivo.Name = "lblCambioMasivo"
      Me.lblCambioMasivo.Size = New System.Drawing.Size(45, 13)
      Me.lblCambioMasivo.TabIndex = 78
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
      Me.cmbCambioMasivo.Location = New System.Drawing.Point(153, 157)
      Me.cmbCambioMasivo.Name = "cmbCambioMasivo"
      Me.cmbCambioMasivo.Size = New System.Drawing.Size(181, 21)
      Me.cmbCambioMasivo.TabIndex = 77
      '
      'CambiarTipoComprobante
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(371, 196)
      Me.Controls.Add(Me.lblCambioMasivo)
      Me.Controls.Add(Me.cmbCambioMasivo)
      Me.Controls.Add(Me.lblcompActual)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.cmbtComprNuevo)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtLetra)
      Me.Controls.Add(Me.txtNumeroComprobante)
      Me.Controls.Add(Me.txtIdTipoComprobante)
      Me.Controls.Add(Me.Label1)
      Me.Name = "CambiarTipoComprobante"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Tipo Comprobante"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbtComprNuevo As Eniac.Controles.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtLetra As System.Windows.Forms.TextBox
   Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
   Friend WithEvents txtIdTipoComprobante As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents lblcompActual As System.Windows.Forms.Label
   Friend WithEvents lblCambioMasivo As Eniac.Controles.Label
   Friend WithEvents cmbCambioMasivo As Eniac.Controles.ComboBox
End Class
