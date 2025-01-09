<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProcesoDeclaracionProduccion
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadPedida")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadPendiente")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaOrdenProduccion")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idProducto")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProcesoProductivo")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionProceso")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido", 0)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenPedido", 1)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcesoDeclaracionProduccion))
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
        Me.txtLineaPedido = New Eniac.Controles.TextBox()
        Me.lblLineaVta = New Eniac.Controles.Label()
        Me.Label4 = New Eniac.Controles.Label()
        Me.cmbTipoComprobantePedido = New Eniac.Controles.ComboBox()
        Me.chbPedidoVta = New Eniac.Controles.CheckBox()
        Me.txtNroPedido = New Eniac.Controles.TextBox()
        Me.bscNombreProducto = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.cmbTipoComprobanteOP = New Eniac.Controles.ComboBox()
        Me.chbOrdenProduccion = New Eniac.Controles.CheckBox()
        Me.txtIdOrdenProduccion = New Eniac.Controles.TextBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.bscNombreCliente = New Eniac.Controles.Buscador2()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.tspBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbInformar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFiltroDeclaracion.SuspendLayout()
        Me.tspBarra.SuspendLayout()
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
        Me.tssInfo.Size = New System.Drawing.Size(841, 17)
        Me.tssInfo.Spring = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.ToolStripProgressBar1, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(920, 22)
        Me.stsStado.TabIndex = 2
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
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn3.Header.Caption = "Comprobante"
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn4.Header.Caption = "L"
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn6.Header.Caption = "Emisor"
        UltraGridColumn6.Header.VisiblePosition = 2
        UltraGridColumn7.Header.Caption = "Numero"
        UltraGridColumn7.Header.VisiblePosition = 3
        UltraGridColumn8.Header.VisiblePosition = 4
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.Caption = "Cant. Pedida"
        UltraGridColumn9.Header.VisiblePosition = 5
        UltraGridColumn10.Header.Caption = "Cant. Pendiente"
        UltraGridColumn10.Header.VisiblePosition = 6
        UltraGridColumn11.Header.Caption = "Fecha"
        UltraGridColumn11.Header.VisiblePosition = 7
        UltraGridColumn12.Header.VisiblePosition = 8
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.Caption = "Cliente"
        UltraGridColumn13.Header.VisiblePosition = 9
        UltraGridColumn14.Header.VisiblePosition = 10
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.Header.Caption = "Producto"
        UltraGridColumn15.Header.VisiblePosition = 11
        UltraGridColumn16.Header.VisiblePosition = 12
        UltraGridColumn16.Hidden = True
        UltraGridColumn22.Header.Caption = "Descripcion Proceso"
        UltraGridColumn22.Header.VisiblePosition = 13
        UltraGridColumn23.Header.VisiblePosition = 14
        UltraGridColumn23.Hidden = True
        UltraGridColumn1.Header.VisiblePosition = 15
        UltraGridColumn2.Header.VisiblePosition = 16
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn3, UltraGridColumn4, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn22, UltraGridColumn23, UltraGridColumn1, UltraGridColumn2})
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
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 154)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(920, 385)
        Me.ugDetalle.TabIndex = 1
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
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtLineaPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblLineaVta)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.Label4)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbTipoComprobantePedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbPedidoVta)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtNroPedido)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.bscNombreProducto)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.bscCodigoProducto)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblTipoComprobante)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.cmbTipoComprobanteOP)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbOrdenProduccion)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.txtIdOrdenProduccion)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbFecha)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.bscNombreCliente)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.bscCodigoCliente)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbCliente)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chbProducto)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.chkMesCompleto)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.btnConsultar)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.dtpHasta)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.dtpDesde)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblDesde)
        Me.gpbFiltroDeclaracion.Controls.Add(Me.lblHasta)
        Me.gpbFiltroDeclaracion.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltroDeclaracion.Location = New System.Drawing.Point(0, 29)
        Me.gpbFiltroDeclaracion.Name = "gpbFiltroDeclaracion"
        Me.gpbFiltroDeclaracion.Size = New System.Drawing.Size(920, 125)
        Me.gpbFiltroDeclaracion.TabIndex = 0
        Me.gpbFiltroDeclaracion.TabStop = False
        Me.gpbFiltroDeclaracion.Text = "Producción"
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
        Me.txtLineaPedido.Location = New System.Drawing.Point(286, 98)
        Me.txtLineaPedido.MaxLength = 8
        Me.txtLineaPedido.Name = "txtLineaPedido"
        Me.txtLineaPedido.Size = New System.Drawing.Size(54, 20)
        Me.txtLineaPedido.TabIndex = 19
        Me.txtLineaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLineaVta
        '
        Me.lblLineaVta.AutoSize = True
        Me.lblLineaVta.LabelAsoc = Nothing
        Me.lblLineaVta.Location = New System.Drawing.Point(247, 102)
        Me.lblLineaVta.Name = "lblLineaVta"
        Me.lblLineaVta.Size = New System.Drawing.Size(33, 13)
        Me.lblLineaVta.TabIndex = 18
        Me.lblLineaVta.Text = "Linea"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(346, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Comprobante"
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
        Me.cmbTipoComprobantePedido.Location = New System.Drawing.Point(422, 97)
        Me.cmbTipoComprobantePedido.Name = "cmbTipoComprobantePedido"
        Me.cmbTipoComprobantePedido.Size = New System.Drawing.Size(200, 21)
        Me.cmbTipoComprobantePedido.TabIndex = 21
        '
        'chbPedidoVta
        '
        Me.chbPedidoVta.AutoSize = True
        Me.chbPedidoVta.BindearPropiedadControl = Nothing
        Me.chbPedidoVta.BindearPropiedadEntidad = Nothing
        Me.chbPedidoVta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidoVta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidoVta.IsPK = False
        Me.chbPedidoVta.IsRequired = False
        Me.chbPedidoVta.Key = Nothing
        Me.chbPedidoVta.LabelAsoc = Nothing
        Me.chbPedidoVta.Location = New System.Drawing.Point(16, 102)
        Me.chbPedidoVta.Name = "chbPedidoVta"
        Me.chbPedidoVta.Size = New System.Drawing.Size(81, 17)
        Me.chbPedidoVta.TabIndex = 16
        Me.chbPedidoVta.Text = "Pedido Vta."
        Me.chbPedidoVta.UseVisualStyleBackColor = True
        '
        'txtNroPedido
        '
        Me.txtNroPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroPedido.BindearPropiedadControl = Nothing
        Me.txtNroPedido.BindearPropiedadEntidad = Nothing
        Me.txtNroPedido.Enabled = False
        Me.txtNroPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPedido.Formato = ""
        Me.txtNroPedido.IsDecimal = False
        Me.txtNroPedido.IsNumber = True
        Me.txtNroPedido.IsPK = False
        Me.txtNroPedido.IsRequired = False
        Me.txtNroPedido.Key = ""
        Me.txtNroPedido.LabelAsoc = Nothing
        Me.txtNroPedido.Location = New System.Drawing.Point(97, 99)
        Me.txtNroPedido.MaxLength = 8
        Me.txtNroPedido.Name = "txtNroPedido"
        Me.txtNroPedido.Size = New System.Drawing.Size(147, 20)
        Me.txtNroPedido.TabIndex = 17
        Me.txtNroPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscNombreProducto
        '
        Me.bscNombreProducto.ActivarFiltroEnGrilla = True
        Me.bscNombreProducto.BindearPropiedadControl = Nothing
        Me.bscNombreProducto.BindearPropiedadEntidad = Nothing
        Me.bscNombreProducto.ConfigBuscador = Nothing
        Me.bscNombreProducto.Datos = Nothing
        Me.bscNombreProducto.Enabled = False
        Me.bscNombreProducto.FilaDevuelta = Nothing
        Me.bscNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProducto.IsDecimal = False
        Me.bscNombreProducto.IsNumber = False
        Me.bscNombreProducto.IsPK = False
        Me.bscNombreProducto.IsRequired = False
        Me.bscNombreProducto.Key = ""
        Me.bscNombreProducto.LabelAsoc = Nothing
        Me.bscNombreProducto.Location = New System.Drawing.Point(250, 44)
        Me.bscNombreProducto.MaxLengh = "32767"
        Me.bscNombreProducto.Name = "bscNombreProducto"
        Me.bscNombreProducto.Permitido = True
        Me.bscNombreProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProducto.Selecciono = False
        Me.bscNombreProducto.Size = New System.Drawing.Size(337, 20)
        Me.bscNombreProducto.TabIndex = 12
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.Enabled = False
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Nothing
        Me.bscCodigoProducto.Location = New System.Drawing.Point(98, 44)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = True
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto.TabIndex = 11
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(600, 48)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobante.TabIndex = 8
        Me.lblTipoComprobante.Text = "Tipo Comprobante"
        '
        'cmbTipoComprobanteOP
        '
        Me.cmbTipoComprobanteOP.BindearPropiedadControl = ""
        Me.cmbTipoComprobanteOP.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobanteOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteOP.Enabled = False
        Me.cmbTipoComprobanteOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteOP.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteOP.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteOP.FormattingEnabled = True
        Me.cmbTipoComprobanteOP.IsPK = False
        Me.cmbTipoComprobanteOP.IsRequired = False
        Me.cmbTipoComprobanteOP.Key = Nothing
        Me.cmbTipoComprobanteOP.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTipoComprobanteOP.Location = New System.Drawing.Point(700, 45)
        Me.cmbTipoComprobanteOP.Name = "cmbTipoComprobanteOP"
        Me.cmbTipoComprobanteOP.Size = New System.Drawing.Size(200, 21)
        Me.cmbTipoComprobanteOP.TabIndex = 9
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
        Me.chbOrdenProduccion.Location = New System.Drawing.Point(603, 19)
        Me.chbOrdenProduccion.Name = "chbOrdenProduccion"
        Me.chbOrdenProduccion.Size = New System.Drawing.Size(127, 17)
        Me.chbOrdenProduccion.TabIndex = 6
        Me.chbOrdenProduccion.Text = "Orden de Producción"
        Me.chbOrdenProduccion.UseVisualStyleBackColor = True
        '
        'txtIdOrdenProduccion
        '
        Me.txtIdOrdenProduccion.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdOrdenProduccion.BindearPropiedadControl = Nothing
        Me.txtIdOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.txtIdOrdenProduccion.Enabled = False
        Me.txtIdOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdOrdenProduccion.Formato = ""
        Me.txtIdOrdenProduccion.IsDecimal = False
        Me.txtIdOrdenProduccion.IsNumber = True
        Me.txtIdOrdenProduccion.IsPK = False
        Me.txtIdOrdenProduccion.IsRequired = False
        Me.txtIdOrdenProduccion.Key = ""
        Me.txtIdOrdenProduccion.LabelAsoc = Nothing
        Me.txtIdOrdenProduccion.Location = New System.Drawing.Point(733, 16)
        Me.txtIdOrdenProduccion.MaxLength = 6
        Me.txtIdOrdenProduccion.Name = "txtIdOrdenProduccion"
        Me.txtIdOrdenProduccion.Size = New System.Drawing.Size(69, 20)
        Me.txtIdOrdenProduccion.TabIndex = 7
        Me.txtIdOrdenProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.chbFecha.Location = New System.Drawing.Point(16, 21)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 0
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
        Me.bscNombreCliente.Enabled = False
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Me.chbCliente
        Me.bscNombreCliente.Location = New System.Drawing.Point(250, 72)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = True
        Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(337, 20)
        Me.bscNombreCliente.TabIndex = 15
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
        Me.chbCliente.Location = New System.Drawing.Point(16, 74)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 13
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
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.chbCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(96, 72)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(148, 20)
        Me.bscCodigoCliente.TabIndex = 14
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
        Me.chbProducto.Location = New System.Drawing.Point(16, 47)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 10
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(97, 21)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 1
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(804, 88)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 22
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(422, 19)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Me.chkMesCompleto
        Me.lblHasta.Location = New System.Drawing.Point(383, 23)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.Checked = False
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(240, 19)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 3
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Me.chkMesCompleto
        Me.lblDesde.Location = New System.Drawing.Point(196, 23)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 2
        Me.lblDesde.Text = "Desde"
        '
        'tspBarra
        '
        Me.tspBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tspBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator5, Me.tsbInformar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tspBarra.Location = New System.Drawing.Point(0, 0)
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(920, 29)
        Me.tspBarra.TabIndex = 3
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
        'tsbInformar
        '
        Me.tsbInformar.Enabled = False
        Me.tsbInformar.Image = Global.Eniac.Win.My.Resources.Resources.add_24
        Me.tsbInformar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInformar.Name = "tsbInformar"
        Me.tsbInformar.Size = New System.Drawing.Size(102, 26)
        Me.tsbInformar.Text = "Informar (F4)"
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
        'ProcesoDeclaracionProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 561)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.gpbFiltroDeclaracion)
        Me.Controls.Add(Me.tspBarra)
        Me.Name = "ProcesoDeclaracionProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proceso Declaracion de Produccion"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFiltroDeclaracion.ResumeLayout(False)
        Me.gpbFiltroDeclaracion.PerformLayout()
        Me.tspBarra.ResumeLayout(False)
        Me.tspBarra.PerformLayout()
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
   Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
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
   Friend WithEvents tsbInformar As ToolStripButton
   Friend WithEvents chbFecha As Controles.CheckBox
   Friend WithEvents lblTipoComprobante As Controles.Label
   Friend WithEvents cmbTipoComprobanteOP As Controles.ComboBox
   Friend WithEvents chbOrdenProduccion As Controles.CheckBox
   Friend WithEvents txtIdOrdenProduccion As Controles.TextBox
   Friend WithEvents bscNombreProducto As Controles.Buscador2
   Friend WithEvents bscCodigoProducto As Controles.Buscador2
    Friend WithEvents txtLineaPedido As Controles.TextBox
    Friend WithEvents lblLineaVta As Controles.Label
    Friend WithEvents Label4 As Controles.Label
    Friend WithEvents cmbTipoComprobantePedido As Controles.ComboBox
    Friend WithEvents chbPedidoVta As Controles.CheckBox
    Friend WithEvents txtNroPedido As Controles.TextBox
End Class
