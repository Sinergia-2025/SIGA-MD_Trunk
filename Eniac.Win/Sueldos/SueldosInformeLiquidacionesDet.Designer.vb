<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosInformeLiquidacionesDet
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
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoComprobante")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocCliente")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocCliente")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoriaFiscal")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaDePago")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
      Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
      Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
      Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
      Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioLista")
      Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
      Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
      Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
      Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
      Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
      Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
      Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
      Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
      Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLegajo", -1, Nothing, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePersonal")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdConcepto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreConcepto")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Valor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Haberes")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoConcepto")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodoLiquidacion", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Deducciones")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoConcepto")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoRecibo")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroLiquidacion", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo1", 0)
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
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosInformeLiquidacionesDet))
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.grpModalidad = New System.Windows.Forms.GroupBox()
      Me.RadioModoAguinaldo = New System.Windows.Forms.RadioButton()
      Me.RadioModoNormal = New System.Windows.Forms.RadioButton()
      Me.chbConcepto = New System.Windows.Forms.CheckBox()
      Me.bscNombreConcepto = New Eniac.Controles.Buscador()
      Me.lblNombreConcepto = New Eniac.Controles.Label()
      Me.bscCodigoConcepto = New Eniac.Controles.Buscador()
      Me.lblCodigoConcepto = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbPeriodoLiquidacionHasta = New Eniac.Controles.ComboBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.cmbPeriodoLiquidacionDesde = New Eniac.Controles.ComboBox()
      Me.lbPeriodo = New Eniac.Controles.Label()
      Me.cmbTipoRecibo = New Eniac.Controles.ComboBox()
      Me.lblTipoRecibo = New Eniac.Controles.Label()
      Me.lblNroDocumento = New Eniac.Controles.Label()
      Me.ckbLegajo = New System.Windows.Forms.CheckBox()
      Me.bscIdLegajo = New Eniac.Controles.Buscador()
      Me.bscNombrePersonal = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.grpModalidad.SuspendLayout()
      Me.SuspendLayout()
      '
      'UltraDataSource1
      '
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance22.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance22
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
      UltraGridColumn12.Header.Caption = "Legajo"
      UltraGridColumn12.Header.VisiblePosition = 0
      UltraGridColumn2.Header.Caption = "Nombre Personal"
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Width = 188
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn3.CellAppearance = Appearance2
      UltraGridColumn3.Header.Caption = "Concepto"
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Hidden = True
      UltraGridColumn3.Width = 71
      UltraGridColumn4.Header.Caption = "Nombre Concepto"
      UltraGridColumn4.Header.VisiblePosition = 5
      UltraGridColumn4.Width = 199
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance3
      UltraGridColumn5.Format = "N2"
      UltraGridColumn5.Header.VisiblePosition = 6
      UltraGridColumn5.Width = 65
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn10.CellAppearance = Appearance4
      UltraGridColumn10.Format = "N2"
      UltraGridColumn10.Header.VisiblePosition = 7
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance5
      UltraGridColumn7.Format = "N2"
      UltraGridColumn7.Header.VisiblePosition = 9
      UltraGridColumn7.Hidden = True
      UltraGridColumn7.Width = 246
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance6
      UltraGridColumn8.Header.Caption = "Concepto"
      UltraGridColumn8.Header.VisiblePosition = 4
      UltraGridColumn8.Width = 65
      UltraGridColumn9.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
      Appearance7.BackColor = System.Drawing.Color.PaleGreen
      UltraGridColumn9.GroupByRowAppearance = Appearance7
      UltraGridColumn9.Header.Caption = "Periodo"
      UltraGridColumn9.Header.VisiblePosition = 1
      UltraGridColumn9.Width = 73
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance8
      UltraGridColumn11.Format = "N2"
      UltraGridColumn11.Header.VisiblePosition = 8
      UltraGridColumn6.Header.VisiblePosition = 11
      UltraGridColumn6.Hidden = True
      UltraGridColumn1.Header.VisiblePosition = 12
      UltraGridColumn1.Hidden = True
      UltraGridColumn13.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
      UltraGridColumn13.Header.VisiblePosition = 13
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn14.CellAppearance = Appearance9
      UltraGridColumn14.Format = "N2"
      UltraGridColumn14.Header.Caption = ""
      UltraGridColumn14.Header.VisiblePosition = 10
      UltraGridColumn14.Width = 150
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn10, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn11, UltraGridColumn6, UltraGridColumn1, UltraGridColumn13, UltraGridColumn14})
      UltraGridBand1.SummaryFooterCaption = "Grand Summaries"
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance10.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance10
      Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna para agrupar"
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance12.BackColor2 = System.Drawing.SystemColors.Control
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance13
      Appearance14.BackColor = System.Drawing.SystemColors.Highlight
      Appearance14.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance15
      Appearance16.BorderColor = System.Drawing.Color.Silver
      Appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance17.BackColor = System.Drawing.SystemColors.Control
      Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance17.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
      Appearance18.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance18
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Appearance19.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance19
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance20.BackColor = System.Drawing.Color.MediumAquamarine
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance20
      Appearance21.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance21
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 192)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(925, 344)
      Me.ugDetalle.TabIndex = 1
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(945, 29)
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
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
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
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(945, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(866, 17)
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
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.grpModalidad)
      Me.grbFiltros.Controls.Add(Me.chbConcepto)
      Me.grbFiltros.Controls.Add(Me.bscNombreConcepto)
      Me.grbFiltros.Controls.Add(Me.bscCodigoConcepto)
      Me.grbFiltros.Controls.Add(Me.lblNombreConcepto)
      Me.grbFiltros.Controls.Add(Me.lblCodigoConcepto)
      Me.grbFiltros.Controls.Add(Me.Label1)
      Me.grbFiltros.Controls.Add(Me.cmbPeriodoLiquidacionHasta)
      Me.grbFiltros.Controls.Add(Me.chkExpandAll)
      Me.grbFiltros.Controls.Add(Me.cmbPeriodoLiquidacionDesde)
      Me.grbFiltros.Controls.Add(Me.lbPeriodo)
      Me.grbFiltros.Controls.Add(Me.cmbTipoRecibo)
      Me.grbFiltros.Controls.Add(Me.lblTipoRecibo)
      Me.grbFiltros.Controls.Add(Me.lblNroDocumento)
      Me.grbFiltros.Controls.Add(Me.ckbLegajo)
      Me.grbFiltros.Controls.Add(Me.bscIdLegajo)
      Me.grbFiltros.Controls.Add(Me.bscNombrePersonal)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(925, 148)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'grpModalidad
      '
      Me.grpModalidad.Controls.Add(Me.RadioModoAguinaldo)
      Me.grpModalidad.Controls.Add(Me.RadioModoNormal)
      Me.grpModalidad.Location = New System.Drawing.Point(629, 63)
      Me.grpModalidad.Name = "grpModalidad"
      Me.grpModalidad.Size = New System.Drawing.Size(80, 52)
      Me.grpModalidad.TabIndex = 69
      Me.grpModalidad.TabStop = False
      '
      'RadioModoAguinaldo
      '
      Me.RadioModoAguinaldo.AutoSize = True
      Me.RadioModoAguinaldo.Location = New System.Drawing.Point(6, 29)
      Me.RadioModoAguinaldo.Name = "RadioModoAguinaldo"
      Me.RadioModoAguinaldo.Size = New System.Drawing.Size(72, 17)
      Me.RadioModoAguinaldo.TabIndex = 1
      Me.RadioModoAguinaldo.Text = "Aguinaldo"
      Me.RadioModoAguinaldo.UseVisualStyleBackColor = True
      '
      'RadioModoNormal
      '
      Me.RadioModoNormal.AutoSize = True
      Me.RadioModoNormal.Checked = True
      Me.RadioModoNormal.Location = New System.Drawing.Point(7, 10)
      Me.RadioModoNormal.Name = "RadioModoNormal"
      Me.RadioModoNormal.Size = New System.Drawing.Size(58, 17)
      Me.RadioModoNormal.TabIndex = 0
      Me.RadioModoNormal.TabStop = True
      Me.RadioModoNormal.Text = "Normal"
      Me.RadioModoNormal.UseVisualStyleBackColor = True
      '
      'chbConcepto
      '
      Me.chbConcepto.AutoSize = True
      Me.chbConcepto.Location = New System.Drawing.Point(11, 75)
      Me.chbConcepto.Name = "chbConcepto"
      Me.chbConcepto.Size = New System.Drawing.Size(72, 17)
      Me.chbConcepto.TabIndex = 68
      Me.chbConcepto.Text = "Concepto"
      Me.chbConcepto.UseVisualStyleBackColor = True
      '
      'bscNombreConcepto
      '
      Me.bscNombreConcepto.AutoSize = True
      Me.bscNombreConcepto.AyudaAncho = 608
      Me.bscNombreConcepto.BindearPropiedadControl = Nothing
      Me.bscNombreConcepto.BindearPropiedadEntidad = Nothing
      Me.bscNombreConcepto.ColumnasAlineacion = Nothing
      Me.bscNombreConcepto.ColumnasAncho = Nothing
      Me.bscNombreConcepto.ColumnasFormato = Nothing
      Me.bscNombreConcepto.ColumnasOcultas = Nothing
      Me.bscNombreConcepto.ColumnasTitulos = Nothing
      Me.bscNombreConcepto.Datos = Nothing
      Me.bscNombreConcepto.Enabled = False
      Me.bscNombreConcepto.FilaDevuelta = Nothing
      Me.bscNombreConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreConcepto.IsDecimal = False
      Me.bscNombreConcepto.IsNumber = False
      Me.bscNombreConcepto.IsPK = False
      Me.bscNombreConcepto.IsRequired = False
      Me.bscNombreConcepto.Key = ""
      Me.bscNombreConcepto.LabelAsoc = Me.lblNombreConcepto
      Me.bscNombreConcepto.Location = New System.Drawing.Point(234, 72)
      Me.bscNombreConcepto.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreConcepto.MaxLengh = "32767"
      Me.bscNombreConcepto.Name = "bscNombreConcepto"
      Me.bscNombreConcepto.Permitido = True
      Me.bscNombreConcepto.Selecciono = False
      Me.bscNombreConcepto.Size = New System.Drawing.Size(369, 23)
      Me.bscNombreConcepto.TabIndex = 67
      Me.bscNombreConcepto.Titulo = Nothing
      '
      'lblNombreConcepto
      '
      Me.lblNombreConcepto.AutoSize = True
      Me.lblNombreConcepto.Location = New System.Drawing.Point(233, 56)
      Me.lblNombreConcepto.Name = "lblNombreConcepto"
      Me.lblNombreConcepto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreConcepto.TabIndex = 66
      Me.lblNombreConcepto.Text = "Nombre"
      '
      'bscCodigoConcepto
      '
      Me.bscCodigoConcepto.AyudaAncho = 608
      Me.bscCodigoConcepto.BindearPropiedadControl = Nothing
      Me.bscCodigoConcepto.BindearPropiedadEntidad = Nothing
      Me.bscCodigoConcepto.ColumnasAlineacion = Nothing
      Me.bscCodigoConcepto.ColumnasAncho = Nothing
      Me.bscCodigoConcepto.ColumnasFormato = Nothing
      Me.bscCodigoConcepto.ColumnasOcultas = Nothing
      Me.bscCodigoConcepto.ColumnasTitulos = Nothing
      Me.bscCodigoConcepto.Datos = Nothing
      Me.bscCodigoConcepto.Enabled = False
      Me.bscCodigoConcepto.FilaDevuelta = Nothing
      Me.bscCodigoConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoConcepto.IsDecimal = False
      Me.bscCodigoConcepto.IsNumber = True
      Me.bscCodigoConcepto.IsPK = False
      Me.bscCodigoConcepto.IsRequired = False
      Me.bscCodigoConcepto.Key = ""
      Me.bscCodigoConcepto.LabelAsoc = Me.lblCodigoConcepto
      Me.bscCodigoConcepto.Location = New System.Drawing.Point(96, 72)
      Me.bscCodigoConcepto.MaxLengh = "32767"
      Me.bscCodigoConcepto.Name = "bscCodigoConcepto"
      Me.bscCodigoConcepto.Permitido = True
      Me.bscCodigoConcepto.Selecciono = False
      Me.bscCodigoConcepto.Size = New System.Drawing.Size(131, 23)
      Me.bscCodigoConcepto.TabIndex = 65
      Me.bscCodigoConcepto.Titulo = Nothing
      '
      'lblCodigoConcepto
      '
      Me.lblCodigoConcepto.AutoSize = True
      Me.lblCodigoConcepto.Location = New System.Drawing.Point(94, 56)
      Me.lblCodigoConcepto.Name = "lblCodigoConcepto"
      Me.lblCodigoConcepto.Size = New System.Drawing.Size(53, 13)
      Me.lblCodigoConcepto.TabIndex = 64
      Me.lblCodigoConcepto.Text = "Concepto"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(258, 28)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(35, 13)
      Me.Label1.TabIndex = 63
      Me.Label1.Text = "Hasta"
      '
      'cmbPeriodoLiquidacionHasta
      '
      Me.cmbPeriodoLiquidacionHasta.BindearPropiedadControl = "SelectedValue"
      Me.cmbPeriodoLiquidacionHasta.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.cmbPeriodoLiquidacionHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPeriodoLiquidacionHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPeriodoLiquidacionHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPeriodoLiquidacionHasta.FormattingEnabled = True
      Me.cmbPeriodoLiquidacionHasta.IsPK = False
      Me.cmbPeriodoLiquidacionHasta.IsRequired = True
      Me.cmbPeriodoLiquidacionHasta.Key = Nothing
      Me.cmbPeriodoLiquidacionHasta.LabelAsoc = Nothing
      Me.cmbPeriodoLiquidacionHasta.Location = New System.Drawing.Point(299, 23)
      Me.cmbPeriodoLiquidacionHasta.Name = "cmbPeriodoLiquidacionHasta"
      Me.cmbPeriodoLiquidacionHasta.Size = New System.Drawing.Size(90, 21)
      Me.cmbPeriodoLiquidacionHasta.TabIndex = 62
      '
      'chkExpandAll
      '
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(811, 119)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chkExpandAll.TabIndex = 61
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'cmbPeriodoLiquidacionDesde
      '
      Me.cmbPeriodoLiquidacionDesde.BindearPropiedadControl = "SelectedValue"
      Me.cmbPeriodoLiquidacionDesde.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.cmbPeriodoLiquidacionDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPeriodoLiquidacionDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPeriodoLiquidacionDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPeriodoLiquidacionDesde.FormattingEnabled = True
      Me.cmbPeriodoLiquidacionDesde.IsPK = False
      Me.cmbPeriodoLiquidacionDesde.IsRequired = True
      Me.cmbPeriodoLiquidacionDesde.Key = Nothing
      Me.cmbPeriodoLiquidacionDesde.LabelAsoc = Nothing
      Me.cmbPeriodoLiquidacionDesde.Location = New System.Drawing.Point(151, 23)
      Me.cmbPeriodoLiquidacionDesde.Name = "cmbPeriodoLiquidacionDesde"
      Me.cmbPeriodoLiquidacionDesde.Size = New System.Drawing.Size(90, 21)
      Me.cmbPeriodoLiquidacionDesde.TabIndex = 60
      '
      'lbPeriodo
      '
      Me.lbPeriodo.AutoSize = True
      Me.lbPeriodo.Location = New System.Drawing.Point(11, 28)
      Me.lbPeriodo.Name = "lbPeriodo"
      Me.lbPeriodo.Size = New System.Drawing.Size(134, 13)
      Me.lbPeriodo.TabIndex = 59
      Me.lbPeriodo.Text = "Periodo Liquidación Desde"
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
      Me.cmbTipoRecibo.LabelAsoc = Me.lblTipoRecibo
      Me.cmbTipoRecibo.Location = New System.Drawing.Point(505, 23)
      Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
      Me.cmbTipoRecibo.Size = New System.Drawing.Size(126, 21)
      Me.cmbTipoRecibo.TabIndex = 1
      '
      'lblTipoRecibo
      '
      Me.lblTipoRecibo.AutoSize = True
      Me.lblTipoRecibo.Location = New System.Drawing.Point(419, 28)
      Me.lblTipoRecibo.Name = "lblTipoRecibo"
      Me.lblTipoRecibo.Size = New System.Drawing.Size(80, 13)
      Me.lblTipoRecibo.TabIndex = 0
      Me.lblTipoRecibo.Text = "Tipo de Recibo"
      '
      'lblNroDocumento
      '
      Me.lblNroDocumento.AutoSize = True
      Me.lblNroDocumento.Location = New System.Drawing.Point(93, 96)
      Me.lblNroDocumento.Name = "lblNroDocumento"
      Me.lblNroDocumento.Size = New System.Drawing.Size(62, 13)
      Me.lblNroDocumento.TabIndex = 3
      Me.lblNroDocumento.Text = "Nro. Legajo"
      '
      'ckbLegajo
      '
      Me.ckbLegajo.AutoSize = True
      Me.ckbLegajo.Location = New System.Drawing.Point(11, 116)
      Me.ckbLegajo.Name = "ckbLegajo"
      Me.ckbLegajo.Size = New System.Drawing.Size(58, 17)
      Me.ckbLegajo.TabIndex = 2
      Me.ckbLegajo.Text = "Legajo"
      Me.ckbLegajo.UseVisualStyleBackColor = True
      '
      'bscIdLegajo
      '
      Me.bscIdLegajo.AyudaAncho = 608
      Me.bscIdLegajo.BindearPropiedadControl = Nothing
      Me.bscIdLegajo.BindearPropiedadEntidad = Nothing
      Me.bscIdLegajo.ColumnasAlineacion = Nothing
      Me.bscIdLegajo.ColumnasAncho = Nothing
      Me.bscIdLegajo.ColumnasFormato = Nothing
      Me.bscIdLegajo.ColumnasOcultas = Nothing
      Me.bscIdLegajo.ColumnasTitulos = Nothing
      Me.bscIdLegajo.Datos = Nothing
      Me.bscIdLegajo.Enabled = False
      Me.bscIdLegajo.FilaDevuelta = Nothing
      Me.bscIdLegajo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscIdLegajo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscIdLegajo.IsDecimal = False
      Me.bscIdLegajo.IsNumber = True
      Me.bscIdLegajo.IsPK = False
      Me.bscIdLegajo.IsRequired = False
      Me.bscIdLegajo.Key = ""
      Me.bscIdLegajo.LabelAsoc = Nothing
      Me.bscIdLegajo.Location = New System.Drawing.Point(96, 113)
      Me.bscIdLegajo.MaxLengh = "32767"
      Me.bscIdLegajo.Name = "bscIdLegajo"
      Me.bscIdLegajo.Permitido = True
      Me.bscIdLegajo.Selecciono = False
      Me.bscIdLegajo.Size = New System.Drawing.Size(131, 23)
      Me.bscIdLegajo.TabIndex = 4
      Me.bscIdLegajo.Titulo = Nothing
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
      Me.bscNombrePersonal.Location = New System.Drawing.Point(234, 113)
      Me.bscNombrePersonal.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombrePersonal.MaxLengh = "32767"
      Me.bscNombrePersonal.Name = "bscNombrePersonal"
      Me.bscNombrePersonal.Permitido = True
      Me.bscNombrePersonal.Selecciono = False
      Me.bscNombrePersonal.Size = New System.Drawing.Size(369, 23)
      Me.bscNombrePersonal.TabIndex = 6
      Me.bscNombrePersonal.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(231, 96)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 5
      Me.lblNombre.Text = "Nombre"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(809, 64)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 7
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'SueldosInformeLiquidacionesDet
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(945, 561)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "SueldosInformeLiquidacionesDet"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Liquidacion Detallada"
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.grpModalidad.ResumeLayout(False)
      Me.grpModalidad.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscIdLegajo As Eniac.Controles.Buscador
   Friend WithEvents bscNombrePersonal As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ckbLegajo As System.Windows.Forms.CheckBox
   Friend WithEvents lblNroDocumento As Eniac.Controles.Label
   Friend WithEvents cmbTipoRecibo As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoRecibo As Eniac.Controles.Label
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbPeriodoLiquidacionDesde As Eniac.Controles.ComboBox
   Friend WithEvents lbPeriodo As Eniac.Controles.Label
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbPeriodoLiquidacionHasta As Eniac.Controles.ComboBox
   Friend WithEvents chbConcepto As System.Windows.Forms.CheckBox
   Friend WithEvents bscNombreConcepto As Eniac.Controles.Buscador
   Friend WithEvents lblNombreConcepto As Eniac.Controles.Label
   Friend WithEvents bscCodigoConcepto As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoConcepto As Eniac.Controles.Label
   Friend WithEvents grpModalidad As System.Windows.Forms.GroupBox
   Friend WithEvents RadioModoAguinaldo As System.Windows.Forms.RadioButton
   Friend WithEvents RadioModoNormal As System.Windows.Forms.RadioButton
End Class
