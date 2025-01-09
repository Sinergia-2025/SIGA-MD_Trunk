<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepartoCambiarTipoComprobante
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RepartoCambiarTipoComprobante))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.cmbtComprNuevo = New Eniac.Controles.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtCliente = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbCambioMasivo = New Eniac.Controles.ComboBox()
      Me.txtDireccion = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chbCambiarTipoComprobante = New System.Windows.Forms.CheckBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.txtCategoriaActual = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.chbCambiarCategoria = New System.Windows.Forms.CheckBox()
      Me.cmbCategoriaNueva = New Eniac.Controles.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cmbCambioMasivoCategoria = New Eniac.Controles.ComboBox()
      Me.txtTipoComprobanteActual = New System.Windows.Forms.TextBox()
      Me.tstBarra.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
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
      Me.cmbtComprNuevo.Enabled = False
      Me.cmbtComprNuevo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbtComprNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbtComprNuevo.FormattingEnabled = True
      Me.cmbtComprNuevo.IsPK = False
      Me.cmbtComprNuevo.IsRequired = True
      Me.cmbtComprNuevo.Key = Nothing
      Me.cmbtComprNuevo.LabelAsoc = Nothing
      Me.cmbtComprNuevo.Location = New System.Drawing.Point(137, 43)
      Me.cmbtComprNuevo.Name = "cmbtComprNuevo"
      Me.cmbtComprNuevo.Size = New System.Drawing.Size(181, 21)
      Me.cmbtComprNuevo.TabIndex = 74
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(4, 46)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(129, 13)
      Me.Label3.TabIndex = 73
      Me.Label3.Text = "Tipo Comprobante Nuevo"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(4, 19)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(130, 13)
      Me.Label2.TabIndex = 71
      Me.Label2.Text = "Tipo Comprobante Actual:"
      '
      'txtCliente
      '
      Me.txtCliente.Enabled = False
      Me.txtCliente.Location = New System.Drawing.Point(12, 54)
      Me.txtCliente.Name = "txtCliente"
      Me.txtCliente.Size = New System.Drawing.Size(347, 20)
      Me.txtCliente.TabIndex = 68
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(9, 38)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(39, 13)
      Me.Label1.TabIndex = 67
      Me.Label1.Text = "Cliente"
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
      Me.cmbCambioMasivo.LabelAsoc = Nothing
      Me.cmbCambioMasivo.Location = New System.Drawing.Point(137, 70)
      Me.cmbCambioMasivo.Name = "cmbCambioMasivo"
      Me.cmbCambioMasivo.Size = New System.Drawing.Size(181, 21)
      Me.cmbCambioMasivo.TabIndex = 77
      '
      'txtDireccion
      '
      Me.txtDireccion.Enabled = False
      Me.txtDireccion.Location = New System.Drawing.Point(12, 96)
      Me.txtDireccion.Multiline = True
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.Size = New System.Drawing.Size(347, 63)
      Me.txtDireccion.TabIndex = 79
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 80)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(52, 13)
      Me.Label4.TabIndex = 80
      Me.Label4.Text = "Direccion"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chbCambiarTipoComprobante)
      Me.GroupBox1.Controls.Add(Me.cmbtComprNuevo)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.cmbCambioMasivo)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 164)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(347, 100)
      Me.GroupBox1.TabIndex = 81
      Me.GroupBox1.TabStop = False
      '
      'chbCambiarTipoComprobante
      '
      Me.chbCambiarTipoComprobante.AutoSize = True
      Me.chbCambiarTipoComprobante.Location = New System.Drawing.Point(7, 70)
      Me.chbCambiarTipoComprobante.Name = "chbCambiarTipoComprobante"
      Me.chbCambiarTipoComprobante.Size = New System.Drawing.Size(64, 17)
      Me.chbCambiarTipoComprobante.TabIndex = 79
      Me.chbCambiarTipoComprobante.Text = "Cambiar"
      Me.chbCambiarTipoComprobante.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.txtCategoriaActual)
      Me.GroupBox2.Controls.Add(Me.Label7)
      Me.GroupBox2.Controls.Add(Me.chbCambiarCategoria)
      Me.GroupBox2.Controls.Add(Me.cmbCategoriaNueva)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.Label6)
      Me.GroupBox2.Controls.Add(Me.cmbCambioMasivoCategoria)
      Me.GroupBox2.Location = New System.Drawing.Point(12, 270)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(347, 100)
      Me.GroupBox2.TabIndex = 82
      Me.GroupBox2.TabStop = False
      '
      'txtCategoriaActual
      '
      Me.txtCategoriaActual.Enabled = False
      Me.txtCategoriaActual.Location = New System.Drawing.Point(136, 19)
      Me.txtCategoriaActual.Name = "txtCategoriaActual"
      Me.txtCategoriaActual.ReadOnly = True
      Me.txtCategoriaActual.Size = New System.Drawing.Size(182, 20)
      Me.txtCategoriaActual.TabIndex = 84
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(133, 19)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(0, 13)
      Me.Label7.TabIndex = 80
      '
      'chbCambiarCategoria
      '
      Me.chbCambiarCategoria.AutoSize = True
      Me.chbCambiarCategoria.Location = New System.Drawing.Point(7, 72)
      Me.chbCambiarCategoria.Name = "chbCambiarCategoria"
      Me.chbCambiarCategoria.Size = New System.Drawing.Size(64, 17)
      Me.chbCambiarCategoria.TabIndex = 80
      Me.chbCambiarCategoria.Text = "Cambiar"
      Me.chbCambiarCategoria.UseVisualStyleBackColor = True
      '
      'cmbCategoriaNueva
      '
      Me.cmbCategoriaNueva.BindearPropiedadControl = "SelectedValue"
      Me.cmbCategoriaNueva.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbCategoriaNueva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoriaNueva.Enabled = False
      Me.cmbCategoriaNueva.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoriaNueva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoriaNueva.FormattingEnabled = True
      Me.cmbCategoriaNueva.IsPK = False
      Me.cmbCategoriaNueva.IsRequired = True
      Me.cmbCategoriaNueva.Key = Nothing
      Me.cmbCategoriaNueva.LabelAsoc = Nothing
      Me.cmbCategoriaNueva.Location = New System.Drawing.Point(137, 43)
      Me.cmbCategoriaNueva.Name = "cmbCategoriaNueva"
      Me.cmbCategoriaNueva.Size = New System.Drawing.Size(181, 21)
      Me.cmbCategoriaNueva.TabIndex = 74
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(4, 19)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(90, 13)
      Me.Label5.TabIndex = 71
      Me.Label5.Text = "Categoría Actual:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(4, 46)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(89, 13)
      Me.Label6.TabIndex = 73
      Me.Label6.Text = "Categoría Nueva"
      '
      'cmbCambioMasivoCategoria
      '
      Me.cmbCambioMasivoCategoria.BindearPropiedadControl = "SelectedValue"
      Me.cmbCambioMasivoCategoria.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
      Me.cmbCambioMasivoCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCambioMasivoCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCambioMasivoCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCambioMasivoCategoria.FormattingEnabled = True
      Me.cmbCambioMasivoCategoria.IsPK = False
      Me.cmbCambioMasivoCategoria.IsRequired = True
      Me.cmbCambioMasivoCategoria.Key = Nothing
      Me.cmbCambioMasivoCategoria.LabelAsoc = Nothing
      Me.cmbCambioMasivoCategoria.Location = New System.Drawing.Point(137, 70)
      Me.cmbCambioMasivoCategoria.Name = "cmbCambioMasivoCategoria"
      Me.cmbCambioMasivoCategoria.Size = New System.Drawing.Size(181, 21)
      Me.cmbCambioMasivoCategoria.TabIndex = 77
      '
      'txtTipoComprobanteActual
      '
      Me.txtTipoComprobanteActual.Enabled = False
      Me.txtTipoComprobanteActual.Location = New System.Drawing.Point(148, 183)
      Me.txtTipoComprobanteActual.Name = "txtTipoComprobanteActual"
      Me.txtTipoComprobanteActual.ReadOnly = True
      Me.txtTipoComprobanteActual.Size = New System.Drawing.Size(182, 20)
      Me.txtTipoComprobanteActual.TabIndex = 83
      '
      'RepartoCambiarTipoComprobante
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(371, 386)
      Me.Controls.Add(Me.txtTipoComprobanteActual)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtDireccion)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.txtCliente)
      Me.Controls.Add(Me.Label1)
      Me.Name = "RepartoCambiarTipoComprobante"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Datos"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
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
   Friend WithEvents txtCliente As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbCambioMasivo As Eniac.Controles.ComboBox
   Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents cmbCategoriaNueva As Eniac.Controles.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmbCambioMasivoCategoria As Eniac.Controles.ComboBox
   Friend WithEvents chbCambiarTipoComprobante As System.Windows.Forms.CheckBox
   Friend WithEvents chbCambiarCategoria As System.Windows.Forms.CheckBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents txtCategoriaActual As System.Windows.Forms.TextBox
   Friend WithEvents txtTipoComprobanteActual As System.Windows.Forms.TextBox
End Class
