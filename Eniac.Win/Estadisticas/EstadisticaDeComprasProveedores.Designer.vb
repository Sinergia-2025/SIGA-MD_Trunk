<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadisticaDeComprasProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadisticaDeComprasProveedores))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.clbSucursales = New Eniac.Controles.CheckedListBox()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.chbModelo = New Eniac.Controles.CheckBox()
        Me.cmbModelo = New Eniac.Controles.ComboBox()
        Me.chbSubRubro = New Eniac.Controles.CheckBox()
        Me.cmbSubRubro = New Eniac.Controles.ComboBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.txtCantidad = New Eniac.Controles.TextBox()
        Me.lblCantidad = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbMesCompleto = New System.Windows.Forms.CheckBox()
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.CodigoProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.lblTotal = New Eniac.Controles.Label()
        Me.tstBarra.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbSalir, Me.ToolStripSeparator4})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(693, 29)
        Me.tstBarra.TabIndex = 0
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bscProducto2)
        Me.GroupBox1.Controls.Add(Me.bscCodigoProducto2)
        Me.GroupBox1.Controls.Add(Me.clbSucursales)
        Me.GroupBox1.Controls.Add(Me.chbProducto)
        Me.GroupBox1.Controls.Add(Me.chbModelo)
        Me.GroupBox1.Controls.Add(Me.cmbModelo)
        Me.GroupBox1.Controls.Add(Me.chbSubRubro)
        Me.GroupBox1.Controls.Add(Me.cmbSubRubro)
        Me.GroupBox1.Controls.Add(Me.chbRubro)
        Me.GroupBox1.Controls.Add(Me.cmbRubro)
        Me.GroupBox1.Controls.Add(Me.chbMarca)
        Me.GroupBox1.Controls.Add(Me.cmbMarca)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.lblCantidad)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHasta)
        Me.GroupBox1.Controls.Add(Me.dtpDesde)
        Me.GroupBox1.Controls.Add(Me.lblHasta)
        Me.GroupBox1.Controls.Add(Me.lblDesde)
        Me.GroupBox1.Controls.Add(Me.chbMesCompleto)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(676, 183)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'bscProducto2
        '
        Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ColumnasVisibles = CType(resources.GetObject("bscProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.Enabled = False
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(239, 151)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(306, 20)
        Me.bscProducto2.TabIndex = 48
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ColumnasVisibles = CType(resources.GetObject("bscCodigoProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.Enabled = False
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(85, 150)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto2.TabIndex = 47
        '
        'clbSucursales
        '
        Me.clbSucursales.CheckOnClick = True
        Me.clbSucursales.FormattingEnabled = True
        Me.clbSucursales.Location = New System.Drawing.Point(18, 13)
        Me.clbSucursales.Name = "clbSucursales"
        Me.clbSucursales.Size = New System.Drawing.Size(128, 64)
        Me.clbSucursales.TabIndex = 0
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(18, 154)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 16
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
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
        Me.chbModelo.Location = New System.Drawing.Point(292, 88)
        Me.chbModelo.Name = "chbModelo"
        Me.chbModelo.Size = New System.Drawing.Size(61, 17)
        Me.chbModelo.TabIndex = 12
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
        Me.cmbModelo.Location = New System.Drawing.Point(367, 86)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.Size = New System.Drawing.Size(188, 21)
        Me.cmbModelo.TabIndex = 13
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
        Me.chbSubRubro.Location = New System.Drawing.Point(292, 121)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 14
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
        Me.cmbSubRubro.Location = New System.Drawing.Point(367, 119)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(188, 21)
        Me.cmbSubRubro.TabIndex = 15
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
        Me.chbRubro.Location = New System.Drawing.Point(18, 120)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 10
        Me.chbRubro.Text = "Rubro"
        Me.chbRubro.UseVisualStyleBackColor = True
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
        Me.cmbRubro.Location = New System.Drawing.Point(77, 117)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(179, 21)
        Me.cmbRubro.TabIndex = 11
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
        Me.chbMarca.Location = New System.Drawing.Point(18, 89)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 8
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
        Me.cmbMarca.Location = New System.Drawing.Point(77, 87)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(179, 21)
        Me.cmbMarca.TabIndex = 9
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
        Me.txtCantidad.Location = New System.Drawing.Point(380, 55)
        Me.txtCantidad.MaxLength = 4
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(40, 20)
        Me.txtCantidad.TabIndex = 7
        Me.txtCantidad.Text = "10"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(201, 58)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(173, 13)
        Me.lblCantidad.TabIndex = 6
        Me.lblCantidad.Text = "Cantidad de Proveedores a mostrar"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(570, 112)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 19
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(491, 23)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(84, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Location = New System.Drawing.Point(450, 26)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
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
        Me.dtpDesde.Location = New System.Drawing.Point(341, 23)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(84, 20)
        Me.dtpDesde.TabIndex = 3
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.Location = New System.Drawing.Point(297, 25)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 2
        Me.lblDesde.Text = "Desde"
        '
        'chbMesCompleto
        '
        Me.chbMesCompleto.AutoSize = True
        Me.chbMesCompleto.Location = New System.Drawing.Point(200, 24)
        Me.chbMesCompleto.Name = "chbMesCompleto"
        Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chbMesCompleto.TabIndex = 1
        Me.chbMesCompleto.Text = "Mes Completo"
        Me.chbMesCompleto.UseVisualStyleBackColor = True
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoProveedor, Me.IdProveedor, Me.NombreProveedor, Me.Importe, Me.PorcImporte})
        Me.dgvDetalle.Location = New System.Drawing.Point(8, 221)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.Size = New System.Drawing.Size(676, 243)
        Me.dgvDetalle.TabIndex = 2
        '
        'CodigoProveedor
        '
        Me.CodigoProveedor.DataPropertyName = "CodigoProveedor"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CodigoProveedor.DefaultCellStyle = DataGridViewCellStyle1
        Me.CodigoProveedor.HeaderText = "Cod. Proveedor"
        Me.CodigoProveedor.Name = "CodigoProveedor"
        Me.CodigoProveedor.ReadOnly = True
        Me.CodigoProveedor.Width = 110
        '
        'IdProveedor
        '
        Me.IdProveedor.DataPropertyName = "IdProveedor"
        Me.IdProveedor.HeaderText = "IdProveedor"
        Me.IdProveedor.Name = "IdProveedor"
        Me.IdProveedor.ReadOnly = True
        Me.IdProveedor.Visible = False
        '
        'NombreProveedor
        '
        Me.NombreProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreProveedor.DataPropertyName = "NombreProveedor"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NombreProveedor.DefaultCellStyle = DataGridViewCellStyle2
        Me.NombreProveedor.HeaderText = "Nombre Proveedor"
        Me.NombreProveedor.Name = "NombreProveedor"
        Me.NombreProveedor.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle3
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 80
        '
        'PorcImporte
        '
        Me.PorcImporte.DataPropertyName = "PorcImporte"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PorcImporte.DefaultCellStyle = DataGridViewCellStyle4
        Me.PorcImporte.HeaderText = "% Imp."
        Me.PorcImporte.Name = "PorcImporte"
        Me.PorcImporte.ReadOnly = True
        Me.PorcImporte.Width = 70
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.txtTotal.LabelAsoc = Me.lblTotal
        Me.txtTotal.Location = New System.Drawing.Point(532, 464)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(80, 20)
        Me.txtTotal.TabIndex = 13
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(492, 468)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblTotal.TabIndex = 12
        Me.lblTotal.Text = "Total :"
        '
        'EstadisticaDeComprasProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 490)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "EstadisticaDeComprasProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadística de Compras por Proveedores"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblHasta As Eniac.Controles.Label
    Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents chbMesCompleto As System.Windows.Forms.CheckBox
    Friend WithEvents btnConsultar As Eniac.Controles.Button
    Friend WithEvents lblCantidad As Eniac.Controles.Label
    Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtCantidad As Eniac.Controles.TextBox
    Friend WithEvents chbModelo As Eniac.Controles.CheckBox
    Friend WithEvents cmbModelo As Eniac.Controles.ComboBox
    Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
    Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
    Friend WithEvents chbRubro As Eniac.Controles.CheckBox
    Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
    Friend WithEvents chbMarca As Eniac.Controles.CheckBox
    Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
    Friend WithEvents chbProducto As Eniac.Controles.CheckBox
    Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
    Friend WithEvents txtTotal As Eniac.Controles.TextBox
    Friend WithEvents lblTotal As Eniac.Controles.Label
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents CodigoProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PorcImporte As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
