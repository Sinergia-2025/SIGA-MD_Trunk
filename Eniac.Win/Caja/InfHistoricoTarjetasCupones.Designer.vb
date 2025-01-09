<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfHistoricoTarjetasCupones

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfHistoricoTarjetasCupones))
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTarjetaCupon")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTarjeta")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Monto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuotas")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroLote")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCupon")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoTarjeta")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoTarjetaAnt")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCajaIngreso")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroPlanillaIngreso")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroMovimientoIngreso")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCajaEgreso")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroPlanillaEgreso")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroMovimientoEgreso")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuarioActualizacion")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCajaIngreso")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCajaEgreso")
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
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbFechaEnCarteraAl = New Eniac.Controles.CheckBox()
      Me.dtpFechaEnCarteraAl = New Eniac.Controles.DateTimePicker()
      Me.chbFechaIngreso = New Eniac.Controles.CheckBox()
      Me.dtpIngresoHasta = New Eniac.Controles.DateTimePicker()
      Me.Label1 = New Eniac.Controles.Label()
      Me.dtpIngresoDesde = New Eniac.Controles.DateTimePicker()
      Me.Label2 = New Eniac.Controles.Label()
      Me.chbFechaLiquidacion = New Eniac.Controles.CheckBox()
      Me.dtpLiquidacionHasta = New Eniac.Controles.DateTimePicker()
      Me.lblFechaCobroHasta = New Eniac.Controles.Label()
      Me.dtpLiquidacionDesde = New Eniac.Controles.DateTimePicker()
      Me.lblFechaCobroDesde = New Eniac.Controles.Label()
      Me.chbEstado = New Eniac.Controles.CheckBox()
      Me.cmbEstado = New Eniac.Controles.ComboBox()
      Me.chbNumeroLote = New Eniac.Controles.CheckBox()
      Me.txtNumeroLote = New Eniac.Controles.TextBox()
      Me.chbCaja = New Eniac.Controles.CheckBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.chbNumeroCupon = New Eniac.Controles.CheckBox()
      Me.txtNumeroCupon = New Eniac.Controles.TextBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.cmbBanco = New Eniac.Controles.ComboBox()
      Me.chbBanco = New Eniac.Controles.CheckBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.grbOrdenar = New System.Windows.Forms.GroupBox()
      Me.rdbOrdenNombre = New System.Windows.Forms.RadioButton()
      Me.rdbOrdenFechaActualizacion = New System.Windows.Forms.RadioButton()
      Me.grbFiltros.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbOrdenar.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.grbOrdenar)
      Me.grbFiltros.Controls.Add(Me.chbFechaEnCarteraAl)
      Me.grbFiltros.Controls.Add(Me.dtpFechaEnCarteraAl)
      Me.grbFiltros.Controls.Add(Me.chbFechaIngreso)
      Me.grbFiltros.Controls.Add(Me.dtpIngresoHasta)
      Me.grbFiltros.Controls.Add(Me.dtpIngresoDesde)
      Me.grbFiltros.Controls.Add(Me.Label1)
      Me.grbFiltros.Controls.Add(Me.Label2)
      Me.grbFiltros.Controls.Add(Me.chbFechaLiquidacion)
      Me.grbFiltros.Controls.Add(Me.dtpLiquidacionHasta)
      Me.grbFiltros.Controls.Add(Me.dtpLiquidacionDesde)
      Me.grbFiltros.Controls.Add(Me.lblFechaCobroHasta)
      Me.grbFiltros.Controls.Add(Me.lblFechaCobroDesde)
      Me.grbFiltros.Controls.Add(Me.chbEstado)
      Me.grbFiltros.Controls.Add(Me.cmbEstado)
      Me.grbFiltros.Controls.Add(Me.chbNumeroLote)
      Me.grbFiltros.Controls.Add(Me.txtNumeroLote)
      Me.grbFiltros.Controls.Add(Me.chbCaja)
      Me.grbFiltros.Controls.Add(Me.cmbCajas)
      Me.grbFiltros.Controls.Add(Me.chkExpandAll)
      Me.grbFiltros.Controls.Add(Me.chbNumeroCupon)
      Me.grbFiltros.Controls.Add(Me.txtNumeroCupon)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.cmbBanco)
      Me.grbFiltros.Controls.Add(Me.chbBanco)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(909, 171)
      Me.grbFiltros.TabIndex = 1
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'chbFechaEnCarteraAl
      '
      Me.chbFechaEnCarteraAl.AutoSize = True
      Me.chbFechaEnCarteraAl.BindearPropiedadControl = Nothing
      Me.chbFechaEnCarteraAl.BindearPropiedadEntidad = Nothing
      Me.chbFechaEnCarteraAl.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaEnCarteraAl.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaEnCarteraAl.IsPK = False
      Me.chbFechaEnCarteraAl.IsRequired = False
      Me.chbFechaEnCarteraAl.Key = Nothing
      Me.chbFechaEnCarteraAl.LabelAsoc = Nothing
      Me.chbFechaEnCarteraAl.Location = New System.Drawing.Point(11, 90)
      Me.chbFechaEnCarteraAl.Name = "chbFechaEnCarteraAl"
      Me.chbFechaEnCarteraAl.Size = New System.Drawing.Size(88, 17)
      Me.chbFechaEnCarteraAl.TabIndex = 16
      Me.chbFechaEnCarteraAl.Text = "En Cartera Al"
      Me.chbFechaEnCarteraAl.UseVisualStyleBackColor = True
      '
      'dtpFechaEnCarteraAl
      '
      Me.dtpFechaEnCarteraAl.BindearPropiedadControl = Nothing
      Me.dtpFechaEnCarteraAl.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEnCarteraAl.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaEnCarteraAl.Enabled = False
      Me.dtpFechaEnCarteraAl.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEnCarteraAl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEnCarteraAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEnCarteraAl.IsPK = False
      Me.dtpFechaEnCarteraAl.IsRequired = False
      Me.dtpFechaEnCarteraAl.Key = ""
      Me.dtpFechaEnCarteraAl.LabelAsoc = Nothing
      Me.dtpFechaEnCarteraAl.Location = New System.Drawing.Point(118, 87)
      Me.dtpFechaEnCarteraAl.Name = "dtpFechaEnCarteraAl"
      Me.dtpFechaEnCarteraAl.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaEnCarteraAl.TabIndex = 17
      '
      'chbFechaIngreso
      '
      Me.chbFechaIngreso.AutoSize = True
      Me.chbFechaIngreso.BindearPropiedadControl = Nothing
      Me.chbFechaIngreso.BindearPropiedadEntidad = Nothing
      Me.chbFechaIngreso.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaIngreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaIngreso.IsPK = False
      Me.chbFechaIngreso.IsRequired = False
      Me.chbFechaIngreso.Key = Nothing
      Me.chbFechaIngreso.LabelAsoc = Nothing
      Me.chbFechaIngreso.Location = New System.Drawing.Point(11, 23)
      Me.chbFechaIngreso.Name = "chbFechaIngreso"
      Me.chbFechaIngreso.Size = New System.Drawing.Size(61, 17)
      Me.chbFechaIngreso.TabIndex = 0
      Me.chbFechaIngreso.Text = "Ingreso"
      Me.chbFechaIngreso.UseVisualStyleBackColor = True
      '
      'dtpIngresoHasta
      '
      Me.dtpIngresoHasta.BindearPropiedadControl = Nothing
      Me.dtpIngresoHasta.BindearPropiedadEntidad = Nothing
      Me.dtpIngresoHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpIngresoHasta.Enabled = False
      Me.dtpIngresoHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpIngresoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpIngresoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpIngresoHasta.IsPK = False
      Me.dtpIngresoHasta.IsRequired = False
      Me.dtpIngresoHasta.Key = ""
      Me.dtpIngresoHasta.LabelAsoc = Me.Label1
      Me.dtpIngresoHasta.Location = New System.Drawing.Point(263, 21)
      Me.dtpIngresoHasta.Name = "dtpIngresoHasta"
      Me.dtpIngresoHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpIngresoHasta.TabIndex = 4
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(223, 23)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(35, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Hasta"
      '
      'dtpIngresoDesde
      '
      Me.dtpIngresoDesde.BindearPropiedadControl = Nothing
      Me.dtpIngresoDesde.BindearPropiedadEntidad = Nothing
      Me.dtpIngresoDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpIngresoDesde.Enabled = False
      Me.dtpIngresoDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpIngresoDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpIngresoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpIngresoDesde.IsPK = False
      Me.dtpIngresoDesde.IsRequired = False
      Me.dtpIngresoDesde.Key = ""
      Me.dtpIngresoDesde.LabelAsoc = Me.Label2
      Me.dtpIngresoDesde.Location = New System.Drawing.Point(120, 21)
      Me.dtpIngresoDesde.Name = "dtpIngresoDesde"
      Me.dtpIngresoDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpIngresoDesde.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(82, 24)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 1
      Me.Label2.Text = "Desde"
      '
      'chbFechaLiquidacion
      '
      Me.chbFechaLiquidacion.AutoSize = True
      Me.chbFechaLiquidacion.BindearPropiedadControl = Nothing
      Me.chbFechaLiquidacion.BindearPropiedadEntidad = Nothing
      Me.chbFechaLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaLiquidacion.IsPK = False
      Me.chbFechaLiquidacion.IsRequired = False
      Me.chbFechaLiquidacion.Key = Nothing
      Me.chbFechaLiquidacion.LabelAsoc = Nothing
      Me.chbFechaLiquidacion.Location = New System.Drawing.Point(11, 56)
      Me.chbFechaLiquidacion.Name = "chbFechaLiquidacion"
      Me.chbFechaLiquidacion.Size = New System.Drawing.Size(72, 17)
      Me.chbFechaLiquidacion.TabIndex = 7
      Me.chbFechaLiquidacion.Text = "Liquidado"
      Me.chbFechaLiquidacion.UseVisualStyleBackColor = True
      '
      'dtpLiquidacionHasta
      '
      Me.dtpLiquidacionHasta.BindearPropiedadControl = Nothing
      Me.dtpLiquidacionHasta.BindearPropiedadEntidad = Nothing
      Me.dtpLiquidacionHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpLiquidacionHasta.Enabled = False
      Me.dtpLiquidacionHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpLiquidacionHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpLiquidacionHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpLiquidacionHasta.IsPK = False
      Me.dtpLiquidacionHasta.IsRequired = False
      Me.dtpLiquidacionHasta.Key = ""
      Me.dtpLiquidacionHasta.LabelAsoc = Me.lblFechaCobroHasta
      Me.dtpLiquidacionHasta.Location = New System.Drawing.Point(262, 54)
      Me.dtpLiquidacionHasta.Name = "dtpLiquidacionHasta"
      Me.dtpLiquidacionHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpLiquidacionHasta.TabIndex = 11
      '
      'lblFechaCobroHasta
      '
      Me.lblFechaCobroHasta.AutoSize = True
      Me.lblFechaCobroHasta.LabelAsoc = Nothing
      Me.lblFechaCobroHasta.Location = New System.Drawing.Point(223, 58)
      Me.lblFechaCobroHasta.Name = "lblFechaCobroHasta"
      Me.lblFechaCobroHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblFechaCobroHasta.TabIndex = 10
      Me.lblFechaCobroHasta.Text = "Hasta"
      '
      'dtpLiquidacionDesde
      '
      Me.dtpLiquidacionDesde.BindearPropiedadControl = Nothing
      Me.dtpLiquidacionDesde.BindearPropiedadEntidad = Nothing
      Me.dtpLiquidacionDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpLiquidacionDesde.Enabled = False
      Me.dtpLiquidacionDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpLiquidacionDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpLiquidacionDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpLiquidacionDesde.IsPK = False
      Me.dtpLiquidacionDesde.IsRequired = False
      Me.dtpLiquidacionDesde.Key = ""
      Me.dtpLiquidacionDesde.LabelAsoc = Me.lblFechaCobroDesde
      Me.dtpLiquidacionDesde.Location = New System.Drawing.Point(118, 54)
      Me.dtpLiquidacionDesde.Name = "dtpLiquidacionDesde"
      Me.dtpLiquidacionDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpLiquidacionDesde.TabIndex = 9
      '
      'lblFechaCobroDesde
      '
      Me.lblFechaCobroDesde.AutoSize = True
      Me.lblFechaCobroDesde.LabelAsoc = Nothing
      Me.lblFechaCobroDesde.Location = New System.Drawing.Point(82, 58)
      Me.lblFechaCobroDesde.Name = "lblFechaCobroDesde"
      Me.lblFechaCobroDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblFechaCobroDesde.TabIndex = 8
      Me.lblFechaCobroDesde.Text = "Desde"
      '
      'chbEstado
      '
      Me.chbEstado.AutoSize = True
      Me.chbEstado.BindearPropiedadControl = Nothing
      Me.chbEstado.BindearPropiedadEntidad = Nothing
      Me.chbEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEstado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEstado.IsPK = False
      Me.chbEstado.IsRequired = False
      Me.chbEstado.Key = Nothing
      Me.chbEstado.LabelAsoc = Nothing
      Me.chbEstado.Location = New System.Drawing.Point(370, 23)
      Me.chbEstado.Name = "chbEstado"
      Me.chbEstado.Size = New System.Drawing.Size(59, 17)
      Me.chbEstado.TabIndex = 5
      Me.chbEstado.Text = "Estado"
      Me.chbEstado.UseVisualStyleBackColor = True
      '
      'cmbEstado
      '
      Me.cmbEstado.BindearPropiedadControl = Nothing
      Me.cmbEstado.BindearPropiedadEntidad = Nothing
      Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstado.Enabled = False
      Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstado.FormattingEnabled = True
      Me.cmbEstado.IsPK = False
      Me.cmbEstado.IsRequired = False
      Me.cmbEstado.Key = Nothing
      Me.cmbEstado.LabelAsoc = Nothing
      Me.cmbEstado.Location = New System.Drawing.Point(433, 21)
      Me.cmbEstado.Name = "cmbEstado"
      Me.cmbEstado.Size = New System.Drawing.Size(125, 21)
      Me.cmbEstado.TabIndex = 6
      '
      'chbNumeroLote
      '
      Me.chbNumeroLote.AutoSize = True
      Me.chbNumeroLote.BindearPropiedadControl = Nothing
      Me.chbNumeroLote.BindearPropiedadEntidad = Nothing
      Me.chbNumeroLote.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumeroLote.IsPK = False
      Me.chbNumeroLote.IsRequired = False
      Me.chbNumeroLote.Key = Nothing
      Me.chbNumeroLote.LabelAsoc = Nothing
      Me.chbNumeroLote.Location = New System.Drawing.Point(521, 56)
      Me.chbNumeroLote.Name = "chbNumeroLote"
      Me.chbNumeroLote.Size = New System.Drawing.Size(47, 17)
      Me.chbNumeroLote.TabIndex = 14
      Me.chbNumeroLote.Text = "Lote"
      Me.chbNumeroLote.UseVisualStyleBackColor = True
      '
      'txtNumeroLote
      '
      Me.txtNumeroLote.BindearPropiedadControl = Nothing
      Me.txtNumeroLote.BindearPropiedadEntidad = Nothing
      Me.txtNumeroLote.Enabled = False
      Me.txtNumeroLote.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroLote.Formato = "##0"
      Me.txtNumeroLote.IsDecimal = False
      Me.txtNumeroLote.IsNumber = True
      Me.txtNumeroLote.IsPK = False
      Me.txtNumeroLote.IsRequired = False
      Me.txtNumeroLote.Key = ""
      Me.txtNumeroLote.LabelAsoc = Nothing
      Me.txtNumeroLote.Location = New System.Drawing.Point(570, 54)
      Me.txtNumeroLote.MaxLength = 8
      Me.txtNumeroLote.Name = "txtNumeroLote"
      Me.txtNumeroLote.Size = New System.Drawing.Size(69, 20)
      Me.txtNumeroLote.TabIndex = 15
      Me.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbCaja
      '
      Me.chbCaja.AutoSize = True
      Me.chbCaja.BindearPropiedadControl = Nothing
      Me.chbCaja.BindearPropiedadEntidad = Nothing
      Me.chbCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCaja.IsPK = False
      Me.chbCaja.IsRequired = False
      Me.chbCaja.Key = Nothing
      Me.chbCaja.LabelAsoc = Nothing
      Me.chbCaja.Location = New System.Drawing.Point(226, 90)
      Me.chbCaja.Name = "chbCaja"
      Me.chbCaja.Size = New System.Drawing.Size(47, 17)
      Me.chbCaja.TabIndex = 18
      Me.chbCaja.Text = "Caja"
      Me.chbCaja.UseVisualStyleBackColor = True
      '
      'cmbCajas
      '
      Me.cmbCajas.BindearPropiedadControl = ""
      Me.cmbCajas.BindearPropiedadEntidad = ""
      Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCajas.Enabled = False
      Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCajas.FormattingEnabled = True
      Me.cmbCajas.IsPK = False
      Me.cmbCajas.IsRequired = False
      Me.cmbCajas.Key = Nothing
      Me.cmbCajas.LabelAsoc = Nothing
      Me.cmbCajas.Location = New System.Drawing.Point(278, 88)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(130, 21)
      Me.cmbCajas.TabIndex = 19
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(759, 93)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
      Me.chkExpandAll.TabIndex = 28
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'chbNumeroCupon
      '
      Me.chbNumeroCupon.AutoSize = True
      Me.chbNumeroCupon.BindearPropiedadControl = Nothing
      Me.chbNumeroCupon.BindearPropiedadEntidad = Nothing
      Me.chbNumeroCupon.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumeroCupon.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumeroCupon.IsPK = False
      Me.chbNumeroCupon.IsRequired = False
      Me.chbNumeroCupon.Key = Nothing
      Me.chbNumeroCupon.LabelAsoc = Nothing
      Me.chbNumeroCupon.Location = New System.Drawing.Point(370, 56)
      Me.chbNumeroCupon.Name = "chbNumeroCupon"
      Me.chbNumeroCupon.Size = New System.Drawing.Size(57, 17)
      Me.chbNumeroCupon.TabIndex = 12
      Me.chbNumeroCupon.Text = "Cupón"
      Me.chbNumeroCupon.UseVisualStyleBackColor = True
      '
      'txtNumeroCupon
      '
      Me.txtNumeroCupon.BindearPropiedadControl = Nothing
      Me.txtNumeroCupon.BindearPropiedadEntidad = Nothing
      Me.txtNumeroCupon.Enabled = False
      Me.txtNumeroCupon.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroCupon.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroCupon.Formato = "##0"
      Me.txtNumeroCupon.IsDecimal = False
      Me.txtNumeroCupon.IsNumber = True
      Me.txtNumeroCupon.IsPK = False
      Me.txtNumeroCupon.IsRequired = False
      Me.txtNumeroCupon.Key = ""
      Me.txtNumeroCupon.LabelAsoc = Nothing
      Me.txtNumeroCupon.Location = New System.Drawing.Point(429, 54)
      Me.txtNumeroCupon.MaxLength = 8
      Me.txtNumeroCupon.Name = "txtNumeroCupon"
      Me.txtNumeroCupon.Size = New System.Drawing.Size(69, 20)
      Me.txtNumeroCupon.TabIndex = 13
      Me.txtNumeroCupon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(75, 133)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 24
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(72, 119)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 23
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ConfigBuscador = Nothing
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
      Me.bscCliente.Location = New System.Drawing.Point(172, 133)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 26
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(169, 119)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 25
      Me.lblNombre.Text = "Nombre"
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
      Me.chbCliente.Location = New System.Drawing.Point(11, 136)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 22
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(759, 42)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 27
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'cmbBanco
      '
      Me.cmbBanco.BindearPropiedadControl = ""
      Me.cmbBanco.BindearPropiedadEntidad = ""
      Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbBanco.Enabled = False
      Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbBanco.FormattingEnabled = True
      Me.cmbBanco.IsPK = True
      Me.cmbBanco.IsRequired = True
      Me.cmbBanco.Key = Nothing
      Me.cmbBanco.LabelAsoc = Nothing
      Me.cmbBanco.Location = New System.Drawing.Point(479, 89)
      Me.cmbBanco.Name = "cmbBanco"
      Me.cmbBanco.Size = New System.Drawing.Size(160, 21)
      Me.cmbBanco.TabIndex = 21
      '
      'chbBanco
      '
      Me.chbBanco.AutoSize = True
      Me.chbBanco.BindearPropiedadControl = Nothing
      Me.chbBanco.BindearPropiedadEntidad = Nothing
      Me.chbBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.chbBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbBanco.IsPK = False
      Me.chbBanco.IsRequired = False
      Me.chbBanco.Key = Nothing
      Me.chbBanco.LabelAsoc = Nothing
      Me.chbBanco.Location = New System.Drawing.Point(419, 91)
      Me.chbBanco.Name = "chbBanco"
      Me.chbBanco.Size = New System.Drawing.Size(57, 17)
      Me.chbBanco.TabIndex = 20
      Me.chbBanco.Text = "Banco"
      Me.chbBanco.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(934, 29)
      Me.tstBarra.TabIndex = 0
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
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 444)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(934, 22)
      Me.stsStado.TabIndex = 3
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
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance17
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
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn8.Header.VisiblePosition = 0
      UltraGridColumn8.Hidden = True
      UltraGridColumn9.Header.VisiblePosition = 1
      UltraGridColumn9.Hidden = True
      UltraGridColumn10.Header.VisiblePosition = 4
      UltraGridColumn10.Hidden = True
      UltraGridColumn12.Header.VisiblePosition = 9
      UltraGridColumn12.Hidden = True
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn16.CellAppearance = Appearance2
      UltraGridColumn16.Format = "N2"
      UltraGridColumn16.Header.VisiblePosition = 7
      UltraGridColumn16.Width = 74
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn14.CellAppearance = Appearance3
      UltraGridColumn14.Header.VisiblePosition = 5
      UltraGridColumn14.Width = 47
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn22.CellAppearance = Appearance4
      UltraGridColumn22.Header.Caption = "Nro. Lote"
      UltraGridColumn22.Header.VisiblePosition = 2
      UltraGridColumn22.Width = 62
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn15.CellAppearance = Appearance5
      UltraGridColumn15.Header.Caption = "Nro. Cupon"
      UltraGridColumn15.Header.VisiblePosition = 6
      UltraGridColumn15.Width = 70
      UltraGridColumn23.Format = "dd/MM/yyyy"
      UltraGridColumn23.Header.Caption = "Emision"
      UltraGridColumn23.Header.VisiblePosition = 8
      UltraGridColumn23.Width = 65
      UltraGridColumn24.Header.Caption = "Estado Tarjeta"
      UltraGridColumn24.Header.VisiblePosition = 11
      UltraGridColumn24.Width = 89
      UltraGridColumn25.Header.VisiblePosition = 10
      UltraGridColumn25.Hidden = True
      UltraGridColumn26.Header.VisiblePosition = 13
      UltraGridColumn26.Hidden = True
      UltraGridColumn27.Header.Caption = "Nro Planilla Ingreso"
      UltraGridColumn27.Header.VisiblePosition = 15
      UltraGridColumn27.Width = 85
      UltraGridColumn28.Header.Caption = "Nro Movimiento Ingreso"
      UltraGridColumn28.Header.VisiblePosition = 16
      UltraGridColumn28.Width = 80
      UltraGridColumn29.Header.VisiblePosition = 17
      UltraGridColumn29.Hidden = True
      UltraGridColumn30.Header.Caption = "Nro Planilla Egreso"
      UltraGridColumn30.Header.VisiblePosition = 19
      UltraGridColumn30.Width = 89
      UltraGridColumn31.Header.Caption = "Nro Movimiento Egreso"
      UltraGridColumn31.Header.VisiblePosition = 20
      UltraGridColumn31.Width = 85
      UltraGridColumn32.Header.VisiblePosition = 21
      UltraGridColumn32.Hidden = True
      UltraGridColumn33.Header.VisiblePosition = 22
      UltraGridColumn33.Hidden = True
      UltraGridColumn34.Header.VisiblePosition = 23
      UltraGridColumn34.Hidden = True
      UltraGridColumn35.Header.VisiblePosition = 24
      UltraGridColumn35.Hidden = True
      UltraGridColumn1.Header.Caption = "Banco"
      UltraGridColumn1.Header.VisiblePosition = 3
      UltraGridColumn1.Width = 126
      UltraGridColumn2.Header.Caption = "Cliente"
      UltraGridColumn2.Header.VisiblePosition = 12
      UltraGridColumn2.Width = 200
      UltraGridColumn3.Header.Caption = "Caja Ingreso"
      UltraGridColumn3.Header.VisiblePosition = 14
      UltraGridColumn4.Header.Caption = "Caja Egreso"
      UltraGridColumn4.Header.VisiblePosition = 18
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn12, UltraGridColumn16, UltraGridColumn14, UltraGridColumn22, UltraGridColumn15, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance6.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance6
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre las columnas aquí para agrupar."
      Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance8.BackColor2 = System.Drawing.SystemColors.Control
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance9
      Appearance10.BackColor = System.Drawing.SystemColors.Highlight
      Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance11
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance13.BackColor = System.Drawing.SystemColors.Control
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 215)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(909, 226)
      Me.ugDetalle.TabIndex = 2
      '
      'grbOrdenar
      '
      Me.grbOrdenar.Controls.Add(Me.rdbOrdenNombre)
      Me.grbOrdenar.Controls.Add(Me.rdbOrdenFechaActualizacion)
      Me.grbOrdenar.Location = New System.Drawing.Point(503, 119)
      Me.grbOrdenar.Name = "grbOrdenar"
      Me.grbOrdenar.Size = New System.Drawing.Size(280, 42)
      Me.grbOrdenar.TabIndex = 29
      Me.grbOrdenar.TabStop = False
      Me.grbOrdenar.Text = "Ordenar por:"
      '
      'rdbOrdenNombre
      '
      Me.rdbOrdenNombre.AutoSize = True
      Me.rdbOrdenNombre.Location = New System.Drawing.Point(132, 17)
      Me.rdbOrdenNombre.Name = "rdbOrdenNombre"
      Me.rdbOrdenNombre.Size = New System.Drawing.Size(135, 17)
      Me.rdbOrdenNombre.TabIndex = 41
      Me.rdbOrdenNombre.Text = "N. Cliente + Fecha Act."
      Me.rdbOrdenNombre.UseVisualStyleBackColor = True
      '
      'rdbOrdenFechaActualizacion
      '
      Me.rdbOrdenFechaActualizacion.AutoSize = True
      Me.rdbOrdenFechaActualizacion.Checked = True
      Me.rdbOrdenFechaActualizacion.Location = New System.Drawing.Point(9, 18)
      Me.rdbOrdenFechaActualizacion.Name = "rdbOrdenFechaActualizacion"
      Me.rdbOrdenFechaActualizacion.Size = New System.Drawing.Size(121, 17)
      Me.rdbOrdenFechaActualizacion.TabIndex = 40
      Me.rdbOrdenFechaActualizacion.TabStop = True
      Me.rdbOrdenFechaActualizacion.Text = "Fecha Actualización"
      Me.rdbOrdenFechaActualizacion.UseVisualStyleBackColor = True
      '
      'InfHistoricoTarjetasCupones
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(934, 466)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "InfHistoricoTarjetasCupones"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe Historico de Cupones de Tarjetas"
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbOrdenar.ResumeLayout(False)
      Me.grbOrdenar.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbBanco As Eniac.Controles.CheckBox
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents txtNumeroCupon As Eniac.Controles.TextBox
   Friend WithEvents chbNumeroCupon As Eniac.Controles.CheckBox
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbNumeroLote As Eniac.Controles.CheckBox
   Friend WithEvents txtNumeroLote As Eniac.Controles.TextBox
   Friend WithEvents chbEstado As Eniac.Controles.CheckBox
   Friend WithEvents cmbEstado As Eniac.Controles.ComboBox
   Friend WithEvents chbFechaIngreso As Eniac.Controles.CheckBox
   Friend WithEvents dtpIngresoHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dtpIngresoDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents chbFechaLiquidacion As Eniac.Controles.CheckBox
   Friend WithEvents dtpLiquidacionHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCobroHasta As Eniac.Controles.Label
   Friend WithEvents dtpLiquidacionDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCobroDesde As Eniac.Controles.Label
   Friend WithEvents chbFechaEnCarteraAl As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaEnCarteraAl As Eniac.Controles.DateTimePicker
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents grbOrdenar As System.Windows.Forms.GroupBox
   Friend WithEvents rdbOrdenNombre As System.Windows.Forms.RadioButton
   Friend WithEvents rdbOrdenFechaActualizacion As System.Windows.Forms.RadioButton
End Class
