<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CartasPendientes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CartasPendientes))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.chbPorCliente = New Eniac.Controles.CheckBox()
      Me.llbOperacion = New Eniac.Controles.LinkLabel()
      Me.txtNroOperacion = New Eniac.Controles.TextBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.cmbCobradores = New Eniac.Controles.ComboBox()
      Me.chbConCobrador = New Eniac.Controles.CheckBox()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.dgvClientes = New Eniac.Controles.DataGridView()
      Me.btnEmitirCarta = New Eniac.Controles.Button()
      Me.cmbTipoCarta = New Eniac.Controles.ComboBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Celular = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbPendientes.SuspendLayout()
      CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.chbPorCliente)
      Me.grbPendientes.Controls.Add(Me.llbOperacion)
      Me.grbPendientes.Controls.Add(Me.txtNroOperacion)
      Me.grbPendientes.Controls.Add(Me.bscCodigoCliente)
      Me.grbPendientes.Controls.Add(Me.bscCliente)
      Me.grbPendientes.Controls.Add(Me.lblCodigoCliente)
      Me.grbPendientes.Controls.Add(Me.lblNombre)
      Me.grbPendientes.Controls.Add(Me.cmbCobradores)
      Me.grbPendientes.Controls.Add(Me.chbConCobrador)
      Me.grbPendientes.Controls.Add(Me.btnBuscar)
      Me.grbPendientes.Controls.Add(Me.dtpHasta)
      Me.grbPendientes.Controls.Add(Me.dtpDesde)
      Me.grbPendientes.Controls.Add(Me.lblHasta)
      Me.grbPendientes.Controls.Add(Me.lblDesde)
      Me.grbPendientes.Location = New System.Drawing.Point(12, 25)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(961, 145)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'chbPorCliente
      '
      Me.chbPorCliente.AutoSize = True
      Me.chbPorCliente.BindearPropiedadControl = Nothing
      Me.chbPorCliente.BindearPropiedadEntidad = Nothing
      Me.chbPorCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chbPorCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPorCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPorCliente.IsPK = False
      Me.chbPorCliente.IsRequired = False
      Me.chbPorCliente.Key = Nothing
      Me.chbPorCliente.LabelAsoc = Nothing
      Me.chbPorCliente.Location = New System.Drawing.Point(13, 75)
      Me.chbPorCliente.Name = "chbPorCliente"
      Me.chbPorCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbPorCliente.TabIndex = 4
      Me.chbPorCliente.Text = "Cliente"
      Me.chbPorCliente.UseVisualStyleBackColor = True
      '
      'llbOperacion
      '
      Me.llbOperacion.AutoSize = True
      Me.llbOperacion.Location = New System.Drawing.Point(476, 58)
      Me.llbOperacion.Name = "llbOperacion"
      Me.llbOperacion.Size = New System.Drawing.Size(79, 13)
      Me.llbOperacion.TabIndex = 12
      Me.llbOperacion.TabStop = True
      Me.llbOperacion.Text = "Nro. Operación"
      '
      'txtNroOperacion
      '
      Me.txtNroOperacion.BindearPropiedadControl = Nothing
      Me.txtNroOperacion.BindearPropiedadEntidad = Nothing
      Me.txtNroOperacion.Enabled = False
      Me.txtNroOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNroOperacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroOperacion.Formato = ""
      Me.txtNroOperacion.IsDecimal = False
      Me.txtNroOperacion.IsNumber = True
      Me.txtNroOperacion.IsPK = False
      Me.txtNroOperacion.IsRequired = False
      Me.txtNroOperacion.Key = ""
      Me.txtNroOperacion.LabelAsoc = Nothing
      Me.txtNroOperacion.Location = New System.Drawing.Point(479, 73)
      Me.txtNroOperacion.Name = "txtNroOperacion"
      Me.txtNroOperacion.ReadOnly = True
      Me.txtNroOperacion.Size = New System.Drawing.Size(82, 20)
      Me.txtNroOperacion.TabIndex = 11
      Me.txtNroOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(84, 73)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoCliente.TabIndex = 7
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(84, 56)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 8
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
      Me.bscCliente.Location = New System.Drawing.Point(207, 72)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(262, 23)
      Me.bscCliente.TabIndex = 9
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(204, 57)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 10
      Me.lblNombre.Text = "Nombre"
      '
      'cmbCobradores
      '
      Me.cmbCobradores.BindearPropiedadControl = Nothing
      Me.cmbCobradores.BindearPropiedadEntidad = Nothing
      Me.cmbCobradores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCobradores.Enabled = False
      Me.cmbCobradores.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCobradores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCobradores.FormattingEnabled = True
      Me.cmbCobradores.IsPK = False
      Me.cmbCobradores.IsRequired = False
      Me.cmbCobradores.Key = Nothing
      Me.cmbCobradores.LabelAsoc = Nothing
      Me.cmbCobradores.Location = New System.Drawing.Point(84, 108)
      Me.cmbCobradores.Name = "cmbCobradores"
      Me.cmbCobradores.Size = New System.Drawing.Size(149, 21)
      Me.cmbCobradores.TabIndex = 14
      '
      'chbConCobrador
      '
      Me.chbConCobrador.AutoSize = True
      Me.chbConCobrador.BindearPropiedadControl = Nothing
      Me.chbConCobrador.BindearPropiedadEntidad = Nothing
      Me.chbConCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chbConCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConCobrador.IsPK = False
      Me.chbConCobrador.IsRequired = False
      Me.chbConCobrador.Key = Nothing
      Me.chbConCobrador.LabelAsoc = Nothing
      Me.chbConCobrador.Location = New System.Drawing.Point(13, 110)
      Me.chbConCobrador.Name = "chbConCobrador"
      Me.chbConCobrador.Size = New System.Drawing.Size(69, 17)
      Me.chbConCobrador.TabIndex = 13
      Me.chbConCobrador.Text = "Cobrador"
      Me.chbConCobrador.UseVisualStyleBackColor = True
      '
      'btnBuscar
      '
      Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscar.Location = New System.Drawing.Point(787, 47)
      Me.btnBuscar.Name = "btnBuscar"
      Me.btnBuscar.Size = New System.Drawing.Size(100, 45)
      Me.btnBuscar.TabIndex = 15
      Me.btnBuscar.Text = "&Consultar"
      Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnBuscar.UseVisualStyleBackColor = True
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
      Me.dtpHasta.Location = New System.Drawing.Point(214, 25)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
      Me.dtpHasta.TabIndex = 3
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(170, 29)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 2
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
      Me.dtpDesde.Location = New System.Drawing.Point(58, 25)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 1
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(14, 29)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 0
      Me.lblDesde.Text = "Desde"
      '
      'dgvClientes
      '
      Me.dgvClientes.AllowUserToAddRows = False
      Me.dgvClientes.AllowUserToDeleteRows = False
      Me.dgvClientes.AllowUserToResizeRows = False
      Me.dgvClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSucursal, Me.Check, Me.IdCliente, Me.NombreCliente, Me.FechaVencimiento, Me.NroOperacion, Me.NroCuota, Me.Importe, Me.Saldo, Me.Direccion, Me.Telefono, Me.Celular})
      Me.dgvClientes.Location = New System.Drawing.Point(12, 176)
      Me.dgvClientes.Name = "dgvClientes"
      Me.dgvClientes.RowHeadersVisible = False
      Me.dgvClientes.RowHeadersWidth = 20
      Me.dgvClientes.Size = New System.Drawing.Size(960, 272)
      Me.dgvClientes.TabIndex = 1
      '
      'btnEmitirCarta
      '
      Me.btnEmitirCarta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEmitirCarta.Enabled = False
      Me.btnEmitirCarta.Image = Global.Eniac.Win.My.Resources.Resources.document_add
      Me.btnEmitirCarta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnEmitirCarta.Location = New System.Drawing.Point(680, 455)
      Me.btnEmitirCarta.Name = "btnEmitirCarta"
      Me.btnEmitirCarta.Size = New System.Drawing.Size(136, 45)
      Me.btnEmitirCarta.TabIndex = 3
      Me.btnEmitirCarta.Text = "&Emitir carta del tipo"
      Me.btnEmitirCarta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnEmitirCarta.UseVisualStyleBackColor = True
      '
      'cmbTipoCarta
      '
      Me.cmbTipoCarta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTipoCarta.BindearPropiedadControl = Nothing
      Me.cmbTipoCarta.BindearPropiedadEntidad = Nothing
      Me.cmbTipoCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoCarta.Enabled = False
      Me.cmbTipoCarta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoCarta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoCarta.FormattingEnabled = True
      Me.cmbTipoCarta.IsPK = False
      Me.cmbTipoCarta.IsRequired = False
      Me.cmbTipoCarta.Key = Nothing
      Me.cmbTipoCarta.LabelAsoc = Nothing
      Me.cmbTipoCarta.Location = New System.Drawing.Point(823, 456)
      Me.cmbTipoCarta.Name = "cmbTipoCarta"
      Me.cmbTipoCarta.Size = New System.Drawing.Size(149, 21)
      Me.cmbTipoCarta.TabIndex = 4
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 5
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(81, 26)
      Me.tsbRefrescar.Text = "&Refrescar"
      Me.tsbRefrescar.ToolTipText = "Cerrar el formulario"
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
      'chbTodos
      '
      Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.ImageIndex = 3
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(12, 466)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(119, 24)
      Me.chbTodos.TabIndex = 2
      Me.chbTodos.Text = "Chequear todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.Visible = False
      '
      'Check
      '
      Me.Check.FillWeight = 50.0!
      Me.Check.HeaderText = ""
      Me.Check.Name = "Check"
      Me.Check.Width = 40
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
      Me.IdCliente.Width = 65
      '
      'NombreCliente
      '
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "Cliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      Me.NombreCliente.Width = 200
      '
      'FechaVencimiento
      '
      Me.FechaVencimiento.DataPropertyName = "FechaVencimiento"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Format = "dd/MM/yyyy"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle2
      Me.FechaVencimiento.HeaderText = "Venc."
      Me.FechaVencimiento.Name = "FechaVencimiento"
      Me.FechaVencimiento.ReadOnly = True
      Me.FechaVencimiento.Width = 70
      '
      'NroOperacion
      '
      Me.NroOperacion.DataPropertyName = "NroOperacion"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroOperacion.DefaultCellStyle = DataGridViewCellStyle3
      Me.NroOperacion.HeaderText = "Oper."
      Me.NroOperacion.Name = "NroOperacion"
      Me.NroOperacion.ReadOnly = True
      Me.NroOperacion.Width = 40
      '
      'NroCuota
      '
      Me.NroCuota.DataPropertyName = "NroCuota"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroCuota.DefaultCellStyle = DataGridViewCellStyle4
      Me.NroCuota.HeaderText = "Cuota"
      Me.NroCuota.Name = "NroCuota"
      Me.NroCuota.ReadOnly = True
      Me.NroCuota.Width = 40
      '
      'Importe
      '
      Me.Importe.DataPropertyName = "Importe"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle5.Format = "N2"
      DataGridViewCellStyle5.NullValue = Nothing
      Me.Importe.DefaultCellStyle = DataGridViewCellStyle5
      Me.Importe.HeaderText = "Importe"
      Me.Importe.Name = "Importe"
      Me.Importe.ReadOnly = True
      Me.Importe.Width = 50
      '
      'Saldo
      '
      Me.Saldo.DataPropertyName = "Saldo"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red
      DataGridViewCellStyle6.Format = "N2"
      Me.Saldo.DefaultCellStyle = DataGridViewCellStyle6
      Me.Saldo.HeaderText = "Saldo"
      Me.Saldo.Name = "Saldo"
      Me.Saldo.ReadOnly = True
      Me.Saldo.Width = 50
      '
      'Direccion
      '
      Me.Direccion.DataPropertyName = "Direccion"
      Me.Direccion.HeaderText = "Dirección"
      Me.Direccion.Name = "Direccion"
      Me.Direccion.ReadOnly = True
      Me.Direccion.Width = 160
      '
      'Telefono
      '
      Me.Telefono.DataPropertyName = "Telefono"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Telefono.DefaultCellStyle = DataGridViewCellStyle7
      Me.Telefono.HeaderText = "Telefono"
      Me.Telefono.Name = "Telefono"
      Me.Telefono.ReadOnly = True
      '
      'Celular
      '
      Me.Celular.DataPropertyName = "Celular"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Celular.DefaultCellStyle = DataGridViewCellStyle8
      Me.Celular.HeaderText = "Celular"
      Me.Celular.Name = "Celular"
      Me.Celular.ReadOnly = True
      '
      'CartasPendientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 509)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.cmbTipoCarta)
      Me.Controls.Add(Me.btnEmitirCarta)
      Me.Controls.Add(Me.dgvClientes)
      Me.Controls.Add(Me.grbPendientes)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CartasPendientes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Emisión de cartas para deudores"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents chbConCobrador As Eniac.Controles.CheckBox
   Friend WithEvents cmbCobradores As Eniac.Controles.ComboBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents dgvClientes As Eniac.Controles.DataGridView
   Friend WithEvents btnEmitirCarta As Eniac.Controles.Button
   Friend WithEvents cmbTipoCarta As Eniac.Controles.ComboBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbPorCliente As Eniac.Controles.CheckBox
   Friend WithEvents llbOperacion As Eniac.Controles.LinkLabel
   Friend WithEvents txtNroOperacion As Eniac.Controles.TextBox
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Check As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroOperacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroCuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Celular As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
