<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Informe5SDiferencias
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
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Cabecera", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto", -1, Nothing, 1028380360, 0, 0)
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto", -1, Nothing, 1028380360, 1, 0)
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente", -1, Nothing, 1028380360, 2, 0)
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadFechaIngreso", -1, Nothing, 1028380360, 3, 0)
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadFechaEgreso")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadStatusLiberado")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CalidadStatusEntregado")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaControl")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FecIngreso")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FecEgreso")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CincoS", -1, Nothing, 1028425735, 0, 0)
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CincoSComment", -1, Nothing, 1028425735, 1, 0)
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CincoSC", -1, Nothing, 1028434766, 0, 0)
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CincoSCommentC", -1, Nothing, 1028434766, 1, 0)
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CincoSUsr", -1, Nothing, 1028425735, 3, 0)
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CincoSFecha", -1, Nothing, 1028425735, 2, 0)
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CincoSUsrC", -1, Nothing, 1028434766, 3, 0)
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CincoSFechaC", -1, Nothing, 1028434766, 2, 0)
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Aplica")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCalidad")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaControl", -1, Nothing, 1028380360, 4, 0)
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoCalidad", -1, Nothing, 1028380360, 5, 0)
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dias")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasMaximoProceso")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridGroup1 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(1028380360)
      Dim UltraGridGroup2 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Producción", 1028425735)
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup3 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Calidad", 1028434766)
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Informe5SDiferencias))
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.MenuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ListaDeControlPorProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbExpandAll = New Eniac.Controles.CheckBox()
      Me.chbUbicacion = New Eniac.Controles.CheckBox()
      Me.cmbUbicacion = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmb5S = New Eniac.Controles.ComboBox()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.chbListasControl = New Eniac.Controles.CheckBox()
      Me.cmbListasControl = New Eniac.Controles.ComboBox()
      Me.chbFechaLiberado = New Eniac.Controles.CheckBox()
      Me.chbEstado = New Eniac.Controles.CheckBox()
      Me.cmbEstadoCalidad = New Eniac.Controles.ComboBox()
      Me.chbFechaEntregado = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.MenuContext.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
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
      Appearance28.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance28
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
      UltraGridColumn1.Header.Caption = "Codigo"
      UltraGridColumn1.Width = 78
      UltraGridColumn2.Header.Caption = "Producto"
      UltraGridColumn2.Width = 218
      UltraGridColumn7.Header.Caption = "Cliente"
      UltraGridColumn7.Width = 195
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn3.CellAppearance = Appearance2
      UltraGridColumn3.Header.Caption = "Fecha Ingreso"
      UltraGridColumn3.Width = 79
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn4.CellAppearance = Appearance3
      UltraGridColumn4.Header.Caption = "Fecha Egreso"
      UltraGridColumn4.Header.VisiblePosition = 10
      UltraGridColumn4.Hidden = True
      UltraGridColumn5.Header.Caption = "L"
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn5.Hidden = True
      UltraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn5.Width = 34
      UltraGridColumn6.Header.Caption = "E"
      UltraGridColumn6.Header.VisiblePosition = 6
      UltraGridColumn6.Hidden = True
      UltraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn6.Width = 41
      UltraGridColumn8.Header.Caption = "Codigo Cliente"
      UltraGridColumn8.Header.VisiblePosition = 4
      UltraGridColumn8.Hidden = True
      UltraGridColumn8.Width = 73
      UltraGridColumn9.Header.Caption = "Nombre Fantasia"
      UltraGridColumn9.Header.VisiblePosition = 11
      UltraGridColumn9.Hidden = True
      UltraGridColumn10.Header.VisiblePosition = 12
      UltraGridColumn10.Hidden = True
      UltraGridColumn11.Header.VisiblePosition = 13
      UltraGridColumn11.Hidden = True
      UltraGridColumn12.Header.VisiblePosition = 14
      UltraGridColumn12.Hidden = True
      UltraGridColumn13.Header.Caption = "Fecha"
      UltraGridColumn13.Header.VisiblePosition = 7
      UltraGridColumn13.Hidden = True
      UltraGridColumn13.Width = 80
      UltraGridColumn14.Header.Caption = "Fecha Fin"
      UltraGridColumn14.Header.VisiblePosition = 8
      UltraGridColumn14.Hidden = True
      UltraGridColumn14.Width = 81
      Appearance4.TextHAlignAsString = "Center"
      UltraGridColumn15.CellAppearance = Appearance4
      UltraGridColumn15.Header.Caption = "5S Producción"
      UltraGridColumn15.Width = 70
      UltraGridColumn16.Header.Caption = "5S Comentarios Producción"
      UltraGridColumn16.Width = 200
      Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Appearance5.TextHAlignAsString = "Center"
      UltraGridColumn17.CellAppearance = Appearance5
      UltraGridColumn17.Header.Caption = "5S Calidad"
      UltraGridColumn17.Width = 70
      Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      UltraGridColumn18.CellAppearance = Appearance6
      UltraGridColumn18.Header.Caption = "5S Comentarios Calidad"
      UltraGridColumn18.Width = 200
      UltraGridColumn19.Header.Caption = "5S Usuario Producción"
      UltraGridColumn19.Width = 80
      Appearance7.TextHAlignAsString = "Center"
      UltraGridColumn20.CellAppearance = Appearance7
      UltraGridColumn20.Header.Caption = "5S Fecha Producción"
      UltraGridColumn20.Width = 80
      Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      UltraGridColumn21.CellAppearance = Appearance8
      UltraGridColumn21.Header.Caption = "5S Usuario Calidad"
      UltraGridColumn21.Width = 80
      Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Appearance9.TextHAlignAsString = "Center"
      UltraGridColumn22.CellAppearance = Appearance9
      UltraGridColumn22.Header.Caption = "5S Fecha Calidad"
      UltraGridColumn22.Width = 80
      UltraGridColumn23.Header.VisiblePosition = 23
      UltraGridColumn23.Hidden = True
      UltraGridColumn24.Header.VisiblePosition = 24
      UltraGridColumn24.Hidden = True
      UltraGridColumn25.Header.Caption = "Lista de Control"
      UltraGridColumn25.Width = 240
      UltraGridColumn26.Header.Caption = "Estado"
      UltraGridColumn26.Width = 84
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn27.CellAppearance = Appearance10
      UltraGridColumn27.Header.VisiblePosition = 9
      UltraGridColumn27.Hidden = True
      UltraGridColumn27.Width = 70
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn28.CellAppearance = Appearance11
      UltraGridColumn28.Header.Caption = "Dias máximos"
      UltraGridColumn28.Header.VisiblePosition = 27
      UltraGridColumn28.Hidden = True
      UltraGridColumn28.Width = 70
      Appearance12.TextHAlignAsString = "Right"
      UltraGridColumn29.CellAppearance = Appearance12
      UltraGridColumn29.Header.VisiblePosition = 28
      UltraGridColumn29.Hidden = True
      UltraGridColumn29.Width = 70
      UltraGridColumn30.Header.Caption = "Observación"
      UltraGridColumn30.Header.VisiblePosition = 29
      UltraGridColumn30.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn7, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30})
      Appearance13.TextHAlignAsString = "Center"
      UltraGridGroup2.CellAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Center"
      UltraGridGroup2.Header.Appearance = Appearance14
      UltraGridGroup2.Key = "Producción"
      Appearance15.TextHAlignAsString = "Center"
      UltraGridGroup3.Header.Appearance = Appearance15
      UltraGridGroup3.Key = "Calidad"
      UltraGridBand1.Groups.AddRange(New Infragistics.Win.UltraWinGrid.UltraGridGroup() {UltraGridGroup1, UltraGridGroup2, UltraGridGroup3})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance16.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance16
      Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = " Arrastrar la Columna que desea agrupar"
      Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance18.BackColor2 = System.Drawing.SystemColors.Control
      Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance19
      Appearance20.BackColor = System.Drawing.SystemColors.Highlight
      Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance20
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance21.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance21
      Appearance22.BorderColor = System.Drawing.Color.Silver
      Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance22
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance23.BackColor = System.Drawing.SystemColors.Control
      Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance23.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance23
      Appearance24.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance24
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance25.BackColor = System.Drawing.SystemColors.Window
      Appearance25.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance25
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance26.BackColor = System.Drawing.Color.SkyBlue
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance26
      Appearance27.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance27
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(11, 177)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(1100, 359)
      Me.ugDetalle.TabIndex = 1
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'MenuContext
      '
      Me.MenuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListaDeControlPorProductosToolStripMenuItem})
      Me.MenuContext.Name = "MenuContext"
      Me.MenuContext.Size = New System.Drawing.Size(236, 26)
      '
      'ListaDeControlPorProductosToolStripMenuItem
      '
      Me.ListaDeControlPorProductosToolStripMenuItem.Name = "ListaDeControlPorProductosToolStripMenuItem"
      Me.ListaDeControlPorProductosToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
      Me.ListaDeControlPorProductosToolStripMenuItem.Text = "Lista de Control por Productos"
      '
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.chbExpandAll)
      Me.grbFiltros.Controls.Add(Me.chbUbicacion)
      Me.grbFiltros.Controls.Add(Me.cmbUbicacion)
      Me.grbFiltros.Controls.Add(Me.Label1)
      Me.grbFiltros.Controls.Add(Me.cmb5S)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.chbListasControl)
      Me.grbFiltros.Controls.Add(Me.cmbListasControl)
      Me.grbFiltros.Controls.Add(Me.chbFechaLiberado)
      Me.grbFiltros.Controls.Add(Me.chbEstado)
      Me.grbFiltros.Controls.Add(Me.cmbEstadoCalidad)
      Me.grbFiltros.Controls.Add(Me.chbFechaEntregado)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.bscProducto2)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProducto2)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbProducto)
      Me.grbFiltros.Location = New System.Drawing.Point(11, 32)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(1100, 139)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      '
      'chbExpandAll
      '
      Me.chbExpandAll.AutoSize = True
      Me.chbExpandAll.BindearPropiedadControl = Nothing
      Me.chbExpandAll.BindearPropiedadEntidad = Nothing
      Me.chbExpandAll.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExpandAll.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExpandAll.IsPK = False
      Me.chbExpandAll.IsRequired = False
      Me.chbExpandAll.Key = Nothing
      Me.chbExpandAll.LabelAsoc = Nothing
      Me.chbExpandAll.Location = New System.Drawing.Point(738, 113)
      Me.chbExpandAll.Name = "chbExpandAll"
      Me.chbExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chbExpandAll.TabIndex = 47
      Me.chbExpandAll.Text = "Expandir Grupos"
      Me.chbExpandAll.UseVisualStyleBackColor = True
      '
      'chbUbicacion
      '
      Me.chbUbicacion.AutoSize = True
      Me.chbUbicacion.BindearPropiedadControl = Nothing
      Me.chbUbicacion.BindearPropiedadEntidad = Nothing
      Me.chbUbicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUbicacion.IsPK = False
      Me.chbUbicacion.IsRequired = False
      Me.chbUbicacion.Key = Nothing
      Me.chbUbicacion.LabelAsoc = Nothing
      Me.chbUbicacion.Location = New System.Drawing.Point(540, 113)
      Me.chbUbicacion.Name = "chbUbicacion"
      Me.chbUbicacion.Size = New System.Drawing.Size(74, 17)
      Me.chbUbicacion.TabIndex = 41
      Me.chbUbicacion.Text = "Ubicacion"
      Me.chbUbicacion.UseVisualStyleBackColor = True
      '
      'cmbUbicacion
      '
      Me.cmbUbicacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbUbicacion.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUbicacion.Enabled = False
      Me.cmbUbicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUbicacion.FormattingEnabled = True
      Me.cmbUbicacion.IsPK = False
      Me.cmbUbicacion.IsRequired = False
      Me.cmbUbicacion.Key = Nothing
      Me.cmbUbicacion.LabelAsoc = Nothing
      Me.cmbUbicacion.Location = New System.Drawing.Point(617, 111)
      Me.cmbUbicacion.Name = "cmbUbicacion"
      Me.cmbUbicacion.Size = New System.Drawing.Size(88, 21)
      Me.cmbUbicacion.TabIndex = 42
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(591, 20)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(20, 13)
      Me.Label1.TabIndex = 40
      Me.Label1.Text = "5S"
      '
      'cmb5S
      '
      Me.cmb5S.BindearPropiedadControl = "SelectedValue"
      Me.cmb5S.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmb5S.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmb5S.ForeColorFocus = System.Drawing.Color.Red
      Me.cmb5S.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmb5S.FormattingEnabled = True
      Me.cmb5S.IsPK = False
      Me.cmb5S.IsRequired = False
      Me.cmb5S.Key = Nothing
      Me.cmb5S.LabelAsoc = Me.Label1
      Me.cmb5S.Location = New System.Drawing.Point(617, 15)
      Me.cmb5S.Name = "cmb5S"
      Me.cmb5S.Size = New System.Drawing.Size(142, 21)
      Me.cmb5S.TabIndex = 39
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
      Me.chbCliente.Location = New System.Drawing.Point(11, 109)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 38
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
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
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Nothing
      Me.bscCodigoCliente.Location = New System.Drawing.Point(105, 108)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(147, 23)
      Me.bscCodigoCliente.TabIndex = 36
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
      Me.bscCliente.LabelAsoc = Nothing
      Me.bscCliente.Location = New System.Drawing.Point(258, 109)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(267, 23)
      Me.bscCliente.TabIndex = 37
      '
      'chbListasControl
      '
      Me.chbListasControl.AutoSize = True
      Me.chbListasControl.BindearPropiedadControl = Nothing
      Me.chbListasControl.BindearPropiedadEntidad = Nothing
      Me.chbListasControl.ForeColorFocus = System.Drawing.Color.Red
      Me.chbListasControl.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbListasControl.IsPK = False
      Me.chbListasControl.IsRequired = False
      Me.chbListasControl.Key = Nothing
      Me.chbListasControl.LabelAsoc = Nothing
      Me.chbListasControl.Location = New System.Drawing.Point(266, 78)
      Me.chbListasControl.Name = "chbListasControl"
      Me.chbListasControl.Size = New System.Drawing.Size(104, 17)
      Me.chbListasControl.TabIndex = 29
      Me.chbListasControl.Text = "Listas de Control"
      Me.chbListasControl.UseVisualStyleBackColor = True
      '
      'cmbListasControl
      '
      Me.cmbListasControl.BindearPropiedadControl = "SelectedValue"
      Me.cmbListasControl.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbListasControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListasControl.Enabled = False
      Me.cmbListasControl.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbListasControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbListasControl.FormattingEnabled = True
      Me.cmbListasControl.IsPK = False
      Me.cmbListasControl.IsRequired = False
      Me.cmbListasControl.Key = Nothing
      Me.cmbListasControl.LabelAsoc = Nothing
      Me.cmbListasControl.Location = New System.Drawing.Point(376, 76)
      Me.cmbListasControl.Name = "cmbListasControl"
      Me.cmbListasControl.Size = New System.Drawing.Size(316, 21)
      Me.cmbListasControl.TabIndex = 30
      '
      'chbFechaLiberado
      '
      Me.chbFechaLiberado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chbFechaLiberado.AutoSize = True
      Me.chbFechaLiberado.BindearPropiedadControl = "Checked"
      Me.chbFechaLiberado.BindearPropiedadEntidad = "CalidadStatusLiberado"
      Me.chbFechaLiberado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaLiberado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaLiberado.IsPK = False
      Me.chbFechaLiberado.IsRequired = False
      Me.chbFechaLiberado.Key = Nothing
      Me.chbFechaLiberado.LabelAsoc = Nothing
      Me.chbFechaLiberado.Location = New System.Drawing.Point(544, 48)
      Me.chbFechaLiberado.Name = "chbFechaLiberado"
      Me.chbFechaLiberado.Size = New System.Drawing.Size(67, 17)
      Me.chbFechaLiberado.TabIndex = 26
      Me.chbFechaLiberado.Text = "Liberado"
      Me.chbFechaLiberado.UseVisualStyleBackColor = True
      Me.chbFechaLiberado.Visible = False
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
      Me.chbEstado.Location = New System.Drawing.Point(11, 78)
      Me.chbEstado.Name = "chbEstado"
      Me.chbEstado.Size = New System.Drawing.Size(67, 17)
      Me.chbEstado.TabIndex = 24
      Me.chbEstado.Text = "Estados "
      Me.chbEstado.UseVisualStyleBackColor = True
      '
      'cmbEstadoCalidad
      '
      Me.cmbEstadoCalidad.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoCalidad.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbEstadoCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoCalidad.Enabled = False
      Me.cmbEstadoCalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoCalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoCalidad.FormattingEnabled = True
      Me.cmbEstadoCalidad.IsPK = False
      Me.cmbEstadoCalidad.IsRequired = False
      Me.cmbEstadoCalidad.Key = Nothing
      Me.cmbEstadoCalidad.LabelAsoc = Nothing
      Me.cmbEstadoCalidad.Location = New System.Drawing.Point(105, 76)
      Me.cmbEstadoCalidad.Name = "cmbEstadoCalidad"
      Me.cmbEstadoCalidad.Size = New System.Drawing.Size(146, 21)
      Me.cmbEstadoCalidad.TabIndex = 25
      '
      'chbFechaEntregado
      '
      Me.chbFechaEntregado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chbFechaEntregado.AutoSize = True
      Me.chbFechaEntregado.BindearPropiedadControl = "Checked"
      Me.chbFechaEntregado.BindearPropiedadEntidad = "CalidadStatusEntregado"
      Me.chbFechaEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaEntregado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaEntregado.IsPK = False
      Me.chbFechaEntregado.IsRequired = False
      Me.chbFechaEntregado.Key = Nothing
      Me.chbFechaEntregado.LabelAsoc = Nothing
      Me.chbFechaEntregado.Location = New System.Drawing.Point(617, 48)
      Me.chbFechaEntregado.Name = "chbFechaEntregado"
      Me.chbFechaEntregado.Size = New System.Drawing.Size(75, 17)
      Me.chbFechaEntregado.TabIndex = 27
      Me.chbFechaEntregado.Text = "Entregado"
      Me.chbFechaEntregado.UseVisualStyleBackColor = True
      Me.chbFechaEntregado.Visible = False
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(11, 19)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 12
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
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
      Me.dtpHasta.Location = New System.Drawing.Point(442, 16)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 16
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(403, 20)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 15
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
      Me.dtpDesde.Location = New System.Drawing.Point(274, 16)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 14
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(118, 20)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(155, 13)
      Me.lblDesde.TabIndex = 13
      Me.lblDesde.Text = "Fecha Ingreso Producto Desde"
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ConfigBuscador = Nothing
      Me.bscProducto2.Datos = Nothing
      Me.bscProducto2.Enabled = False
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto2.IsDecimal = False
      Me.bscProducto2.IsNumber = False
      Me.bscProducto2.IsPK = False
      Me.bscProducto2.IsRequired = False
      Me.bscProducto2.Key = ""
      Me.bscProducto2.LabelAsoc = Me.chbProducto
      Me.bscProducto2.Location = New System.Drawing.Point(258, 45)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(267, 20)
      Me.bscProducto2.TabIndex = 4
      '
      'chbProducto
      '
      Me.chbProducto.AutoSize = True
      Me.chbProducto.BindearPropiedadControl = Nothing
      Me.chbProducto.BindearPropiedadEntidad = Nothing
      Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProducto.IsPK = False
      Me.chbProducto.IsRequired = False
      Me.chbProducto.Key = Nothing
      Me.chbProducto.LabelAsoc = Nothing
      Me.chbProducto.Location = New System.Drawing.Point(11, 48)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 2
      Me.chbProducto.Text = "Producto"
      Me.chbProducto.UseVisualStyleBackColor = True
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCodigoProducto2.Datos = Nothing
      Me.bscCodigoProducto2.Enabled = False
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2.IsDecimal = False
      Me.bscCodigoProducto2.IsNumber = False
      Me.bscCodigoProducto2.IsPK = False
      Me.bscCodigoProducto2.IsRequired = False
      Me.bscCodigoProducto2.Key = ""
      Me.bscCodigoProducto2.LabelAsoc = Me.chbProducto
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(106, 45)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
      Me.bscCodigoProducto2.TabIndex = 3
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(738, 65)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(99, 45)
      Me.btnConsultar.TabIndex = 11
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(1123, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(1044, 17)
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
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1123, 29)
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
      Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
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
      'Informe5SDiferencias
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1123, 561)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "Informe5SDiferencias"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe 5S Diferencias en Calificaciones"
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.MenuContext.ResumeLayout(False)
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbEstado As Eniac.Controles.CheckBox
   Friend WithEvents cmbEstadoCalidad As Eniac.Controles.ComboBox
   Friend WithEvents chbFechaLiberado As Eniac.Controles.CheckBox
   Friend WithEvents chbFechaEntregado As Eniac.Controles.CheckBox
   Friend WithEvents MenuContext As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ListaDeControlPorProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents chbListasControl As Eniac.Controles.CheckBox
   Friend WithEvents cmbListasControl As Eniac.Controles.ComboBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmb5S As Eniac.Controles.ComboBox
   Friend WithEvents chbUbicacion As Eniac.Controles.CheckBox
   Friend WithEvents cmbUbicacion As Eniac.Controles.ComboBox
   Friend WithEvents chbExpandAll As Eniac.Controles.CheckBox
End Class
