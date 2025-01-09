<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClientesDebitosAutomaticosPMC
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesDebitosAutomaticosPMC))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.txtNumeroCompDesde = New Eniac.Controles.TextBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.lblNumeroDesde = New Eniac.Controles.Label()
        Me.lblNumeroHasta = New Eniac.Controles.Label()
        Me.txtNumeroCompHasta = New Eniac.Controles.TextBox()
        Me.chbCargo = New Eniac.Controles.CheckBox()
        Me.lblTipoLiquidacion = New Eniac.Controles.Label()
        Me.cmbTiposLiquidacion = New Eniac.Controles.ComboBox()
        Me.dtpPeriodo = New Eniac.Controles.DateTimePicker()
        Me.chbPeriodo = New Eniac.Controles.CheckBox()
        Me.cmbCategorias = New Eniac.Win.ComboBoxCategorias()
        Me.lblCategorias = New Eniac.Controles.Label()
        Me.chbTomaFoto = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.lblFechaAcreditacionDiasMacro = New Eniac.Controles.Label()
        Me.dtpFechaVencimiento = New Eniac.Controles.DateTimePicker()
        Me.lblFechaVencimiento = New Eniac.Controles.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource5 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNroRefinancion = New Eniac.Controles.TextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.chbEsRefinanciado = New Eniac.Controles.CheckBox()
        Me.cmbFormato = New Eniac.Controles.ComboBox()
        Me.lblFormato = New Eniac.Controles.Label()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbGenerar, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(934, 29)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbGenerar
        '
        Me.tsbGenerar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.tsbGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerar.Name = "tsbGenerar"
        Me.tsbGenerar.Size = New System.Drawing.Size(74, 26)
        Me.tsbGenerar.Text = "&Generar"
        Me.tsbGenerar.ToolTipText = "Imprimir y Grabar (F4)"
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
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.txtNumeroCompDesde)
        Me.grbFiltros.Controls.Add(Me.lblNumeroDesde)
        Me.grbFiltros.Controls.Add(Me.lblNumeroHasta)
        Me.grbFiltros.Controls.Add(Me.txtNumeroCompHasta)
        Me.grbFiltros.Controls.Add(Me.chbNumero)
        Me.grbFiltros.Controls.Add(Me.chbCargo)
        Me.grbFiltros.Controls.Add(Me.lblTipoLiquidacion)
        Me.grbFiltros.Controls.Add(Me.cmbTiposLiquidacion)
        Me.grbFiltros.Controls.Add(Me.dtpPeriodo)
        Me.grbFiltros.Controls.Add(Me.chbPeriodo)
        Me.grbFiltros.Controls.Add(Me.cmbCategorias)
        Me.grbFiltros.Controls.Add(Me.chbTomaFoto)
        Me.grbFiltros.Controls.Add(Me.lblCategorias)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(483, 95)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'txtNumeroCompDesde
        '
        Me.txtNumeroCompDesde.BindearPropiedadControl = Nothing
        Me.txtNumeroCompDesde.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCompDesde.Enabled = False
        Me.txtNumeroCompDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCompDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCompDesde.Formato = "##0"
        Me.txtNumeroCompDesde.IsDecimal = False
        Me.txtNumeroCompDesde.IsNumber = True
        Me.txtNumeroCompDesde.IsPK = False
        Me.txtNumeroCompDesde.IsRequired = False
        Me.txtNumeroCompDesde.Key = ""
        Me.txtNumeroCompDesde.LabelAsoc = Me.chbNumero
        Me.txtNumeroCompDesde.Location = New System.Drawing.Point(119, 69)
        Me.txtNumeroCompDesde.MaxLength = 8
        Me.txtNumeroCompDesde.Name = "txtNumeroCompDesde"
        Me.txtNumeroCompDesde.Size = New System.Drawing.Size(55, 20)
        Me.txtNumeroCompDesde.TabIndex = 7
        Me.txtNumeroCompDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNumero
        '
        Me.chbNumero.AutoSize = True
        Me.chbNumero.BindearPropiedadControl = Nothing
        Me.chbNumero.BindearPropiedadEntidad = Nothing
        Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumero.IsPK = False
        Me.chbNumero.IsRequired = False
        Me.chbNumero.Key = Nothing
        Me.chbNumero.LabelAsoc = Nothing
        Me.chbNumero.Location = New System.Drawing.Point(6, 71)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 5
        Me.chbNumero.Text = "Numero"
        Me.chbNumero.UseVisualStyleBackColor = True
        '
        'lblNumeroDesde
        '
        Me.lblNumeroDesde.AutoSize = True
        Me.lblNumeroDesde.LabelAsoc = Nothing
        Me.lblNumeroDesde.Location = New System.Drawing.Point(75, 73)
        Me.lblNumeroDesde.Name = "lblNumeroDesde"
        Me.lblNumeroDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblNumeroDesde.TabIndex = 6
        Me.lblNumeroDesde.Text = "Desde"
        '
        'lblNumeroHasta
        '
        Me.lblNumeroHasta.AutoSize = True
        Me.lblNumeroHasta.LabelAsoc = Nothing
        Me.lblNumeroHasta.Location = New System.Drawing.Point(180, 73)
        Me.lblNumeroHasta.Name = "lblNumeroHasta"
        Me.lblNumeroHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblNumeroHasta.TabIndex = 8
        Me.lblNumeroHasta.Text = "Hasta"
        '
        'txtNumeroCompHasta
        '
        Me.txtNumeroCompHasta.BindearPropiedadControl = Nothing
        Me.txtNumeroCompHasta.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCompHasta.Enabled = False
        Me.txtNumeroCompHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCompHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCompHasta.Formato = "##0"
        Me.txtNumeroCompHasta.IsDecimal = False
        Me.txtNumeroCompHasta.IsNumber = True
        Me.txtNumeroCompHasta.IsPK = False
        Me.txtNumeroCompHasta.IsRequired = False
        Me.txtNumeroCompHasta.Key = ""
        Me.txtNumeroCompHasta.LabelAsoc = Me.lblNumeroHasta
        Me.txtNumeroCompHasta.Location = New System.Drawing.Point(221, 69)
        Me.txtNumeroCompHasta.MaxLength = 8
        Me.txtNumeroCompHasta.Name = "txtNumeroCompHasta"
        Me.txtNumeroCompHasta.Size = New System.Drawing.Size(55, 20)
        Me.txtNumeroCompHasta.TabIndex = 9
        Me.txtNumeroCompHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbCargo
        '
        Me.chbCargo.AutoSize = True
        Me.chbCargo.BindearPropiedadControl = Nothing
        Me.chbCargo.BindearPropiedadEntidad = Nothing
        Me.chbCargo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCargo.IsPK = False
        Me.chbCargo.IsRequired = False
        Me.chbCargo.Key = Nothing
        Me.chbCargo.LabelAsoc = Nothing
        Me.chbCargo.Location = New System.Drawing.Point(6, 47)
        Me.chbCargo.Name = "chbCargo"
        Me.chbCargo.Size = New System.Drawing.Size(54, 17)
        Me.chbCargo.TabIndex = 2
        Me.chbCargo.Text = "Cargo"
        Me.chbCargo.UseVisualStyleBackColor = True
        '
        'lblTipoLiquidacion
        '
        Me.lblTipoLiquidacion.AutoSize = True
        Me.lblTipoLiquidacion.LabelAsoc = Nothing
        Me.lblTipoLiquidacion.Location = New System.Drawing.Point(59, 49)
        Me.lblTipoLiquidacion.Name = "lblTipoLiquidacion"
        Me.lblTipoLiquidacion.Size = New System.Drawing.Size(85, 13)
        Me.lblTipoLiquidacion.TabIndex = 3
        Me.lblTipoLiquidacion.Text = "Tipo Liquidacion"
        '
        'cmbTiposLiquidacion
        '
        Me.cmbTiposLiquidacion.BindearPropiedadControl = ""
        Me.cmbTiposLiquidacion.BindearPropiedadEntidad = ""
        Me.cmbTiposLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposLiquidacion.Enabled = False
        Me.cmbTiposLiquidacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposLiquidacion.FormattingEnabled = True
        Me.cmbTiposLiquidacion.IsPK = False
        Me.cmbTiposLiquidacion.IsRequired = True
        Me.cmbTiposLiquidacion.Key = Nothing
        Me.cmbTiposLiquidacion.LabelAsoc = Nothing
        Me.cmbTiposLiquidacion.Location = New System.Drawing.Point(150, 42)
        Me.cmbTiposLiquidacion.Name = "cmbTiposLiquidacion"
        Me.cmbTiposLiquidacion.Size = New System.Drawing.Size(136, 21)
        Me.cmbTiposLiquidacion.TabIndex = 4
        '
        'dtpPeriodo
        '
        Me.dtpPeriodo.BindearPropiedadControl = Nothing
        Me.dtpPeriodo.BindearPropiedadEntidad = Nothing
        Me.dtpPeriodo.CalendarMonthBackground = System.Drawing.Color.Tomato
        Me.dtpPeriodo.CustomFormat = "MM/yyyy"
        Me.dtpPeriodo.Enabled = False
        Me.dtpPeriodo.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpPeriodo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodo.IsPK = False
        Me.dtpPeriodo.IsRequired = False
        Me.dtpPeriodo.Key = ""
        Me.dtpPeriodo.LabelAsoc = Nothing
        Me.dtpPeriodo.Location = New System.Drawing.Point(306, 43)
        Me.dtpPeriodo.Name = "dtpPeriodo"
        Me.dtpPeriodo.Size = New System.Drawing.Size(65, 20)
        Me.dtpPeriodo.TabIndex = 11
        '
        'chbPeriodo
        '
        Me.chbPeriodo.AutoSize = True
        Me.chbPeriodo.BindearPropiedadControl = Nothing
        Me.chbPeriodo.BindearPropiedadEntidad = Nothing
        Me.chbPeriodo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPeriodo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPeriodo.IsPK = False
        Me.chbPeriodo.IsRequired = False
        Me.chbPeriodo.Key = Nothing
        Me.chbPeriodo.LabelAsoc = Nothing
        Me.chbPeriodo.Location = New System.Drawing.Point(306, 23)
        Me.chbPeriodo.Name = "chbPeriodo"
        Me.chbPeriodo.Size = New System.Drawing.Size(64, 17)
        Me.chbPeriodo.TabIndex = 10
        Me.chbPeriodo.Text = "Período"
        '
        'cmbCategorias
        '
        Me.cmbCategorias.BindearPropiedadControl = Nothing
        Me.cmbCategorias.BindearPropiedadEntidad = Nothing
        Me.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategorias.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategorias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategorias.FormattingEnabled = True
        Me.cmbCategorias.IsPK = False
        Me.cmbCategorias.IsRequired = False
        Me.cmbCategorias.Key = Nothing
        Me.cmbCategorias.LabelAsoc = Me.lblCategorias
        Me.cmbCategorias.Location = New System.Drawing.Point(79, 19)
        Me.cmbCategorias.Name = "cmbCategorias"
        Me.cmbCategorias.Size = New System.Drawing.Size(199, 21)
        Me.cmbCategorias.TabIndex = 1
        '
        'lblCategorias
        '
        Me.lblCategorias.AutoSize = True
        Me.lblCategorias.LabelAsoc = Nothing
        Me.lblCategorias.Location = New System.Drawing.Point(21, 22)
        Me.lblCategorias.Name = "lblCategorias"
        Me.lblCategorias.Size = New System.Drawing.Size(52, 13)
        Me.lblCategorias.TabIndex = 0
        Me.lblCategorias.Text = "Categoria"
        '
        'chbTomaFoto
        '
        Me.chbTomaFoto.AutoSize = True
        Me.chbTomaFoto.BindearPropiedadControl = Nothing
        Me.chbTomaFoto.BindearPropiedadEntidad = Nothing
        Me.chbTomaFoto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTomaFoto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTomaFoto.IsPK = False
        Me.chbTomaFoto.IsRequired = False
        Me.chbTomaFoto.Key = Nothing
        Me.chbTomaFoto.LabelAsoc = Nothing
        Me.chbTomaFoto.Location = New System.Drawing.Point(306, 72)
        Me.chbTomaFoto.Name = "chbTomaFoto"
        Me.chbTomaFoto.Size = New System.Drawing.Size(121, 17)
        Me.chbTomaFoto.TabIndex = 12
        Me.chbTomaFoto.Text = "Tomar datos de foto"
        Me.chbTomaFoto.UseVisualStyleBackColor = True
        Me.chbTomaFoto.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(377, 19)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 13
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'lblFechaAcreditacionDiasMacro
        '
        Me.lblFechaAcreditacionDiasMacro.AutoSize = True
        Me.lblFechaAcreditacionDiasMacro.LabelAsoc = Nothing
        Me.lblFechaAcreditacionDiasMacro.Location = New System.Drawing.Point(278, 55)
        Me.lblFechaAcreditacionDiasMacro.Name = "lblFechaAcreditacionDiasMacro"
        Me.lblFechaAcreditacionDiasMacro.Size = New System.Drawing.Size(77, 13)
        Me.lblFechaAcreditacionDiasMacro.TabIndex = 3
        Me.lblFechaAcreditacionDiasMacro.Text = "(2 dias habiles)"
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.BindearPropiedadControl = Nothing
        Me.dtpFechaVencimiento.BindearPropiedadEntidad = Nothing
        Me.dtpFechaVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaVencimiento.IsPK = False
        Me.dtpFechaVencimiento.IsRequired = False
        Me.dtpFechaVencimiento.Key = ""
        Me.dtpFechaVencimiento.LabelAsoc = Me.lblFechaVencimiento
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(278, 70)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaVencimiento.TabIndex = 4
        '
        'lblFechaVencimiento
        '
        Me.lblFechaVencimiento.AutoSize = True
        Me.lblFechaVencimiento.LabelAsoc = Nothing
        Me.lblFechaVencimiento.Location = New System.Drawing.Point(207, 74)
        Me.lblFechaVencimiento.Name = "lblFechaVencimiento"
        Me.lblFechaVencimiento.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaVencimiento.TabIndex = 2
        Me.lblFechaVencimiento.Text = "Vencimiento"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 497)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(934, 22)
        Me.stsStado.TabIndex = 5
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(855, 17)
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
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Me.ugDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna aquí para agrupar"
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(12, 139)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(913, 355)
        Me.ugDetalle.TabIndex = 4
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtNroRefinancion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chbEsRefinanciado)
        Me.GroupBox1.Controls.Add(Me.cmbFormato)
        Me.GroupBox1.Controls.Add(Me.lblFormato)
        Me.GroupBox1.Controls.Add(Me.dtpFechaVencimiento)
        Me.GroupBox1.Controls.Add(Me.lblFechaAcreditacionDiasMacro)
        Me.GroupBox1.Controls.Add(Me.lblFechaVencimiento)
        Me.GroupBox1.Location = New System.Drawing.Point(501, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 95)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Modificables"
        '
        'txtNroRefinancion
        '
        Me.txtNroRefinancion.BindearPropiedadControl = Nothing
        Me.txtNroRefinancion.BindearPropiedadEntidad = Nothing
        Me.txtNroRefinancion.Enabled = False
        Me.txtNroRefinancion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroRefinancion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroRefinancion.Formato = "##0"
        Me.txtNroRefinancion.IsDecimal = False
        Me.txtNroRefinancion.IsNumber = True
        Me.txtNroRefinancion.IsPK = False
        Me.txtNroRefinancion.IsRequired = False
        Me.txtNroRefinancion.Key = ""
        Me.txtNroRefinancion.LabelAsoc = Me.chbNumero
        Me.txtNroRefinancion.Location = New System.Drawing.Point(109, 70)
        Me.txtNroRefinancion.MaxLength = 1
        Me.txtNroRefinancion.Name = "txtNroRefinancion"
        Me.txtNroRefinancion.Size = New System.Drawing.Size(25, 20)
        Me.txtNroRefinancion.TabIndex = 15
        Me.txtNroRefinancion.Text = "0"
        Me.txtNroRefinancion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(24, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Nro. Refinanción"
        '
        'chbEsRefinanciado
        '
        Me.chbEsRefinanciado.AutoSize = True
        Me.chbEsRefinanciado.BindearPropiedadControl = Nothing
        Me.chbEsRefinanciado.BindearPropiedadEntidad = Nothing
        Me.chbEsRefinanciado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsRefinanciado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsRefinanciado.IsPK = False
        Me.chbEsRefinanciado.IsRequired = False
        Me.chbEsRefinanciado.Key = Nothing
        Me.chbEsRefinanciado.LabelAsoc = Nothing
        Me.chbEsRefinanciado.Location = New System.Drawing.Point(7, 60)
        Me.chbEsRefinanciado.Name = "chbEsRefinanciado"
        Me.chbEsRefinanciado.Size = New System.Drawing.Size(104, 17)
        Me.chbEsRefinanciado.TabIndex = 14
        Me.chbEsRefinanciado.Text = "Es Refinanciado"
        Me.chbEsRefinanciado.UseVisualStyleBackColor = True
        '
        'cmbFormato
        '
        Me.cmbFormato.BindearPropiedadControl = Nothing
        Me.cmbFormato.BindearPropiedadEntidad = Nothing
        Me.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormato.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormato.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormato.FormattingEnabled = True
        Me.cmbFormato.IsPK = False
        Me.cmbFormato.IsRequired = False
        Me.cmbFormato.Key = Nothing
        Me.cmbFormato.LabelAsoc = Me.lblFormato
        Me.cmbFormato.Location = New System.Drawing.Point(45, 27)
        Me.cmbFormato.Name = "cmbFormato"
        Me.cmbFormato.Size = New System.Drawing.Size(160, 21)
        Me.cmbFormato.TabIndex = 1
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.LabelAsoc = Nothing
        Me.lblFormato.Location = New System.Drawing.Point(3, 31)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(45, 13)
        Me.lblFormato.TabIndex = 0
        Me.lblFormato.Text = "Formato"
        '
        'btnTodos
        '
        Me.btnTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTodos.BackColor = System.Drawing.SystemColors.Control
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(842, 146)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 3
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = False
        Me.btnTodos.Visible = False
        '
        'cmbTodos
        '
        Me.cmbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.cmbTodos.Location = New System.Drawing.Point(715, 147)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 2
        Me.cmbTodos.Visible = False
        '
        'ClientesDebitosAutomaticosPMC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 519)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ClientesDebitosAutomaticosPMC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Archivo Pago Mis Cuentas"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbGenerar As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultar As Eniac.Controles.Button
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource5 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dtpFechaVencimiento As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaVencimiento As Eniac.Controles.Label
    Friend WithEvents lblFechaAcreditacionDiasMacro As Eniac.Controles.Label
    Friend WithEvents chbTomaFoto As Eniac.Controles.CheckBox
    Friend WithEvents cmbCategorias As Eniac.Win.ComboBoxCategorias
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCategorias As Eniac.Controles.Label
    Friend WithEvents dtpPeriodo As Eniac.Controles.DateTimePicker
    Friend WithEvents chbPeriodo As Eniac.Controles.CheckBox
    Friend WithEvents chbCargo As Eniac.Controles.CheckBox
    Friend WithEvents lblTipoLiquidacion As Eniac.Controles.Label
    Friend WithEvents cmbTiposLiquidacion As Eniac.Controles.ComboBox
    Friend WithEvents cmbFormato As Eniac.Controles.ComboBox
    Friend WithEvents lblFormato As Eniac.Controles.Label
    Friend WithEvents btnTodos As Button
    Friend WithEvents cmbTodos As Controles.ComboBox
    Friend WithEvents txtNumeroCompDesde As Controles.TextBox
    Friend WithEvents chbNumero As Controles.CheckBox
    Friend WithEvents lblNumeroDesde As Controles.Label
    Friend WithEvents lblNumeroHasta As Controles.Label
    Friend WithEvents txtNumeroCompHasta As Controles.TextBox
    Friend WithEvents txtNroRefinancion As Controles.TextBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents chbEsRefinanciado As Controles.CheckBox
End Class
