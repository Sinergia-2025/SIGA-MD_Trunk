<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LimpiarStock
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LimpiarStock))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.cmbDepositos = New Eniac.Controles.ComboBox()
        Me.lblDepositos = New Eniac.Controles.Label()
        Me.chbConStock = New Eniac.Controles.CheckBox()
        Me.chbSubRubro = New Eniac.Controles.CheckBox()
        Me.cmbSubRubro = New Eniac.Controles.ComboBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbAjustar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.chkBlanquear = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVentaConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUbicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreUbicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Alicuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbConsultar.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.cmbDepositos)
        Me.grbConsultar.Controls.Add(Me.lblDepositos)
        Me.grbConsultar.Controls.Add(Me.chbConStock)
        Me.grbConsultar.Controls.Add(Me.chbSubRubro)
        Me.grbConsultar.Controls.Add(Me.cmbSubRubro)
        Me.grbConsultar.Controls.Add(Me.btnBuscar)
        Me.grbConsultar.Controls.Add(Me.cmbRubro)
        Me.grbConsultar.Controls.Add(Me.chbRubro)
        Me.grbConsultar.Controls.Add(Me.cmbMarca)
        Me.grbConsultar.Controls.Add(Me.chbMarca)
        Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(940, 75)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'cmbDepositos
        '
        Me.cmbDepositos.BindearPropiedadControl = Nothing
        Me.cmbDepositos.BindearPropiedadEntidad = Nothing
        Me.cmbDepositos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositos.FormattingEnabled = True
        Me.cmbDepositos.IsPK = False
        Me.cmbDepositos.IsRequired = False
        Me.cmbDepositos.Key = Nothing
        Me.cmbDepositos.LabelAsoc = Me.lblDepositos
        Me.cmbDepositos.Location = New System.Drawing.Point(82, 21)
        Me.cmbDepositos.Name = "cmbDepositos"
        Me.cmbDepositos.Size = New System.Drawing.Size(231, 21)
        Me.cmbDepositos.TabIndex = 55
        '
        'lblDepositos
        '
        Me.lblDepositos.AutoSize = True
        Me.lblDepositos.LabelAsoc = Nothing
        Me.lblDepositos.Location = New System.Drawing.Point(17, 24)
        Me.lblDepositos.Name = "lblDepositos"
        Me.lblDepositos.Size = New System.Drawing.Size(49, 13)
        Me.lblDepositos.TabIndex = 54
        Me.lblDepositos.Text = "Depósito"
        '
        'chbConStock
        '
        Me.chbConStock.AutoSize = True
        Me.chbConStock.BindearPropiedadControl = Nothing
        Me.chbConStock.BindearPropiedadEntidad = Nothing
        Me.chbConStock.Checked = True
        Me.chbConStock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbConStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConStock.IsPK = False
        Me.chbConStock.IsRequired = False
        Me.chbConStock.Key = Nothing
        Me.chbConStock.LabelAsoc = Nothing
        Me.chbConStock.Location = New System.Drawing.Point(673, 49)
        Me.chbConStock.Name = "chbConStock"
        Me.chbConStock.Size = New System.Drawing.Size(76, 17)
        Me.chbConStock.TabIndex = 53
        Me.chbConStock.Text = "Con Stock"
        Me.chbConStock.UseVisualStyleBackColor = True
        '
        'chbSubRubro
        '
        Me.chbSubRubro.AutoSize = True
        Me.chbSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubRubro.IsPK = False
        Me.chbSubRubro.IsRequired = False
        Me.chbSubRubro.Key = Nothing
        Me.chbSubRubro.LabelAsoc = Nothing
        Me.chbSubRubro.Location = New System.Drawing.Point(334, 49)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 41
        Me.chbSubRubro.Text = "SubRubro"
        Me.chbSubRubro.UseVisualStyleBackColor = True
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro.Enabled = False
        Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro.FormattingEnabled = True
        Me.cmbSubRubro.IsPK = False
        Me.cmbSubRubro.IsRequired = False
        Me.cmbSubRubro.Key = Nothing
        Me.cmbSubRubro.LabelAsoc = Nothing
        Me.cmbSubRubro.Location = New System.Drawing.Point(423, 47)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(234, 21)
        Me.cmbSubRubro.TabIndex = 42
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(820, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 45)
        Me.btnBuscar.TabIndex = 9
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbRubro
        '
        Me.cmbRubro.BindearPropiedadControl = Nothing
        Me.cmbRubro.BindearPropiedadEntidad = Nothing
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.Enabled = False
        Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.IsPK = False
        Me.cmbRubro.IsRequired = False
        Me.cmbRubro.Key = Nothing
        Me.cmbRubro.LabelAsoc = Nothing
        Me.cmbRubro.Location = New System.Drawing.Point(423, 21)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(234, 21)
        Me.cmbRubro.TabIndex = 3
        '
        'chbRubro
        '
        Me.chbRubro.AutoSize = True
        Me.chbRubro.BindearPropiedadControl = Nothing
        Me.chbRubro.BindearPropiedadEntidad = Nothing
        Me.chbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRubro.IsPK = False
        Me.chbRubro.IsRequired = False
        Me.chbRubro.Key = Nothing
        Me.chbRubro.LabelAsoc = Nothing
        Me.chbRubro.Location = New System.Drawing.Point(334, 25)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 8
        Me.chbRubro.Text = "Rubro"
        Me.chbRubro.UseVisualStyleBackColor = True
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = False
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Nothing
        Me.cmbMarca.Location = New System.Drawing.Point(82, 46)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(231, 21)
        Me.cmbMarca.TabIndex = 2
        '
        'chbMarca
        '
        Me.chbMarca.AutoSize = True
        Me.chbMarca.BindearPropiedadControl = Nothing
        Me.chbMarca.BindearPropiedadEntidad = Nothing
        Me.chbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarca.IsPK = False
        Me.chbMarca.IsRequired = False
        Me.chbMarca.Key = Nothing
        Me.chbMarca.LabelAsoc = Nothing
        Me.chbMarca.Location = New System.Drawing.Point(20, 49)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 7
        Me.chbMarca.Text = "Marca"
        Me.chbMarca.UseVisualStyleBackColor = True
        '
        'imgGrabar
        '
        Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
        Me.imgGrabar.Images.SetKeyName(0, "find.ico")
        Me.imgGrabar.Images.SetKeyName(1, "delete2.ico")
        Me.imgGrabar.Images.SetKeyName(2, "document_new.ico")
        Me.imgGrabar.Images.SetKeyName(3, "checks.ico")
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkBlanquear, Me.Producto, Me.NombreProducto, Me.PrecioVenta, Me.PrecioVentaConIVA, Me.IdUbicacion, Me.NombreUbicacion, Me.Stock, Me.Marca, Me.Rubro, Me.Activo, Me.Alicuota})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 113)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersWidth = 15
        Me.dgvDetalle.Size = New System.Drawing.Size(940, 348)
        Me.dgvDetalle.TabIndex = 1
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator3, Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbAjustar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(964, 29)
        Me.tstBarra.TabIndex = 2
        Me.tstBarra.Text = "toolStrip1"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbAjustar
        '
        Me.tsbAjustar.Image = Global.Eniac.Win.My.Resources.Resources.note_edit
        Me.tsbAjustar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAjustar.Name = "tsbAjustar"
        Me.tsbAjustar.Size = New System.Drawing.Size(70, 26)
        Me.tsbAjustar.Text = "&Ajustar"
        Me.tsbAjustar.ToolTipText = "Ajustar Stock"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 502)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(964, 22)
        Me.stsStado.TabIndex = 6
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(885, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'chbTodos
        '
        Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.ImageIndex = 3
        Me.chbTodos.ImageList = Me.imgGrabar
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(12, 469)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(119, 24)
        Me.chbTodos.TabIndex = 21
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'chkBlanquear
        '
        Me.chkBlanquear.FillWeight = 50.0!
        Me.chkBlanquear.HeaderText = ""
        Me.chkBlanquear.Name = "chkBlanquear"
        Me.chkBlanquear.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chkBlanquear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.chkBlanquear.Width = 40
        '
        'Producto
        '
        Me.Producto.DataPropertyName = "IdProducto"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Producto.DefaultCellStyle = DataGridViewCellStyle1
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        '
        'NombreProducto
        '
        Me.NombreProducto.DataPropertyName = "NombreProducto"
        Me.NombreProducto.HeaderText = "Nombre Producto"
        Me.NombreProducto.Name = "NombreProducto"
        Me.NombreProducto.ReadOnly = True
        Me.NombreProducto.Width = 235
        '
        'PrecioVenta
        '
        Me.PrecioVenta.DataPropertyName = "PrecioVentaSinIVA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PrecioVenta.DefaultCellStyle = DataGridViewCellStyle2
        Me.PrecioVenta.HeaderText = "Venta Sin IVA"
        Me.PrecioVenta.Name = "PrecioVenta"
        Me.PrecioVenta.ReadOnly = True
        Me.PrecioVenta.Width = 75
        '
        'PrecioVentaConIVA
        '
        Me.PrecioVentaConIVA.DataPropertyName = "PrecioVentaConIVA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Format = "N2"
        Me.PrecioVentaConIVA.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrecioVentaConIVA.HeaderText = "Venta Con IVA"
        Me.PrecioVentaConIVA.Name = "PrecioVentaConIVA"
        Me.PrecioVentaConIVA.Width = 75
        '
        'IdUbicacion
        '
        Me.IdUbicacion.DataPropertyName = "IdUbicacion"
        Me.IdUbicacion.HeaderText = "IdUbicacion"
        Me.IdUbicacion.Name = "IdUbicacion"
        Me.IdUbicacion.Visible = False
        '
        'NombreUbicacion
        '
        Me.NombreUbicacion.DataPropertyName = "NombreUbicacion"
        Me.NombreUbicacion.HeaderText = "Ubicacion"
        Me.NombreUbicacion.Name = "NombreUbicacion"
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "Stock"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle4
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 70
        '
        'Marca
        '
        Me.Marca.DataPropertyName = "NombreMarca"
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        Me.Marca.Width = 130
        '
        'Rubro
        '
        Me.Rubro.DataPropertyName = "NombreRubro"
        Me.Rubro.HeaderText = "Rubro"
        Me.Rubro.Name = "Rubro"
        Me.Rubro.ReadOnly = True
        Me.Rubro.Width = 130
        '
        'Activo
        '
        Me.Activo.DataPropertyName = "Activo"
        Me.Activo.HeaderText = "Activo"
        Me.Activo.Name = "Activo"
        Me.Activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Activo.Width = 50
        '
        'Alicuota
        '
        Me.Alicuota.DataPropertyName = "Alicuota"
        Me.Alicuota.HeaderText = "Alicuota"
        Me.Alicuota.Name = "Alicuota"
        Me.Alicuota.Visible = False
        '
        'LimpiarStock
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 524)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.grbConsultar)
        Me.KeyPreview = True
        Me.Name = "LimpiarStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Limpiar Stock"
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
    Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbAjustar As System.Windows.Forms.ToolStripButton
    Friend WithEvents chbConStock As Eniac.Controles.CheckBox
    Friend WithEvents cmbDepositos As Controles.ComboBox
    Friend WithEvents lblDepositos As Controles.Label
    Friend WithEvents chkBlanquear As DataGridViewCheckBoxColumn
    Friend WithEvents Producto As DataGridViewTextBoxColumn
    Friend WithEvents NombreProducto As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVenta As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVentaConIVA As DataGridViewTextBoxColumn
    Friend WithEvents IdUbicacion As DataGridViewTextBoxColumn
    Friend WithEvents NombreUbicacion As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Marca As DataGridViewTextBoxColumn
    Friend WithEvents Rubro As DataGridViewTextBoxColumn
    Friend WithEvents Activo As DataGridViewCheckBoxColumn
    Friend WithEvents Alicuota As DataGridViewTextBoxColumn
End Class
