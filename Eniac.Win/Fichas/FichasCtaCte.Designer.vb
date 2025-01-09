<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichasCtaCte
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
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FichasCtaCte))
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.NroOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImportePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.lblOperaciones = New Eniac.Controles.Label()
      Me.txtOperaciones = New Eniac.Controles.TextBox()
      Me.chkSoloConSaldo = New Eniac.Controles.CheckBox()
      Me.lblCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.lblTotales = New Eniac.Controles.Label()
      Me.txtTotalPagado = New Eniac.Controles.TextBox()
      Me.txtSaldo = New Eniac.Controles.TextBox()
      Me.txtTotalCompras = New Eniac.Controles.TextBox()
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.NroOperacion, Me.FechaCompra, Me.ImporteCompra, Me.NroCuota, Me.FechaPago, Me.ImportePago, Me.Saldo})
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle10
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(61, 157)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(670, 328)
      Me.dgvDetalle.TabIndex = 10
      '
      'Ver
      '
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.Ver.DefaultCellStyle = DataGridViewCellStyle2
      Me.Ver.HeaderText = "Ver"
      Me.Ver.Name = "Ver"
      Me.Ver.ReadOnly = True
      Me.Ver.Text = "Ver"
      Me.Ver.Width = 30
      '
      'NroOperacion
      '
      Me.NroOperacion.DataPropertyName = "NroOperacion"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroOperacion.DefaultCellStyle = DataGridViewCellStyle3
      Me.NroOperacion.HeaderText = "Operación"
      Me.NroOperacion.Name = "NroOperacion"
      Me.NroOperacion.ReadOnly = True
      Me.NroOperacion.Width = 75
      '
      'FechaCompra
      '
      Me.FechaCompra.DataPropertyName = "FechaCompra"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle4.Format = "dd/MM/yyyy HH:mm"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.FechaCompra.DefaultCellStyle = DataGridViewCellStyle4
      Me.FechaCompra.HeaderText = "Emitida"
      Me.FechaCompra.Name = "FechaCompra"
      Me.FechaCompra.ReadOnly = True
      '
      'ImporteCompra
      '
      Me.ImporteCompra.DataPropertyName = "ImporteCompra"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle5.Format = "N2"
      Me.ImporteCompra.DefaultCellStyle = DataGridViewCellStyle5
      Me.ImporteCompra.HeaderText = "Compra"
      Me.ImporteCompra.Name = "ImporteCompra"
      Me.ImporteCompra.ReadOnly = True
      Me.ImporteCompra.Width = 90
      '
      'NroCuota
      '
      Me.NroCuota.DataPropertyName = "NroCuota"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroCuota.DefaultCellStyle = DataGridViewCellStyle6
      Me.NroCuota.HeaderText = "Cuota"
      Me.NroCuota.Name = "NroCuota"
      Me.NroCuota.ReadOnly = True
      Me.NroCuota.Width = 75
      '
      'FechaPago
      '
      Me.FechaPago.DataPropertyName = "FechaPago"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "dd/MM/yyyy HH:mm"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.FechaPago.DefaultCellStyle = DataGridViewCellStyle7
      Me.FechaPago.HeaderText = "Fec. Pago"
      Me.FechaPago.Name = "FechaPago"
      Me.FechaPago.ReadOnly = True
      '
      'ImportePago
      '
      Me.ImportePago.DataPropertyName = "ImportePago"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.ImportePago.DefaultCellStyle = DataGridViewCellStyle8
      Me.ImportePago.HeaderText = "Imp. Pago"
      Me.ImportePago.Name = "ImportePago"
      Me.ImportePago.ReadOnly = True
      Me.ImportePago.Width = 90
      '
      'Saldo
      '
      Me.Saldo.DataPropertyName = "Saldo"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "N2"
      Me.Saldo.DefaultCellStyle = DataGridViewCellStyle9
      Me.Saldo.HeaderText = "Saldo"
      Me.Saldo.Name = "Saldo"
      Me.Saldo.ReadOnly = True
      Me.Saldo.Width = 90
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.lblOperaciones)
      Me.grbFiltros.Controls.Add(Me.txtOperaciones)
      Me.grbFiltros.Controls.Add(Me.chkSoloConSaldo)
      Me.grbFiltros.Controls.Add(Me.lblCliente)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(782, 112)
      Me.grbFiltros.TabIndex = 11
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'lblOperaciones
      '
      Me.lblOperaciones.AutoSize = True
      Me.lblOperaciones.Location = New System.Drawing.Point(203, 85)
      Me.lblOperaciones.Name = "lblOperaciones"
      Me.lblOperaciones.Size = New System.Drawing.Size(70, 13)
      Me.lblOperaciones.TabIndex = 54
      Me.lblOperaciones.Text = "Operaciones:"
      '
      'txtOperaciones
      '
      Me.txtOperaciones.BindearPropiedadControl = Nothing
      Me.txtOperaciones.BindearPropiedadEntidad = Nothing
      Me.txtOperaciones.Enabled = False
      Me.txtOperaciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtOperaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtOperaciones.Formato = ""
      Me.txtOperaciones.IsDecimal = False
      Me.txtOperaciones.IsNumber = False
      Me.txtOperaciones.IsPK = False
      Me.txtOperaciones.IsRequired = False
      Me.txtOperaciones.Key = ""
      Me.txtOperaciones.LabelAsoc = Nothing
      Me.txtOperaciones.Location = New System.Drawing.Point(279, 82)
      Me.txtOperaciones.Name = "txtOperaciones"
      Me.txtOperaciones.Size = New System.Drawing.Size(351, 20)
      Me.txtOperaciones.TabIndex = 53
      '
      'chkSoloConSaldo
      '
      Me.chkSoloConSaldo.AutoSize = True
      Me.chkSoloConSaldo.BindearPropiedadControl = Nothing
      Me.chkSoloConSaldo.BindearPropiedadEntidad = Nothing
      Me.chkSoloConSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.chkSoloConSaldo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkSoloConSaldo.IsPK = False
      Me.chkSoloConSaldo.IsRequired = False
      Me.chkSoloConSaldo.Key = Nothing
      Me.chkSoloConSaldo.LabelAsoc = Nothing
      Me.chkSoloConSaldo.Location = New System.Drawing.Point(18, 85)
      Me.chkSoloConSaldo.Name = "chkSoloConSaldo"
      Me.chkSoloConSaldo.Size = New System.Drawing.Size(149, 17)
      Me.chkSoloConSaldo.TabIndex = 52
      Me.chkSoloConSaldo.Text = "Solo con Saldo Pendiente"
      Me.chkSoloConSaldo.UseVisualStyleBackColor = True
      '
      'lblCliente
      '
      Me.lblCliente.AutoSize = True
      Me.lblCliente.Location = New System.Drawing.Point(15, 40)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(39, 13)
      Me.lblCliente.TabIndex = 51
      Me.lblCliente.Text = "Cliente"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasCondiciones = CType(resources.GetObject("bscCodigoCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoCliente.ColumnasVisibles = CType(resources.GetObject("bscCodigoCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(70, 38)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(141, 23)
      Me.bscCodigoCliente.TabIndex = 46
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(67, 22)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 50
      Me.lblCodigoCliente.Text = "Codigo"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasCondiciones = CType(resources.GetObject("bscCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCliente.ColumnasVisibles = CType(resources.GetObject("bscCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCliente.Datos = Nothing
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
      Me.bscCliente.Location = New System.Drawing.Point(225, 38)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(316, 23)
      Me.bscCliente.TabIndex = 47
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(222, 22)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 48
      Me.lblNombre.Text = "Nombre"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Location = New System.Drawing.Point(658, 24)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(111, 45)
      Me.btnConsultar.TabIndex = 43
      Me.btnConsultar.Text = "&Consultar"
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator3, Me.tsbRefrescar, Me.tsbImprimir, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(807, 29)
      Me.tstBarra.TabIndex = 12
      Me.tstBarra.Text = "toolStrip1"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "Imprimir"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 521)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(807, 22)
      Me.stsStado.TabIndex = 13
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(728, 17)
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
      'lblTotales
      '
      Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotales.AutoSize = True
      Me.lblTotales.Location = New System.Drawing.Point(216, 488)
      Me.lblTotales.Name = "lblTotales"
      Me.lblTotales.Size = New System.Drawing.Size(45, 13)
      Me.lblTotales.TabIndex = 29
      Me.lblTotales.Text = "Totales:"
      '
      'txtTotalPagado
      '
      Me.txtTotalPagado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalPagado.BindearPropiedadControl = Nothing
      Me.txtTotalPagado.BindearPropiedadEntidad = Nothing
      Me.txtTotalPagado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalPagado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalPagado.Formato = "##0.00"
      Me.txtTotalPagado.IsDecimal = True
      Me.txtTotalPagado.IsNumber = True
      Me.txtTotalPagado.IsPK = False
      Me.txtTotalPagado.IsRequired = False
      Me.txtTotalPagado.Key = ""
      Me.txtTotalPagado.LabelAsoc = Nothing
      Me.txtTotalPagado.Location = New System.Drawing.Point(533, 485)
      Me.txtTotalPagado.Name = "txtTotalPagado"
      Me.txtTotalPagado.ReadOnly = True
      Me.txtTotalPagado.Size = New System.Drawing.Size(90, 20)
      Me.txtTotalPagado.TabIndex = 28
      Me.txtTotalPagado.Text = "0.00"
      Me.txtTotalPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtSaldo
      '
      Me.txtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSaldo.BindearPropiedadControl = Nothing
      Me.txtSaldo.BindearPropiedadEntidad = Nothing
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = "##0.00"
      Me.txtSaldo.IsDecimal = True
      Me.txtSaldo.IsNumber = True
      Me.txtSaldo.IsPK = False
      Me.txtSaldo.IsRequired = False
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Nothing
      Me.txtSaldo.Location = New System.Drawing.Point(623, 485)
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.ReadOnly = True
      Me.txtSaldo.Size = New System.Drawing.Size(90, 20)
      Me.txtSaldo.TabIndex = 27
      Me.txtSaldo.Text = "0.00"
      Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalCompras
      '
      Me.txtTotalCompras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalCompras.BindearPropiedadControl = Nothing
      Me.txtTotalCompras.BindearPropiedadEntidad = Nothing
      Me.txtTotalCompras.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalCompras.Formato = "##0.00"
      Me.txtTotalCompras.IsDecimal = True
      Me.txtTotalCompras.IsNumber = True
      Me.txtTotalCompras.IsPK = False
      Me.txtTotalCompras.IsRequired = False
      Me.txtTotalCompras.Key = ""
      Me.txtTotalCompras.LabelAsoc = Nothing
      Me.txtTotalCompras.Location = New System.Drawing.Point(267, 485)
      Me.txtTotalCompras.Name = "txtTotalCompras"
      Me.txtTotalCompras.ReadOnly = True
      Me.txtTotalCompras.Size = New System.Drawing.Size(90, 20)
      Me.txtTotalCompras.TabIndex = 31
      Me.txtTotalCompras.Text = "0.00"
      Me.txtTotalCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'FichasCtaCte
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(807, 543)
      Me.Controls.Add(Me.txtTotalCompras)
      Me.Controls.Add(Me.lblTotales)
      Me.Controls.Add(Me.txtTotalPagado)
      Me.Controls.Add(Me.txtSaldo)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "FichasCtaCte"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Fichas - Cuenta Corriente de Clientes"
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
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtTotalPagado As Eniac.Controles.TextBox
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents txtTotalCompras As Eniac.Controles.TextBox
   Friend WithEvents lblCliente As Eniac.Controles.Label
   Friend WithEvents chkSoloConSaldo As Eniac.Controles.CheckBox
   Friend WithEvents lblOperaciones As Eniac.Controles.Label
   Friend WithEvents txtOperaciones As Eniac.Controles.TextBox
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents NroOperacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaCompra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCompra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroCuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImportePago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
