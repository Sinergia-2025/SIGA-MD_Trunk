﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfTurnosCalendarios
   Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfTurnosCalendarios))
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTurno")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCalendario")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCalendario")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaDesde")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaHasta")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoTurno")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoTurno")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsEfectivo")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observaciones")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorcGral")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroSesion")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoTurno")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoTurno")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmbarcacion")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoEmbarcacion")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmbarcacion")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDestino")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DestinoLibre")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadPasajeros")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaHoraLlegada")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarcaVehiculo", 0)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreModeloVehiculo", 1)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PatenteVehiculo", 2)
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Telefono", 3)
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbEstadosTurnos = New Eniac.Controles.ComboBox()
        Me.chbEstadoTurno = New Eniac.Controles.CheckBox()
        Me.cmbCalendario = New Eniac.Controles.ComboBox()
        Me.cmbTiposTurnos = New Eniac.Controles.ComboBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.bscNombreCliente = New Eniac.Controles.Buscador2()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbCalendario = New Eniac.Controles.CheckBox()
        Me.chbTipoTurno = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1067, 29)
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
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance30.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance30
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
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.VisiblePosition = 3
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.Caption = "Calendario"
        UltraGridColumn14.Header.VisiblePosition = 1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn1.Header.Caption = "Desde"
        UltraGridColumn1.Header.VisiblePosition = 2
        UltraGridColumn1.Width = 100
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn2.Header.Caption = "Hasta"
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.Width = 100
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Hidden = True
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance4
        UltraGridColumn7.Header.Caption = "Código"
        UltraGridColumn7.Header.VisiblePosition = 10
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 60
        UltraGridColumn8.Header.Caption = "Cliente"
        UltraGridColumn8.Header.VisiblePosition = 5
        UltraGridColumn8.Width = 217
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn9.CellAppearance = Appearance5
        UltraGridColumn9.Header.Caption = "Tipo"
        UltraGridColumn9.Header.VisiblePosition = 11
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 40
        UltraGridColumn15.Header.Caption = "Tipo"
        UltraGridColumn15.Header.VisiblePosition = 9
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance6
        UltraGridColumn10.Header.Caption = "Efect."
        UltraGridColumn10.Header.VisiblePosition = 12
        UltraGridColumn10.Width = 46
        UltraGridColumn11.Header.VisiblePosition = 30
        UltraGridColumn11.Width = 300
        UltraGridColumn4.Header.Caption = "Código"
        UltraGridColumn4.Header.VisiblePosition = 13
        UltraGridColumn4.Width = 78
        UltraGridColumn5.Header.Caption = "Nombre"
        UltraGridColumn5.Header.VisiblePosition = 14
        UltraGridColumn5.Width = 248
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance7
        UltraGridColumn16.Format = "N2"
        UltraGridColumn16.Header.Caption = "Precio Lista"
        UltraGridColumn16.Header.VisiblePosition = 16
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance8
        UltraGridColumn17.Format = "N2"
        UltraGridColumn17.Header.VisiblePosition = 17
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance9
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.Caption = "% D/R"
        UltraGridColumn18.Header.VisiblePosition = 18
        UltraGridColumn18.Width = 47
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance10
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "% D/R 1"
        UltraGridColumn19.Header.VisiblePosition = 19
        UltraGridColumn19.Width = 53
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance11
        UltraGridColumn20.Format = "N2"
        UltraGridColumn20.Header.Caption = "% D/R 2"
        UltraGridColumn20.Header.VisiblePosition = 20
        UltraGridColumn20.Width = 58
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance12
        UltraGridColumn21.Format = "N2"
        UltraGridColumn21.Header.Caption = "Precio Neto"
        UltraGridColumn21.Header.VisiblePosition = 21
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance13
        UltraGridColumn3.Header.Caption = "Nro Sesion"
        UltraGridColumn3.Header.VisiblePosition = 15
        UltraGridColumn22.Header.VisiblePosition = 22
        UltraGridColumn22.Hidden = True
        UltraGridColumn23.Header.Caption = "Estado"
        UltraGridColumn23.Header.VisiblePosition = 8
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance14
        UltraGridColumn24.Header.VisiblePosition = 23
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 60
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance15
        UltraGridColumn25.Header.Caption = "Código Embarcación"
        UltraGridColumn25.Header.VisiblePosition = 24
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 83
        UltraGridColumn26.Header.Caption = "Embarcación"
        UltraGridColumn26.Header.VisiblePosition = 25
        UltraGridColumn26.Width = 150
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance16
        UltraGridColumn27.Header.Caption = "Código Destino"
        UltraGridColumn27.Header.VisiblePosition = 26
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.Width = 60
        UltraGridColumn28.Header.Caption = "Destino Libre"
        UltraGridColumn28.Header.VisiblePosition = 27
        UltraGridColumn28.Width = 150
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance17
        UltraGridColumn29.Header.Caption = "Cantidad Pasajeros"
        UltraGridColumn29.Header.VisiblePosition = 28
        UltraGridColumn29.Width = 70
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn30.CellAppearance = Appearance18
        UltraGridColumn30.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn30.Header.Caption = "Llegada"
        UltraGridColumn30.Header.VisiblePosition = 29
        UltraGridColumn30.Width = 100
        UltraGridColumn31.Header.Caption = "Marca Vehiculo"
        UltraGridColumn31.Header.VisiblePosition = 32
        UltraGridColumn32.Header.Caption = "Modelo Vehiculo"
        UltraGridColumn32.Header.VisiblePosition = 33
        UltraGridColumn33.Header.Caption = "Patente Vehiculo"
        UltraGridColumn33.Header.VisiblePosition = 31
        UltraGridColumn34.Header.VisiblePosition = 7
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn1, UltraGridColumn2, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn15, UltraGridColumn10, UltraGridColumn11, UltraGridColumn4, UltraGridColumn5, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn3, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance19
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar."
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance21.BackColor2 = System.Drawing.SystemColors.Control
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance22
        Appearance23.BackColor = System.Drawing.SystemColors.Highlight
        Appearance23.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance23
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance24
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Appearance25.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance26.BackColor = System.Drawing.SystemColors.Control
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance26
        Appearance27.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(12, 151)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1039, 361)
        Me.ugDetalle.TabIndex = 1
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbEstadosTurnos)
        Me.grbFiltros.Controls.Add(Me.chbEstadoTurno)
        Me.grbFiltros.Controls.Add(Me.cmbCalendario)
        Me.grbFiltros.Controls.Add(Me.cmbTiposTurnos)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.bscNombreCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.chbCalendario)
        Me.grbFiltros.Controls.Add(Me.chbTipoTurno)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1039, 113)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'cmbEstadosTurnos
        '
        Me.cmbEstadosTurnos.BindearPropiedadControl = Nothing
        Me.cmbEstadosTurnos.BindearPropiedadEntidad = Nothing
        Me.cmbEstadosTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadosTurnos.Enabled = False
        Me.cmbEstadosTurnos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadosTurnos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadosTurnos.FormattingEnabled = True
        Me.cmbEstadosTurnos.IsPK = False
        Me.cmbEstadosTurnos.IsRequired = False
        Me.cmbEstadosTurnos.Key = Nothing
        Me.cmbEstadosTurnos.LabelAsoc = Nothing
        Me.cmbEstadosTurnos.Location = New System.Drawing.Point(111, 82)
        Me.cmbEstadosTurnos.Name = "cmbEstadosTurnos"
        Me.cmbEstadosTurnos.Size = New System.Drawing.Size(120, 21)
        Me.cmbEstadosTurnos.TabIndex = 17
        '
        'chbEstadoTurno
        '
        Me.chbEstadoTurno.AutoSize = True
        Me.chbEstadoTurno.BindearPropiedadControl = Nothing
        Me.chbEstadoTurno.BindearPropiedadEntidad = Nothing
        Me.chbEstadoTurno.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstadoTurno.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstadoTurno.IsPK = False
        Me.chbEstadoTurno.IsRequired = False
        Me.chbEstadoTurno.Key = Nothing
        Me.chbEstadoTurno.LabelAsoc = Nothing
        Me.chbEstadoTurno.Location = New System.Drawing.Point(9, 84)
        Me.chbEstadoTurno.Name = "chbEstadoTurno"
        Me.chbEstadoTurno.Size = New System.Drawing.Size(105, 17)
        Me.chbEstadoTurno.TabIndex = 16
        Me.chbEstadoTurno.Text = "Estado de Turno"
        Me.chbEstadoTurno.UseVisualStyleBackColor = True
        '
        'cmbCalendario
        '
        Me.cmbCalendario.BindearPropiedadControl = "SelectedValue"
        Me.cmbCalendario.BindearPropiedadEntidad = "idCancha"
        Me.cmbCalendario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalendario.Enabled = False
        Me.cmbCalendario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCalendario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCalendario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCalendario.FormattingEnabled = True
        Me.cmbCalendario.IsPK = False
        Me.cmbCalendario.IsRequired = True
        Me.cmbCalendario.Key = Nothing
        Me.cmbCalendario.LabelAsoc = Nothing
        Me.cmbCalendario.Location = New System.Drawing.Point(627, 17)
        Me.cmbCalendario.Name = "cmbCalendario"
        Me.cmbCalendario.Size = New System.Drawing.Size(212, 21)
        Me.cmbCalendario.TabIndex = 6
        '
        'cmbTiposTurnos
        '
        Me.cmbTiposTurnos.BindearPropiedadControl = Nothing
        Me.cmbTiposTurnos.BindearPropiedadEntidad = Nothing
        Me.cmbTiposTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposTurnos.Enabled = False
        Me.cmbTiposTurnos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposTurnos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposTurnos.FormattingEnabled = True
        Me.cmbTiposTurnos.IsPK = False
        Me.cmbTiposTurnos.IsRequired = False
        Me.cmbTiposTurnos.Key = Nothing
        Me.cmbTiposTurnos.LabelAsoc = Nothing
        Me.cmbTiposTurnos.Location = New System.Drawing.Point(627, 51)
        Me.cmbTiposTurnos.Name = "cmbTiposTurnos"
        Me.cmbTiposTurnos.Size = New System.Drawing.Size(120, 21)
        Me.cmbTiposTurnos.TabIndex = 11
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(10, 21)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
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
        Me.dtpHasta.Location = New System.Drawing.Point(331, 19)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(294, 23)
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
        Me.dtpDesde.Location = New System.Drawing.Point(151, 19)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(107, 23)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.ActivarFiltroEnGrilla = True
        Me.bscNombreCliente.BindearPropiedadControl = Nothing
        Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
        Me.bscNombreCliente.ConfigBuscador = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.Enabled = False
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Nothing
        Me.bscNombreCliente.Location = New System.Drawing.Point(218, 51)
        Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = True
        Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(272, 23)
        Me.bscNombreCliente.TabIndex = 9
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
        Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(81, 51)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(133, 23)
        Me.bscCodigoCliente.TabIndex = 8
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Location = New System.Drawing.Point(894, 83)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(96, 20)
        Me.chkExpandAll.TabIndex = 15
        Me.chkExpandAll.Text = "Expandir todo"
        '
        'chbCalendario
        '
        Me.chbCalendario.AutoSize = True
        Me.chbCalendario.BindearPropiedadControl = Nothing
        Me.chbCalendario.BindearPropiedadEntidad = Nothing
        Me.chbCalendario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCalendario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCalendario.IsPK = False
        Me.chbCalendario.IsRequired = False
        Me.chbCalendario.Key = Nothing
        Me.chbCalendario.LabelAsoc = Nothing
        Me.chbCalendario.Location = New System.Drawing.Point(525, 20)
        Me.chbCalendario.Name = "chbCalendario"
        Me.chbCalendario.Size = New System.Drawing.Size(76, 17)
        Me.chbCalendario.TabIndex = 5
        Me.chbCalendario.Text = "Calendario"
        Me.chbCalendario.UseVisualStyleBackColor = True
        '
        'chbTipoTurno
        '
        Me.chbTipoTurno.AutoSize = True
        Me.chbTipoTurno.BindearPropiedadControl = Nothing
        Me.chbTipoTurno.BindearPropiedadEntidad = Nothing
        Me.chbTipoTurno.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoTurno.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoTurno.IsPK = False
        Me.chbTipoTurno.IsRequired = False
        Me.chbTipoTurno.Key = Nothing
        Me.chbTipoTurno.LabelAsoc = Nothing
        Me.chbTipoTurno.Location = New System.Drawing.Point(525, 53)
        Me.chbTipoTurno.Name = "chbTipoTurno"
        Me.chbTipoTurno.Size = New System.Drawing.Size(93, 17)
        Me.chbTipoTurno.TabIndex = 10
        Me.chbTipoTurno.Text = "Tipo de Turno"
        Me.chbTipoTurno.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(894, 29)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 14
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.chbCliente.Location = New System.Drawing.Point(10, 54)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 7
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 517)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1067, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(988, 17)
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
        'InfTurnosCalendarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 539)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "InfTurnosCalendarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Turnos"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Protected WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Protected WithEvents chbTipoTurno As Eniac.Controles.CheckBox
   Protected WithEvents btnConsultar As Eniac.Controles.Button
   Protected WithEvents chbCliente As Eniac.Controles.CheckBox
   Protected WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected WithEvents bscNombreCliente As Eniac.Controles.Buscador2
   Protected WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Protected WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Protected WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Protected WithEvents lblHasta As Eniac.Controles.Label
   Protected WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Protected WithEvents lblDesde As Eniac.Controles.Label
   Protected WithEvents cmbTiposTurnos As Eniac.Controles.ComboBox
   Protected WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Protected WithEvents cmbCalendario As Eniac.Controles.ComboBox
   Protected WithEvents chbCalendario As Eniac.Controles.CheckBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Protected WithEvents cmbEstadosTurnos As Eniac.Controles.ComboBox
   Protected WithEvents chbEstadoTurno As Eniac.Controles.CheckBox
End Class