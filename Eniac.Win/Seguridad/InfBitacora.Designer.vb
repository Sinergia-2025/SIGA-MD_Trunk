<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfBitacora
   Inherits Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfBitacora))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBitacora")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaBitacora")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFuncion")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePC")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tipo")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
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
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.bscFuncion = New Eniac.Controles.Buscador2()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.txtNombrePC = New Eniac.Controles.TextBox()
      Me.chbNombrePC = New Eniac.Controles.CheckBox()
      Me.chbFuncion = New Eniac.Controles.CheckBox()
      Me.chbDescripcion = New Eniac.Controles.CheckBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.chbTipoBitacora = New Eniac.Controles.CheckBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbTipoBitacora = New Eniac.Controles.ComboBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.tstBarra.SuspendLayout()
      Me.grbConsultar.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(938, 29)
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
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
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
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'grbConsultar
      '
      Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
      Me.grbConsultar.Controls.Add(Me.bscFuncion)
      Me.grbConsultar.Controls.Add(Me.txtDescripcion)
      Me.grbConsultar.Controls.Add(Me.txtNombrePC)
      Me.grbConsultar.Controls.Add(Me.chbNombrePC)
      Me.grbConsultar.Controls.Add(Me.chbFuncion)
      Me.grbConsultar.Controls.Add(Me.chbDescripcion)
      Me.grbConsultar.Controls.Add(Me.chkExpandAll)
      Me.grbConsultar.Controls.Add(Me.chbTipoBitacora)
      Me.grbConsultar.Controls.Add(Me.chbUsuario)
      Me.grbConsultar.Controls.Add(Me.cmbTipoBitacora)
      Me.grbConsultar.Controls.Add(Me.cmbUsuario)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Controls.Add(Me.dtpHasta)
      Me.grbConsultar.Controls.Add(Me.dtpDesde)
      Me.grbConsultar.Controls.Add(Me.lblHasta)
      Me.grbConsultar.Controls.Add(Me.lblDesde)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(914, 128)
      Me.grbConsultar.TabIndex = 0
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Filtros"
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(16, 22)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 0
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
      '
      'bscFuncion
      '
      Me.bscFuncion.ActivarFiltroEnGrilla = True
      Me.bscFuncion.AutoSize = True
      Me.bscFuncion.BindearPropiedadControl = Nothing
      Me.bscFuncion.BindearPropiedadEntidad = Nothing
      Me.bscFuncion.ColumnasCondiciones = CType(resources.GetObject("bscFuncion.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscFuncion.ColumnasVisibles = CType(resources.GetObject("bscFuncion.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscFuncion.Datos = Nothing
      Me.bscFuncion.Enabled = False
      Me.bscFuncion.FilaDevuelta = Nothing
      Me.bscFuncion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscFuncion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscFuncion.IsDecimal = False
      Me.bscFuncion.IsNumber = False
      Me.bscFuncion.IsPK = False
      Me.bscFuncion.IsRequired = False
      Me.bscFuncion.Key = ""
      Me.bscFuncion.LabelAsoc = Nothing
      Me.bscFuncion.Location = New System.Drawing.Point(96, 46)
      Me.bscFuncion.Margin = New System.Windows.Forms.Padding(4)
      Me.bscFuncion.MaxLengh = "32767"
      Me.bscFuncion.Name = "bscFuncion"
      Me.bscFuncion.Permitido = True
      Me.bscFuncion.Selecciono = False
      Me.bscFuncion.Size = New System.Drawing.Size(274, 23)
      Me.bscFuncion.TabIndex = 8
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescripcion.BindearPropiedadControl = Nothing
      Me.txtDescripcion.BindearPropiedadEntidad = Nothing
      Me.txtDescripcion.Enabled = False
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = False
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Nothing
      Me.txtDescripcion.Location = New System.Drawing.Point(491, 47)
      Me.txtDescripcion.MaxLength = 200
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(260, 20)
      Me.txtDescripcion.TabIndex = 10
      '
      'txtNombrePC
      '
      Me.txtNombrePC.BackColor = System.Drawing.SystemColors.Window
      Me.txtNombrePC.BindearPropiedadControl = Nothing
      Me.txtNombrePC.BindearPropiedadEntidad = Nothing
      Me.txtNombrePC.Enabled = False
      Me.txtNombrePC.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombrePC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombrePC.Formato = ""
      Me.txtNombrePC.IsDecimal = False
      Me.txtNombrePC.IsNumber = False
      Me.txtNombrePC.IsPK = False
      Me.txtNombrePC.IsRequired = False
      Me.txtNombrePC.Key = ""
      Me.txtNombrePC.LabelAsoc = Nothing
      Me.txtNombrePC.Location = New System.Drawing.Point(96, 76)
      Me.txtNombrePC.MaxLength = 20
      Me.txtNombrePC.Name = "txtNombrePC"
      Me.txtNombrePC.Size = New System.Drawing.Size(274, 20)
      Me.txtNombrePC.TabIndex = 12
      '
      'chbNombrePC
      '
      Me.chbNombrePC.AutoSize = True
      Me.chbNombrePC.BindearPropiedadControl = Nothing
      Me.chbNombrePC.BindearPropiedadEntidad = Nothing
      Me.chbNombrePC.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNombrePC.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNombrePC.IsPK = False
      Me.chbNombrePC.IsRequired = False
      Me.chbNombrePC.Key = Nothing
      Me.chbNombrePC.LabelAsoc = Nothing
      Me.chbNombrePC.Location = New System.Drawing.Point(16, 78)
      Me.chbNombrePC.Name = "chbNombrePC"
      Me.chbNombrePC.Size = New System.Drawing.Size(80, 17)
      Me.chbNombrePC.TabIndex = 11
      Me.chbNombrePC.Text = "Nombre PC"
      Me.chbNombrePC.UseVisualStyleBackColor = True
      '
      'chbFuncion
      '
      Me.chbFuncion.AutoSize = True
      Me.chbFuncion.BindearPropiedadControl = Nothing
      Me.chbFuncion.BindearPropiedadEntidad = Nothing
      Me.chbFuncion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFuncion.IsPK = False
      Me.chbFuncion.IsRequired = False
      Me.chbFuncion.Key = Nothing
      Me.chbFuncion.LabelAsoc = Nothing
      Me.chbFuncion.Location = New System.Drawing.Point(16, 49)
      Me.chbFuncion.Name = "chbFuncion"
      Me.chbFuncion.Size = New System.Drawing.Size(64, 17)
      Me.chbFuncion.TabIndex = 7
      Me.chbFuncion.Text = "Funcion"
      Me.chbFuncion.UseVisualStyleBackColor = True
      '
      'chbDescripcion
      '
      Me.chbDescripcion.AutoSize = True
      Me.chbDescripcion.BindearPropiedadControl = Nothing
      Me.chbDescripcion.BindearPropiedadEntidad = Nothing
      Me.chbDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDescripcion.IsPK = False
      Me.chbDescripcion.IsRequired = False
      Me.chbDescripcion.Key = Nothing
      Me.chbDescripcion.LabelAsoc = Nothing
      Me.chbDescripcion.Location = New System.Drawing.Point(403, 49)
      Me.chbDescripcion.Name = "chbDescripcion"
      Me.chbDescripcion.Size = New System.Drawing.Size(82, 17)
      Me.chbDescripcion.TabIndex = 9
      Me.chbDescripcion.Text = "Descripción"
      Me.chbDescripcion.UseVisualStyleBackColor = True
      '
      'chkExpandAll
      '
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(801, 90)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chkExpandAll.TabIndex = 16
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'chbTipoBitacora
      '
      Me.chbTipoBitacora.AutoSize = True
      Me.chbTipoBitacora.BindearPropiedadControl = Nothing
      Me.chbTipoBitacora.BindearPropiedadEntidad = Nothing
      Me.chbTipoBitacora.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoBitacora.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoBitacora.IsPK = False
      Me.chbTipoBitacora.IsRequired = False
      Me.chbTipoBitacora.Key = Nothing
      Me.chbTipoBitacora.LabelAsoc = Nothing
      Me.chbTipoBitacora.Location = New System.Drawing.Point(16, 104)
      Me.chbTipoBitacora.Name = "chbTipoBitacora"
      Me.chbTipoBitacora.Size = New System.Drawing.Size(47, 17)
      Me.chbTipoBitacora.TabIndex = 13
      Me.chbTipoBitacora.Text = "Tipo"
      Me.chbTipoBitacora.UseVisualStyleBackColor = True
      '
      'chbUsuario
      '
      Me.chbUsuario.AutoSize = True
      Me.chbUsuario.BindearPropiedadControl = Nothing
      Me.chbUsuario.BindearPropiedadEntidad = Nothing
      Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuario.IsPK = False
      Me.chbUsuario.IsRequired = False
      Me.chbUsuario.Key = Nothing
      Me.chbUsuario.LabelAsoc = Nothing
      Me.chbUsuario.Location = New System.Drawing.Point(403, 79)
      Me.chbUsuario.Name = "chbUsuario"
      Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuario.TabIndex = 13
      Me.chbUsuario.Text = "Usuario"
      Me.chbUsuario.UseVisualStyleBackColor = True
      '
      'cmbTipoBitacora
      '
      Me.cmbTipoBitacora.BindearPropiedadControl = Nothing
      Me.cmbTipoBitacora.BindearPropiedadEntidad = Nothing
      Me.cmbTipoBitacora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoBitacora.Enabled = False
      Me.cmbTipoBitacora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoBitacora.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoBitacora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoBitacora.FormattingEnabled = True
      Me.cmbTipoBitacora.IsPK = False
      Me.cmbTipoBitacora.IsRequired = False
      Me.cmbTipoBitacora.Key = Nothing
      Me.cmbTipoBitacora.LabelAsoc = Nothing
      Me.cmbTipoBitacora.Location = New System.Drawing.Point(96, 102)
      Me.cmbTipoBitacora.Name = "cmbTipoBitacora"
      Me.cmbTipoBitacora.Size = New System.Drawing.Size(190, 21)
      Me.cmbTipoBitacora.TabIndex = 14
      '
      'cmbUsuario
      '
      Me.cmbUsuario.BindearPropiedadControl = Nothing
      Me.cmbUsuario.BindearPropiedadEntidad = Nothing
      Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuario.Enabled = False
      Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuario.FormattingEnabled = True
      Me.cmbUsuario.IsPK = False
      Me.cmbUsuario.IsRequired = False
      Me.cmbUsuario.Key = Nothing
      Me.cmbUsuario.LabelAsoc = Nothing
      Me.cmbUsuario.Location = New System.Drawing.Point(491, 77)
      Me.cmbUsuario.Name = "cmbUsuario"
      Me.cmbUsuario.Size = New System.Drawing.Size(260, 21)
      Me.cmbUsuario.TabIndex = 14
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(801, 37)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(104, 45)
      Me.btnConsultar.TabIndex = 15
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(335, 20)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(294, 24)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(157, 20)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(113, 24)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 540)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(938, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(859, 17)
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
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn30.CellAppearance = Appearance2
      UltraGridColumn30.Header.VisiblePosition = 0
      UltraGridColumn30.Hidden = True
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance3
      UltraGridColumn1.Header.Caption = "ID"
      UltraGridColumn1.Header.VisiblePosition = 1
      UltraGridColumn1.Width = 46
      Appearance4.TextHAlignAsString = "Center"
      UltraGridColumn2.CellAppearance = Appearance4
      UltraGridColumn2.Format = "dd/MM/yyyy HH:mm"
      UltraGridColumn2.Header.Caption = "Fecha"
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Width = 100
      Appearance5.TextHAlignAsString = "Left"
      UltraGridColumn3.CellAppearance = Appearance5
      UltraGridColumn3.Header.Caption = "Función"
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Hidden = True
      UltraGridColumn3.Width = 175
      UltraGridColumn8.Header.Caption = "Nombre Funcion"
      UltraGridColumn8.Header.VisiblePosition = 4
      UltraGridColumn8.Width = 200
      Appearance6.TextHAlignAsString = "Left"
      UltraGridColumn4.CellAppearance = Appearance6
      UltraGridColumn4.Header.Caption = "Usuario"
      UltraGridColumn4.Header.VisiblePosition = 5
      UltraGridColumn5.Header.Caption = "Nombre de la PC"
      UltraGridColumn5.Header.VisiblePosition = 6
      UltraGridColumn5.Width = 102
      UltraGridColumn6.Header.VisiblePosition = 7
      UltraGridColumn7.Header.VisiblePosition = 8
      UltraGridColumn7.Width = 300
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn30, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn8, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance7.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance7
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance9.BackColor2 = System.Drawing.SystemColors.Control
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance10.BackColor = System.Drawing.SystemColors.Window
      Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance10
      Appearance11.BackColor = System.Drawing.SystemColors.Highlight
      Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance12
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance14.BackColor = System.Drawing.SystemColors.Control
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance14
      Appearance15.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance16.BackColor = System.Drawing.SystemColors.Window
      Appearance16.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(11, 166)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(915, 371)
      Me.ugDetalle.TabIndex = 1
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Bitacora"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance18
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
      'InfBitacora
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(938, 562)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.grbConsultar)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "InfBitacora"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Bitácora"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents chbNombrePC As Eniac.Controles.CheckBox
   Friend WithEvents chbFuncion As Eniac.Controles.CheckBox
   Friend WithEvents chbDescripcion As Eniac.Controles.CheckBox
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents txtNombrePC As Eniac.Controles.TextBox
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents bscFuncion As Eniac.Controles.Buscador2
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents chbTipoBitacora As Eniac.Controles.CheckBox
   Friend WithEvents cmbTipoBitacora As Eniac.Controles.ComboBox

End Class
