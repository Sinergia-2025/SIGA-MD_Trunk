<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadisticaDeVentasClientes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadisticaDeVentasClientes))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImporte")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
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
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
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
      'tsbPreferencias
      '
      Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
      Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPreferencias.Name = "tsbPreferencias"
      Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
      Me.tsbPreferencias.Text = "&Preferencias"
      Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.cmbVendedor)
      Me.GroupBox1.Controls.Add(Me.chbVendedor)
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
      Me.cmbVendedor.LabelAsoc = Me.chbVendedor
      Me.cmbVendedor.Location = New System.Drawing.Point(491, 56)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(164, 21)
      Me.cmbVendedor.TabIndex = 9
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
      Me.chbVendedor.Location = New System.Drawing.Point(420, 58)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 8
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ConfigBuscador = Nothing
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
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(306, 20)
      Me.bscProducto2.TabIndex = 20
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
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
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
      Me.bscCodigoProducto2.TabIndex = 19
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
      Me.chbProducto.TabIndex = 18
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
      Me.chbModelo.TabIndex = 14
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
      Me.cmbModelo.TabIndex = 15
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
      Me.chbSubRubro.TabIndex = 16
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
      Me.cmbSubRubro.TabIndex = 17
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
      Me.chbRubro.TabIndex = 12
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
      Me.cmbRubro.TabIndex = 13
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
      Me.chbMarca.TabIndex = 10
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
      Me.cmbMarca.TabIndex = 11
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
      Me.txtCantidad.Location = New System.Drawing.Point(367, 55)
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
      Me.lblCantidad.LabelAsoc = Nothing
      Me.lblCantidad.Location = New System.Drawing.Point(201, 58)
      Me.lblCantidad.Name = "lblCantidad"
      Me.lblCantidad.Size = New System.Drawing.Size(150, 13)
      Me.lblCantidad.TabIndex = 6
      Me.lblCantidad.Text = "Cantidad de Clientes a mostrar"
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(570, 112)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 21
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
      Me.lblHasta.LabelAsoc = Nothing
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
      Me.lblDesde.LabelAsoc = Nothing
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
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn6.Header.VisiblePosition = 0
      UltraGridColumn6.Hidden = True
      UltraGridColumn7.Header.Caption = "Código"
      UltraGridColumn7.Header.VisiblePosition = 1
      UltraGridColumn8.Header.Caption = "Nombre Cliente"
      UltraGridColumn8.Header.VisiblePosition = 2
      UltraGridColumn8.Width = 398
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance2
      UltraGridColumn4.Format = "N2"
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn4.Header.Appearance = Appearance3
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 94
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance4
      UltraGridColumn1.Format = "N2"
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn1.Header.Appearance = Appearance5
      UltraGridColumn1.Header.Caption = "% Importe"
      UltraGridColumn1.Header.VisiblePosition = 4
      UltraGridColumn1.Width = 80
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn4, UltraGridColumn1})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance6.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance6
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance8.BackColor2 = System.Drawing.SystemColors.Control
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance9
      Appearance10.BackColor = System.Drawing.SystemColors.Highlight
      Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance11
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance13.BackColor = System.Drawing.SystemColors.Control
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(8, 221)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(676, 326)
      Me.ugDetalle.TabIndex = 18
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 550)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(693, 22)
      Me.stsStado.TabIndex = 19
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(614, 17)
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
      'EstadisticaDeVentasClientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(693, 572)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "EstadisticaDeVentasClientes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Estadística de Ventas por Clientes"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
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
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
End Class
