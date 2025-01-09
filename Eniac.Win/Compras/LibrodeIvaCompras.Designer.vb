<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LibrodeIvaCompras
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LibrodeIvaCompras))
      Me.chkConVendedor = New Eniac.Controles.CheckBox()
      Me.cmbCompradores = New Eniac.Controles.ComboBox()
      Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
      Me.lblPeriodoFiscal = New Eniac.Controles.Label()
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.grbImpresionFinal = New System.Windows.Forms.GroupBox()
      Me.lblNumeroInicialHoja = New Eniac.Controles.Label()
      Me.txtNumeroInicialHoja = New Eniac.Controles.TextBox()
      Me.chkVersionFinal = New Eniac.Controles.CheckBox()
      Me.optPorProvincia = New System.Windows.Forms.RadioButton()
      Me.lblOrden = New System.Windows.Forms.Label()
      Me.optPorFecha = New System.Windows.Forms.RadioButton()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbImpresionFinal.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'chkConVendedor
      '
      Me.chkConVendedor.AutoSize = True
      Me.chkConVendedor.BindearPropiedadControl = Nothing
      Me.chkConVendedor.BindearPropiedadEntidad = Nothing
      Me.chkConVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chkConVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkConVendedor.IsPK = False
      Me.chkConVendedor.IsRequired = False
      Me.chkConVendedor.Key = Nothing
      Me.chkConVendedor.LabelAsoc = Nothing
      Me.chkConVendedor.Location = New System.Drawing.Point(22, 165)
      Me.chkConVendedor.Name = "chkConVendedor"
      Me.chkConVendedor.Size = New System.Drawing.Size(96, 17)
      Me.chkConVendedor.TabIndex = 21
      Me.chkConVendedor.Text = "Por Comprador"
      Me.chkConVendedor.UseVisualStyleBackColor = True
      '
      'cmbCompradores
      '
      Me.cmbCompradores.BindearPropiedadControl = Nothing
      Me.cmbCompradores.BindearPropiedadEntidad = Nothing
      Me.cmbCompradores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCompradores.Enabled = False
      Me.cmbCompradores.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCompradores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCompradores.FormattingEnabled = True
      Me.cmbCompradores.IsPK = False
      Me.cmbCompradores.IsRequired = False
      Me.cmbCompradores.Key = Nothing
      Me.cmbCompradores.LabelAsoc = Nothing
      Me.cmbCompradores.Location = New System.Drawing.Point(123, 161)
      Me.cmbCompradores.Name = "cmbCompradores"
      Me.cmbCompradores.Size = New System.Drawing.Size(212, 21)
      Me.cmbCompradores.TabIndex = 15
      '
      'dtpPeriodoFiscal
      '
      Me.dtpPeriodoFiscal.BindearPropiedadControl = Nothing
      Me.dtpPeriodoFiscal.BindearPropiedadEntidad = Nothing
      Me.dtpPeriodoFiscal.CustomFormat = "MM/yyyy"
      Me.dtpPeriodoFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPeriodoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPeriodoFiscal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodoFiscal.IsPK = False
      Me.dtpPeriodoFiscal.IsRequired = False
      Me.dtpPeriodoFiscal.Key = ""
      Me.dtpPeriodoFiscal.LabelAsoc = Me.lblPeriodoFiscal
      Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(99, 43)
      Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
      Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(73, 20)
      Me.dtpPeriodoFiscal.TabIndex = 13
      '
      'lblPeriodoFiscal
      '
      Me.lblPeriodoFiscal.AutoSize = True
      Me.lblPeriodoFiscal.Location = New System.Drawing.Point(19, 47)
      Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
      Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
      Me.lblPeriodoFiscal.TabIndex = 19
      Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "check2.ico")
      Me.imgGrabar.Images.SetKeyName(1, "delete2.ico")
      '
      'grbImpresionFinal
      '
      Me.grbImpresionFinal.Controls.Add(Me.lblNumeroInicialHoja)
      Me.grbImpresionFinal.Controls.Add(Me.txtNumeroInicialHoja)
      Me.grbImpresionFinal.Controls.Add(Me.chkVersionFinal)
      Me.grbImpresionFinal.Location = New System.Drawing.Point(22, 73)
      Me.grbImpresionFinal.Name = "grbImpresionFinal"
      Me.grbImpresionFinal.Size = New System.Drawing.Size(313, 77)
      Me.grbImpresionFinal.TabIndex = 26
      Me.grbImpresionFinal.TabStop = False
      Me.grbImpresionFinal.Text = "Impresión Final (MES COMPLETO)"
      '
      'lblNumeroInicialHoja
      '
      Me.lblNumeroInicialHoja.AutoSize = True
      Me.lblNumeroInicialHoja.Location = New System.Drawing.Point(117, 47)
      Me.lblNumeroInicialHoja.Name = "lblNumeroInicialHoja"
      Me.lblNumeroInicialHoja.Size = New System.Drawing.Size(57, 13)
      Me.lblNumeroInicialHoja.TabIndex = 26
      Me.lblNumeroInicialHoja.Text = "Nro. Inicial"
      '
      'txtNumeroInicialHoja
      '
      Me.txtNumeroInicialHoja.BindearPropiedadControl = Nothing
      Me.txtNumeroInicialHoja.BindearPropiedadEntidad = Nothing
      Me.txtNumeroInicialHoja.Enabled = False
      Me.txtNumeroInicialHoja.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroInicialHoja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroInicialHoja.Formato = ""
      Me.txtNumeroInicialHoja.IsDecimal = False
      Me.txtNumeroInicialHoja.IsNumber = True
      Me.txtNumeroInicialHoja.IsPK = False
      Me.txtNumeroInicialHoja.IsRequired = False
      Me.txtNumeroInicialHoja.Key = ""
      Me.txtNumeroInicialHoja.LabelAsoc = Me.lblNumeroInicialHoja
      Me.txtNumeroInicialHoja.Location = New System.Drawing.Point(178, 43)
      Me.txtNumeroInicialHoja.Name = "txtNumeroInicialHoja"
      Me.txtNumeroInicialHoja.Size = New System.Drawing.Size(92, 20)
      Me.txtNumeroInicialHoja.TabIndex = 25
      Me.txtNumeroInicialHoja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'chkVersionFinal
      '
      Me.chkVersionFinal.AutoSize = True
      Me.chkVersionFinal.BindearPropiedadControl = Nothing
      Me.chkVersionFinal.BindearPropiedadEntidad = Nothing
      Me.chkVersionFinal.ForeColorFocus = System.Drawing.Color.Red
      Me.chkVersionFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkVersionFinal.IsPK = False
      Me.chkVersionFinal.IsRequired = False
      Me.chkVersionFinal.Key = Nothing
      Me.chkVersionFinal.LabelAsoc = Nothing
      Me.chkVersionFinal.Location = New System.Drawing.Point(11, 19)
      Me.chkVersionFinal.Name = "chkVersionFinal"
      Me.chkVersionFinal.Size = New System.Drawing.Size(195, 17)
      Me.chkVersionFinal.TabIndex = 24
      Me.chkVersionFinal.Text = "Versión Final (Guarda Numero Hoja)"
      Me.chkVersionFinal.UseVisualStyleBackColor = True
      '
      'optPorProvincia
      '
      Me.optPorProvincia.AutoSize = True
      Me.optPorProvincia.Location = New System.Drawing.Point(166, 196)
      Me.optPorProvincia.Name = "optPorProvincia"
      Me.optPorProvincia.Size = New System.Drawing.Size(88, 17)
      Me.optPorProvincia.TabIndex = 31
      Me.optPorProvincia.TabStop = True
      Me.optPorProvincia.Text = "Por Provincia"
      Me.optPorProvincia.UseVisualStyleBackColor = True
      '
      'lblOrden
      '
      Me.lblOrden.AutoSize = True
      Me.lblOrden.Location = New System.Drawing.Point(25, 198)
      Me.lblOrden.Name = "lblOrden"
      Me.lblOrden.Size = New System.Drawing.Size(42, 13)
      Me.lblOrden.TabIndex = 32
      Me.lblOrden.Text = "Orden :"
      '
      'optPorFecha
      '
      Me.optPorFecha.AutoSize = True
      Me.optPorFecha.Checked = True
      Me.optPorFecha.Location = New System.Drawing.Point(77, 196)
      Me.optPorFecha.Name = "optPorFecha"
      Me.optPorFecha.Size = New System.Drawing.Size(74, 17)
      Me.optPorFecha.TabIndex = 30
      Me.optPorFecha.TabStop = True
      Me.optPorFecha.Text = "Por Fecha"
      Me.optPorFecha.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(347, 29)
      Me.tstBarra.TabIndex = 33
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'LibrodeIvaCompras
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(347, 233)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.optPorProvincia)
      Me.Controls.Add(Me.lblOrden)
      Me.Controls.Add(Me.optPorFecha)
      Me.Controls.Add(Me.grbImpresionFinal)
      Me.Controls.Add(Me.chkConVendedor)
      Me.Controls.Add(Me.cmbCompradores)
      Me.Controls.Add(Me.dtpPeriodoFiscal)
      Me.Controls.Add(Me.lblPeriodoFiscal)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.Name = "LibrodeIvaCompras"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Libro de I.V.A. Compras"
      Me.grbImpresionFinal.ResumeLayout(False)
      Me.grbImpresionFinal.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents chkConVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbCompradores As Eniac.Controles.ComboBox
   Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents grbImpresionFinal As System.Windows.Forms.GroupBox
   Friend WithEvents lblNumeroInicialHoja As Eniac.Controles.Label
   Friend WithEvents txtNumeroInicialHoja As Eniac.Controles.TextBox
   Friend WithEvents chkVersionFinal As Eniac.Controles.CheckBox
   Friend WithEvents optPorProvincia As System.Windows.Forms.RadioButton
   Friend WithEvents lblOrden As System.Windows.Forms.Label
   Friend WithEvents optPorFecha As System.Windows.Forms.RadioButton
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
End Class
