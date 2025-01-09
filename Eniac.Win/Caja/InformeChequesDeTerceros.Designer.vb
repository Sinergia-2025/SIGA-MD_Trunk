<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InformeChequesDeTerceros
   Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeChequesDeTerceros))
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.cmbCajas = New Eniac.Win.ComboBoxCajas()
        Me.chbTipoCheque = New System.Windows.Forms.CheckBox()
        Me.cmbTiposCheques = New Eniac.Controles.ComboBox()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.cmbEstadosCheques_M = New Eniac.Win.ComboBoxEstadosCheques()
        Me.lblMarca = New Eniac.Controles.Label()
        Me.grbOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdbOrdenNombre = New System.Windows.Forms.RadioButton()
        Me.rdbOrdenCobro = New System.Windows.Forms.RadioButton()
        Me.chbIngreso = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.dtpHastaFechaIng = New Eniac.Controles.DateTimePicker()
        Me.Label1 = New Eniac.Controles.Label()
        Me.dtpDesdeFechaIng = New Eniac.Controles.DateTimePicker()
        Me.Label2 = New Eniac.Controles.Label()
        Me.chbTitular = New Eniac.Controles.CheckBox()
        Me.txtTitular = New Eniac.Controles.TextBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.txtNumero = New Eniac.Controles.TextBox()
        Me.chbFechaEnCarteraAl = New Eniac.Controles.CheckBox()
        Me.dtpFechaEnCarteraAl = New Eniac.Controles.DateTimePicker()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.bscProveedor = New Eniac.Controles.Buscador2()
        Me.lblNombreProv = New Eniac.Controles.Label()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chbFechaCobro = New Eniac.Controles.CheckBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.cmbLocalidad = New Eniac.Controles.ComboBox()
        Me.cmbBanco = New Eniac.Controles.ComboBox()
        Me.chbBanco = New Eniac.Controles.CheckBox()
        Me.dtpFechaCobroHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaCobroHasta = New Eniac.Controles.Label()
        Me.dtpFechaCobroDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaCobroDesde = New Eniac.Controles.Label()
        Me.chbObservacion = New Eniac.Controles.CheckBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.grbFiltros.SuspendLayout()
        Me.grbOrdenar.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.txtObservacion)
        Me.grbFiltros.Controls.Add(Me.lblCaja)
        Me.grbFiltros.Controls.Add(Me.cmbCajas)
        Me.grbFiltros.Controls.Add(Me.chbTipoCheque)
        Me.grbFiltros.Controls.Add(Me.cmbTiposCheques)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.cmbEstadosCheques_M)
        Me.grbFiltros.Controls.Add(Me.lblMarca)
        Me.grbFiltros.Controls.Add(Me.grbOrdenar)
        Me.grbFiltros.Controls.Add(Me.chbIngreso)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.dtpHastaFechaIng)
        Me.grbFiltros.Controls.Add(Me.dtpDesdeFechaIng)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.chbTitular)
        Me.grbFiltros.Controls.Add(Me.txtTitular)
        Me.grbFiltros.Controls.Add(Me.chbNumero)
        Me.grbFiltros.Controls.Add(Me.txtNumero)
        Me.grbFiltros.Controls.Add(Me.chbFechaEnCarteraAl)
        Me.grbFiltros.Controls.Add(Me.dtpFechaEnCarteraAl)
        Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
        Me.grbFiltros.Controls.Add(Me.bscProveedor)
        Me.grbFiltros.Controls.Add(Me.lblCodigoProveedor)
        Me.grbFiltros.Controls.Add(Me.lblNombreProv)
        Me.grbFiltros.Controls.Add(Me.chbProveedor)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.chbFechaCobro)
        Me.grbFiltros.Controls.Add(Me.chbLocalidad)
        Me.grbFiltros.Controls.Add(Me.cmbLocalidad)
        Me.grbFiltros.Controls.Add(Me.cmbBanco)
        Me.grbFiltros.Controls.Add(Me.chbBanco)
        Me.grbFiltros.Controls.Add(Me.dtpFechaCobroHasta)
        Me.grbFiltros.Controls.Add(Me.dtpFechaCobroDesde)
        Me.grbFiltros.Controls.Add(Me.lblFechaCobroHasta)
        Me.grbFiltros.Controls.Add(Me.lblFechaCobroDesde)
        Me.grbFiltros.Controls.Add(Me.chbObservacion)
        Me.grbFiltros.Location = New System.Drawing.Point(4, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(975, 220)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'txtObservacion
        '
        Me.txtObservacion.BindearPropiedadControl = "Text"
        Me.txtObservacion.BindearPropiedadEntidad = "Titular"
        Me.txtObservacion.Enabled = False
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = ""
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = "Titular"
        Me.txtObservacion.LabelAsoc = Nothing
        Me.txtObservacion.Location = New System.Drawing.Point(388, 188)
        Me.txtObservacion.MaxLength = 40
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(305, 20)
        Me.txtObservacion.TabIndex = 39
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Me.lblCaja
        Me.lblCaja.Location = New System.Drawing.Point(32, 46)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 3
        Me.lblCaja.Text = "Caja"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = Nothing
        Me.cmbCajas.BindearPropiedadEntidad = Nothing
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Nothing
        Me.cmbCajas.Location = New System.Drawing.Point(66, 43)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
        Me.cmbCajas.SucursalesSeleccionadas = Nothing
        Me.cmbCajas.TabIndex = 4
        '
        'chbTipoCheque
        '
        Me.chbTipoCheque.AutoSize = True
        Me.chbTipoCheque.Location = New System.Drawing.Point(11, 188)
        Me.chbTipoCheque.Name = "chbTipoCheque"
        Me.chbTipoCheque.Size = New System.Drawing.Size(102, 17)
        Me.chbTipoCheque.TabIndex = 36
        Me.chbTipoCheque.Text = "Tipo de Cheque"
        Me.chbTipoCheque.UseVisualStyleBackColor = True
        '
        'cmbTiposCheques
        '
        Me.cmbTiposCheques.BindearPropiedadControl = ""
        Me.cmbTiposCheques.BindearPropiedadEntidad = ""
        Me.cmbTiposCheques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposCheques.Enabled = False
        Me.cmbTiposCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposCheques.FormattingEnabled = True
        Me.cmbTiposCheques.IsPK = False
        Me.cmbTiposCheques.IsRequired = True
        Me.cmbTiposCheques.Key = Nothing
        Me.cmbTiposCheques.LabelAsoc = Nothing
        Me.cmbTiposCheques.Location = New System.Drawing.Point(119, 186)
        Me.cmbTiposCheques.Name = "cmbTiposCheques"
        Me.cmbTiposCheques.Size = New System.Drawing.Size(114, 21)
        Me.cmbTiposCheques.TabIndex = 37
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(12, 19)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 1
        Me.lblSucursal.Text = "Sucursal"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(66, 16)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(125, 21)
        Me.cmbSucursal.TabIndex = 2
        '
        'cmbEstadosCheques_M
        '
        Me.cmbEstadosCheques_M.BindearPropiedadControl = Nothing
        Me.cmbEstadosCheques_M.BindearPropiedadEntidad = Nothing
        Me.cmbEstadosCheques_M.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadosCheques_M.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadosCheques_M.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadosCheques_M.FormattingEnabled = True
        Me.cmbEstadosCheques_M.IsPK = False
        Me.cmbEstadosCheques_M.IsRequired = False
        Me.cmbEstadosCheques_M.Key = Nothing
        Me.cmbEstadosCheques_M.LabelAsoc = Nothing
        Me.cmbEstadosCheques_M.Location = New System.Drawing.Point(281, 43)
        Me.cmbEstadosCheques_M.Name = "cmbEstadosCheques_M"
        Me.cmbEstadosCheques_M.Size = New System.Drawing.Size(125, 21)
        Me.cmbEstadosCheques_M.TabIndex = 6
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.LabelAsoc = Nothing
        Me.lblMarca.Location = New System.Drawing.Point(235, 46)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(40, 13)
        Me.lblMarca.TabIndex = 5
        Me.lblMarca.Text = "Estado"
        '
        'grbOrdenar
        '
        Me.grbOrdenar.Controls.Add(Me.rdbOrdenNombre)
        Me.grbOrdenar.Controls.Add(Me.rdbOrdenCobro)
        Me.grbOrdenar.Location = New System.Drawing.Point(714, 169)
        Me.grbOrdenar.Name = "grbOrdenar"
        Me.grbOrdenar.Size = New System.Drawing.Size(250, 45)
        Me.grbOrdenar.TabIndex = 40
        Me.grbOrdenar.TabStop = False
        Me.grbOrdenar.Text = "Ordenar por:"
        '
        'rdbOrdenNombre
        '
        Me.rdbOrdenNombre.AutoSize = True
        Me.rdbOrdenNombre.Location = New System.Drawing.Point(98, 18)
        Me.rdbOrdenNombre.Name = "rdbOrdenNombre"
        Me.rdbOrdenNombre.Size = New System.Drawing.Size(144, 17)
        Me.rdbOrdenNombre.TabIndex = 1
        Me.rdbOrdenNombre.Text = "N. Cliente + Fecha Cobro"
        Me.rdbOrdenNombre.UseVisualStyleBackColor = True
        '
        'rdbOrdenCobro
        '
        Me.rdbOrdenCobro.AutoSize = True
        Me.rdbOrdenCobro.Checked = True
        Me.rdbOrdenCobro.Location = New System.Drawing.Point(6, 17)
        Me.rdbOrdenCobro.Name = "rdbOrdenCobro"
        Me.rdbOrdenCobro.Size = New System.Drawing.Size(86, 17)
        Me.rdbOrdenCobro.TabIndex = 0
        Me.rdbOrdenCobro.TabStop = True
        Me.rdbOrdenCobro.Text = "Fecha Cobro"
        Me.rdbOrdenCobro.UseVisualStyleBackColor = True
        '
        'chbIngreso
        '
        Me.chbIngreso.AutoSize = True
        Me.chbIngreso.BindearPropiedadControl = Nothing
        Me.chbIngreso.BindearPropiedadEntidad = Nothing
        Me.chbIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIngreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIngreso.IsPK = False
        Me.chbIngreso.IsRequired = False
        Me.chbIngreso.Key = Nothing
        Me.chbIngreso.LabelAsoc = Nothing
        Me.chbIngreso.Location = New System.Drawing.Point(478, 91)
        Me.chbIngreso.Name = "chbIngreso"
        Me.chbIngreso.Size = New System.Drawing.Size(61, 17)
        Me.chbIngreso.TabIndex = 19
        Me.chbIngreso.Text = "Ingreso"
        Me.chbIngreso.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(864, 118)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 41
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpHastaFechaIng
        '
        Me.dtpHastaFechaIng.BindearPropiedadControl = Nothing
        Me.dtpHastaFechaIng.BindearPropiedadEntidad = Nothing
        Me.dtpHastaFechaIng.CustomFormat = "dd/MM/yyyy"
        Me.dtpHastaFechaIng.Enabled = False
        Me.dtpHastaFechaIng.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHastaFechaIng.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHastaFechaIng.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFechaIng.IsPK = False
        Me.dtpHastaFechaIng.IsRequired = False
        Me.dtpHastaFechaIng.Key = ""
        Me.dtpHastaFechaIng.LabelAsoc = Me.Label1
        Me.dtpHastaFechaIng.Location = New System.Drawing.Point(716, 88)
        Me.dtpHastaFechaIng.Name = "dtpHastaFechaIng"
        Me.dtpHastaFechaIng.Size = New System.Drawing.Size(95, 20)
        Me.dtpHastaFechaIng.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(676, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Hasta"
        '
        'dtpDesdeFechaIng
        '
        Me.dtpDesdeFechaIng.BindearPropiedadControl = Nothing
        Me.dtpDesdeFechaIng.BindearPropiedadEntidad = Nothing
        Me.dtpDesdeFechaIng.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesdeFechaIng.Enabled = False
        Me.dtpDesdeFechaIng.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesdeFechaIng.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesdeFechaIng.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFechaIng.IsPK = False
        Me.dtpDesdeFechaIng.IsRequired = False
        Me.dtpDesdeFechaIng.Key = ""
        Me.dtpDesdeFechaIng.LabelAsoc = Me.Label2
        Me.dtpDesdeFechaIng.Location = New System.Drawing.Point(575, 88)
        Me.dtpDesdeFechaIng.Name = "dtpDesdeFechaIng"
        Me.dtpDesdeFechaIng.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesdeFechaIng.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(537, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Desde"
        '
        'chbTitular
        '
        Me.chbTitular.AutoSize = True
        Me.chbTitular.BindearPropiedadControl = Nothing
        Me.chbTitular.BindearPropiedadEntidad = Nothing
        Me.chbTitular.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTitular.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTitular.IsPK = False
        Me.chbTitular.IsRequired = False
        Me.chbTitular.Key = Nothing
        Me.chbTitular.LabelAsoc = Nothing
        Me.chbTitular.Location = New System.Drawing.Point(11, 159)
        Me.chbTitular.Name = "chbTitular"
        Me.chbTitular.Size = New System.Drawing.Size(55, 17)
        Me.chbTitular.TabIndex = 31
        Me.chbTitular.Text = "Titular"
        Me.chbTitular.UseVisualStyleBackColor = True
        '
        'txtTitular
        '
        Me.txtTitular.BindearPropiedadControl = "Text"
        Me.txtTitular.BindearPropiedadEntidad = "Titular"
        Me.txtTitular.Enabled = False
        Me.txtTitular.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTitular.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTitular.Formato = ""
        Me.txtTitular.IsDecimal = False
        Me.txtTitular.IsNumber = False
        Me.txtTitular.IsPK = False
        Me.txtTitular.IsRequired = False
        Me.txtTitular.Key = "Titular"
        Me.txtTitular.LabelAsoc = Nothing
        Me.txtTitular.Location = New System.Drawing.Point(92, 157)
        Me.txtTitular.MaxLength = 40
        Me.txtTitular.Name = "txtTitular"
        Me.txtTitular.Size = New System.Drawing.Size(200, 20)
        Me.txtTitular.TabIndex = 32
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
        Me.chbNumero.Location = New System.Drawing.Point(554, 159)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 35
        Me.chbNumero.Text = "Numero"
        Me.chbNumero.UseVisualStyleBackColor = True
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
        Me.txtNumero.LabelAsoc = Nothing
        Me.txtNumero.Location = New System.Drawing.Point(621, 157)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(78, 20)
        Me.txtNumero.TabIndex = 0
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.chbFechaEnCarteraAl.Location = New System.Drawing.Point(778, 45)
        Me.chbFechaEnCarteraAl.Name = "chbFechaEnCarteraAl"
        Me.chbFechaEnCarteraAl.Size = New System.Drawing.Size(88, 17)
        Me.chbFechaEnCarteraAl.TabIndex = 12
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
        Me.dtpFechaEnCarteraAl.Location = New System.Drawing.Point(871, 43)
        Me.dtpFechaEnCarteraAl.Name = "dtpFechaEnCarteraAl"
        Me.dtpFechaEnCarteraAl.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEnCarteraAl.TabIndex = 13
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.Enabled = False
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(92, 129)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 26
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(89, 115)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 25
        Me.lblCodigoProveedor.Text = "Código"
        '
        'bscProveedor
        '
        Me.bscProveedor.ActivarFiltroEnGrilla = True
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ConfigBuscador = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.Enabled = False
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Me.lblNombreProv
        Me.bscProveedor.Location = New System.Drawing.Point(188, 129)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(280, 23)
        Me.bscProveedor.TabIndex = 28
        '
        'lblNombreProv
        '
        Me.lblNombreProv.AutoSize = True
        Me.lblNombreProv.LabelAsoc = Nothing
        Me.lblNombreProv.Location = New System.Drawing.Point(185, 115)
        Me.lblNombreProv.Name = "lblNombreProv"
        Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProv.TabIndex = 27
        Me.lblNombreProv.Text = "Nombre"
        '
        'chbProveedor
        '
        Me.chbProveedor.AutoSize = True
        Me.chbProveedor.BindearPropiedadControl = Nothing
        Me.chbProveedor.BindearPropiedadEntidad = Nothing
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Location = New System.Drawing.Point(11, 132)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 24
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(92, 85)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 16
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(89, 71)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 15
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
        Me.bscCliente.Location = New System.Drawing.Point(188, 85)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(280, 23)
        Me.bscCliente.TabIndex = 18
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(185, 71)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 17
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
        Me.chbCliente.Location = New System.Drawing.Point(11, 88)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 14
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'chbFechaCobro
        '
        Me.chbFechaCobro.AutoSize = True
        Me.chbFechaCobro.BindearPropiedadControl = Nothing
        Me.chbFechaCobro.BindearPropiedadEntidad = Nothing
        Me.chbFechaCobro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaCobro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaCobro.IsPK = False
        Me.chbFechaCobro.IsRequired = False
        Me.chbFechaCobro.Key = Nothing
        Me.chbFechaCobro.LabelAsoc = Nothing
        Me.chbFechaCobro.Location = New System.Drawing.Point(421, 45)
        Me.chbFechaCobro.Name = "chbFechaCobro"
        Me.chbFechaCobro.Size = New System.Drawing.Size(54, 17)
        Me.chbFechaCobro.TabIndex = 7
        Me.chbFechaCobro.Text = "Cobro"
        Me.chbFechaCobro.UseVisualStyleBackColor = True
        '
        'chbLocalidad
        '
        Me.chbLocalidad.AutoSize = True
        Me.chbLocalidad.BindearPropiedadControl = Nothing
        Me.chbLocalidad.BindearPropiedadEntidad = Nothing
        Me.chbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLocalidad.IsPK = False
        Me.chbLocalidad.IsRequired = False
        Me.chbLocalidad.Key = Nothing
        Me.chbLocalidad.LabelAsoc = Nothing
        Me.chbLocalidad.Location = New System.Drawing.Point(478, 132)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 29
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
        '
        'cmbLocalidad
        '
        Me.cmbLocalidad.BindearPropiedadControl = ""
        Me.cmbLocalidad.BindearPropiedadEntidad = ""
        Me.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalidad.Enabled = False
        Me.cmbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLocalidad.FormattingEnabled = True
        Me.cmbLocalidad.IsPK = False
        Me.cmbLocalidad.IsRequired = True
        Me.cmbLocalidad.Key = Nothing
        Me.cmbLocalidad.LabelAsoc = Nothing
        Me.cmbLocalidad.Location = New System.Drawing.Point(554, 130)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(160, 21)
        Me.cmbLocalidad.TabIndex = 30
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
        Me.cmbBanco.IsRequired = False
        Me.cmbBanco.Key = Nothing
        Me.cmbBanco.LabelAsoc = Nothing
        Me.cmbBanco.Location = New System.Drawing.Point(362, 157)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(160, 21)
        Me.cmbBanco.TabIndex = 34
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
        Me.chbBanco.Location = New System.Drawing.Point(304, 159)
        Me.chbBanco.Name = "chbBanco"
        Me.chbBanco.Size = New System.Drawing.Size(57, 17)
        Me.chbBanco.TabIndex = 33
        Me.chbBanco.Text = "Banco"
        Me.chbBanco.UseVisualStyleBackColor = True
        '
        'dtpFechaCobroHasta
        '
        Me.dtpFechaCobroHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaCobroHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaCobroHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCobroHasta.Enabled = False
        Me.dtpFechaCobroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCobroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCobroHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCobroHasta.IsPK = False
        Me.dtpFechaCobroHasta.IsRequired = False
        Me.dtpFechaCobroHasta.Key = ""
        Me.dtpFechaCobroHasta.LabelAsoc = Me.lblFechaCobroHasta
        Me.dtpFechaCobroHasta.Location = New System.Drawing.Point(661, 42)
        Me.dtpFechaCobroHasta.Name = "dtpFechaCobroHasta"
        Me.dtpFechaCobroHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaCobroHasta.TabIndex = 11
        '
        'lblFechaCobroHasta
        '
        Me.lblFechaCobroHasta.AutoSize = True
        Me.lblFechaCobroHasta.LabelAsoc = Nothing
        Me.lblFechaCobroHasta.Location = New System.Drawing.Point(623, 46)
        Me.lblFechaCobroHasta.Name = "lblFechaCobroHasta"
        Me.lblFechaCobroHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaCobroHasta.TabIndex = 10
        Me.lblFechaCobroHasta.Text = "Hasta"
        '
        'dtpFechaCobroDesde
        '
        Me.dtpFechaCobroDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaCobroDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaCobroDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCobroDesde.Enabled = False
        Me.dtpFechaCobroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCobroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCobroDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCobroDesde.IsPK = False
        Me.dtpFechaCobroDesde.IsRequired = False
        Me.dtpFechaCobroDesde.Key = ""
        Me.dtpFechaCobroDesde.LabelAsoc = Me.lblFechaCobroDesde
        Me.dtpFechaCobroDesde.Location = New System.Drawing.Point(522, 42)
        Me.dtpFechaCobroDesde.Name = "dtpFechaCobroDesde"
        Me.dtpFechaCobroDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaCobroDesde.TabIndex = 9
        '
        'lblFechaCobroDesde
        '
        Me.lblFechaCobroDesde.AutoSize = True
        Me.lblFechaCobroDesde.LabelAsoc = Nothing
        Me.lblFechaCobroDesde.Location = New System.Drawing.Point(481, 46)
        Me.lblFechaCobroDesde.Name = "lblFechaCobroDesde"
        Me.lblFechaCobroDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaCobroDesde.TabIndex = 8
        Me.lblFechaCobroDesde.Text = "Desde"
        '
        'chbObservacion
        '
        Me.chbObservacion.AutoSize = True
        Me.chbObservacion.BindearPropiedadControl = Nothing
        Me.chbObservacion.BindearPropiedadEntidad = Nothing
        Me.chbObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbObservacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbObservacion.IsPK = False
        Me.chbObservacion.IsRequired = False
        Me.chbObservacion.Key = Nothing
        Me.chbObservacion.LabelAsoc = Nothing
        Me.chbObservacion.Location = New System.Drawing.Point(303, 190)
        Me.chbObservacion.Name = "chbObservacion"
        Me.chbObservacion.Size = New System.Drawing.Size(86, 17)
        Me.chbObservacion.TabIndex = 38
        Me.chbObservacion.Text = "Observación"
        Me.chbObservacion.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 540)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 2
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
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre las columnas aquí para agrupar."
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
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Location = New System.Drawing.Point(4, 264)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(975, 273)
        Me.ugDetalle.TabIndex = 0
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
        'InformeChequesDeTerceros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InformeChequesDeTerceros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Cheques de Terceros"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.grbOrdenar.ResumeLayout(False)
        Me.grbOrdenar.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpFechaCobroHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCobroHasta As Eniac.Controles.Label
   Friend WithEvents dtpFechaCobroDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCobroDesde As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbBanco As Eniac.Controles.CheckBox
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbFechaCobro As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
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
   Friend WithEvents chbTitular As Eniac.Controles.CheckBox
   Friend WithEvents txtTitular As Eniac.Controles.TextBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbFechaEnCarteraAl As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaEnCarteraAl As Eniac.Controles.DateTimePicker
   Friend WithEvents chbIngreso As Eniac.Controles.CheckBox
   Friend WithEvents dtpHastaFechaIng As Eniac.Controles.DateTimePicker
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dtpDesdeFechaIng As Eniac.Controles.DateTimePicker
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents grbOrdenar As System.Windows.Forms.GroupBox
   Friend WithEvents rdbOrdenNombre As System.Windows.Forms.RadioButton
   Friend WithEvents rdbOrdenCobro As System.Windows.Forms.RadioButton
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents cmbEstadosCheques_M As Eniac.Win.ComboBoxEstadosCheques
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents chbTipoCheque As System.Windows.Forms.CheckBox
   Friend WithEvents cmbTiposCheques As Eniac.Controles.ComboBox
   Friend WithEvents cmbCajas As Eniac.Win.ComboBoxCajas
   Friend WithEvents lblCaja As Eniac.Controles.Label
    Friend WithEvents txtObservacion As Controles.TextBox
    Friend WithEvents chbObservacion As Controles.CheckBox
End Class
