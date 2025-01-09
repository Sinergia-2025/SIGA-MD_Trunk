<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosLibroDeSueldosyJornales
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosLibroDeSueldosyJornales))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Legajo")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePersonal")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EmpresaNombre")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EmpresaCUIT")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EmpresaDomicilio")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPago")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodoLiquidacion")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaIngreso")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CUIL")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SueldoBasico")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalHaberes")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalDescuentos")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAportesPatronales")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNeto")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe_En_Letras")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Lugar_de_Pago")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalHaberesSinDescuento")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BancoDePago")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BancoClaseCta")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCta")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CBU")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CategoriaNombre")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreNacionalidad")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaNacimiento")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DataSetSueldos_ReciboSueldoDetalle")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("DataSetSueldos_ReciboSueldoDetalle", 0)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idLegajo")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idConcepto")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoConcepto")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreConcepto")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Valor")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteHaberes")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDescuentos")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAportesPatronales")
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
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtNroLegajo = New System.Windows.Forms.RadioButton()
        Me.rbtNombre = New System.Windows.Forms.RadioButton()
        Me.cmbTipoRecibo = New Eniac.Controles.ComboBox()
        Me.chbTipoDeRecibo = New System.Windows.Forms.CheckBox()
        Me.cmbNroLiquidacion = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbLegajo = New Eniac.Controles.CheckBox()
        Me.cmbPeriodoLiquidacion = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.bscNroLegajo = New Eniac.Controles.Buscador()
        Me.lblNroDocumento = New Eniac.Controles.Label()
        Me.bscNombrePersonal = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.lbPeriodo = New Eniac.Controles.Label()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DataSetSueldos = New Eniac.Win.DataSetSueldos()
        Me.RecibosImpresosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecibosImpresosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.GroupBox1)
        Me.grbFiltros.Controls.Add(Me.cmbTipoRecibo)
        Me.grbFiltros.Controls.Add(Me.chbTipoDeRecibo)
        Me.grbFiltros.Controls.Add(Me.cmbNroLiquidacion)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.chbLegajo)
        Me.grbFiltros.Controls.Add(Me.cmbPeriodoLiquidacion)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.bscNroLegajo)
        Me.grbFiltros.Controls.Add(Me.bscNombrePersonal)
        Me.grbFiltros.Controls.Add(Me.lblNroDocumento)
        Me.grbFiltros.Controls.Add(Me.lbPeriodo)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(862, 100)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtNroLegajo)
        Me.GroupBox1.Controls.Add(Me.rbtNombre)
        Me.GroupBox1.Location = New System.Drawing.Point(589, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(115, 65)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ordenar por:"
        '
        'rbtNroLegajo
        '
        Me.rbtNroLegajo.AutoSize = True
        Me.rbtNroLegajo.Checked = True
        Me.rbtNroLegajo.Location = New System.Drawing.Point(18, 17)
        Me.rbtNroLegajo.Name = "rbtNroLegajo"
        Me.rbtNroLegajo.Size = New System.Drawing.Size(80, 17)
        Me.rbtNroLegajo.TabIndex = 15
        Me.rbtNroLegajo.TabStop = True
        Me.rbtNroLegajo.Text = "Nro. Legajo"
        Me.rbtNroLegajo.UseVisualStyleBackColor = True
        '
        'rbtNombre
        '
        Me.rbtNombre.AutoSize = True
        Me.rbtNombre.Location = New System.Drawing.Point(18, 40)
        Me.rbtNombre.Name = "rbtNombre"
        Me.rbtNombre.Size = New System.Drawing.Size(62, 17)
        Me.rbtNombre.TabIndex = 14
        Me.rbtNombre.Text = "Nombre"
        Me.rbtNombre.UseVisualStyleBackColor = True
        '
        'cmbTipoRecibo
        '
        Me.cmbTipoRecibo.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoRecibo.BindearPropiedadEntidad = "IdTipoConcepto"
        Me.cmbTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRecibo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoRecibo.FormattingEnabled = True
        Me.cmbTipoRecibo.IsPK = False
        Me.cmbTipoRecibo.IsRequired = True
        Me.cmbTipoRecibo.Key = Nothing
        Me.cmbTipoRecibo.LabelAsoc = Nothing
        Me.cmbTipoRecibo.Location = New System.Drawing.Point(313, 21)
        Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
        Me.cmbTipoRecibo.Size = New System.Drawing.Size(126, 21)
        Me.cmbTipoRecibo.TabIndex = 3
        '
        'chbTipoDeRecibo
        '
        Me.chbTipoDeRecibo.Location = New System.Drawing.Point(216, 26)
        Me.chbTipoDeRecibo.Name = "chbTipoDeRecibo"
        Me.chbTipoDeRecibo.Size = New System.Drawing.Size(102, 16)
        Me.chbTipoDeRecibo.TabIndex = 13
        Me.chbTipoDeRecibo.Text = "Tipo de Recibo"
        '
        'cmbNroLiquidacion
        '
        Me.cmbNroLiquidacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbNroLiquidacion.BindearPropiedadEntidad = "IdTipoConcepto"
        Me.cmbNroLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNroLiquidacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbNroLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbNroLiquidacion.FormattingEnabled = True
        Me.cmbNroLiquidacion.IsPK = False
        Me.cmbNroLiquidacion.IsRequired = True
        Me.cmbNroLiquidacion.Key = Nothing
        Me.cmbNroLiquidacion.LabelAsoc = Nothing
        Me.cmbNroLiquidacion.Location = New System.Drawing.Point(529, 22)
        Me.cmbNroLiquidacion.Name = "cmbNroLiquidacion"
        Me.cmbNroLiquidacion.Size = New System.Drawing.Size(43, 21)
        Me.cmbNroLiquidacion.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(445, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Nro Liquidación"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(748, 78)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(102, 16)
        Me.chkExpandAll.TabIndex = 10
        Me.chkExpandAll.Text = "Expandir Filas"
        '
        'chbLegajo
        '
        Me.chbLegajo.AutoSize = True
        Me.chbLegajo.BindearPropiedadControl = Nothing
        Me.chbLegajo.BindearPropiedadEntidad = Nothing
        Me.chbLegajo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLegajo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLegajo.IsPK = False
        Me.chbLegajo.IsRequired = False
        Me.chbLegajo.Key = Nothing
        Me.chbLegajo.LabelAsoc = Nothing
        Me.chbLegajo.Location = New System.Drawing.Point(14, 64)
        Me.chbLegajo.Name = "chbLegajo"
        Me.chbLegajo.Size = New System.Drawing.Size(58, 17)
        Me.chbLegajo.TabIndex = 4
        Me.chbLegajo.Text = "Legajo"
        Me.chbLegajo.UseVisualStyleBackColor = True
        '
        'cmbPeriodoLiquidacion
        '
        Me.cmbPeriodoLiquidacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbPeriodoLiquidacion.BindearPropiedadEntidad = "IdTipoConcepto"
        Me.cmbPeriodoLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoLiquidacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPeriodoLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPeriodoLiquidacion.FormattingEnabled = True
        Me.cmbPeriodoLiquidacion.IsPK = False
        Me.cmbPeriodoLiquidacion.IsRequired = True
        Me.cmbPeriodoLiquidacion.Key = Nothing
        Me.cmbPeriodoLiquidacion.LabelAsoc = Nothing
        Me.cmbPeriodoLiquidacion.Location = New System.Drawing.Point(115, 21)
        Me.cmbPeriodoLiquidacion.Name = "cmbPeriodoLiquidacion"
        Me.cmbPeriodoLiquidacion.Size = New System.Drawing.Size(90, 21)
        Me.cmbPeriodoLiquidacion.TabIndex = 1
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(748, 23)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(105, 49)
        Me.btnConsultar.TabIndex = 9
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'bscNroLegajo
        '
        Me.bscNroLegajo.AyudaAncho = 608
        Me.bscNroLegajo.BindearPropiedadControl = Nothing
        Me.bscNroLegajo.BindearPropiedadEntidad = Nothing
        Me.bscNroLegajo.ColumnasAlineacion = Nothing
        Me.bscNroLegajo.ColumnasAncho = Nothing
        Me.bscNroLegajo.ColumnasFormato = Nothing
        Me.bscNroLegajo.ColumnasOcultas = Nothing
        Me.bscNroLegajo.ColumnasTitulos = Nothing
        Me.bscNroLegajo.Datos = Nothing
        Me.bscNroLegajo.Enabled = False
        Me.bscNroLegajo.FilaDevuelta = Nothing
        Me.bscNroLegajo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNroLegajo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNroLegajo.IsDecimal = False
        Me.bscNroLegajo.IsNumber = True
        Me.bscNroLegajo.IsPK = False
        Me.bscNroLegajo.IsRequired = False
        Me.bscNroLegajo.Key = ""
        Me.bscNroLegajo.LabelAsoc = Me.lblNroDocumento
        Me.bscNroLegajo.Location = New System.Drawing.Point(80, 64)
        Me.bscNroLegajo.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNroLegajo.MaxLengh = "32767"
        Me.bscNroLegajo.Name = "bscNroLegajo"
        Me.bscNroLegajo.Permitido = True
        Me.bscNroLegajo.Selecciono = False
        Me.bscNroLegajo.Size = New System.Drawing.Size(131, 23)
        Me.bscNroLegajo.TabIndex = 5
        Me.bscNroLegajo.Titulo = Nothing
        '
        'lblNroDocumento
        '
        Me.lblNroDocumento.AutoSize = True
        Me.lblNroDocumento.LabelAsoc = Nothing
        Me.lblNroDocumento.Location = New System.Drawing.Point(77, 48)
        Me.lblNroDocumento.Name = "lblNroDocumento"
        Me.lblNroDocumento.Size = New System.Drawing.Size(44, 13)
        Me.lblNroDocumento.TabIndex = 6
        Me.lblNroDocumento.Text = "Numero"
        '
        'bscNombrePersonal
        '
        Me.bscNombrePersonal.AutoSize = True
        Me.bscNombrePersonal.AyudaAncho = 608
        Me.bscNombrePersonal.BindearPropiedadControl = Nothing
        Me.bscNombrePersonal.BindearPropiedadEntidad = Nothing
        Me.bscNombrePersonal.ColumnasAlineacion = Nothing
        Me.bscNombrePersonal.ColumnasAncho = Nothing
        Me.bscNombrePersonal.ColumnasFormato = Nothing
        Me.bscNombrePersonal.ColumnasOcultas = Nothing
        Me.bscNombrePersonal.ColumnasTitulos = Nothing
        Me.bscNombrePersonal.Datos = Nothing
        Me.bscNombrePersonal.Enabled = False
        Me.bscNombrePersonal.FilaDevuelta = Nothing
        Me.bscNombrePersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombrePersonal.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombrePersonal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombrePersonal.IsDecimal = False
        Me.bscNombrePersonal.IsNumber = False
        Me.bscNombrePersonal.IsPK = False
        Me.bscNombrePersonal.IsRequired = False
        Me.bscNombrePersonal.Key = ""
        Me.bscNombrePersonal.LabelAsoc = Me.lblNombre
        Me.bscNombrePersonal.Location = New System.Drawing.Point(220, 64)
        Me.bscNombrePersonal.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombrePersonal.MaxLengh = "32767"
        Me.bscNombrePersonal.Name = "bscNombrePersonal"
        Me.bscNombrePersonal.Permitido = True
        Me.bscNombrePersonal.Selecciono = False
        Me.bscNombrePersonal.Size = New System.Drawing.Size(307, 27)
        Me.bscNombrePersonal.TabIndex = 7
        Me.bscNombrePersonal.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(220, 48)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 8
        Me.lblNombre.Text = "Nombre"
        '
        'lbPeriodo
        '
        Me.lbPeriodo.AutoSize = True
        Me.lbPeriodo.LabelAsoc = Nothing
        Me.lbPeriodo.Location = New System.Drawing.Point(12, 25)
        Me.lbPeriodo.Name = "lbPeriodo"
        Me.lbPeriodo.Size = New System.Drawing.Size(100, 13)
        Me.lbPeriodo.TabIndex = 0
        Me.lbPeriodo.Text = "Periodo Liquidación"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(886, 29)
        Me.tstBarra.TabIndex = 3
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Enabled = False
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(886, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(807, 17)
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
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.Color.White
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 80
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.Header.Caption = "Nombre Personal"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 250
        UltraGridColumn3.Header.VisiblePosition = 7
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.Header.VisiblePosition = 8
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.VisiblePosition = 9
        UltraGridColumn5.Hidden = True
        UltraGridColumn6.Header.VisiblePosition = 10
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.VisiblePosition = 11
        UltraGridColumn7.Hidden = True
        UltraGridColumn9.Header.VisiblePosition = 12
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn10.Header.Caption = "Fecha Ingreso"
        UltraGridColumn10.Header.VisiblePosition = 5
        UltraGridColumn10.Width = 119
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn11.Header.VisiblePosition = 2
        UltraGridColumn11.Width = 150
        UltraGridColumn12.Header.VisiblePosition = 13
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.VisiblePosition = 14
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.VisiblePosition = 15
        UltraGridColumn14.Hidden = True
        UltraGridColumn32.Header.VisiblePosition = 16
        UltraGridColumn32.Hidden = True
        UltraGridColumn15.Header.VisiblePosition = 17
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.Header.VisiblePosition = 18
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.Header.VisiblePosition = 19
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn18.Header.VisiblePosition = 20
        UltraGridColumn18.Hidden = True
        UltraGridColumn19.Header.VisiblePosition = 21
        UltraGridColumn19.Hidden = True
        UltraGridColumn20.Header.VisiblePosition = 22
        UltraGridColumn20.Hidden = True
        UltraGridColumn21.Header.VisiblePosition = 23
        UltraGridColumn21.Hidden = True
        UltraGridColumn22.Header.VisiblePosition = 24
        UltraGridColumn22.Hidden = True
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn35.Header.Caption = "Categoria Laboral"
        UltraGridColumn35.Header.VisiblePosition = 6
        UltraGridColumn35.Width = 150
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.Header.Caption = "Nacionalidad"
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance3
        UltraGridColumn33.Header.Caption = "Fecha Nacimiento"
        UltraGridColumn33.Header.VisiblePosition = 4
        UltraGridColumn23.Header.VisiblePosition = 25
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn32, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn35, UltraGridColumn8, UltraGridColumn33, UltraGridColumn23})
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance4.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Appearance4.BorderColor = System.Drawing.Color.White
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.FontData.SizeInPoints = 8.0!
        UltraGridBand1.Override.HeaderAppearance = Appearance4
        UltraGridBand1.Override.HeaderPlacement = Infragistics.Win.UltraWinGrid.HeaderPlacement.FixedOnTop
        Appearance5.BorderColor = System.Drawing.Color.White
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.SizeInPoints = 8.0!
        UltraGridBand1.Override.RowAppearance = Appearance5
        UltraGridColumn24.Header.VisiblePosition = 0
        UltraGridColumn24.Hidden = True
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn25.Header.Caption = "IdConcepto"
        UltraGridColumn25.Header.VisiblePosition = 1
        UltraGridColumn25.Hidden = True
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance6
        UltraGridColumn30.Header.Caption = "Codigo"
        UltraGridColumn30.Header.VisiblePosition = 2
        UltraGridColumn30.Width = 61
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn26.Header.Caption = "Nombre Concepto"
        UltraGridColumn26.Header.VisiblePosition = 3
        UltraGridColumn26.Width = 250
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance7
        UltraGridColumn27.Header.VisiblePosition = 4
        UltraGridColumn27.Width = 150
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance8
        UltraGridColumn28.Header.Caption = "Haberes"
        UltraGridColumn28.Header.VisiblePosition = 5
        UltraGridColumn28.Width = 102
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance9
        UltraGridColumn29.Header.Caption = "Deducciones"
        UltraGridColumn29.Header.VisiblePosition = 6
        UltraGridColumn29.Width = 105
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance10
        UltraGridColumn31.Header.Caption = "Ap. Patronales"
        UltraGridColumn31.Header.VisiblePosition = 7
        UltraGridColumn31.Width = 119
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn24, UltraGridColumn25, UltraGridColumn30, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn31})
        UltraGridBand2.GroupHeaderLines = 3
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance11.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Appearance11.BorderColor = System.Drawing.Color.White
        Appearance11.FontData.BoldAsString = "False"
        Appearance11.FontData.SizeInPoints = 8.0!
        UltraGridBand2.Override.HeaderAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.White
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.SizeInPoints = 8.0!
        UltraGridBand2.Override.RowAppearance = Appearance12
        Appearance13.BorderColor = System.Drawing.Color.White
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.FontData.SizeInPoints = 8.0!
        UltraGridBand2.Override.SummaryFooterAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 3
        Appearance15.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance16.BorderColor = System.Drawing.Color.LightGray
        Appearance16.TextVAlignAsString = "Middle"
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance16
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance17.BorderColor = System.Drawing.Color.Black
        Appearance17.ForeColor = System.Drawing.Color.Black
        Me.ugDetalle.DisplayLayout.Override.SelectedRowAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance18.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugDetalle.DisplayLayout.Override.SummaryFooterAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.Color.White
        Appearance19.FontData.BoldAsString = "True"
        Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(12, 142)
        Me.ugDetalle.Margin = New System.Windows.Forms.Padding(1)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(862, 396)
        Me.ugDetalle.TabIndex = 1
        '
        'DataSetSueldos
        '
        Me.DataSetSueldos.DataSetName = "DataSetSueldos"
        Me.DataSetSueldos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RecibosImpresosBindingSource
        '
        Me.RecibosImpresosBindingSource.DataMember = "RecibosImpresos"
        Me.RecibosImpresosBindingSource.DataSource = Me.DataSetSueldos
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.FitWidthToPages = 1
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Page.Margins.Bottom = 1
        Me.UltraGridPrintDocument1.Page.Margins.Left = 1
        Me.UltraGridPrintDocument1.Page.Margins.Right = 1
        Me.UltraGridPrintDocument1.Page.Margins.Top = 1
        Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 1
        Me.UltraGridPrintDocument1.PageBody.Margins.Left = 1
        Me.UltraGridPrintDocument1.PageBody.Margins.Right = 1
        Me.UltraGridPrintDocument1.PageBody.Margins.Top = 1
        Me.UltraGridPrintDocument1.PrintColorStyle = Infragistics.Win.ColorRenderMode.GrayScale
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        Me.UltraPrintPreviewDialog1.PreviewSettings.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        '
        'SueldosLibroDeSueldosyJornales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 561)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.KeyPreview = True
        Me.Name = "SueldosLibroDeSueldosyJornales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Libro de Sueldos y Jornales"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecibosImpresosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lbPeriodo As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents RecibosImpresosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataSetSueldos As Eniac.Win.DataSetSueldos
   Friend WithEvents chbLegajo As Eniac.Controles.CheckBox
   Friend WithEvents bscNroLegajo As Eniac.Controles.Buscador
   Friend WithEvents lblNroDocumento As Eniac.Controles.Label
   Friend WithEvents bscNombrePersonal As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents PeriodoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DireccionCobroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreLocalidadDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCobradorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCuotaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaExtraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Periodo2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocSocio2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSocio2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DireccionCobro2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreLocalidad2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaSocio2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCobrador2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCuota2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaExtra2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cmbPeriodoLiquidacion As Eniac.Controles.ComboBox
   Friend WithEvents cmbTipoRecibo As Eniac.Controles.ComboBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents cmbNroLiquidacion As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbTipoDeRecibo As System.Windows.Forms.CheckBox
   Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtNroLegajo As System.Windows.Forms.RadioButton
   Friend WithEvents rbtNombre As System.Windows.Forms.RadioButton
End Class
