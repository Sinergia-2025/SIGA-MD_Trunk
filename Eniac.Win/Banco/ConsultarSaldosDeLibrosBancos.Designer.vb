<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarSaldosDeLibrosBancos
   Inherits Eniac.Win.BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarSaldosDeLibrosBancos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria", -1, Nothing, 19826672, 0, 0)
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuenta", -1, Nothing, 19826672, 2, 0)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMoneda", -1, Nothing, 19826672, 3, 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo", -1, Nothing, 19826673, 0, 0)
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoConciliado", -1, Nothing, 19826673, 1, 0)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoDolares", -1, Nothing, 19826674, 0, 0)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoConciliadoDolares", -1, Nothing, 19826674, 1, 0)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaBancariaClase", 0, Nothing, 19826672, 1, 0)
        Dim UltraGridGroup1 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(19826672)
        Dim UltraGridGroup2 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Pesos", 19826673)
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridGroup3 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Dolares", 19826674)
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.chbClase = New Eniac.Controles.CheckBox()
        Me.cmbClaseCuenta = New Eniac.Controles.ComboBox()
        Me.cmbConSaldo = New Eniac.Controles.ComboBox()
        Me.lblConSaldo = New Eniac.Controles.Label()
        Me.cmbActiva = New Eniac.Controles.ComboBox()
        Me.lblActiva = New Eniac.Controles.Label()
        Me.cmbMonedas = New Eniac.Controles.ComboBox()
        Me.chbMoneda = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.dpFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaHasta = New Eniac.Controles.Label()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(766, 29)
        Me.tstBarra.TabIndex = 2
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "I&mprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.chbClase)
        Me.grbFiltros.Controls.Add(Me.cmbClaseCuenta)
        Me.grbFiltros.Controls.Add(Me.cmbConSaldo)
        Me.grbFiltros.Controls.Add(Me.lblConSaldo)
        Me.grbFiltros.Controls.Add(Me.cmbActiva)
        Me.grbFiltros.Controls.Add(Me.lblActiva)
        Me.grbFiltros.Controls.Add(Me.cmbMonedas)
        Me.grbFiltros.Controls.Add(Me.chbMoneda)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.dpFechaHasta)
        Me.grbFiltros.Controls.Add(Me.lblFechaHasta)
        Me.grbFiltros.Location = New System.Drawing.Point(8, 36)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(742, 76)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtro"
        '
        'chbClase
        '
        Me.chbClase.AutoSize = True
        Me.chbClase.BindearPropiedadControl = Nothing
        Me.chbClase.BindearPropiedadEntidad = Nothing
        Me.chbClase.ForeColorFocus = System.Drawing.Color.Red
        Me.chbClase.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbClase.IsPK = False
        Me.chbClase.IsRequired = False
        Me.chbClase.Key = Nothing
        Me.chbClase.LabelAsoc = Nothing
        Me.chbClase.Location = New System.Drawing.Point(401, 21)
        Me.chbClase.Name = "chbClase"
        Me.chbClase.Size = New System.Drawing.Size(52, 17)
        Me.chbClase.TabIndex = 4
        Me.chbClase.Text = "Clase"
        '
        'cmbClaseCuenta
        '
        Me.cmbClaseCuenta.BindearPropiedadControl = "SelectedValue"
        Me.cmbClaseCuenta.BindearPropiedadEntidad = "CuentaBancariaClase.IdCuentaBancariaClase"
        Me.cmbClaseCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClaseCuenta.Enabled = False
        Me.cmbClaseCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbClaseCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbClaseCuenta.FormattingEnabled = True
        Me.cmbClaseCuenta.IsPK = False
        Me.cmbClaseCuenta.IsRequired = True
        Me.cmbClaseCuenta.Key = Nothing
        Me.cmbClaseCuenta.LabelAsoc = Nothing
        Me.cmbClaseCuenta.Location = New System.Drawing.Point(459, 19)
        Me.cmbClaseCuenta.Name = "cmbClaseCuenta"
        Me.cmbClaseCuenta.Size = New System.Drawing.Size(130, 21)
        Me.cmbClaseCuenta.TabIndex = 5
        '
        'cmbConSaldo
        '
        Me.cmbConSaldo.BindearPropiedadControl = Nothing
        Me.cmbConSaldo.BindearPropiedadEntidad = Nothing
        Me.cmbConSaldo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConSaldo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbConSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbConSaldo.FormattingEnabled = True
        Me.cmbConSaldo.IsPK = False
        Me.cmbConSaldo.IsRequired = False
        Me.cmbConSaldo.Key = Nothing
        Me.cmbConSaldo.LabelAsoc = Me.lblConSaldo
        Me.cmbConSaldo.Location = New System.Drawing.Point(305, 46)
        Me.cmbConSaldo.Name = "cmbConSaldo"
        Me.cmbConSaldo.Size = New System.Drawing.Size(70, 21)
        Me.cmbConSaldo.TabIndex = 9
        '
        'lblConSaldo
        '
        Me.lblConSaldo.AutoSize = True
        Me.lblConSaldo.LabelAsoc = Nothing
        Me.lblConSaldo.Location = New System.Drawing.Point(231, 50)
        Me.lblConSaldo.Name = "lblConSaldo"
        Me.lblConSaldo.Size = New System.Drawing.Size(56, 13)
        Me.lblConSaldo.TabIndex = 8
        Me.lblConSaldo.Text = "Con Saldo"
        '
        'cmbActiva
        '
        Me.cmbActiva.BindearPropiedadControl = Nothing
        Me.cmbActiva.BindearPropiedadEntidad = Nothing
        Me.cmbActiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActiva.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActiva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActiva.FormattingEnabled = True
        Me.cmbActiva.IsPK = False
        Me.cmbActiva.IsRequired = False
        Me.cmbActiva.Key = Nothing
        Me.cmbActiva.LabelAsoc = Me.lblActiva
        Me.cmbActiva.Location = New System.Drawing.Point(101, 46)
        Me.cmbActiva.Name = "cmbActiva"
        Me.cmbActiva.Size = New System.Drawing.Size(70, 21)
        Me.cmbActiva.TabIndex = 7
        '
        'lblActiva
        '
        Me.lblActiva.AutoSize = True
        Me.lblActiva.LabelAsoc = Nothing
        Me.lblActiva.Location = New System.Drawing.Point(28, 50)
        Me.lblActiva.Name = "lblActiva"
        Me.lblActiva.Size = New System.Drawing.Size(42, 13)
        Me.lblActiva.TabIndex = 6
        Me.lblActiva.Text = "Activas"
        '
        'cmbMonedas
        '
        Me.cmbMonedas.BindearPropiedadControl = "SelectedValue"
        Me.cmbMonedas.BindearPropiedadEntidad = "Moneda.IdMoneda"
        Me.cmbMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonedas.Enabled = False
        Me.cmbMonedas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMonedas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMonedas.FormattingEnabled = True
        Me.cmbMonedas.IsPK = False
        Me.cmbMonedas.IsRequired = True
        Me.cmbMonedas.Key = Nothing
        Me.cmbMonedas.LabelAsoc = Me.chbMoneda
        Me.cmbMonedas.Location = New System.Drawing.Point(305, 19)
        Me.cmbMonedas.Name = "cmbMonedas"
        Me.cmbMonedas.Size = New System.Drawing.Size(70, 21)
        Me.cmbMonedas.TabIndex = 3
        '
        'chbMoneda
        '
        Me.chbMoneda.AutoSize = True
        Me.chbMoneda.BindearPropiedadControl = Nothing
        Me.chbMoneda.BindearPropiedadEntidad = Nothing
        Me.chbMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMoneda.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMoneda.IsPK = False
        Me.chbMoneda.IsRequired = False
        Me.chbMoneda.Key = Nothing
        Me.chbMoneda.LabelAsoc = Nothing
        Me.chbMoneda.Location = New System.Drawing.Point(234, 21)
        Me.chbMoneda.Name = "chbMoneda"
        Me.chbMoneda.Size = New System.Drawing.Size(65, 17)
        Me.chbMoneda.TabIndex = 2
        Me.chbMoneda.Text = "Moneda"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.zoom_32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(626, 22)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 10
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dpFechaHasta
        '
        Me.dpFechaHasta.BindearPropiedadControl = Nothing
        Me.dpFechaHasta.BindearPropiedadEntidad = Nothing
        Me.dpFechaHasta.CustomFormat = "dd/MM/yyyy"
        Me.dpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaHasta.IsPK = False
        Me.dpFechaHasta.IsRequired = False
        Me.dpFechaHasta.Key = ""
        Me.dpFechaHasta.LabelAsoc = Me.lblFechaHasta
        Me.dpFechaHasta.Location = New System.Drawing.Point(101, 19)
        Me.dpFechaHasta.Name = "dpFechaHasta"
        Me.dpFechaHasta.Size = New System.Drawing.Size(95, 20)
        Me.dpFechaHasta.TabIndex = 1
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.LabelAsoc = Nothing
        Me.lblFechaHasta.Location = New System.Drawing.Point(28, 23)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(68, 13)
        Me.lblFechaHasta.TabIndex = 0
        Me.lblFechaHasta.Text = "Fecha Hasta"
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Código"
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.Caption = "Nombre Cuenta"
        UltraGridColumn2.Width = 200
        UltraGridColumn7.Header.Caption = "Id Moneda"
        UltraGridColumn7.Hidden = True
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance3
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "General"
        UltraGridColumn3.Width = 100
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance4
        UltraGridColumn4.Format = "N2"
        UltraGridColumn4.Header.Caption = "Conciliado"
        UltraGridColumn4.Width = 100
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance5
        UltraGridColumn5.Format = "N2"
        UltraGridColumn5.Header.Caption = "General"
        UltraGridColumn5.Width = 100
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance6
        UltraGridColumn6.Format = "N2"
        UltraGridColumn6.Header.Caption = "Conciliado"
        UltraGridColumn6.Width = 100
        UltraGridColumn8.Header.Caption = "Clase"
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn7, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn8})
        UltraGridGroup1.RowLayoutGroupInfo.LabelSpan = 1
        Appearance7.TextHAlignAsString = "Center"
        UltraGridGroup2.Header.Appearance = Appearance7
        UltraGridGroup2.Key = "Pesos"
        UltraGridGroup2.RowLayoutGroupInfo.LabelSpan = 1
        Appearance8.TextHAlignAsString = "Center"
        UltraGridGroup3.Header.Appearance = Appearance8
        UltraGridGroup3.Key = "Dolares"
        UltraGridGroup3.RowLayoutGroupInfo.LabelSpan = 1
        UltraGridBand1.Groups.AddRange(New Infragistics.Win.UltraWinGrid.UltraGridGroup() {UltraGridGroup1, UltraGridGroup2, UltraGridGroup3})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance18
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(8, 118)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(742, 249)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 370)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(766, 22)
        Me.stsStado.TabIndex = 3
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(687, 17)
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance21
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
        'ConsultarSaldosDeLibrosBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 392)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ConsultarSaldosDeLibrosBancos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Saldos de Cuentas Bancarias"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents dpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaHasta As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbMonedas As Eniac.Controles.ComboBox
   Friend WithEvents chbMoneda As Eniac.Controles.CheckBox
   Friend WithEvents ugDetalle As UltraGrid
   Friend WithEvents cmbActiva As Controles.ComboBox
   Friend WithEvents lblActiva As Controles.Label
   Friend WithEvents cmbConSaldo As Controles.ComboBox
   Friend WithEvents lblConSaldo As Controles.Label
   Protected Friend WithEvents stsStado As StatusStrip
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As ToolStripProgressBar
   Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents tsbImprimir As ToolStripButton
    Public WithEvents tsbPreferencias As ToolStripButton
    Friend WithEvents tsddExportar As ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As ToolStripMenuItem
    Friend WithEvents tsmiAPDF As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
    Friend WithEvents sfdExportar As SaveFileDialog
    Friend WithEvents chbClase As Controles.CheckBox
    Friend WithEvents cmbClaseCuenta As Controles.ComboBox
End Class
