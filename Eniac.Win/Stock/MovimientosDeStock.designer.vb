<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MovimientosDeStock
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovimientosDeStock))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion2")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NrosSerie")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLote")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VtoLote")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tlpMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtTotalGeneral = New Eniac.Controles.TextBox()
        Me.lblTotalGeneral = New Eniac.Controles.Label()
        Me.grbMovimiento = New System.Windows.Forms.GroupBox()
        Me.grbMovimientoDestino = New System.Windows.Forms.GroupBox()
        Me.lblSucursalDestino = New Eniac.Controles.Label()
        Me.cmbSucursalDestino = New Eniac.Controles.ComboBox()
        Me.grbMovimientoOrigen = New System.Windows.Forms.GroupBox()
        Me.cmbSucursalOrigen = New Eniac.Controles.Label()
        Me.lblSucursalOrigen = New Eniac.Controles.Label()
        Me.cmbEmpleado = New Eniac.Controles.ComboBox()
        Me.lblEmpleado = New Eniac.Controles.Label()
        Me.dtpFecha = New Eniac.Controles.DateTimePicker()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.cboTipoMovimiento = New Eniac.Controles.ComboBox()
        Me.lblTipoMovimiento = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.lblObservacion = New Eniac.Controles.Label()
        Me.grbProveedor = New System.Windows.Forms.GroupBox()
        Me.txtCategoriaFiscal = New Eniac.Controles.TextBox()
        Me.lblCategoriaFiscal = New System.Windows.Forms.Label()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.lblNombreProveedor = New Eniac.Controles.Label()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.grbProducto = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnLimpiarProducto = New Eniac.Controles.Button()
        Me.txtStock = New Eniac.Controles.TextBox()
        Me.llbTotalProducto = New Eniac.Controles.Label()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.lblCodProducto = New Eniac.Controles.Label()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.lblStock = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblPrecio = New Eniac.Controles.Label()
        Me.txtPrecio = New Eniac.Controles.TextBox()
        Me.txtTotalProducto = New Eniac.Controles.TextBox()
        Me.lblCantidad = New Eniac.Controles.Label()
        Me.txtCantidad = New Eniac.Controles.TextBox()
        Me.pnlDepositosUbicaciones = New System.Windows.Forms.Panel()
        Me.Label1 = New Eniac.Controles.Label()
        Me.lblDepositoOrigen = New Eniac.Controles.Label()
        Me.cmbUbicacionOrigen = New Eniac.Controles.ComboBox()
        Me.cmbDepositoOrigen = New Eniac.Controles.ComboBox()
        Me.grbDestinoDepositoUbicacion = New System.Windows.Forms.Panel()
        Me.cmbDepositoDestino = New Eniac.Controles.ComboBox()
        Me.lblDepositoDestino = New Eniac.Controles.Label()
        Me.cmbUbicacionDestino = New Eniac.Controles.ComboBox()
        Me.lblUbicacionDestino = New Eniac.Controles.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.ugProductos = New Eniac.Win.UltraGridEditable()
        Me.txtStock2 = New Eniac.Controles.TextBox()
        Me.lblStock2 = New Eniac.Controles.Label()
        Me.cmbCantidadAfectada = New Eniac.Controles.ComboBox()
        Me.lblCantidadAfectada = New Eniac.Controles.Label()
        Me.tspFichas = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevoComprobante = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbInvocarComprobantes = New System.Windows.Forms.ToolStripButton()
        Me.tsbLeerArchivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado.SuspendLayout()
        Me.grbMovimiento.SuspendLayout()
        Me.grbMovimientoDestino.SuspendLayout()
        Me.grbMovimientoOrigen.SuspendLayout()
        Me.grbProveedor.SuspendLayout()
        Me.grbProducto.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlDepositosUbicaciones.SuspendLayout()
        Me.grbDestinoDepositoUbicacion.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tspFichas.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMensaje
        '
        Me.tlpMensaje.IsBalloon = True
        Me.tlpMensaje.ShowAlways = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(947, 22)
        Me.stsStado.TabIndex = 19
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(868, 17)
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
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.BindearPropiedadControl = Nothing
        Me.txtTotalGeneral.BindearPropiedadEntidad = Nothing
        Me.txtTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalGeneral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalGeneral.Formato = "##,##0.00"
        Me.txtTotalGeneral.IsDecimal = True
        Me.txtTotalGeneral.IsNumber = True
        Me.txtTotalGeneral.IsPK = False
        Me.txtTotalGeneral.IsRequired = False
        Me.txtTotalGeneral.Key = ""
        Me.txtTotalGeneral.LabelAsoc = Nothing
        Me.txtTotalGeneral.Location = New System.Drawing.Point(849, 148)
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.ReadOnly = True
        Me.txtTotalGeneral.Size = New System.Drawing.Size(84, 21)
        Me.txtTotalGeneral.TabIndex = 17
        Me.txtTotalGeneral.TabStop = False
        Me.txtTotalGeneral.Text = "0.00"
        Me.txtTotalGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalGeneral
        '
        Me.lblTotalGeneral.AutoSize = True
        Me.lblTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalGeneral.LabelAsoc = Nothing
        Me.lblTotalGeneral.Location = New System.Drawing.Point(802, 152)
        Me.lblTotalGeneral.Name = "lblTotalGeneral"
        Me.lblTotalGeneral.Size = New System.Drawing.Size(36, 13)
        Me.lblTotalGeneral.TabIndex = 16
        Me.lblTotalGeneral.Text = "Total"
        '
        'grbMovimiento
        '
        Me.grbMovimiento.Controls.Add(Me.grbMovimientoDestino)
        Me.grbMovimiento.Controls.Add(Me.grbMovimientoOrigen)
        Me.grbMovimiento.Controls.Add(Me.cmbEmpleado)
        Me.grbMovimiento.Controls.Add(Me.lblEmpleado)
        Me.grbMovimiento.Controls.Add(Me.dtpFecha)
        Me.grbMovimiento.Controls.Add(Me.lblFecha)
        Me.grbMovimiento.Controls.Add(Me.cboTipoMovimiento)
        Me.grbMovimiento.Controls.Add(Me.txtObservacion)
        Me.grbMovimiento.Controls.Add(Me.lblObservacion)
        Me.grbMovimiento.Controls.Add(Me.lblTipoMovimiento)
        Me.grbMovimiento.Location = New System.Drawing.Point(12, 26)
        Me.grbMovimiento.Name = "grbMovimiento"
        Me.grbMovimiento.Size = New System.Drawing.Size(923, 101)
        Me.grbMovimiento.TabIndex = 0
        Me.grbMovimiento.TabStop = False
        '
        'grbMovimientoDestino
        '
        Me.grbMovimientoDestino.Controls.Add(Me.lblSucursalDestino)
        Me.grbMovimientoDestino.Controls.Add(Me.cmbSucursalDestino)
        Me.grbMovimientoDestino.Location = New System.Drawing.Point(642, 9)
        Me.grbMovimientoDestino.Name = "grbMovimientoDestino"
        Me.grbMovimientoDestino.Size = New System.Drawing.Size(227, 53)
        Me.grbMovimientoDestino.TabIndex = 38
        Me.grbMovimientoDestino.TabStop = False
        Me.grbMovimientoDestino.Text = "Destino"
        Me.grbMovimientoDestino.Visible = False
        '
        'lblSucursalDestino
        '
        Me.lblSucursalDestino.AutoSize = True
        Me.lblSucursalDestino.LabelAsoc = Nothing
        Me.lblSucursalDestino.Location = New System.Drawing.Point(8, 20)
        Me.lblSucursalDestino.Name = "lblSucursalDestino"
        Me.lblSucursalDestino.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursalDestino.TabIndex = 35
        Me.lblSucursalDestino.Text = "Sucursal"
        '
        'cmbSucursalDestino
        '
        Me.cmbSucursalDestino.BindearPropiedadControl = Nothing
        Me.cmbSucursalDestino.BindearPropiedadEntidad = Nothing
        Me.cmbSucursalDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursalDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursalDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursalDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalDestino.FormattingEnabled = True
        Me.cmbSucursalDestino.IsPK = False
        Me.cmbSucursalDestino.IsRequired = False
        Me.cmbSucursalDestino.Key = Nothing
        Me.cmbSucursalDestino.LabelAsoc = Me.lblSucursalDestino
        Me.cmbSucursalDestino.Location = New System.Drawing.Point(62, 17)
        Me.cmbSucursalDestino.Name = "cmbSucursalDestino"
        Me.cmbSucursalDestino.Size = New System.Drawing.Size(156, 21)
        Me.cmbSucursalDestino.TabIndex = 34
        '
        'grbMovimientoOrigen
        '
        Me.grbMovimientoOrigen.Controls.Add(Me.cmbSucursalOrigen)
        Me.grbMovimientoOrigen.Controls.Add(Me.lblSucursalOrigen)
        Me.grbMovimientoOrigen.Location = New System.Drawing.Point(403, 9)
        Me.grbMovimientoOrigen.Name = "grbMovimientoOrigen"
        Me.grbMovimientoOrigen.Size = New System.Drawing.Size(227, 53)
        Me.grbMovimientoOrigen.TabIndex = 36
        Me.grbMovimientoOrigen.TabStop = False
        Me.grbMovimientoOrigen.Text = "Origen"
        '
        'cmbSucursalOrigen
        '
        Me.cmbSucursalOrigen.AutoSize = True
        Me.cmbSucursalOrigen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalOrigen.LabelAsoc = Nothing
        Me.cmbSucursalOrigen.Location = New System.Drawing.Point(65, 20)
        Me.cmbSucursalOrigen.Name = "cmbSucursalOrigen"
        Me.cmbSucursalOrigen.Size = New System.Drawing.Size(10, 13)
        Me.cmbSucursalOrigen.TabIndex = 38
        Me.cmbSucursalOrigen.Text = "-"
        '
        'lblSucursalOrigen
        '
        Me.lblSucursalOrigen.AutoSize = True
        Me.lblSucursalOrigen.LabelAsoc = Nothing
        Me.lblSucursalOrigen.Location = New System.Drawing.Point(8, 20)
        Me.lblSucursalOrigen.Name = "lblSucursalOrigen"
        Me.lblSucursalOrigen.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursalOrigen.TabIndex = 35
        Me.lblSucursalOrigen.Text = "Sucursal"
        '
        'cmbEmpleado
        '
        Me.cmbEmpleado.BindearPropiedadControl = Nothing
        Me.cmbEmpleado.BindearPropiedadEntidad = Nothing
        Me.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmpleado.FormattingEnabled = True
        Me.cmbEmpleado.IsPK = False
        Me.cmbEmpleado.IsRequired = False
        Me.cmbEmpleado.Key = Nothing
        Me.cmbEmpleado.LabelAsoc = Me.lblEmpleado
        Me.cmbEmpleado.Location = New System.Drawing.Point(90, 41)
        Me.cmbEmpleado.Name = "cmbEmpleado"
        Me.cmbEmpleado.Size = New System.Drawing.Size(307, 21)
        Me.cmbEmpleado.TabIndex = 34
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.LabelAsoc = Nothing
        Me.lblEmpleado.Location = New System.Drawing.Point(6, 45)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(54, 13)
        Me.lblEmpleado.TabIndex = 35
        Me.lblEmpleado.Text = "Empleado"
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = Nothing
        Me.dtpFecha.BindearPropiedadEntidad = Nothing
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFecha
        Me.dtpFecha.Location = New System.Drawing.Point(313, 14)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(84, 20)
        Me.dtpFecha.TabIndex = 5
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(275, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 31
        Me.lblFecha.Text = "Fecha"
        '
        'cboTipoMovimiento
        '
        Me.cboTipoMovimiento.BindearPropiedadControl = Nothing
        Me.cboTipoMovimiento.BindearPropiedadEntidad = Nothing
        Me.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoMovimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.cboTipoMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboTipoMovimiento.FormattingEnabled = True
        Me.cboTipoMovimiento.IsPK = False
        Me.cboTipoMovimiento.IsRequired = False
        Me.cboTipoMovimiento.Key = Nothing
        Me.cboTipoMovimiento.LabelAsoc = Me.lblTipoMovimiento
        Me.cboTipoMovimiento.Location = New System.Drawing.Point(90, 14)
        Me.cboTipoMovimiento.Name = "cboTipoMovimiento"
        Me.cboTipoMovimiento.Size = New System.Drawing.Size(179, 21)
        Me.cboTipoMovimiento.TabIndex = 0
        '
        'lblTipoMovimiento
        '
        Me.lblTipoMovimiento.AutoSize = True
        Me.lblTipoMovimiento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipoMovimiento.LabelAsoc = Nothing
        Me.lblTipoMovimiento.Location = New System.Drawing.Point(4, 18)
        Me.lblTipoMovimiento.Name = "lblTipoMovimiento"
        Me.lblTipoMovimiento.Size = New System.Drawing.Size(85, 13)
        Me.lblTipoMovimiento.TabIndex = 2
        Me.lblTipoMovimiento.Text = "Tipo Movimiento"
        '
        'txtObservacion
        '
        Me.txtObservacion.BackColor = System.Drawing.Color.White
        Me.txtObservacion.BindearPropiedadControl = Nothing
        Me.txtObservacion.BindearPropiedadEntidad = Nothing
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = ""
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = ""
        Me.txtObservacion.LabelAsoc = Me.lblObservacion
        Me.txtObservacion.Location = New System.Drawing.Point(90, 68)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(780, 20)
        Me.txtObservacion.TabIndex = 6
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(6, 71)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 7
        Me.lblObservacion.Text = "Observación"
        '
        'grbProveedor
        '
        Me.grbProveedor.Controls.Add(Me.txtCategoriaFiscal)
        Me.grbProveedor.Controls.Add(Me.lblCategoriaFiscal)
        Me.grbProveedor.Controls.Add(Me.bscCodigoProveedor)
        Me.grbProveedor.Controls.Add(Me.bscProveedor)
        Me.grbProveedor.Controls.Add(Me.lblCodigoProveedor)
        Me.grbProveedor.Controls.Add(Me.lblNombreProveedor)
        Me.grbProveedor.Location = New System.Drawing.Point(12, 130)
        Me.grbProveedor.Name = "grbProveedor"
        Me.grbProveedor.Size = New System.Drawing.Size(784, 46)
        Me.grbProveedor.TabIndex = 1
        Me.grbProveedor.TabStop = False
        Me.grbProveedor.Text = "Proveedor"
        '
        'txtCategoriaFiscal
        '
        Me.txtCategoriaFiscal.BindearPropiedadControl = Nothing
        Me.txtCategoriaFiscal.BindearPropiedadEntidad = Nothing
        Me.txtCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCategoriaFiscal.Formato = ""
        Me.txtCategoriaFiscal.IsDecimal = False
        Me.txtCategoriaFiscal.IsNumber = False
        Me.txtCategoriaFiscal.IsPK = False
        Me.txtCategoriaFiscal.IsRequired = False
        Me.txtCategoriaFiscal.Key = ""
        Me.txtCategoriaFiscal.LabelAsoc = Nothing
        Me.txtCategoriaFiscal.Location = New System.Drawing.Point(590, 18)
        Me.txtCategoriaFiscal.Name = "txtCategoriaFiscal"
        Me.txtCategoriaFiscal.ReadOnly = True
        Me.txtCategoriaFiscal.Size = New System.Drawing.Size(184, 20)
        Me.txtCategoriaFiscal.TabIndex = 36
        Me.txtCategoriaFiscal.TabStop = False
        '
        'lblCategoriaFiscal
        '
        Me.lblCategoriaFiscal.AutoSize = True
        Me.lblCategoriaFiscal.Location = New System.Drawing.Point(502, 22)
        Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
        Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
        Me.lblCategoriaFiscal.TabIndex = 37
        Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(55, 18)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoProveedor.TabIndex = 1
        Me.bscCodigoProveedor.Titulo = Nothing
        '
        'bscProveedor
        '
        Me.bscProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.bscProveedor.LabelAsoc = Me.lblNombreProveedor
        Me.bscProveedor.Location = New System.Drawing.Point(202, 18)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(297, 20)
        Me.bscProveedor.TabIndex = 2
        Me.bscProveedor.Titulo = Nothing
        '
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.AutoSize = True
        Me.lblNombreProveedor.LabelAsoc = Nothing
        Me.lblNombreProveedor.Location = New System.Drawing.Point(151, 21)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProveedor.TabIndex = 1
        Me.lblNombreProveedor.Text = "Nombre"
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(6, 21)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 2
        Me.lblCodigoProveedor.Text = "Código"
        '
        'grbProducto
        '
        Me.grbProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbProducto.Controls.Add(Me.TableLayoutPanel2)
        Me.grbProducto.Location = New System.Drawing.Point(12, 182)
        Me.grbProducto.Name = "grbProducto"
        Me.grbProducto.Size = New System.Drawing.Size(923, 354)
        Me.grbProducto.TabIndex = 3
        Me.grbProducto.TabStop = False
        Me.grbProducto.Text = "Producto"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ugProductos, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(917, 335)
        Me.TableLayoutPanel2.TabIndex = 1013
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlDepositosUbicaciones)
        Me.FlowLayoutPanel1.Controls.Add(Me.grbDestinoDepositoUbicacion)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(873, 98)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnLimpiarProducto)
        Me.Panel2.Controls.Add(Me.txtStock)
        Me.Panel2.Controls.Add(Me.lblProducto)
        Me.Panel2.Controls.Add(Me.lblCodProducto)
        Me.Panel2.Controls.Add(Me.bscCodigoProducto2)
        Me.Panel2.Controls.Add(Me.lblStock)
        Me.Panel2.Controls.Add(Me.bscProducto2)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(453, 43)
        Me.Panel2.TabIndex = 45
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(3, 10)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(31, 31)
        Me.btnLimpiarProducto.TabIndex = 0
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'txtStock
        '
        Me.txtStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStock.BindearPropiedadControl = Nothing
        Me.txtStock.BindearPropiedadEntidad = Nothing
        Me.txtStock.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStock.Formato = ""
        Me.txtStock.IsDecimal = False
        Me.txtStock.IsNumber = True
        Me.txtStock.IsPK = False
        Me.txtStock.IsRequired = False
        Me.txtStock.Key = ""
        Me.txtStock.LabelAsoc = Me.llbTotalProducto
        Me.txtStock.Location = New System.Drawing.Point(390, -2)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(59, 20)
        Me.txtStock.TabIndex = 7
        Me.txtStock.TabStop = False
        Me.txtStock.Text = "0"
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'llbTotalProducto
        '
        Me.llbTotalProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbTotalProducto.AutoSize = True
        Me.llbTotalProducto.LabelAsoc = Nothing
        Me.llbTotalProducto.Location = New System.Drawing.Point(210, 1)
        Me.llbTotalProducto.Name = "llbTotalProducto"
        Me.llbTotalProducto.Size = New System.Drawing.Size(42, 13)
        Me.llbTotalProducto.TabIndex = 13
        Me.llbTotalProducto.Text = "Importe"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(159, 1)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 3
        Me.lblProducto.Text = "Producto"
        '
        'lblCodProducto
        '
        Me.lblCodProducto.AutoSize = True
        Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodProducto.LabelAsoc = Nothing
        Me.lblCodProducto.Location = New System.Drawing.Point(36, 1)
        Me.lblCodProducto.Name = "lblCodProducto"
        Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodProducto.TabIndex = 1
        Me.lblCodProducto.Text = "Código"
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(39, 20)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(117, 21)
        Me.bscCodigoProducto2.TabIndex = 2
        '
        'lblStock
        '
        Me.lblStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStock.AutoSize = True
        Me.lblStock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStock.LabelAsoc = Nothing
        Me.lblStock.Location = New System.Drawing.Point(339, 1)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(45, 13)
        Me.lblStock.TabIndex = 6
        Me.lblStock.Text = "Stock P"
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
        Me.bscProducto2.Location = New System.Drawing.Point(162, 20)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(287, 21)
        Me.bscProducto2.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblPrecio)
        Me.Panel4.Controls.Add(Me.txtPrecio)
        Me.Panel4.Controls.Add(Me.llbTotalProducto)
        Me.Panel4.Controls.Add(Me.txtTotalProducto)
        Me.Panel4.Controls.Add(Me.lblCantidad)
        Me.Panel4.Controls.Add(Me.txtCantidad)
        Me.Panel4.Location = New System.Drawing.Point(462, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(340, 42)
        Me.Panel4.TabIndex = 46
        '
        'lblPrecio
        '
        Me.lblPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.LabelAsoc = Nothing
        Me.lblPrecio.Location = New System.Drawing.Point(105, 1)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecio.TabIndex = 11
        Me.lblPrecio.Text = "Precio"
        '
        'txtPrecio
        '
        Me.txtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrecio.BindearPropiedadControl = Nothing
        Me.txtPrecio.BindearPropiedadEntidad = Nothing
        Me.txtPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecio.Formato = "##0.00"
        Me.txtPrecio.IsDecimal = True
        Me.txtPrecio.IsNumber = True
        Me.txtPrecio.IsPK = False
        Me.txtPrecio.IsRequired = False
        Me.txtPrecio.Key = ""
        Me.txtPrecio.LabelAsoc = Me.lblPrecio
        Me.txtPrecio.Location = New System.Drawing.Point(108, 20)
        Me.txtPrecio.MaxLength = 10
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(97, 20)
        Me.txtPrecio.TabIndex = 12
        Me.txtPrecio.Text = "0.00"
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalProducto
        '
        Me.txtTotalProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalProducto.BindearPropiedadControl = Nothing
        Me.txtTotalProducto.BindearPropiedadEntidad = Nothing
        Me.txtTotalProducto.Enabled = False
        Me.txtTotalProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalProducto.Formato = "##0.00"
        Me.txtTotalProducto.IsDecimal = False
        Me.txtTotalProducto.IsNumber = True
        Me.txtTotalProducto.IsPK = False
        Me.txtTotalProducto.IsRequired = False
        Me.txtTotalProducto.Key = ""
        Me.txtTotalProducto.LabelAsoc = Me.llbTotalProducto
        Me.txtTotalProducto.Location = New System.Drawing.Point(213, 19)
        Me.txtTotalProducto.MaxLength = 100
        Me.txtTotalProducto.Name = "txtTotalProducto"
        Me.txtTotalProducto.Size = New System.Drawing.Size(119, 20)
        Me.txtTotalProducto.TabIndex = 14
        Me.txtTotalProducto.TabStop = False
        Me.txtTotalProducto.Text = "0.00"
        Me.txtTotalProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidad
        '
        Me.lblCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(7, 1)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 9
        Me.lblCantidad.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "#0.00"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblCantidad
        Me.txtCantidad.Location = New System.Drawing.Point(6, 20)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(96, 20)
        Me.txtCantidad.TabIndex = 10
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlDepositosUbicaciones
        '
        Me.pnlDepositosUbicaciones.Controls.Add(Me.Label1)
        Me.pnlDepositosUbicaciones.Controls.Add(Me.lblDepositoOrigen)
        Me.pnlDepositosUbicaciones.Controls.Add(Me.cmbUbicacionOrigen)
        Me.pnlDepositosUbicaciones.Controls.Add(Me.cmbDepositoOrigen)
        Me.pnlDepositosUbicaciones.Location = New System.Drawing.Point(3, 52)
        Me.pnlDepositosUbicaciones.Name = "pnlDepositosUbicaciones"
        Me.pnlDepositosUbicaciones.Size = New System.Drawing.Size(218, 43)
        Me.pnlDepositosUbicaciones.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(106, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Ubicación"
        '
        'lblDepositoOrigen
        '
        Me.lblDepositoOrigen.AutoSize = True
        Me.lblDepositoOrigen.LabelAsoc = Nothing
        Me.lblDepositoOrigen.Location = New System.Drawing.Point(0, 1)
        Me.lblDepositoOrigen.Name = "lblDepositoOrigen"
        Me.lblDepositoOrigen.Size = New System.Drawing.Size(49, 13)
        Me.lblDepositoOrigen.TabIndex = 5
        Me.lblDepositoOrigen.Text = "Depósito"
        '
        'cmbUbicacionOrigen
        '
        Me.cmbUbicacionOrigen.BindearPropiedadControl = Nothing
        Me.cmbUbicacionOrigen.BindearPropiedadEntidad = Nothing
        Me.cmbUbicacionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionOrigen.Enabled = False
        Me.cmbUbicacionOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacionOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionOrigen.FormattingEnabled = True
        Me.cmbUbicacionOrigen.IsPK = False
        Me.cmbUbicacionOrigen.IsRequired = False
        Me.cmbUbicacionOrigen.Key = Nothing
        Me.cmbUbicacionOrigen.LabelAsoc = Me.Label1
        Me.cmbUbicacionOrigen.Location = New System.Drawing.Point(109, 18)
        Me.cmbUbicacionOrigen.Name = "cmbUbicacionOrigen"
        Me.cmbUbicacionOrigen.Size = New System.Drawing.Size(99, 21)
        Me.cmbUbicacionOrigen.TabIndex = 8
        '
        'cmbDepositoOrigen
        '
        Me.cmbDepositoOrigen.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmbDepositoOrigen.BindearPropiedadControl = Nothing
        Me.cmbDepositoOrigen.BindearPropiedadEntidad = Nothing
        Me.cmbDepositoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoOrigen.Enabled = False
        Me.cmbDepositoOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepositoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoOrigen.FormattingEnabled = True
        Me.cmbDepositoOrigen.IsPK = False
        Me.cmbDepositoOrigen.IsRequired = False
        Me.cmbDepositoOrigen.Key = Nothing
        Me.cmbDepositoOrigen.LabelAsoc = Me.lblDepositoOrigen
        Me.cmbDepositoOrigen.Location = New System.Drawing.Point(4, 18)
        Me.cmbDepositoOrigen.Name = "cmbDepositoOrigen"
        Me.cmbDepositoOrigen.Size = New System.Drawing.Size(99, 21)
        Me.cmbDepositoOrigen.TabIndex = 6
        '
        'grbDestinoDepositoUbicacion
        '
        Me.grbDestinoDepositoUbicacion.Controls.Add(Me.cmbDepositoDestino)
        Me.grbDestinoDepositoUbicacion.Controls.Add(Me.cmbUbicacionDestino)
        Me.grbDestinoDepositoUbicacion.Controls.Add(Me.lblDepositoDestino)
        Me.grbDestinoDepositoUbicacion.Controls.Add(Me.lblUbicacionDestino)
        Me.grbDestinoDepositoUbicacion.Location = New System.Drawing.Point(227, 52)
        Me.grbDestinoDepositoUbicacion.Name = "grbDestinoDepositoUbicacion"
        Me.grbDestinoDepositoUbicacion.Size = New System.Drawing.Size(213, 42)
        Me.grbDestinoDepositoUbicacion.TabIndex = 46
        '
        'cmbDepositoDestino
        '
        Me.cmbDepositoDestino.BindearPropiedadControl = Nothing
        Me.cmbDepositoDestino.BindearPropiedadEntidad = Nothing
        Me.cmbDepositoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepositoDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoDestino.FormattingEnabled = True
        Me.cmbDepositoDestino.IsPK = False
        Me.cmbDepositoDestino.IsRequired = False
        Me.cmbDepositoDestino.Key = Nothing
        Me.cmbDepositoDestino.LabelAsoc = Me.lblDepositoDestino
        Me.cmbDepositoDestino.Location = New System.Drawing.Point(5, 18)
        Me.cmbDepositoDestino.Name = "cmbDepositoDestino"
        Me.cmbDepositoDestino.Size = New System.Drawing.Size(99, 21)
        Me.cmbDepositoDestino.TabIndex = 16
        '
        'lblDepositoDestino
        '
        Me.lblDepositoDestino.AutoSize = True
        Me.lblDepositoDestino.LabelAsoc = Nothing
        Me.lblDepositoDestino.Location = New System.Drawing.Point(2, -1)
        Me.lblDepositoDestino.Name = "lblDepositoDestino"
        Me.lblDepositoDestino.Size = New System.Drawing.Size(88, 13)
        Me.lblDepositoDestino.TabIndex = 15
        Me.lblDepositoDestino.Text = "Depósito Destino"
        '
        'cmbUbicacionDestino
        '
        Me.cmbUbicacionDestino.BindearPropiedadControl = Nothing
        Me.cmbUbicacionDestino.BindearPropiedadEntidad = Nothing
        Me.cmbUbicacionDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacionDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionDestino.FormattingEnabled = True
        Me.cmbUbicacionDestino.IsPK = False
        Me.cmbUbicacionDestino.IsRequired = False
        Me.cmbUbicacionDestino.Key = Nothing
        Me.cmbUbicacionDestino.LabelAsoc = Me.lblUbicacionDestino
        Me.cmbUbicacionDestino.Location = New System.Drawing.Point(109, 18)
        Me.cmbUbicacionDestino.Name = "cmbUbicacionDestino"
        Me.cmbUbicacionDestino.Size = New System.Drawing.Size(99, 21)
        Me.cmbUbicacionDestino.TabIndex = 18
        Me.cmbUbicacionDestino.Visible = False
        '
        'lblUbicacionDestino
        '
        Me.lblUbicacionDestino.AutoSize = True
        Me.lblUbicacionDestino.LabelAsoc = Nothing
        Me.lblUbicacionDestino.Location = New System.Drawing.Point(106, 1)
        Me.lblUbicacionDestino.Name = "lblUbicacionDestino"
        Me.lblUbicacionDestino.Size = New System.Drawing.Size(94, 13)
        Me.lblUbicacionDestino.TabIndex = 17
        Me.lblUbicacionDestino.Text = "Ubicación Destino"
        Me.lblUbicacionDestino.Visible = False
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.btnEliminar)
        Me.Panel3.Controls.Add(Me.btnInsertar)
        Me.Panel3.Location = New System.Drawing.Point(879, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(38, 80)
        Me.Panel3.TabIndex = 2
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(0, 40)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 20
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.Location = New System.Drawing.Point(0, 1)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 19
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'ugProductos
        '
        Me.ugProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.ugProductos, 2)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugProductos.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.ugProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugProductos.DisplayLayout.MaxBandDepth = 1
        Me.ugProductos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductos.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugProductos.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugProductos.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugProductos.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugProductos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugProductos.EnterMueveACeldaDeAbajo = True
        Me.ugProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugProductos.Location = New System.Drawing.Point(3, 107)
        Me.ugProductos.Name = "ugProductos"
        Me.ugProductos.Size = New System.Drawing.Size(911, 226)
        Me.ugProductos.TabIndex = 24
        Me.ugProductos.ToolStripLabelRegistros = Nothing
        Me.ugProductos.ToolStripMenuExpandir = Nothing
        '
        'txtStock2
        '
        Me.txtStock2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStock2.BindearPropiedadControl = Nothing
        Me.txtStock2.BindearPropiedadEntidad = Nothing
        Me.txtStock2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStock2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStock2.Formato = ""
        Me.txtStock2.IsDecimal = False
        Me.txtStock2.IsNumber = True
        Me.txtStock2.IsPK = False
        Me.txtStock2.IsRequired = False
        Me.txtStock2.Key = ""
        Me.txtStock2.LabelAsoc = Me.llbTotalProducto
        Me.txtStock2.Location = New System.Drawing.Point(396, 390)
        Me.txtStock2.Name = "txtStock2"
        Me.txtStock2.ReadOnly = True
        Me.txtStock2.Size = New System.Drawing.Size(52, 20)
        Me.txtStock2.TabIndex = 43
        Me.txtStock2.TabStop = False
        Me.txtStock2.Text = "0"
        Me.txtStock2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStock2
        '
        Me.lblStock2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStock2.AutoSize = True
        Me.lblStock2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStock2.LabelAsoc = Nothing
        Me.lblStock2.Location = New System.Drawing.Point(345, 393)
        Me.lblStock2.Name = "lblStock2"
        Me.lblStock2.Size = New System.Drawing.Size(45, 13)
        Me.lblStock2.TabIndex = 42
        Me.lblStock2.Text = "Stock S"
        '
        'cmbCantidadAfectada
        '
        Me.cmbCantidadAfectada.BindearPropiedadControl = Nothing
        Me.cmbCantidadAfectada.BindearPropiedadEntidad = Nothing
        Me.cmbCantidadAfectada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCantidadAfectada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCantidadAfectada.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCantidadAfectada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCantidadAfectada.FormattingEnabled = True
        Me.cmbCantidadAfectada.IsPK = False
        Me.cmbCantidadAfectada.IsRequired = False
        Me.cmbCantidadAfectada.Key = Nothing
        Me.cmbCantidadAfectada.LabelAsoc = Me.lblCantidadAfectada
        Me.cmbCantidadAfectada.Location = New System.Drawing.Point(373, 363)
        Me.cmbCantidadAfectada.Name = "cmbCantidadAfectada"
        Me.cmbCantidadAfectada.Size = New System.Drawing.Size(36, 21)
        Me.cmbCantidadAfectada.TabIndex = 1
        Me.cmbCantidadAfectada.Visible = False
        '
        'lblCantidadAfectada
        '
        Me.lblCantidadAfectada.AutoSize = True
        Me.lblCantidadAfectada.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCantidadAfectada.LabelAsoc = Nothing
        Me.lblCantidadAfectada.Location = New System.Drawing.Point(306, 366)
        Me.lblCantidadAfectada.Name = "lblCantidadAfectada"
        Me.lblCantidadAfectada.Size = New System.Drawing.Size(38, 13)
        Me.lblCantidadAfectada.TabIndex = 0
        Me.lblCantidadAfectada.Text = "Afecta"
        Me.lblCantidadAfectada.Visible = False
        '
        'tspFichas
        '
        Me.tspFichas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevoComprobante, Me.ToolStripSeparator2, Me.tsbGrabar, Me.ToolStripSeparator3, Me.tsbInvocarComprobantes, Me.tsbLeerArchivo, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tspFichas.Location = New System.Drawing.Point(0, 0)
        Me.tspFichas.Name = "tspFichas"
        Me.tspFichas.Size = New System.Drawing.Size(947, 25)
        Me.tspFichas.TabIndex = 11
        Me.tspFichas.Text = "ToolStrip1"
        '
        'tsbNuevoComprobante
        '
        Me.tsbNuevoComprobante.Image = Global.Eniac.Win.My.Resources.Resources.package_add
        Me.tsbNuevoComprobante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevoComprobante.Name = "tsbNuevoComprobante"
        Me.tsbNuevoComprobante.Size = New System.Drawing.Size(139, 22)
        Me.tsbNuevoComprobante.Text = "Nuevo Comprobante"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(143, 22)
        Me.tsbGrabar.Text = "&Grabar e Imprimir (F4)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbInvocarComprobantes
        '
        Me.tsbInvocarComprobantes.Image = Global.Eniac.Win.My.Resources.Resources.document_add
        Me.tsbInvocarComprobantes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInvocarComprobantes.Name = "tsbInvocarComprobantes"
        Me.tsbInvocarComprobantes.Size = New System.Drawing.Size(148, 22)
        Me.tsbInvocarComprobantes.Text = "&Invocar Comprobantes"
        Me.tsbInvocarComprobantes.ToolTipText = "Invocar Comprobantes"
        '
        'tsbLeerArchivo
        '
        Me.tsbLeerArchivo.Image = CType(resources.GetObject("tsbLeerArchivo.Image"), System.Drawing.Image)
        Me.tsbLeerArchivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLeerArchivo.Name = "tsbLeerArchivo"
        Me.tsbLeerArchivo.Size = New System.Drawing.Size(93, 22)
        Me.tsbLeerArchivo.Text = "&Leer Archivo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'MovimientosDeStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 561)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.txtTotalGeneral)
        Me.Controls.Add(Me.lblTotalGeneral)
        Me.Controls.Add(Me.grbMovimiento)
        Me.Controls.Add(Me.grbProveedor)
        Me.Controls.Add(Me.grbProducto)
        Me.Controls.Add(Me.tspFichas)
        Me.Controls.Add(Me.txtStock2)
        Me.Controls.Add(Me.lblStock2)
        Me.Controls.Add(Me.cmbCantidadAfectada)
        Me.Controls.Add(Me.lblCantidadAfectada)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "MovimientosDeStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos de Stock"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbMovimiento.ResumeLayout(False)
        Me.grbMovimiento.PerformLayout()
        Me.grbMovimientoDestino.ResumeLayout(False)
        Me.grbMovimientoDestino.PerformLayout()
        Me.grbMovimientoOrigen.ResumeLayout(False)
        Me.grbMovimientoOrigen.PerformLayout()
        Me.grbProveedor.ResumeLayout(False)
        Me.grbProveedor.PerformLayout()
        Me.grbProducto.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlDepositosUbicaciones.ResumeLayout(False)
        Me.pnlDepositosUbicaciones.PerformLayout()
        Me.grbDestinoDepositoUbicacion.ResumeLayout(False)
        Me.grbDestinoDepositoUbicacion.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tspFichas.ResumeLayout(False)
        Me.tspFichas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbProveedor As System.Windows.Forms.GroupBox
   Friend WithEvents lblNombreProveedor As Eniac.Controles.Label
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents tlpMensaje As System.Windows.Forms.ToolTip
   Friend WithEvents tspFichas As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents tsbNuevoComprobante As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbProducto As System.Windows.Forms.GroupBox
   Friend WithEvents lblTipoMovimiento As Eniac.Controles.Label
   Friend WithEvents cboTipoMovimiento As Eniac.Controles.ComboBox
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents grbMovimiento As System.Windows.Forms.GroupBox
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblCodProducto As Eniac.Controles.Label
   Friend WithEvents txtStock As Eniac.Controles.TextBox
   Friend WithEvents llbTotalProducto As Eniac.Controles.Label
   Friend WithEvents txtTotalProducto As Eniac.Controles.TextBox
   Friend WithEvents txtPrecio As Eniac.Controles.TextBox
   Friend WithEvents lblPrecio As Eniac.Controles.Label
   Friend WithEvents txtCantidad As Eniac.Controles.TextBox
   Friend WithEvents lblCantidad As Eniac.Controles.Label
   Friend WithEvents lblStock As Eniac.Controles.Label
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
   Friend WithEvents txtCategoriaFiscal As Eniac.Controles.TextBox
   Friend WithEvents lblCategoriaFiscal As System.Windows.Forms.Label
   Friend WithEvents lblSucursalOrigen As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents txtTotalGeneral As Eniac.Controles.TextBox
   Friend WithEvents lblTotalGeneral As Eniac.Controles.Label
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents cmbEmpleado As Eniac.Controles.ComboBox
   Friend WithEvents lblEmpleado As Eniac.Controles.Label
   Friend WithEvents cmbCantidadAfectada As Eniac.Controles.ComboBox
   Friend WithEvents lblCantidadAfectada As Eniac.Controles.Label
   Friend WithEvents tsbInvocarComprobantes As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbLeerArchivo As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grbMovimientoDestino As GroupBox
   Friend WithEvents lblDepositoDestino As Controles.Label
   Friend WithEvents cmbDepositoDestino As Controles.ComboBox
   Friend WithEvents lblSucursalDestino As Controles.Label
   Friend WithEvents cmbSucursalDestino As Controles.ComboBox
   Friend WithEvents grbMovimientoOrigen As GroupBox
   Friend WithEvents cmbSucursalOrigen As Controles.Label
   Friend WithEvents lblDepositoOrigen As Controles.Label
   Friend WithEvents cmbDepositoOrigen As Controles.ComboBox
   Friend WithEvents lblUbicacionDestino As Controles.Label
   Friend WithEvents cmbUbicacionDestino As Controles.ComboBox
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents cmbUbicacionOrigen As Controles.ComboBox
   Friend WithEvents txtStock2 As Controles.TextBox
   Friend WithEvents lblStock2 As Controles.Label
    Friend WithEvents ugProductos As UltraGridEditable
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlDepositosUbicaciones As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grbDestinoDepositoUbicacion As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
End Class
