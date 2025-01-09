<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InfOrdenesProduccionMRPProductos
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
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionTipoComprobante")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraComprobante")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProcesoProductivo")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdOperacion")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProcProdOperacion")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionOperacion")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoTarea")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaOrdenProduccion")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalPedido")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobantePedido")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionTipoComprobantePedido")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraPedido")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorPedido")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoPedido")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenPedido")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoProceso")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoProceso")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsProductoNecesario")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescriptionEsProductoNecesario")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSolicitada")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadProcesada")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadPendiente")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EstadoCompra")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalOP")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteOP")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionTipoComprobanteOP")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraComprobanteOP")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorOP")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccionOP")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenOP")
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
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfOrdenesProduccionMRPProductos))
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.gpbFiltroDeclaracion = New System.Windows.Forms.GroupBox()
        Me.txtCodigoOperacion = New Eniac.Controles.TextBox()
        Me.chbCodigoOperacion = New Eniac.Controles.CheckBox()
        Me.chbCentroEmisorPedido = New Eniac.Controles.CheckBox()
        Me.chbCentroEmisor = New Eniac.Controles.CheckBox()
        Me.cmbCentroEmisorPedido = New Eniac.Controles.ComboBox()
        Me.chbLetraFiscalPedido = New Eniac.Controles.CheckBox()
        Me.cmbCentroEmisor = New Eniac.Controles.ComboBox()
        Me.cmbLetraFiscalPedido = New Eniac.Controles.ComboBox()
        Me.chbLetraFiscal = New Eniac.Controles.CheckBox()
        Me.cmbLetraFiscal = New Eniac.Controles.ComboBox()
        Me.lblEsResultante = New Eniac.Controles.Label()
        Me.chbEstado = New Eniac.Controles.CheckBox()
        Me.cmbEsResultante = New Eniac.Controles.ComboBox()
        Me.cmbEstados = New Eniac.Controles.ComboBox()
        Me.txtPlanMaestroNumero = New Eniac.Controles.TextBox()
        Me.chbPlanMaestroNumero = New Eniac.Controles.CheckBox()
        Me.txtLineaPedido = New Eniac.Controles.TextBox()
        Me.chbLineaPedido = New Eniac.Controles.CheckBox()
        Me.chbTipoComprobantePedido = New Eniac.Controles.CheckBox()
        Me.cmbTipoComprobantePedido = New Eniac.Controles.ComboBox()
        Me.chbNumeroPedido = New Eniac.Controles.CheckBox()
        Me.txtNumeroPedidoDesde = New Eniac.Controles.TextBox()
        Me.bscNombreProducto = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.cmbTipoComprobante = New Eniac.Controles.ComboBox()
        Me.lblNumeroPedidoHasta = New Eniac.Controles.Label()
        Me.lblNumeroHasta = New Eniac.Controles.Label()
        Me.chbOrdenProduccion = New Eniac.Controles.CheckBox()
        Me.txtNumeroPedidoHasta = New Eniac.Controles.TextBox()
        Me.txtNumeroHasta = New Eniac.Controles.TextBox()
        Me.txtNumeroDesde = New Eniac.Controles.TextBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.bscNombreCliente = New Eniac.Controles.Buscador2()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tspBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.splitter1 = New Infragistics.Win.Misc.UltraSplitter()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFiltroDeclaracion.SuspendLayout()
        Me.tspBarra.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
        Me.tssInfo.Spring = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.ToolStripProgressBar1, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 3
        Me.stsStado.Text = "statusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ToolStripProgressBar1.Visible = False
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance36.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance36
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
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance2
        UltraGridColumn5.Header.Caption = "S."
        UltraGridColumn5.Header.VisiblePosition = 3
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 30
        UltraGridColumn3.Header.Caption = "Codigó Tipo Comprobante"
        UltraGridColumn3.Header.VisiblePosition = 21
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 100
        UltraGridColumn17.Header.Caption = "Tipo"
        UltraGridColumn17.Header.VisiblePosition = 4
        UltraGridColumn17.Width = 100
        UltraGridColumn18.Header.Caption = "L."
        UltraGridColumn18.Header.VisiblePosition = 5
        UltraGridColumn18.Width = 30
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance3
        UltraGridColumn6.Header.Caption = "Emisor"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 50
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance4
        UltraGridColumn7.Header.Caption = "Número"
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 90
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance5
        UltraGridColumn32.Header.VisiblePosition = 13
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 50
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance6
        UltraGridColumn16.Header.Caption = "Proceso Productivo"
        UltraGridColumn16.Header.VisiblePosition = 24
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 70
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance7
        UltraGridColumn19.Header.Caption = "Id Operación"
        UltraGridColumn19.Header.VisiblePosition = 22
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 70
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance8
        UltraGridColumn20.Header.Caption = "Orden Tarea"
        UltraGridColumn20.Header.VisiblePosition = 0
        UltraGridColumn20.Width = 70
        UltraGridColumn21.Header.Caption = "Operación"
        UltraGridColumn21.Header.VisiblePosition = 1
        UltraGridColumn21.Width = 100
        UltraGridColumn24.Header.Caption = "Estado"
        UltraGridColumn24.Header.VisiblePosition = 2
        UltraGridColumn24.Width = 80
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn11.CellAppearance = Appearance9
        UltraGridColumn11.Header.Caption = "Fecha Orden"
        UltraGridColumn11.Header.VisiblePosition = 8
        UltraGridColumn11.Width = 100
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance10
        UltraGridColumn12.Header.Caption = "Id Cliente"
        UltraGridColumn12.Header.VisiblePosition = 23
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 70
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance11
        UltraGridColumn25.Header.Caption = "Código Cliente"
        UltraGridColumn25.Header.VisiblePosition = 9
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 70
        UltraGridColumn13.Header.Caption = "Cliente"
        UltraGridColumn13.Header.VisiblePosition = 10
        UltraGridColumn13.Width = 200
        UltraGridColumn26.Header.Caption = "Código Producto"
        UltraGridColumn26.Header.VisiblePosition = 11
        UltraGridColumn26.Width = 100
        UltraGridColumn15.Header.Caption = "Producto"
        UltraGridColumn15.Header.VisiblePosition = 12
        UltraGridColumn15.Width = 200
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance12
        UltraGridColumn27.Header.Caption = "S. P."
        UltraGridColumn27.Header.VisiblePosition = 14
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.Width = 30
        UltraGridColumn28.Header.Caption = "Código Tipo Comprobante Pedido"
        UltraGridColumn28.Header.VisiblePosition = 25
        UltraGridColumn28.Hidden = True
        UltraGridColumn28.Width = 100
        UltraGridColumn33.Header.Caption = "Tipo Comprobante Pedido"
        UltraGridColumn33.Header.VisiblePosition = 15
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 100
        UltraGridColumn29.Header.Caption = "L.P."
        UltraGridColumn29.Header.VisiblePosition = 16
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Width = 30
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance13
        UltraGridColumn30.Header.Caption = "Emisor P."
        UltraGridColumn30.Header.VisiblePosition = 17
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 50
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance14
        UltraGridColumn1.Header.Caption = "Número P."
        UltraGridColumn1.Header.VisiblePosition = 18
        UltraGridColumn1.Width = 90
        UltraGridColumn31.Header.Caption = "Código Producto Pedido"
        UltraGridColumn31.Header.VisiblePosition = 20
        UltraGridColumn31.Hidden = True
        UltraGridColumn31.Width = 100
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance15
        UltraGridColumn2.Header.Caption = "Orden Pedido"
        UltraGridColumn2.Header.VisiblePosition = 19
        UltraGridColumn2.Width = 50
        UltraGridColumn4.Header.Caption = "Código Producto Proceso"
        UltraGridColumn4.Header.VisiblePosition = 26
        UltraGridColumn4.Width = 100
        UltraGridColumn8.Header.Caption = "Producto Proceso"
        UltraGridColumn8.Header.VisiblePosition = 27
        UltraGridColumn8.Width = 200
        UltraGridColumn9.Header.VisiblePosition = 28
        UltraGridColumn9.Hidden = True
        Appearance16.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance16
        UltraGridColumn10.Header.Caption = "Necesario / Resultante"
        UltraGridColumn10.Header.VisiblePosition = 29
        UltraGridColumn10.Width = 100
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance17
        UltraGridColumn14.Format = "N4"
        UltraGridColumn14.Header.Caption = "Cantidad Solicitada"
        UltraGridColumn14.Header.VisiblePosition = 30
        UltraGridColumn14.Width = 80
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance18
        UltraGridColumn22.Format = "N4"
        UltraGridColumn22.Header.Caption = "Cantidad Procesada"
        UltraGridColumn22.Header.VisiblePosition = 31
        UltraGridColumn22.Width = 80
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance19
        UltraGridColumn23.Format = "N4"
        UltraGridColumn23.Header.Caption = "Cantidad Pendiente"
        UltraGridColumn23.Header.VisiblePosition = 32
        UltraGridColumn23.Width = 80
        Appearance20.TextHAlignAsString = "Center"
        UltraGridColumn34.CellAppearance = Appearance20
        UltraGridColumn34.Header.Caption = "Estado Compra"
        UltraGridColumn34.Header.VisiblePosition = 33
        UltraGridColumn34.Width = 100
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance21
        UltraGridColumn35.Header.Caption = "S. OP."
        UltraGridColumn35.Header.VisiblePosition = 34
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 30
        UltraGridColumn36.Header.Caption = "Código Tipo Comprobante OP"
        UltraGridColumn36.Header.VisiblePosition = 35
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 100
        UltraGridColumn37.Header.Caption = "Tipo Comprobante OP"
        UltraGridColumn37.Header.VisiblePosition = 36
        UltraGridColumn37.Width = 100
        UltraGridColumn38.Header.Caption = "L. OP."
        UltraGridColumn38.Header.VisiblePosition = 37
        UltraGridColumn38.Width = 30
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance22
        UltraGridColumn39.Header.Caption = "Emisor OP."
        UltraGridColumn39.Header.VisiblePosition = 38
        UltraGridColumn39.Width = 50
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance23
        UltraGridColumn40.Header.Caption = "Número OP."
        UltraGridColumn40.Header.VisiblePosition = 39
        UltraGridColumn40.Width = 90
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn41.CellAppearance = Appearance24
        UltraGridColumn41.Header.Caption = "Orden OP."
        UltraGridColumn41.Header.VisiblePosition = 40
        UltraGridColumn41.Width = 50
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn5, UltraGridColumn3, UltraGridColumn17, UltraGridColumn18, UltraGridColumn6, UltraGridColumn7, UltraGridColumn32, UltraGridColumn16, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn24, UltraGridColumn11, UltraGridColumn12, UltraGridColumn25, UltraGridColumn13, UltraGridColumn26, UltraGridColumn15, UltraGridColumn27, UltraGridColumn28, UltraGridColumn33, UltraGridColumn29, UltraGridColumn30, UltraGridColumn1, UltraGridColumn31, UltraGridColumn2, UltraGridColumn4, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn14, UltraGridColumn22, UltraGridColumn23, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance25
        Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance26
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance27.BackColor2 = System.Drawing.SystemColors.Control
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance28
        Appearance29.BackColor = System.Drawing.SystemColors.Highlight
        Appearance29.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance30
        Appearance31.BorderColor = System.Drawing.Color.Silver
        Appearance31.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance31
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance32.BackColor = System.Drawing.SystemColors.Control
        Appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance32.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance32
        Appearance33.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance34
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance35.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance35
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 344)
        Me.ugDetalle.TabIndex = 2
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'gpbFiltroDeclaracion
        '
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtCodigoOperacion)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbCodigoOperacion)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbCentroEmisorPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbCentroEmisor)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbCentroEmisorPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbLetraFiscalPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbCentroEmisor)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbLetraFiscalPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbLetraFiscal)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbLetraFiscal)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblEsResultante)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbEstado)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbEsResultante)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbEstados)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtPlanMaestroNumero)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbPlanMaestroNumero)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtLineaPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbLineaPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbTipoComprobantePedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbTipoComprobantePedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbNumeroPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtNumeroPedidoDesde)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.bscNombreProducto)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.bscCodigoProducto)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbTipoComprobante)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbTipoComprobante)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblNumeroPedidoHasta)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblNumeroHasta)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbOrdenProduccion)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtNumeroPedidoHasta)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtNumeroHasta)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtNumeroDesde)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbFecha)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.bscNombreCliente)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.bscCodigoCliente)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbCliente)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbProducto)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chkMesCompleto)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.dtpHasta)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.dtpDesde)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblDesde)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblHasta)
        Me.gpbFiltroDeclaracion.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltroDeclaracion.Location = New System.Drawing.Point(0, 29)
        Me.gpbFiltroDeclaracion.Name = "gpbFiltroDeclaracion"
        Me.gpbFiltroDeclaracion.Size = New System.Drawing.Size(984, 151)
        Me.gpbFiltroDeclaracion.TabIndex = 0
        Me.gpbFiltroDeclaracion.TabStop = False
        Me.gpbFiltroDeclaracion.Text = "Filtros"
        '
        'txtCodigoOperacion
        '
        Me.txtCodigoOperacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodigoOperacion.BindearPropiedadControl = Nothing
        Me.txtCodigoOperacion.BindearPropiedadEntidad = Nothing
        Me.txtCodigoOperacion.Enabled = False
        Me.txtCodigoOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoOperacion.Formato = ""
        Me.txtCodigoOperacion.IsDecimal = False
        Me.txtCodigoOperacion.IsNumber = False
        Me.txtCodigoOperacion.IsPK = False
        Me.txtCodigoOperacion.IsRequired = False
        Me.txtCodigoOperacion.Key = ""
        Me.txtCodigoOperacion.LabelAsoc = Nothing
        Me.txtCodigoOperacion.Location = New System.Drawing.Point(353, 21)
        Me.txtCodigoOperacion.MaxLength = 30
        Me.txtCodigoOperacion.Name = "txtCodigoOperacion"
        Me.txtCodigoOperacion.Size = New System.Drawing.Size(54, 20)
        Me.txtCodigoOperacion.TabIndex = 3
        '
        'chbCodigoOperacion
        '
        Me.chbCodigoOperacion.AutoSize = True
        Me.chbCodigoOperacion.BindearPropiedadControl = Nothing
        Me.chbCodigoOperacion.BindearPropiedadEntidad = Nothing
        Me.chbCodigoOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCodigoOperacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCodigoOperacion.IsPK = False
        Me.chbCodigoOperacion.IsRequired = False
        Me.chbCodigoOperacion.Key = Nothing
        Me.chbCodigoOperacion.LabelAsoc = Nothing
        Me.chbCodigoOperacion.Location = New System.Drawing.Point(299, 23)
        Me.chbCodigoOperacion.Name = "chbCodigoOperacion"
        Me.chbCodigoOperacion.Size = New System.Drawing.Size(54, 17)
        Me.chbCodigoOperacion.TabIndex = 2
        Me.chbCodigoOperacion.Text = "Tarea"
        '
        'chbCentroEmisorPedido
        '
        Me.chbCentroEmisorPedido.AutoSize = True
        Me.chbCentroEmisorPedido.BindearPropiedadControl = Nothing
        Me.chbCentroEmisorPedido.BindearPropiedadEntidad = Nothing
        Me.chbCentroEmisorPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCentroEmisorPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCentroEmisorPedido.IsPK = False
        Me.chbCentroEmisorPedido.IsRequired = False
        Me.chbCentroEmisorPedido.Key = Nothing
        Me.chbCentroEmisorPedido.LabelAsoc = Nothing
        Me.chbCentroEmisorPedido.Location = New System.Drawing.Point(440, 100)
        Me.chbCentroEmisorPedido.Name = "chbCentroEmisorPedido"
        Me.chbCentroEmisorPedido.Size = New System.Drawing.Size(57, 17)
        Me.chbCentroEmisorPedido.TabIndex = 32
        Me.chbCentroEmisorPedido.Text = "Emisor"
        Me.chbCentroEmisorPedido.UseVisualStyleBackColor = True
        '
        'chbCentroEmisor
        '
        Me.chbCentroEmisor.AutoSize = True
        Me.chbCentroEmisor.BindearPropiedadControl = Nothing
        Me.chbCentroEmisor.BindearPropiedadEntidad = Nothing
        Me.chbCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCentroEmisor.IsPK = False
        Me.chbCentroEmisor.IsRequired = False
        Me.chbCentroEmisor.Key = Nothing
        Me.chbCentroEmisor.LabelAsoc = Nothing
        Me.chbCentroEmisor.Location = New System.Drawing.Point(440, 50)
        Me.chbCentroEmisor.Name = "chbCentroEmisor"
        Me.chbCentroEmisor.Size = New System.Drawing.Size(57, 17)
        Me.chbCentroEmisor.TabIndex = 14
        Me.chbCentroEmisor.Text = "Emisor"
        Me.chbCentroEmisor.UseVisualStyleBackColor = True
        '
        'cmbCentroEmisorPedido
        '
        Me.cmbCentroEmisorPedido.BindearPropiedadControl = Nothing
        Me.cmbCentroEmisorPedido.BindearPropiedadEntidad = Nothing
        Me.cmbCentroEmisorPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroEmisorPedido.Enabled = False
        Me.cmbCentroEmisorPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroEmisorPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCentroEmisorPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCentroEmisorPedido.FormattingEnabled = True
        Me.cmbCentroEmisorPedido.IsPK = False
        Me.cmbCentroEmisorPedido.IsRequired = False
        Me.cmbCentroEmisorPedido.Key = Nothing
        Me.cmbCentroEmisorPedido.LabelAsoc = Me.chbCentroEmisorPedido
        Me.cmbCentroEmisorPedido.Location = New System.Drawing.Point(499, 98)
        Me.cmbCentroEmisorPedido.Name = "cmbCentroEmisorPedido"
        Me.cmbCentroEmisorPedido.Size = New System.Drawing.Size(40, 21)
        Me.cmbCentroEmisorPedido.TabIndex = 33
        '
        'chbLetraFiscalPedido
        '
        Me.chbLetraFiscalPedido.AutoSize = True
        Me.chbLetraFiscalPedido.BindearPropiedadControl = Nothing
        Me.chbLetraFiscalPedido.BindearPropiedadEntidad = Nothing
        Me.chbLetraFiscalPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLetraFiscalPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLetraFiscalPedido.IsPK = False
        Me.chbLetraFiscalPedido.IsRequired = False
        Me.chbLetraFiscalPedido.Key = Nothing
        Me.chbLetraFiscalPedido.LabelAsoc = Nothing
        Me.chbLetraFiscalPedido.Location = New System.Drawing.Point(340, 100)
        Me.chbLetraFiscalPedido.Name = "chbLetraFiscalPedido"
        Me.chbLetraFiscalPedido.Size = New System.Drawing.Size(50, 17)
        Me.chbLetraFiscalPedido.TabIndex = 30
        Me.chbLetraFiscalPedido.Text = "Letra"
        Me.chbLetraFiscalPedido.UseVisualStyleBackColor = True
        '
        'cmbCentroEmisor
        '
        Me.cmbCentroEmisor.BindearPropiedadControl = Nothing
        Me.cmbCentroEmisor.BindearPropiedadEntidad = Nothing
        Me.cmbCentroEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroEmisor.Enabled = False
        Me.cmbCentroEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCentroEmisor.FormattingEnabled = True
        Me.cmbCentroEmisor.IsPK = False
        Me.cmbCentroEmisor.IsRequired = False
        Me.cmbCentroEmisor.Key = Nothing
        Me.cmbCentroEmisor.LabelAsoc = Me.chbCentroEmisor
        Me.cmbCentroEmisor.Location = New System.Drawing.Point(499, 48)
        Me.cmbCentroEmisor.Name = "cmbCentroEmisor"
        Me.cmbCentroEmisor.Size = New System.Drawing.Size(40, 21)
        Me.cmbCentroEmisor.TabIndex = 15
        '
        'cmbLetraFiscalPedido
        '
        Me.cmbLetraFiscalPedido.BindearPropiedadControl = Nothing
        Me.cmbLetraFiscalPedido.BindearPropiedadEntidad = Nothing
        Me.cmbLetraFiscalPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLetraFiscalPedido.Enabled = False
        Me.cmbLetraFiscalPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLetraFiscalPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLetraFiscalPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLetraFiscalPedido.FormattingEnabled = True
        Me.cmbLetraFiscalPedido.IsPK = False
        Me.cmbLetraFiscalPedido.IsRequired = False
        Me.cmbLetraFiscalPedido.Key = Nothing
        Me.cmbLetraFiscalPedido.LabelAsoc = Me.chbLetraFiscalPedido
        Me.cmbLetraFiscalPedido.Location = New System.Drawing.Point(396, 98)
        Me.cmbLetraFiscalPedido.Name = "cmbLetraFiscalPedido"
        Me.cmbLetraFiscalPedido.Size = New System.Drawing.Size(38, 21)
        Me.cmbLetraFiscalPedido.TabIndex = 31
        '
        'chbLetraFiscal
        '
        Me.chbLetraFiscal.AutoSize = True
        Me.chbLetraFiscal.BindearPropiedadControl = Nothing
        Me.chbLetraFiscal.BindearPropiedadEntidad = Nothing
        Me.chbLetraFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLetraFiscal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLetraFiscal.IsPK = False
        Me.chbLetraFiscal.IsRequired = False
        Me.chbLetraFiscal.Key = Nothing
        Me.chbLetraFiscal.LabelAsoc = Nothing
        Me.chbLetraFiscal.Location = New System.Drawing.Point(340, 50)
        Me.chbLetraFiscal.Name = "chbLetraFiscal"
        Me.chbLetraFiscal.Size = New System.Drawing.Size(50, 17)
        Me.chbLetraFiscal.TabIndex = 12
        Me.chbLetraFiscal.Text = "Letra"
        Me.chbLetraFiscal.UseVisualStyleBackColor = True
        '
        'cmbLetraFiscal
        '
        Me.cmbLetraFiscal.BindearPropiedadControl = Nothing
        Me.cmbLetraFiscal.BindearPropiedadEntidad = Nothing
        Me.cmbLetraFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLetraFiscal.Enabled = False
        Me.cmbLetraFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLetraFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLetraFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLetraFiscal.FormattingEnabled = True
        Me.cmbLetraFiscal.IsPK = False
        Me.cmbLetraFiscal.IsRequired = False
        Me.cmbLetraFiscal.Key = Nothing
        Me.cmbLetraFiscal.LabelAsoc = Me.chbLetraFiscal
        Me.cmbLetraFiscal.Location = New System.Drawing.Point(396, 48)
        Me.cmbLetraFiscal.Name = "cmbLetraFiscal"
        Me.cmbLetraFiscal.Size = New System.Drawing.Size(38, 21)
        Me.cmbLetraFiscal.TabIndex = 13
        '
        'lblEsResultante
        '
        Me.lblEsResultante.AutoSize = True
        Me.lblEsResultante.LabelAsoc = Nothing
        Me.lblEsResultante.Location = New System.Drawing.Point(31, 127)
        Me.lblEsResultante.Name = "lblEsResultante"
        Me.lblEsResultante.Size = New System.Drawing.Size(73, 13)
        Me.lblEsResultante.TabIndex = 40
        Me.lblEsResultante.Text = "Es Resultante"
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
        Me.chbEstado.Location = New System.Drawing.Point(15, 23)
        Me.chbEstado.Name = "chbEstado"
        Me.chbEstado.Size = New System.Drawing.Size(59, 17)
        Me.chbEstado.TabIndex = 0
        Me.chbEstado.Text = "Estado"
        '
        'cmbEsResultante
        '
        Me.cmbEsResultante.BindearPropiedadControl = ""
        Me.cmbEsResultante.BindearPropiedadEntidad = ""
        Me.cmbEsResultante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsResultante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEsResultante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsResultante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsResultante.FormattingEnabled = True
        Me.cmbEsResultante.IsPK = False
        Me.cmbEsResultante.IsRequired = False
        Me.cmbEsResultante.Key = Nothing
        Me.cmbEsResultante.LabelAsoc = Me.lblEsResultante
        Me.cmbEsResultante.Location = New System.Drawing.Point(134, 125)
        Me.cmbEsResultante.Name = "cmbEsResultante"
        Me.cmbEsResultante.Size = New System.Drawing.Size(140, 21)
        Me.cmbEsResultante.TabIndex = 41
        '
        'cmbEstados
        '
        Me.cmbEstados.BindearPropiedadControl = ""
        Me.cmbEstados.BindearPropiedadEntidad = ""
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.Enabled = False
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.IsPK = False
        Me.cmbEstados.IsRequired = False
        Me.cmbEstados.Key = Nothing
        Me.cmbEstados.LabelAsoc = Me.chbEstado
        Me.cmbEstados.Location = New System.Drawing.Point(134, 21)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstados.TabIndex = 1
        '
        'txtPlanMaestroNumero
        '
        Me.txtPlanMaestroNumero.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlanMaestroNumero.BindearPropiedadControl = Nothing
        Me.txtPlanMaestroNumero.BindearPropiedadEntidad = Nothing
        Me.txtPlanMaestroNumero.Enabled = False
        Me.txtPlanMaestroNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPlanMaestroNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPlanMaestroNumero.Formato = ""
        Me.txtPlanMaestroNumero.IsDecimal = False
        Me.txtPlanMaestroNumero.IsNumber = True
        Me.txtPlanMaestroNumero.IsPK = False
        Me.txtPlanMaestroNumero.IsRequired = False
        Me.txtPlanMaestroNumero.Key = ""
        Me.txtPlanMaestroNumero.LabelAsoc = Nothing
        Me.txtPlanMaestroNumero.Location = New System.Drawing.Point(891, 48)
        Me.txtPlanMaestroNumero.MaxLength = 8
        Me.txtPlanMaestroNumero.Name = "txtPlanMaestroNumero"
        Me.txtPlanMaestroNumero.Size = New System.Drawing.Size(54, 20)
        Me.txtPlanMaestroNumero.TabIndex = 21
        Me.txtPlanMaestroNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbPlanMaestroNumero
        '
        Me.chbPlanMaestroNumero.AutoSize = True
        Me.chbPlanMaestroNumero.BindearPropiedadControl = Nothing
        Me.chbPlanMaestroNumero.BindearPropiedadEntidad = Nothing
        Me.chbPlanMaestroNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPlanMaestroNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPlanMaestroNumero.IsPK = False
        Me.chbPlanMaestroNumero.IsRequired = False
        Me.chbPlanMaestroNumero.Key = Nothing
        Me.chbPlanMaestroNumero.LabelAsoc = Nothing
        Me.chbPlanMaestroNumero.Location = New System.Drawing.Point(794, 50)
        Me.chbPlanMaestroNumero.Name = "chbPlanMaestroNumero"
        Me.chbPlanMaestroNumero.Size = New System.Drawing.Size(88, 17)
        Me.chbPlanMaestroNumero.TabIndex = 20
        Me.chbPlanMaestroNumero.Text = "Plan Maestro"
        '
        'txtLineaPedido
        '
        Me.txtLineaPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtLineaPedido.BindearPropiedadControl = Nothing
        Me.txtLineaPedido.BindearPropiedadEntidad = Nothing
        Me.txtLineaPedido.Enabled = False
        Me.txtLineaPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLineaPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLineaPedido.Formato = ""
        Me.txtLineaPedido.IsDecimal = False
        Me.txtLineaPedido.IsNumber = True
        Me.txtLineaPedido.IsPK = False
        Me.txtLineaPedido.IsRequired = False
        Me.txtLineaPedido.Key = ""
        Me.txtLineaPedido.LabelAsoc = Nothing
        Me.txtLineaPedido.Location = New System.Drawing.Point(891, 98)
        Me.txtLineaPedido.MaxLength = 8
        Me.txtLineaPedido.Name = "txtLineaPedido"
        Me.txtLineaPedido.Size = New System.Drawing.Size(54, 20)
        Me.txtLineaPedido.TabIndex = 39
        Me.txtLineaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbLineaPedido
        '
        Me.chbLineaPedido.AutoSize = True
        Me.chbLineaPedido.BindearPropiedadControl = Nothing
        Me.chbLineaPedido.BindearPropiedadEntidad = Nothing
        Me.chbLineaPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLineaPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLineaPedido.IsPK = False
        Me.chbLineaPedido.IsRequired = False
        Me.chbLineaPedido.Key = Nothing
        Me.chbLineaPedido.LabelAsoc = Nothing
        Me.chbLineaPedido.Location = New System.Drawing.Point(794, 100)
        Me.chbLineaPedido.Name = "chbLineaPedido"
        Me.chbLineaPedido.Size = New System.Drawing.Size(52, 17)
        Me.chbLineaPedido.TabIndex = 38
        Me.chbLineaPedido.Text = "Linea"
        '
        'chbTipoComprobantePedido
        '
        Me.chbTipoComprobantePedido.AutoSize = True
        Me.chbTipoComprobantePedido.BindearPropiedadControl = Nothing
        Me.chbTipoComprobantePedido.BindearPropiedadEntidad = Nothing
        Me.chbTipoComprobantePedido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobantePedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobantePedido.IsPK = False
        Me.chbTipoComprobantePedido.IsRequired = False
        Me.chbTipoComprobantePedido.Key = Nothing
        Me.chbTipoComprobantePedido.LabelAsoc = Nothing
        Me.chbTipoComprobantePedido.Location = New System.Drawing.Point(15, 100)
        Me.chbTipoComprobantePedido.Name = "chbTipoComprobantePedido"
        Me.chbTipoComprobantePedido.Size = New System.Drawing.Size(83, 17)
        Me.chbTipoComprobantePedido.TabIndex = 28
        Me.chbTipoComprobantePedido.Text = "Tipo Pedido"
        '
        'cmbTipoComprobantePedido
        '
        Me.cmbTipoComprobantePedido.BindearPropiedadControl = ""
        Me.cmbTipoComprobantePedido.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobantePedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobantePedido.Enabled = False
        Me.cmbTipoComprobantePedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobantePedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobantePedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobantePedido.FormattingEnabled = True
        Me.cmbTipoComprobantePedido.IsPK = False
        Me.cmbTipoComprobantePedido.IsRequired = False
        Me.cmbTipoComprobantePedido.Key = Nothing
        Me.cmbTipoComprobantePedido.LabelAsoc = Nothing
        Me.cmbTipoComprobantePedido.Location = New System.Drawing.Point(134, 98)
        Me.cmbTipoComprobantePedido.Name = "cmbTipoComprobantePedido"
        Me.cmbTipoComprobantePedido.Size = New System.Drawing.Size(200, 21)
        Me.cmbTipoComprobantePedido.TabIndex = 29
        '
        'chbNumeroPedido
        '
        Me.chbNumeroPedido.AutoSize = True
        Me.chbNumeroPedido.BindearPropiedadControl = Nothing
        Me.chbNumeroPedido.BindearPropiedadEntidad = Nothing
        Me.chbNumeroPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroPedido.IsPK = False
        Me.chbNumeroPedido.IsRequired = False
        Me.chbNumeroPedido.Key = Nothing
        Me.chbNumeroPedido.LabelAsoc = Nothing
        Me.chbNumeroPedido.Location = New System.Drawing.Point(544, 100)
        Me.chbNumeroPedido.Name = "chbNumeroPedido"
        Me.chbNumeroPedido.Size = New System.Drawing.Size(63, 17)
        Me.chbNumeroPedido.TabIndex = 34
        Me.chbNumeroPedido.Text = "Número"
        Me.chbNumeroPedido.UseVisualStyleBackColor = True
        '
        'txtNumeroPedidoDesde
        '
        Me.txtNumeroPedidoDesde.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumeroPedidoDesde.BindearPropiedadControl = Nothing
        Me.txtNumeroPedidoDesde.BindearPropiedadEntidad = Nothing
        Me.txtNumeroPedidoDesde.Enabled = False
        Me.txtNumeroPedidoDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroPedidoDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroPedidoDesde.Formato = ""
        Me.txtNumeroPedidoDesde.IsDecimal = False
        Me.txtNumeroPedidoDesde.IsNumber = True
        Me.txtNumeroPedidoDesde.IsPK = False
        Me.txtNumeroPedidoDesde.IsRequired = False
        Me.txtNumeroPedidoDesde.Key = ""
        Me.txtNumeroPedidoDesde.LabelAsoc = Nothing
        Me.txtNumeroPedidoDesde.Location = New System.Drawing.Point(625, 98)
        Me.txtNumeroPedidoDesde.MaxLength = 8
        Me.txtNumeroPedidoDesde.Name = "txtNumeroPedidoDesde"
        Me.txtNumeroPedidoDesde.Size = New System.Drawing.Size(69, 20)
        Me.txtNumeroPedidoDesde.TabIndex = 35
        Me.txtNumeroPedidoDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscNombreProducto
        '
        Me.bscNombreProducto.ActivarFiltroEnGrilla = True
        Me.bscNombreProducto.BindearPropiedadControl = Nothing
        Me.bscNombreProducto.BindearPropiedadEntidad = Nothing
        Me.bscNombreProducto.ConfigBuscador = Nothing
        Me.bscNombreProducto.Datos = Nothing
        Me.bscNombreProducto.FilaDevuelta = Nothing
        Me.bscNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProducto.IsDecimal = False
        Me.bscNombreProducto.IsNumber = False
        Me.bscNombreProducto.IsPK = False
        Me.bscNombreProducto.IsRequired = False
        Me.bscNombreProducto.Key = ""
        Me.bscNombreProducto.LabelAsoc = Nothing
        Me.bscNombreProducto.Location = New System.Drawing.Point(286, 72)
        Me.bscNombreProducto.MaxLengh = "32767"
        Me.bscNombreProducto.Name = "bscNombreProducto"
        Me.bscNombreProducto.Permitido = False
        Me.bscNombreProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProducto.Selecciono = False
        Me.bscNombreProducto.Size = New System.Drawing.Size(253, 20)
        Me.bscNombreProducto.TabIndex = 24
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Nothing
        Me.bscCodigoProducto.Location = New System.Drawing.Point(134, 72)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = False
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto.TabIndex = 23
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.BindearPropiedadControl = Nothing
        Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobante.IsPK = False
        Me.chbTipoComprobante.IsRequired = False
        Me.chbTipoComprobante.Key = Nothing
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(15, 50)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 10
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        '
        'cmbTipoComprobante
        '
        Me.cmbTipoComprobante.BindearPropiedadControl = ""
        Me.cmbTipoComprobante.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobante.Enabled = False
        Me.cmbTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobante.FormattingEnabled = True
        Me.cmbTipoComprobante.IsPK = False
        Me.cmbTipoComprobante.IsRequired = False
        Me.cmbTipoComprobante.Key = Nothing
        Me.cmbTipoComprobante.LabelAsoc = Me.chbTipoComprobante
        Me.cmbTipoComprobante.Location = New System.Drawing.Point(134, 48)
        Me.cmbTipoComprobante.Name = "cmbTipoComprobante"
        Me.cmbTipoComprobante.Size = New System.Drawing.Size(200, 21)
        Me.cmbTipoComprobante.TabIndex = 11
        '
        'lblNumeroPedidoHasta
        '
        Me.lblNumeroPedidoHasta.AutoSize = True
        Me.lblNumeroPedidoHasta.LabelAsoc = Nothing
        Me.lblNumeroPedidoHasta.Location = New System.Drawing.Point(700, 102)
        Me.lblNumeroPedidoHasta.Name = "lblNumeroPedidoHasta"
        Me.lblNumeroPedidoHasta.Size = New System.Drawing.Size(13, 13)
        Me.lblNumeroPedidoHasta.TabIndex = 36
        Me.lblNumeroPedidoHasta.Text = "a"
        '
        'lblNumeroHasta
        '
        Me.lblNumeroHasta.AutoSize = True
        Me.lblNumeroHasta.LabelAsoc = Nothing
        Me.lblNumeroHasta.Location = New System.Drawing.Point(700, 52)
        Me.lblNumeroHasta.Name = "lblNumeroHasta"
        Me.lblNumeroHasta.Size = New System.Drawing.Size(13, 13)
        Me.lblNumeroHasta.TabIndex = 18
        Me.lblNumeroHasta.Text = "a"
        '
        'chbOrdenProduccion
        '
        Me.chbOrdenProduccion.AutoSize = True
        Me.chbOrdenProduccion.BindearPropiedadControl = Nothing
        Me.chbOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.chbOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenProduccion.IsPK = False
        Me.chbOrdenProduccion.IsRequired = False
        Me.chbOrdenProduccion.Key = Nothing
        Me.chbOrdenProduccion.LabelAsoc = Nothing
        Me.chbOrdenProduccion.Location = New System.Drawing.Point(545, 50)
        Me.chbOrdenProduccion.Name = "chbOrdenProduccion"
        Me.chbOrdenProduccion.Size = New System.Drawing.Size(63, 17)
        Me.chbOrdenProduccion.TabIndex = 16
        Me.chbOrdenProduccion.Text = "Número"
        Me.chbOrdenProduccion.UseVisualStyleBackColor = True
        '
        'txtNumeroPedidoHasta
        '
        Me.txtNumeroPedidoHasta.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumeroPedidoHasta.BindearPropiedadControl = Nothing
        Me.txtNumeroPedidoHasta.BindearPropiedadEntidad = Nothing
        Me.txtNumeroPedidoHasta.Enabled = False
        Me.txtNumeroPedidoHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroPedidoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroPedidoHasta.Formato = ""
        Me.txtNumeroPedidoHasta.IsDecimal = False
        Me.txtNumeroPedidoHasta.IsNumber = True
        Me.txtNumeroPedidoHasta.IsPK = False
        Me.txtNumeroPedidoHasta.IsRequired = False
        Me.txtNumeroPedidoHasta.Key = ""
        Me.txtNumeroPedidoHasta.LabelAsoc = Nothing
        Me.txtNumeroPedidoHasta.Location = New System.Drawing.Point(719, 98)
        Me.txtNumeroPedidoHasta.MaxLength = 6
        Me.txtNumeroPedidoHasta.Name = "txtNumeroPedidoHasta"
        Me.txtNumeroPedidoHasta.Size = New System.Drawing.Size(69, 20)
        Me.txtNumeroPedidoHasta.TabIndex = 37
        Me.txtNumeroPedidoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumeroHasta
        '
        Me.txtNumeroHasta.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumeroHasta.BindearPropiedadControl = Nothing
        Me.txtNumeroHasta.BindearPropiedadEntidad = Nothing
        Me.txtNumeroHasta.Enabled = False
        Me.txtNumeroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroHasta.Formato = ""
        Me.txtNumeroHasta.IsDecimal = False
        Me.txtNumeroHasta.IsNumber = True
        Me.txtNumeroHasta.IsPK = False
        Me.txtNumeroHasta.IsRequired = False
        Me.txtNumeroHasta.Key = ""
        Me.txtNumeroHasta.LabelAsoc = Nothing
        Me.txtNumeroHasta.Location = New System.Drawing.Point(719, 48)
        Me.txtNumeroHasta.MaxLength = 6
        Me.txtNumeroHasta.Name = "txtNumeroHasta"
        Me.txtNumeroHasta.Size = New System.Drawing.Size(69, 20)
        Me.txtNumeroHasta.TabIndex = 19
        Me.txtNumeroHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumeroDesde
        '
        Me.txtNumeroDesde.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumeroDesde.BindearPropiedadControl = Nothing
        Me.txtNumeroDesde.BindearPropiedadEntidad = Nothing
        Me.txtNumeroDesde.Enabled = False
        Me.txtNumeroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroDesde.Formato = ""
        Me.txtNumeroDesde.IsDecimal = False
        Me.txtNumeroDesde.IsNumber = True
        Me.txtNumeroDesde.IsPK = False
        Me.txtNumeroDesde.IsRequired = False
        Me.txtNumeroDesde.Key = ""
        Me.txtNumeroDesde.LabelAsoc = Nothing
        Me.txtNumeroDesde.Location = New System.Drawing.Point(625, 48)
        Me.txtNumeroDesde.MaxLength = 6
        Me.txtNumeroDesde.Name = "txtNumeroDesde"
        Me.txtNumeroDesde.Size = New System.Drawing.Size(69, 20)
        Me.txtNumeroDesde.TabIndex = 17
        Me.txtNumeroDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbFecha
        '
        Me.chbFecha.AutoSize = True
        Me.chbFecha.BindearPropiedadControl = Nothing
        Me.chbFecha.BindearPropiedadEntidad = Nothing
        Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFecha.IsPK = False
        Me.chbFecha.IsRequired = False
        Me.chbFecha.Key = Nothing
        Me.chbFecha.LabelAsoc = Nothing
        Me.chbFecha.Location = New System.Drawing.Point(440, 23)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 4
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.ActivarFiltroEnGrilla = True
        Me.bscNombreCliente.BindearPropiedadControl = Nothing
        Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
        Me.bscNombreCliente.ConfigBuscador = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Me.chbCliente
        Me.bscNombreCliente.Location = New System.Drawing.Point(719, 72)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = False
        Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(255, 20)
        Me.bscNombreCliente.TabIndex = 27
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
        Me.chbCliente.Location = New System.Drawing.Point(545, 74)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 25
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
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.chbCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(625, 72)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(92, 20)
        Me.bscCodigoCliente.TabIndex = 26
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
        Me.chbProducto.Location = New System.Drawing.Point(15, 74)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 22
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(502, 23)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 5
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(827, 21)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 9
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Me.chkMesCompleto
        Me.lblHasta.Location = New System.Drawing.Point(788, 25)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 8
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(645, 21)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 7
        Me.dtpDesde.Value = New Date(2021, 8, 3, 8, 32, 0, 0)
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Me.chkMesCompleto
        Me.lblDesde.Location = New System.Drawing.Point(601, 25)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 6
        Me.lblDesde.Text = "Desde"
        '
        'btnConsultar
        '
        Me.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(870, 3)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tspBarra
        '
        Me.tspBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tspBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator5, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tspBarra.Location = New System.Drawing.Point(0, 0)
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(984, 29)
        Me.tspBarra.TabIndex = 4
        Me.tspBarra.Text = "ToolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnConsultar)
        Me.Panel1.Controls.Add(Me.ugDetalle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 195)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 344)
        Me.Panel1.TabIndex = 5
        '
        'splitter1
        '
        Me.splitter1.BackColor = System.Drawing.SystemColors.Control
        Me.splitter1.ButtonExtent = 360
        Me.splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitter1.Location = New System.Drawing.Point(0, 180)
        Me.splitter1.MinSize = 45
        Me.splitter1.Name = "splitter1"
        Me.splitter1.RestoreExtent = 151
        Me.splitter1.Size = New System.Drawing.Size(984, 15)
        Me.splitter1.TabIndex = 9
        '
        'InfOrdenesProduccionMRPProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.splitter1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.gpbFiltroDeclaracion)
        Me.Controls.Add(Me.tspBarra)
        Me.Name = "InfOrdenesProduccionMRPProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inf. Detalle Operaciones de Orden Producción"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFiltroDeclaracion.ResumeLayout(False)
        Me.gpbFiltroDeclaracion.PerformLayout()
        Me.tspBarra.ResumeLayout(False)
        Me.tspBarra.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected WithEvents tssRegistros As ToolStripStatusLabel
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents stsStado As StatusStrip
   Protected Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
   Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
   Friend WithEvents sfdExportar As SaveFileDialog
   Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents gpbFiltroDeclaracion As GroupBox
   Friend WithEvents chbProducto As Controles.CheckBox
   Friend WithEvents chkMesCompleto As Controles.CheckBox
   Friend WithEvents btnConsultar As Controles.Button
   Friend WithEvents dtpHasta As Controles.DateTimePicker
   Friend WithEvents lblHasta As Controles.Label
   Friend WithEvents dtpDesde As Controles.DateTimePicker
   Friend WithEvents lblDesde As Controles.Label
   Friend WithEvents tspBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
   Friend WithEvents tsbImprimir As ToolStripButton
   Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
   Friend WithEvents tsddExportar As ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As ToolStripMenuItem
   Friend WithEvents tsmiAPDF As ToolStripMenuItem
   Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
   Public WithEvents tsbPreferencias As ToolStripButton
   Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
   Friend WithEvents tsbSalir As ToolStripButton
   Friend WithEvents bscNombreCliente As Controles.Buscador2
   Friend WithEvents chbCliente As Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Controles.Buscador2
   Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
   Friend WithEvents chbFecha As Controles.CheckBox
   Friend WithEvents chbTipoComprobante As Controles.CheckBox
   Friend WithEvents cmbTipoComprobante As Controles.ComboBox
   Friend WithEvents chbOrdenProduccion As Controles.CheckBox
   Friend WithEvents txtNumeroDesde As Controles.TextBox
   Friend WithEvents bscNombreProducto As Controles.Buscador2
   Friend WithEvents bscCodigoProducto As Controles.Buscador2
   Friend WithEvents txtLineaPedido As Controles.TextBox
   Friend WithEvents chbLineaPedido As Controles.CheckBox
   Friend WithEvents chbTipoComprobantePedido As Controles.CheckBox
   Friend WithEvents cmbTipoComprobantePedido As Controles.ComboBox
   Friend WithEvents chbNumeroPedido As Controles.CheckBox
   Friend WithEvents txtNumeroPedidoDesde As Controles.TextBox
   Friend WithEvents chbEstado As Controles.CheckBox
   Friend WithEvents cmbEstados As Controles.ComboBox
   Friend WithEvents chbCentroEmisor As Controles.CheckBox
   Friend WithEvents cmbCentroEmisor As Controles.ComboBox
   Friend WithEvents chbLetraFiscal As Controles.CheckBox
   Friend WithEvents cmbLetraFiscal As Controles.ComboBox
   Friend WithEvents lblNumeroHasta As Controles.Label
   Friend WithEvents txtNumeroHasta As Controles.TextBox
   Friend WithEvents chbCentroEmisorPedido As Controles.CheckBox
   Friend WithEvents cmbCentroEmisorPedido As Controles.ComboBox
   Friend WithEvents chbLetraFiscalPedido As Controles.CheckBox
   Friend WithEvents cmbLetraFiscalPedido As Controles.ComboBox
   Friend WithEvents lblNumeroPedidoHasta As Controles.Label
   Friend WithEvents txtNumeroPedidoHasta As Controles.TextBox
   Friend WithEvents txtPlanMaestroNumero As Controles.TextBox
   Friend WithEvents chbPlanMaestroNumero As Controles.CheckBox
   Friend WithEvents txtCodigoOperacion As Controles.TextBox
   Friend WithEvents chbCodigoOperacion As Controles.CheckBox
   Friend WithEvents lblEsResultante As Controles.Label
   Friend WithEvents cmbEsResultante As Controles.ComboBox
   Friend WithEvents Panel1 As Panel
   Friend WithEvents splitter1 As Misc.UltraSplitter
End Class
