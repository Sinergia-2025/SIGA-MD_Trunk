<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarCuentaCorriente
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerarCuentaCorriente))
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbGenerado = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.bscReserva = New Eniac.Controles.Buscador2()
        Me.lblLetra = New Eniac.Controles.Label()
        Me.lblEmisor = New Eniac.Controles.Label()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.txtLetraComprobante = New Eniac.Controles.TextBox()
        Me.txtEmisor = New Eniac.Controles.TextBox()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtEstablecimiento = New System.Windows.Forms.RadioButton()
        Me.rbtPasajeros = New System.Windows.Forms.RadioButton()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.ugPasajeros = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.dtpFechaViaje = New Eniac.Controles.DateTimePicker()
        Me.Label2 = New Eniac.Controles.Label()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.lblFormaPago = New Eniac.Controles.Label()
        Me.lblSaldo = New Eniac.Controles.Label()
        Me.txtSaldo = New Eniac.Controles.TextBox()
        Me.dtpPrimerVencimiento = New Eniac.Controles.DateTimePicker()
        Me.lblPrimerVencimiento = New Eniac.Controles.Label()
        Me.grpCalculo = New System.Windows.Forms.GroupBox()
        Me.cmbTiposComprobantesGenerar = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.Label4 = New Eniac.Controles.Label()
        Me.txtCantidadCuotas = New Eniac.Controles.TextBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.txtAdelanto = New Eniac.Controles.TextBox()
        Me.lblAdelanto = New Eniac.Controles.Label()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ugPasajeros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCalculo.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.FitWidthToPages = 1
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance1.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance1
        Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Header.TextCenter = ""
        Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
        Me.UltraGridPrintDocument1.Page.Margins.Left = 2
        Me.UltraGridPrintDocument1.Page.Margins.Right = 2
        Me.UltraGridPrintDocument1.Page.Margins.Top = 2
        Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbGenerar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 4
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbGenerar
        '
        Me.tsbGenerar.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
        Me.tsbGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerar.Name = "tsbGenerar"
        Me.tsbGenerar.Size = New System.Drawing.Size(97, 26)
        Me.tsbGenerar.Text = "&Generar (F4)"
        Me.tsbGenerar.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 3
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(803, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbGenerado)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.bscReserva)
        Me.grbFiltros.Controls.Add(Me.lblLetra)
        Me.grbFiltros.Controls.Add(Me.lblEmisor)
        Me.grbFiltros.Controls.Add(Me.lblTipoComprobante)
        Me.grbFiltros.Controls.Add(Me.lblProducto)
        Me.grbFiltros.Controls.Add(Me.txtLetraComprobante)
        Me.grbFiltros.Controls.Add(Me.txtEmisor)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.GroupBox1)
        Me.grbFiltros.Location = New System.Drawing.Point(7, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(511, 126)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'cmbGenerado
        '
        Me.cmbGenerado.BindearPropiedadControl = "SelectedValue"
        Me.cmbGenerado.BindearPropiedadEntidad = "IdTipoComprobanteService"
        Me.cmbGenerado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGenerado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbGenerado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGenerado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGenerado.FormattingEnabled = True
        Me.cmbGenerado.IsPK = False
        Me.cmbGenerado.IsRequired = False
        Me.cmbGenerado.Key = Nothing
        Me.cmbGenerado.LabelAsoc = Nothing
        Me.cmbGenerado.Location = New System.Drawing.Point(74, 69)
        Me.cmbGenerado.Name = "cmbGenerado"
        Me.cmbGenerado.Size = New System.Drawing.Size(65, 21)
        Me.cmbGenerado.TabIndex = 10
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(6, 73)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(62, 13)
        Me.lblGrabanLibro.TabIndex = 9
        Me.lblGrabanLibro.Text = "Generación"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(7, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reserva"
        '
        'bscReserva
        '
        Me.bscReserva.ActivarFiltroEnGrilla = True
        Me.bscReserva.BindearPropiedadControl = Nothing
        Me.bscReserva.BindearPropiedadEntidad = Nothing
        Me.bscReserva.ConfigBuscador = Nothing
        Me.bscReserva.Datos = Nothing
        Me.bscReserva.FilaDevuelta = Nothing
        Me.bscReserva.ForeColorFocus = System.Drawing.Color.Red
        Me.bscReserva.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscReserva.IsDecimal = False
        Me.bscReserva.IsNumber = False
        Me.bscReserva.IsPK = False
        Me.bscReserva.IsRequired = False
        Me.bscReserva.Key = ""
        Me.bscReserva.LabelAsoc = Nothing
        Me.bscReserva.Location = New System.Drawing.Point(266, 33)
        Me.bscReserva.MaxLengh = "32767"
        Me.bscReserva.Name = "bscReserva"
        Me.bscReserva.Permitido = True
        Me.bscReserva.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscReserva.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscReserva.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscReserva.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscReserva.Selecciono = False
        Me.bscReserva.Size = New System.Drawing.Size(94, 20)
        Me.bscReserva.TabIndex = 8
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLetra.LabelAsoc = Nothing
        Me.lblLetra.Location = New System.Drawing.Point(190, 17)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(31, 13)
        Me.lblLetra.TabIndex = 3
        Me.lblLetra.Text = "Letra"
        '
        'lblEmisor
        '
        Me.lblEmisor.AutoSize = True
        Me.lblEmisor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmisor.LabelAsoc = Nothing
        Me.lblEmisor.Location = New System.Drawing.Point(225, 17)
        Me.lblEmisor.Name = "lblEmisor"
        Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
        Me.lblEmisor.TabIndex = 5
        Me.lblEmisor.Text = "Emisor"
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(71, 17)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoComprobante.TabIndex = 1
        Me.lblTipoComprobante.Text = "Tipo"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(261, 17)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(44, 13)
        Me.lblProducto.TabIndex = 7
        Me.lblProducto.Text = "Numero"
        '
        'txtLetraComprobante
        '
        Me.txtLetraComprobante.BindearPropiedadControl = "Text"
        Me.txtLetraComprobante.BindearPropiedadEntidad = "LetraService"
        Me.txtLetraComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtLetraComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLetraComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLetraComprobante.Formato = ""
        Me.txtLetraComprobante.IsDecimal = False
        Me.txtLetraComprobante.IsNumber = False
        Me.txtLetraComprobante.IsPK = False
        Me.txtLetraComprobante.IsRequired = False
        Me.txtLetraComprobante.Key = ""
        Me.txtLetraComprobante.LabelAsoc = Nothing
        Me.txtLetraComprobante.Location = New System.Drawing.Point(193, 33)
        Me.txtLetraComprobante.Name = "txtLetraComprobante"
        Me.txtLetraComprobante.ReadOnly = True
        Me.txtLetraComprobante.Size = New System.Drawing.Size(26, 20)
        Me.txtLetraComprobante.TabIndex = 4
        Me.txtLetraComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEmisor
        '
        Me.txtEmisor.BindearPropiedadControl = "Text"
        Me.txtEmisor.BindearPropiedadEntidad = "CentroEmisorService"
        Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEmisor.Formato = "#0"
        Me.txtEmisor.IsDecimal = True
        Me.txtEmisor.IsNumber = True
        Me.txtEmisor.IsPK = False
        Me.txtEmisor.IsRequired = False
        Me.txtEmisor.Key = ""
        Me.txtEmisor.LabelAsoc = Nothing
        Me.txtEmisor.Location = New System.Drawing.Point(223, 33)
        Me.txtEmisor.MaxLength = 8
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.ReadOnly = True
        Me.txtEmisor.Size = New System.Drawing.Size(40, 20)
        Me.txtEmisor.TabIndex = 6
        Me.txtEmisor.Text = "0"
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = "IdTipoComprobanteService"
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(73, 33)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(117, 21)
        Me.cmbTiposComprobantes.TabIndex = 2
        '
        'chkExpandAll
        '
        Me.chkExpandAll.AutoSize = True
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(406, 97)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
        Me.chkExpandAll.TabIndex = 13
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(405, 51)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 12
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtEstablecimiento)
        Me.GroupBox1.Controls.Add(Me.rbtPasajeros)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 36)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuenta Corriente"
        Me.GroupBox1.Visible = False
        '
        'rbtEstablecimiento
        '
        Me.rbtEstablecimiento.AutoSize = True
        Me.rbtEstablecimiento.Location = New System.Drawing.Point(94, 16)
        Me.rbtEstablecimiento.Name = "rbtEstablecimiento"
        Me.rbtEstablecimiento.Size = New System.Drawing.Size(99, 17)
        Me.rbtEstablecimiento.TabIndex = 1
        Me.rbtEstablecimiento.Text = "Establecimiento"
        Me.rbtEstablecimiento.UseVisualStyleBackColor = True
        '
        'rbtPasajeros
        '
        Me.rbtPasajeros.AutoSize = True
        Me.rbtPasajeros.Checked = True
        Me.rbtPasajeros.Location = New System.Drawing.Point(6, 16)
        Me.rbtPasajeros.Name = "rbtPasajeros"
        Me.rbtPasajeros.Size = New System.Drawing.Size(71, 17)
        Me.rbtPasajeros.TabIndex = 0
        Me.rbtPasajeros.TabStop = True
        Me.rbtPasajeros.Text = "Pasajeros"
        Me.rbtPasajeros.UseVisualStyleBackColor = True
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = ""
        Me.cmbCajas.BindearPropiedadEntidad = ""
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCaja
        Me.cmbCajas.Location = New System.Drawing.Point(97, 98)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(126, 21)
        Me.cmbCajas.TabIndex = 7
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(12, 102)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 6
        Me.lblCaja.Text = "Caja"
        '
        'ugPasajeros
        '
        Me.ugPasajeros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugPasajeros.DisplayLayout.Appearance = Appearance2
        Me.ugPasajeros.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPasajeros.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPasajeros.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPasajeros.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugPasajeros.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPasajeros.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugPasajeros.DisplayLayout.MaxColScrollRegions = 1
        Me.ugPasajeros.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugPasajeros.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugPasajeros.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugPasajeros.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugPasajeros.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPasajeros.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugPasajeros.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugPasajeros.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugPasajeros.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugPasajeros.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugPasajeros.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugPasajeros.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPasajeros.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugPasajeros.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugPasajeros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugPasajeros.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugPasajeros.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugPasajeros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugPasajeros.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugPasajeros.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugPasajeros.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugPasajeros.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugPasajeros.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugPasajeros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugPasajeros.Location = New System.Drawing.Point(7, 170)
        Me.ugPasajeros.Name = "ugPasajeros"
        Me.ugPasajeros.Size = New System.Drawing.Size(973, 366)
        Me.ugPasajeros.TabIndex = 2
        Me.ugPasajeros.Text = "UltraGrid1"
        '
        'dtpFechaViaje
        '
        Me.dtpFechaViaje.BindearPropiedadControl = Nothing
        Me.dtpFechaViaje.BindearPropiedadEntidad = Nothing
        Me.dtpFechaViaje.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaViaje.Enabled = False
        Me.dtpFechaViaje.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaViaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaViaje.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaViaje.IsPK = False
        Me.dtpFechaViaje.IsRequired = False
        Me.dtpFechaViaje.Key = ""
        Me.dtpFechaViaje.LabelAsoc = Me.Label2
        Me.dtpFechaViaje.Location = New System.Drawing.Point(97, 19)
        Me.dtpFechaViaje.Name = "dtpFechaViaje"
        Me.dtpFechaViaje.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaViaje.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha Viaje"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(97, 71)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(126, 21)
        Me.cmbFormaPago.TabIndex = 5
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.LabelAsoc = Nothing
        Me.lblFormaPago.Location = New System.Drawing.Point(12, 75)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
        Me.lblFormaPago.TabIndex = 4
        Me.lblFormaPago.Text = "Forma de &Pago"
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.LabelAsoc = Nothing
        Me.lblSaldo.Location = New System.Drawing.Point(12, 49)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(68, 13)
        Me.lblSaldo.TabIndex = 2
        Me.lblSaldo.Text = "Importe Viaje"
        '
        'txtSaldo
        '
        Me.txtSaldo.BindearPropiedadControl = Nothing
        Me.txtSaldo.BindearPropiedadEntidad = Nothing
        Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldo.Formato = "N2"
        Me.txtSaldo.IsDecimal = True
        Me.txtSaldo.IsNumber = True
        Me.txtSaldo.IsPK = False
        Me.txtSaldo.IsRequired = False
        Me.txtSaldo.Key = ""
        Me.txtSaldo.LabelAsoc = Me.lblSaldo
        Me.txtSaldo.Location = New System.Drawing.Point(97, 45)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(96, 20)
        Me.txtSaldo.TabIndex = 3
        Me.txtSaldo.TabStop = False
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpPrimerVencimiento
        '
        Me.dtpPrimerVencimiento.BindearPropiedadControl = Nothing
        Me.dtpPrimerVencimiento.BindearPropiedadEntidad = Nothing
        Me.dtpPrimerVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.dtpPrimerVencimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpPrimerVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpPrimerVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPrimerVencimiento.IsPK = False
        Me.dtpPrimerVencimiento.IsRequired = False
        Me.dtpPrimerVencimiento.Key = ""
        Me.dtpPrimerVencimiento.LabelAsoc = Me.lblPrimerVencimiento
        Me.dtpPrimerVencimiento.Location = New System.Drawing.Point(354, 48)
        Me.dtpPrimerVencimiento.Name = "dtpPrimerVencimiento"
        Me.dtpPrimerVencimiento.Size = New System.Drawing.Size(96, 20)
        Me.dtpPrimerVencimiento.TabIndex = 9
        '
        'lblPrimerVencimiento
        '
        Me.lblPrimerVencimiento.AutoSize = True
        Me.lblPrimerVencimiento.LabelAsoc = Nothing
        Me.lblPrimerVencimiento.Location = New System.Drawing.Point(251, 52)
        Me.lblPrimerVencimiento.Name = "lblPrimerVencimiento"
        Me.lblPrimerVencimiento.Size = New System.Drawing.Size(97, 13)
        Me.lblPrimerVencimiento.TabIndex = 8
        Me.lblPrimerVencimiento.Text = "Primer Vencimiento"
        '
        'grpCalculo
        '
        Me.grpCalculo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCalculo.Controls.Add(Me.cmbTiposComprobantesGenerar)
        Me.grpCalculo.Controls.Add(Me.Label4)
        Me.grpCalculo.Controls.Add(Me.txtCantidadCuotas)
        Me.grpCalculo.Controls.Add(Me.Label3)
        Me.grpCalculo.Controls.Add(Me.txtAdelanto)
        Me.grpCalculo.Controls.Add(Me.lblAdelanto)
        Me.grpCalculo.Controls.Add(Me.dtpFechaViaje)
        Me.grpCalculo.Controls.Add(Me.dtpPrimerVencimiento)
        Me.grpCalculo.Controls.Add(Me.txtSaldo)
        Me.grpCalculo.Controls.Add(Me.cmbCajas)
        Me.grpCalculo.Controls.Add(Me.lblPrimerVencimiento)
        Me.grpCalculo.Controls.Add(Me.lblSaldo)
        Me.grpCalculo.Controls.Add(Me.lblCaja)
        Me.grpCalculo.Controls.Add(Me.lblFormaPago)
        Me.grpCalculo.Controls.Add(Me.Label2)
        Me.grpCalculo.Controls.Add(Me.cmbFormaPago)
        Me.grpCalculo.Location = New System.Drawing.Point(524, 38)
        Me.grpCalculo.Name = "grpCalculo"
        Me.grpCalculo.Size = New System.Drawing.Size(456, 126)
        Me.grpCalculo.TabIndex = 1
        Me.grpCalculo.TabStop = False
        Me.grpCalculo.Text = "Cálculo"
        '
        'cmbTiposComprobantesGenerar
        '
        Me.cmbTiposComprobantesGenerar.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantesGenerar.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantesGenerar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantesGenerar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesGenerar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesGenerar.FormattingEnabled = True
        Me.cmbTiposComprobantesGenerar.IsPK = False
        Me.cmbTiposComprobantesGenerar.IsRequired = False
        Me.cmbTiposComprobantesGenerar.ItemHeight = 13
        Me.cmbTiposComprobantesGenerar.Key = Nothing
        Me.cmbTiposComprobantesGenerar.LabelAsoc = Nothing
        Me.cmbTiposComprobantesGenerar.Location = New System.Drawing.Point(307, 18)
        Me.cmbTiposComprobantesGenerar.Name = "cmbTiposComprobantesGenerar"
        Me.cmbTiposComprobantesGenerar.Size = New System.Drawing.Size(143, 21)
        Me.cmbTiposComprobantesGenerar.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(198, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Generar Comprobante"
        '
        'txtCantidadCuotas
        '
        Me.txtCantidadCuotas.BindearPropiedadControl = Nothing
        Me.txtCantidadCuotas.BindearPropiedadEntidad = Nothing
        Me.txtCantidadCuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadCuotas.Formato = ""
        Me.txtCantidadCuotas.IsDecimal = True
        Me.txtCantidadCuotas.IsNumber = True
        Me.txtCantidadCuotas.IsPK = False
        Me.txtCantidadCuotas.IsRequired = False
        Me.txtCantidadCuotas.Key = ""
        Me.txtCantidadCuotas.LabelAsoc = Nothing
        Me.txtCantidadCuotas.Location = New System.Drawing.Point(354, 100)
        Me.txtCantidadCuotas.MaxLength = 15
        Me.txtCantidadCuotas.Name = "txtCantidadCuotas"
        Me.txtCantidadCuotas.ReadOnly = True
        Me.txtCantidadCuotas.Size = New System.Drawing.Size(46, 20)
        Me.txtCantidadCuotas.TabIndex = 13
        Me.txtCantidadCuotas.Text = "0"
        Me.txtCantidadCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(251, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Cuotas"
        '
        'txtAdelanto
        '
        Me.txtAdelanto.BindearPropiedadControl = Nothing
        Me.txtAdelanto.BindearPropiedadEntidad = Nothing
        Me.txtAdelanto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAdelanto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAdelanto.Formato = ""
        Me.txtAdelanto.IsDecimal = True
        Me.txtAdelanto.IsNumber = True
        Me.txtAdelanto.IsPK = False
        Me.txtAdelanto.IsRequired = False
        Me.txtAdelanto.Key = ""
        Me.txtAdelanto.LabelAsoc = Nothing
        Me.txtAdelanto.Location = New System.Drawing.Point(354, 74)
        Me.txtAdelanto.MaxLength = 15
        Me.txtAdelanto.Name = "txtAdelanto"
        Me.txtAdelanto.Size = New System.Drawing.Size(96, 20)
        Me.txtAdelanto.TabIndex = 11
        Me.txtAdelanto.Text = "0.00"
        Me.txtAdelanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAdelanto
        '
        Me.lblAdelanto.AutoSize = True
        Me.lblAdelanto.LabelAsoc = Nothing
        Me.lblAdelanto.Location = New System.Drawing.Point(251, 78)
        Me.lblAdelanto.Name = "lblAdelanto"
        Me.lblAdelanto.Size = New System.Drawing.Size(49, 13)
        Me.lblAdelanto.TabIndex = 10
        Me.lblAdelanto.Text = "Adelanto"
        '
        'GenerarCuentaCorriente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.grpCalculo)
        Me.Controls.Add(Me.ugPasajeros)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "GenerarCuentaCorriente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Cuenta Corriente"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ugPasajeros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCalculo.ResumeLayout(False)
        Me.grpCalculo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ugPasajeros As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtEstablecimiento As System.Windows.Forms.RadioButton
   Friend WithEvents rbtPasajeros As System.Windows.Forms.RadioButton
   Friend WithEvents bscReserva As Eniac.Controles.Buscador2
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents lblEmisor As Eniac.Controles.Label
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents txtLetraComprobante As Eniac.Controles.TextBox
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents cmbGenerado As Eniac.Controles.ComboBox
   Friend WithEvents tsbGenerar As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dtpFechaViaje As Controles.DateTimePicker
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents cmbFormaPago As Controles.ComboBox
    Friend WithEvents lblFormaPago As Controles.Label
    Friend WithEvents lblSaldo As Controles.Label
    Friend WithEvents txtSaldo As Controles.TextBox
    Friend WithEvents dtpPrimerVencimiento As Controles.DateTimePicker
    Friend WithEvents lblPrimerVencimiento As Controles.Label
    Friend WithEvents grpCalculo As GroupBox
    Friend WithEvents txtAdelanto As Controles.TextBox
    Friend WithEvents lblAdelanto As Controles.Label
    Friend WithEvents txtCantidadCuotas As Controles.TextBox
    Friend WithEvents Label3 As Controles.Label
    Friend WithEvents Label4 As Controles.Label
    Friend WithEvents cmbTiposComprobantesGenerar As ComboBoxTiposComprobantes
End Class
