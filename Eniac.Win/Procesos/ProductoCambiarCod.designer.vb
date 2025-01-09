<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductoCambiarCod
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
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
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.bscCodigoProducto2REC = New Eniac.Controles.Buscador2()
      Me.Label5 = New Eniac.Controles.Label()
      Me.grbProducto = New System.Windows.Forms.GroupBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.txtRubroNombre = New Eniac.Controles.TextBox()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.txtMarcaNombre = New Eniac.Controles.TextBox()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.txtRubroCodigo = New Eniac.Controles.TextBox()
      Me.txtMarcaCodigo = New Eniac.Controles.TextBox()
      Me.txtStock = New Eniac.Controles.TextBox()
      Me.lblStock = New Eniac.Controles.Label()
      Me.txtPrecioVenta = New Eniac.Controles.TextBox()
      Me.lblPrecioVenta = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Label3 = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbActualizar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.FechaMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdClienteProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoClienteProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreClienteProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.SucursalDeA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.GroupBox1.SuspendLayout()
      Me.grbProducto.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.bscCodigoProducto2REC)
      Me.GroupBox1.Controls.Add(Me.Label5)
      Me.GroupBox1.Location = New System.Drawing.Point(8, 333)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(882, 62)
      Me.GroupBox1.TabIndex = 1
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Producto Destino"
      '
      'bscCodigoProducto2REC
      '
      Me.bscCodigoProducto2REC.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2REC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCodigoProducto2REC.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2REC.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2REC.ConfigBuscador = Nothing
      Me.bscCodigoProducto2REC.Datos = Nothing
      Me.bscCodigoProducto2REC.FilaDevuelta = Nothing
      Me.bscCodigoProducto2REC.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2REC.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2REC.IsDecimal = False
      Me.bscCodigoProducto2REC.IsNumber = False
      Me.bscCodigoProducto2REC.IsPK = False
      Me.bscCodigoProducto2REC.IsRequired = False
      Me.bscCodigoProducto2REC.Key = ""
      Me.bscCodigoProducto2REC.LabelAsoc = Nothing
      Me.bscCodigoProducto2REC.Location = New System.Drawing.Point(72, 25)
      Me.bscCodigoProducto2REC.MaxLengh = "32767"
      Me.bscCodigoProducto2REC.Name = "bscCodigoProducto2REC"
      Me.bscCodigoProducto2REC.Permitido = True
      Me.bscCodigoProducto2REC.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2REC.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2REC.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2REC.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2REC.Selecciono = False
      Me.bscCodigoProducto2REC.Size = New System.Drawing.Size(128, 20)
      Me.bscCodigoProducto2REC.TabIndex = 1
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.LabelAsoc = Nothing
      Me.Label5.Location = New System.Drawing.Point(26, 30)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(40, 13)
      Me.Label5.TabIndex = 0
      Me.Label5.Text = "Código"
      '
      'grbProducto
      '
      Me.grbProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbProducto.Controls.Add(Me.bscProducto2)
      Me.grbProducto.Controls.Add(Me.bscCodigoProducto2)
      Me.grbProducto.Controls.Add(Me.txtRubroNombre)
      Me.grbProducto.Controls.Add(Me.txtMarcaNombre)
      Me.grbProducto.Controls.Add(Me.txtRubroCodigo)
      Me.grbProducto.Controls.Add(Me.txtMarcaCodigo)
      Me.grbProducto.Controls.Add(Me.txtStock)
      Me.grbProducto.Controls.Add(Me.lblStock)
      Me.grbProducto.Controls.Add(Me.txtPrecioVenta)
      Me.grbProducto.Controls.Add(Me.lblPrecioVenta)
      Me.grbProducto.Controls.Add(Me.lblRubro)
      Me.grbProducto.Controls.Add(Me.lblMarca)
      Me.grbProducto.Controls.Add(Me.Label4)
      Me.grbProducto.Controls.Add(Me.Label2)
      Me.grbProducto.Controls.Add(Me.dgvDetalle)
      Me.grbProducto.Controls.Add(Me.Label3)
      Me.grbProducto.Location = New System.Drawing.Point(8, 42)
      Me.grbProducto.Name = "grbProducto"
      Me.grbProducto.Size = New System.Drawing.Size(882, 285)
      Me.grbProducto.TabIndex = 0
      Me.grbProducto.TabStop = False
      Me.grbProducto.Text = "Producto Origen"
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ConfigBuscador = Nothing
      Me.bscProducto2.Datos = Nothing
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto2.IsDecimal = False
      Me.bscProducto2.IsNumber = False
      Me.bscProducto2.IsPK = False
      Me.bscProducto2.IsRequired = False
      Me.bscProducto2.Key = ""
      Me.bscProducto2.LabelAsoc = Nothing
      Me.bscProducto2.Location = New System.Drawing.Point(130, 44)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(338, 20)
      Me.bscProducto2.TabIndex = 3
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCodigoProducto2.Datos = Nothing
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2.IsDecimal = False
      Me.bscCodigoProducto2.IsNumber = False
      Me.bscCodigoProducto2.IsPK = False
      Me.bscCodigoProducto2.IsRequired = False
      Me.bscCodigoProducto2.Key = ""
      Me.bscCodigoProducto2.LabelAsoc = Nothing
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(10, 43)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(119, 20)
      Me.bscCodigoProducto2.TabIndex = 1
      '
      'txtRubroNombre
      '
      Me.txtRubroNombre.BindearPropiedadControl = ""
      Me.txtRubroNombre.BindearPropiedadEntidad = ""
      Me.txtRubroNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRubroNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRubroNombre.Formato = "##0"
      Me.txtRubroNombre.IsDecimal = False
      Me.txtRubroNombre.IsNumber = False
      Me.txtRubroNombre.IsPK = False
      Me.txtRubroNombre.IsRequired = False
      Me.txtRubroNombre.Key = ""
      Me.txtRubroNombre.LabelAsoc = Me.lblRubro
      Me.txtRubroNombre.Location = New System.Drawing.Point(630, 44)
      Me.txtRubroNombre.MaxLength = 13
      Me.txtRubroNombre.Name = "txtRubroNombre"
      Me.txtRubroNombre.ReadOnly = True
      Me.txtRubroNombre.Size = New System.Drawing.Size(237, 20)
      Me.txtRubroNombre.TabIndex = 9
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.LabelAsoc = Nothing
      Me.lblRubro.Location = New System.Drawing.Point(474, 47)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(36, 13)
      Me.lblRubro.TabIndex = 7
      Me.lblRubro.Text = "Rubro"
      '
      'txtMarcaNombre
      '
      Me.txtMarcaNombre.BindearPropiedadControl = ""
      Me.txtMarcaNombre.BindearPropiedadEntidad = ""
      Me.txtMarcaNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMarcaNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMarcaNombre.Formato = "##0"
      Me.txtMarcaNombre.IsDecimal = False
      Me.txtMarcaNombre.IsNumber = False
      Me.txtMarcaNombre.IsPK = False
      Me.txtMarcaNombre.IsRequired = False
      Me.txtMarcaNombre.Key = ""
      Me.txtMarcaNombre.LabelAsoc = Me.lblMarca
      Me.txtMarcaNombre.Location = New System.Drawing.Point(630, 16)
      Me.txtMarcaNombre.MaxLength = 13
      Me.txtMarcaNombre.Name = "txtMarcaNombre"
      Me.txtMarcaNombre.ReadOnly = True
      Me.txtMarcaNombre.Size = New System.Drawing.Size(237, 20)
      Me.txtMarcaNombre.TabIndex = 6
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.LabelAsoc = Nothing
      Me.lblMarca.Location = New System.Drawing.Point(474, 20)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(37, 13)
      Me.lblMarca.TabIndex = 4
      Me.lblMarca.Text = "Marca"
      '
      'txtRubroCodigo
      '
      Me.txtRubroCodigo.BindearPropiedadControl = ""
      Me.txtRubroCodigo.BindearPropiedadEntidad = ""
      Me.txtRubroCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRubroCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRubroCodigo.Formato = "##0"
      Me.txtRubroCodigo.IsDecimal = False
      Me.txtRubroCodigo.IsNumber = True
      Me.txtRubroCodigo.IsPK = False
      Me.txtRubroCodigo.IsRequired = False
      Me.txtRubroCodigo.Key = ""
      Me.txtRubroCodigo.LabelAsoc = Me.lblRubro
      Me.txtRubroCodigo.Location = New System.Drawing.Point(527, 44)
      Me.txtRubroCodigo.MaxLength = 13
      Me.txtRubroCodigo.Name = "txtRubroCodigo"
      Me.txtRubroCodigo.ReadOnly = True
      Me.txtRubroCodigo.Size = New System.Drawing.Size(93, 20)
      Me.txtRubroCodigo.TabIndex = 8
      Me.txtRubroCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtMarcaCodigo
      '
      Me.txtMarcaCodigo.BindearPropiedadControl = ""
      Me.txtMarcaCodigo.BindearPropiedadEntidad = ""
      Me.txtMarcaCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMarcaCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMarcaCodigo.Formato = "##0"
      Me.txtMarcaCodigo.IsDecimal = False
      Me.txtMarcaCodigo.IsNumber = True
      Me.txtMarcaCodigo.IsPK = False
      Me.txtMarcaCodigo.IsRequired = False
      Me.txtMarcaCodigo.Key = ""
      Me.txtMarcaCodigo.LabelAsoc = Me.lblMarca
      Me.txtMarcaCodigo.Location = New System.Drawing.Point(527, 16)
      Me.txtMarcaCodigo.MaxLength = 13
      Me.txtMarcaCodigo.Name = "txtMarcaCodigo"
      Me.txtMarcaCodigo.ReadOnly = True
      Me.txtMarcaCodigo.Size = New System.Drawing.Size(93, 20)
      Me.txtMarcaCodigo.TabIndex = 5
      Me.txtMarcaCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtStock
      '
      Me.txtStock.BindearPropiedadControl = ""
      Me.txtStock.BindearPropiedadEntidad = ""
      Me.txtStock.ForeColorFocus = System.Drawing.Color.Red
      Me.txtStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtStock.Formato = "##0.00"
      Me.txtStock.IsDecimal = True
      Me.txtStock.IsNumber = True
      Me.txtStock.IsPK = False
      Me.txtStock.IsRequired = False
      Me.txtStock.Key = ""
      Me.txtStock.LabelAsoc = Me.lblStock
      Me.txtStock.Location = New System.Drawing.Point(770, 70)
      Me.txtStock.MaxLength = 13
      Me.txtStock.Name = "txtStock"
      Me.txtStock.ReadOnly = True
      Me.txtStock.Size = New System.Drawing.Size(97, 20)
      Me.txtStock.TabIndex = 13
      Me.txtStock.Text = "0.00"
      Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblStock
      '
      Me.lblStock.AutoSize = True
      Me.lblStock.LabelAsoc = Nothing
      Me.lblStock.Location = New System.Drawing.Point(730, 73)
      Me.lblStock.Name = "lblStock"
      Me.lblStock.Size = New System.Drawing.Size(35, 13)
      Me.lblStock.TabIndex = 12
      Me.lblStock.Text = "Stock"
      '
      'txtPrecioVenta
      '
      Me.txtPrecioVenta.BindearPropiedadControl = ""
      Me.txtPrecioVenta.BindearPropiedadEntidad = ""
      Me.txtPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrecioVenta.Formato = "##0.00"
      Me.txtPrecioVenta.IsDecimal = True
      Me.txtPrecioVenta.IsNumber = True
      Me.txtPrecioVenta.IsPK = False
      Me.txtPrecioVenta.IsRequired = False
      Me.txtPrecioVenta.Key = ""
      Me.txtPrecioVenta.LabelAsoc = Me.lblPrecioVenta
      Me.txtPrecioVenta.Location = New System.Drawing.Point(618, 70)
      Me.txtPrecioVenta.MaxLength = 13
      Me.txtPrecioVenta.Name = "txtPrecioVenta"
      Me.txtPrecioVenta.ReadOnly = True
      Me.txtPrecioVenta.Size = New System.Drawing.Size(97, 20)
      Me.txtPrecioVenta.TabIndex = 11
      Me.txtPrecioVenta.Text = "0.00"
      Me.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPrecioVenta
      '
      Me.lblPrecioVenta.AutoSize = True
      Me.lblPrecioVenta.LabelAsoc = Nothing
      Me.lblPrecioVenta.Location = New System.Drawing.Point(545, 73)
      Me.lblPrecioVenta.Name = "lblPrecioVenta"
      Me.lblPrecioVenta.Size = New System.Drawing.Size(68, 13)
      Me.lblPrecioVenta.TabIndex = 10
      Me.lblPrecioVenta.Text = "Precio Venta"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(150, 23)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(63, 13)
      Me.Label4.TabIndex = 2
      Me.Label4.Text = "Descripción"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(15, 24)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(40, 13)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Código"
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechaMovimiento, Me.TipoMovimiento, Me.NumeroMovimiento, Me.TipoComprobante, Me.Letra, Me.NumeroComprobante, Me.Cantidad, Me.IdClienteProveedor, Me.CodigoClienteProveedor, Me.NombreClienteProveedor, Me.SucursalDeA, Me.Usuario, Me.IdFormula})
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(10, 98)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersWidth = 15
      Me.dgvDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(866, 181)
      Me.dgvDetalle.TabIndex = 15
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(8, 75)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(165, 13)
      Me.Label3.TabIndex = 14
      Me.Label3.Text = "Operaciones del último año:"
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbActualizar, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(902, 29)
      Me.tstBarra.TabIndex = 2
      Me.tstBarra.Text = "ToolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      Me.tsbRefrescar.ToolTipText = "Refrescar el formulario"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbActualizar
      '
      Me.tsbActualizar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbActualizar.Name = "tsbActualizar"
      Me.tsbActualizar.Size = New System.Drawing.Size(108, 26)
      Me.tsbActualizar.Text = "&Actualizar (F4)"
      Me.tsbActualizar.ToolTipText = "Refrescar el formulario"
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
      Me.tsbSalir.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'FechaMovimiento
      '
      Me.FechaMovimiento.DataPropertyName = "FechaMovimiento"
      Me.FechaMovimiento.HeaderText = "Fecha"
      Me.FechaMovimiento.Name = "FechaMovimiento"
      Me.FechaMovimiento.ReadOnly = True
      Me.FechaMovimiento.Width = 120
      '
      'TipoMovimiento
      '
      Me.TipoMovimiento.DataPropertyName = "TipoMovimiento"
      Me.TipoMovimiento.HeaderText = "Tipo Movim."
      Me.TipoMovimiento.Name = "TipoMovimiento"
      Me.TipoMovimiento.ReadOnly = True
      '
      'NumeroMovimiento
      '
      Me.NumeroMovimiento.DataPropertyName = "NumeroMovimiento"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroMovimiento.DefaultCellStyle = DataGridViewCellStyle1
      Me.NumeroMovimiento.HeaderText = "Nro. Mov."
      Me.NumeroMovimiento.Name = "NumeroMovimiento"
      Me.NumeroMovimiento.ReadOnly = True
      Me.NumeroMovimiento.Width = 70
      '
      'TipoComprobante
      '
      Me.TipoComprobante.DataPropertyName = "TipoComprobante"
      Me.TipoComprobante.HeaderText = "Comprobante"
      Me.TipoComprobante.Name = "TipoComprobante"
      Me.TipoComprobante.ReadOnly = True
      Me.TipoComprobante.Width = 90
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
      Me.Letra.HeaderText = "L."
      Me.Letra.Name = "Letra"
      Me.Letra.ReadOnly = True
      Me.Letra.Width = 20
      '
      'NumeroComprobante
      '
      Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle3
      Me.NumeroComprobante.HeaderText = "Numero"
      Me.NumeroComprobante.Name = "NumeroComprobante"
      Me.NumeroComprobante.ReadOnly = True
      Me.NumeroComprobante.Width = 110
      '
      'Cantidad
      '
      Me.Cantidad.DataPropertyName = "Cantidad"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
      DataGridViewCellStyle4.Format = "N2"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle4
      Me.Cantidad.HeaderText = "Cantidad"
      Me.Cantidad.Name = "Cantidad"
      Me.Cantidad.ReadOnly = True
      Me.Cantidad.Width = 70
      '
      'IdClienteProveedor
      '
      Me.IdClienteProveedor.DataPropertyName = "IdClienteProveedor"
      Me.IdClienteProveedor.HeaderText = "IdClienteProveedor"
      Me.IdClienteProveedor.Name = "IdClienteProveedor"
      Me.IdClienteProveedor.ReadOnly = True
      Me.IdClienteProveedor.Visible = False
      Me.IdClienteProveedor.Width = 45
      '
      'CodigoClienteProveedor
      '
      Me.CodigoClienteProveedor.DataPropertyName = "CodigoClienteProveedor"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CodigoClienteProveedor.DefaultCellStyle = DataGridViewCellStyle5
      Me.CodigoClienteProveedor.HeaderText = "Codigo"
      Me.CodigoClienteProveedor.Name = "CodigoClienteProveedor"
      Me.CodigoClienteProveedor.ReadOnly = True
      Me.CodigoClienteProveedor.Width = 70
      '
      'NombreClienteProveedor
      '
      Me.NombreClienteProveedor.DataPropertyName = "NombreClienteProveedor"
      Me.NombreClienteProveedor.HeaderText = "Nombre Cliente/Proveedor"
      Me.NombreClienteProveedor.Name = "NombreClienteProveedor"
      Me.NombreClienteProveedor.ReadOnly = True
      Me.NombreClienteProveedor.Width = 170
      '
      'SucursalDeA
      '
      Me.SucursalDeA.DataPropertyName = "SucursalDeA"
      Me.SucursalDeA.HeaderText = "Sucursal De/A"
      Me.SucursalDeA.Name = "SucursalDeA"
      Me.SucursalDeA.ReadOnly = True
      Me.SucursalDeA.Width = 80
      '
      'Usuario
      '
      Me.Usuario.DataPropertyName = "Usuario"
      Me.Usuario.HeaderText = "Usuario"
      Me.Usuario.Name = "Usuario"
      Me.Usuario.ReadOnly = True
      Me.Usuario.Width = 70
      '
      'IdFormula
      '
      Me.IdFormula.DataPropertyName = "IdFormula"
      Me.IdFormula.HeaderText = "IdFormula"
      Me.IdFormula.Name = "IdFormula"
      Me.IdFormula.ReadOnly = True
      Me.IdFormula.Visible = False
      '
      'ProductoCambiarCod
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(902, 405)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.grbProducto)
      Me.Name = "ProductoCambiarCod"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Codigo de Producto"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.grbProducto.ResumeLayout(False)
      Me.grbProducto.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents grbProducto As System.Windows.Forms.GroupBox
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbActualizar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
    Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents txtStock As Eniac.Controles.TextBox
   Friend WithEvents lblStock As Eniac.Controles.Label
   Friend WithEvents txtPrecioVenta As Eniac.Controles.TextBox
   Friend WithEvents lblPrecioVenta As Eniac.Controles.Label
   Friend WithEvents txtMarcaCodigo As Eniac.Controles.TextBox
   Friend WithEvents txtMarcaNombre As Eniac.Controles.TextBox
   Friend WithEvents txtRubroCodigo As Eniac.Controles.TextBox
   Friend WithEvents txtRubroNombre As Eniac.Controles.TextBox
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents bscCodigoProducto2REC As Eniac.Controles.Buscador2
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents FechaMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdClienteProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoClienteProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreClienteProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SucursalDeA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdFormula As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
