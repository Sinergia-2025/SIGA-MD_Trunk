<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMHojaNovedades
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRMHojaNovedades))
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbNuevaNovedad = New System.Windows.Forms.ToolStripButton()
        Me.tscNovedades = New System.Windows.Forms.ToolStripComboBox()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.pnlParametros = New System.Windows.Forms.FlowLayoutPanel()
        Me.chbVerActividades = New Eniac.Controles.CheckBox()
        Me.chbTotalizadoPorCategoria = New Eniac.Controles.CheckBox()
        Me.chbSinHoras = New Eniac.Controles.CheckBox()
        Me.cmbTotalizarPorMes = New Eniac.Controles.ComboBox()
        Me.chbTotalizarPorMes = New Eniac.Controles.Label()
        Me.bscFuncionNuevo = New Eniac.Controles.Buscador2()
        Me.chbFuncionNuevo = New Eniac.Controles.CheckBox()
        Me.txtNumero = New Eniac.Controles.TextBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.chbMesCompleto = New Eniac.Controles.CheckBox()
        Me.chbBloquearFechaHasta = New Eniac.Controles.CheckBox()
        Me.grpMostrar = New System.Windows.Forms.GroupBox()
        Me.pnlMostrar = New System.Windows.Forms.FlowLayoutPanel()
        Me.chbSabados = New Eniac.Controles.CheckBox()
        Me.chbDomingos = New Eniac.Controles.CheckBox()
        Me.chbFeriados = New Eniac.Controles.CheckBox()
        Me.chbCategoriaNovedad = New Eniac.Controles.CheckBox()
        Me.cmbCategoriaNovedad = New Eniac.Controles.ComboBox()
        Me.chbTipoCategoriaNovedad = New Eniac.Controles.CheckBox()
        Me.cmbTipoCategoriaNovedad = New Eniac.Controles.ComboBox()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoProyecto = New Eniac.Controles.Buscador2()
        Me.bscProyecto = New Eniac.Controles.Buscador2()
        Me.chbProyecto = New Eniac.Controles.CheckBox()
        Me.cmbRevisionAdministrativa = New Eniac.Controles.ComboBox()
        Me.lblRevisionAdministrativa = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbIdUsuarioAsignado = New Eniac.Controles.CheckBox()
        Me.cmbIdUsuarioAsignado = New Eniac.Controles.ComboBox()
        Me.bscCodigoFuncionNuevo = New Eniac.Controles.Buscador2()
        Me.btnConsultar = New Eniac.Win.ButtonConsultar()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.splitter1 = New Infragistics.Win.Misc.UltraSplitter()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.grpParametros.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.grpMostrar.SuspendLayout()
        Me.pnlMostrar.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsStado
        '
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(24, 24)
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
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbSalir, Me.tsbNuevaNovedad, Me.tscNovedades})
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'tsbNuevaNovedad
        '
        Me.tsbNuevaNovedad.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbNuevaNovedad.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.tsbNuevaNovedad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevaNovedad.Name = "tsbNuevaNovedad"
        Me.tsbNuevaNovedad.Size = New System.Drawing.Size(67, 26)
        Me.tsbNuevaNovedad.Text = "Nueva"
        Me.tsbNuevaNovedad.Visible = False
        '
        'tscNovedades
        '
        Me.tscNovedades.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tscNovedades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscNovedades.Name = "tscNovedades"
        Me.tscNovedades.Size = New System.Drawing.Size(121, 29)
        Me.tscNovedades.Visible = False
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.grpParametros)
        Me.grbFiltros.Controls.Add(Me.cmbTotalizarPorMes)
        Me.grbFiltros.Controls.Add(Me.chbTotalizarPorMes)
        Me.grbFiltros.Controls.Add(Me.bscFuncionNuevo)
        Me.grbFiltros.Controls.Add(Me.chbFuncionNuevo)
        Me.grbFiltros.Controls.Add(Me.txtNumero)
        Me.grbFiltros.Controls.Add(Me.chbNumero)
        Me.grbFiltros.Controls.Add(Me.chbMesCompleto)
        Me.grbFiltros.Controls.Add(Me.chbBloquearFechaHasta)
        Me.grbFiltros.Controls.Add(Me.grpMostrar)
        Me.grbFiltros.Controls.Add(Me.chbCategoriaNovedad)
        Me.grbFiltros.Controls.Add(Me.cmbCategoriaNovedad)
        Me.grbFiltros.Controls.Add(Me.chbTipoCategoriaNovedad)
        Me.grbFiltros.Controls.Add(Me.cmbTipoCategoriaNovedad)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoProyecto)
        Me.grbFiltros.Controls.Add(Me.bscProyecto)
        Me.grbFiltros.Controls.Add(Me.chbProyecto)
        Me.grbFiltros.Controls.Add(Me.cmbRevisionAdministrativa)
        Me.grbFiltros.Controls.Add(Me.lblRevisionAdministrativa)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.chbIdUsuarioAsignado)
        Me.grbFiltros.Controls.Add(Me.cmbIdUsuarioAsignado)
        Me.grbFiltros.Controls.Add(Me.bscCodigoFuncionNuevo)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grbFiltros.Margin = New System.Windows.Forms.Padding(2)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Padding = New System.Windows.Forms.Padding(2)
        Me.grbFiltros.Size = New System.Drawing.Size(984, 130)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'grpParametros
        '
        Me.grpParametros.Controls.Add(Me.pnlParametros)
        Me.grpParametros.Location = New System.Drawing.Point(571, 66)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.grpParametros.Size = New System.Drawing.Size(293, 58)
        Me.grpParametros.TabIndex = 27
        Me.grpParametros.TabStop = False
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.chbVerActividades)
        Me.pnlParametros.Controls.Add(Me.chbTotalizadoPorCategoria)
        Me.pnlParametros.Controls.Add(Me.chbSinHoras)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParametros.Location = New System.Drawing.Point(2, 13)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(289, 45)
        Me.pnlParametros.TabIndex = 0
        '
        'chbVerActividades
        '
        Me.chbVerActividades.AutoSize = True
        Me.chbVerActividades.BindearPropiedadControl = Nothing
        Me.chbVerActividades.BindearPropiedadEntidad = Nothing
        Me.chbVerActividades.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVerActividades.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVerActividades.IsPK = False
        Me.chbVerActividades.IsRequired = False
        Me.chbVerActividades.Key = Nothing
        Me.chbVerActividades.LabelAsoc = Nothing
        Me.chbVerActividades.Location = New System.Drawing.Point(3, 3)
        Me.chbVerActividades.Name = "chbVerActividades"
        Me.chbVerActividades.Size = New System.Drawing.Size(131, 17)
        Me.chbVerActividades.TabIndex = 0
        Me.chbVerActividades.Text = "Detalle de actividades"
        Me.chbVerActividades.UseVisualStyleBackColor = True
        '
        'chbTotalizadoPorCategoria
        '
        Me.chbTotalizadoPorCategoria.AutoSize = True
        Me.chbTotalizadoPorCategoria.BindearPropiedadControl = Nothing
        Me.chbTotalizadoPorCategoria.BindearPropiedadEntidad = Nothing
        Me.chbTotalizadoPorCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTotalizadoPorCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTotalizadoPorCategoria.IsPK = False
        Me.chbTotalizadoPorCategoria.IsRequired = False
        Me.chbTotalizadoPorCategoria.Key = Nothing
        Me.chbTotalizadoPorCategoria.LabelAsoc = Nothing
        Me.chbTotalizadoPorCategoria.Location = New System.Drawing.Point(140, 3)
        Me.chbTotalizadoPorCategoria.Name = "chbTotalizadoPorCategoria"
        Me.chbTotalizadoPorCategoria.Size = New System.Drawing.Size(142, 17)
        Me.chbTotalizadoPorCategoria.TabIndex = 1
        Me.chbTotalizadoPorCategoria.Text = "Totalizado por categoría"
        Me.chbTotalizadoPorCategoria.UseVisualStyleBackColor = True
        '
        'chbSinHoras
        '
        Me.chbSinHoras.AutoSize = True
        Me.chbSinHoras.BindearPropiedadControl = Nothing
        Me.chbSinHoras.BindearPropiedadEntidad = Nothing
        Me.chbSinHoras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSinHoras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSinHoras.IsPK = False
        Me.chbSinHoras.IsRequired = False
        Me.chbSinHoras.Key = Nothing
        Me.chbSinHoras.LabelAsoc = Nothing
        Me.chbSinHoras.Location = New System.Drawing.Point(3, 26)
        Me.chbSinHoras.Name = "chbSinHoras"
        Me.chbSinHoras.Size = New System.Drawing.Size(129, 17)
        Me.chbSinHoras.TabIndex = 2
        Me.chbSinHoras.Text = "Ocultar días sin horas"
        Me.chbSinHoras.UseVisualStyleBackColor = True
        '
        'cmbTotalizarPorMes
        '
        Me.cmbTotalizarPorMes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTotalizarPorMes.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
        Me.cmbTotalizarPorMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTotalizarPorMes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTotalizarPorMes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTotalizarPorMes.FormattingEnabled = True
        Me.cmbTotalizarPorMes.IsPK = False
        Me.cmbTotalizarPorMes.IsRequired = False
        Me.cmbTotalizarPorMes.Key = Nothing
        Me.cmbTotalizarPorMes.LabelAsoc = Me.chbTotalizarPorMes
        Me.cmbTotalizarPorMes.Location = New System.Drawing.Point(388, 100)
        Me.cmbTotalizarPorMes.Name = "cmbTotalizarPorMes"
        Me.cmbTotalizarPorMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbTotalizarPorMes.TabIndex = 26
        '
        'chbTotalizarPorMes
        '
        Me.chbTotalizarPorMes.AutoSize = True
        Me.chbTotalizarPorMes.LabelAsoc = Nothing
        Me.chbTotalizarPorMes.Location = New System.Drawing.Point(317, 104)
        Me.chbTotalizarPorMes.Name = "chbTotalizarPorMes"
        Me.chbTotalizarPorMes.Size = New System.Drawing.Size(65, 13)
        Me.chbTotalizarPorMes.TabIndex = 25
        Me.chbTotalizarPorMes.Text = "Totalizar por"
        '
        'bscFuncionNuevo
        '
        Me.bscFuncionNuevo.ActivarFiltroEnGrilla = True
        Me.bscFuncionNuevo.BindearPropiedadControl = Nothing
        Me.bscFuncionNuevo.BindearPropiedadEntidad = Nothing
        Me.bscFuncionNuevo.ConfigBuscador = Nothing
        Me.bscFuncionNuevo.Datos = Nothing
        Me.bscFuncionNuevo.FilaDevuelta = Nothing
        Me.bscFuncionNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscFuncionNuevo.IsDecimal = False
        Me.bscFuncionNuevo.IsNumber = False
        Me.bscFuncionNuevo.IsPK = False
        Me.bscFuncionNuevo.IsRequired = False
        Me.bscFuncionNuevo.Key = ""
        Me.bscFuncionNuevo.LabelAsoc = Me.chbFuncionNuevo
        Me.bscFuncionNuevo.Location = New System.Drawing.Point(109, 99)
        Me.bscFuncionNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.bscFuncionNuevo.MaxLengh = "32767"
        Me.bscFuncionNuevo.Name = "bscFuncionNuevo"
        Me.bscFuncionNuevo.Permitido = False
        Me.bscFuncionNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscFuncionNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscFuncionNuevo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscFuncionNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscFuncionNuevo.Selecciono = False
        Me.bscFuncionNuevo.Size = New System.Drawing.Size(197, 20)
        Me.bscFuncionNuevo.TabIndex = 23
        '
        'chbFuncionNuevo
        '
        Me.chbFuncionNuevo.AutoSize = True
        Me.chbFuncionNuevo.BindearPropiedadControl = Nothing
        Me.chbFuncionNuevo.BindearPropiedadEntidad = Nothing
        Me.chbFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFuncionNuevo.IsPK = False
        Me.chbFuncionNuevo.IsRequired = False
        Me.chbFuncionNuevo.Key = Nothing
        Me.chbFuncionNuevo.LabelAsoc = Nothing
        Me.chbFuncionNuevo.Location = New System.Drawing.Point(8, 102)
        Me.chbFuncionNuevo.Name = "chbFuncionNuevo"
        Me.chbFuncionNuevo.Size = New System.Drawing.Size(64, 17)
        Me.chbFuncionNuevo.TabIndex = 22
        Me.chbFuncionNuevo.Text = "Función"
        Me.chbFuncionNuevo.UseVisualStyleBackColor = True
        '
        'txtNumero
        '
        Me.txtNumero.BindearPropiedadControl = Nothing
        Me.txtNumero.BindearPropiedadEntidad = Nothing
        Me.txtNumero.Enabled = False
        Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumero.Formato = "##0"
        Me.txtNumero.IsDecimal = False
        Me.txtNumero.IsNumber = True
        Me.txtNumero.IsPK = False
        Me.txtNumero.IsRequired = False
        Me.txtNumero.Key = ""
        Me.txtNumero.LabelAsoc = Me.chbNumero
        Me.txtNumero.Location = New System.Drawing.Point(920, 18)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(59, 20)
        Me.txtNumero.TabIndex = 11
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.chbNumero.Location = New System.Drawing.Point(855, 20)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 10
        Me.chbNumero.Text = "Numero"
        Me.chbNumero.UseVisualStyleBackColor = True
        '
        'chbMesCompleto
        '
        Me.chbMesCompleto.AutoSize = True
        Me.chbMesCompleto.BindearPropiedadControl = Nothing
        Me.chbMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chbMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMesCompleto.IsPK = False
        Me.chbMesCompleto.IsRequired = False
        Me.chbMesCompleto.Key = Nothing
        Me.chbMesCompleto.LabelAsoc = Nothing
        Me.chbMesCompleto.Location = New System.Drawing.Point(236, 20)
        Me.chbMesCompleto.Name = "chbMesCompleto"
        Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chbMesCompleto.TabIndex = 2
        Me.chbMesCompleto.Text = "Mes Completo"
        Me.chbMesCompleto.UseVisualStyleBackColor = True
        '
        'chbBloquearFechaHasta
        '
        Me.chbBloquearFechaHasta.AutoSize = True
        Me.chbBloquearFechaHasta.BindearPropiedadControl = Nothing
        Me.chbBloquearFechaHasta.BindearPropiedadEntidad = Nothing
        Me.chbBloquearFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBloquearFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBloquearFechaHasta.IsPK = False
        Me.chbBloquearFechaHasta.IsRequired = False
        Me.chbBloquearFechaHasta.Key = Nothing
        Me.chbBloquearFechaHasta.LabelAsoc = Nothing
        Me.chbBloquearFechaHasta.Location = New System.Drawing.Point(571, 20)
        Me.chbBloquearFechaHasta.Name = "chbBloquearFechaHasta"
        Me.chbBloquearFechaHasta.Size = New System.Drawing.Size(99, 17)
        Me.chbBloquearFechaHasta.TabIndex = 7
        Me.chbBloquearFechaHasta.Text = "Vincular fechas"
        Me.chbBloquearFechaHasta.UseVisualStyleBackColor = True
        '
        'grpMostrar
        '
        Me.grpMostrar.Controls.Add(Me.pnlMostrar)
        Me.grpMostrar.Location = New System.Drawing.Point(870, 44)
        Me.grpMostrar.Name = "grpMostrar"
        Me.grpMostrar.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.grpMostrar.Size = New System.Drawing.Size(110, 80)
        Me.grpMostrar.TabIndex = 28
        Me.grpMostrar.TabStop = False
        Me.grpMostrar.Text = "Mostrar..."
        '
        'pnlMostrar
        '
        Me.pnlMostrar.Controls.Add(Me.chbSabados)
        Me.pnlMostrar.Controls.Add(Me.chbDomingos)
        Me.pnlMostrar.Controls.Add(Me.chbFeriados)
        Me.pnlMostrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMostrar.Location = New System.Drawing.Point(2, 13)
        Me.pnlMostrar.Name = "pnlMostrar"
        Me.pnlMostrar.Size = New System.Drawing.Size(106, 67)
        Me.pnlMostrar.TabIndex = 0
        Me.pnlMostrar.Text = "Mostrar..."
        '
        'chbSabados
        '
        Me.chbSabados.AutoSize = True
        Me.chbSabados.BindearPropiedadControl = Nothing
        Me.chbSabados.BindearPropiedadEntidad = Nothing
        Me.chbSabados.Checked = True
        Me.chbSabados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSabados.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSabados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSabados.IsPK = False
        Me.chbSabados.IsRequired = False
        Me.chbSabados.Key = Nothing
        Me.chbSabados.LabelAsoc = Nothing
        Me.chbSabados.Location = New System.Drawing.Point(3, 3)
        Me.chbSabados.Name = "chbSabados"
        Me.chbSabados.Size = New System.Drawing.Size(68, 17)
        Me.chbSabados.TabIndex = 0
        Me.chbSabados.Text = "Sábados"
        Me.chbSabados.UseVisualStyleBackColor = True
        '
        'chbDomingos
        '
        Me.chbDomingos.AutoSize = True
        Me.chbDomingos.BindearPropiedadControl = Nothing
        Me.chbDomingos.BindearPropiedadEntidad = Nothing
        Me.chbDomingos.Checked = True
        Me.chbDomingos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbDomingos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDomingos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDomingos.IsPK = False
        Me.chbDomingos.IsRequired = False
        Me.chbDomingos.Key = Nothing
        Me.chbDomingos.LabelAsoc = Nothing
        Me.chbDomingos.Location = New System.Drawing.Point(3, 26)
        Me.chbDomingos.Name = "chbDomingos"
        Me.chbDomingos.Size = New System.Drawing.Size(73, 17)
        Me.chbDomingos.TabIndex = 1
        Me.chbDomingos.Text = "Domingos"
        Me.chbDomingos.UseVisualStyleBackColor = True
        '
        'chbFeriados
        '
        Me.chbFeriados.AutoSize = True
        Me.chbFeriados.BindearPropiedadControl = Nothing
        Me.chbFeriados.BindearPropiedadEntidad = Nothing
        Me.chbFeriados.Checked = True
        Me.chbFeriados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbFeriados.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFeriados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFeriados.IsPK = False
        Me.chbFeriados.IsRequired = False
        Me.chbFeriados.Key = Nothing
        Me.chbFeriados.LabelAsoc = Nothing
        Me.chbFeriados.Location = New System.Drawing.Point(3, 49)
        Me.chbFeriados.Name = "chbFeriados"
        Me.chbFeriados.Size = New System.Drawing.Size(66, 17)
        Me.chbFeriados.TabIndex = 2
        Me.chbFeriados.Text = "Feriados"
        Me.chbFeriados.UseVisualStyleBackColor = True
        '
        'chbCategoriaNovedad
        '
        Me.chbCategoriaNovedad.AutoSize = True
        Me.chbCategoriaNovedad.BindearPropiedadControl = Nothing
        Me.chbCategoriaNovedad.BindearPropiedadEntidad = Nothing
        Me.chbCategoriaNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoriaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoriaNovedad.IsPK = False
        Me.chbCategoriaNovedad.IsRequired = False
        Me.chbCategoriaNovedad.Key = Nothing
        Me.chbCategoriaNovedad.LabelAsoc = Nothing
        Me.chbCategoriaNovedad.Location = New System.Drawing.Point(309, 73)
        Me.chbCategoriaNovedad.Name = "chbCategoriaNovedad"
        Me.chbCategoriaNovedad.Size = New System.Drawing.Size(73, 17)
        Me.chbCategoriaNovedad.TabIndex = 20
        Me.chbCategoriaNovedad.Text = "Categoría"
        '
        'cmbCategoriaNovedad
        '
        Me.cmbCategoriaNovedad.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoriaNovedad.BindearPropiedadEntidad = "UsuarioAsignado.Usuario"
        Me.cmbCategoriaNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriaNovedad.Enabled = False
        Me.cmbCategoriaNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriaNovedad.FormattingEnabled = True
        Me.cmbCategoriaNovedad.IsPK = False
        Me.cmbCategoriaNovedad.IsRequired = False
        Me.cmbCategoriaNovedad.Key = Nothing
        Me.cmbCategoriaNovedad.LabelAsoc = Me.chbCategoriaNovedad
        Me.cmbCategoriaNovedad.Location = New System.Drawing.Point(388, 71)
        Me.cmbCategoriaNovedad.Name = "cmbCategoriaNovedad"
        Me.cmbCategoriaNovedad.Size = New System.Drawing.Size(121, 21)
        Me.cmbCategoriaNovedad.TabIndex = 21
        '
        'chbTipoCategoriaNovedad
        '
        Me.chbTipoCategoriaNovedad.AutoSize = True
        Me.chbTipoCategoriaNovedad.BindearPropiedadControl = Nothing
        Me.chbTipoCategoriaNovedad.BindearPropiedadEntidad = Nothing
        Me.chbTipoCategoriaNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoCategoriaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoCategoriaNovedad.IsPK = False
        Me.chbTipoCategoriaNovedad.IsRequired = False
        Me.chbTipoCategoriaNovedad.Key = Nothing
        Me.chbTipoCategoriaNovedad.LabelAsoc = Nothing
        Me.chbTipoCategoriaNovedad.Location = New System.Drawing.Point(8, 73)
        Me.chbTipoCategoriaNovedad.Name = "chbTipoCategoriaNovedad"
        Me.chbTipoCategoriaNovedad.Size = New System.Drawing.Size(97, 17)
        Me.chbTipoCategoriaNovedad.TabIndex = 18
        Me.chbTipoCategoriaNovedad.Text = "Tipo Categoría"
        '
        'cmbTipoCategoriaNovedad
        '
        Me.cmbTipoCategoriaNovedad.BindearPropiedadControl = ""
        Me.cmbTipoCategoriaNovedad.BindearPropiedadEntidad = ""
        Me.cmbTipoCategoriaNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCategoriaNovedad.Enabled = False
        Me.cmbTipoCategoriaNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoCategoriaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoCategoriaNovedad.FormattingEnabled = True
        Me.cmbTipoCategoriaNovedad.IsPK = False
        Me.cmbTipoCategoriaNovedad.IsRequired = False
        Me.cmbTipoCategoriaNovedad.Key = Nothing
        Me.cmbTipoCategoriaNovedad.LabelAsoc = Me.chbTipoCategoriaNovedad
        Me.cmbTipoCategoriaNovedad.Location = New System.Drawing.Point(109, 71)
        Me.cmbTipoCategoriaNovedad.Name = "cmbTipoCategoriaNovedad"
        Me.cmbTipoCategoriaNovedad.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoCategoriaNovedad.TabIndex = 19
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
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
        Me.bscCliente.LabelAsoc = Nothing
        Me.bscCliente.Location = New System.Drawing.Point(203, 44)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = False
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(230, 23)
        Me.bscCliente.TabIndex = 14
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(109, 44)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 13
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
        Me.chbCliente.Location = New System.Drawing.Point(8, 47)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 12
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'bscCodigoProyecto
        '
        Me.bscCodigoProyecto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProyecto.BindearPropiedadControl = Nothing
        Me.bscCodigoProyecto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProyecto.ConfigBuscador = Nothing
        Me.bscCodigoProyecto.Datos = Nothing
        Me.bscCodigoProyecto.FilaDevuelta = Nothing
        Me.bscCodigoProyecto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProyecto.IsDecimal = False
        Me.bscCodigoProyecto.IsNumber = False
        Me.bscCodigoProyecto.IsPK = False
        Me.bscCodigoProyecto.IsRequired = False
        Me.bscCodigoProyecto.Key = ""
        Me.bscCodigoProyecto.LabelAsoc = Nothing
        Me.bscCodigoProyecto.Location = New System.Drawing.Point(517, 44)
        Me.bscCodigoProyecto.MaxLengh = "32767"
        Me.bscCodigoProyecto.Name = "bscCodigoProyecto"
        Me.bscCodigoProyecto.Permitido = False
        Me.bscCodigoProyecto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProyecto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProyecto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProyecto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProyecto.Selecciono = False
        Me.bscCodigoProyecto.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProyecto.TabIndex = 16
        '
        'bscProyecto
        '
        Me.bscProyecto.ActivarFiltroEnGrilla = True
        Me.bscProyecto.AutoSize = True
        Me.bscProyecto.BindearPropiedadControl = Nothing
        Me.bscProyecto.BindearPropiedadEntidad = Nothing
        Me.bscProyecto.ConfigBuscador = Nothing
        Me.bscProyecto.Datos = Nothing
        Me.bscProyecto.FilaDevuelta = Nothing
        Me.bscProyecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProyecto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProyecto.IsDecimal = False
        Me.bscProyecto.IsNumber = False
        Me.bscProyecto.IsPK = False
        Me.bscProyecto.IsRequired = False
        Me.bscProyecto.Key = ""
        Me.bscProyecto.LabelAsoc = Nothing
        Me.bscProyecto.Location = New System.Drawing.Point(611, 44)
        Me.bscProyecto.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProyecto.MaxLengh = "32767"
        Me.bscProyecto.Name = "bscProyecto"
        Me.bscProyecto.Permitido = False
        Me.bscProyecto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProyecto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProyecto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProyecto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProyecto.Selecciono = False
        Me.bscProyecto.Size = New System.Drawing.Size(230, 23)
        Me.bscProyecto.TabIndex = 17
        '
        'chbProyecto
        '
        Me.chbProyecto.AutoSize = True
        Me.chbProyecto.BindearPropiedadControl = Nothing
        Me.chbProyecto.BindearPropiedadEntidad = Nothing
        Me.chbProyecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProyecto.IsPK = False
        Me.chbProyecto.IsRequired = False
        Me.chbProyecto.Key = Nothing
        Me.chbProyecto.LabelAsoc = Nothing
        Me.chbProyecto.Location = New System.Drawing.Point(440, 47)
        Me.chbProyecto.Name = "chbProyecto"
        Me.chbProyecto.Size = New System.Drawing.Size(68, 17)
        Me.chbProyecto.TabIndex = 15
        Me.chbProyecto.Text = "Proyecto"
        Me.chbProyecto.UseVisualStyleBackColor = True
        '
        'cmbRevisionAdministrativa
        '
        Me.cmbRevisionAdministrativa.BindearPropiedadControl = Nothing
        Me.cmbRevisionAdministrativa.BindearPropiedadEntidad = Nothing
        Me.cmbRevisionAdministrativa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRevisionAdministrativa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRevisionAdministrativa.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRevisionAdministrativa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRevisionAdministrativa.FormattingEnabled = True
        Me.cmbRevisionAdministrativa.IsPK = False
        Me.cmbRevisionAdministrativa.IsRequired = False
        Me.cmbRevisionAdministrativa.Key = Nothing
        Me.cmbRevisionAdministrativa.LabelAsoc = Me.lblRevisionAdministrativa
        Me.cmbRevisionAdministrativa.Location = New System.Drawing.Point(773, 18)
        Me.cmbRevisionAdministrativa.Name = "cmbRevisionAdministrativa"
        Me.cmbRevisionAdministrativa.Size = New System.Drawing.Size(76, 21)
        Me.cmbRevisionAdministrativa.TabIndex = 9
        '
        'lblRevisionAdministrativa
        '
        Me.lblRevisionAdministrativa.AutoSize = True
        Me.lblRevisionAdministrativa.LabelAsoc = Nothing
        Me.lblRevisionAdministrativa.Location = New System.Drawing.Point(674, 22)
        Me.lblRevisionAdministrativa.Name = "lblRevisionAdministrativa"
        Me.lblRevisionAdministrativa.Size = New System.Drawing.Size(98, 13)
        Me.lblRevisionAdministrativa.TabIndex = 8
        Me.lblRevisionAdministrativa.Text = "Rev. Administrativa"
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
        Me.dtpHasta.Location = New System.Drawing.Point(490, 18)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(78, 20)
        Me.dtpHasta.TabIndex = 6
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(453, 22)
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
        Me.dtpDesde.Location = New System.Drawing.Point(371, 18)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(80, 20)
        Me.dtpDesde.TabIndex = 4
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(326, 22)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 3
        Me.lblDesde.Text = "Desde"
        '
        'chbIdUsuarioAsignado
        '
        Me.chbIdUsuarioAsignado.AutoSize = True
        Me.chbIdUsuarioAsignado.BindearPropiedadControl = Nothing
        Me.chbIdUsuarioAsignado.BindearPropiedadEntidad = Nothing
        Me.chbIdUsuarioAsignado.Checked = True
        Me.chbIdUsuarioAsignado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbIdUsuarioAsignado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIdUsuarioAsignado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIdUsuarioAsignado.IsPK = False
        Me.chbIdUsuarioAsignado.IsRequired = False
        Me.chbIdUsuarioAsignado.Key = Nothing
        Me.chbIdUsuarioAsignado.LabelAsoc = Nothing
        Me.chbIdUsuarioAsignado.Location = New System.Drawing.Point(8, 20)
        Me.chbIdUsuarioAsignado.Name = "chbIdUsuarioAsignado"
        Me.chbIdUsuarioAsignado.Size = New System.Drawing.Size(79, 17)
        Me.chbIdUsuarioAsignado.TabIndex = 0
        Me.chbIdUsuarioAsignado.Text = "Asignado a"
        '
        'cmbIdUsuarioAsignado
        '
        Me.cmbIdUsuarioAsignado.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdUsuarioAsignado.BindearPropiedadEntidad = "UsuarioAsignado.Usuario"
        Me.cmbIdUsuarioAsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdUsuarioAsignado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdUsuarioAsignado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdUsuarioAsignado.FormattingEnabled = True
        Me.cmbIdUsuarioAsignado.IsPK = False
        Me.cmbIdUsuarioAsignado.IsRequired = False
        Me.cmbIdUsuarioAsignado.Key = Nothing
        Me.cmbIdUsuarioAsignado.LabelAsoc = Me.chbIdUsuarioAsignado
        Me.cmbIdUsuarioAsignado.Location = New System.Drawing.Point(109, 18)
        Me.cmbIdUsuarioAsignado.Name = "cmbIdUsuarioAsignado"
        Me.cmbIdUsuarioAsignado.Size = New System.Drawing.Size(121, 21)
        Me.cmbIdUsuarioAsignado.TabIndex = 1
        '
        'bscCodigoFuncionNuevo
        '
        Me.bscCodigoFuncionNuevo.ActivarFiltroEnGrilla = True
        Me.bscCodigoFuncionNuevo.BindearPropiedadControl = Nothing
        Me.bscCodigoFuncionNuevo.BindearPropiedadEntidad = Nothing
        Me.bscCodigoFuncionNuevo.ConfigBuscador = Nothing
        Me.bscCodigoFuncionNuevo.Datos = Nothing
        Me.bscCodigoFuncionNuevo.Enabled = False
        Me.bscCodigoFuncionNuevo.FilaDevuelta = Nothing
        Me.bscCodigoFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoFuncionNuevo.IsDecimal = False
        Me.bscCodigoFuncionNuevo.IsNumber = False
        Me.bscCodigoFuncionNuevo.IsPK = False
        Me.bscCodigoFuncionNuevo.IsRequired = False
        Me.bscCodigoFuncionNuevo.Key = ""
        Me.bscCodigoFuncionNuevo.LabelAsoc = Me.chbFuncionNuevo
        Me.bscCodigoFuncionNuevo.Location = New System.Drawing.Point(216, 99)
        Me.bscCodigoFuncionNuevo.MaxLengh = "32767"
        Me.bscCodigoFuncionNuevo.Name = "bscCodigoFuncionNuevo"
        Me.bscCodigoFuncionNuevo.Permitido = True
        Me.bscCodigoFuncionNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoFuncionNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoFuncionNuevo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoFuncionNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoFuncionNuevo.Selecciono = False
        Me.bscCodigoFuncionNuevo.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoFuncionNuevo.TabIndex = 24
        Me.bscCodigoFuncionNuevo.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(869, 4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance13
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
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
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
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
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
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
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
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 365)
        Me.ugDetalle.TabIndex = 0
        Me.ugDetalle.ToolStripLabelRegistros = Nothing
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Controls.Add(Me.btnConsultar)
        Me.pnlDetalle.Controls.Add(Me.ugDetalle)
        Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetalle.Location = New System.Drawing.Point(0, 174)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(984, 365)
        Me.pnlDetalle.TabIndex = 2
        '
        'splitter1
        '
        Me.splitter1.BackColor = System.Drawing.SystemColors.Control
        Me.splitter1.ButtonExtent = 360
        Me.splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitter1.Location = New System.Drawing.Point(0, 159)
        Me.splitter1.MinSize = 40
        Me.splitter1.Name = "splitter1"
        Me.splitter1.RestoreExtent = 151
        Me.splitter1.Size = New System.Drawing.Size(984, 15)
        Me.splitter1.TabIndex = 1
        '
        'CRMHojaNovedades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.pnlDetalle)
        Me.Controls.Add(Me.splitter1)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "CRMHojaNovedades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hoja de Novedades"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.grpParametros.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.grpMostrar.ResumeLayout(False)
        Me.pnlMostrar.ResumeLayout(False)
        Me.pnlMostrar.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As ButtonConsultar
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents chbIdUsuarioAsignado As Eniac.Controles.CheckBox
   Friend WithEvents cmbIdUsuarioAsignado As Eniac.Controles.ComboBox
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents tsbNuevaNovedad As System.Windows.Forms.ToolStripButton
   Friend WithEvents tscNovedades As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbVerActividades As Eniac.Controles.CheckBox
   Friend WithEvents cmbRevisionAdministrativa As Eniac.Controles.ComboBox
   Friend WithEvents lblRevisionAdministrativa As Eniac.Controles.Label
   Friend WithEvents bscCodigoProyecto As Eniac.Controles.Buscador2
    Friend WithEvents chbProyecto As Eniac.Controles.CheckBox
    Friend WithEvents bscProyecto As Eniac.Controles.Buscador2
    Friend WithEvents bscCliente As Eniac.Controles.Buscador2
    Friend WithEvents chbCliente As Eniac.Controles.CheckBox
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
    Friend WithEvents chbTotalizadoPorCategoria As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoriaNovedad As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoriaNovedad As Eniac.Controles.ComboBox
   Friend WithEvents chbTipoCategoriaNovedad As Eniac.Controles.CheckBox
   Friend WithEvents cmbTipoCategoriaNovedad As Eniac.Controles.ComboBox
   Friend WithEvents pnlMostrar As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents chbFeriados As Eniac.Controles.CheckBox
   Friend WithEvents chbDomingos As Eniac.Controles.CheckBox
   Friend WithEvents chbSabados As Eniac.Controles.CheckBox
   Friend WithEvents grpMostrar As System.Windows.Forms.GroupBox
   Friend WithEvents chbBloquearFechaHasta As Eniac.Controles.CheckBox
   Friend WithEvents chbMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents bscFuncionNuevo As Eniac.Controles.Buscador2
   Friend WithEvents chbFuncionNuevo As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
    Friend WithEvents bscCodigoFuncionNuevo As Eniac.Controles.Buscador2
    Friend WithEvents chbTotalizarPorMes As Eniac.Controles.Label
   Friend WithEvents cmbTotalizarPorMes As Eniac.Controles.ComboBox
    Friend WithEvents chbSinHoras As Controles.CheckBox
    Friend WithEvents pnlDetalle As Panel
    Friend WithEvents grpParametros As GroupBox
    Friend WithEvents pnlParametros As FlowLayoutPanel
    Friend WithEvents splitter1 As Misc.UltraSplitter
End Class
