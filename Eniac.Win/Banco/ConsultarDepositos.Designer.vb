<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarDepositos
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
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDeposito")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuenta")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAplicado")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePesos")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDolares")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTickets")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTarjetas")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCheques")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UsoFechaCheque")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteEuros")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanCuenta")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAsiento")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaDestino", 0)
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 1)
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancariaDestino", 2)
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarDepositos))
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbCaja = New Eniac.Controles.CheckBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.chbComprobante = New Eniac.Controles.CheckBox()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.chbCuentaBancaria = New Eniac.Controles.CheckBox()
      Me.bscCuentaBancaria = New Eniac.Controles.Buscador()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.SuspendLayout()
      '
      'UltraDataSource1
      '
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
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
      Appearance27.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance27.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance27
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
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
      UltraGridColumn1.Width = 30
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance3
      UltraGridColumn2.Header.Caption = "Numero"
      UltraGridColumn2.Header.VisiblePosition = 3
      UltraGridColumn2.Width = 60
      UltraGridColumn3.Header.Caption = "Cuenta"
      UltraGridColumn3.Header.VisiblePosition = 5
      UltraGridColumn3.Width = 180
      Appearance4.TextHAlignAsString = "Center"
      UltraGridColumn4.CellAppearance = Appearance4
      UltraGridColumn4.Format = "dd/MM/yyyy"
      UltraGridColumn4.Header.Caption = "Movimiento"
      UltraGridColumn4.Header.VisiblePosition = 7
      UltraGridColumn4.Width = 70
      Appearance5.TextHAlignAsString = "Center"
      UltraGridColumn5.CellAppearance = Appearance5
      UltraGridColumn5.Format = "dd/MM/yyyy"
      UltraGridColumn5.Header.Caption = "Aplicado"
      UltraGridColumn5.Header.VisiblePosition = 8
      UltraGridColumn5.Width = 70
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance6
      UltraGridColumn6.Format = "N2"
      UltraGridColumn6.Header.Caption = "Pesos"
      UltraGridColumn6.Header.VisiblePosition = 9
      UltraGridColumn6.Width = 70
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance7
      UltraGridColumn7.Format = "N2"
      UltraGridColumn7.Header.Caption = "Dolares"
      UltraGridColumn7.Header.VisiblePosition = 10
      UltraGridColumn7.Width = 70
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance8
      UltraGridColumn8.Format = "N2"
      UltraGridColumn8.Header.Caption = "Tickets"
      UltraGridColumn8.Header.VisiblePosition = 11
      UltraGridColumn8.Hidden = True
      UltraGridColumn8.Width = 70
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance9
      UltraGridColumn9.Format = "N2"
      UltraGridColumn9.Header.Caption = "Tarjetas"
      UltraGridColumn9.Header.VisiblePosition = 12
      UltraGridColumn9.Width = 70
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn10.CellAppearance = Appearance10
      UltraGridColumn10.Format = "N2"
      UltraGridColumn10.Header.Caption = "Cheques"
      UltraGridColumn10.Header.VisiblePosition = 13
      UltraGridColumn10.Width = 70
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance11
      UltraGridColumn11.Format = "N2"
      UltraGridColumn11.Header.Caption = "Total"
      UltraGridColumn11.Header.VisiblePosition = 14
      UltraGridColumn11.Width = 80
      Appearance12.TextHAlignAsString = "Center"
      UltraGridColumn12.CellAppearance = Appearance12
      UltraGridColumn12.Header.Caption = "Fecha Cheque"
      UltraGridColumn12.Header.VisiblePosition = 15
      UltraGridColumn12.Width = 30
      UltraGridColumn13.Header.VisiblePosition = 17
      UltraGridColumn13.Width = 250
      UltraGridColumn14.Header.VisiblePosition = 18
      UltraGridColumn14.Hidden = True
      UltraGridColumn15.Header.VisiblePosition = 19
      UltraGridColumn15.Hidden = True
      Appearance13.TextHAlignAsString = "Right"
      UltraGridColumn16.CellAppearance = Appearance13
      UltraGridColumn16.Format = "##,##0.00"
      UltraGridColumn16.Header.Caption = "Euros"
      UltraGridColumn16.Header.VisiblePosition = 20
      UltraGridColumn16.Hidden = True
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn17.CellAppearance = Appearance14
      UltraGridColumn17.Header.Caption = "P."
      UltraGridColumn17.Header.VisiblePosition = 21
      UltraGridColumn17.Width = 25
      Appearance15.TextHAlignAsString = "Right"
      UltraGridColumn18.CellAppearance = Appearance15
      UltraGridColumn18.Header.Caption = "Asiento"
      UltraGridColumn18.Header.VisiblePosition = 22
      UltraGridColumn18.Width = 54
      UltraGridColumn19.Header.Caption = "Comprobante"
      UltraGridColumn19.Header.VisiblePosition = 1
      UltraGridColumn19.Width = 100
      UltraGridColumn23.Header.Caption = "Caja"
      UltraGridColumn23.Header.VisiblePosition = 4
      UltraGridColumn23.Width = 72
      UltraGridColumn20.Header.Caption = "Cuenta Destino"
      UltraGridColumn20.Header.VisiblePosition = 16
      UltraGridColumn20.Width = 200
      UltraGridColumn21.Header.Caption = "Descripción"
      UltraGridColumn21.Header.VisiblePosition = 2
      UltraGridColumn21.Hidden = True
      UltraGridColumn21.Width = 100
      UltraGridColumn22.Header.Caption = "Id Cuenta Bancaria Destino"
      UltraGridColumn22.Header.VisiblePosition = 6
      UltraGridColumn22.Hidden = True
      UltraGridColumn22.Width = 150
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn23, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22})
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
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
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
      Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 125)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(993, 400)
      Me.ugDetalle.TabIndex = 1
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 528)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(1017, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(938, 17)
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1017, 29)
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
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
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
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.chbCaja)
      Me.grbFiltros.Controls.Add(Me.cmbCajas)
      Me.grbFiltros.Controls.Add(Me.chbComprobante)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.chbCuentaBancaria)
      Me.grbFiltros.Controls.Add(Me.bscCuentaBancaria)
      Me.grbFiltros.Controls.Add(Me.chkExpandAll)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(993, 81)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
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
      Me.chbCaja.Location = New System.Drawing.Point(455, 51)
      Me.chbCaja.Name = "chbCaja"
      Me.chbCaja.Size = New System.Drawing.Size(47, 17)
      Me.chbCaja.TabIndex = 20
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
      Me.cmbCajas.Location = New System.Drawing.Point(550, 49)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(130, 21)
      Me.cmbCajas.TabIndex = 19
      '
      'chbComprobante
      '
      Me.chbComprobante.AutoSize = True
      Me.chbComprobante.BindearPropiedadControl = Nothing
      Me.chbComprobante.BindearPropiedadEntidad = Nothing
      Me.chbComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.chbComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbComprobante.IsPK = False
      Me.chbComprobante.IsRequired = False
      Me.chbComprobante.Key = Nothing
      Me.chbComprobante.LabelAsoc = Nothing
      Me.chbComprobante.Location = New System.Drawing.Point(455, 22)
      Me.chbComprobante.Name = "chbComprobante"
      Me.chbComprobante.Size = New System.Drawing.Size(89, 17)
      Me.chbComprobante.TabIndex = 5
      Me.chbComprobante.Text = "Comprobante"
      Me.chbComprobante.UseVisualStyleBackColor = True
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = "SelectedValue"
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = "IdTipoComprobanteSecundario"
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Enabled = False
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Nothing
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(550, 19)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
      Me.cmbTiposComprobantes.TabIndex = 6
      '
      'chbCuentaBancaria
      '
      Me.chbCuentaBancaria.AutoSize = True
      Me.chbCuentaBancaria.BindearPropiedadControl = Nothing
      Me.chbCuentaBancaria.BindearPropiedadEntidad = Nothing
      Me.chbCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCuentaBancaria.IsPK = False
      Me.chbCuentaBancaria.IsRequired = False
      Me.chbCuentaBancaria.Key = Nothing
      Me.chbCuentaBancaria.LabelAsoc = Nothing
      Me.chbCuentaBancaria.Location = New System.Drawing.Point(13, 49)
      Me.chbCuentaBancaria.Name = "chbCuentaBancaria"
      Me.chbCuentaBancaria.Size = New System.Drawing.Size(105, 17)
      Me.chbCuentaBancaria.TabIndex = 7
      Me.chbCuentaBancaria.Text = "Cuenta Bancaria"
      Me.chbCuentaBancaria.UseVisualStyleBackColor = True
      '
      'bscCuentaBancaria
      '
      Me.bscCuentaBancaria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCuentaBancaria.AyudaAncho = 608
      Me.bscCuentaBancaria.BindearPropiedadControl = Nothing
      Me.bscCuentaBancaria.BindearPropiedadEntidad = Nothing
      Me.bscCuentaBancaria.ColumnasAlineacion = Nothing
      Me.bscCuentaBancaria.ColumnasAncho = Nothing
      Me.bscCuentaBancaria.ColumnasFormato = Nothing
      Me.bscCuentaBancaria.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
      Me.bscCuentaBancaria.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
      Me.bscCuentaBancaria.Datos = Nothing
      Me.bscCuentaBancaria.Enabled = False
      Me.bscCuentaBancaria.FilaDevuelta = Nothing
      Me.bscCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCuentaBancaria.IsDecimal = False
      Me.bscCuentaBancaria.IsNumber = False
      Me.bscCuentaBancaria.IsPK = False
      Me.bscCuentaBancaria.IsRequired = False
      Me.bscCuentaBancaria.Key = ""
      Me.bscCuentaBancaria.LabelAsoc = Nothing
      Me.bscCuentaBancaria.Location = New System.Drawing.Point(124, 47)
      Me.bscCuentaBancaria.MaxLengh = "32767"
      Me.bscCuentaBancaria.Name = "bscCuentaBancaria"
      Me.bscCuentaBancaria.Permitido = True
      Me.bscCuentaBancaria.Selecciono = False
      Me.bscCuentaBancaria.Size = New System.Drawing.Size(315, 20)
      Me.bscCuentaBancaria.TabIndex = 8
      Me.bscCuentaBancaria.Titulo = "Clientes"
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(883, 37)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
      Me.chkExpandAll.TabIndex = 10
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(755, 22)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 9
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.dtpHasta.Location = New System.Drawing.Point(309, 20)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(268, 24)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
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
      Me.dtpDesde.Location = New System.Drawing.Point(154, 20)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(110, 24)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'ConsultarDepositos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1017, 550)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ConsultarDepositos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar Depositos, Extracciones, Liquidaciones o Transferencias"
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscCuentaBancaria As Eniac.Controles.Buscador
   Friend WithEvents chbCuentaBancaria As Eniac.Controles.CheckBox
   Public WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents chbComprobante As Eniac.Controles.CheckBox
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
End Class
