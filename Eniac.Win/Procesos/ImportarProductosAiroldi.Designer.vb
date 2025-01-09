<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarProductosAiroldi
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
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarProductosAiroldi))
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.cmbMarca = New Eniac.Controles.ComboBox()
      Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
      Me.lblCotizacionDolar = New Eniac.Controles.Label()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.btnMostrar = New Eniac.Controles.Button()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.CodigoProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.MonedaConvertida = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CostoFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.prbImportando = New System.Windows.Forms.ProgressBar()
      Me.lblFormato = New Eniac.Controles.Label()
      Me.optTXT = New Eniac.Controles.RadioButton()
      Me.optCSV = New Eniac.Controles.RadioButton()
      Me.grbPendientes.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.lblFormato)
      Me.grbPendientes.Controls.Add(Me.optTXT)
      Me.grbPendientes.Controls.Add(Me.optCSV)
      Me.grbPendientes.Controls.Add(Me.lblMarca)
      Me.grbPendientes.Controls.Add(Me.cmbMarca)
      Me.grbPendientes.Controls.Add(Me.txtArchivoOrigen)
      Me.grbPendientes.Controls.Add(Me.lblArchivo)
      Me.grbPendientes.Controls.Add(Me.txtCotizacionDolar)
      Me.grbPendientes.Controls.Add(Me.lblCotizacionDolar)
      Me.grbPendientes.Controls.Add(Me.btnExaminar)
      Me.grbPendientes.Controls.Add(Me.btnMostrar)
      Me.grbPendientes.Location = New System.Drawing.Point(12, 25)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(895, 93)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.Location = New System.Drawing.Point(26, 59)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(40, 13)
      Me.lblMarca.TabIndex = 6
      Me.lblMarca.Text = "Marca:"
      '
      'cmbMarca
      '
      Me.cmbMarca.BindearPropiedadControl = Nothing
      Me.cmbMarca.BindearPropiedadEntidad = Nothing
      Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMarca.FormattingEnabled = True
      Me.cmbMarca.IsPK = False
      Me.cmbMarca.IsRequired = False
      Me.cmbMarca.Key = Nothing
      Me.cmbMarca.LabelAsoc = Me.lblMarca
      Me.cmbMarca.Location = New System.Drawing.Point(75, 55)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(228, 21)
      Me.cmbMarca.TabIndex = 7
      '
      'txtArchivoOrigen
      '
      Me.txtArchivoOrigen.BindearPropiedadControl = "Text"
      Me.txtArchivoOrigen.BindearPropiedadEntidad = "CantidadProductos"
      Me.txtArchivoOrigen.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoOrigen.Formato = ""
      Me.txtArchivoOrigen.IsDecimal = False
      Me.txtArchivoOrigen.IsNumber = False
      Me.txtArchivoOrigen.IsPK = False
      Me.txtArchivoOrigen.IsRequired = False
      Me.txtArchivoOrigen.Key = ""
      Me.txtArchivoOrigen.LabelAsoc = Nothing
      Me.txtArchivoOrigen.Location = New System.Drawing.Point(254, 27)
      Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
      Me.txtArchivoOrigen.Size = New System.Drawing.Size(402, 20)
      Me.txtArchivoOrigen.TabIndex = 4
      '
      'lblArchivo
      '
      Me.lblArchivo.AutoSize = True
      Me.lblArchivo.Location = New System.Drawing.Point(202, 31)
      Me.lblArchivo.Name = "lblArchivo"
      Me.lblArchivo.Size = New System.Drawing.Size(46, 13)
      Me.lblArchivo.TabIndex = 3
      Me.lblArchivo.Text = "Archivo:"
      '
      'txtCotizacionDolar
      '
      Me.txtCotizacionDolar.BindearPropiedadControl = ""
      Me.txtCotizacionDolar.BindearPropiedadEntidad = ""
      Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCotizacionDolar.Formato = "#,##0.00"
      Me.txtCotizacionDolar.IsDecimal = True
      Me.txtCotizacionDolar.IsNumber = True
      Me.txtCotizacionDolar.IsPK = False
      Me.txtCotizacionDolar.IsRequired = False
      Me.txtCotizacionDolar.Key = ""
      Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
      Me.txtCotizacionDolar.Location = New System.Drawing.Point(448, 55)
      Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
      Me.txtCotizacionDolar.Size = New System.Drawing.Size(70, 20)
      Me.txtCotizacionDolar.TabIndex = 9
      Me.txtCotizacionDolar.Text = "0.00"
      Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCotizacionDolar
      '
      Me.lblCotizacionDolar.AutoSize = True
      Me.lblCotizacionDolar.Location = New System.Drawing.Point(352, 59)
      Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
      Me.lblCotizacionDolar.Size = New System.Drawing.Size(90, 13)
      Me.lblCotizacionDolar.TabIndex = 8
      Me.lblCotizacionDolar.Text = "Dolar (0 va U$D):"
      '
      'btnExaminar
      '
      Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.Location = New System.Drawing.Point(662, 17)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(100, 40)
      Me.btnExaminar.TabIndex = 5
      Me.btnExaminar.Text = "&Examinar..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      '
      'btnMostrar
      '
      Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnMostrar.Location = New System.Drawing.Point(791, 27)
      Me.btnMostrar.Name = "btnMostrar"
      Me.btnMostrar.Size = New System.Drawing.Size(80, 40)
      Me.btnMostrar.TabIndex = 10
      Me.btnMostrar.Text = "&Mostrar"
      Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnMostrar.UseVisualStyleBackColor = True
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoProducto, Me.NombreProducto, Me.Precio, Me.Moneda, Me.MonedaConvertida, Me.IVA, Me.NombreRubro, Me.CostoFinal})
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 124)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.RowHeadersWidth = 15
      Me.dgvDetalle.Size = New System.Drawing.Size(894, 372)
      Me.dgvDetalle.TabIndex = 1
      '
      'CodigoProducto
      '
      Me.CodigoProducto.DataPropertyName = "CodigoProducto"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CodigoProducto.DefaultCellStyle = DataGridViewCellStyle11
      Me.CodigoProducto.HeaderText = "Codigo Prod."
      Me.CodigoProducto.Name = "CodigoProducto"
      '
      'NombreProducto
      '
      Me.NombreProducto.DataPropertyName = "NombreProducto"
      Me.NombreProducto.HeaderText = "Nombre Producto"
      Me.NombreProducto.Name = "NombreProducto"
      Me.NombreProducto.ReadOnly = True
      Me.NombreProducto.Width = 250
      '
      'Precio
      '
      Me.Precio.DataPropertyName = "Precio"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle12.Format = "N2"
      DataGridViewCellStyle12.NullValue = Nothing
      Me.Precio.DefaultCellStyle = DataGridViewCellStyle12
      Me.Precio.HeaderText = "Precio"
      Me.Precio.Name = "Precio"
      Me.Precio.ReadOnly = True
      Me.Precio.Width = 80
      '
      'Moneda
      '
      Me.Moneda.DataPropertyName = "Moneda"
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Moneda.DefaultCellStyle = DataGridViewCellStyle13
      Me.Moneda.HeaderText = "Moneda"
      Me.Moneda.Name = "Moneda"
      Me.Moneda.ReadOnly = True
      Me.Moneda.Width = 80
      '
      'MonedaConvertida
      '
      Me.MonedaConvertida.DataPropertyName = "MonedaConvertida"
      Me.MonedaConvertida.HeaderText = "MonedaConvertida"
      Me.MonedaConvertida.Name = "MonedaConvertida"
      Me.MonedaConvertida.Visible = False
      '
      'IVA
      '
      Me.IVA.DataPropertyName = "IVA"
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle14.Format = "N2"
      Me.IVA.DefaultCellStyle = DataGridViewCellStyle14
      Me.IVA.HeaderText = "IVA"
      Me.IVA.Name = "IVA"
      Me.IVA.ReadOnly = True
      Me.IVA.Width = 60
      '
      'NombreRubro
      '
      Me.NombreRubro.DataPropertyName = "NombreRubro"
      Me.NombreRubro.HeaderText = "Nombre Rubro"
      Me.NombreRubro.Name = "NombreRubro"
      Me.NombreRubro.ReadOnly = True
      Me.NombreRubro.Width = 200
      '
      'CostoFinal
      '
      Me.CostoFinal.DataPropertyName = "CostoFinal"
      DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle15.Format = "N2"
      Me.CostoFinal.DefaultCellStyle = DataGridViewCellStyle15
      Me.CostoFinal.HeaderText = "Costo Final"
      Me.CostoFinal.Name = "CostoFinal"
      Me.CostoFinal.ReadOnly = True
      Me.CostoFinal.Width = 90
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(918, 29)
      Me.tstBarra.TabIndex = 4
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImportar
      '
      Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
      Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImportar.Name = "tsbImportar"
      Me.tsbImportar.Size = New System.Drawing.Size(79, 26)
      Me.tsbImportar.Text = "&Importar"
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
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 524)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(918, 22)
      Me.StatusStrip1.TabIndex = 3
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(903, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'prbImportando
      '
      Me.prbImportando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbImportando.Location = New System.Drawing.Point(12, 498)
      Me.prbImportando.Name = "prbImportando"
      Me.prbImportando.Size = New System.Drawing.Size(894, 23)
      Me.prbImportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbImportando.TabIndex = 2
      '
      'lblFormato
      '
      Me.lblFormato.AutoSize = True
      Me.lblFormato.Location = New System.Drawing.Point(14, 31)
      Me.lblFormato.Name = "lblFormato"
      Me.lblFormato.Size = New System.Drawing.Size(45, 13)
      Me.lblFormato.TabIndex = 0
      Me.lblFormato.Text = "Formato"
      '
      'optTXT
      '
      Me.optTXT.AutoSize = True
      Me.optTXT.BindearPropiedadControl = Nothing
      Me.optTXT.BindearPropiedadEntidad = Nothing
      Me.optTXT.ForeColorFocus = System.Drawing.Color.Red
      Me.optTXT.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optTXT.IsPK = False
      Me.optTXT.IsRequired = False
      Me.optTXT.Key = Nothing
      Me.optTXT.LabelAsoc = Me.lblFormato
      Me.optTXT.Location = New System.Drawing.Point(125, 29)
      Me.optTXT.Name = "optTXT"
      Me.optTXT.Size = New System.Drawing.Size(46, 17)
      Me.optTXT.TabIndex = 2
      Me.optTXT.Text = "TXT"
      Me.optTXT.UseVisualStyleBackColor = True
      '
      'optCSV
      '
      Me.optCSV.AutoSize = True
      Me.optCSV.BindearPropiedadControl = Nothing
      Me.optCSV.BindearPropiedadEntidad = Nothing
      Me.optCSV.Checked = True
      Me.optCSV.ForeColorFocus = System.Drawing.Color.Red
      Me.optCSV.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optCSV.IsPK = False
      Me.optCSV.IsRequired = False
      Me.optCSV.Key = Nothing
      Me.optCSV.LabelAsoc = Me.lblFormato
      Me.optCSV.Location = New System.Drawing.Point(73, 29)
      Me.optCSV.Name = "optCSV"
      Me.optCSV.Size = New System.Drawing.Size(46, 17)
      Me.optCSV.TabIndex = 1
      Me.optCSV.TabStop = True
      Me.optCSV.Text = "CSV"
      Me.optCSV.UseVisualStyleBackColor = True
      '
      'ImportarProductosAiroldi
      '
      Me.AcceptButton = Me.btnMostrar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(918, 546)
      Me.Controls.Add(Me.prbImportando)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.grbPendientes)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ImportarProductosAiroldi"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Importar Productos de Airoldi Computacion Mayorista"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents btnMostrar As Eniac.Controles.Button
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Friend WithEvents txtCotizacionDolar As Eniac.Controles.TextBox
   Friend WithEvents lblCotizacionDolar As Eniac.Controles.Label
   Friend WithEvents lblArchivo As Eniac.Controles.Label
   Friend WithEvents txtArchivoOrigen As Eniac.Controles.TextBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents prbImportando As System.Windows.Forms.ProgressBar
   Friend WithEvents CodigoProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MonedaConvertida As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CostoFinal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblFormato As Eniac.Controles.Label
   Friend WithEvents optTXT As Eniac.Controles.RadioButton
   Friend WithEvents optCSV As Eniac.Controles.RadioButton
End Class
