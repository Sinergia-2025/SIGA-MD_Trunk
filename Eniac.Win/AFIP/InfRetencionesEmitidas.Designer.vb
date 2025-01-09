<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfRetencionesEmitidas
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfRetencionesEmitidas))
        Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.FechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreTipoImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmisorRetencion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroRetencion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroPlanillaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCajaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroMovimientoEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Egreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BaseImponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alicuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.lblTotales = New Eniac.Controles.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbExportarSICORE = New System.Windows.Forms.ToolStripButton()
        Me.tsbGenerarArchivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbAplicativoAfip = New Eniac.Controles.ComboBox()
        Me.chbAplicativoAfip = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.cmbTipoImpuesto = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbTipoImpuesto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgIconos
        '
        Me.imgIconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgIconos.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.FechaEmision, Me.IdTipoImpuesto, Me.NombreTipoImpuesto, Me.EmisorRetencion, Me.NumeroRetencion, Me.IdProveedor, Me.CodigoProveedor, Me.colNombreProveedor, Me.NroPlanillaEgreso, Me.IdCajaEgreso, Me.NroMovimientoEgreso, Me.Egreso, Me.BaseImponible, Me.Alicuota, Me.ImporteTotal})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 118)
        Me.dgvDetalle.MultiSelect = False
        Me.dgvDetalle.Name = "dgvDetalle"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowHeadersWidth = 20
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(886, 294)
        Me.dgvDetalle.TabIndex = 1
        '
        'Ver
        '
        Me.Ver.DataPropertyName = "Ver"
        Me.Ver.HeaderText = "Ver"
        Me.Ver.Name = "Ver"
        Me.Ver.Text = "Ver"
        Me.Ver.Width = 30
        '
        'FechaEmision
        '
        Me.FechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FechaEmision.DefaultCellStyle = DataGridViewCellStyle2
        Me.FechaEmision.HeaderText = "Emision"
        Me.FechaEmision.Name = "FechaEmision"
        Me.FechaEmision.ReadOnly = True
        Me.FechaEmision.Width = 80
        '
        'IdTipoImpuesto
        '
        Me.IdTipoImpuesto.DataPropertyName = "IdTipoImpuesto"
        Me.IdTipoImpuesto.HeaderText = "IdTipoImpuesto"
        Me.IdTipoImpuesto.Name = "IdTipoImpuesto"
        Me.IdTipoImpuesto.Visible = False
        '
        'NombreTipoImpuesto
        '
        Me.NombreTipoImpuesto.DataPropertyName = "NombreTipoImpuesto"
        Me.NombreTipoImpuesto.HeaderText = "Tipo Impuesto"
        Me.NombreTipoImpuesto.Name = "NombreTipoImpuesto"
        Me.NombreTipoImpuesto.ReadOnly = True
        Me.NombreTipoImpuesto.Width = 150
        '
        'EmisorRetencion
        '
        Me.EmisorRetencion.DataPropertyName = "EmisorRetencion"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.EmisorRetencion.DefaultCellStyle = DataGridViewCellStyle3
        Me.EmisorRetencion.HeaderText = "Emisor"
        Me.EmisorRetencion.Name = "EmisorRetencion"
        Me.EmisorRetencion.ReadOnly = True
        Me.EmisorRetencion.Width = 45
        '
        'NumeroRetencion
        '
        Me.NumeroRetencion.DataPropertyName = "NumeroRetencion"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroRetencion.DefaultCellStyle = DataGridViewCellStyle4
        Me.NumeroRetencion.HeaderText = "Numero"
        Me.NumeroRetencion.Name = "NumeroRetencion"
        Me.NumeroRetencion.ReadOnly = True
        Me.NumeroRetencion.Width = 65
        '
        'IdProveedor
        '
        Me.IdProveedor.DataPropertyName = "IdProveedor"
        Me.IdProveedor.HeaderText = "IdProveedor"
        Me.IdProveedor.Name = "IdProveedor"
        Me.IdProveedor.Visible = False
        '
        'CodigoProveedor
        '
        Me.CodigoProveedor.DataPropertyName = "CodigoProveedor"
        Me.CodigoProveedor.HeaderText = "CodigoProveedor"
        Me.CodigoProveedor.Name = "CodigoProveedor"
        Me.CodigoProveedor.Visible = False
        '
        'colNombreProveedor
        '
        Me.colNombreProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombreProveedor.DataPropertyName = "NombreProveedor"
        Me.colNombreProveedor.HeaderText = "Nombre Proveedor"
        Me.colNombreProveedor.Name = "colNombreProveedor"
        '
        'NroPlanillaEgreso
        '
        Me.NroPlanillaEgreso.DataPropertyName = "NroPlanillaEgreso"
        Me.NroPlanillaEgreso.HeaderText = "NroPlanillaEgreso"
        Me.NroPlanillaEgreso.Name = "NroPlanillaEgreso"
        Me.NroPlanillaEgreso.Visible = False
        '
        'IdCajaEgreso
        '
        Me.IdCajaEgreso.DataPropertyName = "IdCajaEgreso"
        Me.IdCajaEgreso.HeaderText = "IdCajaEgreso"
        Me.IdCajaEgreso.Name = "IdCajaEgreso"
        Me.IdCajaEgreso.Visible = False
        '
        'NroMovimientoEgreso
        '
        Me.NroMovimientoEgreso.DataPropertyName = "NroMovimientoEgreso"
        Me.NroMovimientoEgreso.HeaderText = "NroMovimientoEgreso"
        Me.NroMovimientoEgreso.Name = "NroMovimientoEgreso"
        Me.NroMovimientoEgreso.Visible = False
        '
        'Egreso
        '
        Me.Egreso.DataPropertyName = "Egreso"
        Me.Egreso.HeaderText = "Egreso"
        Me.Egreso.Name = "Egreso"
        Me.Egreso.Width = 80
        '
        'BaseImponible
        '
        Me.BaseImponible.DataPropertyName = "BaseImponible"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.BaseImponible.DefaultCellStyle = DataGridViewCellStyle5
        Me.BaseImponible.HeaderText = "Base Imp."
        Me.BaseImponible.Name = "BaseImponible"
        Me.BaseImponible.ReadOnly = True
        Me.BaseImponible.Width = 80
        '
        'Alicuota
        '
        Me.Alicuota.DataPropertyName = "Alicuota"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Alicuota.DefaultCellStyle = DataGridViewCellStyle6
        Me.Alicuota.HeaderText = "Alicuota"
        Me.Alicuota.Name = "Alicuota"
        Me.Alicuota.Width = 50
        '
        'ImporteTotal
        '
        Me.ImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle7
        Me.ImporteTotal.HeaderText = "Importe"
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.Width = 75
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
        Me.txtTotal.Location = New System.Drawing.Point(810, 412)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtTotal.TabIndex = 3
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotales
        '
        Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotales.AutoSize = True
        Me.lblTotales.LabelAsoc = Nothing
        Me.lblTotales.Location = New System.Drawing.Point(769, 415)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(37, 13)
        Me.lblTotales.TabIndex = 2
        Me.lblTotales.Text = "Total :"
        '
        'stsStado
        '
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 439)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(910, 22)
        Me.stsStado.TabIndex = 4
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(831, 17)
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
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.tsbSalir, Me.tsbExportarSICORE, Me.tsbGenerarArchivo, Me.ToolStripSeparator2})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(910, 29)
        Me.tstBarra.TabIndex = 5
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
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
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'tsbExportarSICORE
        '
        Me.tsbExportarSICORE.Image = CType(resources.GetObject("tsbExportarSICORE.Image"), System.Drawing.Image)
        Me.tsbExportarSICORE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportarSICORE.Name = "tsbExportarSICORE"
        Me.tsbExportarSICORE.Size = New System.Drawing.Size(130, 26)
        Me.tsbExportarSICORE.Text = "Exportar para SIAP"
        Me.tsbExportarSICORE.Visible = False
        '
        'tsbGenerarArchivo
        '
        Me.tsbGenerarArchivo.Image = Global.Eniac.Win.My.Resources.Resources.database_save_32
        Me.tsbGenerarArchivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerarArchivo.Name = "tsbGenerarArchivo"
        Me.tsbGenerarArchivo.Size = New System.Drawing.Size(118, 26)
        Me.tsbGenerarArchivo.Text = "Generar Archivo"
        Me.tsbGenerarArchivo.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.cmbAplicativoAfip)
        Me.grbFiltros.Controls.Add(Me.chbAplicativoAfip)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.cmbTipoImpuesto)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbTipoImpuesto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(886, 80)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
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
        Me.cmbSucursal.Location = New System.Drawing.Point(64, 17)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(10, 20)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'cmbAplicativoAfip
        '
        Me.cmbAplicativoAfip.BindearPropiedadControl = "SelectedValue"
        Me.cmbAplicativoAfip.BindearPropiedadEntidad = "IdTipoImpuesto"
        Me.cmbAplicativoAfip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAplicativoAfip.Enabled = False
        Me.cmbAplicativoAfip.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAplicativoAfip.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAplicativoAfip.FormattingEnabled = True
        Me.cmbAplicativoAfip.IsPK = True
        Me.cmbAplicativoAfip.IsRequired = True
        Me.cmbAplicativoAfip.Key = Nothing
        Me.cmbAplicativoAfip.LabelAsoc = Nothing
        Me.cmbAplicativoAfip.Location = New System.Drawing.Point(526, 45)
        Me.cmbAplicativoAfip.Name = "cmbAplicativoAfip"
        Me.cmbAplicativoAfip.Size = New System.Drawing.Size(165, 21)
        Me.cmbAplicativoAfip.TabIndex = 10
        '
        'chbAplicativoAfip
        '
        Me.chbAplicativoAfip.AutoSize = True
        Me.chbAplicativoAfip.BindearPropiedadControl = Nothing
        Me.chbAplicativoAfip.BindearPropiedadEntidad = Nothing
        Me.chbAplicativoAfip.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAplicativoAfip.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAplicativoAfip.IsPK = False
        Me.chbAplicativoAfip.IsRequired = False
        Me.chbAplicativoAfip.Key = Nothing
        Me.chbAplicativoAfip.LabelAsoc = Nothing
        Me.chbAplicativoAfip.Location = New System.Drawing.Point(427, 49)
        Me.chbAplicativoAfip.Name = "chbAplicativoAfip"
        Me.chbAplicativoAfip.Size = New System.Drawing.Size(93, 17)
        Me.chbAplicativoAfip.TabIndex = 9
        Me.chbAplicativoAfip.Text = "Aplicativo Afip"
        Me.chbAplicativoAfip.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(13, 52)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 2
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'cmbTipoImpuesto
        '
        Me.cmbTipoImpuesto.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoImpuesto.BindearPropiedadEntidad = "IdTipoImpuesto"
        Me.cmbTipoImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoImpuesto.Enabled = False
        Me.cmbTipoImpuesto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoImpuesto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoImpuesto.FormattingEnabled = True
        Me.cmbTipoImpuesto.IsPK = True
        Me.cmbTipoImpuesto.IsRequired = True
        Me.cmbTipoImpuesto.Key = Nothing
        Me.cmbTipoImpuesto.LabelAsoc = Nothing
        Me.cmbTipoImpuesto.Location = New System.Drawing.Point(526, 21)
        Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
        Me.cmbTipoImpuesto.Size = New System.Drawing.Size(165, 21)
        Me.cmbTipoImpuesto.TabIndex = 8
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(743, 21)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(101, 45)
        Me.btnConsultar.TabIndex = 11
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbTipoImpuesto
        '
        Me.chbTipoImpuesto.AutoSize = True
        Me.chbTipoImpuesto.BindearPropiedadControl = Nothing
        Me.chbTipoImpuesto.BindearPropiedadEntidad = Nothing
        Me.chbTipoImpuesto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoImpuesto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoImpuesto.IsPK = False
        Me.chbTipoImpuesto.IsRequired = False
        Me.chbTipoImpuesto.Key = Nothing
        Me.chbTipoImpuesto.LabelAsoc = Nothing
        Me.chbTipoImpuesto.Location = New System.Drawing.Point(427, 23)
        Me.chbTipoImpuesto.Name = "chbTipoImpuesto"
        Me.chbTipoImpuesto.Size = New System.Drawing.Size(69, 17)
        Me.chbTipoImpuesto.TabIndex = 7
        Me.chbTipoImpuesto.Text = "Impuesto"
        Me.chbTipoImpuesto.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(297, 49)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpHasta.TabIndex = 6
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(260, 53)
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
        Me.dtpDesde.Location = New System.Drawing.Point(156, 49)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesde.TabIndex = 4
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(115, 53)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 3
        Me.lblDesde.Text = "Desde"
        '
        'InfRetencionesEmitidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 461)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotales)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InfRetencionesEmitidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Retenciones de Compras"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents chbTipoImpuesto As Eniac.Controles.CheckBox
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbTipoImpuesto As Eniac.Controles.ComboBox
   Friend WithEvents tsbExportarSICORE As System.Windows.Forms.ToolStripButton
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
    Friend WithEvents cmbAplicativoAfip As Eniac.Controles.ComboBox
    Friend WithEvents chbAplicativoAfip As Eniac.Controles.CheckBox
    Friend WithEvents tsbGenerarArchivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
    Friend WithEvents lblSucursal As Eniac.Controles.Label
    Friend WithEvents Ver As DataGridViewButtonColumn
    Friend WithEvents FechaEmision As DataGridViewTextBoxColumn
    Friend WithEvents IdTipoImpuesto As DataGridViewTextBoxColumn
    Friend WithEvents NombreTipoImpuesto As DataGridViewTextBoxColumn
    Friend WithEvents EmisorRetencion As DataGridViewTextBoxColumn
    Friend WithEvents NumeroRetencion As DataGridViewTextBoxColumn
    Friend WithEvents IdProveedor As DataGridViewTextBoxColumn
    Friend WithEvents CodigoProveedor As DataGridViewTextBoxColumn
    Friend WithEvents colNombreProveedor As DataGridViewTextBoxColumn
    Friend WithEvents NroPlanillaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents IdCajaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents NroMovimientoEgreso As DataGridViewTextBoxColumn
    Friend WithEvents Egreso As DataGridViewTextBoxColumn
    Friend WithEvents BaseImponible As DataGridViewTextBoxColumn
    Friend WithEvents Alicuota As DataGridViewTextBoxColumn
    Friend WithEvents ImporteTotal As DataGridViewTextBoxColumn
End Class
