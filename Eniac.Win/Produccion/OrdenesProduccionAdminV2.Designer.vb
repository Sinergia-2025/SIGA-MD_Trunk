<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OrdenesProduccionAdminV2
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()>
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
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaOrdenProduccion")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCriticidad")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocumento")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
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
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreResponsable")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PlanMaestroNumero")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PlanMaestroFecha")
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
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCambiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbModificarPedido = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpHastaPlanMaestro = New Eniac.Controles.DateTimePicker()
        Me.lblHastaPlanMaestro = New Eniac.Controles.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlMarcas = New System.Windows.Forms.Panel()
        Me.lblMarcas = New Eniac.Controles.Label()
        Me.cmbMarcas = New Eniac.Win.ComboBoxMarcas()
        Me.pnlModelos = New System.Windows.Forms.Panel()
        Me.cmbModelos = New Eniac.Win.ComboBoxModelos()
        Me.lblModelos = New Eniac.Controles.Label()
        Me.pnlRubros = New System.Windows.Forms.Panel()
        Me.cmbRubros = New Eniac.Win.ComboBoxRubro()
        Me.lblRubros = New Eniac.Controles.Label()
        Me.pnlSubRubros = New System.Windows.Forms.Panel()
        Me.cmbSubRubros = New Eniac.Win.ComboBoxSubRubro()
        Me.lblSubRubros = New Eniac.Controles.Label()
        Me.pnlSubSubRubros = New System.Windows.Forms.Panel()
        Me.cmbSubSubRubros = New Eniac.Win.ComboBoxSubSubRubro()
        Me.lblSubSubRubros = New Eniac.Controles.Label()
        Me.dtpDesdePlanMaestro = New Eniac.Controles.DateTimePicker()
        Me.lblDesdePlanMaestro = New Eniac.Controles.Label()
        Me.chbFechaPlanMaestro = New Eniac.Controles.CheckBox()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.chbPlanMaestro = New Eniac.Controles.CheckBox()
        Me.chbResponsable = New Eniac.Controles.CheckBox()
        Me.txtPlanMaestro = New Eniac.Controles.TextBox()
        Me.cmbResponsable = New Eniac.Controles.ComboBox()
        Me.chbOrdenCompra = New Eniac.Controles.CheckBox()
        Me.txtOrdenCompra = New Eniac.Controles.TextBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbEstados = New Eniac.Controles.ComboBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbTamanio = New Eniac.Controles.CheckBox()
        Me.txtTamanio = New Eniac.Controles.TextBox()
        Me.chbIdPedido = New Eniac.Controles.CheckBox()
        Me.txtIdPedido = New Eniac.Controles.TextBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMarcas.SuspendLayout()
        Me.pnlModelos.SuspendLayout()
        Me.pnlRubros.SuspendLayout()
        Me.pnlSubRubros.SuspendLayout()
        Me.pnlSubSubRubros.SuspendLayout()
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
        UltraGridColumn20.Width = 111
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn21.CellAppearance = Appearance3
        UltraGridColumn21.Header.Caption = "L."
        UltraGridColumn21.Header.VisiblePosition = 5
        UltraGridColumn21.Width = 25
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance4
        UltraGridColumn22.Header.Caption = "Emisor"
        UltraGridColumn22.Header.VisiblePosition = 6
        UltraGridColumn22.Width = 40
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance5
        UltraGridColumn28.Header.Caption = "Numero"
        UltraGridColumn28.Header.VisiblePosition = 7
        UltraGridColumn28.Width = 83
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn37.CellAppearance = Appearance6
        UltraGridColumn37.Header.Caption = "Fecha"
        UltraGridColumn37.Header.VisiblePosition = 8
        UltraGridColumn37.Width = 94
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "Criticidad"
        UltraGridColumn5.Header.VisiblePosition = 9
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Format = "dd/MM/yyyy"
        UltraGridColumn6.Header.Caption = "Fecha Entrega"
        UltraGridColumn6.Header.VisiblePosition = 10
        UltraGridColumn6.Width = 85
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn30.Header.VisiblePosition = 13
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn31.Header.VisiblePosition = 15
        UltraGridColumn31.Hidden = True
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 11
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 14
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "Nombre Cliente"
        UltraGridColumn9.Header.VisiblePosition = 16
        UltraGridColumn9.Width = 150
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.VisiblePosition = 12
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.Caption = "Nombre Producto"
        UltraGridColumn11.Header.VisiblePosition = 17
        UltraGridColumn11.Width = 200
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance7
        UltraGridColumn12.Format = "#,##0.00"
        UltraGridColumn12.Header.Caption = "Tamaño"
        UltraGridColumn12.Header.VisiblePosition = 18
        UltraGridColumn12.Width = 60
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.VisiblePosition = 20
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance8
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.Caption = "Cant.Pedida"
        UltraGridColumn14.Header.VisiblePosition = 22
        UltraGridColumn14.Width = 70
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn15.CellAppearance = Appearance9
        UltraGridColumn15.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn15.Header.Caption = "Fecha Estado"
        UltraGridColumn15.Header.VisiblePosition = 21
        UltraGridColumn15.Width = 100
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.Caption = "Estado"
        UltraGridColumn16.Header.VisiblePosition = 3
        UltraGridColumn16.Width = 90
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.VisiblePosition = 23
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance10
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.Caption = "Cant.Involucrada"
        UltraGridColumn18.Header.VisiblePosition = 24
        UltraGridColumn18.Width = 70
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.BackColor = System.Drawing.Color.LightCyan
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance11
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "Cant.Pendiente"
        UltraGridColumn19.Header.VisiblePosition = 25
        UltraGridColumn19.Width = 70
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn32.Header.Caption = "Comprobante"
        UltraGridColumn32.Header.VisiblePosition = 26
        UltraGridColumn32.Width = 90
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance12
        UltraGridColumn33.Header.Caption = "Let."
        UltraGridColumn33.Header.VisiblePosition = 27
        UltraGridColumn33.Width = 30
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance13
        UltraGridColumn34.Header.Caption = "Emisor"
        UltraGridColumn34.Header.VisiblePosition = 28
        UltraGridColumn34.Width = 40
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance14
        UltraGridColumn35.Header.Caption = "Nro.Comprobante"
        UltraGridColumn35.Header.VisiblePosition = 29
        UltraGridColumn35.Width = 70
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.Header.Caption = "Usuario"
        UltraGridColumn24.Header.VisiblePosition = 31
        UltraGridColumn24.Width = 75
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn25.Header.VisiblePosition = 30
        UltraGridColumn25.Width = 200
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.Caption = "Marca"
        UltraGridColumn26.Header.VisiblePosition = 32
        UltraGridColumn26.Width = 200
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.Header.Caption = "Rubro"
        UltraGridColumn27.Header.VisiblePosition = 33
        UltraGridColumn27.Width = 200
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance15
        UltraGridColumn3.Header.Caption = "U. M."
        UltraGridColumn3.Header.VisiblePosition = 19
        UltraGridColumn3.Width = 40
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance16
        UltraGridColumn23.Header.Caption = "O. C."
        UltraGridColumn23.Header.VisiblePosition = 34
        UltraGridColumn23.Width = 80
        UltraGridColumn4.Header.Caption = "Operario"
        UltraGridColumn4.Header.VisiblePosition = 35
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance17
        UltraGridColumn29.Header.Caption = "Nro. Plan Maestro"
        UltraGridColumn29.Header.VisiblePosition = 36
        UltraGridColumn29.Width = 106
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn38.CellAppearance = Appearance18
        UltraGridColumn38.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn38.Header.Caption = "Fecha/Hora Plan Maestro"
        UltraGridColumn38.Header.VisiblePosition = 37
        UltraGridColumn38.Width = 105
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn36, UltraGridColumn2, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn28, UltraGridColumn37, UltraGridColumn5, UltraGridColumn6, UltraGridColumn30, UltraGridColumn31, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn3, UltraGridColumn23, UltraGridColumn4, UltraGridColumn29, UltraGridColumn38})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance19
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance21.BackColor2 = System.Drawing.SystemColors.Control
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance22
        Appearance23.BackColor = System.Drawing.SystemColors.Highlight
        Appearance23.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance23
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
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
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 170)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1130, 361)
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
        Me.stsStado.TabIndex = 6
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
        Me.chbProducto.Location = New System.Drawing.Point(2, 69)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator7, Me.tsbCambiar, Me.ToolStripSeparator4, Me.tsbModificarPedido, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1130, 29)
        Me.tstBarra.TabIndex = 7
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCambiar
        '
        Me.tsbCambiar.Image = Global.Eniac.Win.My.Resources.Resources.play_24
        Me.tsbCambiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCambiar.Name = "tsbCambiar"
        Me.tsbCambiar.Size = New System.Drawing.Size(101, 26)
        Me.tsbCambiar.Text = "Cambiar (F4)"
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
        Me.tsbModificarPedido.Size = New System.Drawing.Size(184, 26)
        Me.tsbModificarPedido.Text = "Modificar Orden Producción"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpHastaPlanMaestro)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox1.Controls.Add(Me.dtpDesdePlanMaestro)
        Me.GroupBox1.Controls.Add(Me.chbFechaPlanMaestro)
        Me.GroupBox1.Controls.Add(Me.cmbTiposComprobantes)
        Me.GroupBox1.Controls.Add(Me.chbPlanMaestro)
        Me.GroupBox1.Controls.Add(Me.lblTipoComprobante)
        Me.GroupBox1.Controls.Add(Me.lblDesdePlanMaestro)
        Me.GroupBox1.Controls.Add(Me.chbResponsable)
        Me.GroupBox1.Controls.Add(Me.txtPlanMaestro)
        Me.GroupBox1.Controls.Add(Me.cmbResponsable)
        Me.GroupBox1.Controls.Add(Me.lblHastaPlanMaestro)
        Me.GroupBox1.Controls.Add(Me.chbOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.txtOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.bscProducto2)
        Me.GroupBox1.Controls.Add(Me.bscCodigoProducto2)
        Me.GroupBox1.Controls.Add(Me.chbFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbEstados)
        Me.GroupBox1.Controls.Add(Me.chkMesCompleto)
        Me.GroupBox1.Controls.Add(Me.dtpHasta)
        Me.GroupBox1.Controls.Add(Me.dtpDesde)
        Me.GroupBox1.Controls.Add(Me.lblHasta)
        Me.GroupBox1.Controls.Add(Me.lblDesde)
        Me.GroupBox1.Controls.Add(Me.chbTamanio)
        Me.GroupBox1.Controls.Add(Me.txtTamanio)
        Me.GroupBox1.Controls.Add(Me.chbIdPedido)
        Me.GroupBox1.Controls.Add(Me.txtIdPedido)
        Me.GroupBox1.Controls.Add(Me.chbCliente)
        Me.GroupBox1.Controls.Add(Me.bscCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.bscCliente)
        Me.GroupBox1.Controls.Add(Me.chbProducto)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1130, 141)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'dtpHastaPlanMaestro
        '
        Me.dtpHastaPlanMaestro.BindearPropiedadControl = Nothing
        Me.dtpHastaPlanMaestro.BindearPropiedadEntidad = Nothing
        Me.dtpHastaPlanMaestro.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHastaPlanMaestro.Enabled = False
        Me.dtpHastaPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHastaPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHastaPlanMaestro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaPlanMaestro.IsPK = False
        Me.dtpHastaPlanMaestro.IsRequired = False
        Me.dtpHastaPlanMaestro.Key = ""
        Me.dtpHastaPlanMaestro.LabelAsoc = Me.lblHastaPlanMaestro
        Me.dtpHastaPlanMaestro.Location = New System.Drawing.Point(989, 67)
        Me.dtpHastaPlanMaestro.Name = "dtpHastaPlanMaestro"
        Me.dtpHastaPlanMaestro.Size = New System.Drawing.Size(125, 20)
        Me.dtpHastaPlanMaestro.TabIndex = 30
        '
        'lblHastaPlanMaestro
        '
        Me.lblHastaPlanMaestro.AutoSize = True
        Me.lblHastaPlanMaestro.LabelAsoc = Nothing
        Me.lblHastaPlanMaestro.Location = New System.Drawing.Point(945, 69)
        Me.lblHastaPlanMaestro.Name = "lblHastaPlanMaestro"
        Me.lblHastaPlanMaestro.Size = New System.Drawing.Size(35, 13)
        Me.lblHastaPlanMaestro.TabIndex = 29
        Me.lblHastaPlanMaestro.Text = "Hasta"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMarcas)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlModelos)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubSubRubros)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 93)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1123, 48)
        Me.FlowLayoutPanel1.TabIndex = 31
        '
        'pnlMarcas
        '
        Me.pnlMarcas.AutoSize = True
        Me.pnlMarcas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlMarcas.Controls.Add(Me.lblMarcas)
        Me.pnlMarcas.Controls.Add(Me.cmbMarcas)
        Me.pnlMarcas.Location = New System.Drawing.Point(3, 0)
        Me.pnlMarcas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlMarcas.Name = "pnlMarcas"
        Me.pnlMarcas.Size = New System.Drawing.Size(248, 21)
        Me.pnlMarcas.TabIndex = 0
        '
        'lblMarcas
        '
        Me.lblMarcas.AutoSize = True
        Me.lblMarcas.LabelAsoc = Nothing
        Me.lblMarcas.Location = New System.Drawing.Point(3, 4)
        Me.lblMarcas.Name = "lblMarcas"
        Me.lblMarcas.Size = New System.Drawing.Size(42, 13)
        Me.lblMarcas.TabIndex = 0
        Me.lblMarcas.Text = "Marcas"
        '
        'cmbMarcas
        '
        Me.cmbMarcas.BindearPropiedadControl = Nothing
        Me.cmbMarcas.BindearPropiedadEntidad = Nothing
        Me.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarcas.FormattingEnabled = True
        Me.cmbMarcas.IsPK = False
        Me.cmbMarcas.IsRequired = False
        Me.cmbMarcas.Key = Nothing
        Me.cmbMarcas.LabelAsoc = Me.lblMarcas
        Me.cmbMarcas.Location = New System.Drawing.Point(48, 0)
        Me.cmbMarcas.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbMarcas.Name = "cmbMarcas"
        Me.cmbMarcas.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarcas.TabIndex = 1
        '
        'pnlModelos
        '
        Me.pnlModelos.AutoSize = True
        Me.pnlModelos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlModelos.Controls.Add(Me.cmbModelos)
        Me.pnlModelos.Controls.Add(Me.lblModelos)
        Me.pnlModelos.Location = New System.Drawing.Point(257, 0)
        Me.pnlModelos.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlModelos.Name = "pnlModelos"
        Me.pnlModelos.Size = New System.Drawing.Size(253, 21)
        Me.pnlModelos.TabIndex = 1
        '
        'cmbModelos
        '
        Me.cmbModelos.BindearPropiedadControl = Nothing
        Me.cmbModelos.BindearPropiedadEntidad = Nothing
        Me.cmbModelos.ConcatenarNombreMarca = False
        Me.cmbModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModelos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModelos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModelos.FormattingEnabled = True
        Me.cmbModelos.IsPK = False
        Me.cmbModelos.IsRequired = False
        Me.cmbModelos.Key = Nothing
        Me.cmbModelos.LabelAsoc = Me.lblModelos
        Me.cmbModelos.Location = New System.Drawing.Point(53, 0)
        Me.cmbModelos.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbModelos.Name = "cmbModelos"
        Me.cmbModelos.Size = New System.Drawing.Size(200, 21)
        Me.cmbModelos.TabIndex = 1
        '
        'lblModelos
        '
        Me.lblModelos.AutoSize = True
        Me.lblModelos.LabelAsoc = Nothing
        Me.lblModelos.Location = New System.Drawing.Point(3, 4)
        Me.lblModelos.Name = "lblModelos"
        Me.lblModelos.Size = New System.Drawing.Size(47, 13)
        Me.lblModelos.TabIndex = 0
        Me.lblModelos.Text = "Modelos"
        '
        'pnlRubros
        '
        Me.pnlRubros.AutoSize = True
        Me.pnlRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlRubros.Controls.Add(Me.cmbRubros)
        Me.pnlRubros.Controls.Add(Me.lblRubros)
        Me.pnlRubros.Location = New System.Drawing.Point(516, 0)
        Me.pnlRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlRubros.Name = "pnlRubros"
        Me.pnlRubros.Size = New System.Drawing.Size(247, 21)
        Me.pnlRubros.TabIndex = 2
        '
        'cmbRubros
        '
        Me.cmbRubros.BindearPropiedadControl = Nothing
        Me.cmbRubros.BindearPropiedadEntidad = Nothing
        Me.cmbRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubros.FormattingEnabled = True
        Me.cmbRubros.IsPK = False
        Me.cmbRubros.IsRequired = False
        Me.cmbRubros.Key = Nothing
        Me.cmbRubros.LabelAsoc = Me.lblRubros
        Me.cmbRubros.Location = New System.Drawing.Point(47, 0)
        Me.cmbRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbRubros.Name = "cmbRubros"
        Me.cmbRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbRubros.TabIndex = 1
        '
        'lblRubros
        '
        Me.lblRubros.AutoSize = True
        Me.lblRubros.LabelAsoc = Nothing
        Me.lblRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblRubros.Name = "lblRubros"
        Me.lblRubros.Size = New System.Drawing.Size(41, 13)
        Me.lblRubros.TabIndex = 0
        Me.lblRubros.Text = "Rubros"
        '
        'pnlSubRubros
        '
        Me.pnlSubRubros.AutoSize = True
        Me.pnlSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSubRubros.Controls.Add(Me.cmbSubRubros)
        Me.pnlSubRubros.Controls.Add(Me.lblSubRubros)
        Me.pnlSubRubros.Location = New System.Drawing.Point(769, 0)
        Me.pnlSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubRubros.Name = "pnlSubRubros"
        Me.pnlSubRubros.Size = New System.Drawing.Size(265, 21)
        Me.pnlSubRubros.TabIndex = 3
        '
        'cmbSubRubros
        '
        Me.cmbSubRubros.BindearPropiedadControl = Nothing
        Me.cmbSubRubros.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubros.ConcatenarNombreRubro = False
        Me.cmbSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubros.FormattingEnabled = True
        Me.cmbSubRubros.IsPK = False
        Me.cmbSubRubros.IsRequired = False
        Me.cmbSubRubros.Key = Nothing
        Me.cmbSubRubros.LabelAsoc = Me.lblSubRubros
        Me.cmbSubRubros.Location = New System.Drawing.Point(65, 0)
        Me.cmbSubRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSubRubros.Name = "cmbSubRubros"
        Me.cmbSubRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubRubros.TabIndex = 1
        '
        'lblSubRubros
        '
        Me.lblSubRubros.AutoSize = True
        Me.lblSubRubros.LabelAsoc = Nothing
        Me.lblSubRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblSubRubros.Name = "lblSubRubros"
        Me.lblSubRubros.Size = New System.Drawing.Size(60, 13)
        Me.lblSubRubros.TabIndex = 0
        Me.lblSubRubros.Text = "SubRubros"
        '
        'pnlSubSubRubros
        '
        Me.pnlSubSubRubros.AutoSize = True
        Me.pnlSubSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSubSubRubros.Controls.Add(Me.cmbSubSubRubros)
        Me.pnlSubSubRubros.Controls.Add(Me.lblSubSubRubros)
        Me.pnlSubSubRubros.Location = New System.Drawing.Point(3, 24)
        Me.pnlSubSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlSubSubRubros.Name = "pnlSubSubRubros"
        Me.pnlSubSubRubros.Size = New System.Drawing.Size(281, 21)
        Me.pnlSubSubRubros.TabIndex = 4
        '
        'cmbSubSubRubros
        '
        Me.cmbSubSubRubros.BindearPropiedadControl = Nothing
        Me.cmbSubSubRubros.BindearPropiedadEntidad = Nothing
        Me.cmbSubSubRubros.ConcatenarNombreSubRubro = False
        Me.cmbSubSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubSubRubros.FormattingEnabled = True
        Me.cmbSubSubRubros.IsPK = False
        Me.cmbSubSubRubros.IsRequired = False
        Me.cmbSubSubRubros.Key = Nothing
        Me.cmbSubSubRubros.LabelAsoc = Me.lblSubSubRubros
        Me.cmbSubSubRubros.Location = New System.Drawing.Point(81, 0)
        Me.cmbSubSubRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSubSubRubros.Name = "cmbSubSubRubros"
        Me.cmbSubSubRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubSubRubros.TabIndex = 1
        '
        'lblSubSubRubros
        '
        Me.lblSubSubRubros.AutoSize = True
        Me.lblSubSubRubros.LabelAsoc = Nothing
        Me.lblSubSubRubros.Location = New System.Drawing.Point(3, 4)
        Me.lblSubSubRubros.Name = "lblSubSubRubros"
        Me.lblSubSubRubros.Size = New System.Drawing.Size(79, 13)
        Me.lblSubSubRubros.TabIndex = 0
        Me.lblSubSubRubros.Text = "SubSubRubros"
        '
        'dtpDesdePlanMaestro
        '
        Me.dtpDesdePlanMaestro.BindearPropiedadControl = Nothing
        Me.dtpDesdePlanMaestro.BindearPropiedadEntidad = Nothing
        Me.dtpDesdePlanMaestro.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesdePlanMaestro.Enabled = False
        Me.dtpDesdePlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesdePlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesdePlanMaestro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdePlanMaestro.IsPK = False
        Me.dtpDesdePlanMaestro.IsRequired = False
        Me.dtpDesdePlanMaestro.Key = ""
        Me.dtpDesdePlanMaestro.LabelAsoc = Me.lblDesdePlanMaestro
        Me.dtpDesdePlanMaestro.Location = New System.Drawing.Point(814, 66)
        Me.dtpDesdePlanMaestro.Name = "dtpDesdePlanMaestro"
        Me.dtpDesdePlanMaestro.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesdePlanMaestro.TabIndex = 28
        '
        'lblDesdePlanMaestro
        '
        Me.lblDesdePlanMaestro.AutoSize = True
        Me.lblDesdePlanMaestro.LabelAsoc = Nothing
        Me.lblDesdePlanMaestro.Location = New System.Drawing.Point(769, 69)
        Me.lblDesdePlanMaestro.Name = "lblDesdePlanMaestro"
        Me.lblDesdePlanMaestro.Size = New System.Drawing.Size(38, 13)
        Me.lblDesdePlanMaestro.TabIndex = 27
        Me.lblDesdePlanMaestro.Text = "Desde"
        '
        'chbFechaPlanMaestro
        '
        Me.chbFechaPlanMaestro.AutoSize = True
        Me.chbFechaPlanMaestro.BindearPropiedadControl = Nothing
        Me.chbFechaPlanMaestro.BindearPropiedadEntidad = Nothing
        Me.chbFechaPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaPlanMaestro.IsPK = False
        Me.chbFechaPlanMaestro.IsRequired = False
        Me.chbFechaPlanMaestro.Key = Nothing
        Me.chbFechaPlanMaestro.LabelAsoc = Nothing
        Me.chbFechaPlanMaestro.Location = New System.Drawing.Point(714, 68)
        Me.chbFechaPlanMaestro.Name = "chbFechaPlanMaestro"
        Me.chbFechaPlanMaestro.Size = New System.Drawing.Size(56, 17)
        Me.chbFechaPlanMaestro.TabIndex = 26
        Me.chbFechaPlanMaestro.Text = "Fecha"
        Me.chbFechaPlanMaestro.UseVisualStyleBackColor = True
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
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(597, 41)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
        Me.cmbTiposComprobantes.TabIndex = 16
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(496, 45)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(99, 13)
        Me.lblTipoComprobante.TabIndex = 15
        Me.lblTipoComprobante.Text = "Tipos Comprobante"
        '
        'chbPlanMaestro
        '
        Me.chbPlanMaestro.AutoSize = True
        Me.chbPlanMaestro.BindearPropiedadControl = Nothing
        Me.chbPlanMaestro.BindearPropiedadEntidad = Nothing
        Me.chbPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPlanMaestro.IsPK = False
        Me.chbPlanMaestro.IsRequired = False
        Me.chbPlanMaestro.Key = Nothing
        Me.chbPlanMaestro.LabelAsoc = Nothing
        Me.chbPlanMaestro.Location = New System.Drawing.Point(556, 68)
        Me.chbPlanMaestro.Name = "chbPlanMaestro"
        Me.chbPlanMaestro.Size = New System.Drawing.Size(88, 17)
        Me.chbPlanMaestro.TabIndex = 24
        Me.chbPlanMaestro.Text = "Plan Maestro"
        Me.chbPlanMaestro.UseVisualStyleBackColor = True
        '
        'chbResponsable
        '
        Me.chbResponsable.AutoSize = True
        Me.chbResponsable.BindearPropiedadControl = Nothing
        Me.chbResponsable.BindearPropiedadEntidad = Nothing
        Me.chbResponsable.Checked = True
        Me.chbResponsable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbResponsable.ForeColorFocus = System.Drawing.Color.Red
        Me.chbResponsable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbResponsable.IsPK = False
        Me.chbResponsable.IsRequired = False
        Me.chbResponsable.Key = Nothing
        Me.chbResponsable.LabelAsoc = Nothing
        Me.chbResponsable.Location = New System.Drawing.Point(2, 17)
        Me.chbResponsable.Name = "chbResponsable"
        Me.chbResponsable.Size = New System.Drawing.Size(66, 17)
        Me.chbResponsable.TabIndex = 0
        Me.chbResponsable.Text = "Operario"
        '
        'txtPlanMaestro
        '
        Me.txtPlanMaestro.BindearPropiedadControl = "Text"
        Me.txtPlanMaestro.BindearPropiedadEntidad = "CodigoTarea"
        Me.txtPlanMaestro.Enabled = False
        Me.txtPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPlanMaestro.Formato = ""
        Me.txtPlanMaestro.IsDecimal = False
        Me.txtPlanMaestro.IsNumber = True
        Me.txtPlanMaestro.IsPK = False
        Me.txtPlanMaestro.IsRequired = False
        Me.txtPlanMaestro.Key = ""
        Me.txtPlanMaestro.LabelAsoc = Nothing
        Me.txtPlanMaestro.Location = New System.Drawing.Point(647, 66)
        Me.txtPlanMaestro.MaxLength = 12
        Me.txtPlanMaestro.Name = "txtPlanMaestro"
        Me.txtPlanMaestro.Size = New System.Drawing.Size(61, 20)
        Me.txtPlanMaestro.TabIndex = 25
        Me.txtPlanMaestro.Text = "0"
        Me.txtPlanMaestro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbResponsable
        '
        Me.cmbResponsable.BindearPropiedadControl = Nothing
        Me.cmbResponsable.BindearPropiedadEntidad = Nothing
        Me.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbResponsable.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbResponsable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbResponsable.FormattingEnabled = True
        Me.cmbResponsable.IsPK = False
        Me.cmbResponsable.IsRequired = False
        Me.cmbResponsable.Key = Nothing
        Me.cmbResponsable.LabelAsoc = Me.chbResponsable
        Me.cmbResponsable.Location = New System.Drawing.Point(91, 15)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(141, 21)
        Me.cmbResponsable.TabIndex = 1
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
        Me.chbOrdenCompra.Location = New System.Drawing.Point(922, 17)
        Me.chbOrdenCompra.Name = "chbOrdenCompra"
        Me.chbOrdenCompra.Size = New System.Drawing.Size(109, 17)
        Me.chbOrdenCompra.TabIndex = 10
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
        Me.txtOrdenCompra.Location = New System.Drawing.Point(1036, 15)
        Me.txtOrdenCompra.MaxLength = 8
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(80, 20)
        Me.txtOrdenCompra.TabIndex = 11
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(219, 67)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = False
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(331, 20)
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(91, 67)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = False
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(122, 20)
        Me.bscCodigoProducto2.TabIndex = 22
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
        Me.chbFecha.Location = New System.Drawing.Point(431, 17)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 4
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(237, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Estado"
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
        Me.cmbEstados.LabelAsoc = Me.Label1
        Me.cmbEstados.Location = New System.Drawing.Point(283, 15)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstados.TabIndex = 3
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(492, 17)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompleto.TabIndex = 5
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
        Me.dtpHasta.Location = New System.Drawing.Point(775, 15)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 9
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(734, 19)
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
        Me.dtpDesde.Location = New System.Drawing.Point(597, 15)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 7
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(553, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 6
        Me.lblDesde.Text = "Desde"
        '
        'chbTamanio
        '
        Me.chbTamanio.AutoSize = True
        Me.chbTamanio.BindearPropiedadControl = Nothing
        Me.chbTamanio.BindearPropiedadEntidad = Nothing
        Me.chbTamanio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTamanio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTamanio.IsPK = False
        Me.chbTamanio.IsRequired = False
        Me.chbTamanio.Key = Nothing
        Me.chbTamanio.LabelAsoc = Nothing
        Me.chbTamanio.Location = New System.Drawing.Point(922, 43)
        Me.chbTamanio.Name = "chbTamanio"
        Me.chbTamanio.Size = New System.Drawing.Size(65, 17)
        Me.chbTamanio.TabIndex = 19
        Me.chbTamanio.Text = "Tamaño"
        Me.chbTamanio.UseVisualStyleBackColor = True
        '
        'txtTamanio
        '
        Me.txtTamanio.BindearPropiedadControl = "Text"
        Me.txtTamanio.BindearPropiedadEntidad = "Tamano"
        Me.txtTamanio.Enabled = False
        Me.txtTamanio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanio.Formato = "#0.000"
        Me.txtTamanio.IsDecimal = True
        Me.txtTamanio.IsNumber = True
        Me.txtTamanio.IsPK = False
        Me.txtTamanio.IsRequired = False
        Me.txtTamanio.Key = ""
        Me.txtTamanio.LabelAsoc = Nothing
        Me.txtTamanio.Location = New System.Drawing.Point(1036, 41)
        Me.txtTamanio.MaxLength = 7
        Me.txtTamanio.Name = "txtTamanio"
        Me.txtTamanio.Size = New System.Drawing.Size(80, 20)
        Me.txtTamanio.TabIndex = 20
        Me.txtTamanio.Text = "0.000"
        Me.txtTamanio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.chbIdPedido.Location = New System.Drawing.Point(745, 43)
        Me.chbIdPedido.Name = "chbIdPedido"
        Me.chbIdPedido.Size = New System.Drawing.Size(63, 17)
        Me.chbIdPedido.TabIndex = 17
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
        Me.txtIdPedido.Location = New System.Drawing.Point(812, 41)
        Me.txtIdPedido.MaxLength = 10
        Me.txtIdPedido.Name = "txtIdPedido"
        Me.txtIdPedido.Size = New System.Drawing.Size(91, 20)
        Me.txtIdPedido.TabIndex = 18
        Me.txtIdPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.chbCliente.Location = New System.Drawing.Point(2, 43)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 12
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 140
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ColumnasAlineacion = Nothing
        Me.bscCodigoCliente.ColumnasAncho = Nothing
        Me.bscCodigoCliente.ColumnasFormato = Nothing
        Me.bscCodigoCliente.ColumnasOcultas = Nothing
        Me.bscCodigoCliente.ColumnasTitulos = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(91, 41)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoCliente.TabIndex = 13
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 140
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ColumnasAlineacion = Nothing
        Me.bscCliente.ColumnasAncho = Nothing
        Me.bscCliente.ColumnasFormato = Nothing
        Me.bscCliente.ColumnasOcultas = Nothing
        Me.bscCliente.ColumnasTitulos = Nothing
        Me.bscCliente.Datos = Nothing
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
        Me.bscCliente.Location = New System.Drawing.Point(188, 40)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = False
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 14
        Me.bscCliente.Titulo = Nothing
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(698, 181)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 3
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.Location = New System.Drawing.Point(1016, 173)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(935, 177)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 5
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
        Me.cmbTodos.Location = New System.Drawing.Point(808, 178)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 4
        '
        'OrdenesProduccionAdminV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 553)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.chkExpandAll)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "OrdenesProduccionAdminV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de Ordenes de Producción"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.pnlMarcas.ResumeLayout(False)
        Me.pnlMarcas.PerformLayout()
        Me.pnlModelos.ResumeLayout(False)
        Me.pnlModelos.PerformLayout()
        Me.pnlRubros.ResumeLayout(False)
        Me.pnlRubros.PerformLayout()
        Me.pnlSubRubros.ResumeLayout(False)
        Me.pnlSubRubros.PerformLayout()
        Me.pnlSubSubRubros.ResumeLayout(False)
        Me.pnlSubSubRubros.PerformLayout()
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
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbIdPedido As Eniac.Controles.CheckBox
   Friend WithEvents txtIdPedido As Eniac.Controles.TextBox
   Friend WithEvents chbTamanio As Eniac.Controles.CheckBox
   Friend WithEvents txtTamanio As Eniac.Controles.TextBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbEstados As Eniac.Controles.ComboBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbModificarPedido As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbOrdenCompra As Eniac.Controles.CheckBox
   Friend WithEvents txtOrdenCompra As Eniac.Controles.TextBox
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Friend WithEvents cmbResponsable As Controles.ComboBox
   Friend WithEvents chbResponsable As Controles.CheckBox
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobante As Controles.Label
   Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
   Friend WithEvents pnlMarcas As Panel
   Friend WithEvents lblMarcas As Controles.Label
   Friend WithEvents cmbMarcas As ComboBoxMarcas
   Friend WithEvents pnlModelos As Panel
   Friend WithEvents cmbModelos As ComboBoxModelos
   Friend WithEvents lblModelos As Controles.Label
   Friend WithEvents pnlRubros As Panel
   Friend WithEvents cmbRubros As ComboBoxRubro
   Friend WithEvents lblRubros As Controles.Label
   Friend WithEvents pnlSubRubros As Panel
   Friend WithEvents cmbSubRubros As ComboBoxSubRubro
   Friend WithEvents lblSubRubros As Controles.Label
   Friend WithEvents pnlSubSubRubros As Panel
   Friend WithEvents cmbSubSubRubros As ComboBoxSubSubRubro
   Friend WithEvents lblSubSubRubros As Controles.Label
   Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
   Friend WithEvents tsbCambiar As ToolStripButton
    Friend WithEvents dtpHastaPlanMaestro As Controles.DateTimePicker
    Friend WithEvents lblHastaPlanMaestro As Controles.Label
    Friend WithEvents dtpDesdePlanMaestro As Controles.DateTimePicker
    Friend WithEvents lblDesdePlanMaestro As Controles.Label
    Friend WithEvents chbFechaPlanMaestro As Controles.CheckBox
    Friend WithEvents chbPlanMaestro As Controles.CheckBox
    Friend WithEvents txtPlanMaestro As Controles.TextBox
End Class
