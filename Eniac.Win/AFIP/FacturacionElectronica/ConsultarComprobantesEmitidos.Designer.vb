<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarComprobantesEmitidos
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
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbAplicar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbDesdeHasta = New System.Windows.Forms.GroupBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.TipoImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescripcionAbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FormaDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TotalImpuestos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colCAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colCAEVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colIdTipoMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colNumeroMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ptgInfo = New System.Windows.Forms.PropertyGrid()
      Me.lblInformacionAFIP = New Eniac.Controles.Label()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.grbDesdeHasta.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAplicar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(703, 29)
        Me.tstBarra.TabIndex = 4
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbAplicar
        '
        Me.tsbAplicar.Image = Global.Eniac.Win.My.Resources.Resources.copy_save_32
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(70, 26)
        Me.tsbAplicar.Text = "Aplicar"
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
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(688, 17)
        Me.tssInfo.Spring = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 471)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(703, 22)
        Me.stsStado.TabIndex = 5
        Me.stsStado.Text = "statusStrip1"
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
        Me.tssRegistros.Size = New System.Drawing.Size(0, 17)
        '
        'grbDesdeHasta
        '
        Me.grbDesdeHasta.Controls.Add(Me.btnConsultar)
        Me.grbDesdeHasta.Controls.Add(Me.dtpHasta)
        Me.grbDesdeHasta.Controls.Add(Me.dtpDesde)
        Me.grbDesdeHasta.Controls.Add(Me.lblHasta)
        Me.grbDesdeHasta.Controls.Add(Me.lblDesde)
        Me.grbDesdeHasta.Location = New System.Drawing.Point(6, 32)
        Me.grbDesdeHasta.Name = "grbDesdeHasta"
        Me.grbDesdeHasta.Size = New System.Drawing.Size(309, 69)
        Me.grbDesdeHasta.TabIndex = 10
        Me.grbDesdeHasta.TabStop = False
        Me.grbDesdeHasta.Text = "Comprobantes"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(198, 13)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 102
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
        Me.dtpHasta.Location = New System.Drawing.Point(106, 38)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(86, 20)
        Me.dtpHasta.TabIndex = 104
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(103, 22)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 101
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
        Me.dtpDesde.Location = New System.Drawing.Point(12, 38)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(86, 20)
        Me.dtpDesde.TabIndex = 103
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(9, 22)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 100
        Me.lblDesde.Text = "Desde"
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoImpresora, Me.IdTipoComprobante, Me.DescripcionAbrev, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.Fecha, Me.TipoDocCliente, Me.NroDocCliente, Me.NombreCliente, Me.NombreCategoriaFiscal, Me.FormaDePago, Me.SubTotal, Me.TotalImpuestos, Me.ImporteTotal, Me.colCAE, Me.colCAEVencimiento, Me.Usuario, Me.Observacion, Me.colIdTipoMovimiento, Me.colNumeroMovimiento, Me.colIdSucursal})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDetalle.Location = New System.Drawing.Point(6, 103)
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
        Me.dgvDetalle.Size = New System.Drawing.Size(309, 365)
        Me.dgvDetalle.TabIndex = 11
        '
        'TipoImpresora
        '
        Me.TipoImpresora.DataPropertyName = "TipoImpresora"
        Me.TipoImpresora.HeaderText = "TipoImpresora"
        Me.TipoImpresora.Name = "TipoImpresora"
        Me.TipoImpresora.ReadOnly = True
        Me.TipoImpresora.Visible = False
        '
        'IdTipoComprobante
        '
        Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.IdTipoComprobante.HeaderText = "Comprobante"
        Me.IdTipoComprobante.Name = "IdTipoComprobante"
        Me.IdTipoComprobante.ReadOnly = True
        Me.IdTipoComprobante.Visible = False
        Me.IdTipoComprobante.Width = 80
        '
        'DescripcionAbrev
        '
        Me.DescripcionAbrev.DataPropertyName = "DescripcionAbrev"
        Me.DescripcionAbrev.HeaderText = "Comprobante"
        Me.DescripcionAbrev.Name = "DescripcionAbrev"
        Me.DescripcionAbrev.ReadOnly = True
        Me.DescripcionAbrev.Width = 75
        '
        'Letra
        '
        Me.Letra.DataPropertyName = "Letra"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
        Me.Letra.HeaderText = "Let."
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Width = 30
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
        'NumeroComprobante
        '
        Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle4
        Me.NumeroComprobante.HeaderText = "Numero"
        Me.NumeroComprobante.Name = "NumeroComprobante"
        Me.NumeroComprobante.ReadOnly = True
        Me.NumeroComprobante.Width = 55
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "dd/MM/yyyy HH:mm"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle5
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'TipoDocCliente
        '
        Me.TipoDocCliente.DataPropertyName = "TipoDocCliente"
        Me.TipoDocCliente.HeaderText = "Tipo Doc."
        Me.TipoDocCliente.Name = "TipoDocCliente"
        Me.TipoDocCliente.ReadOnly = True
        Me.TipoDocCliente.Visible = False
        Me.TipoDocCliente.Width = 55
        '
        'NroDocCliente
        '
        Me.NroDocCliente.DataPropertyName = "NroDocCliente"
        Me.NroDocCliente.HeaderText = "Nro. Doc."
        Me.NroDocCliente.Name = "NroDocCliente"
        Me.NroDocCliente.ReadOnly = True
        Me.NroDocCliente.Visible = False
        Me.NroDocCliente.Width = 80
        '
        'NombreCliente
        '
        Me.NombreCliente.DataPropertyName = "NombreCliente"
        Me.NombreCliente.HeaderText = "Cliente"
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.ReadOnly = True
        Me.NombreCliente.Width = 160
        '
        'NombreCategoriaFiscal
        '
        Me.NombreCategoriaFiscal.DataPropertyName = "NombreCategoriaFiscal"
        Me.NombreCategoriaFiscal.HeaderText = "Categ. Fiscal"
        Me.NombreCategoriaFiscal.Name = "NombreCategoriaFiscal"
        Me.NombreCategoriaFiscal.ReadOnly = True
        Me.NombreCategoriaFiscal.Width = 70
        '
        'FormaDePago
        '
        Me.FormaDePago.DataPropertyName = "FormaDePago"
        Me.FormaDePago.HeaderText = "F. de Pago"
        Me.FormaDePago.Name = "FormaDePago"
        Me.FormaDePago.ReadOnly = True
        Me.FormaDePago.Width = 64
        '
        'SubTotal
        '
        Me.SubTotal.DataPropertyName = "SubTotal"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.SubTotal.HeaderText = "Neto"
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.ReadOnly = True
        Me.SubTotal.Width = 70
        '
        'TotalImpuestos
        '
        Me.TotalImpuestos.DataPropertyName = "TotalImpuestos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TotalImpuestos.DefaultCellStyle = DataGridViewCellStyle7
        Me.TotalImpuestos.HeaderText = "Impuestos"
        Me.TotalImpuestos.Name = "TotalImpuestos"
        Me.TotalImpuestos.ReadOnly = True
        Me.TotalImpuestos.Width = 70
        '
        'ImporteTotal
        '
        Me.ImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle8
        Me.ImporteTotal.HeaderText = "Total"
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.ReadOnly = True
        Me.ImporteTotal.Width = 70
        '
        'colCAE
        '
        Me.colCAE.DataPropertyName = "CAE"
        Me.colCAE.HeaderText = "CAE"
        Me.colCAE.Name = "colCAE"
        Me.colCAE.ReadOnly = True
        '
        'colCAEVencimiento
        '
        Me.colCAEVencimiento.DataPropertyName = "CAEVencimiento"
        Me.colCAEVencimiento.HeaderText = "Venc. CAE"
        Me.colCAEVencimiento.Name = "colCAEVencimiento"
        Me.colCAEVencimiento.ReadOnly = True
        Me.colCAEVencimiento.Width = 80
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        Me.Usuario.Width = 60
        '
        'Observacion
        '
        Me.Observacion.DataPropertyName = "Observacion"
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        Me.Observacion.Width = 250
        '
        'colIdTipoMovimiento
        '
        Me.colIdTipoMovimiento.DataPropertyName = "IdTipoMovimiento"
        Me.colIdTipoMovimiento.HeaderText = "IdTipoMovimiento"
        Me.colIdTipoMovimiento.Name = "colIdTipoMovimiento"
        Me.colIdTipoMovimiento.ReadOnly = True
        Me.colIdTipoMovimiento.Visible = False
        '
        'colNumeroMovimiento
        '
        Me.colNumeroMovimiento.DataPropertyName = "NumeroMovimiento"
        Me.colNumeroMovimiento.HeaderText = "NumeroMovimiento"
        Me.colNumeroMovimiento.Name = "colNumeroMovimiento"
        Me.colNumeroMovimiento.ReadOnly = True
        Me.colNumeroMovimiento.Visible = False
        '
        'colIdSucursal
        '
        Me.colIdSucursal.DataPropertyName = "IdSucursal"
        Me.colIdSucursal.HeaderText = "Sucursal"
        Me.colIdSucursal.Name = "colIdSucursal"
        Me.colIdSucursal.ReadOnly = True
        Me.colIdSucursal.Visible = False
        '
        'ptgInfo
        '
        Me.ptgInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ptgInfo.HelpVisible = False
        Me.ptgInfo.Location = New System.Drawing.Point(327, 48)
        Me.ptgInfo.Name = "ptgInfo"
        Me.ptgInfo.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
        Me.ptgInfo.Size = New System.Drawing.Size(364, 420)
        Me.ptgInfo.TabIndex = 12
        Me.ptgInfo.ToolbarVisible = False
        '
        'lblInformacionAFIP
        '
        Me.lblInformacionAFIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInformacionAFIP.AutoSize = True
        Me.lblInformacionAFIP.LabelAsoc = Nothing
        Me.lblInformacionAFIP.Location = New System.Drawing.Point(324, 32)
        Me.lblInformacionAFIP.Name = "lblInformacionAFIP"
        Me.lblInformacionAFIP.Size = New System.Drawing.Size(103, 13)
        Me.lblInformacionAFIP.TabIndex = 101
        Me.lblInformacionAFIP.Text = "Información en AFIP"
        '
        'ConsultarComprobantesEmitidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 493)
        Me.Controls.Add(Me.lblInformacionAFIP)
        Me.Controls.Add(Me.ptgInfo)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.grbDesdeHasta)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.Name = "ConsultarComprobantesEmitidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Comprobantes Emitidos"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbDesdeHasta.ResumeLayout(False)
        Me.grbDesdeHasta.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbDesdeHasta As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents TipoImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescripcionAbrev As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FormaDePago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalImpuestos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colCAE As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colCAEVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colIdTipoMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colNumeroMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ptgInfo As System.Windows.Forms.PropertyGrid
   Friend WithEvents lblInformacionAFIP As Eniac.Controles.Label
   Friend WithEvents tsbAplicar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
