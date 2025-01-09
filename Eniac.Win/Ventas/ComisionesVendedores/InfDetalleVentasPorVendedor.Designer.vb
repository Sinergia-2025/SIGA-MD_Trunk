<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfDetalleVentasPorVendedor
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
   '<System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.chbConIVA = New Eniac.Controles.CheckBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chbSubRubro = New Eniac.Controles.CheckBox()
      Me.cmbSubRubro = New Eniac.Controles.ComboBox()
      Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
      Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
      Me.cmbConComision = New Eniac.Controles.ComboBox()
      Me.lblConComision = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.lblVendedor = New Eniac.Controles.Label()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.chbRubro = New Eniac.Controles.CheckBox()
      Me.cmbRubro = New Eniac.Controles.ComboBox()
      Me.chbMarca = New Eniac.Controles.CheckBox()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.cmbMarca = New Eniac.Controles.ComboBox()
      Me.chbMesCompleto = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.lblTotales = New Eniac.Controles.Label()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.txtTotalComision = New Eniac.Controles.TextBox()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescripcionAbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTotalNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PorcComision = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Comision = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbConsultar.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbConsultar
      '
      Me.grbConsultar.Controls.Add(Me.chbConIVA)
      Me.grbConsultar.Controls.Add(Me.bscProducto2)
      Me.grbConsultar.Controls.Add(Me.bscCodigoProducto2)
      Me.grbConsultar.Controls.Add(Me.dtpHasta)
      Me.grbConsultar.Controls.Add(Me.dtpDesde)
      Me.grbConsultar.Controls.Add(Me.lblHasta)
      Me.grbConsultar.Controls.Add(Me.lblDesde)
      Me.grbConsultar.Controls.Add(Me.chbSubRubro)
      Me.grbConsultar.Controls.Add(Me.cmbSubRubro)
      Me.grbConsultar.Controls.Add(Me.chbZonaGeografica)
      Me.grbConsultar.Controls.Add(Me.cmbZonaGeografica)
      Me.grbConsultar.Controls.Add(Me.cmbConComision)
      Me.grbConsultar.Controls.Add(Me.lblConComision)
      Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.bscCliente)
      Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.lblNombre)
      Me.grbConsultar.Controls.Add(Me.chbCliente)
      Me.grbConsultar.Controls.Add(Me.lblVendedor)
      Me.grbConsultar.Controls.Add(Me.cmbVendedor)
      Me.grbConsultar.Controls.Add(Me.chbRubro)
      Me.grbConsultar.Controls.Add(Me.cmbRubro)
      Me.grbConsultar.Controls.Add(Me.chbMarca)
      Me.grbConsultar.Controls.Add(Me.chbProducto)
      Me.grbConsultar.Controls.Add(Me.cmbMarca)
      Me.grbConsultar.Controls.Add(Me.chbMesCompleto)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(1081, 129)
      Me.grbConsultar.TabIndex = 0
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'chbConIVA
      '
      Me.chbConIVA.AutoSize = True
      Me.chbConIVA.BindearPropiedadControl = Nothing
      Me.chbConIVA.BindearPropiedadEntidad = Nothing
      Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConIVA.IsPK = False
      Me.chbConIVA.IsRequired = False
      Me.chbConIVA.Key = Nothing
      Me.chbConIVA.LabelAsoc = Nothing
      Me.chbConIVA.Location = New System.Drawing.Point(747, 62)
      Me.chbConIVA.Name = "chbConIVA"
      Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
      Me.chbConIVA.TabIndex = 97
      Me.chbConIVA.Text = "Con IVA"
      Me.chbConIVA.UseVisualStyleBackColor = True
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
      Me.bscProducto2.Location = New System.Drawing.Point(225, 96)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(306, 20)
      Me.bscProducto2.TabIndex = 96
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
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(77, 96)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
      Me.bscCodigoProducto2.TabIndex = 95
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(320, 20)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 94
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(283, 24)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 93
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(155, 20)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 92
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(111, 24)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 91
      Me.lblDesde.Text = "Desde"
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
      Me.chbSubRubro.Location = New System.Drawing.Point(747, 99)
      Me.chbSubRubro.Name = "chbSubRubro"
      Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
      Me.chbSubRubro.TabIndex = 79
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
      Me.cmbSubRubro.Location = New System.Drawing.Point(822, 97)
      Me.cmbSubRubro.Name = "cmbSubRubro"
      Me.cmbSubRubro.Size = New System.Drawing.Size(143, 21)
      Me.cmbSubRubro.TabIndex = 80
      '
      'chbZonaGeografica
      '
      Me.chbZonaGeografica.AutoSize = True
      Me.chbZonaGeografica.BindearPropiedadControl = Nothing
      Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbZonaGeografica.IsPK = False
      Me.chbZonaGeografica.IsRequired = False
      Me.chbZonaGeografica.Key = Nothing
      Me.chbZonaGeografica.LabelAsoc = Nothing
      Me.chbZonaGeografica.Location = New System.Drawing.Point(855, 23)
      Me.chbZonaGeografica.Name = "chbZonaGeografica"
      Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
      Me.chbZonaGeografica.TabIndex = 77
      Me.chbZonaGeografica.Text = "Zona Geográfica"
      Me.chbZonaGeografica.UseVisualStyleBackColor = True
      '
      'cmbZonaGeografica
      '
      Me.cmbZonaGeografica.BindearPropiedadControl = Nothing
      Me.cmbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbZonaGeografica.Enabled = False
      Me.cmbZonaGeografica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbZonaGeografica.FormattingEnabled = True
      Me.cmbZonaGeografica.IsPK = False
      Me.cmbZonaGeografica.IsRequired = False
      Me.cmbZonaGeografica.Key = Nothing
      Me.cmbZonaGeografica.LabelAsoc = Nothing
      Me.cmbZonaGeografica.Location = New System.Drawing.Point(961, 19)
      Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
      Me.cmbZonaGeografica.Size = New System.Drawing.Size(112, 21)
      Me.cmbZonaGeografica.TabIndex = 78
      '
      'cmbConComision
      '
      Me.cmbConComision.BindearPropiedadControl = Nothing
      Me.cmbConComision.BindearPropiedadEntidad = Nothing
      Me.cmbConComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbConComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbConComision.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbConComision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbConComision.FormattingEnabled = True
      Me.cmbConComision.IsPK = False
      Me.cmbConComision.IsRequired = False
      Me.cmbConComision.Key = Nothing
      Me.cmbConComision.LabelAsoc = Me.lblConComision
      Me.cmbConComision.Location = New System.Drawing.Point(767, 20)
      Me.cmbConComision.Name = "cmbConComision"
      Me.cmbConComision.Size = New System.Drawing.Size(70, 21)
      Me.cmbConComision.TabIndex = 4
      Me.cmbConComision.TabStop = False
      '
      'lblConComision
      '
      Me.lblConComision.AutoSize = True
      Me.lblConComision.LabelAsoc = Nothing
      Me.lblConComision.Location = New System.Drawing.Point(691, 23)
      Me.lblConComision.Name = "lblConComision"
      Me.lblConComision.Size = New System.Drawing.Size(71, 13)
      Me.lblConComision.TabIndex = 67
      Me.lblConComision.Text = "Con Comision"
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(76, 64)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 7
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(73, 48)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 66
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
      Me.bscCliente.Location = New System.Drawing.Point(173, 62)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 8
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(170, 46)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 64
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
      Me.chbCliente.Location = New System.Drawing.Point(12, 62)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 5
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'lblVendedor
      '
      Me.lblVendedor.AutoSize = True
      Me.lblVendedor.LabelAsoc = Nothing
      Me.lblVendedor.Location = New System.Drawing.Point(447, 23)
      Me.lblVendedor.Name = "lblVendedor"
      Me.lblVendedor.Size = New System.Drawing.Size(53, 13)
      Me.lblVendedor.TabIndex = 59
      Me.lblVendedor.Text = "Vendedor"
      '
      'cmbVendedor
      '
      Me.cmbVendedor.BindearPropiedadControl = Nothing
      Me.cmbVendedor.BindearPropiedadEntidad = Nothing
      Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedor.FormattingEnabled = True
      Me.cmbVendedor.IsPK = False
      Me.cmbVendedor.IsRequired = False
      Me.cmbVendedor.Key = Nothing
      Me.cmbVendedor.LabelAsoc = Nothing
      Me.cmbVendedor.Location = New System.Drawing.Point(505, 20)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(177, 21)
      Me.cmbVendedor.TabIndex = 3
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
      Me.chbRubro.Location = New System.Drawing.Point(543, 97)
      Me.chbRubro.Name = "chbRubro"
      Me.chbRubro.Size = New System.Drawing.Size(55, 17)
      Me.chbRubro.TabIndex = 8
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
      Me.cmbRubro.Location = New System.Drawing.Point(599, 95)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(137, 21)
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
      Me.chbMarca.Location = New System.Drawing.Point(543, 62)
      Me.chbMarca.Name = "chbMarca"
      Me.chbMarca.Size = New System.Drawing.Size(56, 17)
      Me.chbMarca.TabIndex = 6
      Me.chbMarca.Text = "Marca"
      Me.chbMarca.UseVisualStyleBackColor = True
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
      Me.chbProducto.Location = New System.Drawing.Point(13, 96)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 9
      Me.chbProducto.Text = "Producto"
      Me.chbProducto.UseVisualStyleBackColor = True
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
      Me.cmbMarca.Location = New System.Drawing.Point(600, 60)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(136, 21)
      Me.cmbMarca.TabIndex = 12
      '
      'chbMesCompleto
      '
      Me.chbMesCompleto.AutoSize = True
      Me.chbMesCompleto.BindearPropiedadControl = Nothing
      Me.chbMesCompleto.BindearPropiedadEntidad = Nothing
      Me.chbMesCompleto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMesCompleto.IsPK = False
      Me.chbMesCompleto.IsRequired = False
      Me.chbMesCompleto.Key = Nothing
      Me.chbMesCompleto.LabelAsoc = Nothing
      Me.chbMesCompleto.Location = New System.Drawing.Point(13, 22)
      Me.chbMesCompleto.Name = "chbMesCompleto"
      Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chbMesCompleto.TabIndex = 0
      Me.chbMesCompleto.Text = "Mes Completo"
      Me.chbMesCompleto.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(975, 78)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 14
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1111, 29)
      Me.tstBarra.TabIndex = 4
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
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.IdCliente, Me.IdVendedor, Me.DescripcionAbrev, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.FormaPago, Me.TipoDocCliente, Me.NroDocCliente, Me.NombreCliente, Me.IdProducto, Me.NombreProducto, Me.Cantidad, Me.NombreMarca, Me.NombreRubro, Me.ImporteTotalNeto, Me.PorcComision, Me.Comision})
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 167)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersWidth = 15
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(1081, 342)
      Me.dgvDetalle.TabIndex = 0
      '
      'lblTotales
      '
      Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotales.AutoSize = True
      Me.lblTotales.LabelAsoc = Nothing
      Me.lblTotales.Location = New System.Drawing.Point(825, 512)
      Me.lblTotales.Name = "lblTotales"
      Me.lblTotales.Size = New System.Drawing.Size(45, 13)
      Me.lblTotales.TabIndex = 28
      Me.lblTotales.Text = "Totales:"
      '
      'txtTotal
      '
      Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotal.BindearPropiedadControl = Nothing
      Me.txtTotal.BindearPropiedadEntidad = Nothing
      Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotal.Formato = "##0.00"
      Me.txtTotal.IsDecimal = True
      Me.txtTotal.IsNumber = True
      Me.txtTotal.IsPK = False
      Me.txtTotal.IsRequired = False
      Me.txtTotal.Key = ""
      Me.txtTotal.LabelAsoc = Nothing
      Me.txtTotal.Location = New System.Drawing.Point(874, 509)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.txtTotal.Size = New System.Drawing.Size(101, 20)
      Me.txtTotal.TabIndex = 27
      Me.txtTotal.Text = "0.00"
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalComision
      '
      Me.txtTotalComision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalComision.BindearPropiedadControl = Nothing
      Me.txtTotalComision.BindearPropiedadEntidad = Nothing
      Me.txtTotalComision.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalComision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalComision.Formato = "##0.00"
      Me.txtTotalComision.IsDecimal = True
      Me.txtTotalComision.IsNumber = True
      Me.txtTotalComision.IsPK = False
      Me.txtTotalComision.IsRequired = False
      Me.txtTotalComision.Key = ""
      Me.txtTotalComision.LabelAsoc = Nothing
      Me.txtTotalComision.Location = New System.Drawing.Point(975, 509)
      Me.txtTotalComision.Name = "txtTotalComision"
      Me.txtTotalComision.ReadOnly = True
      Me.txtTotalComision.Size = New System.Drawing.Size(99, 20)
      Me.txtTotalComision.TabIndex = 26
      Me.txtTotalComision.Text = "0.00"
      Me.txtTotalComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm"
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle1
      Me.Fecha.HeaderText = "Fecha"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.ReadOnly = True
      '
      'IdCliente
      '
      Me.IdCliente.DataPropertyName = "IdCliente"
      Me.IdCliente.HeaderText = "IdCliente"
      Me.IdCliente.Name = "IdCliente"
      Me.IdCliente.ReadOnly = True
      Me.IdCliente.Visible = False
      '
      'IdVendedor
      '
      Me.IdVendedor.DataPropertyName = "IdVendedor"
      Me.IdVendedor.HeaderText = "IdVendedor"
      Me.IdVendedor.Name = "IdVendedor"
      Me.IdVendedor.ReadOnly = True
      Me.IdVendedor.Visible = False
      '
      'DescripcionAbrev
      '
      Me.DescripcionAbrev.DataPropertyName = "DescripcionAbrev"
      Me.DescripcionAbrev.HeaderText = "Tipo Comprob."
      Me.DescripcionAbrev.Name = "DescripcionAbrev"
      Me.DescripcionAbrev.ReadOnly = True
      Me.DescripcionAbrev.Width = 80
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
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
      Me.CentroEmisor.HeaderText = "E."
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.ReadOnly = True
      Me.CentroEmisor.Width = 30
      '
      'NumeroComprobante
      '
      Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle4
      Me.NumeroComprobante.HeaderText = "Numero"
      Me.NumeroComprobante.Name = "NumeroComprobante"
      Me.NumeroComprobante.ReadOnly = True
      Me.NumeroComprobante.Width = 70
      '
      'FormaPago
      '
      Me.FormaPago.DataPropertyName = "FormaPago"
      Me.FormaPago.HeaderText = "FormaPago"
      Me.FormaPago.Name = "FormaPago"
      Me.FormaPago.ReadOnly = True
      Me.FormaPago.Visible = False
      '
      'TipoDocCliente
      '
      Me.TipoDocCliente.DataPropertyName = "TipoDocCliente"
      Me.TipoDocCliente.HeaderText = "T.Doc."
      Me.TipoDocCliente.Name = "TipoDocCliente"
      Me.TipoDocCliente.ReadOnly = True
      Me.TipoDocCliente.Visible = False
      Me.TipoDocCliente.Width = 45
      '
      'NroDocCliente
      '
      Me.NroDocCliente.DataPropertyName = "NroDocCliente"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroDocCliente.DefaultCellStyle = DataGridViewCellStyle5
      Me.NroDocCliente.HeaderText = "Nro. Doc."
      Me.NroDocCliente.Name = "NroDocCliente"
      Me.NroDocCliente.ReadOnly = True
      Me.NroDocCliente.Visible = False
      '
      'NombreCliente
      '
      Me.NombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "Nombre Cliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      '
      'IdProducto
      '
      Me.IdProducto.DataPropertyName = "IdProducto"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdProducto.DefaultCellStyle = DataGridViewCellStyle6
      Me.IdProducto.HeaderText = "Producto"
      Me.IdProducto.Name = "IdProducto"
      Me.IdProducto.ReadOnly = True
      Me.IdProducto.Visible = False
      Me.IdProducto.Width = 120
      '
      'NombreProducto
      '
      Me.NombreProducto.DataPropertyName = "NombreProducto"
      Me.NombreProducto.HeaderText = "Producto"
      Me.NombreProducto.Name = "NombreProducto"
      Me.NombreProducto.ReadOnly = True
      Me.NombreProducto.Width = 170
      '
      'Cantidad
      '
      Me.Cantidad.DataPropertyName = "Cantidad"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
      DataGridViewCellStyle7.Format = "N2"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle7
      Me.Cantidad.HeaderText = "Cant."
      Me.Cantidad.Name = "Cantidad"
      Me.Cantidad.ReadOnly = True
      Me.Cantidad.Width = 70
      '
      'NombreMarca
      '
      Me.NombreMarca.DataPropertyName = "NombreMarca"
      Me.NombreMarca.HeaderText = "Marca"
      Me.NombreMarca.Name = "NombreMarca"
      Me.NombreMarca.ReadOnly = True
      Me.NombreMarca.Width = 140
      '
      'NombreRubro
      '
      Me.NombreRubro.DataPropertyName = "NombreRubro"
      Me.NombreRubro.HeaderText = "Rubro"
      Me.NombreRubro.Name = "NombreRubro"
      Me.NombreRubro.ReadOnly = True
      Me.NombreRubro.Visible = False
      Me.NombreRubro.Width = 150
      '
      'ImporteTotalNeto
      '
      Me.ImporteTotalNeto.DataPropertyName = "ImporteTotalNeto"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.ImporteTotalNeto.DefaultCellStyle = DataGridViewCellStyle8
      Me.ImporteTotalNeto.HeaderText = "Importe Neto"
      Me.ImporteTotalNeto.Name = "ImporteTotalNeto"
      Me.ImporteTotalNeto.ReadOnly = True
      Me.ImporteTotalNeto.Width = 80
      '
      'PorcComision
      '
      Me.PorcComision.DataPropertyName = "PorcComision"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "N2"
      Me.PorcComision.DefaultCellStyle = DataGridViewCellStyle9
      Me.PorcComision.HeaderText = "Porc."
      Me.PorcComision.Name = "PorcComision"
      Me.PorcComision.ReadOnly = True
      Me.PorcComision.Width = 45
      '
      'Comision
      '
      Me.Comision.DataPropertyName = "Comision"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle10.Format = "N2"
      Me.Comision.DefaultCellStyle = DataGridViewCellStyle10
      Me.Comision.HeaderText = "Comision"
      Me.Comision.Name = "Comision"
      Me.Comision.ReadOnly = True
      Me.Comision.Width = 70
      '
      'InfDetalleVentasPorVendedor
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1111, 538)
      Me.Controls.Add(Me.lblTotales)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.txtTotalComision)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbConsultar)
      Me.KeyPreview = True
      Me.Name = "InfDetalleVentasPorVendedor"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Comisiones Detalladas por Productos"
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents txtTotalComision As Eniac.Controles.TextBox
   Friend WithEvents lblVendedor As Eniac.Controles.Label
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents cmbConComision As Eniac.Controles.ComboBox
   Friend WithEvents lblConComision As Eniac.Controles.Label
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescripcionAbrev As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FormaPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotalNeto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PorcComision As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Comision As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
