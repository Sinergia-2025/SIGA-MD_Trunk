<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadExportacion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadExportacion))
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
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.chkprocesos = New System.Windows.Forms.CheckedListBox()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.cmbFechasExportacion = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbAsientosExportados = New Eniac.Controles.ComboBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.cmbPlan = New Eniac.Controles.ComboBox()
        Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaDesde = New Eniac.Controles.Label()
        Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaHasta = New Eniac.Controles.Label()
        Me.lblFormato = New Eniac.Controles.Label()
        Me.lblFormatoEtiq = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtArchivoDestino = New Eniac.Controles.TextBox()
        Me.lblArchivoDestino = New Eniac.Controles.Label()
        Me.btnArchivo = New Eniac.Controles.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpAsientos = New System.Windows.Forms.TabPage()
        Me.ugdAsientos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CitiVentasAlicuotasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbpAsientos.SuspendLayout()
        CType(Me.ugdAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CitiVentasAlicuotasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.chkprocesos)
        Me.grbFiltros.Controls.Add(Me.chbTodos)
        Me.grbFiltros.Controls.Add(Me.cmbFechasExportacion)
        Me.grbFiltros.Controls.Add(Me.cmbAsientosExportados)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.cmbPlan)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.dtpFechaDesde)
        Me.grbFiltros.Controls.Add(Me.lblFechaDesde)
        Me.grbFiltros.Controls.Add(Me.dtpFechaHasta)
        Me.grbFiltros.Controls.Add(Me.lblFormato)
        Me.grbFiltros.Controls.Add(Me.lblFormatoEtiq)
        Me.grbFiltros.Controls.Add(Me.lblFechaHasta)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(946, 104)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'chkprocesos
        '
        Me.chkprocesos.CheckOnClick = True
        Me.chkprocesos.FormattingEnabled = True
        Me.chkprocesos.Location = New System.Drawing.Point(433, 29)
        Me.chkprocesos.MultiColumn = True
        Me.chkprocesos.Name = "chkprocesos"
        Me.chkprocesos.Size = New System.Drawing.Size(259, 64)
        Me.chkprocesos.TabIndex = 58
        '
        'chbTodos
        '
        Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(698, 69)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(136, 24)
        Me.chbTodos.TabIndex = 12
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'cmbFechasExportacion
        '
        Me.cmbFechasExportacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbFechasExportacion.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.cmbFechasExportacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFechasExportacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechasExportacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFechasExportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFechasExportacion.FormattingEnabled = True
        Me.cmbFechasExportacion.IsPK = False
        Me.cmbFechasExportacion.IsRequired = True
        Me.cmbFechasExportacion.Items.AddRange(New Object() {"NO", "SI", "TODOS"})
        Me.cmbFechasExportacion.Key = Nothing
        Me.cmbFechasExportacion.LabelAsoc = Me.Label1
        Me.cmbFechasExportacion.Location = New System.Drawing.Point(271, 72)
        Me.cmbFechasExportacion.Name = "cmbFechasExportacion"
        Me.cmbFechasExportacion.Size = New System.Drawing.Size(144, 21)
        Me.cmbFechasExportacion.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(10, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Plan de Cuenta"
        '
        'cmbAsientosExportados
        '
        Me.cmbAsientosExportados.BindearPropiedadControl = "SelectedValue"
        Me.cmbAsientosExportados.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.cmbAsientosExportados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAsientosExportados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAsientosExportados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAsientosExportados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAsientosExportados.FormattingEnabled = True
        Me.cmbAsientosExportados.IsPK = False
        Me.cmbAsientosExportados.IsRequired = True
        Me.cmbAsientosExportados.Items.AddRange(New Object() {"NO", "SI", "TODOS"})
        Me.cmbAsientosExportados.Key = Nothing
        Me.cmbAsientosExportados.LabelAsoc = Me.Label1
        Me.cmbAsientosExportados.Location = New System.Drawing.Point(156, 72)
        Me.cmbAsientosExportados.Name = "cmbAsientosExportados"
        Me.cmbAsientosExportados.Size = New System.Drawing.Size(100, 21)
        Me.cmbAsientosExportados.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(153, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Asientos Exportados"
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
        Me.cmbPlan.LabelAsoc = Me.Label1
        Me.cmbPlan.Location = New System.Drawing.Point(13, 32)
        Me.cmbPlan.Name = "cmbPlan"
        Me.cmbPlan.Size = New System.Drawing.Size(196, 21)
        Me.cmbPlan.TabIndex = 1
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.BindearPropiedadControl = ""
        Me.dtpFechaDesde.BindearPropiedadEntidad = ""
        Me.dtpFechaDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaDesde.IsPK = False
        Me.dtpFechaDesde.IsRequired = False
        Me.dtpFechaDesde.Key = ""
        Me.dtpFechaDesde.LabelAsoc = Me.lblFechaDesde
        Me.dtpFechaDesde.Location = New System.Drawing.Point(217, 32)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaDesde.TabIndex = 3
        Me.dtpFechaDesde.Value = New Date(2012, 7, 2, 23, 27, 0, 0)
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.LabelAsoc = Nothing
        Me.lblFechaDesde.Location = New System.Drawing.Point(214, 17)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(71, 13)
        Me.lblFechaDesde.TabIndex = 2
        Me.lblFechaDesde.Text = "Fecha Desde"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.BindearPropiedadControl = ""
        Me.dtpFechaHasta.BindearPropiedadEntidad = ""
        Me.dtpFechaHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHasta.IsPK = False
        Me.dtpFechaHasta.IsRequired = False
        Me.dtpFechaHasta.Key = ""
        Me.dtpFechaHasta.LabelAsoc = Me.lblFechaHasta
        Me.dtpFechaHasta.Location = New System.Drawing.Point(320, 32)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaHasta.TabIndex = 5
        Me.dtpFechaHasta.Value = New Date(2012, 7, 2, 23, 27, 0, 0)
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.LabelAsoc = Nothing
        Me.lblFechaHasta.Location = New System.Drawing.Point(317, 16)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(68, 13)
        Me.lblFechaHasta.TabIndex = 4
        Me.lblFechaHasta.Text = "Fecha Hasta"
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.LabelAsoc = Nothing
        Me.lblFormato.Location = New System.Drawing.Point(10, 76)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(68, 13)
        Me.lblFormato.TabIndex = 7
        Me.lblFormato.Text = "{FORMATO}"
        '
        'lblFormatoEtiq
        '
        Me.lblFormatoEtiq.AutoSize = True
        Me.lblFormatoEtiq.LabelAsoc = Nothing
        Me.lblFormatoEtiq.Location = New System.Drawing.Point(10, 57)
        Me.lblFormatoEtiq.Name = "lblFormatoEtiq"
        Me.lblFormatoEtiq.Size = New System.Drawing.Size(119, 13)
        Me.lblFormatoEtiq.TabIndex = 6
        Me.lblFormatoEtiq.Text = "Formato de Exportación"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.zoom_32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(840, 53)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 13
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbImprimir, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbExportar, Me.ToolStripSeparator5, Me.tsbCerrar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(974, 29)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Enabled = False
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(77, 26)
        Me.tsbExportar.Text = "&Exportar"
        Me.tsbExportar.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCerrar
        '
        Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
        Me.tsbCerrar.Text = "&Cerrar"
        Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(974, 22)
        Me.stsStado.TabIndex = 2
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
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'txtArchivoDestino
        '
        Me.txtArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtArchivoDestino.BindearPropiedadControl = ""
        Me.txtArchivoDestino.BindearPropiedadEntidad = ""
        Me.txtArchivoDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoDestino.Formato = ""
        Me.txtArchivoDestino.IsDecimal = False
        Me.txtArchivoDestino.IsNumber = False
        Me.txtArchivoDestino.IsPK = False
        Me.txtArchivoDestino.IsRequired = False
        Me.txtArchivoDestino.Key = ""
        Me.txtArchivoDestino.LabelAsoc = Me.lblArchivoDestino
        Me.txtArchivoDestino.Location = New System.Drawing.Point(105, 327)
        Me.txtArchivoDestino.Name = "txtArchivoDestino"
        Me.txtArchivoDestino.Size = New System.Drawing.Size(463, 20)
        Me.txtArchivoDestino.TabIndex = 2
        '
        'lblArchivoDestino
        '
        Me.lblArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArchivoDestino.AutoSize = True
        Me.lblArchivoDestino.LabelAsoc = Nothing
        Me.lblArchivoDestino.Location = New System.Drawing.Point(14, 331)
        Me.lblArchivoDestino.Name = "lblArchivoDestino"
        Me.lblArchivoDestino.Size = New System.Drawing.Size(85, 13)
        Me.lblArchivoDestino.TabIndex = 1
        Me.lblArchivoDestino.Text = "Archivo Destino:"
        '
        'btnArchivo
        '
        Me.btnArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArchivo.ImageKey = "folder.ico"
        Me.btnArchivo.Location = New System.Drawing.Point(586, 317)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(93, 40)
        Me.btnArchivo.TabIndex = 3
        Me.btnArchivo.Text = "&Examinar..."
        Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tbpAsientos)
        Me.TabControl1.Location = New System.Drawing.Point(12, 142)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(950, 388)
        Me.TabControl1.TabIndex = 1
        '
        'tbpAsientos
        '
        Me.tbpAsientos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpAsientos.Controls.Add(Me.ugdAsientos)
        Me.tbpAsientos.Controls.Add(Me.btnArchivo)
        Me.tbpAsientos.Controls.Add(Me.txtArchivoDestino)
        Me.tbpAsientos.Controls.Add(Me.lblArchivoDestino)
        Me.tbpAsientos.Location = New System.Drawing.Point(4, 22)
        Me.tbpAsientos.Name = "tbpAsientos"
        Me.tbpAsientos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAsientos.Size = New System.Drawing.Size(942, 362)
        Me.tbpAsientos.TabIndex = 0
        Me.tbpAsientos.Text = "Asientos"
        '
        'ugdAsientos
        '
        Me.ugdAsientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugdAsientos.DisplayLayout.Appearance = Appearance1
        Me.ugdAsientos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugdAsientos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugdAsientos.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugdAsientos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugdAsientos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugdAsientos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugdAsientos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugdAsientos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugdAsientos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugdAsientos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugdAsientos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugdAsientos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugdAsientos.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugdAsientos.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugdAsientos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugdAsientos.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugdAsientos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugdAsientos.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugdAsientos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugdAsientos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugdAsientos.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugdAsientos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugdAsientos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugdAsientos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugdAsientos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugdAsientos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdAsientos.Location = New System.Drawing.Point(9, 6)
        Me.ugdAsientos.Name = "ugdAsientos"
        Me.ugdAsientos.Size = New System.Drawing.Size(927, 307)
        Me.ugdAsientos.TabIndex = 4
        Me.ugdAsientos.Text = "UltraGrid1"
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
        Me.UltraGridPrintDocument1.Grid = Me.ugdAsientos
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance14
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
        'ContabilidadExportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 561)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ContabilidadExportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Asientos Contables"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpAsientos.ResumeLayout(False)
        Me.tbpAsientos.PerformLayout()
        CType(Me.ugdAsientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CitiVentasAlicuotasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents txtArchivoDestino As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestino As Eniac.Controles.Label
   Friend WithEvents btnArchivo As Eniac.Controles.Button
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents tbpAsientos As System.Windows.Forms.TabPage
   Friend WithEvents CitiVentasAlicuotasBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents dtpFechaDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaDesde As Eniac.Controles.Label
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaHasta As Eniac.Controles.Label
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents ugdAsientos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents lblFormato As Eniac.Controles.Label
   Friend WithEvents lblFormatoEtiq As Eniac.Controles.Label
   Friend WithEvents cmbAsientosExportados As Eniac.Controles.ComboBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents cmbFechasExportacion As Eniac.Controles.ComboBox
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents chkprocesos As System.Windows.Forms.CheckedListBox
    Friend WithEvents tsbImprimir As ToolStripButton
    Friend WithEvents tsddExportar As ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As ToolStripMenuItem
    Friend WithEvents tsmiAPDF As ToolStripMenuItem
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
   Friend WithEvents sfdExportar As SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
End Class
