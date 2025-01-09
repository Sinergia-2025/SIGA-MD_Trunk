<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfTotalMarcasVentasPorVendedor
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfTotalMarcasVentasPorVendedor))
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.chbFormaPago = New Eniac.Controles.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlMarcas = New System.Windows.Forms.Panel()
        Me.lblMarcas = New Eniac.Controles.Label()
        Me.cmbMarcas = New Eniac.Win.ComboBoxMarcas()
        Me.pnlModelos = New System.Windows.Forms.Panel()
        Me.pnlRubros = New System.Windows.Forms.Panel()
        Me.cmbRubros = New Eniac.Win.ComboBoxRubro()
        Me.lblRubros = New Eniac.Controles.Label()
        Me.pnlSubRubros = New System.Windows.Forms.Panel()
        Me.cmbSubRubros = New Eniac.Win.ComboBoxSubRubro()
        Me.lblSubRubros = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.cmbGrupos = New Eniac.Controles.ComboBox()
        Me.chbGrupo = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.lblConComision = New Eniac.Controles.Label()
        Me.cmbConComision = New Eniac.Controles.ComboBox()
        Me.chbUnificar = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chbMesCompleto = New Eniac.Controles.CheckBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblTotales = New Eniac.Controles.Label()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.txtTotalComision = New Eniac.Controles.TextBox()
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalContado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalCtaCte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbListaPrecios = New Eniac.Controles.ComboBox()
        Me.chbListaPrecios = New Eniac.Controles.CheckBox()
        Me.grbConsultar.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMarcas.SuspendLayout()
        Me.pnlRubros.SuspendLayout()
        Me.pnlSubRubros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbConsultar
        '
        Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbConsultar.Controls.Add(Me.cmbListaPrecios)
        Me.grbConsultar.Controls.Add(Me.chbListaPrecios)
        Me.grbConsultar.Controls.Add(Me.cmbFormaPago)
        Me.grbConsultar.Controls.Add(Me.chbFormaPago)
        Me.grbConsultar.Controls.Add(Me.FlowLayoutPanel1)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.chbTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.cmbGrabanLibro)
        Me.grbConsultar.Controls.Add(Me.lblGrabanLibro)
        Me.grbConsultar.Controls.Add(Me.cmbGrupos)
        Me.grbConsultar.Controls.Add(Me.chbGrupo)
        Me.grbConsultar.Controls.Add(Me.cmbVendedor)
        Me.grbConsultar.Controls.Add(Me.lblConComision)
        Me.grbConsultar.Controls.Add(Me.cmbConComision)
        Me.grbConsultar.Controls.Add(Me.chbUnificar)
        Me.grbConsultar.Controls.Add(Me.chbVendedor)
        Me.grbConsultar.Controls.Add(Me.lblSucursal)
        Me.grbConsultar.Controls.Add(Me.cmbSucursal)
        Me.grbConsultar.Controls.Add(Me.chbConIVA)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Controls.Add(Me.chbZonaGeografica)
        Me.grbConsultar.Controls.Add(Me.cmbZonaGeografica)
        Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.bscCliente)
        Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.lblNombre)
        Me.grbConsultar.Controls.Add(Me.chbCliente)
        Me.grbConsultar.Controls.Add(Me.chbMesCompleto)
        Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(866, 196)
        Me.grbConsultar.TabIndex = 1
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Me.chbFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(477, 130)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(119, 21)
        Me.cmbFormaPago.TabIndex = 35
        '
        'chbFormaPago
        '
        Me.chbFormaPago.AutoSize = True
        Me.chbFormaPago.BindearPropiedadControl = Nothing
        Me.chbFormaPago.BindearPropiedadEntidad = Nothing
        Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormaPago.IsPK = False
        Me.chbFormaPago.IsRequired = False
        Me.chbFormaPago.Key = Nothing
        Me.chbFormaPago.LabelAsoc = Nothing
        Me.chbFormaPago.Location = New System.Drawing.Point(373, 132)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFormaPago.TabIndex = 34
        Me.chbFormaPago.Text = "Forma de Pago"
        Me.chbFormaPago.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMarcas)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlModelos)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubRubros)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(7, 160)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(784, 24)
        Me.FlowLayoutPanel1.TabIndex = 33
        '
        'pnlMarcas
        '
        Me.pnlMarcas.AutoSize = True
        Me.pnlMarcas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlMarcas.Controls.Add(Me.lblMarcas)
        Me.pnlMarcas.Controls.Add(Me.cmbMarcas)
        Me.pnlMarcas.Location = New System.Drawing.Point(3, 0)
        Me.pnlMarcas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlMarcas.Name = "pnlMarcas"
        Me.pnlMarcas.Size = New System.Drawing.Size(248, 21)
        Me.pnlMarcas.TabIndex = 0
        '
        'lblMarcas
        '
        Me.lblMarcas.AutoSize = True
        Me.lblMarcas.LabelAsoc = Nothing
        Me.lblMarcas.Location = New System.Drawing.Point(3, 4)
        Me.lblMarcas.Name = "lblMarcas"
        Me.lblMarcas.Size = New System.Drawing.Size(42, 13)
        Me.lblMarcas.TabIndex = 0
        Me.lblMarcas.Text = "Marcas"
        '
        'cmbMarcas
        '
        Me.cmbMarcas.BindearPropiedadControl = Nothing
        Me.cmbMarcas.BindearPropiedadEntidad = Nothing
        Me.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarcas.FormattingEnabled = True
        Me.cmbMarcas.IsPK = False
        Me.cmbMarcas.IsRequired = False
        Me.cmbMarcas.Key = Nothing
        Me.cmbMarcas.LabelAsoc = Me.lblMarcas
        Me.cmbMarcas.Location = New System.Drawing.Point(48, 0)
        Me.cmbMarcas.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbMarcas.Name = "cmbMarcas"
        Me.cmbMarcas.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarcas.TabIndex = 1
        '
        'pnlModelos
        '
        Me.pnlModelos.AutoSize = True
        Me.pnlModelos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlModelos.Location = New System.Drawing.Point(257, 0)
        Me.pnlModelos.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlModelos.Name = "pnlModelos"
        Me.pnlModelos.Size = New System.Drawing.Size(0, 0)
        Me.pnlModelos.TabIndex = 1
        '
        'pnlRubros
        '
        Me.pnlRubros.AutoSize = True
        Me.pnlRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlRubros.Controls.Add(Me.cmbRubros)
        Me.pnlRubros.Controls.Add(Me.lblRubros)
        Me.pnlRubros.Location = New System.Drawing.Point(263, 0)
        Me.pnlRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlRubros.Name = "pnlRubros"
        Me.pnlRubros.Size = New System.Drawing.Size(247, 21)
        Me.pnlRubros.TabIndex = 2
        '
        'cmbRubros
        '
        Me.cmbRubros.BindearPropiedadControl = Nothing
        Me.cmbRubros.BindearPropiedadEntidad = Nothing
        Me.cmbRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubros.FormattingEnabled = True
        Me.cmbRubros.IsPK = False
        Me.cmbRubros.IsRequired = False
        Me.cmbRubros.Key = Nothing
        Me.cmbRubros.LabelAsoc = Me.lblRubros
        Me.cmbRubros.Location = New System.Drawing.Point(47, 0)
        Me.cmbRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbRubros.Name = "cmbRubros"
        Me.cmbRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbRubros.TabIndex = 1
        '
        'lblRubros
        '
        Me.lblRubros.AutoSize = True
        Me.lblRubros.LabelAsoc = Nothing
        Me.lblRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblRubros.Name = "lblRubros"
        Me.lblRubros.Size = New System.Drawing.Size(41, 13)
        Me.lblRubros.TabIndex = 0
        Me.lblRubros.Text = "Rubros"
        '
        'pnlSubRubros
        '
        Me.pnlSubRubros.AutoSize = True
        Me.pnlSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSubRubros.Controls.Add(Me.cmbSubRubros)
        Me.pnlSubRubros.Controls.Add(Me.lblSubRubros)
        Me.pnlSubRubros.Location = New System.Drawing.Point(516, 0)
        Me.pnlSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubRubros.Name = "pnlSubRubros"
        Me.pnlSubRubros.Size = New System.Drawing.Size(265, 21)
        Me.pnlSubRubros.TabIndex = 3
        '
        'cmbSubRubros
        '
        Me.cmbSubRubros.BindearPropiedadControl = Nothing
        Me.cmbSubRubros.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubros.ConcatenarNombreRubro = False
        Me.cmbSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubros.FormattingEnabled = True
        Me.cmbSubRubros.IsPK = False
        Me.cmbSubRubros.IsRequired = False
        Me.cmbSubRubros.Key = Nothing
        Me.cmbSubRubros.LabelAsoc = Me.lblSubRubros
        Me.cmbSubRubros.Location = New System.Drawing.Point(65, 0)
        Me.cmbSubRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSubRubros.Name = "cmbSubRubros"
        Me.cmbSubRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubRubros.TabIndex = 1
        '
        'lblSubRubros
        '
        Me.lblSubRubros.AutoSize = True
        Me.lblSubRubros.LabelAsoc = Nothing
        Me.lblSubRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblSubRubros.Name = "lblSubRubros"
        Me.lblSubRubros.Size = New System.Drawing.Size(60, 13)
        Me.lblSubRubros.TabIndex = 0
        Me.lblSubRubros.Text = "SubRubros"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Enabled = False
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.chbTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(124, 97)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(148, 21)
        Me.cmbTiposComprobantes.TabIndex = 16
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.BindearPropiedadControl = Nothing
        Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobante.IsPK = False
        Me.chbTipoComprobante.IsRequired = False
        Me.chbTipoComprobante.Key = Nothing
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(7, 100)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 15
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'cmbGrabanLibro
        '
        Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
        Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
        Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrabanLibro.FormattingEnabled = True
        Me.cmbGrabanLibro.IsPK = False
        Me.cmbGrabanLibro.IsRequired = False
        Me.cmbGrabanLibro.Key = Nothing
        Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabanLibro
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(583, 95)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
        Me.cmbGrabanLibro.TabIndex = 20
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(514, 101)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 19
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'cmbGrupos
        '
        Me.cmbGrupos.BindearPropiedadControl = Nothing
        Me.cmbGrupos.BindearPropiedadEntidad = Nothing
        Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupos.Enabled = False
        Me.cmbGrupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupos.FormattingEnabled = True
        Me.cmbGrupos.IsPK = False
        Me.cmbGrupos.IsRequired = False
        Me.cmbGrupos.ItemHeight = 13
        Me.cmbGrupos.Key = Nothing
        Me.cmbGrupos.LabelAsoc = Me.chbGrupo
        Me.cmbGrupos.Location = New System.Drawing.Point(343, 97)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(162, 21)
        Me.cmbGrupos.TabIndex = 18
        '
        'chbGrupo
        '
        Me.chbGrupo.AutoSize = True
        Me.chbGrupo.BindearPropiedadControl = Nothing
        Me.chbGrupo.BindearPropiedadEntidad = Nothing
        Me.chbGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrupo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrupo.IsPK = False
        Me.chbGrupo.IsRequired = False
        Me.chbGrupo.Key = Nothing
        Me.chbGrupo.LabelAsoc = Nothing
        Me.chbGrupo.Location = New System.Drawing.Point(287, 99)
        Me.chbGrupo.Name = "chbGrupo"
        Me.chbGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chbGrupo.TabIndex = 17
        Me.chbGrupo.Text = "Grupo"
        Me.chbGrupo.UseVisualStyleBackColor = True
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
        Me.cmbVendedor.Location = New System.Drawing.Point(83, 129)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(123, 21)
        Me.cmbVendedor.TabIndex = 29
        '
        'lblConComision
        '
        Me.lblConComision.AutoSize = True
        Me.lblConComision.LabelAsoc = Nothing
        Me.lblConComision.Location = New System.Drawing.Point(215, 132)
        Me.lblConComision.Name = "lblConComision"
        Me.lblConComision.Size = New System.Drawing.Size(71, 13)
        Me.lblConComision.TabIndex = 30
        Me.lblConComision.Text = "Con Comision"
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
        Me.cmbConComision.Location = New System.Drawing.Point(292, 129)
        Me.cmbConComision.Name = "cmbConComision"
        Me.cmbConComision.Size = New System.Drawing.Size(70, 21)
        Me.cmbConComision.TabIndex = 31
        Me.cmbConComision.TabStop = False
        '
        'chbUnificar
        '
        Me.chbUnificar.AutoSize = True
        Me.chbUnificar.BindearPropiedadControl = Nothing
        Me.chbUnificar.BindearPropiedadEntidad = Nothing
        Me.chbUnificar.Checked = True
        Me.chbUnificar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbUnificar.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUnificar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUnificar.IsPK = False
        Me.chbUnificar.IsRequired = False
        Me.chbUnificar.Key = Nothing
        Me.chbUnificar.LabelAsoc = Nothing
        Me.chbUnificar.Location = New System.Drawing.Point(198, 22)
        Me.chbUnificar.Name = "chbUnificar"
        Me.chbUnificar.Size = New System.Drawing.Size(62, 17)
        Me.chbUnificar.TabIndex = 2
        Me.chbUnificar.Text = "Unificar"
        Me.chbUnificar.UseVisualStyleBackColor = True
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
        Me.chbVendedor.Location = New System.Drawing.Point(7, 131)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 28
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(7, 24)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
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
        Me.cmbSucursal.Location = New System.Drawing.Point(59, 20)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 1
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
        Me.chbConIVA.Location = New System.Drawing.Point(801, 162)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 21
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(578, 20)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 7
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(538, 24)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 6
        Me.lblHasta.Text = "Hasta"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(744, 69)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 32
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.dtpDesde.Location = New System.Drawing.Point(407, 20)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 5
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(365, 24)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 4
        Me.lblDesde.Text = "Desde"
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
        Me.chbZonaGeografica.Location = New System.Drawing.Point(447, 64)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
        Me.chbZonaGeografica.TabIndex = 13
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
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(554, 62)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(162, 21)
        Me.cmbZonaGeografica.TabIndex = 14
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(71, 62)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 10
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(71, 48)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 9
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
        Me.bscCliente.Location = New System.Drawing.Point(179, 62)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(251, 23)
        Me.bscCliente.TabIndex = 12
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(181, 48)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 11
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
        Me.chbCliente.Location = New System.Drawing.Point(7, 65)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 8
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
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
        Me.chbMesCompleto.Location = New System.Drawing.Point(266, 23)
        Me.chbMesCompleto.Name = "chbMesCompleto"
        Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chbMesCompleto.TabIndex = 3
        Me.chbMesCompleto.Text = "Mes Completo"
        Me.chbMesCompleto.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(892, 29)
        Me.tstBarra.TabIndex = 0
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'lblTotales
        '
        Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotales.AutoSize = True
        Me.lblTotales.LabelAsoc = Nothing
        Me.lblTotales.Location = New System.Drawing.Point(551, 524)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(45, 13)
        Me.lblTotales.TabIndex = 3
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
        Me.txtTotal.Location = New System.Drawing.Point(600, 521)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(101, 20)
        Me.txtTotal.TabIndex = 4
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
        Me.txtTotalComision.Location = New System.Drawing.Point(701, 521)
        Me.txtTotalComision.Name = "txtTotalComision"
        Me.txtTotalComision.ReadOnly = True
        Me.txtTotalComision.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalComision.TabIndex = 5
        Me.txtTotalComision.Text = "0.00"
        Me.txtTotalComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSucursal, Me.IdMarca, Me.NombreMarca, Me.TotalContado, Me.TotalCtaCte, Me.Total, Me.Comision})
        Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 234)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersWidth = 15
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(866, 284)
        Me.dgvDetalle.TabIndex = 2
        '
        'IdSucursal
        '
        Me.IdSucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IdSucursal.DataPropertyName = "IdSucursal"
        Me.IdSucursal.HeaderText = "S."
        Me.IdSucursal.MinimumWidth = 25
        Me.IdSucursal.Name = "IdSucursal"
        Me.IdSucursal.ReadOnly = True
        Me.IdSucursal.Width = 25
        '
        'IdMarca
        '
        Me.IdMarca.DataPropertyName = "IdMarca"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdMarca.DefaultCellStyle = DataGridViewCellStyle1
        Me.IdMarca.HeaderText = "Codigo"
        Me.IdMarca.Name = "IdMarca"
        Me.IdMarca.ReadOnly = True
        Me.IdMarca.Width = 60
        '
        'NombreMarca
        '
        Me.NombreMarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreMarca.DataPropertyName = "NombreMarca"
        Me.NombreMarca.HeaderText = "Nombre Marca"
        Me.NombreMarca.Name = "NombreMarca"
        Me.NombreMarca.ReadOnly = True
        '
        'TotalContado
        '
        Me.TotalContado.DataPropertyName = "TotalContado"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        DataGridViewCellStyle2.Format = "N2"
        Me.TotalContado.DefaultCellStyle = DataGridViewCellStyle2
        Me.TotalContado.HeaderText = "Total Contado"
        Me.TotalContado.Name = "TotalContado"
        Me.TotalContado.ReadOnly = True
        '
        'TotalCtaCte
        '
        Me.TotalCtaCte.DataPropertyName = "TotalCtaCte"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TotalCtaCte.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalCtaCte.HeaderText = "Total Cta.Cte."
        Me.TotalCtaCte.Name = "TotalCtaCte"
        Me.TotalCtaCte.ReadOnly = True
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle4
        Me.Total.HeaderText = "Total (Neto)"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'Comision
        '
        Me.Comision.DataPropertyName = "Comision"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "N2"
        Me.Comision.DefaultCellStyle = DataGridViewCellStyle5
        Me.Comision.HeaderText = "Comision"
        Me.Comision.Name = "Comision"
        Me.Comision.ReadOnly = True
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.BindearPropiedadControl = Nothing
        Me.cmbListaPrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.Enabled = False
        Me.cmbListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.IsPK = False
        Me.cmbListaPrecios.IsRequired = False
        Me.cmbListaPrecios.Key = Nothing
        Me.cmbListaPrecios.LabelAsoc = Nothing
        Me.cmbListaPrecios.Location = New System.Drawing.Point(711, 131)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(140, 21)
        Me.cmbListaPrecios.TabIndex = 50
        '
        'chbListaPrecios
        '
        Me.chbListaPrecios.AutoSize = True
        Me.chbListaPrecios.BindearPropiedadControl = Nothing
        Me.chbListaPrecios.BindearPropiedadEntidad = Nothing
        Me.chbListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaPrecios.IsPK = False
        Me.chbListaPrecios.IsRequired = False
        Me.chbListaPrecios.Key = Nothing
        Me.chbListaPrecios.LabelAsoc = Nothing
        Me.chbListaPrecios.Location = New System.Drawing.Point(607, 133)
        Me.chbListaPrecios.Name = "chbListaPrecios"
        Me.chbListaPrecios.Size = New System.Drawing.Size(101, 17)
        Me.chbListaPrecios.TabIndex = 49
        Me.chbListaPrecios.Text = "Lista de Precios"
        Me.chbListaPrecios.UseVisualStyleBackColor = True
        '
        'InfTotalMarcasVentasPorVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 549)
        Me.Controls.Add(Me.lblTotales)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtTotalComision)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbConsultar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InfTotalMarcasVentasPorVendedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Comisiones Totales por Marcas"
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.pnlMarcas.ResumeLayout(False)
        Me.pnlMarcas.PerformLayout()
        Me.pnlRubros.ResumeLayout(False)
        Me.pnlRubros.PerformLayout()
        Me.pnlSubRubros.ResumeLayout(False)
        Me.pnlSubRubros.PerformLayout()
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
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
    Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
    Friend WithEvents bscCliente As Eniac.Controles.Buscador
    Friend WithEvents lblNombre As Eniac.Controles.Label
    Friend WithEvents chbCliente As Eniac.Controles.CheckBox
    Friend WithEvents cmbConComision As Eniac.Controles.ComboBox
    Friend WithEvents lblConComision As Eniac.Controles.Label
    Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
    Friend WithEvents lblTotales As Eniac.Controles.Label
    Friend WithEvents txtTotal As Eniac.Controles.TextBox
    Friend WithEvents txtTotalComision As Eniac.Controles.TextBox
    Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
    Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalContado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalCtaCte As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Comision As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents chbUnificar As Eniac.Controles.CheckBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents cmbGrupos As Eniac.Controles.ComboBox
   Friend WithEvents chbGrupo As Eniac.Controles.CheckBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents pnlMarcas As Panel
    Friend WithEvents lblMarcas As Controles.Label
    Friend WithEvents cmbMarcas As ComboBoxMarcas
    Friend WithEvents pnlModelos As Panel
    Friend WithEvents pnlRubros As Panel
    Friend WithEvents cmbRubros As ComboBoxRubro
    Friend WithEvents lblRubros As Controles.Label
    Friend WithEvents pnlSubRubros As Panel
    Friend WithEvents cmbSubRubros As ComboBoxSubRubro
    Friend WithEvents lblSubRubros As Controles.Label
    Friend WithEvents cmbFormaPago As Controles.ComboBox
    Friend WithEvents chbFormaPago As Controles.CheckBox
    Friend WithEvents cmbListaPrecios As Controles.ComboBox
    Friend WithEvents chbListaPrecios As Controles.CheckBox
End Class
