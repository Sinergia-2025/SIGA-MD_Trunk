<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesActualizacionesDetalle
   Inherits BaseForm

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoSuceso")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoSucesoValue")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Datos")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mensaje")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreScript")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Script")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VerScript", 0)
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CopiarScript", 1)
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
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesActualizacionesDetalle))
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tssDesactivar = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbDesactivar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.grpEjecucion = New System.Windows.Forms.GroupBox()
      Me.txtActivo = New Eniac.Controles.TextBox()
      Me.lblBaseDatos = New Eniac.Controles.Label()
      Me.lblCliente = New Eniac.Controles.Label()
      Me.lblEjecucionInstalador = New Eniac.Controles.Label()
      Me.txtEjecucionInstalador = New Eniac.Controles.TextBox()
      Me.lblEjecucionScripts = New Eniac.Controles.Label()
      Me.txtEjecucionScripts = New Eniac.Controles.TextBox()
      Me.lblBackup = New Eniac.Controles.Label()
      Me.txtBackup = New Eniac.Controles.TextBox()
      Me.lblDescargaInstalador = New Eniac.Controles.Label()
      Me.txtDescargaInstalador = New Eniac.Controles.TextBox()
      Me.lblDescargaScripts = New Eniac.Controles.Label()
      Me.txtDescargaScripts = New Eniac.Controles.TextBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.txtEstado = New Eniac.Controles.TextBox()
      Me.lblIdUnico = New Eniac.Controles.Label()
      Me.txtIdUnico = New Eniac.Controles.TextBox()
      Me.dtpFechaEjecución = New Eniac.Controles.DateTimePicker()
      Me.lblFechaEjecucion = New Eniac.Controles.Label()
      Me.txtBaseDatos = New Eniac.Controles.TextBox()
      Me.lblNombreServidor = New Eniac.Controles.Label()
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.txtNombreServidor = New Eniac.Controles.TextBox()
      Me.txtNombreCliente = New Eniac.Controles.TextBox()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.txtCodigoCliente = New Eniac.Controles.TextBox()
      Me.dtpFechaFinActualizacion = New Eniac.Controles.DateTimePicker()
      Me.lblFechaFinActualizacion = New Eniac.Controles.Label()
      Me.dtpFechaInicioActualizacion = New Eniac.Controles.DateTimePicker()
      Me.lblFechaInicioActualizacion = New Eniac.Controles.Label()
      Me.stsStado.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.grpEjecucion.SuspendLayout()
      Me.SuspendLayout()
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 480)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(896, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(817, 17)
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
      UltraGridColumn1.Header.Caption = "Tipo"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 213
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance2
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 53
      UltraGridColumn3.Header.Caption = "Valor del Tipo"
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Hidden = True
      UltraGridColumn4.Header.VisiblePosition = 7
      UltraGridColumn4.Hidden = True
      UltraGridColumn4.Width = 492
      Appearance3.FontData.BoldAsString = "True"
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn5.CellAppearance = Appearance3
      UltraGridColumn5.Header.VisiblePosition = 2
      UltraGridColumn5.Width = 80
      UltraGridColumn6.Header.VisiblePosition = 4
      UltraGridColumn6.Width = 332
      UltraGridColumn7.Header.Caption = "Nombre Script"
      UltraGridColumn7.Header.VisiblePosition = 5
      UltraGridColumn7.Width = 149
      UltraGridColumn8.Header.VisiblePosition = 6
      UltraGridColumn8.Hidden = True
      UltraGridColumn8.Width = 47
      UltraGridColumn9.Header.Caption = "Ver"
      UltraGridColumn9.Header.VisiblePosition = 8
      UltraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
      UltraGridColumn9.Width = 45
      UltraGridColumn10.Header.Caption = "Copiar"
      UltraGridColumn10.Header.VisiblePosition = 9
      UltraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
      UltraGridColumn10.Width = 45
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance4.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance4
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance6.BackColor2 = System.Drawing.SystemColors.Control
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance7
      Appearance8.BackColor = System.Drawing.SystemColors.Highlight
      Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance9
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance11.BackColor = System.Drawing.SystemColors.Control
      Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance11
      Appearance12.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 166)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(868, 311)
      Me.ugDetalle.TabIndex = 1
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tssDesactivar, Me.tsbDesactivar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(896, 29)
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
      'tssDesactivar
      '
      Me.tssDesactivar.Name = "tssDesactivar"
      Me.tssDesactivar.Size = New System.Drawing.Size(6, 29)
      '
      'tsbDesactivar
      '
      Me.tsbDesactivar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.tsbDesactivar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbDesactivar.Name = "tsbDesactivar"
      Me.tsbDesactivar.Size = New System.Drawing.Size(151, 26)
      Me.tsbDesactivar.Text = "Marcar como revisado"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.FitWidthToPages = 1
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance15
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
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'grpEjecucion
      '
      Me.grpEjecucion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpEjecucion.Controls.Add(Me.txtActivo)
      Me.grpEjecucion.Controls.Add(Me.lblEjecucionInstalador)
      Me.grpEjecucion.Controls.Add(Me.txtEjecucionInstalador)
      Me.grpEjecucion.Controls.Add(Me.lblEjecucionScripts)
      Me.grpEjecucion.Controls.Add(Me.txtEjecucionScripts)
      Me.grpEjecucion.Controls.Add(Me.lblBackup)
      Me.grpEjecucion.Controls.Add(Me.txtBackup)
      Me.grpEjecucion.Controls.Add(Me.lblDescargaInstalador)
      Me.grpEjecucion.Controls.Add(Me.txtDescargaInstalador)
      Me.grpEjecucion.Controls.Add(Me.lblDescargaScripts)
      Me.grpEjecucion.Controls.Add(Me.txtDescargaScripts)
      Me.grpEjecucion.Controls.Add(Me.lblEstado)
      Me.grpEjecucion.Controls.Add(Me.txtEstado)
      Me.grpEjecucion.Controls.Add(Me.lblIdUnico)
      Me.grpEjecucion.Controls.Add(Me.txtIdUnico)
      Me.grpEjecucion.Controls.Add(Me.dtpFechaEjecución)
      Me.grpEjecucion.Controls.Add(Me.lblFechaEjecucion)
      Me.grpEjecucion.Controls.Add(Me.lblBaseDatos)
      Me.grpEjecucion.Controls.Add(Me.txtBaseDatos)
      Me.grpEjecucion.Controls.Add(Me.lblNombreServidor)
      Me.grpEjecucion.Controls.Add(Me.lblCliente)
      Me.grpEjecucion.Controls.Add(Me.lblNombreCliente)
      Me.grpEjecucion.Controls.Add(Me.txtNombreServidor)
      Me.grpEjecucion.Controls.Add(Me.txtNombreCliente)
      Me.grpEjecucion.Controls.Add(Me.lblCodigoCliente)
      Me.grpEjecucion.Controls.Add(Me.txtCodigoCliente)
      Me.grpEjecucion.Controls.Add(Me.dtpFechaFinActualizacion)
      Me.grpEjecucion.Controls.Add(Me.dtpFechaInicioActualizacion)
      Me.grpEjecucion.Controls.Add(Me.lblFechaFinActualizacion)
      Me.grpEjecucion.Controls.Add(Me.lblFechaInicioActualizacion)
      Me.grpEjecucion.Location = New System.Drawing.Point(12, 32)
      Me.grpEjecucion.Name = "grpEjecucion"
      Me.grpEjecucion.Size = New System.Drawing.Size(868, 128)
      Me.grpEjecucion.TabIndex = 0
      Me.grpEjecucion.TabStop = False
      Me.grpEjecucion.Text = "Ejecución"
      '
      'txtActivo
      '
      Me.txtActivo.BindearPropiedadControl = Nothing
      Me.txtActivo.BindearPropiedadEntidad = Nothing
      Me.txtActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtActivo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtActivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtActivo.Formato = "##0"
      Me.txtActivo.IsDecimal = False
      Me.txtActivo.IsNumber = False
      Me.txtActivo.IsPK = False
      Me.txtActivo.IsRequired = False
      Me.txtActivo.Key = ""
      Me.txtActivo.LabelAsoc = Me.lblBaseDatos
      Me.txtActivo.Location = New System.Drawing.Point(743, 58)
      Me.txtActivo.MaxLength = 8
      Me.txtActivo.Name = "txtActivo"
      Me.txtActivo.ReadOnly = True
      Me.txtActivo.Size = New System.Drawing.Size(70, 20)
      Me.txtActivo.TabIndex = 30
      Me.txtActivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblBaseDatos
      '
      Me.lblBaseDatos.AutoSize = True
      Me.lblBaseDatos.LabelAsoc = Me.lblCliente
      Me.lblBaseDatos.Location = New System.Drawing.Point(560, 16)
      Me.lblBaseDatos.Name = "lblBaseDatos"
      Me.lblBaseDatos.Size = New System.Drawing.Size(77, 13)
      Me.lblBaseDatos.TabIndex = 7
      Me.lblBaseDatos.Text = "Base de Datos"
      '
      'lblCliente
      '
      Me.lblCliente.AutoSize = True
      Me.lblCliente.LabelAsoc = Nothing
      Me.lblCliente.Location = New System.Drawing.Point(18, 36)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(39, 13)
      Me.lblCliente.TabIndex = 0
      Me.lblCliente.Text = "Cliente"
      '
      'lblEjecucionInstalador
      '
      Me.lblEjecucionInstalador.AutoSize = True
      Me.lblEjecucionInstalador.LabelAsoc = Nothing
      Me.lblEjecucionInstalador.Location = New System.Drawing.Point(690, 84)
      Me.lblEjecucionInstalador.Name = "lblEjecucionInstalador"
      Me.lblEjecucionInstalador.Size = New System.Drawing.Size(103, 13)
      Me.lblEjecucionInstalador.TabIndex = 28
      Me.lblEjecucionInstalador.Text = "Ejecución Instalador"
      '
      'txtEjecucionInstalador
      '
      Me.txtEjecucionInstalador.BindearPropiedadControl = Nothing
      Me.txtEjecucionInstalador.BindearPropiedadEntidad = Nothing
      Me.txtEjecucionInstalador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEjecucionInstalador.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEjecucionInstalador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEjecucionInstalador.Formato = "##0"
      Me.txtEjecucionInstalador.IsDecimal = False
      Me.txtEjecucionInstalador.IsNumber = True
      Me.txtEjecucionInstalador.IsPK = False
      Me.txtEjecucionInstalador.IsRequired = False
      Me.txtEjecucionInstalador.Key = ""
      Me.txtEjecucionInstalador.LabelAsoc = Me.lblEjecucionInstalador
      Me.txtEjecucionInstalador.Location = New System.Drawing.Point(693, 100)
      Me.txtEjecucionInstalador.MaxLength = 8
      Me.txtEjecucionInstalador.Name = "txtEjecucionInstalador"
      Me.txtEjecucionInstalador.ReadOnly = True
      Me.txtEjecucionInstalador.Size = New System.Drawing.Size(120, 20)
      Me.txtEjecucionInstalador.TabIndex = 29
      Me.txtEjecucionInstalador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblEjecucionScripts
      '
      Me.lblEjecucionScripts.AutoSize = True
      Me.lblEjecucionScripts.LabelAsoc = Nothing
      Me.lblEjecucionScripts.Location = New System.Drawing.Point(564, 84)
      Me.lblEjecucionScripts.Name = "lblEjecucionScripts"
      Me.lblEjecucionScripts.Size = New System.Drawing.Size(89, 13)
      Me.lblEjecucionScripts.TabIndex = 26
      Me.lblEjecucionScripts.Text = "Ejecución Scripts"
      '
      'txtEjecucionScripts
      '
      Me.txtEjecucionScripts.BindearPropiedadControl = Nothing
      Me.txtEjecucionScripts.BindearPropiedadEntidad = Nothing
      Me.txtEjecucionScripts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEjecucionScripts.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEjecucionScripts.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEjecucionScripts.Formato = "##0"
      Me.txtEjecucionScripts.IsDecimal = False
      Me.txtEjecucionScripts.IsNumber = True
      Me.txtEjecucionScripts.IsPK = False
      Me.txtEjecucionScripts.IsRequired = False
      Me.txtEjecucionScripts.Key = ""
      Me.txtEjecucionScripts.LabelAsoc = Me.lblEjecucionScripts
      Me.txtEjecucionScripts.Location = New System.Drawing.Point(567, 100)
      Me.txtEjecucionScripts.MaxLength = 8
      Me.txtEjecucionScripts.Name = "txtEjecucionScripts"
      Me.txtEjecucionScripts.ReadOnly = True
      Me.txtEjecucionScripts.Size = New System.Drawing.Size(120, 20)
      Me.txtEjecucionScripts.TabIndex = 27
      Me.txtEjecucionScripts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblBackup
      '
      Me.lblBackup.AutoSize = True
      Me.lblBackup.LabelAsoc = Nothing
      Me.lblBackup.Location = New System.Drawing.Point(438, 84)
      Me.lblBackup.Name = "lblBackup"
      Me.lblBackup.Size = New System.Drawing.Size(44, 13)
      Me.lblBackup.TabIndex = 24
      Me.lblBackup.Text = "Backup"
      '
      'txtBackup
      '
      Me.txtBackup.BindearPropiedadControl = Nothing
      Me.txtBackup.BindearPropiedadEntidad = Nothing
      Me.txtBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBackup.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBackup.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBackup.Formato = "##0"
      Me.txtBackup.IsDecimal = False
      Me.txtBackup.IsNumber = True
      Me.txtBackup.IsPK = False
      Me.txtBackup.IsRequired = False
      Me.txtBackup.Key = ""
      Me.txtBackup.LabelAsoc = Me.lblBackup
      Me.txtBackup.Location = New System.Drawing.Point(441, 100)
      Me.txtBackup.MaxLength = 8
      Me.txtBackup.Name = "txtBackup"
      Me.txtBackup.ReadOnly = True
      Me.txtBackup.Size = New System.Drawing.Size(120, 20)
      Me.txtBackup.TabIndex = 25
      Me.txtBackup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblDescargaInstalador
      '
      Me.lblDescargaInstalador.AutoSize = True
      Me.lblDescargaInstalador.LabelAsoc = Nothing
      Me.lblDescargaInstalador.Location = New System.Drawing.Point(312, 84)
      Me.lblDescargaInstalador.Name = "lblDescargaInstalador"
      Me.lblDescargaInstalador.Size = New System.Drawing.Size(102, 13)
      Me.lblDescargaInstalador.TabIndex = 22
      Me.lblDescargaInstalador.Text = "Descarga Instalador"
      '
      'txtDescargaInstalador
      '
      Me.txtDescargaInstalador.BindearPropiedadControl = Nothing
      Me.txtDescargaInstalador.BindearPropiedadEntidad = Nothing
      Me.txtDescargaInstalador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescargaInstalador.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescargaInstalador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescargaInstalador.Formato = "##0"
      Me.txtDescargaInstalador.IsDecimal = False
      Me.txtDescargaInstalador.IsNumber = True
      Me.txtDescargaInstalador.IsPK = False
      Me.txtDescargaInstalador.IsRequired = False
      Me.txtDescargaInstalador.Key = ""
      Me.txtDescargaInstalador.LabelAsoc = Me.lblDescargaInstalador
      Me.txtDescargaInstalador.Location = New System.Drawing.Point(315, 100)
      Me.txtDescargaInstalador.MaxLength = 8
      Me.txtDescargaInstalador.Name = "txtDescargaInstalador"
      Me.txtDescargaInstalador.ReadOnly = True
      Me.txtDescargaInstalador.Size = New System.Drawing.Size(120, 20)
      Me.txtDescargaInstalador.TabIndex = 23
      Me.txtDescargaInstalador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblDescargaScripts
      '
      Me.lblDescargaScripts.AutoSize = True
      Me.lblDescargaScripts.LabelAsoc = Nothing
      Me.lblDescargaScripts.Location = New System.Drawing.Point(187, 84)
      Me.lblDescargaScripts.Name = "lblDescargaScripts"
      Me.lblDescargaScripts.Size = New System.Drawing.Size(88, 13)
      Me.lblDescargaScripts.TabIndex = 20
      Me.lblDescargaScripts.Text = "Descarga Scripts"
      '
      'txtDescargaScripts
      '
      Me.txtDescargaScripts.BindearPropiedadControl = Nothing
      Me.txtDescargaScripts.BindearPropiedadEntidad = Nothing
      Me.txtDescargaScripts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescargaScripts.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescargaScripts.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescargaScripts.Formato = "##0"
      Me.txtDescargaScripts.IsDecimal = False
      Me.txtDescargaScripts.IsNumber = True
      Me.txtDescargaScripts.IsPK = False
      Me.txtDescargaScripts.IsRequired = False
      Me.txtDescargaScripts.Key = ""
      Me.txtDescargaScripts.LabelAsoc = Me.lblDescargaScripts
      Me.txtDescargaScripts.Location = New System.Drawing.Point(190, 100)
      Me.txtDescargaScripts.MaxLength = 8
      Me.txtDescargaScripts.Name = "txtDescargaScripts"
      Me.txtDescargaScripts.ReadOnly = True
      Me.txtDescargaScripts.Size = New System.Drawing.Size(120, 20)
      Me.txtDescargaScripts.TabIndex = 21
      Me.txtDescargaScripts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(61, 84)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 18
      Me.lblEstado.Text = "Estado"
      '
      'txtEstado
      '
      Me.txtEstado.BindearPropiedadControl = Nothing
      Me.txtEstado.BindearPropiedadEntidad = Nothing
      Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEstado.Formato = "##0"
      Me.txtEstado.IsDecimal = False
      Me.txtEstado.IsNumber = True
      Me.txtEstado.IsPK = False
      Me.txtEstado.IsRequired = False
      Me.txtEstado.Key = ""
      Me.txtEstado.LabelAsoc = Me.lblEstado
      Me.txtEstado.Location = New System.Drawing.Point(64, 100)
      Me.txtEstado.MaxLength = 8
      Me.txtEstado.Name = "txtEstado"
      Me.txtEstado.ReadOnly = True
      Me.txtEstado.Size = New System.Drawing.Size(120, 20)
      Me.txtEstado.TabIndex = 19
      Me.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblIdUnico
      '
      Me.lblIdUnico.AutoSize = True
      Me.lblIdUnico.LabelAsoc = Me.lblCliente
      Me.lblIdUnico.Location = New System.Drawing.Point(443, 62)
      Me.lblIdUnico.Name = "lblIdUnico"
      Me.lblIdUnico.Size = New System.Drawing.Size(47, 13)
      Me.lblIdUnico.TabIndex = 15
      Me.lblIdUnico.Text = "Id Único"
      '
      'txtIdUnico
      '
      Me.txtIdUnico.BindearPropiedadControl = Nothing
      Me.txtIdUnico.BindearPropiedadEntidad = Nothing
      Me.txtIdUnico.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdUnico.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdUnico.Formato = "##0"
      Me.txtIdUnico.IsDecimal = False
      Me.txtIdUnico.IsNumber = False
      Me.txtIdUnico.IsPK = False
      Me.txtIdUnico.IsRequired = False
      Me.txtIdUnico.Key = ""
      Me.txtIdUnico.LabelAsoc = Me.lblIdUnico
      Me.txtIdUnico.Location = New System.Drawing.Point(496, 58)
      Me.txtIdUnico.MaxLength = 8
      Me.txtIdUnico.Name = "txtIdUnico"
      Me.txtIdUnico.ReadOnly = True
      Me.txtIdUnico.Size = New System.Drawing.Size(241, 20)
      Me.txtIdUnico.TabIndex = 16
      '
      'dtpFechaEjecución
      '
      Me.dtpFechaEjecución.BindearPropiedadControl = Nothing
      Me.dtpFechaEjecución.BindearPropiedadEntidad = Nothing
      Me.dtpFechaEjecución.CustomFormat = "dd/MM/yyyy HH:mm:ss"
      Me.dtpFechaEjecución.Enabled = False
      Me.dtpFechaEjecución.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaEjecución.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaEjecución.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaEjecución.IsPK = False
      Me.dtpFechaEjecución.IsRequired = False
      Me.dtpFechaEjecución.Key = ""
      Me.dtpFechaEjecución.LabelAsoc = Me.lblFechaEjecucion
      Me.dtpFechaEjecución.Location = New System.Drawing.Point(669, 32)
      Me.dtpFechaEjecución.Name = "dtpFechaEjecución"
      Me.dtpFechaEjecución.Size = New System.Drawing.Size(144, 20)
      Me.dtpFechaEjecución.TabIndex = 10
      '
      'lblFechaEjecucion
      '
      Me.lblFechaEjecucion.AutoSize = True
      Me.lblFechaEjecucion.LabelAsoc = Nothing
      Me.lblFechaEjecucion.Location = New System.Drawing.Point(666, 16)
      Me.lblFechaEjecucion.Name = "lblFechaEjecucion"
      Me.lblFechaEjecucion.Size = New System.Drawing.Size(83, 13)
      Me.lblFechaEjecucion.TabIndex = 9
      Me.lblFechaEjecucion.Text = "Fecha Ejecición"
      '
      'txtBaseDatos
      '
      Me.txtBaseDatos.BindearPropiedadControl = Nothing
      Me.txtBaseDatos.BindearPropiedadEntidad = Nothing
      Me.txtBaseDatos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBaseDatos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBaseDatos.Formato = "##0"
      Me.txtBaseDatos.IsDecimal = False
      Me.txtBaseDatos.IsNumber = False
      Me.txtBaseDatos.IsPK = False
      Me.txtBaseDatos.IsRequired = False
      Me.txtBaseDatos.Key = ""
      Me.txtBaseDatos.LabelAsoc = Me.lblBaseDatos
      Me.txtBaseDatos.Location = New System.Drawing.Point(555, 32)
      Me.txtBaseDatos.MaxLength = 8
      Me.txtBaseDatos.Name = "txtBaseDatos"
      Me.txtBaseDatos.ReadOnly = True
      Me.txtBaseDatos.Size = New System.Drawing.Size(108, 20)
      Me.txtBaseDatos.TabIndex = 8
      '
      'lblNombreServidor
      '
      Me.lblNombreServidor.AutoSize = True
      Me.lblNombreServidor.LabelAsoc = Me.lblCliente
      Me.lblNombreServidor.Location = New System.Drawing.Point(438, 16)
      Me.lblNombreServidor.Name = "lblNombreServidor"
      Me.lblNombreServidor.Size = New System.Drawing.Size(46, 13)
      Me.lblNombreServidor.TabIndex = 5
      Me.lblNombreServidor.Text = "Servidor"
      '
      'lblNombreCliente
      '
      Me.lblNombreCliente.AutoSize = True
      Me.lblNombreCliente.LabelAsoc = Me.lblCliente
      Me.lblNombreCliente.Location = New System.Drawing.Point(126, 16)
      Me.lblNombreCliente.Name = "lblNombreCliente"
      Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCliente.TabIndex = 3
      Me.lblNombreCliente.Text = "Nombre"
      '
      'txtNombreServidor
      '
      Me.txtNombreServidor.BindearPropiedadControl = Nothing
      Me.txtNombreServidor.BindearPropiedadEntidad = Nothing
      Me.txtNombreServidor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreServidor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreServidor.Formato = "##0"
      Me.txtNombreServidor.IsDecimal = False
      Me.txtNombreServidor.IsNumber = False
      Me.txtNombreServidor.IsPK = False
      Me.txtNombreServidor.IsRequired = False
      Me.txtNombreServidor.Key = ""
      Me.txtNombreServidor.LabelAsoc = Me.lblNombreServidor
      Me.txtNombreServidor.Location = New System.Drawing.Point(441, 32)
      Me.txtNombreServidor.MaxLength = 8
      Me.txtNombreServidor.Name = "txtNombreServidor"
      Me.txtNombreServidor.ReadOnly = True
      Me.txtNombreServidor.Size = New System.Drawing.Size(108, 20)
      Me.txtNombreServidor.TabIndex = 6
      '
      'txtNombreCliente
      '
      Me.txtNombreCliente.BindearPropiedadControl = Nothing
      Me.txtNombreCliente.BindearPropiedadEntidad = Nothing
      Me.txtNombreCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCliente.Formato = "##0"
      Me.txtNombreCliente.IsDecimal = False
      Me.txtNombreCliente.IsNumber = False
      Me.txtNombreCliente.IsPK = False
      Me.txtNombreCliente.IsRequired = False
      Me.txtNombreCliente.Key = ""
      Me.txtNombreCliente.LabelAsoc = Me.lblNombreCliente
      Me.txtNombreCliente.Location = New System.Drawing.Point(129, 32)
      Me.txtNombreCliente.MaxLength = 8
      Me.txtNombreCliente.Name = "txtNombreCliente"
      Me.txtNombreCliente.ReadOnly = True
      Me.txtNombreCliente.Size = New System.Drawing.Size(306, 20)
      Me.txtNombreCliente.TabIndex = 4
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Me.lblCliente
      Me.lblCodigoCliente.Location = New System.Drawing.Point(61, 16)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 1
      Me.lblCodigoCliente.Text = "Código"
      '
      'txtCodigoCliente
      '
      Me.txtCodigoCliente.BindearPropiedadControl = Nothing
      Me.txtCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.txtCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigoCliente.Formato = "##0"
      Me.txtCodigoCliente.IsDecimal = False
      Me.txtCodigoCliente.IsNumber = True
      Me.txtCodigoCliente.IsPK = False
      Me.txtCodigoCliente.IsRequired = False
      Me.txtCodigoCliente.Key = ""
      Me.txtCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.txtCodigoCliente.Location = New System.Drawing.Point(64, 32)
      Me.txtCodigoCliente.MaxLength = 8
      Me.txtCodigoCliente.Name = "txtCodigoCliente"
      Me.txtCodigoCliente.ReadOnly = True
      Me.txtCodigoCliente.Size = New System.Drawing.Size(59, 20)
      Me.txtCodigoCliente.TabIndex = 2
      Me.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpFechaFinActualizacion
      '
      Me.dtpFechaFinActualizacion.BindearPropiedadControl = Nothing
      Me.dtpFechaFinActualizacion.BindearPropiedadEntidad = Nothing
      Me.dtpFechaFinActualizacion.CustomFormat = "dd/MM/yyyy HH:mm:ss"
      Me.dtpFechaFinActualizacion.Enabled = False
      Me.dtpFechaFinActualizacion.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaFinActualizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaFinActualizacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaFinActualizacion.IsPK = False
      Me.dtpFechaFinActualizacion.IsRequired = False
      Me.dtpFechaFinActualizacion.Key = ""
      Me.dtpFechaFinActualizacion.LabelAsoc = Me.lblFechaFinActualizacion
      Me.dtpFechaFinActualizacion.Location = New System.Drawing.Point(277, 58)
      Me.dtpFechaFinActualizacion.Name = "dtpFechaFinActualizacion"
      Me.dtpFechaFinActualizacion.ShowCheckBox = True
      Me.dtpFechaFinActualizacion.Size = New System.Drawing.Size(158, 20)
      Me.dtpFechaFinActualizacion.TabIndex = 14
      '
      'lblFechaFinActualizacion
      '
      Me.lblFechaFinActualizacion.AutoSize = True
      Me.lblFechaFinActualizacion.LabelAsoc = Nothing
      Me.lblFechaFinActualizacion.Location = New System.Drawing.Point(250, 62)
      Me.lblFechaFinActualizacion.Name = "lblFechaFinActualizacion"
      Me.lblFechaFinActualizacion.Size = New System.Drawing.Size(21, 13)
      Me.lblFechaFinActualizacion.TabIndex = 13
      Me.lblFechaFinActualizacion.Text = "Fin"
      '
      'dtpFechaInicioActualizacion
      '
      Me.dtpFechaInicioActualizacion.BindearPropiedadControl = Nothing
      Me.dtpFechaInicioActualizacion.BindearPropiedadEntidad = Nothing
      Me.dtpFechaInicioActualizacion.CustomFormat = "dd/MM/yyyy HH:mm:ss"
      Me.dtpFechaInicioActualizacion.Enabled = False
      Me.dtpFechaInicioActualizacion.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaInicioActualizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaInicioActualizacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaInicioActualizacion.IsPK = False
      Me.dtpFechaInicioActualizacion.IsRequired = False
      Me.dtpFechaInicioActualizacion.Key = ""
      Me.dtpFechaInicioActualizacion.LabelAsoc = Me.lblFechaInicioActualizacion
      Me.dtpFechaInicioActualizacion.Location = New System.Drawing.Point(64, 58)
      Me.dtpFechaInicioActualizacion.Name = "dtpFechaInicioActualizacion"
      Me.dtpFechaInicioActualizacion.ShowCheckBox = True
      Me.dtpFechaInicioActualizacion.Size = New System.Drawing.Size(158, 20)
      Me.dtpFechaInicioActualizacion.TabIndex = 12
      '
      'lblFechaInicioActualizacion
      '
      Me.lblFechaInicioActualizacion.AutoSize = True
      Me.lblFechaInicioActualizacion.LabelAsoc = Nothing
      Me.lblFechaInicioActualizacion.Location = New System.Drawing.Point(20, 62)
      Me.lblFechaInicioActualizacion.Name = "lblFechaInicioActualizacion"
      Me.lblFechaInicioActualizacion.Size = New System.Drawing.Size(32, 13)
      Me.lblFechaInicioActualizacion.TabIndex = 11
      Me.lblFechaInicioActualizacion.Text = "Inicio"
      '
      'ClientesActualizacionesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(896, 502)
      Me.Controls.Add(Me.grpEjecucion)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "ClientesActualizacionesDetalle"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Detalle de Actualización"
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grpEjecucion.ResumeLayout(False)
      Me.grpEjecucion.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents grpEjecucion As System.Windows.Forms.GroupBox
   Friend WithEvents dtpFechaFinActualizacion As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaFinActualizacion As Eniac.Controles.Label
   Friend WithEvents dtpFechaInicioActualizacion As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaInicioActualizacion As Eniac.Controles.Label
   Friend WithEvents txtNombreCliente As Eniac.Controles.TextBox
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents txtCodigoCliente As Eniac.Controles.TextBox
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents txtNombreServidor As Eniac.Controles.TextBox
   Friend WithEvents lblCliente As Eniac.Controles.Label
   Friend WithEvents lblBaseDatos As Eniac.Controles.Label
   Friend WithEvents txtBaseDatos As Eniac.Controles.TextBox
   Friend WithEvents lblNombreServidor As Eniac.Controles.Label
   Friend WithEvents dtpFechaEjecución As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaEjecucion As Eniac.Controles.Label
   Friend WithEvents lblIdUnico As Eniac.Controles.Label
   Friend WithEvents txtIdUnico As Eniac.Controles.TextBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents txtEstado As Eniac.Controles.TextBox
   Friend WithEvents lblEjecucionInstalador As Eniac.Controles.Label
   Friend WithEvents txtEjecucionInstalador As Eniac.Controles.TextBox
   Friend WithEvents lblEjecucionScripts As Eniac.Controles.Label
   Friend WithEvents txtEjecucionScripts As Eniac.Controles.TextBox
   Friend WithEvents lblBackup As Eniac.Controles.Label
   Friend WithEvents txtBackup As Eniac.Controles.TextBox
   Friend WithEvents lblDescargaInstalador As Eniac.Controles.Label
   Friend WithEvents txtDescargaInstalador As Eniac.Controles.TextBox
   Friend WithEvents lblDescargaScripts As Eniac.Controles.Label
   Friend WithEvents txtDescargaScripts As Eniac.Controles.TextBox
   Friend WithEvents tssDesactivar As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbDesactivar As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtActivo As Eniac.Controles.TextBox
End Class
