<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidosAdminProv
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Color")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("masivo")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCriticidad")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocumento")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstado")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoEstado")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEntregada")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantPendiente")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteFact")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraFact")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorFact")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteFact")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadNuevoEstado")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProductoProveedor")
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
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PedidosAdminProv))
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbModificarPedido = New System.Windows.Forms.ToolStripButton()
        Me.tsbConvertirEnFactura = New System.Windows.Forms.ToolStripButton()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.grpFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.chbOrdenCompra = New Eniac.Controles.CheckBox()
        Me.txtOrdenCompra = New Eniac.Controles.TextBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.chbSubRubro = New Eniac.Controles.CheckBox()
        Me.cmbSubRubro = New Eniac.Controles.ComboBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.lblEstados = New Eniac.Controles.Label()
        Me.cmbEstados = New Eniac.Controles.ComboBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbIdPedido = New Eniac.Controles.CheckBox()
        Me.txtIdPedido = New Eniac.Controles.TextBox()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.bscProveedor = New Eniac.Controles.Buscador2()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.grpOperaciones = New System.Windows.Forms.GroupBox()
        Me.chbGeneraUnPedidoPorProveedor = New Eniac.Controles.CheckBox()
        Me.lblCantidadObservaciones = New Eniac.Controles.Label()
        Me.lblFechaEntrega = New Eniac.Controles.Label()
        Me.lblCriticidad = New Eniac.Controles.Label()
        Me.dtpFechaEntrega = New Eniac.Controles.DateTimePicker()
        Me.cmbCriticidad = New Eniac.Controles.ComboBox()
        Me.btnMasivo = New System.Windows.Forms.Button()
        Me.txtCantidad = New Eniac.Controles.TextBox()
        Me.lblCantidad = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.lblObservacion = New Eniac.Controles.Label()
        Me.cmbEstadoCambiar = New Eniac.Controles.ComboBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grpFiltros.SuspendLayout()
        Me.grpOperaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 30
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn36.Header.Appearance = Appearance2
        UltraGridColumn36.Header.Caption = "Masivo"
        UltraGridColumn36.Header.VisiblePosition = 1
        UltraGridColumn36.MaxWidth = 50
        UltraGridColumn36.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn36.Width = 50
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.Caption = "Tipo"
        UltraGridColumn20.Header.VisiblePosition = 4
        UltraGridColumn20.Width = 90
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn21.CellAppearance = Appearance3
        UltraGridColumn21.Header.Caption = "L."
        UltraGridColumn21.Header.VisiblePosition = 5
        UltraGridColumn21.Width = 25
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance4
        UltraGridColumn22.Header.Caption = "Emis."
        UltraGridColumn22.Header.VisiblePosition = 6
        UltraGridColumn22.Width = 40
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance5
        UltraGridColumn29.Header.Caption = "Pedido"
        UltraGridColumn29.Header.VisiblePosition = 7
        UltraGridColumn29.Width = 70
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance6
        UltraGridColumn4.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn4.Header.Caption = "Fecha Pedido"
        UltraGridColumn4.Header.VisiblePosition = 9
        UltraGridColumn4.Width = 85
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "Criticidad"
        UltraGridColumn5.Header.VisiblePosition = 8
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Format = "dd/MM/yyyy"
        UltraGridColumn6.Header.Caption = "Fecha Entrega"
        UltraGridColumn6.Header.VisiblePosition = 10
        UltraGridColumn6.Width = 85
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn30.Header.VisiblePosition = 12
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn31.Header.VisiblePosition = 14
        UltraGridColumn31.Hidden = True
        UltraGridColumn31.Width = 80
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 11
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 13
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "Nombre Proveedor"
        UltraGridColumn9.Header.VisiblePosition = 15
        UltraGridColumn9.Width = 150
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.Caption = "Nombre Producto"
        UltraGridColumn11.Header.VisiblePosition = 18
        UltraGridColumn11.Width = 200
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance7
        UltraGridColumn12.Format = "#,##0.00"
        UltraGridColumn12.Header.Caption = "Tamaño"
        UltraGridColumn12.Header.VisiblePosition = 19
        UltraGridColumn12.Width = 60
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.VisiblePosition = 21
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance8
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.Caption = "Cant. Pedida"
        UltraGridColumn14.Header.VisiblePosition = 23
        UltraGridColumn14.Width = 70
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn15.CellAppearance = Appearance9
        UltraGridColumn15.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn15.Header.Caption = "Fecha Estado"
        UltraGridColumn15.Header.VisiblePosition = 22
        UltraGridColumn15.Width = 100
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.Caption = "Estado"
        UltraGridColumn16.Header.VisiblePosition = 3
        UltraGridColumn16.Width = 90
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.VisiblePosition = 24
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance10
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.Caption = "Cant. Involucrada"
        UltraGridColumn18.Header.VisiblePosition = 25
        UltraGridColumn18.Width = 70
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance11
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "Cant. Pendiente"
        UltraGridColumn19.Header.VisiblePosition = 26
        UltraGridColumn19.Width = 70
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn32.Header.Caption = "Comprobante"
        UltraGridColumn32.Header.VisiblePosition = 28
        UltraGridColumn32.Width = 90
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance12
        UltraGridColumn33.Header.Caption = "Let."
        UltraGridColumn33.Header.VisiblePosition = 29
        UltraGridColumn33.Width = 30
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance13
        UltraGridColumn34.Header.Caption = "Emis."
        UltraGridColumn34.Header.VisiblePosition = 30
        UltraGridColumn34.Width = 40
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance14
        UltraGridColumn35.Header.Caption = "Nro. Compro."
        UltraGridColumn35.Header.VisiblePosition = 31
        UltraGridColumn35.Width = 70
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.Header.Caption = "Usuario"
        UltraGridColumn24.Header.VisiblePosition = 33
        UltraGridColumn24.Width = 75
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn25.Header.VisiblePosition = 32
        UltraGridColumn25.Width = 200
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.Caption = "Marca"
        UltraGridColumn26.Header.VisiblePosition = 34
        UltraGridColumn26.Width = 200
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.Header.Caption = "Rubro"
        UltraGridColumn27.Header.VisiblePosition = 35
        UltraGridColumn27.Width = 200
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance15
        UltraGridColumn3.Header.Caption = "U. M."
        UltraGridColumn3.Header.VisiblePosition = 20
        UltraGridColumn3.Width = 40
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance16
        UltraGridColumn23.Header.Caption = "O. C."
        UltraGridColumn23.Header.VisiblePosition = 36
        UltraGridColumn23.Width = 80
        Appearance17.BackColor = System.Drawing.Color.LightCyan
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance17
        UltraGridColumn28.Format = "N2"
        UltraGridColumn28.Header.Caption = "Cant. Nuevo Estado"
        UltraGridColumn28.Header.VisiblePosition = 27
        UltraGridColumn28.MaskInput = "{double:-12.2}"
        UltraGridColumn28.Width = 73
        UltraGridColumn10.Header.Caption = "Código Producto"
        UltraGridColumn10.Header.VisiblePosition = 16
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 80
        UltraGridColumn37.Header.Caption = "Codigo Prod. Proveedor"
        UltraGridColumn37.Header.VisiblePosition = 17
        UltraGridColumn37.Hidden = True
        UltraGridColumn37.Width = 80
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn36, UltraGridColumn2, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn29, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn30, UltraGridColumn31, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn3, UltraGridColumn23, UltraGridColumn28, UltraGridColumn10, UltraGridColumn37})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance18
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance20.BackColor2 = System.Drawing.SystemColors.Control
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.SystemColors.Highlight
        Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance22
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance23
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance24
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance25.BackColor = System.Drawing.SystemColors.Control
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance25
        Appearance26.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance26
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 221)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1130, 310)
        Me.ugDetalle.TabIndex = 2
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 531)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1130, 22)
        Me.stsStado.TabIndex = 3
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1051, 17)
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
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
        Me.chbProducto.Location = New System.Drawing.Point(11, 71)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 21
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbModificarPedido, Me.tsbConvertirEnFactura, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.toolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1130, 29)
        Me.tstBarra.TabIndex = 4
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbModificarPedido
        '
        Me.tsbModificarPedido.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.tsbModificarPedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbModificarPedido.Name = "tsbModificarPedido"
        Me.tsbModificarPedido.Size = New System.Drawing.Size(124, 26)
        Me.tsbModificarPedido.Text = "Modificar Pedido"
        '
        'tsbConvertirEnFactura
        '
        Me.tsbConvertirEnFactura.Image = Global.Eniac.Win.My.Resources.Resources.documents
        Me.tsbConvertirEnFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConvertirEnFactura.Name = "tsbConvertirEnFactura"
        Me.tsbConvertirEnFactura.Size = New System.Drawing.Size(140, 26)
        Me.tsbConvertirEnFactura.Text = "Convertir en Factura"
        Me.tsbConvertirEnFactura.Visible = False
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grpFiltros.Controls.Add(Me.lblTipoComprobante)
        Me.grpFiltros.Controls.Add(Me.chbOrdenCompra)
        Me.grpFiltros.Controls.Add(Me.txtOrdenCompra)
        Me.grpFiltros.Controls.Add(Me.bscProducto2)
        Me.grpFiltros.Controls.Add(Me.bscCodigoProducto2)
        Me.grpFiltros.Controls.Add(Me.chbMarca)
        Me.grpFiltros.Controls.Add(Me.cmbMarca)
        Me.grpFiltros.Controls.Add(Me.chbSubRubro)
        Me.grpFiltros.Controls.Add(Me.cmbSubRubro)
        Me.grpFiltros.Controls.Add(Me.chbRubro)
        Me.grpFiltros.Controls.Add(Me.cmbRubro)
        Me.grpFiltros.Controls.Add(Me.chkExpandAll)
        Me.grpFiltros.Controls.Add(Me.chbFecha)
        Me.grpFiltros.Controls.Add(Me.lblEstados)
        Me.grpFiltros.Controls.Add(Me.cmbEstados)
        Me.grpFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grpFiltros.Controls.Add(Me.dtpHasta)
        Me.grpFiltros.Controls.Add(Me.dtpDesde)
        Me.grpFiltros.Controls.Add(Me.lblHasta)
        Me.grpFiltros.Controls.Add(Me.lblDesde)
        Me.grpFiltros.Controls.Add(Me.chbIdPedido)
        Me.grpFiltros.Controls.Add(Me.txtIdPedido)
        Me.grpFiltros.Controls.Add(Me.chbProveedor)
        Me.grpFiltros.Controls.Add(Me.bscCodigoProveedor)
        Me.grpFiltros.Controls.Add(Me.bscProveedor)
        Me.grpFiltros.Controls.Add(Me.chbProducto)
        Me.grpFiltros.Controls.Add(Me.btnConsultar)
        Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(1130, 120)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        Me.grpFiltros.Text = "Filtros"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(805, 15)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
        Me.cmbTiposComprobantes.TabIndex = 9
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(723, 19)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(76, 13)
        Me.lblTipoComprobante.TabIndex = 8
        Me.lblTipoComprobante.Text = "Tipo Comprob."
        '
        'chbOrdenCompra
        '
        Me.chbOrdenCompra.AutoSize = True
        Me.chbOrdenCompra.BindearPropiedadControl = Nothing
        Me.chbOrdenCompra.BindearPropiedadEntidad = Nothing
        Me.chbOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenCompra.IsPK = False
        Me.chbOrdenCompra.IsRequired = False
        Me.chbOrdenCompra.Key = Nothing
        Me.chbOrdenCompra.LabelAsoc = Nothing
        Me.chbOrdenCompra.Location = New System.Drawing.Point(496, 45)
        Me.chbOrdenCompra.Name = "chbOrdenCompra"
        Me.chbOrdenCompra.Size = New System.Drawing.Size(109, 17)
        Me.chbOrdenCompra.TabIndex = 17
        Me.chbOrdenCompra.Text = "Orden de Compra"
        Me.chbOrdenCompra.UseVisualStyleBackColor = True
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.BackColor = System.Drawing.SystemColors.Window
        Me.txtOrdenCompra.BindearPropiedadControl = Nothing
        Me.txtOrdenCompra.BindearPropiedadEntidad = Nothing
        Me.txtOrdenCompra.Enabled = False
        Me.txtOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenCompra.Formato = ""
        Me.txtOrdenCompra.IsDecimal = False
        Me.txtOrdenCompra.IsNumber = True
        Me.txtOrdenCompra.IsPK = False
        Me.txtOrdenCompra.IsRequired = False
        Me.txtOrdenCompra.Key = ""
        Me.txtOrdenCompra.LabelAsoc = Nothing
        Me.txtOrdenCompra.Location = New System.Drawing.Point(608, 42)
        Me.txtOrdenCompra.MaxLength = 8
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(80, 20)
        Me.txtOrdenCompra.TabIndex = 18
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(241, 69)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(299, 20)
        Me.bscProducto2.TabIndex = 23
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(87, 68)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = False
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(148, 20)
        Me.bscCodigoProducto2.TabIndex = 22
        '
        'chbMarca
        '
        Me.chbMarca.AutoSize = True
        Me.chbMarca.BindearPropiedadControl = Nothing
        Me.chbMarca.BindearPropiedadEntidad = Nothing
        Me.chbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarca.IsPK = False
        Me.chbMarca.IsRequired = False
        Me.chbMarca.Key = Nothing
        Me.chbMarca.LabelAsoc = Nothing
        Me.chbMarca.Location = New System.Drawing.Point(11, 97)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 24
        Me.chbMarca.Text = "Marca"
        Me.chbMarca.UseVisualStyleBackColor = True
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = False
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Nothing
        Me.cmbMarca.Location = New System.Drawing.Point(70, 95)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(240, 21)
        Me.cmbMarca.TabIndex = 25
        '
        'chbSubRubro
        '
        Me.chbSubRubro.AutoSize = True
        Me.chbSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubRubro.IsPK = False
        Me.chbSubRubro.IsRequired = False
        Me.chbSubRubro.Key = Nothing
        Me.chbSubRubro.LabelAsoc = Nothing
        Me.chbSubRubro.Location = New System.Drawing.Point(659, 97)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 28
        Me.chbSubRubro.Text = "SubRubro"
        Me.chbSubRubro.UseVisualStyleBackColor = True
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro.Enabled = False
        Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro.FormattingEnabled = True
        Me.cmbSubRubro.IsPK = False
        Me.cmbSubRubro.IsRequired = False
        Me.cmbSubRubro.Key = Nothing
        Me.cmbSubRubro.LabelAsoc = Nothing
        Me.cmbSubRubro.Location = New System.Drawing.Point(739, 95)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(204, 21)
        Me.cmbSubRubro.TabIndex = 29
        '
        'chbRubro
        '
        Me.chbRubro.AutoSize = True
        Me.chbRubro.BindearPropiedadControl = Nothing
        Me.chbRubro.BindearPropiedadEntidad = Nothing
        Me.chbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRubro.IsPK = False
        Me.chbRubro.IsRequired = False
        Me.chbRubro.Key = Nothing
        Me.chbRubro.LabelAsoc = Nothing
        Me.chbRubro.Location = New System.Drawing.Point(328, 97)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 26
        Me.chbRubro.Text = "Rubro"
        Me.chbRubro.UseVisualStyleBackColor = True
        '
        'cmbRubro
        '
        Me.cmbRubro.BindearPropiedadControl = Nothing
        Me.cmbRubro.BindearPropiedadEntidad = Nothing
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.Enabled = False
        Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.IsPK = False
        Me.cmbRubro.IsRequired = False
        Me.cmbRubro.Key = Nothing
        Me.cmbRubro.LabelAsoc = Nothing
        Me.cmbRubro.Location = New System.Drawing.Point(403, 95)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(240, 21)
        Me.cmbRubro.TabIndex = 27
        '
        'chkExpandAll
        '
        Me.chkExpandAll.AutoSize = True
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(996, 95)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
        Me.chkExpandAll.TabIndex = 31
        Me.chkExpandAll.Text = "Expandir Grupos"
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
        Me.chbFecha.Location = New System.Drawing.Point(240, 17)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 2
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'lblEstados
        '
        Me.lblEstados.AutoSize = True
        Me.lblEstados.LabelAsoc = Nothing
        Me.lblEstados.Location = New System.Drawing.Point(11, 19)
        Me.lblEstados.Name = "lblEstados"
        Me.lblEstados.Size = New System.Drawing.Size(40, 13)
        Me.lblEstados.TabIndex = 0
        Me.lblEstados.Text = "Estado"
        '
        'cmbEstados
        '
        Me.cmbEstados.BindearPropiedadControl = ""
        Me.cmbEstados.BindearPropiedadEntidad = ""
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.IsPK = False
        Me.cmbEstados.IsRequired = False
        Me.cmbEstados.Key = Nothing
        Me.cmbEstados.LabelAsoc = Me.lblEstados
        Me.cmbEstados.Location = New System.Drawing.Point(56, 15)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstados.TabIndex = 1
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(308, 17)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompleto.TabIndex = 3
        Me.chkMesCompleto.Text = "Mes C."
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
        Me.dtpHasta.Location = New System.Drawing.Point(589, 15)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 7
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(548, 19)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 6
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
        Me.dtpDesde.Location = New System.Drawing.Point(411, 15)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 5
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(367, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 4
        Me.lblDesde.Text = "Desde"
        '
        'chbIdPedido
        '
        Me.chbIdPedido.AutoSize = True
        Me.chbIdPedido.BindearPropiedadControl = Nothing
        Me.chbIdPedido.BindearPropiedadEntidad = Nothing
        Me.chbIdPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIdPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIdPedido.IsPK = False
        Me.chbIdPedido.IsRequired = False
        Me.chbIdPedido.Key = Nothing
        Me.chbIdPedido.LabelAsoc = Nothing
        Me.chbIdPedido.Location = New System.Drawing.Point(957, 17)
        Me.chbIdPedido.Name = "chbIdPedido"
        Me.chbIdPedido.Size = New System.Drawing.Size(63, 17)
        Me.chbIdPedido.TabIndex = 10
        Me.chbIdPedido.Text = "Número"
        Me.chbIdPedido.UseVisualStyleBackColor = True
        '
        'txtIdPedido
        '
        Me.txtIdPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdPedido.BindearPropiedadControl = Nothing
        Me.txtIdPedido.BindearPropiedadEntidad = Nothing
        Me.txtIdPedido.Enabled = False
        Me.txtIdPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdPedido.Formato = ""
        Me.txtIdPedido.IsDecimal = False
        Me.txtIdPedido.IsNumber = True
        Me.txtIdPedido.IsPK = False
        Me.txtIdPedido.IsRequired = False
        Me.txtIdPedido.Key = ""
        Me.txtIdPedido.LabelAsoc = Nothing
        Me.txtIdPedido.Location = New System.Drawing.Point(1024, 15)
        Me.txtIdPedido.MaxLength = 8
        Me.txtIdPedido.Name = "txtIdPedido"
        Me.txtIdPedido.Size = New System.Drawing.Size(65, 20)
        Me.txtIdPedido.TabIndex = 11
        Me.txtIdPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbProveedor
        '
        Me.chbProveedor.AutoSize = True
        Me.chbProveedor.BindearPropiedadControl = Nothing
        Me.chbProveedor.BindearPropiedadEntidad = Nothing
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Location = New System.Drawing.Point(11, 43)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 12
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(87, 42)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = False
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoProveedor.TabIndex = 13
        '
        'bscProveedor
        '
        Me.bscProveedor.ActivarFiltroEnGrilla = True
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ConfigBuscador = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Nothing
        Me.bscProveedor.Location = New System.Drawing.Point(184, 43)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = False
        Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
        Me.bscProveedor.TabIndex = 16
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnConsultar.Location = New System.Drawing.Point(996, 46)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 30
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'grpOperaciones
        '
        Me.grpOperaciones.Controls.Add(Me.chbGeneraUnPedidoPorProveedor)
        Me.grpOperaciones.Controls.Add(Me.lblCantidadObservaciones)
        Me.grpOperaciones.Controls.Add(Me.lblFechaEntrega)
        Me.grpOperaciones.Controls.Add(Me.lblCriticidad)
        Me.grpOperaciones.Controls.Add(Me.dtpFechaEntrega)
        Me.grpOperaciones.Controls.Add(Me.cmbCriticidad)
        Me.grpOperaciones.Controls.Add(Me.btnMasivo)
        Me.grpOperaciones.Controls.Add(Me.txtCantidad)
        Me.grpOperaciones.Controls.Add(Me.txtObservacion)
        Me.grpOperaciones.Controls.Add(Me.lblCantidad)
        Me.grpOperaciones.Controls.Add(Me.lblObservacion)
        Me.grpOperaciones.Controls.Add(Me.cmbEstadoCambiar)
        Me.grpOperaciones.Controls.Add(Me.lblEstado)
        Me.grpOperaciones.Controls.Add(Me.btnCancel)
        Me.grpOperaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpOperaciones.Location = New System.Drawing.Point(0, 149)
        Me.grpOperaciones.Name = "grpOperaciones"
        Me.grpOperaciones.Size = New System.Drawing.Size(1130, 72)
        Me.grpOperaciones.TabIndex = 1
        Me.grpOperaciones.TabStop = False
        Me.grpOperaciones.Text = "Operaciones"
        '
        'chbGeneraUnPedidoPorProveedor
        '
        Me.chbGeneraUnPedidoPorProveedor.AutoSize = True
        Me.chbGeneraUnPedidoPorProveedor.BindearPropiedadControl = Nothing
        Me.chbGeneraUnPedidoPorProveedor.BindearPropiedadEntidad = Nothing
        Me.chbGeneraUnPedidoPorProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGeneraUnPedidoPorProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGeneraUnPedidoPorProveedor.IsPK = False
        Me.chbGeneraUnPedidoPorProveedor.IsRequired = False
        Me.chbGeneraUnPedidoPorProveedor.Key = Nothing
        Me.chbGeneraUnPedidoPorProveedor.LabelAsoc = Nothing
        Me.chbGeneraUnPedidoPorProveedor.Location = New System.Drawing.Point(652, 48)
        Me.chbGeneraUnPedidoPorProveedor.Name = "chbGeneraUnPedidoPorProveedor"
        Me.chbGeneraUnPedidoPorProveedor.Size = New System.Drawing.Size(182, 17)
        Me.chbGeneraUnPedidoPorProveedor.TabIndex = 11
        Me.chbGeneraUnPedidoPorProveedor.Text = "Genera un Pedido por Proveedor"
        Me.chbGeneraUnPedidoPorProveedor.UseVisualStyleBackColor = True
        '
        'lblCantidadObservaciones
        '
        Me.lblCantidadObservaciones.AutoSize = True
        Me.lblCantidadObservaciones.LabelAsoc = Nothing
        Me.lblCantidadObservaciones.Location = New System.Drawing.Point(649, 26)
        Me.lblCantidadObservaciones.Name = "lblCantidadObservaciones"
        Me.lblCantidadObservaciones.Size = New System.Drawing.Size(162, 13)
        Me.lblCantidadObservaciones.TabIndex = 6
        Me.lblCantidadObservaciones.Text = "Cantidades modificables en Grilla"
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFechaEntrega.LabelAsoc = Nothing
        Me.lblFechaEntrega.Location = New System.Drawing.Point(215, 50)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(95, 13)
        Me.lblFechaEntrega.TabIndex = 9
        Me.lblFechaEntrega.Text = "Fecha de Entrega:"
        '
        'lblCriticidad
        '
        Me.lblCriticidad.AutoSize = True
        Me.lblCriticidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCriticidad.LabelAsoc = Nothing
        Me.lblCriticidad.Location = New System.Drawing.Point(11, 50)
        Me.lblCriticidad.Name = "lblCriticidad"
        Me.lblCriticidad.Size = New System.Drawing.Size(50, 13)
        Me.lblCriticidad.TabIndex = 7
        Me.lblCriticidad.Text = "Criticidad"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.BindearPropiedadControl = Nothing
        Me.dtpFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntrega.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntrega.IsPK = False
        Me.dtpFechaEntrega.IsRequired = False
        Me.dtpFechaEntrega.Key = ""
        Me.dtpFechaEntrega.LabelAsoc = Me.lblFechaEntrega
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(316, 46)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEntrega.TabIndex = 10
        '
        'cmbCriticidad
        '
        Me.cmbCriticidad.BindearPropiedadControl = Nothing
        Me.cmbCriticidad.BindearPropiedadEntidad = Nothing
        Me.cmbCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCriticidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCriticidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCriticidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCriticidad.FormattingEnabled = True
        Me.cmbCriticidad.IsPK = False
        Me.cmbCriticidad.IsRequired = False
        Me.cmbCriticidad.Key = Nothing
        Me.cmbCriticidad.LabelAsoc = Me.lblCriticidad
        Me.cmbCriticidad.Location = New System.Drawing.Point(85, 46)
        Me.cmbCriticidad.Name = "cmbCriticidad"
        Me.cmbCriticidad.Size = New System.Drawing.Size(112, 21)
        Me.cmbCriticidad.TabIndex = 8
        '
        'btnMasivo
        '
        Me.btnMasivo.Image = Global.Eniac.Win.My.Resources.Resources.play_32
        Me.btnMasivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMasivo.Location = New System.Drawing.Point(900, 20)
        Me.btnMasivo.Name = "btnMasivo"
        Me.btnMasivo.Size = New System.Drawing.Size(93, 48)
        Me.btnMasivo.TabIndex = 12
        Me.btnMasivo.Text = "Cambiar"
        Me.btnMasivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMasivo.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "##0.00"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblCantidad
        Me.txtCantidad.Location = New System.Drawing.Point(704, 22)
        Me.txtCantidad.MaxLength = 6
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(65, 20)
        Me.txtCantidad.TabIndex = 5
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(649, 26)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 4
        Me.lblCantidad.Text = "Cantidad"
        '
        'txtObservacion
        '
        Me.txtObservacion.BindearPropiedadControl = Nothing
        Me.txtObservacion.BindearPropiedadEntidad = Nothing
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = ""
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = ""
        Me.txtObservacion.LabelAsoc = Me.lblObservacion
        Me.txtObservacion.Location = New System.Drawing.Point(85, 23)
        Me.txtObservacion.MaxLength = 200
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(390, 20)
        Me.txtObservacion.TabIndex = 1
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(10, 25)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 0
        Me.lblObservacion.Text = "Observacion"
        '
        'cmbEstadoCambiar
        '
        Me.cmbEstadoCambiar.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoCambiar.BindearPropiedadEntidad = "estadoCambiar"
        Me.cmbEstadoCambiar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCambiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoCambiar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoCambiar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoCambiar.FormattingEnabled = True
        Me.cmbEstadoCambiar.IsPK = False
        Me.cmbEstadoCambiar.IsRequired = True
        Me.cmbEstadoCambiar.Key = Nothing
        Me.cmbEstadoCambiar.LabelAsoc = Nothing
        Me.cmbEstadoCambiar.Location = New System.Drawing.Point(527, 22)
        Me.cmbEstadoCambiar.Name = "cmbEstadoCambiar"
        Me.cmbEstadoCambiar.Size = New System.Drawing.Size(106, 21)
        Me.cmbEstadoCambiar.TabIndex = 3
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(481, 26)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Estado"
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Eniac.Win.My.Resources.Resources.delete2
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1000, 20)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(93, 48)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(1049, 226)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 12
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(922, 227)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 11
        '
        'PedidosAdminProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 553)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.grpOperaciones)
        Me.Controls.Add(Me.grpFiltros)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "PedidosAdminProv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de Pedidos a Proveedores"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.grpOperaciones.ResumeLayout(False)
        Me.grpOperaciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents grpFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents grpOperaciones As System.Windows.Forms.GroupBox
   Friend WithEvents cmbEstadoCambiar As Eniac.Controles.ComboBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents lblCantidad As Eniac.Controles.Label
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents txtCantidad As Eniac.Controles.TextBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
    Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
    Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
    Friend WithEvents chbIdPedido As Eniac.Controles.CheckBox
   Friend WithEvents txtIdPedido As Eniac.Controles.TextBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents lblEstados As Eniac.Controles.Label
   Friend WithEvents cmbEstados As Eniac.Controles.ComboBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents btnMasivo As System.Windows.Forms.Button
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents lblFechaEntrega As Eniac.Controles.Label
   Friend WithEvents lblCriticidad As Eniac.Controles.Label
   Friend WithEvents dtpFechaEntrega As Eniac.Controles.DateTimePicker
   Friend WithEvents cmbCriticidad As Eniac.Controles.ComboBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbModificarPedido As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbConvertirEnFactura As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbOrdenCompra As Eniac.Controles.CheckBox
   Friend WithEvents txtOrdenCompra As Eniac.Controles.TextBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Friend WithEvents lblCantidadObservaciones As Eniac.Controles.Label
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chbGeneraUnPedidoPorProveedor As Controles.CheckBox
End Class
