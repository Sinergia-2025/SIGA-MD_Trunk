<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosRecepcionF
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductosRecepcionF))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbRecibir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.lblCompra = New Eniac.Controles.Label()
      Me.lblFechaHasta = New Eniac.Controles.Label()
      Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
      Me.lblFechaDesde = New Eniac.Controles.Label()
      Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.txtTelefono = New Eniac.Controles.TextBox()
      Me.lblTelefono = New Eniac.Controles.Label()
      Me.txtLocalidad = New Eniac.Controles.TextBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.txtDireccion = New Eniac.Controles.TextBox()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.dgvProductos = New Eniac.Controles.DataGridView()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Tamano = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Rubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Garantia = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tslRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tstBarra.SuspendLayout()
      Me.grbCliente.SuspendLayout()
      CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbRecibir, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(870, 29)
      Me.tstBarra.TabIndex = 16
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
      'tsbRecibir
      '
      Me.tsbRecibir.Enabled = False
      Me.tsbRecibir.Image = Global.Eniac.Win.My.Resources.Resources.import1
      Me.tsbRecibir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRecibir.Name = "tsbRecibir"
      Me.tsbRecibir.Size = New System.Drawing.Size(69, 26)
      Me.tsbRecibir.Text = "&Recibir"
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
      'grbCliente
      '
      Me.grbCliente.Controls.Add(Me.lblCompra)
      Me.grbCliente.Controls.Add(Me.lblFechaHasta)
      Me.grbCliente.Controls.Add(Me.dtpFechaHasta)
      Me.grbCliente.Controls.Add(Me.lblFechaDesde)
      Me.grbCliente.Controls.Add(Me.dtpFechaDesde)
      Me.grbCliente.Controls.Add(Me.btnConsultar)
      Me.grbCliente.Controls.Add(Me.txtTelefono)
      Me.grbCliente.Controls.Add(Me.lblTelefono)
      Me.grbCliente.Controls.Add(Me.txtLocalidad)
      Me.grbCliente.Controls.Add(Me.lblLocalidad)
      Me.grbCliente.Controls.Add(Me.txtDireccion)
      Me.grbCliente.Controls.Add(Me.lblDireccion)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Location = New System.Drawing.Point(12, 32)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(846, 107)
      Me.grbCliente.TabIndex = 17
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Cliente"
      '
      'lblCompra
      '
      Me.lblCompra.AutoSize = True
      Me.lblCompra.Location = New System.Drawing.Point(451, 38)
      Me.lblCompra.Name = "lblCompra"
      Me.lblCompra.Size = New System.Drawing.Size(43, 13)
      Me.lblCompra.TabIndex = 49
      Me.lblCompra.Text = "Compra"
      '
      'lblFechaHasta
      '
      Me.lblFechaHasta.AutoSize = True
      Me.lblFechaHasta.Location = New System.Drawing.Point(598, 18)
      Me.lblFechaHasta.Name = "lblFechaHasta"
      Me.lblFechaHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblFechaHasta.TabIndex = 48
      Me.lblFechaHasta.Text = "Hasta"
      '
      'dtpFechaHasta
      '
      Me.dtpFechaHasta.BindearPropiedadControl = ""
      Me.dtpFechaHasta.BindearPropiedadEntidad = ""
      Me.dtpFechaHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaHasta.IsPK = False
      Me.dtpFechaHasta.IsRequired = True
      Me.dtpFechaHasta.Key = ""
      Me.dtpFechaHasta.LabelAsoc = Me.lblFechaHasta
      Me.dtpFechaHasta.Location = New System.Drawing.Point(601, 34)
      Me.dtpFechaHasta.Name = "dtpFechaHasta"
      Me.dtpFechaHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaHasta.TabIndex = 47
      '
      'lblFechaDesde
      '
      Me.lblFechaDesde.AutoSize = True
      Me.lblFechaDesde.Location = New System.Drawing.Point(497, 18)
      Me.lblFechaDesde.Name = "lblFechaDesde"
      Me.lblFechaDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblFechaDesde.TabIndex = 46
      Me.lblFechaDesde.Text = "Desde"
      '
      'dtpFechaDesde
      '
      Me.dtpFechaDesde.BindearPropiedadControl = ""
      Me.dtpFechaDesde.BindearPropiedadEntidad = ""
      Me.dtpFechaDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaDesde.IsPK = False
      Me.dtpFechaDesde.IsRequired = True
      Me.dtpFechaDesde.Key = ""
      Me.dtpFechaDesde.LabelAsoc = Me.lblFechaDesde
      Me.dtpFechaDesde.Location = New System.Drawing.Point(500, 34)
      Me.dtpFechaDesde.Name = "dtpFechaDesde"
      Me.dtpFechaDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaDesde.TabIndex = 45
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.document_find
      Me.btnConsultar.Location = New System.Drawing.Point(714, 38)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(113, 45)
      Me.btnConsultar.TabIndex = 30
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'txtTelefono
      '
      Me.txtTelefono.BindearPropiedadControl = Nothing
      Me.txtTelefono.BindearPropiedadEntidad = Nothing
      Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefono.Formato = ""
      Me.txtTelefono.IsDecimal = False
      Me.txtTelefono.IsNumber = False
      Me.txtTelefono.IsPK = False
      Me.txtTelefono.IsRequired = False
      Me.txtTelefono.Key = ""
      Me.txtTelefono.LabelAsoc = Me.lblTelefono
      Me.txtTelefono.Location = New System.Drawing.Point(443, 76)
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.ReadOnly = True
      Me.txtTelefono.Size = New System.Drawing.Size(214, 20)
      Me.txtTelefono.TabIndex = 23
      Me.txtTelefono.TabStop = False
      '
      'lblTelefono
      '
      Me.lblTelefono.AutoSize = True
      Me.lblTelefono.Location = New System.Drawing.Point(440, 60)
      Me.lblTelefono.Name = "lblTelefono"
      Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
      Me.lblTelefono.TabIndex = 28
      Me.lblTelefono.Text = "Telefono"
      '
      'txtLocalidad
      '
      Me.txtLocalidad.BindearPropiedadControl = Nothing
      Me.txtLocalidad.BindearPropiedadEntidad = Nothing
      Me.txtLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLocalidad.Formato = ""
      Me.txtLocalidad.IsDecimal = False
      Me.txtLocalidad.IsNumber = False
      Me.txtLocalidad.IsPK = False
      Me.txtLocalidad.IsRequired = False
      Me.txtLocalidad.Key = ""
      Me.txtLocalidad.LabelAsoc = Me.lblLocalidad
      Me.txtLocalidad.Location = New System.Drawing.Point(322, 76)
      Me.txtLocalidad.Name = "txtLocalidad"
      Me.txtLocalidad.ReadOnly = True
      Me.txtLocalidad.Size = New System.Drawing.Size(115, 20)
      Me.txtLocalidad.TabIndex = 21
      Me.txtLocalidad.TabStop = False
      '
      'lblLocalidad
      '
      Me.lblLocalidad.AutoSize = True
      Me.lblLocalidad.Location = New System.Drawing.Point(321, 60)
      Me.lblLocalidad.Name = "lblLocalidad"
      Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
      Me.lblLocalidad.TabIndex = 25
      Me.lblLocalidad.Text = "Localidad"
      '
      'txtDireccion
      '
      Me.txtDireccion.BindearPropiedadControl = Nothing
      Me.txtDireccion.BindearPropiedadEntidad = Nothing
      Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDireccion.Formato = ""
      Me.txtDireccion.IsDecimal = False
      Me.txtDireccion.IsNumber = False
      Me.txtDireccion.IsPK = False
      Me.txtDireccion.IsRequired = False
      Me.txtDireccion.Key = ""
      Me.txtDireccion.LabelAsoc = Me.lblDireccion
      Me.txtDireccion.Location = New System.Drawing.Point(13, 76)
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.ReadOnly = True
      Me.txtDireccion.Size = New System.Drawing.Size(304, 20)
      Me.txtDireccion.TabIndex = 19
      Me.txtDireccion.TabStop = False
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.Location = New System.Drawing.Point(10, 60)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblDireccion.TabIndex = 24
      Me.lblDireccion.Text = "Dirección"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasCondiciones = CType(resources.GetObject("bscCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCliente.ColumnasVisibles = CType(resources.GetObject("bscCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.lblNombre
      Me.bscCliente.Location = New System.Drawing.Point(140, 33)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 15
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(137, 18)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 14
      Me.lblNombre.Text = "Nombre"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasCondiciones = CType(resources.GetObject("bscCodigoCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoCliente.ColumnasVisibles = CType(resources.GetObject("bscCodigoCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(17, 34)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoCliente.TabIndex = 10
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(17, 18)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 12
      Me.lblCodigoCliente.Text = "Codigo"
      '
      'dgvProductos
      '
      Me.dgvProductos.AllowUserToAddRows = False
      Me.dgvProductos.AllowUserToDeleteRows = False
      Me.dgvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.NroOperacion, Me.IdProducto, Me.Producto, Me.Cantidad, Me.Tamano, Me.CodMarca, Me.Marca, Me.CodRubro, Me.Rubro, Me.Garantia, Me.IdSucursal})
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvProductos.DefaultCellStyle = DataGridViewCellStyle9
      Me.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvProductos.Location = New System.Drawing.Point(12, 145)
      Me.dgvProductos.MultiSelect = False
      Me.dgvProductos.Name = "dgvProductos"
      Me.dgvProductos.ReadOnly = True
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
      Me.dgvProductos.RowHeadersWidth = 20
      Me.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvProductos.Size = New System.Drawing.Size(846, 276)
      Me.dgvProductos.TabIndex = 18
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "FechaOperacion"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Format = "d"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle2
      Me.Fecha.HeaderText = "Fecha"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.ReadOnly = True
      Me.Fecha.Width = 70
      '
      'NroOperacion
      '
      Me.NroOperacion.DataPropertyName = "NroOperacion"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroOperacion.DefaultCellStyle = DataGridViewCellStyle3
      Me.NroOperacion.HeaderText = "Operacion"
      Me.NroOperacion.Name = "NroOperacion"
      Me.NroOperacion.ReadOnly = True
      Me.NroOperacion.Width = 70
      '
      'IdProducto
      '
      Me.IdProducto.DataPropertyName = "IdProducto"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdProducto.DefaultCellStyle = DataGridViewCellStyle4
      Me.IdProducto.HeaderText = "Código"
      Me.IdProducto.Name = "IdProducto"
      Me.IdProducto.ReadOnly = True
      Me.IdProducto.Width = 80
      '
      'Producto
      '
      Me.Producto.DataPropertyName = "NombreProducto"
      Me.Producto.HeaderText = "Producto"
      Me.Producto.Name = "Producto"
      Me.Producto.ReadOnly = True
      Me.Producto.Width = 275
      '
      'Cantidad
      '
      Me.Cantidad.DataPropertyName = "Cantidad"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle5
      Me.Cantidad.HeaderText = "Cant."
      Me.Cantidad.Name = "Cantidad"
      Me.Cantidad.ReadOnly = True
      Me.Cantidad.Width = 50
      '
      'Tamano
      '
      Me.Tamano.DataPropertyName = "Tamano"
      Me.Tamano.HeaderText = "Tamaño"
      Me.Tamano.Name = "Tamano"
      Me.Tamano.ReadOnly = True
      Me.Tamano.Visible = False
      Me.Tamano.Width = 60
      '
      'CodMarca
      '
      Me.CodMarca.DataPropertyName = "IdMarca"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CodMarca.DefaultCellStyle = DataGridViewCellStyle6
      Me.CodMarca.HeaderText = "Cod. Marca"
      Me.CodMarca.Name = "CodMarca"
      Me.CodMarca.ReadOnly = True
      Me.CodMarca.Visible = False
      Me.CodMarca.Width = 55
      '
      'Marca
      '
      Me.Marca.DataPropertyName = "NombreMarca"
      Me.Marca.HeaderText = "Marca"
      Me.Marca.Name = "Marca"
      Me.Marca.ReadOnly = True
      '
      'CodRubro
      '
      Me.CodRubro.DataPropertyName = "IdRubro"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CodRubro.DefaultCellStyle = DataGridViewCellStyle7
      Me.CodRubro.HeaderText = "Cod. Rubro"
      Me.CodRubro.Name = "CodRubro"
      Me.CodRubro.ReadOnly = True
      Me.CodRubro.Visible = False
      Me.CodRubro.Width = 55
      '
      'Rubro
      '
      Me.Rubro.DataPropertyName = "NombreRubro"
      Me.Rubro.HeaderText = "Rubro"
      Me.Rubro.Name = "Rubro"
      Me.Rubro.ReadOnly = True
      '
      'Garantia
      '
      Me.Garantia.DataPropertyName = "MesesGarantia"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Garantia.DefaultCellStyle = DataGridViewCellStyle8
      Me.Garantia.HeaderText = "Garantia"
      Me.Garantia.Name = "Garantia"
      Me.Garantia.ReadOnly = True
      Me.Garantia.Width = 60
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.ReadOnly = True
      Me.IdSucursal.Visible = False
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto, Me.tslRegistros, Me.tspBarra})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 424)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(870, 22)
      Me.StatusStrip1.TabIndex = 19
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tslTexto
      '
      Me.tslTexto.Name = "tslTexto"
      Me.tslTexto.Size = New System.Drawing.Size(791, 17)
      Me.tslTexto.Spring = True
      '
      'tslRegistros
      '
      Me.tslRegistros.Name = "tslRegistros"
      Me.tslRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tslRegistros.Text = "0 Registros"
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Marquee
      Me.tspBarra.Visible = False
      '
      'ProductosRecepcionF
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(870, 446)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.dgvProductos)
      Me.Controls.Add(Me.grbCliente)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ProductosRecepcionF"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Recepción de productos para reparación"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbRecibir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents txtLocalidad As Eniac.Controles.TextBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents dgvProductos As Eniac.Controles.DataGridView
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tslTexto As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroOperacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Tamano As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Rubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Garantia As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblCompra As Eniac.Controles.Label
   Friend WithEvents lblFechaHasta As Eniac.Controles.Label
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaDesde As Eniac.Controles.Label
   Friend WithEvents dtpFechaDesde As Eniac.Controles.DateTimePicker
End Class
