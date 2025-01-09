<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadListadoAsientos
    Inherits Eniac.Win.BaseForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadListadoAsientos))
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.fraFiltros = New System.Windows.Forms.GroupBox()
      Me.chbCentroCosto = New Eniac.Controles.CheckBox()
      Me.chbAsiento = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.bscNumeroAsiento = New Eniac.Controles.Buscador2()
      Me.bscConcepto = New Eniac.Controles.Buscador2()
      Me.lblConcepto = New Eniac.Controles.Label()
      Me.lblFechaAsiento = New Eniac.Controles.Label()
      Me.lblNumeroAsiento = New Eniac.Controles.Label()
      Me.cmbExportados = New Eniac.Controles.ComboBox()
      Me.lblExportados = New Eniac.Controles.Label()
      Me.cmbCentroCosto = New Eniac.Controles.ComboBox()
      Me.cmbTipoRegistro = New Eniac.Controles.ComboBox()
      Me.lblTipoRegistro = New Eniac.Controles.Label()
      Me.cmbPlan = New Eniac.Controles.ComboBox()
      Me.lblPlan = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.clbSucursales = New Eniac.Controles.CheckedListBox()
      Me.btnConsultar = New Eniac.Win.ButtonConsultar()
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.pnlAcciones = New System.Windows.Forms.Panel()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.fraFiltros.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.pnlAcciones.SuspendLayout()
      Me.SuspendLayout()
      '
      'fraFiltros
      '
      Me.fraFiltros.Controls.Add(Me.chbCentroCosto)
      Me.fraFiltros.Controls.Add(Me.chbAsiento)
      Me.fraFiltros.Controls.Add(Me.chkMesCompleto)
      Me.fraFiltros.Controls.Add(Me.dtpHasta)
      Me.fraFiltros.Controls.Add(Me.dtpDesde)
      Me.fraFiltros.Controls.Add(Me.lblHasta)
      Me.fraFiltros.Controls.Add(Me.lblDesde)
      Me.fraFiltros.Controls.Add(Me.lblFecha)
      Me.fraFiltros.Controls.Add(Me.bscNumeroAsiento)
      Me.fraFiltros.Controls.Add(Me.bscConcepto)
      Me.fraFiltros.Controls.Add(Me.lblConcepto)
      Me.fraFiltros.Controls.Add(Me.lblFechaAsiento)
      Me.fraFiltros.Controls.Add(Me.lblNumeroAsiento)
      Me.fraFiltros.Controls.Add(Me.cmbExportados)
      Me.fraFiltros.Controls.Add(Me.cmbCentroCosto)
      Me.fraFiltros.Controls.Add(Me.cmbTipoRegistro)
      Me.fraFiltros.Controls.Add(Me.lblExportados)
      Me.fraFiltros.Controls.Add(Me.cmbPlan)
      Me.fraFiltros.Controls.Add(Me.lblTipoRegistro)
      Me.fraFiltros.Controls.Add(Me.lblPlan)
      Me.fraFiltros.Controls.Add(Me.Label3)
      Me.fraFiltros.Controls.Add(Me.clbSucursales)
      Me.fraFiltros.Dock = System.Windows.Forms.DockStyle.Top
      Me.fraFiltros.Location = New System.Drawing.Point(0, 29)
      Me.fraFiltros.Name = "fraFiltros"
      Me.fraFiltros.Size = New System.Drawing.Size(974, 112)
      Me.fraFiltros.TabIndex = 0
      Me.fraFiltros.TabStop = False
      Me.fraFiltros.Text = "Filtros"
      '
      'chbCentroCosto
      '
      Me.chbCentroCosto.AutoSize = True
      Me.chbCentroCosto.BindearPropiedadControl = Nothing
      Me.chbCentroCosto.BindearPropiedadEntidad = Nothing
      Me.chbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCentroCosto.IsPK = False
      Me.chbCentroCosto.IsRequired = False
      Me.chbCentroCosto.Key = Nothing
      Me.chbCentroCosto.LabelAsoc = Nothing
      Me.chbCentroCosto.Location = New System.Drawing.Point(543, 45)
      Me.chbCentroCosto.Name = "chbCentroCosto"
      Me.chbCentroCosto.Size = New System.Drawing.Size(107, 17)
      Me.chbCentroCosto.TabIndex = 13
      Me.chbCentroCosto.Text = "Centro de Costos"
      Me.chbCentroCosto.UseVisualStyleBackColor = True
      '
      'chbAsiento
      '
      Me.chbAsiento.AutoSize = True
      Me.chbAsiento.BindearPropiedadControl = Nothing
      Me.chbAsiento.BindearPropiedadEntidad = Nothing
      Me.chbAsiento.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAsiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAsiento.IsPK = False
      Me.chbAsiento.IsRequired = False
      Me.chbAsiento.Key = Nothing
      Me.chbAsiento.LabelAsoc = Nothing
      Me.chbAsiento.Location = New System.Drawing.Point(324, 88)
      Me.chbAsiento.Name = "chbAsiento"
      Me.chbAsiento.Size = New System.Drawing.Size(61, 17)
      Me.chbAsiento.TabIndex = 15
      Me.chbAsiento.Text = "Asiento"
      Me.chbAsiento.UseVisualStyleBackColor = True
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(292, 18)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 4
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
      Me.dtpHasta.Location = New System.Drawing.Point(556, 16)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(80, 20)
      Me.dtpHasta.TabIndex = 8
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(518, 20)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 7
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
      Me.dtpDesde.Location = New System.Drawing.Point(423, 16)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(80, 20)
      Me.dtpDesde.TabIndex = 6
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(384, 20)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 5
      Me.lblDesde.Text = "Desde"
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.LabelAsoc = Nothing
      Me.lblFecha.Location = New System.Drawing.Point(764, 90)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(42, 13)
      Me.lblFecha.TabIndex = 21
      Me.lblFecha.Text = "{fecha}"
      '
      'bscNumeroAsiento
      '
      Me.bscNumeroAsiento.ActivarFiltroEnGrilla = True
      Me.bscNumeroAsiento.BindearPropiedadControl = Nothing
      Me.bscNumeroAsiento.BindearPropiedadEntidad = Nothing
      Me.bscNumeroAsiento.ConfigBuscador = Nothing
      Me.bscNumeroAsiento.Datos = Nothing
      Me.bscNumeroAsiento.FilaDevuelta = Nothing
      Me.bscNumeroAsiento.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNumeroAsiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNumeroAsiento.IsDecimal = False
      Me.bscNumeroAsiento.IsNumber = True
      Me.bscNumeroAsiento.IsPK = False
      Me.bscNumeroAsiento.IsRequired = False
      Me.bscNumeroAsiento.Key = ""
      Me.bscNumeroAsiento.LabelAsoc = Nothing
      Me.bscNumeroAsiento.Location = New System.Drawing.Point(388, 86)
      Me.bscNumeroAsiento.MaxLengh = "32767"
      Me.bscNumeroAsiento.Name = "bscNumeroAsiento"
      Me.bscNumeroAsiento.Permitido = False
      Me.bscNumeroAsiento.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNumeroAsiento.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNumeroAsiento.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNumeroAsiento.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNumeroAsiento.Selecciono = False
      Me.bscNumeroAsiento.Size = New System.Drawing.Size(95, 20)
      Me.bscNumeroAsiento.TabIndex = 17
      '
      'bscConcepto
      '
      Me.bscConcepto.ActivarFiltroEnGrilla = True
      Me.bscConcepto.BindearPropiedadControl = Nothing
      Me.bscConcepto.BindearPropiedadEntidad = Nothing
      Me.bscConcepto.ConfigBuscador = Nothing
      Me.bscConcepto.Datos = Nothing
      Me.bscConcepto.FilaDevuelta = Nothing
      Me.bscConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscConcepto.IsDecimal = False
      Me.bscConcepto.IsNumber = False
      Me.bscConcepto.IsPK = False
      Me.bscConcepto.IsRequired = False
      Me.bscConcepto.Key = ""
      Me.bscConcepto.LabelAsoc = Me.lblConcepto
      Me.bscConcepto.Location = New System.Drawing.Point(489, 86)
      Me.bscConcepto.MaxLengh = "32767"
      Me.bscConcepto.Name = "bscConcepto"
      Me.bscConcepto.Permitido = False
      Me.bscConcepto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscConcepto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscConcepto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscConcepto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscConcepto.Selecciono = False
      Me.bscConcepto.Size = New System.Drawing.Size(262, 20)
      Me.bscConcepto.TabIndex = 19
      '
      'lblConcepto
      '
      Me.lblConcepto.AutoSize = True
      Me.lblConcepto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblConcepto.LabelAsoc = Nothing
      Me.lblConcepto.Location = New System.Drawing.Point(486, 70)
      Me.lblConcepto.Name = "lblConcepto"
      Me.lblConcepto.Size = New System.Drawing.Size(53, 13)
      Me.lblConcepto.TabIndex = 18
      Me.lblConcepto.Text = "Concepto"
      '
      'lblFechaAsiento
      '
      Me.lblFechaAsiento.AutoSize = True
      Me.lblFechaAsiento.LabelAsoc = Nothing
      Me.lblFechaAsiento.Location = New System.Drawing.Point(764, 70)
      Me.lblFechaAsiento.Name = "lblFechaAsiento"
      Me.lblFechaAsiento.Size = New System.Drawing.Size(91, 13)
      Me.lblFechaAsiento.TabIndex = 20
      Me.lblFechaAsiento.Text = "Fecha del asiento"
      '
      'lblNumeroAsiento
      '
      Me.lblNumeroAsiento.AutoSize = True
      Me.lblNumeroAsiento.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblNumeroAsiento.LabelAsoc = Nothing
      Me.lblNumeroAsiento.Location = New System.Drawing.Point(385, 70)
      Me.lblNumeroAsiento.Name = "lblNumeroAsiento"
      Me.lblNumeroAsiento.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroAsiento.TabIndex = 16
      Me.lblNumeroAsiento.Text = "Número"
      '
      'cmbExportados
      '
      Me.cmbExportados.BindearPropiedadControl = ""
      Me.cmbExportados.BindearPropiedadEntidad = ""
      Me.cmbExportados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbExportados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbExportados.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbExportados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbExportados.FormattingEnabled = True
      Me.cmbExportados.IsPK = False
      Me.cmbExportados.IsRequired = True
      Me.cmbExportados.Key = Nothing
      Me.cmbExportados.LabelAsoc = Me.lblExportados
      Me.cmbExportados.Location = New System.Drawing.Point(723, 16)
      Me.cmbExportados.Name = "cmbExportados"
      Me.cmbExportados.Size = New System.Drawing.Size(117, 21)
      Me.cmbExportados.TabIndex = 10
      '
      'lblExportados
      '
      Me.lblExportados.AutoSize = True
      Me.lblExportados.LabelAsoc = Nothing
      Me.lblExportados.Location = New System.Drawing.Point(657, 20)
      Me.lblExportados.Name = "lblExportados"
      Me.lblExportados.Size = New System.Drawing.Size(60, 13)
      Me.lblExportados.TabIndex = 9
      Me.lblExportados.Text = "Exportados"
      '
      'cmbCentroCosto
      '
      Me.cmbCentroCosto.BindearPropiedadControl = "SelectedValue"
      Me.cmbCentroCosto.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCentroCosto.Enabled = False
      Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCentroCosto.FormattingEnabled = True
      Me.cmbCentroCosto.IsPK = False
      Me.cmbCentroCosto.IsRequired = True
      Me.cmbCentroCosto.Key = Nothing
      Me.cmbCentroCosto.LabelAsoc = Nothing
      Me.cmbCentroCosto.Location = New System.Drawing.Point(660, 43)
      Me.cmbCentroCosto.Name = "cmbCentroCosto"
      Me.cmbCentroCosto.Size = New System.Drawing.Size(180, 21)
      Me.cmbCentroCosto.TabIndex = 14
      '
      'cmbTipoRegistro
      '
      Me.cmbTipoRegistro.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoRegistro.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.cmbTipoRegistro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoRegistro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoRegistro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoRegistro.FormattingEnabled = True
      Me.cmbTipoRegistro.IsPK = False
      Me.cmbTipoRegistro.IsRequired = True
      Me.cmbTipoRegistro.Key = Nothing
      Me.cmbTipoRegistro.LabelAsoc = Me.lblTipoRegistro
      Me.cmbTipoRegistro.Location = New System.Drawing.Point(386, 43)
      Me.cmbTipoRegistro.Name = "cmbTipoRegistro"
      Me.cmbTipoRegistro.Size = New System.Drawing.Size(117, 21)
      Me.cmbTipoRegistro.TabIndex = 12
      '
      'lblTipoRegistro
      '
      Me.lblTipoRegistro.AutoSize = True
      Me.lblTipoRegistro.LabelAsoc = Nothing
      Me.lblTipoRegistro.Location = New System.Drawing.Point(289, 47)
      Me.lblTipoRegistro.Name = "lblTipoRegistro"
      Me.lblTipoRegistro.Size = New System.Drawing.Size(85, 13)
      Me.lblTipoRegistro.TabIndex = 11
      Me.lblTipoRegistro.Text = "Tipo de Registro"
      '
      'cmbPlan
      '
      Me.cmbPlan.BindearPropiedadControl = "SelectedValue"
      Me.cmbPlan.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPlan.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPlan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPlan.FormattingEnabled = True
      Me.cmbPlan.IsPK = False
      Me.cmbPlan.IsRequired = True
      Me.cmbPlan.Key = Nothing
      Me.cmbPlan.LabelAsoc = Me.lblPlan
      Me.cmbPlan.Location = New System.Drawing.Point(98, 86)
      Me.cmbPlan.Name = "cmbPlan"
      Me.cmbPlan.Size = New System.Drawing.Size(180, 21)
      Me.cmbPlan.TabIndex = 3
      '
      'lblPlan
      '
      Me.lblPlan.AutoSize = True
      Me.lblPlan.LabelAsoc = Nothing
      Me.lblPlan.Location = New System.Drawing.Point(13, 90)
      Me.lblPlan.Name = "lblPlan"
      Me.lblPlan.Size = New System.Drawing.Size(80, 13)
      Me.lblPlan.TabIndex = 2
      Me.lblPlan.Text = "Plan de Cuenta"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(13, 16)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Sucursales"
      '
      'clbSucursales
      '
      Me.clbSucursales.CheckOnClick = True
      Me.clbSucursales.ForeColorFocus = System.Drawing.Color.Red
      Me.clbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.clbSucursales.FormattingEnabled = True
      Me.clbSucursales.IsPK = False
      Me.clbSucursales.IsRequired = False
      Me.clbSucursales.Key = Nothing
      Me.clbSucursales.LabelAsoc = Nothing
      Me.clbSucursales.Location = New System.Drawing.Point(98, 16)
      Me.clbSucursales.Name = "clbSucursales"
      Me.clbSucursales.Size = New System.Drawing.Size(180, 64)
      Me.clbSucursales.TabIndex = 1
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.AnchoredControl = Me.ugDetalle
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(859, 161)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
      Me.btnConsultar.TabIndex = 2
      Me.btnConsultar.Text = "&Consultar (F3)"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Location = New System.Drawing.Point(0, 158)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(974, 371)
      Me.ugDetalle.TabIndex = 3
      Me.ugDetalle.Text = "UltraGrid1"
      Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 529)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(974, 22)
      Me.stsStado.TabIndex = 4
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(895, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.tsddExportar, Me.tsbImprimir2, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(974, 29)
      Me.tstBarra.TabIndex = 5
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
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
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
      'tsbImprimir2
      '
      Me.tsbImprimir2.Image = CType(resources.GetObject("tsbImprimir2.Image"), System.Drawing.Image)
      Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir2.Name = "tsbImprimir2"
      Me.tsbImprimir2.Size = New System.Drawing.Size(125, 26)
      Me.tsbImprimir2.Text = "Imp. &Prediseñado"
      Me.tsbImprimir2.ToolTipText = "Imprimir y Grabar (F4)"
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
      'pnlAcciones
      '
      Me.pnlAcciones.Controls.Add(Me.chkExpandAll)
      Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlAcciones.Location = New System.Drawing.Point(0, 141)
      Me.pnlAcciones.Name = "pnlAcciones"
      Me.pnlAcciones.Size = New System.Drawing.Size(974, 17)
      Me.pnlAcciones.TabIndex = 1
      '
      'chkExpandAll
      '
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(859, 0)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chkExpandAll.TabIndex = 0
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'ContabilidadListadoAsientos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(974, 551)
      Me.Controls.Add(Me.btnConsultar)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.pnlAcciones)
      Me.Controls.Add(Me.fraFiltros)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "ContabilidadListadoAsientos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar Asientos"
      Me.fraFiltros.ResumeLayout(False)
      Me.fraFiltros.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.pnlAcciones.ResumeLayout(False)
      Me.pnlAcciones.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents fraFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents lblPlan As Eniac.Controles.Label
   Friend WithEvents btnConsultar As ButtonConsultar
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
   Friend WithEvents bscConcepto As Eniac.Controles.Buscador2
   Friend WithEvents lblConcepto As Eniac.Controles.Label
   Friend WithEvents lblFechaAsiento As Eniac.Controles.Label
   Friend WithEvents lblNumeroAsiento As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents bscNumeroAsiento As Eniac.Controles.Buscador2
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents cmbTipoRegistro As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoRegistro As Eniac.Controles.Label
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbAsiento As Eniac.Controles.CheckBox
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents cmbExportados As Eniac.Controles.ComboBox
   Friend WithEvents lblExportados As Eniac.Controles.Label
   Friend WithEvents chbCentroCosto As Eniac.Controles.CheckBox
   Friend WithEvents cmbCentroCosto As Eniac.Controles.ComboBox
   Friend WithEvents pnlAcciones As Panel
   Friend WithEvents chkExpandAll As CheckBox
End Class
