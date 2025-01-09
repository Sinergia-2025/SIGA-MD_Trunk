<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InfAuditoriaParametros
    Inherits BaseForm

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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Modificado")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAuditoria")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OperacionAuditoria")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioAuditoria")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmpresa")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdParametro")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorParametro")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CategoriaParametro")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionParametro")
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfAuditoriaParametros))
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.chbTipoOperacion = New Eniac.Controles.CheckBox()
        Me.cmbTipoOperacion = New Eniac.Controles.ComboBox()
        Me.txtIdEmpresa = New Eniac.Controles.TextBox()
        Me.lblEmpresa = New Eniac.Controles.Label()
        Me.bscCodigo = New Eniac.Controles.Buscador2()
        Me.lblCodigoParametro = New Eniac.Controles.Label()
        Me.bscParametro = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbParametro = New Eniac.Controles.CheckBox()
        Me.chbMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 30
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn71.Header.VisiblePosition = 4
        UltraGridColumn72.Header.VisiblePosition = 5
        UltraGridColumn73.Header.VisiblePosition = 6
        UltraGridColumn74.Header.VisiblePosition = 7
        UltraGridColumn75.Header.VisiblePosition = 8
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
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
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(12, 157)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(965, 402)
        Me.ugDetalle.TabIndex = 6
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 8
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.chbTipoOperacion)
        Me.grbConsultar.Controls.Add(Me.cmbTipoOperacion)
        Me.grbConsultar.Controls.Add(Me.txtIdEmpresa)
        Me.grbConsultar.Controls.Add(Me.lblEmpresa)
        Me.grbConsultar.Controls.Add(Me.bscCodigo)
        Me.grbConsultar.Controls.Add(Me.bscParametro)
        Me.grbConsultar.Controls.Add(Me.chkExpandAll)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Controls.Add(Me.lblCodigoParametro)
        Me.grbConsultar.Controls.Add(Me.lblNombre)
        Me.grbConsultar.Controls.Add(Me.chbParametro)
        Me.grbConsultar.Controls.Add(Me.chbMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Location = New System.Drawing.Point(9, 32)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(963, 119)
        Me.grbConsultar.TabIndex = 5
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Filtros"
        '
        'chbTipoOperacion
        '
        Me.chbTipoOperacion.AutoSize = True
        Me.chbTipoOperacion.BindearPropiedadControl = Nothing
        Me.chbTipoOperacion.BindearPropiedadEntidad = Nothing
        Me.chbTipoOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoOperacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoOperacion.IsPK = False
        Me.chbTipoOperacion.IsRequired = False
        Me.chbTipoOperacion.Key = Nothing
        Me.chbTipoOperacion.LabelAsoc = Nothing
        Me.chbTipoOperacion.Location = New System.Drawing.Point(356, 90)
        Me.chbTipoOperacion.Name = "chbTipoOperacion"
        Me.chbTipoOperacion.Size = New System.Drawing.Size(114, 17)
        Me.chbTipoOperacion.TabIndex = 18
        Me.chbTipoOperacion.Text = "Tipo de Operación"
        Me.chbTipoOperacion.UseVisualStyleBackColor = True
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoOperacion.BindearPropiedadEntidad = "EstadoCliente.IdEstadoCliente"
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.Enabled = False
        Me.cmbTipoOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.IsPK = False
        Me.cmbTipoOperacion.IsRequired = True
        Me.cmbTipoOperacion.Key = Nothing
        Me.cmbTipoOperacion.LabelAsoc = Nothing
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(476, 88)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(142, 21)
        Me.cmbTipoOperacion.TabIndex = 19
        '
        'txtIdEmpresa
        '
        Me.txtIdEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIdEmpresa.BindearPropiedadControl = "Text"
        Me.txtIdEmpresa.BindearPropiedadEntidad = "IdSubTipoUnidad"
        Me.txtIdEmpresa.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdEmpresa.Formato = ""
        Me.txtIdEmpresa.IsDecimal = False
        Me.txtIdEmpresa.IsNumber = True
        Me.txtIdEmpresa.IsPK = True
        Me.txtIdEmpresa.IsRequired = True
        Me.txtIdEmpresa.Key = ""
        Me.txtIdEmpresa.LabelAsoc = Me.lblEmpresa
        Me.txtIdEmpresa.Location = New System.Drawing.Point(153, 88)
        Me.txtIdEmpresa.MaxLength = 4
        Me.txtIdEmpresa.Name = "txtIdEmpresa"
        Me.txtIdEmpresa.Size = New System.Drawing.Size(46, 20)
        Me.txtIdEmpresa.TabIndex = 17
        Me.txtIdEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.LabelAsoc = Nothing
        Me.lblEmpresa.Location = New System.Drawing.Point(84, 91)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(63, 13)
        Me.lblEmpresa.TabIndex = 16
        Me.lblEmpresa.Text = "N° Empresa"
        '
        'bscCodigo
        '
        Me.bscCodigo.ActivarFiltroEnGrilla = True
        Me.bscCodigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigo.BindearPropiedadControl = ""
        Me.bscCodigo.BindearPropiedadEntidad = ""
        Me.bscCodigo.ConfigBuscador = Nothing
        Me.bscCodigo.Datos = Nothing
        Me.bscCodigo.Enabled = False
        Me.bscCodigo.FilaDevuelta = Nothing
        Me.bscCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigo.IsDecimal = False
        Me.bscCodigo.IsNumber = True
        Me.bscCodigo.IsPK = False
        Me.bscCodigo.IsRequired = True
        Me.bscCodigo.Key = ""
        Me.bscCodigo.LabelAsoc = Me.lblCodigoParametro
        Me.bscCodigo.Location = New System.Drawing.Point(87, 60)
        Me.bscCodigo.MaxLengh = "32767"
        Me.bscCodigo.Name = "bscCodigo"
        Me.bscCodigo.Permitido = True
        Me.bscCodigo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigo.Selecciono = False
        Me.bscCodigo.Size = New System.Drawing.Size(263, 20)
        Me.bscCodigo.TabIndex = 14
        '
        'lblCodigoParametro
        '
        Me.lblCodigoParametro.AutoSize = True
        Me.lblCodigoParametro.LabelAsoc = Nothing
        Me.lblCodigoParametro.Location = New System.Drawing.Point(85, 46)
        Me.lblCodigoParametro.Name = "lblCodigoParametro"
        Me.lblCodigoParametro.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoParametro.TabIndex = 6
        Me.lblCodigoParametro.Text = "Código"
        '
        'bscParametro
        '
        Me.bscParametro.ActivarFiltroEnGrilla = True
        Me.bscParametro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscParametro.BindearPropiedadControl = ""
        Me.bscParametro.BindearPropiedadEntidad = ""
        Me.bscParametro.ConfigBuscador = Nothing
        Me.bscParametro.Datos = Nothing
        Me.bscParametro.Enabled = False
        Me.bscParametro.FilaDevuelta = Nothing
        Me.bscParametro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscParametro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscParametro.IsDecimal = False
        Me.bscParametro.IsNumber = False
        Me.bscParametro.IsPK = False
        Me.bscParametro.IsRequired = True
        Me.bscParametro.Key = ""
        Me.bscParametro.LabelAsoc = Me.lblNombre
        Me.bscParametro.Location = New System.Drawing.Point(356, 60)
        Me.bscParametro.MaxLengh = "32767"
        Me.bscParametro.Name = "bscParametro"
        Me.bscParametro.Permitido = True
        Me.bscParametro.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscParametro.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscParametro.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscParametro.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscParametro.Selecciono = False
        Me.bscParametro.Size = New System.Drawing.Size(335, 20)
        Me.bscParametro.TabIndex = 15
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(354, 46)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 8
        Me.lblNombre.Text = "Nombre"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(818, 69)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 13
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(818, 21)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 12
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbParametro
        '
        Me.chbParametro.AutoSize = True
        Me.chbParametro.BindearPropiedadControl = Nothing
        Me.chbParametro.BindearPropiedadEntidad = Nothing
        Me.chbParametro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbParametro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbParametro.IsPK = False
        Me.chbParametro.IsRequired = False
        Me.chbParametro.Key = Nothing
        Me.chbParametro.LabelAsoc = Nothing
        Me.chbParametro.Location = New System.Drawing.Point(13, 62)
        Me.chbParametro.Name = "chbParametro"
        Me.chbParametro.Size = New System.Drawing.Size(74, 17)
        Me.chbParametro.TabIndex = 5
        Me.chbParametro.Text = "Parametro"
        Me.chbParametro.UseVisualStyleBackColor = True
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
        Me.chbMesCompleto.Location = New System.Drawing.Point(13, 24)
        Me.chbMesCompleto.Name = "chbMesCompleto"
        Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chbMesCompleto.TabIndex = 0
        Me.chbMesCompleto.Text = "Mes Completo"
        Me.chbMesCompleto.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(344, 21)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 3
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(305, 25)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
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
        Me.dtpDesde.Location = New System.Drawing.Point(160, 22)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 1
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(118, 26)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 2
        Me.lblDesde.Text = "Desde"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
        Me.tssInfo.Spring = True
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
        Me.stsStado.Location = New System.Drawing.Point(0, 562)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 7
        Me.stsStado.Text = "statusStrip1"
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'InfAuditoriaParametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 584)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.stsStado)
        Me.Name = "InfAuditoriaParametros"
        Me.Text = "InfAuditoriaParametros"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected Friend WithEvents ugDetalle As UltraGrid
    Public WithEvents tstBarra As ToolStrip
    Public WithEvents tsbRefrescar As ToolStripButton
    Private WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbImprimir As ToolStripButton
    Private WithEvents toolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsddExportar As ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As ToolStripMenuItem
    Friend WithEvents tsmiAPDF As ToolStripMenuItem
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents tsbPreferencias As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Public WithEvents tsbSalir As ToolStripButton
    Friend WithEvents grbConsultar As GroupBox
    Friend WithEvents chkExpandAll As CheckBox
    Friend WithEvents btnConsultar As Controles.Button
    Friend WithEvents lblCodigoParametro As Controles.Label
    Friend WithEvents lblNombre As Controles.Label
    Friend WithEvents chbParametro As Controles.CheckBox
    Friend WithEvents chbMesCompleto As Controles.CheckBox
    Friend WithEvents dtpHasta As Controles.DateTimePicker
    Friend WithEvents lblHasta As Controles.Label
    Friend WithEvents dtpDesde As Controles.DateTimePicker
    Friend WithEvents lblDesde As Controles.Label
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tspBarra As ToolStripProgressBar
    Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
    Friend WithEvents sfdExportar As SaveFileDialog
    Friend WithEvents bscCodigo As Controles.Buscador2
    Friend WithEvents bscParametro As Controles.Buscador2
    Friend WithEvents txtIdEmpresa As Controles.TextBox
    Friend WithEvents lblEmpresa As Controles.Label
    Friend WithEvents chbTipoOperacion As Controles.CheckBox
    Friend WithEvents cmbTipoOperacion As Controles.ComboBox
End Class
