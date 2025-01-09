<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadVentasProductoComparativo
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
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadVentasProductoComparativo))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.txtCantidad = New Eniac.Controles.TextBox()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbModelo = New Eniac.Controles.CheckBox()
      Me.cmbModelo = New Eniac.Controles.ComboBox()
      Me.chbSubRubro = New Eniac.Controles.CheckBox()
      Me.chbRubro = New Eniac.Controles.CheckBox()
      Me.cmbSubRubro = New Eniac.Controles.ComboBox()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PorcCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PorcImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.cmbRubro = New Eniac.Controles.ComboBox()
      Me.chbMarca = New Eniac.Controles.CheckBox()
      Me.cmbMarca = New Eniac.Controles.ComboBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtPeriodo = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.tstBarra.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbSalir, Me.ToolStripSeparator4})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(819, 29)
      Me.tstBarra.TabIndex = 3
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasAlineacion = Nothing
      Me.bscCodigoCliente.ColumnasAncho = Nothing
      Me.bscCodigoCliente.ColumnasFormato = Nothing
      Me.bscCodigoCliente.ColumnasOcultas = Nothing
      Me.bscCodigoCliente.ColumnasTitulos = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(81, 119)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 19
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(78, 103)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 18
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAncho = 608
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasAlineacion = Nothing
      Me.bscCliente.ColumnasAncho = Nothing
      Me.bscCliente.ColumnasFormato = Nothing
      Me.bscCliente.ColumnasOcultas = Nothing
      Me.bscCliente.ColumnasTitulos = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.Enabled = False
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
      Me.bscCliente.Location = New System.Drawing.Point(178, 119)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 21
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(175, 103)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 20
      Me.lblNombre.Text = "Nombre"
      '
      'chbCliente
      '
      Me.chbCliente.AutoSize = True
      Me.chbCliente.BindearPropiedadControl = Nothing
      Me.chbCliente.BindearPropiedadEntidad = Nothing
      Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCliente.IsPK = False
      Me.chbCliente.IsRequired = False
      Me.chbCliente.Key = Nothing
      Me.chbCliente.LabelAsoc = Nothing
      Me.chbCliente.Location = New System.Drawing.Point(17, 123)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 15
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'txtCantidad
      '
      Me.txtCantidad.BindearPropiedadControl = Nothing
      Me.txtCantidad.BindearPropiedadEntidad = Nothing
      Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidad.Formato = ""
      Me.txtCantidad.IsDecimal = False
      Me.txtCantidad.IsNumber = True
      Me.txtCantidad.IsPK = False
      Me.txtCantidad.IsRequired = False
      Me.txtCantidad.Key = ""
      Me.txtCantidad.LabelAsoc = Me.lblCantidad
      Me.txtCantidad.Location = New System.Drawing.Point(704, 18)
      Me.txtCantidad.MaxLength = 4
      Me.txtCantidad.Name = "txtCantidad"
      Me.txtCantidad.Size = New System.Drawing.Size(40, 20)
      Me.txtCantidad.TabIndex = 6
      Me.txtCantidad.Text = "10"
      Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblCantidad
      '
      Me.lblCantidad.AutoSize = True
      Me.lblCantidad.Location = New System.Drawing.Point(538, 21)
      Me.lblCantidad.Name = "lblCantidad"
      Me.lblCantidad.Size = New System.Drawing.Size(160, 13)
      Me.lblCantidad.TabIndex = 5
      Me.lblCantidad.Text = "Cantidad de productos a mostrar"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(693, 97)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 22
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chbModelo
      '
      Me.chbModelo.AutoSize = True
      Me.chbModelo.BindearPropiedadControl = Nothing
      Me.chbModelo.BindearPropiedadEntidad = Nothing
      Me.chbModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbModelo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbModelo.IsPK = False
      Me.chbModelo.IsRequired = False
      Me.chbModelo.Key = Nothing
      Me.chbModelo.LabelAsoc = Nothing
      Me.chbModelo.Location = New System.Drawing.Point(310, 50)
      Me.chbModelo.Name = "chbModelo"
      Me.chbModelo.Size = New System.Drawing.Size(61, 17)
      Me.chbModelo.TabIndex = 9
      Me.chbModelo.Text = "Modelo"
      Me.chbModelo.UseVisualStyleBackColor = True
      '
      'cmbModelo
      '
      Me.cmbModelo.BindearPropiedadControl = Nothing
      Me.cmbModelo.BindearPropiedadEntidad = Nothing
      Me.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbModelo.Enabled = False
      Me.cmbModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbModelo.FormattingEnabled = True
      Me.cmbModelo.IsPK = False
      Me.cmbModelo.IsRequired = False
      Me.cmbModelo.Key = Nothing
      Me.cmbModelo.LabelAsoc = Nothing
      Me.cmbModelo.Location = New System.Drawing.Point(385, 48)
      Me.cmbModelo.Name = "cmbModelo"
      Me.cmbModelo.Size = New System.Drawing.Size(188, 21)
      Me.cmbModelo.TabIndex = 10
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
      Me.chbSubRubro.Location = New System.Drawing.Point(310, 82)
      Me.chbSubRubro.Name = "chbSubRubro"
      Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
      Me.chbSubRubro.TabIndex = 13
      Me.chbSubRubro.Text = "SubRubro"
      Me.chbSubRubro.UseVisualStyleBackColor = True
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
      Me.chbRubro.Location = New System.Drawing.Point(17, 82)
      Me.chbRubro.Name = "chbRubro"
      Me.chbRubro.Size = New System.Drawing.Size(55, 17)
      Me.chbRubro.TabIndex = 11
      Me.chbRubro.Text = "Rubro"
      Me.chbRubro.UseVisualStyleBackColor = True
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
      Me.cmbSubRubro.Location = New System.Drawing.Point(385, 80)
      Me.cmbSubRubro.Name = "cmbSubRubro"
      Me.cmbSubRubro.Size = New System.Drawing.Size(188, 21)
      Me.cmbSubRubro.TabIndex = 14
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeRows = False
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProducto, Me.NombreProducto, Me.Cantidad, Me.Importe, Me.PorcCantidad, Me.PorcImporte})
      Me.dgvDetalle.Location = New System.Drawing.Point(8, 189)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.Size = New System.Drawing.Size(799, 243)
      Me.dgvDetalle.TabIndex = 5
      '
      'IdProducto
      '
      Me.IdProducto.DataPropertyName = "IdProducto"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdProducto.DefaultCellStyle = DataGridViewCellStyle1
      Me.IdProducto.HeaderText = "Codigo"
      Me.IdProducto.Name = "IdProducto"
      Me.IdProducto.ReadOnly = True
      Me.IdProducto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      '
      'NombreProducto
      '
      Me.NombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.NombreProducto.DataPropertyName = "NombreProducto"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      Me.NombreProducto.DefaultCellStyle = DataGridViewCellStyle2
      Me.NombreProducto.HeaderText = "Nombre Producto"
      Me.NombreProducto.Name = "NombreProducto"
      Me.NombreProducto.ReadOnly = True
      '
      'Cantidad
      '
      Me.Cantidad.DataPropertyName = "Cantidad"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle3.Format = "N2"
      Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle3
      Me.Cantidad.HeaderText = "Cantidad"
      Me.Cantidad.Name = "Cantidad"
      Me.Cantidad.ReadOnly = True
      Me.Cantidad.Width = 80
      '
      'Importe
      '
      Me.Importe.DataPropertyName = "Importe"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle4.Format = "N2"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.Importe.DefaultCellStyle = DataGridViewCellStyle4
      Me.Importe.HeaderText = "Importe"
      Me.Importe.Name = "Importe"
      Me.Importe.ReadOnly = True
      Me.Importe.Width = 80
      '
      'PorcCantidad
      '
      Me.PorcCantidad.DataPropertyName = "PorcCantidad"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle5.Format = "N2"
      DataGridViewCellStyle5.NullValue = Nothing
      Me.PorcCantidad.DefaultCellStyle = DataGridViewCellStyle5
      Me.PorcCantidad.HeaderText = "% Cant."
      Me.PorcCantidad.Name = "PorcCantidad"
      Me.PorcCantidad.ReadOnly = True
      Me.PorcCantidad.Width = 70
      '
      'PorcImporte
      '
      Me.PorcImporte.DataPropertyName = "PorcImporte"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "N2"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.PorcImporte.DefaultCellStyle = DataGridViewCellStyle6
      Me.PorcImporte.HeaderText = "% Imp."
      Me.PorcImporte.Name = "PorcImporte"
      Me.PorcImporte.ReadOnly = True
      Me.PorcImporte.Width = 70
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
      Me.cmbRubro.Location = New System.Drawing.Point(76, 78)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(179, 21)
      Me.cmbRubro.TabIndex = 12
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
      Me.chbMarca.Location = New System.Drawing.Point(17, 51)
      Me.chbMarca.Name = "chbMarca"
      Me.chbMarca.Size = New System.Drawing.Size(56, 17)
      Me.chbMarca.TabIndex = 7
      Me.chbMarca.Text = "Marca"
      Me.chbMarca.UseVisualStyleBackColor = True
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
      Me.cmbMarca.Location = New System.Drawing.Point(76, 48)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(179, 21)
      Me.cmbMarca.TabIndex = 8
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(268, 18)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(227, 21)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(118, 18)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(26, 20)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(86, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Fecha      Desde"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.txtPeriodo)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.bscCodigoCliente)
      Me.GroupBox1.Controls.Add(Me.bscCliente)
      Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
      Me.GroupBox1.Controls.Add(Me.lblNombre)
      Me.GroupBox1.Controls.Add(Me.chbCliente)
      Me.GroupBox1.Controls.Add(Me.txtCantidad)
      Me.GroupBox1.Controls.Add(Me.lblCantidad)
      Me.GroupBox1.Controls.Add(Me.btnConsultar)
      Me.GroupBox1.Controls.Add(Me.chbModelo)
      Me.GroupBox1.Controls.Add(Me.cmbModelo)
      Me.GroupBox1.Controls.Add(Me.chbSubRubro)
      Me.GroupBox1.Controls.Add(Me.cmbSubRubro)
      Me.GroupBox1.Controls.Add(Me.chbRubro)
      Me.GroupBox1.Controls.Add(Me.cmbRubro)
      Me.GroupBox1.Controls.Add(Me.chbMarca)
      Me.GroupBox1.Controls.Add(Me.cmbMarca)
      Me.GroupBox1.Controls.Add(Me.dtpHasta)
      Me.GroupBox1.Controls.Add(Me.dtpDesde)
      Me.GroupBox1.Controls.Add(Me.lblHasta)
      Me.GroupBox1.Controls.Add(Me.lblDesde)
      Me.GroupBox1.Location = New System.Drawing.Point(8, 32)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(799, 151)
      Me.GroupBox1.TabIndex = 4
      Me.GroupBox1.TabStop = False
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(490, 21)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(28, 13)
      Me.Label2.TabIndex = 25
      Me.Label2.Text = "días"
      '
      'txtPeriodo
      '
      Me.txtPeriodo.BindearPropiedadControl = Nothing
      Me.txtPeriodo.BindearPropiedadEntidad = Nothing
      Me.txtPeriodo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPeriodo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPeriodo.Formato = ""
      Me.txtPeriodo.IsDecimal = False
      Me.txtPeriodo.IsNumber = True
      Me.txtPeriodo.IsPK = False
      Me.txtPeriodo.IsRequired = False
      Me.txtPeriodo.Key = ""
      Me.txtPeriodo.LabelAsoc = Me.lblCantidad
      Me.txtPeriodo.Location = New System.Drawing.Point(444, 17)
      Me.txtPeriodo.MaxLength = 4
      Me.txtPeriodo.Name = "txtPeriodo"
      Me.txtPeriodo.Size = New System.Drawing.Size(40, 20)
      Me.txtPeriodo.TabIndex = 24
      Me.txtPeriodo.Text = "30"
      Me.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(397, 20)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(45, 13)
      Me.Label1.TabIndex = 23
      Me.Label1.Text = "Período"
      '
      'EstadVentasProductoComparativo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(819, 437)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "EstadVentasProductoComparativo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Comparativo Estadística de Ventas por Producto"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents txtCantidad As Eniac.Controles.TextBox
   Friend WithEvents lblCantidad As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbModelo As Eniac.Controles.CheckBox
   Friend WithEvents cmbModelo As Eniac.Controles.ComboBox
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PorcCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PorcImporte As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtPeriodo As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
End Class
