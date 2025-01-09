<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarNumeracionVentas
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarNumeracionVentas))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
      Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dgvDatos = New Eniac.Controles.DataGridView()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.LetraFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobanteRelacionado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ComparteEntreSucursales = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.EsRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.txtidTipoComprobante = New System.Windows.Forms.TextBox()
      Me.lblidTipoComprobante = New System.Windows.Forms.Label()
      Me.grpEditar = New System.Windows.Forms.GroupBox()
      Me.chbComparteSucursal = New System.Windows.Forms.CheckBox()
      Me.lblIdTipoComprobanteRelacionado = New Eniac.Controles.Label()
      Me.txtIdTipoComprobanteRelacionado = New Eniac.Controles.TextBox()
      Me.lblNroComprobante = New Eniac.Controles.Label()
      Me.txtNroComprobante = New Eniac.Controles.TextBox()
      Me.tstBarra.SuspendLayout()
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpEditar.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tss1, Me.tsbCancelar, Me.tss2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(964, 31)
      Me.tstBarra.TabIndex = 2
      Me.tstBarra.Text = "Números de comprobantes"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Enabled = False
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(70, 28)
      Me.tsbGrabar.Text = "&Grabar"
      '
      'tss1
      '
      Me.tss1.Name = "tss1"
      Me.tss1.Size = New System.Drawing.Size(6, 31)
      '
      'tsbCancelar
      '
      Me.tsbCancelar.Enabled = False
      Me.tsbCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCancelar.Name = "tsbCancelar"
      Me.tsbCancelar.Size = New System.Drawing.Size(81, 28)
      Me.tsbCancelar.Text = "&Cancelar"
      '
      'tss2
      '
      Me.tss2.Name = "tss2"
      Me.tss2.Size = New System.Drawing.Size(6, 31)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(67, 28)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'dgvDatos
      '
      Me.dgvDatos.AllowUserToAddRows = False
      Me.dgvDatos.AllowUserToDeleteRows = False
      Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTipoComprobante, Me.TipoComprobante, Me.LetraFiscal, Me.CentroEmisor, Me.Numero, Me.Fecha, Me.IdTipoComprobanteRelacionado, Me.ComparteEntreSucursales, Me.EsRecibo})
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle7
      Me.dgvDatos.Location = New System.Drawing.Point(12, 116)
      Me.dgvDatos.MultiSelect = False
      Me.dgvDatos.Name = "dgvDatos"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
      Me.dgvDatos.RowHeadersVisible = False
      Me.dgvDatos.RowHeadersWidth = 4
      Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDatos.Size = New System.Drawing.Size(940, 435)
      Me.dgvDatos.TabIndex = 1
      '
      'IdTipoComprobante
      '
      Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.IdTipoComprobante.HeaderText = "IdTipoComprobante"
      Me.IdTipoComprobante.Name = "IdTipoComprobante"
      Me.IdTipoComprobante.Visible = False
      '
      'TipoComprobante
      '
      Me.TipoComprobante.DataPropertyName = "TipoComprobante"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      Me.TipoComprobante.DefaultCellStyle = DataGridViewCellStyle2
      Me.TipoComprobante.HeaderText = "Tipo Comprobante"
      Me.TipoComprobante.Name = "TipoComprobante"
      Me.TipoComprobante.ReadOnly = True
      Me.TipoComprobante.Width = 200
      '
      'LetraFiscal
      '
      Me.LetraFiscal.DataPropertyName = "LetraFiscal"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.LetraFiscal.DefaultCellStyle = DataGridViewCellStyle3
      Me.LetraFiscal.HeaderText = "Letra"
      Me.LetraFiscal.Name = "LetraFiscal"
      Me.LetraFiscal.ReadOnly = True
      Me.LetraFiscal.Width = 60
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle4
      Me.CentroEmisor.HeaderText = "Emisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.ReadOnly = True
      Me.CentroEmisor.Width = 60
      '
      'Numero
      '
      Me.Numero.DataPropertyName = "Numero"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle5.Format = "N0"
      DataGridViewCellStyle5.NullValue = Nothing
      Me.Numero.DefaultCellStyle = DataGridViewCellStyle5
      Me.Numero.HeaderText = "Ultimo Número"
      Me.Numero.Name = "Numero"
      Me.Numero.ReadOnly = True
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle6.Format = "dd/MM/yyyy"
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle6
      Me.Fecha.HeaderText = "Fecha"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.Width = 80
      '
      'IdTipoComprobanteRelacionado
      '
      Me.IdTipoComprobanteRelacionado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.IdTipoComprobanteRelacionado.DataPropertyName = "IdTipoComprobanteRelacionado"
      Me.IdTipoComprobanteRelacionado.HeaderText = "Tipos de Comprobantes Relacionados"
      Me.IdTipoComprobanteRelacionado.Name = "IdTipoComprobanteRelacionado"
      '
      'ComparteEntreSucursales
      '
      Me.ComparteEntreSucursales.DataPropertyName = "ComparteEntreSucursales"
      Me.ComparteEntreSucursales.HeaderText = "Comparte"
      Me.ComparteEntreSucursales.Name = "ComparteEntreSucursales"
      Me.ComparteEntreSucursales.ReadOnly = True
      Me.ComparteEntreSucursales.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.ComparteEntreSucursales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.ComparteEntreSucursales.Width = 60
      '
      'EsRecibo
      '
      Me.EsRecibo.DataPropertyName = "EsRecibo"
      Me.EsRecibo.HeaderText = "Recibo"
      Me.EsRecibo.Name = "EsRecibo"
      Me.EsRecibo.Visible = False
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = "Value"
      Me.dtpFecha.BindearPropiedadEntidad = "FechaInicioActiv"
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(238, 40)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
      Me.dtpFecha.TabIndex = 2
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.Location = New System.Drawing.Point(235, 24)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(72, 13)
      Me.lblFecha.TabIndex = 3
      Me.lblFecha.Text = "Nueva Fecha"
      '
      'txtidTipoComprobante
      '
      Me.txtidTipoComprobante.Location = New System.Drawing.Point(13, 40)
      Me.txtidTipoComprobante.Name = "txtidTipoComprobante"
      Me.txtidTipoComprobante.ReadOnly = True
      Me.txtidTipoComprobante.Size = New System.Drawing.Size(100, 20)
      Me.txtidTipoComprobante.TabIndex = 4
      '
      'lblidTipoComprobante
      '
      Me.lblidTipoComprobante.AutoSize = True
      Me.lblidTipoComprobante.Location = New System.Drawing.Point(13, 24)
      Me.lblidTipoComprobante.Name = "lblidTipoComprobante"
      Me.lblidTipoComprobante.Size = New System.Drawing.Size(91, 13)
      Me.lblidTipoComprobante.TabIndex = 5
      Me.lblidTipoComprobante.Text = "TipoComprobante"
      '
      'grpEditar
      '
      Me.grpEditar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpEditar.Controls.Add(Me.chbComparteSucursal)
      Me.grpEditar.Controls.Add(Me.lblIdTipoComprobanteRelacionado)
      Me.grpEditar.Controls.Add(Me.txtIdTipoComprobanteRelacionado)
      Me.grpEditar.Controls.Add(Me.lblFecha)
      Me.grpEditar.Controls.Add(Me.lblNroComprobante)
      Me.grpEditar.Controls.Add(Me.txtNroComprobante)
      Me.grpEditar.Controls.Add(Me.dtpFecha)
      Me.grpEditar.Controls.Add(Me.txtidTipoComprobante)
      Me.grpEditar.Controls.Add(Me.lblidTipoComprobante)
      Me.grpEditar.Enabled = False
      Me.grpEditar.Location = New System.Drawing.Point(12, 34)
      Me.grpEditar.Name = "grpEditar"
      Me.grpEditar.Size = New System.Drawing.Size(940, 76)
      Me.grpEditar.TabIndex = 0
      Me.grpEditar.TabStop = False
      Me.grpEditar.Text = "Editar"
      '
      'chbComparteSucursal
      '
      Me.chbComparteSucursal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chbComparteSucursal.AutoSize = True
      Me.chbComparteSucursal.Location = New System.Drawing.Point(775, 42)
      Me.chbComparteSucursal.Name = "chbComparteSucursal"
      Me.chbComparteSucursal.Size = New System.Drawing.Size(159, 17)
      Me.chbComparteSucursal.TabIndex = 8
      Me.chbComparteSucursal.Text = "Compartido entre sucursales"
      Me.chbComparteSucursal.UseVisualStyleBackColor = True
      Me.chbComparteSucursal.Visible = False
      '
      'lblIdTipoComprobanteRelacionado
      '
      Me.lblIdTipoComprobanteRelacionado.AutoSize = True
      Me.lblIdTipoComprobanteRelacionado.Location = New System.Drawing.Point(348, 24)
      Me.lblIdTipoComprobanteRelacionado.Name = "lblIdTipoComprobanteRelacionado"
      Me.lblIdTipoComprobanteRelacionado.Size = New System.Drawing.Size(187, 13)
      Me.lblIdTipoComprobanteRelacionado.TabIndex = 7
      Me.lblIdTipoComprobanteRelacionado.Text = "Tipos de Comprobantes Relacionados"
      '
      'txtIdTipoComprobanteRelacionado
      '
      Me.txtIdTipoComprobanteRelacionado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtIdTipoComprobanteRelacionado.BindearPropiedadControl = ""
      Me.txtIdTipoComprobanteRelacionado.BindearPropiedadEntidad = ""
      Me.txtIdTipoComprobanteRelacionado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoComprobanteRelacionado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoComprobanteRelacionado.Formato = ""
      Me.txtIdTipoComprobanteRelacionado.IsDecimal = False
      Me.txtIdTipoComprobanteRelacionado.IsNumber = True
      Me.txtIdTipoComprobanteRelacionado.IsPK = False
      Me.txtIdTipoComprobanteRelacionado.IsRequired = False
      Me.txtIdTipoComprobanteRelacionado.Key = ""
      Me.txtIdTipoComprobanteRelacionado.LabelAsoc = Me.lblIdTipoComprobanteRelacionado
      Me.txtIdTipoComprobanteRelacionado.Location = New System.Drawing.Point(349, 40)
      Me.txtIdTipoComprobanteRelacionado.MaxLength = 5
      Me.txtIdTipoComprobanteRelacionado.Name = "txtIdTipoComprobanteRelacionado"
      Me.txtIdTipoComprobanteRelacionado.ReadOnly = True
      Me.txtIdTipoComprobanteRelacionado.Size = New System.Drawing.Size(420, 20)
      Me.txtIdTipoComprobanteRelacionado.TabIndex = 6
      '
      'lblNroComprobante
      '
      Me.lblNroComprobante.AutoSize = True
      Me.lblNroComprobante.Location = New System.Drawing.Point(137, 24)
      Me.lblNroComprobante.Name = "lblNroComprobante"
      Me.lblNroComprobante.Size = New System.Drawing.Size(79, 13)
      Me.lblNroComprobante.TabIndex = 1
      Me.lblNroComprobante.Text = "Nuevo Numero"
      '
      'txtNroComprobante
      '
      Me.txtNroComprobante.BindearPropiedadControl = ""
      Me.txtNroComprobante.BindearPropiedadEntidad = ""
      Me.txtNroComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroComprobante.Formato = ""
      Me.txtNroComprobante.IsDecimal = False
      Me.txtNroComprobante.IsNumber = True
      Me.txtNroComprobante.IsPK = False
      Me.txtNroComprobante.IsRequired = False
      Me.txtNroComprobante.Key = ""
      Me.txtNroComprobante.LabelAsoc = Me.lblNroComprobante
      Me.txtNroComprobante.Location = New System.Drawing.Point(138, 40)
      Me.txtNroComprobante.MaxLength = 5
      Me.txtNroComprobante.Name = "txtNroComprobante"
      Me.txtNroComprobante.Size = New System.Drawing.Size(70, 20)
      Me.txtNroComprobante.TabIndex = 0
      Me.txtNroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ModificarNumeracionVentas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(964, 561)
      Me.Controls.Add(Me.grpEditar)
      Me.Controls.Add(Me.dgvDatos)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ModificarNumeracionVentas"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Modificar Numeración"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpEditar.ResumeLayout(False)
      Me.grpEditar.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
   Friend WithEvents dgvDatos As Eniac.Controles.DataGridView
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents txtidTipoComprobante As System.Windows.Forms.TextBox
   Friend WithEvents lblidTipoComprobante As System.Windows.Forms.Label
   Friend WithEvents grpEditar As System.Windows.Forms.GroupBox
   Friend WithEvents txtNroComprobante As Eniac.Controles.TextBox
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents lblNroComprobante As Eniac.Controles.Label
   Private WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblIdTipoComprobanteRelacionado As Eniac.Controles.Label
   Friend WithEvents txtIdTipoComprobanteRelacionado As Eniac.Controles.TextBox
   Friend WithEvents chbComparteSucursal As System.Windows.Forms.CheckBox
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents LetraFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobanteRelacionado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ComparteEntreSucursales As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents EsRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
