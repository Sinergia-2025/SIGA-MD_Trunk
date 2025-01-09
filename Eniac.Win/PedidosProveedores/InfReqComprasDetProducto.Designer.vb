<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InfReqComprasDetProducto
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRequerimientoCompra")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionTipoComprobante")
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrevTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroRequerimiento")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha_Fecha")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha_Hora")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuarioAlta")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUnidadDeMedida")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega_Fecha")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega_Hora")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionRQProducto")
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubSubRubro")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubSubRubro")
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdModelo")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreModelo")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedorHabitual")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedorHabitual")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedorHabitual")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalPedido")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobantePedido")
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionTipoComprobantePedido")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrevTipoComprobantePedido")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraPedido")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorPedido")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadAsignada")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedorAsignado")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedorAsignado")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedorAsignado")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario Asignación")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAsignacion")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAsignacion_Fecha")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAsignacion_Hora")
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PlanMaestroNumero")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PlanMaestroFecha")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadUMCompra")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FactorConversionCompra")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedidaCompra")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUnidadDeMedidaCompra")
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
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.chbFechaPlanMaestro = New Eniac.Controles.CheckBox()
        Me.chkMesCompletoPlanMaestro = New Eniac.Controles.CheckBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.dtpPlanMaestroHasta = New Eniac.Controles.DateTimePicker()
        Me.Label1 = New Eniac.Controles.Label()
        Me.txtPlanMaestro = New Eniac.Controles.TextBox()
        Me.dtpPlanMaestroDesde = New Eniac.Controles.DateTimePicker()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.bscNombreProveedor = New Eniac.Controles.Buscador2()
        Me.chbPlanMaestro = New Eniac.Controles.CheckBox()
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
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.lblAsignados = New Eniac.Controles.Label()
        Me.chbIdRequerimiento = New Eniac.Controles.CheckBox()
        Me.txtIdRequerimiento = New Eniac.Controles.TextBox()
        Me.cmbAsignados = New Eniac.Controles.ComboBox()
        Me.chbUsuarioAlta = New Eniac.Controles.CheckBox()
        Me.cmbUsuarioAlta = New Eniac.Controles.ComboBox()
        Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.bscProducto = New Eniac.Controles.Buscador2()
        Me.chkMesCompletoEntrega = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpEntregaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblEntregaHasta = New Eniac.Controles.Label()
        Me.dtpEntregaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblEntregaDesde = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Win.ButtonConsultar()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
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
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbConsultar.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMarcas.SuspendLayout()
        Me.pnlModelos.SuspendLayout()
        Me.pnlRubros.SuspendLayout()
        Me.pnlSubRubros.SuspendLayout()
        Me.pnlSubSubRubros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1016, 17)
        Me.tssInfo.Spring = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1095, 22)
        Me.stsStado.TabIndex = 4
        Me.stsStado.Text = "statusStrip1"
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Id Req."
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 40
        UltraGridColumn2.Header.Caption = "Código Tp. Comp."
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 100
        UltraGridColumn40.Header.Caption = "Tp. Comp."
        UltraGridColumn40.Header.VisiblePosition = 2
        UltraGridColumn40.Width = 100
        UltraGridColumn41.Header.Caption = "Tp. Comp."
        UltraGridColumn41.Header.VisiblePosition = 3
        UltraGridColumn41.Hidden = True
        UltraGridColumn41.Width = 80
        UltraGridColumn3.Header.Caption = "L."
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.Width = 20
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance3
        UltraGridColumn4.Header.Caption = "Emisor"
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Width = 50
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance4
        UltraGridColumn5.Header.Caption = "Número"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 70
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance5
        UltraGridColumn6.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn6.Header.Caption = "Fecha/Hora"
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 100
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance6
        UltraGridColumn7.Format = "dd/MM/yyyy"
        UltraGridColumn7.Header.Caption = "Fecha"
        UltraGridColumn7.Header.VisiblePosition = 8
        UltraGridColumn7.Width = 70
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance7
        UltraGridColumn8.Format = "HH:mm:ss"
        UltraGridColumn8.Header.Caption = "Hora"
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.Width = 70
        UltraGridColumn9.Header.Caption = "Observaciones"
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn9.Width = 200
        UltraGridColumn10.Header.Caption = "Usuario Alta"
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Width = 80
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance8
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridColumn12.Width = 50
        UltraGridColumn11.Header.Caption = "Código Producto"
        UltraGridColumn11.Header.VisiblePosition = 13
        UltraGridColumn11.Width = 100
        UltraGridColumn13.Header.Caption = "Producto"
        UltraGridColumn13.Header.VisiblePosition = 14
        UltraGridColumn13.Width = 150
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance9
        UltraGridColumn14.Format = ""
        UltraGridColumn14.Header.VisiblePosition = 15
        UltraGridColumn14.Width = 80
        UltraGridColumn15.Header.Caption = "U.M."
        UltraGridColumn15.Header.VisiblePosition = 18
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 40
        UltraGridColumn16.Header.Caption = "Unid. Medida"
        UltraGridColumn16.Header.VisiblePosition = 19
        UltraGridColumn16.Width = 100
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn17.CellAppearance = Appearance10
        UltraGridColumn17.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn17.Header.Caption = "Fecha/Hora Entrega"
        UltraGridColumn17.Header.VisiblePosition = 21
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 100
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn18.CellAppearance = Appearance11
        UltraGridColumn18.Format = "dd/MM/yyyy"
        UltraGridColumn18.Header.Caption = "Fecha Entrega"
        UltraGridColumn18.Header.VisiblePosition = 22
        UltraGridColumn18.Width = 70
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn19.CellAppearance = Appearance12
        UltraGridColumn19.Format = "HH:mm:ss"
        UltraGridColumn19.Header.Caption = "Hora Entrega"
        UltraGridColumn19.Header.VisiblePosition = 23
        UltraGridColumn19.Width = 70
        UltraGridColumn20.Header.Caption = "Observaciones Producto"
        UltraGridColumn20.Header.VisiblePosition = 24
        UltraGridColumn20.Width = 200
        UltraGridColumn46.Header.Caption = "Código Rubro"
        UltraGridColumn46.Header.VisiblePosition = 25
        UltraGridColumn46.Hidden = True
        UltraGridColumn21.Header.Caption = "Rubro"
        UltraGridColumn21.Header.VisiblePosition = 26
        UltraGridColumn21.Width = 120
        UltraGridColumn47.Header.Caption = "Código SubRubro"
        UltraGridColumn47.Header.VisiblePosition = 28
        UltraGridColumn47.Hidden = True
        UltraGridColumn22.Header.Caption = "SubRubro"
        UltraGridColumn22.Header.VisiblePosition = 27
        UltraGridColumn22.Width = 120
        UltraGridColumn48.Header.Caption = "Código SubSubRubro"
        UltraGridColumn48.Header.VisiblePosition = 31
        UltraGridColumn48.Hidden = True
        UltraGridColumn23.Header.Caption = "SubSubRubro"
        UltraGridColumn23.Header.VisiblePosition = 29
        UltraGridColumn23.Width = 120
        UltraGridColumn49.Header.Caption = "Código Marca"
        UltraGridColumn49.Header.VisiblePosition = 34
        UltraGridColumn49.Hidden = True
        UltraGridColumn24.Header.Caption = "Marca"
        UltraGridColumn24.Header.VisiblePosition = 30
        UltraGridColumn24.Width = 120
        UltraGridColumn50.Header.Caption = "Código Modelo"
        UltraGridColumn50.Header.VisiblePosition = 37
        UltraGridColumn50.Hidden = True
        UltraGridColumn25.Header.Caption = "Modelo"
        UltraGridColumn25.Header.VisiblePosition = 32
        UltraGridColumn25.Width = 120
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance13
        UltraGridColumn26.Header.VisiblePosition = 33
        UltraGridColumn26.Hidden = True
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance14
        UltraGridColumn27.Header.Caption = "Código Prov. Hab."
        UltraGridColumn27.Header.VisiblePosition = 35
        UltraGridColumn27.Width = 80
        UltraGridColumn28.Header.Caption = "Proveedor Habitual"
        UltraGridColumn28.Header.VisiblePosition = 36
        UltraGridColumn28.Width = 150
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance15
        UltraGridColumn29.Header.Caption = "S. P."
        UltraGridColumn29.Header.VisiblePosition = 38
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Width = 40
        UltraGridColumn30.Header.Caption = "Código Tp. Compr. Pedido"
        UltraGridColumn30.Header.VisiblePosition = 39
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 100
        UltraGridColumn42.Header.Caption = "Tp. Comp. Pedido"
        UltraGridColumn42.Header.VisiblePosition = 40
        UltraGridColumn42.Width = 120
        UltraGridColumn43.Header.Caption = "Tp. Comp. Pedido"
        UltraGridColumn43.Header.VisiblePosition = 41
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.Width = 100
        UltraGridColumn31.Header.Caption = "L. P."
        UltraGridColumn31.Header.VisiblePosition = 42
        UltraGridColumn31.Width = 40
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance16
        UltraGridColumn32.Header.Caption = "Emisor Pedido"
        UltraGridColumn32.Header.VisiblePosition = 43
        UltraGridColumn32.Width = 60
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance17
        UltraGridColumn33.Header.Caption = "Número Pedido"
        UltraGridColumn33.Header.VisiblePosition = 44
        UltraGridColumn33.Width = 80
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance18
        UltraGridColumn34.Format = "N2"
        UltraGridColumn34.Header.Caption = "Cantidad Asignada"
        UltraGridColumn34.Header.VisiblePosition = 45
        UltraGridColumn34.Width = 80
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance19
        UltraGridColumn35.Header.VisiblePosition = 46
        UltraGridColumn35.Hidden = True
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance20
        UltraGridColumn36.Header.Caption = "Código Prov. Asig."
        UltraGridColumn36.Header.VisiblePosition = 47
        UltraGridColumn36.Width = 80
        UltraGridColumn37.Header.Caption = "Proveedor Asignado"
        UltraGridColumn37.Header.VisiblePosition = 48
        UltraGridColumn37.Width = 150
        UltraGridColumn38.Header.VisiblePosition = 49
        UltraGridColumn38.Width = 80
        Appearance21.TextHAlignAsString = "Center"
        UltraGridColumn39.CellAppearance = Appearance21
        UltraGridColumn39.Header.Caption = "Fecha/Hora Asignación"
        UltraGridColumn39.Header.VisiblePosition = 50
        UltraGridColumn39.Hidden = True
        UltraGridColumn39.Width = 100
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn44.CellAppearance = Appearance22
        UltraGridColumn44.Header.Caption = "Fecha Asignación"
        UltraGridColumn44.Header.VisiblePosition = 51
        UltraGridColumn44.Width = 70
        Appearance23.TextHAlignAsString = "Center"
        UltraGridColumn45.CellAppearance = Appearance23
        UltraGridColumn45.Header.Caption = "Hora Asignación"
        UltraGridColumn45.Header.VisiblePosition = 52
        UltraGridColumn45.Width = 70
        UltraGridColumn51.Header.Caption = "Plan Maestro"
        UltraGridColumn51.Header.VisiblePosition = 53
        UltraGridColumn51.Width = 60
        UltraGridColumn52.Header.Caption = "Plan Maestro Fecha"
        UltraGridColumn52.Header.VisiblePosition = 54
        UltraGridColumn52.Width = 80
        UltraGridColumn53.Header.Caption = "Orden Producción"
        UltraGridColumn53.Header.VisiblePosition = 55
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn54.CellAppearance = Appearance24
        UltraGridColumn54.Format = ""
        UltraGridColumn54.Header.Caption = "Cantidad UMC"
        UltraGridColumn54.Header.VisiblePosition = 16
        UltraGridColumn54.Width = 80
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn55.CellAppearance = Appearance25
        UltraGridColumn55.Format = ""
        UltraGridColumn55.Header.Caption = "Factor Conversión Compra"
        UltraGridColumn55.Header.VisiblePosition = 17
        UltraGridColumn55.Width = 109
        UltraGridColumn56.Header.VisiblePosition = 56
        UltraGridColumn56.Hidden = True
        UltraGridColumn57.Header.Caption = "Unid. Medida Compra"
        UltraGridColumn57.Header.VisiblePosition = 20
        UltraGridColumn57.Width = 117
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn40, UltraGridColumn41, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn12, UltraGridColumn11, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn46, UltraGridColumn21, UltraGridColumn47, UltraGridColumn22, UltraGridColumn48, UltraGridColumn23, UltraGridColumn49, UltraGridColumn24, UltraGridColumn50, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn42, UltraGridColumn43, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn44, UltraGridColumn45, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance35
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 242)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1095, 297)
        Me.ugDetalle.TabIndex = 3
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'grbConsultar
        '
        Me.grbConsultar.AutoSize = True
        Me.grbConsultar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grbConsultar.Controls.Add(Me.chbFechaPlanMaestro)
        Me.grbConsultar.Controls.Add(Me.chkMesCompletoPlanMaestro)
        Me.grbConsultar.Controls.Add(Me.Label3)
        Me.grbConsultar.Controls.Add(Me.dtpPlanMaestroHasta)
        Me.grbConsultar.Controls.Add(Me.txtPlanMaestro)
        Me.grbConsultar.Controls.Add(Me.dtpPlanMaestroDesde)
        Me.grbConsultar.Controls.Add(Me.Label1)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.bscNombreProveedor)
        Me.grbConsultar.Controls.Add(Me.chbPlanMaestro)
        Me.grbConsultar.Controls.Add(Me.chbProveedor)
        Me.grbConsultar.Controls.Add(Me.FlowLayoutPanel1)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.chbFechaEntrega)
        Me.grbConsultar.Controls.Add(Me.chbFecha)
        Me.grbConsultar.Controls.Add(Me.lblAsignados)
        Me.grbConsultar.Controls.Add(Me.chbIdRequerimiento)
        Me.grbConsultar.Controls.Add(Me.txtIdRequerimiento)
        Me.grbConsultar.Controls.Add(Me.cmbAsignados)
        Me.grbConsultar.Controls.Add(Me.chbUsuarioAlta)
        Me.grbConsultar.Controls.Add(Me.cmbUsuarioAlta)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProducto)
        Me.grbConsultar.Controls.Add(Me.bscProducto)
        Me.grbConsultar.Controls.Add(Me.chbProducto)
        Me.grbConsultar.Controls.Add(Me.chkMesCompletoEntrega)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpEntregaHasta)
        Me.grbConsultar.Controls.Add(Me.dtpEntregaDesde)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.lblEntregaHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblEntregaDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbConsultar.Location = New System.Drawing.Point(0, 29)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Padding = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.grbConsultar.Size = New System.Drawing.Size(1095, 194)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Filtros"
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
        Me.chbFechaPlanMaestro.Location = New System.Drawing.Point(182, 101)
        Me.chbFechaPlanMaestro.Name = "chbFechaPlanMaestro"
        Me.chbFechaPlanMaestro.Size = New System.Drawing.Size(121, 17)
        Me.chbFechaPlanMaestro.TabIndex = 33
        Me.chbFechaPlanMaestro.Text = "Fecha Plan Maestro"
        Me.chbFechaPlanMaestro.UseVisualStyleBackColor = True
        '
        'chkMesCompletoPlanMaestro
        '
        Me.chkMesCompletoPlanMaestro.AutoSize = True
        Me.chkMesCompletoPlanMaestro.BindearPropiedadControl = Nothing
        Me.chkMesCompletoPlanMaestro.BindearPropiedadEntidad = Nothing
        Me.chkMesCompletoPlanMaestro.Enabled = False
        Me.chkMesCompletoPlanMaestro.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompletoPlanMaestro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompletoPlanMaestro.IsPK = False
        Me.chkMesCompletoPlanMaestro.IsRequired = False
        Me.chkMesCompletoPlanMaestro.Key = Nothing
        Me.chkMesCompletoPlanMaestro.LabelAsoc = Nothing
        Me.chkMesCompletoPlanMaestro.Location = New System.Drawing.Point(310, 101)
        Me.chkMesCompletoPlanMaestro.Name = "chkMesCompletoPlanMaestro"
        Me.chkMesCompletoPlanMaestro.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompletoPlanMaestro.TabIndex = 34
        Me.chkMesCompletoPlanMaestro.Text = "Mes Completo"
        Me.chkMesCompletoPlanMaestro.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(404, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Desde"
        '
        'dtpPlanMaestroHasta
        '
        Me.dtpPlanMaestroHasta.BindearPropiedadControl = Nothing
        Me.dtpPlanMaestroHasta.BindearPropiedadEntidad = Nothing
        Me.dtpPlanMaestroHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpPlanMaestroHasta.Enabled = False
        Me.dtpPlanMaestroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpPlanMaestroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpPlanMaestroHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPlanMaestroHasta.IsPK = False
        Me.dtpPlanMaestroHasta.IsRequired = False
        Me.dtpPlanMaestroHasta.Key = ""
        Me.dtpPlanMaestroHasta.LabelAsoc = Me.Label1
        Me.dtpPlanMaestroHasta.Location = New System.Drawing.Point(624, 97)
        Me.dtpPlanMaestroHasta.Name = "dtpPlanMaestroHasta"
        Me.dtpPlanMaestroHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpPlanMaestroHasta.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(583, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Hasta"
        '
        'txtPlanMaestro
        '
        Me.txtPlanMaestro.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlanMaestro.BindearPropiedadControl = Nothing
        Me.txtPlanMaestro.BindearPropiedadEntidad = Nothing
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
        Me.txtPlanMaestro.Location = New System.Drawing.Point(103, 97)
        Me.txtPlanMaestro.MaxLength = 8
        Me.txtPlanMaestro.Name = "txtPlanMaestro"
        Me.txtPlanMaestro.Size = New System.Drawing.Size(65, 20)
        Me.txtPlanMaestro.TabIndex = 31
        Me.txtPlanMaestro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpPlanMaestroDesde
        '
        Me.dtpPlanMaestroDesde.BindearPropiedadControl = Nothing
        Me.dtpPlanMaestroDesde.BindearPropiedadEntidad = Nothing
        Me.dtpPlanMaestroDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpPlanMaestroDesde.Enabled = False
        Me.dtpPlanMaestroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpPlanMaestroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpPlanMaestroDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPlanMaestroDesde.IsPK = False
        Me.dtpPlanMaestroDesde.IsRequired = False
        Me.dtpPlanMaestroDesde.Key = ""
        Me.dtpPlanMaestroDesde.LabelAsoc = Nothing
        Me.dtpPlanMaestroDesde.Location = New System.Drawing.Point(448, 97)
        Me.dtpPlanMaestroDesde.Name = "dtpPlanMaestroDesde"
        Me.dtpPlanMaestroDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpPlanMaestroDesde.TabIndex = 28
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
        Me.bscCodigoProveedor.LabelAsoc = Me.chbProveedor
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(691, 68)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = False
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 24
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
        Me.chbProveedor.Location = New System.Drawing.Point(579, 71)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 23
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'bscNombreProveedor
        '
        Me.bscNombreProveedor.ActivarFiltroEnGrilla = True
        Me.bscNombreProveedor.AutoSize = True
        Me.bscNombreProveedor.BindearPropiedadControl = Nothing
        Me.bscNombreProveedor.BindearPropiedadEntidad = Nothing
        Me.bscNombreProveedor.ConfigBuscador = Nothing
        Me.bscNombreProveedor.Datos = Nothing
        Me.bscNombreProveedor.FilaDevuelta = Nothing
        Me.bscNombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProveedor.IsDecimal = False
        Me.bscNombreProveedor.IsNumber = False
        Me.bscNombreProveedor.IsPK = False
        Me.bscNombreProveedor.IsRequired = False
        Me.bscNombreProveedor.Key = ""
        Me.bscNombreProveedor.LabelAsoc = Me.chbProveedor
        Me.bscNombreProveedor.Location = New System.Drawing.Point(788, 68)
        Me.bscNombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreProveedor.MaxLengh = "32767"
        Me.bscNombreProveedor.Name = "bscNombreProveedor"
        Me.bscNombreProveedor.Permitido = False
        Me.bscNombreProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.Selecciono = False
        Me.bscNombreProveedor.Size = New System.Drawing.Size(294, 23)
        Me.bscNombreProveedor.TabIndex = 25
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
        Me.chbPlanMaestro.Location = New System.Drawing.Point(10, 98)
        Me.chbPlanMaestro.Name = "chbPlanMaestro"
        Me.chbPlanMaestro.Size = New System.Drawing.Size(88, 17)
        Me.chbPlanMaestro.TabIndex = 27
        Me.chbPlanMaestro.Text = "Plan Maestro"
        Me.chbPlanMaestro.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMarcas)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlModelos)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubRubros)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSubSubRubros)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 124)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1037, 57)
        Me.FlowLayoutPanel1.TabIndex = 26
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
        Me.pnlSubSubRubros.Size = New System.Drawing.Size(281, 30)
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
        Me.cmbSubSubRubros.Location = New System.Drawing.Point(81, 9)
        Me.cmbSubSubRubros.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSubSubRubros.Name = "cmbSubSubRubros"
        Me.cmbSubSubRubros.Size = New System.Drawing.Size(200, 21)
        Me.cmbSubSubRubros.TabIndex = 1
        '
        'lblSubSubRubros
        '
        Me.lblSubSubRubros.AutoSize = True
        Me.lblSubSubRubros.LabelAsoc = Nothing
        Me.lblSubSubRubros.Location = New System.Drawing.Point(3, 12)
        Me.lblSubSubRubros.Name = "lblSubSubRubros"
        Me.lblSubSubRubros.Size = New System.Drawing.Size(79, 13)
        Me.lblSubSubRubros.TabIndex = 0
        Me.lblSubSubRubros.Text = "SubSubRubros"
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
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(691, 15)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(140, 21)
        Me.cmbTiposComprobantes.TabIndex = 13
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(576, 19)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(109, 13)
        Me.lblTipoComprobante.TabIndex = 12
        Me.lblTipoComprobante.Text = "Tipo Comprobrobante"
        '
        'chbFechaEntrega
        '
        Me.chbFechaEntrega.AutoSize = True
        Me.chbFechaEntrega.BindearPropiedadControl = Nothing
        Me.chbFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.chbFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEntrega.IsPK = False
        Me.chbFechaEntrega.IsRequired = False
        Me.chbFechaEntrega.Key = Nothing
        Me.chbFechaEntrega.LabelAsoc = Nothing
        Me.chbFechaEntrega.Location = New System.Drawing.Point(10, 43)
        Me.chbFechaEntrega.Name = "chbFechaEntrega"
        Me.chbFechaEntrega.Size = New System.Drawing.Size(93, 17)
        Me.chbFechaEntrega.TabIndex = 6
        Me.chbFechaEntrega.Text = "FechaEntrega"
        Me.chbFechaEntrega.UseVisualStyleBackColor = True
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
        Me.chbFecha.Location = New System.Drawing.Point(10, 17)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 0
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'lblAsignados
        '
        Me.lblAsignados.AutoSize = True
        Me.lblAsignados.LabelAsoc = Nothing
        Me.lblAsignados.Location = New System.Drawing.Point(576, 45)
        Me.lblAsignados.Name = "lblAsignados"
        Me.lblAsignados.Size = New System.Drawing.Size(56, 13)
        Me.lblAsignados.TabIndex = 16
        Me.lblAsignados.Text = "Asignados"
        '
        'chbIdRequerimiento
        '
        Me.chbIdRequerimiento.AutoSize = True
        Me.chbIdRequerimiento.BindearPropiedadControl = Nothing
        Me.chbIdRequerimiento.BindearPropiedadEntidad = Nothing
        Me.chbIdRequerimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIdRequerimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIdRequerimiento.IsPK = False
        Me.chbIdRequerimiento.IsRequired = False
        Me.chbIdRequerimiento.Key = Nothing
        Me.chbIdRequerimiento.LabelAsoc = Nothing
        Me.chbIdRequerimiento.Location = New System.Drawing.Point(845, 17)
        Me.chbIdRequerimiento.Name = "chbIdRequerimiento"
        Me.chbIdRequerimiento.Size = New System.Drawing.Size(63, 17)
        Me.chbIdRequerimiento.TabIndex = 14
        Me.chbIdRequerimiento.Text = "Número"
        Me.chbIdRequerimiento.UseVisualStyleBackColor = True
        '
        'txtIdRequerimiento
        '
        Me.txtIdRequerimiento.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdRequerimiento.BindearPropiedadControl = Nothing
        Me.txtIdRequerimiento.BindearPropiedadEntidad = Nothing
        Me.txtIdRequerimiento.Enabled = False
        Me.txtIdRequerimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdRequerimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdRequerimiento.Formato = ""
        Me.txtIdRequerimiento.IsDecimal = False
        Me.txtIdRequerimiento.IsNumber = True
        Me.txtIdRequerimiento.IsPK = False
        Me.txtIdRequerimiento.IsRequired = False
        Me.txtIdRequerimiento.Key = ""
        Me.txtIdRequerimiento.LabelAsoc = Nothing
        Me.txtIdRequerimiento.Location = New System.Drawing.Point(912, 15)
        Me.txtIdRequerimiento.MaxLength = 8
        Me.txtIdRequerimiento.Name = "txtIdRequerimiento"
        Me.txtIdRequerimiento.Size = New System.Drawing.Size(65, 20)
        Me.txtIdRequerimiento.TabIndex = 15
        Me.txtIdRequerimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbAsignados
        '
        Me.cmbAsignados.BindearPropiedadControl = ""
        Me.cmbAsignados.BindearPropiedadEntidad = ""
        Me.cmbAsignados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAsignados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAsignados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAsignados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAsignados.FormattingEnabled = True
        Me.cmbAsignados.IsPK = False
        Me.cmbAsignados.IsRequired = False
        Me.cmbAsignados.Key = Nothing
        Me.cmbAsignados.LabelAsoc = Me.lblAsignados
        Me.cmbAsignados.Location = New System.Drawing.Point(691, 41)
        Me.cmbAsignados.Name = "cmbAsignados"
        Me.cmbAsignados.Size = New System.Drawing.Size(140, 21)
        Me.cmbAsignados.TabIndex = 17
        '
        'chbUsuarioAlta
        '
        Me.chbUsuarioAlta.AutoSize = True
        Me.chbUsuarioAlta.BindearPropiedadControl = Nothing
        Me.chbUsuarioAlta.BindearPropiedadEntidad = Nothing
        Me.chbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuarioAlta.IsPK = False
        Me.chbUsuarioAlta.IsRequired = False
        Me.chbUsuarioAlta.Key = Nothing
        Me.chbUsuarioAlta.LabelAsoc = Nothing
        Me.chbUsuarioAlta.Location = New System.Drawing.Point(845, 43)
        Me.chbUsuarioAlta.Name = "chbUsuarioAlta"
        Me.chbUsuarioAlta.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuarioAlta.TabIndex = 18
        Me.chbUsuarioAlta.Text = "Usuario"
        Me.chbUsuarioAlta.UseVisualStyleBackColor = True
        '
        'cmbUsuarioAlta
        '
        Me.cmbUsuarioAlta.BindearPropiedadControl = Nothing
        Me.cmbUsuarioAlta.BindearPropiedadEntidad = Nothing
        Me.cmbUsuarioAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarioAlta.Enabled = False
        Me.cmbUsuarioAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuarioAlta.FormattingEnabled = True
        Me.cmbUsuarioAlta.IsPK = False
        Me.cmbUsuarioAlta.IsRequired = False
        Me.cmbUsuarioAlta.Key = Nothing
        Me.cmbUsuarioAlta.LabelAsoc = Nothing
        Me.cmbUsuarioAlta.Location = New System.Drawing.Point(912, 41)
        Me.cmbUsuarioAlta.Name = "cmbUsuarioAlta"
        Me.cmbUsuarioAlta.Size = New System.Drawing.Size(140, 21)
        Me.cmbUsuarioAlta.TabIndex = 19
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
        Me.bscCodigoProducto.LabelAsoc = Me.chbProducto
        Me.bscCodigoProducto.Location = New System.Drawing.Point(85, 68)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = False
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProducto.TabIndex = 21
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
        Me.chbProducto.Location = New System.Drawing.Point(10, 71)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 20
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'bscProducto
        '
        Me.bscProducto.ActivarFiltroEnGrilla = True
        Me.bscProducto.AutoSize = True
        Me.bscProducto.BindearPropiedadControl = Nothing
        Me.bscProducto.BindearPropiedadEntidad = Nothing
        Me.bscProducto.ConfigBuscador = Nothing
        Me.bscProducto.Datos = Nothing
        Me.bscProducto.FilaDevuelta = Nothing
        Me.bscProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto.IsDecimal = False
        Me.bscProducto.IsNumber = False
        Me.bscProducto.IsPK = False
        Me.bscProducto.IsRequired = False
        Me.bscProducto.Key = ""
        Me.bscProducto.LabelAsoc = Me.chbProducto
        Me.bscProducto.Location = New System.Drawing.Point(182, 68)
        Me.bscProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProducto.MaxLengh = "32767"
        Me.bscProducto.Name = "bscProducto"
        Me.bscProducto.Permitido = False
        Me.bscProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto.Selecciono = False
        Me.bscProducto.Size = New System.Drawing.Size(300, 23)
        Me.bscProducto.TabIndex = 22
        '
        'chkMesCompletoEntrega
        '
        Me.chkMesCompletoEntrega.AutoSize = True
        Me.chkMesCompletoEntrega.BindearPropiedadControl = Nothing
        Me.chkMesCompletoEntrega.BindearPropiedadEntidad = Nothing
        Me.chkMesCompletoEntrega.Enabled = False
        Me.chkMesCompletoEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompletoEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompletoEntrega.IsPK = False
        Me.chkMesCompletoEntrega.IsRequired = False
        Me.chkMesCompletoEntrega.Key = Nothing
        Me.chkMesCompletoEntrega.LabelAsoc = Nothing
        Me.chkMesCompletoEntrega.Location = New System.Drawing.Point(109, 43)
        Me.chkMesCompletoEntrega.Name = "chkMesCompletoEntrega"
        Me.chkMesCompletoEntrega.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompletoEntrega.TabIndex = 7
        Me.chkMesCompletoEntrega.Text = "Mes Completo"
        Me.chkMesCompletoEntrega.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(109, 17)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 1
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpEntregaHasta
        '
        Me.dtpEntregaHasta.BindearPropiedadControl = Nothing
        Me.dtpEntregaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpEntregaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpEntregaHasta.Enabled = False
        Me.dtpEntregaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpEntregaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpEntregaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEntregaHasta.IsPK = False
        Me.dtpEntregaHasta.IsRequired = False
        Me.dtpEntregaHasta.Key = ""
        Me.dtpEntregaHasta.LabelAsoc = Me.lblEntregaHasta
        Me.dtpEntregaHasta.Location = New System.Drawing.Point(430, 41)
        Me.dtpEntregaHasta.Name = "dtpEntregaHasta"
        Me.dtpEntregaHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpEntregaHasta.TabIndex = 11
        '
        'lblEntregaHasta
        '
        Me.lblEntregaHasta.AutoSize = True
        Me.lblEntregaHasta.LabelAsoc = Nothing
        Me.lblEntregaHasta.Location = New System.Drawing.Point(389, 45)
        Me.lblEntregaHasta.Name = "lblEntregaHasta"
        Me.lblEntregaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblEntregaHasta.TabIndex = 10
        Me.lblEntregaHasta.Text = "Hasta"
        '
        'dtpEntregaDesde
        '
        Me.dtpEntregaDesde.BindearPropiedadControl = Nothing
        Me.dtpEntregaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpEntregaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpEntregaDesde.Enabled = False
        Me.dtpEntregaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpEntregaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEntregaDesde.IsPK = False
        Me.dtpEntregaDesde.IsRequired = False
        Me.dtpEntregaDesde.Key = ""
        Me.dtpEntregaDesde.LabelAsoc = Me.lblEntregaDesde
        Me.dtpEntregaDesde.Location = New System.Drawing.Point(252, 41)
        Me.dtpEntregaDesde.Name = "dtpEntregaDesde"
        Me.dtpEntregaDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpEntregaDesde.TabIndex = 9
        '
        'lblEntregaDesde
        '
        Me.lblEntregaDesde.AutoSize = True
        Me.lblEntregaDesde.LabelAsoc = Nothing
        Me.lblEntregaDesde.Location = New System.Drawing.Point(208, 45)
        Me.lblEntregaDesde.Name = "lblEntregaDesde"
        Me.lblEntregaDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblEntregaDesde.TabIndex = 8
        Me.lblEntregaDesde.Text = "Desde"
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
        Me.dtpHasta.Location = New System.Drawing.Point(430, 15)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(389, 19)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
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
        Me.dtpDesde.Location = New System.Drawing.Point(252, 15)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 3
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(208, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 2
        Me.lblDesde.Text = "Desde"
        '
        'btnConsultar
        '
        Me.btnConsultar.AnchoredControl = Me.ugDetalle
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(988, 246)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(104, 30)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance37.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance37.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance37
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
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.tsbSalir, Me.ToolStripSeparator4})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1095, 29)
        Me.tstBarra.TabIndex = 5
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
        Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.chkExpandAll)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 223)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1095, 19)
        Me.pnlAcciones.TabIndex = 1
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(985, 2)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 0
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'InfReqComprasDetProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 561)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.KeyPreview = True
        Me.Name = "InfReqComprasDetProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Requerimientos de Compra Detallado por Producto"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
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
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents chbIdRequerimiento As Eniac.Controles.CheckBox
   Friend WithEvents txtIdRequerimiento As Eniac.Controles.TextBox
   Friend WithEvents chbUsuarioAlta As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuarioAlta As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As ButtonConsultar
   Friend WithEvents bscCodigoProducto As Eniac.Controles.Buscador2
   Friend WithEvents bscProducto As Eniac.Controles.Buscador2
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Public WithEvents tsbPreferencias As ToolStripButton
   Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
   Friend WithEvents chbFechaEntrega As Controles.CheckBox
   Friend WithEvents lblAsignados As Controles.Label
   Friend WithEvents cmbAsignados As Controles.ComboBox
   Friend WithEvents chkMesCompletoEntrega As Controles.CheckBox
   Friend WithEvents dtpEntregaHasta As Controles.DateTimePicker
   Friend WithEvents lblEntregaHasta As Controles.Label
   Friend WithEvents dtpEntregaDesde As Controles.DateTimePicker
   Friend WithEvents lblEntregaDesde As Controles.Label
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
   Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
   Friend WithEvents pnlAcciones As Panel
   Friend WithEvents chkExpandAll As CheckBox
   Friend WithEvents bscCodigoProveedor As Controles.Buscador2
   Friend WithEvents chbProveedor As Controles.CheckBox
   Friend WithEvents bscNombreProveedor As Controles.Buscador2
    Friend WithEvents txtPlanMaestro As Controles.TextBox
    Friend WithEvents dtpPlanMaestroHasta As Controles.DateTimePicker
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents dtpPlanMaestroDesde As Controles.DateTimePicker
    Friend WithEvents chbPlanMaestro As Controles.CheckBox
    Friend WithEvents chbFechaPlanMaestro As Controles.CheckBox
    Friend WithEvents chkMesCompletoPlanMaestro As Controles.CheckBox
    Friend WithEvents Label3 As Controles.Label
End Class
