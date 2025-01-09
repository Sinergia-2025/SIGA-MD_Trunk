<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductoCopiarCod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductoCopiarCod))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grbProducto = New System.Windows.Forms.GroupBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.lblPrefijo = New Eniac.Controles.Label()
        Me.txtPrefijo = New Eniac.Controles.TextBox()
        Me.txtUnidadDeMedida = New Eniac.Controles.TextBox()
        Me.lblUnidadDeMedida = New Eniac.Controles.Label()
        Me.txtTamanio = New Eniac.Controles.TextBox()
        Me.lblTamanio = New Eniac.Controles.Label()
        Me.chbBorraProducto = New Eniac.Controles.CheckBox()
        Me.lblCodigoInicial = New Eniac.Controles.Label()
        Me.txtCodigoInicial = New Eniac.Controles.TextBox()
        Me.lblCopias = New Eniac.Controles.Label()
        Me.txtCopias = New Eniac.Controles.TextBox()
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
        Me.txtPrecioCosto = New Eniac.Controles.TextBox()
        Me.lblPrecioCosto = New Eniac.Controles.Label()
        Me.Label4 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.CodigoProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tamanio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadDeMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGenerar = New System.Windows.Forms.ToolStripButton()
        Me.tsbActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbProducto.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbProducto
        '
        Me.grbProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbProducto.Controls.Add(Me.bscProducto2)
        Me.grbProducto.Controls.Add(Me.bscCodigoProducto2)
        Me.grbProducto.Controls.Add(Me.lblPrefijo)
        Me.grbProducto.Controls.Add(Me.txtPrefijo)
        Me.grbProducto.Controls.Add(Me.txtUnidadDeMedida)
        Me.grbProducto.Controls.Add(Me.lblUnidadDeMedida)
        Me.grbProducto.Controls.Add(Me.txtTamanio)
        Me.grbProducto.Controls.Add(Me.lblTamanio)
        Me.grbProducto.Controls.Add(Me.chbBorraProducto)
        Me.grbProducto.Controls.Add(Me.lblCodigoInicial)
        Me.grbProducto.Controls.Add(Me.txtCodigoInicial)
        Me.grbProducto.Controls.Add(Me.lblCopias)
        Me.grbProducto.Controls.Add(Me.txtCopias)
        Me.grbProducto.Controls.Add(Me.txtRubroNombre)
        Me.grbProducto.Controls.Add(Me.txtMarcaNombre)
        Me.grbProducto.Controls.Add(Me.txtRubroCodigo)
        Me.grbProducto.Controls.Add(Me.txtMarcaCodigo)
        Me.grbProducto.Controls.Add(Me.txtStock)
        Me.grbProducto.Controls.Add(Me.lblStock)
        Me.grbProducto.Controls.Add(Me.txtPrecioVenta)
        Me.grbProducto.Controls.Add(Me.lblPrecioVenta)
        Me.grbProducto.Controls.Add(Me.txtPrecioCosto)
        Me.grbProducto.Controls.Add(Me.lblPrecioCosto)
        Me.grbProducto.Controls.Add(Me.lblRubro)
        Me.grbProducto.Controls.Add(Me.lblMarca)
        Me.grbProducto.Controls.Add(Me.Label4)
        Me.grbProducto.Controls.Add(Me.Label2)
        Me.grbProducto.Controls.Add(Me.dgvDetalle)
        Me.grbProducto.Location = New System.Drawing.Point(8, 42)
        Me.grbProducto.Name = "grbProducto"
        Me.grbProducto.Size = New System.Drawing.Size(875, 400)
        Me.grbProducto.TabIndex = 0
        Me.grbProducto.TabStop = False
        Me.grbProducto.Text = "Producto Origen"
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
        Me.bscProducto2.Location = New System.Drawing.Point(136, 40)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(332, 20)
        Me.bscProducto2.TabIndex = 50
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(16, 39)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(119, 20)
        Me.bscCodigoProducto2.TabIndex = 49
        '
        'lblPrefijo
        '
        Me.lblPrefijo.AutoSize = True
        Me.lblPrefijo.Location = New System.Drawing.Point(15, 179)
        Me.lblPrefijo.Name = "lblPrefijo"
        Me.lblPrefijo.Size = New System.Drawing.Size(36, 13)
        Me.lblPrefijo.TabIndex = 6
        Me.lblPrefijo.Text = "Prefijo"
        '
        'txtPrefijo
        '
        Me.txtPrefijo.BindearPropiedadControl = Nothing
        Me.txtPrefijo.BindearPropiedadEntidad = Nothing
        Me.txtPrefijo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrefijo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrefijo.Formato = ""
        Me.txtPrefijo.IsDecimal = False
        Me.txtPrefijo.IsNumber = False
        Me.txtPrefijo.IsPK = False
        Me.txtPrefijo.IsRequired = False
        Me.txtPrefijo.Key = ""
        Me.txtPrefijo.LabelAsoc = Me.lblPrefijo
        Me.txtPrefijo.Location = New System.Drawing.Point(93, 176)
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Size = New System.Drawing.Size(80, 20)
        Me.txtPrefijo.TabIndex = 7
        '
        'txtUnidadDeMedida
        '
        Me.txtUnidadDeMedida.BindearPropiedadControl = ""
        Me.txtUnidadDeMedida.BindearPropiedadEntidad = ""
        Me.txtUnidadDeMedida.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUnidadDeMedida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUnidadDeMedida.Formato = "##0.00"
        Me.txtUnidadDeMedida.IsDecimal = False
        Me.txtUnidadDeMedida.IsNumber = False
        Me.txtUnidadDeMedida.IsPK = False
        Me.txtUnidadDeMedida.IsRequired = False
        Me.txtUnidadDeMedida.Key = ""
        Me.txtUnidadDeMedida.LabelAsoc = Me.lblUnidadDeMedida
        Me.txtUnidadDeMedida.Location = New System.Drawing.Point(280, 71)
        Me.txtUnidadDeMedida.MaxLength = 13
        Me.txtUnidadDeMedida.Name = "txtUnidadDeMedida"
        Me.txtUnidadDeMedida.ReadOnly = True
        Me.txtUnidadDeMedida.Size = New System.Drawing.Size(55, 20)
        Me.txtUnidadDeMedida.TabIndex = 21
        Me.txtUnidadDeMedida.TabStop = False
        Me.txtUnidadDeMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblUnidadDeMedida
        '
        Me.lblUnidadDeMedida.AutoSize = True
        Me.lblUnidadDeMedida.Location = New System.Drawing.Point(178, 74)
        Me.lblUnidadDeMedida.Name = "lblUnidadDeMedida"
        Me.lblUnidadDeMedida.Size = New System.Drawing.Size(94, 13)
        Me.lblUnidadDeMedida.TabIndex = 20
        Me.lblUnidadDeMedida.Text = "Unidad de Medida"
        '
        'txtTamanio
        '
        Me.txtTamanio.BindearPropiedadControl = ""
        Me.txtTamanio.BindearPropiedadEntidad = ""
        Me.txtTamanio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanio.Formato = "##0.00"
        Me.txtTamanio.IsDecimal = True
        Me.txtTamanio.IsNumber = True
        Me.txtTamanio.IsPK = False
        Me.txtTamanio.IsRequired = False
        Me.txtTamanio.Key = ""
        Me.txtTamanio.LabelAsoc = Me.lblTamanio
        Me.txtTamanio.Location = New System.Drawing.Point(68, 71)
        Me.txtTamanio.MaxLength = 13
        Me.txtTamanio.Name = "txtTamanio"
        Me.txtTamanio.ReadOnly = True
        Me.txtTamanio.Size = New System.Drawing.Size(69, 20)
        Me.txtTamanio.TabIndex = 19
        Me.txtTamanio.TabStop = False
        Me.txtTamanio.Text = "0.00"
        Me.txtTamanio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTamanio
        '
        Me.lblTamanio.AutoSize = True
        Me.lblTamanio.Location = New System.Drawing.Point(15, 74)
        Me.lblTamanio.Name = "lblTamanio"
        Me.lblTamanio.Size = New System.Drawing.Size(46, 13)
        Me.lblTamanio.TabIndex = 18
        Me.lblTamanio.Text = "Tamaño"
        '
        'chbBorraProducto
        '
        Me.chbBorraProducto.AutoSize = True
        Me.chbBorraProducto.BindearPropiedadControl = Nothing
        Me.chbBorraProducto.BindearPropiedadEntidad = Nothing
        Me.chbBorraProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBorraProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBorraProducto.IsPK = False
        Me.chbBorraProducto.IsRequired = False
        Me.chbBorraProducto.Key = Nothing
        Me.chbBorraProducto.LabelAsoc = Nothing
        Me.chbBorraProducto.Location = New System.Drawing.Point(18, 252)
        Me.chbBorraProducto.Name = "chbBorraProducto"
        Me.chbBorraProducto.Size = New System.Drawing.Size(135, 17)
        Me.chbBorraProducto.TabIndex = 10
        Me.chbBorraProducto.Text = "Borra Producto Original"
        Me.chbBorraProducto.UseVisualStyleBackColor = True
        '
        'lblCodigoInicial
        '
        Me.lblCodigoInicial.AutoSize = True
        Me.lblCodigoInicial.Location = New System.Drawing.Point(15, 203)
        Me.lblCodigoInicial.Name = "lblCodigoInicial"
        Me.lblCodigoInicial.Size = New System.Drawing.Size(70, 13)
        Me.lblCodigoInicial.TabIndex = 8
        Me.lblCodigoInicial.Text = "Codigo Inicial"
        '
        'txtCodigoInicial
        '
        Me.txtCodigoInicial.BindearPropiedadControl = Nothing
        Me.txtCodigoInicial.BindearPropiedadEntidad = Nothing
        Me.txtCodigoInicial.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoInicial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoInicial.Formato = ""
        Me.txtCodigoInicial.IsDecimal = False
        Me.txtCodigoInicial.IsNumber = True
        Me.txtCodigoInicial.IsPK = False
        Me.txtCodigoInicial.IsRequired = True
        Me.txtCodigoInicial.Key = ""
        Me.txtCodigoInicial.LabelAsoc = Me.lblCodigoInicial
        Me.txtCodigoInicial.Location = New System.Drawing.Point(93, 200)
        Me.txtCodigoInicial.Name = "txtCodigoInicial"
        Me.txtCodigoInicial.Size = New System.Drawing.Size(108, 20)
        Me.txtCodigoInicial.TabIndex = 9
        '
        'lblCopias
        '
        Me.lblCopias.AutoSize = True
        Me.lblCopias.Location = New System.Drawing.Point(15, 129)
        Me.lblCopias.Name = "lblCopias"
        Me.lblCopias.Size = New System.Drawing.Size(39, 13)
        Me.lblCopias.TabIndex = 4
        Me.lblCopias.Text = "Copias"
        '
        'txtCopias
        '
        Me.txtCopias.BindearPropiedadControl = Nothing
        Me.txtCopias.BindearPropiedadEntidad = Nothing
        Me.txtCopias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCopias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCopias.Formato = ""
        Me.txtCopias.IsDecimal = False
        Me.txtCopias.IsNumber = True
        Me.txtCopias.IsPK = False
        Me.txtCopias.IsRequired = True
        Me.txtCopias.Key = ""
        Me.txtCopias.LabelAsoc = Me.lblCopias
        Me.txtCopias.Location = New System.Drawing.Point(105, 126)
        Me.txtCopias.Name = "txtCopias"
        Me.txtCopias.Size = New System.Drawing.Size(68, 20)
        Me.txtCopias.TabIndex = 5
        Me.txtCopias.Text = "0"
        Me.txtCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtRubroNombre.Location = New System.Drawing.Point(601, 44)
        Me.txtRubroNombre.MaxLength = 13
        Me.txtRubroNombre.Name = "txtRubroNombre"
        Me.txtRubroNombre.ReadOnly = True
        Me.txtRubroNombre.Size = New System.Drawing.Size(266, 20)
        Me.txtRubroNombre.TabIndex = 17
        Me.txtRubroNombre.TabStop = False
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Location = New System.Drawing.Point(474, 47)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 15
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
        Me.txtMarcaNombre.Location = New System.Drawing.Point(601, 16)
        Me.txtMarcaNombre.MaxLength = 13
        Me.txtMarcaNombre.Name = "txtMarcaNombre"
        Me.txtMarcaNombre.ReadOnly = True
        Me.txtMarcaNombre.Size = New System.Drawing.Size(266, 20)
        Me.txtMarcaNombre.TabIndex = 14
        Me.txtMarcaNombre.TabStop = False
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(474, 20)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 12
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
        Me.txtRubroCodigo.Location = New System.Drawing.Point(519, 44)
        Me.txtRubroCodigo.MaxLength = 13
        Me.txtRubroCodigo.Name = "txtRubroCodigo"
        Me.txtRubroCodigo.ReadOnly = True
        Me.txtRubroCodigo.Size = New System.Drawing.Size(72, 20)
        Me.txtRubroCodigo.TabIndex = 16
        Me.txtRubroCodigo.TabStop = False
        Me.txtRubroCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtMarcaCodigo.Location = New System.Drawing.Point(519, 16)
        Me.txtMarcaCodigo.MaxLength = 13
        Me.txtMarcaCodigo.Name = "txtMarcaCodigo"
        Me.txtMarcaCodigo.ReadOnly = True
        Me.txtMarcaCodigo.Size = New System.Drawing.Size(72, 20)
        Me.txtMarcaCodigo.TabIndex = 13
        Me.txtMarcaCodigo.TabStop = False
        Me.txtMarcaCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtStock.Size = New System.Drawing.Size(88, 20)
        Me.txtStock.TabIndex = 27
        Me.txtStock.TabStop = False
        Me.txtStock.Text = "0.00"
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Location = New System.Drawing.Point(730, 73)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(35, 13)
        Me.lblStock.TabIndex = 26
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
        Me.txtPrecioVenta.Size = New System.Drawing.Size(88, 20)
        Me.txtPrecioVenta.TabIndex = 25
        Me.txtPrecioVenta.TabStop = False
        Me.txtPrecioVenta.Text = "0.00"
        Me.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioVenta
        '
        Me.lblPrecioVenta.AutoSize = True
        Me.lblPrecioVenta.Location = New System.Drawing.Point(545, 73)
        Me.lblPrecioVenta.Name = "lblPrecioVenta"
        Me.lblPrecioVenta.Size = New System.Drawing.Size(68, 13)
        Me.lblPrecioVenta.TabIndex = 24
        Me.lblPrecioVenta.Text = "Precio Venta"
        '
        'txtPrecioCosto
        '
        Me.txtPrecioCosto.BindearPropiedadControl = ""
        Me.txtPrecioCosto.BindearPropiedadEntidad = ""
        Me.txtPrecioCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioCosto.Formato = "##0.00"
        Me.txtPrecioCosto.IsDecimal = True
        Me.txtPrecioCosto.IsNumber = True
        Me.txtPrecioCosto.IsPK = False
        Me.txtPrecioCosto.IsRequired = False
        Me.txtPrecioCosto.Key = ""
        Me.txtPrecioCosto.LabelAsoc = Me.lblPrecioCosto
        Me.txtPrecioCosto.Location = New System.Drawing.Point(431, 71)
        Me.txtPrecioCosto.MaxLength = 13
        Me.txtPrecioCosto.Name = "txtPrecioCosto"
        Me.txtPrecioCosto.ReadOnly = True
        Me.txtPrecioCosto.Size = New System.Drawing.Size(88, 20)
        Me.txtPrecioCosto.TabIndex = 23
        Me.txtPrecioCosto.TabStop = False
        Me.txtPrecioCosto.Text = "0.00"
        Me.txtPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioCosto
        '
        Me.lblPrecioCosto.AutoSize = True
        Me.lblPrecioCosto.Location = New System.Drawing.Point(359, 74)
        Me.lblPrecioCosto.Name = "lblPrecioCosto"
        Me.lblPrecioCosto.Size = New System.Drawing.Size(67, 13)
        Me.lblPrecioCosto.TabIndex = 22
        Me.lblPrecioCosto.Text = "Precio Costo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(150, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoProducto, Me.NombreProducto, Me.Tamanio, Me.UnidadDeMedida})
        Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDetalle.Location = New System.Drawing.Point(217, 98)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersWidth = 15
        Me.dgvDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(646, 292)
        Me.dgvDetalle.TabIndex = 11
        '
        'CodigoProducto
        '
        Me.CodigoProducto.DataPropertyName = "CodigoProducto"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CodigoProducto.DefaultCellStyle = DataGridViewCellStyle1
        Me.CodigoProducto.HeaderText = "Codigo"
        Me.CodigoProducto.Name = "CodigoProducto"
        Me.CodigoProducto.Width = 130
        '
        'NombreProducto
        '
        Me.NombreProducto.DataPropertyName = "NombreProducto"
        Me.NombreProducto.HeaderText = "Nombre Producto"
        Me.NombreProducto.Name = "NombreProducto"
        Me.NombreProducto.Width = 390
        '
        'Tamanio
        '
        Me.Tamanio.DataPropertyName = "Tamanio"
        Me.Tamanio.HeaderText = "Tamaño"
        Me.Tamanio.Name = "Tamanio"
        Me.Tamanio.Width = 50
        '
        'UnidadDeMedida
        '
        Me.UnidadDeMedida.DataPropertyName = "UnidadDeMedida"
        Me.UnidadDeMedida.HeaderText = "U.M."
        Me.UnidadDeMedida.Name = "UnidadDeMedida"
        Me.UnidadDeMedida.Width = 40
        '
        'tstBarra
        '
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbGenerar, Me.tsbActualizar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(895, 29)
        Me.tstBarra.TabIndex = 1
        Me.tstBarra.Text = "ToolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'tsbGenerar
        '
        Me.tsbGenerar.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
        Me.tsbGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerar.Name = "tsbGenerar"
        Me.tsbGenerar.Size = New System.Drawing.Size(74, 26)
        Me.tsbGenerar.Text = "&Generar"
        Me.tsbGenerar.ToolTipText = "Generar los Productos"
        '
        'tsbActualizar
        '
        Me.tsbActualizar.Image = Global.Eniac.Win.My.Resources.Resources.check2
        Me.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbActualizar.Name = "tsbActualizar"
        Me.tsbActualizar.Size = New System.Drawing.Size(85, 26)
        Me.tsbActualizar.Text = "&Actualizar"
        Me.tsbActualizar.ToolTipText = "Actualizar los productos"
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
        Me.tsbSalir.ToolTipText = "Cerrar el formulario de Tareas"
        '
        'ProductoCopiarCod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 454)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbProducto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ProductoCopiarCod"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar Codigo de Producto"
        Me.grbProducto.ResumeLayout(False)
        Me.grbProducto.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents grbProducto As System.Windows.Forms.GroupBox
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbActualizar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
    Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents txtStock As Eniac.Controles.TextBox
   Friend WithEvents lblStock As Eniac.Controles.Label
   Friend WithEvents txtPrecioVenta As Eniac.Controles.TextBox
   Friend WithEvents lblPrecioVenta As Eniac.Controles.Label
   Friend WithEvents txtPrecioCosto As Eniac.Controles.TextBox
   Friend WithEvents lblPrecioCosto As Eniac.Controles.Label
   Friend WithEvents txtMarcaCodigo As Eniac.Controles.TextBox
   Friend WithEvents txtMarcaNombre As Eniac.Controles.TextBox
   Friend WithEvents txtRubroCodigo As Eniac.Controles.TextBox
   Friend WithEvents txtRubroNombre As Eniac.Controles.TextBox
   Friend WithEvents lblCopias As Eniac.Controles.Label
   Friend WithEvents txtCopias As Eniac.Controles.TextBox
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblCodigoInicial As Eniac.Controles.Label
   Friend WithEvents txtCodigoInicial As Eniac.Controles.TextBox
   Friend WithEvents chbBorraProducto As Eniac.Controles.CheckBox
   Friend WithEvents tsbGenerar As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtTamanio As Eniac.Controles.TextBox
   Friend WithEvents lblTamanio As Eniac.Controles.Label
   Friend WithEvents txtUnidadDeMedida As Eniac.Controles.TextBox
   Friend WithEvents lblUnidadDeMedida As Eniac.Controles.Label
   Friend WithEvents CodigoProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Tamanio As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents UnidadDeMedida As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblPrefijo As Eniac.Controles.Label
    Friend WithEvents txtPrefijo As Eniac.Controles.TextBox
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
End Class
