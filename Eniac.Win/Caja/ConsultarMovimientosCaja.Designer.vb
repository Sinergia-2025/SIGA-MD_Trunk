<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarMovimientosCaja
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
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCaja")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPlanilla")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPlanilla")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaMovimiento")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimiento")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaCaja")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdGrupoCuenta")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoMovimiento")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePesos")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDolares")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCheques")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTarjetas")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTickets")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsModificable")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteBancos")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteRetenciones")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GeneraContabilidad")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanCuenta")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAsiento")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CotizacionDolar")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdConceptoCM05")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionConceptoCM05")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoConceptoCM05")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imp", 0)
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarMovimientosCaja))
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.cmbCajas = New Eniac.Win.ComboBoxCajas()
        Me.cmbTipoFecha = New Eniac.Controles.ComboBox()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.chbVerSaldos = New System.Windows.Forms.CheckBox()
        Me.txtNroPlanilla = New Eniac.Controles.TextBox()
        Me.chbNroPlanilla = New Eniac.Controles.CheckBox()
        Me.chbGrupo = New Eniac.Controles.CheckBox()
        Me.cmbGrupos = New Eniac.Controles.ComboBox()
        Me.lblEsModificable = New Eniac.Controles.Label()
        Me.cmbEsModificable = New Eniac.Controles.ComboBox()
        Me.lblBuscar = New Eniac.Controles.Label()
        Me.txtBuscar = New Eniac.Controles.TextBox()
        Me.chbCuentaDeCaja = New Eniac.Controles.CheckBox()
        Me.bscCuentaCaja = New Eniac.Controles.Buscador2()
        Me.bscNombreCuentaCaja = New Eniac.Controles.Buscador2()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance35.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance35.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance35
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
        UltraGridColumn24.CellAppearance = Appearance3
        UltraGridColumn24.Header.Caption = "Suc."
        UltraGridColumn24.Header.VisiblePosition = 1
        UltraGridColumn24.Width = 36
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.Caption = "Caja"
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.Width = 110
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance4
        UltraGridColumn4.Format = "dd/MM/yyyy"
        UltraGridColumn4.Header.Caption = "Planilla"
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Width = 70
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance5
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance6
        UltraGridColumn5.Header.Caption = "Nro. Plan."
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 40
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance7
        UltraGridColumn6.Format = "dd/MM/yyyy"
        UltraGridColumn6.Header.Caption = "Movimiento"
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Width = 70
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance8
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn7.Header.Appearance = Appearance9
        UltraGridColumn7.Header.Caption = "Nro. Mov."
        UltraGridColumn7.Header.VisiblePosition = 8
        UltraGridColumn7.Width = 40
        UltraGridColumn8.Header.Caption = "Nombre de Cuenta"
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.Width = 180
        UltraGridColumn9.Header.Caption = "Grupo"
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn9.Width = 100
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance10
        UltraGridColumn10.Header.Caption = "T"
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Width = 20
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance11
        UltraGridColumn11.Format = "##,##0.00"
        UltraGridColumn11.Header.Caption = "Pesos"
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn11.Width = 70
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance12
        UltraGridColumn15.Format = "##,##0.00"
        UltraGridColumn15.Header.Caption = "Dolares"
        UltraGridColumn15.Header.VisiblePosition = 16
        UltraGridColumn15.Width = 70
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance13
        UltraGridColumn12.Format = "##,##0.00"
        UltraGridColumn12.Header.Caption = "Cheques"
        UltraGridColumn12.Header.VisiblePosition = 13
        UltraGridColumn12.Width = 70
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance14
        UltraGridColumn13.Format = "##,##0.00"
        UltraGridColumn13.Header.Caption = "Tarjetas"
        UltraGridColumn13.Header.VisiblePosition = 14
        UltraGridColumn13.Width = 70
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance15
        UltraGridColumn14.Format = "##,##0.00"
        UltraGridColumn14.Header.Caption = "Tickets"
        UltraGridColumn14.Header.VisiblePosition = 18
        UltraGridColumn14.Width = 70
        UltraGridColumn16.Header.Caption = "Usuario"
        UltraGridColumn16.Header.VisiblePosition = 19
        UltraGridColumn16.Width = 75
        Appearance16.TextHAlignAsString = "Center"
        UltraGridColumn17.CellAppearance = Appearance16
        UltraGridColumn17.Header.Caption = "Mod."
        UltraGridColumn17.Header.VisiblePosition = 20
        UltraGridColumn17.Width = 35
        UltraGridColumn18.Header.VisiblePosition = 21
        UltraGridColumn18.Width = 400
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance17
        UltraGridColumn20.Format = "##,##0.00"
        UltraGridColumn20.Header.Caption = "Bancos"
        UltraGridColumn20.Header.VisiblePosition = 17
        UltraGridColumn20.Width = 70
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance18
        UltraGridColumn21.Format = "##,##0.00"
        UltraGridColumn21.Header.Caption = "Retenc."
        UltraGridColumn21.Header.VisiblePosition = 15
        UltraGridColumn21.Width = 70
        UltraGridColumn25.Header.Caption = "Ctbl"
        UltraGridColumn25.Header.VisiblePosition = 22
        UltraGridColumn25.Width = 35
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance19
        UltraGridColumn22.Header.Caption = "P."
        UltraGridColumn22.Header.VisiblePosition = 23
        UltraGridColumn22.Width = 25
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance20
        UltraGridColumn23.Header.Caption = "Asiento"
        UltraGridColumn23.Header.VisiblePosition = 24
        UltraGridColumn23.Width = 54
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn26.Header.Appearance = Appearance22
        UltraGridColumn26.Header.Caption = "Cotización Dolar"
        UltraGridColumn26.Header.VisiblePosition = 25
        UltraGridColumn26.Width = 70
        UltraGridColumn27.Header.VisiblePosition = 26
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.Header.Caption = "Concepto CM05"
        UltraGridColumn28.Header.VisiblePosition = 27
        UltraGridColumn28.Width = 150
        Appearance23.TextHAlignAsString = "Center"
        UltraGridColumn29.CellAppearance = Appearance23
        UltraGridColumn29.Header.Caption = "Tipo CM05"
        UltraGridColumn29.Header.VisiblePosition = 28
        UltraGridColumn29.Width = 80
        UltraGridColumn19.Header.VisiblePosition = 2
        UltraGridColumn19.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn19.Width = 30
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn24, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn15, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn20, UltraGridColumn21, UltraGridColumn25, UltraGridColumn22, UltraGridColumn23, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn19})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance24.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance24
        Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance26.BackColor2 = System.Drawing.SystemColors.Control
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance26
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance27
        Appearance28.BackColor = System.Drawing.SystemColors.Highlight
        Appearance28.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance29
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Appearance30.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance31.BackColor = System.Drawing.SystemColors.Control
        Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance31
        Appearance32.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance34.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance34
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1034, 402)
        Me.ugDetalle.TabIndex = 0
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ugDetalle, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 137)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1040, 408)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 548)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1059, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(980, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.toolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1059, 29)
        Me.tstBarra.TabIndex = 3
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.lblCaja)
        Me.grbFiltros.Controls.Add(Me.cmbCajas)
        Me.grbFiltros.Controls.Add(Me.cmbTipoFecha)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.chbVerSaldos)
        Me.grbFiltros.Controls.Add(Me.txtNroPlanilla)
        Me.grbFiltros.Controls.Add(Me.chbNroPlanilla)
        Me.grbFiltros.Controls.Add(Me.chbGrupo)
        Me.grbFiltros.Controls.Add(Me.cmbGrupos)
        Me.grbFiltros.Controls.Add(Me.lblEsModificable)
        Me.grbFiltros.Controls.Add(Me.cmbEsModificable)
        Me.grbFiltros.Controls.Add(Me.lblBuscar)
        Me.grbFiltros.Controls.Add(Me.txtBuscar)
        Me.grbFiltros.Controls.Add(Me.chbCuentaDeCaja)
        Me.grbFiltros.Controls.Add(Me.bscCuentaCaja)
        Me.grbFiltros.Controls.Add(Me.bscNombreCuentaCaja)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1040, 93)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(543, 39)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(33, 13)
        Me.lblCaja.TabIndex = 8
        Me.lblCaja.Text = "Cajas"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = Nothing
        Me.cmbCajas.BindearPropiedadEntidad = Nothing
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCaja
        Me.cmbCajas.Location = New System.Drawing.Point(582, 35)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(141, 21)
        Me.cmbCajas.SucursalesSeleccionadas = Nothing
        Me.cmbCajas.TabIndex = 9
        '
        'cmbTipoFecha
        '
        Me.cmbTipoFecha.BindearPropiedadControl = ""
        Me.cmbTipoFecha.BindearPropiedadEntidad = ""
        Me.cmbTipoFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoFecha.FormattingEnabled = True
        Me.cmbTipoFecha.IsPK = False
        Me.cmbTipoFecha.IsRequired = False
        Me.cmbTipoFecha.Key = Nothing
        Me.cmbTipoFecha.LabelAsoc = Nothing
        Me.cmbTipoFecha.Location = New System.Drawing.Point(387, 35)
        Me.cmbTipoFecha.Name = "cmbTipoFecha"
        Me.cmbTipoFecha.Size = New System.Drawing.Size(102, 21)
        Me.cmbTipoFecha.TabIndex = 7
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(146, 9)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(92, 12)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'chbVerSaldos
        '
        Me.chbVerSaldos.AutoSize = True
        Me.chbVerSaldos.Checked = True
        Me.chbVerSaldos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbVerSaldos.Location = New System.Drawing.Point(852, 67)
        Me.chbVerSaldos.Name = "chbVerSaldos"
        Me.chbVerSaldos.Size = New System.Drawing.Size(77, 17)
        Me.chbVerSaldos.TabIndex = 21
        Me.chbVerSaldos.Text = "Ver Saldos"
        Me.chbVerSaldos.UseVisualStyleBackColor = True
        '
        'txtNroPlanilla
        '
        Me.txtNroPlanilla.BindearPropiedadControl = Nothing
        Me.txtNroPlanilla.BindearPropiedadEntidad = Nothing
        Me.txtNroPlanilla.Enabled = False
        Me.txtNroPlanilla.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPlanilla.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPlanilla.Formato = "##0"
        Me.txtNroPlanilla.IsDecimal = False
        Me.txtNroPlanilla.IsNumber = True
        Me.txtNroPlanilla.IsPK = False
        Me.txtNroPlanilla.IsRequired = False
        Me.txtNroPlanilla.Key = ""
        Me.txtNroPlanilla.LabelAsoc = Nothing
        Me.txtNroPlanilla.Location = New System.Drawing.Point(834, 35)
        Me.txtNroPlanilla.MaxLength = 8
        Me.txtNroPlanilla.Name = "txtNroPlanilla"
        Me.txtNroPlanilla.Size = New System.Drawing.Size(53, 20)
        Me.txtNroPlanilla.TabIndex = 11
        Me.txtNroPlanilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNroPlanilla
        '
        Me.chbNroPlanilla.AutoSize = True
        Me.chbNroPlanilla.BindearPropiedadControl = Nothing
        Me.chbNroPlanilla.BindearPropiedadEntidad = Nothing
        Me.chbNroPlanilla.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNroPlanilla.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNroPlanilla.IsPK = False
        Me.chbNroPlanilla.IsRequired = False
        Me.chbNroPlanilla.Key = Nothing
        Me.chbNroPlanilla.LabelAsoc = Nothing
        Me.chbNroPlanilla.Location = New System.Drawing.Point(752, 37)
        Me.chbNroPlanilla.Name = "chbNroPlanilla"
        Me.chbNroPlanilla.Size = New System.Drawing.Size(82, 17)
        Me.chbNroPlanilla.TabIndex = 10
        Me.chbNroPlanilla.Text = "Nro. Planilla"
        Me.chbNroPlanilla.UseVisualStyleBackColor = True
        '
        'chbGrupo
        '
        Me.chbGrupo.AutoSize = True
        Me.chbGrupo.BindearPropiedadControl = Nothing
        Me.chbGrupo.BindearPropiedadEntidad = Nothing
        Me.chbGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrupo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrupo.IsPK = False
        Me.chbGrupo.IsRequired = False
        Me.chbGrupo.Key = Nothing
        Me.chbGrupo.LabelAsoc = Nothing
        Me.chbGrupo.Location = New System.Drawing.Point(369, 66)
        Me.chbGrupo.Name = "chbGrupo"
        Me.chbGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chbGrupo.TabIndex = 15
        Me.chbGrupo.Text = "Grupo"
        Me.chbGrupo.UseVisualStyleBackColor = True
        '
        'cmbGrupos
        '
        Me.cmbGrupos.BindearPropiedadControl = ""
        Me.cmbGrupos.BindearPropiedadEntidad = ""
        Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupos.Enabled = False
        Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupos.FormattingEnabled = True
        Me.cmbGrupos.IsPK = False
        Me.cmbGrupos.IsRequired = False
        Me.cmbGrupos.Key = Nothing
        Me.cmbGrupos.LabelAsoc = Nothing
        Me.cmbGrupos.Location = New System.Drawing.Point(425, 64)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(96, 21)
        Me.cmbGrupos.TabIndex = 16
        '
        'lblEsModificable
        '
        Me.lblEsModificable.AutoSize = True
        Me.lblEsModificable.LabelAsoc = Nothing
        Me.lblEsModificable.Location = New System.Drawing.Point(527, 68)
        Me.lblEsModificable.Name = "lblEsModificable"
        Me.lblEsModificable.Size = New System.Drawing.Size(51, 13)
        Me.lblEsModificable.TabIndex = 17
        Me.lblEsModificable.Text = "Es Modif."
        '
        'cmbEsModificable
        '
        Me.cmbEsModificable.BindearPropiedadControl = Nothing
        Me.cmbEsModificable.BindearPropiedadEntidad = Nothing
        Me.cmbEsModificable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsModificable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEsModificable.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsModificable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsModificable.FormattingEnabled = True
        Me.cmbEsModificable.IsPK = False
        Me.cmbEsModificable.IsRequired = False
        Me.cmbEsModificable.Key = Nothing
        Me.cmbEsModificable.LabelAsoc = Me.lblEsModificable
        Me.cmbEsModificable.Location = New System.Drawing.Point(582, 64)
        Me.cmbEsModificable.Name = "cmbEsModificable"
        Me.cmbEsModificable.Size = New System.Drawing.Size(75, 21)
        Me.cmbEsModificable.TabIndex = 18
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.LabelAsoc = Nothing
        Me.lblBuscar.Location = New System.Drawing.Point(665, 68)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
        Me.lblBuscar.TabIndex = 19
        Me.lblBuscar.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.BindearPropiedadControl = "Text"
        Me.txtBuscar.BindearPropiedadEntidad = "NombreBanco"
        Me.txtBuscar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBuscar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBuscar.Formato = ""
        Me.txtBuscar.IsDecimal = False
        Me.txtBuscar.IsNumber = False
        Me.txtBuscar.IsPK = False
        Me.txtBuscar.IsRequired = False
        Me.txtBuscar.Key = ""
        Me.txtBuscar.LabelAsoc = Me.lblBuscar
        Me.txtBuscar.Location = New System.Drawing.Point(708, 64)
        Me.txtBuscar.MaxLength = 40
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(138, 20)
        Me.txtBuscar.TabIndex = 20
        '
        'chbCuentaDeCaja
        '
        Me.chbCuentaDeCaja.AutoSize = True
        Me.chbCuentaDeCaja.BindearPropiedadControl = Nothing
        Me.chbCuentaDeCaja.BindearPropiedadEntidad = Nothing
        Me.chbCuentaDeCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCuentaDeCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCuentaDeCaja.IsPK = False
        Me.chbCuentaDeCaja.IsRequired = False
        Me.chbCuentaDeCaja.Key = Nothing
        Me.chbCuentaDeCaja.LabelAsoc = Nothing
        Me.chbCuentaDeCaja.Location = New System.Drawing.Point(5, 66)
        Me.chbCuentaDeCaja.Name = "chbCuentaDeCaja"
        Me.chbCuentaDeCaja.Size = New System.Drawing.Size(60, 17)
        Me.chbCuentaDeCaja.TabIndex = 12
        Me.chbCuentaDeCaja.Text = "Cuenta"
        Me.chbCuentaDeCaja.UseVisualStyleBackColor = True
        '
        'bscCuentaCaja
        '
        Me.bscCuentaCaja.ActivarFiltroEnGrilla = True
        Me.bscCuentaCaja.AutoSize = True
        Me.bscCuentaCaja.BindearPropiedadControl = Nothing
        Me.bscCuentaCaja.BindearPropiedadEntidad = Nothing
        Me.bscCuentaCaja.ConfigBuscador = Nothing
        Me.bscCuentaCaja.Datos = Nothing
        Me.bscCuentaCaja.Enabled = False
        Me.bscCuentaCaja.FilaDevuelta = Nothing
        Me.bscCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaCaja.IsDecimal = False
        Me.bscCuentaCaja.IsNumber = False
        Me.bscCuentaCaja.IsPK = False
        Me.bscCuentaCaja.IsRequired = False
        Me.bscCuentaCaja.Key = ""
        Me.bscCuentaCaja.LabelAsoc = Nothing
        Me.bscCuentaCaja.Location = New System.Drawing.Point(68, 63)
        Me.bscCuentaCaja.MaxLengh = "32767"
        Me.bscCuentaCaja.Name = "bscCuentaCaja"
        Me.bscCuentaCaja.Permitido = True
        Me.bscCuentaCaja.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCuentaCaja.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCuentaCaja.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCuentaCaja.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCuentaCaja.Selecciono = False
        Me.bscCuentaCaja.Size = New System.Drawing.Size(90, 23)
        Me.bscCuentaCaja.TabIndex = 13
        '
        'bscNombreCuentaCaja
        '
        Me.bscNombreCuentaCaja.ActivarFiltroEnGrilla = True
        Me.bscNombreCuentaCaja.AutoSize = True
        Me.bscNombreCuentaCaja.BindearPropiedadControl = Nothing
        Me.bscNombreCuentaCaja.BindearPropiedadEntidad = Nothing
        Me.bscNombreCuentaCaja.ConfigBuscador = Nothing
        Me.bscNombreCuentaCaja.Datos = Nothing
        Me.bscNombreCuentaCaja.Enabled = False
        Me.bscNombreCuentaCaja.FilaDevuelta = Nothing
        Me.bscNombreCuentaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCuentaCaja.IsDecimal = False
        Me.bscNombreCuentaCaja.IsNumber = False
        Me.bscNombreCuentaCaja.IsPK = False
        Me.bscNombreCuentaCaja.IsRequired = False
        Me.bscNombreCuentaCaja.Key = ""
        Me.bscNombreCuentaCaja.LabelAsoc = Nothing
        Me.bscNombreCuentaCaja.Location = New System.Drawing.Point(162, 63)
        Me.bscNombreCuentaCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCuentaCaja.MaxLengh = "32767"
        Me.bscNombreCuentaCaja.Name = "bscNombreCuentaCaja"
        Me.bscNombreCuentaCaja.Permitido = True
        Me.bscNombreCuentaCaja.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCuentaCaja.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCuentaCaja.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCuentaCaja.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCuentaCaja.Selecciono = False
        Me.bscNombreCuentaCaja.Size = New System.Drawing.Size(202, 23)
        Me.bscNombreCuentaCaja.TabIndex = 14
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnConsultar.Location = New System.Drawing.Point(933, 22)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 22
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(6, 37)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 2
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
        Me.dtpHasta.Location = New System.Drawing.Point(286, 35)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpHasta.TabIndex = 6
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(245, 39)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 5
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
        Me.dtpDesde.Location = New System.Drawing.Point(147, 35)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesde.TabIndex = 4
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(103, 39)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 3
        Me.lblDesde.Text = "Desde"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(933, 70)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(106, 19)
        Me.chkExpandAll.TabIndex = 23
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'ConsultarMovimientosCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 570)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ConsultarMovimientosCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Movimientos de Caja"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
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
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
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
   Friend WithEvents bscCuentaCaja As Eniac.Controles.Buscador2
   Friend WithEvents bscNombreCuentaCaja As Eniac.Controles.Buscador2
    Friend WithEvents chbCuentaDeCaja As Eniac.Controles.CheckBox
    Friend WithEvents lblBuscar As Eniac.Controles.Label
    Friend WithEvents txtBuscar As Eniac.Controles.TextBox
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmbEsModificable As Eniac.Controles.ComboBox
    Friend WithEvents lblEsModificable As Eniac.Controles.Label
    Friend WithEvents chbGrupo As Eniac.Controles.CheckBox
    Friend WithEvents cmbGrupos As Eniac.Controles.ComboBox
    Friend WithEvents txtNroPlanilla As Eniac.Controles.TextBox
    Friend WithEvents chbNroPlanilla As Eniac.Controles.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chbVerSaldos As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
    Friend WithEvents lblSucursal As Eniac.Controles.Label
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbTipoFecha As Controles.ComboBox
    Friend WithEvents lblCaja As Controles.Label
    Friend WithEvents cmbCajas As ComboBoxCajas
End Class
