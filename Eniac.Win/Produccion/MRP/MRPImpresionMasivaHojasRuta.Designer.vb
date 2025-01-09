<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MRPImpresionMasivaHojasRuta
    Inherits BaseForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imprimir")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Visualizar")
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.gpbPlanMaestro = New System.Windows.Forms.GroupBox()
        Me.dtpHastaPlanMaestro = New Eniac.Controles.DateTimePicker()
        Me.lblHastaPlanMaestro = New Eniac.Controles.Label()
        Me.chbFechaPlanMaestro = New Eniac.Controles.CheckBox()
        Me.lblDesdePlanMaestro = New Eniac.Controles.Label()
        Me.dtpDesdePlanMaestro = New Eniac.Controles.DateTimePicker()
        Me.txtPlanMaestro = New Eniac.Controles.TextBox()
        Me.chbPlanMaestro = New Eniac.Controles.CheckBox()
        Me.chbCentroProductor = New Eniac.Controles.CheckBox()
        Me.bscCodigosCentrosProductores = New Eniac.Controles.Buscador2()
        Me.bscNombresCentrosProductores = New Eniac.Controles.Buscador2()
        Me.bscNombreTareas = New Eniac.Controles.Buscador2()
        Me.chbSeccion = New Eniac.Controles.CheckBox()
        Me.cmbSecciones = New Eniac.Controles.ComboBox()
        Me.chbTarea = New Eniac.Controles.CheckBox()
        Me.bscNombresProductos = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.chbImprimeArchivo = New Eniac.Controles.CheckBox()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.cmbTipoComprobanteOP = New Eniac.Controles.ComboBox()
        Me.chbOrdenProduccion = New Eniac.Controles.CheckBox()
        Me.txtIdOrdenProduccion = New Eniac.Controles.TextBox()
        Me.txtLineaPedidoVta = New Eniac.Controles.TextBox()
        Me.lblLineaPedidoVta = New Eniac.Controles.Label()
        Me.lblTipoComprobantePedido = New Eniac.Controles.Label()
        Me.cmbTipoComprobantePedido = New Eniac.Controles.ComboBox()
        Me.chbPedidoVta = New Eniac.Controles.CheckBox()
        Me.txtNroPedidoVta = New Eniac.Controles.TextBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscNombresClientes = New Eniac.Controles.Buscador2()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.lblTipoImpresion = New Eniac.Controles.Label()
        Me.cmbTiposImpresiones = New Eniac.Controles.ComboBox()
        Me.lblResponsable = New Eniac.Controles.Label()
        Me.cmbResponsables = New Eniac.Controles.ComboBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.chbFechaEstado = New Eniac.Controles.CheckBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.cmbEstados = New Eniac.Controles.ComboBox()
        Me.chkMesCompletoEstado = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHastaEstado = New Eniac.Controles.DateTimePicker()
        Me.lblHastaEstado = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesdeEstado = New Eniac.Controles.DateTimePicker()
        Me.lblDesdeEstado = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnConsultar = New Eniac.Win.ButtonConsultar()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.gpbPlanMaestro.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbExportar, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1085, 29)
        Me.tstBarra.TabIndex = 6
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
        Me.tsbImprimir.Size = New System.Drawing.Size(102, 26)
        Me.tsbImprimir.Text = "&Imprimir (F4)"
        Me.tsbImprimir.ToolTipText = "Imprimir(F4)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(77, 26)
        Me.tsbExportar.Text = "&Exportar"
        Me.tsbExportar.ToolTipText = "Imprimir"
        Me.tsbExportar.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        Me.ToolStripSeparator5.Visible = False
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
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 654)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1085, 22)
        Me.stsStado.TabIndex = 5
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1006, 17)
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
        'grbConsultar
        '
        Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbConsultar.Controls.Add(Me.gpbPlanMaestro)
        Me.grbConsultar.Controls.Add(Me.chbCentroProductor)
        Me.grbConsultar.Controls.Add(Me.bscCodigosCentrosProductores)
        Me.grbConsultar.Controls.Add(Me.bscNombresCentrosProductores)
        Me.grbConsultar.Controls.Add(Me.bscNombreTareas)
        Me.grbConsultar.Controls.Add(Me.chbSeccion)
        Me.grbConsultar.Controls.Add(Me.cmbSecciones)
        Me.grbConsultar.Controls.Add(Me.chbTarea)
        Me.grbConsultar.Controls.Add(Me.bscNombresProductos)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProducto)
        Me.grbConsultar.Controls.Add(Me.chbProducto)
        Me.grbConsultar.Controls.Add(Me.chbImprimeArchivo)
        Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.cmbTipoComprobanteOP)
        Me.grbConsultar.Controls.Add(Me.chbOrdenProduccion)
        Me.grbConsultar.Controls.Add(Me.txtIdOrdenProduccion)
        Me.grbConsultar.Controls.Add(Me.txtLineaPedidoVta)
        Me.grbConsultar.Controls.Add(Me.lblLineaPedidoVta)
        Me.grbConsultar.Controls.Add(Me.lblTipoComprobantePedido)
        Me.grbConsultar.Controls.Add(Me.cmbTipoComprobantePedido)
        Me.grbConsultar.Controls.Add(Me.chbPedidoVta)
        Me.grbConsultar.Controls.Add(Me.txtNroPedidoVta)
        Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.bscNombresClientes)
        Me.grbConsultar.Controls.Add(Me.chbCliente)
        Me.grbConsultar.Controls.Add(Me.lblTipoImpresion)
        Me.grbConsultar.Controls.Add(Me.cmbTiposImpresiones)
        Me.grbConsultar.Controls.Add(Me.lblResponsable)
        Me.grbConsultar.Controls.Add(Me.cmbResponsables)
        Me.grbConsultar.Controls.Add(Me.chbFecha)
        Me.grbConsultar.Controls.Add(Me.chbFechaEstado)
        Me.grbConsultar.Controls.Add(Me.lblEstado)
        Me.grbConsultar.Controls.Add(Me.cmbEstados)
        Me.grbConsultar.Controls.Add(Me.chkMesCompletoEstado)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpHastaEstado)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesdeEstado)
        Me.grbConsultar.Controls.Add(Me.lblHastaEstado)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblDesdeEstado)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Location = New System.Drawing.Point(0, 32)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(1085, 184)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Filtros"
        '
        'gpbPlanMaestro
        '
        Me.gpbPlanMaestro.Controls.Add(Me.dtpHastaPlanMaestro)
        Me.gpbPlanMaestro.Controls.Add(Me.chbFechaPlanMaestro)
        Me.gpbPlanMaestro.Controls.Add(Me.lblDesdePlanMaestro)
        Me.gpbPlanMaestro.Controls.Add(Me.lblHastaPlanMaestro)
        Me.gpbPlanMaestro.Controls.Add(Me.dtpDesdePlanMaestro)
        Me.gpbPlanMaestro.Controls.Add(Me.txtPlanMaestro)
        Me.gpbPlanMaestro.Controls.Add(Me.chbPlanMaestro)
        Me.gpbPlanMaestro.Location = New System.Drawing.Point(501, 121)
        Me.gpbPlanMaestro.Name = "gpbPlanMaestro"
        Me.gpbPlanMaestro.Size = New System.Drawing.Size(574, 51)
        Me.gpbPlanMaestro.TabIndex = 42
        Me.gpbPlanMaestro.TabStop = False
        Me.gpbPlanMaestro.Text = "Plan Maestro"
        '
        'dtpHastaPlanMaestro
        '
        Me.dtpHastaPlanMaestro.BindearPropiedadControl = Nothing
        Me.dtpHastaPlanMaestro.BindearPropiedadEntidad = Nothing
        Me.dtpHastaPlanMaestro.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHastaPlanMaestro.Enabled = False
        Me.dtpHastaPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHastaPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHastaPlanMaestro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaPlanMaestro.IsPK = False
        Me.dtpHastaPlanMaestro.IsRequired = False
        Me.dtpHastaPlanMaestro.Key = ""
        Me.dtpHastaPlanMaestro.LabelAsoc = Me.lblHastaPlanMaestro
        Me.dtpHastaPlanMaestro.Location = New System.Drawing.Point(440, 18)
        Me.dtpHastaPlanMaestro.Name = "dtpHastaPlanMaestro"
        Me.dtpHastaPlanMaestro.Size = New System.Drawing.Size(125, 20)
        Me.dtpHastaPlanMaestro.TabIndex = 6
        '
        'lblHastaPlanMaestro
        '
        Me.lblHastaPlanMaestro.AutoSize = True
        Me.lblHastaPlanMaestro.LabelAsoc = Nothing
        Me.lblHastaPlanMaestro.Location = New System.Drawing.Point(399, 20)
        Me.lblHastaPlanMaestro.Name = "lblHastaPlanMaestro"
        Me.lblHastaPlanMaestro.Size = New System.Drawing.Size(35, 13)
        Me.lblHastaPlanMaestro.TabIndex = 5
        Me.lblHastaPlanMaestro.Text = "Hasta"
        '
        'chbFechaPlanMaestro
        '
        Me.chbFechaPlanMaestro.AutoSize = True
        Me.chbFechaPlanMaestro.BindearPropiedadControl = Nothing
        Me.chbFechaPlanMaestro.BindearPropiedadEntidad = Nothing
        Me.chbFechaPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaPlanMaestro.IsPK = False
        Me.chbFechaPlanMaestro.IsRequired = False
        Me.chbFechaPlanMaestro.Key = Nothing
        Me.chbFechaPlanMaestro.LabelAsoc = Nothing
        Me.chbFechaPlanMaestro.Location = New System.Drawing.Point(163, 20)
        Me.chbFechaPlanMaestro.Name = "chbFechaPlanMaestro"
        Me.chbFechaPlanMaestro.Size = New System.Drawing.Size(56, 17)
        Me.chbFechaPlanMaestro.TabIndex = 2
        Me.chbFechaPlanMaestro.Text = "Fecha"
        Me.chbFechaPlanMaestro.UseVisualStyleBackColor = True
        '
        'lblDesdePlanMaestro
        '
        Me.lblDesdePlanMaestro.AutoSize = True
        Me.lblDesdePlanMaestro.LabelAsoc = Nothing
        Me.lblDesdePlanMaestro.Location = New System.Drawing.Point(218, 21)
        Me.lblDesdePlanMaestro.Name = "lblDesdePlanMaestro"
        Me.lblDesdePlanMaestro.Size = New System.Drawing.Size(38, 13)
        Me.lblDesdePlanMaestro.TabIndex = 3
        Me.lblDesdePlanMaestro.Text = "Desde"
        '
        'dtpDesdePlanMaestro
        '
        Me.dtpDesdePlanMaestro.BindearPropiedadControl = Nothing
        Me.dtpDesdePlanMaestro.BindearPropiedadEntidad = Nothing
        Me.dtpDesdePlanMaestro.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesdePlanMaestro.Enabled = False
        Me.dtpDesdePlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesdePlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesdePlanMaestro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdePlanMaestro.IsPK = False
        Me.dtpDesdePlanMaestro.IsRequired = False
        Me.dtpDesdePlanMaestro.Key = ""
        Me.dtpDesdePlanMaestro.LabelAsoc = Me.lblDesdePlanMaestro
        Me.dtpDesdePlanMaestro.Location = New System.Drawing.Point(262, 18)
        Me.dtpDesdePlanMaestro.Name = "dtpDesdePlanMaestro"
        Me.dtpDesdePlanMaestro.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesdePlanMaestro.TabIndex = 4
        '
        'txtPlanMaestro
        '
        Me.txtPlanMaestro.BindearPropiedadControl = "Text"
        Me.txtPlanMaestro.BindearPropiedadEntidad = "CodigoTarea"
        Me.txtPlanMaestro.Enabled = False
        Me.txtPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPlanMaestro.Formato = ""
        Me.txtPlanMaestro.IsDecimal = False
        Me.txtPlanMaestro.IsNumber = True
        Me.txtPlanMaestro.IsPK = False
        Me.txtPlanMaestro.IsRequired = False
        Me.txtPlanMaestro.Key = ""
        Me.txtPlanMaestro.LabelAsoc = Nothing
        Me.txtPlanMaestro.Location = New System.Drawing.Point(79, 18)
        Me.txtPlanMaestro.MaxLength = 12
        Me.txtPlanMaestro.Name = "txtPlanMaestro"
        Me.txtPlanMaestro.Size = New System.Drawing.Size(78, 20)
        Me.txtPlanMaestro.TabIndex = 1
        Me.txtPlanMaestro.Text = "0"
        Me.txtPlanMaestro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbPlanMaestro
        '
        Me.chbPlanMaestro.AutoSize = True
        Me.chbPlanMaestro.BindearPropiedadControl = Nothing
        Me.chbPlanMaestro.BindearPropiedadEntidad = Nothing
        Me.chbPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPlanMaestro.IsPK = False
        Me.chbPlanMaestro.IsRequired = False
        Me.chbPlanMaestro.Key = Nothing
        Me.chbPlanMaestro.LabelAsoc = Nothing
        Me.chbPlanMaestro.Location = New System.Drawing.Point(10, 20)
        Me.chbPlanMaestro.Name = "chbPlanMaestro"
        Me.chbPlanMaestro.Size = New System.Drawing.Size(63, 17)
        Me.chbPlanMaestro.TabIndex = 0
        Me.chbPlanMaestro.Text = "Número"
        Me.chbPlanMaestro.UseVisualStyleBackColor = True
        '
        'chbCentroProductor
        '
        Me.chbCentroProductor.AutoSize = True
        Me.chbCentroProductor.BindearPropiedadControl = Nothing
        Me.chbCentroProductor.BindearPropiedadEntidad = Nothing
        Me.chbCentroProductor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCentroProductor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCentroProductor.IsPK = False
        Me.chbCentroProductor.IsRequired = False
        Me.chbCentroProductor.Key = Nothing
        Me.chbCentroProductor.LabelAsoc = Nothing
        Me.chbCentroProductor.Location = New System.Drawing.Point(15, 155)
        Me.chbCentroProductor.Name = "chbCentroProductor"
        Me.chbCentroProductor.Size = New System.Drawing.Size(106, 17)
        Me.chbCentroProductor.TabIndex = 39
        Me.chbCentroProductor.Text = "Centro Productor"
        Me.chbCentroProductor.UseVisualStyleBackColor = True
        '
        'bscCodigosCentrosProductores
        '
        Me.bscCodigosCentrosProductores.ActivarFiltroEnGrilla = True
        Me.bscCodigosCentrosProductores.BindearPropiedadControl = Nothing
        Me.bscCodigosCentrosProductores.BindearPropiedadEntidad = Nothing
        Me.bscCodigosCentrosProductores.ConfigBuscador = Nothing
        Me.bscCodigosCentrosProductores.Datos = Nothing
        Me.bscCodigosCentrosProductores.Enabled = False
        Me.bscCodigosCentrosProductores.FilaDevuelta = Nothing
        Me.bscCodigosCentrosProductores.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigosCentrosProductores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigosCentrosProductores.IsDecimal = False
        Me.bscCodigosCentrosProductores.IsNumber = False
        Me.bscCodigosCentrosProductores.IsPK = False
        Me.bscCodigosCentrosProductores.IsRequired = False
        Me.bscCodigosCentrosProductores.Key = ""
        Me.bscCodigosCentrosProductores.LabelAsoc = Nothing
        Me.bscCodigosCentrosProductores.Location = New System.Drawing.Point(128, 153)
        Me.bscCodigosCentrosProductores.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigosCentrosProductores.MaxLengh = "32767"
        Me.bscCodigosCentrosProductores.Name = "bscCodigosCentrosProductores"
        Me.bscCodigosCentrosProductores.Permitido = True
        Me.bscCodigosCentrosProductores.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigosCentrosProductores.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigosCentrosProductores.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigosCentrosProductores.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigosCentrosProductores.Selecciono = False
        Me.bscCodigosCentrosProductores.Size = New System.Drawing.Size(79, 20)
        Me.bscCodigosCentrosProductores.TabIndex = 40
        '
        'bscNombresCentrosProductores
        '
        Me.bscNombresCentrosProductores.ActivarFiltroEnGrilla = True
        Me.bscNombresCentrosProductores.BindearPropiedadControl = Nothing
        Me.bscNombresCentrosProductores.BindearPropiedadEntidad = Nothing
        Me.bscNombresCentrosProductores.ConfigBuscador = Nothing
        Me.bscNombresCentrosProductores.Datos = Nothing
        Me.bscNombresCentrosProductores.Enabled = False
        Me.bscNombresCentrosProductores.FilaDevuelta = Nothing
        Me.bscNombresCentrosProductores.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombresCentrosProductores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombresCentrosProductores.IsDecimal = False
        Me.bscNombresCentrosProductores.IsNumber = False
        Me.bscNombresCentrosProductores.IsPK = False
        Me.bscNombresCentrosProductores.IsRequired = False
        Me.bscNombresCentrosProductores.Key = ""
        Me.bscNombresCentrosProductores.LabelAsoc = Nothing
        Me.bscNombresCentrosProductores.Location = New System.Drawing.Point(213, 153)
        Me.bscNombresCentrosProductores.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombresCentrosProductores.MaxLengh = "32767"
        Me.bscNombresCentrosProductores.Name = "bscNombresCentrosProductores"
        Me.bscNombresCentrosProductores.Permitido = True
        Me.bscNombresCentrosProductores.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombresCentrosProductores.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombresCentrosProductores.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombresCentrosProductores.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombresCentrosProductores.Selecciono = False
        Me.bscNombresCentrosProductores.Size = New System.Drawing.Size(263, 20)
        Me.bscNombresCentrosProductores.TabIndex = 41
        '
        'bscNombreTareas
        '
        Me.bscNombreTareas.ActivarFiltroEnGrilla = True
        Me.bscNombreTareas.BindearPropiedadControl = Nothing
        Me.bscNombreTareas.BindearPropiedadEntidad = Nothing
        Me.bscNombreTareas.ConfigBuscador = Nothing
        Me.bscNombreTareas.Datos = Nothing
        Me.bscNombreTareas.Enabled = False
        Me.bscNombreTareas.FilaDevuelta = Nothing
        Me.bscNombreTareas.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreTareas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreTareas.IsDecimal = False
        Me.bscNombreTareas.IsNumber = False
        Me.bscNombreTareas.IsPK = False
        Me.bscNombreTareas.IsRequired = False
        Me.bscNombreTareas.Key = ""
        Me.bscNombreTareas.LabelAsoc = Nothing
        Me.bscNombreTareas.Location = New System.Drawing.Point(299, 124)
        Me.bscNombreTareas.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreTareas.MaxLengh = "32767"
        Me.bscNombreTareas.Name = "bscNombreTareas"
        Me.bscNombreTareas.Permitido = True
        Me.bscNombreTareas.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreTareas.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreTareas.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreTareas.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreTareas.Selecciono = False
        Me.bscNombreTareas.Size = New System.Drawing.Size(177, 20)
        Me.bscNombreTareas.TabIndex = 38
        '
        'chbSeccion
        '
        Me.chbSeccion.AutoSize = True
        Me.chbSeccion.BindearPropiedadControl = Nothing
        Me.chbSeccion.BindearPropiedadEntidad = Nothing
        Me.chbSeccion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSeccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSeccion.IsPK = False
        Me.chbSeccion.IsRequired = False
        Me.chbSeccion.Key = Nothing
        Me.chbSeccion.LabelAsoc = Nothing
        Me.chbSeccion.Location = New System.Drawing.Point(15, 126)
        Me.chbSeccion.Name = "chbSeccion"
        Me.chbSeccion.Size = New System.Drawing.Size(65, 17)
        Me.chbSeccion.TabIndex = 35
        Me.chbSeccion.Text = "Seccion"
        Me.chbSeccion.UseVisualStyleBackColor = True
        '
        'cmbSecciones
        '
        Me.cmbSecciones.BindearPropiedadControl = Nothing
        Me.cmbSecciones.BindearPropiedadEntidad = Nothing
        Me.cmbSecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSecciones.Enabled = False
        Me.cmbSecciones.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSecciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSecciones.FormattingEnabled = True
        Me.cmbSecciones.IsPK = False
        Me.cmbSecciones.IsRequired = False
        Me.cmbSecciones.Key = Nothing
        Me.cmbSecciones.LabelAsoc = Nothing
        Me.cmbSecciones.Location = New System.Drawing.Point(84, 124)
        Me.cmbSecciones.Name = "cmbSecciones"
        Me.cmbSecciones.Size = New System.Drawing.Size(154, 21)
        Me.cmbSecciones.TabIndex = 36
        '
        'chbTarea
        '
        Me.chbTarea.AutoSize = True
        Me.chbTarea.BindearPropiedadControl = Nothing
        Me.chbTarea.BindearPropiedadEntidad = Nothing
        Me.chbTarea.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTarea.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTarea.IsPK = False
        Me.chbTarea.IsRequired = False
        Me.chbTarea.Key = Nothing
        Me.chbTarea.LabelAsoc = Nothing
        Me.chbTarea.Location = New System.Drawing.Point(243, 126)
        Me.chbTarea.Name = "chbTarea"
        Me.chbTarea.Size = New System.Drawing.Size(54, 17)
        Me.chbTarea.TabIndex = 37
        Me.chbTarea.Text = "Tarea"
        Me.chbTarea.UseVisualStyleBackColor = True
        '
        'bscNombresProductos
        '
        Me.bscNombresProductos.ActivarFiltroEnGrilla = True
        Me.bscNombresProductos.BindearPropiedadControl = Nothing
        Me.bscNombresProductos.BindearPropiedadEntidad = Nothing
        Me.bscNombresProductos.ConfigBuscador = Nothing
        Me.bscNombresProductos.Datos = Nothing
        Me.bscNombresProductos.Enabled = False
        Me.bscNombresProductos.FilaDevuelta = Nothing
        Me.bscNombresProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombresProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombresProductos.IsDecimal = False
        Me.bscNombresProductos.IsNumber = False
        Me.bscNombresProductos.IsPK = False
        Me.bscNombresProductos.IsRequired = False
        Me.bscNombresProductos.Key = ""
        Me.bscNombresProductos.LabelAsoc = Nothing
        Me.bscNombresProductos.Location = New System.Drawing.Point(176, 95)
        Me.bscNombresProductos.MaxLengh = "32767"
        Me.bscNombresProductos.Name = "bscNombresProductos"
        Me.bscNombresProductos.Permitido = True
        Me.bscNombresProductos.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombresProductos.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombresProductos.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombresProductos.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombresProductos.Selecciono = False
        Me.bscNombresProductos.Size = New System.Drawing.Size(300, 20)
        Me.bscNombresProductos.TabIndex = 30
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.Enabled = False
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Nothing
        Me.bscCodigoProducto.Location = New System.Drawing.Point(84, 94)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = True
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(85, 20)
        Me.bscCodigoProducto.TabIndex = 29
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
        Me.chbProducto.Location = New System.Drawing.Point(15, 97)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 28
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'chbImprimeArchivo
        '
        Me.chbImprimeArchivo.AutoSize = True
        Me.chbImprimeArchivo.BindearPropiedadControl = Nothing
        Me.chbImprimeArchivo.BindearPropiedadEntidad = Nothing
        Me.chbImprimeArchivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImprimeArchivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImprimeArchivo.IsPK = False
        Me.chbImprimeArchivo.IsRequired = False
        Me.chbImprimeArchivo.Key = Nothing
        Me.chbImprimeArchivo.LabelAsoc = Nothing
        Me.chbImprimeArchivo.Location = New System.Drawing.Point(343, 16)
        Me.chbImprimeArchivo.Name = "chbImprimeArchivo"
        Me.chbImprimeArchivo.Size = New System.Drawing.Size(138, 17)
        Me.chbImprimeArchivo.TabIndex = 2
        Me.chbImprimeArchivo.Text = "Imprime archivo adjunto"
        Me.chbImprimeArchivo.UseVisualStyleBackColor = True
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(746, 98)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobante.TabIndex = 33
        Me.lblTipoComprobante.Text = "Tipo Comprobante"
        '
        'cmbTipoComprobanteOP
        '
        Me.cmbTipoComprobanteOP.BindearPropiedadControl = ""
        Me.cmbTipoComprobanteOP.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobanteOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteOP.Enabled = False
        Me.cmbTipoComprobanteOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteOP.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteOP.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteOP.FormattingEnabled = True
        Me.cmbTipoComprobanteOP.IsPK = False
        Me.cmbTipoComprobanteOP.IsRequired = False
        Me.cmbTipoComprobanteOP.Key = Nothing
        Me.cmbTipoComprobanteOP.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTipoComprobanteOP.Location = New System.Drawing.Point(846, 95)
        Me.cmbTipoComprobanteOP.Name = "cmbTipoComprobanteOP"
        Me.cmbTipoComprobanteOP.Size = New System.Drawing.Size(229, 21)
        Me.cmbTipoComprobanteOP.TabIndex = 34
        '
        'chbOrdenProduccion
        '
        Me.chbOrdenProduccion.AutoSize = True
        Me.chbOrdenProduccion.BindearPropiedadControl = Nothing
        Me.chbOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.chbOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenProduccion.IsPK = False
        Me.chbOrdenProduccion.IsRequired = False
        Me.chbOrdenProduccion.Key = Nothing
        Me.chbOrdenProduccion.LabelAsoc = Nothing
        Me.chbOrdenProduccion.Location = New System.Drawing.Point(501, 98)
        Me.chbOrdenProduccion.Name = "chbOrdenProduccion"
        Me.chbOrdenProduccion.Size = New System.Drawing.Size(127, 17)
        Me.chbOrdenProduccion.TabIndex = 31
        Me.chbOrdenProduccion.Text = "Orden de Producción"
        Me.chbOrdenProduccion.UseVisualStyleBackColor = True
        '
        'txtIdOrdenProduccion
        '
        Me.txtIdOrdenProduccion.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdOrdenProduccion.BindearPropiedadControl = Nothing
        Me.txtIdOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.txtIdOrdenProduccion.Enabled = False
        Me.txtIdOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdOrdenProduccion.Formato = ""
        Me.txtIdOrdenProduccion.IsDecimal = False
        Me.txtIdOrdenProduccion.IsNumber = True
        Me.txtIdOrdenProduccion.IsPK = False
        Me.txtIdOrdenProduccion.IsRequired = False
        Me.txtIdOrdenProduccion.Key = ""
        Me.txtIdOrdenProduccion.LabelAsoc = Nothing
        Me.txtIdOrdenProduccion.Location = New System.Drawing.Point(634, 96)
        Me.txtIdOrdenProduccion.MaxLength = 6
        Me.txtIdOrdenProduccion.Name = "txtIdOrdenProduccion"
        Me.txtIdOrdenProduccion.Size = New System.Drawing.Size(103, 20)
        Me.txtIdOrdenProduccion.TabIndex = 32
        Me.txtIdOrdenProduccion.Text = "0"
        Me.txtIdOrdenProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineaPedidoVta
        '
        Me.txtLineaPedidoVta.BackColor = System.Drawing.SystemColors.Window
        Me.txtLineaPedidoVta.BindearPropiedadControl = Nothing
        Me.txtLineaPedidoVta.BindearPropiedadEntidad = Nothing
        Me.txtLineaPedidoVta.Enabled = False
        Me.txtLineaPedidoVta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLineaPedidoVta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLineaPedidoVta.Formato = ""
        Me.txtLineaPedidoVta.IsDecimal = False
        Me.txtLineaPedidoVta.IsNumber = True
        Me.txtLineaPedidoVta.IsPK = False
        Me.txtLineaPedidoVta.IsRequired = False
        Me.txtLineaPedidoVta.Key = ""
        Me.txtLineaPedidoVta.LabelAsoc = Nothing
        Me.txtLineaPedidoVta.Location = New System.Drawing.Point(739, 69)
        Me.txtLineaPedidoVta.MaxLength = 8
        Me.txtLineaPedidoVta.Name = "txtLineaPedidoVta"
        Me.txtLineaPedidoVta.Size = New System.Drawing.Size(54, 20)
        Me.txtLineaPedidoVta.TabIndex = 25
        Me.txtLineaPedidoVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLineaPedidoVta
        '
        Me.lblLineaPedidoVta.AutoSize = True
        Me.lblLineaPedidoVta.LabelAsoc = Nothing
        Me.lblLineaPedidoVta.Location = New System.Drawing.Point(700, 71)
        Me.lblLineaPedidoVta.Name = "lblLineaPedidoVta"
        Me.lblLineaPedidoVta.Size = New System.Drawing.Size(33, 13)
        Me.lblLineaPedidoVta.TabIndex = 24
        Me.lblLineaPedidoVta.Text = "Linea"
        '
        'lblTipoComprobantePedido
        '
        Me.lblTipoComprobantePedido.AutoSize = True
        Me.lblTipoComprobantePedido.LabelAsoc = Nothing
        Me.lblTipoComprobantePedido.Location = New System.Drawing.Point(799, 70)
        Me.lblTipoComprobantePedido.Name = "lblTipoComprobantePedido"
        Me.lblTipoComprobantePedido.Size = New System.Drawing.Size(70, 13)
        Me.lblTipoComprobantePedido.TabIndex = 26
        Me.lblTipoComprobantePedido.Text = "Comprobante"
        '
        'cmbTipoComprobantePedido
        '
        Me.cmbTipoComprobantePedido.BindearPropiedadControl = ""
        Me.cmbTipoComprobantePedido.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobantePedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobantePedido.Enabled = False
        Me.cmbTipoComprobantePedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobantePedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobantePedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobantePedido.FormattingEnabled = True
        Me.cmbTipoComprobantePedido.IsPK = False
        Me.cmbTipoComprobantePedido.IsRequired = False
        Me.cmbTipoComprobantePedido.Key = Nothing
        Me.cmbTipoComprobantePedido.LabelAsoc = Nothing
        Me.cmbTipoComprobantePedido.Location = New System.Drawing.Point(875, 68)
        Me.cmbTipoComprobantePedido.Name = "cmbTipoComprobantePedido"
        Me.cmbTipoComprobantePedido.Size = New System.Drawing.Size(200, 21)
        Me.cmbTipoComprobantePedido.TabIndex = 27
        '
        'chbPedidoVta
        '
        Me.chbPedidoVta.AutoSize = True
        Me.chbPedidoVta.BindearPropiedadControl = Nothing
        Me.chbPedidoVta.BindearPropiedadEntidad = Nothing
        Me.chbPedidoVta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidoVta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidoVta.IsPK = False
        Me.chbPedidoVta.IsRequired = False
        Me.chbPedidoVta.Key = Nothing
        Me.chbPedidoVta.LabelAsoc = Nothing
        Me.chbPedidoVta.Location = New System.Drawing.Point(501, 70)
        Me.chbPedidoVta.Name = "chbPedidoVta"
        Me.chbPedidoVta.Size = New System.Drawing.Size(81, 17)
        Me.chbPedidoVta.TabIndex = 22
        Me.chbPedidoVta.Text = "Pedido Vta."
        Me.chbPedidoVta.UseVisualStyleBackColor = True
        '
        'txtNroPedidoVta
        '
        Me.txtNroPedidoVta.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroPedidoVta.BindearPropiedadControl = Nothing
        Me.txtNroPedidoVta.BindearPropiedadEntidad = Nothing
        Me.txtNroPedidoVta.Enabled = False
        Me.txtNroPedidoVta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPedidoVta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPedidoVta.Formato = ""
        Me.txtNroPedidoVta.IsDecimal = False
        Me.txtNroPedidoVta.IsNumber = True
        Me.txtNroPedidoVta.IsPK = False
        Me.txtNroPedidoVta.IsRequired = False
        Me.txtNroPedidoVta.Key = ""
        Me.txtNroPedidoVta.LabelAsoc = Nothing
        Me.txtNroPedidoVta.Location = New System.Drawing.Point(588, 68)
        Me.txtNroPedidoVta.MaxLength = 8
        Me.txtNroPedidoVta.Name = "txtNroPedidoVta"
        Me.txtNroPedidoVta.Size = New System.Drawing.Size(106, 20)
        Me.txtNroPedidoVta.TabIndex = 23
        Me.txtNroPedidoVta.Text = "0"
        Me.txtNroPedidoVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
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
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(80, 66)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(91, 23)
        Me.bscCodigoCliente.TabIndex = 20
        '
        'bscNombresClientes
        '
        Me.bscNombresClientes.ActivarFiltroEnGrilla = True
        Me.bscNombresClientes.AutoSize = True
        Me.bscNombresClientes.BindearPropiedadControl = Nothing
        Me.bscNombresClientes.BindearPropiedadEntidad = Nothing
        Me.bscNombresClientes.ConfigBuscador = Nothing
        Me.bscNombresClientes.Datos = Nothing
        Me.bscNombresClientes.Enabled = False
        Me.bscNombresClientes.FilaDevuelta = Nothing
        Me.bscNombresClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombresClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombresClientes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombresClientes.IsDecimal = False
        Me.bscNombresClientes.IsNumber = False
        Me.bscNombresClientes.IsPK = False
        Me.bscNombresClientes.IsRequired = False
        Me.bscNombresClientes.Key = ""
        Me.bscNombresClientes.LabelAsoc = Nothing
        Me.bscNombresClientes.Location = New System.Drawing.Point(178, 66)
        Me.bscNombresClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombresClientes.MaxLengh = "32767"
        Me.bscNombresClientes.Name = "bscNombresClientes"
        Me.bscNombresClientes.Permitido = True
        Me.bscNombresClientes.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombresClientes.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombresClientes.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombresClientes.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombresClientes.Selecciono = False
        Me.bscNombresClientes.Size = New System.Drawing.Size(298, 23)
        Me.bscNombresClientes.TabIndex = 21
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
        Me.chbCliente.Location = New System.Drawing.Point(16, 68)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 19
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'lblTipoImpresion
        '
        Me.lblTipoImpresion.AutoSize = True
        Me.lblTipoImpresion.LabelAsoc = Nothing
        Me.lblTipoImpresion.Location = New System.Drawing.Point(14, 17)
        Me.lblTipoImpresion.Name = "lblTipoImpresion"
        Me.lblTipoImpresion.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoImpresion.TabIndex = 0
        Me.lblTipoImpresion.Text = "Tipo de Impresion "
        '
        'cmbTiposImpresiones
        '
        Me.cmbTiposImpresiones.BindearPropiedadControl = ""
        Me.cmbTiposImpresiones.BindearPropiedadEntidad = ""
        Me.cmbTiposImpresiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposImpresiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiposImpresiones.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposImpresiones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposImpresiones.FormattingEnabled = True
        Me.cmbTiposImpresiones.IsPK = False
        Me.cmbTiposImpresiones.IsRequired = False
        Me.cmbTiposImpresiones.Key = Nothing
        Me.cmbTiposImpresiones.LabelAsoc = Me.lblTipoImpresion
        Me.cmbTiposImpresiones.Location = New System.Drawing.Point(114, 13)
        Me.cmbTiposImpresiones.Name = "cmbTiposImpresiones"
        Me.cmbTiposImpresiones.Size = New System.Drawing.Size(223, 21)
        Me.cmbTiposImpresiones.TabIndex = 1
        '
        'lblResponsable
        '
        Me.lblResponsable.AutoSize = True
        Me.lblResponsable.LabelAsoc = Nothing
        Me.lblResponsable.Location = New System.Drawing.Point(225, 43)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(47, 13)
        Me.lblResponsable.TabIndex = 11
        Me.lblResponsable.Text = "Operario"
        '
        'cmbResponsables
        '
        Me.cmbResponsables.BindearPropiedadControl = ""
        Me.cmbResponsables.BindearPropiedadEntidad = ""
        Me.cmbResponsables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsables.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbResponsables.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbResponsables.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbResponsables.FormattingEnabled = True
        Me.cmbResponsables.IsPK = False
        Me.cmbResponsables.IsRequired = False
        Me.cmbResponsables.Key = Nothing
        Me.cmbResponsables.LabelAsoc = Me.lblResponsable
        Me.cmbResponsables.Location = New System.Drawing.Point(278, 39)
        Me.cmbResponsables.Name = "cmbResponsables"
        Me.cmbResponsables.Size = New System.Drawing.Size(198, 21)
        Me.cmbResponsables.TabIndex = 12
        '
        'chbFecha
        '
        Me.chbFecha.AutoSize = True
        Me.chbFecha.BindearPropiedadControl = Nothing
        Me.chbFecha.BindearPropiedadEntidad = Nothing
        Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFecha.IsPK = False
        Me.chbFecha.IsRequired = False
        Me.chbFecha.Key = Nothing
        Me.chbFecha.LabelAsoc = Nothing
        Me.chbFecha.Location = New System.Drawing.Point(501, 17)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 3
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'chbFechaEstado
        '
        Me.chbFechaEstado.AutoSize = True
        Me.chbFechaEstado.BindearPropiedadControl = Nothing
        Me.chbFechaEstado.BindearPropiedadEntidad = Nothing
        Me.chbFechaEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEstado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEstado.IsPK = False
        Me.chbFechaEstado.IsRequired = False
        Me.chbFechaEstado.Key = Nothing
        Me.chbFechaEstado.LabelAsoc = Nothing
        Me.chbFechaEstado.Location = New System.Drawing.Point(501, 42)
        Me.chbFechaEstado.Name = "chbFechaEstado"
        Me.chbFechaEstado.Size = New System.Drawing.Size(92, 17)
        Me.chbFechaEstado.TabIndex = 13
        Me.chbFechaEstado.Text = "Fecha Estado"
        Me.chbFechaEstado.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(14, 43)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 9
        Me.lblEstado.Text = "Estado"
        '
        'cmbEstados
        '
        Me.cmbEstados.BindearPropiedadControl = ""
        Me.cmbEstados.BindearPropiedadEntidad = ""
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.IsPK = False
        Me.cmbEstados.IsRequired = False
        Me.cmbEstados.Key = Nothing
        Me.cmbEstados.LabelAsoc = Me.lblEstado
        Me.cmbEstados.Location = New System.Drawing.Point(60, 39)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(159, 21)
        Me.cmbEstados.TabIndex = 10
        '
        'chkMesCompletoEstado
        '
        Me.chkMesCompletoEstado.AutoSize = True
        Me.chkMesCompletoEstado.BindearPropiedadControl = Nothing
        Me.chkMesCompletoEstado.BindearPropiedadEntidad = Nothing
        Me.chkMesCompletoEstado.Enabled = False
        Me.chkMesCompletoEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompletoEstado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompletoEstado.IsPK = False
        Me.chkMesCompletoEstado.IsRequired = False
        Me.chkMesCompletoEstado.Key = Nothing
        Me.chkMesCompletoEstado.LabelAsoc = Nothing
        Me.chkMesCompletoEstado.Location = New System.Drawing.Point(646, 42)
        Me.chkMesCompletoEstado.Name = "chkMesCompletoEstado"
        Me.chkMesCompletoEstado.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompletoEstado.TabIndex = 14
        Me.chkMesCompletoEstado.Text = "Mes C."
        Me.chkMesCompletoEstado.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(646, 17)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompleto.TabIndex = 4
        Me.chkMesCompleto.Text = "Mes C."
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHastaEstado
        '
        Me.dtpHastaEstado.BindearPropiedadControl = Nothing
        Me.dtpHastaEstado.BindearPropiedadEntidad = Nothing
        Me.dtpHastaEstado.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHastaEstado.Enabled = False
        Me.dtpHastaEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHastaEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHastaEstado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaEstado.IsPK = False
        Me.dtpHastaEstado.IsRequired = False
        Me.dtpHastaEstado.Key = ""
        Me.dtpHastaEstado.LabelAsoc = Me.lblHastaEstado
        Me.dtpHastaEstado.Location = New System.Drawing.Point(945, 40)
        Me.dtpHastaEstado.Name = "dtpHastaEstado"
        Me.dtpHastaEstado.Size = New System.Drawing.Size(128, 20)
        Me.dtpHastaEstado.TabIndex = 18
        '
        'lblHastaEstado
        '
        Me.lblHastaEstado.AutoSize = True
        Me.lblHastaEstado.LabelAsoc = Nothing
        Me.lblHastaEstado.Location = New System.Drawing.Point(904, 41)
        Me.lblHastaEstado.Name = "lblHastaEstado"
        Me.lblHastaEstado.Size = New System.Drawing.Size(35, 13)
        Me.lblHastaEstado.TabIndex = 17
        Me.lblHastaEstado.Text = "Hasta"
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(945, 16)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 8
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(904, 19)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 7
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesdeEstado
        '
        Me.dtpDesdeEstado.BindearPropiedadControl = Nothing
        Me.dtpDesdeEstado.BindearPropiedadEntidad = Nothing
        Me.dtpDesdeEstado.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesdeEstado.Enabled = False
        Me.dtpDesdeEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesdeEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesdeEstado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeEstado.IsPK = False
        Me.dtpDesdeEstado.IsRequired = False
        Me.dtpDesdeEstado.Key = ""
        Me.dtpDesdeEstado.LabelAsoc = Me.lblDesdeEstado
        Me.dtpDesdeEstado.Location = New System.Drawing.Point(767, 40)
        Me.dtpDesdeEstado.Name = "dtpDesdeEstado"
        Me.dtpDesdeEstado.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesdeEstado.TabIndex = 16
        '
        'lblDesdeEstado
        '
        Me.lblDesdeEstado.AutoSize = True
        Me.lblDesdeEstado.LabelAsoc = Nothing
        Me.lblDesdeEstado.Location = New System.Drawing.Point(723, 44)
        Me.lblDesdeEstado.Name = "lblDesdeEstado"
        Me.lblDesdeEstado.Size = New System.Drawing.Size(38, 13)
        Me.lblDesdeEstado.TabIndex = 15
        Me.lblDesdeEstado.Text = "Desde"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(767, 15)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 6
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(723, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 5
        Me.lblDesde.Text = "Desde"
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        UltraGridColumn1.Header.Appearance = Appearance2
        UltraGridColumn1.Header.Caption = "I"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 27
        UltraGridColumn2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        UltraGridColumn2.CellAppearance = Appearance3
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        UltraGridColumn2.Header.Appearance = Appearance4
        UltraGridColumn2.Header.Caption = "V"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn2.Width = 29
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance14
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 219)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1085, 432)
        Me.ugDetalle.TabIndex = 1
        '
        'btnConsultar
        '
        Me.btnConsultar.AnchoredControl = Me.ugDetalle
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(971, 222)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(104, 30)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(886, 226)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 3
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(759, 226)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 2
        '
        'MRPImpresionMasivaHojasRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 676)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "MRPImpresionMasivaHojasRuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión Masiva de Hojas de Ruta"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.gpbPlanMaestro.ResumeLayout(False)
        Me.gpbPlanMaestro.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents tstBarra As ToolStrip
    Public WithEvents tsbRefrescar As ToolStripButton
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbImprimir As ToolStripButton
    Private WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbExportar As ToolStripButton
    Private WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents tsbSalir As ToolStripButton
    Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As ToolStripProgressBar
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents grbConsultar As GroupBox
    Friend WithEvents chbFechaEstado As Controles.CheckBox
    Friend WithEvents lblEstado As Controles.Label
    Friend WithEvents cmbEstados As Controles.ComboBox
    Friend WithEvents chkMesCompletoEstado As Controles.CheckBox
    Friend WithEvents chkMesCompleto As Controles.CheckBox
    Friend WithEvents dtpHastaEstado As Controles.DateTimePicker
    Friend WithEvents lblHastaEstado As Controles.Label
    Friend WithEvents dtpHasta As Controles.DateTimePicker
    Friend WithEvents lblHasta As Controles.Label
    Friend WithEvents dtpDesdeEstado As Controles.DateTimePicker
    Friend WithEvents lblDesdeEstado As Controles.Label
    Friend WithEvents dtpDesde As Controles.DateTimePicker
    Friend WithEvents lblDesde As Controles.Label
    Friend WithEvents chbFecha As Controles.CheckBox
    Friend WithEvents lblTipoImpresion As Controles.Label
    Friend WithEvents cmbTiposImpresiones As Controles.ComboBox
    Friend WithEvents lblResponsable As Controles.Label
    Friend WithEvents cmbResponsables As Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Controles.Buscador2
   Friend WithEvents bscNombresClientes As Controles.Buscador2
   Friend WithEvents chbCliente As Controles.CheckBox
    Friend WithEvents dtpHastaPlanMaestro As Controles.DateTimePicker
    Friend WithEvents lblHastaPlanMaestro As Controles.Label
    Friend WithEvents dtpDesdePlanMaestro As Controles.DateTimePicker
    Friend WithEvents lblDesdePlanMaestro As Controles.Label
    Friend WithEvents chbFechaPlanMaestro As Controles.CheckBox
    Friend WithEvents txtPlanMaestro As Controles.TextBox
    Friend WithEvents chbPlanMaestro As Controles.CheckBox
    Friend WithEvents txtLineaPedidoVta As Controles.TextBox
    Friend WithEvents lblLineaPedidoVta As Controles.Label
    Friend WithEvents lblTipoComprobantePedido As Controles.Label
    Friend WithEvents cmbTipoComprobantePedido As Controles.ComboBox
    Friend WithEvents chbPedidoVta As Controles.CheckBox
    Friend WithEvents txtNroPedidoVta As Controles.TextBox
    Friend WithEvents chbImprimeArchivo As Controles.CheckBox
    Friend WithEvents lblTipoComprobante As Controles.Label
    Friend WithEvents cmbTipoComprobanteOP As Controles.ComboBox
    Friend WithEvents chbOrdenProduccion As Controles.CheckBox
    Friend WithEvents txtIdOrdenProduccion As Controles.TextBox
    Friend WithEvents bscNombreTareas As Controles.Buscador2
    Friend WithEvents chbSeccion As Controles.CheckBox
    Friend WithEvents cmbSecciones As Controles.ComboBox
    Friend WithEvents chbTarea As Controles.CheckBox
    Friend WithEvents bscNombresProductos As Controles.Buscador2
    Friend WithEvents bscCodigoProducto As Controles.Buscador2
    Friend WithEvents chbProducto As Controles.CheckBox
    Friend WithEvents chbCentroProductor As Controles.CheckBox
    Friend WithEvents bscCodigosCentrosProductores As Controles.Buscador2
    Friend WithEvents bscNombresCentrosProductores As Controles.Buscador2
    Friend WithEvents gpbPlanMaestro As GroupBox
    Friend WithEvents ugDetalle As UltraGrid
    Friend WithEvents btnConsultar As ButtonConsultar
    Friend WithEvents btnTodos As Button
    Friend WithEvents cmbTodos As Controles.ComboBox
End Class
