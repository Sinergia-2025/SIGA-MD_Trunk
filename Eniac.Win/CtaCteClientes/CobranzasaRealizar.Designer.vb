<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CobranzasaRealizar
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CobranzasaRealizar))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.chbFechasVencimiento = New Eniac.Controles.CheckBox()
      Me.dtpVencimientoHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpVencimientoDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.gpbFiltros = New System.Windows.Forms.GroupBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaVto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.lbTotal = New Eniac.Controles.Label()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tstBarra.SuspendLayout()
      Me.gpbFiltros.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(948, 29)
      Me.tstBarra.TabIndex = 7
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'chbVendedor
      '
      Me.chbVendedor.AutoSize = True
      Me.chbVendedor.BindearPropiedadControl = Nothing
      Me.chbVendedor.BindearPropiedadEntidad = Nothing
      Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVendedor.IsPK = False
      Me.chbVendedor.IsRequired = False
      Me.chbVendedor.Key = Nothing
      Me.chbVendedor.LabelAsoc = Nothing
      Me.chbVendedor.Location = New System.Drawing.Point(33, 77)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 27
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
      '
      'cmbVendedor
      '
      Me.cmbVendedor.BindearPropiedadControl = Nothing
      Me.cmbVendedor.BindearPropiedadEntidad = Nothing
      Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedor.Enabled = False
      Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedor.FormattingEnabled = True
      Me.cmbVendedor.IsPK = False
      Me.cmbVendedor.IsRequired = False
      Me.cmbVendedor.Key = Nothing
      Me.cmbVendedor.LabelAsoc = Nothing
      Me.cmbVendedor.Location = New System.Drawing.Point(111, 75)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(162, 21)
      Me.cmbVendedor.TabIndex = 28
      '
      'chbFechasVencimiento
      '
      Me.chbFechasVencimiento.AutoSize = True
      Me.chbFechasVencimiento.BindearPropiedadControl = Nothing
      Me.chbFechasVencimiento.BindearPropiedadEntidad = Nothing
      Me.chbFechasVencimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechasVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechasVencimiento.IsPK = False
      Me.chbFechasVencimiento.IsRequired = False
      Me.chbFechasVencimiento.Key = Nothing
      Me.chbFechasVencimiento.LabelAsoc = Nothing
      Me.chbFechasVencimiento.Location = New System.Drawing.Point(312, 34)
      Me.chbFechasVencimiento.Name = "chbFechasVencimiento"
      Me.chbFechasVencimiento.Size = New System.Drawing.Size(84, 17)
      Me.chbFechasVencimiento.TabIndex = 19
      Me.chbFechasVencimiento.Text = "Vencimiento"
      Me.chbFechasVencimiento.UseVisualStyleBackColor = True
      '
      'dtpVencimientoHasta
      '
      Me.dtpVencimientoHasta.BindearPropiedadControl = Nothing
      Me.dtpVencimientoHasta.BindearPropiedadEntidad = Nothing
      Me.dtpVencimientoHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpVencimientoHasta.Enabled = False
      Me.dtpVencimientoHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpVencimientoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpVencimientoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpVencimientoHasta.IsPK = False
      Me.dtpVencimientoHasta.IsRequired = False
      Me.dtpVencimientoHasta.Key = ""
      Me.dtpVencimientoHasta.LabelAsoc = Me.lblHasta
      Me.dtpVencimientoHasta.Location = New System.Drawing.Point(593, 32)
      Me.dtpVencimientoHasta.Name = "dtpVencimientoHasta"
      Me.dtpVencimientoHasta.Size = New System.Drawing.Size(89, 20)
      Me.dtpVencimientoHasta.TabIndex = 23
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(552, 35)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 22
      Me.lblHasta.Text = "Hasta"
      '
      'dtpVencimientoDesde
      '
      Me.dtpVencimientoDesde.BindearPropiedadControl = Nothing
      Me.dtpVencimientoDesde.BindearPropiedadEntidad = Nothing
      Me.dtpVencimientoDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpVencimientoDesde.Enabled = False
      Me.dtpVencimientoDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpVencimientoDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpVencimientoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpVencimientoDesde.IsPK = False
      Me.dtpVencimientoDesde.IsRequired = False
      Me.dtpVencimientoDesde.Key = ""
      Me.dtpVencimientoDesde.LabelAsoc = Me.lblDesde
      Me.dtpVencimientoDesde.Location = New System.Drawing.Point(447, 32)
      Me.dtpVencimientoDesde.Name = "dtpVencimientoDesde"
      Me.dtpVencimientoDesde.Size = New System.Drawing.Size(89, 20)
      Me.dtpVencimientoDesde.TabIndex = 21
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(403, 35)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 20
      Me.lblDesde.Text = "Desde"
      '
      'gpbFiltros
      '
      Me.gpbFiltros.Controls.Add(Me.btnConsultar)
      Me.gpbFiltros.Controls.Add(Me.lblDesde)
      Me.gpbFiltros.Controls.Add(Me.lblHasta)
      Me.gpbFiltros.Controls.Add(Me.dtpVencimientoDesde)
      Me.gpbFiltros.Controls.Add(Me.dtpVencimientoHasta)
      Me.gpbFiltros.Controls.Add(Me.chbFechasVencimiento)
      Me.gpbFiltros.Location = New System.Drawing.Point(12, 43)
      Me.gpbFiltros.Name = "gpbFiltros"
      Me.gpbFiltros.Size = New System.Drawing.Size(923, 77)
      Me.gpbFiltros.TabIndex = 31
      Me.gpbFiltros.TabStop = False
      Me.gpbFiltros.Text = "Filtros"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(796, 19)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 12
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeRows = False
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Vendedor, Me.FechaVto, Me.Cliente, Me.Direccion, Me.Telefono, Me.Detalle, Me.Importe})
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 126)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 10
      Me.dgvDetalle.Size = New System.Drawing.Size(923, 312)
      Me.dgvDetalle.TabIndex = 32
      '
      'Vendedor
      '
      Me.Vendedor.DataPropertyName = "NombreEmpleado"
      Me.Vendedor.HeaderText = "Vendedor"
      Me.Vendedor.Name = "Vendedor"
      '
      'FechaVto
      '
      Me.FechaVto.DataPropertyName = "FechaVencimiento"
      DataGridViewCellStyle1.Format = "d"
      DataGridViewCellStyle1.NullValue = Nothing
      Me.FechaVto.DefaultCellStyle = DataGridViewCellStyle1
      Me.FechaVto.HeaderText = "Fecha Vto"
      Me.FechaVto.Name = "FechaVto"
      Me.FechaVto.Width = 80
      '
      'Cliente
      '
      Me.Cliente.DataPropertyName = "NombreCliente"
      Me.Cliente.HeaderText = "Cliente"
      Me.Cliente.Name = "Cliente"
      Me.Cliente.Width = 170
      '
      'Direccion
      '
      Me.Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Direccion.DataPropertyName = "Direccion"
      Me.Direccion.HeaderText = "Direccion"
      Me.Direccion.Name = "Direccion"
      '
      'Telefono
      '
      Me.Telefono.DataPropertyName = "Telefono"
      Me.Telefono.HeaderText = "Telefono "
      Me.Telefono.Name = "Telefono"
      Me.Telefono.Visible = False
      Me.Telefono.Width = 30
      '
      'Detalle
      '
      Me.Detalle.DataPropertyName = "NombreProducto"
      Me.Detalle.HeaderText = "Detalle"
      Me.Detalle.Name = "Detalle"
      Me.Detalle.Width = 230
      '
      'Importe
      '
      Me.Importe.DataPropertyName = "Importe"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle2.Format = "N2"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.Importe.DefaultCellStyle = DataGridViewCellStyle2
      Me.Importe.HeaderText = "Importe"
      Me.Importe.Name = "Importe"
      '
      'lbTotal
      '
      Me.lbTotal.AutoSize = True
      Me.lbTotal.Location = New System.Drawing.Point(805, 451)
      Me.lbTotal.Name = "lbTotal"
      Me.lbTotal.Size = New System.Drawing.Size(34, 13)
      Me.lbTotal.TabIndex = 33
      Me.lbTotal.Text = "Total:"
      '
      'txtTotal
      '
      Me.txtTotal.BackColor = System.Drawing.SystemColors.Menu
      Me.txtTotal.BindearPropiedadControl = Nothing
      Me.txtTotal.BindearPropiedadEntidad = Nothing
      Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotal.Formato = ""
      Me.txtTotal.IsDecimal = False
      Me.txtTotal.IsNumber = False
      Me.txtTotal.IsPK = False
      Me.txtTotal.IsRequired = False
      Me.txtTotal.Key = ""
      Me.txtTotal.LabelAsoc = Nothing
      Me.txtTotal.Location = New System.Drawing.Point(845, 448)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.Size = New System.Drawing.Size(90, 20)
      Me.txtTotal.TabIndex = 34
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'CobranzasaRealizar
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(948, 473)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.lbTotal)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.chbVendedor)
      Me.Controls.Add(Me.cmbVendedor)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.gpbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CobranzasaRealizar"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cobranzas a Realizar "
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.gpbFiltros.ResumeLayout(False)
      Me.gpbFiltros.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbFechasVencimiento As Eniac.Controles.CheckBox
   Friend WithEvents dtpVencimientoHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpVencimientoDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents gpbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents lbTotal As Eniac.Controles.Label
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents Vendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
