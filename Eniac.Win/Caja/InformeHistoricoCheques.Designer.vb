<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeHistoricoCheques
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeHistoricoCheques))
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
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpFechaActHasta = New Eniac.Controles.DateTimePicker()
        Me.Label3 = New Eniac.Controles.Label()
        Me.dtpFechaActDesde = New Eniac.Controles.DateTimePicker()
        Me.Label4 = New Eniac.Controles.Label()
        Me.grbOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdbOrdenNombre = New System.Windows.Forms.RadioButton()
        Me.rdbOrdenFechaActualizacion = New System.Windows.Forms.RadioButton()
        Me.chbIngreso = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.dtpHastaFechaIng = New Eniac.Controles.DateTimePicker()
        Me.Label1 = New Eniac.Controles.Label()
        Me.dtpDesdeFechaIng = New Eniac.Controles.DateTimePicker()
        Me.Label2 = New Eniac.Controles.Label()
        Me.chbTitular = New Eniac.Controles.CheckBox()
        Me.txtTitular = New Eniac.Controles.TextBox()
        Me.chbCaja = New Eniac.Controles.CheckBox()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.txtNumero = New Eniac.Controles.TextBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.lblNombreProv = New Eniac.Controles.Label()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chbFechaCobro = New Eniac.Controles.CheckBox()
        Me.chbEstado = New Eniac.Controles.CheckBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.cmbLocalidad = New Eniac.Controles.ComboBox()
        Me.cmbBanco = New Eniac.Controles.ComboBox()
        Me.chbBanco = New Eniac.Controles.CheckBox()
        Me.cmbEstado = New Eniac.Controles.ComboBox()
        Me.dtpFechaCobroHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaCobroHasta = New Eniac.Controles.Label()
        Me.dtpFechaCobroDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaCobroDesde = New Eniac.Controles.Label()
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
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpFechaActHasta)
        Me.grbFiltros.Controls.Add(Me.dtpFechaActDesde)
        Me.grbFiltros.Controls.Add(Me.Label3)
        Me.grbFiltros.Controls.Add(Me.Label4)
        Me.grbFiltros.Controls.Add(Me.grbOrdenar)
        Me.grbFiltros.Controls.Add(Me.chbIngreso)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.dtpHastaFechaIng)
        Me.grbFiltros.Controls.Add(Me.dtpDesdeFechaIng)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.chbTitular)
        Me.grbFiltros.Controls.Add(Me.txtTitular)
        Me.grbFiltros.Controls.Add(Me.chbCaja)
        Me.grbFiltros.Controls.Add(Me.cmbCajas)
        Me.grbFiltros.Controls.Add(Me.chbNumero)
        Me.grbFiltros.Controls.Add(Me.txtNumero)
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
        Me.grbFiltros.Controls.Add(Me.chbEstado)
        Me.grbFiltros.Controls.Add(Me.chbLocalidad)
        Me.grbFiltros.Controls.Add(Me.cmbLocalidad)
        Me.grbFiltros.Controls.Add(Me.cmbBanco)
        Me.grbFiltros.Controls.Add(Me.chbBanco)
        Me.grbFiltros.Controls.Add(Me.cmbEstado)
        Me.grbFiltros.Controls.Add(Me.dtpFechaCobroHasta)
        Me.grbFiltros.Controls.Add(Me.dtpFechaCobroDesde)
        Me.grbFiltros.Controls.Add(Me.lblFechaCobroHasta)
        Me.grbFiltros.Controls.Add(Me.lblFechaCobroDesde)
        Me.grbFiltros.Location = New System.Drawing.Point(4, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(975, 164)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(13, 22)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpFechaActHasta
        '
        Me.dtpFechaActHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaActHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaActHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaActHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaActHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaActHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaActHasta.IsPK = False
        Me.dtpFechaActHasta.IsRequired = False
        Me.dtpFechaActHasta.Key = ""
        Me.dtpFechaActHasta.LabelAsoc = Me.Label3
        Me.dtpFechaActHasta.Location = New System.Drawing.Point(291, 19)
        Me.dtpFechaActHasta.Name = "dtpFechaActHasta"
        Me.dtpFechaActHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaActHasta.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(253, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Hasta"
        '
        'dtpFechaActDesde
        '
        Me.dtpFechaActDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaActDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaActDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaActDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaActDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaActDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaActDesde.IsPK = False
        Me.dtpFechaActDesde.IsRequired = False
        Me.dtpFechaActDesde.Key = ""
        Me.dtpFechaActDesde.LabelAsoc = Me.Label4
        Me.dtpFechaActDesde.Location = New System.Drawing.Point(153, 19)
        Me.dtpFechaActDesde.Name = "dtpFechaActDesde"
        Me.dtpFechaActDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaActDesde.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(112, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Desde"
        '
        'grbOrdenar
        '
        Me.grbOrdenar.Controls.Add(Me.rdbOrdenNombre)
        Me.grbOrdenar.Controls.Add(Me.rdbOrdenFechaActualizacion)
        Me.grbOrdenar.Location = New System.Drawing.Point(691, 102)
        Me.grbOrdenar.Name = "grbOrdenar"
        Me.grbOrdenar.Size = New System.Drawing.Size(280, 56)
        Me.grbOrdenar.TabIndex = 0
        Me.grbOrdenar.TabStop = False
        Me.grbOrdenar.Text = "Ordenar por:"
        '
        'rdbOrdenNombre
        '
        Me.rdbOrdenNombre.AutoSize = True
        Me.rdbOrdenNombre.Location = New System.Drawing.Point(132, 22)
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
        Me.rdbOrdenFechaActualizacion.Location = New System.Drawing.Point(9, 23)
        Me.rdbOrdenFechaActualizacion.Name = "rdbOrdenFechaActualizacion"
        Me.rdbOrdenFechaActualizacion.Size = New System.Drawing.Size(121, 17)
        Me.rdbOrdenFechaActualizacion.TabIndex = 40
        Me.rdbOrdenFechaActualizacion.TabStop = True
        Me.rdbOrdenFechaActualizacion.Text = "Fecha Actualización"
        Me.rdbOrdenFechaActualizacion.UseVisualStyleBackColor = True
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
        Me.chbIngreso.Location = New System.Drawing.Point(450, 75)
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
        Me.btnConsultar.Location = New System.Drawing.Point(858, 36)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 38
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
        Me.dtpHastaFechaIng.Location = New System.Drawing.Point(733, 70)
        Me.dtpHastaFechaIng.Name = "dtpHastaFechaIng"
        Me.dtpHastaFechaIng.Size = New System.Drawing.Size(95, 20)
        Me.dtpHastaFechaIng.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(689, 74)
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
        Me.dtpDesdeFechaIng.Location = New System.Drawing.Point(578, 72)
        Me.dtpDesdeFechaIng.Name = "dtpDesdeFechaIng"
        Me.dtpDesdeFechaIng.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesdeFechaIng.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(530, 74)
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
        Me.chbTitular.Location = New System.Drawing.Point(13, 136)
        Me.chbTitular.Name = "chbTitular"
        Me.chbTitular.Size = New System.Drawing.Size(55, 17)
        Me.chbTitular.TabIndex = 32
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
        Me.txtTitular.IsRequired = True
        Me.txtTitular.Key = "Titular"
        Me.txtTitular.LabelAsoc = Nothing
        Me.txtTitular.Location = New System.Drawing.Point(90, 134)
        Me.txtTitular.MaxLength = 40
        Me.txtTitular.Name = "txtTitular"
        Me.txtTitular.Size = New System.Drawing.Size(200, 20)
        Me.txtTitular.TabIndex = 33
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
        Me.chbCaja.Location = New System.Drawing.Point(450, 17)
        Me.chbCaja.Name = "chbCaja"
        Me.chbCaja.Size = New System.Drawing.Size(47, 17)
        Me.chbCaja.TabIndex = 5
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
        Me.cmbCajas.Location = New System.Drawing.Point(502, 15)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
        Me.cmbCajas.TabIndex = 6
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
        Me.chbNumero.Location = New System.Drawing.Point(517, 136)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 36
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
        Me.txtNumero.Location = New System.Drawing.Point(581, 134)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(78, 20)
        Me.txtNumero.TabIndex = 37
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.AyudaAncho = 608
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
        Me.bscCodigoProveedor.ColumnasAncho = Nothing
        Me.bscCodigoProveedor.ColumnasFormato = Nothing
        Me.bscCodigoProveedor.ColumnasOcultas = Nothing
        Me.bscCodigoProveedor.ColumnasTitulos = Nothing
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
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(90, 101)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 25
        Me.bscCodigoProveedor.Titulo = Nothing
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(87, 87)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 26
        Me.lblCodigoProveedor.Text = "Código"
        '
        'bscProveedor
        '
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.AyudaAncho = 608
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ColumnasAlineacion = Nothing
        Me.bscProveedor.ColumnasAncho = Nothing
        Me.bscProveedor.ColumnasFormato = Nothing
        Me.bscProveedor.ColumnasOcultas = Nothing
        Me.bscProveedor.ColumnasTitulos = Nothing
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
        Me.bscProveedor.Location = New System.Drawing.Point(187, 101)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(251, 23)
        Me.bscProveedor.TabIndex = 27
        Me.bscProveedor.Titulo = Nothing
        '
        'lblNombreProv
        '
        Me.lblNombreProv.AutoSize = True
        Me.lblNombreProv.LabelAsoc = Nothing
        Me.lblNombreProv.Location = New System.Drawing.Point(183, 87)
        Me.lblNombreProv.Name = "lblNombreProv"
        Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProv.TabIndex = 28
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
        Me.chbProveedor.Location = New System.Drawing.Point(13, 104)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 24
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 608
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ColumnasAlineacion = Nothing
        Me.bscCodigoCliente.ColumnasAncho = Nothing
        Me.bscCodigoCliente.ColumnasFormato = Nothing
        Me.bscCodigoCliente.ColumnasOcultas = Nothing
        Me.bscCodigoCliente.ColumnasTitulos = Nothing
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(90, 61)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 10
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(87, 47)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 11
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 608
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ColumnasAlineacion = Nothing
        Me.bscCliente.ColumnasAncho = Nothing
        Me.bscCliente.ColumnasFormato = Nothing
        Me.bscCliente.ColumnasOcultas = Nothing
        Me.bscCliente.ColumnasTitulos = Nothing
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
        Me.bscCliente.Location = New System.Drawing.Point(187, 61)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(251, 23)
        Me.bscCliente.TabIndex = 12
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(183, 47)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 13
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
        Me.chbCliente.Location = New System.Drawing.Point(13, 64)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 9
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
        Me.chbFechaCobro.Location = New System.Drawing.Point(450, 45)
        Me.chbFechaCobro.Name = "chbFechaCobro"
        Me.chbFechaCobro.Size = New System.Drawing.Size(54, 17)
        Me.chbFechaCobro.TabIndex = 14
        Me.chbFechaCobro.Text = "Cobro"
        Me.chbFechaCobro.UseVisualStyleBackColor = True
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
        Me.chbEstado.Location = New System.Drawing.Point(640, 17)
        Me.chbEstado.Name = "chbEstado"
        Me.chbEstado.Size = New System.Drawing.Size(59, 17)
        Me.chbEstado.TabIndex = 7
        Me.chbEstado.Text = "Estado"
        Me.chbEstado.UseVisualStyleBackColor = True
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
        Me.chbLocalidad.Location = New System.Drawing.Point(450, 104)
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
        Me.cmbLocalidad.Location = New System.Drawing.Point(522, 102)
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
        Me.cmbBanco.IsRequired = True
        Me.cmbBanco.Key = Nothing
        Me.cmbBanco.LabelAsoc = Nothing
        Me.cmbBanco.Location = New System.Drawing.Point(352, 134)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(160, 21)
        Me.cmbBanco.TabIndex = 35
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
        Me.chbBanco.Location = New System.Drawing.Point(296, 136)
        Me.chbBanco.Name = "chbBanco"
        Me.chbBanco.Size = New System.Drawing.Size(57, 17)
        Me.chbBanco.TabIndex = 34
        Me.chbBanco.Text = "Banco"
        Me.chbBanco.UseVisualStyleBackColor = True
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
        Me.cmbEstado.Location = New System.Drawing.Point(703, 15)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(125, 21)
        Me.cmbEstado.TabIndex = 8
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
        Me.dtpFechaCobroHasta.Location = New System.Drawing.Point(733, 43)
        Me.dtpFechaCobroHasta.Name = "dtpFechaCobroHasta"
        Me.dtpFechaCobroHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaCobroHasta.TabIndex = 18
        '
        'lblFechaCobroHasta
        '
        Me.lblFechaCobroHasta.AutoSize = True
        Me.lblFechaCobroHasta.LabelAsoc = Nothing
        Me.lblFechaCobroHasta.Location = New System.Drawing.Point(689, 47)
        Me.lblFechaCobroHasta.Name = "lblFechaCobroHasta"
        Me.lblFechaCobroHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaCobroHasta.TabIndex = 17
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
        Me.dtpFechaCobroDesde.Location = New System.Drawing.Point(578, 43)
        Me.dtpFechaCobroDesde.Name = "dtpFechaCobroDesde"
        Me.dtpFechaCobroDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaCobroDesde.TabIndex = 16
        '
        'lblFechaCobroDesde
        '
        Me.lblFechaCobroDesde.AutoSize = True
        Me.lblFechaCobroDesde.LabelAsoc = Nothing
        Me.lblFechaCobroDesde.Location = New System.Drawing.Point(530, 46)
        Me.lblFechaCobroDesde.Name = "lblFechaCobroDesde"
        Me.lblFechaCobroDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaCobroDesde.TabIndex = 15
        Me.lblFechaCobroDesde.Text = "Desde"
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
        Me.ugDetalle.Location = New System.Drawing.Point(4, 208)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(975, 329)
        Me.ugDetalle.TabIndex = 1
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
        'InformeHistoricoCheques
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
        Me.Name = "InformeHistoricoCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe Historico de Cheques"
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
   Friend WithEvents cmbEstado As Eniac.Controles.ComboBox
   Friend WithEvents chbBanco As Eniac.Controles.CheckBox
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Friend WithEvents chbEstado As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbFechaCobro As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
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
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbIngreso As Eniac.Controles.CheckBox
   Friend WithEvents dtpHastaFechaIng As Eniac.Controles.DateTimePicker
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dtpDesdeFechaIng As Eniac.Controles.DateTimePicker
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents grbOrdenar As System.Windows.Forms.GroupBox
   Friend WithEvents rdbOrdenNombre As System.Windows.Forms.RadioButton
   Friend WithEvents rdbOrdenFechaActualizacion As System.Windows.Forms.RadioButton
   Friend WithEvents dtpFechaActHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents dtpFechaActDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
End Class
