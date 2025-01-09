<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenDeBancos
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResumenDeBancos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdGrupoCuenta")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaBanco")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IngresosPesos")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EgresosPesos")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalesPesos")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IngresosDolar")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EgresosDolar")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalesDolar")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdGrupoCuenta")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCuentaBanco")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IngresosPesos")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EgresosPesos")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TotalesPesos")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IngresosDolar")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EgresosDolar")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TotalesDolar")
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.bscCuentaBancaria = New Eniac.Controles.Buscador2()
      Me.chbCuentaBancaria = New Eniac.Controles.CheckBox()
      Me.rdbFechaMovimiento = New Eniac.Controles.RadioButton()
      Me.rdbFechaPlanilla = New Eniac.Controles.RadioButton()
      Me.lblFechaDe = New Eniac.Controles.Label()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.grbFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.bscCuentaBancaria)
      Me.grbFiltros.Controls.Add(Me.chbCuentaBancaria)
      Me.grbFiltros.Controls.Add(Me.rdbFechaMovimiento)
      Me.grbFiltros.Controls.Add(Me.rdbFechaPlanilla)
      Me.grbFiltros.Controls.Add(Me.lblFechaDe)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Location = New System.Drawing.Point(5, 35)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(954, 80)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(837, 18)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 19
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'bscCuentaBancaria
      '
      Me.bscCuentaBancaria.ActivarFiltroEnGrilla = True
      Me.bscCuentaBancaria.BindearPropiedadControl = Nothing
      Me.bscCuentaBancaria.BindearPropiedadEntidad = Nothing
      Me.bscCuentaBancaria.ConfigBuscador = Nothing
      Me.bscCuentaBancaria.Datos = Nothing
      Me.bscCuentaBancaria.Enabled = False
      Me.bscCuentaBancaria.FilaDevuelta = Nothing
      Me.bscCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCuentaBancaria.IsDecimal = False
      Me.bscCuentaBancaria.IsNumber = False
      Me.bscCuentaBancaria.IsPK = False
      Me.bscCuentaBancaria.IsRequired = False
      Me.bscCuentaBancaria.Key = ""
      Me.bscCuentaBancaria.LabelAsoc = Nothing
      Me.bscCuentaBancaria.Location = New System.Drawing.Point(123, 49)
      Me.bscCuentaBancaria.MaxLengh = "32767"
      Me.bscCuentaBancaria.Name = "bscCuentaBancaria"
      Me.bscCuentaBancaria.Permitido = True
      Me.bscCuentaBancaria.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCuentaBancaria.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCuentaBancaria.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCuentaBancaria.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCuentaBancaria.Selecciono = False
      Me.bscCuentaBancaria.Size = New System.Drawing.Size(274, 20)
      Me.bscCuentaBancaria.TabIndex = 9
      '
      'chbCuentaBancaria
      '
      Me.chbCuentaBancaria.AutoSize = True
      Me.chbCuentaBancaria.BindearPropiedadControl = Nothing
      Me.chbCuentaBancaria.BindearPropiedadEntidad = Nothing
      Me.chbCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCuentaBancaria.IsPK = False
      Me.chbCuentaBancaria.IsRequired = False
      Me.chbCuentaBancaria.Key = Nothing
      Me.chbCuentaBancaria.LabelAsoc = Nothing
      Me.chbCuentaBancaria.Location = New System.Drawing.Point(12, 51)
      Me.chbCuentaBancaria.Name = "chbCuentaBancaria"
      Me.chbCuentaBancaria.Size = New System.Drawing.Size(105, 17)
      Me.chbCuentaBancaria.TabIndex = 8
      Me.chbCuentaBancaria.Text = "Cuenta Bancaria"
      Me.chbCuentaBancaria.UseVisualStyleBackColor = True
      '
      'rdbFechaMovimiento
      '
      Me.rdbFechaMovimiento.AutoSize = True
      Me.rdbFechaMovimiento.BindearPropiedadControl = Nothing
      Me.rdbFechaMovimiento.BindearPropiedadEntidad = Nothing
      Me.rdbFechaMovimiento.Checked = True
      Me.rdbFechaMovimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.rdbFechaMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.rdbFechaMovimiento.IsPK = False
      Me.rdbFechaMovimiento.IsRequired = False
      Me.rdbFechaMovimiento.Key = Nothing
      Me.rdbFechaMovimiento.LabelAsoc = Nothing
      Me.rdbFechaMovimiento.Location = New System.Drawing.Point(463, 19)
      Me.rdbFechaMovimiento.Name = "rdbFechaMovimiento"
      Me.rdbFechaMovimiento.Size = New System.Drawing.Size(79, 17)
      Me.rdbFechaMovimiento.TabIndex = 6
      Me.rdbFechaMovimiento.TabStop = True
      Me.rdbFechaMovimiento.Text = "Movimiento"
      Me.rdbFechaMovimiento.UseVisualStyleBackColor = True
      '
      'rdbFechaPlanilla
      '
      Me.rdbFechaPlanilla.AutoSize = True
      Me.rdbFechaPlanilla.BindearPropiedadControl = Nothing
      Me.rdbFechaPlanilla.BindearPropiedadEntidad = Nothing
      Me.rdbFechaPlanilla.ForeColorFocus = System.Drawing.Color.Red
      Me.rdbFechaPlanilla.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.rdbFechaPlanilla.IsPK = False
      Me.rdbFechaPlanilla.IsRequired = False
      Me.rdbFechaPlanilla.Key = Nothing
      Me.rdbFechaPlanilla.LabelAsoc = Nothing
      Me.rdbFechaPlanilla.Location = New System.Drawing.Point(546, 19)
      Me.rdbFechaPlanilla.Name = "rdbFechaPlanilla"
      Me.rdbFechaPlanilla.Size = New System.Drawing.Size(58, 17)
      Me.rdbFechaPlanilla.TabIndex = 7
      Me.rdbFechaPlanilla.Text = "Planilla"
      Me.rdbFechaPlanilla.UseVisualStyleBackColor = True
      '
      'lblFechaDe
      '
      Me.lblFechaDe.AutoSize = True
      Me.lblFechaDe.LabelAsoc = Nothing
      Me.lblFechaDe.Location = New System.Drawing.Point(403, 21)
      Me.lblFechaDe.Name = "lblFechaDe"
      Me.lblFechaDe.Size = New System.Drawing.Size(52, 13)
      Me.lblFechaDe.TabIndex = 5
      Me.lblFechaDe.Text = "Fecha de"
      '
      'chkMesCompleto
      '
      Me.chkMesCompleto.AutoSize = True
      Me.chkMesCompleto.BindearPropiedadControl = Nothing
      Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
      Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
      Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkMesCompleto.IsPK = False
      Me.chkMesCompleto.IsRequired = False
      Me.chkMesCompleto.Key = Nothing
      Me.chkMesCompleto.LabelAsoc = Nothing
      Me.chkMesCompleto.Location = New System.Drawing.Point(13, 21)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 0
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
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
      Me.dtpHasta.Location = New System.Drawing.Point(302, 18)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(261, 21)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
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
      Me.dtpDesde.Location = New System.Drawing.Point(154, 19)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(110, 22)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 533)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(965, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(886, 17)
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(965, 29)
      Me.tstBarra.TabIndex = 3
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
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
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
      Me.tsbSalir.ToolTipText = "Cerrar la Pantalla"
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ugDetalle.DataSource = Me.UltraDataSource1
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn15.CellAppearance = Appearance2
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn15.Header.Appearance = Appearance3
      UltraGridColumn15.Header.Caption = "Grupo Cuenta"
      UltraGridColumn15.Header.VisiblePosition = 0
      UltraGridColumn15.Width = 88
      Appearance4.TextHAlignAsString = "Left"
      UltraGridColumn6.CellAppearance = Appearance4
      Appearance5.TextHAlignAsString = "Left"
      UltraGridColumn6.Header.Appearance = Appearance5
      UltraGridColumn6.Header.Caption = "Nombre Cuenta"
      UltraGridColumn6.Header.VisiblePosition = 1
      UltraGridColumn6.Width = 234
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn27.CellAppearance = Appearance6
      Appearance7.TextHAlignAsString = "Center"
      UltraGridColumn27.Header.Appearance = Appearance7
      UltraGridColumn27.Header.Caption = "Ingresos Pesos"
      UltraGridColumn27.Header.VisiblePosition = 2
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn28.CellAppearance = Appearance8
      Appearance9.TextHAlignAsString = "Center"
      UltraGridColumn28.Header.Appearance = Appearance9
      UltraGridColumn28.Header.Caption = "Egresos Pesos"
      UltraGridColumn28.Header.VisiblePosition = 3
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance10
      Appearance11.TextHAlignAsString = "Center"
      UltraGridColumn1.Header.Appearance = Appearance11
      UltraGridColumn1.Header.Caption = "Totales Pesos"
      UltraGridColumn1.Header.VisiblePosition = 4
      Appearance12.TextHAlignAsString = "Right"
      UltraGridColumn30.CellAppearance = Appearance12
      Appearance13.TextHAlignAsString = "Center"
      UltraGridColumn30.Header.Appearance = Appearance13
      UltraGridColumn30.Header.Caption = "Ingresos Dolares"
      UltraGridColumn30.Header.VisiblePosition = 5
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn31.CellAppearance = Appearance14
      Appearance15.TextHAlignAsString = "Center"
      UltraGridColumn31.Header.Appearance = Appearance15
      UltraGridColumn31.Header.Caption = "Egresos Dolares"
      UltraGridColumn31.Header.VisiblePosition = 6
      Appearance16.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance16
      Appearance17.TextHAlignAsString = "Center"
      UltraGridColumn2.Header.Appearance = Appearance17
      UltraGridColumn2.Header.Caption = "Totales Dolar"
      UltraGridColumn2.Header.VisiblePosition = 7
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn15, UltraGridColumn6, UltraGridColumn27, UltraGridColumn28, UltraGridColumn1, UltraGridColumn30, UltraGridColumn31, UltraGridColumn2})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance18.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance18
      Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar"
      Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance20.BackColor2 = System.Drawing.SystemColors.Control
      Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance21.BackColor = System.Drawing.SystemColors.Window
      Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance21
      Appearance22.BackColor = System.Drawing.SystemColors.Highlight
      Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance22
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance23.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance23
      Appearance24.BorderColor = System.Drawing.Color.Silver
      Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance24
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance25.BackColor = System.Drawing.SystemColors.Control
      Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance25.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance25
      Appearance26.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance26
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance27.BackColor = System.Drawing.SystemColors.Window
      Appearance27.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance27
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(5, 112)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(954, 418)
      Me.ugDetalle.TabIndex = 4
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'UltraDataSource1
      '
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8})
      '
      'ResumenDeBancos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(965, 555)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.grbFiltros)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ResumenDeBancos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Resumen de Bancos"
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblHasta As Eniac.Controles.Label
    Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents chbCuentaBancaria As Eniac.Controles.CheckBox
   Friend WithEvents bscCuentaBancaria As Eniac.Controles.Buscador2
   Friend WithEvents rdbFechaMovimiento As Eniac.Controles.RadioButton
    Friend WithEvents rdbFechaPlanilla As Eniac.Controles.RadioButton
    Friend WithEvents lblFechaDe As Eniac.Controles.Label
    Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As ToolStripProgressBar
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Public WithEvents tstBarra As ToolStrip
    Public WithEvents tsbRefrescar As ToolStripButton
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbImprimir As ToolStripButton
    Private WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsddExportar As ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As ToolStripMenuItem
    Friend WithEvents tsmiAPDF As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Public WithEvents tsbSalir As ToolStripButton
    Friend WithEvents btnConsultar As Controles.Button
    Friend WithEvents ugDetalle As UltraGrid
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraDataSource1 As UltraWinDataSource.UltraDataSource
End Class
