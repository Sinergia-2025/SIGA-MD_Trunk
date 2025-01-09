<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KardexComprobCtaCteProveedores
   Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KardexComprobCtaCteProveedores))
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.TipoImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CuotaNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.lblNumeroFactura = New Eniac.Controles.Label()
      Me.txtEmisor = New Eniac.Controles.TextBox()
      Me.lblEmisorFactura = New Eniac.Controles.Label()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.cboLetra = New Eniac.Controles.ComboBox()
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.lblTotal = New Eniac.Controles.Label()
      Me.txtSaldo = New Eniac.Controles.TextBox()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFiltros.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.TipoImpresora, Me.IdSucursal, Me.IdTipoComprobante, Me.Letra, Me.CentroEmisor, Me.NroComprobante, Me.CuotaNumero, Me.Fecha, Me.FechaVencimiento, Me.ImporteCuota, Me.Observacion, Me.IdProveedor})
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle9
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 166)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(592, 353)
      Me.dgvDetalle.TabIndex = 10
      '
      'Ver
      '
      Me.Ver.HeaderText = "Ver"
      Me.Ver.Name = "Ver"
      Me.Ver.ReadOnly = True
      Me.Ver.Width = 30
      '
      'TipoImpresora
      '
      Me.TipoImpresora.DataPropertyName = "TipoImpresora"
      Me.TipoImpresora.HeaderText = "TipoImpresora"
      Me.TipoImpresora.Name = "TipoImpresora"
      Me.TipoImpresora.ReadOnly = True
      Me.TipoImpresora.Visible = False
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.ReadOnly = True
      Me.IdSucursal.Visible = False
      '
      'IdTipoComprobante
      '
      Me.IdTipoComprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.IdTipoComprobante.HeaderText = "Comprobante"
      Me.IdTipoComprobante.Name = "IdTipoComprobante"
      Me.IdTipoComprobante.ReadOnly = True
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
      Me.Letra.HeaderText = "Letra"
      Me.Letra.Name = "Letra"
      Me.Letra.ReadOnly = True
      Me.Letra.Width = 35
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
      Me.CentroEmisor.HeaderText = "Emisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.ReadOnly = True
      Me.CentroEmisor.Width = 40
      '
      'NroComprobante
      '
      Me.NroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroComprobante.DefaultCellStyle = DataGridViewCellStyle4
      Me.NroComprobante.HeaderText = "Numero"
      Me.NroComprobante.Name = "NroComprobante"
      Me.NroComprobante.ReadOnly = True
      Me.NroComprobante.Width = 70
      '
      'CuotaNumero
      '
      Me.CuotaNumero.DataPropertyName = "CuotaNumero"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CuotaNumero.DefaultCellStyle = DataGridViewCellStyle5
      Me.CuotaNumero.HeaderText = "Cuota"
      Me.CuotaNumero.Name = "CuotaNumero"
      Me.CuotaNumero.ReadOnly = True
      Me.CuotaNumero.Width = 50
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle6.Format = "d"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle6
      Me.Fecha.HeaderText = "Emisión"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.ReadOnly = True
      Me.Fecha.Width = 90
      '
      'FechaVencimiento
      '
      Me.FechaVencimiento.DataPropertyName = "FechaVencimiento"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle7.Format = "d"
      Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle7
      Me.FechaVencimiento.HeaderText = "Vencimiento"
      Me.FechaVencimiento.Name = "FechaVencimiento"
      Me.FechaVencimiento.ReadOnly = True
      Me.FechaVencimiento.Width = 90
      '
      'ImporteCuota
      '
      Me.ImporteCuota.DataPropertyName = "ImporteCuota"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.ImporteCuota.DefaultCellStyle = DataGridViewCellStyle8
      Me.ImporteCuota.HeaderText = "Importe"
      Me.ImporteCuota.Name = "ImporteCuota"
      Me.ImporteCuota.ReadOnly = True
      '
      'Observacion
      '
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observacion"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.ReadOnly = True
      Me.Observacion.Visible = False
      '
      'IdProveedor
      '
      Me.IdProveedor.DataPropertyName = "IdProveedor"
      Me.IdProveedor.HeaderText = "IdProveedor"
      Me.IdProveedor.Name = "IdProveedor"
      Me.IdProveedor.ReadOnly = True
      Me.IdProveedor.Visible = False
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.bscProveedor)
      Me.grbFiltros.Controls.Add(Me.lblCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.txtNumero)
      Me.grbFiltros.Controls.Add(Me.txtEmisor)
      Me.grbFiltros.Controls.Add(Me.lblNumeroFactura)
      Me.grbFiltros.Controls.Add(Me.lblEmisorFactura)
      Me.grbFiltros.Controls.Add(Me.lblLetra)
      Me.grbFiltros.Controls.Add(Me.cboLetra)
      Me.grbFiltros.Controls.Add(Me.lblComprobante)
      Me.grbFiltros.Controls.Add(Me.lblTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(592, 114)
      Me.grbFiltros.TabIndex = 11
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.AyudaAncho = 608
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
      Me.bscCodigoProveedor.ColumnasAncho = Nothing
      Me.bscCodigoProveedor.ColumnasFormato = Nothing
      Me.bscCodigoProveedor.ColumnasOcultas = Nothing
      Me.bscCodigoProveedor.ColumnasTitulos = Nothing
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = True
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(18, 34)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 61
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(15, 18)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 65
      Me.lblCodigoProveedor.Text = "Código"
      '
      'bscProveedor
      '
      Me.bscProveedor.AutoSize = True
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Me.lblNombre
      Me.bscProveedor.Location = New System.Drawing.Point(115, 34)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
      Me.bscProveedor.TabIndex = 62
      Me.bscProveedor.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(112, 18)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 63
      Me.lblNombre.Text = "Nombre"
      '
      'txtNumero
      '
      Me.txtNumero.BackColor = System.Drawing.Color.White
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = ""
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = True
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Me.lblNumeroFactura
      Me.txtNumero.Location = New System.Drawing.Point(385, 77)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(81, 20)
      Me.txtNumero.TabIndex = 3
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroFactura
      '
      Me.lblNumeroFactura.AutoSize = True
      Me.lblNumeroFactura.Location = New System.Drawing.Point(385, 61)
      Me.lblNumeroFactura.Name = "lblNumeroFactura"
      Me.lblNumeroFactura.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroFactura.TabIndex = 58
      Me.lblNumeroFactura.Text = "Numero"
      '
      'txtEmisor
      '
      Me.txtEmisor.BackColor = System.Drawing.Color.White
      Me.txtEmisor.BindearPropiedadControl = Nothing
      Me.txtEmisor.BindearPropiedadEntidad = Nothing
      Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisor.Formato = ""
      Me.txtEmisor.IsDecimal = False
      Me.txtEmisor.IsNumber = True
      Me.txtEmisor.IsPK = False
      Me.txtEmisor.IsRequired = True
      Me.txtEmisor.Key = ""
      Me.txtEmisor.LabelAsoc = Me.lblEmisorFactura
      Me.txtEmisor.Location = New System.Drawing.Point(338, 77)
      Me.txtEmisor.MaxLength = 4
      Me.txtEmisor.Name = "txtEmisor"
      Me.txtEmisor.Size = New System.Drawing.Size(41, 20)
      Me.txtEmisor.TabIndex = 2
      Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblEmisorFactura
      '
      Me.lblEmisorFactura.AutoSize = True
      Me.lblEmisorFactura.Location = New System.Drawing.Point(338, 61)
      Me.lblEmisorFactura.Name = "lblEmisorFactura"
      Me.lblEmisorFactura.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisorFactura.TabIndex = 59
      Me.lblEmisorFactura.Text = "Emisor"
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.Location = New System.Drawing.Point(279, 60)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(31, 13)
      Me.lblLetra.TabIndex = 54
      Me.lblLetra.Text = "Letra"
      '
      'cboLetra
      '
      Me.cboLetra.BindearPropiedadControl = Nothing
      Me.cboLetra.BindearPropiedadEntidad = Nothing
      Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.IsPK = False
      Me.cboLetra.IsRequired = False
      Me.cboLetra.Key = Nothing
      Me.cboLetra.LabelAsoc = Me.lblLetra
      Me.cboLetra.Location = New System.Drawing.Point(281, 76)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(48, 21)
      Me.cboLetra.TabIndex = 1
      '
      'lblComprobante
      '
      Me.lblComprobante.AutoSize = True
      Me.lblComprobante.Location = New System.Drawing.Point(15, 79)
      Me.lblComprobante.Name = "lblComprobante"
      Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
      Me.lblComprobante.TabIndex = 53
      Me.lblComprobante.Text = "Comprobante"
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.Location = New System.Drawing.Point(97, 60)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(28, 13)
      Me.lblTipoComprobante.TabIndex = 51
      Me.lblTipoComprobante.Text = "Tipo"
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.ItemHeight = 13
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(100, 76)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(172, 21)
      Me.cmbTiposComprobantes.TabIndex = 0
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(484, 62)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 4
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(623, 29)
      Me.tstBarra.TabIndex = 12
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
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 550)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(623, 22)
      Me.stsStado.TabIndex = 13
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(544, 17)
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
      'lblTotal
      '
      Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotal.AutoSize = True
      Me.lblTotal.Location = New System.Drawing.Point(461, 528)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(34, 13)
      Me.lblTotal.TabIndex = 29
      Me.lblTotal.Text = "Total:"
      '
      'txtSaldo
      '
      Me.txtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSaldo.BindearPropiedadControl = Nothing
      Me.txtSaldo.BindearPropiedadEntidad = Nothing
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = ""
      Me.txtSaldo.IsDecimal = False
      Me.txtSaldo.IsNumber = False
      Me.txtSaldo.IsPK = False
      Me.txtSaldo.IsRequired = False
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Nothing
      Me.txtSaldo.Location = New System.Drawing.Point(503, 525)
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.ReadOnly = True
      Me.txtSaldo.Size = New System.Drawing.Size(100, 20)
      Me.txtSaldo.TabIndex = 0
      Me.txtSaldo.Text = "0.00"
      Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'KardexComprobCtaCteProveedores
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(623, 572)
      Me.Controls.Add(Me.txtSaldo)
      Me.Controls.Add(Me.lblTotal)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "KardexComprobCtaCteProveedores"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Kardex de Comprobante de Cta. Cte. de Proveedores"
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroFactura As Eniac.Controles.Label
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents lblEmisorFactura As Eniac.Controles.Label
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents TipoImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CuotaNumero As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
