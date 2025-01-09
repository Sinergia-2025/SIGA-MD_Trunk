<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfKilosCompMarcasPorCliente
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfKilosCompMarcasPorCliente))
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
        Me.chbMarca4 = New Eniac.Controles.CheckBox()
        Me.chbMarca5 = New Eniac.Controles.CheckBox()
        Me.cmbMarca5 = New Eniac.Controles.ComboBox()
        Me.cmbMarca4 = New Eniac.Controles.ComboBox()
        Me.lblMarca1 = New Eniac.Controles.Label()
        Me.chbMarca3 = New Eniac.Controles.CheckBox()
        Me.cmbMarca3 = New Eniac.Controles.ComboBox()
        Me.cmbMarca2 = New Eniac.Controles.ComboBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.cmbMarca1 = New Eniac.Controles.ComboBox()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblTotal = New Eniac.Controles.Label()
        Me.txtTotalKilos = New Eniac.Controles.TextBox()
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcMarca1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcMarca2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcMarca3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcMarca4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcMarca5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Promedio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbConsultar.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.cmbSucursal)
        Me.grbConsultar.Controls.Add(Me.lblSucursal)
        Me.grbConsultar.Controls.Add(Me.chbLocalidad)
        Me.grbConsultar.Controls.Add(Me.bscCodigoLocalidad)
        Me.grbConsultar.Controls.Add(Me.bscNombreLocalidad)
        Me.grbConsultar.Controls.Add(Me.chbMarca4)
        Me.grbConsultar.Controls.Add(Me.chbMarca5)
        Me.grbConsultar.Controls.Add(Me.cmbMarca5)
        Me.grbConsultar.Controls.Add(Me.cmbMarca4)
        Me.grbConsultar.Controls.Add(Me.lblMarca1)
        Me.grbConsultar.Controls.Add(Me.chbMarca3)
        Me.grbConsultar.Controls.Add(Me.cmbMarca3)
        Me.grbConsultar.Controls.Add(Me.cmbMarca2)
        Me.grbConsultar.Controls.Add(Me.chbRubro)
        Me.grbConsultar.Controls.Add(Me.cmbRubro)
        Me.grbConsultar.Controls.Add(Me.cmbMarca1)
        Me.grbConsultar.Controls.Add(Me.chbZonaGeografica)
        Me.grbConsultar.Controls.Add(Me.cmbZonaGeografica)
        Me.grbConsultar.Controls.Add(Me.chbVendedor)
        Me.grbConsultar.Controls.Add(Me.cmbVendedor)
        Me.grbConsultar.Controls.Add(Me.chbCliente)
        Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.bscCliente)
        Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.lblNombre)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(855, 225)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(106, 19)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(52, 22)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'chbLocalidad
        '
        Me.chbLocalidad.AutoSize = True
        Me.chbLocalidad.BindearPropiedadControl = Nothing
        Me.chbLocalidad.BindearPropiedadEntidad = Nothing
        Me.chbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLocalidad.IsPK = False
        Me.chbLocalidad.IsRequired = False
        Me.chbLocalidad.Key = Nothing
        Me.chbLocalidad.LabelAsoc = Nothing
        Me.chbLocalidad.Location = New System.Drawing.Point(15, 186)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 27
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.AyudaAncho = 140
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidad"
        Me.bscCodigoLocalidad.ColumnasAlineacion = Nothing
        Me.bscCodigoLocalidad.ColumnasAncho = Nothing
        Me.bscCodigoLocalidad.ColumnasFormato = Nothing
        Me.bscCodigoLocalidad.ColumnasOcultas = Nothing
        Me.bscCodigoLocalidad.ColumnasTitulos = Nothing
        Me.bscCodigoLocalidad.Datos = Nothing
        Me.bscCodigoLocalidad.FilaDevuelta = Nothing
        Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoLocalidad.IsDecimal = False
        Me.bscCodigoLocalidad.IsNumber = False
        Me.bscCodigoLocalidad.IsPK = False
        Me.bscCodigoLocalidad.IsRequired = False
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Nothing
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(93, 183)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = False
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(97, 20)
        Me.bscCodigoLocalidad.TabIndex = 28
        Me.bscCodigoLocalidad.Titulo = Nothing
        '
        'bscNombreLocalidad
        '
        Me.bscNombreLocalidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscNombreLocalidad.AyudaAncho = 140
        Me.bscNombreLocalidad.BindearPropiedadControl = Nothing
        Me.bscNombreLocalidad.BindearPropiedadEntidad = Nothing
        Me.bscNombreLocalidad.ColumnasAlineacion = Nothing
        Me.bscNombreLocalidad.ColumnasAncho = Nothing
        Me.bscNombreLocalidad.ColumnasFormato = Nothing
        Me.bscNombreLocalidad.ColumnasOcultas = Nothing
        Me.bscNombreLocalidad.ColumnasTitulos = Nothing
        Me.bscNombreLocalidad.Datos = Nothing
        Me.bscNombreLocalidad.FilaDevuelta = Nothing
        Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreLocalidad.IsDecimal = False
        Me.bscNombreLocalidad.IsNumber = False
        Me.bscNombreLocalidad.IsPK = False
        Me.bscNombreLocalidad.IsRequired = False
        Me.bscNombreLocalidad.Key = ""
        Me.bscNombreLocalidad.LabelAsoc = Nothing
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(201, 183)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = False
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(287, 20)
        Me.bscNombreLocalidad.TabIndex = 29
        Me.bscNombreLocalidad.Titulo = Nothing
        '
        'chbMarca4
        '
        Me.chbMarca4.AutoSize = True
        Me.chbMarca4.BindearPropiedadControl = Nothing
        Me.chbMarca4.BindearPropiedadEntidad = Nothing
        Me.chbMarca4.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarca4.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarca4.IsPK = False
        Me.chbMarca4.IsRequired = False
        Me.chbMarca4.Key = Nothing
        Me.chbMarca4.LabelAsoc = Nothing
        Me.chbMarca4.Location = New System.Drawing.Point(293, 80)
        Me.chbMarca4.Name = "chbMarca4"
        Me.chbMarca4.Size = New System.Drawing.Size(65, 17)
        Me.chbMarca4.TabIndex = 12
        Me.chbMarca4.Text = "Marca 4"
        Me.chbMarca4.UseVisualStyleBackColor = True
        '
        'chbMarca5
        '
        Me.chbMarca5.AutoSize = True
        Me.chbMarca5.BindearPropiedadControl = Nothing
        Me.chbMarca5.BindearPropiedadEntidad = Nothing
        Me.chbMarca5.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarca5.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarca5.IsPK = False
        Me.chbMarca5.IsRequired = False
        Me.chbMarca5.Key = Nothing
        Me.chbMarca5.LabelAsoc = Nothing
        Me.chbMarca5.Location = New System.Drawing.Point(573, 80)
        Me.chbMarca5.Name = "chbMarca5"
        Me.chbMarca5.Size = New System.Drawing.Size(65, 17)
        Me.chbMarca5.TabIndex = 14
        Me.chbMarca5.Text = "Marca 5"
        Me.chbMarca5.UseVisualStyleBackColor = True
        '
        'cmbMarca5
        '
        Me.cmbMarca5.BindearPropiedadControl = Nothing
        Me.cmbMarca5.BindearPropiedadEntidad = Nothing
        Me.cmbMarca5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca5.Enabled = False
        Me.cmbMarca5.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca5.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca5.FormattingEnabled = True
        Me.cmbMarca5.IsPK = False
        Me.cmbMarca5.IsRequired = False
        Me.cmbMarca5.Key = Nothing
        Me.cmbMarca5.LabelAsoc = Nothing
        Me.cmbMarca5.Location = New System.Drawing.Point(639, 78)
        Me.cmbMarca5.Name = "cmbMarca5"
        Me.cmbMarca5.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarca5.TabIndex = 15
        '
        'cmbMarca4
        '
        Me.cmbMarca4.BindearPropiedadControl = Nothing
        Me.cmbMarca4.BindearPropiedadEntidad = Nothing
        Me.cmbMarca4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca4.Enabled = False
        Me.cmbMarca4.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca4.FormattingEnabled = True
        Me.cmbMarca4.IsPK = False
        Me.cmbMarca4.IsRequired = False
        Me.cmbMarca4.Key = Nothing
        Me.cmbMarca4.LabelAsoc = Nothing
        Me.cmbMarca4.Location = New System.Drawing.Point(364, 78)
        Me.cmbMarca4.Name = "cmbMarca4"
        Me.cmbMarca4.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarca4.TabIndex = 13
        '
        'lblMarca1
        '
        Me.lblMarca1.AutoSize = True
        Me.lblMarca1.LabelAsoc = Nothing
        Me.lblMarca1.Location = New System.Drawing.Point(374, 53)
        Me.lblMarca1.Name = "lblMarca1"
        Me.lblMarca1.Size = New System.Drawing.Size(68, 13)
        Me.lblMarca1.TabIndex = 7
        Me.lblMarca1.Text = "Marcas 1 y 2"
        '
        'chbMarca3
        '
        Me.chbMarca3.AutoSize = True
        Me.chbMarca3.BindearPropiedadControl = Nothing
        Me.chbMarca3.BindearPropiedadEntidad = Nothing
        Me.chbMarca3.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarca3.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarca3.IsPK = False
        Me.chbMarca3.IsRequired = False
        Me.chbMarca3.Key = Nothing
        Me.chbMarca3.LabelAsoc = Nothing
        Me.chbMarca3.Location = New System.Drawing.Point(15, 80)
        Me.chbMarca3.Name = "chbMarca3"
        Me.chbMarca3.Size = New System.Drawing.Size(65, 17)
        Me.chbMarca3.TabIndex = 10
        Me.chbMarca3.Text = "Marca 3"
        Me.chbMarca3.UseVisualStyleBackColor = True
        '
        'cmbMarca3
        '
        Me.cmbMarca3.BindearPropiedadControl = Nothing
        Me.cmbMarca3.BindearPropiedadEntidad = Nothing
        Me.cmbMarca3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca3.Enabled = False
        Me.cmbMarca3.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca3.FormattingEnabled = True
        Me.cmbMarca3.IsPK = False
        Me.cmbMarca3.IsRequired = False
        Me.cmbMarca3.Key = Nothing
        Me.cmbMarca3.LabelAsoc = Nothing
        Me.cmbMarca3.Location = New System.Drawing.Point(85, 78)
        Me.cmbMarca3.Name = "cmbMarca3"
        Me.cmbMarca3.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarca3.TabIndex = 11
        '
        'cmbMarca2
        '
        Me.cmbMarca2.BindearPropiedadControl = Nothing
        Me.cmbMarca2.BindearPropiedadEntidad = Nothing
        Me.cmbMarca2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca2.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca2.FormattingEnabled = True
        Me.cmbMarca2.IsPK = False
        Me.cmbMarca2.IsRequired = False
        Me.cmbMarca2.Key = Nothing
        Me.cmbMarca2.LabelAsoc = Nothing
        Me.cmbMarca2.Location = New System.Drawing.Point(650, 49)
        Me.cmbMarca2.Name = "cmbMarca2"
        Me.cmbMarca2.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarca2.TabIndex = 9
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
        Me.chbRubro.Location = New System.Drawing.Point(15, 109)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 16
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
        Me.cmbRubro.Location = New System.Drawing.Point(74, 107)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(200, 21)
        Me.cmbRubro.TabIndex = 17
        '
        'cmbMarca1
        '
        Me.cmbMarca1.BindearPropiedadControl = Nothing
        Me.cmbMarca1.BindearPropiedadEntidad = Nothing
        Me.cmbMarca1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca1.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca1.FormattingEnabled = True
        Me.cmbMarca1.IsPK = False
        Me.cmbMarca1.IsRequired = False
        Me.cmbMarca1.Key = Nothing
        Me.cmbMarca1.LabelAsoc = Me.lblMarca1
        Me.cmbMarca1.Location = New System.Drawing.Point(444, 49)
        Me.cmbMarca1.Name = "cmbMarca1"
        Me.cmbMarca1.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarca1.TabIndex = 8
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
        Me.chbZonaGeografica.Location = New System.Drawing.Point(552, 109)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
        Me.chbZonaGeografica.TabIndex = 20
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
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(658, 107)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(179, 21)
        Me.cmbZonaGeografica.TabIndex = 21
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
        Me.chbVendedor.Location = New System.Drawing.Point(290, 109)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 18
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
        Me.cmbVendedor.Location = New System.Drawing.Point(362, 107)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(180, 21)
        Me.cmbVendedor.TabIndex = 19
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
        Me.chbCliente.Location = New System.Drawing.Point(15, 160)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 22
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 140
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(93, 154)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 24
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(90, 138)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 23
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 140
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
        Me.bscCliente.Location = New System.Drawing.Point(190, 154)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 26
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(187, 138)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 25
        Me.lblNombre.Text = "Nombre"
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(15, 51)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 2
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(285, 49)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(86, 20)
        Me.dtpHasta.TabIndex = 6
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(244, 53)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 5
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
        Me.dtpDesde.Location = New System.Drawing.Point(150, 49)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(86, 20)
        Me.dtpDesde.TabIndex = 4
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(106, 53)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 3
        Me.lblDesde.Text = "Desde"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(740, 140)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 30
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
        Me.tstBarra.Size = New System.Drawing.Size(879, 29)
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
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.LabelAsoc = Nothing
        Me.lblTotal.Location = New System.Drawing.Point(645, 560)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(34, 13)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "Total:"
        '
        'txtTotalKilos
        '
        Me.txtTotalKilos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalKilos.BindearPropiedadControl = Nothing
        Me.txtTotalKilos.BindearPropiedadEntidad = Nothing
        Me.txtTotalKilos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalKilos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalKilos.Formato = "##0.00"
        Me.txtTotalKilos.IsDecimal = True
        Me.txtTotalKilos.IsNumber = True
        Me.txtTotalKilos.IsPK = False
        Me.txtTotalKilos.IsRequired = False
        Me.txtTotalKilos.Key = ""
        Me.txtTotalKilos.LabelAsoc = Nothing
        Me.txtTotalKilos.Location = New System.Drawing.Point(687, 558)
        Me.txtTotalKilos.Name = "txtTotalKilos"
        Me.txtTotalKilos.ReadOnly = True
        Me.txtTotalKilos.Size = New System.Drawing.Size(80, 20)
        Me.txtTotalKilos.TabIndex = 3
        Me.txtTotalKilos.Text = "0.00"
        Me.txtTotalKilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCliente, Me.CodigoCliente, Me.NombreCliente, Me.NombreLocalidad, Me.Marca1, Me.PorcMarca1, Me.Marca2, Me.PorcMarca2, Me.Marca3, Me.PorcMarca3, Me.Marca4, Me.PorcMarca4, Me.Marca5, Me.PorcMarca5, Me.Total, Me.Promedio, Me.IdSucursal})
        Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 263)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersWidth = 15
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(854, 295)
        Me.dgvDetalle.TabIndex = 1
        '
        'IdCliente
        '
        Me.IdCliente.DataPropertyName = "IdCliente"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdCliente.DefaultCellStyle = DataGridViewCellStyle1
        Me.IdCliente.HeaderText = "IdCliente"
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.ReadOnly = True
        Me.IdCliente.Visible = False
        '
        'CodigoCliente
        '
        Me.CodigoCliente.DataPropertyName = "CodigoCliente"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CodigoCliente.DefaultCellStyle = DataGridViewCellStyle2
        Me.CodigoCliente.HeaderText = "Codigo"
        Me.CodigoCliente.Name = "CodigoCliente"
        Me.CodigoCliente.ReadOnly = True
        Me.CodigoCliente.Width = 80
        '
        'NombreCliente
        '
        Me.NombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreCliente.DataPropertyName = "NombreCliente"
        Me.NombreCliente.HeaderText = "Nombre Cliente"
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.ReadOnly = True
        '
        'NombreLocalidad
        '
        Me.NombreLocalidad.DataPropertyName = "NombreLocalidad"
        Me.NombreLocalidad.HeaderText = "Localidad"
        Me.NombreLocalidad.Name = "NombreLocalidad"
        Me.NombreLocalidad.ReadOnly = True
        Me.NombreLocalidad.Width = 150
        '
        'Marca1
        '
        Me.Marca1.DataPropertyName = "Marca1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Marca1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Marca1.HeaderText = "Marca 1"
        Me.Marca1.Name = "Marca1"
        Me.Marca1.ReadOnly = True
        Me.Marca1.Width = 80
        '
        'PorcMarca1
        '
        Me.PorcMarca1.DataPropertyName = "PorcMarca1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.PorcMarca1.DefaultCellStyle = DataGridViewCellStyle4
        Me.PorcMarca1.HeaderText = "% 1"
        Me.PorcMarca1.Name = "PorcMarca1"
        Me.PorcMarca1.ReadOnly = True
        Me.PorcMarca1.Width = 50
        '
        'Marca2
        '
        Me.Marca2.DataPropertyName = "Marca2"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Marca2.DefaultCellStyle = DataGridViewCellStyle5
        Me.Marca2.HeaderText = "Marca 2"
        Me.Marca2.Name = "Marca2"
        Me.Marca2.ReadOnly = True
        Me.Marca2.Width = 80
        '
        'PorcMarca2
        '
        Me.PorcMarca2.DataPropertyName = "PorcMarca2"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.PorcMarca2.DefaultCellStyle = DataGridViewCellStyle6
        Me.PorcMarca2.HeaderText = "% 2"
        Me.PorcMarca2.Name = "PorcMarca2"
        Me.PorcMarca2.ReadOnly = True
        Me.PorcMarca2.Width = 50
        '
        'Marca3
        '
        Me.Marca3.DataPropertyName = "Marca3"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.Marca3.DefaultCellStyle = DataGridViewCellStyle7
        Me.Marca3.HeaderText = "Marca 3"
        Me.Marca3.Name = "Marca3"
        Me.Marca3.ReadOnly = True
        Me.Marca3.Visible = False
        Me.Marca3.Width = 80
        '
        'PorcMarca3
        '
        Me.PorcMarca3.DataPropertyName = "PorcMarca3"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.PorcMarca3.DefaultCellStyle = DataGridViewCellStyle8
        Me.PorcMarca3.HeaderText = "% 3"
        Me.PorcMarca3.Name = "PorcMarca3"
        Me.PorcMarca3.ReadOnly = True
        Me.PorcMarca3.Visible = False
        Me.PorcMarca3.Width = 50
        '
        'Marca4
        '
        Me.Marca4.DataPropertyName = "Marca4"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.Marca4.DefaultCellStyle = DataGridViewCellStyle9
        Me.Marca4.HeaderText = "Marca 4"
        Me.Marca4.Name = "Marca4"
        Me.Marca4.ReadOnly = True
        Me.Marca4.Visible = False
        Me.Marca4.Width = 80
        '
        'PorcMarca4
        '
        Me.PorcMarca4.DataPropertyName = "PorcMarca4"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.PorcMarca4.DefaultCellStyle = DataGridViewCellStyle10
        Me.PorcMarca4.HeaderText = "% 4"
        Me.PorcMarca4.Name = "PorcMarca4"
        Me.PorcMarca4.ReadOnly = True
        Me.PorcMarca4.Visible = False
        Me.PorcMarca4.Width = 50
        '
        'Marca5
        '
        Me.Marca5.DataPropertyName = "Marca5"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.Marca5.DefaultCellStyle = DataGridViewCellStyle11
        Me.Marca5.HeaderText = "Marca 5"
        Me.Marca5.Name = "Marca5"
        Me.Marca5.ReadOnly = True
        Me.Marca5.Visible = False
        Me.Marca5.Width = 80
        '
        'PorcMarca5
        '
        Me.PorcMarca5.DataPropertyName = "PorcMarca5"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        Me.PorcMarca5.DefaultCellStyle = DataGridViewCellStyle12
        Me.PorcMarca5.HeaderText = "% 5"
        Me.PorcMarca5.Name = "PorcMarca5"
        Me.PorcMarca5.ReadOnly = True
        Me.PorcMarca5.Visible = False
        Me.PorcMarca5.Width = 50
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle13
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 80
        '
        'Promedio
        '
        Me.Promedio.DataPropertyName = "Promedio"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N2"
        Me.Promedio.DefaultCellStyle = DataGridViewCellStyle14
        Me.Promedio.HeaderText = "Promedio"
        Me.Promedio.Name = "Promedio"
        Me.Promedio.ReadOnly = True
        Me.Promedio.Width = 80
        '
        'IdSucursal
        '
        Me.IdSucursal.DataPropertyName = "IdSucursal"
        Me.IdSucursal.HeaderText = "S."
        Me.IdSucursal.Name = "IdSucursal"
        Me.IdSucursal.ReadOnly = True
        Me.IdSucursal.Visible = False
        '
        'InfKilosCompMarcasPorCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 585)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.txtTotalKilos)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbConsultar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InfKilosCompMarcasPorCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Kilos Comparativo de Marcas por Cliente"
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
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents txtTotalKilos As Eniac.Controles.TextBox
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents cmbMarca1 As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca3 As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca3 As Eniac.Controles.ComboBox
   Friend WithEvents cmbMarca2 As Eniac.Controles.ComboBox
   Friend WithEvents lblMarca1 As Eniac.Controles.Label
   Friend WithEvents chbMarca4 As Eniac.Controles.CheckBox
   Friend WithEvents chbMarca5 As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca5 As Eniac.Controles.ComboBox
   Friend WithEvents cmbMarca4 As Eniac.Controles.ComboBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
    Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
    Friend WithEvents cmbSucursal As ComboBoxSucursales
    Friend WithEvents lblSucursal As Controles.Label
    Friend WithEvents IdCliente As DataGridViewTextBoxColumn
    Friend WithEvents CodigoCliente As DataGridViewTextBoxColumn
    Friend WithEvents NombreCliente As DataGridViewTextBoxColumn
    Friend WithEvents NombreLocalidad As DataGridViewTextBoxColumn
    Friend WithEvents Marca1 As DataGridViewTextBoxColumn
    Friend WithEvents PorcMarca1 As DataGridViewTextBoxColumn
    Friend WithEvents Marca2 As DataGridViewTextBoxColumn
    Friend WithEvents PorcMarca2 As DataGridViewTextBoxColumn
    Friend WithEvents Marca3 As DataGridViewTextBoxColumn
    Friend WithEvents PorcMarca3 As DataGridViewTextBoxColumn
    Friend WithEvents Marca4 As DataGridViewTextBoxColumn
    Friend WithEvents PorcMarca4 As DataGridViewTextBoxColumn
    Friend WithEvents Marca5 As DataGridViewTextBoxColumn
    Friend WithEvents PorcMarca5 As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Promedio As DataGridViewTextBoxColumn
    Friend WithEvents IdSucursal As DataGridViewTextBoxColumn
End Class
