<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministracionNotasRecepcionF
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministracionNotasRecepcionF))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbEditarNota = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimirNota = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.lblFechaEnvio = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.lblFechaEnvioHasta = New Eniac.Controles.Label()
      Me.dtpFechaEnvioHasta = New Eniac.Controles.DateTimePicker()
      Me.lblFechaEnvioDesde = New Eniac.Controles.Label()
      Me.dtpFechaEnvioDesde = New Eniac.Controles.DateTimePicker()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.cmbEstado = New Eniac.Controles.ComboBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tslRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.NroNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DefectoProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CostoReparacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.EstaPrestado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.IdProductoPrestado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ProductoPrestado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CantidadPrestada = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ObservacionPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator3, Me.tsbRefrescar, Me.ToolStripSeparator5, Me.tsbEditarNota, Me.ToolStripSeparator6, Me.tsbImprimirNota, Me.ToolStripSeparator7, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(949, 29)
      Me.tstBarra.TabIndex = 16
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
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
      '
      'tsbEditarNota
      '
      Me.tsbEditarNota.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
      Me.tsbEditarNota.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEditarNota.Name = "tsbEditarNota"
      Me.tsbEditarNota.Size = New System.Drawing.Size(92, 26)
      Me.tsbEditarNota.Text = "Editar Nota"
      '
      'ToolStripSeparator6
      '
      Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
      Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimirNota
      '
      Me.tsbImprimirNota.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimirNota.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimirNota.Name = "tsbImprimirNota"
      Me.tsbImprimirNota.Size = New System.Drawing.Size(108, 26)
      Me.tsbImprimirNota.Text = "&Imprimir Nota"
      '
      'ToolStripSeparator7
      '
      Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
      Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 29)
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
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.lblFechaEnvio)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblFechaEnvioHasta)
      Me.grbFiltros.Controls.Add(Me.dtpFechaEnvioHasta)
      Me.grbFiltros.Controls.Add(Me.lblFechaEnvioDesde)
      Me.grbFiltros.Controls.Add(Me.dtpFechaEnvioDesde)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.cmbEstado)
      Me.grbFiltros.Controls.Add(Me.lblEstado)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(924, 101)
      Me.grbFiltros.TabIndex = 19
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Buscar por..."
      '
      'lblFechaEnvio
      '
      Me.lblFechaEnvio.AutoSize = True
      Me.lblFechaEnvio.Location = New System.Drawing.Point(350, 34)
      Me.lblFechaEnvio.Name = "lblFechaEnvio"
      Me.lblFechaEnvio.Size = New System.Drawing.Size(66, 13)
      Me.lblFechaEnvio.TabIndex = 41
      Me.lblFechaEnvio.Text = "Fecha envio"
      '
      'chbCliente
      '
      Me.chbCliente.AutoSize = True
      Me.chbCliente.BindearPropiedadControl = ""
      Me.chbCliente.BindearPropiedadEntidad = ""
      Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCliente.IsPK = False
      Me.chbCliente.IsRequired = False
      Me.chbCliente.Key = Nothing
      Me.chbCliente.LabelAsoc = Nothing
      Me.chbCliente.Location = New System.Drawing.Point(21, 77)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 40
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
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
      Me.bscCliente.Location = New System.Drawing.Point(207, 75)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(368, 23)
      Me.bscCliente.TabIndex = 39
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(204, 61)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 38
      Me.lblNombre.Text = "Nombre"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasCondiciones = CType(resources.GetObject("bscCodigoCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoCliente.ColumnasVisibles = CType(resources.GetObject("bscCodigoCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(84, 75)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoCliente.TabIndex = 34
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(84, 60)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 36
      Me.lblCodigoCliente.Text = "Codigo"
      '
      'lblFechaEnvioHasta
      '
      Me.lblFechaEnvioHasta.AutoSize = True
      Me.lblFechaEnvioHasta.Location = New System.Drawing.Point(523, 14)
      Me.lblFechaEnvioHasta.Name = "lblFechaEnvioHasta"
      Me.lblFechaEnvioHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblFechaEnvioHasta.TabIndex = 33
      Me.lblFechaEnvioHasta.Text = "Hasta"
      '
      'dtpFechaEnvioHasta
      '
      Me.dtpFechaEnvioHasta.BindearPropiedadControl = Nothing
      Me.dtpFechaEnvioHasta.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEnvioHasta.Checked = False
      Me.dtpFechaEnvioHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEnvioHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEnvioHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEnvioHasta.IsPK = False
      Me.dtpFechaEnvioHasta.IsRequired = False
      Me.dtpFechaEnvioHasta.Key = ""
      Me.dtpFechaEnvioHasta.LabelAsoc = Me.lblFechaEnvioHasta
      Me.dtpFechaEnvioHasta.Location = New System.Drawing.Point(526, 30)
      Me.dtpFechaEnvioHasta.Name = "dtpFechaEnvioHasta"
      Me.dtpFechaEnvioHasta.ShowCheckBox = True
      Me.dtpFechaEnvioHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaEnvioHasta.TabIndex = 32
      '
      'lblFechaEnvioDesde
      '
      Me.lblFechaEnvioDesde.AutoSize = True
      Me.lblFechaEnvioDesde.Location = New System.Drawing.Point(419, 14)
      Me.lblFechaEnvioDesde.Name = "lblFechaEnvioDesde"
      Me.lblFechaEnvioDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblFechaEnvioDesde.TabIndex = 31
      Me.lblFechaEnvioDesde.Text = "Desde"
      '
      'dtpFechaEnvioDesde
      '
      Me.dtpFechaEnvioDesde.BindearPropiedadControl = Nothing
      Me.dtpFechaEnvioDesde.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEnvioDesde.Checked = False
      Me.dtpFechaEnvioDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEnvioDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEnvioDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEnvioDesde.IsPK = False
      Me.dtpFechaEnvioDesde.IsRequired = False
      Me.dtpFechaEnvioDesde.Key = ""
      Me.dtpFechaEnvioDesde.LabelAsoc = Me.lblFechaEnvioDesde
      Me.dtpFechaEnvioDesde.Location = New System.Drawing.Point(422, 30)
      Me.dtpFechaEnvioDesde.Name = "dtpFechaEnvioDesde"
      Me.dtpFechaEnvioDesde.ShowCheckBox = True
      Me.dtpFechaEnvioDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaEnvioDesde.TabIndex = 30
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.document_find
      Me.btnConsultar.Location = New System.Drawing.Point(737, 34)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(113, 45)
      Me.btnConsultar.TabIndex = 29
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'cmbEstado
      '
      Me.cmbEstado.BindearPropiedadControl = Nothing
      Me.cmbEstado.BindearPropiedadEntidad = Nothing
      Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstado.FormattingEnabled = True
      Me.cmbEstado.IsPK = False
      Me.cmbEstado.IsRequired = False
      Me.cmbEstado.Key = Nothing
      Me.cmbEstado.LabelAsoc = Me.lblEstado
      Me.cmbEstado.Location = New System.Drawing.Point(84, 30)
      Me.cmbEstado.Name = "cmbEstado"
      Me.cmbEstado.Size = New System.Drawing.Size(120, 21)
      Me.cmbEstado.TabIndex = 13
      Me.cmbEstado.TabStop = False
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.Location = New System.Drawing.Point(39, 34)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 11
      Me.lblEstado.Text = "Estado"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto, Me.tslRegistros, Me.tspBarra})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 457)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(949, 22)
      Me.StatusStrip1.TabIndex = 21
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tslTexto
      '
      Me.tslTexto.Name = "tslTexto"
      Me.tslTexto.Size = New System.Drawing.Size(870, 17)
      Me.tslTexto.Spring = True
      '
      'tslRegistros
      '
      Me.tslRegistros.Name = "tslRegistros"
      Me.tslRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tslRegistros.Text = "0 Registros"
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Marquee
      Me.tspBarra.Visible = False
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroNota, Me.FechaNota, Me.IdEstado, Me.NombreEstado, Me.FechaEstado, Me.IdProducto, Me.Producto, Me.Cantidad, Me.DefectoProducto, Me.CostoReparacion, Me.TipoDocumento, Me.NroDocumento, Me.NombreCliente, Me.Observacion, Me.IdSucursal, Me.NroOperacion, Me.EstaPrestado, Me.IdProductoPrestado, Me.ProductoPrestado, Me.CantidadPrestada, Me.ObservacionPrestamo, Me.TipoDocProveedor, Me.NroDocProveedor, Me.NombreProveedor})
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle11
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 139)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
      Me.dgvDetalle.RowHeadersWidth = 20
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(925, 314)
      Me.dgvDetalle.TabIndex = 23
      '
      'NroNota
      '
      Me.NroNota.DataPropertyName = "NroNota"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Format = "d"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.NroNota.DefaultCellStyle = DataGridViewCellStyle2
      Me.NroNota.HeaderText = "Nota Recep."
      Me.NroNota.Name = "NroNota"
      Me.NroNota.ReadOnly = True
      Me.NroNota.Width = 50
      '
      'FechaNota
      '
      Me.FechaNota.DataPropertyName = "FechaNota"
      DataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm"
      Me.FechaNota.DefaultCellStyle = DataGridViewCellStyle3
      Me.FechaNota.HeaderText = "Fecha Nota"
      Me.FechaNota.Name = "FechaNota"
      Me.FechaNota.ReadOnly = True
      '
      'IdEstado
      '
      Me.IdEstado.DataPropertyName = "IdEstado"
      Me.IdEstado.HeaderText = "IdEstado"
      Me.IdEstado.Name = "IdEstado"
      Me.IdEstado.ReadOnly = True
      Me.IdEstado.Visible = False
      '
      'NombreEstado
      '
      Me.NombreEstado.DataPropertyName = "NombreEstado"
      Me.NombreEstado.HeaderText = "Estado"
      Me.NombreEstado.Name = "NombreEstado"
      Me.NombreEstado.ReadOnly = True
      Me.NombreEstado.Width = 80
      '
      'FechaEstado
      '
      Me.FechaEstado.DataPropertyName = "FechaEstado"
      DataGridViewCellStyle4.Format = "dd/MM/yyyy HH:mm"
      Me.FechaEstado.DefaultCellStyle = DataGridViewCellStyle4
      Me.FechaEstado.HeaderText = "Fecha Estado"
      Me.FechaEstado.Name = "FechaEstado"
      Me.FechaEstado.ReadOnly = True
      '
      'IdProducto
      '
      Me.IdProducto.DataPropertyName = "IdProducto"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdProducto.DefaultCellStyle = DataGridViewCellStyle5
      Me.IdProducto.HeaderText = "Código"
      Me.IdProducto.Name = "IdProducto"
      Me.IdProducto.ReadOnly = True
      Me.IdProducto.Width = 70
      '
      'Producto
      '
      Me.Producto.DataPropertyName = "NombreProducto"
      Me.Producto.HeaderText = "Producto"
      Me.Producto.Name = "Producto"
      Me.Producto.ReadOnly = True
      Me.Producto.Width = 215
      '
      'Cantidad
      '
      Me.Cantidad.DataPropertyName = "CantidadProductos"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle6
      Me.Cantidad.HeaderText = "Cant."
      Me.Cantidad.Name = "Cantidad"
      Me.Cantidad.ReadOnly = True
      Me.Cantidad.Width = 50
      '
      'DefectoProducto
      '
      Me.DefectoProducto.DataPropertyName = "DefectoProducto"
      Me.DefectoProducto.HeaderText = "Defecto"
      Me.DefectoProducto.Name = "DefectoProducto"
      Me.DefectoProducto.ReadOnly = True
      Me.DefectoProducto.Width = 150
      '
      'CostoReparacion
      '
      Me.CostoReparacion.DataPropertyName = "CostoReparacion"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.CostoReparacion.DefaultCellStyle = DataGridViewCellStyle7
      Me.CostoReparacion.HeaderText = "Costo Reparación"
      Me.CostoReparacion.Name = "CostoReparacion"
      Me.CostoReparacion.ReadOnly = True
      Me.CostoReparacion.Width = 70
      '
      'TipoDocumento
      '
      Me.TipoDocumento.DataPropertyName = "TipoDocumento"
      Me.TipoDocumento.HeaderText = "Tipo Doc."
      Me.TipoDocumento.Name = "TipoDocumento"
      Me.TipoDocumento.ReadOnly = True
      Me.TipoDocumento.Width = 40
      '
      'NroDocumento
      '
      Me.NroDocumento.DataPropertyName = "NroDocumento"
      Me.NroDocumento.HeaderText = "Nro. Doc."
      Me.NroDocumento.Name = "NroDocumento"
      Me.NroDocumento.ReadOnly = True
      Me.NroDocumento.Width = 70
      '
      'NombreCliente
      '
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "Cliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      Me.NombreCliente.Width = 130
      '
      'Observacion
      '
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observación"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.ReadOnly = True
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.ReadOnly = True
      Me.IdSucursal.Visible = False
      '
      'NroOperacion
      '
      Me.NroOperacion.DataPropertyName = "NroOperacion"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroOperacion.DefaultCellStyle = DataGridViewCellStyle8
      Me.NroOperacion.HeaderText = "Operac."
      Me.NroOperacion.Name = "NroOperacion"
      Me.NroOperacion.ReadOnly = True
      Me.NroOperacion.Width = 70
      '
      'EstaPrestado
      '
      Me.EstaPrestado.DataPropertyName = "EstaPrestado"
      Me.EstaPrestado.FalseValue = "0"
      Me.EstaPrestado.HeaderText = "Esta Prestado"
      Me.EstaPrestado.Name = "EstaPrestado"
      Me.EstaPrestado.ReadOnly = True
      Me.EstaPrestado.TrueValue = "1"
      Me.EstaPrestado.Width = 60
      '
      'IdProductoPrestado
      '
      Me.IdProductoPrestado.DataPropertyName = "IdProductoPrestado"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdProductoPrestado.DefaultCellStyle = DataGridViewCellStyle9
      Me.IdProductoPrestado.HeaderText = "Cod. Prestado"
      Me.IdProductoPrestado.Name = "IdProductoPrestado"
      Me.IdProductoPrestado.ReadOnly = True
      Me.IdProductoPrestado.Width = 70
      '
      'ProductoPrestado
      '
      Me.ProductoPrestado.DataPropertyName = "NombreProductoPrestado"
      Me.ProductoPrestado.HeaderText = "ProductoPrestado"
      Me.ProductoPrestado.Name = "ProductoPrestado"
      Me.ProductoPrestado.ReadOnly = True
      Me.ProductoPrestado.Width = 215
      '
      'CantidadPrestada
      '
      Me.CantidadPrestada.DataPropertyName = "CantidadPrestada"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CantidadPrestada.DefaultCellStyle = DataGridViewCellStyle10
      Me.CantidadPrestada.HeaderText = "Cant. Prestada"
      Me.CantidadPrestada.Name = "CantidadPrestada"
      Me.CantidadPrestada.ReadOnly = True
      Me.CantidadPrestada.Width = 50
      '
      'ObservacionPrestamo
      '
      Me.ObservacionPrestamo.DataPropertyName = "ObservacionPrestamo"
      Me.ObservacionPrestamo.HeaderText = "Observac. Prestamo"
      Me.ObservacionPrestamo.Name = "ObservacionPrestamo"
      Me.ObservacionPrestamo.ReadOnly = True
      '
      'TipoDocProveedor
      '
      Me.TipoDocProveedor.DataPropertyName = "TipoDocProveedor"
      Me.TipoDocProveedor.HeaderText = "Tipo Doc. Proveedor"
      Me.TipoDocProveedor.Name = "TipoDocProveedor"
      Me.TipoDocProveedor.ReadOnly = True
      Me.TipoDocProveedor.Width = 70
      '
      'NroDocProveedor
      '
      Me.NroDocProveedor.DataPropertyName = "NroDocProveedor"
      Me.NroDocProveedor.HeaderText = "Nro. Doc. Proveedor"
      Me.NroDocProveedor.Name = "NroDocProveedor"
      Me.NroDocProveedor.ReadOnly = True
      '
      'NombreProveedor
      '
      Me.NombreProveedor.DataPropertyName = "NombreProveedor"
      Me.NombreProveedor.HeaderText = "Nombre Proveedor"
      Me.NombreProveedor.Name = "NombreProveedor"
      Me.NombreProveedor.ReadOnly = True
      Me.NombreProveedor.Width = 150
      '
      'AdministracionNotasRecepcionF
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(949, 479)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "AdministracionNotasRecepcionF"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Administración de Notas de Recepción"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbEstado As Eniac.Controles.ComboBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tslTexto As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents lblFechaEnvioHasta As Eniac.Controles.Label
   Friend WithEvents dtpFechaEnvioHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaEnvioDesde As Eniac.Controles.Label
   Friend WithEvents dtpFechaEnvioDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents tsbImprimirNota As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbEditarNota As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents lblFechaEnvio As Eniac.Controles.Label
   Friend WithEvents NroNota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaNota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdEstado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreEstado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaEstado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DefectoProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CostoReparacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroOperacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents EstaPrestado As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents IdProductoPrestado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ProductoPrestado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CantidadPrestada As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ObservacionPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
